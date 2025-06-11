using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class prprocuratags : GXProcedure
   {
      public prprocuratags( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public prprocuratags( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_HTMl ,
                           out GXBaseCollection<SdtSdMapearTags> aP1_Array_SDMapearTags )
      {
         this.AV11HTMl = aP0_HTMl;
         this.AV9Array_SDMapearTags = new GXBaseCollection<SdtSdMapearTags>( context, "SdMapearTags", "Factory21") ;
         initialize();
         ExecuteImpl();
         aP1_Array_SDMapearTags=this.AV9Array_SDMapearTags;
      }

      public GXBaseCollection<SdtSdMapearTags> executeUdp( string aP0_HTMl )
      {
         execute(aP0_HTMl, out aP1_Array_SDMapearTags);
         return AV9Array_SDMapearTags ;
      }

      public void executeSubmit( string aP0_HTMl ,
                                 out GXBaseCollection<SdtSdMapearTags> aP1_Array_SDMapearTags )
      {
         this.AV11HTMl = aP0_HTMl;
         this.AV9Array_SDMapearTags = new GXBaseCollection<SdtSdMapearTags>( context, "SdMapearTags", "Factory21") ;
         SubmitImpl();
         aP1_Array_SDMapearTags=this.AV9Array_SDMapearTags;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9Array_SDMapearTags = new GXBaseCollection<SdtSdMapearTags>( context, "SdMapearTags", "Factory21");
         AV8SDMapearTags = new SdtSdMapearTags(context);
         AV13NomeTag = "{{NomeCompleto}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{TotalReceber}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{TotalPagar}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{Celular}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{Telefone}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{DDI}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{DDD}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{NumeroTelefone}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{NumeroContato}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ContatoDDI}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ContatoDDD}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ContatoEmail}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{EnderecoComplemento}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{EnderecoNumero}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{UF}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{MunicipioNome}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{EnderecoCidade}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{EnderecoBairro}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{EnderecoLogradouro}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{EnderecoCEP}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{EnderecoTipo}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{NomeUsuario}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{Tipo}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{TipoPessoa}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{RazaoSocial}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{RG}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{Convenio}}";
         AV14NomeTabela = "Proposta";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ValorProposta}}";
         AV14NomeTabela = "Proposta";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{Procedimento}}";
         AV14NomeTabela = "Proposta";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ClinicaRazaoSocial}}";
         AV14NomeTabela = "Proposta";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ClinicaValor}}";
         AV14NomeTabela = "Proposta";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ClinicaBanco}}";
         AV14NomeTabela = "Proposta";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ClinicaAgencia}}";
         AV14NomeTabela = "Proposta";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ClinicaConta}}";
         AV14NomeTabela = "Proposta";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ClinicaPIX}}";
         AV14NomeTabela = "Proposta";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ClinicaCNPJ}}";
         AV14NomeTabela = "Proposta";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ClinicaEndereço}}";
         AV14NomeTabela = "Proposta";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ClinicaBairro}}";
         AV14NomeTabela = "Proposta";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ClinicaRepresentanteNome}}";
         AV14NomeTabela = "Proposta";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ClinicaRepresentanteCPF}}";
         AV14NomeTabela = "Proposta";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ClinicaRepresentanteNacionalidade}}";
         AV14NomeTabela = "Proposta";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ClinicaRepresentanteEstadoCivil}}";
         AV14NomeTabela = "Proposta";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ClinicaRepresentanteProfissão}}";
         AV14NomeTabela = "Proposta";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ClinicaRepresentanteRG}}";
         AV14NomeTabela = "Proposta";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ClinicaRepresentanteEndereco}}";
         AV14NomeTabela = "Proposta";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ClinicaRepresentanteTelefone}}";
         AV14NomeTabela = "Proposta";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ClinicaRepresentanteCelular}}";
         AV14NomeTabela = "Proposta";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ClinicaRepresentanteEmail}}";
         AV14NomeTabela = "Proposta";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ClinicaCNPJ}}";
         AV14NomeTabela = "Proposta";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ValorPropostaExtenso}}";
         AV14NomeTabela = "Proposta";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ValorTaxa}}";
         AV14NomeTabela = "Proposta";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ValorTaxaExtenso}}";
         AV14NomeTabela = "Proposta";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{NumeroNotaEmprestimo}}";
         AV14NomeTabela = "Proposta";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{CPF/CNPJ}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{RepresentanteNomeCompleto}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{RepresentanteNacionalidade}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{RepresentanteEstadoCivil}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{RepresentanteProfissão}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{RepresentanteCPF}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{RepresentanteLogadouro}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{RepresentanteEnderecoNumero}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{RepresentanteComplemento}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{RepresentanteMunicipio}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{RepresentanteCidade}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ClienteRG}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ClienteProfissão}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ClienteEstadoCivil}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ClienteNacionalidade}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ClienteBanco}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ClienteAgencia}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ClienteConta}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ClientePIX}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{RepresentanteUF}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{RepresentanteCEP}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{RepresentanteBairro}}";
         AV14NomeTabela = "Cliente";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ContratoJurosMora}}";
         AV14NomeTabela = "Contrato";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ContratoTaxaAdministrativa}}";
         AV14NomeTabela = "Contrato";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ContratoIOFMinimo}}";
         AV14NomeTabela = "Contrato";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{EmpresaBanco}}";
         AV14NomeTabela = "Empresa";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{EmpresaAgencia}}";
         AV14NomeTabela = "Empresa";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{EmpresaConta}}";
         AV14NomeTabela = "Empresa";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{EmpresaPix}}";
         AV14NomeTabela = "Empresa";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{EmpresaEmail}}";
         AV14NomeTabela = "Empresa";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{EmpresaEmail}}";
         AV14NomeTabela = "Empresa";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{TestemunhaPadraoNome1}}";
         AV14NomeTabela = "ConfiguracoesTestemunha";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{TestemunhaPadraoCPF1}}";
         AV14NomeTabela = "ConfiguracoesTestemunha";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{DiaAtual}}";
         AV14NomeTabela = "Servidor";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{AnoAtual}}";
         AV14NomeTabela = "Servidor";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{MesAtualExtenso}}";
         AV14NomeTabela = "Servidor";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ReembolsoValor}}";
         AV14NomeTabela = "Reembolso";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13NomeTag = "{{ValorRemanescente}}";
         AV14NomeTabela = "Reembolso";
         /* Execute user subroutine: 'ADICIONARTAG' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'ADICIONARTAG' Routine */
         returnInSub = false;
         AV10Index = (short)(StringUtil.StringSearch( AV11HTMl, AV13NomeTag, 1));
         if ( ! (0==AV10Index) )
         {
            AV12IsEncontrou = false;
            AV16GXV1 = 1;
            while ( AV16GXV1 <= AV9Array_SDMapearTags.Count )
            {
               AV8SDMapearTags = ((SdtSdMapearTags)AV9Array_SDMapearTags.Item(AV16GXV1));
               if ( StringUtil.StrCmp(AV8SDMapearTags.gxTpr_Tabela, AV14NomeTabela) == 0 )
               {
                  AV12IsEncontrou = true;
                  AV15SdMapearTagsTags = new SdtSdMapearTags_TagsItem(context);
                  AV15SdMapearTagsTags.gxTpr_Tag = AV13NomeTag;
                  AV8SDMapearTags.gxTpr_Tags.Add(AV15SdMapearTagsTags, 0);
                  if (true) break;
               }
               AV16GXV1 = (int)(AV16GXV1+1);
            }
            if ( ! AV12IsEncontrou )
            {
               AV8SDMapearTags = new SdtSdMapearTags(context);
               AV8SDMapearTags.gxTpr_Tabela = AV14NomeTabela;
               AV15SdMapearTagsTags = new SdtSdMapearTags_TagsItem(context);
               AV15SdMapearTagsTags.gxTpr_Tag = AV13NomeTag;
               AV8SDMapearTags.gxTpr_Tags.Add(AV15SdMapearTagsTags, 0);
               AV9Array_SDMapearTags.Add(AV8SDMapearTags, 0);
            }
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
         AV9Array_SDMapearTags = new GXBaseCollection<SdtSdMapearTags>( context, "SdMapearTags", "Factory21");
         AV8SDMapearTags = new SdtSdMapearTags(context);
         AV13NomeTag = "";
         AV14NomeTabela = "";
         AV15SdMapearTagsTags = new SdtSdMapearTags_TagsItem(context);
         /* GeneXus formulas. */
      }

      private short AV10Index ;
      private int AV16GXV1 ;
      private bool returnInSub ;
      private bool AV12IsEncontrou ;
      private string AV11HTMl ;
      private string AV13NomeTag ;
      private string AV14NomeTabela ;
      private GXBaseCollection<SdtSdMapearTags> AV9Array_SDMapearTags ;
      private SdtSdMapearTags AV8SDMapearTags ;
      private SdtSdMapearTags_TagsItem AV15SdMapearTagsTags ;
      private GXBaseCollection<SdtSdMapearTags> aP1_Array_SDMapearTags ;
   }

}
