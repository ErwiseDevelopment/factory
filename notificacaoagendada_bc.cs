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
   public class notificacaoagendada_bc : GxSilentTrn, IGxSilentTrn
   {
      public notificacaoagendada_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public notificacaoagendada_bc( IGxContext context )
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
         ReadRow2U98( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2U98( ) ;
         standaloneModal( ) ;
         AddRow2U98( ) ;
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
            E112U2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z898NotificacaoAgendadaId = A898NotificacaoAgendadaId;
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

      protected void CONFIRM_2U0( )
      {
         BeforeValidate2U98( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2U98( ) ;
            }
            else
            {
               CheckExtendedTable2U98( ) ;
               if ( AnyError == 0 )
               {
                  ZM2U98( 12) ;
               }
               CloseExtendedTableCursors2U98( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E122U2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV17Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV18GXV1 = 1;
            while ( AV18GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV18GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "NotificacaoAgendadaLayoutId") == 0 )
               {
                  AV11Insert_NotificacaoAgendadaLayoutId = (short)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV18GXV1 = (int)(AV18GXV1+1);
            }
         }
      }

      protected void E112U2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM2U98( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z899NotificacaoAgendadaOrigem = A899NotificacaoAgendadaOrigem;
            Z900NotificacaoAgendadaDescricao = A900NotificacaoAgendadaDescricao;
            Z901NotificacaoAgendadaDias = A901NotificacaoAgendadaDias;
            Z902NotificacaoAgendadaMomentoEnvio = A902NotificacaoAgendadaMomentoEnvio;
            Z903NotificacaoAgendadaTipo = A903NotificacaoAgendadaTipo;
            Z905NotificacaoAgendadaStatus = A905NotificacaoAgendadaStatus;
            Z904NotificacaoAgendadaLayoutId = A904NotificacaoAgendadaLayoutId;
            Z907NotificacaoAgendadaOffsetDias = A907NotificacaoAgendadaOffsetDias;
         }
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            Z907NotificacaoAgendadaOffsetDias = A907NotificacaoAgendadaOffsetDias;
         }
         if ( GX_JID == -11 )
         {
            Z898NotificacaoAgendadaId = A898NotificacaoAgendadaId;
            Z899NotificacaoAgendadaOrigem = A899NotificacaoAgendadaOrigem;
            Z900NotificacaoAgendadaDescricao = A900NotificacaoAgendadaDescricao;
            Z901NotificacaoAgendadaDias = A901NotificacaoAgendadaDias;
            Z902NotificacaoAgendadaMomentoEnvio = A902NotificacaoAgendadaMomentoEnvio;
            Z903NotificacaoAgendadaTipo = A903NotificacaoAgendadaTipo;
            Z905NotificacaoAgendadaStatus = A905NotificacaoAgendadaStatus;
            Z904NotificacaoAgendadaLayoutId = A904NotificacaoAgendadaLayoutId;
         }
      }

      protected void standaloneNotModal( )
      {
         AV17Pgmname = "NotificacaoAgendada_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A905NotificacaoAgendadaStatus) && ( Gx_BScreen == 0 ) )
         {
            A905NotificacaoAgendadaStatus = true;
            n905NotificacaoAgendadaStatus = false;
         }
      }

      protected void Load2U98( )
      {
         /* Using cursor BC002U5 */
         pr_default.execute(3, new Object[] {A898NotificacaoAgendadaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound98 = 1;
            A899NotificacaoAgendadaOrigem = BC002U5_A899NotificacaoAgendadaOrigem[0];
            A900NotificacaoAgendadaDescricao = BC002U5_A900NotificacaoAgendadaDescricao[0];
            A901NotificacaoAgendadaDias = BC002U5_A901NotificacaoAgendadaDias[0];
            n901NotificacaoAgendadaDias = BC002U5_n901NotificacaoAgendadaDias[0];
            A902NotificacaoAgendadaMomentoEnvio = BC002U5_A902NotificacaoAgendadaMomentoEnvio[0];
            n902NotificacaoAgendadaMomentoEnvio = BC002U5_n902NotificacaoAgendadaMomentoEnvio[0];
            A903NotificacaoAgendadaTipo = BC002U5_A903NotificacaoAgendadaTipo[0];
            n903NotificacaoAgendadaTipo = BC002U5_n903NotificacaoAgendadaTipo[0];
            A905NotificacaoAgendadaStatus = BC002U5_A905NotificacaoAgendadaStatus[0];
            n905NotificacaoAgendadaStatus = BC002U5_n905NotificacaoAgendadaStatus[0];
            A904NotificacaoAgendadaLayoutId = BC002U5_A904NotificacaoAgendadaLayoutId[0];
            n904NotificacaoAgendadaLayoutId = BC002U5_n904NotificacaoAgendadaLayoutId[0];
            ZM2U98( -11) ;
         }
         pr_default.close(3);
         OnLoadActions2U98( ) ;
      }

      protected void OnLoadActions2U98( )
      {
         A907NotificacaoAgendadaOffsetDias = ((StringUtil.StrCmp(A902NotificacaoAgendadaMomentoEnvio, "D")==0) ? A901NotificacaoAgendadaDias*-1 : A901NotificacaoAgendadaDias);
      }

      protected void CheckExtendedTable2U98( )
      {
         standaloneModal( ) ;
         if ( ! ( ( StringUtil.StrCmp(A899NotificacaoAgendadaOrigem, "R") == 0 ) ) )
         {
            GX_msglist.addItem("Campo Origem da Notificação fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A900NotificacaoAgendadaDescricao)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Descrição", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         A907NotificacaoAgendadaOffsetDias = ((StringUtil.StrCmp(A902NotificacaoAgendadaMomentoEnvio, "D")==0) ? A901NotificacaoAgendadaDias*-1 : A901NotificacaoAgendadaDias);
         if ( (0==A901NotificacaoAgendadaDias) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Quantidade de dias", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A902NotificacaoAgendadaMomentoEnvio, "A") == 0 ) || ( StringUtil.StrCmp(A902NotificacaoAgendadaMomentoEnvio, "D") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A902NotificacaoAgendadaMomentoEnvio)) ) )
         {
            GX_msglist.addItem("Campo Momento do Envio fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A903NotificacaoAgendadaTipo, "E") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A903NotificacaoAgendadaTipo)) ) )
         {
            GX_msglist.addItem("Campo Tipo fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC002U4 */
         pr_default.execute(2, new Object[] {n904NotificacaoAgendadaLayoutId, A904NotificacaoAgendadaLayoutId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A904NotificacaoAgendadaLayoutId) ) )
            {
               GX_msglist.addItem("Não existe 'Layout da Notificação Agendada'.", "ForeignKeyNotFound", 1, "NOTIFICACAOAGENDADALAYOUTID");
               AnyError = 1;
            }
         }
         pr_default.close(2);
         if ( (0==A904NotificacaoAgendadaLayoutId) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Layout de Envio", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors2U98( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2U98( )
      {
         /* Using cursor BC002U6 */
         pr_default.execute(4, new Object[] {A898NotificacaoAgendadaId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound98 = 1;
         }
         else
         {
            RcdFound98 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC002U3 */
         pr_default.execute(1, new Object[] {A898NotificacaoAgendadaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2U98( 11) ;
            RcdFound98 = 1;
            A898NotificacaoAgendadaId = BC002U3_A898NotificacaoAgendadaId[0];
            A899NotificacaoAgendadaOrigem = BC002U3_A899NotificacaoAgendadaOrigem[0];
            A900NotificacaoAgendadaDescricao = BC002U3_A900NotificacaoAgendadaDescricao[0];
            A901NotificacaoAgendadaDias = BC002U3_A901NotificacaoAgendadaDias[0];
            n901NotificacaoAgendadaDias = BC002U3_n901NotificacaoAgendadaDias[0];
            A902NotificacaoAgendadaMomentoEnvio = BC002U3_A902NotificacaoAgendadaMomentoEnvio[0];
            n902NotificacaoAgendadaMomentoEnvio = BC002U3_n902NotificacaoAgendadaMomentoEnvio[0];
            A903NotificacaoAgendadaTipo = BC002U3_A903NotificacaoAgendadaTipo[0];
            n903NotificacaoAgendadaTipo = BC002U3_n903NotificacaoAgendadaTipo[0];
            A905NotificacaoAgendadaStatus = BC002U3_A905NotificacaoAgendadaStatus[0];
            n905NotificacaoAgendadaStatus = BC002U3_n905NotificacaoAgendadaStatus[0];
            A904NotificacaoAgendadaLayoutId = BC002U3_A904NotificacaoAgendadaLayoutId[0];
            n904NotificacaoAgendadaLayoutId = BC002U3_n904NotificacaoAgendadaLayoutId[0];
            Z898NotificacaoAgendadaId = A898NotificacaoAgendadaId;
            sMode98 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2U98( ) ;
            if ( AnyError == 1 )
            {
               RcdFound98 = 0;
               InitializeNonKey2U98( ) ;
            }
            Gx_mode = sMode98;
         }
         else
         {
            RcdFound98 = 0;
            InitializeNonKey2U98( ) ;
            sMode98 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode98;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2U98( ) ;
         if ( RcdFound98 == 0 )
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
         CONFIRM_2U0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2U98( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC002U2 */
            pr_default.execute(0, new Object[] {A898NotificacaoAgendadaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"NotificacaoAgendada"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z899NotificacaoAgendadaOrigem, BC002U2_A899NotificacaoAgendadaOrigem[0]) != 0 ) || ( StringUtil.StrCmp(Z900NotificacaoAgendadaDescricao, BC002U2_A900NotificacaoAgendadaDescricao[0]) != 0 ) || ( Z901NotificacaoAgendadaDias != BC002U2_A901NotificacaoAgendadaDias[0] ) || ( StringUtil.StrCmp(Z902NotificacaoAgendadaMomentoEnvio, BC002U2_A902NotificacaoAgendadaMomentoEnvio[0]) != 0 ) || ( StringUtil.StrCmp(Z903NotificacaoAgendadaTipo, BC002U2_A903NotificacaoAgendadaTipo[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z905NotificacaoAgendadaStatus != BC002U2_A905NotificacaoAgendadaStatus[0] ) || ( Z904NotificacaoAgendadaLayoutId != BC002U2_A904NotificacaoAgendadaLayoutId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"NotificacaoAgendada"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2U98( )
      {
         BeforeValidate2U98( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2U98( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2U98( 0) ;
            CheckOptimisticConcurrency2U98( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2U98( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2U98( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002U7 */
                     pr_default.execute(5, new Object[] {A899NotificacaoAgendadaOrigem, A900NotificacaoAgendadaDescricao, n901NotificacaoAgendadaDias, A901NotificacaoAgendadaDias, n902NotificacaoAgendadaMomentoEnvio, A902NotificacaoAgendadaMomentoEnvio, n903NotificacaoAgendadaTipo, A903NotificacaoAgendadaTipo, n905NotificacaoAgendadaStatus, A905NotificacaoAgendadaStatus, n904NotificacaoAgendadaLayoutId, A904NotificacaoAgendadaLayoutId});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC002U8 */
                     pr_default.execute(6);
                     A898NotificacaoAgendadaId = BC002U8_A898NotificacaoAgendadaId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("NotificacaoAgendada");
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
               Load2U98( ) ;
            }
            EndLevel2U98( ) ;
         }
         CloseExtendedTableCursors2U98( ) ;
      }

      protected void Update2U98( )
      {
         BeforeValidate2U98( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2U98( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2U98( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2U98( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2U98( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002U9 */
                     pr_default.execute(7, new Object[] {A899NotificacaoAgendadaOrigem, A900NotificacaoAgendadaDescricao, n901NotificacaoAgendadaDias, A901NotificacaoAgendadaDias, n902NotificacaoAgendadaMomentoEnvio, A902NotificacaoAgendadaMomentoEnvio, n903NotificacaoAgendadaTipo, A903NotificacaoAgendadaTipo, n905NotificacaoAgendadaStatus, A905NotificacaoAgendadaStatus, n904NotificacaoAgendadaLayoutId, A904NotificacaoAgendadaLayoutId, A898NotificacaoAgendadaId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("NotificacaoAgendada");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"NotificacaoAgendada"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2U98( ) ;
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
            EndLevel2U98( ) ;
         }
         CloseExtendedTableCursors2U98( ) ;
      }

      protected void DeferredUpdate2U98( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2U98( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2U98( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2U98( ) ;
            AfterConfirm2U98( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2U98( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002U10 */
                  pr_default.execute(8, new Object[] {A898NotificacaoAgendadaId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("NotificacaoAgendada");
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
         sMode98 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2U98( ) ;
         Gx_mode = sMode98;
      }

      protected void OnDeleteControls2U98( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            A907NotificacaoAgendadaOffsetDias = ((StringUtil.StrCmp(A902NotificacaoAgendadaMomentoEnvio, "D")==0) ? A901NotificacaoAgendadaDias*-1 : A901NotificacaoAgendadaDias);
         }
      }

      protected void EndLevel2U98( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2U98( ) ;
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

      public void ScanKeyStart2U98( )
      {
         /* Scan By routine */
         /* Using cursor BC002U11 */
         pr_default.execute(9, new Object[] {A898NotificacaoAgendadaId});
         RcdFound98 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound98 = 1;
            A898NotificacaoAgendadaId = BC002U11_A898NotificacaoAgendadaId[0];
            A899NotificacaoAgendadaOrigem = BC002U11_A899NotificacaoAgendadaOrigem[0];
            A900NotificacaoAgendadaDescricao = BC002U11_A900NotificacaoAgendadaDescricao[0];
            A901NotificacaoAgendadaDias = BC002U11_A901NotificacaoAgendadaDias[0];
            n901NotificacaoAgendadaDias = BC002U11_n901NotificacaoAgendadaDias[0];
            A902NotificacaoAgendadaMomentoEnvio = BC002U11_A902NotificacaoAgendadaMomentoEnvio[0];
            n902NotificacaoAgendadaMomentoEnvio = BC002U11_n902NotificacaoAgendadaMomentoEnvio[0];
            A903NotificacaoAgendadaTipo = BC002U11_A903NotificacaoAgendadaTipo[0];
            n903NotificacaoAgendadaTipo = BC002U11_n903NotificacaoAgendadaTipo[0];
            A905NotificacaoAgendadaStatus = BC002U11_A905NotificacaoAgendadaStatus[0];
            n905NotificacaoAgendadaStatus = BC002U11_n905NotificacaoAgendadaStatus[0];
            A904NotificacaoAgendadaLayoutId = BC002U11_A904NotificacaoAgendadaLayoutId[0];
            n904NotificacaoAgendadaLayoutId = BC002U11_n904NotificacaoAgendadaLayoutId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2U98( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound98 = 0;
         ScanKeyLoad2U98( ) ;
      }

      protected void ScanKeyLoad2U98( )
      {
         sMode98 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound98 = 1;
            A898NotificacaoAgendadaId = BC002U11_A898NotificacaoAgendadaId[0];
            A899NotificacaoAgendadaOrigem = BC002U11_A899NotificacaoAgendadaOrigem[0];
            A900NotificacaoAgendadaDescricao = BC002U11_A900NotificacaoAgendadaDescricao[0];
            A901NotificacaoAgendadaDias = BC002U11_A901NotificacaoAgendadaDias[0];
            n901NotificacaoAgendadaDias = BC002U11_n901NotificacaoAgendadaDias[0];
            A902NotificacaoAgendadaMomentoEnvio = BC002U11_A902NotificacaoAgendadaMomentoEnvio[0];
            n902NotificacaoAgendadaMomentoEnvio = BC002U11_n902NotificacaoAgendadaMomentoEnvio[0];
            A903NotificacaoAgendadaTipo = BC002U11_A903NotificacaoAgendadaTipo[0];
            n903NotificacaoAgendadaTipo = BC002U11_n903NotificacaoAgendadaTipo[0];
            A905NotificacaoAgendadaStatus = BC002U11_A905NotificacaoAgendadaStatus[0];
            n905NotificacaoAgendadaStatus = BC002U11_n905NotificacaoAgendadaStatus[0];
            A904NotificacaoAgendadaLayoutId = BC002U11_A904NotificacaoAgendadaLayoutId[0];
            n904NotificacaoAgendadaLayoutId = BC002U11_n904NotificacaoAgendadaLayoutId[0];
         }
         Gx_mode = sMode98;
      }

      protected void ScanKeyEnd2U98( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm2U98( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2U98( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2U98( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2U98( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2U98( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2U98( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2U98( )
      {
      }

      protected void send_integrity_lvl_hashes2U98( )
      {
      }

      protected void AddRow2U98( )
      {
         VarsToRow98( bcNotificacaoAgendada) ;
      }

      protected void ReadRow2U98( )
      {
         RowToVars98( bcNotificacaoAgendada, 1) ;
      }

      protected void InitializeNonKey2U98( )
      {
         A907NotificacaoAgendadaOffsetDias = 0;
         A899NotificacaoAgendadaOrigem = "";
         A900NotificacaoAgendadaDescricao = "";
         A901NotificacaoAgendadaDias = 0;
         n901NotificacaoAgendadaDias = false;
         A902NotificacaoAgendadaMomentoEnvio = "";
         n902NotificacaoAgendadaMomentoEnvio = false;
         A903NotificacaoAgendadaTipo = "";
         n903NotificacaoAgendadaTipo = false;
         A904NotificacaoAgendadaLayoutId = 0;
         n904NotificacaoAgendadaLayoutId = false;
         A905NotificacaoAgendadaStatus = true;
         n905NotificacaoAgendadaStatus = false;
         Z899NotificacaoAgendadaOrigem = "";
         Z900NotificacaoAgendadaDescricao = "";
         Z901NotificacaoAgendadaDias = 0;
         Z902NotificacaoAgendadaMomentoEnvio = "";
         Z903NotificacaoAgendadaTipo = "";
         Z905NotificacaoAgendadaStatus = false;
         Z904NotificacaoAgendadaLayoutId = 0;
      }

      protected void InitAll2U98( )
      {
         A898NotificacaoAgendadaId = 0;
         InitializeNonKey2U98( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A905NotificacaoAgendadaStatus = i905NotificacaoAgendadaStatus;
         n905NotificacaoAgendadaStatus = false;
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

      public void VarsToRow98( SdtNotificacaoAgendada obj98 )
      {
         obj98.gxTpr_Mode = Gx_mode;
         obj98.gxTpr_Notificacaoagendadaoffsetdias = A907NotificacaoAgendadaOffsetDias;
         obj98.gxTpr_Notificacaoagendadaorigem = A899NotificacaoAgendadaOrigem;
         obj98.gxTpr_Notificacaoagendadadescricao = A900NotificacaoAgendadaDescricao;
         obj98.gxTpr_Notificacaoagendadadias = A901NotificacaoAgendadaDias;
         obj98.gxTpr_Notificacaoagendadamomentoenvio = A902NotificacaoAgendadaMomentoEnvio;
         obj98.gxTpr_Notificacaoagendadatipo = A903NotificacaoAgendadaTipo;
         obj98.gxTpr_Notificacaoagendadalayoutid = A904NotificacaoAgendadaLayoutId;
         obj98.gxTpr_Notificacaoagendadastatus = A905NotificacaoAgendadaStatus;
         obj98.gxTpr_Notificacaoagendadaid = A898NotificacaoAgendadaId;
         obj98.gxTpr_Notificacaoagendadaid_Z = Z898NotificacaoAgendadaId;
         obj98.gxTpr_Notificacaoagendadaorigem_Z = Z899NotificacaoAgendadaOrigem;
         obj98.gxTpr_Notificacaoagendadadescricao_Z = Z900NotificacaoAgendadaDescricao;
         obj98.gxTpr_Notificacaoagendadadias_Z = Z901NotificacaoAgendadaDias;
         obj98.gxTpr_Notificacaoagendadamomentoenvio_Z = Z902NotificacaoAgendadaMomentoEnvio;
         obj98.gxTpr_Notificacaoagendadatipo_Z = Z903NotificacaoAgendadaTipo;
         obj98.gxTpr_Notificacaoagendadalayoutid_Z = Z904NotificacaoAgendadaLayoutId;
         obj98.gxTpr_Notificacaoagendadastatus_Z = Z905NotificacaoAgendadaStatus;
         obj98.gxTpr_Notificacaoagendadaoffsetdias_Z = Z907NotificacaoAgendadaOffsetDias;
         obj98.gxTpr_Notificacaoagendadadias_N = (short)(Convert.ToInt16(n901NotificacaoAgendadaDias));
         obj98.gxTpr_Notificacaoagendadamomentoenvio_N = (short)(Convert.ToInt16(n902NotificacaoAgendadaMomentoEnvio));
         obj98.gxTpr_Notificacaoagendadatipo_N = (short)(Convert.ToInt16(n903NotificacaoAgendadaTipo));
         obj98.gxTpr_Notificacaoagendadalayoutid_N = (short)(Convert.ToInt16(n904NotificacaoAgendadaLayoutId));
         obj98.gxTpr_Notificacaoagendadastatus_N = (short)(Convert.ToInt16(n905NotificacaoAgendadaStatus));
         obj98.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow98( SdtNotificacaoAgendada obj98 )
      {
         obj98.gxTpr_Notificacaoagendadaid = A898NotificacaoAgendadaId;
         return  ;
      }

      public void RowToVars98( SdtNotificacaoAgendada obj98 ,
                               int forceLoad )
      {
         Gx_mode = obj98.gxTpr_Mode;
         A907NotificacaoAgendadaOffsetDias = obj98.gxTpr_Notificacaoagendadaoffsetdias;
         A899NotificacaoAgendadaOrigem = obj98.gxTpr_Notificacaoagendadaorigem;
         A900NotificacaoAgendadaDescricao = obj98.gxTpr_Notificacaoagendadadescricao;
         A901NotificacaoAgendadaDias = obj98.gxTpr_Notificacaoagendadadias;
         n901NotificacaoAgendadaDias = false;
         A902NotificacaoAgendadaMomentoEnvio = obj98.gxTpr_Notificacaoagendadamomentoenvio;
         n902NotificacaoAgendadaMomentoEnvio = false;
         A903NotificacaoAgendadaTipo = obj98.gxTpr_Notificacaoagendadatipo;
         n903NotificacaoAgendadaTipo = false;
         A904NotificacaoAgendadaLayoutId = obj98.gxTpr_Notificacaoagendadalayoutid;
         n904NotificacaoAgendadaLayoutId = false;
         A905NotificacaoAgendadaStatus = obj98.gxTpr_Notificacaoagendadastatus;
         n905NotificacaoAgendadaStatus = false;
         A898NotificacaoAgendadaId = obj98.gxTpr_Notificacaoagendadaid;
         Z898NotificacaoAgendadaId = obj98.gxTpr_Notificacaoagendadaid_Z;
         Z899NotificacaoAgendadaOrigem = obj98.gxTpr_Notificacaoagendadaorigem_Z;
         Z900NotificacaoAgendadaDescricao = obj98.gxTpr_Notificacaoagendadadescricao_Z;
         Z901NotificacaoAgendadaDias = obj98.gxTpr_Notificacaoagendadadias_Z;
         Z902NotificacaoAgendadaMomentoEnvio = obj98.gxTpr_Notificacaoagendadamomentoenvio_Z;
         Z903NotificacaoAgendadaTipo = obj98.gxTpr_Notificacaoagendadatipo_Z;
         Z904NotificacaoAgendadaLayoutId = obj98.gxTpr_Notificacaoagendadalayoutid_Z;
         Z905NotificacaoAgendadaStatus = obj98.gxTpr_Notificacaoagendadastatus_Z;
         Z907NotificacaoAgendadaOffsetDias = obj98.gxTpr_Notificacaoagendadaoffsetdias_Z;
         n901NotificacaoAgendadaDias = (bool)(Convert.ToBoolean(obj98.gxTpr_Notificacaoagendadadias_N));
         n902NotificacaoAgendadaMomentoEnvio = (bool)(Convert.ToBoolean(obj98.gxTpr_Notificacaoagendadamomentoenvio_N));
         n903NotificacaoAgendadaTipo = (bool)(Convert.ToBoolean(obj98.gxTpr_Notificacaoagendadatipo_N));
         n904NotificacaoAgendadaLayoutId = (bool)(Convert.ToBoolean(obj98.gxTpr_Notificacaoagendadalayoutid_N));
         n905NotificacaoAgendadaStatus = (bool)(Convert.ToBoolean(obj98.gxTpr_Notificacaoagendadastatus_N));
         Gx_mode = obj98.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A898NotificacaoAgendadaId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2U98( ) ;
         ScanKeyStart2U98( ) ;
         if ( RcdFound98 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z898NotificacaoAgendadaId = A898NotificacaoAgendadaId;
         }
         ZM2U98( -11) ;
         OnLoadActions2U98( ) ;
         AddRow2U98( ) ;
         ScanKeyEnd2U98( ) ;
         if ( RcdFound98 == 0 )
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
         RowToVars98( bcNotificacaoAgendada, 0) ;
         ScanKeyStart2U98( ) ;
         if ( RcdFound98 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z898NotificacaoAgendadaId = A898NotificacaoAgendadaId;
         }
         ZM2U98( -11) ;
         OnLoadActions2U98( ) ;
         AddRow2U98( ) ;
         ScanKeyEnd2U98( ) ;
         if ( RcdFound98 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2U98( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2U98( ) ;
         }
         else
         {
            if ( RcdFound98 == 1 )
            {
               if ( A898NotificacaoAgendadaId != Z898NotificacaoAgendadaId )
               {
                  A898NotificacaoAgendadaId = Z898NotificacaoAgendadaId;
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
                  Update2U98( ) ;
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
                  if ( A898NotificacaoAgendadaId != Z898NotificacaoAgendadaId )
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
                        Insert2U98( ) ;
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
                        Insert2U98( ) ;
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
         RowToVars98( bcNotificacaoAgendada, 1) ;
         SaveImpl( ) ;
         VarsToRow98( bcNotificacaoAgendada) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars98( bcNotificacaoAgendada, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2U98( ) ;
         AfterTrn( ) ;
         VarsToRow98( bcNotificacaoAgendada) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow98( bcNotificacaoAgendada) ;
         }
         else
         {
            SdtNotificacaoAgendada auxBC = new SdtNotificacaoAgendada(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A898NotificacaoAgendadaId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcNotificacaoAgendada);
               auxBC.Save();
               bcNotificacaoAgendada.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars98( bcNotificacaoAgendada, 1) ;
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
         RowToVars98( bcNotificacaoAgendada, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2U98( ) ;
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
               VarsToRow98( bcNotificacaoAgendada) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow98( bcNotificacaoAgendada) ;
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
         RowToVars98( bcNotificacaoAgendada, 0) ;
         GetKey2U98( ) ;
         if ( RcdFound98 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A898NotificacaoAgendadaId != Z898NotificacaoAgendadaId )
            {
               A898NotificacaoAgendadaId = Z898NotificacaoAgendadaId;
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
            if ( A898NotificacaoAgendadaId != Z898NotificacaoAgendadaId )
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
         context.RollbackDataStores("notificacaoagendada_bc",pr_default);
         VarsToRow98( bcNotificacaoAgendada) ;
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
         Gx_mode = bcNotificacaoAgendada.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcNotificacaoAgendada.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcNotificacaoAgendada )
         {
            bcNotificacaoAgendada = (SdtNotificacaoAgendada)(sdt);
            if ( StringUtil.StrCmp(bcNotificacaoAgendada.gxTpr_Mode, "") == 0 )
            {
               bcNotificacaoAgendada.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow98( bcNotificacaoAgendada) ;
            }
            else
            {
               RowToVars98( bcNotificacaoAgendada, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcNotificacaoAgendada.gxTpr_Mode, "") == 0 )
            {
               bcNotificacaoAgendada.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars98( bcNotificacaoAgendada, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtNotificacaoAgendada NotificacaoAgendada_BC
      {
         get {
            return bcNotificacaoAgendada ;
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
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV17Pgmname = "";
         AV12TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z899NotificacaoAgendadaOrigem = "";
         A899NotificacaoAgendadaOrigem = "";
         Z900NotificacaoAgendadaDescricao = "";
         A900NotificacaoAgendadaDescricao = "";
         Z902NotificacaoAgendadaMomentoEnvio = "";
         A902NotificacaoAgendadaMomentoEnvio = "";
         Z903NotificacaoAgendadaTipo = "";
         A903NotificacaoAgendadaTipo = "";
         BC002U5_A898NotificacaoAgendadaId = new int[1] ;
         BC002U5_A899NotificacaoAgendadaOrigem = new string[] {""} ;
         BC002U5_A900NotificacaoAgendadaDescricao = new string[] {""} ;
         BC002U5_A901NotificacaoAgendadaDias = new int[1] ;
         BC002U5_n901NotificacaoAgendadaDias = new bool[] {false} ;
         BC002U5_A902NotificacaoAgendadaMomentoEnvio = new string[] {""} ;
         BC002U5_n902NotificacaoAgendadaMomentoEnvio = new bool[] {false} ;
         BC002U5_A903NotificacaoAgendadaTipo = new string[] {""} ;
         BC002U5_n903NotificacaoAgendadaTipo = new bool[] {false} ;
         BC002U5_A905NotificacaoAgendadaStatus = new bool[] {false} ;
         BC002U5_n905NotificacaoAgendadaStatus = new bool[] {false} ;
         BC002U5_A904NotificacaoAgendadaLayoutId = new short[1] ;
         BC002U5_n904NotificacaoAgendadaLayoutId = new bool[] {false} ;
         BC002U4_A904NotificacaoAgendadaLayoutId = new short[1] ;
         BC002U4_n904NotificacaoAgendadaLayoutId = new bool[] {false} ;
         BC002U6_A898NotificacaoAgendadaId = new int[1] ;
         BC002U3_A898NotificacaoAgendadaId = new int[1] ;
         BC002U3_A899NotificacaoAgendadaOrigem = new string[] {""} ;
         BC002U3_A900NotificacaoAgendadaDescricao = new string[] {""} ;
         BC002U3_A901NotificacaoAgendadaDias = new int[1] ;
         BC002U3_n901NotificacaoAgendadaDias = new bool[] {false} ;
         BC002U3_A902NotificacaoAgendadaMomentoEnvio = new string[] {""} ;
         BC002U3_n902NotificacaoAgendadaMomentoEnvio = new bool[] {false} ;
         BC002U3_A903NotificacaoAgendadaTipo = new string[] {""} ;
         BC002U3_n903NotificacaoAgendadaTipo = new bool[] {false} ;
         BC002U3_A905NotificacaoAgendadaStatus = new bool[] {false} ;
         BC002U3_n905NotificacaoAgendadaStatus = new bool[] {false} ;
         BC002U3_A904NotificacaoAgendadaLayoutId = new short[1] ;
         BC002U3_n904NotificacaoAgendadaLayoutId = new bool[] {false} ;
         sMode98 = "";
         BC002U2_A898NotificacaoAgendadaId = new int[1] ;
         BC002U2_A899NotificacaoAgendadaOrigem = new string[] {""} ;
         BC002U2_A900NotificacaoAgendadaDescricao = new string[] {""} ;
         BC002U2_A901NotificacaoAgendadaDias = new int[1] ;
         BC002U2_n901NotificacaoAgendadaDias = new bool[] {false} ;
         BC002U2_A902NotificacaoAgendadaMomentoEnvio = new string[] {""} ;
         BC002U2_n902NotificacaoAgendadaMomentoEnvio = new bool[] {false} ;
         BC002U2_A903NotificacaoAgendadaTipo = new string[] {""} ;
         BC002U2_n903NotificacaoAgendadaTipo = new bool[] {false} ;
         BC002U2_A905NotificacaoAgendadaStatus = new bool[] {false} ;
         BC002U2_n905NotificacaoAgendadaStatus = new bool[] {false} ;
         BC002U2_A904NotificacaoAgendadaLayoutId = new short[1] ;
         BC002U2_n904NotificacaoAgendadaLayoutId = new bool[] {false} ;
         BC002U8_A898NotificacaoAgendadaId = new int[1] ;
         BC002U11_A898NotificacaoAgendadaId = new int[1] ;
         BC002U11_A899NotificacaoAgendadaOrigem = new string[] {""} ;
         BC002U11_A900NotificacaoAgendadaDescricao = new string[] {""} ;
         BC002U11_A901NotificacaoAgendadaDias = new int[1] ;
         BC002U11_n901NotificacaoAgendadaDias = new bool[] {false} ;
         BC002U11_A902NotificacaoAgendadaMomentoEnvio = new string[] {""} ;
         BC002U11_n902NotificacaoAgendadaMomentoEnvio = new bool[] {false} ;
         BC002U11_A903NotificacaoAgendadaTipo = new string[] {""} ;
         BC002U11_n903NotificacaoAgendadaTipo = new bool[] {false} ;
         BC002U11_A905NotificacaoAgendadaStatus = new bool[] {false} ;
         BC002U11_n905NotificacaoAgendadaStatus = new bool[] {false} ;
         BC002U11_A904NotificacaoAgendadaLayoutId = new short[1] ;
         BC002U11_n904NotificacaoAgendadaLayoutId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.notificacaoagendada_bc__default(),
            new Object[][] {
                new Object[] {
               BC002U2_A898NotificacaoAgendadaId, BC002U2_A899NotificacaoAgendadaOrigem, BC002U2_A900NotificacaoAgendadaDescricao, BC002U2_A901NotificacaoAgendadaDias, BC002U2_n901NotificacaoAgendadaDias, BC002U2_A902NotificacaoAgendadaMomentoEnvio, BC002U2_n902NotificacaoAgendadaMomentoEnvio, BC002U2_A903NotificacaoAgendadaTipo, BC002U2_n903NotificacaoAgendadaTipo, BC002U2_A905NotificacaoAgendadaStatus,
               BC002U2_n905NotificacaoAgendadaStatus, BC002U2_A904NotificacaoAgendadaLayoutId, BC002U2_n904NotificacaoAgendadaLayoutId
               }
               , new Object[] {
               BC002U3_A898NotificacaoAgendadaId, BC002U3_A899NotificacaoAgendadaOrigem, BC002U3_A900NotificacaoAgendadaDescricao, BC002U3_A901NotificacaoAgendadaDias, BC002U3_n901NotificacaoAgendadaDias, BC002U3_A902NotificacaoAgendadaMomentoEnvio, BC002U3_n902NotificacaoAgendadaMomentoEnvio, BC002U3_A903NotificacaoAgendadaTipo, BC002U3_n903NotificacaoAgendadaTipo, BC002U3_A905NotificacaoAgendadaStatus,
               BC002U3_n905NotificacaoAgendadaStatus, BC002U3_A904NotificacaoAgendadaLayoutId, BC002U3_n904NotificacaoAgendadaLayoutId
               }
               , new Object[] {
               BC002U4_A904NotificacaoAgendadaLayoutId
               }
               , new Object[] {
               BC002U5_A898NotificacaoAgendadaId, BC002U5_A899NotificacaoAgendadaOrigem, BC002U5_A900NotificacaoAgendadaDescricao, BC002U5_A901NotificacaoAgendadaDias, BC002U5_n901NotificacaoAgendadaDias, BC002U5_A902NotificacaoAgendadaMomentoEnvio, BC002U5_n902NotificacaoAgendadaMomentoEnvio, BC002U5_A903NotificacaoAgendadaTipo, BC002U5_n903NotificacaoAgendadaTipo, BC002U5_A905NotificacaoAgendadaStatus,
               BC002U5_n905NotificacaoAgendadaStatus, BC002U5_A904NotificacaoAgendadaLayoutId, BC002U5_n904NotificacaoAgendadaLayoutId
               }
               , new Object[] {
               BC002U6_A898NotificacaoAgendadaId
               }
               , new Object[] {
               }
               , new Object[] {
               BC002U8_A898NotificacaoAgendadaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002U11_A898NotificacaoAgendadaId, BC002U11_A899NotificacaoAgendadaOrigem, BC002U11_A900NotificacaoAgendadaDescricao, BC002U11_A901NotificacaoAgendadaDias, BC002U11_n901NotificacaoAgendadaDias, BC002U11_A902NotificacaoAgendadaMomentoEnvio, BC002U11_n902NotificacaoAgendadaMomentoEnvio, BC002U11_A903NotificacaoAgendadaTipo, BC002U11_n903NotificacaoAgendadaTipo, BC002U11_A905NotificacaoAgendadaStatus,
               BC002U11_n905NotificacaoAgendadaStatus, BC002U11_A904NotificacaoAgendadaLayoutId, BC002U11_n904NotificacaoAgendadaLayoutId
               }
            }
         );
         AV17Pgmname = "NotificacaoAgendada_BC";
         Z905NotificacaoAgendadaStatus = true;
         n905NotificacaoAgendadaStatus = false;
         A905NotificacaoAgendadaStatus = true;
         n905NotificacaoAgendadaStatus = false;
         i905NotificacaoAgendadaStatus = true;
         n905NotificacaoAgendadaStatus = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E122U2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short AV11Insert_NotificacaoAgendadaLayoutId ;
      private short Z904NotificacaoAgendadaLayoutId ;
      private short A904NotificacaoAgendadaLayoutId ;
      private short Gx_BScreen ;
      private short RcdFound98 ;
      private int trnEnded ;
      private int Z898NotificacaoAgendadaId ;
      private int A898NotificacaoAgendadaId ;
      private int AV18GXV1 ;
      private int Z901NotificacaoAgendadaDias ;
      private int A901NotificacaoAgendadaDias ;
      private int Z907NotificacaoAgendadaOffsetDias ;
      private int A907NotificacaoAgendadaOffsetDias ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV17Pgmname ;
      private string sMode98 ;
      private bool returnInSub ;
      private bool Z905NotificacaoAgendadaStatus ;
      private bool A905NotificacaoAgendadaStatus ;
      private bool n905NotificacaoAgendadaStatus ;
      private bool n901NotificacaoAgendadaDias ;
      private bool n902NotificacaoAgendadaMomentoEnvio ;
      private bool n903NotificacaoAgendadaTipo ;
      private bool n904NotificacaoAgendadaLayoutId ;
      private bool Gx_longc ;
      private bool i905NotificacaoAgendadaStatus ;
      private string Z899NotificacaoAgendadaOrigem ;
      private string A899NotificacaoAgendadaOrigem ;
      private string Z900NotificacaoAgendadaDescricao ;
      private string A900NotificacaoAgendadaDescricao ;
      private string Z902NotificacaoAgendadaMomentoEnvio ;
      private string A902NotificacaoAgendadaMomentoEnvio ;
      private string Z903NotificacaoAgendadaTipo ;
      private string A903NotificacaoAgendadaTipo ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] BC002U5_A898NotificacaoAgendadaId ;
      private string[] BC002U5_A899NotificacaoAgendadaOrigem ;
      private string[] BC002U5_A900NotificacaoAgendadaDescricao ;
      private int[] BC002U5_A901NotificacaoAgendadaDias ;
      private bool[] BC002U5_n901NotificacaoAgendadaDias ;
      private string[] BC002U5_A902NotificacaoAgendadaMomentoEnvio ;
      private bool[] BC002U5_n902NotificacaoAgendadaMomentoEnvio ;
      private string[] BC002U5_A903NotificacaoAgendadaTipo ;
      private bool[] BC002U5_n903NotificacaoAgendadaTipo ;
      private bool[] BC002U5_A905NotificacaoAgendadaStatus ;
      private bool[] BC002U5_n905NotificacaoAgendadaStatus ;
      private short[] BC002U5_A904NotificacaoAgendadaLayoutId ;
      private bool[] BC002U5_n904NotificacaoAgendadaLayoutId ;
      private short[] BC002U4_A904NotificacaoAgendadaLayoutId ;
      private bool[] BC002U4_n904NotificacaoAgendadaLayoutId ;
      private int[] BC002U6_A898NotificacaoAgendadaId ;
      private int[] BC002U3_A898NotificacaoAgendadaId ;
      private string[] BC002U3_A899NotificacaoAgendadaOrigem ;
      private string[] BC002U3_A900NotificacaoAgendadaDescricao ;
      private int[] BC002U3_A901NotificacaoAgendadaDias ;
      private bool[] BC002U3_n901NotificacaoAgendadaDias ;
      private string[] BC002U3_A902NotificacaoAgendadaMomentoEnvio ;
      private bool[] BC002U3_n902NotificacaoAgendadaMomentoEnvio ;
      private string[] BC002U3_A903NotificacaoAgendadaTipo ;
      private bool[] BC002U3_n903NotificacaoAgendadaTipo ;
      private bool[] BC002U3_A905NotificacaoAgendadaStatus ;
      private bool[] BC002U3_n905NotificacaoAgendadaStatus ;
      private short[] BC002U3_A904NotificacaoAgendadaLayoutId ;
      private bool[] BC002U3_n904NotificacaoAgendadaLayoutId ;
      private int[] BC002U2_A898NotificacaoAgendadaId ;
      private string[] BC002U2_A899NotificacaoAgendadaOrigem ;
      private string[] BC002U2_A900NotificacaoAgendadaDescricao ;
      private int[] BC002U2_A901NotificacaoAgendadaDias ;
      private bool[] BC002U2_n901NotificacaoAgendadaDias ;
      private string[] BC002U2_A902NotificacaoAgendadaMomentoEnvio ;
      private bool[] BC002U2_n902NotificacaoAgendadaMomentoEnvio ;
      private string[] BC002U2_A903NotificacaoAgendadaTipo ;
      private bool[] BC002U2_n903NotificacaoAgendadaTipo ;
      private bool[] BC002U2_A905NotificacaoAgendadaStatus ;
      private bool[] BC002U2_n905NotificacaoAgendadaStatus ;
      private short[] BC002U2_A904NotificacaoAgendadaLayoutId ;
      private bool[] BC002U2_n904NotificacaoAgendadaLayoutId ;
      private int[] BC002U8_A898NotificacaoAgendadaId ;
      private int[] BC002U11_A898NotificacaoAgendadaId ;
      private string[] BC002U11_A899NotificacaoAgendadaOrigem ;
      private string[] BC002U11_A900NotificacaoAgendadaDescricao ;
      private int[] BC002U11_A901NotificacaoAgendadaDias ;
      private bool[] BC002U11_n901NotificacaoAgendadaDias ;
      private string[] BC002U11_A902NotificacaoAgendadaMomentoEnvio ;
      private bool[] BC002U11_n902NotificacaoAgendadaMomentoEnvio ;
      private string[] BC002U11_A903NotificacaoAgendadaTipo ;
      private bool[] BC002U11_n903NotificacaoAgendadaTipo ;
      private bool[] BC002U11_A905NotificacaoAgendadaStatus ;
      private bool[] BC002U11_n905NotificacaoAgendadaStatus ;
      private short[] BC002U11_A904NotificacaoAgendadaLayoutId ;
      private bool[] BC002U11_n904NotificacaoAgendadaLayoutId ;
      private SdtNotificacaoAgendada bcNotificacaoAgendada ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class notificacaoagendada_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC002U2;
          prmBC002U2 = new Object[] {
          new ParDef("NotificacaoAgendadaId",GXType.Int32,9,0)
          };
          Object[] prmBC002U3;
          prmBC002U3 = new Object[] {
          new ParDef("NotificacaoAgendadaId",GXType.Int32,9,0)
          };
          Object[] prmBC002U4;
          prmBC002U4 = new Object[] {
          new ParDef("NotificacaoAgendadaLayoutId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002U5;
          prmBC002U5 = new Object[] {
          new ParDef("NotificacaoAgendadaId",GXType.Int32,9,0)
          };
          Object[] prmBC002U6;
          prmBC002U6 = new Object[] {
          new ParDef("NotificacaoAgendadaId",GXType.Int32,9,0)
          };
          Object[] prmBC002U7;
          prmBC002U7 = new Object[] {
          new ParDef("NotificacaoAgendadaOrigem",GXType.VarChar,1,0) ,
          new ParDef("NotificacaoAgendadaDescricao",GXType.VarChar,120,0) ,
          new ParDef("NotificacaoAgendadaDias",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaMomentoEnvio",GXType.VarChar,1,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaTipo",GXType.VarChar,1,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaLayoutId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002U8;
          prmBC002U8 = new Object[] {
          };
          Object[] prmBC002U9;
          prmBC002U9 = new Object[] {
          new ParDef("NotificacaoAgendadaOrigem",GXType.VarChar,1,0) ,
          new ParDef("NotificacaoAgendadaDescricao",GXType.VarChar,120,0) ,
          new ParDef("NotificacaoAgendadaDias",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaMomentoEnvio",GXType.VarChar,1,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaTipo",GXType.VarChar,1,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaLayoutId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("NotificacaoAgendadaId",GXType.Int32,9,0)
          };
          Object[] prmBC002U10;
          prmBC002U10 = new Object[] {
          new ParDef("NotificacaoAgendadaId",GXType.Int32,9,0)
          };
          Object[] prmBC002U11;
          prmBC002U11 = new Object[] {
          new ParDef("NotificacaoAgendadaId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC002U2", "SELECT NotificacaoAgendadaId, NotificacaoAgendadaOrigem, NotificacaoAgendadaDescricao, NotificacaoAgendadaDias, NotificacaoAgendadaMomentoEnvio, NotificacaoAgendadaTipo, NotificacaoAgendadaStatus, NotificacaoAgendadaLayoutId FROM NotificacaoAgendada WHERE NotificacaoAgendadaId = :NotificacaoAgendadaId  FOR UPDATE OF NotificacaoAgendada",true, GxErrorMask.GX_NOMASK, false, this,prmBC002U2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002U3", "SELECT NotificacaoAgendadaId, NotificacaoAgendadaOrigem, NotificacaoAgendadaDescricao, NotificacaoAgendadaDias, NotificacaoAgendadaMomentoEnvio, NotificacaoAgendadaTipo, NotificacaoAgendadaStatus, NotificacaoAgendadaLayoutId FROM NotificacaoAgendada WHERE NotificacaoAgendadaId = :NotificacaoAgendadaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002U3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002U4", "SELECT LayoutContratoId AS NotificacaoAgendadaLayoutId FROM LayoutContrato WHERE LayoutContratoId = :NotificacaoAgendadaLayoutId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002U4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002U5", "SELECT TM1.NotificacaoAgendadaId, TM1.NotificacaoAgendadaOrigem, TM1.NotificacaoAgendadaDescricao, TM1.NotificacaoAgendadaDias, TM1.NotificacaoAgendadaMomentoEnvio, TM1.NotificacaoAgendadaTipo, TM1.NotificacaoAgendadaStatus, TM1.NotificacaoAgendadaLayoutId AS NotificacaoAgendadaLayoutId FROM NotificacaoAgendada TM1 WHERE TM1.NotificacaoAgendadaId = :NotificacaoAgendadaId ORDER BY TM1.NotificacaoAgendadaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002U5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002U6", "SELECT NotificacaoAgendadaId FROM NotificacaoAgendada WHERE NotificacaoAgendadaId = :NotificacaoAgendadaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002U6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002U7", "SAVEPOINT gxupdate;INSERT INTO NotificacaoAgendada(NotificacaoAgendadaOrigem, NotificacaoAgendadaDescricao, NotificacaoAgendadaDias, NotificacaoAgendadaMomentoEnvio, NotificacaoAgendadaTipo, NotificacaoAgendadaStatus, NotificacaoAgendadaLayoutId) VALUES(:NotificacaoAgendadaOrigem, :NotificacaoAgendadaDescricao, :NotificacaoAgendadaDias, :NotificacaoAgendadaMomentoEnvio, :NotificacaoAgendadaTipo, :NotificacaoAgendadaStatus, :NotificacaoAgendadaLayoutId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002U7)
             ,new CursorDef("BC002U8", "SELECT currval('NotificacaoAgendadaId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002U8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002U9", "SAVEPOINT gxupdate;UPDATE NotificacaoAgendada SET NotificacaoAgendadaOrigem=:NotificacaoAgendadaOrigem, NotificacaoAgendadaDescricao=:NotificacaoAgendadaDescricao, NotificacaoAgendadaDias=:NotificacaoAgendadaDias, NotificacaoAgendadaMomentoEnvio=:NotificacaoAgendadaMomentoEnvio, NotificacaoAgendadaTipo=:NotificacaoAgendadaTipo, NotificacaoAgendadaStatus=:NotificacaoAgendadaStatus, NotificacaoAgendadaLayoutId=:NotificacaoAgendadaLayoutId  WHERE NotificacaoAgendadaId = :NotificacaoAgendadaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002U9)
             ,new CursorDef("BC002U10", "SAVEPOINT gxupdate;DELETE FROM NotificacaoAgendada  WHERE NotificacaoAgendadaId = :NotificacaoAgendadaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002U10)
             ,new CursorDef("BC002U11", "SELECT TM1.NotificacaoAgendadaId, TM1.NotificacaoAgendadaOrigem, TM1.NotificacaoAgendadaDescricao, TM1.NotificacaoAgendadaDias, TM1.NotificacaoAgendadaMomentoEnvio, TM1.NotificacaoAgendadaTipo, TM1.NotificacaoAgendadaStatus, TM1.NotificacaoAgendadaLayoutId AS NotificacaoAgendadaLayoutId FROM NotificacaoAgendada TM1 WHERE TM1.NotificacaoAgendadaId = :NotificacaoAgendadaId ORDER BY TM1.NotificacaoAgendadaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002U11,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((bool[]) buf[9])[0] = rslt.getBool(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((short[]) buf[11])[0] = rslt.getShort(8);
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((bool[]) buf[9])[0] = rslt.getBool(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((short[]) buf[11])[0] = rslt.getShort(8);
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((bool[]) buf[9])[0] = rslt.getBool(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((short[]) buf[11])[0] = rslt.getShort(8);
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((bool[]) buf[9])[0] = rslt.getBool(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((short[]) buf[11])[0] = rslt.getShort(8);
                ((bool[]) buf[12])[0] = rslt.wasNull(8);
                return;
       }
    }

 }

}
