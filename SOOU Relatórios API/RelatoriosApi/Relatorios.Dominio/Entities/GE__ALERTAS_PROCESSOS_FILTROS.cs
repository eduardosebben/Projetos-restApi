﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Relatorios.Dominio.Entities.Entities
{
    public partial class GE__ALERTAS_PROCESSOS_FILTROS
    {
        public int COD_ALERTA_PROCESSOS_FILTROS { get; set; }
        public int COD_ALERTA_PROCESSOS { get; set; }
        public int? NUM_DIAS_VENCER { get; set; }
        public int? NUM_DIAS_VENCIDOS { get; set; }
        public int? NUM_DIAS_IGNORAR_VENCIDOS { get; set; }
        public string? DES_COMANDO_SQL { get; set; }

        public virtual GE_ALERTAS_PROCESSOS COD_ALERTA_PROCESSOSNavigation { get; set; } = null!;
    }
}