﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Relatorios.Dominio.Entities.Entities
{
    public partial class CE_PRODUTOS_ISET
    {
        public int COD_PRODUTO_ISET { get; set; }
        public int COD_PRODUTO { get; set; }
        public int? COD_ISET { get; set; }
        public bool? TIP_NAO_ATUALIZA_ESTOQUE { get; set; }
        public bool? TIP_NAO_ATUALIZA_PRECO { get; set; }
        public bool? TIP_NAO_ATUALIZA_DESCRICAO { get; set; }
        public int COD_EMPRESA { get; set; }
        public DateTime? DTA_ULTIMA_ATUALIZACAO { get; set; }
        public string? DES_VARIACAO_ISET { get; set; }
        public int? COD_VARIACAO_ISET { get; set; }

        public virtual GE_EMPRESAS COD_EMPRESANavigation { get; set; } = null!;
        public virtual CE_PRODUTOS COD_PRODUTONavigation { get; set; } = null!;
    }
}