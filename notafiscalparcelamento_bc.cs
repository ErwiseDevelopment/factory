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
   public class notafiscalparcelamento_bc : GxSilentTrn, IGxSilentTrn
   {
      public notafiscalparcelamento_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public notafiscalparcelamento_bc( IGxContext context )
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
         ReadRow2T97( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2T97( ) ;
         standaloneModal( ) ;
         AddRow2T97( ) ;
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
            E112T2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z890NotaFiscalParcelamentoID = A890NotaFiscalParcelamentoID;
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

      protected void CONFIRM_2T0( )
      {
         BeforeValidate2T97( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2T97( ) ;
            }
            else
            {
               CheckExtendedTable2T97( ) ;
               if ( AnyError == 0 )
               {
                  ZM2T97( 10) ;
               }
               CloseExtendedTableCursors2T97( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E122T2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV19Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV20GXV1 = 1;
            while ( AV20GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV20GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "NotaFiscalId") == 0 )
               {
                  AV11Insert_NotaFiscalId = StringUtil.StrToGuid( AV12TrnContextAtt.gxTpr_Attributevalue);
               }
               AV20GXV1 = (int)(AV20GXV1+1);
            }
         }
      }

      protected void E112T2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM2T97( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z891NotaFiscalParcelamentoNumero = A891NotaFiscalParcelamentoNumero;
            Z892NotaFiscalParcelamentoValor = A892NotaFiscalParcelamentoValor;
            Z893NotaFiscalParcelamentoVencimento = A893NotaFiscalParcelamentoVencimento;
            Z895NotaFiscalParcelamentoValorTaxaAdministrativa = A895NotaFiscalParcelamentoValorTaxaAdministrativa;
            Z896NotaFiscalParcelamentoValorTaxaAnual = A896NotaFiscalParcelamentoValorTaxaAnual;
            Z897NotaFiscalParcelamentoLiquido = A897NotaFiscalParcelamentoLiquido;
            Z794NotaFiscalId = A794NotaFiscalId;
         }
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z799NotaFiscalNumero = A799NotaFiscalNumero;
         }
         if ( GX_JID == -9 )
         {
            Z890NotaFiscalParcelamentoID = A890NotaFiscalParcelamentoID;
            Z891NotaFiscalParcelamentoNumero = A891NotaFiscalParcelamentoNumero;
            Z892NotaFiscalParcelamentoValor = A892NotaFiscalParcelamentoValor;
            Z893NotaFiscalParcelamentoVencimento = A893NotaFiscalParcelamentoVencimento;
            Z895NotaFiscalParcelamentoValorTaxaAdministrativa = A895NotaFiscalParcelamentoValorTaxaAdministrativa;
            Z896NotaFiscalParcelamentoValorTaxaAnual = A896NotaFiscalParcelamentoValorTaxaAnual;
            Z897NotaFiscalParcelamentoLiquido = A897NotaFiscalParcelamentoLiquido;
            Z794NotaFiscalId = A794NotaFiscalId;
            Z799NotaFiscalNumero = A799NotaFiscalNumero;
         }
      }

      protected void standaloneNotModal( )
      {
         AV19Pgmname = "NotaFiscalParcelamento_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A890NotaFiscalParcelamentoID) )
         {
            A890NotaFiscalParcelamentoID = Guid.NewGuid( );
            n890NotaFiscalParcelamentoID = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load2T97( )
      {
         /* Using cursor BC002T5 */
         pr_default.execute(3, new Object[] {n890NotaFiscalParcelamentoID, A890NotaFiscalParcelamentoID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound97 = 1;
            A799NotaFiscalNumero = BC002T5_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = BC002T5_n799NotaFiscalNumero[0];
            A891NotaFiscalParcelamentoNumero = BC002T5_A891NotaFiscalParcelamentoNumero[0];
            n891NotaFiscalParcelamentoNumero = BC002T5_n891NotaFiscalParcelamentoNumero[0];
            A892NotaFiscalParcelamentoValor = BC002T5_A892NotaFiscalParcelamentoValor[0];
            n892NotaFiscalParcelamentoValor = BC002T5_n892NotaFiscalParcelamentoValor[0];
            A893NotaFiscalParcelamentoVencimento = BC002T5_A893NotaFiscalParcelamentoVencimento[0];
            n893NotaFiscalParcelamentoVencimento = BC002T5_n893NotaFiscalParcelamentoVencimento[0];
            A895NotaFiscalParcelamentoValorTaxaAdministrativa = BC002T5_A895NotaFiscalParcelamentoValorTaxaAdministrativa[0];
            n895NotaFiscalParcelamentoValorTaxaAdministrativa = BC002T5_n895NotaFiscalParcelamentoValorTaxaAdministrativa[0];
            A896NotaFiscalParcelamentoValorTaxaAnual = BC002T5_A896NotaFiscalParcelamentoValorTaxaAnual[0];
            n896NotaFiscalParcelamentoValorTaxaAnual = BC002T5_n896NotaFiscalParcelamentoValorTaxaAnual[0];
            A897NotaFiscalParcelamentoLiquido = BC002T5_A897NotaFiscalParcelamentoLiquido[0];
            n897NotaFiscalParcelamentoLiquido = BC002T5_n897NotaFiscalParcelamentoLiquido[0];
            A794NotaFiscalId = BC002T5_A794NotaFiscalId[0];
            n794NotaFiscalId = BC002T5_n794NotaFiscalId[0];
            ZM2T97( -9) ;
         }
         pr_default.close(3);
         OnLoadActions2T97( ) ;
      }

      protected void OnLoadActions2T97( )
      {
      }

      protected void CheckExtendedTable2T97( )
      {
         standaloneModal( ) ;
         /* Using cursor BC002T4 */
         pr_default.execute(2, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (Guid.Empty==A794NotaFiscalId) ) )
            {
               GX_msglist.addItem("Não existe 'NotaFiscal'.", "ForeignKeyNotFound", 1, "NOTAFISCALID");
               AnyError = 1;
            }
         }
         A799NotaFiscalNumero = BC002T4_A799NotaFiscalNumero[0];
         n799NotaFiscalNumero = BC002T4_n799NotaFiscalNumero[0];
         pr_default.close(2);
         if ( ( A892NotaFiscalParcelamentoValor < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         if ( ( A895NotaFiscalParcelamentoValorTaxaAdministrativa < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         if ( ( A896NotaFiscalParcelamentoValorTaxaAnual < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors2T97( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2T97( )
      {
         /* Using cursor BC002T6 */
         pr_default.execute(4, new Object[] {n890NotaFiscalParcelamentoID, A890NotaFiscalParcelamentoID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound97 = 1;
         }
         else
         {
            RcdFound97 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC002T3 */
         pr_default.execute(1, new Object[] {n890NotaFiscalParcelamentoID, A890NotaFiscalParcelamentoID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2T97( 9) ;
            RcdFound97 = 1;
            A890NotaFiscalParcelamentoID = BC002T3_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = BC002T3_n890NotaFiscalParcelamentoID[0];
            A891NotaFiscalParcelamentoNumero = BC002T3_A891NotaFiscalParcelamentoNumero[0];
            n891NotaFiscalParcelamentoNumero = BC002T3_n891NotaFiscalParcelamentoNumero[0];
            A892NotaFiscalParcelamentoValor = BC002T3_A892NotaFiscalParcelamentoValor[0];
            n892NotaFiscalParcelamentoValor = BC002T3_n892NotaFiscalParcelamentoValor[0];
            A893NotaFiscalParcelamentoVencimento = BC002T3_A893NotaFiscalParcelamentoVencimento[0];
            n893NotaFiscalParcelamentoVencimento = BC002T3_n893NotaFiscalParcelamentoVencimento[0];
            A895NotaFiscalParcelamentoValorTaxaAdministrativa = BC002T3_A895NotaFiscalParcelamentoValorTaxaAdministrativa[0];
            n895NotaFiscalParcelamentoValorTaxaAdministrativa = BC002T3_n895NotaFiscalParcelamentoValorTaxaAdministrativa[0];
            A896NotaFiscalParcelamentoValorTaxaAnual = BC002T3_A896NotaFiscalParcelamentoValorTaxaAnual[0];
            n896NotaFiscalParcelamentoValorTaxaAnual = BC002T3_n896NotaFiscalParcelamentoValorTaxaAnual[0];
            A897NotaFiscalParcelamentoLiquido = BC002T3_A897NotaFiscalParcelamentoLiquido[0];
            n897NotaFiscalParcelamentoLiquido = BC002T3_n897NotaFiscalParcelamentoLiquido[0];
            A794NotaFiscalId = BC002T3_A794NotaFiscalId[0];
            n794NotaFiscalId = BC002T3_n794NotaFiscalId[0];
            Z890NotaFiscalParcelamentoID = A890NotaFiscalParcelamentoID;
            sMode97 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2T97( ) ;
            if ( AnyError == 1 )
            {
               RcdFound97 = 0;
               InitializeNonKey2T97( ) ;
            }
            Gx_mode = sMode97;
         }
         else
         {
            RcdFound97 = 0;
            InitializeNonKey2T97( ) ;
            sMode97 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode97;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2T97( ) ;
         if ( RcdFound97 == 0 )
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
         CONFIRM_2T0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2T97( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC002T2 */
            pr_default.execute(0, new Object[] {n890NotaFiscalParcelamentoID, A890NotaFiscalParcelamentoID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"NotaFiscalParcelamento"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z891NotaFiscalParcelamentoNumero, BC002T2_A891NotaFiscalParcelamentoNumero[0]) != 0 ) || ( Z892NotaFiscalParcelamentoValor != BC002T2_A892NotaFiscalParcelamentoValor[0] ) || ( DateTimeUtil.ResetTime ( Z893NotaFiscalParcelamentoVencimento ) != DateTimeUtil.ResetTime ( BC002T2_A893NotaFiscalParcelamentoVencimento[0] ) ) || ( Z895NotaFiscalParcelamentoValorTaxaAdministrativa != BC002T2_A895NotaFiscalParcelamentoValorTaxaAdministrativa[0] ) || ( Z896NotaFiscalParcelamentoValorTaxaAnual != BC002T2_A896NotaFiscalParcelamentoValorTaxaAnual[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z897NotaFiscalParcelamentoLiquido != BC002T2_A897NotaFiscalParcelamentoLiquido[0] ) || ( Z794NotaFiscalId != BC002T2_A794NotaFiscalId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"NotaFiscalParcelamento"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2T97( )
      {
         BeforeValidate2T97( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2T97( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2T97( 0) ;
            CheckOptimisticConcurrency2T97( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2T97( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2T97( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002T7 */
                     pr_default.execute(5, new Object[] {n890NotaFiscalParcelamentoID, A890NotaFiscalParcelamentoID, n891NotaFiscalParcelamentoNumero, A891NotaFiscalParcelamentoNumero, n892NotaFiscalParcelamentoValor, A892NotaFiscalParcelamentoValor, n893NotaFiscalParcelamentoVencimento, A893NotaFiscalParcelamentoVencimento, n895NotaFiscalParcelamentoValorTaxaAdministrativa, A895NotaFiscalParcelamentoValorTaxaAdministrativa, n896NotaFiscalParcelamentoValorTaxaAnual, A896NotaFiscalParcelamentoValorTaxaAnual, n897NotaFiscalParcelamentoLiquido, A897NotaFiscalParcelamentoLiquido, n794NotaFiscalId, A794NotaFiscalId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("NotaFiscalParcelamento");
                     if ( (pr_default.getStatus(5) == 1) )
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
               Load2T97( ) ;
            }
            EndLevel2T97( ) ;
         }
         CloseExtendedTableCursors2T97( ) ;
      }

      protected void Update2T97( )
      {
         BeforeValidate2T97( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2T97( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2T97( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2T97( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2T97( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002T8 */
                     pr_default.execute(6, new Object[] {n891NotaFiscalParcelamentoNumero, A891NotaFiscalParcelamentoNumero, n892NotaFiscalParcelamentoValor, A892NotaFiscalParcelamentoValor, n893NotaFiscalParcelamentoVencimento, A893NotaFiscalParcelamentoVencimento, n895NotaFiscalParcelamentoValorTaxaAdministrativa, A895NotaFiscalParcelamentoValorTaxaAdministrativa, n896NotaFiscalParcelamentoValorTaxaAnual, A896NotaFiscalParcelamentoValorTaxaAnual, n897NotaFiscalParcelamentoLiquido, A897NotaFiscalParcelamentoLiquido, n794NotaFiscalId, A794NotaFiscalId, n890NotaFiscalParcelamentoID, A890NotaFiscalParcelamentoID});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("NotaFiscalParcelamento");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"NotaFiscalParcelamento"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2T97( ) ;
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
            EndLevel2T97( ) ;
         }
         CloseExtendedTableCursors2T97( ) ;
      }

      protected void DeferredUpdate2T97( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2T97( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2T97( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2T97( ) ;
            AfterConfirm2T97( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2T97( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002T9 */
                  pr_default.execute(7, new Object[] {n890NotaFiscalParcelamentoID, A890NotaFiscalParcelamentoID});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("NotaFiscalParcelamento");
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
         sMode97 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2T97( ) ;
         Gx_mode = sMode97;
      }

      protected void OnDeleteControls2T97( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC002T10 */
            pr_default.execute(8, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
            A799NotaFiscalNumero = BC002T10_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = BC002T10_n799NotaFiscalNumero[0];
            pr_default.close(8);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC002T11 */
            pr_default.execute(9, new Object[] {n890NotaFiscalParcelamentoID, A890NotaFiscalParcelamentoID});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Titulo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel2T97( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2T97( ) ;
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

      public void ScanKeyStart2T97( )
      {
         /* Scan By routine */
         /* Using cursor BC002T12 */
         pr_default.execute(10, new Object[] {n890NotaFiscalParcelamentoID, A890NotaFiscalParcelamentoID});
         RcdFound97 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound97 = 1;
            A890NotaFiscalParcelamentoID = BC002T12_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = BC002T12_n890NotaFiscalParcelamentoID[0];
            A799NotaFiscalNumero = BC002T12_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = BC002T12_n799NotaFiscalNumero[0];
            A891NotaFiscalParcelamentoNumero = BC002T12_A891NotaFiscalParcelamentoNumero[0];
            n891NotaFiscalParcelamentoNumero = BC002T12_n891NotaFiscalParcelamentoNumero[0];
            A892NotaFiscalParcelamentoValor = BC002T12_A892NotaFiscalParcelamentoValor[0];
            n892NotaFiscalParcelamentoValor = BC002T12_n892NotaFiscalParcelamentoValor[0];
            A893NotaFiscalParcelamentoVencimento = BC002T12_A893NotaFiscalParcelamentoVencimento[0];
            n893NotaFiscalParcelamentoVencimento = BC002T12_n893NotaFiscalParcelamentoVencimento[0];
            A895NotaFiscalParcelamentoValorTaxaAdministrativa = BC002T12_A895NotaFiscalParcelamentoValorTaxaAdministrativa[0];
            n895NotaFiscalParcelamentoValorTaxaAdministrativa = BC002T12_n895NotaFiscalParcelamentoValorTaxaAdministrativa[0];
            A896NotaFiscalParcelamentoValorTaxaAnual = BC002T12_A896NotaFiscalParcelamentoValorTaxaAnual[0];
            n896NotaFiscalParcelamentoValorTaxaAnual = BC002T12_n896NotaFiscalParcelamentoValorTaxaAnual[0];
            A897NotaFiscalParcelamentoLiquido = BC002T12_A897NotaFiscalParcelamentoLiquido[0];
            n897NotaFiscalParcelamentoLiquido = BC002T12_n897NotaFiscalParcelamentoLiquido[0];
            A794NotaFiscalId = BC002T12_A794NotaFiscalId[0];
            n794NotaFiscalId = BC002T12_n794NotaFiscalId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2T97( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound97 = 0;
         ScanKeyLoad2T97( ) ;
      }

      protected void ScanKeyLoad2T97( )
      {
         sMode97 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound97 = 1;
            A890NotaFiscalParcelamentoID = BC002T12_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = BC002T12_n890NotaFiscalParcelamentoID[0];
            A799NotaFiscalNumero = BC002T12_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = BC002T12_n799NotaFiscalNumero[0];
            A891NotaFiscalParcelamentoNumero = BC002T12_A891NotaFiscalParcelamentoNumero[0];
            n891NotaFiscalParcelamentoNumero = BC002T12_n891NotaFiscalParcelamentoNumero[0];
            A892NotaFiscalParcelamentoValor = BC002T12_A892NotaFiscalParcelamentoValor[0];
            n892NotaFiscalParcelamentoValor = BC002T12_n892NotaFiscalParcelamentoValor[0];
            A893NotaFiscalParcelamentoVencimento = BC002T12_A893NotaFiscalParcelamentoVencimento[0];
            n893NotaFiscalParcelamentoVencimento = BC002T12_n893NotaFiscalParcelamentoVencimento[0];
            A895NotaFiscalParcelamentoValorTaxaAdministrativa = BC002T12_A895NotaFiscalParcelamentoValorTaxaAdministrativa[0];
            n895NotaFiscalParcelamentoValorTaxaAdministrativa = BC002T12_n895NotaFiscalParcelamentoValorTaxaAdministrativa[0];
            A896NotaFiscalParcelamentoValorTaxaAnual = BC002T12_A896NotaFiscalParcelamentoValorTaxaAnual[0];
            n896NotaFiscalParcelamentoValorTaxaAnual = BC002T12_n896NotaFiscalParcelamentoValorTaxaAnual[0];
            A897NotaFiscalParcelamentoLiquido = BC002T12_A897NotaFiscalParcelamentoLiquido[0];
            n897NotaFiscalParcelamentoLiquido = BC002T12_n897NotaFiscalParcelamentoLiquido[0];
            A794NotaFiscalId = BC002T12_A794NotaFiscalId[0];
            n794NotaFiscalId = BC002T12_n794NotaFiscalId[0];
         }
         Gx_mode = sMode97;
      }

      protected void ScanKeyEnd2T97( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm2T97( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2T97( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2T97( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2T97( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2T97( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2T97( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2T97( )
      {
      }

      protected void send_integrity_lvl_hashes2T97( )
      {
      }

      protected void AddRow2T97( )
      {
         VarsToRow97( bcNotaFiscalParcelamento) ;
      }

      protected void ReadRow2T97( )
      {
         RowToVars97( bcNotaFiscalParcelamento, 1) ;
      }

      protected void InitializeNonKey2T97( )
      {
         A794NotaFiscalId = Guid.Empty;
         n794NotaFiscalId = false;
         A799NotaFiscalNumero = "";
         n799NotaFiscalNumero = false;
         A891NotaFiscalParcelamentoNumero = "";
         n891NotaFiscalParcelamentoNumero = false;
         A892NotaFiscalParcelamentoValor = 0;
         n892NotaFiscalParcelamentoValor = false;
         A893NotaFiscalParcelamentoVencimento = DateTime.MinValue;
         n893NotaFiscalParcelamentoVencimento = false;
         A895NotaFiscalParcelamentoValorTaxaAdministrativa = 0;
         n895NotaFiscalParcelamentoValorTaxaAdministrativa = false;
         A896NotaFiscalParcelamentoValorTaxaAnual = 0;
         n896NotaFiscalParcelamentoValorTaxaAnual = false;
         A897NotaFiscalParcelamentoLiquido = 0;
         n897NotaFiscalParcelamentoLiquido = false;
         Z891NotaFiscalParcelamentoNumero = "";
         Z892NotaFiscalParcelamentoValor = 0;
         Z893NotaFiscalParcelamentoVencimento = DateTime.MinValue;
         Z895NotaFiscalParcelamentoValorTaxaAdministrativa = 0;
         Z896NotaFiscalParcelamentoValorTaxaAnual = 0;
         Z897NotaFiscalParcelamentoLiquido = 0;
         Z794NotaFiscalId = Guid.Empty;
      }

      protected void InitAll2T97( )
      {
         A890NotaFiscalParcelamentoID = Guid.NewGuid( );
         n890NotaFiscalParcelamentoID = false;
         InitializeNonKey2T97( ) ;
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

      public void VarsToRow97( SdtNotaFiscalParcelamento obj97 )
      {
         obj97.gxTpr_Mode = Gx_mode;
         obj97.gxTpr_Notafiscalid = A794NotaFiscalId;
         obj97.gxTpr_Notafiscalnumero = A799NotaFiscalNumero;
         obj97.gxTpr_Notafiscalparcelamentonumero = A891NotaFiscalParcelamentoNumero;
         obj97.gxTpr_Notafiscalparcelamentovalor = A892NotaFiscalParcelamentoValor;
         obj97.gxTpr_Notafiscalparcelamentovencimento = A893NotaFiscalParcelamentoVencimento;
         obj97.gxTpr_Notafiscalparcelamentovalortaxaadministrativa = A895NotaFiscalParcelamentoValorTaxaAdministrativa;
         obj97.gxTpr_Notafiscalparcelamentovalortaxaanual = A896NotaFiscalParcelamentoValorTaxaAnual;
         obj97.gxTpr_Notafiscalparcelamentoliquido = A897NotaFiscalParcelamentoLiquido;
         obj97.gxTpr_Notafiscalparcelamentoid = A890NotaFiscalParcelamentoID;
         obj97.gxTpr_Notafiscalparcelamentoid_Z = Z890NotaFiscalParcelamentoID;
         obj97.gxTpr_Notafiscalid_Z = Z794NotaFiscalId;
         obj97.gxTpr_Notafiscalnumero_Z = Z799NotaFiscalNumero;
         obj97.gxTpr_Notafiscalparcelamentonumero_Z = Z891NotaFiscalParcelamentoNumero;
         obj97.gxTpr_Notafiscalparcelamentovalor_Z = Z892NotaFiscalParcelamentoValor;
         obj97.gxTpr_Notafiscalparcelamentovencimento_Z = Z893NotaFiscalParcelamentoVencimento;
         obj97.gxTpr_Notafiscalparcelamentovalortaxaadministrativa_Z = Z895NotaFiscalParcelamentoValorTaxaAdministrativa;
         obj97.gxTpr_Notafiscalparcelamentovalortaxaanual_Z = Z896NotaFiscalParcelamentoValorTaxaAnual;
         obj97.gxTpr_Notafiscalparcelamentoliquido_Z = Z897NotaFiscalParcelamentoLiquido;
         obj97.gxTpr_Notafiscalparcelamentoid_N = (short)(Convert.ToInt16(n890NotaFiscalParcelamentoID));
         obj97.gxTpr_Notafiscalid_N = (short)(Convert.ToInt16(n794NotaFiscalId));
         obj97.gxTpr_Notafiscalnumero_N = (short)(Convert.ToInt16(n799NotaFiscalNumero));
         obj97.gxTpr_Notafiscalparcelamentonumero_N = (short)(Convert.ToInt16(n891NotaFiscalParcelamentoNumero));
         obj97.gxTpr_Notafiscalparcelamentovalor_N = (short)(Convert.ToInt16(n892NotaFiscalParcelamentoValor));
         obj97.gxTpr_Notafiscalparcelamentovencimento_N = (short)(Convert.ToInt16(n893NotaFiscalParcelamentoVencimento));
         obj97.gxTpr_Notafiscalparcelamentovalortaxaadministrativa_N = (short)(Convert.ToInt16(n895NotaFiscalParcelamentoValorTaxaAdministrativa));
         obj97.gxTpr_Notafiscalparcelamentovalortaxaanual_N = (short)(Convert.ToInt16(n896NotaFiscalParcelamentoValorTaxaAnual));
         obj97.gxTpr_Notafiscalparcelamentoliquido_N = (short)(Convert.ToInt16(n897NotaFiscalParcelamentoLiquido));
         obj97.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow97( SdtNotaFiscalParcelamento obj97 )
      {
         obj97.gxTpr_Notafiscalparcelamentoid = A890NotaFiscalParcelamentoID;
         return  ;
      }

      public void RowToVars97( SdtNotaFiscalParcelamento obj97 ,
                               int forceLoad )
      {
         Gx_mode = obj97.gxTpr_Mode;
         A794NotaFiscalId = obj97.gxTpr_Notafiscalid;
         n794NotaFiscalId = false;
         A799NotaFiscalNumero = obj97.gxTpr_Notafiscalnumero;
         n799NotaFiscalNumero = false;
         A891NotaFiscalParcelamentoNumero = obj97.gxTpr_Notafiscalparcelamentonumero;
         n891NotaFiscalParcelamentoNumero = false;
         A892NotaFiscalParcelamentoValor = obj97.gxTpr_Notafiscalparcelamentovalor;
         n892NotaFiscalParcelamentoValor = false;
         A893NotaFiscalParcelamentoVencimento = obj97.gxTpr_Notafiscalparcelamentovencimento;
         n893NotaFiscalParcelamentoVencimento = false;
         A895NotaFiscalParcelamentoValorTaxaAdministrativa = obj97.gxTpr_Notafiscalparcelamentovalortaxaadministrativa;
         n895NotaFiscalParcelamentoValorTaxaAdministrativa = false;
         A896NotaFiscalParcelamentoValorTaxaAnual = obj97.gxTpr_Notafiscalparcelamentovalortaxaanual;
         n896NotaFiscalParcelamentoValorTaxaAnual = false;
         A897NotaFiscalParcelamentoLiquido = obj97.gxTpr_Notafiscalparcelamentoliquido;
         n897NotaFiscalParcelamentoLiquido = false;
         A890NotaFiscalParcelamentoID = obj97.gxTpr_Notafiscalparcelamentoid;
         n890NotaFiscalParcelamentoID = false;
         Z890NotaFiscalParcelamentoID = obj97.gxTpr_Notafiscalparcelamentoid_Z;
         Z794NotaFiscalId = obj97.gxTpr_Notafiscalid_Z;
         Z799NotaFiscalNumero = obj97.gxTpr_Notafiscalnumero_Z;
         Z891NotaFiscalParcelamentoNumero = obj97.gxTpr_Notafiscalparcelamentonumero_Z;
         Z892NotaFiscalParcelamentoValor = obj97.gxTpr_Notafiscalparcelamentovalor_Z;
         Z893NotaFiscalParcelamentoVencimento = obj97.gxTpr_Notafiscalparcelamentovencimento_Z;
         Z895NotaFiscalParcelamentoValorTaxaAdministrativa = obj97.gxTpr_Notafiscalparcelamentovalortaxaadministrativa_Z;
         Z896NotaFiscalParcelamentoValorTaxaAnual = obj97.gxTpr_Notafiscalparcelamentovalortaxaanual_Z;
         Z897NotaFiscalParcelamentoLiquido = obj97.gxTpr_Notafiscalparcelamentoliquido_Z;
         n890NotaFiscalParcelamentoID = (bool)(Convert.ToBoolean(obj97.gxTpr_Notafiscalparcelamentoid_N));
         n794NotaFiscalId = (bool)(Convert.ToBoolean(obj97.gxTpr_Notafiscalid_N));
         n799NotaFiscalNumero = (bool)(Convert.ToBoolean(obj97.gxTpr_Notafiscalnumero_N));
         n891NotaFiscalParcelamentoNumero = (bool)(Convert.ToBoolean(obj97.gxTpr_Notafiscalparcelamentonumero_N));
         n892NotaFiscalParcelamentoValor = (bool)(Convert.ToBoolean(obj97.gxTpr_Notafiscalparcelamentovalor_N));
         n893NotaFiscalParcelamentoVencimento = (bool)(Convert.ToBoolean(obj97.gxTpr_Notafiscalparcelamentovencimento_N));
         n895NotaFiscalParcelamentoValorTaxaAdministrativa = (bool)(Convert.ToBoolean(obj97.gxTpr_Notafiscalparcelamentovalortaxaadministrativa_N));
         n896NotaFiscalParcelamentoValorTaxaAnual = (bool)(Convert.ToBoolean(obj97.gxTpr_Notafiscalparcelamentovalortaxaanual_N));
         n897NotaFiscalParcelamentoLiquido = (bool)(Convert.ToBoolean(obj97.gxTpr_Notafiscalparcelamentoliquido_N));
         Gx_mode = obj97.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A890NotaFiscalParcelamentoID = (Guid)getParm(obj,0);
         n890NotaFiscalParcelamentoID = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2T97( ) ;
         ScanKeyStart2T97( ) ;
         if ( RcdFound97 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z890NotaFiscalParcelamentoID = A890NotaFiscalParcelamentoID;
         }
         ZM2T97( -9) ;
         OnLoadActions2T97( ) ;
         AddRow2T97( ) ;
         ScanKeyEnd2T97( ) ;
         if ( RcdFound97 == 0 )
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
         RowToVars97( bcNotaFiscalParcelamento, 0) ;
         ScanKeyStart2T97( ) ;
         if ( RcdFound97 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z890NotaFiscalParcelamentoID = A890NotaFiscalParcelamentoID;
         }
         ZM2T97( -9) ;
         OnLoadActions2T97( ) ;
         AddRow2T97( ) ;
         ScanKeyEnd2T97( ) ;
         if ( RcdFound97 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2T97( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2T97( ) ;
         }
         else
         {
            if ( RcdFound97 == 1 )
            {
               if ( A890NotaFiscalParcelamentoID != Z890NotaFiscalParcelamentoID )
               {
                  A890NotaFiscalParcelamentoID = Z890NotaFiscalParcelamentoID;
                  n890NotaFiscalParcelamentoID = false;
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
                  Update2T97( ) ;
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
                  if ( A890NotaFiscalParcelamentoID != Z890NotaFiscalParcelamentoID )
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
                        Insert2T97( ) ;
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
                        Insert2T97( ) ;
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
         RowToVars97( bcNotaFiscalParcelamento, 1) ;
         SaveImpl( ) ;
         VarsToRow97( bcNotaFiscalParcelamento) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars97( bcNotaFiscalParcelamento, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2T97( ) ;
         AfterTrn( ) ;
         VarsToRow97( bcNotaFiscalParcelamento) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow97( bcNotaFiscalParcelamento) ;
         }
         else
         {
            SdtNotaFiscalParcelamento auxBC = new SdtNotaFiscalParcelamento(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A890NotaFiscalParcelamentoID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcNotaFiscalParcelamento);
               auxBC.Save();
               bcNotaFiscalParcelamento.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars97( bcNotaFiscalParcelamento, 1) ;
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
         RowToVars97( bcNotaFiscalParcelamento, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2T97( ) ;
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
               VarsToRow97( bcNotaFiscalParcelamento) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow97( bcNotaFiscalParcelamento) ;
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
         RowToVars97( bcNotaFiscalParcelamento, 0) ;
         GetKey2T97( ) ;
         if ( RcdFound97 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A890NotaFiscalParcelamentoID != Z890NotaFiscalParcelamentoID )
            {
               A890NotaFiscalParcelamentoID = Z890NotaFiscalParcelamentoID;
               n890NotaFiscalParcelamentoID = false;
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
            if ( A890NotaFiscalParcelamentoID != Z890NotaFiscalParcelamentoID )
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
         context.RollbackDataStores("notafiscalparcelamento_bc",pr_default);
         VarsToRow97( bcNotaFiscalParcelamento) ;
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
         Gx_mode = bcNotaFiscalParcelamento.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcNotaFiscalParcelamento.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcNotaFiscalParcelamento )
         {
            bcNotaFiscalParcelamento = (SdtNotaFiscalParcelamento)(sdt);
            if ( StringUtil.StrCmp(bcNotaFiscalParcelamento.gxTpr_Mode, "") == 0 )
            {
               bcNotaFiscalParcelamento.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow97( bcNotaFiscalParcelamento) ;
            }
            else
            {
               RowToVars97( bcNotaFiscalParcelamento, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcNotaFiscalParcelamento.gxTpr_Mode, "") == 0 )
            {
               bcNotaFiscalParcelamento.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars97( bcNotaFiscalParcelamento, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtNotaFiscalParcelamento NotaFiscalParcelamento_BC
      {
         get {
            return bcNotaFiscalParcelamento ;
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
         pr_default.close(8);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z890NotaFiscalParcelamentoID = Guid.Empty;
         A890NotaFiscalParcelamentoID = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV19Pgmname = "";
         AV12TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV11Insert_NotaFiscalId = Guid.Empty;
         Z891NotaFiscalParcelamentoNumero = "";
         A891NotaFiscalParcelamentoNumero = "";
         Z893NotaFiscalParcelamentoVencimento = DateTime.MinValue;
         A893NotaFiscalParcelamentoVencimento = DateTime.MinValue;
         Z794NotaFiscalId = Guid.Empty;
         A794NotaFiscalId = Guid.Empty;
         Z799NotaFiscalNumero = "";
         A799NotaFiscalNumero = "";
         BC002T5_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         BC002T5_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         BC002T5_A799NotaFiscalNumero = new string[] {""} ;
         BC002T5_n799NotaFiscalNumero = new bool[] {false} ;
         BC002T5_A891NotaFiscalParcelamentoNumero = new string[] {""} ;
         BC002T5_n891NotaFiscalParcelamentoNumero = new bool[] {false} ;
         BC002T5_A892NotaFiscalParcelamentoValor = new decimal[1] ;
         BC002T5_n892NotaFiscalParcelamentoValor = new bool[] {false} ;
         BC002T5_A893NotaFiscalParcelamentoVencimento = new DateTime[] {DateTime.MinValue} ;
         BC002T5_n893NotaFiscalParcelamentoVencimento = new bool[] {false} ;
         BC002T5_A895NotaFiscalParcelamentoValorTaxaAdministrativa = new decimal[1] ;
         BC002T5_n895NotaFiscalParcelamentoValorTaxaAdministrativa = new bool[] {false} ;
         BC002T5_A896NotaFiscalParcelamentoValorTaxaAnual = new decimal[1] ;
         BC002T5_n896NotaFiscalParcelamentoValorTaxaAnual = new bool[] {false} ;
         BC002T5_A897NotaFiscalParcelamentoLiquido = new decimal[1] ;
         BC002T5_n897NotaFiscalParcelamentoLiquido = new bool[] {false} ;
         BC002T5_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         BC002T5_n794NotaFiscalId = new bool[] {false} ;
         BC002T4_A799NotaFiscalNumero = new string[] {""} ;
         BC002T4_n799NotaFiscalNumero = new bool[] {false} ;
         BC002T6_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         BC002T6_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         BC002T3_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         BC002T3_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         BC002T3_A891NotaFiscalParcelamentoNumero = new string[] {""} ;
         BC002T3_n891NotaFiscalParcelamentoNumero = new bool[] {false} ;
         BC002T3_A892NotaFiscalParcelamentoValor = new decimal[1] ;
         BC002T3_n892NotaFiscalParcelamentoValor = new bool[] {false} ;
         BC002T3_A893NotaFiscalParcelamentoVencimento = new DateTime[] {DateTime.MinValue} ;
         BC002T3_n893NotaFiscalParcelamentoVencimento = new bool[] {false} ;
         BC002T3_A895NotaFiscalParcelamentoValorTaxaAdministrativa = new decimal[1] ;
         BC002T3_n895NotaFiscalParcelamentoValorTaxaAdministrativa = new bool[] {false} ;
         BC002T3_A896NotaFiscalParcelamentoValorTaxaAnual = new decimal[1] ;
         BC002T3_n896NotaFiscalParcelamentoValorTaxaAnual = new bool[] {false} ;
         BC002T3_A897NotaFiscalParcelamentoLiquido = new decimal[1] ;
         BC002T3_n897NotaFiscalParcelamentoLiquido = new bool[] {false} ;
         BC002T3_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         BC002T3_n794NotaFiscalId = new bool[] {false} ;
         sMode97 = "";
         BC002T2_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         BC002T2_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         BC002T2_A891NotaFiscalParcelamentoNumero = new string[] {""} ;
         BC002T2_n891NotaFiscalParcelamentoNumero = new bool[] {false} ;
         BC002T2_A892NotaFiscalParcelamentoValor = new decimal[1] ;
         BC002T2_n892NotaFiscalParcelamentoValor = new bool[] {false} ;
         BC002T2_A893NotaFiscalParcelamentoVencimento = new DateTime[] {DateTime.MinValue} ;
         BC002T2_n893NotaFiscalParcelamentoVencimento = new bool[] {false} ;
         BC002T2_A895NotaFiscalParcelamentoValorTaxaAdministrativa = new decimal[1] ;
         BC002T2_n895NotaFiscalParcelamentoValorTaxaAdministrativa = new bool[] {false} ;
         BC002T2_A896NotaFiscalParcelamentoValorTaxaAnual = new decimal[1] ;
         BC002T2_n896NotaFiscalParcelamentoValorTaxaAnual = new bool[] {false} ;
         BC002T2_A897NotaFiscalParcelamentoLiquido = new decimal[1] ;
         BC002T2_n897NotaFiscalParcelamentoLiquido = new bool[] {false} ;
         BC002T2_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         BC002T2_n794NotaFiscalId = new bool[] {false} ;
         BC002T10_A799NotaFiscalNumero = new string[] {""} ;
         BC002T10_n799NotaFiscalNumero = new bool[] {false} ;
         BC002T11_A261TituloId = new int[1] ;
         BC002T12_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         BC002T12_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         BC002T12_A799NotaFiscalNumero = new string[] {""} ;
         BC002T12_n799NotaFiscalNumero = new bool[] {false} ;
         BC002T12_A891NotaFiscalParcelamentoNumero = new string[] {""} ;
         BC002T12_n891NotaFiscalParcelamentoNumero = new bool[] {false} ;
         BC002T12_A892NotaFiscalParcelamentoValor = new decimal[1] ;
         BC002T12_n892NotaFiscalParcelamentoValor = new bool[] {false} ;
         BC002T12_A893NotaFiscalParcelamentoVencimento = new DateTime[] {DateTime.MinValue} ;
         BC002T12_n893NotaFiscalParcelamentoVencimento = new bool[] {false} ;
         BC002T12_A895NotaFiscalParcelamentoValorTaxaAdministrativa = new decimal[1] ;
         BC002T12_n895NotaFiscalParcelamentoValorTaxaAdministrativa = new bool[] {false} ;
         BC002T12_A896NotaFiscalParcelamentoValorTaxaAnual = new decimal[1] ;
         BC002T12_n896NotaFiscalParcelamentoValorTaxaAnual = new bool[] {false} ;
         BC002T12_A897NotaFiscalParcelamentoLiquido = new decimal[1] ;
         BC002T12_n897NotaFiscalParcelamentoLiquido = new bool[] {false} ;
         BC002T12_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         BC002T12_n794NotaFiscalId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.notafiscalparcelamento_bc__default(),
            new Object[][] {
                new Object[] {
               BC002T2_A890NotaFiscalParcelamentoID, BC002T2_A891NotaFiscalParcelamentoNumero, BC002T2_n891NotaFiscalParcelamentoNumero, BC002T2_A892NotaFiscalParcelamentoValor, BC002T2_n892NotaFiscalParcelamentoValor, BC002T2_A893NotaFiscalParcelamentoVencimento, BC002T2_n893NotaFiscalParcelamentoVencimento, BC002T2_A895NotaFiscalParcelamentoValorTaxaAdministrativa, BC002T2_n895NotaFiscalParcelamentoValorTaxaAdministrativa, BC002T2_A896NotaFiscalParcelamentoValorTaxaAnual,
               BC002T2_n896NotaFiscalParcelamentoValorTaxaAnual, BC002T2_A897NotaFiscalParcelamentoLiquido, BC002T2_n897NotaFiscalParcelamentoLiquido, BC002T2_A794NotaFiscalId, BC002T2_n794NotaFiscalId
               }
               , new Object[] {
               BC002T3_A890NotaFiscalParcelamentoID, BC002T3_A891NotaFiscalParcelamentoNumero, BC002T3_n891NotaFiscalParcelamentoNumero, BC002T3_A892NotaFiscalParcelamentoValor, BC002T3_n892NotaFiscalParcelamentoValor, BC002T3_A893NotaFiscalParcelamentoVencimento, BC002T3_n893NotaFiscalParcelamentoVencimento, BC002T3_A895NotaFiscalParcelamentoValorTaxaAdministrativa, BC002T3_n895NotaFiscalParcelamentoValorTaxaAdministrativa, BC002T3_A896NotaFiscalParcelamentoValorTaxaAnual,
               BC002T3_n896NotaFiscalParcelamentoValorTaxaAnual, BC002T3_A897NotaFiscalParcelamentoLiquido, BC002T3_n897NotaFiscalParcelamentoLiquido, BC002T3_A794NotaFiscalId, BC002T3_n794NotaFiscalId
               }
               , new Object[] {
               BC002T4_A799NotaFiscalNumero, BC002T4_n799NotaFiscalNumero
               }
               , new Object[] {
               BC002T5_A890NotaFiscalParcelamentoID, BC002T5_A799NotaFiscalNumero, BC002T5_n799NotaFiscalNumero, BC002T5_A891NotaFiscalParcelamentoNumero, BC002T5_n891NotaFiscalParcelamentoNumero, BC002T5_A892NotaFiscalParcelamentoValor, BC002T5_n892NotaFiscalParcelamentoValor, BC002T5_A893NotaFiscalParcelamentoVencimento, BC002T5_n893NotaFiscalParcelamentoVencimento, BC002T5_A895NotaFiscalParcelamentoValorTaxaAdministrativa,
               BC002T5_n895NotaFiscalParcelamentoValorTaxaAdministrativa, BC002T5_A896NotaFiscalParcelamentoValorTaxaAnual, BC002T5_n896NotaFiscalParcelamentoValorTaxaAnual, BC002T5_A897NotaFiscalParcelamentoLiquido, BC002T5_n897NotaFiscalParcelamentoLiquido, BC002T5_A794NotaFiscalId, BC002T5_n794NotaFiscalId
               }
               , new Object[] {
               BC002T6_A890NotaFiscalParcelamentoID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002T10_A799NotaFiscalNumero, BC002T10_n799NotaFiscalNumero
               }
               , new Object[] {
               BC002T11_A261TituloId
               }
               , new Object[] {
               BC002T12_A890NotaFiscalParcelamentoID, BC002T12_A799NotaFiscalNumero, BC002T12_n799NotaFiscalNumero, BC002T12_A891NotaFiscalParcelamentoNumero, BC002T12_n891NotaFiscalParcelamentoNumero, BC002T12_A892NotaFiscalParcelamentoValor, BC002T12_n892NotaFiscalParcelamentoValor, BC002T12_A893NotaFiscalParcelamentoVencimento, BC002T12_n893NotaFiscalParcelamentoVencimento, BC002T12_A895NotaFiscalParcelamentoValorTaxaAdministrativa,
               BC002T12_n895NotaFiscalParcelamentoValorTaxaAdministrativa, BC002T12_A896NotaFiscalParcelamentoValorTaxaAnual, BC002T12_n896NotaFiscalParcelamentoValorTaxaAnual, BC002T12_A897NotaFiscalParcelamentoLiquido, BC002T12_n897NotaFiscalParcelamentoLiquido, BC002T12_A794NotaFiscalId, BC002T12_n794NotaFiscalId
               }
            }
         );
         Z890NotaFiscalParcelamentoID = Guid.NewGuid( );
         n890NotaFiscalParcelamentoID = false;
         A890NotaFiscalParcelamentoID = Guid.NewGuid( );
         n890NotaFiscalParcelamentoID = false;
         AV19Pgmname = "NotaFiscalParcelamento_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E122T2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound97 ;
      private int trnEnded ;
      private int AV20GXV1 ;
      private decimal Z892NotaFiscalParcelamentoValor ;
      private decimal A892NotaFiscalParcelamentoValor ;
      private decimal Z895NotaFiscalParcelamentoValorTaxaAdministrativa ;
      private decimal A895NotaFiscalParcelamentoValorTaxaAdministrativa ;
      private decimal Z896NotaFiscalParcelamentoValorTaxaAnual ;
      private decimal A896NotaFiscalParcelamentoValorTaxaAnual ;
      private decimal Z897NotaFiscalParcelamentoLiquido ;
      private decimal A897NotaFiscalParcelamentoLiquido ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV19Pgmname ;
      private string sMode97 ;
      private DateTime Z893NotaFiscalParcelamentoVencimento ;
      private DateTime A893NotaFiscalParcelamentoVencimento ;
      private bool returnInSub ;
      private bool n890NotaFiscalParcelamentoID ;
      private bool n799NotaFiscalNumero ;
      private bool n891NotaFiscalParcelamentoNumero ;
      private bool n892NotaFiscalParcelamentoValor ;
      private bool n893NotaFiscalParcelamentoVencimento ;
      private bool n895NotaFiscalParcelamentoValorTaxaAdministrativa ;
      private bool n896NotaFiscalParcelamentoValorTaxaAnual ;
      private bool n897NotaFiscalParcelamentoLiquido ;
      private bool n794NotaFiscalId ;
      private bool Gx_longc ;
      private string Z891NotaFiscalParcelamentoNumero ;
      private string A891NotaFiscalParcelamentoNumero ;
      private string Z799NotaFiscalNumero ;
      private string A799NotaFiscalNumero ;
      private Guid Z890NotaFiscalParcelamentoID ;
      private Guid A890NotaFiscalParcelamentoID ;
      private Guid AV11Insert_NotaFiscalId ;
      private Guid Z794NotaFiscalId ;
      private Guid A794NotaFiscalId ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC002T5_A890NotaFiscalParcelamentoID ;
      private bool[] BC002T5_n890NotaFiscalParcelamentoID ;
      private string[] BC002T5_A799NotaFiscalNumero ;
      private bool[] BC002T5_n799NotaFiscalNumero ;
      private string[] BC002T5_A891NotaFiscalParcelamentoNumero ;
      private bool[] BC002T5_n891NotaFiscalParcelamentoNumero ;
      private decimal[] BC002T5_A892NotaFiscalParcelamentoValor ;
      private bool[] BC002T5_n892NotaFiscalParcelamentoValor ;
      private DateTime[] BC002T5_A893NotaFiscalParcelamentoVencimento ;
      private bool[] BC002T5_n893NotaFiscalParcelamentoVencimento ;
      private decimal[] BC002T5_A895NotaFiscalParcelamentoValorTaxaAdministrativa ;
      private bool[] BC002T5_n895NotaFiscalParcelamentoValorTaxaAdministrativa ;
      private decimal[] BC002T5_A896NotaFiscalParcelamentoValorTaxaAnual ;
      private bool[] BC002T5_n896NotaFiscalParcelamentoValorTaxaAnual ;
      private decimal[] BC002T5_A897NotaFiscalParcelamentoLiquido ;
      private bool[] BC002T5_n897NotaFiscalParcelamentoLiquido ;
      private Guid[] BC002T5_A794NotaFiscalId ;
      private bool[] BC002T5_n794NotaFiscalId ;
      private string[] BC002T4_A799NotaFiscalNumero ;
      private bool[] BC002T4_n799NotaFiscalNumero ;
      private Guid[] BC002T6_A890NotaFiscalParcelamentoID ;
      private bool[] BC002T6_n890NotaFiscalParcelamentoID ;
      private Guid[] BC002T3_A890NotaFiscalParcelamentoID ;
      private bool[] BC002T3_n890NotaFiscalParcelamentoID ;
      private string[] BC002T3_A891NotaFiscalParcelamentoNumero ;
      private bool[] BC002T3_n891NotaFiscalParcelamentoNumero ;
      private decimal[] BC002T3_A892NotaFiscalParcelamentoValor ;
      private bool[] BC002T3_n892NotaFiscalParcelamentoValor ;
      private DateTime[] BC002T3_A893NotaFiscalParcelamentoVencimento ;
      private bool[] BC002T3_n893NotaFiscalParcelamentoVencimento ;
      private decimal[] BC002T3_A895NotaFiscalParcelamentoValorTaxaAdministrativa ;
      private bool[] BC002T3_n895NotaFiscalParcelamentoValorTaxaAdministrativa ;
      private decimal[] BC002T3_A896NotaFiscalParcelamentoValorTaxaAnual ;
      private bool[] BC002T3_n896NotaFiscalParcelamentoValorTaxaAnual ;
      private decimal[] BC002T3_A897NotaFiscalParcelamentoLiquido ;
      private bool[] BC002T3_n897NotaFiscalParcelamentoLiquido ;
      private Guid[] BC002T3_A794NotaFiscalId ;
      private bool[] BC002T3_n794NotaFiscalId ;
      private Guid[] BC002T2_A890NotaFiscalParcelamentoID ;
      private bool[] BC002T2_n890NotaFiscalParcelamentoID ;
      private string[] BC002T2_A891NotaFiscalParcelamentoNumero ;
      private bool[] BC002T2_n891NotaFiscalParcelamentoNumero ;
      private decimal[] BC002T2_A892NotaFiscalParcelamentoValor ;
      private bool[] BC002T2_n892NotaFiscalParcelamentoValor ;
      private DateTime[] BC002T2_A893NotaFiscalParcelamentoVencimento ;
      private bool[] BC002T2_n893NotaFiscalParcelamentoVencimento ;
      private decimal[] BC002T2_A895NotaFiscalParcelamentoValorTaxaAdministrativa ;
      private bool[] BC002T2_n895NotaFiscalParcelamentoValorTaxaAdministrativa ;
      private decimal[] BC002T2_A896NotaFiscalParcelamentoValorTaxaAnual ;
      private bool[] BC002T2_n896NotaFiscalParcelamentoValorTaxaAnual ;
      private decimal[] BC002T2_A897NotaFiscalParcelamentoLiquido ;
      private bool[] BC002T2_n897NotaFiscalParcelamentoLiquido ;
      private Guid[] BC002T2_A794NotaFiscalId ;
      private bool[] BC002T2_n794NotaFiscalId ;
      private string[] BC002T10_A799NotaFiscalNumero ;
      private bool[] BC002T10_n799NotaFiscalNumero ;
      private int[] BC002T11_A261TituloId ;
      private Guid[] BC002T12_A890NotaFiscalParcelamentoID ;
      private bool[] BC002T12_n890NotaFiscalParcelamentoID ;
      private string[] BC002T12_A799NotaFiscalNumero ;
      private bool[] BC002T12_n799NotaFiscalNumero ;
      private string[] BC002T12_A891NotaFiscalParcelamentoNumero ;
      private bool[] BC002T12_n891NotaFiscalParcelamentoNumero ;
      private decimal[] BC002T12_A892NotaFiscalParcelamentoValor ;
      private bool[] BC002T12_n892NotaFiscalParcelamentoValor ;
      private DateTime[] BC002T12_A893NotaFiscalParcelamentoVencimento ;
      private bool[] BC002T12_n893NotaFiscalParcelamentoVencimento ;
      private decimal[] BC002T12_A895NotaFiscalParcelamentoValorTaxaAdministrativa ;
      private bool[] BC002T12_n895NotaFiscalParcelamentoValorTaxaAdministrativa ;
      private decimal[] BC002T12_A896NotaFiscalParcelamentoValorTaxaAnual ;
      private bool[] BC002T12_n896NotaFiscalParcelamentoValorTaxaAnual ;
      private decimal[] BC002T12_A897NotaFiscalParcelamentoLiquido ;
      private bool[] BC002T12_n897NotaFiscalParcelamentoLiquido ;
      private Guid[] BC002T12_A794NotaFiscalId ;
      private bool[] BC002T12_n794NotaFiscalId ;
      private SdtNotaFiscalParcelamento bcNotaFiscalParcelamento ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class notafiscalparcelamento_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC002T2;
          prmBC002T2 = new Object[] {
          new ParDef("NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmBC002T3;
          prmBC002T3 = new Object[] {
          new ParDef("NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmBC002T4;
          prmBC002T4 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmBC002T5;
          prmBC002T5 = new Object[] {
          new ParDef("NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmBC002T6;
          prmBC002T6 = new Object[] {
          new ParDef("NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmBC002T7;
          prmBC002T7 = new Object[] {
          new ParDef("NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("NotaFiscalParcelamentoNumero",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NotaFiscalParcelamentoValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("NotaFiscalParcelamentoVencimento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("NotaFiscalParcelamentoValorTaxaAdministrativa",GXType.Number,18,2){Nullable=true} ,
          new ParDef("NotaFiscalParcelamentoValorTaxaAnual",GXType.Number,18,2){Nullable=true} ,
          new ParDef("NotaFiscalParcelamentoLiquido",GXType.Number,18,2){Nullable=true} ,
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmBC002T8;
          prmBC002T8 = new Object[] {
          new ParDef("NotaFiscalParcelamentoNumero",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NotaFiscalParcelamentoValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("NotaFiscalParcelamentoVencimento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("NotaFiscalParcelamentoValorTaxaAdministrativa",GXType.Number,18,2){Nullable=true} ,
          new ParDef("NotaFiscalParcelamentoValorTaxaAnual",GXType.Number,18,2){Nullable=true} ,
          new ParDef("NotaFiscalParcelamentoLiquido",GXType.Number,18,2){Nullable=true} ,
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmBC002T9;
          prmBC002T9 = new Object[] {
          new ParDef("NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmBC002T10;
          prmBC002T10 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmBC002T11;
          prmBC002T11 = new Object[] {
          new ParDef("NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmBC002T12;
          prmBC002T12 = new Object[] {
          new ParDef("NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC002T2", "SELECT NotaFiscalParcelamentoID, NotaFiscalParcelamentoNumero, NotaFiscalParcelamentoValor, NotaFiscalParcelamentoVencimento, NotaFiscalParcelamentoValorTaxaAdministrativa, NotaFiscalParcelamentoValorTaxaAnual, NotaFiscalParcelamentoLiquido, NotaFiscalId FROM NotaFiscalParcelamento WHERE NotaFiscalParcelamentoID = :NotaFiscalParcelamentoID  FOR UPDATE OF NotaFiscalParcelamento",true, GxErrorMask.GX_NOMASK, false, this,prmBC002T2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002T3", "SELECT NotaFiscalParcelamentoID, NotaFiscalParcelamentoNumero, NotaFiscalParcelamentoValor, NotaFiscalParcelamentoVencimento, NotaFiscalParcelamentoValorTaxaAdministrativa, NotaFiscalParcelamentoValorTaxaAnual, NotaFiscalParcelamentoLiquido, NotaFiscalId FROM NotaFiscalParcelamento WHERE NotaFiscalParcelamentoID = :NotaFiscalParcelamentoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002T3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002T4", "SELECT NotaFiscalNumero FROM NotaFiscal WHERE NotaFiscalId = :NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002T4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002T5", "SELECT TM1.NotaFiscalParcelamentoID, T2.NotaFiscalNumero, TM1.NotaFiscalParcelamentoNumero, TM1.NotaFiscalParcelamentoValor, TM1.NotaFiscalParcelamentoVencimento, TM1.NotaFiscalParcelamentoValorTaxaAdministrativa, TM1.NotaFiscalParcelamentoValorTaxaAnual, TM1.NotaFiscalParcelamentoLiquido, TM1.NotaFiscalId FROM (NotaFiscalParcelamento TM1 LEFT JOIN NotaFiscal T2 ON T2.NotaFiscalId = TM1.NotaFiscalId) WHERE TM1.NotaFiscalParcelamentoID = :NotaFiscalParcelamentoID ORDER BY TM1.NotaFiscalParcelamentoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002T5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002T6", "SELECT NotaFiscalParcelamentoID FROM NotaFiscalParcelamento WHERE NotaFiscalParcelamentoID = :NotaFiscalParcelamentoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002T6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002T7", "SAVEPOINT gxupdate;INSERT INTO NotaFiscalParcelamento(NotaFiscalParcelamentoID, NotaFiscalParcelamentoNumero, NotaFiscalParcelamentoValor, NotaFiscalParcelamentoVencimento, NotaFiscalParcelamentoValorTaxaAdministrativa, NotaFiscalParcelamentoValorTaxaAnual, NotaFiscalParcelamentoLiquido, NotaFiscalId) VALUES(:NotaFiscalParcelamentoID, :NotaFiscalParcelamentoNumero, :NotaFiscalParcelamentoValor, :NotaFiscalParcelamentoVencimento, :NotaFiscalParcelamentoValorTaxaAdministrativa, :NotaFiscalParcelamentoValorTaxaAnual, :NotaFiscalParcelamentoLiquido, :NotaFiscalId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC002T7)
             ,new CursorDef("BC002T8", "SAVEPOINT gxupdate;UPDATE NotaFiscalParcelamento SET NotaFiscalParcelamentoNumero=:NotaFiscalParcelamentoNumero, NotaFiscalParcelamentoValor=:NotaFiscalParcelamentoValor, NotaFiscalParcelamentoVencimento=:NotaFiscalParcelamentoVencimento, NotaFiscalParcelamentoValorTaxaAdministrativa=:NotaFiscalParcelamentoValorTaxaAdministrativa, NotaFiscalParcelamentoValorTaxaAnual=:NotaFiscalParcelamentoValorTaxaAnual, NotaFiscalParcelamentoLiquido=:NotaFiscalParcelamentoLiquido, NotaFiscalId=:NotaFiscalId  WHERE NotaFiscalParcelamentoID = :NotaFiscalParcelamentoID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002T8)
             ,new CursorDef("BC002T9", "SAVEPOINT gxupdate;DELETE FROM NotaFiscalParcelamento  WHERE NotaFiscalParcelamentoID = :NotaFiscalParcelamentoID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002T9)
             ,new CursorDef("BC002T10", "SELECT NotaFiscalNumero FROM NotaFiscal WHERE NotaFiscalId = :NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002T10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002T11", "SELECT TituloId FROM Titulo WHERE NotaFiscalParcelamentoID = :NotaFiscalParcelamentoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002T11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002T12", "SELECT TM1.NotaFiscalParcelamentoID, T2.NotaFiscalNumero, TM1.NotaFiscalParcelamentoNumero, TM1.NotaFiscalParcelamentoValor, TM1.NotaFiscalParcelamentoVencimento, TM1.NotaFiscalParcelamentoValorTaxaAdministrativa, TM1.NotaFiscalParcelamentoValorTaxaAnual, TM1.NotaFiscalParcelamentoLiquido, TM1.NotaFiscalId FROM (NotaFiscalParcelamento TM1 LEFT JOIN NotaFiscal T2 ON T2.NotaFiscalId = TM1.NotaFiscalId) WHERE TM1.NotaFiscalParcelamentoID = :NotaFiscalParcelamentoID ORDER BY TM1.NotaFiscalParcelamentoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002T12,100, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((Guid[]) buf[13])[0] = rslt.getGuid(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((Guid[]) buf[13])[0] = rslt.getGuid(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((Guid[]) buf[15])[0] = rslt.getGuid(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((Guid[]) buf[15])[0] = rslt.getGuid(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                return;
       }
    }

 }

}
