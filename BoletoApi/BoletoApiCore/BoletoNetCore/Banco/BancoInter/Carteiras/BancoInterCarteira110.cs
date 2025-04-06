using System;
using BoletoNetCore.Exceptions;
using BoletoNetCore.Extensions;
using static System.String;

namespace BoletoNetCore
{
    [CarteiraCodigo("112")]
    internal class BancoInterCarteira110 : ICarteira<BancoInter>
    {
        internal static Lazy<ICarteira<BancoInter>> Instance { get; } = new Lazy<ICarteira<BancoInter>>(() => new BancoInterCarteira110());

        private BancoInterCarteira110()
        {

        }

        public void FormataNossoNumero(Boleto boleto)
        {

            // Nosso número não pode ter mais de 11 dígitos

            if (IsNullOrWhiteSpace(boleto.NossoNumero) || boleto.NossoNumero == "0000000000")
            {
                // Banco irá gerar Nosso Número
                boleto.NossoNumero = new String('0', 10);
                boleto.NossoNumeroDV = "0";
                boleto.NossoNumeroFormatado = boleto.NossoNumero + "-" + boleto.NossoNumeroDV;
            }
            else
            {
                var contaBancaria = boleto.Banco.Beneficiario.ContaBancaria;

                contaBancaria.Agencia = contaBancaria.Agencia.Substring(contaBancaria.Agencia.Length - 4, 4); 
                boleto.Carteira = boleto.Carteira.PadLeft(3, '0');
                boleto.NossoNumero = boleto.NossoNumero.Substring(boleto.NossoNumero.Length - 10, 10);
                boleto.NossoNumeroDV = (contaBancaria.Agencia + boleto.Carteira + boleto.NossoNumero).CalcularDVBancoInter();
                boleto.NossoNumeroFormatado = $"{contaBancaria.Agencia}{contaBancaria.DigitoAgencia}/{contaBancaria.CarteiraPadrao}/{boleto.NossoNumero}-{boleto.NossoNumeroDV}";
            }
            

        }

        public virtual string FormataCodigoBarraCampoLivre(Boleto boleto)
        {
            var contaBancaria = boleto.Banco.Beneficiario.ContaBancaria;
            return $"{contaBancaria.Agencia}{contaBancaria.CarteiraPadrao}{boleto.Banco.Beneficiario.CodigoTransmissao}{boleto.NossoNumero}{boleto.NossoNumeroDV}";
        }
    }
}
