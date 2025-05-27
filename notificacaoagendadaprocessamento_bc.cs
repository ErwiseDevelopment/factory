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
   public class notificacaoagendadaprocessamento_bc : GxSilentTrn, IGxSilentTrn
   {
      public notificacaoagendadaprocessamento_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public notificacaoagendadaprocessamento_bc( IGxContext context )
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
         ReadRow2V99( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2V99( ) ;
         standaloneModal( ) ;
         AddRow2V99( ) ;
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

      protected void CONFIRM_2V0( )
      {
         BeforeValidate2V99( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2V99( ) ;
            }
            else
            {
               CheckExtendedTable2V99( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors2V99( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM2V99( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z909NotificacaoAgendadaProcessamentoInicio = A909NotificacaoAgendadaProcessamentoInicio;
            Z910NotificacaoAgendadaProcessamentoFim = A910NotificacaoAgendadaProcessamentoFim;
            Z911NotificacaoAgendadaProcessamentoQtdExec = A911NotificacaoAgendadaProcessamentoQtdExec;
            Z912NotificacaoAgendadaProcessamentoQtdSucesso = A912NotificacaoAgendadaProcessamentoQtdSucesso;
            Z913NotificacaoAgendadaProcessamentoQtdFalhas = A913NotificacaoAgendadaProcessamentoQtdFalhas;
            Z914NotificacaoAgendadaProcessamentoSituacao = A914NotificacaoAgendadaProcessamentoSituacao;
         }
         if ( GX_JID == -4 )
         {
            Z908NotificacaoAgendadaProcessamentoId = A908NotificacaoAgendadaProcessamentoId;
            Z909NotificacaoAgendadaProcessamentoInicio = A909NotificacaoAgendadaProcessamentoInicio;
            Z910NotificacaoAgendadaProcessamentoFim = A910NotificacaoAgendadaProcessamentoFim;
            Z911NotificacaoAgendadaProcessamentoQtdExec = A911NotificacaoAgendadaProcessamentoQtdExec;
            Z912NotificacaoAgendadaProcessamentoQtdSucesso = A912NotificacaoAgendadaProcessamentoQtdSucesso;
            Z913NotificacaoAgendadaProcessamentoQtdFalhas = A913NotificacaoAgendadaProcessamentoQtdFalhas;
            Z914NotificacaoAgendadaProcessamentoSituacao = A914NotificacaoAgendadaProcessamentoSituacao;
            Z915NotificacaoAgendadaProcessamentoMensagemErro = A915NotificacaoAgendadaProcessamentoMensagemErro;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A908NotificacaoAgendadaProcessamentoId) )
         {
            A908NotificacaoAgendadaProcessamentoId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load2V99( )
      {
         /* Using cursor BC002V4 */
         pr_default.execute(2, new Object[] {A908NotificacaoAgendadaProcessamentoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound99 = 1;
            A909NotificacaoAgendadaProcessamentoInicio = BC002V4_A909NotificacaoAgendadaProcessamentoInicio[0];
            n909NotificacaoAgendadaProcessamentoInicio = BC002V4_n909NotificacaoAgendadaProcessamentoInicio[0];
            A910NotificacaoAgendadaProcessamentoFim = BC002V4_A910NotificacaoAgendadaProcessamentoFim[0];
            n910NotificacaoAgendadaProcessamentoFim = BC002V4_n910NotificacaoAgendadaProcessamentoFim[0];
            A911NotificacaoAgendadaProcessamentoQtdExec = BC002V4_A911NotificacaoAgendadaProcessamentoQtdExec[0];
            n911NotificacaoAgendadaProcessamentoQtdExec = BC002V4_n911NotificacaoAgendadaProcessamentoQtdExec[0];
            A912NotificacaoAgendadaProcessamentoQtdSucesso = BC002V4_A912NotificacaoAgendadaProcessamentoQtdSucesso[0];
            n912NotificacaoAgendadaProcessamentoQtdSucesso = BC002V4_n912NotificacaoAgendadaProcessamentoQtdSucesso[0];
            A913NotificacaoAgendadaProcessamentoQtdFalhas = BC002V4_A913NotificacaoAgendadaProcessamentoQtdFalhas[0];
            n913NotificacaoAgendadaProcessamentoQtdFalhas = BC002V4_n913NotificacaoAgendadaProcessamentoQtdFalhas[0];
            A914NotificacaoAgendadaProcessamentoSituacao = BC002V4_A914NotificacaoAgendadaProcessamentoSituacao[0];
            n914NotificacaoAgendadaProcessamentoSituacao = BC002V4_n914NotificacaoAgendadaProcessamentoSituacao[0];
            A915NotificacaoAgendadaProcessamentoMensagemErro = BC002V4_A915NotificacaoAgendadaProcessamentoMensagemErro[0];
            n915NotificacaoAgendadaProcessamentoMensagemErro = BC002V4_n915NotificacaoAgendadaProcessamentoMensagemErro[0];
            ZM2V99( -4) ;
         }
         pr_default.close(2);
         OnLoadActions2V99( ) ;
      }

      protected void OnLoadActions2V99( )
      {
      }

      protected void CheckExtendedTable2V99( )
      {
         standaloneModal( ) ;
         if ( ! ( ( StringUtil.StrCmp(A914NotificacaoAgendadaProcessamentoSituacao, "F") == 0 ) || ( StringUtil.StrCmp(A914NotificacaoAgendadaProcessamentoSituacao, "P") == 0 ) || ( StringUtil.StrCmp(A914NotificacaoAgendadaProcessamentoSituacao, "S") == 0 ) || ( StringUtil.StrCmp(A914NotificacaoAgendadaProcessamentoSituacao, "E") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A914NotificacaoAgendadaProcessamentoSituacao)) ) )
         {
            GX_msglist.addItem("Campo Situação do processamento de notificações agendadas fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors2V99( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2V99( )
      {
         /* Using cursor BC002V5 */
         pr_default.execute(3, new Object[] {A908NotificacaoAgendadaProcessamentoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound99 = 1;
         }
         else
         {
            RcdFound99 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC002V3 */
         pr_default.execute(1, new Object[] {A908NotificacaoAgendadaProcessamentoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2V99( 4) ;
            RcdFound99 = 1;
            A908NotificacaoAgendadaProcessamentoId = BC002V3_A908NotificacaoAgendadaProcessamentoId[0];
            A909NotificacaoAgendadaProcessamentoInicio = BC002V3_A909NotificacaoAgendadaProcessamentoInicio[0];
            n909NotificacaoAgendadaProcessamentoInicio = BC002V3_n909NotificacaoAgendadaProcessamentoInicio[0];
            A910NotificacaoAgendadaProcessamentoFim = BC002V3_A910NotificacaoAgendadaProcessamentoFim[0];
            n910NotificacaoAgendadaProcessamentoFim = BC002V3_n910NotificacaoAgendadaProcessamentoFim[0];
            A911NotificacaoAgendadaProcessamentoQtdExec = BC002V3_A911NotificacaoAgendadaProcessamentoQtdExec[0];
            n911NotificacaoAgendadaProcessamentoQtdExec = BC002V3_n911NotificacaoAgendadaProcessamentoQtdExec[0];
            A912NotificacaoAgendadaProcessamentoQtdSucesso = BC002V3_A912NotificacaoAgendadaProcessamentoQtdSucesso[0];
            n912NotificacaoAgendadaProcessamentoQtdSucesso = BC002V3_n912NotificacaoAgendadaProcessamentoQtdSucesso[0];
            A913NotificacaoAgendadaProcessamentoQtdFalhas = BC002V3_A913NotificacaoAgendadaProcessamentoQtdFalhas[0];
            n913NotificacaoAgendadaProcessamentoQtdFalhas = BC002V3_n913NotificacaoAgendadaProcessamentoQtdFalhas[0];
            A914NotificacaoAgendadaProcessamentoSituacao = BC002V3_A914NotificacaoAgendadaProcessamentoSituacao[0];
            n914NotificacaoAgendadaProcessamentoSituacao = BC002V3_n914NotificacaoAgendadaProcessamentoSituacao[0];
            A915NotificacaoAgendadaProcessamentoMensagemErro = BC002V3_A915NotificacaoAgendadaProcessamentoMensagemErro[0];
            n915NotificacaoAgendadaProcessamentoMensagemErro = BC002V3_n915NotificacaoAgendadaProcessamentoMensagemErro[0];
            Z908NotificacaoAgendadaProcessamentoId = A908NotificacaoAgendadaProcessamentoId;
            sMode99 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2V99( ) ;
            if ( AnyError == 1 )
            {
               RcdFound99 = 0;
               InitializeNonKey2V99( ) ;
            }
            Gx_mode = sMode99;
         }
         else
         {
            RcdFound99 = 0;
            InitializeNonKey2V99( ) ;
            sMode99 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode99;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2V99( ) ;
         if ( RcdFound99 == 0 )
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
         CONFIRM_2V0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2V99( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC002V2 */
            pr_default.execute(0, new Object[] {A908NotificacaoAgendadaProcessamentoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"NotificacaoAgendadaProcessamento"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z909NotificacaoAgendadaProcessamentoInicio != BC002V2_A909NotificacaoAgendadaProcessamentoInicio[0] ) || ( Z910NotificacaoAgendadaProcessamentoFim != BC002V2_A910NotificacaoAgendadaProcessamentoFim[0] ) || ( Z911NotificacaoAgendadaProcessamentoQtdExec != BC002V2_A911NotificacaoAgendadaProcessamentoQtdExec[0] ) || ( Z912NotificacaoAgendadaProcessamentoQtdSucesso != BC002V2_A912NotificacaoAgendadaProcessamentoQtdSucesso[0] ) || ( Z913NotificacaoAgendadaProcessamentoQtdFalhas != BC002V2_A913NotificacaoAgendadaProcessamentoQtdFalhas[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z914NotificacaoAgendadaProcessamentoSituacao, BC002V2_A914NotificacaoAgendadaProcessamentoSituacao[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"NotificacaoAgendadaProcessamento"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2V99( )
      {
         BeforeValidate2V99( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2V99( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2V99( 0) ;
            CheckOptimisticConcurrency2V99( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2V99( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2V99( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002V6 */
                     pr_default.execute(4, new Object[] {A908NotificacaoAgendadaProcessamentoId, n909NotificacaoAgendadaProcessamentoInicio, A909NotificacaoAgendadaProcessamentoInicio, n910NotificacaoAgendadaProcessamentoFim, A910NotificacaoAgendadaProcessamentoFim, n911NotificacaoAgendadaProcessamentoQtdExec, A911NotificacaoAgendadaProcessamentoQtdExec, n912NotificacaoAgendadaProcessamentoQtdSucesso, A912NotificacaoAgendadaProcessamentoQtdSucesso, n913NotificacaoAgendadaProcessamentoQtdFalhas, A913NotificacaoAgendadaProcessamentoQtdFalhas, n914NotificacaoAgendadaProcessamentoSituacao, A914NotificacaoAgendadaProcessamentoSituacao, n915NotificacaoAgendadaProcessamentoMensagemErro, A915NotificacaoAgendadaProcessamentoMensagemErro});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("NotificacaoAgendadaProcessamento");
                     if ( (pr_default.getStatus(4) == 1) )
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
               Load2V99( ) ;
            }
            EndLevel2V99( ) ;
         }
         CloseExtendedTableCursors2V99( ) ;
      }

      protected void Update2V99( )
      {
         BeforeValidate2V99( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2V99( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2V99( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2V99( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2V99( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002V7 */
                     pr_default.execute(5, new Object[] {n909NotificacaoAgendadaProcessamentoInicio, A909NotificacaoAgendadaProcessamentoInicio, n910NotificacaoAgendadaProcessamentoFim, A910NotificacaoAgendadaProcessamentoFim, n911NotificacaoAgendadaProcessamentoQtdExec, A911NotificacaoAgendadaProcessamentoQtdExec, n912NotificacaoAgendadaProcessamentoQtdSucesso, A912NotificacaoAgendadaProcessamentoQtdSucesso, n913NotificacaoAgendadaProcessamentoQtdFalhas, A913NotificacaoAgendadaProcessamentoQtdFalhas, n914NotificacaoAgendadaProcessamentoSituacao, A914NotificacaoAgendadaProcessamentoSituacao, n915NotificacaoAgendadaProcessamentoMensagemErro, A915NotificacaoAgendadaProcessamentoMensagemErro, A908NotificacaoAgendadaProcessamentoId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("NotificacaoAgendadaProcessamento");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"NotificacaoAgendadaProcessamento"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2V99( ) ;
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
            EndLevel2V99( ) ;
         }
         CloseExtendedTableCursors2V99( ) ;
      }

      protected void DeferredUpdate2V99( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2V99( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2V99( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2V99( ) ;
            AfterConfirm2V99( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2V99( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002V8 */
                  pr_default.execute(6, new Object[] {A908NotificacaoAgendadaProcessamentoId});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("NotificacaoAgendadaProcessamento");
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
         sMode99 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2V99( ) ;
         Gx_mode = sMode99;
      }

      protected void OnDeleteControls2V99( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC002V9 */
            pr_default.execute(7, new Object[] {A908NotificacaoAgendadaProcessamentoId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"NotificacaoAgendadaProcessamentoItem"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel2V99( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2V99( ) ;
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

      public void ScanKeyStart2V99( )
      {
         /* Using cursor BC002V10 */
         pr_default.execute(8, new Object[] {A908NotificacaoAgendadaProcessamentoId});
         RcdFound99 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound99 = 1;
            A908NotificacaoAgendadaProcessamentoId = BC002V10_A908NotificacaoAgendadaProcessamentoId[0];
            A909NotificacaoAgendadaProcessamentoInicio = BC002V10_A909NotificacaoAgendadaProcessamentoInicio[0];
            n909NotificacaoAgendadaProcessamentoInicio = BC002V10_n909NotificacaoAgendadaProcessamentoInicio[0];
            A910NotificacaoAgendadaProcessamentoFim = BC002V10_A910NotificacaoAgendadaProcessamentoFim[0];
            n910NotificacaoAgendadaProcessamentoFim = BC002V10_n910NotificacaoAgendadaProcessamentoFim[0];
            A911NotificacaoAgendadaProcessamentoQtdExec = BC002V10_A911NotificacaoAgendadaProcessamentoQtdExec[0];
            n911NotificacaoAgendadaProcessamentoQtdExec = BC002V10_n911NotificacaoAgendadaProcessamentoQtdExec[0];
            A912NotificacaoAgendadaProcessamentoQtdSucesso = BC002V10_A912NotificacaoAgendadaProcessamentoQtdSucesso[0];
            n912NotificacaoAgendadaProcessamentoQtdSucesso = BC002V10_n912NotificacaoAgendadaProcessamentoQtdSucesso[0];
            A913NotificacaoAgendadaProcessamentoQtdFalhas = BC002V10_A913NotificacaoAgendadaProcessamentoQtdFalhas[0];
            n913NotificacaoAgendadaProcessamentoQtdFalhas = BC002V10_n913NotificacaoAgendadaProcessamentoQtdFalhas[0];
            A914NotificacaoAgendadaProcessamentoSituacao = BC002V10_A914NotificacaoAgendadaProcessamentoSituacao[0];
            n914NotificacaoAgendadaProcessamentoSituacao = BC002V10_n914NotificacaoAgendadaProcessamentoSituacao[0];
            A915NotificacaoAgendadaProcessamentoMensagemErro = BC002V10_A915NotificacaoAgendadaProcessamentoMensagemErro[0];
            n915NotificacaoAgendadaProcessamentoMensagemErro = BC002V10_n915NotificacaoAgendadaProcessamentoMensagemErro[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2V99( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound99 = 0;
         ScanKeyLoad2V99( ) ;
      }

      protected void ScanKeyLoad2V99( )
      {
         sMode99 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound99 = 1;
            A908NotificacaoAgendadaProcessamentoId = BC002V10_A908NotificacaoAgendadaProcessamentoId[0];
            A909NotificacaoAgendadaProcessamentoInicio = BC002V10_A909NotificacaoAgendadaProcessamentoInicio[0];
            n909NotificacaoAgendadaProcessamentoInicio = BC002V10_n909NotificacaoAgendadaProcessamentoInicio[0];
            A910NotificacaoAgendadaProcessamentoFim = BC002V10_A910NotificacaoAgendadaProcessamentoFim[0];
            n910NotificacaoAgendadaProcessamentoFim = BC002V10_n910NotificacaoAgendadaProcessamentoFim[0];
            A911NotificacaoAgendadaProcessamentoQtdExec = BC002V10_A911NotificacaoAgendadaProcessamentoQtdExec[0];
            n911NotificacaoAgendadaProcessamentoQtdExec = BC002V10_n911NotificacaoAgendadaProcessamentoQtdExec[0];
            A912NotificacaoAgendadaProcessamentoQtdSucesso = BC002V10_A912NotificacaoAgendadaProcessamentoQtdSucesso[0];
            n912NotificacaoAgendadaProcessamentoQtdSucesso = BC002V10_n912NotificacaoAgendadaProcessamentoQtdSucesso[0];
            A913NotificacaoAgendadaProcessamentoQtdFalhas = BC002V10_A913NotificacaoAgendadaProcessamentoQtdFalhas[0];
            n913NotificacaoAgendadaProcessamentoQtdFalhas = BC002V10_n913NotificacaoAgendadaProcessamentoQtdFalhas[0];
            A914NotificacaoAgendadaProcessamentoSituacao = BC002V10_A914NotificacaoAgendadaProcessamentoSituacao[0];
            n914NotificacaoAgendadaProcessamentoSituacao = BC002V10_n914NotificacaoAgendadaProcessamentoSituacao[0];
            A915NotificacaoAgendadaProcessamentoMensagemErro = BC002V10_A915NotificacaoAgendadaProcessamentoMensagemErro[0];
            n915NotificacaoAgendadaProcessamentoMensagemErro = BC002V10_n915NotificacaoAgendadaProcessamentoMensagemErro[0];
         }
         Gx_mode = sMode99;
      }

      protected void ScanKeyEnd2V99( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm2V99( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2V99( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2V99( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2V99( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2V99( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2V99( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2V99( )
      {
      }

      protected void send_integrity_lvl_hashes2V99( )
      {
      }

      protected void AddRow2V99( )
      {
         VarsToRow99( bcNotificacaoAgendadaProcessamento) ;
      }

      protected void ReadRow2V99( )
      {
         RowToVars99( bcNotificacaoAgendadaProcessamento, 1) ;
      }

      protected void InitializeNonKey2V99( )
      {
         A909NotificacaoAgendadaProcessamentoInicio = (DateTime)(DateTime.MinValue);
         n909NotificacaoAgendadaProcessamentoInicio = false;
         A910NotificacaoAgendadaProcessamentoFim = (DateTime)(DateTime.MinValue);
         n910NotificacaoAgendadaProcessamentoFim = false;
         A911NotificacaoAgendadaProcessamentoQtdExec = 0;
         n911NotificacaoAgendadaProcessamentoQtdExec = false;
         A912NotificacaoAgendadaProcessamentoQtdSucesso = 0;
         n912NotificacaoAgendadaProcessamentoQtdSucesso = false;
         A913NotificacaoAgendadaProcessamentoQtdFalhas = 0;
         n913NotificacaoAgendadaProcessamentoQtdFalhas = false;
         A914NotificacaoAgendadaProcessamentoSituacao = "";
         n914NotificacaoAgendadaProcessamentoSituacao = false;
         A915NotificacaoAgendadaProcessamentoMensagemErro = "";
         n915NotificacaoAgendadaProcessamentoMensagemErro = false;
         Z909NotificacaoAgendadaProcessamentoInicio = (DateTime)(DateTime.MinValue);
         Z910NotificacaoAgendadaProcessamentoFim = (DateTime)(DateTime.MinValue);
         Z911NotificacaoAgendadaProcessamentoQtdExec = 0;
         Z912NotificacaoAgendadaProcessamentoQtdSucesso = 0;
         Z913NotificacaoAgendadaProcessamentoQtdFalhas = 0;
         Z914NotificacaoAgendadaProcessamentoSituacao = "";
      }

      protected void InitAll2V99( )
      {
         A908NotificacaoAgendadaProcessamentoId = Guid.NewGuid( );
         InitializeNonKey2V99( ) ;
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

      public void VarsToRow99( SdtNotificacaoAgendadaProcessamento obj99 )
      {
         obj99.gxTpr_Mode = Gx_mode;
         obj99.gxTpr_Notificacaoagendadaprocessamentoinicio = A909NotificacaoAgendadaProcessamentoInicio;
         obj99.gxTpr_Notificacaoagendadaprocessamentofim = A910NotificacaoAgendadaProcessamentoFim;
         obj99.gxTpr_Notificacaoagendadaprocessamentoqtdexec = A911NotificacaoAgendadaProcessamentoQtdExec;
         obj99.gxTpr_Notificacaoagendadaprocessamentoqtdsucesso = A912NotificacaoAgendadaProcessamentoQtdSucesso;
         obj99.gxTpr_Notificacaoagendadaprocessamentoqtdfalhas = A913NotificacaoAgendadaProcessamentoQtdFalhas;
         obj99.gxTpr_Notificacaoagendadaprocessamentosituacao = A914NotificacaoAgendadaProcessamentoSituacao;
         obj99.gxTpr_Notificacaoagendadaprocessamentomensagemerro = A915NotificacaoAgendadaProcessamentoMensagemErro;
         obj99.gxTpr_Notificacaoagendadaprocessamentoid = A908NotificacaoAgendadaProcessamentoId;
         obj99.gxTpr_Notificacaoagendadaprocessamentoid_Z = Z908NotificacaoAgendadaProcessamentoId;
         obj99.gxTpr_Notificacaoagendadaprocessamentoinicio_Z = Z909NotificacaoAgendadaProcessamentoInicio;
         obj99.gxTpr_Notificacaoagendadaprocessamentofim_Z = Z910NotificacaoAgendadaProcessamentoFim;
         obj99.gxTpr_Notificacaoagendadaprocessamentoqtdexec_Z = Z911NotificacaoAgendadaProcessamentoQtdExec;
         obj99.gxTpr_Notificacaoagendadaprocessamentoqtdsucesso_Z = Z912NotificacaoAgendadaProcessamentoQtdSucesso;
         obj99.gxTpr_Notificacaoagendadaprocessamentoqtdfalhas_Z = Z913NotificacaoAgendadaProcessamentoQtdFalhas;
         obj99.gxTpr_Notificacaoagendadaprocessamentosituacao_Z = Z914NotificacaoAgendadaProcessamentoSituacao;
         obj99.gxTpr_Notificacaoagendadaprocessamentoinicio_N = (short)(Convert.ToInt16(n909NotificacaoAgendadaProcessamentoInicio));
         obj99.gxTpr_Notificacaoagendadaprocessamentofim_N = (short)(Convert.ToInt16(n910NotificacaoAgendadaProcessamentoFim));
         obj99.gxTpr_Notificacaoagendadaprocessamentoqtdexec_N = (short)(Convert.ToInt16(n911NotificacaoAgendadaProcessamentoQtdExec));
         obj99.gxTpr_Notificacaoagendadaprocessamentoqtdsucesso_N = (short)(Convert.ToInt16(n912NotificacaoAgendadaProcessamentoQtdSucesso));
         obj99.gxTpr_Notificacaoagendadaprocessamentoqtdfalhas_N = (short)(Convert.ToInt16(n913NotificacaoAgendadaProcessamentoQtdFalhas));
         obj99.gxTpr_Notificacaoagendadaprocessamentosituacao_N = (short)(Convert.ToInt16(n914NotificacaoAgendadaProcessamentoSituacao));
         obj99.gxTpr_Notificacaoagendadaprocessamentomensagemerro_N = (short)(Convert.ToInt16(n915NotificacaoAgendadaProcessamentoMensagemErro));
         obj99.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow99( SdtNotificacaoAgendadaProcessamento obj99 )
      {
         obj99.gxTpr_Notificacaoagendadaprocessamentoid = A908NotificacaoAgendadaProcessamentoId;
         return  ;
      }

      public void RowToVars99( SdtNotificacaoAgendadaProcessamento obj99 ,
                               int forceLoad )
      {
         Gx_mode = obj99.gxTpr_Mode;
         A909NotificacaoAgendadaProcessamentoInicio = obj99.gxTpr_Notificacaoagendadaprocessamentoinicio;
         n909NotificacaoAgendadaProcessamentoInicio = false;
         A910NotificacaoAgendadaProcessamentoFim = obj99.gxTpr_Notificacaoagendadaprocessamentofim;
         n910NotificacaoAgendadaProcessamentoFim = false;
         A911NotificacaoAgendadaProcessamentoQtdExec = obj99.gxTpr_Notificacaoagendadaprocessamentoqtdexec;
         n911NotificacaoAgendadaProcessamentoQtdExec = false;
         A912NotificacaoAgendadaProcessamentoQtdSucesso = obj99.gxTpr_Notificacaoagendadaprocessamentoqtdsucesso;
         n912NotificacaoAgendadaProcessamentoQtdSucesso = false;
         A913NotificacaoAgendadaProcessamentoQtdFalhas = obj99.gxTpr_Notificacaoagendadaprocessamentoqtdfalhas;
         n913NotificacaoAgendadaProcessamentoQtdFalhas = false;
         A914NotificacaoAgendadaProcessamentoSituacao = obj99.gxTpr_Notificacaoagendadaprocessamentosituacao;
         n914NotificacaoAgendadaProcessamentoSituacao = false;
         A915NotificacaoAgendadaProcessamentoMensagemErro = obj99.gxTpr_Notificacaoagendadaprocessamentomensagemerro;
         n915NotificacaoAgendadaProcessamentoMensagemErro = false;
         A908NotificacaoAgendadaProcessamentoId = obj99.gxTpr_Notificacaoagendadaprocessamentoid;
         Z908NotificacaoAgendadaProcessamentoId = obj99.gxTpr_Notificacaoagendadaprocessamentoid_Z;
         Z909NotificacaoAgendadaProcessamentoInicio = obj99.gxTpr_Notificacaoagendadaprocessamentoinicio_Z;
         Z910NotificacaoAgendadaProcessamentoFim = obj99.gxTpr_Notificacaoagendadaprocessamentofim_Z;
         Z911NotificacaoAgendadaProcessamentoQtdExec = obj99.gxTpr_Notificacaoagendadaprocessamentoqtdexec_Z;
         Z912NotificacaoAgendadaProcessamentoQtdSucesso = obj99.gxTpr_Notificacaoagendadaprocessamentoqtdsucesso_Z;
         Z913NotificacaoAgendadaProcessamentoQtdFalhas = obj99.gxTpr_Notificacaoagendadaprocessamentoqtdfalhas_Z;
         Z914NotificacaoAgendadaProcessamentoSituacao = obj99.gxTpr_Notificacaoagendadaprocessamentosituacao_Z;
         n909NotificacaoAgendadaProcessamentoInicio = (bool)(Convert.ToBoolean(obj99.gxTpr_Notificacaoagendadaprocessamentoinicio_N));
         n910NotificacaoAgendadaProcessamentoFim = (bool)(Convert.ToBoolean(obj99.gxTpr_Notificacaoagendadaprocessamentofim_N));
         n911NotificacaoAgendadaProcessamentoQtdExec = (bool)(Convert.ToBoolean(obj99.gxTpr_Notificacaoagendadaprocessamentoqtdexec_N));
         n912NotificacaoAgendadaProcessamentoQtdSucesso = (bool)(Convert.ToBoolean(obj99.gxTpr_Notificacaoagendadaprocessamentoqtdsucesso_N));
         n913NotificacaoAgendadaProcessamentoQtdFalhas = (bool)(Convert.ToBoolean(obj99.gxTpr_Notificacaoagendadaprocessamentoqtdfalhas_N));
         n914NotificacaoAgendadaProcessamentoSituacao = (bool)(Convert.ToBoolean(obj99.gxTpr_Notificacaoagendadaprocessamentosituacao_N));
         n915NotificacaoAgendadaProcessamentoMensagemErro = (bool)(Convert.ToBoolean(obj99.gxTpr_Notificacaoagendadaprocessamentomensagemerro_N));
         Gx_mode = obj99.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A908NotificacaoAgendadaProcessamentoId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2V99( ) ;
         ScanKeyStart2V99( ) ;
         if ( RcdFound99 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z908NotificacaoAgendadaProcessamentoId = A908NotificacaoAgendadaProcessamentoId;
         }
         ZM2V99( -4) ;
         OnLoadActions2V99( ) ;
         AddRow2V99( ) ;
         ScanKeyEnd2V99( ) ;
         if ( RcdFound99 == 0 )
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
         RowToVars99( bcNotificacaoAgendadaProcessamento, 0) ;
         ScanKeyStart2V99( ) ;
         if ( RcdFound99 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z908NotificacaoAgendadaProcessamentoId = A908NotificacaoAgendadaProcessamentoId;
         }
         ZM2V99( -4) ;
         OnLoadActions2V99( ) ;
         AddRow2V99( ) ;
         ScanKeyEnd2V99( ) ;
         if ( RcdFound99 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2V99( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2V99( ) ;
         }
         else
         {
            if ( RcdFound99 == 1 )
            {
               if ( A908NotificacaoAgendadaProcessamentoId != Z908NotificacaoAgendadaProcessamentoId )
               {
                  A908NotificacaoAgendadaProcessamentoId = Z908NotificacaoAgendadaProcessamentoId;
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
                  Update2V99( ) ;
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
                  if ( A908NotificacaoAgendadaProcessamentoId != Z908NotificacaoAgendadaProcessamentoId )
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
                        Insert2V99( ) ;
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
                        Insert2V99( ) ;
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
         RowToVars99( bcNotificacaoAgendadaProcessamento, 1) ;
         SaveImpl( ) ;
         VarsToRow99( bcNotificacaoAgendadaProcessamento) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars99( bcNotificacaoAgendadaProcessamento, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2V99( ) ;
         AfterTrn( ) ;
         VarsToRow99( bcNotificacaoAgendadaProcessamento) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow99( bcNotificacaoAgendadaProcessamento) ;
         }
         else
         {
            SdtNotificacaoAgendadaProcessamento auxBC = new SdtNotificacaoAgendadaProcessamento(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A908NotificacaoAgendadaProcessamentoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcNotificacaoAgendadaProcessamento);
               auxBC.Save();
               bcNotificacaoAgendadaProcessamento.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars99( bcNotificacaoAgendadaProcessamento, 1) ;
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
         RowToVars99( bcNotificacaoAgendadaProcessamento, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2V99( ) ;
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
               VarsToRow99( bcNotificacaoAgendadaProcessamento) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow99( bcNotificacaoAgendadaProcessamento) ;
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
         RowToVars99( bcNotificacaoAgendadaProcessamento, 0) ;
         GetKey2V99( ) ;
         if ( RcdFound99 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A908NotificacaoAgendadaProcessamentoId != Z908NotificacaoAgendadaProcessamentoId )
            {
               A908NotificacaoAgendadaProcessamentoId = Z908NotificacaoAgendadaProcessamentoId;
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
            if ( A908NotificacaoAgendadaProcessamentoId != Z908NotificacaoAgendadaProcessamentoId )
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
         context.RollbackDataStores("notificacaoagendadaprocessamento_bc",pr_default);
         VarsToRow99( bcNotificacaoAgendadaProcessamento) ;
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
         Gx_mode = bcNotificacaoAgendadaProcessamento.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcNotificacaoAgendadaProcessamento.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcNotificacaoAgendadaProcessamento )
         {
            bcNotificacaoAgendadaProcessamento = (SdtNotificacaoAgendadaProcessamento)(sdt);
            if ( StringUtil.StrCmp(bcNotificacaoAgendadaProcessamento.gxTpr_Mode, "") == 0 )
            {
               bcNotificacaoAgendadaProcessamento.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow99( bcNotificacaoAgendadaProcessamento) ;
            }
            else
            {
               RowToVars99( bcNotificacaoAgendadaProcessamento, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcNotificacaoAgendadaProcessamento.gxTpr_Mode, "") == 0 )
            {
               bcNotificacaoAgendadaProcessamento.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars99( bcNotificacaoAgendadaProcessamento, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtNotificacaoAgendadaProcessamento NotificacaoAgendadaProcessamento_BC
      {
         get {
            return bcNotificacaoAgendadaProcessamento ;
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
         Z908NotificacaoAgendadaProcessamentoId = Guid.Empty;
         A908NotificacaoAgendadaProcessamentoId = Guid.Empty;
         Z909NotificacaoAgendadaProcessamentoInicio = (DateTime)(DateTime.MinValue);
         A909NotificacaoAgendadaProcessamentoInicio = (DateTime)(DateTime.MinValue);
         Z910NotificacaoAgendadaProcessamentoFim = (DateTime)(DateTime.MinValue);
         A910NotificacaoAgendadaProcessamentoFim = (DateTime)(DateTime.MinValue);
         Z914NotificacaoAgendadaProcessamentoSituacao = "";
         A914NotificacaoAgendadaProcessamentoSituacao = "";
         Z915NotificacaoAgendadaProcessamentoMensagemErro = "";
         A915NotificacaoAgendadaProcessamentoMensagemErro = "";
         BC002V4_A908NotificacaoAgendadaProcessamentoId = new Guid[] {Guid.Empty} ;
         BC002V4_A909NotificacaoAgendadaProcessamentoInicio = new DateTime[] {DateTime.MinValue} ;
         BC002V4_n909NotificacaoAgendadaProcessamentoInicio = new bool[] {false} ;
         BC002V4_A910NotificacaoAgendadaProcessamentoFim = new DateTime[] {DateTime.MinValue} ;
         BC002V4_n910NotificacaoAgendadaProcessamentoFim = new bool[] {false} ;
         BC002V4_A911NotificacaoAgendadaProcessamentoQtdExec = new int[1] ;
         BC002V4_n911NotificacaoAgendadaProcessamentoQtdExec = new bool[] {false} ;
         BC002V4_A912NotificacaoAgendadaProcessamentoQtdSucesso = new short[1] ;
         BC002V4_n912NotificacaoAgendadaProcessamentoQtdSucesso = new bool[] {false} ;
         BC002V4_A913NotificacaoAgendadaProcessamentoQtdFalhas = new short[1] ;
         BC002V4_n913NotificacaoAgendadaProcessamentoQtdFalhas = new bool[] {false} ;
         BC002V4_A914NotificacaoAgendadaProcessamentoSituacao = new string[] {""} ;
         BC002V4_n914NotificacaoAgendadaProcessamentoSituacao = new bool[] {false} ;
         BC002V4_A915NotificacaoAgendadaProcessamentoMensagemErro = new string[] {""} ;
         BC002V4_n915NotificacaoAgendadaProcessamentoMensagemErro = new bool[] {false} ;
         BC002V5_A908NotificacaoAgendadaProcessamentoId = new Guid[] {Guid.Empty} ;
         BC002V3_A908NotificacaoAgendadaProcessamentoId = new Guid[] {Guid.Empty} ;
         BC002V3_A909NotificacaoAgendadaProcessamentoInicio = new DateTime[] {DateTime.MinValue} ;
         BC002V3_n909NotificacaoAgendadaProcessamentoInicio = new bool[] {false} ;
         BC002V3_A910NotificacaoAgendadaProcessamentoFim = new DateTime[] {DateTime.MinValue} ;
         BC002V3_n910NotificacaoAgendadaProcessamentoFim = new bool[] {false} ;
         BC002V3_A911NotificacaoAgendadaProcessamentoQtdExec = new int[1] ;
         BC002V3_n911NotificacaoAgendadaProcessamentoQtdExec = new bool[] {false} ;
         BC002V3_A912NotificacaoAgendadaProcessamentoQtdSucesso = new short[1] ;
         BC002V3_n912NotificacaoAgendadaProcessamentoQtdSucesso = new bool[] {false} ;
         BC002V3_A913NotificacaoAgendadaProcessamentoQtdFalhas = new short[1] ;
         BC002V3_n913NotificacaoAgendadaProcessamentoQtdFalhas = new bool[] {false} ;
         BC002V3_A914NotificacaoAgendadaProcessamentoSituacao = new string[] {""} ;
         BC002V3_n914NotificacaoAgendadaProcessamentoSituacao = new bool[] {false} ;
         BC002V3_A915NotificacaoAgendadaProcessamentoMensagemErro = new string[] {""} ;
         BC002V3_n915NotificacaoAgendadaProcessamentoMensagemErro = new bool[] {false} ;
         sMode99 = "";
         BC002V2_A908NotificacaoAgendadaProcessamentoId = new Guid[] {Guid.Empty} ;
         BC002V2_A909NotificacaoAgendadaProcessamentoInicio = new DateTime[] {DateTime.MinValue} ;
         BC002V2_n909NotificacaoAgendadaProcessamentoInicio = new bool[] {false} ;
         BC002V2_A910NotificacaoAgendadaProcessamentoFim = new DateTime[] {DateTime.MinValue} ;
         BC002V2_n910NotificacaoAgendadaProcessamentoFim = new bool[] {false} ;
         BC002V2_A911NotificacaoAgendadaProcessamentoQtdExec = new int[1] ;
         BC002V2_n911NotificacaoAgendadaProcessamentoQtdExec = new bool[] {false} ;
         BC002V2_A912NotificacaoAgendadaProcessamentoQtdSucesso = new short[1] ;
         BC002V2_n912NotificacaoAgendadaProcessamentoQtdSucesso = new bool[] {false} ;
         BC002V2_A913NotificacaoAgendadaProcessamentoQtdFalhas = new short[1] ;
         BC002V2_n913NotificacaoAgendadaProcessamentoQtdFalhas = new bool[] {false} ;
         BC002V2_A914NotificacaoAgendadaProcessamentoSituacao = new string[] {""} ;
         BC002V2_n914NotificacaoAgendadaProcessamentoSituacao = new bool[] {false} ;
         BC002V2_A915NotificacaoAgendadaProcessamentoMensagemErro = new string[] {""} ;
         BC002V2_n915NotificacaoAgendadaProcessamentoMensagemErro = new bool[] {false} ;
         BC002V9_A908NotificacaoAgendadaProcessamentoId = new Guid[] {Guid.Empty} ;
         BC002V9_A916NotificacaoAgendadaProcessamentoItemId = new int[1] ;
         BC002V10_A908NotificacaoAgendadaProcessamentoId = new Guid[] {Guid.Empty} ;
         BC002V10_A909NotificacaoAgendadaProcessamentoInicio = new DateTime[] {DateTime.MinValue} ;
         BC002V10_n909NotificacaoAgendadaProcessamentoInicio = new bool[] {false} ;
         BC002V10_A910NotificacaoAgendadaProcessamentoFim = new DateTime[] {DateTime.MinValue} ;
         BC002V10_n910NotificacaoAgendadaProcessamentoFim = new bool[] {false} ;
         BC002V10_A911NotificacaoAgendadaProcessamentoQtdExec = new int[1] ;
         BC002V10_n911NotificacaoAgendadaProcessamentoQtdExec = new bool[] {false} ;
         BC002V10_A912NotificacaoAgendadaProcessamentoQtdSucesso = new short[1] ;
         BC002V10_n912NotificacaoAgendadaProcessamentoQtdSucesso = new bool[] {false} ;
         BC002V10_A913NotificacaoAgendadaProcessamentoQtdFalhas = new short[1] ;
         BC002V10_n913NotificacaoAgendadaProcessamentoQtdFalhas = new bool[] {false} ;
         BC002V10_A914NotificacaoAgendadaProcessamentoSituacao = new string[] {""} ;
         BC002V10_n914NotificacaoAgendadaProcessamentoSituacao = new bool[] {false} ;
         BC002V10_A915NotificacaoAgendadaProcessamentoMensagemErro = new string[] {""} ;
         BC002V10_n915NotificacaoAgendadaProcessamentoMensagemErro = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.notificacaoagendadaprocessamento_bc__default(),
            new Object[][] {
                new Object[] {
               BC002V2_A908NotificacaoAgendadaProcessamentoId, BC002V2_A909NotificacaoAgendadaProcessamentoInicio, BC002V2_n909NotificacaoAgendadaProcessamentoInicio, BC002V2_A910NotificacaoAgendadaProcessamentoFim, BC002V2_n910NotificacaoAgendadaProcessamentoFim, BC002V2_A911NotificacaoAgendadaProcessamentoQtdExec, BC002V2_n911NotificacaoAgendadaProcessamentoQtdExec, BC002V2_A912NotificacaoAgendadaProcessamentoQtdSucesso, BC002V2_n912NotificacaoAgendadaProcessamentoQtdSucesso, BC002V2_A913NotificacaoAgendadaProcessamentoQtdFalhas,
               BC002V2_n913NotificacaoAgendadaProcessamentoQtdFalhas, BC002V2_A914NotificacaoAgendadaProcessamentoSituacao, BC002V2_n914NotificacaoAgendadaProcessamentoSituacao, BC002V2_A915NotificacaoAgendadaProcessamentoMensagemErro, BC002V2_n915NotificacaoAgendadaProcessamentoMensagemErro
               }
               , new Object[] {
               BC002V3_A908NotificacaoAgendadaProcessamentoId, BC002V3_A909NotificacaoAgendadaProcessamentoInicio, BC002V3_n909NotificacaoAgendadaProcessamentoInicio, BC002V3_A910NotificacaoAgendadaProcessamentoFim, BC002V3_n910NotificacaoAgendadaProcessamentoFim, BC002V3_A911NotificacaoAgendadaProcessamentoQtdExec, BC002V3_n911NotificacaoAgendadaProcessamentoQtdExec, BC002V3_A912NotificacaoAgendadaProcessamentoQtdSucesso, BC002V3_n912NotificacaoAgendadaProcessamentoQtdSucesso, BC002V3_A913NotificacaoAgendadaProcessamentoQtdFalhas,
               BC002V3_n913NotificacaoAgendadaProcessamentoQtdFalhas, BC002V3_A914NotificacaoAgendadaProcessamentoSituacao, BC002V3_n914NotificacaoAgendadaProcessamentoSituacao, BC002V3_A915NotificacaoAgendadaProcessamentoMensagemErro, BC002V3_n915NotificacaoAgendadaProcessamentoMensagemErro
               }
               , new Object[] {
               BC002V4_A908NotificacaoAgendadaProcessamentoId, BC002V4_A909NotificacaoAgendadaProcessamentoInicio, BC002V4_n909NotificacaoAgendadaProcessamentoInicio, BC002V4_A910NotificacaoAgendadaProcessamentoFim, BC002V4_n910NotificacaoAgendadaProcessamentoFim, BC002V4_A911NotificacaoAgendadaProcessamentoQtdExec, BC002V4_n911NotificacaoAgendadaProcessamentoQtdExec, BC002V4_A912NotificacaoAgendadaProcessamentoQtdSucesso, BC002V4_n912NotificacaoAgendadaProcessamentoQtdSucesso, BC002V4_A913NotificacaoAgendadaProcessamentoQtdFalhas,
               BC002V4_n913NotificacaoAgendadaProcessamentoQtdFalhas, BC002V4_A914NotificacaoAgendadaProcessamentoSituacao, BC002V4_n914NotificacaoAgendadaProcessamentoSituacao, BC002V4_A915NotificacaoAgendadaProcessamentoMensagemErro, BC002V4_n915NotificacaoAgendadaProcessamentoMensagemErro
               }
               , new Object[] {
               BC002V5_A908NotificacaoAgendadaProcessamentoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002V9_A908NotificacaoAgendadaProcessamentoId, BC002V9_A916NotificacaoAgendadaProcessamentoItemId
               }
               , new Object[] {
               BC002V10_A908NotificacaoAgendadaProcessamentoId, BC002V10_A909NotificacaoAgendadaProcessamentoInicio, BC002V10_n909NotificacaoAgendadaProcessamentoInicio, BC002V10_A910NotificacaoAgendadaProcessamentoFim, BC002V10_n910NotificacaoAgendadaProcessamentoFim, BC002V10_A911NotificacaoAgendadaProcessamentoQtdExec, BC002V10_n911NotificacaoAgendadaProcessamentoQtdExec, BC002V10_A912NotificacaoAgendadaProcessamentoQtdSucesso, BC002V10_n912NotificacaoAgendadaProcessamentoQtdSucesso, BC002V10_A913NotificacaoAgendadaProcessamentoQtdFalhas,
               BC002V10_n913NotificacaoAgendadaProcessamentoQtdFalhas, BC002V10_A914NotificacaoAgendadaProcessamentoSituacao, BC002V10_n914NotificacaoAgendadaProcessamentoSituacao, BC002V10_A915NotificacaoAgendadaProcessamentoMensagemErro, BC002V10_n915NotificacaoAgendadaProcessamentoMensagemErro
               }
            }
         );
         Z908NotificacaoAgendadaProcessamentoId = Guid.NewGuid( );
         A908NotificacaoAgendadaProcessamentoId = Guid.NewGuid( );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z912NotificacaoAgendadaProcessamentoQtdSucesso ;
      private short A912NotificacaoAgendadaProcessamentoQtdSucesso ;
      private short Z913NotificacaoAgendadaProcessamentoQtdFalhas ;
      private short A913NotificacaoAgendadaProcessamentoQtdFalhas ;
      private short Gx_BScreen ;
      private short RcdFound99 ;
      private int trnEnded ;
      private int Z911NotificacaoAgendadaProcessamentoQtdExec ;
      private int A911NotificacaoAgendadaProcessamentoQtdExec ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode99 ;
      private DateTime Z909NotificacaoAgendadaProcessamentoInicio ;
      private DateTime A909NotificacaoAgendadaProcessamentoInicio ;
      private DateTime Z910NotificacaoAgendadaProcessamentoFim ;
      private DateTime A910NotificacaoAgendadaProcessamentoFim ;
      private bool n909NotificacaoAgendadaProcessamentoInicio ;
      private bool n910NotificacaoAgendadaProcessamentoFim ;
      private bool n911NotificacaoAgendadaProcessamentoQtdExec ;
      private bool n912NotificacaoAgendadaProcessamentoQtdSucesso ;
      private bool n913NotificacaoAgendadaProcessamentoQtdFalhas ;
      private bool n914NotificacaoAgendadaProcessamentoSituacao ;
      private bool n915NotificacaoAgendadaProcessamentoMensagemErro ;
      private bool Gx_longc ;
      private string Z915NotificacaoAgendadaProcessamentoMensagemErro ;
      private string A915NotificacaoAgendadaProcessamentoMensagemErro ;
      private string Z914NotificacaoAgendadaProcessamentoSituacao ;
      private string A914NotificacaoAgendadaProcessamentoSituacao ;
      private Guid Z908NotificacaoAgendadaProcessamentoId ;
      private Guid A908NotificacaoAgendadaProcessamentoId ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC002V4_A908NotificacaoAgendadaProcessamentoId ;
      private DateTime[] BC002V4_A909NotificacaoAgendadaProcessamentoInicio ;
      private bool[] BC002V4_n909NotificacaoAgendadaProcessamentoInicio ;
      private DateTime[] BC002V4_A910NotificacaoAgendadaProcessamentoFim ;
      private bool[] BC002V4_n910NotificacaoAgendadaProcessamentoFim ;
      private int[] BC002V4_A911NotificacaoAgendadaProcessamentoQtdExec ;
      private bool[] BC002V4_n911NotificacaoAgendadaProcessamentoQtdExec ;
      private short[] BC002V4_A912NotificacaoAgendadaProcessamentoQtdSucesso ;
      private bool[] BC002V4_n912NotificacaoAgendadaProcessamentoQtdSucesso ;
      private short[] BC002V4_A913NotificacaoAgendadaProcessamentoQtdFalhas ;
      private bool[] BC002V4_n913NotificacaoAgendadaProcessamentoQtdFalhas ;
      private string[] BC002V4_A914NotificacaoAgendadaProcessamentoSituacao ;
      private bool[] BC002V4_n914NotificacaoAgendadaProcessamentoSituacao ;
      private string[] BC002V4_A915NotificacaoAgendadaProcessamentoMensagemErro ;
      private bool[] BC002V4_n915NotificacaoAgendadaProcessamentoMensagemErro ;
      private Guid[] BC002V5_A908NotificacaoAgendadaProcessamentoId ;
      private Guid[] BC002V3_A908NotificacaoAgendadaProcessamentoId ;
      private DateTime[] BC002V3_A909NotificacaoAgendadaProcessamentoInicio ;
      private bool[] BC002V3_n909NotificacaoAgendadaProcessamentoInicio ;
      private DateTime[] BC002V3_A910NotificacaoAgendadaProcessamentoFim ;
      private bool[] BC002V3_n910NotificacaoAgendadaProcessamentoFim ;
      private int[] BC002V3_A911NotificacaoAgendadaProcessamentoQtdExec ;
      private bool[] BC002V3_n911NotificacaoAgendadaProcessamentoQtdExec ;
      private short[] BC002V3_A912NotificacaoAgendadaProcessamentoQtdSucesso ;
      private bool[] BC002V3_n912NotificacaoAgendadaProcessamentoQtdSucesso ;
      private short[] BC002V3_A913NotificacaoAgendadaProcessamentoQtdFalhas ;
      private bool[] BC002V3_n913NotificacaoAgendadaProcessamentoQtdFalhas ;
      private string[] BC002V3_A914NotificacaoAgendadaProcessamentoSituacao ;
      private bool[] BC002V3_n914NotificacaoAgendadaProcessamentoSituacao ;
      private string[] BC002V3_A915NotificacaoAgendadaProcessamentoMensagemErro ;
      private bool[] BC002V3_n915NotificacaoAgendadaProcessamentoMensagemErro ;
      private Guid[] BC002V2_A908NotificacaoAgendadaProcessamentoId ;
      private DateTime[] BC002V2_A909NotificacaoAgendadaProcessamentoInicio ;
      private bool[] BC002V2_n909NotificacaoAgendadaProcessamentoInicio ;
      private DateTime[] BC002V2_A910NotificacaoAgendadaProcessamentoFim ;
      private bool[] BC002V2_n910NotificacaoAgendadaProcessamentoFim ;
      private int[] BC002V2_A911NotificacaoAgendadaProcessamentoQtdExec ;
      private bool[] BC002V2_n911NotificacaoAgendadaProcessamentoQtdExec ;
      private short[] BC002V2_A912NotificacaoAgendadaProcessamentoQtdSucesso ;
      private bool[] BC002V2_n912NotificacaoAgendadaProcessamentoQtdSucesso ;
      private short[] BC002V2_A913NotificacaoAgendadaProcessamentoQtdFalhas ;
      private bool[] BC002V2_n913NotificacaoAgendadaProcessamentoQtdFalhas ;
      private string[] BC002V2_A914NotificacaoAgendadaProcessamentoSituacao ;
      private bool[] BC002V2_n914NotificacaoAgendadaProcessamentoSituacao ;
      private string[] BC002V2_A915NotificacaoAgendadaProcessamentoMensagemErro ;
      private bool[] BC002V2_n915NotificacaoAgendadaProcessamentoMensagemErro ;
      private Guid[] BC002V9_A908NotificacaoAgendadaProcessamentoId ;
      private int[] BC002V9_A916NotificacaoAgendadaProcessamentoItemId ;
      private Guid[] BC002V10_A908NotificacaoAgendadaProcessamentoId ;
      private DateTime[] BC002V10_A909NotificacaoAgendadaProcessamentoInicio ;
      private bool[] BC002V10_n909NotificacaoAgendadaProcessamentoInicio ;
      private DateTime[] BC002V10_A910NotificacaoAgendadaProcessamentoFim ;
      private bool[] BC002V10_n910NotificacaoAgendadaProcessamentoFim ;
      private int[] BC002V10_A911NotificacaoAgendadaProcessamentoQtdExec ;
      private bool[] BC002V10_n911NotificacaoAgendadaProcessamentoQtdExec ;
      private short[] BC002V10_A912NotificacaoAgendadaProcessamentoQtdSucesso ;
      private bool[] BC002V10_n912NotificacaoAgendadaProcessamentoQtdSucesso ;
      private short[] BC002V10_A913NotificacaoAgendadaProcessamentoQtdFalhas ;
      private bool[] BC002V10_n913NotificacaoAgendadaProcessamentoQtdFalhas ;
      private string[] BC002V10_A914NotificacaoAgendadaProcessamentoSituacao ;
      private bool[] BC002V10_n914NotificacaoAgendadaProcessamentoSituacao ;
      private string[] BC002V10_A915NotificacaoAgendadaProcessamentoMensagemErro ;
      private bool[] BC002V10_n915NotificacaoAgendadaProcessamentoMensagemErro ;
      private SdtNotificacaoAgendadaProcessamento bcNotificacaoAgendadaProcessamento ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class notificacaoagendadaprocessamento_bc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new UpdateCursor(def[4])
         ,new UpdateCursor(def[5])
         ,new UpdateCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC002V2;
          prmBC002V2 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmBC002V3;
          prmBC002V3 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmBC002V4;
          prmBC002V4 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmBC002V5;
          prmBC002V5 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmBC002V6;
          prmBC002V6 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("NotificacaoAgendadaProcessamentoInicio",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoFim",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoQtdExec",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoQtdSucesso",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoQtdFalhas",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoSituacao",GXType.VarChar,1,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoMensagemErro",GXType.LongVarChar,2097152,0){Nullable=true}
          };
          Object[] prmBC002V7;
          prmBC002V7 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoInicio",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoFim",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoQtdExec",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoQtdSucesso",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoQtdFalhas",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoSituacao",GXType.VarChar,1,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoMensagemErro",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmBC002V8;
          prmBC002V8 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmBC002V9;
          prmBC002V9 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmBC002V10;
          prmBC002V10 = new Object[] {
          new ParDef("NotificacaoAgendadaProcessamentoId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC002V2", "SELECT NotificacaoAgendadaProcessamentoId, NotificacaoAgendadaProcessamentoInicio, NotificacaoAgendadaProcessamentoFim, NotificacaoAgendadaProcessamentoQtdExec, NotificacaoAgendadaProcessamentoQtdSucesso, NotificacaoAgendadaProcessamentoQtdFalhas, NotificacaoAgendadaProcessamentoSituacao, NotificacaoAgendadaProcessamentoMensagemErro FROM NotificacaoAgendadaProcessamento WHERE NotificacaoAgendadaProcessamentoId = :NotificacaoAgendadaProcessamentoId  FOR UPDATE OF NotificacaoAgendadaProcessamento",true, GxErrorMask.GX_NOMASK, false, this,prmBC002V2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002V3", "SELECT NotificacaoAgendadaProcessamentoId, NotificacaoAgendadaProcessamentoInicio, NotificacaoAgendadaProcessamentoFim, NotificacaoAgendadaProcessamentoQtdExec, NotificacaoAgendadaProcessamentoQtdSucesso, NotificacaoAgendadaProcessamentoQtdFalhas, NotificacaoAgendadaProcessamentoSituacao, NotificacaoAgendadaProcessamentoMensagemErro FROM NotificacaoAgendadaProcessamento WHERE NotificacaoAgendadaProcessamentoId = :NotificacaoAgendadaProcessamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002V3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002V4", "SELECT TM1.NotificacaoAgendadaProcessamentoId, TM1.NotificacaoAgendadaProcessamentoInicio, TM1.NotificacaoAgendadaProcessamentoFim, TM1.NotificacaoAgendadaProcessamentoQtdExec, TM1.NotificacaoAgendadaProcessamentoQtdSucesso, TM1.NotificacaoAgendadaProcessamentoQtdFalhas, TM1.NotificacaoAgendadaProcessamentoSituacao, TM1.NotificacaoAgendadaProcessamentoMensagemErro FROM NotificacaoAgendadaProcessamento TM1 WHERE TM1.NotificacaoAgendadaProcessamentoId = :NotificacaoAgendadaProcessamentoId ORDER BY TM1.NotificacaoAgendadaProcessamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002V4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002V5", "SELECT NotificacaoAgendadaProcessamentoId FROM NotificacaoAgendadaProcessamento WHERE NotificacaoAgendadaProcessamentoId = :NotificacaoAgendadaProcessamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002V5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002V6", "SAVEPOINT gxupdate;INSERT INTO NotificacaoAgendadaProcessamento(NotificacaoAgendadaProcessamentoId, NotificacaoAgendadaProcessamentoInicio, NotificacaoAgendadaProcessamentoFim, NotificacaoAgendadaProcessamentoQtdExec, NotificacaoAgendadaProcessamentoQtdSucesso, NotificacaoAgendadaProcessamentoQtdFalhas, NotificacaoAgendadaProcessamentoSituacao, NotificacaoAgendadaProcessamentoMensagemErro) VALUES(:NotificacaoAgendadaProcessamentoId, :NotificacaoAgendadaProcessamentoInicio, :NotificacaoAgendadaProcessamentoFim, :NotificacaoAgendadaProcessamentoQtdExec, :NotificacaoAgendadaProcessamentoQtdSucesso, :NotificacaoAgendadaProcessamentoQtdFalhas, :NotificacaoAgendadaProcessamentoSituacao, :NotificacaoAgendadaProcessamentoMensagemErro);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC002V6)
             ,new CursorDef("BC002V7", "SAVEPOINT gxupdate;UPDATE NotificacaoAgendadaProcessamento SET NotificacaoAgendadaProcessamentoInicio=:NotificacaoAgendadaProcessamentoInicio, NotificacaoAgendadaProcessamentoFim=:NotificacaoAgendadaProcessamentoFim, NotificacaoAgendadaProcessamentoQtdExec=:NotificacaoAgendadaProcessamentoQtdExec, NotificacaoAgendadaProcessamentoQtdSucesso=:NotificacaoAgendadaProcessamentoQtdSucesso, NotificacaoAgendadaProcessamentoQtdFalhas=:NotificacaoAgendadaProcessamentoQtdFalhas, NotificacaoAgendadaProcessamentoSituacao=:NotificacaoAgendadaProcessamentoSituacao, NotificacaoAgendadaProcessamentoMensagemErro=:NotificacaoAgendadaProcessamentoMensagemErro  WHERE NotificacaoAgendadaProcessamentoId = :NotificacaoAgendadaProcessamentoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002V7)
             ,new CursorDef("BC002V8", "SAVEPOINT gxupdate;DELETE FROM NotificacaoAgendadaProcessamento  WHERE NotificacaoAgendadaProcessamentoId = :NotificacaoAgendadaProcessamentoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002V8)
             ,new CursorDef("BC002V9", "SELECT NotificacaoAgendadaProcessamentoId, NotificacaoAgendadaProcessamentoItemId FROM NotificacaoAgendadaProcessamentoItem WHERE NotificacaoAgendadaProcessamentoId = :NotificacaoAgendadaProcessamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002V9,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002V10", "SELECT TM1.NotificacaoAgendadaProcessamentoId, TM1.NotificacaoAgendadaProcessamentoInicio, TM1.NotificacaoAgendadaProcessamentoFim, TM1.NotificacaoAgendadaProcessamentoQtdExec, TM1.NotificacaoAgendadaProcessamentoQtdSucesso, TM1.NotificacaoAgendadaProcessamentoQtdFalhas, TM1.NotificacaoAgendadaProcessamentoSituacao, TM1.NotificacaoAgendadaProcessamentoMensagemErro FROM NotificacaoAgendadaProcessamento TM1 WHERE TM1.NotificacaoAgendadaProcessamentoId = :NotificacaoAgendadaProcessamentoId ORDER BY TM1.NotificacaoAgendadaProcessamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002V10,100, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getLongVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getLongVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getLongVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 7 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 8 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getLongVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
       }
    }

 }

}
