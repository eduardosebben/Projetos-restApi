using System;
using System.Collections.Generic;
using System.Text;

namespace ConectaIntegracaoCoreOpenBank.BancoInter.Models
{
    public class ErrorDTO
    {
        public string title { get; set; }
        public string detail { get; set; }
        public DateTime timestamp { get; set; }
        public List<Violaco> violacoes { get; set; }
    }
    public class Violaco
    {
        public string razao { get; set; }
        public string propriedade { get; set; }
        public string valor { get; set; }
    }
}
