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
   public class secuserlog_bc : GxSilentTrn, IGxSilentTrn
   {
      public secuserlog_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secuserlog_bc( IGxContext context )
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
         ReadRow2577( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2577( ) ;
         standaloneModal( ) ;
         AddRow2577( ) ;
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
            E11252 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z559SecUserLogId = A559SecUserLogId;
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

      protected void CONFIRM_250( )
      {
         BeforeValidate2577( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2577( ) ;
            }
            else
            {
               CheckExtendedTable2577( ) ;
               if ( AnyError == 0 )
               {
                  ZM2577( 4) ;
               }
               CloseExtendedTableCursors2577( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12252( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV19Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV20GXV1 = 1;
            while ( AV20GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV20GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "SecUserId") == 0 )
               {
                  AV11Insert_SecUserId = (short)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV20GXV1 = (int)(AV20GXV1+1);
            }
         }
      }

      protected void E11252( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM2577( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z560SecUserLogDateTime = A560SecUserLogDateTime;
            Z133SecUserId = A133SecUserId;
         }
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z141SecUserName = A141SecUserName;
            Z143SecUserFullName = A143SecUserFullName;
         }
         if ( GX_JID == -3 )
         {
            Z559SecUserLogId = A559SecUserLogId;
            Z560SecUserLogDateTime = A560SecUserLogDateTime;
            Z133SecUserId = A133SecUserId;
            Z141SecUserName = A141SecUserName;
            Z143SecUserFullName = A143SecUserFullName;
         }
      }

      protected void standaloneNotModal( )
      {
         AV19Pgmname = "SecUserLog_BC";
      }

      protected void standaloneModal( )
      {
      }

      protected void Load2577( )
      {
         /* Using cursor BC00255 */
         pr_default.execute(3, new Object[] {A559SecUserLogId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound77 = 1;
            A141SecUserName = BC00255_A141SecUserName[0];
            n141SecUserName = BC00255_n141SecUserName[0];
            A143SecUserFullName = BC00255_A143SecUserFullName[0];
            n143SecUserFullName = BC00255_n143SecUserFullName[0];
            A560SecUserLogDateTime = BC00255_A560SecUserLogDateTime[0];
            n560SecUserLogDateTime = BC00255_n560SecUserLogDateTime[0];
            A133SecUserId = BC00255_A133SecUserId[0];
            n133SecUserId = BC00255_n133SecUserId[0];
            ZM2577( -3) ;
         }
         pr_default.close(3);
         OnLoadActions2577( ) ;
      }

      protected void OnLoadActions2577( )
      {
      }

      protected void CheckExtendedTable2577( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00254 */
         pr_default.execute(2, new Object[] {n133SecUserId, A133SecUserId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A133SecUserId) ) )
            {
               GX_msglist.addItem("Não existe 'User'.", "ForeignKeyNotFound", 1, "SECUSERID");
               AnyError = 1;
            }
         }
         A141SecUserName = BC00254_A141SecUserName[0];
         n141SecUserName = BC00254_n141SecUserName[0];
         A143SecUserFullName = BC00254_A143SecUserFullName[0];
         n143SecUserFullName = BC00254_n143SecUserFullName[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors2577( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2577( )
      {
         /* Using cursor BC00256 */
         pr_default.execute(4, new Object[] {A559SecUserLogId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound77 = 1;
         }
         else
         {
            RcdFound77 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00253 */
         pr_default.execute(1, new Object[] {A559SecUserLogId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2577( 3) ;
            RcdFound77 = 1;
            A559SecUserLogId = BC00253_A559SecUserLogId[0];
            A560SecUserLogDateTime = BC00253_A560SecUserLogDateTime[0];
            n560SecUserLogDateTime = BC00253_n560SecUserLogDateTime[0];
            A133SecUserId = BC00253_A133SecUserId[0];
            n133SecUserId = BC00253_n133SecUserId[0];
            Z559SecUserLogId = A559SecUserLogId;
            sMode77 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2577( ) ;
            if ( AnyError == 1 )
            {
               RcdFound77 = 0;
               InitializeNonKey2577( ) ;
            }
            Gx_mode = sMode77;
         }
         else
         {
            RcdFound77 = 0;
            InitializeNonKey2577( ) ;
            sMode77 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode77;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2577( ) ;
         if ( RcdFound77 == 0 )
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
         CONFIRM_250( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2577( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00252 */
            pr_default.execute(0, new Object[] {A559SecUserLogId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecUserLog"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z560SecUserLogDateTime != BC00252_A560SecUserLogDateTime[0] ) || ( Z133SecUserId != BC00252_A133SecUserId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SecUserLog"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2577( )
      {
         BeforeValidate2577( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2577( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2577( 0) ;
            CheckOptimisticConcurrency2577( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2577( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2577( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00257 */
                     pr_default.execute(5, new Object[] {n560SecUserLogDateTime, A560SecUserLogDateTime, n133SecUserId, A133SecUserId});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC00258 */
                     pr_default.execute(6);
                     A559SecUserLogId = BC00258_A559SecUserLogId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("SecUserLog");
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
               Load2577( ) ;
            }
            EndLevel2577( ) ;
         }
         CloseExtendedTableCursors2577( ) ;
      }

      protected void Update2577( )
      {
         BeforeValidate2577( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2577( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2577( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2577( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2577( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00259 */
                     pr_default.execute(7, new Object[] {n560SecUserLogDateTime, A560SecUserLogDateTime, n133SecUserId, A133SecUserId, A559SecUserLogId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("SecUserLog");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecUserLog"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2577( ) ;
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
            EndLevel2577( ) ;
         }
         CloseExtendedTableCursors2577( ) ;
      }

      protected void DeferredUpdate2577( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2577( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2577( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2577( ) ;
            AfterConfirm2577( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2577( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002510 */
                  pr_default.execute(8, new Object[] {A559SecUserLogId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("SecUserLog");
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
         sMode77 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2577( ) ;
         Gx_mode = sMode77;
      }

      protected void OnDeleteControls2577( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC002511 */
            pr_default.execute(9, new Object[] {n133SecUserId, A133SecUserId});
            A141SecUserName = BC002511_A141SecUserName[0];
            n141SecUserName = BC002511_n141SecUserName[0];
            A143SecUserFullName = BC002511_A143SecUserFullName[0];
            n143SecUserFullName = BC002511_n143SecUserFullName[0];
            pr_default.close(9);
         }
      }

      protected void EndLevel2577( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2577( ) ;
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

      public void ScanKeyStart2577( )
      {
         /* Scan By routine */
         /* Using cursor BC002512 */
         pr_default.execute(10, new Object[] {A559SecUserLogId});
         RcdFound77 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound77 = 1;
            A559SecUserLogId = BC002512_A559SecUserLogId[0];
            A141SecUserName = BC002512_A141SecUserName[0];
            n141SecUserName = BC002512_n141SecUserName[0];
            A143SecUserFullName = BC002512_A143SecUserFullName[0];
            n143SecUserFullName = BC002512_n143SecUserFullName[0];
            A560SecUserLogDateTime = BC002512_A560SecUserLogDateTime[0];
            n560SecUserLogDateTime = BC002512_n560SecUserLogDateTime[0];
            A133SecUserId = BC002512_A133SecUserId[0];
            n133SecUserId = BC002512_n133SecUserId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2577( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound77 = 0;
         ScanKeyLoad2577( ) ;
      }

      protected void ScanKeyLoad2577( )
      {
         sMode77 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound77 = 1;
            A559SecUserLogId = BC002512_A559SecUserLogId[0];
            A141SecUserName = BC002512_A141SecUserName[0];
            n141SecUserName = BC002512_n141SecUserName[0];
            A143SecUserFullName = BC002512_A143SecUserFullName[0];
            n143SecUserFullName = BC002512_n143SecUserFullName[0];
            A560SecUserLogDateTime = BC002512_A560SecUserLogDateTime[0];
            n560SecUserLogDateTime = BC002512_n560SecUserLogDateTime[0];
            A133SecUserId = BC002512_A133SecUserId[0];
            n133SecUserId = BC002512_n133SecUserId[0];
         }
         Gx_mode = sMode77;
      }

      protected void ScanKeyEnd2577( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm2577( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2577( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2577( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2577( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2577( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2577( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2577( )
      {
      }

      protected void send_integrity_lvl_hashes2577( )
      {
      }

      protected void AddRow2577( )
      {
         VarsToRow77( bcSecUserLog) ;
      }

      protected void ReadRow2577( )
      {
         RowToVars77( bcSecUserLog, 1) ;
      }

      protected void InitializeNonKey2577( )
      {
         A133SecUserId = 0;
         n133SecUserId = false;
         A141SecUserName = "";
         n141SecUserName = false;
         A143SecUserFullName = "";
         n143SecUserFullName = false;
         A560SecUserLogDateTime = (DateTime)(DateTime.MinValue);
         n560SecUserLogDateTime = false;
         Z560SecUserLogDateTime = (DateTime)(DateTime.MinValue);
         Z133SecUserId = 0;
      }

      protected void InitAll2577( )
      {
         A559SecUserLogId = 0;
         InitializeNonKey2577( ) ;
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

      public void VarsToRow77( SdtSecUserLog obj77 )
      {
         obj77.gxTpr_Mode = Gx_mode;
         obj77.gxTpr_Secuserid = A133SecUserId;
         obj77.gxTpr_Secusername = A141SecUserName;
         obj77.gxTpr_Secuserfullname = A143SecUserFullName;
         obj77.gxTpr_Secuserlogdatetime = A560SecUserLogDateTime;
         obj77.gxTpr_Secuserlogid = A559SecUserLogId;
         obj77.gxTpr_Secuserlogid_Z = Z559SecUserLogId;
         obj77.gxTpr_Secuserid_Z = Z133SecUserId;
         obj77.gxTpr_Secusername_Z = Z141SecUserName;
         obj77.gxTpr_Secuserfullname_Z = Z143SecUserFullName;
         obj77.gxTpr_Secuserlogdatetime_Z = Z560SecUserLogDateTime;
         obj77.gxTpr_Secuserid_N = (short)(Convert.ToInt16(n133SecUserId));
         obj77.gxTpr_Secusername_N = (short)(Convert.ToInt16(n141SecUserName));
         obj77.gxTpr_Secuserfullname_N = (short)(Convert.ToInt16(n143SecUserFullName));
         obj77.gxTpr_Secuserlogdatetime_N = (short)(Convert.ToInt16(n560SecUserLogDateTime));
         obj77.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow77( SdtSecUserLog obj77 )
      {
         obj77.gxTpr_Secuserlogid = A559SecUserLogId;
         return  ;
      }

      public void RowToVars77( SdtSecUserLog obj77 ,
                               int forceLoad )
      {
         Gx_mode = obj77.gxTpr_Mode;
         A133SecUserId = obj77.gxTpr_Secuserid;
         n133SecUserId = false;
         A141SecUserName = obj77.gxTpr_Secusername;
         n141SecUserName = false;
         A143SecUserFullName = obj77.gxTpr_Secuserfullname;
         n143SecUserFullName = false;
         A560SecUserLogDateTime = obj77.gxTpr_Secuserlogdatetime;
         n560SecUserLogDateTime = false;
         A559SecUserLogId = obj77.gxTpr_Secuserlogid;
         Z559SecUserLogId = obj77.gxTpr_Secuserlogid_Z;
         Z133SecUserId = obj77.gxTpr_Secuserid_Z;
         Z141SecUserName = obj77.gxTpr_Secusername_Z;
         Z143SecUserFullName = obj77.gxTpr_Secuserfullname_Z;
         Z560SecUserLogDateTime = obj77.gxTpr_Secuserlogdatetime_Z;
         n133SecUserId = (bool)(Convert.ToBoolean(obj77.gxTpr_Secuserid_N));
         n141SecUserName = (bool)(Convert.ToBoolean(obj77.gxTpr_Secusername_N));
         n143SecUserFullName = (bool)(Convert.ToBoolean(obj77.gxTpr_Secuserfullname_N));
         n560SecUserLogDateTime = (bool)(Convert.ToBoolean(obj77.gxTpr_Secuserlogdatetime_N));
         Gx_mode = obj77.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A559SecUserLogId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2577( ) ;
         ScanKeyStart2577( ) ;
         if ( RcdFound77 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z559SecUserLogId = A559SecUserLogId;
         }
         ZM2577( -3) ;
         OnLoadActions2577( ) ;
         AddRow2577( ) ;
         ScanKeyEnd2577( ) ;
         if ( RcdFound77 == 0 )
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
         RowToVars77( bcSecUserLog, 0) ;
         ScanKeyStart2577( ) ;
         if ( RcdFound77 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z559SecUserLogId = A559SecUserLogId;
         }
         ZM2577( -3) ;
         OnLoadActions2577( ) ;
         AddRow2577( ) ;
         ScanKeyEnd2577( ) ;
         if ( RcdFound77 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2577( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2577( ) ;
         }
         else
         {
            if ( RcdFound77 == 1 )
            {
               if ( A559SecUserLogId != Z559SecUserLogId )
               {
                  A559SecUserLogId = Z559SecUserLogId;
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
                  Update2577( ) ;
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
                  if ( A559SecUserLogId != Z559SecUserLogId )
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
                        Insert2577( ) ;
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
                        Insert2577( ) ;
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
         RowToVars77( bcSecUserLog, 1) ;
         SaveImpl( ) ;
         VarsToRow77( bcSecUserLog) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars77( bcSecUserLog, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2577( ) ;
         AfterTrn( ) ;
         VarsToRow77( bcSecUserLog) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow77( bcSecUserLog) ;
         }
         else
         {
            SdtSecUserLog auxBC = new SdtSecUserLog(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A559SecUserLogId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcSecUserLog);
               auxBC.Save();
               bcSecUserLog.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars77( bcSecUserLog, 1) ;
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
         RowToVars77( bcSecUserLog, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2577( ) ;
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
               VarsToRow77( bcSecUserLog) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow77( bcSecUserLog) ;
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
         RowToVars77( bcSecUserLog, 0) ;
         GetKey2577( ) ;
         if ( RcdFound77 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A559SecUserLogId != Z559SecUserLogId )
            {
               A559SecUserLogId = Z559SecUserLogId;
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
            if ( A559SecUserLogId != Z559SecUserLogId )
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
         context.RollbackDataStores("secuserlog_bc",pr_default);
         VarsToRow77( bcSecUserLog) ;
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
         Gx_mode = bcSecUserLog.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcSecUserLog.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcSecUserLog )
         {
            bcSecUserLog = (SdtSecUserLog)(sdt);
            if ( StringUtil.StrCmp(bcSecUserLog.gxTpr_Mode, "") == 0 )
            {
               bcSecUserLog.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow77( bcSecUserLog) ;
            }
            else
            {
               RowToVars77( bcSecUserLog, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcSecUserLog.gxTpr_Mode, "") == 0 )
            {
               bcSecUserLog.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars77( bcSecUserLog, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtSecUserLog SecUserLog_BC
      {
         get {
            return bcSecUserLog ;
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
         pr_default.close(9);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV19Pgmname = "";
         AV12TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z560SecUserLogDateTime = (DateTime)(DateTime.MinValue);
         A560SecUserLogDateTime = (DateTime)(DateTime.MinValue);
         Z141SecUserName = "";
         A141SecUserName = "";
         Z143SecUserFullName = "";
         A143SecUserFullName = "";
         BC00255_A559SecUserLogId = new int[1] ;
         BC00255_A141SecUserName = new string[] {""} ;
         BC00255_n141SecUserName = new bool[] {false} ;
         BC00255_A143SecUserFullName = new string[] {""} ;
         BC00255_n143SecUserFullName = new bool[] {false} ;
         BC00255_A560SecUserLogDateTime = new DateTime[] {DateTime.MinValue} ;
         BC00255_n560SecUserLogDateTime = new bool[] {false} ;
         BC00255_A133SecUserId = new short[1] ;
         BC00255_n133SecUserId = new bool[] {false} ;
         BC00254_A141SecUserName = new string[] {""} ;
         BC00254_n141SecUserName = new bool[] {false} ;
         BC00254_A143SecUserFullName = new string[] {""} ;
         BC00254_n143SecUserFullName = new bool[] {false} ;
         BC00256_A559SecUserLogId = new int[1] ;
         BC00253_A559SecUserLogId = new int[1] ;
         BC00253_A560SecUserLogDateTime = new DateTime[] {DateTime.MinValue} ;
         BC00253_n560SecUserLogDateTime = new bool[] {false} ;
         BC00253_A133SecUserId = new short[1] ;
         BC00253_n133SecUserId = new bool[] {false} ;
         sMode77 = "";
         BC00252_A559SecUserLogId = new int[1] ;
         BC00252_A560SecUserLogDateTime = new DateTime[] {DateTime.MinValue} ;
         BC00252_n560SecUserLogDateTime = new bool[] {false} ;
         BC00252_A133SecUserId = new short[1] ;
         BC00252_n133SecUserId = new bool[] {false} ;
         BC00258_A559SecUserLogId = new int[1] ;
         BC002511_A141SecUserName = new string[] {""} ;
         BC002511_n141SecUserName = new bool[] {false} ;
         BC002511_A143SecUserFullName = new string[] {""} ;
         BC002511_n143SecUserFullName = new bool[] {false} ;
         BC002512_A559SecUserLogId = new int[1] ;
         BC002512_A141SecUserName = new string[] {""} ;
         BC002512_n141SecUserName = new bool[] {false} ;
         BC002512_A143SecUserFullName = new string[] {""} ;
         BC002512_n143SecUserFullName = new bool[] {false} ;
         BC002512_A560SecUserLogDateTime = new DateTime[] {DateTime.MinValue} ;
         BC002512_n560SecUserLogDateTime = new bool[] {false} ;
         BC002512_A133SecUserId = new short[1] ;
         BC002512_n133SecUserId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.secuserlog_bc__default(),
            new Object[][] {
                new Object[] {
               BC00252_A559SecUserLogId, BC00252_A560SecUserLogDateTime, BC00252_n560SecUserLogDateTime, BC00252_A133SecUserId, BC00252_n133SecUserId
               }
               , new Object[] {
               BC00253_A559SecUserLogId, BC00253_A560SecUserLogDateTime, BC00253_n560SecUserLogDateTime, BC00253_A133SecUserId, BC00253_n133SecUserId
               }
               , new Object[] {
               BC00254_A141SecUserName, BC00254_n141SecUserName, BC00254_A143SecUserFullName, BC00254_n143SecUserFullName
               }
               , new Object[] {
               BC00255_A559SecUserLogId, BC00255_A141SecUserName, BC00255_n141SecUserName, BC00255_A143SecUserFullName, BC00255_n143SecUserFullName, BC00255_A560SecUserLogDateTime, BC00255_n560SecUserLogDateTime, BC00255_A133SecUserId, BC00255_n133SecUserId
               }
               , new Object[] {
               BC00256_A559SecUserLogId
               }
               , new Object[] {
               }
               , new Object[] {
               BC00258_A559SecUserLogId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002511_A141SecUserName, BC002511_n141SecUserName, BC002511_A143SecUserFullName, BC002511_n143SecUserFullName
               }
               , new Object[] {
               BC002512_A559SecUserLogId, BC002512_A141SecUserName, BC002512_n141SecUserName, BC002512_A143SecUserFullName, BC002512_n143SecUserFullName, BC002512_A560SecUserLogDateTime, BC002512_n560SecUserLogDateTime, BC002512_A133SecUserId, BC002512_n133SecUserId
               }
            }
         );
         AV19Pgmname = "SecUserLog_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12252 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short AV11Insert_SecUserId ;
      private short Z133SecUserId ;
      private short A133SecUserId ;
      private short RcdFound77 ;
      private int trnEnded ;
      private int Z559SecUserLogId ;
      private int A559SecUserLogId ;
      private int AV20GXV1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV19Pgmname ;
      private string sMode77 ;
      private DateTime Z560SecUserLogDateTime ;
      private DateTime A560SecUserLogDateTime ;
      private bool returnInSub ;
      private bool n141SecUserName ;
      private bool n143SecUserFullName ;
      private bool n560SecUserLogDateTime ;
      private bool n133SecUserId ;
      private string Z141SecUserName ;
      private string A141SecUserName ;
      private string Z143SecUserFullName ;
      private string A143SecUserFullName ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] BC00255_A559SecUserLogId ;
      private string[] BC00255_A141SecUserName ;
      private bool[] BC00255_n141SecUserName ;
      private string[] BC00255_A143SecUserFullName ;
      private bool[] BC00255_n143SecUserFullName ;
      private DateTime[] BC00255_A560SecUserLogDateTime ;
      private bool[] BC00255_n560SecUserLogDateTime ;
      private short[] BC00255_A133SecUserId ;
      private bool[] BC00255_n133SecUserId ;
      private string[] BC00254_A141SecUserName ;
      private bool[] BC00254_n141SecUserName ;
      private string[] BC00254_A143SecUserFullName ;
      private bool[] BC00254_n143SecUserFullName ;
      private int[] BC00256_A559SecUserLogId ;
      private int[] BC00253_A559SecUserLogId ;
      private DateTime[] BC00253_A560SecUserLogDateTime ;
      private bool[] BC00253_n560SecUserLogDateTime ;
      private short[] BC00253_A133SecUserId ;
      private bool[] BC00253_n133SecUserId ;
      private int[] BC00252_A559SecUserLogId ;
      private DateTime[] BC00252_A560SecUserLogDateTime ;
      private bool[] BC00252_n560SecUserLogDateTime ;
      private short[] BC00252_A133SecUserId ;
      private bool[] BC00252_n133SecUserId ;
      private int[] BC00258_A559SecUserLogId ;
      private string[] BC002511_A141SecUserName ;
      private bool[] BC002511_n141SecUserName ;
      private string[] BC002511_A143SecUserFullName ;
      private bool[] BC002511_n143SecUserFullName ;
      private int[] BC002512_A559SecUserLogId ;
      private string[] BC002512_A141SecUserName ;
      private bool[] BC002512_n141SecUserName ;
      private string[] BC002512_A143SecUserFullName ;
      private bool[] BC002512_n143SecUserFullName ;
      private DateTime[] BC002512_A560SecUserLogDateTime ;
      private bool[] BC002512_n560SecUserLogDateTime ;
      private short[] BC002512_A133SecUserId ;
      private bool[] BC002512_n133SecUserId ;
      private SdtSecUserLog bcSecUserLog ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class secuserlog_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00252;
          prmBC00252 = new Object[] {
          new ParDef("SecUserLogId",GXType.Int32,9,0)
          };
          Object[] prmBC00253;
          prmBC00253 = new Object[] {
          new ParDef("SecUserLogId",GXType.Int32,9,0)
          };
          Object[] prmBC00254;
          prmBC00254 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC00255;
          prmBC00255 = new Object[] {
          new ParDef("SecUserLogId",GXType.Int32,9,0)
          };
          Object[] prmBC00256;
          prmBC00256 = new Object[] {
          new ParDef("SecUserLogId",GXType.Int32,9,0)
          };
          Object[] prmBC00257;
          prmBC00257 = new Object[] {
          new ParDef("SecUserLogDateTime",GXType.DateTime,10,5){Nullable=true} ,
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC00258;
          prmBC00258 = new Object[] {
          };
          Object[] prmBC00259;
          prmBC00259 = new Object[] {
          new ParDef("SecUserLogDateTime",GXType.DateTime,10,5){Nullable=true} ,
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("SecUserLogId",GXType.Int32,9,0)
          };
          Object[] prmBC002510;
          prmBC002510 = new Object[] {
          new ParDef("SecUserLogId",GXType.Int32,9,0)
          };
          Object[] prmBC002511;
          prmBC002511 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002512;
          prmBC002512 = new Object[] {
          new ParDef("SecUserLogId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00252", "SELECT SecUserLogId, SecUserLogDateTime, SecUserId FROM SecUserLog WHERE SecUserLogId = :SecUserLogId  FOR UPDATE OF SecUserLog",true, GxErrorMask.GX_NOMASK, false, this,prmBC00252,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00253", "SELECT SecUserLogId, SecUserLogDateTime, SecUserId FROM SecUserLog WHERE SecUserLogId = :SecUserLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00253,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00254", "SELECT SecUserName, SecUserFullName FROM SecUser WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00254,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00255", "SELECT TM1.SecUserLogId, T2.SecUserName, T2.SecUserFullName, TM1.SecUserLogDateTime, TM1.SecUserId FROM (SecUserLog TM1 LEFT JOIN SecUser T2 ON T2.SecUserId = TM1.SecUserId) WHERE TM1.SecUserLogId = :SecUserLogId ORDER BY TM1.SecUserLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00255,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00256", "SELECT SecUserLogId FROM SecUserLog WHERE SecUserLogId = :SecUserLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00256,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00257", "SAVEPOINT gxupdate;INSERT INTO SecUserLog(SecUserLogDateTime, SecUserId) VALUES(:SecUserLogDateTime, :SecUserId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00257)
             ,new CursorDef("BC00258", "SELECT currval('SecUserLogId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00258,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00259", "SAVEPOINT gxupdate;UPDATE SecUserLog SET SecUserLogDateTime=:SecUserLogDateTime, SecUserId=:SecUserId  WHERE SecUserLogId = :SecUserLogId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00259)
             ,new CursorDef("BC002510", "SAVEPOINT gxupdate;DELETE FROM SecUserLog  WHERE SecUserLogId = :SecUserLogId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002510)
             ,new CursorDef("BC002511", "SELECT SecUserName, SecUserFullName FROM SecUser WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002511,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002512", "SELECT TM1.SecUserLogId, T2.SecUserName, T2.SecUserFullName, TM1.SecUserLogDateTime, TM1.SecUserId FROM (SecUserLog TM1 LEFT JOIN SecUser T2 ON T2.SecUserId = TM1.SecUserId) WHERE TM1.SecUserLogId = :SecUserLogId ORDER BY TM1.SecUserLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002512,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}
