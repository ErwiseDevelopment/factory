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
   public class reembolsodocumento_bc : GxSilentTrn, IGxSilentTrn
   {
      public reembolsodocumento_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public reembolsodocumento_bc( IGxContext context )
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
         ReadRow2174( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2174( ) ;
         standaloneModal( ) ;
         AddRow2174( ) ;
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
               Z529ReembolsoDocumentoId = A529ReembolsoDocumentoId;
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

      protected void CONFIRM_210( )
      {
         BeforeValidate2174( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2174( ) ;
            }
            else
            {
               CheckExtendedTable2174( ) ;
               if ( AnyError == 0 )
               {
                  ZM2174( 4) ;
                  ZM2174( 5) ;
               }
               CloseExtendedTableCursors2174( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM2174( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z530ReembolsoDocumentoNome = A530ReembolsoDocumentoNome;
            Z532ReembolsoDocumentoBlobExt = A532ReembolsoDocumentoBlobExt;
            Z533ReembolsoDocumentoCreatedAt = A533ReembolsoDocumentoCreatedAt;
            Z549ReembolsoDocumentoStatus = A549ReembolsoDocumentoStatus;
            Z526ReembolsoEtapaId = A526ReembolsoEtapaId;
            Z405DocumentosId = A405DocumentosId;
         }
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -3 )
         {
            Z529ReembolsoDocumentoId = A529ReembolsoDocumentoId;
            Z530ReembolsoDocumentoNome = A530ReembolsoDocumentoNome;
            Z531ReembolsoDocumentoBlob = A531ReembolsoDocumentoBlob;
            Z532ReembolsoDocumentoBlobExt = A532ReembolsoDocumentoBlobExt;
            Z533ReembolsoDocumentoCreatedAt = A533ReembolsoDocumentoCreatedAt;
            Z549ReembolsoDocumentoStatus = A549ReembolsoDocumentoStatus;
            Z526ReembolsoEtapaId = A526ReembolsoEtapaId;
            Z405DocumentosId = A405DocumentosId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A533ReembolsoDocumentoCreatedAt) && ( Gx_BScreen == 0 ) )
         {
            A533ReembolsoDocumentoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n533ReembolsoDocumentoCreatedAt = false;
         }
      }

      protected void Load2174( )
      {
         /* Using cursor BC00216 */
         pr_default.execute(4, new Object[] {A529ReembolsoDocumentoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound74 = 1;
            A530ReembolsoDocumentoNome = BC00216_A530ReembolsoDocumentoNome[0];
            n530ReembolsoDocumentoNome = BC00216_n530ReembolsoDocumentoNome[0];
            A532ReembolsoDocumentoBlobExt = BC00216_A532ReembolsoDocumentoBlobExt[0];
            n532ReembolsoDocumentoBlobExt = BC00216_n532ReembolsoDocumentoBlobExt[0];
            A533ReembolsoDocumentoCreatedAt = BC00216_A533ReembolsoDocumentoCreatedAt[0];
            n533ReembolsoDocumentoCreatedAt = BC00216_n533ReembolsoDocumentoCreatedAt[0];
            A549ReembolsoDocumentoStatus = BC00216_A549ReembolsoDocumentoStatus[0];
            n549ReembolsoDocumentoStatus = BC00216_n549ReembolsoDocumentoStatus[0];
            A526ReembolsoEtapaId = BC00216_A526ReembolsoEtapaId[0];
            n526ReembolsoEtapaId = BC00216_n526ReembolsoEtapaId[0];
            A405DocumentosId = BC00216_A405DocumentosId[0];
            n405DocumentosId = BC00216_n405DocumentosId[0];
            A531ReembolsoDocumentoBlob = BC00216_A531ReembolsoDocumentoBlob[0];
            n531ReembolsoDocumentoBlob = BC00216_n531ReembolsoDocumentoBlob[0];
            ZM2174( -3) ;
         }
         pr_default.close(4);
         OnLoadActions2174( ) ;
      }

      protected void OnLoadActions2174( )
      {
      }

      protected void CheckExtendedTable2174( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00214 */
         pr_default.execute(2, new Object[] {n526ReembolsoEtapaId, A526ReembolsoEtapaId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A526ReembolsoEtapaId) ) )
            {
               GX_msglist.addItem("Não existe 'ReembolsoEtapa'.", "ForeignKeyNotFound", 1, "REEMBOLSOETAPAID");
               AnyError = 1;
            }
         }
         pr_default.close(2);
         /* Using cursor BC00215 */
         pr_default.execute(3, new Object[] {n405DocumentosId, A405DocumentosId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A405DocumentosId) ) )
            {
               GX_msglist.addItem("Não existe 'Documentos'.", "ForeignKeyNotFound", 1, "DOCUMENTOSID");
               AnyError = 1;
            }
         }
         pr_default.close(3);
         if ( ! ( ( StringUtil.StrCmp(A549ReembolsoDocumentoStatus, "AGUARDANDO_ANALISE") == 0 ) || ( StringUtil.StrCmp(A549ReembolsoDocumentoStatus, "APROVADO") == 0 ) || ( StringUtil.StrCmp(A549ReembolsoDocumentoStatus, "REPROVADO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A549ReembolsoDocumentoStatus)) ) )
         {
            GX_msglist.addItem("Campo Reembolso Documento Status fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors2174( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2174( )
      {
         /* Using cursor BC00217 */
         pr_default.execute(5, new Object[] {A529ReembolsoDocumentoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound74 = 1;
         }
         else
         {
            RcdFound74 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00213 */
         pr_default.execute(1, new Object[] {A529ReembolsoDocumentoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2174( 3) ;
            RcdFound74 = 1;
            A529ReembolsoDocumentoId = BC00213_A529ReembolsoDocumentoId[0];
            A530ReembolsoDocumentoNome = BC00213_A530ReembolsoDocumentoNome[0];
            n530ReembolsoDocumentoNome = BC00213_n530ReembolsoDocumentoNome[0];
            A532ReembolsoDocumentoBlobExt = BC00213_A532ReembolsoDocumentoBlobExt[0];
            n532ReembolsoDocumentoBlobExt = BC00213_n532ReembolsoDocumentoBlobExt[0];
            A533ReembolsoDocumentoCreatedAt = BC00213_A533ReembolsoDocumentoCreatedAt[0];
            n533ReembolsoDocumentoCreatedAt = BC00213_n533ReembolsoDocumentoCreatedAt[0];
            A549ReembolsoDocumentoStatus = BC00213_A549ReembolsoDocumentoStatus[0];
            n549ReembolsoDocumentoStatus = BC00213_n549ReembolsoDocumentoStatus[0];
            A526ReembolsoEtapaId = BC00213_A526ReembolsoEtapaId[0];
            n526ReembolsoEtapaId = BC00213_n526ReembolsoEtapaId[0];
            A405DocumentosId = BC00213_A405DocumentosId[0];
            n405DocumentosId = BC00213_n405DocumentosId[0];
            A531ReembolsoDocumentoBlob = BC00213_A531ReembolsoDocumentoBlob[0];
            n531ReembolsoDocumentoBlob = BC00213_n531ReembolsoDocumentoBlob[0];
            Z529ReembolsoDocumentoId = A529ReembolsoDocumentoId;
            sMode74 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2174( ) ;
            if ( AnyError == 1 )
            {
               RcdFound74 = 0;
               InitializeNonKey2174( ) ;
            }
            Gx_mode = sMode74;
         }
         else
         {
            RcdFound74 = 0;
            InitializeNonKey2174( ) ;
            sMode74 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode74;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2174( ) ;
         if ( RcdFound74 == 0 )
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
         CONFIRM_210( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2174( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00212 */
            pr_default.execute(0, new Object[] {A529ReembolsoDocumentoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ReembolsoDocumento"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z530ReembolsoDocumentoNome, BC00212_A530ReembolsoDocumentoNome[0]) != 0 ) || ( StringUtil.StrCmp(Z532ReembolsoDocumentoBlobExt, BC00212_A532ReembolsoDocumentoBlobExt[0]) != 0 ) || ( Z533ReembolsoDocumentoCreatedAt != BC00212_A533ReembolsoDocumentoCreatedAt[0] ) || ( StringUtil.StrCmp(Z549ReembolsoDocumentoStatus, BC00212_A549ReembolsoDocumentoStatus[0]) != 0 ) || ( Z526ReembolsoEtapaId != BC00212_A526ReembolsoEtapaId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z405DocumentosId != BC00212_A405DocumentosId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ReembolsoDocumento"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2174( )
      {
         BeforeValidate2174( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2174( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2174( 0) ;
            CheckOptimisticConcurrency2174( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2174( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2174( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00218 */
                     pr_default.execute(6, new Object[] {n530ReembolsoDocumentoNome, A530ReembolsoDocumentoNome, n531ReembolsoDocumentoBlob, A531ReembolsoDocumentoBlob, n532ReembolsoDocumentoBlobExt, A532ReembolsoDocumentoBlobExt, n533ReembolsoDocumentoCreatedAt, A533ReembolsoDocumentoCreatedAt, n549ReembolsoDocumentoStatus, A549ReembolsoDocumentoStatus, n526ReembolsoEtapaId, A526ReembolsoEtapaId, n405DocumentosId, A405DocumentosId});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC00219 */
                     pr_default.execute(7);
                     A529ReembolsoDocumentoId = BC00219_A529ReembolsoDocumentoId[0];
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("ReembolsoDocumento");
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
               Load2174( ) ;
            }
            EndLevel2174( ) ;
         }
         CloseExtendedTableCursors2174( ) ;
      }

      protected void Update2174( )
      {
         BeforeValidate2174( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2174( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2174( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2174( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2174( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002110 */
                     pr_default.execute(8, new Object[] {n530ReembolsoDocumentoNome, A530ReembolsoDocumentoNome, n532ReembolsoDocumentoBlobExt, A532ReembolsoDocumentoBlobExt, n533ReembolsoDocumentoCreatedAt, A533ReembolsoDocumentoCreatedAt, n549ReembolsoDocumentoStatus, A549ReembolsoDocumentoStatus, n526ReembolsoEtapaId, A526ReembolsoEtapaId, n405DocumentosId, A405DocumentosId, A529ReembolsoDocumentoId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("ReembolsoDocumento");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ReembolsoDocumento"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2174( ) ;
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
            EndLevel2174( ) ;
         }
         CloseExtendedTableCursors2174( ) ;
      }

      protected void DeferredUpdate2174( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC002111 */
            pr_default.execute(9, new Object[] {n531ReembolsoDocumentoBlob, A531ReembolsoDocumentoBlob, A529ReembolsoDocumentoId});
            pr_default.close(9);
            pr_default.SmartCacheProvider.SetUpdated("ReembolsoDocumento");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2174( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2174( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2174( ) ;
            AfterConfirm2174( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2174( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002112 */
                  pr_default.execute(10, new Object[] {A529ReembolsoDocumentoId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("ReembolsoDocumento");
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
         sMode74 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2174( ) ;
         Gx_mode = sMode74;
      }

      protected void OnDeleteControls2174( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2174( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2174( ) ;
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

      public void ScanKeyStart2174( )
      {
         /* Using cursor BC002113 */
         pr_default.execute(11, new Object[] {A529ReembolsoDocumentoId});
         RcdFound74 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound74 = 1;
            A529ReembolsoDocumentoId = BC002113_A529ReembolsoDocumentoId[0];
            A530ReembolsoDocumentoNome = BC002113_A530ReembolsoDocumentoNome[0];
            n530ReembolsoDocumentoNome = BC002113_n530ReembolsoDocumentoNome[0];
            A532ReembolsoDocumentoBlobExt = BC002113_A532ReembolsoDocumentoBlobExt[0];
            n532ReembolsoDocumentoBlobExt = BC002113_n532ReembolsoDocumentoBlobExt[0];
            A533ReembolsoDocumentoCreatedAt = BC002113_A533ReembolsoDocumentoCreatedAt[0];
            n533ReembolsoDocumentoCreatedAt = BC002113_n533ReembolsoDocumentoCreatedAt[0];
            A549ReembolsoDocumentoStatus = BC002113_A549ReembolsoDocumentoStatus[0];
            n549ReembolsoDocumentoStatus = BC002113_n549ReembolsoDocumentoStatus[0];
            A526ReembolsoEtapaId = BC002113_A526ReembolsoEtapaId[0];
            n526ReembolsoEtapaId = BC002113_n526ReembolsoEtapaId[0];
            A405DocumentosId = BC002113_A405DocumentosId[0];
            n405DocumentosId = BC002113_n405DocumentosId[0];
            A531ReembolsoDocumentoBlob = BC002113_A531ReembolsoDocumentoBlob[0];
            n531ReembolsoDocumentoBlob = BC002113_n531ReembolsoDocumentoBlob[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2174( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound74 = 0;
         ScanKeyLoad2174( ) ;
      }

      protected void ScanKeyLoad2174( )
      {
         sMode74 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound74 = 1;
            A529ReembolsoDocumentoId = BC002113_A529ReembolsoDocumentoId[0];
            A530ReembolsoDocumentoNome = BC002113_A530ReembolsoDocumentoNome[0];
            n530ReembolsoDocumentoNome = BC002113_n530ReembolsoDocumentoNome[0];
            A532ReembolsoDocumentoBlobExt = BC002113_A532ReembolsoDocumentoBlobExt[0];
            n532ReembolsoDocumentoBlobExt = BC002113_n532ReembolsoDocumentoBlobExt[0];
            A533ReembolsoDocumentoCreatedAt = BC002113_A533ReembolsoDocumentoCreatedAt[0];
            n533ReembolsoDocumentoCreatedAt = BC002113_n533ReembolsoDocumentoCreatedAt[0];
            A549ReembolsoDocumentoStatus = BC002113_A549ReembolsoDocumentoStatus[0];
            n549ReembolsoDocumentoStatus = BC002113_n549ReembolsoDocumentoStatus[0];
            A526ReembolsoEtapaId = BC002113_A526ReembolsoEtapaId[0];
            n526ReembolsoEtapaId = BC002113_n526ReembolsoEtapaId[0];
            A405DocumentosId = BC002113_A405DocumentosId[0];
            n405DocumentosId = BC002113_n405DocumentosId[0];
            A531ReembolsoDocumentoBlob = BC002113_A531ReembolsoDocumentoBlob[0];
            n531ReembolsoDocumentoBlob = BC002113_n531ReembolsoDocumentoBlob[0];
         }
         Gx_mode = sMode74;
      }

      protected void ScanKeyEnd2174( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm2174( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2174( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2174( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2174( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2174( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2174( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2174( )
      {
      }

      protected void send_integrity_lvl_hashes2174( )
      {
      }

      protected void AddRow2174( )
      {
         VarsToRow74( bcReembolsoDocumento) ;
      }

      protected void ReadRow2174( )
      {
         RowToVars74( bcReembolsoDocumento, 1) ;
      }

      protected void InitializeNonKey2174( )
      {
         A526ReembolsoEtapaId = 0;
         n526ReembolsoEtapaId = false;
         A530ReembolsoDocumentoNome = "";
         n530ReembolsoDocumentoNome = false;
         A531ReembolsoDocumentoBlob = "";
         n531ReembolsoDocumentoBlob = false;
         A532ReembolsoDocumentoBlobExt = "";
         n532ReembolsoDocumentoBlobExt = false;
         A405DocumentosId = 0;
         n405DocumentosId = false;
         A549ReembolsoDocumentoStatus = "";
         n549ReembolsoDocumentoStatus = false;
         A533ReembolsoDocumentoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n533ReembolsoDocumentoCreatedAt = false;
         Z530ReembolsoDocumentoNome = "";
         Z532ReembolsoDocumentoBlobExt = "";
         Z533ReembolsoDocumentoCreatedAt = (DateTime)(DateTime.MinValue);
         Z549ReembolsoDocumentoStatus = "";
         Z526ReembolsoEtapaId = 0;
         Z405DocumentosId = 0;
      }

      protected void InitAll2174( )
      {
         A529ReembolsoDocumentoId = 0;
         InitializeNonKey2174( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A533ReembolsoDocumentoCreatedAt = i533ReembolsoDocumentoCreatedAt;
         n533ReembolsoDocumentoCreatedAt = false;
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

      public void VarsToRow74( SdtReembolsoDocumento obj74 )
      {
         obj74.gxTpr_Mode = Gx_mode;
         obj74.gxTpr_Reembolsoetapaid = A526ReembolsoEtapaId;
         obj74.gxTpr_Reembolsodocumentonome = A530ReembolsoDocumentoNome;
         obj74.gxTpr_Reembolsodocumentoblob = A531ReembolsoDocumentoBlob;
         obj74.gxTpr_Reembolsodocumentoblobext = A532ReembolsoDocumentoBlobExt;
         obj74.gxTpr_Documentosid = A405DocumentosId;
         obj74.gxTpr_Reembolsodocumentostatus = A549ReembolsoDocumentoStatus;
         obj74.gxTpr_Reembolsodocumentocreatedat = A533ReembolsoDocumentoCreatedAt;
         obj74.gxTpr_Reembolsodocumentoid = A529ReembolsoDocumentoId;
         obj74.gxTpr_Reembolsodocumentoid_Z = Z529ReembolsoDocumentoId;
         obj74.gxTpr_Reembolsoetapaid_Z = Z526ReembolsoEtapaId;
         obj74.gxTpr_Reembolsodocumentonome_Z = Z530ReembolsoDocumentoNome;
         obj74.gxTpr_Reembolsodocumentoblobext_Z = Z532ReembolsoDocumentoBlobExt;
         obj74.gxTpr_Reembolsodocumentocreatedat_Z = Z533ReembolsoDocumentoCreatedAt;
         obj74.gxTpr_Documentosid_Z = Z405DocumentosId;
         obj74.gxTpr_Reembolsodocumentostatus_Z = Z549ReembolsoDocumentoStatus;
         obj74.gxTpr_Reembolsoetapaid_N = (short)(Convert.ToInt16(n526ReembolsoEtapaId));
         obj74.gxTpr_Reembolsodocumentonome_N = (short)(Convert.ToInt16(n530ReembolsoDocumentoNome));
         obj74.gxTpr_Reembolsodocumentoblob_N = (short)(Convert.ToInt16(n531ReembolsoDocumentoBlob));
         obj74.gxTpr_Reembolsodocumentoblobext_N = (short)(Convert.ToInt16(n532ReembolsoDocumentoBlobExt));
         obj74.gxTpr_Reembolsodocumentocreatedat_N = (short)(Convert.ToInt16(n533ReembolsoDocumentoCreatedAt));
         obj74.gxTpr_Documentosid_N = (short)(Convert.ToInt16(n405DocumentosId));
         obj74.gxTpr_Reembolsodocumentostatus_N = (short)(Convert.ToInt16(n549ReembolsoDocumentoStatus));
         obj74.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow74( SdtReembolsoDocumento obj74 )
      {
         obj74.gxTpr_Reembolsodocumentoid = A529ReembolsoDocumentoId;
         return  ;
      }

      public void RowToVars74( SdtReembolsoDocumento obj74 ,
                               int forceLoad )
      {
         Gx_mode = obj74.gxTpr_Mode;
         A526ReembolsoEtapaId = obj74.gxTpr_Reembolsoetapaid;
         n526ReembolsoEtapaId = false;
         A530ReembolsoDocumentoNome = obj74.gxTpr_Reembolsodocumentonome;
         n530ReembolsoDocumentoNome = false;
         A531ReembolsoDocumentoBlob = obj74.gxTpr_Reembolsodocumentoblob;
         n531ReembolsoDocumentoBlob = false;
         A532ReembolsoDocumentoBlobExt = obj74.gxTpr_Reembolsodocumentoblobext;
         n532ReembolsoDocumentoBlobExt = false;
         A405DocumentosId = obj74.gxTpr_Documentosid;
         n405DocumentosId = false;
         A549ReembolsoDocumentoStatus = obj74.gxTpr_Reembolsodocumentostatus;
         n549ReembolsoDocumentoStatus = false;
         A533ReembolsoDocumentoCreatedAt = obj74.gxTpr_Reembolsodocumentocreatedat;
         n533ReembolsoDocumentoCreatedAt = false;
         A529ReembolsoDocumentoId = obj74.gxTpr_Reembolsodocumentoid;
         Z529ReembolsoDocumentoId = obj74.gxTpr_Reembolsodocumentoid_Z;
         Z526ReembolsoEtapaId = obj74.gxTpr_Reembolsoetapaid_Z;
         Z530ReembolsoDocumentoNome = obj74.gxTpr_Reembolsodocumentonome_Z;
         Z532ReembolsoDocumentoBlobExt = obj74.gxTpr_Reembolsodocumentoblobext_Z;
         Z533ReembolsoDocumentoCreatedAt = obj74.gxTpr_Reembolsodocumentocreatedat_Z;
         Z405DocumentosId = obj74.gxTpr_Documentosid_Z;
         Z549ReembolsoDocumentoStatus = obj74.gxTpr_Reembolsodocumentostatus_Z;
         n526ReembolsoEtapaId = (bool)(Convert.ToBoolean(obj74.gxTpr_Reembolsoetapaid_N));
         n530ReembolsoDocumentoNome = (bool)(Convert.ToBoolean(obj74.gxTpr_Reembolsodocumentonome_N));
         n531ReembolsoDocumentoBlob = (bool)(Convert.ToBoolean(obj74.gxTpr_Reembolsodocumentoblob_N));
         n532ReembolsoDocumentoBlobExt = (bool)(Convert.ToBoolean(obj74.gxTpr_Reembolsodocumentoblobext_N));
         n533ReembolsoDocumentoCreatedAt = (bool)(Convert.ToBoolean(obj74.gxTpr_Reembolsodocumentocreatedat_N));
         n405DocumentosId = (bool)(Convert.ToBoolean(obj74.gxTpr_Documentosid_N));
         n549ReembolsoDocumentoStatus = (bool)(Convert.ToBoolean(obj74.gxTpr_Reembolsodocumentostatus_N));
         Gx_mode = obj74.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A529ReembolsoDocumentoId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2174( ) ;
         ScanKeyStart2174( ) ;
         if ( RcdFound74 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z529ReembolsoDocumentoId = A529ReembolsoDocumentoId;
         }
         ZM2174( -3) ;
         OnLoadActions2174( ) ;
         AddRow2174( ) ;
         ScanKeyEnd2174( ) ;
         if ( RcdFound74 == 0 )
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
         RowToVars74( bcReembolsoDocumento, 0) ;
         ScanKeyStart2174( ) ;
         if ( RcdFound74 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z529ReembolsoDocumentoId = A529ReembolsoDocumentoId;
         }
         ZM2174( -3) ;
         OnLoadActions2174( ) ;
         AddRow2174( ) ;
         ScanKeyEnd2174( ) ;
         if ( RcdFound74 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2174( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2174( ) ;
         }
         else
         {
            if ( RcdFound74 == 1 )
            {
               if ( A529ReembolsoDocumentoId != Z529ReembolsoDocumentoId )
               {
                  A529ReembolsoDocumentoId = Z529ReembolsoDocumentoId;
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
                  Update2174( ) ;
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
                  if ( A529ReembolsoDocumentoId != Z529ReembolsoDocumentoId )
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
                        Insert2174( ) ;
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
                        Insert2174( ) ;
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
         RowToVars74( bcReembolsoDocumento, 1) ;
         SaveImpl( ) ;
         VarsToRow74( bcReembolsoDocumento) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars74( bcReembolsoDocumento, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2174( ) ;
         AfterTrn( ) ;
         VarsToRow74( bcReembolsoDocumento) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow74( bcReembolsoDocumento) ;
         }
         else
         {
            SdtReembolsoDocumento auxBC = new SdtReembolsoDocumento(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A529ReembolsoDocumentoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcReembolsoDocumento);
               auxBC.Save();
               bcReembolsoDocumento.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars74( bcReembolsoDocumento, 1) ;
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
         RowToVars74( bcReembolsoDocumento, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2174( ) ;
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
               VarsToRow74( bcReembolsoDocumento) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow74( bcReembolsoDocumento) ;
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
         RowToVars74( bcReembolsoDocumento, 0) ;
         GetKey2174( ) ;
         if ( RcdFound74 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A529ReembolsoDocumentoId != Z529ReembolsoDocumentoId )
            {
               A529ReembolsoDocumentoId = Z529ReembolsoDocumentoId;
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
            if ( A529ReembolsoDocumentoId != Z529ReembolsoDocumentoId )
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
         context.RollbackDataStores("reembolsodocumento_bc",pr_default);
         VarsToRow74( bcReembolsoDocumento) ;
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
         Gx_mode = bcReembolsoDocumento.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcReembolsoDocumento.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcReembolsoDocumento )
         {
            bcReembolsoDocumento = (SdtReembolsoDocumento)(sdt);
            if ( StringUtil.StrCmp(bcReembolsoDocumento.gxTpr_Mode, "") == 0 )
            {
               bcReembolsoDocumento.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow74( bcReembolsoDocumento) ;
            }
            else
            {
               RowToVars74( bcReembolsoDocumento, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcReembolsoDocumento.gxTpr_Mode, "") == 0 )
            {
               bcReembolsoDocumento.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars74( bcReembolsoDocumento, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtReembolsoDocumento ReembolsoDocumento_BC
      {
         get {
            return bcReembolsoDocumento ;
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
         Z530ReembolsoDocumentoNome = "";
         A530ReembolsoDocumentoNome = "";
         Z532ReembolsoDocumentoBlobExt = "";
         A532ReembolsoDocumentoBlobExt = "";
         Z533ReembolsoDocumentoCreatedAt = (DateTime)(DateTime.MinValue);
         A533ReembolsoDocumentoCreatedAt = (DateTime)(DateTime.MinValue);
         Z549ReembolsoDocumentoStatus = "";
         A549ReembolsoDocumentoStatus = "";
         Z531ReembolsoDocumentoBlob = "";
         A531ReembolsoDocumentoBlob = "";
         BC00216_A529ReembolsoDocumentoId = new int[1] ;
         BC00216_A530ReembolsoDocumentoNome = new string[] {""} ;
         BC00216_n530ReembolsoDocumentoNome = new bool[] {false} ;
         BC00216_A532ReembolsoDocumentoBlobExt = new string[] {""} ;
         BC00216_n532ReembolsoDocumentoBlobExt = new bool[] {false} ;
         BC00216_A533ReembolsoDocumentoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00216_n533ReembolsoDocumentoCreatedAt = new bool[] {false} ;
         BC00216_A549ReembolsoDocumentoStatus = new string[] {""} ;
         BC00216_n549ReembolsoDocumentoStatus = new bool[] {false} ;
         BC00216_A526ReembolsoEtapaId = new int[1] ;
         BC00216_n526ReembolsoEtapaId = new bool[] {false} ;
         BC00216_A405DocumentosId = new int[1] ;
         BC00216_n405DocumentosId = new bool[] {false} ;
         BC00216_A531ReembolsoDocumentoBlob = new string[] {""} ;
         BC00216_n531ReembolsoDocumentoBlob = new bool[] {false} ;
         BC00214_A526ReembolsoEtapaId = new int[1] ;
         BC00214_n526ReembolsoEtapaId = new bool[] {false} ;
         BC00215_A405DocumentosId = new int[1] ;
         BC00215_n405DocumentosId = new bool[] {false} ;
         BC00217_A529ReembolsoDocumentoId = new int[1] ;
         BC00213_A529ReembolsoDocumentoId = new int[1] ;
         BC00213_A530ReembolsoDocumentoNome = new string[] {""} ;
         BC00213_n530ReembolsoDocumentoNome = new bool[] {false} ;
         BC00213_A532ReembolsoDocumentoBlobExt = new string[] {""} ;
         BC00213_n532ReembolsoDocumentoBlobExt = new bool[] {false} ;
         BC00213_A533ReembolsoDocumentoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00213_n533ReembolsoDocumentoCreatedAt = new bool[] {false} ;
         BC00213_A549ReembolsoDocumentoStatus = new string[] {""} ;
         BC00213_n549ReembolsoDocumentoStatus = new bool[] {false} ;
         BC00213_A526ReembolsoEtapaId = new int[1] ;
         BC00213_n526ReembolsoEtapaId = new bool[] {false} ;
         BC00213_A405DocumentosId = new int[1] ;
         BC00213_n405DocumentosId = new bool[] {false} ;
         BC00213_A531ReembolsoDocumentoBlob = new string[] {""} ;
         BC00213_n531ReembolsoDocumentoBlob = new bool[] {false} ;
         sMode74 = "";
         BC00212_A529ReembolsoDocumentoId = new int[1] ;
         BC00212_A530ReembolsoDocumentoNome = new string[] {""} ;
         BC00212_n530ReembolsoDocumentoNome = new bool[] {false} ;
         BC00212_A532ReembolsoDocumentoBlobExt = new string[] {""} ;
         BC00212_n532ReembolsoDocumentoBlobExt = new bool[] {false} ;
         BC00212_A533ReembolsoDocumentoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00212_n533ReembolsoDocumentoCreatedAt = new bool[] {false} ;
         BC00212_A549ReembolsoDocumentoStatus = new string[] {""} ;
         BC00212_n549ReembolsoDocumentoStatus = new bool[] {false} ;
         BC00212_A526ReembolsoEtapaId = new int[1] ;
         BC00212_n526ReembolsoEtapaId = new bool[] {false} ;
         BC00212_A405DocumentosId = new int[1] ;
         BC00212_n405DocumentosId = new bool[] {false} ;
         BC00212_A531ReembolsoDocumentoBlob = new string[] {""} ;
         BC00212_n531ReembolsoDocumentoBlob = new bool[] {false} ;
         BC00219_A529ReembolsoDocumentoId = new int[1] ;
         BC002113_A529ReembolsoDocumentoId = new int[1] ;
         BC002113_A530ReembolsoDocumentoNome = new string[] {""} ;
         BC002113_n530ReembolsoDocumentoNome = new bool[] {false} ;
         BC002113_A532ReembolsoDocumentoBlobExt = new string[] {""} ;
         BC002113_n532ReembolsoDocumentoBlobExt = new bool[] {false} ;
         BC002113_A533ReembolsoDocumentoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002113_n533ReembolsoDocumentoCreatedAt = new bool[] {false} ;
         BC002113_A549ReembolsoDocumentoStatus = new string[] {""} ;
         BC002113_n549ReembolsoDocumentoStatus = new bool[] {false} ;
         BC002113_A526ReembolsoEtapaId = new int[1] ;
         BC002113_n526ReembolsoEtapaId = new bool[] {false} ;
         BC002113_A405DocumentosId = new int[1] ;
         BC002113_n405DocumentosId = new bool[] {false} ;
         BC002113_A531ReembolsoDocumentoBlob = new string[] {""} ;
         BC002113_n531ReembolsoDocumentoBlob = new bool[] {false} ;
         i533ReembolsoDocumentoCreatedAt = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reembolsodocumento_bc__default(),
            new Object[][] {
                new Object[] {
               BC00212_A529ReembolsoDocumentoId, BC00212_A530ReembolsoDocumentoNome, BC00212_n530ReembolsoDocumentoNome, BC00212_A532ReembolsoDocumentoBlobExt, BC00212_n532ReembolsoDocumentoBlobExt, BC00212_A533ReembolsoDocumentoCreatedAt, BC00212_n533ReembolsoDocumentoCreatedAt, BC00212_A549ReembolsoDocumentoStatus, BC00212_n549ReembolsoDocumentoStatus, BC00212_A526ReembolsoEtapaId,
               BC00212_n526ReembolsoEtapaId, BC00212_A405DocumentosId, BC00212_n405DocumentosId, BC00212_A531ReembolsoDocumentoBlob, BC00212_n531ReembolsoDocumentoBlob
               }
               , new Object[] {
               BC00213_A529ReembolsoDocumentoId, BC00213_A530ReembolsoDocumentoNome, BC00213_n530ReembolsoDocumentoNome, BC00213_A532ReembolsoDocumentoBlobExt, BC00213_n532ReembolsoDocumentoBlobExt, BC00213_A533ReembolsoDocumentoCreatedAt, BC00213_n533ReembolsoDocumentoCreatedAt, BC00213_A549ReembolsoDocumentoStatus, BC00213_n549ReembolsoDocumentoStatus, BC00213_A526ReembolsoEtapaId,
               BC00213_n526ReembolsoEtapaId, BC00213_A405DocumentosId, BC00213_n405DocumentosId, BC00213_A531ReembolsoDocumentoBlob, BC00213_n531ReembolsoDocumentoBlob
               }
               , new Object[] {
               BC00214_A526ReembolsoEtapaId
               }
               , new Object[] {
               BC00215_A405DocumentosId
               }
               , new Object[] {
               BC00216_A529ReembolsoDocumentoId, BC00216_A530ReembolsoDocumentoNome, BC00216_n530ReembolsoDocumentoNome, BC00216_A532ReembolsoDocumentoBlobExt, BC00216_n532ReembolsoDocumentoBlobExt, BC00216_A533ReembolsoDocumentoCreatedAt, BC00216_n533ReembolsoDocumentoCreatedAt, BC00216_A549ReembolsoDocumentoStatus, BC00216_n549ReembolsoDocumentoStatus, BC00216_A526ReembolsoEtapaId,
               BC00216_n526ReembolsoEtapaId, BC00216_A405DocumentosId, BC00216_n405DocumentosId, BC00216_A531ReembolsoDocumentoBlob, BC00216_n531ReembolsoDocumentoBlob
               }
               , new Object[] {
               BC00217_A529ReembolsoDocumentoId
               }
               , new Object[] {
               }
               , new Object[] {
               BC00219_A529ReembolsoDocumentoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002113_A529ReembolsoDocumentoId, BC002113_A530ReembolsoDocumentoNome, BC002113_n530ReembolsoDocumentoNome, BC002113_A532ReembolsoDocumentoBlobExt, BC002113_n532ReembolsoDocumentoBlobExt, BC002113_A533ReembolsoDocumentoCreatedAt, BC002113_n533ReembolsoDocumentoCreatedAt, BC002113_A549ReembolsoDocumentoStatus, BC002113_n549ReembolsoDocumentoStatus, BC002113_A526ReembolsoEtapaId,
               BC002113_n526ReembolsoEtapaId, BC002113_A405DocumentosId, BC002113_n405DocumentosId, BC002113_A531ReembolsoDocumentoBlob, BC002113_n531ReembolsoDocumentoBlob
               }
            }
         );
         Z533ReembolsoDocumentoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n533ReembolsoDocumentoCreatedAt = false;
         A533ReembolsoDocumentoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n533ReembolsoDocumentoCreatedAt = false;
         i533ReembolsoDocumentoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n533ReembolsoDocumentoCreatedAt = false;
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound74 ;
      private int trnEnded ;
      private int Z529ReembolsoDocumentoId ;
      private int A529ReembolsoDocumentoId ;
      private int Z526ReembolsoEtapaId ;
      private int A526ReembolsoEtapaId ;
      private int Z405DocumentosId ;
      private int A405DocumentosId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode74 ;
      private DateTime Z533ReembolsoDocumentoCreatedAt ;
      private DateTime A533ReembolsoDocumentoCreatedAt ;
      private DateTime i533ReembolsoDocumentoCreatedAt ;
      private bool n533ReembolsoDocumentoCreatedAt ;
      private bool n530ReembolsoDocumentoNome ;
      private bool n532ReembolsoDocumentoBlobExt ;
      private bool n549ReembolsoDocumentoStatus ;
      private bool n526ReembolsoEtapaId ;
      private bool n405DocumentosId ;
      private bool n531ReembolsoDocumentoBlob ;
      private bool Gx_longc ;
      private string Z530ReembolsoDocumentoNome ;
      private string A530ReembolsoDocumentoNome ;
      private string Z532ReembolsoDocumentoBlobExt ;
      private string A532ReembolsoDocumentoBlobExt ;
      private string Z549ReembolsoDocumentoStatus ;
      private string A549ReembolsoDocumentoStatus ;
      private string Z531ReembolsoDocumentoBlob ;
      private string A531ReembolsoDocumentoBlob ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00216_A529ReembolsoDocumentoId ;
      private string[] BC00216_A530ReembolsoDocumentoNome ;
      private bool[] BC00216_n530ReembolsoDocumentoNome ;
      private string[] BC00216_A532ReembolsoDocumentoBlobExt ;
      private bool[] BC00216_n532ReembolsoDocumentoBlobExt ;
      private DateTime[] BC00216_A533ReembolsoDocumentoCreatedAt ;
      private bool[] BC00216_n533ReembolsoDocumentoCreatedAt ;
      private string[] BC00216_A549ReembolsoDocumentoStatus ;
      private bool[] BC00216_n549ReembolsoDocumentoStatus ;
      private int[] BC00216_A526ReembolsoEtapaId ;
      private bool[] BC00216_n526ReembolsoEtapaId ;
      private int[] BC00216_A405DocumentosId ;
      private bool[] BC00216_n405DocumentosId ;
      private string[] BC00216_A531ReembolsoDocumentoBlob ;
      private bool[] BC00216_n531ReembolsoDocumentoBlob ;
      private int[] BC00214_A526ReembolsoEtapaId ;
      private bool[] BC00214_n526ReembolsoEtapaId ;
      private int[] BC00215_A405DocumentosId ;
      private bool[] BC00215_n405DocumentosId ;
      private int[] BC00217_A529ReembolsoDocumentoId ;
      private int[] BC00213_A529ReembolsoDocumentoId ;
      private string[] BC00213_A530ReembolsoDocumentoNome ;
      private bool[] BC00213_n530ReembolsoDocumentoNome ;
      private string[] BC00213_A532ReembolsoDocumentoBlobExt ;
      private bool[] BC00213_n532ReembolsoDocumentoBlobExt ;
      private DateTime[] BC00213_A533ReembolsoDocumentoCreatedAt ;
      private bool[] BC00213_n533ReembolsoDocumentoCreatedAt ;
      private string[] BC00213_A549ReembolsoDocumentoStatus ;
      private bool[] BC00213_n549ReembolsoDocumentoStatus ;
      private int[] BC00213_A526ReembolsoEtapaId ;
      private bool[] BC00213_n526ReembolsoEtapaId ;
      private int[] BC00213_A405DocumentosId ;
      private bool[] BC00213_n405DocumentosId ;
      private string[] BC00213_A531ReembolsoDocumentoBlob ;
      private bool[] BC00213_n531ReembolsoDocumentoBlob ;
      private int[] BC00212_A529ReembolsoDocumentoId ;
      private string[] BC00212_A530ReembolsoDocumentoNome ;
      private bool[] BC00212_n530ReembolsoDocumentoNome ;
      private string[] BC00212_A532ReembolsoDocumentoBlobExt ;
      private bool[] BC00212_n532ReembolsoDocumentoBlobExt ;
      private DateTime[] BC00212_A533ReembolsoDocumentoCreatedAt ;
      private bool[] BC00212_n533ReembolsoDocumentoCreatedAt ;
      private string[] BC00212_A549ReembolsoDocumentoStatus ;
      private bool[] BC00212_n549ReembolsoDocumentoStatus ;
      private int[] BC00212_A526ReembolsoEtapaId ;
      private bool[] BC00212_n526ReembolsoEtapaId ;
      private int[] BC00212_A405DocumentosId ;
      private bool[] BC00212_n405DocumentosId ;
      private string[] BC00212_A531ReembolsoDocumentoBlob ;
      private bool[] BC00212_n531ReembolsoDocumentoBlob ;
      private int[] BC00219_A529ReembolsoDocumentoId ;
      private int[] BC002113_A529ReembolsoDocumentoId ;
      private string[] BC002113_A530ReembolsoDocumentoNome ;
      private bool[] BC002113_n530ReembolsoDocumentoNome ;
      private string[] BC002113_A532ReembolsoDocumentoBlobExt ;
      private bool[] BC002113_n532ReembolsoDocumentoBlobExt ;
      private DateTime[] BC002113_A533ReembolsoDocumentoCreatedAt ;
      private bool[] BC002113_n533ReembolsoDocumentoCreatedAt ;
      private string[] BC002113_A549ReembolsoDocumentoStatus ;
      private bool[] BC002113_n549ReembolsoDocumentoStatus ;
      private int[] BC002113_A526ReembolsoEtapaId ;
      private bool[] BC002113_n526ReembolsoEtapaId ;
      private int[] BC002113_A405DocumentosId ;
      private bool[] BC002113_n405DocumentosId ;
      private string[] BC002113_A531ReembolsoDocumentoBlob ;
      private bool[] BC002113_n531ReembolsoDocumentoBlob ;
      private SdtReembolsoDocumento bcReembolsoDocumento ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class reembolsodocumento_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00212;
          prmBC00212 = new Object[] {
          new ParDef("ReembolsoDocumentoId",GXType.Int32,9,0)
          };
          Object[] prmBC00213;
          prmBC00213 = new Object[] {
          new ParDef("ReembolsoDocumentoId",GXType.Int32,9,0)
          };
          Object[] prmBC00214;
          prmBC00214 = new Object[] {
          new ParDef("ReembolsoEtapaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00215;
          prmBC00215 = new Object[] {
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00216;
          prmBC00216 = new Object[] {
          new ParDef("ReembolsoDocumentoId",GXType.Int32,9,0)
          };
          Object[] prmBC00217;
          prmBC00217 = new Object[] {
          new ParDef("ReembolsoDocumentoId",GXType.Int32,9,0)
          };
          Object[] prmBC00218;
          prmBC00218 = new Object[] {
          new ParDef("ReembolsoDocumentoNome",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("ReembolsoDocumentoBlob",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("ReembolsoDocumentoBlobExt",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("ReembolsoDocumentoCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ReembolsoDocumentoStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ReembolsoEtapaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00219;
          prmBC00219 = new Object[] {
          };
          Object[] prmBC002110;
          prmBC002110 = new Object[] {
          new ParDef("ReembolsoDocumentoNome",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("ReembolsoDocumentoBlobExt",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("ReembolsoDocumentoCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ReembolsoDocumentoStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ReembolsoEtapaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ReembolsoDocumentoId",GXType.Int32,9,0)
          };
          Object[] prmBC002111;
          prmBC002111 = new Object[] {
          new ParDef("ReembolsoDocumentoBlob",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("ReembolsoDocumentoId",GXType.Int32,9,0)
          };
          Object[] prmBC002112;
          prmBC002112 = new Object[] {
          new ParDef("ReembolsoDocumentoId",GXType.Int32,9,0)
          };
          Object[] prmBC002113;
          prmBC002113 = new Object[] {
          new ParDef("ReembolsoDocumentoId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00212", "SELECT ReembolsoDocumentoId, ReembolsoDocumentoNome, ReembolsoDocumentoBlobExt, ReembolsoDocumentoCreatedAt, ReembolsoDocumentoStatus, ReembolsoEtapaId, DocumentosId, ReembolsoDocumentoBlob FROM ReembolsoDocumento WHERE ReembolsoDocumentoId = :ReembolsoDocumentoId  FOR UPDATE OF ReembolsoDocumento",true, GxErrorMask.GX_NOMASK, false, this,prmBC00212,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00213", "SELECT ReembolsoDocumentoId, ReembolsoDocumentoNome, ReembolsoDocumentoBlobExt, ReembolsoDocumentoCreatedAt, ReembolsoDocumentoStatus, ReembolsoEtapaId, DocumentosId, ReembolsoDocumentoBlob FROM ReembolsoDocumento WHERE ReembolsoDocumentoId = :ReembolsoDocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00213,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00214", "SELECT ReembolsoEtapaId FROM ReembolsoEtapa WHERE ReembolsoEtapaId = :ReembolsoEtapaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00214,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00215", "SELECT DocumentosId FROM Documentos WHERE DocumentosId = :DocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00215,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00216", "SELECT TM1.ReembolsoDocumentoId, TM1.ReembolsoDocumentoNome, TM1.ReembolsoDocumentoBlobExt, TM1.ReembolsoDocumentoCreatedAt, TM1.ReembolsoDocumentoStatus, TM1.ReembolsoEtapaId, TM1.DocumentosId, TM1.ReembolsoDocumentoBlob FROM ReembolsoDocumento TM1 WHERE TM1.ReembolsoDocumentoId = :ReembolsoDocumentoId ORDER BY TM1.ReembolsoDocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00216,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00217", "SELECT ReembolsoDocumentoId FROM ReembolsoDocumento WHERE ReembolsoDocumentoId = :ReembolsoDocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00217,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00218", "SAVEPOINT gxupdate;INSERT INTO ReembolsoDocumento(ReembolsoDocumentoNome, ReembolsoDocumentoBlob, ReembolsoDocumentoBlobExt, ReembolsoDocumentoCreatedAt, ReembolsoDocumentoStatus, ReembolsoEtapaId, DocumentosId) VALUES(:ReembolsoDocumentoNome, :ReembolsoDocumentoBlob, :ReembolsoDocumentoBlobExt, :ReembolsoDocumentoCreatedAt, :ReembolsoDocumentoStatus, :ReembolsoEtapaId, :DocumentosId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00218)
             ,new CursorDef("BC00219", "SELECT currval('ReembolsoDocumentoId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00219,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002110", "SAVEPOINT gxupdate;UPDATE ReembolsoDocumento SET ReembolsoDocumentoNome=:ReembolsoDocumentoNome, ReembolsoDocumentoBlobExt=:ReembolsoDocumentoBlobExt, ReembolsoDocumentoCreatedAt=:ReembolsoDocumentoCreatedAt, ReembolsoDocumentoStatus=:ReembolsoDocumentoStatus, ReembolsoEtapaId=:ReembolsoEtapaId, DocumentosId=:DocumentosId  WHERE ReembolsoDocumentoId = :ReembolsoDocumentoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002110)
             ,new CursorDef("BC002111", "SAVEPOINT gxupdate;UPDATE ReembolsoDocumento SET ReembolsoDocumentoBlob=:ReembolsoDocumentoBlob  WHERE ReembolsoDocumentoId = :ReembolsoDocumentoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002111)
             ,new CursorDef("BC002112", "SAVEPOINT gxupdate;DELETE FROM ReembolsoDocumento  WHERE ReembolsoDocumentoId = :ReembolsoDocumentoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002112)
             ,new CursorDef("BC002113", "SELECT TM1.ReembolsoDocumentoId, TM1.ReembolsoDocumentoNome, TM1.ReembolsoDocumentoBlobExt, TM1.ReembolsoDocumentoCreatedAt, TM1.ReembolsoDocumentoStatus, TM1.ReembolsoEtapaId, TM1.DocumentosId, TM1.ReembolsoDocumentoBlob FROM ReembolsoDocumento TM1 WHERE TM1.ReembolsoDocumentoId = :ReembolsoDocumentoId ORDER BY TM1.ReembolsoDocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002113,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
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
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getBLOBFile(8, "tmp", "");
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getBLOBFile(8, "tmp", "");
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
       }
    }

 }

}
