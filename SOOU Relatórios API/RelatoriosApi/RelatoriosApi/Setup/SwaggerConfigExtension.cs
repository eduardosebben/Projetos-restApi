using RelatoriosApi.API.Authentication;
using Microsoft.OpenApi.Models;

namespace RelatoriosApi.Setup
{
    public static class SwaggerConfigExtension
    {

        public static void SwaggerSecurityConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(config =>
            {
                config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    In = ParameterLocation.Header,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                config.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
             });



            //services.AddSwaggerGen(options =>
            //{
            //    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            //    {
            //        Scheme = "Bearer",
            //        BearerFormat = "JWT",
            //        In = ParameterLocation.Header,
            //        Name = "Authorization",
            //        Description = "Bearer Authentication with JWT Token",
            //        Type = SecuritySchemeType.Http,

            //    });
            //    options.OperationFilter<BearerAuthorizationAttribute>(); //somente controller ou metodos com esse atributo
            //});
        }

    }
}
