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
   public class proposta_bc : GxSilentTrn, IGxSilentTrn
   {
      public proposta_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public proposta_bc( IGxContext context )
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
         ReadRow1A49( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1A49( ) ;
         standaloneModal( ) ;
         AddRow1A49( ) ;
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
            E111A2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z323PropostaId = A323PropostaId;
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

      protected void CONFIRM_1A0( )
      {
         BeforeValidate1A49( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1A49( ) ;
            }
            else
            {
               CheckExtendedTable1A49( ) ;
               if ( AnyError == 0 )
               {
                  ZM1A49( 33) ;
                  ZM1A49( 34) ;
                  ZM1A49( 35) ;
                  ZM1A49( 36) ;
                  ZM1A49( 37) ;
                  ZM1A49( 38) ;
                  ZM1A49( 39) ;
                  ZM1A49( 40) ;
                  ZM1A49( 41) ;
                  ZM1A49( 42) ;
                  ZM1A49( 43) ;
                  ZM1A49( 44) ;
                  ZM1A49( 45) ;
                  ZM1A49( 46) ;
                  ZM1A49( 47) ;
                  ZM1A49( 48) ;
                  ZM1A49( 49) ;
                  ZM1A49( 50) ;
                  ZM1A49( 51) ;
                  ZM1A49( 52) ;
                  ZM1A49( 53) ;
               }
               CloseExtendedTableCursors1A49( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E121A2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV36Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV37GXV1 = 1;
            while ( AV37GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV37GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "PropostaEmpresaClienteId") == 0 )
               {
                  AV35Insert_PropostaEmpresaClienteId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "PropostaPacienteClienteId") == 0 )
               {
                  AV32Insert_PropostaPacienteClienteId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "PropostaResponsavelId") == 0 )
               {
                  AV33Insert_PropostaResponsavelId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "ProcedimentosMedicosId") == 0 )
               {
                  AV24Insert_ProcedimentosMedicosId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "PropostaCratedBy") == 0 )
               {
                  AV11Insert_PropostaCratedBy = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "PropostaClinicaId") == 0 )
               {
                  AV34Insert_PropostaClinicaId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "ContratoId") == 0 )
               {
                  AV12Insert_ContratoId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "ConvenioCategoriaId") == 0 )
               {
                  AV31Insert_ConvenioCategoriaId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV37GXV1 = (int)(AV37GXV1+1);
            }
         }
      }

      protected void E111A2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1A49( short GX_JID )
      {
         if ( ( GX_JID == 32 ) || ( GX_JID == 0 ) )
         {
            Z327PropostaCreatedAt = A327PropostaCreatedAt;
            Z853PropostaProtocolo = A853PropostaProtocolo;
            Z849PropostaTipoProposta = A849PropostaTipoProposta;
            Z324PropostaTitulo = A324PropostaTitulo;
            Z325PropostaDescricao = A325PropostaDescricao;
            Z517PropostaDataCirurgia = A517PropostaDataCirurgia;
            Z326PropostaValor = A326PropostaValor;
            Z855PropostaValorLiquido = A855PropostaValorLiquido;
            Z501PropostaTaxaAdministrativa = A501PropostaTaxaAdministrativa;
            Z507PropostaSLA = A507PropostaSLA;
            Z508PropostaJurosMora = A508PropostaJurosMora;
            Z329PropostaStatus = A329PropostaStatus;
            Z790PropostaComentarioAnalise = A790PropostaComentarioAnalise;
            Z330PropostaQuantidadeAprovadores = A330PropostaQuantidadeAprovadores;
            Z345PropostaReprovacoesPermitidas = A345PropostaReprovacoesPermitidas;
            Z496ConvenioVencimentoAno = A496ConvenioVencimentoAno;
            Z497ConvenioVencimentoMes = A497ConvenioVencimentoMes;
            Z227ContratoId = A227ContratoId;
            Z376ProcedimentosMedicosId = A376ProcedimentosMedicosId;
            Z493ConvenioCategoriaId = A493ConvenioCategoriaId;
            Z328PropostaCratedBy = A328PropostaCratedBy;
            Z504PropostaPacienteClienteId = A504PropostaPacienteClienteId;
            Z553PropostaResponsavelId = A553PropostaResponsavelId;
            Z642PropostaClinicaId = A642PropostaClinicaId;
            Z850PropostaEmpresaClienteId = A850PropostaEmpresaClienteId;
            Z649PropostaMaxReembolsoId_F = A649PropostaMaxReembolsoId_F;
            Z854PropostaQtdItensNota_F = A854PropostaQtdItensNota_F;
            Z589PropostaResponsavelBanco = A589PropostaResponsavelBanco;
            Z733PropostaResponsavelSerasaConsultas_F = A733PropostaResponsavelSerasaConsultas_F;
            Z783PropostaResponsavelSerasaScoreUltimaData_F = A783PropostaResponsavelSerasaScoreUltimaData_F;
            Z786PropostaResponsavelSerasaUltimoValorRecomendado_F = A786PropostaResponsavelSerasaUltimoValorRecomendado_F;
            Z583PropostaPacienteBanco = A583PropostaPacienteBanco;
            Z734PropostaPacienteSerasaConsultas_F = A734PropostaPacienteSerasaConsultas_F;
            Z782PropostaSerasaScoreUltimaData_F = A782PropostaSerasaScoreUltimaData_F;
            Z787PropostaPacienteSerasaUltimoValorRecomendado_F = A787PropostaPacienteSerasaUltimoValorRecomendado_F;
            Z650PropostaValorTaxaClinica_F = A650PropostaValorTaxaClinica_F;
            Z655PropostaQtdDocumentoPendente_F = A655PropostaQtdDocumentoPendente_F;
            Z784PropostaMaiorScore_F = A784PropostaMaiorScore_F;
            Z788PropostaMaiorValorRecomendado = A788PropostaMaiorValorRecomendado;
            Z575PropostaTaxa_F = A575PropostaTaxa_F;
            Z515PropostaDataCreditoCliente_F = A515PropostaDataCreditoCliente_F;
            Z513PropostaValorTaxa_F = A513PropostaValorTaxa_F;
            Z514PropostaValorJurosMora_F = A514PropostaValorJurosMora_F;
            Z509PropostaValorReembolsado_F = A509PropostaValorReembolsado_F;
            Z510PropostaValorReembolsadoJuros_F = A510PropostaValorReembolsadoJuros_F;
            Z511PropostaValorTaxaRecebida_F = A511PropostaValorTaxaRecebida_F;
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z343PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
         }
         if ( ( GX_JID == 33 ) || ( GX_JID == 0 ) )
         {
            Z228ContratoNome = A228ContratoNome;
            Z649PropostaMaxReembolsoId_F = A649PropostaMaxReembolsoId_F;
            Z854PropostaQtdItensNota_F = A854PropostaQtdItensNota_F;
            Z589PropostaResponsavelBanco = A589PropostaResponsavelBanco;
            Z733PropostaResponsavelSerasaConsultas_F = A733PropostaResponsavelSerasaConsultas_F;
            Z783PropostaResponsavelSerasaScoreUltimaData_F = A783PropostaResponsavelSerasaScoreUltimaData_F;
            Z786PropostaResponsavelSerasaUltimoValorRecomendado_F = A786PropostaResponsavelSerasaUltimoValorRecomendado_F;
            Z583PropostaPacienteBanco = A583PropostaPacienteBanco;
            Z734PropostaPacienteSerasaConsultas_F = A734PropostaPacienteSerasaConsultas_F;
            Z782PropostaSerasaScoreUltimaData_F = A782PropostaSerasaScoreUltimaData_F;
            Z787PropostaPacienteSerasaUltimoValorRecomendado_F = A787PropostaPacienteSerasaUltimoValorRecomendado_F;
            Z650PropostaValorTaxaClinica_F = A650PropostaValorTaxaClinica_F;
            Z655PropostaQtdDocumentoPendente_F = A655PropostaQtdDocumentoPendente_F;
            Z784PropostaMaiorScore_F = A784PropostaMaiorScore_F;
            Z788PropostaMaiorValorRecomendado = A788PropostaMaiorValorRecomendado;
            Z575PropostaTaxa_F = A575PropostaTaxa_F;
            Z515PropostaDataCreditoCliente_F = A515PropostaDataCreditoCliente_F;
            Z513PropostaValorTaxa_F = A513PropostaValorTaxa_F;
            Z514PropostaValorJurosMora_F = A514PropostaValorJurosMora_F;
            Z509PropostaValorReembolsado_F = A509PropostaValorReembolsado_F;
            Z510PropostaValorReembolsadoJuros_F = A510PropostaValorReembolsadoJuros_F;
            Z511PropostaValorTaxaRecebida_F = A511PropostaValorTaxaRecebida_F;
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z343PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
         }
         if ( ( GX_JID == 34 ) || ( GX_JID == 0 ) )
         {
            Z649PropostaMaxReembolsoId_F = A649PropostaMaxReembolsoId_F;
            Z854PropostaQtdItensNota_F = A854PropostaQtdItensNota_F;
            Z589PropostaResponsavelBanco = A589PropostaResponsavelBanco;
            Z733PropostaResponsavelSerasaConsultas_F = A733PropostaResponsavelSerasaConsultas_F;
            Z783PropostaResponsavelSerasaScoreUltimaData_F = A783PropostaResponsavelSerasaScoreUltimaData_F;
            Z786PropostaResponsavelSerasaUltimoValorRecomendado_F = A786PropostaResponsavelSerasaUltimoValorRecomendado_F;
            Z583PropostaPacienteBanco = A583PropostaPacienteBanco;
            Z734PropostaPacienteSerasaConsultas_F = A734PropostaPacienteSerasaConsultas_F;
            Z782PropostaSerasaScoreUltimaData_F = A782PropostaSerasaScoreUltimaData_F;
            Z787PropostaPacienteSerasaUltimoValorRecomendado_F = A787PropostaPacienteSerasaUltimoValorRecomendado_F;
            Z650PropostaValorTaxaClinica_F = A650PropostaValorTaxaClinica_F;
            Z655PropostaQtdDocumentoPendente_F = A655PropostaQtdDocumentoPendente_F;
            Z784PropostaMaiorScore_F = A784PropostaMaiorScore_F;
            Z788PropostaMaiorValorRecomendado = A788PropostaMaiorValorRecomendado;
            Z575PropostaTaxa_F = A575PropostaTaxa_F;
            Z515PropostaDataCreditoCliente_F = A515PropostaDataCreditoCliente_F;
            Z513PropostaValorTaxa_F = A513PropostaValorTaxa_F;
            Z514PropostaValorJurosMora_F = A514PropostaValorJurosMora_F;
            Z509PropostaValorReembolsado_F = A509PropostaValorReembolsado_F;
            Z510PropostaValorReembolsadoJuros_F = A510PropostaValorReembolsadoJuros_F;
            Z511PropostaValorTaxaRecebida_F = A511PropostaValorTaxaRecebida_F;
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z343PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
         }
         if ( ( GX_JID == 35 ) || ( GX_JID == 0 ) )
         {
            Z494ConvenioCategoriaDescricao = A494ConvenioCategoriaDescricao;
            Z410ConvenioId = A410ConvenioId;
            Z649PropostaMaxReembolsoId_F = A649PropostaMaxReembolsoId_F;
            Z854PropostaQtdItensNota_F = A854PropostaQtdItensNota_F;
            Z589PropostaResponsavelBanco = A589PropostaResponsavelBanco;
            Z733PropostaResponsavelSerasaConsultas_F = A733PropostaResponsavelSerasaConsultas_F;
            Z783PropostaResponsavelSerasaScoreUltimaData_F = A783PropostaResponsavelSerasaScoreUltimaData_F;
            Z786PropostaResponsavelSerasaUltimoValorRecomendado_F = A786PropostaResponsavelSerasaUltimoValorRecomendado_F;
            Z583PropostaPacienteBanco = A583PropostaPacienteBanco;
            Z734PropostaPacienteSerasaConsultas_F = A734PropostaPacienteSerasaConsultas_F;
            Z782PropostaSerasaScoreUltimaData_F = A782PropostaSerasaScoreUltimaData_F;
            Z787PropostaPacienteSerasaUltimoValorRecomendado_F = A787PropostaPacienteSerasaUltimoValorRecomendado_F;
            Z650PropostaValorTaxaClinica_F = A650PropostaValorTaxaClinica_F;
            Z655PropostaQtdDocumentoPendente_F = A655PropostaQtdDocumentoPendente_F;
            Z784PropostaMaiorScore_F = A784PropostaMaiorScore_F;
            Z788PropostaMaiorValorRecomendado = A788PropostaMaiorValorRecomendado;
            Z575PropostaTaxa_F = A575PropostaTaxa_F;
            Z515PropostaDataCreditoCliente_F = A515PropostaDataCreditoCliente_F;
            Z513PropostaValorTaxa_F = A513PropostaValorTaxa_F;
            Z514PropostaValorJurosMora_F = A514PropostaValorJurosMora_F;
            Z509PropostaValorReembolsado_F = A509PropostaValorReembolsado_F;
            Z510PropostaValorReembolsadoJuros_F = A510PropostaValorReembolsadoJuros_F;
            Z511PropostaValorTaxaRecebida_F = A511PropostaValorTaxaRecebida_F;
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z343PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
         }
         if ( ( GX_JID == 36 ) || ( GX_JID == 0 ) )
         {
            Z512PropostaSecUserName = A512PropostaSecUserName;
            Z649PropostaMaxReembolsoId_F = A649PropostaMaxReembolsoId_F;
            Z854PropostaQtdItensNota_F = A854PropostaQtdItensNota_F;
            Z589PropostaResponsavelBanco = A589PropostaResponsavelBanco;
            Z733PropostaResponsavelSerasaConsultas_F = A733PropostaResponsavelSerasaConsultas_F;
            Z783PropostaResponsavelSerasaScoreUltimaData_F = A783PropostaResponsavelSerasaScoreUltimaData_F;
            Z786PropostaResponsavelSerasaUltimoValorRecomendado_F = A786PropostaResponsavelSerasaUltimoValorRecomendado_F;
            Z583PropostaPacienteBanco = A583PropostaPacienteBanco;
            Z734PropostaPacienteSerasaConsultas_F = A734PropostaPacienteSerasaConsultas_F;
            Z782PropostaSerasaScoreUltimaData_F = A782PropostaSerasaScoreUltimaData_F;
            Z787PropostaPacienteSerasaUltimoValorRecomendado_F = A787PropostaPacienteSerasaUltimoValorRecomendado_F;
            Z650PropostaValorTaxaClinica_F = A650PropostaValorTaxaClinica_F;
            Z655PropostaQtdDocumentoPendente_F = A655PropostaQtdDocumentoPendente_F;
            Z784PropostaMaiorScore_F = A784PropostaMaiorScore_F;
            Z788PropostaMaiorValorRecomendado = A788PropostaMaiorValorRecomendado;
            Z575PropostaTaxa_F = A575PropostaTaxa_F;
            Z515PropostaDataCreditoCliente_F = A515PropostaDataCreditoCliente_F;
            Z513PropostaValorTaxa_F = A513PropostaValorTaxa_F;
            Z514PropostaValorJurosMora_F = A514PropostaValorJurosMora_F;
            Z509PropostaValorReembolsado_F = A509PropostaValorReembolsado_F;
            Z510PropostaValorReembolsadoJuros_F = A510PropostaValorReembolsadoJuros_F;
            Z511PropostaValorTaxaRecebida_F = A511PropostaValorTaxaRecebida_F;
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z343PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
         }
         if ( ( GX_JID == 37 ) || ( GX_JID == 0 ) )
         {
            Z505PropostaPacienteClienteRazaoSocial = A505PropostaPacienteClienteRazaoSocial;
            Z540PropostaPacienteClienteDocumento = A540PropostaPacienteClienteDocumento;
            Z541PropostaPacienteContatoEmail = A541PropostaPacienteContatoEmail;
            Z584PropostaPacienteConta = A584PropostaPacienteConta;
            Z585PropostaPacienteAgencia = A585PropostaPacienteAgencia;
            Z586PropostaPacienteTipoPix = A586PropostaPacienteTipoPix;
            Z587PropostaPacientePIX = A587PropostaPacientePIX;
            Z588PropostaPacienteDepositoTipo = A588PropostaPacienteDepositoTipo;
            Z620PropostaPacienteEnderecoCEP = A620PropostaPacienteEnderecoCEP;
            Z621PropostaPacienteEnderecoLogradouro = A621PropostaPacienteEnderecoLogradouro;
            Z622PropostaPacienteEnderecoNumero = A622PropostaPacienteEnderecoNumero;
            Z623PropostaPacienteEnderecoComplemento = A623PropostaPacienteEnderecoComplemento;
            Z624PropostaPacienteEnderecoBairro = A624PropostaPacienteEnderecoBairro;
            Z625PropostaPacienteMunicipioCodigo = A625PropostaPacienteMunicipioCodigo;
            Z649PropostaMaxReembolsoId_F = A649PropostaMaxReembolsoId_F;
            Z854PropostaQtdItensNota_F = A854PropostaQtdItensNota_F;
            Z589PropostaResponsavelBanco = A589PropostaResponsavelBanco;
            Z733PropostaResponsavelSerasaConsultas_F = A733PropostaResponsavelSerasaConsultas_F;
            Z783PropostaResponsavelSerasaScoreUltimaData_F = A783PropostaResponsavelSerasaScoreUltimaData_F;
            Z786PropostaResponsavelSerasaUltimoValorRecomendado_F = A786PropostaResponsavelSerasaUltimoValorRecomendado_F;
            Z583PropostaPacienteBanco = A583PropostaPacienteBanco;
            Z734PropostaPacienteSerasaConsultas_F = A734PropostaPacienteSerasaConsultas_F;
            Z782PropostaSerasaScoreUltimaData_F = A782PropostaSerasaScoreUltimaData_F;
            Z787PropostaPacienteSerasaUltimoValorRecomendado_F = A787PropostaPacienteSerasaUltimoValorRecomendado_F;
            Z650PropostaValorTaxaClinica_F = A650PropostaValorTaxaClinica_F;
            Z655PropostaQtdDocumentoPendente_F = A655PropostaQtdDocumentoPendente_F;
            Z784PropostaMaiorScore_F = A784PropostaMaiorScore_F;
            Z788PropostaMaiorValorRecomendado = A788PropostaMaiorValorRecomendado;
            Z575PropostaTaxa_F = A575PropostaTaxa_F;
            Z515PropostaDataCreditoCliente_F = A515PropostaDataCreditoCliente_F;
            Z513PropostaValorTaxa_F = A513PropostaValorTaxa_F;
            Z514PropostaValorJurosMora_F = A514PropostaValorJurosMora_F;
            Z509PropostaValorReembolsado_F = A509PropostaValorReembolsado_F;
            Z510PropostaValorReembolsadoJuros_F = A510PropostaValorReembolsadoJuros_F;
            Z511PropostaValorTaxaRecebida_F = A511PropostaValorTaxaRecebida_F;
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z343PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
         }
         if ( ( GX_JID == 38 ) || ( GX_JID == 0 ) )
         {
            Z580PropostaResponsavelDocumento = A580PropostaResponsavelDocumento;
            Z581PropostaResponsavelRazaoSocial = A581PropostaResponsavelRazaoSocial;
            Z582PropostaResponsavelEmail = A582PropostaResponsavelEmail;
            Z590PropostaResponsavelConta = A590PropostaResponsavelConta;
            Z591PropostaResponsavelAgencia = A591PropostaResponsavelAgencia;
            Z592PropostaResponsavelTipoPix = A592PropostaResponsavelTipoPix;
            Z593PropostaResponsavelPIX = A593PropostaResponsavelPIX;
            Z594PropostaResponsavelDepositoTipo = A594PropostaResponsavelDepositoTipo;
            Z649PropostaMaxReembolsoId_F = A649PropostaMaxReembolsoId_F;
            Z854PropostaQtdItensNota_F = A854PropostaQtdItensNota_F;
            Z589PropostaResponsavelBanco = A589PropostaResponsavelBanco;
            Z733PropostaResponsavelSerasaConsultas_F = A733PropostaResponsavelSerasaConsultas_F;
            Z783PropostaResponsavelSerasaScoreUltimaData_F = A783PropostaResponsavelSerasaScoreUltimaData_F;
            Z786PropostaResponsavelSerasaUltimoValorRecomendado_F = A786PropostaResponsavelSerasaUltimoValorRecomendado_F;
            Z583PropostaPacienteBanco = A583PropostaPacienteBanco;
            Z734PropostaPacienteSerasaConsultas_F = A734PropostaPacienteSerasaConsultas_F;
            Z782PropostaSerasaScoreUltimaData_F = A782PropostaSerasaScoreUltimaData_F;
            Z787PropostaPacienteSerasaUltimoValorRecomendado_F = A787PropostaPacienteSerasaUltimoValorRecomendado_F;
            Z650PropostaValorTaxaClinica_F = A650PropostaValorTaxaClinica_F;
            Z655PropostaQtdDocumentoPendente_F = A655PropostaQtdDocumentoPendente_F;
            Z784PropostaMaiorScore_F = A784PropostaMaiorScore_F;
            Z788PropostaMaiorValorRecomendado = A788PropostaMaiorValorRecomendado;
            Z575PropostaTaxa_F = A575PropostaTaxa_F;
            Z515PropostaDataCreditoCliente_F = A515PropostaDataCreditoCliente_F;
            Z513PropostaValorTaxa_F = A513PropostaValorTaxa_F;
            Z514PropostaValorJurosMora_F = A514PropostaValorJurosMora_F;
            Z509PropostaValorReembolsado_F = A509PropostaValorReembolsado_F;
            Z510PropostaValorReembolsadoJuros_F = A510PropostaValorReembolsadoJuros_F;
            Z511PropostaValorTaxaRecebida_F = A511PropostaValorTaxaRecebida_F;
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z343PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
         }
         if ( ( GX_JID == 39 ) || ( GX_JID == 0 ) )
         {
            Z643PropostaClinicaNome = A643PropostaClinicaNome;
            Z644PropostaClinicaNomeFantasia = A644PropostaClinicaNomeFantasia;
            Z652PropostaClinicaDocumento = A652PropostaClinicaDocumento;
            Z653PropostaClinicaEmail = A653PropostaClinicaEmail;
            Z649PropostaMaxReembolsoId_F = A649PropostaMaxReembolsoId_F;
            Z854PropostaQtdItensNota_F = A854PropostaQtdItensNota_F;
            Z589PropostaResponsavelBanco = A589PropostaResponsavelBanco;
            Z733PropostaResponsavelSerasaConsultas_F = A733PropostaResponsavelSerasaConsultas_F;
            Z783PropostaResponsavelSerasaScoreUltimaData_F = A783PropostaResponsavelSerasaScoreUltimaData_F;
            Z786PropostaResponsavelSerasaUltimoValorRecomendado_F = A786PropostaResponsavelSerasaUltimoValorRecomendado_F;
            Z583PropostaPacienteBanco = A583PropostaPacienteBanco;
            Z734PropostaPacienteSerasaConsultas_F = A734PropostaPacienteSerasaConsultas_F;
            Z782PropostaSerasaScoreUltimaData_F = A782PropostaSerasaScoreUltimaData_F;
            Z787PropostaPacienteSerasaUltimoValorRecomendado_F = A787PropostaPacienteSerasaUltimoValorRecomendado_F;
            Z650PropostaValorTaxaClinica_F = A650PropostaValorTaxaClinica_F;
            Z655PropostaQtdDocumentoPendente_F = A655PropostaQtdDocumentoPendente_F;
            Z784PropostaMaiorScore_F = A784PropostaMaiorScore_F;
            Z788PropostaMaiorValorRecomendado = A788PropostaMaiorValorRecomendado;
            Z575PropostaTaxa_F = A575PropostaTaxa_F;
            Z515PropostaDataCreditoCliente_F = A515PropostaDataCreditoCliente_F;
            Z513PropostaValorTaxa_F = A513PropostaValorTaxa_F;
            Z514PropostaValorJurosMora_F = A514PropostaValorJurosMora_F;
            Z509PropostaValorReembolsado_F = A509PropostaValorReembolsado_F;
            Z510PropostaValorReembolsadoJuros_F = A510PropostaValorReembolsadoJuros_F;
            Z511PropostaValorTaxaRecebida_F = A511PropostaValorTaxaRecebida_F;
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z343PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
         }
         if ( ( GX_JID == 40 ) || ( GX_JID == 0 ) )
         {
            Z649PropostaMaxReembolsoId_F = A649PropostaMaxReembolsoId_F;
            Z854PropostaQtdItensNota_F = A854PropostaQtdItensNota_F;
            Z589PropostaResponsavelBanco = A589PropostaResponsavelBanco;
            Z733PropostaResponsavelSerasaConsultas_F = A733PropostaResponsavelSerasaConsultas_F;
            Z783PropostaResponsavelSerasaScoreUltimaData_F = A783PropostaResponsavelSerasaScoreUltimaData_F;
            Z786PropostaResponsavelSerasaUltimoValorRecomendado_F = A786PropostaResponsavelSerasaUltimoValorRecomendado_F;
            Z583PropostaPacienteBanco = A583PropostaPacienteBanco;
            Z734PropostaPacienteSerasaConsultas_F = A734PropostaPacienteSerasaConsultas_F;
            Z782PropostaSerasaScoreUltimaData_F = A782PropostaSerasaScoreUltimaData_F;
            Z787PropostaPacienteSerasaUltimoValorRecomendado_F = A787PropostaPacienteSerasaUltimoValorRecomendado_F;
            Z650PropostaValorTaxaClinica_F = A650PropostaValorTaxaClinica_F;
            Z655PropostaQtdDocumentoPendente_F = A655PropostaQtdDocumentoPendente_F;
            Z784PropostaMaiorScore_F = A784PropostaMaiorScore_F;
            Z788PropostaMaiorValorRecomendado = A788PropostaMaiorValorRecomendado;
            Z575PropostaTaxa_F = A575PropostaTaxa_F;
            Z515PropostaDataCreditoCliente_F = A515PropostaDataCreditoCliente_F;
            Z513PropostaValorTaxa_F = A513PropostaValorTaxa_F;
            Z514PropostaValorJurosMora_F = A514PropostaValorJurosMora_F;
            Z509PropostaValorReembolsado_F = A509PropostaValorReembolsado_F;
            Z510PropostaValorReembolsadoJuros_F = A510PropostaValorReembolsadoJuros_F;
            Z511PropostaValorTaxaRecebida_F = A511PropostaValorTaxaRecebida_F;
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z343PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
         }
         if ( ( GX_JID == 41 ) || ( GX_JID == 0 ) )
         {
            Z649PropostaMaxReembolsoId_F = A649PropostaMaxReembolsoId_F;
            Z854PropostaQtdItensNota_F = A854PropostaQtdItensNota_F;
            Z589PropostaResponsavelBanco = A589PropostaResponsavelBanco;
            Z733PropostaResponsavelSerasaConsultas_F = A733PropostaResponsavelSerasaConsultas_F;
            Z783PropostaResponsavelSerasaScoreUltimaData_F = A783PropostaResponsavelSerasaScoreUltimaData_F;
            Z786PropostaResponsavelSerasaUltimoValorRecomendado_F = A786PropostaResponsavelSerasaUltimoValorRecomendado_F;
            Z583PropostaPacienteBanco = A583PropostaPacienteBanco;
            Z734PropostaPacienteSerasaConsultas_F = A734PropostaPacienteSerasaConsultas_F;
            Z782PropostaSerasaScoreUltimaData_F = A782PropostaSerasaScoreUltimaData_F;
            Z787PropostaPacienteSerasaUltimoValorRecomendado_F = A787PropostaPacienteSerasaUltimoValorRecomendado_F;
            Z650PropostaValorTaxaClinica_F = A650PropostaValorTaxaClinica_F;
            Z655PropostaQtdDocumentoPendente_F = A655PropostaQtdDocumentoPendente_F;
            Z784PropostaMaiorScore_F = A784PropostaMaiorScore_F;
            Z788PropostaMaiorValorRecomendado = A788PropostaMaiorValorRecomendado;
            Z575PropostaTaxa_F = A575PropostaTaxa_F;
            Z515PropostaDataCreditoCliente_F = A515PropostaDataCreditoCliente_F;
            Z513PropostaValorTaxa_F = A513PropostaValorTaxa_F;
            Z514PropostaValorJurosMora_F = A514PropostaValorJurosMora_F;
            Z509PropostaValorReembolsado_F = A509PropostaValorReembolsado_F;
            Z510PropostaValorReembolsadoJuros_F = A510PropostaValorReembolsadoJuros_F;
            Z511PropostaValorTaxaRecebida_F = A511PropostaValorTaxaRecebida_F;
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z343PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
         }
         if ( ( GX_JID == 42 ) || ( GX_JID == 0 ) )
         {
            Z649PropostaMaxReembolsoId_F = A649PropostaMaxReembolsoId_F;
            Z854PropostaQtdItensNota_F = A854PropostaQtdItensNota_F;
            Z589PropostaResponsavelBanco = A589PropostaResponsavelBanco;
            Z733PropostaResponsavelSerasaConsultas_F = A733PropostaResponsavelSerasaConsultas_F;
            Z783PropostaResponsavelSerasaScoreUltimaData_F = A783PropostaResponsavelSerasaScoreUltimaData_F;
            Z786PropostaResponsavelSerasaUltimoValorRecomendado_F = A786PropostaResponsavelSerasaUltimoValorRecomendado_F;
            Z583PropostaPacienteBanco = A583PropostaPacienteBanco;
            Z734PropostaPacienteSerasaConsultas_F = A734PropostaPacienteSerasaConsultas_F;
            Z782PropostaSerasaScoreUltimaData_F = A782PropostaSerasaScoreUltimaData_F;
            Z787PropostaPacienteSerasaUltimoValorRecomendado_F = A787PropostaPacienteSerasaUltimoValorRecomendado_F;
            Z650PropostaValorTaxaClinica_F = A650PropostaValorTaxaClinica_F;
            Z655PropostaQtdDocumentoPendente_F = A655PropostaQtdDocumentoPendente_F;
            Z784PropostaMaiorScore_F = A784PropostaMaiorScore_F;
            Z788PropostaMaiorValorRecomendado = A788PropostaMaiorValorRecomendado;
            Z575PropostaTaxa_F = A575PropostaTaxa_F;
            Z515PropostaDataCreditoCliente_F = A515PropostaDataCreditoCliente_F;
            Z513PropostaValorTaxa_F = A513PropostaValorTaxa_F;
            Z514PropostaValorJurosMora_F = A514PropostaValorJurosMora_F;
            Z509PropostaValorReembolsado_F = A509PropostaValorReembolsado_F;
            Z510PropostaValorReembolsadoJuros_F = A510PropostaValorReembolsadoJuros_F;
            Z511PropostaValorTaxaRecebida_F = A511PropostaValorTaxaRecebida_F;
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z343PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
         }
         if ( ( GX_JID == 43 ) || ( GX_JID == 0 ) )
         {
            Z649PropostaMaxReembolsoId_F = A649PropostaMaxReembolsoId_F;
            Z854PropostaQtdItensNota_F = A854PropostaQtdItensNota_F;
            Z589PropostaResponsavelBanco = A589PropostaResponsavelBanco;
            Z733PropostaResponsavelSerasaConsultas_F = A733PropostaResponsavelSerasaConsultas_F;
            Z783PropostaResponsavelSerasaScoreUltimaData_F = A783PropostaResponsavelSerasaScoreUltimaData_F;
            Z786PropostaResponsavelSerasaUltimoValorRecomendado_F = A786PropostaResponsavelSerasaUltimoValorRecomendado_F;
            Z583PropostaPacienteBanco = A583PropostaPacienteBanco;
            Z734PropostaPacienteSerasaConsultas_F = A734PropostaPacienteSerasaConsultas_F;
            Z782PropostaSerasaScoreUltimaData_F = A782PropostaSerasaScoreUltimaData_F;
            Z787PropostaPacienteSerasaUltimoValorRecomendado_F = A787PropostaPacienteSerasaUltimoValorRecomendado_F;
            Z650PropostaValorTaxaClinica_F = A650PropostaValorTaxaClinica_F;
            Z655PropostaQtdDocumentoPendente_F = A655PropostaQtdDocumentoPendente_F;
            Z784PropostaMaiorScore_F = A784PropostaMaiorScore_F;
            Z788PropostaMaiorValorRecomendado = A788PropostaMaiorValorRecomendado;
            Z575PropostaTaxa_F = A575PropostaTaxa_F;
            Z515PropostaDataCreditoCliente_F = A515PropostaDataCreditoCliente_F;
            Z513PropostaValorTaxa_F = A513PropostaValorTaxa_F;
            Z514PropostaValorJurosMora_F = A514PropostaValorJurosMora_F;
            Z509PropostaValorReembolsado_F = A509PropostaValorReembolsado_F;
            Z510PropostaValorReembolsadoJuros_F = A510PropostaValorReembolsadoJuros_F;
            Z511PropostaValorTaxaRecebida_F = A511PropostaValorTaxaRecebida_F;
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z343PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
         }
         if ( ( GX_JID == 44 ) || ( GX_JID == 0 ) )
         {
            Z649PropostaMaxReembolsoId_F = A649PropostaMaxReembolsoId_F;
            Z854PropostaQtdItensNota_F = A854PropostaQtdItensNota_F;
            Z589PropostaResponsavelBanco = A589PropostaResponsavelBanco;
            Z733PropostaResponsavelSerasaConsultas_F = A733PropostaResponsavelSerasaConsultas_F;
            Z783PropostaResponsavelSerasaScoreUltimaData_F = A783PropostaResponsavelSerasaScoreUltimaData_F;
            Z786PropostaResponsavelSerasaUltimoValorRecomendado_F = A786PropostaResponsavelSerasaUltimoValorRecomendado_F;
            Z583PropostaPacienteBanco = A583PropostaPacienteBanco;
            Z734PropostaPacienteSerasaConsultas_F = A734PropostaPacienteSerasaConsultas_F;
            Z782PropostaSerasaScoreUltimaData_F = A782PropostaSerasaScoreUltimaData_F;
            Z787PropostaPacienteSerasaUltimoValorRecomendado_F = A787PropostaPacienteSerasaUltimoValorRecomendado_F;
            Z650PropostaValorTaxaClinica_F = A650PropostaValorTaxaClinica_F;
            Z655PropostaQtdDocumentoPendente_F = A655PropostaQtdDocumentoPendente_F;
            Z784PropostaMaiorScore_F = A784PropostaMaiorScore_F;
            Z788PropostaMaiorValorRecomendado = A788PropostaMaiorValorRecomendado;
            Z575PropostaTaxa_F = A575PropostaTaxa_F;
            Z515PropostaDataCreditoCliente_F = A515PropostaDataCreditoCliente_F;
            Z513PropostaValorTaxa_F = A513PropostaValorTaxa_F;
            Z514PropostaValorJurosMora_F = A514PropostaValorJurosMora_F;
            Z509PropostaValorReembolsado_F = A509PropostaValorReembolsado_F;
            Z510PropostaValorReembolsadoJuros_F = A510PropostaValorReembolsadoJuros_F;
            Z511PropostaValorTaxaRecebida_F = A511PropostaValorTaxaRecebida_F;
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z343PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
         }
         if ( ( GX_JID == 45 ) || ( GX_JID == 0 ) )
         {
            Z649PropostaMaxReembolsoId_F = A649PropostaMaxReembolsoId_F;
            Z854PropostaQtdItensNota_F = A854PropostaQtdItensNota_F;
            Z589PropostaResponsavelBanco = A589PropostaResponsavelBanco;
            Z733PropostaResponsavelSerasaConsultas_F = A733PropostaResponsavelSerasaConsultas_F;
            Z783PropostaResponsavelSerasaScoreUltimaData_F = A783PropostaResponsavelSerasaScoreUltimaData_F;
            Z786PropostaResponsavelSerasaUltimoValorRecomendado_F = A786PropostaResponsavelSerasaUltimoValorRecomendado_F;
            Z583PropostaPacienteBanco = A583PropostaPacienteBanco;
            Z734PropostaPacienteSerasaConsultas_F = A734PropostaPacienteSerasaConsultas_F;
            Z782PropostaSerasaScoreUltimaData_F = A782PropostaSerasaScoreUltimaData_F;
            Z787PropostaPacienteSerasaUltimoValorRecomendado_F = A787PropostaPacienteSerasaUltimoValorRecomendado_F;
            Z650PropostaValorTaxaClinica_F = A650PropostaValorTaxaClinica_F;
            Z655PropostaQtdDocumentoPendente_F = A655PropostaQtdDocumentoPendente_F;
            Z784PropostaMaiorScore_F = A784PropostaMaiorScore_F;
            Z788PropostaMaiorValorRecomendado = A788PropostaMaiorValorRecomendado;
            Z575PropostaTaxa_F = A575PropostaTaxa_F;
            Z515PropostaDataCreditoCliente_F = A515PropostaDataCreditoCliente_F;
            Z513PropostaValorTaxa_F = A513PropostaValorTaxa_F;
            Z514PropostaValorJurosMora_F = A514PropostaValorJurosMora_F;
            Z509PropostaValorReembolsado_F = A509PropostaValorReembolsado_F;
            Z510PropostaValorReembolsadoJuros_F = A510PropostaValorReembolsadoJuros_F;
            Z511PropostaValorTaxaRecebida_F = A511PropostaValorTaxaRecebida_F;
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z343PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
         }
         if ( ( GX_JID == 46 ) || ( GX_JID == 0 ) )
         {
            Z649PropostaMaxReembolsoId_F = A649PropostaMaxReembolsoId_F;
            Z854PropostaQtdItensNota_F = A854PropostaQtdItensNota_F;
            Z589PropostaResponsavelBanco = A589PropostaResponsavelBanco;
            Z733PropostaResponsavelSerasaConsultas_F = A733PropostaResponsavelSerasaConsultas_F;
            Z783PropostaResponsavelSerasaScoreUltimaData_F = A783PropostaResponsavelSerasaScoreUltimaData_F;
            Z786PropostaResponsavelSerasaUltimoValorRecomendado_F = A786PropostaResponsavelSerasaUltimoValorRecomendado_F;
            Z583PropostaPacienteBanco = A583PropostaPacienteBanco;
            Z734PropostaPacienteSerasaConsultas_F = A734PropostaPacienteSerasaConsultas_F;
            Z782PropostaSerasaScoreUltimaData_F = A782PropostaSerasaScoreUltimaData_F;
            Z787PropostaPacienteSerasaUltimoValorRecomendado_F = A787PropostaPacienteSerasaUltimoValorRecomendado_F;
            Z650PropostaValorTaxaClinica_F = A650PropostaValorTaxaClinica_F;
            Z655PropostaQtdDocumentoPendente_F = A655PropostaQtdDocumentoPendente_F;
            Z784PropostaMaiorScore_F = A784PropostaMaiorScore_F;
            Z788PropostaMaiorValorRecomendado = A788PropostaMaiorValorRecomendado;
            Z575PropostaTaxa_F = A575PropostaTaxa_F;
            Z515PropostaDataCreditoCliente_F = A515PropostaDataCreditoCliente_F;
            Z513PropostaValorTaxa_F = A513PropostaValorTaxa_F;
            Z514PropostaValorJurosMora_F = A514PropostaValorJurosMora_F;
            Z509PropostaValorReembolsado_F = A509PropostaValorReembolsado_F;
            Z510PropostaValorReembolsadoJuros_F = A510PropostaValorReembolsadoJuros_F;
            Z511PropostaValorTaxaRecebida_F = A511PropostaValorTaxaRecebida_F;
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z343PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
         }
         if ( ( GX_JID == 47 ) || ( GX_JID == 0 ) )
         {
            Z649PropostaMaxReembolsoId_F = A649PropostaMaxReembolsoId_F;
            Z854PropostaQtdItensNota_F = A854PropostaQtdItensNota_F;
            Z589PropostaResponsavelBanco = A589PropostaResponsavelBanco;
            Z733PropostaResponsavelSerasaConsultas_F = A733PropostaResponsavelSerasaConsultas_F;
            Z783PropostaResponsavelSerasaScoreUltimaData_F = A783PropostaResponsavelSerasaScoreUltimaData_F;
            Z786PropostaResponsavelSerasaUltimoValorRecomendado_F = A786PropostaResponsavelSerasaUltimoValorRecomendado_F;
            Z583PropostaPacienteBanco = A583PropostaPacienteBanco;
            Z734PropostaPacienteSerasaConsultas_F = A734PropostaPacienteSerasaConsultas_F;
            Z782PropostaSerasaScoreUltimaData_F = A782PropostaSerasaScoreUltimaData_F;
            Z787PropostaPacienteSerasaUltimoValorRecomendado_F = A787PropostaPacienteSerasaUltimoValorRecomendado_F;
            Z650PropostaValorTaxaClinica_F = A650PropostaValorTaxaClinica_F;
            Z655PropostaQtdDocumentoPendente_F = A655PropostaQtdDocumentoPendente_F;
            Z784PropostaMaiorScore_F = A784PropostaMaiorScore_F;
            Z788PropostaMaiorValorRecomendado = A788PropostaMaiorValorRecomendado;
            Z575PropostaTaxa_F = A575PropostaTaxa_F;
            Z515PropostaDataCreditoCliente_F = A515PropostaDataCreditoCliente_F;
            Z513PropostaValorTaxa_F = A513PropostaValorTaxa_F;
            Z514PropostaValorJurosMora_F = A514PropostaValorJurosMora_F;
            Z509PropostaValorReembolsado_F = A509PropostaValorReembolsado_F;
            Z510PropostaValorReembolsadoJuros_F = A510PropostaValorReembolsadoJuros_F;
            Z511PropostaValorTaxaRecebida_F = A511PropostaValorTaxaRecebida_F;
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z343PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
         }
         if ( ( GX_JID == 48 ) || ( GX_JID == 0 ) )
         {
            Z649PropostaMaxReembolsoId_F = A649PropostaMaxReembolsoId_F;
            Z854PropostaQtdItensNota_F = A854PropostaQtdItensNota_F;
            Z589PropostaResponsavelBanco = A589PropostaResponsavelBanco;
            Z733PropostaResponsavelSerasaConsultas_F = A733PropostaResponsavelSerasaConsultas_F;
            Z783PropostaResponsavelSerasaScoreUltimaData_F = A783PropostaResponsavelSerasaScoreUltimaData_F;
            Z786PropostaResponsavelSerasaUltimoValorRecomendado_F = A786PropostaResponsavelSerasaUltimoValorRecomendado_F;
            Z583PropostaPacienteBanco = A583PropostaPacienteBanco;
            Z734PropostaPacienteSerasaConsultas_F = A734PropostaPacienteSerasaConsultas_F;
            Z782PropostaSerasaScoreUltimaData_F = A782PropostaSerasaScoreUltimaData_F;
            Z787PropostaPacienteSerasaUltimoValorRecomendado_F = A787PropostaPacienteSerasaUltimoValorRecomendado_F;
            Z650PropostaValorTaxaClinica_F = A650PropostaValorTaxaClinica_F;
            Z655PropostaQtdDocumentoPendente_F = A655PropostaQtdDocumentoPendente_F;
            Z784PropostaMaiorScore_F = A784PropostaMaiorScore_F;
            Z788PropostaMaiorValorRecomendado = A788PropostaMaiorValorRecomendado;
            Z575PropostaTaxa_F = A575PropostaTaxa_F;
            Z515PropostaDataCreditoCliente_F = A515PropostaDataCreditoCliente_F;
            Z513PropostaValorTaxa_F = A513PropostaValorTaxa_F;
            Z514PropostaValorJurosMora_F = A514PropostaValorJurosMora_F;
            Z509PropostaValorReembolsado_F = A509PropostaValorReembolsado_F;
            Z510PropostaValorReembolsadoJuros_F = A510PropostaValorReembolsadoJuros_F;
            Z511PropostaValorTaxaRecebida_F = A511PropostaValorTaxaRecebida_F;
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z343PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
         }
         if ( ( GX_JID == 49 ) || ( GX_JID == 0 ) )
         {
            Z649PropostaMaxReembolsoId_F = A649PropostaMaxReembolsoId_F;
            Z854PropostaQtdItensNota_F = A854PropostaQtdItensNota_F;
            Z589PropostaResponsavelBanco = A589PropostaResponsavelBanco;
            Z733PropostaResponsavelSerasaConsultas_F = A733PropostaResponsavelSerasaConsultas_F;
            Z783PropostaResponsavelSerasaScoreUltimaData_F = A783PropostaResponsavelSerasaScoreUltimaData_F;
            Z786PropostaResponsavelSerasaUltimoValorRecomendado_F = A786PropostaResponsavelSerasaUltimoValorRecomendado_F;
            Z583PropostaPacienteBanco = A583PropostaPacienteBanco;
            Z734PropostaPacienteSerasaConsultas_F = A734PropostaPacienteSerasaConsultas_F;
            Z782PropostaSerasaScoreUltimaData_F = A782PropostaSerasaScoreUltimaData_F;
            Z787PropostaPacienteSerasaUltimoValorRecomendado_F = A787PropostaPacienteSerasaUltimoValorRecomendado_F;
            Z650PropostaValorTaxaClinica_F = A650PropostaValorTaxaClinica_F;
            Z655PropostaQtdDocumentoPendente_F = A655PropostaQtdDocumentoPendente_F;
            Z784PropostaMaiorScore_F = A784PropostaMaiorScore_F;
            Z788PropostaMaiorValorRecomendado = A788PropostaMaiorValorRecomendado;
            Z575PropostaTaxa_F = A575PropostaTaxa_F;
            Z515PropostaDataCreditoCliente_F = A515PropostaDataCreditoCliente_F;
            Z513PropostaValorTaxa_F = A513PropostaValorTaxa_F;
            Z514PropostaValorJurosMora_F = A514PropostaValorJurosMora_F;
            Z509PropostaValorReembolsado_F = A509PropostaValorReembolsado_F;
            Z510PropostaValorReembolsadoJuros_F = A510PropostaValorReembolsadoJuros_F;
            Z511PropostaValorTaxaRecebida_F = A511PropostaValorTaxaRecebida_F;
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z343PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
         }
         if ( ( GX_JID == 50 ) || ( GX_JID == 0 ) )
         {
            Z649PropostaMaxReembolsoId_F = A649PropostaMaxReembolsoId_F;
            Z854PropostaQtdItensNota_F = A854PropostaQtdItensNota_F;
            Z589PropostaResponsavelBanco = A589PropostaResponsavelBanco;
            Z733PropostaResponsavelSerasaConsultas_F = A733PropostaResponsavelSerasaConsultas_F;
            Z783PropostaResponsavelSerasaScoreUltimaData_F = A783PropostaResponsavelSerasaScoreUltimaData_F;
            Z786PropostaResponsavelSerasaUltimoValorRecomendado_F = A786PropostaResponsavelSerasaUltimoValorRecomendado_F;
            Z583PropostaPacienteBanco = A583PropostaPacienteBanco;
            Z734PropostaPacienteSerasaConsultas_F = A734PropostaPacienteSerasaConsultas_F;
            Z782PropostaSerasaScoreUltimaData_F = A782PropostaSerasaScoreUltimaData_F;
            Z787PropostaPacienteSerasaUltimoValorRecomendado_F = A787PropostaPacienteSerasaUltimoValorRecomendado_F;
            Z650PropostaValorTaxaClinica_F = A650PropostaValorTaxaClinica_F;
            Z655PropostaQtdDocumentoPendente_F = A655PropostaQtdDocumentoPendente_F;
            Z784PropostaMaiorScore_F = A784PropostaMaiorScore_F;
            Z788PropostaMaiorValorRecomendado = A788PropostaMaiorValorRecomendado;
            Z575PropostaTaxa_F = A575PropostaTaxa_F;
            Z515PropostaDataCreditoCliente_F = A515PropostaDataCreditoCliente_F;
            Z513PropostaValorTaxa_F = A513PropostaValorTaxa_F;
            Z514PropostaValorJurosMora_F = A514PropostaValorJurosMora_F;
            Z509PropostaValorReembolsado_F = A509PropostaValorReembolsado_F;
            Z510PropostaValorReembolsadoJuros_F = A510PropostaValorReembolsadoJuros_F;
            Z511PropostaValorTaxaRecebida_F = A511PropostaValorTaxaRecebida_F;
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z343PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
         }
         if ( ( GX_JID == 51 ) || ( GX_JID == 0 ) )
         {
            Z649PropostaMaxReembolsoId_F = A649PropostaMaxReembolsoId_F;
            Z854PropostaQtdItensNota_F = A854PropostaQtdItensNota_F;
            Z589PropostaResponsavelBanco = A589PropostaResponsavelBanco;
            Z733PropostaResponsavelSerasaConsultas_F = A733PropostaResponsavelSerasaConsultas_F;
            Z783PropostaResponsavelSerasaScoreUltimaData_F = A783PropostaResponsavelSerasaScoreUltimaData_F;
            Z786PropostaResponsavelSerasaUltimoValorRecomendado_F = A786PropostaResponsavelSerasaUltimoValorRecomendado_F;
            Z583PropostaPacienteBanco = A583PropostaPacienteBanco;
            Z734PropostaPacienteSerasaConsultas_F = A734PropostaPacienteSerasaConsultas_F;
            Z782PropostaSerasaScoreUltimaData_F = A782PropostaSerasaScoreUltimaData_F;
            Z787PropostaPacienteSerasaUltimoValorRecomendado_F = A787PropostaPacienteSerasaUltimoValorRecomendado_F;
            Z650PropostaValorTaxaClinica_F = A650PropostaValorTaxaClinica_F;
            Z655PropostaQtdDocumentoPendente_F = A655PropostaQtdDocumentoPendente_F;
            Z784PropostaMaiorScore_F = A784PropostaMaiorScore_F;
            Z788PropostaMaiorValorRecomendado = A788PropostaMaiorValorRecomendado;
            Z575PropostaTaxa_F = A575PropostaTaxa_F;
            Z515PropostaDataCreditoCliente_F = A515PropostaDataCreditoCliente_F;
            Z513PropostaValorTaxa_F = A513PropostaValorTaxa_F;
            Z514PropostaValorJurosMora_F = A514PropostaValorJurosMora_F;
            Z509PropostaValorReembolsado_F = A509PropostaValorReembolsado_F;
            Z510PropostaValorReembolsadoJuros_F = A510PropostaValorReembolsadoJuros_F;
            Z511PropostaValorTaxaRecebida_F = A511PropostaValorTaxaRecebida_F;
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z343PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
         }
         if ( ( GX_JID == 52 ) || ( GX_JID == 0 ) )
         {
            Z649PropostaMaxReembolsoId_F = A649PropostaMaxReembolsoId_F;
            Z854PropostaQtdItensNota_F = A854PropostaQtdItensNota_F;
            Z589PropostaResponsavelBanco = A589PropostaResponsavelBanco;
            Z733PropostaResponsavelSerasaConsultas_F = A733PropostaResponsavelSerasaConsultas_F;
            Z783PropostaResponsavelSerasaScoreUltimaData_F = A783PropostaResponsavelSerasaScoreUltimaData_F;
            Z786PropostaResponsavelSerasaUltimoValorRecomendado_F = A786PropostaResponsavelSerasaUltimoValorRecomendado_F;
            Z583PropostaPacienteBanco = A583PropostaPacienteBanco;
            Z734PropostaPacienteSerasaConsultas_F = A734PropostaPacienteSerasaConsultas_F;
            Z782PropostaSerasaScoreUltimaData_F = A782PropostaSerasaScoreUltimaData_F;
            Z787PropostaPacienteSerasaUltimoValorRecomendado_F = A787PropostaPacienteSerasaUltimoValorRecomendado_F;
            Z650PropostaValorTaxaClinica_F = A650PropostaValorTaxaClinica_F;
            Z655PropostaQtdDocumentoPendente_F = A655PropostaQtdDocumentoPendente_F;
            Z784PropostaMaiorScore_F = A784PropostaMaiorScore_F;
            Z788PropostaMaiorValorRecomendado = A788PropostaMaiorValorRecomendado;
            Z575PropostaTaxa_F = A575PropostaTaxa_F;
            Z515PropostaDataCreditoCliente_F = A515PropostaDataCreditoCliente_F;
            Z513PropostaValorTaxa_F = A513PropostaValorTaxa_F;
            Z514PropostaValorJurosMora_F = A514PropostaValorJurosMora_F;
            Z509PropostaValorReembolsado_F = A509PropostaValorReembolsado_F;
            Z510PropostaValorReembolsadoJuros_F = A510PropostaValorReembolsadoJuros_F;
            Z511PropostaValorTaxaRecebida_F = A511PropostaValorTaxaRecebida_F;
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z343PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
         }
         if ( ( GX_JID == 53 ) || ( GX_JID == 0 ) )
         {
            Z649PropostaMaxReembolsoId_F = A649PropostaMaxReembolsoId_F;
            Z854PropostaQtdItensNota_F = A854PropostaQtdItensNota_F;
            Z589PropostaResponsavelBanco = A589PropostaResponsavelBanco;
            Z733PropostaResponsavelSerasaConsultas_F = A733PropostaResponsavelSerasaConsultas_F;
            Z783PropostaResponsavelSerasaScoreUltimaData_F = A783PropostaResponsavelSerasaScoreUltimaData_F;
            Z786PropostaResponsavelSerasaUltimoValorRecomendado_F = A786PropostaResponsavelSerasaUltimoValorRecomendado_F;
            Z583PropostaPacienteBanco = A583PropostaPacienteBanco;
            Z734PropostaPacienteSerasaConsultas_F = A734PropostaPacienteSerasaConsultas_F;
            Z782PropostaSerasaScoreUltimaData_F = A782PropostaSerasaScoreUltimaData_F;
            Z787PropostaPacienteSerasaUltimoValorRecomendado_F = A787PropostaPacienteSerasaUltimoValorRecomendado_F;
            Z650PropostaValorTaxaClinica_F = A650PropostaValorTaxaClinica_F;
            Z655PropostaQtdDocumentoPendente_F = A655PropostaQtdDocumentoPendente_F;
            Z784PropostaMaiorScore_F = A784PropostaMaiorScore_F;
            Z788PropostaMaiorValorRecomendado = A788PropostaMaiorValorRecomendado;
            Z575PropostaTaxa_F = A575PropostaTaxa_F;
            Z515PropostaDataCreditoCliente_F = A515PropostaDataCreditoCliente_F;
            Z513PropostaValorTaxa_F = A513PropostaValorTaxa_F;
            Z514PropostaValorJurosMora_F = A514PropostaValorJurosMora_F;
            Z509PropostaValorReembolsado_F = A509PropostaValorReembolsado_F;
            Z510PropostaValorReembolsadoJuros_F = A510PropostaValorReembolsadoJuros_F;
            Z511PropostaValorTaxaRecebida_F = A511PropostaValorTaxaRecebida_F;
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z343PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
         }
         if ( GX_JID == -32 )
         {
            Z323PropostaId = A323PropostaId;
            Z327PropostaCreatedAt = A327PropostaCreatedAt;
            Z853PropostaProtocolo = A853PropostaProtocolo;
            Z849PropostaTipoProposta = A849PropostaTipoProposta;
            Z324PropostaTitulo = A324PropostaTitulo;
            Z325PropostaDescricao = A325PropostaDescricao;
            Z517PropostaDataCirurgia = A517PropostaDataCirurgia;
            Z326PropostaValor = A326PropostaValor;
            Z855PropostaValorLiquido = A855PropostaValorLiquido;
            Z501PropostaTaxaAdministrativa = A501PropostaTaxaAdministrativa;
            Z507PropostaSLA = A507PropostaSLA;
            Z508PropostaJurosMora = A508PropostaJurosMora;
            Z329PropostaStatus = A329PropostaStatus;
            Z790PropostaComentarioAnalise = A790PropostaComentarioAnalise;
            Z330PropostaQuantidadeAprovadores = A330PropostaQuantidadeAprovadores;
            Z345PropostaReprovacoesPermitidas = A345PropostaReprovacoesPermitidas;
            Z496ConvenioVencimentoAno = A496ConvenioVencimentoAno;
            Z497ConvenioVencimentoMes = A497ConvenioVencimentoMes;
            Z227ContratoId = A227ContratoId;
            Z376ProcedimentosMedicosId = A376ProcedimentosMedicosId;
            Z493ConvenioCategoriaId = A493ConvenioCategoriaId;
            Z328PropostaCratedBy = A328PropostaCratedBy;
            Z504PropostaPacienteClienteId = A504PropostaPacienteClienteId;
            Z553PropostaResponsavelId = A553PropostaResponsavelId;
            Z642PropostaClinicaId = A642PropostaClinicaId;
            Z850PropostaEmpresaClienteId = A850PropostaEmpresaClienteId;
            Z649PropostaMaxReembolsoId_F = A649PropostaMaxReembolsoId_F;
            Z854PropostaQtdItensNota_F = A854PropostaQtdItensNota_F;
            Z655PropostaQtdDocumentoPendente_F = A655PropostaQtdDocumentoPendente_F;
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z505PropostaPacienteClienteRazaoSocial = A505PropostaPacienteClienteRazaoSocial;
            Z540PropostaPacienteClienteDocumento = A540PropostaPacienteClienteDocumento;
            Z541PropostaPacienteContatoEmail = A541PropostaPacienteContatoEmail;
            Z584PropostaPacienteConta = A584PropostaPacienteConta;
            Z585PropostaPacienteAgencia = A585PropostaPacienteAgencia;
            Z586PropostaPacienteTipoPix = A586PropostaPacienteTipoPix;
            Z587PropostaPacientePIX = A587PropostaPacientePIX;
            Z588PropostaPacienteDepositoTipo = A588PropostaPacienteDepositoTipo;
            Z620PropostaPacienteEnderecoCEP = A620PropostaPacienteEnderecoCEP;
            Z621PropostaPacienteEnderecoLogradouro = A621PropostaPacienteEnderecoLogradouro;
            Z622PropostaPacienteEnderecoNumero = A622PropostaPacienteEnderecoNumero;
            Z623PropostaPacienteEnderecoComplemento = A623PropostaPacienteEnderecoComplemento;
            Z624PropostaPacienteEnderecoBairro = A624PropostaPacienteEnderecoBairro;
            Z625PropostaPacienteMunicipioCodigo = A625PropostaPacienteMunicipioCodigo;
            Z733PropostaResponsavelSerasaConsultas_F = A733PropostaResponsavelSerasaConsultas_F;
            Z734PropostaPacienteSerasaConsultas_F = A734PropostaPacienteSerasaConsultas_F;
            Z783PropostaResponsavelSerasaScoreUltimaData_F = A783PropostaResponsavelSerasaScoreUltimaData_F;
            Z782PropostaSerasaScoreUltimaData_F = A782PropostaSerasaScoreUltimaData_F;
            Z786PropostaResponsavelSerasaUltimoValorRecomendado_F = A786PropostaResponsavelSerasaUltimoValorRecomendado_F;
            Z787PropostaPacienteSerasaUltimoValorRecomendado_F = A787PropostaPacienteSerasaUltimoValorRecomendado_F;
            Z580PropostaResponsavelDocumento = A580PropostaResponsavelDocumento;
            Z581PropostaResponsavelRazaoSocial = A581PropostaResponsavelRazaoSocial;
            Z582PropostaResponsavelEmail = A582PropostaResponsavelEmail;
            Z590PropostaResponsavelConta = A590PropostaResponsavelConta;
            Z591PropostaResponsavelAgencia = A591PropostaResponsavelAgencia;
            Z592PropostaResponsavelTipoPix = A592PropostaResponsavelTipoPix;
            Z593PropostaResponsavelPIX = A593PropostaResponsavelPIX;
            Z594PropostaResponsavelDepositoTipo = A594PropostaResponsavelDepositoTipo;
            Z512PropostaSecUserName = A512PropostaSecUserName;
            Z643PropostaClinicaNome = A643PropostaClinicaNome;
            Z644PropostaClinicaNomeFantasia = A644PropostaClinicaNomeFantasia;
            Z652PropostaClinicaDocumento = A652PropostaClinicaDocumento;
            Z653PropostaClinicaEmail = A653PropostaClinicaEmail;
            Z228ContratoNome = A228ContratoNome;
            Z494ConvenioCategoriaDescricao = A494ConvenioCategoriaDescricao;
            Z410ConvenioId = A410ConvenioId;
         }
      }

      protected void standaloneNotModal( )
      {
         AV36Pgmname = "Proposta_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A327PropostaCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n327PropostaCreatedAt = false;
         }
      }

      protected void Load1A49( )
      {
         /* Using cursor BC001A54 */
         pr_default.execute(23, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound49 = 1;
            A327PropostaCreatedAt = BC001A54_A327PropostaCreatedAt[0];
            n327PropostaCreatedAt = BC001A54_n327PropostaCreatedAt[0];
            A853PropostaProtocolo = BC001A54_A853PropostaProtocolo[0];
            n853PropostaProtocolo = BC001A54_n853PropostaProtocolo[0];
            A849PropostaTipoProposta = BC001A54_A849PropostaTipoProposta[0];
            n849PropostaTipoProposta = BC001A54_n849PropostaTipoProposta[0];
            A580PropostaResponsavelDocumento = BC001A54_A580PropostaResponsavelDocumento[0];
            n580PropostaResponsavelDocumento = BC001A54_n580PropostaResponsavelDocumento[0];
            A581PropostaResponsavelRazaoSocial = BC001A54_A581PropostaResponsavelRazaoSocial[0];
            n581PropostaResponsavelRazaoSocial = BC001A54_n581PropostaResponsavelRazaoSocial[0];
            A582PropostaResponsavelEmail = BC001A54_A582PropostaResponsavelEmail[0];
            n582PropostaResponsavelEmail = BC001A54_n582PropostaResponsavelEmail[0];
            A590PropostaResponsavelConta = BC001A54_A590PropostaResponsavelConta[0];
            n590PropostaResponsavelConta = BC001A54_n590PropostaResponsavelConta[0];
            A591PropostaResponsavelAgencia = BC001A54_A591PropostaResponsavelAgencia[0];
            n591PropostaResponsavelAgencia = BC001A54_n591PropostaResponsavelAgencia[0];
            A592PropostaResponsavelTipoPix = BC001A54_A592PropostaResponsavelTipoPix[0];
            n592PropostaResponsavelTipoPix = BC001A54_n592PropostaResponsavelTipoPix[0];
            A593PropostaResponsavelPIX = BC001A54_A593PropostaResponsavelPIX[0];
            n593PropostaResponsavelPIX = BC001A54_n593PropostaResponsavelPIX[0];
            A594PropostaResponsavelDepositoTipo = BC001A54_A594PropostaResponsavelDepositoTipo[0];
            n594PropostaResponsavelDepositoTipo = BC001A54_n594PropostaResponsavelDepositoTipo[0];
            A505PropostaPacienteClienteRazaoSocial = BC001A54_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = BC001A54_n505PropostaPacienteClienteRazaoSocial[0];
            A540PropostaPacienteClienteDocumento = BC001A54_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = BC001A54_n540PropostaPacienteClienteDocumento[0];
            A541PropostaPacienteContatoEmail = BC001A54_A541PropostaPacienteContatoEmail[0];
            n541PropostaPacienteContatoEmail = BC001A54_n541PropostaPacienteContatoEmail[0];
            A584PropostaPacienteConta = BC001A54_A584PropostaPacienteConta[0];
            n584PropostaPacienteConta = BC001A54_n584PropostaPacienteConta[0];
            A585PropostaPacienteAgencia = BC001A54_A585PropostaPacienteAgencia[0];
            n585PropostaPacienteAgencia = BC001A54_n585PropostaPacienteAgencia[0];
            A586PropostaPacienteTipoPix = BC001A54_A586PropostaPacienteTipoPix[0];
            n586PropostaPacienteTipoPix = BC001A54_n586PropostaPacienteTipoPix[0];
            A587PropostaPacientePIX = BC001A54_A587PropostaPacientePIX[0];
            n587PropostaPacientePIX = BC001A54_n587PropostaPacientePIX[0];
            A588PropostaPacienteDepositoTipo = BC001A54_A588PropostaPacienteDepositoTipo[0];
            n588PropostaPacienteDepositoTipo = BC001A54_n588PropostaPacienteDepositoTipo[0];
            A620PropostaPacienteEnderecoCEP = BC001A54_A620PropostaPacienteEnderecoCEP[0];
            n620PropostaPacienteEnderecoCEP = BC001A54_n620PropostaPacienteEnderecoCEP[0];
            A621PropostaPacienteEnderecoLogradouro = BC001A54_A621PropostaPacienteEnderecoLogradouro[0];
            n621PropostaPacienteEnderecoLogradouro = BC001A54_n621PropostaPacienteEnderecoLogradouro[0];
            A622PropostaPacienteEnderecoNumero = BC001A54_A622PropostaPacienteEnderecoNumero[0];
            n622PropostaPacienteEnderecoNumero = BC001A54_n622PropostaPacienteEnderecoNumero[0];
            A623PropostaPacienteEnderecoComplemento = BC001A54_A623PropostaPacienteEnderecoComplemento[0];
            n623PropostaPacienteEnderecoComplemento = BC001A54_n623PropostaPacienteEnderecoComplemento[0];
            A624PropostaPacienteEnderecoBairro = BC001A54_A624PropostaPacienteEnderecoBairro[0];
            n624PropostaPacienteEnderecoBairro = BC001A54_n624PropostaPacienteEnderecoBairro[0];
            A324PropostaTitulo = BC001A54_A324PropostaTitulo[0];
            n324PropostaTitulo = BC001A54_n324PropostaTitulo[0];
            A325PropostaDescricao = BC001A54_A325PropostaDescricao[0];
            n325PropostaDescricao = BC001A54_n325PropostaDescricao[0];
            A517PropostaDataCirurgia = BC001A54_A517PropostaDataCirurgia[0];
            n517PropostaDataCirurgia = BC001A54_n517PropostaDataCirurgia[0];
            A326PropostaValor = BC001A54_A326PropostaValor[0];
            n326PropostaValor = BC001A54_n326PropostaValor[0];
            A855PropostaValorLiquido = BC001A54_A855PropostaValorLiquido[0];
            n855PropostaValorLiquido = BC001A54_n855PropostaValorLiquido[0];
            A501PropostaTaxaAdministrativa = BC001A54_A501PropostaTaxaAdministrativa[0];
            n501PropostaTaxaAdministrativa = BC001A54_n501PropostaTaxaAdministrativa[0];
            A507PropostaSLA = BC001A54_A507PropostaSLA[0];
            n507PropostaSLA = BC001A54_n507PropostaSLA[0];
            A508PropostaJurosMora = BC001A54_A508PropostaJurosMora[0];
            n508PropostaJurosMora = BC001A54_n508PropostaJurosMora[0];
            A643PropostaClinicaNome = BC001A54_A643PropostaClinicaNome[0];
            n643PropostaClinicaNome = BC001A54_n643PropostaClinicaNome[0];
            A644PropostaClinicaNomeFantasia = BC001A54_A644PropostaClinicaNomeFantasia[0];
            n644PropostaClinicaNomeFantasia = BC001A54_n644PropostaClinicaNomeFantasia[0];
            A652PropostaClinicaDocumento = BC001A54_A652PropostaClinicaDocumento[0];
            n652PropostaClinicaDocumento = BC001A54_n652PropostaClinicaDocumento[0];
            A653PropostaClinicaEmail = BC001A54_A653PropostaClinicaEmail[0];
            n653PropostaClinicaEmail = BC001A54_n653PropostaClinicaEmail[0];
            A512PropostaSecUserName = BC001A54_A512PropostaSecUserName[0];
            n512PropostaSecUserName = BC001A54_n512PropostaSecUserName[0];
            A329PropostaStatus = BC001A54_A329PropostaStatus[0];
            n329PropostaStatus = BC001A54_n329PropostaStatus[0];
            A790PropostaComentarioAnalise = BC001A54_A790PropostaComentarioAnalise[0];
            n790PropostaComentarioAnalise = BC001A54_n790PropostaComentarioAnalise[0];
            A330PropostaQuantidadeAprovadores = BC001A54_A330PropostaQuantidadeAprovadores[0];
            n330PropostaQuantidadeAprovadores = BC001A54_n330PropostaQuantidadeAprovadores[0];
            A345PropostaReprovacoesPermitidas = BC001A54_A345PropostaReprovacoesPermitidas[0];
            n345PropostaReprovacoesPermitidas = BC001A54_n345PropostaReprovacoesPermitidas[0];
            A228ContratoNome = BC001A54_A228ContratoNome[0];
            n228ContratoNome = BC001A54_n228ContratoNome[0];
            A496ConvenioVencimentoAno = BC001A54_A496ConvenioVencimentoAno[0];
            n496ConvenioVencimentoAno = BC001A54_n496ConvenioVencimentoAno[0];
            A497ConvenioVencimentoMes = BC001A54_A497ConvenioVencimentoMes[0];
            n497ConvenioVencimentoMes = BC001A54_n497ConvenioVencimentoMes[0];
            A494ConvenioCategoriaDescricao = BC001A54_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = BC001A54_n494ConvenioCategoriaDescricao[0];
            A227ContratoId = BC001A54_A227ContratoId[0];
            n227ContratoId = BC001A54_n227ContratoId[0];
            A376ProcedimentosMedicosId = BC001A54_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = BC001A54_n376ProcedimentosMedicosId[0];
            A493ConvenioCategoriaId = BC001A54_A493ConvenioCategoriaId[0];
            n493ConvenioCategoriaId = BC001A54_n493ConvenioCategoriaId[0];
            A328PropostaCratedBy = BC001A54_A328PropostaCratedBy[0];
            n328PropostaCratedBy = BC001A54_n328PropostaCratedBy[0];
            A504PropostaPacienteClienteId = BC001A54_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = BC001A54_n504PropostaPacienteClienteId[0];
            A553PropostaResponsavelId = BC001A54_A553PropostaResponsavelId[0];
            n553PropostaResponsavelId = BC001A54_n553PropostaResponsavelId[0];
            A642PropostaClinicaId = BC001A54_A642PropostaClinicaId[0];
            n642PropostaClinicaId = BC001A54_n642PropostaClinicaId[0];
            A850PropostaEmpresaClienteId = BC001A54_A850PropostaEmpresaClienteId[0];
            n850PropostaEmpresaClienteId = BC001A54_n850PropostaEmpresaClienteId[0];
            A410ConvenioId = BC001A54_A410ConvenioId[0];
            n410ConvenioId = BC001A54_n410ConvenioId[0];
            A625PropostaPacienteMunicipioCodigo = BC001A54_A625PropostaPacienteMunicipioCodigo[0];
            n625PropostaPacienteMunicipioCodigo = BC001A54_n625PropostaPacienteMunicipioCodigo[0];
            A649PropostaMaxReembolsoId_F = BC001A54_A649PropostaMaxReembolsoId_F[0];
            n649PropostaMaxReembolsoId_F = BC001A54_n649PropostaMaxReembolsoId_F[0];
            A854PropostaQtdItensNota_F = BC001A54_A854PropostaQtdItensNota_F[0];
            n854PropostaQtdItensNota_F = BC001A54_n854PropostaQtdItensNota_F[0];
            A733PropostaResponsavelSerasaConsultas_F = BC001A54_A733PropostaResponsavelSerasaConsultas_F[0];
            n733PropostaResponsavelSerasaConsultas_F = BC001A54_n733PropostaResponsavelSerasaConsultas_F[0];
            A783PropostaResponsavelSerasaScoreUltimaData_F = BC001A54_A783PropostaResponsavelSerasaScoreUltimaData_F[0];
            n783PropostaResponsavelSerasaScoreUltimaData_F = BC001A54_n783PropostaResponsavelSerasaScoreUltimaData_F[0];
            A786PropostaResponsavelSerasaUltimoValorRecomendado_F = BC001A54_A786PropostaResponsavelSerasaUltimoValorRecomendado_F[0];
            n786PropostaResponsavelSerasaUltimoValorRecomendado_F = BC001A54_n786PropostaResponsavelSerasaUltimoValorRecomendado_F[0];
            A734PropostaPacienteSerasaConsultas_F = BC001A54_A734PropostaPacienteSerasaConsultas_F[0];
            n734PropostaPacienteSerasaConsultas_F = BC001A54_n734PropostaPacienteSerasaConsultas_F[0];
            A782PropostaSerasaScoreUltimaData_F = BC001A54_A782PropostaSerasaScoreUltimaData_F[0];
            n782PropostaSerasaScoreUltimaData_F = BC001A54_n782PropostaSerasaScoreUltimaData_F[0];
            A787PropostaPacienteSerasaUltimoValorRecomendado_F = BC001A54_A787PropostaPacienteSerasaUltimoValorRecomendado_F[0];
            n787PropostaPacienteSerasaUltimoValorRecomendado_F = BC001A54_n787PropostaPacienteSerasaUltimoValorRecomendado_F[0];
            A655PropostaQtdDocumentoPendente_F = BC001A54_A655PropostaQtdDocumentoPendente_F[0];
            n655PropostaQtdDocumentoPendente_F = BC001A54_n655PropostaQtdDocumentoPendente_F[0];
            A341PropostaAprovacoes_F = BC001A54_A341PropostaAprovacoes_F[0];
            n341PropostaAprovacoes_F = BC001A54_n341PropostaAprovacoes_F[0];
            A342PropostaReprovacoes_F = BC001A54_A342PropostaReprovacoes_F[0];
            n342PropostaReprovacoes_F = BC001A54_n342PropostaReprovacoes_F[0];
            ZM1A49( -32) ;
         }
         pr_default.close(23);
         OnLoadActions1A49( ) ;
      }

      protected void OnLoadActions1A49( )
      {
         /* Using cursor BC001A25 */
         pr_default.execute(14, new Object[] {n323PropostaId, A323PropostaId, n642PropostaClinicaId, A642PropostaClinicaId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            A650PropostaValorTaxaClinica_F = BC001A25_A650PropostaValorTaxaClinica_F[0];
            n650PropostaValorTaxaClinica_F = BC001A25_n650PropostaValorTaxaClinica_F[0];
         }
         else
         {
            A650PropostaValorTaxaClinica_F = 0;
            n650PropostaValorTaxaClinica_F = false;
         }
         pr_default.close(14);
         A343PropostaAprovacoesRestantes_F = (short)(A330PropostaQuantidadeAprovadores-A341PropostaAprovacoes_F);
         if ( (0==A850PropostaEmpresaClienteId) )
         {
            A850PropostaEmpresaClienteId = 0;
            n850PropostaEmpresaClienteId = false;
            n850PropostaEmpresaClienteId = true;
            n850PropostaEmpresaClienteId = true;
         }
         if ( (0==A504PropostaPacienteClienteId) )
         {
            A504PropostaPacienteClienteId = 0;
            n504PropostaPacienteClienteId = false;
            n504PropostaPacienteClienteId = true;
            n504PropostaPacienteClienteId = true;
         }
         /* Using cursor BC001A14 */
         pr_default.execute(10, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId, n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            A509PropostaValorReembolsado_F = BC001A14_A509PropostaValorReembolsado_F[0];
            n509PropostaValorReembolsado_F = BC001A14_n509PropostaValorReembolsado_F[0];
         }
         else
         {
            A509PropostaValorReembolsado_F = 0;
            n509PropostaValorReembolsado_F = false;
         }
         pr_default.close(10);
         /* Using cursor BC001A17 */
         pr_default.execute(11, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId, n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            A510PropostaValorReembolsadoJuros_F = BC001A17_A510PropostaValorReembolsadoJuros_F[0];
            n510PropostaValorReembolsadoJuros_F = BC001A17_n510PropostaValorReembolsadoJuros_F[0];
         }
         else
         {
            A510PropostaValorReembolsadoJuros_F = 0;
            n510PropostaValorReembolsadoJuros_F = false;
         }
         pr_default.close(11);
         /* Using cursor BC001A23 */
         pr_default.execute(13, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId, n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            A515PropostaDataCreditoCliente_F = BC001A23_A515PropostaDataCreditoCliente_F[0];
            n515PropostaDataCreditoCliente_F = BC001A23_n515PropostaDataCreditoCliente_F[0];
         }
         else
         {
            A515PropostaDataCreditoCliente_F = DateTime.MinValue;
            n515PropostaDataCreditoCliente_F = false;
         }
         pr_default.close(13);
         GXt_decimal1 = A514PropostaValorJurosMora_F;
         new prcalcularjurosmora(context ).execute(  A515PropostaDataCreditoCliente_F,  A507PropostaSLA,  A508PropostaJurosMora,  A326PropostaValor, out  GXt_decimal1) ;
         A514PropostaValorJurosMora_F = GXt_decimal1;
         A784PropostaMaiorScore_F = (short)(((A782PropostaSerasaScoreUltimaData_F>A783PropostaResponsavelSerasaScoreUltimaData_F) ? A782PropostaSerasaScoreUltimaData_F : A783PropostaResponsavelSerasaScoreUltimaData_F));
         A788PropostaMaiorValorRecomendado = ((A786PropostaResponsavelSerasaUltimoValorRecomendado_F>A787PropostaPacienteSerasaUltimoValorRecomendado_F) ? A786PropostaResponsavelSerasaUltimoValorRecomendado_F : A787PropostaPacienteSerasaUltimoValorRecomendado_F);
         if ( (0==A553PropostaResponsavelId) )
         {
            A553PropostaResponsavelId = 0;
            n553PropostaResponsavelId = false;
            n553PropostaResponsavelId = true;
            n553PropostaResponsavelId = true;
         }
         if ( (0==A376ProcedimentosMedicosId) )
         {
            A376ProcedimentosMedicosId = 0;
            n376ProcedimentosMedicosId = false;
            n376ProcedimentosMedicosId = true;
            n376ProcedimentosMedicosId = true;
         }
         A575PropostaTaxa_F = (decimal)(A326PropostaValor*(A501PropostaTaxaAdministrativa/ (decimal)(100)));
         A513PropostaValorTaxa_F = (decimal)(A326PropostaValor*(A501PropostaTaxaAdministrativa/ (decimal)(100)));
         if ( (0==A328PropostaCratedBy) )
         {
            A328PropostaCratedBy = 0;
            n328PropostaCratedBy = false;
            n328PropostaCratedBy = true;
            n328PropostaCratedBy = true;
         }
         /* Using cursor BC001A20 */
         pr_default.execute(12, new Object[] {n328PropostaCratedBy, A328PropostaCratedBy, n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            A511PropostaValorTaxaRecebida_F = BC001A20_A511PropostaValorTaxaRecebida_F[0];
            n511PropostaValorTaxaRecebida_F = BC001A20_n511PropostaValorTaxaRecebida_F[0];
         }
         else
         {
            A511PropostaValorTaxaRecebida_F = 0;
            n511PropostaValorTaxaRecebida_F = false;
         }
         pr_default.close(12);
         if ( (0==A227ContratoId) )
         {
            A227ContratoId = 0;
            n227ContratoId = false;
            n227ContratoId = true;
            n227ContratoId = true;
         }
         if ( (0==A493ConvenioCategoriaId) )
         {
            A493ConvenioCategoriaId = 0;
            n493ConvenioCategoriaId = false;
            n493ConvenioCategoriaId = true;
            n493ConvenioCategoriaId = true;
         }
      }

      protected void CheckExtendedTable1A49( )
      {
         standaloneModal( ) ;
         /* Using cursor BC001A25 */
         pr_default.execute(14, new Object[] {n323PropostaId, A323PropostaId, n642PropostaClinicaId, A642PropostaClinicaId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            A650PropostaValorTaxaClinica_F = BC001A25_A650PropostaValorTaxaClinica_F[0];
            n650PropostaValorTaxaClinica_F = BC001A25_n650PropostaValorTaxaClinica_F[0];
         }
         else
         {
            A650PropostaValorTaxaClinica_F = 0;
            n650PropostaValorTaxaClinica_F = false;
         }
         pr_default.close(14);
         if ( ( A650PropostaValorTaxaClinica_F < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC001A27 */
         pr_default.execute(15, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            A649PropostaMaxReembolsoId_F = BC001A27_A649PropostaMaxReembolsoId_F[0];
            n649PropostaMaxReembolsoId_F = BC001A27_n649PropostaMaxReembolsoId_F[0];
         }
         else
         {
            A649PropostaMaxReembolsoId_F = 0;
            n649PropostaMaxReembolsoId_F = false;
         }
         pr_default.close(15);
         /* Using cursor BC001A29 */
         pr_default.execute(16, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            A854PropostaQtdItensNota_F = BC001A29_A854PropostaQtdItensNota_F[0];
            n854PropostaQtdItensNota_F = BC001A29_n854PropostaQtdItensNota_F[0];
         }
         else
         {
            A854PropostaQtdItensNota_F = 0;
            n854PropostaQtdItensNota_F = false;
         }
         pr_default.close(16);
         /* Using cursor BC001A39 */
         pr_default.execute(20, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(20) != 101) )
         {
            A655PropostaQtdDocumentoPendente_F = BC001A39_A655PropostaQtdDocumentoPendente_F[0];
            n655PropostaQtdDocumentoPendente_F = BC001A39_n655PropostaQtdDocumentoPendente_F[0];
         }
         else
         {
            A655PropostaQtdDocumentoPendente_F = 0;
            n655PropostaQtdDocumentoPendente_F = false;
         }
         pr_default.close(20);
         /* Using cursor BC001A41 */
         pr_default.execute(21, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(21) != 101) )
         {
            A341PropostaAprovacoes_F = BC001A41_A341PropostaAprovacoes_F[0];
            n341PropostaAprovacoes_F = BC001A41_n341PropostaAprovacoes_F[0];
         }
         else
         {
            A341PropostaAprovacoes_F = 0;
            n341PropostaAprovacoes_F = false;
         }
         pr_default.close(21);
         A343PropostaAprovacoesRestantes_F = (short)(A330PropostaQuantidadeAprovadores-A341PropostaAprovacoes_F);
         /* Using cursor BC001A43 */
         pr_default.execute(22, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(22) != 101) )
         {
            A342PropostaReprovacoes_F = BC001A43_A342PropostaReprovacoes_F[0];
            n342PropostaReprovacoes_F = BC001A43_n342PropostaReprovacoes_F[0];
         }
         else
         {
            A342PropostaReprovacoes_F = 0;
            n342PropostaReprovacoes_F = false;
         }
         pr_default.close(22);
         if ( (0==A850PropostaEmpresaClienteId) )
         {
            A850PropostaEmpresaClienteId = 0;
            n850PropostaEmpresaClienteId = false;
            n850PropostaEmpresaClienteId = true;
            n850PropostaEmpresaClienteId = true;
         }
         /* Using cursor BC001A11 */
         pr_default.execute(9, new Object[] {n850PropostaEmpresaClienteId, A850PropostaEmpresaClienteId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( (0==A850PropostaEmpresaClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Sd Proposta Empresa'.", "ForeignKeyNotFound", 1, "PROPOSTAEMPRESACLIENTEID");
               AnyError = 1;
            }
         }
         pr_default.close(9);
         if ( ! ( ( StringUtil.StrCmp(A849PropostaTipoProposta, "CLINICA") == 0 ) || ( StringUtil.StrCmp(A849PropostaTipoProposta, "COMPRA_TITULO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A849PropostaTipoProposta)) ) )
         {
            GX_msglist.addItem("Campo Proposta Tipo Proposta fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( (0==A504PropostaPacienteClienteId) )
         {
            A504PropostaPacienteClienteId = 0;
            n504PropostaPacienteClienteId = false;
            n504PropostaPacienteClienteId = true;
            n504PropostaPacienteClienteId = true;
         }
         /* Using cursor BC001A8 */
         pr_default.execute(6, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A504PropostaPacienteClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Proposta Cliente'.", "ForeignKeyNotFound", 1, "PROPOSTAPACIENTECLIENTEID");
               AnyError = 1;
            }
         }
         A505PropostaPacienteClienteRazaoSocial = BC001A8_A505PropostaPacienteClienteRazaoSocial[0];
         n505PropostaPacienteClienteRazaoSocial = BC001A8_n505PropostaPacienteClienteRazaoSocial[0];
         A540PropostaPacienteClienteDocumento = BC001A8_A540PropostaPacienteClienteDocumento[0];
         n540PropostaPacienteClienteDocumento = BC001A8_n540PropostaPacienteClienteDocumento[0];
         A541PropostaPacienteContatoEmail = BC001A8_A541PropostaPacienteContatoEmail[0];
         n541PropostaPacienteContatoEmail = BC001A8_n541PropostaPacienteContatoEmail[0];
         A584PropostaPacienteConta = BC001A8_A584PropostaPacienteConta[0];
         n584PropostaPacienteConta = BC001A8_n584PropostaPacienteConta[0];
         A585PropostaPacienteAgencia = BC001A8_A585PropostaPacienteAgencia[0];
         n585PropostaPacienteAgencia = BC001A8_n585PropostaPacienteAgencia[0];
         A586PropostaPacienteTipoPix = BC001A8_A586PropostaPacienteTipoPix[0];
         n586PropostaPacienteTipoPix = BC001A8_n586PropostaPacienteTipoPix[0];
         A587PropostaPacientePIX = BC001A8_A587PropostaPacientePIX[0];
         n587PropostaPacientePIX = BC001A8_n587PropostaPacientePIX[0];
         A588PropostaPacienteDepositoTipo = BC001A8_A588PropostaPacienteDepositoTipo[0];
         n588PropostaPacienteDepositoTipo = BC001A8_n588PropostaPacienteDepositoTipo[0];
         A620PropostaPacienteEnderecoCEP = BC001A8_A620PropostaPacienteEnderecoCEP[0];
         n620PropostaPacienteEnderecoCEP = BC001A8_n620PropostaPacienteEnderecoCEP[0];
         A621PropostaPacienteEnderecoLogradouro = BC001A8_A621PropostaPacienteEnderecoLogradouro[0];
         n621PropostaPacienteEnderecoLogradouro = BC001A8_n621PropostaPacienteEnderecoLogradouro[0];
         A622PropostaPacienteEnderecoNumero = BC001A8_A622PropostaPacienteEnderecoNumero[0];
         n622PropostaPacienteEnderecoNumero = BC001A8_n622PropostaPacienteEnderecoNumero[0];
         A623PropostaPacienteEnderecoComplemento = BC001A8_A623PropostaPacienteEnderecoComplemento[0];
         n623PropostaPacienteEnderecoComplemento = BC001A8_n623PropostaPacienteEnderecoComplemento[0];
         A624PropostaPacienteEnderecoBairro = BC001A8_A624PropostaPacienteEnderecoBairro[0];
         n624PropostaPacienteEnderecoBairro = BC001A8_n624PropostaPacienteEnderecoBairro[0];
         A625PropostaPacienteMunicipioCodigo = BC001A8_A625PropostaPacienteMunicipioCodigo[0];
         n625PropostaPacienteMunicipioCodigo = BC001A8_n625PropostaPacienteMunicipioCodigo[0];
         pr_default.close(6);
         /* Using cursor BC001A14 */
         pr_default.execute(10, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId, n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            A509PropostaValorReembolsado_F = BC001A14_A509PropostaValorReembolsado_F[0];
            n509PropostaValorReembolsado_F = BC001A14_n509PropostaValorReembolsado_F[0];
         }
         else
         {
            A509PropostaValorReembolsado_F = 0;
            n509PropostaValorReembolsado_F = false;
         }
         pr_default.close(10);
         if ( ( A509PropostaValorReembolsado_F < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC001A17 */
         pr_default.execute(11, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId, n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            A510PropostaValorReembolsadoJuros_F = BC001A17_A510PropostaValorReembolsadoJuros_F[0];
            n510PropostaValorReembolsadoJuros_F = BC001A17_n510PropostaValorReembolsadoJuros_F[0];
         }
         else
         {
            A510PropostaValorReembolsadoJuros_F = 0;
            n510PropostaValorReembolsadoJuros_F = false;
         }
         pr_default.close(11);
         if ( ( A510PropostaValorReembolsadoJuros_F < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC001A23 */
         pr_default.execute(13, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId, n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            A515PropostaDataCreditoCliente_F = BC001A23_A515PropostaDataCreditoCliente_F[0];
            n515PropostaDataCreditoCliente_F = BC001A23_n515PropostaDataCreditoCliente_F[0];
         }
         else
         {
            A515PropostaDataCreditoCliente_F = DateTime.MinValue;
            n515PropostaDataCreditoCliente_F = false;
         }
         pr_default.close(13);
         GXt_decimal1 = A514PropostaValorJurosMora_F;
         new prcalcularjurosmora(context ).execute(  A515PropostaDataCreditoCliente_F,  A507PropostaSLA,  A508PropostaJurosMora,  A326PropostaValor, out  GXt_decimal1) ;
         A514PropostaValorJurosMora_F = GXt_decimal1;
         if ( ( A514PropostaValorJurosMora_F < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC001A31 */
         pr_default.execute(17, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            A733PropostaResponsavelSerasaConsultas_F = BC001A31_A733PropostaResponsavelSerasaConsultas_F[0];
            n733PropostaResponsavelSerasaConsultas_F = BC001A31_n733PropostaResponsavelSerasaConsultas_F[0];
            A734PropostaPacienteSerasaConsultas_F = BC001A31_A734PropostaPacienteSerasaConsultas_F[0];
            n734PropostaPacienteSerasaConsultas_F = BC001A31_n734PropostaPacienteSerasaConsultas_F[0];
         }
         else
         {
            A734PropostaPacienteSerasaConsultas_F = 0;
            n734PropostaPacienteSerasaConsultas_F = false;
            A733PropostaResponsavelSerasaConsultas_F = 0;
            n733PropostaResponsavelSerasaConsultas_F = false;
         }
         pr_default.close(17);
         /* Using cursor BC001A34 */
         pr_default.execute(18, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            A783PropostaResponsavelSerasaScoreUltimaData_F = BC001A34_A783PropostaResponsavelSerasaScoreUltimaData_F[0];
            n783PropostaResponsavelSerasaScoreUltimaData_F = BC001A34_n783PropostaResponsavelSerasaScoreUltimaData_F[0];
            A782PropostaSerasaScoreUltimaData_F = BC001A34_A782PropostaSerasaScoreUltimaData_F[0];
            n782PropostaSerasaScoreUltimaData_F = BC001A34_n782PropostaSerasaScoreUltimaData_F[0];
         }
         else
         {
            A782PropostaSerasaScoreUltimaData_F = 0;
            n782PropostaSerasaScoreUltimaData_F = false;
            A783PropostaResponsavelSerasaScoreUltimaData_F = 0;
            n783PropostaResponsavelSerasaScoreUltimaData_F = false;
         }
         pr_default.close(18);
         A784PropostaMaiorScore_F = (short)(((A782PropostaSerasaScoreUltimaData_F>A783PropostaResponsavelSerasaScoreUltimaData_F) ? A782PropostaSerasaScoreUltimaData_F : A783PropostaResponsavelSerasaScoreUltimaData_F));
         /* Using cursor BC001A37 */
         pr_default.execute(19, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            A786PropostaResponsavelSerasaUltimoValorRecomendado_F = BC001A37_A786PropostaResponsavelSerasaUltimoValorRecomendado_F[0];
            n786PropostaResponsavelSerasaUltimoValorRecomendado_F = BC001A37_n786PropostaResponsavelSerasaUltimoValorRecomendado_F[0];
            A787PropostaPacienteSerasaUltimoValorRecomendado_F = BC001A37_A787PropostaPacienteSerasaUltimoValorRecomendado_F[0];
            n787PropostaPacienteSerasaUltimoValorRecomendado_F = BC001A37_n787PropostaPacienteSerasaUltimoValorRecomendado_F[0];
         }
         else
         {
            A787PropostaPacienteSerasaUltimoValorRecomendado_F = 0;
            n787PropostaPacienteSerasaUltimoValorRecomendado_F = false;
            A786PropostaResponsavelSerasaUltimoValorRecomendado_F = 0;
            n786PropostaResponsavelSerasaUltimoValorRecomendado_F = false;
         }
         pr_default.close(19);
         if ( ( A786PropostaResponsavelSerasaUltimoValorRecomendado_F < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         A788PropostaMaiorValorRecomendado = ((A786PropostaResponsavelSerasaUltimoValorRecomendado_F>A787PropostaPacienteSerasaUltimoValorRecomendado_F) ? A786PropostaResponsavelSerasaUltimoValorRecomendado_F : A787PropostaPacienteSerasaUltimoValorRecomendado_F);
         if ( ( A788PropostaMaiorValorRecomendado < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         if ( ( A787PropostaPacienteSerasaUltimoValorRecomendado_F < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         if ( (0==A553PropostaResponsavelId) )
         {
            A553PropostaResponsavelId = 0;
            n553PropostaResponsavelId = false;
            n553PropostaResponsavelId = true;
            n553PropostaResponsavelId = true;
         }
         /* Using cursor BC001A9 */
         pr_default.execute(7, new Object[] {n553PropostaResponsavelId, A553PropostaResponsavelId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A553PropostaResponsavelId) ) )
            {
               GX_msglist.addItem("Não existe 'Proposta Responsavel'.", "ForeignKeyNotFound", 1, "PROPOSTARESPONSAVELID");
               AnyError = 1;
            }
         }
         A580PropostaResponsavelDocumento = BC001A9_A580PropostaResponsavelDocumento[0];
         n580PropostaResponsavelDocumento = BC001A9_n580PropostaResponsavelDocumento[0];
         A581PropostaResponsavelRazaoSocial = BC001A9_A581PropostaResponsavelRazaoSocial[0];
         n581PropostaResponsavelRazaoSocial = BC001A9_n581PropostaResponsavelRazaoSocial[0];
         A582PropostaResponsavelEmail = BC001A9_A582PropostaResponsavelEmail[0];
         n582PropostaResponsavelEmail = BC001A9_n582PropostaResponsavelEmail[0];
         A590PropostaResponsavelConta = BC001A9_A590PropostaResponsavelConta[0];
         n590PropostaResponsavelConta = BC001A9_n590PropostaResponsavelConta[0];
         A591PropostaResponsavelAgencia = BC001A9_A591PropostaResponsavelAgencia[0];
         n591PropostaResponsavelAgencia = BC001A9_n591PropostaResponsavelAgencia[0];
         A592PropostaResponsavelTipoPix = BC001A9_A592PropostaResponsavelTipoPix[0];
         n592PropostaResponsavelTipoPix = BC001A9_n592PropostaResponsavelTipoPix[0];
         A593PropostaResponsavelPIX = BC001A9_A593PropostaResponsavelPIX[0];
         n593PropostaResponsavelPIX = BC001A9_n593PropostaResponsavelPIX[0];
         A594PropostaResponsavelDepositoTipo = BC001A9_A594PropostaResponsavelDepositoTipo[0];
         n594PropostaResponsavelDepositoTipo = BC001A9_n594PropostaResponsavelDepositoTipo[0];
         pr_default.close(7);
         if ( (0==A376ProcedimentosMedicosId) )
         {
            A376ProcedimentosMedicosId = 0;
            n376ProcedimentosMedicosId = false;
            n376ProcedimentosMedicosId = true;
            n376ProcedimentosMedicosId = true;
         }
         /* Using cursor BC001A5 */
         pr_default.execute(3, new Object[] {n376ProcedimentosMedicosId, A376ProcedimentosMedicosId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A376ProcedimentosMedicosId) ) )
            {
               GX_msglist.addItem("Não existe 'ProcedimentosMedicos'.", "ForeignKeyNotFound", 1, "PROCEDIMENTOSMEDICOSID");
               AnyError = 1;
            }
         }
         pr_default.close(3);
         A575PropostaTaxa_F = (decimal)(A326PropostaValor*(A501PropostaTaxaAdministrativa/ (decimal)(100)));
         A513PropostaValorTaxa_F = (decimal)(A326PropostaValor*(A501PropostaTaxaAdministrativa/ (decimal)(100)));
         if ( ( A513PropostaValorTaxa_F < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         if ( ( A326PropostaValor < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         if ( ( A855PropostaValorLiquido < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         if ( (0==A328PropostaCratedBy) )
         {
            A328PropostaCratedBy = 0;
            n328PropostaCratedBy = false;
            n328PropostaCratedBy = true;
            n328PropostaCratedBy = true;
         }
         /* Using cursor BC001A7 */
         pr_default.execute(5, new Object[] {n328PropostaCratedBy, A328PropostaCratedBy});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A328PropostaCratedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sec User Proposta'.", "ForeignKeyNotFound", 1, "PROPOSTACRATEDBY");
               AnyError = 1;
            }
         }
         A512PropostaSecUserName = BC001A7_A512PropostaSecUserName[0];
         n512PropostaSecUserName = BC001A7_n512PropostaSecUserName[0];
         pr_default.close(5);
         /* Using cursor BC001A20 */
         pr_default.execute(12, new Object[] {n328PropostaCratedBy, A328PropostaCratedBy, n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            A511PropostaValorTaxaRecebida_F = BC001A20_A511PropostaValorTaxaRecebida_F[0];
            n511PropostaValorTaxaRecebida_F = BC001A20_n511PropostaValorTaxaRecebida_F[0];
         }
         else
         {
            A511PropostaValorTaxaRecebida_F = 0;
            n511PropostaValorTaxaRecebida_F = false;
         }
         pr_default.close(12);
         if ( ( A511PropostaValorTaxaRecebida_F < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC001A10 */
         pr_default.execute(8, new Object[] {n642PropostaClinicaId, A642PropostaClinicaId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (0==A642PropostaClinicaId) ) )
            {
               GX_msglist.addItem("Não foi possível identificar o ID da clínica, por favor entre em contato com suporte.", "ForeignKeyNotFound", 1, "PROPOSTACLINICAID");
               AnyError = 1;
            }
         }
         A643PropostaClinicaNome = BC001A10_A643PropostaClinicaNome[0];
         n643PropostaClinicaNome = BC001A10_n643PropostaClinicaNome[0];
         A644PropostaClinicaNomeFantasia = BC001A10_A644PropostaClinicaNomeFantasia[0];
         n644PropostaClinicaNomeFantasia = BC001A10_n644PropostaClinicaNomeFantasia[0];
         A652PropostaClinicaDocumento = BC001A10_A652PropostaClinicaDocumento[0];
         n652PropostaClinicaDocumento = BC001A10_n652PropostaClinicaDocumento[0];
         A653PropostaClinicaEmail = BC001A10_A653PropostaClinicaEmail[0];
         n653PropostaClinicaEmail = BC001A10_n653PropostaClinicaEmail[0];
         pr_default.close(8);
         if ( ! ( ( StringUtil.StrCmp(A329PropostaStatus, "PENDENTE") == 0 ) || ( StringUtil.StrCmp(A329PropostaStatus, "EM_ANALISE") == 0 ) || ( StringUtil.StrCmp(A329PropostaStatus, "APROVADO") == 0 ) || ( StringUtil.StrCmp(A329PropostaStatus, "REJEITADO") == 0 ) || ( StringUtil.StrCmp(A329PropostaStatus, "REVISAO") == 0 ) || ( StringUtil.StrCmp(A329PropostaStatus, "CANCELADO") == 0 ) || ( StringUtil.StrCmp(A329PropostaStatus, "AGUARDANDO_ASSINATURA") == 0 ) || ( StringUtil.StrCmp(A329PropostaStatus, "AnaliseReprovada") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A329PropostaStatus)) ) )
         {
            GX_msglist.addItem("Campo Proposta Status fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( (0==A227ContratoId) )
         {
            A227ContratoId = 0;
            n227ContratoId = false;
            n227ContratoId = true;
            n227ContratoId = true;
         }
         /* Using cursor BC001A4 */
         pr_default.execute(2, new Object[] {n227ContratoId, A227ContratoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A227ContratoId) ) )
            {
               GX_msglist.addItem("Não existe 'Contrato'.", "ForeignKeyNotFound", 1, "CONTRATOID");
               AnyError = 1;
            }
         }
         A228ContratoNome = BC001A4_A228ContratoNome[0];
         n228ContratoNome = BC001A4_n228ContratoNome[0];
         pr_default.close(2);
         if ( ! ( ( A496ConvenioVencimentoAno == 2024 ) || ( A496ConvenioVencimentoAno == 2025 ) || ( A496ConvenioVencimentoAno == 2026 ) || ( A496ConvenioVencimentoAno == 2027 ) || ( A496ConvenioVencimentoAno == 2028 ) || ( A496ConvenioVencimentoAno == 2029 ) || ( A496ConvenioVencimentoAno == 2030 ) || ( A496ConvenioVencimentoAno == 2031 ) || ( A496ConvenioVencimentoAno == 2032 ) || ( A496ConvenioVencimentoAno == 2033 ) || ( A496ConvenioVencimentoAno == 2034 ) || ( A496ConvenioVencimentoAno == 2035 ) || ( A496ConvenioVencimentoAno == 2036 ) || ( A496ConvenioVencimentoAno == 2037 ) || ( A496ConvenioVencimentoAno == 2038 ) || ( A496ConvenioVencimentoAno == 2039 ) || ( A496ConvenioVencimentoAno == 2040 ) || ( A496ConvenioVencimentoAno == 2041 ) || ( A496ConvenioVencimentoAno == 2042 ) || ( A496ConvenioVencimentoAno == 2043 ) || ( A496ConvenioVencimentoAno == 2044 ) || ( A496ConvenioVencimentoAno == 2045 ) || ( A496ConvenioVencimentoAno == 2046 ) || ( A496ConvenioVencimentoAno == 2047 ) || ( A496ConvenioVencimentoAno == 2048 ) || ( A496ConvenioVencimentoAno == 2049 ) || ( A496ConvenioVencimentoAno == 2050 ) || (0==A496ConvenioVencimentoAno) ) )
         {
            GX_msglist.addItem("Campo Convenio Vencimento Ano fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( A497ConvenioVencimentoMes == 1 ) || ( A497ConvenioVencimentoMes == 2 ) || ( A497ConvenioVencimentoMes == 3 ) || ( A497ConvenioVencimentoMes == 4 ) || ( A497ConvenioVencimentoMes == 5 ) || ( A497ConvenioVencimentoMes == 6 ) || ( A497ConvenioVencimentoMes == 7 ) || ( A497ConvenioVencimentoMes == 8 ) || ( A497ConvenioVencimentoMes == 9 ) || ( A497ConvenioVencimentoMes == 10 ) || ( A497ConvenioVencimentoMes == 11 ) || ( A497ConvenioVencimentoMes == 12 ) || (0==A497ConvenioVencimentoMes) ) )
         {
            GX_msglist.addItem("Campo Convenio Vencimento Mes fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( (0==A493ConvenioCategoriaId) )
         {
            A493ConvenioCategoriaId = 0;
            n493ConvenioCategoriaId = false;
            n493ConvenioCategoriaId = true;
            n493ConvenioCategoriaId = true;
         }
         /* Using cursor BC001A6 */
         pr_default.execute(4, new Object[] {n493ConvenioCategoriaId, A493ConvenioCategoriaId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A493ConvenioCategoriaId) ) )
            {
               GX_msglist.addItem("Não existe 'ConvenioCategoria'.", "ForeignKeyNotFound", 1, "CONVENIOCATEGORIAID");
               AnyError = 1;
            }
         }
         A494ConvenioCategoriaDescricao = BC001A6_A494ConvenioCategoriaDescricao[0];
         n494ConvenioCategoriaDescricao = BC001A6_n494ConvenioCategoriaDescricao[0];
         A410ConvenioId = BC001A6_A410ConvenioId[0];
         n410ConvenioId = BC001A6_n410ConvenioId[0];
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors1A49( )
      {
         pr_default.close(14);
         pr_default.close(15);
         pr_default.close(16);
         pr_default.close(20);
         pr_default.close(21);
         pr_default.close(22);
         pr_default.close(9);
         pr_default.close(6);
         pr_default.close(10);
         pr_default.close(11);
         pr_default.close(13);
         pr_default.close(17);
         pr_default.close(18);
         pr_default.close(19);
         pr_default.close(7);
         pr_default.close(3);
         pr_default.close(5);
         pr_default.close(12);
         pr_default.close(8);
         pr_default.close(2);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1A49( )
      {
         /* Using cursor BC001A55 */
         pr_default.execute(24, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound49 = 1;
         }
         else
         {
            RcdFound49 = 0;
         }
         pr_default.close(24);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001A3 */
         pr_default.execute(1, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1A49( 32) ;
            RcdFound49 = 1;
            A323PropostaId = BC001A3_A323PropostaId[0];
            n323PropostaId = BC001A3_n323PropostaId[0];
            A327PropostaCreatedAt = BC001A3_A327PropostaCreatedAt[0];
            n327PropostaCreatedAt = BC001A3_n327PropostaCreatedAt[0];
            A853PropostaProtocolo = BC001A3_A853PropostaProtocolo[0];
            n853PropostaProtocolo = BC001A3_n853PropostaProtocolo[0];
            A849PropostaTipoProposta = BC001A3_A849PropostaTipoProposta[0];
            n849PropostaTipoProposta = BC001A3_n849PropostaTipoProposta[0];
            A324PropostaTitulo = BC001A3_A324PropostaTitulo[0];
            n324PropostaTitulo = BC001A3_n324PropostaTitulo[0];
            A325PropostaDescricao = BC001A3_A325PropostaDescricao[0];
            n325PropostaDescricao = BC001A3_n325PropostaDescricao[0];
            A517PropostaDataCirurgia = BC001A3_A517PropostaDataCirurgia[0];
            n517PropostaDataCirurgia = BC001A3_n517PropostaDataCirurgia[0];
            A326PropostaValor = BC001A3_A326PropostaValor[0];
            n326PropostaValor = BC001A3_n326PropostaValor[0];
            A855PropostaValorLiquido = BC001A3_A855PropostaValorLiquido[0];
            n855PropostaValorLiquido = BC001A3_n855PropostaValorLiquido[0];
            A501PropostaTaxaAdministrativa = BC001A3_A501PropostaTaxaAdministrativa[0];
            n501PropostaTaxaAdministrativa = BC001A3_n501PropostaTaxaAdministrativa[0];
            A507PropostaSLA = BC001A3_A507PropostaSLA[0];
            n507PropostaSLA = BC001A3_n507PropostaSLA[0];
            A508PropostaJurosMora = BC001A3_A508PropostaJurosMora[0];
            n508PropostaJurosMora = BC001A3_n508PropostaJurosMora[0];
            A329PropostaStatus = BC001A3_A329PropostaStatus[0];
            n329PropostaStatus = BC001A3_n329PropostaStatus[0];
            A790PropostaComentarioAnalise = BC001A3_A790PropostaComentarioAnalise[0];
            n790PropostaComentarioAnalise = BC001A3_n790PropostaComentarioAnalise[0];
            A330PropostaQuantidadeAprovadores = BC001A3_A330PropostaQuantidadeAprovadores[0];
            n330PropostaQuantidadeAprovadores = BC001A3_n330PropostaQuantidadeAprovadores[0];
            A345PropostaReprovacoesPermitidas = BC001A3_A345PropostaReprovacoesPermitidas[0];
            n345PropostaReprovacoesPermitidas = BC001A3_n345PropostaReprovacoesPermitidas[0];
            A496ConvenioVencimentoAno = BC001A3_A496ConvenioVencimentoAno[0];
            n496ConvenioVencimentoAno = BC001A3_n496ConvenioVencimentoAno[0];
            A497ConvenioVencimentoMes = BC001A3_A497ConvenioVencimentoMes[0];
            n497ConvenioVencimentoMes = BC001A3_n497ConvenioVencimentoMes[0];
            A227ContratoId = BC001A3_A227ContratoId[0];
            n227ContratoId = BC001A3_n227ContratoId[0];
            A376ProcedimentosMedicosId = BC001A3_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = BC001A3_n376ProcedimentosMedicosId[0];
            A493ConvenioCategoriaId = BC001A3_A493ConvenioCategoriaId[0];
            n493ConvenioCategoriaId = BC001A3_n493ConvenioCategoriaId[0];
            A328PropostaCratedBy = BC001A3_A328PropostaCratedBy[0];
            n328PropostaCratedBy = BC001A3_n328PropostaCratedBy[0];
            A504PropostaPacienteClienteId = BC001A3_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = BC001A3_n504PropostaPacienteClienteId[0];
            A553PropostaResponsavelId = BC001A3_A553PropostaResponsavelId[0];
            n553PropostaResponsavelId = BC001A3_n553PropostaResponsavelId[0];
            A642PropostaClinicaId = BC001A3_A642PropostaClinicaId[0];
            n642PropostaClinicaId = BC001A3_n642PropostaClinicaId[0];
            A850PropostaEmpresaClienteId = BC001A3_A850PropostaEmpresaClienteId[0];
            n850PropostaEmpresaClienteId = BC001A3_n850PropostaEmpresaClienteId[0];
            Z323PropostaId = A323PropostaId;
            sMode49 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1A49( ) ;
            if ( AnyError == 1 )
            {
               RcdFound49 = 0;
               InitializeNonKey1A49( ) ;
            }
            Gx_mode = sMode49;
         }
         else
         {
            RcdFound49 = 0;
            InitializeNonKey1A49( ) ;
            sMode49 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode49;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1A49( ) ;
         if ( RcdFound49 == 0 )
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
         CONFIRM_1A0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1A49( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001A2 */
            pr_default.execute(0, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Proposta"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z327PropostaCreatedAt != BC001A2_A327PropostaCreatedAt[0] ) || ( StringUtil.StrCmp(Z853PropostaProtocolo, BC001A2_A853PropostaProtocolo[0]) != 0 ) || ( StringUtil.StrCmp(Z849PropostaTipoProposta, BC001A2_A849PropostaTipoProposta[0]) != 0 ) || ( StringUtil.StrCmp(Z324PropostaTitulo, BC001A2_A324PropostaTitulo[0]) != 0 ) || ( StringUtil.StrCmp(Z325PropostaDescricao, BC001A2_A325PropostaDescricao[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z517PropostaDataCirurgia ) != DateTimeUtil.ResetTime ( BC001A2_A517PropostaDataCirurgia[0] ) ) || ( Z326PropostaValor != BC001A2_A326PropostaValor[0] ) || ( Z855PropostaValorLiquido != BC001A2_A855PropostaValorLiquido[0] ) || ( Z501PropostaTaxaAdministrativa != BC001A2_A501PropostaTaxaAdministrativa[0] ) || ( Z507PropostaSLA != BC001A2_A507PropostaSLA[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z508PropostaJurosMora != BC001A2_A508PropostaJurosMora[0] ) || ( StringUtil.StrCmp(Z329PropostaStatus, BC001A2_A329PropostaStatus[0]) != 0 ) || ( StringUtil.StrCmp(Z790PropostaComentarioAnalise, BC001A2_A790PropostaComentarioAnalise[0]) != 0 ) || ( Z330PropostaQuantidadeAprovadores != BC001A2_A330PropostaQuantidadeAprovadores[0] ) || ( Z345PropostaReprovacoesPermitidas != BC001A2_A345PropostaReprovacoesPermitidas[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z496ConvenioVencimentoAno != BC001A2_A496ConvenioVencimentoAno[0] ) || ( Z497ConvenioVencimentoMes != BC001A2_A497ConvenioVencimentoMes[0] ) || ( Z227ContratoId != BC001A2_A227ContratoId[0] ) || ( Z376ProcedimentosMedicosId != BC001A2_A376ProcedimentosMedicosId[0] ) || ( Z493ConvenioCategoriaId != BC001A2_A493ConvenioCategoriaId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z328PropostaCratedBy != BC001A2_A328PropostaCratedBy[0] ) || ( Z504PropostaPacienteClienteId != BC001A2_A504PropostaPacienteClienteId[0] ) || ( Z553PropostaResponsavelId != BC001A2_A553PropostaResponsavelId[0] ) || ( Z642PropostaClinicaId != BC001A2_A642PropostaClinicaId[0] ) || ( Z850PropostaEmpresaClienteId != BC001A2_A850PropostaEmpresaClienteId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Proposta"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1A49( )
      {
         BeforeValidate1A49( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1A49( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1A49( 0) ;
            CheckOptimisticConcurrency1A49( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1A49( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1A49( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001A56 */
                     pr_default.execute(25, new Object[] {n327PropostaCreatedAt, A327PropostaCreatedAt, n853PropostaProtocolo, A853PropostaProtocolo, n849PropostaTipoProposta, A849PropostaTipoProposta, n324PropostaTitulo, A324PropostaTitulo, n325PropostaDescricao, A325PropostaDescricao, n517PropostaDataCirurgia, A517PropostaDataCirurgia, n326PropostaValor, A326PropostaValor, n855PropostaValorLiquido, A855PropostaValorLiquido, n501PropostaTaxaAdministrativa, A501PropostaTaxaAdministrativa, n507PropostaSLA, A507PropostaSLA, n508PropostaJurosMora, A508PropostaJurosMora, n329PropostaStatus, A329PropostaStatus, n790PropostaComentarioAnalise, A790PropostaComentarioAnalise, n330PropostaQuantidadeAprovadores, A330PropostaQuantidadeAprovadores, n345PropostaReprovacoesPermitidas, A345PropostaReprovacoesPermitidas, n496ConvenioVencimentoAno, A496ConvenioVencimentoAno, n497ConvenioVencimentoMes, A497ConvenioVencimentoMes, n227ContratoId, A227ContratoId, n376ProcedimentosMedicosId, A376ProcedimentosMedicosId, n493ConvenioCategoriaId, A493ConvenioCategoriaId, n328PropostaCratedBy, A328PropostaCratedBy, n504PropostaPacienteClienteId, A504PropostaPacienteClienteId, n553PropostaResponsavelId, A553PropostaResponsavelId, n642PropostaClinicaId, A642PropostaClinicaId, n850PropostaEmpresaClienteId, A850PropostaEmpresaClienteId});
                     pr_default.close(25);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC001A57 */
                     pr_default.execute(26);
                     A323PropostaId = BC001A57_A323PropostaId[0];
                     n323PropostaId = BC001A57_n323PropostaId[0];
                     pr_default.close(26);
                     pr_default.SmartCacheProvider.SetUpdated("Proposta");
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
               Load1A49( ) ;
            }
            EndLevel1A49( ) ;
         }
         CloseExtendedTableCursors1A49( ) ;
      }

      protected void Update1A49( )
      {
         BeforeValidate1A49( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1A49( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1A49( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1A49( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1A49( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001A58 */
                     pr_default.execute(27, new Object[] {n327PropostaCreatedAt, A327PropostaCreatedAt, n853PropostaProtocolo, A853PropostaProtocolo, n849PropostaTipoProposta, A849PropostaTipoProposta, n324PropostaTitulo, A324PropostaTitulo, n325PropostaDescricao, A325PropostaDescricao, n517PropostaDataCirurgia, A517PropostaDataCirurgia, n326PropostaValor, A326PropostaValor, n855PropostaValorLiquido, A855PropostaValorLiquido, n501PropostaTaxaAdministrativa, A501PropostaTaxaAdministrativa, n507PropostaSLA, A507PropostaSLA, n508PropostaJurosMora, A508PropostaJurosMora, n329PropostaStatus, A329PropostaStatus, n790PropostaComentarioAnalise, A790PropostaComentarioAnalise, n330PropostaQuantidadeAprovadores, A330PropostaQuantidadeAprovadores, n345PropostaReprovacoesPermitidas, A345PropostaReprovacoesPermitidas, n496ConvenioVencimentoAno, A496ConvenioVencimentoAno, n497ConvenioVencimentoMes, A497ConvenioVencimentoMes, n227ContratoId, A227ContratoId, n376ProcedimentosMedicosId, A376ProcedimentosMedicosId, n493ConvenioCategoriaId, A493ConvenioCategoriaId, n328PropostaCratedBy, A328PropostaCratedBy, n504PropostaPacienteClienteId, A504PropostaPacienteClienteId, n553PropostaResponsavelId, A553PropostaResponsavelId, n642PropostaClinicaId, A642PropostaClinicaId, n850PropostaEmpresaClienteId, A850PropostaEmpresaClienteId, n323PropostaId, A323PropostaId});
                     pr_default.close(27);
                     pr_default.SmartCacheProvider.SetUpdated("Proposta");
                     if ( (pr_default.getStatus(27) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Proposta"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1A49( ) ;
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
            EndLevel1A49( ) ;
         }
         CloseExtendedTableCursors1A49( ) ;
      }

      protected void DeferredUpdate1A49( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1A49( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1A49( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1A49( ) ;
            AfterConfirm1A49( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1A49( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001A59 */
                  pr_default.execute(28, new Object[] {n323PropostaId, A323PropostaId});
                  pr_default.close(28);
                  pr_default.SmartCacheProvider.SetUpdated("Proposta");
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
         sMode49 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1A49( ) ;
         Gx_mode = sMode49;
      }

      protected void OnDeleteControls1A49( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001A61 */
            pr_default.execute(29, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(29) != 101) )
            {
               A649PropostaMaxReembolsoId_F = BC001A61_A649PropostaMaxReembolsoId_F[0];
               n649PropostaMaxReembolsoId_F = BC001A61_n649PropostaMaxReembolsoId_F[0];
            }
            else
            {
               A649PropostaMaxReembolsoId_F = 0;
               n649PropostaMaxReembolsoId_F = false;
            }
            pr_default.close(29);
            /* Using cursor BC001A63 */
            pr_default.execute(30, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(30) != 101) )
            {
               A854PropostaQtdItensNota_F = BC001A63_A854PropostaQtdItensNota_F[0];
               n854PropostaQtdItensNota_F = BC001A63_n854PropostaQtdItensNota_F[0];
            }
            else
            {
               A854PropostaQtdItensNota_F = 0;
               n854PropostaQtdItensNota_F = false;
            }
            pr_default.close(30);
            /* Using cursor BC001A65 */
            pr_default.execute(31, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(31) != 101) )
            {
               A655PropostaQtdDocumentoPendente_F = BC001A65_A655PropostaQtdDocumentoPendente_F[0];
               n655PropostaQtdDocumentoPendente_F = BC001A65_n655PropostaQtdDocumentoPendente_F[0];
            }
            else
            {
               A655PropostaQtdDocumentoPendente_F = 0;
               n655PropostaQtdDocumentoPendente_F = false;
            }
            pr_default.close(31);
            /* Using cursor BC001A67 */
            pr_default.execute(32, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(32) != 101) )
            {
               A341PropostaAprovacoes_F = BC001A67_A341PropostaAprovacoes_F[0];
               n341PropostaAprovacoes_F = BC001A67_n341PropostaAprovacoes_F[0];
            }
            else
            {
               A341PropostaAprovacoes_F = 0;
               n341PropostaAprovacoes_F = false;
            }
            pr_default.close(32);
            /* Using cursor BC001A69 */
            pr_default.execute(33, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(33) != 101) )
            {
               A342PropostaReprovacoes_F = BC001A69_A342PropostaReprovacoes_F[0];
               n342PropostaReprovacoes_F = BC001A69_n342PropostaReprovacoes_F[0];
            }
            else
            {
               A342PropostaReprovacoes_F = 0;
               n342PropostaReprovacoes_F = false;
            }
            pr_default.close(33);
            /* Using cursor BC001A70 */
            pr_default.execute(34, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId});
            A505PropostaPacienteClienteRazaoSocial = BC001A70_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = BC001A70_n505PropostaPacienteClienteRazaoSocial[0];
            A540PropostaPacienteClienteDocumento = BC001A70_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = BC001A70_n540PropostaPacienteClienteDocumento[0];
            A541PropostaPacienteContatoEmail = BC001A70_A541PropostaPacienteContatoEmail[0];
            n541PropostaPacienteContatoEmail = BC001A70_n541PropostaPacienteContatoEmail[0];
            A584PropostaPacienteConta = BC001A70_A584PropostaPacienteConta[0];
            n584PropostaPacienteConta = BC001A70_n584PropostaPacienteConta[0];
            A585PropostaPacienteAgencia = BC001A70_A585PropostaPacienteAgencia[0];
            n585PropostaPacienteAgencia = BC001A70_n585PropostaPacienteAgencia[0];
            A586PropostaPacienteTipoPix = BC001A70_A586PropostaPacienteTipoPix[0];
            n586PropostaPacienteTipoPix = BC001A70_n586PropostaPacienteTipoPix[0];
            A587PropostaPacientePIX = BC001A70_A587PropostaPacientePIX[0];
            n587PropostaPacientePIX = BC001A70_n587PropostaPacientePIX[0];
            A588PropostaPacienteDepositoTipo = BC001A70_A588PropostaPacienteDepositoTipo[0];
            n588PropostaPacienteDepositoTipo = BC001A70_n588PropostaPacienteDepositoTipo[0];
            A620PropostaPacienteEnderecoCEP = BC001A70_A620PropostaPacienteEnderecoCEP[0];
            n620PropostaPacienteEnderecoCEP = BC001A70_n620PropostaPacienteEnderecoCEP[0];
            A621PropostaPacienteEnderecoLogradouro = BC001A70_A621PropostaPacienteEnderecoLogradouro[0];
            n621PropostaPacienteEnderecoLogradouro = BC001A70_n621PropostaPacienteEnderecoLogradouro[0];
            A622PropostaPacienteEnderecoNumero = BC001A70_A622PropostaPacienteEnderecoNumero[0];
            n622PropostaPacienteEnderecoNumero = BC001A70_n622PropostaPacienteEnderecoNumero[0];
            A623PropostaPacienteEnderecoComplemento = BC001A70_A623PropostaPacienteEnderecoComplemento[0];
            n623PropostaPacienteEnderecoComplemento = BC001A70_n623PropostaPacienteEnderecoComplemento[0];
            A624PropostaPacienteEnderecoBairro = BC001A70_A624PropostaPacienteEnderecoBairro[0];
            n624PropostaPacienteEnderecoBairro = BC001A70_n624PropostaPacienteEnderecoBairro[0];
            A625PropostaPacienteMunicipioCodigo = BC001A70_A625PropostaPacienteMunicipioCodigo[0];
            n625PropostaPacienteMunicipioCodigo = BC001A70_n625PropostaPacienteMunicipioCodigo[0];
            pr_default.close(34);
            /* Using cursor BC001A73 */
            pr_default.execute(35, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId, n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(35) != 101) )
            {
               A509PropostaValorReembolsado_F = BC001A73_A509PropostaValorReembolsado_F[0];
               n509PropostaValorReembolsado_F = BC001A73_n509PropostaValorReembolsado_F[0];
            }
            else
            {
               A509PropostaValorReembolsado_F = 0;
               n509PropostaValorReembolsado_F = false;
            }
            pr_default.close(35);
            /* Using cursor BC001A76 */
            pr_default.execute(36, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId, n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(36) != 101) )
            {
               A510PropostaValorReembolsadoJuros_F = BC001A76_A510PropostaValorReembolsadoJuros_F[0];
               n510PropostaValorReembolsadoJuros_F = BC001A76_n510PropostaValorReembolsadoJuros_F[0];
            }
            else
            {
               A510PropostaValorReembolsadoJuros_F = 0;
               n510PropostaValorReembolsadoJuros_F = false;
            }
            pr_default.close(36);
            /* Using cursor BC001A79 */
            pr_default.execute(37, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId, n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(37) != 101) )
            {
               A515PropostaDataCreditoCliente_F = BC001A79_A515PropostaDataCreditoCliente_F[0];
               n515PropostaDataCreditoCliente_F = BC001A79_n515PropostaDataCreditoCliente_F[0];
            }
            else
            {
               A515PropostaDataCreditoCliente_F = DateTime.MinValue;
               n515PropostaDataCreditoCliente_F = false;
            }
            pr_default.close(37);
            /* Using cursor BC001A81 */
            pr_default.execute(38, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId});
            if ( (pr_default.getStatus(38) != 101) )
            {
               A733PropostaResponsavelSerasaConsultas_F = BC001A81_A733PropostaResponsavelSerasaConsultas_F[0];
               n733PropostaResponsavelSerasaConsultas_F = BC001A81_n733PropostaResponsavelSerasaConsultas_F[0];
               A734PropostaPacienteSerasaConsultas_F = BC001A81_A734PropostaPacienteSerasaConsultas_F[0];
               n734PropostaPacienteSerasaConsultas_F = BC001A81_n734PropostaPacienteSerasaConsultas_F[0];
            }
            else
            {
               A734PropostaPacienteSerasaConsultas_F = 0;
               n734PropostaPacienteSerasaConsultas_F = false;
               A733PropostaResponsavelSerasaConsultas_F = 0;
               n733PropostaResponsavelSerasaConsultas_F = false;
            }
            pr_default.close(38);
            /* Using cursor BC001A84 */
            pr_default.execute(39, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId});
            if ( (pr_default.getStatus(39) != 101) )
            {
               A783PropostaResponsavelSerasaScoreUltimaData_F = BC001A84_A783PropostaResponsavelSerasaScoreUltimaData_F[0];
               n783PropostaResponsavelSerasaScoreUltimaData_F = BC001A84_n783PropostaResponsavelSerasaScoreUltimaData_F[0];
               A782PropostaSerasaScoreUltimaData_F = BC001A84_A782PropostaSerasaScoreUltimaData_F[0];
               n782PropostaSerasaScoreUltimaData_F = BC001A84_n782PropostaSerasaScoreUltimaData_F[0];
            }
            else
            {
               A782PropostaSerasaScoreUltimaData_F = 0;
               n782PropostaSerasaScoreUltimaData_F = false;
               A783PropostaResponsavelSerasaScoreUltimaData_F = 0;
               n783PropostaResponsavelSerasaScoreUltimaData_F = false;
            }
            pr_default.close(39);
            A784PropostaMaiorScore_F = (short)(((A782PropostaSerasaScoreUltimaData_F>A783PropostaResponsavelSerasaScoreUltimaData_F) ? A782PropostaSerasaScoreUltimaData_F : A783PropostaResponsavelSerasaScoreUltimaData_F));
            /* Using cursor BC001A87 */
            pr_default.execute(40, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId});
            if ( (pr_default.getStatus(40) != 101) )
            {
               A786PropostaResponsavelSerasaUltimoValorRecomendado_F = BC001A87_A786PropostaResponsavelSerasaUltimoValorRecomendado_F[0];
               n786PropostaResponsavelSerasaUltimoValorRecomendado_F = BC001A87_n786PropostaResponsavelSerasaUltimoValorRecomendado_F[0];
               A787PropostaPacienteSerasaUltimoValorRecomendado_F = BC001A87_A787PropostaPacienteSerasaUltimoValorRecomendado_F[0];
               n787PropostaPacienteSerasaUltimoValorRecomendado_F = BC001A87_n787PropostaPacienteSerasaUltimoValorRecomendado_F[0];
            }
            else
            {
               A787PropostaPacienteSerasaUltimoValorRecomendado_F = 0;
               n787PropostaPacienteSerasaUltimoValorRecomendado_F = false;
               A786PropostaResponsavelSerasaUltimoValorRecomendado_F = 0;
               n786PropostaResponsavelSerasaUltimoValorRecomendado_F = false;
            }
            pr_default.close(40);
            A788PropostaMaiorValorRecomendado = ((A786PropostaResponsavelSerasaUltimoValorRecomendado_F>A787PropostaPacienteSerasaUltimoValorRecomendado_F) ? A786PropostaResponsavelSerasaUltimoValorRecomendado_F : A787PropostaPacienteSerasaUltimoValorRecomendado_F);
            /* Using cursor BC001A88 */
            pr_default.execute(41, new Object[] {n553PropostaResponsavelId, A553PropostaResponsavelId});
            A580PropostaResponsavelDocumento = BC001A88_A580PropostaResponsavelDocumento[0];
            n580PropostaResponsavelDocumento = BC001A88_n580PropostaResponsavelDocumento[0];
            A581PropostaResponsavelRazaoSocial = BC001A88_A581PropostaResponsavelRazaoSocial[0];
            n581PropostaResponsavelRazaoSocial = BC001A88_n581PropostaResponsavelRazaoSocial[0];
            A582PropostaResponsavelEmail = BC001A88_A582PropostaResponsavelEmail[0];
            n582PropostaResponsavelEmail = BC001A88_n582PropostaResponsavelEmail[0];
            A590PropostaResponsavelConta = BC001A88_A590PropostaResponsavelConta[0];
            n590PropostaResponsavelConta = BC001A88_n590PropostaResponsavelConta[0];
            A591PropostaResponsavelAgencia = BC001A88_A591PropostaResponsavelAgencia[0];
            n591PropostaResponsavelAgencia = BC001A88_n591PropostaResponsavelAgencia[0];
            A592PropostaResponsavelTipoPix = BC001A88_A592PropostaResponsavelTipoPix[0];
            n592PropostaResponsavelTipoPix = BC001A88_n592PropostaResponsavelTipoPix[0];
            A593PropostaResponsavelPIX = BC001A88_A593PropostaResponsavelPIX[0];
            n593PropostaResponsavelPIX = BC001A88_n593PropostaResponsavelPIX[0];
            A594PropostaResponsavelDepositoTipo = BC001A88_A594PropostaResponsavelDepositoTipo[0];
            n594PropostaResponsavelDepositoTipo = BC001A88_n594PropostaResponsavelDepositoTipo[0];
            pr_default.close(41);
            A575PropostaTaxa_F = (decimal)(A326PropostaValor*(A501PropostaTaxaAdministrativa/ (decimal)(100)));
            A513PropostaValorTaxa_F = (decimal)(A326PropostaValor*(A501PropostaTaxaAdministrativa/ (decimal)(100)));
            GXt_decimal1 = A514PropostaValorJurosMora_F;
            new prcalcularjurosmora(context ).execute(  A515PropostaDataCreditoCliente_F,  A507PropostaSLA,  A508PropostaJurosMora,  A326PropostaValor, out  GXt_decimal1) ;
            A514PropostaValorJurosMora_F = GXt_decimal1;
            /* Using cursor BC001A89 */
            pr_default.execute(42, new Object[] {n328PropostaCratedBy, A328PropostaCratedBy});
            A512PropostaSecUserName = BC001A89_A512PropostaSecUserName[0];
            n512PropostaSecUserName = BC001A89_n512PropostaSecUserName[0];
            pr_default.close(42);
            /* Using cursor BC001A92 */
            pr_default.execute(43, new Object[] {n328PropostaCratedBy, A328PropostaCratedBy, n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(43) != 101) )
            {
               A511PropostaValorTaxaRecebida_F = BC001A92_A511PropostaValorTaxaRecebida_F[0];
               n511PropostaValorTaxaRecebida_F = BC001A92_n511PropostaValorTaxaRecebida_F[0];
            }
            else
            {
               A511PropostaValorTaxaRecebida_F = 0;
               n511PropostaValorTaxaRecebida_F = false;
            }
            pr_default.close(43);
            /* Using cursor BC001A93 */
            pr_default.execute(44, new Object[] {n642PropostaClinicaId, A642PropostaClinicaId});
            A643PropostaClinicaNome = BC001A93_A643PropostaClinicaNome[0];
            n643PropostaClinicaNome = BC001A93_n643PropostaClinicaNome[0];
            A644PropostaClinicaNomeFantasia = BC001A93_A644PropostaClinicaNomeFantasia[0];
            n644PropostaClinicaNomeFantasia = BC001A93_n644PropostaClinicaNomeFantasia[0];
            A652PropostaClinicaDocumento = BC001A93_A652PropostaClinicaDocumento[0];
            n652PropostaClinicaDocumento = BC001A93_n652PropostaClinicaDocumento[0];
            A653PropostaClinicaEmail = BC001A93_A653PropostaClinicaEmail[0];
            n653PropostaClinicaEmail = BC001A93_n653PropostaClinicaEmail[0];
            pr_default.close(44);
            /* Using cursor BC001A95 */
            pr_default.execute(45, new Object[] {n323PropostaId, A323PropostaId, n642PropostaClinicaId, A642PropostaClinicaId});
            if ( (pr_default.getStatus(45) != 101) )
            {
               A650PropostaValorTaxaClinica_F = BC001A95_A650PropostaValorTaxaClinica_F[0];
               n650PropostaValorTaxaClinica_F = BC001A95_n650PropostaValorTaxaClinica_F[0];
            }
            else
            {
               A650PropostaValorTaxaClinica_F = 0;
               n650PropostaValorTaxaClinica_F = false;
            }
            pr_default.close(45);
            A343PropostaAprovacoesRestantes_F = (short)(A330PropostaQuantidadeAprovadores-A341PropostaAprovacoes_F);
            /* Using cursor BC001A96 */
            pr_default.execute(46, new Object[] {n227ContratoId, A227ContratoId});
            A228ContratoNome = BC001A96_A228ContratoNome[0];
            n228ContratoNome = BC001A96_n228ContratoNome[0];
            pr_default.close(46);
            /* Using cursor BC001A97 */
            pr_default.execute(47, new Object[] {n493ConvenioCategoriaId, A493ConvenioCategoriaId});
            A494ConvenioCategoriaDescricao = BC001A97_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = BC001A97_n494ConvenioCategoriaDescricao[0];
            A410ConvenioId = BC001A97_A410ConvenioId[0];
            n410ConvenioId = BC001A97_n410ConvenioId[0];
            pr_default.close(47);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC001A98 */
            pr_default.execute(48, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(48) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Contrato"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(48);
            /* Using cursor BC001A99 */
            pr_default.execute(49, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(49) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Reembolso"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(49);
            /* Using cursor BC001A100 */
            pr_default.execute(50, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(50) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Titulo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(50);
            /* Using cursor BC001A101 */
            pr_default.execute(51, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(51) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"NotaFiscalItem"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(51);
            /* Using cursor BC001A102 */
            pr_default.execute(52, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(52) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"PropostaContratoAssinatura"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(52);
            /* Using cursor BC001A103 */
            pr_default.execute(53, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(53) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"PropostaDocumentos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(53);
            /* Using cursor BC001A104 */
            pr_default.execute(54, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(54) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Aprovacao"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(54);
         }
      }

      protected void EndLevel1A49( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1A49( ) ;
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

      public void ScanKeyStart1A49( )
      {
         /* Scan By routine */
         /* Using cursor BC001A115 */
         pr_default.execute(55, new Object[] {n323PropostaId, A323PropostaId});
         RcdFound49 = 0;
         if ( (pr_default.getStatus(55) != 101) )
         {
            RcdFound49 = 1;
            A323PropostaId = BC001A115_A323PropostaId[0];
            n323PropostaId = BC001A115_n323PropostaId[0];
            A327PropostaCreatedAt = BC001A115_A327PropostaCreatedAt[0];
            n327PropostaCreatedAt = BC001A115_n327PropostaCreatedAt[0];
            A853PropostaProtocolo = BC001A115_A853PropostaProtocolo[0];
            n853PropostaProtocolo = BC001A115_n853PropostaProtocolo[0];
            A849PropostaTipoProposta = BC001A115_A849PropostaTipoProposta[0];
            n849PropostaTipoProposta = BC001A115_n849PropostaTipoProposta[0];
            A580PropostaResponsavelDocumento = BC001A115_A580PropostaResponsavelDocumento[0];
            n580PropostaResponsavelDocumento = BC001A115_n580PropostaResponsavelDocumento[0];
            A581PropostaResponsavelRazaoSocial = BC001A115_A581PropostaResponsavelRazaoSocial[0];
            n581PropostaResponsavelRazaoSocial = BC001A115_n581PropostaResponsavelRazaoSocial[0];
            A582PropostaResponsavelEmail = BC001A115_A582PropostaResponsavelEmail[0];
            n582PropostaResponsavelEmail = BC001A115_n582PropostaResponsavelEmail[0];
            A590PropostaResponsavelConta = BC001A115_A590PropostaResponsavelConta[0];
            n590PropostaResponsavelConta = BC001A115_n590PropostaResponsavelConta[0];
            A591PropostaResponsavelAgencia = BC001A115_A591PropostaResponsavelAgencia[0];
            n591PropostaResponsavelAgencia = BC001A115_n591PropostaResponsavelAgencia[0];
            A592PropostaResponsavelTipoPix = BC001A115_A592PropostaResponsavelTipoPix[0];
            n592PropostaResponsavelTipoPix = BC001A115_n592PropostaResponsavelTipoPix[0];
            A593PropostaResponsavelPIX = BC001A115_A593PropostaResponsavelPIX[0];
            n593PropostaResponsavelPIX = BC001A115_n593PropostaResponsavelPIX[0];
            A594PropostaResponsavelDepositoTipo = BC001A115_A594PropostaResponsavelDepositoTipo[0];
            n594PropostaResponsavelDepositoTipo = BC001A115_n594PropostaResponsavelDepositoTipo[0];
            A505PropostaPacienteClienteRazaoSocial = BC001A115_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = BC001A115_n505PropostaPacienteClienteRazaoSocial[0];
            A540PropostaPacienteClienteDocumento = BC001A115_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = BC001A115_n540PropostaPacienteClienteDocumento[0];
            A541PropostaPacienteContatoEmail = BC001A115_A541PropostaPacienteContatoEmail[0];
            n541PropostaPacienteContatoEmail = BC001A115_n541PropostaPacienteContatoEmail[0];
            A584PropostaPacienteConta = BC001A115_A584PropostaPacienteConta[0];
            n584PropostaPacienteConta = BC001A115_n584PropostaPacienteConta[0];
            A585PropostaPacienteAgencia = BC001A115_A585PropostaPacienteAgencia[0];
            n585PropostaPacienteAgencia = BC001A115_n585PropostaPacienteAgencia[0];
            A586PropostaPacienteTipoPix = BC001A115_A586PropostaPacienteTipoPix[0];
            n586PropostaPacienteTipoPix = BC001A115_n586PropostaPacienteTipoPix[0];
            A587PropostaPacientePIX = BC001A115_A587PropostaPacientePIX[0];
            n587PropostaPacientePIX = BC001A115_n587PropostaPacientePIX[0];
            A588PropostaPacienteDepositoTipo = BC001A115_A588PropostaPacienteDepositoTipo[0];
            n588PropostaPacienteDepositoTipo = BC001A115_n588PropostaPacienteDepositoTipo[0];
            A620PropostaPacienteEnderecoCEP = BC001A115_A620PropostaPacienteEnderecoCEP[0];
            n620PropostaPacienteEnderecoCEP = BC001A115_n620PropostaPacienteEnderecoCEP[0];
            A621PropostaPacienteEnderecoLogradouro = BC001A115_A621PropostaPacienteEnderecoLogradouro[0];
            n621PropostaPacienteEnderecoLogradouro = BC001A115_n621PropostaPacienteEnderecoLogradouro[0];
            A622PropostaPacienteEnderecoNumero = BC001A115_A622PropostaPacienteEnderecoNumero[0];
            n622PropostaPacienteEnderecoNumero = BC001A115_n622PropostaPacienteEnderecoNumero[0];
            A623PropostaPacienteEnderecoComplemento = BC001A115_A623PropostaPacienteEnderecoComplemento[0];
            n623PropostaPacienteEnderecoComplemento = BC001A115_n623PropostaPacienteEnderecoComplemento[0];
            A624PropostaPacienteEnderecoBairro = BC001A115_A624PropostaPacienteEnderecoBairro[0];
            n624PropostaPacienteEnderecoBairro = BC001A115_n624PropostaPacienteEnderecoBairro[0];
            A324PropostaTitulo = BC001A115_A324PropostaTitulo[0];
            n324PropostaTitulo = BC001A115_n324PropostaTitulo[0];
            A325PropostaDescricao = BC001A115_A325PropostaDescricao[0];
            n325PropostaDescricao = BC001A115_n325PropostaDescricao[0];
            A517PropostaDataCirurgia = BC001A115_A517PropostaDataCirurgia[0];
            n517PropostaDataCirurgia = BC001A115_n517PropostaDataCirurgia[0];
            A326PropostaValor = BC001A115_A326PropostaValor[0];
            n326PropostaValor = BC001A115_n326PropostaValor[0];
            A855PropostaValorLiquido = BC001A115_A855PropostaValorLiquido[0];
            n855PropostaValorLiquido = BC001A115_n855PropostaValorLiquido[0];
            A501PropostaTaxaAdministrativa = BC001A115_A501PropostaTaxaAdministrativa[0];
            n501PropostaTaxaAdministrativa = BC001A115_n501PropostaTaxaAdministrativa[0];
            A507PropostaSLA = BC001A115_A507PropostaSLA[0];
            n507PropostaSLA = BC001A115_n507PropostaSLA[0];
            A508PropostaJurosMora = BC001A115_A508PropostaJurosMora[0];
            n508PropostaJurosMora = BC001A115_n508PropostaJurosMora[0];
            A643PropostaClinicaNome = BC001A115_A643PropostaClinicaNome[0];
            n643PropostaClinicaNome = BC001A115_n643PropostaClinicaNome[0];
            A644PropostaClinicaNomeFantasia = BC001A115_A644PropostaClinicaNomeFantasia[0];
            n644PropostaClinicaNomeFantasia = BC001A115_n644PropostaClinicaNomeFantasia[0];
            A652PropostaClinicaDocumento = BC001A115_A652PropostaClinicaDocumento[0];
            n652PropostaClinicaDocumento = BC001A115_n652PropostaClinicaDocumento[0];
            A653PropostaClinicaEmail = BC001A115_A653PropostaClinicaEmail[0];
            n653PropostaClinicaEmail = BC001A115_n653PropostaClinicaEmail[0];
            A512PropostaSecUserName = BC001A115_A512PropostaSecUserName[0];
            n512PropostaSecUserName = BC001A115_n512PropostaSecUserName[0];
            A329PropostaStatus = BC001A115_A329PropostaStatus[0];
            n329PropostaStatus = BC001A115_n329PropostaStatus[0];
            A790PropostaComentarioAnalise = BC001A115_A790PropostaComentarioAnalise[0];
            n790PropostaComentarioAnalise = BC001A115_n790PropostaComentarioAnalise[0];
            A330PropostaQuantidadeAprovadores = BC001A115_A330PropostaQuantidadeAprovadores[0];
            n330PropostaQuantidadeAprovadores = BC001A115_n330PropostaQuantidadeAprovadores[0];
            A345PropostaReprovacoesPermitidas = BC001A115_A345PropostaReprovacoesPermitidas[0];
            n345PropostaReprovacoesPermitidas = BC001A115_n345PropostaReprovacoesPermitidas[0];
            A228ContratoNome = BC001A115_A228ContratoNome[0];
            n228ContratoNome = BC001A115_n228ContratoNome[0];
            A496ConvenioVencimentoAno = BC001A115_A496ConvenioVencimentoAno[0];
            n496ConvenioVencimentoAno = BC001A115_n496ConvenioVencimentoAno[0];
            A497ConvenioVencimentoMes = BC001A115_A497ConvenioVencimentoMes[0];
            n497ConvenioVencimentoMes = BC001A115_n497ConvenioVencimentoMes[0];
            A494ConvenioCategoriaDescricao = BC001A115_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = BC001A115_n494ConvenioCategoriaDescricao[0];
            A227ContratoId = BC001A115_A227ContratoId[0];
            n227ContratoId = BC001A115_n227ContratoId[0];
            A376ProcedimentosMedicosId = BC001A115_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = BC001A115_n376ProcedimentosMedicosId[0];
            A493ConvenioCategoriaId = BC001A115_A493ConvenioCategoriaId[0];
            n493ConvenioCategoriaId = BC001A115_n493ConvenioCategoriaId[0];
            A328PropostaCratedBy = BC001A115_A328PropostaCratedBy[0];
            n328PropostaCratedBy = BC001A115_n328PropostaCratedBy[0];
            A504PropostaPacienteClienteId = BC001A115_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = BC001A115_n504PropostaPacienteClienteId[0];
            A553PropostaResponsavelId = BC001A115_A553PropostaResponsavelId[0];
            n553PropostaResponsavelId = BC001A115_n553PropostaResponsavelId[0];
            A642PropostaClinicaId = BC001A115_A642PropostaClinicaId[0];
            n642PropostaClinicaId = BC001A115_n642PropostaClinicaId[0];
            A850PropostaEmpresaClienteId = BC001A115_A850PropostaEmpresaClienteId[0];
            n850PropostaEmpresaClienteId = BC001A115_n850PropostaEmpresaClienteId[0];
            A410ConvenioId = BC001A115_A410ConvenioId[0];
            n410ConvenioId = BC001A115_n410ConvenioId[0];
            A625PropostaPacienteMunicipioCodigo = BC001A115_A625PropostaPacienteMunicipioCodigo[0];
            n625PropostaPacienteMunicipioCodigo = BC001A115_n625PropostaPacienteMunicipioCodigo[0];
            A649PropostaMaxReembolsoId_F = BC001A115_A649PropostaMaxReembolsoId_F[0];
            n649PropostaMaxReembolsoId_F = BC001A115_n649PropostaMaxReembolsoId_F[0];
            A854PropostaQtdItensNota_F = BC001A115_A854PropostaQtdItensNota_F[0];
            n854PropostaQtdItensNota_F = BC001A115_n854PropostaQtdItensNota_F[0];
            A733PropostaResponsavelSerasaConsultas_F = BC001A115_A733PropostaResponsavelSerasaConsultas_F[0];
            n733PropostaResponsavelSerasaConsultas_F = BC001A115_n733PropostaResponsavelSerasaConsultas_F[0];
            A783PropostaResponsavelSerasaScoreUltimaData_F = BC001A115_A783PropostaResponsavelSerasaScoreUltimaData_F[0];
            n783PropostaResponsavelSerasaScoreUltimaData_F = BC001A115_n783PropostaResponsavelSerasaScoreUltimaData_F[0];
            A786PropostaResponsavelSerasaUltimoValorRecomendado_F = BC001A115_A786PropostaResponsavelSerasaUltimoValorRecomendado_F[0];
            n786PropostaResponsavelSerasaUltimoValorRecomendado_F = BC001A115_n786PropostaResponsavelSerasaUltimoValorRecomendado_F[0];
            A734PropostaPacienteSerasaConsultas_F = BC001A115_A734PropostaPacienteSerasaConsultas_F[0];
            n734PropostaPacienteSerasaConsultas_F = BC001A115_n734PropostaPacienteSerasaConsultas_F[0];
            A782PropostaSerasaScoreUltimaData_F = BC001A115_A782PropostaSerasaScoreUltimaData_F[0];
            n782PropostaSerasaScoreUltimaData_F = BC001A115_n782PropostaSerasaScoreUltimaData_F[0];
            A787PropostaPacienteSerasaUltimoValorRecomendado_F = BC001A115_A787PropostaPacienteSerasaUltimoValorRecomendado_F[0];
            n787PropostaPacienteSerasaUltimoValorRecomendado_F = BC001A115_n787PropostaPacienteSerasaUltimoValorRecomendado_F[0];
            A655PropostaQtdDocumentoPendente_F = BC001A115_A655PropostaQtdDocumentoPendente_F[0];
            n655PropostaQtdDocumentoPendente_F = BC001A115_n655PropostaQtdDocumentoPendente_F[0];
            A341PropostaAprovacoes_F = BC001A115_A341PropostaAprovacoes_F[0];
            n341PropostaAprovacoes_F = BC001A115_n341PropostaAprovacoes_F[0];
            A342PropostaReprovacoes_F = BC001A115_A342PropostaReprovacoes_F[0];
            n342PropostaReprovacoes_F = BC001A115_n342PropostaReprovacoes_F[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1A49( )
      {
         /* Scan next routine */
         pr_default.readNext(55);
         RcdFound49 = 0;
         ScanKeyLoad1A49( ) ;
      }

      protected void ScanKeyLoad1A49( )
      {
         sMode49 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(55) != 101) )
         {
            RcdFound49 = 1;
            A323PropostaId = BC001A115_A323PropostaId[0];
            n323PropostaId = BC001A115_n323PropostaId[0];
            A327PropostaCreatedAt = BC001A115_A327PropostaCreatedAt[0];
            n327PropostaCreatedAt = BC001A115_n327PropostaCreatedAt[0];
            A853PropostaProtocolo = BC001A115_A853PropostaProtocolo[0];
            n853PropostaProtocolo = BC001A115_n853PropostaProtocolo[0];
            A849PropostaTipoProposta = BC001A115_A849PropostaTipoProposta[0];
            n849PropostaTipoProposta = BC001A115_n849PropostaTipoProposta[0];
            A580PropostaResponsavelDocumento = BC001A115_A580PropostaResponsavelDocumento[0];
            n580PropostaResponsavelDocumento = BC001A115_n580PropostaResponsavelDocumento[0];
            A581PropostaResponsavelRazaoSocial = BC001A115_A581PropostaResponsavelRazaoSocial[0];
            n581PropostaResponsavelRazaoSocial = BC001A115_n581PropostaResponsavelRazaoSocial[0];
            A582PropostaResponsavelEmail = BC001A115_A582PropostaResponsavelEmail[0];
            n582PropostaResponsavelEmail = BC001A115_n582PropostaResponsavelEmail[0];
            A590PropostaResponsavelConta = BC001A115_A590PropostaResponsavelConta[0];
            n590PropostaResponsavelConta = BC001A115_n590PropostaResponsavelConta[0];
            A591PropostaResponsavelAgencia = BC001A115_A591PropostaResponsavelAgencia[0];
            n591PropostaResponsavelAgencia = BC001A115_n591PropostaResponsavelAgencia[0];
            A592PropostaResponsavelTipoPix = BC001A115_A592PropostaResponsavelTipoPix[0];
            n592PropostaResponsavelTipoPix = BC001A115_n592PropostaResponsavelTipoPix[0];
            A593PropostaResponsavelPIX = BC001A115_A593PropostaResponsavelPIX[0];
            n593PropostaResponsavelPIX = BC001A115_n593PropostaResponsavelPIX[0];
            A594PropostaResponsavelDepositoTipo = BC001A115_A594PropostaResponsavelDepositoTipo[0];
            n594PropostaResponsavelDepositoTipo = BC001A115_n594PropostaResponsavelDepositoTipo[0];
            A505PropostaPacienteClienteRazaoSocial = BC001A115_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = BC001A115_n505PropostaPacienteClienteRazaoSocial[0];
            A540PropostaPacienteClienteDocumento = BC001A115_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = BC001A115_n540PropostaPacienteClienteDocumento[0];
            A541PropostaPacienteContatoEmail = BC001A115_A541PropostaPacienteContatoEmail[0];
            n541PropostaPacienteContatoEmail = BC001A115_n541PropostaPacienteContatoEmail[0];
            A584PropostaPacienteConta = BC001A115_A584PropostaPacienteConta[0];
            n584PropostaPacienteConta = BC001A115_n584PropostaPacienteConta[0];
            A585PropostaPacienteAgencia = BC001A115_A585PropostaPacienteAgencia[0];
            n585PropostaPacienteAgencia = BC001A115_n585PropostaPacienteAgencia[0];
            A586PropostaPacienteTipoPix = BC001A115_A586PropostaPacienteTipoPix[0];
            n586PropostaPacienteTipoPix = BC001A115_n586PropostaPacienteTipoPix[0];
            A587PropostaPacientePIX = BC001A115_A587PropostaPacientePIX[0];
            n587PropostaPacientePIX = BC001A115_n587PropostaPacientePIX[0];
            A588PropostaPacienteDepositoTipo = BC001A115_A588PropostaPacienteDepositoTipo[0];
            n588PropostaPacienteDepositoTipo = BC001A115_n588PropostaPacienteDepositoTipo[0];
            A620PropostaPacienteEnderecoCEP = BC001A115_A620PropostaPacienteEnderecoCEP[0];
            n620PropostaPacienteEnderecoCEP = BC001A115_n620PropostaPacienteEnderecoCEP[0];
            A621PropostaPacienteEnderecoLogradouro = BC001A115_A621PropostaPacienteEnderecoLogradouro[0];
            n621PropostaPacienteEnderecoLogradouro = BC001A115_n621PropostaPacienteEnderecoLogradouro[0];
            A622PropostaPacienteEnderecoNumero = BC001A115_A622PropostaPacienteEnderecoNumero[0];
            n622PropostaPacienteEnderecoNumero = BC001A115_n622PropostaPacienteEnderecoNumero[0];
            A623PropostaPacienteEnderecoComplemento = BC001A115_A623PropostaPacienteEnderecoComplemento[0];
            n623PropostaPacienteEnderecoComplemento = BC001A115_n623PropostaPacienteEnderecoComplemento[0];
            A624PropostaPacienteEnderecoBairro = BC001A115_A624PropostaPacienteEnderecoBairro[0];
            n624PropostaPacienteEnderecoBairro = BC001A115_n624PropostaPacienteEnderecoBairro[0];
            A324PropostaTitulo = BC001A115_A324PropostaTitulo[0];
            n324PropostaTitulo = BC001A115_n324PropostaTitulo[0];
            A325PropostaDescricao = BC001A115_A325PropostaDescricao[0];
            n325PropostaDescricao = BC001A115_n325PropostaDescricao[0];
            A517PropostaDataCirurgia = BC001A115_A517PropostaDataCirurgia[0];
            n517PropostaDataCirurgia = BC001A115_n517PropostaDataCirurgia[0];
            A326PropostaValor = BC001A115_A326PropostaValor[0];
            n326PropostaValor = BC001A115_n326PropostaValor[0];
            A855PropostaValorLiquido = BC001A115_A855PropostaValorLiquido[0];
            n855PropostaValorLiquido = BC001A115_n855PropostaValorLiquido[0];
            A501PropostaTaxaAdministrativa = BC001A115_A501PropostaTaxaAdministrativa[0];
            n501PropostaTaxaAdministrativa = BC001A115_n501PropostaTaxaAdministrativa[0];
            A507PropostaSLA = BC001A115_A507PropostaSLA[0];
            n507PropostaSLA = BC001A115_n507PropostaSLA[0];
            A508PropostaJurosMora = BC001A115_A508PropostaJurosMora[0];
            n508PropostaJurosMora = BC001A115_n508PropostaJurosMora[0];
            A643PropostaClinicaNome = BC001A115_A643PropostaClinicaNome[0];
            n643PropostaClinicaNome = BC001A115_n643PropostaClinicaNome[0];
            A644PropostaClinicaNomeFantasia = BC001A115_A644PropostaClinicaNomeFantasia[0];
            n644PropostaClinicaNomeFantasia = BC001A115_n644PropostaClinicaNomeFantasia[0];
            A652PropostaClinicaDocumento = BC001A115_A652PropostaClinicaDocumento[0];
            n652PropostaClinicaDocumento = BC001A115_n652PropostaClinicaDocumento[0];
            A653PropostaClinicaEmail = BC001A115_A653PropostaClinicaEmail[0];
            n653PropostaClinicaEmail = BC001A115_n653PropostaClinicaEmail[0];
            A512PropostaSecUserName = BC001A115_A512PropostaSecUserName[0];
            n512PropostaSecUserName = BC001A115_n512PropostaSecUserName[0];
            A329PropostaStatus = BC001A115_A329PropostaStatus[0];
            n329PropostaStatus = BC001A115_n329PropostaStatus[0];
            A790PropostaComentarioAnalise = BC001A115_A790PropostaComentarioAnalise[0];
            n790PropostaComentarioAnalise = BC001A115_n790PropostaComentarioAnalise[0];
            A330PropostaQuantidadeAprovadores = BC001A115_A330PropostaQuantidadeAprovadores[0];
            n330PropostaQuantidadeAprovadores = BC001A115_n330PropostaQuantidadeAprovadores[0];
            A345PropostaReprovacoesPermitidas = BC001A115_A345PropostaReprovacoesPermitidas[0];
            n345PropostaReprovacoesPermitidas = BC001A115_n345PropostaReprovacoesPermitidas[0];
            A228ContratoNome = BC001A115_A228ContratoNome[0];
            n228ContratoNome = BC001A115_n228ContratoNome[0];
            A496ConvenioVencimentoAno = BC001A115_A496ConvenioVencimentoAno[0];
            n496ConvenioVencimentoAno = BC001A115_n496ConvenioVencimentoAno[0];
            A497ConvenioVencimentoMes = BC001A115_A497ConvenioVencimentoMes[0];
            n497ConvenioVencimentoMes = BC001A115_n497ConvenioVencimentoMes[0];
            A494ConvenioCategoriaDescricao = BC001A115_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = BC001A115_n494ConvenioCategoriaDescricao[0];
            A227ContratoId = BC001A115_A227ContratoId[0];
            n227ContratoId = BC001A115_n227ContratoId[0];
            A376ProcedimentosMedicosId = BC001A115_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = BC001A115_n376ProcedimentosMedicosId[0];
            A493ConvenioCategoriaId = BC001A115_A493ConvenioCategoriaId[0];
            n493ConvenioCategoriaId = BC001A115_n493ConvenioCategoriaId[0];
            A328PropostaCratedBy = BC001A115_A328PropostaCratedBy[0];
            n328PropostaCratedBy = BC001A115_n328PropostaCratedBy[0];
            A504PropostaPacienteClienteId = BC001A115_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = BC001A115_n504PropostaPacienteClienteId[0];
            A553PropostaResponsavelId = BC001A115_A553PropostaResponsavelId[0];
            n553PropostaResponsavelId = BC001A115_n553PropostaResponsavelId[0];
            A642PropostaClinicaId = BC001A115_A642PropostaClinicaId[0];
            n642PropostaClinicaId = BC001A115_n642PropostaClinicaId[0];
            A850PropostaEmpresaClienteId = BC001A115_A850PropostaEmpresaClienteId[0];
            n850PropostaEmpresaClienteId = BC001A115_n850PropostaEmpresaClienteId[0];
            A410ConvenioId = BC001A115_A410ConvenioId[0];
            n410ConvenioId = BC001A115_n410ConvenioId[0];
            A625PropostaPacienteMunicipioCodigo = BC001A115_A625PropostaPacienteMunicipioCodigo[0];
            n625PropostaPacienteMunicipioCodigo = BC001A115_n625PropostaPacienteMunicipioCodigo[0];
            A649PropostaMaxReembolsoId_F = BC001A115_A649PropostaMaxReembolsoId_F[0];
            n649PropostaMaxReembolsoId_F = BC001A115_n649PropostaMaxReembolsoId_F[0];
            A854PropostaQtdItensNota_F = BC001A115_A854PropostaQtdItensNota_F[0];
            n854PropostaQtdItensNota_F = BC001A115_n854PropostaQtdItensNota_F[0];
            A733PropostaResponsavelSerasaConsultas_F = BC001A115_A733PropostaResponsavelSerasaConsultas_F[0];
            n733PropostaResponsavelSerasaConsultas_F = BC001A115_n733PropostaResponsavelSerasaConsultas_F[0];
            A783PropostaResponsavelSerasaScoreUltimaData_F = BC001A115_A783PropostaResponsavelSerasaScoreUltimaData_F[0];
            n783PropostaResponsavelSerasaScoreUltimaData_F = BC001A115_n783PropostaResponsavelSerasaScoreUltimaData_F[0];
            A786PropostaResponsavelSerasaUltimoValorRecomendado_F = BC001A115_A786PropostaResponsavelSerasaUltimoValorRecomendado_F[0];
            n786PropostaResponsavelSerasaUltimoValorRecomendado_F = BC001A115_n786PropostaResponsavelSerasaUltimoValorRecomendado_F[0];
            A734PropostaPacienteSerasaConsultas_F = BC001A115_A734PropostaPacienteSerasaConsultas_F[0];
            n734PropostaPacienteSerasaConsultas_F = BC001A115_n734PropostaPacienteSerasaConsultas_F[0];
            A782PropostaSerasaScoreUltimaData_F = BC001A115_A782PropostaSerasaScoreUltimaData_F[0];
            n782PropostaSerasaScoreUltimaData_F = BC001A115_n782PropostaSerasaScoreUltimaData_F[0];
            A787PropostaPacienteSerasaUltimoValorRecomendado_F = BC001A115_A787PropostaPacienteSerasaUltimoValorRecomendado_F[0];
            n787PropostaPacienteSerasaUltimoValorRecomendado_F = BC001A115_n787PropostaPacienteSerasaUltimoValorRecomendado_F[0];
            A655PropostaQtdDocumentoPendente_F = BC001A115_A655PropostaQtdDocumentoPendente_F[0];
            n655PropostaQtdDocumentoPendente_F = BC001A115_n655PropostaQtdDocumentoPendente_F[0];
            A341PropostaAprovacoes_F = BC001A115_A341PropostaAprovacoes_F[0];
            n341PropostaAprovacoes_F = BC001A115_n341PropostaAprovacoes_F[0];
            A342PropostaReprovacoes_F = BC001A115_A342PropostaReprovacoes_F[0];
            n342PropostaReprovacoes_F = BC001A115_n342PropostaReprovacoes_F[0];
         }
         Gx_mode = sMode49;
      }

      protected void ScanKeyEnd1A49( )
      {
         pr_default.close(55);
      }

      protected void AfterConfirm1A49( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1A49( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1A49( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1A49( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1A49( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1A49( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1A49( )
      {
      }

      protected void send_integrity_lvl_hashes1A49( )
      {
      }

      protected void AddRow1A49( )
      {
         VarsToRow49( bcProposta) ;
      }

      protected void ReadRow1A49( )
      {
         RowToVars49( bcProposta, 1) ;
      }

      protected void InitializeNonKey1A49( )
      {
         A327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         n327PropostaCreatedAt = false;
         A343PropostaAprovacoesRestantes_F = 0;
         A513PropostaValorTaxa_F = 0;
         A514PropostaValorJurosMora_F = 0;
         A575PropostaTaxa_F = 0;
         A788PropostaMaiorValorRecomendado = 0;
         A784PropostaMaiorScore_F = 0;
         A509PropostaValorReembolsado_F = 0;
         n509PropostaValorReembolsado_F = false;
         A510PropostaValorReembolsadoJuros_F = 0;
         n510PropostaValorReembolsadoJuros_F = false;
         A511PropostaValorTaxaRecebida_F = 0;
         n511PropostaValorTaxaRecebida_F = false;
         A515PropostaDataCreditoCliente_F = DateTime.MinValue;
         n515PropostaDataCreditoCliente_F = false;
         A650PropostaValorTaxaClinica_F = 0;
         n650PropostaValorTaxaClinica_F = false;
         A649PropostaMaxReembolsoId_F = 0;
         n649PropostaMaxReembolsoId_F = false;
         A853PropostaProtocolo = "";
         n853PropostaProtocolo = false;
         A850PropostaEmpresaClienteId = 0;
         n850PropostaEmpresaClienteId = false;
         A849PropostaTipoProposta = "";
         n849PropostaTipoProposta = false;
         A504PropostaPacienteClienteId = 0;
         n504PropostaPacienteClienteId = false;
         A854PropostaQtdItensNota_F = 0;
         n854PropostaQtdItensNota_F = false;
         A553PropostaResponsavelId = 0;
         n553PropostaResponsavelId = false;
         A580PropostaResponsavelDocumento = "";
         n580PropostaResponsavelDocumento = false;
         A581PropostaResponsavelRazaoSocial = "";
         n581PropostaResponsavelRazaoSocial = false;
         A582PropostaResponsavelEmail = "";
         n582PropostaResponsavelEmail = false;
         A589PropostaResponsavelBanco = "";
         A590PropostaResponsavelConta = "";
         n590PropostaResponsavelConta = false;
         A591PropostaResponsavelAgencia = "";
         n591PropostaResponsavelAgencia = false;
         A592PropostaResponsavelTipoPix = "";
         n592PropostaResponsavelTipoPix = false;
         A593PropostaResponsavelPIX = "";
         n593PropostaResponsavelPIX = false;
         A594PropostaResponsavelDepositoTipo = "";
         n594PropostaResponsavelDepositoTipo = false;
         A733PropostaResponsavelSerasaConsultas_F = 0;
         n733PropostaResponsavelSerasaConsultas_F = false;
         A783PropostaResponsavelSerasaScoreUltimaData_F = 0;
         n783PropostaResponsavelSerasaScoreUltimaData_F = false;
         A786PropostaResponsavelSerasaUltimoValorRecomendado_F = 0;
         n786PropostaResponsavelSerasaUltimoValorRecomendado_F = false;
         A505PropostaPacienteClienteRazaoSocial = "";
         n505PropostaPacienteClienteRazaoSocial = false;
         A540PropostaPacienteClienteDocumento = "";
         n540PropostaPacienteClienteDocumento = false;
         A541PropostaPacienteContatoEmail = "";
         n541PropostaPacienteContatoEmail = false;
         A583PropostaPacienteBanco = "";
         A584PropostaPacienteConta = "";
         n584PropostaPacienteConta = false;
         A585PropostaPacienteAgencia = "";
         n585PropostaPacienteAgencia = false;
         A586PropostaPacienteTipoPix = "";
         n586PropostaPacienteTipoPix = false;
         A587PropostaPacientePIX = "";
         n587PropostaPacientePIX = false;
         A588PropostaPacienteDepositoTipo = "";
         n588PropostaPacienteDepositoTipo = false;
         A620PropostaPacienteEnderecoCEP = "";
         n620PropostaPacienteEnderecoCEP = false;
         A621PropostaPacienteEnderecoLogradouro = "";
         n621PropostaPacienteEnderecoLogradouro = false;
         A622PropostaPacienteEnderecoNumero = "";
         n622PropostaPacienteEnderecoNumero = false;
         A623PropostaPacienteEnderecoComplemento = "";
         n623PropostaPacienteEnderecoComplemento = false;
         A624PropostaPacienteEnderecoBairro = "";
         n624PropostaPacienteEnderecoBairro = false;
         A625PropostaPacienteMunicipioCodigo = "";
         n625PropostaPacienteMunicipioCodigo = false;
         A734PropostaPacienteSerasaConsultas_F = 0;
         n734PropostaPacienteSerasaConsultas_F = false;
         A782PropostaSerasaScoreUltimaData_F = 0;
         n782PropostaSerasaScoreUltimaData_F = false;
         A787PropostaPacienteSerasaUltimoValorRecomendado_F = 0;
         n787PropostaPacienteSerasaUltimoValorRecomendado_F = false;
         A655PropostaQtdDocumentoPendente_F = 0;
         n655PropostaQtdDocumentoPendente_F = false;
         A324PropostaTitulo = "";
         n324PropostaTitulo = false;
         A376ProcedimentosMedicosId = 0;
         n376ProcedimentosMedicosId = false;
         A325PropostaDescricao = "";
         n325PropostaDescricao = false;
         A517PropostaDataCirurgia = DateTime.MinValue;
         n517PropostaDataCirurgia = false;
         A326PropostaValor = 0;
         n326PropostaValor = false;
         A855PropostaValorLiquido = 0;
         n855PropostaValorLiquido = false;
         A501PropostaTaxaAdministrativa = 0;
         n501PropostaTaxaAdministrativa = false;
         A507PropostaSLA = 0;
         n507PropostaSLA = false;
         A508PropostaJurosMora = 0;
         n508PropostaJurosMora = false;
         A328PropostaCratedBy = 0;
         n328PropostaCratedBy = false;
         A642PropostaClinicaId = 0;
         n642PropostaClinicaId = false;
         A643PropostaClinicaNome = "";
         n643PropostaClinicaNome = false;
         A644PropostaClinicaNomeFantasia = "";
         n644PropostaClinicaNomeFantasia = false;
         A652PropostaClinicaDocumento = "";
         n652PropostaClinicaDocumento = false;
         A653PropostaClinicaEmail = "";
         n653PropostaClinicaEmail = false;
         A512PropostaSecUserName = "";
         n512PropostaSecUserName = false;
         A329PropostaStatus = "";
         n329PropostaStatus = false;
         A790PropostaComentarioAnalise = "";
         n790PropostaComentarioAnalise = false;
         A330PropostaQuantidadeAprovadores = 0;
         n330PropostaQuantidadeAprovadores = false;
         A345PropostaReprovacoesPermitidas = 0;
         n345PropostaReprovacoesPermitidas = false;
         A227ContratoId = 0;
         n227ContratoId = false;
         A228ContratoNome = "";
         n228ContratoNome = false;
         A410ConvenioId = 0;
         n410ConvenioId = false;
         A496ConvenioVencimentoAno = 0;
         n496ConvenioVencimentoAno = false;
         A497ConvenioVencimentoMes = 0;
         n497ConvenioVencimentoMes = false;
         A493ConvenioCategoriaId = 0;
         n493ConvenioCategoriaId = false;
         A494ConvenioCategoriaDescricao = "";
         n494ConvenioCategoriaDescricao = false;
         A341PropostaAprovacoes_F = 0;
         n341PropostaAprovacoes_F = false;
         A342PropostaReprovacoes_F = 0;
         n342PropostaReprovacoes_F = false;
         Z327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         Z853PropostaProtocolo = "";
         Z849PropostaTipoProposta = "";
         Z324PropostaTitulo = "";
         Z325PropostaDescricao = "";
         Z517PropostaDataCirurgia = DateTime.MinValue;
         Z326PropostaValor = 0;
         Z855PropostaValorLiquido = 0;
         Z501PropostaTaxaAdministrativa = 0;
         Z507PropostaSLA = 0;
         Z508PropostaJurosMora = 0;
         Z329PropostaStatus = "";
         Z790PropostaComentarioAnalise = "";
         Z330PropostaQuantidadeAprovadores = 0;
         Z345PropostaReprovacoesPermitidas = 0;
         Z496ConvenioVencimentoAno = 0;
         Z497ConvenioVencimentoMes = 0;
         Z227ContratoId = 0;
         Z376ProcedimentosMedicosId = 0;
         Z493ConvenioCategoriaId = 0;
         Z328PropostaCratedBy = 0;
         Z504PropostaPacienteClienteId = 0;
         Z553PropostaResponsavelId = 0;
         Z642PropostaClinicaId = 0;
         Z850PropostaEmpresaClienteId = 0;
      }

      protected void InitAll1A49( )
      {
         A323PropostaId = 0;
         n323PropostaId = false;
         InitializeNonKey1A49( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A327PropostaCreatedAt = i327PropostaCreatedAt;
         n327PropostaCreatedAt = false;
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

      public void VarsToRow49( SdtProposta obj49 )
      {
         obj49.gxTpr_Mode = Gx_mode;
         obj49.gxTpr_Propostacreatedat = A327PropostaCreatedAt;
         obj49.gxTpr_Propostaaprovacoesrestantes_f = A343PropostaAprovacoesRestantes_F;
         obj49.gxTpr_Propostavalortaxa_f = A513PropostaValorTaxa_F;
         obj49.gxTpr_Propostavalorjurosmora_f = A514PropostaValorJurosMora_F;
         obj49.gxTpr_Propostataxa_f = A575PropostaTaxa_F;
         obj49.gxTpr_Propostamaiorvalorrecomendado = A788PropostaMaiorValorRecomendado;
         obj49.gxTpr_Propostamaiorscore_f = A784PropostaMaiorScore_F;
         obj49.gxTpr_Propostavalorreembolsado_f = A509PropostaValorReembolsado_F;
         obj49.gxTpr_Propostavalorreembolsadojuros_f = A510PropostaValorReembolsadoJuros_F;
         obj49.gxTpr_Propostavalortaxarecebida_f = A511PropostaValorTaxaRecebida_F;
         obj49.gxTpr_Propostadatacreditocliente_f = A515PropostaDataCreditoCliente_F;
         obj49.gxTpr_Propostavalortaxaclinica_f = A650PropostaValorTaxaClinica_F;
         obj49.gxTpr_Propostamaxreembolsoid_f = A649PropostaMaxReembolsoId_F;
         obj49.gxTpr_Propostaprotocolo = A853PropostaProtocolo;
         obj49.gxTpr_Propostaempresaclienteid = A850PropostaEmpresaClienteId;
         obj49.gxTpr_Propostatipoproposta = A849PropostaTipoProposta;
         obj49.gxTpr_Propostapacienteclienteid = A504PropostaPacienteClienteId;
         obj49.gxTpr_Propostaqtditensnota_f = A854PropostaQtdItensNota_F;
         obj49.gxTpr_Propostaresponsavelid = A553PropostaResponsavelId;
         obj49.gxTpr_Propostaresponsaveldocumento = A580PropostaResponsavelDocumento;
         obj49.gxTpr_Propostaresponsavelrazaosocial = A581PropostaResponsavelRazaoSocial;
         obj49.gxTpr_Propostaresponsavelemail = A582PropostaResponsavelEmail;
         obj49.gxTpr_Propostaresponsavelbanco = A589PropostaResponsavelBanco;
         obj49.gxTpr_Propostaresponsavelconta = A590PropostaResponsavelConta;
         obj49.gxTpr_Propostaresponsavelagencia = A591PropostaResponsavelAgencia;
         obj49.gxTpr_Propostaresponsaveltipopix = A592PropostaResponsavelTipoPix;
         obj49.gxTpr_Propostaresponsavelpix = A593PropostaResponsavelPIX;
         obj49.gxTpr_Propostaresponsaveldepositotipo = A594PropostaResponsavelDepositoTipo;
         obj49.gxTpr_Propostaresponsavelserasaconsultas_f = A733PropostaResponsavelSerasaConsultas_F;
         obj49.gxTpr_Propostaresponsavelserasascoreultimadata_f = A783PropostaResponsavelSerasaScoreUltimaData_F;
         obj49.gxTpr_Propostaresponsavelserasaultimovalorrecomendado_f = A786PropostaResponsavelSerasaUltimoValorRecomendado_F;
         obj49.gxTpr_Propostapacienteclienterazaosocial = A505PropostaPacienteClienteRazaoSocial;
         obj49.gxTpr_Propostapacienteclientedocumento = A540PropostaPacienteClienteDocumento;
         obj49.gxTpr_Propostapacientecontatoemail = A541PropostaPacienteContatoEmail;
         obj49.gxTpr_Propostapacientebanco = A583PropostaPacienteBanco;
         obj49.gxTpr_Propostapacienteconta = A584PropostaPacienteConta;
         obj49.gxTpr_Propostapacienteagencia = A585PropostaPacienteAgencia;
         obj49.gxTpr_Propostapacientetipopix = A586PropostaPacienteTipoPix;
         obj49.gxTpr_Propostapacientepix = A587PropostaPacientePIX;
         obj49.gxTpr_Propostapacientedepositotipo = A588PropostaPacienteDepositoTipo;
         obj49.gxTpr_Propostapacienteenderecocep = A620PropostaPacienteEnderecoCEP;
         obj49.gxTpr_Propostapacienteenderecologradouro = A621PropostaPacienteEnderecoLogradouro;
         obj49.gxTpr_Propostapacienteendereconumero = A622PropostaPacienteEnderecoNumero;
         obj49.gxTpr_Propostapacienteenderecocomplemento = A623PropostaPacienteEnderecoComplemento;
         obj49.gxTpr_Propostapacienteenderecobairro = A624PropostaPacienteEnderecoBairro;
         obj49.gxTpr_Propostapacientemunicipiocodigo = A625PropostaPacienteMunicipioCodigo;
         obj49.gxTpr_Propostapacienteserasaconsultas_f = A734PropostaPacienteSerasaConsultas_F;
         obj49.gxTpr_Propostaserasascoreultimadata_f = A782PropostaSerasaScoreUltimaData_F;
         obj49.gxTpr_Propostapacienteserasaultimovalorrecomendado_f = A787PropostaPacienteSerasaUltimoValorRecomendado_F;
         obj49.gxTpr_Propostaqtddocumentopendente_f = A655PropostaQtdDocumentoPendente_F;
         obj49.gxTpr_Propostatitulo = A324PropostaTitulo;
         obj49.gxTpr_Procedimentosmedicosid = A376ProcedimentosMedicosId;
         obj49.gxTpr_Propostadescricao = A325PropostaDescricao;
         obj49.gxTpr_Propostadatacirurgia = A517PropostaDataCirurgia;
         obj49.gxTpr_Propostavalor = A326PropostaValor;
         obj49.gxTpr_Propostavalorliquido = A855PropostaValorLiquido;
         obj49.gxTpr_Propostataxaadministrativa = A501PropostaTaxaAdministrativa;
         obj49.gxTpr_Propostasla = A507PropostaSLA;
         obj49.gxTpr_Propostajurosmora = A508PropostaJurosMora;
         obj49.gxTpr_Propostacratedby = A328PropostaCratedBy;
         obj49.gxTpr_Propostaclinicaid = A642PropostaClinicaId;
         obj49.gxTpr_Propostaclinicanome = A643PropostaClinicaNome;
         obj49.gxTpr_Propostaclinicanomefantasia = A644PropostaClinicaNomeFantasia;
         obj49.gxTpr_Propostaclinicadocumento = A652PropostaClinicaDocumento;
         obj49.gxTpr_Propostaclinicaemail = A653PropostaClinicaEmail;
         obj49.gxTpr_Propostasecusername = A512PropostaSecUserName;
         obj49.gxTpr_Propostastatus = A329PropostaStatus;
         obj49.gxTpr_Propostacomentarioanalise = A790PropostaComentarioAnalise;
         obj49.gxTpr_Propostaquantidadeaprovadores = A330PropostaQuantidadeAprovadores;
         obj49.gxTpr_Propostareprovacoespermitidas = A345PropostaReprovacoesPermitidas;
         obj49.gxTpr_Contratoid = A227ContratoId;
         obj49.gxTpr_Contratonome = A228ContratoNome;
         obj49.gxTpr_Convenioid = A410ConvenioId;
         obj49.gxTpr_Conveniovencimentoano = A496ConvenioVencimentoAno;
         obj49.gxTpr_Conveniovencimentomes = A497ConvenioVencimentoMes;
         obj49.gxTpr_Conveniocategoriaid = A493ConvenioCategoriaId;
         obj49.gxTpr_Conveniocategoriadescricao = A494ConvenioCategoriaDescricao;
         obj49.gxTpr_Propostaaprovacoes_f = A341PropostaAprovacoes_F;
         obj49.gxTpr_Propostareprovacoes_f = A342PropostaReprovacoes_F;
         obj49.gxTpr_Propostaid = A323PropostaId;
         obj49.gxTpr_Propostaid_Z = Z323PropostaId;
         obj49.gxTpr_Propostamaxreembolsoid_f_Z = Z649PropostaMaxReembolsoId_F;
         obj49.gxTpr_Propostaprotocolo_Z = Z853PropostaProtocolo;
         obj49.gxTpr_Propostaempresaclienteid_Z = Z850PropostaEmpresaClienteId;
         obj49.gxTpr_Propostatipoproposta_Z = Z849PropostaTipoProposta;
         obj49.gxTpr_Propostapacienteclienteid_Z = Z504PropostaPacienteClienteId;
         obj49.gxTpr_Propostaqtditensnota_f_Z = Z854PropostaQtdItensNota_F;
         obj49.gxTpr_Propostaresponsavelid_Z = Z553PropostaResponsavelId;
         obj49.gxTpr_Propostaresponsaveldocumento_Z = Z580PropostaResponsavelDocumento;
         obj49.gxTpr_Propostaresponsavelrazaosocial_Z = Z581PropostaResponsavelRazaoSocial;
         obj49.gxTpr_Propostaresponsavelemail_Z = Z582PropostaResponsavelEmail;
         obj49.gxTpr_Propostaresponsavelbanco_Z = Z589PropostaResponsavelBanco;
         obj49.gxTpr_Propostaresponsavelconta_Z = Z590PropostaResponsavelConta;
         obj49.gxTpr_Propostaresponsavelagencia_Z = Z591PropostaResponsavelAgencia;
         obj49.gxTpr_Propostaresponsaveltipopix_Z = Z592PropostaResponsavelTipoPix;
         obj49.gxTpr_Propostaresponsavelpix_Z = Z593PropostaResponsavelPIX;
         obj49.gxTpr_Propostaresponsaveldepositotipo_Z = Z594PropostaResponsavelDepositoTipo;
         obj49.gxTpr_Propostaresponsavelserasaconsultas_f_Z = Z733PropostaResponsavelSerasaConsultas_F;
         obj49.gxTpr_Propostaresponsavelserasascoreultimadata_f_Z = Z783PropostaResponsavelSerasaScoreUltimaData_F;
         obj49.gxTpr_Propostaresponsavelserasaultimovalorrecomendado_f_Z = Z786PropostaResponsavelSerasaUltimoValorRecomendado_F;
         obj49.gxTpr_Propostapacienteclienterazaosocial_Z = Z505PropostaPacienteClienteRazaoSocial;
         obj49.gxTpr_Propostapacienteclientedocumento_Z = Z540PropostaPacienteClienteDocumento;
         obj49.gxTpr_Propostapacientecontatoemail_Z = Z541PropostaPacienteContatoEmail;
         obj49.gxTpr_Propostapacientebanco_Z = Z583PropostaPacienteBanco;
         obj49.gxTpr_Propostapacienteconta_Z = Z584PropostaPacienteConta;
         obj49.gxTpr_Propostapacienteagencia_Z = Z585PropostaPacienteAgencia;
         obj49.gxTpr_Propostapacientetipopix_Z = Z586PropostaPacienteTipoPix;
         obj49.gxTpr_Propostapacientepix_Z = Z587PropostaPacientePIX;
         obj49.gxTpr_Propostapacientedepositotipo_Z = Z588PropostaPacienteDepositoTipo;
         obj49.gxTpr_Propostapacienteenderecocep_Z = Z620PropostaPacienteEnderecoCEP;
         obj49.gxTpr_Propostapacienteenderecologradouro_Z = Z621PropostaPacienteEnderecoLogradouro;
         obj49.gxTpr_Propostapacienteendereconumero_Z = Z622PropostaPacienteEnderecoNumero;
         obj49.gxTpr_Propostapacienteenderecocomplemento_Z = Z623PropostaPacienteEnderecoComplemento;
         obj49.gxTpr_Propostapacienteenderecobairro_Z = Z624PropostaPacienteEnderecoBairro;
         obj49.gxTpr_Propostapacientemunicipiocodigo_Z = Z625PropostaPacienteMunicipioCodigo;
         obj49.gxTpr_Propostapacienteserasaconsultas_f_Z = Z734PropostaPacienteSerasaConsultas_F;
         obj49.gxTpr_Propostaserasascoreultimadata_f_Z = Z782PropostaSerasaScoreUltimaData_F;
         obj49.gxTpr_Propostapacienteserasaultimovalorrecomendado_f_Z = Z787PropostaPacienteSerasaUltimoValorRecomendado_F;
         obj49.gxTpr_Propostavalortaxaclinica_f_Z = Z650PropostaValorTaxaClinica_F;
         obj49.gxTpr_Propostaqtddocumentopendente_f_Z = Z655PropostaQtdDocumentoPendente_F;
         obj49.gxTpr_Propostamaiorscore_f_Z = Z784PropostaMaiorScore_F;
         obj49.gxTpr_Propostamaiorvalorrecomendado_Z = Z788PropostaMaiorValorRecomendado;
         obj49.gxTpr_Propostatitulo_Z = Z324PropostaTitulo;
         obj49.gxTpr_Procedimentosmedicosid_Z = Z376ProcedimentosMedicosId;
         obj49.gxTpr_Propostadescricao_Z = Z325PropostaDescricao;
         obj49.gxTpr_Propostadatacirurgia_Z = Z517PropostaDataCirurgia;
         obj49.gxTpr_Propostavalor_Z = Z326PropostaValor;
         obj49.gxTpr_Propostavalorliquido_Z = Z855PropostaValorLiquido;
         obj49.gxTpr_Propostataxaadministrativa_Z = Z501PropostaTaxaAdministrativa;
         obj49.gxTpr_Propostataxa_f_Z = Z575PropostaTaxa_F;
         obj49.gxTpr_Propostasla_Z = Z507PropostaSLA;
         obj49.gxTpr_Propostajurosmora_Z = Z508PropostaJurosMora;
         obj49.gxTpr_Propostacreatedat_Z = Z327PropostaCreatedAt;
         obj49.gxTpr_Propostacratedby_Z = Z328PropostaCratedBy;
         obj49.gxTpr_Propostaclinicaid_Z = Z642PropostaClinicaId;
         obj49.gxTpr_Propostaclinicanome_Z = Z643PropostaClinicaNome;
         obj49.gxTpr_Propostaclinicanomefantasia_Z = Z644PropostaClinicaNomeFantasia;
         obj49.gxTpr_Propostaclinicadocumento_Z = Z652PropostaClinicaDocumento;
         obj49.gxTpr_Propostaclinicaemail_Z = Z653PropostaClinicaEmail;
         obj49.gxTpr_Propostasecusername_Z = Z512PropostaSecUserName;
         obj49.gxTpr_Propostastatus_Z = Z329PropostaStatus;
         obj49.gxTpr_Propostacomentarioanalise_Z = Z790PropostaComentarioAnalise;
         obj49.gxTpr_Propostaquantidadeaprovadores_Z = Z330PropostaQuantidadeAprovadores;
         obj49.gxTpr_Propostareprovacoespermitidas_Z = Z345PropostaReprovacoesPermitidas;
         obj49.gxTpr_Contratoid_Z = Z227ContratoId;
         obj49.gxTpr_Contratonome_Z = Z228ContratoNome;
         obj49.gxTpr_Convenioid_Z = Z410ConvenioId;
         obj49.gxTpr_Conveniovencimentoano_Z = Z496ConvenioVencimentoAno;
         obj49.gxTpr_Conveniovencimentomes_Z = Z497ConvenioVencimentoMes;
         obj49.gxTpr_Conveniocategoriaid_Z = Z493ConvenioCategoriaId;
         obj49.gxTpr_Conveniocategoriadescricao_Z = Z494ConvenioCategoriaDescricao;
         obj49.gxTpr_Propostadatacreditocliente_f_Z = Z515PropostaDataCreditoCliente_F;
         obj49.gxTpr_Propostavalortaxa_f_Z = Z513PropostaValorTaxa_F;
         obj49.gxTpr_Propostavalorjurosmora_f_Z = Z514PropostaValorJurosMora_F;
         obj49.gxTpr_Propostavalorreembolsado_f_Z = Z509PropostaValorReembolsado_F;
         obj49.gxTpr_Propostavalorreembolsadojuros_f_Z = Z510PropostaValorReembolsadoJuros_F;
         obj49.gxTpr_Propostavalortaxarecebida_f_Z = Z511PropostaValorTaxaRecebida_F;
         obj49.gxTpr_Propostaaprovacoes_f_Z = Z341PropostaAprovacoes_F;
         obj49.gxTpr_Propostareprovacoes_f_Z = Z342PropostaReprovacoes_F;
         obj49.gxTpr_Propostaaprovacoesrestantes_f_Z = Z343PropostaAprovacoesRestantes_F;
         obj49.gxTpr_Propostaid_N = (short)(Convert.ToInt16(n323PropostaId));
         obj49.gxTpr_Propostamaxreembolsoid_f_N = (short)(Convert.ToInt16(n649PropostaMaxReembolsoId_F));
         obj49.gxTpr_Propostaprotocolo_N = (short)(Convert.ToInt16(n853PropostaProtocolo));
         obj49.gxTpr_Propostaempresaclienteid_N = (short)(Convert.ToInt16(n850PropostaEmpresaClienteId));
         obj49.gxTpr_Propostatipoproposta_N = (short)(Convert.ToInt16(n849PropostaTipoProposta));
         obj49.gxTpr_Propostapacienteclienteid_N = (short)(Convert.ToInt16(n504PropostaPacienteClienteId));
         obj49.gxTpr_Propostaqtditensnota_f_N = (short)(Convert.ToInt16(n854PropostaQtdItensNota_F));
         obj49.gxTpr_Propostaresponsavelid_N = (short)(Convert.ToInt16(n553PropostaResponsavelId));
         obj49.gxTpr_Propostaresponsaveldocumento_N = (short)(Convert.ToInt16(n580PropostaResponsavelDocumento));
         obj49.gxTpr_Propostaresponsavelrazaosocial_N = (short)(Convert.ToInt16(n581PropostaResponsavelRazaoSocial));
         obj49.gxTpr_Propostaresponsavelemail_N = (short)(Convert.ToInt16(n582PropostaResponsavelEmail));
         obj49.gxTpr_Propostaresponsavelconta_N = (short)(Convert.ToInt16(n590PropostaResponsavelConta));
         obj49.gxTpr_Propostaresponsavelagencia_N = (short)(Convert.ToInt16(n591PropostaResponsavelAgencia));
         obj49.gxTpr_Propostaresponsaveltipopix_N = (short)(Convert.ToInt16(n592PropostaResponsavelTipoPix));
         obj49.gxTpr_Propostaresponsavelpix_N = (short)(Convert.ToInt16(n593PropostaResponsavelPIX));
         obj49.gxTpr_Propostaresponsaveldepositotipo_N = (short)(Convert.ToInt16(n594PropostaResponsavelDepositoTipo));
         obj49.gxTpr_Propostaresponsavelserasaconsultas_f_N = (short)(Convert.ToInt16(n733PropostaResponsavelSerasaConsultas_F));
         obj49.gxTpr_Propostaresponsavelserasascoreultimadata_f_N = (short)(Convert.ToInt16(n783PropostaResponsavelSerasaScoreUltimaData_F));
         obj49.gxTpr_Propostaresponsavelserasaultimovalorrecomendado_f_N = (short)(Convert.ToInt16(n786PropostaResponsavelSerasaUltimoValorRecomendado_F));
         obj49.gxTpr_Propostapacienteclienterazaosocial_N = (short)(Convert.ToInt16(n505PropostaPacienteClienteRazaoSocial));
         obj49.gxTpr_Propostapacienteclientedocumento_N = (short)(Convert.ToInt16(n540PropostaPacienteClienteDocumento));
         obj49.gxTpr_Propostapacientecontatoemail_N = (short)(Convert.ToInt16(n541PropostaPacienteContatoEmail));
         obj49.gxTpr_Propostapacienteconta_N = (short)(Convert.ToInt16(n584PropostaPacienteConta));
         obj49.gxTpr_Propostapacienteagencia_N = (short)(Convert.ToInt16(n585PropostaPacienteAgencia));
         obj49.gxTpr_Propostapacientetipopix_N = (short)(Convert.ToInt16(n586PropostaPacienteTipoPix));
         obj49.gxTpr_Propostapacientepix_N = (short)(Convert.ToInt16(n587PropostaPacientePIX));
         obj49.gxTpr_Propostapacientedepositotipo_N = (short)(Convert.ToInt16(n588PropostaPacienteDepositoTipo));
         obj49.gxTpr_Propostapacienteenderecocep_N = (short)(Convert.ToInt16(n620PropostaPacienteEnderecoCEP));
         obj49.gxTpr_Propostapacienteenderecologradouro_N = (short)(Convert.ToInt16(n621PropostaPacienteEnderecoLogradouro));
         obj49.gxTpr_Propostapacienteendereconumero_N = (short)(Convert.ToInt16(n622PropostaPacienteEnderecoNumero));
         obj49.gxTpr_Propostapacienteenderecocomplemento_N = (short)(Convert.ToInt16(n623PropostaPacienteEnderecoComplemento));
         obj49.gxTpr_Propostapacienteenderecobairro_N = (short)(Convert.ToInt16(n624PropostaPacienteEnderecoBairro));
         obj49.gxTpr_Propostapacientemunicipiocodigo_N = (short)(Convert.ToInt16(n625PropostaPacienteMunicipioCodigo));
         obj49.gxTpr_Propostapacienteserasaconsultas_f_N = (short)(Convert.ToInt16(n734PropostaPacienteSerasaConsultas_F));
         obj49.gxTpr_Propostaserasascoreultimadata_f_N = (short)(Convert.ToInt16(n782PropostaSerasaScoreUltimaData_F));
         obj49.gxTpr_Propostapacienteserasaultimovalorrecomendado_f_N = (short)(Convert.ToInt16(n787PropostaPacienteSerasaUltimoValorRecomendado_F));
         obj49.gxTpr_Propostavalortaxaclinica_f_N = (short)(Convert.ToInt16(n650PropostaValorTaxaClinica_F));
         obj49.gxTpr_Propostaqtddocumentopendente_f_N = (short)(Convert.ToInt16(n655PropostaQtdDocumentoPendente_F));
         obj49.gxTpr_Propostatitulo_N = (short)(Convert.ToInt16(n324PropostaTitulo));
         obj49.gxTpr_Procedimentosmedicosid_N = (short)(Convert.ToInt16(n376ProcedimentosMedicosId));
         obj49.gxTpr_Propostadescricao_N = (short)(Convert.ToInt16(n325PropostaDescricao));
         obj49.gxTpr_Propostadatacirurgia_N = (short)(Convert.ToInt16(n517PropostaDataCirurgia));
         obj49.gxTpr_Propostavalor_N = (short)(Convert.ToInt16(n326PropostaValor));
         obj49.gxTpr_Propostavalorliquido_N = (short)(Convert.ToInt16(n855PropostaValorLiquido));
         obj49.gxTpr_Propostataxaadministrativa_N = (short)(Convert.ToInt16(n501PropostaTaxaAdministrativa));
         obj49.gxTpr_Propostasla_N = (short)(Convert.ToInt16(n507PropostaSLA));
         obj49.gxTpr_Propostajurosmora_N = (short)(Convert.ToInt16(n508PropostaJurosMora));
         obj49.gxTpr_Propostacreatedat_N = (short)(Convert.ToInt16(n327PropostaCreatedAt));
         obj49.gxTpr_Propostacratedby_N = (short)(Convert.ToInt16(n328PropostaCratedBy));
         obj49.gxTpr_Propostaclinicaid_N = (short)(Convert.ToInt16(n642PropostaClinicaId));
         obj49.gxTpr_Propostaclinicanome_N = (short)(Convert.ToInt16(n643PropostaClinicaNome));
         obj49.gxTpr_Propostaclinicanomefantasia_N = (short)(Convert.ToInt16(n644PropostaClinicaNomeFantasia));
         obj49.gxTpr_Propostaclinicadocumento_N = (short)(Convert.ToInt16(n652PropostaClinicaDocumento));
         obj49.gxTpr_Propostaclinicaemail_N = (short)(Convert.ToInt16(n653PropostaClinicaEmail));
         obj49.gxTpr_Propostasecusername_N = (short)(Convert.ToInt16(n512PropostaSecUserName));
         obj49.gxTpr_Propostastatus_N = (short)(Convert.ToInt16(n329PropostaStatus));
         obj49.gxTpr_Propostacomentarioanalise_N = (short)(Convert.ToInt16(n790PropostaComentarioAnalise));
         obj49.gxTpr_Propostaquantidadeaprovadores_N = (short)(Convert.ToInt16(n330PropostaQuantidadeAprovadores));
         obj49.gxTpr_Propostareprovacoespermitidas_N = (short)(Convert.ToInt16(n345PropostaReprovacoesPermitidas));
         obj49.gxTpr_Contratoid_N = (short)(Convert.ToInt16(n227ContratoId));
         obj49.gxTpr_Contratonome_N = (short)(Convert.ToInt16(n228ContratoNome));
         obj49.gxTpr_Convenioid_N = (short)(Convert.ToInt16(n410ConvenioId));
         obj49.gxTpr_Conveniovencimentoano_N = (short)(Convert.ToInt16(n496ConvenioVencimentoAno));
         obj49.gxTpr_Conveniovencimentomes_N = (short)(Convert.ToInt16(n497ConvenioVencimentoMes));
         obj49.gxTpr_Conveniocategoriaid_N = (short)(Convert.ToInt16(n493ConvenioCategoriaId));
         obj49.gxTpr_Conveniocategoriadescricao_N = (short)(Convert.ToInt16(n494ConvenioCategoriaDescricao));
         obj49.gxTpr_Propostadatacreditocliente_f_N = (short)(Convert.ToInt16(n515PropostaDataCreditoCliente_F));
         obj49.gxTpr_Propostavalorreembolsado_f_N = (short)(Convert.ToInt16(n509PropostaValorReembolsado_F));
         obj49.gxTpr_Propostavalorreembolsadojuros_f_N = (short)(Convert.ToInt16(n510PropostaValorReembolsadoJuros_F));
         obj49.gxTpr_Propostavalortaxarecebida_f_N = (short)(Convert.ToInt16(n511PropostaValorTaxaRecebida_F));
         obj49.gxTpr_Propostaaprovacoes_f_N = (short)(Convert.ToInt16(n341PropostaAprovacoes_F));
         obj49.gxTpr_Propostareprovacoes_f_N = (short)(Convert.ToInt16(n342PropostaReprovacoes_F));
         obj49.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow49( SdtProposta obj49 )
      {
         obj49.gxTpr_Propostaid = A323PropostaId;
         return  ;
      }

      public void RowToVars49( SdtProposta obj49 ,
                               int forceLoad )
      {
         Gx_mode = obj49.gxTpr_Mode;
         A327PropostaCreatedAt = obj49.gxTpr_Propostacreatedat;
         n327PropostaCreatedAt = false;
         A343PropostaAprovacoesRestantes_F = obj49.gxTpr_Propostaaprovacoesrestantes_f;
         A513PropostaValorTaxa_F = obj49.gxTpr_Propostavalortaxa_f;
         A514PropostaValorJurosMora_F = obj49.gxTpr_Propostavalorjurosmora_f;
         A575PropostaTaxa_F = obj49.gxTpr_Propostataxa_f;
         A788PropostaMaiorValorRecomendado = obj49.gxTpr_Propostamaiorvalorrecomendado;
         A784PropostaMaiorScore_F = obj49.gxTpr_Propostamaiorscore_f;
         A509PropostaValorReembolsado_F = obj49.gxTpr_Propostavalorreembolsado_f;
         n509PropostaValorReembolsado_F = false;
         A510PropostaValorReembolsadoJuros_F = obj49.gxTpr_Propostavalorreembolsadojuros_f;
         n510PropostaValorReembolsadoJuros_F = false;
         A511PropostaValorTaxaRecebida_F = obj49.gxTpr_Propostavalortaxarecebida_f;
         n511PropostaValorTaxaRecebida_F = false;
         A515PropostaDataCreditoCliente_F = obj49.gxTpr_Propostadatacreditocliente_f;
         n515PropostaDataCreditoCliente_F = false;
         A650PropostaValorTaxaClinica_F = obj49.gxTpr_Propostavalortaxaclinica_f;
         n650PropostaValorTaxaClinica_F = false;
         A649PropostaMaxReembolsoId_F = obj49.gxTpr_Propostamaxreembolsoid_f;
         n649PropostaMaxReembolsoId_F = false;
         A853PropostaProtocolo = obj49.gxTpr_Propostaprotocolo;
         n853PropostaProtocolo = false;
         A850PropostaEmpresaClienteId = obj49.gxTpr_Propostaempresaclienteid;
         n850PropostaEmpresaClienteId = false;
         A849PropostaTipoProposta = obj49.gxTpr_Propostatipoproposta;
         n849PropostaTipoProposta = false;
         A504PropostaPacienteClienteId = obj49.gxTpr_Propostapacienteclienteid;
         n504PropostaPacienteClienteId = false;
         A854PropostaQtdItensNota_F = obj49.gxTpr_Propostaqtditensnota_f;
         n854PropostaQtdItensNota_F = false;
         A553PropostaResponsavelId = obj49.gxTpr_Propostaresponsavelid;
         n553PropostaResponsavelId = false;
         A580PropostaResponsavelDocumento = obj49.gxTpr_Propostaresponsaveldocumento;
         n580PropostaResponsavelDocumento = false;
         A581PropostaResponsavelRazaoSocial = obj49.gxTpr_Propostaresponsavelrazaosocial;
         n581PropostaResponsavelRazaoSocial = false;
         A582PropostaResponsavelEmail = obj49.gxTpr_Propostaresponsavelemail;
         n582PropostaResponsavelEmail = false;
         A589PropostaResponsavelBanco = obj49.gxTpr_Propostaresponsavelbanco;
         A590PropostaResponsavelConta = obj49.gxTpr_Propostaresponsavelconta;
         n590PropostaResponsavelConta = false;
         A591PropostaResponsavelAgencia = obj49.gxTpr_Propostaresponsavelagencia;
         n591PropostaResponsavelAgencia = false;
         A592PropostaResponsavelTipoPix = obj49.gxTpr_Propostaresponsaveltipopix;
         n592PropostaResponsavelTipoPix = false;
         A593PropostaResponsavelPIX = obj49.gxTpr_Propostaresponsavelpix;
         n593PropostaResponsavelPIX = false;
         A594PropostaResponsavelDepositoTipo = obj49.gxTpr_Propostaresponsaveldepositotipo;
         n594PropostaResponsavelDepositoTipo = false;
         A733PropostaResponsavelSerasaConsultas_F = obj49.gxTpr_Propostaresponsavelserasaconsultas_f;
         n733PropostaResponsavelSerasaConsultas_F = false;
         A783PropostaResponsavelSerasaScoreUltimaData_F = obj49.gxTpr_Propostaresponsavelserasascoreultimadata_f;
         n783PropostaResponsavelSerasaScoreUltimaData_F = false;
         A786PropostaResponsavelSerasaUltimoValorRecomendado_F = obj49.gxTpr_Propostaresponsavelserasaultimovalorrecomendado_f;
         n786PropostaResponsavelSerasaUltimoValorRecomendado_F = false;
         A505PropostaPacienteClienteRazaoSocial = obj49.gxTpr_Propostapacienteclienterazaosocial;
         n505PropostaPacienteClienteRazaoSocial = false;
         A540PropostaPacienteClienteDocumento = obj49.gxTpr_Propostapacienteclientedocumento;
         n540PropostaPacienteClienteDocumento = false;
         A541PropostaPacienteContatoEmail = obj49.gxTpr_Propostapacientecontatoemail;
         n541PropostaPacienteContatoEmail = false;
         A583PropostaPacienteBanco = obj49.gxTpr_Propostapacientebanco;
         A584PropostaPacienteConta = obj49.gxTpr_Propostapacienteconta;
         n584PropostaPacienteConta = false;
         A585PropostaPacienteAgencia = obj49.gxTpr_Propostapacienteagencia;
         n585PropostaPacienteAgencia = false;
         A586PropostaPacienteTipoPix = obj49.gxTpr_Propostapacientetipopix;
         n586PropostaPacienteTipoPix = false;
         A587PropostaPacientePIX = obj49.gxTpr_Propostapacientepix;
         n587PropostaPacientePIX = false;
         A588PropostaPacienteDepositoTipo = obj49.gxTpr_Propostapacientedepositotipo;
         n588PropostaPacienteDepositoTipo = false;
         A620PropostaPacienteEnderecoCEP = obj49.gxTpr_Propostapacienteenderecocep;
         n620PropostaPacienteEnderecoCEP = false;
         A621PropostaPacienteEnderecoLogradouro = obj49.gxTpr_Propostapacienteenderecologradouro;
         n621PropostaPacienteEnderecoLogradouro = false;
         A622PropostaPacienteEnderecoNumero = obj49.gxTpr_Propostapacienteendereconumero;
         n622PropostaPacienteEnderecoNumero = false;
         A623PropostaPacienteEnderecoComplemento = obj49.gxTpr_Propostapacienteenderecocomplemento;
         n623PropostaPacienteEnderecoComplemento = false;
         A624PropostaPacienteEnderecoBairro = obj49.gxTpr_Propostapacienteenderecobairro;
         n624PropostaPacienteEnderecoBairro = false;
         A625PropostaPacienteMunicipioCodigo = obj49.gxTpr_Propostapacientemunicipiocodigo;
         n625PropostaPacienteMunicipioCodigo = false;
         A734PropostaPacienteSerasaConsultas_F = obj49.gxTpr_Propostapacienteserasaconsultas_f;
         n734PropostaPacienteSerasaConsultas_F = false;
         A782PropostaSerasaScoreUltimaData_F = obj49.gxTpr_Propostaserasascoreultimadata_f;
         n782PropostaSerasaScoreUltimaData_F = false;
         A787PropostaPacienteSerasaUltimoValorRecomendado_F = obj49.gxTpr_Propostapacienteserasaultimovalorrecomendado_f;
         n787PropostaPacienteSerasaUltimoValorRecomendado_F = false;
         A655PropostaQtdDocumentoPendente_F = obj49.gxTpr_Propostaqtddocumentopendente_f;
         n655PropostaQtdDocumentoPendente_F = false;
         A324PropostaTitulo = obj49.gxTpr_Propostatitulo;
         n324PropostaTitulo = false;
         A376ProcedimentosMedicosId = obj49.gxTpr_Procedimentosmedicosid;
         n376ProcedimentosMedicosId = false;
         A325PropostaDescricao = obj49.gxTpr_Propostadescricao;
         n325PropostaDescricao = false;
         A517PropostaDataCirurgia = obj49.gxTpr_Propostadatacirurgia;
         n517PropostaDataCirurgia = false;
         A326PropostaValor = obj49.gxTpr_Propostavalor;
         n326PropostaValor = false;
         A855PropostaValorLiquido = obj49.gxTpr_Propostavalorliquido;
         n855PropostaValorLiquido = false;
         A501PropostaTaxaAdministrativa = obj49.gxTpr_Propostataxaadministrativa;
         n501PropostaTaxaAdministrativa = false;
         A507PropostaSLA = obj49.gxTpr_Propostasla;
         n507PropostaSLA = false;
         A508PropostaJurosMora = obj49.gxTpr_Propostajurosmora;
         n508PropostaJurosMora = false;
         A328PropostaCratedBy = obj49.gxTpr_Propostacratedby;
         n328PropostaCratedBy = false;
         A642PropostaClinicaId = obj49.gxTpr_Propostaclinicaid;
         n642PropostaClinicaId = false;
         A643PropostaClinicaNome = obj49.gxTpr_Propostaclinicanome;
         n643PropostaClinicaNome = false;
         A644PropostaClinicaNomeFantasia = obj49.gxTpr_Propostaclinicanomefantasia;
         n644PropostaClinicaNomeFantasia = false;
         A652PropostaClinicaDocumento = obj49.gxTpr_Propostaclinicadocumento;
         n652PropostaClinicaDocumento = false;
         A653PropostaClinicaEmail = obj49.gxTpr_Propostaclinicaemail;
         n653PropostaClinicaEmail = false;
         A512PropostaSecUserName = obj49.gxTpr_Propostasecusername;
         n512PropostaSecUserName = false;
         A329PropostaStatus = obj49.gxTpr_Propostastatus;
         n329PropostaStatus = false;
         A790PropostaComentarioAnalise = obj49.gxTpr_Propostacomentarioanalise;
         n790PropostaComentarioAnalise = false;
         A330PropostaQuantidadeAprovadores = obj49.gxTpr_Propostaquantidadeaprovadores;
         n330PropostaQuantidadeAprovadores = false;
         A345PropostaReprovacoesPermitidas = obj49.gxTpr_Propostareprovacoespermitidas;
         n345PropostaReprovacoesPermitidas = false;
         A227ContratoId = obj49.gxTpr_Contratoid;
         n227ContratoId = false;
         A228ContratoNome = obj49.gxTpr_Contratonome;
         n228ContratoNome = false;
         A410ConvenioId = obj49.gxTpr_Convenioid;
         n410ConvenioId = false;
         A496ConvenioVencimentoAno = obj49.gxTpr_Conveniovencimentoano;
         n496ConvenioVencimentoAno = false;
         A497ConvenioVencimentoMes = obj49.gxTpr_Conveniovencimentomes;
         n497ConvenioVencimentoMes = false;
         A493ConvenioCategoriaId = obj49.gxTpr_Conveniocategoriaid;
         n493ConvenioCategoriaId = false;
         A494ConvenioCategoriaDescricao = obj49.gxTpr_Conveniocategoriadescricao;
         n494ConvenioCategoriaDescricao = false;
         A341PropostaAprovacoes_F = obj49.gxTpr_Propostaaprovacoes_f;
         n341PropostaAprovacoes_F = false;
         A342PropostaReprovacoes_F = obj49.gxTpr_Propostareprovacoes_f;
         n342PropostaReprovacoes_F = false;
         A323PropostaId = obj49.gxTpr_Propostaid;
         n323PropostaId = false;
         Z323PropostaId = obj49.gxTpr_Propostaid_Z;
         Z649PropostaMaxReembolsoId_F = obj49.gxTpr_Propostamaxreembolsoid_f_Z;
         Z853PropostaProtocolo = obj49.gxTpr_Propostaprotocolo_Z;
         Z850PropostaEmpresaClienteId = obj49.gxTpr_Propostaempresaclienteid_Z;
         Z849PropostaTipoProposta = obj49.gxTpr_Propostatipoproposta_Z;
         Z504PropostaPacienteClienteId = obj49.gxTpr_Propostapacienteclienteid_Z;
         Z854PropostaQtdItensNota_F = obj49.gxTpr_Propostaqtditensnota_f_Z;
         Z553PropostaResponsavelId = obj49.gxTpr_Propostaresponsavelid_Z;
         Z580PropostaResponsavelDocumento = obj49.gxTpr_Propostaresponsaveldocumento_Z;
         Z581PropostaResponsavelRazaoSocial = obj49.gxTpr_Propostaresponsavelrazaosocial_Z;
         Z582PropostaResponsavelEmail = obj49.gxTpr_Propostaresponsavelemail_Z;
         Z589PropostaResponsavelBanco = obj49.gxTpr_Propostaresponsavelbanco_Z;
         Z590PropostaResponsavelConta = obj49.gxTpr_Propostaresponsavelconta_Z;
         Z591PropostaResponsavelAgencia = obj49.gxTpr_Propostaresponsavelagencia_Z;
         Z592PropostaResponsavelTipoPix = obj49.gxTpr_Propostaresponsaveltipopix_Z;
         Z593PropostaResponsavelPIX = obj49.gxTpr_Propostaresponsavelpix_Z;
         Z594PropostaResponsavelDepositoTipo = obj49.gxTpr_Propostaresponsaveldepositotipo_Z;
         Z733PropostaResponsavelSerasaConsultas_F = obj49.gxTpr_Propostaresponsavelserasaconsultas_f_Z;
         Z783PropostaResponsavelSerasaScoreUltimaData_F = obj49.gxTpr_Propostaresponsavelserasascoreultimadata_f_Z;
         Z786PropostaResponsavelSerasaUltimoValorRecomendado_F = obj49.gxTpr_Propostaresponsavelserasaultimovalorrecomendado_f_Z;
         Z505PropostaPacienteClienteRazaoSocial = obj49.gxTpr_Propostapacienteclienterazaosocial_Z;
         Z540PropostaPacienteClienteDocumento = obj49.gxTpr_Propostapacienteclientedocumento_Z;
         Z541PropostaPacienteContatoEmail = obj49.gxTpr_Propostapacientecontatoemail_Z;
         Z583PropostaPacienteBanco = obj49.gxTpr_Propostapacientebanco_Z;
         Z584PropostaPacienteConta = obj49.gxTpr_Propostapacienteconta_Z;
         Z585PropostaPacienteAgencia = obj49.gxTpr_Propostapacienteagencia_Z;
         Z586PropostaPacienteTipoPix = obj49.gxTpr_Propostapacientetipopix_Z;
         Z587PropostaPacientePIX = obj49.gxTpr_Propostapacientepix_Z;
         Z588PropostaPacienteDepositoTipo = obj49.gxTpr_Propostapacientedepositotipo_Z;
         Z620PropostaPacienteEnderecoCEP = obj49.gxTpr_Propostapacienteenderecocep_Z;
         Z621PropostaPacienteEnderecoLogradouro = obj49.gxTpr_Propostapacienteenderecologradouro_Z;
         Z622PropostaPacienteEnderecoNumero = obj49.gxTpr_Propostapacienteendereconumero_Z;
         Z623PropostaPacienteEnderecoComplemento = obj49.gxTpr_Propostapacienteenderecocomplemento_Z;
         Z624PropostaPacienteEnderecoBairro = obj49.gxTpr_Propostapacienteenderecobairro_Z;
         Z625PropostaPacienteMunicipioCodigo = obj49.gxTpr_Propostapacientemunicipiocodigo_Z;
         Z734PropostaPacienteSerasaConsultas_F = obj49.gxTpr_Propostapacienteserasaconsultas_f_Z;
         Z782PropostaSerasaScoreUltimaData_F = obj49.gxTpr_Propostaserasascoreultimadata_f_Z;
         Z787PropostaPacienteSerasaUltimoValorRecomendado_F = obj49.gxTpr_Propostapacienteserasaultimovalorrecomendado_f_Z;
         Z650PropostaValorTaxaClinica_F = obj49.gxTpr_Propostavalortaxaclinica_f_Z;
         Z655PropostaQtdDocumentoPendente_F = obj49.gxTpr_Propostaqtddocumentopendente_f_Z;
         Z784PropostaMaiorScore_F = obj49.gxTpr_Propostamaiorscore_f_Z;
         Z788PropostaMaiorValorRecomendado = obj49.gxTpr_Propostamaiorvalorrecomendado_Z;
         Z324PropostaTitulo = obj49.gxTpr_Propostatitulo_Z;
         Z376ProcedimentosMedicosId = obj49.gxTpr_Procedimentosmedicosid_Z;
         Z325PropostaDescricao = obj49.gxTpr_Propostadescricao_Z;
         Z517PropostaDataCirurgia = obj49.gxTpr_Propostadatacirurgia_Z;
         Z326PropostaValor = obj49.gxTpr_Propostavalor_Z;
         Z855PropostaValorLiquido = obj49.gxTpr_Propostavalorliquido_Z;
         Z501PropostaTaxaAdministrativa = obj49.gxTpr_Propostataxaadministrativa_Z;
         Z575PropostaTaxa_F = obj49.gxTpr_Propostataxa_f_Z;
         Z507PropostaSLA = obj49.gxTpr_Propostasla_Z;
         Z508PropostaJurosMora = obj49.gxTpr_Propostajurosmora_Z;
         Z327PropostaCreatedAt = obj49.gxTpr_Propostacreatedat_Z;
         Z328PropostaCratedBy = obj49.gxTpr_Propostacratedby_Z;
         Z642PropostaClinicaId = obj49.gxTpr_Propostaclinicaid_Z;
         Z643PropostaClinicaNome = obj49.gxTpr_Propostaclinicanome_Z;
         Z644PropostaClinicaNomeFantasia = obj49.gxTpr_Propostaclinicanomefantasia_Z;
         Z652PropostaClinicaDocumento = obj49.gxTpr_Propostaclinicadocumento_Z;
         Z653PropostaClinicaEmail = obj49.gxTpr_Propostaclinicaemail_Z;
         Z512PropostaSecUserName = obj49.gxTpr_Propostasecusername_Z;
         Z329PropostaStatus = obj49.gxTpr_Propostastatus_Z;
         Z790PropostaComentarioAnalise = obj49.gxTpr_Propostacomentarioanalise_Z;
         Z330PropostaQuantidadeAprovadores = obj49.gxTpr_Propostaquantidadeaprovadores_Z;
         Z345PropostaReprovacoesPermitidas = obj49.gxTpr_Propostareprovacoespermitidas_Z;
         Z227ContratoId = obj49.gxTpr_Contratoid_Z;
         Z228ContratoNome = obj49.gxTpr_Contratonome_Z;
         Z410ConvenioId = obj49.gxTpr_Convenioid_Z;
         Z496ConvenioVencimentoAno = obj49.gxTpr_Conveniovencimentoano_Z;
         Z497ConvenioVencimentoMes = obj49.gxTpr_Conveniovencimentomes_Z;
         Z493ConvenioCategoriaId = obj49.gxTpr_Conveniocategoriaid_Z;
         Z494ConvenioCategoriaDescricao = obj49.gxTpr_Conveniocategoriadescricao_Z;
         Z515PropostaDataCreditoCliente_F = obj49.gxTpr_Propostadatacreditocliente_f_Z;
         Z513PropostaValorTaxa_F = obj49.gxTpr_Propostavalortaxa_f_Z;
         Z514PropostaValorJurosMora_F = obj49.gxTpr_Propostavalorjurosmora_f_Z;
         Z509PropostaValorReembolsado_F = obj49.gxTpr_Propostavalorreembolsado_f_Z;
         Z510PropostaValorReembolsadoJuros_F = obj49.gxTpr_Propostavalorreembolsadojuros_f_Z;
         Z511PropostaValorTaxaRecebida_F = obj49.gxTpr_Propostavalortaxarecebida_f_Z;
         Z341PropostaAprovacoes_F = obj49.gxTpr_Propostaaprovacoes_f_Z;
         Z342PropostaReprovacoes_F = obj49.gxTpr_Propostareprovacoes_f_Z;
         Z343PropostaAprovacoesRestantes_F = obj49.gxTpr_Propostaaprovacoesrestantes_f_Z;
         n323PropostaId = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostaid_N));
         n649PropostaMaxReembolsoId_F = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostamaxreembolsoid_f_N));
         n853PropostaProtocolo = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostaprotocolo_N));
         n850PropostaEmpresaClienteId = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostaempresaclienteid_N));
         n849PropostaTipoProposta = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostatipoproposta_N));
         n504PropostaPacienteClienteId = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostapacienteclienteid_N));
         n854PropostaQtdItensNota_F = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostaqtditensnota_f_N));
         n553PropostaResponsavelId = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostaresponsavelid_N));
         n580PropostaResponsavelDocumento = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostaresponsaveldocumento_N));
         n581PropostaResponsavelRazaoSocial = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostaresponsavelrazaosocial_N));
         n582PropostaResponsavelEmail = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostaresponsavelemail_N));
         n590PropostaResponsavelConta = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostaresponsavelconta_N));
         n591PropostaResponsavelAgencia = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostaresponsavelagencia_N));
         n592PropostaResponsavelTipoPix = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostaresponsaveltipopix_N));
         n593PropostaResponsavelPIX = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostaresponsavelpix_N));
         n594PropostaResponsavelDepositoTipo = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostaresponsaveldepositotipo_N));
         n733PropostaResponsavelSerasaConsultas_F = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostaresponsavelserasaconsultas_f_N));
         n783PropostaResponsavelSerasaScoreUltimaData_F = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostaresponsavelserasascoreultimadata_f_N));
         n786PropostaResponsavelSerasaUltimoValorRecomendado_F = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostaresponsavelserasaultimovalorrecomendado_f_N));
         n505PropostaPacienteClienteRazaoSocial = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostapacienteclienterazaosocial_N));
         n540PropostaPacienteClienteDocumento = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostapacienteclientedocumento_N));
         n541PropostaPacienteContatoEmail = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostapacientecontatoemail_N));
         n584PropostaPacienteConta = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostapacienteconta_N));
         n585PropostaPacienteAgencia = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostapacienteagencia_N));
         n586PropostaPacienteTipoPix = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostapacientetipopix_N));
         n587PropostaPacientePIX = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostapacientepix_N));
         n588PropostaPacienteDepositoTipo = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostapacientedepositotipo_N));
         n620PropostaPacienteEnderecoCEP = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostapacienteenderecocep_N));
         n621PropostaPacienteEnderecoLogradouro = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostapacienteenderecologradouro_N));
         n622PropostaPacienteEnderecoNumero = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostapacienteendereconumero_N));
         n623PropostaPacienteEnderecoComplemento = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostapacienteenderecocomplemento_N));
         n624PropostaPacienteEnderecoBairro = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostapacienteenderecobairro_N));
         n625PropostaPacienteMunicipioCodigo = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostapacientemunicipiocodigo_N));
         n734PropostaPacienteSerasaConsultas_F = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostapacienteserasaconsultas_f_N));
         n782PropostaSerasaScoreUltimaData_F = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostaserasascoreultimadata_f_N));
         n787PropostaPacienteSerasaUltimoValorRecomendado_F = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostapacienteserasaultimovalorrecomendado_f_N));
         n650PropostaValorTaxaClinica_F = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostavalortaxaclinica_f_N));
         n655PropostaQtdDocumentoPendente_F = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostaqtddocumentopendente_f_N));
         n324PropostaTitulo = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostatitulo_N));
         n376ProcedimentosMedicosId = (bool)(Convert.ToBoolean(obj49.gxTpr_Procedimentosmedicosid_N));
         n325PropostaDescricao = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostadescricao_N));
         n517PropostaDataCirurgia = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostadatacirurgia_N));
         n326PropostaValor = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostavalor_N));
         n855PropostaValorLiquido = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostavalorliquido_N));
         n501PropostaTaxaAdministrativa = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostataxaadministrativa_N));
         n507PropostaSLA = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostasla_N));
         n508PropostaJurosMora = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostajurosmora_N));
         n327PropostaCreatedAt = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostacreatedat_N));
         n328PropostaCratedBy = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostacratedby_N));
         n642PropostaClinicaId = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostaclinicaid_N));
         n643PropostaClinicaNome = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostaclinicanome_N));
         n644PropostaClinicaNomeFantasia = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostaclinicanomefantasia_N));
         n652PropostaClinicaDocumento = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostaclinicadocumento_N));
         n653PropostaClinicaEmail = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostaclinicaemail_N));
         n512PropostaSecUserName = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostasecusername_N));
         n329PropostaStatus = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostastatus_N));
         n790PropostaComentarioAnalise = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostacomentarioanalise_N));
         n330PropostaQuantidadeAprovadores = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostaquantidadeaprovadores_N));
         n345PropostaReprovacoesPermitidas = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostareprovacoespermitidas_N));
         n227ContratoId = (bool)(Convert.ToBoolean(obj49.gxTpr_Contratoid_N));
         n228ContratoNome = (bool)(Convert.ToBoolean(obj49.gxTpr_Contratonome_N));
         n410ConvenioId = (bool)(Convert.ToBoolean(obj49.gxTpr_Convenioid_N));
         n496ConvenioVencimentoAno = (bool)(Convert.ToBoolean(obj49.gxTpr_Conveniovencimentoano_N));
         n497ConvenioVencimentoMes = (bool)(Convert.ToBoolean(obj49.gxTpr_Conveniovencimentomes_N));
         n493ConvenioCategoriaId = (bool)(Convert.ToBoolean(obj49.gxTpr_Conveniocategoriaid_N));
         n494ConvenioCategoriaDescricao = (bool)(Convert.ToBoolean(obj49.gxTpr_Conveniocategoriadescricao_N));
         n515PropostaDataCreditoCliente_F = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostadatacreditocliente_f_N));
         n509PropostaValorReembolsado_F = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostavalorreembolsado_f_N));
         n510PropostaValorReembolsadoJuros_F = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostavalorreembolsadojuros_f_N));
         n511PropostaValorTaxaRecebida_F = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostavalortaxarecebida_f_N));
         n341PropostaAprovacoes_F = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostaaprovacoes_f_N));
         n342PropostaReprovacoes_F = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostareprovacoes_f_N));
         Gx_mode = obj49.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A323PropostaId = (int)getParm(obj,0);
         n323PropostaId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1A49( ) ;
         ScanKeyStart1A49( ) ;
         if ( RcdFound49 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z323PropostaId = A323PropostaId;
         }
         ZM1A49( -32) ;
         OnLoadActions1A49( ) ;
         AddRow1A49( ) ;
         ScanKeyEnd1A49( ) ;
         if ( RcdFound49 == 0 )
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
         RowToVars49( bcProposta, 0) ;
         ScanKeyStart1A49( ) ;
         if ( RcdFound49 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z323PropostaId = A323PropostaId;
         }
         ZM1A49( -32) ;
         OnLoadActions1A49( ) ;
         AddRow1A49( ) ;
         ScanKeyEnd1A49( ) ;
         if ( RcdFound49 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1A49( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1A49( ) ;
         }
         else
         {
            if ( RcdFound49 == 1 )
            {
               if ( A323PropostaId != Z323PropostaId )
               {
                  A323PropostaId = Z323PropostaId;
                  n323PropostaId = false;
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
                  Update1A49( ) ;
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
                  if ( A323PropostaId != Z323PropostaId )
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
                        Insert1A49( ) ;
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
                        Insert1A49( ) ;
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
         RowToVars49( bcProposta, 1) ;
         SaveImpl( ) ;
         VarsToRow49( bcProposta) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars49( bcProposta, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1A49( ) ;
         AfterTrn( ) ;
         VarsToRow49( bcProposta) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow49( bcProposta) ;
         }
         else
         {
            SdtProposta auxBC = new SdtProposta(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A323PropostaId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcProposta);
               auxBC.Save();
               bcProposta.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars49( bcProposta, 1) ;
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
         RowToVars49( bcProposta, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1A49( ) ;
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
               VarsToRow49( bcProposta) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow49( bcProposta) ;
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
         RowToVars49( bcProposta, 0) ;
         GetKey1A49( ) ;
         if ( RcdFound49 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A323PropostaId != Z323PropostaId )
            {
               A323PropostaId = Z323PropostaId;
               n323PropostaId = false;
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
            if ( A323PropostaId != Z323PropostaId )
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
         context.RollbackDataStores("proposta_bc",pr_default);
         VarsToRow49( bcProposta) ;
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
         Gx_mode = bcProposta.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcProposta.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcProposta )
         {
            bcProposta = (SdtProposta)(sdt);
            if ( StringUtil.StrCmp(bcProposta.gxTpr_Mode, "") == 0 )
            {
               bcProposta.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow49( bcProposta) ;
            }
            else
            {
               RowToVars49( bcProposta, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcProposta.gxTpr_Mode, "") == 0 )
            {
               bcProposta.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars49( bcProposta, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtProposta Proposta_BC
      {
         get {
            return bcProposta ;
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
         pr_default.close(46);
         pr_default.close(47);
         pr_default.close(42);
         pr_default.close(34);
         pr_default.close(41);
         pr_default.close(44);
         pr_default.close(35);
         pr_default.close(36);
         pr_default.close(43);
         pr_default.close(37);
         pr_default.close(45);
         pr_default.close(29);
         pr_default.close(30);
         pr_default.close(38);
         pr_default.close(39);
         pr_default.close(40);
         pr_default.close(31);
         pr_default.close(32);
         pr_default.close(33);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV36Pgmname = "";
         AV13TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         A327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         Z853PropostaProtocolo = "";
         A853PropostaProtocolo = "";
         Z849PropostaTipoProposta = "";
         A849PropostaTipoProposta = "";
         Z324PropostaTitulo = "";
         A324PropostaTitulo = "";
         Z325PropostaDescricao = "";
         A325PropostaDescricao = "";
         Z517PropostaDataCirurgia = DateTime.MinValue;
         A517PropostaDataCirurgia = DateTime.MinValue;
         Z329PropostaStatus = "";
         A329PropostaStatus = "";
         Z790PropostaComentarioAnalise = "";
         A790PropostaComentarioAnalise = "";
         Z589PropostaResponsavelBanco = "";
         A589PropostaResponsavelBanco = "";
         Z583PropostaPacienteBanco = "";
         A583PropostaPacienteBanco = "";
         Z515PropostaDataCreditoCliente_F = DateTime.MinValue;
         A515PropostaDataCreditoCliente_F = DateTime.MinValue;
         Z228ContratoNome = "";
         A228ContratoNome = "";
         Z494ConvenioCategoriaDescricao = "";
         A494ConvenioCategoriaDescricao = "";
         Z512PropostaSecUserName = "";
         A512PropostaSecUserName = "";
         Z505PropostaPacienteClienteRazaoSocial = "";
         A505PropostaPacienteClienteRazaoSocial = "";
         Z540PropostaPacienteClienteDocumento = "";
         A540PropostaPacienteClienteDocumento = "";
         Z541PropostaPacienteContatoEmail = "";
         A541PropostaPacienteContatoEmail = "";
         Z584PropostaPacienteConta = "";
         A584PropostaPacienteConta = "";
         Z585PropostaPacienteAgencia = "";
         A585PropostaPacienteAgencia = "";
         Z586PropostaPacienteTipoPix = "";
         A586PropostaPacienteTipoPix = "";
         Z587PropostaPacientePIX = "";
         A587PropostaPacientePIX = "";
         Z588PropostaPacienteDepositoTipo = "";
         A588PropostaPacienteDepositoTipo = "";
         Z620PropostaPacienteEnderecoCEP = "";
         A620PropostaPacienteEnderecoCEP = "";
         Z621PropostaPacienteEnderecoLogradouro = "";
         A621PropostaPacienteEnderecoLogradouro = "";
         Z622PropostaPacienteEnderecoNumero = "";
         A622PropostaPacienteEnderecoNumero = "";
         Z623PropostaPacienteEnderecoComplemento = "";
         A623PropostaPacienteEnderecoComplemento = "";
         Z624PropostaPacienteEnderecoBairro = "";
         A624PropostaPacienteEnderecoBairro = "";
         Z625PropostaPacienteMunicipioCodigo = "";
         A625PropostaPacienteMunicipioCodigo = "";
         Z580PropostaResponsavelDocumento = "";
         A580PropostaResponsavelDocumento = "";
         Z581PropostaResponsavelRazaoSocial = "";
         A581PropostaResponsavelRazaoSocial = "";
         Z582PropostaResponsavelEmail = "";
         A582PropostaResponsavelEmail = "";
         Z590PropostaResponsavelConta = "";
         A590PropostaResponsavelConta = "";
         Z591PropostaResponsavelAgencia = "";
         A591PropostaResponsavelAgencia = "";
         Z592PropostaResponsavelTipoPix = "";
         A592PropostaResponsavelTipoPix = "";
         Z593PropostaResponsavelPIX = "";
         A593PropostaResponsavelPIX = "";
         Z594PropostaResponsavelDepositoTipo = "";
         A594PropostaResponsavelDepositoTipo = "";
         Z643PropostaClinicaNome = "";
         A643PropostaClinicaNome = "";
         Z644PropostaClinicaNomeFantasia = "";
         A644PropostaClinicaNomeFantasia = "";
         Z652PropostaClinicaDocumento = "";
         A652PropostaClinicaDocumento = "";
         Z653PropostaClinicaEmail = "";
         A653PropostaClinicaEmail = "";
         BC001A54_A323PropostaId = new int[1] ;
         BC001A54_n323PropostaId = new bool[] {false} ;
         BC001A54_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC001A54_n327PropostaCreatedAt = new bool[] {false} ;
         BC001A54_A853PropostaProtocolo = new string[] {""} ;
         BC001A54_n853PropostaProtocolo = new bool[] {false} ;
         BC001A54_A849PropostaTipoProposta = new string[] {""} ;
         BC001A54_n849PropostaTipoProposta = new bool[] {false} ;
         BC001A54_A580PropostaResponsavelDocumento = new string[] {""} ;
         BC001A54_n580PropostaResponsavelDocumento = new bool[] {false} ;
         BC001A54_A581PropostaResponsavelRazaoSocial = new string[] {""} ;
         BC001A54_n581PropostaResponsavelRazaoSocial = new bool[] {false} ;
         BC001A54_A582PropostaResponsavelEmail = new string[] {""} ;
         BC001A54_n582PropostaResponsavelEmail = new bool[] {false} ;
         BC001A54_A590PropostaResponsavelConta = new string[] {""} ;
         BC001A54_n590PropostaResponsavelConta = new bool[] {false} ;
         BC001A54_A591PropostaResponsavelAgencia = new string[] {""} ;
         BC001A54_n591PropostaResponsavelAgencia = new bool[] {false} ;
         BC001A54_A592PropostaResponsavelTipoPix = new string[] {""} ;
         BC001A54_n592PropostaResponsavelTipoPix = new bool[] {false} ;
         BC001A54_A593PropostaResponsavelPIX = new string[] {""} ;
         BC001A54_n593PropostaResponsavelPIX = new bool[] {false} ;
         BC001A54_A594PropostaResponsavelDepositoTipo = new string[] {""} ;
         BC001A54_n594PropostaResponsavelDepositoTipo = new bool[] {false} ;
         BC001A54_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         BC001A54_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         BC001A54_A540PropostaPacienteClienteDocumento = new string[] {""} ;
         BC001A54_n540PropostaPacienteClienteDocumento = new bool[] {false} ;
         BC001A54_A541PropostaPacienteContatoEmail = new string[] {""} ;
         BC001A54_n541PropostaPacienteContatoEmail = new bool[] {false} ;
         BC001A54_A584PropostaPacienteConta = new string[] {""} ;
         BC001A54_n584PropostaPacienteConta = new bool[] {false} ;
         BC001A54_A585PropostaPacienteAgencia = new string[] {""} ;
         BC001A54_n585PropostaPacienteAgencia = new bool[] {false} ;
         BC001A54_A586PropostaPacienteTipoPix = new string[] {""} ;
         BC001A54_n586PropostaPacienteTipoPix = new bool[] {false} ;
         BC001A54_A587PropostaPacientePIX = new string[] {""} ;
         BC001A54_n587PropostaPacientePIX = new bool[] {false} ;
         BC001A54_A588PropostaPacienteDepositoTipo = new string[] {""} ;
         BC001A54_n588PropostaPacienteDepositoTipo = new bool[] {false} ;
         BC001A54_A620PropostaPacienteEnderecoCEP = new string[] {""} ;
         BC001A54_n620PropostaPacienteEnderecoCEP = new bool[] {false} ;
         BC001A54_A621PropostaPacienteEnderecoLogradouro = new string[] {""} ;
         BC001A54_n621PropostaPacienteEnderecoLogradouro = new bool[] {false} ;
         BC001A54_A622PropostaPacienteEnderecoNumero = new string[] {""} ;
         BC001A54_n622PropostaPacienteEnderecoNumero = new bool[] {false} ;
         BC001A54_A623PropostaPacienteEnderecoComplemento = new string[] {""} ;
         BC001A54_n623PropostaPacienteEnderecoComplemento = new bool[] {false} ;
         BC001A54_A624PropostaPacienteEnderecoBairro = new string[] {""} ;
         BC001A54_n624PropostaPacienteEnderecoBairro = new bool[] {false} ;
         BC001A54_A324PropostaTitulo = new string[] {""} ;
         BC001A54_n324PropostaTitulo = new bool[] {false} ;
         BC001A54_A325PropostaDescricao = new string[] {""} ;
         BC001A54_n325PropostaDescricao = new bool[] {false} ;
         BC001A54_A517PropostaDataCirurgia = new DateTime[] {DateTime.MinValue} ;
         BC001A54_n517PropostaDataCirurgia = new bool[] {false} ;
         BC001A54_A326PropostaValor = new decimal[1] ;
         BC001A54_n326PropostaValor = new bool[] {false} ;
         BC001A54_A855PropostaValorLiquido = new decimal[1] ;
         BC001A54_n855PropostaValorLiquido = new bool[] {false} ;
         BC001A54_A501PropostaTaxaAdministrativa = new decimal[1] ;
         BC001A54_n501PropostaTaxaAdministrativa = new bool[] {false} ;
         BC001A54_A507PropostaSLA = new short[1] ;
         BC001A54_n507PropostaSLA = new bool[] {false} ;
         BC001A54_A508PropostaJurosMora = new decimal[1] ;
         BC001A54_n508PropostaJurosMora = new bool[] {false} ;
         BC001A54_A643PropostaClinicaNome = new string[] {""} ;
         BC001A54_n643PropostaClinicaNome = new bool[] {false} ;
         BC001A54_A644PropostaClinicaNomeFantasia = new string[] {""} ;
         BC001A54_n644PropostaClinicaNomeFantasia = new bool[] {false} ;
         BC001A54_A652PropostaClinicaDocumento = new string[] {""} ;
         BC001A54_n652PropostaClinicaDocumento = new bool[] {false} ;
         BC001A54_A653PropostaClinicaEmail = new string[] {""} ;
         BC001A54_n653PropostaClinicaEmail = new bool[] {false} ;
         BC001A54_A512PropostaSecUserName = new string[] {""} ;
         BC001A54_n512PropostaSecUserName = new bool[] {false} ;
         BC001A54_A329PropostaStatus = new string[] {""} ;
         BC001A54_n329PropostaStatus = new bool[] {false} ;
         BC001A54_A790PropostaComentarioAnalise = new string[] {""} ;
         BC001A54_n790PropostaComentarioAnalise = new bool[] {false} ;
         BC001A54_A330PropostaQuantidadeAprovadores = new short[1] ;
         BC001A54_n330PropostaQuantidadeAprovadores = new bool[] {false} ;
         BC001A54_A345PropostaReprovacoesPermitidas = new short[1] ;
         BC001A54_n345PropostaReprovacoesPermitidas = new bool[] {false} ;
         BC001A54_A228ContratoNome = new string[] {""} ;
         BC001A54_n228ContratoNome = new bool[] {false} ;
         BC001A54_A496ConvenioVencimentoAno = new short[1] ;
         BC001A54_n496ConvenioVencimentoAno = new bool[] {false} ;
         BC001A54_A497ConvenioVencimentoMes = new short[1] ;
         BC001A54_n497ConvenioVencimentoMes = new bool[] {false} ;
         BC001A54_A494ConvenioCategoriaDescricao = new string[] {""} ;
         BC001A54_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         BC001A54_A227ContratoId = new int[1] ;
         BC001A54_n227ContratoId = new bool[] {false} ;
         BC001A54_A376ProcedimentosMedicosId = new int[1] ;
         BC001A54_n376ProcedimentosMedicosId = new bool[] {false} ;
         BC001A54_A493ConvenioCategoriaId = new int[1] ;
         BC001A54_n493ConvenioCategoriaId = new bool[] {false} ;
         BC001A54_A328PropostaCratedBy = new short[1] ;
         BC001A54_n328PropostaCratedBy = new bool[] {false} ;
         BC001A54_A504PropostaPacienteClienteId = new int[1] ;
         BC001A54_n504PropostaPacienteClienteId = new bool[] {false} ;
         BC001A54_A553PropostaResponsavelId = new int[1] ;
         BC001A54_n553PropostaResponsavelId = new bool[] {false} ;
         BC001A54_A642PropostaClinicaId = new int[1] ;
         BC001A54_n642PropostaClinicaId = new bool[] {false} ;
         BC001A54_A850PropostaEmpresaClienteId = new int[1] ;
         BC001A54_n850PropostaEmpresaClienteId = new bool[] {false} ;
         BC001A54_A410ConvenioId = new int[1] ;
         BC001A54_n410ConvenioId = new bool[] {false} ;
         BC001A54_A625PropostaPacienteMunicipioCodigo = new string[] {""} ;
         BC001A54_n625PropostaPacienteMunicipioCodigo = new bool[] {false} ;
         BC001A54_A649PropostaMaxReembolsoId_F = new int[1] ;
         BC001A54_n649PropostaMaxReembolsoId_F = new bool[] {false} ;
         BC001A54_A854PropostaQtdItensNota_F = new short[1] ;
         BC001A54_n854PropostaQtdItensNota_F = new bool[] {false} ;
         BC001A54_A733PropostaResponsavelSerasaConsultas_F = new short[1] ;
         BC001A54_n733PropostaResponsavelSerasaConsultas_F = new bool[] {false} ;
         BC001A54_A783PropostaResponsavelSerasaScoreUltimaData_F = new short[1] ;
         BC001A54_n783PropostaResponsavelSerasaScoreUltimaData_F = new bool[] {false} ;
         BC001A54_A786PropostaResponsavelSerasaUltimoValorRecomendado_F = new decimal[1] ;
         BC001A54_n786PropostaResponsavelSerasaUltimoValorRecomendado_F = new bool[] {false} ;
         BC001A54_A734PropostaPacienteSerasaConsultas_F = new short[1] ;
         BC001A54_n734PropostaPacienteSerasaConsultas_F = new bool[] {false} ;
         BC001A54_A782PropostaSerasaScoreUltimaData_F = new short[1] ;
         BC001A54_n782PropostaSerasaScoreUltimaData_F = new bool[] {false} ;
         BC001A54_A787PropostaPacienteSerasaUltimoValorRecomendado_F = new decimal[1] ;
         BC001A54_n787PropostaPacienteSerasaUltimoValorRecomendado_F = new bool[] {false} ;
         BC001A54_A655PropostaQtdDocumentoPendente_F = new short[1] ;
         BC001A54_n655PropostaQtdDocumentoPendente_F = new bool[] {false} ;
         BC001A54_A341PropostaAprovacoes_F = new short[1] ;
         BC001A54_n341PropostaAprovacoes_F = new bool[] {false} ;
         BC001A54_A342PropostaReprovacoes_F = new short[1] ;
         BC001A54_n342PropostaReprovacoes_F = new bool[] {false} ;
         BC001A25_A650PropostaValorTaxaClinica_F = new decimal[1] ;
         BC001A25_n650PropostaValorTaxaClinica_F = new bool[] {false} ;
         BC001A14_A509PropostaValorReembolsado_F = new decimal[1] ;
         BC001A14_n509PropostaValorReembolsado_F = new bool[] {false} ;
         BC001A17_A510PropostaValorReembolsadoJuros_F = new decimal[1] ;
         BC001A17_n510PropostaValorReembolsadoJuros_F = new bool[] {false} ;
         BC001A23_A515PropostaDataCreditoCliente_F = new DateTime[] {DateTime.MinValue} ;
         BC001A23_n515PropostaDataCreditoCliente_F = new bool[] {false} ;
         BC001A20_A511PropostaValorTaxaRecebida_F = new decimal[1] ;
         BC001A20_n511PropostaValorTaxaRecebida_F = new bool[] {false} ;
         BC001A27_A649PropostaMaxReembolsoId_F = new int[1] ;
         BC001A27_n649PropostaMaxReembolsoId_F = new bool[] {false} ;
         BC001A29_A854PropostaQtdItensNota_F = new short[1] ;
         BC001A29_n854PropostaQtdItensNota_F = new bool[] {false} ;
         BC001A39_A655PropostaQtdDocumentoPendente_F = new short[1] ;
         BC001A39_n655PropostaQtdDocumentoPendente_F = new bool[] {false} ;
         BC001A41_A341PropostaAprovacoes_F = new short[1] ;
         BC001A41_n341PropostaAprovacoes_F = new bool[] {false} ;
         BC001A43_A342PropostaReprovacoes_F = new short[1] ;
         BC001A43_n342PropostaReprovacoes_F = new bool[] {false} ;
         BC001A11_A850PropostaEmpresaClienteId = new int[1] ;
         BC001A11_n850PropostaEmpresaClienteId = new bool[] {false} ;
         BC001A8_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         BC001A8_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         BC001A8_A540PropostaPacienteClienteDocumento = new string[] {""} ;
         BC001A8_n540PropostaPacienteClienteDocumento = new bool[] {false} ;
         BC001A8_A541PropostaPacienteContatoEmail = new string[] {""} ;
         BC001A8_n541PropostaPacienteContatoEmail = new bool[] {false} ;
         BC001A8_A584PropostaPacienteConta = new string[] {""} ;
         BC001A8_n584PropostaPacienteConta = new bool[] {false} ;
         BC001A8_A585PropostaPacienteAgencia = new string[] {""} ;
         BC001A8_n585PropostaPacienteAgencia = new bool[] {false} ;
         BC001A8_A586PropostaPacienteTipoPix = new string[] {""} ;
         BC001A8_n586PropostaPacienteTipoPix = new bool[] {false} ;
         BC001A8_A587PropostaPacientePIX = new string[] {""} ;
         BC001A8_n587PropostaPacientePIX = new bool[] {false} ;
         BC001A8_A588PropostaPacienteDepositoTipo = new string[] {""} ;
         BC001A8_n588PropostaPacienteDepositoTipo = new bool[] {false} ;
         BC001A8_A620PropostaPacienteEnderecoCEP = new string[] {""} ;
         BC001A8_n620PropostaPacienteEnderecoCEP = new bool[] {false} ;
         BC001A8_A621PropostaPacienteEnderecoLogradouro = new string[] {""} ;
         BC001A8_n621PropostaPacienteEnderecoLogradouro = new bool[] {false} ;
         BC001A8_A622PropostaPacienteEnderecoNumero = new string[] {""} ;
         BC001A8_n622PropostaPacienteEnderecoNumero = new bool[] {false} ;
         BC001A8_A623PropostaPacienteEnderecoComplemento = new string[] {""} ;
         BC001A8_n623PropostaPacienteEnderecoComplemento = new bool[] {false} ;
         BC001A8_A624PropostaPacienteEnderecoBairro = new string[] {""} ;
         BC001A8_n624PropostaPacienteEnderecoBairro = new bool[] {false} ;
         BC001A8_A625PropostaPacienteMunicipioCodigo = new string[] {""} ;
         BC001A8_n625PropostaPacienteMunicipioCodigo = new bool[] {false} ;
         BC001A31_A733PropostaResponsavelSerasaConsultas_F = new short[1] ;
         BC001A31_n733PropostaResponsavelSerasaConsultas_F = new bool[] {false} ;
         BC001A31_A734PropostaPacienteSerasaConsultas_F = new short[1] ;
         BC001A31_n734PropostaPacienteSerasaConsultas_F = new bool[] {false} ;
         BC001A34_A783PropostaResponsavelSerasaScoreUltimaData_F = new short[1] ;
         BC001A34_n783PropostaResponsavelSerasaScoreUltimaData_F = new bool[] {false} ;
         BC001A34_A782PropostaSerasaScoreUltimaData_F = new short[1] ;
         BC001A34_n782PropostaSerasaScoreUltimaData_F = new bool[] {false} ;
         BC001A37_A786PropostaResponsavelSerasaUltimoValorRecomendado_F = new decimal[1] ;
         BC001A37_n786PropostaResponsavelSerasaUltimoValorRecomendado_F = new bool[] {false} ;
         BC001A37_A787PropostaPacienteSerasaUltimoValorRecomendado_F = new decimal[1] ;
         BC001A37_n787PropostaPacienteSerasaUltimoValorRecomendado_F = new bool[] {false} ;
         BC001A9_A580PropostaResponsavelDocumento = new string[] {""} ;
         BC001A9_n580PropostaResponsavelDocumento = new bool[] {false} ;
         BC001A9_A581PropostaResponsavelRazaoSocial = new string[] {""} ;
         BC001A9_n581PropostaResponsavelRazaoSocial = new bool[] {false} ;
         BC001A9_A582PropostaResponsavelEmail = new string[] {""} ;
         BC001A9_n582PropostaResponsavelEmail = new bool[] {false} ;
         BC001A9_A590PropostaResponsavelConta = new string[] {""} ;
         BC001A9_n590PropostaResponsavelConta = new bool[] {false} ;
         BC001A9_A591PropostaResponsavelAgencia = new string[] {""} ;
         BC001A9_n591PropostaResponsavelAgencia = new bool[] {false} ;
         BC001A9_A592PropostaResponsavelTipoPix = new string[] {""} ;
         BC001A9_n592PropostaResponsavelTipoPix = new bool[] {false} ;
         BC001A9_A593PropostaResponsavelPIX = new string[] {""} ;
         BC001A9_n593PropostaResponsavelPIX = new bool[] {false} ;
         BC001A9_A594PropostaResponsavelDepositoTipo = new string[] {""} ;
         BC001A9_n594PropostaResponsavelDepositoTipo = new bool[] {false} ;
         BC001A5_A376ProcedimentosMedicosId = new int[1] ;
         BC001A5_n376ProcedimentosMedicosId = new bool[] {false} ;
         BC001A7_A512PropostaSecUserName = new string[] {""} ;
         BC001A7_n512PropostaSecUserName = new bool[] {false} ;
         BC001A10_A643PropostaClinicaNome = new string[] {""} ;
         BC001A10_n643PropostaClinicaNome = new bool[] {false} ;
         BC001A10_A644PropostaClinicaNomeFantasia = new string[] {""} ;
         BC001A10_n644PropostaClinicaNomeFantasia = new bool[] {false} ;
         BC001A10_A652PropostaClinicaDocumento = new string[] {""} ;
         BC001A10_n652PropostaClinicaDocumento = new bool[] {false} ;
         BC001A10_A653PropostaClinicaEmail = new string[] {""} ;
         BC001A10_n653PropostaClinicaEmail = new bool[] {false} ;
         BC001A4_A228ContratoNome = new string[] {""} ;
         BC001A4_n228ContratoNome = new bool[] {false} ;
         BC001A6_A494ConvenioCategoriaDescricao = new string[] {""} ;
         BC001A6_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         BC001A6_A410ConvenioId = new int[1] ;
         BC001A6_n410ConvenioId = new bool[] {false} ;
         BC001A55_A323PropostaId = new int[1] ;
         BC001A55_n323PropostaId = new bool[] {false} ;
         BC001A3_A323PropostaId = new int[1] ;
         BC001A3_n323PropostaId = new bool[] {false} ;
         BC001A3_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC001A3_n327PropostaCreatedAt = new bool[] {false} ;
         BC001A3_A853PropostaProtocolo = new string[] {""} ;
         BC001A3_n853PropostaProtocolo = new bool[] {false} ;
         BC001A3_A849PropostaTipoProposta = new string[] {""} ;
         BC001A3_n849PropostaTipoProposta = new bool[] {false} ;
         BC001A3_A324PropostaTitulo = new string[] {""} ;
         BC001A3_n324PropostaTitulo = new bool[] {false} ;
         BC001A3_A325PropostaDescricao = new string[] {""} ;
         BC001A3_n325PropostaDescricao = new bool[] {false} ;
         BC001A3_A517PropostaDataCirurgia = new DateTime[] {DateTime.MinValue} ;
         BC001A3_n517PropostaDataCirurgia = new bool[] {false} ;
         BC001A3_A326PropostaValor = new decimal[1] ;
         BC001A3_n326PropostaValor = new bool[] {false} ;
         BC001A3_A855PropostaValorLiquido = new decimal[1] ;
         BC001A3_n855PropostaValorLiquido = new bool[] {false} ;
         BC001A3_A501PropostaTaxaAdministrativa = new decimal[1] ;
         BC001A3_n501PropostaTaxaAdministrativa = new bool[] {false} ;
         BC001A3_A507PropostaSLA = new short[1] ;
         BC001A3_n507PropostaSLA = new bool[] {false} ;
         BC001A3_A508PropostaJurosMora = new decimal[1] ;
         BC001A3_n508PropostaJurosMora = new bool[] {false} ;
         BC001A3_A329PropostaStatus = new string[] {""} ;
         BC001A3_n329PropostaStatus = new bool[] {false} ;
         BC001A3_A790PropostaComentarioAnalise = new string[] {""} ;
         BC001A3_n790PropostaComentarioAnalise = new bool[] {false} ;
         BC001A3_A330PropostaQuantidadeAprovadores = new short[1] ;
         BC001A3_n330PropostaQuantidadeAprovadores = new bool[] {false} ;
         BC001A3_A345PropostaReprovacoesPermitidas = new short[1] ;
         BC001A3_n345PropostaReprovacoesPermitidas = new bool[] {false} ;
         BC001A3_A496ConvenioVencimentoAno = new short[1] ;
         BC001A3_n496ConvenioVencimentoAno = new bool[] {false} ;
         BC001A3_A497ConvenioVencimentoMes = new short[1] ;
         BC001A3_n497ConvenioVencimentoMes = new bool[] {false} ;
         BC001A3_A227ContratoId = new int[1] ;
         BC001A3_n227ContratoId = new bool[] {false} ;
         BC001A3_A376ProcedimentosMedicosId = new int[1] ;
         BC001A3_n376ProcedimentosMedicosId = new bool[] {false} ;
         BC001A3_A493ConvenioCategoriaId = new int[1] ;
         BC001A3_n493ConvenioCategoriaId = new bool[] {false} ;
         BC001A3_A328PropostaCratedBy = new short[1] ;
         BC001A3_n328PropostaCratedBy = new bool[] {false} ;
         BC001A3_A504PropostaPacienteClienteId = new int[1] ;
         BC001A3_n504PropostaPacienteClienteId = new bool[] {false} ;
         BC001A3_A553PropostaResponsavelId = new int[1] ;
         BC001A3_n553PropostaResponsavelId = new bool[] {false} ;
         BC001A3_A642PropostaClinicaId = new int[1] ;
         BC001A3_n642PropostaClinicaId = new bool[] {false} ;
         BC001A3_A850PropostaEmpresaClienteId = new int[1] ;
         BC001A3_n850PropostaEmpresaClienteId = new bool[] {false} ;
         sMode49 = "";
         BC001A2_A323PropostaId = new int[1] ;
         BC001A2_n323PropostaId = new bool[] {false} ;
         BC001A2_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC001A2_n327PropostaCreatedAt = new bool[] {false} ;
         BC001A2_A853PropostaProtocolo = new string[] {""} ;
         BC001A2_n853PropostaProtocolo = new bool[] {false} ;
         BC001A2_A849PropostaTipoProposta = new string[] {""} ;
         BC001A2_n849PropostaTipoProposta = new bool[] {false} ;
         BC001A2_A324PropostaTitulo = new string[] {""} ;
         BC001A2_n324PropostaTitulo = new bool[] {false} ;
         BC001A2_A325PropostaDescricao = new string[] {""} ;
         BC001A2_n325PropostaDescricao = new bool[] {false} ;
         BC001A2_A517PropostaDataCirurgia = new DateTime[] {DateTime.MinValue} ;
         BC001A2_n517PropostaDataCirurgia = new bool[] {false} ;
         BC001A2_A326PropostaValor = new decimal[1] ;
         BC001A2_n326PropostaValor = new bool[] {false} ;
         BC001A2_A855PropostaValorLiquido = new decimal[1] ;
         BC001A2_n855PropostaValorLiquido = new bool[] {false} ;
         BC001A2_A501PropostaTaxaAdministrativa = new decimal[1] ;
         BC001A2_n501PropostaTaxaAdministrativa = new bool[] {false} ;
         BC001A2_A507PropostaSLA = new short[1] ;
         BC001A2_n507PropostaSLA = new bool[] {false} ;
         BC001A2_A508PropostaJurosMora = new decimal[1] ;
         BC001A2_n508PropostaJurosMora = new bool[] {false} ;
         BC001A2_A329PropostaStatus = new string[] {""} ;
         BC001A2_n329PropostaStatus = new bool[] {false} ;
         BC001A2_A790PropostaComentarioAnalise = new string[] {""} ;
         BC001A2_n790PropostaComentarioAnalise = new bool[] {false} ;
         BC001A2_A330PropostaQuantidadeAprovadores = new short[1] ;
         BC001A2_n330PropostaQuantidadeAprovadores = new bool[] {false} ;
         BC001A2_A345PropostaReprovacoesPermitidas = new short[1] ;
         BC001A2_n345PropostaReprovacoesPermitidas = new bool[] {false} ;
         BC001A2_A496ConvenioVencimentoAno = new short[1] ;
         BC001A2_n496ConvenioVencimentoAno = new bool[] {false} ;
         BC001A2_A497ConvenioVencimentoMes = new short[1] ;
         BC001A2_n497ConvenioVencimentoMes = new bool[] {false} ;
         BC001A2_A227ContratoId = new int[1] ;
         BC001A2_n227ContratoId = new bool[] {false} ;
         BC001A2_A376ProcedimentosMedicosId = new int[1] ;
         BC001A2_n376ProcedimentosMedicosId = new bool[] {false} ;
         BC001A2_A493ConvenioCategoriaId = new int[1] ;
         BC001A2_n493ConvenioCategoriaId = new bool[] {false} ;
         BC001A2_A328PropostaCratedBy = new short[1] ;
         BC001A2_n328PropostaCratedBy = new bool[] {false} ;
         BC001A2_A504PropostaPacienteClienteId = new int[1] ;
         BC001A2_n504PropostaPacienteClienteId = new bool[] {false} ;
         BC001A2_A553PropostaResponsavelId = new int[1] ;
         BC001A2_n553PropostaResponsavelId = new bool[] {false} ;
         BC001A2_A642PropostaClinicaId = new int[1] ;
         BC001A2_n642PropostaClinicaId = new bool[] {false} ;
         BC001A2_A850PropostaEmpresaClienteId = new int[1] ;
         BC001A2_n850PropostaEmpresaClienteId = new bool[] {false} ;
         BC001A57_A323PropostaId = new int[1] ;
         BC001A57_n323PropostaId = new bool[] {false} ;
         BC001A61_A649PropostaMaxReembolsoId_F = new int[1] ;
         BC001A61_n649PropostaMaxReembolsoId_F = new bool[] {false} ;
         BC001A63_A854PropostaQtdItensNota_F = new short[1] ;
         BC001A63_n854PropostaQtdItensNota_F = new bool[] {false} ;
         BC001A65_A655PropostaQtdDocumentoPendente_F = new short[1] ;
         BC001A65_n655PropostaQtdDocumentoPendente_F = new bool[] {false} ;
         BC001A67_A341PropostaAprovacoes_F = new short[1] ;
         BC001A67_n341PropostaAprovacoes_F = new bool[] {false} ;
         BC001A69_A342PropostaReprovacoes_F = new short[1] ;
         BC001A69_n342PropostaReprovacoes_F = new bool[] {false} ;
         BC001A70_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         BC001A70_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         BC001A70_A540PropostaPacienteClienteDocumento = new string[] {""} ;
         BC001A70_n540PropostaPacienteClienteDocumento = new bool[] {false} ;
         BC001A70_A541PropostaPacienteContatoEmail = new string[] {""} ;
         BC001A70_n541PropostaPacienteContatoEmail = new bool[] {false} ;
         BC001A70_A584PropostaPacienteConta = new string[] {""} ;
         BC001A70_n584PropostaPacienteConta = new bool[] {false} ;
         BC001A70_A585PropostaPacienteAgencia = new string[] {""} ;
         BC001A70_n585PropostaPacienteAgencia = new bool[] {false} ;
         BC001A70_A586PropostaPacienteTipoPix = new string[] {""} ;
         BC001A70_n586PropostaPacienteTipoPix = new bool[] {false} ;
         BC001A70_A587PropostaPacientePIX = new string[] {""} ;
         BC001A70_n587PropostaPacientePIX = new bool[] {false} ;
         BC001A70_A588PropostaPacienteDepositoTipo = new string[] {""} ;
         BC001A70_n588PropostaPacienteDepositoTipo = new bool[] {false} ;
         BC001A70_A620PropostaPacienteEnderecoCEP = new string[] {""} ;
         BC001A70_n620PropostaPacienteEnderecoCEP = new bool[] {false} ;
         BC001A70_A621PropostaPacienteEnderecoLogradouro = new string[] {""} ;
         BC001A70_n621PropostaPacienteEnderecoLogradouro = new bool[] {false} ;
         BC001A70_A622PropostaPacienteEnderecoNumero = new string[] {""} ;
         BC001A70_n622PropostaPacienteEnderecoNumero = new bool[] {false} ;
         BC001A70_A623PropostaPacienteEnderecoComplemento = new string[] {""} ;
         BC001A70_n623PropostaPacienteEnderecoComplemento = new bool[] {false} ;
         BC001A70_A624PropostaPacienteEnderecoBairro = new string[] {""} ;
         BC001A70_n624PropostaPacienteEnderecoBairro = new bool[] {false} ;
         BC001A70_A625PropostaPacienteMunicipioCodigo = new string[] {""} ;
         BC001A70_n625PropostaPacienteMunicipioCodigo = new bool[] {false} ;
         BC001A73_A509PropostaValorReembolsado_F = new decimal[1] ;
         BC001A73_n509PropostaValorReembolsado_F = new bool[] {false} ;
         BC001A76_A510PropostaValorReembolsadoJuros_F = new decimal[1] ;
         BC001A76_n510PropostaValorReembolsadoJuros_F = new bool[] {false} ;
         BC001A79_A515PropostaDataCreditoCliente_F = new DateTime[] {DateTime.MinValue} ;
         BC001A79_n515PropostaDataCreditoCliente_F = new bool[] {false} ;
         BC001A81_A733PropostaResponsavelSerasaConsultas_F = new short[1] ;
         BC001A81_n733PropostaResponsavelSerasaConsultas_F = new bool[] {false} ;
         BC001A81_A734PropostaPacienteSerasaConsultas_F = new short[1] ;
         BC001A81_n734PropostaPacienteSerasaConsultas_F = new bool[] {false} ;
         BC001A84_A783PropostaResponsavelSerasaScoreUltimaData_F = new short[1] ;
         BC001A84_n783PropostaResponsavelSerasaScoreUltimaData_F = new bool[] {false} ;
         BC001A84_A782PropostaSerasaScoreUltimaData_F = new short[1] ;
         BC001A84_n782PropostaSerasaScoreUltimaData_F = new bool[] {false} ;
         BC001A87_A786PropostaResponsavelSerasaUltimoValorRecomendado_F = new decimal[1] ;
         BC001A87_n786PropostaResponsavelSerasaUltimoValorRecomendado_F = new bool[] {false} ;
         BC001A87_A787PropostaPacienteSerasaUltimoValorRecomendado_F = new decimal[1] ;
         BC001A87_n787PropostaPacienteSerasaUltimoValorRecomendado_F = new bool[] {false} ;
         BC001A88_A580PropostaResponsavelDocumento = new string[] {""} ;
         BC001A88_n580PropostaResponsavelDocumento = new bool[] {false} ;
         BC001A88_A581PropostaResponsavelRazaoSocial = new string[] {""} ;
         BC001A88_n581PropostaResponsavelRazaoSocial = new bool[] {false} ;
         BC001A88_A582PropostaResponsavelEmail = new string[] {""} ;
         BC001A88_n582PropostaResponsavelEmail = new bool[] {false} ;
         BC001A88_A590PropostaResponsavelConta = new string[] {""} ;
         BC001A88_n590PropostaResponsavelConta = new bool[] {false} ;
         BC001A88_A591PropostaResponsavelAgencia = new string[] {""} ;
         BC001A88_n591PropostaResponsavelAgencia = new bool[] {false} ;
         BC001A88_A592PropostaResponsavelTipoPix = new string[] {""} ;
         BC001A88_n592PropostaResponsavelTipoPix = new bool[] {false} ;
         BC001A88_A593PropostaResponsavelPIX = new string[] {""} ;
         BC001A88_n593PropostaResponsavelPIX = new bool[] {false} ;
         BC001A88_A594PropostaResponsavelDepositoTipo = new string[] {""} ;
         BC001A88_n594PropostaResponsavelDepositoTipo = new bool[] {false} ;
         BC001A89_A512PropostaSecUserName = new string[] {""} ;
         BC001A89_n512PropostaSecUserName = new bool[] {false} ;
         BC001A92_A511PropostaValorTaxaRecebida_F = new decimal[1] ;
         BC001A92_n511PropostaValorTaxaRecebida_F = new bool[] {false} ;
         BC001A93_A643PropostaClinicaNome = new string[] {""} ;
         BC001A93_n643PropostaClinicaNome = new bool[] {false} ;
         BC001A93_A644PropostaClinicaNomeFantasia = new string[] {""} ;
         BC001A93_n644PropostaClinicaNomeFantasia = new bool[] {false} ;
         BC001A93_A652PropostaClinicaDocumento = new string[] {""} ;
         BC001A93_n652PropostaClinicaDocumento = new bool[] {false} ;
         BC001A93_A653PropostaClinicaEmail = new string[] {""} ;
         BC001A93_n653PropostaClinicaEmail = new bool[] {false} ;
         BC001A95_A650PropostaValorTaxaClinica_F = new decimal[1] ;
         BC001A95_n650PropostaValorTaxaClinica_F = new bool[] {false} ;
         BC001A96_A228ContratoNome = new string[] {""} ;
         BC001A96_n228ContratoNome = new bool[] {false} ;
         BC001A97_A494ConvenioCategoriaDescricao = new string[] {""} ;
         BC001A97_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         BC001A97_A410ConvenioId = new int[1] ;
         BC001A97_n410ConvenioId = new bool[] {false} ;
         BC001A98_A227ContratoId = new int[1] ;
         BC001A98_n227ContratoId = new bool[] {false} ;
         BC001A99_A518ReembolsoId = new int[1] ;
         BC001A100_A261TituloId = new int[1] ;
         BC001A100_n261TituloId = new bool[] {false} ;
         BC001A101_A830NotaFiscalItemId = new Guid[] {Guid.Empty} ;
         BC001A102_A572PropostaContratoAssinaturaId = new int[1] ;
         BC001A103_A414PropostaDocumentosId = new int[1] ;
         BC001A104_A336AprovacaoId = new int[1] ;
         BC001A115_A323PropostaId = new int[1] ;
         BC001A115_n323PropostaId = new bool[] {false} ;
         BC001A115_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC001A115_n327PropostaCreatedAt = new bool[] {false} ;
         BC001A115_A853PropostaProtocolo = new string[] {""} ;
         BC001A115_n853PropostaProtocolo = new bool[] {false} ;
         BC001A115_A849PropostaTipoProposta = new string[] {""} ;
         BC001A115_n849PropostaTipoProposta = new bool[] {false} ;
         BC001A115_A580PropostaResponsavelDocumento = new string[] {""} ;
         BC001A115_n580PropostaResponsavelDocumento = new bool[] {false} ;
         BC001A115_A581PropostaResponsavelRazaoSocial = new string[] {""} ;
         BC001A115_n581PropostaResponsavelRazaoSocial = new bool[] {false} ;
         BC001A115_A582PropostaResponsavelEmail = new string[] {""} ;
         BC001A115_n582PropostaResponsavelEmail = new bool[] {false} ;
         BC001A115_A590PropostaResponsavelConta = new string[] {""} ;
         BC001A115_n590PropostaResponsavelConta = new bool[] {false} ;
         BC001A115_A591PropostaResponsavelAgencia = new string[] {""} ;
         BC001A115_n591PropostaResponsavelAgencia = new bool[] {false} ;
         BC001A115_A592PropostaResponsavelTipoPix = new string[] {""} ;
         BC001A115_n592PropostaResponsavelTipoPix = new bool[] {false} ;
         BC001A115_A593PropostaResponsavelPIX = new string[] {""} ;
         BC001A115_n593PropostaResponsavelPIX = new bool[] {false} ;
         BC001A115_A594PropostaResponsavelDepositoTipo = new string[] {""} ;
         BC001A115_n594PropostaResponsavelDepositoTipo = new bool[] {false} ;
         BC001A115_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         BC001A115_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         BC001A115_A540PropostaPacienteClienteDocumento = new string[] {""} ;
         BC001A115_n540PropostaPacienteClienteDocumento = new bool[] {false} ;
         BC001A115_A541PropostaPacienteContatoEmail = new string[] {""} ;
         BC001A115_n541PropostaPacienteContatoEmail = new bool[] {false} ;
         BC001A115_A584PropostaPacienteConta = new string[] {""} ;
         BC001A115_n584PropostaPacienteConta = new bool[] {false} ;
         BC001A115_A585PropostaPacienteAgencia = new string[] {""} ;
         BC001A115_n585PropostaPacienteAgencia = new bool[] {false} ;
         BC001A115_A586PropostaPacienteTipoPix = new string[] {""} ;
         BC001A115_n586PropostaPacienteTipoPix = new bool[] {false} ;
         BC001A115_A587PropostaPacientePIX = new string[] {""} ;
         BC001A115_n587PropostaPacientePIX = new bool[] {false} ;
         BC001A115_A588PropostaPacienteDepositoTipo = new string[] {""} ;
         BC001A115_n588PropostaPacienteDepositoTipo = new bool[] {false} ;
         BC001A115_A620PropostaPacienteEnderecoCEP = new string[] {""} ;
         BC001A115_n620PropostaPacienteEnderecoCEP = new bool[] {false} ;
         BC001A115_A621PropostaPacienteEnderecoLogradouro = new string[] {""} ;
         BC001A115_n621PropostaPacienteEnderecoLogradouro = new bool[] {false} ;
         BC001A115_A622PropostaPacienteEnderecoNumero = new string[] {""} ;
         BC001A115_n622PropostaPacienteEnderecoNumero = new bool[] {false} ;
         BC001A115_A623PropostaPacienteEnderecoComplemento = new string[] {""} ;
         BC001A115_n623PropostaPacienteEnderecoComplemento = new bool[] {false} ;
         BC001A115_A624PropostaPacienteEnderecoBairro = new string[] {""} ;
         BC001A115_n624PropostaPacienteEnderecoBairro = new bool[] {false} ;
         BC001A115_A324PropostaTitulo = new string[] {""} ;
         BC001A115_n324PropostaTitulo = new bool[] {false} ;
         BC001A115_A325PropostaDescricao = new string[] {""} ;
         BC001A115_n325PropostaDescricao = new bool[] {false} ;
         BC001A115_A517PropostaDataCirurgia = new DateTime[] {DateTime.MinValue} ;
         BC001A115_n517PropostaDataCirurgia = new bool[] {false} ;
         BC001A115_A326PropostaValor = new decimal[1] ;
         BC001A115_n326PropostaValor = new bool[] {false} ;
         BC001A115_A855PropostaValorLiquido = new decimal[1] ;
         BC001A115_n855PropostaValorLiquido = new bool[] {false} ;
         BC001A115_A501PropostaTaxaAdministrativa = new decimal[1] ;
         BC001A115_n501PropostaTaxaAdministrativa = new bool[] {false} ;
         BC001A115_A507PropostaSLA = new short[1] ;
         BC001A115_n507PropostaSLA = new bool[] {false} ;
         BC001A115_A508PropostaJurosMora = new decimal[1] ;
         BC001A115_n508PropostaJurosMora = new bool[] {false} ;
         BC001A115_A643PropostaClinicaNome = new string[] {""} ;
         BC001A115_n643PropostaClinicaNome = new bool[] {false} ;
         BC001A115_A644PropostaClinicaNomeFantasia = new string[] {""} ;
         BC001A115_n644PropostaClinicaNomeFantasia = new bool[] {false} ;
         BC001A115_A652PropostaClinicaDocumento = new string[] {""} ;
         BC001A115_n652PropostaClinicaDocumento = new bool[] {false} ;
         BC001A115_A653PropostaClinicaEmail = new string[] {""} ;
         BC001A115_n653PropostaClinicaEmail = new bool[] {false} ;
         BC001A115_A512PropostaSecUserName = new string[] {""} ;
         BC001A115_n512PropostaSecUserName = new bool[] {false} ;
         BC001A115_A329PropostaStatus = new string[] {""} ;
         BC001A115_n329PropostaStatus = new bool[] {false} ;
         BC001A115_A790PropostaComentarioAnalise = new string[] {""} ;
         BC001A115_n790PropostaComentarioAnalise = new bool[] {false} ;
         BC001A115_A330PropostaQuantidadeAprovadores = new short[1] ;
         BC001A115_n330PropostaQuantidadeAprovadores = new bool[] {false} ;
         BC001A115_A345PropostaReprovacoesPermitidas = new short[1] ;
         BC001A115_n345PropostaReprovacoesPermitidas = new bool[] {false} ;
         BC001A115_A228ContratoNome = new string[] {""} ;
         BC001A115_n228ContratoNome = new bool[] {false} ;
         BC001A115_A496ConvenioVencimentoAno = new short[1] ;
         BC001A115_n496ConvenioVencimentoAno = new bool[] {false} ;
         BC001A115_A497ConvenioVencimentoMes = new short[1] ;
         BC001A115_n497ConvenioVencimentoMes = new bool[] {false} ;
         BC001A115_A494ConvenioCategoriaDescricao = new string[] {""} ;
         BC001A115_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         BC001A115_A227ContratoId = new int[1] ;
         BC001A115_n227ContratoId = new bool[] {false} ;
         BC001A115_A376ProcedimentosMedicosId = new int[1] ;
         BC001A115_n376ProcedimentosMedicosId = new bool[] {false} ;
         BC001A115_A493ConvenioCategoriaId = new int[1] ;
         BC001A115_n493ConvenioCategoriaId = new bool[] {false} ;
         BC001A115_A328PropostaCratedBy = new short[1] ;
         BC001A115_n328PropostaCratedBy = new bool[] {false} ;
         BC001A115_A504PropostaPacienteClienteId = new int[1] ;
         BC001A115_n504PropostaPacienteClienteId = new bool[] {false} ;
         BC001A115_A553PropostaResponsavelId = new int[1] ;
         BC001A115_n553PropostaResponsavelId = new bool[] {false} ;
         BC001A115_A642PropostaClinicaId = new int[1] ;
         BC001A115_n642PropostaClinicaId = new bool[] {false} ;
         BC001A115_A850PropostaEmpresaClienteId = new int[1] ;
         BC001A115_n850PropostaEmpresaClienteId = new bool[] {false} ;
         BC001A115_A410ConvenioId = new int[1] ;
         BC001A115_n410ConvenioId = new bool[] {false} ;
         BC001A115_A625PropostaPacienteMunicipioCodigo = new string[] {""} ;
         BC001A115_n625PropostaPacienteMunicipioCodigo = new bool[] {false} ;
         BC001A115_A649PropostaMaxReembolsoId_F = new int[1] ;
         BC001A115_n649PropostaMaxReembolsoId_F = new bool[] {false} ;
         BC001A115_A854PropostaQtdItensNota_F = new short[1] ;
         BC001A115_n854PropostaQtdItensNota_F = new bool[] {false} ;
         BC001A115_A733PropostaResponsavelSerasaConsultas_F = new short[1] ;
         BC001A115_n733PropostaResponsavelSerasaConsultas_F = new bool[] {false} ;
         BC001A115_A783PropostaResponsavelSerasaScoreUltimaData_F = new short[1] ;
         BC001A115_n783PropostaResponsavelSerasaScoreUltimaData_F = new bool[] {false} ;
         BC001A115_A786PropostaResponsavelSerasaUltimoValorRecomendado_F = new decimal[1] ;
         BC001A115_n786PropostaResponsavelSerasaUltimoValorRecomendado_F = new bool[] {false} ;
         BC001A115_A734PropostaPacienteSerasaConsultas_F = new short[1] ;
         BC001A115_n734PropostaPacienteSerasaConsultas_F = new bool[] {false} ;
         BC001A115_A782PropostaSerasaScoreUltimaData_F = new short[1] ;
         BC001A115_n782PropostaSerasaScoreUltimaData_F = new bool[] {false} ;
         BC001A115_A787PropostaPacienteSerasaUltimoValorRecomendado_F = new decimal[1] ;
         BC001A115_n787PropostaPacienteSerasaUltimoValorRecomendado_F = new bool[] {false} ;
         BC001A115_A655PropostaQtdDocumentoPendente_F = new short[1] ;
         BC001A115_n655PropostaQtdDocumentoPendente_F = new bool[] {false} ;
         BC001A115_A341PropostaAprovacoes_F = new short[1] ;
         BC001A115_n341PropostaAprovacoes_F = new bool[] {false} ;
         BC001A115_A342PropostaReprovacoes_F = new short[1] ;
         BC001A115_n342PropostaReprovacoes_F = new bool[] {false} ;
         i327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.proposta_bc__default(),
            new Object[][] {
                new Object[] {
               BC001A2_A323PropostaId, BC001A2_A327PropostaCreatedAt, BC001A2_n327PropostaCreatedAt, BC001A2_A853PropostaProtocolo, BC001A2_n853PropostaProtocolo, BC001A2_A849PropostaTipoProposta, BC001A2_n849PropostaTipoProposta, BC001A2_A324PropostaTitulo, BC001A2_n324PropostaTitulo, BC001A2_A325PropostaDescricao,
               BC001A2_n325PropostaDescricao, BC001A2_A517PropostaDataCirurgia, BC001A2_n517PropostaDataCirurgia, BC001A2_A326PropostaValor, BC001A2_n326PropostaValor, BC001A2_A855PropostaValorLiquido, BC001A2_n855PropostaValorLiquido, BC001A2_A501PropostaTaxaAdministrativa, BC001A2_n501PropostaTaxaAdministrativa, BC001A2_A507PropostaSLA,
               BC001A2_n507PropostaSLA, BC001A2_A508PropostaJurosMora, BC001A2_n508PropostaJurosMora, BC001A2_A329PropostaStatus, BC001A2_n329PropostaStatus, BC001A2_A790PropostaComentarioAnalise, BC001A2_n790PropostaComentarioAnalise, BC001A2_A330PropostaQuantidadeAprovadores, BC001A2_n330PropostaQuantidadeAprovadores, BC001A2_A345PropostaReprovacoesPermitidas,
               BC001A2_n345PropostaReprovacoesPermitidas, BC001A2_A496ConvenioVencimentoAno, BC001A2_n496ConvenioVencimentoAno, BC001A2_A497ConvenioVencimentoMes, BC001A2_n497ConvenioVencimentoMes, BC001A2_A227ContratoId, BC001A2_n227ContratoId, BC001A2_A376ProcedimentosMedicosId, BC001A2_n376ProcedimentosMedicosId, BC001A2_A493ConvenioCategoriaId,
               BC001A2_n493ConvenioCategoriaId, BC001A2_A328PropostaCratedBy, BC001A2_n328PropostaCratedBy, BC001A2_A504PropostaPacienteClienteId, BC001A2_n504PropostaPacienteClienteId, BC001A2_A553PropostaResponsavelId, BC001A2_n553PropostaResponsavelId, BC001A2_A642PropostaClinicaId, BC001A2_n642PropostaClinicaId, BC001A2_A850PropostaEmpresaClienteId,
               BC001A2_n850PropostaEmpresaClienteId
               }
               , new Object[] {
               BC001A3_A323PropostaId, BC001A3_A327PropostaCreatedAt, BC001A3_n327PropostaCreatedAt, BC001A3_A853PropostaProtocolo, BC001A3_n853PropostaProtocolo, BC001A3_A849PropostaTipoProposta, BC001A3_n849PropostaTipoProposta, BC001A3_A324PropostaTitulo, BC001A3_n324PropostaTitulo, BC001A3_A325PropostaDescricao,
               BC001A3_n325PropostaDescricao, BC001A3_A517PropostaDataCirurgia, BC001A3_n517PropostaDataCirurgia, BC001A3_A326PropostaValor, BC001A3_n326PropostaValor, BC001A3_A855PropostaValorLiquido, BC001A3_n855PropostaValorLiquido, BC001A3_A501PropostaTaxaAdministrativa, BC001A3_n501PropostaTaxaAdministrativa, BC001A3_A507PropostaSLA,
               BC001A3_n507PropostaSLA, BC001A3_A508PropostaJurosMora, BC001A3_n508PropostaJurosMora, BC001A3_A329PropostaStatus, BC001A3_n329PropostaStatus, BC001A3_A790PropostaComentarioAnalise, BC001A3_n790PropostaComentarioAnalise, BC001A3_A330PropostaQuantidadeAprovadores, BC001A3_n330PropostaQuantidadeAprovadores, BC001A3_A345PropostaReprovacoesPermitidas,
               BC001A3_n345PropostaReprovacoesPermitidas, BC001A3_A496ConvenioVencimentoAno, BC001A3_n496ConvenioVencimentoAno, BC001A3_A497ConvenioVencimentoMes, BC001A3_n497ConvenioVencimentoMes, BC001A3_A227ContratoId, BC001A3_n227ContratoId, BC001A3_A376ProcedimentosMedicosId, BC001A3_n376ProcedimentosMedicosId, BC001A3_A493ConvenioCategoriaId,
               BC001A3_n493ConvenioCategoriaId, BC001A3_A328PropostaCratedBy, BC001A3_n328PropostaCratedBy, BC001A3_A504PropostaPacienteClienteId, BC001A3_n504PropostaPacienteClienteId, BC001A3_A553PropostaResponsavelId, BC001A3_n553PropostaResponsavelId, BC001A3_A642PropostaClinicaId, BC001A3_n642PropostaClinicaId, BC001A3_A850PropostaEmpresaClienteId,
               BC001A3_n850PropostaEmpresaClienteId
               }
               , new Object[] {
               BC001A4_A228ContratoNome, BC001A4_n228ContratoNome
               }
               , new Object[] {
               BC001A5_A376ProcedimentosMedicosId
               }
               , new Object[] {
               BC001A6_A494ConvenioCategoriaDescricao, BC001A6_n494ConvenioCategoriaDescricao, BC001A6_A410ConvenioId, BC001A6_n410ConvenioId
               }
               , new Object[] {
               BC001A7_A512PropostaSecUserName, BC001A7_n512PropostaSecUserName
               }
               , new Object[] {
               BC001A8_A505PropostaPacienteClienteRazaoSocial, BC001A8_n505PropostaPacienteClienteRazaoSocial, BC001A8_A540PropostaPacienteClienteDocumento, BC001A8_n540PropostaPacienteClienteDocumento, BC001A8_A541PropostaPacienteContatoEmail, BC001A8_n541PropostaPacienteContatoEmail, BC001A8_A584PropostaPacienteConta, BC001A8_n584PropostaPacienteConta, BC001A8_A585PropostaPacienteAgencia, BC001A8_n585PropostaPacienteAgencia,
               BC001A8_A586PropostaPacienteTipoPix, BC001A8_n586PropostaPacienteTipoPix, BC001A8_A587PropostaPacientePIX, BC001A8_n587PropostaPacientePIX, BC001A8_A588PropostaPacienteDepositoTipo, BC001A8_n588PropostaPacienteDepositoTipo, BC001A8_A620PropostaPacienteEnderecoCEP, BC001A8_n620PropostaPacienteEnderecoCEP, BC001A8_A621PropostaPacienteEnderecoLogradouro, BC001A8_n621PropostaPacienteEnderecoLogradouro,
               BC001A8_A622PropostaPacienteEnderecoNumero, BC001A8_n622PropostaPacienteEnderecoNumero, BC001A8_A623PropostaPacienteEnderecoComplemento, BC001A8_n623PropostaPacienteEnderecoComplemento, BC001A8_A624PropostaPacienteEnderecoBairro, BC001A8_n624PropostaPacienteEnderecoBairro, BC001A8_A625PropostaPacienteMunicipioCodigo, BC001A8_n625PropostaPacienteMunicipioCodigo
               }
               , new Object[] {
               BC001A9_A580PropostaResponsavelDocumento, BC001A9_n580PropostaResponsavelDocumento, BC001A9_A581PropostaResponsavelRazaoSocial, BC001A9_n581PropostaResponsavelRazaoSocial, BC001A9_A582PropostaResponsavelEmail, BC001A9_n582PropostaResponsavelEmail, BC001A9_A590PropostaResponsavelConta, BC001A9_n590PropostaResponsavelConta, BC001A9_A591PropostaResponsavelAgencia, BC001A9_n591PropostaResponsavelAgencia,
               BC001A9_A592PropostaResponsavelTipoPix, BC001A9_n592PropostaResponsavelTipoPix, BC001A9_A593PropostaResponsavelPIX, BC001A9_n593PropostaResponsavelPIX, BC001A9_A594PropostaResponsavelDepositoTipo, BC001A9_n594PropostaResponsavelDepositoTipo
               }
               , new Object[] {
               BC001A10_A643PropostaClinicaNome, BC001A10_n643PropostaClinicaNome, BC001A10_A644PropostaClinicaNomeFantasia, BC001A10_n644PropostaClinicaNomeFantasia, BC001A10_A652PropostaClinicaDocumento, BC001A10_n652PropostaClinicaDocumento, BC001A10_A653PropostaClinicaEmail, BC001A10_n653PropostaClinicaEmail
               }
               , new Object[] {
               BC001A11_A850PropostaEmpresaClienteId
               }
               , new Object[] {
               BC001A14_A509PropostaValorReembolsado_F, BC001A14_n509PropostaValorReembolsado_F
               }
               , new Object[] {
               BC001A17_A510PropostaValorReembolsadoJuros_F, BC001A17_n510PropostaValorReembolsadoJuros_F
               }
               , new Object[] {
               BC001A20_A511PropostaValorTaxaRecebida_F, BC001A20_n511PropostaValorTaxaRecebida_F
               }
               , new Object[] {
               BC001A23_A515PropostaDataCreditoCliente_F, BC001A23_n515PropostaDataCreditoCliente_F
               }
               , new Object[] {
               BC001A25_A650PropostaValorTaxaClinica_F, BC001A25_n650PropostaValorTaxaClinica_F
               }
               , new Object[] {
               BC001A27_A649PropostaMaxReembolsoId_F, BC001A27_n649PropostaMaxReembolsoId_F
               }
               , new Object[] {
               BC001A29_A854PropostaQtdItensNota_F, BC001A29_n854PropostaQtdItensNota_F
               }
               , new Object[] {
               BC001A31_A733PropostaResponsavelSerasaConsultas_F, BC001A31_n733PropostaResponsavelSerasaConsultas_F, BC001A31_A734PropostaPacienteSerasaConsultas_F, BC001A31_n734PropostaPacienteSerasaConsultas_F
               }
               , new Object[] {
               BC001A34_A783PropostaResponsavelSerasaScoreUltimaData_F, BC001A34_n783PropostaResponsavelSerasaScoreUltimaData_F, BC001A34_A782PropostaSerasaScoreUltimaData_F, BC001A34_n782PropostaSerasaScoreUltimaData_F
               }
               , new Object[] {
               BC001A37_A786PropostaResponsavelSerasaUltimoValorRecomendado_F, BC001A37_n786PropostaResponsavelSerasaUltimoValorRecomendado_F, BC001A37_A787PropostaPacienteSerasaUltimoValorRecomendado_F, BC001A37_n787PropostaPacienteSerasaUltimoValorRecomendado_F
               }
               , new Object[] {
               BC001A39_A655PropostaQtdDocumentoPendente_F, BC001A39_n655PropostaQtdDocumentoPendente_F
               }
               , new Object[] {
               BC001A41_A341PropostaAprovacoes_F, BC001A41_n341PropostaAprovacoes_F
               }
               , new Object[] {
               BC001A43_A342PropostaReprovacoes_F, BC001A43_n342PropostaReprovacoes_F
               }
               , new Object[] {
               BC001A54_A323PropostaId, BC001A54_A327PropostaCreatedAt, BC001A54_n327PropostaCreatedAt, BC001A54_A853PropostaProtocolo, BC001A54_n853PropostaProtocolo, BC001A54_A849PropostaTipoProposta, BC001A54_n849PropostaTipoProposta, BC001A54_A580PropostaResponsavelDocumento, BC001A54_n580PropostaResponsavelDocumento, BC001A54_A581PropostaResponsavelRazaoSocial,
               BC001A54_n581PropostaResponsavelRazaoSocial, BC001A54_A582PropostaResponsavelEmail, BC001A54_n582PropostaResponsavelEmail, BC001A54_A590PropostaResponsavelConta, BC001A54_n590PropostaResponsavelConta, BC001A54_A591PropostaResponsavelAgencia, BC001A54_n591PropostaResponsavelAgencia, BC001A54_A592PropostaResponsavelTipoPix, BC001A54_n592PropostaResponsavelTipoPix, BC001A54_A593PropostaResponsavelPIX,
               BC001A54_n593PropostaResponsavelPIX, BC001A54_A594PropostaResponsavelDepositoTipo, BC001A54_n594PropostaResponsavelDepositoTipo, BC001A54_A505PropostaPacienteClienteRazaoSocial, BC001A54_n505PropostaPacienteClienteRazaoSocial, BC001A54_A540PropostaPacienteClienteDocumento, BC001A54_n540PropostaPacienteClienteDocumento, BC001A54_A541PropostaPacienteContatoEmail, BC001A54_n541PropostaPacienteContatoEmail, BC001A54_A584PropostaPacienteConta,
               BC001A54_n584PropostaPacienteConta, BC001A54_A585PropostaPacienteAgencia, BC001A54_n585PropostaPacienteAgencia, BC001A54_A586PropostaPacienteTipoPix, BC001A54_n586PropostaPacienteTipoPix, BC001A54_A587PropostaPacientePIX, BC001A54_n587PropostaPacientePIX, BC001A54_A588PropostaPacienteDepositoTipo, BC001A54_n588PropostaPacienteDepositoTipo, BC001A54_A620PropostaPacienteEnderecoCEP,
               BC001A54_n620PropostaPacienteEnderecoCEP, BC001A54_A621PropostaPacienteEnderecoLogradouro, BC001A54_n621PropostaPacienteEnderecoLogradouro, BC001A54_A622PropostaPacienteEnderecoNumero, BC001A54_n622PropostaPacienteEnderecoNumero, BC001A54_A623PropostaPacienteEnderecoComplemento, BC001A54_n623PropostaPacienteEnderecoComplemento, BC001A54_A624PropostaPacienteEnderecoBairro, BC001A54_n624PropostaPacienteEnderecoBairro, BC001A54_A324PropostaTitulo,
               BC001A54_n324PropostaTitulo, BC001A54_A325PropostaDescricao, BC001A54_n325PropostaDescricao, BC001A54_A517PropostaDataCirurgia, BC001A54_n517PropostaDataCirurgia, BC001A54_A326PropostaValor, BC001A54_n326PropostaValor, BC001A54_A855PropostaValorLiquido, BC001A54_n855PropostaValorLiquido, BC001A54_A501PropostaTaxaAdministrativa,
               BC001A54_n501PropostaTaxaAdministrativa, BC001A54_A507PropostaSLA, BC001A54_n507PropostaSLA, BC001A54_A508PropostaJurosMora, BC001A54_n508PropostaJurosMora, BC001A54_A643PropostaClinicaNome, BC001A54_n643PropostaClinicaNome, BC001A54_A644PropostaClinicaNomeFantasia, BC001A54_n644PropostaClinicaNomeFantasia, BC001A54_A652PropostaClinicaDocumento,
               BC001A54_n652PropostaClinicaDocumento, BC001A54_A653PropostaClinicaEmail, BC001A54_n653PropostaClinicaEmail, BC001A54_A512PropostaSecUserName, BC001A54_n512PropostaSecUserName, BC001A54_A329PropostaStatus, BC001A54_n329PropostaStatus, BC001A54_A790PropostaComentarioAnalise, BC001A54_n790PropostaComentarioAnalise, BC001A54_A330PropostaQuantidadeAprovadores,
               BC001A54_n330PropostaQuantidadeAprovadores, BC001A54_A345PropostaReprovacoesPermitidas, BC001A54_n345PropostaReprovacoesPermitidas, BC001A54_A228ContratoNome, BC001A54_n228ContratoNome, BC001A54_A496ConvenioVencimentoAno, BC001A54_n496ConvenioVencimentoAno, BC001A54_A497ConvenioVencimentoMes, BC001A54_n497ConvenioVencimentoMes, BC001A54_A494ConvenioCategoriaDescricao,
               BC001A54_n494ConvenioCategoriaDescricao, BC001A54_A227ContratoId, BC001A54_n227ContratoId, BC001A54_A376ProcedimentosMedicosId, BC001A54_n376ProcedimentosMedicosId, BC001A54_A493ConvenioCategoriaId, BC001A54_n493ConvenioCategoriaId, BC001A54_A328PropostaCratedBy, BC001A54_n328PropostaCratedBy, BC001A54_A504PropostaPacienteClienteId,
               BC001A54_n504PropostaPacienteClienteId, BC001A54_A553PropostaResponsavelId, BC001A54_n553PropostaResponsavelId, BC001A54_A642PropostaClinicaId, BC001A54_n642PropostaClinicaId, BC001A54_A850PropostaEmpresaClienteId, BC001A54_n850PropostaEmpresaClienteId, BC001A54_A410ConvenioId, BC001A54_n410ConvenioId, BC001A54_A625PropostaPacienteMunicipioCodigo,
               BC001A54_n625PropostaPacienteMunicipioCodigo, BC001A54_A649PropostaMaxReembolsoId_F, BC001A54_n649PropostaMaxReembolsoId_F, BC001A54_A854PropostaQtdItensNota_F, BC001A54_n854PropostaQtdItensNota_F, BC001A54_A733PropostaResponsavelSerasaConsultas_F, BC001A54_n733PropostaResponsavelSerasaConsultas_F, BC001A54_A783PropostaResponsavelSerasaScoreUltimaData_F, BC001A54_n783PropostaResponsavelSerasaScoreUltimaData_F, BC001A54_A786PropostaResponsavelSerasaUltimoValorRecomendado_F,
               BC001A54_n786PropostaResponsavelSerasaUltimoValorRecomendado_F, BC001A54_A734PropostaPacienteSerasaConsultas_F, BC001A54_n734PropostaPacienteSerasaConsultas_F, BC001A54_A782PropostaSerasaScoreUltimaData_F, BC001A54_n782PropostaSerasaScoreUltimaData_F, BC001A54_A787PropostaPacienteSerasaUltimoValorRecomendado_F, BC001A54_n787PropostaPacienteSerasaUltimoValorRecomendado_F, BC001A54_A655PropostaQtdDocumentoPendente_F, BC001A54_n655PropostaQtdDocumentoPendente_F, BC001A54_A341PropostaAprovacoes_F,
               BC001A54_n341PropostaAprovacoes_F, BC001A54_A342PropostaReprovacoes_F, BC001A54_n342PropostaReprovacoes_F
               }
               , new Object[] {
               BC001A55_A323PropostaId
               }
               , new Object[] {
               }
               , new Object[] {
               BC001A57_A323PropostaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001A61_A649PropostaMaxReembolsoId_F, BC001A61_n649PropostaMaxReembolsoId_F
               }
               , new Object[] {
               BC001A63_A854PropostaQtdItensNota_F, BC001A63_n854PropostaQtdItensNota_F
               }
               , new Object[] {
               BC001A65_A655PropostaQtdDocumentoPendente_F, BC001A65_n655PropostaQtdDocumentoPendente_F
               }
               , new Object[] {
               BC001A67_A341PropostaAprovacoes_F, BC001A67_n341PropostaAprovacoes_F
               }
               , new Object[] {
               BC001A69_A342PropostaReprovacoes_F, BC001A69_n342PropostaReprovacoes_F
               }
               , new Object[] {
               BC001A70_A505PropostaPacienteClienteRazaoSocial, BC001A70_n505PropostaPacienteClienteRazaoSocial, BC001A70_A540PropostaPacienteClienteDocumento, BC001A70_n540PropostaPacienteClienteDocumento, BC001A70_A541PropostaPacienteContatoEmail, BC001A70_n541PropostaPacienteContatoEmail, BC001A70_A584PropostaPacienteConta, BC001A70_n584PropostaPacienteConta, BC001A70_A585PropostaPacienteAgencia, BC001A70_n585PropostaPacienteAgencia,
               BC001A70_A586PropostaPacienteTipoPix, BC001A70_n586PropostaPacienteTipoPix, BC001A70_A587PropostaPacientePIX, BC001A70_n587PropostaPacientePIX, BC001A70_A588PropostaPacienteDepositoTipo, BC001A70_n588PropostaPacienteDepositoTipo, BC001A70_A620PropostaPacienteEnderecoCEP, BC001A70_n620PropostaPacienteEnderecoCEP, BC001A70_A621PropostaPacienteEnderecoLogradouro, BC001A70_n621PropostaPacienteEnderecoLogradouro,
               BC001A70_A622PropostaPacienteEnderecoNumero, BC001A70_n622PropostaPacienteEnderecoNumero, BC001A70_A623PropostaPacienteEnderecoComplemento, BC001A70_n623PropostaPacienteEnderecoComplemento, BC001A70_A624PropostaPacienteEnderecoBairro, BC001A70_n624PropostaPacienteEnderecoBairro, BC001A70_A625PropostaPacienteMunicipioCodigo, BC001A70_n625PropostaPacienteMunicipioCodigo
               }
               , new Object[] {
               BC001A73_A509PropostaValorReembolsado_F, BC001A73_n509PropostaValorReembolsado_F
               }
               , new Object[] {
               BC001A76_A510PropostaValorReembolsadoJuros_F, BC001A76_n510PropostaValorReembolsadoJuros_F
               }
               , new Object[] {
               BC001A79_A515PropostaDataCreditoCliente_F, BC001A79_n515PropostaDataCreditoCliente_F
               }
               , new Object[] {
               BC001A81_A733PropostaResponsavelSerasaConsultas_F, BC001A81_n733PropostaResponsavelSerasaConsultas_F, BC001A81_A734PropostaPacienteSerasaConsultas_F, BC001A81_n734PropostaPacienteSerasaConsultas_F
               }
               , new Object[] {
               BC001A84_A783PropostaResponsavelSerasaScoreUltimaData_F, BC001A84_n783PropostaResponsavelSerasaScoreUltimaData_F, BC001A84_A782PropostaSerasaScoreUltimaData_F, BC001A84_n782PropostaSerasaScoreUltimaData_F
               }
               , new Object[] {
               BC001A87_A786PropostaResponsavelSerasaUltimoValorRecomendado_F, BC001A87_n786PropostaResponsavelSerasaUltimoValorRecomendado_F, BC001A87_A787PropostaPacienteSerasaUltimoValorRecomendado_F, BC001A87_n787PropostaPacienteSerasaUltimoValorRecomendado_F
               }
               , new Object[] {
               BC001A88_A580PropostaResponsavelDocumento, BC001A88_n580PropostaResponsavelDocumento, BC001A88_A581PropostaResponsavelRazaoSocial, BC001A88_n581PropostaResponsavelRazaoSocial, BC001A88_A582PropostaResponsavelEmail, BC001A88_n582PropostaResponsavelEmail, BC001A88_A590PropostaResponsavelConta, BC001A88_n590PropostaResponsavelConta, BC001A88_A591PropostaResponsavelAgencia, BC001A88_n591PropostaResponsavelAgencia,
               BC001A88_A592PropostaResponsavelTipoPix, BC001A88_n592PropostaResponsavelTipoPix, BC001A88_A593PropostaResponsavelPIX, BC001A88_n593PropostaResponsavelPIX, BC001A88_A594PropostaResponsavelDepositoTipo, BC001A88_n594PropostaResponsavelDepositoTipo
               }
               , new Object[] {
               BC001A89_A512PropostaSecUserName, BC001A89_n512PropostaSecUserName
               }
               , new Object[] {
               BC001A92_A511PropostaValorTaxaRecebida_F, BC001A92_n511PropostaValorTaxaRecebida_F
               }
               , new Object[] {
               BC001A93_A643PropostaClinicaNome, BC001A93_n643PropostaClinicaNome, BC001A93_A644PropostaClinicaNomeFantasia, BC001A93_n644PropostaClinicaNomeFantasia, BC001A93_A652PropostaClinicaDocumento, BC001A93_n652PropostaClinicaDocumento, BC001A93_A653PropostaClinicaEmail, BC001A93_n653PropostaClinicaEmail
               }
               , new Object[] {
               BC001A95_A650PropostaValorTaxaClinica_F, BC001A95_n650PropostaValorTaxaClinica_F
               }
               , new Object[] {
               BC001A96_A228ContratoNome, BC001A96_n228ContratoNome
               }
               , new Object[] {
               BC001A97_A494ConvenioCategoriaDescricao, BC001A97_n494ConvenioCategoriaDescricao, BC001A97_A410ConvenioId, BC001A97_n410ConvenioId
               }
               , new Object[] {
               BC001A98_A227ContratoId
               }
               , new Object[] {
               BC001A99_A518ReembolsoId
               }
               , new Object[] {
               BC001A100_A261TituloId
               }
               , new Object[] {
               BC001A101_A830NotaFiscalItemId
               }
               , new Object[] {
               BC001A102_A572PropostaContratoAssinaturaId
               }
               , new Object[] {
               BC001A103_A414PropostaDocumentosId
               }
               , new Object[] {
               BC001A104_A336AprovacaoId
               }
               , new Object[] {
               BC001A115_A323PropostaId, BC001A115_A327PropostaCreatedAt, BC001A115_n327PropostaCreatedAt, BC001A115_A853PropostaProtocolo, BC001A115_n853PropostaProtocolo, BC001A115_A849PropostaTipoProposta, BC001A115_n849PropostaTipoProposta, BC001A115_A580PropostaResponsavelDocumento, BC001A115_n580PropostaResponsavelDocumento, BC001A115_A581PropostaResponsavelRazaoSocial,
               BC001A115_n581PropostaResponsavelRazaoSocial, BC001A115_A582PropostaResponsavelEmail, BC001A115_n582PropostaResponsavelEmail, BC001A115_A590PropostaResponsavelConta, BC001A115_n590PropostaResponsavelConta, BC001A115_A591PropostaResponsavelAgencia, BC001A115_n591PropostaResponsavelAgencia, BC001A115_A592PropostaResponsavelTipoPix, BC001A115_n592PropostaResponsavelTipoPix, BC001A115_A593PropostaResponsavelPIX,
               BC001A115_n593PropostaResponsavelPIX, BC001A115_A594PropostaResponsavelDepositoTipo, BC001A115_n594PropostaResponsavelDepositoTipo, BC001A115_A505PropostaPacienteClienteRazaoSocial, BC001A115_n505PropostaPacienteClienteRazaoSocial, BC001A115_A540PropostaPacienteClienteDocumento, BC001A115_n540PropostaPacienteClienteDocumento, BC001A115_A541PropostaPacienteContatoEmail, BC001A115_n541PropostaPacienteContatoEmail, BC001A115_A584PropostaPacienteConta,
               BC001A115_n584PropostaPacienteConta, BC001A115_A585PropostaPacienteAgencia, BC001A115_n585PropostaPacienteAgencia, BC001A115_A586PropostaPacienteTipoPix, BC001A115_n586PropostaPacienteTipoPix, BC001A115_A587PropostaPacientePIX, BC001A115_n587PropostaPacientePIX, BC001A115_A588PropostaPacienteDepositoTipo, BC001A115_n588PropostaPacienteDepositoTipo, BC001A115_A620PropostaPacienteEnderecoCEP,
               BC001A115_n620PropostaPacienteEnderecoCEP, BC001A115_A621PropostaPacienteEnderecoLogradouro, BC001A115_n621PropostaPacienteEnderecoLogradouro, BC001A115_A622PropostaPacienteEnderecoNumero, BC001A115_n622PropostaPacienteEnderecoNumero, BC001A115_A623PropostaPacienteEnderecoComplemento, BC001A115_n623PropostaPacienteEnderecoComplemento, BC001A115_A624PropostaPacienteEnderecoBairro, BC001A115_n624PropostaPacienteEnderecoBairro, BC001A115_A324PropostaTitulo,
               BC001A115_n324PropostaTitulo, BC001A115_A325PropostaDescricao, BC001A115_n325PropostaDescricao, BC001A115_A517PropostaDataCirurgia, BC001A115_n517PropostaDataCirurgia, BC001A115_A326PropostaValor, BC001A115_n326PropostaValor, BC001A115_A855PropostaValorLiquido, BC001A115_n855PropostaValorLiquido, BC001A115_A501PropostaTaxaAdministrativa,
               BC001A115_n501PropostaTaxaAdministrativa, BC001A115_A507PropostaSLA, BC001A115_n507PropostaSLA, BC001A115_A508PropostaJurosMora, BC001A115_n508PropostaJurosMora, BC001A115_A643PropostaClinicaNome, BC001A115_n643PropostaClinicaNome, BC001A115_A644PropostaClinicaNomeFantasia, BC001A115_n644PropostaClinicaNomeFantasia, BC001A115_A652PropostaClinicaDocumento,
               BC001A115_n652PropostaClinicaDocumento, BC001A115_A653PropostaClinicaEmail, BC001A115_n653PropostaClinicaEmail, BC001A115_A512PropostaSecUserName, BC001A115_n512PropostaSecUserName, BC001A115_A329PropostaStatus, BC001A115_n329PropostaStatus, BC001A115_A790PropostaComentarioAnalise, BC001A115_n790PropostaComentarioAnalise, BC001A115_A330PropostaQuantidadeAprovadores,
               BC001A115_n330PropostaQuantidadeAprovadores, BC001A115_A345PropostaReprovacoesPermitidas, BC001A115_n345PropostaReprovacoesPermitidas, BC001A115_A228ContratoNome, BC001A115_n228ContratoNome, BC001A115_A496ConvenioVencimentoAno, BC001A115_n496ConvenioVencimentoAno, BC001A115_A497ConvenioVencimentoMes, BC001A115_n497ConvenioVencimentoMes, BC001A115_A494ConvenioCategoriaDescricao,
               BC001A115_n494ConvenioCategoriaDescricao, BC001A115_A227ContratoId, BC001A115_n227ContratoId, BC001A115_A376ProcedimentosMedicosId, BC001A115_n376ProcedimentosMedicosId, BC001A115_A493ConvenioCategoriaId, BC001A115_n493ConvenioCategoriaId, BC001A115_A328PropostaCratedBy, BC001A115_n328PropostaCratedBy, BC001A115_A504PropostaPacienteClienteId,
               BC001A115_n504PropostaPacienteClienteId, BC001A115_A553PropostaResponsavelId, BC001A115_n553PropostaResponsavelId, BC001A115_A642PropostaClinicaId, BC001A115_n642PropostaClinicaId, BC001A115_A850PropostaEmpresaClienteId, BC001A115_n850PropostaEmpresaClienteId, BC001A115_A410ConvenioId, BC001A115_n410ConvenioId, BC001A115_A625PropostaPacienteMunicipioCodigo,
               BC001A115_n625PropostaPacienteMunicipioCodigo, BC001A115_A649PropostaMaxReembolsoId_F, BC001A115_n649PropostaMaxReembolsoId_F, BC001A115_A854PropostaQtdItensNota_F, BC001A115_n854PropostaQtdItensNota_F, BC001A115_A733PropostaResponsavelSerasaConsultas_F, BC001A115_n733PropostaResponsavelSerasaConsultas_F, BC001A115_A783PropostaResponsavelSerasaScoreUltimaData_F, BC001A115_n783PropostaResponsavelSerasaScoreUltimaData_F, BC001A115_A786PropostaResponsavelSerasaUltimoValorRecomendado_F,
               BC001A115_n786PropostaResponsavelSerasaUltimoValorRecomendado_F, BC001A115_A734PropostaPacienteSerasaConsultas_F, BC001A115_n734PropostaPacienteSerasaConsultas_F, BC001A115_A782PropostaSerasaScoreUltimaData_F, BC001A115_n782PropostaSerasaScoreUltimaData_F, BC001A115_A787PropostaPacienteSerasaUltimoValorRecomendado_F, BC001A115_n787PropostaPacienteSerasaUltimoValorRecomendado_F, BC001A115_A655PropostaQtdDocumentoPendente_F, BC001A115_n655PropostaQtdDocumentoPendente_F, BC001A115_A341PropostaAprovacoes_F,
               BC001A115_n341PropostaAprovacoes_F, BC001A115_A342PropostaReprovacoes_F, BC001A115_n342PropostaReprovacoes_F
               }
            }
         );
         AV36Pgmname = "Proposta_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121A2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short AV11Insert_PropostaCratedBy ;
      private short Z507PropostaSLA ;
      private short A507PropostaSLA ;
      private short Z330PropostaQuantidadeAprovadores ;
      private short A330PropostaQuantidadeAprovadores ;
      private short Z345PropostaReprovacoesPermitidas ;
      private short A345PropostaReprovacoesPermitidas ;
      private short Z496ConvenioVencimentoAno ;
      private short A496ConvenioVencimentoAno ;
      private short Z497ConvenioVencimentoMes ;
      private short A497ConvenioVencimentoMes ;
      private short Z328PropostaCratedBy ;
      private short A328PropostaCratedBy ;
      private short Z854PropostaQtdItensNota_F ;
      private short A854PropostaQtdItensNota_F ;
      private short Z733PropostaResponsavelSerasaConsultas_F ;
      private short A733PropostaResponsavelSerasaConsultas_F ;
      private short Z783PropostaResponsavelSerasaScoreUltimaData_F ;
      private short A783PropostaResponsavelSerasaScoreUltimaData_F ;
      private short Z734PropostaPacienteSerasaConsultas_F ;
      private short A734PropostaPacienteSerasaConsultas_F ;
      private short Z782PropostaSerasaScoreUltimaData_F ;
      private short A782PropostaSerasaScoreUltimaData_F ;
      private short Z655PropostaQtdDocumentoPendente_F ;
      private short A655PropostaQtdDocumentoPendente_F ;
      private short Z784PropostaMaiorScore_F ;
      private short A784PropostaMaiorScore_F ;
      private short Z341PropostaAprovacoes_F ;
      private short A341PropostaAprovacoes_F ;
      private short Z342PropostaReprovacoes_F ;
      private short A342PropostaReprovacoes_F ;
      private short Z343PropostaAprovacoesRestantes_F ;
      private short A343PropostaAprovacoesRestantes_F ;
      private short RcdFound49 ;
      private int trnEnded ;
      private int Z323PropostaId ;
      private int A323PropostaId ;
      private int AV37GXV1 ;
      private int AV35Insert_PropostaEmpresaClienteId ;
      private int AV32Insert_PropostaPacienteClienteId ;
      private int AV33Insert_PropostaResponsavelId ;
      private int AV24Insert_ProcedimentosMedicosId ;
      private int AV34Insert_PropostaClinicaId ;
      private int AV12Insert_ContratoId ;
      private int AV31Insert_ConvenioCategoriaId ;
      private int Z227ContratoId ;
      private int A227ContratoId ;
      private int Z376ProcedimentosMedicosId ;
      private int A376ProcedimentosMedicosId ;
      private int Z493ConvenioCategoriaId ;
      private int A493ConvenioCategoriaId ;
      private int Z504PropostaPacienteClienteId ;
      private int A504PropostaPacienteClienteId ;
      private int Z553PropostaResponsavelId ;
      private int A553PropostaResponsavelId ;
      private int Z642PropostaClinicaId ;
      private int A642PropostaClinicaId ;
      private int Z850PropostaEmpresaClienteId ;
      private int A850PropostaEmpresaClienteId ;
      private int Z649PropostaMaxReembolsoId_F ;
      private int A649PropostaMaxReembolsoId_F ;
      private int Z410ConvenioId ;
      private int A410ConvenioId ;
      private decimal Z326PropostaValor ;
      private decimal A326PropostaValor ;
      private decimal Z855PropostaValorLiquido ;
      private decimal A855PropostaValorLiquido ;
      private decimal Z501PropostaTaxaAdministrativa ;
      private decimal A501PropostaTaxaAdministrativa ;
      private decimal Z508PropostaJurosMora ;
      private decimal A508PropostaJurosMora ;
      private decimal Z786PropostaResponsavelSerasaUltimoValorRecomendado_F ;
      private decimal A786PropostaResponsavelSerasaUltimoValorRecomendado_F ;
      private decimal Z787PropostaPacienteSerasaUltimoValorRecomendado_F ;
      private decimal A787PropostaPacienteSerasaUltimoValorRecomendado_F ;
      private decimal Z650PropostaValorTaxaClinica_F ;
      private decimal A650PropostaValorTaxaClinica_F ;
      private decimal Z788PropostaMaiorValorRecomendado ;
      private decimal A788PropostaMaiorValorRecomendado ;
      private decimal Z575PropostaTaxa_F ;
      private decimal A575PropostaTaxa_F ;
      private decimal Z513PropostaValorTaxa_F ;
      private decimal A513PropostaValorTaxa_F ;
      private decimal Z514PropostaValorJurosMora_F ;
      private decimal A514PropostaValorJurosMora_F ;
      private decimal Z509PropostaValorReembolsado_F ;
      private decimal A509PropostaValorReembolsado_F ;
      private decimal Z510PropostaValorReembolsadoJuros_F ;
      private decimal A510PropostaValorReembolsadoJuros_F ;
      private decimal Z511PropostaValorTaxaRecebida_F ;
      private decimal A511PropostaValorTaxaRecebida_F ;
      private decimal GXt_decimal1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV36Pgmname ;
      private string sMode49 ;
      private DateTime Z327PropostaCreatedAt ;
      private DateTime A327PropostaCreatedAt ;
      private DateTime i327PropostaCreatedAt ;
      private DateTime Z517PropostaDataCirurgia ;
      private DateTime A517PropostaDataCirurgia ;
      private DateTime Z515PropostaDataCreditoCliente_F ;
      private DateTime A515PropostaDataCreditoCliente_F ;
      private bool returnInSub ;
      private bool n327PropostaCreatedAt ;
      private bool n323PropostaId ;
      private bool n853PropostaProtocolo ;
      private bool n849PropostaTipoProposta ;
      private bool n580PropostaResponsavelDocumento ;
      private bool n581PropostaResponsavelRazaoSocial ;
      private bool n582PropostaResponsavelEmail ;
      private bool n590PropostaResponsavelConta ;
      private bool n591PropostaResponsavelAgencia ;
      private bool n592PropostaResponsavelTipoPix ;
      private bool n593PropostaResponsavelPIX ;
      private bool n594PropostaResponsavelDepositoTipo ;
      private bool n505PropostaPacienteClienteRazaoSocial ;
      private bool n540PropostaPacienteClienteDocumento ;
      private bool n541PropostaPacienteContatoEmail ;
      private bool n584PropostaPacienteConta ;
      private bool n585PropostaPacienteAgencia ;
      private bool n586PropostaPacienteTipoPix ;
      private bool n587PropostaPacientePIX ;
      private bool n588PropostaPacienteDepositoTipo ;
      private bool n620PropostaPacienteEnderecoCEP ;
      private bool n621PropostaPacienteEnderecoLogradouro ;
      private bool n622PropostaPacienteEnderecoNumero ;
      private bool n623PropostaPacienteEnderecoComplemento ;
      private bool n624PropostaPacienteEnderecoBairro ;
      private bool n324PropostaTitulo ;
      private bool n325PropostaDescricao ;
      private bool n517PropostaDataCirurgia ;
      private bool n326PropostaValor ;
      private bool n855PropostaValorLiquido ;
      private bool n501PropostaTaxaAdministrativa ;
      private bool n507PropostaSLA ;
      private bool n508PropostaJurosMora ;
      private bool n643PropostaClinicaNome ;
      private bool n644PropostaClinicaNomeFantasia ;
      private bool n652PropostaClinicaDocumento ;
      private bool n653PropostaClinicaEmail ;
      private bool n512PropostaSecUserName ;
      private bool n329PropostaStatus ;
      private bool n790PropostaComentarioAnalise ;
      private bool n330PropostaQuantidadeAprovadores ;
      private bool n345PropostaReprovacoesPermitidas ;
      private bool n228ContratoNome ;
      private bool n496ConvenioVencimentoAno ;
      private bool n497ConvenioVencimentoMes ;
      private bool n494ConvenioCategoriaDescricao ;
      private bool n227ContratoId ;
      private bool n376ProcedimentosMedicosId ;
      private bool n493ConvenioCategoriaId ;
      private bool n328PropostaCratedBy ;
      private bool n504PropostaPacienteClienteId ;
      private bool n553PropostaResponsavelId ;
      private bool n642PropostaClinicaId ;
      private bool n850PropostaEmpresaClienteId ;
      private bool n410ConvenioId ;
      private bool n625PropostaPacienteMunicipioCodigo ;
      private bool n649PropostaMaxReembolsoId_F ;
      private bool n854PropostaQtdItensNota_F ;
      private bool n733PropostaResponsavelSerasaConsultas_F ;
      private bool n783PropostaResponsavelSerasaScoreUltimaData_F ;
      private bool n786PropostaResponsavelSerasaUltimoValorRecomendado_F ;
      private bool n734PropostaPacienteSerasaConsultas_F ;
      private bool n782PropostaSerasaScoreUltimaData_F ;
      private bool n787PropostaPacienteSerasaUltimoValorRecomendado_F ;
      private bool n655PropostaQtdDocumentoPendente_F ;
      private bool n341PropostaAprovacoes_F ;
      private bool n342PropostaReprovacoes_F ;
      private bool n650PropostaValorTaxaClinica_F ;
      private bool n509PropostaValorReembolsado_F ;
      private bool n510PropostaValorReembolsadoJuros_F ;
      private bool n515PropostaDataCreditoCliente_F ;
      private bool n511PropostaValorTaxaRecebida_F ;
      private bool Gx_longc ;
      private string Z853PropostaProtocolo ;
      private string A853PropostaProtocolo ;
      private string Z849PropostaTipoProposta ;
      private string A849PropostaTipoProposta ;
      private string Z324PropostaTitulo ;
      private string A324PropostaTitulo ;
      private string Z325PropostaDescricao ;
      private string A325PropostaDescricao ;
      private string Z329PropostaStatus ;
      private string A329PropostaStatus ;
      private string Z790PropostaComentarioAnalise ;
      private string A790PropostaComentarioAnalise ;
      private string Z589PropostaResponsavelBanco ;
      private string A589PropostaResponsavelBanco ;
      private string Z583PropostaPacienteBanco ;
      private string A583PropostaPacienteBanco ;
      private string Z228ContratoNome ;
      private string A228ContratoNome ;
      private string Z494ConvenioCategoriaDescricao ;
      private string A494ConvenioCategoriaDescricao ;
      private string Z512PropostaSecUserName ;
      private string A512PropostaSecUserName ;
      private string Z505PropostaPacienteClienteRazaoSocial ;
      private string A505PropostaPacienteClienteRazaoSocial ;
      private string Z540PropostaPacienteClienteDocumento ;
      private string A540PropostaPacienteClienteDocumento ;
      private string Z541PropostaPacienteContatoEmail ;
      private string A541PropostaPacienteContatoEmail ;
      private string Z584PropostaPacienteConta ;
      private string A584PropostaPacienteConta ;
      private string Z585PropostaPacienteAgencia ;
      private string A585PropostaPacienteAgencia ;
      private string Z586PropostaPacienteTipoPix ;
      private string A586PropostaPacienteTipoPix ;
      private string Z587PropostaPacientePIX ;
      private string A587PropostaPacientePIX ;
      private string Z588PropostaPacienteDepositoTipo ;
      private string A588PropostaPacienteDepositoTipo ;
      private string Z620PropostaPacienteEnderecoCEP ;
      private string A620PropostaPacienteEnderecoCEP ;
      private string Z621PropostaPacienteEnderecoLogradouro ;
      private string A621PropostaPacienteEnderecoLogradouro ;
      private string Z622PropostaPacienteEnderecoNumero ;
      private string A622PropostaPacienteEnderecoNumero ;
      private string Z623PropostaPacienteEnderecoComplemento ;
      private string A623PropostaPacienteEnderecoComplemento ;
      private string Z624PropostaPacienteEnderecoBairro ;
      private string A624PropostaPacienteEnderecoBairro ;
      private string Z625PropostaPacienteMunicipioCodigo ;
      private string A625PropostaPacienteMunicipioCodigo ;
      private string Z580PropostaResponsavelDocumento ;
      private string A580PropostaResponsavelDocumento ;
      private string Z581PropostaResponsavelRazaoSocial ;
      private string A581PropostaResponsavelRazaoSocial ;
      private string Z582PropostaResponsavelEmail ;
      private string A582PropostaResponsavelEmail ;
      private string Z590PropostaResponsavelConta ;
      private string A590PropostaResponsavelConta ;
      private string Z591PropostaResponsavelAgencia ;
      private string A591PropostaResponsavelAgencia ;
      private string Z592PropostaResponsavelTipoPix ;
      private string A592PropostaResponsavelTipoPix ;
      private string Z593PropostaResponsavelPIX ;
      private string A593PropostaResponsavelPIX ;
      private string Z594PropostaResponsavelDepositoTipo ;
      private string A594PropostaResponsavelDepositoTipo ;
      private string Z643PropostaClinicaNome ;
      private string A643PropostaClinicaNome ;
      private string Z644PropostaClinicaNomeFantasia ;
      private string A644PropostaClinicaNomeFantasia ;
      private string Z652PropostaClinicaDocumento ;
      private string A652PropostaClinicaDocumento ;
      private string Z653PropostaClinicaEmail ;
      private string A653PropostaClinicaEmail ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] BC001A54_A323PropostaId ;
      private bool[] BC001A54_n323PropostaId ;
      private DateTime[] BC001A54_A327PropostaCreatedAt ;
      private bool[] BC001A54_n327PropostaCreatedAt ;
      private string[] BC001A54_A853PropostaProtocolo ;
      private bool[] BC001A54_n853PropostaProtocolo ;
      private string[] BC001A54_A849PropostaTipoProposta ;
      private bool[] BC001A54_n849PropostaTipoProposta ;
      private string[] BC001A54_A580PropostaResponsavelDocumento ;
      private bool[] BC001A54_n580PropostaResponsavelDocumento ;
      private string[] BC001A54_A581PropostaResponsavelRazaoSocial ;
      private bool[] BC001A54_n581PropostaResponsavelRazaoSocial ;
      private string[] BC001A54_A582PropostaResponsavelEmail ;
      private bool[] BC001A54_n582PropostaResponsavelEmail ;
      private string[] BC001A54_A590PropostaResponsavelConta ;
      private bool[] BC001A54_n590PropostaResponsavelConta ;
      private string[] BC001A54_A591PropostaResponsavelAgencia ;
      private bool[] BC001A54_n591PropostaResponsavelAgencia ;
      private string[] BC001A54_A592PropostaResponsavelTipoPix ;
      private bool[] BC001A54_n592PropostaResponsavelTipoPix ;
      private string[] BC001A54_A593PropostaResponsavelPIX ;
      private bool[] BC001A54_n593PropostaResponsavelPIX ;
      private string[] BC001A54_A594PropostaResponsavelDepositoTipo ;
      private bool[] BC001A54_n594PropostaResponsavelDepositoTipo ;
      private string[] BC001A54_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] BC001A54_n505PropostaPacienteClienteRazaoSocial ;
      private string[] BC001A54_A540PropostaPacienteClienteDocumento ;
      private bool[] BC001A54_n540PropostaPacienteClienteDocumento ;
      private string[] BC001A54_A541PropostaPacienteContatoEmail ;
      private bool[] BC001A54_n541PropostaPacienteContatoEmail ;
      private string[] BC001A54_A584PropostaPacienteConta ;
      private bool[] BC001A54_n584PropostaPacienteConta ;
      private string[] BC001A54_A585PropostaPacienteAgencia ;
      private bool[] BC001A54_n585PropostaPacienteAgencia ;
      private string[] BC001A54_A586PropostaPacienteTipoPix ;
      private bool[] BC001A54_n586PropostaPacienteTipoPix ;
      private string[] BC001A54_A587PropostaPacientePIX ;
      private bool[] BC001A54_n587PropostaPacientePIX ;
      private string[] BC001A54_A588PropostaPacienteDepositoTipo ;
      private bool[] BC001A54_n588PropostaPacienteDepositoTipo ;
      private string[] BC001A54_A620PropostaPacienteEnderecoCEP ;
      private bool[] BC001A54_n620PropostaPacienteEnderecoCEP ;
      private string[] BC001A54_A621PropostaPacienteEnderecoLogradouro ;
      private bool[] BC001A54_n621PropostaPacienteEnderecoLogradouro ;
      private string[] BC001A54_A622PropostaPacienteEnderecoNumero ;
      private bool[] BC001A54_n622PropostaPacienteEnderecoNumero ;
      private string[] BC001A54_A623PropostaPacienteEnderecoComplemento ;
      private bool[] BC001A54_n623PropostaPacienteEnderecoComplemento ;
      private string[] BC001A54_A624PropostaPacienteEnderecoBairro ;
      private bool[] BC001A54_n624PropostaPacienteEnderecoBairro ;
      private string[] BC001A54_A324PropostaTitulo ;
      private bool[] BC001A54_n324PropostaTitulo ;
      private string[] BC001A54_A325PropostaDescricao ;
      private bool[] BC001A54_n325PropostaDescricao ;
      private DateTime[] BC001A54_A517PropostaDataCirurgia ;
      private bool[] BC001A54_n517PropostaDataCirurgia ;
      private decimal[] BC001A54_A326PropostaValor ;
      private bool[] BC001A54_n326PropostaValor ;
      private decimal[] BC001A54_A855PropostaValorLiquido ;
      private bool[] BC001A54_n855PropostaValorLiquido ;
      private decimal[] BC001A54_A501PropostaTaxaAdministrativa ;
      private bool[] BC001A54_n501PropostaTaxaAdministrativa ;
      private short[] BC001A54_A507PropostaSLA ;
      private bool[] BC001A54_n507PropostaSLA ;
      private decimal[] BC001A54_A508PropostaJurosMora ;
      private bool[] BC001A54_n508PropostaJurosMora ;
      private string[] BC001A54_A643PropostaClinicaNome ;
      private bool[] BC001A54_n643PropostaClinicaNome ;
      private string[] BC001A54_A644PropostaClinicaNomeFantasia ;
      private bool[] BC001A54_n644PropostaClinicaNomeFantasia ;
      private string[] BC001A54_A652PropostaClinicaDocumento ;
      private bool[] BC001A54_n652PropostaClinicaDocumento ;
      private string[] BC001A54_A653PropostaClinicaEmail ;
      private bool[] BC001A54_n653PropostaClinicaEmail ;
      private string[] BC001A54_A512PropostaSecUserName ;
      private bool[] BC001A54_n512PropostaSecUserName ;
      private string[] BC001A54_A329PropostaStatus ;
      private bool[] BC001A54_n329PropostaStatus ;
      private string[] BC001A54_A790PropostaComentarioAnalise ;
      private bool[] BC001A54_n790PropostaComentarioAnalise ;
      private short[] BC001A54_A330PropostaQuantidadeAprovadores ;
      private bool[] BC001A54_n330PropostaQuantidadeAprovadores ;
      private short[] BC001A54_A345PropostaReprovacoesPermitidas ;
      private bool[] BC001A54_n345PropostaReprovacoesPermitidas ;
      private string[] BC001A54_A228ContratoNome ;
      private bool[] BC001A54_n228ContratoNome ;
      private short[] BC001A54_A496ConvenioVencimentoAno ;
      private bool[] BC001A54_n496ConvenioVencimentoAno ;
      private short[] BC001A54_A497ConvenioVencimentoMes ;
      private bool[] BC001A54_n497ConvenioVencimentoMes ;
      private string[] BC001A54_A494ConvenioCategoriaDescricao ;
      private bool[] BC001A54_n494ConvenioCategoriaDescricao ;
      private int[] BC001A54_A227ContratoId ;
      private bool[] BC001A54_n227ContratoId ;
      private int[] BC001A54_A376ProcedimentosMedicosId ;
      private bool[] BC001A54_n376ProcedimentosMedicosId ;
      private int[] BC001A54_A493ConvenioCategoriaId ;
      private bool[] BC001A54_n493ConvenioCategoriaId ;
      private short[] BC001A54_A328PropostaCratedBy ;
      private bool[] BC001A54_n328PropostaCratedBy ;
      private int[] BC001A54_A504PropostaPacienteClienteId ;
      private bool[] BC001A54_n504PropostaPacienteClienteId ;
      private int[] BC001A54_A553PropostaResponsavelId ;
      private bool[] BC001A54_n553PropostaResponsavelId ;
      private int[] BC001A54_A642PropostaClinicaId ;
      private bool[] BC001A54_n642PropostaClinicaId ;
      private int[] BC001A54_A850PropostaEmpresaClienteId ;
      private bool[] BC001A54_n850PropostaEmpresaClienteId ;
      private int[] BC001A54_A410ConvenioId ;
      private bool[] BC001A54_n410ConvenioId ;
      private string[] BC001A54_A625PropostaPacienteMunicipioCodigo ;
      private bool[] BC001A54_n625PropostaPacienteMunicipioCodigo ;
      private int[] BC001A54_A649PropostaMaxReembolsoId_F ;
      private bool[] BC001A54_n649PropostaMaxReembolsoId_F ;
      private short[] BC001A54_A854PropostaQtdItensNota_F ;
      private bool[] BC001A54_n854PropostaQtdItensNota_F ;
      private short[] BC001A54_A733PropostaResponsavelSerasaConsultas_F ;
      private bool[] BC001A54_n733PropostaResponsavelSerasaConsultas_F ;
      private short[] BC001A54_A783PropostaResponsavelSerasaScoreUltimaData_F ;
      private bool[] BC001A54_n783PropostaResponsavelSerasaScoreUltimaData_F ;
      private decimal[] BC001A54_A786PropostaResponsavelSerasaUltimoValorRecomendado_F ;
      private bool[] BC001A54_n786PropostaResponsavelSerasaUltimoValorRecomendado_F ;
      private short[] BC001A54_A734PropostaPacienteSerasaConsultas_F ;
      private bool[] BC001A54_n734PropostaPacienteSerasaConsultas_F ;
      private short[] BC001A54_A782PropostaSerasaScoreUltimaData_F ;
      private bool[] BC001A54_n782PropostaSerasaScoreUltimaData_F ;
      private decimal[] BC001A54_A787PropostaPacienteSerasaUltimoValorRecomendado_F ;
      private bool[] BC001A54_n787PropostaPacienteSerasaUltimoValorRecomendado_F ;
      private short[] BC001A54_A655PropostaQtdDocumentoPendente_F ;
      private bool[] BC001A54_n655PropostaQtdDocumentoPendente_F ;
      private short[] BC001A54_A341PropostaAprovacoes_F ;
      private bool[] BC001A54_n341PropostaAprovacoes_F ;
      private short[] BC001A54_A342PropostaReprovacoes_F ;
      private bool[] BC001A54_n342PropostaReprovacoes_F ;
      private decimal[] BC001A25_A650PropostaValorTaxaClinica_F ;
      private bool[] BC001A25_n650PropostaValorTaxaClinica_F ;
      private decimal[] BC001A14_A509PropostaValorReembolsado_F ;
      private bool[] BC001A14_n509PropostaValorReembolsado_F ;
      private decimal[] BC001A17_A510PropostaValorReembolsadoJuros_F ;
      private bool[] BC001A17_n510PropostaValorReembolsadoJuros_F ;
      private DateTime[] BC001A23_A515PropostaDataCreditoCliente_F ;
      private bool[] BC001A23_n515PropostaDataCreditoCliente_F ;
      private decimal[] BC001A20_A511PropostaValorTaxaRecebida_F ;
      private bool[] BC001A20_n511PropostaValorTaxaRecebida_F ;
      private int[] BC001A27_A649PropostaMaxReembolsoId_F ;
      private bool[] BC001A27_n649PropostaMaxReembolsoId_F ;
      private short[] BC001A29_A854PropostaQtdItensNota_F ;
      private bool[] BC001A29_n854PropostaQtdItensNota_F ;
      private short[] BC001A39_A655PropostaQtdDocumentoPendente_F ;
      private bool[] BC001A39_n655PropostaQtdDocumentoPendente_F ;
      private short[] BC001A41_A341PropostaAprovacoes_F ;
      private bool[] BC001A41_n341PropostaAprovacoes_F ;
      private short[] BC001A43_A342PropostaReprovacoes_F ;
      private bool[] BC001A43_n342PropostaReprovacoes_F ;
      private int[] BC001A11_A850PropostaEmpresaClienteId ;
      private bool[] BC001A11_n850PropostaEmpresaClienteId ;
      private string[] BC001A8_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] BC001A8_n505PropostaPacienteClienteRazaoSocial ;
      private string[] BC001A8_A540PropostaPacienteClienteDocumento ;
      private bool[] BC001A8_n540PropostaPacienteClienteDocumento ;
      private string[] BC001A8_A541PropostaPacienteContatoEmail ;
      private bool[] BC001A8_n541PropostaPacienteContatoEmail ;
      private string[] BC001A8_A584PropostaPacienteConta ;
      private bool[] BC001A8_n584PropostaPacienteConta ;
      private string[] BC001A8_A585PropostaPacienteAgencia ;
      private bool[] BC001A8_n585PropostaPacienteAgencia ;
      private string[] BC001A8_A586PropostaPacienteTipoPix ;
      private bool[] BC001A8_n586PropostaPacienteTipoPix ;
      private string[] BC001A8_A587PropostaPacientePIX ;
      private bool[] BC001A8_n587PropostaPacientePIX ;
      private string[] BC001A8_A588PropostaPacienteDepositoTipo ;
      private bool[] BC001A8_n588PropostaPacienteDepositoTipo ;
      private string[] BC001A8_A620PropostaPacienteEnderecoCEP ;
      private bool[] BC001A8_n620PropostaPacienteEnderecoCEP ;
      private string[] BC001A8_A621PropostaPacienteEnderecoLogradouro ;
      private bool[] BC001A8_n621PropostaPacienteEnderecoLogradouro ;
      private string[] BC001A8_A622PropostaPacienteEnderecoNumero ;
      private bool[] BC001A8_n622PropostaPacienteEnderecoNumero ;
      private string[] BC001A8_A623PropostaPacienteEnderecoComplemento ;
      private bool[] BC001A8_n623PropostaPacienteEnderecoComplemento ;
      private string[] BC001A8_A624PropostaPacienteEnderecoBairro ;
      private bool[] BC001A8_n624PropostaPacienteEnderecoBairro ;
      private string[] BC001A8_A625PropostaPacienteMunicipioCodigo ;
      private bool[] BC001A8_n625PropostaPacienteMunicipioCodigo ;
      private short[] BC001A31_A733PropostaResponsavelSerasaConsultas_F ;
      private bool[] BC001A31_n733PropostaResponsavelSerasaConsultas_F ;
      private short[] BC001A31_A734PropostaPacienteSerasaConsultas_F ;
      private bool[] BC001A31_n734PropostaPacienteSerasaConsultas_F ;
      private short[] BC001A34_A783PropostaResponsavelSerasaScoreUltimaData_F ;
      private bool[] BC001A34_n783PropostaResponsavelSerasaScoreUltimaData_F ;
      private short[] BC001A34_A782PropostaSerasaScoreUltimaData_F ;
      private bool[] BC001A34_n782PropostaSerasaScoreUltimaData_F ;
      private decimal[] BC001A37_A786PropostaResponsavelSerasaUltimoValorRecomendado_F ;
      private bool[] BC001A37_n786PropostaResponsavelSerasaUltimoValorRecomendado_F ;
      private decimal[] BC001A37_A787PropostaPacienteSerasaUltimoValorRecomendado_F ;
      private bool[] BC001A37_n787PropostaPacienteSerasaUltimoValorRecomendado_F ;
      private string[] BC001A9_A580PropostaResponsavelDocumento ;
      private bool[] BC001A9_n580PropostaResponsavelDocumento ;
      private string[] BC001A9_A581PropostaResponsavelRazaoSocial ;
      private bool[] BC001A9_n581PropostaResponsavelRazaoSocial ;
      private string[] BC001A9_A582PropostaResponsavelEmail ;
      private bool[] BC001A9_n582PropostaResponsavelEmail ;
      private string[] BC001A9_A590PropostaResponsavelConta ;
      private bool[] BC001A9_n590PropostaResponsavelConta ;
      private string[] BC001A9_A591PropostaResponsavelAgencia ;
      private bool[] BC001A9_n591PropostaResponsavelAgencia ;
      private string[] BC001A9_A592PropostaResponsavelTipoPix ;
      private bool[] BC001A9_n592PropostaResponsavelTipoPix ;
      private string[] BC001A9_A593PropostaResponsavelPIX ;
      private bool[] BC001A9_n593PropostaResponsavelPIX ;
      private string[] BC001A9_A594PropostaResponsavelDepositoTipo ;
      private bool[] BC001A9_n594PropostaResponsavelDepositoTipo ;
      private int[] BC001A5_A376ProcedimentosMedicosId ;
      private bool[] BC001A5_n376ProcedimentosMedicosId ;
      private string[] BC001A7_A512PropostaSecUserName ;
      private bool[] BC001A7_n512PropostaSecUserName ;
      private string[] BC001A10_A643PropostaClinicaNome ;
      private bool[] BC001A10_n643PropostaClinicaNome ;
      private string[] BC001A10_A644PropostaClinicaNomeFantasia ;
      private bool[] BC001A10_n644PropostaClinicaNomeFantasia ;
      private string[] BC001A10_A652PropostaClinicaDocumento ;
      private bool[] BC001A10_n652PropostaClinicaDocumento ;
      private string[] BC001A10_A653PropostaClinicaEmail ;
      private bool[] BC001A10_n653PropostaClinicaEmail ;
      private string[] BC001A4_A228ContratoNome ;
      private bool[] BC001A4_n228ContratoNome ;
      private string[] BC001A6_A494ConvenioCategoriaDescricao ;
      private bool[] BC001A6_n494ConvenioCategoriaDescricao ;
      private int[] BC001A6_A410ConvenioId ;
      private bool[] BC001A6_n410ConvenioId ;
      private int[] BC001A55_A323PropostaId ;
      private bool[] BC001A55_n323PropostaId ;
      private int[] BC001A3_A323PropostaId ;
      private bool[] BC001A3_n323PropostaId ;
      private DateTime[] BC001A3_A327PropostaCreatedAt ;
      private bool[] BC001A3_n327PropostaCreatedAt ;
      private string[] BC001A3_A853PropostaProtocolo ;
      private bool[] BC001A3_n853PropostaProtocolo ;
      private string[] BC001A3_A849PropostaTipoProposta ;
      private bool[] BC001A3_n849PropostaTipoProposta ;
      private string[] BC001A3_A324PropostaTitulo ;
      private bool[] BC001A3_n324PropostaTitulo ;
      private string[] BC001A3_A325PropostaDescricao ;
      private bool[] BC001A3_n325PropostaDescricao ;
      private DateTime[] BC001A3_A517PropostaDataCirurgia ;
      private bool[] BC001A3_n517PropostaDataCirurgia ;
      private decimal[] BC001A3_A326PropostaValor ;
      private bool[] BC001A3_n326PropostaValor ;
      private decimal[] BC001A3_A855PropostaValorLiquido ;
      private bool[] BC001A3_n855PropostaValorLiquido ;
      private decimal[] BC001A3_A501PropostaTaxaAdministrativa ;
      private bool[] BC001A3_n501PropostaTaxaAdministrativa ;
      private short[] BC001A3_A507PropostaSLA ;
      private bool[] BC001A3_n507PropostaSLA ;
      private decimal[] BC001A3_A508PropostaJurosMora ;
      private bool[] BC001A3_n508PropostaJurosMora ;
      private string[] BC001A3_A329PropostaStatus ;
      private bool[] BC001A3_n329PropostaStatus ;
      private string[] BC001A3_A790PropostaComentarioAnalise ;
      private bool[] BC001A3_n790PropostaComentarioAnalise ;
      private short[] BC001A3_A330PropostaQuantidadeAprovadores ;
      private bool[] BC001A3_n330PropostaQuantidadeAprovadores ;
      private short[] BC001A3_A345PropostaReprovacoesPermitidas ;
      private bool[] BC001A3_n345PropostaReprovacoesPermitidas ;
      private short[] BC001A3_A496ConvenioVencimentoAno ;
      private bool[] BC001A3_n496ConvenioVencimentoAno ;
      private short[] BC001A3_A497ConvenioVencimentoMes ;
      private bool[] BC001A3_n497ConvenioVencimentoMes ;
      private int[] BC001A3_A227ContratoId ;
      private bool[] BC001A3_n227ContratoId ;
      private int[] BC001A3_A376ProcedimentosMedicosId ;
      private bool[] BC001A3_n376ProcedimentosMedicosId ;
      private int[] BC001A3_A493ConvenioCategoriaId ;
      private bool[] BC001A3_n493ConvenioCategoriaId ;
      private short[] BC001A3_A328PropostaCratedBy ;
      private bool[] BC001A3_n328PropostaCratedBy ;
      private int[] BC001A3_A504PropostaPacienteClienteId ;
      private bool[] BC001A3_n504PropostaPacienteClienteId ;
      private int[] BC001A3_A553PropostaResponsavelId ;
      private bool[] BC001A3_n553PropostaResponsavelId ;
      private int[] BC001A3_A642PropostaClinicaId ;
      private bool[] BC001A3_n642PropostaClinicaId ;
      private int[] BC001A3_A850PropostaEmpresaClienteId ;
      private bool[] BC001A3_n850PropostaEmpresaClienteId ;
      private int[] BC001A2_A323PropostaId ;
      private bool[] BC001A2_n323PropostaId ;
      private DateTime[] BC001A2_A327PropostaCreatedAt ;
      private bool[] BC001A2_n327PropostaCreatedAt ;
      private string[] BC001A2_A853PropostaProtocolo ;
      private bool[] BC001A2_n853PropostaProtocolo ;
      private string[] BC001A2_A849PropostaTipoProposta ;
      private bool[] BC001A2_n849PropostaTipoProposta ;
      private string[] BC001A2_A324PropostaTitulo ;
      private bool[] BC001A2_n324PropostaTitulo ;
      private string[] BC001A2_A325PropostaDescricao ;
      private bool[] BC001A2_n325PropostaDescricao ;
      private DateTime[] BC001A2_A517PropostaDataCirurgia ;
      private bool[] BC001A2_n517PropostaDataCirurgia ;
      private decimal[] BC001A2_A326PropostaValor ;
      private bool[] BC001A2_n326PropostaValor ;
      private decimal[] BC001A2_A855PropostaValorLiquido ;
      private bool[] BC001A2_n855PropostaValorLiquido ;
      private decimal[] BC001A2_A501PropostaTaxaAdministrativa ;
      private bool[] BC001A2_n501PropostaTaxaAdministrativa ;
      private short[] BC001A2_A507PropostaSLA ;
      private bool[] BC001A2_n507PropostaSLA ;
      private decimal[] BC001A2_A508PropostaJurosMora ;
      private bool[] BC001A2_n508PropostaJurosMora ;
      private string[] BC001A2_A329PropostaStatus ;
      private bool[] BC001A2_n329PropostaStatus ;
      private string[] BC001A2_A790PropostaComentarioAnalise ;
      private bool[] BC001A2_n790PropostaComentarioAnalise ;
      private short[] BC001A2_A330PropostaQuantidadeAprovadores ;
      private bool[] BC001A2_n330PropostaQuantidadeAprovadores ;
      private short[] BC001A2_A345PropostaReprovacoesPermitidas ;
      private bool[] BC001A2_n345PropostaReprovacoesPermitidas ;
      private short[] BC001A2_A496ConvenioVencimentoAno ;
      private bool[] BC001A2_n496ConvenioVencimentoAno ;
      private short[] BC001A2_A497ConvenioVencimentoMes ;
      private bool[] BC001A2_n497ConvenioVencimentoMes ;
      private int[] BC001A2_A227ContratoId ;
      private bool[] BC001A2_n227ContratoId ;
      private int[] BC001A2_A376ProcedimentosMedicosId ;
      private bool[] BC001A2_n376ProcedimentosMedicosId ;
      private int[] BC001A2_A493ConvenioCategoriaId ;
      private bool[] BC001A2_n493ConvenioCategoriaId ;
      private short[] BC001A2_A328PropostaCratedBy ;
      private bool[] BC001A2_n328PropostaCratedBy ;
      private int[] BC001A2_A504PropostaPacienteClienteId ;
      private bool[] BC001A2_n504PropostaPacienteClienteId ;
      private int[] BC001A2_A553PropostaResponsavelId ;
      private bool[] BC001A2_n553PropostaResponsavelId ;
      private int[] BC001A2_A642PropostaClinicaId ;
      private bool[] BC001A2_n642PropostaClinicaId ;
      private int[] BC001A2_A850PropostaEmpresaClienteId ;
      private bool[] BC001A2_n850PropostaEmpresaClienteId ;
      private int[] BC001A57_A323PropostaId ;
      private bool[] BC001A57_n323PropostaId ;
      private int[] BC001A61_A649PropostaMaxReembolsoId_F ;
      private bool[] BC001A61_n649PropostaMaxReembolsoId_F ;
      private short[] BC001A63_A854PropostaQtdItensNota_F ;
      private bool[] BC001A63_n854PropostaQtdItensNota_F ;
      private short[] BC001A65_A655PropostaQtdDocumentoPendente_F ;
      private bool[] BC001A65_n655PropostaQtdDocumentoPendente_F ;
      private short[] BC001A67_A341PropostaAprovacoes_F ;
      private bool[] BC001A67_n341PropostaAprovacoes_F ;
      private short[] BC001A69_A342PropostaReprovacoes_F ;
      private bool[] BC001A69_n342PropostaReprovacoes_F ;
      private string[] BC001A70_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] BC001A70_n505PropostaPacienteClienteRazaoSocial ;
      private string[] BC001A70_A540PropostaPacienteClienteDocumento ;
      private bool[] BC001A70_n540PropostaPacienteClienteDocumento ;
      private string[] BC001A70_A541PropostaPacienteContatoEmail ;
      private bool[] BC001A70_n541PropostaPacienteContatoEmail ;
      private string[] BC001A70_A584PropostaPacienteConta ;
      private bool[] BC001A70_n584PropostaPacienteConta ;
      private string[] BC001A70_A585PropostaPacienteAgencia ;
      private bool[] BC001A70_n585PropostaPacienteAgencia ;
      private string[] BC001A70_A586PropostaPacienteTipoPix ;
      private bool[] BC001A70_n586PropostaPacienteTipoPix ;
      private string[] BC001A70_A587PropostaPacientePIX ;
      private bool[] BC001A70_n587PropostaPacientePIX ;
      private string[] BC001A70_A588PropostaPacienteDepositoTipo ;
      private bool[] BC001A70_n588PropostaPacienteDepositoTipo ;
      private string[] BC001A70_A620PropostaPacienteEnderecoCEP ;
      private bool[] BC001A70_n620PropostaPacienteEnderecoCEP ;
      private string[] BC001A70_A621PropostaPacienteEnderecoLogradouro ;
      private bool[] BC001A70_n621PropostaPacienteEnderecoLogradouro ;
      private string[] BC001A70_A622PropostaPacienteEnderecoNumero ;
      private bool[] BC001A70_n622PropostaPacienteEnderecoNumero ;
      private string[] BC001A70_A623PropostaPacienteEnderecoComplemento ;
      private bool[] BC001A70_n623PropostaPacienteEnderecoComplemento ;
      private string[] BC001A70_A624PropostaPacienteEnderecoBairro ;
      private bool[] BC001A70_n624PropostaPacienteEnderecoBairro ;
      private string[] BC001A70_A625PropostaPacienteMunicipioCodigo ;
      private bool[] BC001A70_n625PropostaPacienteMunicipioCodigo ;
      private decimal[] BC001A73_A509PropostaValorReembolsado_F ;
      private bool[] BC001A73_n509PropostaValorReembolsado_F ;
      private decimal[] BC001A76_A510PropostaValorReembolsadoJuros_F ;
      private bool[] BC001A76_n510PropostaValorReembolsadoJuros_F ;
      private DateTime[] BC001A79_A515PropostaDataCreditoCliente_F ;
      private bool[] BC001A79_n515PropostaDataCreditoCliente_F ;
      private short[] BC001A81_A733PropostaResponsavelSerasaConsultas_F ;
      private bool[] BC001A81_n733PropostaResponsavelSerasaConsultas_F ;
      private short[] BC001A81_A734PropostaPacienteSerasaConsultas_F ;
      private bool[] BC001A81_n734PropostaPacienteSerasaConsultas_F ;
      private short[] BC001A84_A783PropostaResponsavelSerasaScoreUltimaData_F ;
      private bool[] BC001A84_n783PropostaResponsavelSerasaScoreUltimaData_F ;
      private short[] BC001A84_A782PropostaSerasaScoreUltimaData_F ;
      private bool[] BC001A84_n782PropostaSerasaScoreUltimaData_F ;
      private decimal[] BC001A87_A786PropostaResponsavelSerasaUltimoValorRecomendado_F ;
      private bool[] BC001A87_n786PropostaResponsavelSerasaUltimoValorRecomendado_F ;
      private decimal[] BC001A87_A787PropostaPacienteSerasaUltimoValorRecomendado_F ;
      private bool[] BC001A87_n787PropostaPacienteSerasaUltimoValorRecomendado_F ;
      private string[] BC001A88_A580PropostaResponsavelDocumento ;
      private bool[] BC001A88_n580PropostaResponsavelDocumento ;
      private string[] BC001A88_A581PropostaResponsavelRazaoSocial ;
      private bool[] BC001A88_n581PropostaResponsavelRazaoSocial ;
      private string[] BC001A88_A582PropostaResponsavelEmail ;
      private bool[] BC001A88_n582PropostaResponsavelEmail ;
      private string[] BC001A88_A590PropostaResponsavelConta ;
      private bool[] BC001A88_n590PropostaResponsavelConta ;
      private string[] BC001A88_A591PropostaResponsavelAgencia ;
      private bool[] BC001A88_n591PropostaResponsavelAgencia ;
      private string[] BC001A88_A592PropostaResponsavelTipoPix ;
      private bool[] BC001A88_n592PropostaResponsavelTipoPix ;
      private string[] BC001A88_A593PropostaResponsavelPIX ;
      private bool[] BC001A88_n593PropostaResponsavelPIX ;
      private string[] BC001A88_A594PropostaResponsavelDepositoTipo ;
      private bool[] BC001A88_n594PropostaResponsavelDepositoTipo ;
      private string[] BC001A89_A512PropostaSecUserName ;
      private bool[] BC001A89_n512PropostaSecUserName ;
      private decimal[] BC001A92_A511PropostaValorTaxaRecebida_F ;
      private bool[] BC001A92_n511PropostaValorTaxaRecebida_F ;
      private string[] BC001A93_A643PropostaClinicaNome ;
      private bool[] BC001A93_n643PropostaClinicaNome ;
      private string[] BC001A93_A644PropostaClinicaNomeFantasia ;
      private bool[] BC001A93_n644PropostaClinicaNomeFantasia ;
      private string[] BC001A93_A652PropostaClinicaDocumento ;
      private bool[] BC001A93_n652PropostaClinicaDocumento ;
      private string[] BC001A93_A653PropostaClinicaEmail ;
      private bool[] BC001A93_n653PropostaClinicaEmail ;
      private decimal[] BC001A95_A650PropostaValorTaxaClinica_F ;
      private bool[] BC001A95_n650PropostaValorTaxaClinica_F ;
      private string[] BC001A96_A228ContratoNome ;
      private bool[] BC001A96_n228ContratoNome ;
      private string[] BC001A97_A494ConvenioCategoriaDescricao ;
      private bool[] BC001A97_n494ConvenioCategoriaDescricao ;
      private int[] BC001A97_A410ConvenioId ;
      private bool[] BC001A97_n410ConvenioId ;
      private int[] BC001A98_A227ContratoId ;
      private bool[] BC001A98_n227ContratoId ;
      private int[] BC001A99_A518ReembolsoId ;
      private int[] BC001A100_A261TituloId ;
      private bool[] BC001A100_n261TituloId ;
      private Guid[] BC001A101_A830NotaFiscalItemId ;
      private int[] BC001A102_A572PropostaContratoAssinaturaId ;
      private int[] BC001A103_A414PropostaDocumentosId ;
      private int[] BC001A104_A336AprovacaoId ;
      private int[] BC001A115_A323PropostaId ;
      private bool[] BC001A115_n323PropostaId ;
      private DateTime[] BC001A115_A327PropostaCreatedAt ;
      private bool[] BC001A115_n327PropostaCreatedAt ;
      private string[] BC001A115_A853PropostaProtocolo ;
      private bool[] BC001A115_n853PropostaProtocolo ;
      private string[] BC001A115_A849PropostaTipoProposta ;
      private bool[] BC001A115_n849PropostaTipoProposta ;
      private string[] BC001A115_A580PropostaResponsavelDocumento ;
      private bool[] BC001A115_n580PropostaResponsavelDocumento ;
      private string[] BC001A115_A581PropostaResponsavelRazaoSocial ;
      private bool[] BC001A115_n581PropostaResponsavelRazaoSocial ;
      private string[] BC001A115_A582PropostaResponsavelEmail ;
      private bool[] BC001A115_n582PropostaResponsavelEmail ;
      private string[] BC001A115_A590PropostaResponsavelConta ;
      private bool[] BC001A115_n590PropostaResponsavelConta ;
      private string[] BC001A115_A591PropostaResponsavelAgencia ;
      private bool[] BC001A115_n591PropostaResponsavelAgencia ;
      private string[] BC001A115_A592PropostaResponsavelTipoPix ;
      private bool[] BC001A115_n592PropostaResponsavelTipoPix ;
      private string[] BC001A115_A593PropostaResponsavelPIX ;
      private bool[] BC001A115_n593PropostaResponsavelPIX ;
      private string[] BC001A115_A594PropostaResponsavelDepositoTipo ;
      private bool[] BC001A115_n594PropostaResponsavelDepositoTipo ;
      private string[] BC001A115_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] BC001A115_n505PropostaPacienteClienteRazaoSocial ;
      private string[] BC001A115_A540PropostaPacienteClienteDocumento ;
      private bool[] BC001A115_n540PropostaPacienteClienteDocumento ;
      private string[] BC001A115_A541PropostaPacienteContatoEmail ;
      private bool[] BC001A115_n541PropostaPacienteContatoEmail ;
      private string[] BC001A115_A584PropostaPacienteConta ;
      private bool[] BC001A115_n584PropostaPacienteConta ;
      private string[] BC001A115_A585PropostaPacienteAgencia ;
      private bool[] BC001A115_n585PropostaPacienteAgencia ;
      private string[] BC001A115_A586PropostaPacienteTipoPix ;
      private bool[] BC001A115_n586PropostaPacienteTipoPix ;
      private string[] BC001A115_A587PropostaPacientePIX ;
      private bool[] BC001A115_n587PropostaPacientePIX ;
      private string[] BC001A115_A588PropostaPacienteDepositoTipo ;
      private bool[] BC001A115_n588PropostaPacienteDepositoTipo ;
      private string[] BC001A115_A620PropostaPacienteEnderecoCEP ;
      private bool[] BC001A115_n620PropostaPacienteEnderecoCEP ;
      private string[] BC001A115_A621PropostaPacienteEnderecoLogradouro ;
      private bool[] BC001A115_n621PropostaPacienteEnderecoLogradouro ;
      private string[] BC001A115_A622PropostaPacienteEnderecoNumero ;
      private bool[] BC001A115_n622PropostaPacienteEnderecoNumero ;
      private string[] BC001A115_A623PropostaPacienteEnderecoComplemento ;
      private bool[] BC001A115_n623PropostaPacienteEnderecoComplemento ;
      private string[] BC001A115_A624PropostaPacienteEnderecoBairro ;
      private bool[] BC001A115_n624PropostaPacienteEnderecoBairro ;
      private string[] BC001A115_A324PropostaTitulo ;
      private bool[] BC001A115_n324PropostaTitulo ;
      private string[] BC001A115_A325PropostaDescricao ;
      private bool[] BC001A115_n325PropostaDescricao ;
      private DateTime[] BC001A115_A517PropostaDataCirurgia ;
      private bool[] BC001A115_n517PropostaDataCirurgia ;
      private decimal[] BC001A115_A326PropostaValor ;
      private bool[] BC001A115_n326PropostaValor ;
      private decimal[] BC001A115_A855PropostaValorLiquido ;
      private bool[] BC001A115_n855PropostaValorLiquido ;
      private decimal[] BC001A115_A501PropostaTaxaAdministrativa ;
      private bool[] BC001A115_n501PropostaTaxaAdministrativa ;
      private short[] BC001A115_A507PropostaSLA ;
      private bool[] BC001A115_n507PropostaSLA ;
      private decimal[] BC001A115_A508PropostaJurosMora ;
      private bool[] BC001A115_n508PropostaJurosMora ;
      private string[] BC001A115_A643PropostaClinicaNome ;
      private bool[] BC001A115_n643PropostaClinicaNome ;
      private string[] BC001A115_A644PropostaClinicaNomeFantasia ;
      private bool[] BC001A115_n644PropostaClinicaNomeFantasia ;
      private string[] BC001A115_A652PropostaClinicaDocumento ;
      private bool[] BC001A115_n652PropostaClinicaDocumento ;
      private string[] BC001A115_A653PropostaClinicaEmail ;
      private bool[] BC001A115_n653PropostaClinicaEmail ;
      private string[] BC001A115_A512PropostaSecUserName ;
      private bool[] BC001A115_n512PropostaSecUserName ;
      private string[] BC001A115_A329PropostaStatus ;
      private bool[] BC001A115_n329PropostaStatus ;
      private string[] BC001A115_A790PropostaComentarioAnalise ;
      private bool[] BC001A115_n790PropostaComentarioAnalise ;
      private short[] BC001A115_A330PropostaQuantidadeAprovadores ;
      private bool[] BC001A115_n330PropostaQuantidadeAprovadores ;
      private short[] BC001A115_A345PropostaReprovacoesPermitidas ;
      private bool[] BC001A115_n345PropostaReprovacoesPermitidas ;
      private string[] BC001A115_A228ContratoNome ;
      private bool[] BC001A115_n228ContratoNome ;
      private short[] BC001A115_A496ConvenioVencimentoAno ;
      private bool[] BC001A115_n496ConvenioVencimentoAno ;
      private short[] BC001A115_A497ConvenioVencimentoMes ;
      private bool[] BC001A115_n497ConvenioVencimentoMes ;
      private string[] BC001A115_A494ConvenioCategoriaDescricao ;
      private bool[] BC001A115_n494ConvenioCategoriaDescricao ;
      private int[] BC001A115_A227ContratoId ;
      private bool[] BC001A115_n227ContratoId ;
      private int[] BC001A115_A376ProcedimentosMedicosId ;
      private bool[] BC001A115_n376ProcedimentosMedicosId ;
      private int[] BC001A115_A493ConvenioCategoriaId ;
      private bool[] BC001A115_n493ConvenioCategoriaId ;
      private short[] BC001A115_A328PropostaCratedBy ;
      private bool[] BC001A115_n328PropostaCratedBy ;
      private int[] BC001A115_A504PropostaPacienteClienteId ;
      private bool[] BC001A115_n504PropostaPacienteClienteId ;
      private int[] BC001A115_A553PropostaResponsavelId ;
      private bool[] BC001A115_n553PropostaResponsavelId ;
      private int[] BC001A115_A642PropostaClinicaId ;
      private bool[] BC001A115_n642PropostaClinicaId ;
      private int[] BC001A115_A850PropostaEmpresaClienteId ;
      private bool[] BC001A115_n850PropostaEmpresaClienteId ;
      private int[] BC001A115_A410ConvenioId ;
      private bool[] BC001A115_n410ConvenioId ;
      private string[] BC001A115_A625PropostaPacienteMunicipioCodigo ;
      private bool[] BC001A115_n625PropostaPacienteMunicipioCodigo ;
      private int[] BC001A115_A649PropostaMaxReembolsoId_F ;
      private bool[] BC001A115_n649PropostaMaxReembolsoId_F ;
      private short[] BC001A115_A854PropostaQtdItensNota_F ;
      private bool[] BC001A115_n854PropostaQtdItensNota_F ;
      private short[] BC001A115_A733PropostaResponsavelSerasaConsultas_F ;
      private bool[] BC001A115_n733PropostaResponsavelSerasaConsultas_F ;
      private short[] BC001A115_A783PropostaResponsavelSerasaScoreUltimaData_F ;
      private bool[] BC001A115_n783PropostaResponsavelSerasaScoreUltimaData_F ;
      private decimal[] BC001A115_A786PropostaResponsavelSerasaUltimoValorRecomendado_F ;
      private bool[] BC001A115_n786PropostaResponsavelSerasaUltimoValorRecomendado_F ;
      private short[] BC001A115_A734PropostaPacienteSerasaConsultas_F ;
      private bool[] BC001A115_n734PropostaPacienteSerasaConsultas_F ;
      private short[] BC001A115_A782PropostaSerasaScoreUltimaData_F ;
      private bool[] BC001A115_n782PropostaSerasaScoreUltimaData_F ;
      private decimal[] BC001A115_A787PropostaPacienteSerasaUltimoValorRecomendado_F ;
      private bool[] BC001A115_n787PropostaPacienteSerasaUltimoValorRecomendado_F ;
      private short[] BC001A115_A655PropostaQtdDocumentoPendente_F ;
      private bool[] BC001A115_n655PropostaQtdDocumentoPendente_F ;
      private short[] BC001A115_A341PropostaAprovacoes_F ;
      private bool[] BC001A115_n341PropostaAprovacoes_F ;
      private short[] BC001A115_A342PropostaReprovacoes_F ;
      private bool[] BC001A115_n342PropostaReprovacoes_F ;
      private SdtProposta bcProposta ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class proposta_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new UpdateCursor(def[25])
         ,new ForEachCursor(def[26])
         ,new UpdateCursor(def[27])
         ,new UpdateCursor(def[28])
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
         ,new ForEachCursor(def[40])
         ,new ForEachCursor(def[41])
         ,new ForEachCursor(def[42])
         ,new ForEachCursor(def[43])
         ,new ForEachCursor(def[44])
         ,new ForEachCursor(def[45])
         ,new ForEachCursor(def[46])
         ,new ForEachCursor(def[47])
         ,new ForEachCursor(def[48])
         ,new ForEachCursor(def[49])
         ,new ForEachCursor(def[50])
         ,new ForEachCursor(def[51])
         ,new ForEachCursor(def[52])
         ,new ForEachCursor(def[53])
         ,new ForEachCursor(def[54])
         ,new ForEachCursor(def[55])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC001A2;
          prmBC001A2 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A3;
          prmBC001A3 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A4;
          prmBC001A4 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC001A5;
          prmBC001A5 = new Object[] {
          new ParDef("ProcedimentosMedicosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A6;
          prmBC001A6 = new Object[] {
          new ParDef("ConvenioCategoriaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A7;
          prmBC001A7 = new Object[] {
          new ParDef("PropostaCratedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC001A8;
          prmBC001A8 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A9;
          prmBC001A9 = new Object[] {
          new ParDef("PropostaResponsavelId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A10;
          prmBC001A10 = new Object[] {
          new ParDef("PropostaClinicaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A11;
          prmBC001A11 = new Object[] {
          new ParDef("PropostaEmpresaClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A27;
          prmBC001A27 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A29;
          prmBC001A29 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A31;
          prmBC001A31 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A34;
          prmBC001A34 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A37;
          prmBC001A37 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A39;
          prmBC001A39 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A41;
          prmBC001A41 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A43;
          prmBC001A43 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A54;
          prmBC001A54 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          string cmdBufferBC001A54;
          cmdBufferBC001A54=" SELECT TM1.PropostaId, TM1.PropostaCreatedAt, TM1.PropostaProtocolo, TM1.PropostaTipoProposta, T11.ClienteDocumento AS PropostaResponsavelDocumento, T11.ClienteRazaoSocial AS PropostaResponsavelRazaoSocial, T11.ContatoEmail AS PropostaResponsavelEmail, T11.ContaNumero AS PropostaResponsavelConta, T11.ContaAgencia AS PropostaResponsavelAgencia, T11.ClientePixTipo AS PropostaResponsavelTipoPix, T11.ClientePix AS PropostaResponsavelPIX, T11.ClienteDepositoTipo AS PropostaResponsavelDepositoTipo, T7.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T7.ClienteDocumento AS PropostaPacienteClienteDocumento, T7.ContatoEmail AS PropostaPacienteContatoEmail, T7.ContaNumero AS PropostaPacienteConta, T7.ContaAgencia AS PropostaPacienteAgencia, T7.ClientePixTipo AS PropostaPacienteTipoPix, T7.ClientePix AS PropostaPacientePIX, T7.ClienteDepositoTipo AS PropostaPacienteDepositoTipo, T7.EnderecoCEP AS PropostaPacienteEnderecoCEP, T7.EnderecoLogradouro AS PropostaPacienteEnderecoLogradouro, T7.EnderecoNumero AS PropostaPacienteEnderecoNumero, T7.EnderecoComplemento AS PropostaPacienteEnderecoComplemento, T7.EnderecoBairro AS PropostaPacienteEnderecoBairro, TM1.PropostaTitulo, TM1.PropostaDescricao, TM1.PropostaDataCirurgia, TM1.PropostaValor, TM1.PropostaValorLiquido, TM1.PropostaTaxaAdministrativa, TM1.PropostaSLA, TM1.PropostaJurosMora, T13.ClienteRazaoSocial AS PropostaClinicaNome, T13.ClienteNomeFantasia AS PropostaClinicaNomeFantasia, T13.ClienteDocumento AS PropostaClinicaDocumento, T13.ContatoEmail AS PropostaClinicaEmail, T12.SecUserFullName AS PropostaSecUserName, TM1.PropostaStatus, TM1.PropostaComentarioAnalise, TM1.PropostaQuantidadeAprovadores, TM1.PropostaReprovacoesPermitidas, T14.ContratoNome, TM1.ConvenioVencimentoAno, TM1.ConvenioVencimentoMes, T15.ConvenioCategoriaDescricao, "
          + " TM1.ContratoId, TM1.ProcedimentosMedicosId, TM1.ConvenioCategoriaId, TM1.PropostaCratedBy AS PropostaCratedBy, TM1.PropostaPacienteClienteId AS PropostaPacienteClienteId, TM1.PropostaResponsavelId AS PropostaResponsavelId, TM1.PropostaClinicaId AS PropostaClinicaId, TM1.PropostaEmpresaClienteId AS PropostaEmpresaClienteId, T15.ConvenioId, T7.MunicipioCodigo AS PropostaPacienteMunicipioCodigo, COALESCE( T2.PropostaMaxReembolsoId_F, 0) AS PropostaMaxReembolsoId_F, COALESCE( T3.PropostaQtdItensNota_F, 0) AS PropostaQtdItensNota_F, COALESCE( T8.PropostaResponsavelSerasaConsultas_F, 0) AS PropostaResponsavelSerasaConsultas_F, COALESCE( T9.PropostaResponsavelSerasaScoreUltimaData_F, 0) AS PropostaResponsavelSerasaScoreUltimaData_F, COALESCE( T10.PropostaResponsavelSerasaUltimoValorRecomendado_F, 0) AS PropostaResponsavelSerasaUltimoValorRecomendado_F, COALESCE( T8.PropostaResponsavelSerasaConsultas_F, 0) AS PropostaPacienteSerasaConsultas_F, COALESCE( T9.PropostaResponsavelSerasaScoreUltimaData_F, 0) AS PropostaSerasaScoreUltimaData_F, COALESCE( T10.PropostaResponsavelSerasaUltimoValorRecomendado_F, 0) AS PropostaPacienteSerasaUltimoValorRecomendado_F, COALESCE( T4.PropostaQtdDocumentoPendente_F, 0) AS PropostaQtdDocumentoPendente_F, COALESCE( T5.PropostaAprovacoes_F, 0) AS PropostaAprovacoes_F, COALESCE( T6.PropostaAprovacoes_F, 0) AS PropostaReprovacoes_F FROM ((((((((((((((Proposta TM1 LEFT JOIN LATERAL (SELECT MAX(ReembolsoId) AS PropostaMaxReembolsoId_F, ReembolsoPropostaId FROM Reembolso WHERE TM1.PropostaId = ReembolsoPropostaId GROUP BY ReembolsoPropostaId ) T2 ON T2.ReembolsoPropostaId = TM1.PropostaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaQtdItensNota_F, PropostaId FROM NotaFiscalItem WHERE TM1.PropostaId = PropostaId GROUP BY PropostaId ) T3 ON T3.PropostaId"
          + " = TM1.PropostaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaQtdDocumentoPendente_F, PropostaId FROM PropostaDocumentos WHERE (TM1.PropostaId = PropostaId) AND (PropostaDocumentosStatus = ( 'AGUARDANDO_ANALISE') or PropostaDocumentosStatus = ( 'REPROVADO')) GROUP BY PropostaId ) T4 ON T4.PropostaId = TM1.PropostaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE (TM1.PropostaId = PropostaId) AND (AprovacaoStatus = ( 'APROVADO')) GROUP BY PropostaId ) T5 ON T5.PropostaId = TM1.PropostaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE (TM1.PropostaId = PropostaId) AND (AprovacaoStatus = ( 'REPROVADO')) GROUP BY PropostaId ) T6 ON T6.PropostaId = TM1.PropostaId) LEFT JOIN Cliente T7 ON T7.ClienteId = TM1.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaResponsavelSerasaConsultas_F, ClienteId FROM Serasa WHERE TM1.PropostaPacienteClienteId = ClienteId GROUP BY ClienteId ) T8 ON T8.ClienteId = TM1.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT MAX(T16.SerasaScore) AS PropostaResponsavelSerasaScoreUltimaData_F, COALESCE( T17.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, T16.ClienteId FROM (Serasa T16 LEFT JOIN LATERAL (SELECT MAX(SerasaCreatedAt) AS SerasaUltimaData_F, ClienteId FROM Serasa WHERE T16.ClienteId = ClienteId GROUP BY ClienteId ) T17 ON T17.ClienteId = T16.ClienteId) WHERE (TM1.PropostaPacienteClienteId = T16.ClienteId) AND (T16.SerasaCreatedAt = COALESCE( T17.SerasaUltimaData_F, DATE '00010101')) GROUP BY T17.SerasaUltimaData_F, T16.ClienteId ) T9 ON T9.ClienteId = TM1.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT MAX(T16.SerasaValorLimiteRecomendado) AS PropostaResponsavelSerasaUltimoValorRecomendado_F, COALESCE( T17.SerasaUltimaData_F,"
          + " DATE '00010101') AS SerasaUltimaData_F, T16.ClienteId FROM (Serasa T16 LEFT JOIN LATERAL (SELECT MAX(SerasaCreatedAt) AS SerasaUltimaData_F, ClienteId FROM Serasa WHERE T16.ClienteId = ClienteId GROUP BY ClienteId ) T17 ON T17.ClienteId = T16.ClienteId) WHERE (TM1.PropostaPacienteClienteId = T16.ClienteId) AND (T16.SerasaCreatedAt = COALESCE( T17.SerasaUltimaData_F, DATE '00010101')) GROUP BY T17.SerasaUltimaData_F, T16.ClienteId ) T10 ON T10.ClienteId = TM1.PropostaPacienteClienteId) LEFT JOIN Cliente T11 ON T11.ClienteId = TM1.PropostaResponsavelId) LEFT JOIN SecUser T12 ON T12.SecUserId = TM1.PropostaCratedBy) LEFT JOIN Cliente T13 ON T13.ClienteId = TM1.PropostaClinicaId) LEFT JOIN Contrato T14 ON T14.ContratoId = TM1.ContratoId) LEFT JOIN ConvenioCategoria T15 ON T15.ConvenioCategoriaId = TM1.ConvenioCategoriaId) WHERE TM1.PropostaId = :PropostaId ORDER BY TM1.PropostaId" ;
          Object[] prmBC001A25;
          prmBC001A25 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaClinicaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A14;
          prmBC001A14 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A17;
          prmBC001A17 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A23;
          prmBC001A23 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A20;
          prmBC001A20 = new Object[] {
          new ParDef("PropostaCratedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A55;
          prmBC001A55 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A56;
          prmBC001A56 = new Object[] {
          new ParDef("PropostaCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("PropostaProtocolo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("PropostaTipoProposta",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("PropostaTitulo",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("PropostaDescricao",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("PropostaDataCirurgia",GXType.Date,8,0){Nullable=true} ,
          new ParDef("PropostaValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("PropostaValorLiquido",GXType.Number,18,2){Nullable=true} ,
          new ParDef("PropostaTaxaAdministrativa",GXType.Number,16,4){Nullable=true} ,
          new ParDef("PropostaSLA",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("PropostaJurosMora",GXType.Number,16,4){Nullable=true} ,
          new ParDef("PropostaStatus",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("PropostaComentarioAnalise",GXType.VarChar,255,0){Nullable=true} ,
          new ParDef("PropostaQuantidadeAprovadores",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("PropostaReprovacoesPermitidas",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ConvenioVencimentoAno",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ConvenioVencimentoMes",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("ProcedimentosMedicosId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ConvenioCategoriaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaCratedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaResponsavelId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaClinicaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaEmpresaClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A57;
          prmBC001A57 = new Object[] {
          };
          Object[] prmBC001A58;
          prmBC001A58 = new Object[] {
          new ParDef("PropostaCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("PropostaProtocolo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("PropostaTipoProposta",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("PropostaTitulo",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("PropostaDescricao",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("PropostaDataCirurgia",GXType.Date,8,0){Nullable=true} ,
          new ParDef("PropostaValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("PropostaValorLiquido",GXType.Number,18,2){Nullable=true} ,
          new ParDef("PropostaTaxaAdministrativa",GXType.Number,16,4){Nullable=true} ,
          new ParDef("PropostaSLA",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("PropostaJurosMora",GXType.Number,16,4){Nullable=true} ,
          new ParDef("PropostaStatus",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("PropostaComentarioAnalise",GXType.VarChar,255,0){Nullable=true} ,
          new ParDef("PropostaQuantidadeAprovadores",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("PropostaReprovacoesPermitidas",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ConvenioVencimentoAno",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ConvenioVencimentoMes",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("ProcedimentosMedicosId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ConvenioCategoriaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaCratedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaResponsavelId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaClinicaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaEmpresaClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A59;
          prmBC001A59 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A61;
          prmBC001A61 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A63;
          prmBC001A63 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A65;
          prmBC001A65 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A67;
          prmBC001A67 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A69;
          prmBC001A69 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A70;
          prmBC001A70 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A73;
          prmBC001A73 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A76;
          prmBC001A76 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A79;
          prmBC001A79 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A81;
          prmBC001A81 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A84;
          prmBC001A84 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A87;
          prmBC001A87 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A88;
          prmBC001A88 = new Object[] {
          new ParDef("PropostaResponsavelId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A89;
          prmBC001A89 = new Object[] {
          new ParDef("PropostaCratedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC001A92;
          prmBC001A92 = new Object[] {
          new ParDef("PropostaCratedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A93;
          prmBC001A93 = new Object[] {
          new ParDef("PropostaClinicaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A95;
          prmBC001A95 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaClinicaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A96;
          prmBC001A96 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC001A97;
          prmBC001A97 = new Object[] {
          new ParDef("ConvenioCategoriaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A98;
          prmBC001A98 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A99;
          prmBC001A99 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A100;
          prmBC001A100 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A101;
          prmBC001A101 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A102;
          prmBC001A102 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A103;
          prmBC001A103 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A104;
          prmBC001A104 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001A115;
          prmBC001A115 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          string cmdBufferBC001A115;
          cmdBufferBC001A115=" SELECT TM1.PropostaId, TM1.PropostaCreatedAt, TM1.PropostaProtocolo, TM1.PropostaTipoProposta, T11.ClienteDocumento AS PropostaResponsavelDocumento, T11.ClienteRazaoSocial AS PropostaResponsavelRazaoSocial, T11.ContatoEmail AS PropostaResponsavelEmail, T11.ContaNumero AS PropostaResponsavelConta, T11.ContaAgencia AS PropostaResponsavelAgencia, T11.ClientePixTipo AS PropostaResponsavelTipoPix, T11.ClientePix AS PropostaResponsavelPIX, T11.ClienteDepositoTipo AS PropostaResponsavelDepositoTipo, T7.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T7.ClienteDocumento AS PropostaPacienteClienteDocumento, T7.ContatoEmail AS PropostaPacienteContatoEmail, T7.ContaNumero AS PropostaPacienteConta, T7.ContaAgencia AS PropostaPacienteAgencia, T7.ClientePixTipo AS PropostaPacienteTipoPix, T7.ClientePix AS PropostaPacientePIX, T7.ClienteDepositoTipo AS PropostaPacienteDepositoTipo, T7.EnderecoCEP AS PropostaPacienteEnderecoCEP, T7.EnderecoLogradouro AS PropostaPacienteEnderecoLogradouro, T7.EnderecoNumero AS PropostaPacienteEnderecoNumero, T7.EnderecoComplemento AS PropostaPacienteEnderecoComplemento, T7.EnderecoBairro AS PropostaPacienteEnderecoBairro, TM1.PropostaTitulo, TM1.PropostaDescricao, TM1.PropostaDataCirurgia, TM1.PropostaValor, TM1.PropostaValorLiquido, TM1.PropostaTaxaAdministrativa, TM1.PropostaSLA, TM1.PropostaJurosMora, T13.ClienteRazaoSocial AS PropostaClinicaNome, T13.ClienteNomeFantasia AS PropostaClinicaNomeFantasia, T13.ClienteDocumento AS PropostaClinicaDocumento, T13.ContatoEmail AS PropostaClinicaEmail, T12.SecUserFullName AS PropostaSecUserName, TM1.PropostaStatus, TM1.PropostaComentarioAnalise, TM1.PropostaQuantidadeAprovadores, TM1.PropostaReprovacoesPermitidas, T14.ContratoNome, TM1.ConvenioVencimentoAno, TM1.ConvenioVencimentoMes, T15.ConvenioCategoriaDescricao, "
          + " TM1.ContratoId, TM1.ProcedimentosMedicosId, TM1.ConvenioCategoriaId, TM1.PropostaCratedBy AS PropostaCratedBy, TM1.PropostaPacienteClienteId AS PropostaPacienteClienteId, TM1.PropostaResponsavelId AS PropostaResponsavelId, TM1.PropostaClinicaId AS PropostaClinicaId, TM1.PropostaEmpresaClienteId AS PropostaEmpresaClienteId, T15.ConvenioId, T7.MunicipioCodigo AS PropostaPacienteMunicipioCodigo, COALESCE( T2.PropostaMaxReembolsoId_F, 0) AS PropostaMaxReembolsoId_F, COALESCE( T3.PropostaQtdItensNota_F, 0) AS PropostaQtdItensNota_F, COALESCE( T8.PropostaResponsavelSerasaConsultas_F, 0) AS PropostaResponsavelSerasaConsultas_F, COALESCE( T9.PropostaResponsavelSerasaScoreUltimaData_F, 0) AS PropostaResponsavelSerasaScoreUltimaData_F, COALESCE( T10.PropostaResponsavelSerasaUltimoValorRecomendado_F, 0) AS PropostaResponsavelSerasaUltimoValorRecomendado_F, COALESCE( T8.PropostaResponsavelSerasaConsultas_F, 0) AS PropostaPacienteSerasaConsultas_F, COALESCE( T9.PropostaResponsavelSerasaScoreUltimaData_F, 0) AS PropostaSerasaScoreUltimaData_F, COALESCE( T10.PropostaResponsavelSerasaUltimoValorRecomendado_F, 0) AS PropostaPacienteSerasaUltimoValorRecomendado_F, COALESCE( T4.PropostaQtdDocumentoPendente_F, 0) AS PropostaQtdDocumentoPendente_F, COALESCE( T5.PropostaAprovacoes_F, 0) AS PropostaAprovacoes_F, COALESCE( T6.PropostaAprovacoes_F, 0) AS PropostaReprovacoes_F FROM ((((((((((((((Proposta TM1 LEFT JOIN LATERAL (SELECT MAX(ReembolsoId) AS PropostaMaxReembolsoId_F, ReembolsoPropostaId FROM Reembolso WHERE TM1.PropostaId = ReembolsoPropostaId GROUP BY ReembolsoPropostaId ) T2 ON T2.ReembolsoPropostaId = TM1.PropostaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaQtdItensNota_F, PropostaId FROM NotaFiscalItem WHERE TM1.PropostaId = PropostaId GROUP BY PropostaId ) T3 ON T3.PropostaId"
          + " = TM1.PropostaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaQtdDocumentoPendente_F, PropostaId FROM PropostaDocumentos WHERE (TM1.PropostaId = PropostaId) AND (PropostaDocumentosStatus = ( 'AGUARDANDO_ANALISE') or PropostaDocumentosStatus = ( 'REPROVADO')) GROUP BY PropostaId ) T4 ON T4.PropostaId = TM1.PropostaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE (TM1.PropostaId = PropostaId) AND (AprovacaoStatus = ( 'APROVADO')) GROUP BY PropostaId ) T5 ON T5.PropostaId = TM1.PropostaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE (TM1.PropostaId = PropostaId) AND (AprovacaoStatus = ( 'REPROVADO')) GROUP BY PropostaId ) T6 ON T6.PropostaId = TM1.PropostaId) LEFT JOIN Cliente T7 ON T7.ClienteId = TM1.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaResponsavelSerasaConsultas_F, ClienteId FROM Serasa WHERE TM1.PropostaPacienteClienteId = ClienteId GROUP BY ClienteId ) T8 ON T8.ClienteId = TM1.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT MAX(T16.SerasaScore) AS PropostaResponsavelSerasaScoreUltimaData_F, COALESCE( T17.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, T16.ClienteId FROM (Serasa T16 LEFT JOIN LATERAL (SELECT MAX(SerasaCreatedAt) AS SerasaUltimaData_F, ClienteId FROM Serasa WHERE T16.ClienteId = ClienteId GROUP BY ClienteId ) T17 ON T17.ClienteId = T16.ClienteId) WHERE (TM1.PropostaPacienteClienteId = T16.ClienteId) AND (T16.SerasaCreatedAt = COALESCE( T17.SerasaUltimaData_F, DATE '00010101')) GROUP BY T17.SerasaUltimaData_F, T16.ClienteId ) T9 ON T9.ClienteId = TM1.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT MAX(T16.SerasaValorLimiteRecomendado) AS PropostaResponsavelSerasaUltimoValorRecomendado_F, COALESCE( T17.SerasaUltimaData_F,"
          + " DATE '00010101') AS SerasaUltimaData_F, T16.ClienteId FROM (Serasa T16 LEFT JOIN LATERAL (SELECT MAX(SerasaCreatedAt) AS SerasaUltimaData_F, ClienteId FROM Serasa WHERE T16.ClienteId = ClienteId GROUP BY ClienteId ) T17 ON T17.ClienteId = T16.ClienteId) WHERE (TM1.PropostaPacienteClienteId = T16.ClienteId) AND (T16.SerasaCreatedAt = COALESCE( T17.SerasaUltimaData_F, DATE '00010101')) GROUP BY T17.SerasaUltimaData_F, T16.ClienteId ) T10 ON T10.ClienteId = TM1.PropostaPacienteClienteId) LEFT JOIN Cliente T11 ON T11.ClienteId = TM1.PropostaResponsavelId) LEFT JOIN SecUser T12 ON T12.SecUserId = TM1.PropostaCratedBy) LEFT JOIN Cliente T13 ON T13.ClienteId = TM1.PropostaClinicaId) LEFT JOIN Contrato T14 ON T14.ContratoId = TM1.ContratoId) LEFT JOIN ConvenioCategoria T15 ON T15.ConvenioCategoriaId = TM1.ConvenioCategoriaId) WHERE TM1.PropostaId = :PropostaId ORDER BY TM1.PropostaId" ;
          def= new CursorDef[] {
              new CursorDef("BC001A2", "SELECT PropostaId, PropostaCreatedAt, PropostaProtocolo, PropostaTipoProposta, PropostaTitulo, PropostaDescricao, PropostaDataCirurgia, PropostaValor, PropostaValorLiquido, PropostaTaxaAdministrativa, PropostaSLA, PropostaJurosMora, PropostaStatus, PropostaComentarioAnalise, PropostaQuantidadeAprovadores, PropostaReprovacoesPermitidas, ConvenioVencimentoAno, ConvenioVencimentoMes, ContratoId, ProcedimentosMedicosId, ConvenioCategoriaId, PropostaCratedBy, PropostaPacienteClienteId, PropostaResponsavelId, PropostaClinicaId, PropostaEmpresaClienteId FROM Proposta WHERE PropostaId = :PropostaId  FOR UPDATE OF Proposta",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A3", "SELECT PropostaId, PropostaCreatedAt, PropostaProtocolo, PropostaTipoProposta, PropostaTitulo, PropostaDescricao, PropostaDataCirurgia, PropostaValor, PropostaValorLiquido, PropostaTaxaAdministrativa, PropostaSLA, PropostaJurosMora, PropostaStatus, PropostaComentarioAnalise, PropostaQuantidadeAprovadores, PropostaReprovacoesPermitidas, ConvenioVencimentoAno, ConvenioVencimentoMes, ContratoId, ProcedimentosMedicosId, ConvenioCategoriaId, PropostaCratedBy, PropostaPacienteClienteId, PropostaResponsavelId, PropostaClinicaId, PropostaEmpresaClienteId FROM Proposta WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A4", "SELECT ContratoNome FROM Contrato WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A5", "SELECT ProcedimentosMedicosId FROM ProcedimentosMedicos WHERE ProcedimentosMedicosId = :ProcedimentosMedicosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A6", "SELECT ConvenioCategoriaDescricao, ConvenioId FROM ConvenioCategoria WHERE ConvenioCategoriaId = :ConvenioCategoriaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A7", "SELECT SecUserFullName AS PropostaSecUserName FROM SecUser WHERE SecUserId = :PropostaCratedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A8", "SELECT ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, ClienteDocumento AS PropostaPacienteClienteDocumento, ContatoEmail AS PropostaPacienteContatoEmail, ContaNumero AS PropostaPacienteConta, ContaAgencia AS PropostaPacienteAgencia, ClientePixTipo AS PropostaPacienteTipoPix, ClientePix AS PropostaPacientePIX, ClienteDepositoTipo AS PropostaPacienteDepositoTipo, EnderecoCEP AS PropostaPacienteEnderecoCEP, EnderecoLogradouro AS PropostaPacienteEnderecoLogradouro, EnderecoNumero AS PropostaPacienteEnderecoNumero, EnderecoComplemento AS PropostaPacienteEnderecoComplemento, EnderecoBairro AS PropostaPacienteEnderecoBairro, MunicipioCodigo AS PropostaPacienteMunicipioCodigo FROM Cliente WHERE ClienteId = :PropostaPacienteClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A9", "SELECT ClienteDocumento AS PropostaResponsavelDocumento, ClienteRazaoSocial AS PropostaResponsavelRazaoSocial, ContatoEmail AS PropostaResponsavelEmail, ContaNumero AS PropostaResponsavelConta, ContaAgencia AS PropostaResponsavelAgencia, ClientePixTipo AS PropostaResponsavelTipoPix, ClientePix AS PropostaResponsavelPIX, ClienteDepositoTipo AS PropostaResponsavelDepositoTipo FROM Cliente WHERE ClienteId = :PropostaResponsavelId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A10", "SELECT ClienteRazaoSocial AS PropostaClinicaNome, ClienteNomeFantasia AS PropostaClinicaNomeFantasia, ClienteDocumento AS PropostaClinicaDocumento, ContatoEmail AS PropostaClinicaEmail FROM Cliente WHERE ClienteId = :PropostaClinicaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A11", "SELECT ClienteId AS PropostaEmpresaClienteId FROM Cliente WHERE ClienteId = :PropostaEmpresaClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A14", "SELECT COALESCE( T1.PropostaValorReembolsado_F, 0) AS PropostaValorReembolsado_F FROM (SELECT SUM(COALESCE( T5.TituloTotalMovimento_F, 0)) AS PropostaValorReembolsado_F, T2.TituloPropostaId FROM (((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T2.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T5 ON T5.TituloId = T2.TituloId) WHERE (T4.ClienteId = :PropostaPacienteClienteId) AND (T2.TituloPropostaId = :PropostaId) GROUP BY T2.TituloPropostaId ) T1 WHERE T1.TituloPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A14,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A17", "SELECT COALESCE( T1.PropostaValorReembolsadoJuros_F, 0) AS PropostaValorReembolsadoJuros_F FROM (SELECT SUM(COALESCE( T5.TituloTotalMovimento_F, 0)) AS PropostaValorReembolsadoJuros_F, T2.TituloPropostaId FROM (((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T2.TituloId = TituloId) AND (Not TituloMovimentoSoma) GROUP BY TituloId ) T5 ON T5.TituloId = T2.TituloId) WHERE (T4.ClienteId = :PropostaPacienteClienteId) AND (T2.TituloPropostaId = :PropostaId) GROUP BY T2.TituloPropostaId ) T1 WHERE T1.TituloPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A17,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A20", "SELECT COALESCE( T1.PropostaValorReembolsado_F, 0) AS PropostaValorTaxaRecebida_F FROM (SELECT SUM(COALESCE( T5.TituloTotalMovimento_F, 0)) AS PropostaValorReembolsado_F, T2.TituloPropostaId FROM (((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T2.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T5 ON T5.TituloId = T2.TituloId) WHERE (T4.ClienteId = :PropostaCratedBy) AND (T2.TituloPropostaId = :PropostaId) GROUP BY T2.TituloPropostaId ) T1 WHERE T1.TituloPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A20,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A23", "SELECT COALESCE( T1.PropostaDataCreditoCliente_F, DATE '00010101') AS PropostaDataCreditoCliente_F FROM (SELECT MAX(COALESCE( T5.TituloDataCredito_F, DATE '00010101')) AS PropostaDataCreditoCliente_F, T2.TituloPropostaId FROM (((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN LATERAL (SELECT MAX(TituloMovimentoDataCredito) AS TituloDataCredito_F, TituloId FROM TituloMovimento WHERE T2.TituloId = TituloId GROUP BY TituloId ) T5 ON T5.TituloId = T2.TituloId) WHERE (T4.ClienteId = :PropostaPacienteClienteId) AND (T2.TituloPropostaId = :PropostaId) AND (T2.TituloTipo = ( 'DEBITO')) GROUP BY T2.TituloPropostaId ) T1 WHERE T1.TituloPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A23,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A25", "SELECT COALESCE( T1.PropostaValorTaxaClinica_F, 0) AS PropostaValorTaxaClinica_F FROM (SELECT SUM(T2.TituloValor) AS PropostaValorTaxaClinica_F, T2.TituloPropostaId FROM ((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) WHERE (T2.TituloPropostaTipo = ( 'TAXA')) AND (T2.TituloPropostaId = :PropostaId) AND (T4.ClienteId = :PropostaClinicaId) GROUP BY T2.TituloPropostaId ) T1 WHERE T1.TituloPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A25,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A27", "SELECT COALESCE( T1.PropostaMaxReembolsoId_F, 0) AS PropostaMaxReembolsoId_F FROM (SELECT MAX(ReembolsoId) AS PropostaMaxReembolsoId_F, ReembolsoPropostaId FROM Reembolso GROUP BY ReembolsoPropostaId ) T1 WHERE T1.ReembolsoPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A27,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A29", "SELECT COALESCE( T1.PropostaQtdItensNota_F, 0) AS PropostaQtdItensNota_F FROM (SELECT COUNT(*) AS PropostaQtdItensNota_F, PropostaId FROM NotaFiscalItem GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A29,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A31", "SELECT COALESCE( T1.PropostaResponsavelSerasaConsultas_F, 0) AS PropostaResponsavelSerasaConsultas_F, COALESCE( T1.PropostaResponsavelSerasaConsultas_F, 0) AS PropostaPacienteSerasaConsultas_F FROM (SELECT COUNT(*) AS PropostaResponsavelSerasaConsultas_F, ClienteId FROM Serasa GROUP BY ClienteId ) T1 WHERE T1.ClienteId = :PropostaPacienteClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A31,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A34", "SELECT COALESCE( T1.PropostaResponsavelSerasaScoreUltimaData_F, 0) AS PropostaResponsavelSerasaScoreUltimaData_F, COALESCE( T1.PropostaResponsavelSerasaScoreUltimaData_F, 0) AS PropostaSerasaScoreUltimaData_F FROM (SELECT MAX(T2.SerasaScore) AS PropostaResponsavelSerasaScoreUltimaData_F, COALESCE( T3.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, T2.ClienteId FROM (Serasa T2 LEFT JOIN LATERAL (SELECT MAX(SerasaCreatedAt) AS SerasaUltimaData_F, ClienteId FROM Serasa WHERE T2.ClienteId = ClienteId GROUP BY ClienteId ) T3 ON T3.ClienteId = T2.ClienteId) WHERE T2.SerasaCreatedAt = COALESCE( T3.SerasaUltimaData_F, DATE '00010101') GROUP BY T3.SerasaUltimaData_F, T2.ClienteId ) T1 WHERE T1.ClienteId = :PropostaPacienteClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A34,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A37", "SELECT COALESCE( T1.PropostaResponsavelSerasaUltimoValorRecomendado_F, 0) AS PropostaResponsavelSerasaUltimoValorRecomendado_F, COALESCE( T1.PropostaResponsavelSerasaUltimoValorRecomendado_F, 0) AS PropostaPacienteSerasaUltimoValorRecomendado_F FROM (SELECT MAX(T2.SerasaValorLimiteRecomendado) AS PropostaResponsavelSerasaUltimoValorRecomendado_F, COALESCE( T3.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, T2.ClienteId FROM (Serasa T2 LEFT JOIN LATERAL (SELECT MAX(SerasaCreatedAt) AS SerasaUltimaData_F, ClienteId FROM Serasa WHERE T2.ClienteId = ClienteId GROUP BY ClienteId ) T3 ON T3.ClienteId = T2.ClienteId) WHERE T2.SerasaCreatedAt = COALESCE( T3.SerasaUltimaData_F, DATE '00010101') GROUP BY T3.SerasaUltimaData_F, T2.ClienteId ) T1 WHERE T1.ClienteId = :PropostaPacienteClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A37,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A39", "SELECT COALESCE( T1.PropostaQtdDocumentoPendente_F, 0) AS PropostaQtdDocumentoPendente_F FROM (SELECT COUNT(*) AS PropostaQtdDocumentoPendente_F, PropostaId FROM PropostaDocumentos WHERE PropostaDocumentosStatus = ( 'AGUARDANDO_ANALISE') or PropostaDocumentosStatus = ( 'REPROVADO') GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A39,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A41", "SELECT COALESCE( T1.PropostaAprovacoes_F, 0) AS PropostaAprovacoes_F FROM (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE AprovacaoStatus = ( 'APROVADO') GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A41,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A43", "SELECT COALESCE( T1.PropostaAprovacoes_F, 0) AS PropostaReprovacoes_F FROM (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE AprovacaoStatus = ( 'REPROVADO') GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A43,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A54", cmdBufferBC001A54,true, GxErrorMask.GX_NOMASK, false, this,prmBC001A54,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A55", "SELECT PropostaId FROM Proposta WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A55,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A56", "SAVEPOINT gxupdate;INSERT INTO Proposta(PropostaCreatedAt, PropostaProtocolo, PropostaTipoProposta, PropostaTitulo, PropostaDescricao, PropostaDataCirurgia, PropostaValor, PropostaValorLiquido, PropostaTaxaAdministrativa, PropostaSLA, PropostaJurosMora, PropostaStatus, PropostaComentarioAnalise, PropostaQuantidadeAprovadores, PropostaReprovacoesPermitidas, ConvenioVencimentoAno, ConvenioVencimentoMes, ContratoId, ProcedimentosMedicosId, ConvenioCategoriaId, PropostaCratedBy, PropostaPacienteClienteId, PropostaResponsavelId, PropostaClinicaId, PropostaEmpresaClienteId) VALUES(:PropostaCreatedAt, :PropostaProtocolo, :PropostaTipoProposta, :PropostaTitulo, :PropostaDescricao, :PropostaDataCirurgia, :PropostaValor, :PropostaValorLiquido, :PropostaTaxaAdministrativa, :PropostaSLA, :PropostaJurosMora, :PropostaStatus, :PropostaComentarioAnalise, :PropostaQuantidadeAprovadores, :PropostaReprovacoesPermitidas, :ConvenioVencimentoAno, :ConvenioVencimentoMes, :ContratoId, :ProcedimentosMedicosId, :ConvenioCategoriaId, :PropostaCratedBy, :PropostaPacienteClienteId, :PropostaResponsavelId, :PropostaClinicaId, :PropostaEmpresaClienteId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001A56)
             ,new CursorDef("BC001A57", "SELECT currval('PropostaId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A57,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A58", "SAVEPOINT gxupdate;UPDATE Proposta SET PropostaCreatedAt=:PropostaCreatedAt, PropostaProtocolo=:PropostaProtocolo, PropostaTipoProposta=:PropostaTipoProposta, PropostaTitulo=:PropostaTitulo, PropostaDescricao=:PropostaDescricao, PropostaDataCirurgia=:PropostaDataCirurgia, PropostaValor=:PropostaValor, PropostaValorLiquido=:PropostaValorLiquido, PropostaTaxaAdministrativa=:PropostaTaxaAdministrativa, PropostaSLA=:PropostaSLA, PropostaJurosMora=:PropostaJurosMora, PropostaStatus=:PropostaStatus, PropostaComentarioAnalise=:PropostaComentarioAnalise, PropostaQuantidadeAprovadores=:PropostaQuantidadeAprovadores, PropostaReprovacoesPermitidas=:PropostaReprovacoesPermitidas, ConvenioVencimentoAno=:ConvenioVencimentoAno, ConvenioVencimentoMes=:ConvenioVencimentoMes, ContratoId=:ContratoId, ProcedimentosMedicosId=:ProcedimentosMedicosId, ConvenioCategoriaId=:ConvenioCategoriaId, PropostaCratedBy=:PropostaCratedBy, PropostaPacienteClienteId=:PropostaPacienteClienteId, PropostaResponsavelId=:PropostaResponsavelId, PropostaClinicaId=:PropostaClinicaId, PropostaEmpresaClienteId=:PropostaEmpresaClienteId  WHERE PropostaId = :PropostaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001A58)
             ,new CursorDef("BC001A59", "SAVEPOINT gxupdate;DELETE FROM Proposta  WHERE PropostaId = :PropostaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001A59)
             ,new CursorDef("BC001A61", "SELECT COALESCE( T1.PropostaMaxReembolsoId_F, 0) AS PropostaMaxReembolsoId_F FROM (SELECT MAX(ReembolsoId) AS PropostaMaxReembolsoId_F, ReembolsoPropostaId FROM Reembolso GROUP BY ReembolsoPropostaId ) T1 WHERE T1.ReembolsoPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A61,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A63", "SELECT COALESCE( T1.PropostaQtdItensNota_F, 0) AS PropostaQtdItensNota_F FROM (SELECT COUNT(*) AS PropostaQtdItensNota_F, PropostaId FROM NotaFiscalItem GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A63,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A65", "SELECT COALESCE( T1.PropostaQtdDocumentoPendente_F, 0) AS PropostaQtdDocumentoPendente_F FROM (SELECT COUNT(*) AS PropostaQtdDocumentoPendente_F, PropostaId FROM PropostaDocumentos WHERE PropostaDocumentosStatus = ( 'AGUARDANDO_ANALISE') or PropostaDocumentosStatus = ( 'REPROVADO') GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A65,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A67", "SELECT COALESCE( T1.PropostaAprovacoes_F, 0) AS PropostaAprovacoes_F FROM (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE AprovacaoStatus = ( 'APROVADO') GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A67,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A69", "SELECT COALESCE( T1.PropostaAprovacoes_F, 0) AS PropostaReprovacoes_F FROM (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE AprovacaoStatus = ( 'REPROVADO') GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A69,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A70", "SELECT ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, ClienteDocumento AS PropostaPacienteClienteDocumento, ContatoEmail AS PropostaPacienteContatoEmail, ContaNumero AS PropostaPacienteConta, ContaAgencia AS PropostaPacienteAgencia, ClientePixTipo AS PropostaPacienteTipoPix, ClientePix AS PropostaPacientePIX, ClienteDepositoTipo AS PropostaPacienteDepositoTipo, EnderecoCEP AS PropostaPacienteEnderecoCEP, EnderecoLogradouro AS PropostaPacienteEnderecoLogradouro, EnderecoNumero AS PropostaPacienteEnderecoNumero, EnderecoComplemento AS PropostaPacienteEnderecoComplemento, EnderecoBairro AS PropostaPacienteEnderecoBairro, MunicipioCodigo AS PropostaPacienteMunicipioCodigo FROM Cliente WHERE ClienteId = :PropostaPacienteClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A70,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A73", "SELECT COALESCE( T1.PropostaValorReembolsado_F, 0) AS PropostaValorReembolsado_F FROM (SELECT SUM(COALESCE( T5.TituloTotalMovimento_F, 0)) AS PropostaValorReembolsado_F, T2.TituloPropostaId FROM (((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T2.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T5 ON T5.TituloId = T2.TituloId) WHERE (T4.ClienteId = :PropostaPacienteClienteId) AND (T2.TituloPropostaId = :PropostaId) GROUP BY T2.TituloPropostaId ) T1 WHERE T1.TituloPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A73,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A76", "SELECT COALESCE( T1.PropostaValorReembolsadoJuros_F, 0) AS PropostaValorReembolsadoJuros_F FROM (SELECT SUM(COALESCE( T5.TituloTotalMovimento_F, 0)) AS PropostaValorReembolsadoJuros_F, T2.TituloPropostaId FROM (((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T2.TituloId = TituloId) AND (Not TituloMovimentoSoma) GROUP BY TituloId ) T5 ON T5.TituloId = T2.TituloId) WHERE (T4.ClienteId = :PropostaPacienteClienteId) AND (T2.TituloPropostaId = :PropostaId) GROUP BY T2.TituloPropostaId ) T1 WHERE T1.TituloPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A76,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A79", "SELECT COALESCE( T1.PropostaDataCreditoCliente_F, DATE '00010101') AS PropostaDataCreditoCliente_F FROM (SELECT MAX(COALESCE( T5.TituloDataCredito_F, DATE '00010101')) AS PropostaDataCreditoCliente_F, T2.TituloPropostaId FROM (((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN LATERAL (SELECT MAX(TituloMovimentoDataCredito) AS TituloDataCredito_F, TituloId FROM TituloMovimento WHERE T2.TituloId = TituloId GROUP BY TituloId ) T5 ON T5.TituloId = T2.TituloId) WHERE (T4.ClienteId = :PropostaPacienteClienteId) AND (T2.TituloPropostaId = :PropostaId) AND (T2.TituloTipo = ( 'DEBITO')) GROUP BY T2.TituloPropostaId ) T1 WHERE T1.TituloPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A79,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A81", "SELECT COALESCE( T1.PropostaResponsavelSerasaConsultas_F, 0) AS PropostaResponsavelSerasaConsultas_F, COALESCE( T1.PropostaResponsavelSerasaConsultas_F, 0) AS PropostaPacienteSerasaConsultas_F FROM (SELECT COUNT(*) AS PropostaResponsavelSerasaConsultas_F, ClienteId FROM Serasa GROUP BY ClienteId ) T1 WHERE T1.ClienteId = :PropostaPacienteClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A81,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A84", "SELECT COALESCE( T1.PropostaResponsavelSerasaScoreUltimaData_F, 0) AS PropostaResponsavelSerasaScoreUltimaData_F, COALESCE( T1.PropostaResponsavelSerasaScoreUltimaData_F, 0) AS PropostaSerasaScoreUltimaData_F FROM (SELECT MAX(T2.SerasaScore) AS PropostaResponsavelSerasaScoreUltimaData_F, COALESCE( T3.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, T2.ClienteId FROM (Serasa T2 LEFT JOIN LATERAL (SELECT MAX(SerasaCreatedAt) AS SerasaUltimaData_F, ClienteId FROM Serasa WHERE T2.ClienteId = ClienteId GROUP BY ClienteId ) T3 ON T3.ClienteId = T2.ClienteId) WHERE T2.SerasaCreatedAt = COALESCE( T3.SerasaUltimaData_F, DATE '00010101') GROUP BY T3.SerasaUltimaData_F, T2.ClienteId ) T1 WHERE T1.ClienteId = :PropostaPacienteClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A84,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A87", "SELECT COALESCE( T1.PropostaResponsavelSerasaUltimoValorRecomendado_F, 0) AS PropostaResponsavelSerasaUltimoValorRecomendado_F, COALESCE( T1.PropostaResponsavelSerasaUltimoValorRecomendado_F, 0) AS PropostaPacienteSerasaUltimoValorRecomendado_F FROM (SELECT MAX(T2.SerasaValorLimiteRecomendado) AS PropostaResponsavelSerasaUltimoValorRecomendado_F, COALESCE( T3.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, T2.ClienteId FROM (Serasa T2 LEFT JOIN LATERAL (SELECT MAX(SerasaCreatedAt) AS SerasaUltimaData_F, ClienteId FROM Serasa WHERE T2.ClienteId = ClienteId GROUP BY ClienteId ) T3 ON T3.ClienteId = T2.ClienteId) WHERE T2.SerasaCreatedAt = COALESCE( T3.SerasaUltimaData_F, DATE '00010101') GROUP BY T3.SerasaUltimaData_F, T2.ClienteId ) T1 WHERE T1.ClienteId = :PropostaPacienteClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A87,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A88", "SELECT ClienteDocumento AS PropostaResponsavelDocumento, ClienteRazaoSocial AS PropostaResponsavelRazaoSocial, ContatoEmail AS PropostaResponsavelEmail, ContaNumero AS PropostaResponsavelConta, ContaAgencia AS PropostaResponsavelAgencia, ClientePixTipo AS PropostaResponsavelTipoPix, ClientePix AS PropostaResponsavelPIX, ClienteDepositoTipo AS PropostaResponsavelDepositoTipo FROM Cliente WHERE ClienteId = :PropostaResponsavelId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A88,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A89", "SELECT SecUserFullName AS PropostaSecUserName FROM SecUser WHERE SecUserId = :PropostaCratedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A89,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A92", "SELECT COALESCE( T1.PropostaValorReembolsado_F, 0) AS PropostaValorTaxaRecebida_F FROM (SELECT SUM(COALESCE( T5.TituloTotalMovimento_F, 0)) AS PropostaValorReembolsado_F, T2.TituloPropostaId FROM (((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T2.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T5 ON T5.TituloId = T2.TituloId) WHERE (T4.ClienteId = :PropostaCratedBy) AND (T2.TituloPropostaId = :PropostaId) GROUP BY T2.TituloPropostaId ) T1 WHERE T1.TituloPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A92,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A93", "SELECT ClienteRazaoSocial AS PropostaClinicaNome, ClienteNomeFantasia AS PropostaClinicaNomeFantasia, ClienteDocumento AS PropostaClinicaDocumento, ContatoEmail AS PropostaClinicaEmail FROM Cliente WHERE ClienteId = :PropostaClinicaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A93,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A95", "SELECT COALESCE( T1.PropostaValorTaxaClinica_F, 0) AS PropostaValorTaxaClinica_F FROM (SELECT SUM(T2.TituloValor) AS PropostaValorTaxaClinica_F, T2.TituloPropostaId FROM ((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) WHERE (T2.TituloPropostaTipo = ( 'TAXA')) AND (T2.TituloPropostaId = :PropostaId) AND (T4.ClienteId = :PropostaClinicaId) GROUP BY T2.TituloPropostaId ) T1 WHERE T1.TituloPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A95,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A96", "SELECT ContratoNome FROM Contrato WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A96,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A97", "SELECT ConvenioCategoriaDescricao, ConvenioId FROM ConvenioCategoria WHERE ConvenioCategoriaId = :ConvenioCategoriaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A97,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001A98", "SELECT ContratoId FROM Contrato WHERE ContratoPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A98,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001A99", "SELECT ReembolsoId FROM Reembolso WHERE ReembolsoPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A99,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001A100", "SELECT TituloId FROM Titulo WHERE TituloPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A100,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001A101", "SELECT NotaFiscalItemId FROM NotaFiscalItem WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A101,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001A102", "SELECT PropostaContratoAssinaturaId FROM PropostaContratoAssinatura WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A102,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001A103", "SELECT PropostaDocumentosId FROM PropostaDocumentos WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A103,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001A104", "SELECT AprovacaoId FROM Aprovacao WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001A104,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001A115", cmdBufferBC001A115,true, GxErrorMask.GX_NOMASK, false, this,prmBC001A115,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((short[]) buf[19])[0] = rslt.getShort(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((short[]) buf[27])[0] = rslt.getShort(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((short[]) buf[29])[0] = rslt.getShort(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((short[]) buf[31])[0] = rslt.getShort(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((short[]) buf[33])[0] = rslt.getShort(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((int[]) buf[35])[0] = rslt.getInt(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((int[]) buf[37])[0] = rslt.getInt(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((int[]) buf[39])[0] = rslt.getInt(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((short[]) buf[41])[0] = rslt.getShort(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((int[]) buf[43])[0] = rslt.getInt(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((int[]) buf[45])[0] = rslt.getInt(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((int[]) buf[47])[0] = rslt.getInt(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((int[]) buf[49])[0] = rslt.getInt(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((short[]) buf[19])[0] = rslt.getShort(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((short[]) buf[27])[0] = rslt.getShort(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((short[]) buf[29])[0] = rslt.getShort(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((short[]) buf[31])[0] = rslt.getShort(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((short[]) buf[33])[0] = rslt.getShort(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((int[]) buf[35])[0] = rslt.getInt(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((int[]) buf[37])[0] = rslt.getInt(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((int[]) buf[39])[0] = rslt.getInt(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((short[]) buf[41])[0] = rslt.getShort(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((int[]) buf[43])[0] = rslt.getInt(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((int[]) buf[45])[0] = rslt.getInt(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((int[]) buf[47])[0] = rslt.getInt(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((int[]) buf[49])[0] = rslt.getInt(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 11 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 12 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 13 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 14 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 17 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 19 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 20 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 21 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 22 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 23 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
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
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((string[]) buf[41])[0] = rslt.getVarchar(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((string[]) buf[43])[0] = rslt.getVarchar(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((string[]) buf[47])[0] = rslt.getVarchar(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((string[]) buf[51])[0] = rslt.getVarchar(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((DateTime[]) buf[53])[0] = rslt.getGXDate(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((decimal[]) buf[55])[0] = rslt.getDecimal(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((decimal[]) buf[57])[0] = rslt.getDecimal(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((decimal[]) buf[59])[0] = rslt.getDecimal(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((short[]) buf[61])[0] = rslt.getShort(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((decimal[]) buf[63])[0] = rslt.getDecimal(33);
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                ((string[]) buf[65])[0] = rslt.getVarchar(34);
                ((bool[]) buf[66])[0] = rslt.wasNull(34);
                ((string[]) buf[67])[0] = rslt.getVarchar(35);
                ((bool[]) buf[68])[0] = rslt.wasNull(35);
                ((string[]) buf[69])[0] = rslt.getVarchar(36);
                ((bool[]) buf[70])[0] = rslt.wasNull(36);
                ((string[]) buf[71])[0] = rslt.getVarchar(37);
                ((bool[]) buf[72])[0] = rslt.wasNull(37);
                ((string[]) buf[73])[0] = rslt.getVarchar(38);
                ((bool[]) buf[74])[0] = rslt.wasNull(38);
                ((string[]) buf[75])[0] = rslt.getVarchar(39);
                ((bool[]) buf[76])[0] = rslt.wasNull(39);
                ((string[]) buf[77])[0] = rslt.getVarchar(40);
                ((bool[]) buf[78])[0] = rslt.wasNull(40);
                ((short[]) buf[79])[0] = rslt.getShort(41);
                ((bool[]) buf[80])[0] = rslt.wasNull(41);
                ((short[]) buf[81])[0] = rslt.getShort(42);
                ((bool[]) buf[82])[0] = rslt.wasNull(42);
                ((string[]) buf[83])[0] = rslt.getVarchar(43);
                ((bool[]) buf[84])[0] = rslt.wasNull(43);
                ((short[]) buf[85])[0] = rslt.getShort(44);
                ((bool[]) buf[86])[0] = rslt.wasNull(44);
                ((short[]) buf[87])[0] = rslt.getShort(45);
                ((bool[]) buf[88])[0] = rslt.wasNull(45);
                ((string[]) buf[89])[0] = rslt.getVarchar(46);
                ((bool[]) buf[90])[0] = rslt.wasNull(46);
                ((int[]) buf[91])[0] = rslt.getInt(47);
                ((bool[]) buf[92])[0] = rslt.wasNull(47);
                ((int[]) buf[93])[0] = rslt.getInt(48);
                ((bool[]) buf[94])[0] = rslt.wasNull(48);
                ((int[]) buf[95])[0] = rslt.getInt(49);
                ((bool[]) buf[96])[0] = rslt.wasNull(49);
                ((short[]) buf[97])[0] = rslt.getShort(50);
                ((bool[]) buf[98])[0] = rslt.wasNull(50);
                ((int[]) buf[99])[0] = rslt.getInt(51);
                ((bool[]) buf[100])[0] = rslt.wasNull(51);
                ((int[]) buf[101])[0] = rslt.getInt(52);
                ((bool[]) buf[102])[0] = rslt.wasNull(52);
                ((int[]) buf[103])[0] = rslt.getInt(53);
                ((bool[]) buf[104])[0] = rslt.wasNull(53);
                ((int[]) buf[105])[0] = rslt.getInt(54);
                ((bool[]) buf[106])[0] = rslt.wasNull(54);
                ((int[]) buf[107])[0] = rslt.getInt(55);
                ((bool[]) buf[108])[0] = rslt.wasNull(55);
                ((string[]) buf[109])[0] = rslt.getVarchar(56);
                ((bool[]) buf[110])[0] = rslt.wasNull(56);
                ((int[]) buf[111])[0] = rslt.getInt(57);
                ((bool[]) buf[112])[0] = rslt.wasNull(57);
                ((short[]) buf[113])[0] = rslt.getShort(58);
                ((bool[]) buf[114])[0] = rslt.wasNull(58);
                ((short[]) buf[115])[0] = rslt.getShort(59);
                ((bool[]) buf[116])[0] = rslt.wasNull(59);
                ((short[]) buf[117])[0] = rslt.getShort(60);
                ((bool[]) buf[118])[0] = rslt.wasNull(60);
                ((decimal[]) buf[119])[0] = rslt.getDecimal(61);
                ((bool[]) buf[120])[0] = rslt.wasNull(61);
                ((short[]) buf[121])[0] = rslt.getShort(62);
                ((bool[]) buf[122])[0] = rslt.wasNull(62);
                ((short[]) buf[123])[0] = rslt.getShort(63);
                ((bool[]) buf[124])[0] = rslt.wasNull(63);
                ((decimal[]) buf[125])[0] = rslt.getDecimal(64);
                ((bool[]) buf[126])[0] = rslt.wasNull(64);
                ((short[]) buf[127])[0] = rslt.getShort(65);
                ((bool[]) buf[128])[0] = rslt.wasNull(65);
                ((short[]) buf[129])[0] = rslt.getShort(66);
                ((bool[]) buf[130])[0] = rslt.wasNull(66);
                ((short[]) buf[131])[0] = rslt.getShort(67);
                ((bool[]) buf[132])[0] = rslt.wasNull(67);
                return;
             case 24 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 26 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 29 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 31 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 32 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 33 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 34 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 38 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 39 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 40 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 41 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                return;
             case 42 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 43 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 44 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                return;
             case 45 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 46 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 47 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 48 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 49 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 50 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 51 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 52 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 53 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 54 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 55 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
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
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((string[]) buf[41])[0] = rslt.getVarchar(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((string[]) buf[43])[0] = rslt.getVarchar(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((string[]) buf[47])[0] = rslt.getVarchar(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((string[]) buf[51])[0] = rslt.getVarchar(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((DateTime[]) buf[53])[0] = rslt.getGXDate(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((decimal[]) buf[55])[0] = rslt.getDecimal(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((decimal[]) buf[57])[0] = rslt.getDecimal(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((decimal[]) buf[59])[0] = rslt.getDecimal(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((short[]) buf[61])[0] = rslt.getShort(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((decimal[]) buf[63])[0] = rslt.getDecimal(33);
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                ((string[]) buf[65])[0] = rslt.getVarchar(34);
                ((bool[]) buf[66])[0] = rslt.wasNull(34);
                ((string[]) buf[67])[0] = rslt.getVarchar(35);
                ((bool[]) buf[68])[0] = rslt.wasNull(35);
                ((string[]) buf[69])[0] = rslt.getVarchar(36);
                ((bool[]) buf[70])[0] = rslt.wasNull(36);
                ((string[]) buf[71])[0] = rslt.getVarchar(37);
                ((bool[]) buf[72])[0] = rslt.wasNull(37);
                ((string[]) buf[73])[0] = rslt.getVarchar(38);
                ((bool[]) buf[74])[0] = rslt.wasNull(38);
                ((string[]) buf[75])[0] = rslt.getVarchar(39);
                ((bool[]) buf[76])[0] = rslt.wasNull(39);
                ((string[]) buf[77])[0] = rslt.getVarchar(40);
                ((bool[]) buf[78])[0] = rslt.wasNull(40);
                ((short[]) buf[79])[0] = rslt.getShort(41);
                ((bool[]) buf[80])[0] = rslt.wasNull(41);
                ((short[]) buf[81])[0] = rslt.getShort(42);
                ((bool[]) buf[82])[0] = rslt.wasNull(42);
                ((string[]) buf[83])[0] = rslt.getVarchar(43);
                ((bool[]) buf[84])[0] = rslt.wasNull(43);
                ((short[]) buf[85])[0] = rslt.getShort(44);
                ((bool[]) buf[86])[0] = rslt.wasNull(44);
                ((short[]) buf[87])[0] = rslt.getShort(45);
                ((bool[]) buf[88])[0] = rslt.wasNull(45);
                ((string[]) buf[89])[0] = rslt.getVarchar(46);
                ((bool[]) buf[90])[0] = rslt.wasNull(46);
                ((int[]) buf[91])[0] = rslt.getInt(47);
                ((bool[]) buf[92])[0] = rslt.wasNull(47);
                ((int[]) buf[93])[0] = rslt.getInt(48);
                ((bool[]) buf[94])[0] = rslt.wasNull(48);
                ((int[]) buf[95])[0] = rslt.getInt(49);
                ((bool[]) buf[96])[0] = rslt.wasNull(49);
                ((short[]) buf[97])[0] = rslt.getShort(50);
                ((bool[]) buf[98])[0] = rslt.wasNull(50);
                ((int[]) buf[99])[0] = rslt.getInt(51);
                ((bool[]) buf[100])[0] = rslt.wasNull(51);
                ((int[]) buf[101])[0] = rslt.getInt(52);
                ((bool[]) buf[102])[0] = rslt.wasNull(52);
                ((int[]) buf[103])[0] = rslt.getInt(53);
                ((bool[]) buf[104])[0] = rslt.wasNull(53);
                ((int[]) buf[105])[0] = rslt.getInt(54);
                ((bool[]) buf[106])[0] = rslt.wasNull(54);
                ((int[]) buf[107])[0] = rslt.getInt(55);
                ((bool[]) buf[108])[0] = rslt.wasNull(55);
                ((string[]) buf[109])[0] = rslt.getVarchar(56);
                ((bool[]) buf[110])[0] = rslt.wasNull(56);
                ((int[]) buf[111])[0] = rslt.getInt(57);
                ((bool[]) buf[112])[0] = rslt.wasNull(57);
                ((short[]) buf[113])[0] = rslt.getShort(58);
                ((bool[]) buf[114])[0] = rslt.wasNull(58);
                ((short[]) buf[115])[0] = rslt.getShort(59);
                ((bool[]) buf[116])[0] = rslt.wasNull(59);
                ((short[]) buf[117])[0] = rslt.getShort(60);
                ((bool[]) buf[118])[0] = rslt.wasNull(60);
                ((decimal[]) buf[119])[0] = rslt.getDecimal(61);
                ((bool[]) buf[120])[0] = rslt.wasNull(61);
                ((short[]) buf[121])[0] = rslt.getShort(62);
                ((bool[]) buf[122])[0] = rslt.wasNull(62);
                ((short[]) buf[123])[0] = rslt.getShort(63);
                ((bool[]) buf[124])[0] = rslt.wasNull(63);
                ((decimal[]) buf[125])[0] = rslt.getDecimal(64);
                ((bool[]) buf[126])[0] = rslt.wasNull(64);
                ((short[]) buf[127])[0] = rslt.getShort(65);
                ((bool[]) buf[128])[0] = rslt.wasNull(65);
                ((short[]) buf[129])[0] = rslt.getShort(66);
                ((bool[]) buf[130])[0] = rslt.wasNull(66);
                ((short[]) buf[131])[0] = rslt.getShort(67);
                ((bool[]) buf[132])[0] = rslt.wasNull(67);
                return;
       }
    }

 }

}
