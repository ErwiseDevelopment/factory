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
   public class titulo_bc : GxSilentTrn, IGxSilentTrn
   {
      public titulo_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public titulo_bc( IGxContext context )
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
         ReadRow1544( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1544( ) ;
         standaloneModal( ) ;
         AddRow1544( ) ;
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
            E11152 ();
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

      protected void CONFIRM_150( )
      {
         BeforeValidate1544( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1544( ) ;
            }
            else
            {
               CheckExtendedTable1544( ) ;
               if ( AnyError == 0 )
               {
                  ZM1544( 25) ;
                  ZM1544( 26) ;
                  ZM1544( 27) ;
                  ZM1544( 28) ;
                  ZM1544( 29) ;
                  ZM1544( 30) ;
                  ZM1544( 31) ;
                  ZM1544( 32) ;
                  ZM1544( 33) ;
                  ZM1544( 34) ;
                  ZM1544( 35) ;
                  ZM1544( 36) ;
                  ZM1544( 37) ;
               }
               CloseExtendedTableCursors1544( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12152( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV27Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV28GXV1 = 1;
            while ( AV28GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV28GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "TituloClienteId") == 0 )
               {
                  AV25Insert_TituloClienteId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
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
               else if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "NotaFiscalParcelamentoID") == 0 )
               {
                  AV23Insert_NotaFiscalParcelamentoID = StringUtil.StrToGuid( AV12TrnContextAtt.gxTpr_Attributevalue);
               }
               else if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "ContaBancariaId") == 0 )
               {
                  AV24Insert_ContaBancariaId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV28GXV1 = (int)(AV28GXV1+1);
            }
         }
      }

      protected void E11152( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1544( short GX_JID )
      {
         if ( ( GX_JID == 24 ) || ( GX_JID == 0 ) )
         {
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
            Z648TituloPropostaTipo = A648TituloPropostaTipo;
            Z422ContaId = A422ContaId;
            Z426CategoriaTituloId = A426CategoriaTituloId;
            Z890NotaFiscalParcelamentoID = A890NotaFiscalParcelamentoID;
            Z951ContaBancariaId = A951ContaBancariaId;
            Z419TituloPropostaId = A419TituloPropostaId;
            Z420TituloClienteId = A420TituloClienteId;
            Z295TituloCompetencia_F = A295TituloCompetencia_F;
            Z516TituloDataCredito_F = A516TituloDataCredito_F;
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
            Z1118TitulosEmCarteiraDeCobranca_F = A1118TitulosEmCarteiraDeCobranca_F;
            Z1119TitulosCarteiraDeCobranca = A1119TitulosCarteiraDeCobranca;
         }
         if ( ( GX_JID == 25 ) || ( GX_JID == 0 ) )
         {
            Z295TituloCompetencia_F = A295TituloCompetencia_F;
            Z516TituloDataCredito_F = A516TituloDataCredito_F;
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
            Z1118TitulosEmCarteiraDeCobranca_F = A1118TitulosEmCarteiraDeCobranca_F;
            Z1119TitulosCarteiraDeCobranca = A1119TitulosCarteiraDeCobranca;
         }
         if ( ( GX_JID == 26 ) || ( GX_JID == 0 ) )
         {
            Z295TituloCompetencia_F = A295TituloCompetencia_F;
            Z516TituloDataCredito_F = A516TituloDataCredito_F;
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
            Z1118TitulosEmCarteiraDeCobranca_F = A1118TitulosEmCarteiraDeCobranca_F;
            Z1119TitulosCarteiraDeCobranca = A1119TitulosCarteiraDeCobranca;
         }
         if ( ( GX_JID == 27 ) || ( GX_JID == 0 ) )
         {
            Z794NotaFiscalId = A794NotaFiscalId;
            Z295TituloCompetencia_F = A295TituloCompetencia_F;
            Z516TituloDataCredito_F = A516TituloDataCredito_F;
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
            Z1118TitulosEmCarteiraDeCobranca_F = A1118TitulosEmCarteiraDeCobranca_F;
            Z1119TitulosCarteiraDeCobranca = A1119TitulosCarteiraDeCobranca;
         }
         if ( ( GX_JID == 28 ) || ( GX_JID == 0 ) )
         {
            Z938AgenciaId = A938AgenciaId;
            Z953ContaBancariaCarteira = A953ContaBancariaCarteira;
            Z952ContaBancariaNumero = A952ContaBancariaNumero;
            Z295TituloCompetencia_F = A295TituloCompetencia_F;
            Z516TituloDataCredito_F = A516TituloDataCredito_F;
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
            Z1118TitulosEmCarteiraDeCobranca_F = A1118TitulosEmCarteiraDeCobranca_F;
            Z1119TitulosCarteiraDeCobranca = A1119TitulosCarteiraDeCobranca;
         }
         if ( ( GX_JID == 29 ) || ( GX_JID == 0 ) )
         {
            Z971TituloPropostaDescricao = A971TituloPropostaDescricao;
            Z501PropostaTaxaAdministrativa = A501PropostaTaxaAdministrativa;
            Z295TituloCompetencia_F = A295TituloCompetencia_F;
            Z516TituloDataCredito_F = A516TituloDataCredito_F;
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
            Z1118TitulosEmCarteiraDeCobranca_F = A1118TitulosEmCarteiraDeCobranca_F;
            Z1119TitulosCarteiraDeCobranca = A1119TitulosCarteiraDeCobranca;
         }
         if ( ( GX_JID == 30 ) || ( GX_JID == 0 ) )
         {
            Z972TituloCLienteRazaoSocial = A972TituloCLienteRazaoSocial;
            Z295TituloCompetencia_F = A295TituloCompetencia_F;
            Z516TituloDataCredito_F = A516TituloDataCredito_F;
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
            Z1118TitulosEmCarteiraDeCobranca_F = A1118TitulosEmCarteiraDeCobranca_F;
            Z1119TitulosCarteiraDeCobranca = A1119TitulosCarteiraDeCobranca;
         }
         if ( ( GX_JID == 31 ) || ( GX_JID == 0 ) )
         {
            Z799NotaFiscalNumero = A799NotaFiscalNumero;
            Z295TituloCompetencia_F = A295TituloCompetencia_F;
            Z516TituloDataCredito_F = A516TituloDataCredito_F;
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
            Z1118TitulosEmCarteiraDeCobranca_F = A1118TitulosEmCarteiraDeCobranca_F;
            Z1119TitulosCarteiraDeCobranca = A1119TitulosCarteiraDeCobranca;
         }
         if ( ( GX_JID == 32 ) || ( GX_JID == 0 ) )
         {
            Z968AgenciaBancoId = A968AgenciaBancoId;
            Z939AgenciaNumero = A939AgenciaNumero;
            Z295TituloCompetencia_F = A295TituloCompetencia_F;
            Z516TituloDataCredito_F = A516TituloDataCredito_F;
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
            Z1118TitulosEmCarteiraDeCobranca_F = A1118TitulosEmCarteiraDeCobranca_F;
            Z1119TitulosCarteiraDeCobranca = A1119TitulosCarteiraDeCobranca;
         }
         if ( ( GX_JID == 33 ) || ( GX_JID == 0 ) )
         {
            Z969AgenciaBancoNome = A969AgenciaBancoNome;
            Z295TituloCompetencia_F = A295TituloCompetencia_F;
            Z516TituloDataCredito_F = A516TituloDataCredito_F;
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
            Z1118TitulosEmCarteiraDeCobranca_F = A1118TitulosEmCarteiraDeCobranca_F;
            Z1119TitulosCarteiraDeCobranca = A1119TitulosCarteiraDeCobranca;
         }
         if ( ( GX_JID == 34 ) || ( GX_JID == 0 ) )
         {
            Z295TituloCompetencia_F = A295TituloCompetencia_F;
            Z516TituloDataCredito_F = A516TituloDataCredito_F;
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
            Z1118TitulosEmCarteiraDeCobranca_F = A1118TitulosEmCarteiraDeCobranca_F;
            Z1119TitulosCarteiraDeCobranca = A1119TitulosCarteiraDeCobranca;
         }
         if ( ( GX_JID == 35 ) || ( GX_JID == 0 ) )
         {
            Z295TituloCompetencia_F = A295TituloCompetencia_F;
            Z516TituloDataCredito_F = A516TituloDataCredito_F;
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
            Z1118TitulosEmCarteiraDeCobranca_F = A1118TitulosEmCarteiraDeCobranca_F;
            Z1119TitulosCarteiraDeCobranca = A1119TitulosCarteiraDeCobranca;
         }
         if ( ( GX_JID == 36 ) || ( GX_JID == 0 ) )
         {
            Z295TituloCompetencia_F = A295TituloCompetencia_F;
            Z516TituloDataCredito_F = A516TituloDataCredito_F;
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
            Z1118TitulosEmCarteiraDeCobranca_F = A1118TitulosEmCarteiraDeCobranca_F;
            Z1119TitulosCarteiraDeCobranca = A1119TitulosCarteiraDeCobranca;
         }
         if ( ( GX_JID == 37 ) || ( GX_JID == 0 ) )
         {
            Z295TituloCompetencia_F = A295TituloCompetencia_F;
            Z516TituloDataCredito_F = A516TituloDataCredito_F;
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
            Z1118TitulosEmCarteiraDeCobranca_F = A1118TitulosEmCarteiraDeCobranca_F;
            Z1119TitulosCarteiraDeCobranca = A1119TitulosCarteiraDeCobranca;
         }
         if ( GX_JID == -24 )
         {
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
            Z648TituloPropostaTipo = A648TituloPropostaTipo;
            Z422ContaId = A422ContaId;
            Z426CategoriaTituloId = A426CategoriaTituloId;
            Z890NotaFiscalParcelamentoID = A890NotaFiscalParcelamentoID;
            Z951ContaBancariaId = A951ContaBancariaId;
            Z419TituloPropostaId = A419TituloPropostaId;
            Z420TituloClienteId = A420TituloClienteId;
            Z516TituloDataCredito_F = A516TituloDataCredito_F;
            Z273TituloTotalMovimento_F = A273TituloTotalMovimento_F;
            Z301TituloTotalMultaJuros_F = A301TituloTotalMultaJuros_F;
            Z1119TitulosCarteiraDeCobranca = A1119TitulosCarteiraDeCobranca;
            Z972TituloCLienteRazaoSocial = A972TituloCLienteRazaoSocial;
            Z971TituloPropostaDescricao = A971TituloPropostaDescricao;
            Z501PropostaTaxaAdministrativa = A501PropostaTaxaAdministrativa;
            Z794NotaFiscalId = A794NotaFiscalId;
            Z799NotaFiscalNumero = A799NotaFiscalNumero;
            Z938AgenciaId = A938AgenciaId;
            Z953ContaBancariaCarteira = A953ContaBancariaCarteira;
            Z952ContaBancariaNumero = A952ContaBancariaNumero;
            Z968AgenciaBancoId = A968AgenciaBancoId;
            Z939AgenciaNumero = A939AgenciaNumero;
            Z969AgenciaBancoNome = A969AgenciaBancoNome;
         }
      }

      protected void standaloneNotModal( )
      {
         AV27Pgmname = "Titulo_BC";
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
      }

      protected void Load1544( )
      {
         /* Using cursor BC001525 */
         pr_default.execute(15, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound44 = 1;
            A794NotaFiscalId = BC001525_A794NotaFiscalId[0];
            n794NotaFiscalId = BC001525_n794NotaFiscalId[0];
            A938AgenciaId = BC001525_A938AgenciaId[0];
            n938AgenciaId = BC001525_n938AgenciaId[0];
            A968AgenciaBancoId = BC001525_A968AgenciaBancoId[0];
            n968AgenciaBancoId = BC001525_n968AgenciaBancoId[0];
            A972TituloCLienteRazaoSocial = BC001525_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = BC001525_n972TituloCLienteRazaoSocial[0];
            A262TituloValor = BC001525_A262TituloValor[0];
            n262TituloValor = BC001525_n262TituloValor[0];
            A276TituloDesconto = BC001525_A276TituloDesconto[0];
            n276TituloDesconto = BC001525_n276TituloDesconto[0];
            A284TituloDeleted = BC001525_A284TituloDeleted[0];
            n284TituloDeleted = BC001525_n284TituloDeleted[0];
            A314TituloArchived = BC001525_A314TituloArchived[0];
            n314TituloArchived = BC001525_n314TituloArchived[0];
            A263TituloVencimento = BC001525_A263TituloVencimento[0];
            n263TituloVencimento = BC001525_n263TituloVencimento[0];
            A286TituloCompetenciaAno = BC001525_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = BC001525_n286TituloCompetenciaAno[0];
            A287TituloCompetenciaMes = BC001525_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = BC001525_n287TituloCompetenciaMes[0];
            A264TituloProrrogacao = BC001525_A264TituloProrrogacao[0];
            n264TituloProrrogacao = BC001525_n264TituloProrrogacao[0];
            A265TituloCEP = BC001525_A265TituloCEP[0];
            n265TituloCEP = BC001525_n265TituloCEP[0];
            A266TituloLogradouro = BC001525_A266TituloLogradouro[0];
            n266TituloLogradouro = BC001525_n266TituloLogradouro[0];
            A294TituloNumeroEndereco = BC001525_A294TituloNumeroEndereco[0];
            n294TituloNumeroEndereco = BC001525_n294TituloNumeroEndereco[0];
            A267TituloComplemento = BC001525_A267TituloComplemento[0];
            n267TituloComplemento = BC001525_n267TituloComplemento[0];
            A268TituloBairro = BC001525_A268TituloBairro[0];
            n268TituloBairro = BC001525_n268TituloBairro[0];
            A269TituloMunicipio = BC001525_A269TituloMunicipio[0];
            n269TituloMunicipio = BC001525_n269TituloMunicipio[0];
            A498TituloJurosMora = BC001525_A498TituloJurosMora[0];
            n498TituloJurosMora = BC001525_n498TituloJurosMora[0];
            A283TituloTipo = BC001525_A283TituloTipo[0];
            n283TituloTipo = BC001525_n283TituloTipo[0];
            A971TituloPropostaDescricao = BC001525_A971TituloPropostaDescricao[0];
            n971TituloPropostaDescricao = BC001525_n971TituloPropostaDescricao[0];
            A501PropostaTaxaAdministrativa = BC001525_A501PropostaTaxaAdministrativa[0];
            n501PropostaTaxaAdministrativa = BC001525_n501PropostaTaxaAdministrativa[0];
            A500TituloCriacao = BC001525_A500TituloCriacao[0];
            n500TituloCriacao = BC001525_n500TituloCriacao[0];
            A648TituloPropostaTipo = BC001525_A648TituloPropostaTipo[0];
            n648TituloPropostaTipo = BC001525_n648TituloPropostaTipo[0];
            A799NotaFiscalNumero = BC001525_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = BC001525_n799NotaFiscalNumero[0];
            A969AgenciaBancoNome = BC001525_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = BC001525_n969AgenciaBancoNome[0];
            A953ContaBancariaCarteira = BC001525_A953ContaBancariaCarteira[0];
            n953ContaBancariaCarteira = BC001525_n953ContaBancariaCarteira[0];
            A952ContaBancariaNumero = BC001525_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = BC001525_n952ContaBancariaNumero[0];
            A939AgenciaNumero = BC001525_A939AgenciaNumero[0];
            n939AgenciaNumero = BC001525_n939AgenciaNumero[0];
            A422ContaId = BC001525_A422ContaId[0];
            n422ContaId = BC001525_n422ContaId[0];
            A426CategoriaTituloId = BC001525_A426CategoriaTituloId[0];
            n426CategoriaTituloId = BC001525_n426CategoriaTituloId[0];
            A890NotaFiscalParcelamentoID = BC001525_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = BC001525_n890NotaFiscalParcelamentoID[0];
            A951ContaBancariaId = BC001525_A951ContaBancariaId[0];
            n951ContaBancariaId = BC001525_n951ContaBancariaId[0];
            A419TituloPropostaId = BC001525_A419TituloPropostaId[0];
            n419TituloPropostaId = BC001525_n419TituloPropostaId[0];
            A420TituloClienteId = BC001525_A420TituloClienteId[0];
            n420TituloClienteId = BC001525_n420TituloClienteId[0];
            A516TituloDataCredito_F = BC001525_A516TituloDataCredito_F[0];
            n516TituloDataCredito_F = BC001525_n516TituloDataCredito_F[0];
            A273TituloTotalMovimento_F = BC001525_A273TituloTotalMovimento_F[0];
            n273TituloTotalMovimento_F = BC001525_n273TituloTotalMovimento_F[0];
            A301TituloTotalMultaJuros_F = BC001525_A301TituloTotalMultaJuros_F[0];
            n301TituloTotalMultaJuros_F = BC001525_n301TituloTotalMultaJuros_F[0];
            A1119TitulosCarteiraDeCobranca = BC001525_A1119TitulosCarteiraDeCobranca[0];
            n1119TitulosCarteiraDeCobranca = BC001525_n1119TitulosCarteiraDeCobranca[0];
            ZM1544( -24) ;
         }
         pr_default.close(15);
         OnLoadActions1544( ) ;
      }

      protected void OnLoadActions1544( )
      {
         A303TituloSaldoCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? (A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F : (decimal)(0));
         A302TituloSaldoDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? (A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F : (decimal)(0));
         A275TituloSaldo_F = (decimal)((A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F);
         A282TituloStatus_F = ((Convert.ToDecimal(0)==A275TituloSaldo_F) ? "Liquidado" : ((A275TituloSaldo_F==A262TituloValor) ? "Aberto" : "Baixado parcialmente"));
         A1118TitulosEmCarteiraDeCobranca_F = ((GetTitulosEmCarteiraDeCobranca_F0( A261TituloId)==0) ? false : true);
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
         if ( (Guid.Empty==A890NotaFiscalParcelamentoID) )
         {
            A890NotaFiscalParcelamentoID = Guid.Empty;
            n890NotaFiscalParcelamentoID = false;
            n890NotaFiscalParcelamentoID = true;
            n890NotaFiscalParcelamentoID = true;
         }
         if ( (0==A951ContaBancariaId) )
         {
            A951ContaBancariaId = 0;
            n951ContaBancariaId = false;
            n951ContaBancariaId = true;
            n951ContaBancariaId = true;
         }
      }

      protected void CheckExtendedTable1544( )
      {
         standaloneModal( ) ;
         /* Using cursor BC001514 */
         pr_default.execute(11, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            A516TituloDataCredito_F = BC001514_A516TituloDataCredito_F[0];
            n516TituloDataCredito_F = BC001514_n516TituloDataCredito_F[0];
         }
         else
         {
            A516TituloDataCredito_F = DateTime.MinValue;
            n516TituloDataCredito_F = false;
         }
         pr_default.close(11);
         /* Using cursor BC001516 */
         pr_default.execute(12, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            A273TituloTotalMovimento_F = BC001516_A273TituloTotalMovimento_F[0];
            n273TituloTotalMovimento_F = BC001516_n273TituloTotalMovimento_F[0];
         }
         else
         {
            A273TituloTotalMovimento_F = 0;
            n273TituloTotalMovimento_F = false;
         }
         pr_default.close(12);
         A303TituloSaldoCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? (A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F : (decimal)(0));
         A302TituloSaldoDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? (A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F : (decimal)(0));
         A275TituloSaldo_F = (decimal)((A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F);
         A282TituloStatus_F = ((Convert.ToDecimal(0)==A275TituloSaldo_F) ? "Liquidado" : ((A275TituloSaldo_F==A262TituloValor) ? "Aberto" : "Baixado parcialmente"));
         /* Using cursor BC001518 */
         pr_default.execute(13, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            A301TituloTotalMultaJuros_F = BC001518_A301TituloTotalMultaJuros_F[0];
            n301TituloTotalMultaJuros_F = BC001518_n301TituloTotalMultaJuros_F[0];
         }
         else
         {
            A301TituloTotalMultaJuros_F = 0;
            n301TituloTotalMultaJuros_F = false;
         }
         pr_default.close(13);
         /* Using cursor BC001520 */
         pr_default.execute(14, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            A1119TitulosCarteiraDeCobranca = BC001520_A1119TitulosCarteiraDeCobranca[0];
            n1119TitulosCarteiraDeCobranca = BC001520_n1119TitulosCarteiraDeCobranca[0];
         }
         else
         {
            A1119TitulosCarteiraDeCobranca = "";
            n1119TitulosCarteiraDeCobranca = false;
         }
         pr_default.close(14);
         A1118TitulosEmCarteiraDeCobranca_F = ((GetTitulosEmCarteiraDeCobranca_F0( A261TituloId)==0) ? false : true);
         A307TituloTotalMultaJurosCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? GetTituloTotalMultaJurosCredito_F0( A261TituloId) : (decimal)(0));
         A306TituloTotalMultaJurosDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? GetTituloTotalMultaJurosDebito_F0( A261TituloId) : (decimal)(0));
         A305TituloTotalMovimentoCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? GetTituloTotalMovimentoCredito_F0( A261TituloId) : (decimal)(0));
         A304TituloTotalMovimentoDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? GetTituloTotalMovimentoDebito_F0( A261TituloId) : (decimal)(0));
         /* Using cursor BC00159 */
         pr_default.execute(7, new Object[] {n420TituloClienteId, A420TituloClienteId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A420TituloClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Titulo Cliente Id'.", "ForeignKeyNotFound", 1, "TITULOCLIENTEID");
               AnyError = 1;
            }
         }
         A972TituloCLienteRazaoSocial = BC00159_A972TituloCLienteRazaoSocial[0];
         n972TituloCLienteRazaoSocial = BC00159_n972TituloCLienteRazaoSocial[0];
         pr_default.close(7);
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
         /* Using cursor BC00158 */
         pr_default.execute(6, new Object[] {n419TituloPropostaId, A419TituloPropostaId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A419TituloPropostaId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Titulo Proposta Id'.", "ForeignKeyNotFound", 1, "TITULOPROPOSTAID");
               AnyError = 1;
            }
         }
         A971TituloPropostaDescricao = BC00158_A971TituloPropostaDescricao[0];
         n971TituloPropostaDescricao = BC00158_n971TituloPropostaDescricao[0];
         A501PropostaTaxaAdministrativa = BC00158_A501PropostaTaxaAdministrativa[0];
         n501PropostaTaxaAdministrativa = BC00158_n501PropostaTaxaAdministrativa[0];
         pr_default.close(6);
         if ( (0==A422ContaId) )
         {
            A422ContaId = 0;
            n422ContaId = false;
            n422ContaId = true;
            n422ContaId = true;
         }
         /* Using cursor BC00154 */
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
         /* Using cursor BC00155 */
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
         if ( ! ( ( StringUtil.StrCmp(A648TituloPropostaTipo, "IOF") == 0 ) || ( StringUtil.StrCmp(A648TituloPropostaTipo, "TAXA") == 0 ) || ( StringUtil.StrCmp(A648TituloPropostaTipo, "REEMBOLSO") == 0 ) || ( StringUtil.StrCmp(A648TituloPropostaTipo, "COMUM") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A648TituloPropostaTipo)) ) )
         {
            GX_msglist.addItem("Campo Titulo Proposta Tipo fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( (Guid.Empty==A890NotaFiscalParcelamentoID) )
         {
            A890NotaFiscalParcelamentoID = Guid.Empty;
            n890NotaFiscalParcelamentoID = false;
            n890NotaFiscalParcelamentoID = true;
            n890NotaFiscalParcelamentoID = true;
         }
         /* Using cursor BC00156 */
         pr_default.execute(4, new Object[] {n890NotaFiscalParcelamentoID, A890NotaFiscalParcelamentoID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (Guid.Empty==A890NotaFiscalParcelamentoID) ) )
            {
               GX_msglist.addItem("Não existe 'Nota Fiscal Parcelamento'.", "ForeignKeyNotFound", 1, "NOTAFISCALPARCELAMENTOID");
               AnyError = 1;
            }
         }
         A794NotaFiscalId = BC00156_A794NotaFiscalId[0];
         n794NotaFiscalId = BC00156_n794NotaFiscalId[0];
         pr_default.close(4);
         /* Using cursor BC001510 */
         pr_default.execute(8, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (Guid.Empty==A794NotaFiscalId) ) )
            {
               GX_msglist.addItem("Não existe 'NotaFiscal'.", "ForeignKeyNotFound", 1, "NOTAFISCALID");
               AnyError = 1;
            }
         }
         A799NotaFiscalNumero = BC001510_A799NotaFiscalNumero[0];
         n799NotaFiscalNumero = BC001510_n799NotaFiscalNumero[0];
         pr_default.close(8);
         if ( (0==A951ContaBancariaId) )
         {
            A951ContaBancariaId = 0;
            n951ContaBancariaId = false;
            n951ContaBancariaId = true;
            n951ContaBancariaId = true;
         }
         /* Using cursor BC00157 */
         pr_default.execute(5, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A951ContaBancariaId) ) )
            {
               GX_msglist.addItem("Não existe 'Conta Bancaria'.", "ForeignKeyNotFound", 1, "CONTABANCARIAID");
               AnyError = 1;
            }
         }
         A938AgenciaId = BC00157_A938AgenciaId[0];
         n938AgenciaId = BC00157_n938AgenciaId[0];
         A953ContaBancariaCarteira = BC00157_A953ContaBancariaCarteira[0];
         n953ContaBancariaCarteira = BC00157_n953ContaBancariaCarteira[0];
         A952ContaBancariaNumero = BC00157_A952ContaBancariaNumero[0];
         n952ContaBancariaNumero = BC00157_n952ContaBancariaNumero[0];
         pr_default.close(5);
         /* Using cursor BC001511 */
         pr_default.execute(9, new Object[] {n938AgenciaId, A938AgenciaId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( (0==A938AgenciaId) ) )
            {
               GX_msglist.addItem("Não existe 'Agencia'.", "ForeignKeyNotFound", 1, "AGENCIAID");
               AnyError = 1;
            }
         }
         A968AgenciaBancoId = BC001511_A968AgenciaBancoId[0];
         n968AgenciaBancoId = BC001511_n968AgenciaBancoId[0];
         A939AgenciaNumero = BC001511_A939AgenciaNumero[0];
         n939AgenciaNumero = BC001511_n939AgenciaNumero[0];
         pr_default.close(9);
         /* Using cursor BC001512 */
         pr_default.execute(10, new Object[] {n968AgenciaBancoId, A968AgenciaBancoId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( (0==A968AgenciaBancoId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Agencia Banco Id'.", "ForeignKeyNotFound", 1, "AGENCIABANCOID");
               AnyError = 1;
            }
         }
         A969AgenciaBancoNome = BC001512_A969AgenciaBancoNome[0];
         n969AgenciaBancoNome = BC001512_n969AgenciaBancoNome[0];
         pr_default.close(10);
      }

      protected void CloseExtendedTableCursors1544( )
      {
         pr_default.close(11);
         pr_default.close(12);
         pr_default.close(13);
         pr_default.close(14);
         pr_default.close(7);
         pr_default.close(6);
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(8);
         pr_default.close(5);
         pr_default.close(9);
         pr_default.close(10);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1544( )
      {
         /* Using cursor BC001526 */
         pr_default.execute(16, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound44 = 1;
         }
         else
         {
            RcdFound44 = 0;
         }
         pr_default.close(16);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00153 */
         pr_default.execute(1, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1544( 24) ;
            RcdFound44 = 1;
            A261TituloId = BC00153_A261TituloId[0];
            n261TituloId = BC00153_n261TituloId[0];
            A262TituloValor = BC00153_A262TituloValor[0];
            n262TituloValor = BC00153_n262TituloValor[0];
            A276TituloDesconto = BC00153_A276TituloDesconto[0];
            n276TituloDesconto = BC00153_n276TituloDesconto[0];
            A284TituloDeleted = BC00153_A284TituloDeleted[0];
            n284TituloDeleted = BC00153_n284TituloDeleted[0];
            A314TituloArchived = BC00153_A314TituloArchived[0];
            n314TituloArchived = BC00153_n314TituloArchived[0];
            A263TituloVencimento = BC00153_A263TituloVencimento[0];
            n263TituloVencimento = BC00153_n263TituloVencimento[0];
            A286TituloCompetenciaAno = BC00153_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = BC00153_n286TituloCompetenciaAno[0];
            A287TituloCompetenciaMes = BC00153_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = BC00153_n287TituloCompetenciaMes[0];
            A264TituloProrrogacao = BC00153_A264TituloProrrogacao[0];
            n264TituloProrrogacao = BC00153_n264TituloProrrogacao[0];
            A265TituloCEP = BC00153_A265TituloCEP[0];
            n265TituloCEP = BC00153_n265TituloCEP[0];
            A266TituloLogradouro = BC00153_A266TituloLogradouro[0];
            n266TituloLogradouro = BC00153_n266TituloLogradouro[0];
            A294TituloNumeroEndereco = BC00153_A294TituloNumeroEndereco[0];
            n294TituloNumeroEndereco = BC00153_n294TituloNumeroEndereco[0];
            A267TituloComplemento = BC00153_A267TituloComplemento[0];
            n267TituloComplemento = BC00153_n267TituloComplemento[0];
            A268TituloBairro = BC00153_A268TituloBairro[0];
            n268TituloBairro = BC00153_n268TituloBairro[0];
            A269TituloMunicipio = BC00153_A269TituloMunicipio[0];
            n269TituloMunicipio = BC00153_n269TituloMunicipio[0];
            A498TituloJurosMora = BC00153_A498TituloJurosMora[0];
            n498TituloJurosMora = BC00153_n498TituloJurosMora[0];
            A283TituloTipo = BC00153_A283TituloTipo[0];
            n283TituloTipo = BC00153_n283TituloTipo[0];
            A500TituloCriacao = BC00153_A500TituloCriacao[0];
            n500TituloCriacao = BC00153_n500TituloCriacao[0];
            A648TituloPropostaTipo = BC00153_A648TituloPropostaTipo[0];
            n648TituloPropostaTipo = BC00153_n648TituloPropostaTipo[0];
            A422ContaId = BC00153_A422ContaId[0];
            n422ContaId = BC00153_n422ContaId[0];
            A426CategoriaTituloId = BC00153_A426CategoriaTituloId[0];
            n426CategoriaTituloId = BC00153_n426CategoriaTituloId[0];
            A890NotaFiscalParcelamentoID = BC00153_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = BC00153_n890NotaFiscalParcelamentoID[0];
            A951ContaBancariaId = BC00153_A951ContaBancariaId[0];
            n951ContaBancariaId = BC00153_n951ContaBancariaId[0];
            A419TituloPropostaId = BC00153_A419TituloPropostaId[0];
            n419TituloPropostaId = BC00153_n419TituloPropostaId[0];
            A420TituloClienteId = BC00153_A420TituloClienteId[0];
            n420TituloClienteId = BC00153_n420TituloClienteId[0];
            Z261TituloId = A261TituloId;
            sMode44 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1544( ) ;
            if ( AnyError == 1 )
            {
               RcdFound44 = 0;
               InitializeNonKey1544( ) ;
            }
            Gx_mode = sMode44;
         }
         else
         {
            RcdFound44 = 0;
            InitializeNonKey1544( ) ;
            sMode44 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode44;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1544( ) ;
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
         CONFIRM_150( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1544( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00152 */
            pr_default.execute(0, new Object[] {n261TituloId, A261TituloId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Titulo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z262TituloValor != BC00152_A262TituloValor[0] ) || ( Z276TituloDesconto != BC00152_A276TituloDesconto[0] ) || ( Z284TituloDeleted != BC00152_A284TituloDeleted[0] ) || ( Z314TituloArchived != BC00152_A314TituloArchived[0] ) || ( DateTimeUtil.ResetTime ( Z263TituloVencimento ) != DateTimeUtil.ResetTime ( BC00152_A263TituloVencimento[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z286TituloCompetenciaAno != BC00152_A286TituloCompetenciaAno[0] ) || ( Z287TituloCompetenciaMes != BC00152_A287TituloCompetenciaMes[0] ) || ( DateTimeUtil.ResetTime ( Z264TituloProrrogacao ) != DateTimeUtil.ResetTime ( BC00152_A264TituloProrrogacao[0] ) ) || ( StringUtil.StrCmp(Z265TituloCEP, BC00152_A265TituloCEP[0]) != 0 ) || ( StringUtil.StrCmp(Z266TituloLogradouro, BC00152_A266TituloLogradouro[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z294TituloNumeroEndereco, BC00152_A294TituloNumeroEndereco[0]) != 0 ) || ( StringUtil.StrCmp(Z267TituloComplemento, BC00152_A267TituloComplemento[0]) != 0 ) || ( StringUtil.StrCmp(Z268TituloBairro, BC00152_A268TituloBairro[0]) != 0 ) || ( StringUtil.StrCmp(Z269TituloMunicipio, BC00152_A269TituloMunicipio[0]) != 0 ) || ( Z498TituloJurosMora != BC00152_A498TituloJurosMora[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z283TituloTipo, BC00152_A283TituloTipo[0]) != 0 ) || ( Z500TituloCriacao != BC00152_A500TituloCriacao[0] ) || ( StringUtil.StrCmp(Z648TituloPropostaTipo, BC00152_A648TituloPropostaTipo[0]) != 0 ) || ( Z422ContaId != BC00152_A422ContaId[0] ) || ( Z426CategoriaTituloId != BC00152_A426CategoriaTituloId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z890NotaFiscalParcelamentoID != BC00152_A890NotaFiscalParcelamentoID[0] ) || ( Z951ContaBancariaId != BC00152_A951ContaBancariaId[0] ) || ( Z419TituloPropostaId != BC00152_A419TituloPropostaId[0] ) || ( Z420TituloClienteId != BC00152_A420TituloClienteId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Titulo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1544( )
      {
         BeforeValidate1544( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1544( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1544( 0) ;
            CheckOptimisticConcurrency1544( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1544( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1544( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001527 */
                     pr_default.execute(17, new Object[] {n262TituloValor, A262TituloValor, n276TituloDesconto, A276TituloDesconto, n284TituloDeleted, A284TituloDeleted, n314TituloArchived, A314TituloArchived, n263TituloVencimento, A263TituloVencimento, n286TituloCompetenciaAno, A286TituloCompetenciaAno, n287TituloCompetenciaMes, A287TituloCompetenciaMes, n264TituloProrrogacao, A264TituloProrrogacao, n265TituloCEP, A265TituloCEP, n266TituloLogradouro, A266TituloLogradouro, n294TituloNumeroEndereco, A294TituloNumeroEndereco, n267TituloComplemento, A267TituloComplemento, n268TituloBairro, A268TituloBairro, n269TituloMunicipio, A269TituloMunicipio, n498TituloJurosMora, A498TituloJurosMora, n283TituloTipo, A283TituloTipo, n500TituloCriacao, A500TituloCriacao, n648TituloPropostaTipo, A648TituloPropostaTipo, n422ContaId, A422ContaId, n426CategoriaTituloId, A426CategoriaTituloId, n890NotaFiscalParcelamentoID, A890NotaFiscalParcelamentoID, n951ContaBancariaId, A951ContaBancariaId, n419TituloPropostaId, A419TituloPropostaId, n420TituloClienteId, A420TituloClienteId});
                     pr_default.close(17);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC001528 */
                     pr_default.execute(18);
                     A261TituloId = BC001528_A261TituloId[0];
                     n261TituloId = BC001528_n261TituloId[0];
                     pr_default.close(18);
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
               Load1544( ) ;
            }
            EndLevel1544( ) ;
         }
         CloseExtendedTableCursors1544( ) ;
      }

      protected void Update1544( )
      {
         BeforeValidate1544( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1544( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1544( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1544( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1544( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001529 */
                     pr_default.execute(19, new Object[] {n262TituloValor, A262TituloValor, n276TituloDesconto, A276TituloDesconto, n284TituloDeleted, A284TituloDeleted, n314TituloArchived, A314TituloArchived, n263TituloVencimento, A263TituloVencimento, n286TituloCompetenciaAno, A286TituloCompetenciaAno, n287TituloCompetenciaMes, A287TituloCompetenciaMes, n264TituloProrrogacao, A264TituloProrrogacao, n265TituloCEP, A265TituloCEP, n266TituloLogradouro, A266TituloLogradouro, n294TituloNumeroEndereco, A294TituloNumeroEndereco, n267TituloComplemento, A267TituloComplemento, n268TituloBairro, A268TituloBairro, n269TituloMunicipio, A269TituloMunicipio, n498TituloJurosMora, A498TituloJurosMora, n283TituloTipo, A283TituloTipo, n500TituloCriacao, A500TituloCriacao, n648TituloPropostaTipo, A648TituloPropostaTipo, n422ContaId, A422ContaId, n426CategoriaTituloId, A426CategoriaTituloId, n890NotaFiscalParcelamentoID, A890NotaFiscalParcelamentoID, n951ContaBancariaId, A951ContaBancariaId, n419TituloPropostaId, A419TituloPropostaId, n420TituloClienteId, A420TituloClienteId, n261TituloId, A261TituloId});
                     pr_default.close(19);
                     pr_default.SmartCacheProvider.SetUpdated("Titulo");
                     if ( (pr_default.getStatus(19) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Titulo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1544( ) ;
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
            EndLevel1544( ) ;
         }
         CloseExtendedTableCursors1544( ) ;
      }

      protected void DeferredUpdate1544( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1544( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1544( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1544( ) ;
            AfterConfirm1544( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1544( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001530 */
                  pr_default.execute(20, new Object[] {n261TituloId, A261TituloId});
                  pr_default.close(20);
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
         EndLevel1544( ) ;
         Gx_mode = sMode44;
      }

      protected void OnDeleteControls1544( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001532 */
            pr_default.execute(21, new Object[] {n261TituloId, A261TituloId});
            if ( (pr_default.getStatus(21) != 101) )
            {
               A516TituloDataCredito_F = BC001532_A516TituloDataCredito_F[0];
               n516TituloDataCredito_F = BC001532_n516TituloDataCredito_F[0];
            }
            else
            {
               A516TituloDataCredito_F = DateTime.MinValue;
               n516TituloDataCredito_F = false;
            }
            pr_default.close(21);
            /* Using cursor BC001534 */
            pr_default.execute(22, new Object[] {n261TituloId, A261TituloId});
            if ( (pr_default.getStatus(22) != 101) )
            {
               A273TituloTotalMovimento_F = BC001534_A273TituloTotalMovimento_F[0];
               n273TituloTotalMovimento_F = BC001534_n273TituloTotalMovimento_F[0];
            }
            else
            {
               A273TituloTotalMovimento_F = 0;
               n273TituloTotalMovimento_F = false;
            }
            pr_default.close(22);
            /* Using cursor BC001536 */
            pr_default.execute(23, new Object[] {n261TituloId, A261TituloId});
            if ( (pr_default.getStatus(23) != 101) )
            {
               A301TituloTotalMultaJuros_F = BC001536_A301TituloTotalMultaJuros_F[0];
               n301TituloTotalMultaJuros_F = BC001536_n301TituloTotalMultaJuros_F[0];
            }
            else
            {
               A301TituloTotalMultaJuros_F = 0;
               n301TituloTotalMultaJuros_F = false;
            }
            pr_default.close(23);
            /* Using cursor BC001538 */
            pr_default.execute(24, new Object[] {n261TituloId, A261TituloId});
            if ( (pr_default.getStatus(24) != 101) )
            {
               A1119TitulosCarteiraDeCobranca = BC001538_A1119TitulosCarteiraDeCobranca[0];
               n1119TitulosCarteiraDeCobranca = BC001538_n1119TitulosCarteiraDeCobranca[0];
            }
            else
            {
               A1119TitulosCarteiraDeCobranca = "";
               n1119TitulosCarteiraDeCobranca = false;
            }
            pr_default.close(24);
            A1118TitulosEmCarteiraDeCobranca_F = ((GetTitulosEmCarteiraDeCobranca_F0( A261TituloId)==0) ? false : true);
            /* Using cursor BC001539 */
            pr_default.execute(25, new Object[] {n420TituloClienteId, A420TituloClienteId});
            A972TituloCLienteRazaoSocial = BC001539_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = BC001539_n972TituloCLienteRazaoSocial[0];
            pr_default.close(25);
            A275TituloSaldo_F = (decimal)((A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F);
            A282TituloStatus_F = ((Convert.ToDecimal(0)==A275TituloSaldo_F) ? "Liquidado" : ((A275TituloSaldo_F==A262TituloValor) ? "Aberto" : "Baixado parcialmente"));
            A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
            A303TituloSaldoCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? (A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F : (decimal)(0));
            A302TituloSaldoDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? (A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F : (decimal)(0));
            A307TituloTotalMultaJurosCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? GetTituloTotalMultaJurosCredito_F0( A261TituloId) : (decimal)(0));
            A306TituloTotalMultaJurosDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? GetTituloTotalMultaJurosDebito_F0( A261TituloId) : (decimal)(0));
            A305TituloTotalMovimentoCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? GetTituloTotalMovimentoCredito_F0( A261TituloId) : (decimal)(0));
            A304TituloTotalMovimentoDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? GetTituloTotalMovimentoDebito_F0( A261TituloId) : (decimal)(0));
            /* Using cursor BC001540 */
            pr_default.execute(26, new Object[] {n419TituloPropostaId, A419TituloPropostaId});
            A971TituloPropostaDescricao = BC001540_A971TituloPropostaDescricao[0];
            n971TituloPropostaDescricao = BC001540_n971TituloPropostaDescricao[0];
            A501PropostaTaxaAdministrativa = BC001540_A501PropostaTaxaAdministrativa[0];
            n501PropostaTaxaAdministrativa = BC001540_n501PropostaTaxaAdministrativa[0];
            pr_default.close(26);
            /* Using cursor BC001541 */
            pr_default.execute(27, new Object[] {n890NotaFiscalParcelamentoID, A890NotaFiscalParcelamentoID});
            A794NotaFiscalId = BC001541_A794NotaFiscalId[0];
            n794NotaFiscalId = BC001541_n794NotaFiscalId[0];
            pr_default.close(27);
            /* Using cursor BC001542 */
            pr_default.execute(28, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
            A799NotaFiscalNumero = BC001542_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = BC001542_n799NotaFiscalNumero[0];
            pr_default.close(28);
            /* Using cursor BC001543 */
            pr_default.execute(29, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
            A938AgenciaId = BC001543_A938AgenciaId[0];
            n938AgenciaId = BC001543_n938AgenciaId[0];
            A953ContaBancariaCarteira = BC001543_A953ContaBancariaCarteira[0];
            n953ContaBancariaCarteira = BC001543_n953ContaBancariaCarteira[0];
            A952ContaBancariaNumero = BC001543_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = BC001543_n952ContaBancariaNumero[0];
            pr_default.close(29);
            /* Using cursor BC001544 */
            pr_default.execute(30, new Object[] {n938AgenciaId, A938AgenciaId});
            A968AgenciaBancoId = BC001544_A968AgenciaBancoId[0];
            n968AgenciaBancoId = BC001544_n968AgenciaBancoId[0];
            A939AgenciaNumero = BC001544_A939AgenciaNumero[0];
            n939AgenciaNumero = BC001544_n939AgenciaNumero[0];
            pr_default.close(30);
            /* Using cursor BC001545 */
            pr_default.execute(31, new Object[] {n968AgenciaBancoId, A968AgenciaBancoId});
            A969AgenciaBancoNome = BC001545_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = BC001545_n969AgenciaBancoNome[0];
            pr_default.close(31);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC001546 */
            pr_default.execute(32, new Object[] {n261TituloId, A261TituloId});
            if ( (pr_default.getStatus(32) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Boleto"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(32);
            /* Using cursor BC001547 */
            pr_default.execute(33, new Object[] {n261TituloId, A261TituloId});
            if ( (pr_default.getStatus(33) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"TituloMovimento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(33);
         }
      }

      protected void EndLevel1544( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1544( ) ;
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

      public void ScanKeyStart1544( )
      {
         /* Scan By routine */
         /* Using cursor BC001552 */
         pr_default.execute(34, new Object[] {n261TituloId, A261TituloId});
         RcdFound44 = 0;
         if ( (pr_default.getStatus(34) != 101) )
         {
            RcdFound44 = 1;
            A794NotaFiscalId = BC001552_A794NotaFiscalId[0];
            n794NotaFiscalId = BC001552_n794NotaFiscalId[0];
            A938AgenciaId = BC001552_A938AgenciaId[0];
            n938AgenciaId = BC001552_n938AgenciaId[0];
            A968AgenciaBancoId = BC001552_A968AgenciaBancoId[0];
            n968AgenciaBancoId = BC001552_n968AgenciaBancoId[0];
            A261TituloId = BC001552_A261TituloId[0];
            n261TituloId = BC001552_n261TituloId[0];
            A972TituloCLienteRazaoSocial = BC001552_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = BC001552_n972TituloCLienteRazaoSocial[0];
            A262TituloValor = BC001552_A262TituloValor[0];
            n262TituloValor = BC001552_n262TituloValor[0];
            A276TituloDesconto = BC001552_A276TituloDesconto[0];
            n276TituloDesconto = BC001552_n276TituloDesconto[0];
            A284TituloDeleted = BC001552_A284TituloDeleted[0];
            n284TituloDeleted = BC001552_n284TituloDeleted[0];
            A314TituloArchived = BC001552_A314TituloArchived[0];
            n314TituloArchived = BC001552_n314TituloArchived[0];
            A263TituloVencimento = BC001552_A263TituloVencimento[0];
            n263TituloVencimento = BC001552_n263TituloVencimento[0];
            A286TituloCompetenciaAno = BC001552_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = BC001552_n286TituloCompetenciaAno[0];
            A287TituloCompetenciaMes = BC001552_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = BC001552_n287TituloCompetenciaMes[0];
            A264TituloProrrogacao = BC001552_A264TituloProrrogacao[0];
            n264TituloProrrogacao = BC001552_n264TituloProrrogacao[0];
            A265TituloCEP = BC001552_A265TituloCEP[0];
            n265TituloCEP = BC001552_n265TituloCEP[0];
            A266TituloLogradouro = BC001552_A266TituloLogradouro[0];
            n266TituloLogradouro = BC001552_n266TituloLogradouro[0];
            A294TituloNumeroEndereco = BC001552_A294TituloNumeroEndereco[0];
            n294TituloNumeroEndereco = BC001552_n294TituloNumeroEndereco[0];
            A267TituloComplemento = BC001552_A267TituloComplemento[0];
            n267TituloComplemento = BC001552_n267TituloComplemento[0];
            A268TituloBairro = BC001552_A268TituloBairro[0];
            n268TituloBairro = BC001552_n268TituloBairro[0];
            A269TituloMunicipio = BC001552_A269TituloMunicipio[0];
            n269TituloMunicipio = BC001552_n269TituloMunicipio[0];
            A498TituloJurosMora = BC001552_A498TituloJurosMora[0];
            n498TituloJurosMora = BC001552_n498TituloJurosMora[0];
            A283TituloTipo = BC001552_A283TituloTipo[0];
            n283TituloTipo = BC001552_n283TituloTipo[0];
            A971TituloPropostaDescricao = BC001552_A971TituloPropostaDescricao[0];
            n971TituloPropostaDescricao = BC001552_n971TituloPropostaDescricao[0];
            A501PropostaTaxaAdministrativa = BC001552_A501PropostaTaxaAdministrativa[0];
            n501PropostaTaxaAdministrativa = BC001552_n501PropostaTaxaAdministrativa[0];
            A500TituloCriacao = BC001552_A500TituloCriacao[0];
            n500TituloCriacao = BC001552_n500TituloCriacao[0];
            A648TituloPropostaTipo = BC001552_A648TituloPropostaTipo[0];
            n648TituloPropostaTipo = BC001552_n648TituloPropostaTipo[0];
            A799NotaFiscalNumero = BC001552_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = BC001552_n799NotaFiscalNumero[0];
            A969AgenciaBancoNome = BC001552_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = BC001552_n969AgenciaBancoNome[0];
            A953ContaBancariaCarteira = BC001552_A953ContaBancariaCarteira[0];
            n953ContaBancariaCarteira = BC001552_n953ContaBancariaCarteira[0];
            A952ContaBancariaNumero = BC001552_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = BC001552_n952ContaBancariaNumero[0];
            A939AgenciaNumero = BC001552_A939AgenciaNumero[0];
            n939AgenciaNumero = BC001552_n939AgenciaNumero[0];
            A422ContaId = BC001552_A422ContaId[0];
            n422ContaId = BC001552_n422ContaId[0];
            A426CategoriaTituloId = BC001552_A426CategoriaTituloId[0];
            n426CategoriaTituloId = BC001552_n426CategoriaTituloId[0];
            A890NotaFiscalParcelamentoID = BC001552_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = BC001552_n890NotaFiscalParcelamentoID[0];
            A951ContaBancariaId = BC001552_A951ContaBancariaId[0];
            n951ContaBancariaId = BC001552_n951ContaBancariaId[0];
            A419TituloPropostaId = BC001552_A419TituloPropostaId[0];
            n419TituloPropostaId = BC001552_n419TituloPropostaId[0];
            A420TituloClienteId = BC001552_A420TituloClienteId[0];
            n420TituloClienteId = BC001552_n420TituloClienteId[0];
            A516TituloDataCredito_F = BC001552_A516TituloDataCredito_F[0];
            n516TituloDataCredito_F = BC001552_n516TituloDataCredito_F[0];
            A273TituloTotalMovimento_F = BC001552_A273TituloTotalMovimento_F[0];
            n273TituloTotalMovimento_F = BC001552_n273TituloTotalMovimento_F[0];
            A301TituloTotalMultaJuros_F = BC001552_A301TituloTotalMultaJuros_F[0];
            n301TituloTotalMultaJuros_F = BC001552_n301TituloTotalMultaJuros_F[0];
            A1119TitulosCarteiraDeCobranca = BC001552_A1119TitulosCarteiraDeCobranca[0];
            n1119TitulosCarteiraDeCobranca = BC001552_n1119TitulosCarteiraDeCobranca[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1544( )
      {
         /* Scan next routine */
         pr_default.readNext(34);
         RcdFound44 = 0;
         ScanKeyLoad1544( ) ;
      }

      protected void ScanKeyLoad1544( )
      {
         sMode44 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(34) != 101) )
         {
            RcdFound44 = 1;
            A794NotaFiscalId = BC001552_A794NotaFiscalId[0];
            n794NotaFiscalId = BC001552_n794NotaFiscalId[0];
            A938AgenciaId = BC001552_A938AgenciaId[0];
            n938AgenciaId = BC001552_n938AgenciaId[0];
            A968AgenciaBancoId = BC001552_A968AgenciaBancoId[0];
            n968AgenciaBancoId = BC001552_n968AgenciaBancoId[0];
            A261TituloId = BC001552_A261TituloId[0];
            n261TituloId = BC001552_n261TituloId[0];
            A972TituloCLienteRazaoSocial = BC001552_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = BC001552_n972TituloCLienteRazaoSocial[0];
            A262TituloValor = BC001552_A262TituloValor[0];
            n262TituloValor = BC001552_n262TituloValor[0];
            A276TituloDesconto = BC001552_A276TituloDesconto[0];
            n276TituloDesconto = BC001552_n276TituloDesconto[0];
            A284TituloDeleted = BC001552_A284TituloDeleted[0];
            n284TituloDeleted = BC001552_n284TituloDeleted[0];
            A314TituloArchived = BC001552_A314TituloArchived[0];
            n314TituloArchived = BC001552_n314TituloArchived[0];
            A263TituloVencimento = BC001552_A263TituloVencimento[0];
            n263TituloVencimento = BC001552_n263TituloVencimento[0];
            A286TituloCompetenciaAno = BC001552_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = BC001552_n286TituloCompetenciaAno[0];
            A287TituloCompetenciaMes = BC001552_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = BC001552_n287TituloCompetenciaMes[0];
            A264TituloProrrogacao = BC001552_A264TituloProrrogacao[0];
            n264TituloProrrogacao = BC001552_n264TituloProrrogacao[0];
            A265TituloCEP = BC001552_A265TituloCEP[0];
            n265TituloCEP = BC001552_n265TituloCEP[0];
            A266TituloLogradouro = BC001552_A266TituloLogradouro[0];
            n266TituloLogradouro = BC001552_n266TituloLogradouro[0];
            A294TituloNumeroEndereco = BC001552_A294TituloNumeroEndereco[0];
            n294TituloNumeroEndereco = BC001552_n294TituloNumeroEndereco[0];
            A267TituloComplemento = BC001552_A267TituloComplemento[0];
            n267TituloComplemento = BC001552_n267TituloComplemento[0];
            A268TituloBairro = BC001552_A268TituloBairro[0];
            n268TituloBairro = BC001552_n268TituloBairro[0];
            A269TituloMunicipio = BC001552_A269TituloMunicipio[0];
            n269TituloMunicipio = BC001552_n269TituloMunicipio[0];
            A498TituloJurosMora = BC001552_A498TituloJurosMora[0];
            n498TituloJurosMora = BC001552_n498TituloJurosMora[0];
            A283TituloTipo = BC001552_A283TituloTipo[0];
            n283TituloTipo = BC001552_n283TituloTipo[0];
            A971TituloPropostaDescricao = BC001552_A971TituloPropostaDescricao[0];
            n971TituloPropostaDescricao = BC001552_n971TituloPropostaDescricao[0];
            A501PropostaTaxaAdministrativa = BC001552_A501PropostaTaxaAdministrativa[0];
            n501PropostaTaxaAdministrativa = BC001552_n501PropostaTaxaAdministrativa[0];
            A500TituloCriacao = BC001552_A500TituloCriacao[0];
            n500TituloCriacao = BC001552_n500TituloCriacao[0];
            A648TituloPropostaTipo = BC001552_A648TituloPropostaTipo[0];
            n648TituloPropostaTipo = BC001552_n648TituloPropostaTipo[0];
            A799NotaFiscalNumero = BC001552_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = BC001552_n799NotaFiscalNumero[0];
            A969AgenciaBancoNome = BC001552_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = BC001552_n969AgenciaBancoNome[0];
            A953ContaBancariaCarteira = BC001552_A953ContaBancariaCarteira[0];
            n953ContaBancariaCarteira = BC001552_n953ContaBancariaCarteira[0];
            A952ContaBancariaNumero = BC001552_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = BC001552_n952ContaBancariaNumero[0];
            A939AgenciaNumero = BC001552_A939AgenciaNumero[0];
            n939AgenciaNumero = BC001552_n939AgenciaNumero[0];
            A422ContaId = BC001552_A422ContaId[0];
            n422ContaId = BC001552_n422ContaId[0];
            A426CategoriaTituloId = BC001552_A426CategoriaTituloId[0];
            n426CategoriaTituloId = BC001552_n426CategoriaTituloId[0];
            A890NotaFiscalParcelamentoID = BC001552_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = BC001552_n890NotaFiscalParcelamentoID[0];
            A951ContaBancariaId = BC001552_A951ContaBancariaId[0];
            n951ContaBancariaId = BC001552_n951ContaBancariaId[0];
            A419TituloPropostaId = BC001552_A419TituloPropostaId[0];
            n419TituloPropostaId = BC001552_n419TituloPropostaId[0];
            A420TituloClienteId = BC001552_A420TituloClienteId[0];
            n420TituloClienteId = BC001552_n420TituloClienteId[0];
            A516TituloDataCredito_F = BC001552_A516TituloDataCredito_F[0];
            n516TituloDataCredito_F = BC001552_n516TituloDataCredito_F[0];
            A273TituloTotalMovimento_F = BC001552_A273TituloTotalMovimento_F[0];
            n273TituloTotalMovimento_F = BC001552_n273TituloTotalMovimento_F[0];
            A301TituloTotalMultaJuros_F = BC001552_A301TituloTotalMultaJuros_F[0];
            n301TituloTotalMultaJuros_F = BC001552_n301TituloTotalMultaJuros_F[0];
            A1119TitulosCarteiraDeCobranca = BC001552_A1119TitulosCarteiraDeCobranca[0];
            n1119TitulosCarteiraDeCobranca = BC001552_n1119TitulosCarteiraDeCobranca[0];
         }
         Gx_mode = sMode44;
      }

      protected void ScanKeyEnd1544( )
      {
         pr_default.close(34);
      }

      protected void AfterConfirm1544( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1544( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1544( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1544( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1544( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1544( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1544( )
      {
      }

      protected void send_integrity_lvl_hashes1544( )
      {
      }

      protected void AddRow1544( )
      {
         VarsToRow44( bcTitulo) ;
      }

      protected void ReadRow1544( )
      {
         RowToVars44( bcTitulo, 1) ;
      }

      protected void InitializeNonKey1544( )
      {
         A968AgenciaBancoId = 0;
         n968AgenciaBancoId = false;
         A938AgenciaId = 0;
         n938AgenciaId = false;
         A794NotaFiscalId = Guid.Empty;
         n794NotaFiscalId = false;
         A304TituloTotalMovimentoDebito_F = 0;
         A305TituloTotalMovimentoCredito_F = 0;
         A306TituloTotalMultaJurosDebito_F = 0;
         A307TituloTotalMultaJurosCredito_F = 0;
         A295TituloCompetencia_F = "";
         A275TituloSaldo_F = 0;
         A282TituloStatus_F = "";
         A302TituloSaldoDebito_F = 0;
         A303TituloSaldoCredito_F = 0;
         A420TituloClienteId = 0;
         n420TituloClienteId = false;
         A972TituloCLienteRazaoSocial = "";
         n972TituloCLienteRazaoSocial = false;
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
         A971TituloPropostaDescricao = "";
         n971TituloPropostaDescricao = false;
         A501PropostaTaxaAdministrativa = 0;
         n501PropostaTaxaAdministrativa = false;
         A422ContaId = 0;
         n422ContaId = false;
         A426CategoriaTituloId = 0;
         n426CategoriaTituloId = false;
         A516TituloDataCredito_F = DateTime.MinValue;
         n516TituloDataCredito_F = false;
         A273TituloTotalMovimento_F = 0;
         n273TituloTotalMovimento_F = false;
         A301TituloTotalMultaJuros_F = 0;
         n301TituloTotalMultaJuros_F = false;
         A648TituloPropostaTipo = "";
         n648TituloPropostaTipo = false;
         A890NotaFiscalParcelamentoID = Guid.Empty;
         n890NotaFiscalParcelamentoID = false;
         A799NotaFiscalNumero = "";
         n799NotaFiscalNumero = false;
         A951ContaBancariaId = 0;
         n951ContaBancariaId = false;
         A969AgenciaBancoNome = "";
         n969AgenciaBancoNome = false;
         A953ContaBancariaCarteira = 0;
         n953ContaBancariaCarteira = false;
         A952ContaBancariaNumero = 0;
         n952ContaBancariaNumero = false;
         A939AgenciaNumero = 0;
         n939AgenciaNumero = false;
         A1118TitulosEmCarteiraDeCobranca_F = false;
         A1119TitulosCarteiraDeCobranca = "";
         n1119TitulosCarteiraDeCobranca = false;
         A284TituloDeleted = false;
         n284TituloDeleted = false;
         A500TituloCriacao = DateTimeUtil.ServerNow( context, pr_default);
         n500TituloCriacao = false;
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
         Z648TituloPropostaTipo = "";
         Z422ContaId = 0;
         Z426CategoriaTituloId = 0;
         Z890NotaFiscalParcelamentoID = Guid.Empty;
         Z951ContaBancariaId = 0;
         Z419TituloPropostaId = 0;
         Z420TituloClienteId = 0;
      }

      protected void InitAll1544( )
      {
         A261TituloId = 0;
         n261TituloId = false;
         InitializeNonKey1544( ) ;
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

      public void VarsToRow44( SdtTitulo obj44 )
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
         obj44.gxTpr_Tituloclienteid = A420TituloClienteId;
         obj44.gxTpr_Tituloclienterazaosocial = A972TituloCLienteRazaoSocial;
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
         obj44.gxTpr_Titulopropostadescricao = A971TituloPropostaDescricao;
         obj44.gxTpr_Propostataxaadministrativa = A501PropostaTaxaAdministrativa;
         obj44.gxTpr_Contaid = A422ContaId;
         obj44.gxTpr_Categoriatituloid = A426CategoriaTituloId;
         obj44.gxTpr_Titulodatacredito_f = A516TituloDataCredito_F;
         obj44.gxTpr_Titulototalmovimento_f = A273TituloTotalMovimento_F;
         obj44.gxTpr_Titulototalmultajuros_f = A301TituloTotalMultaJuros_F;
         obj44.gxTpr_Titulopropostatipo = A648TituloPropostaTipo;
         obj44.gxTpr_Notafiscalparcelamentoid = A890NotaFiscalParcelamentoID;
         obj44.gxTpr_Notafiscalnumero = A799NotaFiscalNumero;
         obj44.gxTpr_Contabancariaid = A951ContaBancariaId;
         obj44.gxTpr_Agenciabanconome = A969AgenciaBancoNome;
         obj44.gxTpr_Contabancariacarteira = A953ContaBancariaCarteira;
         obj44.gxTpr_Contabancarianumero = A952ContaBancariaNumero;
         obj44.gxTpr_Agencianumero = A939AgenciaNumero;
         obj44.gxTpr_Titulosemcarteiradecobranca_f = A1118TitulosEmCarteiraDeCobranca_F;
         obj44.gxTpr_Tituloscarteiradecobranca = A1119TitulosCarteiraDeCobranca;
         obj44.gxTpr_Titulodeleted = A284TituloDeleted;
         obj44.gxTpr_Titulocriacao = A500TituloCriacao;
         obj44.gxTpr_Tituloid = A261TituloId;
         obj44.gxTpr_Tituloid_Z = Z261TituloId;
         obj44.gxTpr_Tituloclienteid_Z = Z420TituloClienteId;
         obj44.gxTpr_Tituloclienterazaosocial_Z = Z972TituloCLienteRazaoSocial;
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
         obj44.gxTpr_Titulopropostadescricao_Z = Z971TituloPropostaDescricao;
         obj44.gxTpr_Propostataxaadministrativa_Z = Z501PropostaTaxaAdministrativa;
         obj44.gxTpr_Contaid_Z = Z422ContaId;
         obj44.gxTpr_Titulocriacao_Z = Z500TituloCriacao;
         obj44.gxTpr_Categoriatituloid_Z = Z426CategoriaTituloId;
         obj44.gxTpr_Titulodatacredito_f_Z = Z516TituloDataCredito_F;
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
         obj44.gxTpr_Titulopropostatipo_Z = Z648TituloPropostaTipo;
         obj44.gxTpr_Notafiscalparcelamentoid_Z = Z890NotaFiscalParcelamentoID;
         obj44.gxTpr_Notafiscalnumero_Z = Z799NotaFiscalNumero;
         obj44.gxTpr_Contabancariaid_Z = Z951ContaBancariaId;
         obj44.gxTpr_Agenciabanconome_Z = Z969AgenciaBancoNome;
         obj44.gxTpr_Contabancariacarteira_Z = Z953ContaBancariaCarteira;
         obj44.gxTpr_Contabancarianumero_Z = Z952ContaBancariaNumero;
         obj44.gxTpr_Agencianumero_Z = Z939AgenciaNumero;
         obj44.gxTpr_Titulosemcarteiradecobranca_f_Z = Z1118TitulosEmCarteiraDeCobranca_F;
         obj44.gxTpr_Tituloscarteiradecobranca_Z = Z1119TitulosCarteiraDeCobranca;
         obj44.gxTpr_Tituloid_N = (short)(Convert.ToInt16(n261TituloId));
         obj44.gxTpr_Tituloclienteid_N = (short)(Convert.ToInt16(n420TituloClienteId));
         obj44.gxTpr_Tituloclienterazaosocial_N = (short)(Convert.ToInt16(n972TituloCLienteRazaoSocial));
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
         obj44.gxTpr_Titulopropostadescricao_N = (short)(Convert.ToInt16(n971TituloPropostaDescricao));
         obj44.gxTpr_Propostataxaadministrativa_N = (short)(Convert.ToInt16(n501PropostaTaxaAdministrativa));
         obj44.gxTpr_Contaid_N = (short)(Convert.ToInt16(n422ContaId));
         obj44.gxTpr_Titulocriacao_N = (short)(Convert.ToInt16(n500TituloCriacao));
         obj44.gxTpr_Categoriatituloid_N = (short)(Convert.ToInt16(n426CategoriaTituloId));
         obj44.gxTpr_Titulodatacredito_f_N = (short)(Convert.ToInt16(n516TituloDataCredito_F));
         obj44.gxTpr_Titulototalmovimento_f_N = (short)(Convert.ToInt16(n273TituloTotalMovimento_F));
         obj44.gxTpr_Titulototalmultajuros_f_N = (short)(Convert.ToInt16(n301TituloTotalMultaJuros_F));
         obj44.gxTpr_Titulopropostatipo_N = (short)(Convert.ToInt16(n648TituloPropostaTipo));
         obj44.gxTpr_Notafiscalparcelamentoid_N = (short)(Convert.ToInt16(n890NotaFiscalParcelamentoID));
         obj44.gxTpr_Notafiscalnumero_N = (short)(Convert.ToInt16(n799NotaFiscalNumero));
         obj44.gxTpr_Contabancariaid_N = (short)(Convert.ToInt16(n951ContaBancariaId));
         obj44.gxTpr_Agenciabanconome_N = (short)(Convert.ToInt16(n969AgenciaBancoNome));
         obj44.gxTpr_Contabancariacarteira_N = (short)(Convert.ToInt16(n953ContaBancariaCarteira));
         obj44.gxTpr_Contabancarianumero_N = (short)(Convert.ToInt16(n952ContaBancariaNumero));
         obj44.gxTpr_Agencianumero_N = (short)(Convert.ToInt16(n939AgenciaNumero));
         obj44.gxTpr_Tituloscarteiradecobranca_N = (short)(Convert.ToInt16(n1119TitulosCarteiraDeCobranca));
         obj44.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow44( SdtTitulo obj44 )
      {
         obj44.gxTpr_Tituloid = A261TituloId;
         return  ;
      }

      public void RowToVars44( SdtTitulo obj44 ,
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
         A420TituloClienteId = obj44.gxTpr_Tituloclienteid;
         n420TituloClienteId = false;
         A972TituloCLienteRazaoSocial = obj44.gxTpr_Tituloclienterazaosocial;
         n972TituloCLienteRazaoSocial = false;
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
         A971TituloPropostaDescricao = obj44.gxTpr_Titulopropostadescricao;
         n971TituloPropostaDescricao = false;
         A501PropostaTaxaAdministrativa = obj44.gxTpr_Propostataxaadministrativa;
         n501PropostaTaxaAdministrativa = false;
         A422ContaId = obj44.gxTpr_Contaid;
         n422ContaId = false;
         A426CategoriaTituloId = obj44.gxTpr_Categoriatituloid;
         n426CategoriaTituloId = false;
         A516TituloDataCredito_F = obj44.gxTpr_Titulodatacredito_f;
         n516TituloDataCredito_F = false;
         A273TituloTotalMovimento_F = obj44.gxTpr_Titulototalmovimento_f;
         n273TituloTotalMovimento_F = false;
         A301TituloTotalMultaJuros_F = obj44.gxTpr_Titulototalmultajuros_f;
         n301TituloTotalMultaJuros_F = false;
         A648TituloPropostaTipo = obj44.gxTpr_Titulopropostatipo;
         n648TituloPropostaTipo = false;
         A890NotaFiscalParcelamentoID = obj44.gxTpr_Notafiscalparcelamentoid;
         n890NotaFiscalParcelamentoID = false;
         A799NotaFiscalNumero = obj44.gxTpr_Notafiscalnumero;
         n799NotaFiscalNumero = false;
         A951ContaBancariaId = obj44.gxTpr_Contabancariaid;
         n951ContaBancariaId = false;
         A969AgenciaBancoNome = obj44.gxTpr_Agenciabanconome;
         n969AgenciaBancoNome = false;
         A953ContaBancariaCarteira = obj44.gxTpr_Contabancariacarteira;
         n953ContaBancariaCarteira = false;
         A952ContaBancariaNumero = obj44.gxTpr_Contabancarianumero;
         n952ContaBancariaNumero = false;
         A939AgenciaNumero = obj44.gxTpr_Agencianumero;
         n939AgenciaNumero = false;
         A1118TitulosEmCarteiraDeCobranca_F = obj44.gxTpr_Titulosemcarteiradecobranca_f;
         A1119TitulosCarteiraDeCobranca = obj44.gxTpr_Tituloscarteiradecobranca;
         n1119TitulosCarteiraDeCobranca = false;
         A284TituloDeleted = obj44.gxTpr_Titulodeleted;
         n284TituloDeleted = false;
         A500TituloCriacao = obj44.gxTpr_Titulocriacao;
         n500TituloCriacao = false;
         A261TituloId = obj44.gxTpr_Tituloid;
         n261TituloId = false;
         Z261TituloId = obj44.gxTpr_Tituloid_Z;
         Z420TituloClienteId = obj44.gxTpr_Tituloclienteid_Z;
         Z972TituloCLienteRazaoSocial = obj44.gxTpr_Tituloclienterazaosocial_Z;
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
         Z971TituloPropostaDescricao = obj44.gxTpr_Titulopropostadescricao_Z;
         Z501PropostaTaxaAdministrativa = obj44.gxTpr_Propostataxaadministrativa_Z;
         Z422ContaId = obj44.gxTpr_Contaid_Z;
         Z500TituloCriacao = obj44.gxTpr_Titulocriacao_Z;
         Z426CategoriaTituloId = obj44.gxTpr_Categoriatituloid_Z;
         Z516TituloDataCredito_F = obj44.gxTpr_Titulodatacredito_f_Z;
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
         Z648TituloPropostaTipo = obj44.gxTpr_Titulopropostatipo_Z;
         Z890NotaFiscalParcelamentoID = obj44.gxTpr_Notafiscalparcelamentoid_Z;
         Z799NotaFiscalNumero = obj44.gxTpr_Notafiscalnumero_Z;
         Z951ContaBancariaId = obj44.gxTpr_Contabancariaid_Z;
         Z969AgenciaBancoNome = obj44.gxTpr_Agenciabanconome_Z;
         Z953ContaBancariaCarteira = obj44.gxTpr_Contabancariacarteira_Z;
         Z952ContaBancariaNumero = obj44.gxTpr_Contabancarianumero_Z;
         Z939AgenciaNumero = obj44.gxTpr_Agencianumero_Z;
         Z1118TitulosEmCarteiraDeCobranca_F = obj44.gxTpr_Titulosemcarteiradecobranca_f_Z;
         Z1119TitulosCarteiraDeCobranca = obj44.gxTpr_Tituloscarteiradecobranca_Z;
         n261TituloId = (bool)(Convert.ToBoolean(obj44.gxTpr_Tituloid_N));
         n420TituloClienteId = (bool)(Convert.ToBoolean(obj44.gxTpr_Tituloclienteid_N));
         n972TituloCLienteRazaoSocial = (bool)(Convert.ToBoolean(obj44.gxTpr_Tituloclienterazaosocial_N));
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
         n971TituloPropostaDescricao = (bool)(Convert.ToBoolean(obj44.gxTpr_Titulopropostadescricao_N));
         n501PropostaTaxaAdministrativa = (bool)(Convert.ToBoolean(obj44.gxTpr_Propostataxaadministrativa_N));
         n422ContaId = (bool)(Convert.ToBoolean(obj44.gxTpr_Contaid_N));
         n500TituloCriacao = (bool)(Convert.ToBoolean(obj44.gxTpr_Titulocriacao_N));
         n426CategoriaTituloId = (bool)(Convert.ToBoolean(obj44.gxTpr_Categoriatituloid_N));
         n516TituloDataCredito_F = (bool)(Convert.ToBoolean(obj44.gxTpr_Titulodatacredito_f_N));
         n273TituloTotalMovimento_F = (bool)(Convert.ToBoolean(obj44.gxTpr_Titulototalmovimento_f_N));
         n301TituloTotalMultaJuros_F = (bool)(Convert.ToBoolean(obj44.gxTpr_Titulototalmultajuros_f_N));
         n648TituloPropostaTipo = (bool)(Convert.ToBoolean(obj44.gxTpr_Titulopropostatipo_N));
         n890NotaFiscalParcelamentoID = (bool)(Convert.ToBoolean(obj44.gxTpr_Notafiscalparcelamentoid_N));
         n799NotaFiscalNumero = (bool)(Convert.ToBoolean(obj44.gxTpr_Notafiscalnumero_N));
         n951ContaBancariaId = (bool)(Convert.ToBoolean(obj44.gxTpr_Contabancariaid_N));
         n969AgenciaBancoNome = (bool)(Convert.ToBoolean(obj44.gxTpr_Agenciabanconome_N));
         n953ContaBancariaCarteira = (bool)(Convert.ToBoolean(obj44.gxTpr_Contabancariacarteira_N));
         n952ContaBancariaNumero = (bool)(Convert.ToBoolean(obj44.gxTpr_Contabancarianumero_N));
         n939AgenciaNumero = (bool)(Convert.ToBoolean(obj44.gxTpr_Agencianumero_N));
         n1119TitulosCarteiraDeCobranca = (bool)(Convert.ToBoolean(obj44.gxTpr_Tituloscarteiradecobranca_N));
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
         InitializeNonKey1544( ) ;
         ScanKeyStart1544( ) ;
         if ( RcdFound44 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z261TituloId = A261TituloId;
         }
         ZM1544( -24) ;
         OnLoadActions1544( ) ;
         AddRow1544( ) ;
         ScanKeyEnd1544( ) ;
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
         RowToVars44( bcTitulo, 0) ;
         ScanKeyStart1544( ) ;
         if ( RcdFound44 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z261TituloId = A261TituloId;
         }
         ZM1544( -24) ;
         OnLoadActions1544( ) ;
         AddRow1544( ) ;
         ScanKeyEnd1544( ) ;
         if ( RcdFound44 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1544( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1544( ) ;
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
                  Update1544( ) ;
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
                        Insert1544( ) ;
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
                        Insert1544( ) ;
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
         RowToVars44( bcTitulo, 1) ;
         SaveImpl( ) ;
         VarsToRow44( bcTitulo) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars44( bcTitulo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1544( ) ;
         AfterTrn( ) ;
         VarsToRow44( bcTitulo) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow44( bcTitulo) ;
         }
         else
         {
            SdtTitulo auxBC = new SdtTitulo(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A261TituloId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTitulo);
               auxBC.Save();
               bcTitulo.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars44( bcTitulo, 1) ;
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
         RowToVars44( bcTitulo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1544( ) ;
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
               VarsToRow44( bcTitulo) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow44( bcTitulo) ;
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
         RowToVars44( bcTitulo, 0) ;
         GetKey1544( ) ;
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
         context.RollbackDataStores("titulo_bc",pr_default);
         VarsToRow44( bcTitulo) ;
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
         Gx_mode = bcTitulo.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTitulo.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTitulo )
         {
            bcTitulo = (SdtTitulo)(sdt);
            if ( StringUtil.StrCmp(bcTitulo.gxTpr_Mode, "") == 0 )
            {
               bcTitulo.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow44( bcTitulo) ;
            }
            else
            {
               RowToVars44( bcTitulo, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTitulo.gxTpr_Mode, "") == 0 )
            {
               bcTitulo.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars44( bcTitulo, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTitulo Titulo_BC
      {
         get {
            return bcTitulo ;
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
         /* Using cursor BC001553 */
         pr_default.execute(35, new Object[] {nA261TituloId, E261TituloId});
         if ( (pr_default.getStatus(35) != 101) )
         {
            X271TituloMovimentoValor = BC001553_A271TituloMovimentoValor[0];
            nX271TituloMovimentoValor = BC001553_n271TituloMovimentoValor[0];
         }
         pr_default.close(35);
         return X271TituloMovimentoValor ;
      }

      protected decimal GetTituloTotalMovimentoCredito_F0( int E261TituloId )
      {
         X271TituloMovimentoValor = 0;
         /* Using cursor BC001554 */
         pr_default.execute(36, new Object[] {nE261TituloId, E261TituloId});
         if ( (pr_default.getStatus(36) != 101) )
         {
            X271TituloMovimentoValor = BC001554_A271TituloMovimentoValor[0];
            nX271TituloMovimentoValor = BC001554_n271TituloMovimentoValor[0];
         }
         pr_default.close(36);
         return X271TituloMovimentoValor ;
      }

      protected decimal GetTituloTotalMultaJurosDebito_F0( int E261TituloId )
      {
         X271TituloMovimentoValor = 0;
         /* Using cursor BC001555 */
         pr_default.execute(37, new Object[] {nE261TituloId, E261TituloId});
         if ( (pr_default.getStatus(37) != 101) )
         {
            X271TituloMovimentoValor = BC001555_A271TituloMovimentoValor[0];
            nX271TituloMovimentoValor = BC001555_n271TituloMovimentoValor[0];
         }
         pr_default.close(37);
         return X271TituloMovimentoValor ;
      }

      protected decimal GetTituloTotalMultaJurosCredito_F0( int E261TituloId )
      {
         X271TituloMovimentoValor = 0;
         /* Using cursor BC001556 */
         pr_default.execute(38, new Object[] {nE261TituloId, E261TituloId});
         if ( (pr_default.getStatus(38) != 101) )
         {
            X271TituloMovimentoValor = BC001556_A271TituloMovimentoValor[0];
            nX271TituloMovimentoValor = BC001556_n271TituloMovimentoValor[0];
         }
         pr_default.close(38);
         return X271TituloMovimentoValor ;
      }

      protected int GetTitulosEmCarteiraDeCobranca_F0( int E261TituloId )
      {
         Gx_cnt = 0;
         /* Using cursor BC001557 */
         pr_default.execute(39, new Object[] {nE261TituloId, E261TituloId});
         if ( (pr_default.getStatus(39) != 101) )
         {
            Gx_cnt = BC001557_Gx_cnt[0];
         }
         pr_default.close(39);
         return Gx_cnt ;
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
         pr_default.close(27);
         pr_default.close(29);
         pr_default.close(26);
         pr_default.close(25);
         pr_default.close(28);
         pr_default.close(30);
         pr_default.close(31);
         pr_default.close(21);
         pr_default.close(22);
         pr_default.close(23);
         pr_default.close(24);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV27Pgmname = "";
         AV12TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV23Insert_NotaFiscalParcelamentoID = Guid.Empty;
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
         Z648TituloPropostaTipo = "";
         A648TituloPropostaTipo = "";
         Z890NotaFiscalParcelamentoID = Guid.Empty;
         A890NotaFiscalParcelamentoID = Guid.Empty;
         Z295TituloCompetencia_F = "";
         A295TituloCompetencia_F = "";
         Z516TituloDataCredito_F = DateTime.MinValue;
         A516TituloDataCredito_F = DateTime.MinValue;
         Z282TituloStatus_F = "";
         A282TituloStatus_F = "";
         Z1119TitulosCarteiraDeCobranca = "";
         A1119TitulosCarteiraDeCobranca = "";
         Z794NotaFiscalId = Guid.Empty;
         A794NotaFiscalId = Guid.Empty;
         Z971TituloPropostaDescricao = "";
         A971TituloPropostaDescricao = "";
         Z972TituloCLienteRazaoSocial = "";
         A972TituloCLienteRazaoSocial = "";
         Z799NotaFiscalNumero = "";
         A799NotaFiscalNumero = "";
         Z969AgenciaBancoNome = "";
         A969AgenciaBancoNome = "";
         BC001525_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         BC001525_n794NotaFiscalId = new bool[] {false} ;
         BC001525_A938AgenciaId = new int[1] ;
         BC001525_n938AgenciaId = new bool[] {false} ;
         BC001525_A968AgenciaBancoId = new int[1] ;
         BC001525_n968AgenciaBancoId = new bool[] {false} ;
         BC001525_A261TituloId = new int[1] ;
         BC001525_n261TituloId = new bool[] {false} ;
         BC001525_A972TituloCLienteRazaoSocial = new string[] {""} ;
         BC001525_n972TituloCLienteRazaoSocial = new bool[] {false} ;
         BC001525_A262TituloValor = new decimal[1] ;
         BC001525_n262TituloValor = new bool[] {false} ;
         BC001525_A276TituloDesconto = new decimal[1] ;
         BC001525_n276TituloDesconto = new bool[] {false} ;
         BC001525_A284TituloDeleted = new bool[] {false} ;
         BC001525_n284TituloDeleted = new bool[] {false} ;
         BC001525_A314TituloArchived = new bool[] {false} ;
         BC001525_n314TituloArchived = new bool[] {false} ;
         BC001525_A263TituloVencimento = new DateTime[] {DateTime.MinValue} ;
         BC001525_n263TituloVencimento = new bool[] {false} ;
         BC001525_A286TituloCompetenciaAno = new short[1] ;
         BC001525_n286TituloCompetenciaAno = new bool[] {false} ;
         BC001525_A287TituloCompetenciaMes = new short[1] ;
         BC001525_n287TituloCompetenciaMes = new bool[] {false} ;
         BC001525_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         BC001525_n264TituloProrrogacao = new bool[] {false} ;
         BC001525_A265TituloCEP = new string[] {""} ;
         BC001525_n265TituloCEP = new bool[] {false} ;
         BC001525_A266TituloLogradouro = new string[] {""} ;
         BC001525_n266TituloLogradouro = new bool[] {false} ;
         BC001525_A294TituloNumeroEndereco = new string[] {""} ;
         BC001525_n294TituloNumeroEndereco = new bool[] {false} ;
         BC001525_A267TituloComplemento = new string[] {""} ;
         BC001525_n267TituloComplemento = new bool[] {false} ;
         BC001525_A268TituloBairro = new string[] {""} ;
         BC001525_n268TituloBairro = new bool[] {false} ;
         BC001525_A269TituloMunicipio = new string[] {""} ;
         BC001525_n269TituloMunicipio = new bool[] {false} ;
         BC001525_A498TituloJurosMora = new decimal[1] ;
         BC001525_n498TituloJurosMora = new bool[] {false} ;
         BC001525_A283TituloTipo = new string[] {""} ;
         BC001525_n283TituloTipo = new bool[] {false} ;
         BC001525_A971TituloPropostaDescricao = new string[] {""} ;
         BC001525_n971TituloPropostaDescricao = new bool[] {false} ;
         BC001525_A501PropostaTaxaAdministrativa = new decimal[1] ;
         BC001525_n501PropostaTaxaAdministrativa = new bool[] {false} ;
         BC001525_A500TituloCriacao = new DateTime[] {DateTime.MinValue} ;
         BC001525_n500TituloCriacao = new bool[] {false} ;
         BC001525_A648TituloPropostaTipo = new string[] {""} ;
         BC001525_n648TituloPropostaTipo = new bool[] {false} ;
         BC001525_A799NotaFiscalNumero = new string[] {""} ;
         BC001525_n799NotaFiscalNumero = new bool[] {false} ;
         BC001525_A969AgenciaBancoNome = new string[] {""} ;
         BC001525_n969AgenciaBancoNome = new bool[] {false} ;
         BC001525_A953ContaBancariaCarteira = new long[1] ;
         BC001525_n953ContaBancariaCarteira = new bool[] {false} ;
         BC001525_A952ContaBancariaNumero = new long[1] ;
         BC001525_n952ContaBancariaNumero = new bool[] {false} ;
         BC001525_A939AgenciaNumero = new int[1] ;
         BC001525_n939AgenciaNumero = new bool[] {false} ;
         BC001525_A422ContaId = new int[1] ;
         BC001525_n422ContaId = new bool[] {false} ;
         BC001525_A426CategoriaTituloId = new int[1] ;
         BC001525_n426CategoriaTituloId = new bool[] {false} ;
         BC001525_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         BC001525_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         BC001525_A951ContaBancariaId = new int[1] ;
         BC001525_n951ContaBancariaId = new bool[] {false} ;
         BC001525_A419TituloPropostaId = new int[1] ;
         BC001525_n419TituloPropostaId = new bool[] {false} ;
         BC001525_A420TituloClienteId = new int[1] ;
         BC001525_n420TituloClienteId = new bool[] {false} ;
         BC001525_A516TituloDataCredito_F = new DateTime[] {DateTime.MinValue} ;
         BC001525_n516TituloDataCredito_F = new bool[] {false} ;
         BC001525_A273TituloTotalMovimento_F = new decimal[1] ;
         BC001525_n273TituloTotalMovimento_F = new bool[] {false} ;
         BC001525_A301TituloTotalMultaJuros_F = new decimal[1] ;
         BC001525_n301TituloTotalMultaJuros_F = new bool[] {false} ;
         BC001525_A1119TitulosCarteiraDeCobranca = new string[] {""} ;
         BC001525_n1119TitulosCarteiraDeCobranca = new bool[] {false} ;
         BC001514_A516TituloDataCredito_F = new DateTime[] {DateTime.MinValue} ;
         BC001514_n516TituloDataCredito_F = new bool[] {false} ;
         BC001516_A273TituloTotalMovimento_F = new decimal[1] ;
         BC001516_n273TituloTotalMovimento_F = new bool[] {false} ;
         BC001518_A301TituloTotalMultaJuros_F = new decimal[1] ;
         BC001518_n301TituloTotalMultaJuros_F = new bool[] {false} ;
         BC001520_A1119TitulosCarteiraDeCobranca = new string[] {""} ;
         BC001520_n1119TitulosCarteiraDeCobranca = new bool[] {false} ;
         BC00159_A972TituloCLienteRazaoSocial = new string[] {""} ;
         BC00159_n972TituloCLienteRazaoSocial = new bool[] {false} ;
         BC00158_A971TituloPropostaDescricao = new string[] {""} ;
         BC00158_n971TituloPropostaDescricao = new bool[] {false} ;
         BC00158_A501PropostaTaxaAdministrativa = new decimal[1] ;
         BC00158_n501PropostaTaxaAdministrativa = new bool[] {false} ;
         BC00154_A422ContaId = new int[1] ;
         BC00154_n422ContaId = new bool[] {false} ;
         BC00155_A426CategoriaTituloId = new int[1] ;
         BC00155_n426CategoriaTituloId = new bool[] {false} ;
         BC00156_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         BC00156_n794NotaFiscalId = new bool[] {false} ;
         BC001510_A799NotaFiscalNumero = new string[] {""} ;
         BC001510_n799NotaFiscalNumero = new bool[] {false} ;
         BC00157_A938AgenciaId = new int[1] ;
         BC00157_n938AgenciaId = new bool[] {false} ;
         BC00157_A953ContaBancariaCarteira = new long[1] ;
         BC00157_n953ContaBancariaCarteira = new bool[] {false} ;
         BC00157_A952ContaBancariaNumero = new long[1] ;
         BC00157_n952ContaBancariaNumero = new bool[] {false} ;
         BC001511_A968AgenciaBancoId = new int[1] ;
         BC001511_n968AgenciaBancoId = new bool[] {false} ;
         BC001511_A939AgenciaNumero = new int[1] ;
         BC001511_n939AgenciaNumero = new bool[] {false} ;
         BC001512_A969AgenciaBancoNome = new string[] {""} ;
         BC001512_n969AgenciaBancoNome = new bool[] {false} ;
         BC001526_A261TituloId = new int[1] ;
         BC001526_n261TituloId = new bool[] {false} ;
         BC00153_A261TituloId = new int[1] ;
         BC00153_n261TituloId = new bool[] {false} ;
         BC00153_A262TituloValor = new decimal[1] ;
         BC00153_n262TituloValor = new bool[] {false} ;
         BC00153_A276TituloDesconto = new decimal[1] ;
         BC00153_n276TituloDesconto = new bool[] {false} ;
         BC00153_A284TituloDeleted = new bool[] {false} ;
         BC00153_n284TituloDeleted = new bool[] {false} ;
         BC00153_A314TituloArchived = new bool[] {false} ;
         BC00153_n314TituloArchived = new bool[] {false} ;
         BC00153_A263TituloVencimento = new DateTime[] {DateTime.MinValue} ;
         BC00153_n263TituloVencimento = new bool[] {false} ;
         BC00153_A286TituloCompetenciaAno = new short[1] ;
         BC00153_n286TituloCompetenciaAno = new bool[] {false} ;
         BC00153_A287TituloCompetenciaMes = new short[1] ;
         BC00153_n287TituloCompetenciaMes = new bool[] {false} ;
         BC00153_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         BC00153_n264TituloProrrogacao = new bool[] {false} ;
         BC00153_A265TituloCEP = new string[] {""} ;
         BC00153_n265TituloCEP = new bool[] {false} ;
         BC00153_A266TituloLogradouro = new string[] {""} ;
         BC00153_n266TituloLogradouro = new bool[] {false} ;
         BC00153_A294TituloNumeroEndereco = new string[] {""} ;
         BC00153_n294TituloNumeroEndereco = new bool[] {false} ;
         BC00153_A267TituloComplemento = new string[] {""} ;
         BC00153_n267TituloComplemento = new bool[] {false} ;
         BC00153_A268TituloBairro = new string[] {""} ;
         BC00153_n268TituloBairro = new bool[] {false} ;
         BC00153_A269TituloMunicipio = new string[] {""} ;
         BC00153_n269TituloMunicipio = new bool[] {false} ;
         BC00153_A498TituloJurosMora = new decimal[1] ;
         BC00153_n498TituloJurosMora = new bool[] {false} ;
         BC00153_A283TituloTipo = new string[] {""} ;
         BC00153_n283TituloTipo = new bool[] {false} ;
         BC00153_A500TituloCriacao = new DateTime[] {DateTime.MinValue} ;
         BC00153_n500TituloCriacao = new bool[] {false} ;
         BC00153_A648TituloPropostaTipo = new string[] {""} ;
         BC00153_n648TituloPropostaTipo = new bool[] {false} ;
         BC00153_A422ContaId = new int[1] ;
         BC00153_n422ContaId = new bool[] {false} ;
         BC00153_A426CategoriaTituloId = new int[1] ;
         BC00153_n426CategoriaTituloId = new bool[] {false} ;
         BC00153_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         BC00153_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         BC00153_A951ContaBancariaId = new int[1] ;
         BC00153_n951ContaBancariaId = new bool[] {false} ;
         BC00153_A419TituloPropostaId = new int[1] ;
         BC00153_n419TituloPropostaId = new bool[] {false} ;
         BC00153_A420TituloClienteId = new int[1] ;
         BC00153_n420TituloClienteId = new bool[] {false} ;
         sMode44 = "";
         BC00152_A261TituloId = new int[1] ;
         BC00152_n261TituloId = new bool[] {false} ;
         BC00152_A262TituloValor = new decimal[1] ;
         BC00152_n262TituloValor = new bool[] {false} ;
         BC00152_A276TituloDesconto = new decimal[1] ;
         BC00152_n276TituloDesconto = new bool[] {false} ;
         BC00152_A284TituloDeleted = new bool[] {false} ;
         BC00152_n284TituloDeleted = new bool[] {false} ;
         BC00152_A314TituloArchived = new bool[] {false} ;
         BC00152_n314TituloArchived = new bool[] {false} ;
         BC00152_A263TituloVencimento = new DateTime[] {DateTime.MinValue} ;
         BC00152_n263TituloVencimento = new bool[] {false} ;
         BC00152_A286TituloCompetenciaAno = new short[1] ;
         BC00152_n286TituloCompetenciaAno = new bool[] {false} ;
         BC00152_A287TituloCompetenciaMes = new short[1] ;
         BC00152_n287TituloCompetenciaMes = new bool[] {false} ;
         BC00152_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         BC00152_n264TituloProrrogacao = new bool[] {false} ;
         BC00152_A265TituloCEP = new string[] {""} ;
         BC00152_n265TituloCEP = new bool[] {false} ;
         BC00152_A266TituloLogradouro = new string[] {""} ;
         BC00152_n266TituloLogradouro = new bool[] {false} ;
         BC00152_A294TituloNumeroEndereco = new string[] {""} ;
         BC00152_n294TituloNumeroEndereco = new bool[] {false} ;
         BC00152_A267TituloComplemento = new string[] {""} ;
         BC00152_n267TituloComplemento = new bool[] {false} ;
         BC00152_A268TituloBairro = new string[] {""} ;
         BC00152_n268TituloBairro = new bool[] {false} ;
         BC00152_A269TituloMunicipio = new string[] {""} ;
         BC00152_n269TituloMunicipio = new bool[] {false} ;
         BC00152_A498TituloJurosMora = new decimal[1] ;
         BC00152_n498TituloJurosMora = new bool[] {false} ;
         BC00152_A283TituloTipo = new string[] {""} ;
         BC00152_n283TituloTipo = new bool[] {false} ;
         BC00152_A500TituloCriacao = new DateTime[] {DateTime.MinValue} ;
         BC00152_n500TituloCriacao = new bool[] {false} ;
         BC00152_A648TituloPropostaTipo = new string[] {""} ;
         BC00152_n648TituloPropostaTipo = new bool[] {false} ;
         BC00152_A422ContaId = new int[1] ;
         BC00152_n422ContaId = new bool[] {false} ;
         BC00152_A426CategoriaTituloId = new int[1] ;
         BC00152_n426CategoriaTituloId = new bool[] {false} ;
         BC00152_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         BC00152_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         BC00152_A951ContaBancariaId = new int[1] ;
         BC00152_n951ContaBancariaId = new bool[] {false} ;
         BC00152_A419TituloPropostaId = new int[1] ;
         BC00152_n419TituloPropostaId = new bool[] {false} ;
         BC00152_A420TituloClienteId = new int[1] ;
         BC00152_n420TituloClienteId = new bool[] {false} ;
         BC001528_A261TituloId = new int[1] ;
         BC001528_n261TituloId = new bool[] {false} ;
         BC001532_A516TituloDataCredito_F = new DateTime[] {DateTime.MinValue} ;
         BC001532_n516TituloDataCredito_F = new bool[] {false} ;
         BC001534_A273TituloTotalMovimento_F = new decimal[1] ;
         BC001534_n273TituloTotalMovimento_F = new bool[] {false} ;
         BC001536_A301TituloTotalMultaJuros_F = new decimal[1] ;
         BC001536_n301TituloTotalMultaJuros_F = new bool[] {false} ;
         BC001538_A1119TitulosCarteiraDeCobranca = new string[] {""} ;
         BC001538_n1119TitulosCarteiraDeCobranca = new bool[] {false} ;
         BC001539_A972TituloCLienteRazaoSocial = new string[] {""} ;
         BC001539_n972TituloCLienteRazaoSocial = new bool[] {false} ;
         BC001540_A971TituloPropostaDescricao = new string[] {""} ;
         BC001540_n971TituloPropostaDescricao = new bool[] {false} ;
         BC001540_A501PropostaTaxaAdministrativa = new decimal[1] ;
         BC001540_n501PropostaTaxaAdministrativa = new bool[] {false} ;
         BC001541_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         BC001541_n794NotaFiscalId = new bool[] {false} ;
         BC001542_A799NotaFiscalNumero = new string[] {""} ;
         BC001542_n799NotaFiscalNumero = new bool[] {false} ;
         BC001543_A938AgenciaId = new int[1] ;
         BC001543_n938AgenciaId = new bool[] {false} ;
         BC001543_A953ContaBancariaCarteira = new long[1] ;
         BC001543_n953ContaBancariaCarteira = new bool[] {false} ;
         BC001543_A952ContaBancariaNumero = new long[1] ;
         BC001543_n952ContaBancariaNumero = new bool[] {false} ;
         BC001544_A968AgenciaBancoId = new int[1] ;
         BC001544_n968AgenciaBancoId = new bool[] {false} ;
         BC001544_A939AgenciaNumero = new int[1] ;
         BC001544_n939AgenciaNumero = new bool[] {false} ;
         BC001545_A969AgenciaBancoNome = new string[] {""} ;
         BC001545_n969AgenciaBancoNome = new bool[] {false} ;
         BC001546_A1077BoletosId = new int[1] ;
         BC001547_A270TituloMovimentoId = new int[1] ;
         BC001552_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         BC001552_n794NotaFiscalId = new bool[] {false} ;
         BC001552_A938AgenciaId = new int[1] ;
         BC001552_n938AgenciaId = new bool[] {false} ;
         BC001552_A968AgenciaBancoId = new int[1] ;
         BC001552_n968AgenciaBancoId = new bool[] {false} ;
         BC001552_A261TituloId = new int[1] ;
         BC001552_n261TituloId = new bool[] {false} ;
         BC001552_A972TituloCLienteRazaoSocial = new string[] {""} ;
         BC001552_n972TituloCLienteRazaoSocial = new bool[] {false} ;
         BC001552_A262TituloValor = new decimal[1] ;
         BC001552_n262TituloValor = new bool[] {false} ;
         BC001552_A276TituloDesconto = new decimal[1] ;
         BC001552_n276TituloDesconto = new bool[] {false} ;
         BC001552_A284TituloDeleted = new bool[] {false} ;
         BC001552_n284TituloDeleted = new bool[] {false} ;
         BC001552_A314TituloArchived = new bool[] {false} ;
         BC001552_n314TituloArchived = new bool[] {false} ;
         BC001552_A263TituloVencimento = new DateTime[] {DateTime.MinValue} ;
         BC001552_n263TituloVencimento = new bool[] {false} ;
         BC001552_A286TituloCompetenciaAno = new short[1] ;
         BC001552_n286TituloCompetenciaAno = new bool[] {false} ;
         BC001552_A287TituloCompetenciaMes = new short[1] ;
         BC001552_n287TituloCompetenciaMes = new bool[] {false} ;
         BC001552_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         BC001552_n264TituloProrrogacao = new bool[] {false} ;
         BC001552_A265TituloCEP = new string[] {""} ;
         BC001552_n265TituloCEP = new bool[] {false} ;
         BC001552_A266TituloLogradouro = new string[] {""} ;
         BC001552_n266TituloLogradouro = new bool[] {false} ;
         BC001552_A294TituloNumeroEndereco = new string[] {""} ;
         BC001552_n294TituloNumeroEndereco = new bool[] {false} ;
         BC001552_A267TituloComplemento = new string[] {""} ;
         BC001552_n267TituloComplemento = new bool[] {false} ;
         BC001552_A268TituloBairro = new string[] {""} ;
         BC001552_n268TituloBairro = new bool[] {false} ;
         BC001552_A269TituloMunicipio = new string[] {""} ;
         BC001552_n269TituloMunicipio = new bool[] {false} ;
         BC001552_A498TituloJurosMora = new decimal[1] ;
         BC001552_n498TituloJurosMora = new bool[] {false} ;
         BC001552_A283TituloTipo = new string[] {""} ;
         BC001552_n283TituloTipo = new bool[] {false} ;
         BC001552_A971TituloPropostaDescricao = new string[] {""} ;
         BC001552_n971TituloPropostaDescricao = new bool[] {false} ;
         BC001552_A501PropostaTaxaAdministrativa = new decimal[1] ;
         BC001552_n501PropostaTaxaAdministrativa = new bool[] {false} ;
         BC001552_A500TituloCriacao = new DateTime[] {DateTime.MinValue} ;
         BC001552_n500TituloCriacao = new bool[] {false} ;
         BC001552_A648TituloPropostaTipo = new string[] {""} ;
         BC001552_n648TituloPropostaTipo = new bool[] {false} ;
         BC001552_A799NotaFiscalNumero = new string[] {""} ;
         BC001552_n799NotaFiscalNumero = new bool[] {false} ;
         BC001552_A969AgenciaBancoNome = new string[] {""} ;
         BC001552_n969AgenciaBancoNome = new bool[] {false} ;
         BC001552_A953ContaBancariaCarteira = new long[1] ;
         BC001552_n953ContaBancariaCarteira = new bool[] {false} ;
         BC001552_A952ContaBancariaNumero = new long[1] ;
         BC001552_n952ContaBancariaNumero = new bool[] {false} ;
         BC001552_A939AgenciaNumero = new int[1] ;
         BC001552_n939AgenciaNumero = new bool[] {false} ;
         BC001552_A422ContaId = new int[1] ;
         BC001552_n422ContaId = new bool[] {false} ;
         BC001552_A426CategoriaTituloId = new int[1] ;
         BC001552_n426CategoriaTituloId = new bool[] {false} ;
         BC001552_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         BC001552_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         BC001552_A951ContaBancariaId = new int[1] ;
         BC001552_n951ContaBancariaId = new bool[] {false} ;
         BC001552_A419TituloPropostaId = new int[1] ;
         BC001552_n419TituloPropostaId = new bool[] {false} ;
         BC001552_A420TituloClienteId = new int[1] ;
         BC001552_n420TituloClienteId = new bool[] {false} ;
         BC001552_A516TituloDataCredito_F = new DateTime[] {DateTime.MinValue} ;
         BC001552_n516TituloDataCredito_F = new bool[] {false} ;
         BC001552_A273TituloTotalMovimento_F = new decimal[1] ;
         BC001552_n273TituloTotalMovimento_F = new bool[] {false} ;
         BC001552_A301TituloTotalMultaJuros_F = new decimal[1] ;
         BC001552_n301TituloTotalMultaJuros_F = new bool[] {false} ;
         BC001552_A1119TitulosCarteiraDeCobranca = new string[] {""} ;
         BC001552_n1119TitulosCarteiraDeCobranca = new bool[] {false} ;
         i500TituloCriacao = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC001553_A271TituloMovimentoValor = new decimal[1] ;
         BC001553_n271TituloMovimentoValor = new bool[] {false} ;
         BC001554_A271TituloMovimentoValor = new decimal[1] ;
         BC001554_n271TituloMovimentoValor = new bool[] {false} ;
         BC001555_A271TituloMovimentoValor = new decimal[1] ;
         BC001555_n271TituloMovimentoValor = new bool[] {false} ;
         BC001556_A271TituloMovimentoValor = new decimal[1] ;
         BC001556_n271TituloMovimentoValor = new bool[] {false} ;
         BC001557_Gx_cnt = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.titulo_bc__default(),
            new Object[][] {
                new Object[] {
               BC00152_A261TituloId, BC00152_A262TituloValor, BC00152_n262TituloValor, BC00152_A276TituloDesconto, BC00152_n276TituloDesconto, BC00152_A284TituloDeleted, BC00152_n284TituloDeleted, BC00152_A314TituloArchived, BC00152_n314TituloArchived, BC00152_A263TituloVencimento,
               BC00152_n263TituloVencimento, BC00152_A286TituloCompetenciaAno, BC00152_n286TituloCompetenciaAno, BC00152_A287TituloCompetenciaMes, BC00152_n287TituloCompetenciaMes, BC00152_A264TituloProrrogacao, BC00152_n264TituloProrrogacao, BC00152_A265TituloCEP, BC00152_n265TituloCEP, BC00152_A266TituloLogradouro,
               BC00152_n266TituloLogradouro, BC00152_A294TituloNumeroEndereco, BC00152_n294TituloNumeroEndereco, BC00152_A267TituloComplemento, BC00152_n267TituloComplemento, BC00152_A268TituloBairro, BC00152_n268TituloBairro, BC00152_A269TituloMunicipio, BC00152_n269TituloMunicipio, BC00152_A498TituloJurosMora,
               BC00152_n498TituloJurosMora, BC00152_A283TituloTipo, BC00152_n283TituloTipo, BC00152_A500TituloCriacao, BC00152_n500TituloCriacao, BC00152_A648TituloPropostaTipo, BC00152_n648TituloPropostaTipo, BC00152_A422ContaId, BC00152_n422ContaId, BC00152_A426CategoriaTituloId,
               BC00152_n426CategoriaTituloId, BC00152_A890NotaFiscalParcelamentoID, BC00152_n890NotaFiscalParcelamentoID, BC00152_A951ContaBancariaId, BC00152_n951ContaBancariaId, BC00152_A419TituloPropostaId, BC00152_n419TituloPropostaId, BC00152_A420TituloClienteId, BC00152_n420TituloClienteId
               }
               , new Object[] {
               BC00153_A261TituloId, BC00153_A262TituloValor, BC00153_n262TituloValor, BC00153_A276TituloDesconto, BC00153_n276TituloDesconto, BC00153_A284TituloDeleted, BC00153_n284TituloDeleted, BC00153_A314TituloArchived, BC00153_n314TituloArchived, BC00153_A263TituloVencimento,
               BC00153_n263TituloVencimento, BC00153_A286TituloCompetenciaAno, BC00153_n286TituloCompetenciaAno, BC00153_A287TituloCompetenciaMes, BC00153_n287TituloCompetenciaMes, BC00153_A264TituloProrrogacao, BC00153_n264TituloProrrogacao, BC00153_A265TituloCEP, BC00153_n265TituloCEP, BC00153_A266TituloLogradouro,
               BC00153_n266TituloLogradouro, BC00153_A294TituloNumeroEndereco, BC00153_n294TituloNumeroEndereco, BC00153_A267TituloComplemento, BC00153_n267TituloComplemento, BC00153_A268TituloBairro, BC00153_n268TituloBairro, BC00153_A269TituloMunicipio, BC00153_n269TituloMunicipio, BC00153_A498TituloJurosMora,
               BC00153_n498TituloJurosMora, BC00153_A283TituloTipo, BC00153_n283TituloTipo, BC00153_A500TituloCriacao, BC00153_n500TituloCriacao, BC00153_A648TituloPropostaTipo, BC00153_n648TituloPropostaTipo, BC00153_A422ContaId, BC00153_n422ContaId, BC00153_A426CategoriaTituloId,
               BC00153_n426CategoriaTituloId, BC00153_A890NotaFiscalParcelamentoID, BC00153_n890NotaFiscalParcelamentoID, BC00153_A951ContaBancariaId, BC00153_n951ContaBancariaId, BC00153_A419TituloPropostaId, BC00153_n419TituloPropostaId, BC00153_A420TituloClienteId, BC00153_n420TituloClienteId
               }
               , new Object[] {
               BC00154_A422ContaId
               }
               , new Object[] {
               BC00155_A426CategoriaTituloId
               }
               , new Object[] {
               BC00156_A794NotaFiscalId, BC00156_n794NotaFiscalId
               }
               , new Object[] {
               BC00157_A938AgenciaId, BC00157_n938AgenciaId, BC00157_A953ContaBancariaCarteira, BC00157_n953ContaBancariaCarteira, BC00157_A952ContaBancariaNumero, BC00157_n952ContaBancariaNumero
               }
               , new Object[] {
               BC00158_A971TituloPropostaDescricao, BC00158_n971TituloPropostaDescricao, BC00158_A501PropostaTaxaAdministrativa, BC00158_n501PropostaTaxaAdministrativa
               }
               , new Object[] {
               BC00159_A972TituloCLienteRazaoSocial, BC00159_n972TituloCLienteRazaoSocial
               }
               , new Object[] {
               BC001510_A799NotaFiscalNumero, BC001510_n799NotaFiscalNumero
               }
               , new Object[] {
               BC001511_A968AgenciaBancoId, BC001511_n968AgenciaBancoId, BC001511_A939AgenciaNumero, BC001511_n939AgenciaNumero
               }
               , new Object[] {
               BC001512_A969AgenciaBancoNome, BC001512_n969AgenciaBancoNome
               }
               , new Object[] {
               BC001514_A516TituloDataCredito_F, BC001514_n516TituloDataCredito_F
               }
               , new Object[] {
               BC001516_A273TituloTotalMovimento_F, BC001516_n273TituloTotalMovimento_F
               }
               , new Object[] {
               BC001518_A301TituloTotalMultaJuros_F, BC001518_n301TituloTotalMultaJuros_F
               }
               , new Object[] {
               BC001520_A1119TitulosCarteiraDeCobranca, BC001520_n1119TitulosCarteiraDeCobranca
               }
               , new Object[] {
               BC001525_A794NotaFiscalId, BC001525_n794NotaFiscalId, BC001525_A938AgenciaId, BC001525_n938AgenciaId, BC001525_A968AgenciaBancoId, BC001525_n968AgenciaBancoId, BC001525_A261TituloId, BC001525_A972TituloCLienteRazaoSocial, BC001525_n972TituloCLienteRazaoSocial, BC001525_A262TituloValor,
               BC001525_n262TituloValor, BC001525_A276TituloDesconto, BC001525_n276TituloDesconto, BC001525_A284TituloDeleted, BC001525_n284TituloDeleted, BC001525_A314TituloArchived, BC001525_n314TituloArchived, BC001525_A263TituloVencimento, BC001525_n263TituloVencimento, BC001525_A286TituloCompetenciaAno,
               BC001525_n286TituloCompetenciaAno, BC001525_A287TituloCompetenciaMes, BC001525_n287TituloCompetenciaMes, BC001525_A264TituloProrrogacao, BC001525_n264TituloProrrogacao, BC001525_A265TituloCEP, BC001525_n265TituloCEP, BC001525_A266TituloLogradouro, BC001525_n266TituloLogradouro, BC001525_A294TituloNumeroEndereco,
               BC001525_n294TituloNumeroEndereco, BC001525_A267TituloComplemento, BC001525_n267TituloComplemento, BC001525_A268TituloBairro, BC001525_n268TituloBairro, BC001525_A269TituloMunicipio, BC001525_n269TituloMunicipio, BC001525_A498TituloJurosMora, BC001525_n498TituloJurosMora, BC001525_A283TituloTipo,
               BC001525_n283TituloTipo, BC001525_A971TituloPropostaDescricao, BC001525_n971TituloPropostaDescricao, BC001525_A501PropostaTaxaAdministrativa, BC001525_n501PropostaTaxaAdministrativa, BC001525_A500TituloCriacao, BC001525_n500TituloCriacao, BC001525_A648TituloPropostaTipo, BC001525_n648TituloPropostaTipo, BC001525_A799NotaFiscalNumero,
               BC001525_n799NotaFiscalNumero, BC001525_A969AgenciaBancoNome, BC001525_n969AgenciaBancoNome, BC001525_A953ContaBancariaCarteira, BC001525_n953ContaBancariaCarteira, BC001525_A952ContaBancariaNumero, BC001525_n952ContaBancariaNumero, BC001525_A939AgenciaNumero, BC001525_n939AgenciaNumero, BC001525_A422ContaId,
               BC001525_n422ContaId, BC001525_A426CategoriaTituloId, BC001525_n426CategoriaTituloId, BC001525_A890NotaFiscalParcelamentoID, BC001525_n890NotaFiscalParcelamentoID, BC001525_A951ContaBancariaId, BC001525_n951ContaBancariaId, BC001525_A419TituloPropostaId, BC001525_n419TituloPropostaId, BC001525_A420TituloClienteId,
               BC001525_n420TituloClienteId, BC001525_A516TituloDataCredito_F, BC001525_n516TituloDataCredito_F, BC001525_A273TituloTotalMovimento_F, BC001525_n273TituloTotalMovimento_F, BC001525_A301TituloTotalMultaJuros_F, BC001525_n301TituloTotalMultaJuros_F, BC001525_A1119TitulosCarteiraDeCobranca, BC001525_n1119TitulosCarteiraDeCobranca
               }
               , new Object[] {
               BC001526_A261TituloId
               }
               , new Object[] {
               }
               , new Object[] {
               BC001528_A261TituloId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001532_A516TituloDataCredito_F, BC001532_n516TituloDataCredito_F
               }
               , new Object[] {
               BC001534_A273TituloTotalMovimento_F, BC001534_n273TituloTotalMovimento_F
               }
               , new Object[] {
               BC001536_A301TituloTotalMultaJuros_F, BC001536_n301TituloTotalMultaJuros_F
               }
               , new Object[] {
               BC001538_A1119TitulosCarteiraDeCobranca, BC001538_n1119TitulosCarteiraDeCobranca
               }
               , new Object[] {
               BC001539_A972TituloCLienteRazaoSocial, BC001539_n972TituloCLienteRazaoSocial
               }
               , new Object[] {
               BC001540_A971TituloPropostaDescricao, BC001540_n971TituloPropostaDescricao, BC001540_A501PropostaTaxaAdministrativa, BC001540_n501PropostaTaxaAdministrativa
               }
               , new Object[] {
               BC001541_A794NotaFiscalId, BC001541_n794NotaFiscalId
               }
               , new Object[] {
               BC001542_A799NotaFiscalNumero, BC001542_n799NotaFiscalNumero
               }
               , new Object[] {
               BC001543_A938AgenciaId, BC001543_n938AgenciaId, BC001543_A953ContaBancariaCarteira, BC001543_n953ContaBancariaCarteira, BC001543_A952ContaBancariaNumero, BC001543_n952ContaBancariaNumero
               }
               , new Object[] {
               BC001544_A968AgenciaBancoId, BC001544_n968AgenciaBancoId, BC001544_A939AgenciaNumero, BC001544_n939AgenciaNumero
               }
               , new Object[] {
               BC001545_A969AgenciaBancoNome, BC001545_n969AgenciaBancoNome
               }
               , new Object[] {
               BC001546_A1077BoletosId
               }
               , new Object[] {
               BC001547_A270TituloMovimentoId
               }
               , new Object[] {
               BC001552_A794NotaFiscalId, BC001552_n794NotaFiscalId, BC001552_A938AgenciaId, BC001552_n938AgenciaId, BC001552_A968AgenciaBancoId, BC001552_n968AgenciaBancoId, BC001552_A261TituloId, BC001552_A972TituloCLienteRazaoSocial, BC001552_n972TituloCLienteRazaoSocial, BC001552_A262TituloValor,
               BC001552_n262TituloValor, BC001552_A276TituloDesconto, BC001552_n276TituloDesconto, BC001552_A284TituloDeleted, BC001552_n284TituloDeleted, BC001552_A314TituloArchived, BC001552_n314TituloArchived, BC001552_A263TituloVencimento, BC001552_n263TituloVencimento, BC001552_A286TituloCompetenciaAno,
               BC001552_n286TituloCompetenciaAno, BC001552_A287TituloCompetenciaMes, BC001552_n287TituloCompetenciaMes, BC001552_A264TituloProrrogacao, BC001552_n264TituloProrrogacao, BC001552_A265TituloCEP, BC001552_n265TituloCEP, BC001552_A266TituloLogradouro, BC001552_n266TituloLogradouro, BC001552_A294TituloNumeroEndereco,
               BC001552_n294TituloNumeroEndereco, BC001552_A267TituloComplemento, BC001552_n267TituloComplemento, BC001552_A268TituloBairro, BC001552_n268TituloBairro, BC001552_A269TituloMunicipio, BC001552_n269TituloMunicipio, BC001552_A498TituloJurosMora, BC001552_n498TituloJurosMora, BC001552_A283TituloTipo,
               BC001552_n283TituloTipo, BC001552_A971TituloPropostaDescricao, BC001552_n971TituloPropostaDescricao, BC001552_A501PropostaTaxaAdministrativa, BC001552_n501PropostaTaxaAdministrativa, BC001552_A500TituloCriacao, BC001552_n500TituloCriacao, BC001552_A648TituloPropostaTipo, BC001552_n648TituloPropostaTipo, BC001552_A799NotaFiscalNumero,
               BC001552_n799NotaFiscalNumero, BC001552_A969AgenciaBancoNome, BC001552_n969AgenciaBancoNome, BC001552_A953ContaBancariaCarteira, BC001552_n953ContaBancariaCarteira, BC001552_A952ContaBancariaNumero, BC001552_n952ContaBancariaNumero, BC001552_A939AgenciaNumero, BC001552_n939AgenciaNumero, BC001552_A422ContaId,
               BC001552_n422ContaId, BC001552_A426CategoriaTituloId, BC001552_n426CategoriaTituloId, BC001552_A890NotaFiscalParcelamentoID, BC001552_n890NotaFiscalParcelamentoID, BC001552_A951ContaBancariaId, BC001552_n951ContaBancariaId, BC001552_A419TituloPropostaId, BC001552_n419TituloPropostaId, BC001552_A420TituloClienteId,
               BC001552_n420TituloClienteId, BC001552_A516TituloDataCredito_F, BC001552_n516TituloDataCredito_F, BC001552_A273TituloTotalMovimento_F, BC001552_n273TituloTotalMovimento_F, BC001552_A301TituloTotalMultaJuros_F, BC001552_n301TituloTotalMultaJuros_F, BC001552_A1119TitulosCarteiraDeCobranca, BC001552_n1119TitulosCarteiraDeCobranca
               }
               , new Object[] {
               BC001553_A271TituloMovimentoValor, BC001553_n271TituloMovimentoValor
               }
               , new Object[] {
               BC001554_A271TituloMovimentoValor, BC001554_n271TituloMovimentoValor
               }
               , new Object[] {
               BC001555_A271TituloMovimentoValor, BC001555_n271TituloMovimentoValor
               }
               , new Object[] {
               BC001556_A271TituloMovimentoValor, BC001556_n271TituloMovimentoValor
               }
               , new Object[] {
               BC001557_Gx_cnt
               }
            }
         );
         AV27Pgmname = "Titulo_BC";
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
         E12152 ();
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
      private int AV28GXV1 ;
      private int AV25Insert_TituloClienteId ;
      private int AV20Insert_TituloPropostaId ;
      private int AV21Insert_ContaId ;
      private int AV22Insert_CategoriaTituloId ;
      private int AV24Insert_ContaBancariaId ;
      private int Z422ContaId ;
      private int A422ContaId ;
      private int Z426CategoriaTituloId ;
      private int A426CategoriaTituloId ;
      private int Z951ContaBancariaId ;
      private int A951ContaBancariaId ;
      private int Z419TituloPropostaId ;
      private int A419TituloPropostaId ;
      private int Z420TituloClienteId ;
      private int A420TituloClienteId ;
      private int Z938AgenciaId ;
      private int A938AgenciaId ;
      private int Z968AgenciaBancoId ;
      private int A968AgenciaBancoId ;
      private int Z939AgenciaNumero ;
      private int A939AgenciaNumero ;
      private int E261TituloId ;
      private int Gx_cnt ;
      private long Z953ContaBancariaCarteira ;
      private long A953ContaBancariaCarteira ;
      private long Z952ContaBancariaNumero ;
      private long A952ContaBancariaNumero ;
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
      private string AV27Pgmname ;
      private string sMode44 ;
      private DateTime Z500TituloCriacao ;
      private DateTime A500TituloCriacao ;
      private DateTime i500TituloCriacao ;
      private DateTime Z263TituloVencimento ;
      private DateTime A263TituloVencimento ;
      private DateTime Z264TituloProrrogacao ;
      private DateTime A264TituloProrrogacao ;
      private DateTime Z516TituloDataCredito_F ;
      private DateTime A516TituloDataCredito_F ;
      private bool returnInSub ;
      private bool Z284TituloDeleted ;
      private bool A284TituloDeleted ;
      private bool Z314TituloArchived ;
      private bool A314TituloArchived ;
      private bool Z1118TitulosEmCarteiraDeCobranca_F ;
      private bool A1118TitulosEmCarteiraDeCobranca_F ;
      private bool n284TituloDeleted ;
      private bool n500TituloCriacao ;
      private bool n261TituloId ;
      private bool n794NotaFiscalId ;
      private bool n938AgenciaId ;
      private bool n968AgenciaBancoId ;
      private bool n972TituloCLienteRazaoSocial ;
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
      private bool n971TituloPropostaDescricao ;
      private bool n501PropostaTaxaAdministrativa ;
      private bool n648TituloPropostaTipo ;
      private bool n799NotaFiscalNumero ;
      private bool n969AgenciaBancoNome ;
      private bool n953ContaBancariaCarteira ;
      private bool n952ContaBancariaNumero ;
      private bool n939AgenciaNumero ;
      private bool n422ContaId ;
      private bool n426CategoriaTituloId ;
      private bool n890NotaFiscalParcelamentoID ;
      private bool n951ContaBancariaId ;
      private bool n419TituloPropostaId ;
      private bool n420TituloClienteId ;
      private bool n516TituloDataCredito_F ;
      private bool n273TituloTotalMovimento_F ;
      private bool n301TituloTotalMultaJuros_F ;
      private bool n1119TitulosCarteiraDeCobranca ;
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
      private string Z648TituloPropostaTipo ;
      private string A648TituloPropostaTipo ;
      private string Z295TituloCompetencia_F ;
      private string A295TituloCompetencia_F ;
      private string Z282TituloStatus_F ;
      private string A282TituloStatus_F ;
      private string Z1119TitulosCarteiraDeCobranca ;
      private string A1119TitulosCarteiraDeCobranca ;
      private string Z971TituloPropostaDescricao ;
      private string A971TituloPropostaDescricao ;
      private string Z972TituloCLienteRazaoSocial ;
      private string A972TituloCLienteRazaoSocial ;
      private string Z799NotaFiscalNumero ;
      private string A799NotaFiscalNumero ;
      private string Z969AgenciaBancoNome ;
      private string A969AgenciaBancoNome ;
      private Guid AV23Insert_NotaFiscalParcelamentoID ;
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
      private Guid[] BC001525_A794NotaFiscalId ;
      private bool[] BC001525_n794NotaFiscalId ;
      private int[] BC001525_A938AgenciaId ;
      private bool[] BC001525_n938AgenciaId ;
      private int[] BC001525_A968AgenciaBancoId ;
      private bool[] BC001525_n968AgenciaBancoId ;
      private int[] BC001525_A261TituloId ;
      private bool[] BC001525_n261TituloId ;
      private string[] BC001525_A972TituloCLienteRazaoSocial ;
      private bool[] BC001525_n972TituloCLienteRazaoSocial ;
      private decimal[] BC001525_A262TituloValor ;
      private bool[] BC001525_n262TituloValor ;
      private decimal[] BC001525_A276TituloDesconto ;
      private bool[] BC001525_n276TituloDesconto ;
      private bool[] BC001525_A284TituloDeleted ;
      private bool[] BC001525_n284TituloDeleted ;
      private bool[] BC001525_A314TituloArchived ;
      private bool[] BC001525_n314TituloArchived ;
      private DateTime[] BC001525_A263TituloVencimento ;
      private bool[] BC001525_n263TituloVencimento ;
      private short[] BC001525_A286TituloCompetenciaAno ;
      private bool[] BC001525_n286TituloCompetenciaAno ;
      private short[] BC001525_A287TituloCompetenciaMes ;
      private bool[] BC001525_n287TituloCompetenciaMes ;
      private DateTime[] BC001525_A264TituloProrrogacao ;
      private bool[] BC001525_n264TituloProrrogacao ;
      private string[] BC001525_A265TituloCEP ;
      private bool[] BC001525_n265TituloCEP ;
      private string[] BC001525_A266TituloLogradouro ;
      private bool[] BC001525_n266TituloLogradouro ;
      private string[] BC001525_A294TituloNumeroEndereco ;
      private bool[] BC001525_n294TituloNumeroEndereco ;
      private string[] BC001525_A267TituloComplemento ;
      private bool[] BC001525_n267TituloComplemento ;
      private string[] BC001525_A268TituloBairro ;
      private bool[] BC001525_n268TituloBairro ;
      private string[] BC001525_A269TituloMunicipio ;
      private bool[] BC001525_n269TituloMunicipio ;
      private decimal[] BC001525_A498TituloJurosMora ;
      private bool[] BC001525_n498TituloJurosMora ;
      private string[] BC001525_A283TituloTipo ;
      private bool[] BC001525_n283TituloTipo ;
      private string[] BC001525_A971TituloPropostaDescricao ;
      private bool[] BC001525_n971TituloPropostaDescricao ;
      private decimal[] BC001525_A501PropostaTaxaAdministrativa ;
      private bool[] BC001525_n501PropostaTaxaAdministrativa ;
      private DateTime[] BC001525_A500TituloCriacao ;
      private bool[] BC001525_n500TituloCriacao ;
      private string[] BC001525_A648TituloPropostaTipo ;
      private bool[] BC001525_n648TituloPropostaTipo ;
      private string[] BC001525_A799NotaFiscalNumero ;
      private bool[] BC001525_n799NotaFiscalNumero ;
      private string[] BC001525_A969AgenciaBancoNome ;
      private bool[] BC001525_n969AgenciaBancoNome ;
      private long[] BC001525_A953ContaBancariaCarteira ;
      private bool[] BC001525_n953ContaBancariaCarteira ;
      private long[] BC001525_A952ContaBancariaNumero ;
      private bool[] BC001525_n952ContaBancariaNumero ;
      private int[] BC001525_A939AgenciaNumero ;
      private bool[] BC001525_n939AgenciaNumero ;
      private int[] BC001525_A422ContaId ;
      private bool[] BC001525_n422ContaId ;
      private int[] BC001525_A426CategoriaTituloId ;
      private bool[] BC001525_n426CategoriaTituloId ;
      private Guid[] BC001525_A890NotaFiscalParcelamentoID ;
      private bool[] BC001525_n890NotaFiscalParcelamentoID ;
      private int[] BC001525_A951ContaBancariaId ;
      private bool[] BC001525_n951ContaBancariaId ;
      private int[] BC001525_A419TituloPropostaId ;
      private bool[] BC001525_n419TituloPropostaId ;
      private int[] BC001525_A420TituloClienteId ;
      private bool[] BC001525_n420TituloClienteId ;
      private DateTime[] BC001525_A516TituloDataCredito_F ;
      private bool[] BC001525_n516TituloDataCredito_F ;
      private decimal[] BC001525_A273TituloTotalMovimento_F ;
      private bool[] BC001525_n273TituloTotalMovimento_F ;
      private decimal[] BC001525_A301TituloTotalMultaJuros_F ;
      private bool[] BC001525_n301TituloTotalMultaJuros_F ;
      private string[] BC001525_A1119TitulosCarteiraDeCobranca ;
      private bool[] BC001525_n1119TitulosCarteiraDeCobranca ;
      private DateTime[] BC001514_A516TituloDataCredito_F ;
      private bool[] BC001514_n516TituloDataCredito_F ;
      private decimal[] BC001516_A273TituloTotalMovimento_F ;
      private bool[] BC001516_n273TituloTotalMovimento_F ;
      private decimal[] BC001518_A301TituloTotalMultaJuros_F ;
      private bool[] BC001518_n301TituloTotalMultaJuros_F ;
      private string[] BC001520_A1119TitulosCarteiraDeCobranca ;
      private bool[] BC001520_n1119TitulosCarteiraDeCobranca ;
      private string[] BC00159_A972TituloCLienteRazaoSocial ;
      private bool[] BC00159_n972TituloCLienteRazaoSocial ;
      private string[] BC00158_A971TituloPropostaDescricao ;
      private bool[] BC00158_n971TituloPropostaDescricao ;
      private decimal[] BC00158_A501PropostaTaxaAdministrativa ;
      private bool[] BC00158_n501PropostaTaxaAdministrativa ;
      private int[] BC00154_A422ContaId ;
      private bool[] BC00154_n422ContaId ;
      private int[] BC00155_A426CategoriaTituloId ;
      private bool[] BC00155_n426CategoriaTituloId ;
      private Guid[] BC00156_A794NotaFiscalId ;
      private bool[] BC00156_n794NotaFiscalId ;
      private string[] BC001510_A799NotaFiscalNumero ;
      private bool[] BC001510_n799NotaFiscalNumero ;
      private int[] BC00157_A938AgenciaId ;
      private bool[] BC00157_n938AgenciaId ;
      private long[] BC00157_A953ContaBancariaCarteira ;
      private bool[] BC00157_n953ContaBancariaCarteira ;
      private long[] BC00157_A952ContaBancariaNumero ;
      private bool[] BC00157_n952ContaBancariaNumero ;
      private int[] BC001511_A968AgenciaBancoId ;
      private bool[] BC001511_n968AgenciaBancoId ;
      private int[] BC001511_A939AgenciaNumero ;
      private bool[] BC001511_n939AgenciaNumero ;
      private string[] BC001512_A969AgenciaBancoNome ;
      private bool[] BC001512_n969AgenciaBancoNome ;
      private int[] BC001526_A261TituloId ;
      private bool[] BC001526_n261TituloId ;
      private int[] BC00153_A261TituloId ;
      private bool[] BC00153_n261TituloId ;
      private decimal[] BC00153_A262TituloValor ;
      private bool[] BC00153_n262TituloValor ;
      private decimal[] BC00153_A276TituloDesconto ;
      private bool[] BC00153_n276TituloDesconto ;
      private bool[] BC00153_A284TituloDeleted ;
      private bool[] BC00153_n284TituloDeleted ;
      private bool[] BC00153_A314TituloArchived ;
      private bool[] BC00153_n314TituloArchived ;
      private DateTime[] BC00153_A263TituloVencimento ;
      private bool[] BC00153_n263TituloVencimento ;
      private short[] BC00153_A286TituloCompetenciaAno ;
      private bool[] BC00153_n286TituloCompetenciaAno ;
      private short[] BC00153_A287TituloCompetenciaMes ;
      private bool[] BC00153_n287TituloCompetenciaMes ;
      private DateTime[] BC00153_A264TituloProrrogacao ;
      private bool[] BC00153_n264TituloProrrogacao ;
      private string[] BC00153_A265TituloCEP ;
      private bool[] BC00153_n265TituloCEP ;
      private string[] BC00153_A266TituloLogradouro ;
      private bool[] BC00153_n266TituloLogradouro ;
      private string[] BC00153_A294TituloNumeroEndereco ;
      private bool[] BC00153_n294TituloNumeroEndereco ;
      private string[] BC00153_A267TituloComplemento ;
      private bool[] BC00153_n267TituloComplemento ;
      private string[] BC00153_A268TituloBairro ;
      private bool[] BC00153_n268TituloBairro ;
      private string[] BC00153_A269TituloMunicipio ;
      private bool[] BC00153_n269TituloMunicipio ;
      private decimal[] BC00153_A498TituloJurosMora ;
      private bool[] BC00153_n498TituloJurosMora ;
      private string[] BC00153_A283TituloTipo ;
      private bool[] BC00153_n283TituloTipo ;
      private DateTime[] BC00153_A500TituloCriacao ;
      private bool[] BC00153_n500TituloCriacao ;
      private string[] BC00153_A648TituloPropostaTipo ;
      private bool[] BC00153_n648TituloPropostaTipo ;
      private int[] BC00153_A422ContaId ;
      private bool[] BC00153_n422ContaId ;
      private int[] BC00153_A426CategoriaTituloId ;
      private bool[] BC00153_n426CategoriaTituloId ;
      private Guid[] BC00153_A890NotaFiscalParcelamentoID ;
      private bool[] BC00153_n890NotaFiscalParcelamentoID ;
      private int[] BC00153_A951ContaBancariaId ;
      private bool[] BC00153_n951ContaBancariaId ;
      private int[] BC00153_A419TituloPropostaId ;
      private bool[] BC00153_n419TituloPropostaId ;
      private int[] BC00153_A420TituloClienteId ;
      private bool[] BC00153_n420TituloClienteId ;
      private int[] BC00152_A261TituloId ;
      private bool[] BC00152_n261TituloId ;
      private decimal[] BC00152_A262TituloValor ;
      private bool[] BC00152_n262TituloValor ;
      private decimal[] BC00152_A276TituloDesconto ;
      private bool[] BC00152_n276TituloDesconto ;
      private bool[] BC00152_A284TituloDeleted ;
      private bool[] BC00152_n284TituloDeleted ;
      private bool[] BC00152_A314TituloArchived ;
      private bool[] BC00152_n314TituloArchived ;
      private DateTime[] BC00152_A263TituloVencimento ;
      private bool[] BC00152_n263TituloVencimento ;
      private short[] BC00152_A286TituloCompetenciaAno ;
      private bool[] BC00152_n286TituloCompetenciaAno ;
      private short[] BC00152_A287TituloCompetenciaMes ;
      private bool[] BC00152_n287TituloCompetenciaMes ;
      private DateTime[] BC00152_A264TituloProrrogacao ;
      private bool[] BC00152_n264TituloProrrogacao ;
      private string[] BC00152_A265TituloCEP ;
      private bool[] BC00152_n265TituloCEP ;
      private string[] BC00152_A266TituloLogradouro ;
      private bool[] BC00152_n266TituloLogradouro ;
      private string[] BC00152_A294TituloNumeroEndereco ;
      private bool[] BC00152_n294TituloNumeroEndereco ;
      private string[] BC00152_A267TituloComplemento ;
      private bool[] BC00152_n267TituloComplemento ;
      private string[] BC00152_A268TituloBairro ;
      private bool[] BC00152_n268TituloBairro ;
      private string[] BC00152_A269TituloMunicipio ;
      private bool[] BC00152_n269TituloMunicipio ;
      private decimal[] BC00152_A498TituloJurosMora ;
      private bool[] BC00152_n498TituloJurosMora ;
      private string[] BC00152_A283TituloTipo ;
      private bool[] BC00152_n283TituloTipo ;
      private DateTime[] BC00152_A500TituloCriacao ;
      private bool[] BC00152_n500TituloCriacao ;
      private string[] BC00152_A648TituloPropostaTipo ;
      private bool[] BC00152_n648TituloPropostaTipo ;
      private int[] BC00152_A422ContaId ;
      private bool[] BC00152_n422ContaId ;
      private int[] BC00152_A426CategoriaTituloId ;
      private bool[] BC00152_n426CategoriaTituloId ;
      private Guid[] BC00152_A890NotaFiscalParcelamentoID ;
      private bool[] BC00152_n890NotaFiscalParcelamentoID ;
      private int[] BC00152_A951ContaBancariaId ;
      private bool[] BC00152_n951ContaBancariaId ;
      private int[] BC00152_A419TituloPropostaId ;
      private bool[] BC00152_n419TituloPropostaId ;
      private int[] BC00152_A420TituloClienteId ;
      private bool[] BC00152_n420TituloClienteId ;
      private int[] BC001528_A261TituloId ;
      private bool[] BC001528_n261TituloId ;
      private DateTime[] BC001532_A516TituloDataCredito_F ;
      private bool[] BC001532_n516TituloDataCredito_F ;
      private decimal[] BC001534_A273TituloTotalMovimento_F ;
      private bool[] BC001534_n273TituloTotalMovimento_F ;
      private decimal[] BC001536_A301TituloTotalMultaJuros_F ;
      private bool[] BC001536_n301TituloTotalMultaJuros_F ;
      private string[] BC001538_A1119TitulosCarteiraDeCobranca ;
      private bool[] BC001538_n1119TitulosCarteiraDeCobranca ;
      private string[] BC001539_A972TituloCLienteRazaoSocial ;
      private bool[] BC001539_n972TituloCLienteRazaoSocial ;
      private string[] BC001540_A971TituloPropostaDescricao ;
      private bool[] BC001540_n971TituloPropostaDescricao ;
      private decimal[] BC001540_A501PropostaTaxaAdministrativa ;
      private bool[] BC001540_n501PropostaTaxaAdministrativa ;
      private Guid[] BC001541_A794NotaFiscalId ;
      private bool[] BC001541_n794NotaFiscalId ;
      private string[] BC001542_A799NotaFiscalNumero ;
      private bool[] BC001542_n799NotaFiscalNumero ;
      private int[] BC001543_A938AgenciaId ;
      private bool[] BC001543_n938AgenciaId ;
      private long[] BC001543_A953ContaBancariaCarteira ;
      private bool[] BC001543_n953ContaBancariaCarteira ;
      private long[] BC001543_A952ContaBancariaNumero ;
      private bool[] BC001543_n952ContaBancariaNumero ;
      private int[] BC001544_A968AgenciaBancoId ;
      private bool[] BC001544_n968AgenciaBancoId ;
      private int[] BC001544_A939AgenciaNumero ;
      private bool[] BC001544_n939AgenciaNumero ;
      private string[] BC001545_A969AgenciaBancoNome ;
      private bool[] BC001545_n969AgenciaBancoNome ;
      private int[] BC001546_A1077BoletosId ;
      private int[] BC001547_A270TituloMovimentoId ;
      private Guid[] BC001552_A794NotaFiscalId ;
      private bool[] BC001552_n794NotaFiscalId ;
      private int[] BC001552_A938AgenciaId ;
      private bool[] BC001552_n938AgenciaId ;
      private int[] BC001552_A968AgenciaBancoId ;
      private bool[] BC001552_n968AgenciaBancoId ;
      private int[] BC001552_A261TituloId ;
      private bool[] BC001552_n261TituloId ;
      private string[] BC001552_A972TituloCLienteRazaoSocial ;
      private bool[] BC001552_n972TituloCLienteRazaoSocial ;
      private decimal[] BC001552_A262TituloValor ;
      private bool[] BC001552_n262TituloValor ;
      private decimal[] BC001552_A276TituloDesconto ;
      private bool[] BC001552_n276TituloDesconto ;
      private bool[] BC001552_A284TituloDeleted ;
      private bool[] BC001552_n284TituloDeleted ;
      private bool[] BC001552_A314TituloArchived ;
      private bool[] BC001552_n314TituloArchived ;
      private DateTime[] BC001552_A263TituloVencimento ;
      private bool[] BC001552_n263TituloVencimento ;
      private short[] BC001552_A286TituloCompetenciaAno ;
      private bool[] BC001552_n286TituloCompetenciaAno ;
      private short[] BC001552_A287TituloCompetenciaMes ;
      private bool[] BC001552_n287TituloCompetenciaMes ;
      private DateTime[] BC001552_A264TituloProrrogacao ;
      private bool[] BC001552_n264TituloProrrogacao ;
      private string[] BC001552_A265TituloCEP ;
      private bool[] BC001552_n265TituloCEP ;
      private string[] BC001552_A266TituloLogradouro ;
      private bool[] BC001552_n266TituloLogradouro ;
      private string[] BC001552_A294TituloNumeroEndereco ;
      private bool[] BC001552_n294TituloNumeroEndereco ;
      private string[] BC001552_A267TituloComplemento ;
      private bool[] BC001552_n267TituloComplemento ;
      private string[] BC001552_A268TituloBairro ;
      private bool[] BC001552_n268TituloBairro ;
      private string[] BC001552_A269TituloMunicipio ;
      private bool[] BC001552_n269TituloMunicipio ;
      private decimal[] BC001552_A498TituloJurosMora ;
      private bool[] BC001552_n498TituloJurosMora ;
      private string[] BC001552_A283TituloTipo ;
      private bool[] BC001552_n283TituloTipo ;
      private string[] BC001552_A971TituloPropostaDescricao ;
      private bool[] BC001552_n971TituloPropostaDescricao ;
      private decimal[] BC001552_A501PropostaTaxaAdministrativa ;
      private bool[] BC001552_n501PropostaTaxaAdministrativa ;
      private DateTime[] BC001552_A500TituloCriacao ;
      private bool[] BC001552_n500TituloCriacao ;
      private string[] BC001552_A648TituloPropostaTipo ;
      private bool[] BC001552_n648TituloPropostaTipo ;
      private string[] BC001552_A799NotaFiscalNumero ;
      private bool[] BC001552_n799NotaFiscalNumero ;
      private string[] BC001552_A969AgenciaBancoNome ;
      private bool[] BC001552_n969AgenciaBancoNome ;
      private long[] BC001552_A953ContaBancariaCarteira ;
      private bool[] BC001552_n953ContaBancariaCarteira ;
      private long[] BC001552_A952ContaBancariaNumero ;
      private bool[] BC001552_n952ContaBancariaNumero ;
      private int[] BC001552_A939AgenciaNumero ;
      private bool[] BC001552_n939AgenciaNumero ;
      private int[] BC001552_A422ContaId ;
      private bool[] BC001552_n422ContaId ;
      private int[] BC001552_A426CategoriaTituloId ;
      private bool[] BC001552_n426CategoriaTituloId ;
      private Guid[] BC001552_A890NotaFiscalParcelamentoID ;
      private bool[] BC001552_n890NotaFiscalParcelamentoID ;
      private int[] BC001552_A951ContaBancariaId ;
      private bool[] BC001552_n951ContaBancariaId ;
      private int[] BC001552_A419TituloPropostaId ;
      private bool[] BC001552_n419TituloPropostaId ;
      private int[] BC001552_A420TituloClienteId ;
      private bool[] BC001552_n420TituloClienteId ;
      private DateTime[] BC001552_A516TituloDataCredito_F ;
      private bool[] BC001552_n516TituloDataCredito_F ;
      private decimal[] BC001552_A273TituloTotalMovimento_F ;
      private bool[] BC001552_n273TituloTotalMovimento_F ;
      private decimal[] BC001552_A301TituloTotalMultaJuros_F ;
      private bool[] BC001552_n301TituloTotalMultaJuros_F ;
      private string[] BC001552_A1119TitulosCarteiraDeCobranca ;
      private bool[] BC001552_n1119TitulosCarteiraDeCobranca ;
      private SdtTitulo bcTitulo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private decimal[] BC001553_A271TituloMovimentoValor ;
      private bool[] BC001553_n271TituloMovimentoValor ;
      private decimal[] BC001554_A271TituloMovimentoValor ;
      private bool[] BC001554_n271TituloMovimentoValor ;
      private decimal[] BC001555_A271TituloMovimentoValor ;
      private bool[] BC001555_n271TituloMovimentoValor ;
      private decimal[] BC001556_A271TituloMovimentoValor ;
      private bool[] BC001556_n271TituloMovimentoValor ;
      private int[] BC001557_Gx_cnt ;
   }

   public class titulo_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new UpdateCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new UpdateCursor(def[19])
         ,new UpdateCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
         ,new ForEachCursor(def[27])
         ,new ForEachCursor(def[28])
         ,new ForEachCursor(def[29])
         ,new ForEachCursor(def[30])
         ,new ForEachCursor(def[31])
         ,new ForEachCursor(def[32])
         ,new ForEachCursor(def[33])
         ,new ForEachCursor(def[34])
         ,new ForEachCursor(def[35])
         ,new ForEachCursor(def[36])
         ,new ForEachCursor(def[37])
         ,new ForEachCursor(def[38])
         ,new ForEachCursor(def[39])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00152;
          prmBC00152 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00153;
          prmBC00153 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00154;
          prmBC00154 = new Object[] {
          new ParDef("ContaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00155;
          prmBC00155 = new Object[] {
          new ParDef("CategoriaTituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00156;
          prmBC00156 = new Object[] {
          new ParDef("NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmBC00157;
          prmBC00157 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00158;
          prmBC00158 = new Object[] {
          new ParDef("TituloPropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00159;
          prmBC00159 = new Object[] {
          new ParDef("TituloClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001510;
          prmBC001510 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmBC001511;
          prmBC001511 = new Object[] {
          new ParDef("AgenciaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001512;
          prmBC001512 = new Object[] {
          new ParDef("AgenciaBancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001514;
          prmBC001514 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001516;
          prmBC001516 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001518;
          prmBC001518 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001520;
          prmBC001520 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001525;
          prmBC001525 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          string cmdBufferBC001525;
          cmdBufferBC001525=" SELECT T8.NotaFiscalId, T10.AgenciaId, T11.AgenciaBancoId AS AgenciaBancoId, TM1.TituloId, T6.ClienteRazaoSocial AS TituloCLienteRazaoSocial, TM1.TituloValor, TM1.TituloDesconto, TM1.TituloDeleted, TM1.TituloArchived, TM1.TituloVencimento, TM1.TituloCompetenciaAno, TM1.TituloCompetenciaMes, TM1.TituloProrrogacao, TM1.TituloCEP, TM1.TituloLogradouro, TM1.TituloNumeroEndereco, TM1.TituloComplemento, TM1.TituloBairro, TM1.TituloMunicipio, TM1.TituloJurosMora, TM1.TituloTipo, T7.PropostaDescricao AS TituloPropostaDescricao, T7.PropostaTaxaAdministrativa, TM1.TituloCriacao, TM1.TituloPropostaTipo, T9.NotaFiscalNumero, T12.BancoNome AS AgenciaBancoNome, T10.ContaBancariaCarteira, T10.ContaBancariaNumero, T11.AgenciaNumero, TM1.ContaId, TM1.CategoriaTituloId, TM1.NotaFiscalParcelamentoID, TM1.ContaBancariaId, TM1.TituloPropostaId AS TituloPropostaId, TM1.TituloClienteId AS TituloClienteId, COALESCE( T2.TituloDataCredito_F, DATE '00010101') AS TituloDataCredito_F, COALESCE( T3.TituloTotalMovimento_F, 0) AS TituloTotalMovimento_F, COALESCE( T4.TituloTotalMovimento_F, 0) AS TituloTotalMultaJuros_F, COALESCE( T5.TitulosCarteiraDeCobranca, '') AS TitulosCarteiraDeCobranca FROM (((((((((((Titulo TM1 LEFT JOIN LATERAL (SELECT MAX(TituloMovimentoDataCredito) AS TituloDataCredito_F, TituloId FROM TituloMovimento WHERE TM1.TituloId = TituloId GROUP BY TituloId ) T2 ON T2.TituloId = TM1.TituloId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (TM1.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T3 ON T3.TituloId = TM1.TituloId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (TM1.TituloId = TituloId) AND (Not TituloMovimentoSoma) GROUP BY "
          + " TituloId ) T4 ON T4.TituloId = TM1.TituloId) LEFT JOIN LATERAL (SELECT MAX(T14.CarteiraDeCobrancaNome) AS TitulosCarteiraDeCobranca, T13.TituloId FROM (Boleto T13 LEFT JOIN CarteiraDeCobranca T14 ON T14.CarteiraDeCobrancaId = T13.CarteiraDeCobrancaId) WHERE TM1.TituloId = T13.TituloId GROUP BY T13.TituloId ) T5 ON T5.TituloId = TM1.TituloId) LEFT JOIN Cliente T6 ON T6.ClienteId = TM1.TituloClienteId) LEFT JOIN Proposta T7 ON T7.PropostaId = TM1.TituloPropostaId) LEFT JOIN NotaFiscalParcelamento T8 ON T8.NotaFiscalParcelamentoID = TM1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T9 ON T9.NotaFiscalId = T8.NotaFiscalId) LEFT JOIN ContaBancaria T10 ON T10.ContaBancariaId = TM1.ContaBancariaId) LEFT JOIN Agencia T11 ON T11.AgenciaId = T10.AgenciaId) LEFT JOIN Banco T12 ON T12.BancoId = T11.AgenciaBancoId) WHERE TM1.TituloId = :TituloId ORDER BY TM1.TituloId" ;
          Object[] prmBC001526;
          prmBC001526 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001527;
          prmBC001527 = new Object[] {
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
          new ParDef("TituloPropostaTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ContaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("CategoriaTituloId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("TituloPropostaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("TituloClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001528;
          prmBC001528 = new Object[] {
          };
          Object[] prmBC001529;
          prmBC001529 = new Object[] {
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
          new ParDef("TituloPropostaTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ContaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("CategoriaTituloId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("TituloPropostaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("TituloClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001530;
          prmBC001530 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001532;
          prmBC001532 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001534;
          prmBC001534 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001536;
          prmBC001536 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001538;
          prmBC001538 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001539;
          prmBC001539 = new Object[] {
          new ParDef("TituloClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001540;
          prmBC001540 = new Object[] {
          new ParDef("TituloPropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001541;
          prmBC001541 = new Object[] {
          new ParDef("NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmBC001542;
          prmBC001542 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmBC001543;
          prmBC001543 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001544;
          prmBC001544 = new Object[] {
          new ParDef("AgenciaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001545;
          prmBC001545 = new Object[] {
          new ParDef("AgenciaBancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001546;
          prmBC001546 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001547;
          prmBC001547 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001552;
          prmBC001552 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          string cmdBufferBC001552;
          cmdBufferBC001552=" SELECT T8.NotaFiscalId, T10.AgenciaId, T11.AgenciaBancoId AS AgenciaBancoId, TM1.TituloId, T6.ClienteRazaoSocial AS TituloCLienteRazaoSocial, TM1.TituloValor, TM1.TituloDesconto, TM1.TituloDeleted, TM1.TituloArchived, TM1.TituloVencimento, TM1.TituloCompetenciaAno, TM1.TituloCompetenciaMes, TM1.TituloProrrogacao, TM1.TituloCEP, TM1.TituloLogradouro, TM1.TituloNumeroEndereco, TM1.TituloComplemento, TM1.TituloBairro, TM1.TituloMunicipio, TM1.TituloJurosMora, TM1.TituloTipo, T7.PropostaDescricao AS TituloPropostaDescricao, T7.PropostaTaxaAdministrativa, TM1.TituloCriacao, TM1.TituloPropostaTipo, T9.NotaFiscalNumero, T12.BancoNome AS AgenciaBancoNome, T10.ContaBancariaCarteira, T10.ContaBancariaNumero, T11.AgenciaNumero, TM1.ContaId, TM1.CategoriaTituloId, TM1.NotaFiscalParcelamentoID, TM1.ContaBancariaId, TM1.TituloPropostaId AS TituloPropostaId, TM1.TituloClienteId AS TituloClienteId, COALESCE( T2.TituloDataCredito_F, DATE '00010101') AS TituloDataCredito_F, COALESCE( T3.TituloTotalMovimento_F, 0) AS TituloTotalMovimento_F, COALESCE( T4.TituloTotalMovimento_F, 0) AS TituloTotalMultaJuros_F, COALESCE( T5.TitulosCarteiraDeCobranca, '') AS TitulosCarteiraDeCobranca FROM (((((((((((Titulo TM1 LEFT JOIN LATERAL (SELECT MAX(TituloMovimentoDataCredito) AS TituloDataCredito_F, TituloId FROM TituloMovimento WHERE TM1.TituloId = TituloId GROUP BY TituloId ) T2 ON T2.TituloId = TM1.TituloId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (TM1.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T3 ON T3.TituloId = TM1.TituloId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (TM1.TituloId = TituloId) AND (Not TituloMovimentoSoma) GROUP BY "
          + " TituloId ) T4 ON T4.TituloId = TM1.TituloId) LEFT JOIN LATERAL (SELECT MAX(T14.CarteiraDeCobrancaNome) AS TitulosCarteiraDeCobranca, T13.TituloId FROM (Boleto T13 LEFT JOIN CarteiraDeCobranca T14 ON T14.CarteiraDeCobrancaId = T13.CarteiraDeCobrancaId) WHERE TM1.TituloId = T13.TituloId GROUP BY T13.TituloId ) T5 ON T5.TituloId = TM1.TituloId) LEFT JOIN Cliente T6 ON T6.ClienteId = TM1.TituloClienteId) LEFT JOIN Proposta T7 ON T7.PropostaId = TM1.TituloPropostaId) LEFT JOIN NotaFiscalParcelamento T8 ON T8.NotaFiscalParcelamentoID = TM1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T9 ON T9.NotaFiscalId = T8.NotaFiscalId) LEFT JOIN ContaBancaria T10 ON T10.ContaBancariaId = TM1.ContaBancariaId) LEFT JOIN Agencia T11 ON T11.AgenciaId = T10.AgenciaId) LEFT JOIN Banco T12 ON T12.BancoId = T11.AgenciaBancoId) WHERE TM1.TituloId = :TituloId ORDER BY TM1.TituloId" ;
          Object[] prmBC001553;
          prmBC001553 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001554;
          prmBC001554 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001555;
          prmBC001555 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001556;
          prmBC001556 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001557;
          prmBC001557 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC00152", "SELECT TituloId, TituloValor, TituloDesconto, TituloDeleted, TituloArchived, TituloVencimento, TituloCompetenciaAno, TituloCompetenciaMes, TituloProrrogacao, TituloCEP, TituloLogradouro, TituloNumeroEndereco, TituloComplemento, TituloBairro, TituloMunicipio, TituloJurosMora, TituloTipo, TituloCriacao, TituloPropostaTipo, ContaId, CategoriaTituloId, NotaFiscalParcelamentoID, ContaBancariaId, TituloPropostaId, TituloClienteId FROM Titulo WHERE TituloId = :TituloId  FOR UPDATE OF Titulo",true, GxErrorMask.GX_NOMASK, false, this,prmBC00152,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00153", "SELECT TituloId, TituloValor, TituloDesconto, TituloDeleted, TituloArchived, TituloVencimento, TituloCompetenciaAno, TituloCompetenciaMes, TituloProrrogacao, TituloCEP, TituloLogradouro, TituloNumeroEndereco, TituloComplemento, TituloBairro, TituloMunicipio, TituloJurosMora, TituloTipo, TituloCriacao, TituloPropostaTipo, ContaId, CategoriaTituloId, NotaFiscalParcelamentoID, ContaBancariaId, TituloPropostaId, TituloClienteId FROM Titulo WHERE TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00153,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00154", "SELECT ContaId FROM Conta WHERE ContaId = :ContaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00154,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00155", "SELECT CategoriaTituloId FROM CategoriaTitulo WHERE CategoriaTituloId = :CategoriaTituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00155,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00156", "SELECT NotaFiscalId FROM NotaFiscalParcelamento WHERE NotaFiscalParcelamentoID = :NotaFiscalParcelamentoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00156,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00157", "SELECT AgenciaId, ContaBancariaCarteira, ContaBancariaNumero FROM ContaBancaria WHERE ContaBancariaId = :ContaBancariaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00157,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00158", "SELECT PropostaDescricao AS TituloPropostaDescricao, PropostaTaxaAdministrativa FROM Proposta WHERE PropostaId = :TituloPropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00158,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00159", "SELECT ClienteRazaoSocial AS TituloCLienteRazaoSocial FROM Cliente WHERE ClienteId = :TituloClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00159,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001510", "SELECT NotaFiscalNumero FROM NotaFiscal WHERE NotaFiscalId = :NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001510,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001511", "SELECT AgenciaBancoId, AgenciaNumero FROM Agencia WHERE AgenciaId = :AgenciaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001511,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001512", "SELECT BancoNome AS AgenciaBancoNome FROM Banco WHERE BancoId = :AgenciaBancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001512,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001514", "SELECT COALESCE( T1.TituloDataCredito_F, DATE '00010101') AS TituloDataCredito_F FROM (SELECT MAX(TituloMovimentoDataCredito) AS TituloDataCredito_F, TituloId FROM TituloMovimento GROUP BY TituloId ) T1 WHERE T1.TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001514,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001516", "SELECT COALESCE( T1.TituloTotalMovimento_F, 0) AS TituloTotalMovimento_F FROM (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE TituloMovimentoSoma GROUP BY TituloId ) T1 WHERE T1.TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001516,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001518", "SELECT COALESCE( T1.TituloTotalMovimento_F, 0) AS TituloTotalMultaJuros_F FROM (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE Not TituloMovimentoSoma GROUP BY TituloId ) T1 WHERE T1.TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001518,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001520", "SELECT COALESCE( T1.TitulosCarteiraDeCobranca, '') AS TitulosCarteiraDeCobranca FROM (SELECT MAX(T3.CarteiraDeCobrancaNome) AS TitulosCarteiraDeCobranca, T2.TituloId FROM (Boleto T2 LEFT JOIN CarteiraDeCobranca T3 ON T3.CarteiraDeCobrancaId = T2.CarteiraDeCobrancaId) GROUP BY T2.TituloId ) T1 WHERE T1.TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001520,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001525", cmdBufferBC001525,true, GxErrorMask.GX_NOMASK, false, this,prmBC001525,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001526", "SELECT TituloId FROM Titulo WHERE TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001526,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001527", "SAVEPOINT gxupdate;INSERT INTO Titulo(TituloValor, TituloDesconto, TituloDeleted, TituloArchived, TituloVencimento, TituloCompetenciaAno, TituloCompetenciaMes, TituloProrrogacao, TituloCEP, TituloLogradouro, TituloNumeroEndereco, TituloComplemento, TituloBairro, TituloMunicipio, TituloJurosMora, TituloTipo, TituloCriacao, TituloPropostaTipo, ContaId, CategoriaTituloId, NotaFiscalParcelamentoID, ContaBancariaId, TituloPropostaId, TituloClienteId) VALUES(:TituloValor, :TituloDesconto, :TituloDeleted, :TituloArchived, :TituloVencimento, :TituloCompetenciaAno, :TituloCompetenciaMes, :TituloProrrogacao, :TituloCEP, :TituloLogradouro, :TituloNumeroEndereco, :TituloComplemento, :TituloBairro, :TituloMunicipio, :TituloJurosMora, :TituloTipo, :TituloCriacao, :TituloPropostaTipo, :ContaId, :CategoriaTituloId, :NotaFiscalParcelamentoID, :ContaBancariaId, :TituloPropostaId, :TituloClienteId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001527)
             ,new CursorDef("BC001528", "SELECT currval('TituloId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001528,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001529", "SAVEPOINT gxupdate;UPDATE Titulo SET TituloValor=:TituloValor, TituloDesconto=:TituloDesconto, TituloDeleted=:TituloDeleted, TituloArchived=:TituloArchived, TituloVencimento=:TituloVencimento, TituloCompetenciaAno=:TituloCompetenciaAno, TituloCompetenciaMes=:TituloCompetenciaMes, TituloProrrogacao=:TituloProrrogacao, TituloCEP=:TituloCEP, TituloLogradouro=:TituloLogradouro, TituloNumeroEndereco=:TituloNumeroEndereco, TituloComplemento=:TituloComplemento, TituloBairro=:TituloBairro, TituloMunicipio=:TituloMunicipio, TituloJurosMora=:TituloJurosMora, TituloTipo=:TituloTipo, TituloCriacao=:TituloCriacao, TituloPropostaTipo=:TituloPropostaTipo, ContaId=:ContaId, CategoriaTituloId=:CategoriaTituloId, NotaFiscalParcelamentoID=:NotaFiscalParcelamentoID, ContaBancariaId=:ContaBancariaId, TituloPropostaId=:TituloPropostaId, TituloClienteId=:TituloClienteId  WHERE TituloId = :TituloId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001529)
             ,new CursorDef("BC001530", "SAVEPOINT gxupdate;DELETE FROM Titulo  WHERE TituloId = :TituloId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001530)
             ,new CursorDef("BC001532", "SELECT COALESCE( T1.TituloDataCredito_F, DATE '00010101') AS TituloDataCredito_F FROM (SELECT MAX(TituloMovimentoDataCredito) AS TituloDataCredito_F, TituloId FROM TituloMovimento GROUP BY TituloId ) T1 WHERE T1.TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001532,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001534", "SELECT COALESCE( T1.TituloTotalMovimento_F, 0) AS TituloTotalMovimento_F FROM (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE TituloMovimentoSoma GROUP BY TituloId ) T1 WHERE T1.TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001534,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001536", "SELECT COALESCE( T1.TituloTotalMovimento_F, 0) AS TituloTotalMultaJuros_F FROM (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE Not TituloMovimentoSoma GROUP BY TituloId ) T1 WHERE T1.TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001536,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001538", "SELECT COALESCE( T1.TitulosCarteiraDeCobranca, '') AS TitulosCarteiraDeCobranca FROM (SELECT MAX(T3.CarteiraDeCobrancaNome) AS TitulosCarteiraDeCobranca, T2.TituloId FROM (Boleto T2 LEFT JOIN CarteiraDeCobranca T3 ON T3.CarteiraDeCobrancaId = T2.CarteiraDeCobrancaId) GROUP BY T2.TituloId ) T1 WHERE T1.TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001538,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001539", "SELECT ClienteRazaoSocial AS TituloCLienteRazaoSocial FROM Cliente WHERE ClienteId = :TituloClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001539,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001540", "SELECT PropostaDescricao AS TituloPropostaDescricao, PropostaTaxaAdministrativa FROM Proposta WHERE PropostaId = :TituloPropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001540,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001541", "SELECT NotaFiscalId FROM NotaFiscalParcelamento WHERE NotaFiscalParcelamentoID = :NotaFiscalParcelamentoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001541,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001542", "SELECT NotaFiscalNumero FROM NotaFiscal WHERE NotaFiscalId = :NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001542,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001543", "SELECT AgenciaId, ContaBancariaCarteira, ContaBancariaNumero FROM ContaBancaria WHERE ContaBancariaId = :ContaBancariaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001543,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001544", "SELECT AgenciaBancoId, AgenciaNumero FROM Agencia WHERE AgenciaId = :AgenciaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001544,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001545", "SELECT BancoNome AS AgenciaBancoNome FROM Banco WHERE BancoId = :AgenciaBancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001545,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001546", "SELECT BoletosId FROM Boleto WHERE TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001546,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001547", "SELECT TituloMovimentoId FROM TituloMovimento WHERE TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001547,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001552", cmdBufferBC001552,true, GxErrorMask.GX_NOMASK, false, this,prmBC001552,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001553", "SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento WHERE ( TituloId = :TituloId) and ( TituloMovimentoSoma) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001553,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001554", "SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento WHERE ( TituloId = :TituloId) and ( TituloMovimentoSoma) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001554,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001555", "SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento WHERE ( TituloId = :TituloId) and ( Not TituloMovimentoSoma) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001555,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001556", "SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento WHERE ( TituloId = :TituloId) and ( Not TituloMovimentoSoma) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001556,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001557", "SELECT COUNT(*) FROM Boleto WHERE TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001557,1, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
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
                ((decimal[]) buf[29])[0] = rslt.getDecimal(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((DateTime[]) buf[33])[0] = rslt.getGXDateTime(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((int[]) buf[37])[0] = rslt.getInt(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((int[]) buf[39])[0] = rslt.getInt(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((Guid[]) buf[41])[0] = rslt.getGuid(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((int[]) buf[43])[0] = rslt.getInt(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((int[]) buf[45])[0] = rslt.getInt(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((int[]) buf[47])[0] = rslt.getInt(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
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
                ((decimal[]) buf[29])[0] = rslt.getDecimal(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((DateTime[]) buf[33])[0] = rslt.getGXDateTime(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((int[]) buf[37])[0] = rslt.getInt(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((int[]) buf[39])[0] = rslt.getInt(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((Guid[]) buf[41])[0] = rslt.getGuid(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((int[]) buf[43])[0] = rslt.getInt(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((int[]) buf[45])[0] = rslt.getInt(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((int[]) buf[47])[0] = rslt.getInt(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((long[]) buf[4])[0] = rslt.getLong(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 11 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 12 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 13 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 15 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((bool[]) buf[15])[0] = rslt.getBool(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((short[]) buf[19])[0] = rslt.getShort(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((short[]) buf[21])[0] = rslt.getShort(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[23])[0] = rslt.getGXDate(13);
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
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((decimal[]) buf[37])[0] = rslt.getDecimal(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((string[]) buf[41])[0] = rslt.getVarchar(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((decimal[]) buf[43])[0] = rslt.getDecimal(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((DateTime[]) buf[45])[0] = rslt.getGXDateTime(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((string[]) buf[47])[0] = rslt.getVarchar(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((string[]) buf[51])[0] = rslt.getVarchar(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((long[]) buf[53])[0] = rslt.getLong(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((long[]) buf[55])[0] = rslt.getLong(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((int[]) buf[57])[0] = rslt.getInt(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((int[]) buf[59])[0] = rslt.getInt(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((int[]) buf[61])[0] = rslt.getInt(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((Guid[]) buf[63])[0] = rslt.getGuid(33);
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                ((int[]) buf[65])[0] = rslt.getInt(34);
                ((bool[]) buf[66])[0] = rslt.wasNull(34);
                ((int[]) buf[67])[0] = rslt.getInt(35);
                ((bool[]) buf[68])[0] = rslt.wasNull(35);
                ((int[]) buf[69])[0] = rslt.getInt(36);
                ((bool[]) buf[70])[0] = rslt.wasNull(36);
                ((DateTime[]) buf[71])[0] = rslt.getGXDate(37);
                ((bool[]) buf[72])[0] = rslt.wasNull(37);
                ((decimal[]) buf[73])[0] = rslt.getDecimal(38);
                ((bool[]) buf[74])[0] = rslt.wasNull(38);
                ((decimal[]) buf[75])[0] = rslt.getDecimal(39);
                ((bool[]) buf[76])[0] = rslt.wasNull(39);
                ((string[]) buf[77])[0] = rslt.getVarchar(40);
                ((bool[]) buf[78])[0] = rslt.wasNull(40);
                return;
             case 16 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 18 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 21 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 25 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 26 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 27 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 28 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 29 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((long[]) buf[4])[0] = rslt.getLong(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                return;
       }
       getresults30( cursor, rslt, buf) ;
    }

    public void getresults30( int cursor ,
                              IFieldGetter rslt ,
                              Object[] buf )
    {
       switch ( cursor )
       {
             case 30 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 31 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 32 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 33 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 34 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((bool[]) buf[15])[0] = rslt.getBool(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((short[]) buf[19])[0] = rslt.getShort(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((short[]) buf[21])[0] = rslt.getShort(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[23])[0] = rslt.getGXDate(13);
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
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((decimal[]) buf[37])[0] = rslt.getDecimal(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((string[]) buf[41])[0] = rslt.getVarchar(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((decimal[]) buf[43])[0] = rslt.getDecimal(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((DateTime[]) buf[45])[0] = rslt.getGXDateTime(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((string[]) buf[47])[0] = rslt.getVarchar(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((string[]) buf[51])[0] = rslt.getVarchar(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((long[]) buf[53])[0] = rslt.getLong(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((long[]) buf[55])[0] = rslt.getLong(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((int[]) buf[57])[0] = rslt.getInt(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((int[]) buf[59])[0] = rslt.getInt(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((int[]) buf[61])[0] = rslt.getInt(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((Guid[]) buf[63])[0] = rslt.getGuid(33);
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                ((int[]) buf[65])[0] = rslt.getInt(34);
                ((bool[]) buf[66])[0] = rslt.wasNull(34);
                ((int[]) buf[67])[0] = rslt.getInt(35);
                ((bool[]) buf[68])[0] = rslt.wasNull(35);
                ((int[]) buf[69])[0] = rslt.getInt(36);
                ((bool[]) buf[70])[0] = rslt.wasNull(36);
                ((DateTime[]) buf[71])[0] = rslt.getGXDate(37);
                ((bool[]) buf[72])[0] = rslt.wasNull(37);
                ((decimal[]) buf[73])[0] = rslt.getDecimal(38);
                ((bool[]) buf[74])[0] = rslt.wasNull(38);
                ((decimal[]) buf[75])[0] = rslt.getDecimal(39);
                ((bool[]) buf[76])[0] = rslt.wasNull(39);
                ((string[]) buf[77])[0] = rslt.getVarchar(40);
                ((bool[]) buf[78])[0] = rslt.wasNull(40);
                return;
             case 35 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 36 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 37 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 38 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 39 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
