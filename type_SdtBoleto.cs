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
   [XmlRoot(ElementName = "Boleto" )]
   [XmlType(TypeName =  "Boleto" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtBoleto : GxSilentTrnSdt
   {
      public SdtBoleto( )
      {
      }

      public SdtBoleto( IGxContext context )
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

      public void Load( int AV1077BoletosId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV1077BoletosId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"BoletosId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Boleto");
         metadata.Set("BT", "Boleto");
         metadata.Set("PK", "[ \"BoletosId\" ]");
         metadata.Set("PKAssigned", "[ \"BoletosId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"CarteiraDeCobrancaId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"TituloId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Boletosid_Z");
         state.Add("gxTpr_Carteiradecobrancaid_Z");
         state.Add("gxTpr_Tituloid_Z");
         state.Add("gxTpr_Boletosnossonumero_Z");
         state.Add("gxTpr_Boletosseunumero_Z");
         state.Add("gxTpr_Boletosnumero_Z");
         state.Add("gxTpr_Boletoslinhadigitavel_Z");
         state.Add("gxTpr_Boletoscodigodebarras_Z");
         state.Add("gxTpr_Boletosstatus_Z");
         state.Add("gxTpr_Boletosdataemissao_Z_Nullable");
         state.Add("gxTpr_Boletosdatavencimento_Z_Nullable");
         state.Add("gxTpr_Boletosdataregistro_Z_Nullable");
         state.Add("gxTpr_Boletosdatapagamento_Z_Nullable");
         state.Add("gxTpr_Boletosdatabaixa_Z_Nullable");
         state.Add("gxTpr_Boletosvalornominal_Z");
         state.Add("gxTpr_Boletosvalorpago_Z");
         state.Add("gxTpr_Boletosvalordesconto_Z");
         state.Add("gxTpr_Boletosvalorjuros_Z");
         state.Add("gxTpr_Boletosvalormulta_Z");
         state.Add("gxTpr_Boletossacadonome_Z");
         state.Add("gxTpr_Boletossacadodocumento_Z");
         state.Add("gxTpr_Boletossacadotipodocumento_Z");
         state.Add("gxTpr_Boletostentativasderegistro_Z");
         state.Add("gxTpr_Boletoscreatedat_Z_Nullable");
         state.Add("gxTpr_Boletosupdatedat_Z_Nullable");
         state.Add("gxTpr_Boletosresgitroid_Z");
         state.Add("gxTpr_Carteiradecobrancanome_Z");
         state.Add("gxTpr_Carteiradecobrancaconvenio_Z");
         state.Add("gxTpr_Carteiradecobrancastatus_Z");
         state.Add("gxTpr_Carteiradecobrancavalortotal_Z");
         state.Add("gxTpr_Carteiradecobrancavalorrecebido_Z");
         state.Add("gxTpr_Carteiradecobrancatotalboletos_Z");
         state.Add("gxTpr_Carteiradecobrancatotalboletosregistrados_Z");
         state.Add("gxTpr_Carteiradecobrancatotalboletosexpirados_Z");
         state.Add("gxTpr_Carteiradecobrancatotalboletoscancelados_Z");
         state.Add("gxTpr_Boletosid_N");
         state.Add("gxTpr_Carteiradecobrancaid_N");
         state.Add("gxTpr_Tituloid_N");
         state.Add("gxTpr_Boletosnossonumero_N");
         state.Add("gxTpr_Boletosseunumero_N");
         state.Add("gxTpr_Boletosnumero_N");
         state.Add("gxTpr_Boletoslinhadigitavel_N");
         state.Add("gxTpr_Boletoscodigodebarras_N");
         state.Add("gxTpr_Boletosstatus_N");
         state.Add("gxTpr_Boletosdataemissao_N");
         state.Add("gxTpr_Boletosdatavencimento_N");
         state.Add("gxTpr_Boletosdataregistro_N");
         state.Add("gxTpr_Boletosdatapagamento_N");
         state.Add("gxTpr_Boletosdatabaixa_N");
         state.Add("gxTpr_Boletosvalornominal_N");
         state.Add("gxTpr_Boletosvalorpago_N");
         state.Add("gxTpr_Boletosvalordesconto_N");
         state.Add("gxTpr_Boletosvalorjuros_N");
         state.Add("gxTpr_Boletosvalormulta_N");
         state.Add("gxTpr_Boletossacadonome_N");
         state.Add("gxTpr_Boletossacadodocumento_N");
         state.Add("gxTpr_Boletossacadotipodocumento_N");
         state.Add("gxTpr_Boletosmensagemdeerro_N");
         state.Add("gxTpr_Boletostentativasderegistro_N");
         state.Add("gxTpr_Boletoscreatedat_N");
         state.Add("gxTpr_Boletosupdatedat_N");
         state.Add("gxTpr_Boletosresgitroid_N");
         state.Add("gxTpr_Carteiradecobrancanome_N");
         state.Add("gxTpr_Carteiradecobrancaconvenio_N");
         state.Add("gxTpr_Carteiradecobrancastatus_N");
         state.Add("gxTpr_Carteiradecobrancatotalboletosregistrados_N");
         state.Add("gxTpr_Carteiradecobrancatotalboletosexpirados_N");
         state.Add("gxTpr_Carteiradecobrancatotalboletoscancelados_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtBoleto sdt;
         sdt = (SdtBoleto)(source);
         gxTv_SdtBoleto_Boletosid = sdt.gxTv_SdtBoleto_Boletosid ;
         gxTv_SdtBoleto_Carteiradecobrancaid = sdt.gxTv_SdtBoleto_Carteiradecobrancaid ;
         gxTv_SdtBoleto_Tituloid = sdt.gxTv_SdtBoleto_Tituloid ;
         gxTv_SdtBoleto_Boletosnossonumero = sdt.gxTv_SdtBoleto_Boletosnossonumero ;
         gxTv_SdtBoleto_Boletosseunumero = sdt.gxTv_SdtBoleto_Boletosseunumero ;
         gxTv_SdtBoleto_Boletosnumero = sdt.gxTv_SdtBoleto_Boletosnumero ;
         gxTv_SdtBoleto_Boletoslinhadigitavel = sdt.gxTv_SdtBoleto_Boletoslinhadigitavel ;
         gxTv_SdtBoleto_Boletoscodigodebarras = sdt.gxTv_SdtBoleto_Boletoscodigodebarras ;
         gxTv_SdtBoleto_Boletosstatus = sdt.gxTv_SdtBoleto_Boletosstatus ;
         gxTv_SdtBoleto_Boletosdataemissao = sdt.gxTv_SdtBoleto_Boletosdataemissao ;
         gxTv_SdtBoleto_Boletosdatavencimento = sdt.gxTv_SdtBoleto_Boletosdatavencimento ;
         gxTv_SdtBoleto_Boletosdataregistro = sdt.gxTv_SdtBoleto_Boletosdataregistro ;
         gxTv_SdtBoleto_Boletosdatapagamento = sdt.gxTv_SdtBoleto_Boletosdatapagamento ;
         gxTv_SdtBoleto_Boletosdatabaixa = sdt.gxTv_SdtBoleto_Boletosdatabaixa ;
         gxTv_SdtBoleto_Boletosvalornominal = sdt.gxTv_SdtBoleto_Boletosvalornominal ;
         gxTv_SdtBoleto_Boletosvalorpago = sdt.gxTv_SdtBoleto_Boletosvalorpago ;
         gxTv_SdtBoleto_Boletosvalordesconto = sdt.gxTv_SdtBoleto_Boletosvalordesconto ;
         gxTv_SdtBoleto_Boletosvalorjuros = sdt.gxTv_SdtBoleto_Boletosvalorjuros ;
         gxTv_SdtBoleto_Boletosvalormulta = sdt.gxTv_SdtBoleto_Boletosvalormulta ;
         gxTv_SdtBoleto_Boletossacadonome = sdt.gxTv_SdtBoleto_Boletossacadonome ;
         gxTv_SdtBoleto_Boletossacadodocumento = sdt.gxTv_SdtBoleto_Boletossacadodocumento ;
         gxTv_SdtBoleto_Boletossacadotipodocumento = sdt.gxTv_SdtBoleto_Boletossacadotipodocumento ;
         gxTv_SdtBoleto_Boletosmensagemdeerro = sdt.gxTv_SdtBoleto_Boletosmensagemdeerro ;
         gxTv_SdtBoleto_Boletostentativasderegistro = sdt.gxTv_SdtBoleto_Boletostentativasderegistro ;
         gxTv_SdtBoleto_Boletoscreatedat = sdt.gxTv_SdtBoleto_Boletoscreatedat ;
         gxTv_SdtBoleto_Boletosupdatedat = sdt.gxTv_SdtBoleto_Boletosupdatedat ;
         gxTv_SdtBoleto_Boletosresgitroid = sdt.gxTv_SdtBoleto_Boletosresgitroid ;
         gxTv_SdtBoleto_Carteiradecobrancanome = sdt.gxTv_SdtBoleto_Carteiradecobrancanome ;
         gxTv_SdtBoleto_Carteiradecobrancaconvenio = sdt.gxTv_SdtBoleto_Carteiradecobrancaconvenio ;
         gxTv_SdtBoleto_Carteiradecobrancastatus = sdt.gxTv_SdtBoleto_Carteiradecobrancastatus ;
         gxTv_SdtBoleto_Carteiradecobrancavalortotal = sdt.gxTv_SdtBoleto_Carteiradecobrancavalortotal ;
         gxTv_SdtBoleto_Carteiradecobrancavalorrecebido = sdt.gxTv_SdtBoleto_Carteiradecobrancavalorrecebido ;
         gxTv_SdtBoleto_Carteiradecobrancatotalboletos = sdt.gxTv_SdtBoleto_Carteiradecobrancatotalboletos ;
         gxTv_SdtBoleto_Carteiradecobrancatotalboletosregistrados = sdt.gxTv_SdtBoleto_Carteiradecobrancatotalboletosregistrados ;
         gxTv_SdtBoleto_Carteiradecobrancatotalboletosexpirados = sdt.gxTv_SdtBoleto_Carteiradecobrancatotalboletosexpirados ;
         gxTv_SdtBoleto_Carteiradecobrancatotalboletoscancelados = sdt.gxTv_SdtBoleto_Carteiradecobrancatotalboletoscancelados ;
         gxTv_SdtBoleto_Mode = sdt.gxTv_SdtBoleto_Mode ;
         gxTv_SdtBoleto_Initialized = sdt.gxTv_SdtBoleto_Initialized ;
         gxTv_SdtBoleto_Boletosid_Z = sdt.gxTv_SdtBoleto_Boletosid_Z ;
         gxTv_SdtBoleto_Carteiradecobrancaid_Z = sdt.gxTv_SdtBoleto_Carteiradecobrancaid_Z ;
         gxTv_SdtBoleto_Tituloid_Z = sdt.gxTv_SdtBoleto_Tituloid_Z ;
         gxTv_SdtBoleto_Boletosnossonumero_Z = sdt.gxTv_SdtBoleto_Boletosnossonumero_Z ;
         gxTv_SdtBoleto_Boletosseunumero_Z = sdt.gxTv_SdtBoleto_Boletosseunumero_Z ;
         gxTv_SdtBoleto_Boletosnumero_Z = sdt.gxTv_SdtBoleto_Boletosnumero_Z ;
         gxTv_SdtBoleto_Boletoslinhadigitavel_Z = sdt.gxTv_SdtBoleto_Boletoslinhadigitavel_Z ;
         gxTv_SdtBoleto_Boletoscodigodebarras_Z = sdt.gxTv_SdtBoleto_Boletoscodigodebarras_Z ;
         gxTv_SdtBoleto_Boletosstatus_Z = sdt.gxTv_SdtBoleto_Boletosstatus_Z ;
         gxTv_SdtBoleto_Boletosdataemissao_Z = sdt.gxTv_SdtBoleto_Boletosdataemissao_Z ;
         gxTv_SdtBoleto_Boletosdatavencimento_Z = sdt.gxTv_SdtBoleto_Boletosdatavencimento_Z ;
         gxTv_SdtBoleto_Boletosdataregistro_Z = sdt.gxTv_SdtBoleto_Boletosdataregistro_Z ;
         gxTv_SdtBoleto_Boletosdatapagamento_Z = sdt.gxTv_SdtBoleto_Boletosdatapagamento_Z ;
         gxTv_SdtBoleto_Boletosdatabaixa_Z = sdt.gxTv_SdtBoleto_Boletosdatabaixa_Z ;
         gxTv_SdtBoleto_Boletosvalornominal_Z = sdt.gxTv_SdtBoleto_Boletosvalornominal_Z ;
         gxTv_SdtBoleto_Boletosvalorpago_Z = sdt.gxTv_SdtBoleto_Boletosvalorpago_Z ;
         gxTv_SdtBoleto_Boletosvalordesconto_Z = sdt.gxTv_SdtBoleto_Boletosvalordesconto_Z ;
         gxTv_SdtBoleto_Boletosvalorjuros_Z = sdt.gxTv_SdtBoleto_Boletosvalorjuros_Z ;
         gxTv_SdtBoleto_Boletosvalormulta_Z = sdt.gxTv_SdtBoleto_Boletosvalormulta_Z ;
         gxTv_SdtBoleto_Boletossacadonome_Z = sdt.gxTv_SdtBoleto_Boletossacadonome_Z ;
         gxTv_SdtBoleto_Boletossacadodocumento_Z = sdt.gxTv_SdtBoleto_Boletossacadodocumento_Z ;
         gxTv_SdtBoleto_Boletossacadotipodocumento_Z = sdt.gxTv_SdtBoleto_Boletossacadotipodocumento_Z ;
         gxTv_SdtBoleto_Boletostentativasderegistro_Z = sdt.gxTv_SdtBoleto_Boletostentativasderegistro_Z ;
         gxTv_SdtBoleto_Boletoscreatedat_Z = sdt.gxTv_SdtBoleto_Boletoscreatedat_Z ;
         gxTv_SdtBoleto_Boletosupdatedat_Z = sdt.gxTv_SdtBoleto_Boletosupdatedat_Z ;
         gxTv_SdtBoleto_Boletosresgitroid_Z = sdt.gxTv_SdtBoleto_Boletosresgitroid_Z ;
         gxTv_SdtBoleto_Carteiradecobrancanome_Z = sdt.gxTv_SdtBoleto_Carteiradecobrancanome_Z ;
         gxTv_SdtBoleto_Carteiradecobrancaconvenio_Z = sdt.gxTv_SdtBoleto_Carteiradecobrancaconvenio_Z ;
         gxTv_SdtBoleto_Carteiradecobrancastatus_Z = sdt.gxTv_SdtBoleto_Carteiradecobrancastatus_Z ;
         gxTv_SdtBoleto_Carteiradecobrancavalortotal_Z = sdt.gxTv_SdtBoleto_Carteiradecobrancavalortotal_Z ;
         gxTv_SdtBoleto_Carteiradecobrancavalorrecebido_Z = sdt.gxTv_SdtBoleto_Carteiradecobrancavalorrecebido_Z ;
         gxTv_SdtBoleto_Carteiradecobrancatotalboletos_Z = sdt.gxTv_SdtBoleto_Carteiradecobrancatotalboletos_Z ;
         gxTv_SdtBoleto_Carteiradecobrancatotalboletosregistrados_Z = sdt.gxTv_SdtBoleto_Carteiradecobrancatotalboletosregistrados_Z ;
         gxTv_SdtBoleto_Carteiradecobrancatotalboletosexpirados_Z = sdt.gxTv_SdtBoleto_Carteiradecobrancatotalboletosexpirados_Z ;
         gxTv_SdtBoleto_Carteiradecobrancatotalboletoscancelados_Z = sdt.gxTv_SdtBoleto_Carteiradecobrancatotalboletoscancelados_Z ;
         gxTv_SdtBoleto_Boletosid_N = sdt.gxTv_SdtBoleto_Boletosid_N ;
         gxTv_SdtBoleto_Carteiradecobrancaid_N = sdt.gxTv_SdtBoleto_Carteiradecobrancaid_N ;
         gxTv_SdtBoleto_Tituloid_N = sdt.gxTv_SdtBoleto_Tituloid_N ;
         gxTv_SdtBoleto_Boletosnossonumero_N = sdt.gxTv_SdtBoleto_Boletosnossonumero_N ;
         gxTv_SdtBoleto_Boletosseunumero_N = sdt.gxTv_SdtBoleto_Boletosseunumero_N ;
         gxTv_SdtBoleto_Boletosnumero_N = sdt.gxTv_SdtBoleto_Boletosnumero_N ;
         gxTv_SdtBoleto_Boletoslinhadigitavel_N = sdt.gxTv_SdtBoleto_Boletoslinhadigitavel_N ;
         gxTv_SdtBoleto_Boletoscodigodebarras_N = sdt.gxTv_SdtBoleto_Boletoscodigodebarras_N ;
         gxTv_SdtBoleto_Boletosstatus_N = sdt.gxTv_SdtBoleto_Boletosstatus_N ;
         gxTv_SdtBoleto_Boletosdataemissao_N = sdt.gxTv_SdtBoleto_Boletosdataemissao_N ;
         gxTv_SdtBoleto_Boletosdatavencimento_N = sdt.gxTv_SdtBoleto_Boletosdatavencimento_N ;
         gxTv_SdtBoleto_Boletosdataregistro_N = sdt.gxTv_SdtBoleto_Boletosdataregistro_N ;
         gxTv_SdtBoleto_Boletosdatapagamento_N = sdt.gxTv_SdtBoleto_Boletosdatapagamento_N ;
         gxTv_SdtBoleto_Boletosdatabaixa_N = sdt.gxTv_SdtBoleto_Boletosdatabaixa_N ;
         gxTv_SdtBoleto_Boletosvalornominal_N = sdt.gxTv_SdtBoleto_Boletosvalornominal_N ;
         gxTv_SdtBoleto_Boletosvalorpago_N = sdt.gxTv_SdtBoleto_Boletosvalorpago_N ;
         gxTv_SdtBoleto_Boletosvalordesconto_N = sdt.gxTv_SdtBoleto_Boletosvalordesconto_N ;
         gxTv_SdtBoleto_Boletosvalorjuros_N = sdt.gxTv_SdtBoleto_Boletosvalorjuros_N ;
         gxTv_SdtBoleto_Boletosvalormulta_N = sdt.gxTv_SdtBoleto_Boletosvalormulta_N ;
         gxTv_SdtBoleto_Boletossacadonome_N = sdt.gxTv_SdtBoleto_Boletossacadonome_N ;
         gxTv_SdtBoleto_Boletossacadodocumento_N = sdt.gxTv_SdtBoleto_Boletossacadodocumento_N ;
         gxTv_SdtBoleto_Boletossacadotipodocumento_N = sdt.gxTv_SdtBoleto_Boletossacadotipodocumento_N ;
         gxTv_SdtBoleto_Boletosmensagemdeerro_N = sdt.gxTv_SdtBoleto_Boletosmensagemdeerro_N ;
         gxTv_SdtBoleto_Boletostentativasderegistro_N = sdt.gxTv_SdtBoleto_Boletostentativasderegistro_N ;
         gxTv_SdtBoleto_Boletoscreatedat_N = sdt.gxTv_SdtBoleto_Boletoscreatedat_N ;
         gxTv_SdtBoleto_Boletosupdatedat_N = sdt.gxTv_SdtBoleto_Boletosupdatedat_N ;
         gxTv_SdtBoleto_Boletosresgitroid_N = sdt.gxTv_SdtBoleto_Boletosresgitroid_N ;
         gxTv_SdtBoleto_Carteiradecobrancanome_N = sdt.gxTv_SdtBoleto_Carteiradecobrancanome_N ;
         gxTv_SdtBoleto_Carteiradecobrancaconvenio_N = sdt.gxTv_SdtBoleto_Carteiradecobrancaconvenio_N ;
         gxTv_SdtBoleto_Carteiradecobrancastatus_N = sdt.gxTv_SdtBoleto_Carteiradecobrancastatus_N ;
         gxTv_SdtBoleto_Carteiradecobrancatotalboletosregistrados_N = sdt.gxTv_SdtBoleto_Carteiradecobrancatotalboletosregistrados_N ;
         gxTv_SdtBoleto_Carteiradecobrancatotalboletosexpirados_N = sdt.gxTv_SdtBoleto_Carteiradecobrancatotalboletosexpirados_N ;
         gxTv_SdtBoleto_Carteiradecobrancatotalboletoscancelados_N = sdt.gxTv_SdtBoleto_Carteiradecobrancatotalboletoscancelados_N ;
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
         AddObjectProperty("BoletosId", gxTv_SdtBoleto_Boletosid, false, includeNonInitialized);
         AddObjectProperty("BoletosId_N", gxTv_SdtBoleto_Boletosid_N, false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaId", gxTv_SdtBoleto_Carteiradecobrancaid, false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaId_N", gxTv_SdtBoleto_Carteiradecobrancaid_N, false, includeNonInitialized);
         AddObjectProperty("TituloId", gxTv_SdtBoleto_Tituloid, false, includeNonInitialized);
         AddObjectProperty("TituloId_N", gxTv_SdtBoleto_Tituloid_N, false, includeNonInitialized);
         AddObjectProperty("BoletosNossoNumero", gxTv_SdtBoleto_Boletosnossonumero, false, includeNonInitialized);
         AddObjectProperty("BoletosNossoNumero_N", gxTv_SdtBoleto_Boletosnossonumero_N, false, includeNonInitialized);
         AddObjectProperty("BoletosSeuNumero", gxTv_SdtBoleto_Boletosseunumero, false, includeNonInitialized);
         AddObjectProperty("BoletosSeuNumero_N", gxTv_SdtBoleto_Boletosseunumero_N, false, includeNonInitialized);
         AddObjectProperty("BoletosNumero", gxTv_SdtBoleto_Boletosnumero, false, includeNonInitialized);
         AddObjectProperty("BoletosNumero_N", gxTv_SdtBoleto_Boletosnumero_N, false, includeNonInitialized);
         AddObjectProperty("BoletosLinhaDigitavel", gxTv_SdtBoleto_Boletoslinhadigitavel, false, includeNonInitialized);
         AddObjectProperty("BoletosLinhaDigitavel_N", gxTv_SdtBoleto_Boletoslinhadigitavel_N, false, includeNonInitialized);
         AddObjectProperty("BoletosCodigoDeBarras", gxTv_SdtBoleto_Boletoscodigodebarras, false, includeNonInitialized);
         AddObjectProperty("BoletosCodigoDeBarras_N", gxTv_SdtBoleto_Boletoscodigodebarras_N, false, includeNonInitialized);
         AddObjectProperty("BoletosStatus", gxTv_SdtBoleto_Boletosstatus, false, includeNonInitialized);
         AddObjectProperty("BoletosStatus_N", gxTv_SdtBoleto_Boletosstatus_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtBoleto_Boletosdataemissao)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtBoleto_Boletosdataemissao)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtBoleto_Boletosdataemissao)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("BoletosDataEmissao", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("BoletosDataEmissao_N", gxTv_SdtBoleto_Boletosdataemissao_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtBoleto_Boletosdatavencimento)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtBoleto_Boletosdatavencimento)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtBoleto_Boletosdatavencimento)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("BoletosDataVencimento", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("BoletosDataVencimento_N", gxTv_SdtBoleto_Boletosdatavencimento_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtBoleto_Boletosdataregistro;
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
         AddObjectProperty("BoletosDataRegistro", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("BoletosDataRegistro_N", gxTv_SdtBoleto_Boletosdataregistro_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtBoleto_Boletosdatapagamento)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtBoleto_Boletosdatapagamento)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtBoleto_Boletosdatapagamento)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("BoletosDataPagamento", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("BoletosDataPagamento_N", gxTv_SdtBoleto_Boletosdatapagamento_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtBoleto_Boletosdatabaixa)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtBoleto_Boletosdatabaixa)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtBoleto_Boletosdatabaixa)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("BoletosDataBaixa", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("BoletosDataBaixa_N", gxTv_SdtBoleto_Boletosdatabaixa_N, false, includeNonInitialized);
         AddObjectProperty("BoletosValorNominal", StringUtil.LTrim( StringUtil.Str( gxTv_SdtBoleto_Boletosvalornominal, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("BoletosValorNominal_N", gxTv_SdtBoleto_Boletosvalornominal_N, false, includeNonInitialized);
         AddObjectProperty("BoletosValorPago", StringUtil.LTrim( StringUtil.Str( gxTv_SdtBoleto_Boletosvalorpago, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("BoletosValorPago_N", gxTv_SdtBoleto_Boletosvalorpago_N, false, includeNonInitialized);
         AddObjectProperty("BoletosValorDesconto", StringUtil.LTrim( StringUtil.Str( gxTv_SdtBoleto_Boletosvalordesconto, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("BoletosValorDesconto_N", gxTv_SdtBoleto_Boletosvalordesconto_N, false, includeNonInitialized);
         AddObjectProperty("BoletosValorJuros", StringUtil.LTrim( StringUtil.Str( gxTv_SdtBoleto_Boletosvalorjuros, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("BoletosValorJuros_N", gxTv_SdtBoleto_Boletosvalorjuros_N, false, includeNonInitialized);
         AddObjectProperty("BoletosValorMulta", StringUtil.LTrim( StringUtil.Str( gxTv_SdtBoleto_Boletosvalormulta, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("BoletosValorMulta_N", gxTv_SdtBoleto_Boletosvalormulta_N, false, includeNonInitialized);
         AddObjectProperty("BoletosSacadoNome", gxTv_SdtBoleto_Boletossacadonome, false, includeNonInitialized);
         AddObjectProperty("BoletosSacadoNome_N", gxTv_SdtBoleto_Boletossacadonome_N, false, includeNonInitialized);
         AddObjectProperty("BoletosSacadoDocumento", gxTv_SdtBoleto_Boletossacadodocumento, false, includeNonInitialized);
         AddObjectProperty("BoletosSacadoDocumento_N", gxTv_SdtBoleto_Boletossacadodocumento_N, false, includeNonInitialized);
         AddObjectProperty("BoletosSacadoTipoDocumento", gxTv_SdtBoleto_Boletossacadotipodocumento, false, includeNonInitialized);
         AddObjectProperty("BoletosSacadoTipoDocumento_N", gxTv_SdtBoleto_Boletossacadotipodocumento_N, false, includeNonInitialized);
         AddObjectProperty("BoletosMensagemDeErro", gxTv_SdtBoleto_Boletosmensagemdeerro, false, includeNonInitialized);
         AddObjectProperty("BoletosMensagemDeErro_N", gxTv_SdtBoleto_Boletosmensagemdeerro_N, false, includeNonInitialized);
         AddObjectProperty("BoletosTentativasDeRegistro", gxTv_SdtBoleto_Boletostentativasderegistro, false, includeNonInitialized);
         AddObjectProperty("BoletosTentativasDeRegistro_N", gxTv_SdtBoleto_Boletostentativasderegistro_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtBoleto_Boletoscreatedat;
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
         AddObjectProperty("BoletosCreatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("BoletosCreatedAt_N", gxTv_SdtBoleto_Boletoscreatedat_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtBoleto_Boletosupdatedat;
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
         AddObjectProperty("BoletosUpdatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("BoletosUpdatedAt_N", gxTv_SdtBoleto_Boletosupdatedat_N, false, includeNonInitialized);
         AddObjectProperty("BoletosResgitroId", gxTv_SdtBoleto_Boletosresgitroid, false, includeNonInitialized);
         AddObjectProperty("BoletosResgitroId_N", gxTv_SdtBoleto_Boletosresgitroid_N, false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaNome", gxTv_SdtBoleto_Carteiradecobrancanome, false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaNome_N", gxTv_SdtBoleto_Carteiradecobrancanome_N, false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaConvenio", gxTv_SdtBoleto_Carteiradecobrancaconvenio, false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaConvenio_N", gxTv_SdtBoleto_Carteiradecobrancaconvenio_N, false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaStatus", gxTv_SdtBoleto_Carteiradecobrancastatus, false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaStatus_N", gxTv_SdtBoleto_Carteiradecobrancastatus_N, false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaValorTotal", StringUtil.LTrim( StringUtil.Str( gxTv_SdtBoleto_Carteiradecobrancavalortotal, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaValorRecebido", StringUtil.LTrim( StringUtil.Str( gxTv_SdtBoleto_Carteiradecobrancavalorrecebido, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaTotalBoletos", gxTv_SdtBoleto_Carteiradecobrancatotalboletos, false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaTotalBoletosRegistrados", gxTv_SdtBoleto_Carteiradecobrancatotalboletosregistrados, false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaTotalBoletosRegistrados_N", gxTv_SdtBoleto_Carteiradecobrancatotalboletosregistrados_N, false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaTotalBoletosExpirados", gxTv_SdtBoleto_Carteiradecobrancatotalboletosexpirados, false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaTotalBoletosExpirados_N", gxTv_SdtBoleto_Carteiradecobrancatotalboletosexpirados_N, false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaTotalBoletosCancelados", gxTv_SdtBoleto_Carteiradecobrancatotalboletoscancelados, false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaTotalBoletosCancelados_N", gxTv_SdtBoleto_Carteiradecobrancatotalboletoscancelados_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtBoleto_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtBoleto_Initialized, false, includeNonInitialized);
            AddObjectProperty("BoletosId_Z", gxTv_SdtBoleto_Boletosid_Z, false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaId_Z", gxTv_SdtBoleto_Carteiradecobrancaid_Z, false, includeNonInitialized);
            AddObjectProperty("TituloId_Z", gxTv_SdtBoleto_Tituloid_Z, false, includeNonInitialized);
            AddObjectProperty("BoletosNossoNumero_Z", gxTv_SdtBoleto_Boletosnossonumero_Z, false, includeNonInitialized);
            AddObjectProperty("BoletosSeuNumero_Z", gxTv_SdtBoleto_Boletosseunumero_Z, false, includeNonInitialized);
            AddObjectProperty("BoletosNumero_Z", gxTv_SdtBoleto_Boletosnumero_Z, false, includeNonInitialized);
            AddObjectProperty("BoletosLinhaDigitavel_Z", gxTv_SdtBoleto_Boletoslinhadigitavel_Z, false, includeNonInitialized);
            AddObjectProperty("BoletosCodigoDeBarras_Z", gxTv_SdtBoleto_Boletoscodigodebarras_Z, false, includeNonInitialized);
            AddObjectProperty("BoletosStatus_Z", gxTv_SdtBoleto_Boletosstatus_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtBoleto_Boletosdataemissao_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtBoleto_Boletosdataemissao_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtBoleto_Boletosdataemissao_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("BoletosDataEmissao_Z", sDateCnv, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtBoleto_Boletosdatavencimento_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtBoleto_Boletosdatavencimento_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtBoleto_Boletosdatavencimento_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("BoletosDataVencimento_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtBoleto_Boletosdataregistro_Z;
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
            AddObjectProperty("BoletosDataRegistro_Z", sDateCnv, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtBoleto_Boletosdatapagamento_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtBoleto_Boletosdatapagamento_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtBoleto_Boletosdatapagamento_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("BoletosDataPagamento_Z", sDateCnv, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtBoleto_Boletosdatabaixa_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtBoleto_Boletosdatabaixa_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtBoleto_Boletosdatabaixa_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("BoletosDataBaixa_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("BoletosValorNominal_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtBoleto_Boletosvalornominal_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("BoletosValorPago_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtBoleto_Boletosvalorpago_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("BoletosValorDesconto_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtBoleto_Boletosvalordesconto_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("BoletosValorJuros_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtBoleto_Boletosvalorjuros_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("BoletosValorMulta_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtBoleto_Boletosvalormulta_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("BoletosSacadoNome_Z", gxTv_SdtBoleto_Boletossacadonome_Z, false, includeNonInitialized);
            AddObjectProperty("BoletosSacadoDocumento_Z", gxTv_SdtBoleto_Boletossacadodocumento_Z, false, includeNonInitialized);
            AddObjectProperty("BoletosSacadoTipoDocumento_Z", gxTv_SdtBoleto_Boletossacadotipodocumento_Z, false, includeNonInitialized);
            AddObjectProperty("BoletosTentativasDeRegistro_Z", gxTv_SdtBoleto_Boletostentativasderegistro_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtBoleto_Boletoscreatedat_Z;
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
            AddObjectProperty("BoletosCreatedAt_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtBoleto_Boletosupdatedat_Z;
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
            AddObjectProperty("BoletosUpdatedAt_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("BoletosResgitroId_Z", gxTv_SdtBoleto_Boletosresgitroid_Z, false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaNome_Z", gxTv_SdtBoleto_Carteiradecobrancanome_Z, false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaConvenio_Z", gxTv_SdtBoleto_Carteiradecobrancaconvenio_Z, false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaStatus_Z", gxTv_SdtBoleto_Carteiradecobrancastatus_Z, false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaValorTotal_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtBoleto_Carteiradecobrancavalortotal_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaValorRecebido_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtBoleto_Carteiradecobrancavalorrecebido_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaTotalBoletos_Z", gxTv_SdtBoleto_Carteiradecobrancatotalboletos_Z, false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaTotalBoletosRegistrados_Z", gxTv_SdtBoleto_Carteiradecobrancatotalboletosregistrados_Z, false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaTotalBoletosExpirados_Z", gxTv_SdtBoleto_Carteiradecobrancatotalboletosexpirados_Z, false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaTotalBoletosCancelados_Z", gxTv_SdtBoleto_Carteiradecobrancatotalboletoscancelados_Z, false, includeNonInitialized);
            AddObjectProperty("BoletosId_N", gxTv_SdtBoleto_Boletosid_N, false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaId_N", gxTv_SdtBoleto_Carteiradecobrancaid_N, false, includeNonInitialized);
            AddObjectProperty("TituloId_N", gxTv_SdtBoleto_Tituloid_N, false, includeNonInitialized);
            AddObjectProperty("BoletosNossoNumero_N", gxTv_SdtBoleto_Boletosnossonumero_N, false, includeNonInitialized);
            AddObjectProperty("BoletosSeuNumero_N", gxTv_SdtBoleto_Boletosseunumero_N, false, includeNonInitialized);
            AddObjectProperty("BoletosNumero_N", gxTv_SdtBoleto_Boletosnumero_N, false, includeNonInitialized);
            AddObjectProperty("BoletosLinhaDigitavel_N", gxTv_SdtBoleto_Boletoslinhadigitavel_N, false, includeNonInitialized);
            AddObjectProperty("BoletosCodigoDeBarras_N", gxTv_SdtBoleto_Boletoscodigodebarras_N, false, includeNonInitialized);
            AddObjectProperty("BoletosStatus_N", gxTv_SdtBoleto_Boletosstatus_N, false, includeNonInitialized);
            AddObjectProperty("BoletosDataEmissao_N", gxTv_SdtBoleto_Boletosdataemissao_N, false, includeNonInitialized);
            AddObjectProperty("BoletosDataVencimento_N", gxTv_SdtBoleto_Boletosdatavencimento_N, false, includeNonInitialized);
            AddObjectProperty("BoletosDataRegistro_N", gxTv_SdtBoleto_Boletosdataregistro_N, false, includeNonInitialized);
            AddObjectProperty("BoletosDataPagamento_N", gxTv_SdtBoleto_Boletosdatapagamento_N, false, includeNonInitialized);
            AddObjectProperty("BoletosDataBaixa_N", gxTv_SdtBoleto_Boletosdatabaixa_N, false, includeNonInitialized);
            AddObjectProperty("BoletosValorNominal_N", gxTv_SdtBoleto_Boletosvalornominal_N, false, includeNonInitialized);
            AddObjectProperty("BoletosValorPago_N", gxTv_SdtBoleto_Boletosvalorpago_N, false, includeNonInitialized);
            AddObjectProperty("BoletosValorDesconto_N", gxTv_SdtBoleto_Boletosvalordesconto_N, false, includeNonInitialized);
            AddObjectProperty("BoletosValorJuros_N", gxTv_SdtBoleto_Boletosvalorjuros_N, false, includeNonInitialized);
            AddObjectProperty("BoletosValorMulta_N", gxTv_SdtBoleto_Boletosvalormulta_N, false, includeNonInitialized);
            AddObjectProperty("BoletosSacadoNome_N", gxTv_SdtBoleto_Boletossacadonome_N, false, includeNonInitialized);
            AddObjectProperty("BoletosSacadoDocumento_N", gxTv_SdtBoleto_Boletossacadodocumento_N, false, includeNonInitialized);
            AddObjectProperty("BoletosSacadoTipoDocumento_N", gxTv_SdtBoleto_Boletossacadotipodocumento_N, false, includeNonInitialized);
            AddObjectProperty("BoletosMensagemDeErro_N", gxTv_SdtBoleto_Boletosmensagemdeerro_N, false, includeNonInitialized);
            AddObjectProperty("BoletosTentativasDeRegistro_N", gxTv_SdtBoleto_Boletostentativasderegistro_N, false, includeNonInitialized);
            AddObjectProperty("BoletosCreatedAt_N", gxTv_SdtBoleto_Boletoscreatedat_N, false, includeNonInitialized);
            AddObjectProperty("BoletosUpdatedAt_N", gxTv_SdtBoleto_Boletosupdatedat_N, false, includeNonInitialized);
            AddObjectProperty("BoletosResgitroId_N", gxTv_SdtBoleto_Boletosresgitroid_N, false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaNome_N", gxTv_SdtBoleto_Carteiradecobrancanome_N, false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaConvenio_N", gxTv_SdtBoleto_Carteiradecobrancaconvenio_N, false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaStatus_N", gxTv_SdtBoleto_Carteiradecobrancastatus_N, false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaTotalBoletosRegistrados_N", gxTv_SdtBoleto_Carteiradecobrancatotalboletosregistrados_N, false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaTotalBoletosExpirados_N", gxTv_SdtBoleto_Carteiradecobrancatotalboletosexpirados_N, false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaTotalBoletosCancelados_N", gxTv_SdtBoleto_Carteiradecobrancatotalboletoscancelados_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtBoleto sdt )
      {
         if ( sdt.IsDirty("BoletosId") )
         {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosid = sdt.gxTv_SdtBoleto_Boletosid ;
         }
         if ( sdt.IsDirty("CarteiraDeCobrancaId") )
         {
            gxTv_SdtBoleto_Carteiradecobrancaid_N = (short)(sdt.gxTv_SdtBoleto_Carteiradecobrancaid_N);
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancaid = sdt.gxTv_SdtBoleto_Carteiradecobrancaid ;
         }
         if ( sdt.IsDirty("TituloId") )
         {
            gxTv_SdtBoleto_Tituloid_N = (short)(sdt.gxTv_SdtBoleto_Tituloid_N);
            sdtIsNull = 0;
            gxTv_SdtBoleto_Tituloid = sdt.gxTv_SdtBoleto_Tituloid ;
         }
         if ( sdt.IsDirty("BoletosNossoNumero") )
         {
            gxTv_SdtBoleto_Boletosnossonumero_N = (short)(sdt.gxTv_SdtBoleto_Boletosnossonumero_N);
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosnossonumero = sdt.gxTv_SdtBoleto_Boletosnossonumero ;
         }
         if ( sdt.IsDirty("BoletosSeuNumero") )
         {
            gxTv_SdtBoleto_Boletosseunumero_N = (short)(sdt.gxTv_SdtBoleto_Boletosseunumero_N);
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosseunumero = sdt.gxTv_SdtBoleto_Boletosseunumero ;
         }
         if ( sdt.IsDirty("BoletosNumero") )
         {
            gxTv_SdtBoleto_Boletosnumero_N = (short)(sdt.gxTv_SdtBoleto_Boletosnumero_N);
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosnumero = sdt.gxTv_SdtBoleto_Boletosnumero ;
         }
         if ( sdt.IsDirty("BoletosLinhaDigitavel") )
         {
            gxTv_SdtBoleto_Boletoslinhadigitavel_N = (short)(sdt.gxTv_SdtBoleto_Boletoslinhadigitavel_N);
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletoslinhadigitavel = sdt.gxTv_SdtBoleto_Boletoslinhadigitavel ;
         }
         if ( sdt.IsDirty("BoletosCodigoDeBarras") )
         {
            gxTv_SdtBoleto_Boletoscodigodebarras_N = (short)(sdt.gxTv_SdtBoleto_Boletoscodigodebarras_N);
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletoscodigodebarras = sdt.gxTv_SdtBoleto_Boletoscodigodebarras ;
         }
         if ( sdt.IsDirty("BoletosStatus") )
         {
            gxTv_SdtBoleto_Boletosstatus_N = (short)(sdt.gxTv_SdtBoleto_Boletosstatus_N);
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosstatus = sdt.gxTv_SdtBoleto_Boletosstatus ;
         }
         if ( sdt.IsDirty("BoletosDataEmissao") )
         {
            gxTv_SdtBoleto_Boletosdataemissao_N = (short)(sdt.gxTv_SdtBoleto_Boletosdataemissao_N);
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosdataemissao = sdt.gxTv_SdtBoleto_Boletosdataemissao ;
         }
         if ( sdt.IsDirty("BoletosDataVencimento") )
         {
            gxTv_SdtBoleto_Boletosdatavencimento_N = (short)(sdt.gxTv_SdtBoleto_Boletosdatavencimento_N);
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosdatavencimento = sdt.gxTv_SdtBoleto_Boletosdatavencimento ;
         }
         if ( sdt.IsDirty("BoletosDataRegistro") )
         {
            gxTv_SdtBoleto_Boletosdataregistro_N = (short)(sdt.gxTv_SdtBoleto_Boletosdataregistro_N);
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosdataregistro = sdt.gxTv_SdtBoleto_Boletosdataregistro ;
         }
         if ( sdt.IsDirty("BoletosDataPagamento") )
         {
            gxTv_SdtBoleto_Boletosdatapagamento_N = (short)(sdt.gxTv_SdtBoleto_Boletosdatapagamento_N);
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosdatapagamento = sdt.gxTv_SdtBoleto_Boletosdatapagamento ;
         }
         if ( sdt.IsDirty("BoletosDataBaixa") )
         {
            gxTv_SdtBoleto_Boletosdatabaixa_N = (short)(sdt.gxTv_SdtBoleto_Boletosdatabaixa_N);
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosdatabaixa = sdt.gxTv_SdtBoleto_Boletosdatabaixa ;
         }
         if ( sdt.IsDirty("BoletosValorNominal") )
         {
            gxTv_SdtBoleto_Boletosvalornominal_N = (short)(sdt.gxTv_SdtBoleto_Boletosvalornominal_N);
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosvalornominal = sdt.gxTv_SdtBoleto_Boletosvalornominal ;
         }
         if ( sdt.IsDirty("BoletosValorPago") )
         {
            gxTv_SdtBoleto_Boletosvalorpago_N = (short)(sdt.gxTv_SdtBoleto_Boletosvalorpago_N);
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosvalorpago = sdt.gxTv_SdtBoleto_Boletosvalorpago ;
         }
         if ( sdt.IsDirty("BoletosValorDesconto") )
         {
            gxTv_SdtBoleto_Boletosvalordesconto_N = (short)(sdt.gxTv_SdtBoleto_Boletosvalordesconto_N);
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosvalordesconto = sdt.gxTv_SdtBoleto_Boletosvalordesconto ;
         }
         if ( sdt.IsDirty("BoletosValorJuros") )
         {
            gxTv_SdtBoleto_Boletosvalorjuros_N = (short)(sdt.gxTv_SdtBoleto_Boletosvalorjuros_N);
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosvalorjuros = sdt.gxTv_SdtBoleto_Boletosvalorjuros ;
         }
         if ( sdt.IsDirty("BoletosValorMulta") )
         {
            gxTv_SdtBoleto_Boletosvalormulta_N = (short)(sdt.gxTv_SdtBoleto_Boletosvalormulta_N);
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosvalormulta = sdt.gxTv_SdtBoleto_Boletosvalormulta ;
         }
         if ( sdt.IsDirty("BoletosSacadoNome") )
         {
            gxTv_SdtBoleto_Boletossacadonome_N = (short)(sdt.gxTv_SdtBoleto_Boletossacadonome_N);
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletossacadonome = sdt.gxTv_SdtBoleto_Boletossacadonome ;
         }
         if ( sdt.IsDirty("BoletosSacadoDocumento") )
         {
            gxTv_SdtBoleto_Boletossacadodocumento_N = (short)(sdt.gxTv_SdtBoleto_Boletossacadodocumento_N);
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletossacadodocumento = sdt.gxTv_SdtBoleto_Boletossacadodocumento ;
         }
         if ( sdt.IsDirty("BoletosSacadoTipoDocumento") )
         {
            gxTv_SdtBoleto_Boletossacadotipodocumento_N = (short)(sdt.gxTv_SdtBoleto_Boletossacadotipodocumento_N);
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletossacadotipodocumento = sdt.gxTv_SdtBoleto_Boletossacadotipodocumento ;
         }
         if ( sdt.IsDirty("BoletosMensagemDeErro") )
         {
            gxTv_SdtBoleto_Boletosmensagemdeerro_N = (short)(sdt.gxTv_SdtBoleto_Boletosmensagemdeerro_N);
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosmensagemdeerro = sdt.gxTv_SdtBoleto_Boletosmensagemdeerro ;
         }
         if ( sdt.IsDirty("BoletosTentativasDeRegistro") )
         {
            gxTv_SdtBoleto_Boletostentativasderegistro_N = (short)(sdt.gxTv_SdtBoleto_Boletostentativasderegistro_N);
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletostentativasderegistro = sdt.gxTv_SdtBoleto_Boletostentativasderegistro ;
         }
         if ( sdt.IsDirty("BoletosCreatedAt") )
         {
            gxTv_SdtBoleto_Boletoscreatedat_N = (short)(sdt.gxTv_SdtBoleto_Boletoscreatedat_N);
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletoscreatedat = sdt.gxTv_SdtBoleto_Boletoscreatedat ;
         }
         if ( sdt.IsDirty("BoletosUpdatedAt") )
         {
            gxTv_SdtBoleto_Boletosupdatedat_N = (short)(sdt.gxTv_SdtBoleto_Boletosupdatedat_N);
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosupdatedat = sdt.gxTv_SdtBoleto_Boletosupdatedat ;
         }
         if ( sdt.IsDirty("BoletosResgitroId") )
         {
            gxTv_SdtBoleto_Boletosresgitroid_N = (short)(sdt.gxTv_SdtBoleto_Boletosresgitroid_N);
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosresgitroid = sdt.gxTv_SdtBoleto_Boletosresgitroid ;
         }
         if ( sdt.IsDirty("CarteiraDeCobrancaNome") )
         {
            gxTv_SdtBoleto_Carteiradecobrancanome_N = (short)(sdt.gxTv_SdtBoleto_Carteiradecobrancanome_N);
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancanome = sdt.gxTv_SdtBoleto_Carteiradecobrancanome ;
         }
         if ( sdt.IsDirty("CarteiraDeCobrancaConvenio") )
         {
            gxTv_SdtBoleto_Carteiradecobrancaconvenio_N = (short)(sdt.gxTv_SdtBoleto_Carteiradecobrancaconvenio_N);
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancaconvenio = sdt.gxTv_SdtBoleto_Carteiradecobrancaconvenio ;
         }
         if ( sdt.IsDirty("CarteiraDeCobrancaStatus") )
         {
            gxTv_SdtBoleto_Carteiradecobrancastatus_N = (short)(sdt.gxTv_SdtBoleto_Carteiradecobrancastatus_N);
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancastatus = sdt.gxTv_SdtBoleto_Carteiradecobrancastatus ;
         }
         if ( sdt.IsDirty("CarteiraDeCobrancaValorTotal") )
         {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancavalortotal = sdt.gxTv_SdtBoleto_Carteiradecobrancavalortotal ;
         }
         if ( sdt.IsDirty("CarteiraDeCobrancaValorRecebido") )
         {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancavalorrecebido = sdt.gxTv_SdtBoleto_Carteiradecobrancavalorrecebido ;
         }
         if ( sdt.IsDirty("CarteiraDeCobrancaTotalBoletos") )
         {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancatotalboletos = sdt.gxTv_SdtBoleto_Carteiradecobrancatotalboletos ;
         }
         if ( sdt.IsDirty("CarteiraDeCobrancaTotalBoletosRegistrados") )
         {
            gxTv_SdtBoleto_Carteiradecobrancatotalboletosregistrados_N = (short)(sdt.gxTv_SdtBoleto_Carteiradecobrancatotalboletosregistrados_N);
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancatotalboletosregistrados = sdt.gxTv_SdtBoleto_Carteiradecobrancatotalboletosregistrados ;
         }
         if ( sdt.IsDirty("CarteiraDeCobrancaTotalBoletosExpirados") )
         {
            gxTv_SdtBoleto_Carteiradecobrancatotalboletosexpirados_N = (short)(sdt.gxTv_SdtBoleto_Carteiradecobrancatotalboletosexpirados_N);
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancatotalboletosexpirados = sdt.gxTv_SdtBoleto_Carteiradecobrancatotalboletosexpirados ;
         }
         if ( sdt.IsDirty("CarteiraDeCobrancaTotalBoletosCancelados") )
         {
            gxTv_SdtBoleto_Carteiradecobrancatotalboletoscancelados_N = (short)(sdt.gxTv_SdtBoleto_Carteiradecobrancatotalboletoscancelados_N);
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancatotalboletoscancelados = sdt.gxTv_SdtBoleto_Carteiradecobrancatotalboletoscancelados ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "BoletosId" )]
      [  XmlElement( ElementName = "BoletosId"   )]
      public int gxTpr_Boletosid
      {
         get {
            return gxTv_SdtBoleto_Boletosid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtBoleto_Boletosid != value )
            {
               gxTv_SdtBoleto_Mode = "INS";
               this.gxTv_SdtBoleto_Boletosid_Z_SetNull( );
               this.gxTv_SdtBoleto_Carteiradecobrancaid_Z_SetNull( );
               this.gxTv_SdtBoleto_Tituloid_Z_SetNull( );
               this.gxTv_SdtBoleto_Boletosnossonumero_Z_SetNull( );
               this.gxTv_SdtBoleto_Boletosseunumero_Z_SetNull( );
               this.gxTv_SdtBoleto_Boletosnumero_Z_SetNull( );
               this.gxTv_SdtBoleto_Boletoslinhadigitavel_Z_SetNull( );
               this.gxTv_SdtBoleto_Boletoscodigodebarras_Z_SetNull( );
               this.gxTv_SdtBoleto_Boletosstatus_Z_SetNull( );
               this.gxTv_SdtBoleto_Boletosdataemissao_Z_SetNull( );
               this.gxTv_SdtBoleto_Boletosdatavencimento_Z_SetNull( );
               this.gxTv_SdtBoleto_Boletosdataregistro_Z_SetNull( );
               this.gxTv_SdtBoleto_Boletosdatapagamento_Z_SetNull( );
               this.gxTv_SdtBoleto_Boletosdatabaixa_Z_SetNull( );
               this.gxTv_SdtBoleto_Boletosvalornominal_Z_SetNull( );
               this.gxTv_SdtBoleto_Boletosvalorpago_Z_SetNull( );
               this.gxTv_SdtBoleto_Boletosvalordesconto_Z_SetNull( );
               this.gxTv_SdtBoleto_Boletosvalorjuros_Z_SetNull( );
               this.gxTv_SdtBoleto_Boletosvalormulta_Z_SetNull( );
               this.gxTv_SdtBoleto_Boletossacadonome_Z_SetNull( );
               this.gxTv_SdtBoleto_Boletossacadodocumento_Z_SetNull( );
               this.gxTv_SdtBoleto_Boletossacadotipodocumento_Z_SetNull( );
               this.gxTv_SdtBoleto_Boletostentativasderegistro_Z_SetNull( );
               this.gxTv_SdtBoleto_Boletoscreatedat_Z_SetNull( );
               this.gxTv_SdtBoleto_Boletosupdatedat_Z_SetNull( );
               this.gxTv_SdtBoleto_Boletosresgitroid_Z_SetNull( );
               this.gxTv_SdtBoleto_Carteiradecobrancanome_Z_SetNull( );
               this.gxTv_SdtBoleto_Carteiradecobrancaconvenio_Z_SetNull( );
               this.gxTv_SdtBoleto_Carteiradecobrancastatus_Z_SetNull( );
               this.gxTv_SdtBoleto_Carteiradecobrancavalortotal_Z_SetNull( );
               this.gxTv_SdtBoleto_Carteiradecobrancavalorrecebido_Z_SetNull( );
               this.gxTv_SdtBoleto_Carteiradecobrancatotalboletos_Z_SetNull( );
               this.gxTv_SdtBoleto_Carteiradecobrancatotalboletosregistrados_Z_SetNull( );
               this.gxTv_SdtBoleto_Carteiradecobrancatotalboletosexpirados_Z_SetNull( );
               this.gxTv_SdtBoleto_Carteiradecobrancatotalboletoscancelados_Z_SetNull( );
            }
            gxTv_SdtBoleto_Boletosid = value;
            SetDirty("Boletosid");
         }

      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaId" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaId"   )]
      public int gxTpr_Carteiradecobrancaid
      {
         get {
            return gxTv_SdtBoleto_Carteiradecobrancaid ;
         }

         set {
            gxTv_SdtBoleto_Carteiradecobrancaid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancaid = value;
            SetDirty("Carteiradecobrancaid");
         }

      }

      public void gxTv_SdtBoleto_Carteiradecobrancaid_SetNull( )
      {
         gxTv_SdtBoleto_Carteiradecobrancaid_N = 1;
         gxTv_SdtBoleto_Carteiradecobrancaid = 0;
         SetDirty("Carteiradecobrancaid");
         return  ;
      }

      public bool gxTv_SdtBoleto_Carteiradecobrancaid_IsNull( )
      {
         return (gxTv_SdtBoleto_Carteiradecobrancaid_N==1) ;
      }

      [  SoapElement( ElementName = "TituloId" )]
      [  XmlElement( ElementName = "TituloId"   )]
      public int gxTpr_Tituloid
      {
         get {
            return gxTv_SdtBoleto_Tituloid ;
         }

         set {
            gxTv_SdtBoleto_Tituloid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoleto_Tituloid = value;
            SetDirty("Tituloid");
         }

      }

      public void gxTv_SdtBoleto_Tituloid_SetNull( )
      {
         gxTv_SdtBoleto_Tituloid_N = 1;
         gxTv_SdtBoleto_Tituloid = 0;
         SetDirty("Tituloid");
         return  ;
      }

      public bool gxTv_SdtBoleto_Tituloid_IsNull( )
      {
         return (gxTv_SdtBoleto_Tituloid_N==1) ;
      }

      [  SoapElement( ElementName = "BoletosNossoNumero" )]
      [  XmlElement( ElementName = "BoletosNossoNumero"   )]
      public string gxTpr_Boletosnossonumero
      {
         get {
            return gxTv_SdtBoleto_Boletosnossonumero ;
         }

         set {
            gxTv_SdtBoleto_Boletosnossonumero_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosnossonumero = value;
            SetDirty("Boletosnossonumero");
         }

      }

      public void gxTv_SdtBoleto_Boletosnossonumero_SetNull( )
      {
         gxTv_SdtBoleto_Boletosnossonumero_N = 1;
         gxTv_SdtBoleto_Boletosnossonumero = "";
         SetDirty("Boletosnossonumero");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosnossonumero_IsNull( )
      {
         return (gxTv_SdtBoleto_Boletosnossonumero_N==1) ;
      }

      [  SoapElement( ElementName = "BoletosSeuNumero" )]
      [  XmlElement( ElementName = "BoletosSeuNumero"   )]
      public string gxTpr_Boletosseunumero
      {
         get {
            return gxTv_SdtBoleto_Boletosseunumero ;
         }

         set {
            gxTv_SdtBoleto_Boletosseunumero_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosseunumero = value;
            SetDirty("Boletosseunumero");
         }

      }

      public void gxTv_SdtBoleto_Boletosseunumero_SetNull( )
      {
         gxTv_SdtBoleto_Boletosseunumero_N = 1;
         gxTv_SdtBoleto_Boletosseunumero = "";
         SetDirty("Boletosseunumero");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosseunumero_IsNull( )
      {
         return (gxTv_SdtBoleto_Boletosseunumero_N==1) ;
      }

      [  SoapElement( ElementName = "BoletosNumero" )]
      [  XmlElement( ElementName = "BoletosNumero"   )]
      public string gxTpr_Boletosnumero
      {
         get {
            return gxTv_SdtBoleto_Boletosnumero ;
         }

         set {
            gxTv_SdtBoleto_Boletosnumero_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosnumero = value;
            SetDirty("Boletosnumero");
         }

      }

      public void gxTv_SdtBoleto_Boletosnumero_SetNull( )
      {
         gxTv_SdtBoleto_Boletosnumero_N = 1;
         gxTv_SdtBoleto_Boletosnumero = "";
         SetDirty("Boletosnumero");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosnumero_IsNull( )
      {
         return (gxTv_SdtBoleto_Boletosnumero_N==1) ;
      }

      [  SoapElement( ElementName = "BoletosLinhaDigitavel" )]
      [  XmlElement( ElementName = "BoletosLinhaDigitavel"   )]
      public string gxTpr_Boletoslinhadigitavel
      {
         get {
            return gxTv_SdtBoleto_Boletoslinhadigitavel ;
         }

         set {
            gxTv_SdtBoleto_Boletoslinhadigitavel_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletoslinhadigitavel = value;
            SetDirty("Boletoslinhadigitavel");
         }

      }

      public void gxTv_SdtBoleto_Boletoslinhadigitavel_SetNull( )
      {
         gxTv_SdtBoleto_Boletoslinhadigitavel_N = 1;
         gxTv_SdtBoleto_Boletoslinhadigitavel = "";
         SetDirty("Boletoslinhadigitavel");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletoslinhadigitavel_IsNull( )
      {
         return (gxTv_SdtBoleto_Boletoslinhadigitavel_N==1) ;
      }

      [  SoapElement( ElementName = "BoletosCodigoDeBarras" )]
      [  XmlElement( ElementName = "BoletosCodigoDeBarras"   )]
      public string gxTpr_Boletoscodigodebarras
      {
         get {
            return gxTv_SdtBoleto_Boletoscodigodebarras ;
         }

         set {
            gxTv_SdtBoleto_Boletoscodigodebarras_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletoscodigodebarras = value;
            SetDirty("Boletoscodigodebarras");
         }

      }

      public void gxTv_SdtBoleto_Boletoscodigodebarras_SetNull( )
      {
         gxTv_SdtBoleto_Boletoscodigodebarras_N = 1;
         gxTv_SdtBoleto_Boletoscodigodebarras = "";
         SetDirty("Boletoscodigodebarras");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletoscodigodebarras_IsNull( )
      {
         return (gxTv_SdtBoleto_Boletoscodigodebarras_N==1) ;
      }

      [  SoapElement( ElementName = "BoletosStatus" )]
      [  XmlElement( ElementName = "BoletosStatus"   )]
      public string gxTpr_Boletosstatus
      {
         get {
            return gxTv_SdtBoleto_Boletosstatus ;
         }

         set {
            gxTv_SdtBoleto_Boletosstatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosstatus = value;
            SetDirty("Boletosstatus");
         }

      }

      public void gxTv_SdtBoleto_Boletosstatus_SetNull( )
      {
         gxTv_SdtBoleto_Boletosstatus_N = 1;
         gxTv_SdtBoleto_Boletosstatus = "";
         SetDirty("Boletosstatus");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosstatus_IsNull( )
      {
         return (gxTv_SdtBoleto_Boletosstatus_N==1) ;
      }

      [  SoapElement( ElementName = "BoletosDataEmissao" )]
      [  XmlElement( ElementName = "BoletosDataEmissao"  , IsNullable=true )]
      public string gxTpr_Boletosdataemissao_Nullable
      {
         get {
            if ( gxTv_SdtBoleto_Boletosdataemissao == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtBoleto_Boletosdataemissao).value ;
         }

         set {
            gxTv_SdtBoleto_Boletosdataemissao_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtBoleto_Boletosdataemissao = DateTime.MinValue;
            else
               gxTv_SdtBoleto_Boletosdataemissao = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Boletosdataemissao
      {
         get {
            return gxTv_SdtBoleto_Boletosdataemissao ;
         }

         set {
            gxTv_SdtBoleto_Boletosdataemissao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosdataemissao = value;
            SetDirty("Boletosdataemissao");
         }

      }

      public void gxTv_SdtBoleto_Boletosdataemissao_SetNull( )
      {
         gxTv_SdtBoleto_Boletosdataemissao_N = 1;
         gxTv_SdtBoleto_Boletosdataemissao = (DateTime)(DateTime.MinValue);
         SetDirty("Boletosdataemissao");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosdataemissao_IsNull( )
      {
         return (gxTv_SdtBoleto_Boletosdataemissao_N==1) ;
      }

      [  SoapElement( ElementName = "BoletosDataVencimento" )]
      [  XmlElement( ElementName = "BoletosDataVencimento"  , IsNullable=true )]
      public string gxTpr_Boletosdatavencimento_Nullable
      {
         get {
            if ( gxTv_SdtBoleto_Boletosdatavencimento == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtBoleto_Boletosdatavencimento).value ;
         }

         set {
            gxTv_SdtBoleto_Boletosdatavencimento_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtBoleto_Boletosdatavencimento = DateTime.MinValue;
            else
               gxTv_SdtBoleto_Boletosdatavencimento = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Boletosdatavencimento
      {
         get {
            return gxTv_SdtBoleto_Boletosdatavencimento ;
         }

         set {
            gxTv_SdtBoleto_Boletosdatavencimento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosdatavencimento = value;
            SetDirty("Boletosdatavencimento");
         }

      }

      public void gxTv_SdtBoleto_Boletosdatavencimento_SetNull( )
      {
         gxTv_SdtBoleto_Boletosdatavencimento_N = 1;
         gxTv_SdtBoleto_Boletosdatavencimento = (DateTime)(DateTime.MinValue);
         SetDirty("Boletosdatavencimento");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosdatavencimento_IsNull( )
      {
         return (gxTv_SdtBoleto_Boletosdatavencimento_N==1) ;
      }

      [  SoapElement( ElementName = "BoletosDataRegistro" )]
      [  XmlElement( ElementName = "BoletosDataRegistro"  , IsNullable=true )]
      public string gxTpr_Boletosdataregistro_Nullable
      {
         get {
            if ( gxTv_SdtBoleto_Boletosdataregistro == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtBoleto_Boletosdataregistro).value ;
         }

         set {
            gxTv_SdtBoleto_Boletosdataregistro_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtBoleto_Boletosdataregistro = DateTime.MinValue;
            else
               gxTv_SdtBoleto_Boletosdataregistro = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Boletosdataregistro
      {
         get {
            return gxTv_SdtBoleto_Boletosdataregistro ;
         }

         set {
            gxTv_SdtBoleto_Boletosdataregistro_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosdataregistro = value;
            SetDirty("Boletosdataregistro");
         }

      }

      public void gxTv_SdtBoleto_Boletosdataregistro_SetNull( )
      {
         gxTv_SdtBoleto_Boletosdataregistro_N = 1;
         gxTv_SdtBoleto_Boletosdataregistro = (DateTime)(DateTime.MinValue);
         SetDirty("Boletosdataregistro");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosdataregistro_IsNull( )
      {
         return (gxTv_SdtBoleto_Boletosdataregistro_N==1) ;
      }

      [  SoapElement( ElementName = "BoletosDataPagamento" )]
      [  XmlElement( ElementName = "BoletosDataPagamento"  , IsNullable=true )]
      public string gxTpr_Boletosdatapagamento_Nullable
      {
         get {
            if ( gxTv_SdtBoleto_Boletosdatapagamento == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtBoleto_Boletosdatapagamento).value ;
         }

         set {
            gxTv_SdtBoleto_Boletosdatapagamento_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtBoleto_Boletosdatapagamento = DateTime.MinValue;
            else
               gxTv_SdtBoleto_Boletosdatapagamento = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Boletosdatapagamento
      {
         get {
            return gxTv_SdtBoleto_Boletosdatapagamento ;
         }

         set {
            gxTv_SdtBoleto_Boletosdatapagamento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosdatapagamento = value;
            SetDirty("Boletosdatapagamento");
         }

      }

      public void gxTv_SdtBoleto_Boletosdatapagamento_SetNull( )
      {
         gxTv_SdtBoleto_Boletosdatapagamento_N = 1;
         gxTv_SdtBoleto_Boletosdatapagamento = (DateTime)(DateTime.MinValue);
         SetDirty("Boletosdatapagamento");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosdatapagamento_IsNull( )
      {
         return (gxTv_SdtBoleto_Boletosdatapagamento_N==1) ;
      }

      [  SoapElement( ElementName = "BoletosDataBaixa" )]
      [  XmlElement( ElementName = "BoletosDataBaixa"  , IsNullable=true )]
      public string gxTpr_Boletosdatabaixa_Nullable
      {
         get {
            if ( gxTv_SdtBoleto_Boletosdatabaixa == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtBoleto_Boletosdatabaixa).value ;
         }

         set {
            gxTv_SdtBoleto_Boletosdatabaixa_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtBoleto_Boletosdatabaixa = DateTime.MinValue;
            else
               gxTv_SdtBoleto_Boletosdatabaixa = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Boletosdatabaixa
      {
         get {
            return gxTv_SdtBoleto_Boletosdatabaixa ;
         }

         set {
            gxTv_SdtBoleto_Boletosdatabaixa_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosdatabaixa = value;
            SetDirty("Boletosdatabaixa");
         }

      }

      public void gxTv_SdtBoleto_Boletosdatabaixa_SetNull( )
      {
         gxTv_SdtBoleto_Boletosdatabaixa_N = 1;
         gxTv_SdtBoleto_Boletosdatabaixa = (DateTime)(DateTime.MinValue);
         SetDirty("Boletosdatabaixa");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosdatabaixa_IsNull( )
      {
         return (gxTv_SdtBoleto_Boletosdatabaixa_N==1) ;
      }

      [  SoapElement( ElementName = "BoletosValorNominal" )]
      [  XmlElement( ElementName = "BoletosValorNominal"   )]
      public decimal gxTpr_Boletosvalornominal
      {
         get {
            return gxTv_SdtBoleto_Boletosvalornominal ;
         }

         set {
            gxTv_SdtBoleto_Boletosvalornominal_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosvalornominal = value;
            SetDirty("Boletosvalornominal");
         }

      }

      public void gxTv_SdtBoleto_Boletosvalornominal_SetNull( )
      {
         gxTv_SdtBoleto_Boletosvalornominal_N = 1;
         gxTv_SdtBoleto_Boletosvalornominal = 0;
         SetDirty("Boletosvalornominal");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosvalornominal_IsNull( )
      {
         return (gxTv_SdtBoleto_Boletosvalornominal_N==1) ;
      }

      [  SoapElement( ElementName = "BoletosValorPago" )]
      [  XmlElement( ElementName = "BoletosValorPago"   )]
      public decimal gxTpr_Boletosvalorpago
      {
         get {
            return gxTv_SdtBoleto_Boletosvalorpago ;
         }

         set {
            gxTv_SdtBoleto_Boletosvalorpago_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosvalorpago = value;
            SetDirty("Boletosvalorpago");
         }

      }

      public void gxTv_SdtBoleto_Boletosvalorpago_SetNull( )
      {
         gxTv_SdtBoleto_Boletosvalorpago_N = 1;
         gxTv_SdtBoleto_Boletosvalorpago = 0;
         SetDirty("Boletosvalorpago");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosvalorpago_IsNull( )
      {
         return (gxTv_SdtBoleto_Boletosvalorpago_N==1) ;
      }

      [  SoapElement( ElementName = "BoletosValorDesconto" )]
      [  XmlElement( ElementName = "BoletosValorDesconto"   )]
      public decimal gxTpr_Boletosvalordesconto
      {
         get {
            return gxTv_SdtBoleto_Boletosvalordesconto ;
         }

         set {
            gxTv_SdtBoleto_Boletosvalordesconto_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosvalordesconto = value;
            SetDirty("Boletosvalordesconto");
         }

      }

      public void gxTv_SdtBoleto_Boletosvalordesconto_SetNull( )
      {
         gxTv_SdtBoleto_Boletosvalordesconto_N = 1;
         gxTv_SdtBoleto_Boletosvalordesconto = 0;
         SetDirty("Boletosvalordesconto");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosvalordesconto_IsNull( )
      {
         return (gxTv_SdtBoleto_Boletosvalordesconto_N==1) ;
      }

      [  SoapElement( ElementName = "BoletosValorJuros" )]
      [  XmlElement( ElementName = "BoletosValorJuros"   )]
      public decimal gxTpr_Boletosvalorjuros
      {
         get {
            return gxTv_SdtBoleto_Boletosvalorjuros ;
         }

         set {
            gxTv_SdtBoleto_Boletosvalorjuros_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosvalorjuros = value;
            SetDirty("Boletosvalorjuros");
         }

      }

      public void gxTv_SdtBoleto_Boletosvalorjuros_SetNull( )
      {
         gxTv_SdtBoleto_Boletosvalorjuros_N = 1;
         gxTv_SdtBoleto_Boletosvalorjuros = 0;
         SetDirty("Boletosvalorjuros");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosvalorjuros_IsNull( )
      {
         return (gxTv_SdtBoleto_Boletosvalorjuros_N==1) ;
      }

      [  SoapElement( ElementName = "BoletosValorMulta" )]
      [  XmlElement( ElementName = "BoletosValorMulta"   )]
      public decimal gxTpr_Boletosvalormulta
      {
         get {
            return gxTv_SdtBoleto_Boletosvalormulta ;
         }

         set {
            gxTv_SdtBoleto_Boletosvalormulta_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosvalormulta = value;
            SetDirty("Boletosvalormulta");
         }

      }

      public void gxTv_SdtBoleto_Boletosvalormulta_SetNull( )
      {
         gxTv_SdtBoleto_Boletosvalormulta_N = 1;
         gxTv_SdtBoleto_Boletosvalormulta = 0;
         SetDirty("Boletosvalormulta");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosvalormulta_IsNull( )
      {
         return (gxTv_SdtBoleto_Boletosvalormulta_N==1) ;
      }

      [  SoapElement( ElementName = "BoletosSacadoNome" )]
      [  XmlElement( ElementName = "BoletosSacadoNome"   )]
      public string gxTpr_Boletossacadonome
      {
         get {
            return gxTv_SdtBoleto_Boletossacadonome ;
         }

         set {
            gxTv_SdtBoleto_Boletossacadonome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletossacadonome = value;
            SetDirty("Boletossacadonome");
         }

      }

      public void gxTv_SdtBoleto_Boletossacadonome_SetNull( )
      {
         gxTv_SdtBoleto_Boletossacadonome_N = 1;
         gxTv_SdtBoleto_Boletossacadonome = "";
         SetDirty("Boletossacadonome");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletossacadonome_IsNull( )
      {
         return (gxTv_SdtBoleto_Boletossacadonome_N==1) ;
      }

      [  SoapElement( ElementName = "BoletosSacadoDocumento" )]
      [  XmlElement( ElementName = "BoletosSacadoDocumento"   )]
      public string gxTpr_Boletossacadodocumento
      {
         get {
            return gxTv_SdtBoleto_Boletossacadodocumento ;
         }

         set {
            gxTv_SdtBoleto_Boletossacadodocumento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletossacadodocumento = value;
            SetDirty("Boletossacadodocumento");
         }

      }

      public void gxTv_SdtBoleto_Boletossacadodocumento_SetNull( )
      {
         gxTv_SdtBoleto_Boletossacadodocumento_N = 1;
         gxTv_SdtBoleto_Boletossacadodocumento = "";
         SetDirty("Boletossacadodocumento");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletossacadodocumento_IsNull( )
      {
         return (gxTv_SdtBoleto_Boletossacadodocumento_N==1) ;
      }

      [  SoapElement( ElementName = "BoletosSacadoTipoDocumento" )]
      [  XmlElement( ElementName = "BoletosSacadoTipoDocumento"   )]
      public string gxTpr_Boletossacadotipodocumento
      {
         get {
            return gxTv_SdtBoleto_Boletossacadotipodocumento ;
         }

         set {
            gxTv_SdtBoleto_Boletossacadotipodocumento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletossacadotipodocumento = value;
            SetDirty("Boletossacadotipodocumento");
         }

      }

      public void gxTv_SdtBoleto_Boletossacadotipodocumento_SetNull( )
      {
         gxTv_SdtBoleto_Boletossacadotipodocumento_N = 1;
         gxTv_SdtBoleto_Boletossacadotipodocumento = "";
         SetDirty("Boletossacadotipodocumento");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletossacadotipodocumento_IsNull( )
      {
         return (gxTv_SdtBoleto_Boletossacadotipodocumento_N==1) ;
      }

      [  SoapElement( ElementName = "BoletosMensagemDeErro" )]
      [  XmlElement( ElementName = "BoletosMensagemDeErro"   )]
      public string gxTpr_Boletosmensagemdeerro
      {
         get {
            return gxTv_SdtBoleto_Boletosmensagemdeerro ;
         }

         set {
            gxTv_SdtBoleto_Boletosmensagemdeerro_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosmensagemdeerro = value;
            SetDirty("Boletosmensagemdeerro");
         }

      }

      public void gxTv_SdtBoleto_Boletosmensagemdeerro_SetNull( )
      {
         gxTv_SdtBoleto_Boletosmensagemdeerro_N = 1;
         gxTv_SdtBoleto_Boletosmensagemdeerro = "";
         SetDirty("Boletosmensagemdeerro");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosmensagemdeerro_IsNull( )
      {
         return (gxTv_SdtBoleto_Boletosmensagemdeerro_N==1) ;
      }

      [  SoapElement( ElementName = "BoletosTentativasDeRegistro" )]
      [  XmlElement( ElementName = "BoletosTentativasDeRegistro"   )]
      public int gxTpr_Boletostentativasderegistro
      {
         get {
            return gxTv_SdtBoleto_Boletostentativasderegistro ;
         }

         set {
            gxTv_SdtBoleto_Boletostentativasderegistro_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletostentativasderegistro = value;
            SetDirty("Boletostentativasderegistro");
         }

      }

      public void gxTv_SdtBoleto_Boletostentativasderegistro_SetNull( )
      {
         gxTv_SdtBoleto_Boletostentativasderegistro_N = 1;
         gxTv_SdtBoleto_Boletostentativasderegistro = 0;
         SetDirty("Boletostentativasderegistro");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletostentativasderegistro_IsNull( )
      {
         return (gxTv_SdtBoleto_Boletostentativasderegistro_N==1) ;
      }

      [  SoapElement( ElementName = "BoletosCreatedAt" )]
      [  XmlElement( ElementName = "BoletosCreatedAt"  , IsNullable=true )]
      public string gxTpr_Boletoscreatedat_Nullable
      {
         get {
            if ( gxTv_SdtBoleto_Boletoscreatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtBoleto_Boletoscreatedat).value ;
         }

         set {
            gxTv_SdtBoleto_Boletoscreatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtBoleto_Boletoscreatedat = DateTime.MinValue;
            else
               gxTv_SdtBoleto_Boletoscreatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Boletoscreatedat
      {
         get {
            return gxTv_SdtBoleto_Boletoscreatedat ;
         }

         set {
            gxTv_SdtBoleto_Boletoscreatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletoscreatedat = value;
            SetDirty("Boletoscreatedat");
         }

      }

      public void gxTv_SdtBoleto_Boletoscreatedat_SetNull( )
      {
         gxTv_SdtBoleto_Boletoscreatedat_N = 1;
         gxTv_SdtBoleto_Boletoscreatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Boletoscreatedat");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletoscreatedat_IsNull( )
      {
         return (gxTv_SdtBoleto_Boletoscreatedat_N==1) ;
      }

      [  SoapElement( ElementName = "BoletosUpdatedAt" )]
      [  XmlElement( ElementName = "BoletosUpdatedAt"  , IsNullable=true )]
      public string gxTpr_Boletosupdatedat_Nullable
      {
         get {
            if ( gxTv_SdtBoleto_Boletosupdatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtBoleto_Boletosupdatedat).value ;
         }

         set {
            gxTv_SdtBoleto_Boletosupdatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtBoleto_Boletosupdatedat = DateTime.MinValue;
            else
               gxTv_SdtBoleto_Boletosupdatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Boletosupdatedat
      {
         get {
            return gxTv_SdtBoleto_Boletosupdatedat ;
         }

         set {
            gxTv_SdtBoleto_Boletosupdatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosupdatedat = value;
            SetDirty("Boletosupdatedat");
         }

      }

      public void gxTv_SdtBoleto_Boletosupdatedat_SetNull( )
      {
         gxTv_SdtBoleto_Boletosupdatedat_N = 1;
         gxTv_SdtBoleto_Boletosupdatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Boletosupdatedat");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosupdatedat_IsNull( )
      {
         return (gxTv_SdtBoleto_Boletosupdatedat_N==1) ;
      }

      [  SoapElement( ElementName = "BoletosResgitroId" )]
      [  XmlElement( ElementName = "BoletosResgitroId"   )]
      public Guid gxTpr_Boletosresgitroid
      {
         get {
            return gxTv_SdtBoleto_Boletosresgitroid ;
         }

         set {
            gxTv_SdtBoleto_Boletosresgitroid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosresgitroid = value;
            SetDirty("Boletosresgitroid");
         }

      }

      public void gxTv_SdtBoleto_Boletosresgitroid_SetNull( )
      {
         gxTv_SdtBoleto_Boletosresgitroid_N = 1;
         gxTv_SdtBoleto_Boletosresgitroid = Guid.Empty;
         SetDirty("Boletosresgitroid");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosresgitroid_IsNull( )
      {
         return (gxTv_SdtBoleto_Boletosresgitroid_N==1) ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaNome" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaNome"   )]
      public string gxTpr_Carteiradecobrancanome
      {
         get {
            return gxTv_SdtBoleto_Carteiradecobrancanome ;
         }

         set {
            gxTv_SdtBoleto_Carteiradecobrancanome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancanome = value;
            SetDirty("Carteiradecobrancanome");
         }

      }

      public void gxTv_SdtBoleto_Carteiradecobrancanome_SetNull( )
      {
         gxTv_SdtBoleto_Carteiradecobrancanome_N = 1;
         gxTv_SdtBoleto_Carteiradecobrancanome = "";
         SetDirty("Carteiradecobrancanome");
         return  ;
      }

      public bool gxTv_SdtBoleto_Carteiradecobrancanome_IsNull( )
      {
         return (gxTv_SdtBoleto_Carteiradecobrancanome_N==1) ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaConvenio" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaConvenio"   )]
      public string gxTpr_Carteiradecobrancaconvenio
      {
         get {
            return gxTv_SdtBoleto_Carteiradecobrancaconvenio ;
         }

         set {
            gxTv_SdtBoleto_Carteiradecobrancaconvenio_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancaconvenio = value;
            SetDirty("Carteiradecobrancaconvenio");
         }

      }

      public void gxTv_SdtBoleto_Carteiradecobrancaconvenio_SetNull( )
      {
         gxTv_SdtBoleto_Carteiradecobrancaconvenio_N = 1;
         gxTv_SdtBoleto_Carteiradecobrancaconvenio = "";
         SetDirty("Carteiradecobrancaconvenio");
         return  ;
      }

      public bool gxTv_SdtBoleto_Carteiradecobrancaconvenio_IsNull( )
      {
         return (gxTv_SdtBoleto_Carteiradecobrancaconvenio_N==1) ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaStatus" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaStatus"   )]
      public bool gxTpr_Carteiradecobrancastatus
      {
         get {
            return gxTv_SdtBoleto_Carteiradecobrancastatus ;
         }

         set {
            gxTv_SdtBoleto_Carteiradecobrancastatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancastatus = value;
            SetDirty("Carteiradecobrancastatus");
         }

      }

      public void gxTv_SdtBoleto_Carteiradecobrancastatus_SetNull( )
      {
         gxTv_SdtBoleto_Carteiradecobrancastatus_N = 1;
         gxTv_SdtBoleto_Carteiradecobrancastatus = false;
         SetDirty("Carteiradecobrancastatus");
         return  ;
      }

      public bool gxTv_SdtBoleto_Carteiradecobrancastatus_IsNull( )
      {
         return (gxTv_SdtBoleto_Carteiradecobrancastatus_N==1) ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaValorTotal" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaValorTotal"   )]
      public decimal gxTpr_Carteiradecobrancavalortotal
      {
         get {
            return gxTv_SdtBoleto_Carteiradecobrancavalortotal ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancavalortotal = value;
            SetDirty("Carteiradecobrancavalortotal");
         }

      }

      public void gxTv_SdtBoleto_Carteiradecobrancavalortotal_SetNull( )
      {
         gxTv_SdtBoleto_Carteiradecobrancavalortotal = 0;
         SetDirty("Carteiradecobrancavalortotal");
         return  ;
      }

      public bool gxTv_SdtBoleto_Carteiradecobrancavalortotal_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaValorRecebido" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaValorRecebido"   )]
      public decimal gxTpr_Carteiradecobrancavalorrecebido
      {
         get {
            return gxTv_SdtBoleto_Carteiradecobrancavalorrecebido ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancavalorrecebido = value;
            SetDirty("Carteiradecobrancavalorrecebido");
         }

      }

      public void gxTv_SdtBoleto_Carteiradecobrancavalorrecebido_SetNull( )
      {
         gxTv_SdtBoleto_Carteiradecobrancavalorrecebido = 0;
         SetDirty("Carteiradecobrancavalorrecebido");
         return  ;
      }

      public bool gxTv_SdtBoleto_Carteiradecobrancavalorrecebido_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaTotalBoletos" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaTotalBoletos"   )]
      public int gxTpr_Carteiradecobrancatotalboletos
      {
         get {
            return gxTv_SdtBoleto_Carteiradecobrancatotalboletos ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancatotalboletos = value;
            SetDirty("Carteiradecobrancatotalboletos");
         }

      }

      public void gxTv_SdtBoleto_Carteiradecobrancatotalboletos_SetNull( )
      {
         gxTv_SdtBoleto_Carteiradecobrancatotalboletos = 0;
         SetDirty("Carteiradecobrancatotalboletos");
         return  ;
      }

      public bool gxTv_SdtBoleto_Carteiradecobrancatotalboletos_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaTotalBoletosRegistrados" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaTotalBoletosRegistrados"   )]
      public int gxTpr_Carteiradecobrancatotalboletosregistrados
      {
         get {
            return gxTv_SdtBoleto_Carteiradecobrancatotalboletosregistrados ;
         }

         set {
            gxTv_SdtBoleto_Carteiradecobrancatotalboletosregistrados_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancatotalboletosregistrados = value;
            SetDirty("Carteiradecobrancatotalboletosregistrados");
         }

      }

      public void gxTv_SdtBoleto_Carteiradecobrancatotalboletosregistrados_SetNull( )
      {
         gxTv_SdtBoleto_Carteiradecobrancatotalboletosregistrados_N = 1;
         gxTv_SdtBoleto_Carteiradecobrancatotalboletosregistrados = 0;
         SetDirty("Carteiradecobrancatotalboletosregistrados");
         return  ;
      }

      public bool gxTv_SdtBoleto_Carteiradecobrancatotalboletosregistrados_IsNull( )
      {
         return (gxTv_SdtBoleto_Carteiradecobrancatotalboletosregistrados_N==1) ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaTotalBoletosExpirados" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaTotalBoletosExpirados"   )]
      public int gxTpr_Carteiradecobrancatotalboletosexpirados
      {
         get {
            return gxTv_SdtBoleto_Carteiradecobrancatotalboletosexpirados ;
         }

         set {
            gxTv_SdtBoleto_Carteiradecobrancatotalboletosexpirados_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancatotalboletosexpirados = value;
            SetDirty("Carteiradecobrancatotalboletosexpirados");
         }

      }

      public void gxTv_SdtBoleto_Carteiradecobrancatotalboletosexpirados_SetNull( )
      {
         gxTv_SdtBoleto_Carteiradecobrancatotalboletosexpirados_N = 1;
         gxTv_SdtBoleto_Carteiradecobrancatotalboletosexpirados = 0;
         SetDirty("Carteiradecobrancatotalboletosexpirados");
         return  ;
      }

      public bool gxTv_SdtBoleto_Carteiradecobrancatotalboletosexpirados_IsNull( )
      {
         return (gxTv_SdtBoleto_Carteiradecobrancatotalboletosexpirados_N==1) ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaTotalBoletosCancelados" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaTotalBoletosCancelados"   )]
      public int gxTpr_Carteiradecobrancatotalboletoscancelados
      {
         get {
            return gxTv_SdtBoleto_Carteiradecobrancatotalboletoscancelados ;
         }

         set {
            gxTv_SdtBoleto_Carteiradecobrancatotalboletoscancelados_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancatotalboletoscancelados = value;
            SetDirty("Carteiradecobrancatotalboletoscancelados");
         }

      }

      public void gxTv_SdtBoleto_Carteiradecobrancatotalboletoscancelados_SetNull( )
      {
         gxTv_SdtBoleto_Carteiradecobrancatotalboletoscancelados_N = 1;
         gxTv_SdtBoleto_Carteiradecobrancatotalboletoscancelados = 0;
         SetDirty("Carteiradecobrancatotalboletoscancelados");
         return  ;
      }

      public bool gxTv_SdtBoleto_Carteiradecobrancatotalboletoscancelados_IsNull( )
      {
         return (gxTv_SdtBoleto_Carteiradecobrancatotalboletoscancelados_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtBoleto_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtBoleto_Mode_SetNull( )
      {
         gxTv_SdtBoleto_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtBoleto_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtBoleto_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtBoleto_Initialized_SetNull( )
      {
         gxTv_SdtBoleto_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtBoleto_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosId_Z" )]
      [  XmlElement( ElementName = "BoletosId_Z"   )]
      public int gxTpr_Boletosid_Z
      {
         get {
            return gxTv_SdtBoleto_Boletosid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosid_Z = value;
            SetDirty("Boletosid_Z");
         }

      }

      public void gxTv_SdtBoleto_Boletosid_Z_SetNull( )
      {
         gxTv_SdtBoleto_Boletosid_Z = 0;
         SetDirty("Boletosid_Z");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaId_Z" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaId_Z"   )]
      public int gxTpr_Carteiradecobrancaid_Z
      {
         get {
            return gxTv_SdtBoleto_Carteiradecobrancaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancaid_Z = value;
            SetDirty("Carteiradecobrancaid_Z");
         }

      }

      public void gxTv_SdtBoleto_Carteiradecobrancaid_Z_SetNull( )
      {
         gxTv_SdtBoleto_Carteiradecobrancaid_Z = 0;
         SetDirty("Carteiradecobrancaid_Z");
         return  ;
      }

      public bool gxTv_SdtBoleto_Carteiradecobrancaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloId_Z" )]
      [  XmlElement( ElementName = "TituloId_Z"   )]
      public int gxTpr_Tituloid_Z
      {
         get {
            return gxTv_SdtBoleto_Tituloid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Tituloid_Z = value;
            SetDirty("Tituloid_Z");
         }

      }

      public void gxTv_SdtBoleto_Tituloid_Z_SetNull( )
      {
         gxTv_SdtBoleto_Tituloid_Z = 0;
         SetDirty("Tituloid_Z");
         return  ;
      }

      public bool gxTv_SdtBoleto_Tituloid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosNossoNumero_Z" )]
      [  XmlElement( ElementName = "BoletosNossoNumero_Z"   )]
      public string gxTpr_Boletosnossonumero_Z
      {
         get {
            return gxTv_SdtBoleto_Boletosnossonumero_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosnossonumero_Z = value;
            SetDirty("Boletosnossonumero_Z");
         }

      }

      public void gxTv_SdtBoleto_Boletosnossonumero_Z_SetNull( )
      {
         gxTv_SdtBoleto_Boletosnossonumero_Z = "";
         SetDirty("Boletosnossonumero_Z");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosnossonumero_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosSeuNumero_Z" )]
      [  XmlElement( ElementName = "BoletosSeuNumero_Z"   )]
      public string gxTpr_Boletosseunumero_Z
      {
         get {
            return gxTv_SdtBoleto_Boletosseunumero_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosseunumero_Z = value;
            SetDirty("Boletosseunumero_Z");
         }

      }

      public void gxTv_SdtBoleto_Boletosseunumero_Z_SetNull( )
      {
         gxTv_SdtBoleto_Boletosseunumero_Z = "";
         SetDirty("Boletosseunumero_Z");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosseunumero_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosNumero_Z" )]
      [  XmlElement( ElementName = "BoletosNumero_Z"   )]
      public string gxTpr_Boletosnumero_Z
      {
         get {
            return gxTv_SdtBoleto_Boletosnumero_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosnumero_Z = value;
            SetDirty("Boletosnumero_Z");
         }

      }

      public void gxTv_SdtBoleto_Boletosnumero_Z_SetNull( )
      {
         gxTv_SdtBoleto_Boletosnumero_Z = "";
         SetDirty("Boletosnumero_Z");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosnumero_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosLinhaDigitavel_Z" )]
      [  XmlElement( ElementName = "BoletosLinhaDigitavel_Z"   )]
      public string gxTpr_Boletoslinhadigitavel_Z
      {
         get {
            return gxTv_SdtBoleto_Boletoslinhadigitavel_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletoslinhadigitavel_Z = value;
            SetDirty("Boletoslinhadigitavel_Z");
         }

      }

      public void gxTv_SdtBoleto_Boletoslinhadigitavel_Z_SetNull( )
      {
         gxTv_SdtBoleto_Boletoslinhadigitavel_Z = "";
         SetDirty("Boletoslinhadigitavel_Z");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletoslinhadigitavel_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosCodigoDeBarras_Z" )]
      [  XmlElement( ElementName = "BoletosCodigoDeBarras_Z"   )]
      public string gxTpr_Boletoscodigodebarras_Z
      {
         get {
            return gxTv_SdtBoleto_Boletoscodigodebarras_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletoscodigodebarras_Z = value;
            SetDirty("Boletoscodigodebarras_Z");
         }

      }

      public void gxTv_SdtBoleto_Boletoscodigodebarras_Z_SetNull( )
      {
         gxTv_SdtBoleto_Boletoscodigodebarras_Z = "";
         SetDirty("Boletoscodigodebarras_Z");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletoscodigodebarras_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosStatus_Z" )]
      [  XmlElement( ElementName = "BoletosStatus_Z"   )]
      public string gxTpr_Boletosstatus_Z
      {
         get {
            return gxTv_SdtBoleto_Boletosstatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosstatus_Z = value;
            SetDirty("Boletosstatus_Z");
         }

      }

      public void gxTv_SdtBoleto_Boletosstatus_Z_SetNull( )
      {
         gxTv_SdtBoleto_Boletosstatus_Z = "";
         SetDirty("Boletosstatus_Z");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosstatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosDataEmissao_Z" )]
      [  XmlElement( ElementName = "BoletosDataEmissao_Z"  , IsNullable=true )]
      public string gxTpr_Boletosdataemissao_Z_Nullable
      {
         get {
            if ( gxTv_SdtBoleto_Boletosdataemissao_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtBoleto_Boletosdataemissao_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtBoleto_Boletosdataemissao_Z = DateTime.MinValue;
            else
               gxTv_SdtBoleto_Boletosdataemissao_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Boletosdataemissao_Z
      {
         get {
            return gxTv_SdtBoleto_Boletosdataemissao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosdataemissao_Z = value;
            SetDirty("Boletosdataemissao_Z");
         }

      }

      public void gxTv_SdtBoleto_Boletosdataemissao_Z_SetNull( )
      {
         gxTv_SdtBoleto_Boletosdataemissao_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Boletosdataemissao_Z");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosdataemissao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosDataVencimento_Z" )]
      [  XmlElement( ElementName = "BoletosDataVencimento_Z"  , IsNullable=true )]
      public string gxTpr_Boletosdatavencimento_Z_Nullable
      {
         get {
            if ( gxTv_SdtBoleto_Boletosdatavencimento_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtBoleto_Boletosdatavencimento_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtBoleto_Boletosdatavencimento_Z = DateTime.MinValue;
            else
               gxTv_SdtBoleto_Boletosdatavencimento_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Boletosdatavencimento_Z
      {
         get {
            return gxTv_SdtBoleto_Boletosdatavencimento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosdatavencimento_Z = value;
            SetDirty("Boletosdatavencimento_Z");
         }

      }

      public void gxTv_SdtBoleto_Boletosdatavencimento_Z_SetNull( )
      {
         gxTv_SdtBoleto_Boletosdatavencimento_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Boletosdatavencimento_Z");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosdatavencimento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosDataRegistro_Z" )]
      [  XmlElement( ElementName = "BoletosDataRegistro_Z"  , IsNullable=true )]
      public string gxTpr_Boletosdataregistro_Z_Nullable
      {
         get {
            if ( gxTv_SdtBoleto_Boletosdataregistro_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtBoleto_Boletosdataregistro_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtBoleto_Boletosdataregistro_Z = DateTime.MinValue;
            else
               gxTv_SdtBoleto_Boletosdataregistro_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Boletosdataregistro_Z
      {
         get {
            return gxTv_SdtBoleto_Boletosdataregistro_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosdataregistro_Z = value;
            SetDirty("Boletosdataregistro_Z");
         }

      }

      public void gxTv_SdtBoleto_Boletosdataregistro_Z_SetNull( )
      {
         gxTv_SdtBoleto_Boletosdataregistro_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Boletosdataregistro_Z");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosdataregistro_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosDataPagamento_Z" )]
      [  XmlElement( ElementName = "BoletosDataPagamento_Z"  , IsNullable=true )]
      public string gxTpr_Boletosdatapagamento_Z_Nullable
      {
         get {
            if ( gxTv_SdtBoleto_Boletosdatapagamento_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtBoleto_Boletosdatapagamento_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtBoleto_Boletosdatapagamento_Z = DateTime.MinValue;
            else
               gxTv_SdtBoleto_Boletosdatapagamento_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Boletosdatapagamento_Z
      {
         get {
            return gxTv_SdtBoleto_Boletosdatapagamento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosdatapagamento_Z = value;
            SetDirty("Boletosdatapagamento_Z");
         }

      }

      public void gxTv_SdtBoleto_Boletosdatapagamento_Z_SetNull( )
      {
         gxTv_SdtBoleto_Boletosdatapagamento_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Boletosdatapagamento_Z");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosdatapagamento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosDataBaixa_Z" )]
      [  XmlElement( ElementName = "BoletosDataBaixa_Z"  , IsNullable=true )]
      public string gxTpr_Boletosdatabaixa_Z_Nullable
      {
         get {
            if ( gxTv_SdtBoleto_Boletosdatabaixa_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtBoleto_Boletosdatabaixa_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtBoleto_Boletosdatabaixa_Z = DateTime.MinValue;
            else
               gxTv_SdtBoleto_Boletosdatabaixa_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Boletosdatabaixa_Z
      {
         get {
            return gxTv_SdtBoleto_Boletosdatabaixa_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosdatabaixa_Z = value;
            SetDirty("Boletosdatabaixa_Z");
         }

      }

      public void gxTv_SdtBoleto_Boletosdatabaixa_Z_SetNull( )
      {
         gxTv_SdtBoleto_Boletosdatabaixa_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Boletosdatabaixa_Z");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosdatabaixa_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosValorNominal_Z" )]
      [  XmlElement( ElementName = "BoletosValorNominal_Z"   )]
      public decimal gxTpr_Boletosvalornominal_Z
      {
         get {
            return gxTv_SdtBoleto_Boletosvalornominal_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosvalornominal_Z = value;
            SetDirty("Boletosvalornominal_Z");
         }

      }

      public void gxTv_SdtBoleto_Boletosvalornominal_Z_SetNull( )
      {
         gxTv_SdtBoleto_Boletosvalornominal_Z = 0;
         SetDirty("Boletosvalornominal_Z");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosvalornominal_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosValorPago_Z" )]
      [  XmlElement( ElementName = "BoletosValorPago_Z"   )]
      public decimal gxTpr_Boletosvalorpago_Z
      {
         get {
            return gxTv_SdtBoleto_Boletosvalorpago_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosvalorpago_Z = value;
            SetDirty("Boletosvalorpago_Z");
         }

      }

      public void gxTv_SdtBoleto_Boletosvalorpago_Z_SetNull( )
      {
         gxTv_SdtBoleto_Boletosvalorpago_Z = 0;
         SetDirty("Boletosvalorpago_Z");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosvalorpago_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosValorDesconto_Z" )]
      [  XmlElement( ElementName = "BoletosValorDesconto_Z"   )]
      public decimal gxTpr_Boletosvalordesconto_Z
      {
         get {
            return gxTv_SdtBoleto_Boletosvalordesconto_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosvalordesconto_Z = value;
            SetDirty("Boletosvalordesconto_Z");
         }

      }

      public void gxTv_SdtBoleto_Boletosvalordesconto_Z_SetNull( )
      {
         gxTv_SdtBoleto_Boletosvalordesconto_Z = 0;
         SetDirty("Boletosvalordesconto_Z");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosvalordesconto_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosValorJuros_Z" )]
      [  XmlElement( ElementName = "BoletosValorJuros_Z"   )]
      public decimal gxTpr_Boletosvalorjuros_Z
      {
         get {
            return gxTv_SdtBoleto_Boletosvalorjuros_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosvalorjuros_Z = value;
            SetDirty("Boletosvalorjuros_Z");
         }

      }

      public void gxTv_SdtBoleto_Boletosvalorjuros_Z_SetNull( )
      {
         gxTv_SdtBoleto_Boletosvalorjuros_Z = 0;
         SetDirty("Boletosvalorjuros_Z");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosvalorjuros_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosValorMulta_Z" )]
      [  XmlElement( ElementName = "BoletosValorMulta_Z"   )]
      public decimal gxTpr_Boletosvalormulta_Z
      {
         get {
            return gxTv_SdtBoleto_Boletosvalormulta_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosvalormulta_Z = value;
            SetDirty("Boletosvalormulta_Z");
         }

      }

      public void gxTv_SdtBoleto_Boletosvalormulta_Z_SetNull( )
      {
         gxTv_SdtBoleto_Boletosvalormulta_Z = 0;
         SetDirty("Boletosvalormulta_Z");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosvalormulta_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosSacadoNome_Z" )]
      [  XmlElement( ElementName = "BoletosSacadoNome_Z"   )]
      public string gxTpr_Boletossacadonome_Z
      {
         get {
            return gxTv_SdtBoleto_Boletossacadonome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletossacadonome_Z = value;
            SetDirty("Boletossacadonome_Z");
         }

      }

      public void gxTv_SdtBoleto_Boletossacadonome_Z_SetNull( )
      {
         gxTv_SdtBoleto_Boletossacadonome_Z = "";
         SetDirty("Boletossacadonome_Z");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletossacadonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosSacadoDocumento_Z" )]
      [  XmlElement( ElementName = "BoletosSacadoDocumento_Z"   )]
      public string gxTpr_Boletossacadodocumento_Z
      {
         get {
            return gxTv_SdtBoleto_Boletossacadodocumento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletossacadodocumento_Z = value;
            SetDirty("Boletossacadodocumento_Z");
         }

      }

      public void gxTv_SdtBoleto_Boletossacadodocumento_Z_SetNull( )
      {
         gxTv_SdtBoleto_Boletossacadodocumento_Z = "";
         SetDirty("Boletossacadodocumento_Z");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletossacadodocumento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosSacadoTipoDocumento_Z" )]
      [  XmlElement( ElementName = "BoletosSacadoTipoDocumento_Z"   )]
      public string gxTpr_Boletossacadotipodocumento_Z
      {
         get {
            return gxTv_SdtBoleto_Boletossacadotipodocumento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletossacadotipodocumento_Z = value;
            SetDirty("Boletossacadotipodocumento_Z");
         }

      }

      public void gxTv_SdtBoleto_Boletossacadotipodocumento_Z_SetNull( )
      {
         gxTv_SdtBoleto_Boletossacadotipodocumento_Z = "";
         SetDirty("Boletossacadotipodocumento_Z");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletossacadotipodocumento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosTentativasDeRegistro_Z" )]
      [  XmlElement( ElementName = "BoletosTentativasDeRegistro_Z"   )]
      public int gxTpr_Boletostentativasderegistro_Z
      {
         get {
            return gxTv_SdtBoleto_Boletostentativasderegistro_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletostentativasderegistro_Z = value;
            SetDirty("Boletostentativasderegistro_Z");
         }

      }

      public void gxTv_SdtBoleto_Boletostentativasderegistro_Z_SetNull( )
      {
         gxTv_SdtBoleto_Boletostentativasderegistro_Z = 0;
         SetDirty("Boletostentativasderegistro_Z");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletostentativasderegistro_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosCreatedAt_Z" )]
      [  XmlElement( ElementName = "BoletosCreatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Boletoscreatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtBoleto_Boletoscreatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtBoleto_Boletoscreatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtBoleto_Boletoscreatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtBoleto_Boletoscreatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Boletoscreatedat_Z
      {
         get {
            return gxTv_SdtBoleto_Boletoscreatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletoscreatedat_Z = value;
            SetDirty("Boletoscreatedat_Z");
         }

      }

      public void gxTv_SdtBoleto_Boletoscreatedat_Z_SetNull( )
      {
         gxTv_SdtBoleto_Boletoscreatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Boletoscreatedat_Z");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletoscreatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosUpdatedAt_Z" )]
      [  XmlElement( ElementName = "BoletosUpdatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Boletosupdatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtBoleto_Boletosupdatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtBoleto_Boletosupdatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtBoleto_Boletosupdatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtBoleto_Boletosupdatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Boletosupdatedat_Z
      {
         get {
            return gxTv_SdtBoleto_Boletosupdatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosupdatedat_Z = value;
            SetDirty("Boletosupdatedat_Z");
         }

      }

      public void gxTv_SdtBoleto_Boletosupdatedat_Z_SetNull( )
      {
         gxTv_SdtBoleto_Boletosupdatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Boletosupdatedat_Z");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosupdatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosResgitroId_Z" )]
      [  XmlElement( ElementName = "BoletosResgitroId_Z"   )]
      public Guid gxTpr_Boletosresgitroid_Z
      {
         get {
            return gxTv_SdtBoleto_Boletosresgitroid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosresgitroid_Z = value;
            SetDirty("Boletosresgitroid_Z");
         }

      }

      public void gxTv_SdtBoleto_Boletosresgitroid_Z_SetNull( )
      {
         gxTv_SdtBoleto_Boletosresgitroid_Z = Guid.Empty;
         SetDirty("Boletosresgitroid_Z");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosresgitroid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaNome_Z" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaNome_Z"   )]
      public string gxTpr_Carteiradecobrancanome_Z
      {
         get {
            return gxTv_SdtBoleto_Carteiradecobrancanome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancanome_Z = value;
            SetDirty("Carteiradecobrancanome_Z");
         }

      }

      public void gxTv_SdtBoleto_Carteiradecobrancanome_Z_SetNull( )
      {
         gxTv_SdtBoleto_Carteiradecobrancanome_Z = "";
         SetDirty("Carteiradecobrancanome_Z");
         return  ;
      }

      public bool gxTv_SdtBoleto_Carteiradecobrancanome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaConvenio_Z" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaConvenio_Z"   )]
      public string gxTpr_Carteiradecobrancaconvenio_Z
      {
         get {
            return gxTv_SdtBoleto_Carteiradecobrancaconvenio_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancaconvenio_Z = value;
            SetDirty("Carteiradecobrancaconvenio_Z");
         }

      }

      public void gxTv_SdtBoleto_Carteiradecobrancaconvenio_Z_SetNull( )
      {
         gxTv_SdtBoleto_Carteiradecobrancaconvenio_Z = "";
         SetDirty("Carteiradecobrancaconvenio_Z");
         return  ;
      }

      public bool gxTv_SdtBoleto_Carteiradecobrancaconvenio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaStatus_Z" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaStatus_Z"   )]
      public bool gxTpr_Carteiradecobrancastatus_Z
      {
         get {
            return gxTv_SdtBoleto_Carteiradecobrancastatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancastatus_Z = value;
            SetDirty("Carteiradecobrancastatus_Z");
         }

      }

      public void gxTv_SdtBoleto_Carteiradecobrancastatus_Z_SetNull( )
      {
         gxTv_SdtBoleto_Carteiradecobrancastatus_Z = false;
         SetDirty("Carteiradecobrancastatus_Z");
         return  ;
      }

      public bool gxTv_SdtBoleto_Carteiradecobrancastatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaValorTotal_Z" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaValorTotal_Z"   )]
      public decimal gxTpr_Carteiradecobrancavalortotal_Z
      {
         get {
            return gxTv_SdtBoleto_Carteiradecobrancavalortotal_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancavalortotal_Z = value;
            SetDirty("Carteiradecobrancavalortotal_Z");
         }

      }

      public void gxTv_SdtBoleto_Carteiradecobrancavalortotal_Z_SetNull( )
      {
         gxTv_SdtBoleto_Carteiradecobrancavalortotal_Z = 0;
         SetDirty("Carteiradecobrancavalortotal_Z");
         return  ;
      }

      public bool gxTv_SdtBoleto_Carteiradecobrancavalortotal_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaValorRecebido_Z" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaValorRecebido_Z"   )]
      public decimal gxTpr_Carteiradecobrancavalorrecebido_Z
      {
         get {
            return gxTv_SdtBoleto_Carteiradecobrancavalorrecebido_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancavalorrecebido_Z = value;
            SetDirty("Carteiradecobrancavalorrecebido_Z");
         }

      }

      public void gxTv_SdtBoleto_Carteiradecobrancavalorrecebido_Z_SetNull( )
      {
         gxTv_SdtBoleto_Carteiradecobrancavalorrecebido_Z = 0;
         SetDirty("Carteiradecobrancavalorrecebido_Z");
         return  ;
      }

      public bool gxTv_SdtBoleto_Carteiradecobrancavalorrecebido_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaTotalBoletos_Z" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaTotalBoletos_Z"   )]
      public int gxTpr_Carteiradecobrancatotalboletos_Z
      {
         get {
            return gxTv_SdtBoleto_Carteiradecobrancatotalboletos_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancatotalboletos_Z = value;
            SetDirty("Carteiradecobrancatotalboletos_Z");
         }

      }

      public void gxTv_SdtBoleto_Carteiradecobrancatotalboletos_Z_SetNull( )
      {
         gxTv_SdtBoleto_Carteiradecobrancatotalboletos_Z = 0;
         SetDirty("Carteiradecobrancatotalboletos_Z");
         return  ;
      }

      public bool gxTv_SdtBoleto_Carteiradecobrancatotalboletos_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaTotalBoletosRegistrados_Z" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaTotalBoletosRegistrados_Z"   )]
      public int gxTpr_Carteiradecobrancatotalboletosregistrados_Z
      {
         get {
            return gxTv_SdtBoleto_Carteiradecobrancatotalboletosregistrados_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancatotalboletosregistrados_Z = value;
            SetDirty("Carteiradecobrancatotalboletosregistrados_Z");
         }

      }

      public void gxTv_SdtBoleto_Carteiradecobrancatotalboletosregistrados_Z_SetNull( )
      {
         gxTv_SdtBoleto_Carteiradecobrancatotalboletosregistrados_Z = 0;
         SetDirty("Carteiradecobrancatotalboletosregistrados_Z");
         return  ;
      }

      public bool gxTv_SdtBoleto_Carteiradecobrancatotalboletosregistrados_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaTotalBoletosExpirados_Z" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaTotalBoletosExpirados_Z"   )]
      public int gxTpr_Carteiradecobrancatotalboletosexpirados_Z
      {
         get {
            return gxTv_SdtBoleto_Carteiradecobrancatotalboletosexpirados_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancatotalboletosexpirados_Z = value;
            SetDirty("Carteiradecobrancatotalboletosexpirados_Z");
         }

      }

      public void gxTv_SdtBoleto_Carteiradecobrancatotalboletosexpirados_Z_SetNull( )
      {
         gxTv_SdtBoleto_Carteiradecobrancatotalboletosexpirados_Z = 0;
         SetDirty("Carteiradecobrancatotalboletosexpirados_Z");
         return  ;
      }

      public bool gxTv_SdtBoleto_Carteiradecobrancatotalboletosexpirados_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaTotalBoletosCancelados_Z" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaTotalBoletosCancelados_Z"   )]
      public int gxTpr_Carteiradecobrancatotalboletoscancelados_Z
      {
         get {
            return gxTv_SdtBoleto_Carteiradecobrancatotalboletoscancelados_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancatotalboletoscancelados_Z = value;
            SetDirty("Carteiradecobrancatotalboletoscancelados_Z");
         }

      }

      public void gxTv_SdtBoleto_Carteiradecobrancatotalboletoscancelados_Z_SetNull( )
      {
         gxTv_SdtBoleto_Carteiradecobrancatotalboletoscancelados_Z = 0;
         SetDirty("Carteiradecobrancatotalboletoscancelados_Z");
         return  ;
      }

      public bool gxTv_SdtBoleto_Carteiradecobrancatotalboletoscancelados_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosId_N" )]
      [  XmlElement( ElementName = "BoletosId_N"   )]
      public short gxTpr_Boletosid_N
      {
         get {
            return gxTv_SdtBoleto_Boletosid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosid_N = value;
            SetDirty("Boletosid_N");
         }

      }

      public void gxTv_SdtBoleto_Boletosid_N_SetNull( )
      {
         gxTv_SdtBoleto_Boletosid_N = 0;
         SetDirty("Boletosid_N");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaId_N" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaId_N"   )]
      public short gxTpr_Carteiradecobrancaid_N
      {
         get {
            return gxTv_SdtBoleto_Carteiradecobrancaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancaid_N = value;
            SetDirty("Carteiradecobrancaid_N");
         }

      }

      public void gxTv_SdtBoleto_Carteiradecobrancaid_N_SetNull( )
      {
         gxTv_SdtBoleto_Carteiradecobrancaid_N = 0;
         SetDirty("Carteiradecobrancaid_N");
         return  ;
      }

      public bool gxTv_SdtBoleto_Carteiradecobrancaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloId_N" )]
      [  XmlElement( ElementName = "TituloId_N"   )]
      public short gxTpr_Tituloid_N
      {
         get {
            return gxTv_SdtBoleto_Tituloid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Tituloid_N = value;
            SetDirty("Tituloid_N");
         }

      }

      public void gxTv_SdtBoleto_Tituloid_N_SetNull( )
      {
         gxTv_SdtBoleto_Tituloid_N = 0;
         SetDirty("Tituloid_N");
         return  ;
      }

      public bool gxTv_SdtBoleto_Tituloid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosNossoNumero_N" )]
      [  XmlElement( ElementName = "BoletosNossoNumero_N"   )]
      public short gxTpr_Boletosnossonumero_N
      {
         get {
            return gxTv_SdtBoleto_Boletosnossonumero_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosnossonumero_N = value;
            SetDirty("Boletosnossonumero_N");
         }

      }

      public void gxTv_SdtBoleto_Boletosnossonumero_N_SetNull( )
      {
         gxTv_SdtBoleto_Boletosnossonumero_N = 0;
         SetDirty("Boletosnossonumero_N");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosnossonumero_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosSeuNumero_N" )]
      [  XmlElement( ElementName = "BoletosSeuNumero_N"   )]
      public short gxTpr_Boletosseunumero_N
      {
         get {
            return gxTv_SdtBoleto_Boletosseunumero_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosseunumero_N = value;
            SetDirty("Boletosseunumero_N");
         }

      }

      public void gxTv_SdtBoleto_Boletosseunumero_N_SetNull( )
      {
         gxTv_SdtBoleto_Boletosseunumero_N = 0;
         SetDirty("Boletosseunumero_N");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosseunumero_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosNumero_N" )]
      [  XmlElement( ElementName = "BoletosNumero_N"   )]
      public short gxTpr_Boletosnumero_N
      {
         get {
            return gxTv_SdtBoleto_Boletosnumero_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosnumero_N = value;
            SetDirty("Boletosnumero_N");
         }

      }

      public void gxTv_SdtBoleto_Boletosnumero_N_SetNull( )
      {
         gxTv_SdtBoleto_Boletosnumero_N = 0;
         SetDirty("Boletosnumero_N");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosnumero_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosLinhaDigitavel_N" )]
      [  XmlElement( ElementName = "BoletosLinhaDigitavel_N"   )]
      public short gxTpr_Boletoslinhadigitavel_N
      {
         get {
            return gxTv_SdtBoleto_Boletoslinhadigitavel_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletoslinhadigitavel_N = value;
            SetDirty("Boletoslinhadigitavel_N");
         }

      }

      public void gxTv_SdtBoleto_Boletoslinhadigitavel_N_SetNull( )
      {
         gxTv_SdtBoleto_Boletoslinhadigitavel_N = 0;
         SetDirty("Boletoslinhadigitavel_N");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletoslinhadigitavel_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosCodigoDeBarras_N" )]
      [  XmlElement( ElementName = "BoletosCodigoDeBarras_N"   )]
      public short gxTpr_Boletoscodigodebarras_N
      {
         get {
            return gxTv_SdtBoleto_Boletoscodigodebarras_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletoscodigodebarras_N = value;
            SetDirty("Boletoscodigodebarras_N");
         }

      }

      public void gxTv_SdtBoleto_Boletoscodigodebarras_N_SetNull( )
      {
         gxTv_SdtBoleto_Boletoscodigodebarras_N = 0;
         SetDirty("Boletoscodigodebarras_N");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletoscodigodebarras_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosStatus_N" )]
      [  XmlElement( ElementName = "BoletosStatus_N"   )]
      public short gxTpr_Boletosstatus_N
      {
         get {
            return gxTv_SdtBoleto_Boletosstatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosstatus_N = value;
            SetDirty("Boletosstatus_N");
         }

      }

      public void gxTv_SdtBoleto_Boletosstatus_N_SetNull( )
      {
         gxTv_SdtBoleto_Boletosstatus_N = 0;
         SetDirty("Boletosstatus_N");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosstatus_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosDataEmissao_N" )]
      [  XmlElement( ElementName = "BoletosDataEmissao_N"   )]
      public short gxTpr_Boletosdataemissao_N
      {
         get {
            return gxTv_SdtBoleto_Boletosdataemissao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosdataemissao_N = value;
            SetDirty("Boletosdataemissao_N");
         }

      }

      public void gxTv_SdtBoleto_Boletosdataemissao_N_SetNull( )
      {
         gxTv_SdtBoleto_Boletosdataemissao_N = 0;
         SetDirty("Boletosdataemissao_N");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosdataemissao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosDataVencimento_N" )]
      [  XmlElement( ElementName = "BoletosDataVencimento_N"   )]
      public short gxTpr_Boletosdatavencimento_N
      {
         get {
            return gxTv_SdtBoleto_Boletosdatavencimento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosdatavencimento_N = value;
            SetDirty("Boletosdatavencimento_N");
         }

      }

      public void gxTv_SdtBoleto_Boletosdatavencimento_N_SetNull( )
      {
         gxTv_SdtBoleto_Boletosdatavencimento_N = 0;
         SetDirty("Boletosdatavencimento_N");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosdatavencimento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosDataRegistro_N" )]
      [  XmlElement( ElementName = "BoletosDataRegistro_N"   )]
      public short gxTpr_Boletosdataregistro_N
      {
         get {
            return gxTv_SdtBoleto_Boletosdataregistro_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosdataregistro_N = value;
            SetDirty("Boletosdataregistro_N");
         }

      }

      public void gxTv_SdtBoleto_Boletosdataregistro_N_SetNull( )
      {
         gxTv_SdtBoleto_Boletosdataregistro_N = 0;
         SetDirty("Boletosdataregistro_N");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosdataregistro_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosDataPagamento_N" )]
      [  XmlElement( ElementName = "BoletosDataPagamento_N"   )]
      public short gxTpr_Boletosdatapagamento_N
      {
         get {
            return gxTv_SdtBoleto_Boletosdatapagamento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosdatapagamento_N = value;
            SetDirty("Boletosdatapagamento_N");
         }

      }

      public void gxTv_SdtBoleto_Boletosdatapagamento_N_SetNull( )
      {
         gxTv_SdtBoleto_Boletosdatapagamento_N = 0;
         SetDirty("Boletosdatapagamento_N");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosdatapagamento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosDataBaixa_N" )]
      [  XmlElement( ElementName = "BoletosDataBaixa_N"   )]
      public short gxTpr_Boletosdatabaixa_N
      {
         get {
            return gxTv_SdtBoleto_Boletosdatabaixa_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosdatabaixa_N = value;
            SetDirty("Boletosdatabaixa_N");
         }

      }

      public void gxTv_SdtBoleto_Boletosdatabaixa_N_SetNull( )
      {
         gxTv_SdtBoleto_Boletosdatabaixa_N = 0;
         SetDirty("Boletosdatabaixa_N");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosdatabaixa_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosValorNominal_N" )]
      [  XmlElement( ElementName = "BoletosValorNominal_N"   )]
      public short gxTpr_Boletosvalornominal_N
      {
         get {
            return gxTv_SdtBoleto_Boletosvalornominal_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosvalornominal_N = value;
            SetDirty("Boletosvalornominal_N");
         }

      }

      public void gxTv_SdtBoleto_Boletosvalornominal_N_SetNull( )
      {
         gxTv_SdtBoleto_Boletosvalornominal_N = 0;
         SetDirty("Boletosvalornominal_N");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosvalornominal_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosValorPago_N" )]
      [  XmlElement( ElementName = "BoletosValorPago_N"   )]
      public short gxTpr_Boletosvalorpago_N
      {
         get {
            return gxTv_SdtBoleto_Boletosvalorpago_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosvalorpago_N = value;
            SetDirty("Boletosvalorpago_N");
         }

      }

      public void gxTv_SdtBoleto_Boletosvalorpago_N_SetNull( )
      {
         gxTv_SdtBoleto_Boletosvalorpago_N = 0;
         SetDirty("Boletosvalorpago_N");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosvalorpago_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosValorDesconto_N" )]
      [  XmlElement( ElementName = "BoletosValorDesconto_N"   )]
      public short gxTpr_Boletosvalordesconto_N
      {
         get {
            return gxTv_SdtBoleto_Boletosvalordesconto_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosvalordesconto_N = value;
            SetDirty("Boletosvalordesconto_N");
         }

      }

      public void gxTv_SdtBoleto_Boletosvalordesconto_N_SetNull( )
      {
         gxTv_SdtBoleto_Boletosvalordesconto_N = 0;
         SetDirty("Boletosvalordesconto_N");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosvalordesconto_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosValorJuros_N" )]
      [  XmlElement( ElementName = "BoletosValorJuros_N"   )]
      public short gxTpr_Boletosvalorjuros_N
      {
         get {
            return gxTv_SdtBoleto_Boletosvalorjuros_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosvalorjuros_N = value;
            SetDirty("Boletosvalorjuros_N");
         }

      }

      public void gxTv_SdtBoleto_Boletosvalorjuros_N_SetNull( )
      {
         gxTv_SdtBoleto_Boletosvalorjuros_N = 0;
         SetDirty("Boletosvalorjuros_N");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosvalorjuros_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosValorMulta_N" )]
      [  XmlElement( ElementName = "BoletosValorMulta_N"   )]
      public short gxTpr_Boletosvalormulta_N
      {
         get {
            return gxTv_SdtBoleto_Boletosvalormulta_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosvalormulta_N = value;
            SetDirty("Boletosvalormulta_N");
         }

      }

      public void gxTv_SdtBoleto_Boletosvalormulta_N_SetNull( )
      {
         gxTv_SdtBoleto_Boletosvalormulta_N = 0;
         SetDirty("Boletosvalormulta_N");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosvalormulta_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosSacadoNome_N" )]
      [  XmlElement( ElementName = "BoletosSacadoNome_N"   )]
      public short gxTpr_Boletossacadonome_N
      {
         get {
            return gxTv_SdtBoleto_Boletossacadonome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletossacadonome_N = value;
            SetDirty("Boletossacadonome_N");
         }

      }

      public void gxTv_SdtBoleto_Boletossacadonome_N_SetNull( )
      {
         gxTv_SdtBoleto_Boletossacadonome_N = 0;
         SetDirty("Boletossacadonome_N");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletossacadonome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosSacadoDocumento_N" )]
      [  XmlElement( ElementName = "BoletosSacadoDocumento_N"   )]
      public short gxTpr_Boletossacadodocumento_N
      {
         get {
            return gxTv_SdtBoleto_Boletossacadodocumento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletossacadodocumento_N = value;
            SetDirty("Boletossacadodocumento_N");
         }

      }

      public void gxTv_SdtBoleto_Boletossacadodocumento_N_SetNull( )
      {
         gxTv_SdtBoleto_Boletossacadodocumento_N = 0;
         SetDirty("Boletossacadodocumento_N");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletossacadodocumento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosSacadoTipoDocumento_N" )]
      [  XmlElement( ElementName = "BoletosSacadoTipoDocumento_N"   )]
      public short gxTpr_Boletossacadotipodocumento_N
      {
         get {
            return gxTv_SdtBoleto_Boletossacadotipodocumento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletossacadotipodocumento_N = value;
            SetDirty("Boletossacadotipodocumento_N");
         }

      }

      public void gxTv_SdtBoleto_Boletossacadotipodocumento_N_SetNull( )
      {
         gxTv_SdtBoleto_Boletossacadotipodocumento_N = 0;
         SetDirty("Boletossacadotipodocumento_N");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletossacadotipodocumento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosMensagemDeErro_N" )]
      [  XmlElement( ElementName = "BoletosMensagemDeErro_N"   )]
      public short gxTpr_Boletosmensagemdeerro_N
      {
         get {
            return gxTv_SdtBoleto_Boletosmensagemdeerro_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosmensagemdeerro_N = value;
            SetDirty("Boletosmensagemdeerro_N");
         }

      }

      public void gxTv_SdtBoleto_Boletosmensagemdeerro_N_SetNull( )
      {
         gxTv_SdtBoleto_Boletosmensagemdeerro_N = 0;
         SetDirty("Boletosmensagemdeerro_N");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosmensagemdeerro_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosTentativasDeRegistro_N" )]
      [  XmlElement( ElementName = "BoletosTentativasDeRegistro_N"   )]
      public short gxTpr_Boletostentativasderegistro_N
      {
         get {
            return gxTv_SdtBoleto_Boletostentativasderegistro_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletostentativasderegistro_N = value;
            SetDirty("Boletostentativasderegistro_N");
         }

      }

      public void gxTv_SdtBoleto_Boletostentativasderegistro_N_SetNull( )
      {
         gxTv_SdtBoleto_Boletostentativasderegistro_N = 0;
         SetDirty("Boletostentativasderegistro_N");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletostentativasderegistro_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosCreatedAt_N" )]
      [  XmlElement( ElementName = "BoletosCreatedAt_N"   )]
      public short gxTpr_Boletoscreatedat_N
      {
         get {
            return gxTv_SdtBoleto_Boletoscreatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletoscreatedat_N = value;
            SetDirty("Boletoscreatedat_N");
         }

      }

      public void gxTv_SdtBoleto_Boletoscreatedat_N_SetNull( )
      {
         gxTv_SdtBoleto_Boletoscreatedat_N = 0;
         SetDirty("Boletoscreatedat_N");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletoscreatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosUpdatedAt_N" )]
      [  XmlElement( ElementName = "BoletosUpdatedAt_N"   )]
      public short gxTpr_Boletosupdatedat_N
      {
         get {
            return gxTv_SdtBoleto_Boletosupdatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosupdatedat_N = value;
            SetDirty("Boletosupdatedat_N");
         }

      }

      public void gxTv_SdtBoleto_Boletosupdatedat_N_SetNull( )
      {
         gxTv_SdtBoleto_Boletosupdatedat_N = 0;
         SetDirty("Boletosupdatedat_N");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosupdatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BoletosResgitroId_N" )]
      [  XmlElement( ElementName = "BoletosResgitroId_N"   )]
      public short gxTpr_Boletosresgitroid_N
      {
         get {
            return gxTv_SdtBoleto_Boletosresgitroid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Boletosresgitroid_N = value;
            SetDirty("Boletosresgitroid_N");
         }

      }

      public void gxTv_SdtBoleto_Boletosresgitroid_N_SetNull( )
      {
         gxTv_SdtBoleto_Boletosresgitroid_N = 0;
         SetDirty("Boletosresgitroid_N");
         return  ;
      }

      public bool gxTv_SdtBoleto_Boletosresgitroid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaNome_N" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaNome_N"   )]
      public short gxTpr_Carteiradecobrancanome_N
      {
         get {
            return gxTv_SdtBoleto_Carteiradecobrancanome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancanome_N = value;
            SetDirty("Carteiradecobrancanome_N");
         }

      }

      public void gxTv_SdtBoleto_Carteiradecobrancanome_N_SetNull( )
      {
         gxTv_SdtBoleto_Carteiradecobrancanome_N = 0;
         SetDirty("Carteiradecobrancanome_N");
         return  ;
      }

      public bool gxTv_SdtBoleto_Carteiradecobrancanome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaConvenio_N" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaConvenio_N"   )]
      public short gxTpr_Carteiradecobrancaconvenio_N
      {
         get {
            return gxTv_SdtBoleto_Carteiradecobrancaconvenio_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancaconvenio_N = value;
            SetDirty("Carteiradecobrancaconvenio_N");
         }

      }

      public void gxTv_SdtBoleto_Carteiradecobrancaconvenio_N_SetNull( )
      {
         gxTv_SdtBoleto_Carteiradecobrancaconvenio_N = 0;
         SetDirty("Carteiradecobrancaconvenio_N");
         return  ;
      }

      public bool gxTv_SdtBoleto_Carteiradecobrancaconvenio_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaStatus_N" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaStatus_N"   )]
      public short gxTpr_Carteiradecobrancastatus_N
      {
         get {
            return gxTv_SdtBoleto_Carteiradecobrancastatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancastatus_N = value;
            SetDirty("Carteiradecobrancastatus_N");
         }

      }

      public void gxTv_SdtBoleto_Carteiradecobrancastatus_N_SetNull( )
      {
         gxTv_SdtBoleto_Carteiradecobrancastatus_N = 0;
         SetDirty("Carteiradecobrancastatus_N");
         return  ;
      }

      public bool gxTv_SdtBoleto_Carteiradecobrancastatus_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaTotalBoletosRegistrados_N" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaTotalBoletosRegistrados_N"   )]
      public short gxTpr_Carteiradecobrancatotalboletosregistrados_N
      {
         get {
            return gxTv_SdtBoleto_Carteiradecobrancatotalboletosregistrados_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancatotalboletosregistrados_N = value;
            SetDirty("Carteiradecobrancatotalboletosregistrados_N");
         }

      }

      public void gxTv_SdtBoleto_Carteiradecobrancatotalboletosregistrados_N_SetNull( )
      {
         gxTv_SdtBoleto_Carteiradecobrancatotalboletosregistrados_N = 0;
         SetDirty("Carteiradecobrancatotalboletosregistrados_N");
         return  ;
      }

      public bool gxTv_SdtBoleto_Carteiradecobrancatotalboletosregistrados_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaTotalBoletosExpirados_N" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaTotalBoletosExpirados_N"   )]
      public short gxTpr_Carteiradecobrancatotalboletosexpirados_N
      {
         get {
            return gxTv_SdtBoleto_Carteiradecobrancatotalboletosexpirados_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancatotalboletosexpirados_N = value;
            SetDirty("Carteiradecobrancatotalboletosexpirados_N");
         }

      }

      public void gxTv_SdtBoleto_Carteiradecobrancatotalboletosexpirados_N_SetNull( )
      {
         gxTv_SdtBoleto_Carteiradecobrancatotalboletosexpirados_N = 0;
         SetDirty("Carteiradecobrancatotalboletosexpirados_N");
         return  ;
      }

      public bool gxTv_SdtBoleto_Carteiradecobrancatotalboletosexpirados_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaTotalBoletosCancelados_N" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaTotalBoletosCancelados_N"   )]
      public short gxTpr_Carteiradecobrancatotalboletoscancelados_N
      {
         get {
            return gxTv_SdtBoleto_Carteiradecobrancatotalboletoscancelados_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBoleto_Carteiradecobrancatotalboletoscancelados_N = value;
            SetDirty("Carteiradecobrancatotalboletoscancelados_N");
         }

      }

      public void gxTv_SdtBoleto_Carteiradecobrancatotalboletoscancelados_N_SetNull( )
      {
         gxTv_SdtBoleto_Carteiradecobrancatotalboletoscancelados_N = 0;
         SetDirty("Carteiradecobrancatotalboletoscancelados_N");
         return  ;
      }

      public bool gxTv_SdtBoleto_Carteiradecobrancatotalboletoscancelados_N_IsNull( )
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
         gxTv_SdtBoleto_Boletosnossonumero = "";
         gxTv_SdtBoleto_Boletosseunumero = "";
         gxTv_SdtBoleto_Boletosnumero = "";
         gxTv_SdtBoleto_Boletoslinhadigitavel = "";
         gxTv_SdtBoleto_Boletoscodigodebarras = "";
         gxTv_SdtBoleto_Boletosstatus = "";
         gxTv_SdtBoleto_Boletosdataemissao = DateTime.MinValue;
         gxTv_SdtBoleto_Boletosdatavencimento = DateTime.MinValue;
         gxTv_SdtBoleto_Boletosdataregistro = (DateTime)(DateTime.MinValue);
         gxTv_SdtBoleto_Boletosdatapagamento = DateTime.MinValue;
         gxTv_SdtBoleto_Boletosdatabaixa = DateTime.MinValue;
         gxTv_SdtBoleto_Boletossacadonome = "";
         gxTv_SdtBoleto_Boletossacadodocumento = "";
         gxTv_SdtBoleto_Boletossacadotipodocumento = "";
         gxTv_SdtBoleto_Boletosmensagemdeerro = "";
         gxTv_SdtBoleto_Boletoscreatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtBoleto_Boletosupdatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtBoleto_Boletosresgitroid = Guid.Empty;
         gxTv_SdtBoleto_Carteiradecobrancanome = "";
         gxTv_SdtBoleto_Carteiradecobrancaconvenio = "";
         gxTv_SdtBoleto_Mode = "";
         gxTv_SdtBoleto_Boletosnossonumero_Z = "";
         gxTv_SdtBoleto_Boletosseunumero_Z = "";
         gxTv_SdtBoleto_Boletosnumero_Z = "";
         gxTv_SdtBoleto_Boletoslinhadigitavel_Z = "";
         gxTv_SdtBoleto_Boletoscodigodebarras_Z = "";
         gxTv_SdtBoleto_Boletosstatus_Z = "";
         gxTv_SdtBoleto_Boletosdataemissao_Z = DateTime.MinValue;
         gxTv_SdtBoleto_Boletosdatavencimento_Z = DateTime.MinValue;
         gxTv_SdtBoleto_Boletosdataregistro_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtBoleto_Boletosdatapagamento_Z = DateTime.MinValue;
         gxTv_SdtBoleto_Boletosdatabaixa_Z = DateTime.MinValue;
         gxTv_SdtBoleto_Boletossacadonome_Z = "";
         gxTv_SdtBoleto_Boletossacadodocumento_Z = "";
         gxTv_SdtBoleto_Boletossacadotipodocumento_Z = "";
         gxTv_SdtBoleto_Boletoscreatedat_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtBoleto_Boletosupdatedat_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtBoleto_Boletosresgitroid_Z = Guid.Empty;
         gxTv_SdtBoleto_Carteiradecobrancanome_Z = "";
         gxTv_SdtBoleto_Carteiradecobrancaconvenio_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "boleto", "GeneXus.Programs.boleto_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtBoleto_Initialized ;
      private short gxTv_SdtBoleto_Boletosid_N ;
      private short gxTv_SdtBoleto_Carteiradecobrancaid_N ;
      private short gxTv_SdtBoleto_Tituloid_N ;
      private short gxTv_SdtBoleto_Boletosnossonumero_N ;
      private short gxTv_SdtBoleto_Boletosseunumero_N ;
      private short gxTv_SdtBoleto_Boletosnumero_N ;
      private short gxTv_SdtBoleto_Boletoslinhadigitavel_N ;
      private short gxTv_SdtBoleto_Boletoscodigodebarras_N ;
      private short gxTv_SdtBoleto_Boletosstatus_N ;
      private short gxTv_SdtBoleto_Boletosdataemissao_N ;
      private short gxTv_SdtBoleto_Boletosdatavencimento_N ;
      private short gxTv_SdtBoleto_Boletosdataregistro_N ;
      private short gxTv_SdtBoleto_Boletosdatapagamento_N ;
      private short gxTv_SdtBoleto_Boletosdatabaixa_N ;
      private short gxTv_SdtBoleto_Boletosvalornominal_N ;
      private short gxTv_SdtBoleto_Boletosvalorpago_N ;
      private short gxTv_SdtBoleto_Boletosvalordesconto_N ;
      private short gxTv_SdtBoleto_Boletosvalorjuros_N ;
      private short gxTv_SdtBoleto_Boletosvalormulta_N ;
      private short gxTv_SdtBoleto_Boletossacadonome_N ;
      private short gxTv_SdtBoleto_Boletossacadodocumento_N ;
      private short gxTv_SdtBoleto_Boletossacadotipodocumento_N ;
      private short gxTv_SdtBoleto_Boletosmensagemdeerro_N ;
      private short gxTv_SdtBoleto_Boletostentativasderegistro_N ;
      private short gxTv_SdtBoleto_Boletoscreatedat_N ;
      private short gxTv_SdtBoleto_Boletosupdatedat_N ;
      private short gxTv_SdtBoleto_Boletosresgitroid_N ;
      private short gxTv_SdtBoleto_Carteiradecobrancanome_N ;
      private short gxTv_SdtBoleto_Carteiradecobrancaconvenio_N ;
      private short gxTv_SdtBoleto_Carteiradecobrancastatus_N ;
      private short gxTv_SdtBoleto_Carteiradecobrancatotalboletosregistrados_N ;
      private short gxTv_SdtBoleto_Carteiradecobrancatotalboletosexpirados_N ;
      private short gxTv_SdtBoleto_Carteiradecobrancatotalboletoscancelados_N ;
      private int gxTv_SdtBoleto_Boletosid ;
      private int gxTv_SdtBoleto_Carteiradecobrancaid ;
      private int gxTv_SdtBoleto_Tituloid ;
      private int gxTv_SdtBoleto_Boletostentativasderegistro ;
      private int gxTv_SdtBoleto_Carteiradecobrancatotalboletos ;
      private int gxTv_SdtBoleto_Carteiradecobrancatotalboletosregistrados ;
      private int gxTv_SdtBoleto_Carteiradecobrancatotalboletosexpirados ;
      private int gxTv_SdtBoleto_Carteiradecobrancatotalboletoscancelados ;
      private int gxTv_SdtBoleto_Boletosid_Z ;
      private int gxTv_SdtBoleto_Carteiradecobrancaid_Z ;
      private int gxTv_SdtBoleto_Tituloid_Z ;
      private int gxTv_SdtBoleto_Boletostentativasderegistro_Z ;
      private int gxTv_SdtBoleto_Carteiradecobrancatotalboletos_Z ;
      private int gxTv_SdtBoleto_Carteiradecobrancatotalboletosregistrados_Z ;
      private int gxTv_SdtBoleto_Carteiradecobrancatotalboletosexpirados_Z ;
      private int gxTv_SdtBoleto_Carteiradecobrancatotalboletoscancelados_Z ;
      private decimal gxTv_SdtBoleto_Boletosvalornominal ;
      private decimal gxTv_SdtBoleto_Boletosvalorpago ;
      private decimal gxTv_SdtBoleto_Boletosvalordesconto ;
      private decimal gxTv_SdtBoleto_Boletosvalorjuros ;
      private decimal gxTv_SdtBoleto_Boletosvalormulta ;
      private decimal gxTv_SdtBoleto_Carteiradecobrancavalortotal ;
      private decimal gxTv_SdtBoleto_Carteiradecobrancavalorrecebido ;
      private decimal gxTv_SdtBoleto_Boletosvalornominal_Z ;
      private decimal gxTv_SdtBoleto_Boletosvalorpago_Z ;
      private decimal gxTv_SdtBoleto_Boletosvalordesconto_Z ;
      private decimal gxTv_SdtBoleto_Boletosvalorjuros_Z ;
      private decimal gxTv_SdtBoleto_Boletosvalormulta_Z ;
      private decimal gxTv_SdtBoleto_Carteiradecobrancavalortotal_Z ;
      private decimal gxTv_SdtBoleto_Carteiradecobrancavalorrecebido_Z ;
      private string gxTv_SdtBoleto_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtBoleto_Boletosdataregistro ;
      private DateTime gxTv_SdtBoleto_Boletoscreatedat ;
      private DateTime gxTv_SdtBoleto_Boletosupdatedat ;
      private DateTime gxTv_SdtBoleto_Boletosdataregistro_Z ;
      private DateTime gxTv_SdtBoleto_Boletoscreatedat_Z ;
      private DateTime gxTv_SdtBoleto_Boletosupdatedat_Z ;
      private DateTime datetime_STZ ;
      private DateTime gxTv_SdtBoleto_Boletosdataemissao ;
      private DateTime gxTv_SdtBoleto_Boletosdatavencimento ;
      private DateTime gxTv_SdtBoleto_Boletosdatapagamento ;
      private DateTime gxTv_SdtBoleto_Boletosdatabaixa ;
      private DateTime gxTv_SdtBoleto_Boletosdataemissao_Z ;
      private DateTime gxTv_SdtBoleto_Boletosdatavencimento_Z ;
      private DateTime gxTv_SdtBoleto_Boletosdatapagamento_Z ;
      private DateTime gxTv_SdtBoleto_Boletosdatabaixa_Z ;
      private bool gxTv_SdtBoleto_Carteiradecobrancastatus ;
      private bool gxTv_SdtBoleto_Carteiradecobrancastatus_Z ;
      private string gxTv_SdtBoleto_Boletosmensagemdeerro ;
      private string gxTv_SdtBoleto_Boletosnossonumero ;
      private string gxTv_SdtBoleto_Boletosseunumero ;
      private string gxTv_SdtBoleto_Boletosnumero ;
      private string gxTv_SdtBoleto_Boletoslinhadigitavel ;
      private string gxTv_SdtBoleto_Boletoscodigodebarras ;
      private string gxTv_SdtBoleto_Boletosstatus ;
      private string gxTv_SdtBoleto_Boletossacadonome ;
      private string gxTv_SdtBoleto_Boletossacadodocumento ;
      private string gxTv_SdtBoleto_Boletossacadotipodocumento ;
      private string gxTv_SdtBoleto_Carteiradecobrancanome ;
      private string gxTv_SdtBoleto_Carteiradecobrancaconvenio ;
      private string gxTv_SdtBoleto_Boletosnossonumero_Z ;
      private string gxTv_SdtBoleto_Boletosseunumero_Z ;
      private string gxTv_SdtBoleto_Boletosnumero_Z ;
      private string gxTv_SdtBoleto_Boletoslinhadigitavel_Z ;
      private string gxTv_SdtBoleto_Boletoscodigodebarras_Z ;
      private string gxTv_SdtBoleto_Boletosstatus_Z ;
      private string gxTv_SdtBoleto_Boletossacadonome_Z ;
      private string gxTv_SdtBoleto_Boletossacadodocumento_Z ;
      private string gxTv_SdtBoleto_Boletossacadotipodocumento_Z ;
      private string gxTv_SdtBoleto_Carteiradecobrancanome_Z ;
      private string gxTv_SdtBoleto_Carteiradecobrancaconvenio_Z ;
      private Guid gxTv_SdtBoleto_Boletosresgitroid ;
      private Guid gxTv_SdtBoleto_Boletosresgitroid_Z ;
   }

   [DataContract(Name = @"Boleto", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtBoleto_RESTInterface : GxGenericCollectionItem<SdtBoleto>
   {
      public SdtBoleto_RESTInterface( ) : base()
      {
      }

      public SdtBoleto_RESTInterface( SdtBoleto psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "BoletosId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Boletosid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Boletosid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Boletosid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "CarteiraDeCobrancaId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Carteiradecobrancaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Carteiradecobrancaid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Carteiradecobrancaid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "TituloId" , Order = 2 )]
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

      [DataMember( Name = "BoletosNossoNumero" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Boletosnossonumero
      {
         get {
            return sdt.gxTpr_Boletosnossonumero ;
         }

         set {
            sdt.gxTpr_Boletosnossonumero = value;
         }

      }

      [DataMember( Name = "BoletosSeuNumero" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Boletosseunumero
      {
         get {
            return sdt.gxTpr_Boletosseunumero ;
         }

         set {
            sdt.gxTpr_Boletosseunumero = value;
         }

      }

      [DataMember( Name = "BoletosNumero" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Boletosnumero
      {
         get {
            return sdt.gxTpr_Boletosnumero ;
         }

         set {
            sdt.gxTpr_Boletosnumero = value;
         }

      }

      [DataMember( Name = "BoletosLinhaDigitavel" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Boletoslinhadigitavel
      {
         get {
            return sdt.gxTpr_Boletoslinhadigitavel ;
         }

         set {
            sdt.gxTpr_Boletoslinhadigitavel = value;
         }

      }

      [DataMember( Name = "BoletosCodigoDeBarras" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Boletoscodigodebarras
      {
         get {
            return sdt.gxTpr_Boletoscodigodebarras ;
         }

         set {
            sdt.gxTpr_Boletoscodigodebarras = value;
         }

      }

      [DataMember( Name = "BoletosStatus" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Boletosstatus
      {
         get {
            return sdt.gxTpr_Boletosstatus ;
         }

         set {
            sdt.gxTpr_Boletosstatus = value;
         }

      }

      [DataMember( Name = "BoletosDataEmissao" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Boletosdataemissao
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Boletosdataemissao) ;
         }

         set {
            sdt.gxTpr_Boletosdataemissao = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "BoletosDataVencimento" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Boletosdatavencimento
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Boletosdatavencimento) ;
         }

         set {
            sdt.gxTpr_Boletosdatavencimento = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "BoletosDataRegistro" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Boletosdataregistro
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Boletosdataregistro, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Boletosdataregistro = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "BoletosDataPagamento" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Boletosdatapagamento
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Boletosdatapagamento) ;
         }

         set {
            sdt.gxTpr_Boletosdatapagamento = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "BoletosDataBaixa" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Boletosdatabaixa
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Boletosdatabaixa) ;
         }

         set {
            sdt.gxTpr_Boletosdatabaixa = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "BoletosValorNominal" , Order = 14 )]
      [GxSeudo()]
      public string gxTpr_Boletosvalornominal
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Boletosvalornominal, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Boletosvalornominal = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "BoletosValorPago" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Boletosvalorpago
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Boletosvalorpago, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Boletosvalorpago = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "BoletosValorDesconto" , Order = 16 )]
      [GxSeudo()]
      public string gxTpr_Boletosvalordesconto
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Boletosvalordesconto, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Boletosvalordesconto = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "BoletosValorJuros" , Order = 17 )]
      [GxSeudo()]
      public string gxTpr_Boletosvalorjuros
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Boletosvalorjuros, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Boletosvalorjuros = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "BoletosValorMulta" , Order = 18 )]
      [GxSeudo()]
      public string gxTpr_Boletosvalormulta
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Boletosvalormulta, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Boletosvalormulta = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "BoletosSacadoNome" , Order = 19 )]
      [GxSeudo()]
      public string gxTpr_Boletossacadonome
      {
         get {
            return sdt.gxTpr_Boletossacadonome ;
         }

         set {
            sdt.gxTpr_Boletossacadonome = value;
         }

      }

      [DataMember( Name = "BoletosSacadoDocumento" , Order = 20 )]
      [GxSeudo()]
      public string gxTpr_Boletossacadodocumento
      {
         get {
            return sdt.gxTpr_Boletossacadodocumento ;
         }

         set {
            sdt.gxTpr_Boletossacadodocumento = value;
         }

      }

      [DataMember( Name = "BoletosSacadoTipoDocumento" , Order = 21 )]
      [GxSeudo()]
      public string gxTpr_Boletossacadotipodocumento
      {
         get {
            return sdt.gxTpr_Boletossacadotipodocumento ;
         }

         set {
            sdt.gxTpr_Boletossacadotipodocumento = value;
         }

      }

      [DataMember( Name = "BoletosMensagemDeErro" , Order = 22 )]
      public string gxTpr_Boletosmensagemdeerro
      {
         get {
            return sdt.gxTpr_Boletosmensagemdeerro ;
         }

         set {
            sdt.gxTpr_Boletosmensagemdeerro = value;
         }

      }

      [DataMember( Name = "BoletosTentativasDeRegistro" , Order = 23 )]
      [GxSeudo()]
      public string gxTpr_Boletostentativasderegistro
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Boletostentativasderegistro), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Boletostentativasderegistro = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "BoletosCreatedAt" , Order = 24 )]
      [GxSeudo()]
      public string gxTpr_Boletoscreatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Boletoscreatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Boletoscreatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "BoletosUpdatedAt" , Order = 25 )]
      [GxSeudo()]
      public string gxTpr_Boletosupdatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Boletosupdatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Boletosupdatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "BoletosResgitroId" , Order = 26 )]
      [GxSeudo()]
      public Guid gxTpr_Boletosresgitroid
      {
         get {
            return sdt.gxTpr_Boletosresgitroid ;
         }

         set {
            sdt.gxTpr_Boletosresgitroid = value;
         }

      }

      [DataMember( Name = "CarteiraDeCobrancaNome" , Order = 27 )]
      [GxSeudo()]
      public string gxTpr_Carteiradecobrancanome
      {
         get {
            return sdt.gxTpr_Carteiradecobrancanome ;
         }

         set {
            sdt.gxTpr_Carteiradecobrancanome = value;
         }

      }

      [DataMember( Name = "CarteiraDeCobrancaConvenio" , Order = 28 )]
      [GxSeudo()]
      public string gxTpr_Carteiradecobrancaconvenio
      {
         get {
            return sdt.gxTpr_Carteiradecobrancaconvenio ;
         }

         set {
            sdt.gxTpr_Carteiradecobrancaconvenio = value;
         }

      }

      [DataMember( Name = "CarteiraDeCobrancaStatus" , Order = 29 )]
      [GxSeudo()]
      public bool gxTpr_Carteiradecobrancastatus
      {
         get {
            return sdt.gxTpr_Carteiradecobrancastatus ;
         }

         set {
            sdt.gxTpr_Carteiradecobrancastatus = value;
         }

      }

      [DataMember( Name = "CarteiraDeCobrancaValorTotal" , Order = 30 )]
      [GxSeudo()]
      public string gxTpr_Carteiradecobrancavalortotal
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Carteiradecobrancavalortotal, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Carteiradecobrancavalortotal = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "CarteiraDeCobrancaValorRecebido" , Order = 31 )]
      [GxSeudo()]
      public string gxTpr_Carteiradecobrancavalorrecebido
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Carteiradecobrancavalorrecebido, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Carteiradecobrancavalorrecebido = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "CarteiraDeCobrancaTotalBoletos" , Order = 32 )]
      [GxSeudo()]
      public string gxTpr_Carteiradecobrancatotalboletos
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Carteiradecobrancatotalboletos), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Carteiradecobrancatotalboletos = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "CarteiraDeCobrancaTotalBoletosRegistrados" , Order = 33 )]
      [GxSeudo()]
      public string gxTpr_Carteiradecobrancatotalboletosregistrados
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Carteiradecobrancatotalboletosregistrados), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Carteiradecobrancatotalboletosregistrados = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "CarteiraDeCobrancaTotalBoletosExpirados" , Order = 34 )]
      [GxSeudo()]
      public string gxTpr_Carteiradecobrancatotalboletosexpirados
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Carteiradecobrancatotalboletosexpirados), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Carteiradecobrancatotalboletosexpirados = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "CarteiraDeCobrancaTotalBoletosCancelados" , Order = 35 )]
      [GxSeudo()]
      public string gxTpr_Carteiradecobrancatotalboletoscancelados
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Carteiradecobrancatotalboletoscancelados), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Carteiradecobrancatotalboletoscancelados = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      public SdtBoleto sdt
      {
         get {
            return (SdtBoleto)Sdt ;
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
            sdt = new SdtBoleto() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 36 )]
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

   [DataContract(Name = @"Boleto", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtBoleto_RESTLInterface : GxGenericCollectionItem<SdtBoleto>
   {
      public SdtBoleto_RESTLInterface( ) : base()
      {
      }

      public SdtBoleto_RESTLInterface( SdtBoleto psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "BoletosNossoNumero" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Boletosnossonumero
      {
         get {
            return sdt.gxTpr_Boletosnossonumero ;
         }

         set {
            sdt.gxTpr_Boletosnossonumero = value;
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

      public SdtBoleto sdt
      {
         get {
            return (SdtBoleto)Sdt ;
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
            sdt = new SdtBoleto() ;
         }
      }

   }

}
