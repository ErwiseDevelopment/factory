using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlRoot(ElementName = "Serasa" )]
   [XmlType(TypeName =  "Serasa" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtSerasa : GxSilentTrnSdt
   {
      public SdtSerasa( )
      {
      }

      public SdtSerasa( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetEntryAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void Load( int AV662SerasaId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV662SerasaId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"SerasaId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Serasa");
         metadata.Set("BT", "Serasa");
         metadata.Set("PK", "[ \"SerasaId\" ]");
         metadata.Set("PKAssigned", "[ \"SerasaId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ClienteId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Serasaid_Z");
         state.Add("gxTpr_Clienteid_Z");
         state.Add("gxTpr_Clienterazaosocial_Z");
         state.Add("gxTpr_Serasanumeroproposta_Z");
         state.Add("gxTpr_Serasapolitica_Z");
         state.Add("gxTpr_Serasacreatedat_Z_Nullable");
         state.Add("gxTpr_Serasatipovenda_Z");
         state.Add("gxTpr_Serasacodtipovenda_Z");
         state.Add("gxTpr_Serasacodnivelrisco_Z");
         state.Add("gxTpr_Serasatiporecomendacao_Z");
         state.Add("gxTpr_Serasarecomendacaovenda_Z");
         state.Add("gxTpr_Serasacpfregular_Z");
         state.Add("gxTpr_Serasaretricaoativa_Z");
         state.Add("gxTpr_Serasaprotestoativo_Z");
         state.Add("gxTpr_Serasabaixocomprometimento_Z");
         state.Add("gxTpr_Serasavalorlimiterecomendado_Z");
         state.Add("gxTpr_Serasafaixaderendaestimada_Z");
         state.Add("gxTpr_Serasamensagemrendaestimada_Z");
         state.Add("gxTpr_Serasaanotacoescompletas_Z");
         state.Add("gxTpr_Serasaconsultasdetalhadas_Z");
         state.Add("gxTpr_Serasaanotacoesconsultaspc_Z");
         state.Add("gxTpr_Serasaparticipacaosocietaria_Z");
         state.Add("gxTpr_Serasarendaestimada_Z");
         state.Add("gxTpr_Serasahistoricopagamentopf_Z");
         state.Add("gxTpr_Serasarecomendacompleto_Z");
         state.Add("gxTpr_Serasascore_Z");
         state.Add("gxTpr_Serasataxa_Z");
         state.Add("gxTpr_Serasamensagemscore_Z");
         state.Add("gxTpr_Serasasituacaocpf_Z");
         state.Add("gxTpr_Serasadatanascimento_Z_Nullable");
         state.Add("gxTpr_Serasagenero_Z");
         state.Add("gxTpr_Serasanomemae_Z");
         state.Add("gxTpr_Serasagrafia_Z");
         state.Add("gxTpr_Serasacountacoes_f_Z");
         state.Add("gxTpr_Serasacountenderecos_f_Z");
         state.Add("gxTpr_Serasacountprotestos_f_Z");
         state.Add("gxTpr_Serasacountocorrencias_f_Z");
         state.Add("gxTpr_Serasacountcheques_f_Z");
         state.Add("gxTpr_Serasaid_N");
         state.Add("gxTpr_Clienteid_N");
         state.Add("gxTpr_Clienterazaosocial_N");
         state.Add("gxTpr_Serasanumeroproposta_N");
         state.Add("gxTpr_Serasapolitica_N");
         state.Add("gxTpr_Serasacreatedat_N");
         state.Add("gxTpr_Serasatipovenda_N");
         state.Add("gxTpr_Serasacodtipovenda_N");
         state.Add("gxTpr_Serasacodnivelrisco_N");
         state.Add("gxTpr_Serasatiporecomendacao_N");
         state.Add("gxTpr_Serasarecomendacaovenda_N");
         state.Add("gxTpr_Serasacpfregular_N");
         state.Add("gxTpr_Serasaretricaoativa_N");
         state.Add("gxTpr_Serasaprotestoativo_N");
         state.Add("gxTpr_Serasabaixocomprometimento_N");
         state.Add("gxTpr_Serasavalorlimiterecomendado_N");
         state.Add("gxTpr_Serasafaixaderendaestimada_N");
         state.Add("gxTpr_Serasamensagemrendaestimada_N");
         state.Add("gxTpr_Serasaanotacoescompletas_N");
         state.Add("gxTpr_Serasaconsultasdetalhadas_N");
         state.Add("gxTpr_Serasaanotacoesconsultaspc_N");
         state.Add("gxTpr_Serasaparticipacaosocietaria_N");
         state.Add("gxTpr_Serasarendaestimada_N");
         state.Add("gxTpr_Serasahistoricopagamentopf_N");
         state.Add("gxTpr_Serasarecomendacompleto_N");
         state.Add("gxTpr_Serasascore_N");
         state.Add("gxTpr_Serasataxa_N");
         state.Add("gxTpr_Serasamensagemscore_N");
         state.Add("gxTpr_Serasasituacaocpf_N");
         state.Add("gxTpr_Serasadatanascimento_N");
         state.Add("gxTpr_Serasagenero_N");
         state.Add("gxTpr_Serasanomemae_N");
         state.Add("gxTpr_Serasagrafia_N");
         state.Add("gxTpr_Serasajson_N");
         state.Add("gxTpr_Serasacountacoes_f_N");
         state.Add("gxTpr_Serasacountenderecos_f_N");
         state.Add("gxTpr_Serasacountprotestos_f_N");
         state.Add("gxTpr_Serasacountocorrencias_f_N");
         state.Add("gxTpr_Serasacountcheques_f_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtSerasa sdt;
         sdt = (SdtSerasa)(source);
         gxTv_SdtSerasa_Serasaid = sdt.gxTv_SdtSerasa_Serasaid ;
         gxTv_SdtSerasa_Clienteid = sdt.gxTv_SdtSerasa_Clienteid ;
         gxTv_SdtSerasa_Clienterazaosocial = sdt.gxTv_SdtSerasa_Clienterazaosocial ;
         gxTv_SdtSerasa_Serasanumeroproposta = sdt.gxTv_SdtSerasa_Serasanumeroproposta ;
         gxTv_SdtSerasa_Serasapolitica = sdt.gxTv_SdtSerasa_Serasapolitica ;
         gxTv_SdtSerasa_Serasacreatedat = sdt.gxTv_SdtSerasa_Serasacreatedat ;
         gxTv_SdtSerasa_Serasatipovenda = sdt.gxTv_SdtSerasa_Serasatipovenda ;
         gxTv_SdtSerasa_Serasacodtipovenda = sdt.gxTv_SdtSerasa_Serasacodtipovenda ;
         gxTv_SdtSerasa_Serasacodnivelrisco = sdt.gxTv_SdtSerasa_Serasacodnivelrisco ;
         gxTv_SdtSerasa_Serasatiporecomendacao = sdt.gxTv_SdtSerasa_Serasatiporecomendacao ;
         gxTv_SdtSerasa_Serasarecomendacaovenda = sdt.gxTv_SdtSerasa_Serasarecomendacaovenda ;
         gxTv_SdtSerasa_Serasacpfregular = sdt.gxTv_SdtSerasa_Serasacpfregular ;
         gxTv_SdtSerasa_Serasaretricaoativa = sdt.gxTv_SdtSerasa_Serasaretricaoativa ;
         gxTv_SdtSerasa_Serasaprotestoativo = sdt.gxTv_SdtSerasa_Serasaprotestoativo ;
         gxTv_SdtSerasa_Serasabaixocomprometimento = sdt.gxTv_SdtSerasa_Serasabaixocomprometimento ;
         gxTv_SdtSerasa_Serasavalorlimiterecomendado = sdt.gxTv_SdtSerasa_Serasavalorlimiterecomendado ;
         gxTv_SdtSerasa_Serasafaixaderendaestimada = sdt.gxTv_SdtSerasa_Serasafaixaderendaestimada ;
         gxTv_SdtSerasa_Serasamensagemrendaestimada = sdt.gxTv_SdtSerasa_Serasamensagemrendaestimada ;
         gxTv_SdtSerasa_Serasaanotacoescompletas = sdt.gxTv_SdtSerasa_Serasaanotacoescompletas ;
         gxTv_SdtSerasa_Serasaconsultasdetalhadas = sdt.gxTv_SdtSerasa_Serasaconsultasdetalhadas ;
         gxTv_SdtSerasa_Serasaanotacoesconsultaspc = sdt.gxTv_SdtSerasa_Serasaanotacoesconsultaspc ;
         gxTv_SdtSerasa_Serasaparticipacaosocietaria = sdt.gxTv_SdtSerasa_Serasaparticipacaosocietaria ;
         gxTv_SdtSerasa_Serasarendaestimada = sdt.gxTv_SdtSerasa_Serasarendaestimada ;
         gxTv_SdtSerasa_Serasahistoricopagamentopf = sdt.gxTv_SdtSerasa_Serasahistoricopagamentopf ;
         gxTv_SdtSerasa_Serasarecomendacompleto = sdt.gxTv_SdtSerasa_Serasarecomendacompleto ;
         gxTv_SdtSerasa_Serasascore = sdt.gxTv_SdtSerasa_Serasascore ;
         gxTv_SdtSerasa_Serasataxa = sdt.gxTv_SdtSerasa_Serasataxa ;
         gxTv_SdtSerasa_Serasamensagemscore = sdt.gxTv_SdtSerasa_Serasamensagemscore ;
         gxTv_SdtSerasa_Serasasituacaocpf = sdt.gxTv_SdtSerasa_Serasasituacaocpf ;
         gxTv_SdtSerasa_Serasadatanascimento = sdt.gxTv_SdtSerasa_Serasadatanascimento ;
         gxTv_SdtSerasa_Serasagenero = sdt.gxTv_SdtSerasa_Serasagenero ;
         gxTv_SdtSerasa_Serasanomemae = sdt.gxTv_SdtSerasa_Serasanomemae ;
         gxTv_SdtSerasa_Serasagrafia = sdt.gxTv_SdtSerasa_Serasagrafia ;
         gxTv_SdtSerasa_Serasajson = sdt.gxTv_SdtSerasa_Serasajson ;
         gxTv_SdtSerasa_Serasacountacoes_f = sdt.gxTv_SdtSerasa_Serasacountacoes_f ;
         gxTv_SdtSerasa_Serasacountenderecos_f = sdt.gxTv_SdtSerasa_Serasacountenderecos_f ;
         gxTv_SdtSerasa_Serasacountprotestos_f = sdt.gxTv_SdtSerasa_Serasacountprotestos_f ;
         gxTv_SdtSerasa_Serasacountocorrencias_f = sdt.gxTv_SdtSerasa_Serasacountocorrencias_f ;
         gxTv_SdtSerasa_Serasacountcheques_f = sdt.gxTv_SdtSerasa_Serasacountcheques_f ;
         gxTv_SdtSerasa_Mode = sdt.gxTv_SdtSerasa_Mode ;
         gxTv_SdtSerasa_Initialized = sdt.gxTv_SdtSerasa_Initialized ;
         gxTv_SdtSerasa_Serasaid_Z = sdt.gxTv_SdtSerasa_Serasaid_Z ;
         gxTv_SdtSerasa_Clienteid_Z = sdt.gxTv_SdtSerasa_Clienteid_Z ;
         gxTv_SdtSerasa_Clienterazaosocial_Z = sdt.gxTv_SdtSerasa_Clienterazaosocial_Z ;
         gxTv_SdtSerasa_Serasanumeroproposta_Z = sdt.gxTv_SdtSerasa_Serasanumeroproposta_Z ;
         gxTv_SdtSerasa_Serasapolitica_Z = sdt.gxTv_SdtSerasa_Serasapolitica_Z ;
         gxTv_SdtSerasa_Serasacreatedat_Z = sdt.gxTv_SdtSerasa_Serasacreatedat_Z ;
         gxTv_SdtSerasa_Serasatipovenda_Z = sdt.gxTv_SdtSerasa_Serasatipovenda_Z ;
         gxTv_SdtSerasa_Serasacodtipovenda_Z = sdt.gxTv_SdtSerasa_Serasacodtipovenda_Z ;
         gxTv_SdtSerasa_Serasacodnivelrisco_Z = sdt.gxTv_SdtSerasa_Serasacodnivelrisco_Z ;
         gxTv_SdtSerasa_Serasatiporecomendacao_Z = sdt.gxTv_SdtSerasa_Serasatiporecomendacao_Z ;
         gxTv_SdtSerasa_Serasarecomendacaovenda_Z = sdt.gxTv_SdtSerasa_Serasarecomendacaovenda_Z ;
         gxTv_SdtSerasa_Serasacpfregular_Z = sdt.gxTv_SdtSerasa_Serasacpfregular_Z ;
         gxTv_SdtSerasa_Serasaretricaoativa_Z = sdt.gxTv_SdtSerasa_Serasaretricaoativa_Z ;
         gxTv_SdtSerasa_Serasaprotestoativo_Z = sdt.gxTv_SdtSerasa_Serasaprotestoativo_Z ;
         gxTv_SdtSerasa_Serasabaixocomprometimento_Z = sdt.gxTv_SdtSerasa_Serasabaixocomprometimento_Z ;
         gxTv_SdtSerasa_Serasavalorlimiterecomendado_Z = sdt.gxTv_SdtSerasa_Serasavalorlimiterecomendado_Z ;
         gxTv_SdtSerasa_Serasafaixaderendaestimada_Z = sdt.gxTv_SdtSerasa_Serasafaixaderendaestimada_Z ;
         gxTv_SdtSerasa_Serasamensagemrendaestimada_Z = sdt.gxTv_SdtSerasa_Serasamensagemrendaestimada_Z ;
         gxTv_SdtSerasa_Serasaanotacoescompletas_Z = sdt.gxTv_SdtSerasa_Serasaanotacoescompletas_Z ;
         gxTv_SdtSerasa_Serasaconsultasdetalhadas_Z = sdt.gxTv_SdtSerasa_Serasaconsultasdetalhadas_Z ;
         gxTv_SdtSerasa_Serasaanotacoesconsultaspc_Z = sdt.gxTv_SdtSerasa_Serasaanotacoesconsultaspc_Z ;
         gxTv_SdtSerasa_Serasaparticipacaosocietaria_Z = sdt.gxTv_SdtSerasa_Serasaparticipacaosocietaria_Z ;
         gxTv_SdtSerasa_Serasarendaestimada_Z = sdt.gxTv_SdtSerasa_Serasarendaestimada_Z ;
         gxTv_SdtSerasa_Serasahistoricopagamentopf_Z = sdt.gxTv_SdtSerasa_Serasahistoricopagamentopf_Z ;
         gxTv_SdtSerasa_Serasarecomendacompleto_Z = sdt.gxTv_SdtSerasa_Serasarecomendacompleto_Z ;
         gxTv_SdtSerasa_Serasascore_Z = sdt.gxTv_SdtSerasa_Serasascore_Z ;
         gxTv_SdtSerasa_Serasataxa_Z = sdt.gxTv_SdtSerasa_Serasataxa_Z ;
         gxTv_SdtSerasa_Serasamensagemscore_Z = sdt.gxTv_SdtSerasa_Serasamensagemscore_Z ;
         gxTv_SdtSerasa_Serasasituacaocpf_Z = sdt.gxTv_SdtSerasa_Serasasituacaocpf_Z ;
         gxTv_SdtSerasa_Serasadatanascimento_Z = sdt.gxTv_SdtSerasa_Serasadatanascimento_Z ;
         gxTv_SdtSerasa_Serasagenero_Z = sdt.gxTv_SdtSerasa_Serasagenero_Z ;
         gxTv_SdtSerasa_Serasanomemae_Z = sdt.gxTv_SdtSerasa_Serasanomemae_Z ;
         gxTv_SdtSerasa_Serasagrafia_Z = sdt.gxTv_SdtSerasa_Serasagrafia_Z ;
         gxTv_SdtSerasa_Serasacountacoes_f_Z = sdt.gxTv_SdtSerasa_Serasacountacoes_f_Z ;
         gxTv_SdtSerasa_Serasacountenderecos_f_Z = sdt.gxTv_SdtSerasa_Serasacountenderecos_f_Z ;
         gxTv_SdtSerasa_Serasacountprotestos_f_Z = sdt.gxTv_SdtSerasa_Serasacountprotestos_f_Z ;
         gxTv_SdtSerasa_Serasacountocorrencias_f_Z = sdt.gxTv_SdtSerasa_Serasacountocorrencias_f_Z ;
         gxTv_SdtSerasa_Serasacountcheques_f_Z = sdt.gxTv_SdtSerasa_Serasacountcheques_f_Z ;
         gxTv_SdtSerasa_Serasaid_N = sdt.gxTv_SdtSerasa_Serasaid_N ;
         gxTv_SdtSerasa_Clienteid_N = sdt.gxTv_SdtSerasa_Clienteid_N ;
         gxTv_SdtSerasa_Clienterazaosocial_N = sdt.gxTv_SdtSerasa_Clienterazaosocial_N ;
         gxTv_SdtSerasa_Serasanumeroproposta_N = sdt.gxTv_SdtSerasa_Serasanumeroproposta_N ;
         gxTv_SdtSerasa_Serasapolitica_N = sdt.gxTv_SdtSerasa_Serasapolitica_N ;
         gxTv_SdtSerasa_Serasacreatedat_N = sdt.gxTv_SdtSerasa_Serasacreatedat_N ;
         gxTv_SdtSerasa_Serasatipovenda_N = sdt.gxTv_SdtSerasa_Serasatipovenda_N ;
         gxTv_SdtSerasa_Serasacodtipovenda_N = sdt.gxTv_SdtSerasa_Serasacodtipovenda_N ;
         gxTv_SdtSerasa_Serasacodnivelrisco_N = sdt.gxTv_SdtSerasa_Serasacodnivelrisco_N ;
         gxTv_SdtSerasa_Serasatiporecomendacao_N = sdt.gxTv_SdtSerasa_Serasatiporecomendacao_N ;
         gxTv_SdtSerasa_Serasarecomendacaovenda_N = sdt.gxTv_SdtSerasa_Serasarecomendacaovenda_N ;
         gxTv_SdtSerasa_Serasacpfregular_N = sdt.gxTv_SdtSerasa_Serasacpfregular_N ;
         gxTv_SdtSerasa_Serasaretricaoativa_N = sdt.gxTv_SdtSerasa_Serasaretricaoativa_N ;
         gxTv_SdtSerasa_Serasaprotestoativo_N = sdt.gxTv_SdtSerasa_Serasaprotestoativo_N ;
         gxTv_SdtSerasa_Serasabaixocomprometimento_N = sdt.gxTv_SdtSerasa_Serasabaixocomprometimento_N ;
         gxTv_SdtSerasa_Serasavalorlimiterecomendado_N = sdt.gxTv_SdtSerasa_Serasavalorlimiterecomendado_N ;
         gxTv_SdtSerasa_Serasafaixaderendaestimada_N = sdt.gxTv_SdtSerasa_Serasafaixaderendaestimada_N ;
         gxTv_SdtSerasa_Serasamensagemrendaestimada_N = sdt.gxTv_SdtSerasa_Serasamensagemrendaestimada_N ;
         gxTv_SdtSerasa_Serasaanotacoescompletas_N = sdt.gxTv_SdtSerasa_Serasaanotacoescompletas_N ;
         gxTv_SdtSerasa_Serasaconsultasdetalhadas_N = sdt.gxTv_SdtSerasa_Serasaconsultasdetalhadas_N ;
         gxTv_SdtSerasa_Serasaanotacoesconsultaspc_N = sdt.gxTv_SdtSerasa_Serasaanotacoesconsultaspc_N ;
         gxTv_SdtSerasa_Serasaparticipacaosocietaria_N = sdt.gxTv_SdtSerasa_Serasaparticipacaosocietaria_N ;
         gxTv_SdtSerasa_Serasarendaestimada_N = sdt.gxTv_SdtSerasa_Serasarendaestimada_N ;
         gxTv_SdtSerasa_Serasahistoricopagamentopf_N = sdt.gxTv_SdtSerasa_Serasahistoricopagamentopf_N ;
         gxTv_SdtSerasa_Serasarecomendacompleto_N = sdt.gxTv_SdtSerasa_Serasarecomendacompleto_N ;
         gxTv_SdtSerasa_Serasascore_N = sdt.gxTv_SdtSerasa_Serasascore_N ;
         gxTv_SdtSerasa_Serasataxa_N = sdt.gxTv_SdtSerasa_Serasataxa_N ;
         gxTv_SdtSerasa_Serasamensagemscore_N = sdt.gxTv_SdtSerasa_Serasamensagemscore_N ;
         gxTv_SdtSerasa_Serasasituacaocpf_N = sdt.gxTv_SdtSerasa_Serasasituacaocpf_N ;
         gxTv_SdtSerasa_Serasadatanascimento_N = sdt.gxTv_SdtSerasa_Serasadatanascimento_N ;
         gxTv_SdtSerasa_Serasagenero_N = sdt.gxTv_SdtSerasa_Serasagenero_N ;
         gxTv_SdtSerasa_Serasanomemae_N = sdt.gxTv_SdtSerasa_Serasanomemae_N ;
         gxTv_SdtSerasa_Serasagrafia_N = sdt.gxTv_SdtSerasa_Serasagrafia_N ;
         gxTv_SdtSerasa_Serasajson_N = sdt.gxTv_SdtSerasa_Serasajson_N ;
         gxTv_SdtSerasa_Serasacountacoes_f_N = sdt.gxTv_SdtSerasa_Serasacountacoes_f_N ;
         gxTv_SdtSerasa_Serasacountenderecos_f_N = sdt.gxTv_SdtSerasa_Serasacountenderecos_f_N ;
         gxTv_SdtSerasa_Serasacountprotestos_f_N = sdt.gxTv_SdtSerasa_Serasacountprotestos_f_N ;
         gxTv_SdtSerasa_Serasacountocorrencias_f_N = sdt.gxTv_SdtSerasa_Serasacountocorrencias_f_N ;
         gxTv_SdtSerasa_Serasacountcheques_f_N = sdt.gxTv_SdtSerasa_Serasacountcheques_f_N ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("SerasaId", gxTv_SdtSerasa_Serasaid, false, includeNonInitialized);
         AddObjectProperty("SerasaId_N", gxTv_SdtSerasa_Serasaid_N, false, includeNonInitialized);
         AddObjectProperty("ClienteId", gxTv_SdtSerasa_Clienteid, false, includeNonInitialized);
         AddObjectProperty("ClienteId_N", gxTv_SdtSerasa_Clienteid_N, false, includeNonInitialized);
         AddObjectProperty("ClienteRazaoSocial", gxTv_SdtSerasa_Clienterazaosocial, false, includeNonInitialized);
         AddObjectProperty("ClienteRazaoSocial_N", gxTv_SdtSerasa_Clienterazaosocial_N, false, includeNonInitialized);
         AddObjectProperty("SerasaNumeroProposta", gxTv_SdtSerasa_Serasanumeroproposta, false, includeNonInitialized);
         AddObjectProperty("SerasaNumeroProposta_N", gxTv_SdtSerasa_Serasanumeroproposta_N, false, includeNonInitialized);
         AddObjectProperty("SerasaPolitica", gxTv_SdtSerasa_Serasapolitica, false, includeNonInitialized);
         AddObjectProperty("SerasaPolitica_N", gxTv_SdtSerasa_Serasapolitica_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtSerasa_Serasacreatedat;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("SerasaCreatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("SerasaCreatedAt_N", gxTv_SdtSerasa_Serasacreatedat_N, false, includeNonInitialized);
         AddObjectProperty("SerasaTipoVenda", gxTv_SdtSerasa_Serasatipovenda, false, includeNonInitialized);
         AddObjectProperty("SerasaTipoVenda_N", gxTv_SdtSerasa_Serasatipovenda_N, false, includeNonInitialized);
         AddObjectProperty("SerasaCodTipoVenda", gxTv_SdtSerasa_Serasacodtipovenda, false, includeNonInitialized);
         AddObjectProperty("SerasaCodTipoVenda_N", gxTv_SdtSerasa_Serasacodtipovenda_N, false, includeNonInitialized);
         AddObjectProperty("SerasaCodNivelRisco", gxTv_SdtSerasa_Serasacodnivelrisco, false, includeNonInitialized);
         AddObjectProperty("SerasaCodNivelRisco_N", gxTv_SdtSerasa_Serasacodnivelrisco_N, false, includeNonInitialized);
         AddObjectProperty("SerasaTipoRecomendacao", gxTv_SdtSerasa_Serasatiporecomendacao, false, includeNonInitialized);
         AddObjectProperty("SerasaTipoRecomendacao_N", gxTv_SdtSerasa_Serasatiporecomendacao_N, false, includeNonInitialized);
         AddObjectProperty("SerasaRecomendacaoVenda", gxTv_SdtSerasa_Serasarecomendacaovenda, false, includeNonInitialized);
         AddObjectProperty("SerasaRecomendacaoVenda_N", gxTv_SdtSerasa_Serasarecomendacaovenda_N, false, includeNonInitialized);
         AddObjectProperty("SerasaCpfRegular", gxTv_SdtSerasa_Serasacpfregular, false, includeNonInitialized);
         AddObjectProperty("SerasaCpfRegular_N", gxTv_SdtSerasa_Serasacpfregular_N, false, includeNonInitialized);
         AddObjectProperty("SerasaRetricaoAtiva", gxTv_SdtSerasa_Serasaretricaoativa, false, includeNonInitialized);
         AddObjectProperty("SerasaRetricaoAtiva_N", gxTv_SdtSerasa_Serasaretricaoativa_N, false, includeNonInitialized);
         AddObjectProperty("SerasaProtestoAtivo", gxTv_SdtSerasa_Serasaprotestoativo, false, includeNonInitialized);
         AddObjectProperty("SerasaProtestoAtivo_N", gxTv_SdtSerasa_Serasaprotestoativo_N, false, includeNonInitialized);
         AddObjectProperty("SerasaBaixoComprometimento", gxTv_SdtSerasa_Serasabaixocomprometimento, false, includeNonInitialized);
         AddObjectProperty("SerasaBaixoComprometimento_N", gxTv_SdtSerasa_Serasabaixocomprometimento_N, false, includeNonInitialized);
         AddObjectProperty("SerasaValorLimiteRecomendado", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSerasa_Serasavalorlimiterecomendado, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("SerasaValorLimiteRecomendado_N", gxTv_SdtSerasa_Serasavalorlimiterecomendado_N, false, includeNonInitialized);
         AddObjectProperty("SerasaFaixaDeRendaEstimada", gxTv_SdtSerasa_Serasafaixaderendaestimada, false, includeNonInitialized);
         AddObjectProperty("SerasaFaixaDeRendaEstimada_N", gxTv_SdtSerasa_Serasafaixaderendaestimada_N, false, includeNonInitialized);
         AddObjectProperty("SerasaMensagemRendaEstimada", gxTv_SdtSerasa_Serasamensagemrendaestimada, false, includeNonInitialized);
         AddObjectProperty("SerasaMensagemRendaEstimada_N", gxTv_SdtSerasa_Serasamensagemrendaestimada_N, false, includeNonInitialized);
         AddObjectProperty("SerasaAnotacoesCompletas", gxTv_SdtSerasa_Serasaanotacoescompletas, false, includeNonInitialized);
         AddObjectProperty("SerasaAnotacoesCompletas_N", gxTv_SdtSerasa_Serasaanotacoescompletas_N, false, includeNonInitialized);
         AddObjectProperty("SerasaConsultasDetalhadas", gxTv_SdtSerasa_Serasaconsultasdetalhadas, false, includeNonInitialized);
         AddObjectProperty("SerasaConsultasDetalhadas_N", gxTv_SdtSerasa_Serasaconsultasdetalhadas_N, false, includeNonInitialized);
         AddObjectProperty("SerasaAnotacoesConsultaSPC", gxTv_SdtSerasa_Serasaanotacoesconsultaspc, false, includeNonInitialized);
         AddObjectProperty("SerasaAnotacoesConsultaSPC_N", gxTv_SdtSerasa_Serasaanotacoesconsultaspc_N, false, includeNonInitialized);
         AddObjectProperty("SerasaParticipacaoSocietaria", gxTv_SdtSerasa_Serasaparticipacaosocietaria, false, includeNonInitialized);
         AddObjectProperty("SerasaParticipacaoSocietaria_N", gxTv_SdtSerasa_Serasaparticipacaosocietaria_N, false, includeNonInitialized);
         AddObjectProperty("SerasaRendaEstimada", gxTv_SdtSerasa_Serasarendaestimada, false, includeNonInitialized);
         AddObjectProperty("SerasaRendaEstimada_N", gxTv_SdtSerasa_Serasarendaestimada_N, false, includeNonInitialized);
         AddObjectProperty("SerasaHistoricoPagamentoPF", gxTv_SdtSerasa_Serasahistoricopagamentopf, false, includeNonInitialized);
         AddObjectProperty("SerasaHistoricoPagamentoPF_N", gxTv_SdtSerasa_Serasahistoricopagamentopf_N, false, includeNonInitialized);
         AddObjectProperty("SerasaRecomendaCompleto", gxTv_SdtSerasa_Serasarecomendacompleto, false, includeNonInitialized);
         AddObjectProperty("SerasaRecomendaCompleto_N", gxTv_SdtSerasa_Serasarecomendacompleto_N, false, includeNonInitialized);
         AddObjectProperty("SerasaScore", gxTv_SdtSerasa_Serasascore, false, includeNonInitialized);
         AddObjectProperty("SerasaScore_N", gxTv_SdtSerasa_Serasascore_N, false, includeNonInitialized);
         AddObjectProperty("SerasaTaxa", gxTv_SdtSerasa_Serasataxa, false, includeNonInitialized);
         AddObjectProperty("SerasaTaxa_N", gxTv_SdtSerasa_Serasataxa_N, false, includeNonInitialized);
         AddObjectProperty("SerasaMensagemScore", gxTv_SdtSerasa_Serasamensagemscore, false, includeNonInitialized);
         AddObjectProperty("SerasaMensagemScore_N", gxTv_SdtSerasa_Serasamensagemscore_N, false, includeNonInitialized);
         AddObjectProperty("SerasaSituacaoCPF", gxTv_SdtSerasa_Serasasituacaocpf, false, includeNonInitialized);
         AddObjectProperty("SerasaSituacaoCPF_N", gxTv_SdtSerasa_Serasasituacaocpf_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtSerasa_Serasadatanascimento)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtSerasa_Serasadatanascimento)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtSerasa_Serasadatanascimento)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("SerasaDataNascimento", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("SerasaDataNascimento_N", gxTv_SdtSerasa_Serasadatanascimento_N, false, includeNonInitialized);
         AddObjectProperty("SerasaGenero", gxTv_SdtSerasa_Serasagenero, false, includeNonInitialized);
         AddObjectProperty("SerasaGenero_N", gxTv_SdtSerasa_Serasagenero_N, false, includeNonInitialized);
         AddObjectProperty("SerasaNomeMae", gxTv_SdtSerasa_Serasanomemae, false, includeNonInitialized);
         AddObjectProperty("SerasaNomeMae_N", gxTv_SdtSerasa_Serasanomemae_N, false, includeNonInitialized);
         AddObjectProperty("SerasaGrafia", gxTv_SdtSerasa_Serasagrafia, false, includeNonInitialized);
         AddObjectProperty("SerasaGrafia_N", gxTv_SdtSerasa_Serasagrafia_N, false, includeNonInitialized);
         AddObjectProperty("SerasaJSON", gxTv_SdtSerasa_Serasajson, false, includeNonInitialized);
         AddObjectProperty("SerasaJSON_N", gxTv_SdtSerasa_Serasajson_N, false, includeNonInitialized);
         AddObjectProperty("SerasaCountAcoes_F", gxTv_SdtSerasa_Serasacountacoes_f, false, includeNonInitialized);
         AddObjectProperty("SerasaCountAcoes_F_N", gxTv_SdtSerasa_Serasacountacoes_f_N, false, includeNonInitialized);
         AddObjectProperty("SerasaCountEnderecos_F", gxTv_SdtSerasa_Serasacountenderecos_f, false, includeNonInitialized);
         AddObjectProperty("SerasaCountEnderecos_F_N", gxTv_SdtSerasa_Serasacountenderecos_f_N, false, includeNonInitialized);
         AddObjectProperty("SerasaCountProtestos_F", gxTv_SdtSerasa_Serasacountprotestos_f, false, includeNonInitialized);
         AddObjectProperty("SerasaCountProtestos_F_N", gxTv_SdtSerasa_Serasacountprotestos_f_N, false, includeNonInitialized);
         AddObjectProperty("SerasaCountOcorrencias_F", gxTv_SdtSerasa_Serasacountocorrencias_f, false, includeNonInitialized);
         AddObjectProperty("SerasaCountOcorrencias_F_N", gxTv_SdtSerasa_Serasacountocorrencias_f_N, false, includeNonInitialized);
         AddObjectProperty("SerasaCountCheques_F", gxTv_SdtSerasa_Serasacountcheques_f, false, includeNonInitialized);
         AddObjectProperty("SerasaCountCheques_F_N", gxTv_SdtSerasa_Serasacountcheques_f_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtSerasa_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtSerasa_Initialized, false, includeNonInitialized);
            AddObjectProperty("SerasaId_Z", gxTv_SdtSerasa_Serasaid_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteId_Z", gxTv_SdtSerasa_Clienteid_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteRazaoSocial_Z", gxTv_SdtSerasa_Clienterazaosocial_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaNumeroProposta_Z", gxTv_SdtSerasa_Serasanumeroproposta_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaPolitica_Z", gxTv_SdtSerasa_Serasapolitica_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtSerasa_Serasacreatedat_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("SerasaCreatedAt_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("SerasaTipoVenda_Z", gxTv_SdtSerasa_Serasatipovenda_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaCodTipoVenda_Z", gxTv_SdtSerasa_Serasacodtipovenda_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaCodNivelRisco_Z", gxTv_SdtSerasa_Serasacodnivelrisco_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaTipoRecomendacao_Z", gxTv_SdtSerasa_Serasatiporecomendacao_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaRecomendacaoVenda_Z", gxTv_SdtSerasa_Serasarecomendacaovenda_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaCpfRegular_Z", gxTv_SdtSerasa_Serasacpfregular_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaRetricaoAtiva_Z", gxTv_SdtSerasa_Serasaretricaoativa_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaProtestoAtivo_Z", gxTv_SdtSerasa_Serasaprotestoativo_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaBaixoComprometimento_Z", gxTv_SdtSerasa_Serasabaixocomprometimento_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaValorLimiteRecomendado_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSerasa_Serasavalorlimiterecomendado_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("SerasaFaixaDeRendaEstimada_Z", gxTv_SdtSerasa_Serasafaixaderendaestimada_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaMensagemRendaEstimada_Z", gxTv_SdtSerasa_Serasamensagemrendaestimada_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaAnotacoesCompletas_Z", gxTv_SdtSerasa_Serasaanotacoescompletas_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaConsultasDetalhadas_Z", gxTv_SdtSerasa_Serasaconsultasdetalhadas_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaAnotacoesConsultaSPC_Z", gxTv_SdtSerasa_Serasaanotacoesconsultaspc_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaParticipacaoSocietaria_Z", gxTv_SdtSerasa_Serasaparticipacaosocietaria_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaRendaEstimada_Z", gxTv_SdtSerasa_Serasarendaestimada_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaHistoricoPagamentoPF_Z", gxTv_SdtSerasa_Serasahistoricopagamentopf_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaRecomendaCompleto_Z", gxTv_SdtSerasa_Serasarecomendacompleto_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaScore_Z", gxTv_SdtSerasa_Serasascore_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaTaxa_Z", gxTv_SdtSerasa_Serasataxa_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaMensagemScore_Z", gxTv_SdtSerasa_Serasamensagemscore_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaSituacaoCPF_Z", gxTv_SdtSerasa_Serasasituacaocpf_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtSerasa_Serasadatanascimento_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtSerasa_Serasadatanascimento_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtSerasa_Serasadatanascimento_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("SerasaDataNascimento_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("SerasaGenero_Z", gxTv_SdtSerasa_Serasagenero_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaNomeMae_Z", gxTv_SdtSerasa_Serasanomemae_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaGrafia_Z", gxTv_SdtSerasa_Serasagrafia_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaCountAcoes_F_Z", gxTv_SdtSerasa_Serasacountacoes_f_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaCountEnderecos_F_Z", gxTv_SdtSerasa_Serasacountenderecos_f_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaCountProtestos_F_Z", gxTv_SdtSerasa_Serasacountprotestos_f_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaCountOcorrencias_F_Z", gxTv_SdtSerasa_Serasacountocorrencias_f_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaCountCheques_F_Z", gxTv_SdtSerasa_Serasacountcheques_f_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaId_N", gxTv_SdtSerasa_Serasaid_N, false, includeNonInitialized);
            AddObjectProperty("ClienteId_N", gxTv_SdtSerasa_Clienteid_N, false, includeNonInitialized);
            AddObjectProperty("ClienteRazaoSocial_N", gxTv_SdtSerasa_Clienterazaosocial_N, false, includeNonInitialized);
            AddObjectProperty("SerasaNumeroProposta_N", gxTv_SdtSerasa_Serasanumeroproposta_N, false, includeNonInitialized);
            AddObjectProperty("SerasaPolitica_N", gxTv_SdtSerasa_Serasapolitica_N, false, includeNonInitialized);
            AddObjectProperty("SerasaCreatedAt_N", gxTv_SdtSerasa_Serasacreatedat_N, false, includeNonInitialized);
            AddObjectProperty("SerasaTipoVenda_N", gxTv_SdtSerasa_Serasatipovenda_N, false, includeNonInitialized);
            AddObjectProperty("SerasaCodTipoVenda_N", gxTv_SdtSerasa_Serasacodtipovenda_N, false, includeNonInitialized);
            AddObjectProperty("SerasaCodNivelRisco_N", gxTv_SdtSerasa_Serasacodnivelrisco_N, false, includeNonInitialized);
            AddObjectProperty("SerasaTipoRecomendacao_N", gxTv_SdtSerasa_Serasatiporecomendacao_N, false, includeNonInitialized);
            AddObjectProperty("SerasaRecomendacaoVenda_N", gxTv_SdtSerasa_Serasarecomendacaovenda_N, false, includeNonInitialized);
            AddObjectProperty("SerasaCpfRegular_N", gxTv_SdtSerasa_Serasacpfregular_N, false, includeNonInitialized);
            AddObjectProperty("SerasaRetricaoAtiva_N", gxTv_SdtSerasa_Serasaretricaoativa_N, false, includeNonInitialized);
            AddObjectProperty("SerasaProtestoAtivo_N", gxTv_SdtSerasa_Serasaprotestoativo_N, false, includeNonInitialized);
            AddObjectProperty("SerasaBaixoComprometimento_N", gxTv_SdtSerasa_Serasabaixocomprometimento_N, false, includeNonInitialized);
            AddObjectProperty("SerasaValorLimiteRecomendado_N", gxTv_SdtSerasa_Serasavalorlimiterecomendado_N, false, includeNonInitialized);
            AddObjectProperty("SerasaFaixaDeRendaEstimada_N", gxTv_SdtSerasa_Serasafaixaderendaestimada_N, false, includeNonInitialized);
            AddObjectProperty("SerasaMensagemRendaEstimada_N", gxTv_SdtSerasa_Serasamensagemrendaestimada_N, false, includeNonInitialized);
            AddObjectProperty("SerasaAnotacoesCompletas_N", gxTv_SdtSerasa_Serasaanotacoescompletas_N, false, includeNonInitialized);
            AddObjectProperty("SerasaConsultasDetalhadas_N", gxTv_SdtSerasa_Serasaconsultasdetalhadas_N, false, includeNonInitialized);
            AddObjectProperty("SerasaAnotacoesConsultaSPC_N", gxTv_SdtSerasa_Serasaanotacoesconsultaspc_N, false, includeNonInitialized);
            AddObjectProperty("SerasaParticipacaoSocietaria_N", gxTv_SdtSerasa_Serasaparticipacaosocietaria_N, false, includeNonInitialized);
            AddObjectProperty("SerasaRendaEstimada_N", gxTv_SdtSerasa_Serasarendaestimada_N, false, includeNonInitialized);
            AddObjectProperty("SerasaHistoricoPagamentoPF_N", gxTv_SdtSerasa_Serasahistoricopagamentopf_N, false, includeNonInitialized);
            AddObjectProperty("SerasaRecomendaCompleto_N", gxTv_SdtSerasa_Serasarecomendacompleto_N, false, includeNonInitialized);
            AddObjectProperty("SerasaScore_N", gxTv_SdtSerasa_Serasascore_N, false, includeNonInitialized);
            AddObjectProperty("SerasaTaxa_N", gxTv_SdtSerasa_Serasataxa_N, false, includeNonInitialized);
            AddObjectProperty("SerasaMensagemScore_N", gxTv_SdtSerasa_Serasamensagemscore_N, false, includeNonInitialized);
            AddObjectProperty("SerasaSituacaoCPF_N", gxTv_SdtSerasa_Serasasituacaocpf_N, false, includeNonInitialized);
            AddObjectProperty("SerasaDataNascimento_N", gxTv_SdtSerasa_Serasadatanascimento_N, false, includeNonInitialized);
            AddObjectProperty("SerasaGenero_N", gxTv_SdtSerasa_Serasagenero_N, false, includeNonInitialized);
            AddObjectProperty("SerasaNomeMae_N", gxTv_SdtSerasa_Serasanomemae_N, false, includeNonInitialized);
            AddObjectProperty("SerasaGrafia_N", gxTv_SdtSerasa_Serasagrafia_N, false, includeNonInitialized);
            AddObjectProperty("SerasaJSON_N", gxTv_SdtSerasa_Serasajson_N, false, includeNonInitialized);
            AddObjectProperty("SerasaCountAcoes_F_N", gxTv_SdtSerasa_Serasacountacoes_f_N, false, includeNonInitialized);
            AddObjectProperty("SerasaCountEnderecos_F_N", gxTv_SdtSerasa_Serasacountenderecos_f_N, false, includeNonInitialized);
            AddObjectProperty("SerasaCountProtestos_F_N", gxTv_SdtSerasa_Serasacountprotestos_f_N, false, includeNonInitialized);
            AddObjectProperty("SerasaCountOcorrencias_F_N", gxTv_SdtSerasa_Serasacountocorrencias_f_N, false, includeNonInitialized);
            AddObjectProperty("SerasaCountCheques_F_N", gxTv_SdtSerasa_Serasacountcheques_f_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtSerasa sdt )
      {
         if ( sdt.IsDirty("SerasaId") )
         {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasaid = sdt.gxTv_SdtSerasa_Serasaid ;
         }
         if ( sdt.IsDirty("ClienteId") )
         {
            gxTv_SdtSerasa_Clienteid_N = (short)(sdt.gxTv_SdtSerasa_Clienteid_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Clienteid = sdt.gxTv_SdtSerasa_Clienteid ;
         }
         if ( sdt.IsDirty("ClienteRazaoSocial") )
         {
            gxTv_SdtSerasa_Clienterazaosocial_N = (short)(sdt.gxTv_SdtSerasa_Clienterazaosocial_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Clienterazaosocial = sdt.gxTv_SdtSerasa_Clienterazaosocial ;
         }
         if ( sdt.IsDirty("SerasaNumeroProposta") )
         {
            gxTv_SdtSerasa_Serasanumeroproposta_N = (short)(sdt.gxTv_SdtSerasa_Serasanumeroproposta_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasanumeroproposta = sdt.gxTv_SdtSerasa_Serasanumeroproposta ;
         }
         if ( sdt.IsDirty("SerasaPolitica") )
         {
            gxTv_SdtSerasa_Serasapolitica_N = (short)(sdt.gxTv_SdtSerasa_Serasapolitica_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasapolitica = sdt.gxTv_SdtSerasa_Serasapolitica ;
         }
         if ( sdt.IsDirty("SerasaCreatedAt") )
         {
            gxTv_SdtSerasa_Serasacreatedat_N = (short)(sdt.gxTv_SdtSerasa_Serasacreatedat_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasacreatedat = sdt.gxTv_SdtSerasa_Serasacreatedat ;
         }
         if ( sdt.IsDirty("SerasaTipoVenda") )
         {
            gxTv_SdtSerasa_Serasatipovenda_N = (short)(sdt.gxTv_SdtSerasa_Serasatipovenda_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasatipovenda = sdt.gxTv_SdtSerasa_Serasatipovenda ;
         }
         if ( sdt.IsDirty("SerasaCodTipoVenda") )
         {
            gxTv_SdtSerasa_Serasacodtipovenda_N = (short)(sdt.gxTv_SdtSerasa_Serasacodtipovenda_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasacodtipovenda = sdt.gxTv_SdtSerasa_Serasacodtipovenda ;
         }
         if ( sdt.IsDirty("SerasaCodNivelRisco") )
         {
            gxTv_SdtSerasa_Serasacodnivelrisco_N = (short)(sdt.gxTv_SdtSerasa_Serasacodnivelrisco_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasacodnivelrisco = sdt.gxTv_SdtSerasa_Serasacodnivelrisco ;
         }
         if ( sdt.IsDirty("SerasaTipoRecomendacao") )
         {
            gxTv_SdtSerasa_Serasatiporecomendacao_N = (short)(sdt.gxTv_SdtSerasa_Serasatiporecomendacao_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasatiporecomendacao = sdt.gxTv_SdtSerasa_Serasatiporecomendacao ;
         }
         if ( sdt.IsDirty("SerasaRecomendacaoVenda") )
         {
            gxTv_SdtSerasa_Serasarecomendacaovenda_N = (short)(sdt.gxTv_SdtSerasa_Serasarecomendacaovenda_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasarecomendacaovenda = sdt.gxTv_SdtSerasa_Serasarecomendacaovenda ;
         }
         if ( sdt.IsDirty("SerasaCpfRegular") )
         {
            gxTv_SdtSerasa_Serasacpfregular_N = (short)(sdt.gxTv_SdtSerasa_Serasacpfregular_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasacpfregular = sdt.gxTv_SdtSerasa_Serasacpfregular ;
         }
         if ( sdt.IsDirty("SerasaRetricaoAtiva") )
         {
            gxTv_SdtSerasa_Serasaretricaoativa_N = (short)(sdt.gxTv_SdtSerasa_Serasaretricaoativa_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasaretricaoativa = sdt.gxTv_SdtSerasa_Serasaretricaoativa ;
         }
         if ( sdt.IsDirty("SerasaProtestoAtivo") )
         {
            gxTv_SdtSerasa_Serasaprotestoativo_N = (short)(sdt.gxTv_SdtSerasa_Serasaprotestoativo_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasaprotestoativo = sdt.gxTv_SdtSerasa_Serasaprotestoativo ;
         }
         if ( sdt.IsDirty("SerasaBaixoComprometimento") )
         {
            gxTv_SdtSerasa_Serasabaixocomprometimento_N = (short)(sdt.gxTv_SdtSerasa_Serasabaixocomprometimento_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasabaixocomprometimento = sdt.gxTv_SdtSerasa_Serasabaixocomprometimento ;
         }
         if ( sdt.IsDirty("SerasaValorLimiteRecomendado") )
         {
            gxTv_SdtSerasa_Serasavalorlimiterecomendado_N = (short)(sdt.gxTv_SdtSerasa_Serasavalorlimiterecomendado_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasavalorlimiterecomendado = sdt.gxTv_SdtSerasa_Serasavalorlimiterecomendado ;
         }
         if ( sdt.IsDirty("SerasaFaixaDeRendaEstimada") )
         {
            gxTv_SdtSerasa_Serasafaixaderendaestimada_N = (short)(sdt.gxTv_SdtSerasa_Serasafaixaderendaestimada_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasafaixaderendaestimada = sdt.gxTv_SdtSerasa_Serasafaixaderendaestimada ;
         }
         if ( sdt.IsDirty("SerasaMensagemRendaEstimada") )
         {
            gxTv_SdtSerasa_Serasamensagemrendaestimada_N = (short)(sdt.gxTv_SdtSerasa_Serasamensagemrendaestimada_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasamensagemrendaestimada = sdt.gxTv_SdtSerasa_Serasamensagemrendaestimada ;
         }
         if ( sdt.IsDirty("SerasaAnotacoesCompletas") )
         {
            gxTv_SdtSerasa_Serasaanotacoescompletas_N = (short)(sdt.gxTv_SdtSerasa_Serasaanotacoescompletas_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasaanotacoescompletas = sdt.gxTv_SdtSerasa_Serasaanotacoescompletas ;
         }
         if ( sdt.IsDirty("SerasaConsultasDetalhadas") )
         {
            gxTv_SdtSerasa_Serasaconsultasdetalhadas_N = (short)(sdt.gxTv_SdtSerasa_Serasaconsultasdetalhadas_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasaconsultasdetalhadas = sdt.gxTv_SdtSerasa_Serasaconsultasdetalhadas ;
         }
         if ( sdt.IsDirty("SerasaAnotacoesConsultaSPC") )
         {
            gxTv_SdtSerasa_Serasaanotacoesconsultaspc_N = (short)(sdt.gxTv_SdtSerasa_Serasaanotacoesconsultaspc_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasaanotacoesconsultaspc = sdt.gxTv_SdtSerasa_Serasaanotacoesconsultaspc ;
         }
         if ( sdt.IsDirty("SerasaParticipacaoSocietaria") )
         {
            gxTv_SdtSerasa_Serasaparticipacaosocietaria_N = (short)(sdt.gxTv_SdtSerasa_Serasaparticipacaosocietaria_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasaparticipacaosocietaria = sdt.gxTv_SdtSerasa_Serasaparticipacaosocietaria ;
         }
         if ( sdt.IsDirty("SerasaRendaEstimada") )
         {
            gxTv_SdtSerasa_Serasarendaestimada_N = (short)(sdt.gxTv_SdtSerasa_Serasarendaestimada_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasarendaestimada = sdt.gxTv_SdtSerasa_Serasarendaestimada ;
         }
         if ( sdt.IsDirty("SerasaHistoricoPagamentoPF") )
         {
            gxTv_SdtSerasa_Serasahistoricopagamentopf_N = (short)(sdt.gxTv_SdtSerasa_Serasahistoricopagamentopf_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasahistoricopagamentopf = sdt.gxTv_SdtSerasa_Serasahistoricopagamentopf ;
         }
         if ( sdt.IsDirty("SerasaRecomendaCompleto") )
         {
            gxTv_SdtSerasa_Serasarecomendacompleto_N = (short)(sdt.gxTv_SdtSerasa_Serasarecomendacompleto_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasarecomendacompleto = sdt.gxTv_SdtSerasa_Serasarecomendacompleto ;
         }
         if ( sdt.IsDirty("SerasaScore") )
         {
            gxTv_SdtSerasa_Serasascore_N = (short)(sdt.gxTv_SdtSerasa_Serasascore_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasascore = sdt.gxTv_SdtSerasa_Serasascore ;
         }
         if ( sdt.IsDirty("SerasaTaxa") )
         {
            gxTv_SdtSerasa_Serasataxa_N = (short)(sdt.gxTv_SdtSerasa_Serasataxa_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasataxa = sdt.gxTv_SdtSerasa_Serasataxa ;
         }
         if ( sdt.IsDirty("SerasaMensagemScore") )
         {
            gxTv_SdtSerasa_Serasamensagemscore_N = (short)(sdt.gxTv_SdtSerasa_Serasamensagemscore_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasamensagemscore = sdt.gxTv_SdtSerasa_Serasamensagemscore ;
         }
         if ( sdt.IsDirty("SerasaSituacaoCPF") )
         {
            gxTv_SdtSerasa_Serasasituacaocpf_N = (short)(sdt.gxTv_SdtSerasa_Serasasituacaocpf_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasasituacaocpf = sdt.gxTv_SdtSerasa_Serasasituacaocpf ;
         }
         if ( sdt.IsDirty("SerasaDataNascimento") )
         {
            gxTv_SdtSerasa_Serasadatanascimento_N = (short)(sdt.gxTv_SdtSerasa_Serasadatanascimento_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasadatanascimento = sdt.gxTv_SdtSerasa_Serasadatanascimento ;
         }
         if ( sdt.IsDirty("SerasaGenero") )
         {
            gxTv_SdtSerasa_Serasagenero_N = (short)(sdt.gxTv_SdtSerasa_Serasagenero_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasagenero = sdt.gxTv_SdtSerasa_Serasagenero ;
         }
         if ( sdt.IsDirty("SerasaNomeMae") )
         {
            gxTv_SdtSerasa_Serasanomemae_N = (short)(sdt.gxTv_SdtSerasa_Serasanomemae_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasanomemae = sdt.gxTv_SdtSerasa_Serasanomemae ;
         }
         if ( sdt.IsDirty("SerasaGrafia") )
         {
            gxTv_SdtSerasa_Serasagrafia_N = (short)(sdt.gxTv_SdtSerasa_Serasagrafia_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasagrafia = sdt.gxTv_SdtSerasa_Serasagrafia ;
         }
         if ( sdt.IsDirty("SerasaJSON") )
         {
            gxTv_SdtSerasa_Serasajson_N = (short)(sdt.gxTv_SdtSerasa_Serasajson_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasajson = sdt.gxTv_SdtSerasa_Serasajson ;
         }
         if ( sdt.IsDirty("SerasaCountAcoes_F") )
         {
            gxTv_SdtSerasa_Serasacountacoes_f_N = (short)(sdt.gxTv_SdtSerasa_Serasacountacoes_f_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasacountacoes_f = sdt.gxTv_SdtSerasa_Serasacountacoes_f ;
         }
         if ( sdt.IsDirty("SerasaCountEnderecos_F") )
         {
            gxTv_SdtSerasa_Serasacountenderecos_f_N = (short)(sdt.gxTv_SdtSerasa_Serasacountenderecos_f_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasacountenderecos_f = sdt.gxTv_SdtSerasa_Serasacountenderecos_f ;
         }
         if ( sdt.IsDirty("SerasaCountProtestos_F") )
         {
            gxTv_SdtSerasa_Serasacountprotestos_f_N = (short)(sdt.gxTv_SdtSerasa_Serasacountprotestos_f_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasacountprotestos_f = sdt.gxTv_SdtSerasa_Serasacountprotestos_f ;
         }
         if ( sdt.IsDirty("SerasaCountOcorrencias_F") )
         {
            gxTv_SdtSerasa_Serasacountocorrencias_f_N = (short)(sdt.gxTv_SdtSerasa_Serasacountocorrencias_f_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasacountocorrencias_f = sdt.gxTv_SdtSerasa_Serasacountocorrencias_f ;
         }
         if ( sdt.IsDirty("SerasaCountCheques_F") )
         {
            gxTv_SdtSerasa_Serasacountcheques_f_N = (short)(sdt.gxTv_SdtSerasa_Serasacountcheques_f_N);
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasacountcheques_f = sdt.gxTv_SdtSerasa_Serasacountcheques_f ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "SerasaId" )]
      [  XmlElement( ElementName = "SerasaId"   )]
      public int gxTpr_Serasaid
      {
         get {
            return gxTv_SdtSerasa_Serasaid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtSerasa_Serasaid != value )
            {
               gxTv_SdtSerasa_Mode = "INS";
               this.gxTv_SdtSerasa_Serasaid_Z_SetNull( );
               this.gxTv_SdtSerasa_Clienteid_Z_SetNull( );
               this.gxTv_SdtSerasa_Clienterazaosocial_Z_SetNull( );
               this.gxTv_SdtSerasa_Serasanumeroproposta_Z_SetNull( );
               this.gxTv_SdtSerasa_Serasapolitica_Z_SetNull( );
               this.gxTv_SdtSerasa_Serasacreatedat_Z_SetNull( );
               this.gxTv_SdtSerasa_Serasatipovenda_Z_SetNull( );
               this.gxTv_SdtSerasa_Serasacodtipovenda_Z_SetNull( );
               this.gxTv_SdtSerasa_Serasacodnivelrisco_Z_SetNull( );
               this.gxTv_SdtSerasa_Serasatiporecomendacao_Z_SetNull( );
               this.gxTv_SdtSerasa_Serasarecomendacaovenda_Z_SetNull( );
               this.gxTv_SdtSerasa_Serasacpfregular_Z_SetNull( );
               this.gxTv_SdtSerasa_Serasaretricaoativa_Z_SetNull( );
               this.gxTv_SdtSerasa_Serasaprotestoativo_Z_SetNull( );
               this.gxTv_SdtSerasa_Serasabaixocomprometimento_Z_SetNull( );
               this.gxTv_SdtSerasa_Serasavalorlimiterecomendado_Z_SetNull( );
               this.gxTv_SdtSerasa_Serasafaixaderendaestimada_Z_SetNull( );
               this.gxTv_SdtSerasa_Serasamensagemrendaestimada_Z_SetNull( );
               this.gxTv_SdtSerasa_Serasaanotacoescompletas_Z_SetNull( );
               this.gxTv_SdtSerasa_Serasaconsultasdetalhadas_Z_SetNull( );
               this.gxTv_SdtSerasa_Serasaanotacoesconsultaspc_Z_SetNull( );
               this.gxTv_SdtSerasa_Serasaparticipacaosocietaria_Z_SetNull( );
               this.gxTv_SdtSerasa_Serasarendaestimada_Z_SetNull( );
               this.gxTv_SdtSerasa_Serasahistoricopagamentopf_Z_SetNull( );
               this.gxTv_SdtSerasa_Serasarecomendacompleto_Z_SetNull( );
               this.gxTv_SdtSerasa_Serasascore_Z_SetNull( );
               this.gxTv_SdtSerasa_Serasataxa_Z_SetNull( );
               this.gxTv_SdtSerasa_Serasamensagemscore_Z_SetNull( );
               this.gxTv_SdtSerasa_Serasasituacaocpf_Z_SetNull( );
               this.gxTv_SdtSerasa_Serasadatanascimento_Z_SetNull( );
               this.gxTv_SdtSerasa_Serasagenero_Z_SetNull( );
               this.gxTv_SdtSerasa_Serasanomemae_Z_SetNull( );
               this.gxTv_SdtSerasa_Serasagrafia_Z_SetNull( );
               this.gxTv_SdtSerasa_Serasacountacoes_f_Z_SetNull( );
               this.gxTv_SdtSerasa_Serasacountenderecos_f_Z_SetNull( );
               this.gxTv_SdtSerasa_Serasacountprotestos_f_Z_SetNull( );
               this.gxTv_SdtSerasa_Serasacountocorrencias_f_Z_SetNull( );
               this.gxTv_SdtSerasa_Serasacountcheques_f_Z_SetNull( );
            }
            gxTv_SdtSerasa_Serasaid = value;
            SetDirty("Serasaid");
         }

      }

      [  SoapElement( ElementName = "ClienteId" )]
      [  XmlElement( ElementName = "ClienteId"   )]
      public int gxTpr_Clienteid
      {
         get {
            return gxTv_SdtSerasa_Clienteid ;
         }

         set {
            gxTv_SdtSerasa_Clienteid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Clienteid = value;
            SetDirty("Clienteid");
         }

      }

      public void gxTv_SdtSerasa_Clienteid_SetNull( )
      {
         gxTv_SdtSerasa_Clienteid_N = 1;
         gxTv_SdtSerasa_Clienteid = 0;
         SetDirty("Clienteid");
         return  ;
      }

      public bool gxTv_SdtSerasa_Clienteid_IsNull( )
      {
         return (gxTv_SdtSerasa_Clienteid_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteRazaoSocial" )]
      [  XmlElement( ElementName = "ClienteRazaoSocial"   )]
      public string gxTpr_Clienterazaosocial
      {
         get {
            return gxTv_SdtSerasa_Clienterazaosocial ;
         }

         set {
            gxTv_SdtSerasa_Clienterazaosocial_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Clienterazaosocial = value;
            SetDirty("Clienterazaosocial");
         }

      }

      public void gxTv_SdtSerasa_Clienterazaosocial_SetNull( )
      {
         gxTv_SdtSerasa_Clienterazaosocial_N = 1;
         gxTv_SdtSerasa_Clienterazaosocial = "";
         SetDirty("Clienterazaosocial");
         return  ;
      }

      public bool gxTv_SdtSerasa_Clienterazaosocial_IsNull( )
      {
         return (gxTv_SdtSerasa_Clienterazaosocial_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaNumeroProposta" )]
      [  XmlElement( ElementName = "SerasaNumeroProposta"   )]
      public string gxTpr_Serasanumeroproposta
      {
         get {
            return gxTv_SdtSerasa_Serasanumeroproposta ;
         }

         set {
            gxTv_SdtSerasa_Serasanumeroproposta_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasanumeroproposta = value;
            SetDirty("Serasanumeroproposta");
         }

      }

      public void gxTv_SdtSerasa_Serasanumeroproposta_SetNull( )
      {
         gxTv_SdtSerasa_Serasanumeroproposta_N = 1;
         gxTv_SdtSerasa_Serasanumeroproposta = "";
         SetDirty("Serasanumeroproposta");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasanumeroproposta_IsNull( )
      {
         return (gxTv_SdtSerasa_Serasanumeroproposta_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaPolitica" )]
      [  XmlElement( ElementName = "SerasaPolitica"   )]
      public decimal gxTpr_Serasapolitica
      {
         get {
            return gxTv_SdtSerasa_Serasapolitica ;
         }

         set {
            gxTv_SdtSerasa_Serasapolitica_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasapolitica = value;
            SetDirty("Serasapolitica");
         }

      }

      public void gxTv_SdtSerasa_Serasapolitica_SetNull( )
      {
         gxTv_SdtSerasa_Serasapolitica_N = 1;
         gxTv_SdtSerasa_Serasapolitica = 0;
         SetDirty("Serasapolitica");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasapolitica_IsNull( )
      {
         return (gxTv_SdtSerasa_Serasapolitica_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaCreatedAt" )]
      [  XmlElement( ElementName = "SerasaCreatedAt"  , IsNullable=true )]
      public string gxTpr_Serasacreatedat_Nullable
      {
         get {
            if ( gxTv_SdtSerasa_Serasacreatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtSerasa_Serasacreatedat).value ;
         }

         set {
            gxTv_SdtSerasa_Serasacreatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtSerasa_Serasacreatedat = DateTime.MinValue;
            else
               gxTv_SdtSerasa_Serasacreatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Serasacreatedat
      {
         get {
            return gxTv_SdtSerasa_Serasacreatedat ;
         }

         set {
            gxTv_SdtSerasa_Serasacreatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasacreatedat = value;
            SetDirty("Serasacreatedat");
         }

      }

      public void gxTv_SdtSerasa_Serasacreatedat_SetNull( )
      {
         gxTv_SdtSerasa_Serasacreatedat_N = 1;
         gxTv_SdtSerasa_Serasacreatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Serasacreatedat");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasacreatedat_IsNull( )
      {
         return (gxTv_SdtSerasa_Serasacreatedat_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaTipoVenda" )]
      [  XmlElement( ElementName = "SerasaTipoVenda"   )]
      public string gxTpr_Serasatipovenda
      {
         get {
            return gxTv_SdtSerasa_Serasatipovenda ;
         }

         set {
            gxTv_SdtSerasa_Serasatipovenda_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasatipovenda = value;
            SetDirty("Serasatipovenda");
         }

      }

      public void gxTv_SdtSerasa_Serasatipovenda_SetNull( )
      {
         gxTv_SdtSerasa_Serasatipovenda_N = 1;
         gxTv_SdtSerasa_Serasatipovenda = "";
         SetDirty("Serasatipovenda");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasatipovenda_IsNull( )
      {
         return (gxTv_SdtSerasa_Serasatipovenda_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaCodTipoVenda" )]
      [  XmlElement( ElementName = "SerasaCodTipoVenda"   )]
      public decimal gxTpr_Serasacodtipovenda
      {
         get {
            return gxTv_SdtSerasa_Serasacodtipovenda ;
         }

         set {
            gxTv_SdtSerasa_Serasacodtipovenda_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasacodtipovenda = value;
            SetDirty("Serasacodtipovenda");
         }

      }

      public void gxTv_SdtSerasa_Serasacodtipovenda_SetNull( )
      {
         gxTv_SdtSerasa_Serasacodtipovenda_N = 1;
         gxTv_SdtSerasa_Serasacodtipovenda = 0;
         SetDirty("Serasacodtipovenda");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasacodtipovenda_IsNull( )
      {
         return (gxTv_SdtSerasa_Serasacodtipovenda_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaCodNivelRisco" )]
      [  XmlElement( ElementName = "SerasaCodNivelRisco"   )]
      public decimal gxTpr_Serasacodnivelrisco
      {
         get {
            return gxTv_SdtSerasa_Serasacodnivelrisco ;
         }

         set {
            gxTv_SdtSerasa_Serasacodnivelrisco_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasacodnivelrisco = value;
            SetDirty("Serasacodnivelrisco");
         }

      }

      public void gxTv_SdtSerasa_Serasacodnivelrisco_SetNull( )
      {
         gxTv_SdtSerasa_Serasacodnivelrisco_N = 1;
         gxTv_SdtSerasa_Serasacodnivelrisco = 0;
         SetDirty("Serasacodnivelrisco");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasacodnivelrisco_IsNull( )
      {
         return (gxTv_SdtSerasa_Serasacodnivelrisco_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaTipoRecomendacao" )]
      [  XmlElement( ElementName = "SerasaTipoRecomendacao"   )]
      public string gxTpr_Serasatiporecomendacao
      {
         get {
            return gxTv_SdtSerasa_Serasatiporecomendacao ;
         }

         set {
            gxTv_SdtSerasa_Serasatiporecomendacao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasatiporecomendacao = value;
            SetDirty("Serasatiporecomendacao");
         }

      }

      public void gxTv_SdtSerasa_Serasatiporecomendacao_SetNull( )
      {
         gxTv_SdtSerasa_Serasatiporecomendacao_N = 1;
         gxTv_SdtSerasa_Serasatiporecomendacao = "";
         SetDirty("Serasatiporecomendacao");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasatiporecomendacao_IsNull( )
      {
         return (gxTv_SdtSerasa_Serasatiporecomendacao_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaRecomendacaoVenda" )]
      [  XmlElement( ElementName = "SerasaRecomendacaoVenda"   )]
      public string gxTpr_Serasarecomendacaovenda
      {
         get {
            return gxTv_SdtSerasa_Serasarecomendacaovenda ;
         }

         set {
            gxTv_SdtSerasa_Serasarecomendacaovenda_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasarecomendacaovenda = value;
            SetDirty("Serasarecomendacaovenda");
         }

      }

      public void gxTv_SdtSerasa_Serasarecomendacaovenda_SetNull( )
      {
         gxTv_SdtSerasa_Serasarecomendacaovenda_N = 1;
         gxTv_SdtSerasa_Serasarecomendacaovenda = "";
         SetDirty("Serasarecomendacaovenda");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasarecomendacaovenda_IsNull( )
      {
         return (gxTv_SdtSerasa_Serasarecomendacaovenda_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaCpfRegular" )]
      [  XmlElement( ElementName = "SerasaCpfRegular"   )]
      public bool gxTpr_Serasacpfregular
      {
         get {
            return gxTv_SdtSerasa_Serasacpfregular ;
         }

         set {
            gxTv_SdtSerasa_Serasacpfregular_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasacpfregular = value;
            SetDirty("Serasacpfregular");
         }

      }

      public void gxTv_SdtSerasa_Serasacpfregular_SetNull( )
      {
         gxTv_SdtSerasa_Serasacpfregular_N = 1;
         gxTv_SdtSerasa_Serasacpfregular = false;
         SetDirty("Serasacpfregular");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasacpfregular_IsNull( )
      {
         return (gxTv_SdtSerasa_Serasacpfregular_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaRetricaoAtiva" )]
      [  XmlElement( ElementName = "SerasaRetricaoAtiva"   )]
      public bool gxTpr_Serasaretricaoativa
      {
         get {
            return gxTv_SdtSerasa_Serasaretricaoativa ;
         }

         set {
            gxTv_SdtSerasa_Serasaretricaoativa_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasaretricaoativa = value;
            SetDirty("Serasaretricaoativa");
         }

      }

      public void gxTv_SdtSerasa_Serasaretricaoativa_SetNull( )
      {
         gxTv_SdtSerasa_Serasaretricaoativa_N = 1;
         gxTv_SdtSerasa_Serasaretricaoativa = false;
         SetDirty("Serasaretricaoativa");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasaretricaoativa_IsNull( )
      {
         return (gxTv_SdtSerasa_Serasaretricaoativa_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaProtestoAtivo" )]
      [  XmlElement( ElementName = "SerasaProtestoAtivo"   )]
      public bool gxTpr_Serasaprotestoativo
      {
         get {
            return gxTv_SdtSerasa_Serasaprotestoativo ;
         }

         set {
            gxTv_SdtSerasa_Serasaprotestoativo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasaprotestoativo = value;
            SetDirty("Serasaprotestoativo");
         }

      }

      public void gxTv_SdtSerasa_Serasaprotestoativo_SetNull( )
      {
         gxTv_SdtSerasa_Serasaprotestoativo_N = 1;
         gxTv_SdtSerasa_Serasaprotestoativo = false;
         SetDirty("Serasaprotestoativo");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasaprotestoativo_IsNull( )
      {
         return (gxTv_SdtSerasa_Serasaprotestoativo_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaBaixoComprometimento" )]
      [  XmlElement( ElementName = "SerasaBaixoComprometimento"   )]
      public bool gxTpr_Serasabaixocomprometimento
      {
         get {
            return gxTv_SdtSerasa_Serasabaixocomprometimento ;
         }

         set {
            gxTv_SdtSerasa_Serasabaixocomprometimento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasabaixocomprometimento = value;
            SetDirty("Serasabaixocomprometimento");
         }

      }

      public void gxTv_SdtSerasa_Serasabaixocomprometimento_SetNull( )
      {
         gxTv_SdtSerasa_Serasabaixocomprometimento_N = 1;
         gxTv_SdtSerasa_Serasabaixocomprometimento = false;
         SetDirty("Serasabaixocomprometimento");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasabaixocomprometimento_IsNull( )
      {
         return (gxTv_SdtSerasa_Serasabaixocomprometimento_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaValorLimiteRecomendado" )]
      [  XmlElement( ElementName = "SerasaValorLimiteRecomendado"   )]
      public decimal gxTpr_Serasavalorlimiterecomendado
      {
         get {
            return gxTv_SdtSerasa_Serasavalorlimiterecomendado ;
         }

         set {
            gxTv_SdtSerasa_Serasavalorlimiterecomendado_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasavalorlimiterecomendado = value;
            SetDirty("Serasavalorlimiterecomendado");
         }

      }

      public void gxTv_SdtSerasa_Serasavalorlimiterecomendado_SetNull( )
      {
         gxTv_SdtSerasa_Serasavalorlimiterecomendado_N = 1;
         gxTv_SdtSerasa_Serasavalorlimiterecomendado = 0;
         SetDirty("Serasavalorlimiterecomendado");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasavalorlimiterecomendado_IsNull( )
      {
         return (gxTv_SdtSerasa_Serasavalorlimiterecomendado_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaFaixaDeRendaEstimada" )]
      [  XmlElement( ElementName = "SerasaFaixaDeRendaEstimada"   )]
      public decimal gxTpr_Serasafaixaderendaestimada
      {
         get {
            return gxTv_SdtSerasa_Serasafaixaderendaestimada ;
         }

         set {
            gxTv_SdtSerasa_Serasafaixaderendaestimada_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasafaixaderendaestimada = value;
            SetDirty("Serasafaixaderendaestimada");
         }

      }

      public void gxTv_SdtSerasa_Serasafaixaderendaestimada_SetNull( )
      {
         gxTv_SdtSerasa_Serasafaixaderendaestimada_N = 1;
         gxTv_SdtSerasa_Serasafaixaderendaestimada = 0;
         SetDirty("Serasafaixaderendaestimada");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasafaixaderendaestimada_IsNull( )
      {
         return (gxTv_SdtSerasa_Serasafaixaderendaestimada_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaMensagemRendaEstimada" )]
      [  XmlElement( ElementName = "SerasaMensagemRendaEstimada"   )]
      public string gxTpr_Serasamensagemrendaestimada
      {
         get {
            return gxTv_SdtSerasa_Serasamensagemrendaestimada ;
         }

         set {
            gxTv_SdtSerasa_Serasamensagemrendaestimada_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasamensagemrendaestimada = value;
            SetDirty("Serasamensagemrendaestimada");
         }

      }

      public void gxTv_SdtSerasa_Serasamensagemrendaestimada_SetNull( )
      {
         gxTv_SdtSerasa_Serasamensagemrendaestimada_N = 1;
         gxTv_SdtSerasa_Serasamensagemrendaestimada = "";
         SetDirty("Serasamensagemrendaestimada");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasamensagemrendaestimada_IsNull( )
      {
         return (gxTv_SdtSerasa_Serasamensagemrendaestimada_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaAnotacoesCompletas" )]
      [  XmlElement( ElementName = "SerasaAnotacoesCompletas"   )]
      public bool gxTpr_Serasaanotacoescompletas
      {
         get {
            return gxTv_SdtSerasa_Serasaanotacoescompletas ;
         }

         set {
            gxTv_SdtSerasa_Serasaanotacoescompletas_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasaanotacoescompletas = value;
            SetDirty("Serasaanotacoescompletas");
         }

      }

      public void gxTv_SdtSerasa_Serasaanotacoescompletas_SetNull( )
      {
         gxTv_SdtSerasa_Serasaanotacoescompletas_N = 1;
         gxTv_SdtSerasa_Serasaanotacoescompletas = false;
         SetDirty("Serasaanotacoescompletas");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasaanotacoescompletas_IsNull( )
      {
         return (gxTv_SdtSerasa_Serasaanotacoescompletas_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaConsultasDetalhadas" )]
      [  XmlElement( ElementName = "SerasaConsultasDetalhadas"   )]
      public bool gxTpr_Serasaconsultasdetalhadas
      {
         get {
            return gxTv_SdtSerasa_Serasaconsultasdetalhadas ;
         }

         set {
            gxTv_SdtSerasa_Serasaconsultasdetalhadas_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasaconsultasdetalhadas = value;
            SetDirty("Serasaconsultasdetalhadas");
         }

      }

      public void gxTv_SdtSerasa_Serasaconsultasdetalhadas_SetNull( )
      {
         gxTv_SdtSerasa_Serasaconsultasdetalhadas_N = 1;
         gxTv_SdtSerasa_Serasaconsultasdetalhadas = false;
         SetDirty("Serasaconsultasdetalhadas");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasaconsultasdetalhadas_IsNull( )
      {
         return (gxTv_SdtSerasa_Serasaconsultasdetalhadas_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaAnotacoesConsultaSPC" )]
      [  XmlElement( ElementName = "SerasaAnotacoesConsultaSPC"   )]
      public bool gxTpr_Serasaanotacoesconsultaspc
      {
         get {
            return gxTv_SdtSerasa_Serasaanotacoesconsultaspc ;
         }

         set {
            gxTv_SdtSerasa_Serasaanotacoesconsultaspc_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasaanotacoesconsultaspc = value;
            SetDirty("Serasaanotacoesconsultaspc");
         }

      }

      public void gxTv_SdtSerasa_Serasaanotacoesconsultaspc_SetNull( )
      {
         gxTv_SdtSerasa_Serasaanotacoesconsultaspc_N = 1;
         gxTv_SdtSerasa_Serasaanotacoesconsultaspc = false;
         SetDirty("Serasaanotacoesconsultaspc");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasaanotacoesconsultaspc_IsNull( )
      {
         return (gxTv_SdtSerasa_Serasaanotacoesconsultaspc_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaParticipacaoSocietaria" )]
      [  XmlElement( ElementName = "SerasaParticipacaoSocietaria"   )]
      public bool gxTpr_Serasaparticipacaosocietaria
      {
         get {
            return gxTv_SdtSerasa_Serasaparticipacaosocietaria ;
         }

         set {
            gxTv_SdtSerasa_Serasaparticipacaosocietaria_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasaparticipacaosocietaria = value;
            SetDirty("Serasaparticipacaosocietaria");
         }

      }

      public void gxTv_SdtSerasa_Serasaparticipacaosocietaria_SetNull( )
      {
         gxTv_SdtSerasa_Serasaparticipacaosocietaria_N = 1;
         gxTv_SdtSerasa_Serasaparticipacaosocietaria = false;
         SetDirty("Serasaparticipacaosocietaria");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasaparticipacaosocietaria_IsNull( )
      {
         return (gxTv_SdtSerasa_Serasaparticipacaosocietaria_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaRendaEstimada" )]
      [  XmlElement( ElementName = "SerasaRendaEstimada"   )]
      public bool gxTpr_Serasarendaestimada
      {
         get {
            return gxTv_SdtSerasa_Serasarendaestimada ;
         }

         set {
            gxTv_SdtSerasa_Serasarendaestimada_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasarendaestimada = value;
            SetDirty("Serasarendaestimada");
         }

      }

      public void gxTv_SdtSerasa_Serasarendaestimada_SetNull( )
      {
         gxTv_SdtSerasa_Serasarendaestimada_N = 1;
         gxTv_SdtSerasa_Serasarendaestimada = false;
         SetDirty("Serasarendaestimada");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasarendaestimada_IsNull( )
      {
         return (gxTv_SdtSerasa_Serasarendaestimada_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaHistoricoPagamentoPF" )]
      [  XmlElement( ElementName = "SerasaHistoricoPagamentoPF"   )]
      public bool gxTpr_Serasahistoricopagamentopf
      {
         get {
            return gxTv_SdtSerasa_Serasahistoricopagamentopf ;
         }

         set {
            gxTv_SdtSerasa_Serasahistoricopagamentopf_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasahistoricopagamentopf = value;
            SetDirty("Serasahistoricopagamentopf");
         }

      }

      public void gxTv_SdtSerasa_Serasahistoricopagamentopf_SetNull( )
      {
         gxTv_SdtSerasa_Serasahistoricopagamentopf_N = 1;
         gxTv_SdtSerasa_Serasahistoricopagamentopf = false;
         SetDirty("Serasahistoricopagamentopf");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasahistoricopagamentopf_IsNull( )
      {
         return (gxTv_SdtSerasa_Serasahistoricopagamentopf_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaRecomendaCompleto" )]
      [  XmlElement( ElementName = "SerasaRecomendaCompleto"   )]
      public bool gxTpr_Serasarecomendacompleto
      {
         get {
            return gxTv_SdtSerasa_Serasarecomendacompleto ;
         }

         set {
            gxTv_SdtSerasa_Serasarecomendacompleto_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasarecomendacompleto = value;
            SetDirty("Serasarecomendacompleto");
         }

      }

      public void gxTv_SdtSerasa_Serasarecomendacompleto_SetNull( )
      {
         gxTv_SdtSerasa_Serasarecomendacompleto_N = 1;
         gxTv_SdtSerasa_Serasarecomendacompleto = false;
         SetDirty("Serasarecomendacompleto");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasarecomendacompleto_IsNull( )
      {
         return (gxTv_SdtSerasa_Serasarecomendacompleto_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaScore" )]
      [  XmlElement( ElementName = "SerasaScore"   )]
      public short gxTpr_Serasascore
      {
         get {
            return gxTv_SdtSerasa_Serasascore ;
         }

         set {
            gxTv_SdtSerasa_Serasascore_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasascore = value;
            SetDirty("Serasascore");
         }

      }

      public void gxTv_SdtSerasa_Serasascore_SetNull( )
      {
         gxTv_SdtSerasa_Serasascore_N = 1;
         gxTv_SdtSerasa_Serasascore = 0;
         SetDirty("Serasascore");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasascore_IsNull( )
      {
         return (gxTv_SdtSerasa_Serasascore_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaTaxa" )]
      [  XmlElement( ElementName = "SerasaTaxa"   )]
      public decimal gxTpr_Serasataxa
      {
         get {
            return gxTv_SdtSerasa_Serasataxa ;
         }

         set {
            gxTv_SdtSerasa_Serasataxa_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasataxa = value;
            SetDirty("Serasataxa");
         }

      }

      public void gxTv_SdtSerasa_Serasataxa_SetNull( )
      {
         gxTv_SdtSerasa_Serasataxa_N = 1;
         gxTv_SdtSerasa_Serasataxa = 0;
         SetDirty("Serasataxa");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasataxa_IsNull( )
      {
         return (gxTv_SdtSerasa_Serasataxa_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaMensagemScore" )]
      [  XmlElement( ElementName = "SerasaMensagemScore"   )]
      public string gxTpr_Serasamensagemscore
      {
         get {
            return gxTv_SdtSerasa_Serasamensagemscore ;
         }

         set {
            gxTv_SdtSerasa_Serasamensagemscore_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasamensagemscore = value;
            SetDirty("Serasamensagemscore");
         }

      }

      public void gxTv_SdtSerasa_Serasamensagemscore_SetNull( )
      {
         gxTv_SdtSerasa_Serasamensagemscore_N = 1;
         gxTv_SdtSerasa_Serasamensagemscore = "";
         SetDirty("Serasamensagemscore");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasamensagemscore_IsNull( )
      {
         return (gxTv_SdtSerasa_Serasamensagemscore_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaSituacaoCPF" )]
      [  XmlElement( ElementName = "SerasaSituacaoCPF"   )]
      public string gxTpr_Serasasituacaocpf
      {
         get {
            return gxTv_SdtSerasa_Serasasituacaocpf ;
         }

         set {
            gxTv_SdtSerasa_Serasasituacaocpf_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasasituacaocpf = value;
            SetDirty("Serasasituacaocpf");
         }

      }

      public void gxTv_SdtSerasa_Serasasituacaocpf_SetNull( )
      {
         gxTv_SdtSerasa_Serasasituacaocpf_N = 1;
         gxTv_SdtSerasa_Serasasituacaocpf = "";
         SetDirty("Serasasituacaocpf");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasasituacaocpf_IsNull( )
      {
         return (gxTv_SdtSerasa_Serasasituacaocpf_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaDataNascimento" )]
      [  XmlElement( ElementName = "SerasaDataNascimento"  , IsNullable=true )]
      public string gxTpr_Serasadatanascimento_Nullable
      {
         get {
            if ( gxTv_SdtSerasa_Serasadatanascimento == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtSerasa_Serasadatanascimento).value ;
         }

         set {
            gxTv_SdtSerasa_Serasadatanascimento_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtSerasa_Serasadatanascimento = DateTime.MinValue;
            else
               gxTv_SdtSerasa_Serasadatanascimento = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Serasadatanascimento
      {
         get {
            return gxTv_SdtSerasa_Serasadatanascimento ;
         }

         set {
            gxTv_SdtSerasa_Serasadatanascimento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasadatanascimento = value;
            SetDirty("Serasadatanascimento");
         }

      }

      public void gxTv_SdtSerasa_Serasadatanascimento_SetNull( )
      {
         gxTv_SdtSerasa_Serasadatanascimento_N = 1;
         gxTv_SdtSerasa_Serasadatanascimento = (DateTime)(DateTime.MinValue);
         SetDirty("Serasadatanascimento");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasadatanascimento_IsNull( )
      {
         return (gxTv_SdtSerasa_Serasadatanascimento_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaGenero" )]
      [  XmlElement( ElementName = "SerasaGenero"   )]
      public string gxTpr_Serasagenero
      {
         get {
            return gxTv_SdtSerasa_Serasagenero ;
         }

         set {
            gxTv_SdtSerasa_Serasagenero_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasagenero = value;
            SetDirty("Serasagenero");
         }

      }

      public void gxTv_SdtSerasa_Serasagenero_SetNull( )
      {
         gxTv_SdtSerasa_Serasagenero_N = 1;
         gxTv_SdtSerasa_Serasagenero = "";
         SetDirty("Serasagenero");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasagenero_IsNull( )
      {
         return (gxTv_SdtSerasa_Serasagenero_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaNomeMae" )]
      [  XmlElement( ElementName = "SerasaNomeMae"   )]
      public string gxTpr_Serasanomemae
      {
         get {
            return gxTv_SdtSerasa_Serasanomemae ;
         }

         set {
            gxTv_SdtSerasa_Serasanomemae_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasanomemae = value;
            SetDirty("Serasanomemae");
         }

      }

      public void gxTv_SdtSerasa_Serasanomemae_SetNull( )
      {
         gxTv_SdtSerasa_Serasanomemae_N = 1;
         gxTv_SdtSerasa_Serasanomemae = "";
         SetDirty("Serasanomemae");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasanomemae_IsNull( )
      {
         return (gxTv_SdtSerasa_Serasanomemae_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaGrafia" )]
      [  XmlElement( ElementName = "SerasaGrafia"   )]
      public string gxTpr_Serasagrafia
      {
         get {
            return gxTv_SdtSerasa_Serasagrafia ;
         }

         set {
            gxTv_SdtSerasa_Serasagrafia_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasagrafia = value;
            SetDirty("Serasagrafia");
         }

      }

      public void gxTv_SdtSerasa_Serasagrafia_SetNull( )
      {
         gxTv_SdtSerasa_Serasagrafia_N = 1;
         gxTv_SdtSerasa_Serasagrafia = "";
         SetDirty("Serasagrafia");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasagrafia_IsNull( )
      {
         return (gxTv_SdtSerasa_Serasagrafia_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaJSON" )]
      [  XmlElement( ElementName = "SerasaJSON"   )]
      public string gxTpr_Serasajson
      {
         get {
            return gxTv_SdtSerasa_Serasajson ;
         }

         set {
            gxTv_SdtSerasa_Serasajson_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasajson = value;
            SetDirty("Serasajson");
         }

      }

      public void gxTv_SdtSerasa_Serasajson_SetNull( )
      {
         gxTv_SdtSerasa_Serasajson_N = 1;
         gxTv_SdtSerasa_Serasajson = "";
         SetDirty("Serasajson");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasajson_IsNull( )
      {
         return (gxTv_SdtSerasa_Serasajson_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaCountAcoes_F" )]
      [  XmlElement( ElementName = "SerasaCountAcoes_F"   )]
      public short gxTpr_Serasacountacoes_f
      {
         get {
            return gxTv_SdtSerasa_Serasacountacoes_f ;
         }

         set {
            gxTv_SdtSerasa_Serasacountacoes_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasacountacoes_f = value;
            SetDirty("Serasacountacoes_f");
         }

      }

      public void gxTv_SdtSerasa_Serasacountacoes_f_SetNull( )
      {
         gxTv_SdtSerasa_Serasacountacoes_f_N = 1;
         gxTv_SdtSerasa_Serasacountacoes_f = 0;
         SetDirty("Serasacountacoes_f");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasacountacoes_f_IsNull( )
      {
         return (gxTv_SdtSerasa_Serasacountacoes_f_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaCountEnderecos_F" )]
      [  XmlElement( ElementName = "SerasaCountEnderecos_F"   )]
      public short gxTpr_Serasacountenderecos_f
      {
         get {
            return gxTv_SdtSerasa_Serasacountenderecos_f ;
         }

         set {
            gxTv_SdtSerasa_Serasacountenderecos_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasacountenderecos_f = value;
            SetDirty("Serasacountenderecos_f");
         }

      }

      public void gxTv_SdtSerasa_Serasacountenderecos_f_SetNull( )
      {
         gxTv_SdtSerasa_Serasacountenderecos_f_N = 1;
         gxTv_SdtSerasa_Serasacountenderecos_f = 0;
         SetDirty("Serasacountenderecos_f");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasacountenderecos_f_IsNull( )
      {
         return (gxTv_SdtSerasa_Serasacountenderecos_f_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaCountProtestos_F" )]
      [  XmlElement( ElementName = "SerasaCountProtestos_F"   )]
      public short gxTpr_Serasacountprotestos_f
      {
         get {
            return gxTv_SdtSerasa_Serasacountprotestos_f ;
         }

         set {
            gxTv_SdtSerasa_Serasacountprotestos_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasacountprotestos_f = value;
            SetDirty("Serasacountprotestos_f");
         }

      }

      public void gxTv_SdtSerasa_Serasacountprotestos_f_SetNull( )
      {
         gxTv_SdtSerasa_Serasacountprotestos_f_N = 1;
         gxTv_SdtSerasa_Serasacountprotestos_f = 0;
         SetDirty("Serasacountprotestos_f");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasacountprotestos_f_IsNull( )
      {
         return (gxTv_SdtSerasa_Serasacountprotestos_f_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaCountOcorrencias_F" )]
      [  XmlElement( ElementName = "SerasaCountOcorrencias_F"   )]
      public short gxTpr_Serasacountocorrencias_f
      {
         get {
            return gxTv_SdtSerasa_Serasacountocorrencias_f ;
         }

         set {
            gxTv_SdtSerasa_Serasacountocorrencias_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasacountocorrencias_f = value;
            SetDirty("Serasacountocorrencias_f");
         }

      }

      public void gxTv_SdtSerasa_Serasacountocorrencias_f_SetNull( )
      {
         gxTv_SdtSerasa_Serasacountocorrencias_f_N = 1;
         gxTv_SdtSerasa_Serasacountocorrencias_f = 0;
         SetDirty("Serasacountocorrencias_f");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasacountocorrencias_f_IsNull( )
      {
         return (gxTv_SdtSerasa_Serasacountocorrencias_f_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaCountCheques_F" )]
      [  XmlElement( ElementName = "SerasaCountCheques_F"   )]
      public short gxTpr_Serasacountcheques_f
      {
         get {
            return gxTv_SdtSerasa_Serasacountcheques_f ;
         }

         set {
            gxTv_SdtSerasa_Serasacountcheques_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasacountcheques_f = value;
            SetDirty("Serasacountcheques_f");
         }

      }

      public void gxTv_SdtSerasa_Serasacountcheques_f_SetNull( )
      {
         gxTv_SdtSerasa_Serasacountcheques_f_N = 1;
         gxTv_SdtSerasa_Serasacountcheques_f = 0;
         SetDirty("Serasacountcheques_f");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasacountcheques_f_IsNull( )
      {
         return (gxTv_SdtSerasa_Serasacountcheques_f_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtSerasa_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtSerasa_Mode_SetNull( )
      {
         gxTv_SdtSerasa_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtSerasa_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtSerasa_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtSerasa_Initialized_SetNull( )
      {
         gxTv_SdtSerasa_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtSerasa_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaId_Z" )]
      [  XmlElement( ElementName = "SerasaId_Z"   )]
      public int gxTpr_Serasaid_Z
      {
         get {
            return gxTv_SdtSerasa_Serasaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasaid_Z = value;
            SetDirty("Serasaid_Z");
         }

      }

      public void gxTv_SdtSerasa_Serasaid_Z_SetNull( )
      {
         gxTv_SdtSerasa_Serasaid_Z = 0;
         SetDirty("Serasaid_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteId_Z" )]
      [  XmlElement( ElementName = "ClienteId_Z"   )]
      public int gxTpr_Clienteid_Z
      {
         get {
            return gxTv_SdtSerasa_Clienteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Clienteid_Z = value;
            SetDirty("Clienteid_Z");
         }

      }

      public void gxTv_SdtSerasa_Clienteid_Z_SetNull( )
      {
         gxTv_SdtSerasa_Clienteid_Z = 0;
         SetDirty("Clienteid_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Clienteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteRazaoSocial_Z" )]
      [  XmlElement( ElementName = "ClienteRazaoSocial_Z"   )]
      public string gxTpr_Clienterazaosocial_Z
      {
         get {
            return gxTv_SdtSerasa_Clienterazaosocial_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Clienterazaosocial_Z = value;
            SetDirty("Clienterazaosocial_Z");
         }

      }

      public void gxTv_SdtSerasa_Clienterazaosocial_Z_SetNull( )
      {
         gxTv_SdtSerasa_Clienterazaosocial_Z = "";
         SetDirty("Clienterazaosocial_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Clienterazaosocial_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaNumeroProposta_Z" )]
      [  XmlElement( ElementName = "SerasaNumeroProposta_Z"   )]
      public string gxTpr_Serasanumeroproposta_Z
      {
         get {
            return gxTv_SdtSerasa_Serasanumeroproposta_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasanumeroproposta_Z = value;
            SetDirty("Serasanumeroproposta_Z");
         }

      }

      public void gxTv_SdtSerasa_Serasanumeroproposta_Z_SetNull( )
      {
         gxTv_SdtSerasa_Serasanumeroproposta_Z = "";
         SetDirty("Serasanumeroproposta_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasanumeroproposta_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaPolitica_Z" )]
      [  XmlElement( ElementName = "SerasaPolitica_Z"   )]
      public decimal gxTpr_Serasapolitica_Z
      {
         get {
            return gxTv_SdtSerasa_Serasapolitica_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasapolitica_Z = value;
            SetDirty("Serasapolitica_Z");
         }

      }

      public void gxTv_SdtSerasa_Serasapolitica_Z_SetNull( )
      {
         gxTv_SdtSerasa_Serasapolitica_Z = 0;
         SetDirty("Serasapolitica_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasapolitica_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaCreatedAt_Z" )]
      [  XmlElement( ElementName = "SerasaCreatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Serasacreatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtSerasa_Serasacreatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtSerasa_Serasacreatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtSerasa_Serasacreatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtSerasa_Serasacreatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Serasacreatedat_Z
      {
         get {
            return gxTv_SdtSerasa_Serasacreatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasacreatedat_Z = value;
            SetDirty("Serasacreatedat_Z");
         }

      }

      public void gxTv_SdtSerasa_Serasacreatedat_Z_SetNull( )
      {
         gxTv_SdtSerasa_Serasacreatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Serasacreatedat_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasacreatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaTipoVenda_Z" )]
      [  XmlElement( ElementName = "SerasaTipoVenda_Z"   )]
      public string gxTpr_Serasatipovenda_Z
      {
         get {
            return gxTv_SdtSerasa_Serasatipovenda_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasatipovenda_Z = value;
            SetDirty("Serasatipovenda_Z");
         }

      }

      public void gxTv_SdtSerasa_Serasatipovenda_Z_SetNull( )
      {
         gxTv_SdtSerasa_Serasatipovenda_Z = "";
         SetDirty("Serasatipovenda_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasatipovenda_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaCodTipoVenda_Z" )]
      [  XmlElement( ElementName = "SerasaCodTipoVenda_Z"   )]
      public decimal gxTpr_Serasacodtipovenda_Z
      {
         get {
            return gxTv_SdtSerasa_Serasacodtipovenda_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasacodtipovenda_Z = value;
            SetDirty("Serasacodtipovenda_Z");
         }

      }

      public void gxTv_SdtSerasa_Serasacodtipovenda_Z_SetNull( )
      {
         gxTv_SdtSerasa_Serasacodtipovenda_Z = 0;
         SetDirty("Serasacodtipovenda_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasacodtipovenda_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaCodNivelRisco_Z" )]
      [  XmlElement( ElementName = "SerasaCodNivelRisco_Z"   )]
      public decimal gxTpr_Serasacodnivelrisco_Z
      {
         get {
            return gxTv_SdtSerasa_Serasacodnivelrisco_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasacodnivelrisco_Z = value;
            SetDirty("Serasacodnivelrisco_Z");
         }

      }

      public void gxTv_SdtSerasa_Serasacodnivelrisco_Z_SetNull( )
      {
         gxTv_SdtSerasa_Serasacodnivelrisco_Z = 0;
         SetDirty("Serasacodnivelrisco_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasacodnivelrisco_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaTipoRecomendacao_Z" )]
      [  XmlElement( ElementName = "SerasaTipoRecomendacao_Z"   )]
      public string gxTpr_Serasatiporecomendacao_Z
      {
         get {
            return gxTv_SdtSerasa_Serasatiporecomendacao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasatiporecomendacao_Z = value;
            SetDirty("Serasatiporecomendacao_Z");
         }

      }

      public void gxTv_SdtSerasa_Serasatiporecomendacao_Z_SetNull( )
      {
         gxTv_SdtSerasa_Serasatiporecomendacao_Z = "";
         SetDirty("Serasatiporecomendacao_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasatiporecomendacao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaRecomendacaoVenda_Z" )]
      [  XmlElement( ElementName = "SerasaRecomendacaoVenda_Z"   )]
      public string gxTpr_Serasarecomendacaovenda_Z
      {
         get {
            return gxTv_SdtSerasa_Serasarecomendacaovenda_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasarecomendacaovenda_Z = value;
            SetDirty("Serasarecomendacaovenda_Z");
         }

      }

      public void gxTv_SdtSerasa_Serasarecomendacaovenda_Z_SetNull( )
      {
         gxTv_SdtSerasa_Serasarecomendacaovenda_Z = "";
         SetDirty("Serasarecomendacaovenda_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasarecomendacaovenda_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaCpfRegular_Z" )]
      [  XmlElement( ElementName = "SerasaCpfRegular_Z"   )]
      public bool gxTpr_Serasacpfregular_Z
      {
         get {
            return gxTv_SdtSerasa_Serasacpfregular_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasacpfregular_Z = value;
            SetDirty("Serasacpfregular_Z");
         }

      }

      public void gxTv_SdtSerasa_Serasacpfregular_Z_SetNull( )
      {
         gxTv_SdtSerasa_Serasacpfregular_Z = false;
         SetDirty("Serasacpfregular_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasacpfregular_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaRetricaoAtiva_Z" )]
      [  XmlElement( ElementName = "SerasaRetricaoAtiva_Z"   )]
      public bool gxTpr_Serasaretricaoativa_Z
      {
         get {
            return gxTv_SdtSerasa_Serasaretricaoativa_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasaretricaoativa_Z = value;
            SetDirty("Serasaretricaoativa_Z");
         }

      }

      public void gxTv_SdtSerasa_Serasaretricaoativa_Z_SetNull( )
      {
         gxTv_SdtSerasa_Serasaretricaoativa_Z = false;
         SetDirty("Serasaretricaoativa_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasaretricaoativa_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaProtestoAtivo_Z" )]
      [  XmlElement( ElementName = "SerasaProtestoAtivo_Z"   )]
      public bool gxTpr_Serasaprotestoativo_Z
      {
         get {
            return gxTv_SdtSerasa_Serasaprotestoativo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasaprotestoativo_Z = value;
            SetDirty("Serasaprotestoativo_Z");
         }

      }

      public void gxTv_SdtSerasa_Serasaprotestoativo_Z_SetNull( )
      {
         gxTv_SdtSerasa_Serasaprotestoativo_Z = false;
         SetDirty("Serasaprotestoativo_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasaprotestoativo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaBaixoComprometimento_Z" )]
      [  XmlElement( ElementName = "SerasaBaixoComprometimento_Z"   )]
      public bool gxTpr_Serasabaixocomprometimento_Z
      {
         get {
            return gxTv_SdtSerasa_Serasabaixocomprometimento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasabaixocomprometimento_Z = value;
            SetDirty("Serasabaixocomprometimento_Z");
         }

      }

      public void gxTv_SdtSerasa_Serasabaixocomprometimento_Z_SetNull( )
      {
         gxTv_SdtSerasa_Serasabaixocomprometimento_Z = false;
         SetDirty("Serasabaixocomprometimento_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasabaixocomprometimento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaValorLimiteRecomendado_Z" )]
      [  XmlElement( ElementName = "SerasaValorLimiteRecomendado_Z"   )]
      public decimal gxTpr_Serasavalorlimiterecomendado_Z
      {
         get {
            return gxTv_SdtSerasa_Serasavalorlimiterecomendado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasavalorlimiterecomendado_Z = value;
            SetDirty("Serasavalorlimiterecomendado_Z");
         }

      }

      public void gxTv_SdtSerasa_Serasavalorlimiterecomendado_Z_SetNull( )
      {
         gxTv_SdtSerasa_Serasavalorlimiterecomendado_Z = 0;
         SetDirty("Serasavalorlimiterecomendado_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasavalorlimiterecomendado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaFaixaDeRendaEstimada_Z" )]
      [  XmlElement( ElementName = "SerasaFaixaDeRendaEstimada_Z"   )]
      public decimal gxTpr_Serasafaixaderendaestimada_Z
      {
         get {
            return gxTv_SdtSerasa_Serasafaixaderendaestimada_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasafaixaderendaestimada_Z = value;
            SetDirty("Serasafaixaderendaestimada_Z");
         }

      }

      public void gxTv_SdtSerasa_Serasafaixaderendaestimada_Z_SetNull( )
      {
         gxTv_SdtSerasa_Serasafaixaderendaestimada_Z = 0;
         SetDirty("Serasafaixaderendaestimada_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasafaixaderendaestimada_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaMensagemRendaEstimada_Z" )]
      [  XmlElement( ElementName = "SerasaMensagemRendaEstimada_Z"   )]
      public string gxTpr_Serasamensagemrendaestimada_Z
      {
         get {
            return gxTv_SdtSerasa_Serasamensagemrendaestimada_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasamensagemrendaestimada_Z = value;
            SetDirty("Serasamensagemrendaestimada_Z");
         }

      }

      public void gxTv_SdtSerasa_Serasamensagemrendaestimada_Z_SetNull( )
      {
         gxTv_SdtSerasa_Serasamensagemrendaestimada_Z = "";
         SetDirty("Serasamensagemrendaestimada_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasamensagemrendaestimada_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaAnotacoesCompletas_Z" )]
      [  XmlElement( ElementName = "SerasaAnotacoesCompletas_Z"   )]
      public bool gxTpr_Serasaanotacoescompletas_Z
      {
         get {
            return gxTv_SdtSerasa_Serasaanotacoescompletas_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasaanotacoescompletas_Z = value;
            SetDirty("Serasaanotacoescompletas_Z");
         }

      }

      public void gxTv_SdtSerasa_Serasaanotacoescompletas_Z_SetNull( )
      {
         gxTv_SdtSerasa_Serasaanotacoescompletas_Z = false;
         SetDirty("Serasaanotacoescompletas_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasaanotacoescompletas_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaConsultasDetalhadas_Z" )]
      [  XmlElement( ElementName = "SerasaConsultasDetalhadas_Z"   )]
      public bool gxTpr_Serasaconsultasdetalhadas_Z
      {
         get {
            return gxTv_SdtSerasa_Serasaconsultasdetalhadas_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasaconsultasdetalhadas_Z = value;
            SetDirty("Serasaconsultasdetalhadas_Z");
         }

      }

      public void gxTv_SdtSerasa_Serasaconsultasdetalhadas_Z_SetNull( )
      {
         gxTv_SdtSerasa_Serasaconsultasdetalhadas_Z = false;
         SetDirty("Serasaconsultasdetalhadas_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasaconsultasdetalhadas_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaAnotacoesConsultaSPC_Z" )]
      [  XmlElement( ElementName = "SerasaAnotacoesConsultaSPC_Z"   )]
      public bool gxTpr_Serasaanotacoesconsultaspc_Z
      {
         get {
            return gxTv_SdtSerasa_Serasaanotacoesconsultaspc_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasaanotacoesconsultaspc_Z = value;
            SetDirty("Serasaanotacoesconsultaspc_Z");
         }

      }

      public void gxTv_SdtSerasa_Serasaanotacoesconsultaspc_Z_SetNull( )
      {
         gxTv_SdtSerasa_Serasaanotacoesconsultaspc_Z = false;
         SetDirty("Serasaanotacoesconsultaspc_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasaanotacoesconsultaspc_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaParticipacaoSocietaria_Z" )]
      [  XmlElement( ElementName = "SerasaParticipacaoSocietaria_Z"   )]
      public bool gxTpr_Serasaparticipacaosocietaria_Z
      {
         get {
            return gxTv_SdtSerasa_Serasaparticipacaosocietaria_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasaparticipacaosocietaria_Z = value;
            SetDirty("Serasaparticipacaosocietaria_Z");
         }

      }

      public void gxTv_SdtSerasa_Serasaparticipacaosocietaria_Z_SetNull( )
      {
         gxTv_SdtSerasa_Serasaparticipacaosocietaria_Z = false;
         SetDirty("Serasaparticipacaosocietaria_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasaparticipacaosocietaria_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaRendaEstimada_Z" )]
      [  XmlElement( ElementName = "SerasaRendaEstimada_Z"   )]
      public bool gxTpr_Serasarendaestimada_Z
      {
         get {
            return gxTv_SdtSerasa_Serasarendaestimada_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasarendaestimada_Z = value;
            SetDirty("Serasarendaestimada_Z");
         }

      }

      public void gxTv_SdtSerasa_Serasarendaestimada_Z_SetNull( )
      {
         gxTv_SdtSerasa_Serasarendaestimada_Z = false;
         SetDirty("Serasarendaestimada_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasarendaestimada_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaHistoricoPagamentoPF_Z" )]
      [  XmlElement( ElementName = "SerasaHistoricoPagamentoPF_Z"   )]
      public bool gxTpr_Serasahistoricopagamentopf_Z
      {
         get {
            return gxTv_SdtSerasa_Serasahistoricopagamentopf_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasahistoricopagamentopf_Z = value;
            SetDirty("Serasahistoricopagamentopf_Z");
         }

      }

      public void gxTv_SdtSerasa_Serasahistoricopagamentopf_Z_SetNull( )
      {
         gxTv_SdtSerasa_Serasahistoricopagamentopf_Z = false;
         SetDirty("Serasahistoricopagamentopf_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasahistoricopagamentopf_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaRecomendaCompleto_Z" )]
      [  XmlElement( ElementName = "SerasaRecomendaCompleto_Z"   )]
      public bool gxTpr_Serasarecomendacompleto_Z
      {
         get {
            return gxTv_SdtSerasa_Serasarecomendacompleto_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasarecomendacompleto_Z = value;
            SetDirty("Serasarecomendacompleto_Z");
         }

      }

      public void gxTv_SdtSerasa_Serasarecomendacompleto_Z_SetNull( )
      {
         gxTv_SdtSerasa_Serasarecomendacompleto_Z = false;
         SetDirty("Serasarecomendacompleto_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasarecomendacompleto_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaScore_Z" )]
      [  XmlElement( ElementName = "SerasaScore_Z"   )]
      public short gxTpr_Serasascore_Z
      {
         get {
            return gxTv_SdtSerasa_Serasascore_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasascore_Z = value;
            SetDirty("Serasascore_Z");
         }

      }

      public void gxTv_SdtSerasa_Serasascore_Z_SetNull( )
      {
         gxTv_SdtSerasa_Serasascore_Z = 0;
         SetDirty("Serasascore_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasascore_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaTaxa_Z" )]
      [  XmlElement( ElementName = "SerasaTaxa_Z"   )]
      public decimal gxTpr_Serasataxa_Z
      {
         get {
            return gxTv_SdtSerasa_Serasataxa_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasataxa_Z = value;
            SetDirty("Serasataxa_Z");
         }

      }

      public void gxTv_SdtSerasa_Serasataxa_Z_SetNull( )
      {
         gxTv_SdtSerasa_Serasataxa_Z = 0;
         SetDirty("Serasataxa_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasataxa_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaMensagemScore_Z" )]
      [  XmlElement( ElementName = "SerasaMensagemScore_Z"   )]
      public string gxTpr_Serasamensagemscore_Z
      {
         get {
            return gxTv_SdtSerasa_Serasamensagemscore_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasamensagemscore_Z = value;
            SetDirty("Serasamensagemscore_Z");
         }

      }

      public void gxTv_SdtSerasa_Serasamensagemscore_Z_SetNull( )
      {
         gxTv_SdtSerasa_Serasamensagemscore_Z = "";
         SetDirty("Serasamensagemscore_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasamensagemscore_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaSituacaoCPF_Z" )]
      [  XmlElement( ElementName = "SerasaSituacaoCPF_Z"   )]
      public string gxTpr_Serasasituacaocpf_Z
      {
         get {
            return gxTv_SdtSerasa_Serasasituacaocpf_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasasituacaocpf_Z = value;
            SetDirty("Serasasituacaocpf_Z");
         }

      }

      public void gxTv_SdtSerasa_Serasasituacaocpf_Z_SetNull( )
      {
         gxTv_SdtSerasa_Serasasituacaocpf_Z = "";
         SetDirty("Serasasituacaocpf_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasasituacaocpf_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaDataNascimento_Z" )]
      [  XmlElement( ElementName = "SerasaDataNascimento_Z"  , IsNullable=true )]
      public string gxTpr_Serasadatanascimento_Z_Nullable
      {
         get {
            if ( gxTv_SdtSerasa_Serasadatanascimento_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtSerasa_Serasadatanascimento_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtSerasa_Serasadatanascimento_Z = DateTime.MinValue;
            else
               gxTv_SdtSerasa_Serasadatanascimento_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Serasadatanascimento_Z
      {
         get {
            return gxTv_SdtSerasa_Serasadatanascimento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasadatanascimento_Z = value;
            SetDirty("Serasadatanascimento_Z");
         }

      }

      public void gxTv_SdtSerasa_Serasadatanascimento_Z_SetNull( )
      {
         gxTv_SdtSerasa_Serasadatanascimento_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Serasadatanascimento_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasadatanascimento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaGenero_Z" )]
      [  XmlElement( ElementName = "SerasaGenero_Z"   )]
      public string gxTpr_Serasagenero_Z
      {
         get {
            return gxTv_SdtSerasa_Serasagenero_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasagenero_Z = value;
            SetDirty("Serasagenero_Z");
         }

      }

      public void gxTv_SdtSerasa_Serasagenero_Z_SetNull( )
      {
         gxTv_SdtSerasa_Serasagenero_Z = "";
         SetDirty("Serasagenero_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasagenero_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaNomeMae_Z" )]
      [  XmlElement( ElementName = "SerasaNomeMae_Z"   )]
      public string gxTpr_Serasanomemae_Z
      {
         get {
            return gxTv_SdtSerasa_Serasanomemae_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasanomemae_Z = value;
            SetDirty("Serasanomemae_Z");
         }

      }

      public void gxTv_SdtSerasa_Serasanomemae_Z_SetNull( )
      {
         gxTv_SdtSerasa_Serasanomemae_Z = "";
         SetDirty("Serasanomemae_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasanomemae_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaGrafia_Z" )]
      [  XmlElement( ElementName = "SerasaGrafia_Z"   )]
      public string gxTpr_Serasagrafia_Z
      {
         get {
            return gxTv_SdtSerasa_Serasagrafia_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasagrafia_Z = value;
            SetDirty("Serasagrafia_Z");
         }

      }

      public void gxTv_SdtSerasa_Serasagrafia_Z_SetNull( )
      {
         gxTv_SdtSerasa_Serasagrafia_Z = "";
         SetDirty("Serasagrafia_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasagrafia_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaCountAcoes_F_Z" )]
      [  XmlElement( ElementName = "SerasaCountAcoes_F_Z"   )]
      public short gxTpr_Serasacountacoes_f_Z
      {
         get {
            return gxTv_SdtSerasa_Serasacountacoes_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasacountacoes_f_Z = value;
            SetDirty("Serasacountacoes_f_Z");
         }

      }

      public void gxTv_SdtSerasa_Serasacountacoes_f_Z_SetNull( )
      {
         gxTv_SdtSerasa_Serasacountacoes_f_Z = 0;
         SetDirty("Serasacountacoes_f_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasacountacoes_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaCountEnderecos_F_Z" )]
      [  XmlElement( ElementName = "SerasaCountEnderecos_F_Z"   )]
      public short gxTpr_Serasacountenderecos_f_Z
      {
         get {
            return gxTv_SdtSerasa_Serasacountenderecos_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasacountenderecos_f_Z = value;
            SetDirty("Serasacountenderecos_f_Z");
         }

      }

      public void gxTv_SdtSerasa_Serasacountenderecos_f_Z_SetNull( )
      {
         gxTv_SdtSerasa_Serasacountenderecos_f_Z = 0;
         SetDirty("Serasacountenderecos_f_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasacountenderecos_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaCountProtestos_F_Z" )]
      [  XmlElement( ElementName = "SerasaCountProtestos_F_Z"   )]
      public short gxTpr_Serasacountprotestos_f_Z
      {
         get {
            return gxTv_SdtSerasa_Serasacountprotestos_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasacountprotestos_f_Z = value;
            SetDirty("Serasacountprotestos_f_Z");
         }

      }

      public void gxTv_SdtSerasa_Serasacountprotestos_f_Z_SetNull( )
      {
         gxTv_SdtSerasa_Serasacountprotestos_f_Z = 0;
         SetDirty("Serasacountprotestos_f_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasacountprotestos_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaCountOcorrencias_F_Z" )]
      [  XmlElement( ElementName = "SerasaCountOcorrencias_F_Z"   )]
      public short gxTpr_Serasacountocorrencias_f_Z
      {
         get {
            return gxTv_SdtSerasa_Serasacountocorrencias_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasacountocorrencias_f_Z = value;
            SetDirty("Serasacountocorrencias_f_Z");
         }

      }

      public void gxTv_SdtSerasa_Serasacountocorrencias_f_Z_SetNull( )
      {
         gxTv_SdtSerasa_Serasacountocorrencias_f_Z = 0;
         SetDirty("Serasacountocorrencias_f_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasacountocorrencias_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaCountCheques_F_Z" )]
      [  XmlElement( ElementName = "SerasaCountCheques_F_Z"   )]
      public short gxTpr_Serasacountcheques_f_Z
      {
         get {
            return gxTv_SdtSerasa_Serasacountcheques_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasacountcheques_f_Z = value;
            SetDirty("Serasacountcheques_f_Z");
         }

      }

      public void gxTv_SdtSerasa_Serasacountcheques_f_Z_SetNull( )
      {
         gxTv_SdtSerasa_Serasacountcheques_f_Z = 0;
         SetDirty("Serasacountcheques_f_Z");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasacountcheques_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaId_N" )]
      [  XmlElement( ElementName = "SerasaId_N"   )]
      public short gxTpr_Serasaid_N
      {
         get {
            return gxTv_SdtSerasa_Serasaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasaid_N = value;
            SetDirty("Serasaid_N");
         }

      }

      public void gxTv_SdtSerasa_Serasaid_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasaid_N = 0;
         SetDirty("Serasaid_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteId_N" )]
      [  XmlElement( ElementName = "ClienteId_N"   )]
      public short gxTpr_Clienteid_N
      {
         get {
            return gxTv_SdtSerasa_Clienteid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Clienteid_N = value;
            SetDirty("Clienteid_N");
         }

      }

      public void gxTv_SdtSerasa_Clienteid_N_SetNull( )
      {
         gxTv_SdtSerasa_Clienteid_N = 0;
         SetDirty("Clienteid_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Clienteid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteRazaoSocial_N" )]
      [  XmlElement( ElementName = "ClienteRazaoSocial_N"   )]
      public short gxTpr_Clienterazaosocial_N
      {
         get {
            return gxTv_SdtSerasa_Clienterazaosocial_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Clienterazaosocial_N = value;
            SetDirty("Clienterazaosocial_N");
         }

      }

      public void gxTv_SdtSerasa_Clienterazaosocial_N_SetNull( )
      {
         gxTv_SdtSerasa_Clienterazaosocial_N = 0;
         SetDirty("Clienterazaosocial_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Clienterazaosocial_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaNumeroProposta_N" )]
      [  XmlElement( ElementName = "SerasaNumeroProposta_N"   )]
      public short gxTpr_Serasanumeroproposta_N
      {
         get {
            return gxTv_SdtSerasa_Serasanumeroproposta_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasanumeroproposta_N = value;
            SetDirty("Serasanumeroproposta_N");
         }

      }

      public void gxTv_SdtSerasa_Serasanumeroproposta_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasanumeroproposta_N = 0;
         SetDirty("Serasanumeroproposta_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasanumeroproposta_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaPolitica_N" )]
      [  XmlElement( ElementName = "SerasaPolitica_N"   )]
      public short gxTpr_Serasapolitica_N
      {
         get {
            return gxTv_SdtSerasa_Serasapolitica_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasapolitica_N = value;
            SetDirty("Serasapolitica_N");
         }

      }

      public void gxTv_SdtSerasa_Serasapolitica_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasapolitica_N = 0;
         SetDirty("Serasapolitica_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasapolitica_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaCreatedAt_N" )]
      [  XmlElement( ElementName = "SerasaCreatedAt_N"   )]
      public short gxTpr_Serasacreatedat_N
      {
         get {
            return gxTv_SdtSerasa_Serasacreatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasacreatedat_N = value;
            SetDirty("Serasacreatedat_N");
         }

      }

      public void gxTv_SdtSerasa_Serasacreatedat_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasacreatedat_N = 0;
         SetDirty("Serasacreatedat_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasacreatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaTipoVenda_N" )]
      [  XmlElement( ElementName = "SerasaTipoVenda_N"   )]
      public short gxTpr_Serasatipovenda_N
      {
         get {
            return gxTv_SdtSerasa_Serasatipovenda_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasatipovenda_N = value;
            SetDirty("Serasatipovenda_N");
         }

      }

      public void gxTv_SdtSerasa_Serasatipovenda_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasatipovenda_N = 0;
         SetDirty("Serasatipovenda_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasatipovenda_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaCodTipoVenda_N" )]
      [  XmlElement( ElementName = "SerasaCodTipoVenda_N"   )]
      public short gxTpr_Serasacodtipovenda_N
      {
         get {
            return gxTv_SdtSerasa_Serasacodtipovenda_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasacodtipovenda_N = value;
            SetDirty("Serasacodtipovenda_N");
         }

      }

      public void gxTv_SdtSerasa_Serasacodtipovenda_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasacodtipovenda_N = 0;
         SetDirty("Serasacodtipovenda_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasacodtipovenda_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaCodNivelRisco_N" )]
      [  XmlElement( ElementName = "SerasaCodNivelRisco_N"   )]
      public short gxTpr_Serasacodnivelrisco_N
      {
         get {
            return gxTv_SdtSerasa_Serasacodnivelrisco_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasacodnivelrisco_N = value;
            SetDirty("Serasacodnivelrisco_N");
         }

      }

      public void gxTv_SdtSerasa_Serasacodnivelrisco_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasacodnivelrisco_N = 0;
         SetDirty("Serasacodnivelrisco_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasacodnivelrisco_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaTipoRecomendacao_N" )]
      [  XmlElement( ElementName = "SerasaTipoRecomendacao_N"   )]
      public short gxTpr_Serasatiporecomendacao_N
      {
         get {
            return gxTv_SdtSerasa_Serasatiporecomendacao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasatiporecomendacao_N = value;
            SetDirty("Serasatiporecomendacao_N");
         }

      }

      public void gxTv_SdtSerasa_Serasatiporecomendacao_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasatiporecomendacao_N = 0;
         SetDirty("Serasatiporecomendacao_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasatiporecomendacao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaRecomendacaoVenda_N" )]
      [  XmlElement( ElementName = "SerasaRecomendacaoVenda_N"   )]
      public short gxTpr_Serasarecomendacaovenda_N
      {
         get {
            return gxTv_SdtSerasa_Serasarecomendacaovenda_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasarecomendacaovenda_N = value;
            SetDirty("Serasarecomendacaovenda_N");
         }

      }

      public void gxTv_SdtSerasa_Serasarecomendacaovenda_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasarecomendacaovenda_N = 0;
         SetDirty("Serasarecomendacaovenda_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasarecomendacaovenda_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaCpfRegular_N" )]
      [  XmlElement( ElementName = "SerasaCpfRegular_N"   )]
      public short gxTpr_Serasacpfregular_N
      {
         get {
            return gxTv_SdtSerasa_Serasacpfregular_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasacpfregular_N = value;
            SetDirty("Serasacpfregular_N");
         }

      }

      public void gxTv_SdtSerasa_Serasacpfregular_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasacpfregular_N = 0;
         SetDirty("Serasacpfregular_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasacpfregular_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaRetricaoAtiva_N" )]
      [  XmlElement( ElementName = "SerasaRetricaoAtiva_N"   )]
      public short gxTpr_Serasaretricaoativa_N
      {
         get {
            return gxTv_SdtSerasa_Serasaretricaoativa_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasaretricaoativa_N = value;
            SetDirty("Serasaretricaoativa_N");
         }

      }

      public void gxTv_SdtSerasa_Serasaretricaoativa_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasaretricaoativa_N = 0;
         SetDirty("Serasaretricaoativa_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasaretricaoativa_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaProtestoAtivo_N" )]
      [  XmlElement( ElementName = "SerasaProtestoAtivo_N"   )]
      public short gxTpr_Serasaprotestoativo_N
      {
         get {
            return gxTv_SdtSerasa_Serasaprotestoativo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasaprotestoativo_N = value;
            SetDirty("Serasaprotestoativo_N");
         }

      }

      public void gxTv_SdtSerasa_Serasaprotestoativo_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasaprotestoativo_N = 0;
         SetDirty("Serasaprotestoativo_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasaprotestoativo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaBaixoComprometimento_N" )]
      [  XmlElement( ElementName = "SerasaBaixoComprometimento_N"   )]
      public short gxTpr_Serasabaixocomprometimento_N
      {
         get {
            return gxTv_SdtSerasa_Serasabaixocomprometimento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasabaixocomprometimento_N = value;
            SetDirty("Serasabaixocomprometimento_N");
         }

      }

      public void gxTv_SdtSerasa_Serasabaixocomprometimento_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasabaixocomprometimento_N = 0;
         SetDirty("Serasabaixocomprometimento_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasabaixocomprometimento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaValorLimiteRecomendado_N" )]
      [  XmlElement( ElementName = "SerasaValorLimiteRecomendado_N"   )]
      public short gxTpr_Serasavalorlimiterecomendado_N
      {
         get {
            return gxTv_SdtSerasa_Serasavalorlimiterecomendado_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasavalorlimiterecomendado_N = value;
            SetDirty("Serasavalorlimiterecomendado_N");
         }

      }

      public void gxTv_SdtSerasa_Serasavalorlimiterecomendado_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasavalorlimiterecomendado_N = 0;
         SetDirty("Serasavalorlimiterecomendado_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasavalorlimiterecomendado_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaFaixaDeRendaEstimada_N" )]
      [  XmlElement( ElementName = "SerasaFaixaDeRendaEstimada_N"   )]
      public short gxTpr_Serasafaixaderendaestimada_N
      {
         get {
            return gxTv_SdtSerasa_Serasafaixaderendaestimada_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasafaixaderendaestimada_N = value;
            SetDirty("Serasafaixaderendaestimada_N");
         }

      }

      public void gxTv_SdtSerasa_Serasafaixaderendaestimada_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasafaixaderendaestimada_N = 0;
         SetDirty("Serasafaixaderendaestimada_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasafaixaderendaestimada_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaMensagemRendaEstimada_N" )]
      [  XmlElement( ElementName = "SerasaMensagemRendaEstimada_N"   )]
      public short gxTpr_Serasamensagemrendaestimada_N
      {
         get {
            return gxTv_SdtSerasa_Serasamensagemrendaestimada_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasamensagemrendaestimada_N = value;
            SetDirty("Serasamensagemrendaestimada_N");
         }

      }

      public void gxTv_SdtSerasa_Serasamensagemrendaestimada_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasamensagemrendaestimada_N = 0;
         SetDirty("Serasamensagemrendaestimada_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasamensagemrendaestimada_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaAnotacoesCompletas_N" )]
      [  XmlElement( ElementName = "SerasaAnotacoesCompletas_N"   )]
      public short gxTpr_Serasaanotacoescompletas_N
      {
         get {
            return gxTv_SdtSerasa_Serasaanotacoescompletas_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasaanotacoescompletas_N = value;
            SetDirty("Serasaanotacoescompletas_N");
         }

      }

      public void gxTv_SdtSerasa_Serasaanotacoescompletas_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasaanotacoescompletas_N = 0;
         SetDirty("Serasaanotacoescompletas_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasaanotacoescompletas_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaConsultasDetalhadas_N" )]
      [  XmlElement( ElementName = "SerasaConsultasDetalhadas_N"   )]
      public short gxTpr_Serasaconsultasdetalhadas_N
      {
         get {
            return gxTv_SdtSerasa_Serasaconsultasdetalhadas_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasaconsultasdetalhadas_N = value;
            SetDirty("Serasaconsultasdetalhadas_N");
         }

      }

      public void gxTv_SdtSerasa_Serasaconsultasdetalhadas_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasaconsultasdetalhadas_N = 0;
         SetDirty("Serasaconsultasdetalhadas_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasaconsultasdetalhadas_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaAnotacoesConsultaSPC_N" )]
      [  XmlElement( ElementName = "SerasaAnotacoesConsultaSPC_N"   )]
      public short gxTpr_Serasaanotacoesconsultaspc_N
      {
         get {
            return gxTv_SdtSerasa_Serasaanotacoesconsultaspc_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasaanotacoesconsultaspc_N = value;
            SetDirty("Serasaanotacoesconsultaspc_N");
         }

      }

      public void gxTv_SdtSerasa_Serasaanotacoesconsultaspc_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasaanotacoesconsultaspc_N = 0;
         SetDirty("Serasaanotacoesconsultaspc_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasaanotacoesconsultaspc_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaParticipacaoSocietaria_N" )]
      [  XmlElement( ElementName = "SerasaParticipacaoSocietaria_N"   )]
      public short gxTpr_Serasaparticipacaosocietaria_N
      {
         get {
            return gxTv_SdtSerasa_Serasaparticipacaosocietaria_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasaparticipacaosocietaria_N = value;
            SetDirty("Serasaparticipacaosocietaria_N");
         }

      }

      public void gxTv_SdtSerasa_Serasaparticipacaosocietaria_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasaparticipacaosocietaria_N = 0;
         SetDirty("Serasaparticipacaosocietaria_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasaparticipacaosocietaria_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaRendaEstimada_N" )]
      [  XmlElement( ElementName = "SerasaRendaEstimada_N"   )]
      public short gxTpr_Serasarendaestimada_N
      {
         get {
            return gxTv_SdtSerasa_Serasarendaestimada_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasarendaestimada_N = value;
            SetDirty("Serasarendaestimada_N");
         }

      }

      public void gxTv_SdtSerasa_Serasarendaestimada_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasarendaestimada_N = 0;
         SetDirty("Serasarendaestimada_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasarendaestimada_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaHistoricoPagamentoPF_N" )]
      [  XmlElement( ElementName = "SerasaHistoricoPagamentoPF_N"   )]
      public short gxTpr_Serasahistoricopagamentopf_N
      {
         get {
            return gxTv_SdtSerasa_Serasahistoricopagamentopf_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasahistoricopagamentopf_N = value;
            SetDirty("Serasahistoricopagamentopf_N");
         }

      }

      public void gxTv_SdtSerasa_Serasahistoricopagamentopf_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasahistoricopagamentopf_N = 0;
         SetDirty("Serasahistoricopagamentopf_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasahistoricopagamentopf_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaRecomendaCompleto_N" )]
      [  XmlElement( ElementName = "SerasaRecomendaCompleto_N"   )]
      public short gxTpr_Serasarecomendacompleto_N
      {
         get {
            return gxTv_SdtSerasa_Serasarecomendacompleto_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasarecomendacompleto_N = value;
            SetDirty("Serasarecomendacompleto_N");
         }

      }

      public void gxTv_SdtSerasa_Serasarecomendacompleto_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasarecomendacompleto_N = 0;
         SetDirty("Serasarecomendacompleto_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasarecomendacompleto_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaScore_N" )]
      [  XmlElement( ElementName = "SerasaScore_N"   )]
      public short gxTpr_Serasascore_N
      {
         get {
            return gxTv_SdtSerasa_Serasascore_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasascore_N = value;
            SetDirty("Serasascore_N");
         }

      }

      public void gxTv_SdtSerasa_Serasascore_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasascore_N = 0;
         SetDirty("Serasascore_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasascore_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaTaxa_N" )]
      [  XmlElement( ElementName = "SerasaTaxa_N"   )]
      public short gxTpr_Serasataxa_N
      {
         get {
            return gxTv_SdtSerasa_Serasataxa_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasataxa_N = value;
            SetDirty("Serasataxa_N");
         }

      }

      public void gxTv_SdtSerasa_Serasataxa_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasataxa_N = 0;
         SetDirty("Serasataxa_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasataxa_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaMensagemScore_N" )]
      [  XmlElement( ElementName = "SerasaMensagemScore_N"   )]
      public short gxTpr_Serasamensagemscore_N
      {
         get {
            return gxTv_SdtSerasa_Serasamensagemscore_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasamensagemscore_N = value;
            SetDirty("Serasamensagemscore_N");
         }

      }

      public void gxTv_SdtSerasa_Serasamensagemscore_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasamensagemscore_N = 0;
         SetDirty("Serasamensagemscore_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasamensagemscore_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaSituacaoCPF_N" )]
      [  XmlElement( ElementName = "SerasaSituacaoCPF_N"   )]
      public short gxTpr_Serasasituacaocpf_N
      {
         get {
            return gxTv_SdtSerasa_Serasasituacaocpf_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasasituacaocpf_N = value;
            SetDirty("Serasasituacaocpf_N");
         }

      }

      public void gxTv_SdtSerasa_Serasasituacaocpf_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasasituacaocpf_N = 0;
         SetDirty("Serasasituacaocpf_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasasituacaocpf_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaDataNascimento_N" )]
      [  XmlElement( ElementName = "SerasaDataNascimento_N"   )]
      public short gxTpr_Serasadatanascimento_N
      {
         get {
            return gxTv_SdtSerasa_Serasadatanascimento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasadatanascimento_N = value;
            SetDirty("Serasadatanascimento_N");
         }

      }

      public void gxTv_SdtSerasa_Serasadatanascimento_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasadatanascimento_N = 0;
         SetDirty("Serasadatanascimento_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasadatanascimento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaGenero_N" )]
      [  XmlElement( ElementName = "SerasaGenero_N"   )]
      public short gxTpr_Serasagenero_N
      {
         get {
            return gxTv_SdtSerasa_Serasagenero_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasagenero_N = value;
            SetDirty("Serasagenero_N");
         }

      }

      public void gxTv_SdtSerasa_Serasagenero_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasagenero_N = 0;
         SetDirty("Serasagenero_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasagenero_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaNomeMae_N" )]
      [  XmlElement( ElementName = "SerasaNomeMae_N"   )]
      public short gxTpr_Serasanomemae_N
      {
         get {
            return gxTv_SdtSerasa_Serasanomemae_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasanomemae_N = value;
            SetDirty("Serasanomemae_N");
         }

      }

      public void gxTv_SdtSerasa_Serasanomemae_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasanomemae_N = 0;
         SetDirty("Serasanomemae_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasanomemae_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaGrafia_N" )]
      [  XmlElement( ElementName = "SerasaGrafia_N"   )]
      public short gxTpr_Serasagrafia_N
      {
         get {
            return gxTv_SdtSerasa_Serasagrafia_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasagrafia_N = value;
            SetDirty("Serasagrafia_N");
         }

      }

      public void gxTv_SdtSerasa_Serasagrafia_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasagrafia_N = 0;
         SetDirty("Serasagrafia_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasagrafia_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaJSON_N" )]
      [  XmlElement( ElementName = "SerasaJSON_N"   )]
      public short gxTpr_Serasajson_N
      {
         get {
            return gxTv_SdtSerasa_Serasajson_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasajson_N = value;
            SetDirty("Serasajson_N");
         }

      }

      public void gxTv_SdtSerasa_Serasajson_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasajson_N = 0;
         SetDirty("Serasajson_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasajson_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaCountAcoes_F_N" )]
      [  XmlElement( ElementName = "SerasaCountAcoes_F_N"   )]
      public short gxTpr_Serasacountacoes_f_N
      {
         get {
            return gxTv_SdtSerasa_Serasacountacoes_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasacountacoes_f_N = value;
            SetDirty("Serasacountacoes_f_N");
         }

      }

      public void gxTv_SdtSerasa_Serasacountacoes_f_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasacountacoes_f_N = 0;
         SetDirty("Serasacountacoes_f_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasacountacoes_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaCountEnderecos_F_N" )]
      [  XmlElement( ElementName = "SerasaCountEnderecos_F_N"   )]
      public short gxTpr_Serasacountenderecos_f_N
      {
         get {
            return gxTv_SdtSerasa_Serasacountenderecos_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasacountenderecos_f_N = value;
            SetDirty("Serasacountenderecos_f_N");
         }

      }

      public void gxTv_SdtSerasa_Serasacountenderecos_f_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasacountenderecos_f_N = 0;
         SetDirty("Serasacountenderecos_f_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasacountenderecos_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaCountProtestos_F_N" )]
      [  XmlElement( ElementName = "SerasaCountProtestos_F_N"   )]
      public short gxTpr_Serasacountprotestos_f_N
      {
         get {
            return gxTv_SdtSerasa_Serasacountprotestos_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasacountprotestos_f_N = value;
            SetDirty("Serasacountprotestos_f_N");
         }

      }

      public void gxTv_SdtSerasa_Serasacountprotestos_f_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasacountprotestos_f_N = 0;
         SetDirty("Serasacountprotestos_f_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasacountprotestos_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaCountOcorrencias_F_N" )]
      [  XmlElement( ElementName = "SerasaCountOcorrencias_F_N"   )]
      public short gxTpr_Serasacountocorrencias_f_N
      {
         get {
            return gxTv_SdtSerasa_Serasacountocorrencias_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasacountocorrencias_f_N = value;
            SetDirty("Serasacountocorrencias_f_N");
         }

      }

      public void gxTv_SdtSerasa_Serasacountocorrencias_f_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasacountocorrencias_f_N = 0;
         SetDirty("Serasacountocorrencias_f_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasacountocorrencias_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaCountCheques_F_N" )]
      [  XmlElement( ElementName = "SerasaCountCheques_F_N"   )]
      public short gxTpr_Serasacountcheques_f_N
      {
         get {
            return gxTv_SdtSerasa_Serasacountcheques_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasa_Serasacountcheques_f_N = value;
            SetDirty("Serasacountcheques_f_N");
         }

      }

      public void gxTv_SdtSerasa_Serasacountcheques_f_N_SetNull( )
      {
         gxTv_SdtSerasa_Serasacountcheques_f_N = 0;
         SetDirty("Serasacountcheques_f_N");
         return  ;
      }

      public bool gxTv_SdtSerasa_Serasacountcheques_f_N_IsNull( )
      {
         return false ;
      }

      [XmlIgnore]
      private static GXTypeInfo _typeProps;
      protected override GXTypeInfo TypeInfo
      {
         get {
            return _typeProps ;
         }

         set {
            _typeProps = value ;
         }

      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_SdtSerasa_Clienterazaosocial = "";
         gxTv_SdtSerasa_Serasanumeroproposta = "";
         gxTv_SdtSerasa_Serasacreatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtSerasa_Serasatipovenda = "";
         gxTv_SdtSerasa_Serasatiporecomendacao = "";
         gxTv_SdtSerasa_Serasarecomendacaovenda = "";
         gxTv_SdtSerasa_Serasamensagemrendaestimada = "";
         gxTv_SdtSerasa_Serasamensagemscore = "";
         gxTv_SdtSerasa_Serasasituacaocpf = "";
         gxTv_SdtSerasa_Serasadatanascimento = DateTime.MinValue;
         gxTv_SdtSerasa_Serasagenero = "";
         gxTv_SdtSerasa_Serasanomemae = "";
         gxTv_SdtSerasa_Serasagrafia = "";
         gxTv_SdtSerasa_Serasajson = "";
         gxTv_SdtSerasa_Mode = "";
         gxTv_SdtSerasa_Clienterazaosocial_Z = "";
         gxTv_SdtSerasa_Serasanumeroproposta_Z = "";
         gxTv_SdtSerasa_Serasacreatedat_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtSerasa_Serasatipovenda_Z = "";
         gxTv_SdtSerasa_Serasatiporecomendacao_Z = "";
         gxTv_SdtSerasa_Serasarecomendacaovenda_Z = "";
         gxTv_SdtSerasa_Serasamensagemrendaestimada_Z = "";
         gxTv_SdtSerasa_Serasamensagemscore_Z = "";
         gxTv_SdtSerasa_Serasasituacaocpf_Z = "";
         gxTv_SdtSerasa_Serasadatanascimento_Z = DateTime.MinValue;
         gxTv_SdtSerasa_Serasagenero_Z = "";
         gxTv_SdtSerasa_Serasanomemae_Z = "";
         gxTv_SdtSerasa_Serasagrafia_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "serasa", "GeneXus.Programs.serasa_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtSerasa_Serasascore ;
      private short gxTv_SdtSerasa_Serasacountacoes_f ;
      private short gxTv_SdtSerasa_Serasacountenderecos_f ;
      private short gxTv_SdtSerasa_Serasacountprotestos_f ;
      private short gxTv_SdtSerasa_Serasacountocorrencias_f ;
      private short gxTv_SdtSerasa_Serasacountcheques_f ;
      private short gxTv_SdtSerasa_Initialized ;
      private short gxTv_SdtSerasa_Serasascore_Z ;
      private short gxTv_SdtSerasa_Serasacountacoes_f_Z ;
      private short gxTv_SdtSerasa_Serasacountenderecos_f_Z ;
      private short gxTv_SdtSerasa_Serasacountprotestos_f_Z ;
      private short gxTv_SdtSerasa_Serasacountocorrencias_f_Z ;
      private short gxTv_SdtSerasa_Serasacountcheques_f_Z ;
      private short gxTv_SdtSerasa_Serasaid_N ;
      private short gxTv_SdtSerasa_Clienteid_N ;
      private short gxTv_SdtSerasa_Clienterazaosocial_N ;
      private short gxTv_SdtSerasa_Serasanumeroproposta_N ;
      private short gxTv_SdtSerasa_Serasapolitica_N ;
      private short gxTv_SdtSerasa_Serasacreatedat_N ;
      private short gxTv_SdtSerasa_Serasatipovenda_N ;
      private short gxTv_SdtSerasa_Serasacodtipovenda_N ;
      private short gxTv_SdtSerasa_Serasacodnivelrisco_N ;
      private short gxTv_SdtSerasa_Serasatiporecomendacao_N ;
      private short gxTv_SdtSerasa_Serasarecomendacaovenda_N ;
      private short gxTv_SdtSerasa_Serasacpfregular_N ;
      private short gxTv_SdtSerasa_Serasaretricaoativa_N ;
      private short gxTv_SdtSerasa_Serasaprotestoativo_N ;
      private short gxTv_SdtSerasa_Serasabaixocomprometimento_N ;
      private short gxTv_SdtSerasa_Serasavalorlimiterecomendado_N ;
      private short gxTv_SdtSerasa_Serasafaixaderendaestimada_N ;
      private short gxTv_SdtSerasa_Serasamensagemrendaestimada_N ;
      private short gxTv_SdtSerasa_Serasaanotacoescompletas_N ;
      private short gxTv_SdtSerasa_Serasaconsultasdetalhadas_N ;
      private short gxTv_SdtSerasa_Serasaanotacoesconsultaspc_N ;
      private short gxTv_SdtSerasa_Serasaparticipacaosocietaria_N ;
      private short gxTv_SdtSerasa_Serasarendaestimada_N ;
      private short gxTv_SdtSerasa_Serasahistoricopagamentopf_N ;
      private short gxTv_SdtSerasa_Serasarecomendacompleto_N ;
      private short gxTv_SdtSerasa_Serasascore_N ;
      private short gxTv_SdtSerasa_Serasataxa_N ;
      private short gxTv_SdtSerasa_Serasamensagemscore_N ;
      private short gxTv_SdtSerasa_Serasasituacaocpf_N ;
      private short gxTv_SdtSerasa_Serasadatanascimento_N ;
      private short gxTv_SdtSerasa_Serasagenero_N ;
      private short gxTv_SdtSerasa_Serasanomemae_N ;
      private short gxTv_SdtSerasa_Serasagrafia_N ;
      private short gxTv_SdtSerasa_Serasajson_N ;
      private short gxTv_SdtSerasa_Serasacountacoes_f_N ;
      private short gxTv_SdtSerasa_Serasacountenderecos_f_N ;
      private short gxTv_SdtSerasa_Serasacountprotestos_f_N ;
      private short gxTv_SdtSerasa_Serasacountocorrencias_f_N ;
      private short gxTv_SdtSerasa_Serasacountcheques_f_N ;
      private int gxTv_SdtSerasa_Serasaid ;
      private int gxTv_SdtSerasa_Clienteid ;
      private int gxTv_SdtSerasa_Serasaid_Z ;
      private int gxTv_SdtSerasa_Clienteid_Z ;
      private decimal gxTv_SdtSerasa_Serasapolitica ;
      private decimal gxTv_SdtSerasa_Serasacodtipovenda ;
      private decimal gxTv_SdtSerasa_Serasacodnivelrisco ;
      private decimal gxTv_SdtSerasa_Serasavalorlimiterecomendado ;
      private decimal gxTv_SdtSerasa_Serasafaixaderendaestimada ;
      private decimal gxTv_SdtSerasa_Serasataxa ;
      private decimal gxTv_SdtSerasa_Serasapolitica_Z ;
      private decimal gxTv_SdtSerasa_Serasacodtipovenda_Z ;
      private decimal gxTv_SdtSerasa_Serasacodnivelrisco_Z ;
      private decimal gxTv_SdtSerasa_Serasavalorlimiterecomendado_Z ;
      private decimal gxTv_SdtSerasa_Serasafaixaderendaestimada_Z ;
      private decimal gxTv_SdtSerasa_Serasataxa_Z ;
      private string gxTv_SdtSerasa_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtSerasa_Serasacreatedat ;
      private DateTime gxTv_SdtSerasa_Serasacreatedat_Z ;
      private DateTime datetime_STZ ;
      private DateTime gxTv_SdtSerasa_Serasadatanascimento ;
      private DateTime gxTv_SdtSerasa_Serasadatanascimento_Z ;
      private bool gxTv_SdtSerasa_Serasacpfregular ;
      private bool gxTv_SdtSerasa_Serasaretricaoativa ;
      private bool gxTv_SdtSerasa_Serasaprotestoativo ;
      private bool gxTv_SdtSerasa_Serasabaixocomprometimento ;
      private bool gxTv_SdtSerasa_Serasaanotacoescompletas ;
      private bool gxTv_SdtSerasa_Serasaconsultasdetalhadas ;
      private bool gxTv_SdtSerasa_Serasaanotacoesconsultaspc ;
      private bool gxTv_SdtSerasa_Serasaparticipacaosocietaria ;
      private bool gxTv_SdtSerasa_Serasarendaestimada ;
      private bool gxTv_SdtSerasa_Serasahistoricopagamentopf ;
      private bool gxTv_SdtSerasa_Serasarecomendacompleto ;
      private bool gxTv_SdtSerasa_Serasacpfregular_Z ;
      private bool gxTv_SdtSerasa_Serasaretricaoativa_Z ;
      private bool gxTv_SdtSerasa_Serasaprotestoativo_Z ;
      private bool gxTv_SdtSerasa_Serasabaixocomprometimento_Z ;
      private bool gxTv_SdtSerasa_Serasaanotacoescompletas_Z ;
      private bool gxTv_SdtSerasa_Serasaconsultasdetalhadas_Z ;
      private bool gxTv_SdtSerasa_Serasaanotacoesconsultaspc_Z ;
      private bool gxTv_SdtSerasa_Serasaparticipacaosocietaria_Z ;
      private bool gxTv_SdtSerasa_Serasarendaestimada_Z ;
      private bool gxTv_SdtSerasa_Serasahistoricopagamentopf_Z ;
      private bool gxTv_SdtSerasa_Serasarecomendacompleto_Z ;
      private string gxTv_SdtSerasa_Serasajson ;
      private string gxTv_SdtSerasa_Clienterazaosocial ;
      private string gxTv_SdtSerasa_Serasanumeroproposta ;
      private string gxTv_SdtSerasa_Serasatipovenda ;
      private string gxTv_SdtSerasa_Serasatiporecomendacao ;
      private string gxTv_SdtSerasa_Serasarecomendacaovenda ;
      private string gxTv_SdtSerasa_Serasamensagemrendaestimada ;
      private string gxTv_SdtSerasa_Serasamensagemscore ;
      private string gxTv_SdtSerasa_Serasasituacaocpf ;
      private string gxTv_SdtSerasa_Serasagenero ;
      private string gxTv_SdtSerasa_Serasanomemae ;
      private string gxTv_SdtSerasa_Serasagrafia ;
      private string gxTv_SdtSerasa_Clienterazaosocial_Z ;
      private string gxTv_SdtSerasa_Serasanumeroproposta_Z ;
      private string gxTv_SdtSerasa_Serasatipovenda_Z ;
      private string gxTv_SdtSerasa_Serasatiporecomendacao_Z ;
      private string gxTv_SdtSerasa_Serasarecomendacaovenda_Z ;
      private string gxTv_SdtSerasa_Serasamensagemrendaestimada_Z ;
      private string gxTv_SdtSerasa_Serasamensagemscore_Z ;
      private string gxTv_SdtSerasa_Serasasituacaocpf_Z ;
      private string gxTv_SdtSerasa_Serasagenero_Z ;
      private string gxTv_SdtSerasa_Serasanomemae_Z ;
      private string gxTv_SdtSerasa_Serasagrafia_Z ;
   }

   [DataContract(Name = @"Serasa", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtSerasa_RESTInterface : GxGenericCollectionItem<SdtSerasa>
   {
      public SdtSerasa_RESTInterface( ) : base()
      {
      }

      public SdtSerasa_RESTInterface( SdtSerasa psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SerasaId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Serasaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Serasaid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Serasaid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ClienteId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Clienteid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Clienteid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Clienteid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ClienteRazaoSocial" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Clienterazaosocial
      {
         get {
            return sdt.gxTpr_Clienterazaosocial ;
         }

         set {
            sdt.gxTpr_Clienterazaosocial = value;
         }

      }

      [DataMember( Name = "SerasaNumeroProposta" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Serasanumeroproposta
      {
         get {
            return sdt.gxTpr_Serasanumeroproposta ;
         }

         set {
            sdt.gxTpr_Serasanumeroproposta = value;
         }

      }

      [DataMember( Name = "SerasaPolitica" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Serasapolitica
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Serasapolitica, 15, 2)) ;
         }

         set {
            sdt.gxTpr_Serasapolitica = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "SerasaCreatedAt" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Serasacreatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Serasacreatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Serasacreatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "SerasaTipoVenda" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Serasatipovenda
      {
         get {
            return sdt.gxTpr_Serasatipovenda ;
         }

         set {
            sdt.gxTpr_Serasatipovenda = value;
         }

      }

      [DataMember( Name = "SerasaCodTipoVenda" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Serasacodtipovenda
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Serasacodtipovenda, 15, 2)) ;
         }

         set {
            sdt.gxTpr_Serasacodtipovenda = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "SerasaCodNivelRisco" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Serasacodnivelrisco
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Serasacodnivelrisco, 15, 2)) ;
         }

         set {
            sdt.gxTpr_Serasacodnivelrisco = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "SerasaTipoRecomendacao" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Serasatiporecomendacao
      {
         get {
            return sdt.gxTpr_Serasatiporecomendacao ;
         }

         set {
            sdt.gxTpr_Serasatiporecomendacao = value;
         }

      }

      [DataMember( Name = "SerasaRecomendacaoVenda" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Serasarecomendacaovenda
      {
         get {
            return sdt.gxTpr_Serasarecomendacaovenda ;
         }

         set {
            sdt.gxTpr_Serasarecomendacaovenda = value;
         }

      }

      [DataMember( Name = "SerasaCpfRegular" , Order = 11 )]
      [GxSeudo()]
      public bool gxTpr_Serasacpfregular
      {
         get {
            return sdt.gxTpr_Serasacpfregular ;
         }

         set {
            sdt.gxTpr_Serasacpfregular = value;
         }

      }

      [DataMember( Name = "SerasaRetricaoAtiva" , Order = 12 )]
      [GxSeudo()]
      public bool gxTpr_Serasaretricaoativa
      {
         get {
            return sdt.gxTpr_Serasaretricaoativa ;
         }

         set {
            sdt.gxTpr_Serasaretricaoativa = value;
         }

      }

      [DataMember( Name = "SerasaProtestoAtivo" , Order = 13 )]
      [GxSeudo()]
      public bool gxTpr_Serasaprotestoativo
      {
         get {
            return sdt.gxTpr_Serasaprotestoativo ;
         }

         set {
            sdt.gxTpr_Serasaprotestoativo = value;
         }

      }

      [DataMember( Name = "SerasaBaixoComprometimento" , Order = 14 )]
      [GxSeudo()]
      public bool gxTpr_Serasabaixocomprometimento
      {
         get {
            return sdt.gxTpr_Serasabaixocomprometimento ;
         }

         set {
            sdt.gxTpr_Serasabaixocomprometimento = value;
         }

      }

      [DataMember( Name = "SerasaValorLimiteRecomendado" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Serasavalorlimiterecomendado
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Serasavalorlimiterecomendado, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Serasavalorlimiterecomendado = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "SerasaFaixaDeRendaEstimada" , Order = 16 )]
      [GxSeudo()]
      public string gxTpr_Serasafaixaderendaestimada
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Serasafaixaderendaestimada, 15, 2)) ;
         }

         set {
            sdt.gxTpr_Serasafaixaderendaestimada = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "SerasaMensagemRendaEstimada" , Order = 17 )]
      [GxSeudo()]
      public string gxTpr_Serasamensagemrendaestimada
      {
         get {
            return sdt.gxTpr_Serasamensagemrendaestimada ;
         }

         set {
            sdt.gxTpr_Serasamensagemrendaestimada = value;
         }

      }

      [DataMember( Name = "SerasaAnotacoesCompletas" , Order = 18 )]
      [GxSeudo()]
      public bool gxTpr_Serasaanotacoescompletas
      {
         get {
            return sdt.gxTpr_Serasaanotacoescompletas ;
         }

         set {
            sdt.gxTpr_Serasaanotacoescompletas = value;
         }

      }

      [DataMember( Name = "SerasaConsultasDetalhadas" , Order = 19 )]
      [GxSeudo()]
      public bool gxTpr_Serasaconsultasdetalhadas
      {
         get {
            return sdt.gxTpr_Serasaconsultasdetalhadas ;
         }

         set {
            sdt.gxTpr_Serasaconsultasdetalhadas = value;
         }

      }

      [DataMember( Name = "SerasaAnotacoesConsultaSPC" , Order = 20 )]
      [GxSeudo()]
      public bool gxTpr_Serasaanotacoesconsultaspc
      {
         get {
            return sdt.gxTpr_Serasaanotacoesconsultaspc ;
         }

         set {
            sdt.gxTpr_Serasaanotacoesconsultaspc = value;
         }

      }

      [DataMember( Name = "SerasaParticipacaoSocietaria" , Order = 21 )]
      [GxSeudo()]
      public bool gxTpr_Serasaparticipacaosocietaria
      {
         get {
            return sdt.gxTpr_Serasaparticipacaosocietaria ;
         }

         set {
            sdt.gxTpr_Serasaparticipacaosocietaria = value;
         }

      }

      [DataMember( Name = "SerasaRendaEstimada" , Order = 22 )]
      [GxSeudo()]
      public bool gxTpr_Serasarendaestimada
      {
         get {
            return sdt.gxTpr_Serasarendaestimada ;
         }

         set {
            sdt.gxTpr_Serasarendaestimada = value;
         }

      }

      [DataMember( Name = "SerasaHistoricoPagamentoPF" , Order = 23 )]
      [GxSeudo()]
      public bool gxTpr_Serasahistoricopagamentopf
      {
         get {
            return sdt.gxTpr_Serasahistoricopagamentopf ;
         }

         set {
            sdt.gxTpr_Serasahistoricopagamentopf = value;
         }

      }

      [DataMember( Name = "SerasaRecomendaCompleto" , Order = 24 )]
      [GxSeudo()]
      public bool gxTpr_Serasarecomendacompleto
      {
         get {
            return sdt.gxTpr_Serasarecomendacompleto ;
         }

         set {
            sdt.gxTpr_Serasarecomendacompleto = value;
         }

      }

      [DataMember( Name = "SerasaScore" , Order = 25 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Serasascore
      {
         get {
            return sdt.gxTpr_Serasascore ;
         }

         set {
            sdt.gxTpr_Serasascore = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "SerasaTaxa" , Order = 26 )]
      [GxSeudo()]
      public string gxTpr_Serasataxa
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Serasataxa, 15, 2)) ;
         }

         set {
            sdt.gxTpr_Serasataxa = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "SerasaMensagemScore" , Order = 27 )]
      [GxSeudo()]
      public string gxTpr_Serasamensagemscore
      {
         get {
            return sdt.gxTpr_Serasamensagemscore ;
         }

         set {
            sdt.gxTpr_Serasamensagemscore = value;
         }

      }

      [DataMember( Name = "SerasaSituacaoCPF" , Order = 28 )]
      [GxSeudo()]
      public string gxTpr_Serasasituacaocpf
      {
         get {
            return sdt.gxTpr_Serasasituacaocpf ;
         }

         set {
            sdt.gxTpr_Serasasituacaocpf = value;
         }

      }

      [DataMember( Name = "SerasaDataNascimento" , Order = 29 )]
      [GxSeudo()]
      public string gxTpr_Serasadatanascimento
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Serasadatanascimento) ;
         }

         set {
            sdt.gxTpr_Serasadatanascimento = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "SerasaGenero" , Order = 30 )]
      [GxSeudo()]
      public string gxTpr_Serasagenero
      {
         get {
            return sdt.gxTpr_Serasagenero ;
         }

         set {
            sdt.gxTpr_Serasagenero = value;
         }

      }

      [DataMember( Name = "SerasaNomeMae" , Order = 31 )]
      [GxSeudo()]
      public string gxTpr_Serasanomemae
      {
         get {
            return sdt.gxTpr_Serasanomemae ;
         }

         set {
            sdt.gxTpr_Serasanomemae = value;
         }

      }

      [DataMember( Name = "SerasaGrafia" , Order = 32 )]
      [GxSeudo()]
      public string gxTpr_Serasagrafia
      {
         get {
            return sdt.gxTpr_Serasagrafia ;
         }

         set {
            sdt.gxTpr_Serasagrafia = value;
         }

      }

      [DataMember( Name = "SerasaJSON" , Order = 33 )]
      public string gxTpr_Serasajson
      {
         get {
            return sdt.gxTpr_Serasajson ;
         }

         set {
            sdt.gxTpr_Serasajson = value;
         }

      }

      [DataMember( Name = "SerasaCountAcoes_F" , Order = 34 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Serasacountacoes_f
      {
         get {
            return sdt.gxTpr_Serasacountacoes_f ;
         }

         set {
            sdt.gxTpr_Serasacountacoes_f = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "SerasaCountEnderecos_F" , Order = 35 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Serasacountenderecos_f
      {
         get {
            return sdt.gxTpr_Serasacountenderecos_f ;
         }

         set {
            sdt.gxTpr_Serasacountenderecos_f = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "SerasaCountProtestos_F" , Order = 36 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Serasacountprotestos_f
      {
         get {
            return sdt.gxTpr_Serasacountprotestos_f ;
         }

         set {
            sdt.gxTpr_Serasacountprotestos_f = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "SerasaCountOcorrencias_F" , Order = 37 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Serasacountocorrencias_f
      {
         get {
            return sdt.gxTpr_Serasacountocorrencias_f ;
         }

         set {
            sdt.gxTpr_Serasacountocorrencias_f = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "SerasaCountCheques_F" , Order = 38 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Serasacountcheques_f
      {
         get {
            return sdt.gxTpr_Serasacountcheques_f ;
         }

         set {
            sdt.gxTpr_Serasacountcheques_f = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtSerasa sdt
      {
         get {
            return (SdtSerasa)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtSerasa() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 39 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"Serasa", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtSerasa_RESTLInterface : GxGenericCollectionItem<SdtSerasa>
   {
      public SdtSerasa_RESTLInterface( ) : base()
      {
      }

      public SdtSerasa_RESTLInterface( SdtSerasa psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SerasaNumeroProposta" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Serasanumeroproposta
      {
         get {
            return sdt.gxTpr_Serasanumeroproposta ;
         }

         set {
            sdt.gxTpr_Serasanumeroproposta = value;
         }

      }

      [DataMember( Name = "uri" , Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtSerasa sdt
      {
         get {
            return (SdtSerasa)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtSerasa() ;
         }
      }

   }

}
