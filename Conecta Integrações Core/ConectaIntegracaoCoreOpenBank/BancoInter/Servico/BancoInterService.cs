using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.WebUtilities;
using ConectaIntegracaoCoreOpenBank.BancoInter.Models;
using ConectaIntegracaoCoreOpenBank.BancoInter.Models.Response;
using ConectaIntegracaoCoreOpenBank.BancoInter.Models.ContaCorrente;
using System.IO;
using System.Linq;

namespace ConectaIntegracaoCoreOpenBank.BancoInter.Servico
{
    public static class BancoInterService
    {
        private const string URL_BASE_COBRANCA = "https://cdpj.partners.bancointer.com.br/cobranca/v2/";

        private const string URL_CONSULTAR_EXTRATO = "https://cdpj.partners.bancointer.com.br/banking/v2/extrato";
        private const string URL_EXTRATO_EM_PDF = "https://cdpj.partners.bancointer.com.br/banking/v2/extrato/exportar";
        private const string URL_CONSULTAR_SALDO = "https://cdpj.partners.bancointer.com.br/banking/v2/saldo";

        private const string URL_TOKEN = "https://cdpj.partners.bancointer.com.br/oauth/v2/token";

        private const string ESCOPO_CRIAR_BOLETO = "boleto-cobranca.write boleto-cobranca.read";
        private const string ESCOPO_CONSULTAR_EXTRATO = "extrato.read";
        private const string ESCOPO_CONSULTAR_SALDO = "extrato.read";

        private static HttpClientHandler ObterHttpClientHandler(ConfiguracaoEmpresa configuracao)
        {
            var httpClientHandler = new HttpClientHandler();
            var bytesCertificado = Convert.FromBase64String(configuracao.HashCertificado);
            var x509 = new X509Certificate2(bytesCertificado,
                configuracao.SenhaCertificado,
                //X509KeyStorageFlags.MachineKeySet |
                //X509KeyStorageFlags.PersistKeySet |
                X509KeyStorageFlags.Exportable);
            //Seta o certificado que irá junto com a requisição
            httpClientHandler.ClientCertificates.Add(x509);
            //Define que o certificado foi setado de forma manual e não será obtido do store
            httpClientHandler.ClientCertificateOptions = ClientCertificateOption.Manual;
            httpClientHandler.SslProtocols = SslProtocols.Tls12;

            return httpClientHandler;
        }

        private static DefaultTokenDTO ObterToken(string Escopo, ConfiguracaoEmpresa configuracao)
        {
            DefaultTokenDTO defaultToken = null;
            try
            {
                var conteudoKVP = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("client_id", configuracao.ClientId),
                    new KeyValuePair<string, string>("client_secret", configuracao.ClientSecret),
                    new KeyValuePair<string, string>("grant_type", "client_credentials"),
                    new KeyValuePair<string, string>("scope", Escopo),
                };

                var conteudo = new FormUrlEncodedContent(conteudoKVP);
                var handler = ObterHttpClientHandler(configuracao);

                using (var httpClient = new HttpClient(handler))
                {
                    try
                    {
                        var respostaRequisicao = httpClient.PostAsync(URL_TOKEN, conteudo).Result;
                        if (respostaRequisicao.IsSuccessStatusCode)
                        {
                            var responseString = respostaRequisicao.Content.ReadAsStringAsync().Result;
                            DefaultTokenDTO obj = JsonConvert.DeserializeObject<DefaultTokenDTO>(responseString);

                            defaultToken = new DefaultTokenDTO();
                            defaultToken.access_token = obj.access_token;
                            defaultToken.token_type = obj.token_type;
                            defaultToken.refresh_token = obj.refresh_token;
                            defaultToken.dataGeracao = DateTime.Now;

                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.GravarErroToken("Erro ao gerar token: " + ex.Message + "\n" + ex.InnerException.Message + ex.StackTrace);
                    }

                }
            }
            catch (Exception ex)
            {
                defaultToken = new DefaultTokenDTO();
                defaultToken.TemErro = true;
                defaultToken.Mensagem = ex.Message;
            }

            return defaultToken;
        }

