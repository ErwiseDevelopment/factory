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
namespace GeneXus.Programs.wwpbaseobjects {
   public class secuserrole_bc : GxSilentTrn, IGxSilentTrn
   {
      public secuserrole_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secuserrole_bc( IGxContext context )
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
         ReadRow0J23( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0J23( ) ;
         standaloneModal( ) ;
         AddRow0J23( ) ;
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
               Z133SecUserId = A133SecUserId;
               Z131SecRoleId = A131SecRoleId;
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

      protected void CONFIRM_0J0( )
      {
         BeforeValidate0J23( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0J23( ) ;
            }
            else
            {
               CheckExtendedTable0J23( ) ;
               if ( AnyError == 0 )
               {
                  ZM0J23( 2) ;
                  ZM0J23( 3) ;
               }
               CloseExtendedTableCursors0J23( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0J23( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z647SecUserRoleActive = A647SecUserRoleActive;
         }
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z141SecUserName = A141SecUserName;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z140SecRoleName = A140SecRoleName;
            Z139SecRoleDescription = A139SecRoleDescription;
         }
         if ( GX_JID == -1 )
         {
            Z647SecUserRoleActive = A647SecUserRoleActive;
            Z133SecUserId = A133SecUserId;
            Z131SecRoleId = A131SecRoleId;
            Z141SecUserName = A141SecUserName;
            Z140SecRoleName = A140SecRoleName;
            Z139SecRoleDescription = A139SecRoleDescription;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0J23( )
      {
         /* Using cursor BC000J6 */
         pr_default.execute(4, new Object[] {A133SecUserId, A131SecRoleId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound23 = 1;
            A141SecUserName = BC000J6_A141SecUserName[0];
            n141SecUserName = BC000J6_n141SecUserName[0];
            A140SecRoleName = BC000J6_A140SecRoleName[0];
            A139SecRoleDescription = BC000J6_A139SecRoleDescription[0];
            A647SecUserRoleActive = BC000J6_A647SecUserRoleActive[0];
            ZM0J23( -1) ;
         }
         pr_default.close(4);
         OnLoadActions0J23( ) ;
      }

      protected void OnLoadActions0J23( )
      {
      }

      protected void CheckExtendedTable0J23( )
      {
         standaloneModal( ) ;
         /* Using cursor BC000J4 */
         pr_default.execute(2, new Object[] {A133SecUserId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'User'.", "ForeignKeyNotFound", 1, "SECUSERID");
            AnyError = 1;
         }
         A141SecUserName = BC000J4_A141SecUserName[0];
         n141SecUserName = BC000J4_n141SecUserName[0];
         pr_default.close(2);
         /* Using cursor BC000J5 */
         pr_default.execute(3, new Object[] {A131SecRoleId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe 'Role'.", "ForeignKeyNotFound", 1, "SECROLEID");
            AnyError = 1;
         }
         A140SecRoleName = BC000J5_A140SecRoleName[0];
         A139SecRoleDescription = BC000J5_A139SecRoleDescription[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0J23( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0J23( )
      {
         /* Using cursor BC000J7 */
         pr_default.execute(5, new Object[] {A133SecUserId, A131SecRoleId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound23 = 1;
         }
         else
         {
            RcdFound23 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000J3 */
         pr_default.execute(1, new Object[] {A133SecUserId, A131SecRoleId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0J23( 1) ;
            RcdFound23 = 1;
            A647SecUserRoleActive = BC000J3_A647SecUserRoleActive[0];
            A133SecUserId = BC000J3_A133SecUserId[0];
            A131SecRoleId = BC000J3_A131SecRoleId[0];
            Z133SecUserId = A133SecUserId;
            Z131SecRoleId = A131SecRoleId;
            sMode23 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0J23( ) ;
            if ( AnyError == 1 )
            {
               RcdFound23 = 0;
               InitializeNonKey0J23( ) ;
            }
            Gx_mode = sMode23;
         }
         else
         {
            RcdFound23 = 0;
            InitializeNonKey0J23( ) ;
            sMode23 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode23;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0J23( ) ;
         if ( RcdFound23 == 0 )
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
         CONFIRM_0J0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0J23( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000J2 */
            pr_default.execute(0, new Object[] {A133SecUserId, A131SecRoleId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecUserRole"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z647SecUserRoleActive != BC000J2_A647SecUserRoleActive[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SecUserRole"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0J23( )
      {
         BeforeValidate0J23( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J23( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0J23( 0) ;
            CheckOptimisticConcurrency0J23( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0J23( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0J23( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000J8 */
                     pr_default.execute(6, new Object[] {A647SecUserRoleActive, A133SecUserId, A131SecRoleId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("SecUserRole");
                     if ( (pr_default.getStatus(6) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
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
               Load0J23( ) ;
            }
            EndLevel0J23( ) ;
         }
         CloseExtendedTableCursors0J23( ) ;
      }

      protected void Update0J23( )
      {
         BeforeValidate0J23( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J23( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0J23( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0J23( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0J23( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000J9 */
                     pr_default.execute(7, new Object[] {A647SecUserRoleActive, A133SecUserId, A131SecRoleId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("SecUserRole");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecUserRole"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0J23( ) ;
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
            EndLevel0J23( ) ;
         }
         CloseExtendedTableCursors0J23( ) ;
      }

      protected void DeferredUpdate0J23( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0J23( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0J23( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0J23( ) ;
            AfterConfirm0J23( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0J23( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000J10 */
                  pr_default.execute(8, new Object[] {A133SecUserId, A131SecRoleId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("SecUserRole");
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
         sMode23 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0J23( ) ;
         Gx_mode = sMode23;
      }

      protected void OnDeleteControls0J23( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000J11 */
            pr_default.execute(9, new Object[] {A133SecUserId});
            A141SecUserName = BC000J11_A141SecUserName[0];
            n141SecUserName = BC000J11_n141SecUserName[0];
            pr_default.close(9);
            /* Using cursor BC000J12 */
            pr_default.execute(10, new Object[] {A131SecRoleId});
            A140SecRoleName = BC000J12_A140SecRoleName[0];
            A139SecRoleDescription = BC000J12_A139SecRoleDescription[0];
            pr_default.close(10);
         }
      }

      protected void EndLevel0J23( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0J23( ) ;
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

      public void ScanKeyStart0J23( )
      {
         /* Using cursor BC000J13 */
         pr_default.execute(11, new Object[] {A133SecUserId, A131SecRoleId});
         RcdFound23 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound23 = 1;
            A141SecUserName = BC000J13_A141SecUserName[0];
            n141SecUserName = BC000J13_n141SecUserName[0];
            A140SecRoleName = BC000J13_A140SecRoleName[0];
            A139SecRoleDescription = BC000J13_A139SecRoleDescription[0];
            A647SecUserRoleActive = BC000J13_A647SecUserRoleActive[0];
            A133SecUserId = BC000J13_A133SecUserId[0];
            A131SecRoleId = BC000J13_A131SecRoleId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0J23( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound23 = 0;
         ScanKeyLoad0J23( ) ;
      }

      protected void ScanKeyLoad0J23( )
      {
         sMode23 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound23 = 1;
            A141SecUserName = BC000J13_A141SecUserName[0];
            n141SecUserName = BC000J13_n141SecUserName[0];
            A140SecRoleName = BC000J13_A140SecRoleName[0];
            A139SecRoleDescription = BC000J13_A139SecRoleDescription[0];
            A647SecUserRoleActive = BC000J13_A647SecUserRoleActive[0];
            A133SecUserId = BC000J13_A133SecUserId[0];
            A131SecRoleId = BC000J13_A131SecRoleId[0];
         }
         Gx_mode = sMode23;
      }

      protected void ScanKeyEnd0J23( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm0J23( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0J23( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0J23( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0J23( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0J23( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0J23( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0J23( )
      {
      }

      protected void send_integrity_lvl_hashes0J23( )
      {
      }

      protected void AddRow0J23( )
      {
         VarsToRow23( bcwwpbaseobjects_SecUserRole) ;
      }

      protected void ReadRow0J23( )
      {
         RowToVars23( bcwwpbaseobjects_SecUserRole, 1) ;
      }

      protected void InitializeNonKey0J23( )
      {
         A141SecUserName = "";
         n141SecUserName = false;
         A140SecRoleName = "";
         A139SecRoleDescription = "";
         A647SecUserRoleActive = false;
         Z647SecUserRoleActive = false;
      }

      protected void InitAll0J23( )
      {
         A133SecUserId = 0;
         A131SecRoleId = 0;
         InitializeNonKey0J23( ) ;
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

      public void VarsToRow23( GeneXus.Programs.wwpbaseobjects.SdtSecUserRole obj23 )
      {
         obj23.gxTpr_Mode = Gx_mode;
         obj23.gxTpr_Secusername = A141SecUserName;
         obj23.gxTpr_Secrolename = A140SecRoleName;
         obj23.gxTpr_Secroledescription = A139SecRoleDescription;
         obj23.gxTpr_Secuserroleactive = A647SecUserRoleActive;
         obj23.gxTpr_Secuserid = A133SecUserId;
         obj23.gxTpr_Secroleid = A131SecRoleId;
         obj23.gxTpr_Secuserid_Z = Z133SecUserId;
         obj23.gxTpr_Secroleid_Z = Z131SecRoleId;
         obj23.gxTpr_Secusername_Z = Z141SecUserName;
         obj23.gxTpr_Secrolename_Z = Z140SecRoleName;
         obj23.gxTpr_Secroledescription_Z = Z139SecRoleDescription;
         obj23.gxTpr_Secuserroleactive_Z = Z647SecUserRoleActive;
         obj23.gxTpr_Secusername_N = (short)(Convert.ToInt16(n141SecUserName));
         obj23.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow23( GeneXus.Programs.wwpbaseobjects.SdtSecUserRole obj23 )
      {
         obj23.gxTpr_Secuserid = A133SecUserId;
         obj23.gxTpr_Secroleid = A131SecRoleId;
         return  ;
      }

      public void RowToVars23( GeneXus.Programs.wwpbaseobjects.SdtSecUserRole obj23 ,
                               int forceLoad )
      {
         Gx_mode = obj23.gxTpr_Mode;
         A141SecUserName = obj23.gxTpr_Secusername;
         n141SecUserName = false;
         A140SecRoleName = obj23.gxTpr_Secrolename;
         A139SecRoleDescription = obj23.gxTpr_Secroledescription;
         A647SecUserRoleActive = obj23.gxTpr_Secuserroleactive;
         A133SecUserId = obj23.gxTpr_Secuserid;
         A131SecRoleId = obj23.gxTpr_Secroleid;
         Z133SecUserId = obj23.gxTpr_Secuserid_Z;
         Z131SecRoleId = obj23.gxTpr_Secroleid_Z;
         Z141SecUserName = obj23.gxTpr_Secusername_Z;
         Z140SecRoleName = obj23.gxTpr_Secrolename_Z;
         Z139SecRoleDescription = obj23.gxTpr_Secroledescription_Z;
         Z647SecUserRoleActive = obj23.gxTpr_Secuserroleactive_Z;
         n141SecUserName = (bool)(Convert.ToBoolean(obj23.gxTpr_Secusername_N));
         Gx_mode = obj23.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A133SecUserId = (short)getParm(obj,0);
         A131SecRoleId = (short)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0J23( ) ;
         ScanKeyStart0J23( ) ;
         if ( RcdFound23 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000J11 */
            pr_default.execute(9, new Object[] {A133SecUserId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem("Não existe 'User'.", "ForeignKeyNotFound", 1, "SECUSERID");
               AnyError = 1;
            }
            A141SecUserName = BC000J11_A141SecUserName[0];
            n141SecUserName = BC000J11_n141SecUserName[0];
            pr_default.close(9);
            /* Using cursor BC000J12 */
            pr_default.execute(10, new Object[] {A131SecRoleId});
            if ( (pr_default.getStatus(10) == 101) )
            {
               GX_msglist.addItem("Não existe 'Role'.", "ForeignKeyNotFound", 1, "SECROLEID");
               AnyError = 1;
            }
            A140SecRoleName = BC000J12_A140SecRoleName[0];
            A139SecRoleDescription = BC000J12_A139SecRoleDescription[0];
            pr_default.close(10);
         }
         else
         {
            Gx_mode = "UPD";
            Z133SecUserId = A133SecUserId;
            Z131SecRoleId = A131SecRoleId;
         }
         ZM0J23( -1) ;
         OnLoadActions0J23( ) ;
         AddRow0J23( ) ;
         ScanKeyEnd0J23( ) ;
         if ( RcdFound23 == 0 )
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
         RowToVars23( bcwwpbaseobjects_SecUserRole, 0) ;
         ScanKeyStart0J23( ) ;
         if ( RcdFound23 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000J11 */
            pr_default.execute(9, new Object[] {A133SecUserId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem("Não existe 'User'.", "ForeignKeyNotFound", 1, "SECUSERID");
               AnyError = 1;
            }
            A141SecUserName = BC000J11_A141SecUserName[0];
            n141SecUserName = BC000J11_n141SecUserName[0];
            pr_default.close(9);
            /* Using cursor BC000J12 */
            pr_default.execute(10, new Object[] {A131SecRoleId});
            if ( (pr_default.getStatus(10) == 101) )
            {
               GX_msglist.addItem("Não existe 'Role'.", "ForeignKeyNotFound", 1, "SECROLEID");
               AnyError = 1;
            }
            A140SecRoleName = BC000J12_A140SecRoleName[0];
            A139SecRoleDescription = BC000J12_A139SecRoleDescription[0];
            pr_default.close(10);
         }
         else
         {
            Gx_mode = "UPD";
            Z133SecUserId = A133SecUserId;
            Z131SecRoleId = A131SecRoleId;
         }
         ZM0J23( -1) ;
         OnLoadActions0J23( ) ;
         AddRow0J23( ) ;
         ScanKeyEnd0J23( ) ;
         if ( RcdFound23 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0J23( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0J23( ) ;
         }
         else
         {
            if ( RcdFound23 == 1 )
            {
               if ( ( A133SecUserId != Z133SecUserId ) || ( A131SecRoleId != Z131SecRoleId ) )
               {
                  A133SecUserId = Z133SecUserId;
                  A131SecRoleId = Z131SecRoleId;
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
                  Update0J23( ) ;
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
                  if ( ( A133SecUserId != Z133SecUserId ) || ( A131SecRoleId != Z131SecRoleId ) )
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
                        Insert0J23( ) ;
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
                        Insert0J23( ) ;
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
         RowToVars23( bcwwpbaseobjects_SecUserRole, 1) ;
         SaveImpl( ) ;
         VarsToRow23( bcwwpbaseobjects_SecUserRole) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars23( bcwwpbaseobjects_SecUserRole, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0J23( ) ;
         AfterTrn( ) ;
         VarsToRow23( bcwwpbaseobjects_SecUserRole) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow23( bcwwpbaseobjects_SecUserRole) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.SdtSecUserRole auxBC = new GeneXus.Programs.wwpbaseobjects.SdtSecUserRole(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A133SecUserId, A131SecRoleId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_SecUserRole);
               auxBC.Save();
               bcwwpbaseobjects_SecUserRole.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars23( bcwwpbaseobjects_SecUserRole, 1) ;
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
         RowToVars23( bcwwpbaseobjects_SecUserRole, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0J23( ) ;
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
               VarsToRow23( bcwwpbaseobjects_SecUserRole) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow23( bcwwpbaseobjects_SecUserRole) ;
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
         RowToVars23( bcwwpbaseobjects_SecUserRole, 0) ;
         GetKey0J23( ) ;
         if ( RcdFound23 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A133SecUserId != Z133SecUserId ) || ( A131SecRoleId != Z131SecRoleId ) )
            {
               A133SecUserId = Z133SecUserId;
               A131SecRoleId = Z131SecRoleId;
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
            if ( ( A133SecUserId != Z133SecUserId ) || ( A131SecRoleId != Z131SecRoleId ) )
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
         context.RollbackDataStores("wwpbaseobjects.secuserrole_bc",pr_default);
         VarsToRow23( bcwwpbaseobjects_SecUserRole) ;
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
         Gx_mode = bcwwpbaseobjects_SecUserRole.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_SecUserRole.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_SecUserRole )
         {
            bcwwpbaseobjects_SecUserRole = (GeneXus.Programs.wwpbaseobjects.SdtSecUserRole)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_SecUserRole.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_SecUserRole.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow23( bcwwpbaseobjects_SecUserRole) ;
            }
            else
            {
               RowToVars23( bcwwpbaseobjects_SecUserRole, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_SecUserRole.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_SecUserRole.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars23( bcwwpbaseobjects_SecUserRole, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtSecUserRole SecUserRole_BC
      {
         get {
            return bcwwpbaseobjects_SecUserRole ;
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
         pr_default.close(10);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z141SecUserName = "";
         A141SecUserName = "";
         Z140SecRoleName = "";
         A140SecRoleName = "";
         Z139SecRoleDescription = "";
         A139SecRoleDescription = "";
         BC000J6_A141SecUserName = new string[] {""} ;
         BC000J6_n141SecUserName = new bool[] {false} ;
         BC000J6_A140SecRoleName = new string[] {""} ;
         BC000J6_A139SecRoleDescription = new string[] {""} ;
         BC000J6_A647SecUserRoleActive = new bool[] {false} ;
         BC000J6_A133SecUserId = new short[1] ;
         BC000J6_A131SecRoleId = new short[1] ;
         BC000J4_A141SecUserName = new string[] {""} ;
         BC000J4_n141SecUserName = new bool[] {false} ;
         BC000J5_A140SecRoleName = new string[] {""} ;
         BC000J5_A139SecRoleDescription = new string[] {""} ;
         BC000J7_A133SecUserId = new short[1] ;
         BC000J7_A131SecRoleId = new short[1] ;
         BC000J3_A647SecUserRoleActive = new bool[] {false} ;
         BC000J3_A133SecUserId = new short[1] ;
         BC000J3_A131SecRoleId = new short[1] ;
         sMode23 = "";
         BC000J2_A647SecUserRoleActive = new bool[] {false} ;
         BC000J2_A133SecUserId = new short[1] ;
         BC000J2_A131SecRoleId = new short[1] ;
         BC000J11_A141SecUserName = new string[] {""} ;
         BC000J11_n141SecUserName = new bool[] {false} ;
         BC000J12_A140SecRoleName = new string[] {""} ;
         BC000J12_A139SecRoleDescription = new string[] {""} ;
         BC000J13_A141SecUserName = new string[] {""} ;
         BC000J13_n141SecUserName = new bool[] {false} ;
         BC000J13_A140SecRoleName = new string[] {""} ;
         BC000J13_A139SecRoleDescription = new string[] {""} ;
         BC000J13_A647SecUserRoleActive = new bool[] {false} ;
         BC000J13_A133SecUserId = new short[1] ;
         BC000J13_A131SecRoleId = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secuserrole_bc__default(),
            new Object[][] {
                new Object[] {
               BC000J2_A647SecUserRoleActive, BC000J2_A133SecUserId, BC000J2_A131SecRoleId
               }
               , new Object[] {
               BC000J3_A647SecUserRoleActive, BC000J3_A133SecUserId, BC000J3_A131SecRoleId
               }
               , new Object[] {
               BC000J4_A141SecUserName, BC000J4_n141SecUserName
               }
               , new Object[] {
               BC000J5_A140SecRoleName, BC000J5_A139SecRoleDescription
               }
               , new Object[] {
               BC000J6_A141SecUserName, BC000J6_n141SecUserName, BC000J6_A140SecRoleName, BC000J6_A139SecRoleDescription, BC000J6_A647SecUserRoleActive, BC000J6_A133SecUserId, BC000J6_A131SecRoleId
               }
               , new Object[] {
               BC000J7_A133SecUserId, BC000J7_A131SecRoleId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000J11_A141SecUserName, BC000J11_n141SecUserName
               }
               , new Object[] {
               BC000J12_A140SecRoleName, BC000J12_A139SecRoleDescription
               }
               , new Object[] {
               BC000J13_A141SecUserName, BC000J13_n141SecUserName, BC000J13_A140SecRoleName, BC000J13_A139SecRoleDescription, BC000J13_A647SecUserRoleActive, BC000J13_A133SecUserId, BC000J13_A131SecRoleId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z133SecUserId ;
      private short A133SecUserId ;
      private short Z131SecRoleId ;
      private short A131SecRoleId ;
      private short RcdFound23 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode23 ;
      private bool Z647SecUserRoleActive ;
      private bool A647SecUserRoleActive ;
      private bool n141SecUserName ;
      private string Z141SecUserName ;
      private string A141SecUserName ;
      private string Z140SecRoleName ;
      private string A140SecRoleName ;
      private string Z139SecRoleDescription ;
      private string A139SecRoleDescription ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC000J6_A141SecUserName ;
      private bool[] BC000J6_n141SecUserName ;
      private string[] BC000J6_A140SecRoleName ;
      private string[] BC000J6_A139SecRoleDescription ;
      private bool[] BC000J6_A647SecUserRoleActive ;
      private short[] BC000J6_A133SecUserId ;
      private short[] BC000J6_A131SecRoleId ;
      private string[] BC000J4_A141SecUserName ;
      private bool[] BC000J4_n141SecUserName ;
      private string[] BC000J5_A140SecRoleName ;
      private string[] BC000J5_A139SecRoleDescription ;
      private short[] BC000J7_A133SecUserId ;
      private short[] BC000J7_A131SecRoleId ;
      private bool[] BC000J3_A647SecUserRoleActive ;
      private short[] BC000J3_A133SecUserId ;
      private short[] BC000J3_A131SecRoleId ;
      private bool[] BC000J2_A647SecUserRoleActive ;
      private short[] BC000J2_A133SecUserId ;
      private short[] BC000J2_A131SecRoleId ;
      private string[] BC000J11_A141SecUserName ;
      private bool[] BC000J11_n141SecUserName ;
      private string[] BC000J12_A140SecRoleName ;
      private string[] BC000J12_A139SecRoleDescription ;
      private string[] BC000J13_A141SecUserName ;
      private bool[] BC000J13_n141SecUserName ;
      private string[] BC000J13_A140SecRoleName ;
      private string[] BC000J13_A139SecRoleDescription ;
      private bool[] BC000J13_A647SecUserRoleActive ;
      private short[] BC000J13_A133SecUserId ;
      private short[] BC000J13_A131SecRoleId ;
      private GeneXus.Programs.wwpbaseobjects.SdtSecUserRole bcwwpbaseobjects_SecUserRole ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class secuserrole_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000J2;
          prmBC000J2 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0) ,
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmBC000J3;
          prmBC000J3 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0) ,
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmBC000J4;
          prmBC000J4 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0)
          };
          Object[] prmBC000J5;
          prmBC000J5 = new Object[] {
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmBC000J6;
          prmBC000J6 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0) ,
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmBC000J7;
          prmBC000J7 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0) ,
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmBC000J8;
          prmBC000J8 = new Object[] {
          new ParDef("SecUserRoleActive",GXType.Boolean,4,0) ,
          new ParDef("SecUserId",GXType.Int16,4,0) ,
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmBC000J9;
          prmBC000J9 = new Object[] {
          new ParDef("SecUserRoleActive",GXType.Boolean,4,0) ,
          new ParDef("SecUserId",GXType.Int16,4,0) ,
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmBC000J10;
          prmBC000J10 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0) ,
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmBC000J11;
          prmBC000J11 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0)
          };
          Object[] prmBC000J12;
          prmBC000J12 = new Object[] {
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmBC000J13;
          prmBC000J13 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0) ,
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC000J2", "SELECT SecUserRoleActive, SecUserId, SecRoleId FROM SecUserRole WHERE SecUserId = :SecUserId AND SecRoleId = :SecRoleId  FOR UPDATE OF SecUserRole",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000J3", "SELECT SecUserRoleActive, SecUserId, SecRoleId FROM SecUserRole WHERE SecUserId = :SecUserId AND SecRoleId = :SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000J4", "SELECT SecUserName FROM SecUser WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000J5", "SELECT SecRoleName, SecRoleDescription FROM SecRole WHERE SecRoleId = :SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000J6", "SELECT T2.SecUserName, T3.SecRoleName, T3.SecRoleDescription, TM1.SecUserRoleActive, TM1.SecUserId, TM1.SecRoleId FROM ((SecUserRole TM1 INNER JOIN SecUser T2 ON T2.SecUserId = TM1.SecUserId) INNER JOIN SecRole T3 ON T3.SecRoleId = TM1.SecRoleId) WHERE TM1.SecUserId = :SecUserId and TM1.SecRoleId = :SecRoleId ORDER BY TM1.SecUserId, TM1.SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000J7", "SELECT SecUserId, SecRoleId FROM SecUserRole WHERE SecUserId = :SecUserId AND SecRoleId = :SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000J8", "SAVEPOINT gxupdate;INSERT INTO SecUserRole(SecUserRoleActive, SecUserId, SecRoleId) VALUES(:SecUserRoleActive, :SecUserId, :SecRoleId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000J8)
             ,new CursorDef("BC000J9", "SAVEPOINT gxupdate;UPDATE SecUserRole SET SecUserRoleActive=:SecUserRoleActive  WHERE SecUserId = :SecUserId AND SecRoleId = :SecRoleId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000J9)
             ,new CursorDef("BC000J10", "SAVEPOINT gxupdate;DELETE FROM SecUserRole  WHERE SecUserId = :SecUserId AND SecRoleId = :SecRoleId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000J10)
             ,new CursorDef("BC000J11", "SELECT SecUserName FROM SecUser WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000J12", "SELECT SecRoleName, SecRoleDescription FROM SecRole WHERE SecRoleId = :SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000J13", "SELECT T2.SecUserName, T3.SecRoleName, T3.SecRoleDescription, TM1.SecUserRoleActive, TM1.SecUserId, TM1.SecRoleId FROM ((SecUserRole TM1 INNER JOIN SecUser T2 ON T2.SecUserId = TM1.SecUserId) INNER JOIN SecRole T3 ON T3.SecRoleId = TM1.SecRoleId) WHERE TM1.SecUserId = :SecUserId and TM1.SecRoleId = :SecRoleId ORDER BY TM1.SecUserId, TM1.SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000J13,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 1 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.getBool(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.getBool(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                return;
       }
    }

 }

}
