﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Relatorios.Dominio.Entities.Entities
{
    public partial class GE_EMPRESAS_UF
    {
        public int COD_EMPRESA_UF { get; set; }
        public int COD_EMPRESA { get; set; }
        public int COD_IBGE_UF { get; set; }
        public string? NUM_IE { get; set; }

        public virtual GE_EMPRESAS COD_EMPRESANavigation { get; set; } = null!;
        public virtual SW_UF COD_IBGE_UFNavigation { get; set; } = null!;
    }
}