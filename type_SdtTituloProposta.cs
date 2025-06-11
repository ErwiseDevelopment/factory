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
   [XmlRoot(ElementName = "TituloProposta" )]
   [XmlType(TypeName =  "TituloProposta" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtTituloProposta : GxSilentTrnSdt
   {
      public SdtTituloProposta( )
      {
      }

      public SdtTituloProposta( IGxContext context )
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

      public void Load( int AV261TituloId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV261TituloId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"TituloId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "TituloProposta");
         metadata.Set("BT", "Titulo");
         metadata.Set("PK", "[ \"TituloId\" ]");
         metadata.Set("PKAssigned", "[ \"TituloId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"CategoriaTituloId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ContaId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"NotaFiscalParcelamentoID\" ],\"FKMap\":[  ] },{ \"FK\":[ \"PropostaId\" ],\"FKMap\":[ \"TituloPropostaId-PropostaId\" ] } ]");
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
         state.Add("gxTpr_Tituloid_Z");
         state.Add("gxTpr_Clienteid_Z");
         state.Add("gxTpr_Clienterazaosocial_Z");
         state.Add("gxTpr_Titulovalor_Z");
         state.Add("gxTpr_Titulodesconto_Z");
         state.Add("gxTpr_Titulodeleted_Z");
         state.Add("gxTpr_Tituloarchived_Z");
         state.Add("gxTpr_Titulovencimento_Z_Nullable");
         state.Add("gxTpr_Titulocompetenciaano_Z");
         state.Add("gxTpr_Titulocompetenciames_Z");
         state.Add("gxTpr_Titulocompetencia_f_Z");
         state.Add("gxTpr_Tituloprorrogacao_Z_Nullable");
         state.Add("gxTpr_Titulocep_Z");
         state.Add("gxTpr_Titulologradouro_Z");
         state.Add("gxTpr_Titulonumeroendereco_Z");
         state.Add("gxTpr_Titulocomplemento_Z");
         state.Add("gxTpr_Titulobairro_Z");
         state.Add("gxTpr_Titulomunicipio_Z");
         state.Add("gxTpr_Titulojurosmora_Z");
         state.Add("gxTpr_Titulotipo_Z");
         state.Add("gxTpr_Titulopropostaid_Z");
         state.Add("gxTpr_Propostataxaadministrativa_Z");
         state.Add("gxTpr_Contaid_Z");
         state.Add("gxTpr_Titulocriacao_Z_Nullable");
         state.Add("gxTpr_Categoriatituloid_Z");
         state.Add("gxTpr_Titulototalmovimento_f_Z");
         state.Add("gxTpr_Titulototalmultajuros_f_Z");
         state.Add("gxTpr_Titulosaldo_f_Z");
         state.Add("gxTpr_Titulostatus_f_Z");
         state.Add("gxTpr_Titulosaldodebito_f_Z");
         state.Add("gxTpr_Titulosaldocredito_f_Z");
         state.Add("gxTpr_Titulototalmovimentodebito_f_Z");
         state.Add("gxTpr_Titulototalmovimentocredito_f_Z");
         state.Add("gxTpr_Titulototalmultajurosdebito_f_Z");
         state.Add("gxTpr_Titulototalmultajuroscredito_f_Z");
         state.Add("gxTpr_Tituloid_N");
         state.Add("gxTpr_Clienteid_N");
         state.Add("gxTpr_Clienterazaosocial_N");
         state.Add("gxTpr_Titulovalor_N");
         state.Add("gxTpr_Titulodesconto_N");
         state.Add("gxTpr_Titulodeleted_N");
         state.Add("gxTpr_Tituloarchived_N");
         state.Add("gxTpr_Titulovencimento_N");
         state.Add("gxTpr_Titulocompetenciaano_N");
         state.Add("gxTpr_Titulocompetenciames_N");
         state.Add("gxTpr_Tituloprorrogacao_N");
         state.Add("gxTpr_Titulocep_N");
         state.Add("gxTpr_Titulologradouro_N");
         state.Add("gxTpr_Titulonumeroendereco_N");
         state.Add("gxTpr_Titulocomplemento_N");
         state.Add("gxTpr_Titulobairro_N");
         state.Add("gxTpr_Titulomunicipio_N");
         state.Add("gxTpr_Titulojurosmora_N");
         state.Add("gxTpr_Titulotipo_N");
         state.Add("gxTpr_Titulopropostaid_N");
         state.Add("gxTpr_Propostataxaadministrativa_N");
         state.Add("gxTpr_Contaid_N");
         state.Add("gxTpr_Titulocriacao_N");
         state.Add("gxTpr_Categoriatituloid_N");
         state.Add("gxTpr_Titulototalmovimento_f_N");
         state.Add("gxTpr_Titulototalmultajuros_f_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTituloProposta sdt;
         sdt = (SdtTituloProposta)(source);
         gxTv_SdtTituloProposta_Tituloid = sdt.gxTv_SdtTituloProposta_Tituloid ;
         gxTv_SdtTituloProposta_Clienteid = sdt.gxTv_SdtTituloProposta_Clienteid ;
         gxTv_SdtTituloProposta_Clienterazaosocial = sdt.gxTv_SdtTituloProposta_Clienterazaosocial ;
         gxTv_SdtTituloProposta_Titulovalor = sdt.gxTv_SdtTituloProposta_Titulovalor ;
         gxTv_SdtTituloProposta_Titulodesconto = sdt.gxTv_SdtTituloProposta_Titulodesconto ;
         gxTv_SdtTituloProposta_Titulodeleted = sdt.gxTv_SdtTituloProposta_Titulodeleted ;
         gxTv_SdtTituloProposta_Tituloarchived = sdt.gxTv_SdtTituloProposta_Tituloarchived ;
         gxTv_SdtTituloProposta_Titulovencimento = sdt.gxTv_SdtTituloProposta_Titulovencimento ;
         gxTv_SdtTituloProposta_Titulocompetenciaano = sdt.gxTv_SdtTituloProposta_Titulocompetenciaano ;
         gxTv_SdtTituloProposta_Titulocompetenciames = sdt.gxTv_SdtTituloProposta_Titulocompetenciames ;
         gxTv_SdtTituloProposta_Titulocompetencia_f = sdt.gxTv_SdtTituloProposta_Titulocompetencia_f ;
         gxTv_SdtTituloProposta_Tituloprorrogacao = sdt.gxTv_SdtTituloProposta_Tituloprorrogacao ;
         gxTv_SdtTituloProposta_Titulocep = sdt.gxTv_SdtTituloProposta_Titulocep ;
         gxTv_SdtTituloProposta_Titulologradouro = sdt.gxTv_SdtTituloProposta_Titulologradouro ;
         gxTv_SdtTituloProposta_Titulonumeroendereco = sdt.gxTv_SdtTituloProposta_Titulonumeroendereco ;
         gxTv_SdtTituloProposta_Titulocomplemento = sdt.gxTv_SdtTituloProposta_Titulocomplemento ;
         gxTv_SdtTituloProposta_Titulobairro = sdt.gxTv_SdtTituloProposta_Titulobairro ;
         gxTv_SdtTituloProposta_Titulomunicipio = sdt.gxTv_SdtTituloProposta_Titulomunicipio ;
         gxTv_SdtTituloProposta_Titulojurosmora = sdt.gxTv_SdtTituloProposta_Titulojurosmora ;
         gxTv_SdtTituloProposta_Titulotipo = sdt.gxTv_SdtTituloProposta_Titulotipo ;
         gxTv_SdtTituloProposta_Titulopropostaid = sdt.gxTv_SdtTituloProposta_Titulopropostaid ;
         gxTv_SdtTituloProposta_Propostataxaadministrativa = sdt.gxTv_SdtTituloProposta_Propostataxaadministrativa ;
         gxTv_SdtTituloProposta_Contaid = sdt.gxTv_SdtTituloProposta_Contaid ;
         gxTv_SdtTituloProposta_Titulocriacao = sdt.gxTv_SdtTituloProposta_Titulocriacao ;
         gxTv_SdtTituloProposta_Categoriatituloid = sdt.gxTv_SdtTituloProposta_Categoriatituloid ;
         gxTv_SdtTituloProposta_Titulototalmovimento_f = sdt.gxTv_SdtTituloProposta_Titulototalmovimento_f ;
         gxTv_SdtTituloProposta_Titulototalmultajuros_f = sdt.gxTv_SdtTituloProposta_Titulototalmultajuros_f ;
         gxTv_SdtTituloProposta_Titulosaldo_f = sdt.gxTv_SdtTituloProposta_Titulosaldo_f ;
         gxTv_SdtTituloProposta_Titulostatus_f = sdt.gxTv_SdtTituloProposta_Titulostatus_f ;
         gxTv_SdtTituloProposta_Titulosaldodebito_f = sdt.gxTv_SdtTituloProposta_Titulosaldodebito_f ;
         gxTv_SdtTituloProposta_Titulosaldocredito_f = sdt.gxTv_SdtTituloProposta_Titulosaldocredito_f ;
         gxTv_SdtTituloProposta_Titulototalmovimentodebito_f = sdt.gxTv_SdtTituloProposta_Titulototalmovimentodebito_f ;
         gxTv_SdtTituloProposta_Titulototalmovimentocredito_f = sdt.gxTv_SdtTituloProposta_Titulototalmovimentocredito_f ;
         gxTv_SdtTituloProposta_Titulototalmultajurosdebito_f = sdt.gxTv_SdtTituloProposta_Titulototalmultajurosdebito_f ;
         gxTv_SdtTituloProposta_Titulototalmultajuroscredito_f = sdt.gxTv_SdtTituloProposta_Titulototalmultajuroscredito_f ;
         gxTv_SdtTituloProposta_Mode = sdt.gxTv_SdtTituloProposta_Mode ;
         gxTv_SdtTituloProposta_Initialized = sdt.gxTv_SdtTituloProposta_Initialized ;
         gxTv_SdtTituloProposta_Tituloid_Z = sdt.gxTv_SdtTituloProposta_Tituloid_Z ;
         gxTv_SdtTituloProposta_Clienteid_Z = sdt.gxTv_SdtTituloProposta_Clienteid_Z ;
         gxTv_SdtTituloProposta_Clienterazaosocial_Z = sdt.gxTv_SdtTituloProposta_Clienterazaosocial_Z ;
         gxTv_SdtTituloProposta_Titulovalor_Z = sdt.gxTv_SdtTituloProposta_Titulovalor_Z ;
         gxTv_SdtTituloProposta_Titulodesconto_Z = sdt.gxTv_SdtTituloProposta_Titulodesconto_Z ;
         gxTv_SdtTituloProposta_Titulodeleted_Z = sdt.gxTv_SdtTituloProposta_Titulodeleted_Z ;
         gxTv_SdtTituloProposta_Tituloarchived_Z = sdt.gxTv_SdtTituloProposta_Tituloarchived_Z ;
         gxTv_SdtTituloProposta_Titulovencimento_Z = sdt.gxTv_SdtTituloProposta_Titulovencimento_Z ;
         gxTv_SdtTituloProposta_Titulocompetenciaano_Z = sdt.gxTv_SdtTituloProposta_Titulocompetenciaano_Z ;
         gxTv_SdtTituloProposta_Titulocompetenciames_Z = sdt.gxTv_SdtTituloProposta_Titulocompetenciames_Z ;
         gxTv_SdtTituloProposta_Titulocompetencia_f_Z = sdt.gxTv_SdtTituloProposta_Titulocompetencia_f_Z ;
         gxTv_SdtTituloProposta_Tituloprorrogacao_Z = sdt.gxTv_SdtTituloProposta_Tituloprorrogacao_Z ;
         gxTv_SdtTituloProposta_Titulocep_Z = sdt.gxTv_SdtTituloProposta_Titulocep_Z ;
         gxTv_SdtTituloProposta_Titulologradouro_Z = sdt.gxTv_SdtTituloProposta_Titulologradouro_Z ;
         gxTv_SdtTituloProposta_Titulonumeroendereco_Z = sdt.gxTv_SdtTituloProposta_Titulonumeroendereco_Z ;
         gxTv_SdtTituloProposta_Titulocomplemento_Z = sdt.gxTv_SdtTituloProposta_Titulocomplemento_Z ;
         gxTv_SdtTituloProposta_Titulobairro_Z = sdt.gxTv_SdtTituloProposta_Titulobairro_Z ;
         gxTv_SdtTituloProposta_Titulomunicipio_Z = sdt.gxTv_SdtTituloProposta_Titulomunicipio_Z ;
         gxTv_SdtTituloProposta_Titulojurosmora_Z = sdt.gxTv_SdtTituloProposta_Titulojurosmora_Z ;
         gxTv_SdtTituloProposta_Titulotipo_Z = sdt.gxTv_SdtTituloProposta_Titulotipo_Z ;
         gxTv_SdtTituloProposta_Titulopropostaid_Z = sdt.gxTv_SdtTituloProposta_Titulopropostaid_Z ;
         gxTv_SdtTituloProposta_Propostataxaadministrativa_Z = sdt.gxTv_SdtTituloProposta_Propostataxaadministrativa_Z ;
         gxTv_SdtTituloProposta_Contaid_Z = sdt.gxTv_SdtTituloProposta_Contaid_Z ;
         gxTv_SdtTituloProposta_Titulocriacao_Z = sdt.gxTv_SdtTituloProposta_Titulocriacao_Z ;
         gxTv_SdtTituloProposta_Categoriatituloid_Z = sdt.gxTv_SdtTituloProposta_Categoriatituloid_Z ;
         gxTv_SdtTituloProposta_Titulototalmovimento_f_Z = sdt.gxTv_SdtTituloProposta_Titulototalmovimento_f_Z ;
         gxTv_SdtTituloProposta_Titulototalmultajuros_f_Z = sdt.gxTv_SdtTituloProposta_Titulototalmultajuros_f_Z ;
         gxTv_SdtTituloProposta_Titulosaldo_f_Z = sdt.gxTv_SdtTituloProposta_Titulosaldo_f_Z ;
         gxTv_SdtTituloProposta_Titulostatus_f_Z = sdt.gxTv_SdtTituloProposta_Titulostatus_f_Z ;
         gxTv_SdtTituloProposta_Titulosaldodebito_f_Z = sdt.gxTv_SdtTituloProposta_Titulosaldodebito_f_Z ;
         gxTv_SdtTituloProposta_Titulosaldocredito_f_Z = sdt.gxTv_SdtTituloProposta_Titulosaldocredito_f_Z ;
         gxTv_SdtTituloProposta_Titulototalmovimentodebito_f_Z = sdt.gxTv_SdtTituloProposta_Titulototalmovimentodebito_f_Z ;
         gxTv_SdtTituloProposta_Titulototalmovimentocredito_f_Z = sdt.gxTv_SdtTituloProposta_Titulototalmovimentocredito_f_Z ;
         gxTv_SdtTituloProposta_Titulototalmultajurosdebito_f_Z = sdt.gxTv_SdtTituloProposta_Titulototalmultajurosdebito_f_Z ;
         gxTv_SdtTituloProposta_Titulototalmultajuroscredito_f_Z = sdt.gxTv_SdtTituloProposta_Titulototalmultajuroscredito_f_Z ;
         gxTv_SdtTituloProposta_Tituloid_N = sdt.gxTv_SdtTituloProposta_Tituloid_N ;
         gxTv_SdtTituloProposta_Clienteid_N = sdt.gxTv_SdtTituloProposta_Clienteid_N ;
         gxTv_SdtTituloProposta_Clienterazaosocial_N = sdt.gxTv_SdtTituloProposta_Clienterazaosocial_N ;
         gxTv_SdtTituloProposta_Titulovalor_N = sdt.gxTv_SdtTituloProposta_Titulovalor_N ;
         gxTv_SdtTituloProposta_Titulodesconto_N = sdt.gxTv_SdtTituloProposta_Titulodesconto_N ;
         gxTv_SdtTituloProposta_Titulodeleted_N = sdt.gxTv_SdtTituloProposta_Titulodeleted_N ;
         gxTv_SdtTituloProposta_Tituloarchived_N = sdt.gxTv_SdtTituloProposta_Tituloarchived_N ;
         gxTv_SdtTituloProposta_Titulovencimento_N = sdt.gxTv_SdtTituloProposta_Titulovencimento_N ;
         gxTv_SdtTituloProposta_Titulocompetenciaano_N = sdt.gxTv_SdtTituloProposta_Titulocompetenciaano_N ;
         gxTv_SdtTituloProposta_Titulocompetenciames_N = sdt.gxTv_SdtTituloProposta_Titulocompetenciames_N ;
         gxTv_SdtTituloProposta_Tituloprorrogacao_N = sdt.gxTv_SdtTituloProposta_Tituloprorrogacao_N ;
         gxTv_SdtTituloProposta_Titulocep_N = sdt.gxTv_SdtTituloProposta_Titulocep_N ;
         gxTv_SdtTituloProposta_Titulologradouro_N = sdt.gxTv_SdtTituloProposta_Titulologradouro_N ;
         gxTv_SdtTituloProposta_Titulonumeroendereco_N = sdt.gxTv_SdtTituloProposta_Titulonumeroendereco_N ;
         gxTv_SdtTituloProposta_Titulocomplemento_N = sdt.gxTv_SdtTituloProposta_Titulocomplemento_N ;
         gxTv_SdtTituloProposta_Titulobairro_N = sdt.gxTv_SdtTituloProposta_Titulobairro_N ;
         gxTv_SdtTituloProposta_Titulomunicipio_N = sdt.gxTv_SdtTituloProposta_Titulomunicipio_N ;
         gxTv_SdtTituloProposta_Titulojurosmora_N = sdt.gxTv_SdtTituloProposta_Titulojurosmora_N ;
         gxTv_SdtTituloProposta_Titulotipo_N = sdt.gxTv_SdtTituloProposta_Titulotipo_N ;
         gxTv_SdtTituloProposta_Titulopropostaid_N = sdt.gxTv_SdtTituloProposta_Titulopropostaid_N ;
         gxTv_SdtTituloProposta_Propostataxaadministrativa_N = sdt.gxTv_SdtTituloProposta_Propostataxaadministrativa_N ;
         gxTv_SdtTituloProposta_Contaid_N = sdt.gxTv_SdtTituloProposta_Contaid_N ;
         gxTv_SdtTituloProposta_Titulocriacao_N = sdt.gxTv_SdtTituloProposta_Titulocriacao_N ;
         gxTv_SdtTituloProposta_Categoriatituloid_N = sdt.gxTv_SdtTituloProposta_Categoriatituloid_N ;
         gxTv_SdtTituloProposta_Titulototalmovimento_f_N = sdt.gxTv_SdtTituloProposta_Titulototalmovimento_f_N ;
         gxTv_SdtTituloProposta_Titulototalmultajuros_f_N = sdt.gxTv_SdtTituloProposta_Titulototalmultajuros_f_N ;
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
         AddObjectProperty("TituloId", gxTv_SdtTituloProposta_Tituloid, false, includeNonInitialized);
         AddObjectProperty("TituloId_N", gxTv_SdtTituloProposta_Tituloid_N, false, includeNonInitialized);
         AddObjectProperty("ClienteId", gxTv_SdtTituloProposta_Clienteid, false, includeNonInitialized);
         AddObjectProperty("ClienteId_N", gxTv_SdtTituloProposta_Clienteid_N, false, includeNonInitialized);
         AddObjectProperty("ClienteRazaoSocial", gxTv_SdtTituloProposta_Clienterazaosocial, false, includeNonInitialized);
         AddObjectProperty("ClienteRazaoSocial_N", gxTv_SdtTituloProposta_Clienterazaosocial_N, false, includeNonInitialized);
         AddObjectProperty("TituloValor", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTituloProposta_Titulovalor, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("TituloValor_N", gxTv_SdtTituloProposta_Titulovalor_N, false, includeNonInitialized);
         AddObjectProperty("TituloDesconto", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTituloProposta_Titulodesconto, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("TituloDesconto_N", gxTv_SdtTituloProposta_Titulodesconto_N, false, includeNonInitialized);
         AddObjectProperty("TituloDeleted", gxTv_SdtTituloProposta_Titulodeleted, false, includeNonInitialized);
         AddObjectProperty("TituloDeleted_N", gxTv_SdtTituloProposta_Titulodeleted_N, false, includeNonInitialized);
         AddObjectProperty("TituloArchived", gxTv_SdtTituloProposta_Tituloarchived, false, includeNonInitialized);
         AddObjectProperty("TituloArchived_N", gxTv_SdtTituloProposta_Tituloarchived_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtTituloProposta_Titulovencimento)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtTituloProposta_Titulovencimento)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtTituloProposta_Titulovencimento)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("TituloVencimento", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("TituloVencimento_N", gxTv_SdtTituloProposta_Titulovencimento_N, false, includeNonInitialized);
         AddObjectProperty("TituloCompetenciaAno", gxTv_SdtTituloProposta_Titulocompetenciaano, false, includeNonInitialized);
         AddObjectProperty("TituloCompetenciaAno_N", gxTv_SdtTituloProposta_Titulocompetenciaano_N, false, includeNonInitialized);
         AddObjectProperty("TituloCompetenciaMes", gxTv_SdtTituloProposta_Titulocompetenciames, false, includeNonInitialized);
         AddObjectProperty("TituloCompetenciaMes_N", gxTv_SdtTituloProposta_Titulocompetenciames_N, false, includeNonInitialized);
         AddObjectProperty("TituloCompetencia_F", gxTv_SdtTituloProposta_Titulocompetencia_f, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtTituloProposta_Tituloprorrogacao)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtTituloProposta_Tituloprorrogacao)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtTituloProposta_Tituloprorrogacao)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("TituloProrrogacao", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("TituloProrrogacao_N", gxTv_SdtTituloProposta_Tituloprorrogacao_N, false, includeNonInitialized);
         AddObjectProperty("TituloCEP", gxTv_SdtTituloProposta_Titulocep, false, includeNonInitialized);
         AddObjectProperty("TituloCEP_N", gxTv_SdtTituloProposta_Titulocep_N, false, includeNonInitialized);
         AddObjectProperty("TituloLogradouro", gxTv_SdtTituloProposta_Titulologradouro, false, includeNonInitialized);
         AddObjectProperty("TituloLogradouro_N", gxTv_SdtTituloProposta_Titulologradouro_N, false, includeNonInitialized);
         AddObjectProperty("TituloNumeroEndereco", gxTv_SdtTituloProposta_Titulonumeroendereco, false, includeNonInitialized);
         AddObjectProperty("TituloNumeroEndereco_N", gxTv_SdtTituloProposta_Titulonumeroendereco_N, false, includeNonInitialized);
         AddObjectProperty("TituloComplemento", gxTv_SdtTituloProposta_Titulocomplemento, false, includeNonInitialized);
         AddObjectProperty("TituloComplemento_N", gxTv_SdtTituloProposta_Titulocomplemento_N, false, includeNonInitialized);
         AddObjectProperty("TituloBairro", gxTv_SdtTituloProposta_Titulobairro, false, includeNonInitialized);
         AddObjectProperty("TituloBairro_N", gxTv_SdtTituloProposta_Titulobairro_N, false, includeNonInitialized);
         AddObjectProperty("TituloMunicipio", gxTv_SdtTituloProposta_Titulomunicipio, false, includeNonInitialized);
         AddObjectProperty("TituloMunicipio_N", gxTv_SdtTituloProposta_Titulomunicipio_N, false, includeNonInitialized);
         AddObjectProperty("TituloJurosMora", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTituloProposta_Titulojurosmora, 16, 4)), false, includeNonInitialized);
         AddObjectProperty("TituloJurosMora_N", gxTv_SdtTituloProposta_Titulojurosmora_N, false, includeNonInitialized);
         AddObjectProperty("TituloTipo", gxTv_SdtTituloProposta_Titulotipo, false, includeNonInitialized);
         AddObjectProperty("TituloTipo_N", gxTv_SdtTituloProposta_Titulotipo_N, false, includeNonInitialized);
         AddObjectProperty("TituloPropostaId", gxTv_SdtTituloProposta_Titulopropostaid, false, includeNonInitialized);
         AddObjectProperty("TituloPropostaId_N", gxTv_SdtTituloProposta_Titulopropostaid_N, false, includeNonInitialized);
         AddObjectProperty("PropostaTaxaAdministrativa", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTituloProposta_Propostataxaadministrativa, 16, 4)), false, includeNonInitialized);
         AddObjectProperty("PropostaTaxaAdministrativa_N", gxTv_SdtTituloProposta_Propostataxaadministrativa_N, false, includeNonInitialized);
         AddObjectProperty("ContaId", gxTv_SdtTituloProposta_Contaid, false, includeNonInitialized);
         AddObjectProperty("ContaId_N", gxTv_SdtTituloProposta_Contaid_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtTituloProposta_Titulocriacao;
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
         AddObjectProperty("TituloCriacao", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("TituloCriacao_N", gxTv_SdtTituloProposta_Titulocriacao_N, false, includeNonInitialized);
         AddObjectProperty("CategoriaTituloId", gxTv_SdtTituloProposta_Categoriatituloid, false, includeNonInitialized);
         AddObjectProperty("CategoriaTituloId_N", gxTv_SdtTituloProposta_Categoriatituloid_N, false, includeNonInitialized);
         AddObjectProperty("TituloTotalMovimento_F", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTituloProposta_Titulototalmovimento_f, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("TituloTotalMovimento_F_N", gxTv_SdtTituloProposta_Titulototalmovimento_f_N, false, includeNonInitialized);
         AddObjectProperty("TituloTotalMultaJuros_F", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTituloProposta_Titulototalmultajuros_f, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("TituloTotalMultaJuros_F_N", gxTv_SdtTituloProposta_Titulototalmultajuros_f_N, false, includeNonInitialized);
         AddObjectProperty("TituloSaldo_F", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTituloProposta_Titulosaldo_f, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("TituloStatus_F", gxTv_SdtTituloProposta_Titulostatus_f, false, includeNonInitialized);
         AddObjectProperty("TituloSaldoDebito_F", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTituloProposta_Titulosaldodebito_f, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("TituloSaldoCredito_F", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTituloProposta_Titulosaldocredito_f, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("TituloTotalMovimentoDebito_F", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTituloProposta_Titulototalmovimentodebito_f, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("TituloTotalMovimentoCredito_F", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTituloProposta_Titulototalmovimentocredito_f, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("TituloTotalMultaJurosDebito_F", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTituloProposta_Titulototalmultajurosdebito_f, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("TituloTotalMultaJurosCredito_F", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTituloProposta_Titulototalmultajuroscredito_f, 18, 2)), false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTituloProposta_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTituloProposta_Initialized, false, includeNonInitialized);
            AddObjectProperty("TituloId_Z", gxTv_SdtTituloProposta_Tituloid_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteId_Z", gxTv_SdtTituloProposta_Clienteid_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteRazaoSocial_Z", gxTv_SdtTituloProposta_Clienterazaosocial_Z, false, includeNonInitialized);
            AddObjectProperty("TituloValor_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTituloProposta_Titulovalor_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("TituloDesconto_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTituloProposta_Titulodesconto_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("TituloDeleted_Z", gxTv_SdtTituloProposta_Titulodeleted_Z, false, includeNonInitialized);
            AddObjectProperty("TituloArchived_Z", gxTv_SdtTituloProposta_Tituloarchived_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtTituloProposta_Titulovencimento_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtTituloProposta_Titulovencimento_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtTituloProposta_Titulovencimento_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("TituloVencimento_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("TituloCompetenciaAno_Z", gxTv_SdtTituloProposta_Titulocompetenciaano_Z, false, includeNonInitialized);
            AddObjectProperty("TituloCompetenciaMes_Z", gxTv_SdtTituloProposta_Titulocompetenciames_Z, false, includeNonInitialized);
            AddObjectProperty("TituloCompetencia_F_Z", gxTv_SdtTituloProposta_Titulocompetencia_f_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtTituloProposta_Tituloprorrogacao_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtTituloProposta_Tituloprorrogacao_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtTituloProposta_Tituloprorrogacao_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("TituloProrrogacao_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("TituloCEP_Z", gxTv_SdtTituloProposta_Titulocep_Z, false, includeNonInitialized);
            AddObjectProperty("TituloLogradouro_Z", gxTv_SdtTituloProposta_Titulologradouro_Z, false, includeNonInitialized);
            AddObjectProperty("TituloNumeroEndereco_Z", gxTv_SdtTituloProposta_Titulonumeroendereco_Z, false, includeNonInitialized);
            AddObjectProperty("TituloComplemento_Z", gxTv_SdtTituloProposta_Titulocomplemento_Z, false, includeNonInitialized);
            AddObjectProperty("TituloBairro_Z", gxTv_SdtTituloProposta_Titulobairro_Z, false, includeNonInitialized);
            AddObjectProperty("TituloMunicipio_Z", gxTv_SdtTituloProposta_Titulomunicipio_Z, false, includeNonInitialized);
            AddObjectProperty("TituloJurosMora_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTituloProposta_Titulojurosmora_Z, 16, 4)), false, includeNonInitialized);
            AddObjectProperty("TituloTipo_Z", gxTv_SdtTituloProposta_Titulotipo_Z, false, includeNonInitialized);
            AddObjectProperty("TituloPropostaId_Z", gxTv_SdtTituloProposta_Titulopropostaid_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaTaxaAdministrativa_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTituloProposta_Propostataxaadministrativa_Z, 16, 4)), false, includeNonInitialized);
            AddObjectProperty("ContaId_Z", gxTv_SdtTituloProposta_Contaid_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtTituloProposta_Titulocriacao_Z;
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
            AddObjectProperty("TituloCriacao_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("CategoriaTituloId_Z", gxTv_SdtTituloProposta_Categoriatituloid_Z, false, includeNonInitialized);
            AddObjectProperty("TituloTotalMovimento_F_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTituloProposta_Titulototalmovimento_f_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("TituloTotalMultaJuros_F_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTituloProposta_Titulototalmultajuros_f_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("TituloSaldo_F_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTituloProposta_Titulosaldo_f_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("TituloStatus_F_Z", gxTv_SdtTituloProposta_Titulostatus_f_Z, false, includeNonInitialized);
            AddObjectProperty("TituloSaldoDebito_F_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTituloProposta_Titulosaldodebito_f_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("TituloSaldoCredito_F_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTituloProposta_Titulosaldocredito_f_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("TituloTotalMovimentoDebito_F_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTituloProposta_Titulototalmovimentodebito_f_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("TituloTotalMovimentoCredito_F_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTituloProposta_Titulototalmovimentocredito_f_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("TituloTotalMultaJurosDebito_F_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTituloProposta_Titulototalmultajurosdebito_f_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("TituloTotalMultaJurosCredito_F_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTituloProposta_Titulototalmultajuroscredito_f_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("TituloId_N", gxTv_SdtTituloProposta_Tituloid_N, false, includeNonInitialized);
            AddObjectProperty("ClienteId_N", gxTv_SdtTituloProposta_Clienteid_N, false, includeNonInitialized);
            AddObjectProperty("ClienteRazaoSocial_N", gxTv_SdtTituloProposta_Clienterazaosocial_N, false, includeNonInitialized);
            AddObjectProperty("TituloValor_N", gxTv_SdtTituloProposta_Titulovalor_N, false, includeNonInitialized);
            AddObjectProperty("TituloDesconto_N", gxTv_SdtTituloProposta_Titulodesconto_N, false, includeNonInitialized);
            AddObjectProperty("TituloDeleted_N", gxTv_SdtTituloProposta_Titulodeleted_N, false, includeNonInitialized);
            AddObjectProperty("TituloArchived_N", gxTv_SdtTituloProposta_Tituloarchived_N, false, includeNonInitialized);
            AddObjectProperty("TituloVencimento_N", gxTv_SdtTituloProposta_Titulovencimento_N, false, includeNonInitialized);
            AddObjectProperty("TituloCompetenciaAno_N", gxTv_SdtTituloProposta_Titulocompetenciaano_N, false, includeNonInitialized);
            AddObjectProperty("TituloCompetenciaMes_N", gxTv_SdtTituloProposta_Titulocompetenciames_N, false, includeNonInitialized);
            AddObjectProperty("TituloProrrogacao_N", gxTv_SdtTituloProposta_Tituloprorrogacao_N, false, includeNonInitialized);
            AddObjectProperty("TituloCEP_N", gxTv_SdtTituloProposta_Titulocep_N, false, includeNonInitialized);
            AddObjectProperty("TituloLogradouro_N", gxTv_SdtTituloProposta_Titulologradouro_N, false, includeNonInitialized);
            AddObjectProperty("TituloNumeroEndereco_N", gxTv_SdtTituloProposta_Titulonumeroendereco_N, false, includeNonInitialized);
            AddObjectProperty("TituloComplemento_N", gxTv_SdtTituloProposta_Titulocomplemento_N, false, includeNonInitialized);
            AddObjectProperty("TituloBairro_N", gxTv_SdtTituloProposta_Titulobairro_N, false, includeNonInitialized);
            AddObjectProperty("TituloMunicipio_N", gxTv_SdtTituloProposta_Titulomunicipio_N, false, includeNonInitialized);
            AddObjectProperty("TituloJurosMora_N", gxTv_SdtTituloProposta_Titulojurosmora_N, false, includeNonInitialized);
            AddObjectProperty("TituloTipo_N", gxTv_SdtTituloProposta_Titulotipo_N, false, includeNonInitialized);
            AddObjectProperty("TituloPropostaId_N", gxTv_SdtTituloProposta_Titulopropostaid_N, false, includeNonInitialized);
            AddObjectProperty("PropostaTaxaAdministrativa_N", gxTv_SdtTituloProposta_Propostataxaadministrativa_N, false, includeNonInitialized);
            AddObjectProperty("ContaId_N", gxTv_SdtTituloProposta_Contaid_N, false, includeNonInitialized);
            AddObjectProperty("TituloCriacao_N", gxTv_SdtTituloProposta_Titulocriacao_N, false, includeNonInitialized);
            AddObjectProperty("CategoriaTituloId_N", gxTv_SdtTituloProposta_Categoriatituloid_N, false, includeNonInitialized);
            AddObjectProperty("TituloTotalMovimento_F_N", gxTv_SdtTituloProposta_Titulototalmovimento_f_N, false, includeNonInitialized);
            AddObjectProperty("TituloTotalMultaJuros_F_N", gxTv_SdtTituloProposta_Titulototalmultajuros_f_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTituloProposta sdt )
      {
         if ( sdt.IsDirty("TituloId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Tituloid = sdt.gxTv_SdtTituloProposta_Tituloid ;
         }
         if ( sdt.IsDirty("ClienteId") )
         {
            gxTv_SdtTituloProposta_Clienteid_N = (short)(sdt.gxTv_SdtTituloProposta_Clienteid_N);
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Clienteid = sdt.gxTv_SdtTituloProposta_Clienteid ;
         }
         if ( sdt.IsDirty("ClienteRazaoSocial") )
         {
            gxTv_SdtTituloProposta_Clienterazaosocial_N = (short)(sdt.gxTv_SdtTituloProposta_Clienterazaosocial_N);
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Clienterazaosocial = sdt.gxTv_SdtTituloProposta_Clienterazaosocial ;
         }
         if ( sdt.IsDirty("TituloValor") )
         {
            gxTv_SdtTituloProposta_Titulovalor_N = (short)(sdt.gxTv_SdtTituloProposta_Titulovalor_N);
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulovalor = sdt.gxTv_SdtTituloProposta_Titulovalor ;
         }
         if ( sdt.IsDirty("TituloDesconto") )
         {
            gxTv_SdtTituloProposta_Titulodesconto_N = (short)(sdt.gxTv_SdtTituloProposta_Titulodesconto_N);
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulodesconto = sdt.gxTv_SdtTituloProposta_Titulodesconto ;
         }
         if ( sdt.IsDirty("TituloDeleted") )
         {
            gxTv_SdtTituloProposta_Titulodeleted_N = (short)(sdt.gxTv_SdtTituloProposta_Titulodeleted_N);
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulodeleted = sdt.gxTv_SdtTituloProposta_Titulodeleted ;
         }
         if ( sdt.IsDirty("TituloArchived") )
         {
            gxTv_SdtTituloProposta_Tituloarchived_N = (short)(sdt.gxTv_SdtTituloProposta_Tituloarchived_N);
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Tituloarchived = sdt.gxTv_SdtTituloProposta_Tituloarchived ;
         }
         if ( sdt.IsDirty("TituloVencimento") )
         {
            gxTv_SdtTituloProposta_Titulovencimento_N = (short)(sdt.gxTv_SdtTituloProposta_Titulovencimento_N);
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulovencimento = sdt.gxTv_SdtTituloProposta_Titulovencimento ;
         }
         if ( sdt.IsDirty("TituloCompetenciaAno") )
         {
            gxTv_SdtTituloProposta_Titulocompetenciaano_N = (short)(sdt.gxTv_SdtTituloProposta_Titulocompetenciaano_N);
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulocompetenciaano = sdt.gxTv_SdtTituloProposta_Titulocompetenciaano ;
         }
         if ( sdt.IsDirty("TituloCompetenciaMes") )
         {
            gxTv_SdtTituloProposta_Titulocompetenciames_N = (short)(sdt.gxTv_SdtTituloProposta_Titulocompetenciames_N);
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulocompetenciames = sdt.gxTv_SdtTituloProposta_Titulocompetenciames ;
         }
         if ( sdt.IsDirty("TituloCompetencia_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulocompetencia_f = sdt.gxTv_SdtTituloProposta_Titulocompetencia_f ;
         }
         if ( sdt.IsDirty("TituloProrrogacao") )
         {
            gxTv_SdtTituloProposta_Tituloprorrogacao_N = (short)(sdt.gxTv_SdtTituloProposta_Tituloprorrogacao_N);
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Tituloprorrogacao = sdt.gxTv_SdtTituloProposta_Tituloprorrogacao ;
         }
         if ( sdt.IsDirty("TituloCEP") )
         {
            gxTv_SdtTituloProposta_Titulocep_N = (short)(sdt.gxTv_SdtTituloProposta_Titulocep_N);
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulocep = sdt.gxTv_SdtTituloProposta_Titulocep ;
         }
         if ( sdt.IsDirty("TituloLogradouro") )
         {
            gxTv_SdtTituloProposta_Titulologradouro_N = (short)(sdt.gxTv_SdtTituloProposta_Titulologradouro_N);
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulologradouro = sdt.gxTv_SdtTituloProposta_Titulologradouro ;
         }
         if ( sdt.IsDirty("TituloNumeroEndereco") )
         {
            gxTv_SdtTituloProposta_Titulonumeroendereco_N = (short)(sdt.gxTv_SdtTituloProposta_Titulonumeroendereco_N);
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulonumeroendereco = sdt.gxTv_SdtTituloProposta_Titulonumeroendereco ;
         }
         if ( sdt.IsDirty("TituloComplemento") )
         {
            gxTv_SdtTituloProposta_Titulocomplemento_N = (short)(sdt.gxTv_SdtTituloProposta_Titulocomplemento_N);
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulocomplemento = sdt.gxTv_SdtTituloProposta_Titulocomplemento ;
         }
         if ( sdt.IsDirty("TituloBairro") )
         {
            gxTv_SdtTituloProposta_Titulobairro_N = (short)(sdt.gxTv_SdtTituloProposta_Titulobairro_N);
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulobairro = sdt.gxTv_SdtTituloProposta_Titulobairro ;
         }
         if ( sdt.IsDirty("TituloMunicipio") )
         {
            gxTv_SdtTituloProposta_Titulomunicipio_N = (short)(sdt.gxTv_SdtTituloProposta_Titulomunicipio_N);
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulomunicipio = sdt.gxTv_SdtTituloProposta_Titulomunicipio ;
         }
         if ( sdt.IsDirty("TituloJurosMora") )
         {
            gxTv_SdtTituloProposta_Titulojurosmora_N = (short)(sdt.gxTv_SdtTituloProposta_Titulojurosmora_N);
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulojurosmora = sdt.gxTv_SdtTituloProposta_Titulojurosmora ;
         }
         if ( sdt.IsDirty("TituloTipo") )
         {
            gxTv_SdtTituloProposta_Titulotipo_N = (short)(sdt.gxTv_SdtTituloProposta_Titulotipo_N);
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulotipo = sdt.gxTv_SdtTituloProposta_Titulotipo ;
         }
         if ( sdt.IsDirty("TituloPropostaId") )
         {
            gxTv_SdtTituloProposta_Titulopropostaid_N = (short)(sdt.gxTv_SdtTituloProposta_Titulopropostaid_N);
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulopropostaid = sdt.gxTv_SdtTituloProposta_Titulopropostaid ;
         }
         if ( sdt.IsDirty("PropostaTaxaAdministrativa") )
         {
            gxTv_SdtTituloProposta_Propostataxaadministrativa_N = (short)(sdt.gxTv_SdtTituloProposta_Propostataxaadministrativa_N);
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Propostataxaadministrativa = sdt.gxTv_SdtTituloProposta_Propostataxaadministrativa ;
         }
         if ( sdt.IsDirty("ContaId") )
         {
            gxTv_SdtTituloProposta_Contaid_N = (short)(sdt.gxTv_SdtTituloProposta_Contaid_N);
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Contaid = sdt.gxTv_SdtTituloProposta_Contaid ;
         }
         if ( sdt.IsDirty("TituloCriacao") )
         {
            gxTv_SdtTituloProposta_Titulocriacao_N = (short)(sdt.gxTv_SdtTituloProposta_Titulocriacao_N);
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulocriacao = sdt.gxTv_SdtTituloProposta_Titulocriacao ;
         }
         if ( sdt.IsDirty("CategoriaTituloId") )
         {
            gxTv_SdtTituloProposta_Categoriatituloid_N = (short)(sdt.gxTv_SdtTituloProposta_Categoriatituloid_N);
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Categoriatituloid = sdt.gxTv_SdtTituloProposta_Categoriatituloid ;
         }
         if ( sdt.IsDirty("TituloTotalMovimento_F") )
         {
            gxTv_SdtTituloProposta_Titulototalmovimento_f_N = (short)(sdt.gxTv_SdtTituloProposta_Titulototalmovimento_f_N);
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulototalmovimento_f = sdt.gxTv_SdtTituloProposta_Titulototalmovimento_f ;
         }
         if ( sdt.IsDirty("TituloTotalMultaJuros_F") )
         {
            gxTv_SdtTituloProposta_Titulototalmultajuros_f_N = (short)(sdt.gxTv_SdtTituloProposta_Titulototalmultajuros_f_N);
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulototalmultajuros_f = sdt.gxTv_SdtTituloProposta_Titulototalmultajuros_f ;
         }
         if ( sdt.IsDirty("TituloSaldo_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulosaldo_f = sdt.gxTv_SdtTituloProposta_Titulosaldo_f ;
         }
         if ( sdt.IsDirty("TituloStatus_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulostatus_f = sdt.gxTv_SdtTituloProposta_Titulostatus_f ;
         }
         if ( sdt.IsDirty("TituloSaldoDebito_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulosaldodebito_f = sdt.gxTv_SdtTituloProposta_Titulosaldodebito_f ;
         }
         if ( sdt.IsDirty("TituloSaldoCredito_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulosaldocredito_f = sdt.gxTv_SdtTituloProposta_Titulosaldocredito_f ;
         }
         if ( sdt.IsDirty("TituloTotalMovimentoDebito_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulototalmovimentodebito_f = sdt.gxTv_SdtTituloProposta_Titulototalmovimentodebito_f ;
         }
         if ( sdt.IsDirty("TituloTotalMovimentoCredito_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulototalmovimentocredito_f = sdt.gxTv_SdtTituloProposta_Titulototalmovimentocredito_f ;
         }
         if ( sdt.IsDirty("TituloTotalMultaJurosDebito_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulototalmultajurosdebito_f = sdt.gxTv_SdtTituloProposta_Titulototalmultajurosdebito_f ;
         }
         if ( sdt.IsDirty("TituloTotalMultaJurosCredito_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulototalmultajuroscredito_f = sdt.gxTv_SdtTituloProposta_Titulototalmultajuroscredito_f ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "TituloId" )]
      [  XmlElement( ElementName = "TituloId"   )]
      public int gxTpr_Tituloid
      {
         get {
            return gxTv_SdtTituloProposta_Tituloid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTituloProposta_Tituloid != value )
            {
               gxTv_SdtTituloProposta_Mode = "INS";
               this.gxTv_SdtTituloProposta_Tituloid_Z_SetNull( );
               this.gxTv_SdtTituloProposta_Clienteid_Z_SetNull( );
               this.gxTv_SdtTituloProposta_Clienterazaosocial_Z_SetNull( );
               this.gxTv_SdtTituloProposta_Titulovalor_Z_SetNull( );
               this.gxTv_SdtTituloProposta_Titulodesconto_Z_SetNull( );
               this.gxTv_SdtTituloProposta_Titulodeleted_Z_SetNull( );
               this.gxTv_SdtTituloProposta_Tituloarchived_Z_SetNull( );
               this.gxTv_SdtTituloProposta_Titulovencimento_Z_SetNull( );
               this.gxTv_SdtTituloProposta_Titulocompetenciaano_Z_SetNull( );
               this.gxTv_SdtTituloProposta_Titulocompetenciames_Z_SetNull( );
               this.gxTv_SdtTituloProposta_Titulocompetencia_f_Z_SetNull( );
               this.gxTv_SdtTituloProposta_Tituloprorrogacao_Z_SetNull( );
               this.gxTv_SdtTituloProposta_Titulocep_Z_SetNull( );
               this.gxTv_SdtTituloProposta_Titulologradouro_Z_SetNull( );
               this.gxTv_SdtTituloProposta_Titulonumeroendereco_Z_SetNull( );
               this.gxTv_SdtTituloProposta_Titulocomplemento_Z_SetNull( );
               this.gxTv_SdtTituloProposta_Titulobairro_Z_SetNull( );
               this.gxTv_SdtTituloProposta_Titulomunicipio_Z_SetNull( );
               this.gxTv_SdtTituloProposta_Titulojurosmora_Z_SetNull( );
               this.gxTv_SdtTituloProposta_Titulotipo_Z_SetNull( );
               this.gxTv_SdtTituloProposta_Titulopropostaid_Z_SetNull( );
               this.gxTv_SdtTituloProposta_Propostataxaadministrativa_Z_SetNull( );
               this.gxTv_SdtTituloProposta_Contaid_Z_SetNull( );
               this.gxTv_SdtTituloProposta_Titulocriacao_Z_SetNull( );
               this.gxTv_SdtTituloProposta_Categoriatituloid_Z_SetNull( );
               this.gxTv_SdtTituloProposta_Titulototalmovimento_f_Z_SetNull( );
               this.gxTv_SdtTituloProposta_Titulototalmultajuros_f_Z_SetNull( );
               this.gxTv_SdtTituloProposta_Titulosaldo_f_Z_SetNull( );
               this.gxTv_SdtTituloProposta_Titulostatus_f_Z_SetNull( );
               this.gxTv_SdtTituloProposta_Titulosaldodebito_f_Z_SetNull( );
               this.gxTv_SdtTituloProposta_Titulosaldocredito_f_Z_SetNull( );
               this.gxTv_SdtTituloProposta_Titulototalmovimentodebito_f_Z_SetNull( );
               this.gxTv_SdtTituloProposta_Titulototalmovimentocredito_f_Z_SetNull( );
               this.gxTv_SdtTituloProposta_Titulototalmultajurosdebito_f_Z_SetNull( );
               this.gxTv_SdtTituloProposta_Titulototalmultajuroscredito_f_Z_SetNull( );
            }
            gxTv_SdtTituloProposta_Tituloid = value;
            SetDirty("Tituloid");
         }

      }

      [  SoapElement( ElementName = "ClienteId" )]
      [  XmlElement( ElementName = "ClienteId"   )]
      public int gxTpr_Clienteid
      {
         get {
            return gxTv_SdtTituloProposta_Clienteid ;
         }

         set {
            gxTv_SdtTituloProposta_Clienteid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Clienteid = value;
            SetDirty("Clienteid");
         }

      }

      public void gxTv_SdtTituloProposta_Clienteid_SetNull( )
      {
         gxTv_SdtTituloProposta_Clienteid_N = 1;
         gxTv_SdtTituloProposta_Clienteid = 0;
         SetDirty("Clienteid");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Clienteid_IsNull( )
      {
         return (gxTv_SdtTituloProposta_Clienteid_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteRazaoSocial" )]
      [  XmlElement( ElementName = "ClienteRazaoSocial"   )]
      public string gxTpr_Clienterazaosocial
      {
         get {
            return gxTv_SdtTituloProposta_Clienterazaosocial ;
         }

         set {
            gxTv_SdtTituloProposta_Clienterazaosocial_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Clienterazaosocial = value;
            SetDirty("Clienterazaosocial");
         }

      }

      public void gxTv_SdtTituloProposta_Clienterazaosocial_SetNull( )
      {
         gxTv_SdtTituloProposta_Clienterazaosocial_N = 1;
         gxTv_SdtTituloProposta_Clienterazaosocial = "";
         SetDirty("Clienterazaosocial");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Clienterazaosocial_IsNull( )
      {
         return (gxTv_SdtTituloProposta_Clienterazaosocial_N==1) ;
      }

      [  SoapElement( ElementName = "TituloValor" )]
      [  XmlElement( ElementName = "TituloValor"   )]
      public decimal gxTpr_Titulovalor
      {
         get {
            return gxTv_SdtTituloProposta_Titulovalor ;
         }

         set {
            gxTv_SdtTituloProposta_Titulovalor_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulovalor = value;
            SetDirty("Titulovalor");
         }

      }

      public void gxTv_SdtTituloProposta_Titulovalor_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulovalor_N = 1;
         gxTv_SdtTituloProposta_Titulovalor = 0;
         SetDirty("Titulovalor");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulovalor_IsNull( )
      {
         return (gxTv_SdtTituloProposta_Titulovalor_N==1) ;
      }

      [  SoapElement( ElementName = "TituloDesconto" )]
      [  XmlElement( ElementName = "TituloDesconto"   )]
      public decimal gxTpr_Titulodesconto
      {
         get {
            return gxTv_SdtTituloProposta_Titulodesconto ;
         }

         set {
            gxTv_SdtTituloProposta_Titulodesconto_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulodesconto = value;
            SetDirty("Titulodesconto");
         }

      }

      public void gxTv_SdtTituloProposta_Titulodesconto_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulodesconto_N = 1;
         gxTv_SdtTituloProposta_Titulodesconto = 0;
         SetDirty("Titulodesconto");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulodesconto_IsNull( )
      {
         return (gxTv_SdtTituloProposta_Titulodesconto_N==1) ;
      }

      [  SoapElement( ElementName = "TituloDeleted" )]
      [  XmlElement( ElementName = "TituloDeleted"   )]
      public bool gxTpr_Titulodeleted
      {
         get {
            return gxTv_SdtTituloProposta_Titulodeleted ;
         }

         set {
            gxTv_SdtTituloProposta_Titulodeleted_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulodeleted = value;
            SetDirty("Titulodeleted");
         }

      }

      public void gxTv_SdtTituloProposta_Titulodeleted_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulodeleted_N = 1;
         gxTv_SdtTituloProposta_Titulodeleted = false;
         SetDirty("Titulodeleted");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulodeleted_IsNull( )
      {
         return (gxTv_SdtTituloProposta_Titulodeleted_N==1) ;
      }

      [  SoapElement( ElementName = "TituloArchived" )]
      [  XmlElement( ElementName = "TituloArchived"   )]
      public bool gxTpr_Tituloarchived
      {
         get {
            return gxTv_SdtTituloProposta_Tituloarchived ;
         }

         set {
            gxTv_SdtTituloProposta_Tituloarchived_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Tituloarchived = value;
            SetDirty("Tituloarchived");
         }

      }

      public void gxTv_SdtTituloProposta_Tituloarchived_SetNull( )
      {
         gxTv_SdtTituloProposta_Tituloarchived_N = 1;
         gxTv_SdtTituloProposta_Tituloarchived = false;
         SetDirty("Tituloarchived");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Tituloarchived_IsNull( )
      {
         return (gxTv_SdtTituloProposta_Tituloarchived_N==1) ;
      }

      [  SoapElement( ElementName = "TituloVencimento" )]
      [  XmlElement( ElementName = "TituloVencimento"  , IsNullable=true )]
      public string gxTpr_Titulovencimento_Nullable
      {
         get {
            if ( gxTv_SdtTituloProposta_Titulovencimento == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtTituloProposta_Titulovencimento).value ;
         }

         set {
            gxTv_SdtTituloProposta_Titulovencimento_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtTituloProposta_Titulovencimento = DateTime.MinValue;
            else
               gxTv_SdtTituloProposta_Titulovencimento = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Titulovencimento
      {
         get {
            return gxTv_SdtTituloProposta_Titulovencimento ;
         }

         set {
            gxTv_SdtTituloProposta_Titulovencimento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulovencimento = value;
            SetDirty("Titulovencimento");
         }

      }

      public void gxTv_SdtTituloProposta_Titulovencimento_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulovencimento_N = 1;
         gxTv_SdtTituloProposta_Titulovencimento = (DateTime)(DateTime.MinValue);
         SetDirty("Titulovencimento");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulovencimento_IsNull( )
      {
         return (gxTv_SdtTituloProposta_Titulovencimento_N==1) ;
      }

      [  SoapElement( ElementName = "TituloCompetenciaAno" )]
      [  XmlElement( ElementName = "TituloCompetenciaAno"   )]
      public short gxTpr_Titulocompetenciaano
      {
         get {
            return gxTv_SdtTituloProposta_Titulocompetenciaano ;
         }

         set {
            gxTv_SdtTituloProposta_Titulocompetenciaano_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulocompetenciaano = value;
            SetDirty("Titulocompetenciaano");
         }

      }

      public void gxTv_SdtTituloProposta_Titulocompetenciaano_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulocompetenciaano_N = 1;
         gxTv_SdtTituloProposta_Titulocompetenciaano = 0;
         SetDirty("Titulocompetenciaano");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulocompetenciaano_IsNull( )
      {
         return (gxTv_SdtTituloProposta_Titulocompetenciaano_N==1) ;
      }

      [  SoapElement( ElementName = "TituloCompetenciaMes" )]
      [  XmlElement( ElementName = "TituloCompetenciaMes"   )]
      public short gxTpr_Titulocompetenciames
      {
         get {
            return gxTv_SdtTituloProposta_Titulocompetenciames ;
         }

         set {
            gxTv_SdtTituloProposta_Titulocompetenciames_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulocompetenciames = value;
            SetDirty("Titulocompetenciames");
         }

      }

      public void gxTv_SdtTituloProposta_Titulocompetenciames_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulocompetenciames_N = 1;
         gxTv_SdtTituloProposta_Titulocompetenciames = 0;
         SetDirty("Titulocompetenciames");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulocompetenciames_IsNull( )
      {
         return (gxTv_SdtTituloProposta_Titulocompetenciames_N==1) ;
      }

      [  SoapElement( ElementName = "TituloCompetencia_F" )]
      [  XmlElement( ElementName = "TituloCompetencia_F"   )]
      public string gxTpr_Titulocompetencia_f
      {
         get {
            return gxTv_SdtTituloProposta_Titulocompetencia_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulocompetencia_f = value;
            SetDirty("Titulocompetencia_f");
         }

      }

      public void gxTv_SdtTituloProposta_Titulocompetencia_f_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulocompetencia_f = "";
         SetDirty("Titulocompetencia_f");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulocompetencia_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloProrrogacao" )]
      [  XmlElement( ElementName = "TituloProrrogacao"  , IsNullable=true )]
      public string gxTpr_Tituloprorrogacao_Nullable
      {
         get {
            if ( gxTv_SdtTituloProposta_Tituloprorrogacao == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtTituloProposta_Tituloprorrogacao).value ;
         }

         set {
            gxTv_SdtTituloProposta_Tituloprorrogacao_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtTituloProposta_Tituloprorrogacao = DateTime.MinValue;
            else
               gxTv_SdtTituloProposta_Tituloprorrogacao = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Tituloprorrogacao
      {
         get {
            return gxTv_SdtTituloProposta_Tituloprorrogacao ;
         }

         set {
            gxTv_SdtTituloProposta_Tituloprorrogacao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Tituloprorrogacao = value;
            SetDirty("Tituloprorrogacao");
         }

      }

      public void gxTv_SdtTituloProposta_Tituloprorrogacao_SetNull( )
      {
         gxTv_SdtTituloProposta_Tituloprorrogacao_N = 1;
         gxTv_SdtTituloProposta_Tituloprorrogacao = (DateTime)(DateTime.MinValue);
         SetDirty("Tituloprorrogacao");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Tituloprorrogacao_IsNull( )
      {
         return (gxTv_SdtTituloProposta_Tituloprorrogacao_N==1) ;
      }

      [  SoapElement( ElementName = "TituloCEP" )]
      [  XmlElement( ElementName = "TituloCEP"   )]
      public string gxTpr_Titulocep
      {
         get {
            return gxTv_SdtTituloProposta_Titulocep ;
         }

         set {
            gxTv_SdtTituloProposta_Titulocep_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulocep = value;
            SetDirty("Titulocep");
         }

      }

      public void gxTv_SdtTituloProposta_Titulocep_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulocep_N = 1;
         gxTv_SdtTituloProposta_Titulocep = "";
         SetDirty("Titulocep");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulocep_IsNull( )
      {
         return (gxTv_SdtTituloProposta_Titulocep_N==1) ;
      }

      [  SoapElement( ElementName = "TituloLogradouro" )]
      [  XmlElement( ElementName = "TituloLogradouro"   )]
      public string gxTpr_Titulologradouro
      {
         get {
            return gxTv_SdtTituloProposta_Titulologradouro ;
         }

         set {
            gxTv_SdtTituloProposta_Titulologradouro_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulologradouro = value;
            SetDirty("Titulologradouro");
         }

      }

      public void gxTv_SdtTituloProposta_Titulologradouro_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulologradouro_N = 1;
         gxTv_SdtTituloProposta_Titulologradouro = "";
         SetDirty("Titulologradouro");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulologradouro_IsNull( )
      {
         return (gxTv_SdtTituloProposta_Titulologradouro_N==1) ;
      }

      [  SoapElement( ElementName = "TituloNumeroEndereco" )]
      [  XmlElement( ElementName = "TituloNumeroEndereco"   )]
      public string gxTpr_Titulonumeroendereco
      {
         get {
            return gxTv_SdtTituloProposta_Titulonumeroendereco ;
         }

         set {
            gxTv_SdtTituloProposta_Titulonumeroendereco_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulonumeroendereco = value;
            SetDirty("Titulonumeroendereco");
         }

      }

      public void gxTv_SdtTituloProposta_Titulonumeroendereco_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulonumeroendereco_N = 1;
         gxTv_SdtTituloProposta_Titulonumeroendereco = "";
         SetDirty("Titulonumeroendereco");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulonumeroendereco_IsNull( )
      {
         return (gxTv_SdtTituloProposta_Titulonumeroendereco_N==1) ;
      }

      [  SoapElement( ElementName = "TituloComplemento" )]
      [  XmlElement( ElementName = "TituloComplemento"   )]
      public string gxTpr_Titulocomplemento
      {
         get {
            return gxTv_SdtTituloProposta_Titulocomplemento ;
         }

         set {
            gxTv_SdtTituloProposta_Titulocomplemento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulocomplemento = value;
            SetDirty("Titulocomplemento");
         }

      }

      public void gxTv_SdtTituloProposta_Titulocomplemento_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulocomplemento_N = 1;
         gxTv_SdtTituloProposta_Titulocomplemento = "";
         SetDirty("Titulocomplemento");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulocomplemento_IsNull( )
      {
         return (gxTv_SdtTituloProposta_Titulocomplemento_N==1) ;
      }

      [  SoapElement( ElementName = "TituloBairro" )]
      [  XmlElement( ElementName = "TituloBairro"   )]
      public string gxTpr_Titulobairro
      {
         get {
            return gxTv_SdtTituloProposta_Titulobairro ;
         }

         set {
            gxTv_SdtTituloProposta_Titulobairro_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulobairro = value;
            SetDirty("Titulobairro");
         }

      }

      public void gxTv_SdtTituloProposta_Titulobairro_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulobairro_N = 1;
         gxTv_SdtTituloProposta_Titulobairro = "";
         SetDirty("Titulobairro");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulobairro_IsNull( )
      {
         return (gxTv_SdtTituloProposta_Titulobairro_N==1) ;
      }

      [  SoapElement( ElementName = "TituloMunicipio" )]
      [  XmlElement( ElementName = "TituloMunicipio"   )]
      public string gxTpr_Titulomunicipio
      {
         get {
            return gxTv_SdtTituloProposta_Titulomunicipio ;
         }

         set {
            gxTv_SdtTituloProposta_Titulomunicipio_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulomunicipio = value;
            SetDirty("Titulomunicipio");
         }

      }

      public void gxTv_SdtTituloProposta_Titulomunicipio_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulomunicipio_N = 1;
         gxTv_SdtTituloProposta_Titulomunicipio = "";
         SetDirty("Titulomunicipio");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulomunicipio_IsNull( )
      {
         return (gxTv_SdtTituloProposta_Titulomunicipio_N==1) ;
      }

      [  SoapElement( ElementName = "TituloJurosMora" )]
      [  XmlElement( ElementName = "TituloJurosMora"   )]
      public decimal gxTpr_Titulojurosmora
      {
         get {
            return gxTv_SdtTituloProposta_Titulojurosmora ;
         }

         set {
            gxTv_SdtTituloProposta_Titulojurosmora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulojurosmora = value;
            SetDirty("Titulojurosmora");
         }

      }

      public void gxTv_SdtTituloProposta_Titulojurosmora_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulojurosmora_N = 1;
         gxTv_SdtTituloProposta_Titulojurosmora = 0;
         SetDirty("Titulojurosmora");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulojurosmora_IsNull( )
      {
         return (gxTv_SdtTituloProposta_Titulojurosmora_N==1) ;
      }

      [  SoapElement( ElementName = "TituloTipo" )]
      [  XmlElement( ElementName = "TituloTipo"   )]
      public string gxTpr_Titulotipo
      {
         get {
            return gxTv_SdtTituloProposta_Titulotipo ;
         }

         set {
            gxTv_SdtTituloProposta_Titulotipo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulotipo = value;
            SetDirty("Titulotipo");
         }

      }

      public void gxTv_SdtTituloProposta_Titulotipo_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulotipo_N = 1;
         gxTv_SdtTituloProposta_Titulotipo = "";
         SetDirty("Titulotipo");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulotipo_IsNull( )
      {
         return (gxTv_SdtTituloProposta_Titulotipo_N==1) ;
      }

      [  SoapElement( ElementName = "TituloPropostaId" )]
      [  XmlElement( ElementName = "TituloPropostaId"   )]
      public int gxTpr_Titulopropostaid
      {
         get {
            return gxTv_SdtTituloProposta_Titulopropostaid ;
         }

         set {
            gxTv_SdtTituloProposta_Titulopropostaid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulopropostaid = value;
            SetDirty("Titulopropostaid");
         }

      }

      public void gxTv_SdtTituloProposta_Titulopropostaid_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulopropostaid_N = 1;
         gxTv_SdtTituloProposta_Titulopropostaid = 0;
         SetDirty("Titulopropostaid");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulopropostaid_IsNull( )
      {
         return (gxTv_SdtTituloProposta_Titulopropostaid_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaTaxaAdministrativa" )]
      [  XmlElement( ElementName = "PropostaTaxaAdministrativa"   )]
      public decimal gxTpr_Propostataxaadministrativa
      {
         get {
            return gxTv_SdtTituloProposta_Propostataxaadministrativa ;
         }

         set {
            gxTv_SdtTituloProposta_Propostataxaadministrativa_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Propostataxaadministrativa = value;
            SetDirty("Propostataxaadministrativa");
         }

      }

      public void gxTv_SdtTituloProposta_Propostataxaadministrativa_SetNull( )
      {
         gxTv_SdtTituloProposta_Propostataxaadministrativa_N = 1;
         gxTv_SdtTituloProposta_Propostataxaadministrativa = 0;
         SetDirty("Propostataxaadministrativa");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Propostataxaadministrativa_IsNull( )
      {
         return (gxTv_SdtTituloProposta_Propostataxaadministrativa_N==1) ;
      }

      [  SoapElement( ElementName = "ContaId" )]
      [  XmlElement( ElementName = "ContaId"   )]
      public int gxTpr_Contaid
      {
         get {
            return gxTv_SdtTituloProposta_Contaid ;
         }

         set {
            gxTv_SdtTituloProposta_Contaid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Contaid = value;
            SetDirty("Contaid");
         }

      }

      public void gxTv_SdtTituloProposta_Contaid_SetNull( )
      {
         gxTv_SdtTituloProposta_Contaid_N = 1;
         gxTv_SdtTituloProposta_Contaid = 0;
         SetDirty("Contaid");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Contaid_IsNull( )
      {
         return (gxTv_SdtTituloProposta_Contaid_N==1) ;
      }

      [  SoapElement( ElementName = "TituloCriacao" )]
      [  XmlElement( ElementName = "TituloCriacao"  , IsNullable=true )]
      public string gxTpr_Titulocriacao_Nullable
      {
         get {
            if ( gxTv_SdtTituloProposta_Titulocriacao == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTituloProposta_Titulocriacao).value ;
         }

         set {
            gxTv_SdtTituloProposta_Titulocriacao_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTituloProposta_Titulocriacao = DateTime.MinValue;
            else
               gxTv_SdtTituloProposta_Titulocriacao = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Titulocriacao
      {
         get {
            return gxTv_SdtTituloProposta_Titulocriacao ;
         }

         set {
            gxTv_SdtTituloProposta_Titulocriacao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulocriacao = value;
            SetDirty("Titulocriacao");
         }

      }

      public void gxTv_SdtTituloProposta_Titulocriacao_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulocriacao_N = 1;
         gxTv_SdtTituloProposta_Titulocriacao = (DateTime)(DateTime.MinValue);
         SetDirty("Titulocriacao");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulocriacao_IsNull( )
      {
         return (gxTv_SdtTituloProposta_Titulocriacao_N==1) ;
      }

      [  SoapElement( ElementName = "CategoriaTituloId" )]
      [  XmlElement( ElementName = "CategoriaTituloId"   )]
      public int gxTpr_Categoriatituloid
      {
         get {
            return gxTv_SdtTituloProposta_Categoriatituloid ;
         }

         set {
            gxTv_SdtTituloProposta_Categoriatituloid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Categoriatituloid = value;
            SetDirty("Categoriatituloid");
         }

      }

      public void gxTv_SdtTituloProposta_Categoriatituloid_SetNull( )
      {
         gxTv_SdtTituloProposta_Categoriatituloid_N = 1;
         gxTv_SdtTituloProposta_Categoriatituloid = 0;
         SetDirty("Categoriatituloid");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Categoriatituloid_IsNull( )
      {
         return (gxTv_SdtTituloProposta_Categoriatituloid_N==1) ;
      }

      [  SoapElement( ElementName = "TituloTotalMovimento_F" )]
      [  XmlElement( ElementName = "TituloTotalMovimento_F"   )]
      public decimal gxTpr_Titulototalmovimento_f
      {
         get {
            return gxTv_SdtTituloProposta_Titulototalmovimento_f ;
         }

         set {
            gxTv_SdtTituloProposta_Titulototalmovimento_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulototalmovimento_f = value;
            SetDirty("Titulototalmovimento_f");
         }

      }

      public void gxTv_SdtTituloProposta_Titulototalmovimento_f_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulototalmovimento_f_N = 1;
         gxTv_SdtTituloProposta_Titulototalmovimento_f = 0;
         SetDirty("Titulototalmovimento_f");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulototalmovimento_f_IsNull( )
      {
         return (gxTv_SdtTituloProposta_Titulototalmovimento_f_N==1) ;
      }

      [  SoapElement( ElementName = "TituloTotalMultaJuros_F" )]
      [  XmlElement( ElementName = "TituloTotalMultaJuros_F"   )]
      public decimal gxTpr_Titulototalmultajuros_f
      {
         get {
            return gxTv_SdtTituloProposta_Titulototalmultajuros_f ;
         }

         set {
            gxTv_SdtTituloProposta_Titulototalmultajuros_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulototalmultajuros_f = value;
            SetDirty("Titulototalmultajuros_f");
         }

      }

      public void gxTv_SdtTituloProposta_Titulototalmultajuros_f_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulototalmultajuros_f_N = 1;
         gxTv_SdtTituloProposta_Titulototalmultajuros_f = 0;
         SetDirty("Titulototalmultajuros_f");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulototalmultajuros_f_IsNull( )
      {
         return (gxTv_SdtTituloProposta_Titulototalmultajuros_f_N==1) ;
      }

      [  SoapElement( ElementName = "TituloSaldo_F" )]
      [  XmlElement( ElementName = "TituloSaldo_F"   )]
      public decimal gxTpr_Titulosaldo_f
      {
         get {
            return gxTv_SdtTituloProposta_Titulosaldo_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulosaldo_f = value;
            SetDirty("Titulosaldo_f");
         }

      }

      public void gxTv_SdtTituloProposta_Titulosaldo_f_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulosaldo_f = 0;
         SetDirty("Titulosaldo_f");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulosaldo_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloStatus_F" )]
      [  XmlElement( ElementName = "TituloStatus_F"   )]
      public string gxTpr_Titulostatus_f
      {
         get {
            return gxTv_SdtTituloProposta_Titulostatus_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulostatus_f = value;
            SetDirty("Titulostatus_f");
         }

      }

      public void gxTv_SdtTituloProposta_Titulostatus_f_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulostatus_f = "";
         SetDirty("Titulostatus_f");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulostatus_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloSaldoDebito_F" )]
      [  XmlElement( ElementName = "TituloSaldoDebito_F"   )]
      public decimal gxTpr_Titulosaldodebito_f
      {
         get {
            return gxTv_SdtTituloProposta_Titulosaldodebito_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulosaldodebito_f = value;
            SetDirty("Titulosaldodebito_f");
         }

      }

      public void gxTv_SdtTituloProposta_Titulosaldodebito_f_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulosaldodebito_f = 0;
         SetDirty("Titulosaldodebito_f");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulosaldodebito_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloSaldoCredito_F" )]
      [  XmlElement( ElementName = "TituloSaldoCredito_F"   )]
      public decimal gxTpr_Titulosaldocredito_f
      {
         get {
            return gxTv_SdtTituloProposta_Titulosaldocredito_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulosaldocredito_f = value;
            SetDirty("Titulosaldocredito_f");
         }

      }

      public void gxTv_SdtTituloProposta_Titulosaldocredito_f_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulosaldocredito_f = 0;
         SetDirty("Titulosaldocredito_f");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulosaldocredito_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloTotalMovimentoDebito_F" )]
      [  XmlElement( ElementName = "TituloTotalMovimentoDebito_F"   )]
      public decimal gxTpr_Titulototalmovimentodebito_f
      {
         get {
            return gxTv_SdtTituloProposta_Titulototalmovimentodebito_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulototalmovimentodebito_f = value;
            SetDirty("Titulototalmovimentodebito_f");
         }

      }

      public void gxTv_SdtTituloProposta_Titulototalmovimentodebito_f_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulototalmovimentodebito_f = 0;
         SetDirty("Titulototalmovimentodebito_f");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulototalmovimentodebito_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloTotalMovimentoCredito_F" )]
      [  XmlElement( ElementName = "TituloTotalMovimentoCredito_F"   )]
      public decimal gxTpr_Titulototalmovimentocredito_f
      {
         get {
            return gxTv_SdtTituloProposta_Titulototalmovimentocredito_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulototalmovimentocredito_f = value;
            SetDirty("Titulototalmovimentocredito_f");
         }

      }

      public void gxTv_SdtTituloProposta_Titulototalmovimentocredito_f_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulototalmovimentocredito_f = 0;
         SetDirty("Titulototalmovimentocredito_f");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulototalmovimentocredito_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloTotalMultaJurosDebito_F" )]
      [  XmlElement( ElementName = "TituloTotalMultaJurosDebito_F"   )]
      public decimal gxTpr_Titulototalmultajurosdebito_f
      {
         get {
            return gxTv_SdtTituloProposta_Titulototalmultajurosdebito_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulototalmultajurosdebito_f = value;
            SetDirty("Titulototalmultajurosdebito_f");
         }

      }

      public void gxTv_SdtTituloProposta_Titulototalmultajurosdebito_f_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulototalmultajurosdebito_f = 0;
         SetDirty("Titulototalmultajurosdebito_f");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulototalmultajurosdebito_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloTotalMultaJurosCredito_F" )]
      [  XmlElement( ElementName = "TituloTotalMultaJurosCredito_F"   )]
      public decimal gxTpr_Titulototalmultajuroscredito_f
      {
         get {
            return gxTv_SdtTituloProposta_Titulototalmultajuroscredito_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulototalmultajuroscredito_f = value;
            SetDirty("Titulototalmultajuroscredito_f");
         }

      }

      public void gxTv_SdtTituloProposta_Titulototalmultajuroscredito_f_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulototalmultajuroscredito_f = 0;
         SetDirty("Titulototalmultajuroscredito_f");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulototalmultajuroscredito_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTituloProposta_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTituloProposta_Mode_SetNull( )
      {
         gxTv_SdtTituloProposta_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTituloProposta_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTituloProposta_Initialized_SetNull( )
      {
         gxTv_SdtTituloProposta_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloId_Z" )]
      [  XmlElement( ElementName = "TituloId_Z"   )]
      public int gxTpr_Tituloid_Z
      {
         get {
            return gxTv_SdtTituloProposta_Tituloid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Tituloid_Z = value;
            SetDirty("Tituloid_Z");
         }

      }

      public void gxTv_SdtTituloProposta_Tituloid_Z_SetNull( )
      {
         gxTv_SdtTituloProposta_Tituloid_Z = 0;
         SetDirty("Tituloid_Z");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Tituloid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteId_Z" )]
      [  XmlElement( ElementName = "ClienteId_Z"   )]
      public int gxTpr_Clienteid_Z
      {
         get {
            return gxTv_SdtTituloProposta_Clienteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Clienteid_Z = value;
            SetDirty("Clienteid_Z");
         }

      }

      public void gxTv_SdtTituloProposta_Clienteid_Z_SetNull( )
      {
         gxTv_SdtTituloProposta_Clienteid_Z = 0;
         SetDirty("Clienteid_Z");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Clienteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteRazaoSocial_Z" )]
      [  XmlElement( ElementName = "ClienteRazaoSocial_Z"   )]
      public string gxTpr_Clienterazaosocial_Z
      {
         get {
            return gxTv_SdtTituloProposta_Clienterazaosocial_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Clienterazaosocial_Z = value;
            SetDirty("Clienterazaosocial_Z");
         }

      }

      public void gxTv_SdtTituloProposta_Clienterazaosocial_Z_SetNull( )
      {
         gxTv_SdtTituloProposta_Clienterazaosocial_Z = "";
         SetDirty("Clienterazaosocial_Z");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Clienterazaosocial_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloValor_Z" )]
      [  XmlElement( ElementName = "TituloValor_Z"   )]
      public decimal gxTpr_Titulovalor_Z
      {
         get {
            return gxTv_SdtTituloProposta_Titulovalor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulovalor_Z = value;
            SetDirty("Titulovalor_Z");
         }

      }

      public void gxTv_SdtTituloProposta_Titulovalor_Z_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulovalor_Z = 0;
         SetDirty("Titulovalor_Z");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulovalor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloDesconto_Z" )]
      [  XmlElement( ElementName = "TituloDesconto_Z"   )]
      public decimal gxTpr_Titulodesconto_Z
      {
         get {
            return gxTv_SdtTituloProposta_Titulodesconto_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulodesconto_Z = value;
            SetDirty("Titulodesconto_Z");
         }

      }

      public void gxTv_SdtTituloProposta_Titulodesconto_Z_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulodesconto_Z = 0;
         SetDirty("Titulodesconto_Z");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulodesconto_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloDeleted_Z" )]
      [  XmlElement( ElementName = "TituloDeleted_Z"   )]
      public bool gxTpr_Titulodeleted_Z
      {
         get {
            return gxTv_SdtTituloProposta_Titulodeleted_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulodeleted_Z = value;
            SetDirty("Titulodeleted_Z");
         }

      }

      public void gxTv_SdtTituloProposta_Titulodeleted_Z_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulodeleted_Z = false;
         SetDirty("Titulodeleted_Z");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulodeleted_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloArchived_Z" )]
      [  XmlElement( ElementName = "TituloArchived_Z"   )]
      public bool gxTpr_Tituloarchived_Z
      {
         get {
            return gxTv_SdtTituloProposta_Tituloarchived_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Tituloarchived_Z = value;
            SetDirty("Tituloarchived_Z");
         }

      }

      public void gxTv_SdtTituloProposta_Tituloarchived_Z_SetNull( )
      {
         gxTv_SdtTituloProposta_Tituloarchived_Z = false;
         SetDirty("Tituloarchived_Z");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Tituloarchived_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloVencimento_Z" )]
      [  XmlElement( ElementName = "TituloVencimento_Z"  , IsNullable=true )]
      public string gxTpr_Titulovencimento_Z_Nullable
      {
         get {
            if ( gxTv_SdtTituloProposta_Titulovencimento_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtTituloProposta_Titulovencimento_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtTituloProposta_Titulovencimento_Z = DateTime.MinValue;
            else
               gxTv_SdtTituloProposta_Titulovencimento_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Titulovencimento_Z
      {
         get {
            return gxTv_SdtTituloProposta_Titulovencimento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulovencimento_Z = value;
            SetDirty("Titulovencimento_Z");
         }

      }

      public void gxTv_SdtTituloProposta_Titulovencimento_Z_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulovencimento_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Titulovencimento_Z");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulovencimento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloCompetenciaAno_Z" )]
      [  XmlElement( ElementName = "TituloCompetenciaAno_Z"   )]
      public short gxTpr_Titulocompetenciaano_Z
      {
         get {
            return gxTv_SdtTituloProposta_Titulocompetenciaano_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulocompetenciaano_Z = value;
            SetDirty("Titulocompetenciaano_Z");
         }

      }

      public void gxTv_SdtTituloProposta_Titulocompetenciaano_Z_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulocompetenciaano_Z = 0;
         SetDirty("Titulocompetenciaano_Z");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulocompetenciaano_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloCompetenciaMes_Z" )]
      [  XmlElement( ElementName = "TituloCompetenciaMes_Z"   )]
      public short gxTpr_Titulocompetenciames_Z
      {
         get {
            return gxTv_SdtTituloProposta_Titulocompetenciames_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulocompetenciames_Z = value;
            SetDirty("Titulocompetenciames_Z");
         }

      }

      public void gxTv_SdtTituloProposta_Titulocompetenciames_Z_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulocompetenciames_Z = 0;
         SetDirty("Titulocompetenciames_Z");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulocompetenciames_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloCompetencia_F_Z" )]
      [  XmlElement( ElementName = "TituloCompetencia_F_Z"   )]
      public string gxTpr_Titulocompetencia_f_Z
      {
         get {
            return gxTv_SdtTituloProposta_Titulocompetencia_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulocompetencia_f_Z = value;
            SetDirty("Titulocompetencia_f_Z");
         }

      }

      public void gxTv_SdtTituloProposta_Titulocompetencia_f_Z_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulocompetencia_f_Z = "";
         SetDirty("Titulocompetencia_f_Z");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulocompetencia_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloProrrogacao_Z" )]
      [  XmlElement( ElementName = "TituloProrrogacao_Z"  , IsNullable=true )]
      public string gxTpr_Tituloprorrogacao_Z_Nullable
      {
         get {
            if ( gxTv_SdtTituloProposta_Tituloprorrogacao_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtTituloProposta_Tituloprorrogacao_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtTituloProposta_Tituloprorrogacao_Z = DateTime.MinValue;
            else
               gxTv_SdtTituloProposta_Tituloprorrogacao_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Tituloprorrogacao_Z
      {
         get {
            return gxTv_SdtTituloProposta_Tituloprorrogacao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Tituloprorrogacao_Z = value;
            SetDirty("Tituloprorrogacao_Z");
         }

      }

      public void gxTv_SdtTituloProposta_Tituloprorrogacao_Z_SetNull( )
      {
         gxTv_SdtTituloProposta_Tituloprorrogacao_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Tituloprorrogacao_Z");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Tituloprorrogacao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloCEP_Z" )]
      [  XmlElement( ElementName = "TituloCEP_Z"   )]
      public string gxTpr_Titulocep_Z
      {
         get {
            return gxTv_SdtTituloProposta_Titulocep_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulocep_Z = value;
            SetDirty("Titulocep_Z");
         }

      }

      public void gxTv_SdtTituloProposta_Titulocep_Z_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulocep_Z = "";
         SetDirty("Titulocep_Z");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulocep_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloLogradouro_Z" )]
      [  XmlElement( ElementName = "TituloLogradouro_Z"   )]
      public string gxTpr_Titulologradouro_Z
      {
         get {
            return gxTv_SdtTituloProposta_Titulologradouro_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulologradouro_Z = value;
            SetDirty("Titulologradouro_Z");
         }

      }

      public void gxTv_SdtTituloProposta_Titulologradouro_Z_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulologradouro_Z = "";
         SetDirty("Titulologradouro_Z");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulologradouro_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloNumeroEndereco_Z" )]
      [  XmlElement( ElementName = "TituloNumeroEndereco_Z"   )]
      public string gxTpr_Titulonumeroendereco_Z
      {
         get {
            return gxTv_SdtTituloProposta_Titulonumeroendereco_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulonumeroendereco_Z = value;
            SetDirty("Titulonumeroendereco_Z");
         }

      }

      public void gxTv_SdtTituloProposta_Titulonumeroendereco_Z_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulonumeroendereco_Z = "";
         SetDirty("Titulonumeroendereco_Z");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulonumeroendereco_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloComplemento_Z" )]
      [  XmlElement( ElementName = "TituloComplemento_Z"   )]
      public string gxTpr_Titulocomplemento_Z
      {
         get {
            return gxTv_SdtTituloProposta_Titulocomplemento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulocomplemento_Z = value;
            SetDirty("Titulocomplemento_Z");
         }

      }

      public void gxTv_SdtTituloProposta_Titulocomplemento_Z_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulocomplemento_Z = "";
         SetDirty("Titulocomplemento_Z");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulocomplemento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloBairro_Z" )]
      [  XmlElement( ElementName = "TituloBairro_Z"   )]
      public string gxTpr_Titulobairro_Z
      {
         get {
            return gxTv_SdtTituloProposta_Titulobairro_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulobairro_Z = value;
            SetDirty("Titulobairro_Z");
         }

      }

      public void gxTv_SdtTituloProposta_Titulobairro_Z_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulobairro_Z = "";
         SetDirty("Titulobairro_Z");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulobairro_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloMunicipio_Z" )]
      [  XmlElement( ElementName = "TituloMunicipio_Z"   )]
      public string gxTpr_Titulomunicipio_Z
      {
         get {
            return gxTv_SdtTituloProposta_Titulomunicipio_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulomunicipio_Z = value;
            SetDirty("Titulomunicipio_Z");
         }

      }

      public void gxTv_SdtTituloProposta_Titulomunicipio_Z_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulomunicipio_Z = "";
         SetDirty("Titulomunicipio_Z");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulomunicipio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloJurosMora_Z" )]
      [  XmlElement( ElementName = "TituloJurosMora_Z"   )]
      public decimal gxTpr_Titulojurosmora_Z
      {
         get {
            return gxTv_SdtTituloProposta_Titulojurosmora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulojurosmora_Z = value;
            SetDirty("Titulojurosmora_Z");
         }

      }

      public void gxTv_SdtTituloProposta_Titulojurosmora_Z_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulojurosmora_Z = 0;
         SetDirty("Titulojurosmora_Z");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulojurosmora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloTipo_Z" )]
      [  XmlElement( ElementName = "TituloTipo_Z"   )]
      public string gxTpr_Titulotipo_Z
      {
         get {
            return gxTv_SdtTituloProposta_Titulotipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulotipo_Z = value;
            SetDirty("Titulotipo_Z");
         }

      }

      public void gxTv_SdtTituloProposta_Titulotipo_Z_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulotipo_Z = "";
         SetDirty("Titulotipo_Z");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulotipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloPropostaId_Z" )]
      [  XmlElement( ElementName = "TituloPropostaId_Z"   )]
      public int gxTpr_Titulopropostaid_Z
      {
         get {
            return gxTv_SdtTituloProposta_Titulopropostaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulopropostaid_Z = value;
            SetDirty("Titulopropostaid_Z");
         }

      }

      public void gxTv_SdtTituloProposta_Titulopropostaid_Z_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulopropostaid_Z = 0;
         SetDirty("Titulopropostaid_Z");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulopropostaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaTaxaAdministrativa_Z" )]
      [  XmlElement( ElementName = "PropostaTaxaAdministrativa_Z"   )]
      public decimal gxTpr_Propostataxaadministrativa_Z
      {
         get {
            return gxTv_SdtTituloProposta_Propostataxaadministrativa_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Propostataxaadministrativa_Z = value;
            SetDirty("Propostataxaadministrativa_Z");
         }

      }

      public void gxTv_SdtTituloProposta_Propostataxaadministrativa_Z_SetNull( )
      {
         gxTv_SdtTituloProposta_Propostataxaadministrativa_Z = 0;
         SetDirty("Propostataxaadministrativa_Z");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Propostataxaadministrativa_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaId_Z" )]
      [  XmlElement( ElementName = "ContaId_Z"   )]
      public int gxTpr_Contaid_Z
      {
         get {
            return gxTv_SdtTituloProposta_Contaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Contaid_Z = value;
            SetDirty("Contaid_Z");
         }

      }

      public void gxTv_SdtTituloProposta_Contaid_Z_SetNull( )
      {
         gxTv_SdtTituloProposta_Contaid_Z = 0;
         SetDirty("Contaid_Z");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Contaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloCriacao_Z" )]
      [  XmlElement( ElementName = "TituloCriacao_Z"  , IsNullable=true )]
      public string gxTpr_Titulocriacao_Z_Nullable
      {
         get {
            if ( gxTv_SdtTituloProposta_Titulocriacao_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTituloProposta_Titulocriacao_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTituloProposta_Titulocriacao_Z = DateTime.MinValue;
            else
               gxTv_SdtTituloProposta_Titulocriacao_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Titulocriacao_Z
      {
         get {
            return gxTv_SdtTituloProposta_Titulocriacao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulocriacao_Z = value;
            SetDirty("Titulocriacao_Z");
         }

      }

      public void gxTv_SdtTituloProposta_Titulocriacao_Z_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulocriacao_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Titulocriacao_Z");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulocriacao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoriaTituloId_Z" )]
      [  XmlElement( ElementName = "CategoriaTituloId_Z"   )]
      public int gxTpr_Categoriatituloid_Z
      {
         get {
            return gxTv_SdtTituloProposta_Categoriatituloid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Categoriatituloid_Z = value;
            SetDirty("Categoriatituloid_Z");
         }

      }

      public void gxTv_SdtTituloProposta_Categoriatituloid_Z_SetNull( )
      {
         gxTv_SdtTituloProposta_Categoriatituloid_Z = 0;
         SetDirty("Categoriatituloid_Z");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Categoriatituloid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloTotalMovimento_F_Z" )]
      [  XmlElement( ElementName = "TituloTotalMovimento_F_Z"   )]
      public decimal gxTpr_Titulototalmovimento_f_Z
      {
         get {
            return gxTv_SdtTituloProposta_Titulototalmovimento_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulototalmovimento_f_Z = value;
            SetDirty("Titulototalmovimento_f_Z");
         }

      }

      public void gxTv_SdtTituloProposta_Titulototalmovimento_f_Z_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulototalmovimento_f_Z = 0;
         SetDirty("Titulototalmovimento_f_Z");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulototalmovimento_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloTotalMultaJuros_F_Z" )]
      [  XmlElement( ElementName = "TituloTotalMultaJuros_F_Z"   )]
      public decimal gxTpr_Titulototalmultajuros_f_Z
      {
         get {
            return gxTv_SdtTituloProposta_Titulototalmultajuros_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulototalmultajuros_f_Z = value;
            SetDirty("Titulototalmultajuros_f_Z");
         }

      }

      public void gxTv_SdtTituloProposta_Titulototalmultajuros_f_Z_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulototalmultajuros_f_Z = 0;
         SetDirty("Titulototalmultajuros_f_Z");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulototalmultajuros_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloSaldo_F_Z" )]
      [  XmlElement( ElementName = "TituloSaldo_F_Z"   )]
      public decimal gxTpr_Titulosaldo_f_Z
      {
         get {
            return gxTv_SdtTituloProposta_Titulosaldo_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulosaldo_f_Z = value;
            SetDirty("Titulosaldo_f_Z");
         }

      }

      public void gxTv_SdtTituloProposta_Titulosaldo_f_Z_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulosaldo_f_Z = 0;
         SetDirty("Titulosaldo_f_Z");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulosaldo_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloStatus_F_Z" )]
      [  XmlElement( ElementName = "TituloStatus_F_Z"   )]
      public string gxTpr_Titulostatus_f_Z
      {
         get {
            return gxTv_SdtTituloProposta_Titulostatus_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulostatus_f_Z = value;
            SetDirty("Titulostatus_f_Z");
         }

      }

      public void gxTv_SdtTituloProposta_Titulostatus_f_Z_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulostatus_f_Z = "";
         SetDirty("Titulostatus_f_Z");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulostatus_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloSaldoDebito_F_Z" )]
      [  XmlElement( ElementName = "TituloSaldoDebito_F_Z"   )]
      public decimal gxTpr_Titulosaldodebito_f_Z
      {
         get {
            return gxTv_SdtTituloProposta_Titulosaldodebito_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulosaldodebito_f_Z = value;
            SetDirty("Titulosaldodebito_f_Z");
         }

      }

      public void gxTv_SdtTituloProposta_Titulosaldodebito_f_Z_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulosaldodebito_f_Z = 0;
         SetDirty("Titulosaldodebito_f_Z");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulosaldodebito_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloSaldoCredito_F_Z" )]
      [  XmlElement( ElementName = "TituloSaldoCredito_F_Z"   )]
      public decimal gxTpr_Titulosaldocredito_f_Z
      {
         get {
            return gxTv_SdtTituloProposta_Titulosaldocredito_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulosaldocredito_f_Z = value;
            SetDirty("Titulosaldocredito_f_Z");
         }

      }

      public void gxTv_SdtTituloProposta_Titulosaldocredito_f_Z_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulosaldocredito_f_Z = 0;
         SetDirty("Titulosaldocredito_f_Z");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulosaldocredito_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloTotalMovimentoDebito_F_Z" )]
      [  XmlElement( ElementName = "TituloTotalMovimentoDebito_F_Z"   )]
      public decimal gxTpr_Titulototalmovimentodebito_f_Z
      {
         get {
            return gxTv_SdtTituloProposta_Titulototalmovimentodebito_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulototalmovimentodebito_f_Z = value;
            SetDirty("Titulototalmovimentodebito_f_Z");
         }

      }

      public void gxTv_SdtTituloProposta_Titulototalmovimentodebito_f_Z_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulototalmovimentodebito_f_Z = 0;
         SetDirty("Titulototalmovimentodebito_f_Z");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulototalmovimentodebito_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloTotalMovimentoCredito_F_Z" )]
      [  XmlElement( ElementName = "TituloTotalMovimentoCredito_F_Z"   )]
      public decimal gxTpr_Titulototalmovimentocredito_f_Z
      {
         get {
            return gxTv_SdtTituloProposta_Titulototalmovimentocredito_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulototalmovimentocredito_f_Z = value;
            SetDirty("Titulototalmovimentocredito_f_Z");
         }

      }

      public void gxTv_SdtTituloProposta_Titulototalmovimentocredito_f_Z_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulototalmovimentocredito_f_Z = 0;
         SetDirty("Titulototalmovimentocredito_f_Z");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulototalmovimentocredito_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloTotalMultaJurosDebito_F_Z" )]
      [  XmlElement( ElementName = "TituloTotalMultaJurosDebito_F_Z"   )]
      public decimal gxTpr_Titulototalmultajurosdebito_f_Z
      {
         get {
            return gxTv_SdtTituloProposta_Titulototalmultajurosdebito_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulototalmultajurosdebito_f_Z = value;
            SetDirty("Titulototalmultajurosdebito_f_Z");
         }

      }

      public void gxTv_SdtTituloProposta_Titulototalmultajurosdebito_f_Z_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulototalmultajurosdebito_f_Z = 0;
         SetDirty("Titulototalmultajurosdebito_f_Z");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulototalmultajurosdebito_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloTotalMultaJurosCredito_F_Z" )]
      [  XmlElement( ElementName = "TituloTotalMultaJurosCredito_F_Z"   )]
      public decimal gxTpr_Titulototalmultajuroscredito_f_Z
      {
         get {
            return gxTv_SdtTituloProposta_Titulototalmultajuroscredito_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulototalmultajuroscredito_f_Z = value;
            SetDirty("Titulototalmultajuroscredito_f_Z");
         }

      }

      public void gxTv_SdtTituloProposta_Titulototalmultajuroscredito_f_Z_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulototalmultajuroscredito_f_Z = 0;
         SetDirty("Titulototalmultajuroscredito_f_Z");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulototalmultajuroscredito_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloId_N" )]
      [  XmlElement( ElementName = "TituloId_N"   )]
      public short gxTpr_Tituloid_N
      {
         get {
            return gxTv_SdtTituloProposta_Tituloid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Tituloid_N = value;
            SetDirty("Tituloid_N");
         }

      }

      public void gxTv_SdtTituloProposta_Tituloid_N_SetNull( )
      {
         gxTv_SdtTituloProposta_Tituloid_N = 0;
         SetDirty("Tituloid_N");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Tituloid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteId_N" )]
      [  XmlElement( ElementName = "ClienteId_N"   )]
      public short gxTpr_Clienteid_N
      {
         get {
            return gxTv_SdtTituloProposta_Clienteid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Clienteid_N = value;
            SetDirty("Clienteid_N");
         }

      }

      public void gxTv_SdtTituloProposta_Clienteid_N_SetNull( )
      {
         gxTv_SdtTituloProposta_Clienteid_N = 0;
         SetDirty("Clienteid_N");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Clienteid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteRazaoSocial_N" )]
      [  XmlElement( ElementName = "ClienteRazaoSocial_N"   )]
      public short gxTpr_Clienterazaosocial_N
      {
         get {
            return gxTv_SdtTituloProposta_Clienterazaosocial_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Clienterazaosocial_N = value;
            SetDirty("Clienterazaosocial_N");
         }

      }

      public void gxTv_SdtTituloProposta_Clienterazaosocial_N_SetNull( )
      {
         gxTv_SdtTituloProposta_Clienterazaosocial_N = 0;
         SetDirty("Clienterazaosocial_N");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Clienterazaosocial_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloValor_N" )]
      [  XmlElement( ElementName = "TituloValor_N"   )]
      public short gxTpr_Titulovalor_N
      {
         get {
            return gxTv_SdtTituloProposta_Titulovalor_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulovalor_N = value;
            SetDirty("Titulovalor_N");
         }

      }

      public void gxTv_SdtTituloProposta_Titulovalor_N_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulovalor_N = 0;
         SetDirty("Titulovalor_N");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulovalor_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloDesconto_N" )]
      [  XmlElement( ElementName = "TituloDesconto_N"   )]
      public short gxTpr_Titulodesconto_N
      {
         get {
            return gxTv_SdtTituloProposta_Titulodesconto_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulodesconto_N = value;
            SetDirty("Titulodesconto_N");
         }

      }

      public void gxTv_SdtTituloProposta_Titulodesconto_N_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulodesconto_N = 0;
         SetDirty("Titulodesconto_N");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulodesconto_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloDeleted_N" )]
      [  XmlElement( ElementName = "TituloDeleted_N"   )]
      public short gxTpr_Titulodeleted_N
      {
         get {
            return gxTv_SdtTituloProposta_Titulodeleted_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulodeleted_N = value;
            SetDirty("Titulodeleted_N");
         }

      }

      public void gxTv_SdtTituloProposta_Titulodeleted_N_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulodeleted_N = 0;
         SetDirty("Titulodeleted_N");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulodeleted_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloArchived_N" )]
      [  XmlElement( ElementName = "TituloArchived_N"   )]
      public short gxTpr_Tituloarchived_N
      {
         get {
            return gxTv_SdtTituloProposta_Tituloarchived_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Tituloarchived_N = value;
            SetDirty("Tituloarchived_N");
         }

      }

      public void gxTv_SdtTituloProposta_Tituloarchived_N_SetNull( )
      {
         gxTv_SdtTituloProposta_Tituloarchived_N = 0;
         SetDirty("Tituloarchived_N");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Tituloarchived_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloVencimento_N" )]
      [  XmlElement( ElementName = "TituloVencimento_N"   )]
      public short gxTpr_Titulovencimento_N
      {
         get {
            return gxTv_SdtTituloProposta_Titulovencimento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulovencimento_N = value;
            SetDirty("Titulovencimento_N");
         }

      }

      public void gxTv_SdtTituloProposta_Titulovencimento_N_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulovencimento_N = 0;
         SetDirty("Titulovencimento_N");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulovencimento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloCompetenciaAno_N" )]
      [  XmlElement( ElementName = "TituloCompetenciaAno_N"   )]
      public short gxTpr_Titulocompetenciaano_N
      {
         get {
            return gxTv_SdtTituloProposta_Titulocompetenciaano_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulocompetenciaano_N = value;
            SetDirty("Titulocompetenciaano_N");
         }

      }

      public void gxTv_SdtTituloProposta_Titulocompetenciaano_N_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulocompetenciaano_N = 0;
         SetDirty("Titulocompetenciaano_N");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulocompetenciaano_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloCompetenciaMes_N" )]
      [  XmlElement( ElementName = "TituloCompetenciaMes_N"   )]
      public short gxTpr_Titulocompetenciames_N
      {
         get {
            return gxTv_SdtTituloProposta_Titulocompetenciames_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulocompetenciames_N = value;
            SetDirty("Titulocompetenciames_N");
         }

      }

      public void gxTv_SdtTituloProposta_Titulocompetenciames_N_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulocompetenciames_N = 0;
         SetDirty("Titulocompetenciames_N");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulocompetenciames_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloProrrogacao_N" )]
      [  XmlElement( ElementName = "TituloProrrogacao_N"   )]
      public short gxTpr_Tituloprorrogacao_N
      {
         get {
            return gxTv_SdtTituloProposta_Tituloprorrogacao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Tituloprorrogacao_N = value;
            SetDirty("Tituloprorrogacao_N");
         }

      }

      public void gxTv_SdtTituloProposta_Tituloprorrogacao_N_SetNull( )
      {
         gxTv_SdtTituloProposta_Tituloprorrogacao_N = 0;
         SetDirty("Tituloprorrogacao_N");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Tituloprorrogacao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloCEP_N" )]
      [  XmlElement( ElementName = "TituloCEP_N"   )]
      public short gxTpr_Titulocep_N
      {
         get {
            return gxTv_SdtTituloProposta_Titulocep_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulocep_N = value;
            SetDirty("Titulocep_N");
         }

      }

      public void gxTv_SdtTituloProposta_Titulocep_N_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulocep_N = 0;
         SetDirty("Titulocep_N");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulocep_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloLogradouro_N" )]
      [  XmlElement( ElementName = "TituloLogradouro_N"   )]
      public short gxTpr_Titulologradouro_N
      {
         get {
            return gxTv_SdtTituloProposta_Titulologradouro_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulologradouro_N = value;
            SetDirty("Titulologradouro_N");
         }

      }

      public void gxTv_SdtTituloProposta_Titulologradouro_N_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulologradouro_N = 0;
         SetDirty("Titulologradouro_N");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulologradouro_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloNumeroEndereco_N" )]
      [  XmlElement( ElementName = "TituloNumeroEndereco_N"   )]
      public short gxTpr_Titulonumeroendereco_N
      {
         get {
            return gxTv_SdtTituloProposta_Titulonumeroendereco_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulonumeroendereco_N = value;
            SetDirty("Titulonumeroendereco_N");
         }

      }

      public void gxTv_SdtTituloProposta_Titulonumeroendereco_N_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulonumeroendereco_N = 0;
         SetDirty("Titulonumeroendereco_N");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulonumeroendereco_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloComplemento_N" )]
      [  XmlElement( ElementName = "TituloComplemento_N"   )]
      public short gxTpr_Titulocomplemento_N
      {
         get {
            return gxTv_SdtTituloProposta_Titulocomplemento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulocomplemento_N = value;
            SetDirty("Titulocomplemento_N");
         }

      }

      public void gxTv_SdtTituloProposta_Titulocomplemento_N_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulocomplemento_N = 0;
         SetDirty("Titulocomplemento_N");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulocomplemento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloBairro_N" )]
      [  XmlElement( ElementName = "TituloBairro_N"   )]
      public short gxTpr_Titulobairro_N
      {
         get {
            return gxTv_SdtTituloProposta_Titulobairro_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulobairro_N = value;
            SetDirty("Titulobairro_N");
         }

      }

      public void gxTv_SdtTituloProposta_Titulobairro_N_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulobairro_N = 0;
         SetDirty("Titulobairro_N");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulobairro_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloMunicipio_N" )]
      [  XmlElement( ElementName = "TituloMunicipio_N"   )]
      public short gxTpr_Titulomunicipio_N
      {
         get {
            return gxTv_SdtTituloProposta_Titulomunicipio_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulomunicipio_N = value;
            SetDirty("Titulomunicipio_N");
         }

      }

      public void gxTv_SdtTituloProposta_Titulomunicipio_N_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulomunicipio_N = 0;
         SetDirty("Titulomunicipio_N");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulomunicipio_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloJurosMora_N" )]
      [  XmlElement( ElementName = "TituloJurosMora_N"   )]
      public short gxTpr_Titulojurosmora_N
      {
         get {
            return gxTv_SdtTituloProposta_Titulojurosmora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulojurosmora_N = value;
            SetDirty("Titulojurosmora_N");
         }

      }

      public void gxTv_SdtTituloProposta_Titulojurosmora_N_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulojurosmora_N = 0;
         SetDirty("Titulojurosmora_N");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulojurosmora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloTipo_N" )]
      [  XmlElement( ElementName = "TituloTipo_N"   )]
      public short gxTpr_Titulotipo_N
      {
         get {
            return gxTv_SdtTituloProposta_Titulotipo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulotipo_N = value;
            SetDirty("Titulotipo_N");
         }

      }

      public void gxTv_SdtTituloProposta_Titulotipo_N_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulotipo_N = 0;
         SetDirty("Titulotipo_N");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulotipo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloPropostaId_N" )]
      [  XmlElement( ElementName = "TituloPropostaId_N"   )]
      public short gxTpr_Titulopropostaid_N
      {
         get {
            return gxTv_SdtTituloProposta_Titulopropostaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulopropostaid_N = value;
            SetDirty("Titulopropostaid_N");
         }

      }

      public void gxTv_SdtTituloProposta_Titulopropostaid_N_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulopropostaid_N = 0;
         SetDirty("Titulopropostaid_N");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulopropostaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaTaxaAdministrativa_N" )]
      [  XmlElement( ElementName = "PropostaTaxaAdministrativa_N"   )]
      public short gxTpr_Propostataxaadministrativa_N
      {
         get {
            return gxTv_SdtTituloProposta_Propostataxaadministrativa_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Propostataxaadministrativa_N = value;
            SetDirty("Propostataxaadministrativa_N");
         }

      }

      public void gxTv_SdtTituloProposta_Propostataxaadministrativa_N_SetNull( )
      {
         gxTv_SdtTituloProposta_Propostataxaadministrativa_N = 0;
         SetDirty("Propostataxaadministrativa_N");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Propostataxaadministrativa_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaId_N" )]
      [  XmlElement( ElementName = "ContaId_N"   )]
      public short gxTpr_Contaid_N
      {
         get {
            return gxTv_SdtTituloProposta_Contaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Contaid_N = value;
            SetDirty("Contaid_N");
         }

      }

      public void gxTv_SdtTituloProposta_Contaid_N_SetNull( )
      {
         gxTv_SdtTituloProposta_Contaid_N = 0;
         SetDirty("Contaid_N");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Contaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloCriacao_N" )]
      [  XmlElement( ElementName = "TituloCriacao_N"   )]
      public short gxTpr_Titulocriacao_N
      {
         get {
            return gxTv_SdtTituloProposta_Titulocriacao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulocriacao_N = value;
            SetDirty("Titulocriacao_N");
         }

      }

      public void gxTv_SdtTituloProposta_Titulocriacao_N_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulocriacao_N = 0;
         SetDirty("Titulocriacao_N");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulocriacao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoriaTituloId_N" )]
      [  XmlElement( ElementName = "CategoriaTituloId_N"   )]
      public short gxTpr_Categoriatituloid_N
      {
         get {
            return gxTv_SdtTituloProposta_Categoriatituloid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Categoriatituloid_N = value;
            SetDirty("Categoriatituloid_N");
         }

      }

      public void gxTv_SdtTituloProposta_Categoriatituloid_N_SetNull( )
      {
         gxTv_SdtTituloProposta_Categoriatituloid_N = 0;
         SetDirty("Categoriatituloid_N");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Categoriatituloid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloTotalMovimento_F_N" )]
      [  XmlElement( ElementName = "TituloTotalMovimento_F_N"   )]
      public short gxTpr_Titulototalmovimento_f_N
      {
         get {
            return gxTv_SdtTituloProposta_Titulototalmovimento_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulototalmovimento_f_N = value;
            SetDirty("Titulototalmovimento_f_N");
         }

      }

      public void gxTv_SdtTituloProposta_Titulototalmovimento_f_N_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulototalmovimento_f_N = 0;
         SetDirty("Titulototalmovimento_f_N");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulototalmovimento_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloTotalMultaJuros_F_N" )]
      [  XmlElement( ElementName = "TituloTotalMultaJuros_F_N"   )]
      public short gxTpr_Titulototalmultajuros_f_N
      {
         get {
            return gxTv_SdtTituloProposta_Titulototalmultajuros_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloProposta_Titulototalmultajuros_f_N = value;
            SetDirty("Titulototalmultajuros_f_N");
         }

      }

      public void gxTv_SdtTituloProposta_Titulototalmultajuros_f_N_SetNull( )
      {
         gxTv_SdtTituloProposta_Titulototalmultajuros_f_N = 0;
         SetDirty("Titulototalmultajuros_f_N");
         return  ;
      }

      public bool gxTv_SdtTituloProposta_Titulototalmultajuros_f_N_IsNull( )
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
         gxTv_SdtTituloProposta_Clienterazaosocial = "";
         gxTv_SdtTituloProposta_Titulovencimento = DateTime.MinValue;
         gxTv_SdtTituloProposta_Titulocompetencia_f = "";
         gxTv_SdtTituloProposta_Tituloprorrogacao = DateTime.MinValue;
         gxTv_SdtTituloProposta_Titulocep = "";
         gxTv_SdtTituloProposta_Titulologradouro = "";
         gxTv_SdtTituloProposta_Titulonumeroendereco = "";
         gxTv_SdtTituloProposta_Titulocomplemento = "";
         gxTv_SdtTituloProposta_Titulobairro = "";
         gxTv_SdtTituloProposta_Titulomunicipio = "";
         gxTv_SdtTituloProposta_Titulotipo = "";
         gxTv_SdtTituloProposta_Titulocriacao = (DateTime)(DateTime.MinValue);
         gxTv_SdtTituloProposta_Titulostatus_f = "";
         gxTv_SdtTituloProposta_Mode = "";
         gxTv_SdtTituloProposta_Clienterazaosocial_Z = "";
         gxTv_SdtTituloProposta_Titulovencimento_Z = DateTime.MinValue;
         gxTv_SdtTituloProposta_Titulocompetencia_f_Z = "";
         gxTv_SdtTituloProposta_Tituloprorrogacao_Z = DateTime.MinValue;
         gxTv_SdtTituloProposta_Titulocep_Z = "";
         gxTv_SdtTituloProposta_Titulologradouro_Z = "";
         gxTv_SdtTituloProposta_Titulonumeroendereco_Z = "";
         gxTv_SdtTituloProposta_Titulocomplemento_Z = "";
         gxTv_SdtTituloProposta_Titulobairro_Z = "";
         gxTv_SdtTituloProposta_Titulomunicipio_Z = "";
         gxTv_SdtTituloProposta_Titulotipo_Z = "";
         gxTv_SdtTituloProposta_Titulocriacao_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtTituloProposta_Titulostatus_f_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "tituloproposta", "GeneXus.Programs.tituloproposta_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTituloProposta_Titulocompetenciaano ;
      private short gxTv_SdtTituloProposta_Titulocompetenciames ;
      private short gxTv_SdtTituloProposta_Initialized ;
      private short gxTv_SdtTituloProposta_Titulocompetenciaano_Z ;
      private short gxTv_SdtTituloProposta_Titulocompetenciames_Z ;
      private short gxTv_SdtTituloProposta_Tituloid_N ;
      private short gxTv_SdtTituloProposta_Clienteid_N ;
      private short gxTv_SdtTituloProposta_Clienterazaosocial_N ;
      private short gxTv_SdtTituloProposta_Titulovalor_N ;
      private short gxTv_SdtTituloProposta_Titulodesconto_N ;
      private short gxTv_SdtTituloProposta_Titulodeleted_N ;
      private short gxTv_SdtTituloProposta_Tituloarchived_N ;
      private short gxTv_SdtTituloProposta_Titulovencimento_N ;
      private short gxTv_SdtTituloProposta_Titulocompetenciaano_N ;
      private short gxTv_SdtTituloProposta_Titulocompetenciames_N ;
      private short gxTv_SdtTituloProposta_Tituloprorrogacao_N ;
      private short gxTv_SdtTituloProposta_Titulocep_N ;
      private short gxTv_SdtTituloProposta_Titulologradouro_N ;
      private short gxTv_SdtTituloProposta_Titulonumeroendereco_N ;
      private short gxTv_SdtTituloProposta_Titulocomplemento_N ;
      private short gxTv_SdtTituloProposta_Titulobairro_N ;
      private short gxTv_SdtTituloProposta_Titulomunicipio_N ;
      private short gxTv_SdtTituloProposta_Titulojurosmora_N ;
      private short gxTv_SdtTituloProposta_Titulotipo_N ;
      private short gxTv_SdtTituloProposta_Titulopropostaid_N ;
      private short gxTv_SdtTituloProposta_Propostataxaadministrativa_N ;
      private short gxTv_SdtTituloProposta_Contaid_N ;
      private short gxTv_SdtTituloProposta_Titulocriacao_N ;
      private short gxTv_SdtTituloProposta_Categoriatituloid_N ;
      private short gxTv_SdtTituloProposta_Titulototalmovimento_f_N ;
      private short gxTv_SdtTituloProposta_Titulototalmultajuros_f_N ;
      private int gxTv_SdtTituloProposta_Tituloid ;
      private int gxTv_SdtTituloProposta_Clienteid ;
      private int gxTv_SdtTituloProposta_Titulopropostaid ;
      private int gxTv_SdtTituloProposta_Contaid ;
      private int gxTv_SdtTituloProposta_Categoriatituloid ;
      private int gxTv_SdtTituloProposta_Tituloid_Z ;
      private int gxTv_SdtTituloProposta_Clienteid_Z ;
      private int gxTv_SdtTituloProposta_Titulopropostaid_Z ;
      private int gxTv_SdtTituloProposta_Contaid_Z ;
      private int gxTv_SdtTituloProposta_Categoriatituloid_Z ;
      private decimal gxTv_SdtTituloProposta_Titulovalor ;
      private decimal gxTv_SdtTituloProposta_Titulodesconto ;
      private decimal gxTv_SdtTituloProposta_Titulojurosmora ;
      private decimal gxTv_SdtTituloProposta_Propostataxaadministrativa ;
      private decimal gxTv_SdtTituloProposta_Titulototalmovimento_f ;
      private decimal gxTv_SdtTituloProposta_Titulototalmultajuros_f ;
      private decimal gxTv_SdtTituloProposta_Titulosaldo_f ;
      private decimal gxTv_SdtTituloProposta_Titulosaldodebito_f ;
      private decimal gxTv_SdtTituloProposta_Titulosaldocredito_f ;
      private decimal gxTv_SdtTituloProposta_Titulototalmovimentodebito_f ;
      private decimal gxTv_SdtTituloProposta_Titulototalmovimentocredito_f ;
      private decimal gxTv_SdtTituloProposta_Titulototalmultajurosdebito_f ;
      private decimal gxTv_SdtTituloProposta_Titulototalmultajuroscredito_f ;
      private decimal gxTv_SdtTituloProposta_Titulovalor_Z ;
      private decimal gxTv_SdtTituloProposta_Titulodesconto_Z ;
      private decimal gxTv_SdtTituloProposta_Titulojurosmora_Z ;
      private decimal gxTv_SdtTituloProposta_Propostataxaadministrativa_Z ;
      private decimal gxTv_SdtTituloProposta_Titulototalmovimento_f_Z ;
      private decimal gxTv_SdtTituloProposta_Titulototalmultajuros_f_Z ;
      private decimal gxTv_SdtTituloProposta_Titulosaldo_f_Z ;
      private decimal gxTv_SdtTituloProposta_Titulosaldodebito_f_Z ;
      private decimal gxTv_SdtTituloProposta_Titulosaldocredito_f_Z ;
      private decimal gxTv_SdtTituloProposta_Titulototalmovimentodebito_f_Z ;
      private decimal gxTv_SdtTituloProposta_Titulototalmovimentocredito_f_Z ;
      private decimal gxTv_SdtTituloProposta_Titulototalmultajurosdebito_f_Z ;
      private decimal gxTv_SdtTituloProposta_Titulototalmultajuroscredito_f_Z ;
      private string gxTv_SdtTituloProposta_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtTituloProposta_Titulocriacao ;
      private DateTime gxTv_SdtTituloProposta_Titulocriacao_Z ;
      private DateTime datetime_STZ ;
      private DateTime gxTv_SdtTituloProposta_Titulovencimento ;
      private DateTime gxTv_SdtTituloProposta_Tituloprorrogacao ;
      private DateTime gxTv_SdtTituloProposta_Titulovencimento_Z ;
      private DateTime gxTv_SdtTituloProposta_Tituloprorrogacao_Z ;
      private bool gxTv_SdtTituloProposta_Titulodeleted ;
      private bool gxTv_SdtTituloProposta_Tituloarchived ;
      private bool gxTv_SdtTituloProposta_Titulodeleted_Z ;
      private bool gxTv_SdtTituloProposta_Tituloarchived_Z ;
      private string gxTv_SdtTituloProposta_Clienterazaosocial ;
      private string gxTv_SdtTituloProposta_Titulocompetencia_f ;
      private string gxTv_SdtTituloProposta_Titulocep ;
      private string gxTv_SdtTituloProposta_Titulologradouro ;
      private string gxTv_SdtTituloProposta_Titulonumeroendereco ;
      private string gxTv_SdtTituloProposta_Titulocomplemento ;
      private string gxTv_SdtTituloProposta_Titulobairro ;
      private string gxTv_SdtTituloProposta_Titulomunicipio ;
      private string gxTv_SdtTituloProposta_Titulotipo ;
      private string gxTv_SdtTituloProposta_Titulostatus_f ;
      private string gxTv_SdtTituloProposta_Clienterazaosocial_Z ;
      private string gxTv_SdtTituloProposta_Titulocompetencia_f_Z ;
      private string gxTv_SdtTituloProposta_Titulocep_Z ;
      private string gxTv_SdtTituloProposta_Titulologradouro_Z ;
      private string gxTv_SdtTituloProposta_Titulonumeroendereco_Z ;
      private string gxTv_SdtTituloProposta_Titulocomplemento_Z ;
      private string gxTv_SdtTituloProposta_Titulobairro_Z ;
      private string gxTv_SdtTituloProposta_Titulomunicipio_Z ;
      private string gxTv_SdtTituloProposta_Titulotipo_Z ;
      private string gxTv_SdtTituloProposta_Titulostatus_f_Z ;
   }

   [DataContract(Name = @"TituloProposta", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtTituloProposta_RESTInterface : GxGenericCollectionItem<SdtTituloProposta>
   {
      public SdtTituloProposta_RESTInterface( ) : base()
      {
      }

      public SdtTituloProposta_RESTInterface( SdtTituloProposta psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TituloId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Tituloid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Tituloid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Tituloid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
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

      [DataMember( Name = "TituloValor" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Titulovalor
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Titulovalor, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Titulovalor = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "TituloDesconto" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Titulodesconto
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Titulodesconto, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Titulodesconto = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "TituloDeleted" , Order = 5 )]
      [GxSeudo()]
      public bool gxTpr_Titulodeleted
      {
         get {
            return sdt.gxTpr_Titulodeleted ;
         }

         set {
            sdt.gxTpr_Titulodeleted = value;
         }

      }

      [DataMember( Name = "TituloArchived" , Order = 6 )]
      [GxSeudo()]
      public bool gxTpr_Tituloarchived
      {
         get {
            return sdt.gxTpr_Tituloarchived ;
         }

         set {
            sdt.gxTpr_Tituloarchived = value;
         }

      }

      [DataMember( Name = "TituloVencimento" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Titulovencimento
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Titulovencimento) ;
         }

         set {
            sdt.gxTpr_Titulovencimento = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "TituloCompetenciaAno" , Order = 8 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Titulocompetenciaano
      {
         get {
            return sdt.gxTpr_Titulocompetenciaano ;
         }

         set {
            sdt.gxTpr_Titulocompetenciaano = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "TituloCompetenciaMes" , Order = 9 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Titulocompetenciames
      {
         get {
            return sdt.gxTpr_Titulocompetenciames ;
         }

         set {
            sdt.gxTpr_Titulocompetenciames = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "TituloCompetencia_F" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Titulocompetencia_f
      {
         get {
            return sdt.gxTpr_Titulocompetencia_f ;
         }

         set {
            sdt.gxTpr_Titulocompetencia_f = value;
         }

      }

      [DataMember( Name = "TituloProrrogacao" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Tituloprorrogacao
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Tituloprorrogacao) ;
         }

         set {
            sdt.gxTpr_Tituloprorrogacao = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "TituloCEP" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Titulocep
      {
         get {
            return sdt.gxTpr_Titulocep ;
         }

         set {
            sdt.gxTpr_Titulocep = value;
         }

      }

      [DataMember( Name = "TituloLogradouro" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Titulologradouro
      {
         get {
            return sdt.gxTpr_Titulologradouro ;
         }

         set {
            sdt.gxTpr_Titulologradouro = value;
         }

      }

      [DataMember( Name = "TituloNumeroEndereco" , Order = 14 )]
      [GxSeudo()]
      public string gxTpr_Titulonumeroendereco
      {
         get {
            return sdt.gxTpr_Titulonumeroendereco ;
         }

         set {
            sdt.gxTpr_Titulonumeroendereco = value;
         }

      }

      [DataMember( Name = "TituloComplemento" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Titulocomplemento
      {
         get {
            return sdt.gxTpr_Titulocomplemento ;
         }

         set {
            sdt.gxTpr_Titulocomplemento = value;
         }

      }

      [DataMember( Name = "TituloBairro" , Order = 16 )]
      [GxSeudo()]
      public string gxTpr_Titulobairro
      {
         get {
            return sdt.gxTpr_Titulobairro ;
         }

         set {
            sdt.gxTpr_Titulobairro = value;
         }

      }

      [DataMember( Name = "TituloMunicipio" , Order = 17 )]
      [GxSeudo()]
      public string gxTpr_Titulomunicipio
      {
         get {
            return sdt.gxTpr_Titulomunicipio ;
         }

         set {
            sdt.gxTpr_Titulomunicipio = value;
         }

      }

      [DataMember( Name = "TituloJurosMora" , Order = 18 )]
      [GxSeudo()]
      public string gxTpr_Titulojurosmora
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Titulojurosmora, 16, 4)) ;
         }

         set {
            sdt.gxTpr_Titulojurosmora = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "TituloTipo" , Order = 19 )]
      [GxSeudo()]
      public string gxTpr_Titulotipo
      {
         get {
            return sdt.gxTpr_Titulotipo ;
         }

         set {
            sdt.gxTpr_Titulotipo = value;
         }

      }

      [DataMember( Name = "TituloPropostaId" , Order = 20 )]
      [GxSeudo()]
      public string gxTpr_Titulopropostaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Titulopropostaid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Titulopropostaid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "PropostaTaxaAdministrativa" , Order = 21 )]
      [GxSeudo()]
      public string gxTpr_Propostataxaadministrativa
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Propostataxaadministrativa, 16, 4)) ;
         }

         set {
            sdt.gxTpr_Propostataxaadministrativa = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ContaId" , Order = 22 )]
      [GxSeudo()]
      public string gxTpr_Contaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Contaid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Contaid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "TituloCriacao" , Order = 23 )]
      [GxSeudo()]
      public string gxTpr_Titulocriacao
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Titulocriacao, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Titulocriacao = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "CategoriaTituloId" , Order = 24 )]
      [GxSeudo()]
      public string gxTpr_Categoriatituloid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Categoriatituloid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Categoriatituloid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "TituloTotalMovimento_F" , Order = 25 )]
      [GxSeudo()]
      public string gxTpr_Titulototalmovimento_f
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Titulototalmovimento_f, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Titulototalmovimento_f = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "TituloTotalMultaJuros_F" , Order = 26 )]
      [GxSeudo()]
      public string gxTpr_Titulototalmultajuros_f
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Titulototalmultajuros_f, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Titulototalmultajuros_f = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "TituloSaldo_F" , Order = 27 )]
      [GxSeudo()]
      public string gxTpr_Titulosaldo_f
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Titulosaldo_f, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Titulosaldo_f = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "TituloStatus_F" , Order = 28 )]
      [GxSeudo()]
      public string gxTpr_Titulostatus_f
      {
         get {
            return sdt.gxTpr_Titulostatus_f ;
         }

         set {
            sdt.gxTpr_Titulostatus_f = value;
         }

      }

      [DataMember( Name = "TituloSaldoDebito_F" , Order = 29 )]
      [GxSeudo()]
      public string gxTpr_Titulosaldodebito_f
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Titulosaldodebito_f, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Titulosaldodebito_f = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "TituloSaldoCredito_F" , Order = 30 )]
      [GxSeudo()]
      public string gxTpr_Titulosaldocredito_f
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Titulosaldocredito_f, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Titulosaldocredito_f = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "TituloTotalMovimentoDebito_F" , Order = 31 )]
      [GxSeudo()]
      public string gxTpr_Titulototalmovimentodebito_f
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Titulototalmovimentodebito_f, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Titulototalmovimentodebito_f = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "TituloTotalMovimentoCredito_F" , Order = 32 )]
      [GxSeudo()]
      public string gxTpr_Titulototalmovimentocredito_f
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Titulototalmovimentocredito_f, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Titulototalmovimentocredito_f = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "TituloTotalMultaJurosDebito_F" , Order = 33 )]
      [GxSeudo()]
      public string gxTpr_Titulototalmultajurosdebito_f
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Titulototalmultajurosdebito_f, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Titulototalmultajurosdebito_f = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "TituloTotalMultaJurosCredito_F" , Order = 34 )]
      [GxSeudo()]
      public string gxTpr_Titulototalmultajuroscredito_f
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Titulototalmultajuroscredito_f, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Titulototalmultajuroscredito_f = NumberUtil.Val( value, ".");
         }

      }

      public SdtTituloProposta sdt
      {
         get {
            return (SdtTituloProposta)Sdt ;
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
            sdt = new SdtTituloProposta() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 35 )]
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

   [DataContract(Name = @"TituloProposta", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtTituloProposta_RESTLInterface : GxGenericCollectionItem<SdtTituloProposta>
   {
      public SdtTituloProposta_RESTLInterface( ) : base()
      {
      }

      public SdtTituloProposta_RESTLInterface( SdtTituloProposta psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TituloValor" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Titulovalor
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Titulovalor, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Titulovalor = NumberUtil.Val( value, ".");
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

      public SdtTituloProposta sdt
      {
         get {
            return (SdtTituloProposta)Sdt ;
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
            sdt = new SdtTituloProposta() ;
         }
      }

   }

}
