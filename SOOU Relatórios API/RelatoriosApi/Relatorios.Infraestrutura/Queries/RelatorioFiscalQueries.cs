namespace Relatorios.Infraestrutura.Queries
{
    public static class RelatorioFiscalQueries
    {
        public static string LivroFiscal =>
            @"SELECT  
	            COD_NOTA as CodigoNota,
	            DES_PESSOA as DesPessoa
            FROM FT_NOTAS";
    }


    public static class AccountQueries
    {
        public static string GetStringConnection =>
            @"SELECT 
				isnull(DES_SERVIDOR, '') as servidor,  
				isnull(DES_BANCO, '') as banco, 
				isnull(DES_USUARIO, '') as usuario, 
				isnull(DES_SENHA, '') as senha
			FROM 
				SW_ORGANIZACAO_APLICACAO_AMBIENTES OAA
				inner JOIN SW_ORGANIZACOES ORG
				ON OAA.COD_ORGANIZACAO = ORG.COD_ORGANIZACAO 
			WHERE 
				ORG.DES_GUID = @desGuid
				AND OAA.COD_APLICACAO = @codAplicacao
				AND OAA.COD_AMBIENTE = @codAmbiente
			";


        public static string ValidarTokenDistribuidoOrganizacao =>
            @"SELECT 
				ORG.DES_GUID 
			FROM 
				SW_ORGANIZACAO_TOKENS TOKEN
				INNER JOIN 
				SW_ORGANIZACOES ORG
				ON ORG.COD_ORGANIZACAO = TOKEN.COD_ORGANIZACAO
			WHERE 
				DES_TOKEN = @token
				AND ORG.DES_GUID = @guidOrg
				AND TOKEN.TIP_ATIVO = 1
			";

    }
}
