﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Relatorios.Dominio.Entities.Entities
{
    public partial class GE_CONFIGURACAO_ALMOXARIFADO_ISET
    {
        public int COD_CONFIGURACAO { get; set; }
        public int COD_EMPRESA { get; set; }
        public int COD_ALMOXARIFADO { get; set; }

        public virtual GE_ALMOXARIFADOS COD_ALMOXARIFADONavigation { get; set; } = null!;
        public virtual GE_EMPRESAS COD_EMPRESANavigation { get; set; } = null!;
    }
}