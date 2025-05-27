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
   public class logemail_bc : GxSilentTrn, IGxSilentTrn
   {
      public logemail_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public logemail_bc( IGxContext context )
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
         ReadRow2A80( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2A80( ) ;
         standaloneModal( ) ;
         AddRow2A80( ) ;
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
               Z626LogEmailId = A626LogEmailId;
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

      protected void CONFIRM_2A0( )
      {
         BeforeValidate2A80( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2A80( ) ;
            }
            else
            {
               CheckExtendedTable2A80( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors2A80( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM2A80( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z628LogEmailSubject = A628LogEmailSubject;
            Z629LogEmailDestinatario = A629LogEmailDestinatario;
            Z630LogEmailCreatedAt = A630LogEmailCreatedAt;
         }
         if ( GX_JID == -1 )
         {
            Z626LogEmailId = A626LogEmailId;
            Z627LogEmailCorpo = A627LogEmailCorpo;
            Z628LogEmailSubject = A628LogEmailSubject;
            Z629LogEmailDestinatario = A629LogEmailDestinatario;
            Z630LogEmailCreatedAt = A630LogEmailCreatedAt;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load2A80( )
      {
         /* Using cursor BC002A4 */
         pr_default.execute(2, new Object[] {A626LogEmailId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound80 = 1;
            A627LogEmailCorpo = BC002A4_A627LogEmailCorpo[0];
            n627LogEmailCorpo = BC002A4_n627LogEmailCorpo[0];
            A628LogEmailSubject = BC002A4_A628LogEmailSubject[0];
            n628LogEmailSubject = BC002A4_n628LogEmailSubject[0];
            A629LogEmailDestinatario = BC002A4_A629LogEmailDestinatario[0];
            n629LogEmailDestinatario = BC002A4_n629LogEmailDestinatario[0];
            A630LogEmailCreatedAt = BC002A4_A630LogEmailCreatedAt[0];
            n630LogEmailCreatedAt = BC002A4_n630LogEmailCreatedAt[0];
            ZM2A80( -1) ;
         }
         pr_default.close(2);
         OnLoadActions2A80( ) ;
      }

      protected void OnLoadActions2A80( )
      {
      }

      protected void CheckExtendedTable2A80( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors2A80( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2A80( )
      {
         /* Using cursor BC002A5 */
         pr_default.execute(3, new Object[] {A626LogEmailId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound80 = 1;
         }
         else
         {
            RcdFound80 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC002A3 */
         pr_default.execute(1, new Object[] {A626LogEmailId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2A80( 1) ;
            RcdFound80 = 1;
            A626LogEmailId = BC002A3_A626LogEmailId[0];
            A627LogEmailCorpo = BC002A3_A627LogEmailCorpo[0];
            n627LogEmailCorpo = BC002A3_n627LogEmailCorpo[0];
            A628LogEmailSubject = BC002A3_A628LogEmailSubject[0];
            n628LogEmailSubject = BC002A3_n628LogEmailSubject[0];
            A629LogEmailDestinatario = BC002A3_A629LogEmailDestinatario[0];
            n629LogEmailDestinatario = BC002A3_n629LogEmailDestinatario[0];
            A630LogEmailCreatedAt = BC002A3_A630LogEmailCreatedAt[0];
            n630LogEmailCreatedAt = BC002A3_n630LogEmailCreatedAt[0];
            Z626LogEmailId = A626LogEmailId;
            sMode80 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2A80( ) ;
            if ( AnyError == 1 )
            {
               RcdFound80 = 0;
               InitializeNonKey2A80( ) ;
            }
            Gx_mode = sMode80;
         }
         else
         {
            RcdFound80 = 0;
            InitializeNonKey2A80( ) ;
            sMode80 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode80;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2A80( ) ;
         if ( RcdFound80 == 0 )
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
         CONFIRM_2A0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2A80( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC002A2 */
            pr_default.execute(0, new Object[] {A626LogEmailId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"LogEmail"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z628LogEmailSubject, BC002A2_A628LogEmailSubject[0]) != 0 ) || ( StringUtil.StrCmp(Z629LogEmailDestinatario, BC002A2_A629LogEmailDestinatario[0]) != 0 ) || ( Z630LogEmailCreatedAt != BC002A2_A630LogEmailCreatedAt[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"LogEmail"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2A80( )
      {
         BeforeValidate2A80( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2A80( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2A80( 0) ;
            CheckOptimisticConcurrency2A80( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2A80( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2A80( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002A6 */
                     pr_default.execute(4, new Object[] {n627LogEmailCorpo, A627LogEmailCorpo, n628LogEmailSubject, A628LogEmailSubject, n629LogEmailDestinatario, A629LogEmailDestinatario, n630LogEmailCreatedAt, A630LogEmailCreatedAt});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC002A7 */
                     pr_default.execute(5);
                     A626LogEmailId = BC002A7_A626LogEmailId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("LogEmail");
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
               Load2A80( ) ;
            }
            EndLevel2A80( ) ;
         }
         CloseExtendedTableCursors2A80( ) ;
      }

      protected void Update2A80( )
      {
         BeforeValidate2A80( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2A80( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2A80( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2A80( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2A80( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002A8 */
                     pr_default.execute(6, new Object[] {n627LogEmailCorpo, A627LogEmailCorpo, n628LogEmailSubject, A628LogEmailSubject, n629LogEmailDestinatario, A629LogEmailDestinatario, n630LogEmailCreatedAt, A630LogEmailCreatedAt, A626LogEmailId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("LogEmail");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"LogEmail"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2A80( ) ;
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
            EndLevel2A80( ) ;
         }
         CloseExtendedTableCursors2A80( ) ;
      }

      protected void DeferredUpdate2A80( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2A80( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2A80( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2A80( ) ;
            AfterConfirm2A80( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2A80( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002A9 */
                  pr_default.execute(7, new Object[] {A626LogEmailId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("LogEmail");
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
         sMode80 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2A80( ) ;
         Gx_mode = sMode80;
      }

      protected void OnDeleteControls2A80( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2A80( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2A80( ) ;
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

      public void ScanKeyStart2A80( )
      {
         /* Using cursor BC002A10 */
         pr_default.execute(8, new Object[] {A626LogEmailId});
         RcdFound80 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound80 = 1;
            A626LogEmailId = BC002A10_A626LogEmailId[0];
            A627LogEmailCorpo = BC002A10_A627LogEmailCorpo[0];
            n627LogEmailCorpo = BC002A10_n627LogEmailCorpo[0];
            A628LogEmailSubject = BC002A10_A628LogEmailSubject[0];
            n628LogEmailSubject = BC002A10_n628LogEmailSubject[0];
            A629LogEmailDestinatario = BC002A10_A629LogEmailDestinatario[0];
            n629LogEmailDestinatario = BC002A10_n629LogEmailDestinatario[0];
            A630LogEmailCreatedAt = BC002A10_A630LogEmailCreatedAt[0];
            n630LogEmailCreatedAt = BC002A10_n630LogEmailCreatedAt[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2A80( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound80 = 0;
         ScanKeyLoad2A80( ) ;
      }

      protected void ScanKeyLoad2A80( )
      {
         sMode80 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound80 = 1;
            A626LogEmailId = BC002A10_A626LogEmailId[0];
            A627LogEmailCorpo = BC002A10_A627LogEmailCorpo[0];
            n627LogEmailCorpo = BC002A10_n627LogEmailCorpo[0];
            A628LogEmailSubject = BC002A10_A628LogEmailSubject[0];
            n628LogEmailSubject = BC002A10_n628LogEmailSubject[0];
            A629LogEmailDestinatario = BC002A10_A629LogEmailDestinatario[0];
            n629LogEmailDestinatario = BC002A10_n629LogEmailDestinatario[0];
            A630LogEmailCreatedAt = BC002A10_A630LogEmailCreatedAt[0];
            n630LogEmailCreatedAt = BC002A10_n630LogEmailCreatedAt[0];
         }
         Gx_mode = sMode80;
      }

      protected void ScanKeyEnd2A80( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm2A80( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2A80( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2A80( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2A80( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2A80( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2A80( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2A80( )
      {
      }

      protected void send_integrity_lvl_hashes2A80( )
      {
      }

      protected void AddRow2A80( )
      {
         VarsToRow80( bcLogEmail) ;
      }

      protected void ReadRow2A80( )
      {
         RowToVars80( bcLogEmail, 1) ;
      }

      protected void InitializeNonKey2A80( )
      {
         A627LogEmailCorpo = "";
         n627LogEmailCorpo = false;
         A628LogEmailSubject = "";
         n628LogEmailSubject = false;
         A629LogEmailDestinatario = "";
         n629LogEmailDestinatario = false;
         A630LogEmailCreatedAt = (DateTime)(DateTime.MinValue);
         n630LogEmailCreatedAt = false;
         Z628LogEmailSubject = "";
         Z629LogEmailDestinatario = "";
         Z630LogEmailCreatedAt = (DateTime)(DateTime.MinValue);
      }

      protected void InitAll2A80( )
      {
         A626LogEmailId = 0;
         InitializeNonKey2A80( ) ;
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

      public void VarsToRow80( SdtLogEmail obj80 )
      {
         obj80.gxTpr_Mode = Gx_mode;
         obj80.gxTpr_Logemailcorpo = A627LogEmailCorpo;
         obj80.gxTpr_Logemailsubject = A628LogEmailSubject;
         obj80.gxTpr_Logemaildestinatario = A629LogEmailDestinatario;
         obj80.gxTpr_Logemailcreatedat = A630LogEmailCreatedAt;
         obj80.gxTpr_Logemailid = A626LogEmailId;
         obj80.gxTpr_Logemailid_Z = Z626LogEmailId;
         obj80.gxTpr_Logemailsubject_Z = Z628LogEmailSubject;
         obj80.gxTpr_Logemaildestinatario_Z = Z629LogEmailDestinatario;
         obj80.gxTpr_Logemailcreatedat_Z = Z630LogEmailCreatedAt;
         obj80.gxTpr_Logemailcorpo_N = (short)(Convert.ToInt16(n627LogEmailCorpo));
         obj80.gxTpr_Logemailsubject_N = (short)(Convert.ToInt16(n628LogEmailSubject));
         obj80.gxTpr_Logemaildestinatario_N = (short)(Convert.ToInt16(n629LogEmailDestinatario));
         obj80.gxTpr_Logemailcreatedat_N = (short)(Convert.ToInt16(n630LogEmailCreatedAt));
         obj80.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow80( SdtLogEmail obj80 )
      {
         obj80.gxTpr_Logemailid = A626LogEmailId;
         return  ;
      }

      public void RowToVars80( SdtLogEmail obj80 ,
                               int forceLoad )
      {
         Gx_mode = obj80.gxTpr_Mode;
         A627LogEmailCorpo = obj80.gxTpr_Logemailcorpo;
         n627LogEmailCorpo = false;
         A628LogEmailSubject = obj80.gxTpr_Logemailsubject;
         n628LogEmailSubject = false;
         A629LogEmailDestinatario = obj80.gxTpr_Logemaildestinatario;
         n629LogEmailDestinatario = false;
         A630LogEmailCreatedAt = obj80.gxTpr_Logemailcreatedat;
         n630LogEmailCreatedAt = false;
         A626LogEmailId = obj80.gxTpr_Logemailid;
         Z626LogEmailId = obj80.gxTpr_Logemailid_Z;
         Z628LogEmailSubject = obj80.gxTpr_Logemailsubject_Z;
         Z629LogEmailDestinatario = obj80.gxTpr_Logemaildestinatario_Z;
         Z630LogEmailCreatedAt = obj80.gxTpr_Logemailcreatedat_Z;
         n627LogEmailCorpo = (bool)(Convert.ToBoolean(obj80.gxTpr_Logemailcorpo_N));
         n628LogEmailSubject = (bool)(Convert.ToBoolean(obj80.gxTpr_Logemailsubject_N));
         n629LogEmailDestinatario = (bool)(Convert.ToBoolean(obj80.gxTpr_Logemaildestinatario_N));
         n630LogEmailCreatedAt = (bool)(Convert.ToBoolean(obj80.gxTpr_Logemailcreatedat_N));
         Gx_mode = obj80.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A626LogEmailId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2A80( ) ;
         ScanKeyStart2A80( ) ;
         if ( RcdFound80 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z626LogEmailId = A626LogEmailId;
         }
         ZM2A80( -1) ;
         OnLoadActions2A80( ) ;
         AddRow2A80( ) ;
         ScanKeyEnd2A80( ) ;
         if ( RcdFound80 == 0 )
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
         RowToVars80( bcLogEmail, 0) ;
         ScanKeyStart2A80( ) ;
         if ( RcdFound80 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z626LogEmailId = A626LogEmailId;
         }
         ZM2A80( -1) ;
         OnLoadActions2A80( ) ;
         AddRow2A80( ) ;
         ScanKeyEnd2A80( ) ;
         if ( RcdFound80 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2A80( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2A80( ) ;
         }
         else
         {
            if ( RcdFound80 == 1 )
            {
               if ( A626LogEmailId != Z626LogEmailId )
               {
                  A626LogEmailId = Z626LogEmailId;
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
                  Update2A80( ) ;
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
                  if ( A626LogEmailId != Z626LogEmailId )
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
                        Insert2A80( ) ;
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
                        Insert2A80( ) ;
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
         RowToVars80( bcLogEmail, 1) ;
         SaveImpl( ) ;
         VarsToRow80( bcLogEmail) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars80( bcLogEmail, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2A80( ) ;
         AfterTrn( ) ;
         VarsToRow80( bcLogEmail) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow80( bcLogEmail) ;
         }
         else
         {
            SdtLogEmail auxBC = new SdtLogEmail(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A626LogEmailId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcLogEmail);
               auxBC.Save();
               bcLogEmail.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars80( bcLogEmail, 1) ;
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
         RowToVars80( bcLogEmail, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2A80( ) ;
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
               VarsToRow80( bcLogEmail) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow80( bcLogEmail) ;
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
         RowToVars80( bcLogEmail, 0) ;
         GetKey2A80( ) ;
         if ( RcdFound80 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A626LogEmailId != Z626LogEmailId )
            {
               A626LogEmailId = Z626LogEmailId;
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
            if ( A626LogEmailId != Z626LogEmailId )
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
         context.RollbackDataStores("logemail_bc",pr_default);
         VarsToRow80( bcLogEmail) ;
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
         Gx_mode = bcLogEmail.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcLogEmail.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcLogEmail )
         {
            bcLogEmail = (SdtLogEmail)(sdt);
            if ( StringUtil.StrCmp(bcLogEmail.gxTpr_Mode, "") == 0 )
            {
               bcLogEmail.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow80( bcLogEmail) ;
            }
            else
            {
               RowToVars80( bcLogEmail, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcLogEmail.gxTpr_Mode, "") == 0 )
            {
               bcLogEmail.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars80( bcLogEmail, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtLogEmail LogEmail_BC
      {
         get {
            return bcLogEmail ;
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
         Z628LogEmailSubject = "";
         A628LogEmailSubject = "";
         Z629LogEmailDestinatario = "";
         A629LogEmailDestinatario = "";
         Z630LogEmailCreatedAt = (DateTime)(DateTime.MinValue);
         A630LogEmailCreatedAt = (DateTime)(DateTime.MinValue);
         Z627LogEmailCorpo = "";
         A627LogEmailCorpo = "";
         BC002A4_A626LogEmailId = new int[1] ;
         BC002A4_A627LogEmailCorpo = new string[] {""} ;
         BC002A4_n627LogEmailCorpo = new bool[] {false} ;
         BC002A4_A628LogEmailSubject = new string[] {""} ;
         BC002A4_n628LogEmailSubject = new bool[] {false} ;
         BC002A4_A629LogEmailDestinatario = new string[] {""} ;
         BC002A4_n629LogEmailDestinatario = new bool[] {false} ;
         BC002A4_A630LogEmailCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002A4_n630LogEmailCreatedAt = new bool[] {false} ;
         BC002A5_A626LogEmailId = new int[1] ;
         BC002A3_A626LogEmailId = new int[1] ;
         BC002A3_A627LogEmailCorpo = new string[] {""} ;
         BC002A3_n627LogEmailCorpo = new bool[] {false} ;
         BC002A3_A628LogEmailSubject = new string[] {""} ;
         BC002A3_n628LogEmailSubject = new bool[] {false} ;
         BC002A3_A629LogEmailDestinatario = new string[] {""} ;
         BC002A3_n629LogEmailDestinatario = new bool[] {false} ;
         BC002A3_A630LogEmailCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002A3_n630LogEmailCreatedAt = new bool[] {false} ;
         sMode80 = "";
         BC002A2_A626LogEmailId = new int[1] ;
         BC002A2_A627LogEmailCorpo = new string[] {""} ;
         BC002A2_n627LogEmailCorpo = new bool[] {false} ;
         BC002A2_A628LogEmailSubject = new string[] {""} ;
         BC002A2_n628LogEmailSubject = new bool[] {false} ;
         BC002A2_A629LogEmailDestinatario = new string[] {""} ;
         BC002A2_n629LogEmailDestinatario = new bool[] {false} ;
         BC002A2_A630LogEmailCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002A2_n630LogEmailCreatedAt = new bool[] {false} ;
         BC002A7_A626LogEmailId = new int[1] ;
         BC002A10_A626LogEmailId = new int[1] ;
         BC002A10_A627LogEmailCorpo = new string[] {""} ;
         BC002A10_n627LogEmailCorpo = new bool[] {false} ;
         BC002A10_A628LogEmailSubject = new string[] {""} ;
         BC002A10_n628LogEmailSubject = new bool[] {false} ;
         BC002A10_A629LogEmailDestinatario = new string[] {""} ;
         BC002A10_n629LogEmailDestinatario = new bool[] {false} ;
         BC002A10_A630LogEmailCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002A10_n630LogEmailCreatedAt = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.logemail_bc__default(),
            new Object[][] {
                new Object[] {
               BC002A2_A626LogEmailId, BC002A2_A627LogEmailCorpo, BC002A2_n627LogEmailCorpo, BC002A2_A628LogEmailSubject, BC002A2_n628LogEmailSubject, BC002A2_A629LogEmailDestinatario, BC002A2_n629LogEmailDestinatario, BC002A2_A630LogEmailCreatedAt, BC002A2_n630LogEmailCreatedAt
               }
               , new Object[] {
               BC002A3_A626LogEmailId, BC002A3_A627LogEmailCorpo, BC002A3_n627LogEmailCorpo, BC002A3_A628LogEmailSubject, BC002A3_n628LogEmailSubject, BC002A3_A629LogEmailDestinatario, BC002A3_n629LogEmailDestinatario, BC002A3_A630LogEmailCreatedAt, BC002A3_n630LogEmailCreatedAt
               }
               , new Object[] {
               BC002A4_A626LogEmailId, BC002A4_A627LogEmailCorpo, BC002A4_n627LogEmailCorpo, BC002A4_A628LogEmailSubject, BC002A4_n628LogEmailSubject, BC002A4_A629LogEmailDestinatario, BC002A4_n629LogEmailDestinatario, BC002A4_A630LogEmailCreatedAt, BC002A4_n630LogEmailCreatedAt
               }
               , new Object[] {
               BC002A5_A626LogEmailId
               }
               , new Object[] {
               }
               , new Object[] {
               BC002A7_A626LogEmailId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002A10_A626LogEmailId, BC002A10_A627LogEmailCorpo, BC002A10_n627LogEmailCorpo, BC002A10_A628LogEmailSubject, BC002A10_n628LogEmailSubject, BC002A10_A629LogEmailDestinatario, BC002A10_n629LogEmailDestinatario, BC002A10_A630LogEmailCreatedAt, BC002A10_n630LogEmailCreatedAt
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound80 ;
      private int trnEnded ;
      private int Z626LogEmailId ;
      private int A626LogEmailId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode80 ;
      private DateTime Z630LogEmailCreatedAt ;
      private DateTime A630LogEmailCreatedAt ;
      private bool n627LogEmailCorpo ;
      private bool n628LogEmailSubject ;
      private bool n629LogEmailDestinatario ;
      private bool n630LogEmailCreatedAt ;
      private string Z627LogEmailCorpo ;
      private string A627LogEmailCorpo ;
      private string Z628LogEmailSubject ;
      private string A628LogEmailSubject ;
      private string Z629LogEmailDestinatario ;
      private string A629LogEmailDestinatario ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC002A4_A626LogEmailId ;
      private string[] BC002A4_A627LogEmailCorpo ;
      private bool[] BC002A4_n627LogEmailCorpo ;
      private string[] BC002A4_A628LogEmailSubject ;
      private bool[] BC002A4_n628LogEmailSubject ;
      private string[] BC002A4_A629LogEmailDestinatario ;
      private bool[] BC002A4_n629LogEmailDestinatario ;
      private DateTime[] BC002A4_A630LogEmailCreatedAt ;
      private bool[] BC002A4_n630LogEmailCreatedAt ;
      private int[] BC002A5_A626LogEmailId ;
      private int[] BC002A3_A626LogEmailId ;
      private string[] BC002A3_A627LogEmailCorpo ;
      private bool[] BC002A3_n627LogEmailCorpo ;
      private string[] BC002A3_A628LogEmailSubject ;
      private bool[] BC002A3_n628LogEmailSubject ;
      private string[] BC002A3_A629LogEmailDestinatario ;
      private bool[] BC002A3_n629LogEmailDestinatario ;
      private DateTime[] BC002A3_A630LogEmailCreatedAt ;
      private bool[] BC002A3_n630LogEmailCreatedAt ;
      private int[] BC002A2_A626LogEmailId ;
      private string[] BC002A2_A627LogEmailCorpo ;
      private bool[] BC002A2_n627LogEmailCorpo ;
      private string[] BC002A2_A628LogEmailSubject ;
      private bool[] BC002A2_n628LogEmailSubject ;
      private string[] BC002A2_A629LogEmailDestinatario ;
      private bool[] BC002A2_n629LogEmailDestinatario ;
      private DateTime[] BC002A2_A630LogEmailCreatedAt ;
      private bool[] BC002A2_n630LogEmailCreatedAt ;
      private int[] BC002A7_A626LogEmailId ;
      private int[] BC002A10_A626LogEmailId ;
      private string[] BC002A10_A627LogEmailCorpo ;
      private bool[] BC002A10_n627LogEmailCorpo ;
      private string[] BC002A10_A628LogEmailSubject ;
      private bool[] BC002A10_n628LogEmailSubject ;
      private string[] BC002A10_A629LogEmailDestinatario ;
      private bool[] BC002A10_n629LogEmailDestinatario ;
      private DateTime[] BC002A10_A630LogEmailCreatedAt ;
      private bool[] BC002A10_n630LogEmailCreatedAt ;
      private SdtLogEmail bcLogEmail ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class logemail_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC002A2;
          prmBC002A2 = new Object[] {
          new ParDef("LogEmailId",GXType.Int32,9,0)
          };
          Object[] prmBC002A3;
          prmBC002A3 = new Object[] {
          new ParDef("LogEmailId",GXType.Int32,9,0)
          };
          Object[] prmBC002A4;
          prmBC002A4 = new Object[] {
          new ParDef("LogEmailId",GXType.Int32,9,0)
          };
          Object[] prmBC002A5;
          prmBC002A5 = new Object[] {
          new ParDef("LogEmailId",GXType.Int32,9,0)
          };
          Object[] prmBC002A6;
          prmBC002A6 = new Object[] {
          new ParDef("LogEmailCorpo",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("LogEmailSubject",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("LogEmailDestinatario",GXType.VarChar,255,0){Nullable=true} ,
          new ParDef("LogEmailCreatedAt",GXType.DateTime,8,5){Nullable=true}
          };
          Object[] prmBC002A7;
          prmBC002A7 = new Object[] {
          };
          Object[] prmBC002A8;
          prmBC002A8 = new Object[] {
          new ParDef("LogEmailCorpo",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("LogEmailSubject",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("LogEmailDestinatario",GXType.VarChar,255,0){Nullable=true} ,
          new ParDef("LogEmailCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("LogEmailId",GXType.Int32,9,0)
          };
          Object[] prmBC002A9;
          prmBC002A9 = new Object[] {
          new ParDef("LogEmailId",GXType.Int32,9,0)
          };
          Object[] prmBC002A10;
          prmBC002A10 = new Object[] {
          new ParDef("LogEmailId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC002A2", "SELECT LogEmailId, LogEmailCorpo, LogEmailSubject, LogEmailDestinatario, LogEmailCreatedAt FROM LogEmail WHERE LogEmailId = :LogEmailId  FOR UPDATE OF LogEmail",true, GxErrorMask.GX_NOMASK, false, this,prmBC002A2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002A3", "SELECT LogEmailId, LogEmailCorpo, LogEmailSubject, LogEmailDestinatario, LogEmailCreatedAt FROM LogEmail WHERE LogEmailId = :LogEmailId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002A3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002A4", "SELECT TM1.LogEmailId, TM1.LogEmailCorpo, TM1.LogEmailSubject, TM1.LogEmailDestinatario, TM1.LogEmailCreatedAt FROM LogEmail TM1 WHERE TM1.LogEmailId = :LogEmailId ORDER BY TM1.LogEmailId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002A4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002A5", "SELECT LogEmailId FROM LogEmail WHERE LogEmailId = :LogEmailId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002A5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002A6", "SAVEPOINT gxupdate;INSERT INTO LogEmail(LogEmailCorpo, LogEmailSubject, LogEmailDestinatario, LogEmailCreatedAt) VALUES(:LogEmailCorpo, :LogEmailSubject, :LogEmailDestinatario, :LogEmailCreatedAt);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC002A6)
             ,new CursorDef("BC002A7", "SELECT currval('LogEmailId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002A7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002A8", "SAVEPOINT gxupdate;UPDATE LogEmail SET LogEmailCorpo=:LogEmailCorpo, LogEmailSubject=:LogEmailSubject, LogEmailDestinatario=:LogEmailDestinatario, LogEmailCreatedAt=:LogEmailCreatedAt  WHERE LogEmailId = :LogEmailId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002A8)
             ,new CursorDef("BC002A9", "SAVEPOINT gxupdate;DELETE FROM LogEmail  WHERE LogEmailId = :LogEmailId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002A9)
             ,new CursorDef("BC002A10", "SELECT TM1.LogEmailId, TM1.LogEmailCorpo, TM1.LogEmailSubject, TM1.LogEmailDestinatario, TM1.LogEmailCreatedAt FROM LogEmail TM1 WHERE TM1.LogEmailId = :LogEmailId ORDER BY TM1.LogEmailId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002A10,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}
