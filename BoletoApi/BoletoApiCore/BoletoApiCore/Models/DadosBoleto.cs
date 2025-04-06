using BoletoNetCore;
using BoletoNetCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoletoApiCore.Models
{
    public class DadosBoleto
    {
        public PagadorResponse PagadorResponse { get; set; } = new PagadorResponse();
        public BeneficiarioResponse BeneficiarioResponse { get; set; } = new BeneficiarioResponse();

        public DateTime DataEmissao { get; set; }

        public DateTime DataProcessamento { get; set; }

        public DateTime DataVencimento { get; set; }

        public decimal ValorTitulo { get; set; }
        public string NossoNumero { get; set; } = string.Empty;
        public string NumeroDocumento { get; set; } = string.Empty;
        public string CampoLivre { get; set; } = string.Empty;
        public decimal? ValorJurosDia { get; set; }
        public decimal? PercentualJurosDia { get; set; }
        public DateTime? DataJuros { get; set; }
        public TipoJuros? TipoJuros { get; set; } 
        // Multa
        public decimal? ValorMulta { get; set; }
        public decimal? PercentualMulta { get; set; }
        public DateTime? DataMulta { get; set; }
        public TipoCodigoMulta? TipoCodigoMulta { get; set; }
        // Desconto
        public DateTime? DataDesconto { get; set; }
        public decimal? ValorDesconto { get; set; }
        public string codNota { get; set; }
    }
}
