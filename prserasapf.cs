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
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class prserasapf : GXProcedure
   {
      public prserasapf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prserasapf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PropostaId ,
                           string aP1_Tipo ,
                           out SdtSdConteudoRecomendaPF aP2_SdConteudoRecomendaPF )
      {
         this.AV25PropostaId = aP0_PropostaId;
         this.AV29Tipo = aP1_Tipo;
         this.AV10SdConteudoRecomendaPF = new SdtSdConteudoRecomendaPF(context) ;
         initialize();
         ExecuteImpl();
         aP2_SdConteudoRecomendaPF=this.AV10SdConteudoRecomendaPF;
      }

      public SdtSdConteudoRecomendaPF executeUdp( int aP0_PropostaId ,
                                                  string aP1_Tipo )
      {
         execute(aP0_PropostaId, aP1_Tipo, out aP2_SdConteudoRecomendaPF);
         return AV10SdConteudoRecomendaPF ;
      }

      public void executeSubmit( int aP0_PropostaId ,
                                 string aP1_Tipo ,
                                 out SdtSdConteudoRecomendaPF aP2_SdConteudoRecomendaPF )
      {
         this.AV25PropostaId = aP0_PropostaId;
         this.AV29Tipo = aP1_Tipo;
         this.AV10SdConteudoRecomendaPF = new SdtSdConteudoRecomendaPF(context) ;
         SubmitImpl();
         aP2_SdConteudoRecomendaPF=this.AV10SdConteudoRecomendaPF;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00CJ2 */
         pr_default.execute(0, new Object[] {AV25PropostaId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A323PropostaId = P00CJ2_A323PropostaId[0];
            A326PropostaValor = P00CJ2_A326PropostaValor[0];
            n326PropostaValor = P00CJ2_n326PropostaValor[0];
            A553PropostaResponsavelId = P00CJ2_A553PropostaResponsavelId[0];
            n553PropostaResponsavelId = P00CJ2_n553PropostaResponsavelId[0];
            A504PropostaPacienteClienteId = P00CJ2_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = P00CJ2_n504PropostaPacienteClienteId[0];
            AV27PropostaValor = A326PropostaValor;
            AV11ClienteId = ((StringUtil.StrCmp(AV29Tipo, "Paciente")==0) ? A504PropostaPacienteClienteId : A553PropostaResponsavelId);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Using cursor P00CJ3 */
         pr_default.execute(1, new Object[] {AV11ClienteId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A168ClienteId = P00CJ3_A168ClienteId[0];
            A169ClienteDocumento = P00CJ3_A169ClienteDocumento[0];
            n169ClienteDocumento = P00CJ3_n169ClienteDocumento[0];
            AV26ClienteDocumento = A169ClienteDocumento;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         AV8SdSerasaPFProposta = new SdtSdSerasaPFProposta(context);
         AV8SdSerasaPFProposta.gxTpr_Cpf = StringUtil.Trim( AV26ClienteDocumento);
         AV8SdSerasaPFProposta.gxTpr_Valoroperacao = StringUtil.StringReplace( StringUtil.Trim( StringUtil.Str( AV27PropostaValor, 18, 2)), ",", ".");
         AV8SdSerasaPFProposta.gxTpr_Politica = "1";
         AV8SdSerasaPFProposta.gxTpr_Codtipovenda = (decimal)(1);
         /* Using cursor P00CJ4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A765ConfiguracoesSerasaAnotacoesCompletas = P00CJ4_A765ConfiguracoesSerasaAnotacoesCompletas[0];
            n765ConfiguracoesSerasaAnotacoesCompletas = P00CJ4_n765ConfiguracoesSerasaAnotacoesCompletas[0];
            A766ConfiguracoesSerasaConsultaDetalhada = P00CJ4_A766ConfiguracoesSerasaConsultaDetalhada[0];
            n766ConfiguracoesSerasaConsultaDetalhada = P00CJ4_n766ConfiguracoesSerasaConsultaDetalhada[0];
            A767ConfiguracoesSerasaParticipacaoSocietaria = P00CJ4_A767ConfiguracoesSerasaParticipacaoSocietaria[0];
            n767ConfiguracoesSerasaParticipacaoSocietaria = P00CJ4_n767ConfiguracoesSerasaParticipacaoSocietaria[0];
            A769ConfiguracoesSerasaHistoricoPagamento = P00CJ4_A769ConfiguracoesSerasaHistoricoPagamento[0];
            n769ConfiguracoesSerasaHistoricoPagamento = P00CJ4_n769ConfiguracoesSerasaHistoricoPagamento[0];
            A768ConfiguracoesSerasaRendaEstimada = P00CJ4_A768ConfiguracoesSerasaRendaEstimada[0];
            n768ConfiguracoesSerasaRendaEstimada = P00CJ4_n768ConfiguracoesSerasaRendaEstimada[0];
            A299ConfiguracoesId = P00CJ4_A299ConfiguracoesId[0];
            AV8SdSerasaPFProposta.gxTpr_Informacoesadicionais.gxTpr_Anotacoescompletas = A765ConfiguracoesSerasaAnotacoesCompletas;
            AV8SdSerasaPFProposta.gxTpr_Informacoesadicionais.gxTpr_Consultasdetalhadasserasa = A766ConfiguracoesSerasaConsultaDetalhada;
            AV8SdSerasaPFProposta.gxTpr_Informacoesadicionais.gxTpr_Participacaosocietaria = A767ConfiguracoesSerasaParticipacaoSocietaria;
            AV8SdSerasaPFProposta.gxTpr_Informacoesadicionais.gxTpr_Historicopagamentopf = A769ConfiguracoesSerasaHistoricoPagamento;
            AV8SdSerasaPFProposta.gxTpr_Informacoesadicionais.gxTpr_Rendaestimada = A768ConfiguracoesSerasaRendaEstimada;
            pr_default.readNext(2);
         }
         pr_default.close(2);
         new prserasa_auth(context ).execute( out  AV9SdSerasaAuth) ;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9SdSerasaAuth.gxTpr_Tokentype)) )
         {
            new prrecomendapf(context ).execute(  AV9SdSerasaAuth,  AV8SdSerasaPFProposta, out  AV10SdConteudoRecomendaPF, out  AV28ResponseStatus) ;
            if ( AV28ResponseStatus == 200 )
            {
               AV24JSON = AV10SdConteudoRecomendaPF.ToJSonString(false, true);
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Numeroproposta)) )
               {
                  AV12Serasa = new SdtSerasa(context);
                  AV12Serasa.gxTpr_Clienteid = AV11ClienteId;
                  AV12Serasa.gxTpr_Serasanumeroproposta = AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Numeroproposta;
                  AV12Serasa.gxTpr_Serasapolitica = AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Politica;
                  AV12Serasa.gxTpr_Serasacreatedat = AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Criacao;
                  AV12Serasa.gxTpr_Serasatipovenda = AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Tipovenda;
                  AV12Serasa.gxTpr_Serasacodtipovenda = AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Codtipovenda;
                  AV12Serasa.gxTpr_Serasacodnivelrisco = AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Codnivelrisco;
                  AV12Serasa.gxTpr_Serasatiporecomendacao = AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Tiporecomendacao;
                  AV12Serasa.gxTpr_Serasarecomendacaovenda = AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Tiporecomendacao;
                  AV12Serasa.gxTpr_Serasacpfregular = AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Criteriosanalisados.gxTpr_Cpfregular;
                  AV12Serasa.gxTpr_Serasaretricaoativa = AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Criteriosanalisados.gxTpr_Semrestritivoativo;
                  AV12Serasa.gxTpr_Serasaprotestoativo = AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Criteriosanalisados.gxTpr_Semprotestosativos;
                  AV12Serasa.gxTpr_Serasabaixocomprometimento = AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Criteriosanalisados.gxTpr_Baixocomprometimentoderenda;
                  AV12Serasa.gxTpr_Serasavalorlimiterecomendado = AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Valorlimiterecomendado;
                  AV12Serasa.gxTpr_Serasafaixaderendaestimada = AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Faixarendaestimada;
                  AV12Serasa.gxTpr_Serasamensagemrendaestimada = AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Mensagemrendaestimada;
                  AV12Serasa.gxTpr_Serasaanotacoescompletas = AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Informacoesadicionais.gxTpr_Anotacoescompletas;
                  AV12Serasa.gxTpr_Serasaconsultasdetalhadas = AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Informacoesadicionais.gxTpr_Consultasdetalhadasserasa;
                  AV12Serasa.gxTpr_Serasaanotacoesconsultaspc = AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Informacoesadicionais.gxTpr_Anotacoesconsultasspc;
                  AV12Serasa.gxTpr_Serasaparticipacaosocietaria = AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Informacoesadicionais.gxTpr_Participacaosocietaria;
                  AV12Serasa.gxTpr_Serasarendaestimada = AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Informacoesadicionais.gxTpr_Rendaestimada;
                  AV12Serasa.gxTpr_Serasahistoricopagamentopf = AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Informacoesadicionais.gxTpr_Historicopagamentopf;
                  AV12Serasa.gxTpr_Serasarecomendacompleto = AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Informacoesadicionais.gxTpr_Recomendacompleto;
                  AV12Serasa.gxTpr_Serasascore = (short)(Math.Round(NumberUtil.Val( AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Score.gxTpr_Serasascore, "."), 18, MidpointRounding.ToEven));
                  AV12Serasa.gxTpr_Serasataxa = NumberUtil.Val( AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Score.gxTpr_Taxa, ".");
                  AV12Serasa.gxTpr_Serasamensagemscore = AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Mensagemscore;
                  AV12Serasa.gxTpr_Serasasituacaocpf = AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Identificacao.gxTpr_Situacaocpf;
                  AV12Serasa.gxTpr_Serasadatanascimento = AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Identificacao.gxTpr_Datanascimento;
                  AV12Serasa.gxTpr_Serasagenero = AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Identificacao.gxTpr_Genero;
                  AV12Serasa.gxTpr_Serasanomemae = AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Identificacao.gxTpr_Nomemae;
                  AV12Serasa.gxTpr_Serasagrafia = AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Identificacao.gxTpr_Grafia;
                  AV12Serasa.gxTpr_Serasajson = AV24JSON;
                  AV12Serasa.Save();
                  if ( AV12Serasa.Success() )
                  {
                     AV33GXV1 = 1;
                     while ( AV33GXV1 <= AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Chequesdevolvidos.Count )
                     {
                        AV14SdConteudoRecomendaPFCheques = ((SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem)AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Chequesdevolvidos.Item(AV33GXV1));
                        AV13SerasaCheques = new SdtSerasaCheques(context);
                        AV13SerasaCheques.gxTpr_Serasaid = AV12Serasa.gxTpr_Serasaid;
                        AV13SerasaCheques.gxTpr_Serasachequestotalcons = AV14SdConteudoRecomendaPFCheques.gxTpr_Totalconsultascheques;
                        AV13SerasaCheques.gxTpr_Serasachequesqtdsemfundo = AV14SdConteudoRecomendaPFCheques.gxTpr_Quantidadechequesemfundos;
                        AV13SerasaCheques.gxTpr_Serasachequesultocorsus = AV14SdConteudoRecomendaPFCheques.gxTpr_Dataultimaocorrenciachequesustado;
                        AV13SerasaCheques.gxTpr_Serasachequesvalorsemfundo = AV14SdConteudoRecomendaPFCheques.gxTpr_Valortotalchequesemfundos;
                        AV13SerasaCheques.gxTpr_Serasachequestotalsust = AV14SdConteudoRecomendaPFCheques.gxTpr_Quantidadetotalchequesustado;
                        AV13SerasaCheques.Save();
                        if ( AV13SerasaCheques.Fail() )
                        {
                        }
                        AV33GXV1 = (int)(AV33GXV1+1);
                     }
                     AV34GXV2 = 1;
                     while ( AV34GXV2 <= AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Anotacoescompletas.Count )
                     {
                        AV15SdConteudoRecomendaPFAnotacoesCompletas = ((SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem)AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Anotacoescompletas.Item(AV34GXV2));
                        AV35GXV3 = 1;
                        while ( AV35GXV3 <= AV15SdConteudoRecomendaPFAnotacoesCompletas.gxTpr_Acoesjudiciais.Count )
                        {
                           AV16SdConteudoRecomendaPFAcoesJudiciais = ((SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem)AV15SdConteudoRecomendaPFAnotacoesCompletas.gxTpr_Acoesjudiciais.Item(AV35GXV3));
                           AV17SerasaAcoes = new SdtSerasaAcoes(context);
                           AV17SerasaAcoes.gxTpr_Serasaid = AV12Serasa.gxTpr_Serasaid;
                           AV17SerasaAcoes.gxTpr_Serasaacoesdata = AV16SdConteudoRecomendaPFAcoesJudiciais.gxTpr_Dataocorrencia;
                           AV17SerasaAcoes.gxTpr_Serasaacoesnatureza = AV16SdConteudoRecomendaPFAcoesJudiciais.gxTpr_Natureza;
                           AV17SerasaAcoes.gxTpr_Serasaacoesvalor = AV16SdConteudoRecomendaPFAcoesJudiciais.gxTpr_Valor;
                           AV17SerasaAcoes.gxTpr_Serasaacoesdistribuidor = AV16SdConteudoRecomendaPFAcoesJudiciais.gxTpr_Distribuidor;
                           AV17SerasaAcoes.gxTpr_Serasaacoesvara = AV16SdConteudoRecomendaPFAcoesJudiciais.gxTpr_Vara;
                           AV17SerasaAcoes.gxTpr_Serasaacoescidade = AV16SdConteudoRecomendaPFAcoesJudiciais.gxTpr_Cidade;
                           AV17SerasaAcoes.gxTpr_Serasaacoesuf = AV16SdConteudoRecomendaPFAcoesJudiciais.gxTpr_Uf;
                           AV17SerasaAcoes.gxTpr_Serasaacoesprincipal = AV16SdConteudoRecomendaPFAcoesJudiciais.gxTpr_Principal;
                           AV17SerasaAcoes.gxTpr_Serasaacoestipomoeda = AV16SdConteudoRecomendaPFAcoesJudiciais.gxTpr_Tipomoeda;
                           AV17SerasaAcoes.gxTpr_Serasaacoesqtdoco = (short)(Math.Round(AV16SdConteudoRecomendaPFAcoesJudiciais.gxTpr_Qtdeocorrencia, 18, MidpointRounding.ToEven));
                           AV17SerasaAcoes.Save();
                           if ( AV17SerasaAcoes.Fail() )
                           {
                           }
                           AV35GXV3 = (int)(AV35GXV3+1);
                        }
                        AV34GXV2 = (int)(AV34GXV2+1);
                     }
                     AV36GXV4 = 1;
                     while ( AV36GXV4 <= AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Consultasdetalhadasserasa.Count )
                     {
                        AV18SdConteudoRecomendaPFDetalhada = ((SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem)AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Consultasdetalhadasserasa.Item(AV36GXV4));
                        AV37GXV5 = 1;
                        while ( AV37GXV5 <= AV18SdConteudoRecomendaPFDetalhada.gxTpr_Consultasserasa.Count )
                        {
                           AV19SdConteudoRecomendaPFConsultasItem = ((SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem)AV18SdConteudoRecomendaPFDetalhada.gxTpr_Consultasserasa.Item(AV37GXV5));
                           AV20SerasaOcorrencias = new SdtSerasaOcorrencias(context);
                           AV20SerasaOcorrencias.gxTpr_Serasaid = AV12Serasa.gxTpr_Serasaid;
                           AV20SerasaOcorrencias.gxTpr_Serasaocorrenciasdata = AV19SdConteudoRecomendaPFConsultasItem.gxTpr_Dataocorrencia;
                           AV20SerasaOcorrencias.gxTpr_Serasaocorrenciasorigem = AV19SdConteudoRecomendaPFConsultasItem.gxTpr_Origem;
                           AV20SerasaOcorrencias.gxTpr_Serasaocorrenciasmodalidade = AV19SdConteudoRecomendaPFConsultasItem.gxTpr_Modalidade;
                           AV20SerasaOcorrencias.gxTpr_Serasaocorrenciastipomoeda = AV19SdConteudoRecomendaPFConsultasItem.gxTpr_Tipomoeda;
                           AV20SerasaOcorrencias.gxTpr_Serasaocorrenciasvalor = AV19SdConteudoRecomendaPFConsultasItem.gxTpr_Valor;
                           AV20SerasaOcorrencias.Save();
                           if ( AV20SerasaOcorrencias.Fail() )
                           {
                           }
                           AV37GXV5 = (int)(AV37GXV5+1);
                        }
                        AV36GXV4 = (int)(AV36GXV4+1);
                     }
                     AV38GXV6 = 1;
                     while ( AV38GXV6 <= AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Anotacoesnegativas.Count )
                     {
                        AV21SdConteudoRecomendaPFAnotNegativas = ((SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem)AV10SdConteudoRecomendaPF.gxTpr_Data.gxTpr_Anotacoesnegativas.Item(AV38GXV6));
                        AV39GXV7 = 1;
                        while ( AV39GXV7 <= AV21SdConteudoRecomendaPFAnotNegativas.gxTpr_Protestos.Count )
                        {
                           AV22SdConteudoRecomendaPFProtestos = ((SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem)AV21SdConteudoRecomendaPFAnotNegativas.gxTpr_Protestos.Item(AV39GXV7));
                           AV23SerasaProtestos = new SdtSerasaProtestos(context);
                           AV23SerasaProtestos.gxTpr_Serasaid = AV12Serasa.gxTpr_Serasaid;
                           AV23SerasaProtestos.gxTpr_Serasaprotestosdata = AV22SdConteudoRecomendaPFProtestos.gxTpr_Dataocorrencia;
                           AV23SerasaProtestos.gxTpr_Serasaprotestosvalor = AV22SdConteudoRecomendaPFProtestos.gxTpr_Valor;
                           AV23SerasaProtestos.gxTpr_Serasaprotestoscartorio = AV22SdConteudoRecomendaPFProtestos.gxTpr_Cartorio;
                           AV23SerasaProtestos.gxTpr_Serasaprotestoscidade = AV22SdConteudoRecomendaPFProtestos.gxTpr_Cidade;
                           AV23SerasaProtestos.Save();
                           if ( AV23SerasaProtestos.Fail() )
                           {
                           }
                           AV39GXV7 = (int)(AV39GXV7+1);
                        }
                        AV38GXV6 = (int)(AV38GXV6+1);
                     }
                     context.CommitDataStores("prserasapf",pr_default);
                  }
                  else
                  {
                  }
               }
            }
         }
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV10SdConteudoRecomendaPF = new SdtSdConteudoRecomendaPF(context);
         P00CJ2_A323PropostaId = new int[1] ;
         P00CJ2_A326PropostaValor = new decimal[1] ;
         P00CJ2_n326PropostaValor = new bool[] {false} ;
         P00CJ2_A553PropostaResponsavelId = new int[1] ;
         P00CJ2_n553PropostaResponsavelId = new bool[] {false} ;
         P00CJ2_A504PropostaPacienteClienteId = new int[1] ;
         P00CJ2_n504PropostaPacienteClienteId = new bool[] {false} ;
         P00CJ3_A168ClienteId = new int[1] ;
         P00CJ3_A169ClienteDocumento = new string[] {""} ;
         P00CJ3_n169ClienteDocumento = new bool[] {false} ;
         A169ClienteDocumento = "";
         AV26ClienteDocumento = "";
         AV8SdSerasaPFProposta = new SdtSdSerasaPFProposta(context);
         P00CJ4_A765ConfiguracoesSerasaAnotacoesCompletas = new bool[] {false} ;
         P00CJ4_n765ConfiguracoesSerasaAnotacoesCompletas = new bool[] {false} ;
         P00CJ4_A766ConfiguracoesSerasaConsultaDetalhada = new bool[] {false} ;
         P00CJ4_n766ConfiguracoesSerasaConsultaDetalhada = new bool[] {false} ;
         P00CJ4_A767ConfiguracoesSerasaParticipacaoSocietaria = new bool[] {false} ;
         P00CJ4_n767ConfiguracoesSerasaParticipacaoSocietaria = new bool[] {false} ;
         P00CJ4_A769ConfiguracoesSerasaHistoricoPagamento = new bool[] {false} ;
         P00CJ4_n769ConfiguracoesSerasaHistoricoPagamento = new bool[] {false} ;
         P00CJ4_A768ConfiguracoesSerasaRendaEstimada = new bool[] {false} ;
         P00CJ4_n768ConfiguracoesSerasaRendaEstimada = new bool[] {false} ;
         P00CJ4_A299ConfiguracoesId = new int[1] ;
         AV9SdSerasaAuth = new SdtSdSerasaAuth(context);
         AV24JSON = "";
         AV12Serasa = new SdtSerasa(context);
         AV14SdConteudoRecomendaPFCheques = new SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem(context);
         AV13SerasaCheques = new SdtSerasaCheques(context);
         AV15SdConteudoRecomendaPFAnotacoesCompletas = new SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem(context);
         AV16SdConteudoRecomendaPFAcoesJudiciais = new SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem(context);
         AV17SerasaAcoes = new SdtSerasaAcoes(context);
         AV18SdConteudoRecomendaPFDetalhada = new SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem(context);
         AV19SdConteudoRecomendaPFConsultasItem = new SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem(context);
         AV20SerasaOcorrencias = new SdtSerasaOcorrencias(context);
         AV21SdConteudoRecomendaPFAnotNegativas = new SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem(context);
         AV22SdConteudoRecomendaPFProtestos = new SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem(context);
         AV23SerasaProtestos = new SdtSerasaProtestos(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prserasapf__default(),
            new Object[][] {
                new Object[] {
               P00CJ2_A323PropostaId, P00CJ2_A326PropostaValor, P00CJ2_n326PropostaValor, P00CJ2_A553PropostaResponsavelId, P00CJ2_n553PropostaResponsavelId, P00CJ2_A504PropostaPacienteClienteId, P00CJ2_n504PropostaPacienteClienteId
               }
               , new Object[] {
               P00CJ3_A168ClienteId, P00CJ3_A169ClienteDocumento, P00CJ3_n169ClienteDocumento
               }
               , new Object[] {
               P00CJ4_A765ConfiguracoesSerasaAnotacoesCompletas, P00CJ4_n765ConfiguracoesSerasaAnotacoesCompletas, P00CJ4_A766ConfiguracoesSerasaConsultaDetalhada, P00CJ4_n766ConfiguracoesSerasaConsultaDetalhada, P00CJ4_A767ConfiguracoesSerasaParticipacaoSocietaria, P00CJ4_n767ConfiguracoesSerasaParticipacaoSocietaria, P00CJ4_A769ConfiguracoesSerasaHistoricoPagamento, P00CJ4_n769ConfiguracoesSerasaHistoricoPagamento, P00CJ4_A768ConfiguracoesSerasaRendaEstimada, P00CJ4_n768ConfiguracoesSerasaRendaEstimada,
               P00CJ4_A299ConfiguracoesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV28ResponseStatus ;
      private int AV25PropostaId ;
      private int A323PropostaId ;
      private int A553PropostaResponsavelId ;
      private int A504PropostaPacienteClienteId ;
      private int AV11ClienteId ;
      private int A168ClienteId ;
      private int A299ConfiguracoesId ;
      private int AV33GXV1 ;
      private int AV34GXV2 ;
      private int AV35GXV3 ;
      private int AV36GXV4 ;
      private int AV37GXV5 ;
      private int AV38GXV6 ;
      private int AV39GXV7 ;
      private decimal A326PropostaValor ;
      private decimal AV27PropostaValor ;
      private bool n326PropostaValor ;
      private bool n553PropostaResponsavelId ;
      private bool n504PropostaPacienteClienteId ;
      private bool n169ClienteDocumento ;
      private bool A765ConfiguracoesSerasaAnotacoesCompletas ;
      private bool n765ConfiguracoesSerasaAnotacoesCompletas ;
      private bool A766ConfiguracoesSerasaConsultaDetalhada ;
      private bool n766ConfiguracoesSerasaConsultaDetalhada ;
      private bool A767ConfiguracoesSerasaParticipacaoSocietaria ;
      private bool n767ConfiguracoesSerasaParticipacaoSocietaria ;
      private bool A769ConfiguracoesSerasaHistoricoPagamento ;
      private bool n769ConfiguracoesSerasaHistoricoPagamento ;
      private bool A768ConfiguracoesSerasaRendaEstimada ;
      private bool n768ConfiguracoesSerasaRendaEstimada ;
      private string AV24JSON ;
      private string AV29Tipo ;
      private string A169ClienteDocumento ;
      private string AV26ClienteDocumento ;
      private IGxDataStore dsDefault ;
      private SdtSdConteudoRecomendaPF AV10SdConteudoRecomendaPF ;
      private IDataStoreProvider pr_default ;
      private int[] P00CJ2_A323PropostaId ;
      private decimal[] P00CJ2_A326PropostaValor ;
      private bool[] P00CJ2_n326PropostaValor ;
      private int[] P00CJ2_A553PropostaResponsavelId ;
      private bool[] P00CJ2_n553PropostaResponsavelId ;
      private int[] P00CJ2_A504PropostaPacienteClienteId ;
      private bool[] P00CJ2_n504PropostaPacienteClienteId ;
      private int[] P00CJ3_A168ClienteId ;
      private string[] P00CJ3_A169ClienteDocumento ;
      private bool[] P00CJ3_n169ClienteDocumento ;
      private SdtSdSerasaPFProposta AV8SdSerasaPFProposta ;
      private bool[] P00CJ4_A765ConfiguracoesSerasaAnotacoesCompletas ;
      private bool[] P00CJ4_n765ConfiguracoesSerasaAnotacoesCompletas ;
      private bool[] P00CJ4_A766ConfiguracoesSerasaConsultaDetalhada ;
      private bool[] P00CJ4_n766ConfiguracoesSerasaConsultaDetalhada ;
      private bool[] P00CJ4_A767ConfiguracoesSerasaParticipacaoSocietaria ;
      private bool[] P00CJ4_n767ConfiguracoesSerasaParticipacaoSocietaria ;
      private bool[] P00CJ4_A769ConfiguracoesSerasaHistoricoPagamento ;
      private bool[] P00CJ4_n769ConfiguracoesSerasaHistoricoPagamento ;
      private bool[] P00CJ4_A768ConfiguracoesSerasaRendaEstimada ;
      private bool[] P00CJ4_n768ConfiguracoesSerasaRendaEstimada ;
      private int[] P00CJ4_A299ConfiguracoesId ;
      private SdtSdSerasaAuth AV9SdSerasaAuth ;
      private SdtSerasa AV12Serasa ;
      private SdtSdConteudoRecomendaPF_data_chequesDevolvidosItem AV14SdConteudoRecomendaPFCheques ;
      private SdtSerasaCheques AV13SerasaCheques ;
      private SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem AV15SdConteudoRecomendaPFAnotacoesCompletas ;
      private SdtSdConteudoRecomendaPF_data_anotacoesCompletasItem_acoesJudiciaisItem AV16SdConteudoRecomendaPFAcoesJudiciais ;
      private SdtSerasaAcoes AV17SerasaAcoes ;
      private SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem AV18SdConteudoRecomendaPFDetalhada ;
      private SdtSdConteudoRecomendaPF_data_consultasDetalhadasSerasaItem_consultasSerasaItem AV19SdConteudoRecomendaPFConsultasItem ;
      private SdtSerasaOcorrencias AV20SerasaOcorrencias ;
      private SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem AV21SdConteudoRecomendaPFAnotNegativas ;
      private SdtSdConteudoRecomendaPF_data_anotacoesNegativasItem_protestosItem AV22SdConteudoRecomendaPFProtestos ;
      private SdtSerasaProtestos AV23SerasaProtestos ;
      private SdtSdConteudoRecomendaPF aP2_SdConteudoRecomendaPF ;
   }

   public class prserasapf__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00CJ2;
          prmP00CJ2 = new Object[] {
          new ParDef("AV25PropostaId",GXType.Int32,9,0)
          };
          Object[] prmP00CJ3;
          prmP00CJ3 = new Object[] {
          new ParDef("AV11ClienteId",GXType.Int32,9,0)
          };
          Object[] prmP00CJ4;
          prmP00CJ4 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00CJ2", "SELECT PropostaId, PropostaValor, PropostaResponsavelId, PropostaPacienteClienteId FROM Proposta WHERE PropostaId = :AV25PropostaId ORDER BY PropostaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CJ2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00CJ3", "SELECT ClienteId, ClienteDocumento FROM Cliente WHERE ClienteId = :AV11ClienteId ORDER BY ClienteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CJ3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00CJ4", "SELECT ConfiguracoesSerasaAnotacoesCompletas, ConfiguracoesSerasaConsultaDetalhada, ConfiguracoesSerasaParticipacaoSocietaria, ConfiguracoesSerasaHistoricoPagamento, ConfiguracoesSerasaRendaEstimada, ConfiguracoesId FROM Configuracoes ORDER BY ConfiguracoesId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CJ4,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 2 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((bool[]) buf[6])[0] = rslt.getBool(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((bool[]) buf[8])[0] = rslt.getBool(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                return;
       }
    }

 }

}
