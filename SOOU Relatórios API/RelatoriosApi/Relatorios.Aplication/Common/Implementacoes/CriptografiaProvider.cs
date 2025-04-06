using ConectaMD5Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relatorios.Aplication.Common.Implementacoes
{
    public interface ICriptografiaProvider
    {
        string Criptografar(string valor);
        string CriptografarASCII(string valor);
        string CriptografarUTF8(string valor);
        string Descriptografar(string valor);
        string DescriptografarASCII(string valor);
        string DescriptografarUTF8(string valor);
    }

    public class CriptografiaProvider : ICriptografiaProvider
    {
        public string Descriptografar(string valor)
        {
            return new MD5Ext().Descriptografa(valor);
        }

        public string DescriptografarASCII(string valor)
        {
            return new MD5Ext().DescriptografaASCII(valor);
        }

        public string DescriptografarUTF8(string valor)
        {
            return new MD5Ext().DescriptografaUTF8(valor);
        }

        public string Criptografar(string valor)
        {
            return new MD5Ext().Criptografa(valor);
        }

        public string CriptografarASCII(string valor)
        {
            return new MD5Ext().CriptografaASCII(valor);
        }

        public string CriptografarUTF8(string valor)
        {
            return new MD5Ext().CriptografaUTF8(valor);
        }
    }

}
