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
   [XmlRoot(ElementName = "Contrato" )]
   [XmlType(TypeName =  "Contrato" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtContrato : GxSilentTrnSdt
   {
      public SdtContrato( )
      {
      }

      public SdtContrato( IGxContext context )
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

      public void Load( int AV227ContratoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV227ContratoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ContratoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Contrato");
         metadata.Set("BT", "Contrato");
         metadata.Set("PK", "[ \"ContratoId\" ]");
         metadata.Set("PKAssigned", "[ \"ContratoId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ClienteId\" ],\"FKMap\":[ \"ContratoClienteId-ClienteId\" ] },{ \"FK\":[ \"ContratoId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"PropostaId\" ],\"FKMap\":[ \"ContratoPropostaId-PropostaId\" ] } ]");
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
         state.Add("gxTpr_Contratoid_Z");
         state.Add("gxTpr_Contratonome_Z");
         state.Add("gxTpr_Contratocomvigencia_Z");
         state.Add("gxTpr_Contratodatainicial_Z_Nullable");
         state.Add("gxTpr_Contratodatafinal_Z_Nullable");
         state.Add("gxTpr_Contratoclienteid_Z");
         state.Add("gxTpr_Contratoclientenome_Z");
         state.Add("gxTpr_Contratoclientedocumento_Z");
         state.Add("gxTpr_Contratoclienterepresentantenome_Z");
         state.Add("gxTpr_Contratoclienterepresentantecpf_Z");
         state.Add("gxTpr_Contratoclientetipopessoa_Z");
         state.Add("gxTpr_Contratotaxa_Z");
         state.Add("gxTpr_Contratosla_Z");
         state.Add("gxTpr_Contratojurosmora_Z");
         state.Add("gxTpr_Contratoiofminimo_Z");
         state.Add("gxTpr_Contratosituacao_Z");
         state.Add("gxTpr_Assinaturaultid_f_Z");
         state.Add("gxTpr_Contratoclienteenderecocep_Z");
         state.Add("gxTpr_Contratoclienteenderecolograodouro_Z");
         state.Add("gxTpr_Contratoclienteendereconumero_Z");
         state.Add("gxTpr_Contratoclienteenderecocomplemento_Z");
         state.Add("gxTpr_Contratoclienteenderecobairro_Z");
         state.Add("gxTpr_Contratoclientemunicipiocodigo_Z");
         state.Add("gxTpr_Contratopropostaid_Z");
         state.Add("gxTpr_Contratocountassinantes_f_Z");
         state.Add("gxTpr_Contratoid_N");
         state.Add("gxTpr_Contratonome_N");
         state.Add("gxTpr_Contratocorpo_N");
         state.Add("gxTpr_Contratocomvigencia_N");
         state.Add("gxTpr_Contratodatainicial_N");
         state.Add("gxTpr_Contratodatafinal_N");
         state.Add("gxTpr_Contratoclienteid_N");
         state.Add("gxTpr_Contratoclientenome_N");
         state.Add("gxTpr_Contratoclientedocumento_N");
         state.Add("gxTpr_Contratoclienterepresentantenome_N");
         state.Add("gxTpr_Contratoclienterepresentantecpf_N");
         state.Add("gxTpr_Contratoclientetipopessoa_N");
         state.Add("gxTpr_Contratotaxa_N");
         state.Add("gxTpr_Contratosla_N");
         state.Add("gxTpr_Contratojurosmora_N");
         state.Add("gxTpr_Contratoiofminimo_N");
         state.Add("gxTpr_Contratosituacao_N");
         state.Add("gxTpr_Contratoblob_N");
         state.Add("gxTpr_Assinaturaultid_f_N");
         state.Add("gxTpr_Contratoclienteenderecocep_N");
         state.Add("gxTpr_Contratoclienteenderecolograodouro_N");
         state.Add("gxTpr_Contratoclienteendereconumero_N");
         state.Add("gxTpr_Contratoclienteenderecocomplemento_N");
         state.Add("gxTpr_Contratoclienteenderecobairro_N");
         state.Add("gxTpr_Contratoclientemunicipiocodigo_N");
         state.Add("gxTpr_Contratopropostaid_N");
         state.Add("gxTpr_Contratocountassinantes_f_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtContrato sdt;
         sdt = (SdtContrato)(source);
         gxTv_SdtContrato_Contratoid = sdt.gxTv_SdtContrato_Contratoid ;
         gxTv_SdtContrato_Contratonome = sdt.gxTv_SdtContrato_Contratonome ;
         gxTv_SdtContrato_Contratocorpo = sdt.gxTv_SdtContrato_Contratocorpo ;
         gxTv_SdtContrato_Contratocomvigencia = sdt.gxTv_SdtContrato_Contratocomvigencia ;
         gxTv_SdtContrato_Contratodatainicial = sdt.gxTv_SdtContrato_Contratodatainicial ;
         gxTv_SdtContrato_Contratodatafinal = sdt.gxTv_SdtContrato_Contratodatafinal ;
         gxTv_SdtContrato_Contratoclienteid = sdt.gxTv_SdtContrato_Contratoclienteid ;
         gxTv_SdtContrato_Contratoclientenome = sdt.gxTv_SdtContrato_Contratoclientenome ;
         gxTv_SdtContrato_Contratoclientedocumento = sdt.gxTv_SdtContrato_Contratoclientedocumento ;
         gxTv_SdtContrato_Contratoclienterepresentantenome = sdt.gxTv_SdtContrato_Contratoclienterepresentantenome ;
         gxTv_SdtContrato_Contratoclienterepresentantecpf = sdt.gxTv_SdtContrato_Contratoclienterepresentantecpf ;
         gxTv_SdtContrato_Contratoclientetipopessoa = sdt.gxTv_SdtContrato_Contratoclientetipopessoa ;
         gxTv_SdtContrato_Contratotaxa = sdt.gxTv_SdtContrato_Contratotaxa ;
         gxTv_SdtContrato_Contratosla = sdt.gxTv_SdtContrato_Contratosla ;
         gxTv_SdtContrato_Contratojurosmora = sdt.gxTv_SdtContrato_Contratojurosmora ;
         gxTv_SdtContrato_Contratoiofminimo = sdt.gxTv_SdtContrato_Contratoiofminimo ;
         gxTv_SdtContrato_Contratosituacao = sdt.gxTv_SdtContrato_Contratosituacao ;
         gxTv_SdtContrato_Contratoblob = sdt.gxTv_SdtContrato_Contratoblob ;
         gxTv_SdtContrato_Assinaturaultid_f = sdt.gxTv_SdtContrato_Assinaturaultid_f ;
         gxTv_SdtContrato_Contratoclienteenderecocep = sdt.gxTv_SdtContrato_Contratoclienteenderecocep ;
         gxTv_SdtContrato_Contratoclienteenderecolograodouro = sdt.gxTv_SdtContrato_Contratoclienteenderecolograodouro ;
         gxTv_SdtContrato_Contratoclienteendereconumero = sdt.gxTv_SdtContrato_Contratoclienteendereconumero ;
         gxTv_SdtContrato_Contratoclienteenderecocomplemento = sdt.gxTv_SdtContrato_Contratoclienteenderecocomplemento ;
         gxTv_SdtContrato_Contratoclienteenderecobairro = sdt.gxTv_SdtContrato_Contratoclienteenderecobairro ;
         gxTv_SdtContrato_Contratoclientemunicipiocodigo = sdt.gxTv_SdtContrato_Contratoclientemunicipiocodigo ;
         gxTv_SdtContrato_Contratopropostaid = sdt.gxTv_SdtContrato_Contratopropostaid ;
         gxTv_SdtContrato_Contratocountassinantes_f = sdt.gxTv_SdtContrato_Contratocountassinantes_f ;
         gxTv_SdtContrato_Mode = sdt.gxTv_SdtContrato_Mode ;
         gxTv_SdtContrato_Initialized = sdt.gxTv_SdtContrato_Initialized ;
         gxTv_SdtContrato_Contratoid_Z = sdt.gxTv_SdtContrato_Contratoid_Z ;
         gxTv_SdtContrato_Contratonome_Z = sdt.gxTv_SdtContrato_Contratonome_Z ;
         gxTv_SdtContrato_Contratocomvigencia_Z = sdt.gxTv_SdtContrato_Contratocomvigencia_Z ;
         gxTv_SdtContrato_Contratodatainicial_Z = sdt.gxTv_SdtContrato_Contratodatainicial_Z ;
         gxTv_SdtContrato_Contratodatafinal_Z = sdt.gxTv_SdtContrato_Contratodatafinal_Z ;
         gxTv_SdtContrato_Contratoclienteid_Z = sdt.gxTv_SdtContrato_Contratoclienteid_Z ;
         gxTv_SdtContrato_Contratoclientenome_Z = sdt.gxTv_SdtContrato_Contratoclientenome_Z ;
         gxTv_SdtContrato_Contratoclientedocumento_Z = sdt.gxTv_SdtContrato_Contratoclientedocumento_Z ;
         gxTv_SdtContrato_Contratoclienterepresentantenome_Z = sdt.gxTv_SdtContrato_Contratoclienterepresentantenome_Z ;
         gxTv_SdtContrato_Contratoclienterepresentantecpf_Z = sdt.gxTv_SdtContrato_Contratoclienterepresentantecpf_Z ;
         gxTv_SdtContrato_Contratoclientetipopessoa_Z = sdt.gxTv_SdtContrato_Contratoclientetipopessoa_Z ;
         gxTv_SdtContrato_Contratotaxa_Z = sdt.gxTv_SdtContrato_Contratotaxa_Z ;
         gxTv_SdtContrato_Contratosla_Z = sdt.gxTv_SdtContrato_Contratosla_Z ;
         gxTv_SdtContrato_Contratojurosmora_Z = sdt.gxTv_SdtContrato_Contratojurosmora_Z ;
         gxTv_SdtContrato_Contratoiofminimo_Z = sdt.gxTv_SdtContrato_Contratoiofminimo_Z ;
         gxTv_SdtContrato_Contratosituacao_Z = sdt.gxTv_SdtContrato_Contratosituacao_Z ;
         gxTv_SdtContrato_Assinaturaultid_f_Z = sdt.gxTv_SdtContrato_Assinaturaultid_f_Z ;
         gxTv_SdtContrato_Contratoclienteenderecocep_Z = sdt.gxTv_SdtContrato_Contratoclienteenderecocep_Z ;
         gxTv_SdtContrato_Contratoclienteenderecolograodouro_Z = sdt.gxTv_SdtContrato_Contratoclienteenderecolograodouro_Z ;
         gxTv_SdtContrato_Contratoclienteendereconumero_Z = sdt.gxTv_SdtContrato_Contratoclienteendereconumero_Z ;
         gxTv_SdtContrato_Contratoclienteenderecocomplemento_Z = sdt.gxTv_SdtContrato_Contratoclienteenderecocomplemento_Z ;
         gxTv_SdtContrato_Contratoclienteenderecobairro_Z = sdt.gxTv_SdtContrato_Contratoclienteenderecobairro_Z ;
         gxTv_SdtContrato_Contratoclientemunicipiocodigo_Z = sdt.gxTv_SdtContrato_Contratoclientemunicipiocodigo_Z ;
         gxTv_SdtContrato_Contratopropostaid_Z = sdt.gxTv_SdtContrato_Contratopropostaid_Z ;
         gxTv_SdtContrato_Contratocountassinantes_f_Z = sdt.gxTv_SdtContrato_Contratocountassinantes_f_Z ;
         gxTv_SdtContrato_Contratoid_N = sdt.gxTv_SdtContrato_Contratoid_N ;
         gxTv_SdtContrato_Contratonome_N = sdt.gxTv_SdtContrato_Contratonome_N ;
         gxTv_SdtContrato_Contratocorpo_N = sdt.gxTv_SdtContrato_Contratocorpo_N ;
         gxTv_SdtContrato_Contratocomvigencia_N = sdt.gxTv_SdtContrato_Contratocomvigencia_N ;
         gxTv_SdtContrato_Contratodatainicial_N = sdt.gxTv_SdtContrato_Contratodatainicial_N ;
         gxTv_SdtContrato_Contratodatafinal_N = sdt.gxTv_SdtContrato_Contratodatafinal_N ;
         gxTv_SdtContrato_Contratoclienteid_N = sdt.gxTv_SdtContrato_Contratoclienteid_N ;
         gxTv_SdtContrato_Contratoclientenome_N = sdt.gxTv_SdtContrato_Contratoclientenome_N ;
         gxTv_SdtContrato_Contratoclientedocumento_N = sdt.gxTv_SdtContrato_Contratoclientedocumento_N ;
         gxTv_SdtContrato_Contratoclienterepresentantenome_N = sdt.gxTv_SdtContrato_Contratoclienterepresentantenome_N ;
         gxTv_SdtContrato_Contratoclienterepresentantecpf_N = sdt.gxTv_SdtContrato_Contratoclienterepresentantecpf_N ;
         gxTv_SdtContrato_Contratoclientetipopessoa_N = sdt.gxTv_SdtContrato_Contratoclientetipopessoa_N ;
         gxTv_SdtContrato_Contratotaxa_N = sdt.gxTv_SdtContrato_Contratotaxa_N ;
         gxTv_SdtContrato_Contratosla_N = sdt.gxTv_SdtContrato_Contratosla_N ;
         gxTv_SdtContrato_Contratojurosmora_N = sdt.gxTv_SdtContrato_Contratojurosmora_N ;
         gxTv_SdtContrato_Contratoiofminimo_N = sdt.gxTv_SdtContrato_Contratoiofminimo_N ;
         gxTv_SdtContrato_Contratosituacao_N = sdt.gxTv_SdtContrato_Contratosituacao_N ;
         gxTv_SdtContrato_Contratoblob_N = sdt.gxTv_SdtContrato_Contratoblob_N ;
         gxTv_SdtContrato_Assinaturaultid_f_N = sdt.gxTv_SdtContrato_Assinaturaultid_f_N ;
         gxTv_SdtContrato_Contratoclienteenderecocep_N = sdt.gxTv_SdtContrato_Contratoclienteenderecocep_N ;
         gxTv_SdtContrato_Contratoclienteenderecolograodouro_N = sdt.gxTv_SdtContrato_Contratoclienteenderecolograodouro_N ;
         gxTv_SdtContrato_Contratoclienteendereconumero_N = sdt.gxTv_SdtContrato_Contratoclienteendereconumero_N ;
         gxTv_SdtContrato_Contratoclienteenderecocomplemento_N = sdt.gxTv_SdtContrato_Contratoclienteenderecocomplemento_N ;
         gxTv_SdtContrato_Contratoclienteenderecobairro_N = sdt.gxTv_SdtContrato_Contratoclienteenderecobairro_N ;
         gxTv_SdtContrato_Contratoclientemunicipiocodigo_N = sdt.gxTv_SdtContrato_Contratoclientemunicipiocodigo_N ;
         gxTv_SdtContrato_Contratopropostaid_N = sdt.gxTv_SdtContrato_Contratopropostaid_N ;
         gxTv_SdtContrato_Contratocountassinantes_f_N = sdt.gxTv_SdtContrato_Contratocountassinantes_f_N ;
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
         AddObjectProperty("ContratoId", gxTv_SdtContrato_Contratoid, false, includeNonInitialized);
         AddObjectProperty("ContratoId_N", gxTv_SdtContrato_Contratoid_N, false, includeNonInitialized);
         AddObjectProperty("ContratoNome", gxTv_SdtContrato_Contratonome, false, includeNonInitialized);
         AddObjectProperty("ContratoNome_N", gxTv_SdtContrato_Contratonome_N, false, includeNonInitialized);
         AddObjectProperty("ContratoCorpo", gxTv_SdtContrato_Contratocorpo, false, includeNonInitialized);
         AddObjectProperty("ContratoCorpo_N", gxTv_SdtContrato_Contratocorpo_N, false, includeNonInitialized);
         AddObjectProperty("ContratoComVigencia", gxTv_SdtContrato_Contratocomvigencia, false, includeNonInitialized);
         AddObjectProperty("ContratoComVigencia_N", gxTv_SdtContrato_Contratocomvigencia_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtContrato_Contratodatainicial)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtContrato_Contratodatainicial)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtContrato_Contratodatainicial)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("ContratoDataInicial", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ContratoDataInicial_N", gxTv_SdtContrato_Contratodatainicial_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtContrato_Contratodatafinal)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtContrato_Contratodatafinal)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtContrato_Contratodatafinal)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("ContratoDataFinal", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ContratoDataFinal_N", gxTv_SdtContrato_Contratodatafinal_N, false, includeNonInitialized);
         AddObjectProperty("ContratoClienteId", gxTv_SdtContrato_Contratoclienteid, false, includeNonInitialized);
         AddObjectProperty("ContratoClienteId_N", gxTv_SdtContrato_Contratoclienteid_N, false, includeNonInitialized);
         AddObjectProperty("ContratoClienteNome", gxTv_SdtContrato_Contratoclientenome, false, includeNonInitialized);
         AddObjectProperty("ContratoClienteNome_N", gxTv_SdtContrato_Contratoclientenome_N, false, includeNonInitialized);
         AddObjectProperty("ContratoClienteDocumento", gxTv_SdtContrato_Contratoclientedocumento, false, includeNonInitialized);
         AddObjectProperty("ContratoClienteDocumento_N", gxTv_SdtContrato_Contratoclientedocumento_N, false, includeNonInitialized);
         AddObjectProperty("ContratoClienteRepresentanteNome", gxTv_SdtContrato_Contratoclienterepresentantenome, false, includeNonInitialized);
         AddObjectProperty("ContratoClienteRepresentanteNome_N", gxTv_SdtContrato_Contratoclienterepresentantenome_N, false, includeNonInitialized);
         AddObjectProperty("ContratoClienteRepresentanteCPF", gxTv_SdtContrato_Contratoclienterepresentantecpf, false, includeNonInitialized);
         AddObjectProperty("ContratoClienteRepresentanteCPF_N", gxTv_SdtContrato_Contratoclienterepresentantecpf_N, false, includeNonInitialized);
         AddObjectProperty("ContratoClienteTipoPessoa", gxTv_SdtContrato_Contratoclientetipopessoa, false, includeNonInitialized);
         AddObjectProperty("ContratoClienteTipoPessoa_N", gxTv_SdtContrato_Contratoclientetipopessoa_N, false, includeNonInitialized);
         AddObjectProperty("ContratoTaxa", StringUtil.LTrim( StringUtil.Str( gxTv_SdtContrato_Contratotaxa, 16, 4)), false, includeNonInitialized);
         AddObjectProperty("ContratoTaxa_N", gxTv_SdtContrato_Contratotaxa_N, false, includeNonInitialized);
         AddObjectProperty("ContratoSLA", gxTv_SdtContrato_Contratosla, false, includeNonInitialized);
         AddObjectProperty("ContratoSLA_N", gxTv_SdtContrato_Contratosla_N, false, includeNonInitialized);
         AddObjectProperty("ContratoJurosMora", StringUtil.LTrim( StringUtil.Str( gxTv_SdtContrato_Contratojurosmora, 16, 4)), false, includeNonInitialized);
         AddObjectProperty("ContratoJurosMora_N", gxTv_SdtContrato_Contratojurosmora_N, false, includeNonInitialized);
         AddObjectProperty("ContratoIOFMinimo", StringUtil.LTrim( StringUtil.Str( gxTv_SdtContrato_Contratoiofminimo, 16, 4)), false, includeNonInitialized);
         AddObjectProperty("ContratoIOFMinimo_N", gxTv_SdtContrato_Contratoiofminimo_N, false, includeNonInitialized);
         AddObjectProperty("ContratoSituacao", gxTv_SdtContrato_Contratosituacao, false, includeNonInitialized);
         AddObjectProperty("ContratoSituacao_N", gxTv_SdtContrato_Contratosituacao_N, false, includeNonInitialized);
         AddObjectProperty("ContratoBlob", gxTv_SdtContrato_Contratoblob, false, includeNonInitialized);
         AddObjectProperty("ContratoBlob_N", gxTv_SdtContrato_Contratoblob_N, false, includeNonInitialized);
         AddObjectProperty("AssinaturaUltId_F", gxTv_SdtContrato_Assinaturaultid_f, false, includeNonInitialized);
         AddObjectProperty("AssinaturaUltId_F_N", gxTv_SdtContrato_Assinaturaultid_f_N, false, includeNonInitialized);
         AddObjectProperty("ContratoClienteEnderecoCEP", gxTv_SdtContrato_Contratoclienteenderecocep, false, includeNonInitialized);
         AddObjectProperty("ContratoClienteEnderecoCEP_N", gxTv_SdtContrato_Contratoclienteenderecocep_N, false, includeNonInitialized);
         AddObjectProperty("ContratoClienteEnderecoLograodouro", gxTv_SdtContrato_Contratoclienteenderecolograodouro, false, includeNonInitialized);
         AddObjectProperty("ContratoClienteEnderecoLograodouro_N", gxTv_SdtContrato_Contratoclienteenderecolograodouro_N, false, includeNonInitialized);
         AddObjectProperty("ContratoClienteEnderecoNumero", gxTv_SdtContrato_Contratoclienteendereconumero, false, includeNonInitialized);
         AddObjectProperty("ContratoClienteEnderecoNumero_N", gxTv_SdtContrato_Contratoclienteendereconumero_N, false, includeNonInitialized);
         AddObjectProperty("ContratoClienteEnderecoComplemento", gxTv_SdtContrato_Contratoclienteenderecocomplemento, false, includeNonInitialized);
         AddObjectProperty("ContratoClienteEnderecoComplemento_N", gxTv_SdtContrato_Contratoclienteenderecocomplemento_N, false, includeNonInitialized);
         AddObjectProperty("ContratoClienteEnderecoBairro", gxTv_SdtContrato_Contratoclienteenderecobairro, false, includeNonInitialized);
         AddObjectProperty("ContratoClienteEnderecoBairro_N", gxTv_SdtContrato_Contratoclienteenderecobairro_N, false, includeNonInitialized);
         AddObjectProperty("ContratoClienteMunicipioCodigo", gxTv_SdtContrato_Contratoclientemunicipiocodigo, false, includeNonInitialized);
         AddObjectProperty("ContratoClienteMunicipioCodigo_N", gxTv_SdtContrato_Contratoclientemunicipiocodigo_N, false, includeNonInitialized);
         AddObjectProperty("ContratoPropostaId", gxTv_SdtContrato_Contratopropostaid, false, includeNonInitialized);
         AddObjectProperty("ContratoPropostaId_N", gxTv_SdtContrato_Contratopropostaid_N, false, includeNonInitialized);
         AddObjectProperty("ContratoCountAssinantes_F", gxTv_SdtContrato_Contratocountassinantes_f, false, includeNonInitialized);
         AddObjectProperty("ContratoCountAssinantes_F_N", gxTv_SdtContrato_Contratocountassinantes_f_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtContrato_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtContrato_Initialized, false, includeNonInitialized);
            AddObjectProperty("ContratoId_Z", gxTv_SdtContrato_Contratoid_Z, false, includeNonInitialized);
            AddObjectProperty("ContratoNome_Z", gxTv_SdtContrato_Contratonome_Z, false, includeNonInitialized);
            AddObjectProperty("ContratoComVigencia_Z", gxTv_SdtContrato_Contratocomvigencia_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtContrato_Contratodatainicial_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtContrato_Contratodatainicial_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtContrato_Contratodatainicial_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("ContratoDataInicial_Z", sDateCnv, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtContrato_Contratodatafinal_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtContrato_Contratodatafinal_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtContrato_Contratodatafinal_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("ContratoDataFinal_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("ContratoClienteId_Z", gxTv_SdtContrato_Contratoclienteid_Z, false, includeNonInitialized);
            AddObjectProperty("ContratoClienteNome_Z", gxTv_SdtContrato_Contratoclientenome_Z, false, includeNonInitialized);
            AddObjectProperty("ContratoClienteDocumento_Z", gxTv_SdtContrato_Contratoclientedocumento_Z, false, includeNonInitialized);
            AddObjectProperty("ContratoClienteRepresentanteNome_Z", gxTv_SdtContrato_Contratoclienterepresentantenome_Z, false, includeNonInitialized);
            AddObjectProperty("ContratoClienteRepresentanteCPF_Z", gxTv_SdtContrato_Contratoclienterepresentantecpf_Z, false, includeNonInitialized);
            AddObjectProperty("ContratoClienteTipoPessoa_Z", gxTv_SdtContrato_Contratoclientetipopessoa_Z, false, includeNonInitialized);
            AddObjectProperty("ContratoTaxa_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtContrato_Contratotaxa_Z, 16, 4)), false, includeNonInitialized);
            AddObjectProperty("ContratoSLA_Z", gxTv_SdtContrato_Contratosla_Z, false, includeNonInitialized);
            AddObjectProperty("ContratoJurosMora_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtContrato_Contratojurosmora_Z, 16, 4)), false, includeNonInitialized);
            AddObjectProperty("ContratoIOFMinimo_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtContrato_Contratoiofminimo_Z, 16, 4)), false, includeNonInitialized);
            AddObjectProperty("ContratoSituacao_Z", gxTv_SdtContrato_Contratosituacao_Z, false, includeNonInitialized);
            AddObjectProperty("AssinaturaUltId_F_Z", gxTv_SdtContrato_Assinaturaultid_f_Z, false, includeNonInitialized);
            AddObjectProperty("ContratoClienteEnderecoCEP_Z", gxTv_SdtContrato_Contratoclienteenderecocep_Z, false, includeNonInitialized);
            AddObjectProperty("ContratoClienteEnderecoLograodouro_Z", gxTv_SdtContrato_Contratoclienteenderecolograodouro_Z, false, includeNonInitialized);
            AddObjectProperty("ContratoClienteEnderecoNumero_Z", gxTv_SdtContrato_Contratoclienteendereconumero_Z, false, includeNonInitialized);
            AddObjectProperty("ContratoClienteEnderecoComplemento_Z", gxTv_SdtContrato_Contratoclienteenderecocomplemento_Z, false, includeNonInitialized);
            AddObjectProperty("ContratoClienteEnderecoBairro_Z", gxTv_SdtContrato_Contratoclienteenderecobairro_Z, false, includeNonInitialized);
            AddObjectProperty("ContratoClienteMunicipioCodigo_Z", gxTv_SdtContrato_Contratoclientemunicipiocodigo_Z, false, includeNonInitialized);
            AddObjectProperty("ContratoPropostaId_Z", gxTv_SdtContrato_Contratopropostaid_Z, false, includeNonInitialized);
            AddObjectProperty("ContratoCountAssinantes_F_Z", gxTv_SdtContrato_Contratocountassinantes_f_Z, false, includeNonInitialized);
            AddObjectProperty("ContratoId_N", gxTv_SdtContrato_Contratoid_N, false, includeNonInitialized);
            AddObjectProperty("ContratoNome_N", gxTv_SdtContrato_Contratonome_N, false, includeNonInitialized);
            AddObjectProperty("ContratoCorpo_N", gxTv_SdtContrato_Contratocorpo_N, false, includeNonInitialized);
            AddObjectProperty("ContratoComVigencia_N", gxTv_SdtContrato_Contratocomvigencia_N, false, includeNonInitialized);
            AddObjectProperty("ContratoDataInicial_N", gxTv_SdtContrato_Contratodatainicial_N, false, includeNonInitialized);
            AddObjectProperty("ContratoDataFinal_N", gxTv_SdtContrato_Contratodatafinal_N, false, includeNonInitialized);
            AddObjectProperty("ContratoClienteId_N", gxTv_SdtContrato_Contratoclienteid_N, false, includeNonInitialized);
            AddObjectProperty("ContratoClienteNome_N", gxTv_SdtContrato_Contratoclientenome_N, false, includeNonInitialized);
            AddObjectProperty("ContratoClienteDocumento_N", gxTv_SdtContrato_Contratoclientedocumento_N, false, includeNonInitialized);
            AddObjectProperty("ContratoClienteRepresentanteNome_N", gxTv_SdtContrato_Contratoclienterepresentantenome_N, false, includeNonInitialized);
            AddObjectProperty("ContratoClienteRepresentanteCPF_N", gxTv_SdtContrato_Contratoclienterepresentantecpf_N, false, includeNonInitialized);
            AddObjectProperty("ContratoClienteTipoPessoa_N", gxTv_SdtContrato_Contratoclientetipopessoa_N, false, includeNonInitialized);
            AddObjectProperty("ContratoTaxa_N", gxTv_SdtContrato_Contratotaxa_N, false, includeNonInitialized);
            AddObjectProperty("ContratoSLA_N", gxTv_SdtContrato_Contratosla_N, false, includeNonInitialized);
            AddObjectProperty("ContratoJurosMora_N", gxTv_SdtContrato_Contratojurosmora_N, false, includeNonInitialized);
            AddObjectProperty("ContratoIOFMinimo_N", gxTv_SdtContrato_Contratoiofminimo_N, false, includeNonInitialized);
            AddObjectProperty("ContratoSituacao_N", gxTv_SdtContrato_Contratosituacao_N, false, includeNonInitialized);
            AddObjectProperty("ContratoBlob_N", gxTv_SdtContrato_Contratoblob_N, false, includeNonInitialized);
            AddObjectProperty("AssinaturaUltId_F_N", gxTv_SdtContrato_Assinaturaultid_f_N, false, includeNonInitialized);
            AddObjectProperty("ContratoClienteEnderecoCEP_N", gxTv_SdtContrato_Contratoclienteenderecocep_N, false, includeNonInitialized);
            AddObjectProperty("ContratoClienteEnderecoLograodouro_N", gxTv_SdtContrato_Contratoclienteenderecolograodouro_N, false, includeNonInitialized);
            AddObjectProperty("ContratoClienteEnderecoNumero_N", gxTv_SdtContrato_Contratoclienteendereconumero_N, false, includeNonInitialized);
            AddObjectProperty("ContratoClienteEnderecoComplemento_N", gxTv_SdtContrato_Contratoclienteenderecocomplemento_N, false, includeNonInitialized);
            AddObjectProperty("ContratoClienteEnderecoBairro_N", gxTv_SdtContrato_Contratoclienteenderecobairro_N, false, includeNonInitialized);
            AddObjectProperty("ContratoClienteMunicipioCodigo_N", gxTv_SdtContrato_Contratoclientemunicipiocodigo_N, false, includeNonInitialized);
            AddObjectProperty("ContratoPropostaId_N", gxTv_SdtContrato_Contratopropostaid_N, false, includeNonInitialized);
            AddObjectProperty("ContratoCountAssinantes_F_N", gxTv_SdtContrato_Contratocountassinantes_f_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtContrato sdt )
      {
         if ( sdt.IsDirty("ContratoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoid = sdt.gxTv_SdtContrato_Contratoid ;
         }
         if ( sdt.IsDirty("ContratoNome") )
         {
            gxTv_SdtContrato_Contratonome_N = (short)(sdt.gxTv_SdtContrato_Contratonome_N);
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratonome = sdt.gxTv_SdtContrato_Contratonome ;
         }
         if ( sdt.IsDirty("ContratoCorpo") )
         {
            gxTv_SdtContrato_Contratocorpo_N = (short)(sdt.gxTv_SdtContrato_Contratocorpo_N);
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratocorpo = sdt.gxTv_SdtContrato_Contratocorpo ;
         }
         if ( sdt.IsDirty("ContratoComVigencia") )
         {
            gxTv_SdtContrato_Contratocomvigencia_N = (short)(sdt.gxTv_SdtContrato_Contratocomvigencia_N);
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratocomvigencia = sdt.gxTv_SdtContrato_Contratocomvigencia ;
         }
         if ( sdt.IsDirty("ContratoDataInicial") )
         {
            gxTv_SdtContrato_Contratodatainicial_N = (short)(sdt.gxTv_SdtContrato_Contratodatainicial_N);
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratodatainicial = sdt.gxTv_SdtContrato_Contratodatainicial ;
         }
         if ( sdt.IsDirty("ContratoDataFinal") )
         {
            gxTv_SdtContrato_Contratodatafinal_N = (short)(sdt.gxTv_SdtContrato_Contratodatafinal_N);
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratodatafinal = sdt.gxTv_SdtContrato_Contratodatafinal ;
         }
         if ( sdt.IsDirty("ContratoClienteId") )
         {
            gxTv_SdtContrato_Contratoclienteid_N = (short)(sdt.gxTv_SdtContrato_Contratoclienteid_N);
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclienteid = sdt.gxTv_SdtContrato_Contratoclienteid ;
         }
         if ( sdt.IsDirty("ContratoClienteNome") )
         {
            gxTv_SdtContrato_Contratoclientenome_N = (short)(sdt.gxTv_SdtContrato_Contratoclientenome_N);
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclientenome = sdt.gxTv_SdtContrato_Contratoclientenome ;
         }
         if ( sdt.IsDirty("ContratoClienteDocumento") )
         {
            gxTv_SdtContrato_Contratoclientedocumento_N = (short)(sdt.gxTv_SdtContrato_Contratoclientedocumento_N);
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclientedocumento = sdt.gxTv_SdtContrato_Contratoclientedocumento ;
         }
         if ( sdt.IsDirty("ContratoClienteRepresentanteNome") )
         {
            gxTv_SdtContrato_Contratoclienterepresentantenome_N = (short)(sdt.gxTv_SdtContrato_Contratoclienterepresentantenome_N);
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclienterepresentantenome = sdt.gxTv_SdtContrato_Contratoclienterepresentantenome ;
         }
         if ( sdt.IsDirty("ContratoClienteRepresentanteCPF") )
         {
            gxTv_SdtContrato_Contratoclienterepresentantecpf_N = (short)(sdt.gxTv_SdtContrato_Contratoclienterepresentantecpf_N);
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclienterepresentantecpf = sdt.gxTv_SdtContrato_Contratoclienterepresentantecpf ;
         }
         if ( sdt.IsDirty("ContratoClienteTipoPessoa") )
         {
            gxTv_SdtContrato_Contratoclientetipopessoa_N = (short)(sdt.gxTv_SdtContrato_Contratoclientetipopessoa_N);
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclientetipopessoa = sdt.gxTv_SdtContrato_Contratoclientetipopessoa ;
         }
         if ( sdt.IsDirty("ContratoTaxa") )
         {
            gxTv_SdtContrato_Contratotaxa_N = (short)(sdt.gxTv_SdtContrato_Contratotaxa_N);
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratotaxa = sdt.gxTv_SdtContrato_Contratotaxa ;
         }
         if ( sdt.IsDirty("ContratoSLA") )
         {
            gxTv_SdtContrato_Contratosla_N = (short)(sdt.gxTv_SdtContrato_Contratosla_N);
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratosla = sdt.gxTv_SdtContrato_Contratosla ;
         }
         if ( sdt.IsDirty("ContratoJurosMora") )
         {
            gxTv_SdtContrato_Contratojurosmora_N = (short)(sdt.gxTv_SdtContrato_Contratojurosmora_N);
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratojurosmora = sdt.gxTv_SdtContrato_Contratojurosmora ;
         }
         if ( sdt.IsDirty("ContratoIOFMinimo") )
         {
            gxTv_SdtContrato_Contratoiofminimo_N = (short)(sdt.gxTv_SdtContrato_Contratoiofminimo_N);
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoiofminimo = sdt.gxTv_SdtContrato_Contratoiofminimo ;
         }
         if ( sdt.IsDirty("ContratoSituacao") )
         {
            gxTv_SdtContrato_Contratosituacao_N = (short)(sdt.gxTv_SdtContrato_Contratosituacao_N);
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratosituacao = sdt.gxTv_SdtContrato_Contratosituacao ;
         }
         if ( sdt.IsDirty("ContratoBlob") )
         {
            gxTv_SdtContrato_Contratoblob_N = (short)(sdt.gxTv_SdtContrato_Contratoblob_N);
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoblob = sdt.gxTv_SdtContrato_Contratoblob ;
         }
         if ( sdt.IsDirty("AssinaturaUltId_F") )
         {
            gxTv_SdtContrato_Assinaturaultid_f_N = (short)(sdt.gxTv_SdtContrato_Assinaturaultid_f_N);
            sdtIsNull = 0;
            gxTv_SdtContrato_Assinaturaultid_f = sdt.gxTv_SdtContrato_Assinaturaultid_f ;
         }
         if ( sdt.IsDirty("ContratoClienteEnderecoCEP") )
         {
            gxTv_SdtContrato_Contratoclienteenderecocep_N = (short)(sdt.gxTv_SdtContrato_Contratoclienteenderecocep_N);
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclienteenderecocep = sdt.gxTv_SdtContrato_Contratoclienteenderecocep ;
         }
         if ( sdt.IsDirty("ContratoClienteEnderecoLograodouro") )
         {
            gxTv_SdtContrato_Contratoclienteenderecolograodouro_N = (short)(sdt.gxTv_SdtContrato_Contratoclienteenderecolograodouro_N);
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclienteenderecolograodouro = sdt.gxTv_SdtContrato_Contratoclienteenderecolograodouro ;
         }
         if ( sdt.IsDirty("ContratoClienteEnderecoNumero") )
         {
            gxTv_SdtContrato_Contratoclienteendereconumero_N = (short)(sdt.gxTv_SdtContrato_Contratoclienteendereconumero_N);
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclienteendereconumero = sdt.gxTv_SdtContrato_Contratoclienteendereconumero ;
         }
         if ( sdt.IsDirty("ContratoClienteEnderecoComplemento") )
         {
            gxTv_SdtContrato_Contratoclienteenderecocomplemento_N = (short)(sdt.gxTv_SdtContrato_Contratoclienteenderecocomplemento_N);
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclienteenderecocomplemento = sdt.gxTv_SdtContrato_Contratoclienteenderecocomplemento ;
         }
         if ( sdt.IsDirty("ContratoClienteEnderecoBairro") )
         {
            gxTv_SdtContrato_Contratoclienteenderecobairro_N = (short)(sdt.gxTv_SdtContrato_Contratoclienteenderecobairro_N);
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclienteenderecobairro = sdt.gxTv_SdtContrato_Contratoclienteenderecobairro ;
         }
         if ( sdt.IsDirty("ContratoClienteMunicipioCodigo") )
         {
            gxTv_SdtContrato_Contratoclientemunicipiocodigo_N = (short)(sdt.gxTv_SdtContrato_Contratoclientemunicipiocodigo_N);
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclientemunicipiocodigo = sdt.gxTv_SdtContrato_Contratoclientemunicipiocodigo ;
         }
         if ( sdt.IsDirty("ContratoPropostaId") )
         {
            gxTv_SdtContrato_Contratopropostaid_N = (short)(sdt.gxTv_SdtContrato_Contratopropostaid_N);
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratopropostaid = sdt.gxTv_SdtContrato_Contratopropostaid ;
         }
         if ( sdt.IsDirty("ContratoCountAssinantes_F") )
         {
            gxTv_SdtContrato_Contratocountassinantes_f_N = (short)(sdt.gxTv_SdtContrato_Contratocountassinantes_f_N);
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratocountassinantes_f = sdt.gxTv_SdtContrato_Contratocountassinantes_f ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ContratoId" )]
      [  XmlElement( ElementName = "ContratoId"   )]
      public int gxTpr_Contratoid
      {
         get {
            return gxTv_SdtContrato_Contratoid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtContrato_Contratoid != value )
            {
               gxTv_SdtContrato_Mode = "INS";
               this.gxTv_SdtContrato_Contratoid_Z_SetNull( );
               this.gxTv_SdtContrato_Contratonome_Z_SetNull( );
               this.gxTv_SdtContrato_Contratocomvigencia_Z_SetNull( );
               this.gxTv_SdtContrato_Contratodatainicial_Z_SetNull( );
               this.gxTv_SdtContrato_Contratodatafinal_Z_SetNull( );
               this.gxTv_SdtContrato_Contratoclienteid_Z_SetNull( );
               this.gxTv_SdtContrato_Contratoclientenome_Z_SetNull( );
               this.gxTv_SdtContrato_Contratoclientedocumento_Z_SetNull( );
               this.gxTv_SdtContrato_Contratoclienterepresentantenome_Z_SetNull( );
               this.gxTv_SdtContrato_Contratoclienterepresentantecpf_Z_SetNull( );
               this.gxTv_SdtContrato_Contratoclientetipopessoa_Z_SetNull( );
               this.gxTv_SdtContrato_Contratotaxa_Z_SetNull( );
               this.gxTv_SdtContrato_Contratosla_Z_SetNull( );
               this.gxTv_SdtContrato_Contratojurosmora_Z_SetNull( );
               this.gxTv_SdtContrato_Contratoiofminimo_Z_SetNull( );
               this.gxTv_SdtContrato_Contratosituacao_Z_SetNull( );
               this.gxTv_SdtContrato_Assinaturaultid_f_Z_SetNull( );
               this.gxTv_SdtContrato_Contratoclienteenderecocep_Z_SetNull( );
               this.gxTv_SdtContrato_Contratoclienteenderecolograodouro_Z_SetNull( );
               this.gxTv_SdtContrato_Contratoclienteendereconumero_Z_SetNull( );
               this.gxTv_SdtContrato_Contratoclienteenderecocomplemento_Z_SetNull( );
               this.gxTv_SdtContrato_Contratoclienteenderecobairro_Z_SetNull( );
               this.gxTv_SdtContrato_Contratoclientemunicipiocodigo_Z_SetNull( );
               this.gxTv_SdtContrato_Contratopropostaid_Z_SetNull( );
               this.gxTv_SdtContrato_Contratocountassinantes_f_Z_SetNull( );
            }
            gxTv_SdtContrato_Contratoid = value;
            SetDirty("Contratoid");
         }

      }

      [  SoapElement( ElementName = "ContratoNome" )]
      [  XmlElement( ElementName = "ContratoNome"   )]
      public string gxTpr_Contratonome
      {
         get {
            return gxTv_SdtContrato_Contratonome ;
         }

         set {
            gxTv_SdtContrato_Contratonome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratonome = value;
            SetDirty("Contratonome");
         }

      }

      public void gxTv_SdtContrato_Contratonome_SetNull( )
      {
         gxTv_SdtContrato_Contratonome_N = 1;
         gxTv_SdtContrato_Contratonome = "";
         SetDirty("Contratonome");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratonome_IsNull( )
      {
         return (gxTv_SdtContrato_Contratonome_N==1) ;
      }

      [  SoapElement( ElementName = "ContratoCorpo" )]
      [  XmlElement( ElementName = "ContratoCorpo"   )]
      public string gxTpr_Contratocorpo
      {
         get {
            return gxTv_SdtContrato_Contratocorpo ;
         }

         set {
            gxTv_SdtContrato_Contratocorpo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratocorpo = value;
            SetDirty("Contratocorpo");
         }

      }

      public void gxTv_SdtContrato_Contratocorpo_SetNull( )
      {
         gxTv_SdtContrato_Contratocorpo_N = 1;
         gxTv_SdtContrato_Contratocorpo = "";
         SetDirty("Contratocorpo");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratocorpo_IsNull( )
      {
         return (gxTv_SdtContrato_Contratocorpo_N==1) ;
      }

      [  SoapElement( ElementName = "ContratoComVigencia" )]
      [  XmlElement( ElementName = "ContratoComVigencia"   )]
      public bool gxTpr_Contratocomvigencia
      {
         get {
            return gxTv_SdtContrato_Contratocomvigencia ;
         }

         set {
            gxTv_SdtContrato_Contratocomvigencia_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratocomvigencia = value;
            SetDirty("Contratocomvigencia");
         }

      }

      public void gxTv_SdtContrato_Contratocomvigencia_SetNull( )
      {
         gxTv_SdtContrato_Contratocomvigencia_N = 1;
         gxTv_SdtContrato_Contratocomvigencia = false;
         SetDirty("Contratocomvigencia");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratocomvigencia_IsNull( )
      {
         return (gxTv_SdtContrato_Contratocomvigencia_N==1) ;
      }

      [  SoapElement( ElementName = "ContratoDataInicial" )]
      [  XmlElement( ElementName = "ContratoDataInicial"  , IsNullable=true )]
      public string gxTpr_Contratodatainicial_Nullable
      {
         get {
            if ( gxTv_SdtContrato_Contratodatainicial == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtContrato_Contratodatainicial).value ;
         }

         set {
            gxTv_SdtContrato_Contratodatainicial_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtContrato_Contratodatainicial = DateTime.MinValue;
            else
               gxTv_SdtContrato_Contratodatainicial = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Contratodatainicial
      {
         get {
            return gxTv_SdtContrato_Contratodatainicial ;
         }

         set {
            gxTv_SdtContrato_Contratodatainicial_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratodatainicial = value;
            SetDirty("Contratodatainicial");
         }

      }

      public void gxTv_SdtContrato_Contratodatainicial_SetNull( )
      {
         gxTv_SdtContrato_Contratodatainicial_N = 1;
         gxTv_SdtContrato_Contratodatainicial = (DateTime)(DateTime.MinValue);
         SetDirty("Contratodatainicial");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratodatainicial_IsNull( )
      {
         return (gxTv_SdtContrato_Contratodatainicial_N==1) ;
      }

      [  SoapElement( ElementName = "ContratoDataFinal" )]
      [  XmlElement( ElementName = "ContratoDataFinal"  , IsNullable=true )]
      public string gxTpr_Contratodatafinal_Nullable
      {
         get {
            if ( gxTv_SdtContrato_Contratodatafinal == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtContrato_Contratodatafinal).value ;
         }

         set {
            gxTv_SdtContrato_Contratodatafinal_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtContrato_Contratodatafinal = DateTime.MinValue;
            else
               gxTv_SdtContrato_Contratodatafinal = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Contratodatafinal
      {
         get {
            return gxTv_SdtContrato_Contratodatafinal ;
         }

         set {
            gxTv_SdtContrato_Contratodatafinal_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratodatafinal = value;
            SetDirty("Contratodatafinal");
         }

      }

      public void gxTv_SdtContrato_Contratodatafinal_SetNull( )
      {
         gxTv_SdtContrato_Contratodatafinal_N = 1;
         gxTv_SdtContrato_Contratodatafinal = (DateTime)(DateTime.MinValue);
         SetDirty("Contratodatafinal");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratodatafinal_IsNull( )
      {
         return (gxTv_SdtContrato_Contratodatafinal_N==1) ;
      }

      [  SoapElement( ElementName = "ContratoClienteId" )]
      [  XmlElement( ElementName = "ContratoClienteId"   )]
      public int gxTpr_Contratoclienteid
      {
         get {
            return gxTv_SdtContrato_Contratoclienteid ;
         }

         set {
            gxTv_SdtContrato_Contratoclienteid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclienteid = value;
            SetDirty("Contratoclienteid");
         }

      }

      public void gxTv_SdtContrato_Contratoclienteid_SetNull( )
      {
         gxTv_SdtContrato_Contratoclienteid_N = 1;
         gxTv_SdtContrato_Contratoclienteid = 0;
         SetDirty("Contratoclienteid");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoclienteid_IsNull( )
      {
         return (gxTv_SdtContrato_Contratoclienteid_N==1) ;
      }

      [  SoapElement( ElementName = "ContratoClienteNome" )]
      [  XmlElement( ElementName = "ContratoClienteNome"   )]
      public string gxTpr_Contratoclientenome
      {
         get {
            return gxTv_SdtContrato_Contratoclientenome ;
         }

         set {
            gxTv_SdtContrato_Contratoclientenome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclientenome = value;
            SetDirty("Contratoclientenome");
         }

      }

      public void gxTv_SdtContrato_Contratoclientenome_SetNull( )
      {
         gxTv_SdtContrato_Contratoclientenome_N = 1;
         gxTv_SdtContrato_Contratoclientenome = "";
         SetDirty("Contratoclientenome");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoclientenome_IsNull( )
      {
         return (gxTv_SdtContrato_Contratoclientenome_N==1) ;
      }

      [  SoapElement( ElementName = "ContratoClienteDocumento" )]
      [  XmlElement( ElementName = "ContratoClienteDocumento"   )]
      public string gxTpr_Contratoclientedocumento
      {
         get {
            return gxTv_SdtContrato_Contratoclientedocumento ;
         }

         set {
            gxTv_SdtContrato_Contratoclientedocumento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclientedocumento = value;
            SetDirty("Contratoclientedocumento");
         }

      }

      public void gxTv_SdtContrato_Contratoclientedocumento_SetNull( )
      {
         gxTv_SdtContrato_Contratoclientedocumento_N = 1;
         gxTv_SdtContrato_Contratoclientedocumento = "";
         SetDirty("Contratoclientedocumento");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoclientedocumento_IsNull( )
      {
         return (gxTv_SdtContrato_Contratoclientedocumento_N==1) ;
      }

      [  SoapElement( ElementName = "ContratoClienteRepresentanteNome" )]
      [  XmlElement( ElementName = "ContratoClienteRepresentanteNome"   )]
      public string gxTpr_Contratoclienterepresentantenome
      {
         get {
            return gxTv_SdtContrato_Contratoclienterepresentantenome ;
         }

         set {
            gxTv_SdtContrato_Contratoclienterepresentantenome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclienterepresentantenome = value;
            SetDirty("Contratoclienterepresentantenome");
         }

      }

      public void gxTv_SdtContrato_Contratoclienterepresentantenome_SetNull( )
      {
         gxTv_SdtContrato_Contratoclienterepresentantenome_N = 1;
         gxTv_SdtContrato_Contratoclienterepresentantenome = "";
         SetDirty("Contratoclienterepresentantenome");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoclienterepresentantenome_IsNull( )
      {
         return (gxTv_SdtContrato_Contratoclienterepresentantenome_N==1) ;
      }

      [  SoapElement( ElementName = "ContratoClienteRepresentanteCPF" )]
      [  XmlElement( ElementName = "ContratoClienteRepresentanteCPF"   )]
      public string gxTpr_Contratoclienterepresentantecpf
      {
         get {
            return gxTv_SdtContrato_Contratoclienterepresentantecpf ;
         }

         set {
            gxTv_SdtContrato_Contratoclienterepresentantecpf_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclienterepresentantecpf = value;
            SetDirty("Contratoclienterepresentantecpf");
         }

      }

      public void gxTv_SdtContrato_Contratoclienterepresentantecpf_SetNull( )
      {
         gxTv_SdtContrato_Contratoclienterepresentantecpf_N = 1;
         gxTv_SdtContrato_Contratoclienterepresentantecpf = "";
         SetDirty("Contratoclienterepresentantecpf");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoclienterepresentantecpf_IsNull( )
      {
         return (gxTv_SdtContrato_Contratoclienterepresentantecpf_N==1) ;
      }

      [  SoapElement( ElementName = "ContratoClienteTipoPessoa" )]
      [  XmlElement( ElementName = "ContratoClienteTipoPessoa"   )]
      public string gxTpr_Contratoclientetipopessoa
      {
         get {
            return gxTv_SdtContrato_Contratoclientetipopessoa ;
         }

         set {
            gxTv_SdtContrato_Contratoclientetipopessoa_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclientetipopessoa = value;
            SetDirty("Contratoclientetipopessoa");
         }

      }

      public void gxTv_SdtContrato_Contratoclientetipopessoa_SetNull( )
      {
         gxTv_SdtContrato_Contratoclientetipopessoa_N = 1;
         gxTv_SdtContrato_Contratoclientetipopessoa = "";
         SetDirty("Contratoclientetipopessoa");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoclientetipopessoa_IsNull( )
      {
         return (gxTv_SdtContrato_Contratoclientetipopessoa_N==1) ;
      }

      [  SoapElement( ElementName = "ContratoTaxa" )]
      [  XmlElement( ElementName = "ContratoTaxa"   )]
      public decimal gxTpr_Contratotaxa
      {
         get {
            return gxTv_SdtContrato_Contratotaxa ;
         }

         set {
            gxTv_SdtContrato_Contratotaxa_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratotaxa = value;
            SetDirty("Contratotaxa");
         }

      }

      public void gxTv_SdtContrato_Contratotaxa_SetNull( )
      {
         gxTv_SdtContrato_Contratotaxa_N = 1;
         gxTv_SdtContrato_Contratotaxa = 0;
         SetDirty("Contratotaxa");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratotaxa_IsNull( )
      {
         return (gxTv_SdtContrato_Contratotaxa_N==1) ;
      }

      [  SoapElement( ElementName = "ContratoSLA" )]
      [  XmlElement( ElementName = "ContratoSLA"   )]
      public short gxTpr_Contratosla
      {
         get {
            return gxTv_SdtContrato_Contratosla ;
         }

         set {
            gxTv_SdtContrato_Contratosla_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratosla = value;
            SetDirty("Contratosla");
         }

      }

      public void gxTv_SdtContrato_Contratosla_SetNull( )
      {
         gxTv_SdtContrato_Contratosla_N = 1;
         gxTv_SdtContrato_Contratosla = 0;
         SetDirty("Contratosla");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratosla_IsNull( )
      {
         return (gxTv_SdtContrato_Contratosla_N==1) ;
      }

      [  SoapElement( ElementName = "ContratoJurosMora" )]
      [  XmlElement( ElementName = "ContratoJurosMora"   )]
      public decimal gxTpr_Contratojurosmora
      {
         get {
            return gxTv_SdtContrato_Contratojurosmora ;
         }

         set {
            gxTv_SdtContrato_Contratojurosmora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratojurosmora = value;
            SetDirty("Contratojurosmora");
         }

      }

      public void gxTv_SdtContrato_Contratojurosmora_SetNull( )
      {
         gxTv_SdtContrato_Contratojurosmora_N = 1;
         gxTv_SdtContrato_Contratojurosmora = 0;
         SetDirty("Contratojurosmora");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratojurosmora_IsNull( )
      {
         return (gxTv_SdtContrato_Contratojurosmora_N==1) ;
      }

      [  SoapElement( ElementName = "ContratoIOFMinimo" )]
      [  XmlElement( ElementName = "ContratoIOFMinimo"   )]
      public decimal gxTpr_Contratoiofminimo
      {
         get {
            return gxTv_SdtContrato_Contratoiofminimo ;
         }

         set {
            gxTv_SdtContrato_Contratoiofminimo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoiofminimo = value;
            SetDirty("Contratoiofminimo");
         }

      }

      public void gxTv_SdtContrato_Contratoiofminimo_SetNull( )
      {
         gxTv_SdtContrato_Contratoiofminimo_N = 1;
         gxTv_SdtContrato_Contratoiofminimo = 0;
         SetDirty("Contratoiofminimo");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoiofminimo_IsNull( )
      {
         return (gxTv_SdtContrato_Contratoiofminimo_N==1) ;
      }

      [  SoapElement( ElementName = "ContratoSituacao" )]
      [  XmlElement( ElementName = "ContratoSituacao"   )]
      public string gxTpr_Contratosituacao
      {
         get {
            return gxTv_SdtContrato_Contratosituacao ;
         }

         set {
            gxTv_SdtContrato_Contratosituacao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratosituacao = value;
            SetDirty("Contratosituacao");
         }

      }

      public void gxTv_SdtContrato_Contratosituacao_SetNull( )
      {
         gxTv_SdtContrato_Contratosituacao_N = 1;
         gxTv_SdtContrato_Contratosituacao = "";
         SetDirty("Contratosituacao");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratosituacao_IsNull( )
      {
         return (gxTv_SdtContrato_Contratosituacao_N==1) ;
      }

      [  SoapElement( ElementName = "ContratoBlob" )]
      [  XmlElement( ElementName = "ContratoBlob"   )]
      [GxUpload()]
      public byte[] gxTpr_Contratoblob_Blob
      {
         get {
            IGxContext context = this.context == null ? new GxContext() : this.context;
            return context.FileToByteArray( gxTv_SdtContrato_Contratoblob) ;
         }

         set {
            gxTv_SdtContrato_Contratoblob_N = 0;
            sdtIsNull = 0;
            IGxContext context = this.context == null ? new GxContext() : this.context;
            gxTv_SdtContrato_Contratoblob=context.FileFromByteArray( value) ;
         }

      }

      [XmlIgnore]
      [GxUpload()]
      public string gxTpr_Contratoblob
      {
         get {
            return gxTv_SdtContrato_Contratoblob ;
         }

         set {
            gxTv_SdtContrato_Contratoblob_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoblob = value;
            SetDirty("Contratoblob");
         }

      }

      public void gxTv_SdtContrato_Contratoblob_SetBlob( string blob ,
                                                         string fileName ,
                                                         string fileType )
      {
         gxTv_SdtContrato_Contratoblob = blob;
         return  ;
      }

      public void gxTv_SdtContrato_Contratoblob_SetNull( )
      {
         gxTv_SdtContrato_Contratoblob_N = 1;
         gxTv_SdtContrato_Contratoblob = "";
         SetDirty("Contratoblob");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoblob_IsNull( )
      {
         return (gxTv_SdtContrato_Contratoblob_N==1) ;
      }

      [  SoapElement( ElementName = "AssinaturaUltId_F" )]
      [  XmlElement( ElementName = "AssinaturaUltId_F"   )]
      public short gxTpr_Assinaturaultid_f
      {
         get {
            return gxTv_SdtContrato_Assinaturaultid_f ;
         }

         set {
            gxTv_SdtContrato_Assinaturaultid_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContrato_Assinaturaultid_f = value;
            SetDirty("Assinaturaultid_f");
         }

      }

      public void gxTv_SdtContrato_Assinaturaultid_f_SetNull( )
      {
         gxTv_SdtContrato_Assinaturaultid_f_N = 1;
         gxTv_SdtContrato_Assinaturaultid_f = 0;
         SetDirty("Assinaturaultid_f");
         return  ;
      }

      public bool gxTv_SdtContrato_Assinaturaultid_f_IsNull( )
      {
         return (gxTv_SdtContrato_Assinaturaultid_f_N==1) ;
      }

      [  SoapElement( ElementName = "ContratoClienteEnderecoCEP" )]
      [  XmlElement( ElementName = "ContratoClienteEnderecoCEP"   )]
      public string gxTpr_Contratoclienteenderecocep
      {
         get {
            return gxTv_SdtContrato_Contratoclienteenderecocep ;
         }

         set {
            gxTv_SdtContrato_Contratoclienteenderecocep_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclienteenderecocep = value;
            SetDirty("Contratoclienteenderecocep");
         }

      }

      public void gxTv_SdtContrato_Contratoclienteenderecocep_SetNull( )
      {
         gxTv_SdtContrato_Contratoclienteenderecocep_N = 1;
         gxTv_SdtContrato_Contratoclienteenderecocep = "";
         SetDirty("Contratoclienteenderecocep");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoclienteenderecocep_IsNull( )
      {
         return (gxTv_SdtContrato_Contratoclienteenderecocep_N==1) ;
      }

      [  SoapElement( ElementName = "ContratoClienteEnderecoLograodouro" )]
      [  XmlElement( ElementName = "ContratoClienteEnderecoLograodouro"   )]
      public string gxTpr_Contratoclienteenderecolograodouro
      {
         get {
            return gxTv_SdtContrato_Contratoclienteenderecolograodouro ;
         }

         set {
            gxTv_SdtContrato_Contratoclienteenderecolograodouro_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclienteenderecolograodouro = value;
            SetDirty("Contratoclienteenderecolograodouro");
         }

      }

      public void gxTv_SdtContrato_Contratoclienteenderecolograodouro_SetNull( )
      {
         gxTv_SdtContrato_Contratoclienteenderecolograodouro_N = 1;
         gxTv_SdtContrato_Contratoclienteenderecolograodouro = "";
         SetDirty("Contratoclienteenderecolograodouro");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoclienteenderecolograodouro_IsNull( )
      {
         return (gxTv_SdtContrato_Contratoclienteenderecolograodouro_N==1) ;
      }

      [  SoapElement( ElementName = "ContratoClienteEnderecoNumero" )]
      [  XmlElement( ElementName = "ContratoClienteEnderecoNumero"   )]
      public string gxTpr_Contratoclienteendereconumero
      {
         get {
            return gxTv_SdtContrato_Contratoclienteendereconumero ;
         }

         set {
            gxTv_SdtContrato_Contratoclienteendereconumero_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclienteendereconumero = value;
            SetDirty("Contratoclienteendereconumero");
         }

      }

      public void gxTv_SdtContrato_Contratoclienteendereconumero_SetNull( )
      {
         gxTv_SdtContrato_Contratoclienteendereconumero_N = 1;
         gxTv_SdtContrato_Contratoclienteendereconumero = "";
         SetDirty("Contratoclienteendereconumero");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoclienteendereconumero_IsNull( )
      {
         return (gxTv_SdtContrato_Contratoclienteendereconumero_N==1) ;
      }

      [  SoapElement( ElementName = "ContratoClienteEnderecoComplemento" )]
      [  XmlElement( ElementName = "ContratoClienteEnderecoComplemento"   )]
      public string gxTpr_Contratoclienteenderecocomplemento
      {
         get {
            return gxTv_SdtContrato_Contratoclienteenderecocomplemento ;
         }

         set {
            gxTv_SdtContrato_Contratoclienteenderecocomplemento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclienteenderecocomplemento = value;
            SetDirty("Contratoclienteenderecocomplemento");
         }

      }

      public void gxTv_SdtContrato_Contratoclienteenderecocomplemento_SetNull( )
      {
         gxTv_SdtContrato_Contratoclienteenderecocomplemento_N = 1;
         gxTv_SdtContrato_Contratoclienteenderecocomplemento = "";
         SetDirty("Contratoclienteenderecocomplemento");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoclienteenderecocomplemento_IsNull( )
      {
         return (gxTv_SdtContrato_Contratoclienteenderecocomplemento_N==1) ;
      }

      [  SoapElement( ElementName = "ContratoClienteEnderecoBairro" )]
      [  XmlElement( ElementName = "ContratoClienteEnderecoBairro"   )]
      public string gxTpr_Contratoclienteenderecobairro
      {
         get {
            return gxTv_SdtContrato_Contratoclienteenderecobairro ;
         }

         set {
            gxTv_SdtContrato_Contratoclienteenderecobairro_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclienteenderecobairro = value;
            SetDirty("Contratoclienteenderecobairro");
         }

      }

      public void gxTv_SdtContrato_Contratoclienteenderecobairro_SetNull( )
      {
         gxTv_SdtContrato_Contratoclienteenderecobairro_N = 1;
         gxTv_SdtContrato_Contratoclienteenderecobairro = "";
         SetDirty("Contratoclienteenderecobairro");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoclienteenderecobairro_IsNull( )
      {
         return (gxTv_SdtContrato_Contratoclienteenderecobairro_N==1) ;
      }

      [  SoapElement( ElementName = "ContratoClienteMunicipioCodigo" )]
      [  XmlElement( ElementName = "ContratoClienteMunicipioCodigo"   )]
      public string gxTpr_Contratoclientemunicipiocodigo
      {
         get {
            return gxTv_SdtContrato_Contratoclientemunicipiocodigo ;
         }

         set {
            gxTv_SdtContrato_Contratoclientemunicipiocodigo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclientemunicipiocodigo = value;
            SetDirty("Contratoclientemunicipiocodigo");
         }

      }

      public void gxTv_SdtContrato_Contratoclientemunicipiocodigo_SetNull( )
      {
         gxTv_SdtContrato_Contratoclientemunicipiocodigo_N = 1;
         gxTv_SdtContrato_Contratoclientemunicipiocodigo = "";
         SetDirty("Contratoclientemunicipiocodigo");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoclientemunicipiocodigo_IsNull( )
      {
         return (gxTv_SdtContrato_Contratoclientemunicipiocodigo_N==1) ;
      }

      [  SoapElement( ElementName = "ContratoPropostaId" )]
      [  XmlElement( ElementName = "ContratoPropostaId"   )]
      public int gxTpr_Contratopropostaid
      {
         get {
            return gxTv_SdtContrato_Contratopropostaid ;
         }

         set {
            gxTv_SdtContrato_Contratopropostaid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratopropostaid = value;
            SetDirty("Contratopropostaid");
         }

      }

      public void gxTv_SdtContrato_Contratopropostaid_SetNull( )
      {
         gxTv_SdtContrato_Contratopropostaid_N = 1;
         gxTv_SdtContrato_Contratopropostaid = 0;
         SetDirty("Contratopropostaid");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratopropostaid_IsNull( )
      {
         return (gxTv_SdtContrato_Contratopropostaid_N==1) ;
      }

      [  SoapElement( ElementName = "ContratoCountAssinantes_F" )]
      [  XmlElement( ElementName = "ContratoCountAssinantes_F"   )]
      public short gxTpr_Contratocountassinantes_f
      {
         get {
            return gxTv_SdtContrato_Contratocountassinantes_f ;
         }

         set {
            gxTv_SdtContrato_Contratocountassinantes_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratocountassinantes_f = value;
            SetDirty("Contratocountassinantes_f");
         }

      }

      public void gxTv_SdtContrato_Contratocountassinantes_f_SetNull( )
      {
         gxTv_SdtContrato_Contratocountassinantes_f_N = 1;
         gxTv_SdtContrato_Contratocountassinantes_f = 0;
         SetDirty("Contratocountassinantes_f");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratocountassinantes_f_IsNull( )
      {
         return (gxTv_SdtContrato_Contratocountassinantes_f_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtContrato_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtContrato_Mode_SetNull( )
      {
         gxTv_SdtContrato_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtContrato_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtContrato_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtContrato_Initialized_SetNull( )
      {
         gxTv_SdtContrato_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtContrato_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoId_Z" )]
      [  XmlElement( ElementName = "ContratoId_Z"   )]
      public int gxTpr_Contratoid_Z
      {
         get {
            return gxTv_SdtContrato_Contratoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoid_Z = value;
            SetDirty("Contratoid_Z");
         }

      }

      public void gxTv_SdtContrato_Contratoid_Z_SetNull( )
      {
         gxTv_SdtContrato_Contratoid_Z = 0;
         SetDirty("Contratoid_Z");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoNome_Z" )]
      [  XmlElement( ElementName = "ContratoNome_Z"   )]
      public string gxTpr_Contratonome_Z
      {
         get {
            return gxTv_SdtContrato_Contratonome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratonome_Z = value;
            SetDirty("Contratonome_Z");
         }

      }

      public void gxTv_SdtContrato_Contratonome_Z_SetNull( )
      {
         gxTv_SdtContrato_Contratonome_Z = "";
         SetDirty("Contratonome_Z");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoComVigencia_Z" )]
      [  XmlElement( ElementName = "ContratoComVigencia_Z"   )]
      public bool gxTpr_Contratocomvigencia_Z
      {
         get {
            return gxTv_SdtContrato_Contratocomvigencia_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratocomvigencia_Z = value;
            SetDirty("Contratocomvigencia_Z");
         }

      }

      public void gxTv_SdtContrato_Contratocomvigencia_Z_SetNull( )
      {
         gxTv_SdtContrato_Contratocomvigencia_Z = false;
         SetDirty("Contratocomvigencia_Z");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratocomvigencia_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoDataInicial_Z" )]
      [  XmlElement( ElementName = "ContratoDataInicial_Z"  , IsNullable=true )]
      public string gxTpr_Contratodatainicial_Z_Nullable
      {
         get {
            if ( gxTv_SdtContrato_Contratodatainicial_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtContrato_Contratodatainicial_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtContrato_Contratodatainicial_Z = DateTime.MinValue;
            else
               gxTv_SdtContrato_Contratodatainicial_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Contratodatainicial_Z
      {
         get {
            return gxTv_SdtContrato_Contratodatainicial_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratodatainicial_Z = value;
            SetDirty("Contratodatainicial_Z");
         }

      }

      public void gxTv_SdtContrato_Contratodatainicial_Z_SetNull( )
      {
         gxTv_SdtContrato_Contratodatainicial_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Contratodatainicial_Z");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratodatainicial_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoDataFinal_Z" )]
      [  XmlElement( ElementName = "ContratoDataFinal_Z"  , IsNullable=true )]
      public string gxTpr_Contratodatafinal_Z_Nullable
      {
         get {
            if ( gxTv_SdtContrato_Contratodatafinal_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtContrato_Contratodatafinal_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtContrato_Contratodatafinal_Z = DateTime.MinValue;
            else
               gxTv_SdtContrato_Contratodatafinal_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Contratodatafinal_Z
      {
         get {
            return gxTv_SdtContrato_Contratodatafinal_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratodatafinal_Z = value;
            SetDirty("Contratodatafinal_Z");
         }

      }

      public void gxTv_SdtContrato_Contratodatafinal_Z_SetNull( )
      {
         gxTv_SdtContrato_Contratodatafinal_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Contratodatafinal_Z");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratodatafinal_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoClienteId_Z" )]
      [  XmlElement( ElementName = "ContratoClienteId_Z"   )]
      public int gxTpr_Contratoclienteid_Z
      {
         get {
            return gxTv_SdtContrato_Contratoclienteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclienteid_Z = value;
            SetDirty("Contratoclienteid_Z");
         }

      }

      public void gxTv_SdtContrato_Contratoclienteid_Z_SetNull( )
      {
         gxTv_SdtContrato_Contratoclienteid_Z = 0;
         SetDirty("Contratoclienteid_Z");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoclienteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoClienteNome_Z" )]
      [  XmlElement( ElementName = "ContratoClienteNome_Z"   )]
      public string gxTpr_Contratoclientenome_Z
      {
         get {
            return gxTv_SdtContrato_Contratoclientenome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclientenome_Z = value;
            SetDirty("Contratoclientenome_Z");
         }

      }

      public void gxTv_SdtContrato_Contratoclientenome_Z_SetNull( )
      {
         gxTv_SdtContrato_Contratoclientenome_Z = "";
         SetDirty("Contratoclientenome_Z");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoclientenome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoClienteDocumento_Z" )]
      [  XmlElement( ElementName = "ContratoClienteDocumento_Z"   )]
      public string gxTpr_Contratoclientedocumento_Z
      {
         get {
            return gxTv_SdtContrato_Contratoclientedocumento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclientedocumento_Z = value;
            SetDirty("Contratoclientedocumento_Z");
         }

      }

      public void gxTv_SdtContrato_Contratoclientedocumento_Z_SetNull( )
      {
         gxTv_SdtContrato_Contratoclientedocumento_Z = "";
         SetDirty("Contratoclientedocumento_Z");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoclientedocumento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoClienteRepresentanteNome_Z" )]
      [  XmlElement( ElementName = "ContratoClienteRepresentanteNome_Z"   )]
      public string gxTpr_Contratoclienterepresentantenome_Z
      {
         get {
            return gxTv_SdtContrato_Contratoclienterepresentantenome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclienterepresentantenome_Z = value;
            SetDirty("Contratoclienterepresentantenome_Z");
         }

      }

      public void gxTv_SdtContrato_Contratoclienterepresentantenome_Z_SetNull( )
      {
         gxTv_SdtContrato_Contratoclienterepresentantenome_Z = "";
         SetDirty("Contratoclienterepresentantenome_Z");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoclienterepresentantenome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoClienteRepresentanteCPF_Z" )]
      [  XmlElement( ElementName = "ContratoClienteRepresentanteCPF_Z"   )]
      public string gxTpr_Contratoclienterepresentantecpf_Z
      {
         get {
            return gxTv_SdtContrato_Contratoclienterepresentantecpf_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclienterepresentantecpf_Z = value;
            SetDirty("Contratoclienterepresentantecpf_Z");
         }

      }

      public void gxTv_SdtContrato_Contratoclienterepresentantecpf_Z_SetNull( )
      {
         gxTv_SdtContrato_Contratoclienterepresentantecpf_Z = "";
         SetDirty("Contratoclienterepresentantecpf_Z");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoclienterepresentantecpf_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoClienteTipoPessoa_Z" )]
      [  XmlElement( ElementName = "ContratoClienteTipoPessoa_Z"   )]
      public string gxTpr_Contratoclientetipopessoa_Z
      {
         get {
            return gxTv_SdtContrato_Contratoclientetipopessoa_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclientetipopessoa_Z = value;
            SetDirty("Contratoclientetipopessoa_Z");
         }

      }

      public void gxTv_SdtContrato_Contratoclientetipopessoa_Z_SetNull( )
      {
         gxTv_SdtContrato_Contratoclientetipopessoa_Z = "";
         SetDirty("Contratoclientetipopessoa_Z");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoclientetipopessoa_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoTaxa_Z" )]
      [  XmlElement( ElementName = "ContratoTaxa_Z"   )]
      public decimal gxTpr_Contratotaxa_Z
      {
         get {
            return gxTv_SdtContrato_Contratotaxa_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratotaxa_Z = value;
            SetDirty("Contratotaxa_Z");
         }

      }

      public void gxTv_SdtContrato_Contratotaxa_Z_SetNull( )
      {
         gxTv_SdtContrato_Contratotaxa_Z = 0;
         SetDirty("Contratotaxa_Z");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratotaxa_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoSLA_Z" )]
      [  XmlElement( ElementName = "ContratoSLA_Z"   )]
      public short gxTpr_Contratosla_Z
      {
         get {
            return gxTv_SdtContrato_Contratosla_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratosla_Z = value;
            SetDirty("Contratosla_Z");
         }

      }

      public void gxTv_SdtContrato_Contratosla_Z_SetNull( )
      {
         gxTv_SdtContrato_Contratosla_Z = 0;
         SetDirty("Contratosla_Z");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratosla_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoJurosMora_Z" )]
      [  XmlElement( ElementName = "ContratoJurosMora_Z"   )]
      public decimal gxTpr_Contratojurosmora_Z
      {
         get {
            return gxTv_SdtContrato_Contratojurosmora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratojurosmora_Z = value;
            SetDirty("Contratojurosmora_Z");
         }

      }

      public void gxTv_SdtContrato_Contratojurosmora_Z_SetNull( )
      {
         gxTv_SdtContrato_Contratojurosmora_Z = 0;
         SetDirty("Contratojurosmora_Z");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratojurosmora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoIOFMinimo_Z" )]
      [  XmlElement( ElementName = "ContratoIOFMinimo_Z"   )]
      public decimal gxTpr_Contratoiofminimo_Z
      {
         get {
            return gxTv_SdtContrato_Contratoiofminimo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoiofminimo_Z = value;
            SetDirty("Contratoiofminimo_Z");
         }

      }

      public void gxTv_SdtContrato_Contratoiofminimo_Z_SetNull( )
      {
         gxTv_SdtContrato_Contratoiofminimo_Z = 0;
         SetDirty("Contratoiofminimo_Z");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoiofminimo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoSituacao_Z" )]
      [  XmlElement( ElementName = "ContratoSituacao_Z"   )]
      public string gxTpr_Contratosituacao_Z
      {
         get {
            return gxTv_SdtContrato_Contratosituacao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratosituacao_Z = value;
            SetDirty("Contratosituacao_Z");
         }

      }

      public void gxTv_SdtContrato_Contratosituacao_Z_SetNull( )
      {
         gxTv_SdtContrato_Contratosituacao_Z = "";
         SetDirty("Contratosituacao_Z");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratosituacao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaUltId_F_Z" )]
      [  XmlElement( ElementName = "AssinaturaUltId_F_Z"   )]
      public short gxTpr_Assinaturaultid_f_Z
      {
         get {
            return gxTv_SdtContrato_Assinaturaultid_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Assinaturaultid_f_Z = value;
            SetDirty("Assinaturaultid_f_Z");
         }

      }

      public void gxTv_SdtContrato_Assinaturaultid_f_Z_SetNull( )
      {
         gxTv_SdtContrato_Assinaturaultid_f_Z = 0;
         SetDirty("Assinaturaultid_f_Z");
         return  ;
      }

      public bool gxTv_SdtContrato_Assinaturaultid_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoClienteEnderecoCEP_Z" )]
      [  XmlElement( ElementName = "ContratoClienteEnderecoCEP_Z"   )]
      public string gxTpr_Contratoclienteenderecocep_Z
      {
         get {
            return gxTv_SdtContrato_Contratoclienteenderecocep_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclienteenderecocep_Z = value;
            SetDirty("Contratoclienteenderecocep_Z");
         }

      }

      public void gxTv_SdtContrato_Contratoclienteenderecocep_Z_SetNull( )
      {
         gxTv_SdtContrato_Contratoclienteenderecocep_Z = "";
         SetDirty("Contratoclienteenderecocep_Z");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoclienteenderecocep_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoClienteEnderecoLograodouro_Z" )]
      [  XmlElement( ElementName = "ContratoClienteEnderecoLograodouro_Z"   )]
      public string gxTpr_Contratoclienteenderecolograodouro_Z
      {
         get {
            return gxTv_SdtContrato_Contratoclienteenderecolograodouro_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclienteenderecolograodouro_Z = value;
            SetDirty("Contratoclienteenderecolograodouro_Z");
         }

      }

      public void gxTv_SdtContrato_Contratoclienteenderecolograodouro_Z_SetNull( )
      {
         gxTv_SdtContrato_Contratoclienteenderecolograodouro_Z = "";
         SetDirty("Contratoclienteenderecolograodouro_Z");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoclienteenderecolograodouro_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoClienteEnderecoNumero_Z" )]
      [  XmlElement( ElementName = "ContratoClienteEnderecoNumero_Z"   )]
      public string gxTpr_Contratoclienteendereconumero_Z
      {
         get {
            return gxTv_SdtContrato_Contratoclienteendereconumero_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclienteendereconumero_Z = value;
            SetDirty("Contratoclienteendereconumero_Z");
         }

      }

      public void gxTv_SdtContrato_Contratoclienteendereconumero_Z_SetNull( )
      {
         gxTv_SdtContrato_Contratoclienteendereconumero_Z = "";
         SetDirty("Contratoclienteendereconumero_Z");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoclienteendereconumero_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoClienteEnderecoComplemento_Z" )]
      [  XmlElement( ElementName = "ContratoClienteEnderecoComplemento_Z"   )]
      public string gxTpr_Contratoclienteenderecocomplemento_Z
      {
         get {
            return gxTv_SdtContrato_Contratoclienteenderecocomplemento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclienteenderecocomplemento_Z = value;
            SetDirty("Contratoclienteenderecocomplemento_Z");
         }

      }

      public void gxTv_SdtContrato_Contratoclienteenderecocomplemento_Z_SetNull( )
      {
         gxTv_SdtContrato_Contratoclienteenderecocomplemento_Z = "";
         SetDirty("Contratoclienteenderecocomplemento_Z");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoclienteenderecocomplemento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoClienteEnderecoBairro_Z" )]
      [  XmlElement( ElementName = "ContratoClienteEnderecoBairro_Z"   )]
      public string gxTpr_Contratoclienteenderecobairro_Z
      {
         get {
            return gxTv_SdtContrato_Contratoclienteenderecobairro_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclienteenderecobairro_Z = value;
            SetDirty("Contratoclienteenderecobairro_Z");
         }

      }

      public void gxTv_SdtContrato_Contratoclienteenderecobairro_Z_SetNull( )
      {
         gxTv_SdtContrato_Contratoclienteenderecobairro_Z = "";
         SetDirty("Contratoclienteenderecobairro_Z");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoclienteenderecobairro_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoClienteMunicipioCodigo_Z" )]
      [  XmlElement( ElementName = "ContratoClienteMunicipioCodigo_Z"   )]
      public string gxTpr_Contratoclientemunicipiocodigo_Z
      {
         get {
            return gxTv_SdtContrato_Contratoclientemunicipiocodigo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclientemunicipiocodigo_Z = value;
            SetDirty("Contratoclientemunicipiocodigo_Z");
         }

      }

      public void gxTv_SdtContrato_Contratoclientemunicipiocodigo_Z_SetNull( )
      {
         gxTv_SdtContrato_Contratoclientemunicipiocodigo_Z = "";
         SetDirty("Contratoclientemunicipiocodigo_Z");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoclientemunicipiocodigo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoPropostaId_Z" )]
      [  XmlElement( ElementName = "ContratoPropostaId_Z"   )]
      public int gxTpr_Contratopropostaid_Z
      {
         get {
            return gxTv_SdtContrato_Contratopropostaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratopropostaid_Z = value;
            SetDirty("Contratopropostaid_Z");
         }

      }

      public void gxTv_SdtContrato_Contratopropostaid_Z_SetNull( )
      {
         gxTv_SdtContrato_Contratopropostaid_Z = 0;
         SetDirty("Contratopropostaid_Z");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratopropostaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoCountAssinantes_F_Z" )]
      [  XmlElement( ElementName = "ContratoCountAssinantes_F_Z"   )]
      public short gxTpr_Contratocountassinantes_f_Z
      {
         get {
            return gxTv_SdtContrato_Contratocountassinantes_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratocountassinantes_f_Z = value;
            SetDirty("Contratocountassinantes_f_Z");
         }

      }

      public void gxTv_SdtContrato_Contratocountassinantes_f_Z_SetNull( )
      {
         gxTv_SdtContrato_Contratocountassinantes_f_Z = 0;
         SetDirty("Contratocountassinantes_f_Z");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratocountassinantes_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoId_N" )]
      [  XmlElement( ElementName = "ContratoId_N"   )]
      public short gxTpr_Contratoid_N
      {
         get {
            return gxTv_SdtContrato_Contratoid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoid_N = value;
            SetDirty("Contratoid_N");
         }

      }

      public void gxTv_SdtContrato_Contratoid_N_SetNull( )
      {
         gxTv_SdtContrato_Contratoid_N = 0;
         SetDirty("Contratoid_N");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoNome_N" )]
      [  XmlElement( ElementName = "ContratoNome_N"   )]
      public short gxTpr_Contratonome_N
      {
         get {
            return gxTv_SdtContrato_Contratonome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratonome_N = value;
            SetDirty("Contratonome_N");
         }

      }

      public void gxTv_SdtContrato_Contratonome_N_SetNull( )
      {
         gxTv_SdtContrato_Contratonome_N = 0;
         SetDirty("Contratonome_N");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratonome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoCorpo_N" )]
      [  XmlElement( ElementName = "ContratoCorpo_N"   )]
      public short gxTpr_Contratocorpo_N
      {
         get {
            return gxTv_SdtContrato_Contratocorpo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratocorpo_N = value;
            SetDirty("Contratocorpo_N");
         }

      }

      public void gxTv_SdtContrato_Contratocorpo_N_SetNull( )
      {
         gxTv_SdtContrato_Contratocorpo_N = 0;
         SetDirty("Contratocorpo_N");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratocorpo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoComVigencia_N" )]
      [  XmlElement( ElementName = "ContratoComVigencia_N"   )]
      public short gxTpr_Contratocomvigencia_N
      {
         get {
            return gxTv_SdtContrato_Contratocomvigencia_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratocomvigencia_N = value;
            SetDirty("Contratocomvigencia_N");
         }

      }

      public void gxTv_SdtContrato_Contratocomvigencia_N_SetNull( )
      {
         gxTv_SdtContrato_Contratocomvigencia_N = 0;
         SetDirty("Contratocomvigencia_N");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratocomvigencia_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoDataInicial_N" )]
      [  XmlElement( ElementName = "ContratoDataInicial_N"   )]
      public short gxTpr_Contratodatainicial_N
      {
         get {
            return gxTv_SdtContrato_Contratodatainicial_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratodatainicial_N = value;
            SetDirty("Contratodatainicial_N");
         }

      }

      public void gxTv_SdtContrato_Contratodatainicial_N_SetNull( )
      {
         gxTv_SdtContrato_Contratodatainicial_N = 0;
         SetDirty("Contratodatainicial_N");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratodatainicial_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoDataFinal_N" )]
      [  XmlElement( ElementName = "ContratoDataFinal_N"   )]
      public short gxTpr_Contratodatafinal_N
      {
         get {
            return gxTv_SdtContrato_Contratodatafinal_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratodatafinal_N = value;
            SetDirty("Contratodatafinal_N");
         }

      }

      public void gxTv_SdtContrato_Contratodatafinal_N_SetNull( )
      {
         gxTv_SdtContrato_Contratodatafinal_N = 0;
         SetDirty("Contratodatafinal_N");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratodatafinal_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoClienteId_N" )]
      [  XmlElement( ElementName = "ContratoClienteId_N"   )]
      public short gxTpr_Contratoclienteid_N
      {
         get {
            return gxTv_SdtContrato_Contratoclienteid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclienteid_N = value;
            SetDirty("Contratoclienteid_N");
         }

      }

      public void gxTv_SdtContrato_Contratoclienteid_N_SetNull( )
      {
         gxTv_SdtContrato_Contratoclienteid_N = 0;
         SetDirty("Contratoclienteid_N");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoclienteid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoClienteNome_N" )]
      [  XmlElement( ElementName = "ContratoClienteNome_N"   )]
      public short gxTpr_Contratoclientenome_N
      {
         get {
            return gxTv_SdtContrato_Contratoclientenome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclientenome_N = value;
            SetDirty("Contratoclientenome_N");
         }

      }

      public void gxTv_SdtContrato_Contratoclientenome_N_SetNull( )
      {
         gxTv_SdtContrato_Contratoclientenome_N = 0;
         SetDirty("Contratoclientenome_N");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoclientenome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoClienteDocumento_N" )]
      [  XmlElement( ElementName = "ContratoClienteDocumento_N"   )]
      public short gxTpr_Contratoclientedocumento_N
      {
         get {
            return gxTv_SdtContrato_Contratoclientedocumento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclientedocumento_N = value;
            SetDirty("Contratoclientedocumento_N");
         }

      }

      public void gxTv_SdtContrato_Contratoclientedocumento_N_SetNull( )
      {
         gxTv_SdtContrato_Contratoclientedocumento_N = 0;
         SetDirty("Contratoclientedocumento_N");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoclientedocumento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoClienteRepresentanteNome_N" )]
      [  XmlElement( ElementName = "ContratoClienteRepresentanteNome_N"   )]
      public short gxTpr_Contratoclienterepresentantenome_N
      {
         get {
            return gxTv_SdtContrato_Contratoclienterepresentantenome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclienterepresentantenome_N = value;
            SetDirty("Contratoclienterepresentantenome_N");
         }

      }

      public void gxTv_SdtContrato_Contratoclienterepresentantenome_N_SetNull( )
      {
         gxTv_SdtContrato_Contratoclienterepresentantenome_N = 0;
         SetDirty("Contratoclienterepresentantenome_N");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoclienterepresentantenome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoClienteRepresentanteCPF_N" )]
      [  XmlElement( ElementName = "ContratoClienteRepresentanteCPF_N"   )]
      public short gxTpr_Contratoclienterepresentantecpf_N
      {
         get {
            return gxTv_SdtContrato_Contratoclienterepresentantecpf_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclienterepresentantecpf_N = value;
            SetDirty("Contratoclienterepresentantecpf_N");
         }

      }

      public void gxTv_SdtContrato_Contratoclienterepresentantecpf_N_SetNull( )
      {
         gxTv_SdtContrato_Contratoclienterepresentantecpf_N = 0;
         SetDirty("Contratoclienterepresentantecpf_N");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoclienterepresentantecpf_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoClienteTipoPessoa_N" )]
      [  XmlElement( ElementName = "ContratoClienteTipoPessoa_N"   )]
      public short gxTpr_Contratoclientetipopessoa_N
      {
         get {
            return gxTv_SdtContrato_Contratoclientetipopessoa_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclientetipopessoa_N = value;
            SetDirty("Contratoclientetipopessoa_N");
         }

      }

      public void gxTv_SdtContrato_Contratoclientetipopessoa_N_SetNull( )
      {
         gxTv_SdtContrato_Contratoclientetipopessoa_N = 0;
         SetDirty("Contratoclientetipopessoa_N");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoclientetipopessoa_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoTaxa_N" )]
      [  XmlElement( ElementName = "ContratoTaxa_N"   )]
      public short gxTpr_Contratotaxa_N
      {
         get {
            return gxTv_SdtContrato_Contratotaxa_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratotaxa_N = value;
            SetDirty("Contratotaxa_N");
         }

      }

      public void gxTv_SdtContrato_Contratotaxa_N_SetNull( )
      {
         gxTv_SdtContrato_Contratotaxa_N = 0;
         SetDirty("Contratotaxa_N");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratotaxa_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoSLA_N" )]
      [  XmlElement( ElementName = "ContratoSLA_N"   )]
      public short gxTpr_Contratosla_N
      {
         get {
            return gxTv_SdtContrato_Contratosla_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratosla_N = value;
            SetDirty("Contratosla_N");
         }

      }

      public void gxTv_SdtContrato_Contratosla_N_SetNull( )
      {
         gxTv_SdtContrato_Contratosla_N = 0;
         SetDirty("Contratosla_N");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratosla_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoJurosMora_N" )]
      [  XmlElement( ElementName = "ContratoJurosMora_N"   )]
      public short gxTpr_Contratojurosmora_N
      {
         get {
            return gxTv_SdtContrato_Contratojurosmora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratojurosmora_N = value;
            SetDirty("Contratojurosmora_N");
         }

      }

      public void gxTv_SdtContrato_Contratojurosmora_N_SetNull( )
      {
         gxTv_SdtContrato_Contratojurosmora_N = 0;
         SetDirty("Contratojurosmora_N");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratojurosmora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoIOFMinimo_N" )]
      [  XmlElement( ElementName = "ContratoIOFMinimo_N"   )]
      public short gxTpr_Contratoiofminimo_N
      {
         get {
            return gxTv_SdtContrato_Contratoiofminimo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoiofminimo_N = value;
            SetDirty("Contratoiofminimo_N");
         }

      }

      public void gxTv_SdtContrato_Contratoiofminimo_N_SetNull( )
      {
         gxTv_SdtContrato_Contratoiofminimo_N = 0;
         SetDirty("Contratoiofminimo_N");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoiofminimo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoSituacao_N" )]
      [  XmlElement( ElementName = "ContratoSituacao_N"   )]
      public short gxTpr_Contratosituacao_N
      {
         get {
            return gxTv_SdtContrato_Contratosituacao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratosituacao_N = value;
            SetDirty("Contratosituacao_N");
         }

      }

      public void gxTv_SdtContrato_Contratosituacao_N_SetNull( )
      {
         gxTv_SdtContrato_Contratosituacao_N = 0;
         SetDirty("Contratosituacao_N");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratosituacao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoBlob_N" )]
      [  XmlElement( ElementName = "ContratoBlob_N"   )]
      public short gxTpr_Contratoblob_N
      {
         get {
            return gxTv_SdtContrato_Contratoblob_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoblob_N = value;
            SetDirty("Contratoblob_N");
         }

      }

      public void gxTv_SdtContrato_Contratoblob_N_SetNull( )
      {
         gxTv_SdtContrato_Contratoblob_N = 0;
         SetDirty("Contratoblob_N");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoblob_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaUltId_F_N" )]
      [  XmlElement( ElementName = "AssinaturaUltId_F_N"   )]
      public short gxTpr_Assinaturaultid_f_N
      {
         get {
            return gxTv_SdtContrato_Assinaturaultid_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Assinaturaultid_f_N = value;
            SetDirty("Assinaturaultid_f_N");
         }

      }

      public void gxTv_SdtContrato_Assinaturaultid_f_N_SetNull( )
      {
         gxTv_SdtContrato_Assinaturaultid_f_N = 0;
         SetDirty("Assinaturaultid_f_N");
         return  ;
      }

      public bool gxTv_SdtContrato_Assinaturaultid_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoClienteEnderecoCEP_N" )]
      [  XmlElement( ElementName = "ContratoClienteEnderecoCEP_N"   )]
      public short gxTpr_Contratoclienteenderecocep_N
      {
         get {
            return gxTv_SdtContrato_Contratoclienteenderecocep_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclienteenderecocep_N = value;
            SetDirty("Contratoclienteenderecocep_N");
         }

      }

      public void gxTv_SdtContrato_Contratoclienteenderecocep_N_SetNull( )
      {
         gxTv_SdtContrato_Contratoclienteenderecocep_N = 0;
         SetDirty("Contratoclienteenderecocep_N");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoclienteenderecocep_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoClienteEnderecoLograodouro_N" )]
      [  XmlElement( ElementName = "ContratoClienteEnderecoLograodouro_N"   )]
      public short gxTpr_Contratoclienteenderecolograodouro_N
      {
         get {
            return gxTv_SdtContrato_Contratoclienteenderecolograodouro_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclienteenderecolograodouro_N = value;
            SetDirty("Contratoclienteenderecolograodouro_N");
         }

      }

      public void gxTv_SdtContrato_Contratoclienteenderecolograodouro_N_SetNull( )
      {
         gxTv_SdtContrato_Contratoclienteenderecolograodouro_N = 0;
         SetDirty("Contratoclienteenderecolograodouro_N");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoclienteenderecolograodouro_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoClienteEnderecoNumero_N" )]
      [  XmlElement( ElementName = "ContratoClienteEnderecoNumero_N"   )]
      public short gxTpr_Contratoclienteendereconumero_N
      {
         get {
            return gxTv_SdtContrato_Contratoclienteendereconumero_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclienteendereconumero_N = value;
            SetDirty("Contratoclienteendereconumero_N");
         }

      }

      public void gxTv_SdtContrato_Contratoclienteendereconumero_N_SetNull( )
      {
         gxTv_SdtContrato_Contratoclienteendereconumero_N = 0;
         SetDirty("Contratoclienteendereconumero_N");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoclienteendereconumero_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoClienteEnderecoComplemento_N" )]
      [  XmlElement( ElementName = "ContratoClienteEnderecoComplemento_N"   )]
      public short gxTpr_Contratoclienteenderecocomplemento_N
      {
         get {
            return gxTv_SdtContrato_Contratoclienteenderecocomplemento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclienteenderecocomplemento_N = value;
            SetDirty("Contratoclienteenderecocomplemento_N");
         }

      }

      public void gxTv_SdtContrato_Contratoclienteenderecocomplemento_N_SetNull( )
      {
         gxTv_SdtContrato_Contratoclienteenderecocomplemento_N = 0;
         SetDirty("Contratoclienteenderecocomplemento_N");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoclienteenderecocomplemento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoClienteEnderecoBairro_N" )]
      [  XmlElement( ElementName = "ContratoClienteEnderecoBairro_N"   )]
      public short gxTpr_Contratoclienteenderecobairro_N
      {
         get {
            return gxTv_SdtContrato_Contratoclienteenderecobairro_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclienteenderecobairro_N = value;
            SetDirty("Contratoclienteenderecobairro_N");
         }

      }

      public void gxTv_SdtContrato_Contratoclienteenderecobairro_N_SetNull( )
      {
         gxTv_SdtContrato_Contratoclienteenderecobairro_N = 0;
         SetDirty("Contratoclienteenderecobairro_N");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoclienteenderecobairro_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoClienteMunicipioCodigo_N" )]
      [  XmlElement( ElementName = "ContratoClienteMunicipioCodigo_N"   )]
      public short gxTpr_Contratoclientemunicipiocodigo_N
      {
         get {
            return gxTv_SdtContrato_Contratoclientemunicipiocodigo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratoclientemunicipiocodigo_N = value;
            SetDirty("Contratoclientemunicipiocodigo_N");
         }

      }

      public void gxTv_SdtContrato_Contratoclientemunicipiocodigo_N_SetNull( )
      {
         gxTv_SdtContrato_Contratoclientemunicipiocodigo_N = 0;
         SetDirty("Contratoclientemunicipiocodigo_N");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratoclientemunicipiocodigo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoPropostaId_N" )]
      [  XmlElement( ElementName = "ContratoPropostaId_N"   )]
      public short gxTpr_Contratopropostaid_N
      {
         get {
            return gxTv_SdtContrato_Contratopropostaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratopropostaid_N = value;
            SetDirty("Contratopropostaid_N");
         }

      }

      public void gxTv_SdtContrato_Contratopropostaid_N_SetNull( )
      {
         gxTv_SdtContrato_Contratopropostaid_N = 0;
         SetDirty("Contratopropostaid_N");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratopropostaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoCountAssinantes_F_N" )]
      [  XmlElement( ElementName = "ContratoCountAssinantes_F_N"   )]
      public short gxTpr_Contratocountassinantes_f_N
      {
         get {
            return gxTv_SdtContrato_Contratocountassinantes_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContrato_Contratocountassinantes_f_N = value;
            SetDirty("Contratocountassinantes_f_N");
         }

      }

      public void gxTv_SdtContrato_Contratocountassinantes_f_N_SetNull( )
      {
         gxTv_SdtContrato_Contratocountassinantes_f_N = 0;
         SetDirty("Contratocountassinantes_f_N");
         return  ;
      }

      public bool gxTv_SdtContrato_Contratocountassinantes_f_N_IsNull( )
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
         gxTv_SdtContrato_Contratonome = "";
         gxTv_SdtContrato_Contratocorpo = "";
         gxTv_SdtContrato_Contratodatainicial = DateTime.MinValue;
         gxTv_SdtContrato_Contratodatafinal = DateTime.MinValue;
         gxTv_SdtContrato_Contratoclientenome = "";
         gxTv_SdtContrato_Contratoclientedocumento = "";
         gxTv_SdtContrato_Contratoclienterepresentantenome = "";
         gxTv_SdtContrato_Contratoclienterepresentantecpf = "";
         gxTv_SdtContrato_Contratoclientetipopessoa = "";
         gxTv_SdtContrato_Contratosituacao = "";
         gxTv_SdtContrato_Contratoblob = "";
         gxTv_SdtContrato_Contratoclienteenderecocep = "";
         gxTv_SdtContrato_Contratoclienteenderecolograodouro = "";
         gxTv_SdtContrato_Contratoclienteendereconumero = "";
         gxTv_SdtContrato_Contratoclienteenderecocomplemento = "";
         gxTv_SdtContrato_Contratoclienteenderecobairro = "";
         gxTv_SdtContrato_Contratoclientemunicipiocodigo = "";
         gxTv_SdtContrato_Mode = "";
         gxTv_SdtContrato_Contratonome_Z = "";
         gxTv_SdtContrato_Contratodatainicial_Z = DateTime.MinValue;
         gxTv_SdtContrato_Contratodatafinal_Z = DateTime.MinValue;
         gxTv_SdtContrato_Contratoclientenome_Z = "";
         gxTv_SdtContrato_Contratoclientedocumento_Z = "";
         gxTv_SdtContrato_Contratoclienterepresentantenome_Z = "";
         gxTv_SdtContrato_Contratoclienterepresentantecpf_Z = "";
         gxTv_SdtContrato_Contratoclientetipopessoa_Z = "";
         gxTv_SdtContrato_Contratosituacao_Z = "";
         gxTv_SdtContrato_Contratoclienteenderecocep_Z = "";
         gxTv_SdtContrato_Contratoclienteenderecolograodouro_Z = "";
         gxTv_SdtContrato_Contratoclienteendereconumero_Z = "";
         gxTv_SdtContrato_Contratoclienteenderecocomplemento_Z = "";
         gxTv_SdtContrato_Contratoclienteenderecobairro_Z = "";
         gxTv_SdtContrato_Contratoclientemunicipiocodigo_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "contrato", "GeneXus.Programs.contrato_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtContrato_Contratosla ;
      private short gxTv_SdtContrato_Assinaturaultid_f ;
      private short gxTv_SdtContrato_Contratocountassinantes_f ;
      private short gxTv_SdtContrato_Initialized ;
      private short gxTv_SdtContrato_Contratosla_Z ;
      private short gxTv_SdtContrato_Assinaturaultid_f_Z ;
      private short gxTv_SdtContrato_Contratocountassinantes_f_Z ;
      private short gxTv_SdtContrato_Contratoid_N ;
      private short gxTv_SdtContrato_Contratonome_N ;
      private short gxTv_SdtContrato_Contratocorpo_N ;
      private short gxTv_SdtContrato_Contratocomvigencia_N ;
      private short gxTv_SdtContrato_Contratodatainicial_N ;
      private short gxTv_SdtContrato_Contratodatafinal_N ;
      private short gxTv_SdtContrato_Contratoclienteid_N ;
      private short gxTv_SdtContrato_Contratoclientenome_N ;
      private short gxTv_SdtContrato_Contratoclientedocumento_N ;
      private short gxTv_SdtContrato_Contratoclienterepresentantenome_N ;
      private short gxTv_SdtContrato_Contratoclienterepresentantecpf_N ;
      private short gxTv_SdtContrato_Contratoclientetipopessoa_N ;
      private short gxTv_SdtContrato_Contratotaxa_N ;
      private short gxTv_SdtContrato_Contratosla_N ;
      private short gxTv_SdtContrato_Contratojurosmora_N ;
      private short gxTv_SdtContrato_Contratoiofminimo_N ;
      private short gxTv_SdtContrato_Contratosituacao_N ;
      private short gxTv_SdtContrato_Contratoblob_N ;
      private short gxTv_SdtContrato_Assinaturaultid_f_N ;
      private short gxTv_SdtContrato_Contratoclienteenderecocep_N ;
      private short gxTv_SdtContrato_Contratoclienteenderecolograodouro_N ;
      private short gxTv_SdtContrato_Contratoclienteendereconumero_N ;
      private short gxTv_SdtContrato_Contratoclienteenderecocomplemento_N ;
      private short gxTv_SdtContrato_Contratoclienteenderecobairro_N ;
      private short gxTv_SdtContrato_Contratoclientemunicipiocodigo_N ;
      private short gxTv_SdtContrato_Contratopropostaid_N ;
      private short gxTv_SdtContrato_Contratocountassinantes_f_N ;
      private int gxTv_SdtContrato_Contratoid ;
      private int gxTv_SdtContrato_Contratoclienteid ;
      private int gxTv_SdtContrato_Contratopropostaid ;
      private int gxTv_SdtContrato_Contratoid_Z ;
      private int gxTv_SdtContrato_Contratoclienteid_Z ;
      private int gxTv_SdtContrato_Contratopropostaid_Z ;
      private decimal gxTv_SdtContrato_Contratotaxa ;
      private decimal gxTv_SdtContrato_Contratojurosmora ;
      private decimal gxTv_SdtContrato_Contratoiofminimo ;
      private decimal gxTv_SdtContrato_Contratotaxa_Z ;
      private decimal gxTv_SdtContrato_Contratojurosmora_Z ;
      private decimal gxTv_SdtContrato_Contratoiofminimo_Z ;
      private string gxTv_SdtContrato_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtContrato_Contratodatainicial ;
      private DateTime gxTv_SdtContrato_Contratodatafinal ;
      private DateTime gxTv_SdtContrato_Contratodatainicial_Z ;
      private DateTime gxTv_SdtContrato_Contratodatafinal_Z ;
      private bool gxTv_SdtContrato_Contratocomvigencia ;
      private bool gxTv_SdtContrato_Contratocomvigencia_Z ;
      private string gxTv_SdtContrato_Contratocorpo ;
      private string gxTv_SdtContrato_Contratonome ;
      private string gxTv_SdtContrato_Contratoclientenome ;
      private string gxTv_SdtContrato_Contratoclientedocumento ;
      private string gxTv_SdtContrato_Contratoclienterepresentantenome ;
      private string gxTv_SdtContrato_Contratoclienterepresentantecpf ;
      private string gxTv_SdtContrato_Contratoclientetipopessoa ;
      private string gxTv_SdtContrato_Contratosituacao ;
      private string gxTv_SdtContrato_Contratoclienteenderecocep ;
      private string gxTv_SdtContrato_Contratoclienteenderecolograodouro ;
      private string gxTv_SdtContrato_Contratoclienteendereconumero ;
      private string gxTv_SdtContrato_Contratoclienteenderecocomplemento ;
      private string gxTv_SdtContrato_Contratoclienteenderecobairro ;
      private string gxTv_SdtContrato_Contratoclientemunicipiocodigo ;
      private string gxTv_SdtContrato_Contratonome_Z ;
      private string gxTv_SdtContrato_Contratoclientenome_Z ;
      private string gxTv_SdtContrato_Contratoclientedocumento_Z ;
      private string gxTv_SdtContrato_Contratoclienterepresentantenome_Z ;
      private string gxTv_SdtContrato_Contratoclienterepresentantecpf_Z ;
      private string gxTv_SdtContrato_Contratoclientetipopessoa_Z ;
      private string gxTv_SdtContrato_Contratosituacao_Z ;
      private string gxTv_SdtContrato_Contratoclienteenderecocep_Z ;
      private string gxTv_SdtContrato_Contratoclienteenderecolograodouro_Z ;
      private string gxTv_SdtContrato_Contratoclienteendereconumero_Z ;
      private string gxTv_SdtContrato_Contratoclienteenderecocomplemento_Z ;
      private string gxTv_SdtContrato_Contratoclienteenderecobairro_Z ;
      private string gxTv_SdtContrato_Contratoclientemunicipiocodigo_Z ;
      private string gxTv_SdtContrato_Contratoblob ;
   }

   [DataContract(Name = @"Contrato", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtContrato_RESTInterface : GxGenericCollectionItem<SdtContrato>
   {
      public SdtContrato_RESTInterface( ) : base()
      {
      }

      public SdtContrato_RESTInterface( SdtContrato psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ContratoId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Contratoid
      {
         get {
            return sdt.gxTpr_Contratoid ;
         }

         set {
            sdt.gxTpr_Contratoid = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ContratoNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Contratonome
      {
         get {
            return sdt.gxTpr_Contratonome ;
         }

         set {
            sdt.gxTpr_Contratonome = value;
         }

      }

      [DataMember( Name = "ContratoCorpo" , Order = 2 )]
      public string gxTpr_Contratocorpo
      {
         get {
            return sdt.gxTpr_Contratocorpo ;
         }

         set {
            sdt.gxTpr_Contratocorpo = value;
         }

      }

      [DataMember( Name = "ContratoComVigencia" , Order = 3 )]
      [GxSeudo()]
      public bool gxTpr_Contratocomvigencia
      {
         get {
            return sdt.gxTpr_Contratocomvigencia ;
         }

         set {
            sdt.gxTpr_Contratocomvigencia = value;
         }

      }

      [DataMember( Name = "ContratoDataInicial" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Contratodatainicial
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Contratodatainicial) ;
         }

         set {
            sdt.gxTpr_Contratodatainicial = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "ContratoDataFinal" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Contratodatafinal
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Contratodatafinal) ;
         }

         set {
            sdt.gxTpr_Contratodatafinal = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "ContratoClienteId" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Contratoclienteid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Contratoclienteid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Contratoclienteid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ContratoClienteNome" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Contratoclientenome
      {
         get {
            return sdt.gxTpr_Contratoclientenome ;
         }

         set {
            sdt.gxTpr_Contratoclientenome = value;
         }

      }

      [DataMember( Name = "ContratoClienteDocumento" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Contratoclientedocumento
      {
         get {
            return sdt.gxTpr_Contratoclientedocumento ;
         }

         set {
            sdt.gxTpr_Contratoclientedocumento = value;
         }

      }

      [DataMember( Name = "ContratoClienteRepresentanteNome" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Contratoclienterepresentantenome
      {
         get {
            return sdt.gxTpr_Contratoclienterepresentantenome ;
         }

         set {
            sdt.gxTpr_Contratoclienterepresentantenome = value;
         }

      }

      [DataMember( Name = "ContratoClienteRepresentanteCPF" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Contratoclienterepresentantecpf
      {
         get {
            return sdt.gxTpr_Contratoclienterepresentantecpf ;
         }

         set {
            sdt.gxTpr_Contratoclienterepresentantecpf = value;
         }

      }

      [DataMember( Name = "ContratoClienteTipoPessoa" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Contratoclientetipopessoa
      {
         get {
            return sdt.gxTpr_Contratoclientetipopessoa ;
         }

         set {
            sdt.gxTpr_Contratoclientetipopessoa = value;
         }

      }

      [DataMember( Name = "ContratoTaxa" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Contratotaxa
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Contratotaxa, 16, 4)) ;
         }

         set {
            sdt.gxTpr_Contratotaxa = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ContratoSLA" , Order = 13 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Contratosla
      {
         get {
            return sdt.gxTpr_Contratosla ;
         }

         set {
            sdt.gxTpr_Contratosla = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ContratoJurosMora" , Order = 14 )]
      [GxSeudo()]
      public string gxTpr_Contratojurosmora
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Contratojurosmora, 16, 4)) ;
         }

         set {
            sdt.gxTpr_Contratojurosmora = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ContratoIOFMinimo" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Contratoiofminimo
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Contratoiofminimo, 16, 4)) ;
         }

         set {
            sdt.gxTpr_Contratoiofminimo = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ContratoSituacao" , Order = 16 )]
      [GxSeudo()]
      public string gxTpr_Contratosituacao
      {
         get {
            return sdt.gxTpr_Contratosituacao ;
         }

         set {
            sdt.gxTpr_Contratosituacao = value;
         }

      }

      [DataMember( Name = "ContratoBlob" , Order = 17 )]
      [GxUpload()]
      public string gxTpr_Contratoblob
      {
         get {
            return PathUtil.RelativeURL( sdt.gxTpr_Contratoblob) ;
         }

         set {
            sdt.gxTpr_Contratoblob = value;
         }

      }

      [DataMember( Name = "AssinaturaUltId_F" , Order = 18 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Assinaturaultid_f
      {
         get {
            return sdt.gxTpr_Assinaturaultid_f ;
         }

         set {
            sdt.gxTpr_Assinaturaultid_f = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ContratoClienteEnderecoCEP" , Order = 19 )]
      [GxSeudo()]
      public string gxTpr_Contratoclienteenderecocep
      {
         get {
            return sdt.gxTpr_Contratoclienteenderecocep ;
         }

         set {
            sdt.gxTpr_Contratoclienteenderecocep = value;
         }

      }

      [DataMember( Name = "ContratoClienteEnderecoLograodouro" , Order = 20 )]
      [GxSeudo()]
      public string gxTpr_Contratoclienteenderecolograodouro
      {
         get {
            return sdt.gxTpr_Contratoclienteenderecolograodouro ;
         }

         set {
            sdt.gxTpr_Contratoclienteenderecolograodouro = value;
         }

      }

      [DataMember( Name = "ContratoClienteEnderecoNumero" , Order = 21 )]
      [GxSeudo()]
      public string gxTpr_Contratoclienteendereconumero
      {
         get {
            return sdt.gxTpr_Contratoclienteendereconumero ;
         }

         set {
            sdt.gxTpr_Contratoclienteendereconumero = value;
         }

      }

      [DataMember( Name = "ContratoClienteEnderecoComplemento" , Order = 22 )]
      [GxSeudo()]
      public string gxTpr_Contratoclienteenderecocomplemento
      {
         get {
            return sdt.gxTpr_Contratoclienteenderecocomplemento ;
         }

         set {
            sdt.gxTpr_Contratoclienteenderecocomplemento = value;
         }

      }

      [DataMember( Name = "ContratoClienteEnderecoBairro" , Order = 23 )]
      [GxSeudo()]
      public string gxTpr_Contratoclienteenderecobairro
      {
         get {
            return sdt.gxTpr_Contratoclienteenderecobairro ;
         }

         set {
            sdt.gxTpr_Contratoclienteenderecobairro = value;
         }

      }

      [DataMember( Name = "ContratoClienteMunicipioCodigo" , Order = 24 )]
      [GxSeudo()]
      public string gxTpr_Contratoclientemunicipiocodigo
      {
         get {
            return sdt.gxTpr_Contratoclientemunicipiocodigo ;
         }

         set {
            sdt.gxTpr_Contratoclientemunicipiocodigo = value;
         }

      }

      [DataMember( Name = "ContratoPropostaId" , Order = 25 )]
      [GxSeudo()]
      public string gxTpr_Contratopropostaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Contratopropostaid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Contratopropostaid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ContratoCountAssinantes_F" , Order = 26 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Contratocountassinantes_f
      {
         get {
            return sdt.gxTpr_Contratocountassinantes_f ;
         }

         set {
            sdt.gxTpr_Contratocountassinantes_f = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtContrato sdt
      {
         get {
            return (SdtContrato)Sdt ;
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
            sdt = new SdtContrato() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 27 )]
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

   [DataContract(Name = @"Contrato", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtContrato_RESTLInterface : GxGenericCollectionItem<SdtContrato>
   {
      public SdtContrato_RESTLInterface( ) : base()
      {
      }

      public SdtContrato_RESTLInterface( SdtContrato psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ContratoNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Contratonome
      {
         get {
            return sdt.gxTpr_Contratonome ;
         }

         set {
            sdt.gxTpr_Contratonome = value;
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

      public SdtContrato sdt
      {
         get {
            return (SdtContrato)Sdt ;
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
            sdt = new SdtContrato() ;
         }
      }

   }

}
