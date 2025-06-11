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
   public class serasa_bc : GxSilentTrn, IGxSilentTrn
   {
      public serasa_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public serasa_bc( IGxContext context )
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
         ReadRow2E84( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2E84( ) ;
         standaloneModal( ) ;
         AddRow2E84( ) ;
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
            E112E2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z662SerasaId = A662SerasaId;
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

      protected void CONFIRM_2E0( )
      {
         BeforeValidate2E84( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2E84( ) ;
            }
            else
            {
               CheckExtendedTable2E84( ) ;
               if ( AnyError == 0 )
               {
                  ZM2E84( 6) ;
                  ZM2E84( 7) ;
                  ZM2E84( 8) ;
                  ZM2E84( 9) ;
                  ZM2E84( 10) ;
                  ZM2E84( 11) ;
               }
               CloseExtendedTableCursors2E84( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E122E2( )
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
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "ClienteId") == 0 )
               {
                  AV11Insert_ClienteId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV20GXV1 = (int)(AV20GXV1+1);
            }
         }
      }

      protected void E112E2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM2E84( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z665SerasaCreatedAt = A665SerasaCreatedAt;
            Z663SerasaNumeroProposta = A663SerasaNumeroProposta;
            Z664SerasaPolitica = A664SerasaPolitica;
            Z666SerasaTipoVenda = A666SerasaTipoVenda;
            Z667SerasaCodTipoVenda = A667SerasaCodTipoVenda;
            Z668SerasaCodNivelRisco = A668SerasaCodNivelRisco;
            Z669SerasaTipoRecomendacao = A669SerasaTipoRecomendacao;
            Z670SerasaRecomendacaoVenda = A670SerasaRecomendacaoVenda;
            Z671SerasaCpfRegular = A671SerasaCpfRegular;
            Z672SerasaRetricaoAtiva = A672SerasaRetricaoAtiva;
            Z673SerasaProtestoAtivo = A673SerasaProtestoAtivo;
            Z674SerasaBaixoComprometimento = A674SerasaBaixoComprometimento;
            Z675SerasaValorLimiteRecomendado = A675SerasaValorLimiteRecomendado;
            Z676SerasaFaixaDeRendaEstimada = A676SerasaFaixaDeRendaEstimada;
            Z677SerasaMensagemRendaEstimada = A677SerasaMensagemRendaEstimada;
            Z678SerasaAnotacoesCompletas = A678SerasaAnotacoesCompletas;
            Z679SerasaConsultasDetalhadas = A679SerasaConsultasDetalhadas;
            Z680SerasaAnotacoesConsultaSPC = A680SerasaAnotacoesConsultaSPC;
            Z681SerasaParticipacaoSocietaria = A681SerasaParticipacaoSocietaria;
            Z682SerasaRendaEstimada = A682SerasaRendaEstimada;
            Z683SerasaHistoricoPagamentoPF = A683SerasaHistoricoPagamentoPF;
            Z684SerasaRecomendaCompleto = A684SerasaRecomendaCompleto;
            Z685SerasaScore = A685SerasaScore;
            Z686SerasaTaxa = A686SerasaTaxa;
            Z687SerasaMensagemScore = A687SerasaMensagemScore;
            Z688SerasaSituacaoCPF = A688SerasaSituacaoCPF;
            Z689SerasaDataNascimento = A689SerasaDataNascimento;
            Z690SerasaGenero = A690SerasaGenero;
            Z691SerasaNomeMae = A691SerasaNomeMae;
            Z692SerasaGrafia = A692SerasaGrafia;
            Z168ClienteId = A168ClienteId;
            Z775SerasaCountAcoes_F = A775SerasaCountAcoes_F;
            Z776SerasaCountEnderecos_F = A776SerasaCountEnderecos_F;
            Z777SerasaCountProtestos_F = A777SerasaCountProtestos_F;
            Z778SerasaCountOcorrencias_F = A778SerasaCountOcorrencias_F;
            Z779SerasaCountCheques_F = A779SerasaCountCheques_F;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z170ClienteRazaoSocial = A170ClienteRazaoSocial;
            Z775SerasaCountAcoes_F = A775SerasaCountAcoes_F;
            Z776SerasaCountEnderecos_F = A776SerasaCountEnderecos_F;
            Z777SerasaCountProtestos_F = A777SerasaCountProtestos_F;
            Z778SerasaCountOcorrencias_F = A778SerasaCountOcorrencias_F;
            Z779SerasaCountCheques_F = A779SerasaCountCheques_F;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z775SerasaCountAcoes_F = A775SerasaCountAcoes_F;
            Z776SerasaCountEnderecos_F = A776SerasaCountEnderecos_F;
            Z777SerasaCountProtestos_F = A777SerasaCountProtestos_F;
            Z778SerasaCountOcorrencias_F = A778SerasaCountOcorrencias_F;
            Z779SerasaCountCheques_F = A779SerasaCountCheques_F;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z775SerasaCountAcoes_F = A775SerasaCountAcoes_F;
            Z776SerasaCountEnderecos_F = A776SerasaCountEnderecos_F;
            Z777SerasaCountProtestos_F = A777SerasaCountProtestos_F;
            Z778SerasaCountOcorrencias_F = A778SerasaCountOcorrencias_F;
            Z779SerasaCountCheques_F = A779SerasaCountCheques_F;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z775SerasaCountAcoes_F = A775SerasaCountAcoes_F;
            Z776SerasaCountEnderecos_F = A776SerasaCountEnderecos_F;
            Z777SerasaCountProtestos_F = A777SerasaCountProtestos_F;
            Z778SerasaCountOcorrencias_F = A778SerasaCountOcorrencias_F;
            Z779SerasaCountCheques_F = A779SerasaCountCheques_F;
         }
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z775SerasaCountAcoes_F = A775SerasaCountAcoes_F;
            Z776SerasaCountEnderecos_F = A776SerasaCountEnderecos_F;
            Z777SerasaCountProtestos_F = A777SerasaCountProtestos_F;
            Z778SerasaCountOcorrencias_F = A778SerasaCountOcorrencias_F;
            Z779SerasaCountCheques_F = A779SerasaCountCheques_F;
         }
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z775SerasaCountAcoes_F = A775SerasaCountAcoes_F;
            Z776SerasaCountEnderecos_F = A776SerasaCountEnderecos_F;
            Z777SerasaCountProtestos_F = A777SerasaCountProtestos_F;
            Z778SerasaCountOcorrencias_F = A778SerasaCountOcorrencias_F;
            Z779SerasaCountCheques_F = A779SerasaCountCheques_F;
         }
         if ( GX_JID == -5 )
         {
            Z662SerasaId = A662SerasaId;
            Z665SerasaCreatedAt = A665SerasaCreatedAt;
            Z663SerasaNumeroProposta = A663SerasaNumeroProposta;
            Z664SerasaPolitica = A664SerasaPolitica;
            Z666SerasaTipoVenda = A666SerasaTipoVenda;
            Z667SerasaCodTipoVenda = A667SerasaCodTipoVenda;
            Z668SerasaCodNivelRisco = A668SerasaCodNivelRisco;
            Z669SerasaTipoRecomendacao = A669SerasaTipoRecomendacao;
            Z670SerasaRecomendacaoVenda = A670SerasaRecomendacaoVenda;
            Z671SerasaCpfRegular = A671SerasaCpfRegular;
            Z672SerasaRetricaoAtiva = A672SerasaRetricaoAtiva;
            Z673SerasaProtestoAtivo = A673SerasaProtestoAtivo;
            Z674SerasaBaixoComprometimento = A674SerasaBaixoComprometimento;
            Z675SerasaValorLimiteRecomendado = A675SerasaValorLimiteRecomendado;
            Z676SerasaFaixaDeRendaEstimada = A676SerasaFaixaDeRendaEstimada;
            Z677SerasaMensagemRendaEstimada = A677SerasaMensagemRendaEstimada;
            Z678SerasaAnotacoesCompletas = A678SerasaAnotacoesCompletas;
            Z679SerasaConsultasDetalhadas = A679SerasaConsultasDetalhadas;
            Z680SerasaAnotacoesConsultaSPC = A680SerasaAnotacoesConsultaSPC;
            Z681SerasaParticipacaoSocietaria = A681SerasaParticipacaoSocietaria;
            Z682SerasaRendaEstimada = A682SerasaRendaEstimada;
            Z683SerasaHistoricoPagamentoPF = A683SerasaHistoricoPagamentoPF;
            Z684SerasaRecomendaCompleto = A684SerasaRecomendaCompleto;
            Z685SerasaScore = A685SerasaScore;
            Z686SerasaTaxa = A686SerasaTaxa;
            Z687SerasaMensagemScore = A687SerasaMensagemScore;
            Z688SerasaSituacaoCPF = A688SerasaSituacaoCPF;
            Z689SerasaDataNascimento = A689SerasaDataNascimento;
            Z690SerasaGenero = A690SerasaGenero;
            Z691SerasaNomeMae = A691SerasaNomeMae;
            Z692SerasaGrafia = A692SerasaGrafia;
            Z774SerasaJSON = A774SerasaJSON;
            Z168ClienteId = A168ClienteId;
            Z775SerasaCountAcoes_F = A775SerasaCountAcoes_F;
            Z776SerasaCountEnderecos_F = A776SerasaCountEnderecos_F;
            Z777SerasaCountProtestos_F = A777SerasaCountProtestos_F;
            Z778SerasaCountOcorrencias_F = A778SerasaCountOcorrencias_F;
            Z779SerasaCountCheques_F = A779SerasaCountCheques_F;
            Z170ClienteRazaoSocial = A170ClienteRazaoSocial;
         }
      }

      protected void standaloneNotModal( )
      {
         AV19Pgmname = "Serasa_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A665SerasaCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n665SerasaCreatedAt = false;
         }
      }

      protected void Load2E84( )
      {
         /* Using cursor BC002E20 */
         pr_default.execute(8, new Object[] {n662SerasaId, A662SerasaId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound84 = 1;
            A665SerasaCreatedAt = BC002E20_A665SerasaCreatedAt[0];
            n665SerasaCreatedAt = BC002E20_n665SerasaCreatedAt[0];
            A170ClienteRazaoSocial = BC002E20_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = BC002E20_n170ClienteRazaoSocial[0];
            A663SerasaNumeroProposta = BC002E20_A663SerasaNumeroProposta[0];
            n663SerasaNumeroProposta = BC002E20_n663SerasaNumeroProposta[0];
            A664SerasaPolitica = BC002E20_A664SerasaPolitica[0];
            n664SerasaPolitica = BC002E20_n664SerasaPolitica[0];
            A666SerasaTipoVenda = BC002E20_A666SerasaTipoVenda[0];
            n666SerasaTipoVenda = BC002E20_n666SerasaTipoVenda[0];
            A667SerasaCodTipoVenda = BC002E20_A667SerasaCodTipoVenda[0];
            n667SerasaCodTipoVenda = BC002E20_n667SerasaCodTipoVenda[0];
            A668SerasaCodNivelRisco = BC002E20_A668SerasaCodNivelRisco[0];
            n668SerasaCodNivelRisco = BC002E20_n668SerasaCodNivelRisco[0];
            A669SerasaTipoRecomendacao = BC002E20_A669SerasaTipoRecomendacao[0];
            n669SerasaTipoRecomendacao = BC002E20_n669SerasaTipoRecomendacao[0];
            A670SerasaRecomendacaoVenda = BC002E20_A670SerasaRecomendacaoVenda[0];
            n670SerasaRecomendacaoVenda = BC002E20_n670SerasaRecomendacaoVenda[0];
            A671SerasaCpfRegular = BC002E20_A671SerasaCpfRegular[0];
            n671SerasaCpfRegular = BC002E20_n671SerasaCpfRegular[0];
            A672SerasaRetricaoAtiva = BC002E20_A672SerasaRetricaoAtiva[0];
            n672SerasaRetricaoAtiva = BC002E20_n672SerasaRetricaoAtiva[0];
            A673SerasaProtestoAtivo = BC002E20_A673SerasaProtestoAtivo[0];
            n673SerasaProtestoAtivo = BC002E20_n673SerasaProtestoAtivo[0];
            A674SerasaBaixoComprometimento = BC002E20_A674SerasaBaixoComprometimento[0];
            n674SerasaBaixoComprometimento = BC002E20_n674SerasaBaixoComprometimento[0];
            A675SerasaValorLimiteRecomendado = BC002E20_A675SerasaValorLimiteRecomendado[0];
            n675SerasaValorLimiteRecomendado = BC002E20_n675SerasaValorLimiteRecomendado[0];
            A676SerasaFaixaDeRendaEstimada = BC002E20_A676SerasaFaixaDeRendaEstimada[0];
            n676SerasaFaixaDeRendaEstimada = BC002E20_n676SerasaFaixaDeRendaEstimada[0];
            A677SerasaMensagemRendaEstimada = BC002E20_A677SerasaMensagemRendaEstimada[0];
            n677SerasaMensagemRendaEstimada = BC002E20_n677SerasaMensagemRendaEstimada[0];
            A678SerasaAnotacoesCompletas = BC002E20_A678SerasaAnotacoesCompletas[0];
            n678SerasaAnotacoesCompletas = BC002E20_n678SerasaAnotacoesCompletas[0];
            A679SerasaConsultasDetalhadas = BC002E20_A679SerasaConsultasDetalhadas[0];
            n679SerasaConsultasDetalhadas = BC002E20_n679SerasaConsultasDetalhadas[0];
            A680SerasaAnotacoesConsultaSPC = BC002E20_A680SerasaAnotacoesConsultaSPC[0];
            n680SerasaAnotacoesConsultaSPC = BC002E20_n680SerasaAnotacoesConsultaSPC[0];
            A681SerasaParticipacaoSocietaria = BC002E20_A681SerasaParticipacaoSocietaria[0];
            n681SerasaParticipacaoSocietaria = BC002E20_n681SerasaParticipacaoSocietaria[0];
            A682SerasaRendaEstimada = BC002E20_A682SerasaRendaEstimada[0];
            n682SerasaRendaEstimada = BC002E20_n682SerasaRendaEstimada[0];
            A683SerasaHistoricoPagamentoPF = BC002E20_A683SerasaHistoricoPagamentoPF[0];
            n683SerasaHistoricoPagamentoPF = BC002E20_n683SerasaHistoricoPagamentoPF[0];
            A684SerasaRecomendaCompleto = BC002E20_A684SerasaRecomendaCompleto[0];
            n684SerasaRecomendaCompleto = BC002E20_n684SerasaRecomendaCompleto[0];
            A685SerasaScore = BC002E20_A685SerasaScore[0];
            n685SerasaScore = BC002E20_n685SerasaScore[0];
            A686SerasaTaxa = BC002E20_A686SerasaTaxa[0];
            n686SerasaTaxa = BC002E20_n686SerasaTaxa[0];
            A687SerasaMensagemScore = BC002E20_A687SerasaMensagemScore[0];
            n687SerasaMensagemScore = BC002E20_n687SerasaMensagemScore[0];
            A688SerasaSituacaoCPF = BC002E20_A688SerasaSituacaoCPF[0];
            n688SerasaSituacaoCPF = BC002E20_n688SerasaSituacaoCPF[0];
            A689SerasaDataNascimento = BC002E20_A689SerasaDataNascimento[0];
            n689SerasaDataNascimento = BC002E20_n689SerasaDataNascimento[0];
            A690SerasaGenero = BC002E20_A690SerasaGenero[0];
            n690SerasaGenero = BC002E20_n690SerasaGenero[0];
            A691SerasaNomeMae = BC002E20_A691SerasaNomeMae[0];
            n691SerasaNomeMae = BC002E20_n691SerasaNomeMae[0];
            A692SerasaGrafia = BC002E20_A692SerasaGrafia[0];
            n692SerasaGrafia = BC002E20_n692SerasaGrafia[0];
            A774SerasaJSON = BC002E20_A774SerasaJSON[0];
            n774SerasaJSON = BC002E20_n774SerasaJSON[0];
            A168ClienteId = BC002E20_A168ClienteId[0];
            n168ClienteId = BC002E20_n168ClienteId[0];
            A775SerasaCountAcoes_F = BC002E20_A775SerasaCountAcoes_F[0];
            n775SerasaCountAcoes_F = BC002E20_n775SerasaCountAcoes_F[0];
            A776SerasaCountEnderecos_F = BC002E20_A776SerasaCountEnderecos_F[0];
            n776SerasaCountEnderecos_F = BC002E20_n776SerasaCountEnderecos_F[0];
            A777SerasaCountProtestos_F = BC002E20_A777SerasaCountProtestos_F[0];
            n777SerasaCountProtestos_F = BC002E20_n777SerasaCountProtestos_F[0];
            A778SerasaCountOcorrencias_F = BC002E20_A778SerasaCountOcorrencias_F[0];
            n778SerasaCountOcorrencias_F = BC002E20_n778SerasaCountOcorrencias_F[0];
            A779SerasaCountCheques_F = BC002E20_A779SerasaCountCheques_F[0];
            n779SerasaCountCheques_F = BC002E20_n779SerasaCountCheques_F[0];
            ZM2E84( -5) ;
         }
         pr_default.close(8);
         OnLoadActions2E84( ) ;
      }

      protected void OnLoadActions2E84( )
      {
      }

      protected void CheckExtendedTable2E84( )
      {
         standaloneModal( ) ;
         /* Using cursor BC002E6 */
         pr_default.execute(3, new Object[] {n662SerasaId, A662SerasaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            A775SerasaCountAcoes_F = BC002E6_A775SerasaCountAcoes_F[0];
            n775SerasaCountAcoes_F = BC002E6_n775SerasaCountAcoes_F[0];
         }
         else
         {
            A775SerasaCountAcoes_F = 0;
            n775SerasaCountAcoes_F = false;
         }
         pr_default.close(3);
         /* Using cursor BC002E8 */
         pr_default.execute(4, new Object[] {n662SerasaId, A662SerasaId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            A776SerasaCountEnderecos_F = BC002E8_A776SerasaCountEnderecos_F[0];
            n776SerasaCountEnderecos_F = BC002E8_n776SerasaCountEnderecos_F[0];
         }
         else
         {
            A776SerasaCountEnderecos_F = 0;
            n776SerasaCountEnderecos_F = false;
         }
         pr_default.close(4);
         /* Using cursor BC002E10 */
         pr_default.execute(5, new Object[] {n662SerasaId, A662SerasaId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            A777SerasaCountProtestos_F = BC002E10_A777SerasaCountProtestos_F[0];
            n777SerasaCountProtestos_F = BC002E10_n777SerasaCountProtestos_F[0];
         }
         else
         {
            A777SerasaCountProtestos_F = 0;
            n777SerasaCountProtestos_F = false;
         }
         pr_default.close(5);
         /* Using cursor BC002E12 */
         pr_default.execute(6, new Object[] {n662SerasaId, A662SerasaId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            A778SerasaCountOcorrencias_F = BC002E12_A778SerasaCountOcorrencias_F[0];
            n778SerasaCountOcorrencias_F = BC002E12_n778SerasaCountOcorrencias_F[0];
         }
         else
         {
            A778SerasaCountOcorrencias_F = 0;
            n778SerasaCountOcorrencias_F = false;
         }
         pr_default.close(6);
         /* Using cursor BC002E14 */
         pr_default.execute(7, new Object[] {n662SerasaId, A662SerasaId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            A779SerasaCountCheques_F = BC002E14_A779SerasaCountCheques_F[0];
            n779SerasaCountCheques_F = BC002E14_n779SerasaCountCheques_F[0];
         }
         else
         {
            A779SerasaCountCheques_F = 0;
            n779SerasaCountCheques_F = false;
         }
         pr_default.close(7);
         /* Using cursor BC002E4 */
         pr_default.execute(2, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A168ClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
               AnyError = 1;
            }
         }
         A170ClienteRazaoSocial = BC002E4_A170ClienteRazaoSocial[0];
         n170ClienteRazaoSocial = BC002E4_n170ClienteRazaoSocial[0];
         pr_default.close(2);
         if ( ( A675SerasaValorLimiteRecomendado < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors2E84( )
      {
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(6);
         pr_default.close(7);
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2E84( )
      {
         /* Using cursor BC002E21 */
         pr_default.execute(9, new Object[] {n662SerasaId, A662SerasaId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound84 = 1;
         }
         else
         {
            RcdFound84 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC002E3 */
         pr_default.execute(1, new Object[] {n662SerasaId, A662SerasaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2E84( 5) ;
            RcdFound84 = 1;
            A662SerasaId = BC002E3_A662SerasaId[0];
            n662SerasaId = BC002E3_n662SerasaId[0];
            A665SerasaCreatedAt = BC002E3_A665SerasaCreatedAt[0];
            n665SerasaCreatedAt = BC002E3_n665SerasaCreatedAt[0];
            A663SerasaNumeroProposta = BC002E3_A663SerasaNumeroProposta[0];
            n663SerasaNumeroProposta = BC002E3_n663SerasaNumeroProposta[0];
            A664SerasaPolitica = BC002E3_A664SerasaPolitica[0];
            n664SerasaPolitica = BC002E3_n664SerasaPolitica[0];
            A666SerasaTipoVenda = BC002E3_A666SerasaTipoVenda[0];
            n666SerasaTipoVenda = BC002E3_n666SerasaTipoVenda[0];
            A667SerasaCodTipoVenda = BC002E3_A667SerasaCodTipoVenda[0];
            n667SerasaCodTipoVenda = BC002E3_n667SerasaCodTipoVenda[0];
            A668SerasaCodNivelRisco = BC002E3_A668SerasaCodNivelRisco[0];
            n668SerasaCodNivelRisco = BC002E3_n668SerasaCodNivelRisco[0];
            A669SerasaTipoRecomendacao = BC002E3_A669SerasaTipoRecomendacao[0];
            n669SerasaTipoRecomendacao = BC002E3_n669SerasaTipoRecomendacao[0];
            A670SerasaRecomendacaoVenda = BC002E3_A670SerasaRecomendacaoVenda[0];
            n670SerasaRecomendacaoVenda = BC002E3_n670SerasaRecomendacaoVenda[0];
            A671SerasaCpfRegular = BC002E3_A671SerasaCpfRegular[0];
            n671SerasaCpfRegular = BC002E3_n671SerasaCpfRegular[0];
            A672SerasaRetricaoAtiva = BC002E3_A672SerasaRetricaoAtiva[0];
            n672SerasaRetricaoAtiva = BC002E3_n672SerasaRetricaoAtiva[0];
            A673SerasaProtestoAtivo = BC002E3_A673SerasaProtestoAtivo[0];
            n673SerasaProtestoAtivo = BC002E3_n673SerasaProtestoAtivo[0];
            A674SerasaBaixoComprometimento = BC002E3_A674SerasaBaixoComprometimento[0];
            n674SerasaBaixoComprometimento = BC002E3_n674SerasaBaixoComprometimento[0];
            A675SerasaValorLimiteRecomendado = BC002E3_A675SerasaValorLimiteRecomendado[0];
            n675SerasaValorLimiteRecomendado = BC002E3_n675SerasaValorLimiteRecomendado[0];
            A676SerasaFaixaDeRendaEstimada = BC002E3_A676SerasaFaixaDeRendaEstimada[0];
            n676SerasaFaixaDeRendaEstimada = BC002E3_n676SerasaFaixaDeRendaEstimada[0];
            A677SerasaMensagemRendaEstimada = BC002E3_A677SerasaMensagemRendaEstimada[0];
            n677SerasaMensagemRendaEstimada = BC002E3_n677SerasaMensagemRendaEstimada[0];
            A678SerasaAnotacoesCompletas = BC002E3_A678SerasaAnotacoesCompletas[0];
            n678SerasaAnotacoesCompletas = BC002E3_n678SerasaAnotacoesCompletas[0];
            A679SerasaConsultasDetalhadas = BC002E3_A679SerasaConsultasDetalhadas[0];
            n679SerasaConsultasDetalhadas = BC002E3_n679SerasaConsultasDetalhadas[0];
            A680SerasaAnotacoesConsultaSPC = BC002E3_A680SerasaAnotacoesConsultaSPC[0];
            n680SerasaAnotacoesConsultaSPC = BC002E3_n680SerasaAnotacoesConsultaSPC[0];
            A681SerasaParticipacaoSocietaria = BC002E3_A681SerasaParticipacaoSocietaria[0];
            n681SerasaParticipacaoSocietaria = BC002E3_n681SerasaParticipacaoSocietaria[0];
            A682SerasaRendaEstimada = BC002E3_A682SerasaRendaEstimada[0];
            n682SerasaRendaEstimada = BC002E3_n682SerasaRendaEstimada[0];
            A683SerasaHistoricoPagamentoPF = BC002E3_A683SerasaHistoricoPagamentoPF[0];
            n683SerasaHistoricoPagamentoPF = BC002E3_n683SerasaHistoricoPagamentoPF[0];
            A684SerasaRecomendaCompleto = BC002E3_A684SerasaRecomendaCompleto[0];
            n684SerasaRecomendaCompleto = BC002E3_n684SerasaRecomendaCompleto[0];
            A685SerasaScore = BC002E3_A685SerasaScore[0];
            n685SerasaScore = BC002E3_n685SerasaScore[0];
            A686SerasaTaxa = BC002E3_A686SerasaTaxa[0];
            n686SerasaTaxa = BC002E3_n686SerasaTaxa[0];
            A687SerasaMensagemScore = BC002E3_A687SerasaMensagemScore[0];
            n687SerasaMensagemScore = BC002E3_n687SerasaMensagemScore[0];
            A688SerasaSituacaoCPF = BC002E3_A688SerasaSituacaoCPF[0];
            n688SerasaSituacaoCPF = BC002E3_n688SerasaSituacaoCPF[0];
            A689SerasaDataNascimento = BC002E3_A689SerasaDataNascimento[0];
            n689SerasaDataNascimento = BC002E3_n689SerasaDataNascimento[0];
            A690SerasaGenero = BC002E3_A690SerasaGenero[0];
            n690SerasaGenero = BC002E3_n690SerasaGenero[0];
            A691SerasaNomeMae = BC002E3_A691SerasaNomeMae[0];
            n691SerasaNomeMae = BC002E3_n691SerasaNomeMae[0];
            A692SerasaGrafia = BC002E3_A692SerasaGrafia[0];
            n692SerasaGrafia = BC002E3_n692SerasaGrafia[0];
            A774SerasaJSON = BC002E3_A774SerasaJSON[0];
            n774SerasaJSON = BC002E3_n774SerasaJSON[0];
            A168ClienteId = BC002E3_A168ClienteId[0];
            n168ClienteId = BC002E3_n168ClienteId[0];
            Z662SerasaId = A662SerasaId;
            sMode84 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2E84( ) ;
            if ( AnyError == 1 )
            {
               RcdFound84 = 0;
               InitializeNonKey2E84( ) ;
            }
            Gx_mode = sMode84;
         }
         else
         {
            RcdFound84 = 0;
            InitializeNonKey2E84( ) ;
            sMode84 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode84;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2E84( ) ;
         if ( RcdFound84 == 0 )
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
         CONFIRM_2E0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2E84( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC002E2 */
            pr_default.execute(0, new Object[] {n662SerasaId, A662SerasaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Serasa"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z665SerasaCreatedAt != BC002E2_A665SerasaCreatedAt[0] ) || ( StringUtil.StrCmp(Z663SerasaNumeroProposta, BC002E2_A663SerasaNumeroProposta[0]) != 0 ) || ( Z664SerasaPolitica != BC002E2_A664SerasaPolitica[0] ) || ( StringUtil.StrCmp(Z666SerasaTipoVenda, BC002E2_A666SerasaTipoVenda[0]) != 0 ) || ( Z667SerasaCodTipoVenda != BC002E2_A667SerasaCodTipoVenda[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z668SerasaCodNivelRisco != BC002E2_A668SerasaCodNivelRisco[0] ) || ( StringUtil.StrCmp(Z669SerasaTipoRecomendacao, BC002E2_A669SerasaTipoRecomendacao[0]) != 0 ) || ( StringUtil.StrCmp(Z670SerasaRecomendacaoVenda, BC002E2_A670SerasaRecomendacaoVenda[0]) != 0 ) || ( Z671SerasaCpfRegular != BC002E2_A671SerasaCpfRegular[0] ) || ( Z672SerasaRetricaoAtiva != BC002E2_A672SerasaRetricaoAtiva[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z673SerasaProtestoAtivo != BC002E2_A673SerasaProtestoAtivo[0] ) || ( Z674SerasaBaixoComprometimento != BC002E2_A674SerasaBaixoComprometimento[0] ) || ( Z675SerasaValorLimiteRecomendado != BC002E2_A675SerasaValorLimiteRecomendado[0] ) || ( Z676SerasaFaixaDeRendaEstimada != BC002E2_A676SerasaFaixaDeRendaEstimada[0] ) || ( StringUtil.StrCmp(Z677SerasaMensagemRendaEstimada, BC002E2_A677SerasaMensagemRendaEstimada[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z678SerasaAnotacoesCompletas != BC002E2_A678SerasaAnotacoesCompletas[0] ) || ( Z679SerasaConsultasDetalhadas != BC002E2_A679SerasaConsultasDetalhadas[0] ) || ( Z680SerasaAnotacoesConsultaSPC != BC002E2_A680SerasaAnotacoesConsultaSPC[0] ) || ( Z681SerasaParticipacaoSocietaria != BC002E2_A681SerasaParticipacaoSocietaria[0] ) || ( Z682SerasaRendaEstimada != BC002E2_A682SerasaRendaEstimada[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z683SerasaHistoricoPagamentoPF != BC002E2_A683SerasaHistoricoPagamentoPF[0] ) || ( Z684SerasaRecomendaCompleto != BC002E2_A684SerasaRecomendaCompleto[0] ) || ( Z685SerasaScore != BC002E2_A685SerasaScore[0] ) || ( Z686SerasaTaxa != BC002E2_A686SerasaTaxa[0] ) || ( StringUtil.StrCmp(Z687SerasaMensagemScore, BC002E2_A687SerasaMensagemScore[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z688SerasaSituacaoCPF, BC002E2_A688SerasaSituacaoCPF[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z689SerasaDataNascimento ) != DateTimeUtil.ResetTime ( BC002E2_A689SerasaDataNascimento[0] ) ) || ( StringUtil.StrCmp(Z690SerasaGenero, BC002E2_A690SerasaGenero[0]) != 0 ) || ( StringUtil.StrCmp(Z691SerasaNomeMae, BC002E2_A691SerasaNomeMae[0]) != 0 ) || ( StringUtil.StrCmp(Z692SerasaGrafia, BC002E2_A692SerasaGrafia[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z168ClienteId != BC002E2_A168ClienteId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Serasa"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2E84( )
      {
         BeforeValidate2E84( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2E84( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2E84( 0) ;
            CheckOptimisticConcurrency2E84( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2E84( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2E84( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002E22 */
                     pr_default.execute(10, new Object[] {n665SerasaCreatedAt, A665SerasaCreatedAt, n663SerasaNumeroProposta, A663SerasaNumeroProposta, n664SerasaPolitica, A664SerasaPolitica, n666SerasaTipoVenda, A666SerasaTipoVenda, n667SerasaCodTipoVenda, A667SerasaCodTipoVenda, n668SerasaCodNivelRisco, A668SerasaCodNivelRisco, n669SerasaTipoRecomendacao, A669SerasaTipoRecomendacao, n670SerasaRecomendacaoVenda, A670SerasaRecomendacaoVenda, n671SerasaCpfRegular, A671SerasaCpfRegular, n672SerasaRetricaoAtiva, A672SerasaRetricaoAtiva, n673SerasaProtestoAtivo, A673SerasaProtestoAtivo, n674SerasaBaixoComprometimento, A674SerasaBaixoComprometimento, n675SerasaValorLimiteRecomendado, A675SerasaValorLimiteRecomendado, n676SerasaFaixaDeRendaEstimada, A676SerasaFaixaDeRendaEstimada, n677SerasaMensagemRendaEstimada, A677SerasaMensagemRendaEstimada, n678SerasaAnotacoesCompletas, A678SerasaAnotacoesCompletas, n679SerasaConsultasDetalhadas, A679SerasaConsultasDetalhadas, n680SerasaAnotacoesConsultaSPC, A680SerasaAnotacoesConsultaSPC, n681SerasaParticipacaoSocietaria, A681SerasaParticipacaoSocietaria, n682SerasaRendaEstimada, A682SerasaRendaEstimada, n683SerasaHistoricoPagamentoPF, A683SerasaHistoricoPagamentoPF, n684SerasaRecomendaCompleto, A684SerasaRecomendaCompleto, n685SerasaScore, A685SerasaScore, n686SerasaTaxa, A686SerasaTaxa, n687SerasaMensagemScore, A687SerasaMensagemScore, n688SerasaSituacaoCPF, A688SerasaSituacaoCPF, n689SerasaDataNascimento, A689SerasaDataNascimento, n690SerasaGenero, A690SerasaGenero, n691SerasaNomeMae, A691SerasaNomeMae, n692SerasaGrafia, A692SerasaGrafia, n774SerasaJSON, A774SerasaJSON, n168ClienteId, A168ClienteId});
                     pr_default.close(10);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC002E23 */
                     pr_default.execute(11);
                     A662SerasaId = BC002E23_A662SerasaId[0];
                     n662SerasaId = BC002E23_n662SerasaId[0];
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Serasa");
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
               Load2E84( ) ;
            }
            EndLevel2E84( ) ;
         }
         CloseExtendedTableCursors2E84( ) ;
      }

      protected void Update2E84( )
      {
         BeforeValidate2E84( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2E84( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2E84( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2E84( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2E84( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002E24 */
                     pr_default.execute(12, new Object[] {n665SerasaCreatedAt, A665SerasaCreatedAt, n663SerasaNumeroProposta, A663SerasaNumeroProposta, n664SerasaPolitica, A664SerasaPolitica, n666SerasaTipoVenda, A666SerasaTipoVenda, n667SerasaCodTipoVenda, A667SerasaCodTipoVenda, n668SerasaCodNivelRisco, A668SerasaCodNivelRisco, n669SerasaTipoRecomendacao, A669SerasaTipoRecomendacao, n670SerasaRecomendacaoVenda, A670SerasaRecomendacaoVenda, n671SerasaCpfRegular, A671SerasaCpfRegular, n672SerasaRetricaoAtiva, A672SerasaRetricaoAtiva, n673SerasaProtestoAtivo, A673SerasaProtestoAtivo, n674SerasaBaixoComprometimento, A674SerasaBaixoComprometimento, n675SerasaValorLimiteRecomendado, A675SerasaValorLimiteRecomendado, n676SerasaFaixaDeRendaEstimada, A676SerasaFaixaDeRendaEstimada, n677SerasaMensagemRendaEstimada, A677SerasaMensagemRendaEstimada, n678SerasaAnotacoesCompletas, A678SerasaAnotacoesCompletas, n679SerasaConsultasDetalhadas, A679SerasaConsultasDetalhadas, n680SerasaAnotacoesConsultaSPC, A680SerasaAnotacoesConsultaSPC, n681SerasaParticipacaoSocietaria, A681SerasaParticipacaoSocietaria, n682SerasaRendaEstimada, A682SerasaRendaEstimada, n683SerasaHistoricoPagamentoPF, A683SerasaHistoricoPagamentoPF, n684SerasaRecomendaCompleto, A684SerasaRecomendaCompleto, n685SerasaScore, A685SerasaScore, n686SerasaTaxa, A686SerasaTaxa, n687SerasaMensagemScore, A687SerasaMensagemScore, n688SerasaSituacaoCPF, A688SerasaSituacaoCPF, n689SerasaDataNascimento, A689SerasaDataNascimento, n690SerasaGenero, A690SerasaGenero, n691SerasaNomeMae, A691SerasaNomeMae, n692SerasaGrafia, A692SerasaGrafia, n774SerasaJSON, A774SerasaJSON, n168ClienteId, A168ClienteId, n662SerasaId, A662SerasaId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Serasa");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Serasa"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2E84( ) ;
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
            EndLevel2E84( ) ;
         }
         CloseExtendedTableCursors2E84( ) ;
      }

      protected void DeferredUpdate2E84( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2E84( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2E84( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2E84( ) ;
            AfterConfirm2E84( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2E84( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002E25 */
                  pr_default.execute(13, new Object[] {n662SerasaId, A662SerasaId});
                  pr_default.close(13);
                  pr_default.SmartCacheProvider.SetUpdated("Serasa");
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
         sMode84 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2E84( ) ;
         Gx_mode = sMode84;
      }

      protected void OnDeleteControls2E84( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC002E27 */
            pr_default.execute(14, new Object[] {n662SerasaId, A662SerasaId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               A775SerasaCountAcoes_F = BC002E27_A775SerasaCountAcoes_F[0];
               n775SerasaCountAcoes_F = BC002E27_n775SerasaCountAcoes_F[0];
            }
            else
            {
               A775SerasaCountAcoes_F = 0;
               n775SerasaCountAcoes_F = false;
            }
            pr_default.close(14);
            /* Using cursor BC002E29 */
            pr_default.execute(15, new Object[] {n662SerasaId, A662SerasaId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               A776SerasaCountEnderecos_F = BC002E29_A776SerasaCountEnderecos_F[0];
               n776SerasaCountEnderecos_F = BC002E29_n776SerasaCountEnderecos_F[0];
            }
            else
            {
               A776SerasaCountEnderecos_F = 0;
               n776SerasaCountEnderecos_F = false;
            }
            pr_default.close(15);
            /* Using cursor BC002E31 */
            pr_default.execute(16, new Object[] {n662SerasaId, A662SerasaId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               A777SerasaCountProtestos_F = BC002E31_A777SerasaCountProtestos_F[0];
               n777SerasaCountProtestos_F = BC002E31_n777SerasaCountProtestos_F[0];
            }
            else
            {
               A777SerasaCountProtestos_F = 0;
               n777SerasaCountProtestos_F = false;
            }
            pr_default.close(16);
            /* Using cursor BC002E33 */
            pr_default.execute(17, new Object[] {n662SerasaId, A662SerasaId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               A778SerasaCountOcorrencias_F = BC002E33_A778SerasaCountOcorrencias_F[0];
               n778SerasaCountOcorrencias_F = BC002E33_n778SerasaCountOcorrencias_F[0];
            }
            else
            {
               A778SerasaCountOcorrencias_F = 0;
               n778SerasaCountOcorrencias_F = false;
            }
            pr_default.close(17);
            /* Using cursor BC002E35 */
            pr_default.execute(18, new Object[] {n662SerasaId, A662SerasaId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               A779SerasaCountCheques_F = BC002E35_A779SerasaCountCheques_F[0];
               n779SerasaCountCheques_F = BC002E35_n779SerasaCountCheques_F[0];
            }
            else
            {
               A779SerasaCountCheques_F = 0;
               n779SerasaCountCheques_F = false;
            }
            pr_default.close(18);
            /* Using cursor BC002E36 */
            pr_default.execute(19, new Object[] {n168ClienteId, A168ClienteId});
            A170ClienteRazaoSocial = BC002E36_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = BC002E36_n170ClienteRazaoSocial[0];
            pr_default.close(19);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC002E37 */
            pr_default.execute(20, new Object[] {n662SerasaId, A662SerasaId});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SerasaOcorrencias"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor BC002E38 */
            pr_default.execute(21, new Object[] {n662SerasaId, A662SerasaId});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SerasaEnderecos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor BC002E39 */
            pr_default.execute(22, new Object[] {n662SerasaId, A662SerasaId});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SerasaProtestos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor BC002E40 */
            pr_default.execute(23, new Object[] {n662SerasaId, A662SerasaId});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SerasaAcoes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
            /* Using cursor BC002E41 */
            pr_default.execute(24, new Object[] {n662SerasaId, A662SerasaId});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SerasaCheques"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
         }
      }

      protected void EndLevel2E84( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2E84( ) ;
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

      public void ScanKeyStart2E84( )
      {
         /* Scan By routine */
         /* Using cursor BC002E47 */
         pr_default.execute(25, new Object[] {n662SerasaId, A662SerasaId});
         RcdFound84 = 0;
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound84 = 1;
            A662SerasaId = BC002E47_A662SerasaId[0];
            n662SerasaId = BC002E47_n662SerasaId[0];
            A665SerasaCreatedAt = BC002E47_A665SerasaCreatedAt[0];
            n665SerasaCreatedAt = BC002E47_n665SerasaCreatedAt[0];
            A170ClienteRazaoSocial = BC002E47_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = BC002E47_n170ClienteRazaoSocial[0];
            A663SerasaNumeroProposta = BC002E47_A663SerasaNumeroProposta[0];
            n663SerasaNumeroProposta = BC002E47_n663SerasaNumeroProposta[0];
            A664SerasaPolitica = BC002E47_A664SerasaPolitica[0];
            n664SerasaPolitica = BC002E47_n664SerasaPolitica[0];
            A666SerasaTipoVenda = BC002E47_A666SerasaTipoVenda[0];
            n666SerasaTipoVenda = BC002E47_n666SerasaTipoVenda[0];
            A667SerasaCodTipoVenda = BC002E47_A667SerasaCodTipoVenda[0];
            n667SerasaCodTipoVenda = BC002E47_n667SerasaCodTipoVenda[0];
            A668SerasaCodNivelRisco = BC002E47_A668SerasaCodNivelRisco[0];
            n668SerasaCodNivelRisco = BC002E47_n668SerasaCodNivelRisco[0];
            A669SerasaTipoRecomendacao = BC002E47_A669SerasaTipoRecomendacao[0];
            n669SerasaTipoRecomendacao = BC002E47_n669SerasaTipoRecomendacao[0];
            A670SerasaRecomendacaoVenda = BC002E47_A670SerasaRecomendacaoVenda[0];
            n670SerasaRecomendacaoVenda = BC002E47_n670SerasaRecomendacaoVenda[0];
            A671SerasaCpfRegular = BC002E47_A671SerasaCpfRegular[0];
            n671SerasaCpfRegular = BC002E47_n671SerasaCpfRegular[0];
            A672SerasaRetricaoAtiva = BC002E47_A672SerasaRetricaoAtiva[0];
            n672SerasaRetricaoAtiva = BC002E47_n672SerasaRetricaoAtiva[0];
            A673SerasaProtestoAtivo = BC002E47_A673SerasaProtestoAtivo[0];
            n673SerasaProtestoAtivo = BC002E47_n673SerasaProtestoAtivo[0];
            A674SerasaBaixoComprometimento = BC002E47_A674SerasaBaixoComprometimento[0];
            n674SerasaBaixoComprometimento = BC002E47_n674SerasaBaixoComprometimento[0];
            A675SerasaValorLimiteRecomendado = BC002E47_A675SerasaValorLimiteRecomendado[0];
            n675SerasaValorLimiteRecomendado = BC002E47_n675SerasaValorLimiteRecomendado[0];
            A676SerasaFaixaDeRendaEstimada = BC002E47_A676SerasaFaixaDeRendaEstimada[0];
            n676SerasaFaixaDeRendaEstimada = BC002E47_n676SerasaFaixaDeRendaEstimada[0];
            A677SerasaMensagemRendaEstimada = BC002E47_A677SerasaMensagemRendaEstimada[0];
            n677SerasaMensagemRendaEstimada = BC002E47_n677SerasaMensagemRendaEstimada[0];
            A678SerasaAnotacoesCompletas = BC002E47_A678SerasaAnotacoesCompletas[0];
            n678SerasaAnotacoesCompletas = BC002E47_n678SerasaAnotacoesCompletas[0];
            A679SerasaConsultasDetalhadas = BC002E47_A679SerasaConsultasDetalhadas[0];
            n679SerasaConsultasDetalhadas = BC002E47_n679SerasaConsultasDetalhadas[0];
            A680SerasaAnotacoesConsultaSPC = BC002E47_A680SerasaAnotacoesConsultaSPC[0];
            n680SerasaAnotacoesConsultaSPC = BC002E47_n680SerasaAnotacoesConsultaSPC[0];
            A681SerasaParticipacaoSocietaria = BC002E47_A681SerasaParticipacaoSocietaria[0];
            n681SerasaParticipacaoSocietaria = BC002E47_n681SerasaParticipacaoSocietaria[0];
            A682SerasaRendaEstimada = BC002E47_A682SerasaRendaEstimada[0];
            n682SerasaRendaEstimada = BC002E47_n682SerasaRendaEstimada[0];
            A683SerasaHistoricoPagamentoPF = BC002E47_A683SerasaHistoricoPagamentoPF[0];
            n683SerasaHistoricoPagamentoPF = BC002E47_n683SerasaHistoricoPagamentoPF[0];
            A684SerasaRecomendaCompleto = BC002E47_A684SerasaRecomendaCompleto[0];
            n684SerasaRecomendaCompleto = BC002E47_n684SerasaRecomendaCompleto[0];
            A685SerasaScore = BC002E47_A685SerasaScore[0];
            n685SerasaScore = BC002E47_n685SerasaScore[0];
            A686SerasaTaxa = BC002E47_A686SerasaTaxa[0];
            n686SerasaTaxa = BC002E47_n686SerasaTaxa[0];
            A687SerasaMensagemScore = BC002E47_A687SerasaMensagemScore[0];
            n687SerasaMensagemScore = BC002E47_n687SerasaMensagemScore[0];
            A688SerasaSituacaoCPF = BC002E47_A688SerasaSituacaoCPF[0];
            n688SerasaSituacaoCPF = BC002E47_n688SerasaSituacaoCPF[0];
            A689SerasaDataNascimento = BC002E47_A689SerasaDataNascimento[0];
            n689SerasaDataNascimento = BC002E47_n689SerasaDataNascimento[0];
            A690SerasaGenero = BC002E47_A690SerasaGenero[0];
            n690SerasaGenero = BC002E47_n690SerasaGenero[0];
            A691SerasaNomeMae = BC002E47_A691SerasaNomeMae[0];
            n691SerasaNomeMae = BC002E47_n691SerasaNomeMae[0];
            A692SerasaGrafia = BC002E47_A692SerasaGrafia[0];
            n692SerasaGrafia = BC002E47_n692SerasaGrafia[0];
            A774SerasaJSON = BC002E47_A774SerasaJSON[0];
            n774SerasaJSON = BC002E47_n774SerasaJSON[0];
            A168ClienteId = BC002E47_A168ClienteId[0];
            n168ClienteId = BC002E47_n168ClienteId[0];
            A775SerasaCountAcoes_F = BC002E47_A775SerasaCountAcoes_F[0];
            n775SerasaCountAcoes_F = BC002E47_n775SerasaCountAcoes_F[0];
            A776SerasaCountEnderecos_F = BC002E47_A776SerasaCountEnderecos_F[0];
            n776SerasaCountEnderecos_F = BC002E47_n776SerasaCountEnderecos_F[0];
            A777SerasaCountProtestos_F = BC002E47_A777SerasaCountProtestos_F[0];
            n777SerasaCountProtestos_F = BC002E47_n777SerasaCountProtestos_F[0];
            A778SerasaCountOcorrencias_F = BC002E47_A778SerasaCountOcorrencias_F[0];
            n778SerasaCountOcorrencias_F = BC002E47_n778SerasaCountOcorrencias_F[0];
            A779SerasaCountCheques_F = BC002E47_A779SerasaCountCheques_F[0];
            n779SerasaCountCheques_F = BC002E47_n779SerasaCountCheques_F[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2E84( )
      {
         /* Scan next routine */
         pr_default.readNext(25);
         RcdFound84 = 0;
         ScanKeyLoad2E84( ) ;
      }

      protected void ScanKeyLoad2E84( )
      {
         sMode84 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound84 = 1;
            A662SerasaId = BC002E47_A662SerasaId[0];
            n662SerasaId = BC002E47_n662SerasaId[0];
            A665SerasaCreatedAt = BC002E47_A665SerasaCreatedAt[0];
            n665SerasaCreatedAt = BC002E47_n665SerasaCreatedAt[0];
            A170ClienteRazaoSocial = BC002E47_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = BC002E47_n170ClienteRazaoSocial[0];
            A663SerasaNumeroProposta = BC002E47_A663SerasaNumeroProposta[0];
            n663SerasaNumeroProposta = BC002E47_n663SerasaNumeroProposta[0];
            A664SerasaPolitica = BC002E47_A664SerasaPolitica[0];
            n664SerasaPolitica = BC002E47_n664SerasaPolitica[0];
            A666SerasaTipoVenda = BC002E47_A666SerasaTipoVenda[0];
            n666SerasaTipoVenda = BC002E47_n666SerasaTipoVenda[0];
            A667SerasaCodTipoVenda = BC002E47_A667SerasaCodTipoVenda[0];
            n667SerasaCodTipoVenda = BC002E47_n667SerasaCodTipoVenda[0];
            A668SerasaCodNivelRisco = BC002E47_A668SerasaCodNivelRisco[0];
            n668SerasaCodNivelRisco = BC002E47_n668SerasaCodNivelRisco[0];
            A669SerasaTipoRecomendacao = BC002E47_A669SerasaTipoRecomendacao[0];
            n669SerasaTipoRecomendacao = BC002E47_n669SerasaTipoRecomendacao[0];
            A670SerasaRecomendacaoVenda = BC002E47_A670SerasaRecomendacaoVenda[0];
            n670SerasaRecomendacaoVenda = BC002E47_n670SerasaRecomendacaoVenda[0];
            A671SerasaCpfRegular = BC002E47_A671SerasaCpfRegular[0];
            n671SerasaCpfRegular = BC002E47_n671SerasaCpfRegular[0];
            A672SerasaRetricaoAtiva = BC002E47_A672SerasaRetricaoAtiva[0];
            n672SerasaRetricaoAtiva = BC002E47_n672SerasaRetricaoAtiva[0];
            A673SerasaProtestoAtivo = BC002E47_A673SerasaProtestoAtivo[0];
            n673SerasaProtestoAtivo = BC002E47_n673SerasaProtestoAtivo[0];
            A674SerasaBaixoComprometimento = BC002E47_A674SerasaBaixoComprometimento[0];
            n674SerasaBaixoComprometimento = BC002E47_n674SerasaBaixoComprometimento[0];
            A675SerasaValorLimiteRecomendado = BC002E47_A675SerasaValorLimiteRecomendado[0];
            n675SerasaValorLimiteRecomendado = BC002E47_n675SerasaValorLimiteRecomendado[0];
            A676SerasaFaixaDeRendaEstimada = BC002E47_A676SerasaFaixaDeRendaEstimada[0];
            n676SerasaFaixaDeRendaEstimada = BC002E47_n676SerasaFaixaDeRendaEstimada[0];
            A677SerasaMensagemRendaEstimada = BC002E47_A677SerasaMensagemRendaEstimada[0];
            n677SerasaMensagemRendaEstimada = BC002E47_n677SerasaMensagemRendaEstimada[0];
            A678SerasaAnotacoesCompletas = BC002E47_A678SerasaAnotacoesCompletas[0];
            n678SerasaAnotacoesCompletas = BC002E47_n678SerasaAnotacoesCompletas[0];
            A679SerasaConsultasDetalhadas = BC002E47_A679SerasaConsultasDetalhadas[0];
            n679SerasaConsultasDetalhadas = BC002E47_n679SerasaConsultasDetalhadas[0];
            A680SerasaAnotacoesConsultaSPC = BC002E47_A680SerasaAnotacoesConsultaSPC[0];
            n680SerasaAnotacoesConsultaSPC = BC002E47_n680SerasaAnotacoesConsultaSPC[0];
            A681SerasaParticipacaoSocietaria = BC002E47_A681SerasaParticipacaoSocietaria[0];
            n681SerasaParticipacaoSocietaria = BC002E47_n681SerasaParticipacaoSocietaria[0];
            A682SerasaRendaEstimada = BC002E47_A682SerasaRendaEstimada[0];
            n682SerasaRendaEstimada = BC002E47_n682SerasaRendaEstimada[0];
            A683SerasaHistoricoPagamentoPF = BC002E47_A683SerasaHistoricoPagamentoPF[0];
            n683SerasaHistoricoPagamentoPF = BC002E47_n683SerasaHistoricoPagamentoPF[0];
            A684SerasaRecomendaCompleto = BC002E47_A684SerasaRecomendaCompleto[0];
            n684SerasaRecomendaCompleto = BC002E47_n684SerasaRecomendaCompleto[0];
            A685SerasaScore = BC002E47_A685SerasaScore[0];
            n685SerasaScore = BC002E47_n685SerasaScore[0];
            A686SerasaTaxa = BC002E47_A686SerasaTaxa[0];
            n686SerasaTaxa = BC002E47_n686SerasaTaxa[0];
            A687SerasaMensagemScore = BC002E47_A687SerasaMensagemScore[0];
            n687SerasaMensagemScore = BC002E47_n687SerasaMensagemScore[0];
            A688SerasaSituacaoCPF = BC002E47_A688SerasaSituacaoCPF[0];
            n688SerasaSituacaoCPF = BC002E47_n688SerasaSituacaoCPF[0];
            A689SerasaDataNascimento = BC002E47_A689SerasaDataNascimento[0];
            n689SerasaDataNascimento = BC002E47_n689SerasaDataNascimento[0];
            A690SerasaGenero = BC002E47_A690SerasaGenero[0];
            n690SerasaGenero = BC002E47_n690SerasaGenero[0];
            A691SerasaNomeMae = BC002E47_A691SerasaNomeMae[0];
            n691SerasaNomeMae = BC002E47_n691SerasaNomeMae[0];
            A692SerasaGrafia = BC002E47_A692SerasaGrafia[0];
            n692SerasaGrafia = BC002E47_n692SerasaGrafia[0];
            A774SerasaJSON = BC002E47_A774SerasaJSON[0];
            n774SerasaJSON = BC002E47_n774SerasaJSON[0];
            A168ClienteId = BC002E47_A168ClienteId[0];
            n168ClienteId = BC002E47_n168ClienteId[0];
            A775SerasaCountAcoes_F = BC002E47_A775SerasaCountAcoes_F[0];
            n775SerasaCountAcoes_F = BC002E47_n775SerasaCountAcoes_F[0];
            A776SerasaCountEnderecos_F = BC002E47_A776SerasaCountEnderecos_F[0];
            n776SerasaCountEnderecos_F = BC002E47_n776SerasaCountEnderecos_F[0];
            A777SerasaCountProtestos_F = BC002E47_A777SerasaCountProtestos_F[0];
            n777SerasaCountProtestos_F = BC002E47_n777SerasaCountProtestos_F[0];
            A778SerasaCountOcorrencias_F = BC002E47_A778SerasaCountOcorrencias_F[0];
            n778SerasaCountOcorrencias_F = BC002E47_n778SerasaCountOcorrencias_F[0];
            A779SerasaCountCheques_F = BC002E47_A779SerasaCountCheques_F[0];
            n779SerasaCountCheques_F = BC002E47_n779SerasaCountCheques_F[0];
         }
         Gx_mode = sMode84;
      }

      protected void ScanKeyEnd2E84( )
      {
         pr_default.close(25);
      }

      protected void AfterConfirm2E84( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2E84( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2E84( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2E84( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2E84( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2E84( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2E84( )
      {
      }

      protected void send_integrity_lvl_hashes2E84( )
      {
      }

      protected void AddRow2E84( )
      {
         VarsToRow84( bcSerasa) ;
      }

      protected void ReadRow2E84( )
      {
         RowToVars84( bcSerasa, 1) ;
      }

      protected void InitializeNonKey2E84( )
      {
         A665SerasaCreatedAt = (DateTime)(DateTime.MinValue);
         n665SerasaCreatedAt = false;
         A168ClienteId = 0;
         n168ClienteId = false;
         A170ClienteRazaoSocial = "";
         n170ClienteRazaoSocial = false;
         A663SerasaNumeroProposta = "";
         n663SerasaNumeroProposta = false;
         A664SerasaPolitica = 0;
         n664SerasaPolitica = false;
         A666SerasaTipoVenda = "";
         n666SerasaTipoVenda = false;
         A667SerasaCodTipoVenda = 0;
         n667SerasaCodTipoVenda = false;
         A668SerasaCodNivelRisco = 0;
         n668SerasaCodNivelRisco = false;
         A669SerasaTipoRecomendacao = "";
         n669SerasaTipoRecomendacao = false;
         A670SerasaRecomendacaoVenda = "";
         n670SerasaRecomendacaoVenda = false;
         A671SerasaCpfRegular = false;
         n671SerasaCpfRegular = false;
         A672SerasaRetricaoAtiva = false;
         n672SerasaRetricaoAtiva = false;
         A673SerasaProtestoAtivo = false;
         n673SerasaProtestoAtivo = false;
         A674SerasaBaixoComprometimento = false;
         n674SerasaBaixoComprometimento = false;
         A675SerasaValorLimiteRecomendado = 0;
         n675SerasaValorLimiteRecomendado = false;
         A676SerasaFaixaDeRendaEstimada = 0;
         n676SerasaFaixaDeRendaEstimada = false;
         A677SerasaMensagemRendaEstimada = "";
         n677SerasaMensagemRendaEstimada = false;
         A678SerasaAnotacoesCompletas = false;
         n678SerasaAnotacoesCompletas = false;
         A679SerasaConsultasDetalhadas = false;
         n679SerasaConsultasDetalhadas = false;
         A680SerasaAnotacoesConsultaSPC = false;
         n680SerasaAnotacoesConsultaSPC = false;
         A681SerasaParticipacaoSocietaria = false;
         n681SerasaParticipacaoSocietaria = false;
         A682SerasaRendaEstimada = false;
         n682SerasaRendaEstimada = false;
         A683SerasaHistoricoPagamentoPF = false;
         n683SerasaHistoricoPagamentoPF = false;
         A684SerasaRecomendaCompleto = false;
         n684SerasaRecomendaCompleto = false;
         A685SerasaScore = 0;
         n685SerasaScore = false;
         A686SerasaTaxa = 0;
         n686SerasaTaxa = false;
         A687SerasaMensagemScore = "";
         n687SerasaMensagemScore = false;
         A688SerasaSituacaoCPF = "";
         n688SerasaSituacaoCPF = false;
         A689SerasaDataNascimento = DateTime.MinValue;
         n689SerasaDataNascimento = false;
         A690SerasaGenero = "";
         n690SerasaGenero = false;
         A691SerasaNomeMae = "";
         n691SerasaNomeMae = false;
         A692SerasaGrafia = "";
         n692SerasaGrafia = false;
         A774SerasaJSON = "";
         n774SerasaJSON = false;
         A775SerasaCountAcoes_F = 0;
         n775SerasaCountAcoes_F = false;
         A776SerasaCountEnderecos_F = 0;
         n776SerasaCountEnderecos_F = false;
         A777SerasaCountProtestos_F = 0;
         n777SerasaCountProtestos_F = false;
         A778SerasaCountOcorrencias_F = 0;
         n778SerasaCountOcorrencias_F = false;
         A779SerasaCountCheques_F = 0;
         n779SerasaCountCheques_F = false;
         Z665SerasaCreatedAt = (DateTime)(DateTime.MinValue);
         Z663SerasaNumeroProposta = "";
         Z664SerasaPolitica = 0;
         Z666SerasaTipoVenda = "";
         Z667SerasaCodTipoVenda = 0;
         Z668SerasaCodNivelRisco = 0;
         Z669SerasaTipoRecomendacao = "";
         Z670SerasaRecomendacaoVenda = "";
         Z671SerasaCpfRegular = false;
         Z672SerasaRetricaoAtiva = false;
         Z673SerasaProtestoAtivo = false;
         Z674SerasaBaixoComprometimento = false;
         Z675SerasaValorLimiteRecomendado = 0;
         Z676SerasaFaixaDeRendaEstimada = 0;
         Z677SerasaMensagemRendaEstimada = "";
         Z678SerasaAnotacoesCompletas = false;
         Z679SerasaConsultasDetalhadas = false;
         Z680SerasaAnotacoesConsultaSPC = false;
         Z681SerasaParticipacaoSocietaria = false;
         Z682SerasaRendaEstimada = false;
         Z683SerasaHistoricoPagamentoPF = false;
         Z684SerasaRecomendaCompleto = false;
         Z685SerasaScore = 0;
         Z686SerasaTaxa = 0;
         Z687SerasaMensagemScore = "";
         Z688SerasaSituacaoCPF = "";
         Z689SerasaDataNascimento = DateTime.MinValue;
         Z690SerasaGenero = "";
         Z691SerasaNomeMae = "";
         Z692SerasaGrafia = "";
         Z168ClienteId = 0;
      }

      protected void InitAll2E84( )
      {
         A662SerasaId = 0;
         n662SerasaId = false;
         InitializeNonKey2E84( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A665SerasaCreatedAt = i665SerasaCreatedAt;
         n665SerasaCreatedAt = false;
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

      public void VarsToRow84( SdtSerasa obj84 )
      {
         obj84.gxTpr_Mode = Gx_mode;
         obj84.gxTpr_Serasacreatedat = A665SerasaCreatedAt;
         obj84.gxTpr_Clienteid = A168ClienteId;
         obj84.gxTpr_Clienterazaosocial = A170ClienteRazaoSocial;
         obj84.gxTpr_Serasanumeroproposta = A663SerasaNumeroProposta;
         obj84.gxTpr_Serasapolitica = A664SerasaPolitica;
         obj84.gxTpr_Serasatipovenda = A666SerasaTipoVenda;
         obj84.gxTpr_Serasacodtipovenda = A667SerasaCodTipoVenda;
         obj84.gxTpr_Serasacodnivelrisco = A668SerasaCodNivelRisco;
         obj84.gxTpr_Serasatiporecomendacao = A669SerasaTipoRecomendacao;
         obj84.gxTpr_Serasarecomendacaovenda = A670SerasaRecomendacaoVenda;
         obj84.gxTpr_Serasacpfregular = A671SerasaCpfRegular;
         obj84.gxTpr_Serasaretricaoativa = A672SerasaRetricaoAtiva;
         obj84.gxTpr_Serasaprotestoativo = A673SerasaProtestoAtivo;
         obj84.gxTpr_Serasabaixocomprometimento = A674SerasaBaixoComprometimento;
         obj84.gxTpr_Serasavalorlimiterecomendado = A675SerasaValorLimiteRecomendado;
         obj84.gxTpr_Serasafaixaderendaestimada = A676SerasaFaixaDeRendaEstimada;
         obj84.gxTpr_Serasamensagemrendaestimada = A677SerasaMensagemRendaEstimada;
         obj84.gxTpr_Serasaanotacoescompletas = A678SerasaAnotacoesCompletas;
         obj84.gxTpr_Serasaconsultasdetalhadas = A679SerasaConsultasDetalhadas;
         obj84.gxTpr_Serasaanotacoesconsultaspc = A680SerasaAnotacoesConsultaSPC;
         obj84.gxTpr_Serasaparticipacaosocietaria = A681SerasaParticipacaoSocietaria;
         obj84.gxTpr_Serasarendaestimada = A682SerasaRendaEstimada;
         obj84.gxTpr_Serasahistoricopagamentopf = A683SerasaHistoricoPagamentoPF;
         obj84.gxTpr_Serasarecomendacompleto = A684SerasaRecomendaCompleto;
         obj84.gxTpr_Serasascore = A685SerasaScore;
         obj84.gxTpr_Serasataxa = A686SerasaTaxa;
         obj84.gxTpr_Serasamensagemscore = A687SerasaMensagemScore;
         obj84.gxTpr_Serasasituacaocpf = A688SerasaSituacaoCPF;
         obj84.gxTpr_Serasadatanascimento = A689SerasaDataNascimento;
         obj84.gxTpr_Serasagenero = A690SerasaGenero;
         obj84.gxTpr_Serasanomemae = A691SerasaNomeMae;
         obj84.gxTpr_Serasagrafia = A692SerasaGrafia;
         obj84.gxTpr_Serasajson = A774SerasaJSON;
         obj84.gxTpr_Serasacountacoes_f = A775SerasaCountAcoes_F;
         obj84.gxTpr_Serasacountenderecos_f = A776SerasaCountEnderecos_F;
         obj84.gxTpr_Serasacountprotestos_f = A777SerasaCountProtestos_F;
         obj84.gxTpr_Serasacountocorrencias_f = A778SerasaCountOcorrencias_F;
         obj84.gxTpr_Serasacountcheques_f = A779SerasaCountCheques_F;
         obj84.gxTpr_Serasaid = A662SerasaId;
         obj84.gxTpr_Serasaid_Z = Z662SerasaId;
         obj84.gxTpr_Clienteid_Z = Z168ClienteId;
         obj84.gxTpr_Clienterazaosocial_Z = Z170ClienteRazaoSocial;
         obj84.gxTpr_Serasanumeroproposta_Z = Z663SerasaNumeroProposta;
         obj84.gxTpr_Serasapolitica_Z = Z664SerasaPolitica;
         obj84.gxTpr_Serasacreatedat_Z = Z665SerasaCreatedAt;
         obj84.gxTpr_Serasatipovenda_Z = Z666SerasaTipoVenda;
         obj84.gxTpr_Serasacodtipovenda_Z = Z667SerasaCodTipoVenda;
         obj84.gxTpr_Serasacodnivelrisco_Z = Z668SerasaCodNivelRisco;
         obj84.gxTpr_Serasatiporecomendacao_Z = Z669SerasaTipoRecomendacao;
         obj84.gxTpr_Serasarecomendacaovenda_Z = Z670SerasaRecomendacaoVenda;
         obj84.gxTpr_Serasacpfregular_Z = Z671SerasaCpfRegular;
         obj84.gxTpr_Serasaretricaoativa_Z = Z672SerasaRetricaoAtiva;
         obj84.gxTpr_Serasaprotestoativo_Z = Z673SerasaProtestoAtivo;
         obj84.gxTpr_Serasabaixocomprometimento_Z = Z674SerasaBaixoComprometimento;
         obj84.gxTpr_Serasavalorlimiterecomendado_Z = Z675SerasaValorLimiteRecomendado;
         obj84.gxTpr_Serasafaixaderendaestimada_Z = Z676SerasaFaixaDeRendaEstimada;
         obj84.gxTpr_Serasamensagemrendaestimada_Z = Z677SerasaMensagemRendaEstimada;
         obj84.gxTpr_Serasaanotacoescompletas_Z = Z678SerasaAnotacoesCompletas;
         obj84.gxTpr_Serasaconsultasdetalhadas_Z = Z679SerasaConsultasDetalhadas;
         obj84.gxTpr_Serasaanotacoesconsultaspc_Z = Z680SerasaAnotacoesConsultaSPC;
         obj84.gxTpr_Serasaparticipacaosocietaria_Z = Z681SerasaParticipacaoSocietaria;
         obj84.gxTpr_Serasarendaestimada_Z = Z682SerasaRendaEstimada;
         obj84.gxTpr_Serasahistoricopagamentopf_Z = Z683SerasaHistoricoPagamentoPF;
         obj84.gxTpr_Serasarecomendacompleto_Z = Z684SerasaRecomendaCompleto;
         obj84.gxTpr_Serasascore_Z = Z685SerasaScore;
         obj84.gxTpr_Serasataxa_Z = Z686SerasaTaxa;
         obj84.gxTpr_Serasamensagemscore_Z = Z687SerasaMensagemScore;
         obj84.gxTpr_Serasasituacaocpf_Z = Z688SerasaSituacaoCPF;
         obj84.gxTpr_Serasadatanascimento_Z = Z689SerasaDataNascimento;
         obj84.gxTpr_Serasagenero_Z = Z690SerasaGenero;
         obj84.gxTpr_Serasanomemae_Z = Z691SerasaNomeMae;
         obj84.gxTpr_Serasagrafia_Z = Z692SerasaGrafia;
         obj84.gxTpr_Serasacountacoes_f_Z = Z775SerasaCountAcoes_F;
         obj84.gxTpr_Serasacountenderecos_f_Z = Z776SerasaCountEnderecos_F;
         obj84.gxTpr_Serasacountprotestos_f_Z = Z777SerasaCountProtestos_F;
         obj84.gxTpr_Serasacountocorrencias_f_Z = Z778SerasaCountOcorrencias_F;
         obj84.gxTpr_Serasacountcheques_f_Z = Z779SerasaCountCheques_F;
         obj84.gxTpr_Serasaid_N = (short)(Convert.ToInt16(n662SerasaId));
         obj84.gxTpr_Clienteid_N = (short)(Convert.ToInt16(n168ClienteId));
         obj84.gxTpr_Clienterazaosocial_N = (short)(Convert.ToInt16(n170ClienteRazaoSocial));
         obj84.gxTpr_Serasanumeroproposta_N = (short)(Convert.ToInt16(n663SerasaNumeroProposta));
         obj84.gxTpr_Serasapolitica_N = (short)(Convert.ToInt16(n664SerasaPolitica));
         obj84.gxTpr_Serasacreatedat_N = (short)(Convert.ToInt16(n665SerasaCreatedAt));
         obj84.gxTpr_Serasatipovenda_N = (short)(Convert.ToInt16(n666SerasaTipoVenda));
         obj84.gxTpr_Serasacodtipovenda_N = (short)(Convert.ToInt16(n667SerasaCodTipoVenda));
         obj84.gxTpr_Serasacodnivelrisco_N = (short)(Convert.ToInt16(n668SerasaCodNivelRisco));
         obj84.gxTpr_Serasatiporecomendacao_N = (short)(Convert.ToInt16(n669SerasaTipoRecomendacao));
         obj84.gxTpr_Serasarecomendacaovenda_N = (short)(Convert.ToInt16(n670SerasaRecomendacaoVenda));
         obj84.gxTpr_Serasacpfregular_N = (short)(Convert.ToInt16(n671SerasaCpfRegular));
         obj84.gxTpr_Serasaretricaoativa_N = (short)(Convert.ToInt16(n672SerasaRetricaoAtiva));
         obj84.gxTpr_Serasaprotestoativo_N = (short)(Convert.ToInt16(n673SerasaProtestoAtivo));
         obj84.gxTpr_Serasabaixocomprometimento_N = (short)(Convert.ToInt16(n674SerasaBaixoComprometimento));
         obj84.gxTpr_Serasavalorlimiterecomendado_N = (short)(Convert.ToInt16(n675SerasaValorLimiteRecomendado));
         obj84.gxTpr_Serasafaixaderendaestimada_N = (short)(Convert.ToInt16(n676SerasaFaixaDeRendaEstimada));
         obj84.gxTpr_Serasamensagemrendaestimada_N = (short)(Convert.ToInt16(n677SerasaMensagemRendaEstimada));
         obj84.gxTpr_Serasaanotacoescompletas_N = (short)(Convert.ToInt16(n678SerasaAnotacoesCompletas));
         obj84.gxTpr_Serasaconsultasdetalhadas_N = (short)(Convert.ToInt16(n679SerasaConsultasDetalhadas));
         obj84.gxTpr_Serasaanotacoesconsultaspc_N = (short)(Convert.ToInt16(n680SerasaAnotacoesConsultaSPC));
         obj84.gxTpr_Serasaparticipacaosocietaria_N = (short)(Convert.ToInt16(n681SerasaParticipacaoSocietaria));
         obj84.gxTpr_Serasarendaestimada_N = (short)(Convert.ToInt16(n682SerasaRendaEstimada));
         obj84.gxTpr_Serasahistoricopagamentopf_N = (short)(Convert.ToInt16(n683SerasaHistoricoPagamentoPF));
         obj84.gxTpr_Serasarecomendacompleto_N = (short)(Convert.ToInt16(n684SerasaRecomendaCompleto));
         obj84.gxTpr_Serasascore_N = (short)(Convert.ToInt16(n685SerasaScore));
         obj84.gxTpr_Serasataxa_N = (short)(Convert.ToInt16(n686SerasaTaxa));
         obj84.gxTpr_Serasamensagemscore_N = (short)(Convert.ToInt16(n687SerasaMensagemScore));
         obj84.gxTpr_Serasasituacaocpf_N = (short)(Convert.ToInt16(n688SerasaSituacaoCPF));
         obj84.gxTpr_Serasadatanascimento_N = (short)(Convert.ToInt16(n689SerasaDataNascimento));
         obj84.gxTpr_Serasagenero_N = (short)(Convert.ToInt16(n690SerasaGenero));
         obj84.gxTpr_Serasanomemae_N = (short)(Convert.ToInt16(n691SerasaNomeMae));
         obj84.gxTpr_Serasagrafia_N = (short)(Convert.ToInt16(n692SerasaGrafia));
         obj84.gxTpr_Serasajson_N = (short)(Convert.ToInt16(n774SerasaJSON));
         obj84.gxTpr_Serasacountacoes_f_N = (short)(Convert.ToInt16(n775SerasaCountAcoes_F));
         obj84.gxTpr_Serasacountenderecos_f_N = (short)(Convert.ToInt16(n776SerasaCountEnderecos_F));
         obj84.gxTpr_Serasacountprotestos_f_N = (short)(Convert.ToInt16(n777SerasaCountProtestos_F));
         obj84.gxTpr_Serasacountocorrencias_f_N = (short)(Convert.ToInt16(n778SerasaCountOcorrencias_F));
         obj84.gxTpr_Serasacountcheques_f_N = (short)(Convert.ToInt16(n779SerasaCountCheques_F));
         obj84.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow84( SdtSerasa obj84 )
      {
         obj84.gxTpr_Serasaid = A662SerasaId;
         return  ;
      }

      public void RowToVars84( SdtSerasa obj84 ,
                               int forceLoad )
      {
         Gx_mode = obj84.gxTpr_Mode;
         A665SerasaCreatedAt = obj84.gxTpr_Serasacreatedat;
         n665SerasaCreatedAt = false;
         A168ClienteId = obj84.gxTpr_Clienteid;
         n168ClienteId = false;
         A170ClienteRazaoSocial = obj84.gxTpr_Clienterazaosocial;
         n170ClienteRazaoSocial = false;
         A663SerasaNumeroProposta = obj84.gxTpr_Serasanumeroproposta;
         n663SerasaNumeroProposta = false;
         A664SerasaPolitica = obj84.gxTpr_Serasapolitica;
         n664SerasaPolitica = false;
         A666SerasaTipoVenda = obj84.gxTpr_Serasatipovenda;
         n666SerasaTipoVenda = false;
         A667SerasaCodTipoVenda = obj84.gxTpr_Serasacodtipovenda;
         n667SerasaCodTipoVenda = false;
         A668SerasaCodNivelRisco = obj84.gxTpr_Serasacodnivelrisco;
         n668SerasaCodNivelRisco = false;
         A669SerasaTipoRecomendacao = obj84.gxTpr_Serasatiporecomendacao;
         n669SerasaTipoRecomendacao = false;
         A670SerasaRecomendacaoVenda = obj84.gxTpr_Serasarecomendacaovenda;
         n670SerasaRecomendacaoVenda = false;
         A671SerasaCpfRegular = obj84.gxTpr_Serasacpfregular;
         n671SerasaCpfRegular = false;
         A672SerasaRetricaoAtiva = obj84.gxTpr_Serasaretricaoativa;
         n672SerasaRetricaoAtiva = false;
         A673SerasaProtestoAtivo = obj84.gxTpr_Serasaprotestoativo;
         n673SerasaProtestoAtivo = false;
         A674SerasaBaixoComprometimento = obj84.gxTpr_Serasabaixocomprometimento;
         n674SerasaBaixoComprometimento = false;
         A675SerasaValorLimiteRecomendado = obj84.gxTpr_Serasavalorlimiterecomendado;
         n675SerasaValorLimiteRecomendado = false;
         A676SerasaFaixaDeRendaEstimada = obj84.gxTpr_Serasafaixaderendaestimada;
         n676SerasaFaixaDeRendaEstimada = false;
         A677SerasaMensagemRendaEstimada = obj84.gxTpr_Serasamensagemrendaestimada;
         n677SerasaMensagemRendaEstimada = false;
         A678SerasaAnotacoesCompletas = obj84.gxTpr_Serasaanotacoescompletas;
         n678SerasaAnotacoesCompletas = false;
         A679SerasaConsultasDetalhadas = obj84.gxTpr_Serasaconsultasdetalhadas;
         n679SerasaConsultasDetalhadas = false;
         A680SerasaAnotacoesConsultaSPC = obj84.gxTpr_Serasaanotacoesconsultaspc;
         n680SerasaAnotacoesConsultaSPC = false;
         A681SerasaParticipacaoSocietaria = obj84.gxTpr_Serasaparticipacaosocietaria;
         n681SerasaParticipacaoSocietaria = false;
         A682SerasaRendaEstimada = obj84.gxTpr_Serasarendaestimada;
         n682SerasaRendaEstimada = false;
         A683SerasaHistoricoPagamentoPF = obj84.gxTpr_Serasahistoricopagamentopf;
         n683SerasaHistoricoPagamentoPF = false;
         A684SerasaRecomendaCompleto = obj84.gxTpr_Serasarecomendacompleto;
         n684SerasaRecomendaCompleto = false;
         A685SerasaScore = obj84.gxTpr_Serasascore;
         n685SerasaScore = false;
         A686SerasaTaxa = obj84.gxTpr_Serasataxa;
         n686SerasaTaxa = false;
         A687SerasaMensagemScore = obj84.gxTpr_Serasamensagemscore;
         n687SerasaMensagemScore = false;
         A688SerasaSituacaoCPF = obj84.gxTpr_Serasasituacaocpf;
         n688SerasaSituacaoCPF = false;
         A689SerasaDataNascimento = obj84.gxTpr_Serasadatanascimento;
         n689SerasaDataNascimento = false;
         A690SerasaGenero = obj84.gxTpr_Serasagenero;
         n690SerasaGenero = false;
         A691SerasaNomeMae = obj84.gxTpr_Serasanomemae;
         n691SerasaNomeMae = false;
         A692SerasaGrafia = obj84.gxTpr_Serasagrafia;
         n692SerasaGrafia = false;
         A774SerasaJSON = obj84.gxTpr_Serasajson;
         n774SerasaJSON = false;
         A775SerasaCountAcoes_F = obj84.gxTpr_Serasacountacoes_f;
         n775SerasaCountAcoes_F = false;
         A776SerasaCountEnderecos_F = obj84.gxTpr_Serasacountenderecos_f;
         n776SerasaCountEnderecos_F = false;
         A777SerasaCountProtestos_F = obj84.gxTpr_Serasacountprotestos_f;
         n777SerasaCountProtestos_F = false;
         A778SerasaCountOcorrencias_F = obj84.gxTpr_Serasacountocorrencias_f;
         n778SerasaCountOcorrencias_F = false;
         A779SerasaCountCheques_F = obj84.gxTpr_Serasacountcheques_f;
         n779SerasaCountCheques_F = false;
         A662SerasaId = obj84.gxTpr_Serasaid;
         n662SerasaId = false;
         Z662SerasaId = obj84.gxTpr_Serasaid_Z;
         Z168ClienteId = obj84.gxTpr_Clienteid_Z;
         Z170ClienteRazaoSocial = obj84.gxTpr_Clienterazaosocial_Z;
         Z663SerasaNumeroProposta = obj84.gxTpr_Serasanumeroproposta_Z;
         Z664SerasaPolitica = obj84.gxTpr_Serasapolitica_Z;
         Z665SerasaCreatedAt = obj84.gxTpr_Serasacreatedat_Z;
         Z666SerasaTipoVenda = obj84.gxTpr_Serasatipovenda_Z;
         Z667SerasaCodTipoVenda = obj84.gxTpr_Serasacodtipovenda_Z;
         Z668SerasaCodNivelRisco = obj84.gxTpr_Serasacodnivelrisco_Z;
         Z669SerasaTipoRecomendacao = obj84.gxTpr_Serasatiporecomendacao_Z;
         Z670SerasaRecomendacaoVenda = obj84.gxTpr_Serasarecomendacaovenda_Z;
         Z671SerasaCpfRegular = obj84.gxTpr_Serasacpfregular_Z;
         Z672SerasaRetricaoAtiva = obj84.gxTpr_Serasaretricaoativa_Z;
         Z673SerasaProtestoAtivo = obj84.gxTpr_Serasaprotestoativo_Z;
         Z674SerasaBaixoComprometimento = obj84.gxTpr_Serasabaixocomprometimento_Z;
         Z675SerasaValorLimiteRecomendado = obj84.gxTpr_Serasavalorlimiterecomendado_Z;
         Z676SerasaFaixaDeRendaEstimada = obj84.gxTpr_Serasafaixaderendaestimada_Z;
         Z677SerasaMensagemRendaEstimada = obj84.gxTpr_Serasamensagemrendaestimada_Z;
         Z678SerasaAnotacoesCompletas = obj84.gxTpr_Serasaanotacoescompletas_Z;
         Z679SerasaConsultasDetalhadas = obj84.gxTpr_Serasaconsultasdetalhadas_Z;
         Z680SerasaAnotacoesConsultaSPC = obj84.gxTpr_Serasaanotacoesconsultaspc_Z;
         Z681SerasaParticipacaoSocietaria = obj84.gxTpr_Serasaparticipacaosocietaria_Z;
         Z682SerasaRendaEstimada = obj84.gxTpr_Serasarendaestimada_Z;
         Z683SerasaHistoricoPagamentoPF = obj84.gxTpr_Serasahistoricopagamentopf_Z;
         Z684SerasaRecomendaCompleto = obj84.gxTpr_Serasarecomendacompleto_Z;
         Z685SerasaScore = obj84.gxTpr_Serasascore_Z;
         Z686SerasaTaxa = obj84.gxTpr_Serasataxa_Z;
         Z687SerasaMensagemScore = obj84.gxTpr_Serasamensagemscore_Z;
         Z688SerasaSituacaoCPF = obj84.gxTpr_Serasasituacaocpf_Z;
         Z689SerasaDataNascimento = obj84.gxTpr_Serasadatanascimento_Z;
         Z690SerasaGenero = obj84.gxTpr_Serasagenero_Z;
         Z691SerasaNomeMae = obj84.gxTpr_Serasanomemae_Z;
         Z692SerasaGrafia = obj84.gxTpr_Serasagrafia_Z;
         Z775SerasaCountAcoes_F = obj84.gxTpr_Serasacountacoes_f_Z;
         Z776SerasaCountEnderecos_F = obj84.gxTpr_Serasacountenderecos_f_Z;
         Z777SerasaCountProtestos_F = obj84.gxTpr_Serasacountprotestos_f_Z;
         Z778SerasaCountOcorrencias_F = obj84.gxTpr_Serasacountocorrencias_f_Z;
         Z779SerasaCountCheques_F = obj84.gxTpr_Serasacountcheques_f_Z;
         n662SerasaId = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasaid_N));
         n168ClienteId = (bool)(Convert.ToBoolean(obj84.gxTpr_Clienteid_N));
         n170ClienteRazaoSocial = (bool)(Convert.ToBoolean(obj84.gxTpr_Clienterazaosocial_N));
         n663SerasaNumeroProposta = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasanumeroproposta_N));
         n664SerasaPolitica = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasapolitica_N));
         n665SerasaCreatedAt = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasacreatedat_N));
         n666SerasaTipoVenda = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasatipovenda_N));
         n667SerasaCodTipoVenda = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasacodtipovenda_N));
         n668SerasaCodNivelRisco = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasacodnivelrisco_N));
         n669SerasaTipoRecomendacao = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasatiporecomendacao_N));
         n670SerasaRecomendacaoVenda = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasarecomendacaovenda_N));
         n671SerasaCpfRegular = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasacpfregular_N));
         n672SerasaRetricaoAtiva = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasaretricaoativa_N));
         n673SerasaProtestoAtivo = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasaprotestoativo_N));
         n674SerasaBaixoComprometimento = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasabaixocomprometimento_N));
         n675SerasaValorLimiteRecomendado = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasavalorlimiterecomendado_N));
         n676SerasaFaixaDeRendaEstimada = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasafaixaderendaestimada_N));
         n677SerasaMensagemRendaEstimada = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasamensagemrendaestimada_N));
         n678SerasaAnotacoesCompletas = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasaanotacoescompletas_N));
         n679SerasaConsultasDetalhadas = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasaconsultasdetalhadas_N));
         n680SerasaAnotacoesConsultaSPC = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasaanotacoesconsultaspc_N));
         n681SerasaParticipacaoSocietaria = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasaparticipacaosocietaria_N));
         n682SerasaRendaEstimada = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasarendaestimada_N));
         n683SerasaHistoricoPagamentoPF = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasahistoricopagamentopf_N));
         n684SerasaRecomendaCompleto = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasarecomendacompleto_N));
         n685SerasaScore = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasascore_N));
         n686SerasaTaxa = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasataxa_N));
         n687SerasaMensagemScore = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasamensagemscore_N));
         n688SerasaSituacaoCPF = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasasituacaocpf_N));
         n689SerasaDataNascimento = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasadatanascimento_N));
         n690SerasaGenero = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasagenero_N));
         n691SerasaNomeMae = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasanomemae_N));
         n692SerasaGrafia = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasagrafia_N));
         n774SerasaJSON = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasajson_N));
         n775SerasaCountAcoes_F = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasacountacoes_f_N));
         n776SerasaCountEnderecos_F = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasacountenderecos_f_N));
         n777SerasaCountProtestos_F = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasacountprotestos_f_N));
         n778SerasaCountOcorrencias_F = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasacountocorrencias_f_N));
         n779SerasaCountCheques_F = (bool)(Convert.ToBoolean(obj84.gxTpr_Serasacountcheques_f_N));
         Gx_mode = obj84.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A662SerasaId = (int)getParm(obj,0);
         n662SerasaId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2E84( ) ;
         ScanKeyStart2E84( ) ;
         if ( RcdFound84 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z662SerasaId = A662SerasaId;
         }
         ZM2E84( -5) ;
         OnLoadActions2E84( ) ;
         AddRow2E84( ) ;
         ScanKeyEnd2E84( ) ;
         if ( RcdFound84 == 0 )
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
         RowToVars84( bcSerasa, 0) ;
         ScanKeyStart2E84( ) ;
         if ( RcdFound84 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z662SerasaId = A662SerasaId;
         }
         ZM2E84( -5) ;
         OnLoadActions2E84( ) ;
         AddRow2E84( ) ;
         ScanKeyEnd2E84( ) ;
         if ( RcdFound84 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2E84( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2E84( ) ;
         }
         else
         {
            if ( RcdFound84 == 1 )
            {
               if ( A662SerasaId != Z662SerasaId )
               {
                  A662SerasaId = Z662SerasaId;
                  n662SerasaId = false;
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
                  Update2E84( ) ;
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
                  if ( A662SerasaId != Z662SerasaId )
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
                        Insert2E84( ) ;
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
                        Insert2E84( ) ;
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
         RowToVars84( bcSerasa, 1) ;
         SaveImpl( ) ;
         VarsToRow84( bcSerasa) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars84( bcSerasa, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2E84( ) ;
         AfterTrn( ) ;
         VarsToRow84( bcSerasa) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow84( bcSerasa) ;
         }
         else
         {
            SdtSerasa auxBC = new SdtSerasa(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A662SerasaId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcSerasa);
               auxBC.Save();
               bcSerasa.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars84( bcSerasa, 1) ;
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
         RowToVars84( bcSerasa, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2E84( ) ;
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
               VarsToRow84( bcSerasa) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow84( bcSerasa) ;
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
         RowToVars84( bcSerasa, 0) ;
         GetKey2E84( ) ;
         if ( RcdFound84 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A662SerasaId != Z662SerasaId )
            {
               A662SerasaId = Z662SerasaId;
               n662SerasaId = false;
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
            if ( A662SerasaId != Z662SerasaId )
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
         context.RollbackDataStores("serasa_bc",pr_default);
         VarsToRow84( bcSerasa) ;
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
         Gx_mode = bcSerasa.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcSerasa.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcSerasa )
         {
            bcSerasa = (SdtSerasa)(sdt);
            if ( StringUtil.StrCmp(bcSerasa.gxTpr_Mode, "") == 0 )
            {
               bcSerasa.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow84( bcSerasa) ;
            }
            else
            {
               RowToVars84( bcSerasa, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcSerasa.gxTpr_Mode, "") == 0 )
            {
               bcSerasa.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars84( bcSerasa, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtSerasa Serasa_BC
      {
         get {
            return bcSerasa ;
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
         AV19Pgmname = "";
         AV12TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z665SerasaCreatedAt = (DateTime)(DateTime.MinValue);
         A665SerasaCreatedAt = (DateTime)(DateTime.MinValue);
         Z663SerasaNumeroProposta = "";
         A663SerasaNumeroProposta = "";
         Z666SerasaTipoVenda = "";
         A666SerasaTipoVenda = "";
         Z669SerasaTipoRecomendacao = "";
         A669SerasaTipoRecomendacao = "";
         Z670SerasaRecomendacaoVenda = "";
         A670SerasaRecomendacaoVenda = "";
         Z677SerasaMensagemRendaEstimada = "";
         A677SerasaMensagemRendaEstimada = "";
         Z687SerasaMensagemScore = "";
         A687SerasaMensagemScore = "";
         Z688SerasaSituacaoCPF = "";
         A688SerasaSituacaoCPF = "";
         Z689SerasaDataNascimento = DateTime.MinValue;
         A689SerasaDataNascimento = DateTime.MinValue;
         Z690SerasaGenero = "";
         A690SerasaGenero = "";
         Z691SerasaNomeMae = "";
         A691SerasaNomeMae = "";
         Z692SerasaGrafia = "";
         A692SerasaGrafia = "";
         Z170ClienteRazaoSocial = "";
         A170ClienteRazaoSocial = "";
         Z774SerasaJSON = "";
         A774SerasaJSON = "";
         BC002E20_A662SerasaId = new int[1] ;
         BC002E20_n662SerasaId = new bool[] {false} ;
         BC002E20_A665SerasaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002E20_n665SerasaCreatedAt = new bool[] {false} ;
         BC002E20_A170ClienteRazaoSocial = new string[] {""} ;
         BC002E20_n170ClienteRazaoSocial = new bool[] {false} ;
         BC002E20_A663SerasaNumeroProposta = new string[] {""} ;
         BC002E20_n663SerasaNumeroProposta = new bool[] {false} ;
         BC002E20_A664SerasaPolitica = new decimal[1] ;
         BC002E20_n664SerasaPolitica = new bool[] {false} ;
         BC002E20_A666SerasaTipoVenda = new string[] {""} ;
         BC002E20_n666SerasaTipoVenda = new bool[] {false} ;
         BC002E20_A667SerasaCodTipoVenda = new decimal[1] ;
         BC002E20_n667SerasaCodTipoVenda = new bool[] {false} ;
         BC002E20_A668SerasaCodNivelRisco = new decimal[1] ;
         BC002E20_n668SerasaCodNivelRisco = new bool[] {false} ;
         BC002E20_A669SerasaTipoRecomendacao = new string[] {""} ;
         BC002E20_n669SerasaTipoRecomendacao = new bool[] {false} ;
         BC002E20_A670SerasaRecomendacaoVenda = new string[] {""} ;
         BC002E20_n670SerasaRecomendacaoVenda = new bool[] {false} ;
         BC002E20_A671SerasaCpfRegular = new bool[] {false} ;
         BC002E20_n671SerasaCpfRegular = new bool[] {false} ;
         BC002E20_A672SerasaRetricaoAtiva = new bool[] {false} ;
         BC002E20_n672SerasaRetricaoAtiva = new bool[] {false} ;
         BC002E20_A673SerasaProtestoAtivo = new bool[] {false} ;
         BC002E20_n673SerasaProtestoAtivo = new bool[] {false} ;
         BC002E20_A674SerasaBaixoComprometimento = new bool[] {false} ;
         BC002E20_n674SerasaBaixoComprometimento = new bool[] {false} ;
         BC002E20_A675SerasaValorLimiteRecomendado = new decimal[1] ;
         BC002E20_n675SerasaValorLimiteRecomendado = new bool[] {false} ;
         BC002E20_A676SerasaFaixaDeRendaEstimada = new decimal[1] ;
         BC002E20_n676SerasaFaixaDeRendaEstimada = new bool[] {false} ;
         BC002E20_A677SerasaMensagemRendaEstimada = new string[] {""} ;
         BC002E20_n677SerasaMensagemRendaEstimada = new bool[] {false} ;
         BC002E20_A678SerasaAnotacoesCompletas = new bool[] {false} ;
         BC002E20_n678SerasaAnotacoesCompletas = new bool[] {false} ;
         BC002E20_A679SerasaConsultasDetalhadas = new bool[] {false} ;
         BC002E20_n679SerasaConsultasDetalhadas = new bool[] {false} ;
         BC002E20_A680SerasaAnotacoesConsultaSPC = new bool[] {false} ;
         BC002E20_n680SerasaAnotacoesConsultaSPC = new bool[] {false} ;
         BC002E20_A681SerasaParticipacaoSocietaria = new bool[] {false} ;
         BC002E20_n681SerasaParticipacaoSocietaria = new bool[] {false} ;
         BC002E20_A682SerasaRendaEstimada = new bool[] {false} ;
         BC002E20_n682SerasaRendaEstimada = new bool[] {false} ;
         BC002E20_A683SerasaHistoricoPagamentoPF = new bool[] {false} ;
         BC002E20_n683SerasaHistoricoPagamentoPF = new bool[] {false} ;
         BC002E20_A684SerasaRecomendaCompleto = new bool[] {false} ;
         BC002E20_n684SerasaRecomendaCompleto = new bool[] {false} ;
         BC002E20_A685SerasaScore = new short[1] ;
         BC002E20_n685SerasaScore = new bool[] {false} ;
         BC002E20_A686SerasaTaxa = new decimal[1] ;
         BC002E20_n686SerasaTaxa = new bool[] {false} ;
         BC002E20_A687SerasaMensagemScore = new string[] {""} ;
         BC002E20_n687SerasaMensagemScore = new bool[] {false} ;
         BC002E20_A688SerasaSituacaoCPF = new string[] {""} ;
         BC002E20_n688SerasaSituacaoCPF = new bool[] {false} ;
         BC002E20_A689SerasaDataNascimento = new DateTime[] {DateTime.MinValue} ;
         BC002E20_n689SerasaDataNascimento = new bool[] {false} ;
         BC002E20_A690SerasaGenero = new string[] {""} ;
         BC002E20_n690SerasaGenero = new bool[] {false} ;
         BC002E20_A691SerasaNomeMae = new string[] {""} ;
         BC002E20_n691SerasaNomeMae = new bool[] {false} ;
         BC002E20_A692SerasaGrafia = new string[] {""} ;
         BC002E20_n692SerasaGrafia = new bool[] {false} ;
         BC002E20_A774SerasaJSON = new string[] {""} ;
         BC002E20_n774SerasaJSON = new bool[] {false} ;
         BC002E20_A168ClienteId = new int[1] ;
         BC002E20_n168ClienteId = new bool[] {false} ;
         BC002E20_A775SerasaCountAcoes_F = new short[1] ;
         BC002E20_n775SerasaCountAcoes_F = new bool[] {false} ;
         BC002E20_A776SerasaCountEnderecos_F = new short[1] ;
         BC002E20_n776SerasaCountEnderecos_F = new bool[] {false} ;
         BC002E20_A777SerasaCountProtestos_F = new short[1] ;
         BC002E20_n777SerasaCountProtestos_F = new bool[] {false} ;
         BC002E20_A778SerasaCountOcorrencias_F = new short[1] ;
         BC002E20_n778SerasaCountOcorrencias_F = new bool[] {false} ;
         BC002E20_A779SerasaCountCheques_F = new short[1] ;
         BC002E20_n779SerasaCountCheques_F = new bool[] {false} ;
         BC002E6_A775SerasaCountAcoes_F = new short[1] ;
         BC002E6_n775SerasaCountAcoes_F = new bool[] {false} ;
         BC002E8_A776SerasaCountEnderecos_F = new short[1] ;
         BC002E8_n776SerasaCountEnderecos_F = new bool[] {false} ;
         BC002E10_A777SerasaCountProtestos_F = new short[1] ;
         BC002E10_n777SerasaCountProtestos_F = new bool[] {false} ;
         BC002E12_A778SerasaCountOcorrencias_F = new short[1] ;
         BC002E12_n778SerasaCountOcorrencias_F = new bool[] {false} ;
         BC002E14_A779SerasaCountCheques_F = new short[1] ;
         BC002E14_n779SerasaCountCheques_F = new bool[] {false} ;
         BC002E4_A170ClienteRazaoSocial = new string[] {""} ;
         BC002E4_n170ClienteRazaoSocial = new bool[] {false} ;
         BC002E21_A662SerasaId = new int[1] ;
         BC002E21_n662SerasaId = new bool[] {false} ;
         BC002E3_A662SerasaId = new int[1] ;
         BC002E3_n662SerasaId = new bool[] {false} ;
         BC002E3_A665SerasaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002E3_n665SerasaCreatedAt = new bool[] {false} ;
         BC002E3_A663SerasaNumeroProposta = new string[] {""} ;
         BC002E3_n663SerasaNumeroProposta = new bool[] {false} ;
         BC002E3_A664SerasaPolitica = new decimal[1] ;
         BC002E3_n664SerasaPolitica = new bool[] {false} ;
         BC002E3_A666SerasaTipoVenda = new string[] {""} ;
         BC002E3_n666SerasaTipoVenda = new bool[] {false} ;
         BC002E3_A667SerasaCodTipoVenda = new decimal[1] ;
         BC002E3_n667SerasaCodTipoVenda = new bool[] {false} ;
         BC002E3_A668SerasaCodNivelRisco = new decimal[1] ;
         BC002E3_n668SerasaCodNivelRisco = new bool[] {false} ;
         BC002E3_A669SerasaTipoRecomendacao = new string[] {""} ;
         BC002E3_n669SerasaTipoRecomendacao = new bool[] {false} ;
         BC002E3_A670SerasaRecomendacaoVenda = new string[] {""} ;
         BC002E3_n670SerasaRecomendacaoVenda = new bool[] {false} ;
         BC002E3_A671SerasaCpfRegular = new bool[] {false} ;
         BC002E3_n671SerasaCpfRegular = new bool[] {false} ;
         BC002E3_A672SerasaRetricaoAtiva = new bool[] {false} ;
         BC002E3_n672SerasaRetricaoAtiva = new bool[] {false} ;
         BC002E3_A673SerasaProtestoAtivo = new bool[] {false} ;
         BC002E3_n673SerasaProtestoAtivo = new bool[] {false} ;
         BC002E3_A674SerasaBaixoComprometimento = new bool[] {false} ;
         BC002E3_n674SerasaBaixoComprometimento = new bool[] {false} ;
         BC002E3_A675SerasaValorLimiteRecomendado = new decimal[1] ;
         BC002E3_n675SerasaValorLimiteRecomendado = new bool[] {false} ;
         BC002E3_A676SerasaFaixaDeRendaEstimada = new decimal[1] ;
         BC002E3_n676SerasaFaixaDeRendaEstimada = new bool[] {false} ;
         BC002E3_A677SerasaMensagemRendaEstimada = new string[] {""} ;
         BC002E3_n677SerasaMensagemRendaEstimada = new bool[] {false} ;
         BC002E3_A678SerasaAnotacoesCompletas = new bool[] {false} ;
         BC002E3_n678SerasaAnotacoesCompletas = new bool[] {false} ;
         BC002E3_A679SerasaConsultasDetalhadas = new bool[] {false} ;
         BC002E3_n679SerasaConsultasDetalhadas = new bool[] {false} ;
         BC002E3_A680SerasaAnotacoesConsultaSPC = new bool[] {false} ;
         BC002E3_n680SerasaAnotacoesConsultaSPC = new bool[] {false} ;
         BC002E3_A681SerasaParticipacaoSocietaria = new bool[] {false} ;
         BC002E3_n681SerasaParticipacaoSocietaria = new bool[] {false} ;
         BC002E3_A682SerasaRendaEstimada = new bool[] {false} ;
         BC002E3_n682SerasaRendaEstimada = new bool[] {false} ;
         BC002E3_A683SerasaHistoricoPagamentoPF = new bool[] {false} ;
         BC002E3_n683SerasaHistoricoPagamentoPF = new bool[] {false} ;
         BC002E3_A684SerasaRecomendaCompleto = new bool[] {false} ;
         BC002E3_n684SerasaRecomendaCompleto = new bool[] {false} ;
         BC002E3_A685SerasaScore = new short[1] ;
         BC002E3_n685SerasaScore = new bool[] {false} ;
         BC002E3_A686SerasaTaxa = new decimal[1] ;
         BC002E3_n686SerasaTaxa = new bool[] {false} ;
         BC002E3_A687SerasaMensagemScore = new string[] {""} ;
         BC002E3_n687SerasaMensagemScore = new bool[] {false} ;
         BC002E3_A688SerasaSituacaoCPF = new string[] {""} ;
         BC002E3_n688SerasaSituacaoCPF = new bool[] {false} ;
         BC002E3_A689SerasaDataNascimento = new DateTime[] {DateTime.MinValue} ;
         BC002E3_n689SerasaDataNascimento = new bool[] {false} ;
         BC002E3_A690SerasaGenero = new string[] {""} ;
         BC002E3_n690SerasaGenero = new bool[] {false} ;
         BC002E3_A691SerasaNomeMae = new string[] {""} ;
         BC002E3_n691SerasaNomeMae = new bool[] {false} ;
         BC002E3_A692SerasaGrafia = new string[] {""} ;
         BC002E3_n692SerasaGrafia = new bool[] {false} ;
         BC002E3_A774SerasaJSON = new string[] {""} ;
         BC002E3_n774SerasaJSON = new bool[] {false} ;
         BC002E3_A168ClienteId = new int[1] ;
         BC002E3_n168ClienteId = new bool[] {false} ;
         sMode84 = "";
         BC002E2_A662SerasaId = new int[1] ;
         BC002E2_n662SerasaId = new bool[] {false} ;
         BC002E2_A665SerasaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002E2_n665SerasaCreatedAt = new bool[] {false} ;
         BC002E2_A663SerasaNumeroProposta = new string[] {""} ;
         BC002E2_n663SerasaNumeroProposta = new bool[] {false} ;
         BC002E2_A664SerasaPolitica = new decimal[1] ;
         BC002E2_n664SerasaPolitica = new bool[] {false} ;
         BC002E2_A666SerasaTipoVenda = new string[] {""} ;
         BC002E2_n666SerasaTipoVenda = new bool[] {false} ;
         BC002E2_A667SerasaCodTipoVenda = new decimal[1] ;
         BC002E2_n667SerasaCodTipoVenda = new bool[] {false} ;
         BC002E2_A668SerasaCodNivelRisco = new decimal[1] ;
         BC002E2_n668SerasaCodNivelRisco = new bool[] {false} ;
         BC002E2_A669SerasaTipoRecomendacao = new string[] {""} ;
         BC002E2_n669SerasaTipoRecomendacao = new bool[] {false} ;
         BC002E2_A670SerasaRecomendacaoVenda = new string[] {""} ;
         BC002E2_n670SerasaRecomendacaoVenda = new bool[] {false} ;
         BC002E2_A671SerasaCpfRegular = new bool[] {false} ;
         BC002E2_n671SerasaCpfRegular = new bool[] {false} ;
         BC002E2_A672SerasaRetricaoAtiva = new bool[] {false} ;
         BC002E2_n672SerasaRetricaoAtiva = new bool[] {false} ;
         BC002E2_A673SerasaProtestoAtivo = new bool[] {false} ;
         BC002E2_n673SerasaProtestoAtivo = new bool[] {false} ;
         BC002E2_A674SerasaBaixoComprometimento = new bool[] {false} ;
         BC002E2_n674SerasaBaixoComprometimento = new bool[] {false} ;
         BC002E2_A675SerasaValorLimiteRecomendado = new decimal[1] ;
         BC002E2_n675SerasaValorLimiteRecomendado = new bool[] {false} ;
         BC002E2_A676SerasaFaixaDeRendaEstimada = new decimal[1] ;
         BC002E2_n676SerasaFaixaDeRendaEstimada = new bool[] {false} ;
         BC002E2_A677SerasaMensagemRendaEstimada = new string[] {""} ;
         BC002E2_n677SerasaMensagemRendaEstimada = new bool[] {false} ;
         BC002E2_A678SerasaAnotacoesCompletas = new bool[] {false} ;
         BC002E2_n678SerasaAnotacoesCompletas = new bool[] {false} ;
         BC002E2_A679SerasaConsultasDetalhadas = new bool[] {false} ;
         BC002E2_n679SerasaConsultasDetalhadas = new bool[] {false} ;
         BC002E2_A680SerasaAnotacoesConsultaSPC = new bool[] {false} ;
         BC002E2_n680SerasaAnotacoesConsultaSPC = new bool[] {false} ;
         BC002E2_A681SerasaParticipacaoSocietaria = new bool[] {false} ;
         BC002E2_n681SerasaParticipacaoSocietaria = new bool[] {false} ;
         BC002E2_A682SerasaRendaEstimada = new bool[] {false} ;
         BC002E2_n682SerasaRendaEstimada = new bool[] {false} ;
         BC002E2_A683SerasaHistoricoPagamentoPF = new bool[] {false} ;
         BC002E2_n683SerasaHistoricoPagamentoPF = new bool[] {false} ;
         BC002E2_A684SerasaRecomendaCompleto = new bool[] {false} ;
         BC002E2_n684SerasaRecomendaCompleto = new bool[] {false} ;
         BC002E2_A685SerasaScore = new short[1] ;
         BC002E2_n685SerasaScore = new bool[] {false} ;
         BC002E2_A686SerasaTaxa = new decimal[1] ;
         BC002E2_n686SerasaTaxa = new bool[] {false} ;
         BC002E2_A687SerasaMensagemScore = new string[] {""} ;
         BC002E2_n687SerasaMensagemScore = new bool[] {false} ;
         BC002E2_A688SerasaSituacaoCPF = new string[] {""} ;
         BC002E2_n688SerasaSituacaoCPF = new bool[] {false} ;
         BC002E2_A689SerasaDataNascimento = new DateTime[] {DateTime.MinValue} ;
         BC002E2_n689SerasaDataNascimento = new bool[] {false} ;
         BC002E2_A690SerasaGenero = new string[] {""} ;
         BC002E2_n690SerasaGenero = new bool[] {false} ;
         BC002E2_A691SerasaNomeMae = new string[] {""} ;
         BC002E2_n691SerasaNomeMae = new bool[] {false} ;
         BC002E2_A692SerasaGrafia = new string[] {""} ;
         BC002E2_n692SerasaGrafia = new bool[] {false} ;
         BC002E2_A774SerasaJSON = new string[] {""} ;
         BC002E2_n774SerasaJSON = new bool[] {false} ;
         BC002E2_A168ClienteId = new int[1] ;
         BC002E2_n168ClienteId = new bool[] {false} ;
         BC002E23_A662SerasaId = new int[1] ;
         BC002E23_n662SerasaId = new bool[] {false} ;
         BC002E27_A775SerasaCountAcoes_F = new short[1] ;
         BC002E27_n775SerasaCountAcoes_F = new bool[] {false} ;
         BC002E29_A776SerasaCountEnderecos_F = new short[1] ;
         BC002E29_n776SerasaCountEnderecos_F = new bool[] {false} ;
         BC002E31_A777SerasaCountProtestos_F = new short[1] ;
         BC002E31_n777SerasaCountProtestos_F = new bool[] {false} ;
         BC002E33_A778SerasaCountOcorrencias_F = new short[1] ;
         BC002E33_n778SerasaCountOcorrencias_F = new bool[] {false} ;
         BC002E35_A779SerasaCountCheques_F = new short[1] ;
         BC002E35_n779SerasaCountCheques_F = new bool[] {false} ;
         BC002E36_A170ClienteRazaoSocial = new string[] {""} ;
         BC002E36_n170ClienteRazaoSocial = new bool[] {false} ;
         BC002E37_A726SerasaOcorrenciasId = new int[1] ;
         BC002E38_A716SerasaEnderecosId = new int[1] ;
         BC002E39_A711SerasaProtestosId = new int[1] ;
         BC002E40_A699SerasaAcoesId = new int[1] ;
         BC002E41_A693SerasaChequesId = new int[1] ;
         BC002E47_A662SerasaId = new int[1] ;
         BC002E47_n662SerasaId = new bool[] {false} ;
         BC002E47_A665SerasaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002E47_n665SerasaCreatedAt = new bool[] {false} ;
         BC002E47_A170ClienteRazaoSocial = new string[] {""} ;
         BC002E47_n170ClienteRazaoSocial = new bool[] {false} ;
         BC002E47_A663SerasaNumeroProposta = new string[] {""} ;
         BC002E47_n663SerasaNumeroProposta = new bool[] {false} ;
         BC002E47_A664SerasaPolitica = new decimal[1] ;
         BC002E47_n664SerasaPolitica = new bool[] {false} ;
         BC002E47_A666SerasaTipoVenda = new string[] {""} ;
         BC002E47_n666SerasaTipoVenda = new bool[] {false} ;
         BC002E47_A667SerasaCodTipoVenda = new decimal[1] ;
         BC002E47_n667SerasaCodTipoVenda = new bool[] {false} ;
         BC002E47_A668SerasaCodNivelRisco = new decimal[1] ;
         BC002E47_n668SerasaCodNivelRisco = new bool[] {false} ;
         BC002E47_A669SerasaTipoRecomendacao = new string[] {""} ;
         BC002E47_n669SerasaTipoRecomendacao = new bool[] {false} ;
         BC002E47_A670SerasaRecomendacaoVenda = new string[] {""} ;
         BC002E47_n670SerasaRecomendacaoVenda = new bool[] {false} ;
         BC002E47_A671SerasaCpfRegular = new bool[] {false} ;
         BC002E47_n671SerasaCpfRegular = new bool[] {false} ;
         BC002E47_A672SerasaRetricaoAtiva = new bool[] {false} ;
         BC002E47_n672SerasaRetricaoAtiva = new bool[] {false} ;
         BC002E47_A673SerasaProtestoAtivo = new bool[] {false} ;
         BC002E47_n673SerasaProtestoAtivo = new bool[] {false} ;
         BC002E47_A674SerasaBaixoComprometimento = new bool[] {false} ;
         BC002E47_n674SerasaBaixoComprometimento = new bool[] {false} ;
         BC002E47_A675SerasaValorLimiteRecomendado = new decimal[1] ;
         BC002E47_n675SerasaValorLimiteRecomendado = new bool[] {false} ;
         BC002E47_A676SerasaFaixaDeRendaEstimada = new decimal[1] ;
         BC002E47_n676SerasaFaixaDeRendaEstimada = new bool[] {false} ;
         BC002E47_A677SerasaMensagemRendaEstimada = new string[] {""} ;
         BC002E47_n677SerasaMensagemRendaEstimada = new bool[] {false} ;
         BC002E47_A678SerasaAnotacoesCompletas = new bool[] {false} ;
         BC002E47_n678SerasaAnotacoesCompletas = new bool[] {false} ;
         BC002E47_A679SerasaConsultasDetalhadas = new bool[] {false} ;
         BC002E47_n679SerasaConsultasDetalhadas = new bool[] {false} ;
         BC002E47_A680SerasaAnotacoesConsultaSPC = new bool[] {false} ;
         BC002E47_n680SerasaAnotacoesConsultaSPC = new bool[] {false} ;
         BC002E47_A681SerasaParticipacaoSocietaria = new bool[] {false} ;
         BC002E47_n681SerasaParticipacaoSocietaria = new bool[] {false} ;
         BC002E47_A682SerasaRendaEstimada = new bool[] {false} ;
         BC002E47_n682SerasaRendaEstimada = new bool[] {false} ;
         BC002E47_A683SerasaHistoricoPagamentoPF = new bool[] {false} ;
         BC002E47_n683SerasaHistoricoPagamentoPF = new bool[] {false} ;
         BC002E47_A684SerasaRecomendaCompleto = new bool[] {false} ;
         BC002E47_n684SerasaRecomendaCompleto = new bool[] {false} ;
         BC002E47_A685SerasaScore = new short[1] ;
         BC002E47_n685SerasaScore = new bool[] {false} ;
         BC002E47_A686SerasaTaxa = new decimal[1] ;
         BC002E47_n686SerasaTaxa = new bool[] {false} ;
         BC002E47_A687SerasaMensagemScore = new string[] {""} ;
         BC002E47_n687SerasaMensagemScore = new bool[] {false} ;
         BC002E47_A688SerasaSituacaoCPF = new string[] {""} ;
         BC002E47_n688SerasaSituacaoCPF = new bool[] {false} ;
         BC002E47_A689SerasaDataNascimento = new DateTime[] {DateTime.MinValue} ;
         BC002E47_n689SerasaDataNascimento = new bool[] {false} ;
         BC002E47_A690SerasaGenero = new string[] {""} ;
         BC002E47_n690SerasaGenero = new bool[] {false} ;
         BC002E47_A691SerasaNomeMae = new string[] {""} ;
         BC002E47_n691SerasaNomeMae = new bool[] {false} ;
         BC002E47_A692SerasaGrafia = new string[] {""} ;
         BC002E47_n692SerasaGrafia = new bool[] {false} ;
         BC002E47_A774SerasaJSON = new string[] {""} ;
         BC002E47_n774SerasaJSON = new bool[] {false} ;
         BC002E47_A168ClienteId = new int[1] ;
         BC002E47_n168ClienteId = new bool[] {false} ;
         BC002E47_A775SerasaCountAcoes_F = new short[1] ;
         BC002E47_n775SerasaCountAcoes_F = new bool[] {false} ;
         BC002E47_A776SerasaCountEnderecos_F = new short[1] ;
         BC002E47_n776SerasaCountEnderecos_F = new bool[] {false} ;
         BC002E47_A777SerasaCountProtestos_F = new short[1] ;
         BC002E47_n777SerasaCountProtestos_F = new bool[] {false} ;
         BC002E47_A778SerasaCountOcorrencias_F = new short[1] ;
         BC002E47_n778SerasaCountOcorrencias_F = new bool[] {false} ;
         BC002E47_A779SerasaCountCheques_F = new short[1] ;
         BC002E47_n779SerasaCountCheques_F = new bool[] {false} ;
         i665SerasaCreatedAt = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.serasa_bc__default(),
            new Object[][] {
                new Object[] {
               BC002E2_A662SerasaId, BC002E2_A665SerasaCreatedAt, BC002E2_n665SerasaCreatedAt, BC002E2_A663SerasaNumeroProposta, BC002E2_n663SerasaNumeroProposta, BC002E2_A664SerasaPolitica, BC002E2_n664SerasaPolitica, BC002E2_A666SerasaTipoVenda, BC002E2_n666SerasaTipoVenda, BC002E2_A667SerasaCodTipoVenda,
               BC002E2_n667SerasaCodTipoVenda, BC002E2_A668SerasaCodNivelRisco, BC002E2_n668SerasaCodNivelRisco, BC002E2_A669SerasaTipoRecomendacao, BC002E2_n669SerasaTipoRecomendacao, BC002E2_A670SerasaRecomendacaoVenda, BC002E2_n670SerasaRecomendacaoVenda, BC002E2_A671SerasaCpfRegular, BC002E2_n671SerasaCpfRegular, BC002E2_A672SerasaRetricaoAtiva,
               BC002E2_n672SerasaRetricaoAtiva, BC002E2_A673SerasaProtestoAtivo, BC002E2_n673SerasaProtestoAtivo, BC002E2_A674SerasaBaixoComprometimento, BC002E2_n674SerasaBaixoComprometimento, BC002E2_A675SerasaValorLimiteRecomendado, BC002E2_n675SerasaValorLimiteRecomendado, BC002E2_A676SerasaFaixaDeRendaEstimada, BC002E2_n676SerasaFaixaDeRendaEstimada, BC002E2_A677SerasaMensagemRendaEstimada,
               BC002E2_n677SerasaMensagemRendaEstimada, BC002E2_A678SerasaAnotacoesCompletas, BC002E2_n678SerasaAnotacoesCompletas, BC002E2_A679SerasaConsultasDetalhadas, BC002E2_n679SerasaConsultasDetalhadas, BC002E2_A680SerasaAnotacoesConsultaSPC, BC002E2_n680SerasaAnotacoesConsultaSPC, BC002E2_A681SerasaParticipacaoSocietaria, BC002E2_n681SerasaParticipacaoSocietaria, BC002E2_A682SerasaRendaEstimada,
               BC002E2_n682SerasaRendaEstimada, BC002E2_A683SerasaHistoricoPagamentoPF, BC002E2_n683SerasaHistoricoPagamentoPF, BC002E2_A684SerasaRecomendaCompleto, BC002E2_n684SerasaRecomendaCompleto, BC002E2_A685SerasaScore, BC002E2_n685SerasaScore, BC002E2_A686SerasaTaxa, BC002E2_n686SerasaTaxa, BC002E2_A687SerasaMensagemScore,
               BC002E2_n687SerasaMensagemScore, BC002E2_A688SerasaSituacaoCPF, BC002E2_n688SerasaSituacaoCPF, BC002E2_A689SerasaDataNascimento, BC002E2_n689SerasaDataNascimento, BC002E2_A690SerasaGenero, BC002E2_n690SerasaGenero, BC002E2_A691SerasaNomeMae, BC002E2_n691SerasaNomeMae, BC002E2_A692SerasaGrafia,
               BC002E2_n692SerasaGrafia, BC002E2_A774SerasaJSON, BC002E2_n774SerasaJSON, BC002E2_A168ClienteId, BC002E2_n168ClienteId
               }
               , new Object[] {
               BC002E3_A662SerasaId, BC002E3_A665SerasaCreatedAt, BC002E3_n665SerasaCreatedAt, BC002E3_A663SerasaNumeroProposta, BC002E3_n663SerasaNumeroProposta, BC002E3_A664SerasaPolitica, BC002E3_n664SerasaPolitica, BC002E3_A666SerasaTipoVenda, BC002E3_n666SerasaTipoVenda, BC002E3_A667SerasaCodTipoVenda,
               BC002E3_n667SerasaCodTipoVenda, BC002E3_A668SerasaCodNivelRisco, BC002E3_n668SerasaCodNivelRisco, BC002E3_A669SerasaTipoRecomendacao, BC002E3_n669SerasaTipoRecomendacao, BC002E3_A670SerasaRecomendacaoVenda, BC002E3_n670SerasaRecomendacaoVenda, BC002E3_A671SerasaCpfRegular, BC002E3_n671SerasaCpfRegular, BC002E3_A672SerasaRetricaoAtiva,
               BC002E3_n672SerasaRetricaoAtiva, BC002E3_A673SerasaProtestoAtivo, BC002E3_n673SerasaProtestoAtivo, BC002E3_A674SerasaBaixoComprometimento, BC002E3_n674SerasaBaixoComprometimento, BC002E3_A675SerasaValorLimiteRecomendado, BC002E3_n675SerasaValorLimiteRecomendado, BC002E3_A676SerasaFaixaDeRendaEstimada, BC002E3_n676SerasaFaixaDeRendaEstimada, BC002E3_A677SerasaMensagemRendaEstimada,
               BC002E3_n677SerasaMensagemRendaEstimada, BC002E3_A678SerasaAnotacoesCompletas, BC002E3_n678SerasaAnotacoesCompletas, BC002E3_A679SerasaConsultasDetalhadas, BC002E3_n679SerasaConsultasDetalhadas, BC002E3_A680SerasaAnotacoesConsultaSPC, BC002E3_n680SerasaAnotacoesConsultaSPC, BC002E3_A681SerasaParticipacaoSocietaria, BC002E3_n681SerasaParticipacaoSocietaria, BC002E3_A682SerasaRendaEstimada,
               BC002E3_n682SerasaRendaEstimada, BC002E3_A683SerasaHistoricoPagamentoPF, BC002E3_n683SerasaHistoricoPagamentoPF, BC002E3_A684SerasaRecomendaCompleto, BC002E3_n684SerasaRecomendaCompleto, BC002E3_A685SerasaScore, BC002E3_n685SerasaScore, BC002E3_A686SerasaTaxa, BC002E3_n686SerasaTaxa, BC002E3_A687SerasaMensagemScore,
               BC002E3_n687SerasaMensagemScore, BC002E3_A688SerasaSituacaoCPF, BC002E3_n688SerasaSituacaoCPF, BC002E3_A689SerasaDataNascimento, BC002E3_n689SerasaDataNascimento, BC002E3_A690SerasaGenero, BC002E3_n690SerasaGenero, BC002E3_A691SerasaNomeMae, BC002E3_n691SerasaNomeMae, BC002E3_A692SerasaGrafia,
               BC002E3_n692SerasaGrafia, BC002E3_A774SerasaJSON, BC002E3_n774SerasaJSON, BC002E3_A168ClienteId, BC002E3_n168ClienteId
               }
               , new Object[] {
               BC002E4_A170ClienteRazaoSocial, BC002E4_n170ClienteRazaoSocial
               }
               , new Object[] {
               BC002E6_A775SerasaCountAcoes_F, BC002E6_n775SerasaCountAcoes_F
               }
               , new Object[] {
               BC002E8_A776SerasaCountEnderecos_F, BC002E8_n776SerasaCountEnderecos_F
               }
               , new Object[] {
               BC002E10_A777SerasaCountProtestos_F, BC002E10_n777SerasaCountProtestos_F
               }
               , new Object[] {
               BC002E12_A778SerasaCountOcorrencias_F, BC002E12_n778SerasaCountOcorrencias_F
               }
               , new Object[] {
               BC002E14_A779SerasaCountCheques_F, BC002E14_n779SerasaCountCheques_F
               }
               , new Object[] {
               BC002E20_A662SerasaId, BC002E20_A665SerasaCreatedAt, BC002E20_n665SerasaCreatedAt, BC002E20_A170ClienteRazaoSocial, BC002E20_n170ClienteRazaoSocial, BC002E20_A663SerasaNumeroProposta, BC002E20_n663SerasaNumeroProposta, BC002E20_A664SerasaPolitica, BC002E20_n664SerasaPolitica, BC002E20_A666SerasaTipoVenda,
               BC002E20_n666SerasaTipoVenda, BC002E20_A667SerasaCodTipoVenda, BC002E20_n667SerasaCodTipoVenda, BC002E20_A668SerasaCodNivelRisco, BC002E20_n668SerasaCodNivelRisco, BC002E20_A669SerasaTipoRecomendacao, BC002E20_n669SerasaTipoRecomendacao, BC002E20_A670SerasaRecomendacaoVenda, BC002E20_n670SerasaRecomendacaoVenda, BC002E20_A671SerasaCpfRegular,
               BC002E20_n671SerasaCpfRegular, BC002E20_A672SerasaRetricaoAtiva, BC002E20_n672SerasaRetricaoAtiva, BC002E20_A673SerasaProtestoAtivo, BC002E20_n673SerasaProtestoAtivo, BC002E20_A674SerasaBaixoComprometimento, BC002E20_n674SerasaBaixoComprometimento, BC002E20_A675SerasaValorLimiteRecomendado, BC002E20_n675SerasaValorLimiteRecomendado, BC002E20_A676SerasaFaixaDeRendaEstimada,
               BC002E20_n676SerasaFaixaDeRendaEstimada, BC002E20_A677SerasaMensagemRendaEstimada, BC002E20_n677SerasaMensagemRendaEstimada, BC002E20_A678SerasaAnotacoesCompletas, BC002E20_n678SerasaAnotacoesCompletas, BC002E20_A679SerasaConsultasDetalhadas, BC002E20_n679SerasaConsultasDetalhadas, BC002E20_A680SerasaAnotacoesConsultaSPC, BC002E20_n680SerasaAnotacoesConsultaSPC, BC002E20_A681SerasaParticipacaoSocietaria,
               BC002E20_n681SerasaParticipacaoSocietaria, BC002E20_A682SerasaRendaEstimada, BC002E20_n682SerasaRendaEstimada, BC002E20_A683SerasaHistoricoPagamentoPF, BC002E20_n683SerasaHistoricoPagamentoPF, BC002E20_A684SerasaRecomendaCompleto, BC002E20_n684SerasaRecomendaCompleto, BC002E20_A685SerasaScore, BC002E20_n685SerasaScore, BC002E20_A686SerasaTaxa,
               BC002E20_n686SerasaTaxa, BC002E20_A687SerasaMensagemScore, BC002E20_n687SerasaMensagemScore, BC002E20_A688SerasaSituacaoCPF, BC002E20_n688SerasaSituacaoCPF, BC002E20_A689SerasaDataNascimento, BC002E20_n689SerasaDataNascimento, BC002E20_A690SerasaGenero, BC002E20_n690SerasaGenero, BC002E20_A691SerasaNomeMae,
               BC002E20_n691SerasaNomeMae, BC002E20_A692SerasaGrafia, BC002E20_n692SerasaGrafia, BC002E20_A774SerasaJSON, BC002E20_n774SerasaJSON, BC002E20_A168ClienteId, BC002E20_n168ClienteId, BC002E20_A775SerasaCountAcoes_F, BC002E20_n775SerasaCountAcoes_F, BC002E20_A776SerasaCountEnderecos_F,
               BC002E20_n776SerasaCountEnderecos_F, BC002E20_A777SerasaCountProtestos_F, BC002E20_n777SerasaCountProtestos_F, BC002E20_A778SerasaCountOcorrencias_F, BC002E20_n778SerasaCountOcorrencias_F, BC002E20_A779SerasaCountCheques_F, BC002E20_n779SerasaCountCheques_F
               }
               , new Object[] {
               BC002E21_A662SerasaId
               }
               , new Object[] {
               }
               , new Object[] {
               BC002E23_A662SerasaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002E27_A775SerasaCountAcoes_F, BC002E27_n775SerasaCountAcoes_F
               }
               , new Object[] {
               BC002E29_A776SerasaCountEnderecos_F, BC002E29_n776SerasaCountEnderecos_F
               }
               , new Object[] {
               BC002E31_A777SerasaCountProtestos_F, BC002E31_n777SerasaCountProtestos_F
               }
               , new Object[] {
               BC002E33_A778SerasaCountOcorrencias_F, BC002E33_n778SerasaCountOcorrencias_F
               }
               , new Object[] {
               BC002E35_A779SerasaCountCheques_F, BC002E35_n779SerasaCountCheques_F
               }
               , new Object[] {
               BC002E36_A170ClienteRazaoSocial, BC002E36_n170ClienteRazaoSocial
               }
               , new Object[] {
               BC002E37_A726SerasaOcorrenciasId
               }
               , new Object[] {
               BC002E38_A716SerasaEnderecosId
               }
               , new Object[] {
               BC002E39_A711SerasaProtestosId
               }
               , new Object[] {
               BC002E40_A699SerasaAcoesId
               }
               , new Object[] {
               BC002E41_A693SerasaChequesId
               }
               , new Object[] {
               BC002E47_A662SerasaId, BC002E47_A665SerasaCreatedAt, BC002E47_n665SerasaCreatedAt, BC002E47_A170ClienteRazaoSocial, BC002E47_n170ClienteRazaoSocial, BC002E47_A663SerasaNumeroProposta, BC002E47_n663SerasaNumeroProposta, BC002E47_A664SerasaPolitica, BC002E47_n664SerasaPolitica, BC002E47_A666SerasaTipoVenda,
               BC002E47_n666SerasaTipoVenda, BC002E47_A667SerasaCodTipoVenda, BC002E47_n667SerasaCodTipoVenda, BC002E47_A668SerasaCodNivelRisco, BC002E47_n668SerasaCodNivelRisco, BC002E47_A669SerasaTipoRecomendacao, BC002E47_n669SerasaTipoRecomendacao, BC002E47_A670SerasaRecomendacaoVenda, BC002E47_n670SerasaRecomendacaoVenda, BC002E47_A671SerasaCpfRegular,
               BC002E47_n671SerasaCpfRegular, BC002E47_A672SerasaRetricaoAtiva, BC002E47_n672SerasaRetricaoAtiva, BC002E47_A673SerasaProtestoAtivo, BC002E47_n673SerasaProtestoAtivo, BC002E47_A674SerasaBaixoComprometimento, BC002E47_n674SerasaBaixoComprometimento, BC002E47_A675SerasaValorLimiteRecomendado, BC002E47_n675SerasaValorLimiteRecomendado, BC002E47_A676SerasaFaixaDeRendaEstimada,
               BC002E47_n676SerasaFaixaDeRendaEstimada, BC002E47_A677SerasaMensagemRendaEstimada, BC002E47_n677SerasaMensagemRendaEstimada, BC002E47_A678SerasaAnotacoesCompletas, BC002E47_n678SerasaAnotacoesCompletas, BC002E47_A679SerasaConsultasDetalhadas, BC002E47_n679SerasaConsultasDetalhadas, BC002E47_A680SerasaAnotacoesConsultaSPC, BC002E47_n680SerasaAnotacoesConsultaSPC, BC002E47_A681SerasaParticipacaoSocietaria,
               BC002E47_n681SerasaParticipacaoSocietaria, BC002E47_A682SerasaRendaEstimada, BC002E47_n682SerasaRendaEstimada, BC002E47_A683SerasaHistoricoPagamentoPF, BC002E47_n683SerasaHistoricoPagamentoPF, BC002E47_A684SerasaRecomendaCompleto, BC002E47_n684SerasaRecomendaCompleto, BC002E47_A685SerasaScore, BC002E47_n685SerasaScore, BC002E47_A686SerasaTaxa,
               BC002E47_n686SerasaTaxa, BC002E47_A687SerasaMensagemScore, BC002E47_n687SerasaMensagemScore, BC002E47_A688SerasaSituacaoCPF, BC002E47_n688SerasaSituacaoCPF, BC002E47_A689SerasaDataNascimento, BC002E47_n689SerasaDataNascimento, BC002E47_A690SerasaGenero, BC002E47_n690SerasaGenero, BC002E47_A691SerasaNomeMae,
               BC002E47_n691SerasaNomeMae, BC002E47_A692SerasaGrafia, BC002E47_n692SerasaGrafia, BC002E47_A774SerasaJSON, BC002E47_n774SerasaJSON, BC002E47_A168ClienteId, BC002E47_n168ClienteId, BC002E47_A775SerasaCountAcoes_F, BC002E47_n775SerasaCountAcoes_F, BC002E47_A776SerasaCountEnderecos_F,
               BC002E47_n776SerasaCountEnderecos_F, BC002E47_A777SerasaCountProtestos_F, BC002E47_n777SerasaCountProtestos_F, BC002E47_A778SerasaCountOcorrencias_F, BC002E47_n778SerasaCountOcorrencias_F, BC002E47_A779SerasaCountCheques_F, BC002E47_n779SerasaCountCheques_F
               }
            }
         );
         AV19Pgmname = "Serasa_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E122E2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z685SerasaScore ;
      private short A685SerasaScore ;
      private short Z775SerasaCountAcoes_F ;
      private short A775SerasaCountAcoes_F ;
      private short Z776SerasaCountEnderecos_F ;
      private short A776SerasaCountEnderecos_F ;
      private short Z777SerasaCountProtestos_F ;
      private short A777SerasaCountProtestos_F ;
      private short Z778SerasaCountOcorrencias_F ;
      private short A778SerasaCountOcorrencias_F ;
      private short Z779SerasaCountCheques_F ;
      private short A779SerasaCountCheques_F ;
      private short RcdFound84 ;
      private int trnEnded ;
      private int Z662SerasaId ;
      private int A662SerasaId ;
      private int AV20GXV1 ;
      private int AV11Insert_ClienteId ;
      private int Z168ClienteId ;
      private int A168ClienteId ;
      private decimal Z664SerasaPolitica ;
      private decimal A664SerasaPolitica ;
      private decimal Z667SerasaCodTipoVenda ;
      private decimal A667SerasaCodTipoVenda ;
      private decimal Z668SerasaCodNivelRisco ;
      private decimal A668SerasaCodNivelRisco ;
      private decimal Z675SerasaValorLimiteRecomendado ;
      private decimal A675SerasaValorLimiteRecomendado ;
      private decimal Z676SerasaFaixaDeRendaEstimada ;
      private decimal A676SerasaFaixaDeRendaEstimada ;
      private decimal Z686SerasaTaxa ;
      private decimal A686SerasaTaxa ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV19Pgmname ;
      private string sMode84 ;
      private DateTime Z665SerasaCreatedAt ;
      private DateTime A665SerasaCreatedAt ;
      private DateTime i665SerasaCreatedAt ;
      private DateTime Z689SerasaDataNascimento ;
      private DateTime A689SerasaDataNascimento ;
      private bool returnInSub ;
      private bool Z671SerasaCpfRegular ;
      private bool A671SerasaCpfRegular ;
      private bool Z672SerasaRetricaoAtiva ;
      private bool A672SerasaRetricaoAtiva ;
      private bool Z673SerasaProtestoAtivo ;
      private bool A673SerasaProtestoAtivo ;
      private bool Z674SerasaBaixoComprometimento ;
      private bool A674SerasaBaixoComprometimento ;
      private bool Z678SerasaAnotacoesCompletas ;
      private bool A678SerasaAnotacoesCompletas ;
      private bool Z679SerasaConsultasDetalhadas ;
      private bool A679SerasaConsultasDetalhadas ;
      private bool Z680SerasaAnotacoesConsultaSPC ;
      private bool A680SerasaAnotacoesConsultaSPC ;
      private bool Z681SerasaParticipacaoSocietaria ;
      private bool A681SerasaParticipacaoSocietaria ;
      private bool Z682SerasaRendaEstimada ;
      private bool A682SerasaRendaEstimada ;
      private bool Z683SerasaHistoricoPagamentoPF ;
      private bool A683SerasaHistoricoPagamentoPF ;
      private bool Z684SerasaRecomendaCompleto ;
      private bool A684SerasaRecomendaCompleto ;
      private bool n665SerasaCreatedAt ;
      private bool n662SerasaId ;
      private bool n170ClienteRazaoSocial ;
      private bool n663SerasaNumeroProposta ;
      private bool n664SerasaPolitica ;
      private bool n666SerasaTipoVenda ;
      private bool n667SerasaCodTipoVenda ;
      private bool n668SerasaCodNivelRisco ;
      private bool n669SerasaTipoRecomendacao ;
      private bool n670SerasaRecomendacaoVenda ;
      private bool n671SerasaCpfRegular ;
      private bool n672SerasaRetricaoAtiva ;
      private bool n673SerasaProtestoAtivo ;
      private bool n674SerasaBaixoComprometimento ;
      private bool n675SerasaValorLimiteRecomendado ;
      private bool n676SerasaFaixaDeRendaEstimada ;
      private bool n677SerasaMensagemRendaEstimada ;
      private bool n678SerasaAnotacoesCompletas ;
      private bool n679SerasaConsultasDetalhadas ;
      private bool n680SerasaAnotacoesConsultaSPC ;
      private bool n681SerasaParticipacaoSocietaria ;
      private bool n682SerasaRendaEstimada ;
      private bool n683SerasaHistoricoPagamentoPF ;
      private bool n684SerasaRecomendaCompleto ;
      private bool n685SerasaScore ;
      private bool n686SerasaTaxa ;
      private bool n687SerasaMensagemScore ;
      private bool n688SerasaSituacaoCPF ;
      private bool n689SerasaDataNascimento ;
      private bool n690SerasaGenero ;
      private bool n691SerasaNomeMae ;
      private bool n692SerasaGrafia ;
      private bool n774SerasaJSON ;
      private bool n168ClienteId ;
      private bool n775SerasaCountAcoes_F ;
      private bool n776SerasaCountEnderecos_F ;
      private bool n777SerasaCountProtestos_F ;
      private bool n778SerasaCountOcorrencias_F ;
      private bool n779SerasaCountCheques_F ;
      private bool Gx_longc ;
      private string Z774SerasaJSON ;
      private string A774SerasaJSON ;
      private string Z663SerasaNumeroProposta ;
      private string A663SerasaNumeroProposta ;
      private string Z666SerasaTipoVenda ;
      private string A666SerasaTipoVenda ;
      private string Z669SerasaTipoRecomendacao ;
      private string A669SerasaTipoRecomendacao ;
      private string Z670SerasaRecomendacaoVenda ;
      private string A670SerasaRecomendacaoVenda ;
      private string Z677SerasaMensagemRendaEstimada ;
      private string A677SerasaMensagemRendaEstimada ;
      private string Z687SerasaMensagemScore ;
      private string A687SerasaMensagemScore ;
      private string Z688SerasaSituacaoCPF ;
      private string A688SerasaSituacaoCPF ;
      private string Z690SerasaGenero ;
      private string A690SerasaGenero ;
      private string Z691SerasaNomeMae ;
      private string A691SerasaNomeMae ;
      private string Z692SerasaGrafia ;
      private string A692SerasaGrafia ;
      private string Z170ClienteRazaoSocial ;
      private string A170ClienteRazaoSocial ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] BC002E20_A662SerasaId ;
      private bool[] BC002E20_n662SerasaId ;
      private DateTime[] BC002E20_A665SerasaCreatedAt ;
      private bool[] BC002E20_n665SerasaCreatedAt ;
      private string[] BC002E20_A170ClienteRazaoSocial ;
      private bool[] BC002E20_n170ClienteRazaoSocial ;
      private string[] BC002E20_A663SerasaNumeroProposta ;
      private bool[] BC002E20_n663SerasaNumeroProposta ;
      private decimal[] BC002E20_A664SerasaPolitica ;
      private bool[] BC002E20_n664SerasaPolitica ;
      private string[] BC002E20_A666SerasaTipoVenda ;
      private bool[] BC002E20_n666SerasaTipoVenda ;
      private decimal[] BC002E20_A667SerasaCodTipoVenda ;
      private bool[] BC002E20_n667SerasaCodTipoVenda ;
      private decimal[] BC002E20_A668SerasaCodNivelRisco ;
      private bool[] BC002E20_n668SerasaCodNivelRisco ;
      private string[] BC002E20_A669SerasaTipoRecomendacao ;
      private bool[] BC002E20_n669SerasaTipoRecomendacao ;
      private string[] BC002E20_A670SerasaRecomendacaoVenda ;
      private bool[] BC002E20_n670SerasaRecomendacaoVenda ;
      private bool[] BC002E20_A671SerasaCpfRegular ;
      private bool[] BC002E20_n671SerasaCpfRegular ;
      private bool[] BC002E20_A672SerasaRetricaoAtiva ;
      private bool[] BC002E20_n672SerasaRetricaoAtiva ;
      private bool[] BC002E20_A673SerasaProtestoAtivo ;
      private bool[] BC002E20_n673SerasaProtestoAtivo ;
      private bool[] BC002E20_A674SerasaBaixoComprometimento ;
      private bool[] BC002E20_n674SerasaBaixoComprometimento ;
      private decimal[] BC002E20_A675SerasaValorLimiteRecomendado ;
      private bool[] BC002E20_n675SerasaValorLimiteRecomendado ;
      private decimal[] BC002E20_A676SerasaFaixaDeRendaEstimada ;
      private bool[] BC002E20_n676SerasaFaixaDeRendaEstimada ;
      private string[] BC002E20_A677SerasaMensagemRendaEstimada ;
      private bool[] BC002E20_n677SerasaMensagemRendaEstimada ;
      private bool[] BC002E20_A678SerasaAnotacoesCompletas ;
      private bool[] BC002E20_n678SerasaAnotacoesCompletas ;
      private bool[] BC002E20_A679SerasaConsultasDetalhadas ;
      private bool[] BC002E20_n679SerasaConsultasDetalhadas ;
      private bool[] BC002E20_A680SerasaAnotacoesConsultaSPC ;
      private bool[] BC002E20_n680SerasaAnotacoesConsultaSPC ;
      private bool[] BC002E20_A681SerasaParticipacaoSocietaria ;
      private bool[] BC002E20_n681SerasaParticipacaoSocietaria ;
      private bool[] BC002E20_A682SerasaRendaEstimada ;
      private bool[] BC002E20_n682SerasaRendaEstimada ;
      private bool[] BC002E20_A683SerasaHistoricoPagamentoPF ;
      private bool[] BC002E20_n683SerasaHistoricoPagamentoPF ;
      private bool[] BC002E20_A684SerasaRecomendaCompleto ;
      private bool[] BC002E20_n684SerasaRecomendaCompleto ;
      private short[] BC002E20_A685SerasaScore ;
      private bool[] BC002E20_n685SerasaScore ;
      private decimal[] BC002E20_A686SerasaTaxa ;
      private bool[] BC002E20_n686SerasaTaxa ;
      private string[] BC002E20_A687SerasaMensagemScore ;
      private bool[] BC002E20_n687SerasaMensagemScore ;
      private string[] BC002E20_A688SerasaSituacaoCPF ;
      private bool[] BC002E20_n688SerasaSituacaoCPF ;
      private DateTime[] BC002E20_A689SerasaDataNascimento ;
      private bool[] BC002E20_n689SerasaDataNascimento ;
      private string[] BC002E20_A690SerasaGenero ;
      private bool[] BC002E20_n690SerasaGenero ;
      private string[] BC002E20_A691SerasaNomeMae ;
      private bool[] BC002E20_n691SerasaNomeMae ;
      private string[] BC002E20_A692SerasaGrafia ;
      private bool[] BC002E20_n692SerasaGrafia ;
      private string[] BC002E20_A774SerasaJSON ;
      private bool[] BC002E20_n774SerasaJSON ;
      private int[] BC002E20_A168ClienteId ;
      private bool[] BC002E20_n168ClienteId ;
      private short[] BC002E20_A775SerasaCountAcoes_F ;
      private bool[] BC002E20_n775SerasaCountAcoes_F ;
      private short[] BC002E20_A776SerasaCountEnderecos_F ;
      private bool[] BC002E20_n776SerasaCountEnderecos_F ;
      private short[] BC002E20_A777SerasaCountProtestos_F ;
      private bool[] BC002E20_n777SerasaCountProtestos_F ;
      private short[] BC002E20_A778SerasaCountOcorrencias_F ;
      private bool[] BC002E20_n778SerasaCountOcorrencias_F ;
      private short[] BC002E20_A779SerasaCountCheques_F ;
      private bool[] BC002E20_n779SerasaCountCheques_F ;
      private short[] BC002E6_A775SerasaCountAcoes_F ;
      private bool[] BC002E6_n775SerasaCountAcoes_F ;
      private short[] BC002E8_A776SerasaCountEnderecos_F ;
      private bool[] BC002E8_n776SerasaCountEnderecos_F ;
      private short[] BC002E10_A777SerasaCountProtestos_F ;
      private bool[] BC002E10_n777SerasaCountProtestos_F ;
      private short[] BC002E12_A778SerasaCountOcorrencias_F ;
      private bool[] BC002E12_n778SerasaCountOcorrencias_F ;
      private short[] BC002E14_A779SerasaCountCheques_F ;
      private bool[] BC002E14_n779SerasaCountCheques_F ;
      private string[] BC002E4_A170ClienteRazaoSocial ;
      private bool[] BC002E4_n170ClienteRazaoSocial ;
      private int[] BC002E21_A662SerasaId ;
      private bool[] BC002E21_n662SerasaId ;
      private int[] BC002E3_A662SerasaId ;
      private bool[] BC002E3_n662SerasaId ;
      private DateTime[] BC002E3_A665SerasaCreatedAt ;
      private bool[] BC002E3_n665SerasaCreatedAt ;
      private string[] BC002E3_A663SerasaNumeroProposta ;
      private bool[] BC002E3_n663SerasaNumeroProposta ;
      private decimal[] BC002E3_A664SerasaPolitica ;
      private bool[] BC002E3_n664SerasaPolitica ;
      private string[] BC002E3_A666SerasaTipoVenda ;
      private bool[] BC002E3_n666SerasaTipoVenda ;
      private decimal[] BC002E3_A667SerasaCodTipoVenda ;
      private bool[] BC002E3_n667SerasaCodTipoVenda ;
      private decimal[] BC002E3_A668SerasaCodNivelRisco ;
      private bool[] BC002E3_n668SerasaCodNivelRisco ;
      private string[] BC002E3_A669SerasaTipoRecomendacao ;
      private bool[] BC002E3_n669SerasaTipoRecomendacao ;
      private string[] BC002E3_A670SerasaRecomendacaoVenda ;
      private bool[] BC002E3_n670SerasaRecomendacaoVenda ;
      private bool[] BC002E3_A671SerasaCpfRegular ;
      private bool[] BC002E3_n671SerasaCpfRegular ;
      private bool[] BC002E3_A672SerasaRetricaoAtiva ;
      private bool[] BC002E3_n672SerasaRetricaoAtiva ;
      private bool[] BC002E3_A673SerasaProtestoAtivo ;
      private bool[] BC002E3_n673SerasaProtestoAtivo ;
      private bool[] BC002E3_A674SerasaBaixoComprometimento ;
      private bool[] BC002E3_n674SerasaBaixoComprometimento ;
      private decimal[] BC002E3_A675SerasaValorLimiteRecomendado ;
      private bool[] BC002E3_n675SerasaValorLimiteRecomendado ;
      private decimal[] BC002E3_A676SerasaFaixaDeRendaEstimada ;
      private bool[] BC002E3_n676SerasaFaixaDeRendaEstimada ;
      private string[] BC002E3_A677SerasaMensagemRendaEstimada ;
      private bool[] BC002E3_n677SerasaMensagemRendaEstimada ;
      private bool[] BC002E3_A678SerasaAnotacoesCompletas ;
      private bool[] BC002E3_n678SerasaAnotacoesCompletas ;
      private bool[] BC002E3_A679SerasaConsultasDetalhadas ;
      private bool[] BC002E3_n679SerasaConsultasDetalhadas ;
      private bool[] BC002E3_A680SerasaAnotacoesConsultaSPC ;
      private bool[] BC002E3_n680SerasaAnotacoesConsultaSPC ;
      private bool[] BC002E3_A681SerasaParticipacaoSocietaria ;
      private bool[] BC002E3_n681SerasaParticipacaoSocietaria ;
      private bool[] BC002E3_A682SerasaRendaEstimada ;
      private bool[] BC002E3_n682SerasaRendaEstimada ;
      private bool[] BC002E3_A683SerasaHistoricoPagamentoPF ;
      private bool[] BC002E3_n683SerasaHistoricoPagamentoPF ;
      private bool[] BC002E3_A684SerasaRecomendaCompleto ;
      private bool[] BC002E3_n684SerasaRecomendaCompleto ;
      private short[] BC002E3_A685SerasaScore ;
      private bool[] BC002E3_n685SerasaScore ;
      private decimal[] BC002E3_A686SerasaTaxa ;
      private bool[] BC002E3_n686SerasaTaxa ;
      private string[] BC002E3_A687SerasaMensagemScore ;
      private bool[] BC002E3_n687SerasaMensagemScore ;
      private string[] BC002E3_A688SerasaSituacaoCPF ;
      private bool[] BC002E3_n688SerasaSituacaoCPF ;
      private DateTime[] BC002E3_A689SerasaDataNascimento ;
      private bool[] BC002E3_n689SerasaDataNascimento ;
      private string[] BC002E3_A690SerasaGenero ;
      private bool[] BC002E3_n690SerasaGenero ;
      private string[] BC002E3_A691SerasaNomeMae ;
      private bool[] BC002E3_n691SerasaNomeMae ;
      private string[] BC002E3_A692SerasaGrafia ;
      private bool[] BC002E3_n692SerasaGrafia ;
      private string[] BC002E3_A774SerasaJSON ;
      private bool[] BC002E3_n774SerasaJSON ;
      private int[] BC002E3_A168ClienteId ;
      private bool[] BC002E3_n168ClienteId ;
      private int[] BC002E2_A662SerasaId ;
      private bool[] BC002E2_n662SerasaId ;
      private DateTime[] BC002E2_A665SerasaCreatedAt ;
      private bool[] BC002E2_n665SerasaCreatedAt ;
      private string[] BC002E2_A663SerasaNumeroProposta ;
      private bool[] BC002E2_n663SerasaNumeroProposta ;
      private decimal[] BC002E2_A664SerasaPolitica ;
      private bool[] BC002E2_n664SerasaPolitica ;
      private string[] BC002E2_A666SerasaTipoVenda ;
      private bool[] BC002E2_n666SerasaTipoVenda ;
      private decimal[] BC002E2_A667SerasaCodTipoVenda ;
      private bool[] BC002E2_n667SerasaCodTipoVenda ;
      private decimal[] BC002E2_A668SerasaCodNivelRisco ;
      private bool[] BC002E2_n668SerasaCodNivelRisco ;
      private string[] BC002E2_A669SerasaTipoRecomendacao ;
      private bool[] BC002E2_n669SerasaTipoRecomendacao ;
      private string[] BC002E2_A670SerasaRecomendacaoVenda ;
      private bool[] BC002E2_n670SerasaRecomendacaoVenda ;
      private bool[] BC002E2_A671SerasaCpfRegular ;
      private bool[] BC002E2_n671SerasaCpfRegular ;
      private bool[] BC002E2_A672SerasaRetricaoAtiva ;
      private bool[] BC002E2_n672SerasaRetricaoAtiva ;
      private bool[] BC002E2_A673SerasaProtestoAtivo ;
      private bool[] BC002E2_n673SerasaProtestoAtivo ;
      private bool[] BC002E2_A674SerasaBaixoComprometimento ;
      private bool[] BC002E2_n674SerasaBaixoComprometimento ;
      private decimal[] BC002E2_A675SerasaValorLimiteRecomendado ;
      private bool[] BC002E2_n675SerasaValorLimiteRecomendado ;
      private decimal[] BC002E2_A676SerasaFaixaDeRendaEstimada ;
      private bool[] BC002E2_n676SerasaFaixaDeRendaEstimada ;
      private string[] BC002E2_A677SerasaMensagemRendaEstimada ;
      private bool[] BC002E2_n677SerasaMensagemRendaEstimada ;
      private bool[] BC002E2_A678SerasaAnotacoesCompletas ;
      private bool[] BC002E2_n678SerasaAnotacoesCompletas ;
      private bool[] BC002E2_A679SerasaConsultasDetalhadas ;
      private bool[] BC002E2_n679SerasaConsultasDetalhadas ;
      private bool[] BC002E2_A680SerasaAnotacoesConsultaSPC ;
      private bool[] BC002E2_n680SerasaAnotacoesConsultaSPC ;
      private bool[] BC002E2_A681SerasaParticipacaoSocietaria ;
      private bool[] BC002E2_n681SerasaParticipacaoSocietaria ;
      private bool[] BC002E2_A682SerasaRendaEstimada ;
      private bool[] BC002E2_n682SerasaRendaEstimada ;
      private bool[] BC002E2_A683SerasaHistoricoPagamentoPF ;
      private bool[] BC002E2_n683SerasaHistoricoPagamentoPF ;
      private bool[] BC002E2_A684SerasaRecomendaCompleto ;
      private bool[] BC002E2_n684SerasaRecomendaCompleto ;
      private short[] BC002E2_A685SerasaScore ;
      private bool[] BC002E2_n685SerasaScore ;
      private decimal[] BC002E2_A686SerasaTaxa ;
      private bool[] BC002E2_n686SerasaTaxa ;
      private string[] BC002E2_A687SerasaMensagemScore ;
      private bool[] BC002E2_n687SerasaMensagemScore ;
      private string[] BC002E2_A688SerasaSituacaoCPF ;
      private bool[] BC002E2_n688SerasaSituacaoCPF ;
      private DateTime[] BC002E2_A689SerasaDataNascimento ;
      private bool[] BC002E2_n689SerasaDataNascimento ;
      private string[] BC002E2_A690SerasaGenero ;
      private bool[] BC002E2_n690SerasaGenero ;
      private string[] BC002E2_A691SerasaNomeMae ;
      private bool[] BC002E2_n691SerasaNomeMae ;
      private string[] BC002E2_A692SerasaGrafia ;
      private bool[] BC002E2_n692SerasaGrafia ;
      private string[] BC002E2_A774SerasaJSON ;
      private bool[] BC002E2_n774SerasaJSON ;
      private int[] BC002E2_A168ClienteId ;
      private bool[] BC002E2_n168ClienteId ;
      private int[] BC002E23_A662SerasaId ;
      private bool[] BC002E23_n662SerasaId ;
      private short[] BC002E27_A775SerasaCountAcoes_F ;
      private bool[] BC002E27_n775SerasaCountAcoes_F ;
      private short[] BC002E29_A776SerasaCountEnderecos_F ;
      private bool[] BC002E29_n776SerasaCountEnderecos_F ;
      private short[] BC002E31_A777SerasaCountProtestos_F ;
      private bool[] BC002E31_n777SerasaCountProtestos_F ;
      private short[] BC002E33_A778SerasaCountOcorrencias_F ;
      private bool[] BC002E33_n778SerasaCountOcorrencias_F ;
      private short[] BC002E35_A779SerasaCountCheques_F ;
      private bool[] BC002E35_n779SerasaCountCheques_F ;
      private string[] BC002E36_A170ClienteRazaoSocial ;
      private bool[] BC002E36_n170ClienteRazaoSocial ;
      private int[] BC002E37_A726SerasaOcorrenciasId ;
      private int[] BC002E38_A716SerasaEnderecosId ;
      private int[] BC002E39_A711SerasaProtestosId ;
      private int[] BC002E40_A699SerasaAcoesId ;
      private int[] BC002E41_A693SerasaChequesId ;
      private int[] BC002E47_A662SerasaId ;
      private bool[] BC002E47_n662SerasaId ;
      private DateTime[] BC002E47_A665SerasaCreatedAt ;
      private bool[] BC002E47_n665SerasaCreatedAt ;
      private string[] BC002E47_A170ClienteRazaoSocial ;
      private bool[] BC002E47_n170ClienteRazaoSocial ;
      private string[] BC002E47_A663SerasaNumeroProposta ;
      private bool[] BC002E47_n663SerasaNumeroProposta ;
      private decimal[] BC002E47_A664SerasaPolitica ;
      private bool[] BC002E47_n664SerasaPolitica ;
      private string[] BC002E47_A666SerasaTipoVenda ;
      private bool[] BC002E47_n666SerasaTipoVenda ;
      private decimal[] BC002E47_A667SerasaCodTipoVenda ;
      private bool[] BC002E47_n667SerasaCodTipoVenda ;
      private decimal[] BC002E47_A668SerasaCodNivelRisco ;
      private bool[] BC002E47_n668SerasaCodNivelRisco ;
      private string[] BC002E47_A669SerasaTipoRecomendacao ;
      private bool[] BC002E47_n669SerasaTipoRecomendacao ;
      private string[] BC002E47_A670SerasaRecomendacaoVenda ;
      private bool[] BC002E47_n670SerasaRecomendacaoVenda ;
      private bool[] BC002E47_A671SerasaCpfRegular ;
      private bool[] BC002E47_n671SerasaCpfRegular ;
      private bool[] BC002E47_A672SerasaRetricaoAtiva ;
      private bool[] BC002E47_n672SerasaRetricaoAtiva ;
      private bool[] BC002E47_A673SerasaProtestoAtivo ;
      private bool[] BC002E47_n673SerasaProtestoAtivo ;
      private bool[] BC002E47_A674SerasaBaixoComprometimento ;
      private bool[] BC002E47_n674SerasaBaixoComprometimento ;
      private decimal[] BC002E47_A675SerasaValorLimiteRecomendado ;
      private bool[] BC002E47_n675SerasaValorLimiteRecomendado ;
      private decimal[] BC002E47_A676SerasaFaixaDeRendaEstimada ;
      private bool[] BC002E47_n676SerasaFaixaDeRendaEstimada ;
      private string[] BC002E47_A677SerasaMensagemRendaEstimada ;
      private bool[] BC002E47_n677SerasaMensagemRendaEstimada ;
      private bool[] BC002E47_A678SerasaAnotacoesCompletas ;
      private bool[] BC002E47_n678SerasaAnotacoesCompletas ;
      private bool[] BC002E47_A679SerasaConsultasDetalhadas ;
      private bool[] BC002E47_n679SerasaConsultasDetalhadas ;
      private bool[] BC002E47_A680SerasaAnotacoesConsultaSPC ;
      private bool[] BC002E47_n680SerasaAnotacoesConsultaSPC ;
      private bool[] BC002E47_A681SerasaParticipacaoSocietaria ;
      private bool[] BC002E47_n681SerasaParticipacaoSocietaria ;
      private bool[] BC002E47_A682SerasaRendaEstimada ;
      private bool[] BC002E47_n682SerasaRendaEstimada ;
      private bool[] BC002E47_A683SerasaHistoricoPagamentoPF ;
      private bool[] BC002E47_n683SerasaHistoricoPagamentoPF ;
      private bool[] BC002E47_A684SerasaRecomendaCompleto ;
      private bool[] BC002E47_n684SerasaRecomendaCompleto ;
      private short[] BC002E47_A685SerasaScore ;
      private bool[] BC002E47_n685SerasaScore ;
      private decimal[] BC002E47_A686SerasaTaxa ;
      private bool[] BC002E47_n686SerasaTaxa ;
      private string[] BC002E47_A687SerasaMensagemScore ;
      private bool[] BC002E47_n687SerasaMensagemScore ;
      private string[] BC002E47_A688SerasaSituacaoCPF ;
      private bool[] BC002E47_n688SerasaSituacaoCPF ;
      private DateTime[] BC002E47_A689SerasaDataNascimento ;
      private bool[] BC002E47_n689SerasaDataNascimento ;
      private string[] BC002E47_A690SerasaGenero ;
      private bool[] BC002E47_n690SerasaGenero ;
      private string[] BC002E47_A691SerasaNomeMae ;
      private bool[] BC002E47_n691SerasaNomeMae ;
      private string[] BC002E47_A692SerasaGrafia ;
      private bool[] BC002E47_n692SerasaGrafia ;
      private string[] BC002E47_A774SerasaJSON ;
      private bool[] BC002E47_n774SerasaJSON ;
      private int[] BC002E47_A168ClienteId ;
      private bool[] BC002E47_n168ClienteId ;
      private short[] BC002E47_A775SerasaCountAcoes_F ;
      private bool[] BC002E47_n775SerasaCountAcoes_F ;
      private short[] BC002E47_A776SerasaCountEnderecos_F ;
      private bool[] BC002E47_n776SerasaCountEnderecos_F ;
      private short[] BC002E47_A777SerasaCountProtestos_F ;
      private bool[] BC002E47_n777SerasaCountProtestos_F ;
      private short[] BC002E47_A778SerasaCountOcorrencias_F ;
      private bool[] BC002E47_n778SerasaCountOcorrencias_F ;
      private short[] BC002E47_A779SerasaCountCheques_F ;
      private bool[] BC002E47_n779SerasaCountCheques_F ;
      private SdtSerasa bcSerasa ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class serasa_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC002E2;
          prmBC002E2 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002E3;
          prmBC002E3 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002E4;
          prmBC002E4 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002E6;
          prmBC002E6 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002E8;
          prmBC002E8 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002E10;
          prmBC002E10 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002E12;
          prmBC002E12 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002E14;
          prmBC002E14 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002E20;
          prmBC002E20 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          string cmdBufferBC002E20;
          cmdBufferBC002E20=" SELECT TM1.SerasaId, TM1.SerasaCreatedAt, T7.ClienteRazaoSocial, TM1.SerasaNumeroProposta, TM1.SerasaPolitica, TM1.SerasaTipoVenda, TM1.SerasaCodTipoVenda, TM1.SerasaCodNivelRisco, TM1.SerasaTipoRecomendacao, TM1.SerasaRecomendacaoVenda, TM1.SerasaCpfRegular, TM1.SerasaRetricaoAtiva, TM1.SerasaProtestoAtivo, TM1.SerasaBaixoComprometimento, TM1.SerasaValorLimiteRecomendado, TM1.SerasaFaixaDeRendaEstimada, TM1.SerasaMensagemRendaEstimada, TM1.SerasaAnotacoesCompletas, TM1.SerasaConsultasDetalhadas, TM1.SerasaAnotacoesConsultaSPC, TM1.SerasaParticipacaoSocietaria, TM1.SerasaRendaEstimada, TM1.SerasaHistoricoPagamentoPF, TM1.SerasaRecomendaCompleto, TM1.SerasaScore, TM1.SerasaTaxa, TM1.SerasaMensagemScore, TM1.SerasaSituacaoCPF, TM1.SerasaDataNascimento, TM1.SerasaGenero, TM1.SerasaNomeMae, TM1.SerasaGrafia, TM1.SerasaJSON, TM1.ClienteId, COALESCE( T2.SerasaCountAcoes_F, 0) AS SerasaCountAcoes_F, COALESCE( T3.SerasaCountEnderecos_F, 0) AS SerasaCountEnderecos_F, COALESCE( T4.SerasaCountProtestos_F, 0) AS SerasaCountProtestos_F, COALESCE( T5.SerasaCountOcorrencias_F, 0) AS SerasaCountOcorrencias_F, COALESCE( T6.SerasaCountCheques_F, 0) AS SerasaCountCheques_F FROM ((((((Serasa TM1 LEFT JOIN LATERAL (SELECT COUNT(*) AS SerasaCountAcoes_F, SerasaId FROM SerasaAcoes WHERE TM1.SerasaId = SerasaId GROUP BY SerasaId ) T2 ON T2.SerasaId = TM1.SerasaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS SerasaCountEnderecos_F, SerasaId FROM SerasaEnderecos WHERE TM1.SerasaId = SerasaId GROUP BY SerasaId ) T3 ON T3.SerasaId = TM1.SerasaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS SerasaCountProtestos_F, SerasaId FROM SerasaProtestos WHERE TM1.SerasaId = SerasaId GROUP BY SerasaId ) T4 ON T4.SerasaId = TM1.SerasaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS SerasaCountOcorrencias_F, SerasaId FROM SerasaOcorrencias "
          + " WHERE TM1.SerasaId = SerasaId GROUP BY SerasaId ) T5 ON T5.SerasaId = TM1.SerasaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS SerasaCountCheques_F, SerasaId FROM SerasaCheques WHERE TM1.SerasaId = SerasaId GROUP BY SerasaId ) T6 ON T6.SerasaId = TM1.SerasaId) LEFT JOIN Cliente T7 ON T7.ClienteId = TM1.ClienteId) WHERE TM1.SerasaId = :SerasaId ORDER BY TM1.SerasaId" ;
          Object[] prmBC002E21;
          prmBC002E21 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002E22;
          prmBC002E22 = new Object[] {
          new ParDef("SerasaCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("SerasaNumeroProposta",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaPolitica",GXType.Number,15,2){Nullable=true} ,
          new ParDef("SerasaTipoVenda",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaCodTipoVenda",GXType.Number,15,2){Nullable=true} ,
          new ParDef("SerasaCodNivelRisco",GXType.Number,15,2){Nullable=true} ,
          new ParDef("SerasaTipoRecomendacao",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaRecomendacaoVenda",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SerasaCpfRegular",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaRetricaoAtiva",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaProtestoAtivo",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaBaixoComprometimento",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaValorLimiteRecomendado",GXType.Number,18,2){Nullable=true} ,
          new ParDef("SerasaFaixaDeRendaEstimada",GXType.Number,15,2){Nullable=true} ,
          new ParDef("SerasaMensagemRendaEstimada",GXType.VarChar,250,0){Nullable=true} ,
          new ParDef("SerasaAnotacoesCompletas",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaConsultasDetalhadas",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaAnotacoesConsultaSPC",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaParticipacaoSocietaria",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaRendaEstimada",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaHistoricoPagamentoPF",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaRecomendaCompleto",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaScore",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("SerasaTaxa",GXType.Number,15,2){Nullable=true} ,
          new ParDef("SerasaMensagemScore",GXType.VarChar,250,0){Nullable=true} ,
          new ParDef("SerasaSituacaoCPF",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaDataNascimento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("SerasaGenero",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaNomeMae",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("SerasaGrafia",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("SerasaJSON",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002E23;
          prmBC002E23 = new Object[] {
          };
          Object[] prmBC002E24;
          prmBC002E24 = new Object[] {
          new ParDef("SerasaCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("SerasaNumeroProposta",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaPolitica",GXType.Number,15,2){Nullable=true} ,
          new ParDef("SerasaTipoVenda",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaCodTipoVenda",GXType.Number,15,2){Nullable=true} ,
          new ParDef("SerasaCodNivelRisco",GXType.Number,15,2){Nullable=true} ,
          new ParDef("SerasaTipoRecomendacao",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaRecomendacaoVenda",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SerasaCpfRegular",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaRetricaoAtiva",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaProtestoAtivo",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaBaixoComprometimento",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaValorLimiteRecomendado",GXType.Number,18,2){Nullable=true} ,
          new ParDef("SerasaFaixaDeRendaEstimada",GXType.Number,15,2){Nullable=true} ,
          new ParDef("SerasaMensagemRendaEstimada",GXType.VarChar,250,0){Nullable=true} ,
          new ParDef("SerasaAnotacoesCompletas",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaConsultasDetalhadas",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaAnotacoesConsultaSPC",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaParticipacaoSocietaria",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaRendaEstimada",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaHistoricoPagamentoPF",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaRecomendaCompleto",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaScore",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("SerasaTaxa",GXType.Number,15,2){Nullable=true} ,
          new ParDef("SerasaMensagemScore",GXType.VarChar,250,0){Nullable=true} ,
          new ParDef("SerasaSituacaoCPF",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaDataNascimento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("SerasaGenero",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaNomeMae",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("SerasaGrafia",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("SerasaJSON",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002E25;
          prmBC002E25 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002E27;
          prmBC002E27 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002E29;
          prmBC002E29 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002E31;
          prmBC002E31 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002E33;
          prmBC002E33 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002E35;
          prmBC002E35 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002E36;
          prmBC002E36 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002E37;
          prmBC002E37 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002E38;
          prmBC002E38 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002E39;
          prmBC002E39 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002E40;
          prmBC002E40 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002E41;
          prmBC002E41 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002E47;
          prmBC002E47 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          string cmdBufferBC002E47;
          cmdBufferBC002E47=" SELECT TM1.SerasaId, TM1.SerasaCreatedAt, T7.ClienteRazaoSocial, TM1.SerasaNumeroProposta, TM1.SerasaPolitica, TM1.SerasaTipoVenda, TM1.SerasaCodTipoVenda, TM1.SerasaCodNivelRisco, TM1.SerasaTipoRecomendacao, TM1.SerasaRecomendacaoVenda, TM1.SerasaCpfRegular, TM1.SerasaRetricaoAtiva, TM1.SerasaProtestoAtivo, TM1.SerasaBaixoComprometimento, TM1.SerasaValorLimiteRecomendado, TM1.SerasaFaixaDeRendaEstimada, TM1.SerasaMensagemRendaEstimada, TM1.SerasaAnotacoesCompletas, TM1.SerasaConsultasDetalhadas, TM1.SerasaAnotacoesConsultaSPC, TM1.SerasaParticipacaoSocietaria, TM1.SerasaRendaEstimada, TM1.SerasaHistoricoPagamentoPF, TM1.SerasaRecomendaCompleto, TM1.SerasaScore, TM1.SerasaTaxa, TM1.SerasaMensagemScore, TM1.SerasaSituacaoCPF, TM1.SerasaDataNascimento, TM1.SerasaGenero, TM1.SerasaNomeMae, TM1.SerasaGrafia, TM1.SerasaJSON, TM1.ClienteId, COALESCE( T2.SerasaCountAcoes_F, 0) AS SerasaCountAcoes_F, COALESCE( T3.SerasaCountEnderecos_F, 0) AS SerasaCountEnderecos_F, COALESCE( T4.SerasaCountProtestos_F, 0) AS SerasaCountProtestos_F, COALESCE( T5.SerasaCountOcorrencias_F, 0) AS SerasaCountOcorrencias_F, COALESCE( T6.SerasaCountCheques_F, 0) AS SerasaCountCheques_F FROM ((((((Serasa TM1 LEFT JOIN LATERAL (SELECT COUNT(*) AS SerasaCountAcoes_F, SerasaId FROM SerasaAcoes WHERE TM1.SerasaId = SerasaId GROUP BY SerasaId ) T2 ON T2.SerasaId = TM1.SerasaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS SerasaCountEnderecos_F, SerasaId FROM SerasaEnderecos WHERE TM1.SerasaId = SerasaId GROUP BY SerasaId ) T3 ON T3.SerasaId = TM1.SerasaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS SerasaCountProtestos_F, SerasaId FROM SerasaProtestos WHERE TM1.SerasaId = SerasaId GROUP BY SerasaId ) T4 ON T4.SerasaId = TM1.SerasaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS SerasaCountOcorrencias_F, SerasaId FROM SerasaOcorrencias "
          + " WHERE TM1.SerasaId = SerasaId GROUP BY SerasaId ) T5 ON T5.SerasaId = TM1.SerasaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS SerasaCountCheques_F, SerasaId FROM SerasaCheques WHERE TM1.SerasaId = SerasaId GROUP BY SerasaId ) T6 ON T6.SerasaId = TM1.SerasaId) LEFT JOIN Cliente T7 ON T7.ClienteId = TM1.ClienteId) WHERE TM1.SerasaId = :SerasaId ORDER BY TM1.SerasaId" ;
          def= new CursorDef[] {
              new CursorDef("BC002E2", "SELECT SerasaId, SerasaCreatedAt, SerasaNumeroProposta, SerasaPolitica, SerasaTipoVenda, SerasaCodTipoVenda, SerasaCodNivelRisco, SerasaTipoRecomendacao, SerasaRecomendacaoVenda, SerasaCpfRegular, SerasaRetricaoAtiva, SerasaProtestoAtivo, SerasaBaixoComprometimento, SerasaValorLimiteRecomendado, SerasaFaixaDeRendaEstimada, SerasaMensagemRendaEstimada, SerasaAnotacoesCompletas, SerasaConsultasDetalhadas, SerasaAnotacoesConsultaSPC, SerasaParticipacaoSocietaria, SerasaRendaEstimada, SerasaHistoricoPagamentoPF, SerasaRecomendaCompleto, SerasaScore, SerasaTaxa, SerasaMensagemScore, SerasaSituacaoCPF, SerasaDataNascimento, SerasaGenero, SerasaNomeMae, SerasaGrafia, SerasaJSON, ClienteId FROM Serasa WHERE SerasaId = :SerasaId  FOR UPDATE OF Serasa",true, GxErrorMask.GX_NOMASK, false, this,prmBC002E2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002E3", "SELECT SerasaId, SerasaCreatedAt, SerasaNumeroProposta, SerasaPolitica, SerasaTipoVenda, SerasaCodTipoVenda, SerasaCodNivelRisco, SerasaTipoRecomendacao, SerasaRecomendacaoVenda, SerasaCpfRegular, SerasaRetricaoAtiva, SerasaProtestoAtivo, SerasaBaixoComprometimento, SerasaValorLimiteRecomendado, SerasaFaixaDeRendaEstimada, SerasaMensagemRendaEstimada, SerasaAnotacoesCompletas, SerasaConsultasDetalhadas, SerasaAnotacoesConsultaSPC, SerasaParticipacaoSocietaria, SerasaRendaEstimada, SerasaHistoricoPagamentoPF, SerasaRecomendaCompleto, SerasaScore, SerasaTaxa, SerasaMensagemScore, SerasaSituacaoCPF, SerasaDataNascimento, SerasaGenero, SerasaNomeMae, SerasaGrafia, SerasaJSON, ClienteId FROM Serasa WHERE SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002E3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002E4", "SELECT ClienteRazaoSocial FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002E4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002E6", "SELECT COALESCE( T1.SerasaCountAcoes_F, 0) AS SerasaCountAcoes_F FROM (SELECT COUNT(*) AS SerasaCountAcoes_F, SerasaId FROM SerasaAcoes GROUP BY SerasaId ) T1 WHERE T1.SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002E6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002E8", "SELECT COALESCE( T1.SerasaCountEnderecos_F, 0) AS SerasaCountEnderecos_F FROM (SELECT COUNT(*) AS SerasaCountEnderecos_F, SerasaId FROM SerasaEnderecos GROUP BY SerasaId ) T1 WHERE T1.SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002E8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002E10", "SELECT COALESCE( T1.SerasaCountProtestos_F, 0) AS SerasaCountProtestos_F FROM (SELECT COUNT(*) AS SerasaCountProtestos_F, SerasaId FROM SerasaProtestos GROUP BY SerasaId ) T1 WHERE T1.SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002E10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002E12", "SELECT COALESCE( T1.SerasaCountOcorrencias_F, 0) AS SerasaCountOcorrencias_F FROM (SELECT COUNT(*) AS SerasaCountOcorrencias_F, SerasaId FROM SerasaOcorrencias GROUP BY SerasaId ) T1 WHERE T1.SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002E12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002E14", "SELECT COALESCE( T1.SerasaCountCheques_F, 0) AS SerasaCountCheques_F FROM (SELECT COUNT(*) AS SerasaCountCheques_F, SerasaId FROM SerasaCheques GROUP BY SerasaId ) T1 WHERE T1.SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002E14,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002E20", cmdBufferBC002E20,true, GxErrorMask.GX_NOMASK, false, this,prmBC002E20,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002E21", "SELECT SerasaId FROM Serasa WHERE SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002E21,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002E22", "SAVEPOINT gxupdate;INSERT INTO Serasa(SerasaCreatedAt, SerasaNumeroProposta, SerasaPolitica, SerasaTipoVenda, SerasaCodTipoVenda, SerasaCodNivelRisco, SerasaTipoRecomendacao, SerasaRecomendacaoVenda, SerasaCpfRegular, SerasaRetricaoAtiva, SerasaProtestoAtivo, SerasaBaixoComprometimento, SerasaValorLimiteRecomendado, SerasaFaixaDeRendaEstimada, SerasaMensagemRendaEstimada, SerasaAnotacoesCompletas, SerasaConsultasDetalhadas, SerasaAnotacoesConsultaSPC, SerasaParticipacaoSocietaria, SerasaRendaEstimada, SerasaHistoricoPagamentoPF, SerasaRecomendaCompleto, SerasaScore, SerasaTaxa, SerasaMensagemScore, SerasaSituacaoCPF, SerasaDataNascimento, SerasaGenero, SerasaNomeMae, SerasaGrafia, SerasaJSON, ClienteId) VALUES(:SerasaCreatedAt, :SerasaNumeroProposta, :SerasaPolitica, :SerasaTipoVenda, :SerasaCodTipoVenda, :SerasaCodNivelRisco, :SerasaTipoRecomendacao, :SerasaRecomendacaoVenda, :SerasaCpfRegular, :SerasaRetricaoAtiva, :SerasaProtestoAtivo, :SerasaBaixoComprometimento, :SerasaValorLimiteRecomendado, :SerasaFaixaDeRendaEstimada, :SerasaMensagemRendaEstimada, :SerasaAnotacoesCompletas, :SerasaConsultasDetalhadas, :SerasaAnotacoesConsultaSPC, :SerasaParticipacaoSocietaria, :SerasaRendaEstimada, :SerasaHistoricoPagamentoPF, :SerasaRecomendaCompleto, :SerasaScore, :SerasaTaxa, :SerasaMensagemScore, :SerasaSituacaoCPF, :SerasaDataNascimento, :SerasaGenero, :SerasaNomeMae, :SerasaGrafia, :SerasaJSON, :ClienteId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC002E22)
             ,new CursorDef("BC002E23", "SELECT currval('SerasaId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002E23,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002E24", "SAVEPOINT gxupdate;UPDATE Serasa SET SerasaCreatedAt=:SerasaCreatedAt, SerasaNumeroProposta=:SerasaNumeroProposta, SerasaPolitica=:SerasaPolitica, SerasaTipoVenda=:SerasaTipoVenda, SerasaCodTipoVenda=:SerasaCodTipoVenda, SerasaCodNivelRisco=:SerasaCodNivelRisco, SerasaTipoRecomendacao=:SerasaTipoRecomendacao, SerasaRecomendacaoVenda=:SerasaRecomendacaoVenda, SerasaCpfRegular=:SerasaCpfRegular, SerasaRetricaoAtiva=:SerasaRetricaoAtiva, SerasaProtestoAtivo=:SerasaProtestoAtivo, SerasaBaixoComprometimento=:SerasaBaixoComprometimento, SerasaValorLimiteRecomendado=:SerasaValorLimiteRecomendado, SerasaFaixaDeRendaEstimada=:SerasaFaixaDeRendaEstimada, SerasaMensagemRendaEstimada=:SerasaMensagemRendaEstimada, SerasaAnotacoesCompletas=:SerasaAnotacoesCompletas, SerasaConsultasDetalhadas=:SerasaConsultasDetalhadas, SerasaAnotacoesConsultaSPC=:SerasaAnotacoesConsultaSPC, SerasaParticipacaoSocietaria=:SerasaParticipacaoSocietaria, SerasaRendaEstimada=:SerasaRendaEstimada, SerasaHistoricoPagamentoPF=:SerasaHistoricoPagamentoPF, SerasaRecomendaCompleto=:SerasaRecomendaCompleto, SerasaScore=:SerasaScore, SerasaTaxa=:SerasaTaxa, SerasaMensagemScore=:SerasaMensagemScore, SerasaSituacaoCPF=:SerasaSituacaoCPF, SerasaDataNascimento=:SerasaDataNascimento, SerasaGenero=:SerasaGenero, SerasaNomeMae=:SerasaNomeMae, SerasaGrafia=:SerasaGrafia, SerasaJSON=:SerasaJSON, ClienteId=:ClienteId  WHERE SerasaId = :SerasaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002E24)
             ,new CursorDef("BC002E25", "SAVEPOINT gxupdate;DELETE FROM Serasa  WHERE SerasaId = :SerasaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002E25)
             ,new CursorDef("BC002E27", "SELECT COALESCE( T1.SerasaCountAcoes_F, 0) AS SerasaCountAcoes_F FROM (SELECT COUNT(*) AS SerasaCountAcoes_F, SerasaId FROM SerasaAcoes GROUP BY SerasaId ) T1 WHERE T1.SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002E27,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002E29", "SELECT COALESCE( T1.SerasaCountEnderecos_F, 0) AS SerasaCountEnderecos_F FROM (SELECT COUNT(*) AS SerasaCountEnderecos_F, SerasaId FROM SerasaEnderecos GROUP BY SerasaId ) T1 WHERE T1.SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002E29,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002E31", "SELECT COALESCE( T1.SerasaCountProtestos_F, 0) AS SerasaCountProtestos_F FROM (SELECT COUNT(*) AS SerasaCountProtestos_F, SerasaId FROM SerasaProtestos GROUP BY SerasaId ) T1 WHERE T1.SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002E31,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002E33", "SELECT COALESCE( T1.SerasaCountOcorrencias_F, 0) AS SerasaCountOcorrencias_F FROM (SELECT COUNT(*) AS SerasaCountOcorrencias_F, SerasaId FROM SerasaOcorrencias GROUP BY SerasaId ) T1 WHERE T1.SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002E33,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002E35", "SELECT COALESCE( T1.SerasaCountCheques_F, 0) AS SerasaCountCheques_F FROM (SELECT COUNT(*) AS SerasaCountCheques_F, SerasaId FROM SerasaCheques GROUP BY SerasaId ) T1 WHERE T1.SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002E35,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002E36", "SELECT ClienteRazaoSocial FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002E36,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002E37", "SELECT SerasaOcorrenciasId FROM SerasaOcorrencias WHERE SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002E37,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002E38", "SELECT SerasaEnderecosId FROM SerasaEnderecos WHERE SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002E38,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002E39", "SELECT SerasaProtestosId FROM SerasaProtestos WHERE SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002E39,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002E40", "SELECT SerasaAcoesId FROM SerasaAcoes WHERE SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002E40,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002E41", "SELECT SerasaChequesId FROM SerasaCheques WHERE SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002E41,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002E47", cmdBufferBC002E47,true, GxErrorMask.GX_NOMASK, false, this,prmBC002E47,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((bool[]) buf[17])[0] = rslt.getBool(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((bool[]) buf[19])[0] = rslt.getBool(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((bool[]) buf[21])[0] = rslt.getBool(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((bool[]) buf[23])[0] = rslt.getBool(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((bool[]) buf[31])[0] = rslt.getBool(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((bool[]) buf[33])[0] = rslt.getBool(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((bool[]) buf[35])[0] = rslt.getBool(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((bool[]) buf[37])[0] = rslt.getBool(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((bool[]) buf[39])[0] = rslt.getBool(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((bool[]) buf[41])[0] = rslt.getBool(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((bool[]) buf[43])[0] = rslt.getBool(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((short[]) buf[45])[0] = rslt.getShort(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((decimal[]) buf[47])[0] = rslt.getDecimal(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((string[]) buf[51])[0] = rslt.getVarchar(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((DateTime[]) buf[53])[0] = rslt.getGXDate(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((string[]) buf[55])[0] = rslt.getVarchar(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((string[]) buf[57])[0] = rslt.getVarchar(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((string[]) buf[59])[0] = rslt.getVarchar(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((string[]) buf[61])[0] = rslt.getLongVarchar(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((int[]) buf[63])[0] = rslt.getInt(33);
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((bool[]) buf[17])[0] = rslt.getBool(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((bool[]) buf[19])[0] = rslt.getBool(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((bool[]) buf[21])[0] = rslt.getBool(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((bool[]) buf[23])[0] = rslt.getBool(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((bool[]) buf[31])[0] = rslt.getBool(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((bool[]) buf[33])[0] = rslt.getBool(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((bool[]) buf[35])[0] = rslt.getBool(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((bool[]) buf[37])[0] = rslt.getBool(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((bool[]) buf[39])[0] = rslt.getBool(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((bool[]) buf[41])[0] = rslt.getBool(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((bool[]) buf[43])[0] = rslt.getBool(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((short[]) buf[45])[0] = rslt.getShort(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((decimal[]) buf[47])[0] = rslt.getDecimal(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((string[]) buf[51])[0] = rslt.getVarchar(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((DateTime[]) buf[53])[0] = rslt.getGXDate(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((string[]) buf[55])[0] = rslt.getVarchar(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((string[]) buf[57])[0] = rslt.getVarchar(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((string[]) buf[59])[0] = rslt.getVarchar(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((string[]) buf[61])[0] = rslt.getLongVarchar(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((int[]) buf[63])[0] = rslt.getInt(33);
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
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
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((bool[]) buf[19])[0] = rslt.getBool(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((bool[]) buf[21])[0] = rslt.getBool(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((bool[]) buf[23])[0] = rslt.getBool(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((bool[]) buf[25])[0] = rslt.getBool(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((decimal[]) buf[29])[0] = rslt.getDecimal(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((bool[]) buf[33])[0] = rslt.getBool(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((bool[]) buf[35])[0] = rslt.getBool(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((bool[]) buf[37])[0] = rslt.getBool(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((bool[]) buf[39])[0] = rslt.getBool(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((bool[]) buf[41])[0] = rslt.getBool(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((bool[]) buf[43])[0] = rslt.getBool(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((bool[]) buf[45])[0] = rslt.getBool(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((short[]) buf[47])[0] = rslt.getShort(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((decimal[]) buf[49])[0] = rslt.getDecimal(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((string[]) buf[51])[0] = rslt.getVarchar(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((string[]) buf[53])[0] = rslt.getVarchar(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((DateTime[]) buf[55])[0] = rslt.getGXDate(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((string[]) buf[57])[0] = rslt.getVarchar(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((string[]) buf[59])[0] = rslt.getVarchar(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((string[]) buf[61])[0] = rslt.getVarchar(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((string[]) buf[63])[0] = rslt.getLongVarchar(33);
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                ((int[]) buf[65])[0] = rslt.getInt(34);
                ((bool[]) buf[66])[0] = rslt.wasNull(34);
                ((short[]) buf[67])[0] = rslt.getShort(35);
                ((bool[]) buf[68])[0] = rslt.wasNull(35);
                ((short[]) buf[69])[0] = rslt.getShort(36);
                ((bool[]) buf[70])[0] = rslt.wasNull(36);
                ((short[]) buf[71])[0] = rslt.getShort(37);
                ((bool[]) buf[72])[0] = rslt.wasNull(37);
                ((short[]) buf[73])[0] = rslt.getShort(38);
                ((bool[]) buf[74])[0] = rslt.wasNull(38);
                ((short[]) buf[75])[0] = rslt.getShort(39);
                ((bool[]) buf[76])[0] = rslt.wasNull(39);
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 17 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
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
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((bool[]) buf[19])[0] = rslt.getBool(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((bool[]) buf[21])[0] = rslt.getBool(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((bool[]) buf[23])[0] = rslt.getBool(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((bool[]) buf[25])[0] = rslt.getBool(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((decimal[]) buf[29])[0] = rslt.getDecimal(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((bool[]) buf[33])[0] = rslt.getBool(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((bool[]) buf[35])[0] = rslt.getBool(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((bool[]) buf[37])[0] = rslt.getBool(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((bool[]) buf[39])[0] = rslt.getBool(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((bool[]) buf[41])[0] = rslt.getBool(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((bool[]) buf[43])[0] = rslt.getBool(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((bool[]) buf[45])[0] = rslt.getBool(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((short[]) buf[47])[0] = rslt.getShort(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((decimal[]) buf[49])[0] = rslt.getDecimal(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((string[]) buf[51])[0] = rslt.getVarchar(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((string[]) buf[53])[0] = rslt.getVarchar(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((DateTime[]) buf[55])[0] = rslt.getGXDate(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((string[]) buf[57])[0] = rslt.getVarchar(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((string[]) buf[59])[0] = rslt.getVarchar(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((string[]) buf[61])[0] = rslt.getVarchar(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((string[]) buf[63])[0] = rslt.getLongVarchar(33);
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                ((int[]) buf[65])[0] = rslt.getInt(34);
                ((bool[]) buf[66])[0] = rslt.wasNull(34);
                ((short[]) buf[67])[0] = rslt.getShort(35);
                ((bool[]) buf[68])[0] = rslt.wasNull(35);
                ((short[]) buf[69])[0] = rslt.getShort(36);
                ((bool[]) buf[70])[0] = rslt.wasNull(36);
                ((short[]) buf[71])[0] = rslt.getShort(37);
                ((bool[]) buf[72])[0] = rslt.wasNull(37);
                ((short[]) buf[73])[0] = rslt.getShort(38);
                ((bool[]) buf[74])[0] = rslt.wasNull(38);
                ((short[]) buf[75])[0] = rslt.getShort(39);
                ((bool[]) buf[76])[0] = rslt.wasNull(39);
                return;
       }
    }

 }

}
