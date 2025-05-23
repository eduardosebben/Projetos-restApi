﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Relatorios.Dominio.Entities.Entities
{
    public partial class FT_NOTAS_ITENS_IMPORTACAO
    {
        public FT_NOTAS_ITENS_IMPORTACAO()
        {
            FT_NOTAS_ITENS_IMPORTACAO_ADICAO = new HashSet<FT_NOTAS_ITENS_IMPORTACAO_ADICAO>();
        }

        public int COD_NOTA_ITEM_IMPORTACAO { get; set; }
        public int COD_NOTA_ITEM { get; set; }
        public int COD_EMPRESA { get; set; }
        public int COD_ORGANIZACAO { get; set; }
        public string? NUM_DI { get; set; }
        public DateTime? DTA_DI { get; set; }
        public string? DES_LOCAL_DESEMBARACO { get; set; }
        public int? COD_UF_DESEMBARACO { get; set; }
        public DateTime? DTA_DESEMBARACO { get; set; }
        public int? COD_VIA_TRANSPORTE { get; set; }
        public decimal? VLR_AFRMM { get; set; }
        public int? COD_FORMA_IMPORTACAO { get; set; }
        public string? NUM_CNPJ_ADQUIRENTE { get; set; }
        public int? COD_UF_ADQUIRENTE { get; set; }
        public string? COD_EXPORTADOR { get; set; }
        public int? NUM_ADICAO { get; set; }
        public string? COD_FABRICANTE { get; set; }
        public string? NUM_DRAWBACK { get; set; }
        public decimal? VLR_PARCELA_IMPORTADA { get; set; }
        public decimal? VLR_OPERACOES_FINANCEIRAS { get; set; }
        public string? DES_ADICAO { get; set; }
        public decimal? VLR_DESCONTO { get; set; }

        public virtual GE_EMPRESAS COD_EMPRESANavigation { get; set; } = null!;
        public virtual SW_FORMA_IMPORTACAO? COD_FORMA_IMPORTACAONavigation { get; set; }
        public virtual FT_NOTAS_ITENS COD_NOTA_ITEMNavigation { get; set; } = null!;
        public virtual GE_ORGANIZACAO COD_ORGANIZACAONavigation { get; set; } = null!;
        public virtual SW_UF? COD_UF_ADQUIRENTENavigation { get; set; }
        public virtual SW_UF? COD_UF_DESEMBARACONavigation { get; set; }
        public virtual SW_VIA_TRANSPORTE? COD_VIA_TRANSPORTENavigation { get; set; }
        public virtual ICollection<FT_NOTAS_ITENS_IMPORTACAO_ADICAO> FT_NOTAS_ITENS_IMPORTACAO_ADICAO { get; set; }
    }
}