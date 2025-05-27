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
   public class procedimentosmedicos_bc : GxSilentTrn, IGxSilentTrn
   {
      public procedimentosmedicos_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public procedimentosmedicos_bc( IGxContext context )
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
         ReadRow1F54( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1F54( ) ;
         standaloneModal( ) ;
         AddRow1F54( ) ;
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
               Z376ProcedimentosMedicosId = A376ProcedimentosMedicosId;
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

      protected void CONFIRM_1F0( )
      {
         BeforeValidate1F54( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1F54( ) ;
            }
            else
            {
               CheckExtendedTable1F54( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1F54( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM1F54( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z377ProcedimentosMedicosNome = A377ProcedimentosMedicosNome;
            Z379ProcedimentosMedicosArea = A379ProcedimentosMedicosArea;
            Z408CID = A408CID;
            Z409ProcedimentosMedicosAtivo = A409ProcedimentosMedicosAtivo;
         }
         if ( GX_JID == -1 )
         {
            Z376ProcedimentosMedicosId = A376ProcedimentosMedicosId;
            Z377ProcedimentosMedicosNome = A377ProcedimentosMedicosNome;
            Z378ProcedimentosMedicosDescricao = A378ProcedimentosMedicosDescricao;
            Z379ProcedimentosMedicosArea = A379ProcedimentosMedicosArea;
            Z408CID = A408CID;
            Z409ProcedimentosMedicosAtivo = A409ProcedimentosMedicosAtivo;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load1F54( )
      {
         /* Using cursor BC001F4 */
         pr_default.execute(2, new Object[] {n376ProcedimentosMedicosId, A376ProcedimentosMedicosId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound54 = 1;
            A377ProcedimentosMedicosNome = BC001F4_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = BC001F4_n377ProcedimentosMedicosNome[0];
            A378ProcedimentosMedicosDescricao = BC001F4_A378ProcedimentosMedicosDescricao[0];
            n378ProcedimentosMedicosDescricao = BC001F4_n378ProcedimentosMedicosDescricao[0];
            A379ProcedimentosMedicosArea = BC001F4_A379ProcedimentosMedicosArea[0];
            n379ProcedimentosMedicosArea = BC001F4_n379ProcedimentosMedicosArea[0];
            A408CID = BC001F4_A408CID[0];
            n408CID = BC001F4_n408CID[0];
            A409ProcedimentosMedicosAtivo = BC001F4_A409ProcedimentosMedicosAtivo[0];
            ZM1F54( -1) ;
         }
         pr_default.close(2);
         OnLoadActions1F54( ) ;
      }

      protected void OnLoadActions1F54( )
      {
      }

      protected void CheckExtendedTable1F54( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1F54( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1F54( )
      {
         /* Using cursor BC001F5 */
         pr_default.execute(3, new Object[] {n376ProcedimentosMedicosId, A376ProcedimentosMedicosId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound54 = 1;
         }
         else
         {
            RcdFound54 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001F3 */
         pr_default.execute(1, new Object[] {n376ProcedimentosMedicosId, A376ProcedimentosMedicosId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1F54( 1) ;
            RcdFound54 = 1;
            A376ProcedimentosMedicosId = BC001F3_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = BC001F3_n376ProcedimentosMedicosId[0];
            A377ProcedimentosMedicosNome = BC001F3_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = BC001F3_n377ProcedimentosMedicosNome[0];
            A378ProcedimentosMedicosDescricao = BC001F3_A378ProcedimentosMedicosDescricao[0];
            n378ProcedimentosMedicosDescricao = BC001F3_n378ProcedimentosMedicosDescricao[0];
            A379ProcedimentosMedicosArea = BC001F3_A379ProcedimentosMedicosArea[0];
            n379ProcedimentosMedicosArea = BC001F3_n379ProcedimentosMedicosArea[0];
            A408CID = BC001F3_A408CID[0];
            n408CID = BC001F3_n408CID[0];
            A409ProcedimentosMedicosAtivo = BC001F3_A409ProcedimentosMedicosAtivo[0];
            Z376ProcedimentosMedicosId = A376ProcedimentosMedicosId;
            sMode54 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1F54( ) ;
            if ( AnyError == 1 )
            {
               RcdFound54 = 0;
               InitializeNonKey1F54( ) ;
            }
            Gx_mode = sMode54;
         }
         else
         {
            RcdFound54 = 0;
            InitializeNonKey1F54( ) ;
            sMode54 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode54;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1F54( ) ;
         if ( RcdFound54 == 0 )
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
         CONFIRM_1F0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1F54( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001F2 */
            pr_default.execute(0, new Object[] {n376ProcedimentosMedicosId, A376ProcedimentosMedicosId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProcedimentosMedicos"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z377ProcedimentosMedicosNome, BC001F2_A377ProcedimentosMedicosNome[0]) != 0 ) || ( StringUtil.StrCmp(Z379ProcedimentosMedicosArea, BC001F2_A379ProcedimentosMedicosArea[0]) != 0 ) || ( Z408CID != BC001F2_A408CID[0] ) || ( Z409ProcedimentosMedicosAtivo != BC001F2_A409ProcedimentosMedicosAtivo[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ProcedimentosMedicos"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1F54( )
      {
         BeforeValidate1F54( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1F54( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1F54( 0) ;
            CheckOptimisticConcurrency1F54( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1F54( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1F54( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001F6 */
                     pr_default.execute(4, new Object[] {n377ProcedimentosMedicosNome, A377ProcedimentosMedicosNome, n378ProcedimentosMedicosDescricao, A378ProcedimentosMedicosDescricao, n379ProcedimentosMedicosArea, A379ProcedimentosMedicosArea, n408CID, A408CID, A409ProcedimentosMedicosAtivo});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC001F7 */
                     pr_default.execute(5);
                     A376ProcedimentosMedicosId = BC001F7_A376ProcedimentosMedicosId[0];
                     n376ProcedimentosMedicosId = BC001F7_n376ProcedimentosMedicosId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("ProcedimentosMedicos");
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
               Load1F54( ) ;
            }
            EndLevel1F54( ) ;
         }
         CloseExtendedTableCursors1F54( ) ;
      }

      protected void Update1F54( )
      {
         BeforeValidate1F54( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1F54( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1F54( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1F54( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1F54( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001F8 */
                     pr_default.execute(6, new Object[] {n377ProcedimentosMedicosNome, A377ProcedimentosMedicosNome, n378ProcedimentosMedicosDescricao, A378ProcedimentosMedicosDescricao, n379ProcedimentosMedicosArea, A379ProcedimentosMedicosArea, n408CID, A408CID, A409ProcedimentosMedicosAtivo, n376ProcedimentosMedicosId, A376ProcedimentosMedicosId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("ProcedimentosMedicos");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ProcedimentosMedicos"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1F54( ) ;
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
            EndLevel1F54( ) ;
         }
         CloseExtendedTableCursors1F54( ) ;
      }

      protected void DeferredUpdate1F54( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1F54( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1F54( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1F54( ) ;
            AfterConfirm1F54( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1F54( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001F9 */
                  pr_default.execute(7, new Object[] {n376ProcedimentosMedicosId, A376ProcedimentosMedicosId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("ProcedimentosMedicos");
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
         sMode54 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1F54( ) ;
         Gx_mode = sMode54;
      }

      protected void OnDeleteControls1F54( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC001F10 */
            pr_default.execute(8, new Object[] {n376ProcedimentosMedicosId, A376ProcedimentosMedicosId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Proposta"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
         }
      }

      protected void EndLevel1F54( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1F54( ) ;
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

      public void ScanKeyStart1F54( )
      {
         /* Using cursor BC001F11 */
         pr_default.execute(9, new Object[] {n376ProcedimentosMedicosId, A376ProcedimentosMedicosId});
         RcdFound54 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound54 = 1;
            A376ProcedimentosMedicosId = BC001F11_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = BC001F11_n376ProcedimentosMedicosId[0];
            A377ProcedimentosMedicosNome = BC001F11_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = BC001F11_n377ProcedimentosMedicosNome[0];
            A378ProcedimentosMedicosDescricao = BC001F11_A378ProcedimentosMedicosDescricao[0];
            n378ProcedimentosMedicosDescricao = BC001F11_n378ProcedimentosMedicosDescricao[0];
            A379ProcedimentosMedicosArea = BC001F11_A379ProcedimentosMedicosArea[0];
            n379ProcedimentosMedicosArea = BC001F11_n379ProcedimentosMedicosArea[0];
            A408CID = BC001F11_A408CID[0];
            n408CID = BC001F11_n408CID[0];
            A409ProcedimentosMedicosAtivo = BC001F11_A409ProcedimentosMedicosAtivo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1F54( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound54 = 0;
         ScanKeyLoad1F54( ) ;
      }

      protected void ScanKeyLoad1F54( )
      {
         sMode54 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound54 = 1;
            A376ProcedimentosMedicosId = BC001F11_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = BC001F11_n376ProcedimentosMedicosId[0];
            A377ProcedimentosMedicosNome = BC001F11_A377ProcedimentosMedicosNome[0];
            n377ProcedimentosMedicosNome = BC001F11_n377ProcedimentosMedicosNome[0];
            A378ProcedimentosMedicosDescricao = BC001F11_A378ProcedimentosMedicosDescricao[0];
            n378ProcedimentosMedicosDescricao = BC001F11_n378ProcedimentosMedicosDescricao[0];
            A379ProcedimentosMedicosArea = BC001F11_A379ProcedimentosMedicosArea[0];
            n379ProcedimentosMedicosArea = BC001F11_n379ProcedimentosMedicosArea[0];
            A408CID = BC001F11_A408CID[0];
            n408CID = BC001F11_n408CID[0];
            A409ProcedimentosMedicosAtivo = BC001F11_A409ProcedimentosMedicosAtivo[0];
         }
         Gx_mode = sMode54;
      }

      protected void ScanKeyEnd1F54( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm1F54( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1F54( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1F54( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1F54( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1F54( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1F54( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1F54( )
      {
      }

      protected void send_integrity_lvl_hashes1F54( )
      {
      }

      protected void AddRow1F54( )
      {
         VarsToRow54( bcProcedimentosMedicos) ;
      }

      protected void ReadRow1F54( )
      {
         RowToVars54( bcProcedimentosMedicos, 1) ;
      }

      protected void InitializeNonKey1F54( )
      {
         A377ProcedimentosMedicosNome = "";
         n377ProcedimentosMedicosNome = false;
         A378ProcedimentosMedicosDescricao = "";
         n378ProcedimentosMedicosDescricao = false;
         A379ProcedimentosMedicosArea = "";
         n379ProcedimentosMedicosArea = false;
         A408CID = 0;
         n408CID = false;
         A409ProcedimentosMedicosAtivo = false;
         Z377ProcedimentosMedicosNome = "";
         Z379ProcedimentosMedicosArea = "";
         Z408CID = 0;
         Z409ProcedimentosMedicosAtivo = false;
      }

      protected void InitAll1F54( )
      {
         A376ProcedimentosMedicosId = 0;
         n376ProcedimentosMedicosId = false;
         InitializeNonKey1F54( ) ;
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

      public void VarsToRow54( SdtProcedimentosMedicos obj54 )
      {
         obj54.gxTpr_Mode = Gx_mode;
         obj54.gxTpr_Procedimentosmedicosnome = A377ProcedimentosMedicosNome;
         obj54.gxTpr_Procedimentosmedicosdescricao = A378ProcedimentosMedicosDescricao;
         obj54.gxTpr_Procedimentosmedicosarea = A379ProcedimentosMedicosArea;
         obj54.gxTpr_Cid = A408CID;
         obj54.gxTpr_Procedimentosmedicosativo = A409ProcedimentosMedicosAtivo;
         obj54.gxTpr_Procedimentosmedicosid = A376ProcedimentosMedicosId;
         obj54.gxTpr_Procedimentosmedicosid_Z = Z376ProcedimentosMedicosId;
         obj54.gxTpr_Procedimentosmedicosnome_Z = Z377ProcedimentosMedicosNome;
         obj54.gxTpr_Procedimentosmedicosarea_Z = Z379ProcedimentosMedicosArea;
         obj54.gxTpr_Cid_Z = Z408CID;
         obj54.gxTpr_Procedimentosmedicosativo_Z = Z409ProcedimentosMedicosAtivo;
         obj54.gxTpr_Procedimentosmedicosid_N = (short)(Convert.ToInt16(n376ProcedimentosMedicosId));
         obj54.gxTpr_Procedimentosmedicosnome_N = (short)(Convert.ToInt16(n377ProcedimentosMedicosNome));
         obj54.gxTpr_Procedimentosmedicosdescricao_N = (short)(Convert.ToInt16(n378ProcedimentosMedicosDescricao));
         obj54.gxTpr_Procedimentosmedicosarea_N = (short)(Convert.ToInt16(n379ProcedimentosMedicosArea));
         obj54.gxTpr_Cid_N = (short)(Convert.ToInt16(n408CID));
         obj54.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow54( SdtProcedimentosMedicos obj54 )
      {
         obj54.gxTpr_Procedimentosmedicosid = A376ProcedimentosMedicosId;
         return  ;
      }

      public void RowToVars54( SdtProcedimentosMedicos obj54 ,
                               int forceLoad )
      {
         Gx_mode = obj54.gxTpr_Mode;
         A377ProcedimentosMedicosNome = obj54.gxTpr_Procedimentosmedicosnome;
         n377ProcedimentosMedicosNome = false;
         A378ProcedimentosMedicosDescricao = obj54.gxTpr_Procedimentosmedicosdescricao;
         n378ProcedimentosMedicosDescricao = false;
         A379ProcedimentosMedicosArea = obj54.gxTpr_Procedimentosmedicosarea;
         n379ProcedimentosMedicosArea = false;
         A408CID = obj54.gxTpr_Cid;
         n408CID = false;
         A409ProcedimentosMedicosAtivo = obj54.gxTpr_Procedimentosmedicosativo;
         A376ProcedimentosMedicosId = obj54.gxTpr_Procedimentosmedicosid;
         n376ProcedimentosMedicosId = false;
         Z376ProcedimentosMedicosId = obj54.gxTpr_Procedimentosmedicosid_Z;
         Z377ProcedimentosMedicosNome = obj54.gxTpr_Procedimentosmedicosnome_Z;
         Z379ProcedimentosMedicosArea = obj54.gxTpr_Procedimentosmedicosarea_Z;
         Z408CID = obj54.gxTpr_Cid_Z;
         Z409ProcedimentosMedicosAtivo = obj54.gxTpr_Procedimentosmedicosativo_Z;
         n376ProcedimentosMedicosId = (bool)(Convert.ToBoolean(obj54.gxTpr_Procedimentosmedicosid_N));
         n377ProcedimentosMedicosNome = (bool)(Convert.ToBoolean(obj54.gxTpr_Procedimentosmedicosnome_N));
         n378ProcedimentosMedicosDescricao = (bool)(Convert.ToBoolean(obj54.gxTpr_Procedimentosmedicosdescricao_N));
         n379ProcedimentosMedicosArea = (bool)(Convert.ToBoolean(obj54.gxTpr_Procedimentosmedicosarea_N));
         n408CID = (bool)(Convert.ToBoolean(obj54.gxTpr_Cid_N));
         Gx_mode = obj54.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A376ProcedimentosMedicosId = (int)getParm(obj,0);
         n376ProcedimentosMedicosId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1F54( ) ;
         ScanKeyStart1F54( ) ;
         if ( RcdFound54 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z376ProcedimentosMedicosId = A376ProcedimentosMedicosId;
         }
         ZM1F54( -1) ;
         OnLoadActions1F54( ) ;
         AddRow1F54( ) ;
         ScanKeyEnd1F54( ) ;
         if ( RcdFound54 == 0 )
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
         RowToVars54( bcProcedimentosMedicos, 0) ;
         ScanKeyStart1F54( ) ;
         if ( RcdFound54 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z376ProcedimentosMedicosId = A376ProcedimentosMedicosId;
         }
         ZM1F54( -1) ;
         OnLoadActions1F54( ) ;
         AddRow1F54( ) ;
         ScanKeyEnd1F54( ) ;
         if ( RcdFound54 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1F54( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1F54( ) ;
         }
         else
         {
            if ( RcdFound54 == 1 )
            {
               if ( A376ProcedimentosMedicosId != Z376ProcedimentosMedicosId )
               {
                  A376ProcedimentosMedicosId = Z376ProcedimentosMedicosId;
                  n376ProcedimentosMedicosId = false;
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
                  Update1F54( ) ;
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
                  if ( A376ProcedimentosMedicosId != Z376ProcedimentosMedicosId )
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
                        Insert1F54( ) ;
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
                        Insert1F54( ) ;
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
         RowToVars54( bcProcedimentosMedicos, 1) ;
         SaveImpl( ) ;
         VarsToRow54( bcProcedimentosMedicos) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars54( bcProcedimentosMedicos, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1F54( ) ;
         AfterTrn( ) ;
         VarsToRow54( bcProcedimentosMedicos) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow54( bcProcedimentosMedicos) ;
         }
         else
         {
            SdtProcedimentosMedicos auxBC = new SdtProcedimentosMedicos(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A376ProcedimentosMedicosId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcProcedimentosMedicos);
               auxBC.Save();
               bcProcedimentosMedicos.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars54( bcProcedimentosMedicos, 1) ;
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
         RowToVars54( bcProcedimentosMedicos, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1F54( ) ;
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
               VarsToRow54( bcProcedimentosMedicos) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow54( bcProcedimentosMedicos) ;
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
         RowToVars54( bcProcedimentosMedicos, 0) ;
         GetKey1F54( ) ;
         if ( RcdFound54 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A376ProcedimentosMedicosId != Z376ProcedimentosMedicosId )
            {
               A376ProcedimentosMedicosId = Z376ProcedimentosMedicosId;
               n376ProcedimentosMedicosId = false;
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
            if ( A376ProcedimentosMedicosId != Z376ProcedimentosMedicosId )
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
         context.RollbackDataStores("procedimentosmedicos_bc",pr_default);
         VarsToRow54( bcProcedimentosMedicos) ;
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
         Gx_mode = bcProcedimentosMedicos.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcProcedimentosMedicos.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcProcedimentosMedicos )
         {
            bcProcedimentosMedicos = (SdtProcedimentosMedicos)(sdt);
            if ( StringUtil.StrCmp(bcProcedimentosMedicos.gxTpr_Mode, "") == 0 )
            {
               bcProcedimentosMedicos.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow54( bcProcedimentosMedicos) ;
            }
            else
            {
               RowToVars54( bcProcedimentosMedicos, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcProcedimentosMedicos.gxTpr_Mode, "") == 0 )
            {
               bcProcedimentosMedicos.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars54( bcProcedimentosMedicos, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtProcedimentosMedicos ProcedimentosMedicos_BC
      {
         get {
            return bcProcedimentosMedicos ;
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
         Z377ProcedimentosMedicosNome = "";
         A377ProcedimentosMedicosNome = "";
         Z379ProcedimentosMedicosArea = "";
         A379ProcedimentosMedicosArea = "";
         Z378ProcedimentosMedicosDescricao = "";
         A378ProcedimentosMedicosDescricao = "";
         BC001F4_A376ProcedimentosMedicosId = new int[1] ;
         BC001F4_n376ProcedimentosMedicosId = new bool[] {false} ;
         BC001F4_A377ProcedimentosMedicosNome = new string[] {""} ;
         BC001F4_n377ProcedimentosMedicosNome = new bool[] {false} ;
         BC001F4_A378ProcedimentosMedicosDescricao = new string[] {""} ;
         BC001F4_n378ProcedimentosMedicosDescricao = new bool[] {false} ;
         BC001F4_A379ProcedimentosMedicosArea = new string[] {""} ;
         BC001F4_n379ProcedimentosMedicosArea = new bool[] {false} ;
         BC001F4_A408CID = new int[1] ;
         BC001F4_n408CID = new bool[] {false} ;
         BC001F4_A409ProcedimentosMedicosAtivo = new bool[] {false} ;
         BC001F5_A376ProcedimentosMedicosId = new int[1] ;
         BC001F5_n376ProcedimentosMedicosId = new bool[] {false} ;
         BC001F3_A376ProcedimentosMedicosId = new int[1] ;
         BC001F3_n376ProcedimentosMedicosId = new bool[] {false} ;
         BC001F3_A377ProcedimentosMedicosNome = new string[] {""} ;
         BC001F3_n377ProcedimentosMedicosNome = new bool[] {false} ;
         BC001F3_A378ProcedimentosMedicosDescricao = new string[] {""} ;
         BC001F3_n378ProcedimentosMedicosDescricao = new bool[] {false} ;
         BC001F3_A379ProcedimentosMedicosArea = new string[] {""} ;
         BC001F3_n379ProcedimentosMedicosArea = new bool[] {false} ;
         BC001F3_A408CID = new int[1] ;
         BC001F3_n408CID = new bool[] {false} ;
         BC001F3_A409ProcedimentosMedicosAtivo = new bool[] {false} ;
         sMode54 = "";
         BC001F2_A376ProcedimentosMedicosId = new int[1] ;
         BC001F2_n376ProcedimentosMedicosId = new bool[] {false} ;
         BC001F2_A377ProcedimentosMedicosNome = new string[] {""} ;
         BC001F2_n377ProcedimentosMedicosNome = new bool[] {false} ;
         BC001F2_A378ProcedimentosMedicosDescricao = new string[] {""} ;
         BC001F2_n378ProcedimentosMedicosDescricao = new bool[] {false} ;
         BC001F2_A379ProcedimentosMedicosArea = new string[] {""} ;
         BC001F2_n379ProcedimentosMedicosArea = new bool[] {false} ;
         BC001F2_A408CID = new int[1] ;
         BC001F2_n408CID = new bool[] {false} ;
         BC001F2_A409ProcedimentosMedicosAtivo = new bool[] {false} ;
         BC001F7_A376ProcedimentosMedicosId = new int[1] ;
         BC001F7_n376ProcedimentosMedicosId = new bool[] {false} ;
         BC001F10_A323PropostaId = new int[1] ;
         BC001F11_A376ProcedimentosMedicosId = new int[1] ;
         BC001F11_n376ProcedimentosMedicosId = new bool[] {false} ;
         BC001F11_A377ProcedimentosMedicosNome = new string[] {""} ;
         BC001F11_n377ProcedimentosMedicosNome = new bool[] {false} ;
         BC001F11_A378ProcedimentosMedicosDescricao = new string[] {""} ;
         BC001F11_n378ProcedimentosMedicosDescricao = new bool[] {false} ;
         BC001F11_A379ProcedimentosMedicosArea = new string[] {""} ;
         BC001F11_n379ProcedimentosMedicosArea = new bool[] {false} ;
         BC001F11_A408CID = new int[1] ;
         BC001F11_n408CID = new bool[] {false} ;
         BC001F11_A409ProcedimentosMedicosAtivo = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.procedimentosmedicos_bc__default(),
            new Object[][] {
                new Object[] {
               BC001F2_A376ProcedimentosMedicosId, BC001F2_A377ProcedimentosMedicosNome, BC001F2_n377ProcedimentosMedicosNome, BC001F2_A378ProcedimentosMedicosDescricao, BC001F2_n378ProcedimentosMedicosDescricao, BC001F2_A379ProcedimentosMedicosArea, BC001F2_n379ProcedimentosMedicosArea, BC001F2_A408CID, BC001F2_n408CID, BC001F2_A409ProcedimentosMedicosAtivo
               }
               , new Object[] {
               BC001F3_A376ProcedimentosMedicosId, BC001F3_A377ProcedimentosMedicosNome, BC001F3_n377ProcedimentosMedicosNome, BC001F3_A378ProcedimentosMedicosDescricao, BC001F3_n378ProcedimentosMedicosDescricao, BC001F3_A379ProcedimentosMedicosArea, BC001F3_n379ProcedimentosMedicosArea, BC001F3_A408CID, BC001F3_n408CID, BC001F3_A409ProcedimentosMedicosAtivo
               }
               , new Object[] {
               BC001F4_A376ProcedimentosMedicosId, BC001F4_A377ProcedimentosMedicosNome, BC001F4_n377ProcedimentosMedicosNome, BC001F4_A378ProcedimentosMedicosDescricao, BC001F4_n378ProcedimentosMedicosDescricao, BC001F4_A379ProcedimentosMedicosArea, BC001F4_n379ProcedimentosMedicosArea, BC001F4_A408CID, BC001F4_n408CID, BC001F4_A409ProcedimentosMedicosAtivo
               }
               , new Object[] {
               BC001F5_A376ProcedimentosMedicosId
               }
               , new Object[] {
               }
               , new Object[] {
               BC001F7_A376ProcedimentosMedicosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001F10_A323PropostaId
               }
               , new Object[] {
               BC001F11_A376ProcedimentosMedicosId, BC001F11_A377ProcedimentosMedicosNome, BC001F11_n377ProcedimentosMedicosNome, BC001F11_A378ProcedimentosMedicosDescricao, BC001F11_n378ProcedimentosMedicosDescricao, BC001F11_A379ProcedimentosMedicosArea, BC001F11_n379ProcedimentosMedicosArea, BC001F11_A408CID, BC001F11_n408CID, BC001F11_A409ProcedimentosMedicosAtivo
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound54 ;
      private int trnEnded ;
      private int Z376ProcedimentosMedicosId ;
      private int A376ProcedimentosMedicosId ;
      private int Z408CID ;
      private int A408CID ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode54 ;
      private bool Z409ProcedimentosMedicosAtivo ;
      private bool A409ProcedimentosMedicosAtivo ;
      private bool n376ProcedimentosMedicosId ;
      private bool n377ProcedimentosMedicosNome ;
      private bool n378ProcedimentosMedicosDescricao ;
      private bool n379ProcedimentosMedicosArea ;
      private bool n408CID ;
      private string Z378ProcedimentosMedicosDescricao ;
      private string A378ProcedimentosMedicosDescricao ;
      private string Z377ProcedimentosMedicosNome ;
      private string A377ProcedimentosMedicosNome ;
      private string Z379ProcedimentosMedicosArea ;
      private string A379ProcedimentosMedicosArea ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC001F4_A376ProcedimentosMedicosId ;
      private bool[] BC001F4_n376ProcedimentosMedicosId ;
      private string[] BC001F4_A377ProcedimentosMedicosNome ;
      private bool[] BC001F4_n377ProcedimentosMedicosNome ;
      private string[] BC001F4_A378ProcedimentosMedicosDescricao ;
      private bool[] BC001F4_n378ProcedimentosMedicosDescricao ;
      private string[] BC001F4_A379ProcedimentosMedicosArea ;
      private bool[] BC001F4_n379ProcedimentosMedicosArea ;
      private int[] BC001F4_A408CID ;
      private bool[] BC001F4_n408CID ;
      private bool[] BC001F4_A409ProcedimentosMedicosAtivo ;
      private int[] BC001F5_A376ProcedimentosMedicosId ;
      private bool[] BC001F5_n376ProcedimentosMedicosId ;
      private int[] BC001F3_A376ProcedimentosMedicosId ;
      private bool[] BC001F3_n376ProcedimentosMedicosId ;
      private string[] BC001F3_A377ProcedimentosMedicosNome ;
      private bool[] BC001F3_n377ProcedimentosMedicosNome ;
      private string[] BC001F3_A378ProcedimentosMedicosDescricao ;
      private bool[] BC001F3_n378ProcedimentosMedicosDescricao ;
      private string[] BC001F3_A379ProcedimentosMedicosArea ;
      private bool[] BC001F3_n379ProcedimentosMedicosArea ;
      private int[] BC001F3_A408CID ;
      private bool[] BC001F3_n408CID ;
      private bool[] BC001F3_A409ProcedimentosMedicosAtivo ;
      private int[] BC001F2_A376ProcedimentosMedicosId ;
      private bool[] BC001F2_n376ProcedimentosMedicosId ;
      private string[] BC001F2_A377ProcedimentosMedicosNome ;
      private bool[] BC001F2_n377ProcedimentosMedicosNome ;
      private string[] BC001F2_A378ProcedimentosMedicosDescricao ;
      private bool[] BC001F2_n378ProcedimentosMedicosDescricao ;
      private string[] BC001F2_A379ProcedimentosMedicosArea ;
      private bool[] BC001F2_n379ProcedimentosMedicosArea ;
      private int[] BC001F2_A408CID ;
      private bool[] BC001F2_n408CID ;
      private bool[] BC001F2_A409ProcedimentosMedicosAtivo ;
      private int[] BC001F7_A376ProcedimentosMedicosId ;
      private bool[] BC001F7_n376ProcedimentosMedicosId ;
      private int[] BC001F10_A323PropostaId ;
      private int[] BC001F11_A376ProcedimentosMedicosId ;
      private bool[] BC001F11_n376ProcedimentosMedicosId ;
      private string[] BC001F11_A377ProcedimentosMedicosNome ;
      private bool[] BC001F11_n377ProcedimentosMedicosNome ;
      private string[] BC001F11_A378ProcedimentosMedicosDescricao ;
      private bool[] BC001F11_n378ProcedimentosMedicosDescricao ;
      private string[] BC001F11_A379ProcedimentosMedicosArea ;
      private bool[] BC001F11_n379ProcedimentosMedicosArea ;
      private int[] BC001F11_A408CID ;
      private bool[] BC001F11_n408CID ;
      private bool[] BC001F11_A409ProcedimentosMedicosAtivo ;
      private SdtProcedimentosMedicos bcProcedimentosMedicos ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class procedimentosmedicos_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[9])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC001F2;
          prmBC001F2 = new Object[] {
          new ParDef("ProcedimentosMedicosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001F3;
          prmBC001F3 = new Object[] {
          new ParDef("ProcedimentosMedicosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001F4;
          prmBC001F4 = new Object[] {
          new ParDef("ProcedimentosMedicosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001F5;
          prmBC001F5 = new Object[] {
          new ParDef("ProcedimentosMedicosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001F6;
          prmBC001F6 = new Object[] {
          new ParDef("ProcedimentosMedicosNome",GXType.VarChar,255,0){Nullable=true} ,
          new ParDef("ProcedimentosMedicosDescricao",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("ProcedimentosMedicosArea",GXType.VarChar,255,0){Nullable=true} ,
          new ParDef("CID",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ProcedimentosMedicosAtivo",GXType.Boolean,4,0)
          };
          Object[] prmBC001F7;
          prmBC001F7 = new Object[] {
          };
          Object[] prmBC001F8;
          prmBC001F8 = new Object[] {
          new ParDef("ProcedimentosMedicosNome",GXType.VarChar,255,0){Nullable=true} ,
          new ParDef("ProcedimentosMedicosDescricao",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("ProcedimentosMedicosArea",GXType.VarChar,255,0){Nullable=true} ,
          new ParDef("CID",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ProcedimentosMedicosAtivo",GXType.Boolean,4,0) ,
          new ParDef("ProcedimentosMedicosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001F9;
          prmBC001F9 = new Object[] {
          new ParDef("ProcedimentosMedicosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001F10;
          prmBC001F10 = new Object[] {
          new ParDef("ProcedimentosMedicosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001F11;
          prmBC001F11 = new Object[] {
          new ParDef("ProcedimentosMedicosId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC001F2", "SELECT ProcedimentosMedicosId, ProcedimentosMedicosNome, ProcedimentosMedicosDescricao, ProcedimentosMedicosArea, CID, ProcedimentosMedicosAtivo FROM ProcedimentosMedicos WHERE ProcedimentosMedicosId = :ProcedimentosMedicosId  FOR UPDATE OF ProcedimentosMedicos",true, GxErrorMask.GX_NOMASK, false, this,prmBC001F2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001F3", "SELECT ProcedimentosMedicosId, ProcedimentosMedicosNome, ProcedimentosMedicosDescricao, ProcedimentosMedicosArea, CID, ProcedimentosMedicosAtivo FROM ProcedimentosMedicos WHERE ProcedimentosMedicosId = :ProcedimentosMedicosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001F3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001F4", "SELECT TM1.ProcedimentosMedicosId, TM1.ProcedimentosMedicosNome, TM1.ProcedimentosMedicosDescricao, TM1.ProcedimentosMedicosArea, TM1.CID, TM1.ProcedimentosMedicosAtivo FROM ProcedimentosMedicos TM1 WHERE TM1.ProcedimentosMedicosId = :ProcedimentosMedicosId ORDER BY TM1.ProcedimentosMedicosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001F4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001F5", "SELECT ProcedimentosMedicosId FROM ProcedimentosMedicos WHERE ProcedimentosMedicosId = :ProcedimentosMedicosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001F5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001F6", "SAVEPOINT gxupdate;INSERT INTO ProcedimentosMedicos(ProcedimentosMedicosNome, ProcedimentosMedicosDescricao, ProcedimentosMedicosArea, CID, ProcedimentosMedicosAtivo) VALUES(:ProcedimentosMedicosNome, :ProcedimentosMedicosDescricao, :ProcedimentosMedicosArea, :CID, :ProcedimentosMedicosAtivo);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001F6)
             ,new CursorDef("BC001F7", "SELECT currval('ProcedimentosMedicosId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001F7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001F8", "SAVEPOINT gxupdate;UPDATE ProcedimentosMedicos SET ProcedimentosMedicosNome=:ProcedimentosMedicosNome, ProcedimentosMedicosDescricao=:ProcedimentosMedicosDescricao, ProcedimentosMedicosArea=:ProcedimentosMedicosArea, CID=:CID, ProcedimentosMedicosAtivo=:ProcedimentosMedicosAtivo  WHERE ProcedimentosMedicosId = :ProcedimentosMedicosId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001F8)
             ,new CursorDef("BC001F9", "SAVEPOINT gxupdate;DELETE FROM ProcedimentosMedicos  WHERE ProcedimentosMedicosId = :ProcedimentosMedicosId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001F9)
             ,new CursorDef("BC001F10", "SELECT PropostaId FROM Proposta WHERE ProcedimentosMedicosId = :ProcedimentosMedicosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001F10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001F11", "SELECT TM1.ProcedimentosMedicosId, TM1.ProcedimentosMedicosNome, TM1.ProcedimentosMedicosDescricao, TM1.ProcedimentosMedicosArea, TM1.CID, TM1.ProcedimentosMedicosAtivo FROM ProcedimentosMedicos TM1 WHERE TM1.ProcedimentosMedicosId = :ProcedimentosMedicosId ORDER BY TM1.ProcedimentosMedicosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001F11,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                return;
       }
    }

 }

}
