﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Relatorios.Dominio.Entities.Entities
{
    public partial class GE_TIPO_TITULO
    {
        public GE_TIPO_TITULO()
        {
            CP_TITULOS = new HashSet<CP_TITULOS>();
            PS_PESSOAS = new HashSet<PS_PESSOAS>();
        }

        public int COD_TIPO_TITULO { get; set; }
        public string DES_TIPO_TITULO { get; set; } = null!;
        public int COD_ORGANIZACAO { get; set; }
        public int COD_EMPRESA { get; set; }

        public virtual GE_EMPRESAS COD_EMPRESANavigation { get; set; } = null!;
        public virtual GE_ORGANIZACAO COD_ORGANIZACAONavigation { get; set; } = null!;
        public virtual ICollection<CP_TITULOS> CP_TITULOS { get; set; }
        public virtual ICollection<PS_PESSOAS> PS_PESSOAS { get; set; }
    }
}