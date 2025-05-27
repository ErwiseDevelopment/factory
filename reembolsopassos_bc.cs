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
   public class reembolsopassos_bc : GxSilentTrn, IGxSilentTrn
   {
      public reembolsopassos_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public reembolsopassos_bc( IGxContext context )
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
         ReadRow2L90( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2L90( ) ;
         standaloneModal( ) ;
         AddRow2L90( ) ;
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
               Z738ReembolsoPassos = A738ReembolsoPassos;
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

      protected void CONFIRM_2L0( )
      {
         BeforeValidate2L90( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2L90( ) ;
            }
            else
            {
               CheckExtendedTable2L90( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors2L90( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM2L90( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z739ReembolsoPassosNome = A739ReembolsoPassosNome;
            Z740ReembolsoPassosStatus = A740ReembolsoPassosStatus;
            Z741ReembolsoPassosSLALembrete = A741ReembolsoPassosSLALembrete;
         }
         if ( GX_JID == -1 )
         {
            Z738ReembolsoPassos = A738ReembolsoPassos;
            Z739ReembolsoPassosNome = A739ReembolsoPassosNome;
            Z740ReembolsoPassosStatus = A740ReembolsoPassosStatus;
            Z741ReembolsoPassosSLALembrete = A741ReembolsoPassosSLALembrete;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load2L90( )
      {
         /* Using cursor BC002L4 */
         pr_default.execute(2, new Object[] {A738ReembolsoPassos});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound90 = 1;
            A739ReembolsoPassosNome = BC002L4_A739ReembolsoPassosNome[0];
            n739ReembolsoPassosNome = BC002L4_n739ReembolsoPassosNome[0];
            A740ReembolsoPassosStatus = BC002L4_A740ReembolsoPassosStatus[0];
            n740ReembolsoPassosStatus = BC002L4_n740ReembolsoPassosStatus[0];
            A741ReembolsoPassosSLALembrete = BC002L4_A741ReembolsoPassosSLALembrete[0];
            n741ReembolsoPassosSLALembrete = BC002L4_n741ReembolsoPassosSLALembrete[0];
            ZM2L90( -1) ;
         }
         pr_default.close(2);
         OnLoadActions2L90( ) ;
      }

      protected void OnLoadActions2L90( )
      {
      }

      protected void CheckExtendedTable2L90( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors2L90( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2L90( )
      {
         /* Using cursor BC002L5 */
         pr_default.execute(3, new Object[] {A738ReembolsoPassos});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound90 = 1;
         }
         else
         {
            RcdFound90 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC002L3 */
         pr_default.execute(1, new Object[] {A738ReembolsoPassos});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2L90( 1) ;
            RcdFound90 = 1;
            A738ReembolsoPassos = BC002L3_A738ReembolsoPassos[0];
            A739ReembolsoPassosNome = BC002L3_A739ReembolsoPassosNome[0];
            n739ReembolsoPassosNome = BC002L3_n739ReembolsoPassosNome[0];
            A740ReembolsoPassosStatus = BC002L3_A740ReembolsoPassosStatus[0];
            n740ReembolsoPassosStatus = BC002L3_n740ReembolsoPassosStatus[0];
            A741ReembolsoPassosSLALembrete = BC002L3_A741ReembolsoPassosSLALembrete[0];
            n741ReembolsoPassosSLALembrete = BC002L3_n741ReembolsoPassosSLALembrete[0];
            Z738ReembolsoPassos = A738ReembolsoPassos;
            sMode90 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2L90( ) ;
            if ( AnyError == 1 )
            {
               RcdFound90 = 0;
               InitializeNonKey2L90( ) ;
            }
            Gx_mode = sMode90;
         }
         else
         {
            RcdFound90 = 0;
            InitializeNonKey2L90( ) ;
            sMode90 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode90;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2L90( ) ;
         if ( RcdFound90 == 0 )
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
         CONFIRM_2L0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2L90( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC002L2 */
            pr_default.execute(0, new Object[] {A738ReembolsoPassos});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ReembolsoPassos"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z739ReembolsoPassosNome, BC002L2_A739ReembolsoPassosNome[0]) != 0 ) || ( Z740ReembolsoPassosStatus != BC002L2_A740ReembolsoPassosStatus[0] ) || ( Z741ReembolsoPassosSLALembrete != BC002L2_A741ReembolsoPassosSLALembrete[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ReembolsoPassos"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2L90( )
      {
         BeforeValidate2L90( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2L90( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2L90( 0) ;
            CheckOptimisticConcurrency2L90( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2L90( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2L90( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002L6 */
                     pr_default.execute(4, new Object[] {A738ReembolsoPassos, n739ReembolsoPassosNome, A739ReembolsoPassosNome, n740ReembolsoPassosStatus, A740ReembolsoPassosStatus, n741ReembolsoPassosSLALembrete, A741ReembolsoPassosSLALembrete});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("ReembolsoPassos");
                     if ( (pr_default.getStatus(4) == 1) )
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
               Load2L90( ) ;
            }
            EndLevel2L90( ) ;
         }
         CloseExtendedTableCursors2L90( ) ;
      }

      protected void Update2L90( )
      {
         BeforeValidate2L90( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2L90( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2L90( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2L90( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2L90( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002L7 */
                     pr_default.execute(5, new Object[] {n739ReembolsoPassosNome, A739ReembolsoPassosNome, n740ReembolsoPassosStatus, A740ReembolsoPassosStatus, n741ReembolsoPassosSLALembrete, A741ReembolsoPassosSLALembrete, A738ReembolsoPassos});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("ReembolsoPassos");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ReembolsoPassos"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2L90( ) ;
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
            EndLevel2L90( ) ;
         }
         CloseExtendedTableCursors2L90( ) ;
      }

      protected void DeferredUpdate2L90( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2L90( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2L90( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2L90( ) ;
            AfterConfirm2L90( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2L90( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002L8 */
                  pr_default.execute(6, new Object[] {A738ReembolsoPassos});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("ReembolsoPassos");
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
         sMode90 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2L90( ) ;
         Gx_mode = sMode90;
      }

      protected void OnDeleteControls2L90( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2L90( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2L90( ) ;
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

      public void ScanKeyStart2L90( )
      {
         /* Using cursor BC002L9 */
         pr_default.execute(7, new Object[] {A738ReembolsoPassos});
         RcdFound90 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound90 = 1;
            A738ReembolsoPassos = BC002L9_A738ReembolsoPassos[0];
            A739ReembolsoPassosNome = BC002L9_A739ReembolsoPassosNome[0];
            n739ReembolsoPassosNome = BC002L9_n739ReembolsoPassosNome[0];
            A740ReembolsoPassosStatus = BC002L9_A740ReembolsoPassosStatus[0];
            n740ReembolsoPassosStatus = BC002L9_n740ReembolsoPassosStatus[0];
            A741ReembolsoPassosSLALembrete = BC002L9_A741ReembolsoPassosSLALembrete[0];
            n741ReembolsoPassosSLALembrete = BC002L9_n741ReembolsoPassosSLALembrete[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2L90( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound90 = 0;
         ScanKeyLoad2L90( ) ;
      }

      protected void ScanKeyLoad2L90( )
      {
         sMode90 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound90 = 1;
            A738ReembolsoPassos = BC002L9_A738ReembolsoPassos[0];
            A739ReembolsoPassosNome = BC002L9_A739ReembolsoPassosNome[0];
            n739ReembolsoPassosNome = BC002L9_n739ReembolsoPassosNome[0];
            A740ReembolsoPassosStatus = BC002L9_A740ReembolsoPassosStatus[0];
            n740ReembolsoPassosStatus = BC002L9_n740ReembolsoPassosStatus[0];
            A741ReembolsoPassosSLALembrete = BC002L9_A741ReembolsoPassosSLALembrete[0];
            n741ReembolsoPassosSLALembrete = BC002L9_n741ReembolsoPassosSLALembrete[0];
         }
         Gx_mode = sMode90;
      }

      protected void ScanKeyEnd2L90( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm2L90( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2L90( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2L90( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2L90( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2L90( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2L90( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2L90( )
      {
      }

      protected void send_integrity_lvl_hashes2L90( )
      {
      }

      protected void AddRow2L90( )
      {
         VarsToRow90( bcReembolsoPassos) ;
      }

      protected void ReadRow2L90( )
      {
         RowToVars90( bcReembolsoPassos, 1) ;
      }

      protected void InitializeNonKey2L90( )
      {
         A739ReembolsoPassosNome = "";
         n739ReembolsoPassosNome = false;
         A740ReembolsoPassosStatus = false;
         n740ReembolsoPassosStatus = false;
         A741ReembolsoPassosSLALembrete = 0;
         n741ReembolsoPassosSLALembrete = false;
         Z739ReembolsoPassosNome = "";
         Z740ReembolsoPassosStatus = false;
         Z741ReembolsoPassosSLALembrete = 0;
      }

      protected void InitAll2L90( )
      {
         A738ReembolsoPassos = 0;
         InitializeNonKey2L90( ) ;
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

      public void VarsToRow90( SdtReembolsoPassos obj90 )
      {
         obj90.gxTpr_Mode = Gx_mode;
         obj90.gxTpr_Reembolsopassosnome = A739ReembolsoPassosNome;
         obj90.gxTpr_Reembolsopassosstatus = A740ReembolsoPassosStatus;
         obj90.gxTpr_Reembolsopassosslalembrete = A741ReembolsoPassosSLALembrete;
         obj90.gxTpr_Reembolsopassos = A738ReembolsoPassos;
         obj90.gxTpr_Reembolsopassos_Z = Z738ReembolsoPassos;
         obj90.gxTpr_Reembolsopassosnome_Z = Z739ReembolsoPassosNome;
         obj90.gxTpr_Reembolsopassosstatus_Z = Z740ReembolsoPassosStatus;
         obj90.gxTpr_Reembolsopassosslalembrete_Z = Z741ReembolsoPassosSLALembrete;
         obj90.gxTpr_Reembolsopassosnome_N = (short)(Convert.ToInt16(n739ReembolsoPassosNome));
         obj90.gxTpr_Reembolsopassosstatus_N = (short)(Convert.ToInt16(n740ReembolsoPassosStatus));
         obj90.gxTpr_Reembolsopassosslalembrete_N = (short)(Convert.ToInt16(n741ReembolsoPassosSLALembrete));
         obj90.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow90( SdtReembolsoPassos obj90 )
      {
         obj90.gxTpr_Reembolsopassos = A738ReembolsoPassos;
         return  ;
      }

      public void RowToVars90( SdtReembolsoPassos obj90 ,
                               int forceLoad )
      {
         Gx_mode = obj90.gxTpr_Mode;
         A739ReembolsoPassosNome = obj90.gxTpr_Reembolsopassosnome;
         n739ReembolsoPassosNome = false;
         A740ReembolsoPassosStatus = obj90.gxTpr_Reembolsopassosstatus;
         n740ReembolsoPassosStatus = false;
         A741ReembolsoPassosSLALembrete = obj90.gxTpr_Reembolsopassosslalembrete;
         n741ReembolsoPassosSLALembrete = false;
         A738ReembolsoPassos = obj90.gxTpr_Reembolsopassos;
         Z738ReembolsoPassos = obj90.gxTpr_Reembolsopassos_Z;
         Z739ReembolsoPassosNome = obj90.gxTpr_Reembolsopassosnome_Z;
         Z740ReembolsoPassosStatus = obj90.gxTpr_Reembolsopassosstatus_Z;
         Z741ReembolsoPassosSLALembrete = obj90.gxTpr_Reembolsopassosslalembrete_Z;
         n739ReembolsoPassosNome = (bool)(Convert.ToBoolean(obj90.gxTpr_Reembolsopassosnome_N));
         n740ReembolsoPassosStatus = (bool)(Convert.ToBoolean(obj90.gxTpr_Reembolsopassosstatus_N));
         n741ReembolsoPassosSLALembrete = (bool)(Convert.ToBoolean(obj90.gxTpr_Reembolsopassosslalembrete_N));
         Gx_mode = obj90.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A738ReembolsoPassos = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2L90( ) ;
         ScanKeyStart2L90( ) ;
         if ( RcdFound90 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z738ReembolsoPassos = A738ReembolsoPassos;
         }
         ZM2L90( -1) ;
         OnLoadActions2L90( ) ;
         AddRow2L90( ) ;
         ScanKeyEnd2L90( ) ;
         if ( RcdFound90 == 0 )
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
         RowToVars90( bcReembolsoPassos, 0) ;
         ScanKeyStart2L90( ) ;
         if ( RcdFound90 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z738ReembolsoPassos = A738ReembolsoPassos;
         }
         ZM2L90( -1) ;
         OnLoadActions2L90( ) ;
         AddRow2L90( ) ;
         ScanKeyEnd2L90( ) ;
         if ( RcdFound90 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2L90( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2L90( ) ;
         }
         else
         {
            if ( RcdFound90 == 1 )
            {
               if ( A738ReembolsoPassos != Z738ReembolsoPassos )
               {
                  A738ReembolsoPassos = Z738ReembolsoPassos;
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
                  Update2L90( ) ;
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
                  if ( A738ReembolsoPassos != Z738ReembolsoPassos )
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
                        Insert2L90( ) ;
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
                        Insert2L90( ) ;
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
         RowToVars90( bcReembolsoPassos, 1) ;
         SaveImpl( ) ;
         VarsToRow90( bcReembolsoPassos) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars90( bcReembolsoPassos, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2L90( ) ;
         AfterTrn( ) ;
         VarsToRow90( bcReembolsoPassos) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow90( bcReembolsoPassos) ;
         }
         else
         {
            SdtReembolsoPassos auxBC = new SdtReembolsoPassos(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A738ReembolsoPassos);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcReembolsoPassos);
               auxBC.Save();
               bcReembolsoPassos.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars90( bcReembolsoPassos, 1) ;
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
         RowToVars90( bcReembolsoPassos, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2L90( ) ;
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
               VarsToRow90( bcReembolsoPassos) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow90( bcReembolsoPassos) ;
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
         RowToVars90( bcReembolsoPassos, 0) ;
         GetKey2L90( ) ;
         if ( RcdFound90 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A738ReembolsoPassos != Z738ReembolsoPassos )
            {
               A738ReembolsoPassos = Z738ReembolsoPassos;
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
            if ( A738ReembolsoPassos != Z738ReembolsoPassos )
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
         context.RollbackDataStores("reembolsopassos_bc",pr_default);
         VarsToRow90( bcReembolsoPassos) ;
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
         Gx_mode = bcReembolsoPassos.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcReembolsoPassos.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcReembolsoPassos )
         {
            bcReembolsoPassos = (SdtReembolsoPassos)(sdt);
            if ( StringUtil.StrCmp(bcReembolsoPassos.gxTpr_Mode, "") == 0 )
            {
               bcReembolsoPassos.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow90( bcReembolsoPassos) ;
            }
            else
            {
               RowToVars90( bcReembolsoPassos, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcReembolsoPassos.gxTpr_Mode, "") == 0 )
            {
               bcReembolsoPassos.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars90( bcReembolsoPassos, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtReembolsoPassos ReembolsoPassos_BC
      {
         get {
            return bcReembolsoPassos ;
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
         Z739ReembolsoPassosNome = "";
         A739ReembolsoPassosNome = "";
         BC002L4_A738ReembolsoPassos = new short[1] ;
         BC002L4_A739ReembolsoPassosNome = new string[] {""} ;
         BC002L4_n739ReembolsoPassosNome = new bool[] {false} ;
         BC002L4_A740ReembolsoPassosStatus = new bool[] {false} ;
         BC002L4_n740ReembolsoPassosStatus = new bool[] {false} ;
         BC002L4_A741ReembolsoPassosSLALembrete = new short[1] ;
         BC002L4_n741ReembolsoPassosSLALembrete = new bool[] {false} ;
         BC002L5_A738ReembolsoPassos = new short[1] ;
         BC002L3_A738ReembolsoPassos = new short[1] ;
         BC002L3_A739ReembolsoPassosNome = new string[] {""} ;
         BC002L3_n739ReembolsoPassosNome = new bool[] {false} ;
         BC002L3_A740ReembolsoPassosStatus = new bool[] {false} ;
         BC002L3_n740ReembolsoPassosStatus = new bool[] {false} ;
         BC002L3_A741ReembolsoPassosSLALembrete = new short[1] ;
         BC002L3_n741ReembolsoPassosSLALembrete = new bool[] {false} ;
         sMode90 = "";
         BC002L2_A738ReembolsoPassos = new short[1] ;
         BC002L2_A739ReembolsoPassosNome = new string[] {""} ;
         BC002L2_n739ReembolsoPassosNome = new bool[] {false} ;
         BC002L2_A740ReembolsoPassosStatus = new bool[] {false} ;
         BC002L2_n740ReembolsoPassosStatus = new bool[] {false} ;
         BC002L2_A741ReembolsoPassosSLALembrete = new short[1] ;
         BC002L2_n741ReembolsoPassosSLALembrete = new bool[] {false} ;
         BC002L9_A738ReembolsoPassos = new short[1] ;
         BC002L9_A739ReembolsoPassosNome = new string[] {""} ;
         BC002L9_n739ReembolsoPassosNome = new bool[] {false} ;
         BC002L9_A740ReembolsoPassosStatus = new bool[] {false} ;
         BC002L9_n740ReembolsoPassosStatus = new bool[] {false} ;
         BC002L9_A741ReembolsoPassosSLALembrete = new short[1] ;
         BC002L9_n741ReembolsoPassosSLALembrete = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reembolsopassos_bc__default(),
            new Object[][] {
                new Object[] {
               BC002L2_A738ReembolsoPassos, BC002L2_A739ReembolsoPassosNome, BC002L2_n739ReembolsoPassosNome, BC002L2_A740ReembolsoPassosStatus, BC002L2_n740ReembolsoPassosStatus, BC002L2_A741ReembolsoPassosSLALembrete, BC002L2_n741ReembolsoPassosSLALembrete
               }
               , new Object[] {
               BC002L3_A738ReembolsoPassos, BC002L3_A739ReembolsoPassosNome, BC002L3_n739ReembolsoPassosNome, BC002L3_A740ReembolsoPassosStatus, BC002L3_n740ReembolsoPassosStatus, BC002L3_A741ReembolsoPassosSLALembrete, BC002L3_n741ReembolsoPassosSLALembrete
               }
               , new Object[] {
               BC002L4_A738ReembolsoPassos, BC002L4_A739ReembolsoPassosNome, BC002L4_n739ReembolsoPassosNome, BC002L4_A740ReembolsoPassosStatus, BC002L4_n740ReembolsoPassosStatus, BC002L4_A741ReembolsoPassosSLALembrete, BC002L4_n741ReembolsoPassosSLALembrete
               }
               , new Object[] {
               BC002L5_A738ReembolsoPassos
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002L9_A738ReembolsoPassos, BC002L9_A739ReembolsoPassosNome, BC002L9_n739ReembolsoPassosNome, BC002L9_A740ReembolsoPassosStatus, BC002L9_n740ReembolsoPassosStatus, BC002L9_A741ReembolsoPassosSLALembrete, BC002L9_n741ReembolsoPassosSLALembrete
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z738ReembolsoPassos ;
      private short A738ReembolsoPassos ;
      private short Z741ReembolsoPassosSLALembrete ;
      private short A741ReembolsoPassosSLALembrete ;
      private short RcdFound90 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode90 ;
      private bool Z740ReembolsoPassosStatus ;
      private bool A740ReembolsoPassosStatus ;
      private bool n739ReembolsoPassosNome ;
      private bool n740ReembolsoPassosStatus ;
      private bool n741ReembolsoPassosSLALembrete ;
      private string Z739ReembolsoPassosNome ;
      private string A739ReembolsoPassosNome ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC002L4_A738ReembolsoPassos ;
      private string[] BC002L4_A739ReembolsoPassosNome ;
      private bool[] BC002L4_n739ReembolsoPassosNome ;
      private bool[] BC002L4_A740ReembolsoPassosStatus ;
      private bool[] BC002L4_n740ReembolsoPassosStatus ;
      private short[] BC002L4_A741ReembolsoPassosSLALembrete ;
      private bool[] BC002L4_n741ReembolsoPassosSLALembrete ;
      private short[] BC002L5_A738ReembolsoPassos ;
      private short[] BC002L3_A738ReembolsoPassos ;
      private string[] BC002L3_A739ReembolsoPassosNome ;
      private bool[] BC002L3_n739ReembolsoPassosNome ;
      private bool[] BC002L3_A740ReembolsoPassosStatus ;
      private bool[] BC002L3_n740ReembolsoPassosStatus ;
      private short[] BC002L3_A741ReembolsoPassosSLALembrete ;
      private bool[] BC002L3_n741ReembolsoPassosSLALembrete ;
      private short[] BC002L2_A738ReembolsoPassos ;
      private string[] BC002L2_A739ReembolsoPassosNome ;
      private bool[] BC002L2_n739ReembolsoPassosNome ;
      private bool[] BC002L2_A740ReembolsoPassosStatus ;
      private bool[] BC002L2_n740ReembolsoPassosStatus ;
      private short[] BC002L2_A741ReembolsoPassosSLALembrete ;
      private bool[] BC002L2_n741ReembolsoPassosSLALembrete ;
      private short[] BC002L9_A738ReembolsoPassos ;
      private string[] BC002L9_A739ReembolsoPassosNome ;
      private bool[] BC002L9_n739ReembolsoPassosNome ;
      private bool[] BC002L9_A740ReembolsoPassosStatus ;
      private bool[] BC002L9_n740ReembolsoPassosStatus ;
      private short[] BC002L9_A741ReembolsoPassosSLALembrete ;
      private bool[] BC002L9_n741ReembolsoPassosSLALembrete ;
      private SdtReembolsoPassos bcReembolsoPassos ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class reembolsopassos_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[5])
         ,new UpdateCursor(def[6])
         ,new ForEachCursor(def[7])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC002L2;
          prmBC002L2 = new Object[] {
          new ParDef("ReembolsoPassos",GXType.Int16,4,0)
          };
          Object[] prmBC002L3;
          prmBC002L3 = new Object[] {
          new ParDef("ReembolsoPassos",GXType.Int16,4,0)
          };
          Object[] prmBC002L4;
          prmBC002L4 = new Object[] {
          new ParDef("ReembolsoPassos",GXType.Int16,4,0)
          };
          Object[] prmBC002L5;
          prmBC002L5 = new Object[] {
          new ParDef("ReembolsoPassos",GXType.Int16,4,0)
          };
          Object[] prmBC002L6;
          prmBC002L6 = new Object[] {
          new ParDef("ReembolsoPassos",GXType.Int16,4,0) ,
          new ParDef("ReembolsoPassosNome",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("ReembolsoPassosStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ReembolsoPassosSLALembrete",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002L7;
          prmBC002L7 = new Object[] {
          new ParDef("ReembolsoPassosNome",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("ReembolsoPassosStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ReembolsoPassosSLALembrete",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ReembolsoPassos",GXType.Int16,4,0)
          };
          Object[] prmBC002L8;
          prmBC002L8 = new Object[] {
          new ParDef("ReembolsoPassos",GXType.Int16,4,0)
          };
          Object[] prmBC002L9;
          prmBC002L9 = new Object[] {
          new ParDef("ReembolsoPassos",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC002L2", "SELECT ReembolsoPassos, ReembolsoPassosNome, ReembolsoPassosStatus, ReembolsoPassosSLALembrete FROM ReembolsoPassos WHERE ReembolsoPassos = :ReembolsoPassos  FOR UPDATE OF ReembolsoPassos",true, GxErrorMask.GX_NOMASK, false, this,prmBC002L2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002L3", "SELECT ReembolsoPassos, ReembolsoPassosNome, ReembolsoPassosStatus, ReembolsoPassosSLALembrete FROM ReembolsoPassos WHERE ReembolsoPassos = :ReembolsoPassos ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002L3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002L4", "SELECT TM1.ReembolsoPassos, TM1.ReembolsoPassosNome, TM1.ReembolsoPassosStatus, TM1.ReembolsoPassosSLALembrete FROM ReembolsoPassos TM1 WHERE TM1.ReembolsoPassos = :ReembolsoPassos ORDER BY TM1.ReembolsoPassos ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002L4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002L5", "SELECT ReembolsoPassos FROM ReembolsoPassos WHERE ReembolsoPassos = :ReembolsoPassos ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002L5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002L6", "SAVEPOINT gxupdate;INSERT INTO ReembolsoPassos(ReembolsoPassos, ReembolsoPassosNome, ReembolsoPassosStatus, ReembolsoPassosSLALembrete) VALUES(:ReembolsoPassos, :ReembolsoPassosNome, :ReembolsoPassosStatus, :ReembolsoPassosSLALembrete);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC002L6)
             ,new CursorDef("BC002L7", "SAVEPOINT gxupdate;UPDATE ReembolsoPassos SET ReembolsoPassosNome=:ReembolsoPassosNome, ReembolsoPassosStatus=:ReembolsoPassosStatus, ReembolsoPassosSLALembrete=:ReembolsoPassosSLALembrete  WHERE ReembolsoPassos = :ReembolsoPassos;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002L7)
             ,new CursorDef("BC002L8", "SAVEPOINT gxupdate;DELETE FROM ReembolsoPassos  WHERE ReembolsoPassos = :ReembolsoPassos;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002L8)
             ,new CursorDef("BC002L9", "SELECT TM1.ReembolsoPassos, TM1.ReembolsoPassosNome, TM1.ReembolsoPassosStatus, TM1.ReembolsoPassosSLALembrete FROM ReembolsoPassos TM1 WHERE TM1.ReembolsoPassos = :ReembolsoPassos ORDER BY TM1.ReembolsoPassos ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002L9,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((short[]) buf[5])[0] = rslt.getShort(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((short[]) buf[5])[0] = rslt.getShort(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((short[]) buf[5])[0] = rslt.getShort(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((short[]) buf[5])[0] = rslt.getShort(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
