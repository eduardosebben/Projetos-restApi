using BoletoNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoletoApiCore.Models
{
    public class BeneficiarioResponse
    {
        public int BeneficiarioResponseId { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Observacoes { get; set; } = string.Empty;

        public string CPFCNPJ { get; set; } = string.Empty;

        public ContaBancariaResponse ContaBancariaResponse { get; set; } = new ContaBancariaResponse();

        public Endereco Endereco { get; set; } = new Endereco();

        public bool MostrarCNPJnoBoleto { get; set; } = true;
        public string CodigoTransmissao { get; set; } = string.Empty;
    }
}
