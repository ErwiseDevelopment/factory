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
   public class prefetivarreembolso : GXProcedure
   {
      public prefetivarreembolso( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prefetivarreembolso( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_PropostaId ,
                           int aP1_ReembolsoId ,
                           DateTime aP2_ReembolsoParcelasData ,
                           short aP3_ReembolsoParcelasDiasPJuros ,
                           decimal aP4_ReembolsoParcelasJurosValor ,
                           string aP5_ReembolsoParcelasObservacao ,
                           decimal aP6_ReembolsoParcelasTaxaValor ,
                           decimal aP7_ReembolsoParcelasValor ,
                           bool aP8_FinalizarReembolso ,
                           decimal aP9_ReembolsoSaldoValor ,
                           int aP10_TipoPagamentoId ,
                           out SdtSdErro aP11_SdErro )
      {
         this.AV8PropostaId = aP0_PropostaId;
         this.AV9ReembolsoId = aP1_ReembolsoId;
         this.AV10ReembolsoParcelasData = aP2_ReembolsoParcelasData;
         this.AV11ReembolsoParcelasDiasPJuros = aP3_ReembolsoParcelasDiasPJuros;
         this.AV12ReembolsoParcelasJurosValor = aP4_ReembolsoParcelasJurosValor;
         this.AV13ReembolsoParcelasObservacao = aP5_ReembolsoParcelasObservacao;
         this.AV14ReembolsoParcelasTaxaValor = aP6_ReembolsoParcelasTaxaValor;
         this.AV15ReembolsoParcelasValor = aP7_ReembolsoParcelasValor;
         this.AV17FinalizarReembolso = aP8_FinalizarReembolso;
         this.AV23ReembolsoSaldoValor = aP9_ReembolsoSaldoValor;
         this.AV28TipoPagamentoId = aP10_TipoPagamentoId;
         this.AV16SdErro = new SdtSdErro(context) ;
         initialize();
         ExecuteImpl();
         aP11_SdErro=this.AV16SdErro;
      }

      public SdtSdErro executeUdp( int aP0_PropostaId ,
                                   int aP1_ReembolsoId ,
                                   DateTime aP2_ReembolsoParcelasData ,
                                   short aP3_ReembolsoParcelasDiasPJuros ,
                                   decimal aP4_ReembolsoParcelasJurosValor ,
                                   string aP5_ReembolsoParcelasObservacao ,
                                   decimal aP6_ReembolsoParcelasTaxaValor ,
                                   decimal aP7_ReembolsoParcelasValor ,
                                   bool aP8_FinalizarReembolso ,
                                   decimal aP9_ReembolsoSaldoValor ,
                                   int aP10_TipoPagamentoId )
      {
         execute(aP0_PropostaId, aP1_ReembolsoId, aP2_ReembolsoParcelasData, aP3_ReembolsoParcelasDiasPJuros, aP4_ReembolsoParcelasJurosValor, aP5_ReembolsoParcelasObservacao, aP6_ReembolsoParcelasTaxaValor, aP7_ReembolsoParcelasValor, aP8_FinalizarReembolso, aP9_ReembolsoSaldoValor, aP10_TipoPagamentoId, out aP11_SdErro);
         return AV16SdErro ;
      }

      public void executeSubmit( int aP0_PropostaId ,
                                 int aP1_ReembolsoId ,
                                 DateTime aP2_ReembolsoParcelasData ,
                                 short aP3_ReembolsoParcelasDiasPJuros ,
                                 decimal aP4_ReembolsoParcelasJurosValor ,
                                 string aP5_ReembolsoParcelasObservacao ,
                                 decimal aP6_ReembolsoParcelasTaxaValor ,
                                 decimal aP7_ReembolsoParcelasValor ,
                                 bool aP8_FinalizarReembolso ,
                                 decimal aP9_ReembolsoSaldoValor ,
                                 int aP10_TipoPagamentoId ,
                                 out SdtSdErro aP11_SdErro )
      {
         this.AV8PropostaId = aP0_PropostaId;
         this.AV9ReembolsoId = aP1_ReembolsoId;
         this.AV10ReembolsoParcelasData = aP2_ReembolsoParcelasData;
         this.AV11ReembolsoParcelasDiasPJuros = aP3_ReembolsoParcelasDiasPJuros;
         this.AV12ReembolsoParcelasJurosValor = aP4_ReembolsoParcelasJurosValor;
         this.AV13ReembolsoParcelasObservacao = aP5_ReembolsoParcelasObservacao;
         this.AV14ReembolsoParcelasTaxaValor = aP6_ReembolsoParcelasTaxaValor;
         this.AV15ReembolsoParcelasValor = aP7_ReembolsoParcelasValor;
         this.AV17FinalizarReembolso = aP8_FinalizarReembolso;
         this.AV23ReembolsoSaldoValor = aP9_ReembolsoSaldoValor;
         this.AV28TipoPagamentoId = aP10_TipoPagamentoId;
         this.AV16SdErro = new SdtSdErro(context) ;
         SubmitImpl();
         aP11_SdErro=this.AV16SdErro;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_SdtWWPContext1 = AV37WWPContext;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext1) ;
         AV37WWPContext = GXt_SdtWWPContext1;
         /* Using cursor P00C92 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A654ConfiguracoesCategoriaTitulo = P00C92_A654ConfiguracoesCategoriaTitulo[0];
            n654ConfiguracoesCategoriaTitulo = P00C92_n654ConfiguracoesCategoriaTitulo[0];
            A299ConfiguracoesId = P00C92_A299ConfiguracoesId[0];
            AV39ConfiguracoesCategoriaTitulo = A654ConfiguracoesCategoriaTitulo;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV18ReembolsoParcelas = new SdtReembolsoParcelas(context);
         AV18ReembolsoParcelas.gxTpr_Reembolsoid = AV9ReembolsoId;
         AV18ReembolsoParcelas.gxTpr_Reembolsoparcelasvalor = AV15ReembolsoParcelasValor;
         AV18ReembolsoParcelas.gxTpr_Reembolsoparcelasdata = AV10ReembolsoParcelasData;
         AV18ReembolsoParcelas.gxTpr_Reembolsoparcelasobservacao = AV13ReembolsoParcelasObservacao;
         AV18ReembolsoParcelas.gxTpr_Reembolsoparcelastaxavalor = AV14ReembolsoParcelasTaxaValor;
         AV18ReembolsoParcelas.gxTpr_Reembolsoparcelasjurosvalor = AV12ReembolsoParcelasJurosValor;
         AV18ReembolsoParcelas.gxTpr_Reembolsoparcelasdiaspjuros = AV11ReembolsoParcelasDiasPJuros;
         AV18ReembolsoParcelas.Save();
         if ( AV18ReembolsoParcelas.Fail() )
         {
            AV19Mensagem = ((GeneXus.Utils.SdtMessages_Message)AV18ReembolsoParcelas.GetMessages().Item(1)).gxTpr_Description;
            /* Execute user subroutine: 'RETORNAERRO' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         /* Using cursor P00C93 */
         pr_default.execute(1, new Object[] {AV8PropostaId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A323PropostaId = P00C93_A323PropostaId[0];
            A328PropostaCratedBy = P00C93_A328PropostaCratedBy[0];
            n328PropostaCratedBy = P00C93_n328PropostaCratedBy[0];
            A642PropostaClinicaId = P00C93_A642PropostaClinicaId[0];
            n642PropostaClinicaId = P00C93_n642PropostaClinicaId[0];
            A504PropostaPacienteClienteId = P00C93_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = P00C93_n504PropostaPacienteClienteId[0];
            A620PropostaPacienteEnderecoCEP = P00C93_A620PropostaPacienteEnderecoCEP[0];
            n620PropostaPacienteEnderecoCEP = P00C93_n620PropostaPacienteEnderecoCEP[0];
            A621PropostaPacienteEnderecoLogradouro = P00C93_A621PropostaPacienteEnderecoLogradouro[0];
            n621PropostaPacienteEnderecoLogradouro = P00C93_n621PropostaPacienteEnderecoLogradouro[0];
            A622PropostaPacienteEnderecoNumero = P00C93_A622PropostaPacienteEnderecoNumero[0];
            n622PropostaPacienteEnderecoNumero = P00C93_n622PropostaPacienteEnderecoNumero[0];
            A623PropostaPacienteEnderecoComplemento = P00C93_A623PropostaPacienteEnderecoComplemento[0];
            n623PropostaPacienteEnderecoComplemento = P00C93_n623PropostaPacienteEnderecoComplemento[0];
            A624PropostaPacienteEnderecoBairro = P00C93_A624PropostaPacienteEnderecoBairro[0];
            n624PropostaPacienteEnderecoBairro = P00C93_n624PropostaPacienteEnderecoBairro[0];
            A625PropostaPacienteMunicipioCodigo = P00C93_A625PropostaPacienteMunicipioCodigo[0];
            n625PropostaPacienteMunicipioCodigo = P00C93_n625PropostaPacienteMunicipioCodigo[0];
            A620PropostaPacienteEnderecoCEP = P00C93_A620PropostaPacienteEnderecoCEP[0];
            n620PropostaPacienteEnderecoCEP = P00C93_n620PropostaPacienteEnderecoCEP[0];
            A621PropostaPacienteEnderecoLogradouro = P00C93_A621PropostaPacienteEnderecoLogradouro[0];
            n621PropostaPacienteEnderecoLogradouro = P00C93_n621PropostaPacienteEnderecoLogradouro[0];
            A622PropostaPacienteEnderecoNumero = P00C93_A622PropostaPacienteEnderecoNumero[0];
            n622PropostaPacienteEnderecoNumero = P00C93_n622PropostaPacienteEnderecoNumero[0];
            A623PropostaPacienteEnderecoComplemento = P00C93_A623PropostaPacienteEnderecoComplemento[0];
            n623PropostaPacienteEnderecoComplemento = P00C93_n623PropostaPacienteEnderecoComplemento[0];
            A624PropostaPacienteEnderecoBairro = P00C93_A624PropostaPacienteEnderecoBairro[0];
            n624PropostaPacienteEnderecoBairro = P00C93_n624PropostaPacienteEnderecoBairro[0];
            A625PropostaPacienteMunicipioCodigo = P00C93_A625PropostaPacienteMunicipioCodigo[0];
            n625PropostaPacienteMunicipioCodigo = P00C93_n625PropostaPacienteMunicipioCodigo[0];
            AV29PropostaCratedBy = A328PropostaCratedBy;
            AV22PropostaClinicaId = A642PropostaClinicaId;
            AV20SdTitulo = new SdtSdTitulo(context);
            AV20SdTitulo.gxTpr_Clienteid = A504PropostaPacienteClienteId;
            AV20SdTitulo.gxTpr_Titulovalor = AV15ReembolsoParcelasValor;
            AV20SdTitulo.gxTpr_Titulodesconto = (decimal)(0);
            AV20SdTitulo.gxTpr_Titulodeleted = false;
            AV20SdTitulo.gxTpr_Titulovencimento = AV10ReembolsoParcelasData;
            AV20SdTitulo.gxTpr_Tituloprorrogacao = AV10ReembolsoParcelasData;
            AV20SdTitulo.gxTpr_Titulocep = A620PropostaPacienteEnderecoCEP;
            AV20SdTitulo.gxTpr_Titulologradouro = A621PropostaPacienteEnderecoLogradouro;
            AV20SdTitulo.gxTpr_Titulonumeroendereco = A622PropostaPacienteEnderecoNumero;
            AV20SdTitulo.gxTpr_Titulocomplemento = A623PropostaPacienteEnderecoComplemento;
            AV20SdTitulo.gxTpr_Titulobairro = A624PropostaPacienteEnderecoBairro;
            AV20SdTitulo.gxTpr_Titulomunicipio = A625PropostaPacienteMunicipioCodigo;
            AV20SdTitulo.gxTpr_Titulotipo = "CREDITO";
            AV20SdTitulo.gxTpr_Contaid = AV21ContaId;
            AV20SdTitulo.gxTpr_Titulocompetenciaano = (short)(DateTimeUtil.Year( AV10ReembolsoParcelasData));
            AV20SdTitulo.gxTpr_Titulocompetenciames = (short)(DateTimeUtil.Month( AV10ReembolsoParcelasData));
            AV20SdTitulo.gxTpr_Propostaid = AV8PropostaId;
            AV20SdTitulo.gxTpr_Titulopropostatipo = "REEMBOLSO";
            AV20SdTitulo.gxTpr_Categoriatituloid = AV39ConfiguracoesCategoriaTitulo;
            new prcriartitulo(context ).execute( ref  AV20SdTitulo, out  AV16SdErro) ;
            if ( AV16SdErro.gxTpr_Status != 200 )
            {
               pr_default.close(1);
               cleanup();
               if (true) return;
            }
            AV26Array_SdTituloMovimento = new GXBaseCollection<SdtSdTituloMovimento>( context, "SdTituloMovimento", "Factory21");
            AV27SdTituloMovimento = new SdtSdTituloMovimento(context);
            AV27SdTituloMovimento.gxTpr_Tipopagamentoid = AV28TipoPagamentoId;
            AV27SdTituloMovimento.gxTpr_Tituloid = AV20SdTitulo.gxTpr_Tituloid;
            AV27SdTituloMovimento.gxTpr_Titulomovimentovalor = AV15ReembolsoParcelasValor;
            AV27SdTituloMovimento.gxTpr_Titulomovimentotipo = "Baixa";
            AV27SdTituloMovimento.gxTpr_Titulomovimentosoma = true;
            AV27SdTituloMovimento.gxTpr_Titulomovimentodatacredito = AV10ReembolsoParcelasData;
            AV26Array_SdTituloMovimento.Add(AV27SdTituloMovimento, 0);
            new prcriarntitulomovimentos(context ).execute(  AV26Array_SdTituloMovimento, out  AV16SdErro) ;
            if ( AV16SdErro.gxTpr_Status != 200 )
            {
               pr_default.close(1);
               cleanup();
               if (true) return;
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         /* Using cursor P00C94 */
         pr_default.execute(2, new Object[] {AV22PropostaClinicaId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A168ClienteId = P00C94_A168ClienteId[0];
            A182EnderecoCEP = P00C94_A182EnderecoCEP[0];
            n182EnderecoCEP = P00C94_n182EnderecoCEP[0];
            A183EnderecoLogradouro = P00C94_A183EnderecoLogradouro[0];
            n183EnderecoLogradouro = P00C94_n183EnderecoLogradouro[0];
            A190EnderecoNumero = P00C94_A190EnderecoNumero[0];
            n190EnderecoNumero = P00C94_n190EnderecoNumero[0];
            A191EnderecoComplemento = P00C94_A191EnderecoComplemento[0];
            n191EnderecoComplemento = P00C94_n191EnderecoComplemento[0];
            A184EnderecoBairro = P00C94_A184EnderecoBairro[0];
            n184EnderecoBairro = P00C94_n184EnderecoBairro[0];
            A186MunicipioCodigo = P00C94_A186MunicipioCodigo[0];
            n186MunicipioCodigo = P00C94_n186MunicipioCodigo[0];
            AV20SdTitulo = new SdtSdTitulo(context);
            AV20SdTitulo.gxTpr_Clienteid = A168ClienteId;
            AV20SdTitulo.gxTpr_Titulovalor = (decimal)(AV14ReembolsoParcelasTaxaValor+AV12ReembolsoParcelasJurosValor);
            AV20SdTitulo.gxTpr_Titulodesconto = (decimal)(0);
            AV20SdTitulo.gxTpr_Titulodeleted = false;
            AV20SdTitulo.gxTpr_Titulovencimento = AV10ReembolsoParcelasData;
            AV20SdTitulo.gxTpr_Tituloprorrogacao = AV10ReembolsoParcelasData;
            AV20SdTitulo.gxTpr_Titulocep = A182EnderecoCEP;
            AV20SdTitulo.gxTpr_Titulologradouro = A183EnderecoLogradouro;
            AV20SdTitulo.gxTpr_Titulonumeroendereco = A190EnderecoNumero;
            AV20SdTitulo.gxTpr_Titulocomplemento = A191EnderecoComplemento;
            AV20SdTitulo.gxTpr_Titulobairro = A184EnderecoBairro;
            AV20SdTitulo.gxTpr_Titulomunicipio = A186MunicipioCodigo;
            AV20SdTitulo.gxTpr_Titulotipo = "CREDITO";
            AV20SdTitulo.gxTpr_Contaid = AV21ContaId;
            AV20SdTitulo.gxTpr_Titulocompetenciaano = (short)(DateTimeUtil.Year( AV10ReembolsoParcelasData));
            AV20SdTitulo.gxTpr_Titulocompetenciames = (short)(DateTimeUtil.Month( AV10ReembolsoParcelasData));
            AV20SdTitulo.gxTpr_Propostaid = AV8PropostaId;
            AV20SdTitulo.gxTpr_Titulopropostatipo = "TAXA";
            AV20SdTitulo.gxTpr_Categoriatituloid = AV39ConfiguracoesCategoriaTitulo;
            new prcriartitulo(context ).execute( ref  AV20SdTitulo, out  AV16SdErro) ;
            if ( AV16SdErro.gxTpr_Status != 200 )
            {
               pr_default.close(2);
               cleanup();
               if (true) return;
            }
            if ( AV17FinalizarReembolso && ! ( AV23ReembolsoSaldoValor - AV15ReembolsoParcelasValor <= Convert.ToDecimal( 0 )) )
            {
               AV20SdTitulo = new SdtSdTitulo(context);
               AV20SdTitulo.gxTpr_Clienteid = A168ClienteId;
               AV20SdTitulo.gxTpr_Titulovalor = (decimal)(AV23ReembolsoSaldoValor-AV15ReembolsoParcelasValor);
               AV20SdTitulo.gxTpr_Titulodesconto = (decimal)(0);
               AV20SdTitulo.gxTpr_Titulodeleted = false;
               AV20SdTitulo.gxTpr_Titulovencimento = AV10ReembolsoParcelasData;
               AV20SdTitulo.gxTpr_Tituloprorrogacao = AV10ReembolsoParcelasData;
               AV20SdTitulo.gxTpr_Titulocep = A182EnderecoCEP;
               AV20SdTitulo.gxTpr_Titulologradouro = A183EnderecoLogradouro;
               AV20SdTitulo.gxTpr_Titulonumeroendereco = A190EnderecoNumero;
               AV20SdTitulo.gxTpr_Titulocomplemento = A191EnderecoComplemento;
               AV20SdTitulo.gxTpr_Titulobairro = A184EnderecoBairro;
               AV20SdTitulo.gxTpr_Titulomunicipio = A186MunicipioCodigo;
               AV20SdTitulo.gxTpr_Titulotipo = "CREDITO";
               AV20SdTitulo.gxTpr_Contaid = AV21ContaId;
               AV20SdTitulo.gxTpr_Titulocompetenciaano = (short)(DateTimeUtil.Year( AV10ReembolsoParcelasData));
               AV20SdTitulo.gxTpr_Titulocompetenciames = (short)(DateTimeUtil.Month( AV10ReembolsoParcelasData));
               AV20SdTitulo.gxTpr_Propostaid = AV8PropostaId;
               AV20SdTitulo.gxTpr_Titulopropostatipo = "IOF";
               AV20SdTitulo.gxTpr_Categoriatituloid = AV39ConfiguracoesCategoriaTitulo;
               new prcriartitulo(context ).execute( ref  AV20SdTitulo, out  AV16SdErro) ;
               if ( AV16SdErro.gxTpr_Status != 200 )
               {
                  pr_default.close(2);
                  cleanup();
                  if (true) return;
               }
               AV18ReembolsoParcelas = new SdtReembolsoParcelas(context);
               AV18ReembolsoParcelas.gxTpr_Reembolsoid = AV9ReembolsoId;
               AV18ReembolsoParcelas.gxTpr_Reembolsoparcelasvalor = (decimal)(AV23ReembolsoSaldoValor-AV15ReembolsoParcelasValor);
               AV18ReembolsoParcelas.gxTpr_Reembolsoparcelasdata = AV10ReembolsoParcelasData;
               AV18ReembolsoParcelas.gxTpr_Reembolsoparcelasobservacao = "IOF";
               AV18ReembolsoParcelas.gxTpr_Reembolsoparcelastaxavalor = (decimal)(0);
               AV18ReembolsoParcelas.gxTpr_Reembolsoparcelasjurosvalor = (decimal)(0);
               AV18ReembolsoParcelas.gxTpr_Reembolsoparcelasdiaspjuros = 0;
               AV18ReembolsoParcelas.Save();
               if ( AV18ReembolsoParcelas.Fail() )
               {
                  AV19Mensagem = ((GeneXus.Utils.SdtMessages_Message)AV18ReembolsoParcelas.GetMessages().Item(1)).gxTpr_Description;
                  /* Execute user subroutine: 'RETORNAERRO' */
                  S111 ();
                  if ( returnInSub )
                  {
                     pr_default.close(2);
                     cleanup();
                     if (true) return;
                  }
               }
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
         if ( ! AV17FinalizarReembolso )
         {
            AV25ReembolsoEtapa = new SdtReembolsoEtapa(context);
            AV25ReembolsoEtapa.gxTpr_Reembolsoetapastatus = "REANALISE";
            AV25ReembolsoEtapa.gxTpr_Reembolsoid = AV9ReembolsoId;
            AV25ReembolsoEtapa.Save();
            if ( AV25ReembolsoEtapa.Fail() )
            {
               AV19Mensagem = ((GeneXus.Utils.SdtMessages_Message)AV25ReembolsoEtapa.GetMessages().Item(1)).gxTpr_Description;
               /* Execute user subroutine: 'RETORNAERRO' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            /* Using cursor P00C95 */
            pr_default.execute(3, new Object[] {AV29PropostaCratedBy});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A133SecUserId = P00C95_A133SecUserId[0];
               A144SecUserEmail = P00C95_A144SecUserEmail[0];
               n144SecUserEmail = P00C95_n144SecUserEmail[0];
               A143SecUserFullName = P00C95_A143SecUserFullName[0];
               n143SecUserFullName = P00C95_n143SecUserFullName[0];
               AV30SecUserEmail = A144SecUserEmail;
               AV32SecUserFullName = A143SecUserFullName;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
            /* Using cursor P00C96 */
            pr_default.execute(4, new Object[] {AV9ReembolsoId});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A518ReembolsoId = P00C96_A518ReembolsoId[0];
               A546ReembolsoProtocolo = P00C96_A546ReembolsoProtocolo[0];
               n546ReembolsoProtocolo = P00C96_n546ReembolsoProtocolo[0];
               AV31ReembolsoProtocolo = A546ReembolsoProtocolo;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(4);
            AV36BCNotification = new SdtBCNotification(context);
            AV36BCNotification.gxTpr_Notificationtitle = "Status do Reembolso";
            AV36BCNotification.gxTpr_Notificationmessage = "Informamos que o status do seu reembolso foi atualizado. Além disso, títulos a pagar foram gerados para a clínica.";
            AV36BCNotification.gxTpr_Notificationtype = "Internal";
            AV36BCNotification.gxTpr_Notificationcreatedat = DateTimeUtil.ServerNow( context, pr_default);
            AV36BCNotification.gxTpr_Notificationstatus = "Pending";
            AV36BCNotification.gxTpr_Secuserid = AV37WWPContext.gxTpr_Secuserclienteid;
            AV36BCNotification.Save();
            if ( AV36BCNotification.Fail() )
            {
               AV19Mensagem = ((GeneXus.Utils.SdtMessages_Message)AV36BCNotification.GetMessages().Item(1)).gxTpr_Description;
               /* Execute user subroutine: 'RETORNAERRO' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            AV38usernotification = new SdtUserNotification(context);
            AV38usernotification.gxTpr_Notificationid = AV36BCNotification.gxTpr_Notificationid;
            AV38usernotification.gxTpr_Usernotificationuserid = AV29PropostaCratedBy;
            AV38usernotification.gxTpr_Usernotificationstatus = "Unread";
            AV38usernotification.gxTpr_Usernotificationsentat = DateTimeUtil.ServerNow( context, pr_default);
            AV38usernotification.Save();
            if ( AV38usernotification.Fail() )
            {
               AV19Mensagem = ((GeneXus.Utils.SdtMessages_Message)AV38usernotification.GetMessages().Item(1)).gxTpr_Description;
               /* Execute user subroutine: 'RETORNAERRO' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            new premailnotificaalteracaostatusreembolso(context ).execute(  AV32SecUserFullName,  AV31ReembolsoProtocolo, out  AV33HTML) ;
            AV35Array_Email = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
            AV35Array_Email.Add(AV30SecUserEmail, 0);
            new sendemail(context).executeSubmit(  "Status do Reembolso",  AV33HTML,  AV35Array_Email, out  AV34Message) ;
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'RETORNAERRO' Routine */
         returnInSub = false;
         AV16SdErro.gxTpr_Internalcode = 1;
         AV16SdErro.gxTpr_Msg = AV19Mensagem;
         returnInSub = true;
         if (true) return;
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
         AV16SdErro = new SdtSdErro(context);
         AV37WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtWWPContext1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         P00C92_A654ConfiguracoesCategoriaTitulo = new int[1] ;
         P00C92_n654ConfiguracoesCategoriaTitulo = new bool[] {false} ;
         P00C92_A299ConfiguracoesId = new int[1] ;
         AV18ReembolsoParcelas = new SdtReembolsoParcelas(context);
         AV19Mensagem = "";
         P00C93_A323PropostaId = new int[1] ;
         P00C93_A328PropostaCratedBy = new short[1] ;
         P00C93_n328PropostaCratedBy = new bool[] {false} ;
         P00C93_A642PropostaClinicaId = new int[1] ;
         P00C93_n642PropostaClinicaId = new bool[] {false} ;
         P00C93_A504PropostaPacienteClienteId = new int[1] ;
         P00C93_n504PropostaPacienteClienteId = new bool[] {false} ;
         P00C93_A620PropostaPacienteEnderecoCEP = new string[] {""} ;
         P00C93_n620PropostaPacienteEnderecoCEP = new bool[] {false} ;
         P00C93_A621PropostaPacienteEnderecoLogradouro = new string[] {""} ;
         P00C93_n621PropostaPacienteEnderecoLogradouro = new bool[] {false} ;
         P00C93_A622PropostaPacienteEnderecoNumero = new string[] {""} ;
         P00C93_n622PropostaPacienteEnderecoNumero = new bool[] {false} ;
         P00C93_A623PropostaPacienteEnderecoComplemento = new string[] {""} ;
         P00C93_n623PropostaPacienteEnderecoComplemento = new bool[] {false} ;
         P00C93_A624PropostaPacienteEnderecoBairro = new string[] {""} ;
         P00C93_n624PropostaPacienteEnderecoBairro = new bool[] {false} ;
         P00C93_A625PropostaPacienteMunicipioCodigo = new string[] {""} ;
         P00C93_n625PropostaPacienteMunicipioCodigo = new bool[] {false} ;
         A620PropostaPacienteEnderecoCEP = "";
         A621PropostaPacienteEnderecoLogradouro = "";
         A622PropostaPacienteEnderecoNumero = "";
         A623PropostaPacienteEnderecoComplemento = "";
         A624PropostaPacienteEnderecoBairro = "";
         A625PropostaPacienteMunicipioCodigo = "";
         AV20SdTitulo = new SdtSdTitulo(context);
         AV26Array_SdTituloMovimento = new GXBaseCollection<SdtSdTituloMovimento>( context, "SdTituloMovimento", "Factory21");
         AV27SdTituloMovimento = new SdtSdTituloMovimento(context);
         P00C94_A168ClienteId = new int[1] ;
         P00C94_A182EnderecoCEP = new string[] {""} ;
         P00C94_n182EnderecoCEP = new bool[] {false} ;
         P00C94_A183EnderecoLogradouro = new string[] {""} ;
         P00C94_n183EnderecoLogradouro = new bool[] {false} ;
         P00C94_A190EnderecoNumero = new string[] {""} ;
         P00C94_n190EnderecoNumero = new bool[] {false} ;
         P00C94_A191EnderecoComplemento = new string[] {""} ;
         P00C94_n191EnderecoComplemento = new bool[] {false} ;
         P00C94_A184EnderecoBairro = new string[] {""} ;
         P00C94_n184EnderecoBairro = new bool[] {false} ;
         P00C94_A186MunicipioCodigo = new string[] {""} ;
         P00C94_n186MunicipioCodigo = new bool[] {false} ;
         A182EnderecoCEP = "";
         A183EnderecoLogradouro = "";
         A190EnderecoNumero = "";
         A191EnderecoComplemento = "";
         A184EnderecoBairro = "";
         A186MunicipioCodigo = "";
         AV25ReembolsoEtapa = new SdtReembolsoEtapa(context);
         P00C95_A133SecUserId = new short[1] ;
         P00C95_A144SecUserEmail = new string[] {""} ;
         P00C95_n144SecUserEmail = new bool[] {false} ;
         P00C95_A143SecUserFullName = new string[] {""} ;
         P00C95_n143SecUserFullName = new bool[] {false} ;
         A144SecUserEmail = "";
         A143SecUserFullName = "";
         AV30SecUserEmail = "";
         AV32SecUserFullName = "";
         P00C96_A518ReembolsoId = new int[1] ;
         P00C96_A546ReembolsoProtocolo = new string[] {""} ;
         P00C96_n546ReembolsoProtocolo = new bool[] {false} ;
         A546ReembolsoProtocolo = "";
         AV31ReembolsoProtocolo = "";
         AV36BCNotification = new SdtBCNotification(context);
         AV38usernotification = new SdtUserNotification(context);
         AV33HTML = "";
         AV35Array_Email = new GxSimpleCollection<string>();
         AV34Message = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prefetivarreembolso__default(),
            new Object[][] {
                new Object[] {
               P00C92_A654ConfiguracoesCategoriaTitulo, P00C92_n654ConfiguracoesCategoriaTitulo, P00C92_A299ConfiguracoesId
               }
               , new Object[] {
               P00C93_A323PropostaId, P00C93_A328PropostaCratedBy, P00C93_n328PropostaCratedBy, P00C93_A642PropostaClinicaId, P00C93_n642PropostaClinicaId, P00C93_A504PropostaPacienteClienteId, P00C93_n504PropostaPacienteClienteId, P00C93_A620PropostaPacienteEnderecoCEP, P00C93_n620PropostaPacienteEnderecoCEP, P00C93_A621PropostaPacienteEnderecoLogradouro,
               P00C93_n621PropostaPacienteEnderecoLogradouro, P00C93_A622PropostaPacienteEnderecoNumero, P00C93_n622PropostaPacienteEnderecoNumero, P00C93_A623PropostaPacienteEnderecoComplemento, P00C93_n623PropostaPacienteEnderecoComplemento, P00C93_A624PropostaPacienteEnderecoBairro, P00C93_n624PropostaPacienteEnderecoBairro, P00C93_A625PropostaPacienteMunicipioCodigo, P00C93_n625PropostaPacienteMunicipioCodigo
               }
               , new Object[] {
               P00C94_A168ClienteId, P00C94_A182EnderecoCEP, P00C94_n182EnderecoCEP, P00C94_A183EnderecoLogradouro, P00C94_n183EnderecoLogradouro, P00C94_A190EnderecoNumero, P00C94_n190EnderecoNumero, P00C94_A191EnderecoComplemento, P00C94_n191EnderecoComplemento, P00C94_A184EnderecoBairro,
               P00C94_n184EnderecoBairro, P00C94_A186MunicipioCodigo, P00C94_n186MunicipioCodigo
               }
               , new Object[] {
               P00C95_A133SecUserId, P00C95_A144SecUserEmail, P00C95_n144SecUserEmail, P00C95_A143SecUserFullName, P00C95_n143SecUserFullName
               }
               , new Object[] {
               P00C96_A518ReembolsoId, P00C96_A546ReembolsoProtocolo, P00C96_n546ReembolsoProtocolo
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV11ReembolsoParcelasDiasPJuros ;
      private short A328PropostaCratedBy ;
      private short AV29PropostaCratedBy ;
      private short A133SecUserId ;
      private int AV8PropostaId ;
      private int AV9ReembolsoId ;
      private int AV28TipoPagamentoId ;
      private int A654ConfiguracoesCategoriaTitulo ;
      private int A299ConfiguracoesId ;
      private int AV39ConfiguracoesCategoriaTitulo ;
      private int A323PropostaId ;
      private int A642PropostaClinicaId ;
      private int A504PropostaPacienteClienteId ;
      private int AV22PropostaClinicaId ;
      private int AV21ContaId ;
      private int A168ClienteId ;
      private int A518ReembolsoId ;
      private decimal AV12ReembolsoParcelasJurosValor ;
      private decimal AV14ReembolsoParcelasTaxaValor ;
      private decimal AV15ReembolsoParcelasValor ;
      private decimal AV23ReembolsoSaldoValor ;
      private DateTime AV10ReembolsoParcelasData ;
      private bool AV17FinalizarReembolso ;
      private bool n654ConfiguracoesCategoriaTitulo ;
      private bool returnInSub ;
      private bool n328PropostaCratedBy ;
      private bool n642PropostaClinicaId ;
      private bool n504PropostaPacienteClienteId ;
      private bool n620PropostaPacienteEnderecoCEP ;
      private bool n621PropostaPacienteEnderecoLogradouro ;
      private bool n622PropostaPacienteEnderecoNumero ;
      private bool n623PropostaPacienteEnderecoComplemento ;
      private bool n624PropostaPacienteEnderecoBairro ;
      private bool n625PropostaPacienteMunicipioCodigo ;
      private bool n182EnderecoCEP ;
      private bool n183EnderecoLogradouro ;
      private bool n190EnderecoNumero ;
      private bool n191EnderecoComplemento ;
      private bool n184EnderecoBairro ;
      private bool n186MunicipioCodigo ;
      private bool n144SecUserEmail ;
      private bool n143SecUserFullName ;
      private bool n546ReembolsoProtocolo ;
      private string AV33HTML ;
      private string AV13ReembolsoParcelasObservacao ;
      private string AV19Mensagem ;
      private string A620PropostaPacienteEnderecoCEP ;
      private string A621PropostaPacienteEnderecoLogradouro ;
      private string A622PropostaPacienteEnderecoNumero ;
      private string A623PropostaPacienteEnderecoComplemento ;
      private string A624PropostaPacienteEnderecoBairro ;
      private string A625PropostaPacienteMunicipioCodigo ;
      private string A182EnderecoCEP ;
      private string A183EnderecoLogradouro ;
      private string A190EnderecoNumero ;
      private string A191EnderecoComplemento ;
      private string A184EnderecoBairro ;
      private string A186MunicipioCodigo ;
      private string A144SecUserEmail ;
      private string A143SecUserFullName ;
      private string AV30SecUserEmail ;
      private string AV32SecUserFullName ;
      private string A546ReembolsoProtocolo ;
      private string AV31ReembolsoProtocolo ;
      private string AV34Message ;
      private IGxDataStore dsDefault ;
      private SdtSdErro AV16SdErro ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV37WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext1 ;
      private IDataStoreProvider pr_default ;
      private int[] P00C92_A654ConfiguracoesCategoriaTitulo ;
      private bool[] P00C92_n654ConfiguracoesCategoriaTitulo ;
      private int[] P00C92_A299ConfiguracoesId ;
      private SdtReembolsoParcelas AV18ReembolsoParcelas ;
      private int[] P00C93_A323PropostaId ;
      private short[] P00C93_A328PropostaCratedBy ;
      private bool[] P00C93_n328PropostaCratedBy ;
      private int[] P00C93_A642PropostaClinicaId ;
      private bool[] P00C93_n642PropostaClinicaId ;
      private int[] P00C93_A504PropostaPacienteClienteId ;
      private bool[] P00C93_n504PropostaPacienteClienteId ;
      private string[] P00C93_A620PropostaPacienteEnderecoCEP ;
      private bool[] P00C93_n620PropostaPacienteEnderecoCEP ;
      private string[] P00C93_A621PropostaPacienteEnderecoLogradouro ;
      private bool[] P00C93_n621PropostaPacienteEnderecoLogradouro ;
      private string[] P00C93_A622PropostaPacienteEnderecoNumero ;
      private bool[] P00C93_n622PropostaPacienteEnderecoNumero ;
      private string[] P00C93_A623PropostaPacienteEnderecoComplemento ;
      private bool[] P00C93_n623PropostaPacienteEnderecoComplemento ;
      private string[] P00C93_A624PropostaPacienteEnderecoBairro ;
      private bool[] P00C93_n624PropostaPacienteEnderecoBairro ;
      private string[] P00C93_A625PropostaPacienteMunicipioCodigo ;
      private bool[] P00C93_n625PropostaPacienteMunicipioCodigo ;
      private SdtSdTitulo AV20SdTitulo ;
      private GXBaseCollection<SdtSdTituloMovimento> AV26Array_SdTituloMovimento ;
      private SdtSdTituloMovimento AV27SdTituloMovimento ;
      private int[] P00C94_A168ClienteId ;
      private string[] P00C94_A182EnderecoCEP ;
      private bool[] P00C94_n182EnderecoCEP ;
      private string[] P00C94_A183EnderecoLogradouro ;
      private bool[] P00C94_n183EnderecoLogradouro ;
      private string[] P00C94_A190EnderecoNumero ;
      private bool[] P00C94_n190EnderecoNumero ;
      private string[] P00C94_A191EnderecoComplemento ;
      private bool[] P00C94_n191EnderecoComplemento ;
      private string[] P00C94_A184EnderecoBairro ;
      private bool[] P00C94_n184EnderecoBairro ;
      private string[] P00C94_A186MunicipioCodigo ;
      private bool[] P00C94_n186MunicipioCodigo ;
      private SdtReembolsoEtapa AV25ReembolsoEtapa ;
      private short[] P00C95_A133SecUserId ;
      private string[] P00C95_A144SecUserEmail ;
      private bool[] P00C95_n144SecUserEmail ;
      private string[] P00C95_A143SecUserFullName ;
      private bool[] P00C95_n143SecUserFullName ;
      private int[] P00C96_A518ReembolsoId ;
      private string[] P00C96_A546ReembolsoProtocolo ;
      private bool[] P00C96_n546ReembolsoProtocolo ;
      private SdtBCNotification AV36BCNotification ;
      private SdtUserNotification AV38usernotification ;
      private GxSimpleCollection<string> AV35Array_Email ;
      private SdtSdErro aP11_SdErro ;
   }

   public class prefetivarreembolso__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00C92;
          prmP00C92 = new Object[] {
          };
          Object[] prmP00C93;
          prmP00C93 = new Object[] {
          new ParDef("AV8PropostaId",GXType.Int32,9,0)
          };
          Object[] prmP00C94;
          prmP00C94 = new Object[] {
          new ParDef("AV22PropostaClinicaId",GXType.Int32,9,0)
          };
          Object[] prmP00C95;
          prmP00C95 = new Object[] {
          new ParDef("AV29PropostaCratedBy",GXType.Int16,4,0)
          };
          Object[] prmP00C96;
          prmP00C96 = new Object[] {
          new ParDef("AV9ReembolsoId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00C92", "SELECT ConfiguracoesCategoriaTitulo, ConfiguracoesId FROM Configuracoes ORDER BY ConfiguracoesId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C92,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00C93", "SELECT T1.PropostaId, T1.PropostaCratedBy, T1.PropostaClinicaId, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T2.EnderecoCEP AS PropostaPacienteEnderecoCEP, T2.EnderecoLogradouro AS PropostaPacienteEnderecoLogradouro, T2.EnderecoNumero AS PropostaPacienteEnderecoNumero, T2.EnderecoComplemento AS PropostaPacienteEnderecoComplemento, T2.EnderecoBairro AS PropostaPacienteEnderecoBairro, T2.MunicipioCodigo AS PropostaPacienteMunicipioCodigo FROM (Proposta T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.PropostaPacienteClienteId) WHERE T1.PropostaId = :AV8PropostaId ORDER BY T1.PropostaId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C93,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00C94", "SELECT ClienteId, EnderecoCEP, EnderecoLogradouro, EnderecoNumero, EnderecoComplemento, EnderecoBairro, MunicipioCodigo FROM Cliente WHERE ClienteId = :AV22PropostaClinicaId ORDER BY ClienteId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C94,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00C95", "SELECT SecUserId, SecUserEmail, SecUserFullName FROM SecUser WHERE SecUserId = :AV29PropostaCratedBy ORDER BY SecUserId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C95,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00C96", "SELECT ReembolsoId, ReembolsoProtocolo FROM Reembolso WHERE ReembolsoId = :AV9ReembolsoId ORDER BY ReembolsoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C96,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
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
                return;
             case 2 :
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
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
