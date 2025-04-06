using EcommerceNetCore.IntegracaoMercadoLivre;
using EcommerceNetCore.Models;
using EcommerceNetCore.Models.MercadoLivre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceNetCore
{
    public class ConectaEcommerce
    {
        public string Consulta(string dadosConsultas, LogarDto login)
        {
            var gerenciadorMercadoLivre = new GerenciadorMercadoLivre(login);
            var teste = gerenciadorMercadoLivre.Consultar(dadosConsultas);
            return teste;
        }
        public string Envia(string recurso, LogarDto login, string dados)
        {
            var gerenciadorMercadoLivre = new GerenciadorMercadoLivre(login);
            var ret = gerenciadorMercadoLivre.Enviar(recurso, dados);
            return ret;
        }
    }
}





