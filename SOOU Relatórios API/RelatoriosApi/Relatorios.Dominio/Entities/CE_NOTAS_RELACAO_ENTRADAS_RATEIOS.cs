﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Relatorios.Dominio.Entities.Entities
{
    public partial class CE_NOTAS_RELACAO_ENTRADAS_RATEIOS
    {
        public int COD_RELACAO { get; set; }
        public int COD_NOTA_ENTRADA { get; set; }
        public int COD_NOTA_ENTRADA_RELACAO { get; set; }
        public decimal VLR_RATEIO { get; set; }

        public virtual CE_NOTAS COD_NOTA_ENTRADANavigation { get; set; } = null!;
        public virtual CE_NOTAS COD_NOTA_ENTRADA_RELACAONavigation { get; set; } = null!;
    }
}