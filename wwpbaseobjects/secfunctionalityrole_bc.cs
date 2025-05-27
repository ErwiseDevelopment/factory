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
   public class secfunctionalityrole_bc : GxSilentTrn, IGxSilentTrn
   {
      public secfunctionalityrole_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secfunctionalityrole_bc( IGxContext context )
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
         ReadRow0F18( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0F18( ) ;
         standaloneModal( ) ;
         AddRow0F18( ) ;
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
               Z128SecFunctionalityId = A128SecFunctionalityId;
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

      protected void CONFIRM_0F0( )
      {
         BeforeValidate0F18( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0F18( ) ;
            }
            else
            {
               CheckExtendedTable0F18( ) ;
               if ( AnyError == 0 )
               {
                  ZM0F18( 2) ;
                  ZM0F18( 3) ;
               }
               CloseExtendedTableCursors0F18( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0F18( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z735SecFunctionalityRoleAtivo = A735SecFunctionalityRoleAtivo;
         }
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z135SecFunctionalityDescription = A135SecFunctionalityDescription;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -1 )
         {
            Z735SecFunctionalityRoleAtivo = A735SecFunctionalityRoleAtivo;
            Z128SecFunctionalityId = A128SecFunctionalityId;
            Z131SecRoleId = A131SecRoleId;
            Z135SecFunctionalityDescription = A135SecFunctionalityDescription;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0F18( )
      {
         /* Using cursor BC000F6 */
         pr_default.execute(4, new Object[] {A128SecFunctionalityId, A131SecRoleId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound18 = 1;
            A135SecFunctionalityDescription = BC000F6_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = BC000F6_n135SecFunctionalityDescription[0];
            A735SecFunctionalityRoleAtivo = BC000F6_A735SecFunctionalityRoleAtivo[0];
            ZM0F18( -1) ;
         }
         pr_default.close(4);
         OnLoadActions0F18( ) ;
      }

      protected void OnLoadActions0F18( )
      {
      }

      protected void CheckExtendedTable0F18( )
      {
         standaloneModal( ) ;
         /* Using cursor BC000F4 */
         pr_default.execute(2, new Object[] {A128SecFunctionalityId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Functionality'.", "ForeignKeyNotFound", 1, "SECFUNCTIONALITYID");
            AnyError = 1;
         }
         A135SecFunctionalityDescription = BC000F4_A135SecFunctionalityDescription[0];
         n135SecFunctionalityDescription = BC000F4_n135SecFunctionalityDescription[0];
         pr_default.close(2);
         /* Using cursor BC000F5 */
         pr_default.execute(3, new Object[] {A131SecRoleId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe 'Role'.", "ForeignKeyNotFound", 1, "SECROLEID");
            AnyError = 1;
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0F18( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0F18( )
      {
         /* Using cursor BC000F7 */
         pr_default.execute(5, new Object[] {A128SecFunctionalityId, A131SecRoleId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound18 = 1;
         }
         else
         {
            RcdFound18 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000F3 */
         pr_default.execute(1, new Object[] {A128SecFunctionalityId, A131SecRoleId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0F18( 1) ;
            RcdFound18 = 1;
            A735SecFunctionalityRoleAtivo = BC000F3_A735SecFunctionalityRoleAtivo[0];
            A128SecFunctionalityId = BC000F3_A128SecFunctionalityId[0];
            A131SecRoleId = BC000F3_A131SecRoleId[0];
            Z128SecFunctionalityId = A128SecFunctionalityId;
            Z131SecRoleId = A131SecRoleId;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0F18( ) ;
            if ( AnyError == 1 )
            {
               RcdFound18 = 0;
               InitializeNonKey0F18( ) ;
            }
            Gx_mode = sMode18;
         }
         else
         {
            RcdFound18 = 0;
            InitializeNonKey0F18( ) ;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode18;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0F18( ) ;
         if ( RcdFound18 == 0 )
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
         CONFIRM_0F0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0F18( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000F2 */
            pr_default.execute(0, new Object[] {A128SecFunctionalityId, A131SecRoleId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecFunctionalityRole"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z735SecFunctionalityRoleAtivo != BC000F2_A735SecFunctionalityRoleAtivo[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SecFunctionalityRole"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0F18( )
      {
         BeforeValidate0F18( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F18( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0F18( 0) ;
            CheckOptimisticConcurrency0F18( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F18( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0F18( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000F8 */
                     pr_default.execute(6, new Object[] {A735SecFunctionalityRoleAtivo, A128SecFunctionalityId, A131SecRoleId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("SecFunctionalityRole");
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
               Load0F18( ) ;
            }
            EndLevel0F18( ) ;
         }
         CloseExtendedTableCursors0F18( ) ;
      }

      protected void Update0F18( )
      {
         BeforeValidate0F18( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F18( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F18( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F18( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0F18( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000F9 */
                     pr_default.execute(7, new Object[] {A735SecFunctionalityRoleAtivo, A128SecFunctionalityId, A131SecRoleId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("SecFunctionalityRole");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecFunctionalityRole"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0F18( ) ;
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
            EndLevel0F18( ) ;
         }
         CloseExtendedTableCursors0F18( ) ;
      }

      protected void DeferredUpdate0F18( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0F18( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F18( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0F18( ) ;
            AfterConfirm0F18( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0F18( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000F10 */
                  pr_default.execute(8, new Object[] {A128SecFunctionalityId, A131SecRoleId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("SecFunctionalityRole");
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
         sMode18 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0F18( ) ;
         Gx_mode = sMode18;
      }

      protected void OnDeleteControls0F18( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000F11 */
            pr_default.execute(9, new Object[] {A128SecFunctionalityId});
            A135SecFunctionalityDescription = BC000F11_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = BC000F11_n135SecFunctionalityDescription[0];
            pr_default.close(9);
         }
      }

      protected void EndLevel0F18( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0F18( ) ;
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

      public void ScanKeyStart0F18( )
      {
         /* Scan By routine */
         /* Using cursor BC000F12 */
         pr_default.execute(10, new Object[] {A128SecFunctionalityId, A131SecRoleId});
         RcdFound18 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound18 = 1;
            A135SecFunctionalityDescription = BC000F12_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = BC000F12_n135SecFunctionalityDescription[0];
            A735SecFunctionalityRoleAtivo = BC000F12_A735SecFunctionalityRoleAtivo[0];
            A128SecFunctionalityId = BC000F12_A128SecFunctionalityId[0];
            A131SecRoleId = BC000F12_A131SecRoleId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0F18( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound18 = 0;
         ScanKeyLoad0F18( ) ;
      }

      protected void ScanKeyLoad0F18( )
      {
         sMode18 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound18 = 1;
            A135SecFunctionalityDescription = BC000F12_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = BC000F12_n135SecFunctionalityDescription[0];
            A735SecFunctionalityRoleAtivo = BC000F12_A735SecFunctionalityRoleAtivo[0];
            A128SecFunctionalityId = BC000F12_A128SecFunctionalityId[0];
            A131SecRoleId = BC000F12_A131SecRoleId[0];
         }
         Gx_mode = sMode18;
      }

      protected void ScanKeyEnd0F18( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0F18( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0F18( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0F18( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0F18( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0F18( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0F18( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0F18( )
      {
      }

      protected void send_integrity_lvl_hashes0F18( )
      {
      }

      protected void AddRow0F18( )
      {
         VarsToRow18( bcwwpbaseobjects_SecFunctionalityRole) ;
      }

      protected void ReadRow0F18( )
      {
         RowToVars18( bcwwpbaseobjects_SecFunctionalityRole, 1) ;
      }

      protected void InitializeNonKey0F18( )
      {
         A135SecFunctionalityDescription = "";
         n135SecFunctionalityDescription = false;
         A735SecFunctionalityRoleAtivo = false;
         Z735SecFunctionalityRoleAtivo = false;
      }

      protected void InitAll0F18( )
      {
         A128SecFunctionalityId = 0;
         A131SecRoleId = 0;
         InitializeNonKey0F18( ) ;
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

      public void VarsToRow18( GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole obj18 )
      {
         obj18.gxTpr_Mode = Gx_mode;
         obj18.gxTpr_Secfunctionalitydescription = A135SecFunctionalityDescription;
         obj18.gxTpr_Secfunctionalityroleativo = A735SecFunctionalityRoleAtivo;
         obj18.gxTpr_Secfunctionalityid = A128SecFunctionalityId;
         obj18.gxTpr_Secroleid = A131SecRoleId;
         obj18.gxTpr_Secfunctionalityid_Z = Z128SecFunctionalityId;
         obj18.gxTpr_Secfunctionalitydescription_Z = Z135SecFunctionalityDescription;
         obj18.gxTpr_Secroleid_Z = Z131SecRoleId;
         obj18.gxTpr_Secfunctionalityroleativo_Z = Z735SecFunctionalityRoleAtivo;
         obj18.gxTpr_Secfunctionalitydescription_N = (short)(Convert.ToInt16(n135SecFunctionalityDescription));
         obj18.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow18( GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole obj18 )
      {
         obj18.gxTpr_Secfunctionalityid = A128SecFunctionalityId;
         obj18.gxTpr_Secroleid = A131SecRoleId;
         return  ;
      }

      public void RowToVars18( GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole obj18 ,
                               int forceLoad )
      {
         Gx_mode = obj18.gxTpr_Mode;
         A135SecFunctionalityDescription = obj18.gxTpr_Secfunctionalitydescription;
         n135SecFunctionalityDescription = false;
         A735SecFunctionalityRoleAtivo = obj18.gxTpr_Secfunctionalityroleativo;
         A128SecFunctionalityId = obj18.gxTpr_Secfunctionalityid;
         A131SecRoleId = obj18.gxTpr_Secroleid;
         Z128SecFunctionalityId = obj18.gxTpr_Secfunctionalityid_Z;
         Z135SecFunctionalityDescription = obj18.gxTpr_Secfunctionalitydescription_Z;
         Z131SecRoleId = obj18.gxTpr_Secroleid_Z;
         Z735SecFunctionalityRoleAtivo = obj18.gxTpr_Secfunctionalityroleativo_Z;
         n135SecFunctionalityDescription = (bool)(Convert.ToBoolean(obj18.gxTpr_Secfunctionalitydescription_N));
         Gx_mode = obj18.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A128SecFunctionalityId = (long)getParm(obj,0);
         A131SecRoleId = (short)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0F18( ) ;
         ScanKeyStart0F18( ) ;
         if ( RcdFound18 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000F11 */
            pr_default.execute(9, new Object[] {A128SecFunctionalityId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem("Não existe 'Functionality'.", "ForeignKeyNotFound", 1, "SECFUNCTIONALITYID");
               AnyError = 1;
            }
            A135SecFunctionalityDescription = BC000F11_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = BC000F11_n135SecFunctionalityDescription[0];
            pr_default.close(9);
            /* Using cursor BC000F13 */
            pr_default.execute(11, new Object[] {A131SecRoleId});
            if ( (pr_default.getStatus(11) == 101) )
            {
               GX_msglist.addItem("Não existe 'Role'.", "ForeignKeyNotFound", 1, "SECROLEID");
               AnyError = 1;
            }
            pr_default.close(11);
         }
         else
         {
            Gx_mode = "UPD";
            Z128SecFunctionalityId = A128SecFunctionalityId;
            Z131SecRoleId = A131SecRoleId;
         }
         ZM0F18( -1) ;
         OnLoadActions0F18( ) ;
         AddRow0F18( ) ;
         ScanKeyEnd0F18( ) ;
         if ( RcdFound18 == 0 )
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
         RowToVars18( bcwwpbaseobjects_SecFunctionalityRole, 0) ;
         ScanKeyStart0F18( ) ;
         if ( RcdFound18 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000F11 */
            pr_default.execute(9, new Object[] {A128SecFunctionalityId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem("Não existe 'Functionality'.", "ForeignKeyNotFound", 1, "SECFUNCTIONALITYID");
               AnyError = 1;
            }
            A135SecFunctionalityDescription = BC000F11_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = BC000F11_n135SecFunctionalityDescription[0];
            pr_default.close(9);
            /* Using cursor BC000F13 */
            pr_default.execute(11, new Object[] {A131SecRoleId});
            if ( (pr_default.getStatus(11) == 101) )
            {
               GX_msglist.addItem("Não existe 'Role'.", "ForeignKeyNotFound", 1, "SECROLEID");
               AnyError = 1;
            }
            pr_default.close(11);
         }
         else
         {
            Gx_mode = "UPD";
            Z128SecFunctionalityId = A128SecFunctionalityId;
            Z131SecRoleId = A131SecRoleId;
         }
         ZM0F18( -1) ;
         OnLoadActions0F18( ) ;
         AddRow0F18( ) ;
         ScanKeyEnd0F18( ) ;
         if ( RcdFound18 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0F18( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0F18( ) ;
         }
         else
         {
            if ( RcdFound18 == 1 )
            {
               if ( ( A128SecFunctionalityId != Z128SecFunctionalityId ) || ( A131SecRoleId != Z131SecRoleId ) )
               {
                  A128SecFunctionalityId = Z128SecFunctionalityId;
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
                  Update0F18( ) ;
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
                  if ( ( A128SecFunctionalityId != Z128SecFunctionalityId ) || ( A131SecRoleId != Z131SecRoleId ) )
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
                        Insert0F18( ) ;
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
                        Insert0F18( ) ;
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
         RowToVars18( bcwwpbaseobjects_SecFunctionalityRole, 1) ;
         SaveImpl( ) ;
         VarsToRow18( bcwwpbaseobjects_SecFunctionalityRole) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars18( bcwwpbaseobjects_SecFunctionalityRole, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0F18( ) ;
         AfterTrn( ) ;
         VarsToRow18( bcwwpbaseobjects_SecFunctionalityRole) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow18( bcwwpbaseobjects_SecFunctionalityRole) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole auxBC = new GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A128SecFunctionalityId, A131SecRoleId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_SecFunctionalityRole);
               auxBC.Save();
               bcwwpbaseobjects_SecFunctionalityRole.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars18( bcwwpbaseobjects_SecFunctionalityRole, 1) ;
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
         RowToVars18( bcwwpbaseobjects_SecFunctionalityRole, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0F18( ) ;
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
               VarsToRow18( bcwwpbaseobjects_SecFunctionalityRole) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow18( bcwwpbaseobjects_SecFunctionalityRole) ;
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
         RowToVars18( bcwwpbaseobjects_SecFunctionalityRole, 0) ;
         GetKey0F18( ) ;
         if ( RcdFound18 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A128SecFunctionalityId != Z128SecFunctionalityId ) || ( A131SecRoleId != Z131SecRoleId ) )
            {
               A128SecFunctionalityId = Z128SecFunctionalityId;
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
            if ( ( A128SecFunctionalityId != Z128SecFunctionalityId ) || ( A131SecRoleId != Z131SecRoleId ) )
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
         context.RollbackDataStores("wwpbaseobjects.secfunctionalityrole_bc",pr_default);
         VarsToRow18( bcwwpbaseobjects_SecFunctionalityRole) ;
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
         Gx_mode = bcwwpbaseobjects_SecFunctionalityRole.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_SecFunctionalityRole.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_SecFunctionalityRole )
         {
            bcwwpbaseobjects_SecFunctionalityRole = (GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_SecFunctionalityRole.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_SecFunctionalityRole.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow18( bcwwpbaseobjects_SecFunctionalityRole) ;
            }
            else
            {
               RowToVars18( bcwwpbaseobjects_SecFunctionalityRole, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_SecFunctionalityRole.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_SecFunctionalityRole.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars18( bcwwpbaseobjects_SecFunctionalityRole, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtSecFunctionalityRole SecFunctionalityRole_BC
      {
         get {
            return bcwwpbaseobjects_SecFunctionalityRole ;
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
         pr_default.close(11);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z135SecFunctionalityDescription = "";
         A135SecFunctionalityDescription = "";
         BC000F6_A135SecFunctionalityDescription = new string[] {""} ;
         BC000F6_n135SecFunctionalityDescription = new bool[] {false} ;
         BC000F6_A735SecFunctionalityRoleAtivo = new bool[] {false} ;
         BC000F6_A128SecFunctionalityId = new long[1] ;
         BC000F6_A131SecRoleId = new short[1] ;
         BC000F4_A135SecFunctionalityDescription = new string[] {""} ;
         BC000F4_n135SecFunctionalityDescription = new bool[] {false} ;
         BC000F5_A131SecRoleId = new short[1] ;
         BC000F7_A128SecFunctionalityId = new long[1] ;
         BC000F7_A131SecRoleId = new short[1] ;
         BC000F3_A735SecFunctionalityRoleAtivo = new bool[] {false} ;
         BC000F3_A128SecFunctionalityId = new long[1] ;
         BC000F3_A131SecRoleId = new short[1] ;
         sMode18 = "";
         BC000F2_A735SecFunctionalityRoleAtivo = new bool[] {false} ;
         BC000F2_A128SecFunctionalityId = new long[1] ;
         BC000F2_A131SecRoleId = new short[1] ;
         BC000F11_A135SecFunctionalityDescription = new string[] {""} ;
         BC000F11_n135SecFunctionalityDescription = new bool[] {false} ;
         BC000F12_A135SecFunctionalityDescription = new string[] {""} ;
         BC000F12_n135SecFunctionalityDescription = new bool[] {false} ;
         BC000F12_A735SecFunctionalityRoleAtivo = new bool[] {false} ;
         BC000F12_A128SecFunctionalityId = new long[1] ;
         BC000F12_A131SecRoleId = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC000F13_A131SecRoleId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secfunctionalityrole_bc__default(),
            new Object[][] {
                new Object[] {
               BC000F2_A735SecFunctionalityRoleAtivo, BC000F2_A128SecFunctionalityId, BC000F2_A131SecRoleId
               }
               , new Object[] {
               BC000F3_A735SecFunctionalityRoleAtivo, BC000F3_A128SecFunctionalityId, BC000F3_A131SecRoleId
               }
               , new Object[] {
               BC000F4_A135SecFunctionalityDescription, BC000F4_n135SecFunctionalityDescription
               }
               , new Object[] {
               BC000F5_A131SecRoleId
               }
               , new Object[] {
               BC000F6_A135SecFunctionalityDescription, BC000F6_n135SecFunctionalityDescription, BC000F6_A735SecFunctionalityRoleAtivo, BC000F6_A128SecFunctionalityId, BC000F6_A131SecRoleId
               }
               , new Object[] {
               BC000F7_A128SecFunctionalityId, BC000F7_A131SecRoleId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000F11_A135SecFunctionalityDescription, BC000F11_n135SecFunctionalityDescription
               }
               , new Object[] {
               BC000F12_A135SecFunctionalityDescription, BC000F12_n135SecFunctionalityDescription, BC000F12_A735SecFunctionalityRoleAtivo, BC000F12_A128SecFunctionalityId, BC000F12_A131SecRoleId
               }
               , new Object[] {
               BC000F13_A131SecRoleId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z131SecRoleId ;
      private short A131SecRoleId ;
      private short RcdFound18 ;
      private int trnEnded ;
      private long Z128SecFunctionalityId ;
      private long A128SecFunctionalityId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode18 ;
      private bool Z735SecFunctionalityRoleAtivo ;
      private bool A735SecFunctionalityRoleAtivo ;
      private bool n135SecFunctionalityDescription ;
      private string Z135SecFunctionalityDescription ;
      private string A135SecFunctionalityDescription ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC000F6_A135SecFunctionalityDescription ;
      private bool[] BC000F6_n135SecFunctionalityDescription ;
      private bool[] BC000F6_A735SecFunctionalityRoleAtivo ;
      private long[] BC000F6_A128SecFunctionalityId ;
      private short[] BC000F6_A131SecRoleId ;
      private string[] BC000F4_A135SecFunctionalityDescription ;
      private bool[] BC000F4_n135SecFunctionalityDescription ;
      private short[] BC000F5_A131SecRoleId ;
      private long[] BC000F7_A128SecFunctionalityId ;
      private short[] BC000F7_A131SecRoleId ;
      private bool[] BC000F3_A735SecFunctionalityRoleAtivo ;
      private long[] BC000F3_A128SecFunctionalityId ;
      private short[] BC000F3_A131SecRoleId ;
      private bool[] BC000F2_A735SecFunctionalityRoleAtivo ;
      private long[] BC000F2_A128SecFunctionalityId ;
      private short[] BC000F2_A131SecRoleId ;
      private string[] BC000F11_A135SecFunctionalityDescription ;
      private bool[] BC000F11_n135SecFunctionalityDescription ;
      private string[] BC000F12_A135SecFunctionalityDescription ;
      private bool[] BC000F12_n135SecFunctionalityDescription ;
      private bool[] BC000F12_A735SecFunctionalityRoleAtivo ;
      private long[] BC000F12_A128SecFunctionalityId ;
      private short[] BC000F12_A131SecRoleId ;
      private GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole bcwwpbaseobjects_SecFunctionalityRole ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short[] BC000F13_A131SecRoleId ;
   }

   public class secfunctionalityrole_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC000F2;
          prmBC000F2 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0) ,
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmBC000F3;
          prmBC000F3 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0) ,
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmBC000F4;
          prmBC000F4 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmBC000F5;
          prmBC000F5 = new Object[] {
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmBC000F6;
          prmBC000F6 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0) ,
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmBC000F7;
          prmBC000F7 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0) ,
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmBC000F8;
          prmBC000F8 = new Object[] {
          new ParDef("SecFunctionalityRoleAtivo",GXType.Boolean,4,0) ,
          new ParDef("SecFunctionalityId",GXType.Int64,10,0) ,
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmBC000F9;
          prmBC000F9 = new Object[] {
          new ParDef("SecFunctionalityRoleAtivo",GXType.Boolean,4,0) ,
          new ParDef("SecFunctionalityId",GXType.Int64,10,0) ,
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmBC000F10;
          prmBC000F10 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0) ,
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmBC000F11;
          prmBC000F11 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmBC000F12;
          prmBC000F12 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0) ,
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmBC000F13;
          prmBC000F13 = new Object[] {
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC000F2", "SELECT SecFunctionalityRoleAtivo, SecFunctionalityId, SecRoleId FROM SecFunctionalityRole WHERE SecFunctionalityId = :SecFunctionalityId AND SecRoleId = :SecRoleId  FOR UPDATE OF SecFunctionalityRole",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000F3", "SELECT SecFunctionalityRoleAtivo, SecFunctionalityId, SecRoleId FROM SecFunctionalityRole WHERE SecFunctionalityId = :SecFunctionalityId AND SecRoleId = :SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000F4", "SELECT SecFunctionalityDescription FROM SecFunctionality WHERE SecFunctionalityId = :SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000F5", "SELECT SecRoleId FROM SecRole WHERE SecRoleId = :SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000F6", "SELECT T2.SecFunctionalityDescription, TM1.SecFunctionalityRoleAtivo, TM1.SecFunctionalityId, TM1.SecRoleId FROM (SecFunctionalityRole TM1 INNER JOIN SecFunctionality T2 ON T2.SecFunctionalityId = TM1.SecFunctionalityId) WHERE TM1.SecFunctionalityId = :SecFunctionalityId and TM1.SecRoleId = :SecRoleId ORDER BY TM1.SecFunctionalityId, TM1.SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000F7", "SELECT SecFunctionalityId, SecRoleId FROM SecFunctionalityRole WHERE SecFunctionalityId = :SecFunctionalityId AND SecRoleId = :SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000F8", "SAVEPOINT gxupdate;INSERT INTO SecFunctionalityRole(SecFunctionalityRoleAtivo, SecFunctionalityId, SecRoleId) VALUES(:SecFunctionalityRoleAtivo, :SecFunctionalityId, :SecRoleId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000F8)
             ,new CursorDef("BC000F9", "SAVEPOINT gxupdate;UPDATE SecFunctionalityRole SET SecFunctionalityRoleAtivo=:SecFunctionalityRoleAtivo  WHERE SecFunctionalityId = :SecFunctionalityId AND SecRoleId = :SecRoleId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000F9)
             ,new CursorDef("BC000F10", "SAVEPOINT gxupdate;DELETE FROM SecFunctionalityRole  WHERE SecFunctionalityId = :SecFunctionalityId AND SecRoleId = :SecRoleId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000F10)
             ,new CursorDef("BC000F11", "SELECT SecFunctionalityDescription FROM SecFunctionality WHERE SecFunctionalityId = :SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000F12", "SELECT T2.SecFunctionalityDescription, TM1.SecFunctionalityRoleAtivo, TM1.SecFunctionalityId, TM1.SecRoleId FROM (SecFunctionalityRole TM1 INNER JOIN SecFunctionality T2 ON T2.SecFunctionalityId = TM1.SecFunctionalityId) WHERE TM1.SecFunctionalityId = :SecFunctionalityId and TM1.SecRoleId = :SecRoleId ORDER BY TM1.SecFunctionalityId, TM1.SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F12,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000F13", "SELECT SecRoleId FROM SecRole WHERE SecRoleId = :SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F13,1, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 1 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