        public static RegistroBoletoResponseDTO RegistrarBoleto(RegistroBoletoDTO emissaoBoletoDTO, ConfiguracaoEmpresa configuracao)
        {
            RegistroBoletoResponseDTO response = new RegistroBoletoResponseDTO();

            try
            {
                var objToken = new DefaultTokenDTO();
                if (string.IsNullOrEmpty(configuracao.desToken))
                {
                    objToken = ObterToken(ESCOPO_CRIAR_BOLETO, configuracao);

                    if (objToken.TemErro)
                    {
                        response.TemErro = true;
                        response.Mensagem = objToken.Mensagem;
                        return response;
                    }
                }
                else
                {
                    objToken.access_token = configuracao.desToken;
                }
                var handler = ObterHttpClientHandler(configuracao);
                //TODO: Mudar para IHttpClientFactory 
                var httpClient = new HttpClient(handler);

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objToken.access_token);

                var boletoSerializado = JsonConvert.SerializeObject(emissaoBoletoDTO);
                var conteudo = new StringContent(boletoSerializado, Encoding.UTF8, "application/json");
                var url = string.Concat(URL_BASE_COBRANCA, "boletos");
                var message =  httpClient.PostAsync(url, conteudo).Result;
                var resultadoStr = message.Content.ReadAsStringAsync().Result;
                if (resultadoStr.Contains("violacoes"))
                {
                    var erro = new ErrorDTO();
                    erro = JsonConvert.DeserializeObject<ErrorDTO>(resultadoStr);
                    var messagem = erro.violacoes.FirstOrDefault().razao;
                    throw new HttpRequestException(messagem.Trim());
                }
                if (resultadoStr.Contains("title"))
                {
                    throw new HttpRequestException(resultadoStr);
                }
                response = JsonConvert.DeserializeObject<RegistroBoletoResponseDTO>(resultadoStr);
                response.tokenDTO = objToken;

            }
            catch (Exception ex)
            {
                response.TemErro = true;
                response.Mensagem = ex.Message;
            }

            return response;
        }

        public static ConsultaBoletoDetalhadoResponseDTO ConsultarBoletoDetalhado(string nossoNumero, ConfiguracaoEmpresa configuracao)
        {
            ConsultaBoletoDetalhadoResponseDTO response = new ConsultaBoletoDetalhadoResponseDTO();

            try
            {
                var httpClientHandler = ObterHttpClientHandler(configuracao);
                //TODO: Mudar para IHttpClientFactory 
                var httpClient = new HttpClient(httpClientHandler);
                var objToken = new DefaultTokenDTO();
                if (string.IsNullOrEmpty(configuracao.desToken))
                {
                    objToken = ObterToken(ESCOPO_CRIAR_BOLETO, configuracao);
                }
                else
                {
                    objToken.access_token =  configuracao.desToken;
                }

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objToken.access_token);
                var url = URL_BASE_COBRANCA + "boletos/" + nossoNumero;
                var message = httpClient.GetAsync(url).Result;

                var resultadoStr = message.Content.ReadAsStringAsync().Result;
                Logger.GravarDadosRetornoDetalhesIntegracaoInter("Detalhes Boleto: " + resultadoStr);
                message.EnsureSuccessStatusCode();
                response = JsonConvert.DeserializeObject<ConsultaBoletoDetalhadoResponseDTO>(resultadoStr);
                Logger.GravarDadosRetornoDetalhesIntegracaoInter("Depois de jogar no  model de Detalhes: " + resultadoStr);

            }
            catch (Exception ex)
            {
                Logger.GravarErroIntegracaoDetalhes(ex.Message + "\n" + " " + ex.InnerException.Message + ex.StackTrace);
                response.TemErro = true;
                response.Mensagem = ex.Message;
            }

