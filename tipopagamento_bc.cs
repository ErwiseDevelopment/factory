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
   public class tipopagamento_bc : GxSilentTrn, IGxSilentTrn
   {
      public tipopagamento_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public tipopagamento_bc( IGxContext context )
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
         ReadRow1746( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1746( ) ;
         standaloneModal( ) ;
         AddRow1746( ) ;
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
            E11172 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z288TipoPagamentoId = A288TipoPagamentoId;
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

      protected void CONFIRM_170( )
      {
         BeforeValidate1746( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1746( ) ;
            }
            else
            {
               CheckExtendedTable1746( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1746( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12172( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E11172( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1746( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z289TipoPagamentoNome = A289TipoPagamentoNome;
         }
         if ( GX_JID == -1 )
         {
            Z288TipoPagamentoId = A288TipoPagamentoId;
            Z289TipoPagamentoNome = A289TipoPagamentoNome;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load1746( )
      {
         /* Using cursor BC00174 */
         pr_default.execute(2, new Object[] {n288TipoPagamentoId, A288TipoPagamentoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound46 = 1;
            A289TipoPagamentoNome = BC00174_A289TipoPagamentoNome[0];
            ZM1746( -1) ;
         }
         pr_default.close(2);
         OnLoadActions1746( ) ;
      }

      protected void OnLoadActions1746( )
      {
      }

      protected void CheckExtendedTable1746( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1746( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1746( )
      {
         /* Using cursor BC00175 */
         pr_default.execute(3, new Object[] {n288TipoPagamentoId, A288TipoPagamentoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound46 = 1;
         }
         else
         {
            RcdFound46 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00173 */
         pr_default.execute(1, new Object[] {n288TipoPagamentoId, A288TipoPagamentoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1746( 1) ;
            RcdFound46 = 1;
            A288TipoPagamentoId = BC00173_A288TipoPagamentoId[0];
            n288TipoPagamentoId = BC00173_n288TipoPagamentoId[0];
            A289TipoPagamentoNome = BC00173_A289TipoPagamentoNome[0];
            Z288TipoPagamentoId = A288TipoPagamentoId;
            sMode46 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1746( ) ;
            if ( AnyError == 1 )
            {
               RcdFound46 = 0;
               InitializeNonKey1746( ) ;
            }
            Gx_mode = sMode46;
         }
         else
         {
            RcdFound46 = 0;
            InitializeNonKey1746( ) ;
            sMode46 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode46;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1746( ) ;
         if ( RcdFound46 == 0 )
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
         CONFIRM_170( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1746( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00172 */
            pr_default.execute(0, new Object[] {n288TipoPagamentoId, A288TipoPagamentoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TipoPagamento"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z289TipoPagamentoNome, BC00172_A289TipoPagamentoNome[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TipoPagamento"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1746( )
      {
         BeforeValidate1746( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1746( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1746( 0) ;
            CheckOptimisticConcurrency1746( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1746( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1746( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00176 */
                     pr_default.execute(4, new Object[] {A289TipoPagamentoNome});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC00177 */
                     pr_default.execute(5);
                     A288TipoPagamentoId = BC00177_A288TipoPagamentoId[0];
                     n288TipoPagamentoId = BC00177_n288TipoPagamentoId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("TipoPagamento");
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
               Load1746( ) ;
            }
            EndLevel1746( ) ;
         }
         CloseExtendedTableCursors1746( ) ;
      }

      protected void Update1746( )
      {
         BeforeValidate1746( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1746( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1746( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1746( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1746( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00178 */
                     pr_default.execute(6, new Object[] {A289TipoPagamentoNome, n288TipoPagamentoId, A288TipoPagamentoId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("TipoPagamento");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TipoPagamento"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1746( ) ;
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
            EndLevel1746( ) ;
         }
         CloseExtendedTableCursors1746( ) ;
      }

      protected void DeferredUpdate1746( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1746( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1746( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1746( ) ;
            AfterConfirm1746( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1746( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00179 */
                  pr_default.execute(7, new Object[] {n288TipoPagamentoId, A288TipoPagamentoId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("TipoPagamento");
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
         sMode46 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1746( ) ;
         Gx_mode = sMode46;
      }

      protected void OnDeleteControls1746( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC001710 */
            pr_default.execute(8, new Object[] {n288TipoPagamentoId, A288TipoPagamentoId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"TituloMovimento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
         }
      }

      protected void EndLevel1746( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1746( ) ;
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

      public void ScanKeyStart1746( )
      {
         /* Scan By routine */
         /* Using cursor BC001711 */
         pr_default.execute(9, new Object[] {n288TipoPagamentoId, A288TipoPagamentoId});
         RcdFound46 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound46 = 1;
            A288TipoPagamentoId = BC001711_A288TipoPagamentoId[0];
            n288TipoPagamentoId = BC001711_n288TipoPagamentoId[0];
            A289TipoPagamentoNome = BC001711_A289TipoPagamentoNome[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1746( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound46 = 0;
         ScanKeyLoad1746( ) ;
      }

      protected void ScanKeyLoad1746( )
      {
         sMode46 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound46 = 1;
            A288TipoPagamentoId = BC001711_A288TipoPagamentoId[0];
            n288TipoPagamentoId = BC001711_n288TipoPagamentoId[0];
            A289TipoPagamentoNome = BC001711_A289TipoPagamentoNome[0];
         }
         Gx_mode = sMode46;
      }

      protected void ScanKeyEnd1746( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm1746( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1746( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1746( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1746( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1746( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1746( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1746( )
      {
      }

      protected void send_integrity_lvl_hashes1746( )
      {
      }

      protected void AddRow1746( )
      {
         VarsToRow46( bcTipoPagamento) ;
      }

      protected void ReadRow1746( )
      {
         RowToVars46( bcTipoPagamento, 1) ;
      }

      protected void InitializeNonKey1746( )
      {
         A289TipoPagamentoNome = "";
         Z289TipoPagamentoNome = "";
      }

      protected void InitAll1746( )
      {
         A288TipoPagamentoId = 0;
         n288TipoPagamentoId = false;
         InitializeNonKey1746( ) ;
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

      public void VarsToRow46( SdtTipoPagamento obj46 )
      {
         obj46.gxTpr_Mode = Gx_mode;
         obj46.gxTpr_Tipopagamentonome = A289TipoPagamentoNome;
         obj46.gxTpr_Tipopagamentoid = A288TipoPagamentoId;
         obj46.gxTpr_Tipopagamentoid_Z = Z288TipoPagamentoId;
         obj46.gxTpr_Tipopagamentonome_Z = Z289TipoPagamentoNome;
         obj46.gxTpr_Tipopagamentoid_N = (short)(Convert.ToInt16(n288TipoPagamentoId));
         obj46.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow46( SdtTipoPagamento obj46 )
      {
         obj46.gxTpr_Tipopagamentoid = A288TipoPagamentoId;
         return  ;
      }

      public void RowToVars46( SdtTipoPagamento obj46 ,
                               int forceLoad )
      {
         Gx_mode = obj46.gxTpr_Mode;
         A289TipoPagamentoNome = obj46.gxTpr_Tipopagamentonome;
         A288TipoPagamentoId = obj46.gxTpr_Tipopagamentoid;
         n288TipoPagamentoId = false;
         Z288TipoPagamentoId = obj46.gxTpr_Tipopagamentoid_Z;
         Z289TipoPagamentoNome = obj46.gxTpr_Tipopagamentonome_Z;
         n288TipoPagamentoId = (bool)(Convert.ToBoolean(obj46.gxTpr_Tipopagamentoid_N));
         Gx_mode = obj46.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A288TipoPagamentoId = (int)getParm(obj,0);
         n288TipoPagamentoId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1746( ) ;
         ScanKeyStart1746( ) ;
         if ( RcdFound46 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z288TipoPagamentoId = A288TipoPagamentoId;
         }
         ZM1746( -1) ;
         OnLoadActions1746( ) ;
         AddRow1746( ) ;
         ScanKeyEnd1746( ) ;
         if ( RcdFound46 == 0 )
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
         RowToVars46( bcTipoPagamento, 0) ;
         ScanKeyStart1746( ) ;
         if ( RcdFound46 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z288TipoPagamentoId = A288TipoPagamentoId;
         }
         ZM1746( -1) ;
         OnLoadActions1746( ) ;
         AddRow1746( ) ;
         ScanKeyEnd1746( ) ;
         if ( RcdFound46 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1746( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1746( ) ;
         }
         else
         {
            if ( RcdFound46 == 1 )
            {
               if ( A288TipoPagamentoId != Z288TipoPagamentoId )
               {
                  A288TipoPagamentoId = Z288TipoPagamentoId;
                  n288TipoPagamentoId = false;
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
                  Update1746( ) ;
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
                  if ( A288TipoPagamentoId != Z288TipoPagamentoId )
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
                        Insert1746( ) ;
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
                        Insert1746( ) ;
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
         RowToVars46( bcTipoPagamento, 1) ;
         SaveImpl( ) ;
         VarsToRow46( bcTipoPagamento) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars46( bcTipoPagamento, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1746( ) ;
         AfterTrn( ) ;
         VarsToRow46( bcTipoPagamento) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow46( bcTipoPagamento) ;
         }
         else
         {
            SdtTipoPagamento auxBC = new SdtTipoPagamento(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A288TipoPagamentoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTipoPagamento);
               auxBC.Save();
               bcTipoPagamento.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars46( bcTipoPagamento, 1) ;
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
         RowToVars46( bcTipoPagamento, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1746( ) ;
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
               VarsToRow46( bcTipoPagamento) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow46( bcTipoPagamento) ;
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
         RowToVars46( bcTipoPagamento, 0) ;
         GetKey1746( ) ;
         if ( RcdFound46 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A288TipoPagamentoId != Z288TipoPagamentoId )
            {
               A288TipoPagamentoId = Z288TipoPagamentoId;
               n288TipoPagamentoId = false;
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
            if ( A288TipoPagamentoId != Z288TipoPagamentoId )
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
         context.RollbackDataStores("tipopagamento_bc",pr_default);
         VarsToRow46( bcTipoPagamento) ;
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
         Gx_mode = bcTipoPagamento.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTipoPagamento.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTipoPagamento )
         {
            bcTipoPagamento = (SdtTipoPagamento)(sdt);
            if ( StringUtil.StrCmp(bcTipoPagamento.gxTpr_Mode, "") == 0 )
            {
               bcTipoPagamento.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow46( bcTipoPagamento) ;
            }
            else
            {
               RowToVars46( bcTipoPagamento, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTipoPagamento.gxTpr_Mode, "") == 0 )
            {
               bcTipoPagamento.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars46( bcTipoPagamento, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTipoPagamento TipoPagamento_BC
      {
         get {
            return bcTipoPagamento ;
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
         Z289TipoPagamentoNome = "";
         A289TipoPagamentoNome = "";
         BC00174_A288TipoPagamentoId = new int[1] ;
         BC00174_n288TipoPagamentoId = new bool[] {false} ;
         BC00174_A289TipoPagamentoNome = new string[] {""} ;
         BC00175_A288TipoPagamentoId = new int[1] ;
         BC00175_n288TipoPagamentoId = new bool[] {false} ;
         BC00173_A288TipoPagamentoId = new int[1] ;
         BC00173_n288TipoPagamentoId = new bool[] {false} ;
         BC00173_A289TipoPagamentoNome = new string[] {""} ;
         sMode46 = "";
         BC00172_A288TipoPagamentoId = new int[1] ;
         BC00172_n288TipoPagamentoId = new bool[] {false} ;
         BC00172_A289TipoPagamentoNome = new string[] {""} ;
         BC00177_A288TipoPagamentoId = new int[1] ;
         BC00177_n288TipoPagamentoId = new bool[] {false} ;
         BC001710_A270TituloMovimentoId = new int[1] ;
         BC001711_A288TipoPagamentoId = new int[1] ;
         BC001711_n288TipoPagamentoId = new bool[] {false} ;
         BC001711_A289TipoPagamentoNome = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tipopagamento_bc__default(),
            new Object[][] {
                new Object[] {
               BC00172_A288TipoPagamentoId, BC00172_A289TipoPagamentoNome
               }
               , new Object[] {
               BC00173_A288TipoPagamentoId, BC00173_A289TipoPagamentoNome
               }
               , new Object[] {
               BC00174_A288TipoPagamentoId, BC00174_A289TipoPagamentoNome
               }
               , new Object[] {
               BC00175_A288TipoPagamentoId
               }
               , new Object[] {
               }
               , new Object[] {
               BC00177_A288TipoPagamentoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001710_A270TituloMovimentoId
               }
               , new Object[] {
               BC001711_A288TipoPagamentoId, BC001711_A289TipoPagamentoNome
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12172 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound46 ;
      private int trnEnded ;
      private int Z288TipoPagamentoId ;
      private int A288TipoPagamentoId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode46 ;
      private bool returnInSub ;
      private bool n288TipoPagamentoId ;
      private string Z289TipoPagamentoNome ;
      private string A289TipoPagamentoNome ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private int[] BC00174_A288TipoPagamentoId ;
      private bool[] BC00174_n288TipoPagamentoId ;
      private string[] BC00174_A289TipoPagamentoNome ;
      private int[] BC00175_A288TipoPagamentoId ;
      private bool[] BC00175_n288TipoPagamentoId ;
      private int[] BC00173_A288TipoPagamentoId ;
      private bool[] BC00173_n288TipoPagamentoId ;
      private string[] BC00173_A289TipoPagamentoNome ;
      private int[] BC00172_A288TipoPagamentoId ;
      private bool[] BC00172_n288TipoPagamentoId ;
      private string[] BC00172_A289TipoPagamentoNome ;
      private int[] BC00177_A288TipoPagamentoId ;
      private bool[] BC00177_n288TipoPagamentoId ;
      private int[] BC001710_A270TituloMovimentoId ;
      private int[] BC001711_A288TipoPagamentoId ;
      private bool[] BC001711_n288TipoPagamentoId ;
      private string[] BC001711_A289TipoPagamentoNome ;
      private SdtTipoPagamento bcTipoPagamento ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class tipopagamento_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[9])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00172;
          prmBC00172 = new Object[] {
          new ParDef("TipoPagamentoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00173;
          prmBC00173 = new Object[] {
          new ParDef("TipoPagamentoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00174;
          prmBC00174 = new Object[] {
          new ParDef("TipoPagamentoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00175;
          prmBC00175 = new Object[] {
          new ParDef("TipoPagamentoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00176;
          prmBC00176 = new Object[] {
          new ParDef("TipoPagamentoNome",GXType.VarChar,60,0)
          };
          Object[] prmBC00177;
          prmBC00177 = new Object[] {
          };
          Object[] prmBC00178;
          prmBC00178 = new Object[] {
          new ParDef("TipoPagamentoNome",GXType.VarChar,60,0) ,
          new ParDef("TipoPagamentoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00179;
          prmBC00179 = new Object[] {
          new ParDef("TipoPagamentoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001710;
          prmBC001710 = new Object[] {
          new ParDef("TipoPagamentoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001711;
          prmBC001711 = new Object[] {
          new ParDef("TipoPagamentoId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC00172", "SELECT TipoPagamentoId, TipoPagamentoNome FROM TipoPagamento WHERE TipoPagamentoId = :TipoPagamentoId  FOR UPDATE OF TipoPagamento",true, GxErrorMask.GX_NOMASK, false, this,prmBC00172,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00173", "SELECT TipoPagamentoId, TipoPagamentoNome FROM TipoPagamento WHERE TipoPagamentoId = :TipoPagamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00173,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00174", "SELECT TM1.TipoPagamentoId, TM1.TipoPagamentoNome FROM TipoPagamento TM1 WHERE TM1.TipoPagamentoId = :TipoPagamentoId ORDER BY TM1.TipoPagamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00174,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00175", "SELECT TipoPagamentoId FROM TipoPagamento WHERE TipoPagamentoId = :TipoPagamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00175,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00176", "SAVEPOINT gxupdate;INSERT INTO TipoPagamento(TipoPagamentoNome) VALUES(:TipoPagamentoNome);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00176)
             ,new CursorDef("BC00177", "SELECT currval('TipoPagamentoId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00177,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00178", "SAVEPOINT gxupdate;UPDATE TipoPagamento SET TipoPagamentoNome=:TipoPagamentoNome  WHERE TipoPagamentoId = :TipoPagamentoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00178)
             ,new CursorDef("BC00179", "SAVEPOINT gxupdate;DELETE FROM TipoPagamento  WHERE TipoPagamentoId = :TipoPagamentoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00179)
             ,new CursorDef("BC001710", "SELECT TituloMovimentoId FROM TituloMovimento WHERE TipoPagamentoId = :TipoPagamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001710,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001711", "SELECT TM1.TipoPagamentoId, TM1.TipoPagamentoNome FROM TipoPagamento TM1 WHERE TM1.TipoPagamentoId = :TipoPagamentoId ORDER BY TM1.TipoPagamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001711,100, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
