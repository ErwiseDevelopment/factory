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
   public class propostanota_bc : GxSilentTrn, IGxSilentTrn
   {
      public propostanota_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public propostanota_bc( IGxContext context )
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
         ReadRow2S49( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2S49( ) ;
         standaloneModal( ) ;
         AddRow2S49( ) ;
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
            E112S2 ();
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

      protected void CONFIRM_2S0( )
      {
         BeforeValidate2S49( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2S49( ) ;
            }
            else
            {
               CheckExtendedTable2S49( ) ;
               if ( AnyError == 0 )
               {
                  ZM2S49( 7) ;
                  ZM2S49( 8) ;
               }
               CloseExtendedTableCursors2S49( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E122S2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV20Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV21GXV1 = 1;
            while ( AV21GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV21GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "PropostaEmpresaClienteId") == 0 )
               {
                  AV11Insert_PropostaEmpresaClienteId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV21GXV1 = (int)(AV21GXV1+1);
            }
         }
      }

      protected void E112S2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM2S49( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z327PropostaCreatedAt = A327PropostaCreatedAt;
            Z853PropostaProtocolo = A853PropostaProtocolo;
            Z849PropostaTipoProposta = A849PropostaTipoProposta;
            Z329PropostaStatus = A329PropostaStatus;
            Z850PropostaEmpresaClienteId = A850PropostaEmpresaClienteId;
            Z854PropostaQtdItensNota_F = A854PropostaQtdItensNota_F;
            Z887PropostaSumItensnota_F = A887PropostaSumItensnota_F;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z888PropostaEmpresaRazao = A888PropostaEmpresaRazao;
            Z854PropostaQtdItensNota_F = A854PropostaQtdItensNota_F;
            Z887PropostaSumItensnota_F = A887PropostaSumItensnota_F;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z854PropostaQtdItensNota_F = A854PropostaQtdItensNota_F;
            Z887PropostaSumItensnota_F = A887PropostaSumItensnota_F;
         }
         if ( GX_JID == -6 )
         {
            Z323PropostaId = A323PropostaId;
            Z327PropostaCreatedAt = A327PropostaCreatedAt;
            Z853PropostaProtocolo = A853PropostaProtocolo;
            Z849PropostaTipoProposta = A849PropostaTipoProposta;
            Z329PropostaStatus = A329PropostaStatus;
            Z850PropostaEmpresaClienteId = A850PropostaEmpresaClienteId;
            Z854PropostaQtdItensNota_F = A854PropostaQtdItensNota_F;
            Z887PropostaSumItensnota_F = A887PropostaSumItensnota_F;
            Z888PropostaEmpresaRazao = A888PropostaEmpresaRazao;
         }
      }

      protected void standaloneNotModal( )
      {
         AV20Pgmname = "PropostaNota_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A327PropostaCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n327PropostaCreatedAt = false;
         }
      }

      protected void Load2S49( )
      {
         /* Using cursor BC002S8 */
         pr_default.execute(4, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound49 = 1;
            A327PropostaCreatedAt = BC002S8_A327PropostaCreatedAt[0];
            n327PropostaCreatedAt = BC002S8_n327PropostaCreatedAt[0];
            A853PropostaProtocolo = BC002S8_A853PropostaProtocolo[0];
            n853PropostaProtocolo = BC002S8_n853PropostaProtocolo[0];
            A849PropostaTipoProposta = BC002S8_A849PropostaTipoProposta[0];
            n849PropostaTipoProposta = BC002S8_n849PropostaTipoProposta[0];
            A888PropostaEmpresaRazao = BC002S8_A888PropostaEmpresaRazao[0];
            n888PropostaEmpresaRazao = BC002S8_n888PropostaEmpresaRazao[0];
            A329PropostaStatus = BC002S8_A329PropostaStatus[0];
            n329PropostaStatus = BC002S8_n329PropostaStatus[0];
            A850PropostaEmpresaClienteId = BC002S8_A850PropostaEmpresaClienteId[0];
            n850PropostaEmpresaClienteId = BC002S8_n850PropostaEmpresaClienteId[0];
            A854PropostaQtdItensNota_F = BC002S8_A854PropostaQtdItensNota_F[0];
            A887PropostaSumItensnota_F = BC002S8_A887PropostaSumItensnota_F[0];
            ZM2S49( -6) ;
         }
         pr_default.close(4);
         OnLoadActions2S49( ) ;
      }

      protected void OnLoadActions2S49( )
      {
      }

      protected void CheckExtendedTable2S49( )
      {
         standaloneModal( ) ;
         /* Using cursor BC002S6 */
         pr_default.execute(3, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            A854PropostaQtdItensNota_F = BC002S6_A854PropostaQtdItensNota_F[0];
            A887PropostaSumItensnota_F = BC002S6_A887PropostaSumItensnota_F[0];
         }
         else
         {
            A854PropostaQtdItensNota_F = 0;
            A887PropostaSumItensnota_F = 0;
         }
         pr_default.close(3);
         if ( ! ( ( StringUtil.StrCmp(A849PropostaTipoProposta, "CLINICA") == 0 ) || ( StringUtil.StrCmp(A849PropostaTipoProposta, "COMPRA_TITULO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A849PropostaTipoProposta)) ) )
         {
            GX_msglist.addItem("Campo Proposta Tipo Proposta fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC002S4 */
         pr_default.execute(2, new Object[] {n850PropostaEmpresaClienteId, A850PropostaEmpresaClienteId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A850PropostaEmpresaClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Sd Proposta Empresa'.", "ForeignKeyNotFound", 1, "PROPOSTAEMPRESACLIENTEID");
               AnyError = 1;
            }
         }
         A888PropostaEmpresaRazao = BC002S4_A888PropostaEmpresaRazao[0];
         n888PropostaEmpresaRazao = BC002S4_n888PropostaEmpresaRazao[0];
         pr_default.close(2);
         if ( ! ( ( StringUtil.StrCmp(A329PropostaStatus, "PENDENTE") == 0 ) || ( StringUtil.StrCmp(A329PropostaStatus, "EM_ANALISE") == 0 ) || ( StringUtil.StrCmp(A329PropostaStatus, "APROVADO") == 0 ) || ( StringUtil.StrCmp(A329PropostaStatus, "REJEITADO") == 0 ) || ( StringUtil.StrCmp(A329PropostaStatus, "REVISAO") == 0 ) || ( StringUtil.StrCmp(A329PropostaStatus, "CANCELADO") == 0 ) || ( StringUtil.StrCmp(A329PropostaStatus, "AGUARDANDO_ASSINATURA") == 0 ) || ( StringUtil.StrCmp(A329PropostaStatus, "AnaliseReprovada") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A329PropostaStatus)) ) )
         {
            GX_msglist.addItem("Campo Proposta Status fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors2S49( )
      {
         pr_default.close(3);
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2S49( )
      {
         /* Using cursor BC002S9 */
         pr_default.execute(5, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound49 = 1;
         }
         else
         {
            RcdFound49 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC002S3 */
         pr_default.execute(1, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2S49( 6) ;
            RcdFound49 = 1;
            A323PropostaId = BC002S3_A323PropostaId[0];
            n323PropostaId = BC002S3_n323PropostaId[0];
            A327PropostaCreatedAt = BC002S3_A327PropostaCreatedAt[0];
            n327PropostaCreatedAt = BC002S3_n327PropostaCreatedAt[0];
            A853PropostaProtocolo = BC002S3_A853PropostaProtocolo[0];
            n853PropostaProtocolo = BC002S3_n853PropostaProtocolo[0];
            A849PropostaTipoProposta = BC002S3_A849PropostaTipoProposta[0];
            n849PropostaTipoProposta = BC002S3_n849PropostaTipoProposta[0];
            A329PropostaStatus = BC002S3_A329PropostaStatus[0];
            n329PropostaStatus = BC002S3_n329PropostaStatus[0];
            A850PropostaEmpresaClienteId = BC002S3_A850PropostaEmpresaClienteId[0];
            n850PropostaEmpresaClienteId = BC002S3_n850PropostaEmpresaClienteId[0];
            Z323PropostaId = A323PropostaId;
            sMode49 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2S49( ) ;
            if ( AnyError == 1 )
            {
               RcdFound49 = 0;
               InitializeNonKey2S49( ) ;
            }
            Gx_mode = sMode49;
         }
         else
         {
            RcdFound49 = 0;
            InitializeNonKey2S49( ) ;
            sMode49 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode49;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2S49( ) ;
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
         CONFIRM_2S0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2S49( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC002S2 */
            pr_default.execute(0, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Proposta"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z327PropostaCreatedAt != BC002S2_A327PropostaCreatedAt[0] ) || ( StringUtil.StrCmp(Z853PropostaProtocolo, BC002S2_A853PropostaProtocolo[0]) != 0 ) || ( StringUtil.StrCmp(Z849PropostaTipoProposta, BC002S2_A849PropostaTipoProposta[0]) != 0 ) || ( StringUtil.StrCmp(Z329PropostaStatus, BC002S2_A329PropostaStatus[0]) != 0 ) || ( Z850PropostaEmpresaClienteId != BC002S2_A850PropostaEmpresaClienteId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Proposta"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2S49( )
      {
         BeforeValidate2S49( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2S49( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2S49( 0) ;
            CheckOptimisticConcurrency2S49( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2S49( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2S49( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002S10 */
                     pr_default.execute(6, new Object[] {n327PropostaCreatedAt, A327PropostaCreatedAt, n853PropostaProtocolo, A853PropostaProtocolo, n849PropostaTipoProposta, A849PropostaTipoProposta, n329PropostaStatus, A329PropostaStatus, n850PropostaEmpresaClienteId, A850PropostaEmpresaClienteId});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC002S11 */
                     pr_default.execute(7);
                     A323PropostaId = BC002S11_A323PropostaId[0];
                     n323PropostaId = BC002S11_n323PropostaId[0];
                     pr_default.close(7);
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
               Load2S49( ) ;
            }
            EndLevel2S49( ) ;
         }
         CloseExtendedTableCursors2S49( ) ;
      }

      protected void Update2S49( )
      {
         BeforeValidate2S49( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2S49( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2S49( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2S49( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2S49( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002S12 */
                     pr_default.execute(8, new Object[] {n327PropostaCreatedAt, A327PropostaCreatedAt, n853PropostaProtocolo, A853PropostaProtocolo, n849PropostaTipoProposta, A849PropostaTipoProposta, n329PropostaStatus, A329PropostaStatus, n850PropostaEmpresaClienteId, A850PropostaEmpresaClienteId, n323PropostaId, A323PropostaId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Proposta");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Proposta"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2S49( ) ;
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
            EndLevel2S49( ) ;
         }
         CloseExtendedTableCursors2S49( ) ;
      }

      protected void DeferredUpdate2S49( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2S49( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2S49( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2S49( ) ;
            AfterConfirm2S49( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2S49( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002S13 */
                  pr_default.execute(9, new Object[] {n323PropostaId, A323PropostaId});
                  pr_default.close(9);
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
         EndLevel2S49( ) ;
         Gx_mode = sMode49;
      }

      protected void OnDeleteControls2S49( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC002S15 */
            pr_default.execute(10, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               A854PropostaQtdItensNota_F = BC002S15_A854PropostaQtdItensNota_F[0];
               A887PropostaSumItensnota_F = BC002S15_A887PropostaSumItensnota_F[0];
            }
            else
            {
               A854PropostaQtdItensNota_F = 0;
               A887PropostaSumItensnota_F = 0;
            }
            pr_default.close(10);
            /* Using cursor BC002S16 */
            pr_default.execute(11, new Object[] {n850PropostaEmpresaClienteId, A850PropostaEmpresaClienteId});
            A888PropostaEmpresaRazao = BC002S16_A888PropostaEmpresaRazao[0];
            n888PropostaEmpresaRazao = BC002S16_n888PropostaEmpresaRazao[0];
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC002S17 */
            pr_default.execute(12, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Contrato"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor BC002S18 */
            pr_default.execute(13, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Reembolso"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor BC002S19 */
            pr_default.execute(14, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Titulo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor BC002S20 */
            pr_default.execute(15, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"NotaFiscalItem"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor BC002S21 */
            pr_default.execute(16, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"PropostaContratoAssinatura"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor BC002S22 */
            pr_default.execute(17, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"PropostaDocumentos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor BC002S23 */
            pr_default.execute(18, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Aprovacao"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
         }
      }

      protected void EndLevel2S49( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2S49( ) ;
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

      public void ScanKeyStart2S49( )
      {
         /* Scan By routine */
         /* Using cursor BC002S25 */
         pr_default.execute(19, new Object[] {n323PropostaId, A323PropostaId});
         RcdFound49 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound49 = 1;
            A323PropostaId = BC002S25_A323PropostaId[0];
            n323PropostaId = BC002S25_n323PropostaId[0];
            A327PropostaCreatedAt = BC002S25_A327PropostaCreatedAt[0];
            n327PropostaCreatedAt = BC002S25_n327PropostaCreatedAt[0];
            A853PropostaProtocolo = BC002S25_A853PropostaProtocolo[0];
            n853PropostaProtocolo = BC002S25_n853PropostaProtocolo[0];
            A849PropostaTipoProposta = BC002S25_A849PropostaTipoProposta[0];
            n849PropostaTipoProposta = BC002S25_n849PropostaTipoProposta[0];
            A888PropostaEmpresaRazao = BC002S25_A888PropostaEmpresaRazao[0];
            n888PropostaEmpresaRazao = BC002S25_n888PropostaEmpresaRazao[0];
            A329PropostaStatus = BC002S25_A329PropostaStatus[0];
            n329PropostaStatus = BC002S25_n329PropostaStatus[0];
            A850PropostaEmpresaClienteId = BC002S25_A850PropostaEmpresaClienteId[0];
            n850PropostaEmpresaClienteId = BC002S25_n850PropostaEmpresaClienteId[0];
            A854PropostaQtdItensNota_F = BC002S25_A854PropostaQtdItensNota_F[0];
            A887PropostaSumItensnota_F = BC002S25_A887PropostaSumItensnota_F[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2S49( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound49 = 0;
         ScanKeyLoad2S49( ) ;
      }

      protected void ScanKeyLoad2S49( )
      {
         sMode49 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound49 = 1;
            A323PropostaId = BC002S25_A323PropostaId[0];
            n323PropostaId = BC002S25_n323PropostaId[0];
            A327PropostaCreatedAt = BC002S25_A327PropostaCreatedAt[0];
            n327PropostaCreatedAt = BC002S25_n327PropostaCreatedAt[0];
            A853PropostaProtocolo = BC002S25_A853PropostaProtocolo[0];
            n853PropostaProtocolo = BC002S25_n853PropostaProtocolo[0];
            A849PropostaTipoProposta = BC002S25_A849PropostaTipoProposta[0];
            n849PropostaTipoProposta = BC002S25_n849PropostaTipoProposta[0];
            A888PropostaEmpresaRazao = BC002S25_A888PropostaEmpresaRazao[0];
            n888PropostaEmpresaRazao = BC002S25_n888PropostaEmpresaRazao[0];
            A329PropostaStatus = BC002S25_A329PropostaStatus[0];
            n329PropostaStatus = BC002S25_n329PropostaStatus[0];
            A850PropostaEmpresaClienteId = BC002S25_A850PropostaEmpresaClienteId[0];
            n850PropostaEmpresaClienteId = BC002S25_n850PropostaEmpresaClienteId[0];
            A854PropostaQtdItensNota_F = BC002S25_A854PropostaQtdItensNota_F[0];
            A887PropostaSumItensnota_F = BC002S25_A887PropostaSumItensnota_F[0];
         }
         Gx_mode = sMode49;
      }

      protected void ScanKeyEnd2S49( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm2S49( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2S49( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2S49( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2S49( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2S49( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2S49( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2S49( )
      {
      }

      protected void send_integrity_lvl_hashes2S49( )
      {
      }

      protected void AddRow2S49( )
      {
         VarsToRow49( bcPropostaNota) ;
      }

      protected void ReadRow2S49( )
      {
         RowToVars49( bcPropostaNota, 1) ;
      }

      protected void InitializeNonKey2S49( )
      {
         A327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         n327PropostaCreatedAt = false;
         A854PropostaQtdItensNota_F = 0;
         A853PropostaProtocolo = "";
         n853PropostaProtocolo = false;
         A849PropostaTipoProposta = "";
         n849PropostaTipoProposta = false;
         A887PropostaSumItensnota_F = 0;
         A850PropostaEmpresaClienteId = 0;
         n850PropostaEmpresaClienteId = false;
         A888PropostaEmpresaRazao = "";
         n888PropostaEmpresaRazao = false;
         A329PropostaStatus = "";
         n329PropostaStatus = false;
         Z327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         Z853PropostaProtocolo = "";
         Z849PropostaTipoProposta = "";
         Z329PropostaStatus = "";
         Z850PropostaEmpresaClienteId = 0;
      }

      protected void InitAll2S49( )
      {
         A323PropostaId = 0;
         n323PropostaId = false;
         InitializeNonKey2S49( ) ;
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

      public void VarsToRow49( SdtPropostaNota obj49 )
      {
         obj49.gxTpr_Mode = Gx_mode;
         obj49.gxTpr_Propostacreatedat = A327PropostaCreatedAt;
         obj49.gxTpr_Propostaqtditensnota_f = A854PropostaQtdItensNota_F;
         obj49.gxTpr_Propostaprotocolo = A853PropostaProtocolo;
         obj49.gxTpr_Propostatipoproposta = A849PropostaTipoProposta;
         obj49.gxTpr_Propostasumitensnota_f = A887PropostaSumItensnota_F;
         obj49.gxTpr_Propostaempresaclienteid = A850PropostaEmpresaClienteId;
         obj49.gxTpr_Propostaempresarazao = A888PropostaEmpresaRazao;
         obj49.gxTpr_Propostastatus = A329PropostaStatus;
         obj49.gxTpr_Propostaid = A323PropostaId;
         obj49.gxTpr_Propostaid_Z = Z323PropostaId;
         obj49.gxTpr_Propostaqtditensnota_f_Z = Z854PropostaQtdItensNota_F;
         obj49.gxTpr_Propostaprotocolo_Z = Z853PropostaProtocolo;
         obj49.gxTpr_Propostatipoproposta_Z = Z849PropostaTipoProposta;
         obj49.gxTpr_Propostasumitensnota_f_Z = Z887PropostaSumItensnota_F;
         obj49.gxTpr_Propostaempresaclienteid_Z = Z850PropostaEmpresaClienteId;
         obj49.gxTpr_Propostaempresarazao_Z = Z888PropostaEmpresaRazao;
         obj49.gxTpr_Propostacreatedat_Z = Z327PropostaCreatedAt;
         obj49.gxTpr_Propostastatus_Z = Z329PropostaStatus;
         obj49.gxTpr_Propostaid_N = (short)(Convert.ToInt16(n323PropostaId));
         obj49.gxTpr_Propostaprotocolo_N = (short)(Convert.ToInt16(n853PropostaProtocolo));
         obj49.gxTpr_Propostatipoproposta_N = (short)(Convert.ToInt16(n849PropostaTipoProposta));
         obj49.gxTpr_Propostaempresaclienteid_N = (short)(Convert.ToInt16(n850PropostaEmpresaClienteId));
         obj49.gxTpr_Propostaempresarazao_N = (short)(Convert.ToInt16(n888PropostaEmpresaRazao));
         obj49.gxTpr_Propostacreatedat_N = (short)(Convert.ToInt16(n327PropostaCreatedAt));
         obj49.gxTpr_Propostastatus_N = (short)(Convert.ToInt16(n329PropostaStatus));
         obj49.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow49( SdtPropostaNota obj49 )
      {
         obj49.gxTpr_Propostaid = A323PropostaId;
         return  ;
      }

      public void RowToVars49( SdtPropostaNota obj49 ,
                               int forceLoad )
      {
         Gx_mode = obj49.gxTpr_Mode;
         A327PropostaCreatedAt = obj49.gxTpr_Propostacreatedat;
         n327PropostaCreatedAt = false;
         A854PropostaQtdItensNota_F = obj49.gxTpr_Propostaqtditensnota_f;
         A853PropostaProtocolo = obj49.gxTpr_Propostaprotocolo;
         n853PropostaProtocolo = false;
         A849PropostaTipoProposta = obj49.gxTpr_Propostatipoproposta;
         n849PropostaTipoProposta = false;
         A887PropostaSumItensnota_F = obj49.gxTpr_Propostasumitensnota_f;
         A850PropostaEmpresaClienteId = obj49.gxTpr_Propostaempresaclienteid;
         n850PropostaEmpresaClienteId = false;
         A888PropostaEmpresaRazao = obj49.gxTpr_Propostaempresarazao;
         n888PropostaEmpresaRazao = false;
         A329PropostaStatus = obj49.gxTpr_Propostastatus;
         n329PropostaStatus = false;
         A323PropostaId = obj49.gxTpr_Propostaid;
         n323PropostaId = false;
         Z323PropostaId = obj49.gxTpr_Propostaid_Z;
         Z854PropostaQtdItensNota_F = obj49.gxTpr_Propostaqtditensnota_f_Z;
         Z853PropostaProtocolo = obj49.gxTpr_Propostaprotocolo_Z;
         Z849PropostaTipoProposta = obj49.gxTpr_Propostatipoproposta_Z;
         Z887PropostaSumItensnota_F = obj49.gxTpr_Propostasumitensnota_f_Z;
         Z850PropostaEmpresaClienteId = obj49.gxTpr_Propostaempresaclienteid_Z;
         Z888PropostaEmpresaRazao = obj49.gxTpr_Propostaempresarazao_Z;
         Z327PropostaCreatedAt = obj49.gxTpr_Propostacreatedat_Z;
         Z329PropostaStatus = obj49.gxTpr_Propostastatus_Z;
         n323PropostaId = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostaid_N));
         n853PropostaProtocolo = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostaprotocolo_N));
         n849PropostaTipoProposta = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostatipoproposta_N));
         n850PropostaEmpresaClienteId = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostaempresaclienteid_N));
         n888PropostaEmpresaRazao = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostaempresarazao_N));
         n327PropostaCreatedAt = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostacreatedat_N));
         n329PropostaStatus = (bool)(Convert.ToBoolean(obj49.gxTpr_Propostastatus_N));
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
         InitializeNonKey2S49( ) ;
         ScanKeyStart2S49( ) ;
         if ( RcdFound49 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z323PropostaId = A323PropostaId;
         }
         ZM2S49( -6) ;
         OnLoadActions2S49( ) ;
         AddRow2S49( ) ;
         ScanKeyEnd2S49( ) ;
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
         RowToVars49( bcPropostaNota, 0) ;
         ScanKeyStart2S49( ) ;
         if ( RcdFound49 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z323PropostaId = A323PropostaId;
         }
         ZM2S49( -6) ;
         OnLoadActions2S49( ) ;
         AddRow2S49( ) ;
         ScanKeyEnd2S49( ) ;
         if ( RcdFound49 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2S49( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2S49( ) ;
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
                  Update2S49( ) ;
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
                        Insert2S49( ) ;
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
                        Insert2S49( ) ;
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
         RowToVars49( bcPropostaNota, 1) ;
         SaveImpl( ) ;
         VarsToRow49( bcPropostaNota) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars49( bcPropostaNota, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2S49( ) ;
         AfterTrn( ) ;
         VarsToRow49( bcPropostaNota) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow49( bcPropostaNota) ;
         }
         else
         {
            SdtPropostaNota auxBC = new SdtPropostaNota(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A323PropostaId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcPropostaNota);
               auxBC.Save();
               bcPropostaNota.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars49( bcPropostaNota, 1) ;
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
         RowToVars49( bcPropostaNota, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2S49( ) ;
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
               VarsToRow49( bcPropostaNota) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow49( bcPropostaNota) ;
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
         RowToVars49( bcPropostaNota, 0) ;
         GetKey2S49( ) ;
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
         context.RollbackDataStores("propostanota_bc",pr_default);
         VarsToRow49( bcPropostaNota) ;
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
         Gx_mode = bcPropostaNota.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcPropostaNota.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcPropostaNota )
         {
            bcPropostaNota = (SdtPropostaNota)(sdt);
            if ( StringUtil.StrCmp(bcPropostaNota.gxTpr_Mode, "") == 0 )
            {
               bcPropostaNota.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow49( bcPropostaNota) ;
            }
            else
            {
               RowToVars49( bcPropostaNota, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcPropostaNota.gxTpr_Mode, "") == 0 )
            {
               bcPropostaNota.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars49( bcPropostaNota, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtPropostaNota PropostaNota_BC
      {
         get {
            return bcPropostaNota ;
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
         pr_default.close(10);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV20Pgmname = "";
         AV12TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         A327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         Z853PropostaProtocolo = "";
         A853PropostaProtocolo = "";
         Z849PropostaTipoProposta = "";
         A849PropostaTipoProposta = "";
         Z329PropostaStatus = "";
         A329PropostaStatus = "";
         Z888PropostaEmpresaRazao = "";
         A888PropostaEmpresaRazao = "";
         BC002S8_A323PropostaId = new int[1] ;
         BC002S8_n323PropostaId = new bool[] {false} ;
         BC002S8_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002S8_n327PropostaCreatedAt = new bool[] {false} ;
         BC002S8_A853PropostaProtocolo = new string[] {""} ;
         BC002S8_n853PropostaProtocolo = new bool[] {false} ;
         BC002S8_A849PropostaTipoProposta = new string[] {""} ;
         BC002S8_n849PropostaTipoProposta = new bool[] {false} ;
         BC002S8_A888PropostaEmpresaRazao = new string[] {""} ;
         BC002S8_n888PropostaEmpresaRazao = new bool[] {false} ;
         BC002S8_A329PropostaStatus = new string[] {""} ;
         BC002S8_n329PropostaStatus = new bool[] {false} ;
         BC002S8_A850PropostaEmpresaClienteId = new int[1] ;
         BC002S8_n850PropostaEmpresaClienteId = new bool[] {false} ;
         BC002S8_A854PropostaQtdItensNota_F = new short[1] ;
         BC002S8_A887PropostaSumItensnota_F = new decimal[1] ;
         BC002S6_A854PropostaQtdItensNota_F = new short[1] ;
         BC002S6_A887PropostaSumItensnota_F = new decimal[1] ;
         BC002S4_A888PropostaEmpresaRazao = new string[] {""} ;
         BC002S4_n888PropostaEmpresaRazao = new bool[] {false} ;
         BC002S9_A323PropostaId = new int[1] ;
         BC002S9_n323PropostaId = new bool[] {false} ;
         BC002S3_A323PropostaId = new int[1] ;
         BC002S3_n323PropostaId = new bool[] {false} ;
         BC002S3_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002S3_n327PropostaCreatedAt = new bool[] {false} ;
         BC002S3_A853PropostaProtocolo = new string[] {""} ;
         BC002S3_n853PropostaProtocolo = new bool[] {false} ;
         BC002S3_A849PropostaTipoProposta = new string[] {""} ;
         BC002S3_n849PropostaTipoProposta = new bool[] {false} ;
         BC002S3_A329PropostaStatus = new string[] {""} ;
         BC002S3_n329PropostaStatus = new bool[] {false} ;
         BC002S3_A850PropostaEmpresaClienteId = new int[1] ;
         BC002S3_n850PropostaEmpresaClienteId = new bool[] {false} ;
         sMode49 = "";
         BC002S2_A323PropostaId = new int[1] ;
         BC002S2_n323PropostaId = new bool[] {false} ;
         BC002S2_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002S2_n327PropostaCreatedAt = new bool[] {false} ;
         BC002S2_A853PropostaProtocolo = new string[] {""} ;
         BC002S2_n853PropostaProtocolo = new bool[] {false} ;
         BC002S2_A849PropostaTipoProposta = new string[] {""} ;
         BC002S2_n849PropostaTipoProposta = new bool[] {false} ;
         BC002S2_A329PropostaStatus = new string[] {""} ;
         BC002S2_n329PropostaStatus = new bool[] {false} ;
         BC002S2_A850PropostaEmpresaClienteId = new int[1] ;
         BC002S2_n850PropostaEmpresaClienteId = new bool[] {false} ;
         BC002S11_A323PropostaId = new int[1] ;
         BC002S11_n323PropostaId = new bool[] {false} ;
         BC002S15_A854PropostaQtdItensNota_F = new short[1] ;
         BC002S15_A887PropostaSumItensnota_F = new decimal[1] ;
         BC002S16_A888PropostaEmpresaRazao = new string[] {""} ;
         BC002S16_n888PropostaEmpresaRazao = new bool[] {false} ;
         BC002S17_A227ContratoId = new int[1] ;
         BC002S17_n227ContratoId = new bool[] {false} ;
         BC002S18_A518ReembolsoId = new int[1] ;
         BC002S19_A261TituloId = new int[1] ;
         BC002S20_A830NotaFiscalItemId = new Guid[] {Guid.Empty} ;
         BC002S21_A572PropostaContratoAssinaturaId = new int[1] ;
         BC002S22_A414PropostaDocumentosId = new int[1] ;
         BC002S23_A336AprovacaoId = new int[1] ;
         BC002S25_A323PropostaId = new int[1] ;
         BC002S25_n323PropostaId = new bool[] {false} ;
         BC002S25_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002S25_n327PropostaCreatedAt = new bool[] {false} ;
         BC002S25_A853PropostaProtocolo = new string[] {""} ;
         BC002S25_n853PropostaProtocolo = new bool[] {false} ;
         BC002S25_A849PropostaTipoProposta = new string[] {""} ;
         BC002S25_n849PropostaTipoProposta = new bool[] {false} ;
         BC002S25_A888PropostaEmpresaRazao = new string[] {""} ;
         BC002S25_n888PropostaEmpresaRazao = new bool[] {false} ;
         BC002S25_A329PropostaStatus = new string[] {""} ;
         BC002S25_n329PropostaStatus = new bool[] {false} ;
         BC002S25_A850PropostaEmpresaClienteId = new int[1] ;
         BC002S25_n850PropostaEmpresaClienteId = new bool[] {false} ;
         BC002S25_A854PropostaQtdItensNota_F = new short[1] ;
         BC002S25_A887PropostaSumItensnota_F = new decimal[1] ;
         i327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.propostanota_bc__default(),
            new Object[][] {
                new Object[] {
               BC002S2_A323PropostaId, BC002S2_A327PropostaCreatedAt, BC002S2_n327PropostaCreatedAt, BC002S2_A853PropostaProtocolo, BC002S2_n853PropostaProtocolo, BC002S2_A849PropostaTipoProposta, BC002S2_n849PropostaTipoProposta, BC002S2_A329PropostaStatus, BC002S2_n329PropostaStatus, BC002S2_A850PropostaEmpresaClienteId,
               BC002S2_n850PropostaEmpresaClienteId
               }
               , new Object[] {
               BC002S3_A323PropostaId, BC002S3_A327PropostaCreatedAt, BC002S3_n327PropostaCreatedAt, BC002S3_A853PropostaProtocolo, BC002S3_n853PropostaProtocolo, BC002S3_A849PropostaTipoProposta, BC002S3_n849PropostaTipoProposta, BC002S3_A329PropostaStatus, BC002S3_n329PropostaStatus, BC002S3_A850PropostaEmpresaClienteId,
               BC002S3_n850PropostaEmpresaClienteId
               }
               , new Object[] {
               BC002S4_A888PropostaEmpresaRazao, BC002S4_n888PropostaEmpresaRazao
               }
               , new Object[] {
               BC002S6_A854PropostaQtdItensNota_F, BC002S6_A887PropostaSumItensnota_F
               }
               , new Object[] {
               BC002S8_A323PropostaId, BC002S8_A327PropostaCreatedAt, BC002S8_n327PropostaCreatedAt, BC002S8_A853PropostaProtocolo, BC002S8_n853PropostaProtocolo, BC002S8_A849PropostaTipoProposta, BC002S8_n849PropostaTipoProposta, BC002S8_A888PropostaEmpresaRazao, BC002S8_n888PropostaEmpresaRazao, BC002S8_A329PropostaStatus,
               BC002S8_n329PropostaStatus, BC002S8_A850PropostaEmpresaClienteId, BC002S8_n850PropostaEmpresaClienteId, BC002S8_A854PropostaQtdItensNota_F, BC002S8_A887PropostaSumItensnota_F
               }
               , new Object[] {
               BC002S9_A323PropostaId
               }
               , new Object[] {
               }
               , new Object[] {
               BC002S11_A323PropostaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002S15_A854PropostaQtdItensNota_F, BC002S15_A887PropostaSumItensnota_F
               }
               , new Object[] {
               BC002S16_A888PropostaEmpresaRazao, BC002S16_n888PropostaEmpresaRazao
               }
               , new Object[] {
               BC002S17_A227ContratoId
               }
               , new Object[] {
               BC002S18_A518ReembolsoId
               }
               , new Object[] {
               BC002S19_A261TituloId
               }
               , new Object[] {
               BC002S20_A830NotaFiscalItemId
               }
               , new Object[] {
               BC002S21_A572PropostaContratoAssinaturaId
               }
               , new Object[] {
               BC002S22_A414PropostaDocumentosId
               }
               , new Object[] {
               BC002S23_A336AprovacaoId
               }
               , new Object[] {
               BC002S25_A323PropostaId, BC002S25_A327PropostaCreatedAt, BC002S25_n327PropostaCreatedAt, BC002S25_A853PropostaProtocolo, BC002S25_n853PropostaProtocolo, BC002S25_A849PropostaTipoProposta, BC002S25_n849PropostaTipoProposta, BC002S25_A888PropostaEmpresaRazao, BC002S25_n888PropostaEmpresaRazao, BC002S25_A329PropostaStatus,
               BC002S25_n329PropostaStatus, BC002S25_A850PropostaEmpresaClienteId, BC002S25_n850PropostaEmpresaClienteId, BC002S25_A854PropostaQtdItensNota_F, BC002S25_A887PropostaSumItensnota_F
               }
            }
         );
         AV20Pgmname = "PropostaNota_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E122S2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z854PropostaQtdItensNota_F ;
      private short A854PropostaQtdItensNota_F ;
      private short RcdFound49 ;
      private int trnEnded ;
      private int Z323PropostaId ;
      private int A323PropostaId ;
      private int AV21GXV1 ;
      private int AV11Insert_PropostaEmpresaClienteId ;
      private int Z850PropostaEmpresaClienteId ;
      private int A850PropostaEmpresaClienteId ;
      private decimal Z887PropostaSumItensnota_F ;
      private decimal A887PropostaSumItensnota_F ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV20Pgmname ;
      private string sMode49 ;
      private DateTime Z327PropostaCreatedAt ;
      private DateTime A327PropostaCreatedAt ;
      private DateTime i327PropostaCreatedAt ;
      private bool returnInSub ;
      private bool n327PropostaCreatedAt ;
      private bool n323PropostaId ;
      private bool n853PropostaProtocolo ;
      private bool n849PropostaTipoProposta ;
      private bool n888PropostaEmpresaRazao ;
      private bool n329PropostaStatus ;
      private bool n850PropostaEmpresaClienteId ;
      private string Z853PropostaProtocolo ;
      private string A853PropostaProtocolo ;
      private string Z849PropostaTipoProposta ;
      private string A849PropostaTipoProposta ;
      private string Z329PropostaStatus ;
      private string A329PropostaStatus ;
      private string Z888PropostaEmpresaRazao ;
      private string A888PropostaEmpresaRazao ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] BC002S8_A323PropostaId ;
      private bool[] BC002S8_n323PropostaId ;
      private DateTime[] BC002S8_A327PropostaCreatedAt ;
      private bool[] BC002S8_n327PropostaCreatedAt ;
      private string[] BC002S8_A853PropostaProtocolo ;
      private bool[] BC002S8_n853PropostaProtocolo ;
      private string[] BC002S8_A849PropostaTipoProposta ;
      private bool[] BC002S8_n849PropostaTipoProposta ;
      private string[] BC002S8_A888PropostaEmpresaRazao ;
      private bool[] BC002S8_n888PropostaEmpresaRazao ;
      private string[] BC002S8_A329PropostaStatus ;
      private bool[] BC002S8_n329PropostaStatus ;
      private int[] BC002S8_A850PropostaEmpresaClienteId ;
      private bool[] BC002S8_n850PropostaEmpresaClienteId ;
      private short[] BC002S8_A854PropostaQtdItensNota_F ;
      private decimal[] BC002S8_A887PropostaSumItensnota_F ;
      private short[] BC002S6_A854PropostaQtdItensNota_F ;
      private decimal[] BC002S6_A887PropostaSumItensnota_F ;
      private string[] BC002S4_A888PropostaEmpresaRazao ;
      private bool[] BC002S4_n888PropostaEmpresaRazao ;
      private int[] BC002S9_A323PropostaId ;
      private bool[] BC002S9_n323PropostaId ;
      private int[] BC002S3_A323PropostaId ;
      private bool[] BC002S3_n323PropostaId ;
      private DateTime[] BC002S3_A327PropostaCreatedAt ;
      private bool[] BC002S3_n327PropostaCreatedAt ;
      private string[] BC002S3_A853PropostaProtocolo ;
      private bool[] BC002S3_n853PropostaProtocolo ;
      private string[] BC002S3_A849PropostaTipoProposta ;
      private bool[] BC002S3_n849PropostaTipoProposta ;
      private string[] BC002S3_A329PropostaStatus ;
      private bool[] BC002S3_n329PropostaStatus ;
      private int[] BC002S3_A850PropostaEmpresaClienteId ;
      private bool[] BC002S3_n850PropostaEmpresaClienteId ;
      private int[] BC002S2_A323PropostaId ;
      private bool[] BC002S2_n323PropostaId ;
      private DateTime[] BC002S2_A327PropostaCreatedAt ;
      private bool[] BC002S2_n327PropostaCreatedAt ;
      private string[] BC002S2_A853PropostaProtocolo ;
      private bool[] BC002S2_n853PropostaProtocolo ;
      private string[] BC002S2_A849PropostaTipoProposta ;
      private bool[] BC002S2_n849PropostaTipoProposta ;
      private string[] BC002S2_A329PropostaStatus ;
      private bool[] BC002S2_n329PropostaStatus ;
      private int[] BC002S2_A850PropostaEmpresaClienteId ;
      private bool[] BC002S2_n850PropostaEmpresaClienteId ;
      private int[] BC002S11_A323PropostaId ;
      private bool[] BC002S11_n323PropostaId ;
      private short[] BC002S15_A854PropostaQtdItensNota_F ;
      private decimal[] BC002S15_A887PropostaSumItensnota_F ;
      private string[] BC002S16_A888PropostaEmpresaRazao ;
      private bool[] BC002S16_n888PropostaEmpresaRazao ;
      private int[] BC002S17_A227ContratoId ;
      private bool[] BC002S17_n227ContratoId ;
      private int[] BC002S18_A518ReembolsoId ;
      private int[] BC002S19_A261TituloId ;
      private Guid[] BC002S20_A830NotaFiscalItemId ;
      private int[] BC002S21_A572PropostaContratoAssinaturaId ;
      private int[] BC002S22_A414PropostaDocumentosId ;
      private int[] BC002S23_A336AprovacaoId ;
      private int[] BC002S25_A323PropostaId ;
      private bool[] BC002S25_n323PropostaId ;
      private DateTime[] BC002S25_A327PropostaCreatedAt ;
      private bool[] BC002S25_n327PropostaCreatedAt ;
      private string[] BC002S25_A853PropostaProtocolo ;
      private bool[] BC002S25_n853PropostaProtocolo ;
      private string[] BC002S25_A849PropostaTipoProposta ;
      private bool[] BC002S25_n849PropostaTipoProposta ;
      private string[] BC002S25_A888PropostaEmpresaRazao ;
      private bool[] BC002S25_n888PropostaEmpresaRazao ;
      private string[] BC002S25_A329PropostaStatus ;
      private bool[] BC002S25_n329PropostaStatus ;
      private int[] BC002S25_A850PropostaEmpresaClienteId ;
      private bool[] BC002S25_n850PropostaEmpresaClienteId ;
      private short[] BC002S25_A854PropostaQtdItensNota_F ;
      private decimal[] BC002S25_A887PropostaSumItensnota_F ;
      private SdtPropostaNota bcPropostaNota ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class propostanota_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new UpdateCursor(def[9])
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC002S2;
          prmBC002S2 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002S3;
          prmBC002S3 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002S4;
          prmBC002S4 = new Object[] {
          new ParDef("PropostaEmpresaClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002S6;
          prmBC002S6 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002S8;
          prmBC002S8 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002S9;
          prmBC002S9 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002S10;
          prmBC002S10 = new Object[] {
          new ParDef("PropostaCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("PropostaProtocolo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("PropostaTipoProposta",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("PropostaStatus",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("PropostaEmpresaClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002S11;
          prmBC002S11 = new Object[] {
          };
          Object[] prmBC002S12;
          prmBC002S12 = new Object[] {
          new ParDef("PropostaCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("PropostaProtocolo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("PropostaTipoProposta",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("PropostaStatus",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("PropostaEmpresaClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002S13;
          prmBC002S13 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002S15;
          prmBC002S15 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002S16;
          prmBC002S16 = new Object[] {
          new ParDef("PropostaEmpresaClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002S17;
          prmBC002S17 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002S18;
          prmBC002S18 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002S19;
          prmBC002S19 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002S20;
          prmBC002S20 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002S21;
          prmBC002S21 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002S22;
          prmBC002S22 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002S23;
          prmBC002S23 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002S25;
          prmBC002S25 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC002S2", "SELECT PropostaId, PropostaCreatedAt, PropostaProtocolo, PropostaTipoProposta, PropostaStatus, PropostaEmpresaClienteId FROM Proposta WHERE PropostaId = :PropostaId  FOR UPDATE OF Proposta",true, GxErrorMask.GX_NOMASK, false, this,prmBC002S2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002S3", "SELECT PropostaId, PropostaCreatedAt, PropostaProtocolo, PropostaTipoProposta, PropostaStatus, PropostaEmpresaClienteId FROM Proposta WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002S3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002S4", "SELECT ClienteRazaoSocial AS PropostaEmpresaRazao FROM Cliente WHERE ClienteId = :PropostaEmpresaClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002S4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002S6", "SELECT COALESCE( T1.PropostaQtdItensNota_F, 0) AS PropostaQtdItensNota_F, COALESCE( T1.PropostaSumItensnota_F, 0) AS PropostaSumItensnota_F FROM (SELECT COUNT(*) AS PropostaQtdItensNota_F, PropostaId, SUM(NotaFiscalItemValorTotal) AS PropostaSumItensnota_F FROM NotaFiscalItem GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002S6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002S8", "SELECT TM1.PropostaId, TM1.PropostaCreatedAt, TM1.PropostaProtocolo, TM1.PropostaTipoProposta, T3.ClienteRazaoSocial AS PropostaEmpresaRazao, TM1.PropostaStatus, TM1.PropostaEmpresaClienteId AS PropostaEmpresaClienteId, COALESCE( T2.PropostaQtdItensNota_F, 0) AS PropostaQtdItensNota_F, COALESCE( T2.PropostaSumItensnota_F, 0) AS PropostaSumItensnota_F FROM ((Proposta TM1 LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaQtdItensNota_F, PropostaId, SUM(NotaFiscalItemValorTotal) AS PropostaSumItensnota_F FROM NotaFiscalItem WHERE TM1.PropostaId = PropostaId GROUP BY PropostaId ) T2 ON T2.PropostaId = TM1.PropostaId) LEFT JOIN Cliente T3 ON T3.ClienteId = TM1.PropostaEmpresaClienteId) WHERE TM1.PropostaId = :PropostaId ORDER BY TM1.PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002S8,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002S9", "SELECT PropostaId FROM Proposta WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002S9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002S10", "SAVEPOINT gxupdate;INSERT INTO Proposta(PropostaCreatedAt, PropostaProtocolo, PropostaTipoProposta, PropostaStatus, PropostaEmpresaClienteId, PropostaTitulo, PropostaDescricao, PropostaValor, PropostaCratedBy, ContratoId, PropostaQuantidadeAprovadores, PropostaReprovacoesPermitidas, ProcedimentosMedicosId, ConvenioVencimentoAno, ConvenioVencimentoMes, ConvenioCategoriaId, PropostaPacienteClienteId, PropostaTaxaAdministrativa, PropostaSLA, PropostaJurosMora, PropostaDataCirurgia, PropostaResponsavelId, PropostaClinicaId, PropostaComentarioAnalise, PropostaValorLiquido) VALUES(:PropostaCreatedAt, :PropostaProtocolo, :PropostaTipoProposta, :PropostaStatus, :PropostaEmpresaClienteId, '', '', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, DATE '00010101', 0, 0, '', 0);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC002S10)
             ,new CursorDef("BC002S11", "SELECT currval('PropostaId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002S11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002S12", "SAVEPOINT gxupdate;UPDATE Proposta SET PropostaCreatedAt=:PropostaCreatedAt, PropostaProtocolo=:PropostaProtocolo, PropostaTipoProposta=:PropostaTipoProposta, PropostaStatus=:PropostaStatus, PropostaEmpresaClienteId=:PropostaEmpresaClienteId  WHERE PropostaId = :PropostaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002S12)
             ,new CursorDef("BC002S13", "SAVEPOINT gxupdate;DELETE FROM Proposta  WHERE PropostaId = :PropostaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002S13)
             ,new CursorDef("BC002S15", "SELECT COALESCE( T1.PropostaQtdItensNota_F, 0) AS PropostaQtdItensNota_F, COALESCE( T1.PropostaSumItensnota_F, 0) AS PropostaSumItensnota_F FROM (SELECT COUNT(*) AS PropostaQtdItensNota_F, PropostaId, SUM(NotaFiscalItemValorTotal) AS PropostaSumItensnota_F FROM NotaFiscalItem GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002S15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002S16", "SELECT ClienteRazaoSocial AS PropostaEmpresaRazao FROM Cliente WHERE ClienteId = :PropostaEmpresaClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002S16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002S17", "SELECT ContratoId FROM Contrato WHERE ContratoPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002S17,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002S18", "SELECT ReembolsoId FROM Reembolso WHERE ReembolsoPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002S18,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002S19", "SELECT TituloId FROM Titulo WHERE TituloPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002S19,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002S20", "SELECT NotaFiscalItemId FROM NotaFiscalItem WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002S20,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002S21", "SELECT PropostaContratoAssinaturaId FROM PropostaContratoAssinatura WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002S21,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002S22", "SELECT PropostaDocumentosId FROM PropostaDocumentos WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002S22,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002S23", "SELECT AprovacaoId FROM Aprovacao WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002S23,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002S25", "SELECT TM1.PropostaId, TM1.PropostaCreatedAt, TM1.PropostaProtocolo, TM1.PropostaTipoProposta, T3.ClienteRazaoSocial AS PropostaEmpresaRazao, TM1.PropostaStatus, TM1.PropostaEmpresaClienteId AS PropostaEmpresaClienteId, COALESCE( T2.PropostaQtdItensNota_F, 0) AS PropostaQtdItensNota_F, COALESCE( T2.PropostaSumItensnota_F, 0) AS PropostaSumItensnota_F FROM ((Proposta TM1 LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaQtdItensNota_F, PropostaId, SUM(NotaFiscalItemValorTotal) AS PropostaSumItensnota_F FROM NotaFiscalItem WHERE TM1.PropostaId = PropostaId GROUP BY PropostaId ) T2 ON T2.PropostaId = TM1.PropostaId) LEFT JOIN Cliente T3 ON T3.ClienteId = TM1.PropostaEmpresaClienteId) WHERE TM1.PropostaId = :PropostaId ORDER BY TM1.PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002S25,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
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
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                return;
             case 4 :
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
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(9);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
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
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 15 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 16 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 17 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 18 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 19 :
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
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(9);
                return;
       }
    }

 }

}
