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
   public class propostadocumentos_bc : GxSilentTrn, IGxSilentTrn
   {
      public propostadocumentos_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public propostadocumentos_bc( IGxContext context )
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
         ReadRow1O62( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1O62( ) ;
         standaloneModal( ) ;
         AddRow1O62( ) ;
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
               Z414PropostaDocumentosId = A414PropostaDocumentosId;
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

      protected void CONFIRM_1O0( )
      {
         BeforeValidate1O62( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1O62( ) ;
            }
            else
            {
               CheckExtendedTable1O62( ) ;
               if ( AnyError == 0 )
               {
                  ZM1O62( 3) ;
                  ZM1O62( 4) ;
               }
               CloseExtendedTableCursors1O62( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM1O62( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z416PropostaDocumentosAnexoName = A416PropostaDocumentosAnexoName;
            Z417PropostaDocumentosAnexoFileType = A417PropostaDocumentosAnexoFileType;
            Z579PropostaDocumentosStatus = A579PropostaDocumentosStatus;
            Z651PropostaDocumentosAdm = A651PropostaDocumentosAdm;
            Z323PropostaId = A323PropostaId;
            Z405DocumentosId = A405DocumentosId;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z406DocumentosDescricao = A406DocumentosDescricao;
            Z407DocumentosStatus = A407DocumentosStatus;
         }
         if ( GX_JID == -2 )
         {
            Z414PropostaDocumentosId = A414PropostaDocumentosId;
            Z415PropostaDocumentosAnexo = A415PropostaDocumentosAnexo;
            Z416PropostaDocumentosAnexoName = A416PropostaDocumentosAnexoName;
            Z417PropostaDocumentosAnexoFileType = A417PropostaDocumentosAnexoFileType;
            Z579PropostaDocumentosStatus = A579PropostaDocumentosStatus;
            Z651PropostaDocumentosAdm = A651PropostaDocumentosAdm;
            Z323PropostaId = A323PropostaId;
            Z405DocumentosId = A405DocumentosId;
            Z406DocumentosDescricao = A406DocumentosDescricao;
            Z407DocumentosStatus = A407DocumentosStatus;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load1O62( )
      {
         /* Using cursor BC001O6 */
         pr_default.execute(4, new Object[] {A414PropostaDocumentosId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound62 = 1;
            A406DocumentosDescricao = BC001O6_A406DocumentosDescricao[0];
            n406DocumentosDescricao = BC001O6_n406DocumentosDescricao[0];
            A407DocumentosStatus = BC001O6_A407DocumentosStatus[0];
            n407DocumentosStatus = BC001O6_n407DocumentosStatus[0];
            A416PropostaDocumentosAnexoName = BC001O6_A416PropostaDocumentosAnexoName[0];
            n416PropostaDocumentosAnexoName = BC001O6_n416PropostaDocumentosAnexoName[0];
            A417PropostaDocumentosAnexoFileType = BC001O6_A417PropostaDocumentosAnexoFileType[0];
            n417PropostaDocumentosAnexoFileType = BC001O6_n417PropostaDocumentosAnexoFileType[0];
            A579PropostaDocumentosStatus = BC001O6_A579PropostaDocumentosStatus[0];
            n579PropostaDocumentosStatus = BC001O6_n579PropostaDocumentosStatus[0];
            A651PropostaDocumentosAdm = BC001O6_A651PropostaDocumentosAdm[0];
            n651PropostaDocumentosAdm = BC001O6_n651PropostaDocumentosAdm[0];
            A323PropostaId = BC001O6_A323PropostaId[0];
            n323PropostaId = BC001O6_n323PropostaId[0];
            A405DocumentosId = BC001O6_A405DocumentosId[0];
            n405DocumentosId = BC001O6_n405DocumentosId[0];
            A415PropostaDocumentosAnexo = BC001O6_A415PropostaDocumentosAnexo[0];
            n415PropostaDocumentosAnexo = BC001O6_n415PropostaDocumentosAnexo[0];
            ZM1O62( -2) ;
         }
         pr_default.close(4);
         OnLoadActions1O62( ) ;
      }

      protected void OnLoadActions1O62( )
      {
      }

      protected void CheckExtendedTable1O62( )
      {
         standaloneModal( ) ;
         /* Using cursor BC001O4 */
         pr_default.execute(2, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A323PropostaId) ) )
            {
               GX_msglist.addItem("Não existe 'Proposta'.", "ForeignKeyNotFound", 1, "PROPOSTAID");
               AnyError = 1;
            }
         }
         pr_default.close(2);
         /* Using cursor BC001O5 */
         pr_default.execute(3, new Object[] {n405DocumentosId, A405DocumentosId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A405DocumentosId) ) )
            {
               GX_msglist.addItem("Não existe 'Documentos'.", "ForeignKeyNotFound", 1, "DOCUMENTOSID");
               AnyError = 1;
            }
         }
         A406DocumentosDescricao = BC001O5_A406DocumentosDescricao[0];
         n406DocumentosDescricao = BC001O5_n406DocumentosDescricao[0];
         A407DocumentosStatus = BC001O5_A407DocumentosStatus[0];
         n407DocumentosStatus = BC001O5_n407DocumentosStatus[0];
         pr_default.close(3);
         if ( ! ( ( StringUtil.StrCmp(A579PropostaDocumentosStatus, "AGUARDANDO_ANALISE") == 0 ) || ( StringUtil.StrCmp(A579PropostaDocumentosStatus, "APROVADO") == 0 ) || ( StringUtil.StrCmp(A579PropostaDocumentosStatus, "REPROVADO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A579PropostaDocumentosStatus)) ) )
         {
            GX_msglist.addItem("Campo Proposta Documentos Status fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1O62( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1O62( )
      {
         /* Using cursor BC001O7 */
         pr_default.execute(5, new Object[] {A414PropostaDocumentosId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound62 = 1;
         }
         else
         {
            RcdFound62 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001O3 */
         pr_default.execute(1, new Object[] {A414PropostaDocumentosId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1O62( 2) ;
            RcdFound62 = 1;
            A414PropostaDocumentosId = BC001O3_A414PropostaDocumentosId[0];
            A416PropostaDocumentosAnexoName = BC001O3_A416PropostaDocumentosAnexoName[0];
            n416PropostaDocumentosAnexoName = BC001O3_n416PropostaDocumentosAnexoName[0];
            A417PropostaDocumentosAnexoFileType = BC001O3_A417PropostaDocumentosAnexoFileType[0];
            n417PropostaDocumentosAnexoFileType = BC001O3_n417PropostaDocumentosAnexoFileType[0];
            A579PropostaDocumentosStatus = BC001O3_A579PropostaDocumentosStatus[0];
            n579PropostaDocumentosStatus = BC001O3_n579PropostaDocumentosStatus[0];
            A651PropostaDocumentosAdm = BC001O3_A651PropostaDocumentosAdm[0];
            n651PropostaDocumentosAdm = BC001O3_n651PropostaDocumentosAdm[0];
            A323PropostaId = BC001O3_A323PropostaId[0];
            n323PropostaId = BC001O3_n323PropostaId[0];
            A405DocumentosId = BC001O3_A405DocumentosId[0];
            n405DocumentosId = BC001O3_n405DocumentosId[0];
            A415PropostaDocumentosAnexo = BC001O3_A415PropostaDocumentosAnexo[0];
            n415PropostaDocumentosAnexo = BC001O3_n415PropostaDocumentosAnexo[0];
            Z414PropostaDocumentosId = A414PropostaDocumentosId;
            sMode62 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1O62( ) ;
            if ( AnyError == 1 )
            {
               RcdFound62 = 0;
               InitializeNonKey1O62( ) ;
            }
            Gx_mode = sMode62;
         }
         else
         {
            RcdFound62 = 0;
            InitializeNonKey1O62( ) ;
            sMode62 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode62;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1O62( ) ;
         if ( RcdFound62 == 0 )
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
         CONFIRM_1O0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1O62( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001O2 */
            pr_default.execute(0, new Object[] {A414PropostaDocumentosId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PropostaDocumentos"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z416PropostaDocumentosAnexoName, BC001O2_A416PropostaDocumentosAnexoName[0]) != 0 ) || ( StringUtil.StrCmp(Z417PropostaDocumentosAnexoFileType, BC001O2_A417PropostaDocumentosAnexoFileType[0]) != 0 ) || ( StringUtil.StrCmp(Z579PropostaDocumentosStatus, BC001O2_A579PropostaDocumentosStatus[0]) != 0 ) || ( Z651PropostaDocumentosAdm != BC001O2_A651PropostaDocumentosAdm[0] ) || ( Z323PropostaId != BC001O2_A323PropostaId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z405DocumentosId != BC001O2_A405DocumentosId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PropostaDocumentos"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1O62( )
      {
         BeforeValidate1O62( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1O62( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1O62( 0) ;
            CheckOptimisticConcurrency1O62( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1O62( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1O62( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001O8 */
                     pr_default.execute(6, new Object[] {n415PropostaDocumentosAnexo, A415PropostaDocumentosAnexo, n416PropostaDocumentosAnexoName, A416PropostaDocumentosAnexoName, n417PropostaDocumentosAnexoFileType, A417PropostaDocumentosAnexoFileType, n579PropostaDocumentosStatus, A579PropostaDocumentosStatus, n651PropostaDocumentosAdm, A651PropostaDocumentosAdm, n323PropostaId, A323PropostaId, n405DocumentosId, A405DocumentosId});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC001O9 */
                     pr_default.execute(7);
                     A414PropostaDocumentosId = BC001O9_A414PropostaDocumentosId[0];
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("PropostaDocumentos");
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
               Load1O62( ) ;
            }
            EndLevel1O62( ) ;
         }
         CloseExtendedTableCursors1O62( ) ;
      }

      protected void Update1O62( )
      {
         BeforeValidate1O62( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1O62( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1O62( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1O62( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1O62( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001O10 */
                     pr_default.execute(8, new Object[] {n416PropostaDocumentosAnexoName, A416PropostaDocumentosAnexoName, n417PropostaDocumentosAnexoFileType, A417PropostaDocumentosAnexoFileType, n579PropostaDocumentosStatus, A579PropostaDocumentosStatus, n651PropostaDocumentosAdm, A651PropostaDocumentosAdm, n323PropostaId, A323PropostaId, n405DocumentosId, A405DocumentosId, A414PropostaDocumentosId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("PropostaDocumentos");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PropostaDocumentos"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1O62( ) ;
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
            EndLevel1O62( ) ;
         }
         CloseExtendedTableCursors1O62( ) ;
      }

      protected void DeferredUpdate1O62( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC001O11 */
            pr_default.execute(9, new Object[] {n415PropostaDocumentosAnexo, A415PropostaDocumentosAnexo, A414PropostaDocumentosId});
            pr_default.close(9);
            pr_default.SmartCacheProvider.SetUpdated("PropostaDocumentos");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1O62( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1O62( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1O62( ) ;
            AfterConfirm1O62( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1O62( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001O12 */
                  pr_default.execute(10, new Object[] {A414PropostaDocumentosId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("PropostaDocumentos");
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
         sMode62 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1O62( ) ;
         Gx_mode = sMode62;
      }

      protected void OnDeleteControls1O62( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001O13 */
            pr_default.execute(11, new Object[] {n405DocumentosId, A405DocumentosId});
            A406DocumentosDescricao = BC001O13_A406DocumentosDescricao[0];
            n406DocumentosDescricao = BC001O13_n406DocumentosDescricao[0];
            A407DocumentosStatus = BC001O13_A407DocumentosStatus[0];
            n407DocumentosStatus = BC001O13_n407DocumentosStatus[0];
            pr_default.close(11);
         }
      }

      protected void EndLevel1O62( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1O62( ) ;
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

      public void ScanKeyStart1O62( )
      {
         /* Using cursor BC001O14 */
         pr_default.execute(12, new Object[] {A414PropostaDocumentosId});
         RcdFound62 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound62 = 1;
            A414PropostaDocumentosId = BC001O14_A414PropostaDocumentosId[0];
            A406DocumentosDescricao = BC001O14_A406DocumentosDescricao[0];
            n406DocumentosDescricao = BC001O14_n406DocumentosDescricao[0];
            A407DocumentosStatus = BC001O14_A407DocumentosStatus[0];
            n407DocumentosStatus = BC001O14_n407DocumentosStatus[0];
            A416PropostaDocumentosAnexoName = BC001O14_A416PropostaDocumentosAnexoName[0];
            n416PropostaDocumentosAnexoName = BC001O14_n416PropostaDocumentosAnexoName[0];
            A417PropostaDocumentosAnexoFileType = BC001O14_A417PropostaDocumentosAnexoFileType[0];
            n417PropostaDocumentosAnexoFileType = BC001O14_n417PropostaDocumentosAnexoFileType[0];
            A579PropostaDocumentosStatus = BC001O14_A579PropostaDocumentosStatus[0];
            n579PropostaDocumentosStatus = BC001O14_n579PropostaDocumentosStatus[0];
            A651PropostaDocumentosAdm = BC001O14_A651PropostaDocumentosAdm[0];
            n651PropostaDocumentosAdm = BC001O14_n651PropostaDocumentosAdm[0];
            A323PropostaId = BC001O14_A323PropostaId[0];
            n323PropostaId = BC001O14_n323PropostaId[0];
            A405DocumentosId = BC001O14_A405DocumentosId[0];
            n405DocumentosId = BC001O14_n405DocumentosId[0];
            A415PropostaDocumentosAnexo = BC001O14_A415PropostaDocumentosAnexo[0];
            n415PropostaDocumentosAnexo = BC001O14_n415PropostaDocumentosAnexo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1O62( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound62 = 0;
         ScanKeyLoad1O62( ) ;
      }

      protected void ScanKeyLoad1O62( )
      {
         sMode62 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound62 = 1;
            A414PropostaDocumentosId = BC001O14_A414PropostaDocumentosId[0];
            A406DocumentosDescricao = BC001O14_A406DocumentosDescricao[0];
            n406DocumentosDescricao = BC001O14_n406DocumentosDescricao[0];
            A407DocumentosStatus = BC001O14_A407DocumentosStatus[0];
            n407DocumentosStatus = BC001O14_n407DocumentosStatus[0];
            A416PropostaDocumentosAnexoName = BC001O14_A416PropostaDocumentosAnexoName[0];
            n416PropostaDocumentosAnexoName = BC001O14_n416PropostaDocumentosAnexoName[0];
            A417PropostaDocumentosAnexoFileType = BC001O14_A417PropostaDocumentosAnexoFileType[0];
            n417PropostaDocumentosAnexoFileType = BC001O14_n417PropostaDocumentosAnexoFileType[0];
            A579PropostaDocumentosStatus = BC001O14_A579PropostaDocumentosStatus[0];
            n579PropostaDocumentosStatus = BC001O14_n579PropostaDocumentosStatus[0];
            A651PropostaDocumentosAdm = BC001O14_A651PropostaDocumentosAdm[0];
            n651PropostaDocumentosAdm = BC001O14_n651PropostaDocumentosAdm[0];
            A323PropostaId = BC001O14_A323PropostaId[0];
            n323PropostaId = BC001O14_n323PropostaId[0];
            A405DocumentosId = BC001O14_A405DocumentosId[0];
            n405DocumentosId = BC001O14_n405DocumentosId[0];
            A415PropostaDocumentosAnexo = BC001O14_A415PropostaDocumentosAnexo[0];
            n415PropostaDocumentosAnexo = BC001O14_n415PropostaDocumentosAnexo[0];
         }
         Gx_mode = sMode62;
      }

      protected void ScanKeyEnd1O62( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm1O62( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1O62( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1O62( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1O62( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1O62( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1O62( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1O62( )
      {
      }

      protected void send_integrity_lvl_hashes1O62( )
      {
      }

      protected void AddRow1O62( )
      {
         VarsToRow62( bcPropostaDocumentos) ;
      }

      protected void ReadRow1O62( )
      {
         RowToVars62( bcPropostaDocumentos, 1) ;
      }

      protected void InitializeNonKey1O62( )
      {
         A323PropostaId = 0;
         n323PropostaId = false;
         A405DocumentosId = 0;
         n405DocumentosId = false;
         A406DocumentosDescricao = "";
         n406DocumentosDescricao = false;
         A407DocumentosStatus = false;
         n407DocumentosStatus = false;
         A415PropostaDocumentosAnexo = "";
         n415PropostaDocumentosAnexo = false;
         A416PropostaDocumentosAnexoName = "";
         n416PropostaDocumentosAnexoName = false;
         A417PropostaDocumentosAnexoFileType = "";
         n417PropostaDocumentosAnexoFileType = false;
         A579PropostaDocumentosStatus = "";
         n579PropostaDocumentosStatus = false;
         A651PropostaDocumentosAdm = false;
         n651PropostaDocumentosAdm = false;
         Z416PropostaDocumentosAnexoName = "";
         Z417PropostaDocumentosAnexoFileType = "";
         Z579PropostaDocumentosStatus = "";
         Z651PropostaDocumentosAdm = false;
         Z323PropostaId = 0;
         Z405DocumentosId = 0;
      }

      protected void InitAll1O62( )
      {
         A414PropostaDocumentosId = 0;
         InitializeNonKey1O62( ) ;
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

      public void VarsToRow62( SdtPropostaDocumentos obj62 )
      {
         obj62.gxTpr_Mode = Gx_mode;
         obj62.gxTpr_Propostaid = A323PropostaId;
         obj62.gxTpr_Documentosid = A405DocumentosId;
         obj62.gxTpr_Documentosdescricao = A406DocumentosDescricao;
         obj62.gxTpr_Documentosstatus = A407DocumentosStatus;
         obj62.gxTpr_Propostadocumentosanexo = A415PropostaDocumentosAnexo;
         obj62.gxTpr_Propostadocumentosanexoname = A416PropostaDocumentosAnexoName;
         obj62.gxTpr_Propostadocumentosanexofiletype = A417PropostaDocumentosAnexoFileType;
         obj62.gxTpr_Propostadocumentosstatus = A579PropostaDocumentosStatus;
         obj62.gxTpr_Propostadocumentosadm = A651PropostaDocumentosAdm;
         obj62.gxTpr_Propostadocumentosid = A414PropostaDocumentosId;
         obj62.gxTpr_Propostadocumentosid_Z = Z414PropostaDocumentosId;
         obj62.gxTpr_Propostaid_Z = Z323PropostaId;
         obj62.gxTpr_Documentosid_Z = Z405DocumentosId;
         obj62.gxTpr_Documentosdescricao_Z = Z406DocumentosDescricao;
         obj62.gxTpr_Documentosstatus_Z = Z407DocumentosStatus;
         obj62.gxTpr_Propostadocumentosanexoname_Z = Z416PropostaDocumentosAnexoName;
         obj62.gxTpr_Propostadocumentosanexofiletype_Z = Z417PropostaDocumentosAnexoFileType;
         obj62.gxTpr_Propostadocumentosstatus_Z = Z579PropostaDocumentosStatus;
         obj62.gxTpr_Propostadocumentosadm_Z = Z651PropostaDocumentosAdm;
         obj62.gxTpr_Propostaid_N = (short)(Convert.ToInt16(n323PropostaId));
         obj62.gxTpr_Documentosid_N = (short)(Convert.ToInt16(n405DocumentosId));
         obj62.gxTpr_Documentosdescricao_N = (short)(Convert.ToInt16(n406DocumentosDescricao));
         obj62.gxTpr_Documentosstatus_N = (short)(Convert.ToInt16(n407DocumentosStatus));
         obj62.gxTpr_Propostadocumentosanexo_N = (short)(Convert.ToInt16(n415PropostaDocumentosAnexo));
         obj62.gxTpr_Propostadocumentosanexoname_N = (short)(Convert.ToInt16(n416PropostaDocumentosAnexoName));
         obj62.gxTpr_Propostadocumentosanexofiletype_N = (short)(Convert.ToInt16(n417PropostaDocumentosAnexoFileType));
         obj62.gxTpr_Propostadocumentosstatus_N = (short)(Convert.ToInt16(n579PropostaDocumentosStatus));
         obj62.gxTpr_Propostadocumentosadm_N = (short)(Convert.ToInt16(n651PropostaDocumentosAdm));
         obj62.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow62( SdtPropostaDocumentos obj62 )
      {
         obj62.gxTpr_Propostadocumentosid = A414PropostaDocumentosId;
         return  ;
      }

      public void RowToVars62( SdtPropostaDocumentos obj62 ,
                               int forceLoad )
      {
         Gx_mode = obj62.gxTpr_Mode;
         A323PropostaId = obj62.gxTpr_Propostaid;
         n323PropostaId = false;
         A405DocumentosId = obj62.gxTpr_Documentosid;
         n405DocumentosId = false;
         A406DocumentosDescricao = obj62.gxTpr_Documentosdescricao;
         n406DocumentosDescricao = false;
         A407DocumentosStatus = obj62.gxTpr_Documentosstatus;
         n407DocumentosStatus = false;
         A415PropostaDocumentosAnexo = obj62.gxTpr_Propostadocumentosanexo;
         n415PropostaDocumentosAnexo = false;
         A416PropostaDocumentosAnexoName = obj62.gxTpr_Propostadocumentosanexoname;
         n416PropostaDocumentosAnexoName = false;
         A417PropostaDocumentosAnexoFileType = obj62.gxTpr_Propostadocumentosanexofiletype;
         n417PropostaDocumentosAnexoFileType = false;
         A579PropostaDocumentosStatus = obj62.gxTpr_Propostadocumentosstatus;
         n579PropostaDocumentosStatus = false;
         A651PropostaDocumentosAdm = obj62.gxTpr_Propostadocumentosadm;
         n651PropostaDocumentosAdm = false;
         A414PropostaDocumentosId = obj62.gxTpr_Propostadocumentosid;
         Z414PropostaDocumentosId = obj62.gxTpr_Propostadocumentosid_Z;
         Z323PropostaId = obj62.gxTpr_Propostaid_Z;
         Z405DocumentosId = obj62.gxTpr_Documentosid_Z;
         Z406DocumentosDescricao = obj62.gxTpr_Documentosdescricao_Z;
         Z407DocumentosStatus = obj62.gxTpr_Documentosstatus_Z;
         Z416PropostaDocumentosAnexoName = obj62.gxTpr_Propostadocumentosanexoname_Z;
         Z417PropostaDocumentosAnexoFileType = obj62.gxTpr_Propostadocumentosanexofiletype_Z;
         Z579PropostaDocumentosStatus = obj62.gxTpr_Propostadocumentosstatus_Z;
         Z651PropostaDocumentosAdm = obj62.gxTpr_Propostadocumentosadm_Z;
         n323PropostaId = (bool)(Convert.ToBoolean(obj62.gxTpr_Propostaid_N));
         n405DocumentosId = (bool)(Convert.ToBoolean(obj62.gxTpr_Documentosid_N));
         n406DocumentosDescricao = (bool)(Convert.ToBoolean(obj62.gxTpr_Documentosdescricao_N));
         n407DocumentosStatus = (bool)(Convert.ToBoolean(obj62.gxTpr_Documentosstatus_N));
         n415PropostaDocumentosAnexo = (bool)(Convert.ToBoolean(obj62.gxTpr_Propostadocumentosanexo_N));
         n416PropostaDocumentosAnexoName = (bool)(Convert.ToBoolean(obj62.gxTpr_Propostadocumentosanexoname_N));
         n417PropostaDocumentosAnexoFileType = (bool)(Convert.ToBoolean(obj62.gxTpr_Propostadocumentosanexofiletype_N));
         n579PropostaDocumentosStatus = (bool)(Convert.ToBoolean(obj62.gxTpr_Propostadocumentosstatus_N));
         n651PropostaDocumentosAdm = (bool)(Convert.ToBoolean(obj62.gxTpr_Propostadocumentosadm_N));
         Gx_mode = obj62.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A414PropostaDocumentosId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1O62( ) ;
         ScanKeyStart1O62( ) ;
         if ( RcdFound62 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z414PropostaDocumentosId = A414PropostaDocumentosId;
         }
         ZM1O62( -2) ;
         OnLoadActions1O62( ) ;
         AddRow1O62( ) ;
         ScanKeyEnd1O62( ) ;
         if ( RcdFound62 == 0 )
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
         RowToVars62( bcPropostaDocumentos, 0) ;
         ScanKeyStart1O62( ) ;
         if ( RcdFound62 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z414PropostaDocumentosId = A414PropostaDocumentosId;
         }
         ZM1O62( -2) ;
         OnLoadActions1O62( ) ;
         AddRow1O62( ) ;
         ScanKeyEnd1O62( ) ;
         if ( RcdFound62 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1O62( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1O62( ) ;
         }
         else
         {
            if ( RcdFound62 == 1 )
            {
               if ( A414PropostaDocumentosId != Z414PropostaDocumentosId )
               {
                  A414PropostaDocumentosId = Z414PropostaDocumentosId;
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
                  Update1O62( ) ;
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
                  if ( A414PropostaDocumentosId != Z414PropostaDocumentosId )
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
                        Insert1O62( ) ;
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
                        Insert1O62( ) ;
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
         RowToVars62( bcPropostaDocumentos, 1) ;
         SaveImpl( ) ;
         VarsToRow62( bcPropostaDocumentos) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars62( bcPropostaDocumentos, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1O62( ) ;
         AfterTrn( ) ;
         VarsToRow62( bcPropostaDocumentos) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow62( bcPropostaDocumentos) ;
         }
         else
         {
            SdtPropostaDocumentos auxBC = new SdtPropostaDocumentos(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A414PropostaDocumentosId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcPropostaDocumentos);
               auxBC.Save();
               bcPropostaDocumentos.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars62( bcPropostaDocumentos, 1) ;
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
         RowToVars62( bcPropostaDocumentos, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1O62( ) ;
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
               VarsToRow62( bcPropostaDocumentos) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow62( bcPropostaDocumentos) ;
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
         RowToVars62( bcPropostaDocumentos, 0) ;
         GetKey1O62( ) ;
         if ( RcdFound62 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A414PropostaDocumentosId != Z414PropostaDocumentosId )
            {
               A414PropostaDocumentosId = Z414PropostaDocumentosId;
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
            if ( A414PropostaDocumentosId != Z414PropostaDocumentosId )
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
         context.RollbackDataStores("propostadocumentos_bc",pr_default);
         VarsToRow62( bcPropostaDocumentos) ;
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
         Gx_mode = bcPropostaDocumentos.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcPropostaDocumentos.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcPropostaDocumentos )
         {
            bcPropostaDocumentos = (SdtPropostaDocumentos)(sdt);
            if ( StringUtil.StrCmp(bcPropostaDocumentos.gxTpr_Mode, "") == 0 )
            {
               bcPropostaDocumentos.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow62( bcPropostaDocumentos) ;
            }
            else
            {
               RowToVars62( bcPropostaDocumentos, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcPropostaDocumentos.gxTpr_Mode, "") == 0 )
            {
               bcPropostaDocumentos.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars62( bcPropostaDocumentos, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtPropostaDocumentos PropostaDocumentos_BC
      {
         get {
            return bcPropostaDocumentos ;
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
         pr_default.close(11);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z416PropostaDocumentosAnexoName = "";
         A416PropostaDocumentosAnexoName = "";
         Z417PropostaDocumentosAnexoFileType = "";
         A417PropostaDocumentosAnexoFileType = "";
         Z579PropostaDocumentosStatus = "";
         A579PropostaDocumentosStatus = "";
         Z406DocumentosDescricao = "";
         A406DocumentosDescricao = "";
         Z415PropostaDocumentosAnexo = "";
         A415PropostaDocumentosAnexo = "";
         BC001O6_A414PropostaDocumentosId = new int[1] ;
         BC001O6_A406DocumentosDescricao = new string[] {""} ;
         BC001O6_n406DocumentosDescricao = new bool[] {false} ;
         BC001O6_A407DocumentosStatus = new bool[] {false} ;
         BC001O6_n407DocumentosStatus = new bool[] {false} ;
         BC001O6_A416PropostaDocumentosAnexoName = new string[] {""} ;
         BC001O6_n416PropostaDocumentosAnexoName = new bool[] {false} ;
         BC001O6_A417PropostaDocumentosAnexoFileType = new string[] {""} ;
         BC001O6_n417PropostaDocumentosAnexoFileType = new bool[] {false} ;
         BC001O6_A579PropostaDocumentosStatus = new string[] {""} ;
         BC001O6_n579PropostaDocumentosStatus = new bool[] {false} ;
         BC001O6_A651PropostaDocumentosAdm = new bool[] {false} ;
         BC001O6_n651PropostaDocumentosAdm = new bool[] {false} ;
         BC001O6_A323PropostaId = new int[1] ;
         BC001O6_n323PropostaId = new bool[] {false} ;
         BC001O6_A405DocumentosId = new int[1] ;
         BC001O6_n405DocumentosId = new bool[] {false} ;
         BC001O6_A415PropostaDocumentosAnexo = new string[] {""} ;
         BC001O6_n415PropostaDocumentosAnexo = new bool[] {false} ;
         BC001O4_A323PropostaId = new int[1] ;
         BC001O4_n323PropostaId = new bool[] {false} ;
         BC001O5_A406DocumentosDescricao = new string[] {""} ;
         BC001O5_n406DocumentosDescricao = new bool[] {false} ;
         BC001O5_A407DocumentosStatus = new bool[] {false} ;
         BC001O5_n407DocumentosStatus = new bool[] {false} ;
         BC001O7_A414PropostaDocumentosId = new int[1] ;
         BC001O3_A414PropostaDocumentosId = new int[1] ;
         BC001O3_A416PropostaDocumentosAnexoName = new string[] {""} ;
         BC001O3_n416PropostaDocumentosAnexoName = new bool[] {false} ;
         BC001O3_A417PropostaDocumentosAnexoFileType = new string[] {""} ;
         BC001O3_n417PropostaDocumentosAnexoFileType = new bool[] {false} ;
         BC001O3_A579PropostaDocumentosStatus = new string[] {""} ;
         BC001O3_n579PropostaDocumentosStatus = new bool[] {false} ;
         BC001O3_A651PropostaDocumentosAdm = new bool[] {false} ;
         BC001O3_n651PropostaDocumentosAdm = new bool[] {false} ;
         BC001O3_A323PropostaId = new int[1] ;
         BC001O3_n323PropostaId = new bool[] {false} ;
         BC001O3_A405DocumentosId = new int[1] ;
         BC001O3_n405DocumentosId = new bool[] {false} ;
         BC001O3_A415PropostaDocumentosAnexo = new string[] {""} ;
         BC001O3_n415PropostaDocumentosAnexo = new bool[] {false} ;
         sMode62 = "";
         BC001O2_A414PropostaDocumentosId = new int[1] ;
         BC001O2_A416PropostaDocumentosAnexoName = new string[] {""} ;
         BC001O2_n416PropostaDocumentosAnexoName = new bool[] {false} ;
         BC001O2_A417PropostaDocumentosAnexoFileType = new string[] {""} ;
         BC001O2_n417PropostaDocumentosAnexoFileType = new bool[] {false} ;
         BC001O2_A579PropostaDocumentosStatus = new string[] {""} ;
         BC001O2_n579PropostaDocumentosStatus = new bool[] {false} ;
         BC001O2_A651PropostaDocumentosAdm = new bool[] {false} ;
         BC001O2_n651PropostaDocumentosAdm = new bool[] {false} ;
         BC001O2_A323PropostaId = new int[1] ;
         BC001O2_n323PropostaId = new bool[] {false} ;
         BC001O2_A405DocumentosId = new int[1] ;
         BC001O2_n405DocumentosId = new bool[] {false} ;
         BC001O2_A415PropostaDocumentosAnexo = new string[] {""} ;
         BC001O2_n415PropostaDocumentosAnexo = new bool[] {false} ;
         BC001O9_A414PropostaDocumentosId = new int[1] ;
         BC001O13_A406DocumentosDescricao = new string[] {""} ;
         BC001O13_n406DocumentosDescricao = new bool[] {false} ;
         BC001O13_A407DocumentosStatus = new bool[] {false} ;
         BC001O13_n407DocumentosStatus = new bool[] {false} ;
         BC001O14_A414PropostaDocumentosId = new int[1] ;
         BC001O14_A406DocumentosDescricao = new string[] {""} ;
         BC001O14_n406DocumentosDescricao = new bool[] {false} ;
         BC001O14_A407DocumentosStatus = new bool[] {false} ;
         BC001O14_n407DocumentosStatus = new bool[] {false} ;
         BC001O14_A416PropostaDocumentosAnexoName = new string[] {""} ;
         BC001O14_n416PropostaDocumentosAnexoName = new bool[] {false} ;
         BC001O14_A417PropostaDocumentosAnexoFileType = new string[] {""} ;
         BC001O14_n417PropostaDocumentosAnexoFileType = new bool[] {false} ;
         BC001O14_A579PropostaDocumentosStatus = new string[] {""} ;
         BC001O14_n579PropostaDocumentosStatus = new bool[] {false} ;
         BC001O14_A651PropostaDocumentosAdm = new bool[] {false} ;
         BC001O14_n651PropostaDocumentosAdm = new bool[] {false} ;
         BC001O14_A323PropostaId = new int[1] ;
         BC001O14_n323PropostaId = new bool[] {false} ;
         BC001O14_A405DocumentosId = new int[1] ;
         BC001O14_n405DocumentosId = new bool[] {false} ;
         BC001O14_A415PropostaDocumentosAnexo = new string[] {""} ;
         BC001O14_n415PropostaDocumentosAnexo = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.propostadocumentos_bc__default(),
            new Object[][] {
                new Object[] {
               BC001O2_A414PropostaDocumentosId, BC001O2_A416PropostaDocumentosAnexoName, BC001O2_n416PropostaDocumentosAnexoName, BC001O2_A417PropostaDocumentosAnexoFileType, BC001O2_n417PropostaDocumentosAnexoFileType, BC001O2_A579PropostaDocumentosStatus, BC001O2_n579PropostaDocumentosStatus, BC001O2_A651PropostaDocumentosAdm, BC001O2_n651PropostaDocumentosAdm, BC001O2_A323PropostaId,
               BC001O2_n323PropostaId, BC001O2_A405DocumentosId, BC001O2_n405DocumentosId, BC001O2_A415PropostaDocumentosAnexo, BC001O2_n415PropostaDocumentosAnexo
               }
               , new Object[] {
               BC001O3_A414PropostaDocumentosId, BC001O3_A416PropostaDocumentosAnexoName, BC001O3_n416PropostaDocumentosAnexoName, BC001O3_A417PropostaDocumentosAnexoFileType, BC001O3_n417PropostaDocumentosAnexoFileType, BC001O3_A579PropostaDocumentosStatus, BC001O3_n579PropostaDocumentosStatus, BC001O3_A651PropostaDocumentosAdm, BC001O3_n651PropostaDocumentosAdm, BC001O3_A323PropostaId,
               BC001O3_n323PropostaId, BC001O3_A405DocumentosId, BC001O3_n405DocumentosId, BC001O3_A415PropostaDocumentosAnexo, BC001O3_n415PropostaDocumentosAnexo
               }
               , new Object[] {
               BC001O4_A323PropostaId
               }
               , new Object[] {
               BC001O5_A406DocumentosDescricao, BC001O5_n406DocumentosDescricao, BC001O5_A407DocumentosStatus, BC001O5_n407DocumentosStatus
               }
               , new Object[] {
               BC001O6_A414PropostaDocumentosId, BC001O6_A406DocumentosDescricao, BC001O6_n406DocumentosDescricao, BC001O6_A407DocumentosStatus, BC001O6_n407DocumentosStatus, BC001O6_A416PropostaDocumentosAnexoName, BC001O6_n416PropostaDocumentosAnexoName, BC001O6_A417PropostaDocumentosAnexoFileType, BC001O6_n417PropostaDocumentosAnexoFileType, BC001O6_A579PropostaDocumentosStatus,
               BC001O6_n579PropostaDocumentosStatus, BC001O6_A651PropostaDocumentosAdm, BC001O6_n651PropostaDocumentosAdm, BC001O6_A323PropostaId, BC001O6_n323PropostaId, BC001O6_A405DocumentosId, BC001O6_n405DocumentosId, BC001O6_A415PropostaDocumentosAnexo, BC001O6_n415PropostaDocumentosAnexo
               }
               , new Object[] {
               BC001O7_A414PropostaDocumentosId
               }
               , new Object[] {
               }
               , new Object[] {
               BC001O9_A414PropostaDocumentosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001O13_A406DocumentosDescricao, BC001O13_n406DocumentosDescricao, BC001O13_A407DocumentosStatus, BC001O13_n407DocumentosStatus
               }
               , new Object[] {
               BC001O14_A414PropostaDocumentosId, BC001O14_A406DocumentosDescricao, BC001O14_n406DocumentosDescricao, BC001O14_A407DocumentosStatus, BC001O14_n407DocumentosStatus, BC001O14_A416PropostaDocumentosAnexoName, BC001O14_n416PropostaDocumentosAnexoName, BC001O14_A417PropostaDocumentosAnexoFileType, BC001O14_n417PropostaDocumentosAnexoFileType, BC001O14_A579PropostaDocumentosStatus,
               BC001O14_n579PropostaDocumentosStatus, BC001O14_A651PropostaDocumentosAdm, BC001O14_n651PropostaDocumentosAdm, BC001O14_A323PropostaId, BC001O14_n323PropostaId, BC001O14_A405DocumentosId, BC001O14_n405DocumentosId, BC001O14_A415PropostaDocumentosAnexo, BC001O14_n415PropostaDocumentosAnexo
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound62 ;
      private int trnEnded ;
      private int Z414PropostaDocumentosId ;
      private int A414PropostaDocumentosId ;
      private int Z323PropostaId ;
      private int A323PropostaId ;
      private int Z405DocumentosId ;
      private int A405DocumentosId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode62 ;
      private bool Z651PropostaDocumentosAdm ;
      private bool A651PropostaDocumentosAdm ;
      private bool Z407DocumentosStatus ;
      private bool A407DocumentosStatus ;
      private bool n406DocumentosDescricao ;
      private bool n407DocumentosStatus ;
      private bool n416PropostaDocumentosAnexoName ;
      private bool n417PropostaDocumentosAnexoFileType ;
      private bool n579PropostaDocumentosStatus ;
      private bool n651PropostaDocumentosAdm ;
      private bool n323PropostaId ;
      private bool n405DocumentosId ;
      private bool n415PropostaDocumentosAnexo ;
      private bool Gx_longc ;
      private string Z416PropostaDocumentosAnexoName ;
      private string A416PropostaDocumentosAnexoName ;
      private string Z417PropostaDocumentosAnexoFileType ;
      private string A417PropostaDocumentosAnexoFileType ;
      private string Z579PropostaDocumentosStatus ;
      private string A579PropostaDocumentosStatus ;
      private string Z406DocumentosDescricao ;
      private string A406DocumentosDescricao ;
      private string Z415PropostaDocumentosAnexo ;
      private string A415PropostaDocumentosAnexo ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC001O6_A414PropostaDocumentosId ;
      private string[] BC001O6_A406DocumentosDescricao ;
      private bool[] BC001O6_n406DocumentosDescricao ;
      private bool[] BC001O6_A407DocumentosStatus ;
      private bool[] BC001O6_n407DocumentosStatus ;
      private string[] BC001O6_A416PropostaDocumentosAnexoName ;
      private bool[] BC001O6_n416PropostaDocumentosAnexoName ;
      private string[] BC001O6_A417PropostaDocumentosAnexoFileType ;
      private bool[] BC001O6_n417PropostaDocumentosAnexoFileType ;
      private string[] BC001O6_A579PropostaDocumentosStatus ;
      private bool[] BC001O6_n579PropostaDocumentosStatus ;
      private bool[] BC001O6_A651PropostaDocumentosAdm ;
      private bool[] BC001O6_n651PropostaDocumentosAdm ;
      private int[] BC001O6_A323PropostaId ;
      private bool[] BC001O6_n323PropostaId ;
      private int[] BC001O6_A405DocumentosId ;
      private bool[] BC001O6_n405DocumentosId ;
      private string[] BC001O6_A415PropostaDocumentosAnexo ;
      private bool[] BC001O6_n415PropostaDocumentosAnexo ;
      private int[] BC001O4_A323PropostaId ;
      private bool[] BC001O4_n323PropostaId ;
      private string[] BC001O5_A406DocumentosDescricao ;
      private bool[] BC001O5_n406DocumentosDescricao ;
      private bool[] BC001O5_A407DocumentosStatus ;
      private bool[] BC001O5_n407DocumentosStatus ;
      private int[] BC001O7_A414PropostaDocumentosId ;
      private int[] BC001O3_A414PropostaDocumentosId ;
      private string[] BC001O3_A416PropostaDocumentosAnexoName ;
      private bool[] BC001O3_n416PropostaDocumentosAnexoName ;
      private string[] BC001O3_A417PropostaDocumentosAnexoFileType ;
      private bool[] BC001O3_n417PropostaDocumentosAnexoFileType ;
      private string[] BC001O3_A579PropostaDocumentosStatus ;
      private bool[] BC001O3_n579PropostaDocumentosStatus ;
      private bool[] BC001O3_A651PropostaDocumentosAdm ;
      private bool[] BC001O3_n651PropostaDocumentosAdm ;
      private int[] BC001O3_A323PropostaId ;
      private bool[] BC001O3_n323PropostaId ;
      private int[] BC001O3_A405DocumentosId ;
      private bool[] BC001O3_n405DocumentosId ;
      private string[] BC001O3_A415PropostaDocumentosAnexo ;
      private bool[] BC001O3_n415PropostaDocumentosAnexo ;
      private int[] BC001O2_A414PropostaDocumentosId ;
      private string[] BC001O2_A416PropostaDocumentosAnexoName ;
      private bool[] BC001O2_n416PropostaDocumentosAnexoName ;
      private string[] BC001O2_A417PropostaDocumentosAnexoFileType ;
      private bool[] BC001O2_n417PropostaDocumentosAnexoFileType ;
      private string[] BC001O2_A579PropostaDocumentosStatus ;
      private bool[] BC001O2_n579PropostaDocumentosStatus ;
      private bool[] BC001O2_A651PropostaDocumentosAdm ;
      private bool[] BC001O2_n651PropostaDocumentosAdm ;
      private int[] BC001O2_A323PropostaId ;
      private bool[] BC001O2_n323PropostaId ;
      private int[] BC001O2_A405DocumentosId ;
      private bool[] BC001O2_n405DocumentosId ;
      private string[] BC001O2_A415PropostaDocumentosAnexo ;
      private bool[] BC001O2_n415PropostaDocumentosAnexo ;
      private int[] BC001O9_A414PropostaDocumentosId ;
      private string[] BC001O13_A406DocumentosDescricao ;
      private bool[] BC001O13_n406DocumentosDescricao ;
      private bool[] BC001O13_A407DocumentosStatus ;
      private bool[] BC001O13_n407DocumentosStatus ;
      private int[] BC001O14_A414PropostaDocumentosId ;
      private string[] BC001O14_A406DocumentosDescricao ;
      private bool[] BC001O14_n406DocumentosDescricao ;
      private bool[] BC001O14_A407DocumentosStatus ;
      private bool[] BC001O14_n407DocumentosStatus ;
      private string[] BC001O14_A416PropostaDocumentosAnexoName ;
      private bool[] BC001O14_n416PropostaDocumentosAnexoName ;
      private string[] BC001O14_A417PropostaDocumentosAnexoFileType ;
      private bool[] BC001O14_n417PropostaDocumentosAnexoFileType ;
      private string[] BC001O14_A579PropostaDocumentosStatus ;
      private bool[] BC001O14_n579PropostaDocumentosStatus ;
      private bool[] BC001O14_A651PropostaDocumentosAdm ;
      private bool[] BC001O14_n651PropostaDocumentosAdm ;
      private int[] BC001O14_A323PropostaId ;
      private bool[] BC001O14_n323PropostaId ;
      private int[] BC001O14_A405DocumentosId ;
      private bool[] BC001O14_n405DocumentosId ;
      private string[] BC001O14_A415PropostaDocumentosAnexo ;
      private bool[] BC001O14_n415PropostaDocumentosAnexo ;
      private SdtPropostaDocumentos bcPropostaDocumentos ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class propostadocumentos_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC001O2;
          prmBC001O2 = new Object[] {
          new ParDef("PropostaDocumentosId",GXType.Int32,9,0)
          };
          Object[] prmBC001O3;
          prmBC001O3 = new Object[] {
          new ParDef("PropostaDocumentosId",GXType.Int32,9,0)
          };
          Object[] prmBC001O4;
          prmBC001O4 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001O5;
          prmBC001O5 = new Object[] {
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001O6;
          prmBC001O6 = new Object[] {
          new ParDef("PropostaDocumentosId",GXType.Int32,9,0)
          };
          Object[] prmBC001O7;
          prmBC001O7 = new Object[] {
          new ParDef("PropostaDocumentosId",GXType.Int32,9,0)
          };
          Object[] prmBC001O8;
          prmBC001O8 = new Object[] {
          new ParDef("PropostaDocumentosAnexo",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("PropostaDocumentosAnexoName",GXType.VarChar,128,0){Nullable=true} ,
          new ParDef("PropostaDocumentosAnexoFileType",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("PropostaDocumentosStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("PropostaDocumentosAdm",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001O9;
          prmBC001O9 = new Object[] {
          };
          Object[] prmBC001O10;
          prmBC001O10 = new Object[] {
          new ParDef("PropostaDocumentosAnexoName",GXType.VarChar,128,0){Nullable=true} ,
          new ParDef("PropostaDocumentosAnexoFileType",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("PropostaDocumentosStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("PropostaDocumentosAdm",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaDocumentosId",GXType.Int32,9,0)
          };
          Object[] prmBC001O11;
          prmBC001O11 = new Object[] {
          new ParDef("PropostaDocumentosAnexo",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("PropostaDocumentosId",GXType.Int32,9,0)
          };
          Object[] prmBC001O12;
          prmBC001O12 = new Object[] {
          new ParDef("PropostaDocumentosId",GXType.Int32,9,0)
          };
          Object[] prmBC001O13;
          prmBC001O13 = new Object[] {
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001O14;
          prmBC001O14 = new Object[] {
          new ParDef("PropostaDocumentosId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC001O2", "SELECT PropostaDocumentosId, PropostaDocumentosAnexoName, PropostaDocumentosAnexoFileType, PropostaDocumentosStatus, PropostaDocumentosAdm, PropostaId, DocumentosId, PropostaDocumentosAnexo FROM PropostaDocumentos WHERE PropostaDocumentosId = :PropostaDocumentosId  FOR UPDATE OF PropostaDocumentos",true, GxErrorMask.GX_NOMASK, false, this,prmBC001O2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001O3", "SELECT PropostaDocumentosId, PropostaDocumentosAnexoName, PropostaDocumentosAnexoFileType, PropostaDocumentosStatus, PropostaDocumentosAdm, PropostaId, DocumentosId, PropostaDocumentosAnexo FROM PropostaDocumentos WHERE PropostaDocumentosId = :PropostaDocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001O3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001O4", "SELECT PropostaId FROM Proposta WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001O4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001O5", "SELECT DocumentosDescricao, DocumentosStatus FROM Documentos WHERE DocumentosId = :DocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001O5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001O6", "SELECT TM1.PropostaDocumentosId, T2.DocumentosDescricao, T2.DocumentosStatus, TM1.PropostaDocumentosAnexoName, TM1.PropostaDocumentosAnexoFileType, TM1.PropostaDocumentosStatus, TM1.PropostaDocumentosAdm, TM1.PropostaId, TM1.DocumentosId, TM1.PropostaDocumentosAnexo FROM (PropostaDocumentos TM1 LEFT JOIN Documentos T2 ON T2.DocumentosId = TM1.DocumentosId) WHERE TM1.PropostaDocumentosId = :PropostaDocumentosId ORDER BY TM1.PropostaDocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001O6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001O7", "SELECT PropostaDocumentosId FROM PropostaDocumentos WHERE PropostaDocumentosId = :PropostaDocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001O7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001O8", "SAVEPOINT gxupdate;INSERT INTO PropostaDocumentos(PropostaDocumentosAnexo, PropostaDocumentosAnexoName, PropostaDocumentosAnexoFileType, PropostaDocumentosStatus, PropostaDocumentosAdm, PropostaId, DocumentosId) VALUES(:PropostaDocumentosAnexo, :PropostaDocumentosAnexoName, :PropostaDocumentosAnexoFileType, :PropostaDocumentosStatus, :PropostaDocumentosAdm, :PropostaId, :DocumentosId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001O8)
             ,new CursorDef("BC001O9", "SELECT currval('PropostaDocumentosId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001O9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001O10", "SAVEPOINT gxupdate;UPDATE PropostaDocumentos SET PropostaDocumentosAnexoName=:PropostaDocumentosAnexoName, PropostaDocumentosAnexoFileType=:PropostaDocumentosAnexoFileType, PropostaDocumentosStatus=:PropostaDocumentosStatus, PropostaDocumentosAdm=:PropostaDocumentosAdm, PropostaId=:PropostaId, DocumentosId=:DocumentosId  WHERE PropostaDocumentosId = :PropostaDocumentosId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001O10)
             ,new CursorDef("BC001O11", "SAVEPOINT gxupdate;UPDATE PropostaDocumentos SET PropostaDocumentosAnexo=:PropostaDocumentosAnexo  WHERE PropostaDocumentosId = :PropostaDocumentosId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001O11)
             ,new CursorDef("BC001O12", "SAVEPOINT gxupdate;DELETE FROM PropostaDocumentos  WHERE PropostaDocumentosId = :PropostaDocumentosId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001O12)
             ,new CursorDef("BC001O13", "SELECT DocumentosDescricao, DocumentosStatus FROM Documentos WHERE DocumentosId = :DocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001O13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001O14", "SELECT TM1.PropostaDocumentosId, T2.DocumentosDescricao, T2.DocumentosStatus, TM1.PropostaDocumentosAnexoName, TM1.PropostaDocumentosAnexoFileType, TM1.PropostaDocumentosStatus, TM1.PropostaDocumentosAdm, TM1.PropostaId, TM1.DocumentosId, TM1.PropostaDocumentosAnexo FROM (PropostaDocumentos TM1 LEFT JOIN Documentos T2 ON T2.DocumentosId = TM1.DocumentosId) WHERE TM1.PropostaDocumentosId = :PropostaDocumentosId ORDER BY TM1.PropostaDocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001O14,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getBLOBFile(8, "tmp", "");
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getBLOBFile(8, "tmp", "");
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getBLOBFile(10, "tmp", "");
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getBLOBFile(10, "tmp", "");
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                return;
       }
    }

 }

}
