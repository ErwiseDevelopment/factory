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
   public class configuracaonotificacoes_bc : GxSilentTrn, IGxSilentTrn
   {
      public configuracaonotificacoes_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public configuracaonotificacoes_bc( IGxContext context )
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
         ReadRow1V69( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1V69( ) ;
         standaloneModal( ) ;
         AddRow1V69( ) ;
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
            E111V2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z491ConfiguracaoNotificacoesId = A491ConfiguracaoNotificacoesId;
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

      protected void CONFIRM_1V0( )
      {
         BeforeValidate1V69( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1V69( ) ;
            }
            else
            {
               CheckExtendedTable1V69( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1V69( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E121V2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E111V2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1V69( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z492ConfiguracaoNotificacoesEmail = A492ConfiguracaoNotificacoesEmail;
         }
         if ( GX_JID == -2 )
         {
            Z491ConfiguracaoNotificacoesId = A491ConfiguracaoNotificacoesId;
            Z492ConfiguracaoNotificacoesEmail = A492ConfiguracaoNotificacoesEmail;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load1V69( )
      {
         /* Using cursor BC001V4 */
         pr_default.execute(2, new Object[] {A491ConfiguracaoNotificacoesId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound69 = 1;
            A492ConfiguracaoNotificacoesEmail = BC001V4_A492ConfiguracaoNotificacoesEmail[0];
            n492ConfiguracaoNotificacoesEmail = BC001V4_n492ConfiguracaoNotificacoesEmail[0];
            ZM1V69( -2) ;
         }
         pr_default.close(2);
         OnLoadActions1V69( ) ;
      }

      protected void OnLoadActions1V69( )
      {
      }

      protected void CheckExtendedTable1V69( )
      {
         standaloneModal( ) ;
         if ( ! ( GxRegex.IsMatch(A492ConfiguracaoNotificacoesEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A492ConfiguracaoNotificacoesEmail)) ) )
         {
            GX_msglist.addItem("O valor de Configuracao Notificacoes Email não coincide com o padrão especificado", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1V69( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1V69( )
      {
         /* Using cursor BC001V5 */
         pr_default.execute(3, new Object[] {A491ConfiguracaoNotificacoesId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound69 = 1;
         }
         else
         {
            RcdFound69 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001V3 */
         pr_default.execute(1, new Object[] {A491ConfiguracaoNotificacoesId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1V69( 2) ;
            RcdFound69 = 1;
            A491ConfiguracaoNotificacoesId = BC001V3_A491ConfiguracaoNotificacoesId[0];
            A492ConfiguracaoNotificacoesEmail = BC001V3_A492ConfiguracaoNotificacoesEmail[0];
            n492ConfiguracaoNotificacoesEmail = BC001V3_n492ConfiguracaoNotificacoesEmail[0];
            Z491ConfiguracaoNotificacoesId = A491ConfiguracaoNotificacoesId;
            sMode69 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1V69( ) ;
            if ( AnyError == 1 )
            {
               RcdFound69 = 0;
               InitializeNonKey1V69( ) ;
            }
            Gx_mode = sMode69;
         }
         else
         {
            RcdFound69 = 0;
            InitializeNonKey1V69( ) ;
            sMode69 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode69;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1V69( ) ;
         if ( RcdFound69 == 0 )
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
         CONFIRM_1V0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1V69( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001V2 */
            pr_default.execute(0, new Object[] {A491ConfiguracaoNotificacoesId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ConfiguracaoNotificacoes"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z492ConfiguracaoNotificacoesEmail, BC001V2_A492ConfiguracaoNotificacoesEmail[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ConfiguracaoNotificacoes"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1V69( )
      {
         BeforeValidate1V69( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1V69( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1V69( 0) ;
            CheckOptimisticConcurrency1V69( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1V69( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1V69( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001V6 */
                     pr_default.execute(4, new Object[] {n492ConfiguracaoNotificacoesEmail, A492ConfiguracaoNotificacoesEmail});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC001V7 */
                     pr_default.execute(5);
                     A491ConfiguracaoNotificacoesId = BC001V7_A491ConfiguracaoNotificacoesId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("ConfiguracaoNotificacoes");
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
               Load1V69( ) ;
            }
            EndLevel1V69( ) ;
         }
         CloseExtendedTableCursors1V69( ) ;
      }

      protected void Update1V69( )
      {
         BeforeValidate1V69( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1V69( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1V69( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1V69( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1V69( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001V8 */
                     pr_default.execute(6, new Object[] {n492ConfiguracaoNotificacoesEmail, A492ConfiguracaoNotificacoesEmail, A491ConfiguracaoNotificacoesId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("ConfiguracaoNotificacoes");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ConfiguracaoNotificacoes"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1V69( ) ;
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
            EndLevel1V69( ) ;
         }
         CloseExtendedTableCursors1V69( ) ;
      }

      protected void DeferredUpdate1V69( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1V69( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1V69( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1V69( ) ;
            AfterConfirm1V69( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1V69( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001V9 */
                  pr_default.execute(7, new Object[] {A491ConfiguracaoNotificacoesId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("ConfiguracaoNotificacoes");
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
         sMode69 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1V69( ) ;
         Gx_mode = sMode69;
      }

      protected void OnDeleteControls1V69( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1V69( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1V69( ) ;
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

      public void ScanKeyStart1V69( )
      {
         /* Scan By routine */
         /* Using cursor BC001V10 */
         pr_default.execute(8, new Object[] {A491ConfiguracaoNotificacoesId});
         RcdFound69 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound69 = 1;
            A491ConfiguracaoNotificacoesId = BC001V10_A491ConfiguracaoNotificacoesId[0];
            A492ConfiguracaoNotificacoesEmail = BC001V10_A492ConfiguracaoNotificacoesEmail[0];
            n492ConfiguracaoNotificacoesEmail = BC001V10_n492ConfiguracaoNotificacoesEmail[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1V69( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound69 = 0;
         ScanKeyLoad1V69( ) ;
      }

      protected void ScanKeyLoad1V69( )
      {
         sMode69 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound69 = 1;
            A491ConfiguracaoNotificacoesId = BC001V10_A491ConfiguracaoNotificacoesId[0];
            A492ConfiguracaoNotificacoesEmail = BC001V10_A492ConfiguracaoNotificacoesEmail[0];
            n492ConfiguracaoNotificacoesEmail = BC001V10_n492ConfiguracaoNotificacoesEmail[0];
         }
         Gx_mode = sMode69;
      }

      protected void ScanKeyEnd1V69( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm1V69( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1V69( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1V69( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1V69( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1V69( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1V69( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1V69( )
      {
      }

      protected void send_integrity_lvl_hashes1V69( )
      {
      }

      protected void AddRow1V69( )
      {
         VarsToRow69( bcConfiguracaoNotificacoes) ;
      }

      protected void ReadRow1V69( )
      {
         RowToVars69( bcConfiguracaoNotificacoes, 1) ;
      }

      protected void InitializeNonKey1V69( )
      {
         A492ConfiguracaoNotificacoesEmail = "";
         n492ConfiguracaoNotificacoesEmail = false;
         Z492ConfiguracaoNotificacoesEmail = "";
      }

      protected void InitAll1V69( )
      {
         A491ConfiguracaoNotificacoesId = 0;
         InitializeNonKey1V69( ) ;
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

      public void VarsToRow69( SdtConfiguracaoNotificacoes obj69 )
      {
         obj69.gxTpr_Mode = Gx_mode;
         obj69.gxTpr_Configuracaonotificacoesemail = A492ConfiguracaoNotificacoesEmail;
         obj69.gxTpr_Configuracaonotificacoesid = A491ConfiguracaoNotificacoesId;
         obj69.gxTpr_Configuracaonotificacoesid_Z = Z491ConfiguracaoNotificacoesId;
         obj69.gxTpr_Configuracaonotificacoesemail_Z = Z492ConfiguracaoNotificacoesEmail;
         obj69.gxTpr_Configuracaonotificacoesemail_N = (short)(Convert.ToInt16(n492ConfiguracaoNotificacoesEmail));
         obj69.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow69( SdtConfiguracaoNotificacoes obj69 )
      {
         obj69.gxTpr_Configuracaonotificacoesid = A491ConfiguracaoNotificacoesId;
         return  ;
      }

      public void RowToVars69( SdtConfiguracaoNotificacoes obj69 ,
                               int forceLoad )
      {
         Gx_mode = obj69.gxTpr_Mode;
         A492ConfiguracaoNotificacoesEmail = obj69.gxTpr_Configuracaonotificacoesemail;
         n492ConfiguracaoNotificacoesEmail = false;
         A491ConfiguracaoNotificacoesId = obj69.gxTpr_Configuracaonotificacoesid;
         Z491ConfiguracaoNotificacoesId = obj69.gxTpr_Configuracaonotificacoesid_Z;
         Z492ConfiguracaoNotificacoesEmail = obj69.gxTpr_Configuracaonotificacoesemail_Z;
         n492ConfiguracaoNotificacoesEmail = (bool)(Convert.ToBoolean(obj69.gxTpr_Configuracaonotificacoesemail_N));
         Gx_mode = obj69.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A491ConfiguracaoNotificacoesId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1V69( ) ;
         ScanKeyStart1V69( ) ;
         if ( RcdFound69 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z491ConfiguracaoNotificacoesId = A491ConfiguracaoNotificacoesId;
         }
         ZM1V69( -2) ;
         OnLoadActions1V69( ) ;
         AddRow1V69( ) ;
         ScanKeyEnd1V69( ) ;
         if ( RcdFound69 == 0 )
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
         RowToVars69( bcConfiguracaoNotificacoes, 0) ;
         ScanKeyStart1V69( ) ;
         if ( RcdFound69 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z491ConfiguracaoNotificacoesId = A491ConfiguracaoNotificacoesId;
         }
         ZM1V69( -2) ;
         OnLoadActions1V69( ) ;
         AddRow1V69( ) ;
         ScanKeyEnd1V69( ) ;
         if ( RcdFound69 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1V69( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1V69( ) ;
         }
         else
         {
            if ( RcdFound69 == 1 )
            {
               if ( A491ConfiguracaoNotificacoesId != Z491ConfiguracaoNotificacoesId )
               {
                  A491ConfiguracaoNotificacoesId = Z491ConfiguracaoNotificacoesId;
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
                  Update1V69( ) ;
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
                  if ( A491ConfiguracaoNotificacoesId != Z491ConfiguracaoNotificacoesId )
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
                        Insert1V69( ) ;
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
                        Insert1V69( ) ;
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
         RowToVars69( bcConfiguracaoNotificacoes, 1) ;
         SaveImpl( ) ;
         VarsToRow69( bcConfiguracaoNotificacoes) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars69( bcConfiguracaoNotificacoes, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1V69( ) ;
         AfterTrn( ) ;
         VarsToRow69( bcConfiguracaoNotificacoes) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow69( bcConfiguracaoNotificacoes) ;
         }
         else
         {
            SdtConfiguracaoNotificacoes auxBC = new SdtConfiguracaoNotificacoes(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A491ConfiguracaoNotificacoesId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcConfiguracaoNotificacoes);
               auxBC.Save();
               bcConfiguracaoNotificacoes.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars69( bcConfiguracaoNotificacoes, 1) ;
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
         RowToVars69( bcConfiguracaoNotificacoes, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1V69( ) ;
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
               VarsToRow69( bcConfiguracaoNotificacoes) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow69( bcConfiguracaoNotificacoes) ;
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
         RowToVars69( bcConfiguracaoNotificacoes, 0) ;
         GetKey1V69( ) ;
         if ( RcdFound69 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A491ConfiguracaoNotificacoesId != Z491ConfiguracaoNotificacoesId )
            {
               A491ConfiguracaoNotificacoesId = Z491ConfiguracaoNotificacoesId;
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
            if ( A491ConfiguracaoNotificacoesId != Z491ConfiguracaoNotificacoesId )
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
         context.RollbackDataStores("configuracaonotificacoes_bc",pr_default);
         VarsToRow69( bcConfiguracaoNotificacoes) ;
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
         Gx_mode = bcConfiguracaoNotificacoes.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcConfiguracaoNotificacoes.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcConfiguracaoNotificacoes )
         {
            bcConfiguracaoNotificacoes = (SdtConfiguracaoNotificacoes)(sdt);
            if ( StringUtil.StrCmp(bcConfiguracaoNotificacoes.gxTpr_Mode, "") == 0 )
            {
               bcConfiguracaoNotificacoes.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow69( bcConfiguracaoNotificacoes) ;
            }
            else
            {
               RowToVars69( bcConfiguracaoNotificacoes, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcConfiguracaoNotificacoes.gxTpr_Mode, "") == 0 )
            {
               bcConfiguracaoNotificacoes.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars69( bcConfiguracaoNotificacoes, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtConfiguracaoNotificacoes ConfiguracaoNotificacoes_BC
      {
         get {
            return bcConfiguracaoNotificacoes ;
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
         Z492ConfiguracaoNotificacoesEmail = "";
         A492ConfiguracaoNotificacoesEmail = "";
         BC001V4_A491ConfiguracaoNotificacoesId = new int[1] ;
         BC001V4_A492ConfiguracaoNotificacoesEmail = new string[] {""} ;
         BC001V4_n492ConfiguracaoNotificacoesEmail = new bool[] {false} ;
         BC001V5_A491ConfiguracaoNotificacoesId = new int[1] ;
         BC001V3_A491ConfiguracaoNotificacoesId = new int[1] ;
         BC001V3_A492ConfiguracaoNotificacoesEmail = new string[] {""} ;
         BC001V3_n492ConfiguracaoNotificacoesEmail = new bool[] {false} ;
         sMode69 = "";
         BC001V2_A491ConfiguracaoNotificacoesId = new int[1] ;
         BC001V2_A492ConfiguracaoNotificacoesEmail = new string[] {""} ;
         BC001V2_n492ConfiguracaoNotificacoesEmail = new bool[] {false} ;
         BC001V7_A491ConfiguracaoNotificacoesId = new int[1] ;
         BC001V10_A491ConfiguracaoNotificacoesId = new int[1] ;
         BC001V10_A492ConfiguracaoNotificacoesEmail = new string[] {""} ;
         BC001V10_n492ConfiguracaoNotificacoesEmail = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracaonotificacoes_bc__default(),
            new Object[][] {
                new Object[] {
               BC001V2_A491ConfiguracaoNotificacoesId, BC001V2_A492ConfiguracaoNotificacoesEmail, BC001V2_n492ConfiguracaoNotificacoesEmail
               }
               , new Object[] {
               BC001V3_A491ConfiguracaoNotificacoesId, BC001V3_A492ConfiguracaoNotificacoesEmail, BC001V3_n492ConfiguracaoNotificacoesEmail
               }
               , new Object[] {
               BC001V4_A491ConfiguracaoNotificacoesId, BC001V4_A492ConfiguracaoNotificacoesEmail, BC001V4_n492ConfiguracaoNotificacoesEmail
               }
               , new Object[] {
               BC001V5_A491ConfiguracaoNotificacoesId
               }
               , new Object[] {
               }
               , new Object[] {
               BC001V7_A491ConfiguracaoNotificacoesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001V10_A491ConfiguracaoNotificacoesId, BC001V10_A492ConfiguracaoNotificacoesEmail, BC001V10_n492ConfiguracaoNotificacoesEmail
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121V2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound69 ;
      private int trnEnded ;
      private int Z491ConfiguracaoNotificacoesId ;
      private int A491ConfiguracaoNotificacoesId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode69 ;
      private bool returnInSub ;
      private bool n492ConfiguracaoNotificacoesEmail ;
      private string Z492ConfiguracaoNotificacoesEmail ;
      private string A492ConfiguracaoNotificacoesEmail ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private int[] BC001V4_A491ConfiguracaoNotificacoesId ;
      private string[] BC001V4_A492ConfiguracaoNotificacoesEmail ;
      private bool[] BC001V4_n492ConfiguracaoNotificacoesEmail ;
      private int[] BC001V5_A491ConfiguracaoNotificacoesId ;
      private int[] BC001V3_A491ConfiguracaoNotificacoesId ;
      private string[] BC001V3_A492ConfiguracaoNotificacoesEmail ;
      private bool[] BC001V3_n492ConfiguracaoNotificacoesEmail ;
      private int[] BC001V2_A491ConfiguracaoNotificacoesId ;
      private string[] BC001V2_A492ConfiguracaoNotificacoesEmail ;
      private bool[] BC001V2_n492ConfiguracaoNotificacoesEmail ;
      private int[] BC001V7_A491ConfiguracaoNotificacoesId ;
      private int[] BC001V10_A491ConfiguracaoNotificacoesId ;
      private string[] BC001V10_A492ConfiguracaoNotificacoesEmail ;
      private bool[] BC001V10_n492ConfiguracaoNotificacoesEmail ;
      private SdtConfiguracaoNotificacoes bcConfiguracaoNotificacoes ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class configuracaonotificacoes_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[5])
         ,new UpdateCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new ForEachCursor(def[8])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC001V2;
          prmBC001V2 = new Object[] {
          new ParDef("ConfiguracaoNotificacoesId",GXType.Int32,9,0)
          };
          Object[] prmBC001V3;
          prmBC001V3 = new Object[] {
          new ParDef("ConfiguracaoNotificacoesId",GXType.Int32,9,0)
          };
          Object[] prmBC001V4;
          prmBC001V4 = new Object[] {
          new ParDef("ConfiguracaoNotificacoesId",GXType.Int32,9,0)
          };
          Object[] prmBC001V5;
          prmBC001V5 = new Object[] {
          new ParDef("ConfiguracaoNotificacoesId",GXType.Int32,9,0)
          };
          Object[] prmBC001V6;
          prmBC001V6 = new Object[] {
          new ParDef("ConfiguracaoNotificacoesEmail",GXType.VarChar,100,0){Nullable=true}
          };
          Object[] prmBC001V7;
          prmBC001V7 = new Object[] {
          };
          Object[] prmBC001V8;
          prmBC001V8 = new Object[] {
          new ParDef("ConfiguracaoNotificacoesEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ConfiguracaoNotificacoesId",GXType.Int32,9,0)
          };
          Object[] prmBC001V9;
          prmBC001V9 = new Object[] {
          new ParDef("ConfiguracaoNotificacoesId",GXType.Int32,9,0)
          };
          Object[] prmBC001V10;
          prmBC001V10 = new Object[] {
          new ParDef("ConfiguracaoNotificacoesId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC001V2", "SELECT ConfiguracaoNotificacoesId, ConfiguracaoNotificacoesEmail FROM ConfiguracaoNotificacoes WHERE ConfiguracaoNotificacoesId = :ConfiguracaoNotificacoesId  FOR UPDATE OF ConfiguracaoNotificacoes",true, GxErrorMask.GX_NOMASK, false, this,prmBC001V2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001V3", "SELECT ConfiguracaoNotificacoesId, ConfiguracaoNotificacoesEmail FROM ConfiguracaoNotificacoes WHERE ConfiguracaoNotificacoesId = :ConfiguracaoNotificacoesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001V3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001V4", "SELECT TM1.ConfiguracaoNotificacoesId, TM1.ConfiguracaoNotificacoesEmail FROM ConfiguracaoNotificacoes TM1 WHERE TM1.ConfiguracaoNotificacoesId = :ConfiguracaoNotificacoesId ORDER BY TM1.ConfiguracaoNotificacoesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001V4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001V5", "SELECT ConfiguracaoNotificacoesId FROM ConfiguracaoNotificacoes WHERE ConfiguracaoNotificacoesId = :ConfiguracaoNotificacoesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001V5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001V6", "SAVEPOINT gxupdate;INSERT INTO ConfiguracaoNotificacoes(ConfiguracaoNotificacoesEmail) VALUES(:ConfiguracaoNotificacoesEmail);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001V6)
             ,new CursorDef("BC001V7", "SELECT currval('ConfiguracaoNotificacoesId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001V7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001V8", "SAVEPOINT gxupdate;UPDATE ConfiguracaoNotificacoes SET ConfiguracaoNotificacoesEmail=:ConfiguracaoNotificacoesEmail  WHERE ConfiguracaoNotificacoesId = :ConfiguracaoNotificacoesId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001V8)
             ,new CursorDef("BC001V9", "SAVEPOINT gxupdate;DELETE FROM ConfiguracaoNotificacoes  WHERE ConfiguracaoNotificacoesId = :ConfiguracaoNotificacoesId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001V9)
             ,new CursorDef("BC001V10", "SELECT TM1.ConfiguracaoNotificacoesId, TM1.ConfiguracaoNotificacoesEmail FROM ConfiguracaoNotificacoes TM1 WHERE TM1.ConfiguracaoNotificacoesId = :ConfiguracaoNotificacoesId ORDER BY TM1.ConfiguracaoNotificacoesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001V10,100, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
