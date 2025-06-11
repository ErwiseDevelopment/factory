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
   [XmlRoot(ElementName = "Titulo" )]
   [XmlType(TypeName =  "Titulo" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtTitulo : GxSilentTrnSdt
   {
      public SdtTitulo( )
      {
      }

      public SdtTitulo( IGxContext context )
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
         metadata.Set("Name", "Titulo");
         metadata.Set("BT", "Titulo");
         metadata.Set("PK", "[ \"TituloId\" ]");
         metadata.Set("PKAssigned", "[ \"TituloId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"CategoriaTituloId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ClienteId\" ],\"FKMap\":[ \"TituloClienteId-ClienteId\" ] },{ \"FK\":[ \"ContaBancariaId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ContaId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"NotaFiscalParcelamentoID\" ],\"FKMap\":[  ] },{ \"FK\":[ \"PropostaId\" ],\"FKMap\":[ \"TituloPropostaId-PropostaId\" ] } ]");
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
         state.Add("gxTpr_Tituloclienteid_Z");
         state.Add("gxTpr_Tituloclienterazaosocial_Z");
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
         state.Add("gxTpr_Titulopropostadescricao_Z");
         state.Add("gxTpr_Propostataxaadministrativa_Z");
         state.Add("gxTpr_Contaid_Z");
         state.Add("gxTpr_Titulocriacao_Z_Nullable");
         state.Add("gxTpr_Categoriatituloid_Z");
         state.Add("gxTpr_Titulodatacredito_f_Z_Nullable");
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
         state.Add("gxTpr_Titulopropostatipo_Z");
         state.Add("gxTpr_Notafiscalparcelamentoid_Z");
         state.Add("gxTpr_Notafiscalnumero_Z");
         state.Add("gxTpr_Contabancariaid_Z");
         state.Add("gxTpr_Agenciabanconome_Z");
         state.Add("gxTpr_Contabancariacarteira_Z");
         state.Add("gxTpr_Contabancarianumero_Z");
         state.Add("gxTpr_Agencianumero_Z");
         state.Add("gxTpr_Titulosemcarteiradecobranca_f_Z");
         state.Add("gxTpr_Tituloscarteiradecobranca_Z");
         state.Add("gxTpr_Tituloid_N");
         state.Add("gxTpr_Tituloclienteid_N");
         state.Add("gxTpr_Tituloclienterazaosocial_N");
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
         state.Add("gxTpr_Titulopropostadescricao_N");
         state.Add("gxTpr_Propostataxaadministrativa_N");
         state.Add("gxTpr_Contaid_N");
         state.Add("gxTpr_Titulocriacao_N");
         state.Add("gxTpr_Categoriatituloid_N");
         state.Add("gxTpr_Titulodatacredito_f_N");
         state.Add("gxTpr_Titulototalmovimento_f_N");
         state.Add("gxTpr_Titulototalmultajuros_f_N");
         state.Add("gxTpr_Titulopropostatipo_N");
         state.Add("gxTpr_Notafiscalparcelamentoid_N");
         state.Add("gxTpr_Notafiscalnumero_N");
         state.Add("gxTpr_Contabancariaid_N");
         state.Add("gxTpr_Agenciabanconome_N");
         state.Add("gxTpr_Contabancariacarteira_N");
         state.Add("gxTpr_Contabancarianumero_N");
         state.Add("gxTpr_Agencianumero_N");
         state.Add("gxTpr_Tituloscarteiradecobranca_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTitulo sdt;
         sdt = (SdtTitulo)(source);
         gxTv_SdtTitulo_Tituloid = sdt.gxTv_SdtTitulo_Tituloid ;
         gxTv_SdtTitulo_Tituloclienteid = sdt.gxTv_SdtTitulo_Tituloclienteid ;
         gxTv_SdtTitulo_Tituloclienterazaosocial = sdt.gxTv_SdtTitulo_Tituloclienterazaosocial ;
         gxTv_SdtTitulo_Titulovalor = sdt.gxTv_SdtTitulo_Titulovalor ;
         gxTv_SdtTitulo_Titulodesconto = sdt.gxTv_SdtTitulo_Titulodesconto ;
         gxTv_SdtTitulo_Titulodeleted = sdt.gxTv_SdtTitulo_Titulodeleted ;
         gxTv_SdtTitulo_Tituloarchived = sdt.gxTv_SdtTitulo_Tituloarchived ;
         gxTv_SdtTitulo_Titulovencimento = sdt.gxTv_SdtTitulo_Titulovencimento ;
         gxTv_SdtTitulo_Titulocompetenciaano = sdt.gxTv_SdtTitulo_Titulocompetenciaano ;
         gxTv_SdtTitulo_Titulocompetenciames = sdt.gxTv_SdtTitulo_Titulocompetenciames ;
         gxTv_SdtTitulo_Titulocompetencia_f = sdt.gxTv_SdtTitulo_Titulocompetencia_f ;
         gxTv_SdtTitulo_Tituloprorrogacao = sdt.gxTv_SdtTitulo_Tituloprorrogacao ;
         gxTv_SdtTitulo_Titulocep = sdt.gxTv_SdtTitulo_Titulocep ;
         gxTv_SdtTitulo_Titulologradouro = sdt.gxTv_SdtTitulo_Titulologradouro ;
         gxTv_SdtTitulo_Titulonumeroendereco = sdt.gxTv_SdtTitulo_Titulonumeroendereco ;
         gxTv_SdtTitulo_Titulocomplemento = sdt.gxTv_SdtTitulo_Titulocomplemento ;
         gxTv_SdtTitulo_Titulobairro = sdt.gxTv_SdtTitulo_Titulobairro ;
         gxTv_SdtTitulo_Titulomunicipio = sdt.gxTv_SdtTitulo_Titulomunicipio ;
         gxTv_SdtTitulo_Titulojurosmora = sdt.gxTv_SdtTitulo_Titulojurosmora ;
         gxTv_SdtTitulo_Titulotipo = sdt.gxTv_SdtTitulo_Titulotipo ;
         gxTv_SdtTitulo_Titulopropostaid = sdt.gxTv_SdtTitulo_Titulopropostaid ;
         gxTv_SdtTitulo_Titulopropostadescricao = sdt.gxTv_SdtTitulo_Titulopropostadescricao ;
         gxTv_SdtTitulo_Propostataxaadministrativa = sdt.gxTv_SdtTitulo_Propostataxaadministrativa ;
         gxTv_SdtTitulo_Contaid = sdt.gxTv_SdtTitulo_Contaid ;
         gxTv_SdtTitulo_Titulocriacao = sdt.gxTv_SdtTitulo_Titulocriacao ;
         gxTv_SdtTitulo_Categoriatituloid = sdt.gxTv_SdtTitulo_Categoriatituloid ;
         gxTv_SdtTitulo_Titulodatacredito_f = sdt.gxTv_SdtTitulo_Titulodatacredito_f ;
         gxTv_SdtTitulo_Titulototalmovimento_f = sdt.gxTv_SdtTitulo_Titulototalmovimento_f ;
         gxTv_SdtTitulo_Titulototalmultajuros_f = sdt.gxTv_SdtTitulo_Titulototalmultajuros_f ;
         gxTv_SdtTitulo_Titulosaldo_f = sdt.gxTv_SdtTitulo_Titulosaldo_f ;
         gxTv_SdtTitulo_Titulostatus_f = sdt.gxTv_SdtTitulo_Titulostatus_f ;
         gxTv_SdtTitulo_Titulosaldodebito_f = sdt.gxTv_SdtTitulo_Titulosaldodebito_f ;
         gxTv_SdtTitulo_Titulosaldocredito_f = sdt.gxTv_SdtTitulo_Titulosaldocredito_f ;
         gxTv_SdtTitulo_Titulototalmovimentodebito_f = sdt.gxTv_SdtTitulo_Titulototalmovimentodebito_f ;
         gxTv_SdtTitulo_Titulototalmovimentocredito_f = sdt.gxTv_SdtTitulo_Titulototalmovimentocredito_f ;
         gxTv_SdtTitulo_Titulototalmultajurosdebito_f = sdt.gxTv_SdtTitulo_Titulototalmultajurosdebito_f ;
         gxTv_SdtTitulo_Titulototalmultajuroscredito_f = sdt.gxTv_SdtTitulo_Titulototalmultajuroscredito_f ;
         gxTv_SdtTitulo_Titulopropostatipo = sdt.gxTv_SdtTitulo_Titulopropostatipo ;
         gxTv_SdtTitulo_Notafiscalparcelamentoid = sdt.gxTv_SdtTitulo_Notafiscalparcelamentoid ;
         gxTv_SdtTitulo_Notafiscalnumero = sdt.gxTv_SdtTitulo_Notafiscalnumero ;
         gxTv_SdtTitulo_Contabancariaid = sdt.gxTv_SdtTitulo_Contabancariaid ;
         gxTv_SdtTitulo_Agenciabanconome = sdt.gxTv_SdtTitulo_Agenciabanconome ;
         gxTv_SdtTitulo_Contabancariacarteira = sdt.gxTv_SdtTitulo_Contabancariacarteira ;
         gxTv_SdtTitulo_Contabancarianumero = sdt.gxTv_SdtTitulo_Contabancarianumero ;
         gxTv_SdtTitulo_Agencianumero = sdt.gxTv_SdtTitulo_Agencianumero ;
         gxTv_SdtTitulo_Titulosemcarteiradecobranca_f = sdt.gxTv_SdtTitulo_Titulosemcarteiradecobranca_f ;
         gxTv_SdtTitulo_Tituloscarteiradecobranca = sdt.gxTv_SdtTitulo_Tituloscarteiradecobranca ;
         gxTv_SdtTitulo_Mode = sdt.gxTv_SdtTitulo_Mode ;
         gxTv_SdtTitulo_Initialized = sdt.gxTv_SdtTitulo_Initialized ;
         gxTv_SdtTitulo_Tituloid_Z = sdt.gxTv_SdtTitulo_Tituloid_Z ;
         gxTv_SdtTitulo_Tituloclienteid_Z = sdt.gxTv_SdtTitulo_Tituloclienteid_Z ;
         gxTv_SdtTitulo_Tituloclienterazaosocial_Z = sdt.gxTv_SdtTitulo_Tituloclienterazaosocial_Z ;
         gxTv_SdtTitulo_Titulovalor_Z = sdt.gxTv_SdtTitulo_Titulovalor_Z ;
         gxTv_SdtTitulo_Titulodesconto_Z = sdt.gxTv_SdtTitulo_Titulodesconto_Z ;
         gxTv_SdtTitulo_Titulodeleted_Z = sdt.gxTv_SdtTitulo_Titulodeleted_Z ;
         gxTv_SdtTitulo_Tituloarchived_Z = sdt.gxTv_SdtTitulo_Tituloarchived_Z ;
         gxTv_SdtTitulo_Titulovencimento_Z = sdt.gxTv_SdtTitulo_Titulovencimento_Z ;
         gxTv_SdtTitulo_Titulocompetenciaano_Z = sdt.gxTv_SdtTitulo_Titulocompetenciaano_Z ;
         gxTv_SdtTitulo_Titulocompetenciames_Z = sdt.gxTv_SdtTitulo_Titulocompetenciames_Z ;
         gxTv_SdtTitulo_Titulocompetencia_f_Z = sdt.gxTv_SdtTitulo_Titulocompetencia_f_Z ;
         gxTv_SdtTitulo_Tituloprorrogacao_Z = sdt.gxTv_SdtTitulo_Tituloprorrogacao_Z ;
         gxTv_SdtTitulo_Titulocep_Z = sdt.gxTv_SdtTitulo_Titulocep_Z ;
         gxTv_SdtTitulo_Titulologradouro_Z = sdt.gxTv_SdtTitulo_Titulologradouro_Z ;
         gxTv_SdtTitulo_Titulonumeroendereco_Z = sdt.gxTv_SdtTitulo_Titulonumeroendereco_Z ;
         gxTv_SdtTitulo_Titulocomplemento_Z = sdt.gxTv_SdtTitulo_Titulocomplemento_Z ;
         gxTv_SdtTitulo_Titulobairro_Z = sdt.gxTv_SdtTitulo_Titulobairro_Z ;
         gxTv_SdtTitulo_Titulomunicipio_Z = sdt.gxTv_SdtTitulo_Titulomunicipio_Z ;
         gxTv_SdtTitulo_Titulojurosmora_Z = sdt.gxTv_SdtTitulo_Titulojurosmora_Z ;
         gxTv_SdtTitulo_Titulotipo_Z = sdt.gxTv_SdtTitulo_Titulotipo_Z ;
         gxTv_SdtTitulo_Titulopropostaid_Z = sdt.gxTv_SdtTitulo_Titulopropostaid_Z ;
         gxTv_SdtTitulo_Titulopropostadescricao_Z = sdt.gxTv_SdtTitulo_Titulopropostadescricao_Z ;
         gxTv_SdtTitulo_Propostataxaadministrativa_Z = sdt.gxTv_SdtTitulo_Propostataxaadministrativa_Z ;
         gxTv_SdtTitulo_Contaid_Z = sdt.gxTv_SdtTitulo_Contaid_Z ;
         gxTv_SdtTitulo_Titulocriacao_Z = sdt.gxTv_SdtTitulo_Titulocriacao_Z ;
         gxTv_SdtTitulo_Categoriatituloid_Z = sdt.gxTv_SdtTitulo_Categoriatituloid_Z ;
         gxTv_SdtTitulo_Titulodatacredito_f_Z = sdt.gxTv_SdtTitulo_Titulodatacredito_f_Z ;
         gxTv_SdtTitulo_Titulototalmovimento_f_Z = sdt.gxTv_SdtTitulo_Titulototalmovimento_f_Z ;
         gxTv_SdtTitulo_Titulototalmultajuros_f_Z = sdt.gxTv_SdtTitulo_Titulototalmultajuros_f_Z ;
         gxTv_SdtTitulo_Titulosaldo_f_Z = sdt.gxTv_SdtTitulo_Titulosaldo_f_Z ;
         gxTv_SdtTitulo_Titulostatus_f_Z = sdt.gxTv_SdtTitulo_Titulostatus_f_Z ;
         gxTv_SdtTitulo_Titulosaldodebito_f_Z = sdt.gxTv_SdtTitulo_Titulosaldodebito_f_Z ;
         gxTv_SdtTitulo_Titulosaldocredito_f_Z = sdt.gxTv_SdtTitulo_Titulosaldocredito_f_Z ;
         gxTv_SdtTitulo_Titulototalmovimentodebito_f_Z = sdt.gxTv_SdtTitulo_Titulototalmovimentodebito_f_Z ;
         gxTv_SdtTitulo_Titulototalmovimentocredito_f_Z = sdt.gxTv_SdtTitulo_Titulototalmovimentocredito_f_Z ;
         gxTv_SdtTitulo_Titulototalmultajurosdebito_f_Z = sdt.gxTv_SdtTitulo_Titulototalmultajurosdebito_f_Z ;
         gxTv_SdtTitulo_Titulototalmultajuroscredito_f_Z = sdt.gxTv_SdtTitulo_Titulototalmultajuroscredito_f_Z ;
         gxTv_SdtTitulo_Titulopropostatipo_Z = sdt.gxTv_SdtTitulo_Titulopropostatipo_Z ;
         gxTv_SdtTitulo_Notafiscalparcelamentoid_Z = sdt.gxTv_SdtTitulo_Notafiscalparcelamentoid_Z ;
         gxTv_SdtTitulo_Notafiscalnumero_Z = sdt.gxTv_SdtTitulo_Notafiscalnumero_Z ;
         gxTv_SdtTitulo_Contabancariaid_Z = sdt.gxTv_SdtTitulo_Contabancariaid_Z ;
         gxTv_SdtTitulo_Agenciabanconome_Z = sdt.gxTv_SdtTitulo_Agenciabanconome_Z ;
         gxTv_SdtTitulo_Contabancariacarteira_Z = sdt.gxTv_SdtTitulo_Contabancariacarteira_Z ;
         gxTv_SdtTitulo_Contabancarianumero_Z = sdt.gxTv_SdtTitulo_Contabancarianumero_Z ;
         gxTv_SdtTitulo_Agencianumero_Z = sdt.gxTv_SdtTitulo_Agencianumero_Z ;
         gxTv_SdtTitulo_Titulosemcarteiradecobranca_f_Z = sdt.gxTv_SdtTitulo_Titulosemcarteiradecobranca_f_Z ;
         gxTv_SdtTitulo_Tituloscarteiradecobranca_Z = sdt.gxTv_SdtTitulo_Tituloscarteiradecobranca_Z ;
         gxTv_SdtTitulo_Tituloid_N = sdt.gxTv_SdtTitulo_Tituloid_N ;
         gxTv_SdtTitulo_Tituloclienteid_N = sdt.gxTv_SdtTitulo_Tituloclienteid_N ;
         gxTv_SdtTitulo_Tituloclienterazaosocial_N = sdt.gxTv_SdtTitulo_Tituloclienterazaosocial_N ;
         gxTv_SdtTitulo_Titulovalor_N = sdt.gxTv_SdtTitulo_Titulovalor_N ;
         gxTv_SdtTitulo_Titulodesconto_N = sdt.gxTv_SdtTitulo_Titulodesconto_N ;
         gxTv_SdtTitulo_Titulodeleted_N = sdt.gxTv_SdtTitulo_Titulodeleted_N ;
         gxTv_SdtTitulo_Tituloarchived_N = sdt.gxTv_SdtTitulo_Tituloarchived_N ;
         gxTv_SdtTitulo_Titulovencimento_N = sdt.gxTv_SdtTitulo_Titulovencimento_N ;
         gxTv_SdtTitulo_Titulocompetenciaano_N = sdt.gxTv_SdtTitulo_Titulocompetenciaano_N ;
         gxTv_SdtTitulo_Titulocompetenciames_N = sdt.gxTv_SdtTitulo_Titulocompetenciames_N ;
         gxTv_SdtTitulo_Tituloprorrogacao_N = sdt.gxTv_SdtTitulo_Tituloprorrogacao_N ;
         gxTv_SdtTitulo_Titulocep_N = sdt.gxTv_SdtTitulo_Titulocep_N ;
         gxTv_SdtTitulo_Titulologradouro_N = sdt.gxTv_SdtTitulo_Titulologradouro_N ;
         gxTv_SdtTitulo_Titulonumeroendereco_N = sdt.gxTv_SdtTitulo_Titulonumeroendereco_N ;
         gxTv_SdtTitulo_Titulocomplemento_N = sdt.gxTv_SdtTitulo_Titulocomplemento_N ;
         gxTv_SdtTitulo_Titulobairro_N = sdt.gxTv_SdtTitulo_Titulobairro_N ;
         gxTv_SdtTitulo_Titulomunicipio_N = sdt.gxTv_SdtTitulo_Titulomunicipio_N ;
         gxTv_SdtTitulo_Titulojurosmora_N = sdt.gxTv_SdtTitulo_Titulojurosmora_N ;
         gxTv_SdtTitulo_Titulotipo_N = sdt.gxTv_SdtTitulo_Titulotipo_N ;
         gxTv_SdtTitulo_Titulopropostaid_N = sdt.gxTv_SdtTitulo_Titulopropostaid_N ;
         gxTv_SdtTitulo_Titulopropostadescricao_N = sdt.gxTv_SdtTitulo_Titulopropostadescricao_N ;
         gxTv_SdtTitulo_Propostataxaadministrativa_N = sdt.gxTv_SdtTitulo_Propostataxaadministrativa_N ;
         gxTv_SdtTitulo_Contaid_N = sdt.gxTv_SdtTitulo_Contaid_N ;
         gxTv_SdtTitulo_Titulocriacao_N = sdt.gxTv_SdtTitulo_Titulocriacao_N ;
         gxTv_SdtTitulo_Categoriatituloid_N = sdt.gxTv_SdtTitulo_Categoriatituloid_N ;
         gxTv_SdtTitulo_Titulodatacredito_f_N = sdt.gxTv_SdtTitulo_Titulodatacredito_f_N ;
         gxTv_SdtTitulo_Titulototalmovimento_f_N = sdt.gxTv_SdtTitulo_Titulototalmovimento_f_N ;
         gxTv_SdtTitulo_Titulototalmultajuros_f_N = sdt.gxTv_SdtTitulo_Titulototalmultajuros_f_N ;
         gxTv_SdtTitulo_Titulopropostatipo_N = sdt.gxTv_SdtTitulo_Titulopropostatipo_N ;
         gxTv_SdtTitulo_Notafiscalparcelamentoid_N = sdt.gxTv_SdtTitulo_Notafiscalparcelamentoid_N ;
         gxTv_SdtTitulo_Notafiscalnumero_N = sdt.gxTv_SdtTitulo_Notafiscalnumero_N ;
         gxTv_SdtTitulo_Contabancariaid_N = sdt.gxTv_SdtTitulo_Contabancariaid_N ;
         gxTv_SdtTitulo_Agenciabanconome_N = sdt.gxTv_SdtTitulo_Agenciabanconome_N ;
         gxTv_SdtTitulo_Contabancariacarteira_N = sdt.gxTv_SdtTitulo_Contabancariacarteira_N ;
         gxTv_SdtTitulo_Contabancarianumero_N = sdt.gxTv_SdtTitulo_Contabancarianumero_N ;
         gxTv_SdtTitulo_Agencianumero_N = sdt.gxTv_SdtTitulo_Agencianumero_N ;
         gxTv_SdtTitulo_Tituloscarteiradecobranca_N = sdt.gxTv_SdtTitulo_Tituloscarteiradecobranca_N ;
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
         AddObjectProperty("TituloId", gxTv_SdtTitulo_Tituloid, false, includeNonInitialized);
         AddObjectProperty("TituloId_N", gxTv_SdtTitulo_Tituloid_N, false, includeNonInitialized);
         AddObjectProperty("TituloClienteId", gxTv_SdtTitulo_Tituloclienteid, false, includeNonInitialized);
         AddObjectProperty("TituloClienteId_N", gxTv_SdtTitulo_Tituloclienteid_N, false, includeNonInitialized);
         AddObjectProperty("TituloCLienteRazaoSocial", gxTv_SdtTitulo_Tituloclienterazaosocial, false, includeNonInitialized);
         AddObjectProperty("TituloCLienteRazaoSocial_N", gxTv_SdtTitulo_Tituloclienterazaosocial_N, false, includeNonInitialized);
         AddObjectProperty("TituloValor", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTitulo_Titulovalor, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("TituloValor_N", gxTv_SdtTitulo_Titulovalor_N, false, includeNonInitialized);
         AddObjectProperty("TituloDesconto", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTitulo_Titulodesconto, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("TituloDesconto_N", gxTv_SdtTitulo_Titulodesconto_N, false, includeNonInitialized);
         AddObjectProperty("TituloDeleted", gxTv_SdtTitulo_Titulodeleted, false, includeNonInitialized);
         AddObjectProperty("TituloDeleted_N", gxTv_SdtTitulo_Titulodeleted_N, false, includeNonInitialized);
         AddObjectProperty("TituloArchived", gxTv_SdtTitulo_Tituloarchived, false, includeNonInitialized);
         AddObjectProperty("TituloArchived_N", gxTv_SdtTitulo_Tituloarchived_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtTitulo_Titulovencimento)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtTitulo_Titulovencimento)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtTitulo_Titulovencimento)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("TituloVencimento", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("TituloVencimento_N", gxTv_SdtTitulo_Titulovencimento_N, false, includeNonInitialized);
         AddObjectProperty("TituloCompetenciaAno", gxTv_SdtTitulo_Titulocompetenciaano, false, includeNonInitialized);
         AddObjectProperty("TituloCompetenciaAno_N", gxTv_SdtTitulo_Titulocompetenciaano_N, false, includeNonInitialized);
         AddObjectProperty("TituloCompetenciaMes", gxTv_SdtTitulo_Titulocompetenciames, false, includeNonInitialized);
         AddObjectProperty("TituloCompetenciaMes_N", gxTv_SdtTitulo_Titulocompetenciames_N, false, includeNonInitialized);
         AddObjectProperty("TituloCompetencia_F", gxTv_SdtTitulo_Titulocompetencia_f, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtTitulo_Tituloprorrogacao)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtTitulo_Tituloprorrogacao)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtTitulo_Tituloprorrogacao)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("TituloProrrogacao", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("TituloProrrogacao_N", gxTv_SdtTitulo_Tituloprorrogacao_N, false, includeNonInitialized);
         AddObjectProperty("TituloCEP", gxTv_SdtTitulo_Titulocep, false, includeNonInitialized);
         AddObjectProperty("TituloCEP_N", gxTv_SdtTitulo_Titulocep_N, false, includeNonInitialized);
         AddObjectProperty("TituloLogradouro", gxTv_SdtTitulo_Titulologradouro, false, includeNonInitialized);
         AddObjectProperty("TituloLogradouro_N", gxTv_SdtTitulo_Titulologradouro_N, false, includeNonInitialized);
         AddObjectProperty("TituloNumeroEndereco", gxTv_SdtTitulo_Titulonumeroendereco, false, includeNonInitialized);
         AddObjectProperty("TituloNumeroEndereco_N", gxTv_SdtTitulo_Titulonumeroendereco_N, false, includeNonInitialized);
         AddObjectProperty("TituloComplemento", gxTv_SdtTitulo_Titulocomplemento, false, includeNonInitialized);
         AddObjectProperty("TituloComplemento_N", gxTv_SdtTitulo_Titulocomplemento_N, false, includeNonInitialized);
         AddObjectProperty("TituloBairro", gxTv_SdtTitulo_Titulobairro, false, includeNonInitialized);
         AddObjectProperty("TituloBairro_N", gxTv_SdtTitulo_Titulobairro_N, false, includeNonInitialized);
         AddObjectProperty("TituloMunicipio", gxTv_SdtTitulo_Titulomunicipio, false, includeNonInitialized);
         AddObjectProperty("TituloMunicipio_N", gxTv_SdtTitulo_Titulomunicipio_N, false, includeNonInitialized);
         AddObjectProperty("TituloJurosMora", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTitulo_Titulojurosmora, 16, 4)), false, includeNonInitialized);
         AddObjectProperty("TituloJurosMora_N", gxTv_SdtTitulo_Titulojurosmora_N, false, includeNonInitialized);
         AddObjectProperty("TituloTipo", gxTv_SdtTitulo_Titulotipo, false, includeNonInitialized);
         AddObjectProperty("TituloTipo_N", gxTv_SdtTitulo_Titulotipo_N, false, includeNonInitialized);
         AddObjectProperty("TituloPropostaId", gxTv_SdtTitulo_Titulopropostaid, false, includeNonInitialized);
         AddObjectProperty("TituloPropostaId_N", gxTv_SdtTitulo_Titulopropostaid_N, false, includeNonInitialized);
         AddObjectProperty("TituloPropostaDescricao", gxTv_SdtTitulo_Titulopropostadescricao, false, includeNonInitialized);
         AddObjectProperty("TituloPropostaDescricao_N", gxTv_SdtTitulo_Titulopropostadescricao_N, false, includeNonInitialized);
         AddObjectProperty("PropostaTaxaAdministrativa", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTitulo_Propostataxaadministrativa, 16, 4)), false, includeNonInitialized);
         AddObjectProperty("PropostaTaxaAdministrativa_N", gxTv_SdtTitulo_Propostataxaadministrativa_N, false, includeNonInitialized);
         AddObjectProperty("ContaId", gxTv_SdtTitulo_Contaid, false, includeNonInitialized);
         AddObjectProperty("ContaId_N", gxTv_SdtTitulo_Contaid_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtTitulo_Titulocriacao;
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
         AddObjectProperty("TituloCriacao_N", gxTv_SdtTitulo_Titulocriacao_N, false, includeNonInitialized);
         AddObjectProperty("CategoriaTituloId", gxTv_SdtTitulo_Categoriatituloid, false, includeNonInitialized);
         AddObjectProperty("CategoriaTituloId_N", gxTv_SdtTitulo_Categoriatituloid_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtTitulo_Titulodatacredito_f)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtTitulo_Titulodatacredito_f)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtTitulo_Titulodatacredito_f)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("TituloDataCredito_F", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("TituloDataCredito_F_N", gxTv_SdtTitulo_Titulodatacredito_f_N, false, includeNonInitialized);
         AddObjectProperty("TituloTotalMovimento_F", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTitulo_Titulototalmovimento_f, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("TituloTotalMovimento_F_N", gxTv_SdtTitulo_Titulototalmovimento_f_N, false, includeNonInitialized);
         AddObjectProperty("TituloTotalMultaJuros_F", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTitulo_Titulototalmultajuros_f, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("TituloTotalMultaJuros_F_N", gxTv_SdtTitulo_Titulototalmultajuros_f_N, false, includeNonInitialized);
         AddObjectProperty("TituloSaldo_F", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTitulo_Titulosaldo_f, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("TituloStatus_F", gxTv_SdtTitulo_Titulostatus_f, false, includeNonInitialized);
         AddObjectProperty("TituloSaldoDebito_F", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTitulo_Titulosaldodebito_f, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("TituloSaldoCredito_F", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTitulo_Titulosaldocredito_f, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("TituloTotalMovimentoDebito_F", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTitulo_Titulototalmovimentodebito_f, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("TituloTotalMovimentoCredito_F", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTitulo_Titulototalmovimentocredito_f, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("TituloTotalMultaJurosDebito_F", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTitulo_Titulototalmultajurosdebito_f, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("TituloTotalMultaJurosCredito_F", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTitulo_Titulototalmultajuroscredito_f, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("TituloPropostaTipo", gxTv_SdtTitulo_Titulopropostatipo, false, includeNonInitialized);
         AddObjectProperty("TituloPropostaTipo_N", gxTv_SdtTitulo_Titulopropostatipo_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalParcelamentoID", gxTv_SdtTitulo_Notafiscalparcelamentoid, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalParcelamentoID_N", gxTv_SdtTitulo_Notafiscalparcelamentoid_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalNumero", gxTv_SdtTitulo_Notafiscalnumero, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalNumero_N", gxTv_SdtTitulo_Notafiscalnumero_N, false, includeNonInitialized);
         AddObjectProperty("ContaBancariaId", gxTv_SdtTitulo_Contabancariaid, false, includeNonInitialized);
         AddObjectProperty("ContaBancariaId_N", gxTv_SdtTitulo_Contabancariaid_N, false, includeNonInitialized);
         AddObjectProperty("AgenciaBancoNome", gxTv_SdtTitulo_Agenciabanconome, false, includeNonInitialized);
         AddObjectProperty("AgenciaBancoNome_N", gxTv_SdtTitulo_Agenciabanconome_N, false, includeNonInitialized);
         AddObjectProperty("ContaBancariaCarteira", gxTv_SdtTitulo_Contabancariacarteira, false, includeNonInitialized);
         AddObjectProperty("ContaBancariaCarteira_N", gxTv_SdtTitulo_Contabancariacarteira_N, false, includeNonInitialized);
         AddObjectProperty("ContaBancariaNumero", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtTitulo_Contabancarianumero), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("ContaBancariaNumero_N", gxTv_SdtTitulo_Contabancarianumero_N, false, includeNonInitialized);
         AddObjectProperty("AgenciaNumero", gxTv_SdtTitulo_Agencianumero, false, includeNonInitialized);
         AddObjectProperty("AgenciaNumero_N", gxTv_SdtTitulo_Agencianumero_N, false, includeNonInitialized);
         AddObjectProperty("TitulosEmCarteiraDeCobranca_F", gxTv_SdtTitulo_Titulosemcarteiradecobranca_f, false, includeNonInitialized);
         AddObjectProperty("TitulosCarteiraDeCobranca", gxTv_SdtTitulo_Tituloscarteiradecobranca, false, includeNonInitialized);
         AddObjectProperty("TitulosCarteiraDeCobranca_N", gxTv_SdtTitulo_Tituloscarteiradecobranca_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTitulo_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTitulo_Initialized, false, includeNonInitialized);
            AddObjectProperty("TituloId_Z", gxTv_SdtTitulo_Tituloid_Z, false, includeNonInitialized);
            AddObjectProperty("TituloClienteId_Z", gxTv_SdtTitulo_Tituloclienteid_Z, false, includeNonInitialized);
            AddObjectProperty("TituloCLienteRazaoSocial_Z", gxTv_SdtTitulo_Tituloclienterazaosocial_Z, false, includeNonInitialized);
            AddObjectProperty("TituloValor_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTitulo_Titulovalor_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("TituloDesconto_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTitulo_Titulodesconto_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("TituloDeleted_Z", gxTv_SdtTitulo_Titulodeleted_Z, false, includeNonInitialized);
            AddObjectProperty("TituloArchived_Z", gxTv_SdtTitulo_Tituloarchived_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtTitulo_Titulovencimento_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtTitulo_Titulovencimento_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtTitulo_Titulovencimento_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("TituloVencimento_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("TituloCompetenciaAno_Z", gxTv_SdtTitulo_Titulocompetenciaano_Z, false, includeNonInitialized);
            AddObjectProperty("TituloCompetenciaMes_Z", gxTv_SdtTitulo_Titulocompetenciames_Z, false, includeNonInitialized);
            AddObjectProperty("TituloCompetencia_F_Z", gxTv_SdtTitulo_Titulocompetencia_f_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtTitulo_Tituloprorrogacao_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtTitulo_Tituloprorrogacao_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtTitulo_Tituloprorrogacao_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("TituloProrrogacao_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("TituloCEP_Z", gxTv_SdtTitulo_Titulocep_Z, false, includeNonInitialized);
            AddObjectProperty("TituloLogradouro_Z", gxTv_SdtTitulo_Titulologradouro_Z, false, includeNonInitialized);
            AddObjectProperty("TituloNumeroEndereco_Z", gxTv_SdtTitulo_Titulonumeroendereco_Z, false, includeNonInitialized);
            AddObjectProperty("TituloComplemento_Z", gxTv_SdtTitulo_Titulocomplemento_Z, false, includeNonInitialized);
            AddObjectProperty("TituloBairro_Z", gxTv_SdtTitulo_Titulobairro_Z, false, includeNonInitialized);
            AddObjectProperty("TituloMunicipio_Z", gxTv_SdtTitulo_Titulomunicipio_Z, false, includeNonInitialized);
            AddObjectProperty("TituloJurosMora_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTitulo_Titulojurosmora_Z, 16, 4)), false, includeNonInitialized);
            AddObjectProperty("TituloTipo_Z", gxTv_SdtTitulo_Titulotipo_Z, false, includeNonInitialized);
            AddObjectProperty("TituloPropostaId_Z", gxTv_SdtTitulo_Titulopropostaid_Z, false, includeNonInitialized);
            AddObjectProperty("TituloPropostaDescricao_Z", gxTv_SdtTitulo_Titulopropostadescricao_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaTaxaAdministrativa_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTitulo_Propostataxaadministrativa_Z, 16, 4)), false, includeNonInitialized);
            AddObjectProperty("ContaId_Z", gxTv_SdtTitulo_Contaid_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtTitulo_Titulocriacao_Z;
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
            AddObjectProperty("CategoriaTituloId_Z", gxTv_SdtTitulo_Categoriatituloid_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtTitulo_Titulodatacredito_f_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtTitulo_Titulodatacredito_f_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtTitulo_Titulodatacredito_f_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("TituloDataCredito_F_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("TituloTotalMovimento_F_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTitulo_Titulototalmovimento_f_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("TituloTotalMultaJuros_F_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTitulo_Titulototalmultajuros_f_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("TituloSaldo_F_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTitulo_Titulosaldo_f_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("TituloStatus_F_Z", gxTv_SdtTitulo_Titulostatus_f_Z, false, includeNonInitialized);
            AddObjectProperty("TituloSaldoDebito_F_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTitulo_Titulosaldodebito_f_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("TituloSaldoCredito_F_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTitulo_Titulosaldocredito_f_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("TituloTotalMovimentoDebito_F_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTitulo_Titulototalmovimentodebito_f_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("TituloTotalMovimentoCredito_F_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTitulo_Titulototalmovimentocredito_f_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("TituloTotalMultaJurosDebito_F_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTitulo_Titulototalmultajurosdebito_f_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("TituloTotalMultaJurosCredito_F_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTitulo_Titulototalmultajuroscredito_f_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("TituloPropostaTipo_Z", gxTv_SdtTitulo_Titulopropostatipo_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalParcelamentoID_Z", gxTv_SdtTitulo_Notafiscalparcelamentoid_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalNumero_Z", gxTv_SdtTitulo_Notafiscalnumero_Z, false, includeNonInitialized);
            AddObjectProperty("ContaBancariaId_Z", gxTv_SdtTitulo_Contabancariaid_Z, false, includeNonInitialized);
            AddObjectProperty("AgenciaBancoNome_Z", gxTv_SdtTitulo_Agenciabanconome_Z, false, includeNonInitialized);
            AddObjectProperty("ContaBancariaCarteira_Z", gxTv_SdtTitulo_Contabancariacarteira_Z, false, includeNonInitialized);
            AddObjectProperty("ContaBancariaNumero_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtTitulo_Contabancarianumero_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("AgenciaNumero_Z", gxTv_SdtTitulo_Agencianumero_Z, false, includeNonInitialized);
            AddObjectProperty("TitulosEmCarteiraDeCobranca_F_Z", gxTv_SdtTitulo_Titulosemcarteiradecobranca_f_Z, false, includeNonInitialized);
            AddObjectProperty("TitulosCarteiraDeCobranca_Z", gxTv_SdtTitulo_Tituloscarteiradecobranca_Z, false, includeNonInitialized);
            AddObjectProperty("TituloId_N", gxTv_SdtTitulo_Tituloid_N, false, includeNonInitialized);
            AddObjectProperty("TituloClienteId_N", gxTv_SdtTitulo_Tituloclienteid_N, false, includeNonInitialized);
            AddObjectProperty("TituloCLienteRazaoSocial_N", gxTv_SdtTitulo_Tituloclienterazaosocial_N, false, includeNonInitialized);
            AddObjectProperty("TituloValor_N", gxTv_SdtTitulo_Titulovalor_N, false, includeNonInitialized);
            AddObjectProperty("TituloDesconto_N", gxTv_SdtTitulo_Titulodesconto_N, false, includeNonInitialized);
            AddObjectProperty("TituloDeleted_N", gxTv_SdtTitulo_Titulodeleted_N, false, includeNonInitialized);
            AddObjectProperty("TituloArchived_N", gxTv_SdtTitulo_Tituloarchived_N, false, includeNonInitialized);
            AddObjectProperty("TituloVencimento_N", gxTv_SdtTitulo_Titulovencimento_N, false, includeNonInitialized);
            AddObjectProperty("TituloCompetenciaAno_N", gxTv_SdtTitulo_Titulocompetenciaano_N, false, includeNonInitialized);
            AddObjectProperty("TituloCompetenciaMes_N", gxTv_SdtTitulo_Titulocompetenciames_N, false, includeNonInitialized);
            AddObjectProperty("TituloProrrogacao_N", gxTv_SdtTitulo_Tituloprorrogacao_N, false, includeNonInitialized);
            AddObjectProperty("TituloCEP_N", gxTv_SdtTitulo_Titulocep_N, false, includeNonInitialized);
            AddObjectProperty("TituloLogradouro_N", gxTv_SdtTitulo_Titulologradouro_N, false, includeNonInitialized);
            AddObjectProperty("TituloNumeroEndereco_N", gxTv_SdtTitulo_Titulonumeroendereco_N, false, includeNonInitialized);
            AddObjectProperty("TituloComplemento_N", gxTv_SdtTitulo_Titulocomplemento_N, false, includeNonInitialized);
            AddObjectProperty("TituloBairro_N", gxTv_SdtTitulo_Titulobairro_N, false, includeNonInitialized);
            AddObjectProperty("TituloMunicipio_N", gxTv_SdtTitulo_Titulomunicipio_N, false, includeNonInitialized);
            AddObjectProperty("TituloJurosMora_N", gxTv_SdtTitulo_Titulojurosmora_N, false, includeNonInitialized);
            AddObjectProperty("TituloTipo_N", gxTv_SdtTitulo_Titulotipo_N, false, includeNonInitialized);
            AddObjectProperty("TituloPropostaId_N", gxTv_SdtTitulo_Titulopropostaid_N, false, includeNonInitialized);
            AddObjectProperty("TituloPropostaDescricao_N", gxTv_SdtTitulo_Titulopropostadescricao_N, false, includeNonInitialized);
            AddObjectProperty("PropostaTaxaAdministrativa_N", gxTv_SdtTitulo_Propostataxaadministrativa_N, false, includeNonInitialized);
            AddObjectProperty("ContaId_N", gxTv_SdtTitulo_Contaid_N, false, includeNonInitialized);
            AddObjectProperty("TituloCriacao_N", gxTv_SdtTitulo_Titulocriacao_N, false, includeNonInitialized);
            AddObjectProperty("CategoriaTituloId_N", gxTv_SdtTitulo_Categoriatituloid_N, false, includeNonInitialized);
            AddObjectProperty("TituloDataCredito_F_N", gxTv_SdtTitulo_Titulodatacredito_f_N, false, includeNonInitialized);
            AddObjectProperty("TituloTotalMovimento_F_N", gxTv_SdtTitulo_Titulototalmovimento_f_N, false, includeNonInitialized);
            AddObjectProperty("TituloTotalMultaJuros_F_N", gxTv_SdtTitulo_Titulototalmultajuros_f_N, false, includeNonInitialized);
            AddObjectProperty("TituloPropostaTipo_N", gxTv_SdtTitulo_Titulopropostatipo_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalParcelamentoID_N", gxTv_SdtTitulo_Notafiscalparcelamentoid_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalNumero_N", gxTv_SdtTitulo_Notafiscalnumero_N, false, includeNonInitialized);
            AddObjectProperty("ContaBancariaId_N", gxTv_SdtTitulo_Contabancariaid_N, false, includeNonInitialized);
            AddObjectProperty("AgenciaBancoNome_N", gxTv_SdtTitulo_Agenciabanconome_N, false, includeNonInitialized);
            AddObjectProperty("ContaBancariaCarteira_N", gxTv_SdtTitulo_Contabancariacarteira_N, false, includeNonInitialized);
            AddObjectProperty("ContaBancariaNumero_N", gxTv_SdtTitulo_Contabancarianumero_N, false, includeNonInitialized);
            AddObjectProperty("AgenciaNumero_N", gxTv_SdtTitulo_Agencianumero_N, false, includeNonInitialized);
            AddObjectProperty("TitulosCarteiraDeCobranca_N", gxTv_SdtTitulo_Tituloscarteiradecobranca_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTitulo sdt )
      {
         if ( sdt.IsDirty("TituloId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Tituloid = sdt.gxTv_SdtTitulo_Tituloid ;
         }
         if ( sdt.IsDirty("TituloClienteId") )
         {
            gxTv_SdtTitulo_Tituloclienteid_N = (short)(sdt.gxTv_SdtTitulo_Tituloclienteid_N);
            sdtIsNull = 0;
            gxTv_SdtTitulo_Tituloclienteid = sdt.gxTv_SdtTitulo_Tituloclienteid ;
         }
         if ( sdt.IsDirty("TituloCLienteRazaoSocial") )
         {
            gxTv_SdtTitulo_Tituloclienterazaosocial_N = (short)(sdt.gxTv_SdtTitulo_Tituloclienterazaosocial_N);
            sdtIsNull = 0;
            gxTv_SdtTitulo_Tituloclienterazaosocial = sdt.gxTv_SdtTitulo_Tituloclienterazaosocial ;
         }
         if ( sdt.IsDirty("TituloValor") )
         {
            gxTv_SdtTitulo_Titulovalor_N = (short)(sdt.gxTv_SdtTitulo_Titulovalor_N);
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulovalor = sdt.gxTv_SdtTitulo_Titulovalor ;
         }
         if ( sdt.IsDirty("TituloDesconto") )
         {
            gxTv_SdtTitulo_Titulodesconto_N = (short)(sdt.gxTv_SdtTitulo_Titulodesconto_N);
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulodesconto = sdt.gxTv_SdtTitulo_Titulodesconto ;
         }
         if ( sdt.IsDirty("TituloDeleted") )
         {
            gxTv_SdtTitulo_Titulodeleted_N = (short)(sdt.gxTv_SdtTitulo_Titulodeleted_N);
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulodeleted = sdt.gxTv_SdtTitulo_Titulodeleted ;
         }
         if ( sdt.IsDirty("TituloArchived") )
         {
            gxTv_SdtTitulo_Tituloarchived_N = (short)(sdt.gxTv_SdtTitulo_Tituloarchived_N);
            sdtIsNull = 0;
            gxTv_SdtTitulo_Tituloarchived = sdt.gxTv_SdtTitulo_Tituloarchived ;
         }
         if ( sdt.IsDirty("TituloVencimento") )
         {
            gxTv_SdtTitulo_Titulovencimento_N = (short)(sdt.gxTv_SdtTitulo_Titulovencimento_N);
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulovencimento = sdt.gxTv_SdtTitulo_Titulovencimento ;
         }
         if ( sdt.IsDirty("TituloCompetenciaAno") )
         {
            gxTv_SdtTitulo_Titulocompetenciaano_N = (short)(sdt.gxTv_SdtTitulo_Titulocompetenciaano_N);
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulocompetenciaano = sdt.gxTv_SdtTitulo_Titulocompetenciaano ;
         }
         if ( sdt.IsDirty("TituloCompetenciaMes") )
         {
            gxTv_SdtTitulo_Titulocompetenciames_N = (short)(sdt.gxTv_SdtTitulo_Titulocompetenciames_N);
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulocompetenciames = sdt.gxTv_SdtTitulo_Titulocompetenciames ;
         }
         if ( sdt.IsDirty("TituloCompetencia_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulocompetencia_f = sdt.gxTv_SdtTitulo_Titulocompetencia_f ;
         }
         if ( sdt.IsDirty("TituloProrrogacao") )
         {
            gxTv_SdtTitulo_Tituloprorrogacao_N = (short)(sdt.gxTv_SdtTitulo_Tituloprorrogacao_N);
            sdtIsNull = 0;
            gxTv_SdtTitulo_Tituloprorrogacao = sdt.gxTv_SdtTitulo_Tituloprorrogacao ;
         }
         if ( sdt.IsDirty("TituloCEP") )
         {
            gxTv_SdtTitulo_Titulocep_N = (short)(sdt.gxTv_SdtTitulo_Titulocep_N);
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulocep = sdt.gxTv_SdtTitulo_Titulocep ;
         }
         if ( sdt.IsDirty("TituloLogradouro") )
         {
            gxTv_SdtTitulo_Titulologradouro_N = (short)(sdt.gxTv_SdtTitulo_Titulologradouro_N);
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulologradouro = sdt.gxTv_SdtTitulo_Titulologradouro ;
         }
         if ( sdt.IsDirty("TituloNumeroEndereco") )
         {
            gxTv_SdtTitulo_Titulonumeroendereco_N = (short)(sdt.gxTv_SdtTitulo_Titulonumeroendereco_N);
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulonumeroendereco = sdt.gxTv_SdtTitulo_Titulonumeroendereco ;
         }
         if ( sdt.IsDirty("TituloComplemento") )
         {
            gxTv_SdtTitulo_Titulocomplemento_N = (short)(sdt.gxTv_SdtTitulo_Titulocomplemento_N);
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulocomplemento = sdt.gxTv_SdtTitulo_Titulocomplemento ;
         }
         if ( sdt.IsDirty("TituloBairro") )
         {
            gxTv_SdtTitulo_Titulobairro_N = (short)(sdt.gxTv_SdtTitulo_Titulobairro_N);
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulobairro = sdt.gxTv_SdtTitulo_Titulobairro ;
         }
         if ( sdt.IsDirty("TituloMunicipio") )
         {
            gxTv_SdtTitulo_Titulomunicipio_N = (short)(sdt.gxTv_SdtTitulo_Titulomunicipio_N);
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulomunicipio = sdt.gxTv_SdtTitulo_Titulomunicipio ;
         }
         if ( sdt.IsDirty("TituloJurosMora") )
         {
            gxTv_SdtTitulo_Titulojurosmora_N = (short)(sdt.gxTv_SdtTitulo_Titulojurosmora_N);
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulojurosmora = sdt.gxTv_SdtTitulo_Titulojurosmora ;
         }
         if ( sdt.IsDirty("TituloTipo") )
         {
            gxTv_SdtTitulo_Titulotipo_N = (short)(sdt.gxTv_SdtTitulo_Titulotipo_N);
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulotipo = sdt.gxTv_SdtTitulo_Titulotipo ;
         }
         if ( sdt.IsDirty("TituloPropostaId") )
         {
            gxTv_SdtTitulo_Titulopropostaid_N = (short)(sdt.gxTv_SdtTitulo_Titulopropostaid_N);
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulopropostaid = sdt.gxTv_SdtTitulo_Titulopropostaid ;
         }
         if ( sdt.IsDirty("TituloPropostaDescricao") )
         {
            gxTv_SdtTitulo_Titulopropostadescricao_N = (short)(sdt.gxTv_SdtTitulo_Titulopropostadescricao_N);
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulopropostadescricao = sdt.gxTv_SdtTitulo_Titulopropostadescricao ;
         }
         if ( sdt.IsDirty("PropostaTaxaAdministrativa") )
         {
            gxTv_SdtTitulo_Propostataxaadministrativa_N = (short)(sdt.gxTv_SdtTitulo_Propostataxaadministrativa_N);
            sdtIsNull = 0;
            gxTv_SdtTitulo_Propostataxaadministrativa = sdt.gxTv_SdtTitulo_Propostataxaadministrativa ;
         }
         if ( sdt.IsDirty("ContaId") )
         {
            gxTv_SdtTitulo_Contaid_N = (short)(sdt.gxTv_SdtTitulo_Contaid_N);
            sdtIsNull = 0;
            gxTv_SdtTitulo_Contaid = sdt.gxTv_SdtTitulo_Contaid ;
         }
         if ( sdt.IsDirty("TituloCriacao") )
         {
            gxTv_SdtTitulo_Titulocriacao_N = (short)(sdt.gxTv_SdtTitulo_Titulocriacao_N);
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulocriacao = sdt.gxTv_SdtTitulo_Titulocriacao ;
         }
         if ( sdt.IsDirty("CategoriaTituloId") )
         {
            gxTv_SdtTitulo_Categoriatituloid_N = (short)(sdt.gxTv_SdtTitulo_Categoriatituloid_N);
            sdtIsNull = 0;
            gxTv_SdtTitulo_Categoriatituloid = sdt.gxTv_SdtTitulo_Categoriatituloid ;
         }
         if ( sdt.IsDirty("TituloDataCredito_F") )
         {
            gxTv_SdtTitulo_Titulodatacredito_f_N = (short)(sdt.gxTv_SdtTitulo_Titulodatacredito_f_N);
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulodatacredito_f = sdt.gxTv_SdtTitulo_Titulodatacredito_f ;
         }
         if ( sdt.IsDirty("TituloTotalMovimento_F") )
         {
            gxTv_SdtTitulo_Titulototalmovimento_f_N = (short)(sdt.gxTv_SdtTitulo_Titulototalmovimento_f_N);
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulototalmovimento_f = sdt.gxTv_SdtTitulo_Titulototalmovimento_f ;
         }
         if ( sdt.IsDirty("TituloTotalMultaJuros_F") )
         {
            gxTv_SdtTitulo_Titulototalmultajuros_f_N = (short)(sdt.gxTv_SdtTitulo_Titulototalmultajuros_f_N);
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulototalmultajuros_f = sdt.gxTv_SdtTitulo_Titulototalmultajuros_f ;
         }
         if ( sdt.IsDirty("TituloSaldo_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulosaldo_f = sdt.gxTv_SdtTitulo_Titulosaldo_f ;
         }
         if ( sdt.IsDirty("TituloStatus_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulostatus_f = sdt.gxTv_SdtTitulo_Titulostatus_f ;
         }
         if ( sdt.IsDirty("TituloSaldoDebito_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulosaldodebito_f = sdt.gxTv_SdtTitulo_Titulosaldodebito_f ;
         }
         if ( sdt.IsDirty("TituloSaldoCredito_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulosaldocredito_f = sdt.gxTv_SdtTitulo_Titulosaldocredito_f ;
         }
         if ( sdt.IsDirty("TituloTotalMovimentoDebito_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulototalmovimentodebito_f = sdt.gxTv_SdtTitulo_Titulototalmovimentodebito_f ;
         }
         if ( sdt.IsDirty("TituloTotalMovimentoCredito_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulototalmovimentocredito_f = sdt.gxTv_SdtTitulo_Titulototalmovimentocredito_f ;
         }
         if ( sdt.IsDirty("TituloTotalMultaJurosDebito_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulototalmultajurosdebito_f = sdt.gxTv_SdtTitulo_Titulototalmultajurosdebito_f ;
         }
         if ( sdt.IsDirty("TituloTotalMultaJurosCredito_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulototalmultajuroscredito_f = sdt.gxTv_SdtTitulo_Titulototalmultajuroscredito_f ;
         }
         if ( sdt.IsDirty("TituloPropostaTipo") )
         {
            gxTv_SdtTitulo_Titulopropostatipo_N = (short)(sdt.gxTv_SdtTitulo_Titulopropostatipo_N);
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulopropostatipo = sdt.gxTv_SdtTitulo_Titulopropostatipo ;
         }
         if ( sdt.IsDirty("NotaFiscalParcelamentoID") )
         {
            gxTv_SdtTitulo_Notafiscalparcelamentoid_N = (short)(sdt.gxTv_SdtTitulo_Notafiscalparcelamentoid_N);
            sdtIsNull = 0;
            gxTv_SdtTitulo_Notafiscalparcelamentoid = sdt.gxTv_SdtTitulo_Notafiscalparcelamentoid ;
         }
         if ( sdt.IsDirty("NotaFiscalNumero") )
         {
            gxTv_SdtTitulo_Notafiscalnumero_N = (short)(sdt.gxTv_SdtTitulo_Notafiscalnumero_N);
            sdtIsNull = 0;
            gxTv_SdtTitulo_Notafiscalnumero = sdt.gxTv_SdtTitulo_Notafiscalnumero ;
         }
         if ( sdt.IsDirty("ContaBancariaId") )
         {
            gxTv_SdtTitulo_Contabancariaid_N = (short)(sdt.gxTv_SdtTitulo_Contabancariaid_N);
            sdtIsNull = 0;
            gxTv_SdtTitulo_Contabancariaid = sdt.gxTv_SdtTitulo_Contabancariaid ;
         }
         if ( sdt.IsDirty("AgenciaBancoNome") )
         {
            gxTv_SdtTitulo_Agenciabanconome_N = (short)(sdt.gxTv_SdtTitulo_Agenciabanconome_N);
            sdtIsNull = 0;
            gxTv_SdtTitulo_Agenciabanconome = sdt.gxTv_SdtTitulo_Agenciabanconome ;
         }
         if ( sdt.IsDirty("ContaBancariaCarteira") )
         {
            gxTv_SdtTitulo_Contabancariacarteira_N = (short)(sdt.gxTv_SdtTitulo_Contabancariacarteira_N);
            sdtIsNull = 0;
            gxTv_SdtTitulo_Contabancariacarteira = sdt.gxTv_SdtTitulo_Contabancariacarteira ;
         }
         if ( sdt.IsDirty("ContaBancariaNumero") )
         {
            gxTv_SdtTitulo_Contabancarianumero_N = (short)(sdt.gxTv_SdtTitulo_Contabancarianumero_N);
            sdtIsNull = 0;
            gxTv_SdtTitulo_Contabancarianumero = sdt.gxTv_SdtTitulo_Contabancarianumero ;
         }
         if ( sdt.IsDirty("AgenciaNumero") )
         {
            gxTv_SdtTitulo_Agencianumero_N = (short)(sdt.gxTv_SdtTitulo_Agencianumero_N);
            sdtIsNull = 0;
            gxTv_SdtTitulo_Agencianumero = sdt.gxTv_SdtTitulo_Agencianumero ;
         }
         if ( sdt.IsDirty("TitulosEmCarteiraDeCobranca_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulosemcarteiradecobranca_f = sdt.gxTv_SdtTitulo_Titulosemcarteiradecobranca_f ;
         }
         if ( sdt.IsDirty("TitulosCarteiraDeCobranca") )
         {
            gxTv_SdtTitulo_Tituloscarteiradecobranca_N = (short)(sdt.gxTv_SdtTitulo_Tituloscarteiradecobranca_N);
            sdtIsNull = 0;
            gxTv_SdtTitulo_Tituloscarteiradecobranca = sdt.gxTv_SdtTitulo_Tituloscarteiradecobranca ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "TituloId" )]
      [  XmlElement( ElementName = "TituloId"   )]
      public int gxTpr_Tituloid
      {
         get {
            return gxTv_SdtTitulo_Tituloid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTitulo_Tituloid != value )
            {
               gxTv_SdtTitulo_Mode = "INS";
               this.gxTv_SdtTitulo_Tituloid_Z_SetNull( );
               this.gxTv_SdtTitulo_Tituloclienteid_Z_SetNull( );
               this.gxTv_SdtTitulo_Tituloclienterazaosocial_Z_SetNull( );
               this.gxTv_SdtTitulo_Titulovalor_Z_SetNull( );
               this.gxTv_SdtTitulo_Titulodesconto_Z_SetNull( );
               this.gxTv_SdtTitulo_Titulodeleted_Z_SetNull( );
               this.gxTv_SdtTitulo_Tituloarchived_Z_SetNull( );
               this.gxTv_SdtTitulo_Titulovencimento_Z_SetNull( );
               this.gxTv_SdtTitulo_Titulocompetenciaano_Z_SetNull( );
               this.gxTv_SdtTitulo_Titulocompetenciames_Z_SetNull( );
               this.gxTv_SdtTitulo_Titulocompetencia_f_Z_SetNull( );
               this.gxTv_SdtTitulo_Tituloprorrogacao_Z_SetNull( );
               this.gxTv_SdtTitulo_Titulocep_Z_SetNull( );
               this.gxTv_SdtTitulo_Titulologradouro_Z_SetNull( );
               this.gxTv_SdtTitulo_Titulonumeroendereco_Z_SetNull( );
               this.gxTv_SdtTitulo_Titulocomplemento_Z_SetNull( );
               this.gxTv_SdtTitulo_Titulobairro_Z_SetNull( );
               this.gxTv_SdtTitulo_Titulomunicipio_Z_SetNull( );
               this.gxTv_SdtTitulo_Titulojurosmora_Z_SetNull( );
               this.gxTv_SdtTitulo_Titulotipo_Z_SetNull( );
               this.gxTv_SdtTitulo_Titulopropostaid_Z_SetNull( );
               this.gxTv_SdtTitulo_Titulopropostadescricao_Z_SetNull( );
               this.gxTv_SdtTitulo_Propostataxaadministrativa_Z_SetNull( );
               this.gxTv_SdtTitulo_Contaid_Z_SetNull( );
               this.gxTv_SdtTitulo_Titulocriacao_Z_SetNull( );
               this.gxTv_SdtTitulo_Categoriatituloid_Z_SetNull( );
               this.gxTv_SdtTitulo_Titulodatacredito_f_Z_SetNull( );
               this.gxTv_SdtTitulo_Titulototalmovimento_f_Z_SetNull( );
               this.gxTv_SdtTitulo_Titulototalmultajuros_f_Z_SetNull( );
               this.gxTv_SdtTitulo_Titulosaldo_f_Z_SetNull( );
               this.gxTv_SdtTitulo_Titulostatus_f_Z_SetNull( );
               this.gxTv_SdtTitulo_Titulosaldodebito_f_Z_SetNull( );
               this.gxTv_SdtTitulo_Titulosaldocredito_f_Z_SetNull( );
               this.gxTv_SdtTitulo_Titulototalmovimentodebito_f_Z_SetNull( );
               this.gxTv_SdtTitulo_Titulototalmovimentocredito_f_Z_SetNull( );
               this.gxTv_SdtTitulo_Titulototalmultajurosdebito_f_Z_SetNull( );
               this.gxTv_SdtTitulo_Titulototalmultajuroscredito_f_Z_SetNull( );
               this.gxTv_SdtTitulo_Titulopropostatipo_Z_SetNull( );
               this.gxTv_SdtTitulo_Notafiscalparcelamentoid_Z_SetNull( );
               this.gxTv_SdtTitulo_Notafiscalnumero_Z_SetNull( );
               this.gxTv_SdtTitulo_Contabancariaid_Z_SetNull( );
               this.gxTv_SdtTitulo_Agenciabanconome_Z_SetNull( );
               this.gxTv_SdtTitulo_Contabancariacarteira_Z_SetNull( );
               this.gxTv_SdtTitulo_Contabancarianumero_Z_SetNull( );
               this.gxTv_SdtTitulo_Agencianumero_Z_SetNull( );
               this.gxTv_SdtTitulo_Titulosemcarteiradecobranca_f_Z_SetNull( );
               this.gxTv_SdtTitulo_Tituloscarteiradecobranca_Z_SetNull( );
            }
            gxTv_SdtTitulo_Tituloid = value;
            SetDirty("Tituloid");
         }

      }

      [  SoapElement( ElementName = "TituloClienteId" )]
      [  XmlElement( ElementName = "TituloClienteId"   )]
      public int gxTpr_Tituloclienteid
      {
         get {
            return gxTv_SdtTitulo_Tituloclienteid ;
         }

         set {
            gxTv_SdtTitulo_Tituloclienteid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTitulo_Tituloclienteid = value;
            SetDirty("Tituloclienteid");
         }

      }

      public void gxTv_SdtTitulo_Tituloclienteid_SetNull( )
      {
         gxTv_SdtTitulo_Tituloclienteid_N = 1;
         gxTv_SdtTitulo_Tituloclienteid = 0;
         SetDirty("Tituloclienteid");
         return  ;
      }

      public bool gxTv_SdtTitulo_Tituloclienteid_IsNull( )
      {
         return (gxTv_SdtTitulo_Tituloclienteid_N==1) ;
      }

      [  SoapElement( ElementName = "TituloCLienteRazaoSocial" )]
      [  XmlElement( ElementName = "TituloCLienteRazaoSocial"   )]
      public string gxTpr_Tituloclienterazaosocial
      {
         get {
            return gxTv_SdtTitulo_Tituloclienterazaosocial ;
         }

         set {
            gxTv_SdtTitulo_Tituloclienterazaosocial_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTitulo_Tituloclienterazaosocial = value;
            SetDirty("Tituloclienterazaosocial");
         }

      }

      public void gxTv_SdtTitulo_Tituloclienterazaosocial_SetNull( )
      {
         gxTv_SdtTitulo_Tituloclienterazaosocial_N = 1;
         gxTv_SdtTitulo_Tituloclienterazaosocial = "";
         SetDirty("Tituloclienterazaosocial");
         return  ;
      }

      public bool gxTv_SdtTitulo_Tituloclienterazaosocial_IsNull( )
      {
         return (gxTv_SdtTitulo_Tituloclienterazaosocial_N==1) ;
      }

      [  SoapElement( ElementName = "TituloValor" )]
      [  XmlElement( ElementName = "TituloValor"   )]
      public decimal gxTpr_Titulovalor
      {
         get {
            return gxTv_SdtTitulo_Titulovalor ;
         }

         set {
            gxTv_SdtTitulo_Titulovalor_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulovalor = value;
            SetDirty("Titulovalor");
         }

      }

      public void gxTv_SdtTitulo_Titulovalor_SetNull( )
      {
         gxTv_SdtTitulo_Titulovalor_N = 1;
         gxTv_SdtTitulo_Titulovalor = 0;
         SetDirty("Titulovalor");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulovalor_IsNull( )
      {
         return (gxTv_SdtTitulo_Titulovalor_N==1) ;
      }

      [  SoapElement( ElementName = "TituloDesconto" )]
      [  XmlElement( ElementName = "TituloDesconto"   )]
      public decimal gxTpr_Titulodesconto
      {
         get {
            return gxTv_SdtTitulo_Titulodesconto ;
         }

         set {
            gxTv_SdtTitulo_Titulodesconto_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulodesconto = value;
            SetDirty("Titulodesconto");
         }

      }

      public void gxTv_SdtTitulo_Titulodesconto_SetNull( )
      {
         gxTv_SdtTitulo_Titulodesconto_N = 1;
         gxTv_SdtTitulo_Titulodesconto = 0;
         SetDirty("Titulodesconto");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulodesconto_IsNull( )
      {
         return (gxTv_SdtTitulo_Titulodesconto_N==1) ;
      }

      [  SoapElement( ElementName = "TituloDeleted" )]
      [  XmlElement( ElementName = "TituloDeleted"   )]
      public bool gxTpr_Titulodeleted
      {
         get {
            return gxTv_SdtTitulo_Titulodeleted ;
         }

         set {
            gxTv_SdtTitulo_Titulodeleted_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulodeleted = value;
            SetDirty("Titulodeleted");
         }

      }

      public void gxTv_SdtTitulo_Titulodeleted_SetNull( )
      {
         gxTv_SdtTitulo_Titulodeleted_N = 1;
         gxTv_SdtTitulo_Titulodeleted = false;
         SetDirty("Titulodeleted");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulodeleted_IsNull( )
      {
         return (gxTv_SdtTitulo_Titulodeleted_N==1) ;
      }

      [  SoapElement( ElementName = "TituloArchived" )]
      [  XmlElement( ElementName = "TituloArchived"   )]
      public bool gxTpr_Tituloarchived
      {
         get {
            return gxTv_SdtTitulo_Tituloarchived ;
         }

         set {
            gxTv_SdtTitulo_Tituloarchived_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTitulo_Tituloarchived = value;
            SetDirty("Tituloarchived");
         }

      }

      public void gxTv_SdtTitulo_Tituloarchived_SetNull( )
      {
         gxTv_SdtTitulo_Tituloarchived_N = 1;
         gxTv_SdtTitulo_Tituloarchived = false;
         SetDirty("Tituloarchived");
         return  ;
      }

      public bool gxTv_SdtTitulo_Tituloarchived_IsNull( )
      {
         return (gxTv_SdtTitulo_Tituloarchived_N==1) ;
      }

      [  SoapElement( ElementName = "TituloVencimento" )]
      [  XmlElement( ElementName = "TituloVencimento"  , IsNullable=true )]
      public string gxTpr_Titulovencimento_Nullable
      {
         get {
            if ( gxTv_SdtTitulo_Titulovencimento == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtTitulo_Titulovencimento).value ;
         }

         set {
            gxTv_SdtTitulo_Titulovencimento_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtTitulo_Titulovencimento = DateTime.MinValue;
            else
               gxTv_SdtTitulo_Titulovencimento = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Titulovencimento
      {
         get {
            return gxTv_SdtTitulo_Titulovencimento ;
         }

         set {
            gxTv_SdtTitulo_Titulovencimento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulovencimento = value;
            SetDirty("Titulovencimento");
         }

      }

      public void gxTv_SdtTitulo_Titulovencimento_SetNull( )
      {
         gxTv_SdtTitulo_Titulovencimento_N = 1;
         gxTv_SdtTitulo_Titulovencimento = (DateTime)(DateTime.MinValue);
         SetDirty("Titulovencimento");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulovencimento_IsNull( )
      {
         return (gxTv_SdtTitulo_Titulovencimento_N==1) ;
      }

      [  SoapElement( ElementName = "TituloCompetenciaAno" )]
      [  XmlElement( ElementName = "TituloCompetenciaAno"   )]
      public short gxTpr_Titulocompetenciaano
      {
         get {
            return gxTv_SdtTitulo_Titulocompetenciaano ;
         }

         set {
            gxTv_SdtTitulo_Titulocompetenciaano_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulocompetenciaano = value;
            SetDirty("Titulocompetenciaano");
         }

      }

      public void gxTv_SdtTitulo_Titulocompetenciaano_SetNull( )
      {
         gxTv_SdtTitulo_Titulocompetenciaano_N = 1;
         gxTv_SdtTitulo_Titulocompetenciaano = 0;
         SetDirty("Titulocompetenciaano");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulocompetenciaano_IsNull( )
      {
         return (gxTv_SdtTitulo_Titulocompetenciaano_N==1) ;
      }

      [  SoapElement( ElementName = "TituloCompetenciaMes" )]
      [  XmlElement( ElementName = "TituloCompetenciaMes"   )]
      public short gxTpr_Titulocompetenciames
      {
         get {
            return gxTv_SdtTitulo_Titulocompetenciames ;
         }

         set {
            gxTv_SdtTitulo_Titulocompetenciames_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulocompetenciames = value;
            SetDirty("Titulocompetenciames");
         }

      }

      public void gxTv_SdtTitulo_Titulocompetenciames_SetNull( )
      {
         gxTv_SdtTitulo_Titulocompetenciames_N = 1;
         gxTv_SdtTitulo_Titulocompetenciames = 0;
         SetDirty("Titulocompetenciames");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulocompetenciames_IsNull( )
      {
         return (gxTv_SdtTitulo_Titulocompetenciames_N==1) ;
      }

      [  SoapElement( ElementName = "TituloCompetencia_F" )]
      [  XmlElement( ElementName = "TituloCompetencia_F"   )]
      public string gxTpr_Titulocompetencia_f
      {
         get {
            return gxTv_SdtTitulo_Titulocompetencia_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulocompetencia_f = value;
            SetDirty("Titulocompetencia_f");
         }

      }

      public void gxTv_SdtTitulo_Titulocompetencia_f_SetNull( )
      {
         gxTv_SdtTitulo_Titulocompetencia_f = "";
         SetDirty("Titulocompetencia_f");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulocompetencia_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloProrrogacao" )]
      [  XmlElement( ElementName = "TituloProrrogacao"  , IsNullable=true )]
      public string gxTpr_Tituloprorrogacao_Nullable
      {
         get {
            if ( gxTv_SdtTitulo_Tituloprorrogacao == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtTitulo_Tituloprorrogacao).value ;
         }

         set {
            gxTv_SdtTitulo_Tituloprorrogacao_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtTitulo_Tituloprorrogacao = DateTime.MinValue;
            else
               gxTv_SdtTitulo_Tituloprorrogacao = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Tituloprorrogacao
      {
         get {
            return gxTv_SdtTitulo_Tituloprorrogacao ;
         }

         set {
            gxTv_SdtTitulo_Tituloprorrogacao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTitulo_Tituloprorrogacao = value;
            SetDirty("Tituloprorrogacao");
         }

      }

      public void gxTv_SdtTitulo_Tituloprorrogacao_SetNull( )
      {
         gxTv_SdtTitulo_Tituloprorrogacao_N = 1;
         gxTv_SdtTitulo_Tituloprorrogacao = (DateTime)(DateTime.MinValue);
         SetDirty("Tituloprorrogacao");
         return  ;
      }

      public bool gxTv_SdtTitulo_Tituloprorrogacao_IsNull( )
      {
         return (gxTv_SdtTitulo_Tituloprorrogacao_N==1) ;
      }

      [  SoapElement( ElementName = "TituloCEP" )]
      [  XmlElement( ElementName = "TituloCEP"   )]
      public string gxTpr_Titulocep
      {
         get {
            return gxTv_SdtTitulo_Titulocep ;
         }

         set {
            gxTv_SdtTitulo_Titulocep_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulocep = value;
            SetDirty("Titulocep");
         }

      }

      public void gxTv_SdtTitulo_Titulocep_SetNull( )
      {
         gxTv_SdtTitulo_Titulocep_N = 1;
         gxTv_SdtTitulo_Titulocep = "";
         SetDirty("Titulocep");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulocep_IsNull( )
      {
         return (gxTv_SdtTitulo_Titulocep_N==1) ;
      }

      [  SoapElement( ElementName = "TituloLogradouro" )]
      [  XmlElement( ElementName = "TituloLogradouro"   )]
      public string gxTpr_Titulologradouro
      {
         get {
            return gxTv_SdtTitulo_Titulologradouro ;
         }

         set {
            gxTv_SdtTitulo_Titulologradouro_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulologradouro = value;
            SetDirty("Titulologradouro");
         }

      }

      public void gxTv_SdtTitulo_Titulologradouro_SetNull( )
      {
         gxTv_SdtTitulo_Titulologradouro_N = 1;
         gxTv_SdtTitulo_Titulologradouro = "";
         SetDirty("Titulologradouro");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulologradouro_IsNull( )
      {
         return (gxTv_SdtTitulo_Titulologradouro_N==1) ;
      }

      [  SoapElement( ElementName = "TituloNumeroEndereco" )]
      [  XmlElement( ElementName = "TituloNumeroEndereco"   )]
      public string gxTpr_Titulonumeroendereco
      {
         get {
            return gxTv_SdtTitulo_Titulonumeroendereco ;
         }

         set {
            gxTv_SdtTitulo_Titulonumeroendereco_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulonumeroendereco = value;
            SetDirty("Titulonumeroendereco");
         }

      }

      public void gxTv_SdtTitulo_Titulonumeroendereco_SetNull( )
      {
         gxTv_SdtTitulo_Titulonumeroendereco_N = 1;
         gxTv_SdtTitulo_Titulonumeroendereco = "";
         SetDirty("Titulonumeroendereco");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulonumeroendereco_IsNull( )
      {
         return (gxTv_SdtTitulo_Titulonumeroendereco_N==1) ;
      }

      [  SoapElement( ElementName = "TituloComplemento" )]
      [  XmlElement( ElementName = "TituloComplemento"   )]
      public string gxTpr_Titulocomplemento
      {
         get {
            return gxTv_SdtTitulo_Titulocomplemento ;
         }

         set {
            gxTv_SdtTitulo_Titulocomplemento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulocomplemento = value;
            SetDirty("Titulocomplemento");
         }

      }

      public void gxTv_SdtTitulo_Titulocomplemento_SetNull( )
      {
         gxTv_SdtTitulo_Titulocomplemento_N = 1;
         gxTv_SdtTitulo_Titulocomplemento = "";
         SetDirty("Titulocomplemento");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulocomplemento_IsNull( )
      {
         return (gxTv_SdtTitulo_Titulocomplemento_N==1) ;
      }

      [  SoapElement( ElementName = "TituloBairro" )]
      [  XmlElement( ElementName = "TituloBairro"   )]
      public string gxTpr_Titulobairro
      {
         get {
            return gxTv_SdtTitulo_Titulobairro ;
         }

         set {
            gxTv_SdtTitulo_Titulobairro_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulobairro = value;
            SetDirty("Titulobairro");
         }

      }

      public void gxTv_SdtTitulo_Titulobairro_SetNull( )
      {
         gxTv_SdtTitulo_Titulobairro_N = 1;
         gxTv_SdtTitulo_Titulobairro = "";
         SetDirty("Titulobairro");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulobairro_IsNull( )
      {
         return (gxTv_SdtTitulo_Titulobairro_N==1) ;
      }

      [  SoapElement( ElementName = "TituloMunicipio" )]
      [  XmlElement( ElementName = "TituloMunicipio"   )]
      public string gxTpr_Titulomunicipio
      {
         get {
            return gxTv_SdtTitulo_Titulomunicipio ;
         }

         set {
            gxTv_SdtTitulo_Titulomunicipio_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulomunicipio = value;
            SetDirty("Titulomunicipio");
         }

      }

      public void gxTv_SdtTitulo_Titulomunicipio_SetNull( )
      {
         gxTv_SdtTitulo_Titulomunicipio_N = 1;
         gxTv_SdtTitulo_Titulomunicipio = "";
         SetDirty("Titulomunicipio");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulomunicipio_IsNull( )
      {
         return (gxTv_SdtTitulo_Titulomunicipio_N==1) ;
      }

      [  SoapElement( ElementName = "TituloJurosMora" )]
      [  XmlElement( ElementName = "TituloJurosMora"   )]
      public decimal gxTpr_Titulojurosmora
      {
         get {
            return gxTv_SdtTitulo_Titulojurosmora ;
         }

         set {
            gxTv_SdtTitulo_Titulojurosmora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulojurosmora = value;
            SetDirty("Titulojurosmora");
         }

      }

      public void gxTv_SdtTitulo_Titulojurosmora_SetNull( )
      {
         gxTv_SdtTitulo_Titulojurosmora_N = 1;
         gxTv_SdtTitulo_Titulojurosmora = 0;
         SetDirty("Titulojurosmora");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulojurosmora_IsNull( )
      {
         return (gxTv_SdtTitulo_Titulojurosmora_N==1) ;
      }

      [  SoapElement( ElementName = "TituloTipo" )]
      [  XmlElement( ElementName = "TituloTipo"   )]
      public string gxTpr_Titulotipo
      {
         get {
            return gxTv_SdtTitulo_Titulotipo ;
         }

         set {
            gxTv_SdtTitulo_Titulotipo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulotipo = value;
            SetDirty("Titulotipo");
         }

      }

      public void gxTv_SdtTitulo_Titulotipo_SetNull( )
      {
         gxTv_SdtTitulo_Titulotipo_N = 1;
         gxTv_SdtTitulo_Titulotipo = "";
         SetDirty("Titulotipo");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulotipo_IsNull( )
      {
         return (gxTv_SdtTitulo_Titulotipo_N==1) ;
      }

      [  SoapElement( ElementName = "TituloPropostaId" )]
      [  XmlElement( ElementName = "TituloPropostaId"   )]
      public int gxTpr_Titulopropostaid
      {
         get {
            return gxTv_SdtTitulo_Titulopropostaid ;
         }

         set {
            gxTv_SdtTitulo_Titulopropostaid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulopropostaid = value;
            SetDirty("Titulopropostaid");
         }

      }

      public void gxTv_SdtTitulo_Titulopropostaid_SetNull( )
      {
         gxTv_SdtTitulo_Titulopropostaid_N = 1;
         gxTv_SdtTitulo_Titulopropostaid = 0;
         SetDirty("Titulopropostaid");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulopropostaid_IsNull( )
      {
         return (gxTv_SdtTitulo_Titulopropostaid_N==1) ;
      }

      [  SoapElement( ElementName = "TituloPropostaDescricao" )]
      [  XmlElement( ElementName = "TituloPropostaDescricao"   )]
      public string gxTpr_Titulopropostadescricao
      {
         get {
            return gxTv_SdtTitulo_Titulopropostadescricao ;
         }

         set {
            gxTv_SdtTitulo_Titulopropostadescricao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulopropostadescricao = value;
            SetDirty("Titulopropostadescricao");
         }

      }

      public void gxTv_SdtTitulo_Titulopropostadescricao_SetNull( )
      {
         gxTv_SdtTitulo_Titulopropostadescricao_N = 1;
         gxTv_SdtTitulo_Titulopropostadescricao = "";
         SetDirty("Titulopropostadescricao");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulopropostadescricao_IsNull( )
      {
         return (gxTv_SdtTitulo_Titulopropostadescricao_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaTaxaAdministrativa" )]
      [  XmlElement( ElementName = "PropostaTaxaAdministrativa"   )]
      public decimal gxTpr_Propostataxaadministrativa
      {
         get {
            return gxTv_SdtTitulo_Propostataxaadministrativa ;
         }

         set {
            gxTv_SdtTitulo_Propostataxaadministrativa_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTitulo_Propostataxaadministrativa = value;
            SetDirty("Propostataxaadministrativa");
         }

      }

      public void gxTv_SdtTitulo_Propostataxaadministrativa_SetNull( )
      {
         gxTv_SdtTitulo_Propostataxaadministrativa_N = 1;
         gxTv_SdtTitulo_Propostataxaadministrativa = 0;
         SetDirty("Propostataxaadministrativa");
         return  ;
      }

      public bool gxTv_SdtTitulo_Propostataxaadministrativa_IsNull( )
      {
         return (gxTv_SdtTitulo_Propostataxaadministrativa_N==1) ;
      }

      [  SoapElement( ElementName = "ContaId" )]
      [  XmlElement( ElementName = "ContaId"   )]
      public int gxTpr_Contaid
      {
         get {
            return gxTv_SdtTitulo_Contaid ;
         }

         set {
            gxTv_SdtTitulo_Contaid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTitulo_Contaid = value;
            SetDirty("Contaid");
         }

      }

      public void gxTv_SdtTitulo_Contaid_SetNull( )
      {
         gxTv_SdtTitulo_Contaid_N = 1;
         gxTv_SdtTitulo_Contaid = 0;
         SetDirty("Contaid");
         return  ;
      }

      public bool gxTv_SdtTitulo_Contaid_IsNull( )
      {
         return (gxTv_SdtTitulo_Contaid_N==1) ;
      }

      [  SoapElement( ElementName = "TituloCriacao" )]
      [  XmlElement( ElementName = "TituloCriacao"  , IsNullable=true )]
      public string gxTpr_Titulocriacao_Nullable
      {
         get {
            if ( gxTv_SdtTitulo_Titulocriacao == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTitulo_Titulocriacao).value ;
         }

         set {
            gxTv_SdtTitulo_Titulocriacao_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTitulo_Titulocriacao = DateTime.MinValue;
            else
               gxTv_SdtTitulo_Titulocriacao = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Titulocriacao
      {
         get {
            return gxTv_SdtTitulo_Titulocriacao ;
         }

         set {
            gxTv_SdtTitulo_Titulocriacao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulocriacao = value;
            SetDirty("Titulocriacao");
         }

      }

      public void gxTv_SdtTitulo_Titulocriacao_SetNull( )
      {
         gxTv_SdtTitulo_Titulocriacao_N = 1;
         gxTv_SdtTitulo_Titulocriacao = (DateTime)(DateTime.MinValue);
         SetDirty("Titulocriacao");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulocriacao_IsNull( )
      {
         return (gxTv_SdtTitulo_Titulocriacao_N==1) ;
      }

      [  SoapElement( ElementName = "CategoriaTituloId" )]
      [  XmlElement( ElementName = "CategoriaTituloId"   )]
      public int gxTpr_Categoriatituloid
      {
         get {
            return gxTv_SdtTitulo_Categoriatituloid ;
         }

         set {
            gxTv_SdtTitulo_Categoriatituloid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTitulo_Categoriatituloid = value;
            SetDirty("Categoriatituloid");
         }

      }

      public void gxTv_SdtTitulo_Categoriatituloid_SetNull( )
      {
         gxTv_SdtTitulo_Categoriatituloid_N = 1;
         gxTv_SdtTitulo_Categoriatituloid = 0;
         SetDirty("Categoriatituloid");
         return  ;
      }

      public bool gxTv_SdtTitulo_Categoriatituloid_IsNull( )
      {
         return (gxTv_SdtTitulo_Categoriatituloid_N==1) ;
      }

      [  SoapElement( ElementName = "TituloDataCredito_F" )]
      [  XmlElement( ElementName = "TituloDataCredito_F"  , IsNullable=true )]
      public string gxTpr_Titulodatacredito_f_Nullable
      {
         get {
            if ( gxTv_SdtTitulo_Titulodatacredito_f == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtTitulo_Titulodatacredito_f).value ;
         }

         set {
            gxTv_SdtTitulo_Titulodatacredito_f_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtTitulo_Titulodatacredito_f = DateTime.MinValue;
            else
               gxTv_SdtTitulo_Titulodatacredito_f = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Titulodatacredito_f
      {
         get {
            return gxTv_SdtTitulo_Titulodatacredito_f ;
         }

         set {
            gxTv_SdtTitulo_Titulodatacredito_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulodatacredito_f = value;
            SetDirty("Titulodatacredito_f");
         }

      }

      public void gxTv_SdtTitulo_Titulodatacredito_f_SetNull( )
      {
         gxTv_SdtTitulo_Titulodatacredito_f_N = 1;
         gxTv_SdtTitulo_Titulodatacredito_f = (DateTime)(DateTime.MinValue);
         SetDirty("Titulodatacredito_f");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulodatacredito_f_IsNull( )
      {
         return (gxTv_SdtTitulo_Titulodatacredito_f_N==1) ;
      }

      [  SoapElement( ElementName = "TituloTotalMovimento_F" )]
      [  XmlElement( ElementName = "TituloTotalMovimento_F"   )]
      public decimal gxTpr_Titulototalmovimento_f
      {
         get {
            return gxTv_SdtTitulo_Titulototalmovimento_f ;
         }

         set {
            gxTv_SdtTitulo_Titulototalmovimento_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulototalmovimento_f = value;
            SetDirty("Titulototalmovimento_f");
         }

      }

      public void gxTv_SdtTitulo_Titulototalmovimento_f_SetNull( )
      {
         gxTv_SdtTitulo_Titulototalmovimento_f_N = 1;
         gxTv_SdtTitulo_Titulototalmovimento_f = 0;
         SetDirty("Titulototalmovimento_f");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulototalmovimento_f_IsNull( )
      {
         return (gxTv_SdtTitulo_Titulototalmovimento_f_N==1) ;
      }

      [  SoapElement( ElementName = "TituloTotalMultaJuros_F" )]
      [  XmlElement( ElementName = "TituloTotalMultaJuros_F"   )]
      public decimal gxTpr_Titulototalmultajuros_f
      {
         get {
            return gxTv_SdtTitulo_Titulototalmultajuros_f ;
         }

         set {
            gxTv_SdtTitulo_Titulototalmultajuros_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulototalmultajuros_f = value;
            SetDirty("Titulototalmultajuros_f");
         }

      }

      public void gxTv_SdtTitulo_Titulototalmultajuros_f_SetNull( )
      {
         gxTv_SdtTitulo_Titulototalmultajuros_f_N = 1;
         gxTv_SdtTitulo_Titulototalmultajuros_f = 0;
         SetDirty("Titulototalmultajuros_f");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulototalmultajuros_f_IsNull( )
      {
         return (gxTv_SdtTitulo_Titulototalmultajuros_f_N==1) ;
      }

      [  SoapElement( ElementName = "TituloSaldo_F" )]
      [  XmlElement( ElementName = "TituloSaldo_F"   )]
      public decimal gxTpr_Titulosaldo_f
      {
         get {
            return gxTv_SdtTitulo_Titulosaldo_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulosaldo_f = value;
            SetDirty("Titulosaldo_f");
         }

      }

      public void gxTv_SdtTitulo_Titulosaldo_f_SetNull( )
      {
         gxTv_SdtTitulo_Titulosaldo_f = 0;
         SetDirty("Titulosaldo_f");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulosaldo_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloStatus_F" )]
      [  XmlElement( ElementName = "TituloStatus_F"   )]
      public string gxTpr_Titulostatus_f
      {
         get {
            return gxTv_SdtTitulo_Titulostatus_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulostatus_f = value;
            SetDirty("Titulostatus_f");
         }

      }

      public void gxTv_SdtTitulo_Titulostatus_f_SetNull( )
      {
         gxTv_SdtTitulo_Titulostatus_f = "";
         SetDirty("Titulostatus_f");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulostatus_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloSaldoDebito_F" )]
      [  XmlElement( ElementName = "TituloSaldoDebito_F"   )]
      public decimal gxTpr_Titulosaldodebito_f
      {
         get {
            return gxTv_SdtTitulo_Titulosaldodebito_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulosaldodebito_f = value;
            SetDirty("Titulosaldodebito_f");
         }

      }

      public void gxTv_SdtTitulo_Titulosaldodebito_f_SetNull( )
      {
         gxTv_SdtTitulo_Titulosaldodebito_f = 0;
         SetDirty("Titulosaldodebito_f");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulosaldodebito_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloSaldoCredito_F" )]
      [  XmlElement( ElementName = "TituloSaldoCredito_F"   )]
      public decimal gxTpr_Titulosaldocredito_f
      {
         get {
            return gxTv_SdtTitulo_Titulosaldocredito_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulosaldocredito_f = value;
            SetDirty("Titulosaldocredito_f");
         }

      }

      public void gxTv_SdtTitulo_Titulosaldocredito_f_SetNull( )
      {
         gxTv_SdtTitulo_Titulosaldocredito_f = 0;
         SetDirty("Titulosaldocredito_f");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulosaldocredito_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloTotalMovimentoDebito_F" )]
      [  XmlElement( ElementName = "TituloTotalMovimentoDebito_F"   )]
      public decimal gxTpr_Titulototalmovimentodebito_f
      {
         get {
            return gxTv_SdtTitulo_Titulototalmovimentodebito_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulototalmovimentodebito_f = value;
            SetDirty("Titulototalmovimentodebito_f");
         }

      }

      public void gxTv_SdtTitulo_Titulototalmovimentodebito_f_SetNull( )
      {
         gxTv_SdtTitulo_Titulototalmovimentodebito_f = 0;
         SetDirty("Titulototalmovimentodebito_f");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulototalmovimentodebito_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloTotalMovimentoCredito_F" )]
      [  XmlElement( ElementName = "TituloTotalMovimentoCredito_F"   )]
      public decimal gxTpr_Titulototalmovimentocredito_f
      {
         get {
            return gxTv_SdtTitulo_Titulototalmovimentocredito_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulototalmovimentocredito_f = value;
            SetDirty("Titulototalmovimentocredito_f");
         }

      }

      public void gxTv_SdtTitulo_Titulototalmovimentocredito_f_SetNull( )
      {
         gxTv_SdtTitulo_Titulototalmovimentocredito_f = 0;
         SetDirty("Titulototalmovimentocredito_f");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulototalmovimentocredito_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloTotalMultaJurosDebito_F" )]
      [  XmlElement( ElementName = "TituloTotalMultaJurosDebito_F"   )]
      public decimal gxTpr_Titulototalmultajurosdebito_f
      {
         get {
            return gxTv_SdtTitulo_Titulototalmultajurosdebito_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulototalmultajurosdebito_f = value;
            SetDirty("Titulototalmultajurosdebito_f");
         }

      }

      public void gxTv_SdtTitulo_Titulototalmultajurosdebito_f_SetNull( )
      {
         gxTv_SdtTitulo_Titulototalmultajurosdebito_f = 0;
         SetDirty("Titulototalmultajurosdebito_f");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulototalmultajurosdebito_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloTotalMultaJurosCredito_F" )]
      [  XmlElement( ElementName = "TituloTotalMultaJurosCredito_F"   )]
      public decimal gxTpr_Titulototalmultajuroscredito_f
      {
         get {
            return gxTv_SdtTitulo_Titulototalmultajuroscredito_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulototalmultajuroscredito_f = value;
            SetDirty("Titulototalmultajuroscredito_f");
         }

      }

      public void gxTv_SdtTitulo_Titulototalmultajuroscredito_f_SetNull( )
      {
         gxTv_SdtTitulo_Titulototalmultajuroscredito_f = 0;
         SetDirty("Titulototalmultajuroscredito_f");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulototalmultajuroscredito_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloPropostaTipo" )]
      [  XmlElement( ElementName = "TituloPropostaTipo"   )]
      public string gxTpr_Titulopropostatipo
      {
         get {
            return gxTv_SdtTitulo_Titulopropostatipo ;
         }

         set {
            gxTv_SdtTitulo_Titulopropostatipo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulopropostatipo = value;
            SetDirty("Titulopropostatipo");
         }

      }

      public void gxTv_SdtTitulo_Titulopropostatipo_SetNull( )
      {
         gxTv_SdtTitulo_Titulopropostatipo_N = 1;
         gxTv_SdtTitulo_Titulopropostatipo = "";
         SetDirty("Titulopropostatipo");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulopropostatipo_IsNull( )
      {
         return (gxTv_SdtTitulo_Titulopropostatipo_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalParcelamentoID" )]
      [  XmlElement( ElementName = "NotaFiscalParcelamentoID"   )]
      public Guid gxTpr_Notafiscalparcelamentoid
      {
         get {
            return gxTv_SdtTitulo_Notafiscalparcelamentoid ;
         }

         set {
            gxTv_SdtTitulo_Notafiscalparcelamentoid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTitulo_Notafiscalparcelamentoid = value;
            SetDirty("Notafiscalparcelamentoid");
         }

      }

      public void gxTv_SdtTitulo_Notafiscalparcelamentoid_SetNull( )
      {
         gxTv_SdtTitulo_Notafiscalparcelamentoid_N = 1;
         gxTv_SdtTitulo_Notafiscalparcelamentoid = Guid.Empty;
         SetDirty("Notafiscalparcelamentoid");
         return  ;
      }

      public bool gxTv_SdtTitulo_Notafiscalparcelamentoid_IsNull( )
      {
         return (gxTv_SdtTitulo_Notafiscalparcelamentoid_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalNumero" )]
      [  XmlElement( ElementName = "NotaFiscalNumero"   )]
      public string gxTpr_Notafiscalnumero
      {
         get {
            return gxTv_SdtTitulo_Notafiscalnumero ;
         }

         set {
            gxTv_SdtTitulo_Notafiscalnumero_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTitulo_Notafiscalnumero = value;
            SetDirty("Notafiscalnumero");
         }

      }

      public void gxTv_SdtTitulo_Notafiscalnumero_SetNull( )
      {
         gxTv_SdtTitulo_Notafiscalnumero_N = 1;
         gxTv_SdtTitulo_Notafiscalnumero = "";
         SetDirty("Notafiscalnumero");
         return  ;
      }

      public bool gxTv_SdtTitulo_Notafiscalnumero_IsNull( )
      {
         return (gxTv_SdtTitulo_Notafiscalnumero_N==1) ;
      }

      [  SoapElement( ElementName = "ContaBancariaId" )]
      [  XmlElement( ElementName = "ContaBancariaId"   )]
      public int gxTpr_Contabancariaid
      {
         get {
            return gxTv_SdtTitulo_Contabancariaid ;
         }

         set {
            gxTv_SdtTitulo_Contabancariaid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTitulo_Contabancariaid = value;
            SetDirty("Contabancariaid");
         }

      }

      public void gxTv_SdtTitulo_Contabancariaid_SetNull( )
      {
         gxTv_SdtTitulo_Contabancariaid_N = 1;
         gxTv_SdtTitulo_Contabancariaid = 0;
         SetDirty("Contabancariaid");
         return  ;
      }

      public bool gxTv_SdtTitulo_Contabancariaid_IsNull( )
      {
         return (gxTv_SdtTitulo_Contabancariaid_N==1) ;
      }

      [  SoapElement( ElementName = "AgenciaBancoNome" )]
      [  XmlElement( ElementName = "AgenciaBancoNome"   )]
      public string gxTpr_Agenciabanconome
      {
         get {
            return gxTv_SdtTitulo_Agenciabanconome ;
         }

         set {
            gxTv_SdtTitulo_Agenciabanconome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTitulo_Agenciabanconome = value;
            SetDirty("Agenciabanconome");
         }

      }

      public void gxTv_SdtTitulo_Agenciabanconome_SetNull( )
      {
         gxTv_SdtTitulo_Agenciabanconome_N = 1;
         gxTv_SdtTitulo_Agenciabanconome = "";
         SetDirty("Agenciabanconome");
         return  ;
      }

      public bool gxTv_SdtTitulo_Agenciabanconome_IsNull( )
      {
         return (gxTv_SdtTitulo_Agenciabanconome_N==1) ;
      }

      [  SoapElement( ElementName = "ContaBancariaCarteira" )]
      [  XmlElement( ElementName = "ContaBancariaCarteira"   )]
      public long gxTpr_Contabancariacarteira
      {
         get {
            return gxTv_SdtTitulo_Contabancariacarteira ;
         }

         set {
            gxTv_SdtTitulo_Contabancariacarteira_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTitulo_Contabancariacarteira = value;
            SetDirty("Contabancariacarteira");
         }

      }

      public void gxTv_SdtTitulo_Contabancariacarteira_SetNull( )
      {
         gxTv_SdtTitulo_Contabancariacarteira_N = 1;
         gxTv_SdtTitulo_Contabancariacarteira = 0;
         SetDirty("Contabancariacarteira");
         return  ;
      }

      public bool gxTv_SdtTitulo_Contabancariacarteira_IsNull( )
      {
         return (gxTv_SdtTitulo_Contabancariacarteira_N==1) ;
      }

      [  SoapElement( ElementName = "ContaBancariaNumero" )]
      [  XmlElement( ElementName = "ContaBancariaNumero"   )]
      public long gxTpr_Contabancarianumero
      {
         get {
            return gxTv_SdtTitulo_Contabancarianumero ;
         }

         set {
            gxTv_SdtTitulo_Contabancarianumero_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTitulo_Contabancarianumero = value;
            SetDirty("Contabancarianumero");
         }

      }

      public void gxTv_SdtTitulo_Contabancarianumero_SetNull( )
      {
         gxTv_SdtTitulo_Contabancarianumero_N = 1;
         gxTv_SdtTitulo_Contabancarianumero = 0;
         SetDirty("Contabancarianumero");
         return  ;
      }

      public bool gxTv_SdtTitulo_Contabancarianumero_IsNull( )
      {
         return (gxTv_SdtTitulo_Contabancarianumero_N==1) ;
      }

      [  SoapElement( ElementName = "AgenciaNumero" )]
      [  XmlElement( ElementName = "AgenciaNumero"   )]
      public int gxTpr_Agencianumero
      {
         get {
            return gxTv_SdtTitulo_Agencianumero ;
         }

         set {
            gxTv_SdtTitulo_Agencianumero_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTitulo_Agencianumero = value;
            SetDirty("Agencianumero");
         }

      }

      public void gxTv_SdtTitulo_Agencianumero_SetNull( )
      {
         gxTv_SdtTitulo_Agencianumero_N = 1;
         gxTv_SdtTitulo_Agencianumero = 0;
         SetDirty("Agencianumero");
         return  ;
      }

      public bool gxTv_SdtTitulo_Agencianumero_IsNull( )
      {
         return (gxTv_SdtTitulo_Agencianumero_N==1) ;
      }

      [  SoapElement( ElementName = "TitulosEmCarteiraDeCobranca_F" )]
      [  XmlElement( ElementName = "TitulosEmCarteiraDeCobranca_F"   )]
      public bool gxTpr_Titulosemcarteiradecobranca_f
      {
         get {
            return gxTv_SdtTitulo_Titulosemcarteiradecobranca_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulosemcarteiradecobranca_f = value;
            SetDirty("Titulosemcarteiradecobranca_f");
         }

      }

      public void gxTv_SdtTitulo_Titulosemcarteiradecobranca_f_SetNull( )
      {
         gxTv_SdtTitulo_Titulosemcarteiradecobranca_f = false;
         SetDirty("Titulosemcarteiradecobranca_f");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulosemcarteiradecobranca_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TitulosCarteiraDeCobranca" )]
      [  XmlElement( ElementName = "TitulosCarteiraDeCobranca"   )]
      public string gxTpr_Tituloscarteiradecobranca
      {
         get {
            return gxTv_SdtTitulo_Tituloscarteiradecobranca ;
         }

         set {
            gxTv_SdtTitulo_Tituloscarteiradecobranca_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTitulo_Tituloscarteiradecobranca = value;
            SetDirty("Tituloscarteiradecobranca");
         }

      }

      public void gxTv_SdtTitulo_Tituloscarteiradecobranca_SetNull( )
      {
         gxTv_SdtTitulo_Tituloscarteiradecobranca_N = 1;
         gxTv_SdtTitulo_Tituloscarteiradecobranca = "";
         SetDirty("Tituloscarteiradecobranca");
         return  ;
      }

      public bool gxTv_SdtTitulo_Tituloscarteiradecobranca_IsNull( )
      {
         return (gxTv_SdtTitulo_Tituloscarteiradecobranca_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTitulo_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTitulo_Mode_SetNull( )
      {
         gxTv_SdtTitulo_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTitulo_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTitulo_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTitulo_Initialized_SetNull( )
      {
         gxTv_SdtTitulo_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTitulo_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloId_Z" )]
      [  XmlElement( ElementName = "TituloId_Z"   )]
      public int gxTpr_Tituloid_Z
      {
         get {
            return gxTv_SdtTitulo_Tituloid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Tituloid_Z = value;
            SetDirty("Tituloid_Z");
         }

      }

      public void gxTv_SdtTitulo_Tituloid_Z_SetNull( )
      {
         gxTv_SdtTitulo_Tituloid_Z = 0;
         SetDirty("Tituloid_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Tituloid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloClienteId_Z" )]
      [  XmlElement( ElementName = "TituloClienteId_Z"   )]
      public int gxTpr_Tituloclienteid_Z
      {
         get {
            return gxTv_SdtTitulo_Tituloclienteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Tituloclienteid_Z = value;
            SetDirty("Tituloclienteid_Z");
         }

      }

      public void gxTv_SdtTitulo_Tituloclienteid_Z_SetNull( )
      {
         gxTv_SdtTitulo_Tituloclienteid_Z = 0;
         SetDirty("Tituloclienteid_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Tituloclienteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloCLienteRazaoSocial_Z" )]
      [  XmlElement( ElementName = "TituloCLienteRazaoSocial_Z"   )]
      public string gxTpr_Tituloclienterazaosocial_Z
      {
         get {
            return gxTv_SdtTitulo_Tituloclienterazaosocial_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Tituloclienterazaosocial_Z = value;
            SetDirty("Tituloclienterazaosocial_Z");
         }

      }

      public void gxTv_SdtTitulo_Tituloclienterazaosocial_Z_SetNull( )
      {
         gxTv_SdtTitulo_Tituloclienterazaosocial_Z = "";
         SetDirty("Tituloclienterazaosocial_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Tituloclienterazaosocial_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloValor_Z" )]
      [  XmlElement( ElementName = "TituloValor_Z"   )]
      public decimal gxTpr_Titulovalor_Z
      {
         get {
            return gxTv_SdtTitulo_Titulovalor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulovalor_Z = value;
            SetDirty("Titulovalor_Z");
         }

      }

      public void gxTv_SdtTitulo_Titulovalor_Z_SetNull( )
      {
         gxTv_SdtTitulo_Titulovalor_Z = 0;
         SetDirty("Titulovalor_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulovalor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloDesconto_Z" )]
      [  XmlElement( ElementName = "TituloDesconto_Z"   )]
      public decimal gxTpr_Titulodesconto_Z
      {
         get {
            return gxTv_SdtTitulo_Titulodesconto_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulodesconto_Z = value;
            SetDirty("Titulodesconto_Z");
         }

      }

      public void gxTv_SdtTitulo_Titulodesconto_Z_SetNull( )
      {
         gxTv_SdtTitulo_Titulodesconto_Z = 0;
         SetDirty("Titulodesconto_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulodesconto_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloDeleted_Z" )]
      [  XmlElement( ElementName = "TituloDeleted_Z"   )]
      public bool gxTpr_Titulodeleted_Z
      {
         get {
            return gxTv_SdtTitulo_Titulodeleted_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulodeleted_Z = value;
            SetDirty("Titulodeleted_Z");
         }

      }

      public void gxTv_SdtTitulo_Titulodeleted_Z_SetNull( )
      {
         gxTv_SdtTitulo_Titulodeleted_Z = false;
         SetDirty("Titulodeleted_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulodeleted_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloArchived_Z" )]
      [  XmlElement( ElementName = "TituloArchived_Z"   )]
      public bool gxTpr_Tituloarchived_Z
      {
         get {
            return gxTv_SdtTitulo_Tituloarchived_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Tituloarchived_Z = value;
            SetDirty("Tituloarchived_Z");
         }

      }

      public void gxTv_SdtTitulo_Tituloarchived_Z_SetNull( )
      {
         gxTv_SdtTitulo_Tituloarchived_Z = false;
         SetDirty("Tituloarchived_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Tituloarchived_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloVencimento_Z" )]
      [  XmlElement( ElementName = "TituloVencimento_Z"  , IsNullable=true )]
      public string gxTpr_Titulovencimento_Z_Nullable
      {
         get {
            if ( gxTv_SdtTitulo_Titulovencimento_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtTitulo_Titulovencimento_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtTitulo_Titulovencimento_Z = DateTime.MinValue;
            else
               gxTv_SdtTitulo_Titulovencimento_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Titulovencimento_Z
      {
         get {
            return gxTv_SdtTitulo_Titulovencimento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulovencimento_Z = value;
            SetDirty("Titulovencimento_Z");
         }

      }

      public void gxTv_SdtTitulo_Titulovencimento_Z_SetNull( )
      {
         gxTv_SdtTitulo_Titulovencimento_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Titulovencimento_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulovencimento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloCompetenciaAno_Z" )]
      [  XmlElement( ElementName = "TituloCompetenciaAno_Z"   )]
      public short gxTpr_Titulocompetenciaano_Z
      {
         get {
            return gxTv_SdtTitulo_Titulocompetenciaano_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulocompetenciaano_Z = value;
            SetDirty("Titulocompetenciaano_Z");
         }

      }

      public void gxTv_SdtTitulo_Titulocompetenciaano_Z_SetNull( )
      {
         gxTv_SdtTitulo_Titulocompetenciaano_Z = 0;
         SetDirty("Titulocompetenciaano_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulocompetenciaano_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloCompetenciaMes_Z" )]
      [  XmlElement( ElementName = "TituloCompetenciaMes_Z"   )]
      public short gxTpr_Titulocompetenciames_Z
      {
         get {
            return gxTv_SdtTitulo_Titulocompetenciames_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulocompetenciames_Z = value;
            SetDirty("Titulocompetenciames_Z");
         }

      }

      public void gxTv_SdtTitulo_Titulocompetenciames_Z_SetNull( )
      {
         gxTv_SdtTitulo_Titulocompetenciames_Z = 0;
         SetDirty("Titulocompetenciames_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulocompetenciames_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloCompetencia_F_Z" )]
      [  XmlElement( ElementName = "TituloCompetencia_F_Z"   )]
      public string gxTpr_Titulocompetencia_f_Z
      {
         get {
            return gxTv_SdtTitulo_Titulocompetencia_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulocompetencia_f_Z = value;
            SetDirty("Titulocompetencia_f_Z");
         }

      }

      public void gxTv_SdtTitulo_Titulocompetencia_f_Z_SetNull( )
      {
         gxTv_SdtTitulo_Titulocompetencia_f_Z = "";
         SetDirty("Titulocompetencia_f_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulocompetencia_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloProrrogacao_Z" )]
      [  XmlElement( ElementName = "TituloProrrogacao_Z"  , IsNullable=true )]
      public string gxTpr_Tituloprorrogacao_Z_Nullable
      {
         get {
            if ( gxTv_SdtTitulo_Tituloprorrogacao_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtTitulo_Tituloprorrogacao_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtTitulo_Tituloprorrogacao_Z = DateTime.MinValue;
            else
               gxTv_SdtTitulo_Tituloprorrogacao_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Tituloprorrogacao_Z
      {
         get {
            return gxTv_SdtTitulo_Tituloprorrogacao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Tituloprorrogacao_Z = value;
            SetDirty("Tituloprorrogacao_Z");
         }

      }

      public void gxTv_SdtTitulo_Tituloprorrogacao_Z_SetNull( )
      {
         gxTv_SdtTitulo_Tituloprorrogacao_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Tituloprorrogacao_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Tituloprorrogacao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloCEP_Z" )]
      [  XmlElement( ElementName = "TituloCEP_Z"   )]
      public string gxTpr_Titulocep_Z
      {
         get {
            return gxTv_SdtTitulo_Titulocep_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulocep_Z = value;
            SetDirty("Titulocep_Z");
         }

      }

      public void gxTv_SdtTitulo_Titulocep_Z_SetNull( )
      {
         gxTv_SdtTitulo_Titulocep_Z = "";
         SetDirty("Titulocep_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulocep_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloLogradouro_Z" )]
      [  XmlElement( ElementName = "TituloLogradouro_Z"   )]
      public string gxTpr_Titulologradouro_Z
      {
         get {
            return gxTv_SdtTitulo_Titulologradouro_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulologradouro_Z = value;
            SetDirty("Titulologradouro_Z");
         }

      }

      public void gxTv_SdtTitulo_Titulologradouro_Z_SetNull( )
      {
         gxTv_SdtTitulo_Titulologradouro_Z = "";
         SetDirty("Titulologradouro_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulologradouro_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloNumeroEndereco_Z" )]
      [  XmlElement( ElementName = "TituloNumeroEndereco_Z"   )]
      public string gxTpr_Titulonumeroendereco_Z
      {
         get {
            return gxTv_SdtTitulo_Titulonumeroendereco_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulonumeroendereco_Z = value;
            SetDirty("Titulonumeroendereco_Z");
         }

      }

      public void gxTv_SdtTitulo_Titulonumeroendereco_Z_SetNull( )
      {
         gxTv_SdtTitulo_Titulonumeroendereco_Z = "";
         SetDirty("Titulonumeroendereco_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulonumeroendereco_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloComplemento_Z" )]
      [  XmlElement( ElementName = "TituloComplemento_Z"   )]
      public string gxTpr_Titulocomplemento_Z
      {
         get {
            return gxTv_SdtTitulo_Titulocomplemento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulocomplemento_Z = value;
            SetDirty("Titulocomplemento_Z");
         }

      }

      public void gxTv_SdtTitulo_Titulocomplemento_Z_SetNull( )
      {
         gxTv_SdtTitulo_Titulocomplemento_Z = "";
         SetDirty("Titulocomplemento_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulocomplemento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloBairro_Z" )]
      [  XmlElement( ElementName = "TituloBairro_Z"   )]
      public string gxTpr_Titulobairro_Z
      {
         get {
            return gxTv_SdtTitulo_Titulobairro_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulobairro_Z = value;
            SetDirty("Titulobairro_Z");
         }

      }

      public void gxTv_SdtTitulo_Titulobairro_Z_SetNull( )
      {
         gxTv_SdtTitulo_Titulobairro_Z = "";
         SetDirty("Titulobairro_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulobairro_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloMunicipio_Z" )]
      [  XmlElement( ElementName = "TituloMunicipio_Z"   )]
      public string gxTpr_Titulomunicipio_Z
      {
         get {
            return gxTv_SdtTitulo_Titulomunicipio_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulomunicipio_Z = value;
            SetDirty("Titulomunicipio_Z");
         }

      }

      public void gxTv_SdtTitulo_Titulomunicipio_Z_SetNull( )
      {
         gxTv_SdtTitulo_Titulomunicipio_Z = "";
         SetDirty("Titulomunicipio_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulomunicipio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloJurosMora_Z" )]
      [  XmlElement( ElementName = "TituloJurosMora_Z"   )]
      public decimal gxTpr_Titulojurosmora_Z
      {
         get {
            return gxTv_SdtTitulo_Titulojurosmora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulojurosmora_Z = value;
            SetDirty("Titulojurosmora_Z");
         }

      }

      public void gxTv_SdtTitulo_Titulojurosmora_Z_SetNull( )
      {
         gxTv_SdtTitulo_Titulojurosmora_Z = 0;
         SetDirty("Titulojurosmora_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulojurosmora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloTipo_Z" )]
      [  XmlElement( ElementName = "TituloTipo_Z"   )]
      public string gxTpr_Titulotipo_Z
      {
         get {
            return gxTv_SdtTitulo_Titulotipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulotipo_Z = value;
            SetDirty("Titulotipo_Z");
         }

      }

      public void gxTv_SdtTitulo_Titulotipo_Z_SetNull( )
      {
         gxTv_SdtTitulo_Titulotipo_Z = "";
         SetDirty("Titulotipo_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulotipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloPropostaId_Z" )]
      [  XmlElement( ElementName = "TituloPropostaId_Z"   )]
      public int gxTpr_Titulopropostaid_Z
      {
         get {
            return gxTv_SdtTitulo_Titulopropostaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulopropostaid_Z = value;
            SetDirty("Titulopropostaid_Z");
         }

      }

      public void gxTv_SdtTitulo_Titulopropostaid_Z_SetNull( )
      {
         gxTv_SdtTitulo_Titulopropostaid_Z = 0;
         SetDirty("Titulopropostaid_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulopropostaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloPropostaDescricao_Z" )]
      [  XmlElement( ElementName = "TituloPropostaDescricao_Z"   )]
      public string gxTpr_Titulopropostadescricao_Z
      {
         get {
            return gxTv_SdtTitulo_Titulopropostadescricao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulopropostadescricao_Z = value;
            SetDirty("Titulopropostadescricao_Z");
         }

      }

      public void gxTv_SdtTitulo_Titulopropostadescricao_Z_SetNull( )
      {
         gxTv_SdtTitulo_Titulopropostadescricao_Z = "";
         SetDirty("Titulopropostadescricao_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulopropostadescricao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaTaxaAdministrativa_Z" )]
      [  XmlElement( ElementName = "PropostaTaxaAdministrativa_Z"   )]
      public decimal gxTpr_Propostataxaadministrativa_Z
      {
         get {
            return gxTv_SdtTitulo_Propostataxaadministrativa_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Propostataxaadministrativa_Z = value;
            SetDirty("Propostataxaadministrativa_Z");
         }

      }

      public void gxTv_SdtTitulo_Propostataxaadministrativa_Z_SetNull( )
      {
         gxTv_SdtTitulo_Propostataxaadministrativa_Z = 0;
         SetDirty("Propostataxaadministrativa_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Propostataxaadministrativa_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaId_Z" )]
      [  XmlElement( ElementName = "ContaId_Z"   )]
      public int gxTpr_Contaid_Z
      {
         get {
            return gxTv_SdtTitulo_Contaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Contaid_Z = value;
            SetDirty("Contaid_Z");
         }

      }

      public void gxTv_SdtTitulo_Contaid_Z_SetNull( )
      {
         gxTv_SdtTitulo_Contaid_Z = 0;
         SetDirty("Contaid_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Contaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloCriacao_Z" )]
      [  XmlElement( ElementName = "TituloCriacao_Z"  , IsNullable=true )]
      public string gxTpr_Titulocriacao_Z_Nullable
      {
         get {
            if ( gxTv_SdtTitulo_Titulocriacao_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTitulo_Titulocriacao_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTitulo_Titulocriacao_Z = DateTime.MinValue;
            else
               gxTv_SdtTitulo_Titulocriacao_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Titulocriacao_Z
      {
         get {
            return gxTv_SdtTitulo_Titulocriacao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulocriacao_Z = value;
            SetDirty("Titulocriacao_Z");
         }

      }

      public void gxTv_SdtTitulo_Titulocriacao_Z_SetNull( )
      {
         gxTv_SdtTitulo_Titulocriacao_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Titulocriacao_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulocriacao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoriaTituloId_Z" )]
      [  XmlElement( ElementName = "CategoriaTituloId_Z"   )]
      public int gxTpr_Categoriatituloid_Z
      {
         get {
            return gxTv_SdtTitulo_Categoriatituloid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Categoriatituloid_Z = value;
            SetDirty("Categoriatituloid_Z");
         }

      }

      public void gxTv_SdtTitulo_Categoriatituloid_Z_SetNull( )
      {
         gxTv_SdtTitulo_Categoriatituloid_Z = 0;
         SetDirty("Categoriatituloid_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Categoriatituloid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloDataCredito_F_Z" )]
      [  XmlElement( ElementName = "TituloDataCredito_F_Z"  , IsNullable=true )]
      public string gxTpr_Titulodatacredito_f_Z_Nullable
      {
         get {
            if ( gxTv_SdtTitulo_Titulodatacredito_f_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtTitulo_Titulodatacredito_f_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtTitulo_Titulodatacredito_f_Z = DateTime.MinValue;
            else
               gxTv_SdtTitulo_Titulodatacredito_f_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Titulodatacredito_f_Z
      {
         get {
            return gxTv_SdtTitulo_Titulodatacredito_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulodatacredito_f_Z = value;
            SetDirty("Titulodatacredito_f_Z");
         }

      }

      public void gxTv_SdtTitulo_Titulodatacredito_f_Z_SetNull( )
      {
         gxTv_SdtTitulo_Titulodatacredito_f_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Titulodatacredito_f_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulodatacredito_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloTotalMovimento_F_Z" )]
      [  XmlElement( ElementName = "TituloTotalMovimento_F_Z"   )]
      public decimal gxTpr_Titulototalmovimento_f_Z
      {
         get {
            return gxTv_SdtTitulo_Titulototalmovimento_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulototalmovimento_f_Z = value;
            SetDirty("Titulototalmovimento_f_Z");
         }

      }

      public void gxTv_SdtTitulo_Titulototalmovimento_f_Z_SetNull( )
      {
         gxTv_SdtTitulo_Titulototalmovimento_f_Z = 0;
         SetDirty("Titulototalmovimento_f_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulototalmovimento_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloTotalMultaJuros_F_Z" )]
      [  XmlElement( ElementName = "TituloTotalMultaJuros_F_Z"   )]
      public decimal gxTpr_Titulototalmultajuros_f_Z
      {
         get {
            return gxTv_SdtTitulo_Titulototalmultajuros_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulototalmultajuros_f_Z = value;
            SetDirty("Titulototalmultajuros_f_Z");
         }

      }

      public void gxTv_SdtTitulo_Titulototalmultajuros_f_Z_SetNull( )
      {
         gxTv_SdtTitulo_Titulototalmultajuros_f_Z = 0;
         SetDirty("Titulototalmultajuros_f_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulototalmultajuros_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloSaldo_F_Z" )]
      [  XmlElement( ElementName = "TituloSaldo_F_Z"   )]
      public decimal gxTpr_Titulosaldo_f_Z
      {
         get {
            return gxTv_SdtTitulo_Titulosaldo_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulosaldo_f_Z = value;
            SetDirty("Titulosaldo_f_Z");
         }

      }

      public void gxTv_SdtTitulo_Titulosaldo_f_Z_SetNull( )
      {
         gxTv_SdtTitulo_Titulosaldo_f_Z = 0;
         SetDirty("Titulosaldo_f_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulosaldo_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloStatus_F_Z" )]
      [  XmlElement( ElementName = "TituloStatus_F_Z"   )]
      public string gxTpr_Titulostatus_f_Z
      {
         get {
            return gxTv_SdtTitulo_Titulostatus_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulostatus_f_Z = value;
            SetDirty("Titulostatus_f_Z");
         }

      }

      public void gxTv_SdtTitulo_Titulostatus_f_Z_SetNull( )
      {
         gxTv_SdtTitulo_Titulostatus_f_Z = "";
         SetDirty("Titulostatus_f_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulostatus_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloSaldoDebito_F_Z" )]
      [  XmlElement( ElementName = "TituloSaldoDebito_F_Z"   )]
      public decimal gxTpr_Titulosaldodebito_f_Z
      {
         get {
            return gxTv_SdtTitulo_Titulosaldodebito_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulosaldodebito_f_Z = value;
            SetDirty("Titulosaldodebito_f_Z");
         }

      }

      public void gxTv_SdtTitulo_Titulosaldodebito_f_Z_SetNull( )
      {
         gxTv_SdtTitulo_Titulosaldodebito_f_Z = 0;
         SetDirty("Titulosaldodebito_f_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulosaldodebito_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloSaldoCredito_F_Z" )]
      [  XmlElement( ElementName = "TituloSaldoCredito_F_Z"   )]
      public decimal gxTpr_Titulosaldocredito_f_Z
      {
         get {
            return gxTv_SdtTitulo_Titulosaldocredito_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulosaldocredito_f_Z = value;
            SetDirty("Titulosaldocredito_f_Z");
         }

      }

      public void gxTv_SdtTitulo_Titulosaldocredito_f_Z_SetNull( )
      {
         gxTv_SdtTitulo_Titulosaldocredito_f_Z = 0;
         SetDirty("Titulosaldocredito_f_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulosaldocredito_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloTotalMovimentoDebito_F_Z" )]
      [  XmlElement( ElementName = "TituloTotalMovimentoDebito_F_Z"   )]
      public decimal gxTpr_Titulototalmovimentodebito_f_Z
      {
         get {
            return gxTv_SdtTitulo_Titulototalmovimentodebito_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulototalmovimentodebito_f_Z = value;
            SetDirty("Titulototalmovimentodebito_f_Z");
         }

      }

      public void gxTv_SdtTitulo_Titulototalmovimentodebito_f_Z_SetNull( )
      {
         gxTv_SdtTitulo_Titulototalmovimentodebito_f_Z = 0;
         SetDirty("Titulototalmovimentodebito_f_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulototalmovimentodebito_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloTotalMovimentoCredito_F_Z" )]
      [  XmlElement( ElementName = "TituloTotalMovimentoCredito_F_Z"   )]
      public decimal gxTpr_Titulototalmovimentocredito_f_Z
      {
         get {
            return gxTv_SdtTitulo_Titulototalmovimentocredito_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulototalmovimentocredito_f_Z = value;
            SetDirty("Titulototalmovimentocredito_f_Z");
         }

      }

      public void gxTv_SdtTitulo_Titulototalmovimentocredito_f_Z_SetNull( )
      {
         gxTv_SdtTitulo_Titulototalmovimentocredito_f_Z = 0;
         SetDirty("Titulototalmovimentocredito_f_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulototalmovimentocredito_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloTotalMultaJurosDebito_F_Z" )]
      [  XmlElement( ElementName = "TituloTotalMultaJurosDebito_F_Z"   )]
      public decimal gxTpr_Titulototalmultajurosdebito_f_Z
      {
         get {
            return gxTv_SdtTitulo_Titulototalmultajurosdebito_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulototalmultajurosdebito_f_Z = value;
            SetDirty("Titulototalmultajurosdebito_f_Z");
         }

      }

      public void gxTv_SdtTitulo_Titulototalmultajurosdebito_f_Z_SetNull( )
      {
         gxTv_SdtTitulo_Titulototalmultajurosdebito_f_Z = 0;
         SetDirty("Titulototalmultajurosdebito_f_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulototalmultajurosdebito_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloTotalMultaJurosCredito_F_Z" )]
      [  XmlElement( ElementName = "TituloTotalMultaJurosCredito_F_Z"   )]
      public decimal gxTpr_Titulototalmultajuroscredito_f_Z
      {
         get {
            return gxTv_SdtTitulo_Titulototalmultajuroscredito_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulototalmultajuroscredito_f_Z = value;
            SetDirty("Titulototalmultajuroscredito_f_Z");
         }

      }

      public void gxTv_SdtTitulo_Titulototalmultajuroscredito_f_Z_SetNull( )
      {
         gxTv_SdtTitulo_Titulototalmultajuroscredito_f_Z = 0;
         SetDirty("Titulototalmultajuroscredito_f_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulototalmultajuroscredito_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloPropostaTipo_Z" )]
      [  XmlElement( ElementName = "TituloPropostaTipo_Z"   )]
      public string gxTpr_Titulopropostatipo_Z
      {
         get {
            return gxTv_SdtTitulo_Titulopropostatipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulopropostatipo_Z = value;
            SetDirty("Titulopropostatipo_Z");
         }

      }

      public void gxTv_SdtTitulo_Titulopropostatipo_Z_SetNull( )
      {
         gxTv_SdtTitulo_Titulopropostatipo_Z = "";
         SetDirty("Titulopropostatipo_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulopropostatipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalParcelamentoID_Z" )]
      [  XmlElement( ElementName = "NotaFiscalParcelamentoID_Z"   )]
      public Guid gxTpr_Notafiscalparcelamentoid_Z
      {
         get {
            return gxTv_SdtTitulo_Notafiscalparcelamentoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Notafiscalparcelamentoid_Z = value;
            SetDirty("Notafiscalparcelamentoid_Z");
         }

      }

      public void gxTv_SdtTitulo_Notafiscalparcelamentoid_Z_SetNull( )
      {
         gxTv_SdtTitulo_Notafiscalparcelamentoid_Z = Guid.Empty;
         SetDirty("Notafiscalparcelamentoid_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Notafiscalparcelamentoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalNumero_Z" )]
      [  XmlElement( ElementName = "NotaFiscalNumero_Z"   )]
      public string gxTpr_Notafiscalnumero_Z
      {
         get {
            return gxTv_SdtTitulo_Notafiscalnumero_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Notafiscalnumero_Z = value;
            SetDirty("Notafiscalnumero_Z");
         }

      }

      public void gxTv_SdtTitulo_Notafiscalnumero_Z_SetNull( )
      {
         gxTv_SdtTitulo_Notafiscalnumero_Z = "";
         SetDirty("Notafiscalnumero_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Notafiscalnumero_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaId_Z" )]
      [  XmlElement( ElementName = "ContaBancariaId_Z"   )]
      public int gxTpr_Contabancariaid_Z
      {
         get {
            return gxTv_SdtTitulo_Contabancariaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Contabancariaid_Z = value;
            SetDirty("Contabancariaid_Z");
         }

      }

      public void gxTv_SdtTitulo_Contabancariaid_Z_SetNull( )
      {
         gxTv_SdtTitulo_Contabancariaid_Z = 0;
         SetDirty("Contabancariaid_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Contabancariaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaBancoNome_Z" )]
      [  XmlElement( ElementName = "AgenciaBancoNome_Z"   )]
      public string gxTpr_Agenciabanconome_Z
      {
         get {
            return gxTv_SdtTitulo_Agenciabanconome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Agenciabanconome_Z = value;
            SetDirty("Agenciabanconome_Z");
         }

      }

      public void gxTv_SdtTitulo_Agenciabanconome_Z_SetNull( )
      {
         gxTv_SdtTitulo_Agenciabanconome_Z = "";
         SetDirty("Agenciabanconome_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Agenciabanconome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaCarteira_Z" )]
      [  XmlElement( ElementName = "ContaBancariaCarteira_Z"   )]
      public long gxTpr_Contabancariacarteira_Z
      {
         get {
            return gxTv_SdtTitulo_Contabancariacarteira_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Contabancariacarteira_Z = value;
            SetDirty("Contabancariacarteira_Z");
         }

      }

      public void gxTv_SdtTitulo_Contabancariacarteira_Z_SetNull( )
      {
         gxTv_SdtTitulo_Contabancariacarteira_Z = 0;
         SetDirty("Contabancariacarteira_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Contabancariacarteira_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaNumero_Z" )]
      [  XmlElement( ElementName = "ContaBancariaNumero_Z"   )]
      public long gxTpr_Contabancarianumero_Z
      {
         get {
            return gxTv_SdtTitulo_Contabancarianumero_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Contabancarianumero_Z = value;
            SetDirty("Contabancarianumero_Z");
         }

      }

      public void gxTv_SdtTitulo_Contabancarianumero_Z_SetNull( )
      {
         gxTv_SdtTitulo_Contabancarianumero_Z = 0;
         SetDirty("Contabancarianumero_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Contabancarianumero_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaNumero_Z" )]
      [  XmlElement( ElementName = "AgenciaNumero_Z"   )]
      public int gxTpr_Agencianumero_Z
      {
         get {
            return gxTv_SdtTitulo_Agencianumero_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Agencianumero_Z = value;
            SetDirty("Agencianumero_Z");
         }

      }

      public void gxTv_SdtTitulo_Agencianumero_Z_SetNull( )
      {
         gxTv_SdtTitulo_Agencianumero_Z = 0;
         SetDirty("Agencianumero_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Agencianumero_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TitulosEmCarteiraDeCobranca_F_Z" )]
      [  XmlElement( ElementName = "TitulosEmCarteiraDeCobranca_F_Z"   )]
      public bool gxTpr_Titulosemcarteiradecobranca_f_Z
      {
         get {
            return gxTv_SdtTitulo_Titulosemcarteiradecobranca_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulosemcarteiradecobranca_f_Z = value;
            SetDirty("Titulosemcarteiradecobranca_f_Z");
         }

      }

      public void gxTv_SdtTitulo_Titulosemcarteiradecobranca_f_Z_SetNull( )
      {
         gxTv_SdtTitulo_Titulosemcarteiradecobranca_f_Z = false;
         SetDirty("Titulosemcarteiradecobranca_f_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulosemcarteiradecobranca_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TitulosCarteiraDeCobranca_Z" )]
      [  XmlElement( ElementName = "TitulosCarteiraDeCobranca_Z"   )]
      public string gxTpr_Tituloscarteiradecobranca_Z
      {
         get {
            return gxTv_SdtTitulo_Tituloscarteiradecobranca_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Tituloscarteiradecobranca_Z = value;
            SetDirty("Tituloscarteiradecobranca_Z");
         }

      }

      public void gxTv_SdtTitulo_Tituloscarteiradecobranca_Z_SetNull( )
      {
         gxTv_SdtTitulo_Tituloscarteiradecobranca_Z = "";
         SetDirty("Tituloscarteiradecobranca_Z");
         return  ;
      }

      public bool gxTv_SdtTitulo_Tituloscarteiradecobranca_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloId_N" )]
      [  XmlElement( ElementName = "TituloId_N"   )]
      public short gxTpr_Tituloid_N
      {
         get {
            return gxTv_SdtTitulo_Tituloid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Tituloid_N = value;
            SetDirty("Tituloid_N");
         }

      }

      public void gxTv_SdtTitulo_Tituloid_N_SetNull( )
      {
         gxTv_SdtTitulo_Tituloid_N = 0;
         SetDirty("Tituloid_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Tituloid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloClienteId_N" )]
      [  XmlElement( ElementName = "TituloClienteId_N"   )]
      public short gxTpr_Tituloclienteid_N
      {
         get {
            return gxTv_SdtTitulo_Tituloclienteid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Tituloclienteid_N = value;
            SetDirty("Tituloclienteid_N");
         }

      }

      public void gxTv_SdtTitulo_Tituloclienteid_N_SetNull( )
      {
         gxTv_SdtTitulo_Tituloclienteid_N = 0;
         SetDirty("Tituloclienteid_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Tituloclienteid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloCLienteRazaoSocial_N" )]
      [  XmlElement( ElementName = "TituloCLienteRazaoSocial_N"   )]
      public short gxTpr_Tituloclienterazaosocial_N
      {
         get {
            return gxTv_SdtTitulo_Tituloclienterazaosocial_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Tituloclienterazaosocial_N = value;
            SetDirty("Tituloclienterazaosocial_N");
         }

      }

      public void gxTv_SdtTitulo_Tituloclienterazaosocial_N_SetNull( )
      {
         gxTv_SdtTitulo_Tituloclienterazaosocial_N = 0;
         SetDirty("Tituloclienterazaosocial_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Tituloclienterazaosocial_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloValor_N" )]
      [  XmlElement( ElementName = "TituloValor_N"   )]
      public short gxTpr_Titulovalor_N
      {
         get {
            return gxTv_SdtTitulo_Titulovalor_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulovalor_N = value;
            SetDirty("Titulovalor_N");
         }

      }

      public void gxTv_SdtTitulo_Titulovalor_N_SetNull( )
      {
         gxTv_SdtTitulo_Titulovalor_N = 0;
         SetDirty("Titulovalor_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulovalor_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloDesconto_N" )]
      [  XmlElement( ElementName = "TituloDesconto_N"   )]
      public short gxTpr_Titulodesconto_N
      {
         get {
            return gxTv_SdtTitulo_Titulodesconto_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulodesconto_N = value;
            SetDirty("Titulodesconto_N");
         }

      }

      public void gxTv_SdtTitulo_Titulodesconto_N_SetNull( )
      {
         gxTv_SdtTitulo_Titulodesconto_N = 0;
         SetDirty("Titulodesconto_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulodesconto_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloDeleted_N" )]
      [  XmlElement( ElementName = "TituloDeleted_N"   )]
      public short gxTpr_Titulodeleted_N
      {
         get {
            return gxTv_SdtTitulo_Titulodeleted_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulodeleted_N = value;
            SetDirty("Titulodeleted_N");
         }

      }

      public void gxTv_SdtTitulo_Titulodeleted_N_SetNull( )
      {
         gxTv_SdtTitulo_Titulodeleted_N = 0;
         SetDirty("Titulodeleted_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulodeleted_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloArchived_N" )]
      [  XmlElement( ElementName = "TituloArchived_N"   )]
      public short gxTpr_Tituloarchived_N
      {
         get {
            return gxTv_SdtTitulo_Tituloarchived_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Tituloarchived_N = value;
            SetDirty("Tituloarchived_N");
         }

      }

      public void gxTv_SdtTitulo_Tituloarchived_N_SetNull( )
      {
         gxTv_SdtTitulo_Tituloarchived_N = 0;
         SetDirty("Tituloarchived_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Tituloarchived_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloVencimento_N" )]
      [  XmlElement( ElementName = "TituloVencimento_N"   )]
      public short gxTpr_Titulovencimento_N
      {
         get {
            return gxTv_SdtTitulo_Titulovencimento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulovencimento_N = value;
            SetDirty("Titulovencimento_N");
         }

      }

      public void gxTv_SdtTitulo_Titulovencimento_N_SetNull( )
      {
         gxTv_SdtTitulo_Titulovencimento_N = 0;
         SetDirty("Titulovencimento_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulovencimento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloCompetenciaAno_N" )]
      [  XmlElement( ElementName = "TituloCompetenciaAno_N"   )]
      public short gxTpr_Titulocompetenciaano_N
      {
         get {
            return gxTv_SdtTitulo_Titulocompetenciaano_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulocompetenciaano_N = value;
            SetDirty("Titulocompetenciaano_N");
         }

      }

      public void gxTv_SdtTitulo_Titulocompetenciaano_N_SetNull( )
      {
         gxTv_SdtTitulo_Titulocompetenciaano_N = 0;
         SetDirty("Titulocompetenciaano_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulocompetenciaano_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloCompetenciaMes_N" )]
      [  XmlElement( ElementName = "TituloCompetenciaMes_N"   )]
      public short gxTpr_Titulocompetenciames_N
      {
         get {
            return gxTv_SdtTitulo_Titulocompetenciames_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulocompetenciames_N = value;
            SetDirty("Titulocompetenciames_N");
         }

      }

      public void gxTv_SdtTitulo_Titulocompetenciames_N_SetNull( )
      {
         gxTv_SdtTitulo_Titulocompetenciames_N = 0;
         SetDirty("Titulocompetenciames_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulocompetenciames_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloProrrogacao_N" )]
      [  XmlElement( ElementName = "TituloProrrogacao_N"   )]
      public short gxTpr_Tituloprorrogacao_N
      {
         get {
            return gxTv_SdtTitulo_Tituloprorrogacao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Tituloprorrogacao_N = value;
            SetDirty("Tituloprorrogacao_N");
         }

      }

      public void gxTv_SdtTitulo_Tituloprorrogacao_N_SetNull( )
      {
         gxTv_SdtTitulo_Tituloprorrogacao_N = 0;
         SetDirty("Tituloprorrogacao_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Tituloprorrogacao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloCEP_N" )]
      [  XmlElement( ElementName = "TituloCEP_N"   )]
      public short gxTpr_Titulocep_N
      {
         get {
            return gxTv_SdtTitulo_Titulocep_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulocep_N = value;
            SetDirty("Titulocep_N");
         }

      }

      public void gxTv_SdtTitulo_Titulocep_N_SetNull( )
      {
         gxTv_SdtTitulo_Titulocep_N = 0;
         SetDirty("Titulocep_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulocep_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloLogradouro_N" )]
      [  XmlElement( ElementName = "TituloLogradouro_N"   )]
      public short gxTpr_Titulologradouro_N
      {
         get {
            return gxTv_SdtTitulo_Titulologradouro_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulologradouro_N = value;
            SetDirty("Titulologradouro_N");
         }

      }

      public void gxTv_SdtTitulo_Titulologradouro_N_SetNull( )
      {
         gxTv_SdtTitulo_Titulologradouro_N = 0;
         SetDirty("Titulologradouro_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulologradouro_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloNumeroEndereco_N" )]
      [  XmlElement( ElementName = "TituloNumeroEndereco_N"   )]
      public short gxTpr_Titulonumeroendereco_N
      {
         get {
            return gxTv_SdtTitulo_Titulonumeroendereco_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulonumeroendereco_N = value;
            SetDirty("Titulonumeroendereco_N");
         }

      }

      public void gxTv_SdtTitulo_Titulonumeroendereco_N_SetNull( )
      {
         gxTv_SdtTitulo_Titulonumeroendereco_N = 0;
         SetDirty("Titulonumeroendereco_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulonumeroendereco_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloComplemento_N" )]
      [  XmlElement( ElementName = "TituloComplemento_N"   )]
      public short gxTpr_Titulocomplemento_N
      {
         get {
            return gxTv_SdtTitulo_Titulocomplemento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulocomplemento_N = value;
            SetDirty("Titulocomplemento_N");
         }

      }

      public void gxTv_SdtTitulo_Titulocomplemento_N_SetNull( )
      {
         gxTv_SdtTitulo_Titulocomplemento_N = 0;
         SetDirty("Titulocomplemento_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulocomplemento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloBairro_N" )]
      [  XmlElement( ElementName = "TituloBairro_N"   )]
      public short gxTpr_Titulobairro_N
      {
         get {
            return gxTv_SdtTitulo_Titulobairro_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulobairro_N = value;
            SetDirty("Titulobairro_N");
         }

      }

      public void gxTv_SdtTitulo_Titulobairro_N_SetNull( )
      {
         gxTv_SdtTitulo_Titulobairro_N = 0;
         SetDirty("Titulobairro_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulobairro_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloMunicipio_N" )]
      [  XmlElement( ElementName = "TituloMunicipio_N"   )]
      public short gxTpr_Titulomunicipio_N
      {
         get {
            return gxTv_SdtTitulo_Titulomunicipio_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulomunicipio_N = value;
            SetDirty("Titulomunicipio_N");
         }

      }

      public void gxTv_SdtTitulo_Titulomunicipio_N_SetNull( )
      {
         gxTv_SdtTitulo_Titulomunicipio_N = 0;
         SetDirty("Titulomunicipio_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulomunicipio_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloJurosMora_N" )]
      [  XmlElement( ElementName = "TituloJurosMora_N"   )]
      public short gxTpr_Titulojurosmora_N
      {
         get {
            return gxTv_SdtTitulo_Titulojurosmora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulojurosmora_N = value;
            SetDirty("Titulojurosmora_N");
         }

      }

      public void gxTv_SdtTitulo_Titulojurosmora_N_SetNull( )
      {
         gxTv_SdtTitulo_Titulojurosmora_N = 0;
         SetDirty("Titulojurosmora_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulojurosmora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloTipo_N" )]
      [  XmlElement( ElementName = "TituloTipo_N"   )]
      public short gxTpr_Titulotipo_N
      {
         get {
            return gxTv_SdtTitulo_Titulotipo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulotipo_N = value;
            SetDirty("Titulotipo_N");
         }

      }

      public void gxTv_SdtTitulo_Titulotipo_N_SetNull( )
      {
         gxTv_SdtTitulo_Titulotipo_N = 0;
         SetDirty("Titulotipo_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulotipo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloPropostaId_N" )]
      [  XmlElement( ElementName = "TituloPropostaId_N"   )]
      public short gxTpr_Titulopropostaid_N
      {
         get {
            return gxTv_SdtTitulo_Titulopropostaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulopropostaid_N = value;
            SetDirty("Titulopropostaid_N");
         }

      }

      public void gxTv_SdtTitulo_Titulopropostaid_N_SetNull( )
      {
         gxTv_SdtTitulo_Titulopropostaid_N = 0;
         SetDirty("Titulopropostaid_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulopropostaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloPropostaDescricao_N" )]
      [  XmlElement( ElementName = "TituloPropostaDescricao_N"   )]
      public short gxTpr_Titulopropostadescricao_N
      {
         get {
            return gxTv_SdtTitulo_Titulopropostadescricao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulopropostadescricao_N = value;
            SetDirty("Titulopropostadescricao_N");
         }

      }

      public void gxTv_SdtTitulo_Titulopropostadescricao_N_SetNull( )
      {
         gxTv_SdtTitulo_Titulopropostadescricao_N = 0;
         SetDirty("Titulopropostadescricao_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulopropostadescricao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaTaxaAdministrativa_N" )]
      [  XmlElement( ElementName = "PropostaTaxaAdministrativa_N"   )]
      public short gxTpr_Propostataxaadministrativa_N
      {
         get {
            return gxTv_SdtTitulo_Propostataxaadministrativa_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Propostataxaadministrativa_N = value;
            SetDirty("Propostataxaadministrativa_N");
         }

      }

      public void gxTv_SdtTitulo_Propostataxaadministrativa_N_SetNull( )
      {
         gxTv_SdtTitulo_Propostataxaadministrativa_N = 0;
         SetDirty("Propostataxaadministrativa_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Propostataxaadministrativa_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaId_N" )]
      [  XmlElement( ElementName = "ContaId_N"   )]
      public short gxTpr_Contaid_N
      {
         get {
            return gxTv_SdtTitulo_Contaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Contaid_N = value;
            SetDirty("Contaid_N");
         }

      }

      public void gxTv_SdtTitulo_Contaid_N_SetNull( )
      {
         gxTv_SdtTitulo_Contaid_N = 0;
         SetDirty("Contaid_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Contaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloCriacao_N" )]
      [  XmlElement( ElementName = "TituloCriacao_N"   )]
      public short gxTpr_Titulocriacao_N
      {
         get {
            return gxTv_SdtTitulo_Titulocriacao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulocriacao_N = value;
            SetDirty("Titulocriacao_N");
         }

      }

      public void gxTv_SdtTitulo_Titulocriacao_N_SetNull( )
      {
         gxTv_SdtTitulo_Titulocriacao_N = 0;
         SetDirty("Titulocriacao_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulocriacao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoriaTituloId_N" )]
      [  XmlElement( ElementName = "CategoriaTituloId_N"   )]
      public short gxTpr_Categoriatituloid_N
      {
         get {
            return gxTv_SdtTitulo_Categoriatituloid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Categoriatituloid_N = value;
            SetDirty("Categoriatituloid_N");
         }

      }

      public void gxTv_SdtTitulo_Categoriatituloid_N_SetNull( )
      {
         gxTv_SdtTitulo_Categoriatituloid_N = 0;
         SetDirty("Categoriatituloid_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Categoriatituloid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloDataCredito_F_N" )]
      [  XmlElement( ElementName = "TituloDataCredito_F_N"   )]
      public short gxTpr_Titulodatacredito_f_N
      {
         get {
            return gxTv_SdtTitulo_Titulodatacredito_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulodatacredito_f_N = value;
            SetDirty("Titulodatacredito_f_N");
         }

      }

      public void gxTv_SdtTitulo_Titulodatacredito_f_N_SetNull( )
      {
         gxTv_SdtTitulo_Titulodatacredito_f_N = 0;
         SetDirty("Titulodatacredito_f_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulodatacredito_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloTotalMovimento_F_N" )]
      [  XmlElement( ElementName = "TituloTotalMovimento_F_N"   )]
      public short gxTpr_Titulototalmovimento_f_N
      {
         get {
            return gxTv_SdtTitulo_Titulototalmovimento_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulototalmovimento_f_N = value;
            SetDirty("Titulototalmovimento_f_N");
         }

      }

      public void gxTv_SdtTitulo_Titulototalmovimento_f_N_SetNull( )
      {
         gxTv_SdtTitulo_Titulototalmovimento_f_N = 0;
         SetDirty("Titulototalmovimento_f_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulototalmovimento_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloTotalMultaJuros_F_N" )]
      [  XmlElement( ElementName = "TituloTotalMultaJuros_F_N"   )]
      public short gxTpr_Titulototalmultajuros_f_N
      {
         get {
            return gxTv_SdtTitulo_Titulototalmultajuros_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulototalmultajuros_f_N = value;
            SetDirty("Titulototalmultajuros_f_N");
         }

      }

      public void gxTv_SdtTitulo_Titulototalmultajuros_f_N_SetNull( )
      {
         gxTv_SdtTitulo_Titulototalmultajuros_f_N = 0;
         SetDirty("Titulototalmultajuros_f_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulototalmultajuros_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloPropostaTipo_N" )]
      [  XmlElement( ElementName = "TituloPropostaTipo_N"   )]
      public short gxTpr_Titulopropostatipo_N
      {
         get {
            return gxTv_SdtTitulo_Titulopropostatipo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Titulopropostatipo_N = value;
            SetDirty("Titulopropostatipo_N");
         }

      }

      public void gxTv_SdtTitulo_Titulopropostatipo_N_SetNull( )
      {
         gxTv_SdtTitulo_Titulopropostatipo_N = 0;
         SetDirty("Titulopropostatipo_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Titulopropostatipo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalParcelamentoID_N" )]
      [  XmlElement( ElementName = "NotaFiscalParcelamentoID_N"   )]
      public short gxTpr_Notafiscalparcelamentoid_N
      {
         get {
            return gxTv_SdtTitulo_Notafiscalparcelamentoid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Notafiscalparcelamentoid_N = value;
            SetDirty("Notafiscalparcelamentoid_N");
         }

      }

      public void gxTv_SdtTitulo_Notafiscalparcelamentoid_N_SetNull( )
      {
         gxTv_SdtTitulo_Notafiscalparcelamentoid_N = 0;
         SetDirty("Notafiscalparcelamentoid_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Notafiscalparcelamentoid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalNumero_N" )]
      [  XmlElement( ElementName = "NotaFiscalNumero_N"   )]
      public short gxTpr_Notafiscalnumero_N
      {
         get {
            return gxTv_SdtTitulo_Notafiscalnumero_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Notafiscalnumero_N = value;
            SetDirty("Notafiscalnumero_N");
         }

      }

      public void gxTv_SdtTitulo_Notafiscalnumero_N_SetNull( )
      {
         gxTv_SdtTitulo_Notafiscalnumero_N = 0;
         SetDirty("Notafiscalnumero_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Notafiscalnumero_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaId_N" )]
      [  XmlElement( ElementName = "ContaBancariaId_N"   )]
      public short gxTpr_Contabancariaid_N
      {
         get {
            return gxTv_SdtTitulo_Contabancariaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Contabancariaid_N = value;
            SetDirty("Contabancariaid_N");
         }

      }

      public void gxTv_SdtTitulo_Contabancariaid_N_SetNull( )
      {
         gxTv_SdtTitulo_Contabancariaid_N = 0;
         SetDirty("Contabancariaid_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Contabancariaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaBancoNome_N" )]
      [  XmlElement( ElementName = "AgenciaBancoNome_N"   )]
      public short gxTpr_Agenciabanconome_N
      {
         get {
            return gxTv_SdtTitulo_Agenciabanconome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Agenciabanconome_N = value;
            SetDirty("Agenciabanconome_N");
         }

      }

      public void gxTv_SdtTitulo_Agenciabanconome_N_SetNull( )
      {
         gxTv_SdtTitulo_Agenciabanconome_N = 0;
         SetDirty("Agenciabanconome_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Agenciabanconome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaCarteira_N" )]
      [  XmlElement( ElementName = "ContaBancariaCarteira_N"   )]
      public short gxTpr_Contabancariacarteira_N
      {
         get {
            return gxTv_SdtTitulo_Contabancariacarteira_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Contabancariacarteira_N = value;
            SetDirty("Contabancariacarteira_N");
         }

      }

      public void gxTv_SdtTitulo_Contabancariacarteira_N_SetNull( )
      {
         gxTv_SdtTitulo_Contabancariacarteira_N = 0;
         SetDirty("Contabancariacarteira_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Contabancariacarteira_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaNumero_N" )]
      [  XmlElement( ElementName = "ContaBancariaNumero_N"   )]
      public short gxTpr_Contabancarianumero_N
      {
         get {
            return gxTv_SdtTitulo_Contabancarianumero_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Contabancarianumero_N = value;
            SetDirty("Contabancarianumero_N");
         }

      }

      public void gxTv_SdtTitulo_Contabancarianumero_N_SetNull( )
      {
         gxTv_SdtTitulo_Contabancarianumero_N = 0;
         SetDirty("Contabancarianumero_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Contabancarianumero_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaNumero_N" )]
      [  XmlElement( ElementName = "AgenciaNumero_N"   )]
      public short gxTpr_Agencianumero_N
      {
         get {
            return gxTv_SdtTitulo_Agencianumero_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Agencianumero_N = value;
            SetDirty("Agencianumero_N");
         }

      }

      public void gxTv_SdtTitulo_Agencianumero_N_SetNull( )
      {
         gxTv_SdtTitulo_Agencianumero_N = 0;
         SetDirty("Agencianumero_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Agencianumero_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TitulosCarteiraDeCobranca_N" )]
      [  XmlElement( ElementName = "TitulosCarteiraDeCobranca_N"   )]
      public short gxTpr_Tituloscarteiradecobranca_N
      {
         get {
            return gxTv_SdtTitulo_Tituloscarteiradecobranca_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTitulo_Tituloscarteiradecobranca_N = value;
            SetDirty("Tituloscarteiradecobranca_N");
         }

      }

      public void gxTv_SdtTitulo_Tituloscarteiradecobranca_N_SetNull( )
      {
         gxTv_SdtTitulo_Tituloscarteiradecobranca_N = 0;
         SetDirty("Tituloscarteiradecobranca_N");
         return  ;
      }

      public bool gxTv_SdtTitulo_Tituloscarteiradecobranca_N_IsNull( )
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
         gxTv_SdtTitulo_Tituloclienterazaosocial = "";
         gxTv_SdtTitulo_Titulovencimento = DateTime.MinValue;
         gxTv_SdtTitulo_Titulocompetencia_f = "";
         gxTv_SdtTitulo_Tituloprorrogacao = DateTime.MinValue;
         gxTv_SdtTitulo_Titulocep = "";
         gxTv_SdtTitulo_Titulologradouro = "";
         gxTv_SdtTitulo_Titulonumeroendereco = "";
         gxTv_SdtTitulo_Titulocomplemento = "";
         gxTv_SdtTitulo_Titulobairro = "";
         gxTv_SdtTitulo_Titulomunicipio = "";
         gxTv_SdtTitulo_Titulotipo = "";
         gxTv_SdtTitulo_Titulopropostadescricao = "";
         gxTv_SdtTitulo_Titulocriacao = (DateTime)(DateTime.MinValue);
         gxTv_SdtTitulo_Titulodatacredito_f = DateTime.MinValue;
         gxTv_SdtTitulo_Titulostatus_f = "";
         gxTv_SdtTitulo_Titulopropostatipo = "";
         gxTv_SdtTitulo_Notafiscalparcelamentoid = Guid.Empty;
         gxTv_SdtTitulo_Notafiscalnumero = "";
         gxTv_SdtTitulo_Agenciabanconome = "";
         gxTv_SdtTitulo_Tituloscarteiradecobranca = "";
         gxTv_SdtTitulo_Mode = "";
         gxTv_SdtTitulo_Tituloclienterazaosocial_Z = "";
         gxTv_SdtTitulo_Titulovencimento_Z = DateTime.MinValue;
         gxTv_SdtTitulo_Titulocompetencia_f_Z = "";
         gxTv_SdtTitulo_Tituloprorrogacao_Z = DateTime.MinValue;
         gxTv_SdtTitulo_Titulocep_Z = "";
         gxTv_SdtTitulo_Titulologradouro_Z = "";
         gxTv_SdtTitulo_Titulonumeroendereco_Z = "";
         gxTv_SdtTitulo_Titulocomplemento_Z = "";
         gxTv_SdtTitulo_Titulobairro_Z = "";
         gxTv_SdtTitulo_Titulomunicipio_Z = "";
         gxTv_SdtTitulo_Titulotipo_Z = "";
         gxTv_SdtTitulo_Titulopropostadescricao_Z = "";
         gxTv_SdtTitulo_Titulocriacao_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtTitulo_Titulodatacredito_f_Z = DateTime.MinValue;
         gxTv_SdtTitulo_Titulostatus_f_Z = "";
         gxTv_SdtTitulo_Titulopropostatipo_Z = "";
         gxTv_SdtTitulo_Notafiscalparcelamentoid_Z = Guid.Empty;
         gxTv_SdtTitulo_Notafiscalnumero_Z = "";
         gxTv_SdtTitulo_Agenciabanconome_Z = "";
         gxTv_SdtTitulo_Tituloscarteiradecobranca_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "titulo", "GeneXus.Programs.titulo_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTitulo_Titulocompetenciaano ;
      private short gxTv_SdtTitulo_Titulocompetenciames ;
      private short gxTv_SdtTitulo_Initialized ;
      private short gxTv_SdtTitulo_Titulocompetenciaano_Z ;
      private short gxTv_SdtTitulo_Titulocompetenciames_Z ;
      private short gxTv_SdtTitulo_Tituloid_N ;
      private short gxTv_SdtTitulo_Tituloclienteid_N ;
      private short gxTv_SdtTitulo_Tituloclienterazaosocial_N ;
      private short gxTv_SdtTitulo_Titulovalor_N ;
      private short gxTv_SdtTitulo_Titulodesconto_N ;
      private short gxTv_SdtTitulo_Titulodeleted_N ;
      private short gxTv_SdtTitulo_Tituloarchived_N ;
      private short gxTv_SdtTitulo_Titulovencimento_N ;
      private short gxTv_SdtTitulo_Titulocompetenciaano_N ;
      private short gxTv_SdtTitulo_Titulocompetenciames_N ;
      private short gxTv_SdtTitulo_Tituloprorrogacao_N ;
      private short gxTv_SdtTitulo_Titulocep_N ;
      private short gxTv_SdtTitulo_Titulologradouro_N ;
      private short gxTv_SdtTitulo_Titulonumeroendereco_N ;
      private short gxTv_SdtTitulo_Titulocomplemento_N ;
      private short gxTv_SdtTitulo_Titulobairro_N ;
      private short gxTv_SdtTitulo_Titulomunicipio_N ;
      private short gxTv_SdtTitulo_Titulojurosmora_N ;
      private short gxTv_SdtTitulo_Titulotipo_N ;
      private short gxTv_SdtTitulo_Titulopropostaid_N ;
      private short gxTv_SdtTitulo_Titulopropostadescricao_N ;
      private short gxTv_SdtTitulo_Propostataxaadministrativa_N ;
      private short gxTv_SdtTitulo_Contaid_N ;
      private short gxTv_SdtTitulo_Titulocriacao_N ;
      private short gxTv_SdtTitulo_Categoriatituloid_N ;
      private short gxTv_SdtTitulo_Titulodatacredito_f_N ;
      private short gxTv_SdtTitulo_Titulototalmovimento_f_N ;
      private short gxTv_SdtTitulo_Titulototalmultajuros_f_N ;
      private short gxTv_SdtTitulo_Titulopropostatipo_N ;
      private short gxTv_SdtTitulo_Notafiscalparcelamentoid_N ;
      private short gxTv_SdtTitulo_Notafiscalnumero_N ;
      private short gxTv_SdtTitulo_Contabancariaid_N ;
      private short gxTv_SdtTitulo_Agenciabanconome_N ;
      private short gxTv_SdtTitulo_Contabancariacarteira_N ;
      private short gxTv_SdtTitulo_Contabancarianumero_N ;
      private short gxTv_SdtTitulo_Agencianumero_N ;
      private short gxTv_SdtTitulo_Tituloscarteiradecobranca_N ;
      private int gxTv_SdtTitulo_Tituloid ;
      private int gxTv_SdtTitulo_Tituloclienteid ;
      private int gxTv_SdtTitulo_Titulopropostaid ;
      private int gxTv_SdtTitulo_Contaid ;
      private int gxTv_SdtTitulo_Categoriatituloid ;
      private int gxTv_SdtTitulo_Contabancariaid ;
      private int gxTv_SdtTitulo_Agencianumero ;
      private int gxTv_SdtTitulo_Tituloid_Z ;
      private int gxTv_SdtTitulo_Tituloclienteid_Z ;
      private int gxTv_SdtTitulo_Titulopropostaid_Z ;
      private int gxTv_SdtTitulo_Contaid_Z ;
      private int gxTv_SdtTitulo_Categoriatituloid_Z ;
      private int gxTv_SdtTitulo_Contabancariaid_Z ;
      private int gxTv_SdtTitulo_Agencianumero_Z ;
      private long gxTv_SdtTitulo_Contabancariacarteira ;
      private long gxTv_SdtTitulo_Contabancarianumero ;
      private long gxTv_SdtTitulo_Contabancariacarteira_Z ;
      private long gxTv_SdtTitulo_Contabancarianumero_Z ;
      private decimal gxTv_SdtTitulo_Titulovalor ;
      private decimal gxTv_SdtTitulo_Titulodesconto ;
      private decimal gxTv_SdtTitulo_Titulojurosmora ;
      private decimal gxTv_SdtTitulo_Propostataxaadministrativa ;
      private decimal gxTv_SdtTitulo_Titulototalmovimento_f ;
      private decimal gxTv_SdtTitulo_Titulototalmultajuros_f ;
      private decimal gxTv_SdtTitulo_Titulosaldo_f ;
      private decimal gxTv_SdtTitulo_Titulosaldodebito_f ;
      private decimal gxTv_SdtTitulo_Titulosaldocredito_f ;
      private decimal gxTv_SdtTitulo_Titulototalmovimentodebito_f ;
      private decimal gxTv_SdtTitulo_Titulototalmovimentocredito_f ;
      private decimal gxTv_SdtTitulo_Titulototalmultajurosdebito_f ;
      private decimal gxTv_SdtTitulo_Titulototalmultajuroscredito_f ;
      private decimal gxTv_SdtTitulo_Titulovalor_Z ;
      private decimal gxTv_SdtTitulo_Titulodesconto_Z ;
      private decimal gxTv_SdtTitulo_Titulojurosmora_Z ;
      private decimal gxTv_SdtTitulo_Propostataxaadministrativa_Z ;
      private decimal gxTv_SdtTitulo_Titulototalmovimento_f_Z ;
      private decimal gxTv_SdtTitulo_Titulototalmultajuros_f_Z ;
      private decimal gxTv_SdtTitulo_Titulosaldo_f_Z ;
      private decimal gxTv_SdtTitulo_Titulosaldodebito_f_Z ;
      private decimal gxTv_SdtTitulo_Titulosaldocredito_f_Z ;
      private decimal gxTv_SdtTitulo_Titulototalmovimentodebito_f_Z ;
      private decimal gxTv_SdtTitulo_Titulototalmovimentocredito_f_Z ;
      private decimal gxTv_SdtTitulo_Titulototalmultajurosdebito_f_Z ;
      private decimal gxTv_SdtTitulo_Titulototalmultajuroscredito_f_Z ;
      private string gxTv_SdtTitulo_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtTitulo_Titulocriacao ;
      private DateTime gxTv_SdtTitulo_Titulocriacao_Z ;
      private DateTime datetime_STZ ;
      private DateTime gxTv_SdtTitulo_Titulovencimento ;
      private DateTime gxTv_SdtTitulo_Tituloprorrogacao ;
      private DateTime gxTv_SdtTitulo_Titulodatacredito_f ;
      private DateTime gxTv_SdtTitulo_Titulovencimento_Z ;
      private DateTime gxTv_SdtTitulo_Tituloprorrogacao_Z ;
      private DateTime gxTv_SdtTitulo_Titulodatacredito_f_Z ;
      private bool gxTv_SdtTitulo_Titulodeleted ;
      private bool gxTv_SdtTitulo_Tituloarchived ;
      private bool gxTv_SdtTitulo_Titulosemcarteiradecobranca_f ;
      private bool gxTv_SdtTitulo_Titulodeleted_Z ;
      private bool gxTv_SdtTitulo_Tituloarchived_Z ;
      private bool gxTv_SdtTitulo_Titulosemcarteiradecobranca_f_Z ;
      private string gxTv_SdtTitulo_Tituloclienterazaosocial ;
      private string gxTv_SdtTitulo_Titulocompetencia_f ;
      private string gxTv_SdtTitulo_Titulocep ;
      private string gxTv_SdtTitulo_Titulologradouro ;
      private string gxTv_SdtTitulo_Titulonumeroendereco ;
      private string gxTv_SdtTitulo_Titulocomplemento ;
      private string gxTv_SdtTitulo_Titulobairro ;
      private string gxTv_SdtTitulo_Titulomunicipio ;
      private string gxTv_SdtTitulo_Titulotipo ;
      private string gxTv_SdtTitulo_Titulopropostadescricao ;
      private string gxTv_SdtTitulo_Titulostatus_f ;
      private string gxTv_SdtTitulo_Titulopropostatipo ;
      private string gxTv_SdtTitulo_Notafiscalnumero ;
      private string gxTv_SdtTitulo_Agenciabanconome ;
      private string gxTv_SdtTitulo_Tituloscarteiradecobranca ;
      private string gxTv_SdtTitulo_Tituloclienterazaosocial_Z ;
      private string gxTv_SdtTitulo_Titulocompetencia_f_Z ;
      private string gxTv_SdtTitulo_Titulocep_Z ;
      private string gxTv_SdtTitulo_Titulologradouro_Z ;
      private string gxTv_SdtTitulo_Titulonumeroendereco_Z ;
      private string gxTv_SdtTitulo_Titulocomplemento_Z ;
      private string gxTv_SdtTitulo_Titulobairro_Z ;
      private string gxTv_SdtTitulo_Titulomunicipio_Z ;
      private string gxTv_SdtTitulo_Titulotipo_Z ;
      private string gxTv_SdtTitulo_Titulopropostadescricao_Z ;
      private string gxTv_SdtTitulo_Titulostatus_f_Z ;
      private string gxTv_SdtTitulo_Titulopropostatipo_Z ;
      private string gxTv_SdtTitulo_Notafiscalnumero_Z ;
      private string gxTv_SdtTitulo_Agenciabanconome_Z ;
      private string gxTv_SdtTitulo_Tituloscarteiradecobranca_Z ;
      private Guid gxTv_SdtTitulo_Notafiscalparcelamentoid ;
      private Guid gxTv_SdtTitulo_Notafiscalparcelamentoid_Z ;
   }

   [DataContract(Name = @"Titulo", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtTitulo_RESTInterface : GxGenericCollectionItem<SdtTitulo>
   {
      public SdtTitulo_RESTInterface( ) : base()
      {
      }

      public SdtTitulo_RESTInterface( SdtTitulo psdt ) : base(psdt)
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

      [DataMember( Name = "TituloClienteId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Tituloclienteid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Tituloclienteid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Tituloclienteid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "TituloCLienteRazaoSocial" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Tituloclienterazaosocial
      {
         get {
            return sdt.gxTpr_Tituloclienterazaosocial ;
         }

         set {
            sdt.gxTpr_Tituloclienterazaosocial = value;
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

      [DataMember( Name = "TituloPropostaDescricao" , Order = 21 )]
      [GxSeudo()]
      public string gxTpr_Titulopropostadescricao
      {
         get {
            return sdt.gxTpr_Titulopropostadescricao ;
         }

         set {
            sdt.gxTpr_Titulopropostadescricao = value;
         }

      }

      [DataMember( Name = "PropostaTaxaAdministrativa" , Order = 22 )]
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

      [DataMember( Name = "ContaId" , Order = 23 )]
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

      [DataMember( Name = "TituloCriacao" , Order = 24 )]
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

      [DataMember( Name = "CategoriaTituloId" , Order = 25 )]
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

      [DataMember( Name = "TituloDataCredito_F" , Order = 26 )]
      [GxSeudo()]
      public string gxTpr_Titulodatacredito_f
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Titulodatacredito_f) ;
         }

         set {
            sdt.gxTpr_Titulodatacredito_f = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "TituloTotalMovimento_F" , Order = 27 )]
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

      [DataMember( Name = "TituloTotalMultaJuros_F" , Order = 28 )]
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

      [DataMember( Name = "TituloSaldo_F" , Order = 29 )]
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

      [DataMember( Name = "TituloStatus_F" , Order = 30 )]
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

      [DataMember( Name = "TituloSaldoDebito_F" , Order = 31 )]
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

      [DataMember( Name = "TituloSaldoCredito_F" , Order = 32 )]
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

      [DataMember( Name = "TituloTotalMovimentoDebito_F" , Order = 33 )]
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

      [DataMember( Name = "TituloTotalMovimentoCredito_F" , Order = 34 )]
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

      [DataMember( Name = "TituloTotalMultaJurosDebito_F" , Order = 35 )]
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

      [DataMember( Name = "TituloTotalMultaJurosCredito_F" , Order = 36 )]
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

      [DataMember( Name = "TituloPropostaTipo" , Order = 37 )]
      [GxSeudo()]
      public string gxTpr_Titulopropostatipo
      {
         get {
            return sdt.gxTpr_Titulopropostatipo ;
         }

         set {
            sdt.gxTpr_Titulopropostatipo = value;
         }

      }

      [DataMember( Name = "NotaFiscalParcelamentoID" , Order = 38 )]
      [GxSeudo()]
      public Guid gxTpr_Notafiscalparcelamentoid
      {
         get {
            return sdt.gxTpr_Notafiscalparcelamentoid ;
         }

         set {
            sdt.gxTpr_Notafiscalparcelamentoid = value;
         }

      }

      [DataMember( Name = "NotaFiscalNumero" , Order = 39 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalnumero
      {
         get {
            return sdt.gxTpr_Notafiscalnumero ;
         }

         set {
            sdt.gxTpr_Notafiscalnumero = value;
         }

      }

      [DataMember( Name = "ContaBancariaId" , Order = 40 )]
      [GxSeudo()]
      public string gxTpr_Contabancariaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Contabancariaid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Contabancariaid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "AgenciaBancoNome" , Order = 41 )]
      [GxSeudo()]
      public string gxTpr_Agenciabanconome
      {
         get {
            return sdt.gxTpr_Agenciabanconome ;
         }

         set {
            sdt.gxTpr_Agenciabanconome = value;
         }

      }

      [DataMember( Name = "ContaBancariaCarteira" , Order = 42 )]
      [GxSeudo()]
      public string gxTpr_Contabancariacarteira
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Contabancariacarteira), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Contabancariacarteira = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ContaBancariaNumero" , Order = 43 )]
      [GxSeudo()]
      public string gxTpr_Contabancarianumero
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Contabancarianumero), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Contabancarianumero = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "AgenciaNumero" , Order = 44 )]
      [GxSeudo()]
      public string gxTpr_Agencianumero
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Agencianumero), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Agencianumero = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "TitulosEmCarteiraDeCobranca_F" , Order = 45 )]
      [GxSeudo()]
      public bool gxTpr_Titulosemcarteiradecobranca_f
      {
         get {
            return sdt.gxTpr_Titulosemcarteiradecobranca_f ;
         }

         set {
            sdt.gxTpr_Titulosemcarteiradecobranca_f = value;
         }

      }

      [DataMember( Name = "TitulosCarteiraDeCobranca" , Order = 46 )]
      [GxSeudo()]
      public string gxTpr_Tituloscarteiradecobranca
      {
         get {
            return sdt.gxTpr_Tituloscarteiradecobranca ;
         }

         set {
            sdt.gxTpr_Tituloscarteiradecobranca = value;
         }

      }

      public SdtTitulo sdt
      {
         get {
            return (SdtTitulo)Sdt ;
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
            sdt = new SdtTitulo() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 47 )]
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

   [DataContract(Name = @"Titulo", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtTitulo_RESTLInterface : GxGenericCollectionItem<SdtTitulo>
   {
      public SdtTitulo_RESTLInterface( ) : base()
      {
      }

      public SdtTitulo_RESTLInterface( SdtTitulo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TituloCLienteRazaoSocial" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Tituloclienterazaosocial
      {
         get {
            return sdt.gxTpr_Tituloclienterazaosocial ;
         }

         set {
            sdt.gxTpr_Tituloclienterazaosocial = value;
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

      public SdtTitulo sdt
      {
         get {
            return (SdtTitulo)Sdt ;
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
            sdt = new SdtTitulo() ;
         }
      }

   }

}
