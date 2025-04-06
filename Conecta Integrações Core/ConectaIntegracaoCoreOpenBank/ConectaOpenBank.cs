using ConectaIntegracaoCoreOpenBank.BancoInter.Models.Response;
using ConectaIntegracaoCoreOpenBank.BancoInter.Models;
using ConectaIntegracaoCoreOpenBank.BancoInter.Servico;
using System;

namespace ConectaIntegracaoCoreOpenBank
{
    public class ConectaOpenBank
    {
        public RegistroBoletoResponseDTO EnviarBoletosInter(RegistroBoletoDTO registroBoleto, ConfiguracaoEmpresa configuracao)
        {
            var retorno = BancoInterService.RegistrarBoleto(registroBoleto, configuracao);
            return retorno;
        }
        public ConsultaBoletoDetalhadoResponseDTO ConsultarDetalhesBoletoInter(string nossoNumero, ConfiguracaoEmpresa configuracao)
        {
            var retorno = BancoInterService.ConsultarBoletoDetalhado(nossoNumero, configuracao);
            return retorno;
        }
        public ConsultaBoletoEmLoteResponseDTO ConsultaBoletosInter(string dataInicial, string dataFinal, ConfiguracaoEmpresa configuracao)
        {
            var retorno = BancoInterService.ConsultarBoletoBancarioEmLote(dataInicial, dataFinal, configuracao);
            return retorno;
        }
        public RespostaComMensagemDTO BaixarBoleto(string nossoNumero, string motivoBaixa, ConfiguracaoEmpresa configuracao)
        {
            var retorno = BancoInterService.BaixarBoleto(nossoNumero, motivoBaixa, configuracao);
            return retorno;
        }
        public RespostaComPDFDTO ImprimirBoletoInter(string nossoNumero, ConfiguracaoEmpresa configuracao)
        {
            var retorno = BancoInterService.ObterPDFBoleto(nossoNumero, configuracao);
            return retorno;
        }
    }
}
