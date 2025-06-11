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
   public class configuracoes_bc : GxSilentTrn, IGxSilentTrn
   {
      public configuracoes_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public configuracoes_bc( IGxContext context )
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
         ReadRow1948( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1948( ) ;
         standaloneModal( ) ;
         AddRow1948( ) ;
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
               Z299ConfiguracoesId = A299ConfiguracoesId;
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

      protected void CONFIRM_190( )
      {
         BeforeValidate1948( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1948( ) ;
            }
            else
            {
               CheckExtendedTable1948( ) ;
               if ( AnyError == 0 )
               {
                  ZM1948( 4) ;
                  ZM1948( 5) ;
                  ZM1948( 6) ;
                  ZM1948( 7) ;
                  ZM1948( 8) ;
                  ZM1948( 9) ;
               }
               CloseExtendedTableCursors1948( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM1948( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z315ConfiguracoesImagemLoginNomeInteiro = A315ConfiguracoesImagemLoginNomeInteiro;
            Z316ConfiguracoesImagemLoginTamanho = A316ConfiguracoesImagemLoginTamanho;
            Z317ConfiguracoesImagemLoginBackground = A317ConfiguracoesImagemLoginBackground;
            Z319ConfiguracoesImagemHeaderNome = A319ConfiguracoesImagemHeaderNome;
            Z320ConfiguracoesImagemHeaderExtencao = A320ConfiguracoesImagemHeaderExtencao;
            Z321ConfiguracoesImagemHeaderNomeInteiro = A321ConfiguracoesImagemHeaderNomeInteiro;
            Z322ConfiguracoesImagemHeaderTamanho = A322ConfiguracoesImagemHeaderTamanho;
            Z563ConfiguracaoSenhaPFX = A563ConfiguracaoSenhaPFX;
            Z765ConfiguracoesSerasaAnotacoesCompletas = A765ConfiguracoesSerasaAnotacoesCompletas;
            Z766ConfiguracoesSerasaConsultaDetalhada = A766ConfiguracoesSerasaConsultaDetalhada;
            Z767ConfiguracoesSerasaParticipacaoSocietaria = A767ConfiguracoesSerasaParticipacaoSocietaria;
            Z768ConfiguracoesSerasaRendaEstimada = A768ConfiguracoesSerasaRendaEstimada;
            Z769ConfiguracoesSerasaHistoricoPagamento = A769ConfiguracoesSerasaHistoricoPagamento;
            Z1013ConfiguracoesCompraTituloTaxaEfetiva = A1013ConfiguracoesCompraTituloTaxaEfetiva;
            Z1014ConfiguracoesCompraTituloTaxaMora = A1014ConfiguracoesCompraTituloTaxaMora;
            Z1036ConfiguracoesCompraTituloFator = A1036ConfiguracoesCompraTituloFator;
            Z1037ConfiguracoesCompraTituloTarifaTipo = A1037ConfiguracoesCompraTituloTarifaTipo;
            Z1038ConfiguracoesCompraTituloTarifa = A1038ConfiguracoesCompraTituloTarifa;
            Z398ConfiguracoesLayoutProposta = A398ConfiguracoesLayoutProposta;
            Z564ConfigLayoutPromissoriaClinicaEmprestimo = A564ConfigLayoutPromissoriaClinicaEmprestimo;
            Z565ConfigLayoutPromissoriaClinicaTaxa = A565ConfigLayoutPromissoriaClinicaTaxa;
            Z566ConfigLayoutPromissoriaPaciente = A566ConfigLayoutPromissoriaPaciente;
            Z922ConfigLayoutContratoCompraTitulo = A922ConfigLayoutContratoCompraTitulo;
            Z654ConfiguracoesCategoriaTitulo = A654ConfiguracoesCategoriaTitulo;
         }
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -3 )
         {
            Z299ConfiguracoesId = A299ConfiguracoesId;
            Z300ConfiguracoesImagemLogin = A300ConfiguracoesImagemLogin;
            Z315ConfiguracoesImagemLoginNomeInteiro = A315ConfiguracoesImagemLoginNomeInteiro;
            Z316ConfiguracoesImagemLoginTamanho = A316ConfiguracoesImagemLoginTamanho;
            Z317ConfiguracoesImagemLoginBackground = A317ConfiguracoesImagemLoginBackground;
            Z318ConfiguracoesImagemHeader = A318ConfiguracoesImagemHeader;
            Z319ConfiguracoesImagemHeaderNome = A319ConfiguracoesImagemHeaderNome;
            Z320ConfiguracoesImagemHeaderExtencao = A320ConfiguracoesImagemHeaderExtencao;
            Z321ConfiguracoesImagemHeaderNomeInteiro = A321ConfiguracoesImagemHeaderNomeInteiro;
            Z322ConfiguracoesImagemHeaderTamanho = A322ConfiguracoesImagemHeaderTamanho;
            Z562ConfiguracoesArquivoPFX = A562ConfiguracoesArquivoPFX;
            Z563ConfiguracaoSenhaPFX = A563ConfiguracaoSenhaPFX;
            Z765ConfiguracoesSerasaAnotacoesCompletas = A765ConfiguracoesSerasaAnotacoesCompletas;
            Z766ConfiguracoesSerasaConsultaDetalhada = A766ConfiguracoesSerasaConsultaDetalhada;
            Z767ConfiguracoesSerasaParticipacaoSocietaria = A767ConfiguracoesSerasaParticipacaoSocietaria;
            Z768ConfiguracoesSerasaRendaEstimada = A768ConfiguracoesSerasaRendaEstimada;
            Z769ConfiguracoesSerasaHistoricoPagamento = A769ConfiguracoesSerasaHistoricoPagamento;
            Z1013ConfiguracoesCompraTituloTaxaEfetiva = A1013ConfiguracoesCompraTituloTaxaEfetiva;
            Z1014ConfiguracoesCompraTituloTaxaMora = A1014ConfiguracoesCompraTituloTaxaMora;
            Z1036ConfiguracoesCompraTituloFator = A1036ConfiguracoesCompraTituloFator;
            Z1037ConfiguracoesCompraTituloTarifaTipo = A1037ConfiguracoesCompraTituloTarifaTipo;
            Z1038ConfiguracoesCompraTituloTarifa = A1038ConfiguracoesCompraTituloTarifa;
            Z312ConfiguracoesImagemLoginExtencao = A312ConfiguracoesImagemLoginExtencao;
            Z313ConfiguracoesImagemLoginNome = A313ConfiguracoesImagemLoginNome;
            Z398ConfiguracoesLayoutProposta = A398ConfiguracoesLayoutProposta;
            Z564ConfigLayoutPromissoriaClinicaEmprestimo = A564ConfigLayoutPromissoriaClinicaEmprestimo;
            Z565ConfigLayoutPromissoriaClinicaTaxa = A565ConfigLayoutPromissoriaClinicaTaxa;
            Z566ConfigLayoutPromissoriaPaciente = A566ConfigLayoutPromissoriaPaciente;
            Z922ConfigLayoutContratoCompraTitulo = A922ConfigLayoutContratoCompraTitulo;
            Z654ConfiguracoesCategoriaTitulo = A654ConfiguracoesCategoriaTitulo;
            Z418ConfiguracoesLayoutContratoCorpo = A418ConfiguracoesLayoutContratoCorpo;
            Z567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo;
            Z568ConfigLayoutCorpoPromissoriaClinicaTaxa = A568ConfigLayoutCorpoPromissoriaClinicaTaxa;
            Z569ConfigLayoutCorpoPromissoriaPaciente = A569ConfigLayoutCorpoPromissoriaPaciente;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load1948( )
      {
         /* Using cursor BC001910 */
         pr_default.execute(8, new Object[] {A299ConfiguracoesId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound48 = 1;
            A315ConfiguracoesImagemLoginNomeInteiro = BC001910_A315ConfiguracoesImagemLoginNomeInteiro[0];
            n315ConfiguracoesImagemLoginNomeInteiro = BC001910_n315ConfiguracoesImagemLoginNomeInteiro[0];
            A316ConfiguracoesImagemLoginTamanho = BC001910_A316ConfiguracoesImagemLoginTamanho[0];
            n316ConfiguracoesImagemLoginTamanho = BC001910_n316ConfiguracoesImagemLoginTamanho[0];
            A317ConfiguracoesImagemLoginBackground = BC001910_A317ConfiguracoesImagemLoginBackground[0];
            n317ConfiguracoesImagemLoginBackground = BC001910_n317ConfiguracoesImagemLoginBackground[0];
            A319ConfiguracoesImagemHeaderNome = BC001910_A319ConfiguracoesImagemHeaderNome[0];
            n319ConfiguracoesImagemHeaderNome = BC001910_n319ConfiguracoesImagemHeaderNome[0];
            A320ConfiguracoesImagemHeaderExtencao = BC001910_A320ConfiguracoesImagemHeaderExtencao[0];
            n320ConfiguracoesImagemHeaderExtencao = BC001910_n320ConfiguracoesImagemHeaderExtencao[0];
            A321ConfiguracoesImagemHeaderNomeInteiro = BC001910_A321ConfiguracoesImagemHeaderNomeInteiro[0];
            n321ConfiguracoesImagemHeaderNomeInteiro = BC001910_n321ConfiguracoesImagemHeaderNomeInteiro[0];
            A322ConfiguracoesImagemHeaderTamanho = BC001910_A322ConfiguracoesImagemHeaderTamanho[0];
            n322ConfiguracoesImagemHeaderTamanho = BC001910_n322ConfiguracoesImagemHeaderTamanho[0];
            A418ConfiguracoesLayoutContratoCorpo = BC001910_A418ConfiguracoesLayoutContratoCorpo[0];
            n418ConfiguracoesLayoutContratoCorpo = BC001910_n418ConfiguracoesLayoutContratoCorpo[0];
            A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = BC001910_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo[0];
            n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = BC001910_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo[0];
            A568ConfigLayoutCorpoPromissoriaClinicaTaxa = BC001910_A568ConfigLayoutCorpoPromissoriaClinicaTaxa[0];
            n568ConfigLayoutCorpoPromissoriaClinicaTaxa = BC001910_n568ConfigLayoutCorpoPromissoriaClinicaTaxa[0];
            A569ConfigLayoutCorpoPromissoriaPaciente = BC001910_A569ConfigLayoutCorpoPromissoriaPaciente[0];
            n569ConfigLayoutCorpoPromissoriaPaciente = BC001910_n569ConfigLayoutCorpoPromissoriaPaciente[0];
            A563ConfiguracaoSenhaPFX = BC001910_A563ConfiguracaoSenhaPFX[0];
            n563ConfiguracaoSenhaPFX = BC001910_n563ConfiguracaoSenhaPFX[0];
            A765ConfiguracoesSerasaAnotacoesCompletas = BC001910_A765ConfiguracoesSerasaAnotacoesCompletas[0];
            n765ConfiguracoesSerasaAnotacoesCompletas = BC001910_n765ConfiguracoesSerasaAnotacoesCompletas[0];
            A766ConfiguracoesSerasaConsultaDetalhada = BC001910_A766ConfiguracoesSerasaConsultaDetalhada[0];
            n766ConfiguracoesSerasaConsultaDetalhada = BC001910_n766ConfiguracoesSerasaConsultaDetalhada[0];
            A767ConfiguracoesSerasaParticipacaoSocietaria = BC001910_A767ConfiguracoesSerasaParticipacaoSocietaria[0];
            n767ConfiguracoesSerasaParticipacaoSocietaria = BC001910_n767ConfiguracoesSerasaParticipacaoSocietaria[0];
            A768ConfiguracoesSerasaRendaEstimada = BC001910_A768ConfiguracoesSerasaRendaEstimada[0];
            n768ConfiguracoesSerasaRendaEstimada = BC001910_n768ConfiguracoesSerasaRendaEstimada[0];
            A769ConfiguracoesSerasaHistoricoPagamento = BC001910_A769ConfiguracoesSerasaHistoricoPagamento[0];
            n769ConfiguracoesSerasaHistoricoPagamento = BC001910_n769ConfiguracoesSerasaHistoricoPagamento[0];
            A1013ConfiguracoesCompraTituloTaxaEfetiva = BC001910_A1013ConfiguracoesCompraTituloTaxaEfetiva[0];
            n1013ConfiguracoesCompraTituloTaxaEfetiva = BC001910_n1013ConfiguracoesCompraTituloTaxaEfetiva[0];
            A1014ConfiguracoesCompraTituloTaxaMora = BC001910_A1014ConfiguracoesCompraTituloTaxaMora[0];
            n1014ConfiguracoesCompraTituloTaxaMora = BC001910_n1014ConfiguracoesCompraTituloTaxaMora[0];
            A1036ConfiguracoesCompraTituloFator = BC001910_A1036ConfiguracoesCompraTituloFator[0];
            n1036ConfiguracoesCompraTituloFator = BC001910_n1036ConfiguracoesCompraTituloFator[0];
            A1037ConfiguracoesCompraTituloTarifaTipo = BC001910_A1037ConfiguracoesCompraTituloTarifaTipo[0];
            n1037ConfiguracoesCompraTituloTarifaTipo = BC001910_n1037ConfiguracoesCompraTituloTarifaTipo[0];
            A1038ConfiguracoesCompraTituloTarifa = BC001910_A1038ConfiguracoesCompraTituloTarifa[0];
            n1038ConfiguracoesCompraTituloTarifa = BC001910_n1038ConfiguracoesCompraTituloTarifa[0];
            A312ConfiguracoesImagemLoginExtencao = BC001910_A312ConfiguracoesImagemLoginExtencao[0];
            n312ConfiguracoesImagemLoginExtencao = BC001910_n312ConfiguracoesImagemLoginExtencao[0];
            A300ConfiguracoesImagemLogin_Filetype = A312ConfiguracoesImagemLoginExtencao;
            A313ConfiguracoesImagemLoginNome = BC001910_A313ConfiguracoesImagemLoginNome[0];
            n313ConfiguracoesImagemLoginNome = BC001910_n313ConfiguracoesImagemLoginNome[0];
            A300ConfiguracoesImagemLogin_Filename = A313ConfiguracoesImagemLoginNome;
            A398ConfiguracoesLayoutProposta = BC001910_A398ConfiguracoesLayoutProposta[0];
            n398ConfiguracoesLayoutProposta = BC001910_n398ConfiguracoesLayoutProposta[0];
            A564ConfigLayoutPromissoriaClinicaEmprestimo = BC001910_A564ConfigLayoutPromissoriaClinicaEmprestimo[0];
            n564ConfigLayoutPromissoriaClinicaEmprestimo = BC001910_n564ConfigLayoutPromissoriaClinicaEmprestimo[0];
            A565ConfigLayoutPromissoriaClinicaTaxa = BC001910_A565ConfigLayoutPromissoriaClinicaTaxa[0];
            n565ConfigLayoutPromissoriaClinicaTaxa = BC001910_n565ConfigLayoutPromissoriaClinicaTaxa[0];
            A566ConfigLayoutPromissoriaPaciente = BC001910_A566ConfigLayoutPromissoriaPaciente[0];
            n566ConfigLayoutPromissoriaPaciente = BC001910_n566ConfigLayoutPromissoriaPaciente[0];
            A922ConfigLayoutContratoCompraTitulo = BC001910_A922ConfigLayoutContratoCompraTitulo[0];
            n922ConfigLayoutContratoCompraTitulo = BC001910_n922ConfigLayoutContratoCompraTitulo[0];
            A654ConfiguracoesCategoriaTitulo = BC001910_A654ConfiguracoesCategoriaTitulo[0];
            n654ConfiguracoesCategoriaTitulo = BC001910_n654ConfiguracoesCategoriaTitulo[0];
            A300ConfiguracoesImagemLogin = BC001910_A300ConfiguracoesImagemLogin[0];
            n300ConfiguracoesImagemLogin = BC001910_n300ConfiguracoesImagemLogin[0];
            A318ConfiguracoesImagemHeader = BC001910_A318ConfiguracoesImagemHeader[0];
            n318ConfiguracoesImagemHeader = BC001910_n318ConfiguracoesImagemHeader[0];
            A562ConfiguracoesArquivoPFX = BC001910_A562ConfiguracoesArquivoPFX[0];
            n562ConfiguracoesArquivoPFX = BC001910_n562ConfiguracoesArquivoPFX[0];
            ZM1948( -3) ;
         }
         pr_default.close(8);
         OnLoadActions1948( ) ;
      }

      protected void OnLoadActions1948( )
      {
         if ( (0==A398ConfiguracoesLayoutProposta) )
         {
            A398ConfiguracoesLayoutProposta = 0;
            n398ConfiguracoesLayoutProposta = false;
            n398ConfiguracoesLayoutProposta = true;
            n398ConfiguracoesLayoutProposta = true;
         }
         if ( (0==A922ConfigLayoutContratoCompraTitulo) )
         {
            A922ConfigLayoutContratoCompraTitulo = 0;
            n922ConfigLayoutContratoCompraTitulo = false;
            n922ConfigLayoutContratoCompraTitulo = true;
            n922ConfigLayoutContratoCompraTitulo = true;
         }
      }

      protected void CheckExtendedTable1948( )
      {
         standaloneModal( ) ;
         if ( (0==A398ConfiguracoesLayoutProposta) )
         {
            A398ConfiguracoesLayoutProposta = 0;
            n398ConfiguracoesLayoutProposta = false;
            n398ConfiguracoesLayoutProposta = true;
            n398ConfiguracoesLayoutProposta = true;
         }
         /* Using cursor BC00194 */
         pr_default.execute(2, new Object[] {n398ConfiguracoesLayoutProposta, A398ConfiguracoesLayoutProposta});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A398ConfiguracoesLayoutProposta) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Layout Proposta Config'.", "ForeignKeyNotFound", 1, "CONFIGURACOESLAYOUTPROPOSTA");
               AnyError = 1;
            }
         }
         A418ConfiguracoesLayoutContratoCorpo = BC00194_A418ConfiguracoesLayoutContratoCorpo[0];
         n418ConfiguracoesLayoutContratoCorpo = BC00194_n418ConfiguracoesLayoutContratoCorpo[0];
         pr_default.close(2);
         /* Using cursor BC00195 */
         pr_default.execute(3, new Object[] {n564ConfigLayoutPromissoriaClinicaEmprestimo, A564ConfigLayoutPromissoriaClinicaEmprestimo});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A564ConfigLayoutPromissoriaClinicaEmprestimo) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Layout Promissoria Clinica Emprestimo'.", "ForeignKeyNotFound", 1, "CONFIGLAYOUTPROMISSORIACLINICAEMPRESTIMO");
               AnyError = 1;
            }
         }
         A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = BC00195_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo[0];
         n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = BC00195_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo[0];
         pr_default.close(3);
         /* Using cursor BC00196 */
         pr_default.execute(4, new Object[] {n565ConfigLayoutPromissoriaClinicaTaxa, A565ConfigLayoutPromissoriaClinicaTaxa});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A565ConfigLayoutPromissoriaClinicaTaxa) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Layout Promissoria Clinica Taxa'.", "ForeignKeyNotFound", 1, "CONFIGLAYOUTPROMISSORIACLINICATAXA");
               AnyError = 1;
            }
         }
         A568ConfigLayoutCorpoPromissoriaClinicaTaxa = BC00196_A568ConfigLayoutCorpoPromissoriaClinicaTaxa[0];
         n568ConfigLayoutCorpoPromissoriaClinicaTaxa = BC00196_n568ConfigLayoutCorpoPromissoriaClinicaTaxa[0];
         pr_default.close(4);
         /* Using cursor BC00197 */
         pr_default.execute(5, new Object[] {n566ConfigLayoutPromissoriaPaciente, A566ConfigLayoutPromissoriaPaciente});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A566ConfigLayoutPromissoriaPaciente) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Layout Promissoria Paciente'.", "ForeignKeyNotFound", 1, "CONFIGLAYOUTPROMISSORIAPACIENTE");
               AnyError = 1;
            }
         }
         A569ConfigLayoutCorpoPromissoriaPaciente = BC00197_A569ConfigLayoutCorpoPromissoriaPaciente[0];
         n569ConfigLayoutCorpoPromissoriaPaciente = BC00197_n569ConfigLayoutCorpoPromissoriaPaciente[0];
         pr_default.close(5);
         if ( (0==A922ConfigLayoutContratoCompraTitulo) )
         {
            A922ConfigLayoutContratoCompraTitulo = 0;
            n922ConfigLayoutContratoCompraTitulo = false;
            n922ConfigLayoutContratoCompraTitulo = true;
            n922ConfigLayoutContratoCompraTitulo = true;
         }
         /* Using cursor BC00198 */
         pr_default.execute(6, new Object[] {n922ConfigLayoutContratoCompraTitulo, A922ConfigLayoutContratoCompraTitulo});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A922ConfigLayoutContratoCompraTitulo) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Config Layout Contrato Compra Titulo'.", "ForeignKeyNotFound", 1, "CONFIGLAYOUTCONTRATOCOMPRATITULO");
               AnyError = 1;
            }
         }
         pr_default.close(6);
         /* Using cursor BC00199 */
         pr_default.execute(7, new Object[] {n654ConfiguracoesCategoriaTitulo, A654ConfiguracoesCategoriaTitulo});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A654ConfiguracoesCategoriaTitulo) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Categoria Titulo Confg'.", "ForeignKeyNotFound", 1, "CONFIGURACOESCATEGORIATITULO");
               AnyError = 1;
            }
         }
         pr_default.close(7);
      }

      protected void CloseExtendedTableCursors1948( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(6);
         pr_default.close(7);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1948( )
      {
         /* Using cursor BC001911 */
         pr_default.execute(9, new Object[] {A299ConfiguracoesId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound48 = 1;
         }
         else
         {
            RcdFound48 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00193 */
         pr_default.execute(1, new Object[] {A299ConfiguracoesId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1948( 3) ;
            RcdFound48 = 1;
            A299ConfiguracoesId = BC00193_A299ConfiguracoesId[0];
            A315ConfiguracoesImagemLoginNomeInteiro = BC00193_A315ConfiguracoesImagemLoginNomeInteiro[0];
            n315ConfiguracoesImagemLoginNomeInteiro = BC00193_n315ConfiguracoesImagemLoginNomeInteiro[0];
            A316ConfiguracoesImagemLoginTamanho = BC00193_A316ConfiguracoesImagemLoginTamanho[0];
            n316ConfiguracoesImagemLoginTamanho = BC00193_n316ConfiguracoesImagemLoginTamanho[0];
            A317ConfiguracoesImagemLoginBackground = BC00193_A317ConfiguracoesImagemLoginBackground[0];
            n317ConfiguracoesImagemLoginBackground = BC00193_n317ConfiguracoesImagemLoginBackground[0];
            A319ConfiguracoesImagemHeaderNome = BC00193_A319ConfiguracoesImagemHeaderNome[0];
            n319ConfiguracoesImagemHeaderNome = BC00193_n319ConfiguracoesImagemHeaderNome[0];
            A320ConfiguracoesImagemHeaderExtencao = BC00193_A320ConfiguracoesImagemHeaderExtencao[0];
            n320ConfiguracoesImagemHeaderExtencao = BC00193_n320ConfiguracoesImagemHeaderExtencao[0];
            A321ConfiguracoesImagemHeaderNomeInteiro = BC00193_A321ConfiguracoesImagemHeaderNomeInteiro[0];
            n321ConfiguracoesImagemHeaderNomeInteiro = BC00193_n321ConfiguracoesImagemHeaderNomeInteiro[0];
            A322ConfiguracoesImagemHeaderTamanho = BC00193_A322ConfiguracoesImagemHeaderTamanho[0];
            n322ConfiguracoesImagemHeaderTamanho = BC00193_n322ConfiguracoesImagemHeaderTamanho[0];
            A563ConfiguracaoSenhaPFX = BC00193_A563ConfiguracaoSenhaPFX[0];
            n563ConfiguracaoSenhaPFX = BC00193_n563ConfiguracaoSenhaPFX[0];
            A765ConfiguracoesSerasaAnotacoesCompletas = BC00193_A765ConfiguracoesSerasaAnotacoesCompletas[0];
            n765ConfiguracoesSerasaAnotacoesCompletas = BC00193_n765ConfiguracoesSerasaAnotacoesCompletas[0];
            A766ConfiguracoesSerasaConsultaDetalhada = BC00193_A766ConfiguracoesSerasaConsultaDetalhada[0];
            n766ConfiguracoesSerasaConsultaDetalhada = BC00193_n766ConfiguracoesSerasaConsultaDetalhada[0];
            A767ConfiguracoesSerasaParticipacaoSocietaria = BC00193_A767ConfiguracoesSerasaParticipacaoSocietaria[0];
            n767ConfiguracoesSerasaParticipacaoSocietaria = BC00193_n767ConfiguracoesSerasaParticipacaoSocietaria[0];
            A768ConfiguracoesSerasaRendaEstimada = BC00193_A768ConfiguracoesSerasaRendaEstimada[0];
            n768ConfiguracoesSerasaRendaEstimada = BC00193_n768ConfiguracoesSerasaRendaEstimada[0];
            A769ConfiguracoesSerasaHistoricoPagamento = BC00193_A769ConfiguracoesSerasaHistoricoPagamento[0];
            n769ConfiguracoesSerasaHistoricoPagamento = BC00193_n769ConfiguracoesSerasaHistoricoPagamento[0];
            A1013ConfiguracoesCompraTituloTaxaEfetiva = BC00193_A1013ConfiguracoesCompraTituloTaxaEfetiva[0];
            n1013ConfiguracoesCompraTituloTaxaEfetiva = BC00193_n1013ConfiguracoesCompraTituloTaxaEfetiva[0];
            A1014ConfiguracoesCompraTituloTaxaMora = BC00193_A1014ConfiguracoesCompraTituloTaxaMora[0];
            n1014ConfiguracoesCompraTituloTaxaMora = BC00193_n1014ConfiguracoesCompraTituloTaxaMora[0];
            A1036ConfiguracoesCompraTituloFator = BC00193_A1036ConfiguracoesCompraTituloFator[0];
            n1036ConfiguracoesCompraTituloFator = BC00193_n1036ConfiguracoesCompraTituloFator[0];
            A1037ConfiguracoesCompraTituloTarifaTipo = BC00193_A1037ConfiguracoesCompraTituloTarifaTipo[0];
            n1037ConfiguracoesCompraTituloTarifaTipo = BC00193_n1037ConfiguracoesCompraTituloTarifaTipo[0];
            A1038ConfiguracoesCompraTituloTarifa = BC00193_A1038ConfiguracoesCompraTituloTarifa[0];
            n1038ConfiguracoesCompraTituloTarifa = BC00193_n1038ConfiguracoesCompraTituloTarifa[0];
            A312ConfiguracoesImagemLoginExtencao = BC00193_A312ConfiguracoesImagemLoginExtencao[0];
            n312ConfiguracoesImagemLoginExtencao = BC00193_n312ConfiguracoesImagemLoginExtencao[0];
            A300ConfiguracoesImagemLogin_Filetype = A312ConfiguracoesImagemLoginExtencao;
            A313ConfiguracoesImagemLoginNome = BC00193_A313ConfiguracoesImagemLoginNome[0];
            n313ConfiguracoesImagemLoginNome = BC00193_n313ConfiguracoesImagemLoginNome[0];
            A300ConfiguracoesImagemLogin_Filename = A313ConfiguracoesImagemLoginNome;
            A398ConfiguracoesLayoutProposta = BC00193_A398ConfiguracoesLayoutProposta[0];
            n398ConfiguracoesLayoutProposta = BC00193_n398ConfiguracoesLayoutProposta[0];
            A564ConfigLayoutPromissoriaClinicaEmprestimo = BC00193_A564ConfigLayoutPromissoriaClinicaEmprestimo[0];
            n564ConfigLayoutPromissoriaClinicaEmprestimo = BC00193_n564ConfigLayoutPromissoriaClinicaEmprestimo[0];
            A565ConfigLayoutPromissoriaClinicaTaxa = BC00193_A565ConfigLayoutPromissoriaClinicaTaxa[0];
            n565ConfigLayoutPromissoriaClinicaTaxa = BC00193_n565ConfigLayoutPromissoriaClinicaTaxa[0];
            A566ConfigLayoutPromissoriaPaciente = BC00193_A566ConfigLayoutPromissoriaPaciente[0];
            n566ConfigLayoutPromissoriaPaciente = BC00193_n566ConfigLayoutPromissoriaPaciente[0];
            A922ConfigLayoutContratoCompraTitulo = BC00193_A922ConfigLayoutContratoCompraTitulo[0];
            n922ConfigLayoutContratoCompraTitulo = BC00193_n922ConfigLayoutContratoCompraTitulo[0];
            A654ConfiguracoesCategoriaTitulo = BC00193_A654ConfiguracoesCategoriaTitulo[0];
            n654ConfiguracoesCategoriaTitulo = BC00193_n654ConfiguracoesCategoriaTitulo[0];
            A300ConfiguracoesImagemLogin = BC00193_A300ConfiguracoesImagemLogin[0];
            n300ConfiguracoesImagemLogin = BC00193_n300ConfiguracoesImagemLogin[0];
            A318ConfiguracoesImagemHeader = BC00193_A318ConfiguracoesImagemHeader[0];
            n318ConfiguracoesImagemHeader = BC00193_n318ConfiguracoesImagemHeader[0];
            A562ConfiguracoesArquivoPFX = BC00193_A562ConfiguracoesArquivoPFX[0];
            n562ConfiguracoesArquivoPFX = BC00193_n562ConfiguracoesArquivoPFX[0];
            Z299ConfiguracoesId = A299ConfiguracoesId;
            sMode48 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1948( ) ;
            if ( AnyError == 1 )
            {
               RcdFound48 = 0;
               InitializeNonKey1948( ) ;
            }
            Gx_mode = sMode48;
         }
         else
         {
            RcdFound48 = 0;
            InitializeNonKey1948( ) ;
            sMode48 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode48;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1948( ) ;
         if ( RcdFound48 == 0 )
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
         CONFIRM_190( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1948( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00192 */
            pr_default.execute(0, new Object[] {A299ConfiguracoesId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Configuracoes"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z315ConfiguracoesImagemLoginNomeInteiro, BC00192_A315ConfiguracoesImagemLoginNomeInteiro[0]) != 0 ) || ( Z316ConfiguracoesImagemLoginTamanho != BC00192_A316ConfiguracoesImagemLoginTamanho[0] ) || ( StringUtil.StrCmp(Z317ConfiguracoesImagemLoginBackground, BC00192_A317ConfiguracoesImagemLoginBackground[0]) != 0 ) || ( StringUtil.StrCmp(Z319ConfiguracoesImagemHeaderNome, BC00192_A319ConfiguracoesImagemHeaderNome[0]) != 0 ) || ( StringUtil.StrCmp(Z320ConfiguracoesImagemHeaderExtencao, BC00192_A320ConfiguracoesImagemHeaderExtencao[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z321ConfiguracoesImagemHeaderNomeInteiro, BC00192_A321ConfiguracoesImagemHeaderNomeInteiro[0]) != 0 ) || ( Z322ConfiguracoesImagemHeaderTamanho != BC00192_A322ConfiguracoesImagemHeaderTamanho[0] ) || ( StringUtil.StrCmp(Z563ConfiguracaoSenhaPFX, BC00192_A563ConfiguracaoSenhaPFX[0]) != 0 ) || ( Z765ConfiguracoesSerasaAnotacoesCompletas != BC00192_A765ConfiguracoesSerasaAnotacoesCompletas[0] ) || ( Z766ConfiguracoesSerasaConsultaDetalhada != BC00192_A766ConfiguracoesSerasaConsultaDetalhada[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z767ConfiguracoesSerasaParticipacaoSocietaria != BC00192_A767ConfiguracoesSerasaParticipacaoSocietaria[0] ) || ( Z768ConfiguracoesSerasaRendaEstimada != BC00192_A768ConfiguracoesSerasaRendaEstimada[0] ) || ( Z769ConfiguracoesSerasaHistoricoPagamento != BC00192_A769ConfiguracoesSerasaHistoricoPagamento[0] ) || ( Z1013ConfiguracoesCompraTituloTaxaEfetiva != BC00192_A1013ConfiguracoesCompraTituloTaxaEfetiva[0] ) || ( Z1014ConfiguracoesCompraTituloTaxaMora != BC00192_A1014ConfiguracoesCompraTituloTaxaMora[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1036ConfiguracoesCompraTituloFator != BC00192_A1036ConfiguracoesCompraTituloFator[0] ) || ( StringUtil.StrCmp(Z1037ConfiguracoesCompraTituloTarifaTipo, BC00192_A1037ConfiguracoesCompraTituloTarifaTipo[0]) != 0 ) || ( Z1038ConfiguracoesCompraTituloTarifa != BC00192_A1038ConfiguracoesCompraTituloTarifa[0] ) || ( Z398ConfiguracoesLayoutProposta != BC00192_A398ConfiguracoesLayoutProposta[0] ) || ( Z564ConfigLayoutPromissoriaClinicaEmprestimo != BC00192_A564ConfigLayoutPromissoriaClinicaEmprestimo[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z565ConfigLayoutPromissoriaClinicaTaxa != BC00192_A565ConfigLayoutPromissoriaClinicaTaxa[0] ) || ( Z566ConfigLayoutPromissoriaPaciente != BC00192_A566ConfigLayoutPromissoriaPaciente[0] ) || ( Z922ConfigLayoutContratoCompraTitulo != BC00192_A922ConfigLayoutContratoCompraTitulo[0] ) || ( Z654ConfiguracoesCategoriaTitulo != BC00192_A654ConfiguracoesCategoriaTitulo[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Configuracoes"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1948( )
      {
         BeforeValidate1948( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1948( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1948( 0) ;
            CheckOptimisticConcurrency1948( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1948( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1948( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001912 */
                     pr_default.execute(10, new Object[] {n300ConfiguracoesImagemLogin, A300ConfiguracoesImagemLogin, n315ConfiguracoesImagemLoginNomeInteiro, A315ConfiguracoesImagemLoginNomeInteiro, n316ConfiguracoesImagemLoginTamanho, A316ConfiguracoesImagemLoginTamanho, n317ConfiguracoesImagemLoginBackground, A317ConfiguracoesImagemLoginBackground, n318ConfiguracoesImagemHeader, A318ConfiguracoesImagemHeader, n319ConfiguracoesImagemHeaderNome, A319ConfiguracoesImagemHeaderNome, n320ConfiguracoesImagemHeaderExtencao, A320ConfiguracoesImagemHeaderExtencao, n321ConfiguracoesImagemHeaderNomeInteiro, A321ConfiguracoesImagemHeaderNomeInteiro, n322ConfiguracoesImagemHeaderTamanho, A322ConfiguracoesImagemHeaderTamanho, n562ConfiguracoesArquivoPFX, A562ConfiguracoesArquivoPFX, n563ConfiguracaoSenhaPFX, A563ConfiguracaoSenhaPFX, n765ConfiguracoesSerasaAnotacoesCompletas, A765ConfiguracoesSerasaAnotacoesCompletas, n766ConfiguracoesSerasaConsultaDetalhada, A766ConfiguracoesSerasaConsultaDetalhada, n767ConfiguracoesSerasaParticipacaoSocietaria, A767ConfiguracoesSerasaParticipacaoSocietaria, n768ConfiguracoesSerasaRendaEstimada, A768ConfiguracoesSerasaRendaEstimada, n769ConfiguracoesSerasaHistoricoPagamento, A769ConfiguracoesSerasaHistoricoPagamento, n1013ConfiguracoesCompraTituloTaxaEfetiva, A1013ConfiguracoesCompraTituloTaxaEfetiva, n1014ConfiguracoesCompraTituloTaxaMora, A1014ConfiguracoesCompraTituloTaxaMora, n1036ConfiguracoesCompraTituloFator, A1036ConfiguracoesCompraTituloFator, n1037ConfiguracoesCompraTituloTarifaTipo, A1037ConfiguracoesCompraTituloTarifaTipo, n1038ConfiguracoesCompraTituloTarifa, A1038ConfiguracoesCompraTituloTarifa, n312ConfiguracoesImagemLoginExtencao, A312ConfiguracoesImagemLoginExtencao, n313ConfiguracoesImagemLoginNome, A313ConfiguracoesImagemLoginNome, n398ConfiguracoesLayoutProposta, A398ConfiguracoesLayoutProposta, n564ConfigLayoutPromissoriaClinicaEmprestimo, A564ConfigLayoutPromissoriaClinicaEmprestimo, n565ConfigLayoutPromissoriaClinicaTaxa, A565ConfigLayoutPromissoriaClinicaTaxa, n566ConfigLayoutPromissoriaPaciente, A566ConfigLayoutPromissoriaPaciente, n922ConfigLayoutContratoCompraTitulo, A922ConfigLayoutContratoCompraTitulo, n654ConfiguracoesCategoriaTitulo, A654ConfiguracoesCategoriaTitulo});
                     pr_default.close(10);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC001913 */
                     pr_default.execute(11);
                     A299ConfiguracoesId = BC001913_A299ConfiguracoesId[0];
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Configuracoes");
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
               Load1948( ) ;
            }
            EndLevel1948( ) ;
         }
         CloseExtendedTableCursors1948( ) ;
      }

      protected void Update1948( )
      {
         BeforeValidate1948( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1948( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1948( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1948( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1948( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001914 */
                     pr_default.execute(12, new Object[] {n315ConfiguracoesImagemLoginNomeInteiro, A315ConfiguracoesImagemLoginNomeInteiro, n316ConfiguracoesImagemLoginTamanho, A316ConfiguracoesImagemLoginTamanho, n317ConfiguracoesImagemLoginBackground, A317ConfiguracoesImagemLoginBackground, n319ConfiguracoesImagemHeaderNome, A319ConfiguracoesImagemHeaderNome, n320ConfiguracoesImagemHeaderExtencao, A320ConfiguracoesImagemHeaderExtencao, n321ConfiguracoesImagemHeaderNomeInteiro, A321ConfiguracoesImagemHeaderNomeInteiro, n322ConfiguracoesImagemHeaderTamanho, A322ConfiguracoesImagemHeaderTamanho, n563ConfiguracaoSenhaPFX, A563ConfiguracaoSenhaPFX, n765ConfiguracoesSerasaAnotacoesCompletas, A765ConfiguracoesSerasaAnotacoesCompletas, n766ConfiguracoesSerasaConsultaDetalhada, A766ConfiguracoesSerasaConsultaDetalhada, n767ConfiguracoesSerasaParticipacaoSocietaria, A767ConfiguracoesSerasaParticipacaoSocietaria, n768ConfiguracoesSerasaRendaEstimada, A768ConfiguracoesSerasaRendaEstimada, n769ConfiguracoesSerasaHistoricoPagamento, A769ConfiguracoesSerasaHistoricoPagamento, n1013ConfiguracoesCompraTituloTaxaEfetiva, A1013ConfiguracoesCompraTituloTaxaEfetiva, n1014ConfiguracoesCompraTituloTaxaMora, A1014ConfiguracoesCompraTituloTaxaMora, n1036ConfiguracoesCompraTituloFator, A1036ConfiguracoesCompraTituloFator, n1037ConfiguracoesCompraTituloTarifaTipo, A1037ConfiguracoesCompraTituloTarifaTipo, n1038ConfiguracoesCompraTituloTarifa, A1038ConfiguracoesCompraTituloTarifa, n312ConfiguracoesImagemLoginExtencao, A312ConfiguracoesImagemLoginExtencao, n313ConfiguracoesImagemLoginNome, A313ConfiguracoesImagemLoginNome, n398ConfiguracoesLayoutProposta, A398ConfiguracoesLayoutProposta, n564ConfigLayoutPromissoriaClinicaEmprestimo, A564ConfigLayoutPromissoriaClinicaEmprestimo, n565ConfigLayoutPromissoriaClinicaTaxa, A565ConfigLayoutPromissoriaClinicaTaxa, n566ConfigLayoutPromissoriaPaciente, A566ConfigLayoutPromissoriaPaciente, n922ConfigLayoutContratoCompraTitulo, A922ConfigLayoutContratoCompraTitulo, n654ConfiguracoesCategoriaTitulo, A654ConfiguracoesCategoriaTitulo, A299ConfiguracoesId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Configuracoes");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Configuracoes"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1948( ) ;
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
            EndLevel1948( ) ;
         }
         CloseExtendedTableCursors1948( ) ;
      }

      protected void DeferredUpdate1948( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC001915 */
            pr_default.execute(13, new Object[] {n300ConfiguracoesImagemLogin, A300ConfiguracoesImagemLogin, A299ConfiguracoesId});
            pr_default.close(13);
            pr_default.SmartCacheProvider.SetUpdated("Configuracoes");
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC001916 */
            pr_default.execute(14, new Object[] {n318ConfiguracoesImagemHeader, A318ConfiguracoesImagemHeader, A299ConfiguracoesId});
            pr_default.close(14);
            pr_default.SmartCacheProvider.SetUpdated("Configuracoes");
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC001917 */
            pr_default.execute(15, new Object[] {n562ConfiguracoesArquivoPFX, A562ConfiguracoesArquivoPFX, A299ConfiguracoesId});
            pr_default.close(15);
            pr_default.SmartCacheProvider.SetUpdated("Configuracoes");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1948( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1948( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1948( ) ;
            AfterConfirm1948( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1948( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001918 */
                  pr_default.execute(16, new Object[] {A299ConfiguracoesId});
                  pr_default.close(16);
                  pr_default.SmartCacheProvider.SetUpdated("Configuracoes");
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
         sMode48 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1948( ) ;
         Gx_mode = sMode48;
      }

      protected void OnDeleteControls1948( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001919 */
            pr_default.execute(17, new Object[] {n398ConfiguracoesLayoutProposta, A398ConfiguracoesLayoutProposta});
            A418ConfiguracoesLayoutContratoCorpo = BC001919_A418ConfiguracoesLayoutContratoCorpo[0];
            n418ConfiguracoesLayoutContratoCorpo = BC001919_n418ConfiguracoesLayoutContratoCorpo[0];
            pr_default.close(17);
            /* Using cursor BC001920 */
            pr_default.execute(18, new Object[] {n564ConfigLayoutPromissoriaClinicaEmprestimo, A564ConfigLayoutPromissoriaClinicaEmprestimo});
            A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = BC001920_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo[0];
            n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = BC001920_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo[0];
            pr_default.close(18);
            /* Using cursor BC001921 */
            pr_default.execute(19, new Object[] {n565ConfigLayoutPromissoriaClinicaTaxa, A565ConfigLayoutPromissoriaClinicaTaxa});
            A568ConfigLayoutCorpoPromissoriaClinicaTaxa = BC001921_A568ConfigLayoutCorpoPromissoriaClinicaTaxa[0];
            n568ConfigLayoutCorpoPromissoriaClinicaTaxa = BC001921_n568ConfigLayoutCorpoPromissoriaClinicaTaxa[0];
            pr_default.close(19);
            /* Using cursor BC001922 */
            pr_default.execute(20, new Object[] {n566ConfigLayoutPromissoriaPaciente, A566ConfigLayoutPromissoriaPaciente});
            A569ConfigLayoutCorpoPromissoriaPaciente = BC001922_A569ConfigLayoutCorpoPromissoriaPaciente[0];
            n569ConfigLayoutCorpoPromissoriaPaciente = BC001922_n569ConfigLayoutCorpoPromissoriaPaciente[0];
            pr_default.close(20);
         }
      }

      protected void EndLevel1948( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1948( ) ;
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

      public void ScanKeyStart1948( )
      {
         /* Using cursor BC001923 */
         pr_default.execute(21, new Object[] {A299ConfiguracoesId});
         RcdFound48 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound48 = 1;
            A299ConfiguracoesId = BC001923_A299ConfiguracoesId[0];
            A315ConfiguracoesImagemLoginNomeInteiro = BC001923_A315ConfiguracoesImagemLoginNomeInteiro[0];
            n315ConfiguracoesImagemLoginNomeInteiro = BC001923_n315ConfiguracoesImagemLoginNomeInteiro[0];
            A316ConfiguracoesImagemLoginTamanho = BC001923_A316ConfiguracoesImagemLoginTamanho[0];
            n316ConfiguracoesImagemLoginTamanho = BC001923_n316ConfiguracoesImagemLoginTamanho[0];
            A317ConfiguracoesImagemLoginBackground = BC001923_A317ConfiguracoesImagemLoginBackground[0];
            n317ConfiguracoesImagemLoginBackground = BC001923_n317ConfiguracoesImagemLoginBackground[0];
            A319ConfiguracoesImagemHeaderNome = BC001923_A319ConfiguracoesImagemHeaderNome[0];
            n319ConfiguracoesImagemHeaderNome = BC001923_n319ConfiguracoesImagemHeaderNome[0];
            A320ConfiguracoesImagemHeaderExtencao = BC001923_A320ConfiguracoesImagemHeaderExtencao[0];
            n320ConfiguracoesImagemHeaderExtencao = BC001923_n320ConfiguracoesImagemHeaderExtencao[0];
            A321ConfiguracoesImagemHeaderNomeInteiro = BC001923_A321ConfiguracoesImagemHeaderNomeInteiro[0];
            n321ConfiguracoesImagemHeaderNomeInteiro = BC001923_n321ConfiguracoesImagemHeaderNomeInteiro[0];
            A322ConfiguracoesImagemHeaderTamanho = BC001923_A322ConfiguracoesImagemHeaderTamanho[0];
            n322ConfiguracoesImagemHeaderTamanho = BC001923_n322ConfiguracoesImagemHeaderTamanho[0];
            A418ConfiguracoesLayoutContratoCorpo = BC001923_A418ConfiguracoesLayoutContratoCorpo[0];
            n418ConfiguracoesLayoutContratoCorpo = BC001923_n418ConfiguracoesLayoutContratoCorpo[0];
            A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = BC001923_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo[0];
            n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = BC001923_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo[0];
            A568ConfigLayoutCorpoPromissoriaClinicaTaxa = BC001923_A568ConfigLayoutCorpoPromissoriaClinicaTaxa[0];
            n568ConfigLayoutCorpoPromissoriaClinicaTaxa = BC001923_n568ConfigLayoutCorpoPromissoriaClinicaTaxa[0];
            A569ConfigLayoutCorpoPromissoriaPaciente = BC001923_A569ConfigLayoutCorpoPromissoriaPaciente[0];
            n569ConfigLayoutCorpoPromissoriaPaciente = BC001923_n569ConfigLayoutCorpoPromissoriaPaciente[0];
            A563ConfiguracaoSenhaPFX = BC001923_A563ConfiguracaoSenhaPFX[0];
            n563ConfiguracaoSenhaPFX = BC001923_n563ConfiguracaoSenhaPFX[0];
            A765ConfiguracoesSerasaAnotacoesCompletas = BC001923_A765ConfiguracoesSerasaAnotacoesCompletas[0];
            n765ConfiguracoesSerasaAnotacoesCompletas = BC001923_n765ConfiguracoesSerasaAnotacoesCompletas[0];
            A766ConfiguracoesSerasaConsultaDetalhada = BC001923_A766ConfiguracoesSerasaConsultaDetalhada[0];
            n766ConfiguracoesSerasaConsultaDetalhada = BC001923_n766ConfiguracoesSerasaConsultaDetalhada[0];
            A767ConfiguracoesSerasaParticipacaoSocietaria = BC001923_A767ConfiguracoesSerasaParticipacaoSocietaria[0];
            n767ConfiguracoesSerasaParticipacaoSocietaria = BC001923_n767ConfiguracoesSerasaParticipacaoSocietaria[0];
            A768ConfiguracoesSerasaRendaEstimada = BC001923_A768ConfiguracoesSerasaRendaEstimada[0];
            n768ConfiguracoesSerasaRendaEstimada = BC001923_n768ConfiguracoesSerasaRendaEstimada[0];
            A769ConfiguracoesSerasaHistoricoPagamento = BC001923_A769ConfiguracoesSerasaHistoricoPagamento[0];
            n769ConfiguracoesSerasaHistoricoPagamento = BC001923_n769ConfiguracoesSerasaHistoricoPagamento[0];
            A1013ConfiguracoesCompraTituloTaxaEfetiva = BC001923_A1013ConfiguracoesCompraTituloTaxaEfetiva[0];
            n1013ConfiguracoesCompraTituloTaxaEfetiva = BC001923_n1013ConfiguracoesCompraTituloTaxaEfetiva[0];
            A1014ConfiguracoesCompraTituloTaxaMora = BC001923_A1014ConfiguracoesCompraTituloTaxaMora[0];
            n1014ConfiguracoesCompraTituloTaxaMora = BC001923_n1014ConfiguracoesCompraTituloTaxaMora[0];
            A1036ConfiguracoesCompraTituloFator = BC001923_A1036ConfiguracoesCompraTituloFator[0];
            n1036ConfiguracoesCompraTituloFator = BC001923_n1036ConfiguracoesCompraTituloFator[0];
            A1037ConfiguracoesCompraTituloTarifaTipo = BC001923_A1037ConfiguracoesCompraTituloTarifaTipo[0];
            n1037ConfiguracoesCompraTituloTarifaTipo = BC001923_n1037ConfiguracoesCompraTituloTarifaTipo[0];
            A1038ConfiguracoesCompraTituloTarifa = BC001923_A1038ConfiguracoesCompraTituloTarifa[0];
            n1038ConfiguracoesCompraTituloTarifa = BC001923_n1038ConfiguracoesCompraTituloTarifa[0];
            A312ConfiguracoesImagemLoginExtencao = BC001923_A312ConfiguracoesImagemLoginExtencao[0];
            n312ConfiguracoesImagemLoginExtencao = BC001923_n312ConfiguracoesImagemLoginExtencao[0];
            A300ConfiguracoesImagemLogin_Filetype = A312ConfiguracoesImagemLoginExtencao;
            A313ConfiguracoesImagemLoginNome = BC001923_A313ConfiguracoesImagemLoginNome[0];
            n313ConfiguracoesImagemLoginNome = BC001923_n313ConfiguracoesImagemLoginNome[0];
            A300ConfiguracoesImagemLogin_Filename = A313ConfiguracoesImagemLoginNome;
            A398ConfiguracoesLayoutProposta = BC001923_A398ConfiguracoesLayoutProposta[0];
            n398ConfiguracoesLayoutProposta = BC001923_n398ConfiguracoesLayoutProposta[0];
            A564ConfigLayoutPromissoriaClinicaEmprestimo = BC001923_A564ConfigLayoutPromissoriaClinicaEmprestimo[0];
            n564ConfigLayoutPromissoriaClinicaEmprestimo = BC001923_n564ConfigLayoutPromissoriaClinicaEmprestimo[0];
            A565ConfigLayoutPromissoriaClinicaTaxa = BC001923_A565ConfigLayoutPromissoriaClinicaTaxa[0];
            n565ConfigLayoutPromissoriaClinicaTaxa = BC001923_n565ConfigLayoutPromissoriaClinicaTaxa[0];
            A566ConfigLayoutPromissoriaPaciente = BC001923_A566ConfigLayoutPromissoriaPaciente[0];
            n566ConfigLayoutPromissoriaPaciente = BC001923_n566ConfigLayoutPromissoriaPaciente[0];
            A922ConfigLayoutContratoCompraTitulo = BC001923_A922ConfigLayoutContratoCompraTitulo[0];
            n922ConfigLayoutContratoCompraTitulo = BC001923_n922ConfigLayoutContratoCompraTitulo[0];
            A654ConfiguracoesCategoriaTitulo = BC001923_A654ConfiguracoesCategoriaTitulo[0];
            n654ConfiguracoesCategoriaTitulo = BC001923_n654ConfiguracoesCategoriaTitulo[0];
            A300ConfiguracoesImagemLogin = BC001923_A300ConfiguracoesImagemLogin[0];
            n300ConfiguracoesImagemLogin = BC001923_n300ConfiguracoesImagemLogin[0];
            A318ConfiguracoesImagemHeader = BC001923_A318ConfiguracoesImagemHeader[0];
            n318ConfiguracoesImagemHeader = BC001923_n318ConfiguracoesImagemHeader[0];
            A562ConfiguracoesArquivoPFX = BC001923_A562ConfiguracoesArquivoPFX[0];
            n562ConfiguracoesArquivoPFX = BC001923_n562ConfiguracoesArquivoPFX[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1948( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound48 = 0;
         ScanKeyLoad1948( ) ;
      }

      protected void ScanKeyLoad1948( )
      {
         sMode48 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound48 = 1;
            A299ConfiguracoesId = BC001923_A299ConfiguracoesId[0];
            A315ConfiguracoesImagemLoginNomeInteiro = BC001923_A315ConfiguracoesImagemLoginNomeInteiro[0];
            n315ConfiguracoesImagemLoginNomeInteiro = BC001923_n315ConfiguracoesImagemLoginNomeInteiro[0];
            A316ConfiguracoesImagemLoginTamanho = BC001923_A316ConfiguracoesImagemLoginTamanho[0];
            n316ConfiguracoesImagemLoginTamanho = BC001923_n316ConfiguracoesImagemLoginTamanho[0];
            A317ConfiguracoesImagemLoginBackground = BC001923_A317ConfiguracoesImagemLoginBackground[0];
            n317ConfiguracoesImagemLoginBackground = BC001923_n317ConfiguracoesImagemLoginBackground[0];
            A319ConfiguracoesImagemHeaderNome = BC001923_A319ConfiguracoesImagemHeaderNome[0];
            n319ConfiguracoesImagemHeaderNome = BC001923_n319ConfiguracoesImagemHeaderNome[0];
            A320ConfiguracoesImagemHeaderExtencao = BC001923_A320ConfiguracoesImagemHeaderExtencao[0];
            n320ConfiguracoesImagemHeaderExtencao = BC001923_n320ConfiguracoesImagemHeaderExtencao[0];
            A321ConfiguracoesImagemHeaderNomeInteiro = BC001923_A321ConfiguracoesImagemHeaderNomeInteiro[0];
            n321ConfiguracoesImagemHeaderNomeInteiro = BC001923_n321ConfiguracoesImagemHeaderNomeInteiro[0];
            A322ConfiguracoesImagemHeaderTamanho = BC001923_A322ConfiguracoesImagemHeaderTamanho[0];
            n322ConfiguracoesImagemHeaderTamanho = BC001923_n322ConfiguracoesImagemHeaderTamanho[0];
            A418ConfiguracoesLayoutContratoCorpo = BC001923_A418ConfiguracoesLayoutContratoCorpo[0];
            n418ConfiguracoesLayoutContratoCorpo = BC001923_n418ConfiguracoesLayoutContratoCorpo[0];
            A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = BC001923_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo[0];
            n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = BC001923_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo[0];
            A568ConfigLayoutCorpoPromissoriaClinicaTaxa = BC001923_A568ConfigLayoutCorpoPromissoriaClinicaTaxa[0];
            n568ConfigLayoutCorpoPromissoriaClinicaTaxa = BC001923_n568ConfigLayoutCorpoPromissoriaClinicaTaxa[0];
            A569ConfigLayoutCorpoPromissoriaPaciente = BC001923_A569ConfigLayoutCorpoPromissoriaPaciente[0];
            n569ConfigLayoutCorpoPromissoriaPaciente = BC001923_n569ConfigLayoutCorpoPromissoriaPaciente[0];
            A563ConfiguracaoSenhaPFX = BC001923_A563ConfiguracaoSenhaPFX[0];
            n563ConfiguracaoSenhaPFX = BC001923_n563ConfiguracaoSenhaPFX[0];
            A765ConfiguracoesSerasaAnotacoesCompletas = BC001923_A765ConfiguracoesSerasaAnotacoesCompletas[0];
            n765ConfiguracoesSerasaAnotacoesCompletas = BC001923_n765ConfiguracoesSerasaAnotacoesCompletas[0];
            A766ConfiguracoesSerasaConsultaDetalhada = BC001923_A766ConfiguracoesSerasaConsultaDetalhada[0];
            n766ConfiguracoesSerasaConsultaDetalhada = BC001923_n766ConfiguracoesSerasaConsultaDetalhada[0];
            A767ConfiguracoesSerasaParticipacaoSocietaria = BC001923_A767ConfiguracoesSerasaParticipacaoSocietaria[0];
            n767ConfiguracoesSerasaParticipacaoSocietaria = BC001923_n767ConfiguracoesSerasaParticipacaoSocietaria[0];
            A768ConfiguracoesSerasaRendaEstimada = BC001923_A768ConfiguracoesSerasaRendaEstimada[0];
            n768ConfiguracoesSerasaRendaEstimada = BC001923_n768ConfiguracoesSerasaRendaEstimada[0];
            A769ConfiguracoesSerasaHistoricoPagamento = BC001923_A769ConfiguracoesSerasaHistoricoPagamento[0];
            n769ConfiguracoesSerasaHistoricoPagamento = BC001923_n769ConfiguracoesSerasaHistoricoPagamento[0];
            A1013ConfiguracoesCompraTituloTaxaEfetiva = BC001923_A1013ConfiguracoesCompraTituloTaxaEfetiva[0];
            n1013ConfiguracoesCompraTituloTaxaEfetiva = BC001923_n1013ConfiguracoesCompraTituloTaxaEfetiva[0];
            A1014ConfiguracoesCompraTituloTaxaMora = BC001923_A1014ConfiguracoesCompraTituloTaxaMora[0];
            n1014ConfiguracoesCompraTituloTaxaMora = BC001923_n1014ConfiguracoesCompraTituloTaxaMora[0];
            A1036ConfiguracoesCompraTituloFator = BC001923_A1036ConfiguracoesCompraTituloFator[0];
            n1036ConfiguracoesCompraTituloFator = BC001923_n1036ConfiguracoesCompraTituloFator[0];
            A1037ConfiguracoesCompraTituloTarifaTipo = BC001923_A1037ConfiguracoesCompraTituloTarifaTipo[0];
            n1037ConfiguracoesCompraTituloTarifaTipo = BC001923_n1037ConfiguracoesCompraTituloTarifaTipo[0];
            A1038ConfiguracoesCompraTituloTarifa = BC001923_A1038ConfiguracoesCompraTituloTarifa[0];
            n1038ConfiguracoesCompraTituloTarifa = BC001923_n1038ConfiguracoesCompraTituloTarifa[0];
            A312ConfiguracoesImagemLoginExtencao = BC001923_A312ConfiguracoesImagemLoginExtencao[0];
            n312ConfiguracoesImagemLoginExtencao = BC001923_n312ConfiguracoesImagemLoginExtencao[0];
            A300ConfiguracoesImagemLogin_Filetype = A312ConfiguracoesImagemLoginExtencao;
            A313ConfiguracoesImagemLoginNome = BC001923_A313ConfiguracoesImagemLoginNome[0];
            n313ConfiguracoesImagemLoginNome = BC001923_n313ConfiguracoesImagemLoginNome[0];
            A300ConfiguracoesImagemLogin_Filename = A313ConfiguracoesImagemLoginNome;
            A398ConfiguracoesLayoutProposta = BC001923_A398ConfiguracoesLayoutProposta[0];
            n398ConfiguracoesLayoutProposta = BC001923_n398ConfiguracoesLayoutProposta[0];
            A564ConfigLayoutPromissoriaClinicaEmprestimo = BC001923_A564ConfigLayoutPromissoriaClinicaEmprestimo[0];
            n564ConfigLayoutPromissoriaClinicaEmprestimo = BC001923_n564ConfigLayoutPromissoriaClinicaEmprestimo[0];
            A565ConfigLayoutPromissoriaClinicaTaxa = BC001923_A565ConfigLayoutPromissoriaClinicaTaxa[0];
            n565ConfigLayoutPromissoriaClinicaTaxa = BC001923_n565ConfigLayoutPromissoriaClinicaTaxa[0];
            A566ConfigLayoutPromissoriaPaciente = BC001923_A566ConfigLayoutPromissoriaPaciente[0];
            n566ConfigLayoutPromissoriaPaciente = BC001923_n566ConfigLayoutPromissoriaPaciente[0];
            A922ConfigLayoutContratoCompraTitulo = BC001923_A922ConfigLayoutContratoCompraTitulo[0];
            n922ConfigLayoutContratoCompraTitulo = BC001923_n922ConfigLayoutContratoCompraTitulo[0];
            A654ConfiguracoesCategoriaTitulo = BC001923_A654ConfiguracoesCategoriaTitulo[0];
            n654ConfiguracoesCategoriaTitulo = BC001923_n654ConfiguracoesCategoriaTitulo[0];
            A300ConfiguracoesImagemLogin = BC001923_A300ConfiguracoesImagemLogin[0];
            n300ConfiguracoesImagemLogin = BC001923_n300ConfiguracoesImagemLogin[0];
            A318ConfiguracoesImagemHeader = BC001923_A318ConfiguracoesImagemHeader[0];
            n318ConfiguracoesImagemHeader = BC001923_n318ConfiguracoesImagemHeader[0];
            A562ConfiguracoesArquivoPFX = BC001923_A562ConfiguracoesArquivoPFX[0];
            n562ConfiguracoesArquivoPFX = BC001923_n562ConfiguracoesArquivoPFX[0];
         }
         Gx_mode = sMode48;
      }

      protected void ScanKeyEnd1948( )
      {
         pr_default.close(21);
      }

      protected void AfterConfirm1948( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1948( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1948( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1948( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1948( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1948( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1948( )
      {
      }

      protected void send_integrity_lvl_hashes1948( )
      {
      }

      protected void AddRow1948( )
      {
         VarsToRow48( bcConfiguracoes) ;
      }

      protected void ReadRow1948( )
      {
         RowToVars48( bcConfiguracoes, 1) ;
      }

      protected void InitializeNonKey1948( )
      {
         A300ConfiguracoesImagemLogin = "";
         n300ConfiguracoesImagemLogin = false;
         A315ConfiguracoesImagemLoginNomeInteiro = "";
         n315ConfiguracoesImagemLoginNomeInteiro = false;
         A316ConfiguracoesImagemLoginTamanho = 0;
         n316ConfiguracoesImagemLoginTamanho = false;
         A317ConfiguracoesImagemLoginBackground = "";
         n317ConfiguracoesImagemLoginBackground = false;
         A318ConfiguracoesImagemHeader = "";
         n318ConfiguracoesImagemHeader = false;
         A319ConfiguracoesImagemHeaderNome = "";
         n319ConfiguracoesImagemHeaderNome = false;
         A320ConfiguracoesImagemHeaderExtencao = "";
         n320ConfiguracoesImagemHeaderExtencao = false;
         A321ConfiguracoesImagemHeaderNomeInteiro = "";
         n321ConfiguracoesImagemHeaderNomeInteiro = false;
         A322ConfiguracoesImagemHeaderTamanho = 0;
         n322ConfiguracoesImagemHeaderTamanho = false;
         A398ConfiguracoesLayoutProposta = 0;
         n398ConfiguracoesLayoutProposta = false;
         A418ConfiguracoesLayoutContratoCorpo = "";
         n418ConfiguracoesLayoutContratoCorpo = false;
         A564ConfigLayoutPromissoriaClinicaEmprestimo = 0;
         n564ConfigLayoutPromissoriaClinicaEmprestimo = false;
         A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = "";
         n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = false;
         A565ConfigLayoutPromissoriaClinicaTaxa = 0;
         n565ConfigLayoutPromissoriaClinicaTaxa = false;
         A568ConfigLayoutCorpoPromissoriaClinicaTaxa = "";
         n568ConfigLayoutCorpoPromissoriaClinicaTaxa = false;
         A566ConfigLayoutPromissoriaPaciente = 0;
         n566ConfigLayoutPromissoriaPaciente = false;
         A922ConfigLayoutContratoCompraTitulo = 0;
         n922ConfigLayoutContratoCompraTitulo = false;
         A569ConfigLayoutCorpoPromissoriaPaciente = "";
         n569ConfigLayoutCorpoPromissoriaPaciente = false;
         A562ConfiguracoesArquivoPFX = "";
         n562ConfiguracoesArquivoPFX = false;
         A563ConfiguracaoSenhaPFX = "";
         n563ConfiguracaoSenhaPFX = false;
         A654ConfiguracoesCategoriaTitulo = 0;
         n654ConfiguracoesCategoriaTitulo = false;
         A765ConfiguracoesSerasaAnotacoesCompletas = false;
         n765ConfiguracoesSerasaAnotacoesCompletas = false;
         A766ConfiguracoesSerasaConsultaDetalhada = false;
         n766ConfiguracoesSerasaConsultaDetalhada = false;
         A767ConfiguracoesSerasaParticipacaoSocietaria = false;
         n767ConfiguracoesSerasaParticipacaoSocietaria = false;
         A768ConfiguracoesSerasaRendaEstimada = false;
         n768ConfiguracoesSerasaRendaEstimada = false;
         A769ConfiguracoesSerasaHistoricoPagamento = false;
         n769ConfiguracoesSerasaHistoricoPagamento = false;
         A1013ConfiguracoesCompraTituloTaxaEfetiva = 0;
         n1013ConfiguracoesCompraTituloTaxaEfetiva = false;
         A1014ConfiguracoesCompraTituloTaxaMora = 0;
         n1014ConfiguracoesCompraTituloTaxaMora = false;
         A1036ConfiguracoesCompraTituloFator = 0;
         n1036ConfiguracoesCompraTituloFator = false;
         A1037ConfiguracoesCompraTituloTarifaTipo = "";
         n1037ConfiguracoesCompraTituloTarifaTipo = false;
         A1038ConfiguracoesCompraTituloTarifa = 0;
         n1038ConfiguracoesCompraTituloTarifa = false;
         A312ConfiguracoesImagemLoginExtencao = "";
         n312ConfiguracoesImagemLoginExtencao = false;
         A313ConfiguracoesImagemLoginNome = "";
         n313ConfiguracoesImagemLoginNome = false;
         Z315ConfiguracoesImagemLoginNomeInteiro = "";
         Z316ConfiguracoesImagemLoginTamanho = 0;
         Z317ConfiguracoesImagemLoginBackground = "";
         Z319ConfiguracoesImagemHeaderNome = "";
         Z320ConfiguracoesImagemHeaderExtencao = "";
         Z321ConfiguracoesImagemHeaderNomeInteiro = "";
         Z322ConfiguracoesImagemHeaderTamanho = 0;
         Z563ConfiguracaoSenhaPFX = "";
         Z765ConfiguracoesSerasaAnotacoesCompletas = false;
         Z766ConfiguracoesSerasaConsultaDetalhada = false;
         Z767ConfiguracoesSerasaParticipacaoSocietaria = false;
         Z768ConfiguracoesSerasaRendaEstimada = false;
         Z769ConfiguracoesSerasaHistoricoPagamento = false;
         Z1013ConfiguracoesCompraTituloTaxaEfetiva = 0;
         Z1014ConfiguracoesCompraTituloTaxaMora = 0;
         Z1036ConfiguracoesCompraTituloFator = 0;
         Z1037ConfiguracoesCompraTituloTarifaTipo = "";
         Z1038ConfiguracoesCompraTituloTarifa = 0;
         Z398ConfiguracoesLayoutProposta = 0;
         Z564ConfigLayoutPromissoriaClinicaEmprestimo = 0;
         Z565ConfigLayoutPromissoriaClinicaTaxa = 0;
         Z566ConfigLayoutPromissoriaPaciente = 0;
         Z922ConfigLayoutContratoCompraTitulo = 0;
         Z654ConfiguracoesCategoriaTitulo = 0;
      }

      protected void InitAll1948( )
      {
         A299ConfiguracoesId = 0;
         InitializeNonKey1948( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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

      public void VarsToRow48( SdtConfiguracoes obj48 )
      {
         obj48.gxTpr_Mode = Gx_mode;
         obj48.gxTpr_Configuracoesimagemlogin = A300ConfiguracoesImagemLogin;
         obj48.gxTpr_Configuracoesimagemloginnomeinteiro = A315ConfiguracoesImagemLoginNomeInteiro;
         obj48.gxTpr_Configuracoesimagemlogintamanho = A316ConfiguracoesImagemLoginTamanho;
         obj48.gxTpr_Configuracoesimagemloginbackground = A317ConfiguracoesImagemLoginBackground;
         obj48.gxTpr_Configuracoesimagemheader = A318ConfiguracoesImagemHeader;
         obj48.gxTpr_Configuracoesimagemheadernome = A319ConfiguracoesImagemHeaderNome;
         obj48.gxTpr_Configuracoesimagemheaderextencao = A320ConfiguracoesImagemHeaderExtencao;
         obj48.gxTpr_Configuracoesimagemheadernomeinteiro = A321ConfiguracoesImagemHeaderNomeInteiro;
         obj48.gxTpr_Configuracoesimagemheadertamanho = A322ConfiguracoesImagemHeaderTamanho;
         obj48.gxTpr_Configuracoeslayoutproposta = A398ConfiguracoesLayoutProposta;
         obj48.gxTpr_Configuracoeslayoutcontratocorpo = A418ConfiguracoesLayoutContratoCorpo;
         obj48.gxTpr_Configlayoutpromissoriaclinicaemprestimo = A564ConfigLayoutPromissoriaClinicaEmprestimo;
         obj48.gxTpr_Configlayoutcorpopromissoriaclinicaemprestimo = A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo;
         obj48.gxTpr_Configlayoutpromissoriaclinicataxa = A565ConfigLayoutPromissoriaClinicaTaxa;
         obj48.gxTpr_Configlayoutcorpopromissoriaclinicataxa = A568ConfigLayoutCorpoPromissoriaClinicaTaxa;
         obj48.gxTpr_Configlayoutpromissoriapaciente = A566ConfigLayoutPromissoriaPaciente;
         obj48.gxTpr_Configlayoutcontratocompratitulo = A922ConfigLayoutContratoCompraTitulo;
         obj48.gxTpr_Configlayoutcorpopromissoriapaciente = A569ConfigLayoutCorpoPromissoriaPaciente;
         obj48.gxTpr_Configuracoesarquivopfx = A562ConfiguracoesArquivoPFX;
         obj48.gxTpr_Configuracaosenhapfx = A563ConfiguracaoSenhaPFX;
         obj48.gxTpr_Configuracoescategoriatitulo = A654ConfiguracoesCategoriaTitulo;
         obj48.gxTpr_Configuracoesserasaanotacoescompletas = A765ConfiguracoesSerasaAnotacoesCompletas;
         obj48.gxTpr_Configuracoesserasaconsultadetalhada = A766ConfiguracoesSerasaConsultaDetalhada;
         obj48.gxTpr_Configuracoesserasaparticipacaosocietaria = A767ConfiguracoesSerasaParticipacaoSocietaria;
         obj48.gxTpr_Configuracoesserasarendaestimada = A768ConfiguracoesSerasaRendaEstimada;
         obj48.gxTpr_Configuracoesserasahistoricopagamento = A769ConfiguracoesSerasaHistoricoPagamento;
         obj48.gxTpr_Configuracoescompratitulotaxaefetiva = A1013ConfiguracoesCompraTituloTaxaEfetiva;
         obj48.gxTpr_Configuracoescompratitulotaxamora = A1014ConfiguracoesCompraTituloTaxaMora;
         obj48.gxTpr_Configuracoescompratitulofator = A1036ConfiguracoesCompraTituloFator;
         obj48.gxTpr_Configuracoescompratitulotarifatipo = A1037ConfiguracoesCompraTituloTarifaTipo;
         obj48.gxTpr_Configuracoescompratitulotarifa = A1038ConfiguracoesCompraTituloTarifa;
         obj48.gxTpr_Configuracoesimagemloginextencao = A312ConfiguracoesImagemLoginExtencao;
         obj48.gxTpr_Configuracoesimagemloginnome = A313ConfiguracoesImagemLoginNome;
         obj48.gxTpr_Configuracoesid = A299ConfiguracoesId;
         obj48.gxTpr_Configuracoesid_Z = Z299ConfiguracoesId;
         obj48.gxTpr_Configuracoesimagemloginnome_Z = Z313ConfiguracoesImagemLoginNome;
         obj48.gxTpr_Configuracoesimagemloginextencao_Z = Z312ConfiguracoesImagemLoginExtencao;
         obj48.gxTpr_Configuracoesimagemloginnomeinteiro_Z = Z315ConfiguracoesImagemLoginNomeInteiro;
         obj48.gxTpr_Configuracoesimagemlogintamanho_Z = Z316ConfiguracoesImagemLoginTamanho;
         obj48.gxTpr_Configuracoesimagemloginbackground_Z = Z317ConfiguracoesImagemLoginBackground;
         obj48.gxTpr_Configuracoesimagemheadernome_Z = Z319ConfiguracoesImagemHeaderNome;
         obj48.gxTpr_Configuracoesimagemheaderextencao_Z = Z320ConfiguracoesImagemHeaderExtencao;
         obj48.gxTpr_Configuracoesimagemheadernomeinteiro_Z = Z321ConfiguracoesImagemHeaderNomeInteiro;
         obj48.gxTpr_Configuracoesimagemheadertamanho_Z = Z322ConfiguracoesImagemHeaderTamanho;
         obj48.gxTpr_Configuracoeslayoutproposta_Z = Z398ConfiguracoesLayoutProposta;
         obj48.gxTpr_Configlayoutpromissoriaclinicaemprestimo_Z = Z564ConfigLayoutPromissoriaClinicaEmprestimo;
         obj48.gxTpr_Configlayoutpromissoriaclinicataxa_Z = Z565ConfigLayoutPromissoriaClinicaTaxa;
         obj48.gxTpr_Configlayoutpromissoriapaciente_Z = Z566ConfigLayoutPromissoriaPaciente;
         obj48.gxTpr_Configlayoutcontratocompratitulo_Z = Z922ConfigLayoutContratoCompraTitulo;
         obj48.gxTpr_Configuracaosenhapfx_Z = Z563ConfiguracaoSenhaPFX;
         obj48.gxTpr_Configuracoescategoriatitulo_Z = Z654ConfiguracoesCategoriaTitulo;
         obj48.gxTpr_Configuracoesserasaanotacoescompletas_Z = Z765ConfiguracoesSerasaAnotacoesCompletas;
         obj48.gxTpr_Configuracoesserasaconsultadetalhada_Z = Z766ConfiguracoesSerasaConsultaDetalhada;
         obj48.gxTpr_Configuracoesserasaparticipacaosocietaria_Z = Z767ConfiguracoesSerasaParticipacaoSocietaria;
         obj48.gxTpr_Configuracoesserasarendaestimada_Z = Z768ConfiguracoesSerasaRendaEstimada;
         obj48.gxTpr_Configuracoesserasahistoricopagamento_Z = Z769ConfiguracoesSerasaHistoricoPagamento;
         obj48.gxTpr_Configuracoescompratitulotaxaefetiva_Z = Z1013ConfiguracoesCompraTituloTaxaEfetiva;
         obj48.gxTpr_Configuracoescompratitulotaxamora_Z = Z1014ConfiguracoesCompraTituloTaxaMora;
         obj48.gxTpr_Configuracoescompratitulofator_Z = Z1036ConfiguracoesCompraTituloFator;
         obj48.gxTpr_Configuracoescompratitulotarifatipo_Z = Z1037ConfiguracoesCompraTituloTarifaTipo;
         obj48.gxTpr_Configuracoescompratitulotarifa_Z = Z1038ConfiguracoesCompraTituloTarifa;
         obj48.gxTpr_Configuracoesimagemlogin_N = (short)(Convert.ToInt16(n300ConfiguracoesImagemLogin));
         obj48.gxTpr_Configuracoesimagemloginnome_N = (short)(Convert.ToInt16(n313ConfiguracoesImagemLoginNome));
         obj48.gxTpr_Configuracoesimagemloginextencao_N = (short)(Convert.ToInt16(n312ConfiguracoesImagemLoginExtencao));
         obj48.gxTpr_Configuracoesimagemloginnomeinteiro_N = (short)(Convert.ToInt16(n315ConfiguracoesImagemLoginNomeInteiro));
         obj48.gxTpr_Configuracoesimagemlogintamanho_N = (short)(Convert.ToInt16(n316ConfiguracoesImagemLoginTamanho));
         obj48.gxTpr_Configuracoesimagemloginbackground_N = (short)(Convert.ToInt16(n317ConfiguracoesImagemLoginBackground));
         obj48.gxTpr_Configuracoesimagemheader_N = (short)(Convert.ToInt16(n318ConfiguracoesImagemHeader));
         obj48.gxTpr_Configuracoesimagemheadernome_N = (short)(Convert.ToInt16(n319ConfiguracoesImagemHeaderNome));
         obj48.gxTpr_Configuracoesimagemheaderextencao_N = (short)(Convert.ToInt16(n320ConfiguracoesImagemHeaderExtencao));
         obj48.gxTpr_Configuracoesimagemheadernomeinteiro_N = (short)(Convert.ToInt16(n321ConfiguracoesImagemHeaderNomeInteiro));
         obj48.gxTpr_Configuracoesimagemheadertamanho_N = (short)(Convert.ToInt16(n322ConfiguracoesImagemHeaderTamanho));
         obj48.gxTpr_Configuracoeslayoutproposta_N = (short)(Convert.ToInt16(n398ConfiguracoesLayoutProposta));
         obj48.gxTpr_Configuracoeslayoutcontratocorpo_N = (short)(Convert.ToInt16(n418ConfiguracoesLayoutContratoCorpo));
         obj48.gxTpr_Configlayoutpromissoriaclinicaemprestimo_N = (short)(Convert.ToInt16(n564ConfigLayoutPromissoriaClinicaEmprestimo));
         obj48.gxTpr_Configlayoutcorpopromissoriaclinicaemprestimo_N = (short)(Convert.ToInt16(n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo));
         obj48.gxTpr_Configlayoutpromissoriaclinicataxa_N = (short)(Convert.ToInt16(n565ConfigLayoutPromissoriaClinicaTaxa));
         obj48.gxTpr_Configlayoutcorpopromissoriaclinicataxa_N = (short)(Convert.ToInt16(n568ConfigLayoutCorpoPromissoriaClinicaTaxa));
         obj48.gxTpr_Configlayoutpromissoriapaciente_N = (short)(Convert.ToInt16(n566ConfigLayoutPromissoriaPaciente));
         obj48.gxTpr_Configlayoutcontratocompratitulo_N = (short)(Convert.ToInt16(n922ConfigLayoutContratoCompraTitulo));
         obj48.gxTpr_Configlayoutcorpopromissoriapaciente_N = (short)(Convert.ToInt16(n569ConfigLayoutCorpoPromissoriaPaciente));
         obj48.gxTpr_Configuracoesarquivopfx_N = (short)(Convert.ToInt16(n562ConfiguracoesArquivoPFX));
         obj48.gxTpr_Configuracaosenhapfx_N = (short)(Convert.ToInt16(n563ConfiguracaoSenhaPFX));
         obj48.gxTpr_Configuracoescategoriatitulo_N = (short)(Convert.ToInt16(n654ConfiguracoesCategoriaTitulo));
         obj48.gxTpr_Configuracoesserasaanotacoescompletas_N = (short)(Convert.ToInt16(n765ConfiguracoesSerasaAnotacoesCompletas));
         obj48.gxTpr_Configuracoesserasaconsultadetalhada_N = (short)(Convert.ToInt16(n766ConfiguracoesSerasaConsultaDetalhada));
         obj48.gxTpr_Configuracoesserasaparticipacaosocietaria_N = (short)(Convert.ToInt16(n767ConfiguracoesSerasaParticipacaoSocietaria));
         obj48.gxTpr_Configuracoesserasarendaestimada_N = (short)(Convert.ToInt16(n768ConfiguracoesSerasaRendaEstimada));
         obj48.gxTpr_Configuracoesserasahistoricopagamento_N = (short)(Convert.ToInt16(n769ConfiguracoesSerasaHistoricoPagamento));
         obj48.gxTpr_Configuracoescompratitulotaxaefetiva_N = (short)(Convert.ToInt16(n1013ConfiguracoesCompraTituloTaxaEfetiva));
         obj48.gxTpr_Configuracoescompratitulotaxamora_N = (short)(Convert.ToInt16(n1014ConfiguracoesCompraTituloTaxaMora));
         obj48.gxTpr_Configuracoescompratitulofator_N = (short)(Convert.ToInt16(n1036ConfiguracoesCompraTituloFator));
         obj48.gxTpr_Configuracoescompratitulotarifatipo_N = (short)(Convert.ToInt16(n1037ConfiguracoesCompraTituloTarifaTipo));
         obj48.gxTpr_Configuracoescompratitulotarifa_N = (short)(Convert.ToInt16(n1038ConfiguracoesCompraTituloTarifa));
         obj48.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow48( SdtConfiguracoes obj48 )
      {
         obj48.gxTpr_Configuracoesid = A299ConfiguracoesId;
         return  ;
      }

      public void RowToVars48( SdtConfiguracoes obj48 ,
                               int forceLoad )
      {
         Gx_mode = obj48.gxTpr_Mode;
         A300ConfiguracoesImagemLogin = obj48.gxTpr_Configuracoesimagemlogin;
         n300ConfiguracoesImagemLogin = false;
         A315ConfiguracoesImagemLoginNomeInteiro = obj48.gxTpr_Configuracoesimagemloginnomeinteiro;
         n315ConfiguracoesImagemLoginNomeInteiro = false;
         A316ConfiguracoesImagemLoginTamanho = obj48.gxTpr_Configuracoesimagemlogintamanho;
         n316ConfiguracoesImagemLoginTamanho = false;
         A317ConfiguracoesImagemLoginBackground = obj48.gxTpr_Configuracoesimagemloginbackground;
         n317ConfiguracoesImagemLoginBackground = false;
         A318ConfiguracoesImagemHeader = obj48.gxTpr_Configuracoesimagemheader;
         n318ConfiguracoesImagemHeader = false;
         A319ConfiguracoesImagemHeaderNome = obj48.gxTpr_Configuracoesimagemheadernome;
         n319ConfiguracoesImagemHeaderNome = false;
         A320ConfiguracoesImagemHeaderExtencao = obj48.gxTpr_Configuracoesimagemheaderextencao;
         n320ConfiguracoesImagemHeaderExtencao = false;
         A321ConfiguracoesImagemHeaderNomeInteiro = obj48.gxTpr_Configuracoesimagemheadernomeinteiro;
         n321ConfiguracoesImagemHeaderNomeInteiro = false;
         A322ConfiguracoesImagemHeaderTamanho = obj48.gxTpr_Configuracoesimagemheadertamanho;
         n322ConfiguracoesImagemHeaderTamanho = false;
         A398ConfiguracoesLayoutProposta = obj48.gxTpr_Configuracoeslayoutproposta;
         n398ConfiguracoesLayoutProposta = false;
         A418ConfiguracoesLayoutContratoCorpo = obj48.gxTpr_Configuracoeslayoutcontratocorpo;
         n418ConfiguracoesLayoutContratoCorpo = false;
         A564ConfigLayoutPromissoriaClinicaEmprestimo = obj48.gxTpr_Configlayoutpromissoriaclinicaemprestimo;
         n564ConfigLayoutPromissoriaClinicaEmprestimo = false;
         A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = obj48.gxTpr_Configlayoutcorpopromissoriaclinicaemprestimo;
         n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = false;
         A565ConfigLayoutPromissoriaClinicaTaxa = obj48.gxTpr_Configlayoutpromissoriaclinicataxa;
         n565ConfigLayoutPromissoriaClinicaTaxa = false;
         A568ConfigLayoutCorpoPromissoriaClinicaTaxa = obj48.gxTpr_Configlayoutcorpopromissoriaclinicataxa;
         n568ConfigLayoutCorpoPromissoriaClinicaTaxa = false;
         A566ConfigLayoutPromissoriaPaciente = obj48.gxTpr_Configlayoutpromissoriapaciente;
         n566ConfigLayoutPromissoriaPaciente = false;
         A922ConfigLayoutContratoCompraTitulo = obj48.gxTpr_Configlayoutcontratocompratitulo;
         n922ConfigLayoutContratoCompraTitulo = false;
         A569ConfigLayoutCorpoPromissoriaPaciente = obj48.gxTpr_Configlayoutcorpopromissoriapaciente;
         n569ConfigLayoutCorpoPromissoriaPaciente = false;
         A562ConfiguracoesArquivoPFX = obj48.gxTpr_Configuracoesarquivopfx;
         n562ConfiguracoesArquivoPFX = false;
         A563ConfiguracaoSenhaPFX = obj48.gxTpr_Configuracaosenhapfx;
         n563ConfiguracaoSenhaPFX = false;
         A654ConfiguracoesCategoriaTitulo = obj48.gxTpr_Configuracoescategoriatitulo;
         n654ConfiguracoesCategoriaTitulo = false;
         A765ConfiguracoesSerasaAnotacoesCompletas = obj48.gxTpr_Configuracoesserasaanotacoescompletas;
         n765ConfiguracoesSerasaAnotacoesCompletas = false;
         A766ConfiguracoesSerasaConsultaDetalhada = obj48.gxTpr_Configuracoesserasaconsultadetalhada;
         n766ConfiguracoesSerasaConsultaDetalhada = false;
         A767ConfiguracoesSerasaParticipacaoSocietaria = obj48.gxTpr_Configuracoesserasaparticipacaosocietaria;
         n767ConfiguracoesSerasaParticipacaoSocietaria = false;
         A768ConfiguracoesSerasaRendaEstimada = obj48.gxTpr_Configuracoesserasarendaestimada;
         n768ConfiguracoesSerasaRendaEstimada = false;
         A769ConfiguracoesSerasaHistoricoPagamento = obj48.gxTpr_Configuracoesserasahistoricopagamento;
         n769ConfiguracoesSerasaHistoricoPagamento = false;
         A1013ConfiguracoesCompraTituloTaxaEfetiva = obj48.gxTpr_Configuracoescompratitulotaxaefetiva;
         n1013ConfiguracoesCompraTituloTaxaEfetiva = false;
         A1014ConfiguracoesCompraTituloTaxaMora = obj48.gxTpr_Configuracoescompratitulotaxamora;
         n1014ConfiguracoesCompraTituloTaxaMora = false;
         A1036ConfiguracoesCompraTituloFator = obj48.gxTpr_Configuracoescompratitulofator;
         n1036ConfiguracoesCompraTituloFator = false;
         A1037ConfiguracoesCompraTituloTarifaTipo = obj48.gxTpr_Configuracoescompratitulotarifatipo;
         n1037ConfiguracoesCompraTituloTarifaTipo = false;
         A1038ConfiguracoesCompraTituloTarifa = obj48.gxTpr_Configuracoescompratitulotarifa;
         n1038ConfiguracoesCompraTituloTarifa = false;
         A312ConfiguracoesImagemLoginExtencao = (String.IsNullOrEmpty(StringUtil.RTrim( obj48.gxTpr_Configuracoesimagemloginextencao)) ? FileUtil.GetFileType( A300ConfiguracoesImagemLogin) : obj48.gxTpr_Configuracoesimagemloginextencao);
         n312ConfiguracoesImagemLoginExtencao = false;
         A313ConfiguracoesImagemLoginNome = (String.IsNullOrEmpty(StringUtil.RTrim( obj48.gxTpr_Configuracoesimagemloginnome)) ? FileUtil.GetFileName( A300ConfiguracoesImagemLogin) : obj48.gxTpr_Configuracoesimagemloginnome);
         n313ConfiguracoesImagemLoginNome = false;
         A299ConfiguracoesId = obj48.gxTpr_Configuracoesid;
         Z299ConfiguracoesId = obj48.gxTpr_Configuracoesid_Z;
         Z313ConfiguracoesImagemLoginNome = obj48.gxTpr_Configuracoesimagemloginnome_Z;
         Z312ConfiguracoesImagemLoginExtencao = obj48.gxTpr_Configuracoesimagemloginextencao_Z;
         Z315ConfiguracoesImagemLoginNomeInteiro = obj48.gxTpr_Configuracoesimagemloginnomeinteiro_Z;
         Z316ConfiguracoesImagemLoginTamanho = obj48.gxTpr_Configuracoesimagemlogintamanho_Z;
         Z317ConfiguracoesImagemLoginBackground = obj48.gxTpr_Configuracoesimagemloginbackground_Z;
         Z319ConfiguracoesImagemHeaderNome = obj48.gxTpr_Configuracoesimagemheadernome_Z;
         Z320ConfiguracoesImagemHeaderExtencao = obj48.gxTpr_Configuracoesimagemheaderextencao_Z;
         Z321ConfiguracoesImagemHeaderNomeInteiro = obj48.gxTpr_Configuracoesimagemheadernomeinteiro_Z;
         Z322ConfiguracoesImagemHeaderTamanho = obj48.gxTpr_Configuracoesimagemheadertamanho_Z;
         Z398ConfiguracoesLayoutProposta = obj48.gxTpr_Configuracoeslayoutproposta_Z;
         Z564ConfigLayoutPromissoriaClinicaEmprestimo = obj48.gxTpr_Configlayoutpromissoriaclinicaemprestimo_Z;
         Z565ConfigLayoutPromissoriaClinicaTaxa = obj48.gxTpr_Configlayoutpromissoriaclinicataxa_Z;
         Z566ConfigLayoutPromissoriaPaciente = obj48.gxTpr_Configlayoutpromissoriapaciente_Z;
         Z922ConfigLayoutContratoCompraTitulo = obj48.gxTpr_Configlayoutcontratocompratitulo_Z;
         Z563ConfiguracaoSenhaPFX = obj48.gxTpr_Configuracaosenhapfx_Z;
         Z654ConfiguracoesCategoriaTitulo = obj48.gxTpr_Configuracoescategoriatitulo_Z;
         Z765ConfiguracoesSerasaAnotacoesCompletas = obj48.gxTpr_Configuracoesserasaanotacoescompletas_Z;
         Z766ConfiguracoesSerasaConsultaDetalhada = obj48.gxTpr_Configuracoesserasaconsultadetalhada_Z;
         Z767ConfiguracoesSerasaParticipacaoSocietaria = obj48.gxTpr_Configuracoesserasaparticipacaosocietaria_Z;
         Z768ConfiguracoesSerasaRendaEstimada = obj48.gxTpr_Configuracoesserasarendaestimada_Z;
         Z769ConfiguracoesSerasaHistoricoPagamento = obj48.gxTpr_Configuracoesserasahistoricopagamento_Z;
         Z1013ConfiguracoesCompraTituloTaxaEfetiva = obj48.gxTpr_Configuracoescompratitulotaxaefetiva_Z;
         Z1014ConfiguracoesCompraTituloTaxaMora = obj48.gxTpr_Configuracoescompratitulotaxamora_Z;
         Z1036ConfiguracoesCompraTituloFator = obj48.gxTpr_Configuracoescompratitulofator_Z;
         Z1037ConfiguracoesCompraTituloTarifaTipo = obj48.gxTpr_Configuracoescompratitulotarifatipo_Z;
         Z1038ConfiguracoesCompraTituloTarifa = obj48.gxTpr_Configuracoescompratitulotarifa_Z;
         n300ConfiguracoesImagemLogin = (bool)(Convert.ToBoolean(obj48.gxTpr_Configuracoesimagemlogin_N));
         n313ConfiguracoesImagemLoginNome = (bool)(Convert.ToBoolean(obj48.gxTpr_Configuracoesimagemloginnome_N));
         n312ConfiguracoesImagemLoginExtencao = (bool)(Convert.ToBoolean(obj48.gxTpr_Configuracoesimagemloginextencao_N));
         n315ConfiguracoesImagemLoginNomeInteiro = (bool)(Convert.ToBoolean(obj48.gxTpr_Configuracoesimagemloginnomeinteiro_N));
         n316ConfiguracoesImagemLoginTamanho = (bool)(Convert.ToBoolean(obj48.gxTpr_Configuracoesimagemlogintamanho_N));
         n317ConfiguracoesImagemLoginBackground = (bool)(Convert.ToBoolean(obj48.gxTpr_Configuracoesimagemloginbackground_N));
         n318ConfiguracoesImagemHeader = (bool)(Convert.ToBoolean(obj48.gxTpr_Configuracoesimagemheader_N));
         n319ConfiguracoesImagemHeaderNome = (bool)(Convert.ToBoolean(obj48.gxTpr_Configuracoesimagemheadernome_N));
         n320ConfiguracoesImagemHeaderExtencao = (bool)(Convert.ToBoolean(obj48.gxTpr_Configuracoesimagemheaderextencao_N));
         n321ConfiguracoesImagemHeaderNomeInteiro = (bool)(Convert.ToBoolean(obj48.gxTpr_Configuracoesimagemheadernomeinteiro_N));
         n322ConfiguracoesImagemHeaderTamanho = (bool)(Convert.ToBoolean(obj48.gxTpr_Configuracoesimagemheadertamanho_N));
         n398ConfiguracoesLayoutProposta = (bool)(Convert.ToBoolean(obj48.gxTpr_Configuracoeslayoutproposta_N));
         n418ConfiguracoesLayoutContratoCorpo = (bool)(Convert.ToBoolean(obj48.gxTpr_Configuracoeslayoutcontratocorpo_N));
         n564ConfigLayoutPromissoriaClinicaEmprestimo = (bool)(Convert.ToBoolean(obj48.gxTpr_Configlayoutpromissoriaclinicaemprestimo_N));
         n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = (bool)(Convert.ToBoolean(obj48.gxTpr_Configlayoutcorpopromissoriaclinicaemprestimo_N));
         n565ConfigLayoutPromissoriaClinicaTaxa = (bool)(Convert.ToBoolean(obj48.gxTpr_Configlayoutpromissoriaclinicataxa_N));
         n568ConfigLayoutCorpoPromissoriaClinicaTaxa = (bool)(Convert.ToBoolean(obj48.gxTpr_Configlayoutcorpopromissoriaclinicataxa_N));
         n566ConfigLayoutPromissoriaPaciente = (bool)(Convert.ToBoolean(obj48.gxTpr_Configlayoutpromissoriapaciente_N));
         n922ConfigLayoutContratoCompraTitulo = (bool)(Convert.ToBoolean(obj48.gxTpr_Configlayoutcontratocompratitulo_N));
         n569ConfigLayoutCorpoPromissoriaPaciente = (bool)(Convert.ToBoolean(obj48.gxTpr_Configlayoutcorpopromissoriapaciente_N));
         n562ConfiguracoesArquivoPFX = (bool)(Convert.ToBoolean(obj48.gxTpr_Configuracoesarquivopfx_N));
         n563ConfiguracaoSenhaPFX = (bool)(Convert.ToBoolean(obj48.gxTpr_Configuracaosenhapfx_N));
         n654ConfiguracoesCategoriaTitulo = (bool)(Convert.ToBoolean(obj48.gxTpr_Configuracoescategoriatitulo_N));
         n765ConfiguracoesSerasaAnotacoesCompletas = (bool)(Convert.ToBoolean(obj48.gxTpr_Configuracoesserasaanotacoescompletas_N));
         n766ConfiguracoesSerasaConsultaDetalhada = (bool)(Convert.ToBoolean(obj48.gxTpr_Configuracoesserasaconsultadetalhada_N));
         n767ConfiguracoesSerasaParticipacaoSocietaria = (bool)(Convert.ToBoolean(obj48.gxTpr_Configuracoesserasaparticipacaosocietaria_N));
         n768ConfiguracoesSerasaRendaEstimada = (bool)(Convert.ToBoolean(obj48.gxTpr_Configuracoesserasarendaestimada_N));
         n769ConfiguracoesSerasaHistoricoPagamento = (bool)(Convert.ToBoolean(obj48.gxTpr_Configuracoesserasahistoricopagamento_N));
         n1013ConfiguracoesCompraTituloTaxaEfetiva = (bool)(Convert.ToBoolean(obj48.gxTpr_Configuracoescompratitulotaxaefetiva_N));
         n1014ConfiguracoesCompraTituloTaxaMora = (bool)(Convert.ToBoolean(obj48.gxTpr_Configuracoescompratitulotaxamora_N));
         n1036ConfiguracoesCompraTituloFator = (bool)(Convert.ToBoolean(obj48.gxTpr_Configuracoescompratitulofator_N));
         n1037ConfiguracoesCompraTituloTarifaTipo = (bool)(Convert.ToBoolean(obj48.gxTpr_Configuracoescompratitulotarifatipo_N));
         n1038ConfiguracoesCompraTituloTarifa = (bool)(Convert.ToBoolean(obj48.gxTpr_Configuracoescompratitulotarifa_N));
         Gx_mode = obj48.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A299ConfiguracoesId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1948( ) ;
         ScanKeyStart1948( ) ;
         if ( RcdFound48 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z299ConfiguracoesId = A299ConfiguracoesId;
         }
         ZM1948( -3) ;
         OnLoadActions1948( ) ;
         AddRow1948( ) ;
         ScanKeyEnd1948( ) ;
         if ( RcdFound48 == 0 )
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
         RowToVars48( bcConfiguracoes, 0) ;
         ScanKeyStart1948( ) ;
         if ( RcdFound48 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z299ConfiguracoesId = A299ConfiguracoesId;
         }
         ZM1948( -3) ;
         OnLoadActions1948( ) ;
         AddRow1948( ) ;
         ScanKeyEnd1948( ) ;
         if ( RcdFound48 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1948( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1948( ) ;
         }
         else
         {
            if ( RcdFound48 == 1 )
            {
               if ( A299ConfiguracoesId != Z299ConfiguracoesId )
               {
                  A299ConfiguracoesId = Z299ConfiguracoesId;
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
                  Update1948( ) ;
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
                  if ( A299ConfiguracoesId != Z299ConfiguracoesId )
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
                        Insert1948( ) ;
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
                        Insert1948( ) ;
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
         RowToVars48( bcConfiguracoes, 1) ;
         SaveImpl( ) ;
         VarsToRow48( bcConfiguracoes) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars48( bcConfiguracoes, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1948( ) ;
         AfterTrn( ) ;
         VarsToRow48( bcConfiguracoes) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow48( bcConfiguracoes) ;
         }
         else
         {
            SdtConfiguracoes auxBC = new SdtConfiguracoes(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A299ConfiguracoesId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcConfiguracoes);
               auxBC.Save();
               bcConfiguracoes.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars48( bcConfiguracoes, 1) ;
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
         RowToVars48( bcConfiguracoes, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1948( ) ;
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
               VarsToRow48( bcConfiguracoes) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow48( bcConfiguracoes) ;
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
         RowToVars48( bcConfiguracoes, 0) ;
         GetKey1948( ) ;
         if ( RcdFound48 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A299ConfiguracoesId != Z299ConfiguracoesId )
            {
               A299ConfiguracoesId = Z299ConfiguracoesId;
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
            if ( A299ConfiguracoesId != Z299ConfiguracoesId )
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
         context.RollbackDataStores("configuracoes_bc",pr_default);
         VarsToRow48( bcConfiguracoes) ;
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
         Gx_mode = bcConfiguracoes.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcConfiguracoes.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcConfiguracoes )
         {
            bcConfiguracoes = (SdtConfiguracoes)(sdt);
            if ( StringUtil.StrCmp(bcConfiguracoes.gxTpr_Mode, "") == 0 )
            {
               bcConfiguracoes.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow48( bcConfiguracoes) ;
            }
            else
            {
               RowToVars48( bcConfiguracoes, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcConfiguracoes.gxTpr_Mode, "") == 0 )
            {
               bcConfiguracoes.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars48( bcConfiguracoes, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtConfiguracoes Configuracoes_BC
      {
         get {
            return bcConfiguracoes ;
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
         pr_default.close(17);
         pr_default.close(18);
         pr_default.close(19);
         pr_default.close(20);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z315ConfiguracoesImagemLoginNomeInteiro = "";
         A315ConfiguracoesImagemLoginNomeInteiro = "";
         Z317ConfiguracoesImagemLoginBackground = "";
         A317ConfiguracoesImagemLoginBackground = "";
         Z319ConfiguracoesImagemHeaderNome = "";
         A319ConfiguracoesImagemHeaderNome = "";
         Z320ConfiguracoesImagemHeaderExtencao = "";
         A320ConfiguracoesImagemHeaderExtencao = "";
         Z321ConfiguracoesImagemHeaderNomeInteiro = "";
         A321ConfiguracoesImagemHeaderNomeInteiro = "";
         Z563ConfiguracaoSenhaPFX = "";
         A563ConfiguracaoSenhaPFX = "";
         Z1037ConfiguracoesCompraTituloTarifaTipo = "";
         A1037ConfiguracoesCompraTituloTarifaTipo = "";
         Z300ConfiguracoesImagemLogin = "";
         A300ConfiguracoesImagemLogin = "";
         Z318ConfiguracoesImagemHeader = "";
         A318ConfiguracoesImagemHeader = "";
         Z562ConfiguracoesArquivoPFX = "";
         A562ConfiguracoesArquivoPFX = "";
         Z312ConfiguracoesImagemLoginExtencao = "";
         A312ConfiguracoesImagemLoginExtencao = "";
         Z313ConfiguracoesImagemLoginNome = "";
         A313ConfiguracoesImagemLoginNome = "";
         Z418ConfiguracoesLayoutContratoCorpo = "";
         A418ConfiguracoesLayoutContratoCorpo = "";
         Z567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = "";
         A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = "";
         Z568ConfigLayoutCorpoPromissoriaClinicaTaxa = "";
         A568ConfigLayoutCorpoPromissoriaClinicaTaxa = "";
         Z569ConfigLayoutCorpoPromissoriaPaciente = "";
         A569ConfigLayoutCorpoPromissoriaPaciente = "";
         BC001910_A299ConfiguracoesId = new int[1] ;
         BC001910_A315ConfiguracoesImagemLoginNomeInteiro = new string[] {""} ;
         BC001910_n315ConfiguracoesImagemLoginNomeInteiro = new bool[] {false} ;
         BC001910_A316ConfiguracoesImagemLoginTamanho = new decimal[1] ;
         BC001910_n316ConfiguracoesImagemLoginTamanho = new bool[] {false} ;
         BC001910_A317ConfiguracoesImagemLoginBackground = new string[] {""} ;
         BC001910_n317ConfiguracoesImagemLoginBackground = new bool[] {false} ;
         BC001910_A319ConfiguracoesImagemHeaderNome = new string[] {""} ;
         BC001910_n319ConfiguracoesImagemHeaderNome = new bool[] {false} ;
         BC001910_A320ConfiguracoesImagemHeaderExtencao = new string[] {""} ;
         BC001910_n320ConfiguracoesImagemHeaderExtencao = new bool[] {false} ;
         BC001910_A321ConfiguracoesImagemHeaderNomeInteiro = new string[] {""} ;
         BC001910_n321ConfiguracoesImagemHeaderNomeInteiro = new bool[] {false} ;
         BC001910_A322ConfiguracoesImagemHeaderTamanho = new decimal[1] ;
         BC001910_n322ConfiguracoesImagemHeaderTamanho = new bool[] {false} ;
         BC001910_A418ConfiguracoesLayoutContratoCorpo = new string[] {""} ;
         BC001910_n418ConfiguracoesLayoutContratoCorpo = new bool[] {false} ;
         BC001910_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = new string[] {""} ;
         BC001910_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = new bool[] {false} ;
         BC001910_A568ConfigLayoutCorpoPromissoriaClinicaTaxa = new string[] {""} ;
         BC001910_n568ConfigLayoutCorpoPromissoriaClinicaTaxa = new bool[] {false} ;
         BC001910_A569ConfigLayoutCorpoPromissoriaPaciente = new string[] {""} ;
         BC001910_n569ConfigLayoutCorpoPromissoriaPaciente = new bool[] {false} ;
         BC001910_A563ConfiguracaoSenhaPFX = new string[] {""} ;
         BC001910_n563ConfiguracaoSenhaPFX = new bool[] {false} ;
         BC001910_A765ConfiguracoesSerasaAnotacoesCompletas = new bool[] {false} ;
         BC001910_n765ConfiguracoesSerasaAnotacoesCompletas = new bool[] {false} ;
         BC001910_A766ConfiguracoesSerasaConsultaDetalhada = new bool[] {false} ;
         BC001910_n766ConfiguracoesSerasaConsultaDetalhada = new bool[] {false} ;
         BC001910_A767ConfiguracoesSerasaParticipacaoSocietaria = new bool[] {false} ;
         BC001910_n767ConfiguracoesSerasaParticipacaoSocietaria = new bool[] {false} ;
         BC001910_A768ConfiguracoesSerasaRendaEstimada = new bool[] {false} ;
         BC001910_n768ConfiguracoesSerasaRendaEstimada = new bool[] {false} ;
         BC001910_A769ConfiguracoesSerasaHistoricoPagamento = new bool[] {false} ;
         BC001910_n769ConfiguracoesSerasaHistoricoPagamento = new bool[] {false} ;
         BC001910_A1013ConfiguracoesCompraTituloTaxaEfetiva = new decimal[1] ;
         BC001910_n1013ConfiguracoesCompraTituloTaxaEfetiva = new bool[] {false} ;
         BC001910_A1014ConfiguracoesCompraTituloTaxaMora = new decimal[1] ;
         BC001910_n1014ConfiguracoesCompraTituloTaxaMora = new bool[] {false} ;
         BC001910_A1036ConfiguracoesCompraTituloFator = new decimal[1] ;
         BC001910_n1036ConfiguracoesCompraTituloFator = new bool[] {false} ;
         BC001910_A1037ConfiguracoesCompraTituloTarifaTipo = new string[] {""} ;
         BC001910_n1037ConfiguracoesCompraTituloTarifaTipo = new bool[] {false} ;
         BC001910_A1038ConfiguracoesCompraTituloTarifa = new decimal[1] ;
         BC001910_n1038ConfiguracoesCompraTituloTarifa = new bool[] {false} ;
         BC001910_A312ConfiguracoesImagemLoginExtencao = new string[] {""} ;
         BC001910_n312ConfiguracoesImagemLoginExtencao = new bool[] {false} ;
         BC001910_A313ConfiguracoesImagemLoginNome = new string[] {""} ;
         BC001910_n313ConfiguracoesImagemLoginNome = new bool[] {false} ;
         BC001910_A398ConfiguracoesLayoutProposta = new short[1] ;
         BC001910_n398ConfiguracoesLayoutProposta = new bool[] {false} ;
         BC001910_A564ConfigLayoutPromissoriaClinicaEmprestimo = new short[1] ;
         BC001910_n564ConfigLayoutPromissoriaClinicaEmprestimo = new bool[] {false} ;
         BC001910_A565ConfigLayoutPromissoriaClinicaTaxa = new short[1] ;
         BC001910_n565ConfigLayoutPromissoriaClinicaTaxa = new bool[] {false} ;
         BC001910_A566ConfigLayoutPromissoriaPaciente = new short[1] ;
         BC001910_n566ConfigLayoutPromissoriaPaciente = new bool[] {false} ;
         BC001910_A922ConfigLayoutContratoCompraTitulo = new short[1] ;
         BC001910_n922ConfigLayoutContratoCompraTitulo = new bool[] {false} ;
         BC001910_A654ConfiguracoesCategoriaTitulo = new int[1] ;
         BC001910_n654ConfiguracoesCategoriaTitulo = new bool[] {false} ;
         BC001910_A300ConfiguracoesImagemLogin = new string[] {""} ;
         BC001910_n300ConfiguracoesImagemLogin = new bool[] {false} ;
         BC001910_A318ConfiguracoesImagemHeader = new string[] {""} ;
         BC001910_n318ConfiguracoesImagemHeader = new bool[] {false} ;
         BC001910_A562ConfiguracoesArquivoPFX = new string[] {""} ;
         BC001910_n562ConfiguracoesArquivoPFX = new bool[] {false} ;
         A300ConfiguracoesImagemLogin_Filetype = "";
         A300ConfiguracoesImagemLogin_Filename = "";
         BC00194_A418ConfiguracoesLayoutContratoCorpo = new string[] {""} ;
         BC00194_n418ConfiguracoesLayoutContratoCorpo = new bool[] {false} ;
         BC00195_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = new string[] {""} ;
         BC00195_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = new bool[] {false} ;
         BC00196_A568ConfigLayoutCorpoPromissoriaClinicaTaxa = new string[] {""} ;
         BC00196_n568ConfigLayoutCorpoPromissoriaClinicaTaxa = new bool[] {false} ;
         BC00197_A569ConfigLayoutCorpoPromissoriaPaciente = new string[] {""} ;
         BC00197_n569ConfigLayoutCorpoPromissoriaPaciente = new bool[] {false} ;
         BC00198_A922ConfigLayoutContratoCompraTitulo = new short[1] ;
         BC00198_n922ConfigLayoutContratoCompraTitulo = new bool[] {false} ;
         BC00199_A654ConfiguracoesCategoriaTitulo = new int[1] ;
         BC00199_n654ConfiguracoesCategoriaTitulo = new bool[] {false} ;
         BC001911_A299ConfiguracoesId = new int[1] ;
         BC00193_A299ConfiguracoesId = new int[1] ;
         BC00193_A315ConfiguracoesImagemLoginNomeInteiro = new string[] {""} ;
         BC00193_n315ConfiguracoesImagemLoginNomeInteiro = new bool[] {false} ;
         BC00193_A316ConfiguracoesImagemLoginTamanho = new decimal[1] ;
         BC00193_n316ConfiguracoesImagemLoginTamanho = new bool[] {false} ;
         BC00193_A317ConfiguracoesImagemLoginBackground = new string[] {""} ;
         BC00193_n317ConfiguracoesImagemLoginBackground = new bool[] {false} ;
         BC00193_A319ConfiguracoesImagemHeaderNome = new string[] {""} ;
         BC00193_n319ConfiguracoesImagemHeaderNome = new bool[] {false} ;
         BC00193_A320ConfiguracoesImagemHeaderExtencao = new string[] {""} ;
         BC00193_n320ConfiguracoesImagemHeaderExtencao = new bool[] {false} ;
         BC00193_A321ConfiguracoesImagemHeaderNomeInteiro = new string[] {""} ;
         BC00193_n321ConfiguracoesImagemHeaderNomeInteiro = new bool[] {false} ;
         BC00193_A322ConfiguracoesImagemHeaderTamanho = new decimal[1] ;
         BC00193_n322ConfiguracoesImagemHeaderTamanho = new bool[] {false} ;
         BC00193_A563ConfiguracaoSenhaPFX = new string[] {""} ;
         BC00193_n563ConfiguracaoSenhaPFX = new bool[] {false} ;
         BC00193_A765ConfiguracoesSerasaAnotacoesCompletas = new bool[] {false} ;
         BC00193_n765ConfiguracoesSerasaAnotacoesCompletas = new bool[] {false} ;
         BC00193_A766ConfiguracoesSerasaConsultaDetalhada = new bool[] {false} ;
         BC00193_n766ConfiguracoesSerasaConsultaDetalhada = new bool[] {false} ;
         BC00193_A767ConfiguracoesSerasaParticipacaoSocietaria = new bool[] {false} ;
         BC00193_n767ConfiguracoesSerasaParticipacaoSocietaria = new bool[] {false} ;
         BC00193_A768ConfiguracoesSerasaRendaEstimada = new bool[] {false} ;
         BC00193_n768ConfiguracoesSerasaRendaEstimada = new bool[] {false} ;
         BC00193_A769ConfiguracoesSerasaHistoricoPagamento = new bool[] {false} ;
         BC00193_n769ConfiguracoesSerasaHistoricoPagamento = new bool[] {false} ;
         BC00193_A1013ConfiguracoesCompraTituloTaxaEfetiva = new decimal[1] ;
         BC00193_n1013ConfiguracoesCompraTituloTaxaEfetiva = new bool[] {false} ;
         BC00193_A1014ConfiguracoesCompraTituloTaxaMora = new decimal[1] ;
         BC00193_n1014ConfiguracoesCompraTituloTaxaMora = new bool[] {false} ;
         BC00193_A1036ConfiguracoesCompraTituloFator = new decimal[1] ;
         BC00193_n1036ConfiguracoesCompraTituloFator = new bool[] {false} ;
         BC00193_A1037ConfiguracoesCompraTituloTarifaTipo = new string[] {""} ;
         BC00193_n1037ConfiguracoesCompraTituloTarifaTipo = new bool[] {false} ;
         BC00193_A1038ConfiguracoesCompraTituloTarifa = new decimal[1] ;
         BC00193_n1038ConfiguracoesCompraTituloTarifa = new bool[] {false} ;
         BC00193_A312ConfiguracoesImagemLoginExtencao = new string[] {""} ;
         BC00193_n312ConfiguracoesImagemLoginExtencao = new bool[] {false} ;
         BC00193_A313ConfiguracoesImagemLoginNome = new string[] {""} ;
         BC00193_n313ConfiguracoesImagemLoginNome = new bool[] {false} ;
         BC00193_A398ConfiguracoesLayoutProposta = new short[1] ;
         BC00193_n398ConfiguracoesLayoutProposta = new bool[] {false} ;
         BC00193_A564ConfigLayoutPromissoriaClinicaEmprestimo = new short[1] ;
         BC00193_n564ConfigLayoutPromissoriaClinicaEmprestimo = new bool[] {false} ;
         BC00193_A565ConfigLayoutPromissoriaClinicaTaxa = new short[1] ;
         BC00193_n565ConfigLayoutPromissoriaClinicaTaxa = new bool[] {false} ;
         BC00193_A566ConfigLayoutPromissoriaPaciente = new short[1] ;
         BC00193_n566ConfigLayoutPromissoriaPaciente = new bool[] {false} ;
         BC00193_A922ConfigLayoutContratoCompraTitulo = new short[1] ;
         BC00193_n922ConfigLayoutContratoCompraTitulo = new bool[] {false} ;
         BC00193_A654ConfiguracoesCategoriaTitulo = new int[1] ;
         BC00193_n654ConfiguracoesCategoriaTitulo = new bool[] {false} ;
         BC00193_A300ConfiguracoesImagemLogin = new string[] {""} ;
         BC00193_n300ConfiguracoesImagemLogin = new bool[] {false} ;
         BC00193_A318ConfiguracoesImagemHeader = new string[] {""} ;
         BC00193_n318ConfiguracoesImagemHeader = new bool[] {false} ;
         BC00193_A562ConfiguracoesArquivoPFX = new string[] {""} ;
         BC00193_n562ConfiguracoesArquivoPFX = new bool[] {false} ;
         sMode48 = "";
         BC00192_A299ConfiguracoesId = new int[1] ;
         BC00192_A315ConfiguracoesImagemLoginNomeInteiro = new string[] {""} ;
         BC00192_n315ConfiguracoesImagemLoginNomeInteiro = new bool[] {false} ;
         BC00192_A316ConfiguracoesImagemLoginTamanho = new decimal[1] ;
         BC00192_n316ConfiguracoesImagemLoginTamanho = new bool[] {false} ;
         BC00192_A317ConfiguracoesImagemLoginBackground = new string[] {""} ;
         BC00192_n317ConfiguracoesImagemLoginBackground = new bool[] {false} ;
         BC00192_A319ConfiguracoesImagemHeaderNome = new string[] {""} ;
         BC00192_n319ConfiguracoesImagemHeaderNome = new bool[] {false} ;
         BC00192_A320ConfiguracoesImagemHeaderExtencao = new string[] {""} ;
         BC00192_n320ConfiguracoesImagemHeaderExtencao = new bool[] {false} ;
         BC00192_A321ConfiguracoesImagemHeaderNomeInteiro = new string[] {""} ;
         BC00192_n321ConfiguracoesImagemHeaderNomeInteiro = new bool[] {false} ;
         BC00192_A322ConfiguracoesImagemHeaderTamanho = new decimal[1] ;
         BC00192_n322ConfiguracoesImagemHeaderTamanho = new bool[] {false} ;
         BC00192_A563ConfiguracaoSenhaPFX = new string[] {""} ;
         BC00192_n563ConfiguracaoSenhaPFX = new bool[] {false} ;
         BC00192_A765ConfiguracoesSerasaAnotacoesCompletas = new bool[] {false} ;
         BC00192_n765ConfiguracoesSerasaAnotacoesCompletas = new bool[] {false} ;
         BC00192_A766ConfiguracoesSerasaConsultaDetalhada = new bool[] {false} ;
         BC00192_n766ConfiguracoesSerasaConsultaDetalhada = new bool[] {false} ;
         BC00192_A767ConfiguracoesSerasaParticipacaoSocietaria = new bool[] {false} ;
         BC00192_n767ConfiguracoesSerasaParticipacaoSocietaria = new bool[] {false} ;
         BC00192_A768ConfiguracoesSerasaRendaEstimada = new bool[] {false} ;
         BC00192_n768ConfiguracoesSerasaRendaEstimada = new bool[] {false} ;
         BC00192_A769ConfiguracoesSerasaHistoricoPagamento = new bool[] {false} ;
         BC00192_n769ConfiguracoesSerasaHistoricoPagamento = new bool[] {false} ;
         BC00192_A1013ConfiguracoesCompraTituloTaxaEfetiva = new decimal[1] ;
         BC00192_n1013ConfiguracoesCompraTituloTaxaEfetiva = new bool[] {false} ;
         BC00192_A1014ConfiguracoesCompraTituloTaxaMora = new decimal[1] ;
         BC00192_n1014ConfiguracoesCompraTituloTaxaMora = new bool[] {false} ;
         BC00192_A1036ConfiguracoesCompraTituloFator = new decimal[1] ;
         BC00192_n1036ConfiguracoesCompraTituloFator = new bool[] {false} ;
         BC00192_A1037ConfiguracoesCompraTituloTarifaTipo = new string[] {""} ;
         BC00192_n1037ConfiguracoesCompraTituloTarifaTipo = new bool[] {false} ;
         BC00192_A1038ConfiguracoesCompraTituloTarifa = new decimal[1] ;
         BC00192_n1038ConfiguracoesCompraTituloTarifa = new bool[] {false} ;
         BC00192_A312ConfiguracoesImagemLoginExtencao = new string[] {""} ;
         BC00192_n312ConfiguracoesImagemLoginExtencao = new bool[] {false} ;
         BC00192_A313ConfiguracoesImagemLoginNome = new string[] {""} ;
         BC00192_n313ConfiguracoesImagemLoginNome = new bool[] {false} ;
         BC00192_A398ConfiguracoesLayoutProposta = new short[1] ;
         BC00192_n398ConfiguracoesLayoutProposta = new bool[] {false} ;
         BC00192_A564ConfigLayoutPromissoriaClinicaEmprestimo = new short[1] ;
         BC00192_n564ConfigLayoutPromissoriaClinicaEmprestimo = new bool[] {false} ;
         BC00192_A565ConfigLayoutPromissoriaClinicaTaxa = new short[1] ;
         BC00192_n565ConfigLayoutPromissoriaClinicaTaxa = new bool[] {false} ;
         BC00192_A566ConfigLayoutPromissoriaPaciente = new short[1] ;
         BC00192_n566ConfigLayoutPromissoriaPaciente = new bool[] {false} ;
         BC00192_A922ConfigLayoutContratoCompraTitulo = new short[1] ;
         BC00192_n922ConfigLayoutContratoCompraTitulo = new bool[] {false} ;
         BC00192_A654ConfiguracoesCategoriaTitulo = new int[1] ;
         BC00192_n654ConfiguracoesCategoriaTitulo = new bool[] {false} ;
         BC00192_A300ConfiguracoesImagemLogin = new string[] {""} ;
         BC00192_n300ConfiguracoesImagemLogin = new bool[] {false} ;
         BC00192_A318ConfiguracoesImagemHeader = new string[] {""} ;
         BC00192_n318ConfiguracoesImagemHeader = new bool[] {false} ;
         BC00192_A562ConfiguracoesArquivoPFX = new string[] {""} ;
         BC00192_n562ConfiguracoesArquivoPFX = new bool[] {false} ;
         BC001913_A299ConfiguracoesId = new int[1] ;
         BC001919_A418ConfiguracoesLayoutContratoCorpo = new string[] {""} ;
         BC001919_n418ConfiguracoesLayoutContratoCorpo = new bool[] {false} ;
         BC001920_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = new string[] {""} ;
         BC001920_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = new bool[] {false} ;
         BC001921_A568ConfigLayoutCorpoPromissoriaClinicaTaxa = new string[] {""} ;
         BC001921_n568ConfigLayoutCorpoPromissoriaClinicaTaxa = new bool[] {false} ;
         BC001922_A569ConfigLayoutCorpoPromissoriaPaciente = new string[] {""} ;
         BC001922_n569ConfigLayoutCorpoPromissoriaPaciente = new bool[] {false} ;
         BC001923_A299ConfiguracoesId = new int[1] ;
         BC001923_A315ConfiguracoesImagemLoginNomeInteiro = new string[] {""} ;
         BC001923_n315ConfiguracoesImagemLoginNomeInteiro = new bool[] {false} ;
         BC001923_A316ConfiguracoesImagemLoginTamanho = new decimal[1] ;
         BC001923_n316ConfiguracoesImagemLoginTamanho = new bool[] {false} ;
         BC001923_A317ConfiguracoesImagemLoginBackground = new string[] {""} ;
         BC001923_n317ConfiguracoesImagemLoginBackground = new bool[] {false} ;
         BC001923_A319ConfiguracoesImagemHeaderNome = new string[] {""} ;
         BC001923_n319ConfiguracoesImagemHeaderNome = new bool[] {false} ;
         BC001923_A320ConfiguracoesImagemHeaderExtencao = new string[] {""} ;
         BC001923_n320ConfiguracoesImagemHeaderExtencao = new bool[] {false} ;
         BC001923_A321ConfiguracoesImagemHeaderNomeInteiro = new string[] {""} ;
         BC001923_n321ConfiguracoesImagemHeaderNomeInteiro = new bool[] {false} ;
         BC001923_A322ConfiguracoesImagemHeaderTamanho = new decimal[1] ;
         BC001923_n322ConfiguracoesImagemHeaderTamanho = new bool[] {false} ;
         BC001923_A418ConfiguracoesLayoutContratoCorpo = new string[] {""} ;
         BC001923_n418ConfiguracoesLayoutContratoCorpo = new bool[] {false} ;
         BC001923_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = new string[] {""} ;
         BC001923_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo = new bool[] {false} ;
         BC001923_A568ConfigLayoutCorpoPromissoriaClinicaTaxa = new string[] {""} ;
         BC001923_n568ConfigLayoutCorpoPromissoriaClinicaTaxa = new bool[] {false} ;
         BC001923_A569ConfigLayoutCorpoPromissoriaPaciente = new string[] {""} ;
         BC001923_n569ConfigLayoutCorpoPromissoriaPaciente = new bool[] {false} ;
         BC001923_A563ConfiguracaoSenhaPFX = new string[] {""} ;
         BC001923_n563ConfiguracaoSenhaPFX = new bool[] {false} ;
         BC001923_A765ConfiguracoesSerasaAnotacoesCompletas = new bool[] {false} ;
         BC001923_n765ConfiguracoesSerasaAnotacoesCompletas = new bool[] {false} ;
         BC001923_A766ConfiguracoesSerasaConsultaDetalhada = new bool[] {false} ;
         BC001923_n766ConfiguracoesSerasaConsultaDetalhada = new bool[] {false} ;
         BC001923_A767ConfiguracoesSerasaParticipacaoSocietaria = new bool[] {false} ;
         BC001923_n767ConfiguracoesSerasaParticipacaoSocietaria = new bool[] {false} ;
         BC001923_A768ConfiguracoesSerasaRendaEstimada = new bool[] {false} ;
         BC001923_n768ConfiguracoesSerasaRendaEstimada = new bool[] {false} ;
         BC001923_A769ConfiguracoesSerasaHistoricoPagamento = new bool[] {false} ;
         BC001923_n769ConfiguracoesSerasaHistoricoPagamento = new bool[] {false} ;
         BC001923_A1013ConfiguracoesCompraTituloTaxaEfetiva = new decimal[1] ;
         BC001923_n1013ConfiguracoesCompraTituloTaxaEfetiva = new bool[] {false} ;
         BC001923_A1014ConfiguracoesCompraTituloTaxaMora = new decimal[1] ;
         BC001923_n1014ConfiguracoesCompraTituloTaxaMora = new bool[] {false} ;
         BC001923_A1036ConfiguracoesCompraTituloFator = new decimal[1] ;
         BC001923_n1036ConfiguracoesCompraTituloFator = new bool[] {false} ;
         BC001923_A1037ConfiguracoesCompraTituloTarifaTipo = new string[] {""} ;
         BC001923_n1037ConfiguracoesCompraTituloTarifaTipo = new bool[] {false} ;
         BC001923_A1038ConfiguracoesCompraTituloTarifa = new decimal[1] ;
         BC001923_n1038ConfiguracoesCompraTituloTarifa = new bool[] {false} ;
         BC001923_A312ConfiguracoesImagemLoginExtencao = new string[] {""} ;
         BC001923_n312ConfiguracoesImagemLoginExtencao = new bool[] {false} ;
         BC001923_A313ConfiguracoesImagemLoginNome = new string[] {""} ;
         BC001923_n313ConfiguracoesImagemLoginNome = new bool[] {false} ;
         BC001923_A398ConfiguracoesLayoutProposta = new short[1] ;
         BC001923_n398ConfiguracoesLayoutProposta = new bool[] {false} ;
         BC001923_A564ConfigLayoutPromissoriaClinicaEmprestimo = new short[1] ;
         BC001923_n564ConfigLayoutPromissoriaClinicaEmprestimo = new bool[] {false} ;
         BC001923_A565ConfigLayoutPromissoriaClinicaTaxa = new short[1] ;
         BC001923_n565ConfigLayoutPromissoriaClinicaTaxa = new bool[] {false} ;
         BC001923_A566ConfigLayoutPromissoriaPaciente = new short[1] ;
         BC001923_n566ConfigLayoutPromissoriaPaciente = new bool[] {false} ;
         BC001923_A922ConfigLayoutContratoCompraTitulo = new short[1] ;
         BC001923_n922ConfigLayoutContratoCompraTitulo = new bool[] {false} ;
         BC001923_A654ConfiguracoesCategoriaTitulo = new int[1] ;
         BC001923_n654ConfiguracoesCategoriaTitulo = new bool[] {false} ;
         BC001923_A300ConfiguracoesImagemLogin = new string[] {""} ;
         BC001923_n300ConfiguracoesImagemLogin = new bool[] {false} ;
         BC001923_A318ConfiguracoesImagemHeader = new string[] {""} ;
         BC001923_n318ConfiguracoesImagemHeader = new bool[] {false} ;
         BC001923_A562ConfiguracoesArquivoPFX = new string[] {""} ;
         BC001923_n562ConfiguracoesArquivoPFX = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracoes_bc__default(),
            new Object[][] {
                new Object[] {
               BC00192_A299ConfiguracoesId, BC00192_A315ConfiguracoesImagemLoginNomeInteiro, BC00192_n315ConfiguracoesImagemLoginNomeInteiro, BC00192_A316ConfiguracoesImagemLoginTamanho, BC00192_n316ConfiguracoesImagemLoginTamanho, BC00192_A317ConfiguracoesImagemLoginBackground, BC00192_n317ConfiguracoesImagemLoginBackground, BC00192_A319ConfiguracoesImagemHeaderNome, BC00192_n319ConfiguracoesImagemHeaderNome, BC00192_A320ConfiguracoesImagemHeaderExtencao,
               BC00192_n320ConfiguracoesImagemHeaderExtencao, BC00192_A321ConfiguracoesImagemHeaderNomeInteiro, BC00192_n321ConfiguracoesImagemHeaderNomeInteiro, BC00192_A322ConfiguracoesImagemHeaderTamanho, BC00192_n322ConfiguracoesImagemHeaderTamanho, BC00192_A563ConfiguracaoSenhaPFX, BC00192_n563ConfiguracaoSenhaPFX, BC00192_A765ConfiguracoesSerasaAnotacoesCompletas, BC00192_n765ConfiguracoesSerasaAnotacoesCompletas, BC00192_A766ConfiguracoesSerasaConsultaDetalhada,
               BC00192_n766ConfiguracoesSerasaConsultaDetalhada, BC00192_A767ConfiguracoesSerasaParticipacaoSocietaria, BC00192_n767ConfiguracoesSerasaParticipacaoSocietaria, BC00192_A768ConfiguracoesSerasaRendaEstimada, BC00192_n768ConfiguracoesSerasaRendaEstimada, BC00192_A769ConfiguracoesSerasaHistoricoPagamento, BC00192_n769ConfiguracoesSerasaHistoricoPagamento, BC00192_A1013ConfiguracoesCompraTituloTaxaEfetiva, BC00192_n1013ConfiguracoesCompraTituloTaxaEfetiva, BC00192_A1014ConfiguracoesCompraTituloTaxaMora,
               BC00192_n1014ConfiguracoesCompraTituloTaxaMora, BC00192_A1036ConfiguracoesCompraTituloFator, BC00192_n1036ConfiguracoesCompraTituloFator, BC00192_A1037ConfiguracoesCompraTituloTarifaTipo, BC00192_n1037ConfiguracoesCompraTituloTarifaTipo, BC00192_A1038ConfiguracoesCompraTituloTarifa, BC00192_n1038ConfiguracoesCompraTituloTarifa, BC00192_A312ConfiguracoesImagemLoginExtencao, BC00192_n312ConfiguracoesImagemLoginExtencao, BC00192_A313ConfiguracoesImagemLoginNome,
               BC00192_n313ConfiguracoesImagemLoginNome, BC00192_A398ConfiguracoesLayoutProposta, BC00192_n398ConfiguracoesLayoutProposta, BC00192_A564ConfigLayoutPromissoriaClinicaEmprestimo, BC00192_n564ConfigLayoutPromissoriaClinicaEmprestimo, BC00192_A565ConfigLayoutPromissoriaClinicaTaxa, BC00192_n565ConfigLayoutPromissoriaClinicaTaxa, BC00192_A566ConfigLayoutPromissoriaPaciente, BC00192_n566ConfigLayoutPromissoriaPaciente, BC00192_A922ConfigLayoutContratoCompraTitulo,
               BC00192_n922ConfigLayoutContratoCompraTitulo, BC00192_A654ConfiguracoesCategoriaTitulo, BC00192_n654ConfiguracoesCategoriaTitulo, BC00192_A300ConfiguracoesImagemLogin, BC00192_n300ConfiguracoesImagemLogin, BC00192_A318ConfiguracoesImagemHeader, BC00192_n318ConfiguracoesImagemHeader, BC00192_A562ConfiguracoesArquivoPFX, BC00192_n562ConfiguracoesArquivoPFX
               }
               , new Object[] {
               BC00193_A299ConfiguracoesId, BC00193_A315ConfiguracoesImagemLoginNomeInteiro, BC00193_n315ConfiguracoesImagemLoginNomeInteiro, BC00193_A316ConfiguracoesImagemLoginTamanho, BC00193_n316ConfiguracoesImagemLoginTamanho, BC00193_A317ConfiguracoesImagemLoginBackground, BC00193_n317ConfiguracoesImagemLoginBackground, BC00193_A319ConfiguracoesImagemHeaderNome, BC00193_n319ConfiguracoesImagemHeaderNome, BC00193_A320ConfiguracoesImagemHeaderExtencao,
               BC00193_n320ConfiguracoesImagemHeaderExtencao, BC00193_A321ConfiguracoesImagemHeaderNomeInteiro, BC00193_n321ConfiguracoesImagemHeaderNomeInteiro, BC00193_A322ConfiguracoesImagemHeaderTamanho, BC00193_n322ConfiguracoesImagemHeaderTamanho, BC00193_A563ConfiguracaoSenhaPFX, BC00193_n563ConfiguracaoSenhaPFX, BC00193_A765ConfiguracoesSerasaAnotacoesCompletas, BC00193_n765ConfiguracoesSerasaAnotacoesCompletas, BC00193_A766ConfiguracoesSerasaConsultaDetalhada,
               BC00193_n766ConfiguracoesSerasaConsultaDetalhada, BC00193_A767ConfiguracoesSerasaParticipacaoSocietaria, BC00193_n767ConfiguracoesSerasaParticipacaoSocietaria, BC00193_A768ConfiguracoesSerasaRendaEstimada, BC00193_n768ConfiguracoesSerasaRendaEstimada, BC00193_A769ConfiguracoesSerasaHistoricoPagamento, BC00193_n769ConfiguracoesSerasaHistoricoPagamento, BC00193_A1013ConfiguracoesCompraTituloTaxaEfetiva, BC00193_n1013ConfiguracoesCompraTituloTaxaEfetiva, BC00193_A1014ConfiguracoesCompraTituloTaxaMora,
               BC00193_n1014ConfiguracoesCompraTituloTaxaMora, BC00193_A1036ConfiguracoesCompraTituloFator, BC00193_n1036ConfiguracoesCompraTituloFator, BC00193_A1037ConfiguracoesCompraTituloTarifaTipo, BC00193_n1037ConfiguracoesCompraTituloTarifaTipo, BC00193_A1038ConfiguracoesCompraTituloTarifa, BC00193_n1038ConfiguracoesCompraTituloTarifa, BC00193_A312ConfiguracoesImagemLoginExtencao, BC00193_n312ConfiguracoesImagemLoginExtencao, BC00193_A313ConfiguracoesImagemLoginNome,
               BC00193_n313ConfiguracoesImagemLoginNome, BC00193_A398ConfiguracoesLayoutProposta, BC00193_n398ConfiguracoesLayoutProposta, BC00193_A564ConfigLayoutPromissoriaClinicaEmprestimo, BC00193_n564ConfigLayoutPromissoriaClinicaEmprestimo, BC00193_A565ConfigLayoutPromissoriaClinicaTaxa, BC00193_n565ConfigLayoutPromissoriaClinicaTaxa, BC00193_A566ConfigLayoutPromissoriaPaciente, BC00193_n566ConfigLayoutPromissoriaPaciente, BC00193_A922ConfigLayoutContratoCompraTitulo,
               BC00193_n922ConfigLayoutContratoCompraTitulo, BC00193_A654ConfiguracoesCategoriaTitulo, BC00193_n654ConfiguracoesCategoriaTitulo, BC00193_A300ConfiguracoesImagemLogin, BC00193_n300ConfiguracoesImagemLogin, BC00193_A318ConfiguracoesImagemHeader, BC00193_n318ConfiguracoesImagemHeader, BC00193_A562ConfiguracoesArquivoPFX, BC00193_n562ConfiguracoesArquivoPFX
               }
               , new Object[] {
               BC00194_A418ConfiguracoesLayoutContratoCorpo, BC00194_n418ConfiguracoesLayoutContratoCorpo
               }
               , new Object[] {
               BC00195_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo, BC00195_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo
               }
               , new Object[] {
               BC00196_A568ConfigLayoutCorpoPromissoriaClinicaTaxa, BC00196_n568ConfigLayoutCorpoPromissoriaClinicaTaxa
               }
               , new Object[] {
               BC00197_A569ConfigLayoutCorpoPromissoriaPaciente, BC00197_n569ConfigLayoutCorpoPromissoriaPaciente
               }
               , new Object[] {
               BC00198_A922ConfigLayoutContratoCompraTitulo
               }
               , new Object[] {
               BC00199_A654ConfiguracoesCategoriaTitulo
               }
               , new Object[] {
               BC001910_A299ConfiguracoesId, BC001910_A315ConfiguracoesImagemLoginNomeInteiro, BC001910_n315ConfiguracoesImagemLoginNomeInteiro, BC001910_A316ConfiguracoesImagemLoginTamanho, BC001910_n316ConfiguracoesImagemLoginTamanho, BC001910_A317ConfiguracoesImagemLoginBackground, BC001910_n317ConfiguracoesImagemLoginBackground, BC001910_A319ConfiguracoesImagemHeaderNome, BC001910_n319ConfiguracoesImagemHeaderNome, BC001910_A320ConfiguracoesImagemHeaderExtencao,
               BC001910_n320ConfiguracoesImagemHeaderExtencao, BC001910_A321ConfiguracoesImagemHeaderNomeInteiro, BC001910_n321ConfiguracoesImagemHeaderNomeInteiro, BC001910_A322ConfiguracoesImagemHeaderTamanho, BC001910_n322ConfiguracoesImagemHeaderTamanho, BC001910_A418ConfiguracoesLayoutContratoCorpo, BC001910_n418ConfiguracoesLayoutContratoCorpo, BC001910_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo, BC001910_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo, BC001910_A568ConfigLayoutCorpoPromissoriaClinicaTaxa,
               BC001910_n568ConfigLayoutCorpoPromissoriaClinicaTaxa, BC001910_A569ConfigLayoutCorpoPromissoriaPaciente, BC001910_n569ConfigLayoutCorpoPromissoriaPaciente, BC001910_A563ConfiguracaoSenhaPFX, BC001910_n563ConfiguracaoSenhaPFX, BC001910_A765ConfiguracoesSerasaAnotacoesCompletas, BC001910_n765ConfiguracoesSerasaAnotacoesCompletas, BC001910_A766ConfiguracoesSerasaConsultaDetalhada, BC001910_n766ConfiguracoesSerasaConsultaDetalhada, BC001910_A767ConfiguracoesSerasaParticipacaoSocietaria,
               BC001910_n767ConfiguracoesSerasaParticipacaoSocietaria, BC001910_A768ConfiguracoesSerasaRendaEstimada, BC001910_n768ConfiguracoesSerasaRendaEstimada, BC001910_A769ConfiguracoesSerasaHistoricoPagamento, BC001910_n769ConfiguracoesSerasaHistoricoPagamento, BC001910_A1013ConfiguracoesCompraTituloTaxaEfetiva, BC001910_n1013ConfiguracoesCompraTituloTaxaEfetiva, BC001910_A1014ConfiguracoesCompraTituloTaxaMora, BC001910_n1014ConfiguracoesCompraTituloTaxaMora, BC001910_A1036ConfiguracoesCompraTituloFator,
               BC001910_n1036ConfiguracoesCompraTituloFator, BC001910_A1037ConfiguracoesCompraTituloTarifaTipo, BC001910_n1037ConfiguracoesCompraTituloTarifaTipo, BC001910_A1038ConfiguracoesCompraTituloTarifa, BC001910_n1038ConfiguracoesCompraTituloTarifa, BC001910_A312ConfiguracoesImagemLoginExtencao, BC001910_n312ConfiguracoesImagemLoginExtencao, BC001910_A313ConfiguracoesImagemLoginNome, BC001910_n313ConfiguracoesImagemLoginNome, BC001910_A398ConfiguracoesLayoutProposta,
               BC001910_n398ConfiguracoesLayoutProposta, BC001910_A564ConfigLayoutPromissoriaClinicaEmprestimo, BC001910_n564ConfigLayoutPromissoriaClinicaEmprestimo, BC001910_A565ConfigLayoutPromissoriaClinicaTaxa, BC001910_n565ConfigLayoutPromissoriaClinicaTaxa, BC001910_A566ConfigLayoutPromissoriaPaciente, BC001910_n566ConfigLayoutPromissoriaPaciente, BC001910_A922ConfigLayoutContratoCompraTitulo, BC001910_n922ConfigLayoutContratoCompraTitulo, BC001910_A654ConfiguracoesCategoriaTitulo,
               BC001910_n654ConfiguracoesCategoriaTitulo, BC001910_A300ConfiguracoesImagemLogin, BC001910_n300ConfiguracoesImagemLogin, BC001910_A318ConfiguracoesImagemHeader, BC001910_n318ConfiguracoesImagemHeader, BC001910_A562ConfiguracoesArquivoPFX, BC001910_n562ConfiguracoesArquivoPFX
               }
               , new Object[] {
               BC001911_A299ConfiguracoesId
               }
               , new Object[] {
               }
               , new Object[] {
               BC001913_A299ConfiguracoesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001919_A418ConfiguracoesLayoutContratoCorpo, BC001919_n418ConfiguracoesLayoutContratoCorpo
               }
               , new Object[] {
               BC001920_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo, BC001920_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo
               }
               , new Object[] {
               BC001921_A568ConfigLayoutCorpoPromissoriaClinicaTaxa, BC001921_n568ConfigLayoutCorpoPromissoriaClinicaTaxa
               }
               , new Object[] {
               BC001922_A569ConfigLayoutCorpoPromissoriaPaciente, BC001922_n569ConfigLayoutCorpoPromissoriaPaciente
               }
               , new Object[] {
               BC001923_A299ConfiguracoesId, BC001923_A315ConfiguracoesImagemLoginNomeInteiro, BC001923_n315ConfiguracoesImagemLoginNomeInteiro, BC001923_A316ConfiguracoesImagemLoginTamanho, BC001923_n316ConfiguracoesImagemLoginTamanho, BC001923_A317ConfiguracoesImagemLoginBackground, BC001923_n317ConfiguracoesImagemLoginBackground, BC001923_A319ConfiguracoesImagemHeaderNome, BC001923_n319ConfiguracoesImagemHeaderNome, BC001923_A320ConfiguracoesImagemHeaderExtencao,
               BC001923_n320ConfiguracoesImagemHeaderExtencao, BC001923_A321ConfiguracoesImagemHeaderNomeInteiro, BC001923_n321ConfiguracoesImagemHeaderNomeInteiro, BC001923_A322ConfiguracoesImagemHeaderTamanho, BC001923_n322ConfiguracoesImagemHeaderTamanho, BC001923_A418ConfiguracoesLayoutContratoCorpo, BC001923_n418ConfiguracoesLayoutContratoCorpo, BC001923_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo, BC001923_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo, BC001923_A568ConfigLayoutCorpoPromissoriaClinicaTaxa,
               BC001923_n568ConfigLayoutCorpoPromissoriaClinicaTaxa, BC001923_A569ConfigLayoutCorpoPromissoriaPaciente, BC001923_n569ConfigLayoutCorpoPromissoriaPaciente, BC001923_A563ConfiguracaoSenhaPFX, BC001923_n563ConfiguracaoSenhaPFX, BC001923_A765ConfiguracoesSerasaAnotacoesCompletas, BC001923_n765ConfiguracoesSerasaAnotacoesCompletas, BC001923_A766ConfiguracoesSerasaConsultaDetalhada, BC001923_n766ConfiguracoesSerasaConsultaDetalhada, BC001923_A767ConfiguracoesSerasaParticipacaoSocietaria,
               BC001923_n767ConfiguracoesSerasaParticipacaoSocietaria, BC001923_A768ConfiguracoesSerasaRendaEstimada, BC001923_n768ConfiguracoesSerasaRendaEstimada, BC001923_A769ConfiguracoesSerasaHistoricoPagamento, BC001923_n769ConfiguracoesSerasaHistoricoPagamento, BC001923_A1013ConfiguracoesCompraTituloTaxaEfetiva, BC001923_n1013ConfiguracoesCompraTituloTaxaEfetiva, BC001923_A1014ConfiguracoesCompraTituloTaxaMora, BC001923_n1014ConfiguracoesCompraTituloTaxaMora, BC001923_A1036ConfiguracoesCompraTituloFator,
               BC001923_n1036ConfiguracoesCompraTituloFator, BC001923_A1037ConfiguracoesCompraTituloTarifaTipo, BC001923_n1037ConfiguracoesCompraTituloTarifaTipo, BC001923_A1038ConfiguracoesCompraTituloTarifa, BC001923_n1038ConfiguracoesCompraTituloTarifa, BC001923_A312ConfiguracoesImagemLoginExtencao, BC001923_n312ConfiguracoesImagemLoginExtencao, BC001923_A313ConfiguracoesImagemLoginNome, BC001923_n313ConfiguracoesImagemLoginNome, BC001923_A398ConfiguracoesLayoutProposta,
               BC001923_n398ConfiguracoesLayoutProposta, BC001923_A564ConfigLayoutPromissoriaClinicaEmprestimo, BC001923_n564ConfigLayoutPromissoriaClinicaEmprestimo, BC001923_A565ConfigLayoutPromissoriaClinicaTaxa, BC001923_n565ConfigLayoutPromissoriaClinicaTaxa, BC001923_A566ConfigLayoutPromissoriaPaciente, BC001923_n566ConfigLayoutPromissoriaPaciente, BC001923_A922ConfigLayoutContratoCompraTitulo, BC001923_n922ConfigLayoutContratoCompraTitulo, BC001923_A654ConfiguracoesCategoriaTitulo,
               BC001923_n654ConfiguracoesCategoriaTitulo, BC001923_A300ConfiguracoesImagemLogin, BC001923_n300ConfiguracoesImagemLogin, BC001923_A318ConfiguracoesImagemHeader, BC001923_n318ConfiguracoesImagemHeader, BC001923_A562ConfiguracoesArquivoPFX, BC001923_n562ConfiguracoesArquivoPFX
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z398ConfiguracoesLayoutProposta ;
      private short A398ConfiguracoesLayoutProposta ;
      private short Z564ConfigLayoutPromissoriaClinicaEmprestimo ;
      private short A564ConfigLayoutPromissoriaClinicaEmprestimo ;
      private short Z565ConfigLayoutPromissoriaClinicaTaxa ;
      private short A565ConfigLayoutPromissoriaClinicaTaxa ;
      private short Z566ConfigLayoutPromissoriaPaciente ;
      private short A566ConfigLayoutPromissoriaPaciente ;
      private short Z922ConfigLayoutContratoCompraTitulo ;
      private short A922ConfigLayoutContratoCompraTitulo ;
      private short RcdFound48 ;
      private int trnEnded ;
      private int Z299ConfiguracoesId ;
      private int A299ConfiguracoesId ;
      private int Z654ConfiguracoesCategoriaTitulo ;
      private int A654ConfiguracoesCategoriaTitulo ;
      private decimal Z316ConfiguracoesImagemLoginTamanho ;
      private decimal A316ConfiguracoesImagemLoginTamanho ;
      private decimal Z322ConfiguracoesImagemHeaderTamanho ;
      private decimal A322ConfiguracoesImagemHeaderTamanho ;
      private decimal Z1013ConfiguracoesCompraTituloTaxaEfetiva ;
      private decimal A1013ConfiguracoesCompraTituloTaxaEfetiva ;
      private decimal Z1014ConfiguracoesCompraTituloTaxaMora ;
      private decimal A1014ConfiguracoesCompraTituloTaxaMora ;
      private decimal Z1036ConfiguracoesCompraTituloFator ;
      private decimal A1036ConfiguracoesCompraTituloFator ;
      private decimal Z1038ConfiguracoesCompraTituloTarifa ;
      private decimal A1038ConfiguracoesCompraTituloTarifa ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string A300ConfiguracoesImagemLogin_Filetype ;
      private string A300ConfiguracoesImagemLogin_Filename ;
      private string sMode48 ;
      private bool Z765ConfiguracoesSerasaAnotacoesCompletas ;
      private bool A765ConfiguracoesSerasaAnotacoesCompletas ;
      private bool Z766ConfiguracoesSerasaConsultaDetalhada ;
      private bool A766ConfiguracoesSerasaConsultaDetalhada ;
      private bool Z767ConfiguracoesSerasaParticipacaoSocietaria ;
      private bool A767ConfiguracoesSerasaParticipacaoSocietaria ;
      private bool Z768ConfiguracoesSerasaRendaEstimada ;
      private bool A768ConfiguracoesSerasaRendaEstimada ;
      private bool Z769ConfiguracoesSerasaHistoricoPagamento ;
      private bool A769ConfiguracoesSerasaHistoricoPagamento ;
      private bool n315ConfiguracoesImagemLoginNomeInteiro ;
      private bool n316ConfiguracoesImagemLoginTamanho ;
      private bool n317ConfiguracoesImagemLoginBackground ;
      private bool n319ConfiguracoesImagemHeaderNome ;
      private bool n320ConfiguracoesImagemHeaderExtencao ;
      private bool n321ConfiguracoesImagemHeaderNomeInteiro ;
      private bool n322ConfiguracoesImagemHeaderTamanho ;
      private bool n418ConfiguracoesLayoutContratoCorpo ;
      private bool n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo ;
      private bool n568ConfigLayoutCorpoPromissoriaClinicaTaxa ;
      private bool n569ConfigLayoutCorpoPromissoriaPaciente ;
      private bool n563ConfiguracaoSenhaPFX ;
      private bool n765ConfiguracoesSerasaAnotacoesCompletas ;
      private bool n766ConfiguracoesSerasaConsultaDetalhada ;
      private bool n767ConfiguracoesSerasaParticipacaoSocietaria ;
      private bool n768ConfiguracoesSerasaRendaEstimada ;
      private bool n769ConfiguracoesSerasaHistoricoPagamento ;
      private bool n1013ConfiguracoesCompraTituloTaxaEfetiva ;
      private bool n1014ConfiguracoesCompraTituloTaxaMora ;
      private bool n1036ConfiguracoesCompraTituloFator ;
      private bool n1037ConfiguracoesCompraTituloTarifaTipo ;
      private bool n1038ConfiguracoesCompraTituloTarifa ;
      private bool n312ConfiguracoesImagemLoginExtencao ;
      private bool n313ConfiguracoesImagemLoginNome ;
      private bool n398ConfiguracoesLayoutProposta ;
      private bool n564ConfigLayoutPromissoriaClinicaEmprestimo ;
      private bool n565ConfigLayoutPromissoriaClinicaTaxa ;
      private bool n566ConfigLayoutPromissoriaPaciente ;
      private bool n922ConfigLayoutContratoCompraTitulo ;
      private bool n654ConfiguracoesCategoriaTitulo ;
      private bool n300ConfiguracoesImagemLogin ;
      private bool n318ConfiguracoesImagemHeader ;
      private bool n562ConfiguracoesArquivoPFX ;
      private bool Gx_longc ;
      private string Z418ConfiguracoesLayoutContratoCorpo ;
      private string A418ConfiguracoesLayoutContratoCorpo ;
      private string Z567ConfigLayoutCorpoPromissoriaClinicaEmprestimo ;
      private string A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo ;
      private string Z568ConfigLayoutCorpoPromissoriaClinicaTaxa ;
      private string A568ConfigLayoutCorpoPromissoriaClinicaTaxa ;
      private string Z569ConfigLayoutCorpoPromissoriaPaciente ;
      private string A569ConfigLayoutCorpoPromissoriaPaciente ;
      private string Z315ConfiguracoesImagemLoginNomeInteiro ;
      private string A315ConfiguracoesImagemLoginNomeInteiro ;
      private string Z317ConfiguracoesImagemLoginBackground ;
      private string A317ConfiguracoesImagemLoginBackground ;
      private string Z319ConfiguracoesImagemHeaderNome ;
      private string A319ConfiguracoesImagemHeaderNome ;
      private string Z320ConfiguracoesImagemHeaderExtencao ;
      private string A320ConfiguracoesImagemHeaderExtencao ;
      private string Z321ConfiguracoesImagemHeaderNomeInteiro ;
      private string A321ConfiguracoesImagemHeaderNomeInteiro ;
      private string Z563ConfiguracaoSenhaPFX ;
      private string A563ConfiguracaoSenhaPFX ;
      private string Z1037ConfiguracoesCompraTituloTarifaTipo ;
      private string A1037ConfiguracoesCompraTituloTarifaTipo ;
      private string Z312ConfiguracoesImagemLoginExtencao ;
      private string A312ConfiguracoesImagemLoginExtencao ;
      private string Z313ConfiguracoesImagemLoginNome ;
      private string A313ConfiguracoesImagemLoginNome ;
      private string Z300ConfiguracoesImagemLogin ;
      private string A300ConfiguracoesImagemLogin ;
      private string Z318ConfiguracoesImagemHeader ;
      private string A318ConfiguracoesImagemHeader ;
      private string Z562ConfiguracoesArquivoPFX ;
      private string A562ConfiguracoesArquivoPFX ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC001910_A299ConfiguracoesId ;
      private string[] BC001910_A315ConfiguracoesImagemLoginNomeInteiro ;
      private bool[] BC001910_n315ConfiguracoesImagemLoginNomeInteiro ;
      private decimal[] BC001910_A316ConfiguracoesImagemLoginTamanho ;
      private bool[] BC001910_n316ConfiguracoesImagemLoginTamanho ;
      private string[] BC001910_A317ConfiguracoesImagemLoginBackground ;
      private bool[] BC001910_n317ConfiguracoesImagemLoginBackground ;
      private string[] BC001910_A319ConfiguracoesImagemHeaderNome ;
      private bool[] BC001910_n319ConfiguracoesImagemHeaderNome ;
      private string[] BC001910_A320ConfiguracoesImagemHeaderExtencao ;
      private bool[] BC001910_n320ConfiguracoesImagemHeaderExtencao ;
      private string[] BC001910_A321ConfiguracoesImagemHeaderNomeInteiro ;
      private bool[] BC001910_n321ConfiguracoesImagemHeaderNomeInteiro ;
      private decimal[] BC001910_A322ConfiguracoesImagemHeaderTamanho ;
      private bool[] BC001910_n322ConfiguracoesImagemHeaderTamanho ;
      private string[] BC001910_A418ConfiguracoesLayoutContratoCorpo ;
      private bool[] BC001910_n418ConfiguracoesLayoutContratoCorpo ;
      private string[] BC001910_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo ;
      private bool[] BC001910_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo ;
      private string[] BC001910_A568ConfigLayoutCorpoPromissoriaClinicaTaxa ;
      private bool[] BC001910_n568ConfigLayoutCorpoPromissoriaClinicaTaxa ;
      private string[] BC001910_A569ConfigLayoutCorpoPromissoriaPaciente ;
      private bool[] BC001910_n569ConfigLayoutCorpoPromissoriaPaciente ;
      private string[] BC001910_A563ConfiguracaoSenhaPFX ;
      private bool[] BC001910_n563ConfiguracaoSenhaPFX ;
      private bool[] BC001910_A765ConfiguracoesSerasaAnotacoesCompletas ;
      private bool[] BC001910_n765ConfiguracoesSerasaAnotacoesCompletas ;
      private bool[] BC001910_A766ConfiguracoesSerasaConsultaDetalhada ;
      private bool[] BC001910_n766ConfiguracoesSerasaConsultaDetalhada ;
      private bool[] BC001910_A767ConfiguracoesSerasaParticipacaoSocietaria ;
      private bool[] BC001910_n767ConfiguracoesSerasaParticipacaoSocietaria ;
      private bool[] BC001910_A768ConfiguracoesSerasaRendaEstimada ;
      private bool[] BC001910_n768ConfiguracoesSerasaRendaEstimada ;
      private bool[] BC001910_A769ConfiguracoesSerasaHistoricoPagamento ;
      private bool[] BC001910_n769ConfiguracoesSerasaHistoricoPagamento ;
      private decimal[] BC001910_A1013ConfiguracoesCompraTituloTaxaEfetiva ;
      private bool[] BC001910_n1013ConfiguracoesCompraTituloTaxaEfetiva ;
      private decimal[] BC001910_A1014ConfiguracoesCompraTituloTaxaMora ;
      private bool[] BC001910_n1014ConfiguracoesCompraTituloTaxaMora ;
      private decimal[] BC001910_A1036ConfiguracoesCompraTituloFator ;
      private bool[] BC001910_n1036ConfiguracoesCompraTituloFator ;
      private string[] BC001910_A1037ConfiguracoesCompraTituloTarifaTipo ;
      private bool[] BC001910_n1037ConfiguracoesCompraTituloTarifaTipo ;
      private decimal[] BC001910_A1038ConfiguracoesCompraTituloTarifa ;
      private bool[] BC001910_n1038ConfiguracoesCompraTituloTarifa ;
      private string[] BC001910_A312ConfiguracoesImagemLoginExtencao ;
      private bool[] BC001910_n312ConfiguracoesImagemLoginExtencao ;
      private string[] BC001910_A313ConfiguracoesImagemLoginNome ;
      private bool[] BC001910_n313ConfiguracoesImagemLoginNome ;
      private short[] BC001910_A398ConfiguracoesLayoutProposta ;
      private bool[] BC001910_n398ConfiguracoesLayoutProposta ;
      private short[] BC001910_A564ConfigLayoutPromissoriaClinicaEmprestimo ;
      private bool[] BC001910_n564ConfigLayoutPromissoriaClinicaEmprestimo ;
      private short[] BC001910_A565ConfigLayoutPromissoriaClinicaTaxa ;
      private bool[] BC001910_n565ConfigLayoutPromissoriaClinicaTaxa ;
      private short[] BC001910_A566ConfigLayoutPromissoriaPaciente ;
      private bool[] BC001910_n566ConfigLayoutPromissoriaPaciente ;
      private short[] BC001910_A922ConfigLayoutContratoCompraTitulo ;
      private bool[] BC001910_n922ConfigLayoutContratoCompraTitulo ;
      private int[] BC001910_A654ConfiguracoesCategoriaTitulo ;
      private bool[] BC001910_n654ConfiguracoesCategoriaTitulo ;
      private string[] BC001910_A300ConfiguracoesImagemLogin ;
      private bool[] BC001910_n300ConfiguracoesImagemLogin ;
      private string[] BC001910_A318ConfiguracoesImagemHeader ;
      private bool[] BC001910_n318ConfiguracoesImagemHeader ;
      private string[] BC001910_A562ConfiguracoesArquivoPFX ;
      private bool[] BC001910_n562ConfiguracoesArquivoPFX ;
      private string[] BC00194_A418ConfiguracoesLayoutContratoCorpo ;
      private bool[] BC00194_n418ConfiguracoesLayoutContratoCorpo ;
      private string[] BC00195_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo ;
      private bool[] BC00195_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo ;
      private string[] BC00196_A568ConfigLayoutCorpoPromissoriaClinicaTaxa ;
      private bool[] BC00196_n568ConfigLayoutCorpoPromissoriaClinicaTaxa ;
      private string[] BC00197_A569ConfigLayoutCorpoPromissoriaPaciente ;
      private bool[] BC00197_n569ConfigLayoutCorpoPromissoriaPaciente ;
      private short[] BC00198_A922ConfigLayoutContratoCompraTitulo ;
      private bool[] BC00198_n922ConfigLayoutContratoCompraTitulo ;
      private int[] BC00199_A654ConfiguracoesCategoriaTitulo ;
      private bool[] BC00199_n654ConfiguracoesCategoriaTitulo ;
      private int[] BC001911_A299ConfiguracoesId ;
      private int[] BC00193_A299ConfiguracoesId ;
      private string[] BC00193_A315ConfiguracoesImagemLoginNomeInteiro ;
      private bool[] BC00193_n315ConfiguracoesImagemLoginNomeInteiro ;
      private decimal[] BC00193_A316ConfiguracoesImagemLoginTamanho ;
      private bool[] BC00193_n316ConfiguracoesImagemLoginTamanho ;
      private string[] BC00193_A317ConfiguracoesImagemLoginBackground ;
      private bool[] BC00193_n317ConfiguracoesImagemLoginBackground ;
      private string[] BC00193_A319ConfiguracoesImagemHeaderNome ;
      private bool[] BC00193_n319ConfiguracoesImagemHeaderNome ;
      private string[] BC00193_A320ConfiguracoesImagemHeaderExtencao ;
      private bool[] BC00193_n320ConfiguracoesImagemHeaderExtencao ;
      private string[] BC00193_A321ConfiguracoesImagemHeaderNomeInteiro ;
      private bool[] BC00193_n321ConfiguracoesImagemHeaderNomeInteiro ;
      private decimal[] BC00193_A322ConfiguracoesImagemHeaderTamanho ;
      private bool[] BC00193_n322ConfiguracoesImagemHeaderTamanho ;
      private string[] BC00193_A563ConfiguracaoSenhaPFX ;
      private bool[] BC00193_n563ConfiguracaoSenhaPFX ;
      private bool[] BC00193_A765ConfiguracoesSerasaAnotacoesCompletas ;
      private bool[] BC00193_n765ConfiguracoesSerasaAnotacoesCompletas ;
      private bool[] BC00193_A766ConfiguracoesSerasaConsultaDetalhada ;
      private bool[] BC00193_n766ConfiguracoesSerasaConsultaDetalhada ;
      private bool[] BC00193_A767ConfiguracoesSerasaParticipacaoSocietaria ;
      private bool[] BC00193_n767ConfiguracoesSerasaParticipacaoSocietaria ;
      private bool[] BC00193_A768ConfiguracoesSerasaRendaEstimada ;
      private bool[] BC00193_n768ConfiguracoesSerasaRendaEstimada ;
      private bool[] BC00193_A769ConfiguracoesSerasaHistoricoPagamento ;
      private bool[] BC00193_n769ConfiguracoesSerasaHistoricoPagamento ;
      private decimal[] BC00193_A1013ConfiguracoesCompraTituloTaxaEfetiva ;
      private bool[] BC00193_n1013ConfiguracoesCompraTituloTaxaEfetiva ;
      private decimal[] BC00193_A1014ConfiguracoesCompraTituloTaxaMora ;
      private bool[] BC00193_n1014ConfiguracoesCompraTituloTaxaMora ;
      private decimal[] BC00193_A1036ConfiguracoesCompraTituloFator ;
      private bool[] BC00193_n1036ConfiguracoesCompraTituloFator ;
      private string[] BC00193_A1037ConfiguracoesCompraTituloTarifaTipo ;
      private bool[] BC00193_n1037ConfiguracoesCompraTituloTarifaTipo ;
      private decimal[] BC00193_A1038ConfiguracoesCompraTituloTarifa ;
      private bool[] BC00193_n1038ConfiguracoesCompraTituloTarifa ;
      private string[] BC00193_A312ConfiguracoesImagemLoginExtencao ;
      private bool[] BC00193_n312ConfiguracoesImagemLoginExtencao ;
      private string[] BC00193_A313ConfiguracoesImagemLoginNome ;
      private bool[] BC00193_n313ConfiguracoesImagemLoginNome ;
      private short[] BC00193_A398ConfiguracoesLayoutProposta ;
      private bool[] BC00193_n398ConfiguracoesLayoutProposta ;
      private short[] BC00193_A564ConfigLayoutPromissoriaClinicaEmprestimo ;
      private bool[] BC00193_n564ConfigLayoutPromissoriaClinicaEmprestimo ;
      private short[] BC00193_A565ConfigLayoutPromissoriaClinicaTaxa ;
      private bool[] BC00193_n565ConfigLayoutPromissoriaClinicaTaxa ;
      private short[] BC00193_A566ConfigLayoutPromissoriaPaciente ;
      private bool[] BC00193_n566ConfigLayoutPromissoriaPaciente ;
      private short[] BC00193_A922ConfigLayoutContratoCompraTitulo ;
      private bool[] BC00193_n922ConfigLayoutContratoCompraTitulo ;
      private int[] BC00193_A654ConfiguracoesCategoriaTitulo ;
      private bool[] BC00193_n654ConfiguracoesCategoriaTitulo ;
      private string[] BC00193_A300ConfiguracoesImagemLogin ;
      private bool[] BC00193_n300ConfiguracoesImagemLogin ;
      private string[] BC00193_A318ConfiguracoesImagemHeader ;
      private bool[] BC00193_n318ConfiguracoesImagemHeader ;
      private string[] BC00193_A562ConfiguracoesArquivoPFX ;
      private bool[] BC00193_n562ConfiguracoesArquivoPFX ;
      private int[] BC00192_A299ConfiguracoesId ;
      private string[] BC00192_A315ConfiguracoesImagemLoginNomeInteiro ;
      private bool[] BC00192_n315ConfiguracoesImagemLoginNomeInteiro ;
      private decimal[] BC00192_A316ConfiguracoesImagemLoginTamanho ;
      private bool[] BC00192_n316ConfiguracoesImagemLoginTamanho ;
      private string[] BC00192_A317ConfiguracoesImagemLoginBackground ;
      private bool[] BC00192_n317ConfiguracoesImagemLoginBackground ;
      private string[] BC00192_A319ConfiguracoesImagemHeaderNome ;
      private bool[] BC00192_n319ConfiguracoesImagemHeaderNome ;
      private string[] BC00192_A320ConfiguracoesImagemHeaderExtencao ;
      private bool[] BC00192_n320ConfiguracoesImagemHeaderExtencao ;
      private string[] BC00192_A321ConfiguracoesImagemHeaderNomeInteiro ;
      private bool[] BC00192_n321ConfiguracoesImagemHeaderNomeInteiro ;
      private decimal[] BC00192_A322ConfiguracoesImagemHeaderTamanho ;
      private bool[] BC00192_n322ConfiguracoesImagemHeaderTamanho ;
      private string[] BC00192_A563ConfiguracaoSenhaPFX ;
      private bool[] BC00192_n563ConfiguracaoSenhaPFX ;
      private bool[] BC00192_A765ConfiguracoesSerasaAnotacoesCompletas ;
      private bool[] BC00192_n765ConfiguracoesSerasaAnotacoesCompletas ;
      private bool[] BC00192_A766ConfiguracoesSerasaConsultaDetalhada ;
      private bool[] BC00192_n766ConfiguracoesSerasaConsultaDetalhada ;
      private bool[] BC00192_A767ConfiguracoesSerasaParticipacaoSocietaria ;
      private bool[] BC00192_n767ConfiguracoesSerasaParticipacaoSocietaria ;
      private bool[] BC00192_A768ConfiguracoesSerasaRendaEstimada ;
      private bool[] BC00192_n768ConfiguracoesSerasaRendaEstimada ;
      private bool[] BC00192_A769ConfiguracoesSerasaHistoricoPagamento ;
      private bool[] BC00192_n769ConfiguracoesSerasaHistoricoPagamento ;
      private decimal[] BC00192_A1013ConfiguracoesCompraTituloTaxaEfetiva ;
      private bool[] BC00192_n1013ConfiguracoesCompraTituloTaxaEfetiva ;
      private decimal[] BC00192_A1014ConfiguracoesCompraTituloTaxaMora ;
      private bool[] BC00192_n1014ConfiguracoesCompraTituloTaxaMora ;
      private decimal[] BC00192_A1036ConfiguracoesCompraTituloFator ;
      private bool[] BC00192_n1036ConfiguracoesCompraTituloFator ;
      private string[] BC00192_A1037ConfiguracoesCompraTituloTarifaTipo ;
      private bool[] BC00192_n1037ConfiguracoesCompraTituloTarifaTipo ;
      private decimal[] BC00192_A1038ConfiguracoesCompraTituloTarifa ;
      private bool[] BC00192_n1038ConfiguracoesCompraTituloTarifa ;
      private string[] BC00192_A312ConfiguracoesImagemLoginExtencao ;
      private bool[] BC00192_n312ConfiguracoesImagemLoginExtencao ;
      private string[] BC00192_A313ConfiguracoesImagemLoginNome ;
      private bool[] BC00192_n313ConfiguracoesImagemLoginNome ;
      private short[] BC00192_A398ConfiguracoesLayoutProposta ;
      private bool[] BC00192_n398ConfiguracoesLayoutProposta ;
      private short[] BC00192_A564ConfigLayoutPromissoriaClinicaEmprestimo ;
      private bool[] BC00192_n564ConfigLayoutPromissoriaClinicaEmprestimo ;
      private short[] BC00192_A565ConfigLayoutPromissoriaClinicaTaxa ;
      private bool[] BC00192_n565ConfigLayoutPromissoriaClinicaTaxa ;
      private short[] BC00192_A566ConfigLayoutPromissoriaPaciente ;
      private bool[] BC00192_n566ConfigLayoutPromissoriaPaciente ;
      private short[] BC00192_A922ConfigLayoutContratoCompraTitulo ;
      private bool[] BC00192_n922ConfigLayoutContratoCompraTitulo ;
      private int[] BC00192_A654ConfiguracoesCategoriaTitulo ;
      private bool[] BC00192_n654ConfiguracoesCategoriaTitulo ;
      private string[] BC00192_A300ConfiguracoesImagemLogin ;
      private bool[] BC00192_n300ConfiguracoesImagemLogin ;
      private string[] BC00192_A318ConfiguracoesImagemHeader ;
      private bool[] BC00192_n318ConfiguracoesImagemHeader ;
      private string[] BC00192_A562ConfiguracoesArquivoPFX ;
      private bool[] BC00192_n562ConfiguracoesArquivoPFX ;
      private int[] BC001913_A299ConfiguracoesId ;
      private string[] BC001919_A418ConfiguracoesLayoutContratoCorpo ;
      private bool[] BC001919_n418ConfiguracoesLayoutContratoCorpo ;
      private string[] BC001920_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo ;
      private bool[] BC001920_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo ;
      private string[] BC001921_A568ConfigLayoutCorpoPromissoriaClinicaTaxa ;
      private bool[] BC001921_n568ConfigLayoutCorpoPromissoriaClinicaTaxa ;
      private string[] BC001922_A569ConfigLayoutCorpoPromissoriaPaciente ;
      private bool[] BC001922_n569ConfigLayoutCorpoPromissoriaPaciente ;
      private int[] BC001923_A299ConfiguracoesId ;
      private string[] BC001923_A315ConfiguracoesImagemLoginNomeInteiro ;
      private bool[] BC001923_n315ConfiguracoesImagemLoginNomeInteiro ;
      private decimal[] BC001923_A316ConfiguracoesImagemLoginTamanho ;
      private bool[] BC001923_n316ConfiguracoesImagemLoginTamanho ;
      private string[] BC001923_A317ConfiguracoesImagemLoginBackground ;
      private bool[] BC001923_n317ConfiguracoesImagemLoginBackground ;
      private string[] BC001923_A319ConfiguracoesImagemHeaderNome ;
      private bool[] BC001923_n319ConfiguracoesImagemHeaderNome ;
      private string[] BC001923_A320ConfiguracoesImagemHeaderExtencao ;
      private bool[] BC001923_n320ConfiguracoesImagemHeaderExtencao ;
      private string[] BC001923_A321ConfiguracoesImagemHeaderNomeInteiro ;
      private bool[] BC001923_n321ConfiguracoesImagemHeaderNomeInteiro ;
      private decimal[] BC001923_A322ConfiguracoesImagemHeaderTamanho ;
      private bool[] BC001923_n322ConfiguracoesImagemHeaderTamanho ;
      private string[] BC001923_A418ConfiguracoesLayoutContratoCorpo ;
      private bool[] BC001923_n418ConfiguracoesLayoutContratoCorpo ;
      private string[] BC001923_A567ConfigLayoutCorpoPromissoriaClinicaEmprestimo ;
      private bool[] BC001923_n567ConfigLayoutCorpoPromissoriaClinicaEmprestimo ;
      private string[] BC001923_A568ConfigLayoutCorpoPromissoriaClinicaTaxa ;
      private bool[] BC001923_n568ConfigLayoutCorpoPromissoriaClinicaTaxa ;
      private string[] BC001923_A569ConfigLayoutCorpoPromissoriaPaciente ;
      private bool[] BC001923_n569ConfigLayoutCorpoPromissoriaPaciente ;
      private string[] BC001923_A563ConfiguracaoSenhaPFX ;
      private bool[] BC001923_n563ConfiguracaoSenhaPFX ;
      private bool[] BC001923_A765ConfiguracoesSerasaAnotacoesCompletas ;
      private bool[] BC001923_n765ConfiguracoesSerasaAnotacoesCompletas ;
      private bool[] BC001923_A766ConfiguracoesSerasaConsultaDetalhada ;
      private bool[] BC001923_n766ConfiguracoesSerasaConsultaDetalhada ;
      private bool[] BC001923_A767ConfiguracoesSerasaParticipacaoSocietaria ;
      private bool[] BC001923_n767ConfiguracoesSerasaParticipacaoSocietaria ;
      private bool[] BC001923_A768ConfiguracoesSerasaRendaEstimada ;
      private bool[] BC001923_n768ConfiguracoesSerasaRendaEstimada ;
      private bool[] BC001923_A769ConfiguracoesSerasaHistoricoPagamento ;
      private bool[] BC001923_n769ConfiguracoesSerasaHistoricoPagamento ;
      private decimal[] BC001923_A1013ConfiguracoesCompraTituloTaxaEfetiva ;
      private bool[] BC001923_n1013ConfiguracoesCompraTituloTaxaEfetiva ;
      private decimal[] BC001923_A1014ConfiguracoesCompraTituloTaxaMora ;
      private bool[] BC001923_n1014ConfiguracoesCompraTituloTaxaMora ;
      private decimal[] BC001923_A1036ConfiguracoesCompraTituloFator ;
      private bool[] BC001923_n1036ConfiguracoesCompraTituloFator ;
      private string[] BC001923_A1037ConfiguracoesCompraTituloTarifaTipo ;
      private bool[] BC001923_n1037ConfiguracoesCompraTituloTarifaTipo ;
      private decimal[] BC001923_A1038ConfiguracoesCompraTituloTarifa ;
      private bool[] BC001923_n1038ConfiguracoesCompraTituloTarifa ;
      private string[] BC001923_A312ConfiguracoesImagemLoginExtencao ;
      private bool[] BC001923_n312ConfiguracoesImagemLoginExtencao ;
      private string[] BC001923_A313ConfiguracoesImagemLoginNome ;
      private bool[] BC001923_n313ConfiguracoesImagemLoginNome ;
      private short[] BC001923_A398ConfiguracoesLayoutProposta ;
      private bool[] BC001923_n398ConfiguracoesLayoutProposta ;
      private short[] BC001923_A564ConfigLayoutPromissoriaClinicaEmprestimo ;
      private bool[] BC001923_n564ConfigLayoutPromissoriaClinicaEmprestimo ;
      private short[] BC001923_A565ConfigLayoutPromissoriaClinicaTaxa ;
      private bool[] BC001923_n565ConfigLayoutPromissoriaClinicaTaxa ;
      private short[] BC001923_A566ConfigLayoutPromissoriaPaciente ;
      private bool[] BC001923_n566ConfigLayoutPromissoriaPaciente ;
      private short[] BC001923_A922ConfigLayoutContratoCompraTitulo ;
      private bool[] BC001923_n922ConfigLayoutContratoCompraTitulo ;
      private int[] BC001923_A654ConfiguracoesCategoriaTitulo ;
      private bool[] BC001923_n654ConfiguracoesCategoriaTitulo ;
      private string[] BC001923_A300ConfiguracoesImagemLogin ;
      private bool[] BC001923_n300ConfiguracoesImagemLogin ;
      private string[] BC001923_A318ConfiguracoesImagemHeader ;
      private bool[] BC001923_n318ConfiguracoesImagemHeader ;
      private string[] BC001923_A562ConfiguracoesArquivoPFX ;
      private bool[] BC001923_n562ConfiguracoesArquivoPFX ;
      private SdtConfiguracoes bcConfiguracoes ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class configuracoes_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[14])
         ,new UpdateCursor(def[15])
         ,new UpdateCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00192;
          prmBC00192 = new Object[] {
          new ParDef("ConfiguracoesId",GXType.Int32,9,0)
          };
          Object[] prmBC00193;
          prmBC00193 = new Object[] {
          new ParDef("ConfiguracoesId",GXType.Int32,9,0)
          };
          Object[] prmBC00194;
          prmBC00194 = new Object[] {
          new ParDef("ConfiguracoesLayoutProposta",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC00195;
          prmBC00195 = new Object[] {
          new ParDef("ConfigLayoutPromissoriaClinicaEmprestimo",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC00196;
          prmBC00196 = new Object[] {
          new ParDef("ConfigLayoutPromissoriaClinicaTaxa",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC00197;
          prmBC00197 = new Object[] {
          new ParDef("ConfigLayoutPromissoriaPaciente",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC00198;
          prmBC00198 = new Object[] {
          new ParDef("ConfigLayoutContratoCompraTitulo",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC00199;
          prmBC00199 = new Object[] {
          new ParDef("ConfiguracoesCategoriaTitulo",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001910;
          prmBC001910 = new Object[] {
          new ParDef("ConfiguracoesId",GXType.Int32,9,0)
          };
          string cmdBufferBC001910;
          cmdBufferBC001910=" SELECT TM1.ConfiguracoesId, TM1.ConfiguracoesImagemLoginNomeInteiro, TM1.ConfiguracoesImagemLoginTamanho, TM1.ConfiguracoesImagemLoginBackground, TM1.ConfiguracoesImagemHeaderNome, TM1.ConfiguracoesImagemHeaderExtencao, TM1.ConfiguracoesImagemHeaderNomeInteiro, TM1.ConfiguracoesImagemHeaderTamanho, T2.LayoutContratoCorpo AS ConfiguracoesLayoutContratoCorpo, T3.LayoutContratoCorpo AS ConfigLayoutCorpoPromissoriaClinicaEmprestimo, T4.LayoutContratoCorpo AS ConfigLayoutCorpoPromissoriaClinicaTaxa, T5.LayoutContratoCorpo AS ConfigLayoutCorpoPromissoriaPaciente, TM1.ConfiguracaoSenhaPFX, TM1.ConfiguracoesSerasaAnotacoesCompletas, TM1.ConfiguracoesSerasaConsultaDetalhada, TM1.ConfiguracoesSerasaParticipacaoSocietaria, TM1.ConfiguracoesSerasaRendaEstimada, TM1.ConfiguracoesSerasaHistoricoPagamento, TM1.ConfiguracoesCompraTituloTaxaEfetiva, TM1.ConfiguracoesCompraTituloTaxaMora, TM1.ConfiguracoesCompraTituloFator, TM1.ConfiguracoesCompraTituloTarifaTipo, TM1.ConfiguracoesCompraTituloTarifa, TM1.ConfiguracoesImagemLoginExtencao, TM1.ConfiguracoesImagemLoginNome, TM1.ConfiguracoesLayoutProposta AS ConfiguracoesLayoutProposta, TM1.ConfigLayoutPromissoriaClinicaEmprestimo AS ConfigLayoutPromissoriaClinicaEmprestimo, TM1.ConfigLayoutPromissoriaClinicaTaxa AS ConfigLayoutPromissoriaClinicaTaxa, TM1.ConfigLayoutPromissoriaPaciente AS ConfigLayoutPromissoriaPaciente, TM1.ConfigLayoutContratoCompraTitulo AS ConfigLayoutContratoCompraTitulo, TM1.ConfiguracoesCategoriaTitulo AS ConfiguracoesCategoriaTitulo, TM1.ConfiguracoesImagemLogin, TM1.ConfiguracoesImagemHeader, TM1.ConfiguracoesArquivoPFX FROM ((((Configuracoes TM1 LEFT JOIN LayoutContrato T2 ON T2.LayoutContratoId = TM1.ConfiguracoesLayoutProposta) LEFT JOIN LayoutContrato T3 ON T3.LayoutContratoId = TM1.ConfigLayoutPromissoriaClinicaEmprestimo) "
          + " LEFT JOIN LayoutContrato T4 ON T4.LayoutContratoId = TM1.ConfigLayoutPromissoriaClinicaTaxa) LEFT JOIN LayoutContrato T5 ON T5.LayoutContratoId = TM1.ConfigLayoutPromissoriaPaciente) WHERE TM1.ConfiguracoesId = :ConfiguracoesId ORDER BY TM1.ConfiguracoesId" ;
          Object[] prmBC001911;
          prmBC001911 = new Object[] {
          new ParDef("ConfiguracoesId",GXType.Int32,9,0)
          };
          Object[] prmBC001912;
          prmBC001912 = new Object[] {
          new ParDef("ConfiguracoesImagemLogin",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("ConfiguracoesImagemLoginNomeInteiro",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ConfiguracoesImagemLoginTamanho",GXType.Number,18,2){Nullable=true} ,
          new ParDef("ConfiguracoesImagemLoginBackground",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ConfiguracoesImagemHeader",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("ConfiguracoesImagemHeaderNome",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ConfiguracoesImagemHeaderExtencao",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ConfiguracoesImagemHeaderNomeInteiro",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ConfiguracoesImagemHeaderTamanho",GXType.Number,18,2){Nullable=true} ,
          new ParDef("ConfiguracoesArquivoPFX",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("ConfiguracaoSenhaPFX",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("ConfiguracoesSerasaAnotacoesCompletas",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ConfiguracoesSerasaConsultaDetalhada",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ConfiguracoesSerasaParticipacaoSocietaria",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ConfiguracoesSerasaRendaEstimada",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ConfiguracoesSerasaHistoricoPagamento",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ConfiguracoesCompraTituloTaxaEfetiva",GXType.Number,16,4){Nullable=true} ,
          new ParDef("ConfiguracoesCompraTituloTaxaMora",GXType.Number,16,4){Nullable=true} ,
          new ParDef("ConfiguracoesCompraTituloFator",GXType.Number,16,4){Nullable=true} ,
          new ParDef("ConfiguracoesCompraTituloTarifaTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ConfiguracoesCompraTituloTarifa",GXType.Number,15,2){Nullable=true} ,
          new ParDef("ConfiguracoesImagemLoginExtencao",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ConfiguracoesImagemLoginNome",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ConfiguracoesLayoutProposta",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ConfigLayoutPromissoriaClinicaEmprestimo",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ConfigLayoutPromissoriaClinicaTaxa",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ConfigLayoutPromissoriaPaciente",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ConfigLayoutContratoCompraTitulo",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ConfiguracoesCategoriaTitulo",GXType.Int32,9,0){Nullable=true}
          };
          string cmdBufferBC001912;
          cmdBufferBC001912=" SAVEPOINT gxupdate;INSERT INTO Configuracoes(ConfiguracoesImagemLogin, ConfiguracoesImagemLoginNomeInteiro, ConfiguracoesImagemLoginTamanho, ConfiguracoesImagemLoginBackground, ConfiguracoesImagemHeader, ConfiguracoesImagemHeaderNome, ConfiguracoesImagemHeaderExtencao, ConfiguracoesImagemHeaderNomeInteiro, ConfiguracoesImagemHeaderTamanho, ConfiguracoesArquivoPFX, ConfiguracaoSenhaPFX, ConfiguracoesSerasaAnotacoesCompletas, ConfiguracoesSerasaConsultaDetalhada, ConfiguracoesSerasaParticipacaoSocietaria, ConfiguracoesSerasaRendaEstimada, ConfiguracoesSerasaHistoricoPagamento, ConfiguracoesCompraTituloTaxaEfetiva, ConfiguracoesCompraTituloTaxaMora, ConfiguracoesCompraTituloFator, ConfiguracoesCompraTituloTarifaTipo, ConfiguracoesCompraTituloTarifa, ConfiguracoesImagemLoginExtencao, ConfiguracoesImagemLoginNome, ConfiguracoesLayoutProposta, ConfigLayoutPromissoriaClinicaEmprestimo, ConfigLayoutPromissoriaClinicaTaxa, ConfigLayoutPromissoriaPaciente, ConfigLayoutContratoCompraTitulo, ConfiguracoesCategoriaTitulo) VALUES(:ConfiguracoesImagemLogin, :ConfiguracoesImagemLoginNomeInteiro, :ConfiguracoesImagemLoginTamanho, :ConfiguracoesImagemLoginBackground, :ConfiguracoesImagemHeader, :ConfiguracoesImagemHeaderNome, :ConfiguracoesImagemHeaderExtencao, :ConfiguracoesImagemHeaderNomeInteiro, :ConfiguracoesImagemHeaderTamanho, :ConfiguracoesArquivoPFX, :ConfiguracaoSenhaPFX, :ConfiguracoesSerasaAnotacoesCompletas, :ConfiguracoesSerasaConsultaDetalhada, :ConfiguracoesSerasaParticipacaoSocietaria, :ConfiguracoesSerasaRendaEstimada, :ConfiguracoesSerasaHistoricoPagamento, :ConfiguracoesCompraTituloTaxaEfetiva, :ConfiguracoesCompraTituloTaxaMora, :ConfiguracoesCompraTituloFator, :ConfiguracoesCompraTituloTarifaTipo, :ConfiguracoesCompraTituloTarifa, :ConfiguracoesImagemLoginExtencao, :ConfiguracoesImagemLoginNome, "
          + " :ConfiguracoesLayoutProposta, :ConfigLayoutPromissoriaClinicaEmprestimo, :ConfigLayoutPromissoriaClinicaTaxa, :ConfigLayoutPromissoriaPaciente, :ConfigLayoutContratoCompraTitulo, :ConfiguracoesCategoriaTitulo);RELEASE SAVEPOINT gxupdate" ;
          Object[] prmBC001913;
          prmBC001913 = new Object[] {
          };
          Object[] prmBC001914;
          prmBC001914 = new Object[] {
          new ParDef("ConfiguracoesImagemLoginNomeInteiro",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ConfiguracoesImagemLoginTamanho",GXType.Number,18,2){Nullable=true} ,
          new ParDef("ConfiguracoesImagemLoginBackground",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ConfiguracoesImagemHeaderNome",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ConfiguracoesImagemHeaderExtencao",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ConfiguracoesImagemHeaderNomeInteiro",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ConfiguracoesImagemHeaderTamanho",GXType.Number,18,2){Nullable=true} ,
          new ParDef("ConfiguracaoSenhaPFX",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("ConfiguracoesSerasaAnotacoesCompletas",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ConfiguracoesSerasaConsultaDetalhada",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ConfiguracoesSerasaParticipacaoSocietaria",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ConfiguracoesSerasaRendaEstimada",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ConfiguracoesSerasaHistoricoPagamento",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ConfiguracoesCompraTituloTaxaEfetiva",GXType.Number,16,4){Nullable=true} ,
          new ParDef("ConfiguracoesCompraTituloTaxaMora",GXType.Number,16,4){Nullable=true} ,
          new ParDef("ConfiguracoesCompraTituloFator",GXType.Number,16,4){Nullable=true} ,
          new ParDef("ConfiguracoesCompraTituloTarifaTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ConfiguracoesCompraTituloTarifa",GXType.Number,15,2){Nullable=true} ,
          new ParDef("ConfiguracoesImagemLoginExtencao",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ConfiguracoesImagemLoginNome",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ConfiguracoesLayoutProposta",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ConfigLayoutPromissoriaClinicaEmprestimo",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ConfigLayoutPromissoriaClinicaTaxa",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ConfigLayoutPromissoriaPaciente",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ConfigLayoutContratoCompraTitulo",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ConfiguracoesCategoriaTitulo",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ConfiguracoesId",GXType.Int32,9,0)
          };
          string cmdBufferBC001914;
          cmdBufferBC001914=" SAVEPOINT gxupdate;UPDATE Configuracoes SET ConfiguracoesImagemLoginNomeInteiro=:ConfiguracoesImagemLoginNomeInteiro, ConfiguracoesImagemLoginTamanho=:ConfiguracoesImagemLoginTamanho, ConfiguracoesImagemLoginBackground=:ConfiguracoesImagemLoginBackground, ConfiguracoesImagemHeaderNome=:ConfiguracoesImagemHeaderNome, ConfiguracoesImagemHeaderExtencao=:ConfiguracoesImagemHeaderExtencao, ConfiguracoesImagemHeaderNomeInteiro=:ConfiguracoesImagemHeaderNomeInteiro, ConfiguracoesImagemHeaderTamanho=:ConfiguracoesImagemHeaderTamanho, ConfiguracaoSenhaPFX=:ConfiguracaoSenhaPFX, ConfiguracoesSerasaAnotacoesCompletas=:ConfiguracoesSerasaAnotacoesCompletas, ConfiguracoesSerasaConsultaDetalhada=:ConfiguracoesSerasaConsultaDetalhada, ConfiguracoesSerasaParticipacaoSocietaria=:ConfiguracoesSerasaParticipacaoSocietaria, ConfiguracoesSerasaRendaEstimada=:ConfiguracoesSerasaRendaEstimada, ConfiguracoesSerasaHistoricoPagamento=:ConfiguracoesSerasaHistoricoPagamento, ConfiguracoesCompraTituloTaxaEfetiva=:ConfiguracoesCompraTituloTaxaEfetiva, ConfiguracoesCompraTituloTaxaMora=:ConfiguracoesCompraTituloTaxaMora, ConfiguracoesCompraTituloFator=:ConfiguracoesCompraTituloFator, ConfiguracoesCompraTituloTarifaTipo=:ConfiguracoesCompraTituloTarifaTipo, ConfiguracoesCompraTituloTarifa=:ConfiguracoesCompraTituloTarifa, ConfiguracoesImagemLoginExtencao=:ConfiguracoesImagemLoginExtencao, ConfiguracoesImagemLoginNome=:ConfiguracoesImagemLoginNome, ConfiguracoesLayoutProposta=:ConfiguracoesLayoutProposta, ConfigLayoutPromissoriaClinicaEmprestimo=:ConfigLayoutPromissoriaClinicaEmprestimo, ConfigLayoutPromissoriaClinicaTaxa=:ConfigLayoutPromissoriaClinicaTaxa, ConfigLayoutPromissoriaPaciente=:ConfigLayoutPromissoriaPaciente, ConfigLayoutContratoCompraTitulo=:ConfigLayoutContratoCompraTitulo, ConfiguracoesCategoriaTitulo=:ConfiguracoesCategoriaTitulo "
          + "  WHERE ConfiguracoesId = :ConfiguracoesId;RELEASE SAVEPOINT gxupdate" ;
          Object[] prmBC001915;
          prmBC001915 = new Object[] {
          new ParDef("ConfiguracoesImagemLogin",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("ConfiguracoesId",GXType.Int32,9,0)
          };
          Object[] prmBC001916;
          prmBC001916 = new Object[] {
          new ParDef("ConfiguracoesImagemHeader",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("ConfiguracoesId",GXType.Int32,9,0)
          };
          Object[] prmBC001917;
          prmBC001917 = new Object[] {
          new ParDef("ConfiguracoesArquivoPFX",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("ConfiguracoesId",GXType.Int32,9,0)
          };
          Object[] prmBC001918;
          prmBC001918 = new Object[] {
          new ParDef("ConfiguracoesId",GXType.Int32,9,0)
          };
          Object[] prmBC001919;
          prmBC001919 = new Object[] {
          new ParDef("ConfiguracoesLayoutProposta",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC001920;
          prmBC001920 = new Object[] {
          new ParDef("ConfigLayoutPromissoriaClinicaEmprestimo",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC001921;
          prmBC001921 = new Object[] {
          new ParDef("ConfigLayoutPromissoriaClinicaTaxa",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC001922;
          prmBC001922 = new Object[] {
          new ParDef("ConfigLayoutPromissoriaPaciente",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC001923;
          prmBC001923 = new Object[] {
          new ParDef("ConfiguracoesId",GXType.Int32,9,0)
          };
          string cmdBufferBC001923;
          cmdBufferBC001923=" SELECT TM1.ConfiguracoesId, TM1.ConfiguracoesImagemLoginNomeInteiro, TM1.ConfiguracoesImagemLoginTamanho, TM1.ConfiguracoesImagemLoginBackground, TM1.ConfiguracoesImagemHeaderNome, TM1.ConfiguracoesImagemHeaderExtencao, TM1.ConfiguracoesImagemHeaderNomeInteiro, TM1.ConfiguracoesImagemHeaderTamanho, T2.LayoutContratoCorpo AS ConfiguracoesLayoutContratoCorpo, T3.LayoutContratoCorpo AS ConfigLayoutCorpoPromissoriaClinicaEmprestimo, T4.LayoutContratoCorpo AS ConfigLayoutCorpoPromissoriaClinicaTaxa, T5.LayoutContratoCorpo AS ConfigLayoutCorpoPromissoriaPaciente, TM1.ConfiguracaoSenhaPFX, TM1.ConfiguracoesSerasaAnotacoesCompletas, TM1.ConfiguracoesSerasaConsultaDetalhada, TM1.ConfiguracoesSerasaParticipacaoSocietaria, TM1.ConfiguracoesSerasaRendaEstimada, TM1.ConfiguracoesSerasaHistoricoPagamento, TM1.ConfiguracoesCompraTituloTaxaEfetiva, TM1.ConfiguracoesCompraTituloTaxaMora, TM1.ConfiguracoesCompraTituloFator, TM1.ConfiguracoesCompraTituloTarifaTipo, TM1.ConfiguracoesCompraTituloTarifa, TM1.ConfiguracoesImagemLoginExtencao, TM1.ConfiguracoesImagemLoginNome, TM1.ConfiguracoesLayoutProposta AS ConfiguracoesLayoutProposta, TM1.ConfigLayoutPromissoriaClinicaEmprestimo AS ConfigLayoutPromissoriaClinicaEmprestimo, TM1.ConfigLayoutPromissoriaClinicaTaxa AS ConfigLayoutPromissoriaClinicaTaxa, TM1.ConfigLayoutPromissoriaPaciente AS ConfigLayoutPromissoriaPaciente, TM1.ConfigLayoutContratoCompraTitulo AS ConfigLayoutContratoCompraTitulo, TM1.ConfiguracoesCategoriaTitulo AS ConfiguracoesCategoriaTitulo, TM1.ConfiguracoesImagemLogin, TM1.ConfiguracoesImagemHeader, TM1.ConfiguracoesArquivoPFX FROM ((((Configuracoes TM1 LEFT JOIN LayoutContrato T2 ON T2.LayoutContratoId = TM1.ConfiguracoesLayoutProposta) LEFT JOIN LayoutContrato T3 ON T3.LayoutContratoId = TM1.ConfigLayoutPromissoriaClinicaEmprestimo) "
          + " LEFT JOIN LayoutContrato T4 ON T4.LayoutContratoId = TM1.ConfigLayoutPromissoriaClinicaTaxa) LEFT JOIN LayoutContrato T5 ON T5.LayoutContratoId = TM1.ConfigLayoutPromissoriaPaciente) WHERE TM1.ConfiguracoesId = :ConfiguracoesId ORDER BY TM1.ConfiguracoesId" ;
          def= new CursorDef[] {
              new CursorDef("BC00192", "SELECT ConfiguracoesId, ConfiguracoesImagemLoginNomeInteiro, ConfiguracoesImagemLoginTamanho, ConfiguracoesImagemLoginBackground, ConfiguracoesImagemHeaderNome, ConfiguracoesImagemHeaderExtencao, ConfiguracoesImagemHeaderNomeInteiro, ConfiguracoesImagemHeaderTamanho, ConfiguracaoSenhaPFX, ConfiguracoesSerasaAnotacoesCompletas, ConfiguracoesSerasaConsultaDetalhada, ConfiguracoesSerasaParticipacaoSocietaria, ConfiguracoesSerasaRendaEstimada, ConfiguracoesSerasaHistoricoPagamento, ConfiguracoesCompraTituloTaxaEfetiva, ConfiguracoesCompraTituloTaxaMora, ConfiguracoesCompraTituloFator, ConfiguracoesCompraTituloTarifaTipo, ConfiguracoesCompraTituloTarifa, ConfiguracoesImagemLoginExtencao, ConfiguracoesImagemLoginNome, ConfiguracoesLayoutProposta, ConfigLayoutPromissoriaClinicaEmprestimo, ConfigLayoutPromissoriaClinicaTaxa, ConfigLayoutPromissoriaPaciente, ConfigLayoutContratoCompraTitulo, ConfiguracoesCategoriaTitulo, ConfiguracoesImagemLogin, ConfiguracoesImagemHeader, ConfiguracoesArquivoPFX FROM Configuracoes WHERE ConfiguracoesId = :ConfiguracoesId  FOR UPDATE OF Configuracoes",true, GxErrorMask.GX_NOMASK, false, this,prmBC00192,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00193", "SELECT ConfiguracoesId, ConfiguracoesImagemLoginNomeInteiro, ConfiguracoesImagemLoginTamanho, ConfiguracoesImagemLoginBackground, ConfiguracoesImagemHeaderNome, ConfiguracoesImagemHeaderExtencao, ConfiguracoesImagemHeaderNomeInteiro, ConfiguracoesImagemHeaderTamanho, ConfiguracaoSenhaPFX, ConfiguracoesSerasaAnotacoesCompletas, ConfiguracoesSerasaConsultaDetalhada, ConfiguracoesSerasaParticipacaoSocietaria, ConfiguracoesSerasaRendaEstimada, ConfiguracoesSerasaHistoricoPagamento, ConfiguracoesCompraTituloTaxaEfetiva, ConfiguracoesCompraTituloTaxaMora, ConfiguracoesCompraTituloFator, ConfiguracoesCompraTituloTarifaTipo, ConfiguracoesCompraTituloTarifa, ConfiguracoesImagemLoginExtencao, ConfiguracoesImagemLoginNome, ConfiguracoesLayoutProposta, ConfigLayoutPromissoriaClinicaEmprestimo, ConfigLayoutPromissoriaClinicaTaxa, ConfigLayoutPromissoriaPaciente, ConfigLayoutContratoCompraTitulo, ConfiguracoesCategoriaTitulo, ConfiguracoesImagemLogin, ConfiguracoesImagemHeader, ConfiguracoesArquivoPFX FROM Configuracoes WHERE ConfiguracoesId = :ConfiguracoesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00193,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00194", "SELECT LayoutContratoCorpo AS ConfiguracoesLayoutContratoCorpo FROM LayoutContrato WHERE LayoutContratoId = :ConfiguracoesLayoutProposta ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00194,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00195", "SELECT LayoutContratoCorpo AS ConfigLayoutCorpoPromissoriaClinicaEmprestimo FROM LayoutContrato WHERE LayoutContratoId = :ConfigLayoutPromissoriaClinicaEmprestimo ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00195,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00196", "SELECT LayoutContratoCorpo AS ConfigLayoutCorpoPromissoriaClinicaTaxa FROM LayoutContrato WHERE LayoutContratoId = :ConfigLayoutPromissoriaClinicaTaxa ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00196,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00197", "SELECT LayoutContratoCorpo AS ConfigLayoutCorpoPromissoriaPaciente FROM LayoutContrato WHERE LayoutContratoId = :ConfigLayoutPromissoriaPaciente ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00197,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00198", "SELECT LayoutContratoId AS ConfigLayoutContratoCompraTitulo FROM LayoutContrato WHERE LayoutContratoId = :ConfigLayoutContratoCompraTitulo ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00198,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00199", "SELECT CategoriaTituloId AS ConfiguracoesCategoriaTitulo FROM CategoriaTitulo WHERE CategoriaTituloId = :ConfiguracoesCategoriaTitulo ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00199,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001910", cmdBufferBC001910,true, GxErrorMask.GX_NOMASK, false, this,prmBC001910,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001911", "SELECT ConfiguracoesId FROM Configuracoes WHERE ConfiguracoesId = :ConfiguracoesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001911,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001912", cmdBufferBC001912, GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001912)
             ,new CursorDef("BC001913", "SELECT currval('ConfiguracoesId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001913,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001914", cmdBufferBC001914, GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001914)
             ,new CursorDef("BC001915", "SAVEPOINT gxupdate;UPDATE Configuracoes SET ConfiguracoesImagemLogin=:ConfiguracoesImagemLogin  WHERE ConfiguracoesId = :ConfiguracoesId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001915)
             ,new CursorDef("BC001916", "SAVEPOINT gxupdate;UPDATE Configuracoes SET ConfiguracoesImagemHeader=:ConfiguracoesImagemHeader  WHERE ConfiguracoesId = :ConfiguracoesId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001916)
             ,new CursorDef("BC001917", "SAVEPOINT gxupdate;UPDATE Configuracoes SET ConfiguracoesArquivoPFX=:ConfiguracoesArquivoPFX  WHERE ConfiguracoesId = :ConfiguracoesId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001917)
             ,new CursorDef("BC001918", "SAVEPOINT gxupdate;DELETE FROM Configuracoes  WHERE ConfiguracoesId = :ConfiguracoesId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001918)
             ,new CursorDef("BC001919", "SELECT LayoutContratoCorpo AS ConfiguracoesLayoutContratoCorpo FROM LayoutContrato WHERE LayoutContratoId = :ConfiguracoesLayoutProposta ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001919,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001920", "SELECT LayoutContratoCorpo AS ConfigLayoutCorpoPromissoriaClinicaEmprestimo FROM LayoutContrato WHERE LayoutContratoId = :ConfigLayoutPromissoriaClinicaEmprestimo ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001920,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001921", "SELECT LayoutContratoCorpo AS ConfigLayoutCorpoPromissoriaClinicaTaxa FROM LayoutContrato WHERE LayoutContratoId = :ConfigLayoutPromissoriaClinicaTaxa ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001921,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001922", "SELECT LayoutContratoCorpo AS ConfigLayoutCorpoPromissoriaPaciente FROM LayoutContrato WHERE LayoutContratoId = :ConfigLayoutPromissoriaPaciente ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001922,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001923", cmdBufferBC001923,true, GxErrorMask.GX_NOMASK, false, this,prmBC001923,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
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
                ((bool[]) buf[25])[0] = rslt.getBool(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((decimal[]) buf[29])[0] = rslt.getDecimal(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((decimal[]) buf[35])[0] = rslt.getDecimal(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((short[]) buf[41])[0] = rslt.getShort(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((short[]) buf[43])[0] = rslt.getShort(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((short[]) buf[45])[0] = rslt.getShort(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((short[]) buf[47])[0] = rslt.getShort(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((short[]) buf[49])[0] = rslt.getShort(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((int[]) buf[51])[0] = rslt.getInt(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((string[]) buf[53])[0] = rslt.getBLOBFile(28, rslt.getVarchar(20), rslt.getVarchar(21));
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((string[]) buf[55])[0] = rslt.getBLOBFile(29, "tmp", "");
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((string[]) buf[57])[0] = rslt.getBLOBFile(30, "tmp", "");
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
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
                ((bool[]) buf[25])[0] = rslt.getBool(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((decimal[]) buf[29])[0] = rslt.getDecimal(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((decimal[]) buf[35])[0] = rslt.getDecimal(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((short[]) buf[41])[0] = rslt.getShort(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((short[]) buf[43])[0] = rslt.getShort(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((short[]) buf[45])[0] = rslt.getShort(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((short[]) buf[47])[0] = rslt.getShort(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((short[]) buf[49])[0] = rslt.getShort(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((int[]) buf[51])[0] = rslt.getInt(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((string[]) buf[53])[0] = rslt.getBLOBFile(28, rslt.getVarchar(20), rslt.getVarchar(21));
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((string[]) buf[55])[0] = rslt.getBLOBFile(29, "tmp", "");
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((string[]) buf[57])[0] = rslt.getBLOBFile(30, "tmp", "");
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getLongVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getLongVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getLongVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getLongVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((bool[]) buf[25])[0] = rslt.getBool(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((bool[]) buf[27])[0] = rslt.getBool(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((bool[]) buf[29])[0] = rslt.getBool(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((bool[]) buf[31])[0] = rslt.getBool(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((bool[]) buf[33])[0] = rslt.getBool(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((decimal[]) buf[35])[0] = rslt.getDecimal(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((decimal[]) buf[37])[0] = rslt.getDecimal(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((decimal[]) buf[39])[0] = rslt.getDecimal(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((string[]) buf[41])[0] = rslt.getVarchar(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((decimal[]) buf[43])[0] = rslt.getDecimal(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((string[]) buf[47])[0] = rslt.getVarchar(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((short[]) buf[49])[0] = rslt.getShort(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((short[]) buf[51])[0] = rslt.getShort(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((short[]) buf[53])[0] = rslt.getShort(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((short[]) buf[55])[0] = rslt.getShort(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((short[]) buf[57])[0] = rslt.getShort(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((int[]) buf[59])[0] = rslt.getInt(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((string[]) buf[61])[0] = rslt.getBLOBFile(32, rslt.getVarchar(24), rslt.getVarchar(25));
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((string[]) buf[63])[0] = rslt.getBLOBFile(33, "tmp", "");
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                ((string[]) buf[65])[0] = rslt.getBLOBFile(34, "tmp", "");
                ((bool[]) buf[66])[0] = rslt.wasNull(34);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 18 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 19 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 21 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getLongVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getLongVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getLongVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getLongVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((bool[]) buf[25])[0] = rslt.getBool(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((bool[]) buf[27])[0] = rslt.getBool(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((bool[]) buf[29])[0] = rslt.getBool(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((bool[]) buf[31])[0] = rslt.getBool(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((bool[]) buf[33])[0] = rslt.getBool(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((decimal[]) buf[35])[0] = rslt.getDecimal(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((decimal[]) buf[37])[0] = rslt.getDecimal(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((decimal[]) buf[39])[0] = rslt.getDecimal(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((string[]) buf[41])[0] = rslt.getVarchar(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((decimal[]) buf[43])[0] = rslt.getDecimal(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((string[]) buf[47])[0] = rslt.getVarchar(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((short[]) buf[49])[0] = rslt.getShort(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((short[]) buf[51])[0] = rslt.getShort(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((short[]) buf[53])[0] = rslt.getShort(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((short[]) buf[55])[0] = rslt.getShort(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((short[]) buf[57])[0] = rslt.getShort(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((int[]) buf[59])[0] = rslt.getInt(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((string[]) buf[61])[0] = rslt.getBLOBFile(32, rslt.getVarchar(24), rslt.getVarchar(25));
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((string[]) buf[63])[0] = rslt.getBLOBFile(33, "tmp", "");
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                ((string[]) buf[65])[0] = rslt.getBLOBFile(34, "tmp", "");
                ((bool[]) buf[66])[0] = rslt.wasNull(34);
                return;
       }
    }

 }

}
