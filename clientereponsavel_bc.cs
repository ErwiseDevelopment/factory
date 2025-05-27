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
   public class clientereponsavel_bc : GxSilentTrn, IGxSilentTrn
   {
      public clientereponsavel_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clientereponsavel_bc( IGxContext context )
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
         ReadRow2375( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2375( ) ;
         standaloneModal( ) ;
         AddRow2375( ) ;
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
               Z551ClienteReponsavelId = A551ClienteReponsavelId;
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

      protected void CONFIRM_230( )
      {
         BeforeValidate2375( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2375( ) ;
            }
            else
            {
               CheckExtendedTable2375( ) ;
               if ( AnyError == 0 )
               {
                  ZM2375( 2) ;
                  ZM2375( 3) ;
               }
               CloseExtendedTableCursors2375( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM2375( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z168ClienteId = A168ClienteId;
            Z552ReponsavelClienteId = A552ReponsavelClienteId;
         }
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -1 )
         {
            Z551ClienteReponsavelId = A551ClienteReponsavelId;
            Z168ClienteId = A168ClienteId;
            Z552ReponsavelClienteId = A552ReponsavelClienteId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load2375( )
      {
         /* Using cursor BC00236 */
         pr_default.execute(4, new Object[] {A551ClienteReponsavelId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound75 = 1;
            A168ClienteId = BC00236_A168ClienteId[0];
            n168ClienteId = BC00236_n168ClienteId[0];
            A552ReponsavelClienteId = BC00236_A552ReponsavelClienteId[0];
            n552ReponsavelClienteId = BC00236_n552ReponsavelClienteId[0];
            ZM2375( -1) ;
         }
         pr_default.close(4);
         OnLoadActions2375( ) ;
      }

      protected void OnLoadActions2375( )
      {
      }

      protected void CheckExtendedTable2375( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00235 */
         pr_default.execute(3, new Object[] {n552ReponsavelClienteId, A552ReponsavelClienteId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A552ReponsavelClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Cliente Reponsavel'.", "ForeignKeyNotFound", 1, "REPONSAVELCLIENTEID");
               AnyError = 1;
            }
         }
         pr_default.close(3);
         /* Using cursor BC00234 */
         pr_default.execute(2, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A168ClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
               AnyError = 1;
            }
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors2375( )
      {
         pr_default.close(3);
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2375( )
      {
         /* Using cursor BC00237 */
         pr_default.execute(5, new Object[] {A551ClienteReponsavelId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound75 = 1;
         }
         else
         {
            RcdFound75 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00233 */
         pr_default.execute(1, new Object[] {A551ClienteReponsavelId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2375( 1) ;
            RcdFound75 = 1;
            A551ClienteReponsavelId = BC00233_A551ClienteReponsavelId[0];
            A168ClienteId = BC00233_A168ClienteId[0];
            n168ClienteId = BC00233_n168ClienteId[0];
            A552ReponsavelClienteId = BC00233_A552ReponsavelClienteId[0];
            n552ReponsavelClienteId = BC00233_n552ReponsavelClienteId[0];
            Z551ClienteReponsavelId = A551ClienteReponsavelId;
            sMode75 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2375( ) ;
            if ( AnyError == 1 )
            {
               RcdFound75 = 0;
               InitializeNonKey2375( ) ;
            }
            Gx_mode = sMode75;
         }
         else
         {
            RcdFound75 = 0;
            InitializeNonKey2375( ) ;
            sMode75 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode75;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2375( ) ;
         if ( RcdFound75 == 0 )
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
         CONFIRM_230( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2375( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00232 */
            pr_default.execute(0, new Object[] {A551ClienteReponsavelId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ClienteReponsavel"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z168ClienteId != BC00232_A168ClienteId[0] ) || ( Z552ReponsavelClienteId != BC00232_A552ReponsavelClienteId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ClienteReponsavel"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2375( )
      {
         BeforeValidate2375( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2375( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2375( 0) ;
            CheckOptimisticConcurrency2375( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2375( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2375( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00238 */
                     pr_default.execute(6, new Object[] {n168ClienteId, A168ClienteId, n552ReponsavelClienteId, A552ReponsavelClienteId});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC00239 */
                     pr_default.execute(7);
                     A551ClienteReponsavelId = BC00239_A551ClienteReponsavelId[0];
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("ClienteReponsavel");
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
               Load2375( ) ;
            }
            EndLevel2375( ) ;
         }
         CloseExtendedTableCursors2375( ) ;
      }

      protected void Update2375( )
      {
         BeforeValidate2375( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2375( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2375( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2375( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2375( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002310 */
                     pr_default.execute(8, new Object[] {n168ClienteId, A168ClienteId, n552ReponsavelClienteId, A552ReponsavelClienteId, A551ClienteReponsavelId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("ClienteReponsavel");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ClienteReponsavel"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2375( ) ;
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
            EndLevel2375( ) ;
         }
         CloseExtendedTableCursors2375( ) ;
      }

      protected void DeferredUpdate2375( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2375( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2375( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2375( ) ;
            AfterConfirm2375( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2375( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002311 */
                  pr_default.execute(9, new Object[] {A551ClienteReponsavelId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("ClienteReponsavel");
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
         sMode75 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2375( ) ;
         Gx_mode = sMode75;
      }

      protected void OnDeleteControls2375( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2375( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2375( ) ;
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

      public void ScanKeyStart2375( )
      {
         /* Using cursor BC002312 */
         pr_default.execute(10, new Object[] {A551ClienteReponsavelId});
         RcdFound75 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound75 = 1;
            A551ClienteReponsavelId = BC002312_A551ClienteReponsavelId[0];
            A168ClienteId = BC002312_A168ClienteId[0];
            n168ClienteId = BC002312_n168ClienteId[0];
            A552ReponsavelClienteId = BC002312_A552ReponsavelClienteId[0];
            n552ReponsavelClienteId = BC002312_n552ReponsavelClienteId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2375( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound75 = 0;
         ScanKeyLoad2375( ) ;
      }

      protected void ScanKeyLoad2375( )
      {
         sMode75 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound75 = 1;
            A551ClienteReponsavelId = BC002312_A551ClienteReponsavelId[0];
            A168ClienteId = BC002312_A168ClienteId[0];
            n168ClienteId = BC002312_n168ClienteId[0];
            A552ReponsavelClienteId = BC002312_A552ReponsavelClienteId[0];
            n552ReponsavelClienteId = BC002312_n552ReponsavelClienteId[0];
         }
         Gx_mode = sMode75;
      }

      protected void ScanKeyEnd2375( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm2375( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2375( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2375( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2375( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2375( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2375( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2375( )
      {
      }

      protected void send_integrity_lvl_hashes2375( )
      {
      }

      protected void AddRow2375( )
      {
         VarsToRow75( bcClienteReponsavel) ;
      }

      protected void ReadRow2375( )
      {
         RowToVars75( bcClienteReponsavel, 1) ;
      }

      protected void InitializeNonKey2375( )
      {
         A552ReponsavelClienteId = 0;
         n552ReponsavelClienteId = false;
         A168ClienteId = 0;
         n168ClienteId = false;
         Z168ClienteId = 0;
         Z552ReponsavelClienteId = 0;
      }

      protected void InitAll2375( )
      {
         A551ClienteReponsavelId = 0;
         InitializeNonKey2375( ) ;
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

      public void VarsToRow75( SdtClienteReponsavel obj75 )
      {
         obj75.gxTpr_Mode = Gx_mode;
         obj75.gxTpr_Reponsavelclienteid = A552ReponsavelClienteId;
         obj75.gxTpr_Clienteid = A168ClienteId;
         obj75.gxTpr_Clientereponsavelid = A551ClienteReponsavelId;
         obj75.gxTpr_Clientereponsavelid_Z = Z551ClienteReponsavelId;
         obj75.gxTpr_Reponsavelclienteid_Z = Z552ReponsavelClienteId;
         obj75.gxTpr_Clienteid_Z = Z168ClienteId;
         obj75.gxTpr_Reponsavelclienteid_N = (short)(Convert.ToInt16(n552ReponsavelClienteId));
         obj75.gxTpr_Clienteid_N = (short)(Convert.ToInt16(n168ClienteId));
         obj75.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow75( SdtClienteReponsavel obj75 )
      {
         obj75.gxTpr_Clientereponsavelid = A551ClienteReponsavelId;
         return  ;
      }

      public void RowToVars75( SdtClienteReponsavel obj75 ,
                               int forceLoad )
      {
         Gx_mode = obj75.gxTpr_Mode;
         A552ReponsavelClienteId = obj75.gxTpr_Reponsavelclienteid;
         n552ReponsavelClienteId = false;
         A168ClienteId = obj75.gxTpr_Clienteid;
         n168ClienteId = false;
         A551ClienteReponsavelId = obj75.gxTpr_Clientereponsavelid;
         Z551ClienteReponsavelId = obj75.gxTpr_Clientereponsavelid_Z;
         Z552ReponsavelClienteId = obj75.gxTpr_Reponsavelclienteid_Z;
         Z168ClienteId = obj75.gxTpr_Clienteid_Z;
         n552ReponsavelClienteId = (bool)(Convert.ToBoolean(obj75.gxTpr_Reponsavelclienteid_N));
         n168ClienteId = (bool)(Convert.ToBoolean(obj75.gxTpr_Clienteid_N));
         Gx_mode = obj75.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A551ClienteReponsavelId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2375( ) ;
         ScanKeyStart2375( ) ;
         if ( RcdFound75 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z551ClienteReponsavelId = A551ClienteReponsavelId;
         }
         ZM2375( -1) ;
         OnLoadActions2375( ) ;
         AddRow2375( ) ;
         ScanKeyEnd2375( ) ;
         if ( RcdFound75 == 0 )
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
         RowToVars75( bcClienteReponsavel, 0) ;
         ScanKeyStart2375( ) ;
         if ( RcdFound75 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z551ClienteReponsavelId = A551ClienteReponsavelId;
         }
         ZM2375( -1) ;
         OnLoadActions2375( ) ;
         AddRow2375( ) ;
         ScanKeyEnd2375( ) ;
         if ( RcdFound75 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2375( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2375( ) ;
         }
         else
         {
            if ( RcdFound75 == 1 )
            {
               if ( A551ClienteReponsavelId != Z551ClienteReponsavelId )
               {
                  A551ClienteReponsavelId = Z551ClienteReponsavelId;
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
                  Update2375( ) ;
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
                  if ( A551ClienteReponsavelId != Z551ClienteReponsavelId )
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
                        Insert2375( ) ;
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
                        Insert2375( ) ;
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
         RowToVars75( bcClienteReponsavel, 1) ;
         SaveImpl( ) ;
         VarsToRow75( bcClienteReponsavel) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars75( bcClienteReponsavel, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2375( ) ;
         AfterTrn( ) ;
         VarsToRow75( bcClienteReponsavel) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow75( bcClienteReponsavel) ;
         }
         else
         {
            SdtClienteReponsavel auxBC = new SdtClienteReponsavel(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A551ClienteReponsavelId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcClienteReponsavel);
               auxBC.Save();
               bcClienteReponsavel.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars75( bcClienteReponsavel, 1) ;
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
         RowToVars75( bcClienteReponsavel, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2375( ) ;
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
               VarsToRow75( bcClienteReponsavel) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow75( bcClienteReponsavel) ;
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
         RowToVars75( bcClienteReponsavel, 0) ;
         GetKey2375( ) ;
         if ( RcdFound75 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A551ClienteReponsavelId != Z551ClienteReponsavelId )
            {
               A551ClienteReponsavelId = Z551ClienteReponsavelId;
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
            if ( A551ClienteReponsavelId != Z551ClienteReponsavelId )
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
         context.RollbackDataStores("clientereponsavel_bc",pr_default);
         VarsToRow75( bcClienteReponsavel) ;
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
         Gx_mode = bcClienteReponsavel.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcClienteReponsavel.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcClienteReponsavel )
         {
            bcClienteReponsavel = (SdtClienteReponsavel)(sdt);
            if ( StringUtil.StrCmp(bcClienteReponsavel.gxTpr_Mode, "") == 0 )
            {
               bcClienteReponsavel.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow75( bcClienteReponsavel) ;
            }
            else
            {
               RowToVars75( bcClienteReponsavel, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcClienteReponsavel.gxTpr_Mode, "") == 0 )
            {
               bcClienteReponsavel.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars75( bcClienteReponsavel, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtClienteReponsavel ClienteReponsavel_BC
      {
         get {
            return bcClienteReponsavel ;
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
         BC00236_A551ClienteReponsavelId = new int[1] ;
         BC00236_A168ClienteId = new int[1] ;
         BC00236_n168ClienteId = new bool[] {false} ;
         BC00236_A552ReponsavelClienteId = new int[1] ;
         BC00236_n552ReponsavelClienteId = new bool[] {false} ;
         BC00235_A552ReponsavelClienteId = new int[1] ;
         BC00235_n552ReponsavelClienteId = new bool[] {false} ;
         BC00234_A168ClienteId = new int[1] ;
         BC00234_n168ClienteId = new bool[] {false} ;
         BC00237_A551ClienteReponsavelId = new int[1] ;
         BC00233_A551ClienteReponsavelId = new int[1] ;
         BC00233_A168ClienteId = new int[1] ;
         BC00233_n168ClienteId = new bool[] {false} ;
         BC00233_A552ReponsavelClienteId = new int[1] ;
         BC00233_n552ReponsavelClienteId = new bool[] {false} ;
         sMode75 = "";
         BC00232_A551ClienteReponsavelId = new int[1] ;
         BC00232_A168ClienteId = new int[1] ;
         BC00232_n168ClienteId = new bool[] {false} ;
         BC00232_A552ReponsavelClienteId = new int[1] ;
         BC00232_n552ReponsavelClienteId = new bool[] {false} ;
         BC00239_A551ClienteReponsavelId = new int[1] ;
         BC002312_A551ClienteReponsavelId = new int[1] ;
         BC002312_A168ClienteId = new int[1] ;
         BC002312_n168ClienteId = new bool[] {false} ;
         BC002312_A552ReponsavelClienteId = new int[1] ;
         BC002312_n552ReponsavelClienteId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clientereponsavel_bc__default(),
            new Object[][] {
                new Object[] {
               BC00232_A551ClienteReponsavelId, BC00232_A168ClienteId, BC00232_n168ClienteId, BC00232_A552ReponsavelClienteId, BC00232_n552ReponsavelClienteId
               }
               , new Object[] {
               BC00233_A551ClienteReponsavelId, BC00233_A168ClienteId, BC00233_n168ClienteId, BC00233_A552ReponsavelClienteId, BC00233_n552ReponsavelClienteId
               }
               , new Object[] {
               BC00234_A168ClienteId
               }
               , new Object[] {
               BC00235_A552ReponsavelClienteId
               }
               , new Object[] {
               BC00236_A551ClienteReponsavelId, BC00236_A168ClienteId, BC00236_n168ClienteId, BC00236_A552ReponsavelClienteId, BC00236_n552ReponsavelClienteId
               }
               , new Object[] {
               BC00237_A551ClienteReponsavelId
               }
               , new Object[] {
               }
               , new Object[] {
               BC00239_A551ClienteReponsavelId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002312_A551ClienteReponsavelId, BC002312_A168ClienteId, BC002312_n168ClienteId, BC002312_A552ReponsavelClienteId, BC002312_n552ReponsavelClienteId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound75 ;
      private int trnEnded ;
      private int Z551ClienteReponsavelId ;
      private int A551ClienteReponsavelId ;
      private int Z168ClienteId ;
      private int A168ClienteId ;
      private int Z552ReponsavelClienteId ;
      private int A552ReponsavelClienteId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode75 ;
      private bool n168ClienteId ;
      private bool n552ReponsavelClienteId ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00236_A551ClienteReponsavelId ;
      private int[] BC00236_A168ClienteId ;
      private bool[] BC00236_n168ClienteId ;
      private int[] BC00236_A552ReponsavelClienteId ;
      private bool[] BC00236_n552ReponsavelClienteId ;
      private int[] BC00235_A552ReponsavelClienteId ;
      private bool[] BC00235_n552ReponsavelClienteId ;
      private int[] BC00234_A168ClienteId ;
      private bool[] BC00234_n168ClienteId ;
      private int[] BC00237_A551ClienteReponsavelId ;
      private int[] BC00233_A551ClienteReponsavelId ;
      private int[] BC00233_A168ClienteId ;
      private bool[] BC00233_n168ClienteId ;
      private int[] BC00233_A552ReponsavelClienteId ;
      private bool[] BC00233_n552ReponsavelClienteId ;
      private int[] BC00232_A551ClienteReponsavelId ;
      private int[] BC00232_A168ClienteId ;
      private bool[] BC00232_n168ClienteId ;
      private int[] BC00232_A552ReponsavelClienteId ;
      private bool[] BC00232_n552ReponsavelClienteId ;
      private int[] BC00239_A551ClienteReponsavelId ;
      private int[] BC002312_A551ClienteReponsavelId ;
      private int[] BC002312_A168ClienteId ;
      private bool[] BC002312_n168ClienteId ;
      private int[] BC002312_A552ReponsavelClienteId ;
      private bool[] BC002312_n552ReponsavelClienteId ;
      private SdtClienteReponsavel bcClienteReponsavel ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class clientereponsavel_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[5])
         ,new UpdateCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00232;
          prmBC00232 = new Object[] {
          new ParDef("ClienteReponsavelId",GXType.Int32,9,0)
          };
          Object[] prmBC00233;
          prmBC00233 = new Object[] {
          new ParDef("ClienteReponsavelId",GXType.Int32,9,0)
          };
          Object[] prmBC00234;
          prmBC00234 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00235;
          prmBC00235 = new Object[] {
          new ParDef("ReponsavelClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00236;
          prmBC00236 = new Object[] {
          new ParDef("ClienteReponsavelId",GXType.Int32,9,0)
          };
          Object[] prmBC00237;
          prmBC00237 = new Object[] {
          new ParDef("ClienteReponsavelId",GXType.Int32,9,0)
          };
          Object[] prmBC00238;
          prmBC00238 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ReponsavelClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00239;
          prmBC00239 = new Object[] {
          };
          Object[] prmBC002310;
          prmBC002310 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ReponsavelClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ClienteReponsavelId",GXType.Int32,9,0)
          };
          Object[] prmBC002311;
          prmBC002311 = new Object[] {
          new ParDef("ClienteReponsavelId",GXType.Int32,9,0)
          };
          Object[] prmBC002312;
          prmBC002312 = new Object[] {
          new ParDef("ClienteReponsavelId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00232", "SELECT ClienteReponsavelId, ClienteId, ReponsavelClienteId FROM ClienteReponsavel WHERE ClienteReponsavelId = :ClienteReponsavelId  FOR UPDATE OF ClienteReponsavel",true, GxErrorMask.GX_NOMASK, false, this,prmBC00232,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00233", "SELECT ClienteReponsavelId, ClienteId, ReponsavelClienteId FROM ClienteReponsavel WHERE ClienteReponsavelId = :ClienteReponsavelId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00233,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00234", "SELECT ClienteId FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00234,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00235", "SELECT ClienteId AS ReponsavelClienteId FROM Cliente WHERE ClienteId = :ReponsavelClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00235,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00236", "SELECT TM1.ClienteReponsavelId, TM1.ClienteId, TM1.ReponsavelClienteId AS ReponsavelClienteId FROM ClienteReponsavel TM1 WHERE TM1.ClienteReponsavelId = :ClienteReponsavelId ORDER BY TM1.ClienteReponsavelId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00236,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00237", "SELECT ClienteReponsavelId FROM ClienteReponsavel WHERE ClienteReponsavelId = :ClienteReponsavelId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00237,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00238", "SAVEPOINT gxupdate;INSERT INTO ClienteReponsavel(ClienteId, ReponsavelClienteId) VALUES(:ClienteId, :ReponsavelClienteId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00238)
             ,new CursorDef("BC00239", "SELECT currval('ClienteReponsavelId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00239,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002310", "SAVEPOINT gxupdate;UPDATE ClienteReponsavel SET ClienteId=:ClienteId, ReponsavelClienteId=:ReponsavelClienteId  WHERE ClienteReponsavelId = :ClienteReponsavelId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002310)
             ,new CursorDef("BC002311", "SAVEPOINT gxupdate;DELETE FROM ClienteReponsavel  WHERE ClienteReponsavelId = :ClienteReponsavelId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002311)
             ,new CursorDef("BC002312", "SELECT TM1.ClienteReponsavelId, TM1.ClienteId, TM1.ReponsavelClienteId AS ReponsavelClienteId FROM ClienteReponsavel TM1 WHERE TM1.ClienteReponsavelId = :ClienteReponsavelId ORDER BY TM1.ClienteReponsavelId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002312,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}
