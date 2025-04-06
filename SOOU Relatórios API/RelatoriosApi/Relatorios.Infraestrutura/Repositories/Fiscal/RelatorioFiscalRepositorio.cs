using Microsoft.EntityFrameworkCore;
using Relatorios.Aplication.Common.Repositories;
using Relatorios.Dominio.Entities.Entities;
using Dapper;
using Relatorios.Aplication.Fiscal.Models;
using Microsoft.Data.SqlClient;
using Relatorios.Infraestrutura.Queries;
using Relatorios.Infraestrutura.Repositories.Context;

namespace Relatorios.Infraestrutura.Repositories.Fiscal
{
    public class RelatorioFiscalRepositorio : BaseDapperRepositorio, IRepositorioFiscal
    {

        public RelatorioFiscalRepositorio(ErpDatabaseConextInfraestrutura context)
        {
            _context = context;
        }

    }

}
