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
   public class propostac_bc : GxSilentTrn, IGxSilentTrn
   {
      public propostac_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public propostac_bc( IGxContext context )
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
         ReadRow1L49( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1L49( ) ;
         standaloneModal( ) ;
         AddRow1L49( ) ;
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
            E111L2 ();
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

      protected void CONFIRM_1L0( )
      {
         BeforeValidate1L49( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1L49( ) ;
            }
            else
            {
               CheckExtendedTable1L49( ) ;
               if ( AnyError == 0 )
               {
                  ZM1L49( 11) ;
                  ZM1L49( 12) ;
                  ZM1L49( 13) ;
                  ZM1L49( 14) ;
                  ZM1L49( 15) ;
                  ZM1L49( 16) ;
               }
               CloseExtendedTableCursors1L49( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E121L2( )
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

      protected void E111L2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1L49( short GX_JID )
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
         }
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z228ContratoNome = A228ContratoNome;
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z343PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
         }
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z343PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
         }
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z343PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
         }
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            Z505PropostaPacienteClienteRazaoSocial = A505PropostaPacienteClienteRazaoSocial;
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z343PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
         }
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z343PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
         }
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z343PropostaAprovacoesRestantes_F = A343PropostaAprovacoesRestantes_F;
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
            Z228ContratoNome = A228ContratoNome;
            Z505PropostaPacienteClienteRazaoSocial = A505PropostaPacienteClienteRazaoSocial;
         }
      }

      protected void standaloneNotModal( )
      {
         AV30Pgmname = "PropostaC_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A327PropostaCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n327PropostaCreatedAt = false;
         }
      }

      protected void Load1L49( )
      {
         /* Using cursor BC001L14 */
         pr_default.execute(8, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound49 = 1;
            A327PropostaCreatedAt = BC001L14_A327PropostaCreatedAt[0];
            n327PropostaCreatedAt = BC001L14_n327PropostaCreatedAt[0];
            A324PropostaTitulo = BC001L14_A324PropostaTitulo[0];
            n324PropostaTitulo = BC001L14_n324PropostaTitulo[0];
            A325PropostaDescricao = BC001L14_A325PropostaDescricao[0];
            n325PropostaDescricao = BC001L14_n325PropostaDescricao[0];
            A326PropostaValor = BC001L14_A326PropostaValor[0];
            n326PropostaValor = BC001L14_n326PropostaValor[0];
            A329PropostaStatus = BC001L14_A329PropostaStatus[0];
            n329PropostaStatus = BC001L14_n329PropostaStatus[0];
            A228ContratoNome = BC001L14_A228ContratoNome[0];
            n228ContratoNome = BC001L14_n228ContratoNome[0];
            A330PropostaQuantidadeAprovadores = BC001L14_A330PropostaQuantidadeAprovadores[0];
            n330PropostaQuantidadeAprovadores = BC001L14_n330PropostaQuantidadeAprovadores[0];
            A345PropostaReprovacoesPermitidas = BC001L14_A345PropostaReprovacoesPermitidas[0];
            n345PropostaReprovacoesPermitidas = BC001L14_n345PropostaReprovacoesPermitidas[0];
            A505PropostaPacienteClienteRazaoSocial = BC001L14_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = BC001L14_n505PropostaPacienteClienteRazaoSocial[0];
            A227ContratoId = BC001L14_A227ContratoId[0];
            n227ContratoId = BC001L14_n227ContratoId[0];
            A376ProcedimentosMedicosId = BC001L14_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = BC001L14_n376ProcedimentosMedicosId[0];
            A328PropostaCratedBy = BC001L14_A328PropostaCratedBy[0];
            n328PropostaCratedBy = BC001L14_n328PropostaCratedBy[0];
            A504PropostaPacienteClienteId = BC001L14_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = BC001L14_n504PropostaPacienteClienteId[0];
            A341PropostaAprovacoes_F = BC001L14_A341PropostaAprovacoes_F[0];
            n341PropostaAprovacoes_F = BC001L14_n341PropostaAprovacoes_F[0];
            A342PropostaReprovacoes_F = BC001L14_A342PropostaReprovacoes_F[0];
            n342PropostaReprovacoes_F = BC001L14_n342PropostaReprovacoes_F[0];
            ZM1L49( -10) ;
         }
         pr_default.close(8);
         OnLoadActions1L49( ) ;
      }

      protected void OnLoadActions1L49( )
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

      protected void CheckExtendedTable1L49( )
      {
         standaloneModal( ) ;
         /* Using cursor BC001L9 */
         pr_default.execute(6, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            A341PropostaAprovacoes_F = BC001L9_A341PropostaAprovacoes_F[0];
            n341PropostaAprovacoes_F = BC001L9_n341PropostaAprovacoes_F[0];
         }
         else
         {
            A341PropostaAprovacoes_F = 0;
            n341PropostaAprovacoes_F = false;
         }
         pr_default.close(6);
         A343PropostaAprovacoesRestantes_F = (short)(A330PropostaQuantidadeAprovadores-A341PropostaAprovacoes_F);
         /* Using cursor BC001L11 */
         pr_default.execute(7, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            A342PropostaReprovacoes_F = BC001L11_A342PropostaReprovacoes_F[0];
            n342PropostaReprovacoes_F = BC001L11_n342PropostaReprovacoes_F[0];
         }
         else
         {
            A342PropostaReprovacoes_F = 0;
            n342PropostaReprovacoes_F = false;
         }
         pr_default.close(7);
         if ( (0==A376ProcedimentosMedicosId) )
         {
            A376ProcedimentosMedicosId = 0;
            n376ProcedimentosMedicosId = false;
            n376ProcedimentosMedicosId = true;
            n376ProcedimentosMedicosId = true;
         }
         /* Using cursor BC001L5 */
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
         /* Using cursor BC001L6 */
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
         /* Using cursor BC001L4 */
         pr_default.execute(2, new Object[] {n227ContratoId, A227ContratoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A227ContratoId) ) )
            {
               GX_msglist.addItem("Não existe 'Contrato'.", "ForeignKeyNotFound", 1, "CONTRATOID");
               AnyError = 1;
            }
         }
         A228ContratoNome = BC001L4_A228ContratoNome[0];
         n228ContratoNome = BC001L4_n228ContratoNome[0];
         pr_default.close(2);
         /* Using cursor BC001L7 */
         pr_default.execute(5, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A504PropostaPacienteClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Proposta Cliente'.", "ForeignKeyNotFound", 1, "PROPOSTAPACIENTECLIENTEID");
               AnyError = 1;
            }
         }
         A505PropostaPacienteClienteRazaoSocial = BC001L7_A505PropostaPacienteClienteRazaoSocial[0];
         n505PropostaPacienteClienteRazaoSocial = BC001L7_n505PropostaPacienteClienteRazaoSocial[0];
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors1L49( )
      {
         pr_default.close(6);
         pr_default.close(7);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(2);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1L49( )
      {
         /* Using cursor BC001L15 */
         pr_default.execute(9, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound49 = 1;
         }
         else
         {
            RcdFound49 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001L3 */
         pr_default.execute(1, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1L49( 10) ;
            RcdFound49 = 1;
            A323PropostaId = BC001L3_A323PropostaId[0];
            n323PropostaId = BC001L3_n323PropostaId[0];
            A327PropostaCreatedAt = BC001L3_A327PropostaCreatedAt[0];
            n327PropostaCreatedAt = BC001L3_n327PropostaCreatedAt[0];
            A324PropostaTitulo = BC001L3_A324PropostaTitulo[0];
            n324PropostaTitulo = BC001L3_n324PropostaTitulo[0];
            A325PropostaDescricao = BC001L3_A325PropostaDescricao[0];
            n325PropostaDescricao = BC001L3_n325PropostaDescricao[0];
            A326PropostaValor = BC001L3_A326PropostaValor[0];
            n326PropostaValor = BC001L3_n326PropostaValor[0];
            A329PropostaStatus = BC001L3_A329PropostaStatus[0];
            n329PropostaStatus = BC001L3_n329PropostaStatus[0];
            A330PropostaQuantidadeAprovadores = BC001L3_A330PropostaQuantidadeAprovadores[0];
            n330PropostaQuantidadeAprovadores = BC001L3_n330PropostaQuantidadeAprovadores[0];
            A345PropostaReprovacoesPermitidas = BC001L3_A345PropostaReprovacoesPermitidas[0];
            n345PropostaReprovacoesPermitidas = BC001L3_n345PropostaReprovacoesPermitidas[0];
            A227ContratoId = BC001L3_A227ContratoId[0];
            n227ContratoId = BC001L3_n227ContratoId[0];
            A376ProcedimentosMedicosId = BC001L3_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = BC001L3_n376ProcedimentosMedicosId[0];
            A328PropostaCratedBy = BC001L3_A328PropostaCratedBy[0];
            n328PropostaCratedBy = BC001L3_n328PropostaCratedBy[0];
            A504PropostaPacienteClienteId = BC001L3_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = BC001L3_n504PropostaPacienteClienteId[0];
            Z323PropostaId = A323PropostaId;
            sMode49 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1L49( ) ;
            if ( AnyError == 1 )
            {
               RcdFound49 = 0;
               InitializeNonKey1L49( ) ;
            }
            Gx_mode = sMode49;
         }
         else
         {
            RcdFound49 = 0;
            InitializeNonKey1L49( ) ;
            sMode49 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode49;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1L49( ) ;
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
         CONFIRM_1L0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1L49( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001L2 */
            pr_default.execute(0, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Proposta"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z327PropostaCreatedAt != BC001L2_A327PropostaCreatedAt[0] ) || ( StringUtil.StrCmp(Z324PropostaTitulo, BC001L2_A324PropostaTitulo[0]) != 0 ) || ( StringUtil.StrCmp(Z325PropostaDescricao, BC001L2_A325PropostaDescricao[0]) != 0 ) || ( Z326PropostaValor != BC001L2_A326PropostaValor[0] ) || ( StringUtil.StrCmp(Z329PropostaStatus, BC001L2_A329PropostaStatus[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z330PropostaQuantidadeAprovadores != BC001L2_A330PropostaQuantidadeAprovadores[0] ) || ( Z345PropostaReprovacoesPermitidas != BC001L2_A345PropostaReprovacoesPermitidas[0] ) || ( Z227ContratoId != BC001L2_A227ContratoId[0] ) || ( Z376ProcedimentosMedicosId != BC001L2_A376ProcedimentosMedicosId[0] ) || ( Z328PropostaCratedBy != BC001L2_A328PropostaCratedBy[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z504PropostaPacienteClienteId != BC001L2_A504PropostaPacienteClienteId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Proposta"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1L49( )
      {
         BeforeValidate1L49( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1L49( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1L49( 0) ;
            CheckOptimisticConcurrency1L49( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1L49( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1L49( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001L16 */
                     pr_default.execute(10, new Object[] {n327PropostaCreatedAt, A327PropostaCreatedAt, n324PropostaTitulo, A324PropostaTitulo, n325PropostaDescricao, A325PropostaDescricao, n326PropostaValor, A326PropostaValor, n329PropostaStatus, A329PropostaStatus, n330PropostaQuantidadeAprovadores, A330PropostaQuantidadeAprovadores, n345PropostaReprovacoesPermitidas, A345PropostaReprovacoesPermitidas, n227ContratoId, A227ContratoId, n376ProcedimentosMedicosId, A376ProcedimentosMedicosId, n328PropostaCratedBy, A328PropostaCratedBy, n504PropostaPacienteClienteId, A504PropostaPacienteClienteId});
                     pr_default.close(10);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC001L17 */
                     pr_default.execute(11);
                     A323PropostaId = BC001L17_A323PropostaId[0];
                     n323PropostaId = BC001L17_n323PropostaId[0];
                     pr_default.close(11);
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
               Load1L49( ) ;
            }
            EndLevel1L49( ) ;
         }
         CloseExtendedTableCursors1L49( ) ;
      }

      protected void Update1L49( )
      {
         BeforeValidate1L49( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1L49( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1L49( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1L49( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1L49( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001L18 */
                     pr_default.execute(12, new Object[] {n327PropostaCreatedAt, A327PropostaCreatedAt, n324PropostaTitulo, A324PropostaTitulo, n325PropostaDescricao, A325PropostaDescricao, n326PropostaValor, A326PropostaValor, n329PropostaStatus, A329PropostaStatus, n330PropostaQuantidadeAprovadores, A330PropostaQuantidadeAprovadores, n345PropostaReprovacoesPermitidas, A345PropostaReprovacoesPermitidas, n227ContratoId, A227ContratoId, n376ProcedimentosMedicosId, A376ProcedimentosMedicosId, n328PropostaCratedBy, A328PropostaCratedBy, n504PropostaPacienteClienteId, A504PropostaPacienteClienteId, n323PropostaId, A323PropostaId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Proposta");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Proposta"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1L49( ) ;
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
            EndLevel1L49( ) ;
         }
         CloseExtendedTableCursors1L49( ) ;
      }

      protected void DeferredUpdate1L49( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1L49( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1L49( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1L49( ) ;
            AfterConfirm1L49( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1L49( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001L19 */
                  pr_default.execute(13, new Object[] {n323PropostaId, A323PropostaId});
                  pr_default.close(13);
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
         EndLevel1L49( ) ;
         Gx_mode = sMode49;
      }

      protected void OnDeleteControls1L49( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001L21 */
            pr_default.execute(14, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               A341PropostaAprovacoes_F = BC001L21_A341PropostaAprovacoes_F[0];
               n341PropostaAprovacoes_F = BC001L21_n341PropostaAprovacoes_F[0];
            }
            else
            {
               A341PropostaAprovacoes_F = 0;
               n341PropostaAprovacoes_F = false;
            }
            pr_default.close(14);
            /* Using cursor BC001L23 */
            pr_default.execute(15, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               A342PropostaReprovacoes_F = BC001L23_A342PropostaReprovacoes_F[0];
               n342PropostaReprovacoes_F = BC001L23_n342PropostaReprovacoes_F[0];
            }
            else
            {
               A342PropostaReprovacoes_F = 0;
               n342PropostaReprovacoes_F = false;
            }
            pr_default.close(15);
            /* Using cursor BC001L24 */
            pr_default.execute(16, new Object[] {n227ContratoId, A227ContratoId});
            A228ContratoNome = BC001L24_A228ContratoNome[0];
            n228ContratoNome = BC001L24_n228ContratoNome[0];
            pr_default.close(16);
            A343PropostaAprovacoesRestantes_F = (short)(A330PropostaQuantidadeAprovadores-A341PropostaAprovacoes_F);
            /* Using cursor BC001L25 */
            pr_default.execute(17, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId});
            A505PropostaPacienteClienteRazaoSocial = BC001L25_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = BC001L25_n505PropostaPacienteClienteRazaoSocial[0];
            pr_default.close(17);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC001L26 */
            pr_default.execute(18, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Contrato"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor BC001L27 */
            pr_default.execute(19, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Reembolso"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor BC001L28 */
            pr_default.execute(20, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Titulo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor BC001L29 */
            pr_default.execute(21, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"NotaFiscalItem"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor BC001L30 */
            pr_default.execute(22, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"PropostaContratoAssinatura"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor BC001L31 */
            pr_default.execute(23, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"PropostaDocumentos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
            /* Using cursor BC001L32 */
            pr_default.execute(24, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Aprovacao"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
         }
      }

      protected void EndLevel1L49( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1L49( ) ;
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

      public void ScanKeyStart1L49( )
      {
         /* Scan By routine */
         /* Using cursor BC001L35 */
         pr_default.execute(25, new Object[] {n323PropostaId, A323PropostaId});
         RcdFound49 = 0;
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound49 = 1;
            A323PropostaId = BC001L35_A323PropostaId[0];
            n323PropostaId = BC001L35_n323PropostaId[0];
            A327PropostaCreatedAt = BC001L35_A327PropostaCreatedAt[0];
            n327PropostaCreatedAt = BC001L35_n327PropostaCreatedAt[0];
            A324PropostaTitulo = BC001L35_A324PropostaTitulo[0];
            n324PropostaTitulo = BC001L35_n324PropostaTitulo[0];
            A325PropostaDescricao = BC001L35_A325PropostaDescricao[0];
            n325PropostaDescricao = BC001L35_n325PropostaDescricao[0];
            A326PropostaValor = BC001L35_A326PropostaValor[0];
            n326PropostaValor = BC001L35_n326PropostaValor[0];
            A329PropostaStatus = BC001L35_A329PropostaStatus[0];
            n329PropostaStatus = BC001L35_n329PropostaStatus[0];
            A228ContratoNome = BC001L35_A228ContratoNome[0];
            n228ContratoNome = BC001L35_n228ContratoNome[0];
            A330PropostaQuantidadeAprovadores = BC001L35_A330PropostaQuantidadeAprovadores[0];
            n330PropostaQuantidadeAprovadores = BC001L35_n330PropostaQuantidadeAprovadores[0];
            A345PropostaReprovacoesPermitidas = BC001L35_A345PropostaReprovacoesPermitidas[0];
            n345PropostaReprovacoesPermitidas = BC001L35_n345PropostaReprovacoesPermitidas[0];
            A505PropostaPacienteClienteRazaoSocial = BC001L35_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = BC001L35_n505PropostaPacienteClienteRazaoSocial[0];
            A227ContratoId = BC001L35_A227ContratoId[0];
            n227ContratoId = BC001L35_n227ContratoId[0];
            A376ProcedimentosMedicosId = BC001L35_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = BC001L35_n376ProcedimentosMedicosId[0];
            A328PropostaCratedBy = BC001L35_A328PropostaCratedBy[0];
            n328PropostaCratedBy = BC001L35_n328PropostaCratedBy[0];
            A504PropostaPacienteClienteId = BC001L35_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = BC001L35_n504PropostaPacienteClienteId[0];
            A341PropostaAprovacoes_F = BC001L35_A341PropostaAprovacoes_F[0];
            n341PropostaAprovacoes_F = BC001L35_n341PropostaAprovacoes_F[0];
            A342PropostaReprovacoes_F = BC001L35_A342PropostaReprovacoes_F[0];
            n342PropostaReprovacoes_F = BC001L35_n342PropostaReprovacoes_F[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1L49( )
      {
         /* Scan next routine */
         pr_default.readNext(25);
         RcdFound49 = 0;
         ScanKeyLoad1L49( ) ;
      }

      protected void ScanKeyLoad1L49( )
      {
         sMode49 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound49 = 1;
            A323PropostaId = BC001L35_A323PropostaId[0];
            n323PropostaId = BC001L35_n323PropostaId[0];
            A327PropostaCreatedAt = BC001L35_A327PropostaCreatedAt[0];
            n327PropostaCreatedAt = BC001L35_n327PropostaCreatedAt[0];
            A324PropostaTitulo = BC001L35_A324PropostaTitulo[0];
            n324PropostaTitulo = BC001L35_n324PropostaTitulo[0];
            A325PropostaDescricao = BC001L35_A325PropostaDescricao[0];
            n325PropostaDescricao = BC001L35_n325PropostaDescricao[0];
            A326PropostaValor = BC001L35_A326PropostaValor[0];
            n326PropostaValor = BC001L35_n326PropostaValor[0];
            A329PropostaStatus = BC001L35_A329PropostaStatus[0];
            n329PropostaStatus = BC001L35_n329PropostaStatus[0];
            A228ContratoNome = BC001L35_A228ContratoNome[0];
            n228ContratoNome = BC001L35_n228ContratoNome[0];
            A330PropostaQuantidadeAprovadores = BC001L35_A330PropostaQuantidadeAprovadores[0];
            n330PropostaQuantidadeAprovadores = BC001L35_n330PropostaQuantidadeAprovadores[0];
            A345PropostaReprovacoesPermitidas = BC001L35_A345PropostaReprovacoesPermitidas[0];
            n345PropostaReprovacoesPermitidas = BC001L35_n345PropostaReprovacoesPermitidas[0];
            A505PropostaPacienteClienteRazaoSocial = BC001L35_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = BC001L35_n505PropostaPacienteClienteRazaoSocial[0];
            A227ContratoId = BC001L35_A227ContratoId[0];
            n227ContratoId = BC001L35_n227ContratoId[0];
            A376ProcedimentosMedicosId = BC001L35_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = BC001L35_n376ProcedimentosMedicosId[0];
            A328PropostaCratedBy = BC001L35_A328PropostaCratedBy[0];
            n328PropostaCratedBy = BC001L35_n328PropostaCratedBy[0];
            A504PropostaPacienteClienteId = BC001L35_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = BC001L35_n504PropostaPacienteClienteId[0];
            A341PropostaAprovacoes_F = BC001L35_A341PropostaAprovacoes_F[0];
            n341PropostaAprovacoes_F = BC001L35_n341PropostaAprovacoes_F[0];
            A342PropostaReprovacoes_F = BC001L35_A342PropostaReprovacoes_F[0];
            n342PropostaReprovacoes_F = BC001L35_n342PropostaReprovacoes_F[0];
         }
         Gx_mode = sMode49;
      }

      protected void ScanKeyEnd1L49( )
      {
         pr_default.close(25);
      }

      protected void AfterConfirm1L49( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1L49( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1L49( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1L49( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1L49( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1L49( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1L49( )
      {
      }

      protected void send_integrity_lvl_hashes1L49( )
      {
      }

      protected void AddRow1L49( )
      {
         VarsToRow49( bcPropostaC) ;
      }

      protected void ReadRow1L49( )
      {
         RowToVars49( bcPropostaC, 1) ;
      }

      protected void InitializeNonKey1L49( )
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

      protected void InitAll1L49( )
      {
         A323PropostaId = 0;
         n323PropostaId = false;
         InitializeNonKey1L49( ) ;
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

      public void VarsToRow49( SdtPropostaC obj49 )
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
         obj49.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow49( SdtPropostaC obj49 )
      {
         obj49.gxTpr_Propostaid = A323PropostaId;
         return  ;
      }

      public void RowToVars49( SdtPropostaC obj49 ,
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
         InitializeNonKey1L49( ) ;
         ScanKeyStart1L49( ) ;
         if ( RcdFound49 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z323PropostaId = A323PropostaId;
         }
         ZM1L49( -10) ;
         OnLoadActions1L49( ) ;
         AddRow1L49( ) ;
         ScanKeyEnd1L49( ) ;
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
         RowToVars49( bcPropostaC, 0) ;
         ScanKeyStart1L49( ) ;
         if ( RcdFound49 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z323PropostaId = A323PropostaId;
         }
         ZM1L49( -10) ;
         OnLoadActions1L49( ) ;
         AddRow1L49( ) ;
         ScanKeyEnd1L49( ) ;
         if ( RcdFound49 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1L49( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1L49( ) ;
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
                  Update1L49( ) ;
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
                        Insert1L49( ) ;
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
                        Insert1L49( ) ;
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
         RowToVars49( bcPropostaC, 1) ;
         SaveImpl( ) ;
         VarsToRow49( bcPropostaC) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars49( bcPropostaC, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1L49( ) ;
         AfterTrn( ) ;
         VarsToRow49( bcPropostaC) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow49( bcPropostaC) ;
         }
         else
         {
            SdtPropostaC auxBC = new SdtPropostaC(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A323PropostaId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcPropostaC);
               auxBC.Save();
               bcPropostaC.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars49( bcPropostaC, 1) ;
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
         RowToVars49( bcPropostaC, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1L49( ) ;
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
               VarsToRow49( bcPropostaC) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow49( bcPropostaC) ;
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
         RowToVars49( bcPropostaC, 0) ;
         GetKey1L49( ) ;
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
         context.RollbackDataStores("propostac_bc",pr_default);
         VarsToRow49( bcPropostaC) ;
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
         Gx_mode = bcPropostaC.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcPropostaC.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcPropostaC )
         {
            bcPropostaC = (SdtPropostaC)(sdt);
            if ( StringUtil.StrCmp(bcPropostaC.gxTpr_Mode, "") == 0 )
            {
               bcPropostaC.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow49( bcPropostaC) ;
            }
            else
            {
               RowToVars49( bcPropostaC, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcPropostaC.gxTpr_Mode, "") == 0 )
            {
               bcPropostaC.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars49( bcPropostaC, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtPropostaC PropostaC_BC
      {
         get {
            return bcPropostaC ;
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
         pr_default.close(16);
         pr_default.close(17);
         pr_default.close(14);
         pr_default.close(15);
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
         Z228ContratoNome = "";
         A228ContratoNome = "";
         Z505PropostaPacienteClienteRazaoSocial = "";
         A505PropostaPacienteClienteRazaoSocial = "";
         BC001L14_A323PropostaId = new int[1] ;
         BC001L14_n323PropostaId = new bool[] {false} ;
         BC001L14_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC001L14_n327PropostaCreatedAt = new bool[] {false} ;
         BC001L14_A324PropostaTitulo = new string[] {""} ;
         BC001L14_n324PropostaTitulo = new bool[] {false} ;
         BC001L14_A325PropostaDescricao = new string[] {""} ;
         BC001L14_n325PropostaDescricao = new bool[] {false} ;
         BC001L14_A326PropostaValor = new decimal[1] ;
         BC001L14_n326PropostaValor = new bool[] {false} ;
         BC001L14_A329PropostaStatus = new string[] {""} ;
         BC001L14_n329PropostaStatus = new bool[] {false} ;
         BC001L14_A228ContratoNome = new string[] {""} ;
         BC001L14_n228ContratoNome = new bool[] {false} ;
         BC001L14_A330PropostaQuantidadeAprovadores = new short[1] ;
         BC001L14_n330PropostaQuantidadeAprovadores = new bool[] {false} ;
         BC001L14_A345PropostaReprovacoesPermitidas = new short[1] ;
         BC001L14_n345PropostaReprovacoesPermitidas = new bool[] {false} ;
         BC001L14_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         BC001L14_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         BC001L14_A227ContratoId = new int[1] ;
         BC001L14_n227ContratoId = new bool[] {false} ;
         BC001L14_A376ProcedimentosMedicosId = new int[1] ;
         BC001L14_n376ProcedimentosMedicosId = new bool[] {false} ;
         BC001L14_A328PropostaCratedBy = new short[1] ;
         BC001L14_n328PropostaCratedBy = new bool[] {false} ;
         BC001L14_A504PropostaPacienteClienteId = new int[1] ;
         BC001L14_n504PropostaPacienteClienteId = new bool[] {false} ;
         BC001L14_A341PropostaAprovacoes_F = new short[1] ;
         BC001L14_n341PropostaAprovacoes_F = new bool[] {false} ;
         BC001L14_A342PropostaReprovacoes_F = new short[1] ;
         BC001L14_n342PropostaReprovacoes_F = new bool[] {false} ;
         BC001L9_A341PropostaAprovacoes_F = new short[1] ;
         BC001L9_n341PropostaAprovacoes_F = new bool[] {false} ;
         BC001L11_A342PropostaReprovacoes_F = new short[1] ;
         BC001L11_n342PropostaReprovacoes_F = new bool[] {false} ;
         BC001L5_A376ProcedimentosMedicosId = new int[1] ;
         BC001L5_n376ProcedimentosMedicosId = new bool[] {false} ;
         BC001L6_A328PropostaCratedBy = new short[1] ;
         BC001L6_n328PropostaCratedBy = new bool[] {false} ;
         BC001L4_A228ContratoNome = new string[] {""} ;
         BC001L4_n228ContratoNome = new bool[] {false} ;
         BC001L7_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         BC001L7_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         BC001L15_A323PropostaId = new int[1] ;
         BC001L15_n323PropostaId = new bool[] {false} ;
         BC001L3_A323PropostaId = new int[1] ;
         BC001L3_n323PropostaId = new bool[] {false} ;
         BC001L3_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC001L3_n327PropostaCreatedAt = new bool[] {false} ;
         BC001L3_A324PropostaTitulo = new string[] {""} ;
         BC001L3_n324PropostaTitulo = new bool[] {false} ;
         BC001L3_A325PropostaDescricao = new string[] {""} ;
         BC001L3_n325PropostaDescricao = new bool[] {false} ;
         BC001L3_A326PropostaValor = new decimal[1] ;
         BC001L3_n326PropostaValor = new bool[] {false} ;
         BC001L3_A329PropostaStatus = new string[] {""} ;
         BC001L3_n329PropostaStatus = new bool[] {false} ;
         BC001L3_A330PropostaQuantidadeAprovadores = new short[1] ;
         BC001L3_n330PropostaQuantidadeAprovadores = new bool[] {false} ;
         BC001L3_A345PropostaReprovacoesPermitidas = new short[1] ;
         BC001L3_n345PropostaReprovacoesPermitidas = new bool[] {false} ;
         BC001L3_A227ContratoId = new int[1] ;
         BC001L3_n227ContratoId = new bool[] {false} ;
         BC001L3_A376ProcedimentosMedicosId = new int[1] ;
         BC001L3_n376ProcedimentosMedicosId = new bool[] {false} ;
         BC001L3_A328PropostaCratedBy = new short[1] ;
         BC001L3_n328PropostaCratedBy = new bool[] {false} ;
         BC001L3_A504PropostaPacienteClienteId = new int[1] ;
         BC001L3_n504PropostaPacienteClienteId = new bool[] {false} ;
         sMode49 = "";
         BC001L2_A323PropostaId = new int[1] ;
         BC001L2_n323PropostaId = new bool[] {false} ;
         BC001L2_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC001L2_n327PropostaCreatedAt = new bool[] {false} ;
         BC001L2_A324PropostaTitulo = new string[] {""} ;
         BC001L2_n324PropostaTitulo = new bool[] {false} ;
         BC001L2_A325PropostaDescricao = new string[] {""} ;
         BC001L2_n325PropostaDescricao = new bool[] {false} ;
         BC001L2_A326PropostaValor = new decimal[1] ;
         BC001L2_n326PropostaValor = new bool[] {false} ;
         BC001L2_A329PropostaStatus = new string[] {""} ;
         BC001L2_n329PropostaStatus = new bool[] {false} ;
         BC001L2_A330PropostaQuantidadeAprovadores = new short[1] ;
         BC001L2_n330PropostaQuantidadeAprovadores = new bool[] {false} ;
         BC001L2_A345PropostaReprovacoesPermitidas = new short[1] ;
         BC001L2_n345PropostaReprovacoesPermitidas = new bool[] {false} ;
         BC001L2_A227ContratoId = new int[1] ;
         BC001L2_n227ContratoId = new bool[] {false} ;
         BC001L2_A376ProcedimentosMedicosId = new int[1] ;
         BC001L2_n376ProcedimentosMedicosId = new bool[] {false} ;
         BC001L2_A328PropostaCratedBy = new short[1] ;
         BC001L2_n328PropostaCratedBy = new bool[] {false} ;
         BC001L2_A504PropostaPacienteClienteId = new int[1] ;
         BC001L2_n504PropostaPacienteClienteId = new bool[] {false} ;
         BC001L17_A323PropostaId = new int[1] ;
         BC001L17_n323PropostaId = new bool[] {false} ;
         BC001L21_A341PropostaAprovacoes_F = new short[1] ;
         BC001L21_n341PropostaAprovacoes_F = new bool[] {false} ;
         BC001L23_A342PropostaReprovacoes_F = new short[1] ;
         BC001L23_n342PropostaReprovacoes_F = new bool[] {false} ;
         BC001L24_A228ContratoNome = new string[] {""} ;
         BC001L24_n228ContratoNome = new bool[] {false} ;
         BC001L25_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         BC001L25_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         BC001L26_A227ContratoId = new int[1] ;
         BC001L26_n227ContratoId = new bool[] {false} ;
         BC001L27_A518ReembolsoId = new int[1] ;
         BC001L28_A261TituloId = new int[1] ;
         BC001L29_A830NotaFiscalItemId = new Guid[] {Guid.Empty} ;
         BC001L30_A572PropostaContratoAssinaturaId = new int[1] ;
         BC001L31_A414PropostaDocumentosId = new int[1] ;
         BC001L32_A336AprovacaoId = new int[1] ;
         BC001L35_A323PropostaId = new int[1] ;
         BC001L35_n323PropostaId = new bool[] {false} ;
         BC001L35_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC001L35_n327PropostaCreatedAt = new bool[] {false} ;
         BC001L35_A324PropostaTitulo = new string[] {""} ;
         BC001L35_n324PropostaTitulo = new bool[] {false} ;
         BC001L35_A325PropostaDescricao = new string[] {""} ;
         BC001L35_n325PropostaDescricao = new bool[] {false} ;
         BC001L35_A326PropostaValor = new decimal[1] ;
         BC001L35_n326PropostaValor = new bool[] {false} ;
         BC001L35_A329PropostaStatus = new string[] {""} ;
         BC001L35_n329PropostaStatus = new bool[] {false} ;
         BC001L35_A228ContratoNome = new string[] {""} ;
         BC001L35_n228ContratoNome = new bool[] {false} ;
         BC001L35_A330PropostaQuantidadeAprovadores = new short[1] ;
         BC001L35_n330PropostaQuantidadeAprovadores = new bool[] {false} ;
         BC001L35_A345PropostaReprovacoesPermitidas = new short[1] ;
         BC001L35_n345PropostaReprovacoesPermitidas = new bool[] {false} ;
         BC001L35_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         BC001L35_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         BC001L35_A227ContratoId = new int[1] ;
         BC001L35_n227ContratoId = new bool[] {false} ;
         BC001L35_A376ProcedimentosMedicosId = new int[1] ;
         BC001L35_n376ProcedimentosMedicosId = new bool[] {false} ;
         BC001L35_A328PropostaCratedBy = new short[1] ;
         BC001L35_n328PropostaCratedBy = new bool[] {false} ;
         BC001L35_A504PropostaPacienteClienteId = new int[1] ;
         BC001L35_n504PropostaPacienteClienteId = new bool[] {false} ;
         BC001L35_A341PropostaAprovacoes_F = new short[1] ;
         BC001L35_n341PropostaAprovacoes_F = new bool[] {false} ;
         BC001L35_A342PropostaReprovacoes_F = new short[1] ;
         BC001L35_n342PropostaReprovacoes_F = new bool[] {false} ;
         i327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.propostac_bc__default(),
            new Object[][] {
                new Object[] {
               BC001L2_A323PropostaId, BC001L2_A327PropostaCreatedAt, BC001L2_n327PropostaCreatedAt, BC001L2_A324PropostaTitulo, BC001L2_n324PropostaTitulo, BC001L2_A325PropostaDescricao, BC001L2_n325PropostaDescricao, BC001L2_A326PropostaValor, BC001L2_n326PropostaValor, BC001L2_A329PropostaStatus,
               BC001L2_n329PropostaStatus, BC001L2_A330PropostaQuantidadeAprovadores, BC001L2_n330PropostaQuantidadeAprovadores, BC001L2_A345PropostaReprovacoesPermitidas, BC001L2_n345PropostaReprovacoesPermitidas, BC001L2_A227ContratoId, BC001L2_n227ContratoId, BC001L2_A376ProcedimentosMedicosId, BC001L2_n376ProcedimentosMedicosId, BC001L2_A328PropostaCratedBy,
               BC001L2_n328PropostaCratedBy, BC001L2_A504PropostaPacienteClienteId, BC001L2_n504PropostaPacienteClienteId
               }
               , new Object[] {
               BC001L3_A323PropostaId, BC001L3_A327PropostaCreatedAt, BC001L3_n327PropostaCreatedAt, BC001L3_A324PropostaTitulo, BC001L3_n324PropostaTitulo, BC001L3_A325PropostaDescricao, BC001L3_n325PropostaDescricao, BC001L3_A326PropostaValor, BC001L3_n326PropostaValor, BC001L3_A329PropostaStatus,
               BC001L3_n329PropostaStatus, BC001L3_A330PropostaQuantidadeAprovadores, BC001L3_n330PropostaQuantidadeAprovadores, BC001L3_A345PropostaReprovacoesPermitidas, BC001L3_n345PropostaReprovacoesPermitidas, BC001L3_A227ContratoId, BC001L3_n227ContratoId, BC001L3_A376ProcedimentosMedicosId, BC001L3_n376ProcedimentosMedicosId, BC001L3_A328PropostaCratedBy,
               BC001L3_n328PropostaCratedBy, BC001L3_A504PropostaPacienteClienteId, BC001L3_n504PropostaPacienteClienteId
               }
               , new Object[] {
               BC001L4_A228ContratoNome, BC001L4_n228ContratoNome
               }
               , new Object[] {
               BC001L5_A376ProcedimentosMedicosId
               }
               , new Object[] {
               BC001L6_A328PropostaCratedBy
               }
               , new Object[] {
               BC001L7_A505PropostaPacienteClienteRazaoSocial, BC001L7_n505PropostaPacienteClienteRazaoSocial
               }
               , new Object[] {
               BC001L9_A341PropostaAprovacoes_F, BC001L9_n341PropostaAprovacoes_F
               }
               , new Object[] {
               BC001L11_A342PropostaReprovacoes_F, BC001L11_n342PropostaReprovacoes_F
               }
               , new Object[] {
               BC001L14_A323PropostaId, BC001L14_A327PropostaCreatedAt, BC001L14_n327PropostaCreatedAt, BC001L14_A324PropostaTitulo, BC001L14_n324PropostaTitulo, BC001L14_A325PropostaDescricao, BC001L14_n325PropostaDescricao, BC001L14_A326PropostaValor, BC001L14_n326PropostaValor, BC001L14_A329PropostaStatus,
               BC001L14_n329PropostaStatus, BC001L14_A228ContratoNome, BC001L14_n228ContratoNome, BC001L14_A330PropostaQuantidadeAprovadores, BC001L14_n330PropostaQuantidadeAprovadores, BC001L14_A345PropostaReprovacoesPermitidas, BC001L14_n345PropostaReprovacoesPermitidas, BC001L14_A505PropostaPacienteClienteRazaoSocial, BC001L14_n505PropostaPacienteClienteRazaoSocial, BC001L14_A227ContratoId,
               BC001L14_n227ContratoId, BC001L14_A376ProcedimentosMedicosId, BC001L14_n376ProcedimentosMedicosId, BC001L14_A328PropostaCratedBy, BC001L14_n328PropostaCratedBy, BC001L14_A504PropostaPacienteClienteId, BC001L14_n504PropostaPacienteClienteId, BC001L14_A341PropostaAprovacoes_F, BC001L14_n341PropostaAprovacoes_F, BC001L14_A342PropostaReprovacoes_F,
               BC001L14_n342PropostaReprovacoes_F
               }
               , new Object[] {
               BC001L15_A323PropostaId
               }
               , new Object[] {
               }
               , new Object[] {
               BC001L17_A323PropostaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001L21_A341PropostaAprovacoes_F, BC001L21_n341PropostaAprovacoes_F
               }
               , new Object[] {
               BC001L23_A342PropostaReprovacoes_F, BC001L23_n342PropostaReprovacoes_F
               }
               , new Object[] {
               BC001L24_A228ContratoNome, BC001L24_n228ContratoNome
               }
               , new Object[] {
               BC001L25_A505PropostaPacienteClienteRazaoSocial, BC001L25_n505PropostaPacienteClienteRazaoSocial
               }
               , new Object[] {
               BC001L26_A227ContratoId
               }
               , new Object[] {
               BC001L27_A518ReembolsoId
               }
               , new Object[] {
               BC001L28_A261TituloId
               }
               , new Object[] {
               BC001L29_A830NotaFiscalItemId
               }
               , new Object[] {
               BC001L30_A572PropostaContratoAssinaturaId
               }
               , new Object[] {
               BC001L31_A414PropostaDocumentosId
               }
               , new Object[] {
               BC001L32_A336AprovacaoId
               }
               , new Object[] {
               BC001L35_A323PropostaId, BC001L35_A327PropostaCreatedAt, BC001L35_n327PropostaCreatedAt, BC001L35_A324PropostaTitulo, BC001L35_n324PropostaTitulo, BC001L35_A325PropostaDescricao, BC001L35_n325PropostaDescricao, BC001L35_A326PropostaValor, BC001L35_n326PropostaValor, BC001L35_A329PropostaStatus,
               BC001L35_n329PropostaStatus, BC001L35_A228ContratoNome, BC001L35_n228ContratoNome, BC001L35_A330PropostaQuantidadeAprovadores, BC001L35_n330PropostaQuantidadeAprovadores, BC001L35_A345PropostaReprovacoesPermitidas, BC001L35_n345PropostaReprovacoesPermitidas, BC001L35_A505PropostaPacienteClienteRazaoSocial, BC001L35_n505PropostaPacienteClienteRazaoSocial, BC001L35_A227ContratoId,
               BC001L35_n227ContratoId, BC001L35_A376ProcedimentosMedicosId, BC001L35_n376ProcedimentosMedicosId, BC001L35_A328PropostaCratedBy, BC001L35_n328PropostaCratedBy, BC001L35_A504PropostaPacienteClienteId, BC001L35_n504PropostaPacienteClienteId, BC001L35_A341PropostaAprovacoes_F, BC001L35_n341PropostaAprovacoes_F, BC001L35_A342PropostaReprovacoes_F,
               BC001L35_n342PropostaReprovacoes_F
               }
            }
         );
         AV30Pgmname = "PropostaC_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121L2 ();
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
      private bool Gx_longc ;
      private string Z324PropostaTitulo ;
      private string A324PropostaTitulo ;
      private string Z325PropostaDescricao ;
      private string A325PropostaDescricao ;
      private string Z329PropostaStatus ;
      private string A329PropostaStatus ;
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
      private int[] BC001L14_A323PropostaId ;
      private bool[] BC001L14_n323PropostaId ;
      private DateTime[] BC001L14_A327PropostaCreatedAt ;
      private bool[] BC001L14_n327PropostaCreatedAt ;
      private string[] BC001L14_A324PropostaTitulo ;
      private bool[] BC001L14_n324PropostaTitulo ;
      private string[] BC001L14_A325PropostaDescricao ;
      private bool[] BC001L14_n325PropostaDescricao ;
      private decimal[] BC001L14_A326PropostaValor ;
      private bool[] BC001L14_n326PropostaValor ;
      private string[] BC001L14_A329PropostaStatus ;
      private bool[] BC001L14_n329PropostaStatus ;
      private string[] BC001L14_A228ContratoNome ;
      private bool[] BC001L14_n228ContratoNome ;
      private short[] BC001L14_A330PropostaQuantidadeAprovadores ;
      private bool[] BC001L14_n330PropostaQuantidadeAprovadores ;
      private short[] BC001L14_A345PropostaReprovacoesPermitidas ;
      private bool[] BC001L14_n345PropostaReprovacoesPermitidas ;
      private string[] BC001L14_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] BC001L14_n505PropostaPacienteClienteRazaoSocial ;
      private int[] BC001L14_A227ContratoId ;
      private bool[] BC001L14_n227ContratoId ;
      private int[] BC001L14_A376ProcedimentosMedicosId ;
      private bool[] BC001L14_n376ProcedimentosMedicosId ;
      private short[] BC001L14_A328PropostaCratedBy ;
      private bool[] BC001L14_n328PropostaCratedBy ;
      private int[] BC001L14_A504PropostaPacienteClienteId ;
      private bool[] BC001L14_n504PropostaPacienteClienteId ;
      private short[] BC001L14_A341PropostaAprovacoes_F ;
      private bool[] BC001L14_n341PropostaAprovacoes_F ;
      private short[] BC001L14_A342PropostaReprovacoes_F ;
      private bool[] BC001L14_n342PropostaReprovacoes_F ;
      private short[] BC001L9_A341PropostaAprovacoes_F ;
      private bool[] BC001L9_n341PropostaAprovacoes_F ;
      private short[] BC001L11_A342PropostaReprovacoes_F ;
      private bool[] BC001L11_n342PropostaReprovacoes_F ;
      private int[] BC001L5_A376ProcedimentosMedicosId ;
      private bool[] BC001L5_n376ProcedimentosMedicosId ;
      private short[] BC001L6_A328PropostaCratedBy ;
      private bool[] BC001L6_n328PropostaCratedBy ;
      private string[] BC001L4_A228ContratoNome ;
      private bool[] BC001L4_n228ContratoNome ;
      private string[] BC001L7_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] BC001L7_n505PropostaPacienteClienteRazaoSocial ;
      private int[] BC001L15_A323PropostaId ;
      private bool[] BC001L15_n323PropostaId ;
      private int[] BC001L3_A323PropostaId ;
      private bool[] BC001L3_n323PropostaId ;
      private DateTime[] BC001L3_A327PropostaCreatedAt ;
      private bool[] BC001L3_n327PropostaCreatedAt ;
      private string[] BC001L3_A324PropostaTitulo ;
      private bool[] BC001L3_n324PropostaTitulo ;
      private string[] BC001L3_A325PropostaDescricao ;
      private bool[] BC001L3_n325PropostaDescricao ;
      private decimal[] BC001L3_A326PropostaValor ;
      private bool[] BC001L3_n326PropostaValor ;
      private string[] BC001L3_A329PropostaStatus ;
      private bool[] BC001L3_n329PropostaStatus ;
      private short[] BC001L3_A330PropostaQuantidadeAprovadores ;
      private bool[] BC001L3_n330PropostaQuantidadeAprovadores ;
      private short[] BC001L3_A345PropostaReprovacoesPermitidas ;
      private bool[] BC001L3_n345PropostaReprovacoesPermitidas ;
      private int[] BC001L3_A227ContratoId ;
      private bool[] BC001L3_n227ContratoId ;
      private int[] BC001L3_A376ProcedimentosMedicosId ;
      private bool[] BC001L3_n376ProcedimentosMedicosId ;
      private short[] BC001L3_A328PropostaCratedBy ;
      private bool[] BC001L3_n328PropostaCratedBy ;
      private int[] BC001L3_A504PropostaPacienteClienteId ;
      private bool[] BC001L3_n504PropostaPacienteClienteId ;
      private int[] BC001L2_A323PropostaId ;
      private bool[] BC001L2_n323PropostaId ;
      private DateTime[] BC001L2_A327PropostaCreatedAt ;
      private bool[] BC001L2_n327PropostaCreatedAt ;
      private string[] BC001L2_A324PropostaTitulo ;
      private bool[] BC001L2_n324PropostaTitulo ;
      private string[] BC001L2_A325PropostaDescricao ;
      private bool[] BC001L2_n325PropostaDescricao ;
      private decimal[] BC001L2_A326PropostaValor ;
      private bool[] BC001L2_n326PropostaValor ;
      private string[] BC001L2_A329PropostaStatus ;
      private bool[] BC001L2_n329PropostaStatus ;
      private short[] BC001L2_A330PropostaQuantidadeAprovadores ;
      private bool[] BC001L2_n330PropostaQuantidadeAprovadores ;
      private short[] BC001L2_A345PropostaReprovacoesPermitidas ;
      private bool[] BC001L2_n345PropostaReprovacoesPermitidas ;
      private int[] BC001L2_A227ContratoId ;
      private bool[] BC001L2_n227ContratoId ;
      private int[] BC001L2_A376ProcedimentosMedicosId ;
      private bool[] BC001L2_n376ProcedimentosMedicosId ;
      private short[] BC001L2_A328PropostaCratedBy ;
      private bool[] BC001L2_n328PropostaCratedBy ;
      private int[] BC001L2_A504PropostaPacienteClienteId ;
      private bool[] BC001L2_n504PropostaPacienteClienteId ;
      private int[] BC001L17_A323PropostaId ;
      private bool[] BC001L17_n323PropostaId ;
      private short[] BC001L21_A341PropostaAprovacoes_F ;
      private bool[] BC001L21_n341PropostaAprovacoes_F ;
      private short[] BC001L23_A342PropostaReprovacoes_F ;
      private bool[] BC001L23_n342PropostaReprovacoes_F ;
      private string[] BC001L24_A228ContratoNome ;
      private bool[] BC001L24_n228ContratoNome ;
      private string[] BC001L25_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] BC001L25_n505PropostaPacienteClienteRazaoSocial ;
      private int[] BC001L26_A227ContratoId ;
      private bool[] BC001L26_n227ContratoId ;
      private int[] BC001L27_A518ReembolsoId ;
      private int[] BC001L28_A261TituloId ;
      private Guid[] BC001L29_A830NotaFiscalItemId ;
      private int[] BC001L30_A572PropostaContratoAssinaturaId ;
      private int[] BC001L31_A414PropostaDocumentosId ;
      private int[] BC001L32_A336AprovacaoId ;
      private int[] BC001L35_A323PropostaId ;
      private bool[] BC001L35_n323PropostaId ;
      private DateTime[] BC001L35_A327PropostaCreatedAt ;
      private bool[] BC001L35_n327PropostaCreatedAt ;
      private string[] BC001L35_A324PropostaTitulo ;
      private bool[] BC001L35_n324PropostaTitulo ;
      private string[] BC001L35_A325PropostaDescricao ;
      private bool[] BC001L35_n325PropostaDescricao ;
      private decimal[] BC001L35_A326PropostaValor ;
      private bool[] BC001L35_n326PropostaValor ;
      private string[] BC001L35_A329PropostaStatus ;
      private bool[] BC001L35_n329PropostaStatus ;
      private string[] BC001L35_A228ContratoNome ;
      private bool[] BC001L35_n228ContratoNome ;
      private short[] BC001L35_A330PropostaQuantidadeAprovadores ;
      private bool[] BC001L35_n330PropostaQuantidadeAprovadores ;
      private short[] BC001L35_A345PropostaReprovacoesPermitidas ;
      private bool[] BC001L35_n345PropostaReprovacoesPermitidas ;
      private string[] BC001L35_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] BC001L35_n505PropostaPacienteClienteRazaoSocial ;
      private int[] BC001L35_A227ContratoId ;
      private bool[] BC001L35_n227ContratoId ;
      private int[] BC001L35_A376ProcedimentosMedicosId ;
      private bool[] BC001L35_n376ProcedimentosMedicosId ;
      private short[] BC001L35_A328PropostaCratedBy ;
      private bool[] BC001L35_n328PropostaCratedBy ;
      private int[] BC001L35_A504PropostaPacienteClienteId ;
      private bool[] BC001L35_n504PropostaPacienteClienteId ;
      private short[] BC001L35_A341PropostaAprovacoes_F ;
      private bool[] BC001L35_n341PropostaAprovacoes_F ;
      private short[] BC001L35_A342PropostaReprovacoes_F ;
      private bool[] BC001L35_n342PropostaReprovacoes_F ;
      private SdtPropostaC bcPropostaC ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class propostac_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC001L2;
          prmBC001L2 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001L3;
          prmBC001L3 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001L4;
          prmBC001L4 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC001L5;
          prmBC001L5 = new Object[] {
          new ParDef("ProcedimentosMedicosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001L6;
          prmBC001L6 = new Object[] {
          new ParDef("PropostaCratedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC001L7;
          prmBC001L7 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001L9;
          prmBC001L9 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001L11;
          prmBC001L11 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001L14;
          prmBC001L14 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001L15;
          prmBC001L15 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001L16;
          prmBC001L16 = new Object[] {
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
          Object[] prmBC001L17;
          prmBC001L17 = new Object[] {
          };
          Object[] prmBC001L18;
          prmBC001L18 = new Object[] {
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
          Object[] prmBC001L19;
          prmBC001L19 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001L21;
          prmBC001L21 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001L23;
          prmBC001L23 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001L24;
          prmBC001L24 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC001L25;
          prmBC001L25 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001L26;
          prmBC001L26 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001L27;
          prmBC001L27 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001L28;
          prmBC001L28 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001L29;
          prmBC001L29 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001L30;
          prmBC001L30 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001L31;
          prmBC001L31 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001L32;
          prmBC001L32 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001L35;
          prmBC001L35 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC001L2", "SELECT PropostaId, PropostaCreatedAt, PropostaTitulo, PropostaDescricao, PropostaValor, PropostaStatus, PropostaQuantidadeAprovadores, PropostaReprovacoesPermitidas, ContratoId, ProcedimentosMedicosId, PropostaCratedBy, PropostaPacienteClienteId FROM Proposta WHERE PropostaId = :PropostaId  FOR UPDATE OF Proposta",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001L3", "SELECT PropostaId, PropostaCreatedAt, PropostaTitulo, PropostaDescricao, PropostaValor, PropostaStatus, PropostaQuantidadeAprovadores, PropostaReprovacoesPermitidas, ContratoId, ProcedimentosMedicosId, PropostaCratedBy, PropostaPacienteClienteId FROM Proposta WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001L4", "SELECT ContratoNome FROM Contrato WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001L5", "SELECT ProcedimentosMedicosId FROM ProcedimentosMedicos WHERE ProcedimentosMedicosId = :ProcedimentosMedicosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001L6", "SELECT SecUserId AS PropostaCratedBy FROM SecUser WHERE SecUserId = :PropostaCratedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001L7", "SELECT ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial FROM Cliente WHERE ClienteId = :PropostaPacienteClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001L9", "SELECT COALESCE( T1.PropostaAprovacoes_F, 0) AS PropostaAprovacoes_F FROM (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE AprovacaoStatus = ( 'APROVADO') GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001L11", "SELECT COALESCE( T1.PropostaAprovacoes_F, 0) AS PropostaReprovacoes_F FROM (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE AprovacaoStatus = ( 'REPROVADO') GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001L14", "SELECT TM1.PropostaId, TM1.PropostaCreatedAt, TM1.PropostaTitulo, TM1.PropostaDescricao, TM1.PropostaValor, TM1.PropostaStatus, T4.ContratoNome, TM1.PropostaQuantidadeAprovadores, TM1.PropostaReprovacoesPermitidas, T5.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, TM1.ContratoId, TM1.ProcedimentosMedicosId, TM1.PropostaCratedBy AS PropostaCratedBy, TM1.PropostaPacienteClienteId AS PropostaPacienteClienteId, COALESCE( T2.PropostaAprovacoes_F, 0) AS PropostaAprovacoes_F, COALESCE( T3.PropostaAprovacoes_F, 0) AS PropostaReprovacoes_F FROM ((((Proposta TM1 LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE (TM1.PropostaId = PropostaId) AND (AprovacaoStatus = ( 'APROVADO')) GROUP BY PropostaId ) T2 ON T2.PropostaId = TM1.PropostaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE (TM1.PropostaId = PropostaId) AND (AprovacaoStatus = ( 'REPROVADO')) GROUP BY PropostaId ) T3 ON T3.PropostaId = TM1.PropostaId) LEFT JOIN Contrato T4 ON T4.ContratoId = TM1.ContratoId) LEFT JOIN Cliente T5 ON T5.ClienteId = TM1.PropostaPacienteClienteId) WHERE TM1.PropostaId = :PropostaId ORDER BY TM1.PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L14,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001L15", "SELECT PropostaId FROM Proposta WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001L16", "SAVEPOINT gxupdate;INSERT INTO Proposta(PropostaCreatedAt, PropostaTitulo, PropostaDescricao, PropostaValor, PropostaStatus, PropostaQuantidadeAprovadores, PropostaReprovacoesPermitidas, ContratoId, ProcedimentosMedicosId, PropostaCratedBy, PropostaPacienteClienteId, ConvenioVencimentoAno, ConvenioVencimentoMes, ConvenioCategoriaId, PropostaTaxaAdministrativa, PropostaSLA, PropostaJurosMora, PropostaDataCirurgia, PropostaResponsavelId, PropostaClinicaId, PropostaComentarioAnalise, PropostaProtocolo, PropostaEmpresaClienteId, PropostaTipoProposta, PropostaValorLiquido) VALUES(:PropostaCreatedAt, :PropostaTitulo, :PropostaDescricao, :PropostaValor, :PropostaStatus, :PropostaQuantidadeAprovadores, :PropostaReprovacoesPermitidas, :ContratoId, :ProcedimentosMedicosId, :PropostaCratedBy, :PropostaPacienteClienteId, 0, 0, 0, 0, 0, 0, DATE '00010101', 0, 0, '', '', 0, '', 0);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001L16)
             ,new CursorDef("BC001L17", "SELECT currval('PropostaId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L17,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001L18", "SAVEPOINT gxupdate;UPDATE Proposta SET PropostaCreatedAt=:PropostaCreatedAt, PropostaTitulo=:PropostaTitulo, PropostaDescricao=:PropostaDescricao, PropostaValor=:PropostaValor, PropostaStatus=:PropostaStatus, PropostaQuantidadeAprovadores=:PropostaQuantidadeAprovadores, PropostaReprovacoesPermitidas=:PropostaReprovacoesPermitidas, ContratoId=:ContratoId, ProcedimentosMedicosId=:ProcedimentosMedicosId, PropostaCratedBy=:PropostaCratedBy, PropostaPacienteClienteId=:PropostaPacienteClienteId  WHERE PropostaId = :PropostaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001L18)
             ,new CursorDef("BC001L19", "SAVEPOINT gxupdate;DELETE FROM Proposta  WHERE PropostaId = :PropostaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001L19)
             ,new CursorDef("BC001L21", "SELECT COALESCE( T1.PropostaAprovacoes_F, 0) AS PropostaAprovacoes_F FROM (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE AprovacaoStatus = ( 'APROVADO') GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L21,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001L23", "SELECT COALESCE( T1.PropostaAprovacoes_F, 0) AS PropostaReprovacoes_F FROM (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE AprovacaoStatus = ( 'REPROVADO') GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L23,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001L24", "SELECT ContratoNome FROM Contrato WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L24,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001L25", "SELECT ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial FROM Cliente WHERE ClienteId = :PropostaPacienteClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L25,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001L26", "SELECT ContratoId FROM Contrato WHERE ContratoPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L26,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001L27", "SELECT ReembolsoId FROM Reembolso WHERE ReembolsoPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L27,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001L28", "SELECT TituloId FROM Titulo WHERE TituloPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L28,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001L29", "SELECT NotaFiscalItemId FROM NotaFiscalItem WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L29,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001L30", "SELECT PropostaContratoAssinaturaId FROM PropostaContratoAssinatura WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L30,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001L31", "SELECT PropostaDocumentosId FROM PropostaDocumentos WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L31,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001L32", "SELECT AprovacaoId FROM Aprovacao WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L32,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001L35", "SELECT TM1.PropostaId, TM1.PropostaCreatedAt, TM1.PropostaTitulo, TM1.PropostaDescricao, TM1.PropostaValor, TM1.PropostaStatus, T4.ContratoNome, TM1.PropostaQuantidadeAprovadores, TM1.PropostaReprovacoesPermitidas, T5.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, TM1.ContratoId, TM1.ProcedimentosMedicosId, TM1.PropostaCratedBy AS PropostaCratedBy, TM1.PropostaPacienteClienteId AS PropostaPacienteClienteId, COALESCE( T2.PropostaAprovacoes_F, 0) AS PropostaAprovacoes_F, COALESCE( T3.PropostaAprovacoes_F, 0) AS PropostaReprovacoes_F FROM ((((Proposta TM1 LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE (TM1.PropostaId = PropostaId) AND (AprovacaoStatus = ( 'APROVADO')) GROUP BY PropostaId ) T2 ON T2.PropostaId = TM1.PropostaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE (TM1.PropostaId = PropostaId) AND (AprovacaoStatus = ( 'REPROVADO')) GROUP BY PropostaId ) T3 ON T3.PropostaId = TM1.PropostaId) LEFT JOIN Contrato T4 ON T4.ContratoId = TM1.ContratoId) LEFT JOIN Cliente T5 ON T5.ClienteId = TM1.PropostaPacienteClienteId) WHERE TM1.PropostaId = :PropostaId ORDER BY TM1.PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001L35,100, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 18 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 19 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 20 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 21 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 22 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 23 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 24 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 25 :
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
                return;
       }
    }

 }

}
