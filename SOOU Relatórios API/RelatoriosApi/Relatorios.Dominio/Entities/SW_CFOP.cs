﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Relatorios.Dominio.Entities.Entities
{
    public partial class SW_CFOP
    {
        public SW_CFOP()
        {
            GE_OPERACAO_FISCALCOD_CFOP_EXTERIORNavigation = new HashSet<GE_OPERACAO_FISCAL>();
            GE_OPERACAO_FISCALCOD_CFOP_FORA_ESTADONavigation = new HashSet<GE_OPERACAO_FISCAL>();
        }

        public int COD_CFOP { get; set; }
        public string? DES_CFOP { get; set; }

        public virtual ICollection<GE_OPERACAO_FISCAL> GE_OPERACAO_FISCALCOD_CFOP_EXTERIORNavigation { get; set; }
        public virtual ICollection<GE_OPERACAO_FISCAL> GE_OPERACAO_FISCALCOD_CFOP_FORA_ESTADONavigation { get; set; }
    }
}