using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceNetCore.Models.MercadoLivre
{
    public class ConfiguracaoApiMercadoLivre
    {
        public string BaseUrl { get; set; }
        public string Access_Token { get; set; }

        public ConfiguracaoApiMercadoLivre(string baseUrl, string AcessToken)
        {
            BaseUrl = baseUrl;
            Access_Token = AcessToken;
        }
        public class RetornoTokenMercadoLivre
        {
            public string access_token { get; set; }
            public string token_type { get; set; }
            public int expires_in { get; set; }
            public string scope { get; set; }
            public string user_id { get; set; }
            public string refresh_token { get; set; }
        }
    }
}
