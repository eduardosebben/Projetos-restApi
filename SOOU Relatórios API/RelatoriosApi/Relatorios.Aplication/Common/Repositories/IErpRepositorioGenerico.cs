using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relatorios.Aplication.Common.Repositories
{
    public interface IErpRepositorioGenerico
    {
        IQueryable<T> Query<T>() where T : class;
        T? GetSingleById<T>(int id) where T : class;
    }

}
