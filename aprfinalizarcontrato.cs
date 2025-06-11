using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class aprfinalizarcontrato : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aprfinalizarcontrato().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         context.StatusMessage( "Command line using complex types not supported." );
         return GX.GXRuntime.ExitCode ;
      }

      public aprfinalizarcontrato( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprfinalizarcontrato( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_AssinaturaId ,
                           string aP1_BaseUrl ,
                           out SdtSdErro aP2_SdErro )
      {
         this.AV8AssinaturaId = aP0_AssinaturaId;
         this.AV63BaseUrl = aP1_BaseUrl;
         this.AV9SdErro = new SdtSdErro(context) ;
         initialize();
         ExecuteImpl();
         aP2_SdErro=this.AV9SdErro;
      }

      public SdtSdErro executeUdp( long aP0_AssinaturaId ,
                                   string aP1_BaseUrl )
      {
         execute(aP0_AssinaturaId, aP1_BaseUrl, out aP2_SdErro);
         return AV9SdErro ;
      }

      public void executeSubmit( long aP0_AssinaturaId ,
                                 string aP1_BaseUrl ,
                                 out SdtSdErro aP2_SdErro )
      {
         this.AV8AssinaturaId = aP0_AssinaturaId;
         this.AV63BaseUrl = aP1_BaseUrl;
         this.AV9SdErro = new SdtSdErro(context) ;
         SubmitImpl();
         aP2_SdErro=this.AV9SdErro;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P008V2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A563ConfiguracaoSenhaPFX = P008V2_A563ConfiguracaoSenhaPFX[0];
            n563ConfiguracaoSenhaPFX = P008V2_n563ConfiguracaoSenhaPFX[0];
            A654ConfiguracoesCategoriaTitulo = P008V2_A654ConfiguracoesCategoriaTitulo[0];
            n654ConfiguracoesCategoriaTitulo = P008V2_n654ConfiguracoesCategoriaTitulo[0];
            A299ConfiguracoesId = P008V2_A299ConfiguracoesId[0];
            A562ConfiguracoesArquivoPFX = P008V2_A562ConfiguracoesArquivoPFX[0];
            n562ConfiguracoesArquivoPFX = P008V2_n562ConfiguracoesArquivoPFX[0];
            AV49ConfiguracaoSenhaPFX = A563ConfiguracaoSenhaPFX;
            AV50ConfiguracoesArquivoPFX = A562ConfiguracoesArquivoPFX;
            AV67ConfiguracoesCategoriaTitulo = A654ConfiguracoesCategoriaTitulo;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor P008V3 */
         pr_default.execute(1, new Object[] {AV8AssinaturaId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A231ArquivoId = P008V3_A231ArquivoId[0];
            n231ArquivoId = P008V3_n231ArquivoId[0];
            A238AssinaturaId = P008V3_A238AssinaturaId[0];
            n238AssinaturaId = P008V3_n238AssinaturaId[0];
            A239AssinaturaStatus = P008V3_A239AssinaturaStatus[0];
            n239AssinaturaStatus = P008V3_n239AssinaturaStatus[0];
            A255ArquivoNome = P008V3_A255ArquivoNome[0];
            n255ArquivoNome = P008V3_n255ArquivoNome[0];
            A254ArquivoExtensao = P008V3_A254ArquivoExtensao[0];
            n254ArquivoExtensao = P008V3_n254ArquivoExtensao[0];
            A366AssinaturaFinalizadoData = P008V3_A366AssinaturaFinalizadoData[0];
            n366AssinaturaFinalizadoData = P008V3_n366AssinaturaFinalizadoData[0];
            A369AssinaturaAno = P008V3_A369AssinaturaAno[0];
            n369AssinaturaAno = P008V3_n369AssinaturaAno[0];
            A368AssinaturaMes = P008V3_A368AssinaturaMes[0];
            n368AssinaturaMes = P008V3_n368AssinaturaMes[0];
            A371AssinaturaMesNome = P008V3_A371AssinaturaMesNome[0];
            n371AssinaturaMesNome = P008V3_n371AssinaturaMesNome[0];
            A241AssinaturaPublicKey = P008V3_A241AssinaturaPublicKey[0];
            n241AssinaturaPublicKey = P008V3_n241AssinaturaPublicKey[0];
            A228ContratoNome = P008V3_A228ContratoNome[0];
            n228ContratoNome = P008V3_n228ContratoNome[0];
            A578ArquivoAssinadoId = P008V3_A578ArquivoAssinadoId[0];
            n578ArquivoAssinadoId = P008V3_n578ArquivoAssinadoId[0];
            A365AssinaturaToken = P008V3_A365AssinaturaToken[0];
            n365AssinaturaToken = P008V3_n365AssinaturaToken[0];
            A227ContratoId = P008V3_A227ContratoId[0];
            n227ContratoId = P008V3_n227ContratoId[0];
            A232ArquivoBlob = P008V3_A232ArquivoBlob[0];
            n232ArquivoBlob = P008V3_n232ArquivoBlob[0];
            A255ArquivoNome = P008V3_A255ArquivoNome[0];
            n255ArquivoNome = P008V3_n255ArquivoNome[0];
            A254ArquivoExtensao = P008V3_A254ArquivoExtensao[0];
            n254ArquivoExtensao = P008V3_n254ArquivoExtensao[0];
            A232ArquivoBlob = P008V3_A232ArquivoBlob[0];
            n232ArquivoBlob = P008V3_n232ArquivoBlob[0];
            A228ContratoNome = P008V3_A228ContratoNome[0];
            n228ContratoNome = P008V3_n228ContratoNome[0];
            A239AssinaturaStatus = "ASSINADO";
            n239AssinaturaStatus = false;
            AV31AssinaturaFinalizadoData = DateTimeUtil.ServerNow( context, pr_default);
            A366AssinaturaFinalizadoData = AV31AssinaturaFinalizadoData;
            n366AssinaturaFinalizadoData = false;
            A369AssinaturaAno = (short)(DateTimeUtil.Year( AV31AssinaturaFinalizadoData));
            n369AssinaturaAno = false;
            A368AssinaturaMes = (short)(DateTimeUtil.Month( AV31AssinaturaFinalizadoData));
            n368AssinaturaMes = false;
            A371AssinaturaMesNome = StringUtil.Trim( DateTimeUtil.CMonth( AV31AssinaturaFinalizadoData, "por"));
            n371AssinaturaMesNome = false;
            AV11Array_SdParticipantesContrato = new GXBaseCollection<SdtSdParticipantesContrato>( context, "SdParticipantesContrato", "Factory21");
            /* Using cursor P008V4 */
            pr_default.execute(2, new Object[] {n238AssinaturaId, A238AssinaturaId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A233ParticipanteId = P008V4_A233ParticipanteId[0];
               n233ParticipanteId = P008V4_n233ParticipanteId[0];
               A248ParticipanteNome = P008V4_A248ParticipanteNome[0];
               n248ParticipanteNome = P008V4_n248ParticipanteNome[0];
               A235ParticipanteEmail = P008V4_A235ParticipanteEmail[0];
               n235ParticipanteEmail = P008V4_n235ParticipanteEmail[0];
               A350AssinaturaParticipanteCPF = P008V4_A350AssinaturaParticipanteCPF[0];
               n350AssinaturaParticipanteCPF = P008V4_n350AssinaturaParticipanteCPF[0];
               A352AssinaturaParticipanteNascimento = P008V4_A352AssinaturaParticipanteNascimento[0];
               n352AssinaturaParticipanteNascimento = P008V4_n352AssinaturaParticipanteNascimento[0];
               A245AssinaturaParticipanteDataConclusao = P008V4_A245AssinaturaParticipanteDataConclusao[0];
               n245AssinaturaParticipanteDataConclusao = P008V4_n245AssinaturaParticipanteDataConclusao[0];
               A246AssinaturaParticipanteKey = P008V4_A246AssinaturaParticipanteKey[0];
               n246AssinaturaParticipanteKey = P008V4_n246AssinaturaParticipanteKey[0];
               A346AssinaturaParticipanteRemoteAddres = P008V4_A346AssinaturaParticipanteRemoteAddres[0];
               n346AssinaturaParticipanteRemoteAddres = P008V4_n346AssinaturaParticipanteRemoteAddres[0];
               A347AssinaturaParticipanteGeolocalizacao = P008V4_A347AssinaturaParticipanteGeolocalizacao[0];
               n347AssinaturaParticipanteGeolocalizacao = P008V4_n347AssinaturaParticipanteGeolocalizacao[0];
               A348AssinaturaParticipanteDispositivo = P008V4_A348AssinaturaParticipanteDispositivo[0];
               n348AssinaturaParticipanteDispositivo = P008V4_n348AssinaturaParticipanteDispositivo[0];
               A1002ParticipanteRepresentanteNome = P008V4_A1002ParticipanteRepresentanteNome[0];
               n1002ParticipanteRepresentanteNome = P008V4_n1002ParticipanteRepresentanteNome[0];
               A1003ParticipanteRepresentanteEmail = P008V4_A1003ParticipanteRepresentanteEmail[0];
               n1003ParticipanteRepresentanteEmail = P008V4_n1003ParticipanteRepresentanteEmail[0];
               A1004ParticipanteRepresentanteDocumento = P008V4_A1004ParticipanteRepresentanteDocumento[0];
               n1004ParticipanteRepresentanteDocumento = P008V4_n1004ParticipanteRepresentanteDocumento[0];
               A242AssinaturaParticipanteId = P008V4_A242AssinaturaParticipanteId[0];
               A248ParticipanteNome = P008V4_A248ParticipanteNome[0];
               n248ParticipanteNome = P008V4_n248ParticipanteNome[0];
               A235ParticipanteEmail = P008V4_A235ParticipanteEmail[0];
               n235ParticipanteEmail = P008V4_n235ParticipanteEmail[0];
               A1002ParticipanteRepresentanteNome = P008V4_A1002ParticipanteRepresentanteNome[0];
               n1002ParticipanteRepresentanteNome = P008V4_n1002ParticipanteRepresentanteNome[0];
               A1003ParticipanteRepresentanteEmail = P008V4_A1003ParticipanteRepresentanteEmail[0];
               n1003ParticipanteRepresentanteEmail = P008V4_n1003ParticipanteRepresentanteEmail[0];
               A1004ParticipanteRepresentanteDocumento = P008V4_A1004ParticipanteRepresentanteDocumento[0];
               n1004ParticipanteRepresentanteDocumento = P008V4_n1004ParticipanteRepresentanteDocumento[0];
               AV12SdParticipantesContrato = new SdtSdParticipantesContrato(context);
               AV12SdParticipantesContrato.gxTpr_Participantenome = A248ParticipanteNome;
               AV12SdParticipantesContrato.gxTpr_Participanteemail = A235ParticipanteEmail;
               AV12SdParticipantesContrato.gxTpr_Assinaturaparticipantecpf = A350AssinaturaParticipanteCPF;
               AV12SdParticipantesContrato.gxTpr_Assinaturaparticipantenascimento = A352AssinaturaParticipanteNascimento;
               AV12SdParticipantesContrato.gxTpr_Assinaturaparticipantedataconclusao = A245AssinaturaParticipanteDataConclusao;
               GXt_char1 = "";
               new prcensuratoken(context ).execute(  A246AssinaturaParticipanteKey.ToString(), out  GXt_char1) ;
               AV12SdParticipantesContrato.gxTpr_Assinaturaparticipantekey = GXt_char1;
               AV12SdParticipantesContrato.gxTpr_Assinaturaparticipanteremoteaddres = A346AssinaturaParticipanteRemoteAddres;
               AV12SdParticipantesContrato.gxTpr_Assinaturaparticipantegeolocalizacao = A347AssinaturaParticipanteGeolocalizacao;
               AV12SdParticipantesContrato.gxTpr_Assinaturaparticipantedispositivo = A348AssinaturaParticipanteDispositivo;
               AV12SdParticipantesContrato.gxTpr_Participanterepresentantenome = A1002ParticipanteRepresentanteNome;
               AV12SdParticipantesContrato.gxTpr_Participanterepresentanteemail = A1003ParticipanteRepresentanteEmail;
               AV12SdParticipantesContrato.gxTpr_Participanterepresentantedocumento = A1004ParticipanteRepresentanteDocumento;
               AV11Array_SdParticipantesContrato.Add(AV12SdParticipantesContrato, 0);
               pr_default.readNext(2);
            }
            pr_default.close(2);
            AV31AssinaturaFinalizadoData = A366AssinaturaFinalizadoData;
            AV17ArquivoBlob = A232ArquivoBlob;
            AV18AssinaturaPublicKey = A241AssinaturaPublicKey;
            new prhtmlfimcontrato(context ).execute(  A228ContratoNome,  A241AssinaturaPublicKey,  AV31AssinaturaFinalizadoData,  AV11Array_SdParticipantesContrato, out  AV13HTML) ;
            AV44PdfOriginalFile = new GxFile(context.GetPhysicalPath());
            AV45GUID = Guid.NewGuid( );
            AV46Source = "./PublicTempStorage/" + StringUtil.Trim( AV45GUID.ToString()) + ".pdf";
            AV44PdfOriginalFile.Source = AV46Source;
            AV44PdfOriginalFile.FromBase64(context.FileToBase64( AV17ArquivoBlob));
            AV44PdfOriginalFile.Create();
            AV45GUID = Guid.NewGuid( );
            AV46Source = "./PublicTempStorage/" + StringUtil.Trim( AV45GUID.ToString()) + ".pdf";
            AV47PdfOrigemFile = new GxFile(context.GetPhysicalPath());
            AV47PdfOrigemFile.Source = AV46Source;
            AV48PDFService.concatenarhtmlnopdf( AV44PdfOriginalFile.GetAbsoluteName(),  AV47PdfOrigemFile.GetAbsoluteName(),  AV13HTML);
            AV48PDFService.dispose();
            AV45GUID = Guid.NewGuid( );
            AV46Source = "./PublicTempStorage/" + StringUtil.Trim( AV45GUID.ToString()) + ".pfx";
            AV51CertificadoFIle = new GxFile(context.GetPhysicalPath());
            AV51CertificadoFIle.Source = AV46Source;
            AV51CertificadoFIle.FromBase64(context.FileToBase64( AV50ConfiguracoesArquivoPFX));
            AV51CertificadoFIle.Create();
            AV45GUID = Guid.NewGuid( );
            AV46Source = "./PublicTempStorage/" + StringUtil.Trim( AV45GUID.ToString()) + ".pdf";
            AV52PdfHistoricoCertificadoFile = new GxFile(context.GetPhysicalPath());
            AV52PdfHistoricoCertificadoFile.Source = AV46Source;
            AV53result = AV55DigitalSignatureUtil.addsignature1(AV47PdfOrigemFile.GetAbsoluteName(), AV52PdfHistoricoCertificadoFile.GetAbsoluteName(), AV51CertificadoFIle.GetAbsoluteName(), AV49ConfiguracaoSenhaPFX, false);
            AV54Blob = AV52PdfHistoricoCertificadoFile.GetAbsoluteName();
            AV64Arquivo = new SdtArquivo(context);
            AV64Arquivo.gxTpr_Arquivonome = StringUtil.Trim( AV45GUID.ToString());
            AV64Arquivo.gxTpr_Arquivoextensao = "pdf";
            AV64Arquivo.gxTpr_Arquivoblob = AV54Blob;
            AV64Arquivo.Save();
            A578ArquivoAssinadoId = AV64Arquivo.gxTpr_Arquivoid;
            n578ArquivoAssinadoId = false;
            AV27checksum = AV28ChecksumCreator.generatechecksum(context.FileToBase64( AV54Blob), "BASE64", "SHA256");
            GXt_char1 = AV29Chave;
            new prchave(context ).execute( out  GXt_char1) ;
            AV29Chave = GXt_char1;
            A365AssinaturaToken = AV27checksum;
            n365AssinaturaToken = false;
            AV32ContratoId = A227ContratoId;
            AV43Contrato.Load(AV32ContratoId);
            AV43Contrato.gxTpr_Contratosituacao = "Assinado";
            AV61ContratoNome = AV43Contrato.gxTpr_Contratonome;
            AV43Contrato.Save();
            if ( AV43Contrato.Fail() )
            {
               AV9SdErro.gxTpr_Internalcode = 1;
               AV9SdErro.gxTpr_Msg = ((GeneXus.Utils.SdtMessages_Message)AV43Contrato.GetMessages().Item(1)).gxTpr_Description;
            }
            /* Execute user subroutine: 'VERIFICASETODOSCONTRATOSFORAMASSINADOS' */
            S121 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               cleanup();
               if (true) return;
            }
            /* Using cursor P008V5 */
            pr_default.execute(3, new Object[] {n239AssinaturaStatus, A239AssinaturaStatus, n366AssinaturaFinalizadoData, A366AssinaturaFinalizadoData, n369AssinaturaAno, A369AssinaturaAno, n368AssinaturaMes, A368AssinaturaMes, n371AssinaturaMesNome, A371AssinaturaMesNome, n578ArquivoAssinadoId, A578ArquivoAssinadoId, n365AssinaturaToken, A365AssinaturaToken, n238AssinaturaId, A238AssinaturaId});
            pr_default.close(3);
            pr_default.SmartCacheProvider.SetUpdated("Assinatura");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         if ( (0==AV9SdErro.gxTpr_Internalcode) )
         {
            context.CommitDataStores("prfinalizarcontrato",pr_default);
            /* Execute user subroutine: 'NOTIFICATODOSOSPARTICIPANTES' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'NOTIFICATODOSOSPARTICIPANTES' Routine */
         returnInSub = false;
         AV62Link = AV63BaseUrl + formatLink("consultacontratodigital") ;
         new prnotificaparticipantefimcontrato(context).executeSubmit(  AV11Array_SdParticipantesContrato,  StringUtil.Trim( AV61ContratoNome),  AV62Link,  StringUtil.Trim( AV27checksum),  AV52PdfHistoricoCertificadoFile.GetAbsoluteName()) ;
      }

      protected void S121( )
      {
         /* 'VERIFICASETODOSCONTRATOSFORAMASSINADOS' Routine */
         returnInSub = false;
         /* Using cursor P008V6 */
         pr_default.execute(4, new Object[] {AV8AssinaturaId});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A571PropostaAssinatura = P008V6_A571PropostaAssinatura[0];
            n571PropostaAssinatura = P008V6_n571PropostaAssinatura[0];
            A323PropostaId = P008V6_A323PropostaId[0];
            n323PropostaId = P008V6_n323PropostaId[0];
            A573PropostaContratoAssinaturaTipo = P008V6_A573PropostaContratoAssinaturaTipo[0];
            n573PropostaContratoAssinaturaTipo = P008V6_n573PropostaContratoAssinaturaTipo[0];
            A572PropostaContratoAssinaturaId = P008V6_A572PropostaContratoAssinaturaId[0];
            AV58PropostaId = A323PropostaId;
            AV65PropostaContratoAssinaturaTipo = A573PropostaContratoAssinaturaTipo;
            pr_default.readNext(4);
         }
         pr_default.close(4);
         AV57IsTodosAssinados = true;
         AV73GXV2 = 1;
         AV72GXV1 = (GxSimpleCollection<string>)(gxdomaindmtipocontrato.getValues());
         while ( AV73GXV2 <= AV72GXV1.Count )
         {
            AV60DmTipoContrato = ((string)AV72GXV1.Item(AV73GXV2));
            if ( ! ( StringUtil.StrCmp(AV60DmTipoContrato, "Documento") == 0 ) )
            {
               AV74GXLvl141 = 0;
               /* Using cursor P008V7 */
               pr_default.execute(5, new Object[] {AV58PropostaId, AV60DmTipoContrato});
               while ( (pr_default.getStatus(5) != 101) )
               {
                  A573PropostaContratoAssinaturaTipo = P008V7_A573PropostaContratoAssinaturaTipo[0];
                  n573PropostaContratoAssinaturaTipo = P008V7_n573PropostaContratoAssinaturaTipo[0];
                  A574PropostaAssinaturaStatus = P008V7_A574PropostaAssinaturaStatus[0];
                  n574PropostaAssinaturaStatus = P008V7_n574PropostaAssinaturaStatus[0];
                  A323PropostaId = P008V7_A323PropostaId[0];
                  n323PropostaId = P008V7_n323PropostaId[0];
                  A571PropostaAssinatura = P008V7_A571PropostaAssinatura[0];
                  n571PropostaAssinatura = P008V7_n571PropostaAssinatura[0];
                  A572PropostaContratoAssinaturaId = P008V7_A572PropostaContratoAssinaturaId[0];
                  A574PropostaAssinaturaStatus = P008V7_A574PropostaAssinaturaStatus[0];
                  n574PropostaAssinaturaStatus = P008V7_n574PropostaAssinaturaStatus[0];
                  AV74GXLvl141 = 1;
                  pr_default.readNext(5);
               }
               pr_default.close(5);
               if ( AV74GXLvl141 == 0 )
               {
                  if ( StringUtil.StrCmp(AV65PropostaContratoAssinaturaTipo, AV60DmTipoContrato) != 0 )
                  {
                     AV57IsTodosAssinados = false;
                  }
               }
               if ( ! AV57IsTodosAssinados )
               {
                  if (true) break;
               }
            }
            AV73GXV2 = (int)(AV73GXV2+1);
         }
         if ( AV57IsTodosAssinados )
         {
            AV59Proposta.Load(AV58PropostaId);
            if ( AV59Proposta.Success() )
            {
               /* Execute user subroutine: 'TITULOS' */
               S131 ();
               if (returnInSub) return;
               AV59Proposta.gxTpr_Propostastatus = "APROVADO";
               AV59Proposta.Save();
            }
         }
      }

      protected void S131( )
      {
         /* 'TITULOS' Routine */
         returnInSub = false;
         AV56IsCriaTitulo = false;
         /* Using cursor P008V8 */
         pr_default.execute(6, new Object[] {AV8AssinaturaId});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A573PropostaContratoAssinaturaTipo = P008V8_A573PropostaContratoAssinaturaTipo[0];
            n573PropostaContratoAssinaturaTipo = P008V8_n573PropostaContratoAssinaturaTipo[0];
            A571PropostaAssinatura = P008V8_A571PropostaAssinatura[0];
            n571PropostaAssinatura = P008V8_n571PropostaAssinatura[0];
            A572PropostaContratoAssinaturaId = P008V8_A572PropostaContratoAssinaturaId[0];
            AV56IsCriaTitulo = true;
            pr_default.readNext(6);
         }
         pr_default.close(6);
         if ( AV56IsCriaTitulo )
         {
            /* Using cursor P008V9 */
            pr_default.execute(7);
            while ( (pr_default.getStatus(7) != 101) )
            {
               A499ContaProposta = P008V9_A499ContaProposta[0];
               n499ContaProposta = P008V9_n499ContaProposta[0];
               A422ContaId = P008V9_A422ContaId[0];
               AV42ContaId = A422ContaId;
               pr_default.readNext(7);
            }
            pr_default.close(7);
            if ( (0==AV42ContaId) )
            {
               /* Using cursor P008V10 */
               pr_default.execute(8);
               while ( (pr_default.getStatus(8) != 101) )
               {
                  A422ContaId = P008V10_A422ContaId[0];
                  AV42ContaId = A422ContaId;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  pr_default.readNext(8);
               }
               pr_default.close(8);
            }
            /* Using cursor P008V11 */
            pr_default.execute(9, new Object[] {AV32ContratoId, AV8AssinaturaId});
            while ( (pr_default.getStatus(9) != 101) )
            {
               A571PropostaAssinatura = P008V11_A571PropostaAssinatura[0];
               n571PropostaAssinatura = P008V11_n571PropostaAssinatura[0];
               A570PropostaContrato = P008V11_A570PropostaContrato[0];
               n570PropostaContrato = P008V11_n570PropostaContrato[0];
               A323PropostaId = P008V11_A323PropostaId[0];
               n323PropostaId = P008V11_n323PropostaId[0];
               A572PropostaContratoAssinaturaId = P008V11_A572PropostaContratoAssinaturaId[0];
               AV58PropostaId = A323PropostaId;
               pr_default.readNext(9);
            }
            pr_default.close(9);
            AV79GXLvl206 = 0;
            /* Using cursor P008V12 */
            pr_default.execute(10, new Object[] {AV58PropostaId});
            while ( (pr_default.getStatus(10) != 101) )
            {
               A323PropostaId = P008V12_A323PropostaId[0];
               n323PropostaId = P008V12_n323PropostaId[0];
               A326PropostaValor = P008V12_A326PropostaValor[0];
               n326PropostaValor = P008V12_n326PropostaValor[0];
               A328PropostaCratedBy = P008V12_A328PropostaCratedBy[0];
               n328PropostaCratedBy = P008V12_n328PropostaCratedBy[0];
               A504PropostaPacienteClienteId = P008V12_A504PropostaPacienteClienteId[0];
               n504PropostaPacienteClienteId = P008V12_n504PropostaPacienteClienteId[0];
               A620PropostaPacienteEnderecoCEP = P008V12_A620PropostaPacienteEnderecoCEP[0];
               n620PropostaPacienteEnderecoCEP = P008V12_n620PropostaPacienteEnderecoCEP[0];
               A621PropostaPacienteEnderecoLogradouro = P008V12_A621PropostaPacienteEnderecoLogradouro[0];
               n621PropostaPacienteEnderecoLogradouro = P008V12_n621PropostaPacienteEnderecoLogradouro[0];
               A622PropostaPacienteEnderecoNumero = P008V12_A622PropostaPacienteEnderecoNumero[0];
               n622PropostaPacienteEnderecoNumero = P008V12_n622PropostaPacienteEnderecoNumero[0];
               A623PropostaPacienteEnderecoComplemento = P008V12_A623PropostaPacienteEnderecoComplemento[0];
               n623PropostaPacienteEnderecoComplemento = P008V12_n623PropostaPacienteEnderecoComplemento[0];
               A624PropostaPacienteEnderecoBairro = P008V12_A624PropostaPacienteEnderecoBairro[0];
               n624PropostaPacienteEnderecoBairro = P008V12_n624PropostaPacienteEnderecoBairro[0];
               A625PropostaPacienteMunicipioCodigo = P008V12_A625PropostaPacienteMunicipioCodigo[0];
               n625PropostaPacienteMunicipioCodigo = P008V12_n625PropostaPacienteMunicipioCodigo[0];
               A620PropostaPacienteEnderecoCEP = P008V12_A620PropostaPacienteEnderecoCEP[0];
               n620PropostaPacienteEnderecoCEP = P008V12_n620PropostaPacienteEnderecoCEP[0];
               A621PropostaPacienteEnderecoLogradouro = P008V12_A621PropostaPacienteEnderecoLogradouro[0];
               n621PropostaPacienteEnderecoLogradouro = P008V12_n621PropostaPacienteEnderecoLogradouro[0];
               A622PropostaPacienteEnderecoNumero = P008V12_A622PropostaPacienteEnderecoNumero[0];
               n622PropostaPacienteEnderecoNumero = P008V12_n622PropostaPacienteEnderecoNumero[0];
               A623PropostaPacienteEnderecoComplemento = P008V12_A623PropostaPacienteEnderecoComplemento[0];
               n623PropostaPacienteEnderecoComplemento = P008V12_n623PropostaPacienteEnderecoComplemento[0];
               A624PropostaPacienteEnderecoBairro = P008V12_A624PropostaPacienteEnderecoBairro[0];
               n624PropostaPacienteEnderecoBairro = P008V12_n624PropostaPacienteEnderecoBairro[0];
               A625PropostaPacienteMunicipioCodigo = P008V12_A625PropostaPacienteMunicipioCodigo[0];
               n625PropostaPacienteMunicipioCodigo = P008V12_n625PropostaPacienteMunicipioCodigo[0];
               AV79GXLvl206 = 1;
               AV33PropostaValor = A326PropostaValor;
               new getclinicatax(context ).execute(  A328PropostaCratedBy, out  AV38ContratoTaxa, out  AV39ContratoSLA, out  AV40ContratoJurosMora, out  AV41ContratoIOFMinimo) ;
               if ( ( AV38ContratoTaxa > Convert.ToDecimal( 0 )) )
               {
                  AV38ContratoTaxa = (decimal)(AV38ContratoTaxa*100);
               }
               AV35Date = DateTimeUtil.ServerDate( context, pr_default);
               AV35Date = DateTimeUtil.DAdd( AV35Date, (AV39ContratoSLA));
               AV35Date = DateTimeUtil.ServerDate( context, pr_default);
               AV34SdTitulo = new SdtSdTitulo(context);
               AV34SdTitulo.gxTpr_Clienteid = A504PropostaPacienteClienteId;
               AV34SdTitulo.gxTpr_Titulovalor = AV33PropostaValor;
               AV34SdTitulo.gxTpr_Titulodesconto = (decimal)(0);
               AV34SdTitulo.gxTpr_Titulodeleted = false;
               AV34SdTitulo.gxTpr_Titulovencimento = AV35Date;
               AV34SdTitulo.gxTpr_Tituloprorrogacao = AV35Date;
               AV34SdTitulo.gxTpr_Titulocep = A620PropostaPacienteEnderecoCEP;
               AV34SdTitulo.gxTpr_Titulologradouro = A621PropostaPacienteEnderecoLogradouro;
               AV34SdTitulo.gxTpr_Titulonumeroendereco = A622PropostaPacienteEnderecoNumero;
               AV34SdTitulo.gxTpr_Titulocomplemento = A623PropostaPacienteEnderecoComplemento;
               AV34SdTitulo.gxTpr_Titulobairro = A624PropostaPacienteEnderecoBairro;
               AV34SdTitulo.gxTpr_Titulomunicipio = A625PropostaPacienteMunicipioCodigo;
               AV34SdTitulo.gxTpr_Titulotipo = "DEBITO";
               AV34SdTitulo.gxTpr_Contaid = AV42ContaId;
               AV34SdTitulo.gxTpr_Titulocompetenciaano = (short)(DateTimeUtil.Year( AV35Date));
               AV34SdTitulo.gxTpr_Titulocompetenciames = (short)(DateTimeUtil.Month( AV35Date));
               AV34SdTitulo.gxTpr_Propostaid = AV58PropostaId;
               AV34SdTitulo.gxTpr_Categoriatituloid = AV67ConfiguracoesCategoriaTitulo;
               new prcriartitulo(context ).execute( ref  AV34SdTitulo, out  AV9SdErro) ;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(10);
            if ( AV79GXLvl206 == 0 )
            {
            }
         }
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV9SdErro = new SdtSdErro(context);
         P008V2_A563ConfiguracaoSenhaPFX = new string[] {""} ;
         P008V2_n563ConfiguracaoSenhaPFX = new bool[] {false} ;
         P008V2_A654ConfiguracoesCategoriaTitulo = new int[1] ;
         P008V2_n654ConfiguracoesCategoriaTitulo = new bool[] {false} ;
         P008V2_A299ConfiguracoesId = new int[1] ;
         P008V2_A562ConfiguracoesArquivoPFX = new string[] {""} ;
         P008V2_n562ConfiguracoesArquivoPFX = new bool[] {false} ;
         A563ConfiguracaoSenhaPFX = "";
         A562ConfiguracoesArquivoPFX = "";
         AV49ConfiguracaoSenhaPFX = "";
         AV50ConfiguracoesArquivoPFX = "";
         P008V3_A231ArquivoId = new int[1] ;
         P008V3_n231ArquivoId = new bool[] {false} ;
         P008V3_A238AssinaturaId = new long[1] ;
         P008V3_n238AssinaturaId = new bool[] {false} ;
         P008V3_A239AssinaturaStatus = new string[] {""} ;
         P008V3_n239AssinaturaStatus = new bool[] {false} ;
         P008V3_A255ArquivoNome = new string[] {""} ;
         P008V3_n255ArquivoNome = new bool[] {false} ;
         P008V3_A254ArquivoExtensao = new string[] {""} ;
         P008V3_n254ArquivoExtensao = new bool[] {false} ;
         P008V3_A366AssinaturaFinalizadoData = new DateTime[] {DateTime.MinValue} ;
         P008V3_n366AssinaturaFinalizadoData = new bool[] {false} ;
         P008V3_A369AssinaturaAno = new short[1] ;
         P008V3_n369AssinaturaAno = new bool[] {false} ;
         P008V3_A368AssinaturaMes = new short[1] ;
         P008V3_n368AssinaturaMes = new bool[] {false} ;
         P008V3_A371AssinaturaMesNome = new string[] {""} ;
         P008V3_n371AssinaturaMesNome = new bool[] {false} ;
         P008V3_A241AssinaturaPublicKey = new Guid[] {Guid.Empty} ;
         P008V3_n241AssinaturaPublicKey = new bool[] {false} ;
         P008V3_A228ContratoNome = new string[] {""} ;
         P008V3_n228ContratoNome = new bool[] {false} ;
         P008V3_A578ArquivoAssinadoId = new int[1] ;
         P008V3_n578ArquivoAssinadoId = new bool[] {false} ;
         P008V3_A365AssinaturaToken = new string[] {""} ;
         P008V3_n365AssinaturaToken = new bool[] {false} ;
         P008V3_A227ContratoId = new int[1] ;
         P008V3_n227ContratoId = new bool[] {false} ;
         P008V3_A232ArquivoBlob = new string[] {""} ;
         P008V3_n232ArquivoBlob = new bool[] {false} ;
         A239AssinaturaStatus = "";
         A255ArquivoNome = "";
         A254ArquivoExtensao = "";
         A366AssinaturaFinalizadoData = (DateTime)(DateTime.MinValue);
         A371AssinaturaMesNome = "";
         A241AssinaturaPublicKey = Guid.Empty;
         A228ContratoNome = "";
         A365AssinaturaToken = "";
         A232ArquivoBlob = "";
         AV31AssinaturaFinalizadoData = (DateTime)(DateTime.MinValue);
         AV11Array_SdParticipantesContrato = new GXBaseCollection<SdtSdParticipantesContrato>( context, "SdParticipantesContrato", "Factory21");
         P008V4_A233ParticipanteId = new int[1] ;
         P008V4_n233ParticipanteId = new bool[] {false} ;
         P008V4_A238AssinaturaId = new long[1] ;
         P008V4_n238AssinaturaId = new bool[] {false} ;
         P008V4_A248ParticipanteNome = new string[] {""} ;
         P008V4_n248ParticipanteNome = new bool[] {false} ;
         P008V4_A235ParticipanteEmail = new string[] {""} ;
         P008V4_n235ParticipanteEmail = new bool[] {false} ;
         P008V4_A350AssinaturaParticipanteCPF = new string[] {""} ;
         P008V4_n350AssinaturaParticipanteCPF = new bool[] {false} ;
         P008V4_A352AssinaturaParticipanteNascimento = new DateTime[] {DateTime.MinValue} ;
         P008V4_n352AssinaturaParticipanteNascimento = new bool[] {false} ;
         P008V4_A245AssinaturaParticipanteDataConclusao = new DateTime[] {DateTime.MinValue} ;
         P008V4_n245AssinaturaParticipanteDataConclusao = new bool[] {false} ;
         P008V4_A246AssinaturaParticipanteKey = new Guid[] {Guid.Empty} ;
         P008V4_n246AssinaturaParticipanteKey = new bool[] {false} ;
         P008V4_A346AssinaturaParticipanteRemoteAddres = new string[] {""} ;
         P008V4_n346AssinaturaParticipanteRemoteAddres = new bool[] {false} ;
         P008V4_A347AssinaturaParticipanteGeolocalizacao = new string[] {""} ;
         P008V4_n347AssinaturaParticipanteGeolocalizacao = new bool[] {false} ;
         P008V4_A348AssinaturaParticipanteDispositivo = new string[] {""} ;
         P008V4_n348AssinaturaParticipanteDispositivo = new bool[] {false} ;
         P008V4_A1002ParticipanteRepresentanteNome = new string[] {""} ;
         P008V4_n1002ParticipanteRepresentanteNome = new bool[] {false} ;
         P008V4_A1003ParticipanteRepresentanteEmail = new string[] {""} ;
         P008V4_n1003ParticipanteRepresentanteEmail = new bool[] {false} ;
         P008V4_A1004ParticipanteRepresentanteDocumento = new string[] {""} ;
         P008V4_n1004ParticipanteRepresentanteDocumento = new bool[] {false} ;
         P008V4_A242AssinaturaParticipanteId = new int[1] ;
         A248ParticipanteNome = "";
         A235ParticipanteEmail = "";
         A350AssinaturaParticipanteCPF = "";
         A352AssinaturaParticipanteNascimento = DateTime.MinValue;
         A245AssinaturaParticipanteDataConclusao = (DateTime)(DateTime.MinValue);
         A246AssinaturaParticipanteKey = Guid.Empty;
         A346AssinaturaParticipanteRemoteAddres = "";
         A347AssinaturaParticipanteGeolocalizacao = "";
         A348AssinaturaParticipanteDispositivo = "";
         A1002ParticipanteRepresentanteNome = "";
         A1003ParticipanteRepresentanteEmail = "";
         A1004ParticipanteRepresentanteDocumento = "";
         AV12SdParticipantesContrato = new SdtSdParticipantesContrato(context);
         AV17ArquivoBlob = "";
         AV18AssinaturaPublicKey = Guid.Empty;
         AV13HTML = "";
         AV44PdfOriginalFile = new GxFile(context.GetPhysicalPath());
         AV45GUID = Guid.Empty;
         AV46Source = "";
         AV47PdfOrigemFile = new GxFile(context.GetPhysicalPath());
         AV48PDFService = new SdtPdfService(context);
         AV51CertificadoFIle = new GxFile(context.GetPhysicalPath());
         AV52PdfHistoricoCertificadoFile = new GxFile(context.GetPhysicalPath());
         AV53result = "";
         AV55DigitalSignatureUtil = new SdtDigitalSignatureUtil(context);
         AV54Blob = "";
         AV64Arquivo = new SdtArquivo(context);
         AV27checksum = "";
         AV28ChecksumCreator = new GeneXus.Programs.genexuscryptography.SdtChecksumCreator(context);
         AV29Chave = "";
         GXt_char1 = "";
         AV43Contrato = new SdtContrato(context);
         AV61ContratoNome = "";
         AV62Link = "";
         P008V6_A571PropostaAssinatura = new long[1] ;
         P008V6_n571PropostaAssinatura = new bool[] {false} ;
         P008V6_A323PropostaId = new int[1] ;
         P008V6_n323PropostaId = new bool[] {false} ;
         P008V6_A573PropostaContratoAssinaturaTipo = new string[] {""} ;
         P008V6_n573PropostaContratoAssinaturaTipo = new bool[] {false} ;
         P008V6_A572PropostaContratoAssinaturaId = new int[1] ;
         A573PropostaContratoAssinaturaTipo = "";
         AV65PropostaContratoAssinaturaTipo = "";
         AV72GXV1 = new GxSimpleCollection<string>();
         AV60DmTipoContrato = "";
         P008V7_A573PropostaContratoAssinaturaTipo = new string[] {""} ;
         P008V7_n573PropostaContratoAssinaturaTipo = new bool[] {false} ;
         P008V7_A574PropostaAssinaturaStatus = new string[] {""} ;
         P008V7_n574PropostaAssinaturaStatus = new bool[] {false} ;
         P008V7_A323PropostaId = new int[1] ;
         P008V7_n323PropostaId = new bool[] {false} ;
         P008V7_A571PropostaAssinatura = new long[1] ;
         P008V7_n571PropostaAssinatura = new bool[] {false} ;
         P008V7_A572PropostaContratoAssinaturaId = new int[1] ;
         A574PropostaAssinaturaStatus = "";
         AV59Proposta = new SdtProposta(context);
         P008V8_A573PropostaContratoAssinaturaTipo = new string[] {""} ;
         P008V8_n573PropostaContratoAssinaturaTipo = new bool[] {false} ;
         P008V8_A571PropostaAssinatura = new long[1] ;
         P008V8_n571PropostaAssinatura = new bool[] {false} ;
         P008V8_A572PropostaContratoAssinaturaId = new int[1] ;
         P008V9_A499ContaProposta = new bool[] {false} ;
         P008V9_n499ContaProposta = new bool[] {false} ;
         P008V9_A422ContaId = new int[1] ;
         P008V10_A422ContaId = new int[1] ;
         P008V11_A571PropostaAssinatura = new long[1] ;
         P008V11_n571PropostaAssinatura = new bool[] {false} ;
         P008V11_A570PropostaContrato = new int[1] ;
         P008V11_n570PropostaContrato = new bool[] {false} ;
         P008V11_A323PropostaId = new int[1] ;
         P008V11_n323PropostaId = new bool[] {false} ;
         P008V11_A572PropostaContratoAssinaturaId = new int[1] ;
         P008V12_A323PropostaId = new int[1] ;
         P008V12_n323PropostaId = new bool[] {false} ;
         P008V12_A326PropostaValor = new decimal[1] ;
         P008V12_n326PropostaValor = new bool[] {false} ;
         P008V12_A328PropostaCratedBy = new short[1] ;
         P008V12_n328PropostaCratedBy = new bool[] {false} ;
         P008V12_A504PropostaPacienteClienteId = new int[1] ;
         P008V12_n504PropostaPacienteClienteId = new bool[] {false} ;
         P008V12_A620PropostaPacienteEnderecoCEP = new string[] {""} ;
         P008V12_n620PropostaPacienteEnderecoCEP = new bool[] {false} ;
         P008V12_A621PropostaPacienteEnderecoLogradouro = new string[] {""} ;
         P008V12_n621PropostaPacienteEnderecoLogradouro = new bool[] {false} ;
         P008V12_A622PropostaPacienteEnderecoNumero = new string[] {""} ;
         P008V12_n622PropostaPacienteEnderecoNumero = new bool[] {false} ;
         P008V12_A623PropostaPacienteEnderecoComplemento = new string[] {""} ;
         P008V12_n623PropostaPacienteEnderecoComplemento = new bool[] {false} ;
         P008V12_A624PropostaPacienteEnderecoBairro = new string[] {""} ;
         P008V12_n624PropostaPacienteEnderecoBairro = new bool[] {false} ;
         P008V12_A625PropostaPacienteMunicipioCodigo = new string[] {""} ;
         P008V12_n625PropostaPacienteMunicipioCodigo = new bool[] {false} ;
         A620PropostaPacienteEnderecoCEP = "";
         A621PropostaPacienteEnderecoLogradouro = "";
         A622PropostaPacienteEnderecoNumero = "";
         A623PropostaPacienteEnderecoComplemento = "";
         A624PropostaPacienteEnderecoBairro = "";
         A625PropostaPacienteMunicipioCodigo = "";
         AV35Date = DateTime.MinValue;
         AV34SdTitulo = new SdtSdTitulo(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprfinalizarcontrato__default(),
            new Object[][] {
                new Object[] {
               P008V2_A563ConfiguracaoSenhaPFX, P008V2_n563ConfiguracaoSenhaPFX, P008V2_A654ConfiguracoesCategoriaTitulo, P008V2_n654ConfiguracoesCategoriaTitulo, P008V2_A299ConfiguracoesId, P008V2_A562ConfiguracoesArquivoPFX, P008V2_n562ConfiguracoesArquivoPFX
               }
               , new Object[] {
               P008V3_A231ArquivoId, P008V3_n231ArquivoId, P008V3_A238AssinaturaId, P008V3_A239AssinaturaStatus, P008V3_n239AssinaturaStatus, P008V3_A255ArquivoNome, P008V3_n255ArquivoNome, P008V3_A254ArquivoExtensao, P008V3_n254ArquivoExtensao, P008V3_A366AssinaturaFinalizadoData,
               P008V3_n366AssinaturaFinalizadoData, P008V3_A369AssinaturaAno, P008V3_n369AssinaturaAno, P008V3_A368AssinaturaMes, P008V3_n368AssinaturaMes, P008V3_A371AssinaturaMesNome, P008V3_n371AssinaturaMesNome, P008V3_A241AssinaturaPublicKey, P008V3_n241AssinaturaPublicKey, P008V3_A228ContratoNome,
               P008V3_n228ContratoNome, P008V3_A578ArquivoAssinadoId, P008V3_n578ArquivoAssinadoId, P008V3_A365AssinaturaToken, P008V3_n365AssinaturaToken, P008V3_A227ContratoId, P008V3_n227ContratoId, P008V3_A232ArquivoBlob, P008V3_n232ArquivoBlob
               }
               , new Object[] {
               P008V4_A233ParticipanteId, P008V4_n233ParticipanteId, P008V4_A238AssinaturaId, P008V4_n238AssinaturaId, P008V4_A248ParticipanteNome, P008V4_n248ParticipanteNome, P008V4_A235ParticipanteEmail, P008V4_n235ParticipanteEmail, P008V4_A350AssinaturaParticipanteCPF, P008V4_n350AssinaturaParticipanteCPF,
               P008V4_A352AssinaturaParticipanteNascimento, P008V4_n352AssinaturaParticipanteNascimento, P008V4_A245AssinaturaParticipanteDataConclusao, P008V4_n245AssinaturaParticipanteDataConclusao, P008V4_A246AssinaturaParticipanteKey, P008V4_n246AssinaturaParticipanteKey, P008V4_A346AssinaturaParticipanteRemoteAddres, P008V4_n346AssinaturaParticipanteRemoteAddres, P008V4_A347AssinaturaParticipanteGeolocalizacao, P008V4_n347AssinaturaParticipanteGeolocalizacao,
               P008V4_A348AssinaturaParticipanteDispositivo, P008V4_n348AssinaturaParticipanteDispositivo, P008V4_A1002ParticipanteRepresentanteNome, P008V4_n1002ParticipanteRepresentanteNome, P008V4_A1003ParticipanteRepresentanteEmail, P008V4_n1003ParticipanteRepresentanteEmail, P008V4_A1004ParticipanteRepresentanteDocumento, P008V4_n1004ParticipanteRepresentanteDocumento, P008V4_A242AssinaturaParticipanteId
               }
               , new Object[] {
               }
               , new Object[] {
               P008V6_A571PropostaAssinatura, P008V6_n571PropostaAssinatura, P008V6_A323PropostaId, P008V6_n323PropostaId, P008V6_A573PropostaContratoAssinaturaTipo, P008V6_n573PropostaContratoAssinaturaTipo, P008V6_A572PropostaContratoAssinaturaId
               }
               , new Object[] {
               P008V7_A573PropostaContratoAssinaturaTipo, P008V7_n573PropostaContratoAssinaturaTipo, P008V7_A574PropostaAssinaturaStatus, P008V7_n574PropostaAssinaturaStatus, P008V7_A323PropostaId, P008V7_n323PropostaId, P008V7_A571PropostaAssinatura, P008V7_n571PropostaAssinatura, P008V7_A572PropostaContratoAssinaturaId
               }
               , new Object[] {
               P008V8_A573PropostaContratoAssinaturaTipo, P008V8_n573PropostaContratoAssinaturaTipo, P008V8_A571PropostaAssinatura, P008V8_n571PropostaAssinatura, P008V8_A572PropostaContratoAssinaturaId
               }
               , new Object[] {
               P008V9_A499ContaProposta, P008V9_n499ContaProposta, P008V9_A422ContaId
               }
               , new Object[] {
               P008V10_A422ContaId
               }
               , new Object[] {
               P008V11_A571PropostaAssinatura, P008V11_n571PropostaAssinatura, P008V11_A570PropostaContrato, P008V11_n570PropostaContrato, P008V11_A323PropostaId, P008V11_n323PropostaId, P008V11_A572PropostaContratoAssinaturaId
               }
               , new Object[] {
               P008V12_A323PropostaId, P008V12_A326PropostaValor, P008V12_n326PropostaValor, P008V12_A328PropostaCratedBy, P008V12_n328PropostaCratedBy, P008V12_A504PropostaPacienteClienteId, P008V12_n504PropostaPacienteClienteId, P008V12_A620PropostaPacienteEnderecoCEP, P008V12_n620PropostaPacienteEnderecoCEP, P008V12_A621PropostaPacienteEnderecoLogradouro,
               P008V12_n621PropostaPacienteEnderecoLogradouro, P008V12_A622PropostaPacienteEnderecoNumero, P008V12_n622PropostaPacienteEnderecoNumero, P008V12_A623PropostaPacienteEnderecoComplemento, P008V12_n623PropostaPacienteEnderecoComplemento, P008V12_A624PropostaPacienteEnderecoBairro, P008V12_n624PropostaPacienteEnderecoBairro, P008V12_A625PropostaPacienteMunicipioCodigo, P008V12_n625PropostaPacienteMunicipioCodigo
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A369AssinaturaAno ;
      private short A368AssinaturaMes ;
      private short AV74GXLvl141 ;
      private short AV79GXLvl206 ;
      private short A328PropostaCratedBy ;
      private short AV39ContratoSLA ;
      private int A654ConfiguracoesCategoriaTitulo ;
      private int A299ConfiguracoesId ;
      private int AV67ConfiguracoesCategoriaTitulo ;
      private int A231ArquivoId ;
      private int A578ArquivoAssinadoId ;
      private int A227ContratoId ;
      private int A233ParticipanteId ;
      private int A242AssinaturaParticipanteId ;
      private int AV32ContratoId ;
      private int A323PropostaId ;
      private int A572PropostaContratoAssinaturaId ;
      private int AV58PropostaId ;
      private int AV73GXV2 ;
      private int A422ContaId ;
      private int AV42ContaId ;
      private int A570PropostaContrato ;
      private int A504PropostaPacienteClienteId ;
      private long AV8AssinaturaId ;
      private long A238AssinaturaId ;
      private long A571PropostaAssinatura ;
      private decimal A326PropostaValor ;
      private decimal AV33PropostaValor ;
      private decimal AV38ContratoTaxa ;
      private decimal AV40ContratoJurosMora ;
      private decimal AV41ContratoIOFMinimo ;
      private string GXt_char1 ;
      private DateTime A366AssinaturaFinalizadoData ;
      private DateTime AV31AssinaturaFinalizadoData ;
      private DateTime A245AssinaturaParticipanteDataConclusao ;
      private DateTime A352AssinaturaParticipanteNascimento ;
      private DateTime AV35Date ;
      private bool n563ConfiguracaoSenhaPFX ;
      private bool n654ConfiguracoesCategoriaTitulo ;
      private bool n562ConfiguracoesArquivoPFX ;
      private bool n231ArquivoId ;
      private bool n238AssinaturaId ;
      private bool n239AssinaturaStatus ;
      private bool n255ArquivoNome ;
      private bool n254ArquivoExtensao ;
      private bool n366AssinaturaFinalizadoData ;
      private bool n369AssinaturaAno ;
      private bool n368AssinaturaMes ;
      private bool n371AssinaturaMesNome ;
      private bool n241AssinaturaPublicKey ;
      private bool n228ContratoNome ;
      private bool n578ArquivoAssinadoId ;
      private bool n365AssinaturaToken ;
      private bool n227ContratoId ;
      private bool n232ArquivoBlob ;
      private bool n233ParticipanteId ;
      private bool n248ParticipanteNome ;
      private bool n235ParticipanteEmail ;
      private bool n350AssinaturaParticipanteCPF ;
      private bool n352AssinaturaParticipanteNascimento ;
      private bool n245AssinaturaParticipanteDataConclusao ;
      private bool n246AssinaturaParticipanteKey ;
      private bool n346AssinaturaParticipanteRemoteAddres ;
      private bool n347AssinaturaParticipanteGeolocalizacao ;
      private bool n348AssinaturaParticipanteDispositivo ;
      private bool n1002ParticipanteRepresentanteNome ;
      private bool n1003ParticipanteRepresentanteEmail ;
      private bool n1004ParticipanteRepresentanteDocumento ;
      private bool returnInSub ;
      private bool n571PropostaAssinatura ;
      private bool n323PropostaId ;
      private bool n573PropostaContratoAssinaturaTipo ;
      private bool AV57IsTodosAssinados ;
      private bool n574PropostaAssinaturaStatus ;
      private bool AV56IsCriaTitulo ;
      private bool A499ContaProposta ;
      private bool n499ContaProposta ;
      private bool n570PropostaContrato ;
      private bool n326PropostaValor ;
      private bool n328PropostaCratedBy ;
      private bool n504PropostaPacienteClienteId ;
      private bool n620PropostaPacienteEnderecoCEP ;
      private bool n621PropostaPacienteEnderecoLogradouro ;
      private bool n622PropostaPacienteEnderecoNumero ;
      private bool n623PropostaPacienteEnderecoComplemento ;
      private bool n624PropostaPacienteEnderecoBairro ;
      private bool n625PropostaPacienteMunicipioCodigo ;
      private string AV13HTML ;
      private string AV63BaseUrl ;
      private string A563ConfiguracaoSenhaPFX ;
      private string AV49ConfiguracaoSenhaPFX ;
      private string A239AssinaturaStatus ;
      private string A255ArquivoNome ;
      private string A254ArquivoExtensao ;
      private string A371AssinaturaMesNome ;
      private string A228ContratoNome ;
      private string A365AssinaturaToken ;
      private string A248ParticipanteNome ;
      private string A235ParticipanteEmail ;
      private string A350AssinaturaParticipanteCPF ;
      private string A346AssinaturaParticipanteRemoteAddres ;
      private string A347AssinaturaParticipanteGeolocalizacao ;
      private string A348AssinaturaParticipanteDispositivo ;
      private string A1002ParticipanteRepresentanteNome ;
      private string A1003ParticipanteRepresentanteEmail ;
      private string A1004ParticipanteRepresentanteDocumento ;
      private string AV46Source ;
      private string AV53result ;
      private string AV27checksum ;
      private string AV29Chave ;
      private string AV61ContratoNome ;
      private string AV62Link ;
      private string A573PropostaContratoAssinaturaTipo ;
      private string AV65PropostaContratoAssinaturaTipo ;
      private string AV60DmTipoContrato ;
      private string A574PropostaAssinaturaStatus ;
      private string A620PropostaPacienteEnderecoCEP ;
      private string A621PropostaPacienteEnderecoLogradouro ;
      private string A622PropostaPacienteEnderecoNumero ;
      private string A623PropostaPacienteEnderecoComplemento ;
      private string A624PropostaPacienteEnderecoBairro ;
      private string A625PropostaPacienteMunicipioCodigo ;
      private Guid A241AssinaturaPublicKey ;
      private Guid A246AssinaturaParticipanteKey ;
      private Guid AV18AssinaturaPublicKey ;
      private Guid AV45GUID ;
      private string A562ConfiguracoesArquivoPFX ;
      private string AV50ConfiguracoesArquivoPFX ;
      private string A232ArquivoBlob ;
      private string AV17ArquivoBlob ;
      private string AV54Blob ;
      private GxFile AV44PdfOriginalFile ;
      private GxFile AV47PdfOrigemFile ;
      private GxFile AV51CertificadoFIle ;
      private GxFile AV52PdfHistoricoCertificadoFile ;
      private IGxDataStore dsDefault ;
      private SdtSdErro AV9SdErro ;
      private IDataStoreProvider pr_default ;
      private string[] P008V2_A563ConfiguracaoSenhaPFX ;
      private bool[] P008V2_n563ConfiguracaoSenhaPFX ;
      private int[] P008V2_A654ConfiguracoesCategoriaTitulo ;
      private bool[] P008V2_n654ConfiguracoesCategoriaTitulo ;
      private int[] P008V2_A299ConfiguracoesId ;
      private string[] P008V2_A562ConfiguracoesArquivoPFX ;
      private bool[] P008V2_n562ConfiguracoesArquivoPFX ;
      private int[] P008V3_A231ArquivoId ;
      private bool[] P008V3_n231ArquivoId ;
      private long[] P008V3_A238AssinaturaId ;
      private bool[] P008V3_n238AssinaturaId ;
      private string[] P008V3_A239AssinaturaStatus ;
      private bool[] P008V3_n239AssinaturaStatus ;
      private string[] P008V3_A255ArquivoNome ;
      private bool[] P008V3_n255ArquivoNome ;
      private string[] P008V3_A254ArquivoExtensao ;
      private bool[] P008V3_n254ArquivoExtensao ;
      private DateTime[] P008V3_A366AssinaturaFinalizadoData ;
      private bool[] P008V3_n366AssinaturaFinalizadoData ;
      private short[] P008V3_A369AssinaturaAno ;
      private bool[] P008V3_n369AssinaturaAno ;
      private short[] P008V3_A368AssinaturaMes ;
      private bool[] P008V3_n368AssinaturaMes ;
      private string[] P008V3_A371AssinaturaMesNome ;
      private bool[] P008V3_n371AssinaturaMesNome ;
      private Guid[] P008V3_A241AssinaturaPublicKey ;
      private bool[] P008V3_n241AssinaturaPublicKey ;
      private string[] P008V3_A228ContratoNome ;
      private bool[] P008V3_n228ContratoNome ;
      private int[] P008V3_A578ArquivoAssinadoId ;
      private bool[] P008V3_n578ArquivoAssinadoId ;
      private string[] P008V3_A365AssinaturaToken ;
      private bool[] P008V3_n365AssinaturaToken ;
      private int[] P008V3_A227ContratoId ;
      private bool[] P008V3_n227ContratoId ;
      private string[] P008V3_A232ArquivoBlob ;
      private bool[] P008V3_n232ArquivoBlob ;
      private GXBaseCollection<SdtSdParticipantesContrato> AV11Array_SdParticipantesContrato ;
      private int[] P008V4_A233ParticipanteId ;
      private bool[] P008V4_n233ParticipanteId ;
      private long[] P008V4_A238AssinaturaId ;
      private bool[] P008V4_n238AssinaturaId ;
      private string[] P008V4_A248ParticipanteNome ;
      private bool[] P008V4_n248ParticipanteNome ;
      private string[] P008V4_A235ParticipanteEmail ;
      private bool[] P008V4_n235ParticipanteEmail ;
      private string[] P008V4_A350AssinaturaParticipanteCPF ;
      private bool[] P008V4_n350AssinaturaParticipanteCPF ;
      private DateTime[] P008V4_A352AssinaturaParticipanteNascimento ;
      private bool[] P008V4_n352AssinaturaParticipanteNascimento ;
      private DateTime[] P008V4_A245AssinaturaParticipanteDataConclusao ;
      private bool[] P008V4_n245AssinaturaParticipanteDataConclusao ;
      private Guid[] P008V4_A246AssinaturaParticipanteKey ;
      private bool[] P008V4_n246AssinaturaParticipanteKey ;
      private string[] P008V4_A346AssinaturaParticipanteRemoteAddres ;
      private bool[] P008V4_n346AssinaturaParticipanteRemoteAddres ;
      private string[] P008V4_A347AssinaturaParticipanteGeolocalizacao ;
      private bool[] P008V4_n347AssinaturaParticipanteGeolocalizacao ;
      private string[] P008V4_A348AssinaturaParticipanteDispositivo ;
      private bool[] P008V4_n348AssinaturaParticipanteDispositivo ;
      private string[] P008V4_A1002ParticipanteRepresentanteNome ;
      private bool[] P008V4_n1002ParticipanteRepresentanteNome ;
      private string[] P008V4_A1003ParticipanteRepresentanteEmail ;
      private bool[] P008V4_n1003ParticipanteRepresentanteEmail ;
      private string[] P008V4_A1004ParticipanteRepresentanteDocumento ;
      private bool[] P008V4_n1004ParticipanteRepresentanteDocumento ;
      private int[] P008V4_A242AssinaturaParticipanteId ;
      private SdtSdParticipantesContrato AV12SdParticipantesContrato ;
      private SdtPdfService AV48PDFService ;
      private SdtDigitalSignatureUtil AV55DigitalSignatureUtil ;
      private SdtArquivo AV64Arquivo ;
      private GeneXus.Programs.genexuscryptography.SdtChecksumCreator AV28ChecksumCreator ;
      private SdtContrato AV43Contrato ;
      private long[] P008V6_A571PropostaAssinatura ;
      private bool[] P008V6_n571PropostaAssinatura ;
      private int[] P008V6_A323PropostaId ;
      private bool[] P008V6_n323PropostaId ;
      private string[] P008V6_A573PropostaContratoAssinaturaTipo ;
      private bool[] P008V6_n573PropostaContratoAssinaturaTipo ;
      private int[] P008V6_A572PropostaContratoAssinaturaId ;
      private GxSimpleCollection<string> AV72GXV1 ;
      private string[] P008V7_A573PropostaContratoAssinaturaTipo ;
      private bool[] P008V7_n573PropostaContratoAssinaturaTipo ;
      private string[] P008V7_A574PropostaAssinaturaStatus ;
      private bool[] P008V7_n574PropostaAssinaturaStatus ;
      private int[] P008V7_A323PropostaId ;
      private bool[] P008V7_n323PropostaId ;
      private long[] P008V7_A571PropostaAssinatura ;
      private bool[] P008V7_n571PropostaAssinatura ;
      private int[] P008V7_A572PropostaContratoAssinaturaId ;
      private SdtProposta AV59Proposta ;
      private string[] P008V8_A573PropostaContratoAssinaturaTipo ;
      private bool[] P008V8_n573PropostaContratoAssinaturaTipo ;
      private long[] P008V8_A571PropostaAssinatura ;
      private bool[] P008V8_n571PropostaAssinatura ;
      private int[] P008V8_A572PropostaContratoAssinaturaId ;
      private bool[] P008V9_A499ContaProposta ;
      private bool[] P008V9_n499ContaProposta ;
      private int[] P008V9_A422ContaId ;
      private int[] P008V10_A422ContaId ;
      private long[] P008V11_A571PropostaAssinatura ;
      private bool[] P008V11_n571PropostaAssinatura ;
      private int[] P008V11_A570PropostaContrato ;
      private bool[] P008V11_n570PropostaContrato ;
      private int[] P008V11_A323PropostaId ;
      private bool[] P008V11_n323PropostaId ;
      private int[] P008V11_A572PropostaContratoAssinaturaId ;
      private int[] P008V12_A323PropostaId ;
      private bool[] P008V12_n323PropostaId ;
      private decimal[] P008V12_A326PropostaValor ;
      private bool[] P008V12_n326PropostaValor ;
      private short[] P008V12_A328PropostaCratedBy ;
      private bool[] P008V12_n328PropostaCratedBy ;
      private int[] P008V12_A504PropostaPacienteClienteId ;
      private bool[] P008V12_n504PropostaPacienteClienteId ;
      private string[] P008V12_A620PropostaPacienteEnderecoCEP ;
      private bool[] P008V12_n620PropostaPacienteEnderecoCEP ;
      private string[] P008V12_A621PropostaPacienteEnderecoLogradouro ;
      private bool[] P008V12_n621PropostaPacienteEnderecoLogradouro ;
      private string[] P008V12_A622PropostaPacienteEnderecoNumero ;
      private bool[] P008V12_n622PropostaPacienteEnderecoNumero ;
      private string[] P008V12_A623PropostaPacienteEnderecoComplemento ;
      private bool[] P008V12_n623PropostaPacienteEnderecoComplemento ;
      private string[] P008V12_A624PropostaPacienteEnderecoBairro ;
      private bool[] P008V12_n624PropostaPacienteEnderecoBairro ;
      private string[] P008V12_A625PropostaPacienteMunicipioCodigo ;
      private bool[] P008V12_n625PropostaPacienteMunicipioCodigo ;
      private SdtSdTitulo AV34SdTitulo ;
      private SdtSdErro aP2_SdErro ;
   }

   public class aprfinalizarcontrato__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new UpdateCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP008V2;
          prmP008V2 = new Object[] {
          };
          Object[] prmP008V3;
          prmP008V3 = new Object[] {
          new ParDef("AV8AssinaturaId",GXType.Int64,10,0)
          };
          Object[] prmP008V4;
          prmP008V4 = new Object[] {
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmP008V5;
          prmP008V5 = new Object[] {
          new ParDef("AssinaturaStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaFinalizadoData",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("AssinaturaAno",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("AssinaturaMes",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("AssinaturaMesNome",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ArquivoAssinadoId",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("AssinaturaToken",GXType.VarChar,512,0){Nullable=true} ,
          new ParDef("AssinaturaId",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmP008V6;
          prmP008V6 = new Object[] {
          new ParDef("AV8AssinaturaId",GXType.Int64,10,0)
          };
          Object[] prmP008V7;
          prmP008V7 = new Object[] {
          new ParDef("AV58PropostaId",GXType.Int32,9,0) ,
          new ParDef("AV60DmTipoContrato",GXType.VarChar,60,0)
          };
          Object[] prmP008V8;
          prmP008V8 = new Object[] {
          new ParDef("AV8AssinaturaId",GXType.Int64,10,0)
          };
          Object[] prmP008V9;
          prmP008V9 = new Object[] {
          };
          Object[] prmP008V10;
          prmP008V10 = new Object[] {
          };
          Object[] prmP008V11;
          prmP008V11 = new Object[] {
          new ParDef("AV32ContratoId",GXType.Int32,6,0) ,
          new ParDef("AV8AssinaturaId",GXType.Int64,10,0)
          };
          Object[] prmP008V12;
          prmP008V12 = new Object[] {
          new ParDef("AV58PropostaId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008V2", "SELECT ConfiguracaoSenhaPFX, ConfiguracoesCategoriaTitulo, ConfiguracoesId, ConfiguracoesArquivoPFX FROM Configuracoes ORDER BY ConfiguracoesId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008V2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008V3", "SELECT T1.ArquivoId, T1.AssinaturaId, T1.AssinaturaStatus, T2.ArquivoNome, T2.ArquivoExtensao, T1.AssinaturaFinalizadoData, T1.AssinaturaAno, T1.AssinaturaMes, T1.AssinaturaMesNome, T1.AssinaturaPublicKey, T3.ContratoNome, T1.ArquivoAssinadoId, T1.AssinaturaToken, T1.ContratoId, T2.ArquivoBlob FROM ((Assinatura T1 LEFT JOIN Arquivo T2 ON T2.ArquivoId = T1.ArquivoId) LEFT JOIN Contrato T3 ON T3.ContratoId = T1.ContratoId) WHERE (T1.AssinaturaId = :AV8AssinaturaId) AND (T1.AssinaturaStatus <> ( 'ASSINADO')) ORDER BY T1.AssinaturaId  FOR UPDATE OF T1, T1, T1",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008V3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P008V4", "SELECT T1.ParticipanteId, T1.AssinaturaId, T2.ParticipanteNome, T2.ParticipanteEmail, T1.AssinaturaParticipanteCPF, T1.AssinaturaParticipanteNascimento, T1.AssinaturaParticipanteDataConclusao, T1.AssinaturaParticipanteKey, T1.AssinaturaParticipanteRemoteAddres, T1.AssinaturaParticipanteGeolocalizacao, T1.AssinaturaParticipanteDispositivo, T2.ParticipanteRepresentanteNome, T2.ParticipanteRepresentanteEmail, T2.ParticipanteRepresentanteDocumento, T1.AssinaturaParticipanteId FROM (AssinaturaParticipante T1 LEFT JOIN Participante T2 ON T2.ParticipanteId = T1.ParticipanteId) WHERE T1.AssinaturaId = :AssinaturaId ORDER BY T1.AssinaturaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008V4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008V5", "SAVEPOINT gxupdate;UPDATE Assinatura SET AssinaturaStatus=:AssinaturaStatus, AssinaturaFinalizadoData=:AssinaturaFinalizadoData, AssinaturaAno=:AssinaturaAno, AssinaturaMes=:AssinaturaMes, AssinaturaMesNome=:AssinaturaMesNome, ArquivoAssinadoId=:ArquivoAssinadoId, AssinaturaToken=:AssinaturaToken  WHERE AssinaturaId = :AssinaturaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP008V5)
             ,new CursorDef("P008V6", "SELECT PropostaAssinatura, PropostaId, PropostaContratoAssinaturaTipo, PropostaContratoAssinaturaId FROM PropostaContratoAssinatura WHERE PropostaAssinatura = :AV8AssinaturaId ORDER BY PropostaAssinatura ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008V6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008V7", "SELECT T1.PropostaContratoAssinaturaTipo, T2.AssinaturaStatus AS PropostaAssinaturaStatus, T1.PropostaId, T1.PropostaAssinatura AS PropostaAssinatura, T1.PropostaContratoAssinaturaId FROM (PropostaContratoAssinatura T1 LEFT JOIN Assinatura T2 ON T2.AssinaturaId = T1.PropostaAssinatura) WHERE (T1.PropostaId = :AV58PropostaId) AND (T2.AssinaturaStatus = ( 'ASSINADO')) AND (T1.PropostaContratoAssinaturaTipo = ( :AV60DmTipoContrato)) ORDER BY T1.PropostaAssinatura ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008V7,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008V8", "SELECT PropostaContratoAssinaturaTipo, PropostaAssinatura, PropostaContratoAssinaturaId FROM PropostaContratoAssinatura WHERE (PropostaAssinatura = :AV8AssinaturaId) AND (PropostaContratoAssinaturaTipo = ( 'Contrato')) ORDER BY PropostaAssinatura ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008V8,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008V9", "SELECT ContaProposta, ContaId FROM Conta WHERE ContaProposta ORDER BY ContaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008V9,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008V10", "SELECT ContaId FROM Conta ORDER BY ContaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008V10,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008V11", "SELECT PropostaAssinatura, PropostaContrato, PropostaId, PropostaContratoAssinaturaId FROM PropostaContratoAssinatura WHERE (PropostaContrato = :AV32ContratoId) AND (PropostaAssinatura = :AV8AssinaturaId) ORDER BY PropostaContrato ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008V11,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008V12", "SELECT T1.PropostaId, T1.PropostaValor, T1.PropostaCratedBy, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T2.EnderecoCEP AS PropostaPacienteEnderecoCEP, T2.EnderecoLogradouro AS PropostaPacienteEnderecoLogradouro, T2.EnderecoNumero AS PropostaPacienteEnderecoNumero, T2.EnderecoComplemento AS PropostaPacienteEnderecoComplemento, T2.EnderecoBairro AS PropostaPacienteEnderecoBairro, T2.MunicipioCodigo AS PropostaPacienteMunicipioCodigo FROM (Proposta T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.PropostaPacienteClienteId) WHERE T1.PropostaId = :AV58PropostaId ORDER BY T1.PropostaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008V12,1, GxCacheFrequency.OFF ,true,true )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((string[]) buf[5])[0] = rslt.getBLOBFile(4, "tmp", "");
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((Guid[]) buf[17])[0] = rslt.getGuid(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((int[]) buf[25])[0] = rslt.getInt(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getBLOBFile(15, rslt.getVarchar(5), rslt.getVarchar(4));
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((Guid[]) buf[14])[0] = rslt.getGuid(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((int[]) buf[28])[0] = rslt.getInt(15);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((long[]) buf[6])[0] = rslt.getLong(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                return;
             case 7 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                return;
       }
    }

 }

}
