﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Relatorios.Dominio.Entities.Entities
{
    public partial class GE_CARGOS
    {
        public GE_CARGOS()
        {
            PS_CONTATOS = new HashSet<PS_CONTATOS>();
        }

        public int COD_CARGO { get; set; }
        public string? DES_CARGO { get; set; }
        public int COD_EMPRESA { get; set; }
        public int COD_ORGANIZACAO { get; set; }

        public virtual GE_EMPRESAS COD_EMPRESANavigation { get; set; } = null!;
        public virtual GE_ORGANIZACAO COD_ORGANIZACAONavigation { get; set; } = null!;
        public virtual ICollection<PS_CONTATOS> PS_CONTATOS { get; set; }
    }
}