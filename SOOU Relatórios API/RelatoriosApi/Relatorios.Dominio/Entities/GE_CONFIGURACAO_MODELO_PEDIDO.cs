﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Relatorios.Dominio.Entities.Entities
{
    public partial class GE_CONFIGURACAO_MODELO_PEDIDO
    {
        public int COD_CONFIGURACAO { get; set; }
        public int COD_MODELO { get; set; }
        public int COD_EMPRESA { get; set; }
        public bool? TIP_NAO_IMPRIMIR_CODIGO_PRODUTO { get; set; }
        public bool? TIP_NAO_IMPRIMIR_DESCRICAO_PRODUTO { get; set; }
        public bool? TIP_NAO_IMPRIMIR_IMAGEM { get; set; }
        public bool? TIP_NAO_IMPRIMIR_NCM { get; set; }
        public bool? TIP_NAO_IMPRIMIR_CSOSN_CST { get; set; }
        public bool? TIP_NAO_IMPRIMIR_CFOP { get; set; }
        public bool? TIP_NAO_IMPRIMIR_UNIDADE_MEDIDA { get; set; }
        public bool? TIP_NAO_IMPRIMIR_QTD_PRODUTO { get; set; }
        public bool? TIP_NAO_IMPRIMIR_VALOR_UNITARIO { get; set; }
        public bool? TIP_NAO_IMPRIMIR_VALOR_TOTAL { get; set; }
        public bool? TIP_NAO_IMPRIMIR_BASE_ICMS { get; set; }
        public bool? TIP_NAO_IMPRIMIR_ICMS { get; set; }
        public bool? TIP_NAO_IMPRIMIR_IPI { get; set; }
        public bool? TIP_NAO_IMPRIMIR_ALIQ_IPI { get; set; }
        public bool? TIP_NAO_IMPRIMIR_ALIQ_ICMS { get; set; }
        public bool? TIP_NAO_IMPRIMIR_VALOR_PRODUTOS { get; set; }
        public bool TIP_NAO_IMPRIMIR_MARCA_PRODUTO { get; set; }
        public bool? TIP_NAO_IMPRIMIR_REFERENCIA_PRODUTO { get; set; }
        public bool? TIP_IMPRIMIR_SOMENTE_TOTAL { get; set; }
        public bool? TIP_NAO_IMPRIMIR_MENSAGENS { get; set; }
        public bool? TIP_NAO_IMPRIMIR_TRANSPORTADORA { get; set; }
        public bool? TIP_NAO_IMPRIMIR_TOTAIS { get; set; }
        public bool? TIP_NAO_IMPRIMIR_VALOR_DESCONTO { get; set; }
        public bool? TIP_NAO_IMPRIMIR_VALOR_UNIT_DESCONTO { get; set; }

        public virtual GE_EMPRESAS COD_EMPRESANavigation { get; set; } = null!;
        public virtual SW_MODELO_PEDIDO COD_MODELONavigation { get; set; } = null!;
    }
}