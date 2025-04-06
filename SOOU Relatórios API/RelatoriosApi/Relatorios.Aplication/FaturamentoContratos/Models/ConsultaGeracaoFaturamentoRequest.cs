namespace Relatorios.Aplication.FaturamentoContratos.Models
{
    public class ConsultaGeracaoFaturamentoRequest
    {
        public int CodEmpresa { get; set; }
        public int? CodPessoa { get; set; }
        public DateTime DtaInicio { get; set; }
        public DateTime DtaFinal { get; set; }
        public int NumDiaFaturamento { get; set; }
        public bool ListarNaoFaturadosEmAtraso { get; set; }

        public bool IncluirNaoFaturados { get; set; }
        public bool IncluirFaturados { get; set; }

    }

}
