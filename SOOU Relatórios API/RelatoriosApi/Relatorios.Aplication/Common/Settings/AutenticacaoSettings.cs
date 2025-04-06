using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relatorios.Aplication.Common.Settings
{
    public class AutenticacaoSettings
    {
        public const string Section = "AutenticacaoSettings";
        public bool UtilizaAutenticacaoAccount { get; set; } = false;
    }
}
