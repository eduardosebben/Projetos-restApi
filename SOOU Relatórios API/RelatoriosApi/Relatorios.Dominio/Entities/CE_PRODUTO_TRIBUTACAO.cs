﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Relatorios.Dominio.Entities.Entities
{
    public partial class CE_PRODUTO_TRIBUTACAO
    {
        public int COD_PRODUTO_TRIBUTACAO { get; set; }
        public int COD_PRODUTO { get; set; }
        public int? COD_OPERACAO_FISCAL { get; set; }
        public int COD_EMPRESA { get; set; }

        public virtual GE_EMPRESAS COD_EMPRESANavigation { get; set; } = null!;
        public virtual GE_OPERACAO_FISCAL? COD_OPERACAO_FISCALNavigation { get; set; }
        public virtual CE_PRODUTOS COD_PRODUTONavigation { get; set; } = null!;
    }
}