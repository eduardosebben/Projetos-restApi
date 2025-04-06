using Microsoft.IdentityModel.Tokens;
using Relatorios.Aplication.Common.Implementacoes;
using Relatorios.Dominio.Exception;
using Relatorios.Dominio.Repositories;
using SoouCommon.Jwt;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

namespace RelatoriosApi.Authentication
{
    public class CustomJwtSecurityTokenHandler : ISecurityTokenValidator
    {
        private int _maxTokenSizeInBytes = TokenValidationParameters.DefaultMaximumTokenSizeInBytes;
        private JwtSecurityTokenHandler _tokenHandler;
        private readonly ICriptografiaProvider _criptografiaProvider;
        private readonly IRepositorioAccount _repositorioAccount;
        public CustomJwtSecurityTokenHandler(ICriptografiaProvider criptografiaProvider, IRepositorioAccount repositorioAccount)
        {
            _tokenHandler = new JwtSecurityTokenHandler();
            _criptografiaProvider = criptografiaProvider;
            _repositorioAccount = repositorioAccount;
        }

        public bool CanValidateToken
        {
            get
            {
                return true;
            }
        }

        public int MaximumTokenSizeInBytes
        {
            get
            {
                return _maxTokenSizeInBytes;
            }

            set
            {
                _maxTokenSizeInBytes = value;
            }
        }

        public bool CanReadToken(string securityToken)
        {
            return _tokenHandler.CanReadToken(securityToken);
        }

        public ClaimsPrincipal ValidateToken(string securityToken, TokenValidationParameters validationParameters, out SecurityToken validatedToken)
        {
            var securityToken2 =  _tokenHandler.ReadToken(securityToken) as JwtSecurityToken;
            var appdata = securityToken2.Claims.FirstOrDefault(c => c.Type == "appdata")?.Value;
            if(!string.IsNullOrEmpty(appdata))
            {
                var appdataDescriptografado = _criptografiaProvider.DescriptografarUTF8(appdata);
                var tokenData = JsonSerializer.Deserialize<TokenPayloadData>(appdataDescriptografado);
                
                if (tokenData?.TipValidarRelacaoOrganizacao == true)
                {
                    var organizacaoAutorizada = _repositorioAccount.ValidarTokenDistribuidoOrganizacao(tokenData.OrgGuid, securityToken).Result;
                    if (!organizacaoAutorizada)
                        throw new NaoAutorizadoException("Token inválido");

                    validationParameters.RequireExpirationTime = !tokenData?.TipValidarRelacaoOrganizacao ?? true;
                }

            }


            var principal = _tokenHandler.ValidateToken(securityToken, validationParameters, out validatedToken);

            return principal;
        }
    }

}
