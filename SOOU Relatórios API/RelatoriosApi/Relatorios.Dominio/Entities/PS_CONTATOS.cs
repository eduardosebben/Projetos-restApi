﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Relatorios.Dominio.Entities.Entities
{
    public partial class PS_CONTATOS
    {
        public PS_CONTATOS()
        {
            PS_CONTATOS_PROCESSOS = new HashSet<PS_CONTATOS_PROCESSOS>();
            PS_CONTATOS_PROCESSOS_CONECTADO = new HashSet<PS_CONTATOS_PROCESSOS_CONECTADO>();
            PS_TELEFONES_CONTATOS = new HashSet<PS_TELEFONES_CONTATOS>();
        }

        public int COD_CONTATO { get; set; }
        public int COD_PESSOA { get; set; }
        public string DES_CONTATO { get; set; } = null!;
        public string? DES_EMAIL { get; set; }
        public int? COD_ORGANIZACAO { get; set; }
        public int? COD_CARGO { get; set; }

        public virtual GE_CARGOS? COD_CARGONavigation { get; set; }
        public virtual GE_ORGANIZACAO? COD_ORGANIZACAONavigation { get; set; }
        public virtual PS_PESSOAS COD_PESSOANavigation { get; set; } = null!;
        public virtual ICollection<PS_CONTATOS_PROCESSOS> PS_CONTATOS_PROCESSOS { get; set; }
        public virtual ICollection<PS_CONTATOS_PROCESSOS_CONECTADO> PS_CONTATOS_PROCESSOS_CONECTADO { get; set; }
        public virtual ICollection<PS_TELEFONES_CONTATOS> PS_TELEFONES_CONTATOS { get; set; }
    }
}