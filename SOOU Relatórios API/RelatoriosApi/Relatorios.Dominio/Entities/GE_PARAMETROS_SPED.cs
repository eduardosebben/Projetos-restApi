﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Relatorios.Dominio.Entities.Entities
{
    public partial class GE_PARAMETROS_SPED
    {
        public int COD_EMPRESA { get; set; }
        public int COD_FORNECEDOR_CONTABIL { get; set; }
        public string? DES_PERFIL_APRESENTACAO { get; set; }
        public int? IND_PERFIL_ESTABELECIMENTO { get; set; }
        public int? IND_TIPO_ATIVIDADE { get; set; }
        public int? COD_CLASSIF_ESTABELECIMENTO { get; set; }

        public virtual SW_CLASSIF_ESTABELECIMENTO_SPED? COD_CLASSIF_ESTABELECIMENTONavigation { get; set; }
        public virtual PS_PESSOAS COD_FORNECEDOR_CONTABILNavigation { get; set; } = null!;
    }
}