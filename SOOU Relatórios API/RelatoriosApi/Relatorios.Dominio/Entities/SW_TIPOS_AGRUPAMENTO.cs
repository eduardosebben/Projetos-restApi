﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Relatorios.Dominio.Entities.Entities
{
    public partial class SW_TIPOS_AGRUPAMENTO
    {
        public SW_TIPOS_AGRUPAMENTO()
        {
            SW_PERMISSOES_FUNCAO = new HashSet<SW_PERMISSOES_FUNCAO>();
        }

        public int COD_TIPO_AGRUP { get; set; }
        public string? DES_NOME { get; set; }

        public virtual ICollection<SW_PERMISSOES_FUNCAO> SW_PERMISSOES_FUNCAO { get; set; }
    }
}