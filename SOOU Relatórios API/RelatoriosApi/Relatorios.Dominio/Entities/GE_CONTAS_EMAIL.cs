﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Relatorios.Dominio.Entities.Entities
{
    public partial class GE_CONTAS_EMAIL
    {
        public GE_CONTAS_EMAIL()
        {
            GE_CONTA_EMAIL_PROCESSOS = new HashSet<GE_CONTA_EMAIL_PROCESSOS>();
            GE_EMAILS_ENVIADOS = new HashSet<GE_EMAILS_ENVIADOS>();
        }

        public int COD_CONTA { get; set; }
        public string? DES_NOME { get; set; }
        public string? DES_FANTASIA { get; set; }
        public string? DES_NOME_EXIBICAO { get; set; }
        public string? DES_EMAIL { get; set; }
        public string? DES_SERVIDOR { get; set; }
        public string? DES_USUARIO { get; set; }
        public string? DES_SENHA { get; set; }
        public int? NUM_PORTA { get; set; }
        public bool? TIP_SSL { get; set; }
        public int COD_ORGANIZACAO { get; set; }
        public string? DES_EMAIL_CONFIRMACAO { get; set; }
        public int? COD_EMPRESA { get; set; }
        public bool? TIP_DEFAULT { get; set; }
        public bool? TIP_EMAIL_CONECTA_API { get; set; }
        public string? DES_GUID_REGISTRO_APLICACAO { get; set; }
        public bool? TIP_VINCULO_APLICATIVO { get; set; }

        public virtual GE_EMPRESAS? COD_EMPRESANavigation { get; set; }
        public virtual GE_ORGANIZACAO COD_ORGANIZACAONavigation { get; set; } = null!;
        public virtual ICollection<GE_CONTA_EMAIL_PROCESSOS> GE_CONTA_EMAIL_PROCESSOS { get; set; }
        public virtual ICollection<GE_EMAILS_ENVIADOS> GE_EMAILS_ENVIADOS { get; set; }
    }
}