            return response;
        }

        public static ConsultaBoletoEmLoteResponseDTO ConsultarBoletoBancarioEmLote(string dataInicial, string dataFinal,ConfiguracaoEmpresa configuracao)
        {
            ConsultaBoletoEmLoteResponseDTO response = new ConsultaBoletoEmLoteResponseDTO();

            try
            {
                var httpClientHandler = ObterHttpClientHandler(configuracao);
                //TODO: Mudar para IHttpClientFactory 
                var httpClient = new HttpClient(httpClientHandler);
                var objToken = new DefaultTokenDTO();
                if (string.IsNullOrEmpty(configuracao.desToken))
                {
                    objToken = ObterToken(ESCOPO_CRIAR_BOLETO, configuracao);
                }
                else
                {
                    objToken.access_token = configuracao.desToken;
                }
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objToken.access_token);
                var url = URL_BASE_COBRANCA + "boletos";

                url = url + "?dataInicial=" + dataInicial + "&dataFinal=" + dataFinal + "&situacao=PAGO" + "&filtrarDataPor=SITUACAO";
                var message =  httpClient.GetAsync(url).Result;
                var resultadoStr =  message.Content.ReadAsStringAsync().Result;
                message.EnsureSuccessStatusCode();

                if (resultadoStr.Contains("title"))
                {
                    Logger.GravarDadosRetornoIntegracaoInter("Retorno da consulta do banco Inter com erro: " + resultadoStr);
                    throw new HttpRequestException(resultadoStr);
                }
                Logger.GravarDadosRetornoIntegracaoInter("Retorno da consulta do banco Inter: " + resultadoStr); 
                response = JsonConvert.DeserializeObject<ConsultaBoletoEmLoteResponseDTO>(resultadoStr);
                response.tokenDTO = objToken;

            }
            catch (Exception ex)
            {
                Logger.GravarDadosRetornoIntegracaoInter("Retorno da consulta de boletos Inter com erro: " + ex.Message + " " + ex.InnerException.Message + " " + ex.StackTrace);
                response.TemErro = true;
                response.Mensagem = ex.Message;
            }

            return response;
        }

        public static RespostaComMensagemDTO BaixarBoleto(string nossoNumero, string motivoBaixa,ConfiguracaoEmpresa configuracao)
        {
            RespostaComMensagemDTO response = new RespostaComMensagemDTO();

            try
            {
                var objToken = new DefaultTokenDTO();
                if (string.IsNullOrEmpty(configuracao.desToken))
                {
                    objToken = ObterToken(ESCOPO_CRIAR_BOLETO, configuracao);
                }
                else
                {
                    objToken.access_token = configuracao.desToken;
                }
                var httpClientHandler = ObterHttpClientHandler(configuracao);
                var httpClient = new HttpClient(httpClientHandler);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objToken.access_token);

                var parametros = new Dictionary<string, string>();
                parametros.Add("motivoCancelamento", motivoBaixa);
                StringContent content = new StringContent(JsonConvert.SerializeObject(parametros), Encoding.UTF8, "application/json");
                var url = string.Format(string.Concat(URL_BASE_COBRANCA, "boletos/{0}/cancelar"), nossoNumero);
                var message = httpClient.PostAsync(url, content).Result;

                message.EnsureSuccessStatusCode();

                var resultadoStr = message.Content.ReadAsStringAsync().Result;
                response.TemErro = false;
                response.tokenDTO = objToken;
                return response;

            }
            catch (Exception ex)
            {
                response.TemErro = true;
                response.Mensagem = ex.Message;
            }

            return response;
        }

        public static RespostaComPDFDTO ObterPDFBoleto(string nossoNumero, ConfiguracaoEmpresa configuracao)
        {
            RespostaComPDFDTO response = new RespostaComPDFDTO();

            try
            {
                var httpClientHandler = ObterHttpClientHandler(configuracao);
                //TODO: Mudar para IHttpClientFactory 
                var httpClient = new HttpClient(httpClientHandler);
                var objToken = new DefaultTokenDTO();
                if (string.IsNullOrEmpty(configuracao.desToken))
                {
                    objToken = ObterToken(ESCOPO_CRIAR_BOLETO, configuracao);
                }
                else
                {
                    objToken.access_token = configuracao.desToken;
                }
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objToken.access_token);
                var url = string.Concat(URL_BASE_COBRANCA, string.Format("boletos/{0}/pdf", nossoNumero));
                var message = httpClient.GetAsync(url).Result;
                var resultadoStr = message.Content.ReadAsStringAsync().Result;
                message.EnsureSuccessStatusCode();

                var resposta = JsonConvert.DeserializeObject<RespostaComPDFDTO>(resultadoStr);
                response.TemErro = false;
                response.pdf = resposta.pdf;
                response.hashPdf = Convert.FromBase64String(resposta.pdf);
                response.tokenDTO = objToken;
            }
            catch (Exception ex)
            {
                response.TemErro = true;
                response.Mensagem = ex.Message;
            }

            return response;
        }

        public static ExtratoResponseDTO ConsultarExtrato(string dataInicial, string dataFinal, ConfiguracaoEmpresa configuracao)
        {
            ExtratoResponseDTO response = new ExtratoResponseDTO();

            try
            {
                var httpClientHandler = ObterHttpClientHandler(configuracao);
                //TODO: Mudar para IHttpClientFactory 
                var httpClient = new HttpClient(httpClientHandler);
                var objToken = ObterToken(ESCOPO_CONSULTAR_EXTRATO, configuracao);

                if (objToken.TemErro)
                {
                    response.TemErro = true;
                    response.Mensagem = objToken.Mensagem;
                    return response;
                }

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objToken.access_token);
                var parametros = new Dictionary<string, string>
                {
                    { "dataInicio", dataInicial},
                    { "dataFim", dataFinal }
                };

                var url = URL_CONSULTAR_EXTRATO;
                url = QueryHelpers.AddQueryString(url, parametros);

                var message = httpClient.GetAsync(url).Result;
                var resultadoStr = message.Content.ReadAsStringAsync().Result;
                message.EnsureSuccessStatusCode();

                response = JsonConvert.DeserializeObject<ExtratoResponseDTO>(resultadoStr);

            }
            catch (Exception ex)
            {
                response.TemErro = true;
                response.Mensagem = ex.Message;
            }

            return response;
        }

        public static RespostaComPDFDTO ConsultarExtratoPDF(string dataInicial, string dataFinal, ConfiguracaoEmpresa configuracao)
        {
            RespostaComPDFDTO response = new RespostaComPDFDTO();

            try
            {
                var httpClientHandler = ObterHttpClientHandler(configuracao);
                //TODO: Mudar para IHttpClientFactory 
                var httpClient = new HttpClient(httpClientHandler);
                var objToken = ObterToken(ESCOPO_CONSULTAR_EXTRATO, configuracao);

                if (objToken.TemErro)
                {
                    response.TemErro = true;
                    response.Mensagem = objToken.Mensagem;
                    return response;
                }

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objToken.access_token);
                var parametros = new Dictionary<string, string>
                {
                    { "dataInicio", dataInicial},
                    { "dataFim", dataFinal }
                };

                var url = URL_EXTRATO_EM_PDF;
                url = QueryHelpers.AddQueryString(url, parametros);

                var message = httpClient.GetAsync(url).Result;
                var resultadoStr = message.Content.ReadAsStringAsync().Result;
                message.EnsureSuccessStatusCode();

                response = JsonConvert.DeserializeObject<RespostaComPDFDTO>(resultadoStr);
                response.TemErro = false;
                response.pdf = response.pdf;

            }
            catch (Exception ex)
            {
                response.TemErro = true;
                response.Mensagem = ex.Message;
            }

            return response;
        }

        public static SaldoResponseDTO ConsultarSaldo(ConfiguracaoEmpresa configuracao)
        {
            SaldoResponseDTO response = new SaldoResponseDTO();

            try
            {
                var httpClientHandler = ObterHttpClientHandler(configuracao);
                var httpClient = new HttpClient(httpClientHandler);
                var objToken = ObterToken(ESCOPO_CONSULTAR_SALDO, configuracao);

                if (objToken.TemErro)
                {
                    response.TemErro = true;
                    response.Mensagem = objToken.Mensagem;
                    return response;
                }

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", objToken.access_token);

                var message = httpClient.GetAsync(URL_CONSULTAR_SALDO).Result;
                var resultadoStr = message.Content.ReadAsStringAsync().Result;
                message.EnsureSuccessStatusCode();

                response = JsonConvert.DeserializeObject<SaldoResponseDTO>(resultadoStr);

            }
            catch (Exception ex)
            {
                response.TemErro = true;
                response.Mensagem = ex.Message;
            }

            return response;
        }
    }
}
