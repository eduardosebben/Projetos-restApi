﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Relatorios.Dominio.Entities.Entities
{
    public partial class SW_PAISES
    {
        public SW_PAISES()
        {
            PS_ENDERECOS = new HashSet<PS_ENDERECOS>();
        }

        public int COD_PAIS { get; set; }
        public string? DES_PAIS { get; set; }
        public string? COD_IBGE_PAIS { get; set; }

        public virtual ICollection<PS_ENDERECOS> PS_ENDERECOS { get; set; }
    }
}