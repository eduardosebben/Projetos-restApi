using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceNetCore.Models
{
    public class LogarDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public int IndAmbiente { get; set; }
        public string type { get; set; }
        public string code { get; set; }
        public string urlRetorno { get; set; }
        public string codeVerifier { get; set; }
    }
}
