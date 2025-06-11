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
   public class propostacontratoadm_bc : GxSilentTrn, IGxSilentTrn
   {
      public propostacontratoadm_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public propostacontratoadm_bc( IGxContext context )
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
         ReadRow2949( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2949( ) ;
         standaloneModal( ) ;
         AddRow2949( ) ;
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
            E11292 ();
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

      protected void CONFIRM_290( )
      {
         BeforeValidate2949( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2949( ) ;
            }
            else
            {
               CheckExtendedTable2949( ) ;
               if ( AnyError == 0 )
               {
                  ZM2949( 11) ;
                  ZM2949( 12) ;
                  ZM2949( 13) ;
                  ZM2949( 14) ;
                  ZM2949( 15) ;
                  ZM2949( 16) ;
                  ZM2949( 17) ;
               }
               CloseExtendedTableCursors2949( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12292( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV30Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV31GXV1 = 1;
            while ( AV31GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV31GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "ProcedimentosMedicosId") == 0 )
               {
                  AV24Insert_ProcedimentosMedicosId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "PropostaCratedBy") == 0 )
               {
                  AV11Insert_PropostaCratedBy = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "ContratoId") == 0 )
               {
                  AV12Insert_ContratoId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "PropostaPacienteClienteId") == 0 )
               {
                  AV29Insert_PropostaPacienteClienteId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV31GXV1 = (int)(AV31GXV1+1);
            }
         }
      }

      protected void E11292( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM2949( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z327PropostaCreatedAt = A327PropostaCreatedAt;
            Z324PropostaTitulo = A324PropostaTitulo;
            Z325PropostaDescricao = A325PropostaDescricao;
            Z326PropostaValor = A326PropostaValor;
            Z329PropostaStatus = A329PropostaStatus;
            Z330PropostaQuantidadeAprovadores = A330PropostaQuantidadeAprovadores;
            Z345PropostaReprovacoesPermitidas = A345PropostaReprovacoesPermitidas;
            Z227ContratoId = A227ContratoId;
            Z376ProcedimentosMedicosId = A376ProcedimentosMedicosId;
            Z328PropostaCratedBy = A328PropostaCratedBy;
            Z504PropostaPacienteClienteId = A504PropostaPacienteClienteId;
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z343PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
            Z548ReembolsoStatusAtual_F = A548ReembolsoStatusAtual_F;
         }
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z228ContratoNome = A228ContratoNome;
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z343PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
            Z548ReembolsoStatusAtual_F = A548ReembolsoStatusAtual_F;
         }
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z343PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
            Z548ReembolsoStatusAtual_F = A548ReembolsoStatusAtual_F;
         }
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z343PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
            Z548ReembolsoStatusAtual_F = A548ReembolsoStatusAtual_F;
         }
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            Z505PropostaPacienteClienteRazaoSocial = A505PropostaPacienteClienteRazaoSocial;
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z343PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
            Z548ReembolsoStatusAtual_F = A548ReembolsoStatusAtual_F;
         }
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z343PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
            Z548ReembolsoStatusAtual_F = A548ReembolsoStatusAtual_F;
         }
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z343PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
            Z548ReembolsoStatusAtual_F = A548ReembolsoStatusAtual_F;
         }
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z343PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
            Z548ReembolsoStatusAtual_F = A548ReembolsoStatusAtual_F;
         }
         if ( GX_JID == -10 )
         {
            Z323PropostaId = A323PropostaId;
            Z327PropostaCreatedAt = A327PropostaCreatedAt;
            Z324PropostaTitulo = A324PropostaTitulo;
            Z325PropostaDescricao = A325PropostaDescricao;
            Z326PropostaValor = A326PropostaValor;
            Z329PropostaStatus = A329PropostaStatus;
            Z330PropostaQuantidadeAprovadores = A330PropostaQuantidadeAprovadores;
            Z345PropostaReprovacoesPermitidas = A345PropostaReprovacoesPermitidas;
            Z227ContratoId = A227ContratoId;
            Z376ProcedimentosMedicosId = A376ProcedimentosMedicosId;
            Z328PropostaCratedBy = A328PropostaCratedBy;
            Z504PropostaPacienteClienteId = A504PropostaPacienteClienteId;
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z548ReembolsoStatusAtual_F = A548ReembolsoStatusAtual_F;
            Z228ContratoNome = A228ContratoNome;
            Z505PropostaPacienteClienteRazaoSocial = A505PropostaPacienteClienteRazaoSocial;
         }
      }

      protected void standaloneNotModal( )
      {
         AV30Pgmname = "PropostaContratoAdm_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A327PropostaCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n327PropostaCreatedAt = false;
         }
      }

      protected void Load2949( )
      {
         /* Using cursor BC002919 */
         pr_default.execute(9, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound49 = 1;
            A327PropostaCreatedAt = BC002919_A327PropostaCreatedAt[0];
            n327PropostaCreatedAt = BC002919_n327PropostaCreatedAt[0];
            A324PropostaTitulo = BC002919_A324PropostaTitulo[0];
            n324PropostaTitulo = BC002919_n324PropostaTitulo[0];
            A325PropostaDescricao = BC002919_A325PropostaDescricao[0];
            n325PropostaDescricao = BC002919_n325PropostaDescricao[0];
            A326PropostaValor = BC002919_A326PropostaValor[0];
            n326PropostaValor = BC002919_n326PropostaValor[0];
            A329PropostaStatus = BC002919_A329PropostaStatus[0];
            n329PropostaStatus = BC002919_n329PropostaStatus[0];
            A228ContratoNome = BC002919_A228ContratoNome[0];
            n228ContratoNome = BC002919_n228ContratoNome[0];
            A330PropostaQuantidadeAprovadores = BC002919_A330PropostaQuantidadeAprovadores[0];
            n330PropostaQuantidadeAprovadores = BC002919_n330PropostaQuantidadeAprovadores[0];
            A345PropostaReprovacoesPermitidas = BC002919_A345PropostaReprovacoesPermitidas[0];
            n345PropostaReprovacoesPermitidas = BC002919_n345PropostaReprovacoesPermitidas[0];
            A505PropostaPacienteClienteRazaoSocial = BC002919_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = BC002919_n505PropostaPacienteClienteRazaoSocial[0];
            A227ContratoId = BC002919_A227ContratoId[0];
            n227ContratoId = BC002919_n227ContratoId[0];
            A376ProcedimentosMedicosId = BC002919_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = BC002919_n376ProcedimentosMedicosId[0];
            A328PropostaCratedBy = BC002919_A328PropostaCratedBy[0];
            n328PropostaCratedBy = BC002919_n328PropostaCratedBy[0];
            A504PropostaPacienteClienteId = BC002919_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = BC002919_n504PropostaPacienteClienteId[0];
            A341PropostaAprovacoes_F = BC002919_A341PropostaAprovacoes_F[0];
            n341PropostaAprovacoes_F = BC002919_n341PropostaAprovacoes_F[0];
            A342PropostaReprovacoes_F = BC002919_A342PropostaReprovacoes_F[0];
            n342PropostaReprovacoes_F = BC002919_n342PropostaReprovacoes_F[0];
            A548ReembolsoStatusAtual_F = BC002919_A548ReembolsoStatusAtual_F[0];
            n548ReembolsoStatusAtual_F = BC002919_n548ReembolsoStatusAtual_F[0];
            ZM2949( -10) ;
         }
         pr_default.close(9);
         OnLoadActions2949( ) ;
      }

      protected void OnLoadActions2949( )
      {
         A343PropostaAprovacoesRestantes_F = (short)(A330PropostaQuantidadeAprovadores-A341PropostaAprovacoes_F);
         if ( (0==A376ProcedimentosMedicosId) )
         {
            A376ProcedimentosMedicosId = 0;
            n376ProcedimentosMedicosId = false;
            n376ProcedimentosMedicosId = true;
            n376ProcedimentosMedicosId = true;
         }
         if ( (0==A328PropostaCratedBy) )
         {
            A328PropostaCratedBy = 0;
            n328PropostaCratedBy = false;
            n328PropostaCratedBy = true;
            n328PropostaCratedBy = true;
         }
         if ( (0==A227ContratoId) )
         {
            A227ContratoId = 0;
            n227ContratoId = false;
            n227ContratoId = true;
            n227ContratoId = true;
         }
      }

      protected void CheckExtendedTable2949( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00299 */
         pr_default.execute(6, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            A341PropostaAprovacoes_F = BC00299_A341PropostaAprovacoes_F[0];
            n341PropostaAprovacoes_F = BC00299_n341PropostaAprovacoes_F[0];
         }
         else
         {
            A341PropostaAprovacoes_F = 0;
            n341PropostaAprovacoes_F = false;
         }
         pr_default.close(6);
         A343PropostaAprovacoesRestantes_F = (short)(A330PropostaQuantidadeAprovadores-A341PropostaAprovacoes_F);
         /* Using cursor BC002911 */
         pr_default.execute(7, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            A342PropostaReprovacoes_F = BC002911_A342PropostaReprovacoes_F[0];
            n342PropostaReprovacoes_F = BC002911_n342PropostaReprovacoes_F[0];
         }
         else
         {
            A342PropostaReprovacoes_F = 0;
            n342PropostaReprovacoes_F = false;
         }
         pr_default.close(7);
         /* Using cursor BC002914 */
         pr_default.execute(8, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A548ReembolsoStatusAtual_F = BC002914_A548ReembolsoStatusAtual_F[0];
            n548ReembolsoStatusAtual_F = BC002914_n548ReembolsoStatusAtual_F[0];
         }
         else
         {
            A548ReembolsoStatusAtual_F = "";
            n548ReembolsoStatusAtual_F = false;
         }
         pr_default.close(8);
         if ( (0==A376ProcedimentosMedicosId) )
         {
            A376ProcedimentosMedicosId = 0;
            n376ProcedimentosMedicosId = false;
            n376ProcedimentosMedicosId = true;
            n376ProcedimentosMedicosId = true;
         }
         /* Using cursor BC00295 */
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
         if ( ( A326PropostaValor < Convert.ToDecimal( 0 )) )
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
         /* Using cursor BC00296 */
         pr_default.execute(4, new Object[] {n328PropostaCratedBy, A328PropostaCratedBy});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A328PropostaCratedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sec User Proposta'.", "ForeignKeyNotFound", 1, "PROPOSTACRATEDBY");
               AnyError = 1;
            }
         }
         pr_default.close(4);
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
         /* Using cursor BC00294 */
         pr_default.execute(2, new Object[] {n227ContratoId, A227ContratoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A227ContratoId) ) )
            {
               GX_msglist.addItem("Não existe 'Contrato'.", "ForeignKeyNotFound", 1, "CONTRATOID");
               AnyError = 1;
            }
         }
         A228ContratoNome = BC00294_A228ContratoNome[0];
         n228ContratoNome = BC00294_n228ContratoNome[0];
         pr_default.close(2);
         /* Using cursor BC00297 */
         pr_default.execute(5, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A504PropostaPacienteClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Proposta Cliente'.", "ForeignKeyNotFound", 1, "PROPOSTAPACIENTECLIENTEID");
               AnyError = 1;
            }
         }
         A505PropostaPacienteClienteRazaoSocial = BC00297_A505PropostaPacienteClienteRazaoSocial[0];
         n505PropostaPacienteClienteRazaoSocial = BC00297_n505PropostaPacienteClienteRazaoSocial[0];
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors2949( )
      {
         pr_default.close(6);
         pr_default.close(7);
         pr_default.close(8);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(2);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2949( )
      {
         /* Using cursor BC002920 */
         pr_default.execute(10, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound49 = 1;
         }
         else
         {
            RcdFound49 = 0;
         }
         pr_default.close(10);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00293 */
         pr_default.execute(1, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2949( 10) ;
            RcdFound49 = 1;
            A323PropostaId = BC00293_A323PropostaId[0];
            n323PropostaId = BC00293_n323PropostaId[0];
            A327PropostaCreatedAt = BC00293_A327PropostaCreatedAt[0];
            n327PropostaCreatedAt = BC00293_n327PropostaCreatedAt[0];
            A324PropostaTitulo = BC00293_A324PropostaTitulo[0];
            n324PropostaTitulo = BC00293_n324PropostaTitulo[0];
            A325PropostaDescricao = BC00293_A325PropostaDescricao[0];
            n325PropostaDescricao = BC00293_n325PropostaDescricao[0];
            A326PropostaValor = BC00293_A326PropostaValor[0];
            n326PropostaValor = BC00293_n326PropostaValor[0];
            A329PropostaStatus = BC00293_A329PropostaStatus[0];
            n329PropostaStatus = BC00293_n329PropostaStatus[0];
            A330PropostaQuantidadeAprovadores = BC00293_A330PropostaQuantidadeAprovadores[0];
            n330PropostaQuantidadeAprovadores = BC00293_n330PropostaQuantidadeAprovadores[0];
            A345PropostaReprovacoesPermitidas = BC00293_A345PropostaReprovacoesPermitidas[0];
            n345PropostaReprovacoesPermitidas = BC00293_n345PropostaReprovacoesPermitidas[0];
            A227ContratoId = BC00293_A227ContratoId[0];
            n227ContratoId = BC00293_n227ContratoId[0];
            A376ProcedimentosMedicosId = BC00293_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = BC00293_n376ProcedimentosMedicosId[0];
            A328PropostaCratedBy = BC00293_A328PropostaCratedBy[0];
            n328PropostaCratedBy = BC00293_n328PropostaCratedBy[0];
            A504PropostaPacienteClienteId = BC00293_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = BC00293_n504PropostaPacienteClienteId[0];
            Z323PropostaId = A323PropostaId;
            sMode49 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2949( ) ;
            if ( AnyError == 1 )
            {
               RcdFound49 = 0;
               InitializeNonKey2949( ) ;
            }
            Gx_mode = sMode49;
         }
         else
         {
            RcdFound49 = 0;
            InitializeNonKey2949( ) ;
            sMode49 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode49;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2949( ) ;
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
         CONFIRM_290( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2949( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00292 */
            pr_default.execute(0, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Proposta"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z327PropostaCreatedAt != BC00292_A327PropostaCreatedAt[0] ) || ( StringUtil.StrCmp(Z324PropostaTitulo, BC00292_A324PropostaTitulo[0]) != 0 ) || ( StringUtil.StrCmp(Z325PropostaDescricao, BC00292_A325PropostaDescricao[0]) != 0 ) || ( Z326PropostaValor != BC00292_A326PropostaValor[0] ) || ( StringUtil.StrCmp(Z329PropostaStatus, BC00292_A329PropostaStatus[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z330PropostaQuantidadeAprovadores != BC00292_A330PropostaQuantidadeAprovadores[0] ) || ( Z345PropostaReprovacoesPermitidas != BC00292_A345PropostaReprovacoesPermitidas[0] ) || ( Z227ContratoId != BC00292_A227ContratoId[0] ) || ( Z376ProcedimentosMedicosId != BC00292_A376ProcedimentosMedicosId[0] ) || ( Z328PropostaCratedBy != BC00292_A328PropostaCratedBy[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z504PropostaPacienteClienteId != BC00292_A504PropostaPacienteClienteId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Proposta"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2949( )
      {
         BeforeValidate2949( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2949( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2949( 0) ;
            CheckOptimisticConcurrency2949( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2949( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2949( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002921 */
                     pr_default.execute(11, new Object[] {n327PropostaCreatedAt, A327PropostaCreatedAt, n324PropostaTitulo, A324PropostaTitulo, n325PropostaDescricao, A325PropostaDescricao, n326PropostaValor, A326PropostaValor, n329PropostaStatus, A329PropostaStatus, n330PropostaQuantidadeAprovadores, A330PropostaQuantidadeAprovadores, n345PropostaReprovacoesPermitidas, A345PropostaReprovacoesPermitidas, n227ContratoId, A227ContratoId, n376ProcedimentosMedicosId, A376ProcedimentosMedicosId, n328PropostaCratedBy, A328PropostaCratedBy, n504PropostaPacienteClienteId, A504PropostaPacienteClienteId});
                     pr_default.close(11);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC002922 */
                     pr_default.execute(12);
                     A323PropostaId = BC002922_A323PropostaId[0];
                     n323PropostaId = BC002922_n323PropostaId[0];
                     pr_default.close(12);
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
               Load2949( ) ;
            }
            EndLevel2949( ) ;
         }
         CloseExtendedTableCursors2949( ) ;
      }

      protected void Update2949( )
      {
         BeforeValidate2949( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2949( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2949( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2949( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2949( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002923 */
                     pr_default.execute(13, new Object[] {n327PropostaCreatedAt, A327PropostaCreatedAt, n324PropostaTitulo, A324PropostaTitulo, n325PropostaDescricao, A325PropostaDescricao, n326PropostaValor, A326PropostaValor, n329PropostaStatus, A329PropostaStatus, n330PropostaQuantidadeAprovadores, A330PropostaQuantidadeAprovadores, n345PropostaReprovacoesPermitidas, A345PropostaReprovacoesPermitidas, n227ContratoId, A227ContratoId, n376ProcedimentosMedicosId, A376ProcedimentosMedicosId, n328PropostaCratedBy, A328PropostaCratedBy, n504PropostaPacienteClienteId, A504PropostaPacienteClienteId, n323PropostaId, A323PropostaId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Proposta");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Proposta"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2949( ) ;
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
            EndLevel2949( ) ;
         }
         CloseExtendedTableCursors2949( ) ;
      }

      protected void DeferredUpdate2949( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2949( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2949( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2949( ) ;
            AfterConfirm2949( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2949( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002924 */
                  pr_default.execute(14, new Object[] {n323PropostaId, A323PropostaId});
                  pr_default.close(14);
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
         EndLevel2949( ) ;
         Gx_mode = sMode49;
      }

      protected void OnDeleteControls2949( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC002926 */
            pr_default.execute(15, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               A341PropostaAprovacoes_F = BC002926_A341PropostaAprovacoes_F[0];
               n341PropostaAprovacoes_F = BC002926_n341PropostaAprovacoes_F[0];
            }
            else
            {
               A341PropostaAprovacoes_F = 0;
               n341PropostaAprovacoes_F = false;
            }
            pr_default.close(15);
            /* Using cursor BC002928 */
            pr_default.execute(16, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               A342PropostaReprovacoes_F = BC002928_A342PropostaReprovacoes_F[0];
               n342PropostaReprovacoes_F = BC002928_n342PropostaReprovacoes_F[0];
            }
            else
            {
               A342PropostaReprovacoes_F = 0;
               n342PropostaReprovacoes_F = false;
            }
            pr_default.close(16);
            /* Using cursor BC002931 */
            pr_default.execute(17, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               A548ReembolsoStatusAtual_F = BC002931_A548ReembolsoStatusAtual_F[0];
               n548ReembolsoStatusAtual_F = BC002931_n548ReembolsoStatusAtual_F[0];
            }
            else
            {
               A548ReembolsoStatusAtual_F = "";
               n548ReembolsoStatusAtual_F = false;
            }
            pr_default.close(17);
            /* Using cursor BC002932 */
            pr_default.execute(18, new Object[] {n227ContratoId, A227ContratoId});
            A228ContratoNome = BC002932_A228ContratoNome[0];
            n228ContratoNome = BC002932_n228ContratoNome[0];
            pr_default.close(18);
            A343PropostaAprovacoesRestantes_F = (short)(A330PropostaQuantidadeAprovadores-A341PropostaAprovacoes_F);
            /* Using cursor BC002933 */
            pr_default.execute(19, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId});
            A505PropostaPacienteClienteRazaoSocial = BC002933_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = BC002933_n505PropostaPacienteClienteRazaoSocial[0];
            pr_default.close(19);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC002934 */
            pr_default.execute(20, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Contrato"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor BC002935 */
            pr_default.execute(21, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Reembolso"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor BC002936 */
            pr_default.execute(22, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Titulo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor BC002937 */
            pr_default.execute(23, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"NotaFiscalItem"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
            /* Using cursor BC002938 */
            pr_default.execute(24, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"PropostaContratoAssinatura"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
            /* Using cursor BC002939 */
            pr_default.execute(25, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"PropostaDocumentos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
            /* Using cursor BC002940 */
            pr_default.execute(26, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(26) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Aprovacao"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(26);
         }
      }

      protected void EndLevel2949( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2949( ) ;
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

      public void ScanKeyStart2949( )
      {
         /* Scan By routine */
         /* Using cursor BC002945 */
         pr_default.execute(27, new Object[] {n323PropostaId, A323PropostaId});
         RcdFound49 = 0;
         if ( (pr_default.getStatus(27) != 101) )
         {
            RcdFound49 = 1;
            A323PropostaId = BC002945_A323PropostaId[0];
            n323PropostaId = BC002945_n323PropostaId[0];
            A327PropostaCreatedAt = BC002945_A327PropostaCreatedAt[0];
            n327PropostaCreatedAt = BC002945_n327PropostaCreatedAt[0];
            A324PropostaTitulo = BC002945_A324PropostaTitulo[0];
            n324PropostaTitulo = BC002945_n324PropostaTitulo[0];
            A325PropostaDescricao = BC002945_A325PropostaDescricao[0];
            n325PropostaDescricao = BC002945_n325PropostaDescricao[0];
            A326PropostaValor = BC002945_A326PropostaValor[0];
            n326PropostaValor = BC002945_n326PropostaValor[0];
            A329PropostaStatus = BC002945_A329PropostaStatus[0];
            n329PropostaStatus = BC002945_n329PropostaStatus[0];
            A228ContratoNome = BC002945_A228ContratoNome[0];
            n228ContratoNome = BC002945_n228ContratoNome[0];
            A330PropostaQuantidadeAprovadores = BC002945_A330PropostaQuantidadeAprovadores[0];
            n330PropostaQuantidadeAprovadores = BC002945_n330PropostaQuantidadeAprovadores[0];
            A345PropostaReprovacoesPermitidas = BC002945_A345PropostaReprovacoesPermitidas[0];
            n345PropostaReprovacoesPermitidas = BC002945_n345PropostaReprovacoesPermitidas[0];
            A505PropostaPacienteClienteRazaoSocial = BC002945_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = BC002945_n505PropostaPacienteClienteRazaoSocial[0];
            A227ContratoId = BC002945_A227ContratoId[0];
            n227ContratoId = BC002945_n227ContratoId[0];
            A376ProcedimentosMedicosId = BC002945_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = BC002945_n376ProcedimentosMedicosId[0];
            A328PropostaCratedBy = BC002945_A328PropostaCratedBy[0];
            n328PropostaCratedBy = BC002945_n328PropostaCratedBy[0];
            A504PropostaPacienteClienteId = BC002945_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = BC002945_n504PropostaPacienteClienteId[0];
            A341PropostaAprovacoes_F = BC002945_A341PropostaAprovacoes_F[0];
            n341PropostaAprovacoes_F = BC002945_n341PropostaAprovacoes_F[0];
            A342PropostaReprovacoes_F = BC002945_A342PropostaReprovacoes_F[0];
            n342PropostaReprovacoes_F = BC002945_n342PropostaReprovacoes_F[0];
            A548ReembolsoStatusAtual_F = BC002945_A548ReembolsoStatusAtual_F[0];
            n548ReembolsoStatusAtual_F = BC002945_n548ReembolsoStatusAtual_F[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2949( )
      {
         /* Scan next routine */
         pr_default.readNext(27);
         RcdFound49 = 0;
         ScanKeyLoad2949( ) ;
      }

      protected void ScanKeyLoad2949( )
      {
         sMode49 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(27) != 101) )
         {
            RcdFound49 = 1;
            A323PropostaId = BC002945_A323PropostaId[0];
            n323PropostaId = BC002945_n323PropostaId[0];
            A327PropostaCreatedAt = BC002945_A327PropostaCreatedAt[0];
            n327PropostaCreatedAt = BC002945_n327PropostaCreatedAt[0];
            A324PropostaTitulo = BC002945_A324PropostaTitulo[0];
            n324PropostaTitulo = BC002945_n324PropostaTitulo[0];
            A325PropostaDescricao = BC002945_A325PropostaDescricao[0];
            n325PropostaDescricao = BC002945_n325PropostaDescricao[0];
            A326PropostaValor = BC002945_A326PropostaValor[0];
            n326PropostaValor = BC002945_n326PropostaValor[0];
            A329PropostaStatus = BC002945_A329PropostaStatus[0];
            n329PropostaStatus = BC002945_n329PropostaStatus[0];
            A228ContratoNome = BC002945_A228ContratoNome[0];
            n228ContratoNome = BC002945_n228ContratoNome[0];
            A330PropostaQuantidadeAprovadores = BC002945_A330PropostaQuantidadeAprovadores[0];
            n330PropostaQuantidadeAprovadores = BC002945_n330PropostaQuantidadeAprovadores[0];
            A345PropostaReprovacoesPermitidas = BC002945_A345PropostaReprovacoesPermitidas[0];
            n345PropostaReprovacoesPermitidas = BC002945_n345PropostaReprovacoesPermitidas[0];
            A505PropostaPacienteClienteRazaoSocial = BC002945_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = BC002945_n505PropostaPacienteClienteRazaoSocial[0];
            A227ContratoId = BC002945_A227ContratoId[0];
            n227ContratoId = BC002945_n227ContratoId[0];
            A376ProcedimentosMedicosId = BC002945_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = BC002945_n376ProcedimentosMedicosId[0];
            A328PropostaCratedBy = BC002945_A328PropostaCratedBy[0];
            n328PropostaCratedBy = BC002945_n328PropostaCratedBy[0];
            A504PropostaPacienteClienteId = BC002945_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = BC002945_n504PropostaPacienteClienteId[0];
            A341PropostaAprovacoes_F = BC002945_A341PropostaAprovacoes_F[0];
            n341PropostaAprovacoes_F = BC002945_n341PropostaAprovacoes_F[0];
            A342PropostaReprovacoes_F = BC002945_A342PropostaReprovacoes_F[0];
            n342PropostaReprovacoes_F = BC002945_n342PropostaReprovacoes_F[0];
            A548ReembolsoStatusAtual_F = BC002945_A548ReembolsoStatusAtual_F[0];
            n548ReembolsoStatusAtual_F = BC002945_n548ReembolsoStatusAtual_F[0];
         }
         Gx_mode = sMode49;
      }

      protected void ScanKeyEnd2949( )
      {
         pr_default.close(27);
      }

      protected void AfterConfirm2949( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2949( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2949( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2949( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2949( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2949( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2949( )
      {
      }

      protected void send_integrity_lvl_hashes2949( )
      {
      }

      protected void AddRow2949( )
      {
         VarsToRow49( bcPropostaContratoAdm) ;
      }

      protected void ReadRow2949( )
      {
         RowToVars49( bcPropostaContratoAdm, 1) ;
      }

      protected void InitializeNonKey2949( )
      {
         A327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         n327PropostaCreatedAt = false;
         A343PropostaAprovacoesRestantes_F = 0;
         A324PropostaTitulo = "";
         n324PropostaTitulo = false;
         A376ProcedimentosMedicosId = 0;
         n376ProcedimentosMedicosId = false;
         A325PropostaDescricao = "";
         n325PropostaDescricao = false;
         A326PropostaValor = 0;
         n326PropostaValor = false;
         A328PropostaCratedBy = 0;
         n328PropostaCratedBy = false;
         A329PropostaStatus = "";
         n329PropostaStatus = false;
         A227ContratoId = 0;
         n227ContratoId = false;
         A228ContratoNome = "";
         n228ContratoNome = false;
         A330PropostaQuantidadeAprovadores = 0;
         n330PropostaQuantidadeAprovadores = false;
         A345PropostaReprovacoesPermitidas = 0;
         n345PropostaReprovacoesPermitidas = false;
         A341PropostaAprovacoes_F = 0;
         n341PropostaAprovacoes_F = false;
         A342PropostaReprovacoes_F = 0;
         n342PropostaReprovacoes_F = false;
         A504PropostaPacienteClienteId = 0;
         n504PropostaPacienteClienteId = false;
         A505PropostaPacienteClienteRazaoSocial = "";
         n505PropostaPacienteClienteRazaoSocial = false;
         A548ReembolsoStatusAtual_F = "";
         n548ReembolsoStatusAtual_F = false;
         Z327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         Z324PropostaTitulo = "";
         Z325PropostaDescricao = "";
         Z326PropostaValor = 0;
         Z329PropostaStatus = "";
         Z330PropostaQuantidadeAprovadores = 0;
         Z345PropostaReprovacoesPermitidas = 0;
         Z227ContratoId = 0;
         Z376ProcedimentosMedicosId = 0;
         Z328PropostaCratedBy = 0;
         Z504PropostaPacienteClienteId = 0;
      }

      protected void InitAll2949( )
      {
         A323PropostaId = 0;
         n323PropostaId = false;
         InitializeNonKey2949( ) ;
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

      public void VarsToRow49( SdtPropostaContratoAdm obj49 )
      {
         obj49.gxTpr_Mode = Gx_mode;
         obj49.gxTpr_Propostacreatedat = A327PropostaCreatedAt;
         obj49.gxTpr_Propostaaprovacoesrestantes_f = A343PropostaAprovacoesRestantes_F;
         obj49.gxTpr_Propostatitulo = A324PropostaTitulo;
         obj49.gxTpr_Procedimentosmedicosid = A376ProcedimentosMedicosId;
         obj49.gxTpr_Propostadescricao = A325PropostaDescricao;
         obj49.gxTpr_Propostavalor = A326PropostaValor;
         obj49.gxTpr_Propostacratedby = A328PropostaCratedBy;
         obj49.gxTpr_Propostastatus = A329PropostaStatus;
         obj49.gxTpr_Contratoid = A227ContratoId;
         obj49.gxTpr_Contratonome = A228ContratoNome;
         obj49.gxTpr_Propostaquantidadeaprovadores = A330PropostaQuantidadeAprovadores;
         obj49.gxTpr_Propostareprovacoespermitidas = A345PropostaReprovacoesPermitidas;
         obj49.gxTpr_Propostaaprovacoes_f = A341PropostaAprovacoes_F;
         obj49.gxTpr_Propostareprovacoes_f = A342PropostaReprovacoes_F;
         obj49.gxTpr_Propostapacienteclienteid = A504PropostaPacienteClienteId;
         obj49.gxTpr_Propostapacienteclienterazaosocial = A505PropostaPacienteClienteRazaoSocial;
         obj49.gxTpr_Reembolsostatusatual_f = A548ReembolsoStatusAtual_F;
         obj49.gxTpr_Propostaid = A323PropostaId;
         obj49.gxTpr_Propostaid_Z = Z323PropostaId;
         obj49.gxTpr_Propostatitulo_Z = Z324PropostaTitulo;
         obj49.gxTpr_Procedimentosmedicosid_Z = Z376ProcedimentosMedicosId;
         obj49.gxTpr_Propostadescricao_Z = Z325PropostaDescricao;
         obj49.gxTpr_Propostavalor_Z = Z326PropostaValor;
         obj49.gxTpr_Propostacreatedat_Z = Z327PropostaCreatedAt;
         obj49.gxTpr_Propostacratedby_Z = Z328PropostaCratedBy;
         obj49.gxTpr_Propostastatus_Z = Z329PropostaStatus;
         obj49.gxTpr_Contratoid_Z = Z227ContratoId;
         obj49.gxTpr_Contratonome_Z = Z228ContratoNome;
         obj49.gxTpr_Propostaquantidadeaprovadores_Z = Z330PropostaQuantidadeAprovadores;
         obj49.gxTpr_Propostareprovacoespermitidas_Z = Z345PropostaReprovacoesPermitidas;
         obj49.gxTpr_Propostaaprovacoes_f_Z = Z341PropostaAprovacoes_F;
         obj49.gxTpr_Propostareprovacoes_f_Z = Z342PropostaReprovacoes_F;
         obj49.gxTpr_Propostaaprovacoesrestantes_f_Z = Z343PropostaAprovacoesRestantes_F;
         obj49.gxTpr_Propostapacienteclienteid_Z = Z504PropostaPacienteClienteId;
         obj49.gxTpr_Propostapacienteclienterazaosocial_Z = Z505PropostaPacienteClienteRazaoSocial;
         obj49.gxTpr_Reembolsostatusatual_f_Z = Z548ReembolsoStatusAtual_F;
         obj49.gxTpr_Propostaid_N = (short)(Convert.ToInt16(n323PropostaId));
         obj49.gxTpr_Propostatitulo_N = (short)(Convert.ToInt16(n324PropostaTitulo));
         obj49.gxTpr_Procedimentosmedicosid_N = (short)(Convert.ToInt16(n376ProcedimentosMedicosId));
         obj49.gxTpr_Propostadescricao_N = (short)(Convert.ToInt16(n325PropostaDescricao));
         obj49.gxTpr_Propostavalor_N = (short)(Convert.ToInt16(n326PropostaValor));
         obj49.gxTpr_Propostacreatedat_N = (short)(Convert.ToInt16(n327PropostaCreatedAt));
         obj49.gxTpr_Propostacratedby_N = (short)(Convert.ToInt16(n328PropostaCratedBy));
         obj49.gxTpr_Propostastatus_N = (short)(Convert.ToInt16(n329PropostaStatus));
         obj49.gxTpr_Contratoid_N = (short)(Convert.ToInt16(n227ContratoId));
         obj49.gxTpr_Contratonome_N = (short)(Convert.ToInt16(n228ContratoNome));
         obj49.gxTpr_Propostaquantidadeaprovadores_N = (short)(Convert.ToInt16(n330PropostaQuantidadeAprovadores));
         obj49.gxTpr_Propostareprovacoespermitidas_N = (short)(Convert.ToInt16(n345PropostaReprovacoesPermitidas));
         obj49.gxTpr_Propostaaprovacoes_f_N = (short)(Convert.ToInt16(n341PropostaAprovacoes_F));
         obj49.gxTpr_Propostareprovacoes_f_N = (short)(Convert.ToInt16(n342PropostaReprovacoes_F));
         obj49.gxTpr_Propostapacienteclienteid_N = (short)(Convert.ToInt16(n504PropostaPacienteClienteId));
         obj49.gxTpr_Propostapacienteclienterazaosocial_N = (short)(Convert.ToInt16(n505PropostaPacienteClienteRazaoSocial));
         obj49.gxTpr_Reembolsostatusatual_f_N = (short)(Convert.ToInt16(n548ReembolsoStatusAtual_F));
         obj49.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow49( SdtPropostaContratoAdm obj49 )
      {
         obj49.gxTpr_Propostaid = A323PropostaId;
         return  ;
      }

      public void RowToVars49( SdtPropostaContratoAdm obj49 ,
                               int forceLoad )
      {
         Gx_mode = obj49.gxTpr_Mode;
         A327PropostaCreatedAt = obj49.gxTpr_Propostacreatedat;
         n327PropostaCreatedAt = false;
         A343PropostaAprovacoesRestantes_F = obj49.gxTpr_Propostaaprovacoesrestantes_f;
         A324PropostaTitulo = obj49.gxTpr_Propostatitulo;
         n324PropostaTitulo = false;
         A376ProcedimentosMedicosId = obj49.gxTpr_Procedimentosmedicosid;
         n376ProcedimentosMedicosId = false;
         A325PropostaDescricao = obj49.gxTpr_Propostadescricao;
         n325PropostaDescricao = false;
         A326PropostaValor = obj49.gxTpr_Propostavalor;
         n326PropostaValor = false;
         A328PropostaCratedBy = obj49.gxTpr_Propostacratedby;
         n328PropostaCratedBy = false;
         A329PropostaStatus = obj49.gxTpr_Propostastatus;
         n329PropostaStatus = false;
         A227ContratoId = obj49.gxTpr_Contratoid;
         n227ContratoId = false;
         A228ContratoNome = obj49.gxTpr_Contratonome;
         n228ContratoNome = false;
         A330PropostaQuantidadeAprovadores = obj49.gxTpr_Propostaquantidadeaprovadores;
         n330PropostaQuantidadeAprovadores = false;
         A345PropostaReprovacoesPermitidas = obj49.gxTpr_Propostareprovacoespermitidas;
         n345PropostaReprovacoesPermitidas = false;
         A341PropostaAprovacoes_F = obj49.gxTpr_Propostaaprovacoes_f;
         n341PropostaAprovacoes_F = false;
         A342PropostaReprovacoes_F = obj49.gxTpr_Propostareprovacoes_f;
         n342PropostaReprovacoes_F = false;
         A504PropostaPacienteClienteId = obj49.gxTpr_Propostapacienteclienteid;
         n504PropostaPacienteClienteId = false;
         A505PropostaPacienteClienteRazaoSocial = obj49.gxTpr_Propostapacienteclienterazaosocial;
         n505PropostaPacienteClienteRazaoSocial = false;
         A548ReembolsoStatusAtual_F = obj49.gxTpr_Reembolsostatusatual_f;
         n548ReembolsoStatusAtual_F = false;
         A323PropostaId = obj49.gxTpr_Propostaid;
         n323PropostaId = false;
         Z323PropostaId = obj49.gxTpr_Propostaid_Z;
         Z324PropostaTitulo = obj49.gxTpr_Propostatitulo_Z;
         Z376ProcedimentosMedicosId = obj49.gxTpr_Procedimentosmedicosid_Z;
         Z325PropostaDescricao = obj49.gxTpr_Propostadescricao_Z;
         Z326PropostaValor = obj49.gxTpr_Propostavalor_Z;
         Z327PropostaCreatedAt = obj49.gxTpr_Propostacreatedat_Z;
         Z328PropostaCratedBy = obj49.gxTpr_Propostacratedby_Z;
         Z329PropostaStatus = obj49.gxTpr_Propostastatus_Z;
         Z227ContratoId = obj49.gxTpr_Contratoid_Z;
         Z228ContratoNome = obj49.gxTpr_Contratonome_Z;
         Z330PropostaQuantidadeAprovadores = obj49.gxTpr_Propostaquantidadeaprovadores_Z;
         Z345PropostaReprovacoesPermitidas = obj49.gxTpr_Propostareprovacoespermitidas_Z;
         Z341PropostaAprovacoes_F = obj49.gxTpr_Propostaaprovacoes_f_Z;
         Z342PropostaReprovacoes_F = obj49.gxTpr_Propostareprovacoes_f_Z;
         Z343PropostaAprovacoesRestantes_F = obj49.gxTpr_Propostaaprovacoesrestantes_f_Z;
         Z504PropostaPacienteClienteId = obj49.gxTpr_Propostapacienteclienteid_Z;
         Z505PropostaPacienteClienteRazaoSocial = obj49.gxTpr_Propostapacienteclienterazaosocial_Z;
         Z548ReembolsoStatusAtual_F = obj49.gxTpr_Reembolsostatusatual_f_Z;
         n323PropostaId = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostaid_N));
         n324PropostaTitulo = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostatitulo_N));
         n376ProcedimentosMedicosId = (bool)(Convert.ToBoolean(obj49.gxTpr_Procedimentosmedicosid_N));
         n325PropostaDescricao = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostadescricao_N));
         n326PropostaValor = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostavalor_N));
         n327PropostaCreatedAt = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostacreatedat_N));
         n328PropostaCratedBy = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostacratedby_N));
         n329PropostaStatus = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostastatus_N));
         n227ContratoId = (bool)(Convert.ToBoolean(obj49.gxTpr_Contratoid_N));
         n228ContratoNome = (bool)(Convert.ToBoolean(obj49.gxTpr_Contratonome_N));
         n330PropostaQuantidadeAprovadores = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostaquantidadeaprovadores_N));
         n345PropostaReprovacoesPermitidas = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostareprovacoespermitidas_N));
         n341PropostaAprovacoes_F = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostaaprovacoes_f_N));
         n342PropostaReprovacoes_F = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostareprovacoes_f_N));
         n504PropostaPacienteClienteId = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostapacienteclienteid_N));
         n505PropostaPacienteClienteRazaoSocial = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostapacienteclienterazaosocial_N));
         n548ReembolsoStatusAtual_F = (bool)(Convert.ToBoolean(obj49.gxTpr_Reembolsostatusatual_f_N));
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
         InitializeNonKey2949( ) ;
         ScanKeyStart2949( ) ;
         if ( RcdFound49 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z323PropostaId = A323PropostaId;
         }
         ZM2949( -10) ;
         OnLoadActions2949( ) ;
         AddRow2949( ) ;
         ScanKeyEnd2949( ) ;
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
         RowToVars49( bcPropostaContratoAdm, 0) ;
         ScanKeyStart2949( ) ;
         if ( RcdFound49 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z323PropostaId = A323PropostaId;
         }
         ZM2949( -10) ;
         OnLoadActions2949( ) ;
         AddRow2949( ) ;
         ScanKeyEnd2949( ) ;
         if ( RcdFound49 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2949( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2949( ) ;
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
                  Update2949( ) ;
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
                        Insert2949( ) ;
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
                        Insert2949( ) ;
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
         RowToVars49( bcPropostaContratoAdm, 1) ;
         SaveImpl( ) ;
         VarsToRow49( bcPropostaContratoAdm) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars49( bcPropostaContratoAdm, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2949( ) ;
         AfterTrn( ) ;
         VarsToRow49( bcPropostaContratoAdm) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow49( bcPropostaContratoAdm) ;
         }
         else
         {
            SdtPropostaContratoAdm auxBC = new SdtPropostaContratoAdm(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A323PropostaId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcPropostaContratoAdm);
               auxBC.Save();
               bcPropostaContratoAdm.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars49( bcPropostaContratoAdm, 1) ;
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
         RowToVars49( bcPropostaContratoAdm, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2949( ) ;
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
               VarsToRow49( bcPropostaContratoAdm) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow49( bcPropostaContratoAdm) ;
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
         RowToVars49( bcPropostaContratoAdm, 0) ;
         GetKey2949( ) ;
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
         context.RollbackDataStores("propostacontratoadm_bc",pr_default);
         VarsToRow49( bcPropostaContratoAdm) ;
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
         Gx_mode = bcPropostaContratoAdm.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcPropostaContratoAdm.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcPropostaContratoAdm )
         {
            bcPropostaContratoAdm = (SdtPropostaContratoAdm)(sdt);
            if ( StringUtil.StrCmp(bcPropostaContratoAdm.gxTpr_Mode, "") == 0 )
            {
               bcPropostaContratoAdm.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow49( bcPropostaContratoAdm) ;
            }
            else
            {
               RowToVars49( bcPropostaContratoAdm, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcPropostaContratoAdm.gxTpr_Mode, "") == 0 )
            {
               bcPropostaContratoAdm.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars49( bcPropostaContratoAdm, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtPropostaContratoAdm PropostaContratoAdm_BC
      {
         get {
            return bcPropostaContratoAdm ;
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
         pr_default.close(18);
         pr_default.close(19);
         pr_default.close(15);
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
         AV30Pgmname = "";
         AV13TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         A327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         Z324PropostaTitulo = "";
         A324PropostaTitulo = "";
         Z325PropostaDescricao = "";
         A325PropostaDescricao = "";
         Z329PropostaStatus = "";
         A329PropostaStatus = "";
         Z548ReembolsoStatusAtual_F = "";
         A548ReembolsoStatusAtual_F = "";
         Z228ContratoNome = "";
         A228ContratoNome = "";
         Z505PropostaPacienteClienteRazaoSocial = "";
         A505PropostaPacienteClienteRazaoSocial = "";
         BC002919_A323PropostaId = new int[1] ;
         BC002919_n323PropostaId = new bool[] {false} ;
         BC002919_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002919_n327PropostaCreatedAt = new bool[] {false} ;
         BC002919_A324PropostaTitulo = new string[] {""} ;
         BC002919_n324PropostaTitulo = new bool[] {false} ;
         BC002919_A325PropostaDescricao = new string[] {""} ;
         BC002919_n325PropostaDescricao = new bool[] {false} ;
         BC002919_A326PropostaValor = new decimal[1] ;
         BC002919_n326PropostaValor = new bool[] {false} ;
         BC002919_A329PropostaStatus = new string[] {""} ;
         BC002919_n329PropostaStatus = new bool[] {false} ;
         BC002919_A228ContratoNome = new string[] {""} ;
         BC002919_n228ContratoNome = new bool[] {false} ;
         BC002919_A330PropostaQuantidadeAprovadores = new short[1] ;
         BC002919_n330PropostaQuantidadeAprovadores = new bool[] {false} ;
         BC002919_A345PropostaReprovacoesPermitidas = new short[1] ;
         BC002919_n345PropostaReprovacoesPermitidas = new bool[] {false} ;
         BC002919_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         BC002919_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         BC002919_A227ContratoId = new int[1] ;
         BC002919_n227ContratoId = new bool[] {false} ;
         BC002919_A376ProcedimentosMedicosId = new int[1] ;
         BC002919_n376ProcedimentosMedicosId = new bool[] {false} ;
         BC002919_A328PropostaCratedBy = new short[1] ;
         BC002919_n328PropostaCratedBy = new bool[] {false} ;
         BC002919_A504PropostaPacienteClienteId = new int[1] ;
         BC002919_n504PropostaPacienteClienteId = new bool[] {false} ;
         BC002919_A341PropostaAprovacoes_F = new short[1] ;
         BC002919_n341PropostaAprovacoes_F = new bool[] {false} ;
         BC002919_A342PropostaReprovacoes_F = new short[1] ;
         BC002919_n342PropostaReprovacoes_F = new bool[] {false} ;
         BC002919_A548ReembolsoStatusAtual_F = new string[] {""} ;
         BC002919_n548ReembolsoStatusAtual_F = new bool[] {false} ;
         BC00299_A341PropostaAprovacoes_F = new short[1] ;
         BC00299_n341PropostaAprovacoes_F = new bool[] {false} ;
         BC002911_A342PropostaReprovacoes_F = new short[1] ;
         BC002911_n342PropostaReprovacoes_F = new bool[] {false} ;
         BC002914_A548ReembolsoStatusAtual_F = new string[] {""} ;
         BC002914_n548ReembolsoStatusAtual_F = new bool[] {false} ;
         BC00295_A376ProcedimentosMedicosId = new int[1] ;
         BC00295_n376ProcedimentosMedicosId = new bool[] {false} ;
         BC00296_A328PropostaCratedBy = new short[1] ;
         BC00296_n328PropostaCratedBy = new bool[] {false} ;
         BC00294_A228ContratoNome = new string[] {""} ;
         BC00294_n228ContratoNome = new bool[] {false} ;
         BC00297_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         BC00297_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         BC002920_A323PropostaId = new int[1] ;
         BC002920_n323PropostaId = new bool[] {false} ;
         BC00293_A323PropostaId = new int[1] ;
         BC00293_n323PropostaId = new bool[] {false} ;
         BC00293_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00293_n327PropostaCreatedAt = new bool[] {false} ;
         BC00293_A324PropostaTitulo = new string[] {""} ;
         BC00293_n324PropostaTitulo = new bool[] {false} ;
         BC00293_A325PropostaDescricao = new string[] {""} ;
         BC00293_n325PropostaDescricao = new bool[] {false} ;
         BC00293_A326PropostaValor = new decimal[1] ;
         BC00293_n326PropostaValor = new bool[] {false} ;
         BC00293_A329PropostaStatus = new string[] {""} ;
         BC00293_n329PropostaStatus = new bool[] {false} ;
         BC00293_A330PropostaQuantidadeAprovadores = new short[1] ;
         BC00293_n330PropostaQuantidadeAprovadores = new bool[] {false} ;
         BC00293_A345PropostaReprovacoesPermitidas = new short[1] ;
         BC00293_n345PropostaReprovacoesPermitidas = new bool[] {false} ;
         BC00293_A227ContratoId = new int[1] ;
         BC00293_n227ContratoId = new bool[] {false} ;
         BC00293_A376ProcedimentosMedicosId = new int[1] ;
         BC00293_n376ProcedimentosMedicosId = new bool[] {false} ;
         BC00293_A328PropostaCratedBy = new short[1] ;
         BC00293_n328PropostaCratedBy = new bool[] {false} ;
         BC00293_A504PropostaPacienteClienteId = new int[1] ;
         BC00293_n504PropostaPacienteClienteId = new bool[] {false} ;
         sMode49 = "";
         BC00292_A323PropostaId = new int[1] ;
         BC00292_n323PropostaId = new bool[] {false} ;
         BC00292_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00292_n327PropostaCreatedAt = new bool[] {false} ;
         BC00292_A324PropostaTitulo = new string[] {""} ;
         BC00292_n324PropostaTitulo = new bool[] {false} ;
         BC00292_A325PropostaDescricao = new string[] {""} ;
         BC00292_n325PropostaDescricao = new bool[] {false} ;
         BC00292_A326PropostaValor = new decimal[1] ;
         BC00292_n326PropostaValor = new bool[] {false} ;
         BC00292_A329PropostaStatus = new string[] {""} ;
         BC00292_n329PropostaStatus = new bool[] {false} ;
         BC00292_A330PropostaQuantidadeAprovadores = new short[1] ;
         BC00292_n330PropostaQuantidadeAprovadores = new bool[] {false} ;
         BC00292_A345PropostaReprovacoesPermitidas = new short[1] ;
         BC00292_n345PropostaReprovacoesPermitidas = new bool[] {false} ;
         BC00292_A227ContratoId = new int[1] ;
         BC00292_n227ContratoId = new bool[] {false} ;
         BC00292_A376ProcedimentosMedicosId = new int[1] ;
         BC00292_n376ProcedimentosMedicosId = new bool[] {false} ;
         BC00292_A328PropostaCratedBy = new short[1] ;
         BC00292_n328PropostaCratedBy = new bool[] {false} ;
         BC00292_A504PropostaPacienteClienteId = new int[1] ;
         BC00292_n504PropostaPacienteClienteId = new bool[] {false} ;
         BC002922_A323PropostaId = new int[1] ;
         BC002922_n323PropostaId = new bool[] {false} ;
         BC002926_A341PropostaAprovacoes_F = new short[1] ;
         BC002926_n341PropostaAprovacoes_F = new bool[] {false} ;
         BC002928_A342PropostaReprovacoes_F = new short[1] ;
         BC002928_n342PropostaReprovacoes_F = new bool[] {false} ;
         BC002931_A548ReembolsoStatusAtual_F = new string[] {""} ;
         BC002931_n548ReembolsoStatusAtual_F = new bool[] {false} ;
         BC002932_A228ContratoNome = new string[] {""} ;
         BC002932_n228ContratoNome = new bool[] {false} ;
         BC002933_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         BC002933_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         BC002934_A227ContratoId = new int[1] ;
         BC002934_n227ContratoId = new bool[] {false} ;
         BC002935_A518ReembolsoId = new int[1] ;
         BC002935_n518ReembolsoId = new bool[] {false} ;
         BC002936_A261TituloId = new int[1] ;
         BC002937_A830NotaFiscalItemId = new Guid[] {Guid.Empty} ;
         BC002938_A572PropostaContratoAssinaturaId = new int[1] ;
         BC002939_A414PropostaDocumentosId = new int[1] ;
         BC002940_A336AprovacaoId = new int[1] ;
         BC002945_A323PropostaId = new int[1] ;
         BC002945_n323PropostaId = new bool[] {false} ;
         BC002945_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002945_n327PropostaCreatedAt = new bool[] {false} ;
         BC002945_A324PropostaTitulo = new string[] {""} ;
         BC002945_n324PropostaTitulo = new bool[] {false} ;
         BC002945_A325PropostaDescricao = new string[] {""} ;
         BC002945_n325PropostaDescricao = new bool[] {false} ;
         BC002945_A326PropostaValor = new decimal[1] ;
         BC002945_n326PropostaValor = new bool[] {false} ;
         BC002945_A329PropostaStatus = new string[] {""} ;
         BC002945_n329PropostaStatus = new bool[] {false} ;
         BC002945_A228ContratoNome = new string[] {""} ;
         BC002945_n228ContratoNome = new bool[] {false} ;
         BC002945_A330PropostaQuantidadeAprovadores = new short[1] ;
         BC002945_n330PropostaQuantidadeAprovadores = new bool[] {false} ;
         BC002945_A345PropostaReprovacoesPermitidas = new short[1] ;
         BC002945_n345PropostaReprovacoesPermitidas = new bool[] {false} ;
         BC002945_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         BC002945_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         BC002945_A227ContratoId = new int[1] ;
         BC002945_n227ContratoId = new bool[] {false} ;
         BC002945_A376ProcedimentosMedicosId = new int[1] ;
         BC002945_n376ProcedimentosMedicosId = new bool[] {false} ;
         BC002945_A328PropostaCratedBy = new short[1] ;
         BC002945_n328PropostaCratedBy = new bool[] {false} ;
         BC002945_A504PropostaPacienteClienteId = new int[1] ;
         BC002945_n504PropostaPacienteClienteId = new bool[] {false} ;
         BC002945_A341PropostaAprovacoes_F = new short[1] ;
         BC002945_n341PropostaAprovacoes_F = new bool[] {false} ;
         BC002945_A342PropostaReprovacoes_F = new short[1] ;
         BC002945_n342PropostaReprovacoes_F = new bool[] {false} ;
         BC002945_A548ReembolsoStatusAtual_F = new string[] {""} ;
         BC002945_n548ReembolsoStatusAtual_F = new bool[] {false} ;
         i327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.propostacontratoadm_bc__default(),
            new Object[][] {
                new Object[] {
               BC00292_A323PropostaId, BC00292_A327PropostaCreatedAt, BC00292_n327PropostaCreatedAt, BC00292_A324PropostaTitulo, BC00292_n324PropostaTitulo, BC00292_A325PropostaDescricao, BC00292_n325PropostaDescricao, BC00292_A326PropostaValor, BC00292_n326PropostaValor, BC00292_A329PropostaStatus,
               BC00292_n329PropostaStatus, BC00292_A330PropostaQuantidadeAprovadores, BC00292_n330PropostaQuantidadeAprovadores, BC00292_A345PropostaReprovacoesPermitidas, BC00292_n345PropostaReprovacoesPermitidas, BC00292_A227ContratoId, BC00292_n227ContratoId, BC00292_A376ProcedimentosMedicosId, BC00292_n376ProcedimentosMedicosId, BC00292_A328PropostaCratedBy,
               BC00292_n328PropostaCratedBy, BC00292_A504PropostaPacienteClienteId, BC00292_n504PropostaPacienteClienteId
               }
               , new Object[] {
               BC00293_A323PropostaId, BC00293_A327PropostaCreatedAt, BC00293_n327PropostaCreatedAt, BC00293_A324PropostaTitulo, BC00293_n324PropostaTitulo, BC00293_A325PropostaDescricao, BC00293_n325PropostaDescricao, BC00293_A326PropostaValor, BC00293_n326PropostaValor, BC00293_A329PropostaStatus,
               BC00293_n329PropostaStatus, BC00293_A330PropostaQuantidadeAprovadores, BC00293_n330PropostaQuantidadeAprovadores, BC00293_A345PropostaReprovacoesPermitidas, BC00293_n345PropostaReprovacoesPermitidas, BC00293_A227ContratoId, BC00293_n227ContratoId, BC00293_A376ProcedimentosMedicosId, BC00293_n376ProcedimentosMedicosId, BC00293_A328PropostaCratedBy,
               BC00293_n328PropostaCratedBy, BC00293_A504PropostaPacienteClienteId, BC00293_n504PropostaPacienteClienteId
               }
               , new Object[] {
               BC00294_A228ContratoNome, BC00294_n228ContratoNome
               }
               , new Object[] {
               BC00295_A376ProcedimentosMedicosId
               }
               , new Object[] {
               BC00296_A328PropostaCratedBy
               }
               , new Object[] {
               BC00297_A505PropostaPacienteClienteRazaoSocial, BC00297_n505PropostaPacienteClienteRazaoSocial
               }
               , new Object[] {
               BC00299_A341PropostaAprovacoes_F, BC00299_n341PropostaAprovacoes_F
               }
               , new Object[] {
               BC002911_A342PropostaReprovacoes_F, BC002911_n342PropostaReprovacoes_F
               }
               , new Object[] {
               BC002914_A548ReembolsoStatusAtual_F, BC002914_n548ReembolsoStatusAtual_F
               }
               , new Object[] {
               BC002919_A323PropostaId, BC002919_A327PropostaCreatedAt, BC002919_n327PropostaCreatedAt, BC002919_A324PropostaTitulo, BC002919_n324PropostaTitulo, BC002919_A325PropostaDescricao, BC002919_n325PropostaDescricao, BC002919_A326PropostaValor, BC002919_n326PropostaValor, BC002919_A329PropostaStatus,
               BC002919_n329PropostaStatus, BC002919_A228ContratoNome, BC002919_n228ContratoNome, BC002919_A330PropostaQuantidadeAprovadores, BC002919_n330PropostaQuantidadeAprovadores, BC002919_A345PropostaReprovacoesPermitidas, BC002919_n345PropostaReprovacoesPermitidas, BC002919_A505PropostaPacienteClienteRazaoSocial, BC002919_n505PropostaPacienteClienteRazaoSocial, BC002919_A227ContratoId,
               BC002919_n227ContratoId, BC002919_A376ProcedimentosMedicosId, BC002919_n376ProcedimentosMedicosId, BC002919_A328PropostaCratedBy, BC002919_n328PropostaCratedBy, BC002919_A504PropostaPacienteClienteId, BC002919_n504PropostaPacienteClienteId, BC002919_A341PropostaAprovacoes_F, BC002919_n341PropostaAprovacoes_F, BC002919_A342PropostaReprovacoes_F,
               BC002919_n342PropostaReprovacoes_F, BC002919_A548ReembolsoStatusAtual_F, BC002919_n548ReembolsoStatusAtual_F
               }
               , new Object[] {
               BC002920_A323PropostaId
               }
               , new Object[] {
               }
               , new Object[] {
               BC002922_A323PropostaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002926_A341PropostaAprovacoes_F, BC002926_n341PropostaAprovacoes_F
               }
               , new Object[] {
               BC002928_A342PropostaReprovacoes_F, BC002928_n342PropostaReprovacoes_F
               }
               , new Object[] {
               BC002931_A548ReembolsoStatusAtual_F, BC002931_n548ReembolsoStatusAtual_F
               }
               , new Object[] {
               BC002932_A228ContratoNome, BC002932_n228ContratoNome
               }
               , new Object[] {
               BC002933_A505PropostaPacienteClienteRazaoSocial, BC002933_n505PropostaPacienteClienteRazaoSocial
               }
               , new Object[] {
               BC002934_A227ContratoId
               }
               , new Object[] {
               BC002935_A518ReembolsoId
               }
               , new Object[] {
               BC002936_A261TituloId
               }
               , new Object[] {
               BC002937_A830NotaFiscalItemId
               }
               , new Object[] {
               BC002938_A572PropostaContratoAssinaturaId
               }
               , new Object[] {
               BC002939_A414PropostaDocumentosId
               }
               , new Object[] {
               BC002940_A336AprovacaoId
               }
               , new Object[] {
               BC002945_A323PropostaId, BC002945_A327PropostaCreatedAt, BC002945_n327PropostaCreatedAt, BC002945_A324PropostaTitulo, BC002945_n324PropostaTitulo, BC002945_A325PropostaDescricao, BC002945_n325PropostaDescricao, BC002945_A326PropostaValor, BC002945_n326PropostaValor, BC002945_A329PropostaStatus,
               BC002945_n329PropostaStatus, BC002945_A228ContratoNome, BC002945_n228ContratoNome, BC002945_A330PropostaQuantidadeAprovadores, BC002945_n330PropostaQuantidadeAprovadores, BC002945_A345PropostaReprovacoesPermitidas, BC002945_n345PropostaReprovacoesPermitidas, BC002945_A505PropostaPacienteClienteRazaoSocial, BC002945_n505PropostaPacienteClienteRazaoSocial, BC002945_A227ContratoId,
               BC002945_n227ContratoId, BC002945_A376ProcedimentosMedicosId, BC002945_n376ProcedimentosMedicosId, BC002945_A328PropostaCratedBy, BC002945_n328PropostaCratedBy, BC002945_A504PropostaPacienteClienteId, BC002945_n504PropostaPacienteClienteId, BC002945_A341PropostaAprovacoes_F, BC002945_n341PropostaAprovacoes_F, BC002945_A342PropostaReprovacoes_F,
               BC002945_n342PropostaReprovacoes_F, BC002945_A548ReembolsoStatusAtual_F, BC002945_n548ReembolsoStatusAtual_F
               }
            }
         );
         AV30Pgmname = "PropostaContratoAdm_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12292 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short AV11Insert_PropostaCratedBy ;
      private short Z330PropostaQuantidadeAprovadores ;
      private short A330PropostaQuantidadeAprovadores ;
      private short Z345PropostaReprovacoesPermitidas ;
      private short A345PropostaReprovacoesPermitidas ;
      private short Z328PropostaCratedBy ;
      private short A328PropostaCratedBy ;
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
      private int AV31GXV1 ;
      private int AV24Insert_ProcedimentosMedicosId ;
      private int AV12Insert_ContratoId ;
      private int AV29Insert_PropostaPacienteClienteId ;
      private int Z227ContratoId ;
      private int A227ContratoId ;
      private int Z376ProcedimentosMedicosId ;
      private int A376ProcedimentosMedicosId ;
      private int Z504PropostaPacienteClienteId ;
      private int A504PropostaPacienteClienteId ;
      private decimal Z326PropostaValor ;
      private decimal A326PropostaValor ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV30Pgmname ;
      private string sMode49 ;
      private DateTime Z327PropostaCreatedAt ;
      private DateTime A327PropostaCreatedAt ;
      private DateTime i327PropostaCreatedAt ;
      private bool returnInSub ;
      private bool n327PropostaCreatedAt ;
      private bool n323PropostaId ;
      private bool n324PropostaTitulo ;
      private bool n325PropostaDescricao ;
      private bool n326PropostaValor ;
      private bool n329PropostaStatus ;
      private bool n228ContratoNome ;
      private bool n330PropostaQuantidadeAprovadores ;
      private bool n345PropostaReprovacoesPermitidas ;
      private bool n505PropostaPacienteClienteRazaoSocial ;
      private bool n227ContratoId ;
      private bool n376ProcedimentosMedicosId ;
      private bool n328PropostaCratedBy ;
      private bool n504PropostaPacienteClienteId ;
      private bool n341PropostaAprovacoes_F ;
      private bool n342PropostaReprovacoes_F ;
      private bool n548ReembolsoStatusAtual_F ;
      private bool Gx_longc ;
      private string Z324PropostaTitulo ;
      private string A324PropostaTitulo ;
      private string Z325PropostaDescricao ;
      private string A325PropostaDescricao ;
      private string Z329PropostaStatus ;
      private string A329PropostaStatus ;
      private string Z548ReembolsoStatusAtual_F ;
      private string A548ReembolsoStatusAtual_F ;
      private string Z228ContratoNome ;
      private string A228ContratoNome ;
      private string Z505PropostaPacienteClienteRazaoSocial ;
      private string A505PropostaPacienteClienteRazaoSocial ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] BC002919_A323PropostaId ;
      private bool[] BC002919_n323PropostaId ;
      private DateTime[] BC002919_A327PropostaCreatedAt ;
      private bool[] BC002919_n327PropostaCreatedAt ;
      private string[] BC002919_A324PropostaTitulo ;
      private bool[] BC002919_n324PropostaTitulo ;
      private string[] BC002919_A325PropostaDescricao ;
      private bool[] BC002919_n325PropostaDescricao ;
      private decimal[] BC002919_A326PropostaValor ;
      private bool[] BC002919_n326PropostaValor ;
      private string[] BC002919_A329PropostaStatus ;
      private bool[] BC002919_n329PropostaStatus ;
      private string[] BC002919_A228ContratoNome ;
      private bool[] BC002919_n228ContratoNome ;
      private short[] BC002919_A330PropostaQuantidadeAprovadores ;
      private bool[] BC002919_n330PropostaQuantidadeAprovadores ;
      private short[] BC002919_A345PropostaReprovacoesPermitidas ;
      private bool[] BC002919_n345PropostaReprovacoesPermitidas ;
      private string[] BC002919_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] BC002919_n505PropostaPacienteClienteRazaoSocial ;
      private int[] BC002919_A227ContratoId ;
      private bool[] BC002919_n227ContratoId ;
      private int[] BC002919_A376ProcedimentosMedicosId ;
      private bool[] BC002919_n376ProcedimentosMedicosId ;
      private short[] BC002919_A328PropostaCratedBy ;
      private bool[] BC002919_n328PropostaCratedBy ;
      private int[] BC002919_A504PropostaPacienteClienteId ;
      private bool[] BC002919_n504PropostaPacienteClienteId ;
      private short[] BC002919_A341PropostaAprovacoes_F ;
      private bool[] BC002919_n341PropostaAprovacoes_F ;
      private short[] BC002919_A342PropostaReprovacoes_F ;
      private bool[] BC002919_n342PropostaReprovacoes_F ;
      private string[] BC002919_A548ReembolsoStatusAtual_F ;
      private bool[] BC002919_n548ReembolsoStatusAtual_F ;
      private short[] BC00299_A341PropostaAprovacoes_F ;
      private bool[] BC00299_n341PropostaAprovacoes_F ;
      private short[] BC002911_A342PropostaReprovacoes_F ;
      private bool[] BC002911_n342PropostaReprovacoes_F ;
      private string[] BC002914_A548ReembolsoStatusAtual_F ;
      private bool[] BC002914_n548ReembolsoStatusAtual_F ;
      private int[] BC00295_A376ProcedimentosMedicosId ;
      private bool[] BC00295_n376ProcedimentosMedicosId ;
      private short[] BC00296_A328PropostaCratedBy ;
      private bool[] BC00296_n328PropostaCratedBy ;
      private string[] BC00294_A228ContratoNome ;
      private bool[] BC00294_n228ContratoNome ;
      private string[] BC00297_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] BC00297_n505PropostaPacienteClienteRazaoSocial ;
      private int[] BC002920_A323PropostaId ;
      private bool[] BC002920_n323PropostaId ;
      private int[] BC00293_A323PropostaId ;
      private bool[] BC00293_n323PropostaId ;
      private DateTime[] BC00293_A327PropostaCreatedAt ;
      private bool[] BC00293_n327PropostaCreatedAt ;
      private string[] BC00293_A324PropostaTitulo ;
      private bool[] BC00293_n324PropostaTitulo ;
      private string[] BC00293_A325PropostaDescricao ;
      private bool[] BC00293_n325PropostaDescricao ;
      private decimal[] BC00293_A326PropostaValor ;
      private bool[] BC00293_n326PropostaValor ;
      private string[] BC00293_A329PropostaStatus ;
      private bool[] BC00293_n329PropostaStatus ;
      private short[] BC00293_A330PropostaQuantidadeAprovadores ;
      private bool[] BC00293_n330PropostaQuantidadeAprovadores ;
      private short[] BC00293_A345PropostaReprovacoesPermitidas ;
      private bool[] BC00293_n345PropostaReprovacoesPermitidas ;
      private int[] BC00293_A227ContratoId ;
      private bool[] BC00293_n227ContratoId ;
      private int[] BC00293_A376ProcedimentosMedicosId ;
      private bool[] BC00293_n376ProcedimentosMedicosId ;
      private short[] BC00293_A328PropostaCratedBy ;
      private bool[] BC00293_n328PropostaCratedBy ;
      private int[] BC00293_A504PropostaPacienteClienteId ;
      private bool[] BC00293_n504PropostaPacienteClienteId ;
      private int[] BC00292_A323PropostaId ;
      private bool[] BC00292_n323PropostaId ;
      private DateTime[] BC00292_A327PropostaCreatedAt ;
      private bool[] BC00292_n327PropostaCreatedAt ;
      private string[] BC00292_A324PropostaTitulo ;
      private bool[] BC00292_n324PropostaTitulo ;
      private string[] BC00292_A325PropostaDescricao ;
      private bool[] BC00292_n325PropostaDescricao ;
      private decimal[] BC00292_A326PropostaValor ;
      private bool[] BC00292_n326PropostaValor ;
      private string[] BC00292_A329PropostaStatus ;
      private bool[] BC00292_n329PropostaStatus ;
      private short[] BC00292_A330PropostaQuantidadeAprovadores ;
      private bool[] BC00292_n330PropostaQuantidadeAprovadores ;
      private short[] BC00292_A345PropostaReprovacoesPermitidas ;
      private bool[] BC00292_n345PropostaReprovacoesPermitidas ;
      private int[] BC00292_A227ContratoId ;
      private bool[] BC00292_n227ContratoId ;
      private int[] BC00292_A376ProcedimentosMedicosId ;
      private bool[] BC00292_n376ProcedimentosMedicosId ;
      private short[] BC00292_A328PropostaCratedBy ;
      private bool[] BC00292_n328PropostaCratedBy ;
      private int[] BC00292_A504PropostaPacienteClienteId ;
      private bool[] BC00292_n504PropostaPacienteClienteId ;
      private int[] BC002922_A323PropostaId ;
      private bool[] BC002922_n323PropostaId ;
      private short[] BC002926_A341PropostaAprovacoes_F ;
      private bool[] BC002926_n341PropostaAprovacoes_F ;
      private short[] BC002928_A342PropostaReprovacoes_F ;
      private bool[] BC002928_n342PropostaReprovacoes_F ;
      private string[] BC002931_A548ReembolsoStatusAtual_F ;
      private bool[] BC002931_n548ReembolsoStatusAtual_F ;
      private string[] BC002932_A228ContratoNome ;
      private bool[] BC002932_n228ContratoNome ;
      private string[] BC002933_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] BC002933_n505PropostaPacienteClienteRazaoSocial ;
      private int[] BC002934_A227ContratoId ;
      private bool[] BC002934_n227ContratoId ;
      private int[] BC002935_A518ReembolsoId ;
      private bool[] BC002935_n518ReembolsoId ;
      private int[] BC002936_A261TituloId ;
      private Guid[] BC002937_A830NotaFiscalItemId ;
      private int[] BC002938_A572PropostaContratoAssinaturaId ;
      private int[] BC002939_A414PropostaDocumentosId ;
      private int[] BC002940_A336AprovacaoId ;
      private int[] BC002945_A323PropostaId ;
      private bool[] BC002945_n323PropostaId ;
      private DateTime[] BC002945_A327PropostaCreatedAt ;
      private bool[] BC002945_n327PropostaCreatedAt ;
      private string[] BC002945_A324PropostaTitulo ;
      private bool[] BC002945_n324PropostaTitulo ;
      private string[] BC002945_A325PropostaDescricao ;
      private bool[] BC002945_n325PropostaDescricao ;
      private decimal[] BC002945_A326PropostaValor ;
      private bool[] BC002945_n326PropostaValor ;
      private string[] BC002945_A329PropostaStatus ;
      private bool[] BC002945_n329PropostaStatus ;
      private string[] BC002945_A228ContratoNome ;
      private bool[] BC002945_n228ContratoNome ;
      private short[] BC002945_A330PropostaQuantidadeAprovadores ;
      private bool[] BC002945_n330PropostaQuantidadeAprovadores ;
      private short[] BC002945_A345PropostaReprovacoesPermitidas ;
      private bool[] BC002945_n345PropostaReprovacoesPermitidas ;
      private string[] BC002945_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] BC002945_n505PropostaPacienteClienteRazaoSocial ;
      private int[] BC002945_A227ContratoId ;
      private bool[] BC002945_n227ContratoId ;
      private int[] BC002945_A376ProcedimentosMedicosId ;
      private bool[] BC002945_n376ProcedimentosMedicosId ;
      private short[] BC002945_A328PropostaCratedBy ;
      private bool[] BC002945_n328PropostaCratedBy ;
      private int[] BC002945_A504PropostaPacienteClienteId ;
      private bool[] BC002945_n504PropostaPacienteClienteId ;
      private short[] BC002945_A341PropostaAprovacoes_F ;
      private bool[] BC002945_n341PropostaAprovacoes_F ;
      private short[] BC002945_A342PropostaReprovacoes_F ;
      private bool[] BC002945_n342PropostaReprovacoes_F ;
      private string[] BC002945_A548ReembolsoStatusAtual_F ;
      private bool[] BC002945_n548ReembolsoStatusAtual_F ;
      private SdtPropostaContratoAdm bcPropostaContratoAdm ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class propostacontratoadm_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new UpdateCursor(def[13])
         ,new UpdateCursor(def[14])
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
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
         ,new ForEachCursor(def[27])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00292;
          prmBC00292 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00293;
          prmBC00293 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00294;
          prmBC00294 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC00295;
          prmBC00295 = new Object[] {
          new ParDef("ProcedimentosMedicosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00296;
          prmBC00296 = new Object[] {
          new ParDef("PropostaCratedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC00297;
          prmBC00297 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00299;
          prmBC00299 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002911;
          prmBC002911 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002914;
          prmBC002914 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002919;
          prmBC002919 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          string cmdBufferBC002919;
          cmdBufferBC002919=" SELECT TM1.PropostaId, TM1.PropostaCreatedAt, TM1.PropostaTitulo, TM1.PropostaDescricao, TM1.PropostaValor, TM1.PropostaStatus, T5.ContratoNome, TM1.PropostaQuantidadeAprovadores, TM1.PropostaReprovacoesPermitidas, T6.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, TM1.ContratoId, TM1.ProcedimentosMedicosId, TM1.PropostaCratedBy AS PropostaCratedBy, TM1.PropostaPacienteClienteId AS PropostaPacienteClienteId, COALESCE( T2.PropostaAprovacoes_F, 0) AS PropostaAprovacoes_F, COALESCE( T3.PropostaAprovacoes_F, 0) AS PropostaReprovacoes_F, COALESCE( T4.ReembolsoStatusAtual_F, '') AS ReembolsoStatusAtual_F FROM (((((Proposta TM1 LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE (TM1.PropostaId = PropostaId) AND (AprovacaoStatus = ( 'APROVADO')) GROUP BY PropostaId ) T2 ON T2.PropostaId = TM1.PropostaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE (TM1.PropostaId = PropostaId) AND (AprovacaoStatus = ( 'REPROVADO')) GROUP BY PropostaId ) T3 ON T3.PropostaId = TM1.PropostaId) LEFT JOIN LATERAL (SELECT MIN(T7.ReembolsoEtapaStatus) AS ReembolsoStatusAtual_F, COALESCE( T9.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F, T8.ReembolsoPropostaId FROM ((ReembolsoEtapa T7 LEFT JOIN Reembolso T8 ON T8.ReembolsoId = T7.ReembolsoId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa WHERE T7.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T9 ON T9.ReembolsoId = T7.ReembolsoId) WHERE (TM1.PropostaId = T8.ReembolsoPropostaId) AND (T7.ReembolsoEtapaCreatedAt = COALESCE( T9.ReembolsoEtapaUltimo_F, DATE '00010101')) GROUP BY T9.ReembolsoEtapaUltimo_F, T8.ReembolsoPropostaId ) T4 ON T4.ReembolsoPropostaId = TM1.PropostaId) "
          + " LEFT JOIN Contrato T5 ON T5.ContratoId = TM1.ContratoId) LEFT JOIN Cliente T6 ON T6.ClienteId = TM1.PropostaPacienteClienteId) WHERE TM1.PropostaId = :PropostaId ORDER BY TM1.PropostaId" ;
          Object[] prmBC002920;
          prmBC002920 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002921;
          prmBC002921 = new Object[] {
          new ParDef("PropostaCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("PropostaTitulo",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("PropostaDescricao",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("PropostaValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("PropostaStatus",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("PropostaQuantidadeAprovadores",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("PropostaReprovacoesPermitidas",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("ProcedimentosMedicosId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaCratedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002922;
          prmBC002922 = new Object[] {
          };
          Object[] prmBC002923;
          prmBC002923 = new Object[] {
          new ParDef("PropostaCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("PropostaTitulo",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("PropostaDescricao",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("PropostaValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("PropostaStatus",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("PropostaQuantidadeAprovadores",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("PropostaReprovacoesPermitidas",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("ProcedimentosMedicosId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaCratedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002924;
          prmBC002924 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002926;
          prmBC002926 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002928;
          prmBC002928 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002931;
          prmBC002931 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002932;
          prmBC002932 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC002933;
          prmBC002933 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002934;
          prmBC002934 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002935;
          prmBC002935 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002936;
          prmBC002936 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002937;
          prmBC002937 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002938;
          prmBC002938 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002939;
          prmBC002939 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002940;
          prmBC002940 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002945;
          prmBC002945 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          string cmdBufferBC002945;
          cmdBufferBC002945=" SELECT TM1.PropostaId, TM1.PropostaCreatedAt, TM1.PropostaTitulo, TM1.PropostaDescricao, TM1.PropostaValor, TM1.PropostaStatus, T5.ContratoNome, TM1.PropostaQuantidadeAprovadores, TM1.PropostaReprovacoesPermitidas, T6.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, TM1.ContratoId, TM1.ProcedimentosMedicosId, TM1.PropostaCratedBy AS PropostaCratedBy, TM1.PropostaPacienteClienteId AS PropostaPacienteClienteId, COALESCE( T2.PropostaAprovacoes_F, 0) AS PropostaAprovacoes_F, COALESCE( T3.PropostaAprovacoes_F, 0) AS PropostaReprovacoes_F, COALESCE( T4.ReembolsoStatusAtual_F, '') AS ReembolsoStatusAtual_F FROM (((((Proposta TM1 LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE (TM1.PropostaId = PropostaId) AND (AprovacaoStatus = ( 'APROVADO')) GROUP BY PropostaId ) T2 ON T2.PropostaId = TM1.PropostaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE (TM1.PropostaId = PropostaId) AND (AprovacaoStatus = ( 'REPROVADO')) GROUP BY PropostaId ) T3 ON T3.PropostaId = TM1.PropostaId) LEFT JOIN LATERAL (SELECT MIN(T7.ReembolsoEtapaStatus) AS ReembolsoStatusAtual_F, COALESCE( T9.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F, T8.ReembolsoPropostaId FROM ((ReembolsoEtapa T7 LEFT JOIN Reembolso T8 ON T8.ReembolsoId = T7.ReembolsoId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa WHERE T7.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T9 ON T9.ReembolsoId = T7.ReembolsoId) WHERE (TM1.PropostaId = T8.ReembolsoPropostaId) AND (T7.ReembolsoEtapaCreatedAt = COALESCE( T9.ReembolsoEtapaUltimo_F, DATE '00010101')) GROUP BY T9.ReembolsoEtapaUltimo_F, T8.ReembolsoPropostaId ) T4 ON T4.ReembolsoPropostaId = TM1.PropostaId) "
          + " LEFT JOIN Contrato T5 ON T5.ContratoId = TM1.ContratoId) LEFT JOIN Cliente T6 ON T6.ClienteId = TM1.PropostaPacienteClienteId) WHERE TM1.PropostaId = :PropostaId ORDER BY TM1.PropostaId" ;
          def= new CursorDef[] {
              new CursorDef("BC00292", "SELECT PropostaId, PropostaCreatedAt, PropostaTitulo, PropostaDescricao, PropostaValor, PropostaStatus, PropostaQuantidadeAprovadores, PropostaReprovacoesPermitidas, ContratoId, ProcedimentosMedicosId, PropostaCratedBy, PropostaPacienteClienteId FROM Proposta WHERE PropostaId = :PropostaId  FOR UPDATE OF Proposta",true, GxErrorMask.GX_NOMASK, false, this,prmBC00292,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00293", "SELECT PropostaId, PropostaCreatedAt, PropostaTitulo, PropostaDescricao, PropostaValor, PropostaStatus, PropostaQuantidadeAprovadores, PropostaReprovacoesPermitidas, ContratoId, ProcedimentosMedicosId, PropostaCratedBy, PropostaPacienteClienteId FROM Proposta WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00293,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00294", "SELECT ContratoNome FROM Contrato WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00294,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00295", "SELECT ProcedimentosMedicosId FROM ProcedimentosMedicos WHERE ProcedimentosMedicosId = :ProcedimentosMedicosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00295,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00296", "SELECT SecUserId AS PropostaCratedBy FROM SecUser WHERE SecUserId = :PropostaCratedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00296,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00297", "SELECT ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial FROM Cliente WHERE ClienteId = :PropostaPacienteClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00297,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00299", "SELECT COALESCE( T1.PropostaAprovacoes_F, 0) AS PropostaAprovacoes_F FROM (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE AprovacaoStatus = ( 'APROVADO') GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00299,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002911", "SELECT COALESCE( T1.PropostaAprovacoes_F, 0) AS PropostaReprovacoes_F FROM (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE AprovacaoStatus = ( 'REPROVADO') GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002911,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002914", "SELECT COALESCE( T1.ReembolsoStatusAtual_F, '') AS ReembolsoStatusAtual_F FROM (SELECT MIN(T2.ReembolsoEtapaStatus) AS ReembolsoStatusAtual_F, COALESCE( T4.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F, T3.ReembolsoPropostaId FROM ((ReembolsoEtapa T2 LEFT JOIN Reembolso T3 ON T3.ReembolsoId = T2.ReembolsoId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa WHERE T2.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T4 ON T4.ReembolsoId = T2.ReembolsoId) WHERE T2.ReembolsoEtapaCreatedAt = COALESCE( T4.ReembolsoEtapaUltimo_F, DATE '00010101') GROUP BY T4.ReembolsoEtapaUltimo_F, T3.ReembolsoPropostaId ) T1 WHERE T1.ReembolsoPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002914,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002919", cmdBufferBC002919,true, GxErrorMask.GX_NOMASK, false, this,prmBC002919,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002920", "SELECT PropostaId FROM Proposta WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002920,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002921", "SAVEPOINT gxupdate;INSERT INTO Proposta(PropostaCreatedAt, PropostaTitulo, PropostaDescricao, PropostaValor, PropostaStatus, PropostaQuantidadeAprovadores, PropostaReprovacoesPermitidas, ContratoId, ProcedimentosMedicosId, PropostaCratedBy, PropostaPacienteClienteId, ConvenioVencimentoAno, ConvenioVencimentoMes, ConvenioCategoriaId, PropostaTaxaAdministrativa, PropostaSLA, PropostaJurosMora, PropostaDataCirurgia, PropostaResponsavelId, PropostaClinicaId, PropostaComentarioAnalise, PropostaProtocolo, PropostaEmpresaClienteId, PropostaTipoProposta, PropostaValorLiquido) VALUES(:PropostaCreatedAt, :PropostaTitulo, :PropostaDescricao, :PropostaValor, :PropostaStatus, :PropostaQuantidadeAprovadores, :PropostaReprovacoesPermitidas, :ContratoId, :ProcedimentosMedicosId, :PropostaCratedBy, :PropostaPacienteClienteId, 0, 0, 0, 0, 0, 0, DATE '00010101', 0, 0, '', '', 0, '', 0);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002921)
             ,new CursorDef("BC002922", "SELECT currval('PropostaId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002922,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002923", "SAVEPOINT gxupdate;UPDATE Proposta SET PropostaCreatedAt=:PropostaCreatedAt, PropostaTitulo=:PropostaTitulo, PropostaDescricao=:PropostaDescricao, PropostaValor=:PropostaValor, PropostaStatus=:PropostaStatus, PropostaQuantidadeAprovadores=:PropostaQuantidadeAprovadores, PropostaReprovacoesPermitidas=:PropostaReprovacoesPermitidas, ContratoId=:ContratoId, ProcedimentosMedicosId=:ProcedimentosMedicosId, PropostaCratedBy=:PropostaCratedBy, PropostaPacienteClienteId=:PropostaPacienteClienteId  WHERE PropostaId = :PropostaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002923)
             ,new CursorDef("BC002924", "SAVEPOINT gxupdate;DELETE FROM Proposta  WHERE PropostaId = :PropostaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002924)
             ,new CursorDef("BC002926", "SELECT COALESCE( T1.PropostaAprovacoes_F, 0) AS PropostaAprovacoes_F FROM (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE AprovacaoStatus = ( 'APROVADO') GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002926,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002928", "SELECT COALESCE( T1.PropostaAprovacoes_F, 0) AS PropostaReprovacoes_F FROM (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE AprovacaoStatus = ( 'REPROVADO') GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002928,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002931", "SELECT COALESCE( T1.ReembolsoStatusAtual_F, '') AS ReembolsoStatusAtual_F FROM (SELECT MIN(T2.ReembolsoEtapaStatus) AS ReembolsoStatusAtual_F, COALESCE( T4.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F, T3.ReembolsoPropostaId FROM ((ReembolsoEtapa T2 LEFT JOIN Reembolso T3 ON T3.ReembolsoId = T2.ReembolsoId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa WHERE T2.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T4 ON T4.ReembolsoId = T2.ReembolsoId) WHERE T2.ReembolsoEtapaCreatedAt = COALESCE( T4.ReembolsoEtapaUltimo_F, DATE '00010101') GROUP BY T4.ReembolsoEtapaUltimo_F, T3.ReembolsoPropostaId ) T1 WHERE T1.ReembolsoPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002931,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002932", "SELECT ContratoNome FROM Contrato WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002932,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002933", "SELECT ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial FROM Cliente WHERE ClienteId = :PropostaPacienteClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002933,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002934", "SELECT ContratoId FROM Contrato WHERE ContratoPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002934,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002935", "SELECT ReembolsoId FROM Reembolso WHERE ReembolsoPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002935,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002936", "SELECT TituloId FROM Titulo WHERE TituloPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002936,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002937", "SELECT NotaFiscalItemId FROM NotaFiscalItem WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002937,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002938", "SELECT PropostaContratoAssinaturaId FROM PropostaContratoAssinatura WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002938,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002939", "SELECT PropostaDocumentosId FROM PropostaDocumentos WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002939,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002940", "SELECT AprovacaoId FROM Aprovacao WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002940,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002945", cmdBufferBC002945,true, GxErrorMask.GX_NOMASK, false, this,prmBC002945,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((int[]) buf[17])[0] = rslt.getInt(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((short[]) buf[19])[0] = rslt.getShort(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((int[]) buf[17])[0] = rslt.getInt(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((short[]) buf[19])[0] = rslt.getShort(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((short[]) buf[15])[0] = rslt.getShort(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((short[]) buf[23])[0] = rslt.getShort(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((int[]) buf[25])[0] = rslt.getInt(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((short[]) buf[27])[0] = rslt.getShort(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((short[]) buf[29])[0] = rslt.getShort(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 18 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 19 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 20 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 21 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 22 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 23 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 24 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 25 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 26 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 27 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((short[]) buf[15])[0] = rslt.getShort(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((short[]) buf[23])[0] = rslt.getShort(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((int[]) buf[25])[0] = rslt.getInt(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((short[]) buf[27])[0] = rslt.getShort(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((short[]) buf[29])[0] = rslt.getShort(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                return;
       }
    }

 }

}
