﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Relatorios.Dominio.Entities.Entities
{
    public partial class SW_TIPOS_FUNCAO
    {
        public SW_TIPOS_FUNCAO()
        {
            SW_FUNCOES = new HashSet<SW_FUNCOES>();
        }

        public int COD_TIPO_FUNCAO { get; set; }
        public string? DES_NOME { get; set; }
        public string? DES_OBS { get; set; }

        public virtual ICollection<SW_FUNCOES> SW_FUNCOES { get; set; }
    }
}