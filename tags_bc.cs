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
   public class tags_bc : GxSilentTrn, IGxSilentTrn
   {
      public tags_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public tags_bc( IGxContext context )
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
         ReadRow1E53( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1E53( ) ;
         standaloneModal( ) ;
         AddRow1E53( ) ;
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
            E111E2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z372TagsId = A372TagsId;
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

      protected void CONFIRM_1E0( )
      {
         BeforeValidate1E53( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1E53( ) ;
            }
            else
            {
               CheckExtendedTable1E53( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1E53( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E121E2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E111E2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1E53( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z373TagsDescricao = A373TagsDescricao;
            Z374TagsConteudo = A374TagsConteudo;
         }
         if ( GX_JID == -1 )
         {
            Z372TagsId = A372TagsId;
            Z373TagsDescricao = A373TagsDescricao;
            Z374TagsConteudo = A374TagsConteudo;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load1E53( )
      {
         /* Using cursor BC001E4 */
         pr_default.execute(2, new Object[] {A372TagsId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound53 = 1;
            A373TagsDescricao = BC001E4_A373TagsDescricao[0];
            n373TagsDescricao = BC001E4_n373TagsDescricao[0];
            A374TagsConteudo = BC001E4_A374TagsConteudo[0];
            n374TagsConteudo = BC001E4_n374TagsConteudo[0];
            ZM1E53( -1) ;
         }
         pr_default.close(2);
         OnLoadActions1E53( ) ;
      }

      protected void OnLoadActions1E53( )
      {
      }

      protected void CheckExtendedTable1E53( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1E53( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1E53( )
      {
         /* Using cursor BC001E5 */
         pr_default.execute(3, new Object[] {A372TagsId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound53 = 1;
         }
         else
         {
            RcdFound53 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001E3 */
         pr_default.execute(1, new Object[] {A372TagsId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1E53( 1) ;
            RcdFound53 = 1;
            A372TagsId = BC001E3_A372TagsId[0];
            A373TagsDescricao = BC001E3_A373TagsDescricao[0];
            n373TagsDescricao = BC001E3_n373TagsDescricao[0];
            A374TagsConteudo = BC001E3_A374TagsConteudo[0];
            n374TagsConteudo = BC001E3_n374TagsConteudo[0];
            Z372TagsId = A372TagsId;
            sMode53 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1E53( ) ;
            if ( AnyError == 1 )
            {
               RcdFound53 = 0;
               InitializeNonKey1E53( ) ;
            }
            Gx_mode = sMode53;
         }
         else
         {
            RcdFound53 = 0;
            InitializeNonKey1E53( ) ;
            sMode53 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode53;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1E53( ) ;
         if ( RcdFound53 == 0 )
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
         CONFIRM_1E0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1E53( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001E2 */
            pr_default.execute(0, new Object[] {A372TagsId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Tags"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z373TagsDescricao, BC001E2_A373TagsDescricao[0]) != 0 ) || ( StringUtil.StrCmp(Z374TagsConteudo, BC001E2_A374TagsConteudo[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Tags"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1E53( )
      {
         BeforeValidate1E53( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1E53( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1E53( 0) ;
            CheckOptimisticConcurrency1E53( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1E53( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1E53( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001E6 */
                     pr_default.execute(4, new Object[] {n373TagsDescricao, A373TagsDescricao, n374TagsConteudo, A374TagsConteudo});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC001E7 */
                     pr_default.execute(5);
                     A372TagsId = BC001E7_A372TagsId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Tags");
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
               Load1E53( ) ;
            }
            EndLevel1E53( ) ;
         }
         CloseExtendedTableCursors1E53( ) ;
      }

      protected void Update1E53( )
      {
         BeforeValidate1E53( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1E53( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1E53( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1E53( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1E53( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001E8 */
                     pr_default.execute(6, new Object[] {n373TagsDescricao, A373TagsDescricao, n374TagsConteudo, A374TagsConteudo, A372TagsId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Tags");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Tags"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1E53( ) ;
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
            EndLevel1E53( ) ;
         }
         CloseExtendedTableCursors1E53( ) ;
      }

      protected void DeferredUpdate1E53( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1E53( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1E53( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1E53( ) ;
            AfterConfirm1E53( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1E53( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001E9 */
                  pr_default.execute(7, new Object[] {A372TagsId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Tags");
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
         sMode53 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1E53( ) ;
         Gx_mode = sMode53;
      }

      protected void OnDeleteControls1E53( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1E53( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1E53( ) ;
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

      public void ScanKeyStart1E53( )
      {
         /* Scan By routine */
         /* Using cursor BC001E10 */
         pr_default.execute(8, new Object[] {A372TagsId});
         RcdFound53 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound53 = 1;
            A372TagsId = BC001E10_A372TagsId[0];
            A373TagsDescricao = BC001E10_A373TagsDescricao[0];
            n373TagsDescricao = BC001E10_n373TagsDescricao[0];
            A374TagsConteudo = BC001E10_A374TagsConteudo[0];
            n374TagsConteudo = BC001E10_n374TagsConteudo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1E53( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound53 = 0;
         ScanKeyLoad1E53( ) ;
      }

      protected void ScanKeyLoad1E53( )
      {
         sMode53 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound53 = 1;
            A372TagsId = BC001E10_A372TagsId[0];
            A373TagsDescricao = BC001E10_A373TagsDescricao[0];
            n373TagsDescricao = BC001E10_n373TagsDescricao[0];
            A374TagsConteudo = BC001E10_A374TagsConteudo[0];
            n374TagsConteudo = BC001E10_n374TagsConteudo[0];
         }
         Gx_mode = sMode53;
      }

      protected void ScanKeyEnd1E53( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm1E53( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1E53( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1E53( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1E53( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1E53( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1E53( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1E53( )
      {
      }

      protected void send_integrity_lvl_hashes1E53( )
      {
      }

      protected void AddRow1E53( )
      {
         VarsToRow53( bcTags) ;
      }

      protected void ReadRow1E53( )
      {
         RowToVars53( bcTags, 1) ;
      }

      protected void InitializeNonKey1E53( )
      {
         A373TagsDescricao = "";
         n373TagsDescricao = false;
         A374TagsConteudo = "";
         n374TagsConteudo = false;
         Z373TagsDescricao = "";
         Z374TagsConteudo = "";
      }

      protected void InitAll1E53( )
      {
         A372TagsId = 0;
         InitializeNonKey1E53( ) ;
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

      public void VarsToRow53( SdtTags obj53 )
      {
         obj53.gxTpr_Mode = Gx_mode;
         obj53.gxTpr_Tagsdescricao = A373TagsDescricao;
         obj53.gxTpr_Tagsconteudo = A374TagsConteudo;
         obj53.gxTpr_Tagsid = A372TagsId;
         obj53.gxTpr_Tagsid_Z = Z372TagsId;
         obj53.gxTpr_Tagsdescricao_Z = Z373TagsDescricao;
         obj53.gxTpr_Tagsconteudo_Z = Z374TagsConteudo;
         obj53.gxTpr_Tagsdescricao_N = (short)(Convert.ToInt16(n373TagsDescricao));
         obj53.gxTpr_Tagsconteudo_N = (short)(Convert.ToInt16(n374TagsConteudo));
         obj53.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow53( SdtTags obj53 )
      {
         obj53.gxTpr_Tagsid = A372TagsId;
         return  ;
      }

      public void RowToVars53( SdtTags obj53 ,
                               int forceLoad )
      {
         Gx_mode = obj53.gxTpr_Mode;
         A373TagsDescricao = obj53.gxTpr_Tagsdescricao;
         n373TagsDescricao = false;
         A374TagsConteudo = obj53.gxTpr_Tagsconteudo;
         n374TagsConteudo = false;
         A372TagsId = obj53.gxTpr_Tagsid;
         Z372TagsId = obj53.gxTpr_Tagsid_Z;
         Z373TagsDescricao = obj53.gxTpr_Tagsdescricao_Z;
         Z374TagsConteudo = obj53.gxTpr_Tagsconteudo_Z;
         n373TagsDescricao = (bool)(Convert.ToBoolean(obj53.gxTpr_Tagsdescricao_N));
         n374TagsConteudo = (bool)(Convert.ToBoolean(obj53.gxTpr_Tagsconteudo_N));
         Gx_mode = obj53.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A372TagsId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1E53( ) ;
         ScanKeyStart1E53( ) ;
         if ( RcdFound53 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z372TagsId = A372TagsId;
         }
         ZM1E53( -1) ;
         OnLoadActions1E53( ) ;
         AddRow1E53( ) ;
         ScanKeyEnd1E53( ) ;
         if ( RcdFound53 == 0 )
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
         RowToVars53( bcTags, 0) ;
         ScanKeyStart1E53( ) ;
         if ( RcdFound53 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z372TagsId = A372TagsId;
         }
         ZM1E53( -1) ;
         OnLoadActions1E53( ) ;
         AddRow1E53( ) ;
         ScanKeyEnd1E53( ) ;
         if ( RcdFound53 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1E53( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1E53( ) ;
         }
         else
         {
            if ( RcdFound53 == 1 )
            {
               if ( A372TagsId != Z372TagsId )
               {
                  A372TagsId = Z372TagsId;
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
                  Update1E53( ) ;
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
                  if ( A372TagsId != Z372TagsId )
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
                        Insert1E53( ) ;
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
                        Insert1E53( ) ;
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
         RowToVars53( bcTags, 1) ;
         SaveImpl( ) ;
         VarsToRow53( bcTags) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars53( bcTags, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1E53( ) ;
         AfterTrn( ) ;
         VarsToRow53( bcTags) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow53( bcTags) ;
         }
         else
         {
            SdtTags auxBC = new SdtTags(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A372TagsId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTags);
               auxBC.Save();
               bcTags.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars53( bcTags, 1) ;
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
         RowToVars53( bcTags, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1E53( ) ;
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
               VarsToRow53( bcTags) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow53( bcTags) ;
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
         RowToVars53( bcTags, 0) ;
         GetKey1E53( ) ;
         if ( RcdFound53 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A372TagsId != Z372TagsId )
            {
               A372TagsId = Z372TagsId;
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
            if ( A372TagsId != Z372TagsId )
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
         context.RollbackDataStores("tags_bc",pr_default);
         VarsToRow53( bcTags) ;
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
         Gx_mode = bcTags.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTags.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTags )
         {
            bcTags = (SdtTags)(sdt);
            if ( StringUtil.StrCmp(bcTags.gxTpr_Mode, "") == 0 )
            {
               bcTags.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow53( bcTags) ;
            }
            else
            {
               RowToVars53( bcTags, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTags.gxTpr_Mode, "") == 0 )
            {
               bcTags.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars53( bcTags, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTags Tags_BC
      {
         get {
            return bcTags ;
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
         Z373TagsDescricao = "";
         A373TagsDescricao = "";
         Z374TagsConteudo = "";
         A374TagsConteudo = "";
         BC001E4_A372TagsId = new int[1] ;
         BC001E4_A373TagsDescricao = new string[] {""} ;
         BC001E4_n373TagsDescricao = new bool[] {false} ;
         BC001E4_A374TagsConteudo = new string[] {""} ;
         BC001E4_n374TagsConteudo = new bool[] {false} ;
         BC001E5_A372TagsId = new int[1] ;
         BC001E3_A372TagsId = new int[1] ;
         BC001E3_A373TagsDescricao = new string[] {""} ;
         BC001E3_n373TagsDescricao = new bool[] {false} ;
         BC001E3_A374TagsConteudo = new string[] {""} ;
         BC001E3_n374TagsConteudo = new bool[] {false} ;
         sMode53 = "";
         BC001E2_A372TagsId = new int[1] ;
         BC001E2_A373TagsDescricao = new string[] {""} ;
         BC001E2_n373TagsDescricao = new bool[] {false} ;
         BC001E2_A374TagsConteudo = new string[] {""} ;
         BC001E2_n374TagsConteudo = new bool[] {false} ;
         BC001E7_A372TagsId = new int[1] ;
         BC001E10_A372TagsId = new int[1] ;
         BC001E10_A373TagsDescricao = new string[] {""} ;
         BC001E10_n373TagsDescricao = new bool[] {false} ;
         BC001E10_A374TagsConteudo = new string[] {""} ;
         BC001E10_n374TagsConteudo = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tags_bc__default(),
            new Object[][] {
                new Object[] {
               BC001E2_A372TagsId, BC001E2_A373TagsDescricao, BC001E2_n373TagsDescricao, BC001E2_A374TagsConteudo, BC001E2_n374TagsConteudo
               }
               , new Object[] {
               BC001E3_A372TagsId, BC001E3_A373TagsDescricao, BC001E3_n373TagsDescricao, BC001E3_A374TagsConteudo, BC001E3_n374TagsConteudo
               }
               , new Object[] {
               BC001E4_A372TagsId, BC001E4_A373TagsDescricao, BC001E4_n373TagsDescricao, BC001E4_A374TagsConteudo, BC001E4_n374TagsConteudo
               }
               , new Object[] {
               BC001E5_A372TagsId
               }
               , new Object[] {
               }
               , new Object[] {
               BC001E7_A372TagsId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001E10_A372TagsId, BC001E10_A373TagsDescricao, BC001E10_n373TagsDescricao, BC001E10_A374TagsConteudo, BC001E10_n374TagsConteudo
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121E2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound53 ;
      private int trnEnded ;
      private int Z372TagsId ;
      private int A372TagsId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode53 ;
      private bool returnInSub ;
      private bool n373TagsDescricao ;
      private bool n374TagsConteudo ;
      private string Z373TagsDescricao ;
      private string A373TagsDescricao ;
      private string Z374TagsConteudo ;
      private string A374TagsConteudo ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private int[] BC001E4_A372TagsId ;
      private string[] BC001E4_A373TagsDescricao ;
      private bool[] BC001E4_n373TagsDescricao ;
      private string[] BC001E4_A374TagsConteudo ;
      private bool[] BC001E4_n374TagsConteudo ;
      private int[] BC001E5_A372TagsId ;
      private int[] BC001E3_A372TagsId ;
      private string[] BC001E3_A373TagsDescricao ;
      private bool[] BC001E3_n373TagsDescricao ;
      private string[] BC001E3_A374TagsConteudo ;
      private bool[] BC001E3_n374TagsConteudo ;
      private int[] BC001E2_A372TagsId ;
      private string[] BC001E2_A373TagsDescricao ;
      private bool[] BC001E2_n373TagsDescricao ;
      private string[] BC001E2_A374TagsConteudo ;
      private bool[] BC001E2_n374TagsConteudo ;
      private int[] BC001E7_A372TagsId ;
      private int[] BC001E10_A372TagsId ;
      private string[] BC001E10_A373TagsDescricao ;
      private bool[] BC001E10_n373TagsDescricao ;
      private string[] BC001E10_A374TagsConteudo ;
      private bool[] BC001E10_n374TagsConteudo ;
      private SdtTags bcTags ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class tags_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC001E2;
          prmBC001E2 = new Object[] {
          new ParDef("TagsId",GXType.Int32,9,0)
          };
          Object[] prmBC001E3;
          prmBC001E3 = new Object[] {
          new ParDef("TagsId",GXType.Int32,9,0)
          };
          Object[] prmBC001E4;
          prmBC001E4 = new Object[] {
          new ParDef("TagsId",GXType.Int32,9,0)
          };
          Object[] prmBC001E5;
          prmBC001E5 = new Object[] {
          new ParDef("TagsId",GXType.Int32,9,0)
          };
          Object[] prmBC001E6;
          prmBC001E6 = new Object[] {
          new ParDef("TagsDescricao",GXType.VarChar,108,0){Nullable=true} ,
          new ParDef("TagsConteudo",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmBC001E7;
          prmBC001E7 = new Object[] {
          };
          Object[] prmBC001E8;
          prmBC001E8 = new Object[] {
          new ParDef("TagsDescricao",GXType.VarChar,108,0){Nullable=true} ,
          new ParDef("TagsConteudo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("TagsId",GXType.Int32,9,0)
          };
          Object[] prmBC001E9;
          prmBC001E9 = new Object[] {
          new ParDef("TagsId",GXType.Int32,9,0)
          };
          Object[] prmBC001E10;
          prmBC001E10 = new Object[] {
          new ParDef("TagsId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC001E2", "SELECT TagsId, TagsDescricao, TagsConteudo FROM Tags WHERE TagsId = :TagsId  FOR UPDATE OF Tags",true, GxErrorMask.GX_NOMASK, false, this,prmBC001E2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001E3", "SELECT TagsId, TagsDescricao, TagsConteudo FROM Tags WHERE TagsId = :TagsId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001E3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001E4", "SELECT TM1.TagsId, TM1.TagsDescricao, TM1.TagsConteudo FROM Tags TM1 WHERE TM1.TagsId = :TagsId ORDER BY TM1.TagsId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001E4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001E5", "SELECT TagsId FROM Tags WHERE TagsId = :TagsId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001E5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001E6", "SAVEPOINT gxupdate;INSERT INTO Tags(TagsDescricao, TagsConteudo) VALUES(:TagsDescricao, :TagsConteudo);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001E6)
             ,new CursorDef("BC001E7", "SELECT currval('TagsId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001E7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001E8", "SAVEPOINT gxupdate;UPDATE Tags SET TagsDescricao=:TagsDescricao, TagsConteudo=:TagsConteudo  WHERE TagsId = :TagsId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001E8)
             ,new CursorDef("BC001E9", "SAVEPOINT gxupdate;DELETE FROM Tags  WHERE TagsId = :TagsId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001E9)
             ,new CursorDef("BC001E10", "SELECT TM1.TagsId, TM1.TagsDescricao, TM1.TagsConteudo FROM Tags TM1 WHERE TM1.TagsId = :TagsId ORDER BY TM1.TagsId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001E10,100, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
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
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}
