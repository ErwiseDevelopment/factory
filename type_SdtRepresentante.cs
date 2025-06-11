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
   [XmlRoot(ElementName = "Representante" )]
   [XmlType(TypeName =  "Representante" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtRepresentante : GxSilentTrnSdt
   {
      public SdtRepresentante( )
      {
      }

      public SdtRepresentante( IGxContext context )
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

      public void Load( int AV978RepresentanteId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV978RepresentanteId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"RepresentanteId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Representante");
         metadata.Set("BT", "Representante");
         metadata.Set("PK", "[ \"RepresentanteId\" ]");
         metadata.Set("PKAssigned", "[ \"RepresentanteId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ClienteId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"MunicipioCodigo\" ],\"FKMap\":[ \"RepresentanteMunicipio-MunicipioCodigo\" ] },{ \"FK\":[ \"ProfissaoId\" ],\"FKMap\":[ \"RepresentanteProfissao-ProfissaoId\" ] } ]");
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
         state.Add("gxTpr_Representanteid_Z");
         state.Add("gxTpr_Representantenome_Z");
         state.Add("gxTpr_Representanterg_Z");
         state.Add("gxTpr_Representanteorgaoexpedidor_Z");
         state.Add("gxTpr_Representanterguf_Z");
         state.Add("gxTpr_Representantecpf_Z");
         state.Add("gxTpr_Representanteestadocivil_Z");
         state.Add("gxTpr_Representantenacionalidade_Z");
         state.Add("gxTpr_Representanteprofissao_Z");
         state.Add("gxTpr_Representanteprofissaodescricao_Z");
         state.Add("gxTpr_Representanteemail_Z");
         state.Add("gxTpr_Representantecep_Z");
         state.Add("gxTpr_Representantelogradouro_Z");
         state.Add("gxTpr_Representantebairro_Z");
         state.Add("gxTpr_Representantecidade_Z");
         state.Add("gxTpr_Representantemunicipio_Z");
         state.Add("gxTpr_Representantelogradouronumero_Z");
         state.Add("gxTpr_Representantecomplemento_Z");
         state.Add("gxTpr_Representanteddd_Z");
         state.Add("gxTpr_Representantenumero_Z");
         state.Add("gxTpr_Representantemunicipiouf_Z");
         state.Add("gxTpr_Representantemunicipionome_Z");
         state.Add("gxTpr_Representantetipo_Z");
         state.Add("gxTpr_Clienteid_Z");
         state.Add("gxTpr_Representantenome_N");
         state.Add("gxTpr_Representanterg_N");
         state.Add("gxTpr_Representanteorgaoexpedidor_N");
         state.Add("gxTpr_Representanterguf_N");
         state.Add("gxTpr_Representantecpf_N");
         state.Add("gxTpr_Representanteestadocivil_N");
         state.Add("gxTpr_Representantenacionalidade_N");
         state.Add("gxTpr_Representanteprofissao_N");
         state.Add("gxTpr_Representanteprofissaodescricao_N");
         state.Add("gxTpr_Representanteemail_N");
         state.Add("gxTpr_Representantecep_N");
         state.Add("gxTpr_Representantelogradouro_N");
         state.Add("gxTpr_Representantebairro_N");
         state.Add("gxTpr_Representantecidade_N");
         state.Add("gxTpr_Representantemunicipio_N");
         state.Add("gxTpr_Representantelogradouronumero_N");
         state.Add("gxTpr_Representantecomplemento_N");
         state.Add("gxTpr_Representanteddd_N");
         state.Add("gxTpr_Representantenumero_N");
         state.Add("gxTpr_Representantemunicipiouf_N");
         state.Add("gxTpr_Representantemunicipionome_N");
         state.Add("gxTpr_Representantetipo_N");
         state.Add("gxTpr_Clienteid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtRepresentante sdt;
         sdt = (SdtRepresentante)(source);
         gxTv_SdtRepresentante_Representanteid = sdt.gxTv_SdtRepresentante_Representanteid ;
         gxTv_SdtRepresentante_Representantenome = sdt.gxTv_SdtRepresentante_Representantenome ;
         gxTv_SdtRepresentante_Representanterg = sdt.gxTv_SdtRepresentante_Representanterg ;
         gxTv_SdtRepresentante_Representanteorgaoexpedidor = sdt.gxTv_SdtRepresentante_Representanteorgaoexpedidor ;
         gxTv_SdtRepresentante_Representanterguf = sdt.gxTv_SdtRepresentante_Representanterguf ;
         gxTv_SdtRepresentante_Representantecpf = sdt.gxTv_SdtRepresentante_Representantecpf ;
         gxTv_SdtRepresentante_Representanteestadocivil = sdt.gxTv_SdtRepresentante_Representanteestadocivil ;
         gxTv_SdtRepresentante_Representantenacionalidade = sdt.gxTv_SdtRepresentante_Representantenacionalidade ;
         gxTv_SdtRepresentante_Representanteprofissao = sdt.gxTv_SdtRepresentante_Representanteprofissao ;
         gxTv_SdtRepresentante_Representanteprofissaodescricao = sdt.gxTv_SdtRepresentante_Representanteprofissaodescricao ;
         gxTv_SdtRepresentante_Representanteemail = sdt.gxTv_SdtRepresentante_Representanteemail ;
         gxTv_SdtRepresentante_Representantecep = sdt.gxTv_SdtRepresentante_Representantecep ;
         gxTv_SdtRepresentante_Representantelogradouro = sdt.gxTv_SdtRepresentante_Representantelogradouro ;
         gxTv_SdtRepresentante_Representantebairro = sdt.gxTv_SdtRepresentante_Representantebairro ;
         gxTv_SdtRepresentante_Representantecidade = sdt.gxTv_SdtRepresentante_Representantecidade ;
         gxTv_SdtRepresentante_Representantemunicipio = sdt.gxTv_SdtRepresentante_Representantemunicipio ;
         gxTv_SdtRepresentante_Representantelogradouronumero = sdt.gxTv_SdtRepresentante_Representantelogradouronumero ;
         gxTv_SdtRepresentante_Representantecomplemento = sdt.gxTv_SdtRepresentante_Representantecomplemento ;
         gxTv_SdtRepresentante_Representanteddd = sdt.gxTv_SdtRepresentante_Representanteddd ;
         gxTv_SdtRepresentante_Representantenumero = sdt.gxTv_SdtRepresentante_Representantenumero ;
         gxTv_SdtRepresentante_Representantemunicipiouf = sdt.gxTv_SdtRepresentante_Representantemunicipiouf ;
         gxTv_SdtRepresentante_Representantemunicipionome = sdt.gxTv_SdtRepresentante_Representantemunicipionome ;
         gxTv_SdtRepresentante_Representantetipo = sdt.gxTv_SdtRepresentante_Representantetipo ;
         gxTv_SdtRepresentante_Clienteid = sdt.gxTv_SdtRepresentante_Clienteid ;
         gxTv_SdtRepresentante_Mode = sdt.gxTv_SdtRepresentante_Mode ;
         gxTv_SdtRepresentante_Initialized = sdt.gxTv_SdtRepresentante_Initialized ;
         gxTv_SdtRepresentante_Representanteid_Z = sdt.gxTv_SdtRepresentante_Representanteid_Z ;
         gxTv_SdtRepresentante_Representantenome_Z = sdt.gxTv_SdtRepresentante_Representantenome_Z ;
         gxTv_SdtRepresentante_Representanterg_Z = sdt.gxTv_SdtRepresentante_Representanterg_Z ;
         gxTv_SdtRepresentante_Representanteorgaoexpedidor_Z = sdt.gxTv_SdtRepresentante_Representanteorgaoexpedidor_Z ;
         gxTv_SdtRepresentante_Representanterguf_Z = sdt.gxTv_SdtRepresentante_Representanterguf_Z ;
         gxTv_SdtRepresentante_Representantecpf_Z = sdt.gxTv_SdtRepresentante_Representantecpf_Z ;
         gxTv_SdtRepresentante_Representanteestadocivil_Z = sdt.gxTv_SdtRepresentante_Representanteestadocivil_Z ;
         gxTv_SdtRepresentante_Representantenacionalidade_Z = sdt.gxTv_SdtRepresentante_Representantenacionalidade_Z ;
         gxTv_SdtRepresentante_Representanteprofissao_Z = sdt.gxTv_SdtRepresentante_Representanteprofissao_Z ;
         gxTv_SdtRepresentante_Representanteprofissaodescricao_Z = sdt.gxTv_SdtRepresentante_Representanteprofissaodescricao_Z ;
         gxTv_SdtRepresentante_Representanteemail_Z = sdt.gxTv_SdtRepresentante_Representanteemail_Z ;
         gxTv_SdtRepresentante_Representantecep_Z = sdt.gxTv_SdtRepresentante_Representantecep_Z ;
         gxTv_SdtRepresentante_Representantelogradouro_Z = sdt.gxTv_SdtRepresentante_Representantelogradouro_Z ;
         gxTv_SdtRepresentante_Representantebairro_Z = sdt.gxTv_SdtRepresentante_Representantebairro_Z ;
         gxTv_SdtRepresentante_Representantecidade_Z = sdt.gxTv_SdtRepresentante_Representantecidade_Z ;
         gxTv_SdtRepresentante_Representantemunicipio_Z = sdt.gxTv_SdtRepresentante_Representantemunicipio_Z ;
         gxTv_SdtRepresentante_Representantelogradouronumero_Z = sdt.gxTv_SdtRepresentante_Representantelogradouronumero_Z ;
         gxTv_SdtRepresentante_Representantecomplemento_Z = sdt.gxTv_SdtRepresentante_Representantecomplemento_Z ;
         gxTv_SdtRepresentante_Representanteddd_Z = sdt.gxTv_SdtRepresentante_Representanteddd_Z ;
         gxTv_SdtRepresentante_Representantenumero_Z = sdt.gxTv_SdtRepresentante_Representantenumero_Z ;
         gxTv_SdtRepresentante_Representantemunicipiouf_Z = sdt.gxTv_SdtRepresentante_Representantemunicipiouf_Z ;
         gxTv_SdtRepresentante_Representantemunicipionome_Z = sdt.gxTv_SdtRepresentante_Representantemunicipionome_Z ;
         gxTv_SdtRepresentante_Representantetipo_Z = sdt.gxTv_SdtRepresentante_Representantetipo_Z ;
         gxTv_SdtRepresentante_Clienteid_Z = sdt.gxTv_SdtRepresentante_Clienteid_Z ;
         gxTv_SdtRepresentante_Representantenome_N = sdt.gxTv_SdtRepresentante_Representantenome_N ;
         gxTv_SdtRepresentante_Representanterg_N = sdt.gxTv_SdtRepresentante_Representanterg_N ;
         gxTv_SdtRepresentante_Representanteorgaoexpedidor_N = sdt.gxTv_SdtRepresentante_Representanteorgaoexpedidor_N ;
         gxTv_SdtRepresentante_Representanterguf_N = sdt.gxTv_SdtRepresentante_Representanterguf_N ;
         gxTv_SdtRepresentante_Representantecpf_N = sdt.gxTv_SdtRepresentante_Representantecpf_N ;
         gxTv_SdtRepresentante_Representanteestadocivil_N = sdt.gxTv_SdtRepresentante_Representanteestadocivil_N ;
         gxTv_SdtRepresentante_Representantenacionalidade_N = sdt.gxTv_SdtRepresentante_Representantenacionalidade_N ;
         gxTv_SdtRepresentante_Representanteprofissao_N = sdt.gxTv_SdtRepresentante_Representanteprofissao_N ;
         gxTv_SdtRepresentante_Representanteprofissaodescricao_N = sdt.gxTv_SdtRepresentante_Representanteprofissaodescricao_N ;
         gxTv_SdtRepresentante_Representanteemail_N = sdt.gxTv_SdtRepresentante_Representanteemail_N ;
         gxTv_SdtRepresentante_Representantecep_N = sdt.gxTv_SdtRepresentante_Representantecep_N ;
         gxTv_SdtRepresentante_Representantelogradouro_N = sdt.gxTv_SdtRepresentante_Representantelogradouro_N ;
         gxTv_SdtRepresentante_Representantebairro_N = sdt.gxTv_SdtRepresentante_Representantebairro_N ;
         gxTv_SdtRepresentante_Representantecidade_N = sdt.gxTv_SdtRepresentante_Representantecidade_N ;
         gxTv_SdtRepresentante_Representantemunicipio_N = sdt.gxTv_SdtRepresentante_Representantemunicipio_N ;
         gxTv_SdtRepresentante_Representantelogradouronumero_N = sdt.gxTv_SdtRepresentante_Representantelogradouronumero_N ;
         gxTv_SdtRepresentante_Representantecomplemento_N = sdt.gxTv_SdtRepresentante_Representantecomplemento_N ;
         gxTv_SdtRepresentante_Representanteddd_N = sdt.gxTv_SdtRepresentante_Representanteddd_N ;
         gxTv_SdtRepresentante_Representantenumero_N = sdt.gxTv_SdtRepresentante_Representantenumero_N ;
         gxTv_SdtRepresentante_Representantemunicipiouf_N = sdt.gxTv_SdtRepresentante_Representantemunicipiouf_N ;
         gxTv_SdtRepresentante_Representantemunicipionome_N = sdt.gxTv_SdtRepresentante_Representantemunicipionome_N ;
         gxTv_SdtRepresentante_Representantetipo_N = sdt.gxTv_SdtRepresentante_Representantetipo_N ;
         gxTv_SdtRepresentante_Clienteid_N = sdt.gxTv_SdtRepresentante_Clienteid_N ;
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
         AddObjectProperty("RepresentanteId", gxTv_SdtRepresentante_Representanteid, false, includeNonInitialized);
         AddObjectProperty("RepresentanteNome", gxTv_SdtRepresentante_Representantenome, false, includeNonInitialized);
         AddObjectProperty("RepresentanteNome_N", gxTv_SdtRepresentante_Representantenome_N, false, includeNonInitialized);
         AddObjectProperty("RepresentanteRG", gxTv_SdtRepresentante_Representanterg, false, includeNonInitialized);
         AddObjectProperty("RepresentanteRG_N", gxTv_SdtRepresentante_Representanterg_N, false, includeNonInitialized);
         AddObjectProperty("RepresentanteOrgaoExpedidor", gxTv_SdtRepresentante_Representanteorgaoexpedidor, false, includeNonInitialized);
         AddObjectProperty("RepresentanteOrgaoExpedidor_N", gxTv_SdtRepresentante_Representanteorgaoexpedidor_N, false, includeNonInitialized);
         AddObjectProperty("RepresentanteRGUF", gxTv_SdtRepresentante_Representanterguf, false, includeNonInitialized);
         AddObjectProperty("RepresentanteRGUF_N", gxTv_SdtRepresentante_Representanterguf_N, false, includeNonInitialized);
         AddObjectProperty("RepresentanteCPF", gxTv_SdtRepresentante_Representantecpf, false, includeNonInitialized);
         AddObjectProperty("RepresentanteCPF_N", gxTv_SdtRepresentante_Representantecpf_N, false, includeNonInitialized);
         AddObjectProperty("RepresentanteEstadoCivil", gxTv_SdtRepresentante_Representanteestadocivil, false, includeNonInitialized);
         AddObjectProperty("RepresentanteEstadoCivil_N", gxTv_SdtRepresentante_Representanteestadocivil_N, false, includeNonInitialized);
         AddObjectProperty("RepresentanteNacionalidade", gxTv_SdtRepresentante_Representantenacionalidade, false, includeNonInitialized);
         AddObjectProperty("RepresentanteNacionalidade_N", gxTv_SdtRepresentante_Representantenacionalidade_N, false, includeNonInitialized);
         AddObjectProperty("RepresentanteProfissao", gxTv_SdtRepresentante_Representanteprofissao, false, includeNonInitialized);
         AddObjectProperty("RepresentanteProfissao_N", gxTv_SdtRepresentante_Representanteprofissao_N, false, includeNonInitialized);
         AddObjectProperty("RepresentanteProfissaoDescricao", gxTv_SdtRepresentante_Representanteprofissaodescricao, false, includeNonInitialized);
         AddObjectProperty("RepresentanteProfissaoDescricao_N", gxTv_SdtRepresentante_Representanteprofissaodescricao_N, false, includeNonInitialized);
         AddObjectProperty("RepresentanteEmail", gxTv_SdtRepresentante_Representanteemail, false, includeNonInitialized);
         AddObjectProperty("RepresentanteEmail_N", gxTv_SdtRepresentante_Representanteemail_N, false, includeNonInitialized);
         AddObjectProperty("RepresentanteCEP", gxTv_SdtRepresentante_Representantecep, false, includeNonInitialized);
         AddObjectProperty("RepresentanteCEP_N", gxTv_SdtRepresentante_Representantecep_N, false, includeNonInitialized);
         AddObjectProperty("RepresentanteLogradouro", gxTv_SdtRepresentante_Representantelogradouro, false, includeNonInitialized);
         AddObjectProperty("RepresentanteLogradouro_N", gxTv_SdtRepresentante_Representantelogradouro_N, false, includeNonInitialized);
         AddObjectProperty("RepresentanteBairro", gxTv_SdtRepresentante_Representantebairro, false, includeNonInitialized);
         AddObjectProperty("RepresentanteBairro_N", gxTv_SdtRepresentante_Representantebairro_N, false, includeNonInitialized);
         AddObjectProperty("RepresentanteCidade", gxTv_SdtRepresentante_Representantecidade, false, includeNonInitialized);
         AddObjectProperty("RepresentanteCidade_N", gxTv_SdtRepresentante_Representantecidade_N, false, includeNonInitialized);
         AddObjectProperty("RepresentanteMunicipio", gxTv_SdtRepresentante_Representantemunicipio, false, includeNonInitialized);
         AddObjectProperty("RepresentanteMunicipio_N", gxTv_SdtRepresentante_Representantemunicipio_N, false, includeNonInitialized);
         AddObjectProperty("RepresentanteLogradouroNumero", gxTv_SdtRepresentante_Representantelogradouronumero, false, includeNonInitialized);
         AddObjectProperty("RepresentanteLogradouroNumero_N", gxTv_SdtRepresentante_Representantelogradouronumero_N, false, includeNonInitialized);
         AddObjectProperty("RepresentanteComplemento", gxTv_SdtRepresentante_Representantecomplemento, false, includeNonInitialized);
         AddObjectProperty("RepresentanteComplemento_N", gxTv_SdtRepresentante_Representantecomplemento_N, false, includeNonInitialized);
         AddObjectProperty("RepresentanteDDD", gxTv_SdtRepresentante_Representanteddd, false, includeNonInitialized);
         AddObjectProperty("RepresentanteDDD_N", gxTv_SdtRepresentante_Representanteddd_N, false, includeNonInitialized);
         AddObjectProperty("RepresentanteNumero", gxTv_SdtRepresentante_Representantenumero, false, includeNonInitialized);
         AddObjectProperty("RepresentanteNumero_N", gxTv_SdtRepresentante_Representantenumero_N, false, includeNonInitialized);
         AddObjectProperty("RepresentanteMunicipioUF", gxTv_SdtRepresentante_Representantemunicipiouf, false, includeNonInitialized);
         AddObjectProperty("RepresentanteMunicipioUF_N", gxTv_SdtRepresentante_Representantemunicipiouf_N, false, includeNonInitialized);
         AddObjectProperty("RepresentanteMunicipioNome", gxTv_SdtRepresentante_Representantemunicipionome, false, includeNonInitialized);
         AddObjectProperty("RepresentanteMunicipioNome_N", gxTv_SdtRepresentante_Representantemunicipionome_N, false, includeNonInitialized);
         AddObjectProperty("RepresentanteTipo", gxTv_SdtRepresentante_Representantetipo, false, includeNonInitialized);
         AddObjectProperty("RepresentanteTipo_N", gxTv_SdtRepresentante_Representantetipo_N, false, includeNonInitialized);
         AddObjectProperty("ClienteId", gxTv_SdtRepresentante_Clienteid, false, includeNonInitialized);
         AddObjectProperty("ClienteId_N", gxTv_SdtRepresentante_Clienteid_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtRepresentante_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtRepresentante_Initialized, false, includeNonInitialized);
            AddObjectProperty("RepresentanteId_Z", gxTv_SdtRepresentante_Representanteid_Z, false, includeNonInitialized);
            AddObjectProperty("RepresentanteNome_Z", gxTv_SdtRepresentante_Representantenome_Z, false, includeNonInitialized);
            AddObjectProperty("RepresentanteRG_Z", gxTv_SdtRepresentante_Representanterg_Z, false, includeNonInitialized);
            AddObjectProperty("RepresentanteOrgaoExpedidor_Z", gxTv_SdtRepresentante_Representanteorgaoexpedidor_Z, false, includeNonInitialized);
            AddObjectProperty("RepresentanteRGUF_Z", gxTv_SdtRepresentante_Representanterguf_Z, false, includeNonInitialized);
            AddObjectProperty("RepresentanteCPF_Z", gxTv_SdtRepresentante_Representantecpf_Z, false, includeNonInitialized);
            AddObjectProperty("RepresentanteEstadoCivil_Z", gxTv_SdtRepresentante_Representanteestadocivil_Z, false, includeNonInitialized);
            AddObjectProperty("RepresentanteNacionalidade_Z", gxTv_SdtRepresentante_Representantenacionalidade_Z, false, includeNonInitialized);
            AddObjectProperty("RepresentanteProfissao_Z", gxTv_SdtRepresentante_Representanteprofissao_Z, false, includeNonInitialized);
            AddObjectProperty("RepresentanteProfissaoDescricao_Z", gxTv_SdtRepresentante_Representanteprofissaodescricao_Z, false, includeNonInitialized);
            AddObjectProperty("RepresentanteEmail_Z", gxTv_SdtRepresentante_Representanteemail_Z, false, includeNonInitialized);
            AddObjectProperty("RepresentanteCEP_Z", gxTv_SdtRepresentante_Representantecep_Z, false, includeNonInitialized);
            AddObjectProperty("RepresentanteLogradouro_Z", gxTv_SdtRepresentante_Representantelogradouro_Z, false, includeNonInitialized);
            AddObjectProperty("RepresentanteBairro_Z", gxTv_SdtRepresentante_Representantebairro_Z, false, includeNonInitialized);
            AddObjectProperty("RepresentanteCidade_Z", gxTv_SdtRepresentante_Representantecidade_Z, false, includeNonInitialized);
            AddObjectProperty("RepresentanteMunicipio_Z", gxTv_SdtRepresentante_Representantemunicipio_Z, false, includeNonInitialized);
            AddObjectProperty("RepresentanteLogradouroNumero_Z", gxTv_SdtRepresentante_Representantelogradouronumero_Z, false, includeNonInitialized);
            AddObjectProperty("RepresentanteComplemento_Z", gxTv_SdtRepresentante_Representantecomplemento_Z, false, includeNonInitialized);
            AddObjectProperty("RepresentanteDDD_Z", gxTv_SdtRepresentante_Representanteddd_Z, false, includeNonInitialized);
            AddObjectProperty("RepresentanteNumero_Z", gxTv_SdtRepresentante_Representantenumero_Z, false, includeNonInitialized);
            AddObjectProperty("RepresentanteMunicipioUF_Z", gxTv_SdtRepresentante_Representantemunicipiouf_Z, false, includeNonInitialized);
            AddObjectProperty("RepresentanteMunicipioNome_Z", gxTv_SdtRepresentante_Representantemunicipionome_Z, false, includeNonInitialized);
            AddObjectProperty("RepresentanteTipo_Z", gxTv_SdtRepresentante_Representantetipo_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteId_Z", gxTv_SdtRepresentante_Clienteid_Z, false, includeNonInitialized);
            AddObjectProperty("RepresentanteNome_N", gxTv_SdtRepresentante_Representantenome_N, false, includeNonInitialized);
            AddObjectProperty("RepresentanteRG_N", gxTv_SdtRepresentante_Representanterg_N, false, includeNonInitialized);
            AddObjectProperty("RepresentanteOrgaoExpedidor_N", gxTv_SdtRepresentante_Representanteorgaoexpedidor_N, false, includeNonInitialized);
            AddObjectProperty("RepresentanteRGUF_N", gxTv_SdtRepresentante_Representanterguf_N, false, includeNonInitialized);
            AddObjectProperty("RepresentanteCPF_N", gxTv_SdtRepresentante_Representantecpf_N, false, includeNonInitialized);
            AddObjectProperty("RepresentanteEstadoCivil_N", gxTv_SdtRepresentante_Representanteestadocivil_N, false, includeNonInitialized);
            AddObjectProperty("RepresentanteNacionalidade_N", gxTv_SdtRepresentante_Representantenacionalidade_N, false, includeNonInitialized);
            AddObjectProperty("RepresentanteProfissao_N", gxTv_SdtRepresentante_Representanteprofissao_N, false, includeNonInitialized);
            AddObjectProperty("RepresentanteProfissaoDescricao_N", gxTv_SdtRepresentante_Representanteprofissaodescricao_N, false, includeNonInitialized);
            AddObjectProperty("RepresentanteEmail_N", gxTv_SdtRepresentante_Representanteemail_N, false, includeNonInitialized);
            AddObjectProperty("RepresentanteCEP_N", gxTv_SdtRepresentante_Representantecep_N, false, includeNonInitialized);
            AddObjectProperty("RepresentanteLogradouro_N", gxTv_SdtRepresentante_Representantelogradouro_N, false, includeNonInitialized);
            AddObjectProperty("RepresentanteBairro_N", gxTv_SdtRepresentante_Representantebairro_N, false, includeNonInitialized);
            AddObjectProperty("RepresentanteCidade_N", gxTv_SdtRepresentante_Representantecidade_N, false, includeNonInitialized);
            AddObjectProperty("RepresentanteMunicipio_N", gxTv_SdtRepresentante_Representantemunicipio_N, false, includeNonInitialized);
            AddObjectProperty("RepresentanteLogradouroNumero_N", gxTv_SdtRepresentante_Representantelogradouronumero_N, false, includeNonInitialized);
            AddObjectProperty("RepresentanteComplemento_N", gxTv_SdtRepresentante_Representantecomplemento_N, false, includeNonInitialized);
            AddObjectProperty("RepresentanteDDD_N", gxTv_SdtRepresentante_Representanteddd_N, false, includeNonInitialized);
            AddObjectProperty("RepresentanteNumero_N", gxTv_SdtRepresentante_Representantenumero_N, false, includeNonInitialized);
            AddObjectProperty("RepresentanteMunicipioUF_N", gxTv_SdtRepresentante_Representantemunicipiouf_N, false, includeNonInitialized);
            AddObjectProperty("RepresentanteMunicipioNome_N", gxTv_SdtRepresentante_Representantemunicipionome_N, false, includeNonInitialized);
            AddObjectProperty("RepresentanteTipo_N", gxTv_SdtRepresentante_Representantetipo_N, false, includeNonInitialized);
            AddObjectProperty("ClienteId_N", gxTv_SdtRepresentante_Clienteid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtRepresentante sdt )
      {
         if ( sdt.IsDirty("RepresentanteId") )
         {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representanteid = sdt.gxTv_SdtRepresentante_Representanteid ;
         }
         if ( sdt.IsDirty("RepresentanteNome") )
         {
            gxTv_SdtRepresentante_Representantenome_N = (short)(sdt.gxTv_SdtRepresentante_Representantenome_N);
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantenome = sdt.gxTv_SdtRepresentante_Representantenome ;
         }
         if ( sdt.IsDirty("RepresentanteRG") )
         {
            gxTv_SdtRepresentante_Representanterg_N = (short)(sdt.gxTv_SdtRepresentante_Representanterg_N);
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representanterg = sdt.gxTv_SdtRepresentante_Representanterg ;
         }
         if ( sdt.IsDirty("RepresentanteOrgaoExpedidor") )
         {
            gxTv_SdtRepresentante_Representanteorgaoexpedidor_N = (short)(sdt.gxTv_SdtRepresentante_Representanteorgaoexpedidor_N);
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representanteorgaoexpedidor = sdt.gxTv_SdtRepresentante_Representanteorgaoexpedidor ;
         }
         if ( sdt.IsDirty("RepresentanteRGUF") )
         {
            gxTv_SdtRepresentante_Representanterguf_N = (short)(sdt.gxTv_SdtRepresentante_Representanterguf_N);
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representanterguf = sdt.gxTv_SdtRepresentante_Representanterguf ;
         }
         if ( sdt.IsDirty("RepresentanteCPF") )
         {
            gxTv_SdtRepresentante_Representantecpf_N = (short)(sdt.gxTv_SdtRepresentante_Representantecpf_N);
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantecpf = sdt.gxTv_SdtRepresentante_Representantecpf ;
         }
         if ( sdt.IsDirty("RepresentanteEstadoCivil") )
         {
            gxTv_SdtRepresentante_Representanteestadocivil_N = (short)(sdt.gxTv_SdtRepresentante_Representanteestadocivil_N);
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representanteestadocivil = sdt.gxTv_SdtRepresentante_Representanteestadocivil ;
         }
         if ( sdt.IsDirty("RepresentanteNacionalidade") )
         {
            gxTv_SdtRepresentante_Representantenacionalidade_N = (short)(sdt.gxTv_SdtRepresentante_Representantenacionalidade_N);
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantenacionalidade = sdt.gxTv_SdtRepresentante_Representantenacionalidade ;
         }
         if ( sdt.IsDirty("RepresentanteProfissao") )
         {
            gxTv_SdtRepresentante_Representanteprofissao_N = (short)(sdt.gxTv_SdtRepresentante_Representanteprofissao_N);
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representanteprofissao = sdt.gxTv_SdtRepresentante_Representanteprofissao ;
         }
         if ( sdt.IsDirty("RepresentanteProfissaoDescricao") )
         {
            gxTv_SdtRepresentante_Representanteprofissaodescricao_N = (short)(sdt.gxTv_SdtRepresentante_Representanteprofissaodescricao_N);
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representanteprofissaodescricao = sdt.gxTv_SdtRepresentante_Representanteprofissaodescricao ;
         }
         if ( sdt.IsDirty("RepresentanteEmail") )
         {
            gxTv_SdtRepresentante_Representanteemail_N = (short)(sdt.gxTv_SdtRepresentante_Representanteemail_N);
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representanteemail = sdt.gxTv_SdtRepresentante_Representanteemail ;
         }
         if ( sdt.IsDirty("RepresentanteCEP") )
         {
            gxTv_SdtRepresentante_Representantecep_N = (short)(sdt.gxTv_SdtRepresentante_Representantecep_N);
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantecep = sdt.gxTv_SdtRepresentante_Representantecep ;
         }
         if ( sdt.IsDirty("RepresentanteLogradouro") )
         {
            gxTv_SdtRepresentante_Representantelogradouro_N = (short)(sdt.gxTv_SdtRepresentante_Representantelogradouro_N);
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantelogradouro = sdt.gxTv_SdtRepresentante_Representantelogradouro ;
         }
         if ( sdt.IsDirty("RepresentanteBairro") )
         {
            gxTv_SdtRepresentante_Representantebairro_N = (short)(sdt.gxTv_SdtRepresentante_Representantebairro_N);
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantebairro = sdt.gxTv_SdtRepresentante_Representantebairro ;
         }
         if ( sdt.IsDirty("RepresentanteCidade") )
         {
            gxTv_SdtRepresentante_Representantecidade_N = (short)(sdt.gxTv_SdtRepresentante_Representantecidade_N);
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantecidade = sdt.gxTv_SdtRepresentante_Representantecidade ;
         }
         if ( sdt.IsDirty("RepresentanteMunicipio") )
         {
            gxTv_SdtRepresentante_Representantemunicipio_N = (short)(sdt.gxTv_SdtRepresentante_Representantemunicipio_N);
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantemunicipio = sdt.gxTv_SdtRepresentante_Representantemunicipio ;
         }
         if ( sdt.IsDirty("RepresentanteLogradouroNumero") )
         {
            gxTv_SdtRepresentante_Representantelogradouronumero_N = (short)(sdt.gxTv_SdtRepresentante_Representantelogradouronumero_N);
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantelogradouronumero = sdt.gxTv_SdtRepresentante_Representantelogradouronumero ;
         }
         if ( sdt.IsDirty("RepresentanteComplemento") )
         {
            gxTv_SdtRepresentante_Representantecomplemento_N = (short)(sdt.gxTv_SdtRepresentante_Representantecomplemento_N);
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantecomplemento = sdt.gxTv_SdtRepresentante_Representantecomplemento ;
         }
         if ( sdt.IsDirty("RepresentanteDDD") )
         {
            gxTv_SdtRepresentante_Representanteddd_N = (short)(sdt.gxTv_SdtRepresentante_Representanteddd_N);
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representanteddd = sdt.gxTv_SdtRepresentante_Representanteddd ;
         }
         if ( sdt.IsDirty("RepresentanteNumero") )
         {
            gxTv_SdtRepresentante_Representantenumero_N = (short)(sdt.gxTv_SdtRepresentante_Representantenumero_N);
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantenumero = sdt.gxTv_SdtRepresentante_Representantenumero ;
         }
         if ( sdt.IsDirty("RepresentanteMunicipioUF") )
         {
            gxTv_SdtRepresentante_Representantemunicipiouf_N = (short)(sdt.gxTv_SdtRepresentante_Representantemunicipiouf_N);
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantemunicipiouf = sdt.gxTv_SdtRepresentante_Representantemunicipiouf ;
         }
         if ( sdt.IsDirty("RepresentanteMunicipioNome") )
         {
            gxTv_SdtRepresentante_Representantemunicipionome_N = (short)(sdt.gxTv_SdtRepresentante_Representantemunicipionome_N);
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantemunicipionome = sdt.gxTv_SdtRepresentante_Representantemunicipionome ;
         }
         if ( sdt.IsDirty("RepresentanteTipo") )
         {
            gxTv_SdtRepresentante_Representantetipo_N = (short)(sdt.gxTv_SdtRepresentante_Representantetipo_N);
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantetipo = sdt.gxTv_SdtRepresentante_Representantetipo ;
         }
         if ( sdt.IsDirty("ClienteId") )
         {
            gxTv_SdtRepresentante_Clienteid_N = (short)(sdt.gxTv_SdtRepresentante_Clienteid_N);
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Clienteid = sdt.gxTv_SdtRepresentante_Clienteid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "RepresentanteId" )]
      [  XmlElement( ElementName = "RepresentanteId"   )]
      public int gxTpr_Representanteid
      {
         get {
            return gxTv_SdtRepresentante_Representanteid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtRepresentante_Representanteid != value )
            {
               gxTv_SdtRepresentante_Mode = "INS";
               this.gxTv_SdtRepresentante_Representanteid_Z_SetNull( );
               this.gxTv_SdtRepresentante_Representantenome_Z_SetNull( );
               this.gxTv_SdtRepresentante_Representanterg_Z_SetNull( );
               this.gxTv_SdtRepresentante_Representanteorgaoexpedidor_Z_SetNull( );
               this.gxTv_SdtRepresentante_Representanterguf_Z_SetNull( );
               this.gxTv_SdtRepresentante_Representantecpf_Z_SetNull( );
               this.gxTv_SdtRepresentante_Representanteestadocivil_Z_SetNull( );
               this.gxTv_SdtRepresentante_Representantenacionalidade_Z_SetNull( );
               this.gxTv_SdtRepresentante_Representanteprofissao_Z_SetNull( );
               this.gxTv_SdtRepresentante_Representanteprofissaodescricao_Z_SetNull( );
               this.gxTv_SdtRepresentante_Representanteemail_Z_SetNull( );
               this.gxTv_SdtRepresentante_Representantecep_Z_SetNull( );
               this.gxTv_SdtRepresentante_Representantelogradouro_Z_SetNull( );
               this.gxTv_SdtRepresentante_Representantebairro_Z_SetNull( );
               this.gxTv_SdtRepresentante_Representantecidade_Z_SetNull( );
               this.gxTv_SdtRepresentante_Representantemunicipio_Z_SetNull( );
               this.gxTv_SdtRepresentante_Representantelogradouronumero_Z_SetNull( );
               this.gxTv_SdtRepresentante_Representantecomplemento_Z_SetNull( );
               this.gxTv_SdtRepresentante_Representanteddd_Z_SetNull( );
               this.gxTv_SdtRepresentante_Representantenumero_Z_SetNull( );
               this.gxTv_SdtRepresentante_Representantemunicipiouf_Z_SetNull( );
               this.gxTv_SdtRepresentante_Representantemunicipionome_Z_SetNull( );
               this.gxTv_SdtRepresentante_Representantetipo_Z_SetNull( );
               this.gxTv_SdtRepresentante_Clienteid_Z_SetNull( );
            }
            gxTv_SdtRepresentante_Representanteid = value;
            SetDirty("Representanteid");
         }

      }

      [  SoapElement( ElementName = "RepresentanteNome" )]
      [  XmlElement( ElementName = "RepresentanteNome"   )]
      public string gxTpr_Representantenome
      {
         get {
            return gxTv_SdtRepresentante_Representantenome ;
         }

         set {
            gxTv_SdtRepresentante_Representantenome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantenome = value;
            SetDirty("Representantenome");
         }

      }

      public void gxTv_SdtRepresentante_Representantenome_SetNull( )
      {
         gxTv_SdtRepresentante_Representantenome_N = 1;
         gxTv_SdtRepresentante_Representantenome = "";
         SetDirty("Representantenome");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantenome_IsNull( )
      {
         return (gxTv_SdtRepresentante_Representantenome_N==1) ;
      }

      [  SoapElement( ElementName = "RepresentanteRG" )]
      [  XmlElement( ElementName = "RepresentanteRG"   )]
      public string gxTpr_Representanterg
      {
         get {
            return gxTv_SdtRepresentante_Representanterg ;
         }

         set {
            gxTv_SdtRepresentante_Representanterg_N = 0;
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representanterg = value;
            SetDirty("Representanterg");
         }

      }

      public void gxTv_SdtRepresentante_Representanterg_SetNull( )
      {
         gxTv_SdtRepresentante_Representanterg_N = 1;
         gxTv_SdtRepresentante_Representanterg = "";
         SetDirty("Representanterg");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representanterg_IsNull( )
      {
         return (gxTv_SdtRepresentante_Representanterg_N==1) ;
      }

      [  SoapElement( ElementName = "RepresentanteOrgaoExpedidor" )]
      [  XmlElement( ElementName = "RepresentanteOrgaoExpedidor"   )]
      public string gxTpr_Representanteorgaoexpedidor
      {
         get {
            return gxTv_SdtRepresentante_Representanteorgaoexpedidor ;
         }

         set {
            gxTv_SdtRepresentante_Representanteorgaoexpedidor_N = 0;
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representanteorgaoexpedidor = value;
            SetDirty("Representanteorgaoexpedidor");
         }

      }

      public void gxTv_SdtRepresentante_Representanteorgaoexpedidor_SetNull( )
      {
         gxTv_SdtRepresentante_Representanteorgaoexpedidor_N = 1;
         gxTv_SdtRepresentante_Representanteorgaoexpedidor = "";
         SetDirty("Representanteorgaoexpedidor");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representanteorgaoexpedidor_IsNull( )
      {
         return (gxTv_SdtRepresentante_Representanteorgaoexpedidor_N==1) ;
      }

      [  SoapElement( ElementName = "RepresentanteRGUF" )]
      [  XmlElement( ElementName = "RepresentanteRGUF"   )]
      public string gxTpr_Representanterguf
      {
         get {
            return gxTv_SdtRepresentante_Representanterguf ;
         }

         set {
            gxTv_SdtRepresentante_Representanterguf_N = 0;
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representanterguf = value;
            SetDirty("Representanterguf");
         }

      }

      public void gxTv_SdtRepresentante_Representanterguf_SetNull( )
      {
         gxTv_SdtRepresentante_Representanterguf_N = 1;
         gxTv_SdtRepresentante_Representanterguf = "";
         SetDirty("Representanterguf");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representanterguf_IsNull( )
      {
         return (gxTv_SdtRepresentante_Representanterguf_N==1) ;
      }

      [  SoapElement( ElementName = "RepresentanteCPF" )]
      [  XmlElement( ElementName = "RepresentanteCPF"   )]
      public string gxTpr_Representantecpf
      {
         get {
            return gxTv_SdtRepresentante_Representantecpf ;
         }

         set {
            gxTv_SdtRepresentante_Representantecpf_N = 0;
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantecpf = value;
            SetDirty("Representantecpf");
         }

      }

      public void gxTv_SdtRepresentante_Representantecpf_SetNull( )
      {
         gxTv_SdtRepresentante_Representantecpf_N = 1;
         gxTv_SdtRepresentante_Representantecpf = "";
         SetDirty("Representantecpf");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantecpf_IsNull( )
      {
         return (gxTv_SdtRepresentante_Representantecpf_N==1) ;
      }

      [  SoapElement( ElementName = "RepresentanteEstadoCivil" )]
      [  XmlElement( ElementName = "RepresentanteEstadoCivil"   )]
      public string gxTpr_Representanteestadocivil
      {
         get {
            return gxTv_SdtRepresentante_Representanteestadocivil ;
         }

         set {
            gxTv_SdtRepresentante_Representanteestadocivil_N = 0;
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representanteestadocivil = value;
            SetDirty("Representanteestadocivil");
         }

      }

      public void gxTv_SdtRepresentante_Representanteestadocivil_SetNull( )
      {
         gxTv_SdtRepresentante_Representanteestadocivil_N = 1;
         gxTv_SdtRepresentante_Representanteestadocivil = "";
         SetDirty("Representanteestadocivil");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representanteestadocivil_IsNull( )
      {
         return (gxTv_SdtRepresentante_Representanteestadocivil_N==1) ;
      }

      [  SoapElement( ElementName = "RepresentanteNacionalidade" )]
      [  XmlElement( ElementName = "RepresentanteNacionalidade"   )]
      public string gxTpr_Representantenacionalidade
      {
         get {
            return gxTv_SdtRepresentante_Representantenacionalidade ;
         }

         set {
            gxTv_SdtRepresentante_Representantenacionalidade_N = 0;
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantenacionalidade = value;
            SetDirty("Representantenacionalidade");
         }

      }

      public void gxTv_SdtRepresentante_Representantenacionalidade_SetNull( )
      {
         gxTv_SdtRepresentante_Representantenacionalidade_N = 1;
         gxTv_SdtRepresentante_Representantenacionalidade = "";
         SetDirty("Representantenacionalidade");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantenacionalidade_IsNull( )
      {
         return (gxTv_SdtRepresentante_Representantenacionalidade_N==1) ;
      }

      [  SoapElement( ElementName = "RepresentanteProfissao" )]
      [  XmlElement( ElementName = "RepresentanteProfissao"   )]
      public int gxTpr_Representanteprofissao
      {
         get {
            return gxTv_SdtRepresentante_Representanteprofissao ;
         }

         set {
            gxTv_SdtRepresentante_Representanteprofissao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representanteprofissao = value;
            SetDirty("Representanteprofissao");
         }

      }

      public void gxTv_SdtRepresentante_Representanteprofissao_SetNull( )
      {
         gxTv_SdtRepresentante_Representanteprofissao_N = 1;
         gxTv_SdtRepresentante_Representanteprofissao = 0;
         SetDirty("Representanteprofissao");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representanteprofissao_IsNull( )
      {
         return (gxTv_SdtRepresentante_Representanteprofissao_N==1) ;
      }

      [  SoapElement( ElementName = "RepresentanteProfissaoDescricao" )]
      [  XmlElement( ElementName = "RepresentanteProfissaoDescricao"   )]
      public string gxTpr_Representanteprofissaodescricao
      {
         get {
            return gxTv_SdtRepresentante_Representanteprofissaodescricao ;
         }

         set {
            gxTv_SdtRepresentante_Representanteprofissaodescricao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representanteprofissaodescricao = value;
            SetDirty("Representanteprofissaodescricao");
         }

      }

      public void gxTv_SdtRepresentante_Representanteprofissaodescricao_SetNull( )
      {
         gxTv_SdtRepresentante_Representanteprofissaodescricao_N = 1;
         gxTv_SdtRepresentante_Representanteprofissaodescricao = "";
         SetDirty("Representanteprofissaodescricao");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representanteprofissaodescricao_IsNull( )
      {
         return (gxTv_SdtRepresentante_Representanteprofissaodescricao_N==1) ;
      }

      [  SoapElement( ElementName = "RepresentanteEmail" )]
      [  XmlElement( ElementName = "RepresentanteEmail"   )]
      public string gxTpr_Representanteemail
      {
         get {
            return gxTv_SdtRepresentante_Representanteemail ;
         }

         set {
            gxTv_SdtRepresentante_Representanteemail_N = 0;
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representanteemail = value;
            SetDirty("Representanteemail");
         }

      }

      public void gxTv_SdtRepresentante_Representanteemail_SetNull( )
      {
         gxTv_SdtRepresentante_Representanteemail_N = 1;
         gxTv_SdtRepresentante_Representanteemail = "";
         SetDirty("Representanteemail");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representanteemail_IsNull( )
      {
         return (gxTv_SdtRepresentante_Representanteemail_N==1) ;
      }

      [  SoapElement( ElementName = "RepresentanteCEP" )]
      [  XmlElement( ElementName = "RepresentanteCEP"   )]
      public string gxTpr_Representantecep
      {
         get {
            return gxTv_SdtRepresentante_Representantecep ;
         }

         set {
            gxTv_SdtRepresentante_Representantecep_N = 0;
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantecep = value;
            SetDirty("Representantecep");
         }

      }

      public void gxTv_SdtRepresentante_Representantecep_SetNull( )
      {
         gxTv_SdtRepresentante_Representantecep_N = 1;
         gxTv_SdtRepresentante_Representantecep = "";
         SetDirty("Representantecep");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantecep_IsNull( )
      {
         return (gxTv_SdtRepresentante_Representantecep_N==1) ;
      }

      [  SoapElement( ElementName = "RepresentanteLogradouro" )]
      [  XmlElement( ElementName = "RepresentanteLogradouro"   )]
      public string gxTpr_Representantelogradouro
      {
         get {
            return gxTv_SdtRepresentante_Representantelogradouro ;
         }

         set {
            gxTv_SdtRepresentante_Representantelogradouro_N = 0;
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantelogradouro = value;
            SetDirty("Representantelogradouro");
         }

      }

      public void gxTv_SdtRepresentante_Representantelogradouro_SetNull( )
      {
         gxTv_SdtRepresentante_Representantelogradouro_N = 1;
         gxTv_SdtRepresentante_Representantelogradouro = "";
         SetDirty("Representantelogradouro");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantelogradouro_IsNull( )
      {
         return (gxTv_SdtRepresentante_Representantelogradouro_N==1) ;
      }

      [  SoapElement( ElementName = "RepresentanteBairro" )]
      [  XmlElement( ElementName = "RepresentanteBairro"   )]
      public string gxTpr_Representantebairro
      {
         get {
            return gxTv_SdtRepresentante_Representantebairro ;
         }

         set {
            gxTv_SdtRepresentante_Representantebairro_N = 0;
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantebairro = value;
            SetDirty("Representantebairro");
         }

      }

      public void gxTv_SdtRepresentante_Representantebairro_SetNull( )
      {
         gxTv_SdtRepresentante_Representantebairro_N = 1;
         gxTv_SdtRepresentante_Representantebairro = "";
         SetDirty("Representantebairro");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantebairro_IsNull( )
      {
         return (gxTv_SdtRepresentante_Representantebairro_N==1) ;
      }

      [  SoapElement( ElementName = "RepresentanteCidade" )]
      [  XmlElement( ElementName = "RepresentanteCidade"   )]
      public string gxTpr_Representantecidade
      {
         get {
            return gxTv_SdtRepresentante_Representantecidade ;
         }

         set {
            gxTv_SdtRepresentante_Representantecidade_N = 0;
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantecidade = value;
            SetDirty("Representantecidade");
         }

      }

      public void gxTv_SdtRepresentante_Representantecidade_SetNull( )
      {
         gxTv_SdtRepresentante_Representantecidade_N = 1;
         gxTv_SdtRepresentante_Representantecidade = "";
         SetDirty("Representantecidade");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantecidade_IsNull( )
      {
         return (gxTv_SdtRepresentante_Representantecidade_N==1) ;
      }

      [  SoapElement( ElementName = "RepresentanteMunicipio" )]
      [  XmlElement( ElementName = "RepresentanteMunicipio"   )]
      public string gxTpr_Representantemunicipio
      {
         get {
            return gxTv_SdtRepresentante_Representantemunicipio ;
         }

         set {
            gxTv_SdtRepresentante_Representantemunicipio_N = 0;
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantemunicipio = value;
            SetDirty("Representantemunicipio");
         }

      }

      public void gxTv_SdtRepresentante_Representantemunicipio_SetNull( )
      {
         gxTv_SdtRepresentante_Representantemunicipio_N = 1;
         gxTv_SdtRepresentante_Representantemunicipio = "";
         SetDirty("Representantemunicipio");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantemunicipio_IsNull( )
      {
         return (gxTv_SdtRepresentante_Representantemunicipio_N==1) ;
      }

      [  SoapElement( ElementName = "RepresentanteLogradouroNumero" )]
      [  XmlElement( ElementName = "RepresentanteLogradouroNumero"   )]
      public long gxTpr_Representantelogradouronumero
      {
         get {
            return gxTv_SdtRepresentante_Representantelogradouronumero ;
         }

         set {
            gxTv_SdtRepresentante_Representantelogradouronumero_N = 0;
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantelogradouronumero = value;
            SetDirty("Representantelogradouronumero");
         }

      }

      public void gxTv_SdtRepresentante_Representantelogradouronumero_SetNull( )
      {
         gxTv_SdtRepresentante_Representantelogradouronumero_N = 1;
         gxTv_SdtRepresentante_Representantelogradouronumero = 0;
         SetDirty("Representantelogradouronumero");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantelogradouronumero_IsNull( )
      {
         return (gxTv_SdtRepresentante_Representantelogradouronumero_N==1) ;
      }

      [  SoapElement( ElementName = "RepresentanteComplemento" )]
      [  XmlElement( ElementName = "RepresentanteComplemento"   )]
      public string gxTpr_Representantecomplemento
      {
         get {
            return gxTv_SdtRepresentante_Representantecomplemento ;
         }

         set {
            gxTv_SdtRepresentante_Representantecomplemento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantecomplemento = value;
            SetDirty("Representantecomplemento");
         }

      }

      public void gxTv_SdtRepresentante_Representantecomplemento_SetNull( )
      {
         gxTv_SdtRepresentante_Representantecomplemento_N = 1;
         gxTv_SdtRepresentante_Representantecomplemento = "";
         SetDirty("Representantecomplemento");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantecomplemento_IsNull( )
      {
         return (gxTv_SdtRepresentante_Representantecomplemento_N==1) ;
      }

      [  SoapElement( ElementName = "RepresentanteDDD" )]
      [  XmlElement( ElementName = "RepresentanteDDD"   )]
      public short gxTpr_Representanteddd
      {
         get {
            return gxTv_SdtRepresentante_Representanteddd ;
         }

         set {
            gxTv_SdtRepresentante_Representanteddd_N = 0;
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representanteddd = value;
            SetDirty("Representanteddd");
         }

      }

      public void gxTv_SdtRepresentante_Representanteddd_SetNull( )
      {
         gxTv_SdtRepresentante_Representanteddd_N = 1;
         gxTv_SdtRepresentante_Representanteddd = 0;
         SetDirty("Representanteddd");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representanteddd_IsNull( )
      {
         return (gxTv_SdtRepresentante_Representanteddd_N==1) ;
      }

      [  SoapElement( ElementName = "RepresentanteNumero" )]
      [  XmlElement( ElementName = "RepresentanteNumero"   )]
      public int gxTpr_Representantenumero
      {
         get {
            return gxTv_SdtRepresentante_Representantenumero ;
         }

         set {
            gxTv_SdtRepresentante_Representantenumero_N = 0;
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantenumero = value;
            SetDirty("Representantenumero");
         }

      }

      public void gxTv_SdtRepresentante_Representantenumero_SetNull( )
      {
         gxTv_SdtRepresentante_Representantenumero_N = 1;
         gxTv_SdtRepresentante_Representantenumero = 0;
         SetDirty("Representantenumero");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantenumero_IsNull( )
      {
         return (gxTv_SdtRepresentante_Representantenumero_N==1) ;
      }

      [  SoapElement( ElementName = "RepresentanteMunicipioUF" )]
      [  XmlElement( ElementName = "RepresentanteMunicipioUF"   )]
      public string gxTpr_Representantemunicipiouf
      {
         get {
            return gxTv_SdtRepresentante_Representantemunicipiouf ;
         }

         set {
            gxTv_SdtRepresentante_Representantemunicipiouf_N = 0;
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantemunicipiouf = value;
            SetDirty("Representantemunicipiouf");
         }

      }

      public void gxTv_SdtRepresentante_Representantemunicipiouf_SetNull( )
      {
         gxTv_SdtRepresentante_Representantemunicipiouf_N = 1;
         gxTv_SdtRepresentante_Representantemunicipiouf = "";
         SetDirty("Representantemunicipiouf");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantemunicipiouf_IsNull( )
      {
         return (gxTv_SdtRepresentante_Representantemunicipiouf_N==1) ;
      }

      [  SoapElement( ElementName = "RepresentanteMunicipioNome" )]
      [  XmlElement( ElementName = "RepresentanteMunicipioNome"   )]
      public string gxTpr_Representantemunicipionome
      {
         get {
            return gxTv_SdtRepresentante_Representantemunicipionome ;
         }

         set {
            gxTv_SdtRepresentante_Representantemunicipionome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantemunicipionome = value;
            SetDirty("Representantemunicipionome");
         }

      }

      public void gxTv_SdtRepresentante_Representantemunicipionome_SetNull( )
      {
         gxTv_SdtRepresentante_Representantemunicipionome_N = 1;
         gxTv_SdtRepresentante_Representantemunicipionome = "";
         SetDirty("Representantemunicipionome");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantemunicipionome_IsNull( )
      {
         return (gxTv_SdtRepresentante_Representantemunicipionome_N==1) ;
      }

      [  SoapElement( ElementName = "RepresentanteTipo" )]
      [  XmlElement( ElementName = "RepresentanteTipo"   )]
      public string gxTpr_Representantetipo
      {
         get {
            return gxTv_SdtRepresentante_Representantetipo ;
         }

         set {
            gxTv_SdtRepresentante_Representantetipo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantetipo = value;
            SetDirty("Representantetipo");
         }

      }

      public void gxTv_SdtRepresentante_Representantetipo_SetNull( )
      {
         gxTv_SdtRepresentante_Representantetipo_N = 1;
         gxTv_SdtRepresentante_Representantetipo = "";
         SetDirty("Representantetipo");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantetipo_IsNull( )
      {
         return (gxTv_SdtRepresentante_Representantetipo_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteId" )]
      [  XmlElement( ElementName = "ClienteId"   )]
      public int gxTpr_Clienteid
      {
         get {
            return gxTv_SdtRepresentante_Clienteid ;
         }

         set {
            gxTv_SdtRepresentante_Clienteid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Clienteid = value;
            SetDirty("Clienteid");
         }

      }

      public void gxTv_SdtRepresentante_Clienteid_SetNull( )
      {
         gxTv_SdtRepresentante_Clienteid_N = 1;
         gxTv_SdtRepresentante_Clienteid = 0;
         SetDirty("Clienteid");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Clienteid_IsNull( )
      {
         return (gxTv_SdtRepresentante_Clienteid_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtRepresentante_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtRepresentante_Mode_SetNull( )
      {
         gxTv_SdtRepresentante_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtRepresentante_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtRepresentante_Initialized_SetNull( )
      {
         gxTv_SdtRepresentante_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteId_Z" )]
      [  XmlElement( ElementName = "RepresentanteId_Z"   )]
      public int gxTpr_Representanteid_Z
      {
         get {
            return gxTv_SdtRepresentante_Representanteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representanteid_Z = value;
            SetDirty("Representanteid_Z");
         }

      }

      public void gxTv_SdtRepresentante_Representanteid_Z_SetNull( )
      {
         gxTv_SdtRepresentante_Representanteid_Z = 0;
         SetDirty("Representanteid_Z");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representanteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteNome_Z" )]
      [  XmlElement( ElementName = "RepresentanteNome_Z"   )]
      public string gxTpr_Representantenome_Z
      {
         get {
            return gxTv_SdtRepresentante_Representantenome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantenome_Z = value;
            SetDirty("Representantenome_Z");
         }

      }

      public void gxTv_SdtRepresentante_Representantenome_Z_SetNull( )
      {
         gxTv_SdtRepresentante_Representantenome_Z = "";
         SetDirty("Representantenome_Z");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantenome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteRG_Z" )]
      [  XmlElement( ElementName = "RepresentanteRG_Z"   )]
      public string gxTpr_Representanterg_Z
      {
         get {
            return gxTv_SdtRepresentante_Representanterg_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representanterg_Z = value;
            SetDirty("Representanterg_Z");
         }

      }

      public void gxTv_SdtRepresentante_Representanterg_Z_SetNull( )
      {
         gxTv_SdtRepresentante_Representanterg_Z = "";
         SetDirty("Representanterg_Z");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representanterg_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteOrgaoExpedidor_Z" )]
      [  XmlElement( ElementName = "RepresentanteOrgaoExpedidor_Z"   )]
      public string gxTpr_Representanteorgaoexpedidor_Z
      {
         get {
            return gxTv_SdtRepresentante_Representanteorgaoexpedidor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representanteorgaoexpedidor_Z = value;
            SetDirty("Representanteorgaoexpedidor_Z");
         }

      }

      public void gxTv_SdtRepresentante_Representanteorgaoexpedidor_Z_SetNull( )
      {
         gxTv_SdtRepresentante_Representanteorgaoexpedidor_Z = "";
         SetDirty("Representanteorgaoexpedidor_Z");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representanteorgaoexpedidor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteRGUF_Z" )]
      [  XmlElement( ElementName = "RepresentanteRGUF_Z"   )]
      public string gxTpr_Representanterguf_Z
      {
         get {
            return gxTv_SdtRepresentante_Representanterguf_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representanterguf_Z = value;
            SetDirty("Representanterguf_Z");
         }

      }

      public void gxTv_SdtRepresentante_Representanterguf_Z_SetNull( )
      {
         gxTv_SdtRepresentante_Representanterguf_Z = "";
         SetDirty("Representanterguf_Z");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representanterguf_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteCPF_Z" )]
      [  XmlElement( ElementName = "RepresentanteCPF_Z"   )]
      public string gxTpr_Representantecpf_Z
      {
         get {
            return gxTv_SdtRepresentante_Representantecpf_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantecpf_Z = value;
            SetDirty("Representantecpf_Z");
         }

      }

      public void gxTv_SdtRepresentante_Representantecpf_Z_SetNull( )
      {
         gxTv_SdtRepresentante_Representantecpf_Z = "";
         SetDirty("Representantecpf_Z");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantecpf_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteEstadoCivil_Z" )]
      [  XmlElement( ElementName = "RepresentanteEstadoCivil_Z"   )]
      public string gxTpr_Representanteestadocivil_Z
      {
         get {
            return gxTv_SdtRepresentante_Representanteestadocivil_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representanteestadocivil_Z = value;
            SetDirty("Representanteestadocivil_Z");
         }

      }

      public void gxTv_SdtRepresentante_Representanteestadocivil_Z_SetNull( )
      {
         gxTv_SdtRepresentante_Representanteestadocivil_Z = "";
         SetDirty("Representanteestadocivil_Z");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representanteestadocivil_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteNacionalidade_Z" )]
      [  XmlElement( ElementName = "RepresentanteNacionalidade_Z"   )]
      public string gxTpr_Representantenacionalidade_Z
      {
         get {
            return gxTv_SdtRepresentante_Representantenacionalidade_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantenacionalidade_Z = value;
            SetDirty("Representantenacionalidade_Z");
         }

      }

      public void gxTv_SdtRepresentante_Representantenacionalidade_Z_SetNull( )
      {
         gxTv_SdtRepresentante_Representantenacionalidade_Z = "";
         SetDirty("Representantenacionalidade_Z");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantenacionalidade_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteProfissao_Z" )]
      [  XmlElement( ElementName = "RepresentanteProfissao_Z"   )]
      public int gxTpr_Representanteprofissao_Z
      {
         get {
            return gxTv_SdtRepresentante_Representanteprofissao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representanteprofissao_Z = value;
            SetDirty("Representanteprofissao_Z");
         }

      }

      public void gxTv_SdtRepresentante_Representanteprofissao_Z_SetNull( )
      {
         gxTv_SdtRepresentante_Representanteprofissao_Z = 0;
         SetDirty("Representanteprofissao_Z");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representanteprofissao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteProfissaoDescricao_Z" )]
      [  XmlElement( ElementName = "RepresentanteProfissaoDescricao_Z"   )]
      public string gxTpr_Representanteprofissaodescricao_Z
      {
         get {
            return gxTv_SdtRepresentante_Representanteprofissaodescricao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representanteprofissaodescricao_Z = value;
            SetDirty("Representanteprofissaodescricao_Z");
         }

      }

      public void gxTv_SdtRepresentante_Representanteprofissaodescricao_Z_SetNull( )
      {
         gxTv_SdtRepresentante_Representanteprofissaodescricao_Z = "";
         SetDirty("Representanteprofissaodescricao_Z");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representanteprofissaodescricao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteEmail_Z" )]
      [  XmlElement( ElementName = "RepresentanteEmail_Z"   )]
      public string gxTpr_Representanteemail_Z
      {
         get {
            return gxTv_SdtRepresentante_Representanteemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representanteemail_Z = value;
            SetDirty("Representanteemail_Z");
         }

      }

      public void gxTv_SdtRepresentante_Representanteemail_Z_SetNull( )
      {
         gxTv_SdtRepresentante_Representanteemail_Z = "";
         SetDirty("Representanteemail_Z");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representanteemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteCEP_Z" )]
      [  XmlElement( ElementName = "RepresentanteCEP_Z"   )]
      public string gxTpr_Representantecep_Z
      {
         get {
            return gxTv_SdtRepresentante_Representantecep_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantecep_Z = value;
            SetDirty("Representantecep_Z");
         }

      }

      public void gxTv_SdtRepresentante_Representantecep_Z_SetNull( )
      {
         gxTv_SdtRepresentante_Representantecep_Z = "";
         SetDirty("Representantecep_Z");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantecep_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteLogradouro_Z" )]
      [  XmlElement( ElementName = "RepresentanteLogradouro_Z"   )]
      public string gxTpr_Representantelogradouro_Z
      {
         get {
            return gxTv_SdtRepresentante_Representantelogradouro_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantelogradouro_Z = value;
            SetDirty("Representantelogradouro_Z");
         }

      }

      public void gxTv_SdtRepresentante_Representantelogradouro_Z_SetNull( )
      {
         gxTv_SdtRepresentante_Representantelogradouro_Z = "";
         SetDirty("Representantelogradouro_Z");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantelogradouro_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteBairro_Z" )]
      [  XmlElement( ElementName = "RepresentanteBairro_Z"   )]
      public string gxTpr_Representantebairro_Z
      {
         get {
            return gxTv_SdtRepresentante_Representantebairro_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantebairro_Z = value;
            SetDirty("Representantebairro_Z");
         }

      }

      public void gxTv_SdtRepresentante_Representantebairro_Z_SetNull( )
      {
         gxTv_SdtRepresentante_Representantebairro_Z = "";
         SetDirty("Representantebairro_Z");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantebairro_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteCidade_Z" )]
      [  XmlElement( ElementName = "RepresentanteCidade_Z"   )]
      public string gxTpr_Representantecidade_Z
      {
         get {
            return gxTv_SdtRepresentante_Representantecidade_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantecidade_Z = value;
            SetDirty("Representantecidade_Z");
         }

      }

      public void gxTv_SdtRepresentante_Representantecidade_Z_SetNull( )
      {
         gxTv_SdtRepresentante_Representantecidade_Z = "";
         SetDirty("Representantecidade_Z");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantecidade_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteMunicipio_Z" )]
      [  XmlElement( ElementName = "RepresentanteMunicipio_Z"   )]
      public string gxTpr_Representantemunicipio_Z
      {
         get {
            return gxTv_SdtRepresentante_Representantemunicipio_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantemunicipio_Z = value;
            SetDirty("Representantemunicipio_Z");
         }

      }

      public void gxTv_SdtRepresentante_Representantemunicipio_Z_SetNull( )
      {
         gxTv_SdtRepresentante_Representantemunicipio_Z = "";
         SetDirty("Representantemunicipio_Z");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantemunicipio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteLogradouroNumero_Z" )]
      [  XmlElement( ElementName = "RepresentanteLogradouroNumero_Z"   )]
      public long gxTpr_Representantelogradouronumero_Z
      {
         get {
            return gxTv_SdtRepresentante_Representantelogradouronumero_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantelogradouronumero_Z = value;
            SetDirty("Representantelogradouronumero_Z");
         }

      }

      public void gxTv_SdtRepresentante_Representantelogradouronumero_Z_SetNull( )
      {
         gxTv_SdtRepresentante_Representantelogradouronumero_Z = 0;
         SetDirty("Representantelogradouronumero_Z");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantelogradouronumero_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteComplemento_Z" )]
      [  XmlElement( ElementName = "RepresentanteComplemento_Z"   )]
      public string gxTpr_Representantecomplemento_Z
      {
         get {
            return gxTv_SdtRepresentante_Representantecomplemento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantecomplemento_Z = value;
            SetDirty("Representantecomplemento_Z");
         }

      }

      public void gxTv_SdtRepresentante_Representantecomplemento_Z_SetNull( )
      {
         gxTv_SdtRepresentante_Representantecomplemento_Z = "";
         SetDirty("Representantecomplemento_Z");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantecomplemento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteDDD_Z" )]
      [  XmlElement( ElementName = "RepresentanteDDD_Z"   )]
      public short gxTpr_Representanteddd_Z
      {
         get {
            return gxTv_SdtRepresentante_Representanteddd_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representanteddd_Z = value;
            SetDirty("Representanteddd_Z");
         }

      }

      public void gxTv_SdtRepresentante_Representanteddd_Z_SetNull( )
      {
         gxTv_SdtRepresentante_Representanteddd_Z = 0;
         SetDirty("Representanteddd_Z");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representanteddd_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteNumero_Z" )]
      [  XmlElement( ElementName = "RepresentanteNumero_Z"   )]
      public int gxTpr_Representantenumero_Z
      {
         get {
            return gxTv_SdtRepresentante_Representantenumero_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantenumero_Z = value;
            SetDirty("Representantenumero_Z");
         }

      }

      public void gxTv_SdtRepresentante_Representantenumero_Z_SetNull( )
      {
         gxTv_SdtRepresentante_Representantenumero_Z = 0;
         SetDirty("Representantenumero_Z");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantenumero_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteMunicipioUF_Z" )]
      [  XmlElement( ElementName = "RepresentanteMunicipioUF_Z"   )]
      public string gxTpr_Representantemunicipiouf_Z
      {
         get {
            return gxTv_SdtRepresentante_Representantemunicipiouf_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantemunicipiouf_Z = value;
            SetDirty("Representantemunicipiouf_Z");
         }

      }

      public void gxTv_SdtRepresentante_Representantemunicipiouf_Z_SetNull( )
      {
         gxTv_SdtRepresentante_Representantemunicipiouf_Z = "";
         SetDirty("Representantemunicipiouf_Z");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantemunicipiouf_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteMunicipioNome_Z" )]
      [  XmlElement( ElementName = "RepresentanteMunicipioNome_Z"   )]
      public string gxTpr_Representantemunicipionome_Z
      {
         get {
            return gxTv_SdtRepresentante_Representantemunicipionome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantemunicipionome_Z = value;
            SetDirty("Representantemunicipionome_Z");
         }

      }

      public void gxTv_SdtRepresentante_Representantemunicipionome_Z_SetNull( )
      {
         gxTv_SdtRepresentante_Representantemunicipionome_Z = "";
         SetDirty("Representantemunicipionome_Z");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantemunicipionome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteTipo_Z" )]
      [  XmlElement( ElementName = "RepresentanteTipo_Z"   )]
      public string gxTpr_Representantetipo_Z
      {
         get {
            return gxTv_SdtRepresentante_Representantetipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantetipo_Z = value;
            SetDirty("Representantetipo_Z");
         }

      }

      public void gxTv_SdtRepresentante_Representantetipo_Z_SetNull( )
      {
         gxTv_SdtRepresentante_Representantetipo_Z = "";
         SetDirty("Representantetipo_Z");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantetipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteId_Z" )]
      [  XmlElement( ElementName = "ClienteId_Z"   )]
      public int gxTpr_Clienteid_Z
      {
         get {
            return gxTv_SdtRepresentante_Clienteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Clienteid_Z = value;
            SetDirty("Clienteid_Z");
         }

      }

      public void gxTv_SdtRepresentante_Clienteid_Z_SetNull( )
      {
         gxTv_SdtRepresentante_Clienteid_Z = 0;
         SetDirty("Clienteid_Z");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Clienteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteNome_N" )]
      [  XmlElement( ElementName = "RepresentanteNome_N"   )]
      public short gxTpr_Representantenome_N
      {
         get {
            return gxTv_SdtRepresentante_Representantenome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantenome_N = value;
            SetDirty("Representantenome_N");
         }

      }

      public void gxTv_SdtRepresentante_Representantenome_N_SetNull( )
      {
         gxTv_SdtRepresentante_Representantenome_N = 0;
         SetDirty("Representantenome_N");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantenome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteRG_N" )]
      [  XmlElement( ElementName = "RepresentanteRG_N"   )]
      public short gxTpr_Representanterg_N
      {
         get {
            return gxTv_SdtRepresentante_Representanterg_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representanterg_N = value;
            SetDirty("Representanterg_N");
         }

      }

      public void gxTv_SdtRepresentante_Representanterg_N_SetNull( )
      {
         gxTv_SdtRepresentante_Representanterg_N = 0;
         SetDirty("Representanterg_N");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representanterg_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteOrgaoExpedidor_N" )]
      [  XmlElement( ElementName = "RepresentanteOrgaoExpedidor_N"   )]
      public short gxTpr_Representanteorgaoexpedidor_N
      {
         get {
            return gxTv_SdtRepresentante_Representanteorgaoexpedidor_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representanteorgaoexpedidor_N = value;
            SetDirty("Representanteorgaoexpedidor_N");
         }

      }

      public void gxTv_SdtRepresentante_Representanteorgaoexpedidor_N_SetNull( )
      {
         gxTv_SdtRepresentante_Representanteorgaoexpedidor_N = 0;
         SetDirty("Representanteorgaoexpedidor_N");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representanteorgaoexpedidor_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteRGUF_N" )]
      [  XmlElement( ElementName = "RepresentanteRGUF_N"   )]
      public short gxTpr_Representanterguf_N
      {
         get {
            return gxTv_SdtRepresentante_Representanterguf_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representanterguf_N = value;
            SetDirty("Representanterguf_N");
         }

      }

      public void gxTv_SdtRepresentante_Representanterguf_N_SetNull( )
      {
         gxTv_SdtRepresentante_Representanterguf_N = 0;
         SetDirty("Representanterguf_N");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representanterguf_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteCPF_N" )]
      [  XmlElement( ElementName = "RepresentanteCPF_N"   )]
      public short gxTpr_Representantecpf_N
      {
         get {
            return gxTv_SdtRepresentante_Representantecpf_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantecpf_N = value;
            SetDirty("Representantecpf_N");
         }

      }

      public void gxTv_SdtRepresentante_Representantecpf_N_SetNull( )
      {
         gxTv_SdtRepresentante_Representantecpf_N = 0;
         SetDirty("Representantecpf_N");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantecpf_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteEstadoCivil_N" )]
      [  XmlElement( ElementName = "RepresentanteEstadoCivil_N"   )]
      public short gxTpr_Representanteestadocivil_N
      {
         get {
            return gxTv_SdtRepresentante_Representanteestadocivil_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representanteestadocivil_N = value;
            SetDirty("Representanteestadocivil_N");
         }

      }

      public void gxTv_SdtRepresentante_Representanteestadocivil_N_SetNull( )
      {
         gxTv_SdtRepresentante_Representanteestadocivil_N = 0;
         SetDirty("Representanteestadocivil_N");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representanteestadocivil_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteNacionalidade_N" )]
      [  XmlElement( ElementName = "RepresentanteNacionalidade_N"   )]
      public short gxTpr_Representantenacionalidade_N
      {
         get {
            return gxTv_SdtRepresentante_Representantenacionalidade_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantenacionalidade_N = value;
            SetDirty("Representantenacionalidade_N");
         }

      }

      public void gxTv_SdtRepresentante_Representantenacionalidade_N_SetNull( )
      {
         gxTv_SdtRepresentante_Representantenacionalidade_N = 0;
         SetDirty("Representantenacionalidade_N");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantenacionalidade_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteProfissao_N" )]
      [  XmlElement( ElementName = "RepresentanteProfissao_N"   )]
      public short gxTpr_Representanteprofissao_N
      {
         get {
            return gxTv_SdtRepresentante_Representanteprofissao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representanteprofissao_N = value;
            SetDirty("Representanteprofissao_N");
         }

      }

      public void gxTv_SdtRepresentante_Representanteprofissao_N_SetNull( )
      {
         gxTv_SdtRepresentante_Representanteprofissao_N = 0;
         SetDirty("Representanteprofissao_N");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representanteprofissao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteProfissaoDescricao_N" )]
      [  XmlElement( ElementName = "RepresentanteProfissaoDescricao_N"   )]
      public short gxTpr_Representanteprofissaodescricao_N
      {
         get {
            return gxTv_SdtRepresentante_Representanteprofissaodescricao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representanteprofissaodescricao_N = value;
            SetDirty("Representanteprofissaodescricao_N");
         }

      }

      public void gxTv_SdtRepresentante_Representanteprofissaodescricao_N_SetNull( )
      {
         gxTv_SdtRepresentante_Representanteprofissaodescricao_N = 0;
         SetDirty("Representanteprofissaodescricao_N");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representanteprofissaodescricao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteEmail_N" )]
      [  XmlElement( ElementName = "RepresentanteEmail_N"   )]
      public short gxTpr_Representanteemail_N
      {
         get {
            return gxTv_SdtRepresentante_Representanteemail_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representanteemail_N = value;
            SetDirty("Representanteemail_N");
         }

      }

      public void gxTv_SdtRepresentante_Representanteemail_N_SetNull( )
      {
         gxTv_SdtRepresentante_Representanteemail_N = 0;
         SetDirty("Representanteemail_N");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representanteemail_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteCEP_N" )]
      [  XmlElement( ElementName = "RepresentanteCEP_N"   )]
      public short gxTpr_Representantecep_N
      {
         get {
            return gxTv_SdtRepresentante_Representantecep_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantecep_N = value;
            SetDirty("Representantecep_N");
         }

      }

      public void gxTv_SdtRepresentante_Representantecep_N_SetNull( )
      {
         gxTv_SdtRepresentante_Representantecep_N = 0;
         SetDirty("Representantecep_N");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantecep_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteLogradouro_N" )]
      [  XmlElement( ElementName = "RepresentanteLogradouro_N"   )]
      public short gxTpr_Representantelogradouro_N
      {
         get {
            return gxTv_SdtRepresentante_Representantelogradouro_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantelogradouro_N = value;
            SetDirty("Representantelogradouro_N");
         }

      }

      public void gxTv_SdtRepresentante_Representantelogradouro_N_SetNull( )
      {
         gxTv_SdtRepresentante_Representantelogradouro_N = 0;
         SetDirty("Representantelogradouro_N");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantelogradouro_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteBairro_N" )]
      [  XmlElement( ElementName = "RepresentanteBairro_N"   )]
      public short gxTpr_Representantebairro_N
      {
         get {
            return gxTv_SdtRepresentante_Representantebairro_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantebairro_N = value;
            SetDirty("Representantebairro_N");
         }

      }

      public void gxTv_SdtRepresentante_Representantebairro_N_SetNull( )
      {
         gxTv_SdtRepresentante_Representantebairro_N = 0;
         SetDirty("Representantebairro_N");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantebairro_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteCidade_N" )]
      [  XmlElement( ElementName = "RepresentanteCidade_N"   )]
      public short gxTpr_Representantecidade_N
      {
         get {
            return gxTv_SdtRepresentante_Representantecidade_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantecidade_N = value;
            SetDirty("Representantecidade_N");
         }

      }

      public void gxTv_SdtRepresentante_Representantecidade_N_SetNull( )
      {
         gxTv_SdtRepresentante_Representantecidade_N = 0;
         SetDirty("Representantecidade_N");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantecidade_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteMunicipio_N" )]
      [  XmlElement( ElementName = "RepresentanteMunicipio_N"   )]
      public short gxTpr_Representantemunicipio_N
      {
         get {
            return gxTv_SdtRepresentante_Representantemunicipio_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantemunicipio_N = value;
            SetDirty("Representantemunicipio_N");
         }

      }

      public void gxTv_SdtRepresentante_Representantemunicipio_N_SetNull( )
      {
         gxTv_SdtRepresentante_Representantemunicipio_N = 0;
         SetDirty("Representantemunicipio_N");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantemunicipio_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteLogradouroNumero_N" )]
      [  XmlElement( ElementName = "RepresentanteLogradouroNumero_N"   )]
      public short gxTpr_Representantelogradouronumero_N
      {
         get {
            return gxTv_SdtRepresentante_Representantelogradouronumero_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantelogradouronumero_N = value;
            SetDirty("Representantelogradouronumero_N");
         }

      }

      public void gxTv_SdtRepresentante_Representantelogradouronumero_N_SetNull( )
      {
         gxTv_SdtRepresentante_Representantelogradouronumero_N = 0;
         SetDirty("Representantelogradouronumero_N");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantelogradouronumero_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteComplemento_N" )]
      [  XmlElement( ElementName = "RepresentanteComplemento_N"   )]
      public short gxTpr_Representantecomplemento_N
      {
         get {
            return gxTv_SdtRepresentante_Representantecomplemento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantecomplemento_N = value;
            SetDirty("Representantecomplemento_N");
         }

      }

      public void gxTv_SdtRepresentante_Representantecomplemento_N_SetNull( )
      {
         gxTv_SdtRepresentante_Representantecomplemento_N = 0;
         SetDirty("Representantecomplemento_N");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantecomplemento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteDDD_N" )]
      [  XmlElement( ElementName = "RepresentanteDDD_N"   )]
      public short gxTpr_Representanteddd_N
      {
         get {
            return gxTv_SdtRepresentante_Representanteddd_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representanteddd_N = value;
            SetDirty("Representanteddd_N");
         }

      }

      public void gxTv_SdtRepresentante_Representanteddd_N_SetNull( )
      {
         gxTv_SdtRepresentante_Representanteddd_N = 0;
         SetDirty("Representanteddd_N");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representanteddd_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteNumero_N" )]
      [  XmlElement( ElementName = "RepresentanteNumero_N"   )]
      public short gxTpr_Representantenumero_N
      {
         get {
            return gxTv_SdtRepresentante_Representantenumero_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantenumero_N = value;
            SetDirty("Representantenumero_N");
         }

      }

      public void gxTv_SdtRepresentante_Representantenumero_N_SetNull( )
      {
         gxTv_SdtRepresentante_Representantenumero_N = 0;
         SetDirty("Representantenumero_N");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantenumero_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteMunicipioUF_N" )]
      [  XmlElement( ElementName = "RepresentanteMunicipioUF_N"   )]
      public short gxTpr_Representantemunicipiouf_N
      {
         get {
            return gxTv_SdtRepresentante_Representantemunicipiouf_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantemunicipiouf_N = value;
            SetDirty("Representantemunicipiouf_N");
         }

      }

      public void gxTv_SdtRepresentante_Representantemunicipiouf_N_SetNull( )
      {
         gxTv_SdtRepresentante_Representantemunicipiouf_N = 0;
         SetDirty("Representantemunicipiouf_N");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantemunicipiouf_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteMunicipioNome_N" )]
      [  XmlElement( ElementName = "RepresentanteMunicipioNome_N"   )]
      public short gxTpr_Representantemunicipionome_N
      {
         get {
            return gxTv_SdtRepresentante_Representantemunicipionome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantemunicipionome_N = value;
            SetDirty("Representantemunicipionome_N");
         }

      }

      public void gxTv_SdtRepresentante_Representantemunicipionome_N_SetNull( )
      {
         gxTv_SdtRepresentante_Representantemunicipionome_N = 0;
         SetDirty("Representantemunicipionome_N");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantemunicipionome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepresentanteTipo_N" )]
      [  XmlElement( ElementName = "RepresentanteTipo_N"   )]
      public short gxTpr_Representantetipo_N
      {
         get {
            return gxTv_SdtRepresentante_Representantetipo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Representantetipo_N = value;
            SetDirty("Representantetipo_N");
         }

      }

      public void gxTv_SdtRepresentante_Representantetipo_N_SetNull( )
      {
         gxTv_SdtRepresentante_Representantetipo_N = 0;
         SetDirty("Representantetipo_N");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Representantetipo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteId_N" )]
      [  XmlElement( ElementName = "ClienteId_N"   )]
      public short gxTpr_Clienteid_N
      {
         get {
            return gxTv_SdtRepresentante_Clienteid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRepresentante_Clienteid_N = value;
            SetDirty("Clienteid_N");
         }

      }

      public void gxTv_SdtRepresentante_Clienteid_N_SetNull( )
      {
         gxTv_SdtRepresentante_Clienteid_N = 0;
         SetDirty("Clienteid_N");
         return  ;
      }

      public bool gxTv_SdtRepresentante_Clienteid_N_IsNull( )
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
         gxTv_SdtRepresentante_Representantenome = "";
         gxTv_SdtRepresentante_Representanterg = "";
         gxTv_SdtRepresentante_Representanteorgaoexpedidor = "";
         gxTv_SdtRepresentante_Representanterguf = "";
         gxTv_SdtRepresentante_Representantecpf = "";
         gxTv_SdtRepresentante_Representanteestadocivil = "";
         gxTv_SdtRepresentante_Representantenacionalidade = "";
         gxTv_SdtRepresentante_Representanteprofissaodescricao = "";
         gxTv_SdtRepresentante_Representanteemail = "";
         gxTv_SdtRepresentante_Representantecep = "";
         gxTv_SdtRepresentante_Representantelogradouro = "";
         gxTv_SdtRepresentante_Representantebairro = "";
         gxTv_SdtRepresentante_Representantecidade = "";
         gxTv_SdtRepresentante_Representantemunicipio = "";
         gxTv_SdtRepresentante_Representantecomplemento = "";
         gxTv_SdtRepresentante_Representantemunicipiouf = "";
         gxTv_SdtRepresentante_Representantemunicipionome = "";
         gxTv_SdtRepresentante_Representantetipo = "";
         gxTv_SdtRepresentante_Mode = "";
         gxTv_SdtRepresentante_Representantenome_Z = "";
         gxTv_SdtRepresentante_Representanterg_Z = "";
         gxTv_SdtRepresentante_Representanteorgaoexpedidor_Z = "";
         gxTv_SdtRepresentante_Representanterguf_Z = "";
         gxTv_SdtRepresentante_Representantecpf_Z = "";
         gxTv_SdtRepresentante_Representanteestadocivil_Z = "";
         gxTv_SdtRepresentante_Representantenacionalidade_Z = "";
         gxTv_SdtRepresentante_Representanteprofissaodescricao_Z = "";
         gxTv_SdtRepresentante_Representanteemail_Z = "";
         gxTv_SdtRepresentante_Representantecep_Z = "";
         gxTv_SdtRepresentante_Representantelogradouro_Z = "";
         gxTv_SdtRepresentante_Representantebairro_Z = "";
         gxTv_SdtRepresentante_Representantecidade_Z = "";
         gxTv_SdtRepresentante_Representantemunicipio_Z = "";
         gxTv_SdtRepresentante_Representantecomplemento_Z = "";
         gxTv_SdtRepresentante_Representantemunicipiouf_Z = "";
         gxTv_SdtRepresentante_Representantemunicipionome_Z = "";
         gxTv_SdtRepresentante_Representantetipo_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "representante", "GeneXus.Programs.representante_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtRepresentante_Representanteddd ;
      private short gxTv_SdtRepresentante_Initialized ;
      private short gxTv_SdtRepresentante_Representanteddd_Z ;
      private short gxTv_SdtRepresentante_Representantenome_N ;
      private short gxTv_SdtRepresentante_Representanterg_N ;
      private short gxTv_SdtRepresentante_Representanteorgaoexpedidor_N ;
      private short gxTv_SdtRepresentante_Representanterguf_N ;
      private short gxTv_SdtRepresentante_Representantecpf_N ;
      private short gxTv_SdtRepresentante_Representanteestadocivil_N ;
      private short gxTv_SdtRepresentante_Representantenacionalidade_N ;
      private short gxTv_SdtRepresentante_Representanteprofissao_N ;
      private short gxTv_SdtRepresentante_Representanteprofissaodescricao_N ;
      private short gxTv_SdtRepresentante_Representanteemail_N ;
      private short gxTv_SdtRepresentante_Representantecep_N ;
      private short gxTv_SdtRepresentante_Representantelogradouro_N ;
      private short gxTv_SdtRepresentante_Representantebairro_N ;
      private short gxTv_SdtRepresentante_Representantecidade_N ;
      private short gxTv_SdtRepresentante_Representantemunicipio_N ;
      private short gxTv_SdtRepresentante_Representantelogradouronumero_N ;
      private short gxTv_SdtRepresentante_Representantecomplemento_N ;
      private short gxTv_SdtRepresentante_Representanteddd_N ;
      private short gxTv_SdtRepresentante_Representantenumero_N ;
      private short gxTv_SdtRepresentante_Representantemunicipiouf_N ;
      private short gxTv_SdtRepresentante_Representantemunicipionome_N ;
      private short gxTv_SdtRepresentante_Representantetipo_N ;
      private short gxTv_SdtRepresentante_Clienteid_N ;
      private int gxTv_SdtRepresentante_Representanteid ;
      private int gxTv_SdtRepresentante_Representanteprofissao ;
      private int gxTv_SdtRepresentante_Representantenumero ;
      private int gxTv_SdtRepresentante_Clienteid ;
      private int gxTv_SdtRepresentante_Representanteid_Z ;
      private int gxTv_SdtRepresentante_Representanteprofissao_Z ;
      private int gxTv_SdtRepresentante_Representantenumero_Z ;
      private int gxTv_SdtRepresentante_Clienteid_Z ;
      private long gxTv_SdtRepresentante_Representantelogradouronumero ;
      private long gxTv_SdtRepresentante_Representantelogradouronumero_Z ;
      private string gxTv_SdtRepresentante_Mode ;
      private string gxTv_SdtRepresentante_Representantenome ;
      private string gxTv_SdtRepresentante_Representanterg ;
      private string gxTv_SdtRepresentante_Representanteorgaoexpedidor ;
      private string gxTv_SdtRepresentante_Representanterguf ;
      private string gxTv_SdtRepresentante_Representantecpf ;
      private string gxTv_SdtRepresentante_Representanteestadocivil ;
      private string gxTv_SdtRepresentante_Representantenacionalidade ;
      private string gxTv_SdtRepresentante_Representanteprofissaodescricao ;
      private string gxTv_SdtRepresentante_Representanteemail ;
      private string gxTv_SdtRepresentante_Representantecep ;
      private string gxTv_SdtRepresentante_Representantelogradouro ;
      private string gxTv_SdtRepresentante_Representantebairro ;
      private string gxTv_SdtRepresentante_Representantecidade ;
      private string gxTv_SdtRepresentante_Representantemunicipio ;
      private string gxTv_SdtRepresentante_Representantecomplemento ;
      private string gxTv_SdtRepresentante_Representantemunicipiouf ;
      private string gxTv_SdtRepresentante_Representantemunicipionome ;
      private string gxTv_SdtRepresentante_Representantetipo ;
      private string gxTv_SdtRepresentante_Representantenome_Z ;
      private string gxTv_SdtRepresentante_Representanterg_Z ;
      private string gxTv_SdtRepresentante_Representanteorgaoexpedidor_Z ;
      private string gxTv_SdtRepresentante_Representanterguf_Z ;
      private string gxTv_SdtRepresentante_Representantecpf_Z ;
      private string gxTv_SdtRepresentante_Representanteestadocivil_Z ;
      private string gxTv_SdtRepresentante_Representantenacionalidade_Z ;
      private string gxTv_SdtRepresentante_Representanteprofissaodescricao_Z ;
      private string gxTv_SdtRepresentante_Representanteemail_Z ;
      private string gxTv_SdtRepresentante_Representantecep_Z ;
      private string gxTv_SdtRepresentante_Representantelogradouro_Z ;
      private string gxTv_SdtRepresentante_Representantebairro_Z ;
      private string gxTv_SdtRepresentante_Representantecidade_Z ;
      private string gxTv_SdtRepresentante_Representantemunicipio_Z ;
      private string gxTv_SdtRepresentante_Representantecomplemento_Z ;
      private string gxTv_SdtRepresentante_Representantemunicipiouf_Z ;
      private string gxTv_SdtRepresentante_Representantemunicipionome_Z ;
      private string gxTv_SdtRepresentante_Representantetipo_Z ;
   }

   [DataContract(Name = @"Representante", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtRepresentante_RESTInterface : GxGenericCollectionItem<SdtRepresentante>
   {
      public SdtRepresentante_RESTInterface( ) : base()
      {
      }

      public SdtRepresentante_RESTInterface( SdtRepresentante psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "RepresentanteId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Representanteid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Representanteid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Representanteid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "RepresentanteNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Representantenome
      {
         get {
            return sdt.gxTpr_Representantenome ;
         }

         set {
            sdt.gxTpr_Representantenome = value;
         }

      }

      [DataMember( Name = "RepresentanteRG" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Representanterg
      {
         get {
            return sdt.gxTpr_Representanterg ;
         }

         set {
            sdt.gxTpr_Representanterg = value;
         }

      }

      [DataMember( Name = "RepresentanteOrgaoExpedidor" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Representanteorgaoexpedidor
      {
         get {
            return sdt.gxTpr_Representanteorgaoexpedidor ;
         }

         set {
            sdt.gxTpr_Representanteorgaoexpedidor = value;
         }

      }

      [DataMember( Name = "RepresentanteRGUF" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Representanterguf
      {
         get {
            return sdt.gxTpr_Representanterguf ;
         }

         set {
            sdt.gxTpr_Representanterguf = value;
         }

      }

      [DataMember( Name = "RepresentanteCPF" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Representantecpf
      {
         get {
            return sdt.gxTpr_Representantecpf ;
         }

         set {
            sdt.gxTpr_Representantecpf = value;
         }

      }

      [DataMember( Name = "RepresentanteEstadoCivil" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Representanteestadocivil
      {
         get {
            return sdt.gxTpr_Representanteestadocivil ;
         }

         set {
            sdt.gxTpr_Representanteestadocivil = value;
         }

      }

      [DataMember( Name = "RepresentanteNacionalidade" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Representantenacionalidade
      {
         get {
            return sdt.gxTpr_Representantenacionalidade ;
         }

         set {
            sdt.gxTpr_Representantenacionalidade = value;
         }

      }

      [DataMember( Name = "RepresentanteProfissao" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Representanteprofissao
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Representanteprofissao), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Representanteprofissao = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "RepresentanteProfissaoDescricao" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Representanteprofissaodescricao
      {
         get {
            return sdt.gxTpr_Representanteprofissaodescricao ;
         }

         set {
            sdt.gxTpr_Representanteprofissaodescricao = value;
         }

      }

      [DataMember( Name = "RepresentanteEmail" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Representanteemail
      {
         get {
            return sdt.gxTpr_Representanteemail ;
         }

         set {
            sdt.gxTpr_Representanteemail = value;
         }

      }

      [DataMember( Name = "RepresentanteCEP" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Representantecep
      {
         get {
            return sdt.gxTpr_Representantecep ;
         }

         set {
            sdt.gxTpr_Representantecep = value;
         }

      }

      [DataMember( Name = "RepresentanteLogradouro" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Representantelogradouro
      {
         get {
            return sdt.gxTpr_Representantelogradouro ;
         }

         set {
            sdt.gxTpr_Representantelogradouro = value;
         }

      }

      [DataMember( Name = "RepresentanteBairro" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Representantebairro
      {
         get {
            return sdt.gxTpr_Representantebairro ;
         }

         set {
            sdt.gxTpr_Representantebairro = value;
         }

      }

      [DataMember( Name = "RepresentanteCidade" , Order = 14 )]
      [GxSeudo()]
      public string gxTpr_Representantecidade
      {
         get {
            return sdt.gxTpr_Representantecidade ;
         }

         set {
            sdt.gxTpr_Representantecidade = value;
         }

      }

      [DataMember( Name = "RepresentanteMunicipio" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Representantemunicipio
      {
         get {
            return sdt.gxTpr_Representantemunicipio ;
         }

         set {
            sdt.gxTpr_Representantemunicipio = value;
         }

      }

      [DataMember( Name = "RepresentanteLogradouroNumero" , Order = 16 )]
      [GxSeudo()]
      public string gxTpr_Representantelogradouronumero
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Representantelogradouronumero), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Representantelogradouronumero = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "RepresentanteComplemento" , Order = 17 )]
      [GxSeudo()]
      public string gxTpr_Representantecomplemento
      {
         get {
            return sdt.gxTpr_Representantecomplemento ;
         }

         set {
            sdt.gxTpr_Representantecomplemento = value;
         }

      }

      [DataMember( Name = "RepresentanteDDD" , Order = 18 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Representanteddd
      {
         get {
            return sdt.gxTpr_Representanteddd ;
         }

         set {
            sdt.gxTpr_Representanteddd = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "RepresentanteNumero" , Order = 19 )]
      [GxSeudo()]
      public string gxTpr_Representantenumero
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Representantenumero), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Representantenumero = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "RepresentanteMunicipioUF" , Order = 20 )]
      [GxSeudo()]
      public string gxTpr_Representantemunicipiouf
      {
         get {
            return sdt.gxTpr_Representantemunicipiouf ;
         }

         set {
            sdt.gxTpr_Representantemunicipiouf = value;
         }

      }

      [DataMember( Name = "RepresentanteMunicipioNome" , Order = 21 )]
      [GxSeudo()]
      public string gxTpr_Representantemunicipionome
      {
         get {
            return sdt.gxTpr_Representantemunicipionome ;
         }

         set {
            sdt.gxTpr_Representantemunicipionome = value;
         }

      }

      [DataMember( Name = "RepresentanteTipo" , Order = 22 )]
      [GxSeudo()]
      public string gxTpr_Representantetipo
      {
         get {
            return sdt.gxTpr_Representantetipo ;
         }

         set {
            sdt.gxTpr_Representantetipo = value;
         }

      }

      [DataMember( Name = "ClienteId" , Order = 23 )]
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

      public SdtRepresentante sdt
      {
         get {
            return (SdtRepresentante)Sdt ;
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
            sdt = new SdtRepresentante() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 24 )]
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

   [DataContract(Name = @"Representante", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtRepresentante_RESTLInterface : GxGenericCollectionItem<SdtRepresentante>
   {
      public SdtRepresentante_RESTLInterface( ) : base()
      {
      }

      public SdtRepresentante_RESTLInterface( SdtRepresentante psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "RepresentanteNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Representantenome
      {
         get {
            return sdt.gxTpr_Representantenome ;
         }

         set {
            sdt.gxTpr_Representantenome = value;
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

      public SdtRepresentante sdt
      {
         get {
            return (SdtRepresentante)Sdt ;
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
            sdt = new SdtRepresentante() ;
         }
      }

   }

}
