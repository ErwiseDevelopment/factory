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
   [XmlRoot(ElementName = "NotaFiscal" )]
   [XmlType(TypeName =  "NotaFiscal" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtNotaFiscal : GxSilentTrnSdt
   {
      public SdtNotaFiscal( )
      {
      }

      public SdtNotaFiscal( IGxContext context )
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

      public void Load( Guid AV794NotaFiscalId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV794NotaFiscalId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"NotaFiscalId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "NotaFiscal");
         metadata.Set("BT", "NotaFiscal");
         metadata.Set("PK", "[ \"NotaFiscalId\" ]");
         metadata.Set("PKAssigned", "[ \"NotaFiscalId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ClienteId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ClienteId\" ],\"FKMap\":[ \"NotaFiscalDestinatarioClienteId-ClienteId\" ] } ]");
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
         state.Add("gxTpr_Notafiscalid_Z");
         state.Add("gxTpr_Clienteid_Z");
         state.Add("gxTpr_Notafiscaluf_Z");
         state.Add("gxTpr_Notafiscalvalortotal_f_Z");
         state.Add("gxTpr_Notafiscalvalortotalvendido_f_Z");
         state.Add("gxTpr_Notafiscalsaldo_f_Z");
         state.Add("gxTpr_Notafiscalquantidadedeitens_f_Z");
         state.Add("gxTpr_Notafiscalquantidadedeitensvendidos_f_Z");
         state.Add("gxTpr_Notafiscalquantidaderesumo_f_Z");
         state.Add("gxTpr_Notafiscalvalorformatado_f_Z");
         state.Add("gxTpr_Notafiscalvalorvendidoformatado_f_Z");
         state.Add("gxTpr_Notafiscalsaldoformatado_f_Z");
         state.Add("gxTpr_Notafiscalstatus_Z");
         state.Add("gxTpr_Notafiscalnatureza_Z");
         state.Add("gxTpr_Notafiscalmod_Z");
         state.Add("gxTpr_Notafiscalserie_Z");
         state.Add("gxTpr_Notafiscalnumero_Z");
         state.Add("gxTpr_Notafiscaldataemissao_Z_Nullable");
         state.Add("gxTpr_Notafiscaldatasaida_Z_Nullable");
         state.Add("gxTpr_Notafiscaltipo_Z");
         state.Add("gxTpr_Notafiscalmunicipio_Z");
         state.Add("gxTpr_Notafiscaltipoemissao_Z");
         state.Add("gxTpr_Notafiscalambiente_Z");
         state.Add("gxTpr_Notafiscalfinalidades_Z");
         state.Add("gxTpr_Notafiscaemitenteldocumento_Z");
         state.Add("gxTpr_Notafiscalemitentenome_Z");
         state.Add("gxTpr_Notafiscalemitentelogradouro_Z");
         state.Add("gxTpr_Notafiscalemitentelognum_Z");
         state.Add("gxTpr_Notafiscalemitentecomplemento_Z");
         state.Add("gxTpr_Notafiscalemitentebairro_Z");
         state.Add("gxTpr_Notafiscalemitentemunicipio_Z");
         state.Add("gxTpr_Notafiscalemitenteuf_Z");
         state.Add("gxTpr_Notafiscalemitentecep_Z");
         state.Add("gxTpr_Notafiscalemitentepais_Z");
         state.Add("gxTpr_Notafiscalemitentetelefone_Z");
         state.Add("gxTpr_Notafiscalemitenteie_Z");
         state.Add("gxTpr_Notafiscaldestinatarioclienteid_Z");
         state.Add("gxTpr_Notafiscaldestinatariodocumento_Z");
         state.Add("gxTpr_Notafiscaldestinatarionome_Z");
         state.Add("gxTpr_Notafiscaldestinatariologradouro_Z");
         state.Add("gxTpr_Notafiscaldestinatariolognum_Z");
         state.Add("gxTpr_Notafiscaldestinatariocomplemento_Z");
         state.Add("gxTpr_Notafiscaldestinatariobairro_Z");
         state.Add("gxTpr_Notafiscaldestinatariomunicipio_Z");
         state.Add("gxTpr_Notafiscaldestinatariouf_Z");
         state.Add("gxTpr_Notafiscaldestinatariocep_Z");
         state.Add("gxTpr_Notafiscaldestinatariopais_Z");
         state.Add("gxTpr_Notafiscaldestinatariofone_Z");
         state.Add("gxTpr_Notafiscalid_N");
         state.Add("gxTpr_Clienteid_N");
         state.Add("gxTpr_Notafiscaluf_N");
         state.Add("gxTpr_Notafiscalnatureza_N");
         state.Add("gxTpr_Notafiscalmod_N");
         state.Add("gxTpr_Notafiscalserie_N");
         state.Add("gxTpr_Notafiscalnumero_N");
         state.Add("gxTpr_Notafiscaldataemissao_N");
         state.Add("gxTpr_Notafiscaldatasaida_N");
         state.Add("gxTpr_Notafiscaltipo_N");
         state.Add("gxTpr_Notafiscalmunicipio_N");
         state.Add("gxTpr_Notafiscaltipoemissao_N");
         state.Add("gxTpr_Notafiscalambiente_N");
         state.Add("gxTpr_Notafiscalfinalidades_N");
         state.Add("gxTpr_Notafiscaemitenteldocumento_N");
         state.Add("gxTpr_Notafiscalemitentenome_N");
         state.Add("gxTpr_Notafiscalemitentelogradouro_N");
         state.Add("gxTpr_Notafiscalemitentelognum_N");
         state.Add("gxTpr_Notafiscalemitentecomplemento_N");
         state.Add("gxTpr_Notafiscalemitentebairro_N");
         state.Add("gxTpr_Notafiscalemitentemunicipio_N");
         state.Add("gxTpr_Notafiscalemitenteuf_N");
         state.Add("gxTpr_Notafiscalemitentecep_N");
         state.Add("gxTpr_Notafiscalemitentepais_N");
         state.Add("gxTpr_Notafiscalemitentetelefone_N");
         state.Add("gxTpr_Notafiscalemitenteie_N");
         state.Add("gxTpr_Notafiscaldestinatarioclienteid_N");
         state.Add("gxTpr_Notafiscaldestinatariodocumento_N");
         state.Add("gxTpr_Notafiscaldestinatarionome_N");
         state.Add("gxTpr_Notafiscaldestinatariologradouro_N");
         state.Add("gxTpr_Notafiscaldestinatariolognum_N");
         state.Add("gxTpr_Notafiscaldestinatariocomplemento_N");
         state.Add("gxTpr_Notafiscaldestinatariobairro_N");
         state.Add("gxTpr_Notafiscaldestinatariomunicipio_N");
         state.Add("gxTpr_Notafiscaldestinatariouf_N");
         state.Add("gxTpr_Notafiscaldestinatariocep_N");
         state.Add("gxTpr_Notafiscaldestinatariopais_N");
         state.Add("gxTpr_Notafiscaldestinatariofone_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtNotaFiscal sdt;
         sdt = (SdtNotaFiscal)(source);
         gxTv_SdtNotaFiscal_Notafiscalid = sdt.gxTv_SdtNotaFiscal_Notafiscalid ;
         gxTv_SdtNotaFiscal_Clienteid = sdt.gxTv_SdtNotaFiscal_Clienteid ;
         gxTv_SdtNotaFiscal_Notafiscaluf = sdt.gxTv_SdtNotaFiscal_Notafiscaluf ;
         gxTv_SdtNotaFiscal_Notafiscalvalortotal_f = sdt.gxTv_SdtNotaFiscal_Notafiscalvalortotal_f ;
         gxTv_SdtNotaFiscal_Notafiscalvalortotalvendido_f = sdt.gxTv_SdtNotaFiscal_Notafiscalvalortotalvendido_f ;
         gxTv_SdtNotaFiscal_Notafiscalsaldo_f = sdt.gxTv_SdtNotaFiscal_Notafiscalsaldo_f ;
         gxTv_SdtNotaFiscal_Notafiscalquantidadedeitens_f = sdt.gxTv_SdtNotaFiscal_Notafiscalquantidadedeitens_f ;
         gxTv_SdtNotaFiscal_Notafiscalquantidadedeitensvendidos_f = sdt.gxTv_SdtNotaFiscal_Notafiscalquantidadedeitensvendidos_f ;
         gxTv_SdtNotaFiscal_Notafiscalquantidaderesumo_f = sdt.gxTv_SdtNotaFiscal_Notafiscalquantidaderesumo_f ;
         gxTv_SdtNotaFiscal_Notafiscalvalorformatado_f = sdt.gxTv_SdtNotaFiscal_Notafiscalvalorformatado_f ;
         gxTv_SdtNotaFiscal_Notafiscalvalorvendidoformatado_f = sdt.gxTv_SdtNotaFiscal_Notafiscalvalorvendidoformatado_f ;
         gxTv_SdtNotaFiscal_Notafiscalsaldoformatado_f = sdt.gxTv_SdtNotaFiscal_Notafiscalsaldoformatado_f ;
         gxTv_SdtNotaFiscal_Notafiscalstatus = sdt.gxTv_SdtNotaFiscal_Notafiscalstatus ;
         gxTv_SdtNotaFiscal_Notafiscalnatureza = sdt.gxTv_SdtNotaFiscal_Notafiscalnatureza ;
         gxTv_SdtNotaFiscal_Notafiscalmod = sdt.gxTv_SdtNotaFiscal_Notafiscalmod ;
         gxTv_SdtNotaFiscal_Notafiscalserie = sdt.gxTv_SdtNotaFiscal_Notafiscalserie ;
         gxTv_SdtNotaFiscal_Notafiscalnumero = sdt.gxTv_SdtNotaFiscal_Notafiscalnumero ;
         gxTv_SdtNotaFiscal_Notafiscaldataemissao = sdt.gxTv_SdtNotaFiscal_Notafiscaldataemissao ;
         gxTv_SdtNotaFiscal_Notafiscaldatasaida = sdt.gxTv_SdtNotaFiscal_Notafiscaldatasaida ;
         gxTv_SdtNotaFiscal_Notafiscaltipo = sdt.gxTv_SdtNotaFiscal_Notafiscaltipo ;
         gxTv_SdtNotaFiscal_Notafiscalmunicipio = sdt.gxTv_SdtNotaFiscal_Notafiscalmunicipio ;
         gxTv_SdtNotaFiscal_Notafiscaltipoemissao = sdt.gxTv_SdtNotaFiscal_Notafiscaltipoemissao ;
         gxTv_SdtNotaFiscal_Notafiscalambiente = sdt.gxTv_SdtNotaFiscal_Notafiscalambiente ;
         gxTv_SdtNotaFiscal_Notafiscalfinalidades = sdt.gxTv_SdtNotaFiscal_Notafiscalfinalidades ;
         gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento = sdt.gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento ;
         gxTv_SdtNotaFiscal_Notafiscalemitentenome = sdt.gxTv_SdtNotaFiscal_Notafiscalemitentenome ;
         gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro = sdt.gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro ;
         gxTv_SdtNotaFiscal_Notafiscalemitentelognum = sdt.gxTv_SdtNotaFiscal_Notafiscalemitentelognum ;
         gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento = sdt.gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento ;
         gxTv_SdtNotaFiscal_Notafiscalemitentebairro = sdt.gxTv_SdtNotaFiscal_Notafiscalemitentebairro ;
         gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio = sdt.gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio ;
         gxTv_SdtNotaFiscal_Notafiscalemitenteuf = sdt.gxTv_SdtNotaFiscal_Notafiscalemitenteuf ;
         gxTv_SdtNotaFiscal_Notafiscalemitentecep = sdt.gxTv_SdtNotaFiscal_Notafiscalemitentecep ;
         gxTv_SdtNotaFiscal_Notafiscalemitentepais = sdt.gxTv_SdtNotaFiscal_Notafiscalemitentepais ;
         gxTv_SdtNotaFiscal_Notafiscalemitentetelefone = sdt.gxTv_SdtNotaFiscal_Notafiscalemitentetelefone ;
         gxTv_SdtNotaFiscal_Notafiscalemitenteie = sdt.gxTv_SdtNotaFiscal_Notafiscalemitenteie ;
         gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid ;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento ;
         gxTv_SdtNotaFiscal_Notafiscaldestinatarionome = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatarionome ;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro ;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum ;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento ;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro ;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio ;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariouf = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariouf ;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariocep = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariocep ;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariopais = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariopais ;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariofone = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariofone ;
         gxTv_SdtNotaFiscal_Mode = sdt.gxTv_SdtNotaFiscal_Mode ;
         gxTv_SdtNotaFiscal_Initialized = sdt.gxTv_SdtNotaFiscal_Initialized ;
         gxTv_SdtNotaFiscal_Notafiscalid_Z = sdt.gxTv_SdtNotaFiscal_Notafiscalid_Z ;
         gxTv_SdtNotaFiscal_Clienteid_Z = sdt.gxTv_SdtNotaFiscal_Clienteid_Z ;
         gxTv_SdtNotaFiscal_Notafiscaluf_Z = sdt.gxTv_SdtNotaFiscal_Notafiscaluf_Z ;
         gxTv_SdtNotaFiscal_Notafiscalvalortotal_f_Z = sdt.gxTv_SdtNotaFiscal_Notafiscalvalortotal_f_Z ;
         gxTv_SdtNotaFiscal_Notafiscalvalortotalvendido_f_Z = sdt.gxTv_SdtNotaFiscal_Notafiscalvalortotalvendido_f_Z ;
         gxTv_SdtNotaFiscal_Notafiscalsaldo_f_Z = sdt.gxTv_SdtNotaFiscal_Notafiscalsaldo_f_Z ;
         gxTv_SdtNotaFiscal_Notafiscalquantidadedeitens_f_Z = sdt.gxTv_SdtNotaFiscal_Notafiscalquantidadedeitens_f_Z ;
         gxTv_SdtNotaFiscal_Notafiscalquantidadedeitensvendidos_f_Z = sdt.gxTv_SdtNotaFiscal_Notafiscalquantidadedeitensvendidos_f_Z ;
         gxTv_SdtNotaFiscal_Notafiscalquantidaderesumo_f_Z = sdt.gxTv_SdtNotaFiscal_Notafiscalquantidaderesumo_f_Z ;
         gxTv_SdtNotaFiscal_Notafiscalvalorformatado_f_Z = sdt.gxTv_SdtNotaFiscal_Notafiscalvalorformatado_f_Z ;
         gxTv_SdtNotaFiscal_Notafiscalvalorvendidoformatado_f_Z = sdt.gxTv_SdtNotaFiscal_Notafiscalvalorvendidoformatado_f_Z ;
         gxTv_SdtNotaFiscal_Notafiscalsaldoformatado_f_Z = sdt.gxTv_SdtNotaFiscal_Notafiscalsaldoformatado_f_Z ;
         gxTv_SdtNotaFiscal_Notafiscalstatus_Z = sdt.gxTv_SdtNotaFiscal_Notafiscalstatus_Z ;
         gxTv_SdtNotaFiscal_Notafiscalnatureza_Z = sdt.gxTv_SdtNotaFiscal_Notafiscalnatureza_Z ;
         gxTv_SdtNotaFiscal_Notafiscalmod_Z = sdt.gxTv_SdtNotaFiscal_Notafiscalmod_Z ;
         gxTv_SdtNotaFiscal_Notafiscalserie_Z = sdt.gxTv_SdtNotaFiscal_Notafiscalserie_Z ;
         gxTv_SdtNotaFiscal_Notafiscalnumero_Z = sdt.gxTv_SdtNotaFiscal_Notafiscalnumero_Z ;
         gxTv_SdtNotaFiscal_Notafiscaldataemissao_Z = sdt.gxTv_SdtNotaFiscal_Notafiscaldataemissao_Z ;
         gxTv_SdtNotaFiscal_Notafiscaldatasaida_Z = sdt.gxTv_SdtNotaFiscal_Notafiscaldatasaida_Z ;
         gxTv_SdtNotaFiscal_Notafiscaltipo_Z = sdt.gxTv_SdtNotaFiscal_Notafiscaltipo_Z ;
         gxTv_SdtNotaFiscal_Notafiscalmunicipio_Z = sdt.gxTv_SdtNotaFiscal_Notafiscalmunicipio_Z ;
         gxTv_SdtNotaFiscal_Notafiscaltipoemissao_Z = sdt.gxTv_SdtNotaFiscal_Notafiscaltipoemissao_Z ;
         gxTv_SdtNotaFiscal_Notafiscalambiente_Z = sdt.gxTv_SdtNotaFiscal_Notafiscalambiente_Z ;
         gxTv_SdtNotaFiscal_Notafiscalfinalidades_Z = sdt.gxTv_SdtNotaFiscal_Notafiscalfinalidades_Z ;
         gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento_Z = sdt.gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento_Z ;
         gxTv_SdtNotaFiscal_Notafiscalemitentenome_Z = sdt.gxTv_SdtNotaFiscal_Notafiscalemitentenome_Z ;
         gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro_Z = sdt.gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro_Z ;
         gxTv_SdtNotaFiscal_Notafiscalemitentelognum_Z = sdt.gxTv_SdtNotaFiscal_Notafiscalemitentelognum_Z ;
         gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento_Z = sdt.gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento_Z ;
         gxTv_SdtNotaFiscal_Notafiscalemitentebairro_Z = sdt.gxTv_SdtNotaFiscal_Notafiscalemitentebairro_Z ;
         gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio_Z = sdt.gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio_Z ;
         gxTv_SdtNotaFiscal_Notafiscalemitenteuf_Z = sdt.gxTv_SdtNotaFiscal_Notafiscalemitenteuf_Z ;
         gxTv_SdtNotaFiscal_Notafiscalemitentecep_Z = sdt.gxTv_SdtNotaFiscal_Notafiscalemitentecep_Z ;
         gxTv_SdtNotaFiscal_Notafiscalemitentepais_Z = sdt.gxTv_SdtNotaFiscal_Notafiscalemitentepais_Z ;
         gxTv_SdtNotaFiscal_Notafiscalemitentetelefone_Z = sdt.gxTv_SdtNotaFiscal_Notafiscalemitentetelefone_Z ;
         gxTv_SdtNotaFiscal_Notafiscalemitenteie_Z = sdt.gxTv_SdtNotaFiscal_Notafiscalemitenteie_Z ;
         gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid_Z = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid_Z ;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento_Z = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento_Z ;
         gxTv_SdtNotaFiscal_Notafiscaldestinatarionome_Z = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatarionome_Z ;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro_Z = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro_Z ;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum_Z = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum_Z ;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento_Z = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento_Z ;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro_Z = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro_Z ;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio_Z = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio_Z ;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariouf_Z = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariouf_Z ;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariocep_Z = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariocep_Z ;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariopais_Z = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariopais_Z ;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariofone_Z = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariofone_Z ;
         gxTv_SdtNotaFiscal_Notafiscalid_N = sdt.gxTv_SdtNotaFiscal_Notafiscalid_N ;
         gxTv_SdtNotaFiscal_Clienteid_N = sdt.gxTv_SdtNotaFiscal_Clienteid_N ;
         gxTv_SdtNotaFiscal_Notafiscaluf_N = sdt.gxTv_SdtNotaFiscal_Notafiscaluf_N ;
         gxTv_SdtNotaFiscal_Notafiscalnatureza_N = sdt.gxTv_SdtNotaFiscal_Notafiscalnatureza_N ;
         gxTv_SdtNotaFiscal_Notafiscalmod_N = sdt.gxTv_SdtNotaFiscal_Notafiscalmod_N ;
         gxTv_SdtNotaFiscal_Notafiscalserie_N = sdt.gxTv_SdtNotaFiscal_Notafiscalserie_N ;
         gxTv_SdtNotaFiscal_Notafiscalnumero_N = sdt.gxTv_SdtNotaFiscal_Notafiscalnumero_N ;
         gxTv_SdtNotaFiscal_Notafiscaldataemissao_N = sdt.gxTv_SdtNotaFiscal_Notafiscaldataemissao_N ;
         gxTv_SdtNotaFiscal_Notafiscaldatasaida_N = sdt.gxTv_SdtNotaFiscal_Notafiscaldatasaida_N ;
         gxTv_SdtNotaFiscal_Notafiscaltipo_N = sdt.gxTv_SdtNotaFiscal_Notafiscaltipo_N ;
         gxTv_SdtNotaFiscal_Notafiscalmunicipio_N = sdt.gxTv_SdtNotaFiscal_Notafiscalmunicipio_N ;
         gxTv_SdtNotaFiscal_Notafiscaltipoemissao_N = sdt.gxTv_SdtNotaFiscal_Notafiscaltipoemissao_N ;
         gxTv_SdtNotaFiscal_Notafiscalambiente_N = sdt.gxTv_SdtNotaFiscal_Notafiscalambiente_N ;
         gxTv_SdtNotaFiscal_Notafiscalfinalidades_N = sdt.gxTv_SdtNotaFiscal_Notafiscalfinalidades_N ;
         gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento_N = sdt.gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento_N ;
         gxTv_SdtNotaFiscal_Notafiscalemitentenome_N = sdt.gxTv_SdtNotaFiscal_Notafiscalemitentenome_N ;
         gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro_N = sdt.gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro_N ;
         gxTv_SdtNotaFiscal_Notafiscalemitentelognum_N = sdt.gxTv_SdtNotaFiscal_Notafiscalemitentelognum_N ;
         gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento_N = sdt.gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento_N ;
         gxTv_SdtNotaFiscal_Notafiscalemitentebairro_N = sdt.gxTv_SdtNotaFiscal_Notafiscalemitentebairro_N ;
         gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio_N = sdt.gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio_N ;
         gxTv_SdtNotaFiscal_Notafiscalemitenteuf_N = sdt.gxTv_SdtNotaFiscal_Notafiscalemitenteuf_N ;
         gxTv_SdtNotaFiscal_Notafiscalemitentecep_N = sdt.gxTv_SdtNotaFiscal_Notafiscalemitentecep_N ;
         gxTv_SdtNotaFiscal_Notafiscalemitentepais_N = sdt.gxTv_SdtNotaFiscal_Notafiscalemitentepais_N ;
         gxTv_SdtNotaFiscal_Notafiscalemitentetelefone_N = sdt.gxTv_SdtNotaFiscal_Notafiscalemitentetelefone_N ;
         gxTv_SdtNotaFiscal_Notafiscalemitenteie_N = sdt.gxTv_SdtNotaFiscal_Notafiscalemitenteie_N ;
         gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid_N = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid_N ;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento_N = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento_N ;
         gxTv_SdtNotaFiscal_Notafiscaldestinatarionome_N = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatarionome_N ;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro_N = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro_N ;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum_N = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum_N ;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento_N = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento_N ;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro_N = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro_N ;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio_N = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio_N ;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariouf_N = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariouf_N ;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariocep_N = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariocep_N ;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariopais_N = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariopais_N ;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariofone_N = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariofone_N ;
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
         AddObjectProperty("NotaFiscalId", gxTv_SdtNotaFiscal_Notafiscalid, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalId_N", gxTv_SdtNotaFiscal_Notafiscalid_N, false, includeNonInitialized);
         AddObjectProperty("ClienteId", gxTv_SdtNotaFiscal_Clienteid, false, includeNonInitialized);
         AddObjectProperty("ClienteId_N", gxTv_SdtNotaFiscal_Clienteid_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalUF", gxTv_SdtNotaFiscal_Notafiscaluf, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalUF_N", gxTv_SdtNotaFiscal_Notafiscaluf_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalValorTotal_F", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNotaFiscal_Notafiscalvalortotal_f, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("NotaFiscalValorTotalVendido_F", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNotaFiscal_Notafiscalvalortotalvendido_f, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("NotaFiscalSaldo_F", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNotaFiscal_Notafiscalsaldo_f, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("NotaFiscalQuantidadeDeItens_F", gxTv_SdtNotaFiscal_Notafiscalquantidadedeitens_f, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalQuantidadeDeItensVendidos_F", gxTv_SdtNotaFiscal_Notafiscalquantidadedeitensvendidos_f, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalQuantidadeResumo_F", gxTv_SdtNotaFiscal_Notafiscalquantidaderesumo_f, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalValorFormatado_F", gxTv_SdtNotaFiscal_Notafiscalvalorformatado_f, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalValorVendidoFormatado_F", gxTv_SdtNotaFiscal_Notafiscalvalorvendidoformatado_f, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalSaldoFormatado_F", gxTv_SdtNotaFiscal_Notafiscalsaldoformatado_f, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalStatus", gxTv_SdtNotaFiscal_Notafiscalstatus, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalNatureza", gxTv_SdtNotaFiscal_Notafiscalnatureza, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalNatureza_N", gxTv_SdtNotaFiscal_Notafiscalnatureza_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalMod", gxTv_SdtNotaFiscal_Notafiscalmod, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalMod_N", gxTv_SdtNotaFiscal_Notafiscalmod_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalSerie", gxTv_SdtNotaFiscal_Notafiscalserie, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalSerie_N", gxTv_SdtNotaFiscal_Notafiscalserie_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalNumero", gxTv_SdtNotaFiscal_Notafiscalnumero, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalNumero_N", gxTv_SdtNotaFiscal_Notafiscalnumero_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtNotaFiscal_Notafiscaldataemissao;
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
         AddObjectProperty("NotaFiscalDataEmissao", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalDataEmissao_N", gxTv_SdtNotaFiscal_Notafiscaldataemissao_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtNotaFiscal_Notafiscaldatasaida;
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
         AddObjectProperty("NotaFiscalDataSaida", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalDataSaida_N", gxTv_SdtNotaFiscal_Notafiscaldatasaida_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalTipo", gxTv_SdtNotaFiscal_Notafiscaltipo, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalTipo_N", gxTv_SdtNotaFiscal_Notafiscaltipo_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalMunicipio", gxTv_SdtNotaFiscal_Notafiscalmunicipio, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalMunicipio_N", gxTv_SdtNotaFiscal_Notafiscalmunicipio_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalTipoEmissao", gxTv_SdtNotaFiscal_Notafiscaltipoemissao, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalTipoEmissao_N", gxTv_SdtNotaFiscal_Notafiscaltipoemissao_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalAmbiente", gxTv_SdtNotaFiscal_Notafiscalambiente, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalAmbiente_N", gxTv_SdtNotaFiscal_Notafiscalambiente_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalFinalidades", gxTv_SdtNotaFiscal_Notafiscalfinalidades, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalFinalidades_N", gxTv_SdtNotaFiscal_Notafiscalfinalidades_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscaEmitentelDocumento", gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento, false, includeNonInitialized);
         AddObjectProperty("NotaFiscaEmitentelDocumento_N", gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalEmitenteNome", gxTv_SdtNotaFiscal_Notafiscalemitentenome, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalEmitenteNome_N", gxTv_SdtNotaFiscal_Notafiscalemitentenome_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalEmitenteLogradouro", gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalEmitenteLogradouro_N", gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalEmitenteLogNum", gxTv_SdtNotaFiscal_Notafiscalemitentelognum, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalEmitenteLogNum_N", gxTv_SdtNotaFiscal_Notafiscalemitentelognum_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalEmitenteComplemento", gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalEmitenteComplemento_N", gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalEmitenteBairro", gxTv_SdtNotaFiscal_Notafiscalemitentebairro, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalEmitenteBairro_N", gxTv_SdtNotaFiscal_Notafiscalemitentebairro_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalEmitenteMunicipio", gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalEmitenteMunicipio_N", gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalEmitenteUF", gxTv_SdtNotaFiscal_Notafiscalemitenteuf, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalEmitenteUF_N", gxTv_SdtNotaFiscal_Notafiscalemitenteuf_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalEmitenteCEP", gxTv_SdtNotaFiscal_Notafiscalemitentecep, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalEmitenteCEP_N", gxTv_SdtNotaFiscal_Notafiscalemitentecep_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalEmitentePais", gxTv_SdtNotaFiscal_Notafiscalemitentepais, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalEmitentePais_N", gxTv_SdtNotaFiscal_Notafiscalemitentepais_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalEmitenteTelefone", gxTv_SdtNotaFiscal_Notafiscalemitentetelefone, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalEmitenteTelefone_N", gxTv_SdtNotaFiscal_Notafiscalemitentetelefone_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalEmitenteIE", gxTv_SdtNotaFiscal_Notafiscalemitenteie, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalEmitenteIE_N", gxTv_SdtNotaFiscal_Notafiscalemitenteie_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalDestinatarioClienteId", gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalDestinatarioClienteId_N", gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalDestinatarioDocumento", gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalDestinatarioDocumento_N", gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalDestinatarioNome", gxTv_SdtNotaFiscal_Notafiscaldestinatarionome, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalDestinatarioNome_N", gxTv_SdtNotaFiscal_Notafiscaldestinatarionome_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalDestinatarioLogradouro", gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalDestinatarioLogradouro_N", gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalDestinatarioLogNum", gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalDestinatarioLogNum_N", gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalDestinatarioComplemento", gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalDestinatarioComplemento_N", gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalDestinatarioBairro", gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalDestinatarioBairro_N", gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalDestinatarioMunicipio", gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalDestinatarioMunicipio_N", gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalDestinatarioUF", gxTv_SdtNotaFiscal_Notafiscaldestinatariouf, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalDestinatarioUF_N", gxTv_SdtNotaFiscal_Notafiscaldestinatariouf_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalDestinatarioCEP", gxTv_SdtNotaFiscal_Notafiscaldestinatariocep, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalDestinatarioCEP_N", gxTv_SdtNotaFiscal_Notafiscaldestinatariocep_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalDestinatarioPais", gxTv_SdtNotaFiscal_Notafiscaldestinatariopais, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalDestinatarioPais_N", gxTv_SdtNotaFiscal_Notafiscaldestinatariopais_N, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalDestinatarioFone", gxTv_SdtNotaFiscal_Notafiscaldestinatariofone, false, includeNonInitialized);
         AddObjectProperty("NotaFiscalDestinatarioFone_N", gxTv_SdtNotaFiscal_Notafiscaldestinatariofone_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtNotaFiscal_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtNotaFiscal_Initialized, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalId_Z", gxTv_SdtNotaFiscal_Notafiscalid_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteId_Z", gxTv_SdtNotaFiscal_Clienteid_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalUF_Z", gxTv_SdtNotaFiscal_Notafiscaluf_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalValorTotal_F_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNotaFiscal_Notafiscalvalortotal_f_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("NotaFiscalValorTotalVendido_F_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNotaFiscal_Notafiscalvalortotalvendido_f_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("NotaFiscalSaldo_F_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtNotaFiscal_Notafiscalsaldo_f_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("NotaFiscalQuantidadeDeItens_F_Z", gxTv_SdtNotaFiscal_Notafiscalquantidadedeitens_f_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalQuantidadeDeItensVendidos_F_Z", gxTv_SdtNotaFiscal_Notafiscalquantidadedeitensvendidos_f_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalQuantidadeResumo_F_Z", gxTv_SdtNotaFiscal_Notafiscalquantidaderesumo_f_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalValorFormatado_F_Z", gxTv_SdtNotaFiscal_Notafiscalvalorformatado_f_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalValorVendidoFormatado_F_Z", gxTv_SdtNotaFiscal_Notafiscalvalorvendidoformatado_f_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalSaldoFormatado_F_Z", gxTv_SdtNotaFiscal_Notafiscalsaldoformatado_f_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalStatus_Z", gxTv_SdtNotaFiscal_Notafiscalstatus_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalNatureza_Z", gxTv_SdtNotaFiscal_Notafiscalnatureza_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalMod_Z", gxTv_SdtNotaFiscal_Notafiscalmod_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalSerie_Z", gxTv_SdtNotaFiscal_Notafiscalserie_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalNumero_Z", gxTv_SdtNotaFiscal_Notafiscalnumero_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtNotaFiscal_Notafiscaldataemissao_Z;
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
            AddObjectProperty("NotaFiscalDataEmissao_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtNotaFiscal_Notafiscaldatasaida_Z;
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
            AddObjectProperty("NotaFiscalDataSaida_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalTipo_Z", gxTv_SdtNotaFiscal_Notafiscaltipo_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalMunicipio_Z", gxTv_SdtNotaFiscal_Notafiscalmunicipio_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalTipoEmissao_Z", gxTv_SdtNotaFiscal_Notafiscaltipoemissao_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalAmbiente_Z", gxTv_SdtNotaFiscal_Notafiscalambiente_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalFinalidades_Z", gxTv_SdtNotaFiscal_Notafiscalfinalidades_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscaEmitentelDocumento_Z", gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalEmitenteNome_Z", gxTv_SdtNotaFiscal_Notafiscalemitentenome_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalEmitenteLogradouro_Z", gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalEmitenteLogNum_Z", gxTv_SdtNotaFiscal_Notafiscalemitentelognum_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalEmitenteComplemento_Z", gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalEmitenteBairro_Z", gxTv_SdtNotaFiscal_Notafiscalemitentebairro_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalEmitenteMunicipio_Z", gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalEmitenteUF_Z", gxTv_SdtNotaFiscal_Notafiscalemitenteuf_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalEmitenteCEP_Z", gxTv_SdtNotaFiscal_Notafiscalemitentecep_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalEmitentePais_Z", gxTv_SdtNotaFiscal_Notafiscalemitentepais_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalEmitenteTelefone_Z", gxTv_SdtNotaFiscal_Notafiscalemitentetelefone_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalEmitenteIE_Z", gxTv_SdtNotaFiscal_Notafiscalemitenteie_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalDestinatarioClienteId_Z", gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalDestinatarioDocumento_Z", gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalDestinatarioNome_Z", gxTv_SdtNotaFiscal_Notafiscaldestinatarionome_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalDestinatarioLogradouro_Z", gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalDestinatarioLogNum_Z", gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalDestinatarioComplemento_Z", gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalDestinatarioBairro_Z", gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalDestinatarioMunicipio_Z", gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalDestinatarioUF_Z", gxTv_SdtNotaFiscal_Notafiscaldestinatariouf_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalDestinatarioCEP_Z", gxTv_SdtNotaFiscal_Notafiscaldestinatariocep_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalDestinatarioPais_Z", gxTv_SdtNotaFiscal_Notafiscaldestinatariopais_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalDestinatarioFone_Z", gxTv_SdtNotaFiscal_Notafiscaldestinatariofone_Z, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalId_N", gxTv_SdtNotaFiscal_Notafiscalid_N, false, includeNonInitialized);
            AddObjectProperty("ClienteId_N", gxTv_SdtNotaFiscal_Clienteid_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalUF_N", gxTv_SdtNotaFiscal_Notafiscaluf_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalNatureza_N", gxTv_SdtNotaFiscal_Notafiscalnatureza_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalMod_N", gxTv_SdtNotaFiscal_Notafiscalmod_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalSerie_N", gxTv_SdtNotaFiscal_Notafiscalserie_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalNumero_N", gxTv_SdtNotaFiscal_Notafiscalnumero_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalDataEmissao_N", gxTv_SdtNotaFiscal_Notafiscaldataemissao_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalDataSaida_N", gxTv_SdtNotaFiscal_Notafiscaldatasaida_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalTipo_N", gxTv_SdtNotaFiscal_Notafiscaltipo_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalMunicipio_N", gxTv_SdtNotaFiscal_Notafiscalmunicipio_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalTipoEmissao_N", gxTv_SdtNotaFiscal_Notafiscaltipoemissao_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalAmbiente_N", gxTv_SdtNotaFiscal_Notafiscalambiente_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalFinalidades_N", gxTv_SdtNotaFiscal_Notafiscalfinalidades_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscaEmitentelDocumento_N", gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalEmitenteNome_N", gxTv_SdtNotaFiscal_Notafiscalemitentenome_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalEmitenteLogradouro_N", gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalEmitenteLogNum_N", gxTv_SdtNotaFiscal_Notafiscalemitentelognum_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalEmitenteComplemento_N", gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalEmitenteBairro_N", gxTv_SdtNotaFiscal_Notafiscalemitentebairro_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalEmitenteMunicipio_N", gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalEmitenteUF_N", gxTv_SdtNotaFiscal_Notafiscalemitenteuf_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalEmitenteCEP_N", gxTv_SdtNotaFiscal_Notafiscalemitentecep_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalEmitentePais_N", gxTv_SdtNotaFiscal_Notafiscalemitentepais_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalEmitenteTelefone_N", gxTv_SdtNotaFiscal_Notafiscalemitentetelefone_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalEmitenteIE_N", gxTv_SdtNotaFiscal_Notafiscalemitenteie_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalDestinatarioClienteId_N", gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalDestinatarioDocumento_N", gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalDestinatarioNome_N", gxTv_SdtNotaFiscal_Notafiscaldestinatarionome_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalDestinatarioLogradouro_N", gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalDestinatarioLogNum_N", gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalDestinatarioComplemento_N", gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalDestinatarioBairro_N", gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalDestinatarioMunicipio_N", gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalDestinatarioUF_N", gxTv_SdtNotaFiscal_Notafiscaldestinatariouf_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalDestinatarioCEP_N", gxTv_SdtNotaFiscal_Notafiscaldestinatariocep_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalDestinatarioPais_N", gxTv_SdtNotaFiscal_Notafiscaldestinatariopais_N, false, includeNonInitialized);
            AddObjectProperty("NotaFiscalDestinatarioFone_N", gxTv_SdtNotaFiscal_Notafiscaldestinatariofone_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtNotaFiscal sdt )
      {
         if ( sdt.IsDirty("NotaFiscalId") )
         {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalid = sdt.gxTv_SdtNotaFiscal_Notafiscalid ;
         }
         if ( sdt.IsDirty("ClienteId") )
         {
            gxTv_SdtNotaFiscal_Clienteid_N = (short)(sdt.gxTv_SdtNotaFiscal_Clienteid_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Clienteid = sdt.gxTv_SdtNotaFiscal_Clienteid ;
         }
         if ( sdt.IsDirty("NotaFiscalUF") )
         {
            gxTv_SdtNotaFiscal_Notafiscaluf_N = (short)(sdt.gxTv_SdtNotaFiscal_Notafiscaluf_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaluf = sdt.gxTv_SdtNotaFiscal_Notafiscaluf ;
         }
         if ( sdt.IsDirty("NotaFiscalValorTotal_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalvalortotal_f = sdt.gxTv_SdtNotaFiscal_Notafiscalvalortotal_f ;
         }
         if ( sdt.IsDirty("NotaFiscalValorTotalVendido_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalvalortotalvendido_f = sdt.gxTv_SdtNotaFiscal_Notafiscalvalortotalvendido_f ;
         }
         if ( sdt.IsDirty("NotaFiscalSaldo_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalsaldo_f = sdt.gxTv_SdtNotaFiscal_Notafiscalsaldo_f ;
         }
         if ( sdt.IsDirty("NotaFiscalQuantidadeDeItens_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalquantidadedeitens_f = sdt.gxTv_SdtNotaFiscal_Notafiscalquantidadedeitens_f ;
         }
         if ( sdt.IsDirty("NotaFiscalQuantidadeDeItensVendidos_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalquantidadedeitensvendidos_f = sdt.gxTv_SdtNotaFiscal_Notafiscalquantidadedeitensvendidos_f ;
         }
         if ( sdt.IsDirty("NotaFiscalQuantidadeResumo_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalquantidaderesumo_f = sdt.gxTv_SdtNotaFiscal_Notafiscalquantidaderesumo_f ;
         }
         if ( sdt.IsDirty("NotaFiscalValorFormatado_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalvalorformatado_f = sdt.gxTv_SdtNotaFiscal_Notafiscalvalorformatado_f ;
         }
         if ( sdt.IsDirty("NotaFiscalValorVendidoFormatado_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalvalorvendidoformatado_f = sdt.gxTv_SdtNotaFiscal_Notafiscalvalorvendidoformatado_f ;
         }
         if ( sdt.IsDirty("NotaFiscalSaldoFormatado_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalsaldoformatado_f = sdt.gxTv_SdtNotaFiscal_Notafiscalsaldoformatado_f ;
         }
         if ( sdt.IsDirty("NotaFiscalStatus") )
         {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalstatus = sdt.gxTv_SdtNotaFiscal_Notafiscalstatus ;
         }
         if ( sdt.IsDirty("NotaFiscalNatureza") )
         {
            gxTv_SdtNotaFiscal_Notafiscalnatureza_N = (short)(sdt.gxTv_SdtNotaFiscal_Notafiscalnatureza_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalnatureza = sdt.gxTv_SdtNotaFiscal_Notafiscalnatureza ;
         }
         if ( sdt.IsDirty("NotaFiscalMod") )
         {
            gxTv_SdtNotaFiscal_Notafiscalmod_N = (short)(sdt.gxTv_SdtNotaFiscal_Notafiscalmod_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalmod = sdt.gxTv_SdtNotaFiscal_Notafiscalmod ;
         }
         if ( sdt.IsDirty("NotaFiscalSerie") )
         {
            gxTv_SdtNotaFiscal_Notafiscalserie_N = (short)(sdt.gxTv_SdtNotaFiscal_Notafiscalserie_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalserie = sdt.gxTv_SdtNotaFiscal_Notafiscalserie ;
         }
         if ( sdt.IsDirty("NotaFiscalNumero") )
         {
            gxTv_SdtNotaFiscal_Notafiscalnumero_N = (short)(sdt.gxTv_SdtNotaFiscal_Notafiscalnumero_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalnumero = sdt.gxTv_SdtNotaFiscal_Notafiscalnumero ;
         }
         if ( sdt.IsDirty("NotaFiscalDataEmissao") )
         {
            gxTv_SdtNotaFiscal_Notafiscaldataemissao_N = (short)(sdt.gxTv_SdtNotaFiscal_Notafiscaldataemissao_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldataemissao = sdt.gxTv_SdtNotaFiscal_Notafiscaldataemissao ;
         }
         if ( sdt.IsDirty("NotaFiscalDataSaida") )
         {
            gxTv_SdtNotaFiscal_Notafiscaldatasaida_N = (short)(sdt.gxTv_SdtNotaFiscal_Notafiscaldatasaida_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldatasaida = sdt.gxTv_SdtNotaFiscal_Notafiscaldatasaida ;
         }
         if ( sdt.IsDirty("NotaFiscalTipo") )
         {
            gxTv_SdtNotaFiscal_Notafiscaltipo_N = (short)(sdt.gxTv_SdtNotaFiscal_Notafiscaltipo_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaltipo = sdt.gxTv_SdtNotaFiscal_Notafiscaltipo ;
         }
         if ( sdt.IsDirty("NotaFiscalMunicipio") )
         {
            gxTv_SdtNotaFiscal_Notafiscalmunicipio_N = (short)(sdt.gxTv_SdtNotaFiscal_Notafiscalmunicipio_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalmunicipio = sdt.gxTv_SdtNotaFiscal_Notafiscalmunicipio ;
         }
         if ( sdt.IsDirty("NotaFiscalTipoEmissao") )
         {
            gxTv_SdtNotaFiscal_Notafiscaltipoemissao_N = (short)(sdt.gxTv_SdtNotaFiscal_Notafiscaltipoemissao_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaltipoemissao = sdt.gxTv_SdtNotaFiscal_Notafiscaltipoemissao ;
         }
         if ( sdt.IsDirty("NotaFiscalAmbiente") )
         {
            gxTv_SdtNotaFiscal_Notafiscalambiente_N = (short)(sdt.gxTv_SdtNotaFiscal_Notafiscalambiente_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalambiente = sdt.gxTv_SdtNotaFiscal_Notafiscalambiente ;
         }
         if ( sdt.IsDirty("NotaFiscalFinalidades") )
         {
            gxTv_SdtNotaFiscal_Notafiscalfinalidades_N = (short)(sdt.gxTv_SdtNotaFiscal_Notafiscalfinalidades_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalfinalidades = sdt.gxTv_SdtNotaFiscal_Notafiscalfinalidades ;
         }
         if ( sdt.IsDirty("NotaFiscaEmitentelDocumento") )
         {
            gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento_N = (short)(sdt.gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento = sdt.gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento ;
         }
         if ( sdt.IsDirty("NotaFiscalEmitenteNome") )
         {
            gxTv_SdtNotaFiscal_Notafiscalemitentenome_N = (short)(sdt.gxTv_SdtNotaFiscal_Notafiscalemitentenome_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitentenome = sdt.gxTv_SdtNotaFiscal_Notafiscalemitentenome ;
         }
         if ( sdt.IsDirty("NotaFiscalEmitenteLogradouro") )
         {
            gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro_N = (short)(sdt.gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro = sdt.gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro ;
         }
         if ( sdt.IsDirty("NotaFiscalEmitenteLogNum") )
         {
            gxTv_SdtNotaFiscal_Notafiscalemitentelognum_N = (short)(sdt.gxTv_SdtNotaFiscal_Notafiscalemitentelognum_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitentelognum = sdt.gxTv_SdtNotaFiscal_Notafiscalemitentelognum ;
         }
         if ( sdt.IsDirty("NotaFiscalEmitenteComplemento") )
         {
            gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento_N = (short)(sdt.gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento = sdt.gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento ;
         }
         if ( sdt.IsDirty("NotaFiscalEmitenteBairro") )
         {
            gxTv_SdtNotaFiscal_Notafiscalemitentebairro_N = (short)(sdt.gxTv_SdtNotaFiscal_Notafiscalemitentebairro_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitentebairro = sdt.gxTv_SdtNotaFiscal_Notafiscalemitentebairro ;
         }
         if ( sdt.IsDirty("NotaFiscalEmitenteMunicipio") )
         {
            gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio_N = (short)(sdt.gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio = sdt.gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio ;
         }
         if ( sdt.IsDirty("NotaFiscalEmitenteUF") )
         {
            gxTv_SdtNotaFiscal_Notafiscalemitenteuf_N = (short)(sdt.gxTv_SdtNotaFiscal_Notafiscalemitenteuf_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitenteuf = sdt.gxTv_SdtNotaFiscal_Notafiscalemitenteuf ;
         }
         if ( sdt.IsDirty("NotaFiscalEmitenteCEP") )
         {
            gxTv_SdtNotaFiscal_Notafiscalemitentecep_N = (short)(sdt.gxTv_SdtNotaFiscal_Notafiscalemitentecep_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitentecep = sdt.gxTv_SdtNotaFiscal_Notafiscalemitentecep ;
         }
         if ( sdt.IsDirty("NotaFiscalEmitentePais") )
         {
            gxTv_SdtNotaFiscal_Notafiscalemitentepais_N = (short)(sdt.gxTv_SdtNotaFiscal_Notafiscalemitentepais_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitentepais = sdt.gxTv_SdtNotaFiscal_Notafiscalemitentepais ;
         }
         if ( sdt.IsDirty("NotaFiscalEmitenteTelefone") )
         {
            gxTv_SdtNotaFiscal_Notafiscalemitentetelefone_N = (short)(sdt.gxTv_SdtNotaFiscal_Notafiscalemitentetelefone_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitentetelefone = sdt.gxTv_SdtNotaFiscal_Notafiscalemitentetelefone ;
         }
         if ( sdt.IsDirty("NotaFiscalEmitenteIE") )
         {
            gxTv_SdtNotaFiscal_Notafiscalemitenteie_N = (short)(sdt.gxTv_SdtNotaFiscal_Notafiscalemitenteie_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitenteie = sdt.gxTv_SdtNotaFiscal_Notafiscalemitenteie ;
         }
         if ( sdt.IsDirty("NotaFiscalDestinatarioClienteId") )
         {
            gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid_N = (short)(sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid ;
         }
         if ( sdt.IsDirty("NotaFiscalDestinatarioDocumento") )
         {
            gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento_N = (short)(sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento ;
         }
         if ( sdt.IsDirty("NotaFiscalDestinatarioNome") )
         {
            gxTv_SdtNotaFiscal_Notafiscaldestinatarionome_N = (short)(sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatarionome_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatarionome = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatarionome ;
         }
         if ( sdt.IsDirty("NotaFiscalDestinatarioLogradouro") )
         {
            gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro_N = (short)(sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro ;
         }
         if ( sdt.IsDirty("NotaFiscalDestinatarioLogNum") )
         {
            gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum_N = (short)(sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum ;
         }
         if ( sdt.IsDirty("NotaFiscalDestinatarioComplemento") )
         {
            gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento_N = (short)(sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento ;
         }
         if ( sdt.IsDirty("NotaFiscalDestinatarioBairro") )
         {
            gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro_N = (short)(sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro ;
         }
         if ( sdt.IsDirty("NotaFiscalDestinatarioMunicipio") )
         {
            gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio_N = (short)(sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio ;
         }
         if ( sdt.IsDirty("NotaFiscalDestinatarioUF") )
         {
            gxTv_SdtNotaFiscal_Notafiscaldestinatariouf_N = (short)(sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariouf_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariouf = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariouf ;
         }
         if ( sdt.IsDirty("NotaFiscalDestinatarioCEP") )
         {
            gxTv_SdtNotaFiscal_Notafiscaldestinatariocep_N = (short)(sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariocep_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariocep = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariocep ;
         }
         if ( sdt.IsDirty("NotaFiscalDestinatarioPais") )
         {
            gxTv_SdtNotaFiscal_Notafiscaldestinatariopais_N = (short)(sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariopais_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariopais = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariopais ;
         }
         if ( sdt.IsDirty("NotaFiscalDestinatarioFone") )
         {
            gxTv_SdtNotaFiscal_Notafiscaldestinatariofone_N = (short)(sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariofone_N);
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariofone = sdt.gxTv_SdtNotaFiscal_Notafiscaldestinatariofone ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "NotaFiscalId" )]
      [  XmlElement( ElementName = "NotaFiscalId"   )]
      public Guid gxTpr_Notafiscalid
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtNotaFiscal_Notafiscalid != value )
            {
               gxTv_SdtNotaFiscal_Mode = "INS";
               this.gxTv_SdtNotaFiscal_Notafiscalid_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Clienteid_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscaluf_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscalvalortotal_f_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscalvalortotalvendido_f_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscalsaldo_f_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscalquantidadedeitens_f_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscalquantidadedeitensvendidos_f_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscalquantidaderesumo_f_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscalvalorformatado_f_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscalvalorvendidoformatado_f_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscalsaldoformatado_f_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscalstatus_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscalnatureza_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscalmod_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscalserie_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscalnumero_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscaldataemissao_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscaldatasaida_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscaltipo_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscalmunicipio_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscaltipoemissao_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscalambiente_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscalfinalidades_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscalemitentenome_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscalemitentelognum_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscalemitentebairro_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscalemitenteuf_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscalemitentecep_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscalemitentepais_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscalemitentetelefone_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscalemitenteie_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscaldestinatarionome_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscaldestinatariouf_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscaldestinatariocep_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscaldestinatariopais_Z_SetNull( );
               this.gxTv_SdtNotaFiscal_Notafiscaldestinatariofone_Z_SetNull( );
            }
            gxTv_SdtNotaFiscal_Notafiscalid = value;
            SetDirty("Notafiscalid");
         }

      }

      [  SoapElement( ElementName = "ClienteId" )]
      [  XmlElement( ElementName = "ClienteId"   )]
      public int gxTpr_Clienteid
      {
         get {
            return gxTv_SdtNotaFiscal_Clienteid ;
         }

         set {
            gxTv_SdtNotaFiscal_Clienteid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Clienteid = value;
            SetDirty("Clienteid");
         }

      }

      public void gxTv_SdtNotaFiscal_Clienteid_SetNull( )
      {
         gxTv_SdtNotaFiscal_Clienteid_N = 1;
         gxTv_SdtNotaFiscal_Clienteid = 0;
         SetDirty("Clienteid");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Clienteid_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Clienteid_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalUF" )]
      [  XmlElement( ElementName = "NotaFiscalUF"   )]
      public short gxTpr_Notafiscaluf
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaluf ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscaluf_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaluf = value;
            SetDirty("Notafiscaluf");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaluf_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaluf_N = 1;
         gxTv_SdtNotaFiscal_Notafiscaluf = 0;
         SetDirty("Notafiscaluf");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaluf_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Notafiscaluf_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalValorTotal_F" )]
      [  XmlElement( ElementName = "NotaFiscalValorTotal_F"   )]
      public decimal gxTpr_Notafiscalvalortotal_f
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalvalortotal_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalvalortotal_f = value;
            SetDirty("Notafiscalvalortotal_f");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalvalortotal_f_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalvalortotal_f = 0;
         SetDirty("Notafiscalvalortotal_f");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalvalortotal_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalValorTotalVendido_F" )]
      [  XmlElement( ElementName = "NotaFiscalValorTotalVendido_F"   )]
      public decimal gxTpr_Notafiscalvalortotalvendido_f
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalvalortotalvendido_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalvalortotalvendido_f = value;
            SetDirty("Notafiscalvalortotalvendido_f");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalvalortotalvendido_f_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalvalortotalvendido_f = 0;
         SetDirty("Notafiscalvalortotalvendido_f");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalvalortotalvendido_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalSaldo_F" )]
      [  XmlElement( ElementName = "NotaFiscalSaldo_F"   )]
      public decimal gxTpr_Notafiscalsaldo_f
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalsaldo_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalsaldo_f = value;
            SetDirty("Notafiscalsaldo_f");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalsaldo_f_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalsaldo_f = 0;
         SetDirty("Notafiscalsaldo_f");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalsaldo_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalQuantidadeDeItens_F" )]
      [  XmlElement( ElementName = "NotaFiscalQuantidadeDeItens_F"   )]
      public short gxTpr_Notafiscalquantidadedeitens_f
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalquantidadedeitens_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalquantidadedeitens_f = value;
            SetDirty("Notafiscalquantidadedeitens_f");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalquantidadedeitens_f_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalquantidadedeitens_f = 0;
         SetDirty("Notafiscalquantidadedeitens_f");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalquantidadedeitens_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalQuantidadeDeItensVendidos_F" )]
      [  XmlElement( ElementName = "NotaFiscalQuantidadeDeItensVendidos_F"   )]
      public short gxTpr_Notafiscalquantidadedeitensvendidos_f
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalquantidadedeitensvendidos_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalquantidadedeitensvendidos_f = value;
            SetDirty("Notafiscalquantidadedeitensvendidos_f");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalquantidadedeitensvendidos_f_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalquantidadedeitensvendidos_f = 0;
         SetDirty("Notafiscalquantidadedeitensvendidos_f");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalquantidadedeitensvendidos_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalQuantidadeResumo_F" )]
      [  XmlElement( ElementName = "NotaFiscalQuantidadeResumo_F"   )]
      public string gxTpr_Notafiscalquantidaderesumo_f
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalquantidaderesumo_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalquantidaderesumo_f = value;
            SetDirty("Notafiscalquantidaderesumo_f");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalquantidaderesumo_f_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalquantidaderesumo_f = "";
         SetDirty("Notafiscalquantidaderesumo_f");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalquantidaderesumo_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalValorFormatado_F" )]
      [  XmlElement( ElementName = "NotaFiscalValorFormatado_F"   )]
      public string gxTpr_Notafiscalvalorformatado_f
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalvalorformatado_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalvalorformatado_f = value;
            SetDirty("Notafiscalvalorformatado_f");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalvalorformatado_f_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalvalorformatado_f = "";
         SetDirty("Notafiscalvalorformatado_f");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalvalorformatado_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalValorVendidoFormatado_F" )]
      [  XmlElement( ElementName = "NotaFiscalValorVendidoFormatado_F"   )]
      public string gxTpr_Notafiscalvalorvendidoformatado_f
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalvalorvendidoformatado_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalvalorvendidoformatado_f = value;
            SetDirty("Notafiscalvalorvendidoformatado_f");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalvalorvendidoformatado_f_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalvalorvendidoformatado_f = "";
         SetDirty("Notafiscalvalorvendidoformatado_f");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalvalorvendidoformatado_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalSaldoFormatado_F" )]
      [  XmlElement( ElementName = "NotaFiscalSaldoFormatado_F"   )]
      public string gxTpr_Notafiscalsaldoformatado_f
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalsaldoformatado_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalsaldoformatado_f = value;
            SetDirty("Notafiscalsaldoformatado_f");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalsaldoformatado_f_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalsaldoformatado_f = "";
         SetDirty("Notafiscalsaldoformatado_f");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalsaldoformatado_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalStatus" )]
      [  XmlElement( ElementName = "NotaFiscalStatus"   )]
      public string gxTpr_Notafiscalstatus
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalstatus ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalstatus = value;
            SetDirty("Notafiscalstatus");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalstatus_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalstatus = "";
         SetDirty("Notafiscalstatus");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalstatus_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalNatureza" )]
      [  XmlElement( ElementName = "NotaFiscalNatureza"   )]
      public string gxTpr_Notafiscalnatureza
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalnatureza ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscalnatureza_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalnatureza = value;
            SetDirty("Notafiscalnatureza");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalnatureza_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalnatureza_N = 1;
         gxTv_SdtNotaFiscal_Notafiscalnatureza = "";
         SetDirty("Notafiscalnatureza");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalnatureza_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Notafiscalnatureza_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalMod" )]
      [  XmlElement( ElementName = "NotaFiscalMod"   )]
      public string gxTpr_Notafiscalmod
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalmod ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscalmod_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalmod = value;
            SetDirty("Notafiscalmod");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalmod_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalmod_N = 1;
         gxTv_SdtNotaFiscal_Notafiscalmod = "";
         SetDirty("Notafiscalmod");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalmod_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Notafiscalmod_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalSerie" )]
      [  XmlElement( ElementName = "NotaFiscalSerie"   )]
      public string gxTpr_Notafiscalserie
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalserie ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscalserie_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalserie = value;
            SetDirty("Notafiscalserie");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalserie_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalserie_N = 1;
         gxTv_SdtNotaFiscal_Notafiscalserie = "";
         SetDirty("Notafiscalserie");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalserie_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Notafiscalserie_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalNumero" )]
      [  XmlElement( ElementName = "NotaFiscalNumero"   )]
      public string gxTpr_Notafiscalnumero
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalnumero ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscalnumero_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalnumero = value;
            SetDirty("Notafiscalnumero");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalnumero_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalnumero_N = 1;
         gxTv_SdtNotaFiscal_Notafiscalnumero = "";
         SetDirty("Notafiscalnumero");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalnumero_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Notafiscalnumero_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalDataEmissao" )]
      [  XmlElement( ElementName = "NotaFiscalDataEmissao"  , IsNullable=true )]
      public string gxTpr_Notafiscaldataemissao_Nullable
      {
         get {
            if ( gxTv_SdtNotaFiscal_Notafiscaldataemissao == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNotaFiscal_Notafiscaldataemissao).value ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscaldataemissao_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNotaFiscal_Notafiscaldataemissao = DateTime.MinValue;
            else
               gxTv_SdtNotaFiscal_Notafiscaldataemissao = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Notafiscaldataemissao
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldataemissao ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscaldataemissao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldataemissao = value;
            SetDirty("Notafiscaldataemissao");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldataemissao_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldataemissao_N = 1;
         gxTv_SdtNotaFiscal_Notafiscaldataemissao = (DateTime)(DateTime.MinValue);
         SetDirty("Notafiscaldataemissao");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldataemissao_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Notafiscaldataemissao_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalDataSaida" )]
      [  XmlElement( ElementName = "NotaFiscalDataSaida"  , IsNullable=true )]
      public string gxTpr_Notafiscaldatasaida_Nullable
      {
         get {
            if ( gxTv_SdtNotaFiscal_Notafiscaldatasaida == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNotaFiscal_Notafiscaldatasaida).value ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscaldatasaida_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNotaFiscal_Notafiscaldatasaida = DateTime.MinValue;
            else
               gxTv_SdtNotaFiscal_Notafiscaldatasaida = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Notafiscaldatasaida
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldatasaida ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscaldatasaida_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldatasaida = value;
            SetDirty("Notafiscaldatasaida");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldatasaida_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldatasaida_N = 1;
         gxTv_SdtNotaFiscal_Notafiscaldatasaida = (DateTime)(DateTime.MinValue);
         SetDirty("Notafiscaldatasaida");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldatasaida_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Notafiscaldatasaida_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalTipo" )]
      [  XmlElement( ElementName = "NotaFiscalTipo"   )]
      public string gxTpr_Notafiscaltipo
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaltipo ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscaltipo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaltipo = value;
            SetDirty("Notafiscaltipo");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaltipo_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaltipo_N = 1;
         gxTv_SdtNotaFiscal_Notafiscaltipo = "";
         SetDirty("Notafiscaltipo");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaltipo_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Notafiscaltipo_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalMunicipio" )]
      [  XmlElement( ElementName = "NotaFiscalMunicipio"   )]
      public string gxTpr_Notafiscalmunicipio
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalmunicipio ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscalmunicipio_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalmunicipio = value;
            SetDirty("Notafiscalmunicipio");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalmunicipio_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalmunicipio_N = 1;
         gxTv_SdtNotaFiscal_Notafiscalmunicipio = "";
         SetDirty("Notafiscalmunicipio");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalmunicipio_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Notafiscalmunicipio_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalTipoEmissao" )]
      [  XmlElement( ElementName = "NotaFiscalTipoEmissao"   )]
      public string gxTpr_Notafiscaltipoemissao
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaltipoemissao ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscaltipoemissao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaltipoemissao = value;
            SetDirty("Notafiscaltipoemissao");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaltipoemissao_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaltipoemissao_N = 1;
         gxTv_SdtNotaFiscal_Notafiscaltipoemissao = "";
         SetDirty("Notafiscaltipoemissao");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaltipoemissao_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Notafiscaltipoemissao_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalAmbiente" )]
      [  XmlElement( ElementName = "NotaFiscalAmbiente"   )]
      public short gxTpr_Notafiscalambiente
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalambiente ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscalambiente_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalambiente = value;
            SetDirty("Notafiscalambiente");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalambiente_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalambiente_N = 1;
         gxTv_SdtNotaFiscal_Notafiscalambiente = 0;
         SetDirty("Notafiscalambiente");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalambiente_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Notafiscalambiente_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalFinalidades" )]
      [  XmlElement( ElementName = "NotaFiscalFinalidades"   )]
      public string gxTpr_Notafiscalfinalidades
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalfinalidades ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscalfinalidades_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalfinalidades = value;
            SetDirty("Notafiscalfinalidades");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalfinalidades_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalfinalidades_N = 1;
         gxTv_SdtNotaFiscal_Notafiscalfinalidades = "";
         SetDirty("Notafiscalfinalidades");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalfinalidades_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Notafiscalfinalidades_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscaEmitentelDocumento" )]
      [  XmlElement( ElementName = "NotaFiscaEmitentelDocumento"   )]
      public string gxTpr_Notafiscaemitenteldocumento
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento = value;
            SetDirty("Notafiscaemitenteldocumento");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento_N = 1;
         gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento = "";
         SetDirty("Notafiscaemitenteldocumento");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalEmitenteNome" )]
      [  XmlElement( ElementName = "NotaFiscalEmitenteNome"   )]
      public string gxTpr_Notafiscalemitentenome
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalemitentenome ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscalemitentenome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitentenome = value;
            SetDirty("Notafiscalemitentenome");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalemitentenome_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalemitentenome_N = 1;
         gxTv_SdtNotaFiscal_Notafiscalemitentenome = "";
         SetDirty("Notafiscalemitentenome");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalemitentenome_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Notafiscalemitentenome_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalEmitenteLogradouro" )]
      [  XmlElement( ElementName = "NotaFiscalEmitenteLogradouro"   )]
      public string gxTpr_Notafiscalemitentelogradouro
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro = value;
            SetDirty("Notafiscalemitentelogradouro");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro_N = 1;
         gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro = "";
         SetDirty("Notafiscalemitentelogradouro");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalEmitenteLogNum" )]
      [  XmlElement( ElementName = "NotaFiscalEmitenteLogNum"   )]
      public string gxTpr_Notafiscalemitentelognum
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalemitentelognum ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscalemitentelognum_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitentelognum = value;
            SetDirty("Notafiscalemitentelognum");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalemitentelognum_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalemitentelognum_N = 1;
         gxTv_SdtNotaFiscal_Notafiscalemitentelognum = "";
         SetDirty("Notafiscalemitentelognum");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalemitentelognum_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Notafiscalemitentelognum_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalEmitenteComplemento" )]
      [  XmlElement( ElementName = "NotaFiscalEmitenteComplemento"   )]
      public string gxTpr_Notafiscalemitentecomplemento
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento = value;
            SetDirty("Notafiscalemitentecomplemento");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento_N = 1;
         gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento = "";
         SetDirty("Notafiscalemitentecomplemento");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalEmitenteBairro" )]
      [  XmlElement( ElementName = "NotaFiscalEmitenteBairro"   )]
      public string gxTpr_Notafiscalemitentebairro
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalemitentebairro ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscalemitentebairro_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitentebairro = value;
            SetDirty("Notafiscalemitentebairro");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalemitentebairro_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalemitentebairro_N = 1;
         gxTv_SdtNotaFiscal_Notafiscalemitentebairro = "";
         SetDirty("Notafiscalemitentebairro");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalemitentebairro_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Notafiscalemitentebairro_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalEmitenteMunicipio" )]
      [  XmlElement( ElementName = "NotaFiscalEmitenteMunicipio"   )]
      public string gxTpr_Notafiscalemitentemunicipio
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio = value;
            SetDirty("Notafiscalemitentemunicipio");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio_N = 1;
         gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio = "";
         SetDirty("Notafiscalemitentemunicipio");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalEmitenteUF" )]
      [  XmlElement( ElementName = "NotaFiscalEmitenteUF"   )]
      public string gxTpr_Notafiscalemitenteuf
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalemitenteuf ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscalemitenteuf_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitenteuf = value;
            SetDirty("Notafiscalemitenteuf");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalemitenteuf_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalemitenteuf_N = 1;
         gxTv_SdtNotaFiscal_Notafiscalemitenteuf = "";
         SetDirty("Notafiscalemitenteuf");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalemitenteuf_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Notafiscalemitenteuf_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalEmitenteCEP" )]
      [  XmlElement( ElementName = "NotaFiscalEmitenteCEP"   )]
      public string gxTpr_Notafiscalemitentecep
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalemitentecep ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscalemitentecep_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitentecep = value;
            SetDirty("Notafiscalemitentecep");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalemitentecep_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalemitentecep_N = 1;
         gxTv_SdtNotaFiscal_Notafiscalemitentecep = "";
         SetDirty("Notafiscalemitentecep");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalemitentecep_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Notafiscalemitentecep_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalEmitentePais" )]
      [  XmlElement( ElementName = "NotaFiscalEmitentePais"   )]
      public string gxTpr_Notafiscalemitentepais
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalemitentepais ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscalemitentepais_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitentepais = value;
            SetDirty("Notafiscalemitentepais");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalemitentepais_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalemitentepais_N = 1;
         gxTv_SdtNotaFiscal_Notafiscalemitentepais = "";
         SetDirty("Notafiscalemitentepais");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalemitentepais_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Notafiscalemitentepais_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalEmitenteTelefone" )]
      [  XmlElement( ElementName = "NotaFiscalEmitenteTelefone"   )]
      public string gxTpr_Notafiscalemitentetelefone
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalemitentetelefone ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscalemitentetelefone_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitentetelefone = value;
            SetDirty("Notafiscalemitentetelefone");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalemitentetelefone_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalemitentetelefone_N = 1;
         gxTv_SdtNotaFiscal_Notafiscalemitentetelefone = "";
         SetDirty("Notafiscalemitentetelefone");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalemitentetelefone_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Notafiscalemitentetelefone_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalEmitenteIE" )]
      [  XmlElement( ElementName = "NotaFiscalEmitenteIE"   )]
      public string gxTpr_Notafiscalemitenteie
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalemitenteie ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscalemitenteie_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitenteie = value;
            SetDirty("Notafiscalemitenteie");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalemitenteie_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalemitenteie_N = 1;
         gxTv_SdtNotaFiscal_Notafiscalemitenteie = "";
         SetDirty("Notafiscalemitenteie");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalemitenteie_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Notafiscalemitenteie_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalDestinatarioClienteId" )]
      [  XmlElement( ElementName = "NotaFiscalDestinatarioClienteId"   )]
      public int gxTpr_Notafiscaldestinatarioclienteid
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid = value;
            SetDirty("Notafiscaldestinatarioclienteid");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid_N = 1;
         gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid = 0;
         SetDirty("Notafiscaldestinatarioclienteid");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalDestinatarioDocumento" )]
      [  XmlElement( ElementName = "NotaFiscalDestinatarioDocumento"   )]
      public string gxTpr_Notafiscaldestinatariodocumento
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento = value;
            SetDirty("Notafiscaldestinatariodocumento");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento_N = 1;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento = "";
         SetDirty("Notafiscaldestinatariodocumento");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalDestinatarioNome" )]
      [  XmlElement( ElementName = "NotaFiscalDestinatarioNome"   )]
      public string gxTpr_Notafiscaldestinatarionome
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldestinatarionome ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscaldestinatarionome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatarionome = value;
            SetDirty("Notafiscaldestinatarionome");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldestinatarionome_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldestinatarionome_N = 1;
         gxTv_SdtNotaFiscal_Notafiscaldestinatarionome = "";
         SetDirty("Notafiscaldestinatarionome");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldestinatarionome_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Notafiscaldestinatarionome_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalDestinatarioLogradouro" )]
      [  XmlElement( ElementName = "NotaFiscalDestinatarioLogradouro"   )]
      public string gxTpr_Notafiscaldestinatariologradouro
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro = value;
            SetDirty("Notafiscaldestinatariologradouro");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro_N = 1;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro = "";
         SetDirty("Notafiscaldestinatariologradouro");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalDestinatarioLogNum" )]
      [  XmlElement( ElementName = "NotaFiscalDestinatarioLogNum"   )]
      public string gxTpr_Notafiscaldestinatariolognum
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum = value;
            SetDirty("Notafiscaldestinatariolognum");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum_N = 1;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum = "";
         SetDirty("Notafiscaldestinatariolognum");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalDestinatarioComplemento" )]
      [  XmlElement( ElementName = "NotaFiscalDestinatarioComplemento"   )]
      public string gxTpr_Notafiscaldestinatariocomplemento
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento = value;
            SetDirty("Notafiscaldestinatariocomplemento");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento_N = 1;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento = "";
         SetDirty("Notafiscaldestinatariocomplemento");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalDestinatarioBairro" )]
      [  XmlElement( ElementName = "NotaFiscalDestinatarioBairro"   )]
      public string gxTpr_Notafiscaldestinatariobairro
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro = value;
            SetDirty("Notafiscaldestinatariobairro");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro_N = 1;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro = "";
         SetDirty("Notafiscaldestinatariobairro");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalDestinatarioMunicipio" )]
      [  XmlElement( ElementName = "NotaFiscalDestinatarioMunicipio"   )]
      public string gxTpr_Notafiscaldestinatariomunicipio
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio = value;
            SetDirty("Notafiscaldestinatariomunicipio");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio_N = 1;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio = "";
         SetDirty("Notafiscaldestinatariomunicipio");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalDestinatarioUF" )]
      [  XmlElement( ElementName = "NotaFiscalDestinatarioUF"   )]
      public string gxTpr_Notafiscaldestinatariouf
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldestinatariouf ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscaldestinatariouf_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariouf = value;
            SetDirty("Notafiscaldestinatariouf");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldestinatariouf_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldestinatariouf_N = 1;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariouf = "";
         SetDirty("Notafiscaldestinatariouf");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldestinatariouf_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Notafiscaldestinatariouf_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalDestinatarioCEP" )]
      [  XmlElement( ElementName = "NotaFiscalDestinatarioCEP"   )]
      public string gxTpr_Notafiscaldestinatariocep
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldestinatariocep ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscaldestinatariocep_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariocep = value;
            SetDirty("Notafiscaldestinatariocep");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldestinatariocep_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldestinatariocep_N = 1;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariocep = "";
         SetDirty("Notafiscaldestinatariocep");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldestinatariocep_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Notafiscaldestinatariocep_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalDestinatarioPais" )]
      [  XmlElement( ElementName = "NotaFiscalDestinatarioPais"   )]
      public string gxTpr_Notafiscaldestinatariopais
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldestinatariopais ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscaldestinatariopais_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariopais = value;
            SetDirty("Notafiscaldestinatariopais");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldestinatariopais_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldestinatariopais_N = 1;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariopais = "";
         SetDirty("Notafiscaldestinatariopais");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldestinatariopais_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Notafiscaldestinatariopais_N==1) ;
      }

      [  SoapElement( ElementName = "NotaFiscalDestinatarioFone" )]
      [  XmlElement( ElementName = "NotaFiscalDestinatarioFone"   )]
      public string gxTpr_Notafiscaldestinatariofone
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldestinatariofone ;
         }

         set {
            gxTv_SdtNotaFiscal_Notafiscaldestinatariofone_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariofone = value;
            SetDirty("Notafiscaldestinatariofone");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldestinatariofone_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldestinatariofone_N = 1;
         gxTv_SdtNotaFiscal_Notafiscaldestinatariofone = "";
         SetDirty("Notafiscaldestinatariofone");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldestinatariofone_IsNull( )
      {
         return (gxTv_SdtNotaFiscal_Notafiscaldestinatariofone_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtNotaFiscal_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtNotaFiscal_Mode_SetNull( )
      {
         gxTv_SdtNotaFiscal_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtNotaFiscal_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtNotaFiscal_Initialized_SetNull( )
      {
         gxTv_SdtNotaFiscal_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalId_Z" )]
      [  XmlElement( ElementName = "NotaFiscalId_Z"   )]
      public Guid gxTpr_Notafiscalid_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalid_Z = value;
            SetDirty("Notafiscalid_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalid_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalid_Z = Guid.Empty;
         SetDirty("Notafiscalid_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteId_Z" )]
      [  XmlElement( ElementName = "ClienteId_Z"   )]
      public int gxTpr_Clienteid_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Clienteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Clienteid_Z = value;
            SetDirty("Clienteid_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Clienteid_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Clienteid_Z = 0;
         SetDirty("Clienteid_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Clienteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalUF_Z" )]
      [  XmlElement( ElementName = "NotaFiscalUF_Z"   )]
      public short gxTpr_Notafiscaluf_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaluf_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaluf_Z = value;
            SetDirty("Notafiscaluf_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaluf_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaluf_Z = 0;
         SetDirty("Notafiscaluf_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaluf_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalValorTotal_F_Z" )]
      [  XmlElement( ElementName = "NotaFiscalValorTotal_F_Z"   )]
      public decimal gxTpr_Notafiscalvalortotal_f_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalvalortotal_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalvalortotal_f_Z = value;
            SetDirty("Notafiscalvalortotal_f_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalvalortotal_f_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalvalortotal_f_Z = 0;
         SetDirty("Notafiscalvalortotal_f_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalvalortotal_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalValorTotalVendido_F_Z" )]
      [  XmlElement( ElementName = "NotaFiscalValorTotalVendido_F_Z"   )]
      public decimal gxTpr_Notafiscalvalortotalvendido_f_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalvalortotalvendido_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalvalortotalvendido_f_Z = value;
            SetDirty("Notafiscalvalortotalvendido_f_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalvalortotalvendido_f_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalvalortotalvendido_f_Z = 0;
         SetDirty("Notafiscalvalortotalvendido_f_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalvalortotalvendido_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalSaldo_F_Z" )]
      [  XmlElement( ElementName = "NotaFiscalSaldo_F_Z"   )]
      public decimal gxTpr_Notafiscalsaldo_f_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalsaldo_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalsaldo_f_Z = value;
            SetDirty("Notafiscalsaldo_f_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalsaldo_f_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalsaldo_f_Z = 0;
         SetDirty("Notafiscalsaldo_f_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalsaldo_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalQuantidadeDeItens_F_Z" )]
      [  XmlElement( ElementName = "NotaFiscalQuantidadeDeItens_F_Z"   )]
      public short gxTpr_Notafiscalquantidadedeitens_f_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalquantidadedeitens_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalquantidadedeitens_f_Z = value;
            SetDirty("Notafiscalquantidadedeitens_f_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalquantidadedeitens_f_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalquantidadedeitens_f_Z = 0;
         SetDirty("Notafiscalquantidadedeitens_f_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalquantidadedeitens_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalQuantidadeDeItensVendidos_F_Z" )]
      [  XmlElement( ElementName = "NotaFiscalQuantidadeDeItensVendidos_F_Z"   )]
      public short gxTpr_Notafiscalquantidadedeitensvendidos_f_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalquantidadedeitensvendidos_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalquantidadedeitensvendidos_f_Z = value;
            SetDirty("Notafiscalquantidadedeitensvendidos_f_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalquantidadedeitensvendidos_f_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalquantidadedeitensvendidos_f_Z = 0;
         SetDirty("Notafiscalquantidadedeitensvendidos_f_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalquantidadedeitensvendidos_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalQuantidadeResumo_F_Z" )]
      [  XmlElement( ElementName = "NotaFiscalQuantidadeResumo_F_Z"   )]
      public string gxTpr_Notafiscalquantidaderesumo_f_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalquantidaderesumo_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalquantidaderesumo_f_Z = value;
            SetDirty("Notafiscalquantidaderesumo_f_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalquantidaderesumo_f_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalquantidaderesumo_f_Z = "";
         SetDirty("Notafiscalquantidaderesumo_f_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalquantidaderesumo_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalValorFormatado_F_Z" )]
      [  XmlElement( ElementName = "NotaFiscalValorFormatado_F_Z"   )]
      public string gxTpr_Notafiscalvalorformatado_f_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalvalorformatado_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalvalorformatado_f_Z = value;
            SetDirty("Notafiscalvalorformatado_f_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalvalorformatado_f_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalvalorformatado_f_Z = "";
         SetDirty("Notafiscalvalorformatado_f_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalvalorformatado_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalValorVendidoFormatado_F_Z" )]
      [  XmlElement( ElementName = "NotaFiscalValorVendidoFormatado_F_Z"   )]
      public string gxTpr_Notafiscalvalorvendidoformatado_f_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalvalorvendidoformatado_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalvalorvendidoformatado_f_Z = value;
            SetDirty("Notafiscalvalorvendidoformatado_f_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalvalorvendidoformatado_f_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalvalorvendidoformatado_f_Z = "";
         SetDirty("Notafiscalvalorvendidoformatado_f_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalvalorvendidoformatado_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalSaldoFormatado_F_Z" )]
      [  XmlElement( ElementName = "NotaFiscalSaldoFormatado_F_Z"   )]
      public string gxTpr_Notafiscalsaldoformatado_f_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalsaldoformatado_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalsaldoformatado_f_Z = value;
            SetDirty("Notafiscalsaldoformatado_f_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalsaldoformatado_f_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalsaldoformatado_f_Z = "";
         SetDirty("Notafiscalsaldoformatado_f_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalsaldoformatado_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalStatus_Z" )]
      [  XmlElement( ElementName = "NotaFiscalStatus_Z"   )]
      public string gxTpr_Notafiscalstatus_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalstatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalstatus_Z = value;
            SetDirty("Notafiscalstatus_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalstatus_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalstatus_Z = "";
         SetDirty("Notafiscalstatus_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalstatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalNatureza_Z" )]
      [  XmlElement( ElementName = "NotaFiscalNatureza_Z"   )]
      public string gxTpr_Notafiscalnatureza_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalnatureza_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalnatureza_Z = value;
            SetDirty("Notafiscalnatureza_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalnatureza_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalnatureza_Z = "";
         SetDirty("Notafiscalnatureza_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalnatureza_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalMod_Z" )]
      [  XmlElement( ElementName = "NotaFiscalMod_Z"   )]
      public string gxTpr_Notafiscalmod_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalmod_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalmod_Z = value;
            SetDirty("Notafiscalmod_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalmod_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalmod_Z = "";
         SetDirty("Notafiscalmod_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalmod_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalSerie_Z" )]
      [  XmlElement( ElementName = "NotaFiscalSerie_Z"   )]
      public string gxTpr_Notafiscalserie_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalserie_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalserie_Z = value;
            SetDirty("Notafiscalserie_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalserie_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalserie_Z = "";
         SetDirty("Notafiscalserie_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalserie_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalNumero_Z" )]
      [  XmlElement( ElementName = "NotaFiscalNumero_Z"   )]
      public string gxTpr_Notafiscalnumero_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalnumero_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalnumero_Z = value;
            SetDirty("Notafiscalnumero_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalnumero_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalnumero_Z = "";
         SetDirty("Notafiscalnumero_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalnumero_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalDataEmissao_Z" )]
      [  XmlElement( ElementName = "NotaFiscalDataEmissao_Z"  , IsNullable=true )]
      public string gxTpr_Notafiscaldataemissao_Z_Nullable
      {
         get {
            if ( gxTv_SdtNotaFiscal_Notafiscaldataemissao_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNotaFiscal_Notafiscaldataemissao_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNotaFiscal_Notafiscaldataemissao_Z = DateTime.MinValue;
            else
               gxTv_SdtNotaFiscal_Notafiscaldataemissao_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Notafiscaldataemissao_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldataemissao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldataemissao_Z = value;
            SetDirty("Notafiscaldataemissao_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldataemissao_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldataemissao_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Notafiscaldataemissao_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldataemissao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalDataSaida_Z" )]
      [  XmlElement( ElementName = "NotaFiscalDataSaida_Z"  , IsNullable=true )]
      public string gxTpr_Notafiscaldatasaida_Z_Nullable
      {
         get {
            if ( gxTv_SdtNotaFiscal_Notafiscaldatasaida_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNotaFiscal_Notafiscaldatasaida_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNotaFiscal_Notafiscaldatasaida_Z = DateTime.MinValue;
            else
               gxTv_SdtNotaFiscal_Notafiscaldatasaida_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Notafiscaldatasaida_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldatasaida_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldatasaida_Z = value;
            SetDirty("Notafiscaldatasaida_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldatasaida_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldatasaida_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Notafiscaldatasaida_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldatasaida_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalTipo_Z" )]
      [  XmlElement( ElementName = "NotaFiscalTipo_Z"   )]
      public string gxTpr_Notafiscaltipo_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaltipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaltipo_Z = value;
            SetDirty("Notafiscaltipo_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaltipo_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaltipo_Z = "";
         SetDirty("Notafiscaltipo_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaltipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalMunicipio_Z" )]
      [  XmlElement( ElementName = "NotaFiscalMunicipio_Z"   )]
      public string gxTpr_Notafiscalmunicipio_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalmunicipio_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalmunicipio_Z = value;
            SetDirty("Notafiscalmunicipio_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalmunicipio_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalmunicipio_Z = "";
         SetDirty("Notafiscalmunicipio_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalmunicipio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalTipoEmissao_Z" )]
      [  XmlElement( ElementName = "NotaFiscalTipoEmissao_Z"   )]
      public string gxTpr_Notafiscaltipoemissao_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaltipoemissao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaltipoemissao_Z = value;
            SetDirty("Notafiscaltipoemissao_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaltipoemissao_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaltipoemissao_Z = "";
         SetDirty("Notafiscaltipoemissao_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaltipoemissao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalAmbiente_Z" )]
      [  XmlElement( ElementName = "NotaFiscalAmbiente_Z"   )]
      public short gxTpr_Notafiscalambiente_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalambiente_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalambiente_Z = value;
            SetDirty("Notafiscalambiente_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalambiente_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalambiente_Z = 0;
         SetDirty("Notafiscalambiente_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalambiente_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalFinalidades_Z" )]
      [  XmlElement( ElementName = "NotaFiscalFinalidades_Z"   )]
      public string gxTpr_Notafiscalfinalidades_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalfinalidades_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalfinalidades_Z = value;
            SetDirty("Notafiscalfinalidades_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalfinalidades_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalfinalidades_Z = "";
         SetDirty("Notafiscalfinalidades_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalfinalidades_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscaEmitentelDocumento_Z" )]
      [  XmlElement( ElementName = "NotaFiscaEmitentelDocumento_Z"   )]
      public string gxTpr_Notafiscaemitenteldocumento_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento_Z = value;
            SetDirty("Notafiscaemitenteldocumento_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento_Z = "";
         SetDirty("Notafiscaemitenteldocumento_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalEmitenteNome_Z" )]
      [  XmlElement( ElementName = "NotaFiscalEmitenteNome_Z"   )]
      public string gxTpr_Notafiscalemitentenome_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalemitentenome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitentenome_Z = value;
            SetDirty("Notafiscalemitentenome_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalemitentenome_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalemitentenome_Z = "";
         SetDirty("Notafiscalemitentenome_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalemitentenome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalEmitenteLogradouro_Z" )]
      [  XmlElement( ElementName = "NotaFiscalEmitenteLogradouro_Z"   )]
      public string gxTpr_Notafiscalemitentelogradouro_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro_Z = value;
            SetDirty("Notafiscalemitentelogradouro_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro_Z = "";
         SetDirty("Notafiscalemitentelogradouro_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalEmitenteLogNum_Z" )]
      [  XmlElement( ElementName = "NotaFiscalEmitenteLogNum_Z"   )]
      public string gxTpr_Notafiscalemitentelognum_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalemitentelognum_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitentelognum_Z = value;
            SetDirty("Notafiscalemitentelognum_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalemitentelognum_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalemitentelognum_Z = "";
         SetDirty("Notafiscalemitentelognum_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalemitentelognum_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalEmitenteComplemento_Z" )]
      [  XmlElement( ElementName = "NotaFiscalEmitenteComplemento_Z"   )]
      public string gxTpr_Notafiscalemitentecomplemento_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento_Z = value;
            SetDirty("Notafiscalemitentecomplemento_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento_Z = "";
         SetDirty("Notafiscalemitentecomplemento_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalEmitenteBairro_Z" )]
      [  XmlElement( ElementName = "NotaFiscalEmitenteBairro_Z"   )]
      public string gxTpr_Notafiscalemitentebairro_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalemitentebairro_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitentebairro_Z = value;
            SetDirty("Notafiscalemitentebairro_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalemitentebairro_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalemitentebairro_Z = "";
         SetDirty("Notafiscalemitentebairro_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalemitentebairro_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalEmitenteMunicipio_Z" )]
      [  XmlElement( ElementName = "NotaFiscalEmitenteMunicipio_Z"   )]
      public string gxTpr_Notafiscalemitentemunicipio_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio_Z = value;
            SetDirty("Notafiscalemitentemunicipio_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio_Z = "";
         SetDirty("Notafiscalemitentemunicipio_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalEmitenteUF_Z" )]
      [  XmlElement( ElementName = "NotaFiscalEmitenteUF_Z"   )]
      public string gxTpr_Notafiscalemitenteuf_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalemitenteuf_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitenteuf_Z = value;
            SetDirty("Notafiscalemitenteuf_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalemitenteuf_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalemitenteuf_Z = "";
         SetDirty("Notafiscalemitenteuf_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalemitenteuf_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalEmitenteCEP_Z" )]
      [  XmlElement( ElementName = "NotaFiscalEmitenteCEP_Z"   )]
      public string gxTpr_Notafiscalemitentecep_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalemitentecep_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitentecep_Z = value;
            SetDirty("Notafiscalemitentecep_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalemitentecep_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalemitentecep_Z = "";
         SetDirty("Notafiscalemitentecep_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalemitentecep_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalEmitentePais_Z" )]
      [  XmlElement( ElementName = "NotaFiscalEmitentePais_Z"   )]
      public string gxTpr_Notafiscalemitentepais_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalemitentepais_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitentepais_Z = value;
            SetDirty("Notafiscalemitentepais_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalemitentepais_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalemitentepais_Z = "";
         SetDirty("Notafiscalemitentepais_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalemitentepais_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalEmitenteTelefone_Z" )]
      [  XmlElement( ElementName = "NotaFiscalEmitenteTelefone_Z"   )]
      public string gxTpr_Notafiscalemitentetelefone_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalemitentetelefone_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitentetelefone_Z = value;
            SetDirty("Notafiscalemitentetelefone_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalemitentetelefone_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalemitentetelefone_Z = "";
         SetDirty("Notafiscalemitentetelefone_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalemitentetelefone_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalEmitenteIE_Z" )]
      [  XmlElement( ElementName = "NotaFiscalEmitenteIE_Z"   )]
      public string gxTpr_Notafiscalemitenteie_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalemitenteie_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitenteie_Z = value;
            SetDirty("Notafiscalemitenteie_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalemitenteie_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalemitenteie_Z = "";
         SetDirty("Notafiscalemitenteie_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalemitenteie_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalDestinatarioClienteId_Z" )]
      [  XmlElement( ElementName = "NotaFiscalDestinatarioClienteId_Z"   )]
      public int gxTpr_Notafiscaldestinatarioclienteid_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid_Z = value;
            SetDirty("Notafiscaldestinatarioclienteid_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid_Z = 0;
         SetDirty("Notafiscaldestinatarioclienteid_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalDestinatarioDocumento_Z" )]
      [  XmlElement( ElementName = "NotaFiscalDestinatarioDocumento_Z"   )]
      public string gxTpr_Notafiscaldestinatariodocumento_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento_Z = value;
            SetDirty("Notafiscaldestinatariodocumento_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento_Z = "";
         SetDirty("Notafiscaldestinatariodocumento_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalDestinatarioNome_Z" )]
      [  XmlElement( ElementName = "NotaFiscalDestinatarioNome_Z"   )]
      public string gxTpr_Notafiscaldestinatarionome_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldestinatarionome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatarionome_Z = value;
            SetDirty("Notafiscaldestinatarionome_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldestinatarionome_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldestinatarionome_Z = "";
         SetDirty("Notafiscaldestinatarionome_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldestinatarionome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalDestinatarioLogradouro_Z" )]
      [  XmlElement( ElementName = "NotaFiscalDestinatarioLogradouro_Z"   )]
      public string gxTpr_Notafiscaldestinatariologradouro_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro_Z = value;
            SetDirty("Notafiscaldestinatariologradouro_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro_Z = "";
         SetDirty("Notafiscaldestinatariologradouro_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalDestinatarioLogNum_Z" )]
      [  XmlElement( ElementName = "NotaFiscalDestinatarioLogNum_Z"   )]
      public string gxTpr_Notafiscaldestinatariolognum_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum_Z = value;
            SetDirty("Notafiscaldestinatariolognum_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum_Z = "";
         SetDirty("Notafiscaldestinatariolognum_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalDestinatarioComplemento_Z" )]
      [  XmlElement( ElementName = "NotaFiscalDestinatarioComplemento_Z"   )]
      public string gxTpr_Notafiscaldestinatariocomplemento_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento_Z = value;
            SetDirty("Notafiscaldestinatariocomplemento_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento_Z = "";
         SetDirty("Notafiscaldestinatariocomplemento_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalDestinatarioBairro_Z" )]
      [  XmlElement( ElementName = "NotaFiscalDestinatarioBairro_Z"   )]
      public string gxTpr_Notafiscaldestinatariobairro_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro_Z = value;
            SetDirty("Notafiscaldestinatariobairro_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro_Z = "";
         SetDirty("Notafiscaldestinatariobairro_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalDestinatarioMunicipio_Z" )]
      [  XmlElement( ElementName = "NotaFiscalDestinatarioMunicipio_Z"   )]
      public string gxTpr_Notafiscaldestinatariomunicipio_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio_Z = value;
            SetDirty("Notafiscaldestinatariomunicipio_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio_Z = "";
         SetDirty("Notafiscaldestinatariomunicipio_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalDestinatarioUF_Z" )]
      [  XmlElement( ElementName = "NotaFiscalDestinatarioUF_Z"   )]
      public string gxTpr_Notafiscaldestinatariouf_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldestinatariouf_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariouf_Z = value;
            SetDirty("Notafiscaldestinatariouf_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldestinatariouf_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldestinatariouf_Z = "";
         SetDirty("Notafiscaldestinatariouf_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldestinatariouf_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalDestinatarioCEP_Z" )]
      [  XmlElement( ElementName = "NotaFiscalDestinatarioCEP_Z"   )]
      public string gxTpr_Notafiscaldestinatariocep_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldestinatariocep_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariocep_Z = value;
            SetDirty("Notafiscaldestinatariocep_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldestinatariocep_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldestinatariocep_Z = "";
         SetDirty("Notafiscaldestinatariocep_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldestinatariocep_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalDestinatarioPais_Z" )]
      [  XmlElement( ElementName = "NotaFiscalDestinatarioPais_Z"   )]
      public string gxTpr_Notafiscaldestinatariopais_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldestinatariopais_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariopais_Z = value;
            SetDirty("Notafiscaldestinatariopais_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldestinatariopais_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldestinatariopais_Z = "";
         SetDirty("Notafiscaldestinatariopais_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldestinatariopais_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalDestinatarioFone_Z" )]
      [  XmlElement( ElementName = "NotaFiscalDestinatarioFone_Z"   )]
      public string gxTpr_Notafiscaldestinatariofone_Z
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldestinatariofone_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariofone_Z = value;
            SetDirty("Notafiscaldestinatariofone_Z");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldestinatariofone_Z_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldestinatariofone_Z = "";
         SetDirty("Notafiscaldestinatariofone_Z");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldestinatariofone_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalId_N" )]
      [  XmlElement( ElementName = "NotaFiscalId_N"   )]
      public short gxTpr_Notafiscalid_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalid_N = value;
            SetDirty("Notafiscalid_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalid_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalid_N = 0;
         SetDirty("Notafiscalid_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteId_N" )]
      [  XmlElement( ElementName = "ClienteId_N"   )]
      public short gxTpr_Clienteid_N
      {
         get {
            return gxTv_SdtNotaFiscal_Clienteid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Clienteid_N = value;
            SetDirty("Clienteid_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Clienteid_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Clienteid_N = 0;
         SetDirty("Clienteid_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Clienteid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalUF_N" )]
      [  XmlElement( ElementName = "NotaFiscalUF_N"   )]
      public short gxTpr_Notafiscaluf_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaluf_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaluf_N = value;
            SetDirty("Notafiscaluf_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaluf_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaluf_N = 0;
         SetDirty("Notafiscaluf_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaluf_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalNatureza_N" )]
      [  XmlElement( ElementName = "NotaFiscalNatureza_N"   )]
      public short gxTpr_Notafiscalnatureza_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalnatureza_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalnatureza_N = value;
            SetDirty("Notafiscalnatureza_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalnatureza_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalnatureza_N = 0;
         SetDirty("Notafiscalnatureza_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalnatureza_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalMod_N" )]
      [  XmlElement( ElementName = "NotaFiscalMod_N"   )]
      public short gxTpr_Notafiscalmod_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalmod_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalmod_N = value;
            SetDirty("Notafiscalmod_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalmod_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalmod_N = 0;
         SetDirty("Notafiscalmod_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalmod_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalSerie_N" )]
      [  XmlElement( ElementName = "NotaFiscalSerie_N"   )]
      public short gxTpr_Notafiscalserie_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalserie_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalserie_N = value;
            SetDirty("Notafiscalserie_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalserie_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalserie_N = 0;
         SetDirty("Notafiscalserie_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalserie_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalNumero_N" )]
      [  XmlElement( ElementName = "NotaFiscalNumero_N"   )]
      public short gxTpr_Notafiscalnumero_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalnumero_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalnumero_N = value;
            SetDirty("Notafiscalnumero_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalnumero_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalnumero_N = 0;
         SetDirty("Notafiscalnumero_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalnumero_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalDataEmissao_N" )]
      [  XmlElement( ElementName = "NotaFiscalDataEmissao_N"   )]
      public short gxTpr_Notafiscaldataemissao_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldataemissao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldataemissao_N = value;
            SetDirty("Notafiscaldataemissao_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldataemissao_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldataemissao_N = 0;
         SetDirty("Notafiscaldataemissao_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldataemissao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalDataSaida_N" )]
      [  XmlElement( ElementName = "NotaFiscalDataSaida_N"   )]
      public short gxTpr_Notafiscaldatasaida_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldatasaida_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldatasaida_N = value;
            SetDirty("Notafiscaldatasaida_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldatasaida_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldatasaida_N = 0;
         SetDirty("Notafiscaldatasaida_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldatasaida_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalTipo_N" )]
      [  XmlElement( ElementName = "NotaFiscalTipo_N"   )]
      public short gxTpr_Notafiscaltipo_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaltipo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaltipo_N = value;
            SetDirty("Notafiscaltipo_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaltipo_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaltipo_N = 0;
         SetDirty("Notafiscaltipo_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaltipo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalMunicipio_N" )]
      [  XmlElement( ElementName = "NotaFiscalMunicipio_N"   )]
      public short gxTpr_Notafiscalmunicipio_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalmunicipio_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalmunicipio_N = value;
            SetDirty("Notafiscalmunicipio_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalmunicipio_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalmunicipio_N = 0;
         SetDirty("Notafiscalmunicipio_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalmunicipio_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalTipoEmissao_N" )]
      [  XmlElement( ElementName = "NotaFiscalTipoEmissao_N"   )]
      public short gxTpr_Notafiscaltipoemissao_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaltipoemissao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaltipoemissao_N = value;
            SetDirty("Notafiscaltipoemissao_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaltipoemissao_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaltipoemissao_N = 0;
         SetDirty("Notafiscaltipoemissao_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaltipoemissao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalAmbiente_N" )]
      [  XmlElement( ElementName = "NotaFiscalAmbiente_N"   )]
      public short gxTpr_Notafiscalambiente_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalambiente_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalambiente_N = value;
            SetDirty("Notafiscalambiente_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalambiente_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalambiente_N = 0;
         SetDirty("Notafiscalambiente_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalambiente_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalFinalidades_N" )]
      [  XmlElement( ElementName = "NotaFiscalFinalidades_N"   )]
      public short gxTpr_Notafiscalfinalidades_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalfinalidades_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalfinalidades_N = value;
            SetDirty("Notafiscalfinalidades_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalfinalidades_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalfinalidades_N = 0;
         SetDirty("Notafiscalfinalidades_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalfinalidades_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscaEmitentelDocumento_N" )]
      [  XmlElement( ElementName = "NotaFiscaEmitentelDocumento_N"   )]
      public short gxTpr_Notafiscaemitenteldocumento_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento_N = value;
            SetDirty("Notafiscaemitenteldocumento_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento_N = 0;
         SetDirty("Notafiscaemitenteldocumento_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalEmitenteNome_N" )]
      [  XmlElement( ElementName = "NotaFiscalEmitenteNome_N"   )]
      public short gxTpr_Notafiscalemitentenome_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalemitentenome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitentenome_N = value;
            SetDirty("Notafiscalemitentenome_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalemitentenome_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalemitentenome_N = 0;
         SetDirty("Notafiscalemitentenome_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalemitentenome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalEmitenteLogradouro_N" )]
      [  XmlElement( ElementName = "NotaFiscalEmitenteLogradouro_N"   )]
      public short gxTpr_Notafiscalemitentelogradouro_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro_N = value;
            SetDirty("Notafiscalemitentelogradouro_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro_N = 0;
         SetDirty("Notafiscalemitentelogradouro_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalEmitenteLogNum_N" )]
      [  XmlElement( ElementName = "NotaFiscalEmitenteLogNum_N"   )]
      public short gxTpr_Notafiscalemitentelognum_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalemitentelognum_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitentelognum_N = value;
            SetDirty("Notafiscalemitentelognum_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalemitentelognum_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalemitentelognum_N = 0;
         SetDirty("Notafiscalemitentelognum_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalemitentelognum_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalEmitenteComplemento_N" )]
      [  XmlElement( ElementName = "NotaFiscalEmitenteComplemento_N"   )]
      public short gxTpr_Notafiscalemitentecomplemento_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento_N = value;
            SetDirty("Notafiscalemitentecomplemento_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento_N = 0;
         SetDirty("Notafiscalemitentecomplemento_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalEmitenteBairro_N" )]
      [  XmlElement( ElementName = "NotaFiscalEmitenteBairro_N"   )]
      public short gxTpr_Notafiscalemitentebairro_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalemitentebairro_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitentebairro_N = value;
            SetDirty("Notafiscalemitentebairro_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalemitentebairro_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalemitentebairro_N = 0;
         SetDirty("Notafiscalemitentebairro_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalemitentebairro_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalEmitenteMunicipio_N" )]
      [  XmlElement( ElementName = "NotaFiscalEmitenteMunicipio_N"   )]
      public short gxTpr_Notafiscalemitentemunicipio_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio_N = value;
            SetDirty("Notafiscalemitentemunicipio_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio_N = 0;
         SetDirty("Notafiscalemitentemunicipio_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalEmitenteUF_N" )]
      [  XmlElement( ElementName = "NotaFiscalEmitenteUF_N"   )]
      public short gxTpr_Notafiscalemitenteuf_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalemitenteuf_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitenteuf_N = value;
            SetDirty("Notafiscalemitenteuf_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalemitenteuf_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalemitenteuf_N = 0;
         SetDirty("Notafiscalemitenteuf_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalemitenteuf_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalEmitenteCEP_N" )]
      [  XmlElement( ElementName = "NotaFiscalEmitenteCEP_N"   )]
      public short gxTpr_Notafiscalemitentecep_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalemitentecep_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitentecep_N = value;
            SetDirty("Notafiscalemitentecep_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalemitentecep_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalemitentecep_N = 0;
         SetDirty("Notafiscalemitentecep_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalemitentecep_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalEmitentePais_N" )]
      [  XmlElement( ElementName = "NotaFiscalEmitentePais_N"   )]
      public short gxTpr_Notafiscalemitentepais_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalemitentepais_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitentepais_N = value;
            SetDirty("Notafiscalemitentepais_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalemitentepais_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalemitentepais_N = 0;
         SetDirty("Notafiscalemitentepais_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalemitentepais_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalEmitenteTelefone_N" )]
      [  XmlElement( ElementName = "NotaFiscalEmitenteTelefone_N"   )]
      public short gxTpr_Notafiscalemitentetelefone_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalemitentetelefone_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitentetelefone_N = value;
            SetDirty("Notafiscalemitentetelefone_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalemitentetelefone_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalemitentetelefone_N = 0;
         SetDirty("Notafiscalemitentetelefone_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalemitentetelefone_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalEmitenteIE_N" )]
      [  XmlElement( ElementName = "NotaFiscalEmitenteIE_N"   )]
      public short gxTpr_Notafiscalemitenteie_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscalemitenteie_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscalemitenteie_N = value;
            SetDirty("Notafiscalemitenteie_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscalemitenteie_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscalemitenteie_N = 0;
         SetDirty("Notafiscalemitenteie_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscalemitenteie_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalDestinatarioClienteId_N" )]
      [  XmlElement( ElementName = "NotaFiscalDestinatarioClienteId_N"   )]
      public short gxTpr_Notafiscaldestinatarioclienteid_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid_N = value;
            SetDirty("Notafiscaldestinatarioclienteid_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid_N = 0;
         SetDirty("Notafiscaldestinatarioclienteid_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalDestinatarioDocumento_N" )]
      [  XmlElement( ElementName = "NotaFiscalDestinatarioDocumento_N"   )]
      public short gxTpr_Notafiscaldestinatariodocumento_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento_N = value;
            SetDirty("Notafiscaldestinatariodocumento_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento_N = 0;
         SetDirty("Notafiscaldestinatariodocumento_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalDestinatarioNome_N" )]
      [  XmlElement( ElementName = "NotaFiscalDestinatarioNome_N"   )]
      public short gxTpr_Notafiscaldestinatarionome_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldestinatarionome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatarionome_N = value;
            SetDirty("Notafiscaldestinatarionome_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldestinatarionome_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldestinatarionome_N = 0;
         SetDirty("Notafiscaldestinatarionome_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldestinatarionome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalDestinatarioLogradouro_N" )]
      [  XmlElement( ElementName = "NotaFiscalDestinatarioLogradouro_N"   )]
      public short gxTpr_Notafiscaldestinatariologradouro_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro_N = value;
            SetDirty("Notafiscaldestinatariologradouro_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro_N = 0;
         SetDirty("Notafiscaldestinatariologradouro_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalDestinatarioLogNum_N" )]
      [  XmlElement( ElementName = "NotaFiscalDestinatarioLogNum_N"   )]
      public short gxTpr_Notafiscaldestinatariolognum_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum_N = value;
            SetDirty("Notafiscaldestinatariolognum_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum_N = 0;
         SetDirty("Notafiscaldestinatariolognum_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalDestinatarioComplemento_N" )]
      [  XmlElement( ElementName = "NotaFiscalDestinatarioComplemento_N"   )]
      public short gxTpr_Notafiscaldestinatariocomplemento_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento_N = value;
            SetDirty("Notafiscaldestinatariocomplemento_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento_N = 0;
         SetDirty("Notafiscaldestinatariocomplemento_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalDestinatarioBairro_N" )]
      [  XmlElement( ElementName = "NotaFiscalDestinatarioBairro_N"   )]
      public short gxTpr_Notafiscaldestinatariobairro_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro_N = value;
            SetDirty("Notafiscaldestinatariobairro_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro_N = 0;
         SetDirty("Notafiscaldestinatariobairro_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalDestinatarioMunicipio_N" )]
      [  XmlElement( ElementName = "NotaFiscalDestinatarioMunicipio_N"   )]
      public short gxTpr_Notafiscaldestinatariomunicipio_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio_N = value;
            SetDirty("Notafiscaldestinatariomunicipio_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio_N = 0;
         SetDirty("Notafiscaldestinatariomunicipio_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalDestinatarioUF_N" )]
      [  XmlElement( ElementName = "NotaFiscalDestinatarioUF_N"   )]
      public short gxTpr_Notafiscaldestinatariouf_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldestinatariouf_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariouf_N = value;
            SetDirty("Notafiscaldestinatariouf_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldestinatariouf_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldestinatariouf_N = 0;
         SetDirty("Notafiscaldestinatariouf_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldestinatariouf_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalDestinatarioCEP_N" )]
      [  XmlElement( ElementName = "NotaFiscalDestinatarioCEP_N"   )]
      public short gxTpr_Notafiscaldestinatariocep_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldestinatariocep_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariocep_N = value;
            SetDirty("Notafiscaldestinatariocep_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldestinatariocep_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldestinatariocep_N = 0;
         SetDirty("Notafiscaldestinatariocep_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldestinatariocep_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalDestinatarioPais_N" )]
      [  XmlElement( ElementName = "NotaFiscalDestinatarioPais_N"   )]
      public short gxTpr_Notafiscaldestinatariopais_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldestinatariopais_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariopais_N = value;
            SetDirty("Notafiscaldestinatariopais_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldestinatariopais_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldestinatariopais_N = 0;
         SetDirty("Notafiscaldestinatariopais_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldestinatariopais_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotaFiscalDestinatarioFone_N" )]
      [  XmlElement( ElementName = "NotaFiscalDestinatarioFone_N"   )]
      public short gxTpr_Notafiscaldestinatariofone_N
      {
         get {
            return gxTv_SdtNotaFiscal_Notafiscaldestinatariofone_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNotaFiscal_Notafiscaldestinatariofone_N = value;
            SetDirty("Notafiscaldestinatariofone_N");
         }

      }

      public void gxTv_SdtNotaFiscal_Notafiscaldestinatariofone_N_SetNull( )
      {
         gxTv_SdtNotaFiscal_Notafiscaldestinatariofone_N = 0;
         SetDirty("Notafiscaldestinatariofone_N");
         return  ;
      }

      public bool gxTv_SdtNotaFiscal_Notafiscaldestinatariofone_N_IsNull( )
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
         gxTv_SdtNotaFiscal_Notafiscalid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtNotaFiscal_Notafiscalquantidaderesumo_f = "";
         gxTv_SdtNotaFiscal_Notafiscalvalorformatado_f = "";
         gxTv_SdtNotaFiscal_Notafiscalvalorvendidoformatado_f = "";
         gxTv_SdtNotaFiscal_Notafiscalsaldoformatado_f = "";
         gxTv_SdtNotaFiscal_Notafiscalstatus = "";
         gxTv_SdtNotaFiscal_Notafiscalnatureza = "";
         gxTv_SdtNotaFiscal_Notafiscalmod = "";
         gxTv_SdtNotaFiscal_Notafiscalserie = "";
         gxTv_SdtNotaFiscal_Notafiscalnumero = "";
         gxTv_SdtNotaFiscal_Notafiscaldataemissao = (DateTime)(DateTime.MinValue);
         gxTv_SdtNotaFiscal_Notafiscaldatasaida = (DateTime)(DateTime.MinValue);
         gxTv_SdtNotaFiscal_Notafiscaltipo = "";
         gxTv_SdtNotaFiscal_Notafiscalmunicipio = "";
         gxTv_SdtNotaFiscal_Notafiscaltipoemissao = "";
         gxTv_SdtNotaFiscal_Notafiscalfinalidades = "";
         gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento = "";
         gxTv_SdtNotaFiscal_Notafiscalemitentenome = "";
         gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro = "";
         gxTv_SdtNotaFiscal_Notafiscalemitentelognum = "";
         gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento = "";
         gxTv_SdtNotaFiscal_Notafiscalemitentebairro = "";
         gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio = "";
         gxTv_SdtNotaFiscal_Notafiscalemitenteuf = "";
         gxTv_SdtNotaFiscal_Notafiscalemitentecep = "";
         gxTv_SdtNotaFiscal_Notafiscalemitentepais = "";
         gxTv_SdtNotaFiscal_Notafiscalemitentetelefone = "";
         gxTv_SdtNotaFiscal_Notafiscalemitenteie = "";
         gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento = "";
         gxTv_SdtNotaFiscal_Notafiscaldestinatarionome = "";
         gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro = "";
         gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum = "";
         gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento = "";
         gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro = "";
         gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio = "";
         gxTv_SdtNotaFiscal_Notafiscaldestinatariouf = "";
         gxTv_SdtNotaFiscal_Notafiscaldestinatariocep = "";
         gxTv_SdtNotaFiscal_Notafiscaldestinatariopais = "";
         gxTv_SdtNotaFiscal_Notafiscaldestinatariofone = "";
         gxTv_SdtNotaFiscal_Mode = "";
         gxTv_SdtNotaFiscal_Notafiscalid_Z = Guid.Empty;
         gxTv_SdtNotaFiscal_Notafiscalquantidaderesumo_f_Z = "";
         gxTv_SdtNotaFiscal_Notafiscalvalorformatado_f_Z = "";
         gxTv_SdtNotaFiscal_Notafiscalvalorvendidoformatado_f_Z = "";
         gxTv_SdtNotaFiscal_Notafiscalsaldoformatado_f_Z = "";
         gxTv_SdtNotaFiscal_Notafiscalstatus_Z = "";
         gxTv_SdtNotaFiscal_Notafiscalnatureza_Z = "";
         gxTv_SdtNotaFiscal_Notafiscalmod_Z = "";
         gxTv_SdtNotaFiscal_Notafiscalserie_Z = "";
         gxTv_SdtNotaFiscal_Notafiscalnumero_Z = "";
         gxTv_SdtNotaFiscal_Notafiscaldataemissao_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtNotaFiscal_Notafiscaldatasaida_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtNotaFiscal_Notafiscaltipo_Z = "";
         gxTv_SdtNotaFiscal_Notafiscalmunicipio_Z = "";
         gxTv_SdtNotaFiscal_Notafiscaltipoemissao_Z = "";
         gxTv_SdtNotaFiscal_Notafiscalfinalidades_Z = "";
         gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento_Z = "";
         gxTv_SdtNotaFiscal_Notafiscalemitentenome_Z = "";
         gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro_Z = "";
         gxTv_SdtNotaFiscal_Notafiscalemitentelognum_Z = "";
         gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento_Z = "";
         gxTv_SdtNotaFiscal_Notafiscalemitentebairro_Z = "";
         gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio_Z = "";
         gxTv_SdtNotaFiscal_Notafiscalemitenteuf_Z = "";
         gxTv_SdtNotaFiscal_Notafiscalemitentecep_Z = "";
         gxTv_SdtNotaFiscal_Notafiscalemitentepais_Z = "";
         gxTv_SdtNotaFiscal_Notafiscalemitentetelefone_Z = "";
         gxTv_SdtNotaFiscal_Notafiscalemitenteie_Z = "";
         gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento_Z = "";
         gxTv_SdtNotaFiscal_Notafiscaldestinatarionome_Z = "";
         gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro_Z = "";
         gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum_Z = "";
         gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento_Z = "";
         gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro_Z = "";
         gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio_Z = "";
         gxTv_SdtNotaFiscal_Notafiscaldestinatariouf_Z = "";
         gxTv_SdtNotaFiscal_Notafiscaldestinatariocep_Z = "";
         gxTv_SdtNotaFiscal_Notafiscaldestinatariopais_Z = "";
         gxTv_SdtNotaFiscal_Notafiscaldestinatariofone_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "notafiscal", "GeneXus.Programs.notafiscal_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtNotaFiscal_Notafiscaluf ;
      private short gxTv_SdtNotaFiscal_Notafiscalquantidadedeitens_f ;
      private short gxTv_SdtNotaFiscal_Notafiscalquantidadedeitensvendidos_f ;
      private short gxTv_SdtNotaFiscal_Notafiscalambiente ;
      private short gxTv_SdtNotaFiscal_Initialized ;
      private short gxTv_SdtNotaFiscal_Notafiscaluf_Z ;
      private short gxTv_SdtNotaFiscal_Notafiscalquantidadedeitens_f_Z ;
      private short gxTv_SdtNotaFiscal_Notafiscalquantidadedeitensvendidos_f_Z ;
      private short gxTv_SdtNotaFiscal_Notafiscalambiente_Z ;
      private short gxTv_SdtNotaFiscal_Notafiscalid_N ;
      private short gxTv_SdtNotaFiscal_Clienteid_N ;
      private short gxTv_SdtNotaFiscal_Notafiscaluf_N ;
      private short gxTv_SdtNotaFiscal_Notafiscalnatureza_N ;
      private short gxTv_SdtNotaFiscal_Notafiscalmod_N ;
      private short gxTv_SdtNotaFiscal_Notafiscalserie_N ;
      private short gxTv_SdtNotaFiscal_Notafiscalnumero_N ;
      private short gxTv_SdtNotaFiscal_Notafiscaldataemissao_N ;
      private short gxTv_SdtNotaFiscal_Notafiscaldatasaida_N ;
      private short gxTv_SdtNotaFiscal_Notafiscaltipo_N ;
      private short gxTv_SdtNotaFiscal_Notafiscalmunicipio_N ;
      private short gxTv_SdtNotaFiscal_Notafiscaltipoemissao_N ;
      private short gxTv_SdtNotaFiscal_Notafiscalambiente_N ;
      private short gxTv_SdtNotaFiscal_Notafiscalfinalidades_N ;
      private short gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento_N ;
      private short gxTv_SdtNotaFiscal_Notafiscalemitentenome_N ;
      private short gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro_N ;
      private short gxTv_SdtNotaFiscal_Notafiscalemitentelognum_N ;
      private short gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento_N ;
      private short gxTv_SdtNotaFiscal_Notafiscalemitentebairro_N ;
      private short gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio_N ;
      private short gxTv_SdtNotaFiscal_Notafiscalemitenteuf_N ;
      private short gxTv_SdtNotaFiscal_Notafiscalemitentecep_N ;
      private short gxTv_SdtNotaFiscal_Notafiscalemitentepais_N ;
      private short gxTv_SdtNotaFiscal_Notafiscalemitentetelefone_N ;
      private short gxTv_SdtNotaFiscal_Notafiscalemitenteie_N ;
      private short gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid_N ;
      private short gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento_N ;
      private short gxTv_SdtNotaFiscal_Notafiscaldestinatarionome_N ;
      private short gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro_N ;
      private short gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum_N ;
      private short gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento_N ;
      private short gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro_N ;
      private short gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio_N ;
      private short gxTv_SdtNotaFiscal_Notafiscaldestinatariouf_N ;
      private short gxTv_SdtNotaFiscal_Notafiscaldestinatariocep_N ;
      private short gxTv_SdtNotaFiscal_Notafiscaldestinatariopais_N ;
      private short gxTv_SdtNotaFiscal_Notafiscaldestinatariofone_N ;
      private int gxTv_SdtNotaFiscal_Clienteid ;
      private int gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid ;
      private int gxTv_SdtNotaFiscal_Clienteid_Z ;
      private int gxTv_SdtNotaFiscal_Notafiscaldestinatarioclienteid_Z ;
      private decimal gxTv_SdtNotaFiscal_Notafiscalvalortotal_f ;
      private decimal gxTv_SdtNotaFiscal_Notafiscalvalortotalvendido_f ;
      private decimal gxTv_SdtNotaFiscal_Notafiscalsaldo_f ;
      private decimal gxTv_SdtNotaFiscal_Notafiscalvalortotal_f_Z ;
      private decimal gxTv_SdtNotaFiscal_Notafiscalvalortotalvendido_f_Z ;
      private decimal gxTv_SdtNotaFiscal_Notafiscalsaldo_f_Z ;
      private string gxTv_SdtNotaFiscal_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtNotaFiscal_Notafiscaldataemissao ;
      private DateTime gxTv_SdtNotaFiscal_Notafiscaldatasaida ;
      private DateTime gxTv_SdtNotaFiscal_Notafiscaldataemissao_Z ;
      private DateTime gxTv_SdtNotaFiscal_Notafiscaldatasaida_Z ;
      private DateTime datetime_STZ ;
      private string gxTv_SdtNotaFiscal_Notafiscalquantidaderesumo_f ;
      private string gxTv_SdtNotaFiscal_Notafiscalvalorformatado_f ;
      private string gxTv_SdtNotaFiscal_Notafiscalvalorvendidoformatado_f ;
      private string gxTv_SdtNotaFiscal_Notafiscalsaldoformatado_f ;
      private string gxTv_SdtNotaFiscal_Notafiscalstatus ;
      private string gxTv_SdtNotaFiscal_Notafiscalnatureza ;
      private string gxTv_SdtNotaFiscal_Notafiscalmod ;
      private string gxTv_SdtNotaFiscal_Notafiscalserie ;
      private string gxTv_SdtNotaFiscal_Notafiscalnumero ;
      private string gxTv_SdtNotaFiscal_Notafiscaltipo ;
      private string gxTv_SdtNotaFiscal_Notafiscalmunicipio ;
      private string gxTv_SdtNotaFiscal_Notafiscaltipoemissao ;
      private string gxTv_SdtNotaFiscal_Notafiscalfinalidades ;
      private string gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento ;
      private string gxTv_SdtNotaFiscal_Notafiscalemitentenome ;
      private string gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro ;
      private string gxTv_SdtNotaFiscal_Notafiscalemitentelognum ;
      private string gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento ;
      private string gxTv_SdtNotaFiscal_Notafiscalemitentebairro ;
      private string gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio ;
      private string gxTv_SdtNotaFiscal_Notafiscalemitenteuf ;
      private string gxTv_SdtNotaFiscal_Notafiscalemitentecep ;
      private string gxTv_SdtNotaFiscal_Notafiscalemitentepais ;
      private string gxTv_SdtNotaFiscal_Notafiscalemitentetelefone ;
      private string gxTv_SdtNotaFiscal_Notafiscalemitenteie ;
      private string gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento ;
      private string gxTv_SdtNotaFiscal_Notafiscaldestinatarionome ;
      private string gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro ;
      private string gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum ;
      private string gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento ;
      private string gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro ;
      private string gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio ;
      private string gxTv_SdtNotaFiscal_Notafiscaldestinatariouf ;
      private string gxTv_SdtNotaFiscal_Notafiscaldestinatariocep ;
      private string gxTv_SdtNotaFiscal_Notafiscaldestinatariopais ;
      private string gxTv_SdtNotaFiscal_Notafiscaldestinatariofone ;
      private string gxTv_SdtNotaFiscal_Notafiscalquantidaderesumo_f_Z ;
      private string gxTv_SdtNotaFiscal_Notafiscalvalorformatado_f_Z ;
      private string gxTv_SdtNotaFiscal_Notafiscalvalorvendidoformatado_f_Z ;
      private string gxTv_SdtNotaFiscal_Notafiscalsaldoformatado_f_Z ;
      private string gxTv_SdtNotaFiscal_Notafiscalstatus_Z ;
      private string gxTv_SdtNotaFiscal_Notafiscalnatureza_Z ;
      private string gxTv_SdtNotaFiscal_Notafiscalmod_Z ;
      private string gxTv_SdtNotaFiscal_Notafiscalserie_Z ;
      private string gxTv_SdtNotaFiscal_Notafiscalnumero_Z ;
      private string gxTv_SdtNotaFiscal_Notafiscaltipo_Z ;
      private string gxTv_SdtNotaFiscal_Notafiscalmunicipio_Z ;
      private string gxTv_SdtNotaFiscal_Notafiscaltipoemissao_Z ;
      private string gxTv_SdtNotaFiscal_Notafiscalfinalidades_Z ;
      private string gxTv_SdtNotaFiscal_Notafiscaemitenteldocumento_Z ;
      private string gxTv_SdtNotaFiscal_Notafiscalemitentenome_Z ;
      private string gxTv_SdtNotaFiscal_Notafiscalemitentelogradouro_Z ;
      private string gxTv_SdtNotaFiscal_Notafiscalemitentelognum_Z ;
      private string gxTv_SdtNotaFiscal_Notafiscalemitentecomplemento_Z ;
      private string gxTv_SdtNotaFiscal_Notafiscalemitentebairro_Z ;
      private string gxTv_SdtNotaFiscal_Notafiscalemitentemunicipio_Z ;
      private string gxTv_SdtNotaFiscal_Notafiscalemitenteuf_Z ;
      private string gxTv_SdtNotaFiscal_Notafiscalemitentecep_Z ;
      private string gxTv_SdtNotaFiscal_Notafiscalemitentepais_Z ;
      private string gxTv_SdtNotaFiscal_Notafiscalemitentetelefone_Z ;
      private string gxTv_SdtNotaFiscal_Notafiscalemitenteie_Z ;
      private string gxTv_SdtNotaFiscal_Notafiscaldestinatariodocumento_Z ;
      private string gxTv_SdtNotaFiscal_Notafiscaldestinatarionome_Z ;
      private string gxTv_SdtNotaFiscal_Notafiscaldestinatariologradouro_Z ;
      private string gxTv_SdtNotaFiscal_Notafiscaldestinatariolognum_Z ;
      private string gxTv_SdtNotaFiscal_Notafiscaldestinatariocomplemento_Z ;
      private string gxTv_SdtNotaFiscal_Notafiscaldestinatariobairro_Z ;
      private string gxTv_SdtNotaFiscal_Notafiscaldestinatariomunicipio_Z ;
      private string gxTv_SdtNotaFiscal_Notafiscaldestinatariouf_Z ;
      private string gxTv_SdtNotaFiscal_Notafiscaldestinatariocep_Z ;
      private string gxTv_SdtNotaFiscal_Notafiscaldestinatariopais_Z ;
      private string gxTv_SdtNotaFiscal_Notafiscaldestinatariofone_Z ;
      private Guid gxTv_SdtNotaFiscal_Notafiscalid ;
      private Guid gxTv_SdtNotaFiscal_Notafiscalid_Z ;
   }

   [DataContract(Name = @"NotaFiscal", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtNotaFiscal_RESTInterface : GxGenericCollectionItem<SdtNotaFiscal>
   {
      public SdtNotaFiscal_RESTInterface( ) : base()
      {
      }

      public SdtNotaFiscal_RESTInterface( SdtNotaFiscal psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "NotaFiscalId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Notafiscalid
      {
         get {
            return sdt.gxTpr_Notafiscalid ;
         }

         set {
            sdt.gxTpr_Notafiscalid = value;
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

      [DataMember( Name = "NotaFiscalUF" , Order = 2 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Notafiscaluf
      {
         get {
            return sdt.gxTpr_Notafiscaluf ;
         }

         set {
            sdt.gxTpr_Notafiscaluf = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "NotaFiscalValorTotal_F" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalvalortotal_f
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Notafiscalvalortotal_f, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Notafiscalvalortotal_f = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "NotaFiscalValorTotalVendido_F" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalvalortotalvendido_f
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Notafiscalvalortotalvendido_f, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Notafiscalvalortotalvendido_f = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "NotaFiscalSaldo_F" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalsaldo_f
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Notafiscalsaldo_f, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Notafiscalsaldo_f = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "NotaFiscalQuantidadeDeItens_F" , Order = 6 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Notafiscalquantidadedeitens_f
      {
         get {
            return sdt.gxTpr_Notafiscalquantidadedeitens_f ;
         }

         set {
            sdt.gxTpr_Notafiscalquantidadedeitens_f = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "NotaFiscalQuantidadeDeItensVendidos_F" , Order = 7 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Notafiscalquantidadedeitensvendidos_f
      {
         get {
            return sdt.gxTpr_Notafiscalquantidadedeitensvendidos_f ;
         }

         set {
            sdt.gxTpr_Notafiscalquantidadedeitensvendidos_f = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "NotaFiscalQuantidadeResumo_F" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalquantidaderesumo_f
      {
         get {
            return sdt.gxTpr_Notafiscalquantidaderesumo_f ;
         }

         set {
            sdt.gxTpr_Notafiscalquantidaderesumo_f = value;
         }

      }

      [DataMember( Name = "NotaFiscalValorFormatado_F" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalvalorformatado_f
      {
         get {
            return sdt.gxTpr_Notafiscalvalorformatado_f ;
         }

         set {
            sdt.gxTpr_Notafiscalvalorformatado_f = value;
         }

      }

      [DataMember( Name = "NotaFiscalValorVendidoFormatado_F" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalvalorvendidoformatado_f
      {
         get {
            return sdt.gxTpr_Notafiscalvalorvendidoformatado_f ;
         }

         set {
            sdt.gxTpr_Notafiscalvalorvendidoformatado_f = value;
         }

      }

      [DataMember( Name = "NotaFiscalSaldoFormatado_F" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalsaldoformatado_f
      {
         get {
            return sdt.gxTpr_Notafiscalsaldoformatado_f ;
         }

         set {
            sdt.gxTpr_Notafiscalsaldoformatado_f = value;
         }

      }

      [DataMember( Name = "NotaFiscalStatus" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalstatus
      {
         get {
            return sdt.gxTpr_Notafiscalstatus ;
         }

         set {
            sdt.gxTpr_Notafiscalstatus = value;
         }

      }

      [DataMember( Name = "NotaFiscalNatureza" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalnatureza
      {
         get {
            return sdt.gxTpr_Notafiscalnatureza ;
         }

         set {
            sdt.gxTpr_Notafiscalnatureza = value;
         }

      }

      [DataMember( Name = "NotaFiscalMod" , Order = 14 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalmod
      {
         get {
            return sdt.gxTpr_Notafiscalmod ;
         }

         set {
            sdt.gxTpr_Notafiscalmod = value;
         }

      }

      [DataMember( Name = "NotaFiscalSerie" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalserie
      {
         get {
            return sdt.gxTpr_Notafiscalserie ;
         }

         set {
            sdt.gxTpr_Notafiscalserie = value;
         }

      }

      [DataMember( Name = "NotaFiscalNumero" , Order = 16 )]
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

      [DataMember( Name = "NotaFiscalDataEmissao" , Order = 17 )]
      [GxSeudo()]
      public string gxTpr_Notafiscaldataemissao
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Notafiscaldataemissao, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Notafiscaldataemissao = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "NotaFiscalDataSaida" , Order = 18 )]
      [GxSeudo()]
      public string gxTpr_Notafiscaldatasaida
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Notafiscaldatasaida, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Notafiscaldatasaida = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "NotaFiscalTipo" , Order = 19 )]
      [GxSeudo()]
      public string gxTpr_Notafiscaltipo
      {
         get {
            return sdt.gxTpr_Notafiscaltipo ;
         }

         set {
            sdt.gxTpr_Notafiscaltipo = value;
         }

      }

      [DataMember( Name = "NotaFiscalMunicipio" , Order = 20 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalmunicipio
      {
         get {
            return sdt.gxTpr_Notafiscalmunicipio ;
         }

         set {
            sdt.gxTpr_Notafiscalmunicipio = value;
         }

      }

      [DataMember( Name = "NotaFiscalTipoEmissao" , Order = 21 )]
      [GxSeudo()]
      public string gxTpr_Notafiscaltipoemissao
      {
         get {
            return sdt.gxTpr_Notafiscaltipoemissao ;
         }

         set {
            sdt.gxTpr_Notafiscaltipoemissao = value;
         }

      }

      [DataMember( Name = "NotaFiscalAmbiente" , Order = 22 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Notafiscalambiente
      {
         get {
            return sdt.gxTpr_Notafiscalambiente ;
         }

         set {
            sdt.gxTpr_Notafiscalambiente = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "NotaFiscalFinalidades" , Order = 23 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalfinalidades
      {
         get {
            return sdt.gxTpr_Notafiscalfinalidades ;
         }

         set {
            sdt.gxTpr_Notafiscalfinalidades = value;
         }

      }

      [DataMember( Name = "NotaFiscaEmitentelDocumento" , Order = 24 )]
      [GxSeudo()]
      public string gxTpr_Notafiscaemitenteldocumento
      {
         get {
            return sdt.gxTpr_Notafiscaemitenteldocumento ;
         }

         set {
            sdt.gxTpr_Notafiscaemitenteldocumento = value;
         }

      }

      [DataMember( Name = "NotaFiscalEmitenteNome" , Order = 25 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalemitentenome
      {
         get {
            return sdt.gxTpr_Notafiscalemitentenome ;
         }

         set {
            sdt.gxTpr_Notafiscalemitentenome = value;
         }

      }

      [DataMember( Name = "NotaFiscalEmitenteLogradouro" , Order = 26 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalemitentelogradouro
      {
         get {
            return sdt.gxTpr_Notafiscalemitentelogradouro ;
         }

         set {
            sdt.gxTpr_Notafiscalemitentelogradouro = value;
         }

      }

      [DataMember( Name = "NotaFiscalEmitenteLogNum" , Order = 27 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalemitentelognum
      {
         get {
            return sdt.gxTpr_Notafiscalemitentelognum ;
         }

         set {
            sdt.gxTpr_Notafiscalemitentelognum = value;
         }

      }

      [DataMember( Name = "NotaFiscalEmitenteComplemento" , Order = 28 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalemitentecomplemento
      {
         get {
            return sdt.gxTpr_Notafiscalemitentecomplemento ;
         }

         set {
            sdt.gxTpr_Notafiscalemitentecomplemento = value;
         }

      }

      [DataMember( Name = "NotaFiscalEmitenteBairro" , Order = 29 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalemitentebairro
      {
         get {
            return sdt.gxTpr_Notafiscalemitentebairro ;
         }

         set {
            sdt.gxTpr_Notafiscalemitentebairro = value;
         }

      }

      [DataMember( Name = "NotaFiscalEmitenteMunicipio" , Order = 30 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalemitentemunicipio
      {
         get {
            return sdt.gxTpr_Notafiscalemitentemunicipio ;
         }

         set {
            sdt.gxTpr_Notafiscalemitentemunicipio = value;
         }

      }

      [DataMember( Name = "NotaFiscalEmitenteUF" , Order = 31 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalemitenteuf
      {
         get {
            return sdt.gxTpr_Notafiscalemitenteuf ;
         }

         set {
            sdt.gxTpr_Notafiscalemitenteuf = value;
         }

      }

      [DataMember( Name = "NotaFiscalEmitenteCEP" , Order = 32 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalemitentecep
      {
         get {
            return sdt.gxTpr_Notafiscalemitentecep ;
         }

         set {
            sdt.gxTpr_Notafiscalemitentecep = value;
         }

      }

      [DataMember( Name = "NotaFiscalEmitentePais" , Order = 33 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalemitentepais
      {
         get {
            return sdt.gxTpr_Notafiscalemitentepais ;
         }

         set {
            sdt.gxTpr_Notafiscalemitentepais = value;
         }

      }

      [DataMember( Name = "NotaFiscalEmitenteTelefone" , Order = 34 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalemitentetelefone
      {
         get {
            return sdt.gxTpr_Notafiscalemitentetelefone ;
         }

         set {
            sdt.gxTpr_Notafiscalemitentetelefone = value;
         }

      }

      [DataMember( Name = "NotaFiscalEmitenteIE" , Order = 35 )]
      [GxSeudo()]
      public string gxTpr_Notafiscalemitenteie
      {
         get {
            return sdt.gxTpr_Notafiscalemitenteie ;
         }

         set {
            sdt.gxTpr_Notafiscalemitenteie = value;
         }

      }

      [DataMember( Name = "NotaFiscalDestinatarioClienteId" , Order = 36 )]
      [GxSeudo()]
      public string gxTpr_Notafiscaldestinatarioclienteid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Notafiscaldestinatarioclienteid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Notafiscaldestinatarioclienteid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "NotaFiscalDestinatarioDocumento" , Order = 37 )]
      [GxSeudo()]
      public string gxTpr_Notafiscaldestinatariodocumento
      {
         get {
            return sdt.gxTpr_Notafiscaldestinatariodocumento ;
         }

         set {
            sdt.gxTpr_Notafiscaldestinatariodocumento = value;
         }

      }

      [DataMember( Name = "NotaFiscalDestinatarioNome" , Order = 38 )]
      [GxSeudo()]
      public string gxTpr_Notafiscaldestinatarionome
      {
         get {
            return sdt.gxTpr_Notafiscaldestinatarionome ;
         }

         set {
            sdt.gxTpr_Notafiscaldestinatarionome = value;
         }

      }

      [DataMember( Name = "NotaFiscalDestinatarioLogradouro" , Order = 39 )]
      [GxSeudo()]
      public string gxTpr_Notafiscaldestinatariologradouro
      {
         get {
            return sdt.gxTpr_Notafiscaldestinatariologradouro ;
         }

         set {
            sdt.gxTpr_Notafiscaldestinatariologradouro = value;
         }

      }

      [DataMember( Name = "NotaFiscalDestinatarioLogNum" , Order = 40 )]
      [GxSeudo()]
      public string gxTpr_Notafiscaldestinatariolognum
      {
         get {
            return sdt.gxTpr_Notafiscaldestinatariolognum ;
         }

         set {
            sdt.gxTpr_Notafiscaldestinatariolognum = value;
         }

      }

      [DataMember( Name = "NotaFiscalDestinatarioComplemento" , Order = 41 )]
      [GxSeudo()]
      public string gxTpr_Notafiscaldestinatariocomplemento
      {
         get {
            return sdt.gxTpr_Notafiscaldestinatariocomplemento ;
         }

         set {
            sdt.gxTpr_Notafiscaldestinatariocomplemento = value;
         }

      }

      [DataMember( Name = "NotaFiscalDestinatarioBairro" , Order = 42 )]
      [GxSeudo()]
      public string gxTpr_Notafiscaldestinatariobairro
      {
         get {
            return sdt.gxTpr_Notafiscaldestinatariobairro ;
         }

         set {
            sdt.gxTpr_Notafiscaldestinatariobairro = value;
         }

      }

      [DataMember( Name = "NotaFiscalDestinatarioMunicipio" , Order = 43 )]
      [GxSeudo()]
      public string gxTpr_Notafiscaldestinatariomunicipio
      {
         get {
            return sdt.gxTpr_Notafiscaldestinatariomunicipio ;
         }

         set {
            sdt.gxTpr_Notafiscaldestinatariomunicipio = value;
         }

      }

      [DataMember( Name = "NotaFiscalDestinatarioUF" , Order = 44 )]
      [GxSeudo()]
      public string gxTpr_Notafiscaldestinatariouf
      {
         get {
            return sdt.gxTpr_Notafiscaldestinatariouf ;
         }

         set {
            sdt.gxTpr_Notafiscaldestinatariouf = value;
         }

      }

      [DataMember( Name = "NotaFiscalDestinatarioCEP" , Order = 45 )]
      [GxSeudo()]
      public string gxTpr_Notafiscaldestinatariocep
      {
         get {
            return sdt.gxTpr_Notafiscaldestinatariocep ;
         }

         set {
            sdt.gxTpr_Notafiscaldestinatariocep = value;
         }

      }

      [DataMember( Name = "NotaFiscalDestinatarioPais" , Order = 46 )]
      [GxSeudo()]
      public string gxTpr_Notafiscaldestinatariopais
      {
         get {
            return sdt.gxTpr_Notafiscaldestinatariopais ;
         }

         set {
            sdt.gxTpr_Notafiscaldestinatariopais = value;
         }

      }

      [DataMember( Name = "NotaFiscalDestinatarioFone" , Order = 47 )]
      [GxSeudo()]
      public string gxTpr_Notafiscaldestinatariofone
      {
         get {
            return sdt.gxTpr_Notafiscaldestinatariofone ;
         }

         set {
            sdt.gxTpr_Notafiscaldestinatariofone = value;
         }

      }

      public SdtNotaFiscal sdt
      {
         get {
            return (SdtNotaFiscal)Sdt ;
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
            sdt = new SdtNotaFiscal() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 48 )]
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

   [DataContract(Name = @"NotaFiscal", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtNotaFiscal_RESTLInterface : GxGenericCollectionItem<SdtNotaFiscal>
   {
      public SdtNotaFiscal_RESTLInterface( ) : base()
      {
      }

      public SdtNotaFiscal_RESTLInterface( SdtNotaFiscal psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "NotaFiscalUF" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Notafiscaluf
      {
         get {
            return sdt.gxTpr_Notafiscaluf ;
         }

         set {
            sdt.gxTpr_Notafiscaluf = (short)(value.HasValue ? value.Value : 0);
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

      public SdtNotaFiscal sdt
      {
         get {
            return (SdtNotaFiscal)Sdt ;
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
            sdt = new SdtNotaFiscal() ;
         }
      }

   }

}
