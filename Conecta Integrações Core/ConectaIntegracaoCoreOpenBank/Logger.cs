using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConectaIntegracaoCoreOpenBank
{
    public static class Logger
    {
        public static void GravarErroToken(string erro)
        {
            var file = "LogErroTokenInterCore.txt";
            if (File.Exists(file))
                File.Delete(file);
            using (StreamWriter outputFile = new StreamWriter(file))
            {
                outputFile.WriteLine(erro);
            }

        }
        public static void GravarErroIntegracaoDetalhes(string erro)
        {
            var file = "LogErroDetalhesBoletoInterCore.txt";
            if (File.Exists(file))
                File.Delete(file);
            using (StreamWriter outputFile = new StreamWriter(file))
            {
                outputFile.WriteLine(erro);
            }

        }
        public static void GravarDadosIntegracaoInter(string erro)
        {
            var file = "LogIntegracaoInterCore.txt";
            if (File.Exists(file))
                File.Delete(file);
            using (StreamWriter outputFile = new StreamWriter(file))
            {
                outputFile.WriteLine(erro);
            }

        }
        public static void GravarDadosRetornoIntegracaoInter(string erro)
        {
            var file = "LogRetornoIntegracaoInterCore.txt";
            if (File.Exists(file))
                File.Delete(file);
            using (StreamWriter outputFile = new StreamWriter(file))
            {
                outputFile.WriteLine(erro);
            }

        }

        public static void GravarDadosRetornoDetalhesIntegracaoInter(string erro)
        {
            var file = "LogRetornoDetalhesBoletoIntegracaoInterCore.txt";
            if (File.Exists(file))
                File.Delete(file);
            using (StreamWriter outputFile = new StreamWriter(file))
            {
                outputFile.WriteLine(erro);
            }

        }
    }
}
