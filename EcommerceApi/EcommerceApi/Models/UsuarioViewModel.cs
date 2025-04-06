using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApi.Models
{
    public class UsuarioViewModel
    {
        public int COD_USUARIO { get; set; }
        public string DES_NOME { get; set; }
        public string DES_EMAIL { get; set; }
        public string DES_SENHA { get; set; }
        public string DES_GUID { get; set; }
        public DateTime? DTA_CRIACAO { get; set; }
        
    }
}

