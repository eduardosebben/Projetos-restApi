using Microsoft.EntityFrameworkCore;
using Relatorios.Dominio.Entities.Entities;
using Relatorios.Infraestrutura.Repositories.Context;
using System.Text.Json.Serialization;

namespace Relatorios.Infraestrutura.Repositories
{
    public abstract class BaseDapperRepositorio
    {
        protected ErpContext _context;
        protected string _connetionString => _context.Database.GetDbConnection().ConnectionString;
    }

}
