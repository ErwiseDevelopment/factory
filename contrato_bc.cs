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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class contrato_bc : GxSilentTrn, IGxSilentTrn
   {
      public contrato_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public contrato_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow0X36( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0X36( ) ;
         standaloneModal( ) ;
         AddRow0X36( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E110X2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z227ContratoId = A227ContratoId;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_0X0( )
      {
         BeforeValidate0X36( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0X36( ) ;
            }
            else
            {
               CheckExtendedTable0X36( ) ;
               if ( AnyError == 0 )
               {
                  ZM0X36( 7) ;
                  ZM0X36( 8) ;
                  ZM0X36( 9) ;
                  ZM0X36( 10) ;
               }
               CloseExtendedTableCursors0X36( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E120X2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV16Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV17GXV1 = 1;
            while ( AV17GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV17GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "ContratoClienteId") == 0 )
               {
                  AV14Insert_ContratoClienteId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "ContratoPropostaId") == 0 )
               {
                  AV15Insert_ContratoPropostaId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV17GXV1 = (int)(AV17GXV1+1);
            }
         }
      }

      protected void E110X2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0X36( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z228ContratoNome = A228ContratoNome;
            Z361ContratoComVigencia = A361ContratoComVigencia;
            Z362ContratoDataInicial = A362ContratoDataInicial;
            Z363ContratoDataFinal = A363ContratoDataFinal;
            Z460ContratoTaxa = A460ContratoTaxa;
            Z461ContratoSLA = A461ContratoSLA;
            Z462ContratoJurosMora = A462ContratoJurosMora;
            Z463ContratoIOFMinimo = A463ContratoIOFMinimo;
            Z471ContratoSituacao = A471ContratoSituacao;
            Z473ContratoClienteId = A473ContratoClienteId;
            Z923ContratoPropostaId = A923ContratoPropostaId;
            Z483AssinaturaUltId_F = A483AssinaturaUltId_F;
            Z1007ContratoCountAssinantes_F = A1007ContratoCountAssinantes_F;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z474ContratoClienteNome = A474ContratoClienteNome;
            Z475ContratoClienteDocumento = A475ContratoClienteDocumento;
            Z476ContratoClienteRepresentanteNome = A476ContratoClienteRepresentanteNome;
            Z477ContratoClienteRepresentanteCPF = A477ContratoClienteRepresentanteCPF;
            Z561ContratoClienteTipoPessoa = A561ContratoClienteTipoPessoa;
            Z614ContratoClienteEnderecoCEP = A614ContratoClienteEnderecoCEP;
            Z615ContratoClienteEnderecoLograodouro = A615ContratoClienteEnderecoLograodouro;
            Z616ContratoClienteEnderecoNumero = A616ContratoClienteEnderecoNumero;
            Z617ContratoClienteEnderecoComplemento = A617ContratoClienteEnderecoComplemento;
            Z618ContratoClienteEnderecoBairro = A618ContratoClienteEnderecoBairro;
            Z619ContratoClienteMunicipioCodigo = A619ContratoClienteMunicipioCodigo;
            Z483AssinaturaUltId_F = A483AssinaturaUltId_F;
            Z1007ContratoCountAssinantes_F = A1007ContratoCountAssinantes_F;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z483AssinaturaUltId_F = A483AssinaturaUltId_F;
            Z1007ContratoCountAssinantes_F = A1007ContratoCountAssinantes_F;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z483AssinaturaUltId_F = A483AssinaturaUltId_F;
            Z1007ContratoCountAssinantes_F = A1007ContratoCountAssinantes_F;
         }
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z483AssinaturaUltId_F = A483AssinaturaUltId_F;
            Z1007ContratoCountAssinantes_F = A1007ContratoCountAssinantes_F;
         }
         if ( GX_JID == -6 )
         {
            Z227ContratoId = A227ContratoId;
            Z228ContratoNome = A228ContratoNome;
            Z339ContratoCorpo = A339ContratoCorpo;
            Z361ContratoComVigencia = A361ContratoComVigencia;
            Z362ContratoDataInicial = A362ContratoDataInicial;
            Z363ContratoDataFinal = A363ContratoDataFinal;
            Z460ContratoTaxa = A460ContratoTaxa;
            Z461ContratoSLA = A461ContratoSLA;
            Z462ContratoJurosMora = A462ContratoJurosMora;
            Z463ContratoIOFMinimo = A463ContratoIOFMinimo;
            Z471ContratoSituacao = A471ContratoSituacao;
            Z472ContratoBlob = A472ContratoBlob;
            Z473ContratoClienteId = A473ContratoClienteId;
            Z923ContratoPropostaId = A923ContratoPropostaId;
            Z483AssinaturaUltId_F = A483AssinaturaUltId_F;
            Z474ContratoClienteNome = A474ContratoClienteNome;
            Z475ContratoClienteDocumento = A475ContratoClienteDocumento;
            Z476ContratoClienteRepresentanteNome = A476ContratoClienteRepresentanteNome;
            Z477ContratoClienteRepresentanteCPF = A477ContratoClienteRepresentanteCPF;
            Z561ContratoClienteTipoPessoa = A561ContratoClienteTipoPessoa;
            Z614ContratoClienteEnderecoCEP = A614ContratoClienteEnderecoCEP;
            Z615ContratoClienteEnderecoLograodouro = A615ContratoClienteEnderecoLograodouro;
            Z616ContratoClienteEnderecoNumero = A616ContratoClienteEnderecoNumero;
            Z617ContratoClienteEnderecoComplemento = A617ContratoClienteEnderecoComplemento;
            Z618ContratoClienteEnderecoBairro = A618ContratoClienteEnderecoBairro;
            Z619ContratoClienteMunicipioCodigo = A619ContratoClienteMunicipioCodigo;
            Z1007ContratoCountAssinantes_F = A1007ContratoCountAssinantes_F;
         }
      }

      protected void standaloneNotModal( )
      {
         AV16Pgmname = "Contrato_BC";
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0X36( )
      {
         /* Using cursor BC000X12 */
         pr_default.execute(6, new Object[] {n227ContratoId, A227ContratoId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound36 = 1;
            A228ContratoNome = BC000X12_A228ContratoNome[0];
            n228ContratoNome = BC000X12_n228ContratoNome[0];
            A339ContratoCorpo = BC000X12_A339ContratoCorpo[0];
            n339ContratoCorpo = BC000X12_n339ContratoCorpo[0];
            A361ContratoComVigencia = BC000X12_A361ContratoComVigencia[0];
            n361ContratoComVigencia = BC000X12_n361ContratoComVigencia[0];
            A362ContratoDataInicial = BC000X12_A362ContratoDataInicial[0];
            n362ContratoDataInicial = BC000X12_n362ContratoDataInicial[0];
            A363ContratoDataFinal = BC000X12_A363ContratoDataFinal[0];
            n363ContratoDataFinal = BC000X12_n363ContratoDataFinal[0];
            A474ContratoClienteNome = BC000X12_A474ContratoClienteNome[0];
            n474ContratoClienteNome = BC000X12_n474ContratoClienteNome[0];
            A475ContratoClienteDocumento = BC000X12_A475ContratoClienteDocumento[0];
            n475ContratoClienteDocumento = BC000X12_n475ContratoClienteDocumento[0];
            A476ContratoClienteRepresentanteNome = BC000X12_A476ContratoClienteRepresentanteNome[0];
            n476ContratoClienteRepresentanteNome = BC000X12_n476ContratoClienteRepresentanteNome[0];
            A477ContratoClienteRepresentanteCPF = BC000X12_A477ContratoClienteRepresentanteCPF[0];
            n477ContratoClienteRepresentanteCPF = BC000X12_n477ContratoClienteRepresentanteCPF[0];
            A561ContratoClienteTipoPessoa = BC000X12_A561ContratoClienteTipoPessoa[0];
            n561ContratoClienteTipoPessoa = BC000X12_n561ContratoClienteTipoPessoa[0];
            A460ContratoTaxa = BC000X12_A460ContratoTaxa[0];
            n460ContratoTaxa = BC000X12_n460ContratoTaxa[0];
            A461ContratoSLA = BC000X12_A461ContratoSLA[0];
            n461ContratoSLA = BC000X12_n461ContratoSLA[0];
            A462ContratoJurosMora = BC000X12_A462ContratoJurosMora[0];
            n462ContratoJurosMora = BC000X12_n462ContratoJurosMora[0];
            A463ContratoIOFMinimo = BC000X12_A463ContratoIOFMinimo[0];
            n463ContratoIOFMinimo = BC000X12_n463ContratoIOFMinimo[0];
            A471ContratoSituacao = BC000X12_A471ContratoSituacao[0];
            n471ContratoSituacao = BC000X12_n471ContratoSituacao[0];
            A614ContratoClienteEnderecoCEP = BC000X12_A614ContratoClienteEnderecoCEP[0];
            n614ContratoClienteEnderecoCEP = BC000X12_n614ContratoClienteEnderecoCEP[0];
            A615ContratoClienteEnderecoLograodouro = BC000X12_A615ContratoClienteEnderecoLograodouro[0];
            n615ContratoClienteEnderecoLograodouro = BC000X12_n615ContratoClienteEnderecoLograodouro[0];
            A616ContratoClienteEnderecoNumero = BC000X12_A616ContratoClienteEnderecoNumero[0];
            n616ContratoClienteEnderecoNumero = BC000X12_n616ContratoClienteEnderecoNumero[0];
            A617ContratoClienteEnderecoComplemento = BC000X12_A617ContratoClienteEnderecoComplemento[0];
            n617ContratoClienteEnderecoComplemento = BC000X12_n617ContratoClienteEnderecoComplemento[0];
            A618ContratoClienteEnderecoBairro = BC000X12_A618ContratoClienteEnderecoBairro[0];
            n618ContratoClienteEnderecoBairro = BC000X12_n618ContratoClienteEnderecoBairro[0];
            A473ContratoClienteId = BC000X12_A473ContratoClienteId[0];
            n473ContratoClienteId = BC000X12_n473ContratoClienteId[0];
            A923ContratoPropostaId = BC000X12_A923ContratoPropostaId[0];
            n923ContratoPropostaId = BC000X12_n923ContratoPropostaId[0];
            A619ContratoClienteMunicipioCodigo = BC000X12_A619ContratoClienteMunicipioCodigo[0];
            n619ContratoClienteMunicipioCodigo = BC000X12_n619ContratoClienteMunicipioCodigo[0];
            A483AssinaturaUltId_F = BC000X12_A483AssinaturaUltId_F[0];
            n483AssinaturaUltId_F = BC000X12_n483AssinaturaUltId_F[0];
            A1007ContratoCountAssinantes_F = BC000X12_A1007ContratoCountAssinantes_F[0];
            n1007ContratoCountAssinantes_F = BC000X12_n1007ContratoCountAssinantes_F[0];
            A472ContratoBlob = BC000X12_A472ContratoBlob[0];
            n472ContratoBlob = BC000X12_n472ContratoBlob[0];
            ZM0X36( -6) ;
         }
         pr_default.close(6);
         OnLoadActions0X36( ) ;
      }

      protected void OnLoadActions0X36( )
      {
         if ( (0==A473ContratoClienteId) )
         {
            A473ContratoClienteId = 0;
            n473ContratoClienteId = false;
            n473ContratoClienteId = true;
            n473ContratoClienteId = true;
         }
         if ( (0==A923ContratoPropostaId) )
         {
            A923ContratoPropostaId = 0;
            n923ContratoPropostaId = false;
            n923ContratoPropostaId = true;
            n923ContratoPropostaId = true;
         }
      }

      protected void CheckExtendedTable0X36( )
      {
         standaloneModal( ) ;
         /* Using cursor BC000X7 */
         pr_default.execute(4, new Object[] {n227ContratoId, A227ContratoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            A483AssinaturaUltId_F = BC000X7_A483AssinaturaUltId_F[0];
            n483AssinaturaUltId_F = BC000X7_n483AssinaturaUltId_F[0];
         }
         else
         {
            A483AssinaturaUltId_F = 0;
            n483AssinaturaUltId_F = false;
         }
         pr_default.close(4);
         if ( (0==A473ContratoClienteId) )
         {
            A473ContratoClienteId = 0;
            n473ContratoClienteId = false;
            n473ContratoClienteId = true;
            n473ContratoClienteId = true;
         }
         /* Using cursor BC000X4 */
         pr_default.execute(2, new Object[] {n473ContratoClienteId, A473ContratoClienteId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A473ContratoClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Contrato Cliente'.", "ForeignKeyNotFound", 1, "CONTRATOCLIENTEID");
               AnyError = 1;
            }
         }
         A474ContratoClienteNome = BC000X4_A474ContratoClienteNome[0];
         n474ContratoClienteNome = BC000X4_n474ContratoClienteNome[0];
         A475ContratoClienteDocumento = BC000X4_A475ContratoClienteDocumento[0];
         n475ContratoClienteDocumento = BC000X4_n475ContratoClienteDocumento[0];
         A476ContratoClienteRepresentanteNome = BC000X4_A476ContratoClienteRepresentanteNome[0];
         n476ContratoClienteRepresentanteNome = BC000X4_n476ContratoClienteRepresentanteNome[0];
         A477ContratoClienteRepresentanteCPF = BC000X4_A477ContratoClienteRepresentanteCPF[0];
         n477ContratoClienteRepresentanteCPF = BC000X4_n477ContratoClienteRepresentanteCPF[0];
         A561ContratoClienteTipoPessoa = BC000X4_A561ContratoClienteTipoPessoa[0];
         n561ContratoClienteTipoPessoa = BC000X4_n561ContratoClienteTipoPessoa[0];
         A614ContratoClienteEnderecoCEP = BC000X4_A614ContratoClienteEnderecoCEP[0];
         n614ContratoClienteEnderecoCEP = BC000X4_n614ContratoClienteEnderecoCEP[0];
         A615ContratoClienteEnderecoLograodouro = BC000X4_A615ContratoClienteEnderecoLograodouro[0];
         n615ContratoClienteEnderecoLograodouro = BC000X4_n615ContratoClienteEnderecoLograodouro[0];
         A616ContratoClienteEnderecoNumero = BC000X4_A616ContratoClienteEnderecoNumero[0];
         n616ContratoClienteEnderecoNumero = BC000X4_n616ContratoClienteEnderecoNumero[0];
         A617ContratoClienteEnderecoComplemento = BC000X4_A617ContratoClienteEnderecoComplemento[0];
         n617ContratoClienteEnderecoComplemento = BC000X4_n617ContratoClienteEnderecoComplemento[0];
         A618ContratoClienteEnderecoBairro = BC000X4_A618ContratoClienteEnderecoBairro[0];
         n618ContratoClienteEnderecoBairro = BC000X4_n618ContratoClienteEnderecoBairro[0];
         A619ContratoClienteMunicipioCodigo = BC000X4_A619ContratoClienteMunicipioCodigo[0];
         n619ContratoClienteMunicipioCodigo = BC000X4_n619ContratoClienteMunicipioCodigo[0];
         pr_default.close(2);
         /* Using cursor BC000X9 */
         pr_default.execute(5, new Object[] {n227ContratoId, A227ContratoId, n473ContratoClienteId, A473ContratoClienteId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            A1007ContratoCountAssinantes_F = BC000X9_A1007ContratoCountAssinantes_F[0];
            n1007ContratoCountAssinantes_F = BC000X9_n1007ContratoCountAssinantes_F[0];
         }
         else
         {
            A1007ContratoCountAssinantes_F = 0;
            n1007ContratoCountAssinantes_F = false;
         }
         pr_default.close(5);
         if ( ! ( ( StringUtil.StrCmp(A471ContratoSituacao, "EmElaboracao") == 0 ) || ( StringUtil.StrCmp(A471ContratoSituacao, "ColetandoAssinatura") == 0 ) || ( StringUtil.StrCmp(A471ContratoSituacao, "Assinado") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A471ContratoSituacao)) ) )
         {
            GX_msglist.addItem("Campo Contrato Situacao fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( (0==A923ContratoPropostaId) )
         {
            A923ContratoPropostaId = 0;
            n923ContratoPropostaId = false;
            n923ContratoPropostaId = true;
            n923ContratoPropostaId = true;
         }
         /* Using cursor BC000X5 */
         pr_default.execute(3, new Object[] {n923ContratoPropostaId, A923ContratoPropostaId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A923ContratoPropostaId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Contrato Proposta Id'.", "ForeignKeyNotFound", 1, "CONTRATOPROPOSTAID");
               AnyError = 1;
            }
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0X36( )
      {
         pr_default.close(4);
         pr_default.close(2);
         pr_default.close(5);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0X36( )
      {
         /* Using cursor BC000X13 */
         pr_default.execute(7, new Object[] {n227ContratoId, A227ContratoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound36 = 1;
         }
         else
         {
            RcdFound36 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000X3 */
         pr_default.execute(1, new Object[] {n227ContratoId, A227ContratoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0X36( 6) ;
            RcdFound36 = 1;
            A227ContratoId = BC000X3_A227ContratoId[0];
            n227ContratoId = BC000X3_n227ContratoId[0];
            A228ContratoNome = BC000X3_A228ContratoNome[0];
            n228ContratoNome = BC000X3_n228ContratoNome[0];
            A339ContratoCorpo = BC000X3_A339ContratoCorpo[0];
            n339ContratoCorpo = BC000X3_n339ContratoCorpo[0];
            A361ContratoComVigencia = BC000X3_A361ContratoComVigencia[0];
            n361ContratoComVigencia = BC000X3_n361ContratoComVigencia[0];
            A362ContratoDataInicial = BC000X3_A362ContratoDataInicial[0];
            n362ContratoDataInicial = BC000X3_n362ContratoDataInicial[0];
            A363ContratoDataFinal = BC000X3_A363ContratoDataFinal[0];
            n363ContratoDataFinal = BC000X3_n363ContratoDataFinal[0];
            A460ContratoTaxa = BC000X3_A460ContratoTaxa[0];
            n460ContratoTaxa = BC000X3_n460ContratoTaxa[0];
            A461ContratoSLA = BC000X3_A461ContratoSLA[0];
            n461ContratoSLA = BC000X3_n461ContratoSLA[0];
            A462ContratoJurosMora = BC000X3_A462ContratoJurosMora[0];
            n462ContratoJurosMora = BC000X3_n462ContratoJurosMora[0];
            A463ContratoIOFMinimo = BC000X3_A463ContratoIOFMinimo[0];
            n463ContratoIOFMinimo = BC000X3_n463ContratoIOFMinimo[0];
            A471ContratoSituacao = BC000X3_A471ContratoSituacao[0];
            n471ContratoSituacao = BC000X3_n471ContratoSituacao[0];
            A473ContratoClienteId = BC000X3_A473ContratoClienteId[0];
            n473ContratoClienteId = BC000X3_n473ContratoClienteId[0];
            A923ContratoPropostaId = BC000X3_A923ContratoPropostaId[0];
            n923ContratoPropostaId = BC000X3_n923ContratoPropostaId[0];
            A472ContratoBlob = BC000X3_A472ContratoBlob[0];
            n472ContratoBlob = BC000X3_n472ContratoBlob[0];
            Z227ContratoId = A227ContratoId;
            sMode36 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0X36( ) ;
            if ( AnyError == 1 )
            {
               RcdFound36 = 0;
               InitializeNonKey0X36( ) ;
            }
            Gx_mode = sMode36;
         }
         else
         {
            RcdFound36 = 0;
            InitializeNonKey0X36( ) ;
            sMode36 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode36;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0X36( ) ;
         if ( RcdFound36 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_0X0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0X36( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000X2 */
            pr_default.execute(0, new Object[] {n227ContratoId, A227ContratoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Contrato"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z228ContratoNome, BC000X2_A228ContratoNome[0]) != 0 ) || ( Z361ContratoComVigencia != BC000X2_A361ContratoComVigencia[0] ) || ( DateTimeUtil.ResetTime ( Z362ContratoDataInicial ) != DateTimeUtil.ResetTime ( BC000X2_A362ContratoDataInicial[0] ) ) || ( DateTimeUtil.ResetTime ( Z363ContratoDataFinal ) != DateTimeUtil.ResetTime ( BC000X2_A363ContratoDataFinal[0] ) ) || ( Z460ContratoTaxa != BC000X2_A460ContratoTaxa[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z461ContratoSLA != BC000X2_A461ContratoSLA[0] ) || ( Z462ContratoJurosMora != BC000X2_A462ContratoJurosMora[0] ) || ( Z463ContratoIOFMinimo != BC000X2_A463ContratoIOFMinimo[0] ) || ( StringUtil.StrCmp(Z471ContratoSituacao, BC000X2_A471ContratoSituacao[0]) != 0 ) || ( Z473ContratoClienteId != BC000X2_A473ContratoClienteId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z923ContratoPropostaId != BC000X2_A923ContratoPropostaId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Contrato"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0X36( )
      {
         BeforeValidate0X36( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0X36( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0X36( 0) ;
            CheckOptimisticConcurrency0X36( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0X36( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0X36( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000X14 */
                     pr_default.execute(8, new Object[] {n228ContratoNome, A228ContratoNome, n339ContratoCorpo, A339ContratoCorpo, n361ContratoComVigencia, A361ContratoComVigencia, n362ContratoDataInicial, A362ContratoDataInicial, n363ContratoDataFinal, A363ContratoDataFinal, n460ContratoTaxa, A460ContratoTaxa, n461ContratoSLA, A461ContratoSLA, n462ContratoJurosMora, A462ContratoJurosMora, n463ContratoIOFMinimo, A463ContratoIOFMinimo, n471ContratoSituacao, A471ContratoSituacao, n472ContratoBlob, A472ContratoBlob, n473ContratoClienteId, A473ContratoClienteId, n923ContratoPropostaId, A923ContratoPropostaId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000X15 */
                     pr_default.execute(9);
                     A227ContratoId = BC000X15_A227ContratoId[0];
                     n227ContratoId = BC000X15_n227ContratoId[0];
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Contrato");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0X36( ) ;
            }
            EndLevel0X36( ) ;
         }
         CloseExtendedTableCursors0X36( ) ;
      }

      protected void Update0X36( )
      {
         BeforeValidate0X36( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0X36( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0X36( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0X36( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0X36( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000X16 */
                     pr_default.execute(10, new Object[] {n228ContratoNome, A228ContratoNome, n339ContratoCorpo, A339ContratoCorpo, n361ContratoComVigencia, A361ContratoComVigencia, n362ContratoDataInicial, A362ContratoDataInicial, n363ContratoDataFinal, A363ContratoDataFinal, n460ContratoTaxa, A460ContratoTaxa, n461ContratoSLA, A461ContratoSLA, n462ContratoJurosMora, A462ContratoJurosMora, n463ContratoIOFMinimo, A463ContratoIOFMinimo, n471ContratoSituacao, A471ContratoSituacao, n473ContratoClienteId, A473ContratoClienteId, n923ContratoPropostaId, A923ContratoPropostaId, n227ContratoId, A227ContratoId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Contrato");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Contrato"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0X36( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0X36( ) ;
         }
         CloseExtendedTableCursors0X36( ) ;
      }

      protected void DeferredUpdate0X36( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC000X17 */
            pr_default.execute(11, new Object[] {n472ContratoBlob, A472ContratoBlob, n227ContratoId, A227ContratoId});
            pr_default.close(11);
            pr_default.SmartCacheProvider.SetUpdated("Contrato");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0X36( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0X36( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0X36( ) ;
            AfterConfirm0X36( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0X36( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000X18 */
                  pr_default.execute(12, new Object[] {n227ContratoId, A227ContratoId});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("Contrato");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode36 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0X36( ) ;
         Gx_mode = sMode36;
      }

      protected void OnDeleteControls0X36( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000X20 */
            pr_default.execute(13, new Object[] {n227ContratoId, A227ContratoId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               A483AssinaturaUltId_F = BC000X20_A483AssinaturaUltId_F[0];
               n483AssinaturaUltId_F = BC000X20_n483AssinaturaUltId_F[0];
            }
            else
            {
               A483AssinaturaUltId_F = 0;
               n483AssinaturaUltId_F = false;
            }
            pr_default.close(13);
            /* Using cursor BC000X21 */
            pr_default.execute(14, new Object[] {n473ContratoClienteId, A473ContratoClienteId});
            A474ContratoClienteNome = BC000X21_A474ContratoClienteNome[0];
            n474ContratoClienteNome = BC000X21_n474ContratoClienteNome[0];
            A475ContratoClienteDocumento = BC000X21_A475ContratoClienteDocumento[0];
            n475ContratoClienteDocumento = BC000X21_n475ContratoClienteDocumento[0];
            A476ContratoClienteRepresentanteNome = BC000X21_A476ContratoClienteRepresentanteNome[0];
            n476ContratoClienteRepresentanteNome = BC000X21_n476ContratoClienteRepresentanteNome[0];
            A477ContratoClienteRepresentanteCPF = BC000X21_A477ContratoClienteRepresentanteCPF[0];
            n477ContratoClienteRepresentanteCPF = BC000X21_n477ContratoClienteRepresentanteCPF[0];
            A561ContratoClienteTipoPessoa = BC000X21_A561ContratoClienteTipoPessoa[0];
            n561ContratoClienteTipoPessoa = BC000X21_n561ContratoClienteTipoPessoa[0];
            A614ContratoClienteEnderecoCEP = BC000X21_A614ContratoClienteEnderecoCEP[0];
            n614ContratoClienteEnderecoCEP = BC000X21_n614ContratoClienteEnderecoCEP[0];
            A615ContratoClienteEnderecoLograodouro = BC000X21_A615ContratoClienteEnderecoLograodouro[0];
            n615ContratoClienteEnderecoLograodouro = BC000X21_n615ContratoClienteEnderecoLograodouro[0];
            A616ContratoClienteEnderecoNumero = BC000X21_A616ContratoClienteEnderecoNumero[0];
            n616ContratoClienteEnderecoNumero = BC000X21_n616ContratoClienteEnderecoNumero[0];
            A617ContratoClienteEnderecoComplemento = BC000X21_A617ContratoClienteEnderecoComplemento[0];
            n617ContratoClienteEnderecoComplemento = BC000X21_n617ContratoClienteEnderecoComplemento[0];
            A618ContratoClienteEnderecoBairro = BC000X21_A618ContratoClienteEnderecoBairro[0];
            n618ContratoClienteEnderecoBairro = BC000X21_n618ContratoClienteEnderecoBairro[0];
            A619ContratoClienteMunicipioCodigo = BC000X21_A619ContratoClienteMunicipioCodigo[0];
            n619ContratoClienteMunicipioCodigo = BC000X21_n619ContratoClienteMunicipioCodigo[0];
            pr_default.close(14);
            /* Using cursor BC000X23 */
            pr_default.execute(15, new Object[] {n227ContratoId, A227ContratoId, n473ContratoClienteId, A473ContratoClienteId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               A1007ContratoCountAssinantes_F = BC000X23_A1007ContratoCountAssinantes_F[0];
               n1007ContratoCountAssinantes_F = BC000X23_n1007ContratoCountAssinantes_F[0];
            }
            else
            {
               A1007ContratoCountAssinantes_F = 0;
               n1007ContratoCountAssinantes_F = false;
            }
            pr_default.close(15);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000X24 */
            pr_default.execute(16, new Object[] {n227ContratoId, A227ContratoId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"PropostaContratoAssinatura"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor BC000X25 */
            pr_default.execute(17, new Object[] {n227ContratoId, A227ContratoId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Operacoes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor BC000X26 */
            pr_default.execute(18, new Object[] {n227ContratoId, A227ContratoId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Proposta"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor BC000X27 */
            pr_default.execute(19, new Object[] {n227ContratoId, A227ContratoId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Assinatura"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor BC000X28 */
            pr_default.execute(20, new Object[] {n227ContratoId, A227ContratoId});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Contrato Participante"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
         }
      }

      protected void EndLevel0X36( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0X36( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0X36( )
      {
         /* Scan By routine */
         /* Using cursor BC000X31 */
         pr_default.execute(21, new Object[] {n227ContratoId, A227ContratoId});
         RcdFound36 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound36 = 1;
            A227ContratoId = BC000X31_A227ContratoId[0];
            n227ContratoId = BC000X31_n227ContratoId[0];
            A228ContratoNome = BC000X31_A228ContratoNome[0];
            n228ContratoNome = BC000X31_n228ContratoNome[0];
            A339ContratoCorpo = BC000X31_A339ContratoCorpo[0];
            n339ContratoCorpo = BC000X31_n339ContratoCorpo[0];
            A361ContratoComVigencia = BC000X31_A361ContratoComVigencia[0];
            n361ContratoComVigencia = BC000X31_n361ContratoComVigencia[0];
            A362ContratoDataInicial = BC000X31_A362ContratoDataInicial[0];
            n362ContratoDataInicial = BC000X31_n362ContratoDataInicial[0];
            A363ContratoDataFinal = BC000X31_A363ContratoDataFinal[0];
            n363ContratoDataFinal = BC000X31_n363ContratoDataFinal[0];
            A474ContratoClienteNome = BC000X31_A474ContratoClienteNome[0];
            n474ContratoClienteNome = BC000X31_n474ContratoClienteNome[0];
            A475ContratoClienteDocumento = BC000X31_A475ContratoClienteDocumento[0];
            n475ContratoClienteDocumento = BC000X31_n475ContratoClienteDocumento[0];
            A476ContratoClienteRepresentanteNome = BC000X31_A476ContratoClienteRepresentanteNome[0];
            n476ContratoClienteRepresentanteNome = BC000X31_n476ContratoClienteRepresentanteNome[0];
            A477ContratoClienteRepresentanteCPF = BC000X31_A477ContratoClienteRepresentanteCPF[0];
            n477ContratoClienteRepresentanteCPF = BC000X31_n477ContratoClienteRepresentanteCPF[0];
            A561ContratoClienteTipoPessoa = BC000X31_A561ContratoClienteTipoPessoa[0];
            n561ContratoClienteTipoPessoa = BC000X31_n561ContratoClienteTipoPessoa[0];
            A460ContratoTaxa = BC000X31_A460ContratoTaxa[0];
            n460ContratoTaxa = BC000X31_n460ContratoTaxa[0];
            A461ContratoSLA = BC000X31_A461ContratoSLA[0];
            n461ContratoSLA = BC000X31_n461ContratoSLA[0];
            A462ContratoJurosMora = BC000X31_A462ContratoJurosMora[0];
            n462ContratoJurosMora = BC000X31_n462ContratoJurosMora[0];
            A463ContratoIOFMinimo = BC000X31_A463ContratoIOFMinimo[0];
            n463ContratoIOFMinimo = BC000X31_n463ContratoIOFMinimo[0];
            A471ContratoSituacao = BC000X31_A471ContratoSituacao[0];
            n471ContratoSituacao = BC000X31_n471ContratoSituacao[0];
            A614ContratoClienteEnderecoCEP = BC000X31_A614ContratoClienteEnderecoCEP[0];
            n614ContratoClienteEnderecoCEP = BC000X31_n614ContratoClienteEnderecoCEP[0];
            A615ContratoClienteEnderecoLograodouro = BC000X31_A615ContratoClienteEnderecoLograodouro[0];
            n615ContratoClienteEnderecoLograodouro = BC000X31_n615ContratoClienteEnderecoLograodouro[0];
            A616ContratoClienteEnderecoNumero = BC000X31_A616ContratoClienteEnderecoNumero[0];
            n616ContratoClienteEnderecoNumero = BC000X31_n616ContratoClienteEnderecoNumero[0];
            A617ContratoClienteEnderecoComplemento = BC000X31_A617ContratoClienteEnderecoComplemento[0];
            n617ContratoClienteEnderecoComplemento = BC000X31_n617ContratoClienteEnderecoComplemento[0];
            A618ContratoClienteEnderecoBairro = BC000X31_A618ContratoClienteEnderecoBairro[0];
            n618ContratoClienteEnderecoBairro = BC000X31_n618ContratoClienteEnderecoBairro[0];
            A473ContratoClienteId = BC000X31_A473ContratoClienteId[0];
            n473ContratoClienteId = BC000X31_n473ContratoClienteId[0];
            A923ContratoPropostaId = BC000X31_A923ContratoPropostaId[0];
            n923ContratoPropostaId = BC000X31_n923ContratoPropostaId[0];
            A619ContratoClienteMunicipioCodigo = BC000X31_A619ContratoClienteMunicipioCodigo[0];
            n619ContratoClienteMunicipioCodigo = BC000X31_n619ContratoClienteMunicipioCodigo[0];
            A483AssinaturaUltId_F = BC000X31_A483AssinaturaUltId_F[0];
            n483AssinaturaUltId_F = BC000X31_n483AssinaturaUltId_F[0];
            A1007ContratoCountAssinantes_F = BC000X31_A1007ContratoCountAssinantes_F[0];
            n1007ContratoCountAssinantes_F = BC000X31_n1007ContratoCountAssinantes_F[0];
            A472ContratoBlob = BC000X31_A472ContratoBlob[0];
            n472ContratoBlob = BC000X31_n472ContratoBlob[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0X36( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound36 = 0;
         ScanKeyLoad0X36( ) ;
      }

      protected void ScanKeyLoad0X36( )
      {
         sMode36 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound36 = 1;
            A227ContratoId = BC000X31_A227ContratoId[0];
            n227ContratoId = BC000X31_n227ContratoId[0];
            A228ContratoNome = BC000X31_A228ContratoNome[0];
            n228ContratoNome = BC000X31_n228ContratoNome[0];
            A339ContratoCorpo = BC000X31_A339ContratoCorpo[0];
            n339ContratoCorpo = BC000X31_n339ContratoCorpo[0];
            A361ContratoComVigencia = BC000X31_A361ContratoComVigencia[0];
            n361ContratoComVigencia = BC000X31_n361ContratoComVigencia[0];
            A362ContratoDataInicial = BC000X31_A362ContratoDataInicial[0];
            n362ContratoDataInicial = BC000X31_n362ContratoDataInicial[0];
            A363ContratoDataFinal = BC000X31_A363ContratoDataFinal[0];
            n363ContratoDataFinal = BC000X31_n363ContratoDataFinal[0];
            A474ContratoClienteNome = BC000X31_A474ContratoClienteNome[0];
            n474ContratoClienteNome = BC000X31_n474ContratoClienteNome[0];
            A475ContratoClienteDocumento = BC000X31_A475ContratoClienteDocumento[0];
            n475ContratoClienteDocumento = BC000X31_n475ContratoClienteDocumento[0];
            A476ContratoClienteRepresentanteNome = BC000X31_A476ContratoClienteRepresentanteNome[0];
            n476ContratoClienteRepresentanteNome = BC000X31_n476ContratoClienteRepresentanteNome[0];
            A477ContratoClienteRepresentanteCPF = BC000X31_A477ContratoClienteRepresentanteCPF[0];
            n477ContratoClienteRepresentanteCPF = BC000X31_n477ContratoClienteRepresentanteCPF[0];
            A561ContratoClienteTipoPessoa = BC000X31_A561ContratoClienteTipoPessoa[0];
            n561ContratoClienteTipoPessoa = BC000X31_n561ContratoClienteTipoPessoa[0];
            A460ContratoTaxa = BC000X31_A460ContratoTaxa[0];
            n460ContratoTaxa = BC000X31_n460ContratoTaxa[0];
            A461ContratoSLA = BC000X31_A461ContratoSLA[0];
            n461ContratoSLA = BC000X31_n461ContratoSLA[0];
            A462ContratoJurosMora = BC000X31_A462ContratoJurosMora[0];
            n462ContratoJurosMora = BC000X31_n462ContratoJurosMora[0];
            A463ContratoIOFMinimo = BC000X31_A463ContratoIOFMinimo[0];
            n463ContratoIOFMinimo = BC000X31_n463ContratoIOFMinimo[0];
            A471ContratoSituacao = BC000X31_A471ContratoSituacao[0];
            n471ContratoSituacao = BC000X31_n471ContratoSituacao[0];
            A614ContratoClienteEnderecoCEP = BC000X31_A614ContratoClienteEnderecoCEP[0];
            n614ContratoClienteEnderecoCEP = BC000X31_n614ContratoClienteEnderecoCEP[0];
            A615ContratoClienteEnderecoLograodouro = BC000X31_A615ContratoClienteEnderecoLograodouro[0];
            n615ContratoClienteEnderecoLograodouro = BC000X31_n615ContratoClienteEnderecoLograodouro[0];
            A616ContratoClienteEnderecoNumero = BC000X31_A616ContratoClienteEnderecoNumero[0];
            n616ContratoClienteEnderecoNumero = BC000X31_n616ContratoClienteEnderecoNumero[0];
            A617ContratoClienteEnderecoComplemento = BC000X31_A617ContratoClienteEnderecoComplemento[0];
            n617ContratoClienteEnderecoComplemento = BC000X31_n617ContratoClienteEnderecoComplemento[0];
            A618ContratoClienteEnderecoBairro = BC000X31_A618ContratoClienteEnderecoBairro[0];
            n618ContratoClienteEnderecoBairro = BC000X31_n618ContratoClienteEnderecoBairro[0];
            A473ContratoClienteId = BC000X31_A473ContratoClienteId[0];
            n473ContratoClienteId = BC000X31_n473ContratoClienteId[0];
            A923ContratoPropostaId = BC000X31_A923ContratoPropostaId[0];
            n923ContratoPropostaId = BC000X31_n923ContratoPropostaId[0];
            A619ContratoClienteMunicipioCodigo = BC000X31_A619ContratoClienteMunicipioCodigo[0];
            n619ContratoClienteMunicipioCodigo = BC000X31_n619ContratoClienteMunicipioCodigo[0];
            A483AssinaturaUltId_F = BC000X31_A483AssinaturaUltId_F[0];
            n483AssinaturaUltId_F = BC000X31_n483AssinaturaUltId_F[0];
            A1007ContratoCountAssinantes_F = BC000X31_A1007ContratoCountAssinantes_F[0];
            n1007ContratoCountAssinantes_F = BC000X31_n1007ContratoCountAssinantes_F[0];
            A472ContratoBlob = BC000X31_A472ContratoBlob[0];
            n472ContratoBlob = BC000X31_n472ContratoBlob[0];
         }
         Gx_mode = sMode36;
      }

      protected void ScanKeyEnd0X36( )
      {
         pr_default.close(21);
      }

      protected void AfterConfirm0X36( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0X36( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0X36( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0X36( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0X36( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0X36( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0X36( )
      {
      }

      protected void send_integrity_lvl_hashes0X36( )
      {
      }

      protected void AddRow0X36( )
      {
         VarsToRow36( bcContrato) ;
      }

      protected void ReadRow0X36( )
      {
         RowToVars36( bcContrato, 1) ;
      }

      protected void InitializeNonKey0X36( )
      {
         A228ContratoNome = "";
         n228ContratoNome = false;
         A339ContratoCorpo = "";
         n339ContratoCorpo = false;
         A361ContratoComVigencia = false;
         n361ContratoComVigencia = false;
         A362ContratoDataInicial = DateTime.MinValue;
         n362ContratoDataInicial = false;
         A363ContratoDataFinal = DateTime.MinValue;
         n363ContratoDataFinal = false;
         A473ContratoClienteId = 0;
         n473ContratoClienteId = false;
         A474ContratoClienteNome = "";
         n474ContratoClienteNome = false;
         A475ContratoClienteDocumento = "";
         n475ContratoClienteDocumento = false;
         A476ContratoClienteRepresentanteNome = "";
         n476ContratoClienteRepresentanteNome = false;
         A477ContratoClienteRepresentanteCPF = "";
         n477ContratoClienteRepresentanteCPF = false;
         A561ContratoClienteTipoPessoa = "";
         n561ContratoClienteTipoPessoa = false;
         A460ContratoTaxa = 0;
         n460ContratoTaxa = false;
         A461ContratoSLA = 0;
         n461ContratoSLA = false;
         A462ContratoJurosMora = 0;
         n462ContratoJurosMora = false;
         A463ContratoIOFMinimo = 0;
         n463ContratoIOFMinimo = false;
         A471ContratoSituacao = "";
         n471ContratoSituacao = false;
         A472ContratoBlob = "";
         n472ContratoBlob = false;
         A483AssinaturaUltId_F = 0;
         n483AssinaturaUltId_F = false;
         A614ContratoClienteEnderecoCEP = "";
         n614ContratoClienteEnderecoCEP = false;
         A615ContratoClienteEnderecoLograodouro = "";
         n615ContratoClienteEnderecoLograodouro = false;
         A616ContratoClienteEnderecoNumero = "";
         n616ContratoClienteEnderecoNumero = false;
         A617ContratoClienteEnderecoComplemento = "";
         n617ContratoClienteEnderecoComplemento = false;
         A618ContratoClienteEnderecoBairro = "";
         n618ContratoClienteEnderecoBairro = false;
         A619ContratoClienteMunicipioCodigo = "";
         n619ContratoClienteMunicipioCodigo = false;
         A923ContratoPropostaId = 0;
         n923ContratoPropostaId = false;
         A1007ContratoCountAssinantes_F = 0;
         n1007ContratoCountAssinantes_F = false;
         Z228ContratoNome = "";
         Z361ContratoComVigencia = false;
         Z362ContratoDataInicial = DateTime.MinValue;
         Z363ContratoDataFinal = DateTime.MinValue;
         Z460ContratoTaxa = 0;
         Z461ContratoSLA = 0;
         Z462ContratoJurosMora = 0;
         Z463ContratoIOFMinimo = 0;
         Z471ContratoSituacao = "";
         Z473ContratoClienteId = 0;
         Z923ContratoPropostaId = 0;
      }

      protected void InitAll0X36( )
      {
         A227ContratoId = 0;
         n227ContratoId = false;
         InitializeNonKey0X36( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow36( SdtContrato obj36 )
      {
         obj36.gxTpr_Mode = Gx_mode;
         obj36.gxTpr_Contratonome = A228ContratoNome;
         obj36.gxTpr_Contratocorpo = A339ContratoCorpo;
         obj36.gxTpr_Contratocomvigencia = A361ContratoComVigencia;
         obj36.gxTpr_Contratodatainicial = A362ContratoDataInicial;
         obj36.gxTpr_Contratodatafinal = A363ContratoDataFinal;
         obj36.gxTpr_Contratoclienteid = A473ContratoClienteId;
         obj36.gxTpr_Contratoclientenome = A474ContratoClienteNome;
         obj36.gxTpr_Contratoclientedocumento = A475ContratoClienteDocumento;
         obj36.gxTpr_Contratoclienterepresentantenome = A476ContratoClienteRepresentanteNome;
         obj36.gxTpr_Contratoclienterepresentantecpf = A477ContratoClienteRepresentanteCPF;
         obj36.gxTpr_Contratoclientetipopessoa = A561ContratoClienteTipoPessoa;
         obj36.gxTpr_Contratotaxa = A460ContratoTaxa;
         obj36.gxTpr_Contratosla = A461ContratoSLA;
         obj36.gxTpr_Contratojurosmora = A462ContratoJurosMora;
         obj36.gxTpr_Contratoiofminimo = A463ContratoIOFMinimo;
         obj36.gxTpr_Contratosituacao = A471ContratoSituacao;
         obj36.gxTpr_Contratoblob = A472ContratoBlob;
         obj36.gxTpr_Assinaturaultid_f = A483AssinaturaUltId_F;
         obj36.gxTpr_Contratoclienteenderecocep = A614ContratoClienteEnderecoCEP;
         obj36.gxTpr_Contratoclienteenderecolograodouro = A615ContratoClienteEnderecoLograodouro;
         obj36.gxTpr_Contratoclienteendereconumero = A616ContratoClienteEnderecoNumero;
         obj36.gxTpr_Contratoclienteenderecocomplemento = A617ContratoClienteEnderecoComplemento;
         obj36.gxTpr_Contratoclienteenderecobairro = A618ContratoClienteEnderecoBairro;
         obj36.gxTpr_Contratoclientemunicipiocodigo = A619ContratoClienteMunicipioCodigo;
         obj36.gxTpr_Contratopropostaid = A923ContratoPropostaId;
         obj36.gxTpr_Contratocountassinantes_f = A1007ContratoCountAssinantes_F;
         obj36.gxTpr_Contratoid = A227ContratoId;
         obj36.gxTpr_Contratoid_Z = Z227ContratoId;
         obj36.gxTpr_Contratonome_Z = Z228ContratoNome;
         obj36.gxTpr_Contratocomvigencia_Z = Z361ContratoComVigencia;
         obj36.gxTpr_Contratodatainicial_Z = Z362ContratoDataInicial;
         obj36.gxTpr_Contratodatafinal_Z = Z363ContratoDataFinal;
         obj36.gxTpr_Contratoclienteid_Z = Z473ContratoClienteId;
         obj36.gxTpr_Contratoclientenome_Z = Z474ContratoClienteNome;
         obj36.gxTpr_Contratoclientedocumento_Z = Z475ContratoClienteDocumento;
         obj36.gxTpr_Contratoclienterepresentantenome_Z = Z476ContratoClienteRepresentanteNome;
         obj36.gxTpr_Contratoclienterepresentantecpf_Z = Z477ContratoClienteRepresentanteCPF;
         obj36.gxTpr_Contratoclientetipopessoa_Z = Z561ContratoClienteTipoPessoa;
         obj36.gxTpr_Contratotaxa_Z = Z460ContratoTaxa;
         obj36.gxTpr_Contratosla_Z = Z461ContratoSLA;
         obj36.gxTpr_Contratojurosmora_Z = Z462ContratoJurosMora;
         obj36.gxTpr_Contratoiofminimo_Z = Z463ContratoIOFMinimo;
         obj36.gxTpr_Contratosituacao_Z = Z471ContratoSituacao;
         obj36.gxTpr_Assinaturaultid_f_Z = Z483AssinaturaUltId_F;
         obj36.gxTpr_Contratoclienteenderecocep_Z = Z614ContratoClienteEnderecoCEP;
         obj36.gxTpr_Contratoclienteenderecolograodouro_Z = Z615ContratoClienteEnderecoLograodouro;
         obj36.gxTpr_Contratoclienteendereconumero_Z = Z616ContratoClienteEnderecoNumero;
         obj36.gxTpr_Contratoclienteenderecocomplemento_Z = Z617ContratoClienteEnderecoComplemento;
         obj36.gxTpr_Contratoclienteenderecobairro_Z = Z618ContratoClienteEnderecoBairro;
         obj36.gxTpr_Contratoclientemunicipiocodigo_Z = Z619ContratoClienteMunicipioCodigo;
         obj36.gxTpr_Contratopropostaid_Z = Z923ContratoPropostaId;
         obj36.gxTpr_Contratocountassinantes_f_Z = Z1007ContratoCountAssinantes_F;
         obj36.gxTpr_Contratoid_N = (short)(Convert.ToInt16(n227ContratoId));
         obj36.gxTpr_Contratonome_N = (short)(Convert.ToInt16(n228ContratoNome));
         obj36.gxTpr_Contratocorpo_N = (short)(Convert.ToInt16(n339ContratoCorpo));
         obj36.gxTpr_Contratocomvigencia_N = (short)(Convert.ToInt16(n361ContratoComVigencia));
         obj36.gxTpr_Contratodatainicial_N = (short)(Convert.ToInt16(n362ContratoDataInicial));
         obj36.gxTpr_Contratodatafinal_N = (short)(Convert.ToInt16(n363ContratoDataFinal));
         obj36.gxTpr_Contratoclienteid_N = (short)(Convert.ToInt16(n473ContratoClienteId));
         obj36.gxTpr_Contratoclientenome_N = (short)(Convert.ToInt16(n474ContratoClienteNome));
         obj36.gxTpr_Contratoclientedocumento_N = (short)(Convert.ToInt16(n475ContratoClienteDocumento));
         obj36.gxTpr_Contratoclienterepresentantenome_N = (short)(Convert.ToInt16(n476ContratoClienteRepresentanteNome));
         obj36.gxTpr_Contratoclienterepresentantecpf_N = (short)(Convert.ToInt16(n477ContratoClienteRepresentanteCPF));
         obj36.gxTpr_Contratoclientetipopessoa_N = (short)(Convert.ToInt16(n561ContratoClienteTipoPessoa));
         obj36.gxTpr_Contratotaxa_N = (short)(Convert.ToInt16(n460ContratoTaxa));
         obj36.gxTpr_Contratosla_N = (short)(Convert.ToInt16(n461ContratoSLA));
         obj36.gxTpr_Contratojurosmora_N = (short)(Convert.ToInt16(n462ContratoJurosMora));
         obj36.gxTpr_Contratoiofminimo_N = (short)(Convert.ToInt16(n463ContratoIOFMinimo));
         obj36.gxTpr_Contratosituacao_N = (short)(Convert.ToInt16(n471ContratoSituacao));
         obj36.gxTpr_Contratoblob_N = (short)(Convert.ToInt16(n472ContratoBlob));
         obj36.gxTpr_Assinaturaultid_f_N = (short)(Convert.ToInt16(n483AssinaturaUltId_F));
         obj36.gxTpr_Contratoclienteenderecocep_N = (short)(Convert.ToInt16(n614ContratoClienteEnderecoCEP));
         obj36.gxTpr_Contratoclienteenderecolograodouro_N = (short)(Convert.ToInt16(n615ContratoClienteEnderecoLograodouro));
         obj36.gxTpr_Contratoclienteendereconumero_N = (short)(Convert.ToInt16(n616ContratoClienteEnderecoNumero));
         obj36.gxTpr_Contratoclienteenderecocomplemento_N = (short)(Convert.ToInt16(n617ContratoClienteEnderecoComplemento));
         obj36.gxTpr_Contratoclienteenderecobairro_N = (short)(Convert.ToInt16(n618ContratoClienteEnderecoBairro));
         obj36.gxTpr_Contratoclientemunicipiocodigo_N = (short)(Convert.ToInt16(n619ContratoClienteMunicipioCodigo));
         obj36.gxTpr_Contratopropostaid_N = (short)(Convert.ToInt16(n923ContratoPropostaId));
         obj36.gxTpr_Contratocountassinantes_f_N = (short)(Convert.ToInt16(n1007ContratoCountAssinantes_F));
         obj36.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow36( SdtContrato obj36 )
      {
         obj36.gxTpr_Contratoid = A227ContratoId;
         return  ;
      }

      public void RowToVars36( SdtContrato obj36 ,
                               int forceLoad )
      {
         Gx_mode = obj36.gxTpr_Mode;
         A228ContratoNome = obj36.gxTpr_Contratonome;
         n228ContratoNome = false;
         A339ContratoCorpo = obj36.gxTpr_Contratocorpo;
         n339ContratoCorpo = false;
         A361ContratoComVigencia = obj36.gxTpr_Contratocomvigencia;
         n361ContratoComVigencia = false;
         A362ContratoDataInicial = obj36.gxTpr_Contratodatainicial;
         n362ContratoDataInicial = false;
         A363ContratoDataFinal = obj36.gxTpr_Contratodatafinal;
         n363ContratoDataFinal = false;
         A473ContratoClienteId = obj36.gxTpr_Contratoclienteid;
         n473ContratoClienteId = false;
         A474ContratoClienteNome = obj36.gxTpr_Contratoclientenome;
         n474ContratoClienteNome = false;
         A475ContratoClienteDocumento = obj36.gxTpr_Contratoclientedocumento;
         n475ContratoClienteDocumento = false;
         A476ContratoClienteRepresentanteNome = obj36.gxTpr_Contratoclienterepresentantenome;
         n476ContratoClienteRepresentanteNome = false;
         A477ContratoClienteRepresentanteCPF = obj36.gxTpr_Contratoclienterepresentantecpf;
         n477ContratoClienteRepresentanteCPF = false;
         A561ContratoClienteTipoPessoa = obj36.gxTpr_Contratoclientetipopessoa;
         n561ContratoClienteTipoPessoa = false;
         A460ContratoTaxa = obj36.gxTpr_Contratotaxa;
         n460ContratoTaxa = false;
         A461ContratoSLA = obj36.gxTpr_Contratosla;
         n461ContratoSLA = false;
         A462ContratoJurosMora = obj36.gxTpr_Contratojurosmora;
         n462ContratoJurosMora = false;
         A463ContratoIOFMinimo = obj36.gxTpr_Contratoiofminimo;
         n463ContratoIOFMinimo = false;
         A471ContratoSituacao = obj36.gxTpr_Contratosituacao;
         n471ContratoSituacao = false;
         A472ContratoBlob = obj36.gxTpr_Contratoblob;
         n472ContratoBlob = false;
         A483AssinaturaUltId_F = obj36.gxTpr_Assinaturaultid_f;
         n483AssinaturaUltId_F = false;
         A614ContratoClienteEnderecoCEP = obj36.gxTpr_Contratoclienteenderecocep;
         n614ContratoClienteEnderecoCEP = false;
         A615ContratoClienteEnderecoLograodouro = obj36.gxTpr_Contratoclienteenderecolograodouro;
         n615ContratoClienteEnderecoLograodouro = false;
         A616ContratoClienteEnderecoNumero = obj36.gxTpr_Contratoclienteendereconumero;
         n616ContratoClienteEnderecoNumero = false;
         A617ContratoClienteEnderecoComplemento = obj36.gxTpr_Contratoclienteenderecocomplemento;
         n617ContratoClienteEnderecoComplemento = false;
         A618ContratoClienteEnderecoBairro = obj36.gxTpr_Contratoclienteenderecobairro;
         n618ContratoClienteEnderecoBairro = false;
         A619ContratoClienteMunicipioCodigo = obj36.gxTpr_Contratoclientemunicipiocodigo;
         n619ContratoClienteMunicipioCodigo = false;
         A923ContratoPropostaId = obj36.gxTpr_Contratopropostaid;
         n923ContratoPropostaId = false;
         A1007ContratoCountAssinantes_F = obj36.gxTpr_Contratocountassinantes_f;
         n1007ContratoCountAssinantes_F = false;
         A227ContratoId = obj36.gxTpr_Contratoid;
         n227ContratoId = false;
         Z227ContratoId = obj36.gxTpr_Contratoid_Z;
         Z228ContratoNome = obj36.gxTpr_Contratonome_Z;
         Z361ContratoComVigencia = obj36.gxTpr_Contratocomvigencia_Z;
         Z362ContratoDataInicial = obj36.gxTpr_Contratodatainicial_Z;
         Z363ContratoDataFinal = obj36.gxTpr_Contratodatafinal_Z;
         Z473ContratoClienteId = obj36.gxTpr_Contratoclienteid_Z;
         Z474ContratoClienteNome = obj36.gxTpr_Contratoclientenome_Z;
         Z475ContratoClienteDocumento = obj36.gxTpr_Contratoclientedocumento_Z;
         Z476ContratoClienteRepresentanteNome = obj36.gxTpr_Contratoclienterepresentantenome_Z;
         Z477ContratoClienteRepresentanteCPF = obj36.gxTpr_Contratoclienterepresentantecpf_Z;
         Z561ContratoClienteTipoPessoa = obj36.gxTpr_Contratoclientetipopessoa_Z;
         Z460ContratoTaxa = obj36.gxTpr_Contratotaxa_Z;
         Z461ContratoSLA = obj36.gxTpr_Contratosla_Z;
         Z462ContratoJurosMora = obj36.gxTpr_Contratojurosmora_Z;
         Z463ContratoIOFMinimo = obj36.gxTpr_Contratoiofminimo_Z;
         Z471ContratoSituacao = obj36.gxTpr_Contratosituacao_Z;
         Z483AssinaturaUltId_F = obj36.gxTpr_Assinaturaultid_f_Z;
         Z614ContratoClienteEnderecoCEP = obj36.gxTpr_Contratoclienteenderecocep_Z;
         Z615ContratoClienteEnderecoLograodouro = obj36.gxTpr_Contratoclienteenderecolograodouro_Z;
         Z616ContratoClienteEnderecoNumero = obj36.gxTpr_Contratoclienteendereconumero_Z;
         Z617ContratoClienteEnderecoComplemento = obj36.gxTpr_Contratoclienteenderecocomplemento_Z;
         Z618ContratoClienteEnderecoBairro = obj36.gxTpr_Contratoclienteenderecobairro_Z;
         Z619ContratoClienteMunicipioCodigo = obj36.gxTpr_Contratoclientemunicipiocodigo_Z;
         Z923ContratoPropostaId = obj36.gxTpr_Contratopropostaid_Z;
         Z1007ContratoCountAssinantes_F = obj36.gxTpr_Contratocountassinantes_f_Z;
         n227ContratoId = (bool)(Convert.ToBoolean(obj36.gxTpr_Contratoid_N));
         n228ContratoNome = (bool)(Convert.ToBoolean(obj36.gxTpr_Contratonome_N));
         n339ContratoCorpo = (bool)(Convert.ToBoolean(obj36.gxTpr_Contratocorpo_N));
         n361ContratoComVigencia = (bool)(Convert.ToBoolean(obj36.gxTpr_Contratocomvigencia_N));
         n362ContratoDataInicial = (bool)(Convert.ToBoolean(obj36.gxTpr_Contratodatainicial_N));
         n363ContratoDataFinal = (bool)(Convert.ToBoolean(obj36.gxTpr_Contratodatafinal_N));
         n473ContratoClienteId = (bool)(Convert.ToBoolean(obj36.gxTpr_Contratoclienteid_N));
         n474ContratoClienteNome = (bool)(Convert.ToBoolean(obj36.gxTpr_Contratoclientenome_N));
         n475ContratoClienteDocumento = (bool)(Convert.ToBoolean(obj36.gxTpr_Contratoclientedocumento_N));
         n476ContratoClienteRepresentanteNome = (bool)(Convert.ToBoolean(obj36.gxTpr_Contratoclienterepresentantenome_N));
         n477ContratoClienteRepresentanteCPF = (bool)(Convert.ToBoolean(obj36.gxTpr_Contratoclienterepresentantecpf_N));
         n561ContratoClienteTipoPessoa = (bool)(Convert.ToBoolean(obj36.gxTpr_Contratoclientetipopessoa_N));
         n460ContratoTaxa = (bool)(Convert.ToBoolean(obj36.gxTpr_Contratotaxa_N));
         n461ContratoSLA = (bool)(Convert.ToBoolean(obj36.gxTpr_Contratosla_N));
         n462ContratoJurosMora = (bool)(Convert.ToBoolean(obj36.gxTpr_Contratojurosmora_N));
         n463ContratoIOFMinimo = (bool)(Convert.ToBoolean(obj36.gxTpr_Contratoiofminimo_N));
         n471ContratoSituacao = (bool)(Convert.ToBoolean(obj36.gxTpr_Contratosituacao_N));
         n472ContratoBlob = (bool)(Convert.ToBoolean(obj36.gxTpr_Contratoblob_N));
         n483AssinaturaUltId_F = (bool)(Convert.ToBoolean(obj36.gxTpr_Assinaturaultid_f_N));
         n614ContratoClienteEnderecoCEP = (bool)(Convert.ToBoolean(obj36.gxTpr_Contratoclienteenderecocep_N));
         n615ContratoClienteEnderecoLograodouro = (bool)(Convert.ToBoolean(obj36.gxTpr_Contratoclienteenderecolograodouro_N));
         n616ContratoClienteEnderecoNumero = (bool)(Convert.ToBoolean(obj36.gxTpr_Contratoclienteendereconumero_N));
         n617ContratoClienteEnderecoComplemento = (bool)(Convert.ToBoolean(obj36.gxTpr_Contratoclienteenderecocomplemento_N));
         n618ContratoClienteEnderecoBairro = (bool)(Convert.ToBoolean(obj36.gxTpr_Contratoclienteenderecobairro_N));
         n619ContratoClienteMunicipioCodigo = (bool)(Convert.ToBoolean(obj36.gxTpr_Contratoclientemunicipiocodigo_N));
         n923ContratoPropostaId = (bool)(Convert.ToBoolean(obj36.gxTpr_Contratopropostaid_N));
         n1007ContratoCountAssinantes_F = (bool)(Convert.ToBoolean(obj36.gxTpr_Contratocountassinantes_f_N));
         Gx_mode = obj36.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A227ContratoId = (int)getParm(obj,0);
         n227ContratoId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0X36( ) ;
         ScanKeyStart0X36( ) ;
         if ( RcdFound36 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z227ContratoId = A227ContratoId;
         }
         ZM0X36( -6) ;
         OnLoadActions0X36( ) ;
         AddRow0X36( ) ;
         ScanKeyEnd0X36( ) ;
         if ( RcdFound36 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars36( bcContrato, 0) ;
         ScanKeyStart0X36( ) ;
         if ( RcdFound36 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z227ContratoId = A227ContratoId;
         }
         ZM0X36( -6) ;
         OnLoadActions0X36( ) ;
         AddRow0X36( ) ;
         ScanKeyEnd0X36( ) ;
         if ( RcdFound36 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0X36( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0X36( ) ;
         }
         else
         {
            if ( RcdFound36 == 1 )
            {
               if ( A227ContratoId != Z227ContratoId )
               {
                  A227ContratoId = Z227ContratoId;
                  n227ContratoId = false;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update0X36( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A227ContratoId != Z227ContratoId )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert0X36( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert0X36( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars36( bcContrato, 1) ;
         SaveImpl( ) ;
         VarsToRow36( bcContrato) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars36( bcContrato, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0X36( ) ;
         AfterTrn( ) ;
         VarsToRow36( bcContrato) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow36( bcContrato) ;
         }
         else
         {
            SdtContrato auxBC = new SdtContrato(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A227ContratoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcContrato);
               auxBC.Save();
               bcContrato.Copy((GxSilentTrnSdt)(auxBC));
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars36( bcContrato, 1) ;
         UpdateImpl( ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars36( bcContrato, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0X36( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
            else
            {
               VarsToRow36( bcContrato) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow36( bcContrato) ;
         }
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars36( bcContrato, 0) ;
         GetKey0X36( ) ;
         if ( RcdFound36 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A227ContratoId != Z227ContratoId )
            {
               A227ContratoId = Z227ContratoId;
               n227ContratoId = false;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A227ContratoId != Z227ContratoId )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         context.RollbackDataStores("contrato_bc",pr_default);
         VarsToRow36( bcContrato) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcContrato.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcContrato.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcContrato )
         {
            bcContrato = (SdtContrato)(sdt);
            if ( StringUtil.StrCmp(bcContrato.gxTpr_Mode, "") == 0 )
            {
               bcContrato.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow36( bcContrato) ;
            }
            else
            {
               RowToVars36( bcContrato, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcContrato.gxTpr_Mode, "") == 0 )
            {
               bcContrato.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars36( bcContrato, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtContrato Contrato_BC
      {
         get {
            return bcContrato ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      public bool isMasterPage( )
      {
         return false;
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected override void CloseCursors( )
      {
         pr_default.close(1);
         pr_default.close(14);
         pr_default.close(13);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV16Pgmname = "";
         AV12TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z228ContratoNome = "";
         A228ContratoNome = "";
         Z362ContratoDataInicial = DateTime.MinValue;
         A362ContratoDataInicial = DateTime.MinValue;
         Z363ContratoDataFinal = DateTime.MinValue;
         A363ContratoDataFinal = DateTime.MinValue;
         Z471ContratoSituacao = "";
         A471ContratoSituacao = "";
         Z474ContratoClienteNome = "";
         A474ContratoClienteNome = "";
         Z475ContratoClienteDocumento = "";
         A475ContratoClienteDocumento = "";
         Z476ContratoClienteRepresentanteNome = "";
         A476ContratoClienteRepresentanteNome = "";
         Z477ContratoClienteRepresentanteCPF = "";
         A477ContratoClienteRepresentanteCPF = "";
         Z561ContratoClienteTipoPessoa = "";
         A561ContratoClienteTipoPessoa = "";
         Z614ContratoClienteEnderecoCEP = "";
         A614ContratoClienteEnderecoCEP = "";
         Z615ContratoClienteEnderecoLograodouro = "";
         A615ContratoClienteEnderecoLograodouro = "";
         Z616ContratoClienteEnderecoNumero = "";
         A616ContratoClienteEnderecoNumero = "";
         Z617ContratoClienteEnderecoComplemento = "";
         A617ContratoClienteEnderecoComplemento = "";
         Z618ContratoClienteEnderecoBairro = "";
         A618ContratoClienteEnderecoBairro = "";
         Z619ContratoClienteMunicipioCodigo = "";
         A619ContratoClienteMunicipioCodigo = "";
         Z339ContratoCorpo = "";
         A339ContratoCorpo = "";
         Z472ContratoBlob = "";
         A472ContratoBlob = "";
         BC000X12_A227ContratoId = new int[1] ;
         BC000X12_n227ContratoId = new bool[] {false} ;
         BC000X12_A228ContratoNome = new string[] {""} ;
         BC000X12_n228ContratoNome = new bool[] {false} ;
         BC000X12_A339ContratoCorpo = new string[] {""} ;
         BC000X12_n339ContratoCorpo = new bool[] {false} ;
         BC000X12_A361ContratoComVigencia = new bool[] {false} ;
         BC000X12_n361ContratoComVigencia = new bool[] {false} ;
         BC000X12_A362ContratoDataInicial = new DateTime[] {DateTime.MinValue} ;
         BC000X12_n362ContratoDataInicial = new bool[] {false} ;
         BC000X12_A363ContratoDataFinal = new DateTime[] {DateTime.MinValue} ;
         BC000X12_n363ContratoDataFinal = new bool[] {false} ;
         BC000X12_A474ContratoClienteNome = new string[] {""} ;
         BC000X12_n474ContratoClienteNome = new bool[] {false} ;
         BC000X12_A475ContratoClienteDocumento = new string[] {""} ;
         BC000X12_n475ContratoClienteDocumento = new bool[] {false} ;
         BC000X12_A476ContratoClienteRepresentanteNome = new string[] {""} ;
         BC000X12_n476ContratoClienteRepresentanteNome = new bool[] {false} ;
         BC000X12_A477ContratoClienteRepresentanteCPF = new string[] {""} ;
         BC000X12_n477ContratoClienteRepresentanteCPF = new bool[] {false} ;
         BC000X12_A561ContratoClienteTipoPessoa = new string[] {""} ;
         BC000X12_n561ContratoClienteTipoPessoa = new bool[] {false} ;
         BC000X12_A460ContratoTaxa = new decimal[1] ;
         BC000X12_n460ContratoTaxa = new bool[] {false} ;
         BC000X12_A461ContratoSLA = new short[1] ;
         BC000X12_n461ContratoSLA = new bool[] {false} ;
         BC000X12_A462ContratoJurosMora = new decimal[1] ;
         BC000X12_n462ContratoJurosMora = new bool[] {false} ;
         BC000X12_A463ContratoIOFMinimo = new decimal[1] ;
         BC000X12_n463ContratoIOFMinimo = new bool[] {false} ;
         BC000X12_A471ContratoSituacao = new string[] {""} ;
         BC000X12_n471ContratoSituacao = new bool[] {false} ;
         BC000X12_A614ContratoClienteEnderecoCEP = new string[] {""} ;
         BC000X12_n614ContratoClienteEnderecoCEP = new bool[] {false} ;
         BC000X12_A615ContratoClienteEnderecoLograodouro = new string[] {""} ;
         BC000X12_n615ContratoClienteEnderecoLograodouro = new bool[] {false} ;
         BC000X12_A616ContratoClienteEnderecoNumero = new string[] {""} ;
         BC000X12_n616ContratoClienteEnderecoNumero = new bool[] {false} ;
         BC000X12_A617ContratoClienteEnderecoComplemento = new string[] {""} ;
         BC000X12_n617ContratoClienteEnderecoComplemento = new bool[] {false} ;
         BC000X12_A618ContratoClienteEnderecoBairro = new string[] {""} ;
         BC000X12_n618ContratoClienteEnderecoBairro = new bool[] {false} ;
         BC000X12_A473ContratoClienteId = new int[1] ;
         BC000X12_n473ContratoClienteId = new bool[] {false} ;
         BC000X12_A923ContratoPropostaId = new int[1] ;
         BC000X12_n923ContratoPropostaId = new bool[] {false} ;
         BC000X12_A619ContratoClienteMunicipioCodigo = new string[] {""} ;
         BC000X12_n619ContratoClienteMunicipioCodigo = new bool[] {false} ;
         BC000X12_A483AssinaturaUltId_F = new short[1] ;
         BC000X12_n483AssinaturaUltId_F = new bool[] {false} ;
         BC000X12_A1007ContratoCountAssinantes_F = new short[1] ;
         BC000X12_n1007ContratoCountAssinantes_F = new bool[] {false} ;
         BC000X12_A472ContratoBlob = new string[] {""} ;
         BC000X12_n472ContratoBlob = new bool[] {false} ;
         BC000X7_A483AssinaturaUltId_F = new short[1] ;
         BC000X7_n483AssinaturaUltId_F = new bool[] {false} ;
         BC000X4_A474ContratoClienteNome = new string[] {""} ;
         BC000X4_n474ContratoClienteNome = new bool[] {false} ;
         BC000X4_A475ContratoClienteDocumento = new string[] {""} ;
         BC000X4_n475ContratoClienteDocumento = new bool[] {false} ;
         BC000X4_A476ContratoClienteRepresentanteNome = new string[] {""} ;
         BC000X4_n476ContratoClienteRepresentanteNome = new bool[] {false} ;
         BC000X4_A477ContratoClienteRepresentanteCPF = new string[] {""} ;
         BC000X4_n477ContratoClienteRepresentanteCPF = new bool[] {false} ;
         BC000X4_A561ContratoClienteTipoPessoa = new string[] {""} ;
         BC000X4_n561ContratoClienteTipoPessoa = new bool[] {false} ;
         BC000X4_A614ContratoClienteEnderecoCEP = new string[] {""} ;
         BC000X4_n614ContratoClienteEnderecoCEP = new bool[] {false} ;
         BC000X4_A615ContratoClienteEnderecoLograodouro = new string[] {""} ;
         BC000X4_n615ContratoClienteEnderecoLograodouro = new bool[] {false} ;
         BC000X4_A616ContratoClienteEnderecoNumero = new string[] {""} ;
         BC000X4_n616ContratoClienteEnderecoNumero = new bool[] {false} ;
         BC000X4_A617ContratoClienteEnderecoComplemento = new string[] {""} ;
         BC000X4_n617ContratoClienteEnderecoComplemento = new bool[] {false} ;
         BC000X4_A618ContratoClienteEnderecoBairro = new string[] {""} ;
         BC000X4_n618ContratoClienteEnderecoBairro = new bool[] {false} ;
         BC000X4_A619ContratoClienteMunicipioCodigo = new string[] {""} ;
         BC000X4_n619ContratoClienteMunicipioCodigo = new bool[] {false} ;
         BC000X9_A1007ContratoCountAssinantes_F = new short[1] ;
         BC000X9_n1007ContratoCountAssinantes_F = new bool[] {false} ;
         BC000X5_A923ContratoPropostaId = new int[1] ;
         BC000X5_n923ContratoPropostaId = new bool[] {false} ;
         BC000X13_A227ContratoId = new int[1] ;
         BC000X13_n227ContratoId = new bool[] {false} ;
         BC000X3_A227ContratoId = new int[1] ;
         BC000X3_n227ContratoId = new bool[] {false} ;
         BC000X3_A228ContratoNome = new string[] {""} ;
         BC000X3_n228ContratoNome = new bool[] {false} ;
         BC000X3_A339ContratoCorpo = new string[] {""} ;
         BC000X3_n339ContratoCorpo = new bool[] {false} ;
         BC000X3_A361ContratoComVigencia = new bool[] {false} ;
         BC000X3_n361ContratoComVigencia = new bool[] {false} ;
         BC000X3_A362ContratoDataInicial = new DateTime[] {DateTime.MinValue} ;
         BC000X3_n362ContratoDataInicial = new bool[] {false} ;
         BC000X3_A363ContratoDataFinal = new DateTime[] {DateTime.MinValue} ;
         BC000X3_n363ContratoDataFinal = new bool[] {false} ;
         BC000X3_A460ContratoTaxa = new decimal[1] ;
         BC000X3_n460ContratoTaxa = new bool[] {false} ;
         BC000X3_A461ContratoSLA = new short[1] ;
         BC000X3_n461ContratoSLA = new bool[] {false} ;
         BC000X3_A462ContratoJurosMora = new decimal[1] ;
         BC000X3_n462ContratoJurosMora = new bool[] {false} ;
         BC000X3_A463ContratoIOFMinimo = new decimal[1] ;
         BC000X3_n463ContratoIOFMinimo = new bool[] {false} ;
         BC000X3_A471ContratoSituacao = new string[] {""} ;
         BC000X3_n471ContratoSituacao = new bool[] {false} ;
         BC000X3_A473ContratoClienteId = new int[1] ;
         BC000X3_n473ContratoClienteId = new bool[] {false} ;
         BC000X3_A923ContratoPropostaId = new int[1] ;
         BC000X3_n923ContratoPropostaId = new bool[] {false} ;
         BC000X3_A472ContratoBlob = new string[] {""} ;
         BC000X3_n472ContratoBlob = new bool[] {false} ;
         sMode36 = "";
         BC000X2_A227ContratoId = new int[1] ;
         BC000X2_n227ContratoId = new bool[] {false} ;
         BC000X2_A228ContratoNome = new string[] {""} ;
         BC000X2_n228ContratoNome = new bool[] {false} ;
         BC000X2_A339ContratoCorpo = new string[] {""} ;
         BC000X2_n339ContratoCorpo = new bool[] {false} ;
         BC000X2_A361ContratoComVigencia = new bool[] {false} ;
         BC000X2_n361ContratoComVigencia = new bool[] {false} ;
         BC000X2_A362ContratoDataInicial = new DateTime[] {DateTime.MinValue} ;
         BC000X2_n362ContratoDataInicial = new bool[] {false} ;
         BC000X2_A363ContratoDataFinal = new DateTime[] {DateTime.MinValue} ;
         BC000X2_n363ContratoDataFinal = new bool[] {false} ;
         BC000X2_A460ContratoTaxa = new decimal[1] ;
         BC000X2_n460ContratoTaxa = new bool[] {false} ;
         BC000X2_A461ContratoSLA = new short[1] ;
         BC000X2_n461ContratoSLA = new bool[] {false} ;
         BC000X2_A462ContratoJurosMora = new decimal[1] ;
         BC000X2_n462ContratoJurosMora = new bool[] {false} ;
         BC000X2_A463ContratoIOFMinimo = new decimal[1] ;
         BC000X2_n463ContratoIOFMinimo = new bool[] {false} ;
         BC000X2_A471ContratoSituacao = new string[] {""} ;
         BC000X2_n471ContratoSituacao = new bool[] {false} ;
         BC000X2_A473ContratoClienteId = new int[1] ;
         BC000X2_n473ContratoClienteId = new bool[] {false} ;
         BC000X2_A923ContratoPropostaId = new int[1] ;
         BC000X2_n923ContratoPropostaId = new bool[] {false} ;
         BC000X2_A472ContratoBlob = new string[] {""} ;
         BC000X2_n472ContratoBlob = new bool[] {false} ;
         BC000X15_A227ContratoId = new int[1] ;
         BC000X15_n227ContratoId = new bool[] {false} ;
         BC000X20_A483AssinaturaUltId_F = new short[1] ;
         BC000X20_n483AssinaturaUltId_F = new bool[] {false} ;
         BC000X21_A474ContratoClienteNome = new string[] {""} ;
         BC000X21_n474ContratoClienteNome = new bool[] {false} ;
         BC000X21_A475ContratoClienteDocumento = new string[] {""} ;
         BC000X21_n475ContratoClienteDocumento = new bool[] {false} ;
         BC000X21_A476ContratoClienteRepresentanteNome = new string[] {""} ;
         BC000X21_n476ContratoClienteRepresentanteNome = new bool[] {false} ;
         BC000X21_A477ContratoClienteRepresentanteCPF = new string[] {""} ;
         BC000X21_n477ContratoClienteRepresentanteCPF = new bool[] {false} ;
         BC000X21_A561ContratoClienteTipoPessoa = new string[] {""} ;
         BC000X21_n561ContratoClienteTipoPessoa = new bool[] {false} ;
         BC000X21_A614ContratoClienteEnderecoCEP = new string[] {""} ;
         BC000X21_n614ContratoClienteEnderecoCEP = new bool[] {false} ;
         BC000X21_A615ContratoClienteEnderecoLograodouro = new string[] {""} ;
         BC000X21_n615ContratoClienteEnderecoLograodouro = new bool[] {false} ;
         BC000X21_A616ContratoClienteEnderecoNumero = new string[] {""} ;
         BC000X21_n616ContratoClienteEnderecoNumero = new bool[] {false} ;
         BC000X21_A617ContratoClienteEnderecoComplemento = new string[] {""} ;
         BC000X21_n617ContratoClienteEnderecoComplemento = new bool[] {false} ;
         BC000X21_A618ContratoClienteEnderecoBairro = new string[] {""} ;
         BC000X21_n618ContratoClienteEnderecoBairro = new bool[] {false} ;
         BC000X21_A619ContratoClienteMunicipioCodigo = new string[] {""} ;
         BC000X21_n619ContratoClienteMunicipioCodigo = new bool[] {false} ;
         BC000X23_A1007ContratoCountAssinantes_F = new short[1] ;
         BC000X23_n1007ContratoCountAssinantes_F = new bool[] {false} ;
         BC000X24_A572PropostaContratoAssinaturaId = new int[1] ;
         BC000X25_A1010OperacoesId = new int[1] ;
         BC000X26_A323PropostaId = new int[1] ;
         BC000X27_A238AssinaturaId = new long[1] ;
         BC000X27_n238AssinaturaId = new bool[] {false} ;
         BC000X28_A237ContratoParticipanteId = new int[1] ;
         BC000X31_A227ContratoId = new int[1] ;
         BC000X31_n227ContratoId = new bool[] {false} ;
         BC000X31_A228ContratoNome = new string[] {""} ;
         BC000X31_n228ContratoNome = new bool[] {false} ;
         BC000X31_A339ContratoCorpo = new string[] {""} ;
         BC000X31_n339ContratoCorpo = new bool[] {false} ;
         BC000X31_A361ContratoComVigencia = new bool[] {false} ;
         BC000X31_n361ContratoComVigencia = new bool[] {false} ;
         BC000X31_A362ContratoDataInicial = new DateTime[] {DateTime.MinValue} ;
         BC000X31_n362ContratoDataInicial = new bool[] {false} ;
         BC000X31_A363ContratoDataFinal = new DateTime[] {DateTime.MinValue} ;
         BC000X31_n363ContratoDataFinal = new bool[] {false} ;
         BC000X31_A474ContratoClienteNome = new string[] {""} ;
         BC000X31_n474ContratoClienteNome = new bool[] {false} ;
         BC000X31_A475ContratoClienteDocumento = new string[] {""} ;
         BC000X31_n475ContratoClienteDocumento = new bool[] {false} ;
         BC000X31_A476ContratoClienteRepresentanteNome = new string[] {""} ;
         BC000X31_n476ContratoClienteRepresentanteNome = new bool[] {false} ;
         BC000X31_A477ContratoClienteRepresentanteCPF = new string[] {""} ;
         BC000X31_n477ContratoClienteRepresentanteCPF = new bool[] {false} ;
         BC000X31_A561ContratoClienteTipoPessoa = new string[] {""} ;
         BC000X31_n561ContratoClienteTipoPessoa = new bool[] {false} ;
         BC000X31_A460ContratoTaxa = new decimal[1] ;
         BC000X31_n460ContratoTaxa = new bool[] {false} ;
         BC000X31_A461ContratoSLA = new short[1] ;
         BC000X31_n461ContratoSLA = new bool[] {false} ;
         BC000X31_A462ContratoJurosMora = new decimal[1] ;
         BC000X31_n462ContratoJurosMora = new bool[] {false} ;
         BC000X31_A463ContratoIOFMinimo = new decimal[1] ;
         BC000X31_n463ContratoIOFMinimo = new bool[] {false} ;
         BC000X31_A471ContratoSituacao = new string[] {""} ;
         BC000X31_n471ContratoSituacao = new bool[] {false} ;
         BC000X31_A614ContratoClienteEnderecoCEP = new string[] {""} ;
         BC000X31_n614ContratoClienteEnderecoCEP = new bool[] {false} ;
         BC000X31_A615ContratoClienteEnderecoLograodouro = new string[] {""} ;
         BC000X31_n615ContratoClienteEnderecoLograodouro = new bool[] {false} ;
         BC000X31_A616ContratoClienteEnderecoNumero = new string[] {""} ;
         BC000X31_n616ContratoClienteEnderecoNumero = new bool[] {false} ;
         BC000X31_A617ContratoClienteEnderecoComplemento = new string[] {""} ;
         BC000X31_n617ContratoClienteEnderecoComplemento = new bool[] {false} ;
         BC000X31_A618ContratoClienteEnderecoBairro = new string[] {""} ;
         BC000X31_n618ContratoClienteEnderecoBairro = new bool[] {false} ;
         BC000X31_A473ContratoClienteId = new int[1] ;
         BC000X31_n473ContratoClienteId = new bool[] {false} ;
         BC000X31_A923ContratoPropostaId = new int[1] ;
         BC000X31_n923ContratoPropostaId = new bool[] {false} ;
         BC000X31_A619ContratoClienteMunicipioCodigo = new string[] {""} ;
         BC000X31_n619ContratoClienteMunicipioCodigo = new bool[] {false} ;
         BC000X31_A483AssinaturaUltId_F = new short[1] ;
         BC000X31_n483AssinaturaUltId_F = new bool[] {false} ;
         BC000X31_A1007ContratoCountAssinantes_F = new short[1] ;
         BC000X31_n1007ContratoCountAssinantes_F = new bool[] {false} ;
         BC000X31_A472ContratoBlob = new string[] {""} ;
         BC000X31_n472ContratoBlob = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contrato_bc__default(),
            new Object[][] {
                new Object[] {
               BC000X2_A227ContratoId, BC000X2_A228ContratoNome, BC000X2_n228ContratoNome, BC000X2_A339ContratoCorpo, BC000X2_n339ContratoCorpo, BC000X2_A361ContratoComVigencia, BC000X2_n361ContratoComVigencia, BC000X2_A362ContratoDataInicial, BC000X2_n362ContratoDataInicial, BC000X2_A363ContratoDataFinal,
               BC000X2_n363ContratoDataFinal, BC000X2_A460ContratoTaxa, BC000X2_n460ContratoTaxa, BC000X2_A461ContratoSLA, BC000X2_n461ContratoSLA, BC000X2_A462ContratoJurosMora, BC000X2_n462ContratoJurosMora, BC000X2_A463ContratoIOFMinimo, BC000X2_n463ContratoIOFMinimo, BC000X2_A471ContratoSituacao,
               BC000X2_n471ContratoSituacao, BC000X2_A473ContratoClienteId, BC000X2_n473ContratoClienteId, BC000X2_A923ContratoPropostaId, BC000X2_n923ContratoPropostaId, BC000X2_A472ContratoBlob, BC000X2_n472ContratoBlob
               }
               , new Object[] {
               BC000X3_A227ContratoId, BC000X3_A228ContratoNome, BC000X3_n228ContratoNome, BC000X3_A339ContratoCorpo, BC000X3_n339ContratoCorpo, BC000X3_A361ContratoComVigencia, BC000X3_n361ContratoComVigencia, BC000X3_A362ContratoDataInicial, BC000X3_n362ContratoDataInicial, BC000X3_A363ContratoDataFinal,
               BC000X3_n363ContratoDataFinal, BC000X3_A460ContratoTaxa, BC000X3_n460ContratoTaxa, BC000X3_A461ContratoSLA, BC000X3_n461ContratoSLA, BC000X3_A462ContratoJurosMora, BC000X3_n462ContratoJurosMora, BC000X3_A463ContratoIOFMinimo, BC000X3_n463ContratoIOFMinimo, BC000X3_A471ContratoSituacao,
               BC000X3_n471ContratoSituacao, BC000X3_A473ContratoClienteId, BC000X3_n473ContratoClienteId, BC000X3_A923ContratoPropostaId, BC000X3_n923ContratoPropostaId, BC000X3_A472ContratoBlob, BC000X3_n472ContratoBlob
               }
               , new Object[] {
               BC000X4_A474ContratoClienteNome, BC000X4_n474ContratoClienteNome, BC000X4_A475ContratoClienteDocumento, BC000X4_n475ContratoClienteDocumento, BC000X4_A476ContratoClienteRepresentanteNome, BC000X4_n476ContratoClienteRepresentanteNome, BC000X4_A477ContratoClienteRepresentanteCPF, BC000X4_n477ContratoClienteRepresentanteCPF, BC000X4_A561ContratoClienteTipoPessoa, BC000X4_n561ContratoClienteTipoPessoa,
               BC000X4_A614ContratoClienteEnderecoCEP, BC000X4_n614ContratoClienteEnderecoCEP, BC000X4_A615ContratoClienteEnderecoLograodouro, BC000X4_n615ContratoClienteEnderecoLograodouro, BC000X4_A616ContratoClienteEnderecoNumero, BC000X4_n616ContratoClienteEnderecoNumero, BC000X4_A617ContratoClienteEnderecoComplemento, BC000X4_n617ContratoClienteEnderecoComplemento, BC000X4_A618ContratoClienteEnderecoBairro, BC000X4_n618ContratoClienteEnderecoBairro,
               BC000X4_A619ContratoClienteMunicipioCodigo, BC000X4_n619ContratoClienteMunicipioCodigo
               }
               , new Object[] {
               BC000X5_A923ContratoPropostaId
               }
               , new Object[] {
               BC000X7_A483AssinaturaUltId_F, BC000X7_n483AssinaturaUltId_F
               }
               , new Object[] {
               BC000X9_A1007ContratoCountAssinantes_F, BC000X9_n1007ContratoCountAssinantes_F
               }
               , new Object[] {
               BC000X12_A227ContratoId, BC000X12_A228ContratoNome, BC000X12_n228ContratoNome, BC000X12_A339ContratoCorpo, BC000X12_n339ContratoCorpo, BC000X12_A361ContratoComVigencia, BC000X12_n361ContratoComVigencia, BC000X12_A362ContratoDataInicial, BC000X12_n362ContratoDataInicial, BC000X12_A363ContratoDataFinal,
               BC000X12_n363ContratoDataFinal, BC000X12_A474ContratoClienteNome, BC000X12_n474ContratoClienteNome, BC000X12_A475ContratoClienteDocumento, BC000X12_n475ContratoClienteDocumento, BC000X12_A476ContratoClienteRepresentanteNome, BC000X12_n476ContratoClienteRepresentanteNome, BC000X12_A477ContratoClienteRepresentanteCPF, BC000X12_n477ContratoClienteRepresentanteCPF, BC000X12_A561ContratoClienteTipoPessoa,
               BC000X12_n561ContratoClienteTipoPessoa, BC000X12_A460ContratoTaxa, BC000X12_n460ContratoTaxa, BC000X12_A461ContratoSLA, BC000X12_n461ContratoSLA, BC000X12_A462ContratoJurosMora, BC000X12_n462ContratoJurosMora, BC000X12_A463ContratoIOFMinimo, BC000X12_n463ContratoIOFMinimo, BC000X12_A471ContratoSituacao,
               BC000X12_n471ContratoSituacao, BC000X12_A614ContratoClienteEnderecoCEP, BC000X12_n614ContratoClienteEnderecoCEP, BC000X12_A615ContratoClienteEnderecoLograodouro, BC000X12_n615ContratoClienteEnderecoLograodouro, BC000X12_A616ContratoClienteEnderecoNumero, BC000X12_n616ContratoClienteEnderecoNumero, BC000X12_A617ContratoClienteEnderecoComplemento, BC000X12_n617ContratoClienteEnderecoComplemento, BC000X12_A618ContratoClienteEnderecoBairro,
               BC000X12_n618ContratoClienteEnderecoBairro, BC000X12_A473ContratoClienteId, BC000X12_n473ContratoClienteId, BC000X12_A923ContratoPropostaId, BC000X12_n923ContratoPropostaId, BC000X12_A619ContratoClienteMunicipioCodigo, BC000X12_n619ContratoClienteMunicipioCodigo, BC000X12_A483AssinaturaUltId_F, BC000X12_n483AssinaturaUltId_F, BC000X12_A1007ContratoCountAssinantes_F,
               BC000X12_n1007ContratoCountAssinantes_F, BC000X12_A472ContratoBlob, BC000X12_n472ContratoBlob
               }
               , new Object[] {
               BC000X13_A227ContratoId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000X15_A227ContratoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000X20_A483AssinaturaUltId_F, BC000X20_n483AssinaturaUltId_F
               }
               , new Object[] {
               BC000X21_A474ContratoClienteNome, BC000X21_n474ContratoClienteNome, BC000X21_A475ContratoClienteDocumento, BC000X21_n475ContratoClienteDocumento, BC000X21_A476ContratoClienteRepresentanteNome, BC000X21_n476ContratoClienteRepresentanteNome, BC000X21_A477ContratoClienteRepresentanteCPF, BC000X21_n477ContratoClienteRepresentanteCPF, BC000X21_A561ContratoClienteTipoPessoa, BC000X21_n561ContratoClienteTipoPessoa,
               BC000X21_A614ContratoClienteEnderecoCEP, BC000X21_n614ContratoClienteEnderecoCEP, BC000X21_A615ContratoClienteEnderecoLograodouro, BC000X21_n615ContratoClienteEnderecoLograodouro, BC000X21_A616ContratoClienteEnderecoNumero, BC000X21_n616ContratoClienteEnderecoNumero, BC000X21_A617ContratoClienteEnderecoComplemento, BC000X21_n617ContratoClienteEnderecoComplemento, BC000X21_A618ContratoClienteEnderecoBairro, BC000X21_n618ContratoClienteEnderecoBairro,
               BC000X21_A619ContratoClienteMunicipioCodigo, BC000X21_n619ContratoClienteMunicipioCodigo
               }
               , new Object[] {
               BC000X23_A1007ContratoCountAssinantes_F, BC000X23_n1007ContratoCountAssinantes_F
               }
               , new Object[] {
               BC000X24_A572PropostaContratoAssinaturaId
               }
               , new Object[] {
               BC000X25_A1010OperacoesId
               }
               , new Object[] {
               BC000X26_A323PropostaId
               }
               , new Object[] {
               BC000X27_A238AssinaturaId
               }
               , new Object[] {
               BC000X28_A237ContratoParticipanteId
               }
               , new Object[] {
               BC000X31_A227ContratoId, BC000X31_A228ContratoNome, BC000X31_n228ContratoNome, BC000X31_A339ContratoCorpo, BC000X31_n339ContratoCorpo, BC000X31_A361ContratoComVigencia, BC000X31_n361ContratoComVigencia, BC000X31_A362ContratoDataInicial, BC000X31_n362ContratoDataInicial, BC000X31_A363ContratoDataFinal,
               BC000X31_n363ContratoDataFinal, BC000X31_A474ContratoClienteNome, BC000X31_n474ContratoClienteNome, BC000X31_A475ContratoClienteDocumento, BC000X31_n475ContratoClienteDocumento, BC000X31_A476ContratoClienteRepresentanteNome, BC000X31_n476ContratoClienteRepresentanteNome, BC000X31_A477ContratoClienteRepresentanteCPF, BC000X31_n477ContratoClienteRepresentanteCPF, BC000X31_A561ContratoClienteTipoPessoa,
               BC000X31_n561ContratoClienteTipoPessoa, BC000X31_A460ContratoTaxa, BC000X31_n460ContratoTaxa, BC000X31_A461ContratoSLA, BC000X31_n461ContratoSLA, BC000X31_A462ContratoJurosMora, BC000X31_n462ContratoJurosMora, BC000X31_A463ContratoIOFMinimo, BC000X31_n463ContratoIOFMinimo, BC000X31_A471ContratoSituacao,
               BC000X31_n471ContratoSituacao, BC000X31_A614ContratoClienteEnderecoCEP, BC000X31_n614ContratoClienteEnderecoCEP, BC000X31_A615ContratoClienteEnderecoLograodouro, BC000X31_n615ContratoClienteEnderecoLograodouro, BC000X31_A616ContratoClienteEnderecoNumero, BC000X31_n616ContratoClienteEnderecoNumero, BC000X31_A617ContratoClienteEnderecoComplemento, BC000X31_n617ContratoClienteEnderecoComplemento, BC000X31_A618ContratoClienteEnderecoBairro,
               BC000X31_n618ContratoClienteEnderecoBairro, BC000X31_A473ContratoClienteId, BC000X31_n473ContratoClienteId, BC000X31_A923ContratoPropostaId, BC000X31_n923ContratoPropostaId, BC000X31_A619ContratoClienteMunicipioCodigo, BC000X31_n619ContratoClienteMunicipioCodigo, BC000X31_A483AssinaturaUltId_F, BC000X31_n483AssinaturaUltId_F, BC000X31_A1007ContratoCountAssinantes_F,
               BC000X31_n1007ContratoCountAssinantes_F, BC000X31_A472ContratoBlob, BC000X31_n472ContratoBlob
               }
            }
         );
         AV16Pgmname = "Contrato_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120X2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z461ContratoSLA ;
      private short A461ContratoSLA ;
      private short Z483AssinaturaUltId_F ;
      private short A483AssinaturaUltId_F ;
      private short Z1007ContratoCountAssinantes_F ;
      private short A1007ContratoCountAssinantes_F ;
      private short RcdFound36 ;
      private int trnEnded ;
      private int Z227ContratoId ;
      private int A227ContratoId ;
      private int AV17GXV1 ;
      private int AV14Insert_ContratoClienteId ;
      private int AV15Insert_ContratoPropostaId ;
      private int Z473ContratoClienteId ;
      private int A473ContratoClienteId ;
      private int Z923ContratoPropostaId ;
      private int A923ContratoPropostaId ;
      private decimal Z460ContratoTaxa ;
      private decimal A460ContratoTaxa ;
      private decimal Z462ContratoJurosMora ;
      private decimal A462ContratoJurosMora ;
      private decimal Z463ContratoIOFMinimo ;
      private decimal A463ContratoIOFMinimo ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV16Pgmname ;
      private string sMode36 ;
      private DateTime Z362ContratoDataInicial ;
      private DateTime A362ContratoDataInicial ;
      private DateTime Z363ContratoDataFinal ;
      private DateTime A363ContratoDataFinal ;
      private bool returnInSub ;
      private bool Z361ContratoComVigencia ;
      private bool A361ContratoComVigencia ;
      private bool n227ContratoId ;
      private bool n228ContratoNome ;
      private bool n339ContratoCorpo ;
      private bool n361ContratoComVigencia ;
      private bool n362ContratoDataInicial ;
      private bool n363ContratoDataFinal ;
      private bool n474ContratoClienteNome ;
      private bool n475ContratoClienteDocumento ;
      private bool n476ContratoClienteRepresentanteNome ;
      private bool n477ContratoClienteRepresentanteCPF ;
      private bool n561ContratoClienteTipoPessoa ;
      private bool n460ContratoTaxa ;
      private bool n461ContratoSLA ;
      private bool n462ContratoJurosMora ;
      private bool n463ContratoIOFMinimo ;
      private bool n471ContratoSituacao ;
      private bool n614ContratoClienteEnderecoCEP ;
      private bool n615ContratoClienteEnderecoLograodouro ;
      private bool n616ContratoClienteEnderecoNumero ;
      private bool n617ContratoClienteEnderecoComplemento ;
      private bool n618ContratoClienteEnderecoBairro ;
      private bool n473ContratoClienteId ;
      private bool n923ContratoPropostaId ;
      private bool n619ContratoClienteMunicipioCodigo ;
      private bool n483AssinaturaUltId_F ;
      private bool n1007ContratoCountAssinantes_F ;
      private bool n472ContratoBlob ;
      private bool Gx_longc ;
      private string Z339ContratoCorpo ;
      private string A339ContratoCorpo ;
      private string Z228ContratoNome ;
      private string A228ContratoNome ;
      private string Z471ContratoSituacao ;
      private string A471ContratoSituacao ;
      private string Z474ContratoClienteNome ;
      private string A474ContratoClienteNome ;
      private string Z475ContratoClienteDocumento ;
      private string A475ContratoClienteDocumento ;
      private string Z476ContratoClienteRepresentanteNome ;
      private string A476ContratoClienteRepresentanteNome ;
      private string Z477ContratoClienteRepresentanteCPF ;
      private string A477ContratoClienteRepresentanteCPF ;
      private string Z561ContratoClienteTipoPessoa ;
      private string A561ContratoClienteTipoPessoa ;
      private string Z614ContratoClienteEnderecoCEP ;
      private string A614ContratoClienteEnderecoCEP ;
      private string Z615ContratoClienteEnderecoLograodouro ;
      private string A615ContratoClienteEnderecoLograodouro ;
      private string Z616ContratoClienteEnderecoNumero ;
      private string A616ContratoClienteEnderecoNumero ;
      private string Z617ContratoClienteEnderecoComplemento ;
      private string A617ContratoClienteEnderecoComplemento ;
      private string Z618ContratoClienteEnderecoBairro ;
      private string A618ContratoClienteEnderecoBairro ;
      private string Z619ContratoClienteMunicipioCodigo ;
      private string A619ContratoClienteMunicipioCodigo ;
      private string Z472ContratoBlob ;
      private string A472ContratoBlob ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] BC000X12_A227ContratoId ;
      private bool[] BC000X12_n227ContratoId ;
      private string[] BC000X12_A228ContratoNome ;
      private bool[] BC000X12_n228ContratoNome ;
      private string[] BC000X12_A339ContratoCorpo ;
      private bool[] BC000X12_n339ContratoCorpo ;
      private bool[] BC000X12_A361ContratoComVigencia ;
      private bool[] BC000X12_n361ContratoComVigencia ;
      private DateTime[] BC000X12_A362ContratoDataInicial ;
      private bool[] BC000X12_n362ContratoDataInicial ;
      private DateTime[] BC000X12_A363ContratoDataFinal ;
      private bool[] BC000X12_n363ContratoDataFinal ;
      private string[] BC000X12_A474ContratoClienteNome ;
      private bool[] BC000X12_n474ContratoClienteNome ;
      private string[] BC000X12_A475ContratoClienteDocumento ;
      private bool[] BC000X12_n475ContratoClienteDocumento ;
      private string[] BC000X12_A476ContratoClienteRepresentanteNome ;
      private bool[] BC000X12_n476ContratoClienteRepresentanteNome ;
      private string[] BC000X12_A477ContratoClienteRepresentanteCPF ;
      private bool[] BC000X12_n477ContratoClienteRepresentanteCPF ;
      private string[] BC000X12_A561ContratoClienteTipoPessoa ;
      private bool[] BC000X12_n561ContratoClienteTipoPessoa ;
      private decimal[] BC000X12_A460ContratoTaxa ;
      private bool[] BC000X12_n460ContratoTaxa ;
      private short[] BC000X12_A461ContratoSLA ;
      private bool[] BC000X12_n461ContratoSLA ;
      private decimal[] BC000X12_A462ContratoJurosMora ;
      private bool[] BC000X12_n462ContratoJurosMora ;
      private decimal[] BC000X12_A463ContratoIOFMinimo ;
      private bool[] BC000X12_n463ContratoIOFMinimo ;
      private string[] BC000X12_A471ContratoSituacao ;
      private bool[] BC000X12_n471ContratoSituacao ;
      private string[] BC000X12_A614ContratoClienteEnderecoCEP ;
      private bool[] BC000X12_n614ContratoClienteEnderecoCEP ;
      private string[] BC000X12_A615ContratoClienteEnderecoLograodouro ;
      private bool[] BC000X12_n615ContratoClienteEnderecoLograodouro ;
      private string[] BC000X12_A616ContratoClienteEnderecoNumero ;
      private bool[] BC000X12_n616ContratoClienteEnderecoNumero ;
      private string[] BC000X12_A617ContratoClienteEnderecoComplemento ;
      private bool[] BC000X12_n617ContratoClienteEnderecoComplemento ;
      private string[] BC000X12_A618ContratoClienteEnderecoBairro ;
      private bool[] BC000X12_n618ContratoClienteEnderecoBairro ;
      private int[] BC000X12_A473ContratoClienteId ;
      private bool[] BC000X12_n473ContratoClienteId ;
      private int[] BC000X12_A923ContratoPropostaId ;
      private bool[] BC000X12_n923ContratoPropostaId ;
      private string[] BC000X12_A619ContratoClienteMunicipioCodigo ;
      private bool[] BC000X12_n619ContratoClienteMunicipioCodigo ;
      private short[] BC000X12_A483AssinaturaUltId_F ;
      private bool[] BC000X12_n483AssinaturaUltId_F ;
      private short[] BC000X12_A1007ContratoCountAssinantes_F ;
      private bool[] BC000X12_n1007ContratoCountAssinantes_F ;
      private string[] BC000X12_A472ContratoBlob ;
      private bool[] BC000X12_n472ContratoBlob ;
      private short[] BC000X7_A483AssinaturaUltId_F ;
      private bool[] BC000X7_n483AssinaturaUltId_F ;
      private string[] BC000X4_A474ContratoClienteNome ;
      private bool[] BC000X4_n474ContratoClienteNome ;
      private string[] BC000X4_A475ContratoClienteDocumento ;
      private bool[] BC000X4_n475ContratoClienteDocumento ;
      private string[] BC000X4_A476ContratoClienteRepresentanteNome ;
      private bool[] BC000X4_n476ContratoClienteRepresentanteNome ;
      private string[] BC000X4_A477ContratoClienteRepresentanteCPF ;
      private bool[] BC000X4_n477ContratoClienteRepresentanteCPF ;
      private string[] BC000X4_A561ContratoClienteTipoPessoa ;
      private bool[] BC000X4_n561ContratoClienteTipoPessoa ;
      private string[] BC000X4_A614ContratoClienteEnderecoCEP ;
      private bool[] BC000X4_n614ContratoClienteEnderecoCEP ;
      private string[] BC000X4_A615ContratoClienteEnderecoLograodouro ;
      private bool[] BC000X4_n615ContratoClienteEnderecoLograodouro ;
      private string[] BC000X4_A616ContratoClienteEnderecoNumero ;
      private bool[] BC000X4_n616ContratoClienteEnderecoNumero ;
      private string[] BC000X4_A617ContratoClienteEnderecoComplemento ;
      private bool[] BC000X4_n617ContratoClienteEnderecoComplemento ;
      private string[] BC000X4_A618ContratoClienteEnderecoBairro ;
      private bool[] BC000X4_n618ContratoClienteEnderecoBairro ;
      private string[] BC000X4_A619ContratoClienteMunicipioCodigo ;
      private bool[] BC000X4_n619ContratoClienteMunicipioCodigo ;
      private short[] BC000X9_A1007ContratoCountAssinantes_F ;
      private bool[] BC000X9_n1007ContratoCountAssinantes_F ;
      private int[] BC000X5_A923ContratoPropostaId ;
      private bool[] BC000X5_n923ContratoPropostaId ;
      private int[] BC000X13_A227ContratoId ;
      private bool[] BC000X13_n227ContratoId ;
      private int[] BC000X3_A227ContratoId ;
      private bool[] BC000X3_n227ContratoId ;
      private string[] BC000X3_A228ContratoNome ;
      private bool[] BC000X3_n228ContratoNome ;
      private string[] BC000X3_A339ContratoCorpo ;
      private bool[] BC000X3_n339ContratoCorpo ;
      private bool[] BC000X3_A361ContratoComVigencia ;
      private bool[] BC000X3_n361ContratoComVigencia ;
      private DateTime[] BC000X3_A362ContratoDataInicial ;
      private bool[] BC000X3_n362ContratoDataInicial ;
      private DateTime[] BC000X3_A363ContratoDataFinal ;
      private bool[] BC000X3_n363ContratoDataFinal ;
      private decimal[] BC000X3_A460ContratoTaxa ;
      private bool[] BC000X3_n460ContratoTaxa ;
      private short[] BC000X3_A461ContratoSLA ;
      private bool[] BC000X3_n461ContratoSLA ;
      private decimal[] BC000X3_A462ContratoJurosMora ;
      private bool[] BC000X3_n462ContratoJurosMora ;
      private decimal[] BC000X3_A463ContratoIOFMinimo ;
      private bool[] BC000X3_n463ContratoIOFMinimo ;
      private string[] BC000X3_A471ContratoSituacao ;
      private bool[] BC000X3_n471ContratoSituacao ;
      private int[] BC000X3_A473ContratoClienteId ;
      private bool[] BC000X3_n473ContratoClienteId ;
      private int[] BC000X3_A923ContratoPropostaId ;
      private bool[] BC000X3_n923ContratoPropostaId ;
      private string[] BC000X3_A472ContratoBlob ;
      private bool[] BC000X3_n472ContratoBlob ;
      private int[] BC000X2_A227ContratoId ;
      private bool[] BC000X2_n227ContratoId ;
      private string[] BC000X2_A228ContratoNome ;
      private bool[] BC000X2_n228ContratoNome ;
      private string[] BC000X2_A339ContratoCorpo ;
      private bool[] BC000X2_n339ContratoCorpo ;
      private bool[] BC000X2_A361ContratoComVigencia ;
      private bool[] BC000X2_n361ContratoComVigencia ;
      private DateTime[] BC000X2_A362ContratoDataInicial ;
      private bool[] BC000X2_n362ContratoDataInicial ;
      private DateTime[] BC000X2_A363ContratoDataFinal ;
      private bool[] BC000X2_n363ContratoDataFinal ;
      private decimal[] BC000X2_A460ContratoTaxa ;
      private bool[] BC000X2_n460ContratoTaxa ;
      private short[] BC000X2_A461ContratoSLA ;
      private bool[] BC000X2_n461ContratoSLA ;
      private decimal[] BC000X2_A462ContratoJurosMora ;
      private bool[] BC000X2_n462ContratoJurosMora ;
      private decimal[] BC000X2_A463ContratoIOFMinimo ;
      private bool[] BC000X2_n463ContratoIOFMinimo ;
      private string[] BC000X2_A471ContratoSituacao ;
      private bool[] BC000X2_n471ContratoSituacao ;
      private int[] BC000X2_A473ContratoClienteId ;
      private bool[] BC000X2_n473ContratoClienteId ;
      private int[] BC000X2_A923ContratoPropostaId ;
      private bool[] BC000X2_n923ContratoPropostaId ;
      private string[] BC000X2_A472ContratoBlob ;
      private bool[] BC000X2_n472ContratoBlob ;
      private int[] BC000X15_A227ContratoId ;
      private bool[] BC000X15_n227ContratoId ;
      private short[] BC000X20_A483AssinaturaUltId_F ;
      private bool[] BC000X20_n483AssinaturaUltId_F ;
      private string[] BC000X21_A474ContratoClienteNome ;
      private bool[] BC000X21_n474ContratoClienteNome ;
      private string[] BC000X21_A475ContratoClienteDocumento ;
      private bool[] BC000X21_n475ContratoClienteDocumento ;
      private string[] BC000X21_A476ContratoClienteRepresentanteNome ;
      private bool[] BC000X21_n476ContratoClienteRepresentanteNome ;
      private string[] BC000X21_A477ContratoClienteRepresentanteCPF ;
      private bool[] BC000X21_n477ContratoClienteRepresentanteCPF ;
      private string[] BC000X21_A561ContratoClienteTipoPessoa ;
      private bool[] BC000X21_n561ContratoClienteTipoPessoa ;
      private string[] BC000X21_A614ContratoClienteEnderecoCEP ;
      private bool[] BC000X21_n614ContratoClienteEnderecoCEP ;
      private string[] BC000X21_A615ContratoClienteEnderecoLograodouro ;
      private bool[] BC000X21_n615ContratoClienteEnderecoLograodouro ;
      private string[] BC000X21_A616ContratoClienteEnderecoNumero ;
      private bool[] BC000X21_n616ContratoClienteEnderecoNumero ;
      private string[] BC000X21_A617ContratoClienteEnderecoComplemento ;
      private bool[] BC000X21_n617ContratoClienteEnderecoComplemento ;
      private string[] BC000X21_A618ContratoClienteEnderecoBairro ;
      private bool[] BC000X21_n618ContratoClienteEnderecoBairro ;
      private string[] BC000X21_A619ContratoClienteMunicipioCodigo ;
      private bool[] BC000X21_n619ContratoClienteMunicipioCodigo ;
      private short[] BC000X23_A1007ContratoCountAssinantes_F ;
      private bool[] BC000X23_n1007ContratoCountAssinantes_F ;
      private int[] BC000X24_A572PropostaContratoAssinaturaId ;
      private int[] BC000X25_A1010OperacoesId ;
      private int[] BC000X26_A323PropostaId ;
      private long[] BC000X27_A238AssinaturaId ;
      private bool[] BC000X27_n238AssinaturaId ;
      private int[] BC000X28_A237ContratoParticipanteId ;
      private int[] BC000X31_A227ContratoId ;
      private bool[] BC000X31_n227ContratoId ;
      private string[] BC000X31_A228ContratoNome ;
      private bool[] BC000X31_n228ContratoNome ;
      private string[] BC000X31_A339ContratoCorpo ;
      private bool[] BC000X31_n339ContratoCorpo ;
      private bool[] BC000X31_A361ContratoComVigencia ;
      private bool[] BC000X31_n361ContratoComVigencia ;
      private DateTime[] BC000X31_A362ContratoDataInicial ;
      private bool[] BC000X31_n362ContratoDataInicial ;
      private DateTime[] BC000X31_A363ContratoDataFinal ;
      private bool[] BC000X31_n363ContratoDataFinal ;
      private string[] BC000X31_A474ContratoClienteNome ;
      private bool[] BC000X31_n474ContratoClienteNome ;
      private string[] BC000X31_A475ContratoClienteDocumento ;
      private bool[] BC000X31_n475ContratoClienteDocumento ;
      private string[] BC000X31_A476ContratoClienteRepresentanteNome ;
      private bool[] BC000X31_n476ContratoClienteRepresentanteNome ;
      private string[] BC000X31_A477ContratoClienteRepresentanteCPF ;
      private bool[] BC000X31_n477ContratoClienteRepresentanteCPF ;
      private string[] BC000X31_A561ContratoClienteTipoPessoa ;
      private bool[] BC000X31_n561ContratoClienteTipoPessoa ;
      private decimal[] BC000X31_A460ContratoTaxa ;
      private bool[] BC000X31_n460ContratoTaxa ;
      private short[] BC000X31_A461ContratoSLA ;
      private bool[] BC000X31_n461ContratoSLA ;
      private decimal[] BC000X31_A462ContratoJurosMora ;
      private bool[] BC000X31_n462ContratoJurosMora ;
      private decimal[] BC000X31_A463ContratoIOFMinimo ;
      private bool[] BC000X31_n463ContratoIOFMinimo ;
      private string[] BC000X31_A471ContratoSituacao ;
      private bool[] BC000X31_n471ContratoSituacao ;
      private string[] BC000X31_A614ContratoClienteEnderecoCEP ;
      private bool[] BC000X31_n614ContratoClienteEnderecoCEP ;
      private string[] BC000X31_A615ContratoClienteEnderecoLograodouro ;
      private bool[] BC000X31_n615ContratoClienteEnderecoLograodouro ;
      private string[] BC000X31_A616ContratoClienteEnderecoNumero ;
      private bool[] BC000X31_n616ContratoClienteEnderecoNumero ;
      private string[] BC000X31_A617ContratoClienteEnderecoComplemento ;
      private bool[] BC000X31_n617ContratoClienteEnderecoComplemento ;
      private string[] BC000X31_A618ContratoClienteEnderecoBairro ;
      private bool[] BC000X31_n618ContratoClienteEnderecoBairro ;
      private int[] BC000X31_A473ContratoClienteId ;
      private bool[] BC000X31_n473ContratoClienteId ;
      private int[] BC000X31_A923ContratoPropostaId ;
      private bool[] BC000X31_n923ContratoPropostaId ;
      private string[] BC000X31_A619ContratoClienteMunicipioCodigo ;
      private bool[] BC000X31_n619ContratoClienteMunicipioCodigo ;
      private short[] BC000X31_A483AssinaturaUltId_F ;
      private bool[] BC000X31_n483AssinaturaUltId_F ;
      private short[] BC000X31_A1007ContratoCountAssinantes_F ;
      private bool[] BC000X31_n1007ContratoCountAssinantes_F ;
      private string[] BC000X31_A472ContratoBlob ;
      private bool[] BC000X31_n472ContratoBlob ;
      private SdtContrato bcContrato ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class contrato_bc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000X2;
          prmBC000X2 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC000X3;
          prmBC000X3 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC000X4;
          prmBC000X4 = new Object[] {
          new ParDef("ContratoClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000X5;
          prmBC000X5 = new Object[] {
          new ParDef("ContratoPropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000X7;
          prmBC000X7 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC000X9;
          prmBC000X9 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("ContratoClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000X12;
          prmBC000X12 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC000X13;
          prmBC000X13 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC000X14;
          prmBC000X14 = new Object[] {
          new ParDef("ContratoNome",GXType.VarChar,125,0){Nullable=true} ,
          new ParDef("ContratoCorpo",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("ContratoComVigencia",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ContratoDataInicial",GXType.Date,8,0){Nullable=true} ,
          new ParDef("ContratoDataFinal",GXType.Date,8,0){Nullable=true} ,
          new ParDef("ContratoTaxa",GXType.Number,16,4){Nullable=true} ,
          new ParDef("ContratoSLA",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ContratoJurosMora",GXType.Number,16,4){Nullable=true} ,
          new ParDef("ContratoIOFMinimo",GXType.Number,16,4){Nullable=true} ,
          new ParDef("ContratoSituacao",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ContratoBlob",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("ContratoClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ContratoPropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000X15;
          prmBC000X15 = new Object[] {
          };
          Object[] prmBC000X16;
          prmBC000X16 = new Object[] {
          new ParDef("ContratoNome",GXType.VarChar,125,0){Nullable=true} ,
          new ParDef("ContratoCorpo",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("ContratoComVigencia",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ContratoDataInicial",GXType.Date,8,0){Nullable=true} ,
          new ParDef("ContratoDataFinal",GXType.Date,8,0){Nullable=true} ,
          new ParDef("ContratoTaxa",GXType.Number,16,4){Nullable=true} ,
          new ParDef("ContratoSLA",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ContratoJurosMora",GXType.Number,16,4){Nullable=true} ,
          new ParDef("ContratoIOFMinimo",GXType.Number,16,4){Nullable=true} ,
          new ParDef("ContratoSituacao",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ContratoClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ContratoPropostaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC000X17;
          prmBC000X17 = new Object[] {
          new ParDef("ContratoBlob",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC000X18;
          prmBC000X18 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC000X20;
          prmBC000X20 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC000X21;
          prmBC000X21 = new Object[] {
          new ParDef("ContratoClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000X23;
          prmBC000X23 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("ContratoClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000X24;
          prmBC000X24 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC000X25;
          prmBC000X25 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC000X26;
          prmBC000X26 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC000X27;
          prmBC000X27 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC000X28;
          prmBC000X28 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC000X31;
          prmBC000X31 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC000X2", "SELECT ContratoId, ContratoNome, ContratoCorpo, ContratoComVigencia, ContratoDataInicial, ContratoDataFinal, ContratoTaxa, ContratoSLA, ContratoJurosMora, ContratoIOFMinimo, ContratoSituacao, ContratoClienteId, ContratoPropostaId, ContratoBlob FROM Contrato WHERE ContratoId = :ContratoId  FOR UPDATE OF Contrato",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000X3", "SELECT ContratoId, ContratoNome, ContratoCorpo, ContratoComVigencia, ContratoDataInicial, ContratoDataFinal, ContratoTaxa, ContratoSLA, ContratoJurosMora, ContratoIOFMinimo, ContratoSituacao, ContratoClienteId, ContratoPropostaId, ContratoBlob FROM Contrato WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000X4", "SELECT ClienteRazaoSocial AS ContratoClienteNome, ClienteDocumento AS ContratoClienteDocumento, ResponsavelNome AS ContratoClienteRepresentanteNome, ResponsavelCPF AS ContratoClienteRepresentanteCPF, ClienteTipoPessoa AS ContratoClienteTipoPessoa, EnderecoCEP AS ContratoClienteEnderecoCEP, EnderecoLogradouro AS ContratoClienteEnderecoLograodouro, EnderecoNumero AS ContratoClienteEnderecoNumero, EnderecoComplemento AS ContratoClienteEnderecoComplemento, EnderecoBairro AS ContratoClienteEnderecoBairro, MunicipioCodigo AS ContratoClienteMunicipioCodigo FROM Cliente WHERE ClienteId = :ContratoClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000X5", "SELECT PropostaId AS ContratoPropostaId FROM Proposta WHERE PropostaId = :ContratoPropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000X7", "SELECT COALESCE( T1.AssinaturaUltId_F, 0) AS AssinaturaUltId_F FROM (SELECT MAX(AssinaturaId) AS AssinaturaUltId_F, ContratoId FROM Assinatura GROUP BY ContratoId ) T1 WHERE T1.ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000X9", "SELECT COALESCE( T1.ContratoCountAssinantes_F, 0) AS ContratoCountAssinantes_F FROM (SELECT COUNT(*) AS ContratoCountAssinantes_F, T3.ContratoId, T2.ClienteId FROM (AssinaturaParticipante T2 LEFT JOIN Assinatura T3 ON T3.AssinaturaId = T2.AssinaturaId) GROUP BY T3.ContratoId, T2.ClienteId ) T1 WHERE T1.ContratoId = :ContratoId AND T1.ClienteId = :ContratoClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000X12", "SELECT TM1.ContratoId, TM1.ContratoNome, TM1.ContratoCorpo, TM1.ContratoComVigencia, TM1.ContratoDataInicial, TM1.ContratoDataFinal, T3.ClienteRazaoSocial AS ContratoClienteNome, T3.ClienteDocumento AS ContratoClienteDocumento, T3.ResponsavelNome AS ContratoClienteRepresentanteNome, T3.ResponsavelCPF AS ContratoClienteRepresentanteCPF, T3.ClienteTipoPessoa AS ContratoClienteTipoPessoa, TM1.ContratoTaxa, TM1.ContratoSLA, TM1.ContratoJurosMora, TM1.ContratoIOFMinimo, TM1.ContratoSituacao, T3.EnderecoCEP AS ContratoClienteEnderecoCEP, T3.EnderecoLogradouro AS ContratoClienteEnderecoLograodouro, T3.EnderecoNumero AS ContratoClienteEnderecoNumero, T3.EnderecoComplemento AS ContratoClienteEnderecoComplemento, T3.EnderecoBairro AS ContratoClienteEnderecoBairro, TM1.ContratoClienteId AS ContratoClienteId, TM1.ContratoPropostaId AS ContratoPropostaId, T3.MunicipioCodigo AS ContratoClienteMunicipioCodigo, COALESCE( T2.AssinaturaUltId_F, 0) AS AssinaturaUltId_F, COALESCE( T4.ContratoCountAssinantes_F, 0) AS ContratoCountAssinantes_F, TM1.ContratoBlob FROM (((Contrato TM1 LEFT JOIN LATERAL (SELECT MAX(AssinaturaId) AS AssinaturaUltId_F, ContratoId FROM Assinatura WHERE TM1.ContratoId = ContratoId GROUP BY ContratoId ) T2 ON T2.ContratoId = TM1.ContratoId) LEFT JOIN Cliente T3 ON T3.ClienteId = TM1.ContratoClienteId) LEFT JOIN LATERAL (SELECT COUNT(*) AS ContratoCountAssinantes_F, T6.ContratoId, T5.ClienteId FROM (AssinaturaParticipante T5 LEFT JOIN Assinatura T6 ON T6.AssinaturaId = T5.AssinaturaId) WHERE TM1.ContratoId = T6.ContratoId and TM1.ContratoClienteId = T5.ClienteId GROUP BY T6.ContratoId, T5.ClienteId ) T4 ON T4.ContratoId = TM1.ContratoId AND T4.ClienteId = TM1.ContratoClienteId) WHERE TM1.ContratoId = :ContratoId ORDER BY TM1.ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X12,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000X13", "SELECT ContratoId FROM Contrato WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000X14", "SAVEPOINT gxupdate;INSERT INTO Contrato(ContratoNome, ContratoCorpo, ContratoComVigencia, ContratoDataInicial, ContratoDataFinal, ContratoTaxa, ContratoSLA, ContratoJurosMora, ContratoIOFMinimo, ContratoSituacao, ContratoBlob, ContratoClienteId, ContratoPropostaId) VALUES(:ContratoNome, :ContratoCorpo, :ContratoComVigencia, :ContratoDataInicial, :ContratoDataFinal, :ContratoTaxa, :ContratoSLA, :ContratoJurosMora, :ContratoIOFMinimo, :ContratoSituacao, :ContratoBlob, :ContratoClienteId, :ContratoPropostaId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000X14)
             ,new CursorDef("BC000X15", "SELECT currval('ContratoId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000X16", "SAVEPOINT gxupdate;UPDATE Contrato SET ContratoNome=:ContratoNome, ContratoCorpo=:ContratoCorpo, ContratoComVigencia=:ContratoComVigencia, ContratoDataInicial=:ContratoDataInicial, ContratoDataFinal=:ContratoDataFinal, ContratoTaxa=:ContratoTaxa, ContratoSLA=:ContratoSLA, ContratoJurosMora=:ContratoJurosMora, ContratoIOFMinimo=:ContratoIOFMinimo, ContratoSituacao=:ContratoSituacao, ContratoClienteId=:ContratoClienteId, ContratoPropostaId=:ContratoPropostaId  WHERE ContratoId = :ContratoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000X16)
             ,new CursorDef("BC000X17", "SAVEPOINT gxupdate;UPDATE Contrato SET ContratoBlob=:ContratoBlob  WHERE ContratoId = :ContratoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000X17)
             ,new CursorDef("BC000X18", "SAVEPOINT gxupdate;DELETE FROM Contrato  WHERE ContratoId = :ContratoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000X18)
             ,new CursorDef("BC000X20", "SELECT COALESCE( T1.AssinaturaUltId_F, 0) AS AssinaturaUltId_F FROM (SELECT MAX(AssinaturaId) AS AssinaturaUltId_F, ContratoId FROM Assinatura GROUP BY ContratoId ) T1 WHERE T1.ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X20,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000X21", "SELECT ClienteRazaoSocial AS ContratoClienteNome, ClienteDocumento AS ContratoClienteDocumento, ResponsavelNome AS ContratoClienteRepresentanteNome, ResponsavelCPF AS ContratoClienteRepresentanteCPF, ClienteTipoPessoa AS ContratoClienteTipoPessoa, EnderecoCEP AS ContratoClienteEnderecoCEP, EnderecoLogradouro AS ContratoClienteEnderecoLograodouro, EnderecoNumero AS ContratoClienteEnderecoNumero, EnderecoComplemento AS ContratoClienteEnderecoComplemento, EnderecoBairro AS ContratoClienteEnderecoBairro, MunicipioCodigo AS ContratoClienteMunicipioCodigo FROM Cliente WHERE ClienteId = :ContratoClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X21,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000X23", "SELECT COALESCE( T1.ContratoCountAssinantes_F, 0) AS ContratoCountAssinantes_F FROM (SELECT COUNT(*) AS ContratoCountAssinantes_F, T3.ContratoId, T2.ClienteId FROM (AssinaturaParticipante T2 LEFT JOIN Assinatura T3 ON T3.AssinaturaId = T2.AssinaturaId) GROUP BY T3.ContratoId, T2.ClienteId ) T1 WHERE T1.ContratoId = :ContratoId AND T1.ClienteId = :ContratoClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X23,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000X24", "SELECT PropostaContratoAssinaturaId FROM PropostaContratoAssinatura WHERE PropostaContrato = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X24,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000X25", "SELECT OperacoesId FROM Operacoes WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X25,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000X26", "SELECT PropostaId FROM Proposta WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X26,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000X27", "SELECT AssinaturaId FROM Assinatura WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X27,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000X28", "SELECT ContratoParticipanteId FROM ContratoParticipante WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X28,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000X31", "SELECT TM1.ContratoId, TM1.ContratoNome, TM1.ContratoCorpo, TM1.ContratoComVigencia, TM1.ContratoDataInicial, TM1.ContratoDataFinal, T3.ClienteRazaoSocial AS ContratoClienteNome, T3.ClienteDocumento AS ContratoClienteDocumento, T3.ResponsavelNome AS ContratoClienteRepresentanteNome, T3.ResponsavelCPF AS ContratoClienteRepresentanteCPF, T3.ClienteTipoPessoa AS ContratoClienteTipoPessoa, TM1.ContratoTaxa, TM1.ContratoSLA, TM1.ContratoJurosMora, TM1.ContratoIOFMinimo, TM1.ContratoSituacao, T3.EnderecoCEP AS ContratoClienteEnderecoCEP, T3.EnderecoLogradouro AS ContratoClienteEnderecoLograodouro, T3.EnderecoNumero AS ContratoClienteEnderecoNumero, T3.EnderecoComplemento AS ContratoClienteEnderecoComplemento, T3.EnderecoBairro AS ContratoClienteEnderecoBairro, TM1.ContratoClienteId AS ContratoClienteId, TM1.ContratoPropostaId AS ContratoPropostaId, T3.MunicipioCodigo AS ContratoClienteMunicipioCodigo, COALESCE( T2.AssinaturaUltId_F, 0) AS AssinaturaUltId_F, COALESCE( T4.ContratoCountAssinantes_F, 0) AS ContratoCountAssinantes_F, TM1.ContratoBlob FROM (((Contrato TM1 LEFT JOIN LATERAL (SELECT MAX(AssinaturaId) AS AssinaturaUltId_F, ContratoId FROM Assinatura WHERE TM1.ContratoId = ContratoId GROUP BY ContratoId ) T2 ON T2.ContratoId = TM1.ContratoId) LEFT JOIN Cliente T3 ON T3.ClienteId = TM1.ContratoClienteId) LEFT JOIN LATERAL (SELECT COUNT(*) AS ContratoCountAssinantes_F, T6.ContratoId, T5.ClienteId FROM (AssinaturaParticipante T5 LEFT JOIN Assinatura T6 ON T6.AssinaturaId = T5.AssinaturaId) WHERE TM1.ContratoId = T6.ContratoId and TM1.ContratoClienteId = T5.ClienteId GROUP BY T6.ContratoId, T5.ClienteId ) T4 ON T4.ContratoId = TM1.ContratoId AND T4.ClienteId = TM1.ContratoClienteId) WHERE TM1.ContratoId = :ContratoId ORDER BY TM1.ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X31,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((int[]) buf[23])[0] = rslt.getInt(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getBLOBFile(14, "tmp", "");
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((int[]) buf[23])[0] = rslt.getInt(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getBLOBFile(14, "tmp", "");
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((short[]) buf[23])[0] = rslt.getShort(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((int[]) buf[41])[0] = rslt.getInt(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((int[]) buf[43])[0] = rslt.getInt(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((short[]) buf[47])[0] = rslt.getShort(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((short[]) buf[49])[0] = rslt.getShort(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((string[]) buf[51])[0] = rslt.getBLOBFile(27, "tmp", "");
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 16 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 17 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 18 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 19 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 20 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 21 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((short[]) buf[23])[0] = rslt.getShort(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((int[]) buf[41])[0] = rslt.getInt(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((int[]) buf[43])[0] = rslt.getInt(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((short[]) buf[47])[0] = rslt.getShort(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((short[]) buf[49])[0] = rslt.getShort(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((string[]) buf[51])[0] = rslt.getBLOBFile(27, "tmp", "");
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                return;
       }
    }

 }

}
