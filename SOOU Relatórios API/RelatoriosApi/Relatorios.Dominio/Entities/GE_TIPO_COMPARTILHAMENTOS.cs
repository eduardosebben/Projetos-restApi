﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Relatorios.Dominio.Entities.Entities
{
    public partial class GE_TIPO_COMPARTILHAMENTOS
    {
        public GE_TIPO_COMPARTILHAMENTOS()
        {
            GE_COMPARTILHAMENTOS = new HashSet<GE_COMPARTILHAMENTOS>();
            GE_GESTAO_COMPARTILHAMENTOS_PROCESSOS = new HashSet<GE_GESTAO_COMPARTILHAMENTOS_PROCESSOS>();
            GE_LOGS_COMPARTILHAMENTOS = new HashSet<GE_LOGS_COMPARTILHAMENTOS>();
        }

        public int COD_TIPO { get; set; }
        public string? DES_TIPO { get; set; }

        public virtual ICollection<GE_COMPARTILHAMENTOS> GE_COMPARTILHAMENTOS { get; set; }
        public virtual ICollection<GE_GESTAO_COMPARTILHAMENTOS_PROCESSOS> GE_GESTAO_COMPARTILHAMENTOS_PROCESSOS { get; set; }
        public virtual ICollection<GE_LOGS_COMPARTILHAMENTOS> GE_LOGS_COMPARTILHAMENTOS { get; set; }
    }
}