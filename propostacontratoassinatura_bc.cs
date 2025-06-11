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
   public class propostacontratoassinatura_bc : GxSilentTrn, IGxSilentTrn
   {
      public propostacontratoassinatura_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public propostacontratoassinatura_bc( IGxContext context )
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
         ReadRow2778( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2778( ) ;
         standaloneModal( ) ;
         AddRow2778( ) ;
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
               Z572PropostaContratoAssinaturaId = A572PropostaContratoAssinaturaId;
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

      protected void CONFIRM_270( )
      {
         BeforeValidate2778( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2778( ) ;
            }
            else
            {
               CheckExtendedTable2778( ) ;
               if ( AnyError == 0 )
               {
                  ZM2778( 3) ;
                  ZM2778( 4) ;
                  ZM2778( 5) ;
               }
               CloseExtendedTableCursors2778( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM2778( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z573PropostaContratoAssinaturaTipo = A573PropostaContratoAssinaturaTipo;
            Z323PropostaId = A323PropostaId;
            Z570PropostaContrato = A570PropostaContrato;
            Z571PropostaAssinatura = A571PropostaAssinatura;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z574PropostaAssinaturaStatus = A574PropostaAssinaturaStatus;
         }
         if ( GX_JID == -2 )
         {
            Z572PropostaContratoAssinaturaId = A572PropostaContratoAssinaturaId;
            Z573PropostaContratoAssinaturaTipo = A573PropostaContratoAssinaturaTipo;
            Z323PropostaId = A323PropostaId;
            Z570PropostaContrato = A570PropostaContrato;
            Z571PropostaAssinatura = A571PropostaAssinatura;
            Z574PropostaAssinaturaStatus = A574PropostaAssinaturaStatus;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load2778( )
      {
         /* Using cursor BC00277 */
         pr_default.execute(5, new Object[] {n572PropostaContratoAssinaturaId, A572PropostaContratoAssinaturaId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound78 = 1;
            A574PropostaAssinaturaStatus = BC00277_A574PropostaAssinaturaStatus[0];
            n574PropostaAssinaturaStatus = BC00277_n574PropostaAssinaturaStatus[0];
            A573PropostaContratoAssinaturaTipo = BC00277_A573PropostaContratoAssinaturaTipo[0];
            n573PropostaContratoAssinaturaTipo = BC00277_n573PropostaContratoAssinaturaTipo[0];
            A323PropostaId = BC00277_A323PropostaId[0];
            n323PropostaId = BC00277_n323PropostaId[0];
            A570PropostaContrato = BC00277_A570PropostaContrato[0];
            n570PropostaContrato = BC00277_n570PropostaContrato[0];
            A571PropostaAssinatura = BC00277_A571PropostaAssinatura[0];
            n571PropostaAssinatura = BC00277_n571PropostaAssinatura[0];
            ZM2778( -2) ;
         }
         pr_default.close(5);
         OnLoadActions2778( ) ;
      }

      protected void OnLoadActions2778( )
      {
      }

      protected void CheckExtendedTable2778( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00274 */
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
         /* Using cursor BC00275 */
         pr_default.execute(3, new Object[] {n570PropostaContrato, A570PropostaContrato});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A570PropostaContrato) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Proposta Contrato'.", "ForeignKeyNotFound", 1, "PROPOSTACONTRATO");
               AnyError = 1;
            }
         }
         pr_default.close(3);
         /* Using cursor BC00276 */
         pr_default.execute(4, new Object[] {n571PropostaAssinatura, A571PropostaAssinatura});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A571PropostaAssinatura) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Proposta Assinatura'.", "ForeignKeyNotFound", 1, "PROPOSTAASSINATURA");
               AnyError = 1;
            }
         }
         A574PropostaAssinaturaStatus = BC00276_A574PropostaAssinaturaStatus[0];
         n574PropostaAssinaturaStatus = BC00276_n574PropostaAssinaturaStatus[0];
         pr_default.close(4);
         if ( ! ( ( StringUtil.StrCmp(A573PropostaContratoAssinaturaTipo, "Contrato") == 0 ) || ( StringUtil.StrCmp(A573PropostaContratoAssinaturaTipo, "Nota_promissoria") == 0 ) || ( StringUtil.StrCmp(A573PropostaContratoAssinaturaTipo, "Nota_promissoria_clinica") == 0 ) || ( StringUtil.StrCmp(A573PropostaContratoAssinaturaTipo, "Nota_promissoria_clinica_taxa") == 0 ) || ( StringUtil.StrCmp(A573PropostaContratoAssinaturaTipo, "Documento") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A573PropostaContratoAssinaturaTipo)) ) )
         {
            GX_msglist.addItem("Campo Proposta Contrato Assinatura Tipo fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors2778( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2778( )
      {
         /* Using cursor BC00278 */
         pr_default.execute(6, new Object[] {n572PropostaContratoAssinaturaId, A572PropostaContratoAssinaturaId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound78 = 1;
         }
         else
         {
            RcdFound78 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00273 */
         pr_default.execute(1, new Object[] {n572PropostaContratoAssinaturaId, A572PropostaContratoAssinaturaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2778( 2) ;
            RcdFound78 = 1;
            A572PropostaContratoAssinaturaId = BC00273_A572PropostaContratoAssinaturaId[0];
            n572PropostaContratoAssinaturaId = BC00273_n572PropostaContratoAssinaturaId[0];
            A573PropostaContratoAssinaturaTipo = BC00273_A573PropostaContratoAssinaturaTipo[0];
            n573PropostaContratoAssinaturaTipo = BC00273_n573PropostaContratoAssinaturaTipo[0];
            A323PropostaId = BC00273_A323PropostaId[0];
            n323PropostaId = BC00273_n323PropostaId[0];
            A570PropostaContrato = BC00273_A570PropostaContrato[0];
            n570PropostaContrato = BC00273_n570PropostaContrato[0];
            A571PropostaAssinatura = BC00273_A571PropostaAssinatura[0];
            n571PropostaAssinatura = BC00273_n571PropostaAssinatura[0];
            Z572PropostaContratoAssinaturaId = A572PropostaContratoAssinaturaId;
            sMode78 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2778( ) ;
            if ( AnyError == 1 )
            {
               RcdFound78 = 0;
               InitializeNonKey2778( ) ;
            }
            Gx_mode = sMode78;
         }
         else
         {
            RcdFound78 = 0;
            InitializeNonKey2778( ) ;
            sMode78 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode78;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2778( ) ;
         if ( RcdFound78 == 0 )
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
         CONFIRM_270( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2778( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00272 */
            pr_default.execute(0, new Object[] {n572PropostaContratoAssinaturaId, A572PropostaContratoAssinaturaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PropostaContratoAssinatura"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z573PropostaContratoAssinaturaTipo, BC00272_A573PropostaContratoAssinaturaTipo[0]) != 0 ) || ( Z323PropostaId != BC00272_A323PropostaId[0] ) || ( Z570PropostaContrato != BC00272_A570PropostaContrato[0] ) || ( Z571PropostaAssinatura != BC00272_A571PropostaAssinatura[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PropostaContratoAssinatura"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2778( )
      {
         BeforeValidate2778( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2778( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2778( 0) ;
            CheckOptimisticConcurrency2778( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2778( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2778( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00279 */
                     pr_default.execute(7, new Object[] {n573PropostaContratoAssinaturaTipo, A573PropostaContratoAssinaturaTipo, n323PropostaId, A323PropostaId, n570PropostaContrato, A570PropostaContrato, n571PropostaAssinatura, A571PropostaAssinatura});
                     pr_default.close(7);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC002710 */
                     pr_default.execute(8);
                     A572PropostaContratoAssinaturaId = BC002710_A572PropostaContratoAssinaturaId[0];
                     n572PropostaContratoAssinaturaId = BC002710_n572PropostaContratoAssinaturaId[0];
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("PropostaContratoAssinatura");
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
               Load2778( ) ;
            }
            EndLevel2778( ) ;
         }
         CloseExtendedTableCursors2778( ) ;
      }

      protected void Update2778( )
      {
         BeforeValidate2778( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2778( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2778( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2778( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2778( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002711 */
                     pr_default.execute(9, new Object[] {n573PropostaContratoAssinaturaTipo, A573PropostaContratoAssinaturaTipo, n323PropostaId, A323PropostaId, n570PropostaContrato, A570PropostaContrato, n571PropostaAssinatura, A571PropostaAssinatura, n572PropostaContratoAssinaturaId, A572PropostaContratoAssinaturaId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("PropostaContratoAssinatura");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PropostaContratoAssinatura"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2778( ) ;
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
            EndLevel2778( ) ;
         }
         CloseExtendedTableCursors2778( ) ;
      }

      protected void DeferredUpdate2778( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2778( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2778( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2778( ) ;
            AfterConfirm2778( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2778( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002712 */
                  pr_default.execute(10, new Object[] {n572PropostaContratoAssinaturaId, A572PropostaContratoAssinaturaId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("PropostaContratoAssinatura");
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
         sMode78 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2778( ) ;
         Gx_mode = sMode78;
      }

      protected void OnDeleteControls2778( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC002713 */
            pr_default.execute(11, new Object[] {n571PropostaAssinatura, A571PropostaAssinatura});
            A574PropostaAssinaturaStatus = BC002713_A574PropostaAssinaturaStatus[0];
            n574PropostaAssinaturaStatus = BC002713_n574PropostaAssinaturaStatus[0];
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC002714 */
            pr_default.execute(12, new Object[] {n572PropostaContratoAssinaturaId, A572PropostaContratoAssinaturaId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ReembolsoAssinaturas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel2778( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2778( ) ;
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

      public void ScanKeyStart2778( )
      {
         /* Using cursor BC002715 */
         pr_default.execute(13, new Object[] {n572PropostaContratoAssinaturaId, A572PropostaContratoAssinaturaId});
         RcdFound78 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound78 = 1;
            A572PropostaContratoAssinaturaId = BC002715_A572PropostaContratoAssinaturaId[0];
            n572PropostaContratoAssinaturaId = BC002715_n572PropostaContratoAssinaturaId[0];
            A574PropostaAssinaturaStatus = BC002715_A574PropostaAssinaturaStatus[0];
            n574PropostaAssinaturaStatus = BC002715_n574PropostaAssinaturaStatus[0];
            A573PropostaContratoAssinaturaTipo = BC002715_A573PropostaContratoAssinaturaTipo[0];
            n573PropostaContratoAssinaturaTipo = BC002715_n573PropostaContratoAssinaturaTipo[0];
            A323PropostaId = BC002715_A323PropostaId[0];
            n323PropostaId = BC002715_n323PropostaId[0];
            A570PropostaContrato = BC002715_A570PropostaContrato[0];
            n570PropostaContrato = BC002715_n570PropostaContrato[0];
            A571PropostaAssinatura = BC002715_A571PropostaAssinatura[0];
            n571PropostaAssinatura = BC002715_n571PropostaAssinatura[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2778( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound78 = 0;
         ScanKeyLoad2778( ) ;
      }

      protected void ScanKeyLoad2778( )
      {
         sMode78 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound78 = 1;
            A572PropostaContratoAssinaturaId = BC002715_A572PropostaContratoAssinaturaId[0];
            n572PropostaContratoAssinaturaId = BC002715_n572PropostaContratoAssinaturaId[0];
            A574PropostaAssinaturaStatus = BC002715_A574PropostaAssinaturaStatus[0];
            n574PropostaAssinaturaStatus = BC002715_n574PropostaAssinaturaStatus[0];
            A573PropostaContratoAssinaturaTipo = BC002715_A573PropostaContratoAssinaturaTipo[0];
            n573PropostaContratoAssinaturaTipo = BC002715_n573PropostaContratoAssinaturaTipo[0];
            A323PropostaId = BC002715_A323PropostaId[0];
            n323PropostaId = BC002715_n323PropostaId[0];
            A570PropostaContrato = BC002715_A570PropostaContrato[0];
            n570PropostaContrato = BC002715_n570PropostaContrato[0];
            A571PropostaAssinatura = BC002715_A571PropostaAssinatura[0];
            n571PropostaAssinatura = BC002715_n571PropostaAssinatura[0];
         }
         Gx_mode = sMode78;
      }

      protected void ScanKeyEnd2778( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm2778( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2778( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2778( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2778( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2778( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2778( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2778( )
      {
      }

      protected void send_integrity_lvl_hashes2778( )
      {
      }

      protected void AddRow2778( )
      {
         VarsToRow78( bcPropostaContratoAssinatura) ;
      }

      protected void ReadRow2778( )
      {
         RowToVars78( bcPropostaContratoAssinatura, 1) ;
      }

      protected void InitializeNonKey2778( )
      {
         A323PropostaId = 0;
         n323PropostaId = false;
         A570PropostaContrato = 0;
         n570PropostaContrato = false;
         A571PropostaAssinatura = 0;
         n571PropostaAssinatura = false;
         A574PropostaAssinaturaStatus = "";
         n574PropostaAssinaturaStatus = false;
         A573PropostaContratoAssinaturaTipo = "";
         n573PropostaContratoAssinaturaTipo = false;
         Z573PropostaContratoAssinaturaTipo = "";
         Z323PropostaId = 0;
         Z570PropostaContrato = 0;
         Z571PropostaAssinatura = 0;
      }

      protected void InitAll2778( )
      {
         A572PropostaContratoAssinaturaId = 0;
         n572PropostaContratoAssinaturaId = false;
         InitializeNonKey2778( ) ;
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

      public void VarsToRow78( SdtPropostaContratoAssinatura obj78 )
      {
         obj78.gxTpr_Mode = Gx_mode;
         obj78.gxTpr_Propostaid = A323PropostaId;
         obj78.gxTpr_Propostacontrato = A570PropostaContrato;
         obj78.gxTpr_Propostaassinatura = A571PropostaAssinatura;
         obj78.gxTpr_Propostaassinaturastatus = A574PropostaAssinaturaStatus;
         obj78.gxTpr_Propostacontratoassinaturatipo = A573PropostaContratoAssinaturaTipo;
         obj78.gxTpr_Propostacontratoassinaturaid = A572PropostaContratoAssinaturaId;
         obj78.gxTpr_Propostacontratoassinaturaid_Z = Z572PropostaContratoAssinaturaId;
         obj78.gxTpr_Propostaid_Z = Z323PropostaId;
         obj78.gxTpr_Propostacontrato_Z = Z570PropostaContrato;
         obj78.gxTpr_Propostaassinatura_Z = Z571PropostaAssinatura;
         obj78.gxTpr_Propostaassinaturastatus_Z = Z574PropostaAssinaturaStatus;
         obj78.gxTpr_Propostacontratoassinaturatipo_Z = Z573PropostaContratoAssinaturaTipo;
         obj78.gxTpr_Propostacontratoassinaturaid_N = (short)(Convert.ToInt16(n572PropostaContratoAssinaturaId));
         obj78.gxTpr_Propostaid_N = (short)(Convert.ToInt16(n323PropostaId));
         obj78.gxTpr_Propostacontrato_N = (short)(Convert.ToInt16(n570PropostaContrato));
         obj78.gxTpr_Propostaassinatura_N = (short)(Convert.ToInt16(n571PropostaAssinatura));
         obj78.gxTpr_Propostaassinaturastatus_N = (short)(Convert.ToInt16(n574PropostaAssinaturaStatus));
         obj78.gxTpr_Propostacontratoassinaturatipo_N = (short)(Convert.ToInt16(n573PropostaContratoAssinaturaTipo));
         obj78.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow78( SdtPropostaContratoAssinatura obj78 )
      {
         obj78.gxTpr_Propostacontratoassinaturaid = A572PropostaContratoAssinaturaId;
         return  ;
      }

      public void RowToVars78( SdtPropostaContratoAssinatura obj78 ,
                               int forceLoad )
      {
         Gx_mode = obj78.gxTpr_Mode;
         A323PropostaId = obj78.gxTpr_Propostaid;
         n323PropostaId = false;
         A570PropostaContrato = obj78.gxTpr_Propostacontrato;
         n570PropostaContrato = false;
         A571PropostaAssinatura = obj78.gxTpr_Propostaassinatura;
         n571PropostaAssinatura = false;
         A574PropostaAssinaturaStatus = obj78.gxTpr_Propostaassinaturastatus;
         n574PropostaAssinaturaStatus = false;
         A573PropostaContratoAssinaturaTipo = obj78.gxTpr_Propostacontratoassinaturatipo;
         n573PropostaContratoAssinaturaTipo = false;
         A572PropostaContratoAssinaturaId = obj78.gxTpr_Propostacontratoassinaturaid;
         n572PropostaContratoAssinaturaId = false;
         Z572PropostaContratoAssinaturaId = obj78.gxTpr_Propostacontratoassinaturaid_Z;
         Z323PropostaId = obj78.gxTpr_Propostaid_Z;
         Z570PropostaContrato = obj78.gxTpr_Propostacontrato_Z;
         Z571PropostaAssinatura = obj78.gxTpr_Propostaassinatura_Z;
         Z574PropostaAssinaturaStatus = obj78.gxTpr_Propostaassinaturastatus_Z;
         Z573PropostaContratoAssinaturaTipo = obj78.gxTpr_Propostacontratoassinaturatipo_Z;
         n572PropostaContratoAssinaturaId = (bool)(Convert.ToBoolean(obj78.gxTpr_Propostacontratoassinaturaid_N));
         n323PropostaId = (bool)(Convert.ToBoolean(obj78.gxTpr_Propostaid_N));
         n570PropostaContrato = (bool)(Convert.ToBoolean(obj78.gxTpr_Propostacontrato_N));
         n571PropostaAssinatura = (bool)(Convert.ToBoolean(obj78.gxTpr_Propostaassinatura_N));
         n574PropostaAssinaturaStatus = (bool)(Convert.ToBoolean(obj78.gxTpr_Propostaassinaturastatus_N));
         n573PropostaContratoAssinaturaTipo = (bool)(Convert.ToBoolean(obj78.gxTpr_Propostacontratoassinaturatipo_N));
         Gx_mode = obj78.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A572PropostaContratoAssinaturaId = (int)getParm(obj,0);
         n572PropostaContratoAssinaturaId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2778( ) ;
         ScanKeyStart2778( ) ;
         if ( RcdFound78 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z572PropostaContratoAssinaturaId = A572PropostaContratoAssinaturaId;
         }
         ZM2778( -2) ;
         OnLoadActions2778( ) ;
         AddRow2778( ) ;
         ScanKeyEnd2778( ) ;
         if ( RcdFound78 == 0 )
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
         RowToVars78( bcPropostaContratoAssinatura, 0) ;
         ScanKeyStart2778( ) ;
         if ( RcdFound78 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z572PropostaContratoAssinaturaId = A572PropostaContratoAssinaturaId;
         }
         ZM2778( -2) ;
         OnLoadActions2778( ) ;
         AddRow2778( ) ;
         ScanKeyEnd2778( ) ;
         if ( RcdFound78 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2778( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2778( ) ;
         }
         else
         {
            if ( RcdFound78 == 1 )
            {
               if ( A572PropostaContratoAssinaturaId != Z572PropostaContratoAssinaturaId )
               {
                  A572PropostaContratoAssinaturaId = Z572PropostaContratoAssinaturaId;
                  n572PropostaContratoAssinaturaId = false;
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
                  Update2778( ) ;
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
                  if ( A572PropostaContratoAssinaturaId != Z572PropostaContratoAssinaturaId )
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
                        Insert2778( ) ;
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
                        Insert2778( ) ;
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
         RowToVars78( bcPropostaContratoAssinatura, 1) ;
         SaveImpl( ) ;
         VarsToRow78( bcPropostaContratoAssinatura) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars78( bcPropostaContratoAssinatura, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2778( ) ;
         AfterTrn( ) ;
         VarsToRow78( bcPropostaContratoAssinatura) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow78( bcPropostaContratoAssinatura) ;
         }
         else
         {
            SdtPropostaContratoAssinatura auxBC = new SdtPropostaContratoAssinatura(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A572PropostaContratoAssinaturaId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcPropostaContratoAssinatura);
               auxBC.Save();
               bcPropostaContratoAssinatura.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars78( bcPropostaContratoAssinatura, 1) ;
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
         RowToVars78( bcPropostaContratoAssinatura, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2778( ) ;
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
               VarsToRow78( bcPropostaContratoAssinatura) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow78( bcPropostaContratoAssinatura) ;
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
         RowToVars78( bcPropostaContratoAssinatura, 0) ;
         GetKey2778( ) ;
         if ( RcdFound78 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A572PropostaContratoAssinaturaId != Z572PropostaContratoAssinaturaId )
            {
               A572PropostaContratoAssinaturaId = Z572PropostaContratoAssinaturaId;
               n572PropostaContratoAssinaturaId = false;
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
            if ( A572PropostaContratoAssinaturaId != Z572PropostaContratoAssinaturaId )
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
         context.RollbackDataStores("propostacontratoassinatura_bc",pr_default);
         VarsToRow78( bcPropostaContratoAssinatura) ;
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
         Gx_mode = bcPropostaContratoAssinatura.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcPropostaContratoAssinatura.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcPropostaContratoAssinatura )
         {
            bcPropostaContratoAssinatura = (SdtPropostaContratoAssinatura)(sdt);
            if ( StringUtil.StrCmp(bcPropostaContratoAssinatura.gxTpr_Mode, "") == 0 )
            {
               bcPropostaContratoAssinatura.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow78( bcPropostaContratoAssinatura) ;
            }
            else
            {
               RowToVars78( bcPropostaContratoAssinatura, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcPropostaContratoAssinatura.gxTpr_Mode, "") == 0 )
            {
               bcPropostaContratoAssinatura.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars78( bcPropostaContratoAssinatura, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtPropostaContratoAssinatura PropostaContratoAssinatura_BC
      {
         get {
            return bcPropostaContratoAssinatura ;
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
         Z573PropostaContratoAssinaturaTipo = "";
         A573PropostaContratoAssinaturaTipo = "";
         Z574PropostaAssinaturaStatus = "";
         A574PropostaAssinaturaStatus = "";
         BC00277_A572PropostaContratoAssinaturaId = new int[1] ;
         BC00277_n572PropostaContratoAssinaturaId = new bool[] {false} ;
         BC00277_A574PropostaAssinaturaStatus = new string[] {""} ;
         BC00277_n574PropostaAssinaturaStatus = new bool[] {false} ;
         BC00277_A573PropostaContratoAssinaturaTipo = new string[] {""} ;
         BC00277_n573PropostaContratoAssinaturaTipo = new bool[] {false} ;
         BC00277_A323PropostaId = new int[1] ;
         BC00277_n323PropostaId = new bool[] {false} ;
         BC00277_A570PropostaContrato = new int[1] ;
         BC00277_n570PropostaContrato = new bool[] {false} ;
         BC00277_A571PropostaAssinatura = new long[1] ;
         BC00277_n571PropostaAssinatura = new bool[] {false} ;
         BC00274_A323PropostaId = new int[1] ;
         BC00274_n323PropostaId = new bool[] {false} ;
         BC00275_A570PropostaContrato = new int[1] ;
         BC00275_n570PropostaContrato = new bool[] {false} ;
         BC00276_A574PropostaAssinaturaStatus = new string[] {""} ;
         BC00276_n574PropostaAssinaturaStatus = new bool[] {false} ;
         BC00278_A572PropostaContratoAssinaturaId = new int[1] ;
         BC00278_n572PropostaContratoAssinaturaId = new bool[] {false} ;
         BC00273_A572PropostaContratoAssinaturaId = new int[1] ;
         BC00273_n572PropostaContratoAssinaturaId = new bool[] {false} ;
         BC00273_A573PropostaContratoAssinaturaTipo = new string[] {""} ;
         BC00273_n573PropostaContratoAssinaturaTipo = new bool[] {false} ;
         BC00273_A323PropostaId = new int[1] ;
         BC00273_n323PropostaId = new bool[] {false} ;
         BC00273_A570PropostaContrato = new int[1] ;
         BC00273_n570PropostaContrato = new bool[] {false} ;
         BC00273_A571PropostaAssinatura = new long[1] ;
         BC00273_n571PropostaAssinatura = new bool[] {false} ;
         sMode78 = "";
         BC00272_A572PropostaContratoAssinaturaId = new int[1] ;
         BC00272_n572PropostaContratoAssinaturaId = new bool[] {false} ;
         BC00272_A573PropostaContratoAssinaturaTipo = new string[] {""} ;
         BC00272_n573PropostaContratoAssinaturaTipo = new bool[] {false} ;
         BC00272_A323PropostaId = new int[1] ;
         BC00272_n323PropostaId = new bool[] {false} ;
         BC00272_A570PropostaContrato = new int[1] ;
         BC00272_n570PropostaContrato = new bool[] {false} ;
         BC00272_A571PropostaAssinatura = new long[1] ;
         BC00272_n571PropostaAssinatura = new bool[] {false} ;
         BC002710_A572PropostaContratoAssinaturaId = new int[1] ;
         BC002710_n572PropostaContratoAssinaturaId = new bool[] {false} ;
         BC002713_A574PropostaAssinaturaStatus = new string[] {""} ;
         BC002713_n574PropostaAssinaturaStatus = new bool[] {false} ;
         BC002714_A631ReembolsoAssinaturasId = new int[1] ;
         BC002715_A572PropostaContratoAssinaturaId = new int[1] ;
         BC002715_n572PropostaContratoAssinaturaId = new bool[] {false} ;
         BC002715_A574PropostaAssinaturaStatus = new string[] {""} ;
         BC002715_n574PropostaAssinaturaStatus = new bool[] {false} ;
         BC002715_A573PropostaContratoAssinaturaTipo = new string[] {""} ;
         BC002715_n573PropostaContratoAssinaturaTipo = new bool[] {false} ;
         BC002715_A323PropostaId = new int[1] ;
         BC002715_n323PropostaId = new bool[] {false} ;
         BC002715_A570PropostaContrato = new int[1] ;
         BC002715_n570PropostaContrato = new bool[] {false} ;
         BC002715_A571PropostaAssinatura = new long[1] ;
         BC002715_n571PropostaAssinatura = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.propostacontratoassinatura_bc__default(),
            new Object[][] {
                new Object[] {
               BC00272_A572PropostaContratoAssinaturaId, BC00272_A573PropostaContratoAssinaturaTipo, BC00272_n573PropostaContratoAssinaturaTipo, BC00272_A323PropostaId, BC00272_n323PropostaId, BC00272_A570PropostaContrato, BC00272_n570PropostaContrato, BC00272_A571PropostaAssinatura, BC00272_n571PropostaAssinatura
               }
               , new Object[] {
               BC00273_A572PropostaContratoAssinaturaId, BC00273_A573PropostaContratoAssinaturaTipo, BC00273_n573PropostaContratoAssinaturaTipo, BC00273_A323PropostaId, BC00273_n323PropostaId, BC00273_A570PropostaContrato, BC00273_n570PropostaContrato, BC00273_A571PropostaAssinatura, BC00273_n571PropostaAssinatura
               }
               , new Object[] {
               BC00274_A323PropostaId
               }
               , new Object[] {
               BC00275_A570PropostaContrato
               }
               , new Object[] {
               BC00276_A574PropostaAssinaturaStatus, BC00276_n574PropostaAssinaturaStatus
               }
               , new Object[] {
               BC00277_A572PropostaContratoAssinaturaId, BC00277_A574PropostaAssinaturaStatus, BC00277_n574PropostaAssinaturaStatus, BC00277_A573PropostaContratoAssinaturaTipo, BC00277_n573PropostaContratoAssinaturaTipo, BC00277_A323PropostaId, BC00277_n323PropostaId, BC00277_A570PropostaContrato, BC00277_n570PropostaContrato, BC00277_A571PropostaAssinatura,
               BC00277_n571PropostaAssinatura
               }
               , new Object[] {
               BC00278_A572PropostaContratoAssinaturaId
               }
               , new Object[] {
               }
               , new Object[] {
               BC002710_A572PropostaContratoAssinaturaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002713_A574PropostaAssinaturaStatus, BC002713_n574PropostaAssinaturaStatus
               }
               , new Object[] {
               BC002714_A631ReembolsoAssinaturasId
               }
               , new Object[] {
               BC002715_A572PropostaContratoAssinaturaId, BC002715_A574PropostaAssinaturaStatus, BC002715_n574PropostaAssinaturaStatus, BC002715_A573PropostaContratoAssinaturaTipo, BC002715_n573PropostaContratoAssinaturaTipo, BC002715_A323PropostaId, BC002715_n323PropostaId, BC002715_A570PropostaContrato, BC002715_n570PropostaContrato, BC002715_A571PropostaAssinatura,
               BC002715_n571PropostaAssinatura
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound78 ;
      private int trnEnded ;
      private int Z572PropostaContratoAssinaturaId ;
      private int A572PropostaContratoAssinaturaId ;
      private int Z323PropostaId ;
      private int A323PropostaId ;
      private int Z570PropostaContrato ;
      private int A570PropostaContrato ;
      private long Z571PropostaAssinatura ;
      private long A571PropostaAssinatura ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode78 ;
      private bool n572PropostaContratoAssinaturaId ;
      private bool n574PropostaAssinaturaStatus ;
      private bool n573PropostaContratoAssinaturaTipo ;
      private bool n323PropostaId ;
      private bool n570PropostaContrato ;
      private bool n571PropostaAssinatura ;
      private string Z573PropostaContratoAssinaturaTipo ;
      private string A573PropostaContratoAssinaturaTipo ;
      private string Z574PropostaAssinaturaStatus ;
      private string A574PropostaAssinaturaStatus ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00277_A572PropostaContratoAssinaturaId ;
      private bool[] BC00277_n572PropostaContratoAssinaturaId ;
      private string[] BC00277_A574PropostaAssinaturaStatus ;
      private bool[] BC00277_n574PropostaAssinaturaStatus ;
      private string[] BC00277_A573PropostaContratoAssinaturaTipo ;
      private bool[] BC00277_n573PropostaContratoAssinaturaTipo ;
      private int[] BC00277_A323PropostaId ;
      private bool[] BC00277_n323PropostaId ;
      private int[] BC00277_A570PropostaContrato ;
      private bool[] BC00277_n570PropostaContrato ;
      private long[] BC00277_A571PropostaAssinatura ;
      private bool[] BC00277_n571PropostaAssinatura ;
      private int[] BC00274_A323PropostaId ;
      private bool[] BC00274_n323PropostaId ;
      private int[] BC00275_A570PropostaContrato ;
      private bool[] BC00275_n570PropostaContrato ;
      private string[] BC00276_A574PropostaAssinaturaStatus ;
      private bool[] BC00276_n574PropostaAssinaturaStatus ;
      private int[] BC00278_A572PropostaContratoAssinaturaId ;
      private bool[] BC00278_n572PropostaContratoAssinaturaId ;
      private int[] BC00273_A572PropostaContratoAssinaturaId ;
      private bool[] BC00273_n572PropostaContratoAssinaturaId ;
      private string[] BC00273_A573PropostaContratoAssinaturaTipo ;
      private bool[] BC00273_n573PropostaContratoAssinaturaTipo ;
      private int[] BC00273_A323PropostaId ;
      private bool[] BC00273_n323PropostaId ;
      private int[] BC00273_A570PropostaContrato ;
      private bool[] BC00273_n570PropostaContrato ;
      private long[] BC00273_A571PropostaAssinatura ;
      private bool[] BC00273_n571PropostaAssinatura ;
      private int[] BC00272_A572PropostaContratoAssinaturaId ;
      private bool[] BC00272_n572PropostaContratoAssinaturaId ;
      private string[] BC00272_A573PropostaContratoAssinaturaTipo ;
      private bool[] BC00272_n573PropostaContratoAssinaturaTipo ;
      private int[] BC00272_A323PropostaId ;
      private bool[] BC00272_n323PropostaId ;
      private int[] BC00272_A570PropostaContrato ;
      private bool[] BC00272_n570PropostaContrato ;
      private long[] BC00272_A571PropostaAssinatura ;
      private bool[] BC00272_n571PropostaAssinatura ;
      private int[] BC002710_A572PropostaContratoAssinaturaId ;
      private bool[] BC002710_n572PropostaContratoAssinaturaId ;
      private string[] BC002713_A574PropostaAssinaturaStatus ;
      private bool[] BC002713_n574PropostaAssinaturaStatus ;
      private int[] BC002714_A631ReembolsoAssinaturasId ;
      private int[] BC002715_A572PropostaContratoAssinaturaId ;
      private bool[] BC002715_n572PropostaContratoAssinaturaId ;
      private string[] BC002715_A574PropostaAssinaturaStatus ;
      private bool[] BC002715_n574PropostaAssinaturaStatus ;
      private string[] BC002715_A573PropostaContratoAssinaturaTipo ;
      private bool[] BC002715_n573PropostaContratoAssinaturaTipo ;
      private int[] BC002715_A323PropostaId ;
      private bool[] BC002715_n323PropostaId ;
      private int[] BC002715_A570PropostaContrato ;
      private bool[] BC002715_n570PropostaContrato ;
      private long[] BC002715_A571PropostaAssinatura ;
      private bool[] BC002715_n571PropostaAssinatura ;
      private SdtPropostaContratoAssinatura bcPropostaContratoAssinatura ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class propostacontratoassinatura_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00272;
          prmBC00272 = new Object[] {
          new ParDef("PropostaContratoAssinaturaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00273;
          prmBC00273 = new Object[] {
          new ParDef("PropostaContratoAssinaturaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00274;
          prmBC00274 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00275;
          prmBC00275 = new Object[] {
          new ParDef("PropostaContrato",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC00276;
          prmBC00276 = new Object[] {
          new ParDef("PropostaAssinatura",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmBC00277;
          prmBC00277 = new Object[] {
          new ParDef("PropostaContratoAssinaturaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00278;
          prmBC00278 = new Object[] {
          new ParDef("PropostaContratoAssinaturaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00279;
          prmBC00279 = new Object[] {
          new ParDef("PropostaContratoAssinaturaTipo",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaContrato",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("PropostaAssinatura",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmBC002710;
          prmBC002710 = new Object[] {
          };
          Object[] prmBC002711;
          prmBC002711 = new Object[] {
          new ParDef("PropostaContratoAssinaturaTipo",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaContrato",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("PropostaAssinatura",GXType.Int64,10,0){Nullable=true} ,
          new ParDef("PropostaContratoAssinaturaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002712;
          prmBC002712 = new Object[] {
          new ParDef("PropostaContratoAssinaturaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002713;
          prmBC002713 = new Object[] {
          new ParDef("PropostaAssinatura",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmBC002714;
          prmBC002714 = new Object[] {
          new ParDef("PropostaContratoAssinaturaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002715;
          prmBC002715 = new Object[] {
          new ParDef("PropostaContratoAssinaturaId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC00272", "SELECT PropostaContratoAssinaturaId, PropostaContratoAssinaturaTipo, PropostaId, PropostaContrato, PropostaAssinatura FROM PropostaContratoAssinatura WHERE PropostaContratoAssinaturaId = :PropostaContratoAssinaturaId  FOR UPDATE OF PropostaContratoAssinatura",true, GxErrorMask.GX_NOMASK, false, this,prmBC00272,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00273", "SELECT PropostaContratoAssinaturaId, PropostaContratoAssinaturaTipo, PropostaId, PropostaContrato, PropostaAssinatura FROM PropostaContratoAssinatura WHERE PropostaContratoAssinaturaId = :PropostaContratoAssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00273,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00274", "SELECT PropostaId FROM Proposta WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00274,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00275", "SELECT ContratoId AS PropostaContrato FROM Contrato WHERE ContratoId = :PropostaContrato ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00275,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00276", "SELECT AssinaturaStatus AS PropostaAssinaturaStatus FROM Assinatura WHERE AssinaturaId = :PropostaAssinatura ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00276,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00277", "SELECT TM1.PropostaContratoAssinaturaId, T2.AssinaturaStatus AS PropostaAssinaturaStatus, TM1.PropostaContratoAssinaturaTipo, TM1.PropostaId, TM1.PropostaContrato AS PropostaContrato, TM1.PropostaAssinatura AS PropostaAssinatura FROM (PropostaContratoAssinatura TM1 LEFT JOIN Assinatura T2 ON T2.AssinaturaId = TM1.PropostaAssinatura) WHERE TM1.PropostaContratoAssinaturaId = :PropostaContratoAssinaturaId ORDER BY TM1.PropostaContratoAssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00277,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00278", "SELECT PropostaContratoAssinaturaId FROM PropostaContratoAssinatura WHERE PropostaContratoAssinaturaId = :PropostaContratoAssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00278,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00279", "SAVEPOINT gxupdate;INSERT INTO PropostaContratoAssinatura(PropostaContratoAssinaturaTipo, PropostaId, PropostaContrato, PropostaAssinatura) VALUES(:PropostaContratoAssinaturaTipo, :PropostaId, :PropostaContrato, :PropostaAssinatura);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00279)
             ,new CursorDef("BC002710", "SELECT currval('PropostaContratoAssinaturaId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002710,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002711", "SAVEPOINT gxupdate;UPDATE PropostaContratoAssinatura SET PropostaContratoAssinaturaTipo=:PropostaContratoAssinaturaTipo, PropostaId=:PropostaId, PropostaContrato=:PropostaContrato, PropostaAssinatura=:PropostaAssinatura  WHERE PropostaContratoAssinaturaId = :PropostaContratoAssinaturaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002711)
             ,new CursorDef("BC002712", "SAVEPOINT gxupdate;DELETE FROM PropostaContratoAssinatura  WHERE PropostaContratoAssinaturaId = :PropostaContratoAssinaturaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002712)
             ,new CursorDef("BC002713", "SELECT AssinaturaStatus AS PropostaAssinaturaStatus FROM Assinatura WHERE AssinaturaId = :PropostaAssinatura ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002713,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002714", "SELECT ReembolsoAssinaturasId FROM ReembolsoAssinaturas WHERE PropostaContratoAssinaturaId = :PropostaContratoAssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002714,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002715", "SELECT TM1.PropostaContratoAssinaturaId, T2.AssinaturaStatus AS PropostaAssinaturaStatus, TM1.PropostaContratoAssinaturaTipo, TM1.PropostaId, TM1.PropostaContrato AS PropostaContrato, TM1.PropostaAssinatura AS PropostaAssinatura FROM (PropostaContratoAssinatura TM1 LEFT JOIN Assinatura T2 ON T2.AssinaturaId = TM1.PropostaAssinatura) WHERE TM1.PropostaContratoAssinaturaId = :PropostaContratoAssinaturaId ORDER BY TM1.PropostaContratoAssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002715,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((long[]) buf[7])[0] = rslt.getLong(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((long[]) buf[7])[0] = rslt.getLong(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((long[]) buf[9])[0] = rslt.getLong(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((long[]) buf[9])[0] = rslt.getLong(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
       }
    }

 }

}
