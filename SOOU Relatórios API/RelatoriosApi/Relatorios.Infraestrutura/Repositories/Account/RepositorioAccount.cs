using Dapper;
using Microsoft.Data.SqlClient;
using Relatorios.Infraestrutura.Queries;
using Microsoft.Extensions.Configuration;
using Relatorios.Aplication.Common.Implementacoes;
using Relatorios.Dominio.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using SoouCommon.Enum;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Relatorios.Infraestrutura.Repositories.Account
{

    public class RepositorioAccount : IRepositorioAccount
    {
        private readonly IConfiguration _configuration;
        private readonly ICriptografiaProvider _criptografiaProvider;

        public RepositorioAccount(IConfiguration configuration, ICriptografiaProvider criptografiaProvider)
        {
            _configuration = configuration;
            _criptografiaProvider = criptografiaProvider;
        }


        public async Task<string?> RetornarStringConnection(string guidOrganizacao, TipoAmbiente tipoAmbiente)
        {
            var connectionString = GetConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var comando = AccountQueries.GetStringConnection;
                var result = await connection.QuerySingleAsync<dynamic>(comando,
                    new { desGuid = guidOrganizacao, codAplicacao = (int)TipoAplicacao.Maboo, codAmbiente = (int)tipoAmbiente });

                if (result != null)
                {
                    var server = _criptografiaProvider.Descriptografar(result.servidor ?? "");
                    var user = _criptografiaProvider.Descriptografar(result.usuario ?? "");
                    var password = _criptografiaProvider.Descriptografar(result.senha ?? "");
                    var database = _criptografiaProvider.Descriptografar(result.banco ?? "");
                    return $"Server={server};User ID={user};Password={password};Database={database};TrustServerCertificate=True;";
                }

                throw new Exception("Erro: string connection account não encontrada");
            }
        }

        private string GetConnectionString => _configuration.GetConnectionString("AccountStringConnetion")!;


        public async Task<bool> ValidarTokenDistribuidoOrganizacao(string guidOrg, string token)
        {
            var connectionString = GetConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                var comando = AccountQueries.ValidarTokenDistribuidoOrganizacao;
                var result = await connection.QueryFirstOrDefaultAsync<string>(comando,
                    new { guidOrg, token });

                if (string.IsNullOrEmpty(result))
                    return false;

                return true;
            }
        }
    }

}
