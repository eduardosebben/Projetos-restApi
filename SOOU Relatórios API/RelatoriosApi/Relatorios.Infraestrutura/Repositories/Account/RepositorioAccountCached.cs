using Relatorios.Dominio.Repositories;
using Microsoft.Extensions.Caching.Memory;
using SoouCommon.Enum;

namespace Relatorios.Infraestrutura.Repositories.Account
{
    /// <summary>
    /// Proxy usado para guardar durante um pequeno espaco de tempo a string de conexao por guid da organizacao antes de buscar de fato no banco do account
    /// </summary>
    public class RepositorioAccountCached : IRepositorioAccount
    {
        private readonly RepositorioAccount _account;
        private readonly IMemoryCache _cache;
        private MemoryCacheEntryOptions cacheOptions;
        private TimeSpan _tempoValidadeCache = TimeSpan.FromMinutes(1);

        public RepositorioAccountCached(RepositorioAccount account, IMemoryCache cache)
        {
            _account = account;
            _cache = cache;
            cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(_tempoValidadeCache);
        }

        public async Task<string?> RetornarStringConnection(string guidOrganizacao, TipoAmbiente tipoAmbiente)
        {
            var chave = $"Account:{guidOrganizacao}-{tipoAmbiente}";

            return await _cache.GetOrCreateAsync(chave, async entry =>
            {
                entry.SetOptions(cacheOptions);
                return await _account.RetornarStringConnection(guidOrganizacao, tipoAmbiente);
            });

        }

        public Task<bool> ValidarTokenDistribuidoOrganizacao(string guidOrg, string token) => _account.ValidarTokenDistribuidoOrganizacao(guidOrg, token);
    }

}
