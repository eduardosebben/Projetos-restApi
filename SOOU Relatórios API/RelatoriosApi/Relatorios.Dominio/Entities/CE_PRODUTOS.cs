﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Relatorios.Dominio.Entities.Entities
{
    public partial class CE_PRODUTOS
    {
        public CE_PRODUTOS()
        {
            CE_INVENTARIOS_PRODUTOS = new HashSet<CE_INVENTARIOS_PRODUTOS>();
            CE_INVENTARIO_SPED_ITENS = new HashSet<CE_INVENTARIO_SPED_ITENS>();
            CE_MOVIMENTOS_ESTOQUES = new HashSet<CE_MOVIMENTOS_ESTOQUES>();
            CE_NOTAS_ITENS = new HashSet<CE_NOTAS_ITENS>();
            CE_PARAMETROS = new HashSet<CE_PARAMETROS>();
            CE_PRODUTOS_CONFIGURADOS = new HashSet<CE_PRODUTOS_CONFIGURADOS>();
            CE_PRODUTOS_FCI = new HashSet<CE_PRODUTOS_FCI>();
            CE_PRODUTOS_FORNECEDORES = new HashSet<CE_PRODUTOS_FORNECEDORES>();
            CE_PRODUTOS_IMAGENS = new HashSet<CE_PRODUTOS_IMAGENS>();
            CE_PRODUTOS_ISET = new HashSet<CE_PRODUTOS_ISET>();
            CE_PRODUTOS_LOTES = new HashSet<CE_PRODUTOS_LOTES>();
            CE_PRODUTOS_SERIES = new HashSet<CE_PRODUTOS_SERIES>();
            CE_PRODUTOS_TRAY = new HashSet<CE_PRODUTOS_TRAY>();
            CE_PRODUTOS_VALORES = new HashSet<CE_PRODUTOS_VALORES>();
            CE_PRODUTOS_VENDAS_EMPRESAS = new HashSet<CE_PRODUTOS_VENDAS_EMPRESAS>();
            CE_PRODUTO_ALMOXARIFADOS = new HashSet<CE_PRODUTO_ALMOXARIFADOS>();
            CE_PRODUTO_BARRAS = new HashSet<CE_PRODUTO_BARRAS>();
            CE_PRODUTO_COMPOSICAOCOD_PRODUTONavigation = new HashSet<CE_PRODUTO_COMPOSICAO>();
            CE_PRODUTO_COMPOSICAOCOD_PRODUTO_COMPOSICAONavigation = new HashSet<CE_PRODUTO_COMPOSICAO>();
            CE_PRODUTO_CONVERSAO_UNIDADES = new HashSet<CE_PRODUTO_CONVERSAO_UNIDADES>();
            CE_PRODUTO_TRIBUTACAO = new HashSet<CE_PRODUTO_TRIBUTACAO>();
            CO_ORDENS_ITENS = new HashSet<CO_ORDENS_ITENS>();
            FT_NOTAS_ITENS = new HashSet<FT_NOTAS_ITENS>();
            FT_PARAMETROS = new HashSet<FT_PARAMETROS>();
            FT_PEDIDOS_ITENS = new HashSet<FT_PEDIDOS_ITENS>();
            GE_LISTA_PRECOS_PRODUTOS = new HashSet<GE_LISTA_PRECOS_PRODUTOS>();
            GE_PROMOCOES_PRODUTOS = new HashSet<GE_PROMOCOES_PRODUTOS>();
            GE_REGRAS_TRIBUTACAO = new HashSet<GE_REGRAS_TRIBUTACAO>();
            OS_ORDEM_MATERIAIS = new HashSet<OS_ORDEM_MATERIAIS>();
            OS_ORDEM_SERVICO = new HashSet<OS_ORDEM_SERVICO>();
            PS_CONTRATOS = new HashSet<PS_CONTRATOS>();
            PS_CONTRATOS_ITENS = new HashSet<PS_CONTRATOS_ITENS>();
            PS_CONTRATOS_REAJUSTES = new HashSet<PS_CONTRATOS_REAJUSTES>();
            PS_LANCAMENTOS = new HashSet<PS_LANCAMENTOS>();
        }

        public int COD_PRODUTO { get; set; }
        public int COD_EMPRESA { get; set; }
        public string? COD_TIPO_SERVICO { get; set; }
        public string? DES_PRODUTO { get; set; }
        public decimal? PER_ISS { get; set; }
        public int COD_ORGANIZACAO { get; set; }
        public decimal? VLR_PRECO_VENDA { get; set; }
        public string? COD_PRODUTO_EMPRESA { get; set; }
        public int? COD_CLASSIFICACAO_FISCAL { get; set; }
        public int COD_UNIDADE_MEDIDA { get; set; }
        public bool? TIP_SERVICO { get; set; }
        public string? COD_ORIGEM { get; set; }
        public bool? TIP_MOVIMENTA_ESTOQUE { get; set; }
        public bool? TIP_CONTROLA_LOTE { get; set; }
        public bool? TIP_CONTROLA_NUMERO_SERIE { get; set; }
        public DateTime? DTA_DESATIVACAO { get; set; }
        public string? DES_MOTIVO_DESATIVACAO { get; set; }
        public int? COD_MARCA { get; set; }
        public int? COD_CATEGORIA { get; set; }
        public int? COD_CLASSIFICACAO { get; set; }
        public string? COD_TIPO_ITEM { get; set; }
        public int? COD_CONFIGURADOR { get; set; }
        public int IND_FORMATO { get; set; }
        public string? COD_APLICACAO_EXTERNA { get; set; }
        public decimal? VLR_CUSTO_REAL { get; set; }
        public decimal? VLR_CUSTO_REAL_ANTERIOR { get; set; }
        public decimal? VLR_CUSTO_MEDIO { get; set; }
        public decimal? VLR_CUSTO_REPOSICAO { get; set; }
        public string? DES_OBSERVACAO { get; set; }
        public string? COD_CBENF { get; set; }
        public string? COD_REFERENCIA { get; set; }
        public int? COD_CENTRO_CUSTO { get; set; }
        public string? DES_GUID { get; set; }
        public bool? TIP_VENDER_SEM_ESTOQUE { get; set; }
        public bool? TIP_NAO_LISTAR_INVENTARIO { get; set; }
        public decimal? VLR_PRECO_SUGERIDO { get; set; }
        public DateTime? DTA_CRIACAO { get; set; }
        public DateTime? DTA_ALTERACAO { get; set; }
        public int? COD_USUARIO_CRIACAO { get; set; }
        public int? COD_USUARIO_ALTERACAO { get; set; }
        public bool? TIP_EMISSAO_NOTA_FATURA { get; set; }
        public string? COD_TRIBUTACAO_MUNICIPIO { get; set; }
        public string? COD_UNIDADE_MEDIDA_TRIBUTAVEL { get; set; }
        public decimal? VLR_FATOR_CONVERSAO_TRIBUTAVEL { get; set; }
        public int? COD_CONTA_CONTABIL { get; set; }
        public bool? TIP_COBRANCA_POR_HORA { get; set; }
        public string? COD_TIPI { get; set; }
        public int? COD_GENERO { get; set; }
        public string? COD_TIPO_SERVICO_SPED { get; set; }

        public virtual GE_CATEGORIAS_PRODUTOS? COD_CATEGORIANavigation { get; set; }
        public virtual GE_CENTRO_CUSTOS? COD_CENTRO_CUSTONavigation { get; set; }
        public virtual GE_CLASSIFICACOES_PRODUTOS? COD_CLASSIFICACAONavigation { get; set; }
        public virtual GE_CLASSIFICACAO_FISCAL? COD_CLASSIFICACAO_FISCALNavigation { get; set; }
        public virtual CE_CONFIGURADOR? COD_CONFIGURADORNavigation { get; set; }
        public virtual GE_CONTAS_CONTABEIS? COD_CONTA_CONTABILNavigation { get; set; }
        public virtual GE_EMPRESAS COD_EMPRESANavigation { get; set; } = null!;
        public virtual SW_TIPO_GENERO? COD_GENERONavigation { get; set; }
        public virtual GE_MARCAS? COD_MARCANavigation { get; set; }
        public virtual GE_ORGANIZACAO COD_ORGANIZACAONavigation { get; set; } = null!;
        public virtual SW_ORIGEM_MERCADORIAS? COD_ORIGEMNavigation { get; set; }
        public virtual SW_TIPO_ITEM_SPED? COD_TIPO_ITEMNavigation { get; set; }
        public virtual SW_TIPO_SERVICO? COD_TIPO_SERVICONavigation { get; set; }
        public virtual GE_UNIDADE_MEDIDA COD_UNIDADE_MEDIDANavigation { get; set; } = null!;
        public virtual GE_USUARIOS? COD_USUARIO_ALTERACAONavigation { get; set; }
        public virtual GE_USUARIOS? COD_USUARIO_CRIACAONavigation { get; set; }
        public virtual ICollection<CE_INVENTARIOS_PRODUTOS> CE_INVENTARIOS_PRODUTOS { get; set; }
        public virtual ICollection<CE_INVENTARIO_SPED_ITENS> CE_INVENTARIO_SPED_ITENS { get; set; }
        public virtual ICollection<CE_MOVIMENTOS_ESTOQUES> CE_MOVIMENTOS_ESTOQUES { get; set; }
        public virtual ICollection<CE_NOTAS_ITENS> CE_NOTAS_ITENS { get; set; }
        public virtual ICollection<CE_PARAMETROS> CE_PARAMETROS { get; set; }
        public virtual ICollection<CE_PRODUTOS_CONFIGURADOS> CE_PRODUTOS_CONFIGURADOS { get; set; }
        public virtual ICollection<CE_PRODUTOS_FCI> CE_PRODUTOS_FCI { get; set; }
        public virtual ICollection<CE_PRODUTOS_FORNECEDORES> CE_PRODUTOS_FORNECEDORES { get; set; }
        public virtual ICollection<CE_PRODUTOS_IMAGENS> CE_PRODUTOS_IMAGENS { get; set; }
        public virtual ICollection<CE_PRODUTOS_ISET> CE_PRODUTOS_ISET { get; set; }
        public virtual ICollection<CE_PRODUTOS_LOTES> CE_PRODUTOS_LOTES { get; set; }
        public virtual ICollection<CE_PRODUTOS_SERIES> CE_PRODUTOS_SERIES { get; set; }
        public virtual ICollection<CE_PRODUTOS_TRAY> CE_PRODUTOS_TRAY { get; set; }
        public virtual ICollection<CE_PRODUTOS_VALORES> CE_PRODUTOS_VALORES { get; set; }
        public virtual ICollection<CE_PRODUTOS_VENDAS_EMPRESAS> CE_PRODUTOS_VENDAS_EMPRESAS { get; set; }
        public virtual ICollection<CE_PRODUTO_ALMOXARIFADOS> CE_PRODUTO_ALMOXARIFADOS { get; set; }
        public virtual ICollection<CE_PRODUTO_BARRAS> CE_PRODUTO_BARRAS { get; set; }
        public virtual ICollection<CE_PRODUTO_COMPOSICAO> CE_PRODUTO_COMPOSICAOCOD_PRODUTONavigation { get; set; }
        public virtual ICollection<CE_PRODUTO_COMPOSICAO> CE_PRODUTO_COMPOSICAOCOD_PRODUTO_COMPOSICAONavigation { get; set; }
        public virtual ICollection<CE_PRODUTO_CONVERSAO_UNIDADES> CE_PRODUTO_CONVERSAO_UNIDADES { get; set; }
        public virtual ICollection<CE_PRODUTO_TRIBUTACAO> CE_PRODUTO_TRIBUTACAO { get; set; }
        public virtual ICollection<CO_ORDENS_ITENS> CO_ORDENS_ITENS { get; set; }
        public virtual ICollection<FT_NOTAS_ITENS> FT_NOTAS_ITENS { get; set; }
        public virtual ICollection<FT_PARAMETROS> FT_PARAMETROS { get; set; }
        public virtual ICollection<FT_PEDIDOS_ITENS> FT_PEDIDOS_ITENS { get; set; }
        public virtual ICollection<GE_LISTA_PRECOS_PRODUTOS> GE_LISTA_PRECOS_PRODUTOS { get; set; }
        public virtual ICollection<GE_PROMOCOES_PRODUTOS> GE_PROMOCOES_PRODUTOS { get; set; }
        public virtual ICollection<GE_REGRAS_TRIBUTACAO> GE_REGRAS_TRIBUTACAO { get; set; }
        public virtual ICollection<OS_ORDEM_MATERIAIS> OS_ORDEM_MATERIAIS { get; set; }
        public virtual ICollection<OS_ORDEM_SERVICO> OS_ORDEM_SERVICO { get; set; }
        public virtual ICollection<PS_CONTRATOS> PS_CONTRATOS { get; set; }
        public virtual ICollection<PS_CONTRATOS_ITENS> PS_CONTRATOS_ITENS { get; set; }
        public virtual ICollection<PS_CONTRATOS_REAJUSTES> PS_CONTRATOS_REAJUSTES { get; set; }
        public virtual ICollection<PS_LANCAMENTOS> PS_LANCAMENTOS { get; set; }
    }
}