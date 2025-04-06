using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Relatorios.Aplication.Common.Implementacoes;
using Relatorios.Aplication.Common.Settings;
using Relatorios.Dominio.Entities.Entities;
using Relatorios.Dominio.Exception;
using Relatorios.Dominio.Repositories;
using SoouCommon.Jwt;
using System.Collections.Specialized;
using System.Text.Json;

namespace Relatorios.Infraestrutura.Repositories.Context
{
    public class ErpDatabaseConextInfraestrutura : ErpContext
    {
        private readonly IConfiguration _configuration;
        private readonly IRepositorioAccount _repositorioAccount;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICriptografiaProvider _criptografiaProvider;
        private readonly IOptions<AutenticacaoSettings> _settings;

        public ErpDatabaseConextInfraestrutura(
            DbContextOptions options,
            IConfiguration configuration,
            IRepositorioAccount repositorioAccount,
            IOptions<AutenticacaoSettings> settings,
            IHttpContextAccessor httpContextAccessor = null,
            ICriptografiaProvider criptografiaProvider = null) : base(options)
        {
            _configuration = configuration;
            _repositorioAccount = repositorioAccount;
            _httpContextAccessor = httpContextAccessor;
            _criptografiaProvider = criptografiaProvider;
            _settings = settings;
        }

        //Aqui pode ser implementado outra forma para buscar a string de conexao, pq por exemplo quando a chamada for pelo kafka pode usar uma forma de 
        //injecao de dependencia
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_settings.Value.UtilizaAutenticacaoAccount)
                ComAccount(optionsBuilder);
            else
                SemAccount(optionsBuilder);
        }

        private void SemAccount(DbContextOptionsBuilder optionsBuilder)
        {
            var count = 0;
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ErpStringConnection"), 
                x => x.CommandTimeout((int)TimeSpan.FromMinutes(2).TotalSeconds)
            ).LogTo(log =>
            {
                Console.WriteLine($"Contador querys: {count}");
                count++;
            },LogLevel.Information);
        }

        private async void ComAccount(DbContextOptionsBuilder optionsBuilder)
        {
            var appdata = _httpContextAccessor.HttpContext.User.FindFirst("appdata");
            if (!string.IsNullOrEmpty(appdata?.Value))
            {
                var appdataDescriptografado = _criptografiaProvider.DescriptografarUTF8(appdata.Value);
                var tokenData = JsonSerializer.Deserialize<TokenPayloadData>(appdataDescriptografado);

                if (tokenData != null)
                {
                    var stringConnection = _repositorioAccount.RetornarStringConnection(tokenData.OrgGuid, tokenData.OriginEnv).Result;
                    optionsBuilder.UseSqlServer(stringConnection);
                }
            }
        }
    }

}
