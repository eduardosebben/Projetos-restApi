﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Relatorios.Dominio.Entities.Entities
{
    public partial class GE_CERTIFICADO_DIGITAL
    {
        public GE_CERTIFICADO_DIGITAL()
        {
            CR_CONVENIOS_BANCARIOS = new HashSet<CR_CONVENIOS_BANCARIOS>();
        }

        public int COD_CERTIFICADO { get; set; }
        public string? DES_CERTIFICADO { get; set; }
        public string DES_HASH_CERTIFICADO { get; set; } = null!;
        public string? DES_SENHA { get; set; }
        public bool? TIP_NFSE { get; set; }
        public bool? TIP_NFE { get; set; }
        public bool? TIP_NFCE { get; set; }
        public int COD_ORGANIZACAO { get; set; }
        public int COD_EMPRESA { get; set; }
        public bool? TIP_MDFE { get; set; }
        public int? COD_TIPO { get; set; }
        public string? DES_GUID { get; set; }

        public virtual GE_EMPRESAS COD_EMPRESANavigation { get; set; } = null!;
        public virtual GE_ORGANIZACAO COD_ORGANIZACAONavigation { get; set; } = null!;
        public virtual SW_TIPO_CERTIFICADO? COD_TIPONavigation { get; set; }
        public virtual ICollection<CR_CONVENIOS_BANCARIOS> CR_CONVENIOS_BANCARIOS { get; set; }
    }
}