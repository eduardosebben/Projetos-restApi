using System;
using static System.String;

namespace BoletoNetCore
{
    [CarteiraCodigo("17/019", "17/027", "17/035", "17/043")]
    internal class BancoBrasilCarteira17 : ICarteira<BancoBrasil>
    {
        internal static Lazy<ICarteira<BancoBrasil>> Instance { get; } = new Lazy<ICarteira<BancoBrasil>>(() => new BancoBrasilCarteira17());

        private BancoBrasilCarteira17()
        {

        }

        public void FormataNossoNumero(Boleto boleto)
        {
            // Carteira 17 - Variação 019/027: Cliente emite o boleto
            // O nosso número não pode ser em branco.
            if (IsNullOrWhiteSpace(boleto.NossoNumero))
                boleto.NossoNumero = "";//boleto registrado não aceita nosso número somente em geração do boleto, mas em remessa CNAB é possível
                                        //throw new Exception("Nosso Número não informado.");

            // Se o convênio for de 7 dígitos,
            // o nosso número deve estar formatado corretamente (com 17 dígitos e iniciando com o código do convênio),
            if (boleto.Banco.Beneficiario.Codigo.Trim().Length > 6)
            {
                var nossoNumero = "";
                nossoNumero = "000000000" + boleto.NossoNumero;
                nossoNumero = nossoNumero.Substring(nossoNumero.Length - 10, 10);
                nossoNumero = boleto.Banco.Beneficiario.Codigo + nossoNumero;
                boleto.NossoNumero = $"{nossoNumero.Substring(nossoNumero.Length - 17,17)}";
                boleto.NossoNumeroFormatado = boleto.NossoNumero;
            }
            else{ 
                var nossoNumero = "";
                if (boleto.NossoNumero.Length < 11)
                {
                    nossoNumero = "0000000000" + boleto.NossoNumero;

                    nossoNumero = nossoNumero.Substring(nossoNumero.Length - 11, 11);
                }
                else
                {
                    nossoNumero = boleto.NossoNumero;
                }
                boleto.NossoNumero = $"{nossoNumero}";

                boleto.NossoNumeroDV = "";
                boleto.NossoNumeroFormatado = boleto.NossoNumero;
            }
        }

        public string FormataCodigoBarraCampoLivre(Boleto boleto)
        {
            if(boleto.Banco.Beneficiario.Codigo.Trim().Length > 6)
            {
                return $"000000{boleto.NossoNumero}" + "17";
            }
            else
            {
                var tipoCobranca = "";
                if (boleto.Banco.Beneficiario.ContaBancaria.TipoCarteiraPadrao.ToString().Contains("CarteiraCobrancaSimples"))
                    tipoCobranca = "01";
                if (boleto.Banco.Beneficiario.ContaBancaria.TipoCarteiraPadrao.ToString().Contains("CarteiraCobrancaVinculada"))
                    tipoCobranca = "02";
                if (boleto.Banco.Beneficiario.ContaBancaria.TipoCarteiraPadrao.ToString().Contains("CarteiraCobrancaCaucionada"))
                    tipoCobranca = "03";
                if (boleto.Banco.Beneficiario.ContaBancaria.TipoCarteiraPadrao.ToString().Contains("CarteiraCobrancaDescontada"))
                    tipoCobranca = "04";
                if (boleto.Banco.Beneficiario.ContaBancaria.TipoCarteiraPadrao.ToString().Contains("CarteiraCobrancaVendor"))
                    tipoCobranca = "05";
                if (boleto.Banco.Beneficiario.ContaBancaria.TipoCarteiraPadrao.ToString().Contains("CarteiraCobrancaDebito"))
                    tipoCobranca = "06";

                var conta = boleto.Banco.Beneficiario.ContaBancaria.Conta;
                if (boleto.Banco.Beneficiario.ContaBancaria.Conta.Length < 8)
                    conta = "000000" + boleto.Banco.Beneficiario.ContaBancaria.Conta;

                string CampoLivre = boleto.NossoNumero + boleto.Banco.Beneficiario.ContaBancaria.Agencia.Substring(boleto.Banco.Beneficiario.ContaBancaria.Agencia.Length - 4, 4) + conta.Substring(conta.Length - 8, 8) + tipoCobranca;

                return CampoLivre;
            }
        }
        public int Mod11(string seq)
        {
            /* Variáveis
             * -------------
             * d - Dígito
             * s - Soma
             * p - Peso
             * b - Base
             * r - Resto
             */

            int d, s = 0, p = 2, b = 9;

            for (int i = seq.Length - 1; i >= 0; i--)
            {
                s = s + (Convert.ToInt32(seq.Substring(i, 1)) * p);
                if (p < b)
                    p = p + 1;
                else
                    p = 2;
            }

            d = 11 - (s % 11);
            if (d > 9)
                d = 0;
            return d;
        }
    }
}
