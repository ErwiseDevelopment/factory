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
   [XmlRoot(ElementName = "Empresa" )]
   [XmlType(TypeName =  "Empresa" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtEmpresa : GxSilentTrnSdt
   {
      public SdtEmpresa( )
      {
      }

      public SdtEmpresa( IGxContext context )
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

      public void Load( int AV249EmpresaId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV249EmpresaId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"EmpresaId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Empresa");
         metadata.Set("BT", "Empresa");
         metadata.Set("PK", "[ \"EmpresaId\" ]");
         metadata.Set("PKAssigned", "[ \"EmpresaId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"BancoId\" ],\"FKMap\":[ \"EmpresaBancoId-BancoId\" ] },{ \"FK\":[ \"MunicipioCodigo\" ],\"FKMap\":[  ] },{ \"FK\":[ \"MunicipioCodigo\" ],\"FKMap\":[ \"EmpresaRepresentanteMunicipio-MunicipioCodigo\" ] },{ \"FK\":[ \"ProfissaoId\" ],\"FKMap\":[ \"EmpresaRepresentanteProfissao-ProfissaoId\" ] } ]");
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
         state.Add("gxTpr_Empresaid_Z");
         state.Add("gxTpr_Empresanomefantasia_Z");
         state.Add("gxTpr_Empresarazaosocial_Z");
         state.Add("gxTpr_Empresacnpj_Z");
         state.Add("gxTpr_Empresasede_Z");
         state.Add("gxTpr_Empresabancoid_Z");
         state.Add("gxTpr_Banconome_Z");
         state.Add("gxTpr_Empresaagencia_Z");
         state.Add("gxTpr_Empresaagenciadigito_Z");
         state.Add("gxTpr_Empresaconta_Z");
         state.Add("gxTpr_Empresapix_Z");
         state.Add("gxTpr_Empresapixtipo_Z");
         state.Add("gxTpr_Empresaemail_Z");
         state.Add("gxTpr_Empresalogradouro_Z");
         state.Add("gxTpr_Empresalogradouronumero_Z");
         state.Add("gxTpr_Empresacep_Z");
         state.Add("gxTpr_Empresabairro_Z");
         state.Add("gxTpr_Empresacomplemento_Z");
         state.Add("gxTpr_Municipiocodigo_Z");
         state.Add("gxTpr_Municipionome_Z");
         state.Add("gxTpr_Municipiouf_Z");
         state.Add("gxTpr_Empresarepresentantecpf_Z");
         state.Add("gxTpr_Empresarepresentantenome_Z");
         state.Add("gxTpr_Empresarepresentanteemail_Z");
         state.Add("gxTpr_Empresautilizarepresentanteassinatura_Z");
         state.Add("gxTpr_Empresarepresentantelogradouro_Z");
         state.Add("gxTpr_Empresarepresentantenumero_Z");
         state.Add("gxTpr_Empresarepresentantecep_Z");
         state.Add("gxTpr_Empresarepresentantebairro_Z");
         state.Add("gxTpr_Empresarepresentantecomplemento_Z");
         state.Add("gxTpr_Empresarepresentantemunicipio_Z");
         state.Add("gxTpr_Empresarepresentantemunicipionome_Z");
         state.Add("gxTpr_Empresarepresentantemunicipiouf_Z");
         state.Add("gxTpr_Empresarepresentantenacionalidade_Z");
         state.Add("gxTpr_Empresarepresentanteprofissao_Z");
         state.Add("gxTpr_Empresarepresentantetelefone_Z");
         state.Add("gxTpr_Empresarepresentantetelefoneddd_Z");
         state.Add("gxTpr_Empresanomefantasia_N");
         state.Add("gxTpr_Empresarazaosocial_N");
         state.Add("gxTpr_Empresacnpj_N");
         state.Add("gxTpr_Empresasede_N");
         state.Add("gxTpr_Empresabancoid_N");
         state.Add("gxTpr_Banconome_N");
         state.Add("gxTpr_Empresaagencia_N");
         state.Add("gxTpr_Empresaagenciadigito_N");
         state.Add("gxTpr_Empresaconta_N");
         state.Add("gxTpr_Empresapix_N");
         state.Add("gxTpr_Empresapixtipo_N");
         state.Add("gxTpr_Empresaemail_N");
         state.Add("gxTpr_Empresalogradouro_N");
         state.Add("gxTpr_Empresalogradouronumero_N");
         state.Add("gxTpr_Empresacep_N");
         state.Add("gxTpr_Empresabairro_N");
         state.Add("gxTpr_Empresacomplemento_N");
         state.Add("gxTpr_Municipiocodigo_N");
         state.Add("gxTpr_Municipionome_N");
         state.Add("gxTpr_Municipiouf_N");
         state.Add("gxTpr_Empresarepresentantecpf_N");
         state.Add("gxTpr_Empresarepresentantenome_N");
         state.Add("gxTpr_Empresarepresentanteemail_N");
         state.Add("gxTpr_Empresautilizarepresentanteassinatura_N");
         state.Add("gxTpr_Empresarepresentantelogradouro_N");
         state.Add("gxTpr_Empresarepresentantenumero_N");
         state.Add("gxTpr_Empresarepresentantecep_N");
         state.Add("gxTpr_Empresarepresentantebairro_N");
         state.Add("gxTpr_Empresarepresentantecomplemento_N");
         state.Add("gxTpr_Empresarepresentantemunicipio_N");
         state.Add("gxTpr_Empresarepresentantemunicipionome_N");
         state.Add("gxTpr_Empresarepresentantemunicipiouf_N");
         state.Add("gxTpr_Empresarepresentantenacionalidade_N");
         state.Add("gxTpr_Empresarepresentanteprofissao_N");
         state.Add("gxTpr_Empresarepresentantetelefone_N");
         state.Add("gxTpr_Empresarepresentantetelefoneddd_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtEmpresa sdt;
         sdt = (SdtEmpresa)(source);
         gxTv_SdtEmpresa_Empresaid = sdt.gxTv_SdtEmpresa_Empresaid ;
         gxTv_SdtEmpresa_Empresanomefantasia = sdt.gxTv_SdtEmpresa_Empresanomefantasia ;
         gxTv_SdtEmpresa_Empresarazaosocial = sdt.gxTv_SdtEmpresa_Empresarazaosocial ;
         gxTv_SdtEmpresa_Empresacnpj = sdt.gxTv_SdtEmpresa_Empresacnpj ;
         gxTv_SdtEmpresa_Empresasede = sdt.gxTv_SdtEmpresa_Empresasede ;
         gxTv_SdtEmpresa_Empresabancoid = sdt.gxTv_SdtEmpresa_Empresabancoid ;
         gxTv_SdtEmpresa_Banconome = sdt.gxTv_SdtEmpresa_Banconome ;
         gxTv_SdtEmpresa_Empresaagencia = sdt.gxTv_SdtEmpresa_Empresaagencia ;
         gxTv_SdtEmpresa_Empresaagenciadigito = sdt.gxTv_SdtEmpresa_Empresaagenciadigito ;
         gxTv_SdtEmpresa_Empresaconta = sdt.gxTv_SdtEmpresa_Empresaconta ;
         gxTv_SdtEmpresa_Empresapix = sdt.gxTv_SdtEmpresa_Empresapix ;
         gxTv_SdtEmpresa_Empresapixtipo = sdt.gxTv_SdtEmpresa_Empresapixtipo ;
         gxTv_SdtEmpresa_Empresaemail = sdt.gxTv_SdtEmpresa_Empresaemail ;
         gxTv_SdtEmpresa_Empresalogradouro = sdt.gxTv_SdtEmpresa_Empresalogradouro ;
         gxTv_SdtEmpresa_Empresalogradouronumero = sdt.gxTv_SdtEmpresa_Empresalogradouronumero ;
         gxTv_SdtEmpresa_Empresacep = sdt.gxTv_SdtEmpresa_Empresacep ;
         gxTv_SdtEmpresa_Empresabairro = sdt.gxTv_SdtEmpresa_Empresabairro ;
         gxTv_SdtEmpresa_Empresacomplemento = sdt.gxTv_SdtEmpresa_Empresacomplemento ;
         gxTv_SdtEmpresa_Municipiocodigo = sdt.gxTv_SdtEmpresa_Municipiocodigo ;
         gxTv_SdtEmpresa_Municipionome = sdt.gxTv_SdtEmpresa_Municipionome ;
         gxTv_SdtEmpresa_Municipiouf = sdt.gxTv_SdtEmpresa_Municipiouf ;
         gxTv_SdtEmpresa_Empresarepresentantecpf = sdt.gxTv_SdtEmpresa_Empresarepresentantecpf ;
         gxTv_SdtEmpresa_Empresarepresentantenome = sdt.gxTv_SdtEmpresa_Empresarepresentantenome ;
         gxTv_SdtEmpresa_Empresarepresentanteemail = sdt.gxTv_SdtEmpresa_Empresarepresentanteemail ;
         gxTv_SdtEmpresa_Empresautilizarepresentanteassinatura = sdt.gxTv_SdtEmpresa_Empresautilizarepresentanteassinatura ;
         gxTv_SdtEmpresa_Empresarepresentantelogradouro = sdt.gxTv_SdtEmpresa_Empresarepresentantelogradouro ;
         gxTv_SdtEmpresa_Empresarepresentantenumero = sdt.gxTv_SdtEmpresa_Empresarepresentantenumero ;
         gxTv_SdtEmpresa_Empresarepresentantecep = sdt.gxTv_SdtEmpresa_Empresarepresentantecep ;
         gxTv_SdtEmpresa_Empresarepresentantebairro = sdt.gxTv_SdtEmpresa_Empresarepresentantebairro ;
         gxTv_SdtEmpresa_Empresarepresentantecomplemento = sdt.gxTv_SdtEmpresa_Empresarepresentantecomplemento ;
         gxTv_SdtEmpresa_Empresarepresentantemunicipio = sdt.gxTv_SdtEmpresa_Empresarepresentantemunicipio ;
         gxTv_SdtEmpresa_Empresarepresentantemunicipionome = sdt.gxTv_SdtEmpresa_Empresarepresentantemunicipionome ;
         gxTv_SdtEmpresa_Empresarepresentantemunicipiouf = sdt.gxTv_SdtEmpresa_Empresarepresentantemunicipiouf ;
         gxTv_SdtEmpresa_Empresarepresentantenacionalidade = sdt.gxTv_SdtEmpresa_Empresarepresentantenacionalidade ;
         gxTv_SdtEmpresa_Empresarepresentanteprofissao = sdt.gxTv_SdtEmpresa_Empresarepresentanteprofissao ;
         gxTv_SdtEmpresa_Empresarepresentantetelefone = sdt.gxTv_SdtEmpresa_Empresarepresentantetelefone ;
         gxTv_SdtEmpresa_Empresarepresentantetelefoneddd = sdt.gxTv_SdtEmpresa_Empresarepresentantetelefoneddd ;
         gxTv_SdtEmpresa_Mode = sdt.gxTv_SdtEmpresa_Mode ;
         gxTv_SdtEmpresa_Initialized = sdt.gxTv_SdtEmpresa_Initialized ;
         gxTv_SdtEmpresa_Empresaid_Z = sdt.gxTv_SdtEmpresa_Empresaid_Z ;
         gxTv_SdtEmpresa_Empresanomefantasia_Z = sdt.gxTv_SdtEmpresa_Empresanomefantasia_Z ;
         gxTv_SdtEmpresa_Empresarazaosocial_Z = sdt.gxTv_SdtEmpresa_Empresarazaosocial_Z ;
         gxTv_SdtEmpresa_Empresacnpj_Z = sdt.gxTv_SdtEmpresa_Empresacnpj_Z ;
         gxTv_SdtEmpresa_Empresasede_Z = sdt.gxTv_SdtEmpresa_Empresasede_Z ;
         gxTv_SdtEmpresa_Empresabancoid_Z = sdt.gxTv_SdtEmpresa_Empresabancoid_Z ;
         gxTv_SdtEmpresa_Banconome_Z = sdt.gxTv_SdtEmpresa_Banconome_Z ;
         gxTv_SdtEmpresa_Empresaagencia_Z = sdt.gxTv_SdtEmpresa_Empresaagencia_Z ;
         gxTv_SdtEmpresa_Empresaagenciadigito_Z = sdt.gxTv_SdtEmpresa_Empresaagenciadigito_Z ;
         gxTv_SdtEmpresa_Empresaconta_Z = sdt.gxTv_SdtEmpresa_Empresaconta_Z ;
         gxTv_SdtEmpresa_Empresapix_Z = sdt.gxTv_SdtEmpresa_Empresapix_Z ;
         gxTv_SdtEmpresa_Empresapixtipo_Z = sdt.gxTv_SdtEmpresa_Empresapixtipo_Z ;
         gxTv_SdtEmpresa_Empresaemail_Z = sdt.gxTv_SdtEmpresa_Empresaemail_Z ;
         gxTv_SdtEmpresa_Empresalogradouro_Z = sdt.gxTv_SdtEmpresa_Empresalogradouro_Z ;
         gxTv_SdtEmpresa_Empresalogradouronumero_Z = sdt.gxTv_SdtEmpresa_Empresalogradouronumero_Z ;
         gxTv_SdtEmpresa_Empresacep_Z = sdt.gxTv_SdtEmpresa_Empresacep_Z ;
         gxTv_SdtEmpresa_Empresabairro_Z = sdt.gxTv_SdtEmpresa_Empresabairro_Z ;
         gxTv_SdtEmpresa_Empresacomplemento_Z = sdt.gxTv_SdtEmpresa_Empresacomplemento_Z ;
         gxTv_SdtEmpresa_Municipiocodigo_Z = sdt.gxTv_SdtEmpresa_Municipiocodigo_Z ;
         gxTv_SdtEmpresa_Municipionome_Z = sdt.gxTv_SdtEmpresa_Municipionome_Z ;
         gxTv_SdtEmpresa_Municipiouf_Z = sdt.gxTv_SdtEmpresa_Municipiouf_Z ;
         gxTv_SdtEmpresa_Empresarepresentantecpf_Z = sdt.gxTv_SdtEmpresa_Empresarepresentantecpf_Z ;
         gxTv_SdtEmpresa_Empresarepresentantenome_Z = sdt.gxTv_SdtEmpresa_Empresarepresentantenome_Z ;
         gxTv_SdtEmpresa_Empresarepresentanteemail_Z = sdt.gxTv_SdtEmpresa_Empresarepresentanteemail_Z ;
         gxTv_SdtEmpresa_Empresautilizarepresentanteassinatura_Z = sdt.gxTv_SdtEmpresa_Empresautilizarepresentanteassinatura_Z ;
         gxTv_SdtEmpresa_Empresarepresentantelogradouro_Z = sdt.gxTv_SdtEmpresa_Empresarepresentantelogradouro_Z ;
         gxTv_SdtEmpresa_Empresarepresentantenumero_Z = sdt.gxTv_SdtEmpresa_Empresarepresentantenumero_Z ;
         gxTv_SdtEmpresa_Empresarepresentantecep_Z = sdt.gxTv_SdtEmpresa_Empresarepresentantecep_Z ;
         gxTv_SdtEmpresa_Empresarepresentantebairro_Z = sdt.gxTv_SdtEmpresa_Empresarepresentantebairro_Z ;
         gxTv_SdtEmpresa_Empresarepresentantecomplemento_Z = sdt.gxTv_SdtEmpresa_Empresarepresentantecomplemento_Z ;
         gxTv_SdtEmpresa_Empresarepresentantemunicipio_Z = sdt.gxTv_SdtEmpresa_Empresarepresentantemunicipio_Z ;
         gxTv_SdtEmpresa_Empresarepresentantemunicipionome_Z = sdt.gxTv_SdtEmpresa_Empresarepresentantemunicipionome_Z ;
         gxTv_SdtEmpresa_Empresarepresentantemunicipiouf_Z = sdt.gxTv_SdtEmpresa_Empresarepresentantemunicipiouf_Z ;
         gxTv_SdtEmpresa_Empresarepresentantenacionalidade_Z = sdt.gxTv_SdtEmpresa_Empresarepresentantenacionalidade_Z ;
         gxTv_SdtEmpresa_Empresarepresentanteprofissao_Z = sdt.gxTv_SdtEmpresa_Empresarepresentanteprofissao_Z ;
         gxTv_SdtEmpresa_Empresarepresentantetelefone_Z = sdt.gxTv_SdtEmpresa_Empresarepresentantetelefone_Z ;
         gxTv_SdtEmpresa_Empresarepresentantetelefoneddd_Z = sdt.gxTv_SdtEmpresa_Empresarepresentantetelefoneddd_Z ;
         gxTv_SdtEmpresa_Empresanomefantasia_N = sdt.gxTv_SdtEmpresa_Empresanomefantasia_N ;
         gxTv_SdtEmpresa_Empresarazaosocial_N = sdt.gxTv_SdtEmpresa_Empresarazaosocial_N ;
         gxTv_SdtEmpresa_Empresacnpj_N = sdt.gxTv_SdtEmpresa_Empresacnpj_N ;
         gxTv_SdtEmpresa_Empresasede_N = sdt.gxTv_SdtEmpresa_Empresasede_N ;
         gxTv_SdtEmpresa_Empresabancoid_N = sdt.gxTv_SdtEmpresa_Empresabancoid_N ;
         gxTv_SdtEmpresa_Banconome_N = sdt.gxTv_SdtEmpresa_Banconome_N ;
         gxTv_SdtEmpresa_Empresaagencia_N = sdt.gxTv_SdtEmpresa_Empresaagencia_N ;
         gxTv_SdtEmpresa_Empresaagenciadigito_N = sdt.gxTv_SdtEmpresa_Empresaagenciadigito_N ;
         gxTv_SdtEmpresa_Empresaconta_N = sdt.gxTv_SdtEmpresa_Empresaconta_N ;
         gxTv_SdtEmpresa_Empresapix_N = sdt.gxTv_SdtEmpresa_Empresapix_N ;
         gxTv_SdtEmpresa_Empresapixtipo_N = sdt.gxTv_SdtEmpresa_Empresapixtipo_N ;
         gxTv_SdtEmpresa_Empresaemail_N = sdt.gxTv_SdtEmpresa_Empresaemail_N ;
         gxTv_SdtEmpresa_Empresalogradouro_N = sdt.gxTv_SdtEmpresa_Empresalogradouro_N ;
         gxTv_SdtEmpresa_Empresalogradouronumero_N = sdt.gxTv_SdtEmpresa_Empresalogradouronumero_N ;
         gxTv_SdtEmpresa_Empresacep_N = sdt.gxTv_SdtEmpresa_Empresacep_N ;
         gxTv_SdtEmpresa_Empresabairro_N = sdt.gxTv_SdtEmpresa_Empresabairro_N ;
         gxTv_SdtEmpresa_Empresacomplemento_N = sdt.gxTv_SdtEmpresa_Empresacomplemento_N ;
         gxTv_SdtEmpresa_Municipiocodigo_N = sdt.gxTv_SdtEmpresa_Municipiocodigo_N ;
         gxTv_SdtEmpresa_Municipionome_N = sdt.gxTv_SdtEmpresa_Municipionome_N ;
         gxTv_SdtEmpresa_Municipiouf_N = sdt.gxTv_SdtEmpresa_Municipiouf_N ;
         gxTv_SdtEmpresa_Empresarepresentantecpf_N = sdt.gxTv_SdtEmpresa_Empresarepresentantecpf_N ;
         gxTv_SdtEmpresa_Empresarepresentantenome_N = sdt.gxTv_SdtEmpresa_Empresarepresentantenome_N ;
         gxTv_SdtEmpresa_Empresarepresentanteemail_N = sdt.gxTv_SdtEmpresa_Empresarepresentanteemail_N ;
         gxTv_SdtEmpresa_Empresautilizarepresentanteassinatura_N = sdt.gxTv_SdtEmpresa_Empresautilizarepresentanteassinatura_N ;
         gxTv_SdtEmpresa_Empresarepresentantelogradouro_N = sdt.gxTv_SdtEmpresa_Empresarepresentantelogradouro_N ;
         gxTv_SdtEmpresa_Empresarepresentantenumero_N = sdt.gxTv_SdtEmpresa_Empresarepresentantenumero_N ;
         gxTv_SdtEmpresa_Empresarepresentantecep_N = sdt.gxTv_SdtEmpresa_Empresarepresentantecep_N ;
         gxTv_SdtEmpresa_Empresarepresentantebairro_N = sdt.gxTv_SdtEmpresa_Empresarepresentantebairro_N ;
         gxTv_SdtEmpresa_Empresarepresentantecomplemento_N = sdt.gxTv_SdtEmpresa_Empresarepresentantecomplemento_N ;
         gxTv_SdtEmpresa_Empresarepresentantemunicipio_N = sdt.gxTv_SdtEmpresa_Empresarepresentantemunicipio_N ;
         gxTv_SdtEmpresa_Empresarepresentantemunicipionome_N = sdt.gxTv_SdtEmpresa_Empresarepresentantemunicipionome_N ;
         gxTv_SdtEmpresa_Empresarepresentantemunicipiouf_N = sdt.gxTv_SdtEmpresa_Empresarepresentantemunicipiouf_N ;
         gxTv_SdtEmpresa_Empresarepresentantenacionalidade_N = sdt.gxTv_SdtEmpresa_Empresarepresentantenacionalidade_N ;
         gxTv_SdtEmpresa_Empresarepresentanteprofissao_N = sdt.gxTv_SdtEmpresa_Empresarepresentanteprofissao_N ;
         gxTv_SdtEmpresa_Empresarepresentantetelefone_N = sdt.gxTv_SdtEmpresa_Empresarepresentantetelefone_N ;
         gxTv_SdtEmpresa_Empresarepresentantetelefoneddd_N = sdt.gxTv_SdtEmpresa_Empresarepresentantetelefoneddd_N ;
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
         AddObjectProperty("EmpresaId", gxTv_SdtEmpresa_Empresaid, false, includeNonInitialized);
         AddObjectProperty("EmpresaNomeFantasia", gxTv_SdtEmpresa_Empresanomefantasia, false, includeNonInitialized);
         AddObjectProperty("EmpresaNomeFantasia_N", gxTv_SdtEmpresa_Empresanomefantasia_N, false, includeNonInitialized);
         AddObjectProperty("EmpresaRazaoSocial", gxTv_SdtEmpresa_Empresarazaosocial, false, includeNonInitialized);
         AddObjectProperty("EmpresaRazaoSocial_N", gxTv_SdtEmpresa_Empresarazaosocial_N, false, includeNonInitialized);
         AddObjectProperty("EmpresaCNPJ", gxTv_SdtEmpresa_Empresacnpj, false, includeNonInitialized);
         AddObjectProperty("EmpresaCNPJ_N", gxTv_SdtEmpresa_Empresacnpj_N, false, includeNonInitialized);
         AddObjectProperty("EmpresaSede", gxTv_SdtEmpresa_Empresasede, false, includeNonInitialized);
         AddObjectProperty("EmpresaSede_N", gxTv_SdtEmpresa_Empresasede_N, false, includeNonInitialized);
         AddObjectProperty("EmpresaBancoId", gxTv_SdtEmpresa_Empresabancoid, false, includeNonInitialized);
         AddObjectProperty("EmpresaBancoId_N", gxTv_SdtEmpresa_Empresabancoid_N, false, includeNonInitialized);
         AddObjectProperty("BancoNome", gxTv_SdtEmpresa_Banconome, false, includeNonInitialized);
         AddObjectProperty("BancoNome_N", gxTv_SdtEmpresa_Banconome_N, false, includeNonInitialized);
         AddObjectProperty("EmpresaAgencia", gxTv_SdtEmpresa_Empresaagencia, false, includeNonInitialized);
         AddObjectProperty("EmpresaAgencia_N", gxTv_SdtEmpresa_Empresaagencia_N, false, includeNonInitialized);
         AddObjectProperty("EmpresaAgenciaDigito", gxTv_SdtEmpresa_Empresaagenciadigito, false, includeNonInitialized);
         AddObjectProperty("EmpresaAgenciaDigito_N", gxTv_SdtEmpresa_Empresaagenciadigito_N, false, includeNonInitialized);
         AddObjectProperty("EmpresaConta", gxTv_SdtEmpresa_Empresaconta, false, includeNonInitialized);
         AddObjectProperty("EmpresaConta_N", gxTv_SdtEmpresa_Empresaconta_N, false, includeNonInitialized);
         AddObjectProperty("EmpresaPix", gxTv_SdtEmpresa_Empresapix, false, includeNonInitialized);
         AddObjectProperty("EmpresaPix_N", gxTv_SdtEmpresa_Empresapix_N, false, includeNonInitialized);
         AddObjectProperty("EmpresaPixTipo", gxTv_SdtEmpresa_Empresapixtipo, false, includeNonInitialized);
         AddObjectProperty("EmpresaPixTipo_N", gxTv_SdtEmpresa_Empresapixtipo_N, false, includeNonInitialized);
         AddObjectProperty("EmpresaEmail", gxTv_SdtEmpresa_Empresaemail, false, includeNonInitialized);
         AddObjectProperty("EmpresaEmail_N", gxTv_SdtEmpresa_Empresaemail_N, false, includeNonInitialized);
         AddObjectProperty("EmpresaLogradouro", gxTv_SdtEmpresa_Empresalogradouro, false, includeNonInitialized);
         AddObjectProperty("EmpresaLogradouro_N", gxTv_SdtEmpresa_Empresalogradouro_N, false, includeNonInitialized);
         AddObjectProperty("EmpresaLogradouroNumero", gxTv_SdtEmpresa_Empresalogradouronumero, false, includeNonInitialized);
         AddObjectProperty("EmpresaLogradouroNumero_N", gxTv_SdtEmpresa_Empresalogradouronumero_N, false, includeNonInitialized);
         AddObjectProperty("EmpresaCEP", gxTv_SdtEmpresa_Empresacep, false, includeNonInitialized);
         AddObjectProperty("EmpresaCEP_N", gxTv_SdtEmpresa_Empresacep_N, false, includeNonInitialized);
         AddObjectProperty("EmpresaBairro", gxTv_SdtEmpresa_Empresabairro, false, includeNonInitialized);
         AddObjectProperty("EmpresaBairro_N", gxTv_SdtEmpresa_Empresabairro_N, false, includeNonInitialized);
         AddObjectProperty("EmpresaComplemento", gxTv_SdtEmpresa_Empresacomplemento, false, includeNonInitialized);
         AddObjectProperty("EmpresaComplemento_N", gxTv_SdtEmpresa_Empresacomplemento_N, false, includeNonInitialized);
         AddObjectProperty("MunicipioCodigo", gxTv_SdtEmpresa_Municipiocodigo, false, includeNonInitialized);
         AddObjectProperty("MunicipioCodigo_N", gxTv_SdtEmpresa_Municipiocodigo_N, false, includeNonInitialized);
         AddObjectProperty("MunicipioNome", gxTv_SdtEmpresa_Municipionome, false, includeNonInitialized);
         AddObjectProperty("MunicipioNome_N", gxTv_SdtEmpresa_Municipionome_N, false, includeNonInitialized);
         AddObjectProperty("MunicipioUF", gxTv_SdtEmpresa_Municipiouf, false, includeNonInitialized);
         AddObjectProperty("MunicipioUF_N", gxTv_SdtEmpresa_Municipiouf_N, false, includeNonInitialized);
         AddObjectProperty("EmpresaRepresentanteCPF", gxTv_SdtEmpresa_Empresarepresentantecpf, false, includeNonInitialized);
         AddObjectProperty("EmpresaRepresentanteCPF_N", gxTv_SdtEmpresa_Empresarepresentantecpf_N, false, includeNonInitialized);
         AddObjectProperty("EmpresaRepresentanteNome", gxTv_SdtEmpresa_Empresarepresentantenome, false, includeNonInitialized);
         AddObjectProperty("EmpresaRepresentanteNome_N", gxTv_SdtEmpresa_Empresarepresentantenome_N, false, includeNonInitialized);
         AddObjectProperty("EmpresaRepresentanteEmail", gxTv_SdtEmpresa_Empresarepresentanteemail, false, includeNonInitialized);
         AddObjectProperty("EmpresaRepresentanteEmail_N", gxTv_SdtEmpresa_Empresarepresentanteemail_N, false, includeNonInitialized);
         AddObjectProperty("EmpresaUtilizaRepresentanteAssinatura", gxTv_SdtEmpresa_Empresautilizarepresentanteassinatura, false, includeNonInitialized);
         AddObjectProperty("EmpresaUtilizaRepresentanteAssinatura_N", gxTv_SdtEmpresa_Empresautilizarepresentanteassinatura_N, false, includeNonInitialized);
         AddObjectProperty("EmpresaRepresentanteLogradouro", gxTv_SdtEmpresa_Empresarepresentantelogradouro, false, includeNonInitialized);
         AddObjectProperty("EmpresaRepresentanteLogradouro_N", gxTv_SdtEmpresa_Empresarepresentantelogradouro_N, false, includeNonInitialized);
         AddObjectProperty("EmpresaRepresentanteNumero", gxTv_SdtEmpresa_Empresarepresentantenumero, false, includeNonInitialized);
         AddObjectProperty("EmpresaRepresentanteNumero_N", gxTv_SdtEmpresa_Empresarepresentantenumero_N, false, includeNonInitialized);
         AddObjectProperty("EmpresaRepresentanteCEP", gxTv_SdtEmpresa_Empresarepresentantecep, false, includeNonInitialized);
         AddObjectProperty("EmpresaRepresentanteCEP_N", gxTv_SdtEmpresa_Empresarepresentantecep_N, false, includeNonInitialized);
         AddObjectProperty("EmpresaRepresentanteBairro", gxTv_SdtEmpresa_Empresarepresentantebairro, false, includeNonInitialized);
         AddObjectProperty("EmpresaRepresentanteBairro_N", gxTv_SdtEmpresa_Empresarepresentantebairro_N, false, includeNonInitialized);
         AddObjectProperty("EmpresaRepresentanteComplemento", gxTv_SdtEmpresa_Empresarepresentantecomplemento, false, includeNonInitialized);
         AddObjectProperty("EmpresaRepresentanteComplemento_N", gxTv_SdtEmpresa_Empresarepresentantecomplemento_N, false, includeNonInitialized);
         AddObjectProperty("EmpresaRepresentanteMunicipio", gxTv_SdtEmpresa_Empresarepresentantemunicipio, false, includeNonInitialized);
         AddObjectProperty("EmpresaRepresentanteMunicipio_N", gxTv_SdtEmpresa_Empresarepresentantemunicipio_N, false, includeNonInitialized);
         AddObjectProperty("EmpresaRepresentanteMunicipioNome", gxTv_SdtEmpresa_Empresarepresentantemunicipionome, false, includeNonInitialized);
         AddObjectProperty("EmpresaRepresentanteMunicipioNome_N", gxTv_SdtEmpresa_Empresarepresentantemunicipionome_N, false, includeNonInitialized);
         AddObjectProperty("EmpresaRepresentanteMunicipioUF", gxTv_SdtEmpresa_Empresarepresentantemunicipiouf, false, includeNonInitialized);
         AddObjectProperty("EmpresaRepresentanteMunicipioUF_N", gxTv_SdtEmpresa_Empresarepresentantemunicipiouf_N, false, includeNonInitialized);
         AddObjectProperty("EmpresaRepresentanteNacionalidade", gxTv_SdtEmpresa_Empresarepresentantenacionalidade, false, includeNonInitialized);
         AddObjectProperty("EmpresaRepresentanteNacionalidade_N", gxTv_SdtEmpresa_Empresarepresentantenacionalidade_N, false, includeNonInitialized);
         AddObjectProperty("EmpresaRepresentanteProfissao", gxTv_SdtEmpresa_Empresarepresentanteprofissao, false, includeNonInitialized);
         AddObjectProperty("EmpresaRepresentanteProfissao_N", gxTv_SdtEmpresa_Empresarepresentanteprofissao_N, false, includeNonInitialized);
         AddObjectProperty("EmpresaRepresentanteTelefone", gxTv_SdtEmpresa_Empresarepresentantetelefone, false, includeNonInitialized);
         AddObjectProperty("EmpresaRepresentanteTelefone_N", gxTv_SdtEmpresa_Empresarepresentantetelefone_N, false, includeNonInitialized);
         AddObjectProperty("EmpresaRepresentanteTelefoneDDD", gxTv_SdtEmpresa_Empresarepresentantetelefoneddd, false, includeNonInitialized);
         AddObjectProperty("EmpresaRepresentanteTelefoneDDD_N", gxTv_SdtEmpresa_Empresarepresentantetelefoneddd_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtEmpresa_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtEmpresa_Initialized, false, includeNonInitialized);
            AddObjectProperty("EmpresaId_Z", gxTv_SdtEmpresa_Empresaid_Z, false, includeNonInitialized);
            AddObjectProperty("EmpresaNomeFantasia_Z", gxTv_SdtEmpresa_Empresanomefantasia_Z, false, includeNonInitialized);
            AddObjectProperty("EmpresaRazaoSocial_Z", gxTv_SdtEmpresa_Empresarazaosocial_Z, false, includeNonInitialized);
            AddObjectProperty("EmpresaCNPJ_Z", gxTv_SdtEmpresa_Empresacnpj_Z, false, includeNonInitialized);
            AddObjectProperty("EmpresaSede_Z", gxTv_SdtEmpresa_Empresasede_Z, false, includeNonInitialized);
            AddObjectProperty("EmpresaBancoId_Z", gxTv_SdtEmpresa_Empresabancoid_Z, false, includeNonInitialized);
            AddObjectProperty("BancoNome_Z", gxTv_SdtEmpresa_Banconome_Z, false, includeNonInitialized);
            AddObjectProperty("EmpresaAgencia_Z", gxTv_SdtEmpresa_Empresaagencia_Z, false, includeNonInitialized);
            AddObjectProperty("EmpresaAgenciaDigito_Z", gxTv_SdtEmpresa_Empresaagenciadigito_Z, false, includeNonInitialized);
            AddObjectProperty("EmpresaConta_Z", gxTv_SdtEmpresa_Empresaconta_Z, false, includeNonInitialized);
            AddObjectProperty("EmpresaPix_Z", gxTv_SdtEmpresa_Empresapix_Z, false, includeNonInitialized);
            AddObjectProperty("EmpresaPixTipo_Z", gxTv_SdtEmpresa_Empresapixtipo_Z, false, includeNonInitialized);
            AddObjectProperty("EmpresaEmail_Z", gxTv_SdtEmpresa_Empresaemail_Z, false, includeNonInitialized);
            AddObjectProperty("EmpresaLogradouro_Z", gxTv_SdtEmpresa_Empresalogradouro_Z, false, includeNonInitialized);
            AddObjectProperty("EmpresaLogradouroNumero_Z", gxTv_SdtEmpresa_Empresalogradouronumero_Z, false, includeNonInitialized);
            AddObjectProperty("EmpresaCEP_Z", gxTv_SdtEmpresa_Empresacep_Z, false, includeNonInitialized);
            AddObjectProperty("EmpresaBairro_Z", gxTv_SdtEmpresa_Empresabairro_Z, false, includeNonInitialized);
            AddObjectProperty("EmpresaComplemento_Z", gxTv_SdtEmpresa_Empresacomplemento_Z, false, includeNonInitialized);
            AddObjectProperty("MunicipioCodigo_Z", gxTv_SdtEmpresa_Municipiocodigo_Z, false, includeNonInitialized);
            AddObjectProperty("MunicipioNome_Z", gxTv_SdtEmpresa_Municipionome_Z, false, includeNonInitialized);
            AddObjectProperty("MunicipioUF_Z", gxTv_SdtEmpresa_Municipiouf_Z, false, includeNonInitialized);
            AddObjectProperty("EmpresaRepresentanteCPF_Z", gxTv_SdtEmpresa_Empresarepresentantecpf_Z, false, includeNonInitialized);
            AddObjectProperty("EmpresaRepresentanteNome_Z", gxTv_SdtEmpresa_Empresarepresentantenome_Z, false, includeNonInitialized);
            AddObjectProperty("EmpresaRepresentanteEmail_Z", gxTv_SdtEmpresa_Empresarepresentanteemail_Z, false, includeNonInitialized);
            AddObjectProperty("EmpresaUtilizaRepresentanteAssinatura_Z", gxTv_SdtEmpresa_Empresautilizarepresentanteassinatura_Z, false, includeNonInitialized);
            AddObjectProperty("EmpresaRepresentanteLogradouro_Z", gxTv_SdtEmpresa_Empresarepresentantelogradouro_Z, false, includeNonInitialized);
            AddObjectProperty("EmpresaRepresentanteNumero_Z", gxTv_SdtEmpresa_Empresarepresentantenumero_Z, false, includeNonInitialized);
            AddObjectProperty("EmpresaRepresentanteCEP_Z", gxTv_SdtEmpresa_Empresarepresentantecep_Z, false, includeNonInitialized);
            AddObjectProperty("EmpresaRepresentanteBairro_Z", gxTv_SdtEmpresa_Empresarepresentantebairro_Z, false, includeNonInitialized);
            AddObjectProperty("EmpresaRepresentanteComplemento_Z", gxTv_SdtEmpresa_Empresarepresentantecomplemento_Z, false, includeNonInitialized);
            AddObjectProperty("EmpresaRepresentanteMunicipio_Z", gxTv_SdtEmpresa_Empresarepresentantemunicipio_Z, false, includeNonInitialized);
            AddObjectProperty("EmpresaRepresentanteMunicipioNome_Z", gxTv_SdtEmpresa_Empresarepresentantemunicipionome_Z, false, includeNonInitialized);
            AddObjectProperty("EmpresaRepresentanteMunicipioUF_Z", gxTv_SdtEmpresa_Empresarepresentantemunicipiouf_Z, false, includeNonInitialized);
            AddObjectProperty("EmpresaRepresentanteNacionalidade_Z", gxTv_SdtEmpresa_Empresarepresentantenacionalidade_Z, false, includeNonInitialized);
            AddObjectProperty("EmpresaRepresentanteProfissao_Z", gxTv_SdtEmpresa_Empresarepresentanteprofissao_Z, false, includeNonInitialized);
            AddObjectProperty("EmpresaRepresentanteTelefone_Z", gxTv_SdtEmpresa_Empresarepresentantetelefone_Z, false, includeNonInitialized);
            AddObjectProperty("EmpresaRepresentanteTelefoneDDD_Z", gxTv_SdtEmpresa_Empresarepresentantetelefoneddd_Z, false, includeNonInitialized);
            AddObjectProperty("EmpresaNomeFantasia_N", gxTv_SdtEmpresa_Empresanomefantasia_N, false, includeNonInitialized);
            AddObjectProperty("EmpresaRazaoSocial_N", gxTv_SdtEmpresa_Empresarazaosocial_N, false, includeNonInitialized);
            AddObjectProperty("EmpresaCNPJ_N", gxTv_SdtEmpresa_Empresacnpj_N, false, includeNonInitialized);
            AddObjectProperty("EmpresaSede_N", gxTv_SdtEmpresa_Empresasede_N, false, includeNonInitialized);
            AddObjectProperty("EmpresaBancoId_N", gxTv_SdtEmpresa_Empresabancoid_N, false, includeNonInitialized);
            AddObjectProperty("BancoNome_N", gxTv_SdtEmpresa_Banconome_N, false, includeNonInitialized);
            AddObjectProperty("EmpresaAgencia_N", gxTv_SdtEmpresa_Empresaagencia_N, false, includeNonInitialized);
            AddObjectProperty("EmpresaAgenciaDigito_N", gxTv_SdtEmpresa_Empresaagenciadigito_N, false, includeNonInitialized);
            AddObjectProperty("EmpresaConta_N", gxTv_SdtEmpresa_Empresaconta_N, false, includeNonInitialized);
            AddObjectProperty("EmpresaPix_N", gxTv_SdtEmpresa_Empresapix_N, false, includeNonInitialized);
            AddObjectProperty("EmpresaPixTipo_N", gxTv_SdtEmpresa_Empresapixtipo_N, false, includeNonInitialized);
            AddObjectProperty("EmpresaEmail_N", gxTv_SdtEmpresa_Empresaemail_N, false, includeNonInitialized);
            AddObjectProperty("EmpresaLogradouro_N", gxTv_SdtEmpresa_Empresalogradouro_N, false, includeNonInitialized);
            AddObjectProperty("EmpresaLogradouroNumero_N", gxTv_SdtEmpresa_Empresalogradouronumero_N, false, includeNonInitialized);
            AddObjectProperty("EmpresaCEP_N", gxTv_SdtEmpresa_Empresacep_N, false, includeNonInitialized);
            AddObjectProperty("EmpresaBairro_N", gxTv_SdtEmpresa_Empresabairro_N, false, includeNonInitialized);
            AddObjectProperty("EmpresaComplemento_N", gxTv_SdtEmpresa_Empresacomplemento_N, false, includeNonInitialized);
            AddObjectProperty("MunicipioCodigo_N", gxTv_SdtEmpresa_Municipiocodigo_N, false, includeNonInitialized);
            AddObjectProperty("MunicipioNome_N", gxTv_SdtEmpresa_Municipionome_N, false, includeNonInitialized);
            AddObjectProperty("MunicipioUF_N", gxTv_SdtEmpresa_Municipiouf_N, false, includeNonInitialized);
            AddObjectProperty("EmpresaRepresentanteCPF_N", gxTv_SdtEmpresa_Empresarepresentantecpf_N, false, includeNonInitialized);
            AddObjectProperty("EmpresaRepresentanteNome_N", gxTv_SdtEmpresa_Empresarepresentantenome_N, false, includeNonInitialized);
            AddObjectProperty("EmpresaRepresentanteEmail_N", gxTv_SdtEmpresa_Empresarepresentanteemail_N, false, includeNonInitialized);
            AddObjectProperty("EmpresaUtilizaRepresentanteAssinatura_N", gxTv_SdtEmpresa_Empresautilizarepresentanteassinatura_N, false, includeNonInitialized);
            AddObjectProperty("EmpresaRepresentanteLogradouro_N", gxTv_SdtEmpresa_Empresarepresentantelogradouro_N, false, includeNonInitialized);
            AddObjectProperty("EmpresaRepresentanteNumero_N", gxTv_SdtEmpresa_Empresarepresentantenumero_N, false, includeNonInitialized);
            AddObjectProperty("EmpresaRepresentanteCEP_N", gxTv_SdtEmpresa_Empresarepresentantecep_N, false, includeNonInitialized);
            AddObjectProperty("EmpresaRepresentanteBairro_N", gxTv_SdtEmpresa_Empresarepresentantebairro_N, false, includeNonInitialized);
            AddObjectProperty("EmpresaRepresentanteComplemento_N", gxTv_SdtEmpresa_Empresarepresentantecomplemento_N, false, includeNonInitialized);
            AddObjectProperty("EmpresaRepresentanteMunicipio_N", gxTv_SdtEmpresa_Empresarepresentantemunicipio_N, false, includeNonInitialized);
            AddObjectProperty("EmpresaRepresentanteMunicipioNome_N", gxTv_SdtEmpresa_Empresarepresentantemunicipionome_N, false, includeNonInitialized);
            AddObjectProperty("EmpresaRepresentanteMunicipioUF_N", gxTv_SdtEmpresa_Empresarepresentantemunicipiouf_N, false, includeNonInitialized);
            AddObjectProperty("EmpresaRepresentanteNacionalidade_N", gxTv_SdtEmpresa_Empresarepresentantenacionalidade_N, false, includeNonInitialized);
            AddObjectProperty("EmpresaRepresentanteProfissao_N", gxTv_SdtEmpresa_Empresarepresentanteprofissao_N, false, includeNonInitialized);
            AddObjectProperty("EmpresaRepresentanteTelefone_N", gxTv_SdtEmpresa_Empresarepresentantetelefone_N, false, includeNonInitialized);
            AddObjectProperty("EmpresaRepresentanteTelefoneDDD_N", gxTv_SdtEmpresa_Empresarepresentantetelefoneddd_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtEmpresa sdt )
      {
         if ( sdt.IsDirty("EmpresaId") )
         {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresaid = sdt.gxTv_SdtEmpresa_Empresaid ;
         }
         if ( sdt.IsDirty("EmpresaNomeFantasia") )
         {
            gxTv_SdtEmpresa_Empresanomefantasia_N = (short)(sdt.gxTv_SdtEmpresa_Empresanomefantasia_N);
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresanomefantasia = sdt.gxTv_SdtEmpresa_Empresanomefantasia ;
         }
         if ( sdt.IsDirty("EmpresaRazaoSocial") )
         {
            gxTv_SdtEmpresa_Empresarazaosocial_N = (short)(sdt.gxTv_SdtEmpresa_Empresarazaosocial_N);
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarazaosocial = sdt.gxTv_SdtEmpresa_Empresarazaosocial ;
         }
         if ( sdt.IsDirty("EmpresaCNPJ") )
         {
            gxTv_SdtEmpresa_Empresacnpj_N = (short)(sdt.gxTv_SdtEmpresa_Empresacnpj_N);
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresacnpj = sdt.gxTv_SdtEmpresa_Empresacnpj ;
         }
         if ( sdt.IsDirty("EmpresaSede") )
         {
            gxTv_SdtEmpresa_Empresasede_N = (short)(sdt.gxTv_SdtEmpresa_Empresasede_N);
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresasede = sdt.gxTv_SdtEmpresa_Empresasede ;
         }
         if ( sdt.IsDirty("EmpresaBancoId") )
         {
            gxTv_SdtEmpresa_Empresabancoid_N = (short)(sdt.gxTv_SdtEmpresa_Empresabancoid_N);
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresabancoid = sdt.gxTv_SdtEmpresa_Empresabancoid ;
         }
         if ( sdt.IsDirty("BancoNome") )
         {
            gxTv_SdtEmpresa_Banconome_N = (short)(sdt.gxTv_SdtEmpresa_Banconome_N);
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Banconome = sdt.gxTv_SdtEmpresa_Banconome ;
         }
         if ( sdt.IsDirty("EmpresaAgencia") )
         {
            gxTv_SdtEmpresa_Empresaagencia_N = (short)(sdt.gxTv_SdtEmpresa_Empresaagencia_N);
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresaagencia = sdt.gxTv_SdtEmpresa_Empresaagencia ;
         }
         if ( sdt.IsDirty("EmpresaAgenciaDigito") )
         {
            gxTv_SdtEmpresa_Empresaagenciadigito_N = (short)(sdt.gxTv_SdtEmpresa_Empresaagenciadigito_N);
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresaagenciadigito = sdt.gxTv_SdtEmpresa_Empresaagenciadigito ;
         }
         if ( sdt.IsDirty("EmpresaConta") )
         {
            gxTv_SdtEmpresa_Empresaconta_N = (short)(sdt.gxTv_SdtEmpresa_Empresaconta_N);
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresaconta = sdt.gxTv_SdtEmpresa_Empresaconta ;
         }
         if ( sdt.IsDirty("EmpresaPix") )
         {
            gxTv_SdtEmpresa_Empresapix_N = (short)(sdt.gxTv_SdtEmpresa_Empresapix_N);
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresapix = sdt.gxTv_SdtEmpresa_Empresapix ;
         }
         if ( sdt.IsDirty("EmpresaPixTipo") )
         {
            gxTv_SdtEmpresa_Empresapixtipo_N = (short)(sdt.gxTv_SdtEmpresa_Empresapixtipo_N);
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresapixtipo = sdt.gxTv_SdtEmpresa_Empresapixtipo ;
         }
         if ( sdt.IsDirty("EmpresaEmail") )
         {
            gxTv_SdtEmpresa_Empresaemail_N = (short)(sdt.gxTv_SdtEmpresa_Empresaemail_N);
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresaemail = sdt.gxTv_SdtEmpresa_Empresaemail ;
         }
         if ( sdt.IsDirty("EmpresaLogradouro") )
         {
            gxTv_SdtEmpresa_Empresalogradouro_N = (short)(sdt.gxTv_SdtEmpresa_Empresalogradouro_N);
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresalogradouro = sdt.gxTv_SdtEmpresa_Empresalogradouro ;
         }
         if ( sdt.IsDirty("EmpresaLogradouroNumero") )
         {
            gxTv_SdtEmpresa_Empresalogradouronumero_N = (short)(sdt.gxTv_SdtEmpresa_Empresalogradouronumero_N);
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresalogradouronumero = sdt.gxTv_SdtEmpresa_Empresalogradouronumero ;
         }
         if ( sdt.IsDirty("EmpresaCEP") )
         {
            gxTv_SdtEmpresa_Empresacep_N = (short)(sdt.gxTv_SdtEmpresa_Empresacep_N);
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresacep = sdt.gxTv_SdtEmpresa_Empresacep ;
         }
         if ( sdt.IsDirty("EmpresaBairro") )
         {
            gxTv_SdtEmpresa_Empresabairro_N = (short)(sdt.gxTv_SdtEmpresa_Empresabairro_N);
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresabairro = sdt.gxTv_SdtEmpresa_Empresabairro ;
         }
         if ( sdt.IsDirty("EmpresaComplemento") )
         {
            gxTv_SdtEmpresa_Empresacomplemento_N = (short)(sdt.gxTv_SdtEmpresa_Empresacomplemento_N);
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresacomplemento = sdt.gxTv_SdtEmpresa_Empresacomplemento ;
         }
         if ( sdt.IsDirty("MunicipioCodigo") )
         {
            gxTv_SdtEmpresa_Municipiocodigo_N = (short)(sdt.gxTv_SdtEmpresa_Municipiocodigo_N);
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Municipiocodigo = sdt.gxTv_SdtEmpresa_Municipiocodigo ;
         }
         if ( sdt.IsDirty("MunicipioNome") )
         {
            gxTv_SdtEmpresa_Municipionome_N = (short)(sdt.gxTv_SdtEmpresa_Municipionome_N);
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Municipionome = sdt.gxTv_SdtEmpresa_Municipionome ;
         }
         if ( sdt.IsDirty("MunicipioUF") )
         {
            gxTv_SdtEmpresa_Municipiouf_N = (short)(sdt.gxTv_SdtEmpresa_Municipiouf_N);
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Municipiouf = sdt.gxTv_SdtEmpresa_Municipiouf ;
         }
         if ( sdt.IsDirty("EmpresaRepresentanteCPF") )
         {
            gxTv_SdtEmpresa_Empresarepresentantecpf_N = (short)(sdt.gxTv_SdtEmpresa_Empresarepresentantecpf_N);
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantecpf = sdt.gxTv_SdtEmpresa_Empresarepresentantecpf ;
         }
         if ( sdt.IsDirty("EmpresaRepresentanteNome") )
         {
            gxTv_SdtEmpresa_Empresarepresentantenome_N = (short)(sdt.gxTv_SdtEmpresa_Empresarepresentantenome_N);
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantenome = sdt.gxTv_SdtEmpresa_Empresarepresentantenome ;
         }
         if ( sdt.IsDirty("EmpresaRepresentanteEmail") )
         {
            gxTv_SdtEmpresa_Empresarepresentanteemail_N = (short)(sdt.gxTv_SdtEmpresa_Empresarepresentanteemail_N);
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentanteemail = sdt.gxTv_SdtEmpresa_Empresarepresentanteemail ;
         }
         if ( sdt.IsDirty("EmpresaUtilizaRepresentanteAssinatura") )
         {
            gxTv_SdtEmpresa_Empresautilizarepresentanteassinatura_N = (short)(sdt.gxTv_SdtEmpresa_Empresautilizarepresentanteassinatura_N);
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresautilizarepresentanteassinatura = sdt.gxTv_SdtEmpresa_Empresautilizarepresentanteassinatura ;
         }
         if ( sdt.IsDirty("EmpresaRepresentanteLogradouro") )
         {
            gxTv_SdtEmpresa_Empresarepresentantelogradouro_N = (short)(sdt.gxTv_SdtEmpresa_Empresarepresentantelogradouro_N);
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantelogradouro = sdt.gxTv_SdtEmpresa_Empresarepresentantelogradouro ;
         }
         if ( sdt.IsDirty("EmpresaRepresentanteNumero") )
         {
            gxTv_SdtEmpresa_Empresarepresentantenumero_N = (short)(sdt.gxTv_SdtEmpresa_Empresarepresentantenumero_N);
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantenumero = sdt.gxTv_SdtEmpresa_Empresarepresentantenumero ;
         }
         if ( sdt.IsDirty("EmpresaRepresentanteCEP") )
         {
            gxTv_SdtEmpresa_Empresarepresentantecep_N = (short)(sdt.gxTv_SdtEmpresa_Empresarepresentantecep_N);
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantecep = sdt.gxTv_SdtEmpresa_Empresarepresentantecep ;
         }
         if ( sdt.IsDirty("EmpresaRepresentanteBairro") )
         {
            gxTv_SdtEmpresa_Empresarepresentantebairro_N = (short)(sdt.gxTv_SdtEmpresa_Empresarepresentantebairro_N);
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantebairro = sdt.gxTv_SdtEmpresa_Empresarepresentantebairro ;
         }
         if ( sdt.IsDirty("EmpresaRepresentanteComplemento") )
         {
            gxTv_SdtEmpresa_Empresarepresentantecomplemento_N = (short)(sdt.gxTv_SdtEmpresa_Empresarepresentantecomplemento_N);
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantecomplemento = sdt.gxTv_SdtEmpresa_Empresarepresentantecomplemento ;
         }
         if ( sdt.IsDirty("EmpresaRepresentanteMunicipio") )
         {
            gxTv_SdtEmpresa_Empresarepresentantemunicipio_N = (short)(sdt.gxTv_SdtEmpresa_Empresarepresentantemunicipio_N);
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantemunicipio = sdt.gxTv_SdtEmpresa_Empresarepresentantemunicipio ;
         }
         if ( sdt.IsDirty("EmpresaRepresentanteMunicipioNome") )
         {
            gxTv_SdtEmpresa_Empresarepresentantemunicipionome_N = (short)(sdt.gxTv_SdtEmpresa_Empresarepresentantemunicipionome_N);
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantemunicipionome = sdt.gxTv_SdtEmpresa_Empresarepresentantemunicipionome ;
         }
         if ( sdt.IsDirty("EmpresaRepresentanteMunicipioUF") )
         {
            gxTv_SdtEmpresa_Empresarepresentantemunicipiouf_N = (short)(sdt.gxTv_SdtEmpresa_Empresarepresentantemunicipiouf_N);
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantemunicipiouf = sdt.gxTv_SdtEmpresa_Empresarepresentantemunicipiouf ;
         }
         if ( sdt.IsDirty("EmpresaRepresentanteNacionalidade") )
         {
            gxTv_SdtEmpresa_Empresarepresentantenacionalidade_N = (short)(sdt.gxTv_SdtEmpresa_Empresarepresentantenacionalidade_N);
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantenacionalidade = sdt.gxTv_SdtEmpresa_Empresarepresentantenacionalidade ;
         }
         if ( sdt.IsDirty("EmpresaRepresentanteProfissao") )
         {
            gxTv_SdtEmpresa_Empresarepresentanteprofissao_N = (short)(sdt.gxTv_SdtEmpresa_Empresarepresentanteprofissao_N);
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentanteprofissao = sdt.gxTv_SdtEmpresa_Empresarepresentanteprofissao ;
         }
         if ( sdt.IsDirty("EmpresaRepresentanteTelefone") )
         {
            gxTv_SdtEmpresa_Empresarepresentantetelefone_N = (short)(sdt.gxTv_SdtEmpresa_Empresarepresentantetelefone_N);
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantetelefone = sdt.gxTv_SdtEmpresa_Empresarepresentantetelefone ;
         }
         if ( sdt.IsDirty("EmpresaRepresentanteTelefoneDDD") )
         {
            gxTv_SdtEmpresa_Empresarepresentantetelefoneddd_N = (short)(sdt.gxTv_SdtEmpresa_Empresarepresentantetelefoneddd_N);
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantetelefoneddd = sdt.gxTv_SdtEmpresa_Empresarepresentantetelefoneddd ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "EmpresaId" )]
      [  XmlElement( ElementName = "EmpresaId"   )]
      public int gxTpr_Empresaid
      {
         get {
            return gxTv_SdtEmpresa_Empresaid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtEmpresa_Empresaid != value )
            {
               gxTv_SdtEmpresa_Mode = "INS";
               this.gxTv_SdtEmpresa_Empresaid_Z_SetNull( );
               this.gxTv_SdtEmpresa_Empresanomefantasia_Z_SetNull( );
               this.gxTv_SdtEmpresa_Empresarazaosocial_Z_SetNull( );
               this.gxTv_SdtEmpresa_Empresacnpj_Z_SetNull( );
               this.gxTv_SdtEmpresa_Empresasede_Z_SetNull( );
               this.gxTv_SdtEmpresa_Empresabancoid_Z_SetNull( );
               this.gxTv_SdtEmpresa_Banconome_Z_SetNull( );
               this.gxTv_SdtEmpresa_Empresaagencia_Z_SetNull( );
               this.gxTv_SdtEmpresa_Empresaagenciadigito_Z_SetNull( );
               this.gxTv_SdtEmpresa_Empresaconta_Z_SetNull( );
               this.gxTv_SdtEmpresa_Empresapix_Z_SetNull( );
               this.gxTv_SdtEmpresa_Empresapixtipo_Z_SetNull( );
               this.gxTv_SdtEmpresa_Empresaemail_Z_SetNull( );
               this.gxTv_SdtEmpresa_Empresalogradouro_Z_SetNull( );
               this.gxTv_SdtEmpresa_Empresalogradouronumero_Z_SetNull( );
               this.gxTv_SdtEmpresa_Empresacep_Z_SetNull( );
               this.gxTv_SdtEmpresa_Empresabairro_Z_SetNull( );
               this.gxTv_SdtEmpresa_Empresacomplemento_Z_SetNull( );
               this.gxTv_SdtEmpresa_Municipiocodigo_Z_SetNull( );
               this.gxTv_SdtEmpresa_Municipionome_Z_SetNull( );
               this.gxTv_SdtEmpresa_Municipiouf_Z_SetNull( );
               this.gxTv_SdtEmpresa_Empresarepresentantecpf_Z_SetNull( );
               this.gxTv_SdtEmpresa_Empresarepresentantenome_Z_SetNull( );
               this.gxTv_SdtEmpresa_Empresarepresentanteemail_Z_SetNull( );
               this.gxTv_SdtEmpresa_Empresautilizarepresentanteassinatura_Z_SetNull( );
               this.gxTv_SdtEmpresa_Empresarepresentantelogradouro_Z_SetNull( );
               this.gxTv_SdtEmpresa_Empresarepresentantenumero_Z_SetNull( );
               this.gxTv_SdtEmpresa_Empresarepresentantecep_Z_SetNull( );
               this.gxTv_SdtEmpresa_Empresarepresentantebairro_Z_SetNull( );
               this.gxTv_SdtEmpresa_Empresarepresentantecomplemento_Z_SetNull( );
               this.gxTv_SdtEmpresa_Empresarepresentantemunicipio_Z_SetNull( );
               this.gxTv_SdtEmpresa_Empresarepresentantemunicipionome_Z_SetNull( );
               this.gxTv_SdtEmpresa_Empresarepresentantemunicipiouf_Z_SetNull( );
               this.gxTv_SdtEmpresa_Empresarepresentantenacionalidade_Z_SetNull( );
               this.gxTv_SdtEmpresa_Empresarepresentanteprofissao_Z_SetNull( );
               this.gxTv_SdtEmpresa_Empresarepresentantetelefone_Z_SetNull( );
               this.gxTv_SdtEmpresa_Empresarepresentantetelefoneddd_Z_SetNull( );
            }
            gxTv_SdtEmpresa_Empresaid = value;
            SetDirty("Empresaid");
         }

      }

      [  SoapElement( ElementName = "EmpresaNomeFantasia" )]
      [  XmlElement( ElementName = "EmpresaNomeFantasia"   )]
      public string gxTpr_Empresanomefantasia
      {
         get {
            return gxTv_SdtEmpresa_Empresanomefantasia ;
         }

         set {
            gxTv_SdtEmpresa_Empresanomefantasia_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresanomefantasia = value;
            SetDirty("Empresanomefantasia");
         }

      }

      public void gxTv_SdtEmpresa_Empresanomefantasia_SetNull( )
      {
         gxTv_SdtEmpresa_Empresanomefantasia_N = 1;
         gxTv_SdtEmpresa_Empresanomefantasia = "";
         SetDirty("Empresanomefantasia");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresanomefantasia_IsNull( )
      {
         return (gxTv_SdtEmpresa_Empresanomefantasia_N==1) ;
      }

      [  SoapElement( ElementName = "EmpresaRazaoSocial" )]
      [  XmlElement( ElementName = "EmpresaRazaoSocial"   )]
      public string gxTpr_Empresarazaosocial
      {
         get {
            return gxTv_SdtEmpresa_Empresarazaosocial ;
         }

         set {
            gxTv_SdtEmpresa_Empresarazaosocial_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarazaosocial = value;
            SetDirty("Empresarazaosocial");
         }

      }

      public void gxTv_SdtEmpresa_Empresarazaosocial_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarazaosocial_N = 1;
         gxTv_SdtEmpresa_Empresarazaosocial = "";
         SetDirty("Empresarazaosocial");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarazaosocial_IsNull( )
      {
         return (gxTv_SdtEmpresa_Empresarazaosocial_N==1) ;
      }

      [  SoapElement( ElementName = "EmpresaCNPJ" )]
      [  XmlElement( ElementName = "EmpresaCNPJ"   )]
      public string gxTpr_Empresacnpj
      {
         get {
            return gxTv_SdtEmpresa_Empresacnpj ;
         }

         set {
            gxTv_SdtEmpresa_Empresacnpj_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresacnpj = value;
            SetDirty("Empresacnpj");
         }

      }

      public void gxTv_SdtEmpresa_Empresacnpj_SetNull( )
      {
         gxTv_SdtEmpresa_Empresacnpj_N = 1;
         gxTv_SdtEmpresa_Empresacnpj = "";
         SetDirty("Empresacnpj");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresacnpj_IsNull( )
      {
         return (gxTv_SdtEmpresa_Empresacnpj_N==1) ;
      }

      [  SoapElement( ElementName = "EmpresaSede" )]
      [  XmlElement( ElementName = "EmpresaSede"   )]
      public bool gxTpr_Empresasede
      {
         get {
            return gxTv_SdtEmpresa_Empresasede ;
         }

         set {
            gxTv_SdtEmpresa_Empresasede_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresasede = value;
            SetDirty("Empresasede");
         }

      }

      public void gxTv_SdtEmpresa_Empresasede_SetNull( )
      {
         gxTv_SdtEmpresa_Empresasede_N = 1;
         gxTv_SdtEmpresa_Empresasede = false;
         SetDirty("Empresasede");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresasede_IsNull( )
      {
         return (gxTv_SdtEmpresa_Empresasede_N==1) ;
      }

      [  SoapElement( ElementName = "EmpresaBancoId" )]
      [  XmlElement( ElementName = "EmpresaBancoId"   )]
      public int gxTpr_Empresabancoid
      {
         get {
            return gxTv_SdtEmpresa_Empresabancoid ;
         }

         set {
            gxTv_SdtEmpresa_Empresabancoid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresabancoid = value;
            SetDirty("Empresabancoid");
         }

      }

      public void gxTv_SdtEmpresa_Empresabancoid_SetNull( )
      {
         gxTv_SdtEmpresa_Empresabancoid_N = 1;
         gxTv_SdtEmpresa_Empresabancoid = 0;
         SetDirty("Empresabancoid");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresabancoid_IsNull( )
      {
         return (gxTv_SdtEmpresa_Empresabancoid_N==1) ;
      }

      [  SoapElement( ElementName = "BancoNome" )]
      [  XmlElement( ElementName = "BancoNome"   )]
      public string gxTpr_Banconome
      {
         get {
            return gxTv_SdtEmpresa_Banconome ;
         }

         set {
            gxTv_SdtEmpresa_Banconome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Banconome = value;
            SetDirty("Banconome");
         }

      }

      public void gxTv_SdtEmpresa_Banconome_SetNull( )
      {
         gxTv_SdtEmpresa_Banconome_N = 1;
         gxTv_SdtEmpresa_Banconome = "";
         SetDirty("Banconome");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Banconome_IsNull( )
      {
         return (gxTv_SdtEmpresa_Banconome_N==1) ;
      }

      [  SoapElement( ElementName = "EmpresaAgencia" )]
      [  XmlElement( ElementName = "EmpresaAgencia"   )]
      public int gxTpr_Empresaagencia
      {
         get {
            return gxTv_SdtEmpresa_Empresaagencia ;
         }

         set {
            gxTv_SdtEmpresa_Empresaagencia_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresaagencia = value;
            SetDirty("Empresaagencia");
         }

      }

      public void gxTv_SdtEmpresa_Empresaagencia_SetNull( )
      {
         gxTv_SdtEmpresa_Empresaagencia_N = 1;
         gxTv_SdtEmpresa_Empresaagencia = 0;
         SetDirty("Empresaagencia");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresaagencia_IsNull( )
      {
         return (gxTv_SdtEmpresa_Empresaagencia_N==1) ;
      }

      [  SoapElement( ElementName = "EmpresaAgenciaDigito" )]
      [  XmlElement( ElementName = "EmpresaAgenciaDigito"   )]
      public int gxTpr_Empresaagenciadigito
      {
         get {
            return gxTv_SdtEmpresa_Empresaagenciadigito ;
         }

         set {
            gxTv_SdtEmpresa_Empresaagenciadigito_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresaagenciadigito = value;
            SetDirty("Empresaagenciadigito");
         }

      }

      public void gxTv_SdtEmpresa_Empresaagenciadigito_SetNull( )
      {
         gxTv_SdtEmpresa_Empresaagenciadigito_N = 1;
         gxTv_SdtEmpresa_Empresaagenciadigito = 0;
         SetDirty("Empresaagenciadigito");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresaagenciadigito_IsNull( )
      {
         return (gxTv_SdtEmpresa_Empresaagenciadigito_N==1) ;
      }

      [  SoapElement( ElementName = "EmpresaConta" )]
      [  XmlElement( ElementName = "EmpresaConta"   )]
      public int gxTpr_Empresaconta
      {
         get {
            return gxTv_SdtEmpresa_Empresaconta ;
         }

         set {
            gxTv_SdtEmpresa_Empresaconta_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresaconta = value;
            SetDirty("Empresaconta");
         }

      }

      public void gxTv_SdtEmpresa_Empresaconta_SetNull( )
      {
         gxTv_SdtEmpresa_Empresaconta_N = 1;
         gxTv_SdtEmpresa_Empresaconta = 0;
         SetDirty("Empresaconta");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresaconta_IsNull( )
      {
         return (gxTv_SdtEmpresa_Empresaconta_N==1) ;
      }

      [  SoapElement( ElementName = "EmpresaPix" )]
      [  XmlElement( ElementName = "EmpresaPix"   )]
      public string gxTpr_Empresapix
      {
         get {
            return gxTv_SdtEmpresa_Empresapix ;
         }

         set {
            gxTv_SdtEmpresa_Empresapix_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresapix = value;
            SetDirty("Empresapix");
         }

      }

      public void gxTv_SdtEmpresa_Empresapix_SetNull( )
      {
         gxTv_SdtEmpresa_Empresapix_N = 1;
         gxTv_SdtEmpresa_Empresapix = "";
         SetDirty("Empresapix");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresapix_IsNull( )
      {
         return (gxTv_SdtEmpresa_Empresapix_N==1) ;
      }

      [  SoapElement( ElementName = "EmpresaPixTipo" )]
      [  XmlElement( ElementName = "EmpresaPixTipo"   )]
      public string gxTpr_Empresapixtipo
      {
         get {
            return gxTv_SdtEmpresa_Empresapixtipo ;
         }

         set {
            gxTv_SdtEmpresa_Empresapixtipo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresapixtipo = value;
            SetDirty("Empresapixtipo");
         }

      }

      public void gxTv_SdtEmpresa_Empresapixtipo_SetNull( )
      {
         gxTv_SdtEmpresa_Empresapixtipo_N = 1;
         gxTv_SdtEmpresa_Empresapixtipo = "";
         SetDirty("Empresapixtipo");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresapixtipo_IsNull( )
      {
         return (gxTv_SdtEmpresa_Empresapixtipo_N==1) ;
      }

      [  SoapElement( ElementName = "EmpresaEmail" )]
      [  XmlElement( ElementName = "EmpresaEmail"   )]
      public string gxTpr_Empresaemail
      {
         get {
            return gxTv_SdtEmpresa_Empresaemail ;
         }

         set {
            gxTv_SdtEmpresa_Empresaemail_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresaemail = value;
            SetDirty("Empresaemail");
         }

      }

      public void gxTv_SdtEmpresa_Empresaemail_SetNull( )
      {
         gxTv_SdtEmpresa_Empresaemail_N = 1;
         gxTv_SdtEmpresa_Empresaemail = "";
         SetDirty("Empresaemail");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresaemail_IsNull( )
      {
         return (gxTv_SdtEmpresa_Empresaemail_N==1) ;
      }

      [  SoapElement( ElementName = "EmpresaLogradouro" )]
      [  XmlElement( ElementName = "EmpresaLogradouro"   )]
      public string gxTpr_Empresalogradouro
      {
         get {
            return gxTv_SdtEmpresa_Empresalogradouro ;
         }

         set {
            gxTv_SdtEmpresa_Empresalogradouro_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresalogradouro = value;
            SetDirty("Empresalogradouro");
         }

      }

      public void gxTv_SdtEmpresa_Empresalogradouro_SetNull( )
      {
         gxTv_SdtEmpresa_Empresalogradouro_N = 1;
         gxTv_SdtEmpresa_Empresalogradouro = "";
         SetDirty("Empresalogradouro");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresalogradouro_IsNull( )
      {
         return (gxTv_SdtEmpresa_Empresalogradouro_N==1) ;
      }

      [  SoapElement( ElementName = "EmpresaLogradouroNumero" )]
      [  XmlElement( ElementName = "EmpresaLogradouroNumero"   )]
      public long gxTpr_Empresalogradouronumero
      {
         get {
            return gxTv_SdtEmpresa_Empresalogradouronumero ;
         }

         set {
            gxTv_SdtEmpresa_Empresalogradouronumero_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresalogradouronumero = value;
            SetDirty("Empresalogradouronumero");
         }

      }

      public void gxTv_SdtEmpresa_Empresalogradouronumero_SetNull( )
      {
         gxTv_SdtEmpresa_Empresalogradouronumero_N = 1;
         gxTv_SdtEmpresa_Empresalogradouronumero = 0;
         SetDirty("Empresalogradouronumero");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresalogradouronumero_IsNull( )
      {
         return (gxTv_SdtEmpresa_Empresalogradouronumero_N==1) ;
      }

      [  SoapElement( ElementName = "EmpresaCEP" )]
      [  XmlElement( ElementName = "EmpresaCEP"   )]
      public string gxTpr_Empresacep
      {
         get {
            return gxTv_SdtEmpresa_Empresacep ;
         }

         set {
            gxTv_SdtEmpresa_Empresacep_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresacep = value;
            SetDirty("Empresacep");
         }

      }

      public void gxTv_SdtEmpresa_Empresacep_SetNull( )
      {
         gxTv_SdtEmpresa_Empresacep_N = 1;
         gxTv_SdtEmpresa_Empresacep = "";
         SetDirty("Empresacep");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresacep_IsNull( )
      {
         return (gxTv_SdtEmpresa_Empresacep_N==1) ;
      }

      [  SoapElement( ElementName = "EmpresaBairro" )]
      [  XmlElement( ElementName = "EmpresaBairro"   )]
      public string gxTpr_Empresabairro
      {
         get {
            return gxTv_SdtEmpresa_Empresabairro ;
         }

         set {
            gxTv_SdtEmpresa_Empresabairro_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresabairro = value;
            SetDirty("Empresabairro");
         }

      }

      public void gxTv_SdtEmpresa_Empresabairro_SetNull( )
      {
         gxTv_SdtEmpresa_Empresabairro_N = 1;
         gxTv_SdtEmpresa_Empresabairro = "";
         SetDirty("Empresabairro");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresabairro_IsNull( )
      {
         return (gxTv_SdtEmpresa_Empresabairro_N==1) ;
      }

      [  SoapElement( ElementName = "EmpresaComplemento" )]
      [  XmlElement( ElementName = "EmpresaComplemento"   )]
      public string gxTpr_Empresacomplemento
      {
         get {
            return gxTv_SdtEmpresa_Empresacomplemento ;
         }

         set {
            gxTv_SdtEmpresa_Empresacomplemento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresacomplemento = value;
            SetDirty("Empresacomplemento");
         }

      }

      public void gxTv_SdtEmpresa_Empresacomplemento_SetNull( )
      {
         gxTv_SdtEmpresa_Empresacomplemento_N = 1;
         gxTv_SdtEmpresa_Empresacomplemento = "";
         SetDirty("Empresacomplemento");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresacomplemento_IsNull( )
      {
         return (gxTv_SdtEmpresa_Empresacomplemento_N==1) ;
      }

      [  SoapElement( ElementName = "MunicipioCodigo" )]
      [  XmlElement( ElementName = "MunicipioCodigo"   )]
      public string gxTpr_Municipiocodigo
      {
         get {
            return gxTv_SdtEmpresa_Municipiocodigo ;
         }

         set {
            gxTv_SdtEmpresa_Municipiocodigo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Municipiocodigo = value;
            SetDirty("Municipiocodigo");
         }

      }

      public void gxTv_SdtEmpresa_Municipiocodigo_SetNull( )
      {
         gxTv_SdtEmpresa_Municipiocodigo_N = 1;
         gxTv_SdtEmpresa_Municipiocodigo = "";
         SetDirty("Municipiocodigo");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Municipiocodigo_IsNull( )
      {
         return (gxTv_SdtEmpresa_Municipiocodigo_N==1) ;
      }

      [  SoapElement( ElementName = "MunicipioNome" )]
      [  XmlElement( ElementName = "MunicipioNome"   )]
      public string gxTpr_Municipionome
      {
         get {
            return gxTv_SdtEmpresa_Municipionome ;
         }

         set {
            gxTv_SdtEmpresa_Municipionome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Municipionome = value;
            SetDirty("Municipionome");
         }

      }

      public void gxTv_SdtEmpresa_Municipionome_SetNull( )
      {
         gxTv_SdtEmpresa_Municipionome_N = 1;
         gxTv_SdtEmpresa_Municipionome = "";
         SetDirty("Municipionome");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Municipionome_IsNull( )
      {
         return (gxTv_SdtEmpresa_Municipionome_N==1) ;
      }

      [  SoapElement( ElementName = "MunicipioUF" )]
      [  XmlElement( ElementName = "MunicipioUF"   )]
      public string gxTpr_Municipiouf
      {
         get {
            return gxTv_SdtEmpresa_Municipiouf ;
         }

         set {
            gxTv_SdtEmpresa_Municipiouf_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Municipiouf = value;
            SetDirty("Municipiouf");
         }

      }

      public void gxTv_SdtEmpresa_Municipiouf_SetNull( )
      {
         gxTv_SdtEmpresa_Municipiouf_N = 1;
         gxTv_SdtEmpresa_Municipiouf = "";
         SetDirty("Municipiouf");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Municipiouf_IsNull( )
      {
         return (gxTv_SdtEmpresa_Municipiouf_N==1) ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteCPF" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteCPF"   )]
      public string gxTpr_Empresarepresentantecpf
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantecpf ;
         }

         set {
            gxTv_SdtEmpresa_Empresarepresentantecpf_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantecpf = value;
            SetDirty("Empresarepresentantecpf");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantecpf_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantecpf_N = 1;
         gxTv_SdtEmpresa_Empresarepresentantecpf = "";
         SetDirty("Empresarepresentantecpf");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantecpf_IsNull( )
      {
         return (gxTv_SdtEmpresa_Empresarepresentantecpf_N==1) ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteNome" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteNome"   )]
      public string gxTpr_Empresarepresentantenome
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantenome ;
         }

         set {
            gxTv_SdtEmpresa_Empresarepresentantenome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantenome = value;
            SetDirty("Empresarepresentantenome");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantenome_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantenome_N = 1;
         gxTv_SdtEmpresa_Empresarepresentantenome = "";
         SetDirty("Empresarepresentantenome");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantenome_IsNull( )
      {
         return (gxTv_SdtEmpresa_Empresarepresentantenome_N==1) ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteEmail" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteEmail"   )]
      public string gxTpr_Empresarepresentanteemail
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentanteemail ;
         }

         set {
            gxTv_SdtEmpresa_Empresarepresentanteemail_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentanteemail = value;
            SetDirty("Empresarepresentanteemail");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentanteemail_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentanteemail_N = 1;
         gxTv_SdtEmpresa_Empresarepresentanteemail = "";
         SetDirty("Empresarepresentanteemail");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentanteemail_IsNull( )
      {
         return (gxTv_SdtEmpresa_Empresarepresentanteemail_N==1) ;
      }

      [  SoapElement( ElementName = "EmpresaUtilizaRepresentanteAssinatura" )]
      [  XmlElement( ElementName = "EmpresaUtilizaRepresentanteAssinatura"   )]
      public bool gxTpr_Empresautilizarepresentanteassinatura
      {
         get {
            return gxTv_SdtEmpresa_Empresautilizarepresentanteassinatura ;
         }

         set {
            gxTv_SdtEmpresa_Empresautilizarepresentanteassinatura_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresautilizarepresentanteassinatura = value;
            SetDirty("Empresautilizarepresentanteassinatura");
         }

      }

      public void gxTv_SdtEmpresa_Empresautilizarepresentanteassinatura_SetNull( )
      {
         gxTv_SdtEmpresa_Empresautilizarepresentanteassinatura_N = 1;
         gxTv_SdtEmpresa_Empresautilizarepresentanteassinatura = false;
         SetDirty("Empresautilizarepresentanteassinatura");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresautilizarepresentanteassinatura_IsNull( )
      {
         return (gxTv_SdtEmpresa_Empresautilizarepresentanteassinatura_N==1) ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteLogradouro" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteLogradouro"   )]
      public string gxTpr_Empresarepresentantelogradouro
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantelogradouro ;
         }

         set {
            gxTv_SdtEmpresa_Empresarepresentantelogradouro_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantelogradouro = value;
            SetDirty("Empresarepresentantelogradouro");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantelogradouro_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantelogradouro_N = 1;
         gxTv_SdtEmpresa_Empresarepresentantelogradouro = "";
         SetDirty("Empresarepresentantelogradouro");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantelogradouro_IsNull( )
      {
         return (gxTv_SdtEmpresa_Empresarepresentantelogradouro_N==1) ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteNumero" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteNumero"   )]
      public long gxTpr_Empresarepresentantenumero
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantenumero ;
         }

         set {
            gxTv_SdtEmpresa_Empresarepresentantenumero_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantenumero = value;
            SetDirty("Empresarepresentantenumero");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantenumero_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantenumero_N = 1;
         gxTv_SdtEmpresa_Empresarepresentantenumero = 0;
         SetDirty("Empresarepresentantenumero");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantenumero_IsNull( )
      {
         return (gxTv_SdtEmpresa_Empresarepresentantenumero_N==1) ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteCEP" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteCEP"   )]
      public string gxTpr_Empresarepresentantecep
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantecep ;
         }

         set {
            gxTv_SdtEmpresa_Empresarepresentantecep_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantecep = value;
            SetDirty("Empresarepresentantecep");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantecep_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantecep_N = 1;
         gxTv_SdtEmpresa_Empresarepresentantecep = "";
         SetDirty("Empresarepresentantecep");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantecep_IsNull( )
      {
         return (gxTv_SdtEmpresa_Empresarepresentantecep_N==1) ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteBairro" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteBairro"   )]
      public string gxTpr_Empresarepresentantebairro
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantebairro ;
         }

         set {
            gxTv_SdtEmpresa_Empresarepresentantebairro_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantebairro = value;
            SetDirty("Empresarepresentantebairro");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantebairro_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantebairro_N = 1;
         gxTv_SdtEmpresa_Empresarepresentantebairro = "";
         SetDirty("Empresarepresentantebairro");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantebairro_IsNull( )
      {
         return (gxTv_SdtEmpresa_Empresarepresentantebairro_N==1) ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteComplemento" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteComplemento"   )]
      public string gxTpr_Empresarepresentantecomplemento
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantecomplemento ;
         }

         set {
            gxTv_SdtEmpresa_Empresarepresentantecomplemento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantecomplemento = value;
            SetDirty("Empresarepresentantecomplemento");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantecomplemento_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantecomplemento_N = 1;
         gxTv_SdtEmpresa_Empresarepresentantecomplemento = "";
         SetDirty("Empresarepresentantecomplemento");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantecomplemento_IsNull( )
      {
         return (gxTv_SdtEmpresa_Empresarepresentantecomplemento_N==1) ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteMunicipio" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteMunicipio"   )]
      public string gxTpr_Empresarepresentantemunicipio
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantemunicipio ;
         }

         set {
            gxTv_SdtEmpresa_Empresarepresentantemunicipio_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantemunicipio = value;
            SetDirty("Empresarepresentantemunicipio");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantemunicipio_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantemunicipio_N = 1;
         gxTv_SdtEmpresa_Empresarepresentantemunicipio = "";
         SetDirty("Empresarepresentantemunicipio");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantemunicipio_IsNull( )
      {
         return (gxTv_SdtEmpresa_Empresarepresentantemunicipio_N==1) ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteMunicipioNome" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteMunicipioNome"   )]
      public string gxTpr_Empresarepresentantemunicipionome
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantemunicipionome ;
         }

         set {
            gxTv_SdtEmpresa_Empresarepresentantemunicipionome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantemunicipionome = value;
            SetDirty("Empresarepresentantemunicipionome");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantemunicipionome_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantemunicipionome_N = 1;
         gxTv_SdtEmpresa_Empresarepresentantemunicipionome = "";
         SetDirty("Empresarepresentantemunicipionome");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantemunicipionome_IsNull( )
      {
         return (gxTv_SdtEmpresa_Empresarepresentantemunicipionome_N==1) ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteMunicipioUF" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteMunicipioUF"   )]
      public string gxTpr_Empresarepresentantemunicipiouf
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantemunicipiouf ;
         }

         set {
            gxTv_SdtEmpresa_Empresarepresentantemunicipiouf_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantemunicipiouf = value;
            SetDirty("Empresarepresentantemunicipiouf");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantemunicipiouf_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantemunicipiouf_N = 1;
         gxTv_SdtEmpresa_Empresarepresentantemunicipiouf = "";
         SetDirty("Empresarepresentantemunicipiouf");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantemunicipiouf_IsNull( )
      {
         return (gxTv_SdtEmpresa_Empresarepresentantemunicipiouf_N==1) ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteNacionalidade" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteNacionalidade"   )]
      public string gxTpr_Empresarepresentantenacionalidade
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantenacionalidade ;
         }

         set {
            gxTv_SdtEmpresa_Empresarepresentantenacionalidade_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantenacionalidade = value;
            SetDirty("Empresarepresentantenacionalidade");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantenacionalidade_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantenacionalidade_N = 1;
         gxTv_SdtEmpresa_Empresarepresentantenacionalidade = "";
         SetDirty("Empresarepresentantenacionalidade");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantenacionalidade_IsNull( )
      {
         return (gxTv_SdtEmpresa_Empresarepresentantenacionalidade_N==1) ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteProfissao" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteProfissao"   )]
      public int gxTpr_Empresarepresentanteprofissao
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentanteprofissao ;
         }

         set {
            gxTv_SdtEmpresa_Empresarepresentanteprofissao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentanteprofissao = value;
            SetDirty("Empresarepresentanteprofissao");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentanteprofissao_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentanteprofissao_N = 1;
         gxTv_SdtEmpresa_Empresarepresentanteprofissao = 0;
         SetDirty("Empresarepresentanteprofissao");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentanteprofissao_IsNull( )
      {
         return (gxTv_SdtEmpresa_Empresarepresentanteprofissao_N==1) ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteTelefone" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteTelefone"   )]
      public int gxTpr_Empresarepresentantetelefone
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantetelefone ;
         }

         set {
            gxTv_SdtEmpresa_Empresarepresentantetelefone_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantetelefone = value;
            SetDirty("Empresarepresentantetelefone");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantetelefone_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantetelefone_N = 1;
         gxTv_SdtEmpresa_Empresarepresentantetelefone = 0;
         SetDirty("Empresarepresentantetelefone");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantetelefone_IsNull( )
      {
         return (gxTv_SdtEmpresa_Empresarepresentantetelefone_N==1) ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteTelefoneDDD" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteTelefoneDDD"   )]
      public short gxTpr_Empresarepresentantetelefoneddd
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantetelefoneddd ;
         }

         set {
            gxTv_SdtEmpresa_Empresarepresentantetelefoneddd_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantetelefoneddd = value;
            SetDirty("Empresarepresentantetelefoneddd");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantetelefoneddd_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantetelefoneddd_N = 1;
         gxTv_SdtEmpresa_Empresarepresentantetelefoneddd = 0;
         SetDirty("Empresarepresentantetelefoneddd");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantetelefoneddd_IsNull( )
      {
         return (gxTv_SdtEmpresa_Empresarepresentantetelefoneddd_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtEmpresa_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtEmpresa_Mode_SetNull( )
      {
         gxTv_SdtEmpresa_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtEmpresa_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtEmpresa_Initialized_SetNull( )
      {
         gxTv_SdtEmpresa_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaId_Z" )]
      [  XmlElement( ElementName = "EmpresaId_Z"   )]
      public int gxTpr_Empresaid_Z
      {
         get {
            return gxTv_SdtEmpresa_Empresaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresaid_Z = value;
            SetDirty("Empresaid_Z");
         }

      }

      public void gxTv_SdtEmpresa_Empresaid_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Empresaid_Z = 0;
         SetDirty("Empresaid_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaNomeFantasia_Z" )]
      [  XmlElement( ElementName = "EmpresaNomeFantasia_Z"   )]
      public string gxTpr_Empresanomefantasia_Z
      {
         get {
            return gxTv_SdtEmpresa_Empresanomefantasia_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresanomefantasia_Z = value;
            SetDirty("Empresanomefantasia_Z");
         }

      }

      public void gxTv_SdtEmpresa_Empresanomefantasia_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Empresanomefantasia_Z = "";
         SetDirty("Empresanomefantasia_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresanomefantasia_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaRazaoSocial_Z" )]
      [  XmlElement( ElementName = "EmpresaRazaoSocial_Z"   )]
      public string gxTpr_Empresarazaosocial_Z
      {
         get {
            return gxTv_SdtEmpresa_Empresarazaosocial_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarazaosocial_Z = value;
            SetDirty("Empresarazaosocial_Z");
         }

      }

      public void gxTv_SdtEmpresa_Empresarazaosocial_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarazaosocial_Z = "";
         SetDirty("Empresarazaosocial_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarazaosocial_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaCNPJ_Z" )]
      [  XmlElement( ElementName = "EmpresaCNPJ_Z"   )]
      public string gxTpr_Empresacnpj_Z
      {
         get {
            return gxTv_SdtEmpresa_Empresacnpj_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresacnpj_Z = value;
            SetDirty("Empresacnpj_Z");
         }

      }

      public void gxTv_SdtEmpresa_Empresacnpj_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Empresacnpj_Z = "";
         SetDirty("Empresacnpj_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresacnpj_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaSede_Z" )]
      [  XmlElement( ElementName = "EmpresaSede_Z"   )]
      public bool gxTpr_Empresasede_Z
      {
         get {
            return gxTv_SdtEmpresa_Empresasede_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresasede_Z = value;
            SetDirty("Empresasede_Z");
         }

      }

      public void gxTv_SdtEmpresa_Empresasede_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Empresasede_Z = false;
         SetDirty("Empresasede_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresasede_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaBancoId_Z" )]
      [  XmlElement( ElementName = "EmpresaBancoId_Z"   )]
      public int gxTpr_Empresabancoid_Z
      {
         get {
            return gxTv_SdtEmpresa_Empresabancoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresabancoid_Z = value;
            SetDirty("Empresabancoid_Z");
         }

      }

      public void gxTv_SdtEmpresa_Empresabancoid_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Empresabancoid_Z = 0;
         SetDirty("Empresabancoid_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresabancoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BancoNome_Z" )]
      [  XmlElement( ElementName = "BancoNome_Z"   )]
      public string gxTpr_Banconome_Z
      {
         get {
            return gxTv_SdtEmpresa_Banconome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Banconome_Z = value;
            SetDirty("Banconome_Z");
         }

      }

      public void gxTv_SdtEmpresa_Banconome_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Banconome_Z = "";
         SetDirty("Banconome_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Banconome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaAgencia_Z" )]
      [  XmlElement( ElementName = "EmpresaAgencia_Z"   )]
      public int gxTpr_Empresaagencia_Z
      {
         get {
            return gxTv_SdtEmpresa_Empresaagencia_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresaagencia_Z = value;
            SetDirty("Empresaagencia_Z");
         }

      }

      public void gxTv_SdtEmpresa_Empresaagencia_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Empresaagencia_Z = 0;
         SetDirty("Empresaagencia_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresaagencia_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaAgenciaDigito_Z" )]
      [  XmlElement( ElementName = "EmpresaAgenciaDigito_Z"   )]
      public int gxTpr_Empresaagenciadigito_Z
      {
         get {
            return gxTv_SdtEmpresa_Empresaagenciadigito_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresaagenciadigito_Z = value;
            SetDirty("Empresaagenciadigito_Z");
         }

      }

      public void gxTv_SdtEmpresa_Empresaagenciadigito_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Empresaagenciadigito_Z = 0;
         SetDirty("Empresaagenciadigito_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresaagenciadigito_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaConta_Z" )]
      [  XmlElement( ElementName = "EmpresaConta_Z"   )]
      public int gxTpr_Empresaconta_Z
      {
         get {
            return gxTv_SdtEmpresa_Empresaconta_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresaconta_Z = value;
            SetDirty("Empresaconta_Z");
         }

      }

      public void gxTv_SdtEmpresa_Empresaconta_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Empresaconta_Z = 0;
         SetDirty("Empresaconta_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresaconta_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaPix_Z" )]
      [  XmlElement( ElementName = "EmpresaPix_Z"   )]
      public string gxTpr_Empresapix_Z
      {
         get {
            return gxTv_SdtEmpresa_Empresapix_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresapix_Z = value;
            SetDirty("Empresapix_Z");
         }

      }

      public void gxTv_SdtEmpresa_Empresapix_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Empresapix_Z = "";
         SetDirty("Empresapix_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresapix_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaPixTipo_Z" )]
      [  XmlElement( ElementName = "EmpresaPixTipo_Z"   )]
      public string gxTpr_Empresapixtipo_Z
      {
         get {
            return gxTv_SdtEmpresa_Empresapixtipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresapixtipo_Z = value;
            SetDirty("Empresapixtipo_Z");
         }

      }

      public void gxTv_SdtEmpresa_Empresapixtipo_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Empresapixtipo_Z = "";
         SetDirty("Empresapixtipo_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresapixtipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaEmail_Z" )]
      [  XmlElement( ElementName = "EmpresaEmail_Z"   )]
      public string gxTpr_Empresaemail_Z
      {
         get {
            return gxTv_SdtEmpresa_Empresaemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresaemail_Z = value;
            SetDirty("Empresaemail_Z");
         }

      }

      public void gxTv_SdtEmpresa_Empresaemail_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Empresaemail_Z = "";
         SetDirty("Empresaemail_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresaemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaLogradouro_Z" )]
      [  XmlElement( ElementName = "EmpresaLogradouro_Z"   )]
      public string gxTpr_Empresalogradouro_Z
      {
         get {
            return gxTv_SdtEmpresa_Empresalogradouro_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresalogradouro_Z = value;
            SetDirty("Empresalogradouro_Z");
         }

      }

      public void gxTv_SdtEmpresa_Empresalogradouro_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Empresalogradouro_Z = "";
         SetDirty("Empresalogradouro_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresalogradouro_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaLogradouroNumero_Z" )]
      [  XmlElement( ElementName = "EmpresaLogradouroNumero_Z"   )]
      public long gxTpr_Empresalogradouronumero_Z
      {
         get {
            return gxTv_SdtEmpresa_Empresalogradouronumero_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresalogradouronumero_Z = value;
            SetDirty("Empresalogradouronumero_Z");
         }

      }

      public void gxTv_SdtEmpresa_Empresalogradouronumero_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Empresalogradouronumero_Z = 0;
         SetDirty("Empresalogradouronumero_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresalogradouronumero_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaCEP_Z" )]
      [  XmlElement( ElementName = "EmpresaCEP_Z"   )]
      public string gxTpr_Empresacep_Z
      {
         get {
            return gxTv_SdtEmpresa_Empresacep_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresacep_Z = value;
            SetDirty("Empresacep_Z");
         }

      }

      public void gxTv_SdtEmpresa_Empresacep_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Empresacep_Z = "";
         SetDirty("Empresacep_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresacep_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaBairro_Z" )]
      [  XmlElement( ElementName = "EmpresaBairro_Z"   )]
      public string gxTpr_Empresabairro_Z
      {
         get {
            return gxTv_SdtEmpresa_Empresabairro_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresabairro_Z = value;
            SetDirty("Empresabairro_Z");
         }

      }

      public void gxTv_SdtEmpresa_Empresabairro_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Empresabairro_Z = "";
         SetDirty("Empresabairro_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresabairro_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaComplemento_Z" )]
      [  XmlElement( ElementName = "EmpresaComplemento_Z"   )]
      public string gxTpr_Empresacomplemento_Z
      {
         get {
            return gxTv_SdtEmpresa_Empresacomplemento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresacomplemento_Z = value;
            SetDirty("Empresacomplemento_Z");
         }

      }

      public void gxTv_SdtEmpresa_Empresacomplemento_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Empresacomplemento_Z = "";
         SetDirty("Empresacomplemento_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresacomplemento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioCodigo_Z" )]
      [  XmlElement( ElementName = "MunicipioCodigo_Z"   )]
      public string gxTpr_Municipiocodigo_Z
      {
         get {
            return gxTv_SdtEmpresa_Municipiocodigo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Municipiocodigo_Z = value;
            SetDirty("Municipiocodigo_Z");
         }

      }

      public void gxTv_SdtEmpresa_Municipiocodigo_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Municipiocodigo_Z = "";
         SetDirty("Municipiocodigo_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Municipiocodigo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioNome_Z" )]
      [  XmlElement( ElementName = "MunicipioNome_Z"   )]
      public string gxTpr_Municipionome_Z
      {
         get {
            return gxTv_SdtEmpresa_Municipionome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Municipionome_Z = value;
            SetDirty("Municipionome_Z");
         }

      }

      public void gxTv_SdtEmpresa_Municipionome_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Municipionome_Z = "";
         SetDirty("Municipionome_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Municipionome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioUF_Z" )]
      [  XmlElement( ElementName = "MunicipioUF_Z"   )]
      public string gxTpr_Municipiouf_Z
      {
         get {
            return gxTv_SdtEmpresa_Municipiouf_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Municipiouf_Z = value;
            SetDirty("Municipiouf_Z");
         }

      }

      public void gxTv_SdtEmpresa_Municipiouf_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Municipiouf_Z = "";
         SetDirty("Municipiouf_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Municipiouf_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteCPF_Z" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteCPF_Z"   )]
      public string gxTpr_Empresarepresentantecpf_Z
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantecpf_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantecpf_Z = value;
            SetDirty("Empresarepresentantecpf_Z");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantecpf_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantecpf_Z = "";
         SetDirty("Empresarepresentantecpf_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantecpf_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteNome_Z" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteNome_Z"   )]
      public string gxTpr_Empresarepresentantenome_Z
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantenome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantenome_Z = value;
            SetDirty("Empresarepresentantenome_Z");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantenome_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantenome_Z = "";
         SetDirty("Empresarepresentantenome_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantenome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteEmail_Z" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteEmail_Z"   )]
      public string gxTpr_Empresarepresentanteemail_Z
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentanteemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentanteemail_Z = value;
            SetDirty("Empresarepresentanteemail_Z");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentanteemail_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentanteemail_Z = "";
         SetDirty("Empresarepresentanteemail_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentanteemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaUtilizaRepresentanteAssinatura_Z" )]
      [  XmlElement( ElementName = "EmpresaUtilizaRepresentanteAssinatura_Z"   )]
      public bool gxTpr_Empresautilizarepresentanteassinatura_Z
      {
         get {
            return gxTv_SdtEmpresa_Empresautilizarepresentanteassinatura_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresautilizarepresentanteassinatura_Z = value;
            SetDirty("Empresautilizarepresentanteassinatura_Z");
         }

      }

      public void gxTv_SdtEmpresa_Empresautilizarepresentanteassinatura_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Empresautilizarepresentanteassinatura_Z = false;
         SetDirty("Empresautilizarepresentanteassinatura_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresautilizarepresentanteassinatura_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteLogradouro_Z" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteLogradouro_Z"   )]
      public string gxTpr_Empresarepresentantelogradouro_Z
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantelogradouro_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantelogradouro_Z = value;
            SetDirty("Empresarepresentantelogradouro_Z");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantelogradouro_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantelogradouro_Z = "";
         SetDirty("Empresarepresentantelogradouro_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantelogradouro_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteNumero_Z" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteNumero_Z"   )]
      public long gxTpr_Empresarepresentantenumero_Z
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantenumero_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantenumero_Z = value;
            SetDirty("Empresarepresentantenumero_Z");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantenumero_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantenumero_Z = 0;
         SetDirty("Empresarepresentantenumero_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantenumero_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteCEP_Z" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteCEP_Z"   )]
      public string gxTpr_Empresarepresentantecep_Z
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantecep_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantecep_Z = value;
            SetDirty("Empresarepresentantecep_Z");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantecep_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantecep_Z = "";
         SetDirty("Empresarepresentantecep_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantecep_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteBairro_Z" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteBairro_Z"   )]
      public string gxTpr_Empresarepresentantebairro_Z
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantebairro_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantebairro_Z = value;
            SetDirty("Empresarepresentantebairro_Z");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantebairro_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantebairro_Z = "";
         SetDirty("Empresarepresentantebairro_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantebairro_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteComplemento_Z" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteComplemento_Z"   )]
      public string gxTpr_Empresarepresentantecomplemento_Z
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantecomplemento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantecomplemento_Z = value;
            SetDirty("Empresarepresentantecomplemento_Z");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantecomplemento_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantecomplemento_Z = "";
         SetDirty("Empresarepresentantecomplemento_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantecomplemento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteMunicipio_Z" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteMunicipio_Z"   )]
      public string gxTpr_Empresarepresentantemunicipio_Z
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantemunicipio_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantemunicipio_Z = value;
            SetDirty("Empresarepresentantemunicipio_Z");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantemunicipio_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantemunicipio_Z = "";
         SetDirty("Empresarepresentantemunicipio_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantemunicipio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteMunicipioNome_Z" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteMunicipioNome_Z"   )]
      public string gxTpr_Empresarepresentantemunicipionome_Z
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantemunicipionome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantemunicipionome_Z = value;
            SetDirty("Empresarepresentantemunicipionome_Z");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantemunicipionome_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantemunicipionome_Z = "";
         SetDirty("Empresarepresentantemunicipionome_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantemunicipionome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteMunicipioUF_Z" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteMunicipioUF_Z"   )]
      public string gxTpr_Empresarepresentantemunicipiouf_Z
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantemunicipiouf_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantemunicipiouf_Z = value;
            SetDirty("Empresarepresentantemunicipiouf_Z");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantemunicipiouf_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantemunicipiouf_Z = "";
         SetDirty("Empresarepresentantemunicipiouf_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantemunicipiouf_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteNacionalidade_Z" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteNacionalidade_Z"   )]
      public string gxTpr_Empresarepresentantenacionalidade_Z
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantenacionalidade_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantenacionalidade_Z = value;
            SetDirty("Empresarepresentantenacionalidade_Z");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantenacionalidade_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantenacionalidade_Z = "";
         SetDirty("Empresarepresentantenacionalidade_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantenacionalidade_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteProfissao_Z" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteProfissao_Z"   )]
      public int gxTpr_Empresarepresentanteprofissao_Z
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentanteprofissao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentanteprofissao_Z = value;
            SetDirty("Empresarepresentanteprofissao_Z");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentanteprofissao_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentanteprofissao_Z = 0;
         SetDirty("Empresarepresentanteprofissao_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentanteprofissao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteTelefone_Z" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteTelefone_Z"   )]
      public int gxTpr_Empresarepresentantetelefone_Z
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantetelefone_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantetelefone_Z = value;
            SetDirty("Empresarepresentantetelefone_Z");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantetelefone_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantetelefone_Z = 0;
         SetDirty("Empresarepresentantetelefone_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantetelefone_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteTelefoneDDD_Z" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteTelefoneDDD_Z"   )]
      public short gxTpr_Empresarepresentantetelefoneddd_Z
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantetelefoneddd_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantetelefoneddd_Z = value;
            SetDirty("Empresarepresentantetelefoneddd_Z");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantetelefoneddd_Z_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantetelefoneddd_Z = 0;
         SetDirty("Empresarepresentantetelefoneddd_Z");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantetelefoneddd_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaNomeFantasia_N" )]
      [  XmlElement( ElementName = "EmpresaNomeFantasia_N"   )]
      public short gxTpr_Empresanomefantasia_N
      {
         get {
            return gxTv_SdtEmpresa_Empresanomefantasia_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresanomefantasia_N = value;
            SetDirty("Empresanomefantasia_N");
         }

      }

      public void gxTv_SdtEmpresa_Empresanomefantasia_N_SetNull( )
      {
         gxTv_SdtEmpresa_Empresanomefantasia_N = 0;
         SetDirty("Empresanomefantasia_N");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresanomefantasia_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaRazaoSocial_N" )]
      [  XmlElement( ElementName = "EmpresaRazaoSocial_N"   )]
      public short gxTpr_Empresarazaosocial_N
      {
         get {
            return gxTv_SdtEmpresa_Empresarazaosocial_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarazaosocial_N = value;
            SetDirty("Empresarazaosocial_N");
         }

      }

      public void gxTv_SdtEmpresa_Empresarazaosocial_N_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarazaosocial_N = 0;
         SetDirty("Empresarazaosocial_N");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarazaosocial_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaCNPJ_N" )]
      [  XmlElement( ElementName = "EmpresaCNPJ_N"   )]
      public short gxTpr_Empresacnpj_N
      {
         get {
            return gxTv_SdtEmpresa_Empresacnpj_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresacnpj_N = value;
            SetDirty("Empresacnpj_N");
         }

      }

      public void gxTv_SdtEmpresa_Empresacnpj_N_SetNull( )
      {
         gxTv_SdtEmpresa_Empresacnpj_N = 0;
         SetDirty("Empresacnpj_N");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresacnpj_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaSede_N" )]
      [  XmlElement( ElementName = "EmpresaSede_N"   )]
      public short gxTpr_Empresasede_N
      {
         get {
            return gxTv_SdtEmpresa_Empresasede_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresasede_N = value;
            SetDirty("Empresasede_N");
         }

      }

      public void gxTv_SdtEmpresa_Empresasede_N_SetNull( )
      {
         gxTv_SdtEmpresa_Empresasede_N = 0;
         SetDirty("Empresasede_N");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresasede_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaBancoId_N" )]
      [  XmlElement( ElementName = "EmpresaBancoId_N"   )]
      public short gxTpr_Empresabancoid_N
      {
         get {
            return gxTv_SdtEmpresa_Empresabancoid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresabancoid_N = value;
            SetDirty("Empresabancoid_N");
         }

      }

      public void gxTv_SdtEmpresa_Empresabancoid_N_SetNull( )
      {
         gxTv_SdtEmpresa_Empresabancoid_N = 0;
         SetDirty("Empresabancoid_N");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresabancoid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BancoNome_N" )]
      [  XmlElement( ElementName = "BancoNome_N"   )]
      public short gxTpr_Banconome_N
      {
         get {
            return gxTv_SdtEmpresa_Banconome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Banconome_N = value;
            SetDirty("Banconome_N");
         }

      }

      public void gxTv_SdtEmpresa_Banconome_N_SetNull( )
      {
         gxTv_SdtEmpresa_Banconome_N = 0;
         SetDirty("Banconome_N");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Banconome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaAgencia_N" )]
      [  XmlElement( ElementName = "EmpresaAgencia_N"   )]
      public short gxTpr_Empresaagencia_N
      {
         get {
            return gxTv_SdtEmpresa_Empresaagencia_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresaagencia_N = value;
            SetDirty("Empresaagencia_N");
         }

      }

      public void gxTv_SdtEmpresa_Empresaagencia_N_SetNull( )
      {
         gxTv_SdtEmpresa_Empresaagencia_N = 0;
         SetDirty("Empresaagencia_N");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresaagencia_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaAgenciaDigito_N" )]
      [  XmlElement( ElementName = "EmpresaAgenciaDigito_N"   )]
      public short gxTpr_Empresaagenciadigito_N
      {
         get {
            return gxTv_SdtEmpresa_Empresaagenciadigito_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresaagenciadigito_N = value;
            SetDirty("Empresaagenciadigito_N");
         }

      }

      public void gxTv_SdtEmpresa_Empresaagenciadigito_N_SetNull( )
      {
         gxTv_SdtEmpresa_Empresaagenciadigito_N = 0;
         SetDirty("Empresaagenciadigito_N");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresaagenciadigito_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaConta_N" )]
      [  XmlElement( ElementName = "EmpresaConta_N"   )]
      public short gxTpr_Empresaconta_N
      {
         get {
            return gxTv_SdtEmpresa_Empresaconta_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresaconta_N = value;
            SetDirty("Empresaconta_N");
         }

      }

      public void gxTv_SdtEmpresa_Empresaconta_N_SetNull( )
      {
         gxTv_SdtEmpresa_Empresaconta_N = 0;
         SetDirty("Empresaconta_N");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresaconta_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaPix_N" )]
      [  XmlElement( ElementName = "EmpresaPix_N"   )]
      public short gxTpr_Empresapix_N
      {
         get {
            return gxTv_SdtEmpresa_Empresapix_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresapix_N = value;
            SetDirty("Empresapix_N");
         }

      }

      public void gxTv_SdtEmpresa_Empresapix_N_SetNull( )
      {
         gxTv_SdtEmpresa_Empresapix_N = 0;
         SetDirty("Empresapix_N");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresapix_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaPixTipo_N" )]
      [  XmlElement( ElementName = "EmpresaPixTipo_N"   )]
      public short gxTpr_Empresapixtipo_N
      {
         get {
            return gxTv_SdtEmpresa_Empresapixtipo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresapixtipo_N = value;
            SetDirty("Empresapixtipo_N");
         }

      }

      public void gxTv_SdtEmpresa_Empresapixtipo_N_SetNull( )
      {
         gxTv_SdtEmpresa_Empresapixtipo_N = 0;
         SetDirty("Empresapixtipo_N");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresapixtipo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaEmail_N" )]
      [  XmlElement( ElementName = "EmpresaEmail_N"   )]
      public short gxTpr_Empresaemail_N
      {
         get {
            return gxTv_SdtEmpresa_Empresaemail_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresaemail_N = value;
            SetDirty("Empresaemail_N");
         }

      }

      public void gxTv_SdtEmpresa_Empresaemail_N_SetNull( )
      {
         gxTv_SdtEmpresa_Empresaemail_N = 0;
         SetDirty("Empresaemail_N");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresaemail_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaLogradouro_N" )]
      [  XmlElement( ElementName = "EmpresaLogradouro_N"   )]
      public short gxTpr_Empresalogradouro_N
      {
         get {
            return gxTv_SdtEmpresa_Empresalogradouro_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresalogradouro_N = value;
            SetDirty("Empresalogradouro_N");
         }

      }

      public void gxTv_SdtEmpresa_Empresalogradouro_N_SetNull( )
      {
         gxTv_SdtEmpresa_Empresalogradouro_N = 0;
         SetDirty("Empresalogradouro_N");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresalogradouro_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaLogradouroNumero_N" )]
      [  XmlElement( ElementName = "EmpresaLogradouroNumero_N"   )]
      public short gxTpr_Empresalogradouronumero_N
      {
         get {
            return gxTv_SdtEmpresa_Empresalogradouronumero_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresalogradouronumero_N = value;
            SetDirty("Empresalogradouronumero_N");
         }

      }

      public void gxTv_SdtEmpresa_Empresalogradouronumero_N_SetNull( )
      {
         gxTv_SdtEmpresa_Empresalogradouronumero_N = 0;
         SetDirty("Empresalogradouronumero_N");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresalogradouronumero_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaCEP_N" )]
      [  XmlElement( ElementName = "EmpresaCEP_N"   )]
      public short gxTpr_Empresacep_N
      {
         get {
            return gxTv_SdtEmpresa_Empresacep_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresacep_N = value;
            SetDirty("Empresacep_N");
         }

      }

      public void gxTv_SdtEmpresa_Empresacep_N_SetNull( )
      {
         gxTv_SdtEmpresa_Empresacep_N = 0;
         SetDirty("Empresacep_N");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresacep_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaBairro_N" )]
      [  XmlElement( ElementName = "EmpresaBairro_N"   )]
      public short gxTpr_Empresabairro_N
      {
         get {
            return gxTv_SdtEmpresa_Empresabairro_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresabairro_N = value;
            SetDirty("Empresabairro_N");
         }

      }

      public void gxTv_SdtEmpresa_Empresabairro_N_SetNull( )
      {
         gxTv_SdtEmpresa_Empresabairro_N = 0;
         SetDirty("Empresabairro_N");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresabairro_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaComplemento_N" )]
      [  XmlElement( ElementName = "EmpresaComplemento_N"   )]
      public short gxTpr_Empresacomplemento_N
      {
         get {
            return gxTv_SdtEmpresa_Empresacomplemento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresacomplemento_N = value;
            SetDirty("Empresacomplemento_N");
         }

      }

      public void gxTv_SdtEmpresa_Empresacomplemento_N_SetNull( )
      {
         gxTv_SdtEmpresa_Empresacomplemento_N = 0;
         SetDirty("Empresacomplemento_N");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresacomplemento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioCodigo_N" )]
      [  XmlElement( ElementName = "MunicipioCodigo_N"   )]
      public short gxTpr_Municipiocodigo_N
      {
         get {
            return gxTv_SdtEmpresa_Municipiocodigo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Municipiocodigo_N = value;
            SetDirty("Municipiocodigo_N");
         }

      }

      public void gxTv_SdtEmpresa_Municipiocodigo_N_SetNull( )
      {
         gxTv_SdtEmpresa_Municipiocodigo_N = 0;
         SetDirty("Municipiocodigo_N");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Municipiocodigo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioNome_N" )]
      [  XmlElement( ElementName = "MunicipioNome_N"   )]
      public short gxTpr_Municipionome_N
      {
         get {
            return gxTv_SdtEmpresa_Municipionome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Municipionome_N = value;
            SetDirty("Municipionome_N");
         }

      }

      public void gxTv_SdtEmpresa_Municipionome_N_SetNull( )
      {
         gxTv_SdtEmpresa_Municipionome_N = 0;
         SetDirty("Municipionome_N");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Municipionome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioUF_N" )]
      [  XmlElement( ElementName = "MunicipioUF_N"   )]
      public short gxTpr_Municipiouf_N
      {
         get {
            return gxTv_SdtEmpresa_Municipiouf_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Municipiouf_N = value;
            SetDirty("Municipiouf_N");
         }

      }

      public void gxTv_SdtEmpresa_Municipiouf_N_SetNull( )
      {
         gxTv_SdtEmpresa_Municipiouf_N = 0;
         SetDirty("Municipiouf_N");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Municipiouf_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteCPF_N" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteCPF_N"   )]
      public short gxTpr_Empresarepresentantecpf_N
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantecpf_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantecpf_N = value;
            SetDirty("Empresarepresentantecpf_N");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantecpf_N_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantecpf_N = 0;
         SetDirty("Empresarepresentantecpf_N");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantecpf_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteNome_N" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteNome_N"   )]
      public short gxTpr_Empresarepresentantenome_N
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantenome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantenome_N = value;
            SetDirty("Empresarepresentantenome_N");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantenome_N_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantenome_N = 0;
         SetDirty("Empresarepresentantenome_N");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantenome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteEmail_N" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteEmail_N"   )]
      public short gxTpr_Empresarepresentanteemail_N
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentanteemail_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentanteemail_N = value;
            SetDirty("Empresarepresentanteemail_N");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentanteemail_N_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentanteemail_N = 0;
         SetDirty("Empresarepresentanteemail_N");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentanteemail_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaUtilizaRepresentanteAssinatura_N" )]
      [  XmlElement( ElementName = "EmpresaUtilizaRepresentanteAssinatura_N"   )]
      public short gxTpr_Empresautilizarepresentanteassinatura_N
      {
         get {
            return gxTv_SdtEmpresa_Empresautilizarepresentanteassinatura_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresautilizarepresentanteassinatura_N = value;
            SetDirty("Empresautilizarepresentanteassinatura_N");
         }

      }

      public void gxTv_SdtEmpresa_Empresautilizarepresentanteassinatura_N_SetNull( )
      {
         gxTv_SdtEmpresa_Empresautilizarepresentanteassinatura_N = 0;
         SetDirty("Empresautilizarepresentanteassinatura_N");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresautilizarepresentanteassinatura_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteLogradouro_N" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteLogradouro_N"   )]
      public short gxTpr_Empresarepresentantelogradouro_N
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantelogradouro_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantelogradouro_N = value;
            SetDirty("Empresarepresentantelogradouro_N");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantelogradouro_N_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantelogradouro_N = 0;
         SetDirty("Empresarepresentantelogradouro_N");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantelogradouro_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteNumero_N" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteNumero_N"   )]
      public short gxTpr_Empresarepresentantenumero_N
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantenumero_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantenumero_N = value;
            SetDirty("Empresarepresentantenumero_N");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantenumero_N_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantenumero_N = 0;
         SetDirty("Empresarepresentantenumero_N");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantenumero_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteCEP_N" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteCEP_N"   )]
      public short gxTpr_Empresarepresentantecep_N
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantecep_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantecep_N = value;
            SetDirty("Empresarepresentantecep_N");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantecep_N_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantecep_N = 0;
         SetDirty("Empresarepresentantecep_N");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantecep_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteBairro_N" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteBairro_N"   )]
      public short gxTpr_Empresarepresentantebairro_N
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantebairro_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantebairro_N = value;
            SetDirty("Empresarepresentantebairro_N");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantebairro_N_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantebairro_N = 0;
         SetDirty("Empresarepresentantebairro_N");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantebairro_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteComplemento_N" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteComplemento_N"   )]
      public short gxTpr_Empresarepresentantecomplemento_N
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantecomplemento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantecomplemento_N = value;
            SetDirty("Empresarepresentantecomplemento_N");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantecomplemento_N_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantecomplemento_N = 0;
         SetDirty("Empresarepresentantecomplemento_N");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantecomplemento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteMunicipio_N" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteMunicipio_N"   )]
      public short gxTpr_Empresarepresentantemunicipio_N
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantemunicipio_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantemunicipio_N = value;
            SetDirty("Empresarepresentantemunicipio_N");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantemunicipio_N_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantemunicipio_N = 0;
         SetDirty("Empresarepresentantemunicipio_N");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantemunicipio_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteMunicipioNome_N" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteMunicipioNome_N"   )]
      public short gxTpr_Empresarepresentantemunicipionome_N
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantemunicipionome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantemunicipionome_N = value;
            SetDirty("Empresarepresentantemunicipionome_N");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantemunicipionome_N_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantemunicipionome_N = 0;
         SetDirty("Empresarepresentantemunicipionome_N");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantemunicipionome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteMunicipioUF_N" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteMunicipioUF_N"   )]
      public short gxTpr_Empresarepresentantemunicipiouf_N
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantemunicipiouf_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantemunicipiouf_N = value;
            SetDirty("Empresarepresentantemunicipiouf_N");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantemunicipiouf_N_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantemunicipiouf_N = 0;
         SetDirty("Empresarepresentantemunicipiouf_N");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantemunicipiouf_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteNacionalidade_N" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteNacionalidade_N"   )]
      public short gxTpr_Empresarepresentantenacionalidade_N
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantenacionalidade_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantenacionalidade_N = value;
            SetDirty("Empresarepresentantenacionalidade_N");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantenacionalidade_N_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantenacionalidade_N = 0;
         SetDirty("Empresarepresentantenacionalidade_N");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantenacionalidade_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteProfissao_N" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteProfissao_N"   )]
      public short gxTpr_Empresarepresentanteprofissao_N
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentanteprofissao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentanteprofissao_N = value;
            SetDirty("Empresarepresentanteprofissao_N");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentanteprofissao_N_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentanteprofissao_N = 0;
         SetDirty("Empresarepresentanteprofissao_N");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentanteprofissao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteTelefone_N" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteTelefone_N"   )]
      public short gxTpr_Empresarepresentantetelefone_N
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantetelefone_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantetelefone_N = value;
            SetDirty("Empresarepresentantetelefone_N");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantetelefone_N_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantetelefone_N = 0;
         SetDirty("Empresarepresentantetelefone_N");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantetelefone_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmpresaRepresentanteTelefoneDDD_N" )]
      [  XmlElement( ElementName = "EmpresaRepresentanteTelefoneDDD_N"   )]
      public short gxTpr_Empresarepresentantetelefoneddd_N
      {
         get {
            return gxTv_SdtEmpresa_Empresarepresentantetelefoneddd_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmpresa_Empresarepresentantetelefoneddd_N = value;
            SetDirty("Empresarepresentantetelefoneddd_N");
         }

      }

      public void gxTv_SdtEmpresa_Empresarepresentantetelefoneddd_N_SetNull( )
      {
         gxTv_SdtEmpresa_Empresarepresentantetelefoneddd_N = 0;
         SetDirty("Empresarepresentantetelefoneddd_N");
         return  ;
      }

      public bool gxTv_SdtEmpresa_Empresarepresentantetelefoneddd_N_IsNull( )
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
         gxTv_SdtEmpresa_Empresanomefantasia = "";
         gxTv_SdtEmpresa_Empresarazaosocial = "";
         gxTv_SdtEmpresa_Empresacnpj = "";
         gxTv_SdtEmpresa_Banconome = "";
         gxTv_SdtEmpresa_Empresapix = "";
         gxTv_SdtEmpresa_Empresapixtipo = "";
         gxTv_SdtEmpresa_Empresaemail = "";
         gxTv_SdtEmpresa_Empresalogradouro = "";
         gxTv_SdtEmpresa_Empresacep = "";
         gxTv_SdtEmpresa_Empresabairro = "";
         gxTv_SdtEmpresa_Empresacomplemento = "";
         gxTv_SdtEmpresa_Municipiocodigo = "";
         gxTv_SdtEmpresa_Municipionome = "";
         gxTv_SdtEmpresa_Municipiouf = "";
         gxTv_SdtEmpresa_Empresarepresentantecpf = "";
         gxTv_SdtEmpresa_Empresarepresentantenome = "";
         gxTv_SdtEmpresa_Empresarepresentanteemail = "";
         gxTv_SdtEmpresa_Empresarepresentantelogradouro = "";
         gxTv_SdtEmpresa_Empresarepresentantecep = "";
         gxTv_SdtEmpresa_Empresarepresentantebairro = "";
         gxTv_SdtEmpresa_Empresarepresentantecomplemento = "";
         gxTv_SdtEmpresa_Empresarepresentantemunicipio = "";
         gxTv_SdtEmpresa_Empresarepresentantemunicipionome = "";
         gxTv_SdtEmpresa_Empresarepresentantemunicipiouf = "";
         gxTv_SdtEmpresa_Empresarepresentantenacionalidade = "";
         gxTv_SdtEmpresa_Mode = "";
         gxTv_SdtEmpresa_Empresanomefantasia_Z = "";
         gxTv_SdtEmpresa_Empresarazaosocial_Z = "";
         gxTv_SdtEmpresa_Empresacnpj_Z = "";
         gxTv_SdtEmpresa_Banconome_Z = "";
         gxTv_SdtEmpresa_Empresapix_Z = "";
         gxTv_SdtEmpresa_Empresapixtipo_Z = "";
         gxTv_SdtEmpresa_Empresaemail_Z = "";
         gxTv_SdtEmpresa_Empresalogradouro_Z = "";
         gxTv_SdtEmpresa_Empresacep_Z = "";
         gxTv_SdtEmpresa_Empresabairro_Z = "";
         gxTv_SdtEmpresa_Empresacomplemento_Z = "";
         gxTv_SdtEmpresa_Municipiocodigo_Z = "";
         gxTv_SdtEmpresa_Municipionome_Z = "";
         gxTv_SdtEmpresa_Municipiouf_Z = "";
         gxTv_SdtEmpresa_Empresarepresentantecpf_Z = "";
         gxTv_SdtEmpresa_Empresarepresentantenome_Z = "";
         gxTv_SdtEmpresa_Empresarepresentanteemail_Z = "";
         gxTv_SdtEmpresa_Empresarepresentantelogradouro_Z = "";
         gxTv_SdtEmpresa_Empresarepresentantecep_Z = "";
         gxTv_SdtEmpresa_Empresarepresentantebairro_Z = "";
         gxTv_SdtEmpresa_Empresarepresentantecomplemento_Z = "";
         gxTv_SdtEmpresa_Empresarepresentantemunicipio_Z = "";
         gxTv_SdtEmpresa_Empresarepresentantemunicipionome_Z = "";
         gxTv_SdtEmpresa_Empresarepresentantemunicipiouf_Z = "";
         gxTv_SdtEmpresa_Empresarepresentantenacionalidade_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "empresa", "GeneXus.Programs.empresa_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtEmpresa_Empresarepresentantetelefoneddd ;
      private short gxTv_SdtEmpresa_Initialized ;
      private short gxTv_SdtEmpresa_Empresarepresentantetelefoneddd_Z ;
      private short gxTv_SdtEmpresa_Empresanomefantasia_N ;
      private short gxTv_SdtEmpresa_Empresarazaosocial_N ;
      private short gxTv_SdtEmpresa_Empresacnpj_N ;
      private short gxTv_SdtEmpresa_Empresasede_N ;
      private short gxTv_SdtEmpresa_Empresabancoid_N ;
      private short gxTv_SdtEmpresa_Banconome_N ;
      private short gxTv_SdtEmpresa_Empresaagencia_N ;
      private short gxTv_SdtEmpresa_Empresaagenciadigito_N ;
      private short gxTv_SdtEmpresa_Empresaconta_N ;
      private short gxTv_SdtEmpresa_Empresapix_N ;
      private short gxTv_SdtEmpresa_Empresapixtipo_N ;
      private short gxTv_SdtEmpresa_Empresaemail_N ;
      private short gxTv_SdtEmpresa_Empresalogradouro_N ;
      private short gxTv_SdtEmpresa_Empresalogradouronumero_N ;
      private short gxTv_SdtEmpresa_Empresacep_N ;
      private short gxTv_SdtEmpresa_Empresabairro_N ;
      private short gxTv_SdtEmpresa_Empresacomplemento_N ;
      private short gxTv_SdtEmpresa_Municipiocodigo_N ;
      private short gxTv_SdtEmpresa_Municipionome_N ;
      private short gxTv_SdtEmpresa_Municipiouf_N ;
      private short gxTv_SdtEmpresa_Empresarepresentantecpf_N ;
      private short gxTv_SdtEmpresa_Empresarepresentantenome_N ;
      private short gxTv_SdtEmpresa_Empresarepresentanteemail_N ;
      private short gxTv_SdtEmpresa_Empresautilizarepresentanteassinatura_N ;
      private short gxTv_SdtEmpresa_Empresarepresentantelogradouro_N ;
      private short gxTv_SdtEmpresa_Empresarepresentantenumero_N ;
      private short gxTv_SdtEmpresa_Empresarepresentantecep_N ;
      private short gxTv_SdtEmpresa_Empresarepresentantebairro_N ;
      private short gxTv_SdtEmpresa_Empresarepresentantecomplemento_N ;
      private short gxTv_SdtEmpresa_Empresarepresentantemunicipio_N ;
      private short gxTv_SdtEmpresa_Empresarepresentantemunicipionome_N ;
      private short gxTv_SdtEmpresa_Empresarepresentantemunicipiouf_N ;
      private short gxTv_SdtEmpresa_Empresarepresentantenacionalidade_N ;
      private short gxTv_SdtEmpresa_Empresarepresentanteprofissao_N ;
      private short gxTv_SdtEmpresa_Empresarepresentantetelefone_N ;
      private short gxTv_SdtEmpresa_Empresarepresentantetelefoneddd_N ;
      private int gxTv_SdtEmpresa_Empresaid ;
      private int gxTv_SdtEmpresa_Empresabancoid ;
      private int gxTv_SdtEmpresa_Empresaagencia ;
      private int gxTv_SdtEmpresa_Empresaagenciadigito ;
      private int gxTv_SdtEmpresa_Empresaconta ;
      private int gxTv_SdtEmpresa_Empresarepresentanteprofissao ;
      private int gxTv_SdtEmpresa_Empresarepresentantetelefone ;
      private int gxTv_SdtEmpresa_Empresaid_Z ;
      private int gxTv_SdtEmpresa_Empresabancoid_Z ;
      private int gxTv_SdtEmpresa_Empresaagencia_Z ;
      private int gxTv_SdtEmpresa_Empresaagenciadigito_Z ;
      private int gxTv_SdtEmpresa_Empresaconta_Z ;
      private int gxTv_SdtEmpresa_Empresarepresentanteprofissao_Z ;
      private int gxTv_SdtEmpresa_Empresarepresentantetelefone_Z ;
      private long gxTv_SdtEmpresa_Empresalogradouronumero ;
      private long gxTv_SdtEmpresa_Empresarepresentantenumero ;
      private long gxTv_SdtEmpresa_Empresalogradouronumero_Z ;
      private long gxTv_SdtEmpresa_Empresarepresentantenumero_Z ;
      private string gxTv_SdtEmpresa_Mode ;
      private bool gxTv_SdtEmpresa_Empresasede ;
      private bool gxTv_SdtEmpresa_Empresautilizarepresentanteassinatura ;
      private bool gxTv_SdtEmpresa_Empresasede_Z ;
      private bool gxTv_SdtEmpresa_Empresautilizarepresentanteassinatura_Z ;
      private string gxTv_SdtEmpresa_Empresanomefantasia ;
      private string gxTv_SdtEmpresa_Empresarazaosocial ;
      private string gxTv_SdtEmpresa_Empresacnpj ;
      private string gxTv_SdtEmpresa_Banconome ;
      private string gxTv_SdtEmpresa_Empresapix ;
      private string gxTv_SdtEmpresa_Empresapixtipo ;
      private string gxTv_SdtEmpresa_Empresaemail ;
      private string gxTv_SdtEmpresa_Empresalogradouro ;
      private string gxTv_SdtEmpresa_Empresacep ;
      private string gxTv_SdtEmpresa_Empresabairro ;
      private string gxTv_SdtEmpresa_Empresacomplemento ;
      private string gxTv_SdtEmpresa_Municipiocodigo ;
      private string gxTv_SdtEmpresa_Municipionome ;
      private string gxTv_SdtEmpresa_Municipiouf ;
      private string gxTv_SdtEmpresa_Empresarepresentantecpf ;
      private string gxTv_SdtEmpresa_Empresarepresentantenome ;
      private string gxTv_SdtEmpresa_Empresarepresentanteemail ;
      private string gxTv_SdtEmpresa_Empresarepresentantelogradouro ;
      private string gxTv_SdtEmpresa_Empresarepresentantecep ;
      private string gxTv_SdtEmpresa_Empresarepresentantebairro ;
      private string gxTv_SdtEmpresa_Empresarepresentantecomplemento ;
      private string gxTv_SdtEmpresa_Empresarepresentantemunicipio ;
      private string gxTv_SdtEmpresa_Empresarepresentantemunicipionome ;
      private string gxTv_SdtEmpresa_Empresarepresentantemunicipiouf ;
      private string gxTv_SdtEmpresa_Empresarepresentantenacionalidade ;
      private string gxTv_SdtEmpresa_Empresanomefantasia_Z ;
      private string gxTv_SdtEmpresa_Empresarazaosocial_Z ;
      private string gxTv_SdtEmpresa_Empresacnpj_Z ;
      private string gxTv_SdtEmpresa_Banconome_Z ;
      private string gxTv_SdtEmpresa_Empresapix_Z ;
      private string gxTv_SdtEmpresa_Empresapixtipo_Z ;
      private string gxTv_SdtEmpresa_Empresaemail_Z ;
      private string gxTv_SdtEmpresa_Empresalogradouro_Z ;
      private string gxTv_SdtEmpresa_Empresacep_Z ;
      private string gxTv_SdtEmpresa_Empresabairro_Z ;
      private string gxTv_SdtEmpresa_Empresacomplemento_Z ;
      private string gxTv_SdtEmpresa_Municipiocodigo_Z ;
      private string gxTv_SdtEmpresa_Municipionome_Z ;
      private string gxTv_SdtEmpresa_Municipiouf_Z ;
      private string gxTv_SdtEmpresa_Empresarepresentantecpf_Z ;
      private string gxTv_SdtEmpresa_Empresarepresentantenome_Z ;
      private string gxTv_SdtEmpresa_Empresarepresentanteemail_Z ;
      private string gxTv_SdtEmpresa_Empresarepresentantelogradouro_Z ;
      private string gxTv_SdtEmpresa_Empresarepresentantecep_Z ;
      private string gxTv_SdtEmpresa_Empresarepresentantebairro_Z ;
      private string gxTv_SdtEmpresa_Empresarepresentantecomplemento_Z ;
      private string gxTv_SdtEmpresa_Empresarepresentantemunicipio_Z ;
      private string gxTv_SdtEmpresa_Empresarepresentantemunicipionome_Z ;
      private string gxTv_SdtEmpresa_Empresarepresentantemunicipiouf_Z ;
      private string gxTv_SdtEmpresa_Empresarepresentantenacionalidade_Z ;
   }

   [DataContract(Name = @"Empresa", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtEmpresa_RESTInterface : GxGenericCollectionItem<SdtEmpresa>
   {
      public SdtEmpresa_RESTInterface( ) : base()
      {
      }

      public SdtEmpresa_RESTInterface( SdtEmpresa psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EmpresaId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Empresaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Empresaid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Empresaid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "EmpresaNomeFantasia" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Empresanomefantasia
      {
         get {
            return sdt.gxTpr_Empresanomefantasia ;
         }

         set {
            sdt.gxTpr_Empresanomefantasia = value;
         }

      }

      [DataMember( Name = "EmpresaRazaoSocial" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Empresarazaosocial
      {
         get {
            return sdt.gxTpr_Empresarazaosocial ;
         }

         set {
            sdt.gxTpr_Empresarazaosocial = value;
         }

      }

      [DataMember( Name = "EmpresaCNPJ" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Empresacnpj
      {
         get {
            return sdt.gxTpr_Empresacnpj ;
         }

         set {
            sdt.gxTpr_Empresacnpj = value;
         }

      }

      [DataMember( Name = "EmpresaSede" , Order = 4 )]
      [GxSeudo()]
      public bool gxTpr_Empresasede
      {
         get {
            return sdt.gxTpr_Empresasede ;
         }

         set {
            sdt.gxTpr_Empresasede = value;
         }

      }

      [DataMember( Name = "EmpresaBancoId" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Empresabancoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Empresabancoid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Empresabancoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "BancoNome" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Banconome
      {
         get {
            return sdt.gxTpr_Banconome ;
         }

         set {
            sdt.gxTpr_Banconome = value;
         }

      }

      [DataMember( Name = "EmpresaAgencia" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Empresaagencia
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Empresaagencia), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Empresaagencia = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "EmpresaAgenciaDigito" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Empresaagenciadigito
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Empresaagenciadigito), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Empresaagenciadigito = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "EmpresaConta" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Empresaconta
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Empresaconta), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Empresaconta = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "EmpresaPix" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Empresapix
      {
         get {
            return sdt.gxTpr_Empresapix ;
         }

         set {
            sdt.gxTpr_Empresapix = value;
         }

      }

      [DataMember( Name = "EmpresaPixTipo" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Empresapixtipo
      {
         get {
            return sdt.gxTpr_Empresapixtipo ;
         }

         set {
            sdt.gxTpr_Empresapixtipo = value;
         }

      }

      [DataMember( Name = "EmpresaEmail" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Empresaemail
      {
         get {
            return sdt.gxTpr_Empresaemail ;
         }

         set {
            sdt.gxTpr_Empresaemail = value;
         }

      }

      [DataMember( Name = "EmpresaLogradouro" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Empresalogradouro
      {
         get {
            return sdt.gxTpr_Empresalogradouro ;
         }

         set {
            sdt.gxTpr_Empresalogradouro = value;
         }

      }

      [DataMember( Name = "EmpresaLogradouroNumero" , Order = 14 )]
      [GxSeudo()]
      public string gxTpr_Empresalogradouronumero
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Empresalogradouronumero), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Empresalogradouronumero = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "EmpresaCEP" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Empresacep
      {
         get {
            return sdt.gxTpr_Empresacep ;
         }

         set {
            sdt.gxTpr_Empresacep = value;
         }

      }

      [DataMember( Name = "EmpresaBairro" , Order = 16 )]
      [GxSeudo()]
      public string gxTpr_Empresabairro
      {
         get {
            return sdt.gxTpr_Empresabairro ;
         }

         set {
            sdt.gxTpr_Empresabairro = value;
         }

      }

      [DataMember( Name = "EmpresaComplemento" , Order = 17 )]
      [GxSeudo()]
      public string gxTpr_Empresacomplemento
      {
         get {
            return sdt.gxTpr_Empresacomplemento ;
         }

         set {
            sdt.gxTpr_Empresacomplemento = value;
         }

      }

      [DataMember( Name = "MunicipioCodigo" , Order = 18 )]
      [GxSeudo()]
      public string gxTpr_Municipiocodigo
      {
         get {
            return sdt.gxTpr_Municipiocodigo ;
         }

         set {
            sdt.gxTpr_Municipiocodigo = value;
         }

      }

      [DataMember( Name = "MunicipioNome" , Order = 19 )]
      [GxSeudo()]
      public string gxTpr_Municipionome
      {
         get {
            return sdt.gxTpr_Municipionome ;
         }

         set {
            sdt.gxTpr_Municipionome = value;
         }

      }

      [DataMember( Name = "MunicipioUF" , Order = 20 )]
      [GxSeudo()]
      public string gxTpr_Municipiouf
      {
         get {
            return sdt.gxTpr_Municipiouf ;
         }

         set {
            sdt.gxTpr_Municipiouf = value;
         }

      }

      [DataMember( Name = "EmpresaRepresentanteCPF" , Order = 21 )]
      [GxSeudo()]
      public string gxTpr_Empresarepresentantecpf
      {
         get {
            return sdt.gxTpr_Empresarepresentantecpf ;
         }

         set {
            sdt.gxTpr_Empresarepresentantecpf = value;
         }

      }

      [DataMember( Name = "EmpresaRepresentanteNome" , Order = 22 )]
      [GxSeudo()]
      public string gxTpr_Empresarepresentantenome
      {
         get {
            return sdt.gxTpr_Empresarepresentantenome ;
         }

         set {
            sdt.gxTpr_Empresarepresentantenome = value;
         }

      }

      [DataMember( Name = "EmpresaRepresentanteEmail" , Order = 23 )]
      [GxSeudo()]
      public string gxTpr_Empresarepresentanteemail
      {
         get {
            return sdt.gxTpr_Empresarepresentanteemail ;
         }

         set {
            sdt.gxTpr_Empresarepresentanteemail = value;
         }

      }

      [DataMember( Name = "EmpresaUtilizaRepresentanteAssinatura" , Order = 24 )]
      [GxSeudo()]
      public bool gxTpr_Empresautilizarepresentanteassinatura
      {
         get {
            return sdt.gxTpr_Empresautilizarepresentanteassinatura ;
         }

         set {
            sdt.gxTpr_Empresautilizarepresentanteassinatura = value;
         }

      }

      [DataMember( Name = "EmpresaRepresentanteLogradouro" , Order = 25 )]
      [GxSeudo()]
      public string gxTpr_Empresarepresentantelogradouro
      {
         get {
            return sdt.gxTpr_Empresarepresentantelogradouro ;
         }

         set {
            sdt.gxTpr_Empresarepresentantelogradouro = value;
         }

      }

      [DataMember( Name = "EmpresaRepresentanteNumero" , Order = 26 )]
      [GxSeudo()]
      public string gxTpr_Empresarepresentantenumero
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Empresarepresentantenumero), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Empresarepresentantenumero = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "EmpresaRepresentanteCEP" , Order = 27 )]
      [GxSeudo()]
      public string gxTpr_Empresarepresentantecep
      {
         get {
            return sdt.gxTpr_Empresarepresentantecep ;
         }

         set {
            sdt.gxTpr_Empresarepresentantecep = value;
         }

      }

      [DataMember( Name = "EmpresaRepresentanteBairro" , Order = 28 )]
      [GxSeudo()]
      public string gxTpr_Empresarepresentantebairro
      {
         get {
            return sdt.gxTpr_Empresarepresentantebairro ;
         }

         set {
            sdt.gxTpr_Empresarepresentantebairro = value;
         }

      }

      [DataMember( Name = "EmpresaRepresentanteComplemento" , Order = 29 )]
      [GxSeudo()]
      public string gxTpr_Empresarepresentantecomplemento
      {
         get {
            return sdt.gxTpr_Empresarepresentantecomplemento ;
         }

         set {
            sdt.gxTpr_Empresarepresentantecomplemento = value;
         }

      }

      [DataMember( Name = "EmpresaRepresentanteMunicipio" , Order = 30 )]
      [GxSeudo()]
      public string gxTpr_Empresarepresentantemunicipio
      {
         get {
            return sdt.gxTpr_Empresarepresentantemunicipio ;
         }

         set {
            sdt.gxTpr_Empresarepresentantemunicipio = value;
         }

      }

      [DataMember( Name = "EmpresaRepresentanteMunicipioNome" , Order = 31 )]
      [GxSeudo()]
      public string gxTpr_Empresarepresentantemunicipionome
      {
         get {
            return sdt.gxTpr_Empresarepresentantemunicipionome ;
         }

         set {
            sdt.gxTpr_Empresarepresentantemunicipionome = value;
         }

      }

      [DataMember( Name = "EmpresaRepresentanteMunicipioUF" , Order = 32 )]
      [GxSeudo()]
      public string gxTpr_Empresarepresentantemunicipiouf
      {
         get {
            return sdt.gxTpr_Empresarepresentantemunicipiouf ;
         }

         set {
            sdt.gxTpr_Empresarepresentantemunicipiouf = value;
         }

      }

      [DataMember( Name = "EmpresaRepresentanteNacionalidade" , Order = 33 )]
      [GxSeudo()]
      public string gxTpr_Empresarepresentantenacionalidade
      {
         get {
            return sdt.gxTpr_Empresarepresentantenacionalidade ;
         }

         set {
            sdt.gxTpr_Empresarepresentantenacionalidade = value;
         }

      }

      [DataMember( Name = "EmpresaRepresentanteProfissao" , Order = 34 )]
      [GxSeudo()]
      public string gxTpr_Empresarepresentanteprofissao
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Empresarepresentanteprofissao), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Empresarepresentanteprofissao = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "EmpresaRepresentanteTelefone" , Order = 35 )]
      [GxSeudo()]
      public string gxTpr_Empresarepresentantetelefone
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Empresarepresentantetelefone), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Empresarepresentantetelefone = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "EmpresaRepresentanteTelefoneDDD" , Order = 36 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Empresarepresentantetelefoneddd
      {
         get {
            return sdt.gxTpr_Empresarepresentantetelefoneddd ;
         }

         set {
            sdt.gxTpr_Empresarepresentantetelefoneddd = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtEmpresa sdt
      {
         get {
            return (SdtEmpresa)Sdt ;
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
            sdt = new SdtEmpresa() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 37 )]
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

   [DataContract(Name = @"Empresa", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtEmpresa_RESTLInterface : GxGenericCollectionItem<SdtEmpresa>
   {
      public SdtEmpresa_RESTLInterface( ) : base()
      {
      }

      public SdtEmpresa_RESTLInterface( SdtEmpresa psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EmpresaNomeFantasia" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Empresanomefantasia
      {
         get {
            return sdt.gxTpr_Empresanomefantasia ;
         }

         set {
            sdt.gxTpr_Empresanomefantasia = value;
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

      public SdtEmpresa sdt
      {
         get {
            return (SdtEmpresa)Sdt ;
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
            sdt = new SdtEmpresa() ;
         }
      }

   }

}
