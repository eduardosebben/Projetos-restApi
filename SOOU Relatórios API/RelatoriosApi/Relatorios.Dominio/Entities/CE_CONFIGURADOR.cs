﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Relatorios.Dominio.Entities.Entities
{
    public partial class CE_CONFIGURADOR
    {
        public CE_CONFIGURADOR()
        {
            CE_CONFIGURADOR_VERSOES = new HashSet<CE_CONFIGURADOR_VERSOES>();
            CE_PRODUTOS = new HashSet<CE_PRODUTOS>();
        }

        public int COD_CONFIGURADOR { get; set; }
        public string? DES_CONFIGURADOR { get; set; }
        public DateTime? DTA_DESATICACAO { get; set; }

        public virtual ICollection<CE_CONFIGURADOR_VERSOES> CE_CONFIGURADOR_VERSOES { get; set; }
        public virtual ICollection<CE_PRODUTOS> CE_PRODUTOS { get; set; }
    }
}