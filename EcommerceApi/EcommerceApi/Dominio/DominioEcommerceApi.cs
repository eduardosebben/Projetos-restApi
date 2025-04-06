using EcommerceApi.Controllers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using EcommerceApi.Models;
using System.Security.Cryptography;
using System.Text;
using ConectaMD5Ext;

namespace EcommerceApi.Dominio
{
    public class DominioEcommerceApi
    {
        public static bool ConsultaUsuario(UserCredentials credentials, SqlConnection cn)
        {
            if(string.IsNullOrEmpty(credentials.email) || string.IsNullOrEmpty(credentials.Password))
            {
                return false;
            }
            else
            {
                try
                {
                    var comandoUsuarios = $"select * from SW_USUARIOS where DES_EMAIL = '{credentials.email}' ";
                    var envioBoletos = cn.Query<UsuarioViewModel>(comandoUsuarios).FirstOrDefault();

                    return ValidarHashSenhaUsuario(envioBoletos.DES_SENHA, credentials.Password, envioBoletos.COD_USUARIO);
                }
                catch(Exception ex)
                {
                    return false;
                }
                
            }
        }
        private static bool ValidarHashSenhaUsuario(string hashAtual, string desSenha, int codUsuario)
        {
            return hashAtual.Equals(GerarHashSenhaUsuario(desSenha, codUsuario));
        }
        private static string GerarHashSenhaUsuario(string senha, int codUsuario)
        {
            if (!string.IsNullOrWhiteSpace(senha))
            {
                using (SHA512 shaM = new SHA512Managed())

                {
                    var generatedHashBytes = Encoding.UTF8.GetBytes(senha + codUsuario);
                    var generatedHash = Encoding.UTF8.GetString(shaM.ComputeHash(generatedHashBytes));

                    var hashSenha = new MD5Ext().CriptografaUTF8(generatedHash);

                    return hashSenha;
                }
            }
            return null;
        }
    }
}
