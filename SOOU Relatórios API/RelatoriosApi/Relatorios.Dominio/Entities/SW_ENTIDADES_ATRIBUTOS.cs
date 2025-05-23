﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Relatorios.Dominio.Entities.Entities
{
    public partial class SW_ENTIDADES_ATRIBUTOS
    {
        public SW_ENTIDADES_ATRIBUTOS()
        {
            GE_CONSULTAS_CONFIGURADAS_CAMPOS = new HashSet<GE_CONSULTAS_CONFIGURADAS_CAMPOS>();
            SW_ENTIDADES = new HashSet<SW_ENTIDADES>();
            SW_ENTIDADES_ATRIBUTOS_CHAVE_UNICA = new HashSet<SW_ENTIDADES_ATRIBUTOS_CHAVE_UNICA>();
        }

        public int COD_ATRIBUTO { get; set; }
        public string? DES_ATRIBUTO_ORIGEM { get; set; }
        public string? DES_FANTASIA { get; set; }
        public string? DES_OBS { get; set; }
        public string? DES_HELP { get; set; }
        public int? COD_ENTIDADE { get; set; }
        public int? COD_ENTIDADE_RELACIONADA { get; set; }
        public string? DES_TIPO_CAMPO { get; set; }
        public string? NUM_TAMANHO_ATRIBUTO { get; set; }
        public int? NUM_ORDEM { get; set; }
        public bool TIP_NOT_NULL { get; set; }
        public bool? TIP_BLOQUEAR_CONSULTA { get; set; }
        public string? DES_INDICADORES { get; set; }
        public bool TIP_ENTIDADE_FILHA { get; set; }

        public virtual SW_ENTIDADES? COD_ENTIDADENavigation { get; set; }
        public virtual SW_ENTIDADES? COD_ENTIDADE_RELACIONADANavigation { get; set; }
        public virtual ICollection<GE_CONSULTAS_CONFIGURADAS_CAMPOS> GE_CONSULTAS_CONFIGURADAS_CAMPOS { get; set; }
        public virtual ICollection<SW_ENTIDADES> SW_ENTIDADES { get; set; }
        public virtual ICollection<SW_ENTIDADES_ATRIBUTOS_CHAVE_UNICA> SW_ENTIDADES_ATRIBUTOS_CHAVE_UNICA { get; set; }
    }
}