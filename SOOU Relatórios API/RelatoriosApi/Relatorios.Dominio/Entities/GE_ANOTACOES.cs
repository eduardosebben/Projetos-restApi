﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Relatorios.Dominio.Entities.Entities
{
    public partial class GE_ANOTACOES
    {
        public GE_ANOTACOES()
        {
            GE_ANOTACOES_ANEXO = new HashSet<GE_ANOTACOES_ANEXO>();
            GE_ANOTACOES_USUARIO = new HashSet<GE_ANOTACOES_USUARIO>();
        }

        public int COD_ANOTACAO { get; set; }
        public int COD_ORGANIZACAO { get; set; }
        public int COD_EMPRESA { get; set; }
        public string DES_ANOTACAO { get; set; } = null!;
        public int COD_USUARIO { get; set; }
        public int COD_REGISTRO { get; set; }
        public DateTime DTA_CRIACAO { get; set; }
        public int COD_ENTIDADE { get; set; }
        public bool? TIP_ALERTAR { get; set; }
        public int? IND_RECORRENCIA { get; set; }
        public int? NUM_A_CADA { get; set; }
        public int? NUM_DIA { get; set; }
        public int? NUM_MES { get; set; }
        public string? HMS_HORAS { get; set; }
        public bool? TIP_SEGUNDA { get; set; }
        public bool? TIP_TERCA { get; set; }
        public bool? TIP_QUARTA { get; set; }
        public bool? TIP_QUINTA { get; set; }
        public bool? TIP_SEXTA { get; set; }
        public bool? TIP_SABADO { get; set; }
        public bool? TIP_DOMINGO { get; set; }
        public int? IND_OPCAO1 { get; set; }
        public int? IND_OPCAO2 { get; set; }
        public DateTime? DTA_ALERTA { get; set; }
        public DateTime? DTA_FIM_ALERTA { get; set; }

        public virtual GE_EMPRESAS COD_EMPRESANavigation { get; set; } = null!;
        public virtual SW_ENTIDADES COD_ENTIDADENavigation { get; set; } = null!;
        public virtual GE_ORGANIZACAO COD_ORGANIZACAONavigation { get; set; } = null!;
        public virtual GE_USUARIOS COD_USUARIONavigation { get; set; } = null!;
        public virtual ICollection<GE_ANOTACOES_ANEXO> GE_ANOTACOES_ANEXO { get; set; }
        public virtual ICollection<GE_ANOTACOES_USUARIO> GE_ANOTACOES_USUARIO { get; set; }
    }
}