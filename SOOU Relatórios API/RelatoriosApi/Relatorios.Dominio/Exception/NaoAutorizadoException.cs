using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relatorios.Dominio.Exception
{
    public class NaoAutorizadoException : System.Exception 
    {

        public NaoAutorizadoException(string mensagem) : base(mensagem) { }

    }
}
