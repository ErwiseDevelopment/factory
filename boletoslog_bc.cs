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
   public class boletoslog_bc : GxSilentTrn, IGxSilentTrn
   {
      public boletoslog_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public boletoslog_bc( IGxContext context )
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
         ReadRow38112( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey38112( ) ;
         standaloneModal( ) ;
         AddRow38112( ) ;
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
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z1101BoletosLogId = A1101BoletosLogId;
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

      protected void CONFIRM_380( )
      {
         BeforeValidate38112( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls38112( ) ;
            }
            else
            {
               CheckExtendedTable38112( ) ;
               if ( AnyError == 0 )
               {
                  ZM38112( 5) ;
               }
               CloseExtendedTableCursors38112( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM38112( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z1102BoletosLogOperacao = A1102BoletosLogOperacao;
            Z1103BoletosLogStatusAnterior = A1103BoletosLogStatusAnterior;
            Z1104BoletosLogStatusNovo = A1104BoletosLogStatusNovo;
            Z1107BoletosLogCodigoHttp = A1107BoletosLogCodigoHttp;
            Z1108BoletosLogSucesso = A1108BoletosLogSucesso;
            Z1109BoletosLogObservacao = A1109BoletosLogObservacao;
            Z1110BoletosLogCreatedAt = A1110BoletosLogCreatedAt;
            Z1077BoletosId = A1077BoletosId;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -4 )
         {
            Z1101BoletosLogId = A1101BoletosLogId;
            Z1102BoletosLogOperacao = A1102BoletosLogOperacao;
            Z1103BoletosLogStatusAnterior = A1103BoletosLogStatusAnterior;
            Z1104BoletosLogStatusNovo = A1104BoletosLogStatusNovo;
            Z1105BoletosLogRequisicao = A1105BoletosLogRequisicao;
            Z1106BoletosLogResponse = A1106BoletosLogResponse;
            Z1107BoletosLogCodigoHttp = A1107BoletosLogCodigoHttp;
            Z1108BoletosLogSucesso = A1108BoletosLogSucesso;
            Z1109BoletosLogObservacao = A1109BoletosLogObservacao;
            Z1110BoletosLogCreatedAt = A1110BoletosLogCreatedAt;
            Z1077BoletosId = A1077BoletosId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load38112( )
      {
         /* Using cursor BC00385 */
         pr_default.execute(3, new Object[] {A1101BoletosLogId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound112 = 1;
            A1102BoletosLogOperacao = BC00385_A1102BoletosLogOperacao[0];
            n1102BoletosLogOperacao = BC00385_n1102BoletosLogOperacao[0];
            A1103BoletosLogStatusAnterior = BC00385_A1103BoletosLogStatusAnterior[0];
            n1103BoletosLogStatusAnterior = BC00385_n1103BoletosLogStatusAnterior[0];
            A1104BoletosLogStatusNovo = BC00385_A1104BoletosLogStatusNovo[0];
            n1104BoletosLogStatusNovo = BC00385_n1104BoletosLogStatusNovo[0];
            A1105BoletosLogRequisicao = BC00385_A1105BoletosLogRequisicao[0];
            n1105BoletosLogRequisicao = BC00385_n1105BoletosLogRequisicao[0];
            A1106BoletosLogResponse = BC00385_A1106BoletosLogResponse[0];
            n1106BoletosLogResponse = BC00385_n1106BoletosLogResponse[0];
            A1107BoletosLogCodigoHttp = BC00385_A1107BoletosLogCodigoHttp[0];
            n1107BoletosLogCodigoHttp = BC00385_n1107BoletosLogCodigoHttp[0];
            A1108BoletosLogSucesso = BC00385_A1108BoletosLogSucesso[0];
            n1108BoletosLogSucesso = BC00385_n1108BoletosLogSucesso[0];
            A1109BoletosLogObservacao = BC00385_A1109BoletosLogObservacao[0];
            n1109BoletosLogObservacao = BC00385_n1109BoletosLogObservacao[0];
            A1110BoletosLogCreatedAt = BC00385_A1110BoletosLogCreatedAt[0];
            n1110BoletosLogCreatedAt = BC00385_n1110BoletosLogCreatedAt[0];
            A1077BoletosId = BC00385_A1077BoletosId[0];
            n1077BoletosId = BC00385_n1077BoletosId[0];
            ZM38112( -4) ;
         }
         pr_default.close(3);
         OnLoadActions38112( ) ;
      }

      protected void OnLoadActions38112( )
      {
      }

      protected void CheckExtendedTable38112( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00384 */
         pr_default.execute(2, new Object[] {n1077BoletosId, A1077BoletosId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A1077BoletosId) ) )
            {
               GX_msglist.addItem("Não existe 'Boleto'.", "ForeignKeyNotFound", 1, "BOLETOSID");
               AnyError = 1;
            }
         }
         pr_default.close(2);
         if ( ! ( ( StringUtil.StrCmp(A1102BoletosLogOperacao, "REGISTRO") == 0 ) || ( StringUtil.StrCmp(A1102BoletosLogOperacao, "CONSULTA") == 0 ) || ( StringUtil.StrCmp(A1102BoletosLogOperacao, "BAIXA") == 0 ) || ( StringUtil.StrCmp(A1102BoletosLogOperacao, "ALTERACAO") == 0 ) || ( StringUtil.StrCmp(A1102BoletosLogOperacao, "WEBHOOK") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A1102BoletosLogOperacao)) ) )
         {
            GX_msglist.addItem("Campo Boletos Log Operacao fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A1103BoletosLogStatusAnterior, "RASCUNHO") == 0 ) || ( StringUtil.StrCmp(A1103BoletosLogStatusAnterior, "REGISTRADO") == 0 ) || ( StringUtil.StrCmp(A1103BoletosLogStatusAnterior, "LIQUIDADO") == 0 ) || ( StringUtil.StrCmp(A1103BoletosLogStatusAnterior, "BAIXADO") == 0 ) || ( StringUtil.StrCmp(A1103BoletosLogStatusAnterior, "VENCIDO") == 0 ) || ( StringUtil.StrCmp(A1103BoletosLogStatusAnterior, "ERRO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A1103BoletosLogStatusAnterior)) ) )
         {
            GX_msglist.addItem("Campo Boletos Log Status Anterior fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A1104BoletosLogStatusNovo, "RASCUNHO") == 0 ) || ( StringUtil.StrCmp(A1104BoletosLogStatusNovo, "REGISTRADO") == 0 ) || ( StringUtil.StrCmp(A1104BoletosLogStatusNovo, "LIQUIDADO") == 0 ) || ( StringUtil.StrCmp(A1104BoletosLogStatusNovo, "BAIXADO") == 0 ) || ( StringUtil.StrCmp(A1104BoletosLogStatusNovo, "VENCIDO") == 0 ) || ( StringUtil.StrCmp(A1104BoletosLogStatusNovo, "ERRO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A1104BoletosLogStatusNovo)) ) )
         {
            GX_msglist.addItem("Campo Boletos Log Status Novo fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors38112( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey38112( )
      {
         /* Using cursor BC00386 */
         pr_default.execute(4, new Object[] {A1101BoletosLogId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound112 = 1;
         }
         else
         {
            RcdFound112 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00383 */
         pr_default.execute(1, new Object[] {A1101BoletosLogId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM38112( 4) ;
            RcdFound112 = 1;
            A1101BoletosLogId = BC00383_A1101BoletosLogId[0];
            A1102BoletosLogOperacao = BC00383_A1102BoletosLogOperacao[0];
            n1102BoletosLogOperacao = BC00383_n1102BoletosLogOperacao[0];
            A1103BoletosLogStatusAnterior = BC00383_A1103BoletosLogStatusAnterior[0];
            n1103BoletosLogStatusAnterior = BC00383_n1103BoletosLogStatusAnterior[0];
            A1104BoletosLogStatusNovo = BC00383_A1104BoletosLogStatusNovo[0];
            n1104BoletosLogStatusNovo = BC00383_n1104BoletosLogStatusNovo[0];
            A1105BoletosLogRequisicao = BC00383_A1105BoletosLogRequisicao[0];
            n1105BoletosLogRequisicao = BC00383_n1105BoletosLogRequisicao[0];
            A1106BoletosLogResponse = BC00383_A1106BoletosLogResponse[0];
            n1106BoletosLogResponse = BC00383_n1106BoletosLogResponse[0];
            A1107BoletosLogCodigoHttp = BC00383_A1107BoletosLogCodigoHttp[0];
            n1107BoletosLogCodigoHttp = BC00383_n1107BoletosLogCodigoHttp[0];
            A1108BoletosLogSucesso = BC00383_A1108BoletosLogSucesso[0];
            n1108BoletosLogSucesso = BC00383_n1108BoletosLogSucesso[0];
            A1109BoletosLogObservacao = BC00383_A1109BoletosLogObservacao[0];
            n1109BoletosLogObservacao = BC00383_n1109BoletosLogObservacao[0];
            A1110BoletosLogCreatedAt = BC00383_A1110BoletosLogCreatedAt[0];
            n1110BoletosLogCreatedAt = BC00383_n1110BoletosLogCreatedAt[0];
            A1077BoletosId = BC00383_A1077BoletosId[0];
            n1077BoletosId = BC00383_n1077BoletosId[0];
            Z1101BoletosLogId = A1101BoletosLogId;
            sMode112 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load38112( ) ;
            if ( AnyError == 1 )
            {
               RcdFound112 = 0;
               InitializeNonKey38112( ) ;
            }
            Gx_mode = sMode112;
         }
         else
         {
            RcdFound112 = 0;
            InitializeNonKey38112( ) ;
            sMode112 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode112;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey38112( ) ;
         if ( RcdFound112 == 0 )
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
         CONFIRM_380( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency38112( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00382 */
            pr_default.execute(0, new Object[] {A1101BoletosLogId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"BoletosLog"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1102BoletosLogOperacao, BC00382_A1102BoletosLogOperacao[0]) != 0 ) || ( StringUtil.StrCmp(Z1103BoletosLogStatusAnterior, BC00382_A1103BoletosLogStatusAnterior[0]) != 0 ) || ( StringUtil.StrCmp(Z1104BoletosLogStatusNovo, BC00382_A1104BoletosLogStatusNovo[0]) != 0 ) || ( Z1107BoletosLogCodigoHttp != BC00382_A1107BoletosLogCodigoHttp[0] ) || ( Z1108BoletosLogSucesso != BC00382_A1108BoletosLogSucesso[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1109BoletosLogObservacao, BC00382_A1109BoletosLogObservacao[0]) != 0 ) || ( Z1110BoletosLogCreatedAt != BC00382_A1110BoletosLogCreatedAt[0] ) || ( Z1077BoletosId != BC00382_A1077BoletosId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"BoletosLog"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert38112( )
      {
         BeforeValidate38112( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable38112( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM38112( 0) ;
            CheckOptimisticConcurrency38112( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm38112( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert38112( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00387 */
                     pr_default.execute(5, new Object[] {n1102BoletosLogOperacao, A1102BoletosLogOperacao, n1103BoletosLogStatusAnterior, A1103BoletosLogStatusAnterior, n1104BoletosLogStatusNovo, A1104BoletosLogStatusNovo, n1105BoletosLogRequisicao, A1105BoletosLogRequisicao, n1106BoletosLogResponse, A1106BoletosLogResponse, n1107BoletosLogCodigoHttp, A1107BoletosLogCodigoHttp, n1108BoletosLogSucesso, A1108BoletosLogSucesso, n1109BoletosLogObservacao, A1109BoletosLogObservacao, n1110BoletosLogCreatedAt, A1110BoletosLogCreatedAt, n1077BoletosId, A1077BoletosId});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC00388 */
                     pr_default.execute(6);
                     A1101BoletosLogId = BC00388_A1101BoletosLogId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("BoletosLog");
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
               Load38112( ) ;
            }
            EndLevel38112( ) ;
         }
         CloseExtendedTableCursors38112( ) ;
      }

      protected void Update38112( )
      {
         BeforeValidate38112( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable38112( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency38112( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm38112( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate38112( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00389 */
                     pr_default.execute(7, new Object[] {n1102BoletosLogOperacao, A1102BoletosLogOperacao, n1103BoletosLogStatusAnterior, A1103BoletosLogStatusAnterior, n1104BoletosLogStatusNovo, A1104BoletosLogStatusNovo, n1105BoletosLogRequisicao, A1105BoletosLogRequisicao, n1106BoletosLogResponse, A1106BoletosLogResponse, n1107BoletosLogCodigoHttp, A1107BoletosLogCodigoHttp, n1108BoletosLogSucesso, A1108BoletosLogSucesso, n1109BoletosLogObservacao, A1109BoletosLogObservacao, n1110BoletosLogCreatedAt, A1110BoletosLogCreatedAt, n1077BoletosId, A1077BoletosId, A1101BoletosLogId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("BoletosLog");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"BoletosLog"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate38112( ) ;
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
            EndLevel38112( ) ;
         }
         CloseExtendedTableCursors38112( ) ;
      }

      protected void DeferredUpdate38112( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate38112( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency38112( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls38112( ) ;
            AfterConfirm38112( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete38112( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC003810 */
                  pr_default.execute(8, new Object[] {A1101BoletosLogId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("BoletosLog");
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
         sMode112 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel38112( ) ;
         Gx_mode = sMode112;
      }

      protected void OnDeleteControls38112( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel38112( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete38112( ) ;
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

      public void ScanKeyStart38112( )
      {
         /* Using cursor BC003811 */
         pr_default.execute(9, new Object[] {A1101BoletosLogId});
         RcdFound112 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound112 = 1;
            A1101BoletosLogId = BC003811_A1101BoletosLogId[0];
            A1102BoletosLogOperacao = BC003811_A1102BoletosLogOperacao[0];
            n1102BoletosLogOperacao = BC003811_n1102BoletosLogOperacao[0];
            A1103BoletosLogStatusAnterior = BC003811_A1103BoletosLogStatusAnterior[0];
            n1103BoletosLogStatusAnterior = BC003811_n1103BoletosLogStatusAnterior[0];
            A1104BoletosLogStatusNovo = BC003811_A1104BoletosLogStatusNovo[0];
            n1104BoletosLogStatusNovo = BC003811_n1104BoletosLogStatusNovo[0];
            A1105BoletosLogRequisicao = BC003811_A1105BoletosLogRequisicao[0];
            n1105BoletosLogRequisicao = BC003811_n1105BoletosLogRequisicao[0];
            A1106BoletosLogResponse = BC003811_A1106BoletosLogResponse[0];
            n1106BoletosLogResponse = BC003811_n1106BoletosLogResponse[0];
            A1107BoletosLogCodigoHttp = BC003811_A1107BoletosLogCodigoHttp[0];
            n1107BoletosLogCodigoHttp = BC003811_n1107BoletosLogCodigoHttp[0];
            A1108BoletosLogSucesso = BC003811_A1108BoletosLogSucesso[0];
            n1108BoletosLogSucesso = BC003811_n1108BoletosLogSucesso[0];
            A1109BoletosLogObservacao = BC003811_A1109BoletosLogObservacao[0];
            n1109BoletosLogObservacao = BC003811_n1109BoletosLogObservacao[0];
            A1110BoletosLogCreatedAt = BC003811_A1110BoletosLogCreatedAt[0];
            n1110BoletosLogCreatedAt = BC003811_n1110BoletosLogCreatedAt[0];
            A1077BoletosId = BC003811_A1077BoletosId[0];
            n1077BoletosId = BC003811_n1077BoletosId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext38112( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound112 = 0;
         ScanKeyLoad38112( ) ;
      }

      protected void ScanKeyLoad38112( )
      {
         sMode112 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound112 = 1;
            A1101BoletosLogId = BC003811_A1101BoletosLogId[0];
            A1102BoletosLogOperacao = BC003811_A1102BoletosLogOperacao[0];
            n1102BoletosLogOperacao = BC003811_n1102BoletosLogOperacao[0];
            A1103BoletosLogStatusAnterior = BC003811_A1103BoletosLogStatusAnterior[0];
            n1103BoletosLogStatusAnterior = BC003811_n1103BoletosLogStatusAnterior[0];
            A1104BoletosLogStatusNovo = BC003811_A1104BoletosLogStatusNovo[0];
            n1104BoletosLogStatusNovo = BC003811_n1104BoletosLogStatusNovo[0];
            A1105BoletosLogRequisicao = BC003811_A1105BoletosLogRequisicao[0];
            n1105BoletosLogRequisicao = BC003811_n1105BoletosLogRequisicao[0];
            A1106BoletosLogResponse = BC003811_A1106BoletosLogResponse[0];
            n1106BoletosLogResponse = BC003811_n1106BoletosLogResponse[0];
            A1107BoletosLogCodigoHttp = BC003811_A1107BoletosLogCodigoHttp[0];
            n1107BoletosLogCodigoHttp = BC003811_n1107BoletosLogCodigoHttp[0];
            A1108BoletosLogSucesso = BC003811_A1108BoletosLogSucesso[0];
            n1108BoletosLogSucesso = BC003811_n1108BoletosLogSucesso[0];
            A1109BoletosLogObservacao = BC003811_A1109BoletosLogObservacao[0];
            n1109BoletosLogObservacao = BC003811_n1109BoletosLogObservacao[0];
            A1110BoletosLogCreatedAt = BC003811_A1110BoletosLogCreatedAt[0];
            n1110BoletosLogCreatedAt = BC003811_n1110BoletosLogCreatedAt[0];
            A1077BoletosId = BC003811_A1077BoletosId[0];
            n1077BoletosId = BC003811_n1077BoletosId[0];
         }
         Gx_mode = sMode112;
      }

      protected void ScanKeyEnd38112( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm38112( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert38112( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate38112( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete38112( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete38112( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate38112( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes38112( )
      {
      }

      protected void send_integrity_lvl_hashes38112( )
      {
      }

      protected void AddRow38112( )
      {
         VarsToRow112( bcBoletosLog) ;
      }

      protected void ReadRow38112( )
      {
         RowToVars112( bcBoletosLog, 1) ;
      }

      protected void InitializeNonKey38112( )
      {
         A1077BoletosId = 0;
         n1077BoletosId = false;
         A1102BoletosLogOperacao = "";
         n1102BoletosLogOperacao = false;
         A1103BoletosLogStatusAnterior = "";
         n1103BoletosLogStatusAnterior = false;
         A1104BoletosLogStatusNovo = "";
         n1104BoletosLogStatusNovo = false;
         A1105BoletosLogRequisicao = "";
         n1105BoletosLogRequisicao = false;
         A1106BoletosLogResponse = "";
         n1106BoletosLogResponse = false;
         A1107BoletosLogCodigoHttp = 0;
         n1107BoletosLogCodigoHttp = false;
         A1108BoletosLogSucesso = false;
         n1108BoletosLogSucesso = false;
         A1109BoletosLogObservacao = "";
         n1109BoletosLogObservacao = false;
         A1110BoletosLogCreatedAt = (DateTime)(DateTime.MinValue);
         n1110BoletosLogCreatedAt = false;
         Z1102BoletosLogOperacao = "";
         Z1103BoletosLogStatusAnterior = "";
         Z1104BoletosLogStatusNovo = "";
         Z1107BoletosLogCodigoHttp = 0;
         Z1108BoletosLogSucesso = false;
         Z1109BoletosLogObservacao = "";
         Z1110BoletosLogCreatedAt = (DateTime)(DateTime.MinValue);
         Z1077BoletosId = 0;
      }

      protected void InitAll38112( )
      {
         A1101BoletosLogId = 0;
         InitializeNonKey38112( ) ;
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

      public void VarsToRow112( SdtBoletosLog obj112 )
      {
         obj112.gxTpr_Mode = Gx_mode;
         obj112.gxTpr_Boletosid = A1077BoletosId;
         obj112.gxTpr_Boletoslogoperacao = A1102BoletosLogOperacao;
         obj112.gxTpr_Boletoslogstatusanterior = A1103BoletosLogStatusAnterior;
         obj112.gxTpr_Boletoslogstatusnovo = A1104BoletosLogStatusNovo;
         obj112.gxTpr_Boletoslogrequisicao = A1105BoletosLogRequisicao;
         obj112.gxTpr_Boletoslogresponse = A1106BoletosLogResponse;
         obj112.gxTpr_Boletoslogcodigohttp = A1107BoletosLogCodigoHttp;
         obj112.gxTpr_Boletoslogsucesso = A1108BoletosLogSucesso;
         obj112.gxTpr_Boletoslogobservacao = A1109BoletosLogObservacao;
         obj112.gxTpr_Boletoslogcreatedat = A1110BoletosLogCreatedAt;
         obj112.gxTpr_Boletoslogid = A1101BoletosLogId;
         obj112.gxTpr_Boletoslogid_Z = Z1101BoletosLogId;
         obj112.gxTpr_Boletosid_Z = Z1077BoletosId;
         obj112.gxTpr_Boletoslogoperacao_Z = Z1102BoletosLogOperacao;
         obj112.gxTpr_Boletoslogstatusanterior_Z = Z1103BoletosLogStatusAnterior;
         obj112.gxTpr_Boletoslogstatusnovo_Z = Z1104BoletosLogStatusNovo;
         obj112.gxTpr_Boletoslogcodigohttp_Z = Z1107BoletosLogCodigoHttp;
         obj112.gxTpr_Boletoslogsucesso_Z = Z1108BoletosLogSucesso;
         obj112.gxTpr_Boletoslogobservacao_Z = Z1109BoletosLogObservacao;
         obj112.gxTpr_Boletoslogcreatedat_Z = Z1110BoletosLogCreatedAt;
         obj112.gxTpr_Boletosid_N = (short)(Convert.ToInt16(n1077BoletosId));
         obj112.gxTpr_Boletoslogoperacao_N = (short)(Convert.ToInt16(n1102BoletosLogOperacao));
         obj112.gxTpr_Boletoslogstatusanterior_N = (short)(Convert.ToInt16(n1103BoletosLogStatusAnterior));
         obj112.gxTpr_Boletoslogstatusnovo_N = (short)(Convert.ToInt16(n1104BoletosLogStatusNovo));
         obj112.gxTpr_Boletoslogrequisicao_N = (short)(Convert.ToInt16(n1105BoletosLogRequisicao));
         obj112.gxTpr_Boletoslogresponse_N = (short)(Convert.ToInt16(n1106BoletosLogResponse));
         obj112.gxTpr_Boletoslogcodigohttp_N = (short)(Convert.ToInt16(n1107BoletosLogCodigoHttp));
         obj112.gxTpr_Boletoslogsucesso_N = (short)(Convert.ToInt16(n1108BoletosLogSucesso));
         obj112.gxTpr_Boletoslogobservacao_N = (short)(Convert.ToInt16(n1109BoletosLogObservacao));
         obj112.gxTpr_Boletoslogcreatedat_N = (short)(Convert.ToInt16(n1110BoletosLogCreatedAt));
         obj112.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow112( SdtBoletosLog obj112 )
      {
         obj112.gxTpr_Boletoslogid = A1101BoletosLogId;
         return  ;
      }

      public void RowToVars112( SdtBoletosLog obj112 ,
                                int forceLoad )
      {
         Gx_mode = obj112.gxTpr_Mode;
         A1077BoletosId = obj112.gxTpr_Boletosid;
         n1077BoletosId = false;
         A1102BoletosLogOperacao = obj112.gxTpr_Boletoslogoperacao;
         n1102BoletosLogOperacao = false;
         A1103BoletosLogStatusAnterior = obj112.gxTpr_Boletoslogstatusanterior;
         n1103BoletosLogStatusAnterior = false;
         A1104BoletosLogStatusNovo = obj112.gxTpr_Boletoslogstatusnovo;
         n1104BoletosLogStatusNovo = false;
         A1105BoletosLogRequisicao = obj112.gxTpr_Boletoslogrequisicao;
         n1105BoletosLogRequisicao = false;
         A1106BoletosLogResponse = obj112.gxTpr_Boletoslogresponse;
         n1106BoletosLogResponse = false;
         A1107BoletosLogCodigoHttp = obj112.gxTpr_Boletoslogcodigohttp;
         n1107BoletosLogCodigoHttp = false;
         A1108BoletosLogSucesso = obj112.gxTpr_Boletoslogsucesso;
         n1108BoletosLogSucesso = false;
         A1109BoletosLogObservacao = obj112.gxTpr_Boletoslogobservacao;
         n1109BoletosLogObservacao = false;
         A1110BoletosLogCreatedAt = obj112.gxTpr_Boletoslogcreatedat;
         n1110BoletosLogCreatedAt = false;
         A1101BoletosLogId = obj112.gxTpr_Boletoslogid;
         Z1101BoletosLogId = obj112.gxTpr_Boletoslogid_Z;
         Z1077BoletosId = obj112.gxTpr_Boletosid_Z;
         Z1102BoletosLogOperacao = obj112.gxTpr_Boletoslogoperacao_Z;
         Z1103BoletosLogStatusAnterior = obj112.gxTpr_Boletoslogstatusanterior_Z;
         Z1104BoletosLogStatusNovo = obj112.gxTpr_Boletoslogstatusnovo_Z;
         Z1107BoletosLogCodigoHttp = obj112.gxTpr_Boletoslogcodigohttp_Z;
         Z1108BoletosLogSucesso = obj112.gxTpr_Boletoslogsucesso_Z;
         Z1109BoletosLogObservacao = obj112.gxTpr_Boletoslogobservacao_Z;
         Z1110BoletosLogCreatedAt = obj112.gxTpr_Boletoslogcreatedat_Z;
         n1077BoletosId = (bool)(Convert.ToBoolean(obj112.gxTpr_Boletosid_N));
         n1102BoletosLogOperacao = (bool)(Convert.ToBoolean(obj112.gxTpr_Boletoslogoperacao_N));
         n1103BoletosLogStatusAnterior = (bool)(Convert.ToBoolean(obj112.gxTpr_Boletoslogstatusanterior_N));
         n1104BoletosLogStatusNovo = (bool)(Convert.ToBoolean(obj112.gxTpr_Boletoslogstatusnovo_N));
         n1105BoletosLogRequisicao = (bool)(Convert.ToBoolean(obj112.gxTpr_Boletoslogrequisicao_N));
         n1106BoletosLogResponse = (bool)(Convert.ToBoolean(obj112.gxTpr_Boletoslogresponse_N));
         n1107BoletosLogCodigoHttp = (bool)(Convert.ToBoolean(obj112.gxTpr_Boletoslogcodigohttp_N));
         n1108BoletosLogSucesso = (bool)(Convert.ToBoolean(obj112.gxTpr_Boletoslogsucesso_N));
         n1109BoletosLogObservacao = (bool)(Convert.ToBoolean(obj112.gxTpr_Boletoslogobservacao_N));
         n1110BoletosLogCreatedAt = (bool)(Convert.ToBoolean(obj112.gxTpr_Boletoslogcreatedat_N));
         Gx_mode = obj112.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A1101BoletosLogId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey38112( ) ;
         ScanKeyStart38112( ) ;
         if ( RcdFound112 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1101BoletosLogId = A1101BoletosLogId;
         }
         ZM38112( -4) ;
         OnLoadActions38112( ) ;
         AddRow38112( ) ;
         ScanKeyEnd38112( ) ;
         if ( RcdFound112 == 0 )
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
         RowToVars112( bcBoletosLog, 0) ;
         ScanKeyStart38112( ) ;
         if ( RcdFound112 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1101BoletosLogId = A1101BoletosLogId;
         }
         ZM38112( -4) ;
         OnLoadActions38112( ) ;
         AddRow38112( ) ;
         ScanKeyEnd38112( ) ;
         if ( RcdFound112 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey38112( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert38112( ) ;
         }
         else
         {
            if ( RcdFound112 == 1 )
            {
               if ( A1101BoletosLogId != Z1101BoletosLogId )
               {
                  A1101BoletosLogId = Z1101BoletosLogId;
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
                  Update38112( ) ;
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
                  if ( A1101BoletosLogId != Z1101BoletosLogId )
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
                        Insert38112( ) ;
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
                        Insert38112( ) ;
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
         RowToVars112( bcBoletosLog, 1) ;
         SaveImpl( ) ;
         VarsToRow112( bcBoletosLog) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars112( bcBoletosLog, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert38112( ) ;
         AfterTrn( ) ;
         VarsToRow112( bcBoletosLog) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow112( bcBoletosLog) ;
         }
         else
         {
            SdtBoletosLog auxBC = new SdtBoletosLog(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A1101BoletosLogId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcBoletosLog);
               auxBC.Save();
               bcBoletosLog.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars112( bcBoletosLog, 1) ;
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
         RowToVars112( bcBoletosLog, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert38112( ) ;
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
               VarsToRow112( bcBoletosLog) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow112( bcBoletosLog) ;
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
         RowToVars112( bcBoletosLog, 0) ;
         GetKey38112( ) ;
         if ( RcdFound112 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A1101BoletosLogId != Z1101BoletosLogId )
            {
               A1101BoletosLogId = Z1101BoletosLogId;
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
            if ( A1101BoletosLogId != Z1101BoletosLogId )
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
         context.RollbackDataStores("boletoslog_bc",pr_default);
         VarsToRow112( bcBoletosLog) ;
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
         Gx_mode = bcBoletosLog.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcBoletosLog.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcBoletosLog )
         {
            bcBoletosLog = (SdtBoletosLog)(sdt);
            if ( StringUtil.StrCmp(bcBoletosLog.gxTpr_Mode, "") == 0 )
            {
               bcBoletosLog.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow112( bcBoletosLog) ;
            }
            else
            {
               RowToVars112( bcBoletosLog, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcBoletosLog.gxTpr_Mode, "") == 0 )
            {
               bcBoletosLog.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars112( bcBoletosLog, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtBoletosLog BoletosLog_BC
      {
         get {
            return bcBoletosLog ;
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
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z1102BoletosLogOperacao = "";
         A1102BoletosLogOperacao = "";
         Z1103BoletosLogStatusAnterior = "";
         A1103BoletosLogStatusAnterior = "";
         Z1104BoletosLogStatusNovo = "";
         A1104BoletosLogStatusNovo = "";
         Z1109BoletosLogObservacao = "";
         A1109BoletosLogObservacao = "";
         Z1110BoletosLogCreatedAt = (DateTime)(DateTime.MinValue);
         A1110BoletosLogCreatedAt = (DateTime)(DateTime.MinValue);
         Z1105BoletosLogRequisicao = "";
         A1105BoletosLogRequisicao = "";
         Z1106BoletosLogResponse = "";
         A1106BoletosLogResponse = "";
         BC00385_A1101BoletosLogId = new int[1] ;
         BC00385_A1102BoletosLogOperacao = new string[] {""} ;
         BC00385_n1102BoletosLogOperacao = new bool[] {false} ;
         BC00385_A1103BoletosLogStatusAnterior = new string[] {""} ;
         BC00385_n1103BoletosLogStatusAnterior = new bool[] {false} ;
         BC00385_A1104BoletosLogStatusNovo = new string[] {""} ;
         BC00385_n1104BoletosLogStatusNovo = new bool[] {false} ;
         BC00385_A1105BoletosLogRequisicao = new string[] {""} ;
         BC00385_n1105BoletosLogRequisicao = new bool[] {false} ;
         BC00385_A1106BoletosLogResponse = new string[] {""} ;
         BC00385_n1106BoletosLogResponse = new bool[] {false} ;
         BC00385_A1107BoletosLogCodigoHttp = new short[1] ;
         BC00385_n1107BoletosLogCodigoHttp = new bool[] {false} ;
         BC00385_A1108BoletosLogSucesso = new bool[] {false} ;
         BC00385_n1108BoletosLogSucesso = new bool[] {false} ;
         BC00385_A1109BoletosLogObservacao = new string[] {""} ;
         BC00385_n1109BoletosLogObservacao = new bool[] {false} ;
         BC00385_A1110BoletosLogCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00385_n1110BoletosLogCreatedAt = new bool[] {false} ;
         BC00385_A1077BoletosId = new int[1] ;
         BC00385_n1077BoletosId = new bool[] {false} ;
         BC00384_A1077BoletosId = new int[1] ;
         BC00384_n1077BoletosId = new bool[] {false} ;
         BC00386_A1101BoletosLogId = new int[1] ;
         BC00383_A1101BoletosLogId = new int[1] ;
         BC00383_A1102BoletosLogOperacao = new string[] {""} ;
         BC00383_n1102BoletosLogOperacao = new bool[] {false} ;
         BC00383_A1103BoletosLogStatusAnterior = new string[] {""} ;
         BC00383_n1103BoletosLogStatusAnterior = new bool[] {false} ;
         BC00383_A1104BoletosLogStatusNovo = new string[] {""} ;
         BC00383_n1104BoletosLogStatusNovo = new bool[] {false} ;
         BC00383_A1105BoletosLogRequisicao = new string[] {""} ;
         BC00383_n1105BoletosLogRequisicao = new bool[] {false} ;
         BC00383_A1106BoletosLogResponse = new string[] {""} ;
         BC00383_n1106BoletosLogResponse = new bool[] {false} ;
         BC00383_A1107BoletosLogCodigoHttp = new short[1] ;
         BC00383_n1107BoletosLogCodigoHttp = new bool[] {false} ;
         BC00383_A1108BoletosLogSucesso = new bool[] {false} ;
         BC00383_n1108BoletosLogSucesso = new bool[] {false} ;
         BC00383_A1109BoletosLogObservacao = new string[] {""} ;
         BC00383_n1109BoletosLogObservacao = new bool[] {false} ;
         BC00383_A1110BoletosLogCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00383_n1110BoletosLogCreatedAt = new bool[] {false} ;
         BC00383_A1077BoletosId = new int[1] ;
         BC00383_n1077BoletosId = new bool[] {false} ;
         sMode112 = "";
         BC00382_A1101BoletosLogId = new int[1] ;
         BC00382_A1102BoletosLogOperacao = new string[] {""} ;
         BC00382_n1102BoletosLogOperacao = new bool[] {false} ;
         BC00382_A1103BoletosLogStatusAnterior = new string[] {""} ;
         BC00382_n1103BoletosLogStatusAnterior = new bool[] {false} ;
         BC00382_A1104BoletosLogStatusNovo = new string[] {""} ;
         BC00382_n1104BoletosLogStatusNovo = new bool[] {false} ;
         BC00382_A1105BoletosLogRequisicao = new string[] {""} ;
         BC00382_n1105BoletosLogRequisicao = new bool[] {false} ;
         BC00382_A1106BoletosLogResponse = new string[] {""} ;
         BC00382_n1106BoletosLogResponse = new bool[] {false} ;
         BC00382_A1107BoletosLogCodigoHttp = new short[1] ;
         BC00382_n1107BoletosLogCodigoHttp = new bool[] {false} ;
         BC00382_A1108BoletosLogSucesso = new bool[] {false} ;
         BC00382_n1108BoletosLogSucesso = new bool[] {false} ;
         BC00382_A1109BoletosLogObservacao = new string[] {""} ;
         BC00382_n1109BoletosLogObservacao = new bool[] {false} ;
         BC00382_A1110BoletosLogCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00382_n1110BoletosLogCreatedAt = new bool[] {false} ;
         BC00382_A1077BoletosId = new int[1] ;
         BC00382_n1077BoletosId = new bool[] {false} ;
         BC00388_A1101BoletosLogId = new int[1] ;
         BC003811_A1101BoletosLogId = new int[1] ;
         BC003811_A1102BoletosLogOperacao = new string[] {""} ;
         BC003811_n1102BoletosLogOperacao = new bool[] {false} ;
         BC003811_A1103BoletosLogStatusAnterior = new string[] {""} ;
         BC003811_n1103BoletosLogStatusAnterior = new bool[] {false} ;
         BC003811_A1104BoletosLogStatusNovo = new string[] {""} ;
         BC003811_n1104BoletosLogStatusNovo = new bool[] {false} ;
         BC003811_A1105BoletosLogRequisicao = new string[] {""} ;
         BC003811_n1105BoletosLogRequisicao = new bool[] {false} ;
         BC003811_A1106BoletosLogResponse = new string[] {""} ;
         BC003811_n1106BoletosLogResponse = new bool[] {false} ;
         BC003811_A1107BoletosLogCodigoHttp = new short[1] ;
         BC003811_n1107BoletosLogCodigoHttp = new bool[] {false} ;
         BC003811_A1108BoletosLogSucesso = new bool[] {false} ;
         BC003811_n1108BoletosLogSucesso = new bool[] {false} ;
         BC003811_A1109BoletosLogObservacao = new string[] {""} ;
         BC003811_n1109BoletosLogObservacao = new bool[] {false} ;
         BC003811_A1110BoletosLogCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC003811_n1110BoletosLogCreatedAt = new bool[] {false} ;
         BC003811_A1077BoletosId = new int[1] ;
         BC003811_n1077BoletosId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.boletoslog_bc__default(),
            new Object[][] {
                new Object[] {
               BC00382_A1101BoletosLogId, BC00382_A1102BoletosLogOperacao, BC00382_n1102BoletosLogOperacao, BC00382_A1103BoletosLogStatusAnterior, BC00382_n1103BoletosLogStatusAnterior, BC00382_A1104BoletosLogStatusNovo, BC00382_n1104BoletosLogStatusNovo, BC00382_A1105BoletosLogRequisicao, BC00382_n1105BoletosLogRequisicao, BC00382_A1106BoletosLogResponse,
               BC00382_n1106BoletosLogResponse, BC00382_A1107BoletosLogCodigoHttp, BC00382_n1107BoletosLogCodigoHttp, BC00382_A1108BoletosLogSucesso, BC00382_n1108BoletosLogSucesso, BC00382_A1109BoletosLogObservacao, BC00382_n1109BoletosLogObservacao, BC00382_A1110BoletosLogCreatedAt, BC00382_n1110BoletosLogCreatedAt, BC00382_A1077BoletosId,
               BC00382_n1077BoletosId
               }
               , new Object[] {
               BC00383_A1101BoletosLogId, BC00383_A1102BoletosLogOperacao, BC00383_n1102BoletosLogOperacao, BC00383_A1103BoletosLogStatusAnterior, BC00383_n1103BoletosLogStatusAnterior, BC00383_A1104BoletosLogStatusNovo, BC00383_n1104BoletosLogStatusNovo, BC00383_A1105BoletosLogRequisicao, BC00383_n1105BoletosLogRequisicao, BC00383_A1106BoletosLogResponse,
               BC00383_n1106BoletosLogResponse, BC00383_A1107BoletosLogCodigoHttp, BC00383_n1107BoletosLogCodigoHttp, BC00383_A1108BoletosLogSucesso, BC00383_n1108BoletosLogSucesso, BC00383_A1109BoletosLogObservacao, BC00383_n1109BoletosLogObservacao, BC00383_A1110BoletosLogCreatedAt, BC00383_n1110BoletosLogCreatedAt, BC00383_A1077BoletosId,
               BC00383_n1077BoletosId
               }
               , new Object[] {
               BC00384_A1077BoletosId
               }
               , new Object[] {
               BC00385_A1101BoletosLogId, BC00385_A1102BoletosLogOperacao, BC00385_n1102BoletosLogOperacao, BC00385_A1103BoletosLogStatusAnterior, BC00385_n1103BoletosLogStatusAnterior, BC00385_A1104BoletosLogStatusNovo, BC00385_n1104BoletosLogStatusNovo, BC00385_A1105BoletosLogRequisicao, BC00385_n1105BoletosLogRequisicao, BC00385_A1106BoletosLogResponse,
               BC00385_n1106BoletosLogResponse, BC00385_A1107BoletosLogCodigoHttp, BC00385_n1107BoletosLogCodigoHttp, BC00385_A1108BoletosLogSucesso, BC00385_n1108BoletosLogSucesso, BC00385_A1109BoletosLogObservacao, BC00385_n1109BoletosLogObservacao, BC00385_A1110BoletosLogCreatedAt, BC00385_n1110BoletosLogCreatedAt, BC00385_A1077BoletosId,
               BC00385_n1077BoletosId
               }
               , new Object[] {
               BC00386_A1101BoletosLogId
               }
               , new Object[] {
               }
               , new Object[] {
               BC00388_A1101BoletosLogId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC003811_A1101BoletosLogId, BC003811_A1102BoletosLogOperacao, BC003811_n1102BoletosLogOperacao, BC003811_A1103BoletosLogStatusAnterior, BC003811_n1103BoletosLogStatusAnterior, BC003811_A1104BoletosLogStatusNovo, BC003811_n1104BoletosLogStatusNovo, BC003811_A1105BoletosLogRequisicao, BC003811_n1105BoletosLogRequisicao, BC003811_A1106BoletosLogResponse,
               BC003811_n1106BoletosLogResponse, BC003811_A1107BoletosLogCodigoHttp, BC003811_n1107BoletosLogCodigoHttp, BC003811_A1108BoletosLogSucesso, BC003811_n1108BoletosLogSucesso, BC003811_A1109BoletosLogObservacao, BC003811_n1109BoletosLogObservacao, BC003811_A1110BoletosLogCreatedAt, BC003811_n1110BoletosLogCreatedAt, BC003811_A1077BoletosId,
               BC003811_n1077BoletosId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z1107BoletosLogCodigoHttp ;
      private short A1107BoletosLogCodigoHttp ;
      private short RcdFound112 ;
      private int trnEnded ;
      private int Z1101BoletosLogId ;
      private int A1101BoletosLogId ;
      private int Z1077BoletosId ;
      private int A1077BoletosId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode112 ;
      private DateTime Z1110BoletosLogCreatedAt ;
      private DateTime A1110BoletosLogCreatedAt ;
      private bool Z1108BoletosLogSucesso ;
      private bool A1108BoletosLogSucesso ;
      private bool n1102BoletosLogOperacao ;
      private bool n1103BoletosLogStatusAnterior ;
      private bool n1104BoletosLogStatusNovo ;
      private bool n1105BoletosLogRequisicao ;
      private bool n1106BoletosLogResponse ;
      private bool n1107BoletosLogCodigoHttp ;
      private bool n1108BoletosLogSucesso ;
      private bool n1109BoletosLogObservacao ;
      private bool n1110BoletosLogCreatedAt ;
      private bool n1077BoletosId ;
      private bool Gx_longc ;
      private string Z1105BoletosLogRequisicao ;
      private string A1105BoletosLogRequisicao ;
      private string Z1106BoletosLogResponse ;
      private string A1106BoletosLogResponse ;
      private string Z1102BoletosLogOperacao ;
      private string A1102BoletosLogOperacao ;
      private string Z1103BoletosLogStatusAnterior ;
      private string A1103BoletosLogStatusAnterior ;
      private string Z1104BoletosLogStatusNovo ;
      private string A1104BoletosLogStatusNovo ;
      private string Z1109BoletosLogObservacao ;
      private string A1109BoletosLogObservacao ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00385_A1101BoletosLogId ;
      private string[] BC00385_A1102BoletosLogOperacao ;
      private bool[] BC00385_n1102BoletosLogOperacao ;
      private string[] BC00385_A1103BoletosLogStatusAnterior ;
      private bool[] BC00385_n1103BoletosLogStatusAnterior ;
      private string[] BC00385_A1104BoletosLogStatusNovo ;
      private bool[] BC00385_n1104BoletosLogStatusNovo ;
      private string[] BC00385_A1105BoletosLogRequisicao ;
      private bool[] BC00385_n1105BoletosLogRequisicao ;
      private string[] BC00385_A1106BoletosLogResponse ;
      private bool[] BC00385_n1106BoletosLogResponse ;
      private short[] BC00385_A1107BoletosLogCodigoHttp ;
      private bool[] BC00385_n1107BoletosLogCodigoHttp ;
      private bool[] BC00385_A1108BoletosLogSucesso ;
      private bool[] BC00385_n1108BoletosLogSucesso ;
      private string[] BC00385_A1109BoletosLogObservacao ;
      private bool[] BC00385_n1109BoletosLogObservacao ;
      private DateTime[] BC00385_A1110BoletosLogCreatedAt ;
      private bool[] BC00385_n1110BoletosLogCreatedAt ;
      private int[] BC00385_A1077BoletosId ;
      private bool[] BC00385_n1077BoletosId ;
      private int[] BC00384_A1077BoletosId ;
      private bool[] BC00384_n1077BoletosId ;
      private int[] BC00386_A1101BoletosLogId ;
      private int[] BC00383_A1101BoletosLogId ;
      private string[] BC00383_A1102BoletosLogOperacao ;
      private bool[] BC00383_n1102BoletosLogOperacao ;
      private string[] BC00383_A1103BoletosLogStatusAnterior ;
      private bool[] BC00383_n1103BoletosLogStatusAnterior ;
      private string[] BC00383_A1104BoletosLogStatusNovo ;
      private bool[] BC00383_n1104BoletosLogStatusNovo ;
      private string[] BC00383_A1105BoletosLogRequisicao ;
      private bool[] BC00383_n1105BoletosLogRequisicao ;
      private string[] BC00383_A1106BoletosLogResponse ;
      private bool[] BC00383_n1106BoletosLogResponse ;
      private short[] BC00383_A1107BoletosLogCodigoHttp ;
      private bool[] BC00383_n1107BoletosLogCodigoHttp ;
      private bool[] BC00383_A1108BoletosLogSucesso ;
      private bool[] BC00383_n1108BoletosLogSucesso ;
      private string[] BC00383_A1109BoletosLogObservacao ;
      private bool[] BC00383_n1109BoletosLogObservacao ;
      private DateTime[] BC00383_A1110BoletosLogCreatedAt ;
      private bool[] BC00383_n1110BoletosLogCreatedAt ;
      private int[] BC00383_A1077BoletosId ;
      private bool[] BC00383_n1077BoletosId ;
      private int[] BC00382_A1101BoletosLogId ;
      private string[] BC00382_A1102BoletosLogOperacao ;
      private bool[] BC00382_n1102BoletosLogOperacao ;
      private string[] BC00382_A1103BoletosLogStatusAnterior ;
      private bool[] BC00382_n1103BoletosLogStatusAnterior ;
      private string[] BC00382_A1104BoletosLogStatusNovo ;
      private bool[] BC00382_n1104BoletosLogStatusNovo ;
      private string[] BC00382_A1105BoletosLogRequisicao ;
      private bool[] BC00382_n1105BoletosLogRequisicao ;
      private string[] BC00382_A1106BoletosLogResponse ;
      private bool[] BC00382_n1106BoletosLogResponse ;
      private short[] BC00382_A1107BoletosLogCodigoHttp ;
      private bool[] BC00382_n1107BoletosLogCodigoHttp ;
      private bool[] BC00382_A1108BoletosLogSucesso ;
      private bool[] BC00382_n1108BoletosLogSucesso ;
      private string[] BC00382_A1109BoletosLogObservacao ;
      private bool[] BC00382_n1109BoletosLogObservacao ;
      private DateTime[] BC00382_A1110BoletosLogCreatedAt ;
      private bool[] BC00382_n1110BoletosLogCreatedAt ;
      private int[] BC00382_A1077BoletosId ;
      private bool[] BC00382_n1077BoletosId ;
      private int[] BC00388_A1101BoletosLogId ;
      private int[] BC003811_A1101BoletosLogId ;
      private string[] BC003811_A1102BoletosLogOperacao ;
      private bool[] BC003811_n1102BoletosLogOperacao ;
      private string[] BC003811_A1103BoletosLogStatusAnterior ;
      private bool[] BC003811_n1103BoletosLogStatusAnterior ;
      private string[] BC003811_A1104BoletosLogStatusNovo ;
      private bool[] BC003811_n1104BoletosLogStatusNovo ;
      private string[] BC003811_A1105BoletosLogRequisicao ;
      private bool[] BC003811_n1105BoletosLogRequisicao ;
      private string[] BC003811_A1106BoletosLogResponse ;
      private bool[] BC003811_n1106BoletosLogResponse ;
      private short[] BC003811_A1107BoletosLogCodigoHttp ;
      private bool[] BC003811_n1107BoletosLogCodigoHttp ;
      private bool[] BC003811_A1108BoletosLogSucesso ;
      private bool[] BC003811_n1108BoletosLogSucesso ;
      private string[] BC003811_A1109BoletosLogObservacao ;
      private bool[] BC003811_n1109BoletosLogObservacao ;
      private DateTime[] BC003811_A1110BoletosLogCreatedAt ;
      private bool[] BC003811_n1110BoletosLogCreatedAt ;
      private int[] BC003811_A1077BoletosId ;
      private bool[] BC003811_n1077BoletosId ;
      private SdtBoletosLog bcBoletosLog ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class boletoslog_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00382;
          prmBC00382 = new Object[] {
          new ParDef("BoletosLogId",GXType.Int32,9,0)
          };
          Object[] prmBC00383;
          prmBC00383 = new Object[] {
          new ParDef("BoletosLogId",GXType.Int32,9,0)
          };
          Object[] prmBC00384;
          prmBC00384 = new Object[] {
          new ParDef("BoletosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00385;
          prmBC00385 = new Object[] {
          new ParDef("BoletosLogId",GXType.Int32,9,0)
          };
          Object[] prmBC00386;
          prmBC00386 = new Object[] {
          new ParDef("BoletosLogId",GXType.Int32,9,0)
          };
          Object[] prmBC00387;
          prmBC00387 = new Object[] {
          new ParDef("BoletosLogOperacao",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("BoletosLogStatusAnterior",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("BoletosLogStatusNovo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("BoletosLogRequisicao",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("BoletosLogResponse",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("BoletosLogCodigoHttp",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("BoletosLogSucesso",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("BoletosLogObservacao",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("BoletosLogCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("BoletosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00388;
          prmBC00388 = new Object[] {
          };
          Object[] prmBC00389;
          prmBC00389 = new Object[] {
          new ParDef("BoletosLogOperacao",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("BoletosLogStatusAnterior",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("BoletosLogStatusNovo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("BoletosLogRequisicao",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("BoletosLogResponse",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("BoletosLogCodigoHttp",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("BoletosLogSucesso",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("BoletosLogObservacao",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("BoletosLogCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("BoletosId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("BoletosLogId",GXType.Int32,9,0)
          };
          Object[] prmBC003810;
          prmBC003810 = new Object[] {
          new ParDef("BoletosLogId",GXType.Int32,9,0)
          };
          Object[] prmBC003811;
          prmBC003811 = new Object[] {
          new ParDef("BoletosLogId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00382", "SELECT BoletosLogId, BoletosLogOperacao, BoletosLogStatusAnterior, BoletosLogStatusNovo, BoletosLogRequisicao, BoletosLogResponse, BoletosLogCodigoHttp, BoletosLogSucesso, BoletosLogObservacao, BoletosLogCreatedAt, BoletosId FROM BoletosLog WHERE BoletosLogId = :BoletosLogId  FOR UPDATE OF BoletosLog",true, GxErrorMask.GX_NOMASK, false, this,prmBC00382,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00383", "SELECT BoletosLogId, BoletosLogOperacao, BoletosLogStatusAnterior, BoletosLogStatusNovo, BoletosLogRequisicao, BoletosLogResponse, BoletosLogCodigoHttp, BoletosLogSucesso, BoletosLogObservacao, BoletosLogCreatedAt, BoletosId FROM BoletosLog WHERE BoletosLogId = :BoletosLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00383,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00384", "SELECT BoletosId FROM Boleto WHERE BoletosId = :BoletosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00384,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00385", "SELECT TM1.BoletosLogId, TM1.BoletosLogOperacao, TM1.BoletosLogStatusAnterior, TM1.BoletosLogStatusNovo, TM1.BoletosLogRequisicao, TM1.BoletosLogResponse, TM1.BoletosLogCodigoHttp, TM1.BoletosLogSucesso, TM1.BoletosLogObservacao, TM1.BoletosLogCreatedAt, TM1.BoletosId FROM BoletosLog TM1 WHERE TM1.BoletosLogId = :BoletosLogId ORDER BY TM1.BoletosLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00385,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00386", "SELECT BoletosLogId FROM BoletosLog WHERE BoletosLogId = :BoletosLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00386,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00387", "SAVEPOINT gxupdate;INSERT INTO BoletosLog(BoletosLogOperacao, BoletosLogStatusAnterior, BoletosLogStatusNovo, BoletosLogRequisicao, BoletosLogResponse, BoletosLogCodigoHttp, BoletosLogSucesso, BoletosLogObservacao, BoletosLogCreatedAt, BoletosId) VALUES(:BoletosLogOperacao, :BoletosLogStatusAnterior, :BoletosLogStatusNovo, :BoletosLogRequisicao, :BoletosLogResponse, :BoletosLogCodigoHttp, :BoletosLogSucesso, :BoletosLogObservacao, :BoletosLogCreatedAt, :BoletosId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00387)
             ,new CursorDef("BC00388", "SELECT currval('BoletosLogId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00388,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00389", "SAVEPOINT gxupdate;UPDATE BoletosLog SET BoletosLogOperacao=:BoletosLogOperacao, BoletosLogStatusAnterior=:BoletosLogStatusAnterior, BoletosLogStatusNovo=:BoletosLogStatusNovo, BoletosLogRequisicao=:BoletosLogRequisicao, BoletosLogResponse=:BoletosLogResponse, BoletosLogCodigoHttp=:BoletosLogCodigoHttp, BoletosLogSucesso=:BoletosLogSucesso, BoletosLogObservacao=:BoletosLogObservacao, BoletosLogCreatedAt=:BoletosLogCreatedAt, BoletosId=:BoletosId  WHERE BoletosLogId = :BoletosLogId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00389)
             ,new CursorDef("BC003810", "SAVEPOINT gxupdate;DELETE FROM BoletosLog  WHERE BoletosLogId = :BoletosLogId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC003810)
             ,new CursorDef("BC003811", "SELECT TM1.BoletosLogId, TM1.BoletosLogOperacao, TM1.BoletosLogStatusAnterior, TM1.BoletosLogStatusNovo, TM1.BoletosLogRequisicao, TM1.BoletosLogResponse, TM1.BoletosLogCodigoHttp, TM1.BoletosLogSucesso, TM1.BoletosLogObservacao, TM1.BoletosLogCreatedAt, TM1.BoletosId FROM BoletosLog TM1 WHERE TM1.BoletosLogId = :BoletosLogId ORDER BY TM1.BoletosLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC003811,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[17])[0] = rslt.getGXDateTime(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[17])[0] = rslt.getGXDateTime(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[17])[0] = rslt.getGXDateTime(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[17])[0] = rslt.getGXDateTime(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
       }
    }

 }

}
