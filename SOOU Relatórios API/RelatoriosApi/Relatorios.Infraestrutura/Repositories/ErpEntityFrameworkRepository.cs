using Microsoft.EntityFrameworkCore;
using Relatorios.Aplication.Common.Repositories;
using Relatorios.Dominio.Entities.Entities;
using Relatorios.Infraestrutura.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relatorios.Infraestrutura.Repositories
{
    public class ErpEntityFrameworkRepository : IErpRepositorioGenerico
    {
        private ErpDatabaseConextInfraestrutura _context;

        public ErpEntityFrameworkRepository(ErpDatabaseConextInfraestrutura context)
        {
            _context = context;
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return _context.Set<T>().AsNoTracking();
        }

        public T? GetSingleById<T>(int id) where T : class
        {
            return _context.Find<T>(id);
        }
    }

}
