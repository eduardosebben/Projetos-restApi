using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soou_Erp_DashBoard.Infraestruct
{
    public class ServicoUsuario
    {
        private readonly HttpClient _httpClient;

        public ServicoUsuario(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task EnviarDadosAsync()
        {
            try
            {
                // Construa o objeto que você deseja enviar como JSON
                var objetoParaEnviar = new SeuObjeto
                {
                    // preencha com os dados necessários
                };

                // Serializa o objeto para JSON
                var json = JsonConvert.SerializeObject(objetoParaEnviar);

                // Construa o conteúdo da solicitação
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Faça a solicitação POST para a URL da sua API .NET Core
                HttpResponseMessage response = await _httpClient.PostAsync("https://suaapi.com/api/seuendpoint", content);

                // Verifique se a solicitação foi bem-sucedida
                if (response.IsSuccessStatusCode)
                {
                    // Lida com a resposta, se necessário
                    var respostaJson = await response.Content.ReadAsStringAsync();
                    // Faça algo com a resposta, se necessário
                }
                else
                {
                    // Lidar com o caso de falha na solicitação
                    Console.WriteLine("A solicitação falhou com o código: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
        }
    }
    public class SeuObjeto
    {
        // Defina as propriedades necessárias
    }
}
