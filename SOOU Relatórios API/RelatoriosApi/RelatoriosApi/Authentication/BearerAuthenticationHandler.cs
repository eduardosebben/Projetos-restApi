using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Security.Claims;
using System.Security.Principal;
using System.Text.Encodings.Web;

namespace RelatoriosApi.API.Authentication
{
    public class BearerAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public IOptions<AutenticacaoConfiguration> _settings { get; set; }

        public BearerAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IOptions<AutenticacaoConfiguration> settings) : base(options, logger, encoder, clock)
        {
            _settings = settings;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // No authorization header, so throw no result.
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return Task.FromResult(AuthenticateResult.Fail("Missing Authorization header"));
            }

            var authorizationHeader = Request.Headers["Authorization"].ToString();

            // If authorization header doesn't start with basic, throw no result.
            if (!authorizationHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                return Task.FromResult(AuthenticateResult.Fail("Authorization header does not start with 'Basic'"));
            }

            var token = authorizationHeader.Replace("Bearer ", "", StringComparison.OrdinalIgnoreCase);

            if (token != _settings.Value.BearerToken)
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalid token"));
            }

            var clientId = "ConectaApi";

            var client = new BearerAuthenticationClient
            {
                AuthenticationType = BearerAuthenticationDefaults.AuthenticationScheme,
                IsAuthenticated = true,
                Name = clientId
            };

            // Set the client ID as the name claim type.
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(client, new[]
            {
                new Claim(ClaimTypes.Name, clientId)
            }));

            // Return a success result.
            return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name)));

        }


    }


    public class BearerAuthenticationClient : IIdentity
    {
        public string? AuthenticationType { get; set; }

        public bool IsAuthenticated { get; set; }

        public string? Name { get; set; }
    }

    public class BearerAuthenticationDefaults
    {
        public const string AuthenticationScheme = "Bearer";
    }

    public class BearerAuthorizationAttribute : AuthorizeAttribute, IOperationFilter
    {
        public BearerAuthorizationAttribute()
        {
            AuthenticationSchemes = BearerAuthenticationDefaults.AuthenticationScheme;
        }


        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.MethodInfo.GetCustomAttributes(true).Any(x => x is BearerAuthorizationAttribute) ||
              context.MethodInfo.DeclaringType.GetCustomAttributes(true).Any(x => x is BearerAuthorizationAttribute))
            {
                operation.Security = new List<OpenApiSecurityRequirement> {
                new OpenApiSecurityRequirement {
                  {
                    new OpenApiSecurityScheme
                        {

                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme,
                            },
                        },
                        new List<string>()
                  }
                }
              };
            }

        }
    }


    public class AutenticacaoConfiguration
    {
        public const string Section = "AutenticacaoLocal";
        public string BearerToken { get; set; } = string.Empty;
    }
}
