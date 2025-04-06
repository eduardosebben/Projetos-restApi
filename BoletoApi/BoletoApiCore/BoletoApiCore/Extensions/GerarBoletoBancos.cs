using BoletoApiCore.Models;
using BoletoNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoletoApiCore.Extensions
{
    public class GerarBoletoBancos
    {
        readonly IBanco _banco;

        public GerarBoletoBancos(IBanco banco)
        {
            _banco = banco;
        }

        public string RetornarHtmlBoleto(DadosBoleto dadosBoleto)
        {
            // 1º Beneficiarios = Quem recebe o pagamento
            Beneficiario beneficiario = new Beneficiario()
            {
                CPFCNPJ = dadosBoleto.BeneficiarioResponse.CPFCNPJ,
                Nome = dadosBoleto.BeneficiarioResponse.Nome,
                Codigo = dadosBoleto.BeneficiarioResponse.BeneficiarioResponseId.ToString(),
                CodigoTransmissao = dadosBoleto.BeneficiarioResponse.CodigoTransmissao,
                ContaBancaria = new ContaBancaria()
                {
                    Agencia = dadosBoleto.BeneficiarioResponse.ContaBancariaResponse.Agencia,
                    Conta = dadosBoleto.BeneficiarioResponse.ContaBancariaResponse.Conta,
                    DigitoAgencia = dadosBoleto.BeneficiarioResponse.ContaBancariaResponse.DigitoAgencia,
                    CarteiraPadrao = dadosBoleto.BeneficiarioResponse.ContaBancariaResponse.CarteiraPadrao,
                    TipoCarteiraPadrao = TipoCarteira.CarteiraCobrancaSimples,
                    TipoFormaCadastramento = TipoFormaCadastramento.ComRegistro,
                    TipoImpressaoBoleto = TipoImpressaoBoleto.Empresa,
                    OperacaoConta = dadosBoleto.BeneficiarioResponse.ContaBancariaResponse.OperacaoConta,
                    MensagemFixaPagador = dadosBoleto.BeneficiarioResponse.ContaBancariaResponse.MensagemFixaPagador
                }
            };

            _banco.Beneficiario = beneficiario;
            _banco.FormataBeneficiario();

            var boleto = GerarBoleto(_banco, dadosBoleto);
            var boletoBancario = new BoletoBancario();
            boletoBancario.Boleto = boleto;

            return boletoBancario.MontaHtmlEmbedded();
        }

        public static Boleto GerarBoleto(IBanco iBanco, DadosBoleto dadosBoleto)
        {
            try
            {
                var vlrTitulo = (int)dadosBoleto.ValorTitulo;

                var boleto = new Boleto(iBanco);

                boleto.Pagador = GerarPagador(dadosBoleto);
                boleto.DataEmissao = dadosBoleto.DataEmissao;
                boleto.DataProcessamento = dadosBoleto.DataProcessamento;
                boleto.DataVencimento = dadosBoleto.DataVencimento;
                boleto.ValorTitulo = dadosBoleto.ValorTitulo;
                boleto.NossoNumero = dadosBoleto.NossoNumero;
                boleto.NumeroDocumento = dadosBoleto.NumeroDocumento;
                boleto.EspecieDocumento = TipoEspecieDocumento.DS;
                boleto.ImprimirValoresAuxiliares = true;
                boleto.codNota = dadosBoleto.codNota;
                if (dadosBoleto.PercentualJurosDia != 0 && !string.IsNullOrEmpty(dadosBoleto.DataJuros.ToString()))
                {
                    boleto.ValorJurosDia = dadosBoleto.ValorJurosDia.Value;
                    boleto.PercentualJurosDia = dadosBoleto.PercentualJurosDia.Value;
                    boleto.DataJuros = dadosBoleto.DataJuros.Value;
                    boleto.TipoJuros = dadosBoleto.TipoJuros.Value;
                }
                if(dadosBoleto.ValorMulta != 0 || dadosBoleto.PercentualMulta != 0)
                {
                    boleto.ValorMulta = dadosBoleto.ValorMulta.Value;
                    boleto.PercentualMulta = dadosBoleto.PercentualMulta.Value;
                    boleto.DataMulta = dadosBoleto.DataMulta.Value;
                    boleto.TipoCodigoMulta = dadosBoleto.TipoCodigoMulta.Value;
                }
                if(dadosBoleto.ValorDesconto != 0)
                {
                    boleto.DataDesconto = dadosBoleto.DataDesconto.Value;
                    boleto.ValorDesconto = dadosBoleto.ValorDesconto.Value;
                }
                boleto.CodigoBarra.CodigoBanco = iBanco.Codigo.ToString();
                boleto.CodigoBarra.ValorDocumento = vlrTitulo.ToString();
                boleto.ValidarDados();
                return boleto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Pagador GerarPagador(DadosBoleto dadosBoleto)
        {
            return new Pagador
            {
                Nome = dadosBoleto.PagadorResponse.Nome,
                CPFCNPJ = dadosBoleto.PagadorResponse.CPFCNPJ,
                Observacoes = dadosBoleto.PagadorResponse.Observacoes,
                Endereco = new Endereco
                {
                    LogradouroEndereco = dadosBoleto.PagadorResponse.EnderecoResponse.Logradouro,
                    LogradouroNumero = dadosBoleto.PagadorResponse.EnderecoResponse.Numero,
                    Bairro = dadosBoleto.PagadorResponse.EnderecoResponse.Bairro,
                    Cidade = dadosBoleto.PagadorResponse.EnderecoResponse.Cidade,
                    UF = dadosBoleto.PagadorResponse.EnderecoResponse.Estado,
                    CEP = dadosBoleto.PagadorResponse.EnderecoResponse.CEP,
                }
            };
        }
    }
}
