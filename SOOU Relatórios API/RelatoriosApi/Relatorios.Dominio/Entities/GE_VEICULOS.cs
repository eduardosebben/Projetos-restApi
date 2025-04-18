﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Relatorios.Dominio.Entities.Entities
{
    public partial class GE_VEICULOS
    {
        public GE_VEICULOS()
        {
            FT_MDFE = new HashSet<FT_MDFE>();
            FT_MDFE_REBOQUE = new HashSet<FT_MDFE_REBOQUE>();
        }

        public int COD_VEICULO { get; set; }
        public int COD_EMPRESA { get; set; }
        public int COD_ORGANIZACAO { get; set; }
        public string? NUM_PLACA { get; set; }
        public string? NUM_RENAVAM { get; set; }
        public int? NUM_TARA_KG { get; set; }
        public int? NUM_CAPACIDADE_KG { get; set; }
        public int? NUM_CAPACIDADE_M3 { get; set; }
        public string? DES_VEICULO { get; set; }
        public int? COD_PROPRIETARIO_VEICULO { get; set; }

        public virtual GE_EMPRESAS COD_EMPRESANavigation { get; set; } = null!;
        public virtual GE_ORGANIZACAO COD_ORGANIZACAONavigation { get; set; } = null!;
        public virtual GE_PROPRIETARIO_VEICULOS? COD_PROPRIETARIO_VEICULONavigation { get; set; }
        public virtual ICollection<FT_MDFE> FT_MDFE { get; set; }
        public virtual ICollection<FT_MDFE_REBOQUE> FT_MDFE_REBOQUE { get; set; }
    }
}