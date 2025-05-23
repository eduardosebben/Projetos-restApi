﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Relatorios.Dominio.Entities.Entities
{
    public partial class FT_NOTAS
    {
        public FT_NOTAS()
        {
            CE_NOTAS_RELACAO_SAIDAS = new HashSet<CE_NOTAS_RELACAO_SAIDAS>();
            CP_TITULOS = new HashSet<CP_TITULOS>();
            CR_TITULOS = new HashSet<CR_TITULOS>();
            FT_DEVOLUCOES = new HashSet<FT_DEVOLUCOES>();
            FT_NFSE_XML_ENVIADAS = new HashSet<FT_NFSE_XML_ENVIADAS>();
            FT_NFSE_XML_RETORNO = new HashSet<FT_NFSE_XML_RETORNO>();
            FT_NOTAS_CARTA_CORRECAO = new HashSet<FT_NOTAS_CARTA_CORRECAO>();
            FT_NOTAS_ITENS = new HashSet<FT_NOTAS_ITENS>();
            FT_NOTAS_MENSAGENS = new HashSet<FT_NOTAS_MENSAGENS>();
            FT_NOTAS_PAGAMENTOS = new HashSet<FT_NOTAS_PAGAMENTOS>();
            FT_NOTAS_REFERENCIADAS = new HashSet<FT_NOTAS_REFERENCIADAS>();
            FT_NOTAS_REPRESENTANTES = new HashSet<FT_NOTAS_REPRESENTANTES>();
            FT_NOTAS_XML_ENVIADAS = new HashSet<FT_NOTAS_XML_ENVIADAS>();
            FT_PEDIDOS_HISTORICOS = new HashSet<FT_PEDIDOS_HISTORICOS>();
            FT_PEDIDOS_NOTAS = new HashSet<FT_PEDIDOS_NOTAS>();
            FT_RETENCAO_IRCOD_NOTANavigation = new HashSet<FT_RETENCAO_IR>();
            FT_RETENCAO_IRCOD_NOTA_RETIDANavigation = new HashSet<FT_RETENCAO_IR>();
            FT_RETENCAO_PISCOFINSCOD_NOTANavigation = new HashSet<FT_RETENCAO_PISCOFINS>();
            FT_RETENCAO_PISCOFINSCOD_NOTA_RETIDANavigation = new HashSet<FT_RETENCAO_PISCOFINS>();
            OS_ORDEMCOD_NOTA_PRODUTONavigation = new HashSet<OS_ORDEM>();
            OS_ORDEMCOD_NOTA_SERVICONavigation = new HashSet<OS_ORDEM>();
        }

        public int COD_NOTA { get; set; }
        public int? COD_ORGANIZACAO { get; set; }
        public int COD_EMPRESA { get; set; }
        public int NUM_NOTA { get; set; }
        public string DES_SERIE { get; set; } = null!;
        public int? COD_PESSOA { get; set; }
        public DateTime DTA_EMISSAO { get; set; }
        public DateTime? DTA_SAIDA { get; set; }
        public int? COD_CONDICAO_PAGAMENTO { get; set; }
        public int? COD_TIPO_PAGAMENTO { get; set; }
        public int? COD_BANCO { get; set; }
        public int? COD_OPERACAO_FISCAL { get; set; }
        public decimal? VLR_MERCADORIA { get; set; }
        public decimal? VLR_TOTAL { get; set; }
        public int IND_SITUACAO { get; set; }
        public decimal? PER_DESCONTO { get; set; }
        public decimal? VLR_DESCONTO { get; set; }
        public decimal? VLR_BASE_ISS { get; set; }
        public decimal? VLR_BASE_IR { get; set; }
        public decimal? VLR_BASE_PIS { get; set; }
        public decimal? VLR_BASE_COFINS { get; set; }
        public decimal? VLR_BASE_CSLL { get; set; }
        public decimal? VLR_BASE_INSS { get; set; }
        public decimal? VLR_ISS { get; set; }
        public decimal? VLR_IR { get; set; }
        public decimal? VLR_PIS { get; set; }
        public decimal? VLR_COFINS { get; set; }
        public decimal? VLR_CSLL { get; set; }
        public decimal? VLR_INSS { get; set; }
        public string? COD_MODELO_NOTA { get; set; }
        public int? IND_TIPO_NOTA { get; set; }
        public string? DES_CHAVE_ACESSO { get; set; }
        public int? NUM_LOTE_NFS { get; set; }
        public DateTime? DTA_AUTORIZACAO { get; set; }
        public string? COD_PROTOCOLO { get; set; }
        public DateTime? DTA_CANCELAMENTO { get; set; }
        public string? DES_MOTIVO_CANCELAMENTO { get; set; }
        public string? DES_URL_NOTA { get; set; }
        public string? DES_URL_BOLETO { get; set; }
        public int? COD_CONVENIO { get; set; }
        public decimal VLR_BASE_ISS_RETIDO { get; set; }
        public decimal VLR_ISS_RETIDO { get; set; }
        public bool? TIP_CONSUMIDOR_FINAL { get; set; }
        public string? COD_PRESENCA_COMPRADOR { get; set; }
        public string? COD_FINALIDADE_EMISSAO { get; set; }
        public string? HMS_SAIDA { get; set; }
        public decimal? VLR_BASE_ICMS { get; set; }
        public decimal? VLR_ICMS { get; set; }
        public decimal? VLR_BASE_ST { get; set; }
        public decimal? VLR_ST { get; set; }
        public int? COD_TRANSPORTADORA { get; set; }
        public decimal? VLR_BASE_IPI { get; set; }
        public decimal? VLR_IPI { get; set; }
        public decimal? VLR_FRETE { get; set; }
        public decimal? VLR_SEGURO { get; set; }
        public decimal? VLR_DESPESA { get; set; }
        public string? COD_MODALIDADE_FRETE { get; set; }
        public string? DES_PLACA_VEICULO { get; set; }
        public string? DES_MARCA { get; set; }
        public string? DES_ESPECIE { get; set; }
        public int? QTD_VOLUMES { get; set; }
        public decimal? QTD_PESO_LIQUIDO { get; set; }
        public decimal? QTD_PESO_BRUTO { get; set; }
        public decimal? VLR_BASE_FUNDO_COMBATE_POBREZA { get; set; }
        public decimal? VLR_FUNDO_COMBATE_POBREZA { get; set; }
        public decimal? VLR_ICMS_INTERESTADUAL_ORIGEM { get; set; }
        public decimal? VLR_ICMS_INTERESTADUAL_DESTINO { get; set; }
        public int? COD_UF_EMBARQUE { get; set; }
        public string? DES_LOCAL_EMBARQUE { get; set; }
        public int? COD_TIPO_NOTA { get; set; }
        public string? COD_LOCAL_DESTINO { get; set; }
        public bool? TIP_CALCULO_AUTOMATICO { get; set; }
        public decimal? VLR_BASE_IMPOSTO_IMPORTACAO { get; set; }
        public decimal? VLR_IMPOSTO_IMPORTACAO { get; set; }
        public decimal? VLR_BASE_FUNDO_COMBATE_POBREZA_ST { get; set; }
        public decimal? VLR_FUNDO_COMBATE_POBREZA_ST { get; set; }
        public string? COD_APLICACAO_EXTERNA { get; set; }
        public string? DES_PESSOA { get; set; }
        public string? NUM_CPF_CNPJ { get; set; }
        public int? COD_USUARIO_EMISSAO { get; set; }
        public int? COD_USUARIO_CANCELAMENTO { get; set; }
        public string? COD_PROTOCOLO_CANCELAMENTO { get; set; }
        public int? NUM_RPS_NFSE { get; set; }
        public string? DES_SERIE_RPS_NFSE { get; set; }
        public string? COD_VERIFICACAO_NOTA_SERVICO { get; set; }
        public decimal? VLR_BASE_ICMS_SIMPLES_ST { get; set; }
        public decimal? VLR_ICMS_SIMPLES_ST { get; set; }
        public decimal? VLR_BASE_IMPOSTO { get; set; }
        public decimal? PER_IMPOSTO_FEDERAL { get; set; }
        public decimal? VLR_IMPOSTO_FEDERAL { get; set; }
        public decimal? PER_IMPOSTO_ESTADUAL { get; set; }
        public decimal? VLR_IMPOSTO_ESTADUAL { get; set; }
        public decimal? PER_IMPOSTO_MUNICIPAL { get; set; }
        public decimal? VLR_IMPOSTO_MUNICIPAL { get; set; }
        public string? DES_COMPOSICAO_PAGAMENTO { get; set; }
        public int? COD_USUARIO_REGERAR_DANFE { get; set; }
        public DateTime? DTA_REGERAR_DANFE { get; set; }
        public int? COD_LISTA_PRECO { get; set; }
        public string? DES_GUID { get; set; }
        public decimal? VLR_ARREDONDAMENTO { get; set; }
        public int? COD_FRENTE_CAIXA { get; set; }
        public bool? TIP_EM_CONTINGENCIA { get; set; }
        public DateTime? DTA_CONTINGENCIA { get; set; }
        public string? DES_MOTIVO_CONTINGENCIA { get; set; }
        public string? ID_PEDIDO_FOOD { get; set; }
        public bool? TIP_NOTA_FATURA { get; set; }
        public int? COD_INTERMEDIADOR { get; set; }
        public decimal? VLR_FRETE_RODOVIARIO { get; set; }
        public decimal? VLR_DESPESAS_IMPORTACAO { get; set; }
        public decimal? VLR_SERVICOS_IMPORTACAO { get; set; }
        public int? COD_TRANSPORTADORA_REDESPACHO { get; set; }
        public bool? TIP_ENVIADO_SEFAZ { get; set; }
        public int? COD_CANAL_VENDAS { get; set; }
        public int? COD_IBGE_UF { get; set; }
        public int? COD_CIDADE { get; set; }
        public int? COD_ABERTURA { get; set; }
        public string? NUM_IE_ST { get; set; }
        public decimal? VLR_ICMS_DESONERADO { get; set; }
        public decimal? VLR_PIS_DESONERADO { get; set; }
        public decimal? VLR_COFINS_DESONERADO { get; set; }

        public virtual CA_ABERTURA_FECHAMENTO? COD_ABERTURANavigation { get; set; }
        public virtual GE_BANCOS? COD_BANCONavigation { get; set; }
        public virtual PS_CANAL_VENDAS? COD_CANAL_VENDASNavigation { get; set; }
        public virtual GE_CIDADES? COD_CIDADENavigation { get; set; }
        public virtual GE_CONDICAO_PAGAMENTO? COD_CONDICAO_PAGAMENTONavigation { get; set; }
        public virtual CR_CONVENIOS_BANCARIOS? COD_CONVENIONavigation { get; set; }
        public virtual GE_EMPRESAS COD_EMPRESANavigation { get; set; } = null!;
        public virtual SW_FINALIDADE_EMISSAO_NOTA? COD_FINALIDADE_EMISSAONavigation { get; set; }
        public virtual GE_CADASTRO_FRENTE_CAIXA? COD_FRENTE_CAIXANavigation { get; set; }
        public virtual SW_UF? COD_IBGE_UFNavigation { get; set; }
        public virtual GE_INTERMEDIADOR? COD_INTERMEDIADORNavigation { get; set; }
        public virtual GE_LISTA_PRECOS? COD_LISTA_PRECONavigation { get; set; }
        public virtual SW_LOCAL_DESTINO_OPERACAO? COD_LOCAL_DESTINONavigation { get; set; }
        public virtual SW_MODALIDADES_FRETE? COD_MODALIDADE_FRETENavigation { get; set; }
        public virtual SW_MODELO_NOTA? COD_MODELO_NOTANavigation { get; set; }
        public virtual GE_OPERACAO_FISCAL? COD_OPERACAO_FISCALNavigation { get; set; }
        public virtual GE_ORGANIZACAO? COD_ORGANIZACAONavigation { get; set; }
        public virtual PS_PESSOAS? COD_PESSOANavigation { get; set; }
        public virtual SW_PRESENCA_COMPRADOR? COD_PRESENCA_COMPRADORNavigation { get; set; }
        public virtual SW_TIPOS_NOTAS? COD_TIPO_NOTANavigation { get; set; }
        public virtual GE_TIPO_PAGAMENTO? COD_TIPO_PAGAMENTONavigation { get; set; }
        public virtual PS_PESSOAS? COD_TRANSPORTADORANavigation { get; set; }
        public virtual PS_PESSOAS? COD_TRANSPORTADORA_REDESPACHONavigation { get; set; }
        public virtual SW_UF? COD_UF_EMBARQUENavigation { get; set; }
        public virtual GE_USUARIOS? COD_USUARIO_CANCELAMENTONavigation { get; set; }
        public virtual GE_USUARIOS? COD_USUARIO_EMISSAONavigation { get; set; }
        public virtual GE_USUARIOS? COD_USUARIO_REGERAR_DANFENavigation { get; set; }
        public virtual ICollection<CE_NOTAS_RELACAO_SAIDAS> CE_NOTAS_RELACAO_SAIDAS { get; set; }
        public virtual ICollection<CP_TITULOS> CP_TITULOS { get; set; }
        public virtual ICollection<CR_TITULOS> CR_TITULOS { get; set; }
        public virtual ICollection<FT_DEVOLUCOES> FT_DEVOLUCOES { get; set; }
        public virtual ICollection<FT_NFSE_XML_ENVIADAS> FT_NFSE_XML_ENVIADAS { get; set; }
        public virtual ICollection<FT_NFSE_XML_RETORNO> FT_NFSE_XML_RETORNO { get; set; }
        public virtual ICollection<FT_NOTAS_CARTA_CORRECAO> FT_NOTAS_CARTA_CORRECAO { get; set; }
        public virtual ICollection<FT_NOTAS_ITENS> FT_NOTAS_ITENS { get; set; }
        public virtual ICollection<FT_NOTAS_MENSAGENS> FT_NOTAS_MENSAGENS { get; set; }
        public virtual ICollection<FT_NOTAS_PAGAMENTOS> FT_NOTAS_PAGAMENTOS { get; set; }
        public virtual ICollection<FT_NOTAS_REFERENCIADAS> FT_NOTAS_REFERENCIADAS { get; set; }
        public virtual ICollection<FT_NOTAS_REPRESENTANTES> FT_NOTAS_REPRESENTANTES { get; set; }
        public virtual ICollection<FT_NOTAS_XML_ENVIADAS> FT_NOTAS_XML_ENVIADAS { get; set; }
        public virtual ICollection<FT_PEDIDOS_HISTORICOS> FT_PEDIDOS_HISTORICOS { get; set; }
        public virtual ICollection<FT_PEDIDOS_NOTAS> FT_PEDIDOS_NOTAS { get; set; }
        public virtual ICollection<FT_RETENCAO_IR> FT_RETENCAO_IRCOD_NOTANavigation { get; set; }
        public virtual ICollection<FT_RETENCAO_IR> FT_RETENCAO_IRCOD_NOTA_RETIDANavigation { get; set; }
        public virtual ICollection<FT_RETENCAO_PISCOFINS> FT_RETENCAO_PISCOFINSCOD_NOTANavigation { get; set; }
        public virtual ICollection<FT_RETENCAO_PISCOFINS> FT_RETENCAO_PISCOFINSCOD_NOTA_RETIDANavigation { get; set; }
        public virtual ICollection<OS_ORDEM> OS_ORDEMCOD_NOTA_PRODUTONavigation { get; set; }
        public virtual ICollection<OS_ORDEM> OS_ORDEMCOD_NOTA_SERVICONavigation { get; set; }
    }
}