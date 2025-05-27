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
   public class reembolsoetapa_bc : GxSilentTrn, IGxSilentTrn
   {
      public reembolsoetapa_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public reembolsoetapa_bc( IGxContext context )
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
         ReadRow1Z72( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1Z72( ) ;
         standaloneModal( ) ;
         AddRow1Z72( ) ;
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
               Z526ReembolsoEtapaId = A526ReembolsoEtapaId;
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

      protected void CONFIRM_1Z0( )
      {
         BeforeValidate1Z72( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1Z72( ) ;
            }
            else
            {
               CheckExtendedTable1Z72( ) ;
               if ( AnyError == 0 )
               {
                  ZM1Z72( 4) ;
               }
               CloseExtendedTableCursors1Z72( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM1Z72( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z534ReembolsoEtapaCreatedAt = A534ReembolsoEtapaCreatedAt;
            Z545ReembolsoEtapaStatus = A545ReembolsoEtapaStatus;
            Z518ReembolsoId = A518ReembolsoId;
         }
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -3 )
         {
            Z526ReembolsoEtapaId = A526ReembolsoEtapaId;
            Z534ReembolsoEtapaCreatedAt = A534ReembolsoEtapaCreatedAt;
            Z545ReembolsoEtapaStatus = A545ReembolsoEtapaStatus;
            Z518ReembolsoId = A518ReembolsoId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A534ReembolsoEtapaCreatedAt) && ( Gx_BScreen == 0 ) )
         {
            A534ReembolsoEtapaCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n534ReembolsoEtapaCreatedAt = false;
         }
      }

      protected void Load1Z72( )
      {
         /* Using cursor BC001Z5 */
         pr_default.execute(3, new Object[] {n526ReembolsoEtapaId, A526ReembolsoEtapaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound72 = 1;
            A534ReembolsoEtapaCreatedAt = BC001Z5_A534ReembolsoEtapaCreatedAt[0];
            n534ReembolsoEtapaCreatedAt = BC001Z5_n534ReembolsoEtapaCreatedAt[0];
            A545ReembolsoEtapaStatus = BC001Z5_A545ReembolsoEtapaStatus[0];
            n545ReembolsoEtapaStatus = BC001Z5_n545ReembolsoEtapaStatus[0];
            A518ReembolsoId = BC001Z5_A518ReembolsoId[0];
            n518ReembolsoId = BC001Z5_n518ReembolsoId[0];
            ZM1Z72( -3) ;
         }
         pr_default.close(3);
         OnLoadActions1Z72( ) ;
      }

      protected void OnLoadActions1Z72( )
      {
      }

      protected void CheckExtendedTable1Z72( )
      {
         standaloneModal( ) ;
         /* Using cursor BC001Z4 */
         pr_default.execute(2, new Object[] {n518ReembolsoId, A518ReembolsoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A518ReembolsoId) ) )
            {
               GX_msglist.addItem("Não existe 'Reembolso'.", "ForeignKeyNotFound", 1, "REEMBOLSOID");
               AnyError = 1;
            }
         }
         pr_default.close(2);
         if ( ! ( ( StringUtil.StrCmp(A545ReembolsoEtapaStatus, "EM_ANALISE") == 0 ) || ( StringUtil.StrCmp(A545ReembolsoEtapaStatus, "FINALIZADO") == 0 ) || ( StringUtil.StrCmp(A545ReembolsoEtapaStatus, "REANALISE") == 0 ) || ( StringUtil.StrCmp(A545ReembolsoEtapaStatus, "") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A545ReembolsoEtapaStatus)) ) )
         {
            GX_msglist.addItem("Campo Reembolso Etapa Status fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1Z72( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1Z72( )
      {
         /* Using cursor BC001Z6 */
         pr_default.execute(4, new Object[] {n526ReembolsoEtapaId, A526ReembolsoEtapaId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound72 = 1;
         }
         else
         {
            RcdFound72 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001Z3 */
         pr_default.execute(1, new Object[] {n526ReembolsoEtapaId, A526ReembolsoEtapaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1Z72( 3) ;
            RcdFound72 = 1;
            A526ReembolsoEtapaId = BC001Z3_A526ReembolsoEtapaId[0];
            n526ReembolsoEtapaId = BC001Z3_n526ReembolsoEtapaId[0];
            A534ReembolsoEtapaCreatedAt = BC001Z3_A534ReembolsoEtapaCreatedAt[0];
            n534ReembolsoEtapaCreatedAt = BC001Z3_n534ReembolsoEtapaCreatedAt[0];
            A545ReembolsoEtapaStatus = BC001Z3_A545ReembolsoEtapaStatus[0];
            n545ReembolsoEtapaStatus = BC001Z3_n545ReembolsoEtapaStatus[0];
            A518ReembolsoId = BC001Z3_A518ReembolsoId[0];
            n518ReembolsoId = BC001Z3_n518ReembolsoId[0];
            Z526ReembolsoEtapaId = A526ReembolsoEtapaId;
            sMode72 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1Z72( ) ;
            if ( AnyError == 1 )
            {
               RcdFound72 = 0;
               InitializeNonKey1Z72( ) ;
            }
            Gx_mode = sMode72;
         }
         else
         {
            RcdFound72 = 0;
            InitializeNonKey1Z72( ) ;
            sMode72 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode72;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1Z72( ) ;
         if ( RcdFound72 == 0 )
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
         CONFIRM_1Z0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1Z72( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001Z2 */
            pr_default.execute(0, new Object[] {n526ReembolsoEtapaId, A526ReembolsoEtapaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ReembolsoEtapa"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z534ReembolsoEtapaCreatedAt != BC001Z2_A534ReembolsoEtapaCreatedAt[0] ) || ( StringUtil.StrCmp(Z545ReembolsoEtapaStatus, BC001Z2_A545ReembolsoEtapaStatus[0]) != 0 ) || ( Z518ReembolsoId != BC001Z2_A518ReembolsoId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ReembolsoEtapa"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1Z72( )
      {
         BeforeValidate1Z72( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Z72( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1Z72( 0) ;
            CheckOptimisticConcurrency1Z72( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Z72( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1Z72( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001Z7 */
                     pr_default.execute(5, new Object[] {n534ReembolsoEtapaCreatedAt, A534ReembolsoEtapaCreatedAt, n545ReembolsoEtapaStatus, A545ReembolsoEtapaStatus, n518ReembolsoId, A518ReembolsoId});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC001Z8 */
                     pr_default.execute(6);
                     A526ReembolsoEtapaId = BC001Z8_A526ReembolsoEtapaId[0];
                     n526ReembolsoEtapaId = BC001Z8_n526ReembolsoEtapaId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("ReembolsoEtapa");
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
               Load1Z72( ) ;
            }
            EndLevel1Z72( ) ;
         }
         CloseExtendedTableCursors1Z72( ) ;
      }

      protected void Update1Z72( )
      {
         BeforeValidate1Z72( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Z72( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Z72( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Z72( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1Z72( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001Z9 */
                     pr_default.execute(7, new Object[] {n534ReembolsoEtapaCreatedAt, A534ReembolsoEtapaCreatedAt, n545ReembolsoEtapaStatus, A545ReembolsoEtapaStatus, n518ReembolsoId, A518ReembolsoId, n526ReembolsoEtapaId, A526ReembolsoEtapaId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("ReembolsoEtapa");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ReembolsoEtapa"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1Z72( ) ;
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
            EndLevel1Z72( ) ;
         }
         CloseExtendedTableCursors1Z72( ) ;
      }

      protected void DeferredUpdate1Z72( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1Z72( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Z72( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1Z72( ) ;
            AfterConfirm1Z72( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1Z72( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001Z10 */
                  pr_default.execute(8, new Object[] {n526ReembolsoEtapaId, A526ReembolsoEtapaId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("ReembolsoEtapa");
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
         sMode72 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1Z72( ) ;
         Gx_mode = sMode72;
      }

      protected void OnDeleteControls1Z72( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC001Z11 */
            pr_default.execute(9, new Object[] {n526ReembolsoEtapaId, A526ReembolsoEtapaId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ReembolsoDocumento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel1Z72( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1Z72( ) ;
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

      public void ScanKeyStart1Z72( )
      {
         /* Using cursor BC001Z12 */
         pr_default.execute(10, new Object[] {n526ReembolsoEtapaId, A526ReembolsoEtapaId});
         RcdFound72 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound72 = 1;
            A526ReembolsoEtapaId = BC001Z12_A526ReembolsoEtapaId[0];
            n526ReembolsoEtapaId = BC001Z12_n526ReembolsoEtapaId[0];
            A534ReembolsoEtapaCreatedAt = BC001Z12_A534ReembolsoEtapaCreatedAt[0];
            n534ReembolsoEtapaCreatedAt = BC001Z12_n534ReembolsoEtapaCreatedAt[0];
            A545ReembolsoEtapaStatus = BC001Z12_A545ReembolsoEtapaStatus[0];
            n545ReembolsoEtapaStatus = BC001Z12_n545ReembolsoEtapaStatus[0];
            A518ReembolsoId = BC001Z12_A518ReembolsoId[0];
            n518ReembolsoId = BC001Z12_n518ReembolsoId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1Z72( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound72 = 0;
         ScanKeyLoad1Z72( ) ;
      }

      protected void ScanKeyLoad1Z72( )
      {
         sMode72 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound72 = 1;
            A526ReembolsoEtapaId = BC001Z12_A526ReembolsoEtapaId[0];
            n526ReembolsoEtapaId = BC001Z12_n526ReembolsoEtapaId[0];
            A534ReembolsoEtapaCreatedAt = BC001Z12_A534ReembolsoEtapaCreatedAt[0];
            n534ReembolsoEtapaCreatedAt = BC001Z12_n534ReembolsoEtapaCreatedAt[0];
            A545ReembolsoEtapaStatus = BC001Z12_A545ReembolsoEtapaStatus[0];
            n545ReembolsoEtapaStatus = BC001Z12_n545ReembolsoEtapaStatus[0];
            A518ReembolsoId = BC001Z12_A518ReembolsoId[0];
            n518ReembolsoId = BC001Z12_n518ReembolsoId[0];
         }
         Gx_mode = sMode72;
      }

      protected void ScanKeyEnd1Z72( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm1Z72( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1Z72( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1Z72( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1Z72( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1Z72( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1Z72( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1Z72( )
      {
      }

      protected void send_integrity_lvl_hashes1Z72( )
      {
      }

      protected void AddRow1Z72( )
      {
         VarsToRow72( bcReembolsoEtapa) ;
      }

      protected void ReadRow1Z72( )
      {
         RowToVars72( bcReembolsoEtapa, 1) ;
      }

      protected void InitializeNonKey1Z72( )
      {
         A518ReembolsoId = 0;
         n518ReembolsoId = false;
         A545ReembolsoEtapaStatus = "";
         n545ReembolsoEtapaStatus = false;
         A534ReembolsoEtapaCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n534ReembolsoEtapaCreatedAt = false;
         Z534ReembolsoEtapaCreatedAt = (DateTime)(DateTime.MinValue);
         Z545ReembolsoEtapaStatus = "";
         Z518ReembolsoId = 0;
      }

      protected void InitAll1Z72( )
      {
         A526ReembolsoEtapaId = 0;
         n526ReembolsoEtapaId = false;
         InitializeNonKey1Z72( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A534ReembolsoEtapaCreatedAt = i534ReembolsoEtapaCreatedAt;
         n534ReembolsoEtapaCreatedAt = false;
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

      public void VarsToRow72( SdtReembolsoEtapa obj72 )
      {
         obj72.gxTpr_Mode = Gx_mode;
         obj72.gxTpr_Reembolsoid = A518ReembolsoId;
         obj72.gxTpr_Reembolsoetapastatus = A545ReembolsoEtapaStatus;
         obj72.gxTpr_Reembolsoetapacreatedat = A534ReembolsoEtapaCreatedAt;
         obj72.gxTpr_Reembolsoetapaid = A526ReembolsoEtapaId;
         obj72.gxTpr_Reembolsoetapaid_Z = Z526ReembolsoEtapaId;
         obj72.gxTpr_Reembolsoid_Z = Z518ReembolsoId;
         obj72.gxTpr_Reembolsoetapacreatedat_Z = Z534ReembolsoEtapaCreatedAt;
         obj72.gxTpr_Reembolsoetapastatus_Z = Z545ReembolsoEtapaStatus;
         obj72.gxTpr_Reembolsoetapaid_N = (short)(Convert.ToInt16(n526ReembolsoEtapaId));
         obj72.gxTpr_Reembolsoid_N = (short)(Convert.ToInt16(n518ReembolsoId));
         obj72.gxTpr_Reembolsoetapacreatedat_N = (short)(Convert.ToInt16(n534ReembolsoEtapaCreatedAt));
         obj72.gxTpr_Reembolsoetapastatus_N = (short)(Convert.ToInt16(n545ReembolsoEtapaStatus));
         obj72.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow72( SdtReembolsoEtapa obj72 )
      {
         obj72.gxTpr_Reembolsoetapaid = A526ReembolsoEtapaId;
         return  ;
      }

      public void RowToVars72( SdtReembolsoEtapa obj72 ,
                               int forceLoad )
      {
         Gx_mode = obj72.gxTpr_Mode;
         A518ReembolsoId = obj72.gxTpr_Reembolsoid;
         n518ReembolsoId = false;
         A545ReembolsoEtapaStatus = obj72.gxTpr_Reembolsoetapastatus;
         n545ReembolsoEtapaStatus = false;
         A534ReembolsoEtapaCreatedAt = obj72.gxTpr_Reembolsoetapacreatedat;
         n534ReembolsoEtapaCreatedAt = false;
         A526ReembolsoEtapaId = obj72.gxTpr_Reembolsoetapaid;
         n526ReembolsoEtapaId = false;
         Z526ReembolsoEtapaId = obj72.gxTpr_Reembolsoetapaid_Z;
         Z518ReembolsoId = obj72.gxTpr_Reembolsoid_Z;
         Z534ReembolsoEtapaCreatedAt = obj72.gxTpr_Reembolsoetapacreatedat_Z;
         Z545ReembolsoEtapaStatus = obj72.gxTpr_Reembolsoetapastatus_Z;
         n526ReembolsoEtapaId = (bool)(Convert.ToBoolean(obj72.gxTpr_Reembolsoetapaid_N));
         n518ReembolsoId = (bool)(Convert.ToBoolean(obj72.gxTpr_Reembolsoid_N));
         n534ReembolsoEtapaCreatedAt = (bool)(Convert.ToBoolean(obj72.gxTpr_Reembolsoetapacreatedat_N));
         n545ReembolsoEtapaStatus = (bool)(Convert.ToBoolean(obj72.gxTpr_Reembolsoetapastatus_N));
         Gx_mode = obj72.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A526ReembolsoEtapaId = (int)getParm(obj,0);
         n526ReembolsoEtapaId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1Z72( ) ;
         ScanKeyStart1Z72( ) ;
         if ( RcdFound72 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z526ReembolsoEtapaId = A526ReembolsoEtapaId;
         }
         ZM1Z72( -3) ;
         OnLoadActions1Z72( ) ;
         AddRow1Z72( ) ;
         ScanKeyEnd1Z72( ) ;
         if ( RcdFound72 == 0 )
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
         RowToVars72( bcReembolsoEtapa, 0) ;
         ScanKeyStart1Z72( ) ;
         if ( RcdFound72 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z526ReembolsoEtapaId = A526ReembolsoEtapaId;
         }
         ZM1Z72( -3) ;
         OnLoadActions1Z72( ) ;
         AddRow1Z72( ) ;
         ScanKeyEnd1Z72( ) ;
         if ( RcdFound72 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1Z72( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1Z72( ) ;
         }
         else
         {
            if ( RcdFound72 == 1 )
            {
               if ( A526ReembolsoEtapaId != Z526ReembolsoEtapaId )
               {
                  A526ReembolsoEtapaId = Z526ReembolsoEtapaId;
                  n526ReembolsoEtapaId = false;
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
                  Update1Z72( ) ;
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
                  if ( A526ReembolsoEtapaId != Z526ReembolsoEtapaId )
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
                        Insert1Z72( ) ;
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
                        Insert1Z72( ) ;
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
         RowToVars72( bcReembolsoEtapa, 1) ;
         SaveImpl( ) ;
         VarsToRow72( bcReembolsoEtapa) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars72( bcReembolsoEtapa, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1Z72( ) ;
         AfterTrn( ) ;
         VarsToRow72( bcReembolsoEtapa) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow72( bcReembolsoEtapa) ;
         }
         else
         {
            SdtReembolsoEtapa auxBC = new SdtReembolsoEtapa(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A526ReembolsoEtapaId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcReembolsoEtapa);
               auxBC.Save();
               bcReembolsoEtapa.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars72( bcReembolsoEtapa, 1) ;
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
         RowToVars72( bcReembolsoEtapa, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1Z72( ) ;
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
               VarsToRow72( bcReembolsoEtapa) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow72( bcReembolsoEtapa) ;
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
         RowToVars72( bcReembolsoEtapa, 0) ;
         GetKey1Z72( ) ;
         if ( RcdFound72 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A526ReembolsoEtapaId != Z526ReembolsoEtapaId )
            {
               A526ReembolsoEtapaId = Z526ReembolsoEtapaId;
               n526ReembolsoEtapaId = false;
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
            if ( A526ReembolsoEtapaId != Z526ReembolsoEtapaId )
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
         context.RollbackDataStores("reembolsoetapa_bc",pr_default);
         VarsToRow72( bcReembolsoEtapa) ;
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
         Gx_mode = bcReembolsoEtapa.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcReembolsoEtapa.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcReembolsoEtapa )
         {
            bcReembolsoEtapa = (SdtReembolsoEtapa)(sdt);
            if ( StringUtil.StrCmp(bcReembolsoEtapa.gxTpr_Mode, "") == 0 )
            {
               bcReembolsoEtapa.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow72( bcReembolsoEtapa) ;
            }
            else
            {
               RowToVars72( bcReembolsoEtapa, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcReembolsoEtapa.gxTpr_Mode, "") == 0 )
            {
               bcReembolsoEtapa.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars72( bcReembolsoEtapa, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtReembolsoEtapa ReembolsoEtapa_BC
      {
         get {
            return bcReembolsoEtapa ;
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
         Z534ReembolsoEtapaCreatedAt = (DateTime)(DateTime.MinValue);
         A534ReembolsoEtapaCreatedAt = (DateTime)(DateTime.MinValue);
         Z545ReembolsoEtapaStatus = "";
         A545ReembolsoEtapaStatus = "";
         BC001Z5_A526ReembolsoEtapaId = new int[1] ;
         BC001Z5_n526ReembolsoEtapaId = new bool[] {false} ;
         BC001Z5_A534ReembolsoEtapaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC001Z5_n534ReembolsoEtapaCreatedAt = new bool[] {false} ;
         BC001Z5_A545ReembolsoEtapaStatus = new string[] {""} ;
         BC001Z5_n545ReembolsoEtapaStatus = new bool[] {false} ;
         BC001Z5_A518ReembolsoId = new int[1] ;
         BC001Z5_n518ReembolsoId = new bool[] {false} ;
         BC001Z4_A518ReembolsoId = new int[1] ;
         BC001Z4_n518ReembolsoId = new bool[] {false} ;
         BC001Z6_A526ReembolsoEtapaId = new int[1] ;
         BC001Z6_n526ReembolsoEtapaId = new bool[] {false} ;
         BC001Z3_A526ReembolsoEtapaId = new int[1] ;
         BC001Z3_n526ReembolsoEtapaId = new bool[] {false} ;
         BC001Z3_A534ReembolsoEtapaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC001Z3_n534ReembolsoEtapaCreatedAt = new bool[] {false} ;
         BC001Z3_A545ReembolsoEtapaStatus = new string[] {""} ;
         BC001Z3_n545ReembolsoEtapaStatus = new bool[] {false} ;
         BC001Z3_A518ReembolsoId = new int[1] ;
         BC001Z3_n518ReembolsoId = new bool[] {false} ;
         sMode72 = "";
         BC001Z2_A526ReembolsoEtapaId = new int[1] ;
         BC001Z2_n526ReembolsoEtapaId = new bool[] {false} ;
         BC001Z2_A534ReembolsoEtapaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC001Z2_n534ReembolsoEtapaCreatedAt = new bool[] {false} ;
         BC001Z2_A545ReembolsoEtapaStatus = new string[] {""} ;
         BC001Z2_n545ReembolsoEtapaStatus = new bool[] {false} ;
         BC001Z2_A518ReembolsoId = new int[1] ;
         BC001Z2_n518ReembolsoId = new bool[] {false} ;
         BC001Z8_A526ReembolsoEtapaId = new int[1] ;
         BC001Z8_n526ReembolsoEtapaId = new bool[] {false} ;
         BC001Z11_A529ReembolsoDocumentoId = new int[1] ;
         BC001Z12_A526ReembolsoEtapaId = new int[1] ;
         BC001Z12_n526ReembolsoEtapaId = new bool[] {false} ;
         BC001Z12_A534ReembolsoEtapaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC001Z12_n534ReembolsoEtapaCreatedAt = new bool[] {false} ;
         BC001Z12_A545ReembolsoEtapaStatus = new string[] {""} ;
         BC001Z12_n545ReembolsoEtapaStatus = new bool[] {false} ;
         BC001Z12_A518ReembolsoId = new int[1] ;
         BC001Z12_n518ReembolsoId = new bool[] {false} ;
         i534ReembolsoEtapaCreatedAt = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reembolsoetapa_bc__default(),
            new Object[][] {
                new Object[] {
               BC001Z2_A526ReembolsoEtapaId, BC001Z2_A534ReembolsoEtapaCreatedAt, BC001Z2_n534ReembolsoEtapaCreatedAt, BC001Z2_A545ReembolsoEtapaStatus, BC001Z2_n545ReembolsoEtapaStatus, BC001Z2_A518ReembolsoId, BC001Z2_n518ReembolsoId
               }
               , new Object[] {
               BC001Z3_A526ReembolsoEtapaId, BC001Z3_A534ReembolsoEtapaCreatedAt, BC001Z3_n534ReembolsoEtapaCreatedAt, BC001Z3_A545ReembolsoEtapaStatus, BC001Z3_n545ReembolsoEtapaStatus, BC001Z3_A518ReembolsoId, BC001Z3_n518ReembolsoId
               }
               , new Object[] {
               BC001Z4_A518ReembolsoId
               }
               , new Object[] {
               BC001Z5_A526ReembolsoEtapaId, BC001Z5_A534ReembolsoEtapaCreatedAt, BC001Z5_n534ReembolsoEtapaCreatedAt, BC001Z5_A545ReembolsoEtapaStatus, BC001Z5_n545ReembolsoEtapaStatus, BC001Z5_A518ReembolsoId, BC001Z5_n518ReembolsoId
               }
               , new Object[] {
               BC001Z6_A526ReembolsoEtapaId
               }
               , new Object[] {
               }
               , new Object[] {
               BC001Z8_A526ReembolsoEtapaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001Z11_A529ReembolsoDocumentoId
               }
               , new Object[] {
               BC001Z12_A526ReembolsoEtapaId, BC001Z12_A534ReembolsoEtapaCreatedAt, BC001Z12_n534ReembolsoEtapaCreatedAt, BC001Z12_A545ReembolsoEtapaStatus, BC001Z12_n545ReembolsoEtapaStatus, BC001Z12_A518ReembolsoId, BC001Z12_n518ReembolsoId
               }
            }
         );
         Z534ReembolsoEtapaCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n534ReembolsoEtapaCreatedAt = false;
         A534ReembolsoEtapaCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n534ReembolsoEtapaCreatedAt = false;
         i534ReembolsoEtapaCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n534ReembolsoEtapaCreatedAt = false;
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound72 ;
      private int trnEnded ;
      private int Z526ReembolsoEtapaId ;
      private int A526ReembolsoEtapaId ;
      private int Z518ReembolsoId ;
      private int A518ReembolsoId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode72 ;
      private DateTime Z534ReembolsoEtapaCreatedAt ;
      private DateTime A534ReembolsoEtapaCreatedAt ;
      private DateTime i534ReembolsoEtapaCreatedAt ;
      private bool n534ReembolsoEtapaCreatedAt ;
      private bool n526ReembolsoEtapaId ;
      private bool n545ReembolsoEtapaStatus ;
      private bool n518ReembolsoId ;
      private string Z545ReembolsoEtapaStatus ;
      private string A545ReembolsoEtapaStatus ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC001Z5_A526ReembolsoEtapaId ;
      private bool[] BC001Z5_n526ReembolsoEtapaId ;
      private DateTime[] BC001Z5_A534ReembolsoEtapaCreatedAt ;
      private bool[] BC001Z5_n534ReembolsoEtapaCreatedAt ;
      private string[] BC001Z5_A545ReembolsoEtapaStatus ;
      private bool[] BC001Z5_n545ReembolsoEtapaStatus ;
      private int[] BC001Z5_A518ReembolsoId ;
      private bool[] BC001Z5_n518ReembolsoId ;
      private int[] BC001Z4_A518ReembolsoId ;
      private bool[] BC001Z4_n518ReembolsoId ;
      private int[] BC001Z6_A526ReembolsoEtapaId ;
      private bool[] BC001Z6_n526ReembolsoEtapaId ;
      private int[] BC001Z3_A526ReembolsoEtapaId ;
      private bool[] BC001Z3_n526ReembolsoEtapaId ;
      private DateTime[] BC001Z3_A534ReembolsoEtapaCreatedAt ;
      private bool[] BC001Z3_n534ReembolsoEtapaCreatedAt ;
      private string[] BC001Z3_A545ReembolsoEtapaStatus ;
      private bool[] BC001Z3_n545ReembolsoEtapaStatus ;
      private int[] BC001Z3_A518ReembolsoId ;
      private bool[] BC001Z3_n518ReembolsoId ;
      private int[] BC001Z2_A526ReembolsoEtapaId ;
      private bool[] BC001Z2_n526ReembolsoEtapaId ;
      private DateTime[] BC001Z2_A534ReembolsoEtapaCreatedAt ;
      private bool[] BC001Z2_n534ReembolsoEtapaCreatedAt ;
      private string[] BC001Z2_A545ReembolsoEtapaStatus ;
      private bool[] BC001Z2_n545ReembolsoEtapaStatus ;
      private int[] BC001Z2_A518ReembolsoId ;
      private bool[] BC001Z2_n518ReembolsoId ;
      private int[] BC001Z8_A526ReembolsoEtapaId ;
      private bool[] BC001Z8_n526ReembolsoEtapaId ;
      private int[] BC001Z11_A529ReembolsoDocumentoId ;
      private int[] BC001Z12_A526ReembolsoEtapaId ;
      private bool[] BC001Z12_n526ReembolsoEtapaId ;
      private DateTime[] BC001Z12_A534ReembolsoEtapaCreatedAt ;
      private bool[] BC001Z12_n534ReembolsoEtapaCreatedAt ;
      private string[] BC001Z12_A545ReembolsoEtapaStatus ;
      private bool[] BC001Z12_n545ReembolsoEtapaStatus ;
      private int[] BC001Z12_A518ReembolsoId ;
      private bool[] BC001Z12_n518ReembolsoId ;
      private SdtReembolsoEtapa bcReembolsoEtapa ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class reembolsoetapa_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC001Z2;
          prmBC001Z2 = new Object[] {
          new ParDef("ReembolsoEtapaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Z3;
          prmBC001Z3 = new Object[] {
          new ParDef("ReembolsoEtapaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Z4;
          prmBC001Z4 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Z5;
          prmBC001Z5 = new Object[] {
          new ParDef("ReembolsoEtapaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Z6;
          prmBC001Z6 = new Object[] {
          new ParDef("ReembolsoEtapaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Z7;
          prmBC001Z7 = new Object[] {
          new ParDef("ReembolsoEtapaCreatedAt",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("ReembolsoEtapaStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Z8;
          prmBC001Z8 = new Object[] {
          };
          Object[] prmBC001Z9;
          prmBC001Z9 = new Object[] {
          new ParDef("ReembolsoEtapaCreatedAt",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("ReembolsoEtapaStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ReembolsoEtapaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Z10;
          prmBC001Z10 = new Object[] {
          new ParDef("ReembolsoEtapaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Z11;
          prmBC001Z11 = new Object[] {
          new ParDef("ReembolsoEtapaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Z12;
          prmBC001Z12 = new Object[] {
          new ParDef("ReembolsoEtapaId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC001Z2", "SELECT ReembolsoEtapaId, ReembolsoEtapaCreatedAt, ReembolsoEtapaStatus, ReembolsoId FROM ReembolsoEtapa WHERE ReembolsoEtapaId = :ReembolsoEtapaId  FOR UPDATE OF ReembolsoEtapa",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Z2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001Z3", "SELECT ReembolsoEtapaId, ReembolsoEtapaCreatedAt, ReembolsoEtapaStatus, ReembolsoId FROM ReembolsoEtapa WHERE ReembolsoEtapaId = :ReembolsoEtapaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Z3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001Z4", "SELECT ReembolsoId FROM Reembolso WHERE ReembolsoId = :ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Z4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001Z5", "SELECT TM1.ReembolsoEtapaId, TM1.ReembolsoEtapaCreatedAt, TM1.ReembolsoEtapaStatus, TM1.ReembolsoId FROM ReembolsoEtapa TM1 WHERE TM1.ReembolsoEtapaId = :ReembolsoEtapaId ORDER BY TM1.ReembolsoEtapaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Z5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001Z6", "SELECT ReembolsoEtapaId FROM ReembolsoEtapa WHERE ReembolsoEtapaId = :ReembolsoEtapaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Z6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001Z7", "SAVEPOINT gxupdate;INSERT INTO ReembolsoEtapa(ReembolsoEtapaCreatedAt, ReembolsoEtapaStatus, ReembolsoId) VALUES(:ReembolsoEtapaCreatedAt, :ReembolsoEtapaStatus, :ReembolsoId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001Z7)
             ,new CursorDef("BC001Z8", "SELECT currval('ReembolsoEtapaId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Z8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001Z9", "SAVEPOINT gxupdate;UPDATE ReembolsoEtapa SET ReembolsoEtapaCreatedAt=:ReembolsoEtapaCreatedAt, ReembolsoEtapaStatus=:ReembolsoEtapaStatus, ReembolsoId=:ReembolsoId  WHERE ReembolsoEtapaId = :ReembolsoEtapaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001Z9)
             ,new CursorDef("BC001Z10", "SAVEPOINT gxupdate;DELETE FROM ReembolsoEtapa  WHERE ReembolsoEtapaId = :ReembolsoEtapaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001Z10)
             ,new CursorDef("BC001Z11", "SELECT ReembolsoDocumentoId FROM ReembolsoDocumento WHERE ReembolsoEtapaId = :ReembolsoEtapaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Z11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001Z12", "SELECT TM1.ReembolsoEtapaId, TM1.ReembolsoEtapaCreatedAt, TM1.ReembolsoEtapaStatus, TM1.ReembolsoId FROM ReembolsoEtapa TM1 WHERE TM1.ReembolsoEtapaId = :ReembolsoEtapaId ORDER BY TM1.ReembolsoEtapaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Z12,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
