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
   public class reembolsoparcelas_bc : GxSilentTrn, IGxSilentTrn
   {
      public reembolsoparcelas_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public reembolsoparcelas_bc( IGxContext context )
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
         ReadRow2C82( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2C82( ) ;
         standaloneModal( ) ;
         AddRow2C82( ) ;
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
               Z634ReembolsoParcelasId = A634ReembolsoParcelasId;
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

      protected void CONFIRM_2C0( )
      {
         BeforeValidate2C82( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2C82( ) ;
            }
            else
            {
               CheckExtendedTable2C82( ) ;
               if ( AnyError == 0 )
               {
                  ZM2C82( 3) ;
               }
               CloseExtendedTableCursors2C82( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM2C82( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z635ReembolsoParcelasValor = A635ReembolsoParcelasValor;
            Z636ReembolsoParcelasData = A636ReembolsoParcelasData;
            Z637ReembolsoParcelasObservacao = A637ReembolsoParcelasObservacao;
            Z638ReembolsoParcelasCreatedAt = A638ReembolsoParcelasCreatedAt;
            Z639ReembolsoParcelasTaxaValor = A639ReembolsoParcelasTaxaValor;
            Z640ReembolsoParcelasJurosValor = A640ReembolsoParcelasJurosValor;
            Z641ReembolsoParcelasDiasPJuros = A641ReembolsoParcelasDiasPJuros;
            Z518ReembolsoId = A518ReembolsoId;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -2 )
         {
            Z634ReembolsoParcelasId = A634ReembolsoParcelasId;
            Z635ReembolsoParcelasValor = A635ReembolsoParcelasValor;
            Z636ReembolsoParcelasData = A636ReembolsoParcelasData;
            Z637ReembolsoParcelasObservacao = A637ReembolsoParcelasObservacao;
            Z638ReembolsoParcelasCreatedAt = A638ReembolsoParcelasCreatedAt;
            Z639ReembolsoParcelasTaxaValor = A639ReembolsoParcelasTaxaValor;
            Z640ReembolsoParcelasJurosValor = A640ReembolsoParcelasJurosValor;
            Z641ReembolsoParcelasDiasPJuros = A641ReembolsoParcelasDiasPJuros;
            Z518ReembolsoId = A518ReembolsoId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A638ReembolsoParcelasCreatedAt) && ( Gx_BScreen == 0 ) )
         {
            A638ReembolsoParcelasCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n638ReembolsoParcelasCreatedAt = false;
         }
      }

      protected void Load2C82( )
      {
         /* Using cursor BC002C5 */
         pr_default.execute(3, new Object[] {A634ReembolsoParcelasId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound82 = 1;
            A635ReembolsoParcelasValor = BC002C5_A635ReembolsoParcelasValor[0];
            n635ReembolsoParcelasValor = BC002C5_n635ReembolsoParcelasValor[0];
            A636ReembolsoParcelasData = BC002C5_A636ReembolsoParcelasData[0];
            n636ReembolsoParcelasData = BC002C5_n636ReembolsoParcelasData[0];
            A637ReembolsoParcelasObservacao = BC002C5_A637ReembolsoParcelasObservacao[0];
            n637ReembolsoParcelasObservacao = BC002C5_n637ReembolsoParcelasObservacao[0];
            A638ReembolsoParcelasCreatedAt = BC002C5_A638ReembolsoParcelasCreatedAt[0];
            n638ReembolsoParcelasCreatedAt = BC002C5_n638ReembolsoParcelasCreatedAt[0];
            A639ReembolsoParcelasTaxaValor = BC002C5_A639ReembolsoParcelasTaxaValor[0];
            n639ReembolsoParcelasTaxaValor = BC002C5_n639ReembolsoParcelasTaxaValor[0];
            A640ReembolsoParcelasJurosValor = BC002C5_A640ReembolsoParcelasJurosValor[0];
            n640ReembolsoParcelasJurosValor = BC002C5_n640ReembolsoParcelasJurosValor[0];
            A641ReembolsoParcelasDiasPJuros = BC002C5_A641ReembolsoParcelasDiasPJuros[0];
            n641ReembolsoParcelasDiasPJuros = BC002C5_n641ReembolsoParcelasDiasPJuros[0];
            A518ReembolsoId = BC002C5_A518ReembolsoId[0];
            n518ReembolsoId = BC002C5_n518ReembolsoId[0];
            ZM2C82( -2) ;
         }
         pr_default.close(3);
         OnLoadActions2C82( ) ;
      }

      protected void OnLoadActions2C82( )
      {
      }

      protected void CheckExtendedTable2C82( )
      {
         standaloneModal( ) ;
         /* Using cursor BC002C4 */
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
      }

      protected void CloseExtendedTableCursors2C82( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2C82( )
      {
         /* Using cursor BC002C6 */
         pr_default.execute(4, new Object[] {A634ReembolsoParcelasId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound82 = 1;
         }
         else
         {
            RcdFound82 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC002C3 */
         pr_default.execute(1, new Object[] {A634ReembolsoParcelasId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2C82( 2) ;
            RcdFound82 = 1;
            A634ReembolsoParcelasId = BC002C3_A634ReembolsoParcelasId[0];
            A635ReembolsoParcelasValor = BC002C3_A635ReembolsoParcelasValor[0];
            n635ReembolsoParcelasValor = BC002C3_n635ReembolsoParcelasValor[0];
            A636ReembolsoParcelasData = BC002C3_A636ReembolsoParcelasData[0];
            n636ReembolsoParcelasData = BC002C3_n636ReembolsoParcelasData[0];
            A637ReembolsoParcelasObservacao = BC002C3_A637ReembolsoParcelasObservacao[0];
            n637ReembolsoParcelasObservacao = BC002C3_n637ReembolsoParcelasObservacao[0];
            A638ReembolsoParcelasCreatedAt = BC002C3_A638ReembolsoParcelasCreatedAt[0];
            n638ReembolsoParcelasCreatedAt = BC002C3_n638ReembolsoParcelasCreatedAt[0];
            A639ReembolsoParcelasTaxaValor = BC002C3_A639ReembolsoParcelasTaxaValor[0];
            n639ReembolsoParcelasTaxaValor = BC002C3_n639ReembolsoParcelasTaxaValor[0];
            A640ReembolsoParcelasJurosValor = BC002C3_A640ReembolsoParcelasJurosValor[0];
            n640ReembolsoParcelasJurosValor = BC002C3_n640ReembolsoParcelasJurosValor[0];
            A641ReembolsoParcelasDiasPJuros = BC002C3_A641ReembolsoParcelasDiasPJuros[0];
            n641ReembolsoParcelasDiasPJuros = BC002C3_n641ReembolsoParcelasDiasPJuros[0];
            A518ReembolsoId = BC002C3_A518ReembolsoId[0];
            n518ReembolsoId = BC002C3_n518ReembolsoId[0];
            Z634ReembolsoParcelasId = A634ReembolsoParcelasId;
            sMode82 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2C82( ) ;
            if ( AnyError == 1 )
            {
               RcdFound82 = 0;
               InitializeNonKey2C82( ) ;
            }
            Gx_mode = sMode82;
         }
         else
         {
            RcdFound82 = 0;
            InitializeNonKey2C82( ) ;
            sMode82 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode82;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2C82( ) ;
         if ( RcdFound82 == 0 )
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
         CONFIRM_2C0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2C82( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC002C2 */
            pr_default.execute(0, new Object[] {A634ReembolsoParcelasId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ReembolsoParcelas"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z635ReembolsoParcelasValor != BC002C2_A635ReembolsoParcelasValor[0] ) || ( DateTimeUtil.ResetTime ( Z636ReembolsoParcelasData ) != DateTimeUtil.ResetTime ( BC002C2_A636ReembolsoParcelasData[0] ) ) || ( StringUtil.StrCmp(Z637ReembolsoParcelasObservacao, BC002C2_A637ReembolsoParcelasObservacao[0]) != 0 ) || ( Z638ReembolsoParcelasCreatedAt != BC002C2_A638ReembolsoParcelasCreatedAt[0] ) || ( Z639ReembolsoParcelasTaxaValor != BC002C2_A639ReembolsoParcelasTaxaValor[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z640ReembolsoParcelasJurosValor != BC002C2_A640ReembolsoParcelasJurosValor[0] ) || ( Z641ReembolsoParcelasDiasPJuros != BC002C2_A641ReembolsoParcelasDiasPJuros[0] ) || ( Z518ReembolsoId != BC002C2_A518ReembolsoId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ReembolsoParcelas"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2C82( )
      {
         BeforeValidate2C82( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2C82( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2C82( 0) ;
            CheckOptimisticConcurrency2C82( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2C82( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2C82( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002C7 */
                     pr_default.execute(5, new Object[] {n635ReembolsoParcelasValor, A635ReembolsoParcelasValor, n636ReembolsoParcelasData, A636ReembolsoParcelasData, n637ReembolsoParcelasObservacao, A637ReembolsoParcelasObservacao, n638ReembolsoParcelasCreatedAt, A638ReembolsoParcelasCreatedAt, n639ReembolsoParcelasTaxaValor, A639ReembolsoParcelasTaxaValor, n640ReembolsoParcelasJurosValor, A640ReembolsoParcelasJurosValor, n641ReembolsoParcelasDiasPJuros, A641ReembolsoParcelasDiasPJuros, n518ReembolsoId, A518ReembolsoId});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC002C8 */
                     pr_default.execute(6);
                     A634ReembolsoParcelasId = BC002C8_A634ReembolsoParcelasId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("ReembolsoParcelas");
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
               Load2C82( ) ;
            }
            EndLevel2C82( ) ;
         }
         CloseExtendedTableCursors2C82( ) ;
      }

      protected void Update2C82( )
      {
         BeforeValidate2C82( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2C82( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2C82( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2C82( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2C82( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002C9 */
                     pr_default.execute(7, new Object[] {n635ReembolsoParcelasValor, A635ReembolsoParcelasValor, n636ReembolsoParcelasData, A636ReembolsoParcelasData, n637ReembolsoParcelasObservacao, A637ReembolsoParcelasObservacao, n638ReembolsoParcelasCreatedAt, A638ReembolsoParcelasCreatedAt, n639ReembolsoParcelasTaxaValor, A639ReembolsoParcelasTaxaValor, n640ReembolsoParcelasJurosValor, A640ReembolsoParcelasJurosValor, n641ReembolsoParcelasDiasPJuros, A641ReembolsoParcelasDiasPJuros, n518ReembolsoId, A518ReembolsoId, A634ReembolsoParcelasId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("ReembolsoParcelas");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ReembolsoParcelas"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2C82( ) ;
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
            EndLevel2C82( ) ;
         }
         CloseExtendedTableCursors2C82( ) ;
      }

      protected void DeferredUpdate2C82( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2C82( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2C82( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2C82( ) ;
            AfterConfirm2C82( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2C82( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002C10 */
                  pr_default.execute(8, new Object[] {A634ReembolsoParcelasId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("ReembolsoParcelas");
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
         sMode82 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2C82( ) ;
         Gx_mode = sMode82;
      }

      protected void OnDeleteControls2C82( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2C82( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2C82( ) ;
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

      public void ScanKeyStart2C82( )
      {
         /* Using cursor BC002C11 */
         pr_default.execute(9, new Object[] {A634ReembolsoParcelasId});
         RcdFound82 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound82 = 1;
            A634ReembolsoParcelasId = BC002C11_A634ReembolsoParcelasId[0];
            A635ReembolsoParcelasValor = BC002C11_A635ReembolsoParcelasValor[0];
            n635ReembolsoParcelasValor = BC002C11_n635ReembolsoParcelasValor[0];
            A636ReembolsoParcelasData = BC002C11_A636ReembolsoParcelasData[0];
            n636ReembolsoParcelasData = BC002C11_n636ReembolsoParcelasData[0];
            A637ReembolsoParcelasObservacao = BC002C11_A637ReembolsoParcelasObservacao[0];
            n637ReembolsoParcelasObservacao = BC002C11_n637ReembolsoParcelasObservacao[0];
            A638ReembolsoParcelasCreatedAt = BC002C11_A638ReembolsoParcelasCreatedAt[0];
            n638ReembolsoParcelasCreatedAt = BC002C11_n638ReembolsoParcelasCreatedAt[0];
            A639ReembolsoParcelasTaxaValor = BC002C11_A639ReembolsoParcelasTaxaValor[0];
            n639ReembolsoParcelasTaxaValor = BC002C11_n639ReembolsoParcelasTaxaValor[0];
            A640ReembolsoParcelasJurosValor = BC002C11_A640ReembolsoParcelasJurosValor[0];
            n640ReembolsoParcelasJurosValor = BC002C11_n640ReembolsoParcelasJurosValor[0];
            A641ReembolsoParcelasDiasPJuros = BC002C11_A641ReembolsoParcelasDiasPJuros[0];
            n641ReembolsoParcelasDiasPJuros = BC002C11_n641ReembolsoParcelasDiasPJuros[0];
            A518ReembolsoId = BC002C11_A518ReembolsoId[0];
            n518ReembolsoId = BC002C11_n518ReembolsoId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2C82( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound82 = 0;
         ScanKeyLoad2C82( ) ;
      }

      protected void ScanKeyLoad2C82( )
      {
         sMode82 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound82 = 1;
            A634ReembolsoParcelasId = BC002C11_A634ReembolsoParcelasId[0];
            A635ReembolsoParcelasValor = BC002C11_A635ReembolsoParcelasValor[0];
            n635ReembolsoParcelasValor = BC002C11_n635ReembolsoParcelasValor[0];
            A636ReembolsoParcelasData = BC002C11_A636ReembolsoParcelasData[0];
            n636ReembolsoParcelasData = BC002C11_n636ReembolsoParcelasData[0];
            A637ReembolsoParcelasObservacao = BC002C11_A637ReembolsoParcelasObservacao[0];
            n637ReembolsoParcelasObservacao = BC002C11_n637ReembolsoParcelasObservacao[0];
            A638ReembolsoParcelasCreatedAt = BC002C11_A638ReembolsoParcelasCreatedAt[0];
            n638ReembolsoParcelasCreatedAt = BC002C11_n638ReembolsoParcelasCreatedAt[0];
            A639ReembolsoParcelasTaxaValor = BC002C11_A639ReembolsoParcelasTaxaValor[0];
            n639ReembolsoParcelasTaxaValor = BC002C11_n639ReembolsoParcelasTaxaValor[0];
            A640ReembolsoParcelasJurosValor = BC002C11_A640ReembolsoParcelasJurosValor[0];
            n640ReembolsoParcelasJurosValor = BC002C11_n640ReembolsoParcelasJurosValor[0];
            A641ReembolsoParcelasDiasPJuros = BC002C11_A641ReembolsoParcelasDiasPJuros[0];
            n641ReembolsoParcelasDiasPJuros = BC002C11_n641ReembolsoParcelasDiasPJuros[0];
            A518ReembolsoId = BC002C11_A518ReembolsoId[0];
            n518ReembolsoId = BC002C11_n518ReembolsoId[0];
         }
         Gx_mode = sMode82;
      }

      protected void ScanKeyEnd2C82( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm2C82( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2C82( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2C82( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2C82( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2C82( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2C82( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2C82( )
      {
      }

      protected void send_integrity_lvl_hashes2C82( )
      {
      }

      protected void AddRow2C82( )
      {
         VarsToRow82( bcReembolsoParcelas) ;
      }

      protected void ReadRow2C82( )
      {
         RowToVars82( bcReembolsoParcelas, 1) ;
      }

      protected void InitializeNonKey2C82( )
      {
         A518ReembolsoId = 0;
         n518ReembolsoId = false;
         A635ReembolsoParcelasValor = 0;
         n635ReembolsoParcelasValor = false;
         A636ReembolsoParcelasData = DateTime.MinValue;
         n636ReembolsoParcelasData = false;
         A637ReembolsoParcelasObservacao = "";
         n637ReembolsoParcelasObservacao = false;
         A639ReembolsoParcelasTaxaValor = 0;
         n639ReembolsoParcelasTaxaValor = false;
         A640ReembolsoParcelasJurosValor = 0;
         n640ReembolsoParcelasJurosValor = false;
         A641ReembolsoParcelasDiasPJuros = 0;
         n641ReembolsoParcelasDiasPJuros = false;
         A638ReembolsoParcelasCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n638ReembolsoParcelasCreatedAt = false;
         Z635ReembolsoParcelasValor = 0;
         Z636ReembolsoParcelasData = DateTime.MinValue;
         Z637ReembolsoParcelasObservacao = "";
         Z638ReembolsoParcelasCreatedAt = (DateTime)(DateTime.MinValue);
         Z639ReembolsoParcelasTaxaValor = 0;
         Z640ReembolsoParcelasJurosValor = 0;
         Z641ReembolsoParcelasDiasPJuros = 0;
         Z518ReembolsoId = 0;
      }

      protected void InitAll2C82( )
      {
         A634ReembolsoParcelasId = 0;
         InitializeNonKey2C82( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A638ReembolsoParcelasCreatedAt = i638ReembolsoParcelasCreatedAt;
         n638ReembolsoParcelasCreatedAt = false;
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

      public void VarsToRow82( SdtReembolsoParcelas obj82 )
      {
         obj82.gxTpr_Mode = Gx_mode;
         obj82.gxTpr_Reembolsoid = A518ReembolsoId;
         obj82.gxTpr_Reembolsoparcelasvalor = A635ReembolsoParcelasValor;
         obj82.gxTpr_Reembolsoparcelasdata = A636ReembolsoParcelasData;
         obj82.gxTpr_Reembolsoparcelasobservacao = A637ReembolsoParcelasObservacao;
         obj82.gxTpr_Reembolsoparcelastaxavalor = A639ReembolsoParcelasTaxaValor;
         obj82.gxTpr_Reembolsoparcelasjurosvalor = A640ReembolsoParcelasJurosValor;
         obj82.gxTpr_Reembolsoparcelasdiaspjuros = A641ReembolsoParcelasDiasPJuros;
         obj82.gxTpr_Reembolsoparcelascreatedat = A638ReembolsoParcelasCreatedAt;
         obj82.gxTpr_Reembolsoparcelasid = A634ReembolsoParcelasId;
         obj82.gxTpr_Reembolsoparcelasid_Z = Z634ReembolsoParcelasId;
         obj82.gxTpr_Reembolsoid_Z = Z518ReembolsoId;
         obj82.gxTpr_Reembolsoparcelasvalor_Z = Z635ReembolsoParcelasValor;
         obj82.gxTpr_Reembolsoparcelasdata_Z = Z636ReembolsoParcelasData;
         obj82.gxTpr_Reembolsoparcelasobservacao_Z = Z637ReembolsoParcelasObservacao;
         obj82.gxTpr_Reembolsoparcelascreatedat_Z = Z638ReembolsoParcelasCreatedAt;
         obj82.gxTpr_Reembolsoparcelastaxavalor_Z = Z639ReembolsoParcelasTaxaValor;
         obj82.gxTpr_Reembolsoparcelasjurosvalor_Z = Z640ReembolsoParcelasJurosValor;
         obj82.gxTpr_Reembolsoparcelasdiaspjuros_Z = Z641ReembolsoParcelasDiasPJuros;
         obj82.gxTpr_Reembolsoid_N = (short)(Convert.ToInt16(n518ReembolsoId));
         obj82.gxTpr_Reembolsoparcelasvalor_N = (short)(Convert.ToInt16(n635ReembolsoParcelasValor));
         obj82.gxTpr_Reembolsoparcelasdata_N = (short)(Convert.ToInt16(n636ReembolsoParcelasData));
         obj82.gxTpr_Reembolsoparcelasobservacao_N = (short)(Convert.ToInt16(n637ReembolsoParcelasObservacao));
         obj82.gxTpr_Reembolsoparcelascreatedat_N = (short)(Convert.ToInt16(n638ReembolsoParcelasCreatedAt));
         obj82.gxTpr_Reembolsoparcelastaxavalor_N = (short)(Convert.ToInt16(n639ReembolsoParcelasTaxaValor));
         obj82.gxTpr_Reembolsoparcelasjurosvalor_N = (short)(Convert.ToInt16(n640ReembolsoParcelasJurosValor));
         obj82.gxTpr_Reembolsoparcelasdiaspjuros_N = (short)(Convert.ToInt16(n641ReembolsoParcelasDiasPJuros));
         obj82.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow82( SdtReembolsoParcelas obj82 )
      {
         obj82.gxTpr_Reembolsoparcelasid = A634ReembolsoParcelasId;
         return  ;
      }

      public void RowToVars82( SdtReembolsoParcelas obj82 ,
                               int forceLoad )
      {
         Gx_mode = obj82.gxTpr_Mode;
         A518ReembolsoId = obj82.gxTpr_Reembolsoid;
         n518ReembolsoId = false;
         A635ReembolsoParcelasValor = obj82.gxTpr_Reembolsoparcelasvalor;
         n635ReembolsoParcelasValor = false;
         A636ReembolsoParcelasData = obj82.gxTpr_Reembolsoparcelasdata;
         n636ReembolsoParcelasData = false;
         A637ReembolsoParcelasObservacao = obj82.gxTpr_Reembolsoparcelasobservacao;
         n637ReembolsoParcelasObservacao = false;
         A639ReembolsoParcelasTaxaValor = obj82.gxTpr_Reembolsoparcelastaxavalor;
         n639ReembolsoParcelasTaxaValor = false;
         A640ReembolsoParcelasJurosValor = obj82.gxTpr_Reembolsoparcelasjurosvalor;
         n640ReembolsoParcelasJurosValor = false;
         A641ReembolsoParcelasDiasPJuros = obj82.gxTpr_Reembolsoparcelasdiaspjuros;
         n641ReembolsoParcelasDiasPJuros = false;
         A638ReembolsoParcelasCreatedAt = obj82.gxTpr_Reembolsoparcelascreatedat;
         n638ReembolsoParcelasCreatedAt = false;
         A634ReembolsoParcelasId = obj82.gxTpr_Reembolsoparcelasid;
         Z634ReembolsoParcelasId = obj82.gxTpr_Reembolsoparcelasid_Z;
         Z518ReembolsoId = obj82.gxTpr_Reembolsoid_Z;
         Z635ReembolsoParcelasValor = obj82.gxTpr_Reembolsoparcelasvalor_Z;
         Z636ReembolsoParcelasData = obj82.gxTpr_Reembolsoparcelasdata_Z;
         Z637ReembolsoParcelasObservacao = obj82.gxTpr_Reembolsoparcelasobservacao_Z;
         Z638ReembolsoParcelasCreatedAt = obj82.gxTpr_Reembolsoparcelascreatedat_Z;
         Z639ReembolsoParcelasTaxaValor = obj82.gxTpr_Reembolsoparcelastaxavalor_Z;
         Z640ReembolsoParcelasJurosValor = obj82.gxTpr_Reembolsoparcelasjurosvalor_Z;
         Z641ReembolsoParcelasDiasPJuros = obj82.gxTpr_Reembolsoparcelasdiaspjuros_Z;
         n518ReembolsoId = (bool)(Convert.ToBoolean(obj82.gxTpr_Reembolsoid_N));
         n635ReembolsoParcelasValor = (bool)(Convert.ToBoolean(obj82.gxTpr_Reembolsoparcelasvalor_N));
         n636ReembolsoParcelasData = (bool)(Convert.ToBoolean(obj82.gxTpr_Reembolsoparcelasdata_N));
         n637ReembolsoParcelasObservacao = (bool)(Convert.ToBoolean(obj82.gxTpr_Reembolsoparcelasobservacao_N));
         n638ReembolsoParcelasCreatedAt = (bool)(Convert.ToBoolean(obj82.gxTpr_Reembolsoparcelascreatedat_N));
         n639ReembolsoParcelasTaxaValor = (bool)(Convert.ToBoolean(obj82.gxTpr_Reembolsoparcelastaxavalor_N));
         n640ReembolsoParcelasJurosValor = (bool)(Convert.ToBoolean(obj82.gxTpr_Reembolsoparcelasjurosvalor_N));
         n641ReembolsoParcelasDiasPJuros = (bool)(Convert.ToBoolean(obj82.gxTpr_Reembolsoparcelasdiaspjuros_N));
         Gx_mode = obj82.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A634ReembolsoParcelasId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2C82( ) ;
         ScanKeyStart2C82( ) ;
         if ( RcdFound82 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z634ReembolsoParcelasId = A634ReembolsoParcelasId;
         }
         ZM2C82( -2) ;
         OnLoadActions2C82( ) ;
         AddRow2C82( ) ;
         ScanKeyEnd2C82( ) ;
         if ( RcdFound82 == 0 )
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
         RowToVars82( bcReembolsoParcelas, 0) ;
         ScanKeyStart2C82( ) ;
         if ( RcdFound82 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z634ReembolsoParcelasId = A634ReembolsoParcelasId;
         }
         ZM2C82( -2) ;
         OnLoadActions2C82( ) ;
         AddRow2C82( ) ;
         ScanKeyEnd2C82( ) ;
         if ( RcdFound82 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2C82( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2C82( ) ;
         }
         else
         {
            if ( RcdFound82 == 1 )
            {
               if ( A634ReembolsoParcelasId != Z634ReembolsoParcelasId )
               {
                  A634ReembolsoParcelasId = Z634ReembolsoParcelasId;
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
                  Update2C82( ) ;
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
                  if ( A634ReembolsoParcelasId != Z634ReembolsoParcelasId )
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
                        Insert2C82( ) ;
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
                        Insert2C82( ) ;
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
         RowToVars82( bcReembolsoParcelas, 1) ;
         SaveImpl( ) ;
         VarsToRow82( bcReembolsoParcelas) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars82( bcReembolsoParcelas, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2C82( ) ;
         AfterTrn( ) ;
         VarsToRow82( bcReembolsoParcelas) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow82( bcReembolsoParcelas) ;
         }
         else
         {
            SdtReembolsoParcelas auxBC = new SdtReembolsoParcelas(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A634ReembolsoParcelasId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcReembolsoParcelas);
               auxBC.Save();
               bcReembolsoParcelas.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars82( bcReembolsoParcelas, 1) ;
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
         RowToVars82( bcReembolsoParcelas, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2C82( ) ;
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
               VarsToRow82( bcReembolsoParcelas) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow82( bcReembolsoParcelas) ;
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
         RowToVars82( bcReembolsoParcelas, 0) ;
         GetKey2C82( ) ;
         if ( RcdFound82 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A634ReembolsoParcelasId != Z634ReembolsoParcelasId )
            {
               A634ReembolsoParcelasId = Z634ReembolsoParcelasId;
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
            if ( A634ReembolsoParcelasId != Z634ReembolsoParcelasId )
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
         context.RollbackDataStores("reembolsoparcelas_bc",pr_default);
         VarsToRow82( bcReembolsoParcelas) ;
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
         Gx_mode = bcReembolsoParcelas.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcReembolsoParcelas.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcReembolsoParcelas )
         {
            bcReembolsoParcelas = (SdtReembolsoParcelas)(sdt);
            if ( StringUtil.StrCmp(bcReembolsoParcelas.gxTpr_Mode, "") == 0 )
            {
               bcReembolsoParcelas.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow82( bcReembolsoParcelas) ;
            }
            else
            {
               RowToVars82( bcReembolsoParcelas, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcReembolsoParcelas.gxTpr_Mode, "") == 0 )
            {
               bcReembolsoParcelas.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars82( bcReembolsoParcelas, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtReembolsoParcelas ReembolsoParcelas_BC
      {
         get {
            return bcReembolsoParcelas ;
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
         Z636ReembolsoParcelasData = DateTime.MinValue;
         A636ReembolsoParcelasData = DateTime.MinValue;
         Z637ReembolsoParcelasObservacao = "";
         A637ReembolsoParcelasObservacao = "";
         Z638ReembolsoParcelasCreatedAt = (DateTime)(DateTime.MinValue);
         A638ReembolsoParcelasCreatedAt = (DateTime)(DateTime.MinValue);
         BC002C5_A634ReembolsoParcelasId = new int[1] ;
         BC002C5_A635ReembolsoParcelasValor = new decimal[1] ;
         BC002C5_n635ReembolsoParcelasValor = new bool[] {false} ;
         BC002C5_A636ReembolsoParcelasData = new DateTime[] {DateTime.MinValue} ;
         BC002C5_n636ReembolsoParcelasData = new bool[] {false} ;
         BC002C5_A637ReembolsoParcelasObservacao = new string[] {""} ;
         BC002C5_n637ReembolsoParcelasObservacao = new bool[] {false} ;
         BC002C5_A638ReembolsoParcelasCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002C5_n638ReembolsoParcelasCreatedAt = new bool[] {false} ;
         BC002C5_A639ReembolsoParcelasTaxaValor = new decimal[1] ;
         BC002C5_n639ReembolsoParcelasTaxaValor = new bool[] {false} ;
         BC002C5_A640ReembolsoParcelasJurosValor = new decimal[1] ;
         BC002C5_n640ReembolsoParcelasJurosValor = new bool[] {false} ;
         BC002C5_A641ReembolsoParcelasDiasPJuros = new short[1] ;
         BC002C5_n641ReembolsoParcelasDiasPJuros = new bool[] {false} ;
         BC002C5_A518ReembolsoId = new int[1] ;
         BC002C5_n518ReembolsoId = new bool[] {false} ;
         BC002C4_A518ReembolsoId = new int[1] ;
         BC002C4_n518ReembolsoId = new bool[] {false} ;
         BC002C6_A634ReembolsoParcelasId = new int[1] ;
         BC002C3_A634ReembolsoParcelasId = new int[1] ;
         BC002C3_A635ReembolsoParcelasValor = new decimal[1] ;
         BC002C3_n635ReembolsoParcelasValor = new bool[] {false} ;
         BC002C3_A636ReembolsoParcelasData = new DateTime[] {DateTime.MinValue} ;
         BC002C3_n636ReembolsoParcelasData = new bool[] {false} ;
         BC002C3_A637ReembolsoParcelasObservacao = new string[] {""} ;
         BC002C3_n637ReembolsoParcelasObservacao = new bool[] {false} ;
         BC002C3_A638ReembolsoParcelasCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002C3_n638ReembolsoParcelasCreatedAt = new bool[] {false} ;
         BC002C3_A639ReembolsoParcelasTaxaValor = new decimal[1] ;
         BC002C3_n639ReembolsoParcelasTaxaValor = new bool[] {false} ;
         BC002C3_A640ReembolsoParcelasJurosValor = new decimal[1] ;
         BC002C3_n640ReembolsoParcelasJurosValor = new bool[] {false} ;
         BC002C3_A641ReembolsoParcelasDiasPJuros = new short[1] ;
         BC002C3_n641ReembolsoParcelasDiasPJuros = new bool[] {false} ;
         BC002C3_A518ReembolsoId = new int[1] ;
         BC002C3_n518ReembolsoId = new bool[] {false} ;
         sMode82 = "";
         BC002C2_A634ReembolsoParcelasId = new int[1] ;
         BC002C2_A635ReembolsoParcelasValor = new decimal[1] ;
         BC002C2_n635ReembolsoParcelasValor = new bool[] {false} ;
         BC002C2_A636ReembolsoParcelasData = new DateTime[] {DateTime.MinValue} ;
         BC002C2_n636ReembolsoParcelasData = new bool[] {false} ;
         BC002C2_A637ReembolsoParcelasObservacao = new string[] {""} ;
         BC002C2_n637ReembolsoParcelasObservacao = new bool[] {false} ;
         BC002C2_A638ReembolsoParcelasCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002C2_n638ReembolsoParcelasCreatedAt = new bool[] {false} ;
         BC002C2_A639ReembolsoParcelasTaxaValor = new decimal[1] ;
         BC002C2_n639ReembolsoParcelasTaxaValor = new bool[] {false} ;
         BC002C2_A640ReembolsoParcelasJurosValor = new decimal[1] ;
         BC002C2_n640ReembolsoParcelasJurosValor = new bool[] {false} ;
         BC002C2_A641ReembolsoParcelasDiasPJuros = new short[1] ;
         BC002C2_n641ReembolsoParcelasDiasPJuros = new bool[] {false} ;
         BC002C2_A518ReembolsoId = new int[1] ;
         BC002C2_n518ReembolsoId = new bool[] {false} ;
         BC002C8_A634ReembolsoParcelasId = new int[1] ;
         BC002C11_A634ReembolsoParcelasId = new int[1] ;
         BC002C11_A635ReembolsoParcelasValor = new decimal[1] ;
         BC002C11_n635ReembolsoParcelasValor = new bool[] {false} ;
         BC002C11_A636ReembolsoParcelasData = new DateTime[] {DateTime.MinValue} ;
         BC002C11_n636ReembolsoParcelasData = new bool[] {false} ;
         BC002C11_A637ReembolsoParcelasObservacao = new string[] {""} ;
         BC002C11_n637ReembolsoParcelasObservacao = new bool[] {false} ;
         BC002C11_A638ReembolsoParcelasCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002C11_n638ReembolsoParcelasCreatedAt = new bool[] {false} ;
         BC002C11_A639ReembolsoParcelasTaxaValor = new decimal[1] ;
         BC002C11_n639ReembolsoParcelasTaxaValor = new bool[] {false} ;
         BC002C11_A640ReembolsoParcelasJurosValor = new decimal[1] ;
         BC002C11_n640ReembolsoParcelasJurosValor = new bool[] {false} ;
         BC002C11_A641ReembolsoParcelasDiasPJuros = new short[1] ;
         BC002C11_n641ReembolsoParcelasDiasPJuros = new bool[] {false} ;
         BC002C11_A518ReembolsoId = new int[1] ;
         BC002C11_n518ReembolsoId = new bool[] {false} ;
         i638ReembolsoParcelasCreatedAt = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reembolsoparcelas_bc__default(),
            new Object[][] {
                new Object[] {
               BC002C2_A634ReembolsoParcelasId, BC002C2_A635ReembolsoParcelasValor, BC002C2_n635ReembolsoParcelasValor, BC002C2_A636ReembolsoParcelasData, BC002C2_n636ReembolsoParcelasData, BC002C2_A637ReembolsoParcelasObservacao, BC002C2_n637ReembolsoParcelasObservacao, BC002C2_A638ReembolsoParcelasCreatedAt, BC002C2_n638ReembolsoParcelasCreatedAt, BC002C2_A639ReembolsoParcelasTaxaValor,
               BC002C2_n639ReembolsoParcelasTaxaValor, BC002C2_A640ReembolsoParcelasJurosValor, BC002C2_n640ReembolsoParcelasJurosValor, BC002C2_A641ReembolsoParcelasDiasPJuros, BC002C2_n641ReembolsoParcelasDiasPJuros, BC002C2_A518ReembolsoId, BC002C2_n518ReembolsoId
               }
               , new Object[] {
               BC002C3_A634ReembolsoParcelasId, BC002C3_A635ReembolsoParcelasValor, BC002C3_n635ReembolsoParcelasValor, BC002C3_A636ReembolsoParcelasData, BC002C3_n636ReembolsoParcelasData, BC002C3_A637ReembolsoParcelasObservacao, BC002C3_n637ReembolsoParcelasObservacao, BC002C3_A638ReembolsoParcelasCreatedAt, BC002C3_n638ReembolsoParcelasCreatedAt, BC002C3_A639ReembolsoParcelasTaxaValor,
               BC002C3_n639ReembolsoParcelasTaxaValor, BC002C3_A640ReembolsoParcelasJurosValor, BC002C3_n640ReembolsoParcelasJurosValor, BC002C3_A641ReembolsoParcelasDiasPJuros, BC002C3_n641ReembolsoParcelasDiasPJuros, BC002C3_A518ReembolsoId, BC002C3_n518ReembolsoId
               }
               , new Object[] {
               BC002C4_A518ReembolsoId
               }
               , new Object[] {
               BC002C5_A634ReembolsoParcelasId, BC002C5_A635ReembolsoParcelasValor, BC002C5_n635ReembolsoParcelasValor, BC002C5_A636ReembolsoParcelasData, BC002C5_n636ReembolsoParcelasData, BC002C5_A637ReembolsoParcelasObservacao, BC002C5_n637ReembolsoParcelasObservacao, BC002C5_A638ReembolsoParcelasCreatedAt, BC002C5_n638ReembolsoParcelasCreatedAt, BC002C5_A639ReembolsoParcelasTaxaValor,
               BC002C5_n639ReembolsoParcelasTaxaValor, BC002C5_A640ReembolsoParcelasJurosValor, BC002C5_n640ReembolsoParcelasJurosValor, BC002C5_A641ReembolsoParcelasDiasPJuros, BC002C5_n641ReembolsoParcelasDiasPJuros, BC002C5_A518ReembolsoId, BC002C5_n518ReembolsoId
               }
               , new Object[] {
               BC002C6_A634ReembolsoParcelasId
               }
               , new Object[] {
               }
               , new Object[] {
               BC002C8_A634ReembolsoParcelasId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002C11_A634ReembolsoParcelasId, BC002C11_A635ReembolsoParcelasValor, BC002C11_n635ReembolsoParcelasValor, BC002C11_A636ReembolsoParcelasData, BC002C11_n636ReembolsoParcelasData, BC002C11_A637ReembolsoParcelasObservacao, BC002C11_n637ReembolsoParcelasObservacao, BC002C11_A638ReembolsoParcelasCreatedAt, BC002C11_n638ReembolsoParcelasCreatedAt, BC002C11_A639ReembolsoParcelasTaxaValor,
               BC002C11_n639ReembolsoParcelasTaxaValor, BC002C11_A640ReembolsoParcelasJurosValor, BC002C11_n640ReembolsoParcelasJurosValor, BC002C11_A641ReembolsoParcelasDiasPJuros, BC002C11_n641ReembolsoParcelasDiasPJuros, BC002C11_A518ReembolsoId, BC002C11_n518ReembolsoId
               }
            }
         );
         Z638ReembolsoParcelasCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n638ReembolsoParcelasCreatedAt = false;
         A638ReembolsoParcelasCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n638ReembolsoParcelasCreatedAt = false;
         i638ReembolsoParcelasCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n638ReembolsoParcelasCreatedAt = false;
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z641ReembolsoParcelasDiasPJuros ;
      private short A641ReembolsoParcelasDiasPJuros ;
      private short Gx_BScreen ;
      private short RcdFound82 ;
      private int trnEnded ;
      private int Z634ReembolsoParcelasId ;
      private int A634ReembolsoParcelasId ;
      private int Z518ReembolsoId ;
      private int A518ReembolsoId ;
      private decimal Z635ReembolsoParcelasValor ;
      private decimal A635ReembolsoParcelasValor ;
      private decimal Z639ReembolsoParcelasTaxaValor ;
      private decimal A639ReembolsoParcelasTaxaValor ;
      private decimal Z640ReembolsoParcelasJurosValor ;
      private decimal A640ReembolsoParcelasJurosValor ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode82 ;
      private DateTime Z638ReembolsoParcelasCreatedAt ;
      private DateTime A638ReembolsoParcelasCreatedAt ;
      private DateTime i638ReembolsoParcelasCreatedAt ;
      private DateTime Z636ReembolsoParcelasData ;
      private DateTime A636ReembolsoParcelasData ;
      private bool n638ReembolsoParcelasCreatedAt ;
      private bool n635ReembolsoParcelasValor ;
      private bool n636ReembolsoParcelasData ;
      private bool n637ReembolsoParcelasObservacao ;
      private bool n639ReembolsoParcelasTaxaValor ;
      private bool n640ReembolsoParcelasJurosValor ;
      private bool n641ReembolsoParcelasDiasPJuros ;
      private bool n518ReembolsoId ;
      private bool Gx_longc ;
      private string Z637ReembolsoParcelasObservacao ;
      private string A637ReembolsoParcelasObservacao ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC002C5_A634ReembolsoParcelasId ;
      private decimal[] BC002C5_A635ReembolsoParcelasValor ;
      private bool[] BC002C5_n635ReembolsoParcelasValor ;
      private DateTime[] BC002C5_A636ReembolsoParcelasData ;
      private bool[] BC002C5_n636ReembolsoParcelasData ;
      private string[] BC002C5_A637ReembolsoParcelasObservacao ;
      private bool[] BC002C5_n637ReembolsoParcelasObservacao ;
      private DateTime[] BC002C5_A638ReembolsoParcelasCreatedAt ;
      private bool[] BC002C5_n638ReembolsoParcelasCreatedAt ;
      private decimal[] BC002C5_A639ReembolsoParcelasTaxaValor ;
      private bool[] BC002C5_n639ReembolsoParcelasTaxaValor ;
      private decimal[] BC002C5_A640ReembolsoParcelasJurosValor ;
      private bool[] BC002C5_n640ReembolsoParcelasJurosValor ;
      private short[] BC002C5_A641ReembolsoParcelasDiasPJuros ;
      private bool[] BC002C5_n641ReembolsoParcelasDiasPJuros ;
      private int[] BC002C5_A518ReembolsoId ;
      private bool[] BC002C5_n518ReembolsoId ;
      private int[] BC002C4_A518ReembolsoId ;
      private bool[] BC002C4_n518ReembolsoId ;
      private int[] BC002C6_A634ReembolsoParcelasId ;
      private int[] BC002C3_A634ReembolsoParcelasId ;
      private decimal[] BC002C3_A635ReembolsoParcelasValor ;
      private bool[] BC002C3_n635ReembolsoParcelasValor ;
      private DateTime[] BC002C3_A636ReembolsoParcelasData ;
      private bool[] BC002C3_n636ReembolsoParcelasData ;
      private string[] BC002C3_A637ReembolsoParcelasObservacao ;
      private bool[] BC002C3_n637ReembolsoParcelasObservacao ;
      private DateTime[] BC002C3_A638ReembolsoParcelasCreatedAt ;
      private bool[] BC002C3_n638ReembolsoParcelasCreatedAt ;
      private decimal[] BC002C3_A639ReembolsoParcelasTaxaValor ;
      private bool[] BC002C3_n639ReembolsoParcelasTaxaValor ;
      private decimal[] BC002C3_A640ReembolsoParcelasJurosValor ;
      private bool[] BC002C3_n640ReembolsoParcelasJurosValor ;
      private short[] BC002C3_A641ReembolsoParcelasDiasPJuros ;
      private bool[] BC002C3_n641ReembolsoParcelasDiasPJuros ;
      private int[] BC002C3_A518ReembolsoId ;
      private bool[] BC002C3_n518ReembolsoId ;
      private int[] BC002C2_A634ReembolsoParcelasId ;
      private decimal[] BC002C2_A635ReembolsoParcelasValor ;
      private bool[] BC002C2_n635ReembolsoParcelasValor ;
      private DateTime[] BC002C2_A636ReembolsoParcelasData ;
      private bool[] BC002C2_n636ReembolsoParcelasData ;
      private string[] BC002C2_A637ReembolsoParcelasObservacao ;
      private bool[] BC002C2_n637ReembolsoParcelasObservacao ;
      private DateTime[] BC002C2_A638ReembolsoParcelasCreatedAt ;
      private bool[] BC002C2_n638ReembolsoParcelasCreatedAt ;
      private decimal[] BC002C2_A639ReembolsoParcelasTaxaValor ;
      private bool[] BC002C2_n639ReembolsoParcelasTaxaValor ;
      private decimal[] BC002C2_A640ReembolsoParcelasJurosValor ;
      private bool[] BC002C2_n640ReembolsoParcelasJurosValor ;
      private short[] BC002C2_A641ReembolsoParcelasDiasPJuros ;
      private bool[] BC002C2_n641ReembolsoParcelasDiasPJuros ;
      private int[] BC002C2_A518ReembolsoId ;
      private bool[] BC002C2_n518ReembolsoId ;
      private int[] BC002C8_A634ReembolsoParcelasId ;
      private int[] BC002C11_A634ReembolsoParcelasId ;
      private decimal[] BC002C11_A635ReembolsoParcelasValor ;
      private bool[] BC002C11_n635ReembolsoParcelasValor ;
      private DateTime[] BC002C11_A636ReembolsoParcelasData ;
      private bool[] BC002C11_n636ReembolsoParcelasData ;
      private string[] BC002C11_A637ReembolsoParcelasObservacao ;
      private bool[] BC002C11_n637ReembolsoParcelasObservacao ;
      private DateTime[] BC002C11_A638ReembolsoParcelasCreatedAt ;
      private bool[] BC002C11_n638ReembolsoParcelasCreatedAt ;
      private decimal[] BC002C11_A639ReembolsoParcelasTaxaValor ;
      private bool[] BC002C11_n639ReembolsoParcelasTaxaValor ;
      private decimal[] BC002C11_A640ReembolsoParcelasJurosValor ;
      private bool[] BC002C11_n640ReembolsoParcelasJurosValor ;
      private short[] BC002C11_A641ReembolsoParcelasDiasPJuros ;
      private bool[] BC002C11_n641ReembolsoParcelasDiasPJuros ;
      private int[] BC002C11_A518ReembolsoId ;
      private bool[] BC002C11_n518ReembolsoId ;
      private SdtReembolsoParcelas bcReembolsoParcelas ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class reembolsoparcelas_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC002C2;
          prmBC002C2 = new Object[] {
          new ParDef("ReembolsoParcelasId",GXType.Int32,9,0)
          };
          Object[] prmBC002C3;
          prmBC002C3 = new Object[] {
          new ParDef("ReembolsoParcelasId",GXType.Int32,9,0)
          };
          Object[] prmBC002C4;
          prmBC002C4 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002C5;
          prmBC002C5 = new Object[] {
          new ParDef("ReembolsoParcelasId",GXType.Int32,9,0)
          };
          Object[] prmBC002C6;
          prmBC002C6 = new Object[] {
          new ParDef("ReembolsoParcelasId",GXType.Int32,9,0)
          };
          Object[] prmBC002C7;
          prmBC002C7 = new Object[] {
          new ParDef("ReembolsoParcelasValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("ReembolsoParcelasData",GXType.Date,8,0){Nullable=true} ,
          new ParDef("ReembolsoParcelasObservacao",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ReembolsoParcelasCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ReembolsoParcelasTaxaValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("ReembolsoParcelasJurosValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("ReembolsoParcelasDiasPJuros",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002C8;
          prmBC002C8 = new Object[] {
          };
          Object[] prmBC002C9;
          prmBC002C9 = new Object[] {
          new ParDef("ReembolsoParcelasValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("ReembolsoParcelasData",GXType.Date,8,0){Nullable=true} ,
          new ParDef("ReembolsoParcelasObservacao",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ReembolsoParcelasCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ReembolsoParcelasTaxaValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("ReembolsoParcelasJurosValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("ReembolsoParcelasDiasPJuros",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ReembolsoParcelasId",GXType.Int32,9,0)
          };
          Object[] prmBC002C10;
          prmBC002C10 = new Object[] {
          new ParDef("ReembolsoParcelasId",GXType.Int32,9,0)
          };
          Object[] prmBC002C11;
          prmBC002C11 = new Object[] {
          new ParDef("ReembolsoParcelasId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC002C2", "SELECT ReembolsoParcelasId, ReembolsoParcelasValor, ReembolsoParcelasData, ReembolsoParcelasObservacao, ReembolsoParcelasCreatedAt, ReembolsoParcelasTaxaValor, ReembolsoParcelasJurosValor, ReembolsoParcelasDiasPJuros, ReembolsoId FROM ReembolsoParcelas WHERE ReembolsoParcelasId = :ReembolsoParcelasId  FOR UPDATE OF ReembolsoParcelas",true, GxErrorMask.GX_NOMASK, false, this,prmBC002C2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002C3", "SELECT ReembolsoParcelasId, ReembolsoParcelasValor, ReembolsoParcelasData, ReembolsoParcelasObservacao, ReembolsoParcelasCreatedAt, ReembolsoParcelasTaxaValor, ReembolsoParcelasJurosValor, ReembolsoParcelasDiasPJuros, ReembolsoId FROM ReembolsoParcelas WHERE ReembolsoParcelasId = :ReembolsoParcelasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002C3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002C4", "SELECT ReembolsoId FROM Reembolso WHERE ReembolsoId = :ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002C4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002C5", "SELECT TM1.ReembolsoParcelasId, TM1.ReembolsoParcelasValor, TM1.ReembolsoParcelasData, TM1.ReembolsoParcelasObservacao, TM1.ReembolsoParcelasCreatedAt, TM1.ReembolsoParcelasTaxaValor, TM1.ReembolsoParcelasJurosValor, TM1.ReembolsoParcelasDiasPJuros, TM1.ReembolsoId FROM ReembolsoParcelas TM1 WHERE TM1.ReembolsoParcelasId = :ReembolsoParcelasId ORDER BY TM1.ReembolsoParcelasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002C5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002C6", "SELECT ReembolsoParcelasId FROM ReembolsoParcelas WHERE ReembolsoParcelasId = :ReembolsoParcelasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002C6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002C7", "SAVEPOINT gxupdate;INSERT INTO ReembolsoParcelas(ReembolsoParcelasValor, ReembolsoParcelasData, ReembolsoParcelasObservacao, ReembolsoParcelasCreatedAt, ReembolsoParcelasTaxaValor, ReembolsoParcelasJurosValor, ReembolsoParcelasDiasPJuros, ReembolsoId) VALUES(:ReembolsoParcelasValor, :ReembolsoParcelasData, :ReembolsoParcelasObservacao, :ReembolsoParcelasCreatedAt, :ReembolsoParcelasTaxaValor, :ReembolsoParcelasJurosValor, :ReembolsoParcelasDiasPJuros, :ReembolsoId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002C7)
             ,new CursorDef("BC002C8", "SELECT currval('ReembolsoParcelasId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002C8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002C9", "SAVEPOINT gxupdate;UPDATE ReembolsoParcelas SET ReembolsoParcelasValor=:ReembolsoParcelasValor, ReembolsoParcelasData=:ReembolsoParcelasData, ReembolsoParcelasObservacao=:ReembolsoParcelasObservacao, ReembolsoParcelasCreatedAt=:ReembolsoParcelasCreatedAt, ReembolsoParcelasTaxaValor=:ReembolsoParcelasTaxaValor, ReembolsoParcelasJurosValor=:ReembolsoParcelasJurosValor, ReembolsoParcelasDiasPJuros=:ReembolsoParcelasDiasPJuros, ReembolsoId=:ReembolsoId  WHERE ReembolsoParcelasId = :ReembolsoParcelasId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002C9)
             ,new CursorDef("BC002C10", "SAVEPOINT gxupdate;DELETE FROM ReembolsoParcelas  WHERE ReembolsoParcelasId = :ReembolsoParcelasId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002C10)
             ,new CursorDef("BC002C11", "SELECT TM1.ReembolsoParcelasId, TM1.ReembolsoParcelasValor, TM1.ReembolsoParcelasData, TM1.ReembolsoParcelasObservacao, TM1.ReembolsoParcelasCreatedAt, TM1.ReembolsoParcelasTaxaValor, TM1.ReembolsoParcelasJurosValor, TM1.ReembolsoParcelasDiasPJuros, TM1.ReembolsoId FROM ReembolsoParcelas TM1 WHERE TM1.ReembolsoParcelasId = :ReembolsoParcelasId ORDER BY TM1.ReembolsoParcelasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002C11,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                return;
       }
    }

 }

}
