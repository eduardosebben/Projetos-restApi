﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Relatorios.Dominio.Entities.Entities
{
    public partial class FT_LIBERACAO_MARGEM_MINIMA
    {
        public int COD_LIBERACAO_MARGEM_MINIMA { get; set; }
        public int? COD_FT_NOTA_ITEM { get; set; }
        public int? COD_FT_PEDIDO_ITEM { get; set; }
        public DateTime DATA_LIBERACAO { get; set; }
        public int COD_USUARIO { get; set; }
        public decimal VLR_VENDA { get; set; }
        public decimal VLR_MINIMO { get; set; }
        public decimal VLR_CUSTO_REAL { get; set; }
        public decimal PER_MARGEM_MINIMA { get; set; }

        public virtual FT_NOTAS_ITENS? COD_FT_NOTA_ITEMNavigation { get; set; }
        public virtual FT_PEDIDOS_ITENS? COD_FT_PEDIDO_ITEMNavigation { get; set; }
        public virtual GE_USUARIOS COD_USUARIONavigation { get; set; } = null!;
    }
}