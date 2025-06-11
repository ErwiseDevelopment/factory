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
   public class boleto_bc : GxSilentTrn, IGxSilentTrn
   {
      public boleto_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public boleto_bc( IGxContext context )
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
         ReadRow37111( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey37111( ) ;
         standaloneModal( ) ;
         AddRow37111( ) ;
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
            E11372 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z1077BoletosId = A1077BoletosId;
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

      protected void CONFIRM_370( )
      {
         BeforeValidate37111( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls37111( ) ;
            }
            else
            {
               CheckExtendedTable37111( ) ;
               if ( AnyError == 0 )
               {
                  ZM37111( 17) ;
                  ZM37111( 18) ;
                  ZM37111( 19) ;
                  ZM37111( 20) ;
                  ZM37111( 21) ;
                  ZM37111( 22) ;
               }
               CloseExtendedTableCursors37111( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12372( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV22Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV23GXV1 = 1;
            while ( AV23GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV23GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "CarteiraDeCobrancaId") == 0 )
               {
                  AV11Insert_CarteiraDeCobrancaId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "TituloId") == 0 )
               {
                  AV12Insert_TituloId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV23GXV1 = (int)(AV23GXV1+1);
            }
         }
      }

      protected void E11372( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM37111( short GX_JID )
      {
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            Z1117BoletosResgitroId = A1117BoletosResgitroId;
            Z1099BoletosCreatedAt = A1099BoletosCreatedAt;
            Z1100BoletosUpdatedAt = A1100BoletosUpdatedAt;
            Z1078BoletosNossoNumero = A1078BoletosNossoNumero;
            Z1079BoletosSeuNumero = A1079BoletosSeuNumero;
            Z1080BoletosNumero = A1080BoletosNumero;
            Z1081BoletosLinhaDigitavel = A1081BoletosLinhaDigitavel;
            Z1082BoletosCodigoDeBarras = A1082BoletosCodigoDeBarras;
            Z1083BoletosStatus = A1083BoletosStatus;
            Z1084BoletosDataEmissao = A1084BoletosDataEmissao;
            Z1085BoletosDataVencimento = A1085BoletosDataVencimento;
            Z1086BoletosDataRegistro = A1086BoletosDataRegistro;
            Z1087BoletosDataPagamento = A1087BoletosDataPagamento;
            Z1088BoletosDataBaixa = A1088BoletosDataBaixa;
            Z1089BoletosValorNominal = A1089BoletosValorNominal;
            Z1090BoletosValorPago = A1090BoletosValorPago;
            Z1091BoletosValorDesconto = A1091BoletosValorDesconto;
            Z1092BoletosValorJuros = A1092BoletosValorJuros;
            Z1093BoletosValorMulta = A1093BoletosValorMulta;
            Z1094BoletosSacadoNome = A1094BoletosSacadoNome;
            Z1095BoletosSacadoDocumento = A1095BoletosSacadoDocumento;
            Z1096BoletosSacadoTipoDocumento = A1096BoletosSacadoTipoDocumento;
            Z1098BoletosTentativasDeRegistro = A1098BoletosTentativasDeRegistro;
            Z1069CarteiraDeCobrancaId = A1069CarteiraDeCobrancaId;
            Z261TituloId = A261TituloId;
            Z1111CarteiraDeCobrancaValorTotal = A1111CarteiraDeCobrancaValorTotal;
            Z1112CarteiraDeCobrancaValorRecebido = A1112CarteiraDeCobrancaValorRecebido;
            Z1113CarteiraDeCobrancaTotalBoletos = A1113CarteiraDeCobrancaTotalBoletos;
            Z1114CarteiraDeCobrancaTotalBoletosRegistrados = A1114CarteiraDeCobrancaTotalBoletosRegistrados;
            Z1115CarteiraDeCobrancaTotalBoletosExpirados = A1115CarteiraDeCobrancaTotalBoletosExpirados;
            Z1116CarteiraDeCobrancaTotalBoletosCancelados = A1116CarteiraDeCobrancaTotalBoletosCancelados;
         }
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            Z1071CarteiraDeCobrancaNome = A1071CarteiraDeCobrancaNome;
            Z1073CarteiraDeCobrancaConvenio = A1073CarteiraDeCobrancaConvenio;
            Z1074CarteiraDeCobrancaStatus = A1074CarteiraDeCobrancaStatus;
            Z1111CarteiraDeCobrancaValorTotal = A1111CarteiraDeCobrancaValorTotal;
            Z1112CarteiraDeCobrancaValorRecebido = A1112CarteiraDeCobrancaValorRecebido;
            Z1113CarteiraDeCobrancaTotalBoletos = A1113CarteiraDeCobrancaTotalBoletos;
            Z1114CarteiraDeCobrancaTotalBoletosRegistrados = A1114CarteiraDeCobrancaTotalBoletosRegistrados;
            Z1115CarteiraDeCobrancaTotalBoletosExpirados = A1115CarteiraDeCobrancaTotalBoletosExpirados;
            Z1116CarteiraDeCobrancaTotalBoletosCancelados = A1116CarteiraDeCobrancaTotalBoletosCancelados;
         }
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            Z1111CarteiraDeCobrancaValorTotal = A1111CarteiraDeCobrancaValorTotal;
            Z1112CarteiraDeCobrancaValorRecebido = A1112CarteiraDeCobrancaValorRecebido;
            Z1113CarteiraDeCobrancaTotalBoletos = A1113CarteiraDeCobrancaTotalBoletos;
            Z1114CarteiraDeCobrancaTotalBoletosRegistrados = A1114CarteiraDeCobrancaTotalBoletosRegistrados;
            Z1115CarteiraDeCobrancaTotalBoletosExpirados = A1115CarteiraDeCobrancaTotalBoletosExpirados;
            Z1116CarteiraDeCobrancaTotalBoletosCancelados = A1116CarteiraDeCobrancaTotalBoletosCancelados;
         }
         if ( ( GX_JID == 19 ) || ( GX_JID == 0 ) )
         {
            Z1111CarteiraDeCobrancaValorTotal = A1111CarteiraDeCobrancaValorTotal;
            Z1112CarteiraDeCobrancaValorRecebido = A1112CarteiraDeCobrancaValorRecebido;
            Z1113CarteiraDeCobrancaTotalBoletos = A1113CarteiraDeCobrancaTotalBoletos;
            Z1114CarteiraDeCobrancaTotalBoletosRegistrados = A1114CarteiraDeCobrancaTotalBoletosRegistrados;
            Z1115CarteiraDeCobrancaTotalBoletosExpirados = A1115CarteiraDeCobrancaTotalBoletosExpirados;
            Z1116CarteiraDeCobrancaTotalBoletosCancelados = A1116CarteiraDeCobrancaTotalBoletosCancelados;
         }
         if ( ( GX_JID == 20 ) || ( GX_JID == 0 ) )
         {
            Z1111CarteiraDeCobrancaValorTotal = A1111CarteiraDeCobrancaValorTotal;
            Z1112CarteiraDeCobrancaValorRecebido = A1112CarteiraDeCobrancaValorRecebido;
            Z1113CarteiraDeCobrancaTotalBoletos = A1113CarteiraDeCobrancaTotalBoletos;
            Z1114CarteiraDeCobrancaTotalBoletosRegistrados = A1114CarteiraDeCobrancaTotalBoletosRegistrados;
            Z1115CarteiraDeCobrancaTotalBoletosExpirados = A1115CarteiraDeCobrancaTotalBoletosExpirados;
            Z1116CarteiraDeCobrancaTotalBoletosCancelados = A1116CarteiraDeCobrancaTotalBoletosCancelados;
         }
         if ( ( GX_JID == 21 ) || ( GX_JID == 0 ) )
         {
            Z1111CarteiraDeCobrancaValorTotal = A1111CarteiraDeCobrancaValorTotal;
            Z1112CarteiraDeCobrancaValorRecebido = A1112CarteiraDeCobrancaValorRecebido;
            Z1113CarteiraDeCobrancaTotalBoletos = A1113CarteiraDeCobrancaTotalBoletos;
            Z1114CarteiraDeCobrancaTotalBoletosRegistrados = A1114CarteiraDeCobrancaTotalBoletosRegistrados;
            Z1115CarteiraDeCobrancaTotalBoletosExpirados = A1115CarteiraDeCobrancaTotalBoletosExpirados;
            Z1116CarteiraDeCobrancaTotalBoletosCancelados = A1116CarteiraDeCobrancaTotalBoletosCancelados;
         }
         if ( ( GX_JID == 22 ) || ( GX_JID == 0 ) )
         {
            Z1111CarteiraDeCobrancaValorTotal = A1111CarteiraDeCobrancaValorTotal;
            Z1112CarteiraDeCobrancaValorRecebido = A1112CarteiraDeCobrancaValorRecebido;
            Z1113CarteiraDeCobrancaTotalBoletos = A1113CarteiraDeCobrancaTotalBoletos;
            Z1114CarteiraDeCobrancaTotalBoletosRegistrados = A1114CarteiraDeCobrancaTotalBoletosRegistrados;
            Z1115CarteiraDeCobrancaTotalBoletosExpirados = A1115CarteiraDeCobrancaTotalBoletosExpirados;
            Z1116CarteiraDeCobrancaTotalBoletosCancelados = A1116CarteiraDeCobrancaTotalBoletosCancelados;
         }
         if ( GX_JID == -16 )
         {
            Z1077BoletosId = A1077BoletosId;
            Z1117BoletosResgitroId = A1117BoletosResgitroId;
            Z1099BoletosCreatedAt = A1099BoletosCreatedAt;
            Z1100BoletosUpdatedAt = A1100BoletosUpdatedAt;
            Z1078BoletosNossoNumero = A1078BoletosNossoNumero;
            Z1079BoletosSeuNumero = A1079BoletosSeuNumero;
            Z1080BoletosNumero = A1080BoletosNumero;
            Z1081BoletosLinhaDigitavel = A1081BoletosLinhaDigitavel;
            Z1082BoletosCodigoDeBarras = A1082BoletosCodigoDeBarras;
            Z1083BoletosStatus = A1083BoletosStatus;
            Z1084BoletosDataEmissao = A1084BoletosDataEmissao;
            Z1085BoletosDataVencimento = A1085BoletosDataVencimento;
            Z1086BoletosDataRegistro = A1086BoletosDataRegistro;
            Z1087BoletosDataPagamento = A1087BoletosDataPagamento;
            Z1088BoletosDataBaixa = A1088BoletosDataBaixa;
            Z1089BoletosValorNominal = A1089BoletosValorNominal;
            Z1090BoletosValorPago = A1090BoletosValorPago;
            Z1091BoletosValorDesconto = A1091BoletosValorDesconto;
            Z1092BoletosValorJuros = A1092BoletosValorJuros;
            Z1093BoletosValorMulta = A1093BoletosValorMulta;
            Z1094BoletosSacadoNome = A1094BoletosSacadoNome;
            Z1095BoletosSacadoDocumento = A1095BoletosSacadoDocumento;
            Z1096BoletosSacadoTipoDocumento = A1096BoletosSacadoTipoDocumento;
            Z1097BoletosMensagemDeErro = A1097BoletosMensagemDeErro;
            Z1098BoletosTentativasDeRegistro = A1098BoletosTentativasDeRegistro;
            Z1069CarteiraDeCobrancaId = A1069CarteiraDeCobrancaId;
            Z261TituloId = A261TituloId;
            Z1071CarteiraDeCobrancaNome = A1071CarteiraDeCobrancaNome;
            Z1073CarteiraDeCobrancaConvenio = A1073CarteiraDeCobrancaConvenio;
            Z1074CarteiraDeCobrancaStatus = A1074CarteiraDeCobrancaStatus;
            Z1112CarteiraDeCobrancaValorRecebido = A1112CarteiraDeCobrancaValorRecebido;
            Z1111CarteiraDeCobrancaValorTotal = A1111CarteiraDeCobrancaValorTotal;
            Z1113CarteiraDeCobrancaTotalBoletos = A1113CarteiraDeCobrancaTotalBoletos;
            Z1114CarteiraDeCobrancaTotalBoletosRegistrados = A1114CarteiraDeCobrancaTotalBoletosRegistrados;
            Z1115CarteiraDeCobrancaTotalBoletosExpirados = A1115CarteiraDeCobrancaTotalBoletosExpirados;
            Z1116CarteiraDeCobrancaTotalBoletosCancelados = A1116CarteiraDeCobrancaTotalBoletosCancelados;
         }
      }

      protected void standaloneNotModal( )
      {
         AV22Pgmname = "Boleto_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A1117BoletosResgitroId) )
         {
            A1117BoletosResgitroId = Guid.NewGuid( );
            n1117BoletosResgitroId = false;
         }
         if ( IsIns( )  )
         {
            A1099BoletosCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n1099BoletosCreatedAt = false;
         }
         if ( IsUpd( )  )
         {
            A1100BoletosUpdatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n1100BoletosUpdatedAt = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load37111( )
      {
         /* Using cursor BC003718 */
         pr_default.execute(8, new Object[] {n1077BoletosId, A1077BoletosId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound111 = 1;
            A1117BoletosResgitroId = BC003718_A1117BoletosResgitroId[0];
            n1117BoletosResgitroId = BC003718_n1117BoletosResgitroId[0];
            A1099BoletosCreatedAt = BC003718_A1099BoletosCreatedAt[0];
            n1099BoletosCreatedAt = BC003718_n1099BoletosCreatedAt[0];
            A1100BoletosUpdatedAt = BC003718_A1100BoletosUpdatedAt[0];
            n1100BoletosUpdatedAt = BC003718_n1100BoletosUpdatedAt[0];
            A1078BoletosNossoNumero = BC003718_A1078BoletosNossoNumero[0];
            n1078BoletosNossoNumero = BC003718_n1078BoletosNossoNumero[0];
            A1079BoletosSeuNumero = BC003718_A1079BoletosSeuNumero[0];
            n1079BoletosSeuNumero = BC003718_n1079BoletosSeuNumero[0];
            A1080BoletosNumero = BC003718_A1080BoletosNumero[0];
            n1080BoletosNumero = BC003718_n1080BoletosNumero[0];
            A1081BoletosLinhaDigitavel = BC003718_A1081BoletosLinhaDigitavel[0];
            n1081BoletosLinhaDigitavel = BC003718_n1081BoletosLinhaDigitavel[0];
            A1082BoletosCodigoDeBarras = BC003718_A1082BoletosCodigoDeBarras[0];
            n1082BoletosCodigoDeBarras = BC003718_n1082BoletosCodigoDeBarras[0];
            A1083BoletosStatus = BC003718_A1083BoletosStatus[0];
            n1083BoletosStatus = BC003718_n1083BoletosStatus[0];
            A1084BoletosDataEmissao = BC003718_A1084BoletosDataEmissao[0];
            n1084BoletosDataEmissao = BC003718_n1084BoletosDataEmissao[0];
            A1085BoletosDataVencimento = BC003718_A1085BoletosDataVencimento[0];
            n1085BoletosDataVencimento = BC003718_n1085BoletosDataVencimento[0];
            A1086BoletosDataRegistro = BC003718_A1086BoletosDataRegistro[0];
            n1086BoletosDataRegistro = BC003718_n1086BoletosDataRegistro[0];
            A1087BoletosDataPagamento = BC003718_A1087BoletosDataPagamento[0];
            n1087BoletosDataPagamento = BC003718_n1087BoletosDataPagamento[0];
            A1088BoletosDataBaixa = BC003718_A1088BoletosDataBaixa[0];
            n1088BoletosDataBaixa = BC003718_n1088BoletosDataBaixa[0];
            A1089BoletosValorNominal = BC003718_A1089BoletosValorNominal[0];
            n1089BoletosValorNominal = BC003718_n1089BoletosValorNominal[0];
            A1090BoletosValorPago = BC003718_A1090BoletosValorPago[0];
            n1090BoletosValorPago = BC003718_n1090BoletosValorPago[0];
            A1091BoletosValorDesconto = BC003718_A1091BoletosValorDesconto[0];
            n1091BoletosValorDesconto = BC003718_n1091BoletosValorDesconto[0];
            A1092BoletosValorJuros = BC003718_A1092BoletosValorJuros[0];
            n1092BoletosValorJuros = BC003718_n1092BoletosValorJuros[0];
            A1093BoletosValorMulta = BC003718_A1093BoletosValorMulta[0];
            n1093BoletosValorMulta = BC003718_n1093BoletosValorMulta[0];
            A1094BoletosSacadoNome = BC003718_A1094BoletosSacadoNome[0];
            n1094BoletosSacadoNome = BC003718_n1094BoletosSacadoNome[0];
            A1095BoletosSacadoDocumento = BC003718_A1095BoletosSacadoDocumento[0];
            n1095BoletosSacadoDocumento = BC003718_n1095BoletosSacadoDocumento[0];
            A1096BoletosSacadoTipoDocumento = BC003718_A1096BoletosSacadoTipoDocumento[0];
            n1096BoletosSacadoTipoDocumento = BC003718_n1096BoletosSacadoTipoDocumento[0];
            A1097BoletosMensagemDeErro = BC003718_A1097BoletosMensagemDeErro[0];
            n1097BoletosMensagemDeErro = BC003718_n1097BoletosMensagemDeErro[0];
            A1098BoletosTentativasDeRegistro = BC003718_A1098BoletosTentativasDeRegistro[0];
            n1098BoletosTentativasDeRegistro = BC003718_n1098BoletosTentativasDeRegistro[0];
            A1071CarteiraDeCobrancaNome = BC003718_A1071CarteiraDeCobrancaNome[0];
            n1071CarteiraDeCobrancaNome = BC003718_n1071CarteiraDeCobrancaNome[0];
            A1073CarteiraDeCobrancaConvenio = BC003718_A1073CarteiraDeCobrancaConvenio[0];
            n1073CarteiraDeCobrancaConvenio = BC003718_n1073CarteiraDeCobrancaConvenio[0];
            A1074CarteiraDeCobrancaStatus = BC003718_A1074CarteiraDeCobrancaStatus[0];
            n1074CarteiraDeCobrancaStatus = BC003718_n1074CarteiraDeCobrancaStatus[0];
            A1069CarteiraDeCobrancaId = BC003718_A1069CarteiraDeCobrancaId[0];
            n1069CarteiraDeCobrancaId = BC003718_n1069CarteiraDeCobrancaId[0];
            A261TituloId = BC003718_A261TituloId[0];
            n261TituloId = BC003718_n261TituloId[0];
            A1112CarteiraDeCobrancaValorRecebido = BC003718_A1112CarteiraDeCobrancaValorRecebido[0];
            A1111CarteiraDeCobrancaValorTotal = BC003718_A1111CarteiraDeCobrancaValorTotal[0];
            A1113CarteiraDeCobrancaTotalBoletos = BC003718_A1113CarteiraDeCobrancaTotalBoletos[0];
            A1114CarteiraDeCobrancaTotalBoletosRegistrados = BC003718_A1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
            n1114CarteiraDeCobrancaTotalBoletosRegistrados = BC003718_n1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
            A1115CarteiraDeCobrancaTotalBoletosExpirados = BC003718_A1115CarteiraDeCobrancaTotalBoletosExpirados[0];
            n1115CarteiraDeCobrancaTotalBoletosExpirados = BC003718_n1115CarteiraDeCobrancaTotalBoletosExpirados[0];
            A1116CarteiraDeCobrancaTotalBoletosCancelados = BC003718_A1116CarteiraDeCobrancaTotalBoletosCancelados[0];
            n1116CarteiraDeCobrancaTotalBoletosCancelados = BC003718_n1116CarteiraDeCobrancaTotalBoletosCancelados[0];
            ZM37111( -16) ;
         }
         pr_default.close(8);
         OnLoadActions37111( ) ;
      }

      protected void OnLoadActions37111( )
      {
      }

      protected void CheckExtendedTable37111( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00374 */
         pr_default.execute(2, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A1069CarteiraDeCobrancaId) ) )
            {
               GX_msglist.addItem("Não existe 'CarteiraDeCobranca'.", "ForeignKeyNotFound", 1, "CARTEIRADECOBRANCAID");
               AnyError = 1;
            }
         }
         A1071CarteiraDeCobrancaNome = BC00374_A1071CarteiraDeCobrancaNome[0];
         n1071CarteiraDeCobrancaNome = BC00374_n1071CarteiraDeCobrancaNome[0];
         A1073CarteiraDeCobrancaConvenio = BC00374_A1073CarteiraDeCobrancaConvenio[0];
         n1073CarteiraDeCobrancaConvenio = BC00374_n1073CarteiraDeCobrancaConvenio[0];
         A1074CarteiraDeCobrancaStatus = BC00374_A1074CarteiraDeCobrancaStatus[0];
         n1074CarteiraDeCobrancaStatus = BC00374_n1074CarteiraDeCobrancaStatus[0];
         pr_default.close(2);
         /* Using cursor BC00377 */
         pr_default.execute(4, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            A1112CarteiraDeCobrancaValorRecebido = BC00377_A1112CarteiraDeCobrancaValorRecebido[0];
            A1111CarteiraDeCobrancaValorTotal = BC00377_A1111CarteiraDeCobrancaValorTotal[0];
            A1113CarteiraDeCobrancaTotalBoletos = BC00377_A1113CarteiraDeCobrancaTotalBoletos[0];
         }
         else
         {
            A1112CarteiraDeCobrancaValorRecebido = 0;
            A1111CarteiraDeCobrancaValorTotal = 0;
            A1113CarteiraDeCobrancaTotalBoletos = 0;
         }
         pr_default.close(4);
         if ( ( A1112CarteiraDeCobrancaValorRecebido < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         if ( ( A1111CarteiraDeCobrancaValorTotal < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00379 */
         pr_default.execute(5, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            A1114CarteiraDeCobrancaTotalBoletosRegistrados = BC00379_A1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
            n1114CarteiraDeCobrancaTotalBoletosRegistrados = BC00379_n1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
         }
         else
         {
            A1114CarteiraDeCobrancaTotalBoletosRegistrados = 0;
            n1114CarteiraDeCobrancaTotalBoletosRegistrados = false;
         }
         pr_default.close(5);
         /* Using cursor BC003711 */
         pr_default.execute(6, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            A1115CarteiraDeCobrancaTotalBoletosExpirados = BC003711_A1115CarteiraDeCobrancaTotalBoletosExpirados[0];
            n1115CarteiraDeCobrancaTotalBoletosExpirados = BC003711_n1115CarteiraDeCobrancaTotalBoletosExpirados[0];
         }
         else
         {
            A1115CarteiraDeCobrancaTotalBoletosExpirados = 0;
            n1115CarteiraDeCobrancaTotalBoletosExpirados = false;
         }
         pr_default.close(6);
         /* Using cursor BC003713 */
         pr_default.execute(7, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            A1116CarteiraDeCobrancaTotalBoletosCancelados = BC003713_A1116CarteiraDeCobrancaTotalBoletosCancelados[0];
            n1116CarteiraDeCobrancaTotalBoletosCancelados = BC003713_n1116CarteiraDeCobrancaTotalBoletosCancelados[0];
         }
         else
         {
            A1116CarteiraDeCobrancaTotalBoletosCancelados = 0;
            n1116CarteiraDeCobrancaTotalBoletosCancelados = false;
         }
         pr_default.close(7);
         /* Using cursor BC00375 */
         pr_default.execute(3, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A261TituloId) ) )
            {
               GX_msglist.addItem("Não existe 'Titulo'.", "ForeignKeyNotFound", 1, "TITULOID");
               AnyError = 1;
            }
         }
         pr_default.close(3);
         if ( ! ( ( StringUtil.StrCmp(A1083BoletosStatus, "RASCUNHO") == 0 ) || ( StringUtil.StrCmp(A1083BoletosStatus, "REGISTRADO") == 0 ) || ( StringUtil.StrCmp(A1083BoletosStatus, "LIQUIDADO") == 0 ) || ( StringUtil.StrCmp(A1083BoletosStatus, "BAIXADO") == 0 ) || ( StringUtil.StrCmp(A1083BoletosStatus, "VENCIDO") == 0 ) || ( StringUtil.StrCmp(A1083BoletosStatus, "ERRO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A1083BoletosStatus)) ) )
         {
            GX_msglist.addItem("Campo Boletos Status fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ( A1089BoletosValorNominal < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         if ( ( A1090BoletosValorPago < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         if ( ( A1091BoletosValorDesconto < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         if ( ( A1092BoletosValorJuros < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         if ( ( A1093BoletosValorMulta < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A1096BoletosSacadoTipoDocumento, "CPF") == 0 ) || ( StringUtil.StrCmp(A1096BoletosSacadoTipoDocumento, "CNPJ") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A1096BoletosSacadoTipoDocumento)) ) )
         {
            GX_msglist.addItem("Campo Boletos Sacado Tipo Documento fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors37111( )
      {
         pr_default.close(2);
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(6);
         pr_default.close(7);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey37111( )
      {
         /* Using cursor BC003719 */
         pr_default.execute(9, new Object[] {n1077BoletosId, A1077BoletosId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound111 = 1;
         }
         else
         {
            RcdFound111 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00373 */
         pr_default.execute(1, new Object[] {n1077BoletosId, A1077BoletosId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM37111( 16) ;
            RcdFound111 = 1;
            A1077BoletosId = BC00373_A1077BoletosId[0];
            n1077BoletosId = BC00373_n1077BoletosId[0];
            A1117BoletosResgitroId = BC00373_A1117BoletosResgitroId[0];
            n1117BoletosResgitroId = BC00373_n1117BoletosResgitroId[0];
            A1099BoletosCreatedAt = BC00373_A1099BoletosCreatedAt[0];
            n1099BoletosCreatedAt = BC00373_n1099BoletosCreatedAt[0];
            A1100BoletosUpdatedAt = BC00373_A1100BoletosUpdatedAt[0];
            n1100BoletosUpdatedAt = BC00373_n1100BoletosUpdatedAt[0];
            A1078BoletosNossoNumero = BC00373_A1078BoletosNossoNumero[0];
            n1078BoletosNossoNumero = BC00373_n1078BoletosNossoNumero[0];
            A1079BoletosSeuNumero = BC00373_A1079BoletosSeuNumero[0];
            n1079BoletosSeuNumero = BC00373_n1079BoletosSeuNumero[0];
            A1080BoletosNumero = BC00373_A1080BoletosNumero[0];
            n1080BoletosNumero = BC00373_n1080BoletosNumero[0];
            A1081BoletosLinhaDigitavel = BC00373_A1081BoletosLinhaDigitavel[0];
            n1081BoletosLinhaDigitavel = BC00373_n1081BoletosLinhaDigitavel[0];
            A1082BoletosCodigoDeBarras = BC00373_A1082BoletosCodigoDeBarras[0];
            n1082BoletosCodigoDeBarras = BC00373_n1082BoletosCodigoDeBarras[0];
            A1083BoletosStatus = BC00373_A1083BoletosStatus[0];
            n1083BoletosStatus = BC00373_n1083BoletosStatus[0];
            A1084BoletosDataEmissao = BC00373_A1084BoletosDataEmissao[0];
            n1084BoletosDataEmissao = BC00373_n1084BoletosDataEmissao[0];
            A1085BoletosDataVencimento = BC00373_A1085BoletosDataVencimento[0];
            n1085BoletosDataVencimento = BC00373_n1085BoletosDataVencimento[0];
            A1086BoletosDataRegistro = BC00373_A1086BoletosDataRegistro[0];
            n1086BoletosDataRegistro = BC00373_n1086BoletosDataRegistro[0];
            A1087BoletosDataPagamento = BC00373_A1087BoletosDataPagamento[0];
            n1087BoletosDataPagamento = BC00373_n1087BoletosDataPagamento[0];
            A1088BoletosDataBaixa = BC00373_A1088BoletosDataBaixa[0];
            n1088BoletosDataBaixa = BC00373_n1088BoletosDataBaixa[0];
            A1089BoletosValorNominal = BC00373_A1089BoletosValorNominal[0];
            n1089BoletosValorNominal = BC00373_n1089BoletosValorNominal[0];
            A1090BoletosValorPago = BC00373_A1090BoletosValorPago[0];
            n1090BoletosValorPago = BC00373_n1090BoletosValorPago[0];
            A1091BoletosValorDesconto = BC00373_A1091BoletosValorDesconto[0];
            n1091BoletosValorDesconto = BC00373_n1091BoletosValorDesconto[0];
            A1092BoletosValorJuros = BC00373_A1092BoletosValorJuros[0];
            n1092BoletosValorJuros = BC00373_n1092BoletosValorJuros[0];
            A1093BoletosValorMulta = BC00373_A1093BoletosValorMulta[0];
            n1093BoletosValorMulta = BC00373_n1093BoletosValorMulta[0];
            A1094BoletosSacadoNome = BC00373_A1094BoletosSacadoNome[0];
            n1094BoletosSacadoNome = BC00373_n1094BoletosSacadoNome[0];
            A1095BoletosSacadoDocumento = BC00373_A1095BoletosSacadoDocumento[0];
            n1095BoletosSacadoDocumento = BC00373_n1095BoletosSacadoDocumento[0];
            A1096BoletosSacadoTipoDocumento = BC00373_A1096BoletosSacadoTipoDocumento[0];
            n1096BoletosSacadoTipoDocumento = BC00373_n1096BoletosSacadoTipoDocumento[0];
            A1097BoletosMensagemDeErro = BC00373_A1097BoletosMensagemDeErro[0];
            n1097BoletosMensagemDeErro = BC00373_n1097BoletosMensagemDeErro[0];
            A1098BoletosTentativasDeRegistro = BC00373_A1098BoletosTentativasDeRegistro[0];
            n1098BoletosTentativasDeRegistro = BC00373_n1098BoletosTentativasDeRegistro[0];
            A1069CarteiraDeCobrancaId = BC00373_A1069CarteiraDeCobrancaId[0];
            n1069CarteiraDeCobrancaId = BC00373_n1069CarteiraDeCobrancaId[0];
            A261TituloId = BC00373_A261TituloId[0];
            n261TituloId = BC00373_n261TituloId[0];
            Z1077BoletosId = A1077BoletosId;
            sMode111 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load37111( ) ;
            if ( AnyError == 1 )
            {
               RcdFound111 = 0;
               InitializeNonKey37111( ) ;
            }
            Gx_mode = sMode111;
         }
         else
         {
            RcdFound111 = 0;
            InitializeNonKey37111( ) ;
            sMode111 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode111;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey37111( ) ;
         if ( RcdFound111 == 0 )
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
         CONFIRM_370( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency37111( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00372 */
            pr_default.execute(0, new Object[] {n1077BoletosId, A1077BoletosId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Boleto"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z1117BoletosResgitroId != BC00372_A1117BoletosResgitroId[0] ) || ( Z1099BoletosCreatedAt != BC00372_A1099BoletosCreatedAt[0] ) || ( Z1100BoletosUpdatedAt != BC00372_A1100BoletosUpdatedAt[0] ) || ( StringUtil.StrCmp(Z1078BoletosNossoNumero, BC00372_A1078BoletosNossoNumero[0]) != 0 ) || ( StringUtil.StrCmp(Z1079BoletosSeuNumero, BC00372_A1079BoletosSeuNumero[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1080BoletosNumero, BC00372_A1080BoletosNumero[0]) != 0 ) || ( StringUtil.StrCmp(Z1081BoletosLinhaDigitavel, BC00372_A1081BoletosLinhaDigitavel[0]) != 0 ) || ( StringUtil.StrCmp(Z1082BoletosCodigoDeBarras, BC00372_A1082BoletosCodigoDeBarras[0]) != 0 ) || ( StringUtil.StrCmp(Z1083BoletosStatus, BC00372_A1083BoletosStatus[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z1084BoletosDataEmissao ) != DateTimeUtil.ResetTime ( BC00372_A1084BoletosDataEmissao[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z1085BoletosDataVencimento ) != DateTimeUtil.ResetTime ( BC00372_A1085BoletosDataVencimento[0] ) ) || ( Z1086BoletosDataRegistro != BC00372_A1086BoletosDataRegistro[0] ) || ( DateTimeUtil.ResetTime ( Z1087BoletosDataPagamento ) != DateTimeUtil.ResetTime ( BC00372_A1087BoletosDataPagamento[0] ) ) || ( DateTimeUtil.ResetTime ( Z1088BoletosDataBaixa ) != DateTimeUtil.ResetTime ( BC00372_A1088BoletosDataBaixa[0] ) ) || ( Z1089BoletosValorNominal != BC00372_A1089BoletosValorNominal[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1090BoletosValorPago != BC00372_A1090BoletosValorPago[0] ) || ( Z1091BoletosValorDesconto != BC00372_A1091BoletosValorDesconto[0] ) || ( Z1092BoletosValorJuros != BC00372_A1092BoletosValorJuros[0] ) || ( Z1093BoletosValorMulta != BC00372_A1093BoletosValorMulta[0] ) || ( StringUtil.StrCmp(Z1094BoletosSacadoNome, BC00372_A1094BoletosSacadoNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1095BoletosSacadoDocumento, BC00372_A1095BoletosSacadoDocumento[0]) != 0 ) || ( StringUtil.StrCmp(Z1096BoletosSacadoTipoDocumento, BC00372_A1096BoletosSacadoTipoDocumento[0]) != 0 ) || ( Z1098BoletosTentativasDeRegistro != BC00372_A1098BoletosTentativasDeRegistro[0] ) || ( Z1069CarteiraDeCobrancaId != BC00372_A1069CarteiraDeCobrancaId[0] ) || ( Z261TituloId != BC00372_A261TituloId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Boleto"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert37111( )
      {
         BeforeValidate37111( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable37111( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM37111( 0) ;
            CheckOptimisticConcurrency37111( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm37111( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert37111( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC003720 */
                     pr_default.execute(10, new Object[] {n1117BoletosResgitroId, A1117BoletosResgitroId, n1099BoletosCreatedAt, A1099BoletosCreatedAt, n1100BoletosUpdatedAt, A1100BoletosUpdatedAt, n1078BoletosNossoNumero, A1078BoletosNossoNumero, n1079BoletosSeuNumero, A1079BoletosSeuNumero, n1080BoletosNumero, A1080BoletosNumero, n1081BoletosLinhaDigitavel, A1081BoletosLinhaDigitavel, n1082BoletosCodigoDeBarras, A1082BoletosCodigoDeBarras, n1083BoletosStatus, A1083BoletosStatus, n1084BoletosDataEmissao, A1084BoletosDataEmissao, n1085BoletosDataVencimento, A1085BoletosDataVencimento, n1086BoletosDataRegistro, A1086BoletosDataRegistro, n1087BoletosDataPagamento, A1087BoletosDataPagamento, n1088BoletosDataBaixa, A1088BoletosDataBaixa, n1089BoletosValorNominal, A1089BoletosValorNominal, n1090BoletosValorPago, A1090BoletosValorPago, n1091BoletosValorDesconto, A1091BoletosValorDesconto, n1092BoletosValorJuros, A1092BoletosValorJuros, n1093BoletosValorMulta, A1093BoletosValorMulta, n1094BoletosSacadoNome, A1094BoletosSacadoNome, n1095BoletosSacadoDocumento, A1095BoletosSacadoDocumento, n1096BoletosSacadoTipoDocumento, A1096BoletosSacadoTipoDocumento, n1097BoletosMensagemDeErro, A1097BoletosMensagemDeErro, n1098BoletosTentativasDeRegistro, A1098BoletosTentativasDeRegistro, n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId, n261TituloId, A261TituloId});
                     pr_default.close(10);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC003721 */
                     pr_default.execute(11);
                     A1077BoletosId = BC003721_A1077BoletosId[0];
                     n1077BoletosId = BC003721_n1077BoletosId[0];
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Boleto");
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
               Load37111( ) ;
            }
            EndLevel37111( ) ;
         }
         CloseExtendedTableCursors37111( ) ;
      }

      protected void Update37111( )
      {
         BeforeValidate37111( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable37111( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency37111( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm37111( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate37111( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC003722 */
                     pr_default.execute(12, new Object[] {n1117BoletosResgitroId, A1117BoletosResgitroId, n1099BoletosCreatedAt, A1099BoletosCreatedAt, n1100BoletosUpdatedAt, A1100BoletosUpdatedAt, n1078BoletosNossoNumero, A1078BoletosNossoNumero, n1079BoletosSeuNumero, A1079BoletosSeuNumero, n1080BoletosNumero, A1080BoletosNumero, n1081BoletosLinhaDigitavel, A1081BoletosLinhaDigitavel, n1082BoletosCodigoDeBarras, A1082BoletosCodigoDeBarras, n1083BoletosStatus, A1083BoletosStatus, n1084BoletosDataEmissao, A1084BoletosDataEmissao, n1085BoletosDataVencimento, A1085BoletosDataVencimento, n1086BoletosDataRegistro, A1086BoletosDataRegistro, n1087BoletosDataPagamento, A1087BoletosDataPagamento, n1088BoletosDataBaixa, A1088BoletosDataBaixa, n1089BoletosValorNominal, A1089BoletosValorNominal, n1090BoletosValorPago, A1090BoletosValorPago, n1091BoletosValorDesconto, A1091BoletosValorDesconto, n1092BoletosValorJuros, A1092BoletosValorJuros, n1093BoletosValorMulta, A1093BoletosValorMulta, n1094BoletosSacadoNome, A1094BoletosSacadoNome, n1095BoletosSacadoDocumento, A1095BoletosSacadoDocumento, n1096BoletosSacadoTipoDocumento, A1096BoletosSacadoTipoDocumento, n1097BoletosMensagemDeErro, A1097BoletosMensagemDeErro, n1098BoletosTentativasDeRegistro, A1098BoletosTentativasDeRegistro, n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId, n261TituloId, A261TituloId, n1077BoletosId, A1077BoletosId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Boleto");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Boleto"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate37111( ) ;
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
            EndLevel37111( ) ;
         }
         CloseExtendedTableCursors37111( ) ;
      }

      protected void DeferredUpdate37111( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate37111( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency37111( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls37111( ) ;
            AfterConfirm37111( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete37111( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC003723 */
                  pr_default.execute(13, new Object[] {n1077BoletosId, A1077BoletosId});
                  pr_default.close(13);
                  pr_default.SmartCacheProvider.SetUpdated("Boleto");
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
         sMode111 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel37111( ) ;
         Gx_mode = sMode111;
      }

      protected void OnDeleteControls37111( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC003724 */
            pr_default.execute(14, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
            A1071CarteiraDeCobrancaNome = BC003724_A1071CarteiraDeCobrancaNome[0];
            n1071CarteiraDeCobrancaNome = BC003724_n1071CarteiraDeCobrancaNome[0];
            A1073CarteiraDeCobrancaConvenio = BC003724_A1073CarteiraDeCobrancaConvenio[0];
            n1073CarteiraDeCobrancaConvenio = BC003724_n1073CarteiraDeCobrancaConvenio[0];
            A1074CarteiraDeCobrancaStatus = BC003724_A1074CarteiraDeCobrancaStatus[0];
            n1074CarteiraDeCobrancaStatus = BC003724_n1074CarteiraDeCobrancaStatus[0];
            pr_default.close(14);
            /* Using cursor BC003726 */
            pr_default.execute(15, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               A1112CarteiraDeCobrancaValorRecebido = BC003726_A1112CarteiraDeCobrancaValorRecebido[0];
               A1111CarteiraDeCobrancaValorTotal = BC003726_A1111CarteiraDeCobrancaValorTotal[0];
               A1113CarteiraDeCobrancaTotalBoletos = BC003726_A1113CarteiraDeCobrancaTotalBoletos[0];
            }
            else
            {
               A1112CarteiraDeCobrancaValorRecebido = 0;
               A1111CarteiraDeCobrancaValorTotal = 0;
               A1113CarteiraDeCobrancaTotalBoletos = 0;
            }
            pr_default.close(15);
            /* Using cursor BC003728 */
            pr_default.execute(16, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               A1114CarteiraDeCobrancaTotalBoletosRegistrados = BC003728_A1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
               n1114CarteiraDeCobrancaTotalBoletosRegistrados = BC003728_n1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
            }
            else
            {
               A1114CarteiraDeCobrancaTotalBoletosRegistrados = 0;
               n1114CarteiraDeCobrancaTotalBoletosRegistrados = false;
            }
            pr_default.close(16);
            /* Using cursor BC003730 */
            pr_default.execute(17, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               A1115CarteiraDeCobrancaTotalBoletosExpirados = BC003730_A1115CarteiraDeCobrancaTotalBoletosExpirados[0];
               n1115CarteiraDeCobrancaTotalBoletosExpirados = BC003730_n1115CarteiraDeCobrancaTotalBoletosExpirados[0];
            }
            else
            {
               A1115CarteiraDeCobrancaTotalBoletosExpirados = 0;
               n1115CarteiraDeCobrancaTotalBoletosExpirados = false;
            }
            pr_default.close(17);
            /* Using cursor BC003732 */
            pr_default.execute(18, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               A1116CarteiraDeCobrancaTotalBoletosCancelados = BC003732_A1116CarteiraDeCobrancaTotalBoletosCancelados[0];
               n1116CarteiraDeCobrancaTotalBoletosCancelados = BC003732_n1116CarteiraDeCobrancaTotalBoletosCancelados[0];
            }
            else
            {
               A1116CarteiraDeCobrancaTotalBoletosCancelados = 0;
               n1116CarteiraDeCobrancaTotalBoletosCancelados = false;
            }
            pr_default.close(18);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC003733 */
            pr_default.execute(19, new Object[] {n1077BoletosId, A1077BoletosId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"BoletosLog"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
         }
      }

      protected void EndLevel37111( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete37111( ) ;
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

      public void ScanKeyStart37111( )
      {
         /* Scan By routine */
         /* Using cursor BC003738 */
         pr_default.execute(20, new Object[] {n1077BoletosId, A1077BoletosId});
         RcdFound111 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound111 = 1;
            A1077BoletosId = BC003738_A1077BoletosId[0];
            n1077BoletosId = BC003738_n1077BoletosId[0];
            A1117BoletosResgitroId = BC003738_A1117BoletosResgitroId[0];
            n1117BoletosResgitroId = BC003738_n1117BoletosResgitroId[0];
            A1099BoletosCreatedAt = BC003738_A1099BoletosCreatedAt[0];
            n1099BoletosCreatedAt = BC003738_n1099BoletosCreatedAt[0];
            A1100BoletosUpdatedAt = BC003738_A1100BoletosUpdatedAt[0];
            n1100BoletosUpdatedAt = BC003738_n1100BoletosUpdatedAt[0];
            A1078BoletosNossoNumero = BC003738_A1078BoletosNossoNumero[0];
            n1078BoletosNossoNumero = BC003738_n1078BoletosNossoNumero[0];
            A1079BoletosSeuNumero = BC003738_A1079BoletosSeuNumero[0];
            n1079BoletosSeuNumero = BC003738_n1079BoletosSeuNumero[0];
            A1080BoletosNumero = BC003738_A1080BoletosNumero[0];
            n1080BoletosNumero = BC003738_n1080BoletosNumero[0];
            A1081BoletosLinhaDigitavel = BC003738_A1081BoletosLinhaDigitavel[0];
            n1081BoletosLinhaDigitavel = BC003738_n1081BoletosLinhaDigitavel[0];
            A1082BoletosCodigoDeBarras = BC003738_A1082BoletosCodigoDeBarras[0];
            n1082BoletosCodigoDeBarras = BC003738_n1082BoletosCodigoDeBarras[0];
            A1083BoletosStatus = BC003738_A1083BoletosStatus[0];
            n1083BoletosStatus = BC003738_n1083BoletosStatus[0];
            A1084BoletosDataEmissao = BC003738_A1084BoletosDataEmissao[0];
            n1084BoletosDataEmissao = BC003738_n1084BoletosDataEmissao[0];
            A1085BoletosDataVencimento = BC003738_A1085BoletosDataVencimento[0];
            n1085BoletosDataVencimento = BC003738_n1085BoletosDataVencimento[0];
            A1086BoletosDataRegistro = BC003738_A1086BoletosDataRegistro[0];
            n1086BoletosDataRegistro = BC003738_n1086BoletosDataRegistro[0];
            A1087BoletosDataPagamento = BC003738_A1087BoletosDataPagamento[0];
            n1087BoletosDataPagamento = BC003738_n1087BoletosDataPagamento[0];
            A1088BoletosDataBaixa = BC003738_A1088BoletosDataBaixa[0];
            n1088BoletosDataBaixa = BC003738_n1088BoletosDataBaixa[0];
            A1089BoletosValorNominal = BC003738_A1089BoletosValorNominal[0];
            n1089BoletosValorNominal = BC003738_n1089BoletosValorNominal[0];
            A1090BoletosValorPago = BC003738_A1090BoletosValorPago[0];
            n1090BoletosValorPago = BC003738_n1090BoletosValorPago[0];
            A1091BoletosValorDesconto = BC003738_A1091BoletosValorDesconto[0];
            n1091BoletosValorDesconto = BC003738_n1091BoletosValorDesconto[0];
            A1092BoletosValorJuros = BC003738_A1092BoletosValorJuros[0];
            n1092BoletosValorJuros = BC003738_n1092BoletosValorJuros[0];
            A1093BoletosValorMulta = BC003738_A1093BoletosValorMulta[0];
            n1093BoletosValorMulta = BC003738_n1093BoletosValorMulta[0];
            A1094BoletosSacadoNome = BC003738_A1094BoletosSacadoNome[0];
            n1094BoletosSacadoNome = BC003738_n1094BoletosSacadoNome[0];
            A1095BoletosSacadoDocumento = BC003738_A1095BoletosSacadoDocumento[0];
            n1095BoletosSacadoDocumento = BC003738_n1095BoletosSacadoDocumento[0];
            A1096BoletosSacadoTipoDocumento = BC003738_A1096BoletosSacadoTipoDocumento[0];
            n1096BoletosSacadoTipoDocumento = BC003738_n1096BoletosSacadoTipoDocumento[0];
            A1097BoletosMensagemDeErro = BC003738_A1097BoletosMensagemDeErro[0];
            n1097BoletosMensagemDeErro = BC003738_n1097BoletosMensagemDeErro[0];
            A1098BoletosTentativasDeRegistro = BC003738_A1098BoletosTentativasDeRegistro[0];
            n1098BoletosTentativasDeRegistro = BC003738_n1098BoletosTentativasDeRegistro[0];
            A1071CarteiraDeCobrancaNome = BC003738_A1071CarteiraDeCobrancaNome[0];
            n1071CarteiraDeCobrancaNome = BC003738_n1071CarteiraDeCobrancaNome[0];
            A1073CarteiraDeCobrancaConvenio = BC003738_A1073CarteiraDeCobrancaConvenio[0];
            n1073CarteiraDeCobrancaConvenio = BC003738_n1073CarteiraDeCobrancaConvenio[0];
            A1074CarteiraDeCobrancaStatus = BC003738_A1074CarteiraDeCobrancaStatus[0];
            n1074CarteiraDeCobrancaStatus = BC003738_n1074CarteiraDeCobrancaStatus[0];
            A1069CarteiraDeCobrancaId = BC003738_A1069CarteiraDeCobrancaId[0];
            n1069CarteiraDeCobrancaId = BC003738_n1069CarteiraDeCobrancaId[0];
            A261TituloId = BC003738_A261TituloId[0];
            n261TituloId = BC003738_n261TituloId[0];
            A1112CarteiraDeCobrancaValorRecebido = BC003738_A1112CarteiraDeCobrancaValorRecebido[0];
            A1111CarteiraDeCobrancaValorTotal = BC003738_A1111CarteiraDeCobrancaValorTotal[0];
            A1113CarteiraDeCobrancaTotalBoletos = BC003738_A1113CarteiraDeCobrancaTotalBoletos[0];
            A1114CarteiraDeCobrancaTotalBoletosRegistrados = BC003738_A1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
            n1114CarteiraDeCobrancaTotalBoletosRegistrados = BC003738_n1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
            A1115CarteiraDeCobrancaTotalBoletosExpirados = BC003738_A1115CarteiraDeCobrancaTotalBoletosExpirados[0];
            n1115CarteiraDeCobrancaTotalBoletosExpirados = BC003738_n1115CarteiraDeCobrancaTotalBoletosExpirados[0];
            A1116CarteiraDeCobrancaTotalBoletosCancelados = BC003738_A1116CarteiraDeCobrancaTotalBoletosCancelados[0];
            n1116CarteiraDeCobrancaTotalBoletosCancelados = BC003738_n1116CarteiraDeCobrancaTotalBoletosCancelados[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext37111( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound111 = 0;
         ScanKeyLoad37111( ) ;
      }

      protected void ScanKeyLoad37111( )
      {
         sMode111 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound111 = 1;
            A1077BoletosId = BC003738_A1077BoletosId[0];
            n1077BoletosId = BC003738_n1077BoletosId[0];
            A1117BoletosResgitroId = BC003738_A1117BoletosResgitroId[0];
            n1117BoletosResgitroId = BC003738_n1117BoletosResgitroId[0];
            A1099BoletosCreatedAt = BC003738_A1099BoletosCreatedAt[0];
            n1099BoletosCreatedAt = BC003738_n1099BoletosCreatedAt[0];
            A1100BoletosUpdatedAt = BC003738_A1100BoletosUpdatedAt[0];
            n1100BoletosUpdatedAt = BC003738_n1100BoletosUpdatedAt[0];
            A1078BoletosNossoNumero = BC003738_A1078BoletosNossoNumero[0];
            n1078BoletosNossoNumero = BC003738_n1078BoletosNossoNumero[0];
            A1079BoletosSeuNumero = BC003738_A1079BoletosSeuNumero[0];
            n1079BoletosSeuNumero = BC003738_n1079BoletosSeuNumero[0];
            A1080BoletosNumero = BC003738_A1080BoletosNumero[0];
            n1080BoletosNumero = BC003738_n1080BoletosNumero[0];
            A1081BoletosLinhaDigitavel = BC003738_A1081BoletosLinhaDigitavel[0];
            n1081BoletosLinhaDigitavel = BC003738_n1081BoletosLinhaDigitavel[0];
            A1082BoletosCodigoDeBarras = BC003738_A1082BoletosCodigoDeBarras[0];
            n1082BoletosCodigoDeBarras = BC003738_n1082BoletosCodigoDeBarras[0];
            A1083BoletosStatus = BC003738_A1083BoletosStatus[0];
            n1083BoletosStatus = BC003738_n1083BoletosStatus[0];
            A1084BoletosDataEmissao = BC003738_A1084BoletosDataEmissao[0];
            n1084BoletosDataEmissao = BC003738_n1084BoletosDataEmissao[0];
            A1085BoletosDataVencimento = BC003738_A1085BoletosDataVencimento[0];
            n1085BoletosDataVencimento = BC003738_n1085BoletosDataVencimento[0];
            A1086BoletosDataRegistro = BC003738_A1086BoletosDataRegistro[0];
            n1086BoletosDataRegistro = BC003738_n1086BoletosDataRegistro[0];
            A1087BoletosDataPagamento = BC003738_A1087BoletosDataPagamento[0];
            n1087BoletosDataPagamento = BC003738_n1087BoletosDataPagamento[0];
            A1088BoletosDataBaixa = BC003738_A1088BoletosDataBaixa[0];
            n1088BoletosDataBaixa = BC003738_n1088BoletosDataBaixa[0];
            A1089BoletosValorNominal = BC003738_A1089BoletosValorNominal[0];
            n1089BoletosValorNominal = BC003738_n1089BoletosValorNominal[0];
            A1090BoletosValorPago = BC003738_A1090BoletosValorPago[0];
            n1090BoletosValorPago = BC003738_n1090BoletosValorPago[0];
            A1091BoletosValorDesconto = BC003738_A1091BoletosValorDesconto[0];
            n1091BoletosValorDesconto = BC003738_n1091BoletosValorDesconto[0];
            A1092BoletosValorJuros = BC003738_A1092BoletosValorJuros[0];
            n1092BoletosValorJuros = BC003738_n1092BoletosValorJuros[0];
            A1093BoletosValorMulta = BC003738_A1093BoletosValorMulta[0];
            n1093BoletosValorMulta = BC003738_n1093BoletosValorMulta[0];
            A1094BoletosSacadoNome = BC003738_A1094BoletosSacadoNome[0];
            n1094BoletosSacadoNome = BC003738_n1094BoletosSacadoNome[0];
            A1095BoletosSacadoDocumento = BC003738_A1095BoletosSacadoDocumento[0];
            n1095BoletosSacadoDocumento = BC003738_n1095BoletosSacadoDocumento[0];
            A1096BoletosSacadoTipoDocumento = BC003738_A1096BoletosSacadoTipoDocumento[0];
            n1096BoletosSacadoTipoDocumento = BC003738_n1096BoletosSacadoTipoDocumento[0];
            A1097BoletosMensagemDeErro = BC003738_A1097BoletosMensagemDeErro[0];
            n1097BoletosMensagemDeErro = BC003738_n1097BoletosMensagemDeErro[0];
            A1098BoletosTentativasDeRegistro = BC003738_A1098BoletosTentativasDeRegistro[0];
            n1098BoletosTentativasDeRegistro = BC003738_n1098BoletosTentativasDeRegistro[0];
            A1071CarteiraDeCobrancaNome = BC003738_A1071CarteiraDeCobrancaNome[0];
            n1071CarteiraDeCobrancaNome = BC003738_n1071CarteiraDeCobrancaNome[0];
            A1073CarteiraDeCobrancaConvenio = BC003738_A1073CarteiraDeCobrancaConvenio[0];
            n1073CarteiraDeCobrancaConvenio = BC003738_n1073CarteiraDeCobrancaConvenio[0];
            A1074CarteiraDeCobrancaStatus = BC003738_A1074CarteiraDeCobrancaStatus[0];
            n1074CarteiraDeCobrancaStatus = BC003738_n1074CarteiraDeCobrancaStatus[0];
            A1069CarteiraDeCobrancaId = BC003738_A1069CarteiraDeCobrancaId[0];
            n1069CarteiraDeCobrancaId = BC003738_n1069CarteiraDeCobrancaId[0];
            A261TituloId = BC003738_A261TituloId[0];
            n261TituloId = BC003738_n261TituloId[0];
            A1112CarteiraDeCobrancaValorRecebido = BC003738_A1112CarteiraDeCobrancaValorRecebido[0];
            A1111CarteiraDeCobrancaValorTotal = BC003738_A1111CarteiraDeCobrancaValorTotal[0];
            A1113CarteiraDeCobrancaTotalBoletos = BC003738_A1113CarteiraDeCobrancaTotalBoletos[0];
            A1114CarteiraDeCobrancaTotalBoletosRegistrados = BC003738_A1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
            n1114CarteiraDeCobrancaTotalBoletosRegistrados = BC003738_n1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
            A1115CarteiraDeCobrancaTotalBoletosExpirados = BC003738_A1115CarteiraDeCobrancaTotalBoletosExpirados[0];
            n1115CarteiraDeCobrancaTotalBoletosExpirados = BC003738_n1115CarteiraDeCobrancaTotalBoletosExpirados[0];
            A1116CarteiraDeCobrancaTotalBoletosCancelados = BC003738_A1116CarteiraDeCobrancaTotalBoletosCancelados[0];
            n1116CarteiraDeCobrancaTotalBoletosCancelados = BC003738_n1116CarteiraDeCobrancaTotalBoletosCancelados[0];
         }
         Gx_mode = sMode111;
      }

      protected void ScanKeyEnd37111( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm37111( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert37111( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate37111( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete37111( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete37111( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate37111( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes37111( )
      {
      }

      protected void send_integrity_lvl_hashes37111( )
      {
      }

      protected void AddRow37111( )
      {
         VarsToRow111( bcBoleto) ;
      }

      protected void ReadRow37111( )
      {
         RowToVars111( bcBoleto, 1) ;
      }

      protected void InitializeNonKey37111( )
      {
         A1099BoletosCreatedAt = (DateTime)(DateTime.MinValue);
         n1099BoletosCreatedAt = false;
         A1100BoletosUpdatedAt = (DateTime)(DateTime.MinValue);
         n1100BoletosUpdatedAt = false;
         A1112CarteiraDeCobrancaValorRecebido = 0;
         A1111CarteiraDeCobrancaValorTotal = 0;
         A1113CarteiraDeCobrancaTotalBoletos = 0;
         A1114CarteiraDeCobrancaTotalBoletosRegistrados = 0;
         n1114CarteiraDeCobrancaTotalBoletosRegistrados = false;
         A1115CarteiraDeCobrancaTotalBoletosExpirados = 0;
         n1115CarteiraDeCobrancaTotalBoletosExpirados = false;
         A1116CarteiraDeCobrancaTotalBoletosCancelados = 0;
         n1116CarteiraDeCobrancaTotalBoletosCancelados = false;
         A1069CarteiraDeCobrancaId = 0;
         n1069CarteiraDeCobrancaId = false;
         A261TituloId = 0;
         n261TituloId = false;
         A1078BoletosNossoNumero = "";
         n1078BoletosNossoNumero = false;
         A1079BoletosSeuNumero = "";
         n1079BoletosSeuNumero = false;
         A1080BoletosNumero = "";
         n1080BoletosNumero = false;
         A1081BoletosLinhaDigitavel = "";
         n1081BoletosLinhaDigitavel = false;
         A1082BoletosCodigoDeBarras = "";
         n1082BoletosCodigoDeBarras = false;
         A1083BoletosStatus = "";
         n1083BoletosStatus = false;
         A1084BoletosDataEmissao = DateTime.MinValue;
         n1084BoletosDataEmissao = false;
         A1085BoletosDataVencimento = DateTime.MinValue;
         n1085BoletosDataVencimento = false;
         A1086BoletosDataRegistro = (DateTime)(DateTime.MinValue);
         n1086BoletosDataRegistro = false;
         A1087BoletosDataPagamento = DateTime.MinValue;
         n1087BoletosDataPagamento = false;
         A1088BoletosDataBaixa = DateTime.MinValue;
         n1088BoletosDataBaixa = false;
         A1089BoletosValorNominal = 0;
         n1089BoletosValorNominal = false;
         A1090BoletosValorPago = 0;
         n1090BoletosValorPago = false;
         A1091BoletosValorDesconto = 0;
         n1091BoletosValorDesconto = false;
         A1092BoletosValorJuros = 0;
         n1092BoletosValorJuros = false;
         A1093BoletosValorMulta = 0;
         n1093BoletosValorMulta = false;
         A1094BoletosSacadoNome = "";
         n1094BoletosSacadoNome = false;
         A1095BoletosSacadoDocumento = "";
         n1095BoletosSacadoDocumento = false;
         A1096BoletosSacadoTipoDocumento = "";
         n1096BoletosSacadoTipoDocumento = false;
         A1097BoletosMensagemDeErro = "";
         n1097BoletosMensagemDeErro = false;
         A1098BoletosTentativasDeRegistro = 0;
         n1098BoletosTentativasDeRegistro = false;
         A1071CarteiraDeCobrancaNome = "";
         n1071CarteiraDeCobrancaNome = false;
         A1073CarteiraDeCobrancaConvenio = "";
         n1073CarteiraDeCobrancaConvenio = false;
         A1074CarteiraDeCobrancaStatus = false;
         n1074CarteiraDeCobrancaStatus = false;
         A1117BoletosResgitroId = Guid.NewGuid( );
         n1117BoletosResgitroId = false;
         Z1117BoletosResgitroId = Guid.Empty;
         Z1099BoletosCreatedAt = (DateTime)(DateTime.MinValue);
         Z1100BoletosUpdatedAt = (DateTime)(DateTime.MinValue);
         Z1078BoletosNossoNumero = "";
         Z1079BoletosSeuNumero = "";
         Z1080BoletosNumero = "";
         Z1081BoletosLinhaDigitavel = "";
         Z1082BoletosCodigoDeBarras = "";
         Z1083BoletosStatus = "";
         Z1084BoletosDataEmissao = DateTime.MinValue;
         Z1085BoletosDataVencimento = DateTime.MinValue;
         Z1086BoletosDataRegistro = (DateTime)(DateTime.MinValue);
         Z1087BoletosDataPagamento = DateTime.MinValue;
         Z1088BoletosDataBaixa = DateTime.MinValue;
         Z1089BoletosValorNominal = 0;
         Z1090BoletosValorPago = 0;
         Z1091BoletosValorDesconto = 0;
         Z1092BoletosValorJuros = 0;
         Z1093BoletosValorMulta = 0;
         Z1094BoletosSacadoNome = "";
         Z1095BoletosSacadoDocumento = "";
         Z1096BoletosSacadoTipoDocumento = "";
         Z1098BoletosTentativasDeRegistro = 0;
         Z1069CarteiraDeCobrancaId = 0;
         Z261TituloId = 0;
      }

      protected void InitAll37111( )
      {
         A1077BoletosId = 0;
         n1077BoletosId = false;
         InitializeNonKey37111( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A1117BoletosResgitroId = i1117BoletosResgitroId;
         n1117BoletosResgitroId = false;
         A1099BoletosCreatedAt = i1099BoletosCreatedAt;
         n1099BoletosCreatedAt = false;
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

      public void VarsToRow111( SdtBoleto obj111 )
      {
         obj111.gxTpr_Mode = Gx_mode;
         obj111.gxTpr_Boletoscreatedat = A1099BoletosCreatedAt;
         obj111.gxTpr_Boletosupdatedat = A1100BoletosUpdatedAt;
         obj111.gxTpr_Carteiradecobrancavalorrecebido = A1112CarteiraDeCobrancaValorRecebido;
         obj111.gxTpr_Carteiradecobrancavalortotal = A1111CarteiraDeCobrancaValorTotal;
         obj111.gxTpr_Carteiradecobrancatotalboletos = A1113CarteiraDeCobrancaTotalBoletos;
         obj111.gxTpr_Carteiradecobrancatotalboletosregistrados = A1114CarteiraDeCobrancaTotalBoletosRegistrados;
         obj111.gxTpr_Carteiradecobrancatotalboletosexpirados = A1115CarteiraDeCobrancaTotalBoletosExpirados;
         obj111.gxTpr_Carteiradecobrancatotalboletoscancelados = A1116CarteiraDeCobrancaTotalBoletosCancelados;
         obj111.gxTpr_Carteiradecobrancaid = A1069CarteiraDeCobrancaId;
         obj111.gxTpr_Tituloid = A261TituloId;
         obj111.gxTpr_Boletosnossonumero = A1078BoletosNossoNumero;
         obj111.gxTpr_Boletosseunumero = A1079BoletosSeuNumero;
         obj111.gxTpr_Boletosnumero = A1080BoletosNumero;
         obj111.gxTpr_Boletoslinhadigitavel = A1081BoletosLinhaDigitavel;
         obj111.gxTpr_Boletoscodigodebarras = A1082BoletosCodigoDeBarras;
         obj111.gxTpr_Boletosstatus = A1083BoletosStatus;
         obj111.gxTpr_Boletosdataemissao = A1084BoletosDataEmissao;
         obj111.gxTpr_Boletosdatavencimento = A1085BoletosDataVencimento;
         obj111.gxTpr_Boletosdataregistro = A1086BoletosDataRegistro;
         obj111.gxTpr_Boletosdatapagamento = A1087BoletosDataPagamento;
         obj111.gxTpr_Boletosdatabaixa = A1088BoletosDataBaixa;
         obj111.gxTpr_Boletosvalornominal = A1089BoletosValorNominal;
         obj111.gxTpr_Boletosvalorpago = A1090BoletosValorPago;
         obj111.gxTpr_Boletosvalordesconto = A1091BoletosValorDesconto;
         obj111.gxTpr_Boletosvalorjuros = A1092BoletosValorJuros;
         obj111.gxTpr_Boletosvalormulta = A1093BoletosValorMulta;
         obj111.gxTpr_Boletossacadonome = A1094BoletosSacadoNome;
         obj111.gxTpr_Boletossacadodocumento = A1095BoletosSacadoDocumento;
         obj111.gxTpr_Boletossacadotipodocumento = A1096BoletosSacadoTipoDocumento;
         obj111.gxTpr_Boletosmensagemdeerro = A1097BoletosMensagemDeErro;
         obj111.gxTpr_Boletostentativasderegistro = A1098BoletosTentativasDeRegistro;
         obj111.gxTpr_Carteiradecobrancanome = A1071CarteiraDeCobrancaNome;
         obj111.gxTpr_Carteiradecobrancaconvenio = A1073CarteiraDeCobrancaConvenio;
         obj111.gxTpr_Carteiradecobrancastatus = A1074CarteiraDeCobrancaStatus;
         obj111.gxTpr_Boletosresgitroid = A1117BoletosResgitroId;
         obj111.gxTpr_Boletosid = A1077BoletosId;
         obj111.gxTpr_Boletosid_Z = Z1077BoletosId;
         obj111.gxTpr_Carteiradecobrancaid_Z = Z1069CarteiraDeCobrancaId;
         obj111.gxTpr_Tituloid_Z = Z261TituloId;
         obj111.gxTpr_Boletosnossonumero_Z = Z1078BoletosNossoNumero;
         obj111.gxTpr_Boletosseunumero_Z = Z1079BoletosSeuNumero;
         obj111.gxTpr_Boletosnumero_Z = Z1080BoletosNumero;
         obj111.gxTpr_Boletoslinhadigitavel_Z = Z1081BoletosLinhaDigitavel;
         obj111.gxTpr_Boletoscodigodebarras_Z = Z1082BoletosCodigoDeBarras;
         obj111.gxTpr_Boletosstatus_Z = Z1083BoletosStatus;
         obj111.gxTpr_Boletosdataemissao_Z = Z1084BoletosDataEmissao;
         obj111.gxTpr_Boletosdatavencimento_Z = Z1085BoletosDataVencimento;
         obj111.gxTpr_Boletosdataregistro_Z = Z1086BoletosDataRegistro;
         obj111.gxTpr_Boletosdatapagamento_Z = Z1087BoletosDataPagamento;
         obj111.gxTpr_Boletosdatabaixa_Z = Z1088BoletosDataBaixa;
         obj111.gxTpr_Boletosvalornominal_Z = Z1089BoletosValorNominal;
         obj111.gxTpr_Boletosvalorpago_Z = Z1090BoletosValorPago;
         obj111.gxTpr_Boletosvalordesconto_Z = Z1091BoletosValorDesconto;
         obj111.gxTpr_Boletosvalorjuros_Z = Z1092BoletosValorJuros;
         obj111.gxTpr_Boletosvalormulta_Z = Z1093BoletosValorMulta;
         obj111.gxTpr_Boletossacadonome_Z = Z1094BoletosSacadoNome;
         obj111.gxTpr_Boletossacadodocumento_Z = Z1095BoletosSacadoDocumento;
         obj111.gxTpr_Boletossacadotipodocumento_Z = Z1096BoletosSacadoTipoDocumento;
         obj111.gxTpr_Boletostentativasderegistro_Z = Z1098BoletosTentativasDeRegistro;
         obj111.gxTpr_Boletoscreatedat_Z = Z1099BoletosCreatedAt;
         obj111.gxTpr_Boletosupdatedat_Z = Z1100BoletosUpdatedAt;
         obj111.gxTpr_Boletosresgitroid_Z = Z1117BoletosResgitroId;
         obj111.gxTpr_Carteiradecobrancanome_Z = Z1071CarteiraDeCobrancaNome;
         obj111.gxTpr_Carteiradecobrancaconvenio_Z = Z1073CarteiraDeCobrancaConvenio;
         obj111.gxTpr_Carteiradecobrancastatus_Z = Z1074CarteiraDeCobrancaStatus;
         obj111.gxTpr_Carteiradecobrancavalortotal_Z = Z1111CarteiraDeCobrancaValorTotal;
         obj111.gxTpr_Carteiradecobrancavalorrecebido_Z = Z1112CarteiraDeCobrancaValorRecebido;
         obj111.gxTpr_Carteiradecobrancatotalboletos_Z = Z1113CarteiraDeCobrancaTotalBoletos;
         obj111.gxTpr_Carteiradecobrancatotalboletosregistrados_Z = Z1114CarteiraDeCobrancaTotalBoletosRegistrados;
         obj111.gxTpr_Carteiradecobrancatotalboletosexpirados_Z = Z1115CarteiraDeCobrancaTotalBoletosExpirados;
         obj111.gxTpr_Carteiradecobrancatotalboletoscancelados_Z = Z1116CarteiraDeCobrancaTotalBoletosCancelados;
         obj111.gxTpr_Boletosid_N = (short)(Convert.ToInt16(n1077BoletosId));
         obj111.gxTpr_Carteiradecobrancaid_N = (short)(Convert.ToInt16(n1069CarteiraDeCobrancaId));
         obj111.gxTpr_Tituloid_N = (short)(Convert.ToInt16(n261TituloId));
         obj111.gxTpr_Boletosnossonumero_N = (short)(Convert.ToInt16(n1078BoletosNossoNumero));
         obj111.gxTpr_Boletosseunumero_N = (short)(Convert.ToInt16(n1079BoletosSeuNumero));
         obj111.gxTpr_Boletosnumero_N = (short)(Convert.ToInt16(n1080BoletosNumero));
         obj111.gxTpr_Boletoslinhadigitavel_N = (short)(Convert.ToInt16(n1081BoletosLinhaDigitavel));
         obj111.gxTpr_Boletoscodigodebarras_N = (short)(Convert.ToInt16(n1082BoletosCodigoDeBarras));
         obj111.gxTpr_Boletosstatus_N = (short)(Convert.ToInt16(n1083BoletosStatus));
         obj111.gxTpr_Boletosdataemissao_N = (short)(Convert.ToInt16(n1084BoletosDataEmissao));
         obj111.gxTpr_Boletosdatavencimento_N = (short)(Convert.ToInt16(n1085BoletosDataVencimento));
         obj111.gxTpr_Boletosdataregistro_N = (short)(Convert.ToInt16(n1086BoletosDataRegistro));
         obj111.gxTpr_Boletosdatapagamento_N = (short)(Convert.ToInt16(n1087BoletosDataPagamento));
         obj111.gxTpr_Boletosdatabaixa_N = (short)(Convert.ToInt16(n1088BoletosDataBaixa));
         obj111.gxTpr_Boletosvalornominal_N = (short)(Convert.ToInt16(n1089BoletosValorNominal));
         obj111.gxTpr_Boletosvalorpago_N = (short)(Convert.ToInt16(n1090BoletosValorPago));
         obj111.gxTpr_Boletosvalordesconto_N = (short)(Convert.ToInt16(n1091BoletosValorDesconto));
         obj111.gxTpr_Boletosvalorjuros_N = (short)(Convert.ToInt16(n1092BoletosValorJuros));
         obj111.gxTpr_Boletosvalormulta_N = (short)(Convert.ToInt16(n1093BoletosValorMulta));
         obj111.gxTpr_Boletossacadonome_N = (short)(Convert.ToInt16(n1094BoletosSacadoNome));
         obj111.gxTpr_Boletossacadodocumento_N = (short)(Convert.ToInt16(n1095BoletosSacadoDocumento));
         obj111.gxTpr_Boletossacadotipodocumento_N = (short)(Convert.ToInt16(n1096BoletosSacadoTipoDocumento));
         obj111.gxTpr_Boletosmensagemdeerro_N = (short)(Convert.ToInt16(n1097BoletosMensagemDeErro));
         obj111.gxTpr_Boletostentativasderegistro_N = (short)(Convert.ToInt16(n1098BoletosTentativasDeRegistro));
         obj111.gxTpr_Boletoscreatedat_N = (short)(Convert.ToInt16(n1099BoletosCreatedAt));
         obj111.gxTpr_Boletosupdatedat_N = (short)(Convert.ToInt16(n1100BoletosUpdatedAt));
         obj111.gxTpr_Boletosresgitroid_N = (short)(Convert.ToInt16(n1117BoletosResgitroId));
         obj111.gxTpr_Carteiradecobrancanome_N = (short)(Convert.ToInt16(n1071CarteiraDeCobrancaNome));
         obj111.gxTpr_Carteiradecobrancaconvenio_N = (short)(Convert.ToInt16(n1073CarteiraDeCobrancaConvenio));
         obj111.gxTpr_Carteiradecobrancastatus_N = (short)(Convert.ToInt16(n1074CarteiraDeCobrancaStatus));
         obj111.gxTpr_Carteiradecobrancatotalboletosregistrados_N = (short)(Convert.ToInt16(n1114CarteiraDeCobrancaTotalBoletosRegistrados));
         obj111.gxTpr_Carteiradecobrancatotalboletosexpirados_N = (short)(Convert.ToInt16(n1115CarteiraDeCobrancaTotalBoletosExpirados));
         obj111.gxTpr_Carteiradecobrancatotalboletoscancelados_N = (short)(Convert.ToInt16(n1116CarteiraDeCobrancaTotalBoletosCancelados));
         obj111.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow111( SdtBoleto obj111 )
      {
         obj111.gxTpr_Boletosid = A1077BoletosId;
         return  ;
      }

      public void RowToVars111( SdtBoleto obj111 ,
                                int forceLoad )
      {
         Gx_mode = obj111.gxTpr_Mode;
         A1099BoletosCreatedAt = obj111.gxTpr_Boletoscreatedat;
         n1099BoletosCreatedAt = false;
         A1100BoletosUpdatedAt = obj111.gxTpr_Boletosupdatedat;
         n1100BoletosUpdatedAt = false;
         A1112CarteiraDeCobrancaValorRecebido = obj111.gxTpr_Carteiradecobrancavalorrecebido;
         A1111CarteiraDeCobrancaValorTotal = obj111.gxTpr_Carteiradecobrancavalortotal;
         A1113CarteiraDeCobrancaTotalBoletos = obj111.gxTpr_Carteiradecobrancatotalboletos;
         A1114CarteiraDeCobrancaTotalBoletosRegistrados = obj111.gxTpr_Carteiradecobrancatotalboletosregistrados;
         n1114CarteiraDeCobrancaTotalBoletosRegistrados = false;
         A1115CarteiraDeCobrancaTotalBoletosExpirados = obj111.gxTpr_Carteiradecobrancatotalboletosexpirados;
         n1115CarteiraDeCobrancaTotalBoletosExpirados = false;
         A1116CarteiraDeCobrancaTotalBoletosCancelados = obj111.gxTpr_Carteiradecobrancatotalboletoscancelados;
         n1116CarteiraDeCobrancaTotalBoletosCancelados = false;
         A1069CarteiraDeCobrancaId = obj111.gxTpr_Carteiradecobrancaid;
         n1069CarteiraDeCobrancaId = false;
         A261TituloId = obj111.gxTpr_Tituloid;
         n261TituloId = false;
         A1078BoletosNossoNumero = obj111.gxTpr_Boletosnossonumero;
         n1078BoletosNossoNumero = false;
         A1079BoletosSeuNumero = obj111.gxTpr_Boletosseunumero;
         n1079BoletosSeuNumero = false;
         A1080BoletosNumero = obj111.gxTpr_Boletosnumero;
         n1080BoletosNumero = false;
         A1081BoletosLinhaDigitavel = obj111.gxTpr_Boletoslinhadigitavel;
         n1081BoletosLinhaDigitavel = false;
         A1082BoletosCodigoDeBarras = obj111.gxTpr_Boletoscodigodebarras;
         n1082BoletosCodigoDeBarras = false;
         A1083BoletosStatus = obj111.gxTpr_Boletosstatus;
         n1083BoletosStatus = false;
         A1084BoletosDataEmissao = obj111.gxTpr_Boletosdataemissao;
         n1084BoletosDataEmissao = false;
         A1085BoletosDataVencimento = obj111.gxTpr_Boletosdatavencimento;
         n1085BoletosDataVencimento = false;
         A1086BoletosDataRegistro = obj111.gxTpr_Boletosdataregistro;
         n1086BoletosDataRegistro = false;
         A1087BoletosDataPagamento = obj111.gxTpr_Boletosdatapagamento;
         n1087BoletosDataPagamento = false;
         A1088BoletosDataBaixa = obj111.gxTpr_Boletosdatabaixa;
         n1088BoletosDataBaixa = false;
         A1089BoletosValorNominal = obj111.gxTpr_Boletosvalornominal;
         n1089BoletosValorNominal = false;
         A1090BoletosValorPago = obj111.gxTpr_Boletosvalorpago;
         n1090BoletosValorPago = false;
         A1091BoletosValorDesconto = obj111.gxTpr_Boletosvalordesconto;
         n1091BoletosValorDesconto = false;
         A1092BoletosValorJuros = obj111.gxTpr_Boletosvalorjuros;
         n1092BoletosValorJuros = false;
         A1093BoletosValorMulta = obj111.gxTpr_Boletosvalormulta;
         n1093BoletosValorMulta = false;
         A1094BoletosSacadoNome = obj111.gxTpr_Boletossacadonome;
         n1094BoletosSacadoNome = false;
         A1095BoletosSacadoDocumento = obj111.gxTpr_Boletossacadodocumento;
         n1095BoletosSacadoDocumento = false;
         A1096BoletosSacadoTipoDocumento = obj111.gxTpr_Boletossacadotipodocumento;
         n1096BoletosSacadoTipoDocumento = false;
         A1097BoletosMensagemDeErro = obj111.gxTpr_Boletosmensagemdeerro;
         n1097BoletosMensagemDeErro = false;
         A1098BoletosTentativasDeRegistro = obj111.gxTpr_Boletostentativasderegistro;
         n1098BoletosTentativasDeRegistro = false;
         A1071CarteiraDeCobrancaNome = obj111.gxTpr_Carteiradecobrancanome;
         n1071CarteiraDeCobrancaNome = false;
         A1073CarteiraDeCobrancaConvenio = obj111.gxTpr_Carteiradecobrancaconvenio;
         n1073CarteiraDeCobrancaConvenio = false;
         A1074CarteiraDeCobrancaStatus = obj111.gxTpr_Carteiradecobrancastatus;
         n1074CarteiraDeCobrancaStatus = false;
         A1117BoletosResgitroId = obj111.gxTpr_Boletosresgitroid;
         n1117BoletosResgitroId = false;
         A1077BoletosId = obj111.gxTpr_Boletosid;
         n1077BoletosId = false;
         Z1077BoletosId = obj111.gxTpr_Boletosid_Z;
         Z1069CarteiraDeCobrancaId = obj111.gxTpr_Carteiradecobrancaid_Z;
         Z261TituloId = obj111.gxTpr_Tituloid_Z;
         Z1078BoletosNossoNumero = obj111.gxTpr_Boletosnossonumero_Z;
         Z1079BoletosSeuNumero = obj111.gxTpr_Boletosseunumero_Z;
         Z1080BoletosNumero = obj111.gxTpr_Boletosnumero_Z;
         Z1081BoletosLinhaDigitavel = obj111.gxTpr_Boletoslinhadigitavel_Z;
         Z1082BoletosCodigoDeBarras = obj111.gxTpr_Boletoscodigodebarras_Z;
         Z1083BoletosStatus = obj111.gxTpr_Boletosstatus_Z;
         Z1084BoletosDataEmissao = obj111.gxTpr_Boletosdataemissao_Z;
         Z1085BoletosDataVencimento = obj111.gxTpr_Boletosdatavencimento_Z;
         Z1086BoletosDataRegistro = obj111.gxTpr_Boletosdataregistro_Z;
         Z1087BoletosDataPagamento = obj111.gxTpr_Boletosdatapagamento_Z;
         Z1088BoletosDataBaixa = obj111.gxTpr_Boletosdatabaixa_Z;
         Z1089BoletosValorNominal = obj111.gxTpr_Boletosvalornominal_Z;
         Z1090BoletosValorPago = obj111.gxTpr_Boletosvalorpago_Z;
         Z1091BoletosValorDesconto = obj111.gxTpr_Boletosvalordesconto_Z;
         Z1092BoletosValorJuros = obj111.gxTpr_Boletosvalorjuros_Z;
         Z1093BoletosValorMulta = obj111.gxTpr_Boletosvalormulta_Z;
         Z1094BoletosSacadoNome = obj111.gxTpr_Boletossacadonome_Z;
         Z1095BoletosSacadoDocumento = obj111.gxTpr_Boletossacadodocumento_Z;
         Z1096BoletosSacadoTipoDocumento = obj111.gxTpr_Boletossacadotipodocumento_Z;
         Z1098BoletosTentativasDeRegistro = obj111.gxTpr_Boletostentativasderegistro_Z;
         Z1099BoletosCreatedAt = obj111.gxTpr_Boletoscreatedat_Z;
         Z1100BoletosUpdatedAt = obj111.gxTpr_Boletosupdatedat_Z;
         Z1117BoletosResgitroId = obj111.gxTpr_Boletosresgitroid_Z;
         Z1071CarteiraDeCobrancaNome = obj111.gxTpr_Carteiradecobrancanome_Z;
         Z1073CarteiraDeCobrancaConvenio = obj111.gxTpr_Carteiradecobrancaconvenio_Z;
         Z1074CarteiraDeCobrancaStatus = obj111.gxTpr_Carteiradecobrancastatus_Z;
         Z1111CarteiraDeCobrancaValorTotal = obj111.gxTpr_Carteiradecobrancavalortotal_Z;
         Z1112CarteiraDeCobrancaValorRecebido = obj111.gxTpr_Carteiradecobrancavalorrecebido_Z;
         Z1113CarteiraDeCobrancaTotalBoletos = obj111.gxTpr_Carteiradecobrancatotalboletos_Z;
         Z1114CarteiraDeCobrancaTotalBoletosRegistrados = obj111.gxTpr_Carteiradecobrancatotalboletosregistrados_Z;
         Z1115CarteiraDeCobrancaTotalBoletosExpirados = obj111.gxTpr_Carteiradecobrancatotalboletosexpirados_Z;
         Z1116CarteiraDeCobrancaTotalBoletosCancelados = obj111.gxTpr_Carteiradecobrancatotalboletoscancelados_Z;
         n1077BoletosId = (bool)(Convert.ToBoolean(obj111.gxTpr_Boletosid_N));
         n1069CarteiraDeCobrancaId = (bool)(Convert.ToBoolean(obj111.gxTpr_Carteiradecobrancaid_N));
         n261TituloId = (bool)(Convert.ToBoolean(obj111.gxTpr_Tituloid_N));
         n1078BoletosNossoNumero = (bool)(Convert.ToBoolean(obj111.gxTpr_Boletosnossonumero_N));
         n1079BoletosSeuNumero = (bool)(Convert.ToBoolean(obj111.gxTpr_Boletosseunumero_N));
         n1080BoletosNumero = (bool)(Convert.ToBoolean(obj111.gxTpr_Boletosnumero_N));
         n1081BoletosLinhaDigitavel = (bool)(Convert.ToBoolean(obj111.gxTpr_Boletoslinhadigitavel_N));
         n1082BoletosCodigoDeBarras = (bool)(Convert.ToBoolean(obj111.gxTpr_Boletoscodigodebarras_N));
         n1083BoletosStatus = (bool)(Convert.ToBoolean(obj111.gxTpr_Boletosstatus_N));
         n1084BoletosDataEmissao = (bool)(Convert.ToBoolean(obj111.gxTpr_Boletosdataemissao_N));
         n1085BoletosDataVencimento = (bool)(Convert.ToBoolean(obj111.gxTpr_Boletosdatavencimento_N));
         n1086BoletosDataRegistro = (bool)(Convert.ToBoolean(obj111.gxTpr_Boletosdataregistro_N));
         n1087BoletosDataPagamento = (bool)(Convert.ToBoolean(obj111.gxTpr_Boletosdatapagamento_N));
         n1088BoletosDataBaixa = (bool)(Convert.ToBoolean(obj111.gxTpr_Boletosdatabaixa_N));
         n1089BoletosValorNominal = (bool)(Convert.ToBoolean(obj111.gxTpr_Boletosvalornominal_N));
         n1090BoletosValorPago = (bool)(Convert.ToBoolean(obj111.gxTpr_Boletosvalorpago_N));
         n1091BoletosValorDesconto = (bool)(Convert.ToBoolean(obj111.gxTpr_Boletosvalordesconto_N));
         n1092BoletosValorJuros = (bool)(Convert.ToBoolean(obj111.gxTpr_Boletosvalorjuros_N));
         n1093BoletosValorMulta = (bool)(Convert.ToBoolean(obj111.gxTpr_Boletosvalormulta_N));
         n1094BoletosSacadoNome = (bool)(Convert.ToBoolean(obj111.gxTpr_Boletossacadonome_N));
         n1095BoletosSacadoDocumento = (bool)(Convert.ToBoolean(obj111.gxTpr_Boletossacadodocumento_N));
         n1096BoletosSacadoTipoDocumento = (bool)(Convert.ToBoolean(obj111.gxTpr_Boletossacadotipodocumento_N));
         n1097BoletosMensagemDeErro = (bool)(Convert.ToBoolean(obj111.gxTpr_Boletosmensagemdeerro_N));
         n1098BoletosTentativasDeRegistro = (bool)(Convert.ToBoolean(obj111.gxTpr_Boletostentativasderegistro_N));
         n1099BoletosCreatedAt = (bool)(Convert.ToBoolean(obj111.gxTpr_Boletoscreatedat_N));
         n1100BoletosUpdatedAt = (bool)(Convert.ToBoolean(obj111.gxTpr_Boletosupdatedat_N));
         n1117BoletosResgitroId = (bool)(Convert.ToBoolean(obj111.gxTpr_Boletosresgitroid_N));
         n1071CarteiraDeCobrancaNome = (bool)(Convert.ToBoolean(obj111.gxTpr_Carteiradecobrancanome_N));
         n1073CarteiraDeCobrancaConvenio = (bool)(Convert.ToBoolean(obj111.gxTpr_Carteiradecobrancaconvenio_N));
         n1074CarteiraDeCobrancaStatus = (bool)(Convert.ToBoolean(obj111.gxTpr_Carteiradecobrancastatus_N));
         n1114CarteiraDeCobrancaTotalBoletosRegistrados = (bool)(Convert.ToBoolean(obj111.gxTpr_Carteiradecobrancatotalboletosregistrados_N));
         n1115CarteiraDeCobrancaTotalBoletosExpirados = (bool)(Convert.ToBoolean(obj111.gxTpr_Carteiradecobrancatotalboletosexpirados_N));
         n1116CarteiraDeCobrancaTotalBoletosCancelados = (bool)(Convert.ToBoolean(obj111.gxTpr_Carteiradecobrancatotalboletoscancelados_N));
         Gx_mode = obj111.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A1077BoletosId = (int)getParm(obj,0);
         n1077BoletosId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey37111( ) ;
         ScanKeyStart37111( ) ;
         if ( RcdFound111 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1077BoletosId = A1077BoletosId;
         }
         ZM37111( -16) ;
         OnLoadActions37111( ) ;
         AddRow37111( ) ;
         ScanKeyEnd37111( ) ;
         if ( RcdFound111 == 0 )
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
         RowToVars111( bcBoleto, 0) ;
         ScanKeyStart37111( ) ;
         if ( RcdFound111 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1077BoletosId = A1077BoletosId;
         }
         ZM37111( -16) ;
         OnLoadActions37111( ) ;
         AddRow37111( ) ;
         ScanKeyEnd37111( ) ;
         if ( RcdFound111 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey37111( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert37111( ) ;
         }
         else
         {
            if ( RcdFound111 == 1 )
            {
               if ( A1077BoletosId != Z1077BoletosId )
               {
                  A1077BoletosId = Z1077BoletosId;
                  n1077BoletosId = false;
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
                  Update37111( ) ;
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
                  if ( A1077BoletosId != Z1077BoletosId )
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
                        Insert37111( ) ;
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
                        Insert37111( ) ;
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
         RowToVars111( bcBoleto, 1) ;
         SaveImpl( ) ;
         VarsToRow111( bcBoleto) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars111( bcBoleto, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert37111( ) ;
         AfterTrn( ) ;
         VarsToRow111( bcBoleto) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow111( bcBoleto) ;
         }
         else
         {
            SdtBoleto auxBC = new SdtBoleto(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A1077BoletosId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcBoleto);
               auxBC.Save();
               bcBoleto.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars111( bcBoleto, 1) ;
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
         RowToVars111( bcBoleto, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert37111( ) ;
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
               VarsToRow111( bcBoleto) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow111( bcBoleto) ;
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
         RowToVars111( bcBoleto, 0) ;
         GetKey37111( ) ;
         if ( RcdFound111 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A1077BoletosId != Z1077BoletosId )
            {
               A1077BoletosId = Z1077BoletosId;
               n1077BoletosId = false;
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
            if ( A1077BoletosId != Z1077BoletosId )
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
         context.RollbackDataStores("boleto_bc",pr_default);
         VarsToRow111( bcBoleto) ;
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
         Gx_mode = bcBoleto.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcBoleto.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcBoleto )
         {
            bcBoleto = (SdtBoleto)(sdt);
            if ( StringUtil.StrCmp(bcBoleto.gxTpr_Mode, "") == 0 )
            {
               bcBoleto.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow111( bcBoleto) ;
            }
            else
            {
               RowToVars111( bcBoleto, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcBoleto.gxTpr_Mode, "") == 0 )
            {
               bcBoleto.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars111( bcBoleto, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtBoleto Boleto_BC
      {
         get {
            return bcBoleto ;
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
         pr_default.close(14);
         pr_default.close(15);
         pr_default.close(16);
         pr_default.close(17);
         pr_default.close(18);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV22Pgmname = "";
         AV13TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z1117BoletosResgitroId = Guid.Empty;
         A1117BoletosResgitroId = Guid.Empty;
         Z1099BoletosCreatedAt = (DateTime)(DateTime.MinValue);
         A1099BoletosCreatedAt = (DateTime)(DateTime.MinValue);
         Z1100BoletosUpdatedAt = (DateTime)(DateTime.MinValue);
         A1100BoletosUpdatedAt = (DateTime)(DateTime.MinValue);
         Z1078BoletosNossoNumero = "";
         A1078BoletosNossoNumero = "";
         Z1079BoletosSeuNumero = "";
         A1079BoletosSeuNumero = "";
         Z1080BoletosNumero = "";
         A1080BoletosNumero = "";
         Z1081BoletosLinhaDigitavel = "";
         A1081BoletosLinhaDigitavel = "";
         Z1082BoletosCodigoDeBarras = "";
         A1082BoletosCodigoDeBarras = "";
         Z1083BoletosStatus = "";
         A1083BoletosStatus = "";
         Z1084BoletosDataEmissao = DateTime.MinValue;
         A1084BoletosDataEmissao = DateTime.MinValue;
         Z1085BoletosDataVencimento = DateTime.MinValue;
         A1085BoletosDataVencimento = DateTime.MinValue;
         Z1086BoletosDataRegistro = (DateTime)(DateTime.MinValue);
         A1086BoletosDataRegistro = (DateTime)(DateTime.MinValue);
         Z1087BoletosDataPagamento = DateTime.MinValue;
         A1087BoletosDataPagamento = DateTime.MinValue;
         Z1088BoletosDataBaixa = DateTime.MinValue;
         A1088BoletosDataBaixa = DateTime.MinValue;
         Z1094BoletosSacadoNome = "";
         A1094BoletosSacadoNome = "";
         Z1095BoletosSacadoDocumento = "";
         A1095BoletosSacadoDocumento = "";
         Z1096BoletosSacadoTipoDocumento = "";
         A1096BoletosSacadoTipoDocumento = "";
         Z1071CarteiraDeCobrancaNome = "";
         A1071CarteiraDeCobrancaNome = "";
         Z1073CarteiraDeCobrancaConvenio = "";
         A1073CarteiraDeCobrancaConvenio = "";
         Z1097BoletosMensagemDeErro = "";
         A1097BoletosMensagemDeErro = "";
         BC003718_A1077BoletosId = new int[1] ;
         BC003718_n1077BoletosId = new bool[] {false} ;
         BC003718_A1117BoletosResgitroId = new Guid[] {Guid.Empty} ;
         BC003718_n1117BoletosResgitroId = new bool[] {false} ;
         BC003718_A1099BoletosCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC003718_n1099BoletosCreatedAt = new bool[] {false} ;
         BC003718_A1100BoletosUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC003718_n1100BoletosUpdatedAt = new bool[] {false} ;
         BC003718_A1078BoletosNossoNumero = new string[] {""} ;
         BC003718_n1078BoletosNossoNumero = new bool[] {false} ;
         BC003718_A1079BoletosSeuNumero = new string[] {""} ;
         BC003718_n1079BoletosSeuNumero = new bool[] {false} ;
         BC003718_A1080BoletosNumero = new string[] {""} ;
         BC003718_n1080BoletosNumero = new bool[] {false} ;
         BC003718_A1081BoletosLinhaDigitavel = new string[] {""} ;
         BC003718_n1081BoletosLinhaDigitavel = new bool[] {false} ;
         BC003718_A1082BoletosCodigoDeBarras = new string[] {""} ;
         BC003718_n1082BoletosCodigoDeBarras = new bool[] {false} ;
         BC003718_A1083BoletosStatus = new string[] {""} ;
         BC003718_n1083BoletosStatus = new bool[] {false} ;
         BC003718_A1084BoletosDataEmissao = new DateTime[] {DateTime.MinValue} ;
         BC003718_n1084BoletosDataEmissao = new bool[] {false} ;
         BC003718_A1085BoletosDataVencimento = new DateTime[] {DateTime.MinValue} ;
         BC003718_n1085BoletosDataVencimento = new bool[] {false} ;
         BC003718_A1086BoletosDataRegistro = new DateTime[] {DateTime.MinValue} ;
         BC003718_n1086BoletosDataRegistro = new bool[] {false} ;
         BC003718_A1087BoletosDataPagamento = new DateTime[] {DateTime.MinValue} ;
         BC003718_n1087BoletosDataPagamento = new bool[] {false} ;
         BC003718_A1088BoletosDataBaixa = new DateTime[] {DateTime.MinValue} ;
         BC003718_n1088BoletosDataBaixa = new bool[] {false} ;
         BC003718_A1089BoletosValorNominal = new decimal[1] ;
         BC003718_n1089BoletosValorNominal = new bool[] {false} ;
         BC003718_A1090BoletosValorPago = new decimal[1] ;
         BC003718_n1090BoletosValorPago = new bool[] {false} ;
         BC003718_A1091BoletosValorDesconto = new decimal[1] ;
         BC003718_n1091BoletosValorDesconto = new bool[] {false} ;
         BC003718_A1092BoletosValorJuros = new decimal[1] ;
         BC003718_n1092BoletosValorJuros = new bool[] {false} ;
         BC003718_A1093BoletosValorMulta = new decimal[1] ;
         BC003718_n1093BoletosValorMulta = new bool[] {false} ;
         BC003718_A1094BoletosSacadoNome = new string[] {""} ;
         BC003718_n1094BoletosSacadoNome = new bool[] {false} ;
         BC003718_A1095BoletosSacadoDocumento = new string[] {""} ;
         BC003718_n1095BoletosSacadoDocumento = new bool[] {false} ;
         BC003718_A1096BoletosSacadoTipoDocumento = new string[] {""} ;
         BC003718_n1096BoletosSacadoTipoDocumento = new bool[] {false} ;
         BC003718_A1097BoletosMensagemDeErro = new string[] {""} ;
         BC003718_n1097BoletosMensagemDeErro = new bool[] {false} ;
         BC003718_A1098BoletosTentativasDeRegistro = new int[1] ;
         BC003718_n1098BoletosTentativasDeRegistro = new bool[] {false} ;
         BC003718_A1071CarteiraDeCobrancaNome = new string[] {""} ;
         BC003718_n1071CarteiraDeCobrancaNome = new bool[] {false} ;
         BC003718_A1073CarteiraDeCobrancaConvenio = new string[] {""} ;
         BC003718_n1073CarteiraDeCobrancaConvenio = new bool[] {false} ;
         BC003718_A1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         BC003718_n1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         BC003718_A1069CarteiraDeCobrancaId = new int[1] ;
         BC003718_n1069CarteiraDeCobrancaId = new bool[] {false} ;
         BC003718_A261TituloId = new int[1] ;
         BC003718_n261TituloId = new bool[] {false} ;
         BC003718_A1112CarteiraDeCobrancaValorRecebido = new decimal[1] ;
         BC003718_A1111CarteiraDeCobrancaValorTotal = new decimal[1] ;
         BC003718_A1113CarteiraDeCobrancaTotalBoletos = new int[1] ;
         BC003718_A1114CarteiraDeCobrancaTotalBoletosRegistrados = new int[1] ;
         BC003718_n1114CarteiraDeCobrancaTotalBoletosRegistrados = new bool[] {false} ;
         BC003718_A1115CarteiraDeCobrancaTotalBoletosExpirados = new int[1] ;
         BC003718_n1115CarteiraDeCobrancaTotalBoletosExpirados = new bool[] {false} ;
         BC003718_A1116CarteiraDeCobrancaTotalBoletosCancelados = new int[1] ;
         BC003718_n1116CarteiraDeCobrancaTotalBoletosCancelados = new bool[] {false} ;
         BC00374_A1071CarteiraDeCobrancaNome = new string[] {""} ;
         BC00374_n1071CarteiraDeCobrancaNome = new bool[] {false} ;
         BC00374_A1073CarteiraDeCobrancaConvenio = new string[] {""} ;
         BC00374_n1073CarteiraDeCobrancaConvenio = new bool[] {false} ;
         BC00374_A1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         BC00374_n1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         BC00377_A1112CarteiraDeCobrancaValorRecebido = new decimal[1] ;
         BC00377_A1111CarteiraDeCobrancaValorTotal = new decimal[1] ;
         BC00377_A1113CarteiraDeCobrancaTotalBoletos = new int[1] ;
         BC00379_A1114CarteiraDeCobrancaTotalBoletosRegistrados = new int[1] ;
         BC00379_n1114CarteiraDeCobrancaTotalBoletosRegistrados = new bool[] {false} ;
         BC003711_A1115CarteiraDeCobrancaTotalBoletosExpirados = new int[1] ;
         BC003711_n1115CarteiraDeCobrancaTotalBoletosExpirados = new bool[] {false} ;
         BC003713_A1116CarteiraDeCobrancaTotalBoletosCancelados = new int[1] ;
         BC003713_n1116CarteiraDeCobrancaTotalBoletosCancelados = new bool[] {false} ;
         BC00375_A261TituloId = new int[1] ;
         BC00375_n261TituloId = new bool[] {false} ;
         BC003719_A1077BoletosId = new int[1] ;
         BC003719_n1077BoletosId = new bool[] {false} ;
         BC00373_A1077BoletosId = new int[1] ;
         BC00373_n1077BoletosId = new bool[] {false} ;
         BC00373_A1117BoletosResgitroId = new Guid[] {Guid.Empty} ;
         BC00373_n1117BoletosResgitroId = new bool[] {false} ;
         BC00373_A1099BoletosCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00373_n1099BoletosCreatedAt = new bool[] {false} ;
         BC00373_A1100BoletosUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00373_n1100BoletosUpdatedAt = new bool[] {false} ;
         BC00373_A1078BoletosNossoNumero = new string[] {""} ;
         BC00373_n1078BoletosNossoNumero = new bool[] {false} ;
         BC00373_A1079BoletosSeuNumero = new string[] {""} ;
         BC00373_n1079BoletosSeuNumero = new bool[] {false} ;
         BC00373_A1080BoletosNumero = new string[] {""} ;
         BC00373_n1080BoletosNumero = new bool[] {false} ;
         BC00373_A1081BoletosLinhaDigitavel = new string[] {""} ;
         BC00373_n1081BoletosLinhaDigitavel = new bool[] {false} ;
         BC00373_A1082BoletosCodigoDeBarras = new string[] {""} ;
         BC00373_n1082BoletosCodigoDeBarras = new bool[] {false} ;
         BC00373_A1083BoletosStatus = new string[] {""} ;
         BC00373_n1083BoletosStatus = new bool[] {false} ;
         BC00373_A1084BoletosDataEmissao = new DateTime[] {DateTime.MinValue} ;
         BC00373_n1084BoletosDataEmissao = new bool[] {false} ;
         BC00373_A1085BoletosDataVencimento = new DateTime[] {DateTime.MinValue} ;
         BC00373_n1085BoletosDataVencimento = new bool[] {false} ;
         BC00373_A1086BoletosDataRegistro = new DateTime[] {DateTime.MinValue} ;
         BC00373_n1086BoletosDataRegistro = new bool[] {false} ;
         BC00373_A1087BoletosDataPagamento = new DateTime[] {DateTime.MinValue} ;
         BC00373_n1087BoletosDataPagamento = new bool[] {false} ;
         BC00373_A1088BoletosDataBaixa = new DateTime[] {DateTime.MinValue} ;
         BC00373_n1088BoletosDataBaixa = new bool[] {false} ;
         BC00373_A1089BoletosValorNominal = new decimal[1] ;
         BC00373_n1089BoletosValorNominal = new bool[] {false} ;
         BC00373_A1090BoletosValorPago = new decimal[1] ;
         BC00373_n1090BoletosValorPago = new bool[] {false} ;
         BC00373_A1091BoletosValorDesconto = new decimal[1] ;
         BC00373_n1091BoletosValorDesconto = new bool[] {false} ;
         BC00373_A1092BoletosValorJuros = new decimal[1] ;
         BC00373_n1092BoletosValorJuros = new bool[] {false} ;
         BC00373_A1093BoletosValorMulta = new decimal[1] ;
         BC00373_n1093BoletosValorMulta = new bool[] {false} ;
         BC00373_A1094BoletosSacadoNome = new string[] {""} ;
         BC00373_n1094BoletosSacadoNome = new bool[] {false} ;
         BC00373_A1095BoletosSacadoDocumento = new string[] {""} ;
         BC00373_n1095BoletosSacadoDocumento = new bool[] {false} ;
         BC00373_A1096BoletosSacadoTipoDocumento = new string[] {""} ;
         BC00373_n1096BoletosSacadoTipoDocumento = new bool[] {false} ;
         BC00373_A1097BoletosMensagemDeErro = new string[] {""} ;
         BC00373_n1097BoletosMensagemDeErro = new bool[] {false} ;
         BC00373_A1098BoletosTentativasDeRegistro = new int[1] ;
         BC00373_n1098BoletosTentativasDeRegistro = new bool[] {false} ;
         BC00373_A1069CarteiraDeCobrancaId = new int[1] ;
         BC00373_n1069CarteiraDeCobrancaId = new bool[] {false} ;
         BC00373_A261TituloId = new int[1] ;
         BC00373_n261TituloId = new bool[] {false} ;
         sMode111 = "";
         BC00372_A1077BoletosId = new int[1] ;
         BC00372_n1077BoletosId = new bool[] {false} ;
         BC00372_A1117BoletosResgitroId = new Guid[] {Guid.Empty} ;
         BC00372_n1117BoletosResgitroId = new bool[] {false} ;
         BC00372_A1099BoletosCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00372_n1099BoletosCreatedAt = new bool[] {false} ;
         BC00372_A1100BoletosUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00372_n1100BoletosUpdatedAt = new bool[] {false} ;
         BC00372_A1078BoletosNossoNumero = new string[] {""} ;
         BC00372_n1078BoletosNossoNumero = new bool[] {false} ;
         BC00372_A1079BoletosSeuNumero = new string[] {""} ;
         BC00372_n1079BoletosSeuNumero = new bool[] {false} ;
         BC00372_A1080BoletosNumero = new string[] {""} ;
         BC00372_n1080BoletosNumero = new bool[] {false} ;
         BC00372_A1081BoletosLinhaDigitavel = new string[] {""} ;
         BC00372_n1081BoletosLinhaDigitavel = new bool[] {false} ;
         BC00372_A1082BoletosCodigoDeBarras = new string[] {""} ;
         BC00372_n1082BoletosCodigoDeBarras = new bool[] {false} ;
         BC00372_A1083BoletosStatus = new string[] {""} ;
         BC00372_n1083BoletosStatus = new bool[] {false} ;
         BC00372_A1084BoletosDataEmissao = new DateTime[] {DateTime.MinValue} ;
         BC00372_n1084BoletosDataEmissao = new bool[] {false} ;
         BC00372_A1085BoletosDataVencimento = new DateTime[] {DateTime.MinValue} ;
         BC00372_n1085BoletosDataVencimento = new bool[] {false} ;
         BC00372_A1086BoletosDataRegistro = new DateTime[] {DateTime.MinValue} ;
         BC00372_n1086BoletosDataRegistro = new bool[] {false} ;
         BC00372_A1087BoletosDataPagamento = new DateTime[] {DateTime.MinValue} ;
         BC00372_n1087BoletosDataPagamento = new bool[] {false} ;
         BC00372_A1088BoletosDataBaixa = new DateTime[] {DateTime.MinValue} ;
         BC00372_n1088BoletosDataBaixa = new bool[] {false} ;
         BC00372_A1089BoletosValorNominal = new decimal[1] ;
         BC00372_n1089BoletosValorNominal = new bool[] {false} ;
         BC00372_A1090BoletosValorPago = new decimal[1] ;
         BC00372_n1090BoletosValorPago = new bool[] {false} ;
         BC00372_A1091BoletosValorDesconto = new decimal[1] ;
         BC00372_n1091BoletosValorDesconto = new bool[] {false} ;
         BC00372_A1092BoletosValorJuros = new decimal[1] ;
         BC00372_n1092BoletosValorJuros = new bool[] {false} ;
         BC00372_A1093BoletosValorMulta = new decimal[1] ;
         BC00372_n1093BoletosValorMulta = new bool[] {false} ;
         BC00372_A1094BoletosSacadoNome = new string[] {""} ;
         BC00372_n1094BoletosSacadoNome = new bool[] {false} ;
         BC00372_A1095BoletosSacadoDocumento = new string[] {""} ;
         BC00372_n1095BoletosSacadoDocumento = new bool[] {false} ;
         BC00372_A1096BoletosSacadoTipoDocumento = new string[] {""} ;
         BC00372_n1096BoletosSacadoTipoDocumento = new bool[] {false} ;
         BC00372_A1097BoletosMensagemDeErro = new string[] {""} ;
         BC00372_n1097BoletosMensagemDeErro = new bool[] {false} ;
         BC00372_A1098BoletosTentativasDeRegistro = new int[1] ;
         BC00372_n1098BoletosTentativasDeRegistro = new bool[] {false} ;
         BC00372_A1069CarteiraDeCobrancaId = new int[1] ;
         BC00372_n1069CarteiraDeCobrancaId = new bool[] {false} ;
         BC00372_A261TituloId = new int[1] ;
         BC00372_n261TituloId = new bool[] {false} ;
         BC003721_A1077BoletosId = new int[1] ;
         BC003721_n1077BoletosId = new bool[] {false} ;
         BC003724_A1071CarteiraDeCobrancaNome = new string[] {""} ;
         BC003724_n1071CarteiraDeCobrancaNome = new bool[] {false} ;
         BC003724_A1073CarteiraDeCobrancaConvenio = new string[] {""} ;
         BC003724_n1073CarteiraDeCobrancaConvenio = new bool[] {false} ;
         BC003724_A1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         BC003724_n1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         BC003726_A1112CarteiraDeCobrancaValorRecebido = new decimal[1] ;
         BC003726_A1111CarteiraDeCobrancaValorTotal = new decimal[1] ;
         BC003726_A1113CarteiraDeCobrancaTotalBoletos = new int[1] ;
         BC003728_A1114CarteiraDeCobrancaTotalBoletosRegistrados = new int[1] ;
         BC003728_n1114CarteiraDeCobrancaTotalBoletosRegistrados = new bool[] {false} ;
         BC003730_A1115CarteiraDeCobrancaTotalBoletosExpirados = new int[1] ;
         BC003730_n1115CarteiraDeCobrancaTotalBoletosExpirados = new bool[] {false} ;
         BC003732_A1116CarteiraDeCobrancaTotalBoletosCancelados = new int[1] ;
         BC003732_n1116CarteiraDeCobrancaTotalBoletosCancelados = new bool[] {false} ;
         BC003733_A1101BoletosLogId = new int[1] ;
         BC003738_A1077BoletosId = new int[1] ;
         BC003738_n1077BoletosId = new bool[] {false} ;
         BC003738_A1117BoletosResgitroId = new Guid[] {Guid.Empty} ;
         BC003738_n1117BoletosResgitroId = new bool[] {false} ;
         BC003738_A1099BoletosCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC003738_n1099BoletosCreatedAt = new bool[] {false} ;
         BC003738_A1100BoletosUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC003738_n1100BoletosUpdatedAt = new bool[] {false} ;
         BC003738_A1078BoletosNossoNumero = new string[] {""} ;
         BC003738_n1078BoletosNossoNumero = new bool[] {false} ;
         BC003738_A1079BoletosSeuNumero = new string[] {""} ;
         BC003738_n1079BoletosSeuNumero = new bool[] {false} ;
         BC003738_A1080BoletosNumero = new string[] {""} ;
         BC003738_n1080BoletosNumero = new bool[] {false} ;
         BC003738_A1081BoletosLinhaDigitavel = new string[] {""} ;
         BC003738_n1081BoletosLinhaDigitavel = new bool[] {false} ;
         BC003738_A1082BoletosCodigoDeBarras = new string[] {""} ;
         BC003738_n1082BoletosCodigoDeBarras = new bool[] {false} ;
         BC003738_A1083BoletosStatus = new string[] {""} ;
         BC003738_n1083BoletosStatus = new bool[] {false} ;
         BC003738_A1084BoletosDataEmissao = new DateTime[] {DateTime.MinValue} ;
         BC003738_n1084BoletosDataEmissao = new bool[] {false} ;
         BC003738_A1085BoletosDataVencimento = new DateTime[] {DateTime.MinValue} ;
         BC003738_n1085BoletosDataVencimento = new bool[] {false} ;
         BC003738_A1086BoletosDataRegistro = new DateTime[] {DateTime.MinValue} ;
         BC003738_n1086BoletosDataRegistro = new bool[] {false} ;
         BC003738_A1087BoletosDataPagamento = new DateTime[] {DateTime.MinValue} ;
         BC003738_n1087BoletosDataPagamento = new bool[] {false} ;
         BC003738_A1088BoletosDataBaixa = new DateTime[] {DateTime.MinValue} ;
         BC003738_n1088BoletosDataBaixa = new bool[] {false} ;
         BC003738_A1089BoletosValorNominal = new decimal[1] ;
         BC003738_n1089BoletosValorNominal = new bool[] {false} ;
         BC003738_A1090BoletosValorPago = new decimal[1] ;
         BC003738_n1090BoletosValorPago = new bool[] {false} ;
         BC003738_A1091BoletosValorDesconto = new decimal[1] ;
         BC003738_n1091BoletosValorDesconto = new bool[] {false} ;
         BC003738_A1092BoletosValorJuros = new decimal[1] ;
         BC003738_n1092BoletosValorJuros = new bool[] {false} ;
         BC003738_A1093BoletosValorMulta = new decimal[1] ;
         BC003738_n1093BoletosValorMulta = new bool[] {false} ;
         BC003738_A1094BoletosSacadoNome = new string[] {""} ;
         BC003738_n1094BoletosSacadoNome = new bool[] {false} ;
         BC003738_A1095BoletosSacadoDocumento = new string[] {""} ;
         BC003738_n1095BoletosSacadoDocumento = new bool[] {false} ;
         BC003738_A1096BoletosSacadoTipoDocumento = new string[] {""} ;
         BC003738_n1096BoletosSacadoTipoDocumento = new bool[] {false} ;
         BC003738_A1097BoletosMensagemDeErro = new string[] {""} ;
         BC003738_n1097BoletosMensagemDeErro = new bool[] {false} ;
         BC003738_A1098BoletosTentativasDeRegistro = new int[1] ;
         BC003738_n1098BoletosTentativasDeRegistro = new bool[] {false} ;
         BC003738_A1071CarteiraDeCobrancaNome = new string[] {""} ;
         BC003738_n1071CarteiraDeCobrancaNome = new bool[] {false} ;
         BC003738_A1073CarteiraDeCobrancaConvenio = new string[] {""} ;
         BC003738_n1073CarteiraDeCobrancaConvenio = new bool[] {false} ;
         BC003738_A1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         BC003738_n1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         BC003738_A1069CarteiraDeCobrancaId = new int[1] ;
         BC003738_n1069CarteiraDeCobrancaId = new bool[] {false} ;
         BC003738_A261TituloId = new int[1] ;
         BC003738_n261TituloId = new bool[] {false} ;
         BC003738_A1112CarteiraDeCobrancaValorRecebido = new decimal[1] ;
         BC003738_A1111CarteiraDeCobrancaValorTotal = new decimal[1] ;
         BC003738_A1113CarteiraDeCobrancaTotalBoletos = new int[1] ;
         BC003738_A1114CarteiraDeCobrancaTotalBoletosRegistrados = new int[1] ;
         BC003738_n1114CarteiraDeCobrancaTotalBoletosRegistrados = new bool[] {false} ;
         BC003738_A1115CarteiraDeCobrancaTotalBoletosExpirados = new int[1] ;
         BC003738_n1115CarteiraDeCobrancaTotalBoletosExpirados = new bool[] {false} ;
         BC003738_A1116CarteiraDeCobrancaTotalBoletosCancelados = new int[1] ;
         BC003738_n1116CarteiraDeCobrancaTotalBoletosCancelados = new bool[] {false} ;
         i1117BoletosResgitroId = Guid.Empty;
         i1099BoletosCreatedAt = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.boleto_bc__default(),
            new Object[][] {
                new Object[] {
               BC00372_A1077BoletosId, BC00372_A1117BoletosResgitroId, BC00372_n1117BoletosResgitroId, BC00372_A1099BoletosCreatedAt, BC00372_n1099BoletosCreatedAt, BC00372_A1100BoletosUpdatedAt, BC00372_n1100BoletosUpdatedAt, BC00372_A1078BoletosNossoNumero, BC00372_n1078BoletosNossoNumero, BC00372_A1079BoletosSeuNumero,
               BC00372_n1079BoletosSeuNumero, BC00372_A1080BoletosNumero, BC00372_n1080BoletosNumero, BC00372_A1081BoletosLinhaDigitavel, BC00372_n1081BoletosLinhaDigitavel, BC00372_A1082BoletosCodigoDeBarras, BC00372_n1082BoletosCodigoDeBarras, BC00372_A1083BoletosStatus, BC00372_n1083BoletosStatus, BC00372_A1084BoletosDataEmissao,
               BC00372_n1084BoletosDataEmissao, BC00372_A1085BoletosDataVencimento, BC00372_n1085BoletosDataVencimento, BC00372_A1086BoletosDataRegistro, BC00372_n1086BoletosDataRegistro, BC00372_A1087BoletosDataPagamento, BC00372_n1087BoletosDataPagamento, BC00372_A1088BoletosDataBaixa, BC00372_n1088BoletosDataBaixa, BC00372_A1089BoletosValorNominal,
               BC00372_n1089BoletosValorNominal, BC00372_A1090BoletosValorPago, BC00372_n1090BoletosValorPago, BC00372_A1091BoletosValorDesconto, BC00372_n1091BoletosValorDesconto, BC00372_A1092BoletosValorJuros, BC00372_n1092BoletosValorJuros, BC00372_A1093BoletosValorMulta, BC00372_n1093BoletosValorMulta, BC00372_A1094BoletosSacadoNome,
               BC00372_n1094BoletosSacadoNome, BC00372_A1095BoletosSacadoDocumento, BC00372_n1095BoletosSacadoDocumento, BC00372_A1096BoletosSacadoTipoDocumento, BC00372_n1096BoletosSacadoTipoDocumento, BC00372_A1097BoletosMensagemDeErro, BC00372_n1097BoletosMensagemDeErro, BC00372_A1098BoletosTentativasDeRegistro, BC00372_n1098BoletosTentativasDeRegistro, BC00372_A1069CarteiraDeCobrancaId,
               BC00372_n1069CarteiraDeCobrancaId, BC00372_A261TituloId, BC00372_n261TituloId
               }
               , new Object[] {
               BC00373_A1077BoletosId, BC00373_A1117BoletosResgitroId, BC00373_n1117BoletosResgitroId, BC00373_A1099BoletosCreatedAt, BC00373_n1099BoletosCreatedAt, BC00373_A1100BoletosUpdatedAt, BC00373_n1100BoletosUpdatedAt, BC00373_A1078BoletosNossoNumero, BC00373_n1078BoletosNossoNumero, BC00373_A1079BoletosSeuNumero,
               BC00373_n1079BoletosSeuNumero, BC00373_A1080BoletosNumero, BC00373_n1080BoletosNumero, BC00373_A1081BoletosLinhaDigitavel, BC00373_n1081BoletosLinhaDigitavel, BC00373_A1082BoletosCodigoDeBarras, BC00373_n1082BoletosCodigoDeBarras, BC00373_A1083BoletosStatus, BC00373_n1083BoletosStatus, BC00373_A1084BoletosDataEmissao,
               BC00373_n1084BoletosDataEmissao, BC00373_A1085BoletosDataVencimento, BC00373_n1085BoletosDataVencimento, BC00373_A1086BoletosDataRegistro, BC00373_n1086BoletosDataRegistro, BC00373_A1087BoletosDataPagamento, BC00373_n1087BoletosDataPagamento, BC00373_A1088BoletosDataBaixa, BC00373_n1088BoletosDataBaixa, BC00373_A1089BoletosValorNominal,
               BC00373_n1089BoletosValorNominal, BC00373_A1090BoletosValorPago, BC00373_n1090BoletosValorPago, BC00373_A1091BoletosValorDesconto, BC00373_n1091BoletosValorDesconto, BC00373_A1092BoletosValorJuros, BC00373_n1092BoletosValorJuros, BC00373_A1093BoletosValorMulta, BC00373_n1093BoletosValorMulta, BC00373_A1094BoletosSacadoNome,
               BC00373_n1094BoletosSacadoNome, BC00373_A1095BoletosSacadoDocumento, BC00373_n1095BoletosSacadoDocumento, BC00373_A1096BoletosSacadoTipoDocumento, BC00373_n1096BoletosSacadoTipoDocumento, BC00373_A1097BoletosMensagemDeErro, BC00373_n1097BoletosMensagemDeErro, BC00373_A1098BoletosTentativasDeRegistro, BC00373_n1098BoletosTentativasDeRegistro, BC00373_A1069CarteiraDeCobrancaId,
               BC00373_n1069CarteiraDeCobrancaId, BC00373_A261TituloId, BC00373_n261TituloId
               }
               , new Object[] {
               BC00374_A1071CarteiraDeCobrancaNome, BC00374_n1071CarteiraDeCobrancaNome, BC00374_A1073CarteiraDeCobrancaConvenio, BC00374_n1073CarteiraDeCobrancaConvenio, BC00374_A1074CarteiraDeCobrancaStatus, BC00374_n1074CarteiraDeCobrancaStatus
               }
               , new Object[] {
               BC00375_A261TituloId
               }
               , new Object[] {
               BC00377_A1112CarteiraDeCobrancaValorRecebido, BC00377_A1111CarteiraDeCobrancaValorTotal, BC00377_A1113CarteiraDeCobrancaTotalBoletos
               }
               , new Object[] {
               BC00379_A1114CarteiraDeCobrancaTotalBoletosRegistrados, BC00379_n1114CarteiraDeCobrancaTotalBoletosRegistrados
               }
               , new Object[] {
               BC003711_A1115CarteiraDeCobrancaTotalBoletosExpirados, BC003711_n1115CarteiraDeCobrancaTotalBoletosExpirados
               }
               , new Object[] {
               BC003713_A1116CarteiraDeCobrancaTotalBoletosCancelados, BC003713_n1116CarteiraDeCobrancaTotalBoletosCancelados
               }
               , new Object[] {
               BC003718_A1077BoletosId, BC003718_A1117BoletosResgitroId, BC003718_n1117BoletosResgitroId, BC003718_A1099BoletosCreatedAt, BC003718_n1099BoletosCreatedAt, BC003718_A1100BoletosUpdatedAt, BC003718_n1100BoletosUpdatedAt, BC003718_A1078BoletosNossoNumero, BC003718_n1078BoletosNossoNumero, BC003718_A1079BoletosSeuNumero,
               BC003718_n1079BoletosSeuNumero, BC003718_A1080BoletosNumero, BC003718_n1080BoletosNumero, BC003718_A1081BoletosLinhaDigitavel, BC003718_n1081BoletosLinhaDigitavel, BC003718_A1082BoletosCodigoDeBarras, BC003718_n1082BoletosCodigoDeBarras, BC003718_A1083BoletosStatus, BC003718_n1083BoletosStatus, BC003718_A1084BoletosDataEmissao,
               BC003718_n1084BoletosDataEmissao, BC003718_A1085BoletosDataVencimento, BC003718_n1085BoletosDataVencimento, BC003718_A1086BoletosDataRegistro, BC003718_n1086BoletosDataRegistro, BC003718_A1087BoletosDataPagamento, BC003718_n1087BoletosDataPagamento, BC003718_A1088BoletosDataBaixa, BC003718_n1088BoletosDataBaixa, BC003718_A1089BoletosValorNominal,
               BC003718_n1089BoletosValorNominal, BC003718_A1090BoletosValorPago, BC003718_n1090BoletosValorPago, BC003718_A1091BoletosValorDesconto, BC003718_n1091BoletosValorDesconto, BC003718_A1092BoletosValorJuros, BC003718_n1092BoletosValorJuros, BC003718_A1093BoletosValorMulta, BC003718_n1093BoletosValorMulta, BC003718_A1094BoletosSacadoNome,
               BC003718_n1094BoletosSacadoNome, BC003718_A1095BoletosSacadoDocumento, BC003718_n1095BoletosSacadoDocumento, BC003718_A1096BoletosSacadoTipoDocumento, BC003718_n1096BoletosSacadoTipoDocumento, BC003718_A1097BoletosMensagemDeErro, BC003718_n1097BoletosMensagemDeErro, BC003718_A1098BoletosTentativasDeRegistro, BC003718_n1098BoletosTentativasDeRegistro, BC003718_A1071CarteiraDeCobrancaNome,
               BC003718_n1071CarteiraDeCobrancaNome, BC003718_A1073CarteiraDeCobrancaConvenio, BC003718_n1073CarteiraDeCobrancaConvenio, BC003718_A1074CarteiraDeCobrancaStatus, BC003718_n1074CarteiraDeCobrancaStatus, BC003718_A1069CarteiraDeCobrancaId, BC003718_n1069CarteiraDeCobrancaId, BC003718_A261TituloId, BC003718_n261TituloId, BC003718_A1112CarteiraDeCobrancaValorRecebido,
               BC003718_A1111CarteiraDeCobrancaValorTotal, BC003718_A1113CarteiraDeCobrancaTotalBoletos, BC003718_A1114CarteiraDeCobrancaTotalBoletosRegistrados, BC003718_n1114CarteiraDeCobrancaTotalBoletosRegistrados, BC003718_A1115CarteiraDeCobrancaTotalBoletosExpirados, BC003718_n1115CarteiraDeCobrancaTotalBoletosExpirados, BC003718_A1116CarteiraDeCobrancaTotalBoletosCancelados, BC003718_n1116CarteiraDeCobrancaTotalBoletosCancelados
               }
               , new Object[] {
               BC003719_A1077BoletosId
               }
               , new Object[] {
               }
               , new Object[] {
               BC003721_A1077BoletosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC003724_A1071CarteiraDeCobrancaNome, BC003724_n1071CarteiraDeCobrancaNome, BC003724_A1073CarteiraDeCobrancaConvenio, BC003724_n1073CarteiraDeCobrancaConvenio, BC003724_A1074CarteiraDeCobrancaStatus, BC003724_n1074CarteiraDeCobrancaStatus
               }
               , new Object[] {
               BC003726_A1112CarteiraDeCobrancaValorRecebido, BC003726_A1111CarteiraDeCobrancaValorTotal, BC003726_A1113CarteiraDeCobrancaTotalBoletos
               }
               , new Object[] {
               BC003728_A1114CarteiraDeCobrancaTotalBoletosRegistrados, BC003728_n1114CarteiraDeCobrancaTotalBoletosRegistrados
               }
               , new Object[] {
               BC003730_A1115CarteiraDeCobrancaTotalBoletosExpirados, BC003730_n1115CarteiraDeCobrancaTotalBoletosExpirados
               }
               , new Object[] {
               BC003732_A1116CarteiraDeCobrancaTotalBoletosCancelados, BC003732_n1116CarteiraDeCobrancaTotalBoletosCancelados
               }
               , new Object[] {
               BC003733_A1101BoletosLogId
               }
               , new Object[] {
               BC003738_A1077BoletosId, BC003738_A1117BoletosResgitroId, BC003738_n1117BoletosResgitroId, BC003738_A1099BoletosCreatedAt, BC003738_n1099BoletosCreatedAt, BC003738_A1100BoletosUpdatedAt, BC003738_n1100BoletosUpdatedAt, BC003738_A1078BoletosNossoNumero, BC003738_n1078BoletosNossoNumero, BC003738_A1079BoletosSeuNumero,
               BC003738_n1079BoletosSeuNumero, BC003738_A1080BoletosNumero, BC003738_n1080BoletosNumero, BC003738_A1081BoletosLinhaDigitavel, BC003738_n1081BoletosLinhaDigitavel, BC003738_A1082BoletosCodigoDeBarras, BC003738_n1082BoletosCodigoDeBarras, BC003738_A1083BoletosStatus, BC003738_n1083BoletosStatus, BC003738_A1084BoletosDataEmissao,
               BC003738_n1084BoletosDataEmissao, BC003738_A1085BoletosDataVencimento, BC003738_n1085BoletosDataVencimento, BC003738_A1086BoletosDataRegistro, BC003738_n1086BoletosDataRegistro, BC003738_A1087BoletosDataPagamento, BC003738_n1087BoletosDataPagamento, BC003738_A1088BoletosDataBaixa, BC003738_n1088BoletosDataBaixa, BC003738_A1089BoletosValorNominal,
               BC003738_n1089BoletosValorNominal, BC003738_A1090BoletosValorPago, BC003738_n1090BoletosValorPago, BC003738_A1091BoletosValorDesconto, BC003738_n1091BoletosValorDesconto, BC003738_A1092BoletosValorJuros, BC003738_n1092BoletosValorJuros, BC003738_A1093BoletosValorMulta, BC003738_n1093BoletosValorMulta, BC003738_A1094BoletosSacadoNome,
               BC003738_n1094BoletosSacadoNome, BC003738_A1095BoletosSacadoDocumento, BC003738_n1095BoletosSacadoDocumento, BC003738_A1096BoletosSacadoTipoDocumento, BC003738_n1096BoletosSacadoTipoDocumento, BC003738_A1097BoletosMensagemDeErro, BC003738_n1097BoletosMensagemDeErro, BC003738_A1098BoletosTentativasDeRegistro, BC003738_n1098BoletosTentativasDeRegistro, BC003738_A1071CarteiraDeCobrancaNome,
               BC003738_n1071CarteiraDeCobrancaNome, BC003738_A1073CarteiraDeCobrancaConvenio, BC003738_n1073CarteiraDeCobrancaConvenio, BC003738_A1074CarteiraDeCobrancaStatus, BC003738_n1074CarteiraDeCobrancaStatus, BC003738_A1069CarteiraDeCobrancaId, BC003738_n1069CarteiraDeCobrancaId, BC003738_A261TituloId, BC003738_n261TituloId, BC003738_A1112CarteiraDeCobrancaValorRecebido,
               BC003738_A1111CarteiraDeCobrancaValorTotal, BC003738_A1113CarteiraDeCobrancaTotalBoletos, BC003738_A1114CarteiraDeCobrancaTotalBoletosRegistrados, BC003738_n1114CarteiraDeCobrancaTotalBoletosRegistrados, BC003738_A1115CarteiraDeCobrancaTotalBoletosExpirados, BC003738_n1115CarteiraDeCobrancaTotalBoletosExpirados, BC003738_A1116CarteiraDeCobrancaTotalBoletosCancelados, BC003738_n1116CarteiraDeCobrancaTotalBoletosCancelados
               }
            }
         );
         Z1117BoletosResgitroId = Guid.NewGuid( );
         n1117BoletosResgitroId = false;
         A1117BoletosResgitroId = Guid.NewGuid( );
         n1117BoletosResgitroId = false;
         i1117BoletosResgitroId = Guid.NewGuid( );
         n1117BoletosResgitroId = false;
         AV22Pgmname = "Boleto_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12372 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound111 ;
      private int trnEnded ;
      private int Z1077BoletosId ;
      private int A1077BoletosId ;
      private int AV23GXV1 ;
      private int AV11Insert_CarteiraDeCobrancaId ;
      private int AV12Insert_TituloId ;
      private int Z1098BoletosTentativasDeRegistro ;
      private int A1098BoletosTentativasDeRegistro ;
      private int Z1069CarteiraDeCobrancaId ;
      private int A1069CarteiraDeCobrancaId ;
      private int Z261TituloId ;
      private int A261TituloId ;
      private int Z1113CarteiraDeCobrancaTotalBoletos ;
      private int A1113CarteiraDeCobrancaTotalBoletos ;
      private int Z1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private int A1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private int Z1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private int A1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private int Z1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private int A1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private decimal Z1089BoletosValorNominal ;
      private decimal A1089BoletosValorNominal ;
      private decimal Z1090BoletosValorPago ;
      private decimal A1090BoletosValorPago ;
      private decimal Z1091BoletosValorDesconto ;
      private decimal A1091BoletosValorDesconto ;
      private decimal Z1092BoletosValorJuros ;
      private decimal A1092BoletosValorJuros ;
      private decimal Z1093BoletosValorMulta ;
      private decimal A1093BoletosValorMulta ;
      private decimal Z1111CarteiraDeCobrancaValorTotal ;
      private decimal A1111CarteiraDeCobrancaValorTotal ;
      private decimal Z1112CarteiraDeCobrancaValorRecebido ;
      private decimal A1112CarteiraDeCobrancaValorRecebido ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV22Pgmname ;
      private string sMode111 ;
      private DateTime Z1099BoletosCreatedAt ;
      private DateTime A1099BoletosCreatedAt ;
      private DateTime Z1100BoletosUpdatedAt ;
      private DateTime A1100BoletosUpdatedAt ;
      private DateTime Z1086BoletosDataRegistro ;
      private DateTime A1086BoletosDataRegistro ;
      private DateTime i1099BoletosCreatedAt ;
      private DateTime Z1084BoletosDataEmissao ;
      private DateTime A1084BoletosDataEmissao ;
      private DateTime Z1085BoletosDataVencimento ;
      private DateTime A1085BoletosDataVencimento ;
      private DateTime Z1087BoletosDataPagamento ;
      private DateTime A1087BoletosDataPagamento ;
      private DateTime Z1088BoletosDataBaixa ;
      private DateTime A1088BoletosDataBaixa ;
      private bool returnInSub ;
      private bool Z1074CarteiraDeCobrancaStatus ;
      private bool A1074CarteiraDeCobrancaStatus ;
      private bool n1117BoletosResgitroId ;
      private bool n1099BoletosCreatedAt ;
      private bool n1100BoletosUpdatedAt ;
      private bool n1077BoletosId ;
      private bool n1078BoletosNossoNumero ;
      private bool n1079BoletosSeuNumero ;
      private bool n1080BoletosNumero ;
      private bool n1081BoletosLinhaDigitavel ;
      private bool n1082BoletosCodigoDeBarras ;
      private bool n1083BoletosStatus ;
      private bool n1084BoletosDataEmissao ;
      private bool n1085BoletosDataVencimento ;
      private bool n1086BoletosDataRegistro ;
      private bool n1087BoletosDataPagamento ;
      private bool n1088BoletosDataBaixa ;
      private bool n1089BoletosValorNominal ;
      private bool n1090BoletosValorPago ;
      private bool n1091BoletosValorDesconto ;
      private bool n1092BoletosValorJuros ;
      private bool n1093BoletosValorMulta ;
      private bool n1094BoletosSacadoNome ;
      private bool n1095BoletosSacadoDocumento ;
      private bool n1096BoletosSacadoTipoDocumento ;
      private bool n1097BoletosMensagemDeErro ;
      private bool n1098BoletosTentativasDeRegistro ;
      private bool n1071CarteiraDeCobrancaNome ;
      private bool n1073CarteiraDeCobrancaConvenio ;
      private bool n1074CarteiraDeCobrancaStatus ;
      private bool n1069CarteiraDeCobrancaId ;
      private bool n261TituloId ;
      private bool n1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private bool n1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private bool n1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private bool Gx_longc ;
      private string Z1097BoletosMensagemDeErro ;
      private string A1097BoletosMensagemDeErro ;
      private string Z1078BoletosNossoNumero ;
      private string A1078BoletosNossoNumero ;
      private string Z1079BoletosSeuNumero ;
      private string A1079BoletosSeuNumero ;
      private string Z1080BoletosNumero ;
      private string A1080BoletosNumero ;
      private string Z1081BoletosLinhaDigitavel ;
      private string A1081BoletosLinhaDigitavel ;
      private string Z1082BoletosCodigoDeBarras ;
      private string A1082BoletosCodigoDeBarras ;
      private string Z1083BoletosStatus ;
      private string A1083BoletosStatus ;
      private string Z1094BoletosSacadoNome ;
      private string A1094BoletosSacadoNome ;
      private string Z1095BoletosSacadoDocumento ;
      private string A1095BoletosSacadoDocumento ;
      private string Z1096BoletosSacadoTipoDocumento ;
      private string A1096BoletosSacadoTipoDocumento ;
      private string Z1071CarteiraDeCobrancaNome ;
      private string A1071CarteiraDeCobrancaNome ;
      private string Z1073CarteiraDeCobrancaConvenio ;
      private string A1073CarteiraDeCobrancaConvenio ;
      private Guid Z1117BoletosResgitroId ;
      private Guid A1117BoletosResgitroId ;
      private Guid i1117BoletosResgitroId ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] BC003718_A1077BoletosId ;
      private bool[] BC003718_n1077BoletosId ;
      private Guid[] BC003718_A1117BoletosResgitroId ;
      private bool[] BC003718_n1117BoletosResgitroId ;
      private DateTime[] BC003718_A1099BoletosCreatedAt ;
      private bool[] BC003718_n1099BoletosCreatedAt ;
      private DateTime[] BC003718_A1100BoletosUpdatedAt ;
      private bool[] BC003718_n1100BoletosUpdatedAt ;
      private string[] BC003718_A1078BoletosNossoNumero ;
      private bool[] BC003718_n1078BoletosNossoNumero ;
      private string[] BC003718_A1079BoletosSeuNumero ;
      private bool[] BC003718_n1079BoletosSeuNumero ;
      private string[] BC003718_A1080BoletosNumero ;
      private bool[] BC003718_n1080BoletosNumero ;
      private string[] BC003718_A1081BoletosLinhaDigitavel ;
      private bool[] BC003718_n1081BoletosLinhaDigitavel ;
      private string[] BC003718_A1082BoletosCodigoDeBarras ;
      private bool[] BC003718_n1082BoletosCodigoDeBarras ;
      private string[] BC003718_A1083BoletosStatus ;
      private bool[] BC003718_n1083BoletosStatus ;
      private DateTime[] BC003718_A1084BoletosDataEmissao ;
      private bool[] BC003718_n1084BoletosDataEmissao ;
      private DateTime[] BC003718_A1085BoletosDataVencimento ;
      private bool[] BC003718_n1085BoletosDataVencimento ;
      private DateTime[] BC003718_A1086BoletosDataRegistro ;
      private bool[] BC003718_n1086BoletosDataRegistro ;
      private DateTime[] BC003718_A1087BoletosDataPagamento ;
      private bool[] BC003718_n1087BoletosDataPagamento ;
      private DateTime[] BC003718_A1088BoletosDataBaixa ;
      private bool[] BC003718_n1088BoletosDataBaixa ;
      private decimal[] BC003718_A1089BoletosValorNominal ;
      private bool[] BC003718_n1089BoletosValorNominal ;
      private decimal[] BC003718_A1090BoletosValorPago ;
      private bool[] BC003718_n1090BoletosValorPago ;
      private decimal[] BC003718_A1091BoletosValorDesconto ;
      private bool[] BC003718_n1091BoletosValorDesconto ;
      private decimal[] BC003718_A1092BoletosValorJuros ;
      private bool[] BC003718_n1092BoletosValorJuros ;
      private decimal[] BC003718_A1093BoletosValorMulta ;
      private bool[] BC003718_n1093BoletosValorMulta ;
      private string[] BC003718_A1094BoletosSacadoNome ;
      private bool[] BC003718_n1094BoletosSacadoNome ;
      private string[] BC003718_A1095BoletosSacadoDocumento ;
      private bool[] BC003718_n1095BoletosSacadoDocumento ;
      private string[] BC003718_A1096BoletosSacadoTipoDocumento ;
      private bool[] BC003718_n1096BoletosSacadoTipoDocumento ;
      private string[] BC003718_A1097BoletosMensagemDeErro ;
      private bool[] BC003718_n1097BoletosMensagemDeErro ;
      private int[] BC003718_A1098BoletosTentativasDeRegistro ;
      private bool[] BC003718_n1098BoletosTentativasDeRegistro ;
      private string[] BC003718_A1071CarteiraDeCobrancaNome ;
      private bool[] BC003718_n1071CarteiraDeCobrancaNome ;
      private string[] BC003718_A1073CarteiraDeCobrancaConvenio ;
      private bool[] BC003718_n1073CarteiraDeCobrancaConvenio ;
      private bool[] BC003718_A1074CarteiraDeCobrancaStatus ;
      private bool[] BC003718_n1074CarteiraDeCobrancaStatus ;
      private int[] BC003718_A1069CarteiraDeCobrancaId ;
      private bool[] BC003718_n1069CarteiraDeCobrancaId ;
      private int[] BC003718_A261TituloId ;
      private bool[] BC003718_n261TituloId ;
      private decimal[] BC003718_A1112CarteiraDeCobrancaValorRecebido ;
      private decimal[] BC003718_A1111CarteiraDeCobrancaValorTotal ;
      private int[] BC003718_A1113CarteiraDeCobrancaTotalBoletos ;
      private int[] BC003718_A1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private bool[] BC003718_n1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private int[] BC003718_A1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private bool[] BC003718_n1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private int[] BC003718_A1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private bool[] BC003718_n1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private string[] BC00374_A1071CarteiraDeCobrancaNome ;
      private bool[] BC00374_n1071CarteiraDeCobrancaNome ;
      private string[] BC00374_A1073CarteiraDeCobrancaConvenio ;
      private bool[] BC00374_n1073CarteiraDeCobrancaConvenio ;
      private bool[] BC00374_A1074CarteiraDeCobrancaStatus ;
      private bool[] BC00374_n1074CarteiraDeCobrancaStatus ;
      private decimal[] BC00377_A1112CarteiraDeCobrancaValorRecebido ;
      private decimal[] BC00377_A1111CarteiraDeCobrancaValorTotal ;
      private int[] BC00377_A1113CarteiraDeCobrancaTotalBoletos ;
      private int[] BC00379_A1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private bool[] BC00379_n1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private int[] BC003711_A1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private bool[] BC003711_n1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private int[] BC003713_A1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private bool[] BC003713_n1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private int[] BC00375_A261TituloId ;
      private bool[] BC00375_n261TituloId ;
      private int[] BC003719_A1077BoletosId ;
      private bool[] BC003719_n1077BoletosId ;
      private int[] BC00373_A1077BoletosId ;
      private bool[] BC00373_n1077BoletosId ;
      private Guid[] BC00373_A1117BoletosResgitroId ;
      private bool[] BC00373_n1117BoletosResgitroId ;
      private DateTime[] BC00373_A1099BoletosCreatedAt ;
      private bool[] BC00373_n1099BoletosCreatedAt ;
      private DateTime[] BC00373_A1100BoletosUpdatedAt ;
      private bool[] BC00373_n1100BoletosUpdatedAt ;
      private string[] BC00373_A1078BoletosNossoNumero ;
      private bool[] BC00373_n1078BoletosNossoNumero ;
      private string[] BC00373_A1079BoletosSeuNumero ;
      private bool[] BC00373_n1079BoletosSeuNumero ;
      private string[] BC00373_A1080BoletosNumero ;
      private bool[] BC00373_n1080BoletosNumero ;
      private string[] BC00373_A1081BoletosLinhaDigitavel ;
      private bool[] BC00373_n1081BoletosLinhaDigitavel ;
      private string[] BC00373_A1082BoletosCodigoDeBarras ;
      private bool[] BC00373_n1082BoletosCodigoDeBarras ;
      private string[] BC00373_A1083BoletosStatus ;
      private bool[] BC00373_n1083BoletosStatus ;
      private DateTime[] BC00373_A1084BoletosDataEmissao ;
      private bool[] BC00373_n1084BoletosDataEmissao ;
      private DateTime[] BC00373_A1085BoletosDataVencimento ;
      private bool[] BC00373_n1085BoletosDataVencimento ;
      private DateTime[] BC00373_A1086BoletosDataRegistro ;
      private bool[] BC00373_n1086BoletosDataRegistro ;
      private DateTime[] BC00373_A1087BoletosDataPagamento ;
      private bool[] BC00373_n1087BoletosDataPagamento ;
      private DateTime[] BC00373_A1088BoletosDataBaixa ;
      private bool[] BC00373_n1088BoletosDataBaixa ;
      private decimal[] BC00373_A1089BoletosValorNominal ;
      private bool[] BC00373_n1089BoletosValorNominal ;
      private decimal[] BC00373_A1090BoletosValorPago ;
      private bool[] BC00373_n1090BoletosValorPago ;
      private decimal[] BC00373_A1091BoletosValorDesconto ;
      private bool[] BC00373_n1091BoletosValorDesconto ;
      private decimal[] BC00373_A1092BoletosValorJuros ;
      private bool[] BC00373_n1092BoletosValorJuros ;
      private decimal[] BC00373_A1093BoletosValorMulta ;
      private bool[] BC00373_n1093BoletosValorMulta ;
      private string[] BC00373_A1094BoletosSacadoNome ;
      private bool[] BC00373_n1094BoletosSacadoNome ;
      private string[] BC00373_A1095BoletosSacadoDocumento ;
      private bool[] BC00373_n1095BoletosSacadoDocumento ;
      private string[] BC00373_A1096BoletosSacadoTipoDocumento ;
      private bool[] BC00373_n1096BoletosSacadoTipoDocumento ;
      private string[] BC00373_A1097BoletosMensagemDeErro ;
      private bool[] BC00373_n1097BoletosMensagemDeErro ;
      private int[] BC00373_A1098BoletosTentativasDeRegistro ;
      private bool[] BC00373_n1098BoletosTentativasDeRegistro ;
      private int[] BC00373_A1069CarteiraDeCobrancaId ;
      private bool[] BC00373_n1069CarteiraDeCobrancaId ;
      private int[] BC00373_A261TituloId ;
      private bool[] BC00373_n261TituloId ;
      private int[] BC00372_A1077BoletosId ;
      private bool[] BC00372_n1077BoletosId ;
      private Guid[] BC00372_A1117BoletosResgitroId ;
      private bool[] BC00372_n1117BoletosResgitroId ;
      private DateTime[] BC00372_A1099BoletosCreatedAt ;
      private bool[] BC00372_n1099BoletosCreatedAt ;
      private DateTime[] BC00372_A1100BoletosUpdatedAt ;
      private bool[] BC00372_n1100BoletosUpdatedAt ;
      private string[] BC00372_A1078BoletosNossoNumero ;
      private bool[] BC00372_n1078BoletosNossoNumero ;
      private string[] BC00372_A1079BoletosSeuNumero ;
      private bool[] BC00372_n1079BoletosSeuNumero ;
      private string[] BC00372_A1080BoletosNumero ;
      private bool[] BC00372_n1080BoletosNumero ;
      private string[] BC00372_A1081BoletosLinhaDigitavel ;
      private bool[] BC00372_n1081BoletosLinhaDigitavel ;
      private string[] BC00372_A1082BoletosCodigoDeBarras ;
      private bool[] BC00372_n1082BoletosCodigoDeBarras ;
      private string[] BC00372_A1083BoletosStatus ;
      private bool[] BC00372_n1083BoletosStatus ;
      private DateTime[] BC00372_A1084BoletosDataEmissao ;
      private bool[] BC00372_n1084BoletosDataEmissao ;
      private DateTime[] BC00372_A1085BoletosDataVencimento ;
      private bool[] BC00372_n1085BoletosDataVencimento ;
      private DateTime[] BC00372_A1086BoletosDataRegistro ;
      private bool[] BC00372_n1086BoletosDataRegistro ;
      private DateTime[] BC00372_A1087BoletosDataPagamento ;
      private bool[] BC00372_n1087BoletosDataPagamento ;
      private DateTime[] BC00372_A1088BoletosDataBaixa ;
      private bool[] BC00372_n1088BoletosDataBaixa ;
      private decimal[] BC00372_A1089BoletosValorNominal ;
      private bool[] BC00372_n1089BoletosValorNominal ;
      private decimal[] BC00372_A1090BoletosValorPago ;
      private bool[] BC00372_n1090BoletosValorPago ;
      private decimal[] BC00372_A1091BoletosValorDesconto ;
      private bool[] BC00372_n1091BoletosValorDesconto ;
      private decimal[] BC00372_A1092BoletosValorJuros ;
      private bool[] BC00372_n1092BoletosValorJuros ;
      private decimal[] BC00372_A1093BoletosValorMulta ;
      private bool[] BC00372_n1093BoletosValorMulta ;
      private string[] BC00372_A1094BoletosSacadoNome ;
      private bool[] BC00372_n1094BoletosSacadoNome ;
      private string[] BC00372_A1095BoletosSacadoDocumento ;
      private bool[] BC00372_n1095BoletosSacadoDocumento ;
      private string[] BC00372_A1096BoletosSacadoTipoDocumento ;
      private bool[] BC00372_n1096BoletosSacadoTipoDocumento ;
      private string[] BC00372_A1097BoletosMensagemDeErro ;
      private bool[] BC00372_n1097BoletosMensagemDeErro ;
      private int[] BC00372_A1098BoletosTentativasDeRegistro ;
      private bool[] BC00372_n1098BoletosTentativasDeRegistro ;
      private int[] BC00372_A1069CarteiraDeCobrancaId ;
      private bool[] BC00372_n1069CarteiraDeCobrancaId ;
      private int[] BC00372_A261TituloId ;
      private bool[] BC00372_n261TituloId ;
      private int[] BC003721_A1077BoletosId ;
      private bool[] BC003721_n1077BoletosId ;
      private string[] BC003724_A1071CarteiraDeCobrancaNome ;
      private bool[] BC003724_n1071CarteiraDeCobrancaNome ;
      private string[] BC003724_A1073CarteiraDeCobrancaConvenio ;
      private bool[] BC003724_n1073CarteiraDeCobrancaConvenio ;
      private bool[] BC003724_A1074CarteiraDeCobrancaStatus ;
      private bool[] BC003724_n1074CarteiraDeCobrancaStatus ;
      private decimal[] BC003726_A1112CarteiraDeCobrancaValorRecebido ;
      private decimal[] BC003726_A1111CarteiraDeCobrancaValorTotal ;
      private int[] BC003726_A1113CarteiraDeCobrancaTotalBoletos ;
      private int[] BC003728_A1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private bool[] BC003728_n1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private int[] BC003730_A1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private bool[] BC003730_n1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private int[] BC003732_A1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private bool[] BC003732_n1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private int[] BC003733_A1101BoletosLogId ;
      private int[] BC003738_A1077BoletosId ;
      private bool[] BC003738_n1077BoletosId ;
      private Guid[] BC003738_A1117BoletosResgitroId ;
      private bool[] BC003738_n1117BoletosResgitroId ;
      private DateTime[] BC003738_A1099BoletosCreatedAt ;
      private bool[] BC003738_n1099BoletosCreatedAt ;
      private DateTime[] BC003738_A1100BoletosUpdatedAt ;
      private bool[] BC003738_n1100BoletosUpdatedAt ;
      private string[] BC003738_A1078BoletosNossoNumero ;
      private bool[] BC003738_n1078BoletosNossoNumero ;
      private string[] BC003738_A1079BoletosSeuNumero ;
      private bool[] BC003738_n1079BoletosSeuNumero ;
      private string[] BC003738_A1080BoletosNumero ;
      private bool[] BC003738_n1080BoletosNumero ;
      private string[] BC003738_A1081BoletosLinhaDigitavel ;
      private bool[] BC003738_n1081BoletosLinhaDigitavel ;
      private string[] BC003738_A1082BoletosCodigoDeBarras ;
      private bool[] BC003738_n1082BoletosCodigoDeBarras ;
      private string[] BC003738_A1083BoletosStatus ;
      private bool[] BC003738_n1083BoletosStatus ;
      private DateTime[] BC003738_A1084BoletosDataEmissao ;
      private bool[] BC003738_n1084BoletosDataEmissao ;
      private DateTime[] BC003738_A1085BoletosDataVencimento ;
      private bool[] BC003738_n1085BoletosDataVencimento ;
      private DateTime[] BC003738_A1086BoletosDataRegistro ;
      private bool[] BC003738_n1086BoletosDataRegistro ;
      private DateTime[] BC003738_A1087BoletosDataPagamento ;
      private bool[] BC003738_n1087BoletosDataPagamento ;
      private DateTime[] BC003738_A1088BoletosDataBaixa ;
      private bool[] BC003738_n1088BoletosDataBaixa ;
      private decimal[] BC003738_A1089BoletosValorNominal ;
      private bool[] BC003738_n1089BoletosValorNominal ;
      private decimal[] BC003738_A1090BoletosValorPago ;
      private bool[] BC003738_n1090BoletosValorPago ;
      private decimal[] BC003738_A1091BoletosValorDesconto ;
      private bool[] BC003738_n1091BoletosValorDesconto ;
      private decimal[] BC003738_A1092BoletosValorJuros ;
      private bool[] BC003738_n1092BoletosValorJuros ;
      private decimal[] BC003738_A1093BoletosValorMulta ;
      private bool[] BC003738_n1093BoletosValorMulta ;
      private string[] BC003738_A1094BoletosSacadoNome ;
      private bool[] BC003738_n1094BoletosSacadoNome ;
      private string[] BC003738_A1095BoletosSacadoDocumento ;
      private bool[] BC003738_n1095BoletosSacadoDocumento ;
      private string[] BC003738_A1096BoletosSacadoTipoDocumento ;
      private bool[] BC003738_n1096BoletosSacadoTipoDocumento ;
      private string[] BC003738_A1097BoletosMensagemDeErro ;
      private bool[] BC003738_n1097BoletosMensagemDeErro ;
      private int[] BC003738_A1098BoletosTentativasDeRegistro ;
      private bool[] BC003738_n1098BoletosTentativasDeRegistro ;
      private string[] BC003738_A1071CarteiraDeCobrancaNome ;
      private bool[] BC003738_n1071CarteiraDeCobrancaNome ;
      private string[] BC003738_A1073CarteiraDeCobrancaConvenio ;
      private bool[] BC003738_n1073CarteiraDeCobrancaConvenio ;
      private bool[] BC003738_A1074CarteiraDeCobrancaStatus ;
      private bool[] BC003738_n1074CarteiraDeCobrancaStatus ;
      private int[] BC003738_A1069CarteiraDeCobrancaId ;
      private bool[] BC003738_n1069CarteiraDeCobrancaId ;
      private int[] BC003738_A261TituloId ;
      private bool[] BC003738_n261TituloId ;
      private decimal[] BC003738_A1112CarteiraDeCobrancaValorRecebido ;
      private decimal[] BC003738_A1111CarteiraDeCobrancaValorTotal ;
      private int[] BC003738_A1113CarteiraDeCobrancaTotalBoletos ;
      private int[] BC003738_A1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private bool[] BC003738_n1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private int[] BC003738_A1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private bool[] BC003738_n1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private int[] BC003738_A1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private bool[] BC003738_n1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private SdtBoleto bcBoleto ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class boleto_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new UpdateCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00372;
          prmBC00372 = new Object[] {
          new ParDef("BoletosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00373;
          prmBC00373 = new Object[] {
          new ParDef("BoletosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00374;
          prmBC00374 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00375;
          prmBC00375 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00377;
          prmBC00377 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00379;
          prmBC00379 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC003711;
          prmBC003711 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC003713;
          prmBC003713 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC003718;
          prmBC003718 = new Object[] {
          new ParDef("BoletosId",GXType.Int32,9,0){Nullable=true}
          };
          string cmdBufferBC003718;
          cmdBufferBC003718=" SELECT TM1.BoletosId, TM1.BoletosResgitroId, TM1.BoletosCreatedAt, TM1.BoletosUpdatedAt, TM1.BoletosNossoNumero, TM1.BoletosSeuNumero, TM1.BoletosNumero, TM1.BoletosLinhaDigitavel, TM1.BoletosCodigoDeBarras, TM1.BoletosStatus, TM1.BoletosDataEmissao, TM1.BoletosDataVencimento, TM1.BoletosDataRegistro, TM1.BoletosDataPagamento, TM1.BoletosDataBaixa, TM1.BoletosValorNominal, TM1.BoletosValorPago, TM1.BoletosValorDesconto, TM1.BoletosValorJuros, TM1.BoletosValorMulta, TM1.BoletosSacadoNome, TM1.BoletosSacadoDocumento, TM1.BoletosSacadoTipoDocumento, TM1.BoletosMensagemDeErro, TM1.BoletosTentativasDeRegistro, T2.CarteiraDeCobrancaNome, T2.CarteiraDeCobrancaConvenio, T2.CarteiraDeCobrancaStatus, TM1.CarteiraDeCobrancaId, TM1.TituloId, COALESCE( T3.CarteiraDeCobrancaValorRecebido, 0) AS CarteiraDeCobrancaValorRecebido, COALESCE( T3.CarteiraDeCobrancaValorTotal, 0) AS CarteiraDeCobrancaValorTotal, COALESCE( T3.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletos, COALESCE( T4.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosRegistrados, COALESCE( T5.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosExpirados, COALESCE( T6.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosCancelados FROM (((((Boleto TM1 LEFT JOIN CarteiraDeCobranca T2 ON T2.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId) LEFT JOIN LATERAL (SELECT SUM(TM1.BoletosValorPago) AS CarteiraDeCobrancaValorRecebido, TM1.CarteiraDeCobrancaId, SUM(TM1.BoletosValorNominal) AS CarteiraDeCobrancaValorTotal, COUNT(*) AS CarteiraDeCobrancaTotalBoletos FROM Boleto TM1 WHERE TM1.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId GROUP BY TM1.CarteiraDeCobrancaId ) T3 ON T3.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, "
          + " TM1.CarteiraDeCobrancaId FROM Boleto TM1 WHERE (TM1.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId) AND (TM1.BoletosStatus = ( 'REGISTRADO')) GROUP BY TM1.CarteiraDeCobrancaId ) T4 ON T4.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, TM1.CarteiraDeCobrancaId FROM Boleto TM1 WHERE (TM1.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId) AND (TM1.BoletosStatus = ( 'VENCIDO')) GROUP BY TM1.CarteiraDeCobrancaId ) T5 ON T5.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, TM1.CarteiraDeCobrancaId FROM Boleto TM1 WHERE (TM1.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId) AND (TM1.BoletosStatus = ( 'BAIXADO')) GROUP BY TM1.CarteiraDeCobrancaId ) T6 ON T6.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId) WHERE TM1.BoletosId = :BoletosId ORDER BY TM1.BoletosId" ;
          Object[] prmBC003719;
          prmBC003719 = new Object[] {
          new ParDef("BoletosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC003720;
          prmBC003720 = new Object[] {
          new ParDef("BoletosResgitroId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("BoletosCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("BoletosUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("BoletosNossoNumero",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("BoletosSeuNumero",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("BoletosNumero",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("BoletosLinhaDigitavel",GXType.VarChar,54,0){Nullable=true} ,
          new ParDef("BoletosCodigoDeBarras",GXType.VarChar,44,0){Nullable=true} ,
          new ParDef("BoletosStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("BoletosDataEmissao",GXType.Date,8,0){Nullable=true} ,
          new ParDef("BoletosDataVencimento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("BoletosDataRegistro",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("BoletosDataPagamento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("BoletosDataBaixa",GXType.Date,8,0){Nullable=true} ,
          new ParDef("BoletosValorNominal",GXType.Number,18,2){Nullable=true} ,
          new ParDef("BoletosValorPago",GXType.Number,18,2){Nullable=true} ,
          new ParDef("BoletosValorDesconto",GXType.Number,18,2){Nullable=true} ,
          new ParDef("BoletosValorJuros",GXType.Number,18,2){Nullable=true} ,
          new ParDef("BoletosValorMulta",GXType.Number,18,2){Nullable=true} ,
          new ParDef("BoletosSacadoNome",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("BoletosSacadoDocumento",GXType.VarChar,20,0){Nullable=true} ,
          new ParDef("BoletosSacadoTipoDocumento",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("BoletosMensagemDeErro",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("BoletosTentativasDeRegistro",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC003721;
          prmBC003721 = new Object[] {
          };
          Object[] prmBC003722;
          prmBC003722 = new Object[] {
          new ParDef("BoletosResgitroId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("BoletosCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("BoletosUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("BoletosNossoNumero",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("BoletosSeuNumero",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("BoletosNumero",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("BoletosLinhaDigitavel",GXType.VarChar,54,0){Nullable=true} ,
          new ParDef("BoletosCodigoDeBarras",GXType.VarChar,44,0){Nullable=true} ,
          new ParDef("BoletosStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("BoletosDataEmissao",GXType.Date,8,0){Nullable=true} ,
          new ParDef("BoletosDataVencimento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("BoletosDataRegistro",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("BoletosDataPagamento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("BoletosDataBaixa",GXType.Date,8,0){Nullable=true} ,
          new ParDef("BoletosValorNominal",GXType.Number,18,2){Nullable=true} ,
          new ParDef("BoletosValorPago",GXType.Number,18,2){Nullable=true} ,
          new ParDef("BoletosValorDesconto",GXType.Number,18,2){Nullable=true} ,
          new ParDef("BoletosValorJuros",GXType.Number,18,2){Nullable=true} ,
          new ParDef("BoletosValorMulta",GXType.Number,18,2){Nullable=true} ,
          new ParDef("BoletosSacadoNome",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("BoletosSacadoDocumento",GXType.VarChar,20,0){Nullable=true} ,
          new ParDef("BoletosSacadoTipoDocumento",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("BoletosMensagemDeErro",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("BoletosTentativasDeRegistro",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("BoletosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC003723;
          prmBC003723 = new Object[] {
          new ParDef("BoletosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC003724;
          prmBC003724 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC003726;
          prmBC003726 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC003728;
          prmBC003728 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC003730;
          prmBC003730 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC003732;
          prmBC003732 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC003733;
          prmBC003733 = new Object[] {
          new ParDef("BoletosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC003738;
          prmBC003738 = new Object[] {
          new ParDef("BoletosId",GXType.Int32,9,0){Nullable=true}
          };
          string cmdBufferBC003738;
          cmdBufferBC003738=" SELECT TM1.BoletosId, TM1.BoletosResgitroId, TM1.BoletosCreatedAt, TM1.BoletosUpdatedAt, TM1.BoletosNossoNumero, TM1.BoletosSeuNumero, TM1.BoletosNumero, TM1.BoletosLinhaDigitavel, TM1.BoletosCodigoDeBarras, TM1.BoletosStatus, TM1.BoletosDataEmissao, TM1.BoletosDataVencimento, TM1.BoletosDataRegistro, TM1.BoletosDataPagamento, TM1.BoletosDataBaixa, TM1.BoletosValorNominal, TM1.BoletosValorPago, TM1.BoletosValorDesconto, TM1.BoletosValorJuros, TM1.BoletosValorMulta, TM1.BoletosSacadoNome, TM1.BoletosSacadoDocumento, TM1.BoletosSacadoTipoDocumento, TM1.BoletosMensagemDeErro, TM1.BoletosTentativasDeRegistro, T2.CarteiraDeCobrancaNome, T2.CarteiraDeCobrancaConvenio, T2.CarteiraDeCobrancaStatus, TM1.CarteiraDeCobrancaId, TM1.TituloId, COALESCE( T3.CarteiraDeCobrancaValorRecebido, 0) AS CarteiraDeCobrancaValorRecebido, COALESCE( T3.CarteiraDeCobrancaValorTotal, 0) AS CarteiraDeCobrancaValorTotal, COALESCE( T3.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletos, COALESCE( T4.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosRegistrados, COALESCE( T5.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosExpirados, COALESCE( T6.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosCancelados FROM (((((Boleto TM1 LEFT JOIN CarteiraDeCobranca T2 ON T2.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId) LEFT JOIN LATERAL (SELECT SUM(TM1.BoletosValorPago) AS CarteiraDeCobrancaValorRecebido, TM1.CarteiraDeCobrancaId, SUM(TM1.BoletosValorNominal) AS CarteiraDeCobrancaValorTotal, COUNT(*) AS CarteiraDeCobrancaTotalBoletos FROM Boleto TM1 WHERE TM1.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId GROUP BY TM1.CarteiraDeCobrancaId ) T3 ON T3.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, "
          + " TM1.CarteiraDeCobrancaId FROM Boleto TM1 WHERE (TM1.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId) AND (TM1.BoletosStatus = ( 'REGISTRADO')) GROUP BY TM1.CarteiraDeCobrancaId ) T4 ON T4.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, TM1.CarteiraDeCobrancaId FROM Boleto TM1 WHERE (TM1.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId) AND (TM1.BoletosStatus = ( 'VENCIDO')) GROUP BY TM1.CarteiraDeCobrancaId ) T5 ON T5.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, TM1.CarteiraDeCobrancaId FROM Boleto TM1 WHERE (TM1.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId) AND (TM1.BoletosStatus = ( 'BAIXADO')) GROUP BY TM1.CarteiraDeCobrancaId ) T6 ON T6.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId) WHERE TM1.BoletosId = :BoletosId ORDER BY TM1.BoletosId" ;
          def= new CursorDef[] {
              new CursorDef("BC00372", "SELECT BoletosId, BoletosResgitroId, BoletosCreatedAt, BoletosUpdatedAt, BoletosNossoNumero, BoletosSeuNumero, BoletosNumero, BoletosLinhaDigitavel, BoletosCodigoDeBarras, BoletosStatus, BoletosDataEmissao, BoletosDataVencimento, BoletosDataRegistro, BoletosDataPagamento, BoletosDataBaixa, BoletosValorNominal, BoletosValorPago, BoletosValorDesconto, BoletosValorJuros, BoletosValorMulta, BoletosSacadoNome, BoletosSacadoDocumento, BoletosSacadoTipoDocumento, BoletosMensagemDeErro, BoletosTentativasDeRegistro, CarteiraDeCobrancaId, TituloId FROM Boleto WHERE BoletosId = :BoletosId  FOR UPDATE OF Boleto",true, GxErrorMask.GX_NOMASK, false, this,prmBC00372,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00373", "SELECT BoletosId, BoletosResgitroId, BoletosCreatedAt, BoletosUpdatedAt, BoletosNossoNumero, BoletosSeuNumero, BoletosNumero, BoletosLinhaDigitavel, BoletosCodigoDeBarras, BoletosStatus, BoletosDataEmissao, BoletosDataVencimento, BoletosDataRegistro, BoletosDataPagamento, BoletosDataBaixa, BoletosValorNominal, BoletosValorPago, BoletosValorDesconto, BoletosValorJuros, BoletosValorMulta, BoletosSacadoNome, BoletosSacadoDocumento, BoletosSacadoTipoDocumento, BoletosMensagemDeErro, BoletosTentativasDeRegistro, CarteiraDeCobrancaId, TituloId FROM Boleto WHERE BoletosId = :BoletosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00373,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00374", "SELECT CarteiraDeCobrancaNome, CarteiraDeCobrancaConvenio, CarteiraDeCobrancaStatus FROM CarteiraDeCobranca WHERE CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00374,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00375", "SELECT TituloId FROM Titulo WHERE TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00375,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00377", "SELECT COALESCE( T1.CarteiraDeCobrancaValorRecebido, 0) AS CarteiraDeCobrancaValorRecebido, COALESCE( T1.CarteiraDeCobrancaValorTotal, 0) AS CarteiraDeCobrancaValorTotal, COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletos FROM (SELECT SUM(BoletosValorPago) AS CarteiraDeCobrancaValorRecebido, CarteiraDeCobrancaId, SUM(BoletosValorNominal) AS CarteiraDeCobrancaValorTotal, COUNT(*) AS CarteiraDeCobrancaTotalBoletos FROM Boleto GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00377,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00379", "SELECT COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosRegistrados FROM (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, CarteiraDeCobrancaId FROM Boleto WHERE BoletosStatus = ( 'REGISTRADO') GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00379,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC003711", "SELECT COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosExpirados FROM (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, CarteiraDeCobrancaId FROM Boleto WHERE BoletosStatus = ( 'VENCIDO') GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC003711,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC003713", "SELECT COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosCancelados FROM (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, CarteiraDeCobrancaId FROM Boleto WHERE BoletosStatus = ( 'BAIXADO') GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC003713,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC003718", cmdBufferBC003718,true, GxErrorMask.GX_NOMASK, false, this,prmBC003718,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC003719", "SELECT BoletosId FROM Boleto WHERE BoletosId = :BoletosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC003719,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC003720", "SAVEPOINT gxupdate;INSERT INTO Boleto(BoletosResgitroId, BoletosCreatedAt, BoletosUpdatedAt, BoletosNossoNumero, BoletosSeuNumero, BoletosNumero, BoletosLinhaDigitavel, BoletosCodigoDeBarras, BoletosStatus, BoletosDataEmissao, BoletosDataVencimento, BoletosDataRegistro, BoletosDataPagamento, BoletosDataBaixa, BoletosValorNominal, BoletosValorPago, BoletosValorDesconto, BoletosValorJuros, BoletosValorMulta, BoletosSacadoNome, BoletosSacadoDocumento, BoletosSacadoTipoDocumento, BoletosMensagemDeErro, BoletosTentativasDeRegistro, CarteiraDeCobrancaId, TituloId) VALUES(:BoletosResgitroId, :BoletosCreatedAt, :BoletosUpdatedAt, :BoletosNossoNumero, :BoletosSeuNumero, :BoletosNumero, :BoletosLinhaDigitavel, :BoletosCodigoDeBarras, :BoletosStatus, :BoletosDataEmissao, :BoletosDataVencimento, :BoletosDataRegistro, :BoletosDataPagamento, :BoletosDataBaixa, :BoletosValorNominal, :BoletosValorPago, :BoletosValorDesconto, :BoletosValorJuros, :BoletosValorMulta, :BoletosSacadoNome, :BoletosSacadoDocumento, :BoletosSacadoTipoDocumento, :BoletosMensagemDeErro, :BoletosTentativasDeRegistro, :CarteiraDeCobrancaId, :TituloId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC003720)
             ,new CursorDef("BC003721", "SELECT currval('BoletosId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC003721,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC003722", "SAVEPOINT gxupdate;UPDATE Boleto SET BoletosResgitroId=:BoletosResgitroId, BoletosCreatedAt=:BoletosCreatedAt, BoletosUpdatedAt=:BoletosUpdatedAt, BoletosNossoNumero=:BoletosNossoNumero, BoletosSeuNumero=:BoletosSeuNumero, BoletosNumero=:BoletosNumero, BoletosLinhaDigitavel=:BoletosLinhaDigitavel, BoletosCodigoDeBarras=:BoletosCodigoDeBarras, BoletosStatus=:BoletosStatus, BoletosDataEmissao=:BoletosDataEmissao, BoletosDataVencimento=:BoletosDataVencimento, BoletosDataRegistro=:BoletosDataRegistro, BoletosDataPagamento=:BoletosDataPagamento, BoletosDataBaixa=:BoletosDataBaixa, BoletosValorNominal=:BoletosValorNominal, BoletosValorPago=:BoletosValorPago, BoletosValorDesconto=:BoletosValorDesconto, BoletosValorJuros=:BoletosValorJuros, BoletosValorMulta=:BoletosValorMulta, BoletosSacadoNome=:BoletosSacadoNome, BoletosSacadoDocumento=:BoletosSacadoDocumento, BoletosSacadoTipoDocumento=:BoletosSacadoTipoDocumento, BoletosMensagemDeErro=:BoletosMensagemDeErro, BoletosTentativasDeRegistro=:BoletosTentativasDeRegistro, CarteiraDeCobrancaId=:CarteiraDeCobrancaId, TituloId=:TituloId  WHERE BoletosId = :BoletosId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC003722)
             ,new CursorDef("BC003723", "SAVEPOINT gxupdate;DELETE FROM Boleto  WHERE BoletosId = :BoletosId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC003723)
             ,new CursorDef("BC003724", "SELECT CarteiraDeCobrancaNome, CarteiraDeCobrancaConvenio, CarteiraDeCobrancaStatus FROM CarteiraDeCobranca WHERE CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC003724,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC003726", "SELECT COALESCE( T1.CarteiraDeCobrancaValorRecebido, 0) AS CarteiraDeCobrancaValorRecebido, COALESCE( T1.CarteiraDeCobrancaValorTotal, 0) AS CarteiraDeCobrancaValorTotal, COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletos FROM (SELECT SUM(BoletosValorPago) AS CarteiraDeCobrancaValorRecebido, CarteiraDeCobrancaId, SUM(BoletosValorNominal) AS CarteiraDeCobrancaValorTotal, COUNT(*) AS CarteiraDeCobrancaTotalBoletos FROM Boleto GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC003726,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC003728", "SELECT COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosRegistrados FROM (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, CarteiraDeCobrancaId FROM Boleto WHERE BoletosStatus = ( 'REGISTRADO') GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC003728,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC003730", "SELECT COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosExpirados FROM (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, CarteiraDeCobrancaId FROM Boleto WHERE BoletosStatus = ( 'VENCIDO') GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC003730,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC003732", "SELECT COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosCancelados FROM (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, CarteiraDeCobrancaId FROM Boleto WHERE BoletosStatus = ( 'BAIXADO') GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC003732,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC003733", "SELECT BoletosLogId FROM BoletosLog WHERE BoletosId = :BoletosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC003733,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC003738", cmdBufferBC003738,true, GxErrorMask.GX_NOMASK, false, this,prmBC003738,100, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[19])[0] = rslt.getGXDate(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[21])[0] = rslt.getGXDate(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((DateTime[]) buf[25])[0] = rslt.getGXDate(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((DateTime[]) buf[27])[0] = rslt.getGXDate(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((decimal[]) buf[29])[0] = rslt.getDecimal(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((decimal[]) buf[33])[0] = rslt.getDecimal(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((decimal[]) buf[35])[0] = rslt.getDecimal(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((decimal[]) buf[37])[0] = rslt.getDecimal(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((string[]) buf[41])[0] = rslt.getVarchar(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((string[]) buf[43])[0] = rslt.getVarchar(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getLongVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((int[]) buf[47])[0] = rslt.getInt(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((int[]) buf[49])[0] = rslt.getInt(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((int[]) buf[51])[0] = rslt.getInt(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[19])[0] = rslt.getGXDate(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[21])[0] = rslt.getGXDate(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((DateTime[]) buf[25])[0] = rslt.getGXDate(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((DateTime[]) buf[27])[0] = rslt.getGXDate(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((decimal[]) buf[29])[0] = rslt.getDecimal(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((decimal[]) buf[33])[0] = rslt.getDecimal(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((decimal[]) buf[35])[0] = rslt.getDecimal(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((decimal[]) buf[37])[0] = rslt.getDecimal(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((string[]) buf[41])[0] = rslt.getVarchar(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((string[]) buf[43])[0] = rslt.getVarchar(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getLongVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((int[]) buf[47])[0] = rslt.getInt(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((int[]) buf[49])[0] = rslt.getInt(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((int[]) buf[51])[0] = rslt.getInt(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[19])[0] = rslt.getGXDate(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[21])[0] = rslt.getGXDate(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((DateTime[]) buf[25])[0] = rslt.getGXDate(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((DateTime[]) buf[27])[0] = rslt.getGXDate(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((decimal[]) buf[29])[0] = rslt.getDecimal(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((decimal[]) buf[33])[0] = rslt.getDecimal(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((decimal[]) buf[35])[0] = rslt.getDecimal(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((decimal[]) buf[37])[0] = rslt.getDecimal(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((string[]) buf[41])[0] = rslt.getVarchar(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((string[]) buf[43])[0] = rslt.getVarchar(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getLongVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((int[]) buf[47])[0] = rslt.getInt(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((string[]) buf[51])[0] = rslt.getVarchar(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((bool[]) buf[53])[0] = rslt.getBool(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((int[]) buf[55])[0] = rslt.getInt(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((int[]) buf[57])[0] = rslt.getInt(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((decimal[]) buf[59])[0] = rslt.getDecimal(31);
                ((decimal[]) buf[60])[0] = rslt.getDecimal(32);
                ((int[]) buf[61])[0] = rslt.getInt(33);
                ((int[]) buf[62])[0] = rslt.getInt(34);
                ((bool[]) buf[63])[0] = rslt.wasNull(34);
                ((int[]) buf[64])[0] = rslt.getInt(35);
                ((bool[]) buf[65])[0] = rslt.wasNull(35);
                ((int[]) buf[66])[0] = rslt.getInt(36);
                ((bool[]) buf[67])[0] = rslt.wasNull(36);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                return;
             case 15 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 16 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 17 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 18 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 19 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 20 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[19])[0] = rslt.getGXDate(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[21])[0] = rslt.getGXDate(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((DateTime[]) buf[25])[0] = rslt.getGXDate(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((DateTime[]) buf[27])[0] = rslt.getGXDate(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((decimal[]) buf[29])[0] = rslt.getDecimal(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((decimal[]) buf[33])[0] = rslt.getDecimal(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((decimal[]) buf[35])[0] = rslt.getDecimal(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((decimal[]) buf[37])[0] = rslt.getDecimal(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((string[]) buf[41])[0] = rslt.getVarchar(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((string[]) buf[43])[0] = rslt.getVarchar(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getLongVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((int[]) buf[47])[0] = rslt.getInt(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((string[]) buf[51])[0] = rslt.getVarchar(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((bool[]) buf[53])[0] = rslt.getBool(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((int[]) buf[55])[0] = rslt.getInt(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((int[]) buf[57])[0] = rslt.getInt(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((decimal[]) buf[59])[0] = rslt.getDecimal(31);
                ((decimal[]) buf[60])[0] = rslt.getDecimal(32);
                ((int[]) buf[61])[0] = rslt.getInt(33);
                ((int[]) buf[62])[0] = rslt.getInt(34);
                ((bool[]) buf[63])[0] = rslt.wasNull(34);
                ((int[]) buf[64])[0] = rslt.getInt(35);
                ((bool[]) buf[65])[0] = rslt.wasNull(35);
                ((int[]) buf[66])[0] = rslt.getInt(36);
                ((bool[]) buf[67])[0] = rslt.wasNull(36);
                return;
       }
    }

 }

}
