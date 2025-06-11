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
   public class aprovadores_bc : GxSilentTrn, IGxSilentTrn
   {
      public aprovadores_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprovadores_bc( IGxContext context )
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
         ReadRow1G55( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1G55( ) ;
         standaloneModal( ) ;
         AddRow1G55( ) ;
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
            E111G2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z375AprovadoresId = A375AprovadoresId;
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

      protected void CONFIRM_1G0( )
      {
         BeforeValidate1G55( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1G55( ) ;
            }
            else
            {
               CheckExtendedTable1G55( ) ;
               if ( AnyError == 0 )
               {
                  ZM1G55( 7) ;
               }
               CloseExtendedTableCursors1G55( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E121G2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV21Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV22GXV1 = 1;
            while ( AV22GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV22GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "SecUserId") == 0 )
               {
                  AV11Insert_SecUserId = (short)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV22GXV1 = (int)(AV22GXV1+1);
            }
         }
      }

      protected void E111G2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1G55( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z380AprovadoresStatus = A380AprovadoresStatus;
            Z133SecUserId = A133SecUserId;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z141SecUserName = A141SecUserName;
            Z144SecUserEmail = A144SecUserEmail;
         }
         if ( GX_JID == -5 )
         {
            Z375AprovadoresId = A375AprovadoresId;
            Z380AprovadoresStatus = A380AprovadoresStatus;
            Z133SecUserId = A133SecUserId;
            Z141SecUserName = A141SecUserName;
            Z144SecUserEmail = A144SecUserEmail;
         }
      }

      protected void standaloneNotModal( )
      {
         AV21Pgmname = "Aprovadores_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A380AprovadoresStatus) && ( Gx_BScreen == 0 ) )
         {
            A380AprovadoresStatus = true;
            n380AprovadoresStatus = false;
         }
      }

      protected void Load1G55( )
      {
         /* Using cursor BC001G5 */
         pr_default.execute(3, new Object[] {n375AprovadoresId, A375AprovadoresId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound55 = 1;
            A141SecUserName = BC001G5_A141SecUserName[0];
            n141SecUserName = BC001G5_n141SecUserName[0];
            A144SecUserEmail = BC001G5_A144SecUserEmail[0];
            n144SecUserEmail = BC001G5_n144SecUserEmail[0];
            A380AprovadoresStatus = BC001G5_A380AprovadoresStatus[0];
            n380AprovadoresStatus = BC001G5_n380AprovadoresStatus[0];
            A133SecUserId = BC001G5_A133SecUserId[0];
            n133SecUserId = BC001G5_n133SecUserId[0];
            ZM1G55( -5) ;
         }
         pr_default.close(3);
         OnLoadActions1G55( ) ;
      }

      protected void OnLoadActions1G55( )
      {
      }

      protected void CheckExtendedTable1G55( )
      {
         standaloneModal( ) ;
         /* Using cursor BC001G6 */
         pr_default.execute(4, new Object[] {n133SecUserId, A133SecUserId, n375AprovadoresId, A375AprovadoresId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            GX_msglist.addItem("Usuário já cadastrado como aprovador", 1, "");
            AnyError = 1;
         }
         pr_default.close(4);
         /* Using cursor BC001G4 */
         pr_default.execute(2, new Object[] {n133SecUserId, A133SecUserId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A133SecUserId) ) )
            {
               GX_msglist.addItem("Usuário já cadastrado como aprovador", "ForeignKeyNotFound", 1, "SECUSERID");
               AnyError = 1;
            }
         }
         A141SecUserName = BC001G4_A141SecUserName[0];
         n141SecUserName = BC001G4_n141SecUserName[0];
         A144SecUserEmail = BC001G4_A144SecUserEmail[0];
         n144SecUserEmail = BC001G4_n144SecUserEmail[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors1G55( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1G55( )
      {
         /* Using cursor BC001G7 */
         pr_default.execute(5, new Object[] {n375AprovadoresId, A375AprovadoresId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound55 = 1;
         }
         else
         {
            RcdFound55 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001G3 */
         pr_default.execute(1, new Object[] {n375AprovadoresId, A375AprovadoresId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1G55( 5) ;
            RcdFound55 = 1;
            A375AprovadoresId = BC001G3_A375AprovadoresId[0];
            n375AprovadoresId = BC001G3_n375AprovadoresId[0];
            A380AprovadoresStatus = BC001G3_A380AprovadoresStatus[0];
            n380AprovadoresStatus = BC001G3_n380AprovadoresStatus[0];
            A133SecUserId = BC001G3_A133SecUserId[0];
            n133SecUserId = BC001G3_n133SecUserId[0];
            Z375AprovadoresId = A375AprovadoresId;
            sMode55 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1G55( ) ;
            if ( AnyError == 1 )
            {
               RcdFound55 = 0;
               InitializeNonKey1G55( ) ;
            }
            Gx_mode = sMode55;
         }
         else
         {
            RcdFound55 = 0;
            InitializeNonKey1G55( ) ;
            sMode55 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode55;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1G55( ) ;
         if ( RcdFound55 == 0 )
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
         CONFIRM_1G0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1G55( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001G2 */
            pr_default.execute(0, new Object[] {n375AprovadoresId, A375AprovadoresId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Aprovadores"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z380AprovadoresStatus != BC001G2_A380AprovadoresStatus[0] ) || ( Z133SecUserId != BC001G2_A133SecUserId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Aprovadores"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1G55( )
      {
         BeforeValidate1G55( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1G55( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1G55( 0) ;
            CheckOptimisticConcurrency1G55( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1G55( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1G55( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001G8 */
                     pr_default.execute(6, new Object[] {n380AprovadoresStatus, A380AprovadoresStatus, n133SecUserId, A133SecUserId});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC001G9 */
                     pr_default.execute(7);
                     A375AprovadoresId = BC001G9_A375AprovadoresId[0];
                     n375AprovadoresId = BC001G9_n375AprovadoresId[0];
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Aprovadores");
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
               Load1G55( ) ;
            }
            EndLevel1G55( ) ;
         }
         CloseExtendedTableCursors1G55( ) ;
      }

      protected void Update1G55( )
      {
         BeforeValidate1G55( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1G55( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1G55( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1G55( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1G55( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001G10 */
                     pr_default.execute(8, new Object[] {n380AprovadoresStatus, A380AprovadoresStatus, n133SecUserId, A133SecUserId, n375AprovadoresId, A375AprovadoresId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Aprovadores");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Aprovadores"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1G55( ) ;
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
            EndLevel1G55( ) ;
         }
         CloseExtendedTableCursors1G55( ) ;
      }

      protected void DeferredUpdate1G55( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1G55( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1G55( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1G55( ) ;
            AfterConfirm1G55( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1G55( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001G11 */
                  pr_default.execute(9, new Object[] {n375AprovadoresId, A375AprovadoresId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("Aprovadores");
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
         sMode55 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1G55( ) ;
         Gx_mode = sMode55;
      }

      protected void OnDeleteControls1G55( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001G12 */
            pr_default.execute(10, new Object[] {n133SecUserId, A133SecUserId});
            A141SecUserName = BC001G12_A141SecUserName[0];
            n141SecUserName = BC001G12_n141SecUserName[0];
            A144SecUserEmail = BC001G12_A144SecUserEmail[0];
            n144SecUserEmail = BC001G12_n144SecUserEmail[0];
            pr_default.close(10);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC001G13 */
            pr_default.execute(11, new Object[] {n375AprovadoresId, A375AprovadoresId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Aprovacao"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel1G55( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1G55( ) ;
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

      public void ScanKeyStart1G55( )
      {
         /* Scan By routine */
         /* Using cursor BC001G14 */
         pr_default.execute(12, new Object[] {n375AprovadoresId, A375AprovadoresId});
         RcdFound55 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound55 = 1;
            A375AprovadoresId = BC001G14_A375AprovadoresId[0];
            n375AprovadoresId = BC001G14_n375AprovadoresId[0];
            A141SecUserName = BC001G14_A141SecUserName[0];
            n141SecUserName = BC001G14_n141SecUserName[0];
            A144SecUserEmail = BC001G14_A144SecUserEmail[0];
            n144SecUserEmail = BC001G14_n144SecUserEmail[0];
            A380AprovadoresStatus = BC001G14_A380AprovadoresStatus[0];
            n380AprovadoresStatus = BC001G14_n380AprovadoresStatus[0];
            A133SecUserId = BC001G14_A133SecUserId[0];
            n133SecUserId = BC001G14_n133SecUserId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1G55( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound55 = 0;
         ScanKeyLoad1G55( ) ;
      }

      protected void ScanKeyLoad1G55( )
      {
         sMode55 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound55 = 1;
            A375AprovadoresId = BC001G14_A375AprovadoresId[0];
            n375AprovadoresId = BC001G14_n375AprovadoresId[0];
            A141SecUserName = BC001G14_A141SecUserName[0];
            n141SecUserName = BC001G14_n141SecUserName[0];
            A144SecUserEmail = BC001G14_A144SecUserEmail[0];
            n144SecUserEmail = BC001G14_n144SecUserEmail[0];
            A380AprovadoresStatus = BC001G14_A380AprovadoresStatus[0];
            n380AprovadoresStatus = BC001G14_n380AprovadoresStatus[0];
            A133SecUserId = BC001G14_A133SecUserId[0];
            n133SecUserId = BC001G14_n133SecUserId[0];
         }
         Gx_mode = sMode55;
      }

      protected void ScanKeyEnd1G55( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm1G55( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1G55( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1G55( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1G55( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1G55( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1G55( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1G55( )
      {
      }

      protected void send_integrity_lvl_hashes1G55( )
      {
      }

      protected void AddRow1G55( )
      {
         VarsToRow55( bcAprovadores) ;
      }

      protected void ReadRow1G55( )
      {
         RowToVars55( bcAprovadores, 1) ;
      }

      protected void InitializeNonKey1G55( )
      {
         A133SecUserId = 0;
         n133SecUserId = false;
         A141SecUserName = "";
         n141SecUserName = false;
         A144SecUserEmail = "";
         n144SecUserEmail = false;
         A380AprovadoresStatus = true;
         n380AprovadoresStatus = false;
         Z380AprovadoresStatus = false;
         Z133SecUserId = 0;
      }

      protected void InitAll1G55( )
      {
         A375AprovadoresId = 0;
         n375AprovadoresId = false;
         InitializeNonKey1G55( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A380AprovadoresStatus = i380AprovadoresStatus;
         n380AprovadoresStatus = false;
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

      public void VarsToRow55( SdtAprovadores obj55 )
      {
         obj55.gxTpr_Mode = Gx_mode;
         obj55.gxTpr_Secuserid = A133SecUserId;
         obj55.gxTpr_Secusername = A141SecUserName;
         obj55.gxTpr_Secuseremail = A144SecUserEmail;
         obj55.gxTpr_Aprovadoresstatus = A380AprovadoresStatus;
         obj55.gxTpr_Aprovadoresid = A375AprovadoresId;
         obj55.gxTpr_Aprovadoresid_Z = Z375AprovadoresId;
         obj55.gxTpr_Secuserid_Z = Z133SecUserId;
         obj55.gxTpr_Secusername_Z = Z141SecUserName;
         obj55.gxTpr_Secuseremail_Z = Z144SecUserEmail;
         obj55.gxTpr_Aprovadoresstatus_Z = Z380AprovadoresStatus;
         obj55.gxTpr_Aprovadoresid_N = (short)(Convert.ToInt16(n375AprovadoresId));
         obj55.gxTpr_Secuserid_N = (short)(Convert.ToInt16(n133SecUserId));
         obj55.gxTpr_Secusername_N = (short)(Convert.ToInt16(n141SecUserName));
         obj55.gxTpr_Secuseremail_N = (short)(Convert.ToInt16(n144SecUserEmail));
         obj55.gxTpr_Aprovadoresstatus_N = (short)(Convert.ToInt16(n380AprovadoresStatus));
         obj55.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow55( SdtAprovadores obj55 )
      {
         obj55.gxTpr_Aprovadoresid = A375AprovadoresId;
         return  ;
      }

      public void RowToVars55( SdtAprovadores obj55 ,
                               int forceLoad )
      {
         Gx_mode = obj55.gxTpr_Mode;
         A133SecUserId = obj55.gxTpr_Secuserid;
         n133SecUserId = false;
         A141SecUserName = obj55.gxTpr_Secusername;
         n141SecUserName = false;
         A144SecUserEmail = obj55.gxTpr_Secuseremail;
         n144SecUserEmail = false;
         if ( ! ( IsIns( )  ) || ( forceLoad == 1 ) )
         {
            A380AprovadoresStatus = obj55.gxTpr_Aprovadoresstatus;
            n380AprovadoresStatus = false;
         }
         A375AprovadoresId = obj55.gxTpr_Aprovadoresid;
         n375AprovadoresId = false;
         Z375AprovadoresId = obj55.gxTpr_Aprovadoresid_Z;
         Z133SecUserId = obj55.gxTpr_Secuserid_Z;
         Z141SecUserName = obj55.gxTpr_Secusername_Z;
         Z144SecUserEmail = obj55.gxTpr_Secuseremail_Z;
         Z380AprovadoresStatus = obj55.gxTpr_Aprovadoresstatus_Z;
         n375AprovadoresId = (bool)(Convert.ToBoolean(obj55.gxTpr_Aprovadoresid_N));
         n133SecUserId = (bool)(Convert.ToBoolean(obj55.gxTpr_Secuserid_N));
         n141SecUserName = (bool)(Convert.ToBoolean(obj55.gxTpr_Secusername_N));
         n144SecUserEmail = (bool)(Convert.ToBoolean(obj55.gxTpr_Secuseremail_N));
         n380AprovadoresStatus = (bool)(Convert.ToBoolean(obj55.gxTpr_Aprovadoresstatus_N));
         Gx_mode = obj55.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A375AprovadoresId = (int)getParm(obj,0);
         n375AprovadoresId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1G55( ) ;
         ScanKeyStart1G55( ) ;
         if ( RcdFound55 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z375AprovadoresId = A375AprovadoresId;
         }
         ZM1G55( -5) ;
         OnLoadActions1G55( ) ;
         AddRow1G55( ) ;
         ScanKeyEnd1G55( ) ;
         if ( RcdFound55 == 0 )
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
         RowToVars55( bcAprovadores, 0) ;
         ScanKeyStart1G55( ) ;
         if ( RcdFound55 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z375AprovadoresId = A375AprovadoresId;
         }
         ZM1G55( -5) ;
         OnLoadActions1G55( ) ;
         AddRow1G55( ) ;
         ScanKeyEnd1G55( ) ;
         if ( RcdFound55 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1G55( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1G55( ) ;
         }
         else
         {
            if ( RcdFound55 == 1 )
            {
               if ( A375AprovadoresId != Z375AprovadoresId )
               {
                  A375AprovadoresId = Z375AprovadoresId;
                  n375AprovadoresId = false;
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
                  Update1G55( ) ;
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
                  if ( A375AprovadoresId != Z375AprovadoresId )
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
                        Insert1G55( ) ;
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
                        Insert1G55( ) ;
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
         RowToVars55( bcAprovadores, 1) ;
         SaveImpl( ) ;
         VarsToRow55( bcAprovadores) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars55( bcAprovadores, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1G55( ) ;
         AfterTrn( ) ;
         VarsToRow55( bcAprovadores) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow55( bcAprovadores) ;
         }
         else
         {
            SdtAprovadores auxBC = new SdtAprovadores(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A375AprovadoresId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcAprovadores);
               auxBC.Save();
               bcAprovadores.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars55( bcAprovadores, 1) ;
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
         RowToVars55( bcAprovadores, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1G55( ) ;
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
               VarsToRow55( bcAprovadores) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow55( bcAprovadores) ;
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
         RowToVars55( bcAprovadores, 0) ;
         GetKey1G55( ) ;
         if ( RcdFound55 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A375AprovadoresId != Z375AprovadoresId )
            {
               A375AprovadoresId = Z375AprovadoresId;
               n375AprovadoresId = false;
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
            if ( A375AprovadoresId != Z375AprovadoresId )
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
         context.RollbackDataStores("aprovadores_bc",pr_default);
         VarsToRow55( bcAprovadores) ;
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
         Gx_mode = bcAprovadores.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcAprovadores.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcAprovadores )
         {
            bcAprovadores = (SdtAprovadores)(sdt);
            if ( StringUtil.StrCmp(bcAprovadores.gxTpr_Mode, "") == 0 )
            {
               bcAprovadores.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow55( bcAprovadores) ;
            }
            else
            {
               RowToVars55( bcAprovadores, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcAprovadores.gxTpr_Mode, "") == 0 )
            {
               bcAprovadores.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars55( bcAprovadores, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtAprovadores Aprovadores_BC
      {
         get {
            return bcAprovadores ;
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
         pr_default.close(10);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV21Pgmname = "";
         AV12TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z141SecUserName = "";
         A141SecUserName = "";
         Z144SecUserEmail = "";
         A144SecUserEmail = "";
         BC001G5_A375AprovadoresId = new int[1] ;
         BC001G5_n375AprovadoresId = new bool[] {false} ;
         BC001G5_A141SecUserName = new string[] {""} ;
         BC001G5_n141SecUserName = new bool[] {false} ;
         BC001G5_A144SecUserEmail = new string[] {""} ;
         BC001G5_n144SecUserEmail = new bool[] {false} ;
         BC001G5_A380AprovadoresStatus = new bool[] {false} ;
         BC001G5_n380AprovadoresStatus = new bool[] {false} ;
         BC001G5_A133SecUserId = new short[1] ;
         BC001G5_n133SecUserId = new bool[] {false} ;
         BC001G6_A133SecUserId = new short[1] ;
         BC001G6_n133SecUserId = new bool[] {false} ;
         BC001G4_A141SecUserName = new string[] {""} ;
         BC001G4_n141SecUserName = new bool[] {false} ;
         BC001G4_A144SecUserEmail = new string[] {""} ;
         BC001G4_n144SecUserEmail = new bool[] {false} ;
         BC001G7_A375AprovadoresId = new int[1] ;
         BC001G7_n375AprovadoresId = new bool[] {false} ;
         BC001G3_A375AprovadoresId = new int[1] ;
         BC001G3_n375AprovadoresId = new bool[] {false} ;
         BC001G3_A380AprovadoresStatus = new bool[] {false} ;
         BC001G3_n380AprovadoresStatus = new bool[] {false} ;
         BC001G3_A133SecUserId = new short[1] ;
         BC001G3_n133SecUserId = new bool[] {false} ;
         sMode55 = "";
         BC001G2_A375AprovadoresId = new int[1] ;
         BC001G2_n375AprovadoresId = new bool[] {false} ;
         BC001G2_A380AprovadoresStatus = new bool[] {false} ;
         BC001G2_n380AprovadoresStatus = new bool[] {false} ;
         BC001G2_A133SecUserId = new short[1] ;
         BC001G2_n133SecUserId = new bool[] {false} ;
         BC001G9_A375AprovadoresId = new int[1] ;
         BC001G9_n375AprovadoresId = new bool[] {false} ;
         BC001G12_A141SecUserName = new string[] {""} ;
         BC001G12_n141SecUserName = new bool[] {false} ;
         BC001G12_A144SecUserEmail = new string[] {""} ;
         BC001G12_n144SecUserEmail = new bool[] {false} ;
         BC001G13_A336AprovacaoId = new int[1] ;
         BC001G14_A375AprovadoresId = new int[1] ;
         BC001G14_n375AprovadoresId = new bool[] {false} ;
         BC001G14_A141SecUserName = new string[] {""} ;
         BC001G14_n141SecUserName = new bool[] {false} ;
         BC001G14_A144SecUserEmail = new string[] {""} ;
         BC001G14_n144SecUserEmail = new bool[] {false} ;
         BC001G14_A380AprovadoresStatus = new bool[] {false} ;
         BC001G14_n380AprovadoresStatus = new bool[] {false} ;
         BC001G14_A133SecUserId = new short[1] ;
         BC001G14_n133SecUserId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprovadores_bc__default(),
            new Object[][] {
                new Object[] {
               BC001G2_A375AprovadoresId, BC001G2_A380AprovadoresStatus, BC001G2_n380AprovadoresStatus, BC001G2_A133SecUserId, BC001G2_n133SecUserId
               }
               , new Object[] {
               BC001G3_A375AprovadoresId, BC001G3_A380AprovadoresStatus, BC001G3_n380AprovadoresStatus, BC001G3_A133SecUserId, BC001G3_n133SecUserId
               }
               , new Object[] {
               BC001G4_A141SecUserName, BC001G4_n141SecUserName, BC001G4_A144SecUserEmail, BC001G4_n144SecUserEmail
               }
               , new Object[] {
               BC001G5_A375AprovadoresId, BC001G5_A141SecUserName, BC001G5_n141SecUserName, BC001G5_A144SecUserEmail, BC001G5_n144SecUserEmail, BC001G5_A380AprovadoresStatus, BC001G5_n380AprovadoresStatus, BC001G5_A133SecUserId, BC001G5_n133SecUserId
               }
               , new Object[] {
               BC001G6_A133SecUserId, BC001G6_n133SecUserId
               }
               , new Object[] {
               BC001G7_A375AprovadoresId
               }
               , new Object[] {
               }
               , new Object[] {
               BC001G9_A375AprovadoresId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001G12_A141SecUserName, BC001G12_n141SecUserName, BC001G12_A144SecUserEmail, BC001G12_n144SecUserEmail
               }
               , new Object[] {
               BC001G13_A336AprovacaoId
               }
               , new Object[] {
               BC001G14_A375AprovadoresId, BC001G14_A141SecUserName, BC001G14_n141SecUserName, BC001G14_A144SecUserEmail, BC001G14_n144SecUserEmail, BC001G14_A380AprovadoresStatus, BC001G14_n380AprovadoresStatus, BC001G14_A133SecUserId, BC001G14_n133SecUserId
               }
            }
         );
         AV21Pgmname = "Aprovadores_BC";
         Z380AprovadoresStatus = true;
         n380AprovadoresStatus = false;
         A380AprovadoresStatus = true;
         n380AprovadoresStatus = false;
         i380AprovadoresStatus = true;
         n380AprovadoresStatus = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121G2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short AV11Insert_SecUserId ;
      private short Z133SecUserId ;
      private short A133SecUserId ;
      private short Gx_BScreen ;
      private short RcdFound55 ;
      private int trnEnded ;
      private int Z375AprovadoresId ;
      private int A375AprovadoresId ;
      private int AV22GXV1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV21Pgmname ;
      private string sMode55 ;
      private bool returnInSub ;
      private bool Z380AprovadoresStatus ;
      private bool A380AprovadoresStatus ;
      private bool n380AprovadoresStatus ;
      private bool n375AprovadoresId ;
      private bool n141SecUserName ;
      private bool n144SecUserEmail ;
      private bool n133SecUserId ;
      private bool i380AprovadoresStatus ;
      private string Z141SecUserName ;
      private string A141SecUserName ;
      private string Z144SecUserEmail ;
      private string A144SecUserEmail ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] BC001G5_A375AprovadoresId ;
      private bool[] BC001G5_n375AprovadoresId ;
      private string[] BC001G5_A141SecUserName ;
      private bool[] BC001G5_n141SecUserName ;
      private string[] BC001G5_A144SecUserEmail ;
      private bool[] BC001G5_n144SecUserEmail ;
      private bool[] BC001G5_A380AprovadoresStatus ;
      private bool[] BC001G5_n380AprovadoresStatus ;
      private short[] BC001G5_A133SecUserId ;
      private bool[] BC001G5_n133SecUserId ;
      private short[] BC001G6_A133SecUserId ;
      private bool[] BC001G6_n133SecUserId ;
      private string[] BC001G4_A141SecUserName ;
      private bool[] BC001G4_n141SecUserName ;
      private string[] BC001G4_A144SecUserEmail ;
      private bool[] BC001G4_n144SecUserEmail ;
      private int[] BC001G7_A375AprovadoresId ;
      private bool[] BC001G7_n375AprovadoresId ;
      private int[] BC001G3_A375AprovadoresId ;
      private bool[] BC001G3_n375AprovadoresId ;
      private bool[] BC001G3_A380AprovadoresStatus ;
      private bool[] BC001G3_n380AprovadoresStatus ;
      private short[] BC001G3_A133SecUserId ;
      private bool[] BC001G3_n133SecUserId ;
      private int[] BC001G2_A375AprovadoresId ;
      private bool[] BC001G2_n375AprovadoresId ;
      private bool[] BC001G2_A380AprovadoresStatus ;
      private bool[] BC001G2_n380AprovadoresStatus ;
      private short[] BC001G2_A133SecUserId ;
      private bool[] BC001G2_n133SecUserId ;
      private int[] BC001G9_A375AprovadoresId ;
      private bool[] BC001G9_n375AprovadoresId ;
      private string[] BC001G12_A141SecUserName ;
      private bool[] BC001G12_n141SecUserName ;
      private string[] BC001G12_A144SecUserEmail ;
      private bool[] BC001G12_n144SecUserEmail ;
      private int[] BC001G13_A336AprovacaoId ;
      private int[] BC001G14_A375AprovadoresId ;
      private bool[] BC001G14_n375AprovadoresId ;
      private string[] BC001G14_A141SecUserName ;
      private bool[] BC001G14_n141SecUserName ;
      private string[] BC001G14_A144SecUserEmail ;
      private bool[] BC001G14_n144SecUserEmail ;
      private bool[] BC001G14_A380AprovadoresStatus ;
      private bool[] BC001G14_n380AprovadoresStatus ;
      private short[] BC001G14_A133SecUserId ;
      private bool[] BC001G14_n133SecUserId ;
      private SdtAprovadores bcAprovadores ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class aprovadores_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC001G2;
          prmBC001G2 = new Object[] {
          new ParDef("AprovadoresId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001G3;
          prmBC001G3 = new Object[] {
          new ParDef("AprovadoresId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001G4;
          prmBC001G4 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC001G5;
          prmBC001G5 = new Object[] {
          new ParDef("AprovadoresId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001G6;
          prmBC001G6 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("AprovadoresId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001G7;
          prmBC001G7 = new Object[] {
          new ParDef("AprovadoresId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001G8;
          prmBC001G8 = new Object[] {
          new ParDef("AprovadoresStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC001G9;
          prmBC001G9 = new Object[] {
          };
          Object[] prmBC001G10;
          prmBC001G10 = new Object[] {
          new ParDef("AprovadoresStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("AprovadoresId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001G11;
          prmBC001G11 = new Object[] {
          new ParDef("AprovadoresId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001G12;
          prmBC001G12 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC001G13;
          prmBC001G13 = new Object[] {
          new ParDef("AprovadoresId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001G14;
          prmBC001G14 = new Object[] {
          new ParDef("AprovadoresId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC001G2", "SELECT AprovadoresId, AprovadoresStatus, SecUserId FROM Aprovadores WHERE AprovadoresId = :AprovadoresId  FOR UPDATE OF Aprovadores",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001G3", "SELECT AprovadoresId, AprovadoresStatus, SecUserId FROM Aprovadores WHERE AprovadoresId = :AprovadoresId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001G4", "SELECT SecUserName, SecUserEmail FROM SecUser WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001G5", "SELECT TM1.AprovadoresId, T2.SecUserName, T2.SecUserEmail, TM1.AprovadoresStatus, TM1.SecUserId FROM (Aprovadores TM1 LEFT JOIN SecUser T2 ON T2.SecUserId = TM1.SecUserId) WHERE TM1.AprovadoresId = :AprovadoresId ORDER BY TM1.AprovadoresId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001G6", "SELECT SecUserId FROM Aprovadores WHERE (SecUserId = :SecUserId) AND (Not ( AprovadoresId = :AprovadoresId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001G7", "SELECT AprovadoresId FROM Aprovadores WHERE AprovadoresId = :AprovadoresId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001G8", "SAVEPOINT gxupdate;INSERT INTO Aprovadores(AprovadoresStatus, SecUserId) VALUES(:AprovadoresStatus, :SecUserId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001G8)
             ,new CursorDef("BC001G9", "SELECT currval('AprovadoresId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001G10", "SAVEPOINT gxupdate;UPDATE Aprovadores SET AprovadoresStatus=:AprovadoresStatus, SecUserId=:SecUserId  WHERE AprovadoresId = :AprovadoresId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001G10)
             ,new CursorDef("BC001G11", "SAVEPOINT gxupdate;DELETE FROM Aprovadores  WHERE AprovadoresId = :AprovadoresId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001G11)
             ,new CursorDef("BC001G12", "SELECT SecUserName, SecUserEmail FROM SecUser WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001G13", "SELECT AprovacaoId FROM Aprovacao WHERE AprovadoresId = :AprovadoresId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G13,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001G14", "SELECT TM1.AprovadoresId, T2.SecUserName, T2.SecUserEmail, TM1.AprovadoresStatus, TM1.SecUserId FROM (Aprovadores TM1 LEFT JOIN SecUser T2 ON T2.SecUserId = TM1.SecUserId) WHERE TM1.AprovadoresId = :AprovadoresId ORDER BY TM1.AprovadoresId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001G14,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
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
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}
