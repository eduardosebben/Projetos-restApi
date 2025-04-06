using EcommerceNetCore.Models;
using EcommerceNetCore.Models.MercadoLivre;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static EcommerceNetCore.Models.MercadoLivre.ConfiguracaoApiMercadoLivre;

namespace EcommerceNetCore.IntegracaoMercadoLivre
{
    public class GerenciadorMercadoLivre
    {
        private LogarDto _logarDto;

        public GerenciadorMercadoLivre(LogarDto logarDto)
        {
            _logarDto = logarDto;
        }
        public string Consultar(string dadosConsultas)
        {
            var configuracao = GeraTokenOpenBank();
            var openBankBBApi = new MercadoLivreApi(configuracao);
            return openBankBBApi.MetodoConsulta(dadosConsultas, _logarDto);
        }
        public string Enviar(string recurso, string dados)
        {
            var configuracao = GeraTokenOpenBank();
            var openBankBBApi = new MercadoLivreApi(configuracao);
            return openBankBBApi.MetodoEnvia(recurso, _logarDto, dados);
        }
        public ConfiguracaoApiMercadoLivre GeraTokenOpenBank()
        {
            try
            {
                var token = "";

                var dict = new Dictionary<string, string>();
                if (string.IsNullOrEmpty(_logarDto.code))
                {
                    dict.Add("grant_type", "authorization_code");
                    dict.Add("client_id", _logarDto.ClientId);
                    dict.Add("client_secret", _logarDto.ClientSecret);
                    dict.Add("code", _logarDto.code);
                    dict.Add("redirect_uri", _logarDto.urlRetorno);
                    dict.Add("code_verifier", _logarDto.codeVerifier);
                }
                else
                {
                    dict.Add("grant_type", "refresh_token");
                    dict.Add("client_id", _logarDto.ClientId);
                    dict.Add("client_secret", _logarDto.ClientSecret);
                    dict.Add("refresh_token", _logarDto.code);
                }

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("ContentType", "application/xwww-formurlencoded");
                    HttpResponseMessage response = client.PostAsync("https://api.mercadolibre.com/oauth/token", new FormUrlEncodedContent(dict)).Result;
                    token = response.Content.ReadAsStringAsync().Result;
                }
                if (string.IsNullOrWhiteSpace(token))
                    throw new HttpRequestException("A resposta está vazia.");
                try
                {
                    var retornoTokenOpenBank = JsonConvert.DeserializeObject<RetornoTokenMercadoLivre>(token);
                    var baseUrl = "";
                    baseUrl = "https://api.mercadolibre.com/";
                    var configuracao = new ConfiguracaoApiMercadoLivre(baseUrl, retornoTokenOpenBank.access_token);
                    return configuracao;
                }
                catch (Exception ex)
                {
                    throw new Exception(token.ToString());
                }
            }
            catch (Exception ex)
            {
                GravaLogOpenBank("", ex.Message + " " + ex.InnerException?.Message, "");
                throw new Exception($@"Ocorreu um erro na desserialização da resposta. Veja a exceção interna para mais detalhes. " + ex.Message + " " + ex.InnerException?.Message);
            }
        }
        public static void GravaLogOpenBank(string exMsg, string result, string path)
        {
            var texto = $"{exMsg}\nJSON: {result} \nChamada: {path}";
            var file = $"Logs/{DateTime.Now.ToString("ddMMyy'_'HHmm")}-ErroOpenBank.txt";
            if (File.Exists(file))
                File.Delete(file);
            using (StreamWriter outputFile = new StreamWriter(file))
            {
                outputFile.WriteLine(texto);
            }
        }
    }
}
