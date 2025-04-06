using Relatorios.Dominio.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relatorios.Aplication.DRE.Models
{
    public class Contas
    {
        public List<Conta> contas { get; set; } = new List<Conta>();
        public List<ContaPai> contaPais { get; set; } = new List<ContaPai>();

        public Contas() { }
    }
    public class Conta
    {
        public int? codConta { get; set; }
        public decimal valorTotal { get; set; } = 0;
        public string desConta { get; set; }
        public List<NotaTitulo> notaTitulos { get; set; }
        public Conta()
        {

        }
        public Conta(int? conta, decimal valor, string descricao)
        {
            codConta = conta;
            valorTotal = valor;
            desConta = descricao;
        }
        
    }

    public class ContaPai
    {
        public int? codConta { get; set; }
        public decimal valorTotal { get; set; } = 0;
        public string desConta { get; set; }
        public ContaPai()
        {

        }
        public ContaPai(int? conta, decimal valor, string descricao)
        {
            codConta = conta;
            valorTotal = valor;
            desConta = descricao;
        }

    }
    public class Conferencia
    {
        public int? codNota { get; set; }
        public string desNota { get; set; }
        public decimal valorTotal { get; set; } = 0;
        public Conferencia()
        {

        }
    }

    public class ProdutoCusto
    {
        public int? codProduto { get; set;}
        public decimal qtdEstoque { get; set; }
        public decimal vlrCusto { get; set; }
        public int? codAlmoxarifado { get; set; }   
        public string codSKU { get; set; }
    }

    public class RetornoDRE
    {
        public List<ContaDRE> contasDRE { get; set; } = new List<ContaDRE>();
        public List<Conferencia> conferenciasDRE { get; set; } = new List<Conferencia>();
        public int? codProduto { get; set;}
    }
    public class ContaDRE
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int nivelConta { get; set; }
        public decimal valorConta { get ; set; }
        public List<NotaTitulo> notasTitulos { get; set; } = new List<NotaTitulo>();
        public List<ContaDRE> Subcontas { get; set; }

        public ContaDRE(int codigo, string nome, decimal valor)
        {
            Codigo = codigo;
            Nome = nome;
            valorConta = valor;
            Subcontas = new List<ContaDRE>();
        }
    }
    public class ContasIndDRE
    {
        public List<ContaIndDRE> contaIndDREs { get; set; } = new List<ContaIndDRE>();
    }
    public class ContaIndDRE
    {
        public int codConta { get; set; }
        public string descricao { get; set; }
        public int indDRE { get; set; }
        public ContaIndDRE(){}
    }
    public class NotaTitulo
    {
        public string Descricao { get; set; }
        public NotaTitulo() { } 
    } 
}
