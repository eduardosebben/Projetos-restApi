using EcommerceApi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApi.Banco_de_Dados
{
    public static class SqlConn
    {
        private static SqlConnection _cn;

        public static SqlConnection Init(string stringConexao)
        {
            if (_cn == null || !IsConnected())
            {
                _cn = new SqlConnection(stringConexao);
                _cn.Open();

            }
            return _cn;
        }

        private static bool IsConnected()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select 1", _cn);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
