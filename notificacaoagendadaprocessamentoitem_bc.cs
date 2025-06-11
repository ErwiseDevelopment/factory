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
   public class notificacaoagendadaprocessamentoitem_bc : GxSilentTrn, IGxSilentTrn
   {
      public notificacaoagendadaprocessamentoitem_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public notificacaoagendadaprocessamentoitem_bc( IGxContext context )
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
         ReadRow2W100( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2W100( ) ;
         standaloneModal( ) ;
         AddRow2W100( ) ;
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
               Z908NotificacaoAgendadaProcessamentoId = A908NotificacaoAgendadaProcessamentoId;
               Z916NotificacaoAgendadaProcessamentoItemId = A916NotificacaoAgendadaProcessamentoItemId;
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

      protected void CONFIRM_2W0( )
      {
         BeforeValidate2W100( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2W100( ) ;
            }
            else
            {
               CheckExtendedTable2W100( ) ;
               if ( AnyError == 0 )
               {
                  ZM2W100( 5) ;
               }
               CloseExtendedTableCursors2W100( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM2W100( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z917NotificacaoAgendadaProcessamentoItemExecucao = A917NotificacaoAgendadaProcessamentoItemExecucao;
            Z919NotificacaoAgendadaProcessamentoItemTipo = A919NotificacaoAgendadaProcessamentoItemTipo;
            Z920NotificacaoAgendadaProcessamentoItemSituacao = A920NotificacaoAgendadaProcessamentoItemSituacao;
            Z921NotificacaoAgendadaProcessamentoItemRetorno = A921NotificacaoAgendadaProcessamentoItemRetorno;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -4 )
         {
            Z916NotificacaoAgendadaProcessamentoItemId = A916NotificacaoAgendadaProcessamentoItemId;
            Z917NotificacaoAgendadaProcessamentoItemExecucao = A917NotificacaoAgendadaProcessamentoItemExecucao;
            Z918NotificacaoAgendadaProcessamentoItemJson = A918NotificacaoAgendadaProcessamentoItemJson;
            Z919NotificacaoAgendadaProcessamentoItemTipo = A919NotificacaoAgendadaProcessamentoItemTipo;
            Z920NotificacaoAgendadaProcessamentoItemSituacao = A920NotificacaoAgendadaProcessamentoItemSituacao;
            Z921NotificacaoAgendadaProcessamentoItemRetorno = A921NotificacaoAgendadaProcessamentoItemRetorno;
            Z908NotificacaoAgendadaProcessamentoId = A908NotificacaoAgendadaProcessamentoId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load2W100( )
      {
         /* Using cursor BC002W5 */
         pr_default.execute(3, new Object[] {A908NotificacaoAgendadaProcessamentoId, A916NotificacaoAgendadaProcessamentoItemId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound100 = 1;
            A917NotificacaoAgendadaProcessamentoItemExecucao = BC002W5_A917NotificacaoAgendadaProcessamentoItemExecucao[0];
            n917NotificacaoAgendadaProcessamentoItemExecucao = BC002W5_n917NotificacaoAgendadaProcessamentoItemExecucao[0];
            A918NotificacaoAgendadaProcessamentoItemJson = BC002W5_A918NotificacaoAgendadaProcessamentoItemJson[0];
            n918NotificacaoAgendadaProcessamentoItemJson = BC002W5_n918NotificacaoAgendadaProcessamentoItemJson[0];
            A919NotificacaoAgendadaProcessamentoItemTipo = BC002W5_A919NotificacaoAgendadaProcessamentoItemTipo[0];
            n919NotificacaoAgendadaProcessamentoItemTipo = BC002W5_n919NotificacaoAgendadaProcessamentoItemTipo[0];
            A920NotificacaoAgendadaProcessamentoItemSituacao = BC002W5_A920NotificacaoAgendadaProcessamentoItemSituacao[0];
            n920NotificacaoAgendadaProcessamentoItemSituacao = BC002W5_n920NotificacaoAgendadaProcessamentoItemSituacao[0];
            A921NotificacaoAgendadaProcessamentoItemRetorno = BC002W5_A921NotificacaoAgendadaProcessamentoItemRetorno[0];
            n921NotificacaoAgendadaProcessamentoItemRetorno = BC002W5_n921NotificacaoAgendadaProcessamentoItemRetorno[0];
            ZM2W100( -4) ;
         }
         pr_default.close(3);
         OnLoadActions2W100( ) ;
      }

      protected void OnLoadActions2W100( )
      {
      }

      protected void CheckExtendedTable2W100( )
      {
         standaloneModal( ) ;
         /* Using cursor BC002W4 */
         pr_default.execute(2, new Object[] {A908NotificacaoAgendadaProcessamentoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'NotificacaoAgendadaProcessamento'.", "ForeignKeyNotFound", 1, "NOTIFICACAOAGENDADAPROCESSAMENTOID");
            AnyError = 1;
         }
         pr_default.close(2);
         if ( ! ( ( StringUtil.StrCmp(A919NotificacaoAgendadaProcessamentoItemTipo, "V") == 0 ) || ( StringUtil.StrCmp(A919NotificacaoAgendadaProcessamentoItemTipo, "P") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A919NotificacaoAgendadaProcessamentoItemTipo)) ) )
         {
            GX_msglist.addItem("Campo Tipo de processamento fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A920NotificacaoAgendadaProcessamentoItemSituacao, "F") == 0 ) || ( StringUtil.StrCmp(A920NotificacaoAgendadaProcessamentoItemSituacao, "P") == 0 ) || ( StringUtil.StrCmp(A920NotificacaoAgendadaProcessamentoItemSituacao, "S") == 0 ) || ( StringUtil.StrCmp(A920NotificacaoAgendadaProcessamentoItemSituacao, "E") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A920NotificacaoAgendadaProcessamentoItemSituacao)) ) )
         {
            GX_msglist.addItem("Campo Situação do item de processamento fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors2W100( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2W100( )
      {
         /* Using cursor BC002W6 */
         pr_default.execute(4, new Object[] {A908NotificacaoAgendadaProcessamentoId, A916NotificacaoAgendadaProcessamentoItemId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound100 = 1;
         }
         else
         {
            RcdFound100 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC002W3 */
         pr_default.execute(1, new Object[] {A908NotificacaoAgendadaProcessamentoId, A916NotificacaoAgendadaProcessamentoItemId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2W100( 4) ;
            RcdFound100 = 1;
            A916NotificacaoAgendadaProcessamentoItemId = BC002W3_A916NotificacaoAgendadaProcessamentoItemId[0];
            A917NotificacaoAgendadaProcessamentoItemExecucao = BC002W3_A917NotificacaoAgendadaProcessamentoItemExecucao[0];
            n917NotificacaoAgendadaProcessamentoItemExecucao = BC002W3_n917NotificacaoAgendadaProcessamentoItemExecucao[0];
            A918NotificacaoAgendadaProcessamentoItemJson = BC002W3_A918NotificacaoAgendadaProcessamentoItemJson[0];
            n918NotificacaoAgendadaProcessamentoItemJson = BC002W3_n918NotificacaoAgendadaProcessamentoItemJson[0];
            A919NotificacaoAgendadaProcessamentoItemTipo = BC002W3_A919NotificacaoAgendadaProcessamentoItemTipo[0];
            n919NotificacaoAgendadaProcessamentoItemTipo = BC002W3_n919NotificacaoAgendadaProcessamentoItemTipo[0];
            A920NotificacaoAgendadaProcessamentoItemSituacao = BC002W3_A920NotificacaoAgendadaProcessamentoItemSituacao[0];
            n920NotificacaoAgendadaProcessamentoItemSituacao = BC002W3_n920NotificacaoAgendadaProcessamentoItemSituacao[0];
            A921NotificacaoAgendadaProcessamentoItemRetorno = BC002W3_A921NotificacaoAgendadaProcessamentoItemRetorno[0];
            n921NotificacaoAgendadaProcessamentoItemRetorno = BC002W3_n921NotificacaoAgendadaProcessamentoItemRetorno[0];
            A908NotificacaoAgendadaProcessamentoId = BC002W3_A908NotificacaoAgendadaProcessamentoId[0];
            Z908NotificacaoAgendadaProcessamentoId = A908NotificacaoAgendadaProcessamentoId;
            Z916NotificacaoAgendadaProcessamentoItemId = A916NotificacaoAgendadaProcessamentoItemId;
            sMode100 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2W100( ) ;
            if ( AnyError == 1 )
            {
               RcdFound100 = 0;
               InitializeNonKey2W100( ) ;
            }
            Gx_mode = sMode100;
         }
         else
         {
            RcdFound100 = 0;
            InitializeNonKey2W100( ) ;
            sMode100 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode100;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2W100( ) ;
         if ( RcdFound100 == 0 )
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
         CONFIRM_2W0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2W100( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC002W2 */
            pr_default.execute(0, new Object[] {A908NotificacaoAgendadaProcessamentoId, A916NotificacaoAgendadaProcessamentoItemId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"NotificacaoAgendadaProcessamentoItem"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z917NotificacaoAgendadaProcessamentoItemExecucao != BC002W2_A917NotificacaoAgendadaProcessamentoItemExecucao[0] ) || ( StringUtil.StrCmp(Z919NotificacaoAgendadaProcessamentoItemTipo, BC002W2_A919NotificacaoAgendadaProcessamentoItemTipo[0]) != 0 ) || ( StringUtil.StrCmp(Z920NotificacaoAgendadaProcessamentoItemSituacao, BC002W2_A920NotificacaoAgendadaProcessamentoItemSituacao[0]) != 0 ) || ( StringUtil.StrCmp(Z921NotificacaoAgendadaProcessamentoItemRetorno, BC002W2_A921NotificacaoAgendadaProcessamentoItemRetorno[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"NotificacaoAgendadaProcessamentoItem"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2W100( )
      {
         BeforeValidate2W100( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2W100( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2W100( 0) ;
            CheckOptimisticConcurrency2W100( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2W100( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2W100( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002W7 */
                     pr_default.execute(5, new Object[] {A916NotificacaoAgendadaProcessamentoItemId, n917NotificacaoAgendadaProcessamentoItemExecucao, A917NotificacaoAgendadaProcessamentoItemExecucao, n918NotificacaoAgendadaProcessamentoItemJson, A918NotificacaoAgendadaProcessamentoItemJson, n919NotificacaoAgendadaProcessamentoItemTipo, A919NotificacaoAgendadaProcessamentoItemTipo, n920NotificacaoAgendadaProcessamentoItemSituacao, A920NotificacaoAgendadaProcessamentoItemSituacao, n921NotificacaoAgendadaProcessamentoItemRetorno, A921NotificacaoAgendadaProcessamentoItemRetorno, A908NotificacaoAgendadaProcessamentoId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("NotificacaoAgendadaProcessamentoItem");
                     if ( (pr_default.getStatus(5) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
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
               Load2W100( ) ;
            }
            EndLevel2W100( ) ;
         }
         CloseExtendedTableCursors2W100( ) ;
      }

      protected void Update2W100( )
      {
         BeforeValidate2W100( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2W100( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2W100( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2W100( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2W100( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002W8 */
                     pr_default.execute(6, new Object[] {n917NotificacaoAgendadaProcessamentoItemExecucao, A917NotificacaoAgendadaProcessamentoItemExecucao, n918NotificacaoAgendadaProcessamentoItemJson, A918NotificacaoAgendadaProcessamentoItemJson, n919NotificacaoAgendadaProcessamentoItemTipo, A919NotificacaoAgendadaProcessamentoItemTipo, n920NotificacaoAgendadaProcessamentoItemSituacao, A920NotificacaoAgendadaProcessamentoItemSituacao, n921NotificacaoAgendadaProcessamentoItemRetorno, A921NotificacaoAgendadaProcessamentoItemRetorno, A908NotificacaoAgendadaProcessamentoId, A916NotificacaoAgendadaProcessamentoItemId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("NotificacaoAgendadaProcessamentoItem");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"NotificacaoAgendadaProcessamentoItem"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2W100( ) ;
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
            EndLevel2W100( ) ;
         }
         CloseExtendedTableCursors2W100( ) ;
      }

      protected void DeferredUpdate2W100( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2W100( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2W100( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2W100( ) ;
            AfterConfirm2W100( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2W100( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002W9 */
                  pr_default.execute(7, new Object[] {A908NotificacaoAgendadaProcessamentoId, A916NotificacaoAgendadaProcessamentoItemId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("NotificacaoAgendadaProcessamentoItem");
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
         sMode100 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2W100( ) ;
         Gx_mode = sMode100;
      }

      protected void OnDeleteControls2W100( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2W100( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2W100( ) ;
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

      public void ScanKeyStart2W100( )
      {
         /* Using cursor BC002W10 */
         pr_default.execute(8, new Object[] {A908NotificacaoAgendadaProcessamentoId, A916NotificacaoAgendadaProcessamentoItemId});
         RcdFound100 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound100 = 1;
            A916NotificacaoAgendadaProcessamentoItemId = BC002W10_A916NotificacaoAgendadaProcessamentoItemId[0];
            A917NotificacaoAgendadaProcessamentoItemExecucao = BC002W10_A917NotificacaoAgendadaProcessamentoItemExecucao[0];
            n917NotificacaoAgendadaProcessamentoItemExecucao = BC002W10_n917NotificacaoAgendadaProcessamentoItemExecucao[0];
            A918NotificacaoAgendadaProcessamentoItemJson = BC002W10_A918NotificacaoAgendadaProcessamentoItemJson[0];
            n918NotificacaoAgendadaProcessamentoItemJson = BC002W10_n918NotificacaoAgendadaProcessamentoItemJson[0];
            A919NotificacaoAgendadaProcessamentoItemTipo = BC002W10_A919NotificacaoAgendadaProcessamentoItemTipo[0];
            n919NotificacaoAgendadaProcessamentoItemTipo = BC002W10_n919NotificacaoAgendadaProcessamentoItemTipo[0];
            A920NotificacaoAgendadaProcessamentoItemSituacao = BC002W10_A920NotificacaoAgendadaProcessamentoItemSituacao[0];
            n920NotificacaoAgendadaProcessamentoItemSituacao = BC002W10_n920NotificacaoAgendadaProcessamentoItemSituacao[0];
            A921NotificacaoAgendadaProcessamentoItemRetorno = BC002W10_A921NotificacaoAgendadaProcessamentoItemRetorno[0];
            n921NotificacaoAgendadaProcessamentoItemRetorno = BC002W10_n921NotificacaoAgendadaProcessamentoItemRetorno[0];
            A908NotificacaoAgendadaProcessamentoId = BC002W10_A908NotificacaoAgendadaProcessamentoId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2W100( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound100 = 0;
         ScanKeyLoad2W100( ) ;
      }

      protected void ScanKeyLoad2W100( )
      {
         sMode100 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound100 = 1;
            A916NotificacaoAgendadaProcessamentoItemId = BC002W10_A916NotificacaoAgendadaProcessamentoItemId[0];
            A917NotificacaoAgendadaProcessamentoItemExecucao = BC002W10_A917NotificacaoAgendadaProcessamentoItemExecucao[0];
            n917NotificacaoAgendadaProcessamentoItemExecucao = BC002W10_n917NotificacaoAgendadaProcessamentoItemExecucao[0];
            A918NotificacaoAgendadaProcessamentoItemJson = BC002W10_A918NotificacaoAgendadaProcessamentoItemJson[0];
            n918NotificacaoAgendadaProcessamentoItemJson = BC002W10_n918NotificacaoAgendadaProcessamentoItemJson[0];
            A919NotificacaoAgendadaProcessamentoItemTipo = BC002W10_A919NotificacaoAgendadaProcessamentoItemTipo[0];
            n919NotificacaoAgendadaProcessamentoItemTipo = BC002W10_n919NotificacaoAgendadaProcessamentoItemTipo[0];
            A920NotificacaoAgendadaProcessamentoItemSituacao = BC002W10_A920NotificacaoAgendadaProcessamentoItemSituacao[0];
            n920NotificacaoAgendadaProcessamentoItemSituacao = BC002W10_n920NotificacaoAgendadaProcessamentoItemSituacao[0];
            A921NotificacaoAgendadaProcessamentoItemRetorno = BC002W10_A921NotificacaoAgendadaProcessamentoItemRetorno[0];
            n921NotificacaoAgendadaProcessamentoItemRetorno = BC002W10_n921NotificacaoAgendadaProcessamentoItemRetorno[0];
            A908NotificacaoAgendadaProcessamentoId = BC002W10_A908NotificacaoAgendadaProcessamentoId[0];
         }
         Gx_mode = sMode100;
      }

      protected void ScanKeyEnd2W100( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm2W100( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2W100( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2W100( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2W100( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2W100( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2W100( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2W100( )
      {
      }

      protected void send_integrity_lvl_hashes2W100( )
      {
      }

      protected void AddRow2W100( )
      {
         VarsToRow100( bcNotificacaoAgendadaProcessamentoItem) ;
      }

      protected void ReadRow2W100( )
      {
         RowToVars100( bcNotificacaoAgendadaProcessamentoItem, 1) ;
      }

      protected void InitializeNonKey2W100( )
      {
         A917NotificacaoAgendadaProcessamentoItemExecucao = (DateTime)(DateTime.MinValue);
         n917NotificacaoAgendadaProcessamentoItemExecucao = false;
         A918NotificacaoAgendadaProcessamentoItemJson = "";
         n918NotificacaoAgendadaProcessamentoItemJson = false;
         A919NotificacaoAgendadaProcessamentoItemTipo = "";
         n919NotificacaoAgendadaProcessamentoItemTipo = false;
         A920NotificacaoAgendadaProcessamentoItemSituacao = "";
         n920NotificacaoAgendadaProcessamentoItemSituacao = false;
         A921NotificacaoAgendadaProcessamentoItemRetorno = "";
         n921NotificacaoAgendadaProcessamentoItemRetorno = false;
         Z917NotificacaoAgendadaProcessamentoItemExecucao = (DateTime)(DateTime.MinValue);
         Z919NotificacaoAgendadaProcessamentoItemTipo = "";
         Z920NotificacaoAgendadaProcessamentoItemSituacao = "";
         Z921NotificacaoAgendadaProcessamentoItemRetorno = "";
      }

      protected void InitAll2W100( )
      {
         A908NotificacaoAgendadaProcessamentoId = Guid.Empty;
         A916NotificacaoAgendadaProcessamentoItemId = 0;
         InitializeNonKey2W100( ) ;
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

      public void VarsToRow100( SdtNotificacaoAgendadaProcessamentoItem obj100 )
      {
         obj100.gxTpr_Mode = Gx_mode;
         obj100.gxTpr_Notificacaoagendadaprocessamentoitemexecucao = A917NotificacaoAgendadaProcessamentoItemExecucao;
         obj100.gxTpr_Notificacaoagendadaprocessamentoitemjson = A918NotificacaoAgendadaProcessamentoItemJson;
         obj100.gxTpr_Notificacaoagendadaprocessamentoitemtipo = A919NotificacaoAgendadaProcessamentoItemTipo;
         obj100.gxTpr_Notificacaoagendadaprocessamentoitemsituacao = A920NotificacaoAgendadaProcessamentoItemSituacao;
         obj100.gxTpr_Notificacaoagendadaprocessamentoitemretorno = A921NotificacaoAgendadaProcessamentoItemRetorno;
         obj100.gxTpr_Notificacaoagendadaprocessamentoid = A908NotificacaoAgendadaProcessamentoId;
         obj100.gxTpr_Notificacaoagendadaprocessamentoitemid = A916NotificacaoAgendadaProcessamentoItemId;
         obj100.gxTpr_Notificacaoagendadaprocessamentoid_Z = Z908NotificacaoAgendadaProcessamentoId;
         obj100.gxTpr_Notificacaoagendadaprocessamentoitemid_Z = Z916NotificacaoAgendadaProcessamentoItemId;
         obj100.gxTpr_Notificacaoagendadaprocessamentoitemexecucao_Z = Z917NotificacaoAgendadaProcessamentoItemExecucao;
         obj100.gxTpr_Notificacaoagendadaprocessamentoitemtipo_Z = Z919NotificacaoAgendadaProcessamentoItemTipo;
         obj100.gxTpr_Notificacaoagendadaprocessamentoitemsituacao_Z = Z920NotificacaoAgendadaProcessamentoItemSituacao;
         obj100.gxTpr_Notificacaoagendadaprocessamentoitemretorno_Z = Z921NotificacaoAgendadaProcessamentoItemRetorno;
         obj100.gxTpr_Notificacaoagendadaprocessamentoitemexecucao_N = (short)(Convert.ToInt16(n917NotificacaoAgendadaProcessamentoItemExecucao));
         obj100.gxTpr_Notificacaoagendadaprocessamentoitemjson_N = (short)(Convert.ToInt16(n918NotificacaoAgendadaProcessamentoItemJson));
         obj100.gxTpr_Notificacaoagendadaprocessamentoitemtipo_N = (short)(Convert.ToInt16(n919NotificacaoAgendadaProcessamentoItemTipo));
         obj100.gxTpr_Notificacaoagendadaprocessamentoitemsituacao_N = (short)(Convert.ToInt16(n920NotificacaoAgendadaProcessamentoItemSituacao));
         obj100.gxTpr_Notificacaoagendadaprocessamentoitemretorno_N = (short)(Convert.ToInt16(n921NotificacaoAgendadaProcessamentoItemRetorno));
         obj100.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow100( SdtNotificacaoAgendadaProcessamentoItem obj100 )
      {
         obj100.gxTpr_Notificacaoagendadaprocessamentoid = A908NotificacaoAgendadaProcessamentoId;
         obj100.gxTpr_Notificacaoagendadaprocessamentoitemid = A916NotificacaoAgendadaProcessamentoItemId;
         return  ;
      }

      public void RowToVars100( SdtNotificacaoAgendadaProcessamentoItem obj100 ,
                                int forceLoad )
      {
         Gx_mode = obj100.gxTpr_Mode;
         A917NotificacaoAgendadaProcessamentoItemExecucao = obj100.gxTpr_Notificacaoagendadaprocessamentoitemexecucao;
         n917NotificacaoAgendadaProcessamentoItemExecucao = false;
         A918NotificacaoAgendadaProcessamentoItemJson = obj100.gxTpr_Notificacaoagendadaprocessamentoitemjson;
         n918NotificacaoAgendadaProcessamentoItemJson = false;
         A919NotificacaoAgendadaProcessamentoItemTipo = obj100.gxTpr_Notificacaoagendadaprocessamentoitemtipo;
         n919NotificacaoAgendadaProcessamentoItemTipo = false;
         A920NotificacaoAgendadaProcessamentoItemSituacao = obj100.gxTpr_Notificacaoagendadaprocessamentoitemsituacao;
         n920NotificacaoAgendadaProcessamentoItemSituacao = false;
         A921NotificacaoAgendadaProcessamentoItemRetorno = obj100.gxTpr_Notificacaoagendadaprocessamentoitemretorno;
         n921NotificacaoAgendadaProcessamentoItemRetorno = false;
         A908NotificacaoAgendadaProcessamentoId = obj100.gxTpr_Notificacaoagendadaprocessamentoid;
         A916NotificacaoAgendadaProcessamentoItemId = obj100.gxTpr_Notificacaoagendadaprocessamentoitemid;
         Z908NotificacaoAgendadaProcessamentoId = obj100.gxTpr_Notificacaoagendadaprocessamentoid_Z;
         Z916NotificacaoAgendadaProcessamentoItemId = obj100.gxTpr_Notificacaoagendadaprocessamentoitemid_Z;
         Z917NotificacaoAgendadaProcessamentoItemExecucao = obj100.gxTpr_Notificacaoagendadaprocessamentoitemexecucao_Z;
         Z919NotificacaoAgendadaProcessamentoItemTipo = obj100.gxTpr_Notificacaoagendadaprocessamentoitemtipo_Z;
         Z920NotificacaoAgendadaProcessamentoItemSituacao = obj100.gxTpr_Notificacaoagendadaprocessamentoitemsituacao_Z;
         Z921NotificacaoAgendadaProcessamentoItemRetorno = obj100.gxTpr_Notificacaoagendadaprocessamentoitemretorno_Z;
         n917NotificacaoAgendadaProcessamentoItemExecucao = (bool)(Convert.ToBoolean(obj100.gxTpr_Notificacaoagendadaprocessamentoitemexecucao_N));
         n918NotificacaoAgendadaProcessamentoItemJson = (bool)(Convert.ToBoolean(obj100.gxTpr_Notificacaoagendadaprocessamentoitemjson_N));
         n919NotificacaoAgendadaProcessamentoItemTipo = (bool)(Convert.ToBoolean(obj100.gxTpr_Notificacaoagendadaprocessamentoitemtipo_N));
         n920NotificacaoAgendadaProcessamentoItemSituacao = (bool)(Convert.ToBoolean(obj100.gxTpr_Notificacaoagendadaprocessamentoitemsituacao_N));
         n921NotificacaoAgendadaProcessamentoItemRetorno = (bool)(Convert.ToBoolean(obj100.gxTpr_Notificacaoagendadaprocessamentoitemretorno_N));
         Gx_mode = obj100.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A908NotificacaoAgendadaProcessamentoId = (Guid)getParm(obj,0);
         A916NotificacaoAgendadaProcessamentoItemId = (int)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2W100( ) ;
         ScanKeyStart2W100( ) ;
         if ( RcdFound100 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC002W11 */
            pr_default.execute(9, new Object[] {A908NotificacaoAgendadaProcessamentoId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem("Não existe 'NotificacaoAgendadaProcessamento'.", "ForeignKeyNotFound", 1, "NOTIFICACAOAGENDADAPROCESSAMENTOID");
               AnyError = 1;
            }
            pr_default.close(9);
         }
         else
         {
            Gx_mode = "UPD";
            Z908NotificacaoAgendadaProcessamentoId = A908NotificacaoAgendadaProcessamentoId;
            Z916NotificacaoAgendadaProcessamentoItemId = A916NotificacaoAgendadaProcessamentoItemId;
         }
         ZM2W100( -4) ;
         OnLoadActions2W100( ) ;
         AddRow2W100( ) ;
         ScanKeyEnd2W100( ) ;
         if ( RcdFound100 == 0 )
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
         RowToVars100( bcNotificacaoAgendadaProcessamentoItem, 0) ;
         ScanKeyStart2W100( ) ;
         if ( RcdFound100 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC002W11 */
            pr_default.execute(9, new Object[] {A908NotificacaoAgendadaProcessamentoId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem("Não existe 'NotificacaoAgendadaProcessamento'.", "ForeignKeyNotFound", 1, "NOTIFICACAOAGENDADAPROCESSAMENTOID");
               AnyError = 1;
            }
            pr_default.close(9);
         }
         else
         {
            Gx_mode = "UPD";
            Z908NotificacaoAgendadaProcessamentoId = A908NotificacaoAgendadaProcessamentoId;
            Z916NotificacaoAgendadaProcessamentoItemId = A916NotificacaoAgendadaProcessamentoItemId;
         }
         ZM2W100( -4) ;
         OnLoadActions2W100( ) ;
         AddRow2W100( ) ;
         ScanKeyEnd2W100( ) ;
         if ( RcdFound100 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2W100( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2W100( ) ;
         }
         else
         {
            if ( RcdFound100 == 1 )
            {
               if ( ( A908NotificacaoAgendadaProcessamentoId != Z908NotificacaoAgendadaProcessamentoId ) || ( A916NotificacaoAgendadaProcessamentoItemId != Z916NotificacaoAgendadaProcessamentoItemId ) )
               {
                  A908NotificacaoAgendadaProcessamentoId = Z908NotificacaoAgendadaProcessamentoId;
                  A916NotificacaoAgendadaProcessamentoItemId = Z916NotificacaoAgendadaProcessamentoItemId;
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
                  Update2W100( ) ;
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
                  if ( ( A908NotificacaoAgendadaProcessamentoId != Z908NotificacaoAgendadaProcessamentoId ) || ( A916NotificacaoAgendadaProcessamentoItemId != Z916NotificacaoAgendadaProcessamentoItemId ) )
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
                        Insert2W100( ) ;
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
                        Insert2W100( ) ;
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
         RowToVars100( bcNotificacaoAgendadaProcessamentoItem, 1) ;
         SaveImpl( ) ;
         VarsToRow100( bcNotificacaoAgendadaProcessamentoItem) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars100( bcNotificacaoAgendadaProcessamentoItem, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2W100( ) ;
         AfterTrn( ) ;
         VarsToRow100( bcNotificacaoAgendadaProcessamentoItem) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow100( bcNotificacaoAgendadaProcessamentoItem) ;
         }
         else
         {
            SdtNotificacaoAgendadaProcessamentoItem auxBC = new SdtNotificacaoAgendadaProcessamentoItem(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A908NotificacaoAgendadaProcessamentoId, A916NotificacaoAgendadaProcessamentoItemId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcNotificacaoAgendadaProcessamentoItem);
               auxBC.Save();
               bcNotificacaoAgendadaProcessamentoItem.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars100( bcNotificacaoAgendadaProcessamentoItem, 1) ;
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
         RowToVars100( bcNotificacaoAgendadaProcessamentoItem, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2W100( ) ;
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
               VarsToRow100( bcNotificacaoAgendadaProcessamentoItem) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow100( bcNotificacaoAgendadaProcessamentoItem) ;
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
         RowToVars100( bcNotificacaoAgendadaProcessamentoItem, 0) ;
         GetKey2W100( ) ;
         if ( RcdFound100 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A908NotificacaoAgendadaProcessamentoId != Z908NotificacaoAgendadaProcessamentoId ) || ( A916NotificacaoAgendadaProcessamentoItemId != Z916NotificacaoAgendadaProcessamentoItemId ) )
            {
               A908NotificacaoAgendadaProcessamentoId = Z908NotificacaoAgendadaProcessamentoId;
               A916NotificacaoAgendadaProcessamentoItemId = Z916NotificacaoAgendadaProcessamentoItemId;
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
            if ( ( A908NotificacaoAgendadaProcessamentoId != Z908NotificacaoAgendadaProcessamentoId ) || ( A916NotificacaoAgendadaProcessamentoItemId != Z916NotificacaoAgendadaProcessamentoItemId ) )
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
         context.RollbackDataStores("notificacaoagendadaprocessamentoitem_bc",pr_default);
         VarsToRow100( bcNotificacaoAgendadaProcessamentoItem) ;
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
         Gx_mode = bcNotificacaoAgendadaProcessamentoItem.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcNotificacaoAgendadaProcessamentoItem.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcNotificacaoAgendadaProcessamentoItem )
         {
            bcNotificacaoAgendadaProcessamentoItem = (SdtNotificacaoAgendadaProcessamentoItem)(sdt);
            if ( StringUtil.StrCmp(bcNotificacaoAgendadaProcessamentoItem.gxTpr_Mode, "") == 0 )
            {
               bcNotificacaoAgendadaProcessamentoItem.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow100( bcNotificacaoAgendadaProcessamentoItem) ;
            }
            else
            {
               RowToVars100( bcNotificacaoAgendadaProcessamentoItem, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcNotificacaoAgendadaProcessamentoItem.gxTpr_Mode, "") == 0 )
            {
               bcNotificacaoAgendadaProcessamentoItem.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars100( bcNotificacaoAgendadaProcessamentoItem, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtNotificacaoAgendadaProcessamentoItem NotificacaoAgendadaProcessamentoItem_BC
      {
         get {
            return bcNotificacaoAgendadaProcessamentoItem ;
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
         pr_default.close(9);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z908NotificacaoAgendadaProcessamentoId = Guid.Empty;
         A908NotificacaoAgendadaProcessamentoId = Guid.Empty;
         Z917NotificacaoAgendadaProcessamentoItemExecucao = (DateTime)(DateTime.MinValue);
         A917NotificacaoAgendadaProcessamentoItemExecucao = (DateTime)(DateTime.MinValue);
         Z919NotificacaoAgendadaProcessamentoItemTipo = "";
         A919NotificacaoAgendadaProcessamentoItemTipo = "";
         Z920NotificacaoAgendadaProcessamentoItemSituacao = "";
         A920NotificacaoAgendadaProcessamentoItemSituacao = "";
         Z921NotificacaoAgendadaProcessamentoItemRetorno = "";
         A921NotificacaoAgendadaProcessamentoItemRetorno = "";
         Z918NotificacaoAgendadaProcessamentoItemJson = "";
         A918NotificacaoAgendadaProcessamentoItemJson = "";
         BC002W5_A916NotificacaoAgendadaProcessamentoItemId = new int[1] ;
         BC002W5_A917NotificacaoAgendadaProcessamentoItemExecucao = new DateTime[] {DateTime.MinValue} ;
         BC002W5_n917NotificacaoAgendadaProcessamentoItemExecucao = new bool[] {false} ;
         BC002W5_A918NotificacaoAgendadaProcessamentoItemJson = new string[] {""} ;
         BC002W5_n918NotificacaoAgendadaProcessamentoItemJson = new bool[] {false} ;
         BC002W5_A919NotificacaoAgendadaProcessamentoItemTipo = new string[] {""} ;
         BC002W5_n919NotificacaoAgendadaProcessamentoItemTipo = new bool[] {false} ;
         BC002W5_A920NotificacaoAgendadaProcessamentoItemSituacao = new string[] {""} ;
         BC002W5_n920NotificacaoAgendadaProcessamentoItemSituacao = new bool[] {false} ;
         BC002W5_A921NotificacaoAgendadaProcessamentoItemRetorno = new string[] {""} ;
         BC002W5_n921NotificacaoAgendadaProcessamentoItemRetorno = new bool[] {false} ;
         BC002W5_A908NotificacaoAgendadaProcessamentoId = new Guid[] {Guid.Empty} ;
         BC002W4_A908NotificacaoAgendadaProcessamentoId = new Guid[] {Guid.Empty} ;
         BC002W6_A908NotificacaoAgendadaProcessamentoId = new Guid[] {Guid.Empty} ;
         BC002W6_A916NotificacaoAgendadaProcessamentoItemId = new int[1] ;
         BC002W3_A916NotificacaoAgendadaProcessamentoItemId = new int[1] ;
         BC002W3_A917NotificacaoAgendadaProcessamentoItemExecucao = new DateTime[] {DateTime.MinValue} ;
         BC002W3_n917NotificacaoAgendadaProcessamentoItemExecucao = new bool[] {false} ;
         BC002W3_A918NotificacaoAgendadaProcessamentoItemJson = new string[] {""} ;
         BC002W3_n918NotificacaoAgendadaProcessamentoItemJson = new bool[] {false} ;
         BC002W3_A919NotificacaoAgendadaProcessamentoItemTipo = new string[] {""} ;
         BC002W3_n919NotificacaoAgendadaProcessamentoItemTipo = new bool[] {false} ;
         BC002W3_A920NotificacaoAgendadaProcessamentoItemSituacao = new string[] {""} ;
         BC002W3_n920NotificacaoAgendadaProcessamentoItemSituacao = new bool[] {false} ;
         BC002W3_A921NotificacaoAgendadaProcessamentoItemRetorno = new string[] {""} ;
         BC002W3_n921NotificacaoAgendadaProcessamentoItemRetorno = new bool[] {false} ;
         BC002W3_A908NotificacaoAgendadaProcessamentoId = new Guid[] {Guid.Empty} ;
         sMode100 = "";
         BC002W2_A916NotificacaoAgendadaProcessamentoItemId = new int[1] ;
         BC002W2_A917NotificacaoAgendadaProcessamentoItemExecucao = new DateTime[] {DateTime.MinValue} ;
         BC002W2_n917NotificacaoAgendadaProcessamentoItemExecucao = new bool[] {false} ;
         BC002W2_A918NotificacaoAgendadaProcessamentoItemJson = new string[] {""} ;
         BC002W2_n918NotificacaoAgendadaProcessamentoItemJson = new bool[] {false} ;
         BC002W2_A919NotificacaoAgendadaProcessamentoItemTipo = new string[] {""} ;
         BC002W2_n919NotificacaoAgendadaProcessamentoItemTipo = new bool[] {false} ;
         BC002W2_A920NotificacaoAgendadaProcessamentoItemSituacao = new string[] {""} ;
         BC002W2_n920NotificacaoAgendadaProcessamentoItemSituacao = new bool[] {false} ;
         BC002W2_A921NotificacaoAgendadaProcessamentoItemRetorno = new string[] {""} ;
         BC002W2_n921NotificacaoAgendadaProcessamentoItemRetorno = new bool[] {false} ;
         BC002W2_A908NotificacaoAgendadaProcessamentoId = new Guid[] {Guid.Empty} ;
         BC002W10_A916NotificacaoAgendadaProcessamentoItemId = new int[1] ;
         BC002W10_A917NotificacaoAgendadaProcessamentoItemExecucao = new DateTime[] {DateTime.MinValue} ;
         BC002W10_n917NotificacaoAgendadaProcessamentoItemExecucao = new bool[] {false} ;
         BC002W10_A918NotificacaoAgendadaProcessamentoItemJson = new string[] {""} ;
         BC002W10_n918NotificacaoAgendadaProcessamentoItemJson = new bool[] {false} ;
         BC002W10_A919NotificacaoAgendadaProcessamentoItemTipo = new string[] {""} ;
         BC002W10_n919NotificacaoAgendadaProcessamentoItemTipo = new bool[] {false} ;
         BC002W10_A920NotificacaoAgendadaProcessamentoItemSituacao = new string[] {""} ;
         BC002W10_n920NotificacaoAgendadaProcessamentoItemSituacao = new bool[] {false} ;
         BC002W10_A921NotificacaoAgendadaProcessamentoItemRetorno = new string[] {""} ;
         BC002W10_n921NotificacaoAgendadaProcessamentoItemRetorno = new bool[] {false} ;
         BC002W10_A908NotificacaoAgendadaProcessamentoId = new Guid[] {Guid.Empty} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC002W11_A908NotificacaoAgendadaProcessamentoId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.notificacaoagendadaprocessamentoitem_bc__default(),
            new Object[][] {
                new Object[] {
               BC002W2_A916NotificacaoAgendadaProcessamentoItemId, BC002W2_A917NotificacaoAgendadaProcessamentoItemExecucao, BC002W2_n917NotificacaoAgendadaProcessamentoItemExecucao, BC002W2_A918NotificacaoAgendadaProcessamentoItemJson, BC002W2_n918NotificacaoAgendadaProcessamentoItemJson, BC002W2_A919NotificacaoAgendadaProcessamentoItemTipo, BC002W2_n919NotificacaoAgendadaProcessamentoItemTipo, BC002W2_A920NotificacaoAgendadaProcessamentoItemSituacao, BC002W2_n920NotificacaoAgendadaProcessamentoItemSituacao, BC002W2_A921NotificacaoAgendadaProcessamentoItemRetorno,
               BC002W2_n921NotificacaoAgendadaProcessamentoItemRetorno, BC002W2_A908NotificacaoAgendadaProcessamentoId
               }
               , new Object[] {
               BC002W3_A916NotificacaoAgendadaProcessamentoItemId, BC002W3_A917NotificacaoAgendadaProcessamentoItemExecucao, BC002W3_n917NotificacaoAgendadaProcessamentoItemExecucao, BC002W3_A918NotificacaoAgendadaProcessamentoItemJson, BC002W3_n918NotificacaoAgendadaProcessamentoItemJson, BC002W3_A919NotificacaoAgendadaProcessamentoItemTipo, BC002W3_n919NotificacaoAgendadaProcessamentoItemTipo, BC002W3_A920NotificacaoAgendadaProcessamentoItemSituacao, BC002W3_n920NotificacaoAgendadaProcessamentoItemSituacao, BC002W3_A921NotificacaoAgendadaProcessamentoItemRetorno,
               BC002W3_n921NotificacaoAgendadaProcessamentoItemRetorno, BC002W3_A908NotificacaoAgendadaProcessamentoId
               }
               , new Object[] {
               BC002W4_A908NotificacaoAgendadaProcessamentoId
               }
               , new Object[] {
               BC002W5_A916NotificacaoAgendadaProcessamentoItemId, BC002W5_A917NotificacaoAgendadaProcessamentoItemExecucao, BC002W5_n917NotificacaoAgendadaProcessamentoItemExecucao, BC002W5_A918NotificacaoAgendadaProcessamentoItemJson, BC002W5_n918NotificacaoAgendadaProcessamentoItemJson, BC002W5_A919NotificacaoAgendadaProcessamentoItemTipo, BC002W5_n919NotificacaoAgendadaProcessamentoItemTipo, BC002W5_A920NotificacaoAgendadaProcessamentoItemSituacao, BC002W5_n920NotificacaoAgendadaProcessamentoItemSituacao, BC002W5_A921NotificacaoAgendadaProcessamentoItemRetorno,
               BC002W5_n921NotificacaoAgendadaProcessamentoItemRetorno, BC002W5_A908NotificacaoAgendadaProcessamentoId
               }
               , new Object[] {
               BC002W6_A908NotificacaoAgendadaProcessamentoId, BC002W6_A916NotificacaoAgendadaProcessamentoItemId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002W10_A916NotificacaoAgendadaProcessamentoItemId, BC002W10_A917NotificacaoAgendadaProcessamentoItemExecucao, BC002W10_n917NotificacaoAgendadaProcessamentoItemExecucao, BC002W10_A918NotificacaoAgendadaProcessamentoItemJson, BC002W10_n918NotificacaoAgendadaProcessamentoItemJson, BC002W10_A919NotificacaoAgendadaProcessamentoItemTipo, BC002W10_n919NotificacaoAgendadaProcessamentoItemTipo, BC002W10_A920NotificacaoAgendadaProcessamentoItemSituacao, BC002W10_n920NotificacaoAgendadaProcessamentoItemSituacao, BC002W10_A921NotificacaoAgendadaProcessamentoItemRetorno,
               BC002W10_n921NotificacaoAgendadaProcessamentoItemRetorno, BC002W10_A908NotificacaoAgendadaProcessamentoId
               }
               , new Object[] {
               BC002W11_A908NotificacaoAgendadaProcessamentoId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound100 ;
      private int trnEnded ;
      private int Z916NotificacaoAgendadaProcessamentoItemId ;
      private int A916NotificacaoAgendadaProcessamentoItemId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode100 ;
      private DateTime Z917NotificacaoAgendadaProcessamentoItemExecucao ;
      private DateTime A917NotificacaoAgendadaProcessamentoItemExecucao ;
      private bool n917NotificacaoAgendadaProcessamentoItemExecucao ;
      private bool n918NotificacaoAgendadaProcessamentoItemJson ;
      private bool n919NotificacaoAgendadaProcessamentoItemTipo ;
      private bool n920NotificacaoAgendadaProcessamentoItemSituacao ;
      private bool n921NotificacaoAgendadaProcessamentoItemRetorno ;
      private string Z918NotificacaoAgendadaProcessamentoItemJson ;
      private string A918NotificacaoAgendadaProcessamentoItemJson ;
      private string Z919NotificacaoAgendadaProcessamentoItemTipo ;
      private string A919NotificacaoAgendadaProcessamentoItemTipo ;
      private string Z920NotificacaoAgendadaProcessamentoItemSituacao ;
      private string A920NotificacaoAgendadaProcessamentoItemSituacao ;
      private string Z921NotificacaoAgendadaProcessamentoItemRetorno ;
      private string A921NotificacaoAgendadaProcessamentoItemRetorno ;
      private Guid Z908NotificacaoAgendadaProcessamentoId ;
      private Guid A908NotificacaoAgendadaProcessamentoId ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC002W5_A916NotificacaoAgendadaProcessamentoItemId ;
      private DateTime[] BC002W5_A917NotificacaoAgendadaProcessamentoItemExecucao ;
      private bool[] BC002W5_n917NotificacaoAgendadaProcessamentoItemExecucao ;
      private string[] BC002W5_A918NotificacaoAgendadaProcessamentoItemJson ;
      private bool[] BC002W5_n918NotificacaoAgendadaProcessamentoItemJson ;
      private string[] BC002W5_A919NotificacaoAgendadaProcessamentoItemTipo ;
      private bool[] BC002W5_n919NotificacaoAgendadaProcessamentoItemTipo ;
      private string[] BC002W5_A920NotificacaoAgendadaProcessamentoItemSituacao ;
      private bool[] BC002W5_n920NotificacaoAgendadaProcessamentoItemSituacao ;
      private string[] BC002W5_A921NotificacaoAgendadaProcessamentoItemRetorno ;
      private bool[] BC002W5_n921NotificacaoAgendadaProcessamentoItemRetorno ;
      private Guid[] BC002W5_A908NotificacaoAgendadaProcessamentoId ;
      private Guid[] BC002W4_A908NotificacaoAgendadaProcessamentoId ;
      private Guid[] BC002W6_A908NotificacaoAgendadaProcessamentoId ;
      private int[] BC002W6_A916NotificacaoAgendadaProcessamentoItemId ;
      private int[] BC002W3_A916NotificacaoAgendadaProcessamentoItemId ;
      private DateTime[] BC002W3_A917NotificacaoAgendadaProcessamentoItemExecucao ;
      private bool[] BC002W3_n917NotificacaoAgendadaProcessamentoItemExecucao ;
      private string[] BC002W3_A918NotificacaoAgendadaProcessamentoItemJson ;
      private bool[] BC002W3_n918NotificacaoAgendadaProcessamentoItemJson ;
      private string[] BC002W3_A919NotificacaoAgendadaProcessamentoItemTipo ;
      private bool[] BC002W3_n919NotificacaoAgendadaProcessamentoItemTipo ;
      private string[] BC002W3_A920NotificacaoAgendadaProcessamentoItemSituacao ;
      private bool[] BC002W3_n920NotificacaoAgendadaProcessamentoItemSituacao ;
      private string[] BC002W3_A921NotificacaoAgendadaProcessamentoItemRetorno ;
      private bool[] BC002W3_n921NotificacaoAgendadaProcessamentoItemRetorno ;
      private Guid[] BC002W3_A908NotificacaoAgendadaProcessamentoId ;
      private int[] BC002W2_A916NotificacaoAgendadaProcessamentoItemId ;
      private DateTime[] BC002W2_A917NotificacaoAgendadaProcessamentoItemExecucao ;
      private bool[] BC002W2_n917NotificacaoAgendadaProcessamentoItemExecucao ;
      private string[] BC002W2_A918NotificacaoAgendadaProcessamentoItemJson ;
      private bool[] BC002W2_n918NotificacaoAgendadaProcessamentoItemJson ;
      private string[] BC002W2_A919NotificacaoAgendadaProcessamentoItemTipo ;
      private bool[] BC002W2_n919NotificacaoAgendadaProcessamentoItemTipo ;
      private string[] BC002W2_A920NotificacaoAgendadaProcessamentoItemSituacao ;
      private bool[] BC002W2_n920NotificacaoAgendadaProcessamentoItemSituacao ;
      private string[] BC002W2_A921NotificacaoAgendadaProcessamentoItemRetorno ;
      private bool[] BC002W2_n921NotificacaoAgendadaProcessamentoItemRetorno ;
      private Guid[] BC002W2_A908NotificacaoAgendadaProcessamentoId ;
      private int[] BC002W10_A916NotificacaoAgendadaProcessamentoItemId ;
      private DateTime[] BC002W10_A917NotificacaoAgendadaProcessamentoItemExecucao ;
      private bool[] BC002W10_n917NotificacaoAgendadaProcessamentoItemExecucao ;
      private string[] BC002W10_A918NotificacaoAgendadaProcessamentoItemJson ;
      private bool[] BC002W10_n918NotificacaoAgendadaProcessamentoItemJson ;
      private string[] BC002W10_A919NotificacaoAgendadaProcessamentoItemTipo ;
      private bool[] BC002W10_n919NotificacaoAgendadaProcessamentoItemTipo ;
      private string[] BC002W10_A920NotificacaoAgendadaProcessamentoItemSituacao ;
      private bool[] BC002W10_n920NotificacaoAgendadaProcessamentoItemSituacao ;
      private string[] BC002W10_A921NotificacaoAgendadaProcessamentoItemRetorno ;
      private bool[] BC002W10_n921NotificacaoAgendadaProcessamentoItemRetorno ;
      private Guid[] BC002W10_A908NotificacaoAgendadaProcessamentoId ;
      private SdtNotificacaoAgendadaProcessamentoItem bcNotificacaoAgendadaProcessamentoItem ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private Guid[] BC002W11_A908NotificacaoAgendadaProcessamentoId ;
   }

   public class notificacaoagendadaprocessamentoitem_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC002W2;
          prmBC002W2 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("NotificacaoAgendadaProcessamentoItemId",GXType.Int32,9,0)
          };
          Object[] prmBC002W3;
          prmBC002W3 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("NotificacaoAgendadaProcessamentoItemId",GXType.Int32,9,0)
          };
          Object[] prmBC002W4;
          prmBC002W4 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmBC002W5;
          prmBC002W5 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("NotificacaoAgendadaProcessamentoItemId",GXType.Int32,9,0)
          };
          Object[] prmBC002W6;
          prmBC002W6 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("NotificacaoAgendadaProcessamentoItemId",GXType.Int32,9,0)
          };
          Object[] prmBC002W7;
          prmBC002W7 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoItemId",GXType.Int32,9,0) ,
          new ParDef("NotificacaoAgendadaProcessamentoItemExecucao",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoItemJson",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoItemTipo",GXType.VarChar,1,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoItemSituacao",GXType.VarChar,1,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoItemRetorno",GXType.VarChar,400,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmBC002W8;
          prmBC002W8 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoItemExecucao",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoItemJson",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoItemTipo",GXType.VarChar,1,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoItemSituacao",GXType.VarChar,1,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoItemRetorno",GXType.VarChar,400,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("NotificacaoAgendadaProcessamentoItemId",GXType.Int32,9,0)
          };
          Object[] prmBC002W9;
          prmBC002W9 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("NotificacaoAgendadaProcessamentoItemId",GXType.Int32,9,0)
          };
          Object[] prmBC002W10;
          prmBC002W10 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("NotificacaoAgendadaProcessamentoItemId",GXType.Int32,9,0)
          };
          Object[] prmBC002W11;
          prmBC002W11 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC002W2", "SELECT NotificacaoAgendadaProcessamentoItemId, NotificacaoAgendadaProcessamentoItemExecucao, NotificacaoAgendadaProcessamentoItemJson, NotificacaoAgendadaProcessamentoItemTipo, NotificacaoAgendadaProcessamentoItemSituacao, NotificacaoAgendadaProcessamentoItemRetorno, NotificacaoAgendadaProcessamentoId FROM NotificacaoAgendadaProcessamentoItem WHERE NotificacaoAgendadaProcessamentoId = :NotificacaoAgendadaProcessamentoId AND NotificacaoAgendadaProcessamentoItemId = :NotificacaoAgendadaProcessamentoItemId  FOR UPDATE OF NotificacaoAgendadaProcessamentoItem",true, GxErrorMask.GX_NOMASK, false, this,prmBC002W2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002W3", "SELECT NotificacaoAgendadaProcessamentoItemId, NotificacaoAgendadaProcessamentoItemExecucao, NotificacaoAgendadaProcessamentoItemJson, NotificacaoAgendadaProcessamentoItemTipo, NotificacaoAgendadaProcessamentoItemSituacao, NotificacaoAgendadaProcessamentoItemRetorno, NotificacaoAgendadaProcessamentoId FROM NotificacaoAgendadaProcessamentoItem WHERE NotificacaoAgendadaProcessamentoId = :NotificacaoAgendadaProcessamentoId AND NotificacaoAgendadaProcessamentoItemId = :NotificacaoAgendadaProcessamentoItemId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002W3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002W4", "SELECT NotificacaoAgendadaProcessamentoId FROM NotificacaoAgendadaProcessamento WHERE NotificacaoAgendadaProcessamentoId = :NotificacaoAgendadaProcessamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002W4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002W5", "SELECT TM1.NotificacaoAgendadaProcessamentoItemId, TM1.NotificacaoAgendadaProcessamentoItemExecucao, TM1.NotificacaoAgendadaProcessamentoItemJson, TM1.NotificacaoAgendadaProcessamentoItemTipo, TM1.NotificacaoAgendadaProcessamentoItemSituacao, TM1.NotificacaoAgendadaProcessamentoItemRetorno, TM1.NotificacaoAgendadaProcessamentoId FROM NotificacaoAgendadaProcessamentoItem TM1 WHERE TM1.NotificacaoAgendadaProcessamentoId = :NotificacaoAgendadaProcessamentoId and TM1.NotificacaoAgendadaProcessamentoItemId = :NotificacaoAgendadaProcessamentoItemId ORDER BY TM1.NotificacaoAgendadaProcessamentoId, TM1.NotificacaoAgendadaProcessamentoItemId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002W5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002W6", "SELECT NotificacaoAgendadaProcessamentoId, NotificacaoAgendadaProcessamentoItemId FROM NotificacaoAgendadaProcessamentoItem WHERE NotificacaoAgendadaProcessamentoId = :NotificacaoAgendadaProcessamentoId AND NotificacaoAgendadaProcessamentoItemId = :NotificacaoAgendadaProcessamentoItemId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002W6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002W7", "SAVEPOINT gxupdate;INSERT INTO NotificacaoAgendadaProcessamentoItem(NotificacaoAgendadaProcessamentoItemId, NotificacaoAgendadaProcessamentoItemExecucao, NotificacaoAgendadaProcessamentoItemJson, NotificacaoAgendadaProcessamentoItemTipo, NotificacaoAgendadaProcessamentoItemSituacao, NotificacaoAgendadaProcessamentoItemRetorno, NotificacaoAgendadaProcessamentoId) VALUES(:NotificacaoAgendadaProcessamentoItemId, :NotificacaoAgendadaProcessamentoItemExecucao, :NotificacaoAgendadaProcessamentoItemJson, :NotificacaoAgendadaProcessamentoItemTipo, :NotificacaoAgendadaProcessamentoItemSituacao, :NotificacaoAgendadaProcessamentoItemRetorno, :NotificacaoAgendadaProcessamentoId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002W7)
             ,new CursorDef("BC002W8", "SAVEPOINT gxupdate;UPDATE NotificacaoAgendadaProcessamentoItem SET NotificacaoAgendadaProcessamentoItemExecucao=:NotificacaoAgendadaProcessamentoItemExecucao, NotificacaoAgendadaProcessamentoItemJson=:NotificacaoAgendadaProcessamentoItemJson, NotificacaoAgendadaProcessamentoItemTipo=:NotificacaoAgendadaProcessamentoItemTipo, NotificacaoAgendadaProcessamentoItemSituacao=:NotificacaoAgendadaProcessamentoItemSituacao, NotificacaoAgendadaProcessamentoItemRetorno=:NotificacaoAgendadaProcessamentoItemRetorno  WHERE NotificacaoAgendadaProcessamentoId = :NotificacaoAgendadaProcessamentoId AND NotificacaoAgendadaProcessamentoItemId = :NotificacaoAgendadaProcessamentoItemId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002W8)
             ,new CursorDef("BC002W9", "SAVEPOINT gxupdate;DELETE FROM NotificacaoAgendadaProcessamentoItem  WHERE NotificacaoAgendadaProcessamentoId = :NotificacaoAgendadaProcessamentoId AND NotificacaoAgendadaProcessamentoItemId = :NotificacaoAgendadaProcessamentoItemId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002W9)
             ,new CursorDef("BC002W10", "SELECT TM1.NotificacaoAgendadaProcessamentoItemId, TM1.NotificacaoAgendadaProcessamentoItemExecucao, TM1.NotificacaoAgendadaProcessamentoItemJson, TM1.NotificacaoAgendadaProcessamentoItemTipo, TM1.NotificacaoAgendadaProcessamentoItemSituacao, TM1.NotificacaoAgendadaProcessamentoItemRetorno, TM1.NotificacaoAgendadaProcessamentoId FROM NotificacaoAgendadaProcessamentoItem TM1 WHERE TM1.NotificacaoAgendadaProcessamentoId = :NotificacaoAgendadaProcessamentoId and TM1.NotificacaoAgendadaProcessamentoItemId = :NotificacaoAgendadaProcessamentoItemId ORDER BY TM1.NotificacaoAgendadaProcessamentoId, TM1.NotificacaoAgendadaProcessamentoItemId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002W10,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002W11", "SELECT NotificacaoAgendadaProcessamentoId FROM NotificacaoAgendadaProcessamento WHERE NotificacaoAgendadaProcessamentoId = :NotificacaoAgendadaProcessamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002W11,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((Guid[]) buf[11])[0] = rslt.getGuid(7);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((Guid[]) buf[11])[0] = rslt.getGuid(7);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((Guid[]) buf[11])[0] = rslt.getGuid(7);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((Guid[]) buf[11])[0] = rslt.getGuid(7);
                return;
             case 9 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
       }
    }

 }

}
