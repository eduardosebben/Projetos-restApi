using EcommerceNetCore.Models;
using EcommerceNetCore.Models.MercadoLivre;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceNetCore.IntegracaoMercadoLivre
{
    public class MercadoLivreApi
    {
        private ConfiguracaoApiMercadoLivre configuracao;
        public MercadoLivreApi(ConfiguracaoApiMercadoLivre configuracaoApi)
        {
            configuracao = configuracaoApi;
        }
        private string GetPadraoOpenBank(string path, LogarDto logarDto)
        {

            try
            {
                var httpClient = new HttpClient();
                httpClient.Timeout = TimeSpan.FromSeconds(60);
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add("x-version", "2");
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {configuracao.Access_Token}");
                path = configuracao.BaseUrl + path;

                var result = httpClient.GetAsync(path.Trim()).Result.Content.ReadAsStringAsync().Result;

                if (string.IsNullOrWhiteSpace(result))
                    throw new HttpRequestException("A resposta está vazia.");

                if (result.Contains("errors") || result.Contains("error") || result.Contains("erros"))
                {

                    throw new HttpRequestException(result.Trim());
                }

                try
                {
                    return result;
                }
                catch
                {
                    throw new Exception(result);
                }
            }
            catch (Exception ex)
            {
                GravaLogOpenBank(ex.Message + " " + ex.InnerException?.Message, "", "");
                throw new Exception($@"Ocorreu um erro: ", ex);
            }
        }
        private string PostPadraoOpenBank(string path, LogarDto logarDto, string dados)
        {

            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add("x-version", "2");
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {configuracao.Access_Token}");
                path = configuracao.BaseUrl + path;

                var content = new StringContent(dados, Encoding.UTF8, "application/xml");

                var result = httpClient.PostAsync(path.Trim(),content).Result.Content.ReadAsStringAsync().Result;

                if (string.IsNullOrWhiteSpace(result))
                    throw new HttpRequestException("A resposta está vazia.");

                if (result.Contains("errors") || result.Contains("error") || result.Contains("erros"))
                {

                    throw new HttpRequestException(result.Trim());
                }

                try
                {
                    return result;
                }
                catch
                {
                    throw new Exception(result);
                }
            }
            catch (Exception ex)
            {
                GravaLogOpenBank(ex.Message + " " + ex.InnerException?.Message, "", "");
                throw new Exception($@"Ocorreu um erro: ", ex);
            }
        }
        public static void GravaLogOpenBank(string exMsg, string result, string path)
        {
            var texto = $"{exMsg}\nJSON: {result} \nChamada: {path}";
            var file = $"{DateTime.Now.ToString("ddMMyy'_'HHmm")}-ErroEcommerceMercadoLivre.txt";
            if (File.Exists(file))
                File.Delete(file);
            using (StreamWriter outputFile = new StreamWriter(file))
            {
                outputFile.WriteLine(texto);
            }
        }
        public string MetodoConsulta(string dadosBoletos, LogarDto logarDto)
        {
            return GetPadraoOpenBank(dadosBoletos, logarDto);
        }
        public string MetodoEnvia(string dadosBoletos, LogarDto logarDto, string dados)
        {
            return PostPadraoOpenBank(dadosBoletos, logarDto, dados);
        }
    }
}
