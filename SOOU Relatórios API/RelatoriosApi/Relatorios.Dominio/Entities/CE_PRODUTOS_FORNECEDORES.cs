﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Relatorios.Dominio.Entities.Entities
{
    public partial class CE_PRODUTOS_FORNECEDORES
    {
        public int COD_PRODUTO_FORNECEDOR { get; set; }
        public int COD_PRODUTO { get; set; }
        public int COD_EMPRESA { get; set; }
        public int COD_ORGANIZACAO { get; set; }
        public int COD_PESSOA { get; set; }
        public decimal? VLR_UNITARIO { get; set; }
        public decimal? VLR_CUSTO { get; set; }
        public string? COD_PRODUTO_NO_FORNECEDOR { get; set; }
        public decimal? VLR_CUSTO_REPOSICAO { get; set; }

        public virtual GE_EMPRESAS COD_EMPRESANavigation { get; set; } = null!;
        public virtual GE_ORGANIZACAO COD_ORGANIZACAONavigation { get; set; } = null!;
        public virtual PS_PESSOAS COD_PESSOANavigation { get; set; } = null!;
        public virtual CE_PRODUTOS COD_PRODUTONavigation { get; set; } = null!;
    }
}