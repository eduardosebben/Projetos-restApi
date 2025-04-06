using RelatoriosApi.API.Authentication;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Relatorios.Dominio.Entities.Entities;
using Relatorios.Infraestrutura.Repositories;
using System.Text;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using System.Net.Mime;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddWebServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthentication();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHealthChecks("/health",
                new HealthCheckOptions()
                {
                    ResponseWriter = async (context, report) =>
                    {
                        var result = System.Text.Json.JsonSerializer.Serialize(
                            new
                            {
                                currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                statusApplication = report.Status.ToString(),
                            });

                        context.Response.ContentType = MediaTypeNames.Application.Json;
                        await context.Response.WriteAsync(result);
                    }
                });

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.MapControllers();

app.UseAuthorization();

app.Run();

