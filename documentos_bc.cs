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
   public class documentos_bc : GxSilentTrn, IGxSilentTrn
   {
      public documentos_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public documentos_bc( IGxContext context )
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
         ReadRow1M60( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1M60( ) ;
         standaloneModal( ) ;
         AddRow1M60( ) ;
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
            E111M2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z405DocumentosId = A405DocumentosId;
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

      protected void CONFIRM_1M0( )
      {
         BeforeValidate1M60( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1M60( ) ;
            }
            else
            {
               CheckExtendedTable1M60( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1M60( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E121M2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E111M2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1M60( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z407DocumentosStatus = A407DocumentosStatus;
            Z406DocumentosDescricao = A406DocumentosDescricao;
            Z413DocumentoObrigatorio = A413DocumentoObrigatorio;
            Z536DocumentoObrigatorioReembolso = A536DocumentoObrigatorioReembolso;
         }
         if ( GX_JID == -3 )
         {
            Z405DocumentosId = A405DocumentosId;
            Z407DocumentosStatus = A407DocumentosStatus;
            Z406DocumentosDescricao = A406DocumentosDescricao;
            Z413DocumentoObrigatorio = A413DocumentoObrigatorio;
            Z536DocumentoObrigatorioReembolso = A536DocumentoObrigatorioReembolso;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A407DocumentosStatus = true;
            n407DocumentosStatus = false;
         }
      }

      protected void Load1M60( )
      {
         /* Using cursor BC001M4 */
         pr_default.execute(2, new Object[] {n405DocumentosId, A405DocumentosId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound60 = 1;
            A407DocumentosStatus = BC001M4_A407DocumentosStatus[0];
            n407DocumentosStatus = BC001M4_n407DocumentosStatus[0];
            A406DocumentosDescricao = BC001M4_A406DocumentosDescricao[0];
            n406DocumentosDescricao = BC001M4_n406DocumentosDescricao[0];
            A413DocumentoObrigatorio = BC001M4_A413DocumentoObrigatorio[0];
            n413DocumentoObrigatorio = BC001M4_n413DocumentoObrigatorio[0];
            A536DocumentoObrigatorioReembolso = BC001M4_A536DocumentoObrigatorioReembolso[0];
            n536DocumentoObrigatorioReembolso = BC001M4_n536DocumentoObrigatorioReembolso[0];
            ZM1M60( -3) ;
         }
         pr_default.close(2);
         OnLoadActions1M60( ) ;
      }

      protected void OnLoadActions1M60( )
      {
      }

      protected void CheckExtendedTable1M60( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1M60( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1M60( )
      {
         /* Using cursor BC001M5 */
         pr_default.execute(3, new Object[] {n405DocumentosId, A405DocumentosId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound60 = 1;
         }
         else
         {
            RcdFound60 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001M3 */
         pr_default.execute(1, new Object[] {n405DocumentosId, A405DocumentosId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1M60( 3) ;
            RcdFound60 = 1;
            A405DocumentosId = BC001M3_A405DocumentosId[0];
            n405DocumentosId = BC001M3_n405DocumentosId[0];
            A407DocumentosStatus = BC001M3_A407DocumentosStatus[0];
            n407DocumentosStatus = BC001M3_n407DocumentosStatus[0];
            A406DocumentosDescricao = BC001M3_A406DocumentosDescricao[0];
            n406DocumentosDescricao = BC001M3_n406DocumentosDescricao[0];
            A413DocumentoObrigatorio = BC001M3_A413DocumentoObrigatorio[0];
            n413DocumentoObrigatorio = BC001M3_n413DocumentoObrigatorio[0];
            A536DocumentoObrigatorioReembolso = BC001M3_A536DocumentoObrigatorioReembolso[0];
            n536DocumentoObrigatorioReembolso = BC001M3_n536DocumentoObrigatorioReembolso[0];
            Z405DocumentosId = A405DocumentosId;
            sMode60 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1M60( ) ;
            if ( AnyError == 1 )
            {
               RcdFound60 = 0;
               InitializeNonKey1M60( ) ;
            }
            Gx_mode = sMode60;
         }
         else
         {
            RcdFound60 = 0;
            InitializeNonKey1M60( ) ;
            sMode60 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode60;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1M60( ) ;
         if ( RcdFound60 == 0 )
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
         CONFIRM_1M0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1M60( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001M2 */
            pr_default.execute(0, new Object[] {n405DocumentosId, A405DocumentosId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Documentos"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z407DocumentosStatus != BC001M2_A407DocumentosStatus[0] ) || ( StringUtil.StrCmp(Z406DocumentosDescricao, BC001M2_A406DocumentosDescricao[0]) != 0 ) || ( Z413DocumentoObrigatorio != BC001M2_A413DocumentoObrigatorio[0] ) || ( Z536DocumentoObrigatorioReembolso != BC001M2_A536DocumentoObrigatorioReembolso[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Documentos"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1M60( )
      {
         BeforeValidate1M60( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1M60( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1M60( 0) ;
            CheckOptimisticConcurrency1M60( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1M60( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1M60( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001M6 */
                     pr_default.execute(4, new Object[] {n407DocumentosStatus, A407DocumentosStatus, n406DocumentosDescricao, A406DocumentosDescricao, n413DocumentoObrigatorio, A413DocumentoObrigatorio, n536DocumentoObrigatorioReembolso, A536DocumentoObrigatorioReembolso});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC001M7 */
                     pr_default.execute(5);
                     A405DocumentosId = BC001M7_A405DocumentosId[0];
                     n405DocumentosId = BC001M7_n405DocumentosId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Documentos");
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
               Load1M60( ) ;
            }
            EndLevel1M60( ) ;
         }
         CloseExtendedTableCursors1M60( ) ;
      }

      protected void Update1M60( )
      {
         BeforeValidate1M60( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1M60( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1M60( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1M60( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1M60( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001M8 */
                     pr_default.execute(6, new Object[] {n407DocumentosStatus, A407DocumentosStatus, n406DocumentosDescricao, A406DocumentosDescricao, n413DocumentoObrigatorio, A413DocumentoObrigatorio, n536DocumentoObrigatorioReembolso, A536DocumentoObrigatorioReembolso, n405DocumentosId, A405DocumentosId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Documentos");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Documentos"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1M60( ) ;
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
            EndLevel1M60( ) ;
         }
         CloseExtendedTableCursors1M60( ) ;
      }

      protected void DeferredUpdate1M60( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1M60( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1M60( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1M60( ) ;
            AfterConfirm1M60( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1M60( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001M9 */
                  pr_default.execute(7, new Object[] {n405DocumentosId, A405DocumentosId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Documentos");
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
         sMode60 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1M60( ) ;
         Gx_mode = sMode60;
      }

      protected void OnDeleteControls1M60( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC001M10 */
            pr_default.execute(8, new Object[] {n405DocumentosId, A405DocumentosId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ClienteDocumento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
            /* Using cursor BC001M11 */
            pr_default.execute(9, new Object[] {n405DocumentosId, A405DocumentosId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ReembolsoDocumento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC001M12 */
            pr_default.execute(10, new Object[] {n405DocumentosId, A405DocumentosId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"PropostaDocumentos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel1M60( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1M60( ) ;
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

      public void ScanKeyStart1M60( )
      {
         /* Scan By routine */
         /* Using cursor BC001M13 */
         pr_default.execute(11, new Object[] {n405DocumentosId, A405DocumentosId});
         RcdFound60 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound60 = 1;
            A405DocumentosId = BC001M13_A405DocumentosId[0];
            n405DocumentosId = BC001M13_n405DocumentosId[0];
            A407DocumentosStatus = BC001M13_A407DocumentosStatus[0];
            n407DocumentosStatus = BC001M13_n407DocumentosStatus[0];
            A406DocumentosDescricao = BC001M13_A406DocumentosDescricao[0];
            n406DocumentosDescricao = BC001M13_n406DocumentosDescricao[0];
            A413DocumentoObrigatorio = BC001M13_A413DocumentoObrigatorio[0];
            n413DocumentoObrigatorio = BC001M13_n413DocumentoObrigatorio[0];
            A536DocumentoObrigatorioReembolso = BC001M13_A536DocumentoObrigatorioReembolso[0];
            n536DocumentoObrigatorioReembolso = BC001M13_n536DocumentoObrigatorioReembolso[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1M60( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound60 = 0;
         ScanKeyLoad1M60( ) ;
      }

      protected void ScanKeyLoad1M60( )
      {
         sMode60 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound60 = 1;
            A405DocumentosId = BC001M13_A405DocumentosId[0];
            n405DocumentosId = BC001M13_n405DocumentosId[0];
            A407DocumentosStatus = BC001M13_A407DocumentosStatus[0];
            n407DocumentosStatus = BC001M13_n407DocumentosStatus[0];
            A406DocumentosDescricao = BC001M13_A406DocumentosDescricao[0];
            n406DocumentosDescricao = BC001M13_n406DocumentosDescricao[0];
            A413DocumentoObrigatorio = BC001M13_A413DocumentoObrigatorio[0];
            n413DocumentoObrigatorio = BC001M13_n413DocumentoObrigatorio[0];
            A536DocumentoObrigatorioReembolso = BC001M13_A536DocumentoObrigatorioReembolso[0];
            n536DocumentoObrigatorioReembolso = BC001M13_n536DocumentoObrigatorioReembolso[0];
         }
         Gx_mode = sMode60;
      }

      protected void ScanKeyEnd1M60( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm1M60( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1M60( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1M60( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1M60( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1M60( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1M60( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1M60( )
      {
      }

      protected void send_integrity_lvl_hashes1M60( )
      {
      }

      protected void AddRow1M60( )
      {
         VarsToRow60( bcDocumentos) ;
      }

      protected void ReadRow1M60( )
      {
         RowToVars60( bcDocumentos, 1) ;
      }

      protected void InitializeNonKey1M60( )
      {
         A407DocumentosStatus = false;
         n407DocumentosStatus = false;
         A406DocumentosDescricao = "";
         n406DocumentosDescricao = false;
         A413DocumentoObrigatorio = false;
         n413DocumentoObrigatorio = false;
         A536DocumentoObrigatorioReembolso = false;
         n536DocumentoObrigatorioReembolso = false;
         Z407DocumentosStatus = false;
         Z406DocumentosDescricao = "";
         Z413DocumentoObrigatorio = false;
         Z536DocumentoObrigatorioReembolso = false;
      }

      protected void InitAll1M60( )
      {
         A405DocumentosId = 0;
         n405DocumentosId = false;
         InitializeNonKey1M60( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A407DocumentosStatus = i407DocumentosStatus;
         n407DocumentosStatus = false;
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

      public void VarsToRow60( SdtDocumentos obj60 )
      {
         obj60.gxTpr_Mode = Gx_mode;
         obj60.gxTpr_Documentosstatus = A407DocumentosStatus;
         obj60.gxTpr_Documentosdescricao = A406DocumentosDescricao;
         obj60.gxTpr_Documentoobrigatorio = A413DocumentoObrigatorio;
         obj60.gxTpr_Documentoobrigatorioreembolso = A536DocumentoObrigatorioReembolso;
         obj60.gxTpr_Documentosid = A405DocumentosId;
         obj60.gxTpr_Documentosid_Z = Z405DocumentosId;
         obj60.gxTpr_Documentosdescricao_Z = Z406DocumentosDescricao;
         obj60.gxTpr_Documentosstatus_Z = Z407DocumentosStatus;
         obj60.gxTpr_Documentoobrigatorio_Z = Z413DocumentoObrigatorio;
         obj60.gxTpr_Documentoobrigatorioreembolso_Z = Z536DocumentoObrigatorioReembolso;
         obj60.gxTpr_Documentosid_N = (short)(Convert.ToInt16(n405DocumentosId));
         obj60.gxTpr_Documentosdescricao_N = (short)(Convert.ToInt16(n406DocumentosDescricao));
         obj60.gxTpr_Documentosstatus_N = (short)(Convert.ToInt16(n407DocumentosStatus));
         obj60.gxTpr_Documentoobrigatorio_N = (short)(Convert.ToInt16(n413DocumentoObrigatorio));
         obj60.gxTpr_Documentoobrigatorioreembolso_N = (short)(Convert.ToInt16(n536DocumentoObrigatorioReembolso));
         obj60.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow60( SdtDocumentos obj60 )
      {
         obj60.gxTpr_Documentosid = A405DocumentosId;
         return  ;
      }

      public void RowToVars60( SdtDocumentos obj60 ,
                               int forceLoad )
      {
         Gx_mode = obj60.gxTpr_Mode;
         if ( ! ( IsIns( )  ) || ( forceLoad == 1 ) )
         {
            A407DocumentosStatus = obj60.gxTpr_Documentosstatus;
            n407DocumentosStatus = false;
         }
         A406DocumentosDescricao = obj60.gxTpr_Documentosdescricao;
         n406DocumentosDescricao = false;
         A413DocumentoObrigatorio = obj60.gxTpr_Documentoobrigatorio;
         n413DocumentoObrigatorio = false;
         A536DocumentoObrigatorioReembolso = obj60.gxTpr_Documentoobrigatorioreembolso;
         n536DocumentoObrigatorioReembolso = false;
         A405DocumentosId = obj60.gxTpr_Documentosid;
         n405DocumentosId = false;
         Z405DocumentosId = obj60.gxTpr_Documentosid_Z;
         Z406DocumentosDescricao = obj60.gxTpr_Documentosdescricao_Z;
         Z407DocumentosStatus = obj60.gxTpr_Documentosstatus_Z;
         Z413DocumentoObrigatorio = obj60.gxTpr_Documentoobrigatorio_Z;
         Z536DocumentoObrigatorioReembolso = obj60.gxTpr_Documentoobrigatorioreembolso_Z;
         n405DocumentosId = (bool)(Convert.ToBoolean(obj60.gxTpr_Documentosid_N));
         n406DocumentosDescricao = (bool)(Convert.ToBoolean(obj60.gxTpr_Documentosdescricao_N));
         n407DocumentosStatus = (bool)(Convert.ToBoolean(obj60.gxTpr_Documentosstatus_N));
         n413DocumentoObrigatorio = (bool)(Convert.ToBoolean(obj60.gxTpr_Documentoobrigatorio_N));
         n536DocumentoObrigatorioReembolso = (bool)(Convert.ToBoolean(obj60.gxTpr_Documentoobrigatorioreembolso_N));
         Gx_mode = obj60.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A405DocumentosId = (int)getParm(obj,0);
         n405DocumentosId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1M60( ) ;
         ScanKeyStart1M60( ) ;
         if ( RcdFound60 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z405DocumentosId = A405DocumentosId;
         }
         ZM1M60( -3) ;
         OnLoadActions1M60( ) ;
         AddRow1M60( ) ;
         ScanKeyEnd1M60( ) ;
         if ( RcdFound60 == 0 )
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
         RowToVars60( bcDocumentos, 0) ;
         ScanKeyStart1M60( ) ;
         if ( RcdFound60 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z405DocumentosId = A405DocumentosId;
         }
         ZM1M60( -3) ;
         OnLoadActions1M60( ) ;
         AddRow1M60( ) ;
         ScanKeyEnd1M60( ) ;
         if ( RcdFound60 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1M60( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1M60( ) ;
         }
         else
         {
            if ( RcdFound60 == 1 )
            {
               if ( A405DocumentosId != Z405DocumentosId )
               {
                  A405DocumentosId = Z405DocumentosId;
                  n405DocumentosId = false;
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
                  Update1M60( ) ;
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
                  if ( A405DocumentosId != Z405DocumentosId )
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
                        Insert1M60( ) ;
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
                        Insert1M60( ) ;
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
         RowToVars60( bcDocumentos, 1) ;
         SaveImpl( ) ;
         VarsToRow60( bcDocumentos) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars60( bcDocumentos, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1M60( ) ;
         AfterTrn( ) ;
         VarsToRow60( bcDocumentos) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow60( bcDocumentos) ;
         }
         else
         {
            SdtDocumentos auxBC = new SdtDocumentos(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A405DocumentosId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcDocumentos);
               auxBC.Save();
               bcDocumentos.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars60( bcDocumentos, 1) ;
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
         RowToVars60( bcDocumentos, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1M60( ) ;
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
               VarsToRow60( bcDocumentos) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow60( bcDocumentos) ;
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
         RowToVars60( bcDocumentos, 0) ;
         GetKey1M60( ) ;
         if ( RcdFound60 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A405DocumentosId != Z405DocumentosId )
            {
               A405DocumentosId = Z405DocumentosId;
               n405DocumentosId = false;
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
            if ( A405DocumentosId != Z405DocumentosId )
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
         context.RollbackDataStores("documentos_bc",pr_default);
         VarsToRow60( bcDocumentos) ;
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
         Gx_mode = bcDocumentos.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcDocumentos.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcDocumentos )
         {
            bcDocumentos = (SdtDocumentos)(sdt);
            if ( StringUtil.StrCmp(bcDocumentos.gxTpr_Mode, "") == 0 )
            {
               bcDocumentos.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow60( bcDocumentos) ;
            }
            else
            {
               RowToVars60( bcDocumentos, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcDocumentos.gxTpr_Mode, "") == 0 )
            {
               bcDocumentos.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars60( bcDocumentos, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtDocumentos Documentos_BC
      {
         get {
            return bcDocumentos ;
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
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         Z406DocumentosDescricao = "";
         A406DocumentosDescricao = "";
         BC001M4_A405DocumentosId = new int[1] ;
         BC001M4_n405DocumentosId = new bool[] {false} ;
         BC001M4_A407DocumentosStatus = new bool[] {false} ;
         BC001M4_n407DocumentosStatus = new bool[] {false} ;
         BC001M4_A406DocumentosDescricao = new string[] {""} ;
         BC001M4_n406DocumentosDescricao = new bool[] {false} ;
         BC001M4_A413DocumentoObrigatorio = new bool[] {false} ;
         BC001M4_n413DocumentoObrigatorio = new bool[] {false} ;
         BC001M4_A536DocumentoObrigatorioReembolso = new bool[] {false} ;
         BC001M4_n536DocumentoObrigatorioReembolso = new bool[] {false} ;
         BC001M5_A405DocumentosId = new int[1] ;
         BC001M5_n405DocumentosId = new bool[] {false} ;
         BC001M3_A405DocumentosId = new int[1] ;
         BC001M3_n405DocumentosId = new bool[] {false} ;
         BC001M3_A407DocumentosStatus = new bool[] {false} ;
         BC001M3_n407DocumentosStatus = new bool[] {false} ;
         BC001M3_A406DocumentosDescricao = new string[] {""} ;
         BC001M3_n406DocumentosDescricao = new bool[] {false} ;
         BC001M3_A413DocumentoObrigatorio = new bool[] {false} ;
         BC001M3_n413DocumentoObrigatorio = new bool[] {false} ;
         BC001M3_A536DocumentoObrigatorioReembolso = new bool[] {false} ;
         BC001M3_n536DocumentoObrigatorioReembolso = new bool[] {false} ;
         sMode60 = "";
         BC001M2_A405DocumentosId = new int[1] ;
         BC001M2_n405DocumentosId = new bool[] {false} ;
         BC001M2_A407DocumentosStatus = new bool[] {false} ;
         BC001M2_n407DocumentosStatus = new bool[] {false} ;
         BC001M2_A406DocumentosDescricao = new string[] {""} ;
         BC001M2_n406DocumentosDescricao = new bool[] {false} ;
         BC001M2_A413DocumentoObrigatorio = new bool[] {false} ;
         BC001M2_n413DocumentoObrigatorio = new bool[] {false} ;
         BC001M2_A536DocumentoObrigatorioReembolso = new bool[] {false} ;
         BC001M2_n536DocumentoObrigatorioReembolso = new bool[] {false} ;
         BC001M7_A405DocumentosId = new int[1] ;
         BC001M7_n405DocumentosId = new bool[] {false} ;
         BC001M10_A599ClienteDocumentoId = new int[1] ;
         BC001M11_A529ReembolsoDocumentoId = new int[1] ;
         BC001M12_A414PropostaDocumentosId = new int[1] ;
         BC001M13_A405DocumentosId = new int[1] ;
         BC001M13_n405DocumentosId = new bool[] {false} ;
         BC001M13_A407DocumentosStatus = new bool[] {false} ;
         BC001M13_n407DocumentosStatus = new bool[] {false} ;
         BC001M13_A406DocumentosDescricao = new string[] {""} ;
         BC001M13_n406DocumentosDescricao = new bool[] {false} ;
         BC001M13_A413DocumentoObrigatorio = new bool[] {false} ;
         BC001M13_n413DocumentoObrigatorio = new bool[] {false} ;
         BC001M13_A536DocumentoObrigatorioReembolso = new bool[] {false} ;
         BC001M13_n536DocumentoObrigatorioReembolso = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.documentos_bc__default(),
            new Object[][] {
                new Object[] {
               BC001M2_A405DocumentosId, BC001M2_A407DocumentosStatus, BC001M2_n407DocumentosStatus, BC001M2_A406DocumentosDescricao, BC001M2_n406DocumentosDescricao, BC001M2_A413DocumentoObrigatorio, BC001M2_n413DocumentoObrigatorio, BC001M2_A536DocumentoObrigatorioReembolso, BC001M2_n536DocumentoObrigatorioReembolso
               }
               , new Object[] {
               BC001M3_A405DocumentosId, BC001M3_A407DocumentosStatus, BC001M3_n407DocumentosStatus, BC001M3_A406DocumentosDescricao, BC001M3_n406DocumentosDescricao, BC001M3_A413DocumentoObrigatorio, BC001M3_n413DocumentoObrigatorio, BC001M3_A536DocumentoObrigatorioReembolso, BC001M3_n536DocumentoObrigatorioReembolso
               }
               , new Object[] {
               BC001M4_A405DocumentosId, BC001M4_A407DocumentosStatus, BC001M4_n407DocumentosStatus, BC001M4_A406DocumentosDescricao, BC001M4_n406DocumentosDescricao, BC001M4_A413DocumentoObrigatorio, BC001M4_n413DocumentoObrigatorio, BC001M4_A536DocumentoObrigatorioReembolso, BC001M4_n536DocumentoObrigatorioReembolso
               }
               , new Object[] {
               BC001M5_A405DocumentosId
               }
               , new Object[] {
               }
               , new Object[] {
               BC001M7_A405DocumentosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001M10_A599ClienteDocumentoId
               }
               , new Object[] {
               BC001M11_A529ReembolsoDocumentoId
               }
               , new Object[] {
               BC001M12_A414PropostaDocumentosId
               }
               , new Object[] {
               BC001M13_A405DocumentosId, BC001M13_A407DocumentosStatus, BC001M13_n407DocumentosStatus, BC001M13_A406DocumentosDescricao, BC001M13_n406DocumentosDescricao, BC001M13_A413DocumentoObrigatorio, BC001M13_n413DocumentoObrigatorio, BC001M13_A536DocumentoObrigatorioReembolso, BC001M13_n536DocumentoObrigatorioReembolso
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121M2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound60 ;
      private int trnEnded ;
      private int Z405DocumentosId ;
      private int A405DocumentosId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode60 ;
      private bool returnInSub ;
      private bool Z407DocumentosStatus ;
      private bool A407DocumentosStatus ;
      private bool Z413DocumentoObrigatorio ;
      private bool A413DocumentoObrigatorio ;
      private bool Z536DocumentoObrigatorioReembolso ;
      private bool A536DocumentoObrigatorioReembolso ;
      private bool n407DocumentosStatus ;
      private bool n405DocumentosId ;
      private bool n406DocumentosDescricao ;
      private bool n413DocumentoObrigatorio ;
      private bool n536DocumentoObrigatorioReembolso ;
      private bool i407DocumentosStatus ;
      private string Z406DocumentosDescricao ;
      private string A406DocumentosDescricao ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private int[] BC001M4_A405DocumentosId ;
      private bool[] BC001M4_n405DocumentosId ;
      private bool[] BC001M4_A407DocumentosStatus ;
      private bool[] BC001M4_n407DocumentosStatus ;
      private string[] BC001M4_A406DocumentosDescricao ;
      private bool[] BC001M4_n406DocumentosDescricao ;
      private bool[] BC001M4_A413DocumentoObrigatorio ;
      private bool[] BC001M4_n413DocumentoObrigatorio ;
      private bool[] BC001M4_A536DocumentoObrigatorioReembolso ;
      private bool[] BC001M4_n536DocumentoObrigatorioReembolso ;
      private int[] BC001M5_A405DocumentosId ;
      private bool[] BC001M5_n405DocumentosId ;
      private int[] BC001M3_A405DocumentosId ;
      private bool[] BC001M3_n405DocumentosId ;
      private bool[] BC001M3_A407DocumentosStatus ;
      private bool[] BC001M3_n407DocumentosStatus ;
      private string[] BC001M3_A406DocumentosDescricao ;
      private bool[] BC001M3_n406DocumentosDescricao ;
      private bool[] BC001M3_A413DocumentoObrigatorio ;
      private bool[] BC001M3_n413DocumentoObrigatorio ;
      private bool[] BC001M3_A536DocumentoObrigatorioReembolso ;
      private bool[] BC001M3_n536DocumentoObrigatorioReembolso ;
      private int[] BC001M2_A405DocumentosId ;
      private bool[] BC001M2_n405DocumentosId ;
      private bool[] BC001M2_A407DocumentosStatus ;
      private bool[] BC001M2_n407DocumentosStatus ;
      private string[] BC001M2_A406DocumentosDescricao ;
      private bool[] BC001M2_n406DocumentosDescricao ;
      private bool[] BC001M2_A413DocumentoObrigatorio ;
      private bool[] BC001M2_n413DocumentoObrigatorio ;
      private bool[] BC001M2_A536DocumentoObrigatorioReembolso ;
      private bool[] BC001M2_n536DocumentoObrigatorioReembolso ;
      private int[] BC001M7_A405DocumentosId ;
      private bool[] BC001M7_n405DocumentosId ;
      private int[] BC001M10_A599ClienteDocumentoId ;
      private int[] BC001M11_A529ReembolsoDocumentoId ;
      private int[] BC001M12_A414PropostaDocumentosId ;
      private int[] BC001M13_A405DocumentosId ;
      private bool[] BC001M13_n405DocumentosId ;
      private bool[] BC001M13_A407DocumentosStatus ;
      private bool[] BC001M13_n407DocumentosStatus ;
      private string[] BC001M13_A406DocumentosDescricao ;
      private bool[] BC001M13_n406DocumentosDescricao ;
      private bool[] BC001M13_A413DocumentoObrigatorio ;
      private bool[] BC001M13_n413DocumentoObrigatorio ;
      private bool[] BC001M13_A536DocumentoObrigatorioReembolso ;
      private bool[] BC001M13_n536DocumentoObrigatorioReembolso ;
      private SdtDocumentos bcDocumentos ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class documentos_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC001M2;
          prmBC001M2 = new Object[] {
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001M3;
          prmBC001M3 = new Object[] {
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001M4;
          prmBC001M4 = new Object[] {
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001M5;
          prmBC001M5 = new Object[] {
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001M6;
          prmBC001M6 = new Object[] {
          new ParDef("DocumentosStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("DocumentosDescricao",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("DocumentoObrigatorio",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("DocumentoObrigatorioReembolso",GXType.Boolean,4,0){Nullable=true}
          };
          Object[] prmBC001M7;
          prmBC001M7 = new Object[] {
          };
          Object[] prmBC001M8;
          prmBC001M8 = new Object[] {
          new ParDef("DocumentosStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("DocumentosDescricao",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("DocumentoObrigatorio",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("DocumentoObrigatorioReembolso",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001M9;
          prmBC001M9 = new Object[] {
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001M10;
          prmBC001M10 = new Object[] {
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001M11;
          prmBC001M11 = new Object[] {
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001M12;
          prmBC001M12 = new Object[] {
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001M13;
          prmBC001M13 = new Object[] {
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC001M2", "SELECT DocumentosId, DocumentosStatus, DocumentosDescricao, DocumentoObrigatorio, DocumentoObrigatorioReembolso FROM Documentos WHERE DocumentosId = :DocumentosId  FOR UPDATE OF Documentos",true, GxErrorMask.GX_NOMASK, false, this,prmBC001M2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001M3", "SELECT DocumentosId, DocumentosStatus, DocumentosDescricao, DocumentoObrigatorio, DocumentoObrigatorioReembolso FROM Documentos WHERE DocumentosId = :DocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001M3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001M4", "SELECT TM1.DocumentosId, TM1.DocumentosStatus, TM1.DocumentosDescricao, TM1.DocumentoObrigatorio, TM1.DocumentoObrigatorioReembolso FROM Documentos TM1 WHERE TM1.DocumentosId = :DocumentosId ORDER BY TM1.DocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001M4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001M5", "SELECT DocumentosId FROM Documentos WHERE DocumentosId = :DocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001M5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001M6", "SAVEPOINT gxupdate;INSERT INTO Documentos(DocumentosStatus, DocumentosDescricao, DocumentoObrigatorio, DocumentoObrigatorioReembolso) VALUES(:DocumentosStatus, :DocumentosDescricao, :DocumentoObrigatorio, :DocumentoObrigatorioReembolso);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001M6)
             ,new CursorDef("BC001M7", "SELECT currval('DocumentosId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001M7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001M8", "SAVEPOINT gxupdate;UPDATE Documentos SET DocumentosStatus=:DocumentosStatus, DocumentosDescricao=:DocumentosDescricao, DocumentoObrigatorio=:DocumentoObrigatorio, DocumentoObrigatorioReembolso=:DocumentoObrigatorioReembolso  WHERE DocumentosId = :DocumentosId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001M8)
             ,new CursorDef("BC001M9", "SAVEPOINT gxupdate;DELETE FROM Documentos  WHERE DocumentosId = :DocumentosId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001M9)
             ,new CursorDef("BC001M10", "SELECT ClienteDocumentoId FROM ClienteDocumento WHERE DocumentosId = :DocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001M10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001M11", "SELECT ReembolsoDocumentoId FROM ReembolsoDocumento WHERE DocumentosId = :DocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001M11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001M12", "SELECT PropostaDocumentosId FROM PropostaDocumentos WHERE DocumentosId = :DocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001M12,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001M13", "SELECT TM1.DocumentosId, TM1.DocumentosStatus, TM1.DocumentosDescricao, TM1.DocumentoObrigatorio, TM1.DocumentoObrigatorioReembolso FROM Documentos TM1 WHERE TM1.DocumentosId = :DocumentosId ORDER BY TM1.DocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001M13,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
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
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}
