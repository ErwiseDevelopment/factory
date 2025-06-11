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
   public class reembolso_bc : GxSilentTrn, IGxSilentTrn
   {
      public reembolso_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public reembolso_bc( IGxContext context )
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
         ReadRow1Y71( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1Y71( ) ;
         standaloneModal( ) ;
         AddRow1Y71( ) ;
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
            E111Y2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z518ReembolsoId = A518ReembolsoId;
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

      protected void CONFIRM_1Y0( )
      {
         BeforeValidate1Y71( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1Y71( ) ;
            }
            else
            {
               CheckExtendedTable1Y71( ) ;
               if ( AnyError == 0 )
               {
                  ZM1Y71( 11) ;
                  ZM1Y71( 12) ;
                  ZM1Y71( 13) ;
                  ZM1Y71( 14) ;
                  ZM1Y71( 15) ;
                  ZM1Y71( 16) ;
                  ZM1Y71( 17) ;
               }
               CloseExtendedTableCursors1Y71( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E121Y2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV26Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV27GXV1 = 1;
            while ( AV27GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV27GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "ReembolsoPropostaId") == 0 )
               {
                  AV11Insert_ReembolsoPropostaId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "ReembolsoCreatedBy") == 0 )
               {
                  AV12Insert_ReembolsoCreatedBy = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "WorkflowConvenioId") == 0 )
               {
                  AV24Insert_WorkflowConvenioId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV27GXV1 = (int)(AV27GXV1+1);
            }
         }
      }

      protected void E111Y2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1Y71( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z522ReembolsoCreatedAt = A522ReembolsoCreatedAt;
            Z546ReembolsoProtocolo = A546ReembolsoProtocolo;
            Z525ReembolsoDataAberturaConvenio = A525ReembolsoDataAberturaConvenio;
            Z742WorkflowConvenioId = A742WorkflowConvenioId;
            Z542ReembolsoPropostaId = A542ReembolsoPropostaId;
            Z544ReembolsoCreatedBy = A544ReembolsoCreatedBy;
            Z645ReembolsoValorReembolsado_F = A645ReembolsoValorReembolsado_F;
            Z547ReembolsoEtapaUltimo_F = A547ReembolsoEtapaUltimo_F;
            Z548ReembolsoStatusAtual_F = A548ReembolsoStatusAtual_F;
         }
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z645ReembolsoValorReembolsado_F = A645ReembolsoValorReembolsado_F;
            Z547ReembolsoEtapaUltimo_F = A547ReembolsoEtapaUltimo_F;
            Z548ReembolsoStatusAtual_F = A548ReembolsoStatusAtual_F;
         }
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            Z736WorkflowConvenioDesc = A736WorkflowConvenioDesc;
            Z645ReembolsoValorReembolsado_F = A645ReembolsoValorReembolsado_F;
            Z547ReembolsoEtapaUltimo_F = A547ReembolsoEtapaUltimo_F;
            Z548ReembolsoStatusAtual_F = A548ReembolsoStatusAtual_F;
         }
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            Z543ReembolsoPropostaValor = A543ReembolsoPropostaValor;
            Z558ReembolsoPropostaPacienteClienteId = A558ReembolsoPropostaPacienteClienteId;
            Z758ReembolsoPropostaClinicaId = A758ReembolsoPropostaClinicaId;
            Z645ReembolsoValorReembolsado_F = A645ReembolsoValorReembolsado_F;
            Z547ReembolsoEtapaUltimo_F = A547ReembolsoEtapaUltimo_F;
            Z548ReembolsoStatusAtual_F = A548ReembolsoStatusAtual_F;
         }
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            Z645ReembolsoValorReembolsado_F = A645ReembolsoValorReembolsado_F;
            Z547ReembolsoEtapaUltimo_F = A547ReembolsoEtapaUltimo_F;
            Z548ReembolsoStatusAtual_F = A548ReembolsoStatusAtual_F;
         }
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            Z550ReembolsoPropostaPacienteClienteRazaoSocial = A550ReembolsoPropostaPacienteClienteRazaoSocial;
            Z645ReembolsoValorReembolsado_F = A645ReembolsoValorReembolsado_F;
            Z547ReembolsoEtapaUltimo_F = A547ReembolsoEtapaUltimo_F;
            Z548ReembolsoStatusAtual_F = A548ReembolsoStatusAtual_F;
         }
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            Z645ReembolsoValorReembolsado_F = A645ReembolsoValorReembolsado_F;
            Z547ReembolsoEtapaUltimo_F = A547ReembolsoEtapaUltimo_F;
            Z548ReembolsoStatusAtual_F = A548ReembolsoStatusAtual_F;
         }
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            Z645ReembolsoValorReembolsado_F = A645ReembolsoValorReembolsado_F;
            Z547ReembolsoEtapaUltimo_F = A547ReembolsoEtapaUltimo_F;
            Z548ReembolsoStatusAtual_F = A548ReembolsoStatusAtual_F;
         }
         if ( GX_JID == -10 )
         {
            Z518ReembolsoId = A518ReembolsoId;
            Z522ReembolsoCreatedAt = A522ReembolsoCreatedAt;
            Z546ReembolsoProtocolo = A546ReembolsoProtocolo;
            Z525ReembolsoDataAberturaConvenio = A525ReembolsoDataAberturaConvenio;
            Z742WorkflowConvenioId = A742WorkflowConvenioId;
            Z542ReembolsoPropostaId = A542ReembolsoPropostaId;
            Z544ReembolsoCreatedBy = A544ReembolsoCreatedBy;
            Z645ReembolsoValorReembolsado_F = A645ReembolsoValorReembolsado_F;
            Z547ReembolsoEtapaUltimo_F = A547ReembolsoEtapaUltimo_F;
            Z543ReembolsoPropostaValor = A543ReembolsoPropostaValor;
            Z558ReembolsoPropostaPacienteClienteId = A558ReembolsoPropostaPacienteClienteId;
            Z758ReembolsoPropostaClinicaId = A758ReembolsoPropostaClinicaId;
            Z550ReembolsoPropostaPacienteClienteRazaoSocial = A550ReembolsoPropostaPacienteClienteRazaoSocial;
            Z736WorkflowConvenioDesc = A736WorkflowConvenioDesc;
         }
      }

      protected void standaloneNotModal( )
      {
         AV26Pgmname = "Reembolso_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A522ReembolsoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n522ReembolsoCreatedAt = false;
         }
         else
         {
            if ( IsIns( )  && (DateTime.MinValue==A522ReembolsoCreatedAt) && ( Gx_BScreen == 0 ) )
            {
               A522ReembolsoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
               n522ReembolsoCreatedAt = false;
            }
         }
      }

      protected void Load1Y71( )
      {
         /* Using cursor BC001Y17 */
         pr_default.execute(9, new Object[] {n518ReembolsoId, A518ReembolsoId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound71 = 1;
            A522ReembolsoCreatedAt = BC001Y17_A522ReembolsoCreatedAt[0];
            n522ReembolsoCreatedAt = BC001Y17_n522ReembolsoCreatedAt[0];
            A550ReembolsoPropostaPacienteClienteRazaoSocial = BC001Y17_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            n550ReembolsoPropostaPacienteClienteRazaoSocial = BC001Y17_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            A546ReembolsoProtocolo = BC001Y17_A546ReembolsoProtocolo[0];
            n546ReembolsoProtocolo = BC001Y17_n546ReembolsoProtocolo[0];
            A543ReembolsoPropostaValor = BC001Y17_A543ReembolsoPropostaValor[0];
            n543ReembolsoPropostaValor = BC001Y17_n543ReembolsoPropostaValor[0];
            A525ReembolsoDataAberturaConvenio = BC001Y17_A525ReembolsoDataAberturaConvenio[0];
            n525ReembolsoDataAberturaConvenio = BC001Y17_n525ReembolsoDataAberturaConvenio[0];
            A736WorkflowConvenioDesc = BC001Y17_A736WorkflowConvenioDesc[0];
            n736WorkflowConvenioDesc = BC001Y17_n736WorkflowConvenioDesc[0];
            A742WorkflowConvenioId = BC001Y17_A742WorkflowConvenioId[0];
            n742WorkflowConvenioId = BC001Y17_n742WorkflowConvenioId[0];
            A542ReembolsoPropostaId = BC001Y17_A542ReembolsoPropostaId[0];
            n542ReembolsoPropostaId = BC001Y17_n542ReembolsoPropostaId[0];
            A544ReembolsoCreatedBy = BC001Y17_A544ReembolsoCreatedBy[0];
            n544ReembolsoCreatedBy = BC001Y17_n544ReembolsoCreatedBy[0];
            A558ReembolsoPropostaPacienteClienteId = BC001Y17_A558ReembolsoPropostaPacienteClienteId[0];
            n558ReembolsoPropostaPacienteClienteId = BC001Y17_n558ReembolsoPropostaPacienteClienteId[0];
            A758ReembolsoPropostaClinicaId = BC001Y17_A758ReembolsoPropostaClinicaId[0];
            n758ReembolsoPropostaClinicaId = BC001Y17_n758ReembolsoPropostaClinicaId[0];
            A645ReembolsoValorReembolsado_F = BC001Y17_A645ReembolsoValorReembolsado_F[0];
            n645ReembolsoValorReembolsado_F = BC001Y17_n645ReembolsoValorReembolsado_F[0];
            A547ReembolsoEtapaUltimo_F = BC001Y17_A547ReembolsoEtapaUltimo_F[0];
            n547ReembolsoEtapaUltimo_F = BC001Y17_n547ReembolsoEtapaUltimo_F[0];
            ZM1Y71( -10) ;
         }
         pr_default.close(9);
         OnLoadActions1Y71( ) ;
      }

      protected void OnLoadActions1Y71( )
      {
         if ( (0==A542ReembolsoPropostaId) )
         {
            A542ReembolsoPropostaId = 0;
            n542ReembolsoPropostaId = false;
            n542ReembolsoPropostaId = true;
            n542ReembolsoPropostaId = true;
         }
         if ( (0==A544ReembolsoCreatedBy) )
         {
            A544ReembolsoCreatedBy = 0;
            n544ReembolsoCreatedBy = false;
            n544ReembolsoCreatedBy = true;
            n544ReembolsoCreatedBy = true;
         }
      }

      protected void CheckExtendedTable1Y71( )
      {
         standaloneModal( ) ;
         /* Using cursor BC001Y12 */
         pr_default.execute(7, new Object[] {n518ReembolsoId, A518ReembolsoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            A645ReembolsoValorReembolsado_F = BC001Y12_A645ReembolsoValorReembolsado_F[0];
            n645ReembolsoValorReembolsado_F = BC001Y12_n645ReembolsoValorReembolsado_F[0];
         }
         else
         {
            A645ReembolsoValorReembolsado_F = 0;
            n645ReembolsoValorReembolsado_F = false;
         }
         pr_default.close(7);
         if ( ( A645ReembolsoValorReembolsado_F < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC001Y14 */
         pr_default.execute(8, new Object[] {n518ReembolsoId, A518ReembolsoId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A547ReembolsoEtapaUltimo_F = BC001Y14_A547ReembolsoEtapaUltimo_F[0];
            n547ReembolsoEtapaUltimo_F = BC001Y14_n547ReembolsoEtapaUltimo_F[0];
         }
         else
         {
            A547ReembolsoEtapaUltimo_F = (DateTime)(DateTime.MinValue);
            n547ReembolsoEtapaUltimo_F = false;
         }
         pr_default.close(8);
         if ( (0==A542ReembolsoPropostaId) )
         {
            A542ReembolsoPropostaId = 0;
            n542ReembolsoPropostaId = false;
            n542ReembolsoPropostaId = true;
            n542ReembolsoPropostaId = true;
         }
         /* Using cursor BC001Y8 */
         pr_default.execute(4, new Object[] {n542ReembolsoPropostaId, A542ReembolsoPropostaId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A542ReembolsoPropostaId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Reembolso Proposta'.", "ForeignKeyNotFound", 1, "REEMBOLSOPROPOSTAID");
               AnyError = 1;
            }
         }
         A543ReembolsoPropostaValor = BC001Y8_A543ReembolsoPropostaValor[0];
         n543ReembolsoPropostaValor = BC001Y8_n543ReembolsoPropostaValor[0];
         A558ReembolsoPropostaPacienteClienteId = BC001Y8_A558ReembolsoPropostaPacienteClienteId[0];
         n558ReembolsoPropostaPacienteClienteId = BC001Y8_n558ReembolsoPropostaPacienteClienteId[0];
         A758ReembolsoPropostaClinicaId = BC001Y8_A758ReembolsoPropostaClinicaId[0];
         n758ReembolsoPropostaClinicaId = BC001Y8_n758ReembolsoPropostaClinicaId[0];
         pr_default.close(4);
         if ( ( A543ReembolsoPropostaValor < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC001Y10 */
         pr_default.execute(6, new Object[] {n558ReembolsoPropostaPacienteClienteId, A558ReembolsoPropostaPacienteClienteId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A558ReembolsoPropostaPacienteClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente'.", "ForeignKeyNotFound", 1, "REEMBOLSOPROPOSTAPACIENTECLIENTEID");
               AnyError = 1;
            }
         }
         A550ReembolsoPropostaPacienteClienteRazaoSocial = BC001Y10_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
         n550ReembolsoPropostaPacienteClienteRazaoSocial = BC001Y10_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
         pr_default.close(6);
         if ( (0==A544ReembolsoCreatedBy) )
         {
            A544ReembolsoCreatedBy = 0;
            n544ReembolsoCreatedBy = false;
            n544ReembolsoCreatedBy = true;
            n544ReembolsoCreatedBy = true;
         }
         /* Using cursor BC001Y9 */
         pr_default.execute(5, new Object[] {n544ReembolsoCreatedBy, A544ReembolsoCreatedBy});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A544ReembolsoCreatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Reembolso Usuario'.", "ForeignKeyNotFound", 1, "REEMBOLSOCREATEDBY");
               AnyError = 1;
            }
         }
         pr_default.close(5);
         /* Using cursor BC001Y7 */
         pr_default.execute(3, new Object[] {n742WorkflowConvenioId, A742WorkflowConvenioId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A742WorkflowConvenioId) ) )
            {
               GX_msglist.addItem("Não existe 'WorkflowConvenio'.", "ForeignKeyNotFound", 1, "WORKFLOWCONVENIOID");
               AnyError = 1;
            }
         }
         A736WorkflowConvenioDesc = BC001Y7_A736WorkflowConvenioDesc[0];
         n736WorkflowConvenioDesc = BC001Y7_n736WorkflowConvenioDesc[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors1Y71( )
      {
         pr_default.close(7);
         pr_default.close(8);
         pr_default.close(4);
         pr_default.close(6);
         pr_default.close(5);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1Y71( )
      {
         /* Using cursor BC001Y18 */
         pr_default.execute(10, new Object[] {n518ReembolsoId, A518ReembolsoId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound71 = 1;
         }
         else
         {
            RcdFound71 = 0;
         }
         pr_default.close(10);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001Y3 */
         pr_default.execute(1, new Object[] {n518ReembolsoId, A518ReembolsoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1Y71( 10) ;
            RcdFound71 = 1;
            A518ReembolsoId = BC001Y3_A518ReembolsoId[0];
            n518ReembolsoId = BC001Y3_n518ReembolsoId[0];
            A522ReembolsoCreatedAt = BC001Y3_A522ReembolsoCreatedAt[0];
            n522ReembolsoCreatedAt = BC001Y3_n522ReembolsoCreatedAt[0];
            A546ReembolsoProtocolo = BC001Y3_A546ReembolsoProtocolo[0];
            n546ReembolsoProtocolo = BC001Y3_n546ReembolsoProtocolo[0];
            A525ReembolsoDataAberturaConvenio = BC001Y3_A525ReembolsoDataAberturaConvenio[0];
            n525ReembolsoDataAberturaConvenio = BC001Y3_n525ReembolsoDataAberturaConvenio[0];
            A742WorkflowConvenioId = BC001Y3_A742WorkflowConvenioId[0];
            n742WorkflowConvenioId = BC001Y3_n742WorkflowConvenioId[0];
            A542ReembolsoPropostaId = BC001Y3_A542ReembolsoPropostaId[0];
            n542ReembolsoPropostaId = BC001Y3_n542ReembolsoPropostaId[0];
            A544ReembolsoCreatedBy = BC001Y3_A544ReembolsoCreatedBy[0];
            n544ReembolsoCreatedBy = BC001Y3_n544ReembolsoCreatedBy[0];
            O742WorkflowConvenioId = A742WorkflowConvenioId;
            n742WorkflowConvenioId = false;
            Z518ReembolsoId = A518ReembolsoId;
            sMode71 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1Y71( ) ;
            if ( AnyError == 1 )
            {
               RcdFound71 = 0;
               InitializeNonKey1Y71( ) ;
            }
            Gx_mode = sMode71;
         }
         else
         {
            RcdFound71 = 0;
            InitializeNonKey1Y71( ) ;
            sMode71 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode71;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1Y71( ) ;
         if ( RcdFound71 == 0 )
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
         CONFIRM_1Y0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1Y71( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001Y2 */
            pr_default.execute(0, new Object[] {n518ReembolsoId, A518ReembolsoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Reembolso"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z522ReembolsoCreatedAt != BC001Y2_A522ReembolsoCreatedAt[0] ) || ( StringUtil.StrCmp(Z546ReembolsoProtocolo, BC001Y2_A546ReembolsoProtocolo[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z525ReembolsoDataAberturaConvenio ) != DateTimeUtil.ResetTime ( BC001Y2_A525ReembolsoDataAberturaConvenio[0] ) ) || ( Z742WorkflowConvenioId != BC001Y2_A742WorkflowConvenioId[0] ) || ( Z542ReembolsoPropostaId != BC001Y2_A542ReembolsoPropostaId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z544ReembolsoCreatedBy != BC001Y2_A544ReembolsoCreatedBy[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Reembolso"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1Y71( )
      {
         BeforeValidate1Y71( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Y71( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1Y71( 0) ;
            CheckOptimisticConcurrency1Y71( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Y71( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1Y71( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001Y19 */
                     pr_default.execute(11, new Object[] {n522ReembolsoCreatedAt, A522ReembolsoCreatedAt, n546ReembolsoProtocolo, A546ReembolsoProtocolo, n525ReembolsoDataAberturaConvenio, A525ReembolsoDataAberturaConvenio, n742WorkflowConvenioId, A742WorkflowConvenioId, n542ReembolsoPropostaId, A542ReembolsoPropostaId, n544ReembolsoCreatedBy, A544ReembolsoCreatedBy});
                     pr_default.close(11);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC001Y20 */
                     pr_default.execute(12);
                     A518ReembolsoId = BC001Y20_A518ReembolsoId[0];
                     n518ReembolsoId = BC001Y20_n518ReembolsoId[0];
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Reembolso");
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
               Load1Y71( ) ;
            }
            EndLevel1Y71( ) ;
         }
         CloseExtendedTableCursors1Y71( ) ;
      }

      protected void Update1Y71( )
      {
         BeforeValidate1Y71( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1Y71( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Y71( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1Y71( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1Y71( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001Y21 */
                     pr_default.execute(13, new Object[] {n522ReembolsoCreatedAt, A522ReembolsoCreatedAt, n546ReembolsoProtocolo, A546ReembolsoProtocolo, n525ReembolsoDataAberturaConvenio, A525ReembolsoDataAberturaConvenio, n742WorkflowConvenioId, A742WorkflowConvenioId, n542ReembolsoPropostaId, A542ReembolsoPropostaId, n544ReembolsoCreatedBy, A544ReembolsoCreatedBy, n518ReembolsoId, A518ReembolsoId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Reembolso");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Reembolso"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1Y71( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        if ( A742WorkflowConvenioId != O742WorkflowConvenioId )
                        {
                           new prlogreembolso(context ).execute(  A518ReembolsoId,  A742WorkflowConvenioId,  AV8WWPContext.gxTpr_Userid) ;
                        }
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
            EndLevel1Y71( ) ;
         }
         CloseExtendedTableCursors1Y71( ) ;
      }

      protected void DeferredUpdate1Y71( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1Y71( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1Y71( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1Y71( ) ;
            AfterConfirm1Y71( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1Y71( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001Y22 */
                  pr_default.execute(14, new Object[] {n518ReembolsoId, A518ReembolsoId});
                  pr_default.close(14);
                  pr_default.SmartCacheProvider.SetUpdated("Reembolso");
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
         sMode71 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1Y71( ) ;
         Gx_mode = sMode71;
      }

      protected void OnDeleteControls1Y71( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001Y24 */
            pr_default.execute(15, new Object[] {n518ReembolsoId, A518ReembolsoId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               A645ReembolsoValorReembolsado_F = BC001Y24_A645ReembolsoValorReembolsado_F[0];
               n645ReembolsoValorReembolsado_F = BC001Y24_n645ReembolsoValorReembolsado_F[0];
            }
            else
            {
               A645ReembolsoValorReembolsado_F = 0;
               n645ReembolsoValorReembolsado_F = false;
            }
            pr_default.close(15);
            /* Using cursor BC001Y26 */
            pr_default.execute(16, new Object[] {n518ReembolsoId, A518ReembolsoId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               A547ReembolsoEtapaUltimo_F = BC001Y26_A547ReembolsoEtapaUltimo_F[0];
               n547ReembolsoEtapaUltimo_F = BC001Y26_n547ReembolsoEtapaUltimo_F[0];
            }
            else
            {
               A547ReembolsoEtapaUltimo_F = (DateTime)(DateTime.MinValue);
               n547ReembolsoEtapaUltimo_F = false;
            }
            pr_default.close(16);
            /* Using cursor BC001Y27 */
            pr_default.execute(17, new Object[] {n542ReembolsoPropostaId, A542ReembolsoPropostaId});
            A543ReembolsoPropostaValor = BC001Y27_A543ReembolsoPropostaValor[0];
            n543ReembolsoPropostaValor = BC001Y27_n543ReembolsoPropostaValor[0];
            A558ReembolsoPropostaPacienteClienteId = BC001Y27_A558ReembolsoPropostaPacienteClienteId[0];
            n558ReembolsoPropostaPacienteClienteId = BC001Y27_n558ReembolsoPropostaPacienteClienteId[0];
            A758ReembolsoPropostaClinicaId = BC001Y27_A758ReembolsoPropostaClinicaId[0];
            n758ReembolsoPropostaClinicaId = BC001Y27_n758ReembolsoPropostaClinicaId[0];
            pr_default.close(17);
            /* Using cursor BC001Y28 */
            pr_default.execute(18, new Object[] {n558ReembolsoPropostaPacienteClienteId, A558ReembolsoPropostaPacienteClienteId});
            A550ReembolsoPropostaPacienteClienteRazaoSocial = BC001Y28_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            n550ReembolsoPropostaPacienteClienteRazaoSocial = BC001Y28_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            pr_default.close(18);
            /* Using cursor BC001Y29 */
            pr_default.execute(19, new Object[] {n742WorkflowConvenioId, A742WorkflowConvenioId});
            A736WorkflowConvenioDesc = BC001Y29_A736WorkflowConvenioDesc[0];
            n736WorkflowConvenioDesc = BC001Y29_n736WorkflowConvenioDesc[0];
            pr_default.close(19);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC001Y30 */
            pr_default.execute(20, new Object[] {n518ReembolsoId, A518ReembolsoId});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ReembolsoFlowLog"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor BC001Y31 */
            pr_default.execute(21, new Object[] {n518ReembolsoId, A518ReembolsoId});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ReembolsoParcelas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor BC001Y32 */
            pr_default.execute(22, new Object[] {n518ReembolsoId, A518ReembolsoId});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ReembolsoAssinaturas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor BC001Y33 */
            pr_default.execute(23, new Object[] {n518ReembolsoId, A518ReembolsoId});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ReembolsoEtapa"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
         }
      }

      protected void EndLevel1Y71( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1Y71( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            if ( A742WorkflowConvenioId != O742WorkflowConvenioId )
            {
               new prlogreembolso(context ).execute(  A518ReembolsoId,  A742WorkflowConvenioId,  AV8WWPContext.gxTpr_Userid) ;
            }
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

      public void ScanKeyStart1Y71( )
      {
         /* Scan By routine */
         /* Using cursor BC001Y36 */
         pr_default.execute(24, new Object[] {n518ReembolsoId, A518ReembolsoId});
         RcdFound71 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound71 = 1;
            A518ReembolsoId = BC001Y36_A518ReembolsoId[0];
            n518ReembolsoId = BC001Y36_n518ReembolsoId[0];
            A522ReembolsoCreatedAt = BC001Y36_A522ReembolsoCreatedAt[0];
            n522ReembolsoCreatedAt = BC001Y36_n522ReembolsoCreatedAt[0];
            A550ReembolsoPropostaPacienteClienteRazaoSocial = BC001Y36_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            n550ReembolsoPropostaPacienteClienteRazaoSocial = BC001Y36_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            A546ReembolsoProtocolo = BC001Y36_A546ReembolsoProtocolo[0];
            n546ReembolsoProtocolo = BC001Y36_n546ReembolsoProtocolo[0];
            A543ReembolsoPropostaValor = BC001Y36_A543ReembolsoPropostaValor[0];
            n543ReembolsoPropostaValor = BC001Y36_n543ReembolsoPropostaValor[0];
            A525ReembolsoDataAberturaConvenio = BC001Y36_A525ReembolsoDataAberturaConvenio[0];
            n525ReembolsoDataAberturaConvenio = BC001Y36_n525ReembolsoDataAberturaConvenio[0];
            A736WorkflowConvenioDesc = BC001Y36_A736WorkflowConvenioDesc[0];
            n736WorkflowConvenioDesc = BC001Y36_n736WorkflowConvenioDesc[0];
            A742WorkflowConvenioId = BC001Y36_A742WorkflowConvenioId[0];
            n742WorkflowConvenioId = BC001Y36_n742WorkflowConvenioId[0];
            A542ReembolsoPropostaId = BC001Y36_A542ReembolsoPropostaId[0];
            n542ReembolsoPropostaId = BC001Y36_n542ReembolsoPropostaId[0];
            A544ReembolsoCreatedBy = BC001Y36_A544ReembolsoCreatedBy[0];
            n544ReembolsoCreatedBy = BC001Y36_n544ReembolsoCreatedBy[0];
            A558ReembolsoPropostaPacienteClienteId = BC001Y36_A558ReembolsoPropostaPacienteClienteId[0];
            n558ReembolsoPropostaPacienteClienteId = BC001Y36_n558ReembolsoPropostaPacienteClienteId[0];
            A758ReembolsoPropostaClinicaId = BC001Y36_A758ReembolsoPropostaClinicaId[0];
            n758ReembolsoPropostaClinicaId = BC001Y36_n758ReembolsoPropostaClinicaId[0];
            A645ReembolsoValorReembolsado_F = BC001Y36_A645ReembolsoValorReembolsado_F[0];
            n645ReembolsoValorReembolsado_F = BC001Y36_n645ReembolsoValorReembolsado_F[0];
            A547ReembolsoEtapaUltimo_F = BC001Y36_A547ReembolsoEtapaUltimo_F[0];
            n547ReembolsoEtapaUltimo_F = BC001Y36_n547ReembolsoEtapaUltimo_F[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1Y71( )
      {
         /* Scan next routine */
         pr_default.readNext(24);
         RcdFound71 = 0;
         ScanKeyLoad1Y71( ) ;
      }

      protected void ScanKeyLoad1Y71( )
      {
         sMode71 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound71 = 1;
            A518ReembolsoId = BC001Y36_A518ReembolsoId[0];
            n518ReembolsoId = BC001Y36_n518ReembolsoId[0];
            A522ReembolsoCreatedAt = BC001Y36_A522ReembolsoCreatedAt[0];
            n522ReembolsoCreatedAt = BC001Y36_n522ReembolsoCreatedAt[0];
            A550ReembolsoPropostaPacienteClienteRazaoSocial = BC001Y36_A550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            n550ReembolsoPropostaPacienteClienteRazaoSocial = BC001Y36_n550ReembolsoPropostaPacienteClienteRazaoSocial[0];
            A546ReembolsoProtocolo = BC001Y36_A546ReembolsoProtocolo[0];
            n546ReembolsoProtocolo = BC001Y36_n546ReembolsoProtocolo[0];
            A543ReembolsoPropostaValor = BC001Y36_A543ReembolsoPropostaValor[0];
            n543ReembolsoPropostaValor = BC001Y36_n543ReembolsoPropostaValor[0];
            A525ReembolsoDataAberturaConvenio = BC001Y36_A525ReembolsoDataAberturaConvenio[0];
            n525ReembolsoDataAberturaConvenio = BC001Y36_n525ReembolsoDataAberturaConvenio[0];
            A736WorkflowConvenioDesc = BC001Y36_A736WorkflowConvenioDesc[0];
            n736WorkflowConvenioDesc = BC001Y36_n736WorkflowConvenioDesc[0];
            A742WorkflowConvenioId = BC001Y36_A742WorkflowConvenioId[0];
            n742WorkflowConvenioId = BC001Y36_n742WorkflowConvenioId[0];
            A542ReembolsoPropostaId = BC001Y36_A542ReembolsoPropostaId[0];
            n542ReembolsoPropostaId = BC001Y36_n542ReembolsoPropostaId[0];
            A544ReembolsoCreatedBy = BC001Y36_A544ReembolsoCreatedBy[0];
            n544ReembolsoCreatedBy = BC001Y36_n544ReembolsoCreatedBy[0];
            A558ReembolsoPropostaPacienteClienteId = BC001Y36_A558ReembolsoPropostaPacienteClienteId[0];
            n558ReembolsoPropostaPacienteClienteId = BC001Y36_n558ReembolsoPropostaPacienteClienteId[0];
            A758ReembolsoPropostaClinicaId = BC001Y36_A758ReembolsoPropostaClinicaId[0];
            n758ReembolsoPropostaClinicaId = BC001Y36_n758ReembolsoPropostaClinicaId[0];
            A645ReembolsoValorReembolsado_F = BC001Y36_A645ReembolsoValorReembolsado_F[0];
            n645ReembolsoValorReembolsado_F = BC001Y36_n645ReembolsoValorReembolsado_F[0];
            A547ReembolsoEtapaUltimo_F = BC001Y36_A547ReembolsoEtapaUltimo_F[0];
            n547ReembolsoEtapaUltimo_F = BC001Y36_n547ReembolsoEtapaUltimo_F[0];
         }
         Gx_mode = sMode71;
      }

      protected void ScanKeyEnd1Y71( )
      {
         pr_default.close(24);
      }

      protected void AfterConfirm1Y71( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1Y71( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1Y71( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1Y71( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1Y71( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1Y71( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1Y71( )
      {
      }

      protected void send_integrity_lvl_hashes1Y71( )
      {
      }

      protected void AddRow1Y71( )
      {
         VarsToRow71( bcReembolso) ;
      }

      protected void ReadRow1Y71( )
      {
         RowToVars71( bcReembolso, 1) ;
      }

      protected void InitializeNonKey1Y71( )
      {
         A522ReembolsoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n522ReembolsoCreatedAt = false;
         A548ReembolsoStatusAtual_F = "";
         n548ReembolsoStatusAtual_F = false;
         A542ReembolsoPropostaId = 0;
         n542ReembolsoPropostaId = false;
         A550ReembolsoPropostaPacienteClienteRazaoSocial = "";
         n550ReembolsoPropostaPacienteClienteRazaoSocial = false;
         A558ReembolsoPropostaPacienteClienteId = 0;
         n558ReembolsoPropostaPacienteClienteId = false;
         A758ReembolsoPropostaClinicaId = 0;
         n758ReembolsoPropostaClinicaId = false;
         A546ReembolsoProtocolo = "";
         n546ReembolsoProtocolo = false;
         A645ReembolsoValorReembolsado_F = 0;
         n645ReembolsoValorReembolsado_F = false;
         A543ReembolsoPropostaValor = 0;
         n543ReembolsoPropostaValor = false;
         A525ReembolsoDataAberturaConvenio = DateTime.MinValue;
         n525ReembolsoDataAberturaConvenio = false;
         A544ReembolsoCreatedBy = 0;
         n544ReembolsoCreatedBy = false;
         A547ReembolsoEtapaUltimo_F = (DateTime)(DateTime.MinValue);
         n547ReembolsoEtapaUltimo_F = false;
         A742WorkflowConvenioId = 0;
         n742WorkflowConvenioId = false;
         A736WorkflowConvenioDesc = "";
         n736WorkflowConvenioDesc = false;
         O742WorkflowConvenioId = A742WorkflowConvenioId;
         n742WorkflowConvenioId = false;
         Z522ReembolsoCreatedAt = (DateTime)(DateTime.MinValue);
         Z546ReembolsoProtocolo = "";
         Z525ReembolsoDataAberturaConvenio = DateTime.MinValue;
         Z742WorkflowConvenioId = 0;
         Z542ReembolsoPropostaId = 0;
         Z544ReembolsoCreatedBy = 0;
      }

      protected void InitAll1Y71( )
      {
         A518ReembolsoId = 0;
         n518ReembolsoId = false;
         InitializeNonKey1Y71( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A522ReembolsoCreatedAt = i522ReembolsoCreatedAt;
         n522ReembolsoCreatedAt = false;
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

      public void VarsToRow71( SdtReembolso obj71 )
      {
         obj71.gxTpr_Mode = Gx_mode;
         obj71.gxTpr_Reembolsocreatedat = A522ReembolsoCreatedAt;
         obj71.gxTpr_Reembolsostatusatual_f = A548ReembolsoStatusAtual_F;
         obj71.gxTpr_Reembolsopropostaid = A542ReembolsoPropostaId;
         obj71.gxTpr_Reembolsopropostapacienteclienterazaosocial = A550ReembolsoPropostaPacienteClienteRazaoSocial;
         obj71.gxTpr_Reembolsopropostapacienteclienteid = A558ReembolsoPropostaPacienteClienteId;
         obj71.gxTpr_Reembolsopropostaclinicaid = A758ReembolsoPropostaClinicaId;
         obj71.gxTpr_Reembolsoprotocolo = A546ReembolsoProtocolo;
         obj71.gxTpr_Reembolsovalorreembolsado_f = A645ReembolsoValorReembolsado_F;
         obj71.gxTpr_Reembolsopropostavalor = A543ReembolsoPropostaValor;
         obj71.gxTpr_Reembolsodataaberturaconvenio = A525ReembolsoDataAberturaConvenio;
         obj71.gxTpr_Reembolsocreatedby = A544ReembolsoCreatedBy;
         obj71.gxTpr_Reembolsoetapaultimo_f = A547ReembolsoEtapaUltimo_F;
         obj71.gxTpr_Workflowconvenioid = A742WorkflowConvenioId;
         obj71.gxTpr_Workflowconveniodesc = A736WorkflowConvenioDesc;
         obj71.gxTpr_Reembolsoid = A518ReembolsoId;
         obj71.gxTpr_Reembolsoid_Z = Z518ReembolsoId;
         obj71.gxTpr_Reembolsopropostaid_Z = Z542ReembolsoPropostaId;
         obj71.gxTpr_Reembolsopropostapacienteclienterazaosocial_Z = Z550ReembolsoPropostaPacienteClienteRazaoSocial;
         obj71.gxTpr_Reembolsopropostapacienteclienteid_Z = Z558ReembolsoPropostaPacienteClienteId;
         obj71.gxTpr_Reembolsopropostaclinicaid_Z = Z758ReembolsoPropostaClinicaId;
         obj71.gxTpr_Reembolsoprotocolo_Z = Z546ReembolsoProtocolo;
         obj71.gxTpr_Reembolsovalorreembolsado_f_Z = Z645ReembolsoValorReembolsado_F;
         obj71.gxTpr_Reembolsocreatedat_Z = Z522ReembolsoCreatedAt;
         obj71.gxTpr_Reembolsopropostavalor_Z = Z543ReembolsoPropostaValor;
         obj71.gxTpr_Reembolsodataaberturaconvenio_Z = Z525ReembolsoDataAberturaConvenio;
         obj71.gxTpr_Reembolsocreatedby_Z = Z544ReembolsoCreatedBy;
         obj71.gxTpr_Reembolsoetapaultimo_f_Z = Z547ReembolsoEtapaUltimo_F;
         obj71.gxTpr_Reembolsostatusatual_f_Z = Z548ReembolsoStatusAtual_F;
         obj71.gxTpr_Workflowconvenioid_Z = Z742WorkflowConvenioId;
         obj71.gxTpr_Workflowconveniodesc_Z = Z736WorkflowConvenioDesc;
         obj71.gxTpr_Reembolsoid_N = (short)(Convert.ToInt16(n518ReembolsoId));
         obj71.gxTpr_Reembolsopropostaid_N = (short)(Convert.ToInt16(n542ReembolsoPropostaId));
         obj71.gxTpr_Reembolsopropostapacienteclienterazaosocial_N = (short)(Convert.ToInt16(n550ReembolsoPropostaPacienteClienteRazaoSocial));
         obj71.gxTpr_Reembolsopropostapacienteclienteid_N = (short)(Convert.ToInt16(n558ReembolsoPropostaPacienteClienteId));
         obj71.gxTpr_Reembolsopropostaclinicaid_N = (short)(Convert.ToInt16(n758ReembolsoPropostaClinicaId));
         obj71.gxTpr_Reembolsoprotocolo_N = (short)(Convert.ToInt16(n546ReembolsoProtocolo));
         obj71.gxTpr_Reembolsovalorreembolsado_f_N = (short)(Convert.ToInt16(n645ReembolsoValorReembolsado_F));
         obj71.gxTpr_Reembolsocreatedat_N = (short)(Convert.ToInt16(n522ReembolsoCreatedAt));
         obj71.gxTpr_Reembolsopropostavalor_N = (short)(Convert.ToInt16(n543ReembolsoPropostaValor));
         obj71.gxTpr_Reembolsodataaberturaconvenio_N = (short)(Convert.ToInt16(n525ReembolsoDataAberturaConvenio));
         obj71.gxTpr_Reembolsocreatedby_N = (short)(Convert.ToInt16(n544ReembolsoCreatedBy));
         obj71.gxTpr_Reembolsoetapaultimo_f_N = (short)(Convert.ToInt16(n547ReembolsoEtapaUltimo_F));
         obj71.gxTpr_Reembolsostatusatual_f_N = (short)(Convert.ToInt16(n548ReembolsoStatusAtual_F));
         obj71.gxTpr_Workflowconvenioid_N = (short)(Convert.ToInt16(n742WorkflowConvenioId));
         obj71.gxTpr_Workflowconveniodesc_N = (short)(Convert.ToInt16(n736WorkflowConvenioDesc));
         obj71.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow71( SdtReembolso obj71 )
      {
         obj71.gxTpr_Reembolsoid = A518ReembolsoId;
         return  ;
      }

      public void RowToVars71( SdtReembolso obj71 ,
                               int forceLoad )
      {
         Gx_mode = obj71.gxTpr_Mode;
         A522ReembolsoCreatedAt = obj71.gxTpr_Reembolsocreatedat;
         n522ReembolsoCreatedAt = false;
         A548ReembolsoStatusAtual_F = obj71.gxTpr_Reembolsostatusatual_f;
         n548ReembolsoStatusAtual_F = false;
         A542ReembolsoPropostaId = obj71.gxTpr_Reembolsopropostaid;
         n542ReembolsoPropostaId = false;
         A550ReembolsoPropostaPacienteClienteRazaoSocial = obj71.gxTpr_Reembolsopropostapacienteclienterazaosocial;
         n550ReembolsoPropostaPacienteClienteRazaoSocial = false;
         A558ReembolsoPropostaPacienteClienteId = obj71.gxTpr_Reembolsopropostapacienteclienteid;
         n558ReembolsoPropostaPacienteClienteId = false;
         A758ReembolsoPropostaClinicaId = obj71.gxTpr_Reembolsopropostaclinicaid;
         n758ReembolsoPropostaClinicaId = false;
         A546ReembolsoProtocolo = obj71.gxTpr_Reembolsoprotocolo;
         n546ReembolsoProtocolo = false;
         A645ReembolsoValorReembolsado_F = obj71.gxTpr_Reembolsovalorreembolsado_f;
         n645ReembolsoValorReembolsado_F = false;
         A543ReembolsoPropostaValor = obj71.gxTpr_Reembolsopropostavalor;
         n543ReembolsoPropostaValor = false;
         A525ReembolsoDataAberturaConvenio = obj71.gxTpr_Reembolsodataaberturaconvenio;
         n525ReembolsoDataAberturaConvenio = false;
         A544ReembolsoCreatedBy = obj71.gxTpr_Reembolsocreatedby;
         n544ReembolsoCreatedBy = false;
         A547ReembolsoEtapaUltimo_F = obj71.gxTpr_Reembolsoetapaultimo_f;
         n547ReembolsoEtapaUltimo_F = false;
         A742WorkflowConvenioId = obj71.gxTpr_Workflowconvenioid;
         n742WorkflowConvenioId = false;
         A736WorkflowConvenioDesc = obj71.gxTpr_Workflowconveniodesc;
         n736WorkflowConvenioDesc = false;
         A518ReembolsoId = obj71.gxTpr_Reembolsoid;
         n518ReembolsoId = false;
         Z518ReembolsoId = obj71.gxTpr_Reembolsoid_Z;
         Z542ReembolsoPropostaId = obj71.gxTpr_Reembolsopropostaid_Z;
         Z550ReembolsoPropostaPacienteClienteRazaoSocial = obj71.gxTpr_Reembolsopropostapacienteclienterazaosocial_Z;
         Z558ReembolsoPropostaPacienteClienteId = obj71.gxTpr_Reembolsopropostapacienteclienteid_Z;
         Z758ReembolsoPropostaClinicaId = obj71.gxTpr_Reembolsopropostaclinicaid_Z;
         Z546ReembolsoProtocolo = obj71.gxTpr_Reembolsoprotocolo_Z;
         Z645ReembolsoValorReembolsado_F = obj71.gxTpr_Reembolsovalorreembolsado_f_Z;
         Z522ReembolsoCreatedAt = obj71.gxTpr_Reembolsocreatedat_Z;
         Z543ReembolsoPropostaValor = obj71.gxTpr_Reembolsopropostavalor_Z;
         Z525ReembolsoDataAberturaConvenio = obj71.gxTpr_Reembolsodataaberturaconvenio_Z;
         Z544ReembolsoCreatedBy = obj71.gxTpr_Reembolsocreatedby_Z;
         Z547ReembolsoEtapaUltimo_F = obj71.gxTpr_Reembolsoetapaultimo_f_Z;
         Z548ReembolsoStatusAtual_F = obj71.gxTpr_Reembolsostatusatual_f_Z;
         Z742WorkflowConvenioId = obj71.gxTpr_Workflowconvenioid_Z;
         O742WorkflowConvenioId = obj71.gxTpr_Workflowconvenioid_Z;
         Z736WorkflowConvenioDesc = obj71.gxTpr_Workflowconveniodesc_Z;
         n518ReembolsoId = (bool)(Convert.ToBoolean(obj71.gxTpr_Reembolsoid_N));
         n542ReembolsoPropostaId = (bool)(Convert.ToBoolean(obj71.gxTpr_Reembolsopropostaid_N));
         n550ReembolsoPropostaPacienteClienteRazaoSocial = (bool)(Convert.ToBoolean(obj71.gxTpr_Reembolsopropostapacienteclienterazaosocial_N));
         n558ReembolsoPropostaPacienteClienteId = (bool)(Convert.ToBoolean(obj71.gxTpr_Reembolsopropostapacienteclienteid_N));
         n758ReembolsoPropostaClinicaId = (bool)(Convert.ToBoolean(obj71.gxTpr_Reembolsopropostaclinicaid_N));
         n546ReembolsoProtocolo = (bool)(Convert.ToBoolean(obj71.gxTpr_Reembolsoprotocolo_N));
         n645ReembolsoValorReembolsado_F = (bool)(Convert.ToBoolean(obj71.gxTpr_Reembolsovalorreembolsado_f_N));
         n522ReembolsoCreatedAt = (bool)(Convert.ToBoolean(obj71.gxTpr_Reembolsocreatedat_N));
         n543ReembolsoPropostaValor = (bool)(Convert.ToBoolean(obj71.gxTpr_Reembolsopropostavalor_N));
         n525ReembolsoDataAberturaConvenio = (bool)(Convert.ToBoolean(obj71.gxTpr_Reembolsodataaberturaconvenio_N));
         n544ReembolsoCreatedBy = (bool)(Convert.ToBoolean(obj71.gxTpr_Reembolsocreatedby_N));
         n547ReembolsoEtapaUltimo_F = (bool)(Convert.ToBoolean(obj71.gxTpr_Reembolsoetapaultimo_f_N));
         n548ReembolsoStatusAtual_F = (bool)(Convert.ToBoolean(obj71.gxTpr_Reembolsostatusatual_f_N));
         n742WorkflowConvenioId = (bool)(Convert.ToBoolean(obj71.gxTpr_Workflowconvenioid_N));
         n736WorkflowConvenioDesc = (bool)(Convert.ToBoolean(obj71.gxTpr_Workflowconveniodesc_N));
         Gx_mode = obj71.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A518ReembolsoId = (int)getParm(obj,0);
         n518ReembolsoId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1Y71( ) ;
         ScanKeyStart1Y71( ) ;
         if ( RcdFound71 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z518ReembolsoId = A518ReembolsoId;
            O742WorkflowConvenioId = A742WorkflowConvenioId;
            n742WorkflowConvenioId = false;
         }
         ZM1Y71( -10) ;
         OnLoadActions1Y71( ) ;
         AddRow1Y71( ) ;
         ScanKeyEnd1Y71( ) ;
         if ( RcdFound71 == 0 )
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
         RowToVars71( bcReembolso, 0) ;
         ScanKeyStart1Y71( ) ;
         if ( RcdFound71 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z518ReembolsoId = A518ReembolsoId;
            O742WorkflowConvenioId = A742WorkflowConvenioId;
            n742WorkflowConvenioId = false;
         }
         ZM1Y71( -10) ;
         OnLoadActions1Y71( ) ;
         AddRow1Y71( ) ;
         ScanKeyEnd1Y71( ) ;
         if ( RcdFound71 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1Y71( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1Y71( ) ;
         }
         else
         {
            if ( RcdFound71 == 1 )
            {
               if ( A518ReembolsoId != Z518ReembolsoId )
               {
                  A518ReembolsoId = Z518ReembolsoId;
                  n518ReembolsoId = false;
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
                  Update1Y71( ) ;
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
                  if ( A518ReembolsoId != Z518ReembolsoId )
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
                        Insert1Y71( ) ;
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
                        Insert1Y71( ) ;
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
         RowToVars71( bcReembolso, 1) ;
         SaveImpl( ) ;
         VarsToRow71( bcReembolso) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars71( bcReembolso, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1Y71( ) ;
         AfterTrn( ) ;
         VarsToRow71( bcReembolso) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow71( bcReembolso) ;
         }
         else
         {
            SdtReembolso auxBC = new SdtReembolso(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A518ReembolsoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcReembolso);
               auxBC.Save();
               bcReembolso.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars71( bcReembolso, 1) ;
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
         RowToVars71( bcReembolso, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1Y71( ) ;
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
               VarsToRow71( bcReembolso) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow71( bcReembolso) ;
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
         RowToVars71( bcReembolso, 0) ;
         GetKey1Y71( ) ;
         if ( RcdFound71 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A518ReembolsoId != Z518ReembolsoId )
            {
               A518ReembolsoId = Z518ReembolsoId;
               n518ReembolsoId = false;
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
            if ( A518ReembolsoId != Z518ReembolsoId )
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
         context.RollbackDataStores("reembolso_bc",pr_default);
         VarsToRow71( bcReembolso) ;
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
         Gx_mode = bcReembolso.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcReembolso.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcReembolso )
         {
            bcReembolso = (SdtReembolso)(sdt);
            if ( StringUtil.StrCmp(bcReembolso.gxTpr_Mode, "") == 0 )
            {
               bcReembolso.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow71( bcReembolso) ;
            }
            else
            {
               RowToVars71( bcReembolso, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcReembolso.gxTpr_Mode, "") == 0 )
            {
               bcReembolso.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars71( bcReembolso, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtReembolso Reembolso_BC
      {
         get {
            return bcReembolso ;
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
         pr_default.close(19);
         pr_default.close(17);
         pr_default.close(18);
         pr_default.close(2);
         pr_default.close(15);
         pr_default.close(16);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV26Pgmname = "";
         AV13TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z522ReembolsoCreatedAt = (DateTime)(DateTime.MinValue);
         A522ReembolsoCreatedAt = (DateTime)(DateTime.MinValue);
         Z546ReembolsoProtocolo = "";
         A546ReembolsoProtocolo = "";
         Z525ReembolsoDataAberturaConvenio = DateTime.MinValue;
         A525ReembolsoDataAberturaConvenio = DateTime.MinValue;
         Z547ReembolsoEtapaUltimo_F = (DateTime)(DateTime.MinValue);
         A547ReembolsoEtapaUltimo_F = (DateTime)(DateTime.MinValue);
         Z548ReembolsoStatusAtual_F = "";
         A548ReembolsoStatusAtual_F = "";
         Z736WorkflowConvenioDesc = "";
         A736WorkflowConvenioDesc = "";
         Z550ReembolsoPropostaPacienteClienteRazaoSocial = "";
         A550ReembolsoPropostaPacienteClienteRazaoSocial = "";
         BC001Y17_A518ReembolsoId = new int[1] ;
         BC001Y17_n518ReembolsoId = new bool[] {false} ;
         BC001Y17_A522ReembolsoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC001Y17_n522ReembolsoCreatedAt = new bool[] {false} ;
         BC001Y17_A550ReembolsoPropostaPacienteClienteRazaoSocial = new string[] {""} ;
         BC001Y17_n550ReembolsoPropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         BC001Y17_A546ReembolsoProtocolo = new string[] {""} ;
         BC001Y17_n546ReembolsoProtocolo = new bool[] {false} ;
         BC001Y17_A543ReembolsoPropostaValor = new decimal[1] ;
         BC001Y17_n543ReembolsoPropostaValor = new bool[] {false} ;
         BC001Y17_A525ReembolsoDataAberturaConvenio = new DateTime[] {DateTime.MinValue} ;
         BC001Y17_n525ReembolsoDataAberturaConvenio = new bool[] {false} ;
         BC001Y17_A736WorkflowConvenioDesc = new string[] {""} ;
         BC001Y17_n736WorkflowConvenioDesc = new bool[] {false} ;
         BC001Y17_A742WorkflowConvenioId = new int[1] ;
         BC001Y17_n742WorkflowConvenioId = new bool[] {false} ;
         BC001Y17_A542ReembolsoPropostaId = new int[1] ;
         BC001Y17_n542ReembolsoPropostaId = new bool[] {false} ;
         BC001Y17_A544ReembolsoCreatedBy = new short[1] ;
         BC001Y17_n544ReembolsoCreatedBy = new bool[] {false} ;
         BC001Y17_A558ReembolsoPropostaPacienteClienteId = new int[1] ;
         BC001Y17_n558ReembolsoPropostaPacienteClienteId = new bool[] {false} ;
         BC001Y17_A758ReembolsoPropostaClinicaId = new int[1] ;
         BC001Y17_n758ReembolsoPropostaClinicaId = new bool[] {false} ;
         BC001Y17_A645ReembolsoValorReembolsado_F = new decimal[1] ;
         BC001Y17_n645ReembolsoValorReembolsado_F = new bool[] {false} ;
         BC001Y17_A547ReembolsoEtapaUltimo_F = new DateTime[] {DateTime.MinValue} ;
         BC001Y17_n547ReembolsoEtapaUltimo_F = new bool[] {false} ;
         BC001Y12_A645ReembolsoValorReembolsado_F = new decimal[1] ;
         BC001Y12_n645ReembolsoValorReembolsado_F = new bool[] {false} ;
         BC001Y14_A547ReembolsoEtapaUltimo_F = new DateTime[] {DateTime.MinValue} ;
         BC001Y14_n547ReembolsoEtapaUltimo_F = new bool[] {false} ;
         BC001Y8_A543ReembolsoPropostaValor = new decimal[1] ;
         BC001Y8_n543ReembolsoPropostaValor = new bool[] {false} ;
         BC001Y8_A558ReembolsoPropostaPacienteClienteId = new int[1] ;
         BC001Y8_n558ReembolsoPropostaPacienteClienteId = new bool[] {false} ;
         BC001Y8_A758ReembolsoPropostaClinicaId = new int[1] ;
         BC001Y8_n758ReembolsoPropostaClinicaId = new bool[] {false} ;
         BC001Y10_A550ReembolsoPropostaPacienteClienteRazaoSocial = new string[] {""} ;
         BC001Y10_n550ReembolsoPropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         BC001Y9_A544ReembolsoCreatedBy = new short[1] ;
         BC001Y9_n544ReembolsoCreatedBy = new bool[] {false} ;
         BC001Y7_A736WorkflowConvenioDesc = new string[] {""} ;
         BC001Y7_n736WorkflowConvenioDesc = new bool[] {false} ;
         BC001Y18_A518ReembolsoId = new int[1] ;
         BC001Y18_n518ReembolsoId = new bool[] {false} ;
         BC001Y3_A518ReembolsoId = new int[1] ;
         BC001Y3_n518ReembolsoId = new bool[] {false} ;
         BC001Y3_A522ReembolsoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC001Y3_n522ReembolsoCreatedAt = new bool[] {false} ;
         BC001Y3_A546ReembolsoProtocolo = new string[] {""} ;
         BC001Y3_n546ReembolsoProtocolo = new bool[] {false} ;
         BC001Y3_A525ReembolsoDataAberturaConvenio = new DateTime[] {DateTime.MinValue} ;
         BC001Y3_n525ReembolsoDataAberturaConvenio = new bool[] {false} ;
         BC001Y3_A742WorkflowConvenioId = new int[1] ;
         BC001Y3_n742WorkflowConvenioId = new bool[] {false} ;
         BC001Y3_A542ReembolsoPropostaId = new int[1] ;
         BC001Y3_n542ReembolsoPropostaId = new bool[] {false} ;
         BC001Y3_A544ReembolsoCreatedBy = new short[1] ;
         BC001Y3_n544ReembolsoCreatedBy = new bool[] {false} ;
         sMode71 = "";
         BC001Y2_A518ReembolsoId = new int[1] ;
         BC001Y2_n518ReembolsoId = new bool[] {false} ;
         BC001Y2_A522ReembolsoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC001Y2_n522ReembolsoCreatedAt = new bool[] {false} ;
         BC001Y2_A546ReembolsoProtocolo = new string[] {""} ;
         BC001Y2_n546ReembolsoProtocolo = new bool[] {false} ;
         BC001Y2_A525ReembolsoDataAberturaConvenio = new DateTime[] {DateTime.MinValue} ;
         BC001Y2_n525ReembolsoDataAberturaConvenio = new bool[] {false} ;
         BC001Y2_A742WorkflowConvenioId = new int[1] ;
         BC001Y2_n742WorkflowConvenioId = new bool[] {false} ;
         BC001Y2_A542ReembolsoPropostaId = new int[1] ;
         BC001Y2_n542ReembolsoPropostaId = new bool[] {false} ;
         BC001Y2_A544ReembolsoCreatedBy = new short[1] ;
         BC001Y2_n544ReembolsoCreatedBy = new bool[] {false} ;
         BC001Y20_A518ReembolsoId = new int[1] ;
         BC001Y20_n518ReembolsoId = new bool[] {false} ;
         BC001Y24_A645ReembolsoValorReembolsado_F = new decimal[1] ;
         BC001Y24_n645ReembolsoValorReembolsado_F = new bool[] {false} ;
         BC001Y26_A547ReembolsoEtapaUltimo_F = new DateTime[] {DateTime.MinValue} ;
         BC001Y26_n547ReembolsoEtapaUltimo_F = new bool[] {false} ;
         BC001Y27_A543ReembolsoPropostaValor = new decimal[1] ;
         BC001Y27_n543ReembolsoPropostaValor = new bool[] {false} ;
         BC001Y27_A558ReembolsoPropostaPacienteClienteId = new int[1] ;
         BC001Y27_n558ReembolsoPropostaPacienteClienteId = new bool[] {false} ;
         BC001Y27_A758ReembolsoPropostaClinicaId = new int[1] ;
         BC001Y27_n758ReembolsoPropostaClinicaId = new bool[] {false} ;
         BC001Y28_A550ReembolsoPropostaPacienteClienteRazaoSocial = new string[] {""} ;
         BC001Y28_n550ReembolsoPropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         BC001Y29_A736WorkflowConvenioDesc = new string[] {""} ;
         BC001Y29_n736WorkflowConvenioDesc = new bool[] {false} ;
         BC001Y30_A746ReembolsoFlowLogId = new int[1] ;
         BC001Y31_A634ReembolsoParcelasId = new int[1] ;
         BC001Y32_A631ReembolsoAssinaturasId = new int[1] ;
         BC001Y33_A526ReembolsoEtapaId = new int[1] ;
         BC001Y36_A518ReembolsoId = new int[1] ;
         BC001Y36_n518ReembolsoId = new bool[] {false} ;
         BC001Y36_A522ReembolsoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC001Y36_n522ReembolsoCreatedAt = new bool[] {false} ;
         BC001Y36_A550ReembolsoPropostaPacienteClienteRazaoSocial = new string[] {""} ;
         BC001Y36_n550ReembolsoPropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         BC001Y36_A546ReembolsoProtocolo = new string[] {""} ;
         BC001Y36_n546ReembolsoProtocolo = new bool[] {false} ;
         BC001Y36_A543ReembolsoPropostaValor = new decimal[1] ;
         BC001Y36_n543ReembolsoPropostaValor = new bool[] {false} ;
         BC001Y36_A525ReembolsoDataAberturaConvenio = new DateTime[] {DateTime.MinValue} ;
         BC001Y36_n525ReembolsoDataAberturaConvenio = new bool[] {false} ;
         BC001Y36_A736WorkflowConvenioDesc = new string[] {""} ;
         BC001Y36_n736WorkflowConvenioDesc = new bool[] {false} ;
         BC001Y36_A742WorkflowConvenioId = new int[1] ;
         BC001Y36_n742WorkflowConvenioId = new bool[] {false} ;
         BC001Y36_A542ReembolsoPropostaId = new int[1] ;
         BC001Y36_n542ReembolsoPropostaId = new bool[] {false} ;
         BC001Y36_A544ReembolsoCreatedBy = new short[1] ;
         BC001Y36_n544ReembolsoCreatedBy = new bool[] {false} ;
         BC001Y36_A558ReembolsoPropostaPacienteClienteId = new int[1] ;
         BC001Y36_n558ReembolsoPropostaPacienteClienteId = new bool[] {false} ;
         BC001Y36_A758ReembolsoPropostaClinicaId = new int[1] ;
         BC001Y36_n758ReembolsoPropostaClinicaId = new bool[] {false} ;
         BC001Y36_A645ReembolsoValorReembolsado_F = new decimal[1] ;
         BC001Y36_n645ReembolsoValorReembolsado_F = new bool[] {false} ;
         BC001Y36_A547ReembolsoEtapaUltimo_F = new DateTime[] {DateTime.MinValue} ;
         BC001Y36_n547ReembolsoEtapaUltimo_F = new bool[] {false} ;
         i522ReembolsoCreatedAt = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reembolso_bc__default(),
            new Object[][] {
                new Object[] {
               BC001Y2_A518ReembolsoId, BC001Y2_A522ReembolsoCreatedAt, BC001Y2_n522ReembolsoCreatedAt, BC001Y2_A546ReembolsoProtocolo, BC001Y2_n546ReembolsoProtocolo, BC001Y2_A525ReembolsoDataAberturaConvenio, BC001Y2_n525ReembolsoDataAberturaConvenio, BC001Y2_A742WorkflowConvenioId, BC001Y2_n742WorkflowConvenioId, BC001Y2_A542ReembolsoPropostaId,
               BC001Y2_n542ReembolsoPropostaId, BC001Y2_A544ReembolsoCreatedBy, BC001Y2_n544ReembolsoCreatedBy
               }
               , new Object[] {
               BC001Y3_A518ReembolsoId, BC001Y3_A522ReembolsoCreatedAt, BC001Y3_n522ReembolsoCreatedAt, BC001Y3_A546ReembolsoProtocolo, BC001Y3_n546ReembolsoProtocolo, BC001Y3_A525ReembolsoDataAberturaConvenio, BC001Y3_n525ReembolsoDataAberturaConvenio, BC001Y3_A742WorkflowConvenioId, BC001Y3_n742WorkflowConvenioId, BC001Y3_A542ReembolsoPropostaId,
               BC001Y3_n542ReembolsoPropostaId, BC001Y3_A544ReembolsoCreatedBy, BC001Y3_n544ReembolsoCreatedBy
               }
               , new Object[] {
               BC001Y6_A548ReembolsoStatusAtual_F, BC001Y6_n548ReembolsoStatusAtual_F
               }
               , new Object[] {
               BC001Y7_A736WorkflowConvenioDesc, BC001Y7_n736WorkflowConvenioDesc
               }
               , new Object[] {
               BC001Y8_A543ReembolsoPropostaValor, BC001Y8_n543ReembolsoPropostaValor, BC001Y8_A558ReembolsoPropostaPacienteClienteId, BC001Y8_n558ReembolsoPropostaPacienteClienteId, BC001Y8_A758ReembolsoPropostaClinicaId, BC001Y8_n758ReembolsoPropostaClinicaId
               }
               , new Object[] {
               BC001Y9_A544ReembolsoCreatedBy
               }
               , new Object[] {
               BC001Y10_A550ReembolsoPropostaPacienteClienteRazaoSocial, BC001Y10_n550ReembolsoPropostaPacienteClienteRazaoSocial
               }
               , new Object[] {
               BC001Y12_A645ReembolsoValorReembolsado_F, BC001Y12_n645ReembolsoValorReembolsado_F
               }
               , new Object[] {
               BC001Y14_A547ReembolsoEtapaUltimo_F, BC001Y14_n547ReembolsoEtapaUltimo_F
               }
               , new Object[] {
               BC001Y17_A518ReembolsoId, BC001Y17_A522ReembolsoCreatedAt, BC001Y17_n522ReembolsoCreatedAt, BC001Y17_A550ReembolsoPropostaPacienteClienteRazaoSocial, BC001Y17_n550ReembolsoPropostaPacienteClienteRazaoSocial, BC001Y17_A546ReembolsoProtocolo, BC001Y17_n546ReembolsoProtocolo, BC001Y17_A543ReembolsoPropostaValor, BC001Y17_n543ReembolsoPropostaValor, BC001Y17_A525ReembolsoDataAberturaConvenio,
               BC001Y17_n525ReembolsoDataAberturaConvenio, BC001Y17_A736WorkflowConvenioDesc, BC001Y17_n736WorkflowConvenioDesc, BC001Y17_A742WorkflowConvenioId, BC001Y17_n742WorkflowConvenioId, BC001Y17_A542ReembolsoPropostaId, BC001Y17_n542ReembolsoPropostaId, BC001Y17_A544ReembolsoCreatedBy, BC001Y17_n544ReembolsoCreatedBy, BC001Y17_A558ReembolsoPropostaPacienteClienteId,
               BC001Y17_n558ReembolsoPropostaPacienteClienteId, BC001Y17_A758ReembolsoPropostaClinicaId, BC001Y17_n758ReembolsoPropostaClinicaId, BC001Y17_A645ReembolsoValorReembolsado_F, BC001Y17_n645ReembolsoValorReembolsado_F, BC001Y17_A547ReembolsoEtapaUltimo_F, BC001Y17_n547ReembolsoEtapaUltimo_F
               }
               , new Object[] {
               BC001Y18_A518ReembolsoId
               }
               , new Object[] {
               }
               , new Object[] {
               BC001Y20_A518ReembolsoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001Y24_A645ReembolsoValorReembolsado_F, BC001Y24_n645ReembolsoValorReembolsado_F
               }
               , new Object[] {
               BC001Y26_A547ReembolsoEtapaUltimo_F, BC001Y26_n547ReembolsoEtapaUltimo_F
               }
               , new Object[] {
               BC001Y27_A543ReembolsoPropostaValor, BC001Y27_n543ReembolsoPropostaValor, BC001Y27_A558ReembolsoPropostaPacienteClienteId, BC001Y27_n558ReembolsoPropostaPacienteClienteId, BC001Y27_A758ReembolsoPropostaClinicaId, BC001Y27_n758ReembolsoPropostaClinicaId
               }
               , new Object[] {
               BC001Y28_A550ReembolsoPropostaPacienteClienteRazaoSocial, BC001Y28_n550ReembolsoPropostaPacienteClienteRazaoSocial
               }
               , new Object[] {
               BC001Y29_A736WorkflowConvenioDesc, BC001Y29_n736WorkflowConvenioDesc
               }
               , new Object[] {
               BC001Y30_A746ReembolsoFlowLogId
               }
               , new Object[] {
               BC001Y31_A634ReembolsoParcelasId
               }
               , new Object[] {
               BC001Y32_A631ReembolsoAssinaturasId
               }
               , new Object[] {
               BC001Y33_A526ReembolsoEtapaId
               }
               , new Object[] {
               BC001Y36_A518ReembolsoId, BC001Y36_A522ReembolsoCreatedAt, BC001Y36_n522ReembolsoCreatedAt, BC001Y36_A550ReembolsoPropostaPacienteClienteRazaoSocial, BC001Y36_n550ReembolsoPropostaPacienteClienteRazaoSocial, BC001Y36_A546ReembolsoProtocolo, BC001Y36_n546ReembolsoProtocolo, BC001Y36_A543ReembolsoPropostaValor, BC001Y36_n543ReembolsoPropostaValor, BC001Y36_A525ReembolsoDataAberturaConvenio,
               BC001Y36_n525ReembolsoDataAberturaConvenio, BC001Y36_A736WorkflowConvenioDesc, BC001Y36_n736WorkflowConvenioDesc, BC001Y36_A742WorkflowConvenioId, BC001Y36_n742WorkflowConvenioId, BC001Y36_A542ReembolsoPropostaId, BC001Y36_n542ReembolsoPropostaId, BC001Y36_A544ReembolsoCreatedBy, BC001Y36_n544ReembolsoCreatedBy, BC001Y36_A558ReembolsoPropostaPacienteClienteId,
               BC001Y36_n558ReembolsoPropostaPacienteClienteId, BC001Y36_A758ReembolsoPropostaClinicaId, BC001Y36_n758ReembolsoPropostaClinicaId, BC001Y36_A645ReembolsoValorReembolsado_F, BC001Y36_n645ReembolsoValorReembolsado_F, BC001Y36_A547ReembolsoEtapaUltimo_F, BC001Y36_n547ReembolsoEtapaUltimo_F
               }
            }
         );
         AV26Pgmname = "Reembolso_BC";
         Z522ReembolsoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n522ReembolsoCreatedAt = false;
         A522ReembolsoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n522ReembolsoCreatedAt = false;
         i522ReembolsoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n522ReembolsoCreatedAt = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121Y2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short AV12Insert_ReembolsoCreatedBy ;
      private short Z544ReembolsoCreatedBy ;
      private short A544ReembolsoCreatedBy ;
      private short Gx_BScreen ;
      private short RcdFound71 ;
      private int trnEnded ;
      private int Z518ReembolsoId ;
      private int A518ReembolsoId ;
      private int AV27GXV1 ;
      private int AV11Insert_ReembolsoPropostaId ;
      private int AV24Insert_WorkflowConvenioId ;
      private int Z742WorkflowConvenioId ;
      private int A742WorkflowConvenioId ;
      private int Z542ReembolsoPropostaId ;
      private int A542ReembolsoPropostaId ;
      private int Z558ReembolsoPropostaPacienteClienteId ;
      private int A558ReembolsoPropostaPacienteClienteId ;
      private int Z758ReembolsoPropostaClinicaId ;
      private int A758ReembolsoPropostaClinicaId ;
      private int O742WorkflowConvenioId ;
      private decimal Z645ReembolsoValorReembolsado_F ;
      private decimal A645ReembolsoValorReembolsado_F ;
      private decimal Z543ReembolsoPropostaValor ;
      private decimal A543ReembolsoPropostaValor ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV26Pgmname ;
      private string sMode71 ;
      private DateTime Z522ReembolsoCreatedAt ;
      private DateTime A522ReembolsoCreatedAt ;
      private DateTime Z547ReembolsoEtapaUltimo_F ;
      private DateTime A547ReembolsoEtapaUltimo_F ;
      private DateTime i522ReembolsoCreatedAt ;
      private DateTime Z525ReembolsoDataAberturaConvenio ;
      private DateTime A525ReembolsoDataAberturaConvenio ;
      private bool returnInSub ;
      private bool n522ReembolsoCreatedAt ;
      private bool n518ReembolsoId ;
      private bool n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool n546ReembolsoProtocolo ;
      private bool n543ReembolsoPropostaValor ;
      private bool n525ReembolsoDataAberturaConvenio ;
      private bool n736WorkflowConvenioDesc ;
      private bool n742WorkflowConvenioId ;
      private bool n542ReembolsoPropostaId ;
      private bool n544ReembolsoCreatedBy ;
      private bool n558ReembolsoPropostaPacienteClienteId ;
      private bool n758ReembolsoPropostaClinicaId ;
      private bool n645ReembolsoValorReembolsado_F ;
      private bool n547ReembolsoEtapaUltimo_F ;
      private bool Gx_longc ;
      private bool n548ReembolsoStatusAtual_F ;
      private string Z546ReembolsoProtocolo ;
      private string A546ReembolsoProtocolo ;
      private string Z548ReembolsoStatusAtual_F ;
      private string A548ReembolsoStatusAtual_F ;
      private string Z736WorkflowConvenioDesc ;
      private string A736WorkflowConvenioDesc ;
      private string Z550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private string A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] BC001Y17_A518ReembolsoId ;
      private bool[] BC001Y17_n518ReembolsoId ;
      private DateTime[] BC001Y17_A522ReembolsoCreatedAt ;
      private bool[] BC001Y17_n522ReembolsoCreatedAt ;
      private string[] BC001Y17_A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool[] BC001Y17_n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private string[] BC001Y17_A546ReembolsoProtocolo ;
      private bool[] BC001Y17_n546ReembolsoProtocolo ;
      private decimal[] BC001Y17_A543ReembolsoPropostaValor ;
      private bool[] BC001Y17_n543ReembolsoPropostaValor ;
      private DateTime[] BC001Y17_A525ReembolsoDataAberturaConvenio ;
      private bool[] BC001Y17_n525ReembolsoDataAberturaConvenio ;
      private string[] BC001Y17_A736WorkflowConvenioDesc ;
      private bool[] BC001Y17_n736WorkflowConvenioDesc ;
      private int[] BC001Y17_A742WorkflowConvenioId ;
      private bool[] BC001Y17_n742WorkflowConvenioId ;
      private int[] BC001Y17_A542ReembolsoPropostaId ;
      private bool[] BC001Y17_n542ReembolsoPropostaId ;
      private short[] BC001Y17_A544ReembolsoCreatedBy ;
      private bool[] BC001Y17_n544ReembolsoCreatedBy ;
      private int[] BC001Y17_A558ReembolsoPropostaPacienteClienteId ;
      private bool[] BC001Y17_n558ReembolsoPropostaPacienteClienteId ;
      private int[] BC001Y17_A758ReembolsoPropostaClinicaId ;
      private bool[] BC001Y17_n758ReembolsoPropostaClinicaId ;
      private decimal[] BC001Y17_A645ReembolsoValorReembolsado_F ;
      private bool[] BC001Y17_n645ReembolsoValorReembolsado_F ;
      private DateTime[] BC001Y17_A547ReembolsoEtapaUltimo_F ;
      private bool[] BC001Y17_n547ReembolsoEtapaUltimo_F ;
      private decimal[] BC001Y12_A645ReembolsoValorReembolsado_F ;
      private bool[] BC001Y12_n645ReembolsoValorReembolsado_F ;
      private DateTime[] BC001Y14_A547ReembolsoEtapaUltimo_F ;
      private bool[] BC001Y14_n547ReembolsoEtapaUltimo_F ;
      private decimal[] BC001Y8_A543ReembolsoPropostaValor ;
      private bool[] BC001Y8_n543ReembolsoPropostaValor ;
      private int[] BC001Y8_A558ReembolsoPropostaPacienteClienteId ;
      private bool[] BC001Y8_n558ReembolsoPropostaPacienteClienteId ;
      private int[] BC001Y8_A758ReembolsoPropostaClinicaId ;
      private bool[] BC001Y8_n758ReembolsoPropostaClinicaId ;
      private string[] BC001Y10_A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool[] BC001Y10_n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private short[] BC001Y9_A544ReembolsoCreatedBy ;
      private bool[] BC001Y9_n544ReembolsoCreatedBy ;
      private string[] BC001Y7_A736WorkflowConvenioDesc ;
      private bool[] BC001Y7_n736WorkflowConvenioDesc ;
      private int[] BC001Y18_A518ReembolsoId ;
      private bool[] BC001Y18_n518ReembolsoId ;
      private int[] BC001Y3_A518ReembolsoId ;
      private bool[] BC001Y3_n518ReembolsoId ;
      private DateTime[] BC001Y3_A522ReembolsoCreatedAt ;
      private bool[] BC001Y3_n522ReembolsoCreatedAt ;
      private string[] BC001Y3_A546ReembolsoProtocolo ;
      private bool[] BC001Y3_n546ReembolsoProtocolo ;
      private DateTime[] BC001Y3_A525ReembolsoDataAberturaConvenio ;
      private bool[] BC001Y3_n525ReembolsoDataAberturaConvenio ;
      private int[] BC001Y3_A742WorkflowConvenioId ;
      private bool[] BC001Y3_n742WorkflowConvenioId ;
      private int[] BC001Y3_A542ReembolsoPropostaId ;
      private bool[] BC001Y3_n542ReembolsoPropostaId ;
      private short[] BC001Y3_A544ReembolsoCreatedBy ;
      private bool[] BC001Y3_n544ReembolsoCreatedBy ;
      private int[] BC001Y2_A518ReembolsoId ;
      private bool[] BC001Y2_n518ReembolsoId ;
      private DateTime[] BC001Y2_A522ReembolsoCreatedAt ;
      private bool[] BC001Y2_n522ReembolsoCreatedAt ;
      private string[] BC001Y2_A546ReembolsoProtocolo ;
      private bool[] BC001Y2_n546ReembolsoProtocolo ;
      private DateTime[] BC001Y2_A525ReembolsoDataAberturaConvenio ;
      private bool[] BC001Y2_n525ReembolsoDataAberturaConvenio ;
      private int[] BC001Y2_A742WorkflowConvenioId ;
      private bool[] BC001Y2_n742WorkflowConvenioId ;
      private int[] BC001Y2_A542ReembolsoPropostaId ;
      private bool[] BC001Y2_n542ReembolsoPropostaId ;
      private short[] BC001Y2_A544ReembolsoCreatedBy ;
      private bool[] BC001Y2_n544ReembolsoCreatedBy ;
      private int[] BC001Y20_A518ReembolsoId ;
      private bool[] BC001Y20_n518ReembolsoId ;
      private decimal[] BC001Y24_A645ReembolsoValorReembolsado_F ;
      private bool[] BC001Y24_n645ReembolsoValorReembolsado_F ;
      private DateTime[] BC001Y26_A547ReembolsoEtapaUltimo_F ;
      private bool[] BC001Y26_n547ReembolsoEtapaUltimo_F ;
      private decimal[] BC001Y27_A543ReembolsoPropostaValor ;
      private bool[] BC001Y27_n543ReembolsoPropostaValor ;
      private int[] BC001Y27_A558ReembolsoPropostaPacienteClienteId ;
      private bool[] BC001Y27_n558ReembolsoPropostaPacienteClienteId ;
      private int[] BC001Y27_A758ReembolsoPropostaClinicaId ;
      private bool[] BC001Y27_n758ReembolsoPropostaClinicaId ;
      private string[] BC001Y28_A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool[] BC001Y28_n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private string[] BC001Y29_A736WorkflowConvenioDesc ;
      private bool[] BC001Y29_n736WorkflowConvenioDesc ;
      private int[] BC001Y30_A746ReembolsoFlowLogId ;
      private int[] BC001Y31_A634ReembolsoParcelasId ;
      private int[] BC001Y32_A631ReembolsoAssinaturasId ;
      private int[] BC001Y33_A526ReembolsoEtapaId ;
      private int[] BC001Y36_A518ReembolsoId ;
      private bool[] BC001Y36_n518ReembolsoId ;
      private DateTime[] BC001Y36_A522ReembolsoCreatedAt ;
      private bool[] BC001Y36_n522ReembolsoCreatedAt ;
      private string[] BC001Y36_A550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private bool[] BC001Y36_n550ReembolsoPropostaPacienteClienteRazaoSocial ;
      private string[] BC001Y36_A546ReembolsoProtocolo ;
      private bool[] BC001Y36_n546ReembolsoProtocolo ;
      private decimal[] BC001Y36_A543ReembolsoPropostaValor ;
      private bool[] BC001Y36_n543ReembolsoPropostaValor ;
      private DateTime[] BC001Y36_A525ReembolsoDataAberturaConvenio ;
      private bool[] BC001Y36_n525ReembolsoDataAberturaConvenio ;
      private string[] BC001Y36_A736WorkflowConvenioDesc ;
      private bool[] BC001Y36_n736WorkflowConvenioDesc ;
      private int[] BC001Y36_A742WorkflowConvenioId ;
      private bool[] BC001Y36_n742WorkflowConvenioId ;
      private int[] BC001Y36_A542ReembolsoPropostaId ;
      private bool[] BC001Y36_n542ReembolsoPropostaId ;
      private short[] BC001Y36_A544ReembolsoCreatedBy ;
      private bool[] BC001Y36_n544ReembolsoCreatedBy ;
      private int[] BC001Y36_A558ReembolsoPropostaPacienteClienteId ;
      private bool[] BC001Y36_n558ReembolsoPropostaPacienteClienteId ;
      private int[] BC001Y36_A758ReembolsoPropostaClinicaId ;
      private bool[] BC001Y36_n758ReembolsoPropostaClinicaId ;
      private decimal[] BC001Y36_A645ReembolsoValorReembolsado_F ;
      private bool[] BC001Y36_n645ReembolsoValorReembolsado_F ;
      private DateTime[] BC001Y36_A547ReembolsoEtapaUltimo_F ;
      private bool[] BC001Y36_n547ReembolsoEtapaUltimo_F ;
      private SdtReembolso bcReembolso ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private string[] BC001Y6_A548ReembolsoStatusAtual_F ;
      private bool[] BC001Y6_n548ReembolsoStatusAtual_F ;
   }

   public class reembolso_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC001Y2;
          prmBC001Y2 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Y3;
          prmBC001Y3 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Y6;
          prmBC001Y6 = new Object[] {
          };
          Object[] prmBC001Y7;
          prmBC001Y7 = new Object[] {
          new ParDef("WorkflowConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Y8;
          prmBC001Y8 = new Object[] {
          new ParDef("ReembolsoPropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Y9;
          prmBC001Y9 = new Object[] {
          new ParDef("ReembolsoCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC001Y10;
          prmBC001Y10 = new Object[] {
          new ParDef("ReembolsoPropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Y12;
          prmBC001Y12 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Y14;
          prmBC001Y14 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Y17;
          prmBC001Y17 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Y18;
          prmBC001Y18 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Y19;
          prmBC001Y19 = new Object[] {
          new ParDef("ReembolsoCreatedAt",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("ReembolsoProtocolo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ReembolsoDataAberturaConvenio",GXType.Date,8,0){Nullable=true} ,
          new ParDef("WorkflowConvenioId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ReembolsoPropostaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ReembolsoCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC001Y20;
          prmBC001Y20 = new Object[] {
          };
          Object[] prmBC001Y21;
          prmBC001Y21 = new Object[] {
          new ParDef("ReembolsoCreatedAt",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("ReembolsoProtocolo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ReembolsoDataAberturaConvenio",GXType.Date,8,0){Nullable=true} ,
          new ParDef("WorkflowConvenioId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ReembolsoPropostaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ReembolsoCreatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Y22;
          prmBC001Y22 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Y24;
          prmBC001Y24 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Y26;
          prmBC001Y26 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Y27;
          prmBC001Y27 = new Object[] {
          new ParDef("ReembolsoPropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Y28;
          prmBC001Y28 = new Object[] {
          new ParDef("ReembolsoPropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Y29;
          prmBC001Y29 = new Object[] {
          new ParDef("WorkflowConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Y30;
          prmBC001Y30 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Y31;
          prmBC001Y31 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Y32;
          prmBC001Y32 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Y33;
          prmBC001Y33 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001Y36;
          prmBC001Y36 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC001Y2", "SELECT ReembolsoId, ReembolsoCreatedAt, ReembolsoProtocolo, ReembolsoDataAberturaConvenio, WorkflowConvenioId, ReembolsoPropostaId, ReembolsoCreatedBy FROM Reembolso WHERE ReembolsoId = :ReembolsoId  FOR UPDATE OF Reembolso",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Y2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001Y3", "SELECT ReembolsoId, ReembolsoCreatedAt, ReembolsoProtocolo, ReembolsoDataAberturaConvenio, WorkflowConvenioId, ReembolsoPropostaId, ReembolsoCreatedBy FROM Reembolso WHERE ReembolsoId = :ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Y3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001Y6", "SELECT COALESCE( T1.ReembolsoStatusAtual_F, '') AS ReembolsoStatusAtual_F FROM (SELECT MIN(T2.ReembolsoEtapaStatus) AS ReembolsoStatusAtual_F, COALESCE( T4.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F, T3.ReembolsoPropostaId AS ReembolsoPropostaId FROM ((ReembolsoEtapa T2 LEFT JOIN Reembolso T3 ON T3.ReembolsoId = T2.ReembolsoId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa WHERE T2.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T4 ON T4.ReembolsoId = T2.ReembolsoId) WHERE T2.ReembolsoEtapaCreatedAt = COALESCE( T4.ReembolsoEtapaUltimo_F, DATE '00010101') GROUP BY T4.ReembolsoEtapaUltimo_F, T3.ReembolsoPropostaId ) T1 ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Y6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001Y7", "SELECT WorkflowConvenioDesc FROM WorkflowConvenio WHERE WorkflowConvenioId = :WorkflowConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Y7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001Y8", "SELECT PropostaValor AS ReembolsoPropostaValor, PropostaPacienteClienteId AS ReembolsoPropostaPacienteClienteId, PropostaClinicaId AS ReembolsoPropostaClinicaId FROM Proposta WHERE PropostaId = :ReembolsoPropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Y8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001Y9", "SELECT SecUserId AS ReembolsoCreatedBy FROM SecUser WHERE SecUserId = :ReembolsoCreatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Y9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001Y10", "SELECT ClienteRazaoSocial AS ReembolsoPropostaPacienteClienteRazaoSocial FROM Cliente WHERE ClienteId = :ReembolsoPropostaPacienteClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Y10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001Y12", "SELECT COALESCE( T1.ReembolsoValorReembolsado_F, 0) AS ReembolsoValorReembolsado_F FROM (SELECT SUM(ReembolsoParcelasValor) AS ReembolsoValorReembolsado_F, ReembolsoId FROM ReembolsoParcelas GROUP BY ReembolsoId ) T1 WHERE T1.ReembolsoId = :ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Y12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001Y14", "SELECT COALESCE( T1.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F FROM (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa GROUP BY ReembolsoId ) T1 WHERE T1.ReembolsoId = :ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Y14,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001Y17", "SELECT TM1.ReembolsoId, TM1.ReembolsoCreatedAt, T5.ClienteRazaoSocial AS ReembolsoPropostaPacienteClienteRazaoSocial, TM1.ReembolsoProtocolo, T4.PropostaValor AS ReembolsoPropostaValor, TM1.ReembolsoDataAberturaConvenio, T6.WorkflowConvenioDesc, TM1.WorkflowConvenioId, TM1.ReembolsoPropostaId AS ReembolsoPropostaId, TM1.ReembolsoCreatedBy AS ReembolsoCreatedBy, T4.PropostaPacienteClienteId AS ReembolsoPropostaPacienteClienteId, T4.PropostaClinicaId AS ReembolsoPropostaClinicaId, COALESCE( T2.ReembolsoValorReembolsado_F, 0) AS ReembolsoValorReembolsado_F, COALESCE( T3.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F FROM (((((Reembolso TM1 LEFT JOIN LATERAL (SELECT SUM(ReembolsoParcelasValor) AS ReembolsoValorReembolsado_F, ReembolsoId FROM ReembolsoParcelas WHERE TM1.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T2 ON T2.ReembolsoId = TM1.ReembolsoId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa WHERE TM1.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T3 ON T3.ReembolsoId = TM1.ReembolsoId) LEFT JOIN Proposta T4 ON T4.PropostaId = TM1.ReembolsoPropostaId) LEFT JOIN Cliente T5 ON T5.ClienteId = T4.PropostaPacienteClienteId) LEFT JOIN WorkflowConvenio T6 ON T6.WorkflowConvenioId = TM1.WorkflowConvenioId) WHERE TM1.ReembolsoId = :ReembolsoId ORDER BY TM1.ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Y17,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001Y18", "SELECT ReembolsoId FROM Reembolso WHERE ReembolsoId = :ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Y18,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001Y19", "SAVEPOINT gxupdate;INSERT INTO Reembolso(ReembolsoCreatedAt, ReembolsoProtocolo, ReembolsoDataAberturaConvenio, WorkflowConvenioId, ReembolsoPropostaId, ReembolsoCreatedBy) VALUES(:ReembolsoCreatedAt, :ReembolsoProtocolo, :ReembolsoDataAberturaConvenio, :WorkflowConvenioId, :ReembolsoPropostaId, :ReembolsoCreatedBy);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001Y19)
             ,new CursorDef("BC001Y20", "SELECT currval('ReembolsoId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Y20,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001Y21", "SAVEPOINT gxupdate;UPDATE Reembolso SET ReembolsoCreatedAt=:ReembolsoCreatedAt, ReembolsoProtocolo=:ReembolsoProtocolo, ReembolsoDataAberturaConvenio=:ReembolsoDataAberturaConvenio, WorkflowConvenioId=:WorkflowConvenioId, ReembolsoPropostaId=:ReembolsoPropostaId, ReembolsoCreatedBy=:ReembolsoCreatedBy  WHERE ReembolsoId = :ReembolsoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001Y21)
             ,new CursorDef("BC001Y22", "SAVEPOINT gxupdate;DELETE FROM Reembolso  WHERE ReembolsoId = :ReembolsoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001Y22)
             ,new CursorDef("BC001Y24", "SELECT COALESCE( T1.ReembolsoValorReembolsado_F, 0) AS ReembolsoValorReembolsado_F FROM (SELECT SUM(ReembolsoParcelasValor) AS ReembolsoValorReembolsado_F, ReembolsoId FROM ReembolsoParcelas GROUP BY ReembolsoId ) T1 WHERE T1.ReembolsoId = :ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Y24,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001Y26", "SELECT COALESCE( T1.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F FROM (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa GROUP BY ReembolsoId ) T1 WHERE T1.ReembolsoId = :ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Y26,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001Y27", "SELECT PropostaValor AS ReembolsoPropostaValor, PropostaPacienteClienteId AS ReembolsoPropostaPacienteClienteId, PropostaClinicaId AS ReembolsoPropostaClinicaId FROM Proposta WHERE PropostaId = :ReembolsoPropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Y27,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001Y28", "SELECT ClienteRazaoSocial AS ReembolsoPropostaPacienteClienteRazaoSocial FROM Cliente WHERE ClienteId = :ReembolsoPropostaPacienteClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Y28,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001Y29", "SELECT WorkflowConvenioDesc FROM WorkflowConvenio WHERE WorkflowConvenioId = :WorkflowConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Y29,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001Y30", "SELECT ReembolsoFlowLogId FROM ReembolsoFlowLog WHERE ReembolsoLogId = :ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Y30,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001Y31", "SELECT ReembolsoParcelasId FROM ReembolsoParcelas WHERE ReembolsoId = :ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Y31,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001Y32", "SELECT ReembolsoAssinaturasId FROM ReembolsoAssinaturas WHERE ReembolsoId = :ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Y32,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001Y33", "SELECT ReembolsoEtapaId FROM ReembolsoEtapa WHERE ReembolsoId = :ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Y33,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001Y36", "SELECT TM1.ReembolsoId, TM1.ReembolsoCreatedAt, T5.ClienteRazaoSocial AS ReembolsoPropostaPacienteClienteRazaoSocial, TM1.ReembolsoProtocolo, T4.PropostaValor AS ReembolsoPropostaValor, TM1.ReembolsoDataAberturaConvenio, T6.WorkflowConvenioDesc, TM1.WorkflowConvenioId, TM1.ReembolsoPropostaId AS ReembolsoPropostaId, TM1.ReembolsoCreatedBy AS ReembolsoCreatedBy, T4.PropostaPacienteClienteId AS ReembolsoPropostaPacienteClienteId, T4.PropostaClinicaId AS ReembolsoPropostaClinicaId, COALESCE( T2.ReembolsoValorReembolsado_F, 0) AS ReembolsoValorReembolsado_F, COALESCE( T3.ReembolsoEtapaUltimo_F, DATE '00010101') AS ReembolsoEtapaUltimo_F FROM (((((Reembolso TM1 LEFT JOIN LATERAL (SELECT SUM(ReembolsoParcelasValor) AS ReembolsoValorReembolsado_F, ReembolsoId FROM ReembolsoParcelas WHERE TM1.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T2 ON T2.ReembolsoId = TM1.ReembolsoId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoEtapaCreatedAt) AS ReembolsoEtapaUltimo_F, ReembolsoId FROM ReembolsoEtapa WHERE TM1.ReembolsoId = ReembolsoId GROUP BY ReembolsoId ) T3 ON T3.ReembolsoId = TM1.ReembolsoId) LEFT JOIN Proposta T4 ON T4.PropostaId = TM1.ReembolsoPropostaId) LEFT JOIN Cliente T5 ON T5.ClienteId = T4.PropostaPacienteClienteId) LEFT JOIN WorkflowConvenio T6 ON T6.WorkflowConvenioId = TM1.WorkflowConvenioId) WHERE TM1.ReembolsoId = :ReembolsoId ORDER BY TM1.ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001Y36,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 7 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 8 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
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
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((short[]) buf[17])[0] = rslt.getShort(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 15 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 16 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 17 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 24 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((short[]) buf[17])[0] = rslt.getShort(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                return;
       }
    }

 }

}
