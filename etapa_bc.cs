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
   public class etapa_bc : GxSilentTrn, IGxSilentTrn
   {
      public etapa_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public etapa_bc( IGxContext context )
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
         ReadRow2073( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2073( ) ;
         standaloneModal( ) ;
         AddRow2073( ) ;
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
               Z527EtapaId = A527EtapaId;
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

      protected void CONFIRM_200( )
      {
         BeforeValidate2073( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2073( ) ;
            }
            else
            {
               CheckExtendedTable2073( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors2073( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM2073( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z528EtapaDescricao = A528EtapaDescricao;
            Z535EtapaCreatedAt = A535EtapaCreatedAt;
         }
         if ( GX_JID == -2 )
         {
            Z527EtapaId = A527EtapaId;
            Z528EtapaDescricao = A528EtapaDescricao;
            Z535EtapaCreatedAt = A535EtapaCreatedAt;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A535EtapaCreatedAt) && ( Gx_BScreen == 0 ) )
         {
            A535EtapaCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         }
      }

      protected void Load2073( )
      {
         /* Using cursor BC00204 */
         pr_default.execute(2, new Object[] {A527EtapaId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound73 = 1;
            A528EtapaDescricao = BC00204_A528EtapaDescricao[0];
            n528EtapaDescricao = BC00204_n528EtapaDescricao[0];
            A535EtapaCreatedAt = BC00204_A535EtapaCreatedAt[0];
            ZM2073( -2) ;
         }
         pr_default.close(2);
         OnLoadActions2073( ) ;
      }

      protected void OnLoadActions2073( )
      {
      }

      protected void CheckExtendedTable2073( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors2073( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2073( )
      {
         /* Using cursor BC00205 */
         pr_default.execute(3, new Object[] {A527EtapaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound73 = 1;
         }
         else
         {
            RcdFound73 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00203 */
         pr_default.execute(1, new Object[] {A527EtapaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2073( 2) ;
            RcdFound73 = 1;
            A527EtapaId = BC00203_A527EtapaId[0];
            A528EtapaDescricao = BC00203_A528EtapaDescricao[0];
            n528EtapaDescricao = BC00203_n528EtapaDescricao[0];
            A535EtapaCreatedAt = BC00203_A535EtapaCreatedAt[0];
            Z527EtapaId = A527EtapaId;
            sMode73 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2073( ) ;
            if ( AnyError == 1 )
            {
               RcdFound73 = 0;
               InitializeNonKey2073( ) ;
            }
            Gx_mode = sMode73;
         }
         else
         {
            RcdFound73 = 0;
            InitializeNonKey2073( ) ;
            sMode73 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode73;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2073( ) ;
         if ( RcdFound73 == 0 )
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
         CONFIRM_200( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2073( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00202 */
            pr_default.execute(0, new Object[] {A527EtapaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Etapa"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z528EtapaDescricao, BC00202_A528EtapaDescricao[0]) != 0 ) || ( Z535EtapaCreatedAt != BC00202_A535EtapaCreatedAt[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Etapa"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2073( )
      {
         BeforeValidate2073( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2073( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2073( 0) ;
            CheckOptimisticConcurrency2073( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2073( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2073( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00206 */
                     pr_default.execute(4, new Object[] {n528EtapaDescricao, A528EtapaDescricao, A535EtapaCreatedAt});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC00207 */
                     pr_default.execute(5);
                     A527EtapaId = BC00207_A527EtapaId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Etapa");
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
               Load2073( ) ;
            }
            EndLevel2073( ) ;
         }
         CloseExtendedTableCursors2073( ) ;
      }

      protected void Update2073( )
      {
         BeforeValidate2073( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2073( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2073( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2073( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2073( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00208 */
                     pr_default.execute(6, new Object[] {n528EtapaDescricao, A528EtapaDescricao, A535EtapaCreatedAt, A527EtapaId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Etapa");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Etapa"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2073( ) ;
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
            EndLevel2073( ) ;
         }
         CloseExtendedTableCursors2073( ) ;
      }

      protected void DeferredUpdate2073( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2073( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2073( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2073( ) ;
            AfterConfirm2073( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2073( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00209 */
                  pr_default.execute(7, new Object[] {A527EtapaId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Etapa");
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
         sMode73 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2073( ) ;
         Gx_mode = sMode73;
      }

      protected void OnDeleteControls2073( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2073( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2073( ) ;
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

      public void ScanKeyStart2073( )
      {
         /* Using cursor BC002010 */
         pr_default.execute(8, new Object[] {A527EtapaId});
         RcdFound73 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound73 = 1;
            A527EtapaId = BC002010_A527EtapaId[0];
            A528EtapaDescricao = BC002010_A528EtapaDescricao[0];
            n528EtapaDescricao = BC002010_n528EtapaDescricao[0];
            A535EtapaCreatedAt = BC002010_A535EtapaCreatedAt[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2073( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound73 = 0;
         ScanKeyLoad2073( ) ;
      }

      protected void ScanKeyLoad2073( )
      {
         sMode73 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound73 = 1;
            A527EtapaId = BC002010_A527EtapaId[0];
            A528EtapaDescricao = BC002010_A528EtapaDescricao[0];
            n528EtapaDescricao = BC002010_n528EtapaDescricao[0];
            A535EtapaCreatedAt = BC002010_A535EtapaCreatedAt[0];
         }
         Gx_mode = sMode73;
      }

      protected void ScanKeyEnd2073( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm2073( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2073( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2073( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2073( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2073( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2073( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2073( )
      {
      }

      protected void send_integrity_lvl_hashes2073( )
      {
      }

      protected void AddRow2073( )
      {
         VarsToRow73( bcEtapa) ;
      }

      protected void ReadRow2073( )
      {
         RowToVars73( bcEtapa, 1) ;
      }

      protected void InitializeNonKey2073( )
      {
         A528EtapaDescricao = "";
         n528EtapaDescricao = false;
         A535EtapaCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         Z528EtapaDescricao = "";
         Z535EtapaCreatedAt = (DateTime)(DateTime.MinValue);
      }

      protected void InitAll2073( )
      {
         A527EtapaId = 0;
         InitializeNonKey2073( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A535EtapaCreatedAt = i535EtapaCreatedAt;
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

      public void VarsToRow73( SdtEtapa obj73 )
      {
         obj73.gxTpr_Mode = Gx_mode;
         obj73.gxTpr_Etapadescricao = A528EtapaDescricao;
         obj73.gxTpr_Etapacreatedat = A535EtapaCreatedAt;
         obj73.gxTpr_Etapaid = A527EtapaId;
         obj73.gxTpr_Etapaid_Z = Z527EtapaId;
         obj73.gxTpr_Etapadescricao_Z = Z528EtapaDescricao;
         obj73.gxTpr_Etapacreatedat_Z = Z535EtapaCreatedAt;
         obj73.gxTpr_Etapadescricao_N = (short)(Convert.ToInt16(n528EtapaDescricao));
         obj73.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow73( SdtEtapa obj73 )
      {
         obj73.gxTpr_Etapaid = A527EtapaId;
         return  ;
      }

      public void RowToVars73( SdtEtapa obj73 ,
                               int forceLoad )
      {
         Gx_mode = obj73.gxTpr_Mode;
         A528EtapaDescricao = obj73.gxTpr_Etapadescricao;
         n528EtapaDescricao = false;
         A535EtapaCreatedAt = obj73.gxTpr_Etapacreatedat;
         A527EtapaId = obj73.gxTpr_Etapaid;
         Z527EtapaId = obj73.gxTpr_Etapaid_Z;
         Z528EtapaDescricao = obj73.gxTpr_Etapadescricao_Z;
         Z535EtapaCreatedAt = obj73.gxTpr_Etapacreatedat_Z;
         n528EtapaDescricao = (bool)(Convert.ToBoolean(obj73.gxTpr_Etapadescricao_N));
         Gx_mode = obj73.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A527EtapaId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2073( ) ;
         ScanKeyStart2073( ) ;
         if ( RcdFound73 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z527EtapaId = A527EtapaId;
         }
         ZM2073( -2) ;
         OnLoadActions2073( ) ;
         AddRow2073( ) ;
         ScanKeyEnd2073( ) ;
         if ( RcdFound73 == 0 )
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
         RowToVars73( bcEtapa, 0) ;
         ScanKeyStart2073( ) ;
         if ( RcdFound73 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z527EtapaId = A527EtapaId;
         }
         ZM2073( -2) ;
         OnLoadActions2073( ) ;
         AddRow2073( ) ;
         ScanKeyEnd2073( ) ;
         if ( RcdFound73 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2073( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2073( ) ;
         }
         else
         {
            if ( RcdFound73 == 1 )
            {
               if ( A527EtapaId != Z527EtapaId )
               {
                  A527EtapaId = Z527EtapaId;
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
                  Update2073( ) ;
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
                  if ( A527EtapaId != Z527EtapaId )
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
                        Insert2073( ) ;
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
                        Insert2073( ) ;
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
         RowToVars73( bcEtapa, 1) ;
         SaveImpl( ) ;
         VarsToRow73( bcEtapa) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars73( bcEtapa, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2073( ) ;
         AfterTrn( ) ;
         VarsToRow73( bcEtapa) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow73( bcEtapa) ;
         }
         else
         {
            SdtEtapa auxBC = new SdtEtapa(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A527EtapaId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcEtapa);
               auxBC.Save();
               bcEtapa.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars73( bcEtapa, 1) ;
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
         RowToVars73( bcEtapa, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2073( ) ;
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
               VarsToRow73( bcEtapa) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow73( bcEtapa) ;
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
         RowToVars73( bcEtapa, 0) ;
         GetKey2073( ) ;
         if ( RcdFound73 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A527EtapaId != Z527EtapaId )
            {
               A527EtapaId = Z527EtapaId;
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
            if ( A527EtapaId != Z527EtapaId )
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
         context.RollbackDataStores("etapa_bc",pr_default);
         VarsToRow73( bcEtapa) ;
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
         Gx_mode = bcEtapa.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcEtapa.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcEtapa )
         {
            bcEtapa = (SdtEtapa)(sdt);
            if ( StringUtil.StrCmp(bcEtapa.gxTpr_Mode, "") == 0 )
            {
               bcEtapa.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow73( bcEtapa) ;
            }
            else
            {
               RowToVars73( bcEtapa, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcEtapa.gxTpr_Mode, "") == 0 )
            {
               bcEtapa.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars73( bcEtapa, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtEtapa Etapa_BC
      {
         get {
            return bcEtapa ;
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
         Z528EtapaDescricao = "";
         A528EtapaDescricao = "";
         Z535EtapaCreatedAt = (DateTime)(DateTime.MinValue);
         A535EtapaCreatedAt = (DateTime)(DateTime.MinValue);
         BC00204_A527EtapaId = new int[1] ;
         BC00204_A528EtapaDescricao = new string[] {""} ;
         BC00204_n528EtapaDescricao = new bool[] {false} ;
         BC00204_A535EtapaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00205_A527EtapaId = new int[1] ;
         BC00203_A527EtapaId = new int[1] ;
         BC00203_A528EtapaDescricao = new string[] {""} ;
         BC00203_n528EtapaDescricao = new bool[] {false} ;
         BC00203_A535EtapaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         sMode73 = "";
         BC00202_A527EtapaId = new int[1] ;
         BC00202_A528EtapaDescricao = new string[] {""} ;
         BC00202_n528EtapaDescricao = new bool[] {false} ;
         BC00202_A535EtapaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00207_A527EtapaId = new int[1] ;
         BC002010_A527EtapaId = new int[1] ;
         BC002010_A528EtapaDescricao = new string[] {""} ;
         BC002010_n528EtapaDescricao = new bool[] {false} ;
         BC002010_A535EtapaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         i535EtapaCreatedAt = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.etapa_bc__default(),
            new Object[][] {
                new Object[] {
               BC00202_A527EtapaId, BC00202_A528EtapaDescricao, BC00202_n528EtapaDescricao, BC00202_A535EtapaCreatedAt
               }
               , new Object[] {
               BC00203_A527EtapaId, BC00203_A528EtapaDescricao, BC00203_n528EtapaDescricao, BC00203_A535EtapaCreatedAt
               }
               , new Object[] {
               BC00204_A527EtapaId, BC00204_A528EtapaDescricao, BC00204_n528EtapaDescricao, BC00204_A535EtapaCreatedAt
               }
               , new Object[] {
               BC00205_A527EtapaId
               }
               , new Object[] {
               }
               , new Object[] {
               BC00207_A527EtapaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002010_A527EtapaId, BC002010_A528EtapaDescricao, BC002010_n528EtapaDescricao, BC002010_A535EtapaCreatedAt
               }
            }
         );
         Z535EtapaCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         A535EtapaCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         i535EtapaCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound73 ;
      private int trnEnded ;
      private int Z527EtapaId ;
      private int A527EtapaId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode73 ;
      private DateTime Z535EtapaCreatedAt ;
      private DateTime A535EtapaCreatedAt ;
      private DateTime i535EtapaCreatedAt ;
      private bool n528EtapaDescricao ;
      private string Z528EtapaDescricao ;
      private string A528EtapaDescricao ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00204_A527EtapaId ;
      private string[] BC00204_A528EtapaDescricao ;
      private bool[] BC00204_n528EtapaDescricao ;
      private DateTime[] BC00204_A535EtapaCreatedAt ;
      private int[] BC00205_A527EtapaId ;
      private int[] BC00203_A527EtapaId ;
      private string[] BC00203_A528EtapaDescricao ;
      private bool[] BC00203_n528EtapaDescricao ;
      private DateTime[] BC00203_A535EtapaCreatedAt ;
      private int[] BC00202_A527EtapaId ;
      private string[] BC00202_A528EtapaDescricao ;
      private bool[] BC00202_n528EtapaDescricao ;
      private DateTime[] BC00202_A535EtapaCreatedAt ;
      private int[] BC00207_A527EtapaId ;
      private int[] BC002010_A527EtapaId ;
      private string[] BC002010_A528EtapaDescricao ;
      private bool[] BC002010_n528EtapaDescricao ;
      private DateTime[] BC002010_A535EtapaCreatedAt ;
      private SdtEtapa bcEtapa ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class etapa_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC00202;
          prmBC00202 = new Object[] {
          new ParDef("EtapaId",GXType.Int32,9,0)
          };
          Object[] prmBC00203;
          prmBC00203 = new Object[] {
          new ParDef("EtapaId",GXType.Int32,9,0)
          };
          Object[] prmBC00204;
          prmBC00204 = new Object[] {
          new ParDef("EtapaId",GXType.Int32,9,0)
          };
          Object[] prmBC00205;
          prmBC00205 = new Object[] {
          new ParDef("EtapaId",GXType.Int32,9,0)
          };
          Object[] prmBC00206;
          prmBC00206 = new Object[] {
          new ParDef("EtapaDescricao",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("EtapaCreatedAt",GXType.DateTime,8,5)
          };
          Object[] prmBC00207;
          prmBC00207 = new Object[] {
          };
          Object[] prmBC00208;
          prmBC00208 = new Object[] {
          new ParDef("EtapaDescricao",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("EtapaCreatedAt",GXType.DateTime,8,5) ,
          new ParDef("EtapaId",GXType.Int32,9,0)
          };
          Object[] prmBC00209;
          prmBC00209 = new Object[] {
          new ParDef("EtapaId",GXType.Int32,9,0)
          };
          Object[] prmBC002010;
          prmBC002010 = new Object[] {
          new ParDef("EtapaId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00202", "SELECT EtapaId, EtapaDescricao, EtapaCreatedAt FROM Etapa WHERE EtapaId = :EtapaId  FOR UPDATE OF Etapa",true, GxErrorMask.GX_NOMASK, false, this,prmBC00202,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00203", "SELECT EtapaId, EtapaDescricao, EtapaCreatedAt FROM Etapa WHERE EtapaId = :EtapaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00203,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00204", "SELECT TM1.EtapaId, TM1.EtapaDescricao, TM1.EtapaCreatedAt FROM Etapa TM1 WHERE TM1.EtapaId = :EtapaId ORDER BY TM1.EtapaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00204,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00205", "SELECT EtapaId FROM Etapa WHERE EtapaId = :EtapaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00205,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00206", "SAVEPOINT gxupdate;INSERT INTO Etapa(EtapaDescricao, EtapaCreatedAt) VALUES(:EtapaDescricao, :EtapaCreatedAt);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00206)
             ,new CursorDef("BC00207", "SELECT currval('EtapaId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00207,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00208", "SAVEPOINT gxupdate;UPDATE Etapa SET EtapaDescricao=:EtapaDescricao, EtapaCreatedAt=:EtapaCreatedAt  WHERE EtapaId = :EtapaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00208)
             ,new CursorDef("BC00209", "SAVEPOINT gxupdate;DELETE FROM Etapa  WHERE EtapaId = :EtapaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00209)
             ,new CursorDef("BC002010", "SELECT TM1.EtapaId, TM1.EtapaDescricao, TM1.EtapaCreatedAt FROM Etapa TM1 WHERE TM1.EtapaId = :EtapaId ORDER BY TM1.EtapaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002010,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
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
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                return;
       }
    }

 }

}
