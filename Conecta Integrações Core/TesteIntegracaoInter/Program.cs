using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using ConectaIntegracaoCoreOpenBank;
using ConectaIntegracaoCoreOpenBank.BancoInter.Models;
using ConectaIntegracaoCoreOpenBank.BancoInter.Models.Response;
using Newtonsoft.Json;


namespace TesteIntegracaoInter
{
    public class Program
    {
        static void Main(string[] args)
        {
            testarOpenBankInter();
        }
        private static void testarOpenBankInter()
        {
            var configuracao = new ConfiguracaoEmpresa();

            //configuracao.ClientId = "0263efa2-eda8-4104-91d8-fcedb1b0df47";
            //configuracao.ClientSecret = "7d042449-8f08-43ec-b06c-a74d09d8accd";
            //configuracao.HashCertificado = @"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";
            //configuracao.SenhaCertificado = "54991945663";
            //configuracao.desToken = "";


            var certificadoBytes = File.ReadAllBytes(@"C:\Users\eduardo.sebben\Downloads\Inter API_Certificado.pfx");
            var CertificadoHash = Convert.ToBase64String(certificadoBytes);

            //var bytesCertificados = Encoding.UTF8.GetBytes(certificado2);
            //var hashCertificado = Convert.ToBase64String(bytesCertificados);

            //var x509 = new X509Certificate2(certificadoBytes, "123456");



            configuracao.ClientId = "67eaf30e-8ab7-4a5f-8582-13f2a2db05a0";
            configuracao.ClientSecret = "090de6e5-e983-4793-b006-5838cfddfa3e";
            configuracao.HashCertificado = @"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";
            //configuracao.HashCertificado = @"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";
            configuracao.SenhaCertificado = "Inter2025";
            configuracao.desToken = "";

            //var certificado = Encoding.ASCII.GetBytes(configuracao.HashCertificado);
            //File.WriteAllBytes("Certificado.pfx", certificado);

            //var certificado2 = File.ReadAllText(@"C:\Users\eduardo.sebben\source\Workspaces\Conecta Integrações Core\TesteIntegracaoInter\bin\Debug\net8.0\Certificado.pfx");

            var envioBoletos = new RegistroBoletoDTO();

            var pagador = new PagadorDTO();
            pagador.bairro = "Madureira";
            pagador.cep = "95020190";
            pagador.cidade = "Caxias do sul";
            pagador.endereco = "Rua Doutor Montaury";
            pagador.complemento = "";
            pagador.numero = "1441";
            pagador.email = "teste@teste.com";
            pagador.nome = "2 Simples Nacional";
            pagador.cpfCnpj = "74910037000193";
            pagador.telefone = "999454545";
            pagador.tipoPessoa = "JURIDICA";
            pagador.uf = "RS";

            var beneficiarioFinal = new BeneficiarioDTO();
            beneficiarioFinal.cpfCnpj = "03184592000137";
            beneficiarioFinal.nome = "2 - Simples Nacional";
            beneficiarioFinal.tipoPessoa = "JURIDICA";
            beneficiarioFinal.bairro = "Madureira";
            beneficiarioFinal.cep = "95020190";
            beneficiarioFinal.cidade = "Caxias do sul";
            beneficiarioFinal.endereco = "Rua Doutor Montaury";
            beneficiarioFinal.uf = "RS";

            //var multa = new MultaDTO();
            //multa.codigoMulta = "VALORFIXO";
            //multa.data = "2024-05-02";
            //multa.taxa = 0;
            //multa.valor = (decimal)3.5;
            //envioBoletos.multa = multa;

            //var jurosMora = new MoraDTO();
            //jurosMora.codigoMora = "TAXAMENSAL";
            //jurosMora.data = "2024-05-02";
            //jurosMora.taxa = 3.5;
            //jurosMora.valor = 0;
            //envioBoletos.mora = jurosMora;

            var multa = new MultaDTO();
            multa.codigoMulta = "NAOTEMMULTA";
            ////multa.data = "2024-05-02";
            ////multa.taxa = 3.5;
            ////multa.valor = 0;
            envioBoletos.multa = multa;

            var jurosMora = new MoraDTO();
            jurosMora.codigoMora = "ISENTO";
            ////jurosMora.data = "2024-05-02";
            ////jurosMora.taxa = 0;
            ////jurosMora.valor = (decimal)0.01;
            envioBoletos.mora = jurosMora;

            var desconto = new DescontoDTO();
            desconto.codigoDesconto = "NAOTEMDESCONTO";
            envioBoletos.desconto1 = desconto;

            var desconto2 = new DescontoDTO();
            desconto2.codigoDesconto = "NAOTEMDESCONTO";
            envioBoletos.desconto2 = desconto2;

            var desconto3 = new DescontoDTO();
            desconto3.codigoDesconto = "NAOTEMDESCONTO";
            envioBoletos.desconto3 = desconto3;

            envioBoletos.seuNumero = "63499";
            envioBoletos.valorNominal = (decimal)2.55;
            envioBoletos.dataVencimento = "2025-01-01";
            envioBoletos.numDiasAgenda = 10;

            var mensagens = new MensagemDTO();
            mensagens.linha1 = "";

            envioBoletos.pagador = pagador;
            envioBoletos.benefiarioFinal = beneficiarioFinal;
            //var teste2 = new ConectaOpenBank().EnviarBoletosInter(envioBoletos, configuracao);

            //var dtaIncial = "2023-10-01";
            //var dtaFinal = "2023-10-30";

          //var teste = new ConectaOpenBank().ConsultaBoletosInter("2025-03-01", "2025-03-27", configuracao);

            //var teste2 = new ConectaOpenBank().ConsultaBoletosInter(dtaIncial, dtaFinal, configuracao);

            //configuracao.desToken = teste2.tokenDTO.access_token;


            var teste = new ConectaOpenBank().ConsultarDetalhesBoletoInter("90226311366", configuracao);

            var teste2 = new ConectaOpenBank().ConsultarDetalhesBoletoInter("90225489197", configuracao);
            var teste3 = new ConectaOpenBank().ConsultarDetalhesBoletoInter("90225489585", configuracao);
            var teste4 = new ConectaOpenBank().ConsultarDetalhesBoletoInter("90226355546", configuracao);
            var teste5 = new ConectaOpenBank().ConsultarDetalhesBoletoInter("90198926092", configuracao);
            var teste6 = new ConectaOpenBank().ConsultarDetalhesBoletoInter("90198919667", configuracao);


            var pagador2 = new PagadorDTO();
            //pagador2.bairro = "CENTRO";
            //pagador2.cep = "89665000";
            //pagador2.cidade = "CAPINZAL";
            //pagador2.complemento = "";
            //pagador2.cpfCnpj = "03620220000106";
            //pagador2.ddd = "";
            //pagador2.email = "controladoria@gratt.com.br";
            //pagador2.endereco = "ANTONIO PELEGRINI, 45, SALA 1, JARDIM DA SERRA";
            //pagador2.nome = "GRATT INDUSTRIA DE MAQUINAS LTDA";
            //pagador2.numero = "0";
            //pagador2.telefone = "";
            //pagador2.tipoPessoa = "JURIDICA";
            //pagador2.uf = "SC";

            //var descontodetalhe = new DescontoDetalheDTO();
            //descontodetalhe.codigoDesconto = "NAOTEMDESCONTO";
            //descontodetalhe.data = "";
            //descontodetalhe.taxa = 0.00;
            //descontodetalhe.valor = 0.00;

            //var descontodetalhe2 = new DescontoDetalheDTO();
            //descontodetalhe2.codigoDesconto = "NAOTEMDESCONTO";
            //descontodetalhe2.data = "";
            //descontodetalhe2.taxa = 0.00;
            //descontodetalhe2.valor = 0.00;

            //var descontodetalhe3 = new DescontoDetalheDTO();
            //descontodetalhe3.codigoDesconto = "NAOTEMDESCONTO";
            //descontodetalhe3.data = ""; 
            //descontodetalhe3.taxa = 0.00;
            //descontodetalhe3.valor = 0.00;

            //var multaDetalhe = new MultaDTO();
            //multaDetalhe.codigoMulta = "PERCENTUAL";
            //multaDetalhe.data = "2025-04-02";
            //multaDetalhe.taxa = 5.00;
            //multaDetalhe.valor = 0.00;


            //var mora = new MoraDTO();
            //mora.codigoMora = "TAXAMENSAL";
            //mora.data = "2025-04-02";
            //mora.taxa = 2.00;
            //mora.valor = 0.00;

            //var mensagem = new MensagemDTO();   


            //var dtoBoleto = new ConsultaBoletoDetalhadoResponseDTO();
            //dtoBoleto.cnpjCpfBeneficiario = "88818216000100";
            //dtoBoleto.codigoBarras = "07795103800011660940001112055677790192014614";
            //dtoBoleto.codigoEspecie = "DUPLICATAMERCANTIL";
            //dtoBoleto.contaCorrente = "84046902";
            //dtoBoleto.dataEmissao = "2025-01-31";
            //dtoBoleto.dataHoraSituacao = "2025-04-01 00:00";
            //dtoBoleto.dataLimite = "2025-05-31";
            //dtoBoleto.desconto1 = descontodetalhe;
            //dtoBoleto.dataVencimento = "2025-04-01";
            //dtoBoleto.desconto2 = descontodetalhe2;
            //dtoBoleto.desconto3 = descontodetalhe3;
            //dtoBoleto.linhaDigitavel = "07790001161205567779801920146147510380001166094";
            //dtoBoleto.mensagem = mensagem;
            //dtoBoleto.mora = mora;
            //dtoBoleto.multa = multaDetalhe;
            //dtoBoleto.nomeBeneficiario = "LONGHI ENGENHARIA E AUTOMACAO LTDA";
            //dtoBoleto.nossoNumero = "90192014614";
            //dtoBoleto.origem = "CERTIFICADO";
            //dtoBoleto.pagador = pagador2;
            //dtoBoleto.seuNumero = "002639001120305";
            //dtoBoleto.situacao = "PAGO";
            //dtoBoleto.TemErro = false;
            //dtoBoleto.tipoPessoaBeneficiario = "JURIDICA";
            //dtoBoleto.valorAbatimento = 0;
            //dtoBoleto.valorNominal = 11660.94;
            //dtoBoleto.valorTotalRecebimento = 11660.94;


            //var teste = new ConectaOpenBank().ConsultarDetalhesBoletoInter(nossoNumero, configuracao);
            //var nossoNumero = "01141494369";
            //var tese = new ConectaOpenBank().ImprimirBoletoInter(nossoNumero, configuracao);

            //System.IO.FileStream stream = new FileStream(@"C:\Users\eduardo.sebben\Desktop\file.pdf", FileMode.CreateNew);
            //System.IO.BinaryWriter writer = new BinaryWriter(stream);
            //writer.Write(tese.hashPdf, 0, tese.hashPdf.Length);
            //writer.Close();

            //var nossoNumero = "01102479961";
            //var teste = new ConectaOpenBank().BaixarBoleto(nossoNumero, "ACERTOS", configuracao);
            //var teste2 = JsonConvert.SerializeObject(teste);
        }
    }
}
