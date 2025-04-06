using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BoletoApiCore.Models
{
    public class PagadorResponse
    {
        [Key]
        public int PagadorResponseId { get; set; }

        public string CPFCNPJ { get; set; } = string.Empty;

        public string Nome { get; set; } = string.Empty;

        public string Observacoes { get; set; } = string.Empty;

        public EnderecoResponse EnderecoResponse { get; set; } = new EnderecoResponse();
    }
}
