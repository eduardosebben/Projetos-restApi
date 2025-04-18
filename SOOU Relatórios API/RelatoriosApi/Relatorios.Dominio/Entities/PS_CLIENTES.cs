﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Relatorios.Dominio.Entities.Entities
{
    public partial class PS_CLIENTES
    {
        public int COD_PESSOA { get; set; }
        public int? COD_ORGANIZACAO { get; set; }
        public int? IND_RETER_IR { get; set; }
        public int? IND_RETER_PIS { get; set; }
        public bool? TIP_RETER_ISS { get; set; }
        public int? COD_CONTA_CONTABIL { get; set; }
        public bool? TIP_LOCAL_TRIBUTACAO_ISS { get; set; }
        public int? COD_CENTRO_RECEITA { get; set; }
        public int? COD_CANAL_VENDAS { get; set; }
        public int? COD_REPRESENTANTE { get; set; }
        public int? COD_TRANSPORTADORA { get; set; }
        public string? COD_MODALIDADE_FRETE { get; set; }
        public int? COD_CONDICAO_PAGAMENTO { get; set; }
        public int? COD_PESSOA_RELACIONADA { get; set; }
        public string? NUM_INSCRICAO_SUFRAMA { get; set; }
        public bool? TIP_NAO_POSSUI_ISENCAO_IMPOSTOS { get; set; }
        public decimal? VLR_LIMITE_CREDITO { get; set; }
        public bool? TIP_CONTROLA_APROVACAO_CLIENTE { get; set; }
        public bool? TIP_CONSUMIDOR_FINAL { get; set; }

        public virtual PS_CANAL_VENDAS? COD_CANAL_VENDASNavigation { get; set; }
        public virtual GE_CENTRO_CUSTOS? COD_CENTRO_RECEITANavigation { get; set; }
        public virtual GE_CONDICAO_PAGAMENTO? COD_CONDICAO_PAGAMENTONavigation { get; set; }
        public virtual GE_CONTAS_CONTABEIS? COD_CONTA_CONTABILNavigation { get; set; }
        public virtual SW_MODALIDADES_FRETE? COD_MODALIDADE_FRETENavigation { get; set; }
        public virtual GE_ORGANIZACAO? COD_ORGANIZACAONavigation { get; set; }
        public virtual PS_PESSOAS COD_PESSOANavigation { get; set; } = null!;
        public virtual PS_PESSOAS? COD_PESSOA_RELACIONADANavigation { get; set; }
        public virtual PS_PESSOAS? COD_REPRESENTANTENavigation { get; set; }
        public virtual PS_PESSOAS? COD_TRANSPORTADORANavigation { get; set; }
    }
}