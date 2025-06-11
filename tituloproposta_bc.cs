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
   public class tituloproposta_bc : GxSilentTrn, IGxSilentTrn
   {
      public tituloproposta_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public tituloproposta_bc( IGxContext context )
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
         ReadRow1X44( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1X44( ) ;
         standaloneModal( ) ;
         AddRow1X44( ) ;
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
            E111X2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z261TituloId = A261TituloId;
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

      protected void CONFIRM_1X0( )
      {
         BeforeValidate1X44( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1X44( ) ;
            }
            else
            {
               CheckExtendedTable1X44( ) ;
               if ( AnyError == 0 )
               {
                  ZM1X44( 20) ;
                  ZM1X44( 21) ;
                  ZM1X44( 22) ;
                  ZM1X44( 23) ;
                  ZM1X44( 24) ;
                  ZM1X44( 25) ;
                  ZM1X44( 26) ;
                  ZM1X44( 27) ;
               }
               CloseExtendedTableCursors1X44( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E121X2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV24Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV25GXV1 = 1;
            while ( AV25GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV25GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "ClienteId") == 0 )
               {
                  AV11Insert_ClienteId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "TituloPropostaId") == 0 )
               {
                  AV20Insert_TituloPropostaId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "ContaId") == 0 )
               {
                  AV21Insert_ContaId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "CategoriaTituloId") == 0 )
               {
                  AV22Insert_CategoriaTituloId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV25GXV1 = (int)(AV25GXV1+1);
            }
         }
      }

      protected void E111X2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1X44( short GX_JID )
      {
         if ( ( GX_JID == 19 ) || ( GX_JID == 0 ) )
         {
            Z890NotaFiscalParcelamentoID = A890NotaFiscalParcelamentoID;
            Z262TituloValor = A262TituloValor;
            Z276TituloDesconto = A276TituloDesconto;
            Z284TituloDeleted = A284TituloDeleted;
            Z314TituloArchived = A314TituloArchived;
            Z263TituloVencimento = A263TituloVencimento;
            Z286TituloCompetenciaAno = A286TituloCompetenciaAno;
            Z287TituloCompetenciaMes = A287TituloCompetenciaMes;
            Z264TituloProrrogacao = A264TituloProrrogacao;
            Z265TituloCEP = A265TituloCEP;
            Z266TituloLogradouro = A266TituloLogradouro;
            Z294TituloNumeroEndereco = A294TituloNumeroEndereco;
            Z267TituloComplemento = A267TituloComplemento;
            Z268TituloBairro = A268TituloBairro;
            Z269TituloMunicipio = A269TituloMunicipio;
            Z498TituloJurosMora = A498TituloJurosMora;
            Z283TituloTipo = A283TituloTipo;
            Z500TituloCriacao = A500TituloCriacao;
            Z422ContaId = A422ContaId;
            Z426CategoriaTituloId = A426CategoriaTituloId;
            Z419TituloPropostaId = A419TituloPropostaId;
            Z295TituloCompetencia_F = A295TituloCompetencia_F;
            Z273TituloTotalMovimento_F = A273TituloTotalMovimento_F;
            Z301TituloTotalMultaJuros_F = A301TituloTotalMultaJuros_F;
            Z275TituloSaldo_F = A275TituloSaldo_F;
            Z282TituloStatus_F = A282TituloStatus_F;
            Z302TituloSaldoDebito_F = A302TituloSaldoDebito_F;
            Z303TituloSaldoCredito_F = A303TituloSaldoCredito_F;
            Z304TituloTotalMovimentoDebito_F = A304TituloTotalMovimentoDebito_F;
            Z305TituloTotalMovimentoCredito_F = A305TituloTotalMovimentoCredito_F;
            Z306TituloTotalMultaJurosDebito_F = A306TituloTotalMultaJurosDebito_F;
            Z307TituloTotalMultaJurosCredito_F = A307TituloTotalMultaJurosCredito_F;
         }
         if ( ( GX_JID == 20 ) || ( GX_JID == 0 ) )
         {
            Z295TituloCompetencia_F = A295TituloCompetencia_F;
            Z273TituloTotalMovimento_F = A273TituloTotalMovimento_F;
            Z301TituloTotalMultaJuros_F = A301TituloTotalMultaJuros_F;
            Z275TituloSaldo_F = A275TituloSaldo_F;
            Z282TituloStatus_F = A282TituloStatus_F;
            Z302TituloSaldoDebito_F = A302TituloSaldoDebito_F;
            Z303TituloSaldoCredito_F = A303TituloSaldoCredito_F;
            Z304TituloTotalMovimentoDebito_F = A304TituloTotalMovimentoDebito_F;
            Z305TituloTotalMovimentoCredito_F = A305TituloTotalMovimentoCredito_F;
            Z306TituloTotalMultaJurosDebito_F = A306TituloTotalMultaJurosDebito_F;
            Z307TituloTotalMultaJurosCredito_F = A307TituloTotalMultaJurosCredito_F;
         }
         if ( ( GX_JID == 21 ) || ( GX_JID == 0 ) )
         {
            Z295TituloCompetencia_F = A295TituloCompetencia_F;
            Z273TituloTotalMovimento_F = A273TituloTotalMovimento_F;
            Z301TituloTotalMultaJuros_F = A301TituloTotalMultaJuros_F;
            Z275TituloSaldo_F = A275TituloSaldo_F;
            Z282TituloStatus_F = A282TituloStatus_F;
            Z302TituloSaldoDebito_F = A302TituloSaldoDebito_F;
            Z303TituloSaldoCredito_F = A303TituloSaldoCredito_F;
            Z304TituloTotalMovimentoDebito_F = A304TituloTotalMovimentoDebito_F;
            Z305TituloTotalMovimentoCredito_F = A305TituloTotalMovimentoCredito_F;
            Z306TituloTotalMultaJurosDebito_F = A306TituloTotalMultaJurosDebito_F;
            Z307TituloTotalMultaJurosCredito_F = A307TituloTotalMultaJurosCredito_F;
         }
         if ( ( GX_JID == 22 ) || ( GX_JID == 0 ) )
         {
            Z794NotaFiscalId = A794NotaFiscalId;
            Z295TituloCompetencia_F = A295TituloCompetencia_F;
            Z273TituloTotalMovimento_F = A273TituloTotalMovimento_F;
            Z301TituloTotalMultaJuros_F = A301TituloTotalMultaJuros_F;
            Z275TituloSaldo_F = A275TituloSaldo_F;
            Z282TituloStatus_F = A282TituloStatus_F;
            Z302TituloSaldoDebito_F = A302TituloSaldoDebito_F;
            Z303TituloSaldoCredito_F = A303TituloSaldoCredito_F;
            Z304TituloTotalMovimentoDebito_F = A304TituloTotalMovimentoDebito_F;
            Z305TituloTotalMovimentoCredito_F = A305TituloTotalMovimentoCredito_F;
            Z306TituloTotalMultaJurosDebito_F = A306TituloTotalMultaJurosDebito_F;
            Z307TituloTotalMultaJurosCredito_F = A307TituloTotalMultaJurosCredito_F;
         }
         if ( ( GX_JID == 23 ) || ( GX_JID == 0 ) )
         {
            Z501PropostaTaxaAdministrativa = A501PropostaTaxaAdministrativa;
            Z295TituloCompetencia_F = A295TituloCompetencia_F;
            Z273TituloTotalMovimento_F = A273TituloTotalMovimento_F;
            Z301TituloTotalMultaJuros_F = A301TituloTotalMultaJuros_F;
            Z275TituloSaldo_F = A275TituloSaldo_F;
            Z282TituloStatus_F = A282TituloStatus_F;
            Z302TituloSaldoDebito_F = A302TituloSaldoDebito_F;
            Z303TituloSaldoCredito_F = A303TituloSaldoCredito_F;
            Z304TituloTotalMovimentoDebito_F = A304TituloTotalMovimentoDebito_F;
            Z305TituloTotalMovimentoCredito_F = A305TituloTotalMovimentoCredito_F;
            Z306TituloTotalMultaJurosDebito_F = A306TituloTotalMultaJurosDebito_F;
            Z307TituloTotalMultaJurosCredito_F = A307TituloTotalMultaJurosCredito_F;
         }
         if ( ( GX_JID == 24 ) || ( GX_JID == 0 ) )
         {
            Z168ClienteId = A168ClienteId;
            Z295TituloCompetencia_F = A295TituloCompetencia_F;
            Z273TituloTotalMovimento_F = A273TituloTotalMovimento_F;
            Z301TituloTotalMultaJuros_F = A301TituloTotalMultaJuros_F;
            Z275TituloSaldo_F = A275TituloSaldo_F;
            Z282TituloStatus_F = A282TituloStatus_F;
            Z302TituloSaldoDebito_F = A302TituloSaldoDebito_F;
            Z303TituloSaldoCredito_F = A303TituloSaldoCredito_F;
            Z304TituloTotalMovimentoDebito_F = A304TituloTotalMovimentoDebito_F;
            Z305TituloTotalMovimentoCredito_F = A305TituloTotalMovimentoCredito_F;
            Z306TituloTotalMultaJurosDebito_F = A306TituloTotalMultaJurosDebito_F;
            Z307TituloTotalMultaJurosCredito_F = A307TituloTotalMultaJurosCredito_F;
         }
         if ( ( GX_JID == 25 ) || ( GX_JID == 0 ) )
         {
            Z170ClienteRazaoSocial = A170ClienteRazaoSocial;
            Z295TituloCompetencia_F = A295TituloCompetencia_F;
            Z273TituloTotalMovimento_F = A273TituloTotalMovimento_F;
            Z301TituloTotalMultaJuros_F = A301TituloTotalMultaJuros_F;
            Z275TituloSaldo_F = A275TituloSaldo_F;
            Z282TituloStatus_F = A282TituloStatus_F;
            Z302TituloSaldoDebito_F = A302TituloSaldoDebito_F;
            Z303TituloSaldoCredito_F = A303TituloSaldoCredito_F;
            Z304TituloTotalMovimentoDebito_F = A304TituloTotalMovimentoDebito_F;
            Z305TituloTotalMovimentoCredito_F = A305TituloTotalMovimentoCredito_F;
            Z306TituloTotalMultaJurosDebito_F = A306TituloTotalMultaJurosDebito_F;
            Z307TituloTotalMultaJurosCredito_F = A307TituloTotalMultaJurosCredito_F;
         }
         if ( ( GX_JID == 26 ) || ( GX_JID == 0 ) )
         {
            Z295TituloCompetencia_F = A295TituloCompetencia_F;
            Z273TituloTotalMovimento_F = A273TituloTotalMovimento_F;
            Z301TituloTotalMultaJuros_F = A301TituloTotalMultaJuros_F;
            Z275TituloSaldo_F = A275TituloSaldo_F;
            Z282TituloStatus_F = A282TituloStatus_F;
            Z302TituloSaldoDebito_F = A302TituloSaldoDebito_F;
            Z303TituloSaldoCredito_F = A303TituloSaldoCredito_F;
            Z304TituloTotalMovimentoDebito_F = A304TituloTotalMovimentoDebito_F;
            Z305TituloTotalMovimentoCredito_F = A305TituloTotalMovimentoCredito_F;
            Z306TituloTotalMultaJurosDebito_F = A306TituloTotalMultaJurosDebito_F;
            Z307TituloTotalMultaJurosCredito_F = A307TituloTotalMultaJurosCredito_F;
         }
         if ( ( GX_JID == 27 ) || ( GX_JID == 0 ) )
         {
            Z295TituloCompetencia_F = A295TituloCompetencia_F;
            Z273TituloTotalMovimento_F = A273TituloTotalMovimento_F;
            Z301TituloTotalMultaJuros_F = A301TituloTotalMultaJuros_F;
            Z275TituloSaldo_F = A275TituloSaldo_F;
            Z282TituloStatus_F = A282TituloStatus_F;
            Z302TituloSaldoDebito_F = A302TituloSaldoDebito_F;
            Z303TituloSaldoCredito_F = A303TituloSaldoCredito_F;
            Z304TituloTotalMovimentoDebito_F = A304TituloTotalMovimentoDebito_F;
            Z305TituloTotalMovimentoCredito_F = A305TituloTotalMovimentoCredito_F;
            Z306TituloTotalMultaJurosDebito_F = A306TituloTotalMultaJurosDebito_F;
            Z307TituloTotalMultaJurosCredito_F = A307TituloTotalMultaJurosCredito_F;
         }
         if ( GX_JID == -19 )
         {
            Z890NotaFiscalParcelamentoID = A890NotaFiscalParcelamentoID;
            Z261TituloId = A261TituloId;
            Z262TituloValor = A262TituloValor;
            Z276TituloDesconto = A276TituloDesconto;
            Z284TituloDeleted = A284TituloDeleted;
            Z314TituloArchived = A314TituloArchived;
            Z263TituloVencimento = A263TituloVencimento;
            Z286TituloCompetenciaAno = A286TituloCompetenciaAno;
            Z287TituloCompetenciaMes = A287TituloCompetenciaMes;
            Z264TituloProrrogacao = A264TituloProrrogacao;
            Z265TituloCEP = A265TituloCEP;
            Z266TituloLogradouro = A266TituloLogradouro;
            Z294TituloNumeroEndereco = A294TituloNumeroEndereco;
            Z267TituloComplemento = A267TituloComplemento;
            Z268TituloBairro = A268TituloBairro;
            Z269TituloMunicipio = A269TituloMunicipio;
            Z498TituloJurosMora = A498TituloJurosMora;
            Z283TituloTipo = A283TituloTipo;
            Z500TituloCriacao = A500TituloCriacao;
            Z422ContaId = A422ContaId;
            Z426CategoriaTituloId = A426CategoriaTituloId;
            Z419TituloPropostaId = A419TituloPropostaId;
            Z794NotaFiscalId = A794NotaFiscalId;
            Z168ClienteId = A168ClienteId;
            Z170ClienteRazaoSocial = A170ClienteRazaoSocial;
            Z273TituloTotalMovimento_F = A273TituloTotalMovimento_F;
            Z301TituloTotalMultaJuros_F = A301TituloTotalMultaJuros_F;
            Z501PropostaTaxaAdministrativa = A501PropostaTaxaAdministrativa;
         }
      }

      protected void standaloneNotModal( )
      {
         AV24Pgmname = "TituloProposta_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A284TituloDeleted) && ( Gx_BScreen == 0 ) )
         {
            A284TituloDeleted = false;
            n284TituloDeleted = false;
         }
         if ( IsIns( )  && (DateTime.MinValue==A500TituloCriacao) && ( Gx_BScreen == 0 ) )
         {
            A500TituloCriacao = DateTimeUtil.ServerNow( context, pr_default);
            n500TituloCriacao = false;
         }
         /* Using cursor BC001X6 */
         pr_default.execute(4, new Object[] {n890NotaFiscalParcelamentoID, A890NotaFiscalParcelamentoID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (Guid.Empty==A890NotaFiscalParcelamentoID) ) )
            {
               GX_msglist.addItem("Não existe 'Nota Fiscal Parcelamento'.", "ForeignKeyNotFound", 1, "NOTAFISCALPARCELAMENTOID");
               AnyError = 1;
            }
         }
         A794NotaFiscalId = BC001X6_A794NotaFiscalId[0];
         n794NotaFiscalId = BC001X6_n794NotaFiscalId[0];
         pr_default.close(4);
         /* Using cursor BC001X8 */
         pr_default.execute(6, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (Guid.Empty==A794NotaFiscalId) ) )
            {
               GX_msglist.addItem("Não existe 'NotaFiscal'.", "ForeignKeyNotFound", 1, "NOTAFISCALID");
               AnyError = 1;
            }
         }
         A168ClienteId = BC001X8_A168ClienteId[0];
         n168ClienteId = BC001X8_n168ClienteId[0];
         pr_default.close(6);
         /* Using cursor BC001X9 */
         pr_default.execute(7, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A168ClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
               AnyError = 1;
            }
         }
         A170ClienteRazaoSocial = BC001X9_A170ClienteRazaoSocial[0];
         n170ClienteRazaoSocial = BC001X9_n170ClienteRazaoSocial[0];
         pr_default.close(7);
      }

      protected void Load1X44( )
      {
         /* Using cursor BC001X16 */
         pr_default.execute(10, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound44 = 1;
            A890NotaFiscalParcelamentoID = BC001X16_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = BC001X16_n890NotaFiscalParcelamentoID[0];
            A794NotaFiscalId = BC001X16_A794NotaFiscalId[0];
            n794NotaFiscalId = BC001X16_n794NotaFiscalId[0];
            A170ClienteRazaoSocial = BC001X16_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = BC001X16_n170ClienteRazaoSocial[0];
            A262TituloValor = BC001X16_A262TituloValor[0];
            n262TituloValor = BC001X16_n262TituloValor[0];
            A276TituloDesconto = BC001X16_A276TituloDesconto[0];
            n276TituloDesconto = BC001X16_n276TituloDesconto[0];
            A284TituloDeleted = BC001X16_A284TituloDeleted[0];
            n284TituloDeleted = BC001X16_n284TituloDeleted[0];
            A314TituloArchived = BC001X16_A314TituloArchived[0];
            n314TituloArchived = BC001X16_n314TituloArchived[0];
            A263TituloVencimento = BC001X16_A263TituloVencimento[0];
            n263TituloVencimento = BC001X16_n263TituloVencimento[0];
            A286TituloCompetenciaAno = BC001X16_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = BC001X16_n286TituloCompetenciaAno[0];
            A287TituloCompetenciaMes = BC001X16_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = BC001X16_n287TituloCompetenciaMes[0];
            A264TituloProrrogacao = BC001X16_A264TituloProrrogacao[0];
            n264TituloProrrogacao = BC001X16_n264TituloProrrogacao[0];
            A265TituloCEP = BC001X16_A265TituloCEP[0];
            n265TituloCEP = BC001X16_n265TituloCEP[0];
            A266TituloLogradouro = BC001X16_A266TituloLogradouro[0];
            n266TituloLogradouro = BC001X16_n266TituloLogradouro[0];
            A294TituloNumeroEndereco = BC001X16_A294TituloNumeroEndereco[0];
            n294TituloNumeroEndereco = BC001X16_n294TituloNumeroEndereco[0];
            A267TituloComplemento = BC001X16_A267TituloComplemento[0];
            n267TituloComplemento = BC001X16_n267TituloComplemento[0];
            A268TituloBairro = BC001X16_A268TituloBairro[0];
            n268TituloBairro = BC001X16_n268TituloBairro[0];
            A269TituloMunicipio = BC001X16_A269TituloMunicipio[0];
            n269TituloMunicipio = BC001X16_n269TituloMunicipio[0];
            A498TituloJurosMora = BC001X16_A498TituloJurosMora[0];
            n498TituloJurosMora = BC001X16_n498TituloJurosMora[0];
            A283TituloTipo = BC001X16_A283TituloTipo[0];
            n283TituloTipo = BC001X16_n283TituloTipo[0];
            A501PropostaTaxaAdministrativa = BC001X16_A501PropostaTaxaAdministrativa[0];
            n501PropostaTaxaAdministrativa = BC001X16_n501PropostaTaxaAdministrativa[0];
            A500TituloCriacao = BC001X16_A500TituloCriacao[0];
            n500TituloCriacao = BC001X16_n500TituloCriacao[0];
            A422ContaId = BC001X16_A422ContaId[0];
            n422ContaId = BC001X16_n422ContaId[0];
            A426CategoriaTituloId = BC001X16_A426CategoriaTituloId[0];
            n426CategoriaTituloId = BC001X16_n426CategoriaTituloId[0];
            A419TituloPropostaId = BC001X16_A419TituloPropostaId[0];
            n419TituloPropostaId = BC001X16_n419TituloPropostaId[0];
            A168ClienteId = BC001X16_A168ClienteId[0];
            n168ClienteId = BC001X16_n168ClienteId[0];
            A273TituloTotalMovimento_F = BC001X16_A273TituloTotalMovimento_F[0];
            n273TituloTotalMovimento_F = BC001X16_n273TituloTotalMovimento_F[0];
            A301TituloTotalMultaJuros_F = BC001X16_A301TituloTotalMultaJuros_F[0];
            n301TituloTotalMultaJuros_F = BC001X16_n301TituloTotalMultaJuros_F[0];
            ZM1X44( -19) ;
         }
         pr_default.close(10);
         OnLoadActions1X44( ) ;
      }

      protected void OnLoadActions1X44( )
      {
         A303TituloSaldoCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? (A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F : (decimal)(0));
         A302TituloSaldoDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? (A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F : (decimal)(0));
         A275TituloSaldo_F = (decimal)((A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F);
         A282TituloStatus_F = ((Convert.ToDecimal(0)==A275TituloSaldo_F) ? "Liquidado" : ((A275TituloSaldo_F==A262TituloValor) ? "Aberto" : "Baixado parcialmente"));
         A307TituloTotalMultaJurosCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? GetTituloTotalMultaJurosCredito_F0( A261TituloId) : (decimal)(0));
         A306TituloTotalMultaJurosDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? GetTituloTotalMultaJurosDebito_F0( A261TituloId) : (decimal)(0));
         A305TituloTotalMovimentoCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? GetTituloTotalMovimentoCredito_F0( A261TituloId) : (decimal)(0));
         A304TituloTotalMovimentoDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? GetTituloTotalMovimentoDebito_F0( A261TituloId) : (decimal)(0));
         A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
         if ( (0==A419TituloPropostaId) )
         {
            A419TituloPropostaId = 0;
            n419TituloPropostaId = false;
            n419TituloPropostaId = true;
            n419TituloPropostaId = true;
         }
         if ( (0==A422ContaId) )
         {
            A422ContaId = 0;
            n422ContaId = false;
            n422ContaId = true;
            n422ContaId = true;
         }
         if ( (0==A426CategoriaTituloId) )
         {
            A426CategoriaTituloId = 0;
            n426CategoriaTituloId = false;
            n426CategoriaTituloId = true;
            n426CategoriaTituloId = true;
         }
      }

      protected void CheckExtendedTable1X44( )
      {
         standaloneModal( ) ;
         /* Using cursor BC001X11 */
         pr_default.execute(8, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A273TituloTotalMovimento_F = BC001X11_A273TituloTotalMovimento_F[0];
            n273TituloTotalMovimento_F = BC001X11_n273TituloTotalMovimento_F[0];
         }
         else
         {
            A273TituloTotalMovimento_F = 0;
            n273TituloTotalMovimento_F = false;
         }
         pr_default.close(8);
         A303TituloSaldoCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? (A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F : (decimal)(0));
         A302TituloSaldoDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? (A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F : (decimal)(0));
         A275TituloSaldo_F = (decimal)((A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F);
         A282TituloStatus_F = ((Convert.ToDecimal(0)==A275TituloSaldo_F) ? "Liquidado" : ((A275TituloSaldo_F==A262TituloValor) ? "Aberto" : "Baixado parcialmente"));
         /* Using cursor BC001X13 */
         pr_default.execute(9, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            A301TituloTotalMultaJuros_F = BC001X13_A301TituloTotalMultaJuros_F[0];
            n301TituloTotalMultaJuros_F = BC001X13_n301TituloTotalMultaJuros_F[0];
         }
         else
         {
            A301TituloTotalMultaJuros_F = 0;
            n301TituloTotalMultaJuros_F = false;
         }
         pr_default.close(9);
         A307TituloTotalMultaJurosCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? GetTituloTotalMultaJurosCredito_F0( A261TituloId) : (decimal)(0));
         A306TituloTotalMultaJurosDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? GetTituloTotalMultaJurosDebito_F0( A261TituloId) : (decimal)(0));
         A305TituloTotalMovimentoCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? GetTituloTotalMovimentoCredito_F0( A261TituloId) : (decimal)(0));
         A304TituloTotalMovimentoDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? GetTituloTotalMovimentoDebito_F0( A261TituloId) : (decimal)(0));
         if ( ( A262TituloValor < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
         if ( ! ( ( StringUtil.StrCmp(A283TituloTipo, "DEBITO") == 0 ) || ( StringUtil.StrCmp(A283TituloTipo, "CREDITO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A283TituloTipo)) ) )
         {
            GX_msglist.addItem("Campo Titulo Tipo fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( (0==A419TituloPropostaId) )
         {
            A419TituloPropostaId = 0;
            n419TituloPropostaId = false;
            n419TituloPropostaId = true;
            n419TituloPropostaId = true;
         }
         /* Using cursor BC001X7 */
         pr_default.execute(5, new Object[] {n419TituloPropostaId, A419TituloPropostaId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A419TituloPropostaId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Titulo Proposta Id'.", "ForeignKeyNotFound", 1, "TITULOPROPOSTAID");
               AnyError = 1;
            }
         }
         A501PropostaTaxaAdministrativa = BC001X7_A501PropostaTaxaAdministrativa[0];
         n501PropostaTaxaAdministrativa = BC001X7_n501PropostaTaxaAdministrativa[0];
         pr_default.close(5);
         if ( (0==A422ContaId) )
         {
            A422ContaId = 0;
            n422ContaId = false;
            n422ContaId = true;
            n422ContaId = true;
         }
         /* Using cursor BC001X4 */
         pr_default.execute(2, new Object[] {n422ContaId, A422ContaId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A422ContaId) ) )
            {
               GX_msglist.addItem("Não existe 'Conta'.", "ForeignKeyNotFound", 1, "CONTAID");
               AnyError = 1;
            }
         }
         pr_default.close(2);
         if ( (0==A426CategoriaTituloId) )
         {
            A426CategoriaTituloId = 0;
            n426CategoriaTituloId = false;
            n426CategoriaTituloId = true;
            n426CategoriaTituloId = true;
         }
         /* Using cursor BC001X5 */
         pr_default.execute(3, new Object[] {n426CategoriaTituloId, A426CategoriaTituloId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A426CategoriaTituloId) ) )
            {
               GX_msglist.addItem("Não existe 'CategoriaTitulo'.", "ForeignKeyNotFound", 1, "CATEGORIATITULOID");
               AnyError = 1;
            }
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors1X44( )
      {
         pr_default.close(8);
         pr_default.close(9);
         pr_default.close(5);
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1X44( )
      {
         /* Using cursor BC001X17 */
         pr_default.execute(11, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound44 = 1;
         }
         else
         {
            RcdFound44 = 0;
         }
         pr_default.close(11);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001X3 */
         pr_default.execute(1, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1X44( 19) ;
            RcdFound44 = 1;
            A890NotaFiscalParcelamentoID = BC001X3_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = BC001X3_n890NotaFiscalParcelamentoID[0];
            A261TituloId = BC001X3_A261TituloId[0];
            n261TituloId = BC001X3_n261TituloId[0];
            A262TituloValor = BC001X3_A262TituloValor[0];
            n262TituloValor = BC001X3_n262TituloValor[0];
            A276TituloDesconto = BC001X3_A276TituloDesconto[0];
            n276TituloDesconto = BC001X3_n276TituloDesconto[0];
            A284TituloDeleted = BC001X3_A284TituloDeleted[0];
            n284TituloDeleted = BC001X3_n284TituloDeleted[0];
            A314TituloArchived = BC001X3_A314TituloArchived[0];
            n314TituloArchived = BC001X3_n314TituloArchived[0];
            A263TituloVencimento = BC001X3_A263TituloVencimento[0];
            n263TituloVencimento = BC001X3_n263TituloVencimento[0];
            A286TituloCompetenciaAno = BC001X3_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = BC001X3_n286TituloCompetenciaAno[0];
            A287TituloCompetenciaMes = BC001X3_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = BC001X3_n287TituloCompetenciaMes[0];
            A264TituloProrrogacao = BC001X3_A264TituloProrrogacao[0];
            n264TituloProrrogacao = BC001X3_n264TituloProrrogacao[0];
            A265TituloCEP = BC001X3_A265TituloCEP[0];
            n265TituloCEP = BC001X3_n265TituloCEP[0];
            A266TituloLogradouro = BC001X3_A266TituloLogradouro[0];
            n266TituloLogradouro = BC001X3_n266TituloLogradouro[0];
            A294TituloNumeroEndereco = BC001X3_A294TituloNumeroEndereco[0];
            n294TituloNumeroEndereco = BC001X3_n294TituloNumeroEndereco[0];
            A267TituloComplemento = BC001X3_A267TituloComplemento[0];
            n267TituloComplemento = BC001X3_n267TituloComplemento[0];
            A268TituloBairro = BC001X3_A268TituloBairro[0];
            n268TituloBairro = BC001X3_n268TituloBairro[0];
            A269TituloMunicipio = BC001X3_A269TituloMunicipio[0];
            n269TituloMunicipio = BC001X3_n269TituloMunicipio[0];
            A498TituloJurosMora = BC001X3_A498TituloJurosMora[0];
            n498TituloJurosMora = BC001X3_n498TituloJurosMora[0];
            A283TituloTipo = BC001X3_A283TituloTipo[0];
            n283TituloTipo = BC001X3_n283TituloTipo[0];
            A500TituloCriacao = BC001X3_A500TituloCriacao[0];
            n500TituloCriacao = BC001X3_n500TituloCriacao[0];
            A422ContaId = BC001X3_A422ContaId[0];
            n422ContaId = BC001X3_n422ContaId[0];
            A426CategoriaTituloId = BC001X3_A426CategoriaTituloId[0];
            n426CategoriaTituloId = BC001X3_n426CategoriaTituloId[0];
            A419TituloPropostaId = BC001X3_A419TituloPropostaId[0];
            n419TituloPropostaId = BC001X3_n419TituloPropostaId[0];
            Z261TituloId = A261TituloId;
            sMode44 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1X44( ) ;
            if ( AnyError == 1 )
            {
               RcdFound44 = 0;
               InitializeNonKey1X44( ) ;
            }
            Gx_mode = sMode44;
         }
         else
         {
            RcdFound44 = 0;
            InitializeNonKey1X44( ) ;
            sMode44 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode44;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1X44( ) ;
         if ( RcdFound44 == 0 )
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
         CONFIRM_1X0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1X44( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001X2 */
            pr_default.execute(0, new Object[] {n261TituloId, A261TituloId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Titulo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z890NotaFiscalParcelamentoID != BC001X2_A890NotaFiscalParcelamentoID[0] ) || ( Z262TituloValor != BC001X2_A262TituloValor[0] ) || ( Z276TituloDesconto != BC001X2_A276TituloDesconto[0] ) || ( Z284TituloDeleted != BC001X2_A284TituloDeleted[0] ) || ( Z314TituloArchived != BC001X2_A314TituloArchived[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z263TituloVencimento ) != DateTimeUtil.ResetTime ( BC001X2_A263TituloVencimento[0] ) ) || ( Z286TituloCompetenciaAno != BC001X2_A286TituloCompetenciaAno[0] ) || ( Z287TituloCompetenciaMes != BC001X2_A287TituloCompetenciaMes[0] ) || ( DateTimeUtil.ResetTime ( Z264TituloProrrogacao ) != DateTimeUtil.ResetTime ( BC001X2_A264TituloProrrogacao[0] ) ) || ( StringUtil.StrCmp(Z265TituloCEP, BC001X2_A265TituloCEP[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z266TituloLogradouro, BC001X2_A266TituloLogradouro[0]) != 0 ) || ( StringUtil.StrCmp(Z294TituloNumeroEndereco, BC001X2_A294TituloNumeroEndereco[0]) != 0 ) || ( StringUtil.StrCmp(Z267TituloComplemento, BC001X2_A267TituloComplemento[0]) != 0 ) || ( StringUtil.StrCmp(Z268TituloBairro, BC001X2_A268TituloBairro[0]) != 0 ) || ( StringUtil.StrCmp(Z269TituloMunicipio, BC001X2_A269TituloMunicipio[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z498TituloJurosMora != BC001X2_A498TituloJurosMora[0] ) || ( StringUtil.StrCmp(Z283TituloTipo, BC001X2_A283TituloTipo[0]) != 0 ) || ( Z500TituloCriacao != BC001X2_A500TituloCriacao[0] ) || ( Z422ContaId != BC001X2_A422ContaId[0] ) || ( Z426CategoriaTituloId != BC001X2_A426CategoriaTituloId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z419TituloPropostaId != BC001X2_A419TituloPropostaId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Titulo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1X44( )
      {
         BeforeValidate1X44( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1X44( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1X44( 0) ;
            CheckOptimisticConcurrency1X44( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1X44( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1X44( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001X18 */
                     pr_default.execute(12, new Object[] {n890NotaFiscalParcelamentoID, A890NotaFiscalParcelamentoID, n262TituloValor, A262TituloValor, n276TituloDesconto, A276TituloDesconto, n284TituloDeleted, A284TituloDeleted, n314TituloArchived, A314TituloArchived, n263TituloVencimento, A263TituloVencimento, n286TituloCompetenciaAno, A286TituloCompetenciaAno, n287TituloCompetenciaMes, A287TituloCompetenciaMes, n264TituloProrrogacao, A264TituloProrrogacao, n265TituloCEP, A265TituloCEP, n266TituloLogradouro, A266TituloLogradouro, n294TituloNumeroEndereco, A294TituloNumeroEndereco, n267TituloComplemento, A267TituloComplemento, n268TituloBairro, A268TituloBairro, n269TituloMunicipio, A269TituloMunicipio, n498TituloJurosMora, A498TituloJurosMora, n283TituloTipo, A283TituloTipo, n500TituloCriacao, A500TituloCriacao, n422ContaId, A422ContaId, n426CategoriaTituloId, A426CategoriaTituloId, n419TituloPropostaId, A419TituloPropostaId});
                     pr_default.close(12);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC001X19 */
                     pr_default.execute(13);
                     A261TituloId = BC001X19_A261TituloId[0];
                     n261TituloId = BC001X19_n261TituloId[0];
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Titulo");
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
               Load1X44( ) ;
            }
            EndLevel1X44( ) ;
         }
         CloseExtendedTableCursors1X44( ) ;
      }

      protected void Update1X44( )
      {
         BeforeValidate1X44( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1X44( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1X44( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1X44( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1X44( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001X20 */
                     pr_default.execute(14, new Object[] {n890NotaFiscalParcelamentoID, A890NotaFiscalParcelamentoID, n262TituloValor, A262TituloValor, n276TituloDesconto, A276TituloDesconto, n284TituloDeleted, A284TituloDeleted, n314TituloArchived, A314TituloArchived, n263TituloVencimento, A263TituloVencimento, n286TituloCompetenciaAno, A286TituloCompetenciaAno, n287TituloCompetenciaMes, A287TituloCompetenciaMes, n264TituloProrrogacao, A264TituloProrrogacao, n265TituloCEP, A265TituloCEP, n266TituloLogradouro, A266TituloLogradouro, n294TituloNumeroEndereco, A294TituloNumeroEndereco, n267TituloComplemento, A267TituloComplemento, n268TituloBairro, A268TituloBairro, n269TituloMunicipio, A269TituloMunicipio, n498TituloJurosMora, A498TituloJurosMora, n283TituloTipo, A283TituloTipo, n500TituloCriacao, A500TituloCriacao, n422ContaId, A422ContaId, n426CategoriaTituloId, A426CategoriaTituloId, n419TituloPropostaId, A419TituloPropostaId, n261TituloId, A261TituloId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("Titulo");
                     if ( (pr_default.getStatus(14) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Titulo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1X44( ) ;
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
            EndLevel1X44( ) ;
         }
         CloseExtendedTableCursors1X44( ) ;
      }

      protected void DeferredUpdate1X44( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1X44( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1X44( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1X44( ) ;
            AfterConfirm1X44( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1X44( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001X21 */
                  pr_default.execute(15, new Object[] {n261TituloId, A261TituloId});
                  pr_default.close(15);
                  pr_default.SmartCacheProvider.SetUpdated("Titulo");
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
         sMode44 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1X44( ) ;
         Gx_mode = sMode44;
      }

      protected void OnDeleteControls1X44( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001X23 */
            pr_default.execute(16, new Object[] {n261TituloId, A261TituloId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               A273TituloTotalMovimento_F = BC001X23_A273TituloTotalMovimento_F[0];
               n273TituloTotalMovimento_F = BC001X23_n273TituloTotalMovimento_F[0];
            }
            else
            {
               A273TituloTotalMovimento_F = 0;
               n273TituloTotalMovimento_F = false;
            }
            pr_default.close(16);
            /* Using cursor BC001X25 */
            pr_default.execute(17, new Object[] {n261TituloId, A261TituloId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               A301TituloTotalMultaJuros_F = BC001X25_A301TituloTotalMultaJuros_F[0];
               n301TituloTotalMultaJuros_F = BC001X25_n301TituloTotalMultaJuros_F[0];
            }
            else
            {
               A301TituloTotalMultaJuros_F = 0;
               n301TituloTotalMultaJuros_F = false;
            }
            pr_default.close(17);
            A275TituloSaldo_F = (decimal)((A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F);
            A282TituloStatus_F = ((Convert.ToDecimal(0)==A275TituloSaldo_F) ? "Liquidado" : ((A275TituloSaldo_F==A262TituloValor) ? "Aberto" : "Baixado parcialmente"));
            A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
            A303TituloSaldoCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? (A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F : (decimal)(0));
            A302TituloSaldoDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? (A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F : (decimal)(0));
            A307TituloTotalMultaJurosCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? GetTituloTotalMultaJurosCredito_F0( A261TituloId) : (decimal)(0));
            A306TituloTotalMultaJurosDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? GetTituloTotalMultaJurosDebito_F0( A261TituloId) : (decimal)(0));
            A305TituloTotalMovimentoCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? GetTituloTotalMovimentoCredito_F0( A261TituloId) : (decimal)(0));
            A304TituloTotalMovimentoDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? GetTituloTotalMovimentoDebito_F0( A261TituloId) : (decimal)(0));
            /* Using cursor BC001X26 */
            pr_default.execute(18, new Object[] {n419TituloPropostaId, A419TituloPropostaId});
            A501PropostaTaxaAdministrativa = BC001X26_A501PropostaTaxaAdministrativa[0];
            n501PropostaTaxaAdministrativa = BC001X26_n501PropostaTaxaAdministrativa[0];
            pr_default.close(18);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC001X27 */
            pr_default.execute(19, new Object[] {n261TituloId, A261TituloId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Boleto"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor BC001X28 */
            pr_default.execute(20, new Object[] {n261TituloId, A261TituloId});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"TituloMovimento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
         }
      }

      protected void EndLevel1X44( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1X44( ) ;
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

      public void ScanKeyStart1X44( )
      {
         /* Scan By routine */
         /* Using cursor BC001X31 */
         pr_default.execute(21, new Object[] {n261TituloId, A261TituloId});
         RcdFound44 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound44 = 1;
            A890NotaFiscalParcelamentoID = BC001X31_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = BC001X31_n890NotaFiscalParcelamentoID[0];
            A794NotaFiscalId = BC001X31_A794NotaFiscalId[0];
            n794NotaFiscalId = BC001X31_n794NotaFiscalId[0];
            A261TituloId = BC001X31_A261TituloId[0];
            n261TituloId = BC001X31_n261TituloId[0];
            A170ClienteRazaoSocial = BC001X31_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = BC001X31_n170ClienteRazaoSocial[0];
            A262TituloValor = BC001X31_A262TituloValor[0];
            n262TituloValor = BC001X31_n262TituloValor[0];
            A276TituloDesconto = BC001X31_A276TituloDesconto[0];
            n276TituloDesconto = BC001X31_n276TituloDesconto[0];
            A284TituloDeleted = BC001X31_A284TituloDeleted[0];
            n284TituloDeleted = BC001X31_n284TituloDeleted[0];
            A314TituloArchived = BC001X31_A314TituloArchived[0];
            n314TituloArchived = BC001X31_n314TituloArchived[0];
            A263TituloVencimento = BC001X31_A263TituloVencimento[0];
            n263TituloVencimento = BC001X31_n263TituloVencimento[0];
            A286TituloCompetenciaAno = BC001X31_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = BC001X31_n286TituloCompetenciaAno[0];
            A287TituloCompetenciaMes = BC001X31_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = BC001X31_n287TituloCompetenciaMes[0];
            A264TituloProrrogacao = BC001X31_A264TituloProrrogacao[0];
            n264TituloProrrogacao = BC001X31_n264TituloProrrogacao[0];
            A265TituloCEP = BC001X31_A265TituloCEP[0];
            n265TituloCEP = BC001X31_n265TituloCEP[0];
            A266TituloLogradouro = BC001X31_A266TituloLogradouro[0];
            n266TituloLogradouro = BC001X31_n266TituloLogradouro[0];
            A294TituloNumeroEndereco = BC001X31_A294TituloNumeroEndereco[0];
            n294TituloNumeroEndereco = BC001X31_n294TituloNumeroEndereco[0];
            A267TituloComplemento = BC001X31_A267TituloComplemento[0];
            n267TituloComplemento = BC001X31_n267TituloComplemento[0];
            A268TituloBairro = BC001X31_A268TituloBairro[0];
            n268TituloBairro = BC001X31_n268TituloBairro[0];
            A269TituloMunicipio = BC001X31_A269TituloMunicipio[0];
            n269TituloMunicipio = BC001X31_n269TituloMunicipio[0];
            A498TituloJurosMora = BC001X31_A498TituloJurosMora[0];
            n498TituloJurosMora = BC001X31_n498TituloJurosMora[0];
            A283TituloTipo = BC001X31_A283TituloTipo[0];
            n283TituloTipo = BC001X31_n283TituloTipo[0];
            A501PropostaTaxaAdministrativa = BC001X31_A501PropostaTaxaAdministrativa[0];
            n501PropostaTaxaAdministrativa = BC001X31_n501PropostaTaxaAdministrativa[0];
            A500TituloCriacao = BC001X31_A500TituloCriacao[0];
            n500TituloCriacao = BC001X31_n500TituloCriacao[0];
            A422ContaId = BC001X31_A422ContaId[0];
            n422ContaId = BC001X31_n422ContaId[0];
            A426CategoriaTituloId = BC001X31_A426CategoriaTituloId[0];
            n426CategoriaTituloId = BC001X31_n426CategoriaTituloId[0];
            A419TituloPropostaId = BC001X31_A419TituloPropostaId[0];
            n419TituloPropostaId = BC001X31_n419TituloPropostaId[0];
            A168ClienteId = BC001X31_A168ClienteId[0];
            n168ClienteId = BC001X31_n168ClienteId[0];
            A273TituloTotalMovimento_F = BC001X31_A273TituloTotalMovimento_F[0];
            n273TituloTotalMovimento_F = BC001X31_n273TituloTotalMovimento_F[0];
            A301TituloTotalMultaJuros_F = BC001X31_A301TituloTotalMultaJuros_F[0];
            n301TituloTotalMultaJuros_F = BC001X31_n301TituloTotalMultaJuros_F[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1X44( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound44 = 0;
         ScanKeyLoad1X44( ) ;
      }

      protected void ScanKeyLoad1X44( )
      {
         sMode44 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound44 = 1;
            A890NotaFiscalParcelamentoID = BC001X31_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = BC001X31_n890NotaFiscalParcelamentoID[0];
            A794NotaFiscalId = BC001X31_A794NotaFiscalId[0];
            n794NotaFiscalId = BC001X31_n794NotaFiscalId[0];
            A261TituloId = BC001X31_A261TituloId[0];
            n261TituloId = BC001X31_n261TituloId[0];
            A170ClienteRazaoSocial = BC001X31_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = BC001X31_n170ClienteRazaoSocial[0];
            A262TituloValor = BC001X31_A262TituloValor[0];
            n262TituloValor = BC001X31_n262TituloValor[0];
            A276TituloDesconto = BC001X31_A276TituloDesconto[0];
            n276TituloDesconto = BC001X31_n276TituloDesconto[0];
            A284TituloDeleted = BC001X31_A284TituloDeleted[0];
            n284TituloDeleted = BC001X31_n284TituloDeleted[0];
            A314TituloArchived = BC001X31_A314TituloArchived[0];
            n314TituloArchived = BC001X31_n314TituloArchived[0];
            A263TituloVencimento = BC001X31_A263TituloVencimento[0];
            n263TituloVencimento = BC001X31_n263TituloVencimento[0];
            A286TituloCompetenciaAno = BC001X31_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = BC001X31_n286TituloCompetenciaAno[0];
            A287TituloCompetenciaMes = BC001X31_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = BC001X31_n287TituloCompetenciaMes[0];
            A264TituloProrrogacao = BC001X31_A264TituloProrrogacao[0];
            n264TituloProrrogacao = BC001X31_n264TituloProrrogacao[0];
            A265TituloCEP = BC001X31_A265TituloCEP[0];
            n265TituloCEP = BC001X31_n265TituloCEP[0];
            A266TituloLogradouro = BC001X31_A266TituloLogradouro[0];
            n266TituloLogradouro = BC001X31_n266TituloLogradouro[0];
            A294TituloNumeroEndereco = BC001X31_A294TituloNumeroEndereco[0];
            n294TituloNumeroEndereco = BC001X31_n294TituloNumeroEndereco[0];
            A267TituloComplemento = BC001X31_A267TituloComplemento[0];
            n267TituloComplemento = BC001X31_n267TituloComplemento[0];
            A268TituloBairro = BC001X31_A268TituloBairro[0];
            n268TituloBairro = BC001X31_n268TituloBairro[0];
            A269TituloMunicipio = BC001X31_A269TituloMunicipio[0];
            n269TituloMunicipio = BC001X31_n269TituloMunicipio[0];
            A498TituloJurosMora = BC001X31_A498TituloJurosMora[0];
            n498TituloJurosMora = BC001X31_n498TituloJurosMora[0];
            A283TituloTipo = BC001X31_A283TituloTipo[0];
            n283TituloTipo = BC001X31_n283TituloTipo[0];
            A501PropostaTaxaAdministrativa = BC001X31_A501PropostaTaxaAdministrativa[0];
            n501PropostaTaxaAdministrativa = BC001X31_n501PropostaTaxaAdministrativa[0];
            A500TituloCriacao = BC001X31_A500TituloCriacao[0];
            n500TituloCriacao = BC001X31_n500TituloCriacao[0];
            A422ContaId = BC001X31_A422ContaId[0];
            n422ContaId = BC001X31_n422ContaId[0];
            A426CategoriaTituloId = BC001X31_A426CategoriaTituloId[0];
            n426CategoriaTituloId = BC001X31_n426CategoriaTituloId[0];
            A419TituloPropostaId = BC001X31_A419TituloPropostaId[0];
            n419TituloPropostaId = BC001X31_n419TituloPropostaId[0];
            A168ClienteId = BC001X31_A168ClienteId[0];
            n168ClienteId = BC001X31_n168ClienteId[0];
            A273TituloTotalMovimento_F = BC001X31_A273TituloTotalMovimento_F[0];
            n273TituloTotalMovimento_F = BC001X31_n273TituloTotalMovimento_F[0];
            A301TituloTotalMultaJuros_F = BC001X31_A301TituloTotalMultaJuros_F[0];
            n301TituloTotalMultaJuros_F = BC001X31_n301TituloTotalMultaJuros_F[0];
         }
         Gx_mode = sMode44;
      }

      protected void ScanKeyEnd1X44( )
      {
         pr_default.close(21);
      }

      protected void AfterConfirm1X44( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1X44( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1X44( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1X44( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1X44( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1X44( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1X44( )
      {
      }

      protected void send_integrity_lvl_hashes1X44( )
      {
      }

      protected void AddRow1X44( )
      {
         VarsToRow44( bcTituloProposta) ;
      }

      protected void ReadRow1X44( )
      {
         RowToVars44( bcTituloProposta, 1) ;
      }

      protected void InitializeNonKey1X44( )
      {
         A794NotaFiscalId = Guid.Empty;
         n794NotaFiscalId = false;
         A890NotaFiscalParcelamentoID = Guid.Empty;
         n890NotaFiscalParcelamentoID = false;
         A304TituloTotalMovimentoDebito_F = 0;
         A305TituloTotalMovimentoCredito_F = 0;
         A306TituloTotalMultaJurosDebito_F = 0;
         A307TituloTotalMultaJurosCredito_F = 0;
         A295TituloCompetencia_F = "";
         A275TituloSaldo_F = 0;
         A282TituloStatus_F = "";
         A302TituloSaldoDebito_F = 0;
         A303TituloSaldoCredito_F = 0;
         A168ClienteId = 0;
         n168ClienteId = false;
         A170ClienteRazaoSocial = "";
         n170ClienteRazaoSocial = false;
         A262TituloValor = 0;
         n262TituloValor = false;
         A276TituloDesconto = 0;
         n276TituloDesconto = false;
         A314TituloArchived = false;
         n314TituloArchived = false;
         A263TituloVencimento = DateTime.MinValue;
         n263TituloVencimento = false;
         A286TituloCompetenciaAno = 0;
         n286TituloCompetenciaAno = false;
         A287TituloCompetenciaMes = 0;
         n287TituloCompetenciaMes = false;
         A264TituloProrrogacao = DateTime.MinValue;
         n264TituloProrrogacao = false;
         A265TituloCEP = "";
         n265TituloCEP = false;
         A266TituloLogradouro = "";
         n266TituloLogradouro = false;
         A294TituloNumeroEndereco = "";
         n294TituloNumeroEndereco = false;
         A267TituloComplemento = "";
         n267TituloComplemento = false;
         A268TituloBairro = "";
         n268TituloBairro = false;
         A269TituloMunicipio = "";
         n269TituloMunicipio = false;
         A498TituloJurosMora = 0;
         n498TituloJurosMora = false;
         A283TituloTipo = "";
         n283TituloTipo = false;
         A419TituloPropostaId = 0;
         n419TituloPropostaId = false;
         A501PropostaTaxaAdministrativa = 0;
         n501PropostaTaxaAdministrativa = false;
         A422ContaId = 0;
         n422ContaId = false;
         A426CategoriaTituloId = 0;
         n426CategoriaTituloId = false;
         A273TituloTotalMovimento_F = 0;
         n273TituloTotalMovimento_F = false;
         A301TituloTotalMultaJuros_F = 0;
         n301TituloTotalMultaJuros_F = false;
         A284TituloDeleted = false;
         n284TituloDeleted = false;
         A500TituloCriacao = DateTimeUtil.ServerNow( context, pr_default);
         n500TituloCriacao = false;
         Z890NotaFiscalParcelamentoID = Guid.Empty;
         Z262TituloValor = 0;
         Z276TituloDesconto = 0;
         Z284TituloDeleted = false;
         Z314TituloArchived = false;
         Z263TituloVencimento = DateTime.MinValue;
         Z286TituloCompetenciaAno = 0;
         Z287TituloCompetenciaMes = 0;
         Z264TituloProrrogacao = DateTime.MinValue;
         Z265TituloCEP = "";
         Z266TituloLogradouro = "";
         Z294TituloNumeroEndereco = "";
         Z267TituloComplemento = "";
         Z268TituloBairro = "";
         Z269TituloMunicipio = "";
         Z498TituloJurosMora = 0;
         Z283TituloTipo = "";
         Z500TituloCriacao = (DateTime)(DateTime.MinValue);
         Z422ContaId = 0;
         Z426CategoriaTituloId = 0;
         Z419TituloPropostaId = 0;
      }

      protected void InitAll1X44( )
      {
         A261TituloId = 0;
         n261TituloId = false;
         InitializeNonKey1X44( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A284TituloDeleted = i284TituloDeleted;
         n284TituloDeleted = false;
         A500TituloCriacao = i500TituloCriacao;
         n500TituloCriacao = false;
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

      public void VarsToRow44( SdtTituloProposta obj44 )
      {
         obj44.gxTpr_Mode = Gx_mode;
         obj44.gxTpr_Titulototalmovimentodebito_f = A304TituloTotalMovimentoDebito_F;
         obj44.gxTpr_Titulototalmovimentocredito_f = A305TituloTotalMovimentoCredito_F;
         obj44.gxTpr_Titulototalmultajurosdebito_f = A306TituloTotalMultaJurosDebito_F;
         obj44.gxTpr_Titulototalmultajuroscredito_f = A307TituloTotalMultaJurosCredito_F;
         obj44.gxTpr_Titulocompetencia_f = A295TituloCompetencia_F;
         obj44.gxTpr_Titulosaldo_f = A275TituloSaldo_F;
         obj44.gxTpr_Titulostatus_f = A282TituloStatus_F;
         obj44.gxTpr_Titulosaldodebito_f = A302TituloSaldoDebito_F;
         obj44.gxTpr_Titulosaldocredito_f = A303TituloSaldoCredito_F;
         obj44.gxTpr_Clienteid = A168ClienteId;
         obj44.gxTpr_Clienterazaosocial = A170ClienteRazaoSocial;
         obj44.gxTpr_Titulovalor = A262TituloValor;
         obj44.gxTpr_Titulodesconto = A276TituloDesconto;
         obj44.gxTpr_Tituloarchived = A314TituloArchived;
         obj44.gxTpr_Titulovencimento = A263TituloVencimento;
         obj44.gxTpr_Titulocompetenciaano = A286TituloCompetenciaAno;
         obj44.gxTpr_Titulocompetenciames = A287TituloCompetenciaMes;
         obj44.gxTpr_Tituloprorrogacao = A264TituloProrrogacao;
         obj44.gxTpr_Titulocep = A265TituloCEP;
         obj44.gxTpr_Titulologradouro = A266TituloLogradouro;
         obj44.gxTpr_Titulonumeroendereco = A294TituloNumeroEndereco;
         obj44.gxTpr_Titulocomplemento = A267TituloComplemento;
         obj44.gxTpr_Titulobairro = A268TituloBairro;
         obj44.gxTpr_Titulomunicipio = A269TituloMunicipio;
         obj44.gxTpr_Titulojurosmora = A498TituloJurosMora;
         obj44.gxTpr_Titulotipo = A283TituloTipo;
         obj44.gxTpr_Titulopropostaid = A419TituloPropostaId;
         obj44.gxTpr_Propostataxaadministrativa = A501PropostaTaxaAdministrativa;
         obj44.gxTpr_Contaid = A422ContaId;
         obj44.gxTpr_Categoriatituloid = A426CategoriaTituloId;
         obj44.gxTpr_Titulototalmovimento_f = A273TituloTotalMovimento_F;
         obj44.gxTpr_Titulototalmultajuros_f = A301TituloTotalMultaJuros_F;
         obj44.gxTpr_Titulodeleted = A284TituloDeleted;
         obj44.gxTpr_Titulocriacao = A500TituloCriacao;
         obj44.gxTpr_Tituloid = A261TituloId;
         obj44.gxTpr_Tituloid_Z = Z261TituloId;
         obj44.gxTpr_Clienteid_Z = Z168ClienteId;
         obj44.gxTpr_Clienterazaosocial_Z = Z170ClienteRazaoSocial;
         obj44.gxTpr_Titulovalor_Z = Z262TituloValor;
         obj44.gxTpr_Titulodesconto_Z = Z276TituloDesconto;
         obj44.gxTpr_Titulodeleted_Z = Z284TituloDeleted;
         obj44.gxTpr_Tituloarchived_Z = Z314TituloArchived;
         obj44.gxTpr_Titulovencimento_Z = Z263TituloVencimento;
         obj44.gxTpr_Titulocompetenciaano_Z = Z286TituloCompetenciaAno;
         obj44.gxTpr_Titulocompetenciames_Z = Z287TituloCompetenciaMes;
         obj44.gxTpr_Titulocompetencia_f_Z = Z295TituloCompetencia_F;
         obj44.gxTpr_Tituloprorrogacao_Z = Z264TituloProrrogacao;
         obj44.gxTpr_Titulocep_Z = Z265TituloCEP;
         obj44.gxTpr_Titulologradouro_Z = Z266TituloLogradouro;
         obj44.gxTpr_Titulonumeroendereco_Z = Z294TituloNumeroEndereco;
         obj44.gxTpr_Titulocomplemento_Z = Z267TituloComplemento;
         obj44.gxTpr_Titulobairro_Z = Z268TituloBairro;
         obj44.gxTpr_Titulomunicipio_Z = Z269TituloMunicipio;
         obj44.gxTpr_Titulojurosmora_Z = Z498TituloJurosMora;
         obj44.gxTpr_Titulotipo_Z = Z283TituloTipo;
         obj44.gxTpr_Titulopropostaid_Z = Z419TituloPropostaId;
         obj44.gxTpr_Propostataxaadministrativa_Z = Z501PropostaTaxaAdministrativa;
         obj44.gxTpr_Contaid_Z = Z422ContaId;
         obj44.gxTpr_Titulocriacao_Z = Z500TituloCriacao;
         obj44.gxTpr_Categoriatituloid_Z = Z426CategoriaTituloId;
         obj44.gxTpr_Titulototalmovimento_f_Z = Z273TituloTotalMovimento_F;
         obj44.gxTpr_Titulototalmultajuros_f_Z = Z301TituloTotalMultaJuros_F;
         obj44.gxTpr_Titulosaldo_f_Z = Z275TituloSaldo_F;
         obj44.gxTpr_Titulostatus_f_Z = Z282TituloStatus_F;
         obj44.gxTpr_Titulosaldodebito_f_Z = Z302TituloSaldoDebito_F;
         obj44.gxTpr_Titulosaldocredito_f_Z = Z303TituloSaldoCredito_F;
         obj44.gxTpr_Titulototalmovimentodebito_f_Z = Z304TituloTotalMovimentoDebito_F;
         obj44.gxTpr_Titulototalmovimentocredito_f_Z = Z305TituloTotalMovimentoCredito_F;
         obj44.gxTpr_Titulototalmultajurosdebito_f_Z = Z306TituloTotalMultaJurosDebito_F;
         obj44.gxTpr_Titulototalmultajuroscredito_f_Z = Z307TituloTotalMultaJurosCredito_F;
         obj44.gxTpr_Tituloid_N = (short)(Convert.ToInt16(n261TituloId));
         obj44.gxTpr_Clienteid_N = (short)(Convert.ToInt16(n168ClienteId));
         obj44.gxTpr_Clienterazaosocial_N = (short)(Convert.ToInt16(n170ClienteRazaoSocial));
         obj44.gxTpr_Titulovalor_N = (short)(Convert.ToInt16(n262TituloValor));
         obj44.gxTpr_Titulodesconto_N = (short)(Convert.ToInt16(n276TituloDesconto));
         obj44.gxTpr_Titulodeleted_N = (short)(Convert.ToInt16(n284TituloDeleted));
         obj44.gxTpr_Tituloarchived_N = (short)(Convert.ToInt16(n314TituloArchived));
         obj44.gxTpr_Titulovencimento_N = (short)(Convert.ToInt16(n263TituloVencimento));
         obj44.gxTpr_Titulocompetenciaano_N = (short)(Convert.ToInt16(n286TituloCompetenciaAno));
         obj44.gxTpr_Titulocompetenciames_N = (short)(Convert.ToInt16(n287TituloCompetenciaMes));
         obj44.gxTpr_Tituloprorrogacao_N = (short)(Convert.ToInt16(n264TituloProrrogacao));
         obj44.gxTpr_Titulocep_N = (short)(Convert.ToInt16(n265TituloCEP));
         obj44.gxTpr_Titulologradouro_N = (short)(Convert.ToInt16(n266TituloLogradouro));
         obj44.gxTpr_Titulonumeroendereco_N = (short)(Convert.ToInt16(n294TituloNumeroEndereco));
         obj44.gxTpr_Titulocomplemento_N = (short)(Convert.ToInt16(n267TituloComplemento));
         obj44.gxTpr_Titulobairro_N = (short)(Convert.ToInt16(n268TituloBairro));
         obj44.gxTpr_Titulomunicipio_N = (short)(Convert.ToInt16(n269TituloMunicipio));
         obj44.gxTpr_Titulojurosmora_N = (short)(Convert.ToInt16(n498TituloJurosMora));
         obj44.gxTpr_Titulotipo_N = (short)(Convert.ToInt16(n283TituloTipo));
         obj44.gxTpr_Titulopropostaid_N = (short)(Convert.ToInt16(n419TituloPropostaId));
         obj44.gxTpr_Propostataxaadministrativa_N = (short)(Convert.ToInt16(n501PropostaTaxaAdministrativa));
         obj44.gxTpr_Contaid_N = (short)(Convert.ToInt16(n422ContaId));
         obj44.gxTpr_Titulocriacao_N = (short)(Convert.ToInt16(n500TituloCriacao));
         obj44.gxTpr_Categoriatituloid_N = (short)(Convert.ToInt16(n426CategoriaTituloId));
         obj44.gxTpr_Titulototalmovimento_f_N = (short)(Convert.ToInt16(n273TituloTotalMovimento_F));
         obj44.gxTpr_Titulototalmultajuros_f_N = (short)(Convert.ToInt16(n301TituloTotalMultaJuros_F));
         obj44.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow44( SdtTituloProposta obj44 )
      {
         obj44.gxTpr_Tituloid = A261TituloId;
         return  ;
      }

      public void RowToVars44( SdtTituloProposta obj44 ,
                               int forceLoad )
      {
         Gx_mode = obj44.gxTpr_Mode;
         A304TituloTotalMovimentoDebito_F = obj44.gxTpr_Titulototalmovimentodebito_f;
         A305TituloTotalMovimentoCredito_F = obj44.gxTpr_Titulototalmovimentocredito_f;
         A306TituloTotalMultaJurosDebito_F = obj44.gxTpr_Titulototalmultajurosdebito_f;
         A307TituloTotalMultaJurosCredito_F = obj44.gxTpr_Titulototalmultajuroscredito_f;
         A295TituloCompetencia_F = obj44.gxTpr_Titulocompetencia_f;
         A275TituloSaldo_F = obj44.gxTpr_Titulosaldo_f;
         A282TituloStatus_F = obj44.gxTpr_Titulostatus_f;
         A302TituloSaldoDebito_F = obj44.gxTpr_Titulosaldodebito_f;
         A303TituloSaldoCredito_F = obj44.gxTpr_Titulosaldocredito_f;
         A168ClienteId = obj44.gxTpr_Clienteid;
         n168ClienteId = false;
         A170ClienteRazaoSocial = obj44.gxTpr_Clienterazaosocial;
         n170ClienteRazaoSocial = false;
         A262TituloValor = obj44.gxTpr_Titulovalor;
         n262TituloValor = false;
         A276TituloDesconto = obj44.gxTpr_Titulodesconto;
         n276TituloDesconto = false;
         A314TituloArchived = obj44.gxTpr_Tituloarchived;
         n314TituloArchived = false;
         A263TituloVencimento = obj44.gxTpr_Titulovencimento;
         n263TituloVencimento = false;
         A286TituloCompetenciaAno = obj44.gxTpr_Titulocompetenciaano;
         n286TituloCompetenciaAno = false;
         A287TituloCompetenciaMes = obj44.gxTpr_Titulocompetenciames;
         n287TituloCompetenciaMes = false;
         A264TituloProrrogacao = obj44.gxTpr_Tituloprorrogacao;
         n264TituloProrrogacao = false;
         A265TituloCEP = obj44.gxTpr_Titulocep;
         n265TituloCEP = false;
         A266TituloLogradouro = obj44.gxTpr_Titulologradouro;
         n266TituloLogradouro = false;
         A294TituloNumeroEndereco = obj44.gxTpr_Titulonumeroendereco;
         n294TituloNumeroEndereco = false;
         A267TituloComplemento = obj44.gxTpr_Titulocomplemento;
         n267TituloComplemento = false;
         A268TituloBairro = obj44.gxTpr_Titulobairro;
         n268TituloBairro = false;
         A269TituloMunicipio = obj44.gxTpr_Titulomunicipio;
         n269TituloMunicipio = false;
         A498TituloJurosMora = obj44.gxTpr_Titulojurosmora;
         n498TituloJurosMora = false;
         A283TituloTipo = obj44.gxTpr_Titulotipo;
         n283TituloTipo = false;
         A419TituloPropostaId = obj44.gxTpr_Titulopropostaid;
         n419TituloPropostaId = false;
         A501PropostaTaxaAdministrativa = obj44.gxTpr_Propostataxaadministrativa;
         n501PropostaTaxaAdministrativa = false;
         A422ContaId = obj44.gxTpr_Contaid;
         n422ContaId = false;
         A426CategoriaTituloId = obj44.gxTpr_Categoriatituloid;
         n426CategoriaTituloId = false;
         A273TituloTotalMovimento_F = obj44.gxTpr_Titulototalmovimento_f;
         n273TituloTotalMovimento_F = false;
         A301TituloTotalMultaJuros_F = obj44.gxTpr_Titulototalmultajuros_f;
         n301TituloTotalMultaJuros_F = false;
         A284TituloDeleted = obj44.gxTpr_Titulodeleted;
         n284TituloDeleted = false;
         A500TituloCriacao = obj44.gxTpr_Titulocriacao;
         n500TituloCriacao = false;
         A261TituloId = obj44.gxTpr_Tituloid;
         n261TituloId = false;
         Z261TituloId = obj44.gxTpr_Tituloid_Z;
         Z168ClienteId = obj44.gxTpr_Clienteid_Z;
         Z170ClienteRazaoSocial = obj44.gxTpr_Clienterazaosocial_Z;
         Z262TituloValor = obj44.gxTpr_Titulovalor_Z;
         Z276TituloDesconto = obj44.gxTpr_Titulodesconto_Z;
         Z284TituloDeleted = obj44.gxTpr_Titulodeleted_Z;
         Z314TituloArchived = obj44.gxTpr_Tituloarchived_Z;
         Z263TituloVencimento = obj44.gxTpr_Titulovencimento_Z;
         Z286TituloCompetenciaAno = obj44.gxTpr_Titulocompetenciaano_Z;
         Z287TituloCompetenciaMes = obj44.gxTpr_Titulocompetenciames_Z;
         Z295TituloCompetencia_F = obj44.gxTpr_Titulocompetencia_f_Z;
         Z264TituloProrrogacao = obj44.gxTpr_Tituloprorrogacao_Z;
         Z265TituloCEP = obj44.gxTpr_Titulocep_Z;
         Z266TituloLogradouro = obj44.gxTpr_Titulologradouro_Z;
         Z294TituloNumeroEndereco = obj44.gxTpr_Titulonumeroendereco_Z;
         Z267TituloComplemento = obj44.gxTpr_Titulocomplemento_Z;
         Z268TituloBairro = obj44.gxTpr_Titulobairro_Z;
         Z269TituloMunicipio = obj44.gxTpr_Titulomunicipio_Z;
         Z498TituloJurosMora = obj44.gxTpr_Titulojurosmora_Z;
         Z283TituloTipo = obj44.gxTpr_Titulotipo_Z;
         Z419TituloPropostaId = obj44.gxTpr_Titulopropostaid_Z;
         Z501PropostaTaxaAdministrativa = obj44.gxTpr_Propostataxaadministrativa_Z;
         Z422ContaId = obj44.gxTpr_Contaid_Z;
         Z500TituloCriacao = obj44.gxTpr_Titulocriacao_Z;
         Z426CategoriaTituloId = obj44.gxTpr_Categoriatituloid_Z;
         Z273TituloTotalMovimento_F = obj44.gxTpr_Titulototalmovimento_f_Z;
         Z301TituloTotalMultaJuros_F = obj44.gxTpr_Titulototalmultajuros_f_Z;
         Z275TituloSaldo_F = obj44.gxTpr_Titulosaldo_f_Z;
         Z282TituloStatus_F = obj44.gxTpr_Titulostatus_f_Z;
         Z302TituloSaldoDebito_F = obj44.gxTpr_Titulosaldodebito_f_Z;
         Z303TituloSaldoCredito_F = obj44.gxTpr_Titulosaldocredito_f_Z;
         Z304TituloTotalMovimentoDebito_F = obj44.gxTpr_Titulototalmovimentodebito_f_Z;
         Z305TituloTotalMovimentoCredito_F = obj44.gxTpr_Titulototalmovimentocredito_f_Z;
         Z306TituloTotalMultaJurosDebito_F = obj44.gxTpr_Titulototalmultajurosdebito_f_Z;
         Z307TituloTotalMultaJurosCredito_F = obj44.gxTpr_Titulototalmultajuroscredito_f_Z;
         n261TituloId = (bool)(Convert.ToBoolean(obj44.gxTpr_Tituloid_N));
         n168ClienteId = (bool)(Convert.ToBoolean(obj44.gxTpr_Clienteid_N));
         n170ClienteRazaoSocial = (bool)(Convert.ToBoolean(obj44.gxTpr_Clienterazaosocial_N));
         n262TituloValor = (bool)(Convert.ToBoolean(obj44.gxTpr_Titulovalor_N));
         n276TituloDesconto = (bool)(Convert.ToBoolean(obj44.gxTpr_Titulodesconto_N));
         n284TituloDeleted = (bool)(Convert.ToBoolean(obj44.gxTpr_Titulodeleted_N));
         n314TituloArchived = (bool)(Convert.ToBoolean(obj44.gxTpr_Tituloarchived_N));
         n263TituloVencimento = (bool)(Convert.ToBoolean(obj44.gxTpr_Titulovencimento_N));
         n286TituloCompetenciaAno = (bool)(Convert.ToBoolean(obj44.gxTpr_Titulocompetenciaano_N));
         n287TituloCompetenciaMes = (bool)(Convert.ToBoolean(obj44.gxTpr_Titulocompetenciames_N));
         n264TituloProrrogacao = (bool)(Convert.ToBoolean(obj44.gxTpr_Tituloprorrogacao_N));
         n265TituloCEP = (bool)(Convert.ToBoolean(obj44.gxTpr_Titulocep_N));
         n266TituloLogradouro = (bool)(Convert.ToBoolean(obj44.gxTpr_Titulologradouro_N));
         n294TituloNumeroEndereco = (bool)(Convert.ToBoolean(obj44.gxTpr_Titulonumeroendereco_N));
         n267TituloComplemento = (bool)(Convert.ToBoolean(obj44.gxTpr_Titulocomplemento_N));
         n268TituloBairro = (bool)(Convert.ToBoolean(obj44.gxTpr_Titulobairro_N));
         n269TituloMunicipio = (bool)(Convert.ToBoolean(obj44.gxTpr_Titulomunicipio_N));
         n498TituloJurosMora = (bool)(Convert.ToBoolean(obj44.gxTpr_Titulojurosmora_N));
         n283TituloTipo = (bool)(Convert.ToBoolean(obj44.gxTpr_Titulotipo_N));
         n419TituloPropostaId = (bool)(Convert.ToBoolean(obj44.gxTpr_Titulopropostaid_N));
         n501PropostaTaxaAdministrativa = (bool)(Convert.ToBoolean(obj44.gxTpr_Propostataxaadministrativa_N));
         n422ContaId = (bool)(Convert.ToBoolean(obj44.gxTpr_Contaid_N));
         n500TituloCriacao = (bool)(Convert.ToBoolean(obj44.gxTpr_Titulocriacao_N));
         n426CategoriaTituloId = (bool)(Convert.ToBoolean(obj44.gxTpr_Categoriatituloid_N));
         n273TituloTotalMovimento_F = (bool)(Convert.ToBoolean(obj44.gxTpr_Titulototalmovimento_f_N));
         n301TituloTotalMultaJuros_F = (bool)(Convert.ToBoolean(obj44.gxTpr_Titulototalmultajuros_f_N));
         Gx_mode = obj44.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A261TituloId = (int)getParm(obj,0);
         n261TituloId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1X44( ) ;
         ScanKeyStart1X44( ) ;
         if ( RcdFound44 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z261TituloId = A261TituloId;
         }
         ZM1X44( -19) ;
         OnLoadActions1X44( ) ;
         AddRow1X44( ) ;
         ScanKeyEnd1X44( ) ;
         if ( RcdFound44 == 0 )
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
         RowToVars44( bcTituloProposta, 0) ;
         ScanKeyStart1X44( ) ;
         if ( RcdFound44 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z261TituloId = A261TituloId;
         }
         ZM1X44( -19) ;
         OnLoadActions1X44( ) ;
         AddRow1X44( ) ;
         ScanKeyEnd1X44( ) ;
         if ( RcdFound44 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1X44( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1X44( ) ;
         }
         else
         {
            if ( RcdFound44 == 1 )
            {
               if ( A261TituloId != Z261TituloId )
               {
                  A261TituloId = Z261TituloId;
                  n261TituloId = false;
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
                  Update1X44( ) ;
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
                  if ( A261TituloId != Z261TituloId )
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
                        Insert1X44( ) ;
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
                        Insert1X44( ) ;
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
         RowToVars44( bcTituloProposta, 1) ;
         SaveImpl( ) ;
         VarsToRow44( bcTituloProposta) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars44( bcTituloProposta, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1X44( ) ;
         AfterTrn( ) ;
         VarsToRow44( bcTituloProposta) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow44( bcTituloProposta) ;
         }
         else
         {
            SdtTituloProposta auxBC = new SdtTituloProposta(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A261TituloId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTituloProposta);
               auxBC.Save();
               bcTituloProposta.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars44( bcTituloProposta, 1) ;
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
         RowToVars44( bcTituloProposta, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1X44( ) ;
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
               VarsToRow44( bcTituloProposta) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow44( bcTituloProposta) ;
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
         RowToVars44( bcTituloProposta, 0) ;
         GetKey1X44( ) ;
         if ( RcdFound44 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A261TituloId != Z261TituloId )
            {
               A261TituloId = Z261TituloId;
               n261TituloId = false;
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
            if ( A261TituloId != Z261TituloId )
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
         context.RollbackDataStores("tituloproposta_bc",pr_default);
         VarsToRow44( bcTituloProposta) ;
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
         Gx_mode = bcTituloProposta.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTituloProposta.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTituloProposta )
         {
            bcTituloProposta = (SdtTituloProposta)(sdt);
            if ( StringUtil.StrCmp(bcTituloProposta.gxTpr_Mode, "") == 0 )
            {
               bcTituloProposta.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow44( bcTituloProposta) ;
            }
            else
            {
               RowToVars44( bcTituloProposta, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTituloProposta.gxTpr_Mode, "") == 0 )
            {
               bcTituloProposta.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars44( bcTituloProposta, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTituloProposta TituloProposta_BC
      {
         get {
            return bcTituloProposta ;
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

      protected decimal GetTituloTotalMovimentoDebito_F0( int E261TituloId )
      {
         X271TituloMovimentoValor = 0;
         /* Using cursor BC001X32 */
         pr_default.execute(22, new Object[] {nA261TituloId, E261TituloId});
         if ( (pr_default.getStatus(22) != 101) )
         {
            X271TituloMovimentoValor = BC001X32_A271TituloMovimentoValor[0];
            nX271TituloMovimentoValor = BC001X32_n271TituloMovimentoValor[0];
         }
         pr_default.close(22);
         return X271TituloMovimentoValor ;
      }

      protected decimal GetTituloTotalMovimentoCredito_F0( int E261TituloId )
      {
         X271TituloMovimentoValor = 0;
         /* Using cursor BC001X33 */
         pr_default.execute(23, new Object[] {nE261TituloId, E261TituloId});
         if ( (pr_default.getStatus(23) != 101) )
         {
            X271TituloMovimentoValor = BC001X33_A271TituloMovimentoValor[0];
            nX271TituloMovimentoValor = BC001X33_n271TituloMovimentoValor[0];
         }
         pr_default.close(23);
         return X271TituloMovimentoValor ;
      }

      protected decimal GetTituloTotalMultaJurosDebito_F0( int E261TituloId )
      {
         X271TituloMovimentoValor = 0;
         /* Using cursor BC001X34 */
         pr_default.execute(24, new Object[] {nE261TituloId, E261TituloId});
         if ( (pr_default.getStatus(24) != 101) )
         {
            X271TituloMovimentoValor = BC001X34_A271TituloMovimentoValor[0];
            nX271TituloMovimentoValor = BC001X34_n271TituloMovimentoValor[0];
         }
         pr_default.close(24);
         return X271TituloMovimentoValor ;
      }

      protected decimal GetTituloTotalMultaJurosCredito_F0( int E261TituloId )
      {
         X271TituloMovimentoValor = 0;
         /* Using cursor BC001X35 */
         pr_default.execute(25, new Object[] {nE261TituloId, E261TituloId});
         if ( (pr_default.getStatus(25) != 101) )
         {
            X271TituloMovimentoValor = BC001X35_A271TituloMovimentoValor[0];
            nX271TituloMovimentoValor = BC001X35_n271TituloMovimentoValor[0];
         }
         pr_default.close(25);
         return X271TituloMovimentoValor ;
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
         pr_default.close(18);
         pr_default.close(16);
         pr_default.close(17);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV24Pgmname = "";
         AV12TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z890NotaFiscalParcelamentoID = Guid.Empty;
         A890NotaFiscalParcelamentoID = Guid.Empty;
         Z263TituloVencimento = DateTime.MinValue;
         A263TituloVencimento = DateTime.MinValue;
         Z264TituloProrrogacao = DateTime.MinValue;
         A264TituloProrrogacao = DateTime.MinValue;
         Z265TituloCEP = "";
         A265TituloCEP = "";
         Z266TituloLogradouro = "";
         A266TituloLogradouro = "";
         Z294TituloNumeroEndereco = "";
         A294TituloNumeroEndereco = "";
         Z267TituloComplemento = "";
         A267TituloComplemento = "";
         Z268TituloBairro = "";
         A268TituloBairro = "";
         Z269TituloMunicipio = "";
         A269TituloMunicipio = "";
         Z283TituloTipo = "";
         A283TituloTipo = "";
         Z500TituloCriacao = (DateTime)(DateTime.MinValue);
         A500TituloCriacao = (DateTime)(DateTime.MinValue);
         Z295TituloCompetencia_F = "";
         A295TituloCompetencia_F = "";
         Z282TituloStatus_F = "";
         A282TituloStatus_F = "";
         Z794NotaFiscalId = Guid.Empty;
         A794NotaFiscalId = Guid.Empty;
         Z170ClienteRazaoSocial = "";
         A170ClienteRazaoSocial = "";
         BC001X6_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         BC001X6_n794NotaFiscalId = new bool[] {false} ;
         BC001X8_A168ClienteId = new int[1] ;
         BC001X8_n168ClienteId = new bool[] {false} ;
         BC001X9_A170ClienteRazaoSocial = new string[] {""} ;
         BC001X9_n170ClienteRazaoSocial = new bool[] {false} ;
         BC001X16_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         BC001X16_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         BC001X16_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         BC001X16_n794NotaFiscalId = new bool[] {false} ;
         BC001X16_A261TituloId = new int[1] ;
         BC001X16_n261TituloId = new bool[] {false} ;
         BC001X16_A170ClienteRazaoSocial = new string[] {""} ;
         BC001X16_n170ClienteRazaoSocial = new bool[] {false} ;
         BC001X16_A262TituloValor = new decimal[1] ;
         BC001X16_n262TituloValor = new bool[] {false} ;
         BC001X16_A276TituloDesconto = new decimal[1] ;
         BC001X16_n276TituloDesconto = new bool[] {false} ;
         BC001X16_A284TituloDeleted = new bool[] {false} ;
         BC001X16_n284TituloDeleted = new bool[] {false} ;
         BC001X16_A314TituloArchived = new bool[] {false} ;
         BC001X16_n314TituloArchived = new bool[] {false} ;
         BC001X16_A263TituloVencimento = new DateTime[] {DateTime.MinValue} ;
         BC001X16_n263TituloVencimento = new bool[] {false} ;
         BC001X16_A286TituloCompetenciaAno = new short[1] ;
         BC001X16_n286TituloCompetenciaAno = new bool[] {false} ;
         BC001X16_A287TituloCompetenciaMes = new short[1] ;
         BC001X16_n287TituloCompetenciaMes = new bool[] {false} ;
         BC001X16_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         BC001X16_n264TituloProrrogacao = new bool[] {false} ;
         BC001X16_A265TituloCEP = new string[] {""} ;
         BC001X16_n265TituloCEP = new bool[] {false} ;
         BC001X16_A266TituloLogradouro = new string[] {""} ;
         BC001X16_n266TituloLogradouro = new bool[] {false} ;
         BC001X16_A294TituloNumeroEndereco = new string[] {""} ;
         BC001X16_n294TituloNumeroEndereco = new bool[] {false} ;
         BC001X16_A267TituloComplemento = new string[] {""} ;
         BC001X16_n267TituloComplemento = new bool[] {false} ;
         BC001X16_A268TituloBairro = new string[] {""} ;
         BC001X16_n268TituloBairro = new bool[] {false} ;
         BC001X16_A269TituloMunicipio = new string[] {""} ;
         BC001X16_n269TituloMunicipio = new bool[] {false} ;
         BC001X16_A498TituloJurosMora = new decimal[1] ;
         BC001X16_n498TituloJurosMora = new bool[] {false} ;
         BC001X16_A283TituloTipo = new string[] {""} ;
         BC001X16_n283TituloTipo = new bool[] {false} ;
         BC001X16_A501PropostaTaxaAdministrativa = new decimal[1] ;
         BC001X16_n501PropostaTaxaAdministrativa = new bool[] {false} ;
         BC001X16_A500TituloCriacao = new DateTime[] {DateTime.MinValue} ;
         BC001X16_n500TituloCriacao = new bool[] {false} ;
         BC001X16_A422ContaId = new int[1] ;
         BC001X16_n422ContaId = new bool[] {false} ;
         BC001X16_A426CategoriaTituloId = new int[1] ;
         BC001X16_n426CategoriaTituloId = new bool[] {false} ;
         BC001X16_A419TituloPropostaId = new int[1] ;
         BC001X16_n419TituloPropostaId = new bool[] {false} ;
         BC001X16_A168ClienteId = new int[1] ;
         BC001X16_n168ClienteId = new bool[] {false} ;
         BC001X16_A273TituloTotalMovimento_F = new decimal[1] ;
         BC001X16_n273TituloTotalMovimento_F = new bool[] {false} ;
         BC001X16_A301TituloTotalMultaJuros_F = new decimal[1] ;
         BC001X16_n301TituloTotalMultaJuros_F = new bool[] {false} ;
         BC001X11_A273TituloTotalMovimento_F = new decimal[1] ;
         BC001X11_n273TituloTotalMovimento_F = new bool[] {false} ;
         BC001X13_A301TituloTotalMultaJuros_F = new decimal[1] ;
         BC001X13_n301TituloTotalMultaJuros_F = new bool[] {false} ;
         BC001X7_A501PropostaTaxaAdministrativa = new decimal[1] ;
         BC001X7_n501PropostaTaxaAdministrativa = new bool[] {false} ;
         BC001X4_A422ContaId = new int[1] ;
         BC001X4_n422ContaId = new bool[] {false} ;
         BC001X5_A426CategoriaTituloId = new int[1] ;
         BC001X5_n426CategoriaTituloId = new bool[] {false} ;
         BC001X17_A261TituloId = new int[1] ;
         BC001X17_n261TituloId = new bool[] {false} ;
         BC001X3_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         BC001X3_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         BC001X3_A261TituloId = new int[1] ;
         BC001X3_n261TituloId = new bool[] {false} ;
         BC001X3_A262TituloValor = new decimal[1] ;
         BC001X3_n262TituloValor = new bool[] {false} ;
         BC001X3_A276TituloDesconto = new decimal[1] ;
         BC001X3_n276TituloDesconto = new bool[] {false} ;
         BC001X3_A284TituloDeleted = new bool[] {false} ;
         BC001X3_n284TituloDeleted = new bool[] {false} ;
         BC001X3_A314TituloArchived = new bool[] {false} ;
         BC001X3_n314TituloArchived = new bool[] {false} ;
         BC001X3_A263TituloVencimento = new DateTime[] {DateTime.MinValue} ;
         BC001X3_n263TituloVencimento = new bool[] {false} ;
         BC001X3_A286TituloCompetenciaAno = new short[1] ;
         BC001X3_n286TituloCompetenciaAno = new bool[] {false} ;
         BC001X3_A287TituloCompetenciaMes = new short[1] ;
         BC001X3_n287TituloCompetenciaMes = new bool[] {false} ;
         BC001X3_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         BC001X3_n264TituloProrrogacao = new bool[] {false} ;
         BC001X3_A265TituloCEP = new string[] {""} ;
         BC001X3_n265TituloCEP = new bool[] {false} ;
         BC001X3_A266TituloLogradouro = new string[] {""} ;
         BC001X3_n266TituloLogradouro = new bool[] {false} ;
         BC001X3_A294TituloNumeroEndereco = new string[] {""} ;
         BC001X3_n294TituloNumeroEndereco = new bool[] {false} ;
         BC001X3_A267TituloComplemento = new string[] {""} ;
         BC001X3_n267TituloComplemento = new bool[] {false} ;
         BC001X3_A268TituloBairro = new string[] {""} ;
         BC001X3_n268TituloBairro = new bool[] {false} ;
         BC001X3_A269TituloMunicipio = new string[] {""} ;
         BC001X3_n269TituloMunicipio = new bool[] {false} ;
         BC001X3_A498TituloJurosMora = new decimal[1] ;
         BC001X3_n498TituloJurosMora = new bool[] {false} ;
         BC001X3_A283TituloTipo = new string[] {""} ;
         BC001X3_n283TituloTipo = new bool[] {false} ;
         BC001X3_A500TituloCriacao = new DateTime[] {DateTime.MinValue} ;
         BC001X3_n500TituloCriacao = new bool[] {false} ;
         BC001X3_A422ContaId = new int[1] ;
         BC001X3_n422ContaId = new bool[] {false} ;
         BC001X3_A426CategoriaTituloId = new int[1] ;
         BC001X3_n426CategoriaTituloId = new bool[] {false} ;
         BC001X3_A419TituloPropostaId = new int[1] ;
         BC001X3_n419TituloPropostaId = new bool[] {false} ;
         sMode44 = "";
         BC001X2_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         BC001X2_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         BC001X2_A261TituloId = new int[1] ;
         BC001X2_n261TituloId = new bool[] {false} ;
         BC001X2_A262TituloValor = new decimal[1] ;
         BC001X2_n262TituloValor = new bool[] {false} ;
         BC001X2_A276TituloDesconto = new decimal[1] ;
         BC001X2_n276TituloDesconto = new bool[] {false} ;
         BC001X2_A284TituloDeleted = new bool[] {false} ;
         BC001X2_n284TituloDeleted = new bool[] {false} ;
         BC001X2_A314TituloArchived = new bool[] {false} ;
         BC001X2_n314TituloArchived = new bool[] {false} ;
         BC001X2_A263TituloVencimento = new DateTime[] {DateTime.MinValue} ;
         BC001X2_n263TituloVencimento = new bool[] {false} ;
         BC001X2_A286TituloCompetenciaAno = new short[1] ;
         BC001X2_n286TituloCompetenciaAno = new bool[] {false} ;
         BC001X2_A287TituloCompetenciaMes = new short[1] ;
         BC001X2_n287TituloCompetenciaMes = new bool[] {false} ;
         BC001X2_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         BC001X2_n264TituloProrrogacao = new bool[] {false} ;
         BC001X2_A265TituloCEP = new string[] {""} ;
         BC001X2_n265TituloCEP = new bool[] {false} ;
         BC001X2_A266TituloLogradouro = new string[] {""} ;
         BC001X2_n266TituloLogradouro = new bool[] {false} ;
         BC001X2_A294TituloNumeroEndereco = new string[] {""} ;
         BC001X2_n294TituloNumeroEndereco = new bool[] {false} ;
         BC001X2_A267TituloComplemento = new string[] {""} ;
         BC001X2_n267TituloComplemento = new bool[] {false} ;
         BC001X2_A268TituloBairro = new string[] {""} ;
         BC001X2_n268TituloBairro = new bool[] {false} ;
         BC001X2_A269TituloMunicipio = new string[] {""} ;
         BC001X2_n269TituloMunicipio = new bool[] {false} ;
         BC001X2_A498TituloJurosMora = new decimal[1] ;
         BC001X2_n498TituloJurosMora = new bool[] {false} ;
         BC001X2_A283TituloTipo = new string[] {""} ;
         BC001X2_n283TituloTipo = new bool[] {false} ;
         BC001X2_A500TituloCriacao = new DateTime[] {DateTime.MinValue} ;
         BC001X2_n500TituloCriacao = new bool[] {false} ;
         BC001X2_A422ContaId = new int[1] ;
         BC001X2_n422ContaId = new bool[] {false} ;
         BC001X2_A426CategoriaTituloId = new int[1] ;
         BC001X2_n426CategoriaTituloId = new bool[] {false} ;
         BC001X2_A419TituloPropostaId = new int[1] ;
         BC001X2_n419TituloPropostaId = new bool[] {false} ;
         BC001X19_A261TituloId = new int[1] ;
         BC001X19_n261TituloId = new bool[] {false} ;
         BC001X23_A273TituloTotalMovimento_F = new decimal[1] ;
         BC001X23_n273TituloTotalMovimento_F = new bool[] {false} ;
         BC001X25_A301TituloTotalMultaJuros_F = new decimal[1] ;
         BC001X25_n301TituloTotalMultaJuros_F = new bool[] {false} ;
         BC001X26_A501PropostaTaxaAdministrativa = new decimal[1] ;
         BC001X26_n501PropostaTaxaAdministrativa = new bool[] {false} ;
         BC001X27_A1077BoletosId = new int[1] ;
         BC001X28_A270TituloMovimentoId = new int[1] ;
         BC001X31_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         BC001X31_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         BC001X31_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         BC001X31_n794NotaFiscalId = new bool[] {false} ;
         BC001X31_A261TituloId = new int[1] ;
         BC001X31_n261TituloId = new bool[] {false} ;
         BC001X31_A170ClienteRazaoSocial = new string[] {""} ;
         BC001X31_n170ClienteRazaoSocial = new bool[] {false} ;
         BC001X31_A262TituloValor = new decimal[1] ;
         BC001X31_n262TituloValor = new bool[] {false} ;
         BC001X31_A276TituloDesconto = new decimal[1] ;
         BC001X31_n276TituloDesconto = new bool[] {false} ;
         BC001X31_A284TituloDeleted = new bool[] {false} ;
         BC001X31_n284TituloDeleted = new bool[] {false} ;
         BC001X31_A314TituloArchived = new bool[] {false} ;
         BC001X31_n314TituloArchived = new bool[] {false} ;
         BC001X31_A263TituloVencimento = new DateTime[] {DateTime.MinValue} ;
         BC001X31_n263TituloVencimento = new bool[] {false} ;
         BC001X31_A286TituloCompetenciaAno = new short[1] ;
         BC001X31_n286TituloCompetenciaAno = new bool[] {false} ;
         BC001X31_A287TituloCompetenciaMes = new short[1] ;
         BC001X31_n287TituloCompetenciaMes = new bool[] {false} ;
         BC001X31_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         BC001X31_n264TituloProrrogacao = new bool[] {false} ;
         BC001X31_A265TituloCEP = new string[] {""} ;
         BC001X31_n265TituloCEP = new bool[] {false} ;
         BC001X31_A266TituloLogradouro = new string[] {""} ;
         BC001X31_n266TituloLogradouro = new bool[] {false} ;
         BC001X31_A294TituloNumeroEndereco = new string[] {""} ;
         BC001X31_n294TituloNumeroEndereco = new bool[] {false} ;
         BC001X31_A267TituloComplemento = new string[] {""} ;
         BC001X31_n267TituloComplemento = new bool[] {false} ;
         BC001X31_A268TituloBairro = new string[] {""} ;
         BC001X31_n268TituloBairro = new bool[] {false} ;
         BC001X31_A269TituloMunicipio = new string[] {""} ;
         BC001X31_n269TituloMunicipio = new bool[] {false} ;
         BC001X31_A498TituloJurosMora = new decimal[1] ;
         BC001X31_n498TituloJurosMora = new bool[] {false} ;
         BC001X31_A283TituloTipo = new string[] {""} ;
         BC001X31_n283TituloTipo = new bool[] {false} ;
         BC001X31_A501PropostaTaxaAdministrativa = new decimal[1] ;
         BC001X31_n501PropostaTaxaAdministrativa = new bool[] {false} ;
         BC001X31_A500TituloCriacao = new DateTime[] {DateTime.MinValue} ;
         BC001X31_n500TituloCriacao = new bool[] {false} ;
         BC001X31_A422ContaId = new int[1] ;
         BC001X31_n422ContaId = new bool[] {false} ;
         BC001X31_A426CategoriaTituloId = new int[1] ;
         BC001X31_n426CategoriaTituloId = new bool[] {false} ;
         BC001X31_A419TituloPropostaId = new int[1] ;
         BC001X31_n419TituloPropostaId = new bool[] {false} ;
         BC001X31_A168ClienteId = new int[1] ;
         BC001X31_n168ClienteId = new bool[] {false} ;
         BC001X31_A273TituloTotalMovimento_F = new decimal[1] ;
         BC001X31_n273TituloTotalMovimento_F = new bool[] {false} ;
         BC001X31_A301TituloTotalMultaJuros_F = new decimal[1] ;
         BC001X31_n301TituloTotalMultaJuros_F = new bool[] {false} ;
         i500TituloCriacao = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC001X32_A271TituloMovimentoValor = new decimal[1] ;
         BC001X32_n271TituloMovimentoValor = new bool[] {false} ;
         BC001X33_A271TituloMovimentoValor = new decimal[1] ;
         BC001X33_n271TituloMovimentoValor = new bool[] {false} ;
         BC001X34_A271TituloMovimentoValor = new decimal[1] ;
         BC001X34_n271TituloMovimentoValor = new bool[] {false} ;
         BC001X35_A271TituloMovimentoValor = new decimal[1] ;
         BC001X35_n271TituloMovimentoValor = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tituloproposta_bc__default(),
            new Object[][] {
                new Object[] {
               BC001X2_A890NotaFiscalParcelamentoID, BC001X2_n890NotaFiscalParcelamentoID, BC001X2_A261TituloId, BC001X2_A262TituloValor, BC001X2_n262TituloValor, BC001X2_A276TituloDesconto, BC001X2_n276TituloDesconto, BC001X2_A284TituloDeleted, BC001X2_n284TituloDeleted, BC001X2_A314TituloArchived,
               BC001X2_n314TituloArchived, BC001X2_A263TituloVencimento, BC001X2_n263TituloVencimento, BC001X2_A286TituloCompetenciaAno, BC001X2_n286TituloCompetenciaAno, BC001X2_A287TituloCompetenciaMes, BC001X2_n287TituloCompetenciaMes, BC001X2_A264TituloProrrogacao, BC001X2_n264TituloProrrogacao, BC001X2_A265TituloCEP,
               BC001X2_n265TituloCEP, BC001X2_A266TituloLogradouro, BC001X2_n266TituloLogradouro, BC001X2_A294TituloNumeroEndereco, BC001X2_n294TituloNumeroEndereco, BC001X2_A267TituloComplemento, BC001X2_n267TituloComplemento, BC001X2_A268TituloBairro, BC001X2_n268TituloBairro, BC001X2_A269TituloMunicipio,
               BC001X2_n269TituloMunicipio, BC001X2_A498TituloJurosMora, BC001X2_n498TituloJurosMora, BC001X2_A283TituloTipo, BC001X2_n283TituloTipo, BC001X2_A500TituloCriacao, BC001X2_n500TituloCriacao, BC001X2_A422ContaId, BC001X2_n422ContaId, BC001X2_A426CategoriaTituloId,
               BC001X2_n426CategoriaTituloId, BC001X2_A419TituloPropostaId, BC001X2_n419TituloPropostaId
               }
               , new Object[] {
               BC001X3_A890NotaFiscalParcelamentoID, BC001X3_n890NotaFiscalParcelamentoID, BC001X3_A261TituloId, BC001X3_A262TituloValor, BC001X3_n262TituloValor, BC001X3_A276TituloDesconto, BC001X3_n276TituloDesconto, BC001X3_A284TituloDeleted, BC001X3_n284TituloDeleted, BC001X3_A314TituloArchived,
               BC001X3_n314TituloArchived, BC001X3_A263TituloVencimento, BC001X3_n263TituloVencimento, BC001X3_A286TituloCompetenciaAno, BC001X3_n286TituloCompetenciaAno, BC001X3_A287TituloCompetenciaMes, BC001X3_n287TituloCompetenciaMes, BC001X3_A264TituloProrrogacao, BC001X3_n264TituloProrrogacao, BC001X3_A265TituloCEP,
               BC001X3_n265TituloCEP, BC001X3_A266TituloLogradouro, BC001X3_n266TituloLogradouro, BC001X3_A294TituloNumeroEndereco, BC001X3_n294TituloNumeroEndereco, BC001X3_A267TituloComplemento, BC001X3_n267TituloComplemento, BC001X3_A268TituloBairro, BC001X3_n268TituloBairro, BC001X3_A269TituloMunicipio,
               BC001X3_n269TituloMunicipio, BC001X3_A498TituloJurosMora, BC001X3_n498TituloJurosMora, BC001X3_A283TituloTipo, BC001X3_n283TituloTipo, BC001X3_A500TituloCriacao, BC001X3_n500TituloCriacao, BC001X3_A422ContaId, BC001X3_n422ContaId, BC001X3_A426CategoriaTituloId,
               BC001X3_n426CategoriaTituloId, BC001X3_A419TituloPropostaId, BC001X3_n419TituloPropostaId
               }
               , new Object[] {
               BC001X4_A422ContaId
               }
               , new Object[] {
               BC001X5_A426CategoriaTituloId
               }
               , new Object[] {
               BC001X6_A794NotaFiscalId, BC001X6_n794NotaFiscalId
               }
               , new Object[] {
               BC001X7_A501PropostaTaxaAdministrativa, BC001X7_n501PropostaTaxaAdministrativa
               }
               , new Object[] {
               BC001X8_A168ClienteId, BC001X8_n168ClienteId
               }
               , new Object[] {
               BC001X9_A170ClienteRazaoSocial, BC001X9_n170ClienteRazaoSocial
               }
               , new Object[] {
               BC001X11_A273TituloTotalMovimento_F, BC001X11_n273TituloTotalMovimento_F
               }
               , new Object[] {
               BC001X13_A301TituloTotalMultaJuros_F, BC001X13_n301TituloTotalMultaJuros_F
               }
               , new Object[] {
               BC001X16_A890NotaFiscalParcelamentoID, BC001X16_n890NotaFiscalParcelamentoID, BC001X16_A794NotaFiscalId, BC001X16_n794NotaFiscalId, BC001X16_A261TituloId, BC001X16_A170ClienteRazaoSocial, BC001X16_n170ClienteRazaoSocial, BC001X16_A262TituloValor, BC001X16_n262TituloValor, BC001X16_A276TituloDesconto,
               BC001X16_n276TituloDesconto, BC001X16_A284TituloDeleted, BC001X16_n284TituloDeleted, BC001X16_A314TituloArchived, BC001X16_n314TituloArchived, BC001X16_A263TituloVencimento, BC001X16_n263TituloVencimento, BC001X16_A286TituloCompetenciaAno, BC001X16_n286TituloCompetenciaAno, BC001X16_A287TituloCompetenciaMes,
               BC001X16_n287TituloCompetenciaMes, BC001X16_A264TituloProrrogacao, BC001X16_n264TituloProrrogacao, BC001X16_A265TituloCEP, BC001X16_n265TituloCEP, BC001X16_A266TituloLogradouro, BC001X16_n266TituloLogradouro, BC001X16_A294TituloNumeroEndereco, BC001X16_n294TituloNumeroEndereco, BC001X16_A267TituloComplemento,
               BC001X16_n267TituloComplemento, BC001X16_A268TituloBairro, BC001X16_n268TituloBairro, BC001X16_A269TituloMunicipio, BC001X16_n269TituloMunicipio, BC001X16_A498TituloJurosMora, BC001X16_n498TituloJurosMora, BC001X16_A283TituloTipo, BC001X16_n283TituloTipo, BC001X16_A501PropostaTaxaAdministrativa,
               BC001X16_n501PropostaTaxaAdministrativa, BC001X16_A500TituloCriacao, BC001X16_n500TituloCriacao, BC001X16_A422ContaId, BC001X16_n422ContaId, BC001X16_A426CategoriaTituloId, BC001X16_n426CategoriaTituloId, BC001X16_A419TituloPropostaId, BC001X16_n419TituloPropostaId, BC001X16_A168ClienteId,
               BC001X16_n168ClienteId, BC001X16_A273TituloTotalMovimento_F, BC001X16_n273TituloTotalMovimento_F, BC001X16_A301TituloTotalMultaJuros_F, BC001X16_n301TituloTotalMultaJuros_F
               }
               , new Object[] {
               BC001X17_A261TituloId
               }
               , new Object[] {
               }
               , new Object[] {
               BC001X19_A261TituloId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001X23_A273TituloTotalMovimento_F, BC001X23_n273TituloTotalMovimento_F
               }
               , new Object[] {
               BC001X25_A301TituloTotalMultaJuros_F, BC001X25_n301TituloTotalMultaJuros_F
               }
               , new Object[] {
               BC001X26_A501PropostaTaxaAdministrativa, BC001X26_n501PropostaTaxaAdministrativa
               }
               , new Object[] {
               BC001X27_A1077BoletosId
               }
               , new Object[] {
               BC001X28_A270TituloMovimentoId
               }
               , new Object[] {
               BC001X31_A890NotaFiscalParcelamentoID, BC001X31_n890NotaFiscalParcelamentoID, BC001X31_A794NotaFiscalId, BC001X31_n794NotaFiscalId, BC001X31_A261TituloId, BC001X31_A170ClienteRazaoSocial, BC001X31_n170ClienteRazaoSocial, BC001X31_A262TituloValor, BC001X31_n262TituloValor, BC001X31_A276TituloDesconto,
               BC001X31_n276TituloDesconto, BC001X31_A284TituloDeleted, BC001X31_n284TituloDeleted, BC001X31_A314TituloArchived, BC001X31_n314TituloArchived, BC001X31_A263TituloVencimento, BC001X31_n263TituloVencimento, BC001X31_A286TituloCompetenciaAno, BC001X31_n286TituloCompetenciaAno, BC001X31_A287TituloCompetenciaMes,
               BC001X31_n287TituloCompetenciaMes, BC001X31_A264TituloProrrogacao, BC001X31_n264TituloProrrogacao, BC001X31_A265TituloCEP, BC001X31_n265TituloCEP, BC001X31_A266TituloLogradouro, BC001X31_n266TituloLogradouro, BC001X31_A294TituloNumeroEndereco, BC001X31_n294TituloNumeroEndereco, BC001X31_A267TituloComplemento,
               BC001X31_n267TituloComplemento, BC001X31_A268TituloBairro, BC001X31_n268TituloBairro, BC001X31_A269TituloMunicipio, BC001X31_n269TituloMunicipio, BC001X31_A498TituloJurosMora, BC001X31_n498TituloJurosMora, BC001X31_A283TituloTipo, BC001X31_n283TituloTipo, BC001X31_A501PropostaTaxaAdministrativa,
               BC001X31_n501PropostaTaxaAdministrativa, BC001X31_A500TituloCriacao, BC001X31_n500TituloCriacao, BC001X31_A422ContaId, BC001X31_n422ContaId, BC001X31_A426CategoriaTituloId, BC001X31_n426CategoriaTituloId, BC001X31_A419TituloPropostaId, BC001X31_n419TituloPropostaId, BC001X31_A168ClienteId,
               BC001X31_n168ClienteId, BC001X31_A273TituloTotalMovimento_F, BC001X31_n273TituloTotalMovimento_F, BC001X31_A301TituloTotalMultaJuros_F, BC001X31_n301TituloTotalMultaJuros_F
               }
               , new Object[] {
               BC001X32_A271TituloMovimentoValor, BC001X32_n271TituloMovimentoValor
               }
               , new Object[] {
               BC001X33_A271TituloMovimentoValor, BC001X33_n271TituloMovimentoValor
               }
               , new Object[] {
               BC001X34_A271TituloMovimentoValor, BC001X34_n271TituloMovimentoValor
               }
               , new Object[] {
               BC001X35_A271TituloMovimentoValor, BC001X35_n271TituloMovimentoValor
               }
            }
         );
         AV24Pgmname = "TituloProposta_BC";
         Z500TituloCriacao = DateTimeUtil.ServerNow( context, pr_default);
         n500TituloCriacao = false;
         A500TituloCriacao = DateTimeUtil.ServerNow( context, pr_default);
         n500TituloCriacao = false;
         i500TituloCriacao = DateTimeUtil.ServerNow( context, pr_default);
         n500TituloCriacao = false;
         Z284TituloDeleted = false;
         n284TituloDeleted = false;
         A284TituloDeleted = false;
         n284TituloDeleted = false;
         i284TituloDeleted = false;
         n284TituloDeleted = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121X2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z286TituloCompetenciaAno ;
      private short A286TituloCompetenciaAno ;
      private short Z287TituloCompetenciaMes ;
      private short A287TituloCompetenciaMes ;
      private short Gx_BScreen ;
      private short RcdFound44 ;
      private int trnEnded ;
      private int Z261TituloId ;
      private int A261TituloId ;
      private int AV25GXV1 ;
      private int AV11Insert_ClienteId ;
      private int AV20Insert_TituloPropostaId ;
      private int AV21Insert_ContaId ;
      private int AV22Insert_CategoriaTituloId ;
      private int Z422ContaId ;
      private int A422ContaId ;
      private int Z426CategoriaTituloId ;
      private int A426CategoriaTituloId ;
      private int Z419TituloPropostaId ;
      private int A419TituloPropostaId ;
      private int Z168ClienteId ;
      private int A168ClienteId ;
      private int E261TituloId ;
      private decimal Z262TituloValor ;
      private decimal A262TituloValor ;
      private decimal Z276TituloDesconto ;
      private decimal A276TituloDesconto ;
      private decimal Z498TituloJurosMora ;
      private decimal A498TituloJurosMora ;
      private decimal Z273TituloTotalMovimento_F ;
      private decimal A273TituloTotalMovimento_F ;
      private decimal Z301TituloTotalMultaJuros_F ;
      private decimal A301TituloTotalMultaJuros_F ;
      private decimal Z275TituloSaldo_F ;
      private decimal A275TituloSaldo_F ;
      private decimal Z302TituloSaldoDebito_F ;
      private decimal A302TituloSaldoDebito_F ;
      private decimal Z303TituloSaldoCredito_F ;
      private decimal A303TituloSaldoCredito_F ;
      private decimal Z304TituloTotalMovimentoDebito_F ;
      private decimal A304TituloTotalMovimentoDebito_F ;
      private decimal Z305TituloTotalMovimentoCredito_F ;
      private decimal A305TituloTotalMovimentoCredito_F ;
      private decimal Z306TituloTotalMultaJurosDebito_F ;
      private decimal A306TituloTotalMultaJurosDebito_F ;
      private decimal Z307TituloTotalMultaJurosCredito_F ;
      private decimal A307TituloTotalMultaJurosCredito_F ;
      private decimal Z501PropostaTaxaAdministrativa ;
      private decimal A501PropostaTaxaAdministrativa ;
      private decimal X271TituloMovimentoValor ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV24Pgmname ;
      private string sMode44 ;
      private DateTime Z500TituloCriacao ;
      private DateTime A500TituloCriacao ;
      private DateTime i500TituloCriacao ;
      private DateTime Z263TituloVencimento ;
      private DateTime A263TituloVencimento ;
      private DateTime Z264TituloProrrogacao ;
      private DateTime A264TituloProrrogacao ;
      private bool returnInSub ;
      private bool Z284TituloDeleted ;
      private bool A284TituloDeleted ;
      private bool Z314TituloArchived ;
      private bool A314TituloArchived ;
      private bool n284TituloDeleted ;
      private bool n500TituloCriacao ;
      private bool n890NotaFiscalParcelamentoID ;
      private bool n794NotaFiscalId ;
      private bool n168ClienteId ;
      private bool n170ClienteRazaoSocial ;
      private bool n261TituloId ;
      private bool n262TituloValor ;
      private bool n276TituloDesconto ;
      private bool n314TituloArchived ;
      private bool n263TituloVencimento ;
      private bool n286TituloCompetenciaAno ;
      private bool n287TituloCompetenciaMes ;
      private bool n264TituloProrrogacao ;
      private bool n265TituloCEP ;
      private bool n266TituloLogradouro ;
      private bool n294TituloNumeroEndereco ;
      private bool n267TituloComplemento ;
      private bool n268TituloBairro ;
      private bool n269TituloMunicipio ;
      private bool n498TituloJurosMora ;
      private bool n283TituloTipo ;
      private bool n501PropostaTaxaAdministrativa ;
      private bool n422ContaId ;
      private bool n426CategoriaTituloId ;
      private bool n419TituloPropostaId ;
      private bool n273TituloTotalMovimento_F ;
      private bool n301TituloTotalMultaJuros_F ;
      private bool Gx_longc ;
      private bool i284TituloDeleted ;
      private bool nA261TituloId ;
      private bool nX271TituloMovimentoValor ;
      private bool nE261TituloId ;
      private string Z265TituloCEP ;
      private string A265TituloCEP ;
      private string Z266TituloLogradouro ;
      private string A266TituloLogradouro ;
      private string Z294TituloNumeroEndereco ;
      private string A294TituloNumeroEndereco ;
      private string Z267TituloComplemento ;
      private string A267TituloComplemento ;
      private string Z268TituloBairro ;
      private string A268TituloBairro ;
      private string Z269TituloMunicipio ;
      private string A269TituloMunicipio ;
      private string Z283TituloTipo ;
      private string A283TituloTipo ;
      private string Z295TituloCompetencia_F ;
      private string A295TituloCompetencia_F ;
      private string Z282TituloStatus_F ;
      private string A282TituloStatus_F ;
      private string Z170ClienteRazaoSocial ;
      private string A170ClienteRazaoSocial ;
      private Guid Z890NotaFiscalParcelamentoID ;
      private Guid A890NotaFiscalParcelamentoID ;
      private Guid Z794NotaFiscalId ;
      private Guid A794NotaFiscalId ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC001X6_A794NotaFiscalId ;
      private bool[] BC001X6_n794NotaFiscalId ;
      private int[] BC001X8_A168ClienteId ;
      private bool[] BC001X8_n168ClienteId ;
      private string[] BC001X9_A170ClienteRazaoSocial ;
      private bool[] BC001X9_n170ClienteRazaoSocial ;
      private Guid[] BC001X16_A890NotaFiscalParcelamentoID ;
      private bool[] BC001X16_n890NotaFiscalParcelamentoID ;
      private Guid[] BC001X16_A794NotaFiscalId ;
      private bool[] BC001X16_n794NotaFiscalId ;
      private int[] BC001X16_A261TituloId ;
      private bool[] BC001X16_n261TituloId ;
      private string[] BC001X16_A170ClienteRazaoSocial ;
      private bool[] BC001X16_n170ClienteRazaoSocial ;
      private decimal[] BC001X16_A262TituloValor ;
      private bool[] BC001X16_n262TituloValor ;
      private decimal[] BC001X16_A276TituloDesconto ;
      private bool[] BC001X16_n276TituloDesconto ;
      private bool[] BC001X16_A284TituloDeleted ;
      private bool[] BC001X16_n284TituloDeleted ;
      private bool[] BC001X16_A314TituloArchived ;
      private bool[] BC001X16_n314TituloArchived ;
      private DateTime[] BC001X16_A263TituloVencimento ;
      private bool[] BC001X16_n263TituloVencimento ;
      private short[] BC001X16_A286TituloCompetenciaAno ;
      private bool[] BC001X16_n286TituloCompetenciaAno ;
      private short[] BC001X16_A287TituloCompetenciaMes ;
      private bool[] BC001X16_n287TituloCompetenciaMes ;
      private DateTime[] BC001X16_A264TituloProrrogacao ;
      private bool[] BC001X16_n264TituloProrrogacao ;
      private string[] BC001X16_A265TituloCEP ;
      private bool[] BC001X16_n265TituloCEP ;
      private string[] BC001X16_A266TituloLogradouro ;
      private bool[] BC001X16_n266TituloLogradouro ;
      private string[] BC001X16_A294TituloNumeroEndereco ;
      private bool[] BC001X16_n294TituloNumeroEndereco ;
      private string[] BC001X16_A267TituloComplemento ;
      private bool[] BC001X16_n267TituloComplemento ;
      private string[] BC001X16_A268TituloBairro ;
      private bool[] BC001X16_n268TituloBairro ;
      private string[] BC001X16_A269TituloMunicipio ;
      private bool[] BC001X16_n269TituloMunicipio ;
      private decimal[] BC001X16_A498TituloJurosMora ;
      private bool[] BC001X16_n498TituloJurosMora ;
      private string[] BC001X16_A283TituloTipo ;
      private bool[] BC001X16_n283TituloTipo ;
      private decimal[] BC001X16_A501PropostaTaxaAdministrativa ;
      private bool[] BC001X16_n501PropostaTaxaAdministrativa ;
      private DateTime[] BC001X16_A500TituloCriacao ;
      private bool[] BC001X16_n500TituloCriacao ;
      private int[] BC001X16_A422ContaId ;
      private bool[] BC001X16_n422ContaId ;
      private int[] BC001X16_A426CategoriaTituloId ;
      private bool[] BC001X16_n426CategoriaTituloId ;
      private int[] BC001X16_A419TituloPropostaId ;
      private bool[] BC001X16_n419TituloPropostaId ;
      private int[] BC001X16_A168ClienteId ;
      private bool[] BC001X16_n168ClienteId ;
      private decimal[] BC001X16_A273TituloTotalMovimento_F ;
      private bool[] BC001X16_n273TituloTotalMovimento_F ;
      private decimal[] BC001X16_A301TituloTotalMultaJuros_F ;
      private bool[] BC001X16_n301TituloTotalMultaJuros_F ;
      private decimal[] BC001X11_A273TituloTotalMovimento_F ;
      private bool[] BC001X11_n273TituloTotalMovimento_F ;
      private decimal[] BC001X13_A301TituloTotalMultaJuros_F ;
      private bool[] BC001X13_n301TituloTotalMultaJuros_F ;
      private decimal[] BC001X7_A501PropostaTaxaAdministrativa ;
      private bool[] BC001X7_n501PropostaTaxaAdministrativa ;
      private int[] BC001X4_A422ContaId ;
      private bool[] BC001X4_n422ContaId ;
      private int[] BC001X5_A426CategoriaTituloId ;
      private bool[] BC001X5_n426CategoriaTituloId ;
      private int[] BC001X17_A261TituloId ;
      private bool[] BC001X17_n261TituloId ;
      private Guid[] BC001X3_A890NotaFiscalParcelamentoID ;
      private bool[] BC001X3_n890NotaFiscalParcelamentoID ;
      private int[] BC001X3_A261TituloId ;
      private bool[] BC001X3_n261TituloId ;
      private decimal[] BC001X3_A262TituloValor ;
      private bool[] BC001X3_n262TituloValor ;
      private decimal[] BC001X3_A276TituloDesconto ;
      private bool[] BC001X3_n276TituloDesconto ;
      private bool[] BC001X3_A284TituloDeleted ;
      private bool[] BC001X3_n284TituloDeleted ;
      private bool[] BC001X3_A314TituloArchived ;
      private bool[] BC001X3_n314TituloArchived ;
      private DateTime[] BC001X3_A263TituloVencimento ;
      private bool[] BC001X3_n263TituloVencimento ;
      private short[] BC001X3_A286TituloCompetenciaAno ;
      private bool[] BC001X3_n286TituloCompetenciaAno ;
      private short[] BC001X3_A287TituloCompetenciaMes ;
      private bool[] BC001X3_n287TituloCompetenciaMes ;
      private DateTime[] BC001X3_A264TituloProrrogacao ;
      private bool[] BC001X3_n264TituloProrrogacao ;
      private string[] BC001X3_A265TituloCEP ;
      private bool[] BC001X3_n265TituloCEP ;
      private string[] BC001X3_A266TituloLogradouro ;
      private bool[] BC001X3_n266TituloLogradouro ;
      private string[] BC001X3_A294TituloNumeroEndereco ;
      private bool[] BC001X3_n294TituloNumeroEndereco ;
      private string[] BC001X3_A267TituloComplemento ;
      private bool[] BC001X3_n267TituloComplemento ;
      private string[] BC001X3_A268TituloBairro ;
      private bool[] BC001X3_n268TituloBairro ;
      private string[] BC001X3_A269TituloMunicipio ;
      private bool[] BC001X3_n269TituloMunicipio ;
      private decimal[] BC001X3_A498TituloJurosMora ;
      private bool[] BC001X3_n498TituloJurosMora ;
      private string[] BC001X3_A283TituloTipo ;
      private bool[] BC001X3_n283TituloTipo ;
      private DateTime[] BC001X3_A500TituloCriacao ;
      private bool[] BC001X3_n500TituloCriacao ;
      private int[] BC001X3_A422ContaId ;
      private bool[] BC001X3_n422ContaId ;
      private int[] BC001X3_A426CategoriaTituloId ;
      private bool[] BC001X3_n426CategoriaTituloId ;
      private int[] BC001X3_A419TituloPropostaId ;
      private bool[] BC001X3_n419TituloPropostaId ;
      private Guid[] BC001X2_A890NotaFiscalParcelamentoID ;
      private bool[] BC001X2_n890NotaFiscalParcelamentoID ;
      private int[] BC001X2_A261TituloId ;
      private bool[] BC001X2_n261TituloId ;
      private decimal[] BC001X2_A262TituloValor ;
      private bool[] BC001X2_n262TituloValor ;
      private decimal[] BC001X2_A276TituloDesconto ;
      private bool[] BC001X2_n276TituloDesconto ;
      private bool[] BC001X2_A284TituloDeleted ;
      private bool[] BC001X2_n284TituloDeleted ;
      private bool[] BC001X2_A314TituloArchived ;
      private bool[] BC001X2_n314TituloArchived ;
      private DateTime[] BC001X2_A263TituloVencimento ;
      private bool[] BC001X2_n263TituloVencimento ;
      private short[] BC001X2_A286TituloCompetenciaAno ;
      private bool[] BC001X2_n286TituloCompetenciaAno ;
      private short[] BC001X2_A287TituloCompetenciaMes ;
      private bool[] BC001X2_n287TituloCompetenciaMes ;
      private DateTime[] BC001X2_A264TituloProrrogacao ;
      private bool[] BC001X2_n264TituloProrrogacao ;
      private string[] BC001X2_A265TituloCEP ;
      private bool[] BC001X2_n265TituloCEP ;
      private string[] BC001X2_A266TituloLogradouro ;
      private bool[] BC001X2_n266TituloLogradouro ;
      private string[] BC001X2_A294TituloNumeroEndereco ;
      private bool[] BC001X2_n294TituloNumeroEndereco ;
      private string[] BC001X2_A267TituloComplemento ;
      private bool[] BC001X2_n267TituloComplemento ;
      private string[] BC001X2_A268TituloBairro ;
      private bool[] BC001X2_n268TituloBairro ;
      private string[] BC001X2_A269TituloMunicipio ;
      private bool[] BC001X2_n269TituloMunicipio ;
      private decimal[] BC001X2_A498TituloJurosMora ;
      private bool[] BC001X2_n498TituloJurosMora ;
      private string[] BC001X2_A283TituloTipo ;
      private bool[] BC001X2_n283TituloTipo ;
      private DateTime[] BC001X2_A500TituloCriacao ;
      private bool[] BC001X2_n500TituloCriacao ;
      private int[] BC001X2_A422ContaId ;
      private bool[] BC001X2_n422ContaId ;
      private int[] BC001X2_A426CategoriaTituloId ;
      private bool[] BC001X2_n426CategoriaTituloId ;
      private int[] BC001X2_A419TituloPropostaId ;
      private bool[] BC001X2_n419TituloPropostaId ;
      private int[] BC001X19_A261TituloId ;
      private bool[] BC001X19_n261TituloId ;
      private decimal[] BC001X23_A273TituloTotalMovimento_F ;
      private bool[] BC001X23_n273TituloTotalMovimento_F ;
      private decimal[] BC001X25_A301TituloTotalMultaJuros_F ;
      private bool[] BC001X25_n301TituloTotalMultaJuros_F ;
      private decimal[] BC001X26_A501PropostaTaxaAdministrativa ;
      private bool[] BC001X26_n501PropostaTaxaAdministrativa ;
      private int[] BC001X27_A1077BoletosId ;
      private int[] BC001X28_A270TituloMovimentoId ;
      private Guid[] BC001X31_A890NotaFiscalParcelamentoID ;
      private bool[] BC001X31_n890NotaFiscalParcelamentoID ;
      private Guid[] BC001X31_A794NotaFiscalId ;
      private bool[] BC001X31_n794NotaFiscalId ;
      private int[] BC001X31_A261TituloId ;
      private bool[] BC001X31_n261TituloId ;
      private string[] BC001X31_A170ClienteRazaoSocial ;
      private bool[] BC001X31_n170ClienteRazaoSocial ;
      private decimal[] BC001X31_A262TituloValor ;
      private bool[] BC001X31_n262TituloValor ;
      private decimal[] BC001X31_A276TituloDesconto ;
      private bool[] BC001X31_n276TituloDesconto ;
      private bool[] BC001X31_A284TituloDeleted ;
      private bool[] BC001X31_n284TituloDeleted ;
      private bool[] BC001X31_A314TituloArchived ;
      private bool[] BC001X31_n314TituloArchived ;
      private DateTime[] BC001X31_A263TituloVencimento ;
      private bool[] BC001X31_n263TituloVencimento ;
      private short[] BC001X31_A286TituloCompetenciaAno ;
      private bool[] BC001X31_n286TituloCompetenciaAno ;
      private short[] BC001X31_A287TituloCompetenciaMes ;
      private bool[] BC001X31_n287TituloCompetenciaMes ;
      private DateTime[] BC001X31_A264TituloProrrogacao ;
      private bool[] BC001X31_n264TituloProrrogacao ;
      private string[] BC001X31_A265TituloCEP ;
      private bool[] BC001X31_n265TituloCEP ;
      private string[] BC001X31_A266TituloLogradouro ;
      private bool[] BC001X31_n266TituloLogradouro ;
      private string[] BC001X31_A294TituloNumeroEndereco ;
      private bool[] BC001X31_n294TituloNumeroEndereco ;
      private string[] BC001X31_A267TituloComplemento ;
      private bool[] BC001X31_n267TituloComplemento ;
      private string[] BC001X31_A268TituloBairro ;
      private bool[] BC001X31_n268TituloBairro ;
      private string[] BC001X31_A269TituloMunicipio ;
      private bool[] BC001X31_n269TituloMunicipio ;
      private decimal[] BC001X31_A498TituloJurosMora ;
      private bool[] BC001X31_n498TituloJurosMora ;
      private string[] BC001X31_A283TituloTipo ;
      private bool[] BC001X31_n283TituloTipo ;
      private decimal[] BC001X31_A501PropostaTaxaAdministrativa ;
      private bool[] BC001X31_n501PropostaTaxaAdministrativa ;
      private DateTime[] BC001X31_A500TituloCriacao ;
      private bool[] BC001X31_n500TituloCriacao ;
      private int[] BC001X31_A422ContaId ;
      private bool[] BC001X31_n422ContaId ;
      private int[] BC001X31_A426CategoriaTituloId ;
      private bool[] BC001X31_n426CategoriaTituloId ;
      private int[] BC001X31_A419TituloPropostaId ;
      private bool[] BC001X31_n419TituloPropostaId ;
      private int[] BC001X31_A168ClienteId ;
      private bool[] BC001X31_n168ClienteId ;
      private decimal[] BC001X31_A273TituloTotalMovimento_F ;
      private bool[] BC001X31_n273TituloTotalMovimento_F ;
      private decimal[] BC001X31_A301TituloTotalMultaJuros_F ;
      private bool[] BC001X31_n301TituloTotalMultaJuros_F ;
      private SdtTituloProposta bcTituloProposta ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private decimal[] BC001X32_A271TituloMovimentoValor ;
      private bool[] BC001X32_n271TituloMovimentoValor ;
      private decimal[] BC001X33_A271TituloMovimentoValor ;
      private bool[] BC001X33_n271TituloMovimentoValor ;
      private decimal[] BC001X34_A271TituloMovimentoValor ;
      private bool[] BC001X34_n271TituloMovimentoValor ;
      private decimal[] BC001X35_A271TituloMovimentoValor ;
      private bool[] BC001X35_n271TituloMovimentoValor ;
   }

   public class tituloproposta_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new UpdateCursor(def[14])
         ,new UpdateCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC001X2;
          prmBC001X2 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001X3;
          prmBC001X3 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001X4;
          prmBC001X4 = new Object[] {
          new ParDef("ContaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001X5;
          prmBC001X5 = new Object[] {
          new ParDef("CategoriaTituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001X6;
          prmBC001X6 = new Object[] {
          new ParDef("NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmBC001X7;
          prmBC001X7 = new Object[] {
          new ParDef("TituloPropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001X8;
          prmBC001X8 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmBC001X9;
          prmBC001X9 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001X11;
          prmBC001X11 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001X13;
          prmBC001X13 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001X16;
          prmBC001X16 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001X17;
          prmBC001X17 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001X18;
          prmBC001X18 = new Object[] {
          new ParDef("NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("TituloValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("TituloDesconto",GXType.Number,18,2){Nullable=true} ,
          new ParDef("TituloDeleted",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("TituloArchived",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("TituloVencimento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("TituloCompetenciaAno",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("TituloCompetenciaMes",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("TituloProrrogacao",GXType.Date,8,0){Nullable=true} ,
          new ParDef("TituloCEP",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("TituloLogradouro",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("TituloNumeroEndereco",GXType.VarChar,10,0){Nullable=true} ,
          new ParDef("TituloComplemento",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("TituloBairro",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("TituloMunicipio",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("TituloJurosMora",GXType.Number,16,4){Nullable=true} ,
          new ParDef("TituloTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("TituloCriacao",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ContaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("CategoriaTituloId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("TituloPropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001X19;
          prmBC001X19 = new Object[] {
          };
          Object[] prmBC001X20;
          prmBC001X20 = new Object[] {
          new ParDef("NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("TituloValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("TituloDesconto",GXType.Number,18,2){Nullable=true} ,
          new ParDef("TituloDeleted",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("TituloArchived",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("TituloVencimento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("TituloCompetenciaAno",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("TituloCompetenciaMes",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("TituloProrrogacao",GXType.Date,8,0){Nullable=true} ,
          new ParDef("TituloCEP",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("TituloLogradouro",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("TituloNumeroEndereco",GXType.VarChar,10,0){Nullable=true} ,
          new ParDef("TituloComplemento",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("TituloBairro",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("TituloMunicipio",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("TituloJurosMora",GXType.Number,16,4){Nullable=true} ,
          new ParDef("TituloTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("TituloCriacao",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ContaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("CategoriaTituloId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("TituloPropostaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001X21;
          prmBC001X21 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001X23;
          prmBC001X23 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001X25;
          prmBC001X25 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001X26;
          prmBC001X26 = new Object[] {
          new ParDef("TituloPropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001X27;
          prmBC001X27 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001X28;
          prmBC001X28 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001X31;
          prmBC001X31 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001X32;
          prmBC001X32 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001X33;
          prmBC001X33 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001X34;
          prmBC001X34 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001X35;
          prmBC001X35 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC001X2", "SELECT NotaFiscalParcelamentoID, TituloId, TituloValor, TituloDesconto, TituloDeleted, TituloArchived, TituloVencimento, TituloCompetenciaAno, TituloCompetenciaMes, TituloProrrogacao, TituloCEP, TituloLogradouro, TituloNumeroEndereco, TituloComplemento, TituloBairro, TituloMunicipio, TituloJurosMora, TituloTipo, TituloCriacao, ContaId, CategoriaTituloId, TituloPropostaId FROM Titulo WHERE TituloId = :TituloId  FOR UPDATE OF Titulo",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001X3", "SELECT NotaFiscalParcelamentoID, TituloId, TituloValor, TituloDesconto, TituloDeleted, TituloArchived, TituloVencimento, TituloCompetenciaAno, TituloCompetenciaMes, TituloProrrogacao, TituloCEP, TituloLogradouro, TituloNumeroEndereco, TituloComplemento, TituloBairro, TituloMunicipio, TituloJurosMora, TituloTipo, TituloCriacao, ContaId, CategoriaTituloId, TituloPropostaId FROM Titulo WHERE TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001X4", "SELECT ContaId FROM Conta WHERE ContaId = :ContaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001X5", "SELECT CategoriaTituloId FROM CategoriaTitulo WHERE CategoriaTituloId = :CategoriaTituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001X6", "SELECT NotaFiscalId FROM NotaFiscalParcelamento WHERE NotaFiscalParcelamentoID = :NotaFiscalParcelamentoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001X7", "SELECT PropostaTaxaAdministrativa FROM Proposta WHERE PropostaId = :TituloPropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001X8", "SELECT ClienteId FROM NotaFiscal WHERE NotaFiscalId = :NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001X9", "SELECT ClienteRazaoSocial FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001X11", "SELECT COALESCE( T1.TituloTotalMovimento_F, 0) AS TituloTotalMovimento_F FROM (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE TituloMovimentoSoma GROUP BY TituloId ) T1 WHERE T1.TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001X13", "SELECT COALESCE( T1.TituloTotalMovimento_F, 0) AS TituloTotalMultaJuros_F FROM (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE Not TituloMovimentoSoma GROUP BY TituloId ) T1 WHERE T1.TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001X16", "SELECT TM1.NotaFiscalParcelamentoID, T2.NotaFiscalId, TM1.TituloId, T4.ClienteRazaoSocial, TM1.TituloValor, TM1.TituloDesconto, TM1.TituloDeleted, TM1.TituloArchived, TM1.TituloVencimento, TM1.TituloCompetenciaAno, TM1.TituloCompetenciaMes, TM1.TituloProrrogacao, TM1.TituloCEP, TM1.TituloLogradouro, TM1.TituloNumeroEndereco, TM1.TituloComplemento, TM1.TituloBairro, TM1.TituloMunicipio, TM1.TituloJurosMora, TM1.TituloTipo, T7.PropostaTaxaAdministrativa, TM1.TituloCriacao, TM1.ContaId, TM1.CategoriaTituloId, TM1.TituloPropostaId AS TituloPropostaId, T3.ClienteId, COALESCE( T5.TituloTotalMovimento_F, 0) AS TituloTotalMovimento_F, COALESCE( T6.TituloTotalMovimento_F, 0) AS TituloTotalMultaJuros_F FROM ((((((Titulo TM1 LEFT JOIN NotaFiscalParcelamento T2 ON T2.NotaFiscalParcelamentoID = TM1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T3 ON T3.NotaFiscalId = T2.NotaFiscalId) LEFT JOIN Cliente T4 ON T4.ClienteId = T3.ClienteId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (TM1.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T5 ON T5.TituloId = TM1.TituloId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (TM1.TituloId = TituloId) AND (Not TituloMovimentoSoma) GROUP BY TituloId ) T6 ON T6.TituloId = TM1.TituloId) LEFT JOIN Proposta T7 ON T7.PropostaId = TM1.TituloPropostaId) WHERE TM1.TituloId = :TituloId ORDER BY TM1.TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X16,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001X17", "SELECT TituloId FROM Titulo WHERE TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X17,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001X18", "SAVEPOINT gxupdate;INSERT INTO Titulo(NotaFiscalParcelamentoID, TituloValor, TituloDesconto, TituloDeleted, TituloArchived, TituloVencimento, TituloCompetenciaAno, TituloCompetenciaMes, TituloProrrogacao, TituloCEP, TituloLogradouro, TituloNumeroEndereco, TituloComplemento, TituloBairro, TituloMunicipio, TituloJurosMora, TituloTipo, TituloCriacao, ContaId, CategoriaTituloId, TituloPropostaId, TituloPropostaTipo, ContaBancariaId, TituloClienteId) VALUES(:NotaFiscalParcelamentoID, :TituloValor, :TituloDesconto, :TituloDeleted, :TituloArchived, :TituloVencimento, :TituloCompetenciaAno, :TituloCompetenciaMes, :TituloProrrogacao, :TituloCEP, :TituloLogradouro, :TituloNumeroEndereco, :TituloComplemento, :TituloBairro, :TituloMunicipio, :TituloJurosMora, :TituloTipo, :TituloCriacao, :ContaId, :CategoriaTituloId, :TituloPropostaId, '', 0, 0);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001X18)
             ,new CursorDef("BC001X19", "SELECT currval('TituloId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X19,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001X20", "SAVEPOINT gxupdate;UPDATE Titulo SET NotaFiscalParcelamentoID=:NotaFiscalParcelamentoID, TituloValor=:TituloValor, TituloDesconto=:TituloDesconto, TituloDeleted=:TituloDeleted, TituloArchived=:TituloArchived, TituloVencimento=:TituloVencimento, TituloCompetenciaAno=:TituloCompetenciaAno, TituloCompetenciaMes=:TituloCompetenciaMes, TituloProrrogacao=:TituloProrrogacao, TituloCEP=:TituloCEP, TituloLogradouro=:TituloLogradouro, TituloNumeroEndereco=:TituloNumeroEndereco, TituloComplemento=:TituloComplemento, TituloBairro=:TituloBairro, TituloMunicipio=:TituloMunicipio, TituloJurosMora=:TituloJurosMora, TituloTipo=:TituloTipo, TituloCriacao=:TituloCriacao, ContaId=:ContaId, CategoriaTituloId=:CategoriaTituloId, TituloPropostaId=:TituloPropostaId  WHERE TituloId = :TituloId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001X20)
             ,new CursorDef("BC001X21", "SAVEPOINT gxupdate;DELETE FROM Titulo  WHERE TituloId = :TituloId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001X21)
             ,new CursorDef("BC001X23", "SELECT COALESCE( T1.TituloTotalMovimento_F, 0) AS TituloTotalMovimento_F FROM (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE TituloMovimentoSoma GROUP BY TituloId ) T1 WHERE T1.TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X23,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001X25", "SELECT COALESCE( T1.TituloTotalMovimento_F, 0) AS TituloTotalMultaJuros_F FROM (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE Not TituloMovimentoSoma GROUP BY TituloId ) T1 WHERE T1.TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X25,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001X26", "SELECT PropostaTaxaAdministrativa FROM Proposta WHERE PropostaId = :TituloPropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X26,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001X27", "SELECT BoletosId FROM Boleto WHERE TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X27,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001X28", "SELECT TituloMovimentoId FROM TituloMovimento WHERE TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X28,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001X31", "SELECT TM1.NotaFiscalParcelamentoID, T2.NotaFiscalId, TM1.TituloId, T4.ClienteRazaoSocial, TM1.TituloValor, TM1.TituloDesconto, TM1.TituloDeleted, TM1.TituloArchived, TM1.TituloVencimento, TM1.TituloCompetenciaAno, TM1.TituloCompetenciaMes, TM1.TituloProrrogacao, TM1.TituloCEP, TM1.TituloLogradouro, TM1.TituloNumeroEndereco, TM1.TituloComplemento, TM1.TituloBairro, TM1.TituloMunicipio, TM1.TituloJurosMora, TM1.TituloTipo, T7.PropostaTaxaAdministrativa, TM1.TituloCriacao, TM1.ContaId, TM1.CategoriaTituloId, TM1.TituloPropostaId AS TituloPropostaId, T3.ClienteId, COALESCE( T5.TituloTotalMovimento_F, 0) AS TituloTotalMovimento_F, COALESCE( T6.TituloTotalMovimento_F, 0) AS TituloTotalMultaJuros_F FROM ((((((Titulo TM1 LEFT JOIN NotaFiscalParcelamento T2 ON T2.NotaFiscalParcelamentoID = TM1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T3 ON T3.NotaFiscalId = T2.NotaFiscalId) LEFT JOIN Cliente T4 ON T4.ClienteId = T3.ClienteId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (TM1.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T5 ON T5.TituloId = TM1.TituloId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (TM1.TituloId = TituloId) AND (Not TituloMovimentoSoma) GROUP BY TituloId ) T6 ON T6.TituloId = TM1.TituloId) LEFT JOIN Proposta T7 ON T7.PropostaId = TM1.TituloPropostaId) WHERE TM1.TituloId = :TituloId ORDER BY TM1.TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X31,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001X32", "SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento WHERE ( TituloId = :TituloId) and ( TituloMovimentoSoma) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X32,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001X33", "SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento WHERE ( TituloId = :TituloId) and ( TituloMovimentoSoma) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X33,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001X34", "SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento WHERE ( TituloId = :TituloId) and ( Not TituloMovimentoSoma) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X34,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001X35", "SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento WHERE ( TituloId = :TituloId) and ( Not TituloMovimentoSoma) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001X35,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((short[]) buf[15])[0] = rslt.getShort(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((DateTime[]) buf[35])[0] = rslt.getGXDateTime(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((int[]) buf[37])[0] = rslt.getInt(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((int[]) buf[39])[0] = rslt.getInt(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((int[]) buf[41])[0] = rslt.getInt(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((short[]) buf[15])[0] = rslt.getShort(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((DateTime[]) buf[35])[0] = rslt.getGXDateTime(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((int[]) buf[37])[0] = rslt.getInt(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((int[]) buf[39])[0] = rslt.getInt(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((int[]) buf[41])[0] = rslt.getInt(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 8 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 9 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 10 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((short[]) buf[17])[0] = rslt.getShort(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((short[]) buf[19])[0] = rslt.getShort(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[21])[0] = rslt.getGXDate(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((decimal[]) buf[35])[0] = rslt.getDecimal(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((decimal[]) buf[39])[0] = rslt.getDecimal(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((DateTime[]) buf[41])[0] = rslt.getGXDateTime(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((int[]) buf[43])[0] = rslt.getInt(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((int[]) buf[45])[0] = rslt.getInt(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((int[]) buf[47])[0] = rslt.getInt(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((int[]) buf[49])[0] = rslt.getInt(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((decimal[]) buf[51])[0] = rslt.getDecimal(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((decimal[]) buf[53])[0] = rslt.getDecimal(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 16 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 17 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 18 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 19 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 20 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 21 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((short[]) buf[17])[0] = rslt.getShort(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((short[]) buf[19])[0] = rslt.getShort(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[21])[0] = rslt.getGXDate(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((decimal[]) buf[35])[0] = rslt.getDecimal(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((decimal[]) buf[39])[0] = rslt.getDecimal(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((DateTime[]) buf[41])[0] = rslt.getGXDateTime(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((int[]) buf[43])[0] = rslt.getInt(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((int[]) buf[45])[0] = rslt.getInt(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((int[]) buf[47])[0] = rslt.getInt(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((int[]) buf[49])[0] = rslt.getInt(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((decimal[]) buf[51])[0] = rslt.getDecimal(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((decimal[]) buf[53])[0] = rslt.getDecimal(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                return;
             case 22 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 23 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 24 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 25 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

 }

}
