﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Relatorios.Dominio.Entities.Entities
{
    public partial class GE_AREA
    {
        public GE_AREA()
        {
            CO_REGRAS_APROVADORES_USUARIOS = new HashSet<CO_REGRAS_APROVADORES_USUARIOS>();
            GE_COMPONENTES_PERMISSOES = new HashSet<GE_COMPONENTES_PERMISSOES>();
            GE_GESTAO_COMPARTILHAMENTOS_PROCESSOS_PERMISSOES = new HashSet<GE_GESTAO_COMPARTILHAMENTOS_PROCESSOS_PERMISSOES>();
            GE_USUARIOS = new HashSet<GE_USUARIOS>();
        }

        public int COD_AREA { get; set; }
        public string? DES_AREA { get; set; }
        public int? COD_ORGANIZACAO { get; set; }

        public virtual GE_ORGANIZACAO? COD_ORGANIZACAONavigation { get; set; }
        public virtual ICollection<CO_REGRAS_APROVADORES_USUARIOS> CO_REGRAS_APROVADORES_USUARIOS { get; set; }
        public virtual ICollection<GE_COMPONENTES_PERMISSOES> GE_COMPONENTES_PERMISSOES { get; set; }
        public virtual ICollection<GE_GESTAO_COMPARTILHAMENTOS_PROCESSOS_PERMISSOES> GE_GESTAO_COMPARTILHAMENTOS_PROCESSOS_PERMISSOES { get; set; }
        public virtual ICollection<GE_USUARIOS> GE_USUARIOS { get; set; }
    }
}