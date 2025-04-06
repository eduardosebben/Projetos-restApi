using EcommerceApi.Models;
using EcommerceNetCore.Models;
using EcommerceNetCore;
using Newtonsoft.Json;

namespace EcommerceApi.Extensions
{
    public class MetodosEnviar
    {
        //EnviarXmlNotaFiscal
        public string EnviarXmlNotaFiscal(DadosEnviarNotaFiscal dto)
        {
            // 1º Dados para a criação do token para realizar as consultas na API do Mercado Livre
            LogarDto logarDto = new LogarDto()
            {
                ClientId = dto.logar.ClientId,
                ClientSecret = dto.logar.ClientSecret,
                code = dto.logar.code,
                codeVerifier = dto.logar.codeVerifier,
                Username = dto.logar.Username,
                Password = dto.logar.Password,
                IndAmbiente = dto.logar.IndAmbiente,
                type = dto.logar.type,
                urlRetorno = dto.logar.urlRetorno
            };

            var dados = JsonConvert.SerializeObject(dto);

            var recurso = $"packs/{dto.ordemID}/fiscal_documents/siteId=MLB";
            var conectaEcommerce = new ConectaEcommerce();
            return conectaEcommerce.Envia(recurso, logarDto, dados);
        }
    }
}
