namespace Relatorios.Aplication.EvolucaoCompras.Models
{
    public class EvolucaoCompraRequest
    {
        public int CodEmpresa { get; set; }
        public int? Meses { get; set; }
        public List<int> Fornecedores { get; set; } = new();
        public List<int> Marcas { get; set; } = new();
        public List<int> Categorias { get; set; } = new();
        public List<int> Classificacoes { get; set; } = new();
        public List<int> Produtos { get; set; } = new();
    }

}
