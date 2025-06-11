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
   public class convenio_bc : GxSilentTrn, IGxSilentTrn
   {
      public convenio_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public convenio_bc( IGxContext context )
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
         ReadRow1N61( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1N61( ) ;
         standaloneModal( ) ;
         AddRow1N61( ) ;
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
            E111N2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z410ConvenioId = A410ConvenioId;
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

      protected void CONFIRM_1N0( )
      {
         BeforeValidate1N61( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1N61( ) ;
            }
            else
            {
               CheckExtendedTable1N61( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1N61( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E121N2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E111N2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1N61( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z411ConvenioDescricao = A411ConvenioDescricao;
            Z412ConvenioStatus = A412ConvenioStatus;
         }
         if ( GX_JID == -1 )
         {
            Z410ConvenioId = A410ConvenioId;
            Z411ConvenioDescricao = A411ConvenioDescricao;
            Z412ConvenioStatus = A412ConvenioStatus;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load1N61( )
      {
         /* Using cursor BC001N4 */
         pr_default.execute(2, new Object[] {n410ConvenioId, A410ConvenioId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound61 = 1;
            A411ConvenioDescricao = BC001N4_A411ConvenioDescricao[0];
            n411ConvenioDescricao = BC001N4_n411ConvenioDescricao[0];
            A412ConvenioStatus = BC001N4_A412ConvenioStatus[0];
            ZM1N61( -1) ;
         }
         pr_default.close(2);
         OnLoadActions1N61( ) ;
      }

      protected void OnLoadActions1N61( )
      {
      }

      protected void CheckExtendedTable1N61( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1N61( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1N61( )
      {
         /* Using cursor BC001N5 */
         pr_default.execute(3, new Object[] {n410ConvenioId, A410ConvenioId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound61 = 1;
         }
         else
         {
            RcdFound61 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001N3 */
         pr_default.execute(1, new Object[] {n410ConvenioId, A410ConvenioId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1N61( 1) ;
            RcdFound61 = 1;
            A410ConvenioId = BC001N3_A410ConvenioId[0];
            n410ConvenioId = BC001N3_n410ConvenioId[0];
            A411ConvenioDescricao = BC001N3_A411ConvenioDescricao[0];
            n411ConvenioDescricao = BC001N3_n411ConvenioDescricao[0];
            A412ConvenioStatus = BC001N3_A412ConvenioStatus[0];
            Z410ConvenioId = A410ConvenioId;
            sMode61 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1N61( ) ;
            if ( AnyError == 1 )
            {
               RcdFound61 = 0;
               InitializeNonKey1N61( ) ;
            }
            Gx_mode = sMode61;
         }
         else
         {
            RcdFound61 = 0;
            InitializeNonKey1N61( ) ;
            sMode61 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode61;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1N61( ) ;
         if ( RcdFound61 == 0 )
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
         CONFIRM_1N0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1N61( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001N2 */
            pr_default.execute(0, new Object[] {n410ConvenioId, A410ConvenioId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Convenio"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z411ConvenioDescricao, BC001N2_A411ConvenioDescricao[0]) != 0 ) || ( Z412ConvenioStatus != BC001N2_A412ConvenioStatus[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Convenio"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1N61( )
      {
         BeforeValidate1N61( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1N61( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1N61( 0) ;
            CheckOptimisticConcurrency1N61( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1N61( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1N61( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001N6 */
                     pr_default.execute(4, new Object[] {n411ConvenioDescricao, A411ConvenioDescricao, A412ConvenioStatus});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC001N7 */
                     pr_default.execute(5);
                     A410ConvenioId = BC001N7_A410ConvenioId[0];
                     n410ConvenioId = BC001N7_n410ConvenioId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Convenio");
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
               Load1N61( ) ;
            }
            EndLevel1N61( ) ;
         }
         CloseExtendedTableCursors1N61( ) ;
      }

      protected void Update1N61( )
      {
         BeforeValidate1N61( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1N61( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1N61( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1N61( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1N61( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001N8 */
                     pr_default.execute(6, new Object[] {n411ConvenioDescricao, A411ConvenioDescricao, A412ConvenioStatus, n410ConvenioId, A410ConvenioId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Convenio");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Convenio"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1N61( ) ;
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
            EndLevel1N61( ) ;
         }
         CloseExtendedTableCursors1N61( ) ;
      }

      protected void DeferredUpdate1N61( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1N61( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1N61( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1N61( ) ;
            AfterConfirm1N61( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1N61( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001N9 */
                  pr_default.execute(7, new Object[] {n410ConvenioId, A410ConvenioId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Convenio");
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
         sMode61 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1N61( ) ;
         Gx_mode = sMode61;
      }

      protected void OnDeleteControls1N61( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC001N10 */
            pr_default.execute(8, new Object[] {n410ConvenioId, A410ConvenioId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cliente"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
            /* Using cursor BC001N11 */
            pr_default.execute(9, new Object[] {n410ConvenioId, A410ConvenioId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ConvenioCategoria"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel1N61( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1N61( ) ;
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

      public void ScanKeyStart1N61( )
      {
         /* Scan By routine */
         /* Using cursor BC001N12 */
         pr_default.execute(10, new Object[] {n410ConvenioId, A410ConvenioId});
         RcdFound61 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound61 = 1;
            A410ConvenioId = BC001N12_A410ConvenioId[0];
            n410ConvenioId = BC001N12_n410ConvenioId[0];
            A411ConvenioDescricao = BC001N12_A411ConvenioDescricao[0];
            n411ConvenioDescricao = BC001N12_n411ConvenioDescricao[0];
            A412ConvenioStatus = BC001N12_A412ConvenioStatus[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1N61( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound61 = 0;
         ScanKeyLoad1N61( ) ;
      }

      protected void ScanKeyLoad1N61( )
      {
         sMode61 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound61 = 1;
            A410ConvenioId = BC001N12_A410ConvenioId[0];
            n410ConvenioId = BC001N12_n410ConvenioId[0];
            A411ConvenioDescricao = BC001N12_A411ConvenioDescricao[0];
            n411ConvenioDescricao = BC001N12_n411ConvenioDescricao[0];
            A412ConvenioStatus = BC001N12_A412ConvenioStatus[0];
         }
         Gx_mode = sMode61;
      }

      protected void ScanKeyEnd1N61( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm1N61( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1N61( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1N61( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1N61( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1N61( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1N61( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1N61( )
      {
      }

      protected void send_integrity_lvl_hashes1N61( )
      {
      }

      protected void AddRow1N61( )
      {
         VarsToRow61( bcConvenio) ;
      }

      protected void ReadRow1N61( )
      {
         RowToVars61( bcConvenio, 1) ;
      }

      protected void InitializeNonKey1N61( )
      {
         A411ConvenioDescricao = "";
         n411ConvenioDescricao = false;
         A412ConvenioStatus = false;
         Z411ConvenioDescricao = "";
         Z412ConvenioStatus = false;
      }

      protected void InitAll1N61( )
      {
         A410ConvenioId = 0;
         n410ConvenioId = false;
         InitializeNonKey1N61( ) ;
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

      public void VarsToRow61( SdtConvenio obj61 )
      {
         obj61.gxTpr_Mode = Gx_mode;
         obj61.gxTpr_Conveniodescricao = A411ConvenioDescricao;
         obj61.gxTpr_Conveniostatus = A412ConvenioStatus;
         obj61.gxTpr_Convenioid = A410ConvenioId;
         obj61.gxTpr_Convenioid_Z = Z410ConvenioId;
         obj61.gxTpr_Conveniodescricao_Z = Z411ConvenioDescricao;
         obj61.gxTpr_Conveniostatus_Z = Z412ConvenioStatus;
         obj61.gxTpr_Convenioid_N = (short)(Convert.ToInt16(n410ConvenioId));
         obj61.gxTpr_Conveniodescricao_N = (short)(Convert.ToInt16(n411ConvenioDescricao));
         obj61.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow61( SdtConvenio obj61 )
      {
         obj61.gxTpr_Convenioid = A410ConvenioId;
         return  ;
      }

      public void RowToVars61( SdtConvenio obj61 ,
                               int forceLoad )
      {
         Gx_mode = obj61.gxTpr_Mode;
         A411ConvenioDescricao = obj61.gxTpr_Conveniodescricao;
         n411ConvenioDescricao = false;
         A412ConvenioStatus = obj61.gxTpr_Conveniostatus;
         A410ConvenioId = obj61.gxTpr_Convenioid;
         n410ConvenioId = false;
         Z410ConvenioId = obj61.gxTpr_Convenioid_Z;
         Z411ConvenioDescricao = obj61.gxTpr_Conveniodescricao_Z;
         Z412ConvenioStatus = obj61.gxTpr_Conveniostatus_Z;
         n410ConvenioId = (bool)(Convert.ToBoolean(obj61.gxTpr_Convenioid_N));
         n411ConvenioDescricao = (bool)(Convert.ToBoolean(obj61.gxTpr_Conveniodescricao_N));
         Gx_mode = obj61.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A410ConvenioId = (int)getParm(obj,0);
         n410ConvenioId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1N61( ) ;
         ScanKeyStart1N61( ) ;
         if ( RcdFound61 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z410ConvenioId = A410ConvenioId;
         }
         ZM1N61( -1) ;
         OnLoadActions1N61( ) ;
         AddRow1N61( ) ;
         ScanKeyEnd1N61( ) ;
         if ( RcdFound61 == 0 )
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
         RowToVars61( bcConvenio, 0) ;
         ScanKeyStart1N61( ) ;
         if ( RcdFound61 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z410ConvenioId = A410ConvenioId;
         }
         ZM1N61( -1) ;
         OnLoadActions1N61( ) ;
         AddRow1N61( ) ;
         ScanKeyEnd1N61( ) ;
         if ( RcdFound61 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1N61( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1N61( ) ;
         }
         else
         {
            if ( RcdFound61 == 1 )
            {
               if ( A410ConvenioId != Z410ConvenioId )
               {
                  A410ConvenioId = Z410ConvenioId;
                  n410ConvenioId = false;
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
                  Update1N61( ) ;
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
                  if ( A410ConvenioId != Z410ConvenioId )
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
                        Insert1N61( ) ;
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
                        Insert1N61( ) ;
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
         RowToVars61( bcConvenio, 1) ;
         SaveImpl( ) ;
         VarsToRow61( bcConvenio) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars61( bcConvenio, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1N61( ) ;
         AfterTrn( ) ;
         VarsToRow61( bcConvenio) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow61( bcConvenio) ;
         }
         else
         {
            SdtConvenio auxBC = new SdtConvenio(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A410ConvenioId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcConvenio);
               auxBC.Save();
               bcConvenio.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars61( bcConvenio, 1) ;
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
         RowToVars61( bcConvenio, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1N61( ) ;
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
               VarsToRow61( bcConvenio) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow61( bcConvenio) ;
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
         RowToVars61( bcConvenio, 0) ;
         GetKey1N61( ) ;
         if ( RcdFound61 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A410ConvenioId != Z410ConvenioId )
            {
               A410ConvenioId = Z410ConvenioId;
               n410ConvenioId = false;
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
            if ( A410ConvenioId != Z410ConvenioId )
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
         context.RollbackDataStores("convenio_bc",pr_default);
         VarsToRow61( bcConvenio) ;
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
         Gx_mode = bcConvenio.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcConvenio.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcConvenio )
         {
            bcConvenio = (SdtConvenio)(sdt);
            if ( StringUtil.StrCmp(bcConvenio.gxTpr_Mode, "") == 0 )
            {
               bcConvenio.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow61( bcConvenio) ;
            }
            else
            {
               RowToVars61( bcConvenio, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcConvenio.gxTpr_Mode, "") == 0 )
            {
               bcConvenio.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars61( bcConvenio, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtConvenio Convenio_BC
      {
         get {
            return bcConvenio ;
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
         Z411ConvenioDescricao = "";
         A411ConvenioDescricao = "";
         BC001N4_A410ConvenioId = new int[1] ;
         BC001N4_n410ConvenioId = new bool[] {false} ;
         BC001N4_A411ConvenioDescricao = new string[] {""} ;
         BC001N4_n411ConvenioDescricao = new bool[] {false} ;
         BC001N4_A412ConvenioStatus = new bool[] {false} ;
         BC001N5_A410ConvenioId = new int[1] ;
         BC001N5_n410ConvenioId = new bool[] {false} ;
         BC001N3_A410ConvenioId = new int[1] ;
         BC001N3_n410ConvenioId = new bool[] {false} ;
         BC001N3_A411ConvenioDescricao = new string[] {""} ;
         BC001N3_n411ConvenioDescricao = new bool[] {false} ;
         BC001N3_A412ConvenioStatus = new bool[] {false} ;
         sMode61 = "";
         BC001N2_A410ConvenioId = new int[1] ;
         BC001N2_n410ConvenioId = new bool[] {false} ;
         BC001N2_A411ConvenioDescricao = new string[] {""} ;
         BC001N2_n411ConvenioDescricao = new bool[] {false} ;
         BC001N2_A412ConvenioStatus = new bool[] {false} ;
         BC001N7_A410ConvenioId = new int[1] ;
         BC001N7_n410ConvenioId = new bool[] {false} ;
         BC001N10_A168ClienteId = new int[1] ;
         BC001N11_A493ConvenioCategoriaId = new int[1] ;
         BC001N12_A410ConvenioId = new int[1] ;
         BC001N12_n410ConvenioId = new bool[] {false} ;
         BC001N12_A411ConvenioDescricao = new string[] {""} ;
         BC001N12_n411ConvenioDescricao = new bool[] {false} ;
         BC001N12_A412ConvenioStatus = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.convenio_bc__default(),
            new Object[][] {
                new Object[] {
               BC001N2_A410ConvenioId, BC001N2_A411ConvenioDescricao, BC001N2_n411ConvenioDescricao, BC001N2_A412ConvenioStatus
               }
               , new Object[] {
               BC001N3_A410ConvenioId, BC001N3_A411ConvenioDescricao, BC001N3_n411ConvenioDescricao, BC001N3_A412ConvenioStatus
               }
               , new Object[] {
               BC001N4_A410ConvenioId, BC001N4_A411ConvenioDescricao, BC001N4_n411ConvenioDescricao, BC001N4_A412ConvenioStatus
               }
               , new Object[] {
               BC001N5_A410ConvenioId
               }
               , new Object[] {
               }
               , new Object[] {
               BC001N7_A410ConvenioId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001N10_A168ClienteId
               }
               , new Object[] {
               BC001N11_A493ConvenioCategoriaId
               }
               , new Object[] {
               BC001N12_A410ConvenioId, BC001N12_A411ConvenioDescricao, BC001N12_n411ConvenioDescricao, BC001N12_A412ConvenioStatus
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121N2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound61 ;
      private int trnEnded ;
      private int Z410ConvenioId ;
      private int A410ConvenioId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode61 ;
      private bool returnInSub ;
      private bool Z412ConvenioStatus ;
      private bool A412ConvenioStatus ;
      private bool n410ConvenioId ;
      private bool n411ConvenioDescricao ;
      private string Z411ConvenioDescricao ;
      private string A411ConvenioDescricao ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private int[] BC001N4_A410ConvenioId ;
      private bool[] BC001N4_n410ConvenioId ;
      private string[] BC001N4_A411ConvenioDescricao ;
      private bool[] BC001N4_n411ConvenioDescricao ;
      private bool[] BC001N4_A412ConvenioStatus ;
      private int[] BC001N5_A410ConvenioId ;
      private bool[] BC001N5_n410ConvenioId ;
      private int[] BC001N3_A410ConvenioId ;
      private bool[] BC001N3_n410ConvenioId ;
      private string[] BC001N3_A411ConvenioDescricao ;
      private bool[] BC001N3_n411ConvenioDescricao ;
      private bool[] BC001N3_A412ConvenioStatus ;
      private int[] BC001N2_A410ConvenioId ;
      private bool[] BC001N2_n410ConvenioId ;
      private string[] BC001N2_A411ConvenioDescricao ;
      private bool[] BC001N2_n411ConvenioDescricao ;
      private bool[] BC001N2_A412ConvenioStatus ;
      private int[] BC001N7_A410ConvenioId ;
      private bool[] BC001N7_n410ConvenioId ;
      private int[] BC001N10_A168ClienteId ;
      private int[] BC001N11_A493ConvenioCategoriaId ;
      private int[] BC001N12_A410ConvenioId ;
      private bool[] BC001N12_n410ConvenioId ;
      private string[] BC001N12_A411ConvenioDescricao ;
      private bool[] BC001N12_n411ConvenioDescricao ;
      private bool[] BC001N12_A412ConvenioStatus ;
      private SdtConvenio bcConvenio ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class convenio_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC001N2;
          prmBC001N2 = new Object[] {
          new ParDef("ConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001N3;
          prmBC001N3 = new Object[] {
          new ParDef("ConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001N4;
          prmBC001N4 = new Object[] {
          new ParDef("ConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001N5;
          prmBC001N5 = new Object[] {
          new ParDef("ConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001N6;
          prmBC001N6 = new Object[] {
          new ParDef("ConvenioDescricao",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ConvenioStatus",GXType.Boolean,4,0)
          };
          Object[] prmBC001N7;
          prmBC001N7 = new Object[] {
          };
          Object[] prmBC001N8;
          prmBC001N8 = new Object[] {
          new ParDef("ConvenioDescricao",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ConvenioStatus",GXType.Boolean,4,0) ,
          new ParDef("ConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001N9;
          prmBC001N9 = new Object[] {
          new ParDef("ConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001N10;
          prmBC001N10 = new Object[] {
          new ParDef("ConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001N11;
          prmBC001N11 = new Object[] {
          new ParDef("ConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001N12;
          prmBC001N12 = new Object[] {
          new ParDef("ConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC001N2", "SELECT ConvenioId, ConvenioDescricao, ConvenioStatus FROM Convenio WHERE ConvenioId = :ConvenioId  FOR UPDATE OF Convenio",true, GxErrorMask.GX_NOMASK, false, this,prmBC001N2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001N3", "SELECT ConvenioId, ConvenioDescricao, ConvenioStatus FROM Convenio WHERE ConvenioId = :ConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001N3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001N4", "SELECT TM1.ConvenioId, TM1.ConvenioDescricao, TM1.ConvenioStatus FROM Convenio TM1 WHERE TM1.ConvenioId = :ConvenioId ORDER BY TM1.ConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001N4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001N5", "SELECT ConvenioId FROM Convenio WHERE ConvenioId = :ConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001N5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001N6", "SAVEPOINT gxupdate;INSERT INTO Convenio(ConvenioDescricao, ConvenioStatus) VALUES(:ConvenioDescricao, :ConvenioStatus);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001N6)
             ,new CursorDef("BC001N7", "SELECT currval('ConvenioId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001N7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001N8", "SAVEPOINT gxupdate;UPDATE Convenio SET ConvenioDescricao=:ConvenioDescricao, ConvenioStatus=:ConvenioStatus  WHERE ConvenioId = :ConvenioId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001N8)
             ,new CursorDef("BC001N9", "SAVEPOINT gxupdate;DELETE FROM Convenio  WHERE ConvenioId = :ConvenioId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001N9)
             ,new CursorDef("BC001N10", "SELECT ClienteId FROM Cliente WHERE ClienteConvenio = :ConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001N10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001N11", "SELECT ConvenioCategoriaId FROM ConvenioCategoria WHERE ConvenioId = :ConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001N11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001N12", "SELECT TM1.ConvenioId, TM1.ConvenioDescricao, TM1.ConvenioStatus FROM Convenio TM1 WHERE TM1.ConvenioId = :ConvenioId ORDER BY TM1.ConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001N12,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
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
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                return;
       }
    }

 }

}
