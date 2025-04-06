using Relatorios.Aplication.Common.Repositories;
using Relatorios.Aplication.EmpresasPadrao.Models;
using Relatorios.Dominio.Entities.Entities;
using Relatorios.Infraestrutura.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relatorios.Infraestrutura.Repositories.EmpresaPadrao
{
   

    public class RepositorioEmpresasPadraoEf : IRepositorioEmpresasPadrao
    {
        private readonly ErpDatabaseConextInfraestrutura _context;

        public RepositorioEmpresasPadraoEf(ErpDatabaseConextInfraestrutura context)
        {
            _context = context;
        }

        public async Task<EmpresasPadraoCollection> EmpresasPadraoCollection(int codEmpresa)
        {
            var empresaPadrao = await _context.FindAsync<GE_EMPRESAS_PADRAO>(codEmpresa);

            if (empresaPadrao == null)
                throw new Exception("Empresa padrão não encontrada!");

            return new EmpresasPadraoCollection(empresaPadrao);
        }

    }


    


    
}
