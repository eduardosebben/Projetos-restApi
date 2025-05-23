﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Relatorios.Dominio.Entities.Entities
{
    public partial class CP_TITULOS
    {
        public CP_TITULOS()
        {
            CP_HISTORICO = new HashSet<CP_HISTORICO>();
            CP_TITULOS_LANCAMENTOS = new HashSet<CP_TITULOS_LANCAMENTOS>();
        }

        public int COD_TITULO { get; set; }
        public int COD_ORGANIZACAO { get; set; }
        public int COD_EMPRESA { get; set; }
        public int? COD_PESSOA { get; set; }
        public string NUM_TITULO { get; set; } = null!;
        public int? NUM_PARCELA { get; set; }
        public DateTime DTA_EMISSAO { get; set; }
        public DateTime DTA_VENCIMENTO { get; set; }
        public DateTime? DTA_PAGAMENTO { get; set; }
        public int? COD_BANCO { get; set; }
        public int? COD_TIPO_PAGAMENTO { get; set; }
        public decimal? VLR_TITULO { get; set; }
        public decimal? VLR_PAGO { get; set; }
        public decimal? VLR_DESCONTO { get; set; }
        public decimal? VLR_JUROS { get; set; }
        public decimal? VLR_MULTA { get; set; }
        public decimal? VLR_ACRESCIMO { get; set; }
        public decimal? VLR_ABATIMENTO { get; set; }
        public string? DES_OBSERVACAO { get; set; }
        public int? COD_TIPO_TITULO { get; set; }
        public int? IND_SITUACAO { get; set; }
        public decimal? VLR_SALDO { get; set; }
        public int? COD_CONTA_CONTABIL { get; set; }
        public int? COD_NOTA { get; set; }
        public int? COD_NOTA_SAIDA { get; set; }
        public int? COD_CENTRO_CUSTO { get; set; }
        public bool? TIP_ADIANTAMENTO { get; set; }
        public bool? TIP_ENCERRA_ADIANTAMENTO_ORDEM { get; set; }
        public bool? TIP_OBRIGA_ADIANTAMENTO_ORDEM { get; set; }
        public bool? TIP_LANCTO_DESPESA { get; set; }
        public bool? TIP_TRANSFERENCIA_CONTA { get; set; }

        public virtual GE_BANCOS? COD_BANCONavigation { get; set; }
        public virtual GE_CENTRO_CUSTOS? COD_CENTRO_CUSTONavigation { get; set; }
        public virtual GE_CONTAS_CONTABEIS? COD_CONTA_CONTABILNavigation { get; set; }
        public virtual GE_EMPRESAS COD_EMPRESANavigation { get; set; } = null!;
        public virtual CE_NOTAS? COD_NOTANavigation { get; set; }
        public virtual FT_NOTAS? COD_NOTA_SAIDANavigation { get; set; }
        public virtual GE_ORGANIZACAO COD_ORGANIZACAONavigation { get; set; } = null!;
        public virtual PS_PESSOAS? COD_PESSOANavigation { get; set; }
        public virtual GE_TIPO_PAGAMENTO? COD_TIPO_PAGAMENTONavigation { get; set; }
        public virtual GE_TIPO_TITULO? COD_TIPO_TITULONavigation { get; set; }
        public virtual ICollection<CP_HISTORICO> CP_HISTORICO { get; set; }
        public virtual ICollection<CP_TITULOS_LANCAMENTOS> CP_TITULOS_LANCAMENTOS { get; set; }
    }
}