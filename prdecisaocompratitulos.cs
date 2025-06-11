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
   public class prdecisaocompratitulos : GXProcedure
   {
      public prdecisaocompratitulos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prdecisaocompratitulos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PropostaId ,
                           string aP1_Decisao ,
                           string aP2_AprovacaoStatus ,
                           out SdtSdErro aP3_SdErro )
      {
         this.AV11PropostaId = aP0_PropostaId;
         this.AV10Decisao = aP1_Decisao;
         this.AV14AprovacaoStatus = aP2_AprovacaoStatus;
         this.AV9SdErro = new SdtSdErro(context) ;
         initialize();
         ExecuteImpl();
         aP3_SdErro=this.AV9SdErro;
      }

      public SdtSdErro executeUdp( int aP0_PropostaId ,
                                   string aP1_Decisao ,
                                   string aP2_AprovacaoStatus )
      {
         execute(aP0_PropostaId, aP1_Decisao, aP2_AprovacaoStatus, out aP3_SdErro);
         return AV9SdErro ;
      }

      public void executeSubmit( int aP0_PropostaId ,
                                 string aP1_Decisao ,
                                 string aP2_AprovacaoStatus ,
                                 out SdtSdErro aP3_SdErro )
      {
         this.AV11PropostaId = aP0_PropostaId;
         this.AV10Decisao = aP1_Decisao;
         this.AV14AprovacaoStatus = aP2_AprovacaoStatus;
         this.AV9SdErro = new SdtSdErro(context) ;
         SubmitImpl();
         aP3_SdErro=this.AV9SdErro;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_SdtWWPContext1 = AV12WWPContext;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext1) ;
         AV12WWPContext = GXt_SdtWWPContext1;
         AV13Aprovacao = new SdtAprovacao(context);
         AV13Aprovacao.gxTpr_Propostaid = AV11PropostaId;
         AV13Aprovacao.gxTpr_Aprovacaostatus = AV14AprovacaoStatus;
         AV13Aprovacao.gxTpr_Aprovacaoem = DateTimeUtil.ServerNow( context, pr_default);
         AV13Aprovacao.gxTpr_Aprovacaodecisao = AV10Decisao;
         AV13Aprovacao.gxTpr_Aprovadoresid = AV12WWPContext.gxTpr_Aprovadorid;
         AV13Aprovacao.Save();
         if ( AV13Aprovacao.Success() )
         {
            /* Execute user subroutine: 'FINALIZAAPROVACOES' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            context.CommitDataStores("prdecisaocompratitulos",pr_default);
            AV9SdErro.gxTpr_Internalcode = 0;
            AV9SdErro.gxTpr_Msg = ((StringUtil.StrCmp(AV14AprovacaoStatus, "APROVADO")==0) ? "Prosposta aprovada!" : "Proposta reprovada.");
         }
         else
         {
            context.RollbackDataStores("prdecisaocompratitulos",pr_default);
            AV9SdErro.gxTpr_Internalcode = 1;
            AV9SdErro.gxTpr_Msg = ((GeneXus.Utils.SdtMessages_Message)AV13Aprovacao.GetMessages().Item(1)).gxTpr_Description;
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'FINALIZAAPROVACOES' Routine */
         returnInSub = false;
         AV36Proposta.Load(AV11PropostaId);
         AV36Proposta.gxTpr_Propostastatus = "APROVADO";
         AV36Proposta.Save();
         if ( AV36Proposta.Success() )
         {
            /* Using cursor P00EB3 */
            pr_default.execute(0, new Object[] {AV11PropostaId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A323PropostaId = P00EB3_A323PropostaId[0];
               n323PropostaId = P00EB3_n323PropostaId[0];
               A855PropostaValorLiquido = P00EB3_A855PropostaValorLiquido[0];
               n855PropostaValorLiquido = P00EB3_n855PropostaValorLiquido[0];
               A850PropostaEmpresaClienteId = P00EB3_A850PropostaEmpresaClienteId[0];
               n850PropostaEmpresaClienteId = P00EB3_n850PropostaEmpresaClienteId[0];
               A40000GXC1 = P00EB3_A40000GXC1[0];
               n40000GXC1 = P00EB3_n40000GXC1[0];
               A40000GXC1 = P00EB3_A40000GXC1[0];
               n40000GXC1 = P00EB3_n40000GXC1[0];
               AV17PropostaValorLiquido = A855PropostaValorLiquido;
               AV18PropostaEmpresaClienteId = A850PropostaEmpresaClienteId;
               AV30NotaFiscalid = A40000GXC1;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00EB4 */
            pr_default.execute(1, new Object[] {AV18PropostaEmpresaClienteId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A168ClienteId = P00EB4_A168ClienteId[0];
               n168ClienteId = P00EB4_n168ClienteId[0];
               A181EnderecoTipo = P00EB4_A181EnderecoTipo[0];
               n181EnderecoTipo = P00EB4_n181EnderecoTipo[0];
               A190EnderecoNumero = P00EB4_A190EnderecoNumero[0];
               n190EnderecoNumero = P00EB4_n190EnderecoNumero[0];
               A183EnderecoLogradouro = P00EB4_A183EnderecoLogradouro[0];
               n183EnderecoLogradouro = P00EB4_n183EnderecoLogradouro[0];
               A191EnderecoComplemento = P00EB4_A191EnderecoComplemento[0];
               n191EnderecoComplemento = P00EB4_n191EnderecoComplemento[0];
               A185EnderecoCidade = P00EB4_A185EnderecoCidade[0];
               n185EnderecoCidade = P00EB4_n185EnderecoCidade[0];
               A182EnderecoCEP = P00EB4_A182EnderecoCEP[0];
               n182EnderecoCEP = P00EB4_n182EnderecoCEP[0];
               A184EnderecoBairro = P00EB4_A184EnderecoBairro[0];
               n184EnderecoBairro = P00EB4_n184EnderecoBairro[0];
               A186MunicipioCodigo = P00EB4_A186MunicipioCodigo[0];
               n186MunicipioCodigo = P00EB4_n186MunicipioCodigo[0];
               AV19EnderecoTipo = A181EnderecoTipo;
               AV24EnderecoNumero = A190EnderecoNumero;
               AV23EnderecoLogradouro = A183EnderecoLogradouro;
               AV22EnderecoComplemento = A191EnderecoComplemento;
               AV20EnderecoCidade = A185EnderecoCidade;
               AV26EnderecoCEP = A182EnderecoCEP;
               AV21EnderecoBairro = A184EnderecoBairro;
               AV27MunicipioCodigo = A186MunicipioCodigo;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Execute user subroutine: 'TITULO_A_PAGAR' */
            S121 ();
            if (returnInSub) return;
            /* Using cursor P00EB5 */
            pr_default.execute(2, new Object[] {AV30NotaFiscalid});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A794NotaFiscalId = P00EB5_A794NotaFiscalId[0];
               n794NotaFiscalId = P00EB5_n794NotaFiscalId[0];
               A889NotaFiscalDestinatarioClienteId = P00EB5_A889NotaFiscalDestinatarioClienteId[0];
               n889NotaFiscalDestinatarioClienteId = P00EB5_n889NotaFiscalDestinatarioClienteId[0];
               A168ClienteId = P00EB5_A168ClienteId[0];
               n168ClienteId = P00EB5_n168ClienteId[0];
               A181EnderecoTipo = P00EB5_A181EnderecoTipo[0];
               n181EnderecoTipo = P00EB5_n181EnderecoTipo[0];
               A190EnderecoNumero = P00EB5_A190EnderecoNumero[0];
               n190EnderecoNumero = P00EB5_n190EnderecoNumero[0];
               A183EnderecoLogradouro = P00EB5_A183EnderecoLogradouro[0];
               n183EnderecoLogradouro = P00EB5_n183EnderecoLogradouro[0];
               A191EnderecoComplemento = P00EB5_A191EnderecoComplemento[0];
               n191EnderecoComplemento = P00EB5_n191EnderecoComplemento[0];
               A185EnderecoCidade = P00EB5_A185EnderecoCidade[0];
               n185EnderecoCidade = P00EB5_n185EnderecoCidade[0];
               A182EnderecoCEP = P00EB5_A182EnderecoCEP[0];
               n182EnderecoCEP = P00EB5_n182EnderecoCEP[0];
               A184EnderecoBairro = P00EB5_A184EnderecoBairro[0];
               n184EnderecoBairro = P00EB5_n184EnderecoBairro[0];
               A186MunicipioCodigo = P00EB5_A186MunicipioCodigo[0];
               n186MunicipioCodigo = P00EB5_n186MunicipioCodigo[0];
               A181EnderecoTipo = P00EB5_A181EnderecoTipo[0];
               n181EnderecoTipo = P00EB5_n181EnderecoTipo[0];
               A190EnderecoNumero = P00EB5_A190EnderecoNumero[0];
               n190EnderecoNumero = P00EB5_n190EnderecoNumero[0];
               A183EnderecoLogradouro = P00EB5_A183EnderecoLogradouro[0];
               n183EnderecoLogradouro = P00EB5_n183EnderecoLogradouro[0];
               A191EnderecoComplemento = P00EB5_A191EnderecoComplemento[0];
               n191EnderecoComplemento = P00EB5_n191EnderecoComplemento[0];
               A185EnderecoCidade = P00EB5_A185EnderecoCidade[0];
               n185EnderecoCidade = P00EB5_n185EnderecoCidade[0];
               A182EnderecoCEP = P00EB5_A182EnderecoCEP[0];
               n182EnderecoCEP = P00EB5_n182EnderecoCEP[0];
               A184EnderecoBairro = P00EB5_A184EnderecoBairro[0];
               n184EnderecoBairro = P00EB5_n184EnderecoBairro[0];
               A186MunicipioCodigo = P00EB5_A186MunicipioCodigo[0];
               n186MunicipioCodigo = P00EB5_n186MunicipioCodigo[0];
               while ( (pr_default.getStatus(2) != 101) && ( P00EB5_A794NotaFiscalId[0] == A794NotaFiscalId ) )
               {
                  A889NotaFiscalDestinatarioClienteId = P00EB5_A889NotaFiscalDestinatarioClienteId[0];
                  n889NotaFiscalDestinatarioClienteId = P00EB5_n889NotaFiscalDestinatarioClienteId[0];
                  A168ClienteId = P00EB5_A168ClienteId[0];
                  n168ClienteId = P00EB5_n168ClienteId[0];
                  A181EnderecoTipo = P00EB5_A181EnderecoTipo[0];
                  n181EnderecoTipo = P00EB5_n181EnderecoTipo[0];
                  A190EnderecoNumero = P00EB5_A190EnderecoNumero[0];
                  n190EnderecoNumero = P00EB5_n190EnderecoNumero[0];
                  A183EnderecoLogradouro = P00EB5_A183EnderecoLogradouro[0];
                  n183EnderecoLogradouro = P00EB5_n183EnderecoLogradouro[0];
                  A191EnderecoComplemento = P00EB5_A191EnderecoComplemento[0];
                  n191EnderecoComplemento = P00EB5_n191EnderecoComplemento[0];
                  A185EnderecoCidade = P00EB5_A185EnderecoCidade[0];
                  n185EnderecoCidade = P00EB5_n185EnderecoCidade[0];
                  A182EnderecoCEP = P00EB5_A182EnderecoCEP[0];
                  n182EnderecoCEP = P00EB5_n182EnderecoCEP[0];
                  A184EnderecoBairro = P00EB5_A184EnderecoBairro[0];
                  n184EnderecoBairro = P00EB5_n184EnderecoBairro[0];
                  A186MunicipioCodigo = P00EB5_A186MunicipioCodigo[0];
                  n186MunicipioCodigo = P00EB5_n186MunicipioCodigo[0];
                  A181EnderecoTipo = P00EB5_A181EnderecoTipo[0];
                  n181EnderecoTipo = P00EB5_n181EnderecoTipo[0];
                  A190EnderecoNumero = P00EB5_A190EnderecoNumero[0];
                  n190EnderecoNumero = P00EB5_n190EnderecoNumero[0];
                  A183EnderecoLogradouro = P00EB5_A183EnderecoLogradouro[0];
                  n183EnderecoLogradouro = P00EB5_n183EnderecoLogradouro[0];
                  A191EnderecoComplemento = P00EB5_A191EnderecoComplemento[0];
                  n191EnderecoComplemento = P00EB5_n191EnderecoComplemento[0];
                  A185EnderecoCidade = P00EB5_A185EnderecoCidade[0];
                  n185EnderecoCidade = P00EB5_n185EnderecoCidade[0];
                  A182EnderecoCEP = P00EB5_A182EnderecoCEP[0];
                  n182EnderecoCEP = P00EB5_n182EnderecoCEP[0];
                  A184EnderecoBairro = P00EB5_A184EnderecoBairro[0];
                  n184EnderecoBairro = P00EB5_n184EnderecoBairro[0];
                  A186MunicipioCodigo = P00EB5_A186MunicipioCodigo[0];
                  n186MunicipioCodigo = P00EB5_n186MunicipioCodigo[0];
                  if ( A168ClienteId == A889NotaFiscalDestinatarioClienteId )
                  {
                     AV19EnderecoTipo = A181EnderecoTipo;
                     AV24EnderecoNumero = A190EnderecoNumero;
                     AV23EnderecoLogradouro = A183EnderecoLogradouro;
                     AV22EnderecoComplemento = A191EnderecoComplemento;
                     AV20EnderecoCidade = A185EnderecoCidade;
                     AV26EnderecoCEP = A182EnderecoCEP;
                     AV21EnderecoBairro = A184EnderecoBairro;
                     AV27MunicipioCodigo = A186MunicipioCodigo;
                  }
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            /* Using cursor P00EB6 */
            pr_default.execute(3, new Object[] {AV30NotaFiscalid});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A794NotaFiscalId = P00EB6_A794NotaFiscalId[0];
               n794NotaFiscalId = P00EB6_n794NotaFiscalId[0];
               A889NotaFiscalDestinatarioClienteId = P00EB6_A889NotaFiscalDestinatarioClienteId[0];
               n889NotaFiscalDestinatarioClienteId = P00EB6_n889NotaFiscalDestinatarioClienteId[0];
               A897NotaFiscalParcelamentoLiquido = P00EB6_A897NotaFiscalParcelamentoLiquido[0];
               n897NotaFiscalParcelamentoLiquido = P00EB6_n897NotaFiscalParcelamentoLiquido[0];
               A893NotaFiscalParcelamentoVencimento = P00EB6_A893NotaFiscalParcelamentoVencimento[0];
               n893NotaFiscalParcelamentoVencimento = P00EB6_n893NotaFiscalParcelamentoVencimento[0];
               A890NotaFiscalParcelamentoID = P00EB6_A890NotaFiscalParcelamentoID[0];
               A892NotaFiscalParcelamentoValor = P00EB6_A892NotaFiscalParcelamentoValor[0];
               n892NotaFiscalParcelamentoValor = P00EB6_n892NotaFiscalParcelamentoValor[0];
               A889NotaFiscalDestinatarioClienteId = P00EB6_A889NotaFiscalDestinatarioClienteId[0];
               n889NotaFiscalDestinatarioClienteId = P00EB6_n889NotaFiscalDestinatarioClienteId[0];
               AV33NotaFiscalDestinatarioClienteId = A889NotaFiscalDestinatarioClienteId;
               AV31NotaFiscalParcelamentoLiquido = A897NotaFiscalParcelamentoLiquido;
               AV32NotaFiscalParcelamentoVencimento = A893NotaFiscalParcelamentoVencimento;
               AV34NotaFiscalParcelamentoId = A890NotaFiscalParcelamentoID;
               AV35notafiscalparcelamentovalor = A892NotaFiscalParcelamentoValor;
               /* Execute user subroutine: 'TITULO_A_RECEBER' */
               S136 ();
               if ( returnInSub )
               {
                  pr_default.close(3);
                  returnInSub = true;
                  if (true) return;
               }
               pr_default.readNext(3);
            }
            pr_default.close(3);
         }
         else
         {
            context.RollbackDataStores("prdecisaocompratitulos",pr_default);
            AV9SdErro.gxTpr_Internalcode = 1;
            AV9SdErro.gxTpr_Msg = ((GeneXus.Utils.SdtMessages_Message)AV36Proposta.GetMessages().Item(1)).gxTpr_Description;
         }
      }

      protected void S136( )
      {
         /* 'TITULO_A_RECEBER' Routine */
         returnInSub = false;
         AV15SdTitulo = new SdtSdTitulo(context);
         AV15SdTitulo.gxTpr_Clienteid = AV33NotaFiscalDestinatarioClienteId;
         AV15SdTitulo.gxTpr_Titulovalor = AV35notafiscalparcelamentovalor;
         AV15SdTitulo.gxTpr_Titulodesconto = (decimal)(0);
         AV15SdTitulo.gxTpr_Titulodeleted = false;
         AV15SdTitulo.gxTpr_Titulovencimento = AV32NotaFiscalParcelamentoVencimento;
         AV15SdTitulo.gxTpr_Tituloprorrogacao = AV32NotaFiscalParcelamentoVencimento;
         AV15SdTitulo.gxTpr_Titulocep = AV26EnderecoCEP;
         AV15SdTitulo.gxTpr_Titulologradouro = AV23EnderecoLogradouro;
         AV15SdTitulo.gxTpr_Titulonumeroendereco = AV24EnderecoNumero;
         AV15SdTitulo.gxTpr_Titulocomplemento = AV22EnderecoComplemento;
         AV15SdTitulo.gxTpr_Titulobairro = AV21EnderecoBairro;
         AV15SdTitulo.gxTpr_Titulomunicipio = AV27MunicipioCodigo;
         AV15SdTitulo.gxTpr_Titulotipo = "CREDITO";
         AV15SdTitulo.gxTpr_Titulocompetenciaano = (short)(DateTimeUtil.Year( AV32NotaFiscalParcelamentoVencimento));
         AV15SdTitulo.gxTpr_Titulojurosmora = (decimal)(0);
         AV15SdTitulo.gxTpr_Titulocompetenciames = (short)(DateTimeUtil.Month( AV32NotaFiscalParcelamentoVencimento));
         AV15SdTitulo.gxTpr_Propostaid = AV11PropostaId;
         AV15SdTitulo.gxTpr_Contaid = 3;
         AV15SdTitulo.gxTpr_Categoriatituloid = 2;
         AV15SdTitulo.gxTpr_Titulopropostatipo = "COMUM";
         AV15SdTitulo.gxTpr_Notafiscalparcelamentoid = AV34NotaFiscalParcelamentoId;
         new prcriartitulo(context ).execute( ref  AV15SdTitulo, out  AV9SdErro) ;
         if ( AV9SdErro.gxTpr_Internalcode != 0 )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S121( )
      {
         /* 'TITULO_A_PAGAR' Routine */
         returnInSub = false;
         AV28Vencimento = DateTimeUtil.ServerDate( context, pr_default);
         AV15SdTitulo = new SdtSdTitulo(context);
         AV15SdTitulo.gxTpr_Clienteid = AV18PropostaEmpresaClienteId;
         AV15SdTitulo.gxTpr_Titulovalor = AV17PropostaValorLiquido;
         AV15SdTitulo.gxTpr_Titulodesconto = (decimal)(0);
         AV15SdTitulo.gxTpr_Titulodeleted = false;
         AV15SdTitulo.gxTpr_Titulovencimento = AV28Vencimento;
         AV15SdTitulo.gxTpr_Tituloprorrogacao = AV28Vencimento;
         AV15SdTitulo.gxTpr_Titulocep = AV26EnderecoCEP;
         AV15SdTitulo.gxTpr_Titulologradouro = AV23EnderecoLogradouro;
         AV15SdTitulo.gxTpr_Titulonumeroendereco = AV24EnderecoNumero;
         AV15SdTitulo.gxTpr_Titulocomplemento = AV22EnderecoComplemento;
         AV15SdTitulo.gxTpr_Titulobairro = AV21EnderecoBairro;
         AV15SdTitulo.gxTpr_Titulomunicipio = AV27MunicipioCodigo;
         AV15SdTitulo.gxTpr_Titulotipo = "DEBITO";
         AV15SdTitulo.gxTpr_Titulocompetenciaano = (short)(DateTimeUtil.Year( AV28Vencimento));
         AV15SdTitulo.gxTpr_Titulojurosmora = (decimal)(0);
         AV15SdTitulo.gxTpr_Titulocompetenciames = (short)(DateTimeUtil.Month( AV28Vencimento));
         AV15SdTitulo.gxTpr_Propostaid = AV11PropostaId;
         AV15SdTitulo.gxTpr_Contaid = 3;
         AV15SdTitulo.gxTpr_Categoriatituloid = 2;
         AV15SdTitulo.gxTpr_Titulopropostatipo = "COMUM";
         new prcriartitulo(context ).execute( ref  AV15SdTitulo, out  AV9SdErro) ;
         if ( AV9SdErro.gxTpr_Internalcode != 0 )
         {
            returnInSub = true;
            if (true) return;
         }
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
         AV9SdErro = new SdtSdErro(context);
         AV12WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtWWPContext1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV13Aprovacao = new SdtAprovacao(context);
         AV36Proposta = new SdtProposta(context);
         P00EB3_A323PropostaId = new int[1] ;
         P00EB3_n323PropostaId = new bool[] {false} ;
         P00EB3_A855PropostaValorLiquido = new decimal[1] ;
         P00EB3_n855PropostaValorLiquido = new bool[] {false} ;
         P00EB3_A850PropostaEmpresaClienteId = new int[1] ;
         P00EB3_n850PropostaEmpresaClienteId = new bool[] {false} ;
         P00EB3_A40000GXC1 = new Guid[] {Guid.Empty} ;
         P00EB3_n40000GXC1 = new bool[] {false} ;
         A40000GXC1 = Guid.Empty;
         AV30NotaFiscalid = Guid.Empty;
         P00EB4_A168ClienteId = new int[1] ;
         P00EB4_n168ClienteId = new bool[] {false} ;
         P00EB4_A181EnderecoTipo = new string[] {""} ;
         P00EB4_n181EnderecoTipo = new bool[] {false} ;
         P00EB4_A190EnderecoNumero = new string[] {""} ;
         P00EB4_n190EnderecoNumero = new bool[] {false} ;
         P00EB4_A183EnderecoLogradouro = new string[] {""} ;
         P00EB4_n183EnderecoLogradouro = new bool[] {false} ;
         P00EB4_A191EnderecoComplemento = new string[] {""} ;
         P00EB4_n191EnderecoComplemento = new bool[] {false} ;
         P00EB4_A185EnderecoCidade = new string[] {""} ;
         P00EB4_n185EnderecoCidade = new bool[] {false} ;
         P00EB4_A182EnderecoCEP = new string[] {""} ;
         P00EB4_n182EnderecoCEP = new bool[] {false} ;
         P00EB4_A184EnderecoBairro = new string[] {""} ;
         P00EB4_n184EnderecoBairro = new bool[] {false} ;
         P00EB4_A186MunicipioCodigo = new string[] {""} ;
         P00EB4_n186MunicipioCodigo = new bool[] {false} ;
         A181EnderecoTipo = "";
         A190EnderecoNumero = "";
         A183EnderecoLogradouro = "";
         A191EnderecoComplemento = "";
         A185EnderecoCidade = "";
         A182EnderecoCEP = "";
         A184EnderecoBairro = "";
         A186MunicipioCodigo = "";
         AV19EnderecoTipo = "";
         AV24EnderecoNumero = "";
         AV23EnderecoLogradouro = "";
         AV22EnderecoComplemento = "";
         AV20EnderecoCidade = "";
         AV26EnderecoCEP = "";
         AV21EnderecoBairro = "";
         AV27MunicipioCodigo = "";
         P00EB5_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00EB5_n794NotaFiscalId = new bool[] {false} ;
         P00EB5_A889NotaFiscalDestinatarioClienteId = new int[1] ;
         P00EB5_n889NotaFiscalDestinatarioClienteId = new bool[] {false} ;
         P00EB5_A168ClienteId = new int[1] ;
         P00EB5_n168ClienteId = new bool[] {false} ;
         P00EB5_A181EnderecoTipo = new string[] {""} ;
         P00EB5_n181EnderecoTipo = new bool[] {false} ;
         P00EB5_A190EnderecoNumero = new string[] {""} ;
         P00EB5_n190EnderecoNumero = new bool[] {false} ;
         P00EB5_A183EnderecoLogradouro = new string[] {""} ;
         P00EB5_n183EnderecoLogradouro = new bool[] {false} ;
         P00EB5_A191EnderecoComplemento = new string[] {""} ;
         P00EB5_n191EnderecoComplemento = new bool[] {false} ;
         P00EB5_A185EnderecoCidade = new string[] {""} ;
         P00EB5_n185EnderecoCidade = new bool[] {false} ;
         P00EB5_A182EnderecoCEP = new string[] {""} ;
         P00EB5_n182EnderecoCEP = new bool[] {false} ;
         P00EB5_A184EnderecoBairro = new string[] {""} ;
         P00EB5_n184EnderecoBairro = new bool[] {false} ;
         P00EB5_A186MunicipioCodigo = new string[] {""} ;
         P00EB5_n186MunicipioCodigo = new bool[] {false} ;
         A794NotaFiscalId = Guid.Empty;
         P00EB6_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00EB6_n794NotaFiscalId = new bool[] {false} ;
         P00EB6_A889NotaFiscalDestinatarioClienteId = new int[1] ;
         P00EB6_n889NotaFiscalDestinatarioClienteId = new bool[] {false} ;
         P00EB6_A897NotaFiscalParcelamentoLiquido = new decimal[1] ;
         P00EB6_n897NotaFiscalParcelamentoLiquido = new bool[] {false} ;
         P00EB6_A893NotaFiscalParcelamentoVencimento = new DateTime[] {DateTime.MinValue} ;
         P00EB6_n893NotaFiscalParcelamentoVencimento = new bool[] {false} ;
         P00EB6_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         P00EB6_A892NotaFiscalParcelamentoValor = new decimal[1] ;
         P00EB6_n892NotaFiscalParcelamentoValor = new bool[] {false} ;
         A893NotaFiscalParcelamentoVencimento = DateTime.MinValue;
         A890NotaFiscalParcelamentoID = Guid.Empty;
         AV32NotaFiscalParcelamentoVencimento = DateTime.MinValue;
         AV34NotaFiscalParcelamentoId = Guid.Empty;
         AV15SdTitulo = new SdtSdTitulo(context);
         AV28Vencimento = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prdecisaocompratitulos__default(),
            new Object[][] {
                new Object[] {
               P00EB3_A323PropostaId, P00EB3_A855PropostaValorLiquido, P00EB3_n855PropostaValorLiquido, P00EB3_A850PropostaEmpresaClienteId, P00EB3_n850PropostaEmpresaClienteId, P00EB3_A40000GXC1, P00EB3_n40000GXC1
               }
               , new Object[] {
               P00EB4_A168ClienteId, P00EB4_A181EnderecoTipo, P00EB4_n181EnderecoTipo, P00EB4_A190EnderecoNumero, P00EB4_n190EnderecoNumero, P00EB4_A183EnderecoLogradouro, P00EB4_n183EnderecoLogradouro, P00EB4_A191EnderecoComplemento, P00EB4_n191EnderecoComplemento, P00EB4_A185EnderecoCidade,
               P00EB4_n185EnderecoCidade, P00EB4_A182EnderecoCEP, P00EB4_n182EnderecoCEP, P00EB4_A184EnderecoBairro, P00EB4_n184EnderecoBairro, P00EB4_A186MunicipioCodigo, P00EB4_n186MunicipioCodigo
               }
               , new Object[] {
               P00EB5_A794NotaFiscalId, P00EB5_A889NotaFiscalDestinatarioClienteId, P00EB5_n889NotaFiscalDestinatarioClienteId, P00EB5_A168ClienteId, P00EB5_n168ClienteId, P00EB5_A181EnderecoTipo, P00EB5_n181EnderecoTipo, P00EB5_A190EnderecoNumero, P00EB5_n190EnderecoNumero, P00EB5_A183EnderecoLogradouro,
               P00EB5_n183EnderecoLogradouro, P00EB5_A191EnderecoComplemento, P00EB5_n191EnderecoComplemento, P00EB5_A185EnderecoCidade, P00EB5_n185EnderecoCidade, P00EB5_A182EnderecoCEP, P00EB5_n182EnderecoCEP, P00EB5_A184EnderecoBairro, P00EB5_n184EnderecoBairro, P00EB5_A186MunicipioCodigo,
               P00EB5_n186MunicipioCodigo
               }
               , new Object[] {
               P00EB6_A794NotaFiscalId, P00EB6_n794NotaFiscalId, P00EB6_A889NotaFiscalDestinatarioClienteId, P00EB6_n889NotaFiscalDestinatarioClienteId, P00EB6_A897NotaFiscalParcelamentoLiquido, P00EB6_n897NotaFiscalParcelamentoLiquido, P00EB6_A893NotaFiscalParcelamentoVencimento, P00EB6_n893NotaFiscalParcelamentoVencimento, P00EB6_A890NotaFiscalParcelamentoID, P00EB6_A892NotaFiscalParcelamentoValor,
               P00EB6_n892NotaFiscalParcelamentoValor
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV11PropostaId ;
      private int A323PropostaId ;
      private int A850PropostaEmpresaClienteId ;
      private int AV18PropostaEmpresaClienteId ;
      private int A168ClienteId ;
      private int A889NotaFiscalDestinatarioClienteId ;
      private int AV33NotaFiscalDestinatarioClienteId ;
      private decimal A855PropostaValorLiquido ;
      private decimal AV17PropostaValorLiquido ;
      private decimal A897NotaFiscalParcelamentoLiquido ;
      private decimal A892NotaFiscalParcelamentoValor ;
      private decimal AV31NotaFiscalParcelamentoLiquido ;
      private decimal AV35notafiscalparcelamentovalor ;
      private DateTime A893NotaFiscalParcelamentoVencimento ;
      private DateTime AV32NotaFiscalParcelamentoVencimento ;
      private DateTime AV28Vencimento ;
      private bool returnInSub ;
      private bool n323PropostaId ;
      private bool n855PropostaValorLiquido ;
      private bool n850PropostaEmpresaClienteId ;
      private bool n40000GXC1 ;
      private bool n168ClienteId ;
      private bool n181EnderecoTipo ;
      private bool n190EnderecoNumero ;
      private bool n183EnderecoLogradouro ;
      private bool n191EnderecoComplemento ;
      private bool n185EnderecoCidade ;
      private bool n182EnderecoCEP ;
      private bool n184EnderecoBairro ;
      private bool n186MunicipioCodigo ;
      private bool n794NotaFiscalId ;
      private bool n889NotaFiscalDestinatarioClienteId ;
      private bool n897NotaFiscalParcelamentoLiquido ;
      private bool n893NotaFiscalParcelamentoVencimento ;
      private bool n892NotaFiscalParcelamentoValor ;
      private string AV10Decisao ;
      private string AV14AprovacaoStatus ;
      private string A181EnderecoTipo ;
      private string A190EnderecoNumero ;
      private string A183EnderecoLogradouro ;
      private string A191EnderecoComplemento ;
      private string A185EnderecoCidade ;
      private string A182EnderecoCEP ;
      private string A184EnderecoBairro ;
      private string A186MunicipioCodigo ;
      private string AV19EnderecoTipo ;
      private string AV24EnderecoNumero ;
      private string AV23EnderecoLogradouro ;
      private string AV22EnderecoComplemento ;
      private string AV20EnderecoCidade ;
      private string AV26EnderecoCEP ;
      private string AV21EnderecoBairro ;
      private string AV27MunicipioCodigo ;
      private Guid A40000GXC1 ;
      private Guid AV30NotaFiscalid ;
      private Guid A794NotaFiscalId ;
      private Guid A890NotaFiscalParcelamentoID ;
      private Guid AV34NotaFiscalParcelamentoId ;
      private IGxDataStore dsDefault ;
      private SdtSdErro AV9SdErro ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV12WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext1 ;
      private SdtAprovacao AV13Aprovacao ;
      private IDataStoreProvider pr_default ;
      private SdtProposta AV36Proposta ;
      private int[] P00EB3_A323PropostaId ;
      private bool[] P00EB3_n323PropostaId ;
      private decimal[] P00EB3_A855PropostaValorLiquido ;
      private bool[] P00EB3_n855PropostaValorLiquido ;
      private int[] P00EB3_A850PropostaEmpresaClienteId ;
      private bool[] P00EB3_n850PropostaEmpresaClienteId ;
      private Guid[] P00EB3_A40000GXC1 ;
      private bool[] P00EB3_n40000GXC1 ;
      private int[] P00EB4_A168ClienteId ;
      private bool[] P00EB4_n168ClienteId ;
      private string[] P00EB4_A181EnderecoTipo ;
      private bool[] P00EB4_n181EnderecoTipo ;
      private string[] P00EB4_A190EnderecoNumero ;
      private bool[] P00EB4_n190EnderecoNumero ;
      private string[] P00EB4_A183EnderecoLogradouro ;
      private bool[] P00EB4_n183EnderecoLogradouro ;
      private string[] P00EB4_A191EnderecoComplemento ;
      private bool[] P00EB4_n191EnderecoComplemento ;
      private string[] P00EB4_A185EnderecoCidade ;
      private bool[] P00EB4_n185EnderecoCidade ;
      private string[] P00EB4_A182EnderecoCEP ;
      private bool[] P00EB4_n182EnderecoCEP ;
      private string[] P00EB4_A184EnderecoBairro ;
      private bool[] P00EB4_n184EnderecoBairro ;
      private string[] P00EB4_A186MunicipioCodigo ;
      private bool[] P00EB4_n186MunicipioCodigo ;
      private Guid[] P00EB5_A794NotaFiscalId ;
      private bool[] P00EB5_n794NotaFiscalId ;
      private int[] P00EB5_A889NotaFiscalDestinatarioClienteId ;
      private bool[] P00EB5_n889NotaFiscalDestinatarioClienteId ;
      private int[] P00EB5_A168ClienteId ;
      private bool[] P00EB5_n168ClienteId ;
      private string[] P00EB5_A181EnderecoTipo ;
      private bool[] P00EB5_n181EnderecoTipo ;
      private string[] P00EB5_A190EnderecoNumero ;
      private bool[] P00EB5_n190EnderecoNumero ;
      private string[] P00EB5_A183EnderecoLogradouro ;
      private bool[] P00EB5_n183EnderecoLogradouro ;
      private string[] P00EB5_A191EnderecoComplemento ;
      private bool[] P00EB5_n191EnderecoComplemento ;
      private string[] P00EB5_A185EnderecoCidade ;
      private bool[] P00EB5_n185EnderecoCidade ;
      private string[] P00EB5_A182EnderecoCEP ;
      private bool[] P00EB5_n182EnderecoCEP ;
      private string[] P00EB5_A184EnderecoBairro ;
      private bool[] P00EB5_n184EnderecoBairro ;
      private string[] P00EB5_A186MunicipioCodigo ;
      private bool[] P00EB5_n186MunicipioCodigo ;
      private Guid[] P00EB6_A794NotaFiscalId ;
      private bool[] P00EB6_n794NotaFiscalId ;
      private int[] P00EB6_A889NotaFiscalDestinatarioClienteId ;
      private bool[] P00EB6_n889NotaFiscalDestinatarioClienteId ;
      private decimal[] P00EB6_A897NotaFiscalParcelamentoLiquido ;
      private bool[] P00EB6_n897NotaFiscalParcelamentoLiquido ;
      private DateTime[] P00EB6_A893NotaFiscalParcelamentoVencimento ;
      private bool[] P00EB6_n893NotaFiscalParcelamentoVencimento ;
      private Guid[] P00EB6_A890NotaFiscalParcelamentoID ;
      private decimal[] P00EB6_A892NotaFiscalParcelamentoValor ;
      private bool[] P00EB6_n892NotaFiscalParcelamentoValor ;
      private SdtSdTitulo AV15SdTitulo ;
      private SdtSdErro aP3_SdErro ;
   }

   public class prdecisaocompratitulos__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00EB3;
          prmP00EB3 = new Object[] {
          new ParDef("AV11PropostaId",GXType.Int32,9,0)
          };
          Object[] prmP00EB4;
          prmP00EB4 = new Object[] {
          new ParDef("AV18PropostaEmpresaClienteId",GXType.Int32,9,0)
          };
          Object[] prmP00EB5;
          prmP00EB5 = new Object[] {
          new ParDef("AV30NotaFiscalid",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00EB6;
          prmP00EB6 = new Object[] {
          new ParDef("AV30NotaFiscalid",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EB3", "SELECT T1.PropostaId, T1.PropostaValorLiquido, T1.PropostaEmpresaClienteId, COALESCE( T2.GXC1, '00000000-0000-0000-0000-000000000000') AS GXC1 FROM (Proposta T1 LEFT JOIN LATERAL (SELECT MAX(NotaFiscalId) AS GXC1, PropostaId FROM NotaFiscalItem WHERE T1.PropostaId = PropostaId GROUP BY PropostaId ) T2 ON T2.PropostaId = T1.PropostaId) WHERE T1.PropostaId = :AV11PropostaId ORDER BY T1.PropostaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EB3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EB4", "SELECT ClienteId, EnderecoTipo, EnderecoNumero, EnderecoLogradouro, EnderecoComplemento, EnderecoCidade, EnderecoCEP, EnderecoBairro, MunicipioCodigo FROM Cliente WHERE ClienteId = :AV18PropostaEmpresaClienteId ORDER BY ClienteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EB4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EB5", "SELECT T1.NotaFiscalId, T1.NotaFiscalDestinatarioClienteId, T1.ClienteId, T2.EnderecoTipo, T2.EnderecoNumero, T2.EnderecoLogradouro, T2.EnderecoComplemento, T2.EnderecoCidade, T2.EnderecoCEP, T2.EnderecoBairro, T2.MunicipioCodigo FROM (NotaFiscal T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.ClienteId) WHERE T1.NotaFiscalId = :AV30NotaFiscalid ORDER BY T1.NotaFiscalId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EB5,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00EB6", "SELECT T1.NotaFiscalId, T2.NotaFiscalDestinatarioClienteId, T1.NotaFiscalParcelamentoLiquido, T1.NotaFiscalParcelamentoVencimento, T1.NotaFiscalParcelamentoID, T1.NotaFiscalParcelamentoValor FROM (NotaFiscalParcelamento T1 LEFT JOIN NotaFiscal T2 ON T2.NotaFiscalId = T1.NotaFiscalId) WHERE T1.NotaFiscalId = :AV30NotaFiscalid ORDER BY T1.NotaFiscalId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EB6,100, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[5])[0] = rslt.getGuid(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
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
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
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
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((Guid[]) buf[8])[0] = rslt.getGuid(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
       }
    }

 }

}
