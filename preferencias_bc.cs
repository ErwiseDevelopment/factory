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
   public class preferencias_bc : GxSilentTrn, IGxSilentTrn
   {
      public preferencias_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public preferencias_bc( IGxContext context )
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
         ReadRow1847( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1847( ) ;
         standaloneModal( ) ;
         AddRow1847( ) ;
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
               Z296PreferenciasId = A296PreferenciasId;
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

      protected void CONFIRM_180( )
      {
         BeforeValidate1847( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1847( ) ;
            }
            else
            {
               CheckExtendedTable1847( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1847( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM1847( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z297PreferenciasMulta = A297PreferenciasMulta;
            Z298PreferenciasJuros = A298PreferenciasJuros;
         }
         if ( GX_JID == -1 )
         {
            Z296PreferenciasId = A296PreferenciasId;
            Z297PreferenciasMulta = A297PreferenciasMulta;
            Z298PreferenciasJuros = A298PreferenciasJuros;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load1847( )
      {
         /* Using cursor BC00184 */
         pr_default.execute(2, new Object[] {A296PreferenciasId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound47 = 1;
            A297PreferenciasMulta = BC00184_A297PreferenciasMulta[0];
            n297PreferenciasMulta = BC00184_n297PreferenciasMulta[0];
            A298PreferenciasJuros = BC00184_A298PreferenciasJuros[0];
            n298PreferenciasJuros = BC00184_n298PreferenciasJuros[0];
            ZM1847( -1) ;
         }
         pr_default.close(2);
         OnLoadActions1847( ) ;
      }

      protected void OnLoadActions1847( )
      {
      }

      protected void CheckExtendedTable1847( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1847( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1847( )
      {
         /* Using cursor BC00185 */
         pr_default.execute(3, new Object[] {A296PreferenciasId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound47 = 1;
         }
         else
         {
            RcdFound47 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00183 */
         pr_default.execute(1, new Object[] {A296PreferenciasId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1847( 1) ;
            RcdFound47 = 1;
            A296PreferenciasId = BC00183_A296PreferenciasId[0];
            A297PreferenciasMulta = BC00183_A297PreferenciasMulta[0];
            n297PreferenciasMulta = BC00183_n297PreferenciasMulta[0];
            A298PreferenciasJuros = BC00183_A298PreferenciasJuros[0];
            n298PreferenciasJuros = BC00183_n298PreferenciasJuros[0];
            Z296PreferenciasId = A296PreferenciasId;
            sMode47 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1847( ) ;
            if ( AnyError == 1 )
            {
               RcdFound47 = 0;
               InitializeNonKey1847( ) ;
            }
            Gx_mode = sMode47;
         }
         else
         {
            RcdFound47 = 0;
            InitializeNonKey1847( ) ;
            sMode47 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode47;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1847( ) ;
         if ( RcdFound47 == 0 )
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
         CONFIRM_180( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1847( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00182 */
            pr_default.execute(0, new Object[] {A296PreferenciasId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Preferencias"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z297PreferenciasMulta != BC00182_A297PreferenciasMulta[0] ) || ( Z298PreferenciasJuros != BC00182_A298PreferenciasJuros[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Preferencias"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1847( )
      {
         BeforeValidate1847( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1847( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1847( 0) ;
            CheckOptimisticConcurrency1847( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1847( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1847( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00186 */
                     pr_default.execute(4, new Object[] {n297PreferenciasMulta, A297PreferenciasMulta, n298PreferenciasJuros, A298PreferenciasJuros});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC00187 */
                     pr_default.execute(5);
                     A296PreferenciasId = BC00187_A296PreferenciasId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Preferencias");
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
               Load1847( ) ;
            }
            EndLevel1847( ) ;
         }
         CloseExtendedTableCursors1847( ) ;
      }

      protected void Update1847( )
      {
         BeforeValidate1847( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1847( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1847( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1847( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1847( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00188 */
                     pr_default.execute(6, new Object[] {n297PreferenciasMulta, A297PreferenciasMulta, n298PreferenciasJuros, A298PreferenciasJuros, A296PreferenciasId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Preferencias");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Preferencias"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1847( ) ;
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
            EndLevel1847( ) ;
         }
         CloseExtendedTableCursors1847( ) ;
      }

      protected void DeferredUpdate1847( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1847( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1847( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1847( ) ;
            AfterConfirm1847( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1847( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00189 */
                  pr_default.execute(7, new Object[] {A296PreferenciasId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Preferencias");
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
         sMode47 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1847( ) ;
         Gx_mode = sMode47;
      }

      protected void OnDeleteControls1847( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1847( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1847( ) ;
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

      public void ScanKeyStart1847( )
      {
         /* Using cursor BC001810 */
         pr_default.execute(8, new Object[] {A296PreferenciasId});
         RcdFound47 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound47 = 1;
            A296PreferenciasId = BC001810_A296PreferenciasId[0];
            A297PreferenciasMulta = BC001810_A297PreferenciasMulta[0];
            n297PreferenciasMulta = BC001810_n297PreferenciasMulta[0];
            A298PreferenciasJuros = BC001810_A298PreferenciasJuros[0];
            n298PreferenciasJuros = BC001810_n298PreferenciasJuros[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1847( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound47 = 0;
         ScanKeyLoad1847( ) ;
      }

      protected void ScanKeyLoad1847( )
      {
         sMode47 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound47 = 1;
            A296PreferenciasId = BC001810_A296PreferenciasId[0];
            A297PreferenciasMulta = BC001810_A297PreferenciasMulta[0];
            n297PreferenciasMulta = BC001810_n297PreferenciasMulta[0];
            A298PreferenciasJuros = BC001810_A298PreferenciasJuros[0];
            n298PreferenciasJuros = BC001810_n298PreferenciasJuros[0];
         }
         Gx_mode = sMode47;
      }

      protected void ScanKeyEnd1847( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm1847( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1847( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1847( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1847( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1847( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1847( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1847( )
      {
      }

      protected void send_integrity_lvl_hashes1847( )
      {
      }

      protected void AddRow1847( )
      {
         VarsToRow47( bcPreferencias) ;
      }

      protected void ReadRow1847( )
      {
         RowToVars47( bcPreferencias, 1) ;
      }

      protected void InitializeNonKey1847( )
      {
         A297PreferenciasMulta = 0;
         n297PreferenciasMulta = false;
         A298PreferenciasJuros = 0;
         n298PreferenciasJuros = false;
         Z297PreferenciasMulta = 0;
         Z298PreferenciasJuros = 0;
      }

      protected void InitAll1847( )
      {
         A296PreferenciasId = 0;
         InitializeNonKey1847( ) ;
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

      public void VarsToRow47( SdtPreferencias obj47 )
      {
         obj47.gxTpr_Mode = Gx_mode;
         obj47.gxTpr_Preferenciasmulta = A297PreferenciasMulta;
         obj47.gxTpr_Preferenciasjuros = A298PreferenciasJuros;
         obj47.gxTpr_Preferenciasid = A296PreferenciasId;
         obj47.gxTpr_Preferenciasid_Z = Z296PreferenciasId;
         obj47.gxTpr_Preferenciasmulta_Z = Z297PreferenciasMulta;
         obj47.gxTpr_Preferenciasjuros_Z = Z298PreferenciasJuros;
         obj47.gxTpr_Preferenciasmulta_N = (short)(Convert.ToInt16(n297PreferenciasMulta));
         obj47.gxTpr_Preferenciasjuros_N = (short)(Convert.ToInt16(n298PreferenciasJuros));
         obj47.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow47( SdtPreferencias obj47 )
      {
         obj47.gxTpr_Preferenciasid = A296PreferenciasId;
         return  ;
      }

      public void RowToVars47( SdtPreferencias obj47 ,
                               int forceLoad )
      {
         Gx_mode = obj47.gxTpr_Mode;
         A297PreferenciasMulta = obj47.gxTpr_Preferenciasmulta;
         n297PreferenciasMulta = false;
         A298PreferenciasJuros = obj47.gxTpr_Preferenciasjuros;
         n298PreferenciasJuros = false;
         A296PreferenciasId = obj47.gxTpr_Preferenciasid;
         Z296PreferenciasId = obj47.gxTpr_Preferenciasid_Z;
         Z297PreferenciasMulta = obj47.gxTpr_Preferenciasmulta_Z;
         Z298PreferenciasJuros = obj47.gxTpr_Preferenciasjuros_Z;
         n297PreferenciasMulta = (bool)(Convert.ToBoolean(obj47.gxTpr_Preferenciasmulta_N));
         n298PreferenciasJuros = (bool)(Convert.ToBoolean(obj47.gxTpr_Preferenciasjuros_N));
         Gx_mode = obj47.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A296PreferenciasId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1847( ) ;
         ScanKeyStart1847( ) ;
         if ( RcdFound47 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z296PreferenciasId = A296PreferenciasId;
         }
         ZM1847( -1) ;
         OnLoadActions1847( ) ;
         AddRow1847( ) ;
         ScanKeyEnd1847( ) ;
         if ( RcdFound47 == 0 )
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
         RowToVars47( bcPreferencias, 0) ;
         ScanKeyStart1847( ) ;
         if ( RcdFound47 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z296PreferenciasId = A296PreferenciasId;
         }
         ZM1847( -1) ;
         OnLoadActions1847( ) ;
         AddRow1847( ) ;
         ScanKeyEnd1847( ) ;
         if ( RcdFound47 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1847( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1847( ) ;
         }
         else
         {
            if ( RcdFound47 == 1 )
            {
               if ( A296PreferenciasId != Z296PreferenciasId )
               {
                  A296PreferenciasId = Z296PreferenciasId;
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
                  Update1847( ) ;
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
                  if ( A296PreferenciasId != Z296PreferenciasId )
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
                        Insert1847( ) ;
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
                        Insert1847( ) ;
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
         RowToVars47( bcPreferencias, 1) ;
         SaveImpl( ) ;
         VarsToRow47( bcPreferencias) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars47( bcPreferencias, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1847( ) ;
         AfterTrn( ) ;
         VarsToRow47( bcPreferencias) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow47( bcPreferencias) ;
         }
         else
         {
            SdtPreferencias auxBC = new SdtPreferencias(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A296PreferenciasId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcPreferencias);
               auxBC.Save();
               bcPreferencias.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars47( bcPreferencias, 1) ;
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
         RowToVars47( bcPreferencias, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1847( ) ;
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
               VarsToRow47( bcPreferencias) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow47( bcPreferencias) ;
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
         RowToVars47( bcPreferencias, 0) ;
         GetKey1847( ) ;
         if ( RcdFound47 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A296PreferenciasId != Z296PreferenciasId )
            {
               A296PreferenciasId = Z296PreferenciasId;
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
            if ( A296PreferenciasId != Z296PreferenciasId )
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
         context.RollbackDataStores("preferencias_bc",pr_default);
         VarsToRow47( bcPreferencias) ;
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
         Gx_mode = bcPreferencias.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcPreferencias.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcPreferencias )
         {
            bcPreferencias = (SdtPreferencias)(sdt);
            if ( StringUtil.StrCmp(bcPreferencias.gxTpr_Mode, "") == 0 )
            {
               bcPreferencias.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow47( bcPreferencias) ;
            }
            else
            {
               RowToVars47( bcPreferencias, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcPreferencias.gxTpr_Mode, "") == 0 )
            {
               bcPreferencias.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars47( bcPreferencias, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtPreferencias Preferencias_BC
      {
         get {
            return bcPreferencias ;
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
         BC00184_A296PreferenciasId = new int[1] ;
         BC00184_A297PreferenciasMulta = new decimal[1] ;
         BC00184_n297PreferenciasMulta = new bool[] {false} ;
         BC00184_A298PreferenciasJuros = new decimal[1] ;
         BC00184_n298PreferenciasJuros = new bool[] {false} ;
         BC00185_A296PreferenciasId = new int[1] ;
         BC00183_A296PreferenciasId = new int[1] ;
         BC00183_A297PreferenciasMulta = new decimal[1] ;
         BC00183_n297PreferenciasMulta = new bool[] {false} ;
         BC00183_A298PreferenciasJuros = new decimal[1] ;
         BC00183_n298PreferenciasJuros = new bool[] {false} ;
         sMode47 = "";
         BC00182_A296PreferenciasId = new int[1] ;
         BC00182_A297PreferenciasMulta = new decimal[1] ;
         BC00182_n297PreferenciasMulta = new bool[] {false} ;
         BC00182_A298PreferenciasJuros = new decimal[1] ;
         BC00182_n298PreferenciasJuros = new bool[] {false} ;
         BC00187_A296PreferenciasId = new int[1] ;
         BC001810_A296PreferenciasId = new int[1] ;
         BC001810_A297PreferenciasMulta = new decimal[1] ;
         BC001810_n297PreferenciasMulta = new bool[] {false} ;
         BC001810_A298PreferenciasJuros = new decimal[1] ;
         BC001810_n298PreferenciasJuros = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.preferencias_bc__default(),
            new Object[][] {
                new Object[] {
               BC00182_A296PreferenciasId, BC00182_A297PreferenciasMulta, BC00182_n297PreferenciasMulta, BC00182_A298PreferenciasJuros, BC00182_n298PreferenciasJuros
               }
               , new Object[] {
               BC00183_A296PreferenciasId, BC00183_A297PreferenciasMulta, BC00183_n297PreferenciasMulta, BC00183_A298PreferenciasJuros, BC00183_n298PreferenciasJuros
               }
               , new Object[] {
               BC00184_A296PreferenciasId, BC00184_A297PreferenciasMulta, BC00184_n297PreferenciasMulta, BC00184_A298PreferenciasJuros, BC00184_n298PreferenciasJuros
               }
               , new Object[] {
               BC00185_A296PreferenciasId
               }
               , new Object[] {
               }
               , new Object[] {
               BC00187_A296PreferenciasId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001810_A296PreferenciasId, BC001810_A297PreferenciasMulta, BC001810_n297PreferenciasMulta, BC001810_A298PreferenciasJuros, BC001810_n298PreferenciasJuros
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound47 ;
      private int trnEnded ;
      private int Z296PreferenciasId ;
      private int A296PreferenciasId ;
      private decimal Z297PreferenciasMulta ;
      private decimal A297PreferenciasMulta ;
      private decimal Z298PreferenciasJuros ;
      private decimal A298PreferenciasJuros ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode47 ;
      private bool n297PreferenciasMulta ;
      private bool n298PreferenciasJuros ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00184_A296PreferenciasId ;
      private decimal[] BC00184_A297PreferenciasMulta ;
      private bool[] BC00184_n297PreferenciasMulta ;
      private decimal[] BC00184_A298PreferenciasJuros ;
      private bool[] BC00184_n298PreferenciasJuros ;
      private int[] BC00185_A296PreferenciasId ;
      private int[] BC00183_A296PreferenciasId ;
      private decimal[] BC00183_A297PreferenciasMulta ;
      private bool[] BC00183_n297PreferenciasMulta ;
      private decimal[] BC00183_A298PreferenciasJuros ;
      private bool[] BC00183_n298PreferenciasJuros ;
      private int[] BC00182_A296PreferenciasId ;
      private decimal[] BC00182_A297PreferenciasMulta ;
      private bool[] BC00182_n297PreferenciasMulta ;
      private decimal[] BC00182_A298PreferenciasJuros ;
      private bool[] BC00182_n298PreferenciasJuros ;
      private int[] BC00187_A296PreferenciasId ;
      private int[] BC001810_A296PreferenciasId ;
      private decimal[] BC001810_A297PreferenciasMulta ;
      private bool[] BC001810_n297PreferenciasMulta ;
      private decimal[] BC001810_A298PreferenciasJuros ;
      private bool[] BC001810_n298PreferenciasJuros ;
      private SdtPreferencias bcPreferencias ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class preferencias_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC00182;
          prmBC00182 = new Object[] {
          new ParDef("PreferenciasId",GXType.Int32,9,0)
          };
          Object[] prmBC00183;
          prmBC00183 = new Object[] {
          new ParDef("PreferenciasId",GXType.Int32,9,0)
          };
          Object[] prmBC00184;
          prmBC00184 = new Object[] {
          new ParDef("PreferenciasId",GXType.Int32,9,0)
          };
          Object[] prmBC00185;
          prmBC00185 = new Object[] {
          new ParDef("PreferenciasId",GXType.Int32,9,0)
          };
          Object[] prmBC00186;
          prmBC00186 = new Object[] {
          new ParDef("PreferenciasMulta",GXType.Number,16,4){Nullable=true} ,
          new ParDef("PreferenciasJuros",GXType.Number,16,4){Nullable=true}
          };
          Object[] prmBC00187;
          prmBC00187 = new Object[] {
          };
          Object[] prmBC00188;
          prmBC00188 = new Object[] {
          new ParDef("PreferenciasMulta",GXType.Number,16,4){Nullable=true} ,
          new ParDef("PreferenciasJuros",GXType.Number,16,4){Nullable=true} ,
          new ParDef("PreferenciasId",GXType.Int32,9,0)
          };
          Object[] prmBC00189;
          prmBC00189 = new Object[] {
          new ParDef("PreferenciasId",GXType.Int32,9,0)
          };
          Object[] prmBC001810;
          prmBC001810 = new Object[] {
          new ParDef("PreferenciasId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00182", "SELECT PreferenciasId, PreferenciasMulta, PreferenciasJuros FROM Preferencias WHERE PreferenciasId = :PreferenciasId  FOR UPDATE OF Preferencias",true, GxErrorMask.GX_NOMASK, false, this,prmBC00182,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00183", "SELECT PreferenciasId, PreferenciasMulta, PreferenciasJuros FROM Preferencias WHERE PreferenciasId = :PreferenciasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00183,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00184", "SELECT TM1.PreferenciasId, TM1.PreferenciasMulta, TM1.PreferenciasJuros FROM Preferencias TM1 WHERE TM1.PreferenciasId = :PreferenciasId ORDER BY TM1.PreferenciasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00184,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00185", "SELECT PreferenciasId FROM Preferencias WHERE PreferenciasId = :PreferenciasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00185,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00186", "SAVEPOINT gxupdate;INSERT INTO Preferencias(PreferenciasMulta, PreferenciasJuros) VALUES(:PreferenciasMulta, :PreferenciasJuros);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00186)
             ,new CursorDef("BC00187", "SELECT currval('PreferenciasId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00187,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00188", "SAVEPOINT gxupdate;UPDATE Preferencias SET PreferenciasMulta=:PreferenciasMulta, PreferenciasJuros=:PreferenciasJuros  WHERE PreferenciasId = :PreferenciasId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00188)
             ,new CursorDef("BC00189", "SAVEPOINT gxupdate;DELETE FROM Preferencias  WHERE PreferenciasId = :PreferenciasId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00189)
             ,new CursorDef("BC001810", "SELECT TM1.PreferenciasId, TM1.PreferenciasMulta, TM1.PreferenciasJuros FROM Preferencias TM1 WHERE TM1.PreferenciasId = :PreferenciasId ORDER BY TM1.PreferenciasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001810,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}
