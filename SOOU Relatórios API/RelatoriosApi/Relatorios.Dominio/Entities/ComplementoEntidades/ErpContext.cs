﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Relatorios.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relatorios.Dominio.Entities.Entities
{
    public partial class ErpContext
    {
        public ErpContext(DbContextOptions options) : base(options)
        {
        }
    }
}
