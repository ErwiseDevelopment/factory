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
   [XmlRoot(ElementName = "Assinatura" )]
   [XmlType(TypeName =  "Assinatura" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtAssinatura : GxSilentTrnSdt
   {
      public SdtAssinatura( )
      {
      }

      public SdtAssinatura( IGxContext context )
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

      public void Load( long AV238AssinaturaId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(long)AV238AssinaturaId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"AssinaturaId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Assinatura");
         metadata.Set("BT", "Assinatura");
         metadata.Set("PK", "[ \"AssinaturaId\" ]");
         metadata.Set("PKAssigned", "[ \"AssinaturaId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ArquivoId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ArquivoId\" ],\"FKMap\":[ \"ArquivoAssinadoId-ArquivoId\" ] },{ \"FK\":[ \"ContratoId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Assinaturaid_Z");
         state.Add("gxTpr_Assinaturastatus_Z");
         state.Add("gxTpr_Contratoid_Z");
         state.Add("gxTpr_Contratonome_Z");
         state.Add("gxTpr_Contratodatainicial_Z_Nullable");
         state.Add("gxTpr_Contratodatafinal_Z_Nullable");
         state.Add("gxTpr_Arquivoid_Z");
         state.Add("gxTpr_Arquivoassinadoid_Z");
         state.Add("gxTpr_Assinaturaarquivoassinadonome_Z");
         state.Add("gxTpr_Assinaturaarquivoassinadoextensao_Z");
         state.Add("gxTpr_Assinaturapublickey_Z");
         state.Add("gxTpr_Assinaturapaginaconsulta_Z");
         state.Add("gxTpr_Assinaturatoken_Z");
         state.Add("gxTpr_Assinaturames_Z");
         state.Add("gxTpr_Assinaturamesnome_Z");
         state.Add("gxTpr_Assinaturaano_Z");
         state.Add("gxTpr_Assinaturafinalizadodata_Z_Nullable");
         state.Add("gxTpr_Assinaturaparticipantes_f_Z");
         state.Add("gxTpr_Assinaturaid_N");
         state.Add("gxTpr_Assinaturastatus_N");
         state.Add("gxTpr_Contratoid_N");
         state.Add("gxTpr_Contratonome_N");
         state.Add("gxTpr_Contratodatainicial_N");
         state.Add("gxTpr_Contratodatafinal_N");
         state.Add("gxTpr_Arquivoid_N");
         state.Add("gxTpr_Arquivoassinadoid_N");
         state.Add("gxTpr_Assinaturaarquivoassinado_N");
         state.Add("gxTpr_Assinaturaarquivoassinadonome_N");
         state.Add("gxTpr_Assinaturaarquivoassinadoextensao_N");
         state.Add("gxTpr_Assinaturapublickey_N");
         state.Add("gxTpr_Assinaturapaginaconsulta_N");
         state.Add("gxTpr_Assinaturatoken_N");
         state.Add("gxTpr_Assinaturames_N");
         state.Add("gxTpr_Assinaturamesnome_N");
         state.Add("gxTpr_Assinaturaano_N");
         state.Add("gxTpr_Assinaturafinalizadodata_N");
         state.Add("gxTpr_Assinaturaparticipantes_f_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtAssinatura sdt;
         sdt = (SdtAssinatura)(source);
         gxTv_SdtAssinatura_Assinaturaid = sdt.gxTv_SdtAssinatura_Assinaturaid ;
         gxTv_SdtAssinatura_Assinaturastatus = sdt.gxTv_SdtAssinatura_Assinaturastatus ;
         gxTv_SdtAssinatura_Contratoid = sdt.gxTv_SdtAssinatura_Contratoid ;
         gxTv_SdtAssinatura_Contratonome = sdt.gxTv_SdtAssinatura_Contratonome ;
         gxTv_SdtAssinatura_Contratodatainicial = sdt.gxTv_SdtAssinatura_Contratodatainicial ;
         gxTv_SdtAssinatura_Contratodatafinal = sdt.gxTv_SdtAssinatura_Contratodatafinal ;
         gxTv_SdtAssinatura_Arquivoid = sdt.gxTv_SdtAssinatura_Arquivoid ;
         gxTv_SdtAssinatura_Arquivoassinadoid = sdt.gxTv_SdtAssinatura_Arquivoassinadoid ;
         gxTv_SdtAssinatura_Assinaturaarquivoassinado = sdt.gxTv_SdtAssinatura_Assinaturaarquivoassinado ;
         gxTv_SdtAssinatura_Assinaturaarquivoassinadonome = sdt.gxTv_SdtAssinatura_Assinaturaarquivoassinadonome ;
         gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao = sdt.gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao ;
         gxTv_SdtAssinatura_Assinaturapublickey = sdt.gxTv_SdtAssinatura_Assinaturapublickey ;
         gxTv_SdtAssinatura_Assinaturapaginaconsulta = sdt.gxTv_SdtAssinatura_Assinaturapaginaconsulta ;
         gxTv_SdtAssinatura_Assinaturatoken = sdt.gxTv_SdtAssinatura_Assinaturatoken ;
         gxTv_SdtAssinatura_Assinaturames = sdt.gxTv_SdtAssinatura_Assinaturames ;
         gxTv_SdtAssinatura_Assinaturamesnome = sdt.gxTv_SdtAssinatura_Assinaturamesnome ;
         gxTv_SdtAssinatura_Assinaturaano = sdt.gxTv_SdtAssinatura_Assinaturaano ;
         gxTv_SdtAssinatura_Assinaturafinalizadodata = sdt.gxTv_SdtAssinatura_Assinaturafinalizadodata ;
         gxTv_SdtAssinatura_Assinaturaparticipantes_f = sdt.gxTv_SdtAssinatura_Assinaturaparticipantes_f ;
         gxTv_SdtAssinatura_Mode = sdt.gxTv_SdtAssinatura_Mode ;
         gxTv_SdtAssinatura_Initialized = sdt.gxTv_SdtAssinatura_Initialized ;
         gxTv_SdtAssinatura_Assinaturaid_Z = sdt.gxTv_SdtAssinatura_Assinaturaid_Z ;
         gxTv_SdtAssinatura_Assinaturastatus_Z = sdt.gxTv_SdtAssinatura_Assinaturastatus_Z ;
         gxTv_SdtAssinatura_Contratoid_Z = sdt.gxTv_SdtAssinatura_Contratoid_Z ;
         gxTv_SdtAssinatura_Contratonome_Z = sdt.gxTv_SdtAssinatura_Contratonome_Z ;
         gxTv_SdtAssinatura_Contratodatainicial_Z = sdt.gxTv_SdtAssinatura_Contratodatainicial_Z ;
         gxTv_SdtAssinatura_Contratodatafinal_Z = sdt.gxTv_SdtAssinatura_Contratodatafinal_Z ;
         gxTv_SdtAssinatura_Arquivoid_Z = sdt.gxTv_SdtAssinatura_Arquivoid_Z ;
         gxTv_SdtAssinatura_Arquivoassinadoid_Z = sdt.gxTv_SdtAssinatura_Arquivoassinadoid_Z ;
         gxTv_SdtAssinatura_Assinaturaarquivoassinadonome_Z = sdt.gxTv_SdtAssinatura_Assinaturaarquivoassinadonome_Z ;
         gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao_Z = sdt.gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao_Z ;
         gxTv_SdtAssinatura_Assinaturapublickey_Z = sdt.gxTv_SdtAssinatura_Assinaturapublickey_Z ;
         gxTv_SdtAssinatura_Assinaturapaginaconsulta_Z = sdt.gxTv_SdtAssinatura_Assinaturapaginaconsulta_Z ;
         gxTv_SdtAssinatura_Assinaturatoken_Z = sdt.gxTv_SdtAssinatura_Assinaturatoken_Z ;
         gxTv_SdtAssinatura_Assinaturames_Z = sdt.gxTv_SdtAssinatura_Assinaturames_Z ;
         gxTv_SdtAssinatura_Assinaturamesnome_Z = sdt.gxTv_SdtAssinatura_Assinaturamesnome_Z ;
         gxTv_SdtAssinatura_Assinaturaano_Z = sdt.gxTv_SdtAssinatura_Assinaturaano_Z ;
         gxTv_SdtAssinatura_Assinaturafinalizadodata_Z = sdt.gxTv_SdtAssinatura_Assinaturafinalizadodata_Z ;
         gxTv_SdtAssinatura_Assinaturaparticipantes_f_Z = sdt.gxTv_SdtAssinatura_Assinaturaparticipantes_f_Z ;
         gxTv_SdtAssinatura_Assinaturaid_N = sdt.gxTv_SdtAssinatura_Assinaturaid_N ;
         gxTv_SdtAssinatura_Assinaturastatus_N = sdt.gxTv_SdtAssinatura_Assinaturastatus_N ;
         gxTv_SdtAssinatura_Contratoid_N = sdt.gxTv_SdtAssinatura_Contratoid_N ;
         gxTv_SdtAssinatura_Contratonome_N = sdt.gxTv_SdtAssinatura_Contratonome_N ;
         gxTv_SdtAssinatura_Contratodatainicial_N = sdt.gxTv_SdtAssinatura_Contratodatainicial_N ;
         gxTv_SdtAssinatura_Contratodatafinal_N = sdt.gxTv_SdtAssinatura_Contratodatafinal_N ;
         gxTv_SdtAssinatura_Arquivoid_N = sdt.gxTv_SdtAssinatura_Arquivoid_N ;
         gxTv_SdtAssinatura_Arquivoassinadoid_N = sdt.gxTv_SdtAssinatura_Arquivoassinadoid_N ;
         gxTv_SdtAssinatura_Assinaturaarquivoassinado_N = sdt.gxTv_SdtAssinatura_Assinaturaarquivoassinado_N ;
         gxTv_SdtAssinatura_Assinaturaarquivoassinadonome_N = sdt.gxTv_SdtAssinatura_Assinaturaarquivoassinadonome_N ;
         gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao_N = sdt.gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao_N ;
         gxTv_SdtAssinatura_Assinaturapublickey_N = sdt.gxTv_SdtAssinatura_Assinaturapublickey_N ;
         gxTv_SdtAssinatura_Assinaturapaginaconsulta_N = sdt.gxTv_SdtAssinatura_Assinaturapaginaconsulta_N ;
         gxTv_SdtAssinatura_Assinaturatoken_N = sdt.gxTv_SdtAssinatura_Assinaturatoken_N ;
         gxTv_SdtAssinatura_Assinaturames_N = sdt.gxTv_SdtAssinatura_Assinaturames_N ;
         gxTv_SdtAssinatura_Assinaturamesnome_N = sdt.gxTv_SdtAssinatura_Assinaturamesnome_N ;
         gxTv_SdtAssinatura_Assinaturaano_N = sdt.gxTv_SdtAssinatura_Assinaturaano_N ;
         gxTv_SdtAssinatura_Assinaturafinalizadodata_N = sdt.gxTv_SdtAssinatura_Assinaturafinalizadodata_N ;
         gxTv_SdtAssinatura_Assinaturaparticipantes_f_N = sdt.gxTv_SdtAssinatura_Assinaturaparticipantes_f_N ;
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
         AddObjectProperty("AssinaturaId", gxTv_SdtAssinatura_Assinaturaid, false, includeNonInitialized);
         AddObjectProperty("AssinaturaId_N", gxTv_SdtAssinatura_Assinaturaid_N, false, includeNonInitialized);
         AddObjectProperty("AssinaturaStatus", gxTv_SdtAssinatura_Assinaturastatus, false, includeNonInitialized);
         AddObjectProperty("AssinaturaStatus_N", gxTv_SdtAssinatura_Assinaturastatus_N, false, includeNonInitialized);
         AddObjectProperty("ContratoId", gxTv_SdtAssinatura_Contratoid, false, includeNonInitialized);
         AddObjectProperty("ContratoId_N", gxTv_SdtAssinatura_Contratoid_N, false, includeNonInitialized);
         AddObjectProperty("ContratoNome", gxTv_SdtAssinatura_Contratonome, false, includeNonInitialized);
         AddObjectProperty("ContratoNome_N", gxTv_SdtAssinatura_Contratonome_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtAssinatura_Contratodatainicial)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtAssinatura_Contratodatainicial)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtAssinatura_Contratodatainicial)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("ContratoDataInicial", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ContratoDataInicial_N", gxTv_SdtAssinatura_Contratodatainicial_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtAssinatura_Contratodatafinal)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtAssinatura_Contratodatafinal)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtAssinatura_Contratodatafinal)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("ContratoDataFinal", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ContratoDataFinal_N", gxTv_SdtAssinatura_Contratodatafinal_N, false, includeNonInitialized);
         AddObjectProperty("ArquivoId", gxTv_SdtAssinatura_Arquivoid, false, includeNonInitialized);
         AddObjectProperty("ArquivoId_N", gxTv_SdtAssinatura_Arquivoid_N, false, includeNonInitialized);
         AddObjectProperty("ArquivoAssinadoId", gxTv_SdtAssinatura_Arquivoassinadoid, false, includeNonInitialized);
         AddObjectProperty("ArquivoAssinadoId_N", gxTv_SdtAssinatura_Arquivoassinadoid_N, false, includeNonInitialized);
         AddObjectProperty("AssinaturaArquivoAssinado", gxTv_SdtAssinatura_Assinaturaarquivoassinado, false, includeNonInitialized);
         AddObjectProperty("AssinaturaArquivoAssinado_N", gxTv_SdtAssinatura_Assinaturaarquivoassinado_N, false, includeNonInitialized);
         AddObjectProperty("AssinaturaArquivoAssinadoNome", gxTv_SdtAssinatura_Assinaturaarquivoassinadonome, false, includeNonInitialized);
         AddObjectProperty("AssinaturaArquivoAssinadoNome_N", gxTv_SdtAssinatura_Assinaturaarquivoassinadonome_N, false, includeNonInitialized);
         AddObjectProperty("AssinaturaArquivoAssinadoExtensao", gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao, false, includeNonInitialized);
         AddObjectProperty("AssinaturaArquivoAssinadoExtensao_N", gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao_N, false, includeNonInitialized);
         AddObjectProperty("AssinaturaPublicKey", gxTv_SdtAssinatura_Assinaturapublickey, false, includeNonInitialized);
         AddObjectProperty("AssinaturaPublicKey_N", gxTv_SdtAssinatura_Assinaturapublickey_N, false, includeNonInitialized);
         AddObjectProperty("AssinaturaPaginaConsulta", gxTv_SdtAssinatura_Assinaturapaginaconsulta, false, includeNonInitialized);
         AddObjectProperty("AssinaturaPaginaConsulta_N", gxTv_SdtAssinatura_Assinaturapaginaconsulta_N, false, includeNonInitialized);
         AddObjectProperty("AssinaturaToken", gxTv_SdtAssinatura_Assinaturatoken, false, includeNonInitialized);
         AddObjectProperty("AssinaturaToken_N", gxTv_SdtAssinatura_Assinaturatoken_N, false, includeNonInitialized);
         AddObjectProperty("AssinaturaMes", gxTv_SdtAssinatura_Assinaturames, false, includeNonInitialized);
         AddObjectProperty("AssinaturaMes_N", gxTv_SdtAssinatura_Assinaturames_N, false, includeNonInitialized);
         AddObjectProperty("AssinaturaMesNome", gxTv_SdtAssinatura_Assinaturamesnome, false, includeNonInitialized);
         AddObjectProperty("AssinaturaMesNome_N", gxTv_SdtAssinatura_Assinaturamesnome_N, false, includeNonInitialized);
         AddObjectProperty("AssinaturaAno", gxTv_SdtAssinatura_Assinaturaano, false, includeNonInitialized);
         AddObjectProperty("AssinaturaAno_N", gxTv_SdtAssinatura_Assinaturaano_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtAssinatura_Assinaturafinalizadodata;
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
         AddObjectProperty("AssinaturaFinalizadoData", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("AssinaturaFinalizadoData_N", gxTv_SdtAssinatura_Assinaturafinalizadodata_N, false, includeNonInitialized);
         AddObjectProperty("AssinaturaParticipantes_F", gxTv_SdtAssinatura_Assinaturaparticipantes_f, false, includeNonInitialized);
         AddObjectProperty("AssinaturaParticipantes_F_N", gxTv_SdtAssinatura_Assinaturaparticipantes_f_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtAssinatura_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtAssinatura_Initialized, false, includeNonInitialized);
            AddObjectProperty("AssinaturaId_Z", gxTv_SdtAssinatura_Assinaturaid_Z, false, includeNonInitialized);
            AddObjectProperty("AssinaturaStatus_Z", gxTv_SdtAssinatura_Assinaturastatus_Z, false, includeNonInitialized);
            AddObjectProperty("ContratoId_Z", gxTv_SdtAssinatura_Contratoid_Z, false, includeNonInitialized);
            AddObjectProperty("ContratoNome_Z", gxTv_SdtAssinatura_Contratonome_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtAssinatura_Contratodatainicial_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtAssinatura_Contratodatainicial_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtAssinatura_Contratodatainicial_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("ContratoDataInicial_Z", sDateCnv, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtAssinatura_Contratodatafinal_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtAssinatura_Contratodatafinal_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtAssinatura_Contratodatafinal_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("ContratoDataFinal_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("ArquivoId_Z", gxTv_SdtAssinatura_Arquivoid_Z, false, includeNonInitialized);
            AddObjectProperty("ArquivoAssinadoId_Z", gxTv_SdtAssinatura_Arquivoassinadoid_Z, false, includeNonInitialized);
            AddObjectProperty("AssinaturaArquivoAssinadoNome_Z", gxTv_SdtAssinatura_Assinaturaarquivoassinadonome_Z, false, includeNonInitialized);
            AddObjectProperty("AssinaturaArquivoAssinadoExtensao_Z", gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao_Z, false, includeNonInitialized);
            AddObjectProperty("AssinaturaPublicKey_Z", gxTv_SdtAssinatura_Assinaturapublickey_Z, false, includeNonInitialized);
            AddObjectProperty("AssinaturaPaginaConsulta_Z", gxTv_SdtAssinatura_Assinaturapaginaconsulta_Z, false, includeNonInitialized);
            AddObjectProperty("AssinaturaToken_Z", gxTv_SdtAssinatura_Assinaturatoken_Z, false, includeNonInitialized);
            AddObjectProperty("AssinaturaMes_Z", gxTv_SdtAssinatura_Assinaturames_Z, false, includeNonInitialized);
            AddObjectProperty("AssinaturaMesNome_Z", gxTv_SdtAssinatura_Assinaturamesnome_Z, false, includeNonInitialized);
            AddObjectProperty("AssinaturaAno_Z", gxTv_SdtAssinatura_Assinaturaano_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtAssinatura_Assinaturafinalizadodata_Z;
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
            AddObjectProperty("AssinaturaFinalizadoData_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipantes_F_Z", gxTv_SdtAssinatura_Assinaturaparticipantes_f_Z, false, includeNonInitialized);
            AddObjectProperty("AssinaturaId_N", gxTv_SdtAssinatura_Assinaturaid_N, false, includeNonInitialized);
            AddObjectProperty("AssinaturaStatus_N", gxTv_SdtAssinatura_Assinaturastatus_N, false, includeNonInitialized);
            AddObjectProperty("ContratoId_N", gxTv_SdtAssinatura_Contratoid_N, false, includeNonInitialized);
            AddObjectProperty("ContratoNome_N", gxTv_SdtAssinatura_Contratonome_N, false, includeNonInitialized);
            AddObjectProperty("ContratoDataInicial_N", gxTv_SdtAssinatura_Contratodatainicial_N, false, includeNonInitialized);
            AddObjectProperty("ContratoDataFinal_N", gxTv_SdtAssinatura_Contratodatafinal_N, false, includeNonInitialized);
            AddObjectProperty("ArquivoId_N", gxTv_SdtAssinatura_Arquivoid_N, false, includeNonInitialized);
            AddObjectProperty("ArquivoAssinadoId_N", gxTv_SdtAssinatura_Arquivoassinadoid_N, false, includeNonInitialized);
            AddObjectProperty("AssinaturaArquivoAssinado_N", gxTv_SdtAssinatura_Assinaturaarquivoassinado_N, false, includeNonInitialized);
            AddObjectProperty("AssinaturaArquivoAssinadoNome_N", gxTv_SdtAssinatura_Assinaturaarquivoassinadonome_N, false, includeNonInitialized);
            AddObjectProperty("AssinaturaArquivoAssinadoExtensao_N", gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao_N, false, includeNonInitialized);
            AddObjectProperty("AssinaturaPublicKey_N", gxTv_SdtAssinatura_Assinaturapublickey_N, false, includeNonInitialized);
            AddObjectProperty("AssinaturaPaginaConsulta_N", gxTv_SdtAssinatura_Assinaturapaginaconsulta_N, false, includeNonInitialized);
            AddObjectProperty("AssinaturaToken_N", gxTv_SdtAssinatura_Assinaturatoken_N, false, includeNonInitialized);
            AddObjectProperty("AssinaturaMes_N", gxTv_SdtAssinatura_Assinaturames_N, false, includeNonInitialized);
            AddObjectProperty("AssinaturaMesNome_N", gxTv_SdtAssinatura_Assinaturamesnome_N, false, includeNonInitialized);
            AddObjectProperty("AssinaturaAno_N", gxTv_SdtAssinatura_Assinaturaano_N, false, includeNonInitialized);
            AddObjectProperty("AssinaturaFinalizadoData_N", gxTv_SdtAssinatura_Assinaturafinalizadodata_N, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipantes_F_N", gxTv_SdtAssinatura_Assinaturaparticipantes_f_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtAssinatura sdt )
      {
         if ( sdt.IsDirty("AssinaturaId") )
         {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturaid = sdt.gxTv_SdtAssinatura_Assinaturaid ;
         }
         if ( sdt.IsDirty("AssinaturaStatus") )
         {
            gxTv_SdtAssinatura_Assinaturastatus_N = (short)(sdt.gxTv_SdtAssinatura_Assinaturastatus_N);
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturastatus = sdt.gxTv_SdtAssinatura_Assinaturastatus ;
         }
         if ( sdt.IsDirty("ContratoId") )
         {
            gxTv_SdtAssinatura_Contratoid_N = (short)(sdt.gxTv_SdtAssinatura_Contratoid_N);
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Contratoid = sdt.gxTv_SdtAssinatura_Contratoid ;
         }
         if ( sdt.IsDirty("ContratoNome") )
         {
            gxTv_SdtAssinatura_Contratonome_N = (short)(sdt.gxTv_SdtAssinatura_Contratonome_N);
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Contratonome = sdt.gxTv_SdtAssinatura_Contratonome ;
         }
         if ( sdt.IsDirty("ContratoDataInicial") )
         {
            gxTv_SdtAssinatura_Contratodatainicial_N = (short)(sdt.gxTv_SdtAssinatura_Contratodatainicial_N);
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Contratodatainicial = sdt.gxTv_SdtAssinatura_Contratodatainicial ;
         }
         if ( sdt.IsDirty("ContratoDataFinal") )
         {
            gxTv_SdtAssinatura_Contratodatafinal_N = (short)(sdt.gxTv_SdtAssinatura_Contratodatafinal_N);
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Contratodatafinal = sdt.gxTv_SdtAssinatura_Contratodatafinal ;
         }
         if ( sdt.IsDirty("ArquivoId") )
         {
            gxTv_SdtAssinatura_Arquivoid_N = (short)(sdt.gxTv_SdtAssinatura_Arquivoid_N);
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Arquivoid = sdt.gxTv_SdtAssinatura_Arquivoid ;
         }
         if ( sdt.IsDirty("ArquivoAssinadoId") )
         {
            gxTv_SdtAssinatura_Arquivoassinadoid_N = (short)(sdt.gxTv_SdtAssinatura_Arquivoassinadoid_N);
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Arquivoassinadoid = sdt.gxTv_SdtAssinatura_Arquivoassinadoid ;
         }
         if ( sdt.IsDirty("AssinaturaArquivoAssinado") )
         {
            gxTv_SdtAssinatura_Assinaturaarquivoassinado_N = (short)(sdt.gxTv_SdtAssinatura_Assinaturaarquivoassinado_N);
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturaarquivoassinado = sdt.gxTv_SdtAssinatura_Assinaturaarquivoassinado ;
         }
         if ( sdt.IsDirty("AssinaturaArquivoAssinadoNome") )
         {
            gxTv_SdtAssinatura_Assinaturaarquivoassinadonome_N = (short)(sdt.gxTv_SdtAssinatura_Assinaturaarquivoassinadonome_N);
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturaarquivoassinadonome = sdt.gxTv_SdtAssinatura_Assinaturaarquivoassinadonome ;
         }
         if ( sdt.IsDirty("AssinaturaArquivoAssinadoExtensao") )
         {
            gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao_N = (short)(sdt.gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao_N);
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao = sdt.gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao ;
         }
         if ( sdt.IsDirty("AssinaturaPublicKey") )
         {
            gxTv_SdtAssinatura_Assinaturapublickey_N = (short)(sdt.gxTv_SdtAssinatura_Assinaturapublickey_N);
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturapublickey = sdt.gxTv_SdtAssinatura_Assinaturapublickey ;
         }
         if ( sdt.IsDirty("AssinaturaPaginaConsulta") )
         {
            gxTv_SdtAssinatura_Assinaturapaginaconsulta_N = (short)(sdt.gxTv_SdtAssinatura_Assinaturapaginaconsulta_N);
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturapaginaconsulta = sdt.gxTv_SdtAssinatura_Assinaturapaginaconsulta ;
         }
         if ( sdt.IsDirty("AssinaturaToken") )
         {
            gxTv_SdtAssinatura_Assinaturatoken_N = (short)(sdt.gxTv_SdtAssinatura_Assinaturatoken_N);
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturatoken = sdt.gxTv_SdtAssinatura_Assinaturatoken ;
         }
         if ( sdt.IsDirty("AssinaturaMes") )
         {
            gxTv_SdtAssinatura_Assinaturames_N = (short)(sdt.gxTv_SdtAssinatura_Assinaturames_N);
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturames = sdt.gxTv_SdtAssinatura_Assinaturames ;
         }
         if ( sdt.IsDirty("AssinaturaMesNome") )
         {
            gxTv_SdtAssinatura_Assinaturamesnome_N = (short)(sdt.gxTv_SdtAssinatura_Assinaturamesnome_N);
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturamesnome = sdt.gxTv_SdtAssinatura_Assinaturamesnome ;
         }
         if ( sdt.IsDirty("AssinaturaAno") )
         {
            gxTv_SdtAssinatura_Assinaturaano_N = (short)(sdt.gxTv_SdtAssinatura_Assinaturaano_N);
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturaano = sdt.gxTv_SdtAssinatura_Assinaturaano ;
         }
         if ( sdt.IsDirty("AssinaturaFinalizadoData") )
         {
            gxTv_SdtAssinatura_Assinaturafinalizadodata_N = (short)(sdt.gxTv_SdtAssinatura_Assinaturafinalizadodata_N);
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturafinalizadodata = sdt.gxTv_SdtAssinatura_Assinaturafinalizadodata ;
         }
         if ( sdt.IsDirty("AssinaturaParticipantes_F") )
         {
            gxTv_SdtAssinatura_Assinaturaparticipantes_f_N = (short)(sdt.gxTv_SdtAssinatura_Assinaturaparticipantes_f_N);
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturaparticipantes_f = sdt.gxTv_SdtAssinatura_Assinaturaparticipantes_f ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "AssinaturaId" )]
      [  XmlElement( ElementName = "AssinaturaId"   )]
      public long gxTpr_Assinaturaid
      {
         get {
            return gxTv_SdtAssinatura_Assinaturaid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtAssinatura_Assinaturaid != value )
            {
               gxTv_SdtAssinatura_Mode = "INS";
               this.gxTv_SdtAssinatura_Assinaturaid_Z_SetNull( );
               this.gxTv_SdtAssinatura_Assinaturastatus_Z_SetNull( );
               this.gxTv_SdtAssinatura_Contratoid_Z_SetNull( );
               this.gxTv_SdtAssinatura_Contratonome_Z_SetNull( );
               this.gxTv_SdtAssinatura_Contratodatainicial_Z_SetNull( );
               this.gxTv_SdtAssinatura_Contratodatafinal_Z_SetNull( );
               this.gxTv_SdtAssinatura_Arquivoid_Z_SetNull( );
               this.gxTv_SdtAssinatura_Arquivoassinadoid_Z_SetNull( );
               this.gxTv_SdtAssinatura_Assinaturaarquivoassinadonome_Z_SetNull( );
               this.gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao_Z_SetNull( );
               this.gxTv_SdtAssinatura_Assinaturapublickey_Z_SetNull( );
               this.gxTv_SdtAssinatura_Assinaturapaginaconsulta_Z_SetNull( );
               this.gxTv_SdtAssinatura_Assinaturatoken_Z_SetNull( );
               this.gxTv_SdtAssinatura_Assinaturames_Z_SetNull( );
               this.gxTv_SdtAssinatura_Assinaturamesnome_Z_SetNull( );
               this.gxTv_SdtAssinatura_Assinaturaano_Z_SetNull( );
               this.gxTv_SdtAssinatura_Assinaturafinalizadodata_Z_SetNull( );
               this.gxTv_SdtAssinatura_Assinaturaparticipantes_f_Z_SetNull( );
            }
            gxTv_SdtAssinatura_Assinaturaid = value;
            SetDirty("Assinaturaid");
         }

      }

      [  SoapElement( ElementName = "AssinaturaStatus" )]
      [  XmlElement( ElementName = "AssinaturaStatus"   )]
      public string gxTpr_Assinaturastatus
      {
         get {
            return gxTv_SdtAssinatura_Assinaturastatus ;
         }

         set {
            gxTv_SdtAssinatura_Assinaturastatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturastatus = value;
            SetDirty("Assinaturastatus");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturastatus_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturastatus_N = 1;
         gxTv_SdtAssinatura_Assinaturastatus = "";
         SetDirty("Assinaturastatus");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturastatus_IsNull( )
      {
         return (gxTv_SdtAssinatura_Assinaturastatus_N==1) ;
      }

      [  SoapElement( ElementName = "ContratoId" )]
      [  XmlElement( ElementName = "ContratoId"   )]
      public int gxTpr_Contratoid
      {
         get {
            return gxTv_SdtAssinatura_Contratoid ;
         }

         set {
            gxTv_SdtAssinatura_Contratoid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Contratoid = value;
            SetDirty("Contratoid");
         }

      }

      public void gxTv_SdtAssinatura_Contratoid_SetNull( )
      {
         gxTv_SdtAssinatura_Contratoid_N = 1;
         gxTv_SdtAssinatura_Contratoid = 0;
         SetDirty("Contratoid");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Contratoid_IsNull( )
      {
         return (gxTv_SdtAssinatura_Contratoid_N==1) ;
      }

      [  SoapElement( ElementName = "ContratoNome" )]
      [  XmlElement( ElementName = "ContratoNome"   )]
      public string gxTpr_Contratonome
      {
         get {
            return gxTv_SdtAssinatura_Contratonome ;
         }

         set {
            gxTv_SdtAssinatura_Contratonome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Contratonome = value;
            SetDirty("Contratonome");
         }

      }

      public void gxTv_SdtAssinatura_Contratonome_SetNull( )
      {
         gxTv_SdtAssinatura_Contratonome_N = 1;
         gxTv_SdtAssinatura_Contratonome = "";
         SetDirty("Contratonome");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Contratonome_IsNull( )
      {
         return (gxTv_SdtAssinatura_Contratonome_N==1) ;
      }

      [  SoapElement( ElementName = "ContratoDataInicial" )]
      [  XmlElement( ElementName = "ContratoDataInicial"  , IsNullable=true )]
      public string gxTpr_Contratodatainicial_Nullable
      {
         get {
            if ( gxTv_SdtAssinatura_Contratodatainicial == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtAssinatura_Contratodatainicial).value ;
         }

         set {
            gxTv_SdtAssinatura_Contratodatainicial_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtAssinatura_Contratodatainicial = DateTime.MinValue;
            else
               gxTv_SdtAssinatura_Contratodatainicial = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Contratodatainicial
      {
         get {
            return gxTv_SdtAssinatura_Contratodatainicial ;
         }

         set {
            gxTv_SdtAssinatura_Contratodatainicial_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Contratodatainicial = value;
            SetDirty("Contratodatainicial");
         }

      }

      public void gxTv_SdtAssinatura_Contratodatainicial_SetNull( )
      {
         gxTv_SdtAssinatura_Contratodatainicial_N = 1;
         gxTv_SdtAssinatura_Contratodatainicial = (DateTime)(DateTime.MinValue);
         SetDirty("Contratodatainicial");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Contratodatainicial_IsNull( )
      {
         return (gxTv_SdtAssinatura_Contratodatainicial_N==1) ;
      }

      [  SoapElement( ElementName = "ContratoDataFinal" )]
      [  XmlElement( ElementName = "ContratoDataFinal"  , IsNullable=true )]
      public string gxTpr_Contratodatafinal_Nullable
      {
         get {
            if ( gxTv_SdtAssinatura_Contratodatafinal == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtAssinatura_Contratodatafinal).value ;
         }

         set {
            gxTv_SdtAssinatura_Contratodatafinal_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtAssinatura_Contratodatafinal = DateTime.MinValue;
            else
               gxTv_SdtAssinatura_Contratodatafinal = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Contratodatafinal
      {
         get {
            return gxTv_SdtAssinatura_Contratodatafinal ;
         }

         set {
            gxTv_SdtAssinatura_Contratodatafinal_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Contratodatafinal = value;
            SetDirty("Contratodatafinal");
         }

      }

      public void gxTv_SdtAssinatura_Contratodatafinal_SetNull( )
      {
         gxTv_SdtAssinatura_Contratodatafinal_N = 1;
         gxTv_SdtAssinatura_Contratodatafinal = (DateTime)(DateTime.MinValue);
         SetDirty("Contratodatafinal");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Contratodatafinal_IsNull( )
      {
         return (gxTv_SdtAssinatura_Contratodatafinal_N==1) ;
      }

      [  SoapElement( ElementName = "ArquivoId" )]
      [  XmlElement( ElementName = "ArquivoId"   )]
      public int gxTpr_Arquivoid
      {
         get {
            return gxTv_SdtAssinatura_Arquivoid ;
         }

         set {
            gxTv_SdtAssinatura_Arquivoid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Arquivoid = value;
            SetDirty("Arquivoid");
         }

      }

      public void gxTv_SdtAssinatura_Arquivoid_SetNull( )
      {
         gxTv_SdtAssinatura_Arquivoid_N = 1;
         gxTv_SdtAssinatura_Arquivoid = 0;
         SetDirty("Arquivoid");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Arquivoid_IsNull( )
      {
         return (gxTv_SdtAssinatura_Arquivoid_N==1) ;
      }

      [  SoapElement( ElementName = "ArquivoAssinadoId" )]
      [  XmlElement( ElementName = "ArquivoAssinadoId"   )]
      public int gxTpr_Arquivoassinadoid
      {
         get {
            return gxTv_SdtAssinatura_Arquivoassinadoid ;
         }

         set {
            gxTv_SdtAssinatura_Arquivoassinadoid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Arquivoassinadoid = value;
            SetDirty("Arquivoassinadoid");
         }

      }

      public void gxTv_SdtAssinatura_Arquivoassinadoid_SetNull( )
      {
         gxTv_SdtAssinatura_Arquivoassinadoid_N = 1;
         gxTv_SdtAssinatura_Arquivoassinadoid = 0;
         SetDirty("Arquivoassinadoid");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Arquivoassinadoid_IsNull( )
      {
         return (gxTv_SdtAssinatura_Arquivoassinadoid_N==1) ;
      }

      [  SoapElement( ElementName = "AssinaturaArquivoAssinado" )]
      [  XmlElement( ElementName = "AssinaturaArquivoAssinado"   )]
      [GxUpload()]
      public byte[] gxTpr_Assinaturaarquivoassinado_Blob
      {
         get {
            IGxContext context = this.context == null ? new GxContext() : this.context;
            return context.FileToByteArray( gxTv_SdtAssinatura_Assinaturaarquivoassinado) ;
         }

         set {
            gxTv_SdtAssinatura_Assinaturaarquivoassinado_N = 0;
            sdtIsNull = 0;
            IGxContext context = this.context == null ? new GxContext() : this.context;
            gxTv_SdtAssinatura_Assinaturaarquivoassinado=context.FileFromByteArray( value) ;
         }

      }

      [XmlIgnore]
      [GxUpload()]
      public string gxTpr_Assinaturaarquivoassinado
      {
         get {
            return gxTv_SdtAssinatura_Assinaturaarquivoassinado ;
         }

         set {
            gxTv_SdtAssinatura_Assinaturaarquivoassinado_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturaarquivoassinado = value;
            SetDirty("Assinaturaarquivoassinado");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturaarquivoassinado_SetBlob( string blob ,
                                                                        string fileName ,
                                                                        string fileType )
      {
         gxTv_SdtAssinatura_Assinaturaarquivoassinado = blob;
         gxTv_SdtAssinatura_Assinaturaarquivoassinadonome = fileName;
         gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao = fileType;
         return  ;
      }

      public void gxTv_SdtAssinatura_Assinaturaarquivoassinado_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturaarquivoassinado_N = 1;
         gxTv_SdtAssinatura_Assinaturaarquivoassinado = "";
         SetDirty("Assinaturaarquivoassinado");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturaarquivoassinado_IsNull( )
      {
         return (gxTv_SdtAssinatura_Assinaturaarquivoassinado_N==1) ;
      }

      [  SoapElement( ElementName = "AssinaturaArquivoAssinadoNome" )]
      [  XmlElement( ElementName = "AssinaturaArquivoAssinadoNome"   )]
      public string gxTpr_Assinaturaarquivoassinadonome
      {
         get {
            return gxTv_SdtAssinatura_Assinaturaarquivoassinadonome ;
         }

         set {
            gxTv_SdtAssinatura_Assinaturaarquivoassinadonome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturaarquivoassinadonome = value;
            SetDirty("Assinaturaarquivoassinadonome");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturaarquivoassinadonome_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturaarquivoassinadonome_N = 1;
         gxTv_SdtAssinatura_Assinaturaarquivoassinadonome = "";
         SetDirty("Assinaturaarquivoassinadonome");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturaarquivoassinadonome_IsNull( )
      {
         return (gxTv_SdtAssinatura_Assinaturaarquivoassinadonome_N==1) ;
      }

      [  SoapElement( ElementName = "AssinaturaArquivoAssinadoExtensao" )]
      [  XmlElement( ElementName = "AssinaturaArquivoAssinadoExtensao"   )]
      public string gxTpr_Assinaturaarquivoassinadoextensao
      {
         get {
            return gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao ;
         }

         set {
            gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao = value;
            SetDirty("Assinaturaarquivoassinadoextensao");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao_N = 1;
         gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao = "";
         SetDirty("Assinaturaarquivoassinadoextensao");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao_IsNull( )
      {
         return (gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao_N==1) ;
      }

      [  SoapElement( ElementName = "AssinaturaPublicKey" )]
      [  XmlElement( ElementName = "AssinaturaPublicKey"   )]
      public Guid gxTpr_Assinaturapublickey
      {
         get {
            return gxTv_SdtAssinatura_Assinaturapublickey ;
         }

         set {
            gxTv_SdtAssinatura_Assinaturapublickey_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturapublickey = value;
            SetDirty("Assinaturapublickey");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturapublickey_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturapublickey_N = 1;
         gxTv_SdtAssinatura_Assinaturapublickey = Guid.Empty;
         SetDirty("Assinaturapublickey");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturapublickey_IsNull( )
      {
         return (gxTv_SdtAssinatura_Assinaturapublickey_N==1) ;
      }

      [  SoapElement( ElementName = "AssinaturaPaginaConsulta" )]
      [  XmlElement( ElementName = "AssinaturaPaginaConsulta"   )]
      public string gxTpr_Assinaturapaginaconsulta
      {
         get {
            return gxTv_SdtAssinatura_Assinaturapaginaconsulta ;
         }

         set {
            gxTv_SdtAssinatura_Assinaturapaginaconsulta_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturapaginaconsulta = value;
            SetDirty("Assinaturapaginaconsulta");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturapaginaconsulta_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturapaginaconsulta_N = 1;
         gxTv_SdtAssinatura_Assinaturapaginaconsulta = "";
         SetDirty("Assinaturapaginaconsulta");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturapaginaconsulta_IsNull( )
      {
         return (gxTv_SdtAssinatura_Assinaturapaginaconsulta_N==1) ;
      }

      [  SoapElement( ElementName = "AssinaturaToken" )]
      [  XmlElement( ElementName = "AssinaturaToken"   )]
      public string gxTpr_Assinaturatoken
      {
         get {
            return gxTv_SdtAssinatura_Assinaturatoken ;
         }

         set {
            gxTv_SdtAssinatura_Assinaturatoken_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturatoken = value;
            SetDirty("Assinaturatoken");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturatoken_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturatoken_N = 1;
         gxTv_SdtAssinatura_Assinaturatoken = "";
         SetDirty("Assinaturatoken");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturatoken_IsNull( )
      {
         return (gxTv_SdtAssinatura_Assinaturatoken_N==1) ;
      }

      [  SoapElement( ElementName = "AssinaturaMes" )]
      [  XmlElement( ElementName = "AssinaturaMes"   )]
      public short gxTpr_Assinaturames
      {
         get {
            return gxTv_SdtAssinatura_Assinaturames ;
         }

         set {
            gxTv_SdtAssinatura_Assinaturames_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturames = value;
            SetDirty("Assinaturames");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturames_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturames_N = 1;
         gxTv_SdtAssinatura_Assinaturames = 0;
         SetDirty("Assinaturames");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturames_IsNull( )
      {
         return (gxTv_SdtAssinatura_Assinaturames_N==1) ;
      }

      [  SoapElement( ElementName = "AssinaturaMesNome" )]
      [  XmlElement( ElementName = "AssinaturaMesNome"   )]
      public string gxTpr_Assinaturamesnome
      {
         get {
            return gxTv_SdtAssinatura_Assinaturamesnome ;
         }

         set {
            gxTv_SdtAssinatura_Assinaturamesnome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturamesnome = value;
            SetDirty("Assinaturamesnome");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturamesnome_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturamesnome_N = 1;
         gxTv_SdtAssinatura_Assinaturamesnome = "";
         SetDirty("Assinaturamesnome");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturamesnome_IsNull( )
      {
         return (gxTv_SdtAssinatura_Assinaturamesnome_N==1) ;
      }

      [  SoapElement( ElementName = "AssinaturaAno" )]
      [  XmlElement( ElementName = "AssinaturaAno"   )]
      public short gxTpr_Assinaturaano
      {
         get {
            return gxTv_SdtAssinatura_Assinaturaano ;
         }

         set {
            gxTv_SdtAssinatura_Assinaturaano_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturaano = value;
            SetDirty("Assinaturaano");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturaano_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturaano_N = 1;
         gxTv_SdtAssinatura_Assinaturaano = 0;
         SetDirty("Assinaturaano");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturaano_IsNull( )
      {
         return (gxTv_SdtAssinatura_Assinaturaano_N==1) ;
      }

      [  SoapElement( ElementName = "AssinaturaFinalizadoData" )]
      [  XmlElement( ElementName = "AssinaturaFinalizadoData"  , IsNullable=true )]
      public string gxTpr_Assinaturafinalizadodata_Nullable
      {
         get {
            if ( gxTv_SdtAssinatura_Assinaturafinalizadodata == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtAssinatura_Assinaturafinalizadodata).value ;
         }

         set {
            gxTv_SdtAssinatura_Assinaturafinalizadodata_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtAssinatura_Assinaturafinalizadodata = DateTime.MinValue;
            else
               gxTv_SdtAssinatura_Assinaturafinalizadodata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Assinaturafinalizadodata
      {
         get {
            return gxTv_SdtAssinatura_Assinaturafinalizadodata ;
         }

         set {
            gxTv_SdtAssinatura_Assinaturafinalizadodata_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturafinalizadodata = value;
            SetDirty("Assinaturafinalizadodata");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturafinalizadodata_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturafinalizadodata_N = 1;
         gxTv_SdtAssinatura_Assinaturafinalizadodata = (DateTime)(DateTime.MinValue);
         SetDirty("Assinaturafinalizadodata");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturafinalizadodata_IsNull( )
      {
         return (gxTv_SdtAssinatura_Assinaturafinalizadodata_N==1) ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipantes_F" )]
      [  XmlElement( ElementName = "AssinaturaParticipantes_F"   )]
      public short gxTpr_Assinaturaparticipantes_f
      {
         get {
            return gxTv_SdtAssinatura_Assinaturaparticipantes_f ;
         }

         set {
            gxTv_SdtAssinatura_Assinaturaparticipantes_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturaparticipantes_f = value;
            SetDirty("Assinaturaparticipantes_f");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturaparticipantes_f_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturaparticipantes_f_N = 1;
         gxTv_SdtAssinatura_Assinaturaparticipantes_f = 0;
         SetDirty("Assinaturaparticipantes_f");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturaparticipantes_f_IsNull( )
      {
         return (gxTv_SdtAssinatura_Assinaturaparticipantes_f_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtAssinatura_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtAssinatura_Mode_SetNull( )
      {
         gxTv_SdtAssinatura_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtAssinatura_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtAssinatura_Initialized_SetNull( )
      {
         gxTv_SdtAssinatura_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaId_Z" )]
      [  XmlElement( ElementName = "AssinaturaId_Z"   )]
      public long gxTpr_Assinaturaid_Z
      {
         get {
            return gxTv_SdtAssinatura_Assinaturaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturaid_Z = value;
            SetDirty("Assinaturaid_Z");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturaid_Z_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturaid_Z = 0;
         SetDirty("Assinaturaid_Z");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaStatus_Z" )]
      [  XmlElement( ElementName = "AssinaturaStatus_Z"   )]
      public string gxTpr_Assinaturastatus_Z
      {
         get {
            return gxTv_SdtAssinatura_Assinaturastatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturastatus_Z = value;
            SetDirty("Assinaturastatus_Z");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturastatus_Z_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturastatus_Z = "";
         SetDirty("Assinaturastatus_Z");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturastatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoId_Z" )]
      [  XmlElement( ElementName = "ContratoId_Z"   )]
      public int gxTpr_Contratoid_Z
      {
         get {
            return gxTv_SdtAssinatura_Contratoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Contratoid_Z = value;
            SetDirty("Contratoid_Z");
         }

      }

      public void gxTv_SdtAssinatura_Contratoid_Z_SetNull( )
      {
         gxTv_SdtAssinatura_Contratoid_Z = 0;
         SetDirty("Contratoid_Z");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Contratoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoNome_Z" )]
      [  XmlElement( ElementName = "ContratoNome_Z"   )]
      public string gxTpr_Contratonome_Z
      {
         get {
            return gxTv_SdtAssinatura_Contratonome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Contratonome_Z = value;
            SetDirty("Contratonome_Z");
         }

      }

      public void gxTv_SdtAssinatura_Contratonome_Z_SetNull( )
      {
         gxTv_SdtAssinatura_Contratonome_Z = "";
         SetDirty("Contratonome_Z");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Contratonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoDataInicial_Z" )]
      [  XmlElement( ElementName = "ContratoDataInicial_Z"  , IsNullable=true )]
      public string gxTpr_Contratodatainicial_Z_Nullable
      {
         get {
            if ( gxTv_SdtAssinatura_Contratodatainicial_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtAssinatura_Contratodatainicial_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtAssinatura_Contratodatainicial_Z = DateTime.MinValue;
            else
               gxTv_SdtAssinatura_Contratodatainicial_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Contratodatainicial_Z
      {
         get {
            return gxTv_SdtAssinatura_Contratodatainicial_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Contratodatainicial_Z = value;
            SetDirty("Contratodatainicial_Z");
         }

      }

      public void gxTv_SdtAssinatura_Contratodatainicial_Z_SetNull( )
      {
         gxTv_SdtAssinatura_Contratodatainicial_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Contratodatainicial_Z");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Contratodatainicial_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoDataFinal_Z" )]
      [  XmlElement( ElementName = "ContratoDataFinal_Z"  , IsNullable=true )]
      public string gxTpr_Contratodatafinal_Z_Nullable
      {
         get {
            if ( gxTv_SdtAssinatura_Contratodatafinal_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtAssinatura_Contratodatafinal_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtAssinatura_Contratodatafinal_Z = DateTime.MinValue;
            else
               gxTv_SdtAssinatura_Contratodatafinal_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Contratodatafinal_Z
      {
         get {
            return gxTv_SdtAssinatura_Contratodatafinal_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Contratodatafinal_Z = value;
            SetDirty("Contratodatafinal_Z");
         }

      }

      public void gxTv_SdtAssinatura_Contratodatafinal_Z_SetNull( )
      {
         gxTv_SdtAssinatura_Contratodatafinal_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Contratodatafinal_Z");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Contratodatafinal_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ArquivoId_Z" )]
      [  XmlElement( ElementName = "ArquivoId_Z"   )]
      public int gxTpr_Arquivoid_Z
      {
         get {
            return gxTv_SdtAssinatura_Arquivoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Arquivoid_Z = value;
            SetDirty("Arquivoid_Z");
         }

      }

      public void gxTv_SdtAssinatura_Arquivoid_Z_SetNull( )
      {
         gxTv_SdtAssinatura_Arquivoid_Z = 0;
         SetDirty("Arquivoid_Z");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Arquivoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ArquivoAssinadoId_Z" )]
      [  XmlElement( ElementName = "ArquivoAssinadoId_Z"   )]
      public int gxTpr_Arquivoassinadoid_Z
      {
         get {
            return gxTv_SdtAssinatura_Arquivoassinadoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Arquivoassinadoid_Z = value;
            SetDirty("Arquivoassinadoid_Z");
         }

      }

      public void gxTv_SdtAssinatura_Arquivoassinadoid_Z_SetNull( )
      {
         gxTv_SdtAssinatura_Arquivoassinadoid_Z = 0;
         SetDirty("Arquivoassinadoid_Z");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Arquivoassinadoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaArquivoAssinadoNome_Z" )]
      [  XmlElement( ElementName = "AssinaturaArquivoAssinadoNome_Z"   )]
      public string gxTpr_Assinaturaarquivoassinadonome_Z
      {
         get {
            return gxTv_SdtAssinatura_Assinaturaarquivoassinadonome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturaarquivoassinadonome_Z = value;
            SetDirty("Assinaturaarquivoassinadonome_Z");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturaarquivoassinadonome_Z_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturaarquivoassinadonome_Z = "";
         SetDirty("Assinaturaarquivoassinadonome_Z");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturaarquivoassinadonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaArquivoAssinadoExtensao_Z" )]
      [  XmlElement( ElementName = "AssinaturaArquivoAssinadoExtensao_Z"   )]
      public string gxTpr_Assinaturaarquivoassinadoextensao_Z
      {
         get {
            return gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao_Z = value;
            SetDirty("Assinaturaarquivoassinadoextensao_Z");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao_Z_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao_Z = "";
         SetDirty("Assinaturaarquivoassinadoextensao_Z");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaPublicKey_Z" )]
      [  XmlElement( ElementName = "AssinaturaPublicKey_Z"   )]
      public Guid gxTpr_Assinaturapublickey_Z
      {
         get {
            return gxTv_SdtAssinatura_Assinaturapublickey_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturapublickey_Z = value;
            SetDirty("Assinaturapublickey_Z");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturapublickey_Z_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturapublickey_Z = Guid.Empty;
         SetDirty("Assinaturapublickey_Z");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturapublickey_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaPaginaConsulta_Z" )]
      [  XmlElement( ElementName = "AssinaturaPaginaConsulta_Z"   )]
      public string gxTpr_Assinaturapaginaconsulta_Z
      {
         get {
            return gxTv_SdtAssinatura_Assinaturapaginaconsulta_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturapaginaconsulta_Z = value;
            SetDirty("Assinaturapaginaconsulta_Z");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturapaginaconsulta_Z_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturapaginaconsulta_Z = "";
         SetDirty("Assinaturapaginaconsulta_Z");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturapaginaconsulta_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaToken_Z" )]
      [  XmlElement( ElementName = "AssinaturaToken_Z"   )]
      public string gxTpr_Assinaturatoken_Z
      {
         get {
            return gxTv_SdtAssinatura_Assinaturatoken_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturatoken_Z = value;
            SetDirty("Assinaturatoken_Z");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturatoken_Z_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturatoken_Z = "";
         SetDirty("Assinaturatoken_Z");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturatoken_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaMes_Z" )]
      [  XmlElement( ElementName = "AssinaturaMes_Z"   )]
      public short gxTpr_Assinaturames_Z
      {
         get {
            return gxTv_SdtAssinatura_Assinaturames_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturames_Z = value;
            SetDirty("Assinaturames_Z");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturames_Z_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturames_Z = 0;
         SetDirty("Assinaturames_Z");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturames_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaMesNome_Z" )]
      [  XmlElement( ElementName = "AssinaturaMesNome_Z"   )]
      public string gxTpr_Assinaturamesnome_Z
      {
         get {
            return gxTv_SdtAssinatura_Assinaturamesnome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturamesnome_Z = value;
            SetDirty("Assinaturamesnome_Z");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturamesnome_Z_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturamesnome_Z = "";
         SetDirty("Assinaturamesnome_Z");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturamesnome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaAno_Z" )]
      [  XmlElement( ElementName = "AssinaturaAno_Z"   )]
      public short gxTpr_Assinaturaano_Z
      {
         get {
            return gxTv_SdtAssinatura_Assinaturaano_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturaano_Z = value;
            SetDirty("Assinaturaano_Z");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturaano_Z_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturaano_Z = 0;
         SetDirty("Assinaturaano_Z");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturaano_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaFinalizadoData_Z" )]
      [  XmlElement( ElementName = "AssinaturaFinalizadoData_Z"  , IsNullable=true )]
      public string gxTpr_Assinaturafinalizadodata_Z_Nullable
      {
         get {
            if ( gxTv_SdtAssinatura_Assinaturafinalizadodata_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtAssinatura_Assinaturafinalizadodata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtAssinatura_Assinaturafinalizadodata_Z = DateTime.MinValue;
            else
               gxTv_SdtAssinatura_Assinaturafinalizadodata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Assinaturafinalizadodata_Z
      {
         get {
            return gxTv_SdtAssinatura_Assinaturafinalizadodata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturafinalizadodata_Z = value;
            SetDirty("Assinaturafinalizadodata_Z");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturafinalizadodata_Z_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturafinalizadodata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Assinaturafinalizadodata_Z");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturafinalizadodata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipantes_F_Z" )]
      [  XmlElement( ElementName = "AssinaturaParticipantes_F_Z"   )]
      public short gxTpr_Assinaturaparticipantes_f_Z
      {
         get {
            return gxTv_SdtAssinatura_Assinaturaparticipantes_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturaparticipantes_f_Z = value;
            SetDirty("Assinaturaparticipantes_f_Z");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturaparticipantes_f_Z_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturaparticipantes_f_Z = 0;
         SetDirty("Assinaturaparticipantes_f_Z");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturaparticipantes_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaId_N" )]
      [  XmlElement( ElementName = "AssinaturaId_N"   )]
      public short gxTpr_Assinaturaid_N
      {
         get {
            return gxTv_SdtAssinatura_Assinaturaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturaid_N = value;
            SetDirty("Assinaturaid_N");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturaid_N_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturaid_N = 0;
         SetDirty("Assinaturaid_N");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaStatus_N" )]
      [  XmlElement( ElementName = "AssinaturaStatus_N"   )]
      public short gxTpr_Assinaturastatus_N
      {
         get {
            return gxTv_SdtAssinatura_Assinaturastatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturastatus_N = value;
            SetDirty("Assinaturastatus_N");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturastatus_N_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturastatus_N = 0;
         SetDirty("Assinaturastatus_N");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturastatus_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoId_N" )]
      [  XmlElement( ElementName = "ContratoId_N"   )]
      public short gxTpr_Contratoid_N
      {
         get {
            return gxTv_SdtAssinatura_Contratoid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Contratoid_N = value;
            SetDirty("Contratoid_N");
         }

      }

      public void gxTv_SdtAssinatura_Contratoid_N_SetNull( )
      {
         gxTv_SdtAssinatura_Contratoid_N = 0;
         SetDirty("Contratoid_N");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Contratoid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoNome_N" )]
      [  XmlElement( ElementName = "ContratoNome_N"   )]
      public short gxTpr_Contratonome_N
      {
         get {
            return gxTv_SdtAssinatura_Contratonome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Contratonome_N = value;
            SetDirty("Contratonome_N");
         }

      }

      public void gxTv_SdtAssinatura_Contratonome_N_SetNull( )
      {
         gxTv_SdtAssinatura_Contratonome_N = 0;
         SetDirty("Contratonome_N");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Contratonome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoDataInicial_N" )]
      [  XmlElement( ElementName = "ContratoDataInicial_N"   )]
      public short gxTpr_Contratodatainicial_N
      {
         get {
            return gxTv_SdtAssinatura_Contratodatainicial_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Contratodatainicial_N = value;
            SetDirty("Contratodatainicial_N");
         }

      }

      public void gxTv_SdtAssinatura_Contratodatainicial_N_SetNull( )
      {
         gxTv_SdtAssinatura_Contratodatainicial_N = 0;
         SetDirty("Contratodatainicial_N");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Contratodatainicial_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoDataFinal_N" )]
      [  XmlElement( ElementName = "ContratoDataFinal_N"   )]
      public short gxTpr_Contratodatafinal_N
      {
         get {
            return gxTv_SdtAssinatura_Contratodatafinal_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Contratodatafinal_N = value;
            SetDirty("Contratodatafinal_N");
         }

      }

      public void gxTv_SdtAssinatura_Contratodatafinal_N_SetNull( )
      {
         gxTv_SdtAssinatura_Contratodatafinal_N = 0;
         SetDirty("Contratodatafinal_N");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Contratodatafinal_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ArquivoId_N" )]
      [  XmlElement( ElementName = "ArquivoId_N"   )]
      public short gxTpr_Arquivoid_N
      {
         get {
            return gxTv_SdtAssinatura_Arquivoid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Arquivoid_N = value;
            SetDirty("Arquivoid_N");
         }

      }

      public void gxTv_SdtAssinatura_Arquivoid_N_SetNull( )
      {
         gxTv_SdtAssinatura_Arquivoid_N = 0;
         SetDirty("Arquivoid_N");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Arquivoid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ArquivoAssinadoId_N" )]
      [  XmlElement( ElementName = "ArquivoAssinadoId_N"   )]
      public short gxTpr_Arquivoassinadoid_N
      {
         get {
            return gxTv_SdtAssinatura_Arquivoassinadoid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Arquivoassinadoid_N = value;
            SetDirty("Arquivoassinadoid_N");
         }

      }

      public void gxTv_SdtAssinatura_Arquivoassinadoid_N_SetNull( )
      {
         gxTv_SdtAssinatura_Arquivoassinadoid_N = 0;
         SetDirty("Arquivoassinadoid_N");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Arquivoassinadoid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaArquivoAssinado_N" )]
      [  XmlElement( ElementName = "AssinaturaArquivoAssinado_N"   )]
      public short gxTpr_Assinaturaarquivoassinado_N
      {
         get {
            return gxTv_SdtAssinatura_Assinaturaarquivoassinado_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturaarquivoassinado_N = value;
            SetDirty("Assinaturaarquivoassinado_N");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturaarquivoassinado_N_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturaarquivoassinado_N = 0;
         SetDirty("Assinaturaarquivoassinado_N");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturaarquivoassinado_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaArquivoAssinadoNome_N" )]
      [  XmlElement( ElementName = "AssinaturaArquivoAssinadoNome_N"   )]
      public short gxTpr_Assinaturaarquivoassinadonome_N
      {
         get {
            return gxTv_SdtAssinatura_Assinaturaarquivoassinadonome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturaarquivoassinadonome_N = value;
            SetDirty("Assinaturaarquivoassinadonome_N");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturaarquivoassinadonome_N_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturaarquivoassinadonome_N = 0;
         SetDirty("Assinaturaarquivoassinadonome_N");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturaarquivoassinadonome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaArquivoAssinadoExtensao_N" )]
      [  XmlElement( ElementName = "AssinaturaArquivoAssinadoExtensao_N"   )]
      public short gxTpr_Assinaturaarquivoassinadoextensao_N
      {
         get {
            return gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao_N = value;
            SetDirty("Assinaturaarquivoassinadoextensao_N");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao_N_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao_N = 0;
         SetDirty("Assinaturaarquivoassinadoextensao_N");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaPublicKey_N" )]
      [  XmlElement( ElementName = "AssinaturaPublicKey_N"   )]
      public short gxTpr_Assinaturapublickey_N
      {
         get {
            return gxTv_SdtAssinatura_Assinaturapublickey_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturapublickey_N = value;
            SetDirty("Assinaturapublickey_N");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturapublickey_N_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturapublickey_N = 0;
         SetDirty("Assinaturapublickey_N");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturapublickey_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaPaginaConsulta_N" )]
      [  XmlElement( ElementName = "AssinaturaPaginaConsulta_N"   )]
      public short gxTpr_Assinaturapaginaconsulta_N
      {
         get {
            return gxTv_SdtAssinatura_Assinaturapaginaconsulta_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturapaginaconsulta_N = value;
            SetDirty("Assinaturapaginaconsulta_N");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturapaginaconsulta_N_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturapaginaconsulta_N = 0;
         SetDirty("Assinaturapaginaconsulta_N");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturapaginaconsulta_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaToken_N" )]
      [  XmlElement( ElementName = "AssinaturaToken_N"   )]
      public short gxTpr_Assinaturatoken_N
      {
         get {
            return gxTv_SdtAssinatura_Assinaturatoken_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturatoken_N = value;
            SetDirty("Assinaturatoken_N");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturatoken_N_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturatoken_N = 0;
         SetDirty("Assinaturatoken_N");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturatoken_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaMes_N" )]
      [  XmlElement( ElementName = "AssinaturaMes_N"   )]
      public short gxTpr_Assinaturames_N
      {
         get {
            return gxTv_SdtAssinatura_Assinaturames_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturames_N = value;
            SetDirty("Assinaturames_N");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturames_N_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturames_N = 0;
         SetDirty("Assinaturames_N");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturames_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaMesNome_N" )]
      [  XmlElement( ElementName = "AssinaturaMesNome_N"   )]
      public short gxTpr_Assinaturamesnome_N
      {
         get {
            return gxTv_SdtAssinatura_Assinaturamesnome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturamesnome_N = value;
            SetDirty("Assinaturamesnome_N");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturamesnome_N_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturamesnome_N = 0;
         SetDirty("Assinaturamesnome_N");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturamesnome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaAno_N" )]
      [  XmlElement( ElementName = "AssinaturaAno_N"   )]
      public short gxTpr_Assinaturaano_N
      {
         get {
            return gxTv_SdtAssinatura_Assinaturaano_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturaano_N = value;
            SetDirty("Assinaturaano_N");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturaano_N_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturaano_N = 0;
         SetDirty("Assinaturaano_N");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturaano_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaFinalizadoData_N" )]
      [  XmlElement( ElementName = "AssinaturaFinalizadoData_N"   )]
      public short gxTpr_Assinaturafinalizadodata_N
      {
         get {
            return gxTv_SdtAssinatura_Assinaturafinalizadodata_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturafinalizadodata_N = value;
            SetDirty("Assinaturafinalizadodata_N");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturafinalizadodata_N_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturafinalizadodata_N = 0;
         SetDirty("Assinaturafinalizadodata_N");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturafinalizadodata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipantes_F_N" )]
      [  XmlElement( ElementName = "AssinaturaParticipantes_F_N"   )]
      public short gxTpr_Assinaturaparticipantes_f_N
      {
         get {
            return gxTv_SdtAssinatura_Assinaturaparticipantes_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinatura_Assinaturaparticipantes_f_N = value;
            SetDirty("Assinaturaparticipantes_f_N");
         }

      }

      public void gxTv_SdtAssinatura_Assinaturaparticipantes_f_N_SetNull( )
      {
         gxTv_SdtAssinatura_Assinaturaparticipantes_f_N = 0;
         SetDirty("Assinaturaparticipantes_f_N");
         return  ;
      }

      public bool gxTv_SdtAssinatura_Assinaturaparticipantes_f_N_IsNull( )
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
         gxTv_SdtAssinatura_Assinaturastatus = "";
         gxTv_SdtAssinatura_Contratonome = "";
         gxTv_SdtAssinatura_Contratodatainicial = DateTime.MinValue;
         gxTv_SdtAssinatura_Contratodatafinal = DateTime.MinValue;
         gxTv_SdtAssinatura_Assinaturaarquivoassinado = "";
         gxTv_SdtAssinatura_Assinaturaarquivoassinadonome = "";
         gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao = "";
         gxTv_SdtAssinatura_Assinaturapublickey = Guid.Empty;
         gxTv_SdtAssinatura_Assinaturapaginaconsulta = "";
         gxTv_SdtAssinatura_Assinaturatoken = "";
         gxTv_SdtAssinatura_Assinaturamesnome = "";
         gxTv_SdtAssinatura_Assinaturafinalizadodata = (DateTime)(DateTime.MinValue);
         gxTv_SdtAssinatura_Mode = "";
         gxTv_SdtAssinatura_Assinaturastatus_Z = "";
         gxTv_SdtAssinatura_Contratonome_Z = "";
         gxTv_SdtAssinatura_Contratodatainicial_Z = DateTime.MinValue;
         gxTv_SdtAssinatura_Contratodatafinal_Z = DateTime.MinValue;
         gxTv_SdtAssinatura_Assinaturaarquivoassinadonome_Z = "";
         gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao_Z = "";
         gxTv_SdtAssinatura_Assinaturapublickey_Z = Guid.Empty;
         gxTv_SdtAssinatura_Assinaturapaginaconsulta_Z = "";
         gxTv_SdtAssinatura_Assinaturatoken_Z = "";
         gxTv_SdtAssinatura_Assinaturamesnome_Z = "";
         gxTv_SdtAssinatura_Assinaturafinalizadodata_Z = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "assinatura", "GeneXus.Programs.assinatura_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtAssinatura_Assinaturames ;
      private short gxTv_SdtAssinatura_Assinaturaano ;
      private short gxTv_SdtAssinatura_Assinaturaparticipantes_f ;
      private short gxTv_SdtAssinatura_Initialized ;
      private short gxTv_SdtAssinatura_Assinaturames_Z ;
      private short gxTv_SdtAssinatura_Assinaturaano_Z ;
      private short gxTv_SdtAssinatura_Assinaturaparticipantes_f_Z ;
      private short gxTv_SdtAssinatura_Assinaturaid_N ;
      private short gxTv_SdtAssinatura_Assinaturastatus_N ;
      private short gxTv_SdtAssinatura_Contratoid_N ;
      private short gxTv_SdtAssinatura_Contratonome_N ;
      private short gxTv_SdtAssinatura_Contratodatainicial_N ;
      private short gxTv_SdtAssinatura_Contratodatafinal_N ;
      private short gxTv_SdtAssinatura_Arquivoid_N ;
      private short gxTv_SdtAssinatura_Arquivoassinadoid_N ;
      private short gxTv_SdtAssinatura_Assinaturaarquivoassinado_N ;
      private short gxTv_SdtAssinatura_Assinaturaarquivoassinadonome_N ;
      private short gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao_N ;
      private short gxTv_SdtAssinatura_Assinaturapublickey_N ;
      private short gxTv_SdtAssinatura_Assinaturapaginaconsulta_N ;
      private short gxTv_SdtAssinatura_Assinaturatoken_N ;
      private short gxTv_SdtAssinatura_Assinaturames_N ;
      private short gxTv_SdtAssinatura_Assinaturamesnome_N ;
      private short gxTv_SdtAssinatura_Assinaturaano_N ;
      private short gxTv_SdtAssinatura_Assinaturafinalizadodata_N ;
      private short gxTv_SdtAssinatura_Assinaturaparticipantes_f_N ;
      private int gxTv_SdtAssinatura_Contratoid ;
      private int gxTv_SdtAssinatura_Arquivoid ;
      private int gxTv_SdtAssinatura_Arquivoassinadoid ;
      private int gxTv_SdtAssinatura_Contratoid_Z ;
      private int gxTv_SdtAssinatura_Arquivoid_Z ;
      private int gxTv_SdtAssinatura_Arquivoassinadoid_Z ;
      private long gxTv_SdtAssinatura_Assinaturaid ;
      private long gxTv_SdtAssinatura_Assinaturaid_Z ;
      private string gxTv_SdtAssinatura_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtAssinatura_Assinaturafinalizadodata ;
      private DateTime gxTv_SdtAssinatura_Assinaturafinalizadodata_Z ;
      private DateTime datetime_STZ ;
      private DateTime gxTv_SdtAssinatura_Contratodatainicial ;
      private DateTime gxTv_SdtAssinatura_Contratodatafinal ;
      private DateTime gxTv_SdtAssinatura_Contratodatainicial_Z ;
      private DateTime gxTv_SdtAssinatura_Contratodatafinal_Z ;
      private string gxTv_SdtAssinatura_Assinaturastatus ;
      private string gxTv_SdtAssinatura_Contratonome ;
      private string gxTv_SdtAssinatura_Assinaturaarquivoassinadonome ;
      private string gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao ;
      private string gxTv_SdtAssinatura_Assinaturapaginaconsulta ;
      private string gxTv_SdtAssinatura_Assinaturatoken ;
      private string gxTv_SdtAssinatura_Assinaturamesnome ;
      private string gxTv_SdtAssinatura_Assinaturastatus_Z ;
      private string gxTv_SdtAssinatura_Contratonome_Z ;
      private string gxTv_SdtAssinatura_Assinaturaarquivoassinadonome_Z ;
      private string gxTv_SdtAssinatura_Assinaturaarquivoassinadoextensao_Z ;
      private string gxTv_SdtAssinatura_Assinaturapaginaconsulta_Z ;
      private string gxTv_SdtAssinatura_Assinaturatoken_Z ;
      private string gxTv_SdtAssinatura_Assinaturamesnome_Z ;
      private Guid gxTv_SdtAssinatura_Assinaturapublickey ;
      private Guid gxTv_SdtAssinatura_Assinaturapublickey_Z ;
      private string gxTv_SdtAssinatura_Assinaturaarquivoassinado ;
   }

   [DataContract(Name = @"Assinatura", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtAssinatura_RESTInterface : GxGenericCollectionItem<SdtAssinatura>
   {
      public SdtAssinatura_RESTInterface( ) : base()
      {
      }

      public SdtAssinatura_RESTInterface( SdtAssinatura psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AssinaturaId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Assinaturaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Assinaturaid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Assinaturaid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "AssinaturaStatus" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Assinaturastatus
      {
         get {
            return sdt.gxTpr_Assinaturastatus ;
         }

         set {
            sdt.gxTpr_Assinaturastatus = value;
         }

      }

      [DataMember( Name = "ContratoId" , Order = 2 )]
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

      [DataMember( Name = "ContratoNome" , Order = 3 )]
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

      [DataMember( Name = "ArquivoId" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Arquivoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Arquivoid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Arquivoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ArquivoAssinadoId" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Arquivoassinadoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Arquivoassinadoid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Arquivoassinadoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "AssinaturaArquivoAssinado" , Order = 8 )]
      [GxUpload()]
      public string gxTpr_Assinaturaarquivoassinado
      {
         get {
            return PathUtil.RelativeURL( sdt.gxTpr_Assinaturaarquivoassinado) ;
         }

         set {
            sdt.gxTpr_Assinaturaarquivoassinado = value;
         }

      }

      [DataMember( Name = "AssinaturaArquivoAssinadoNome" , Order = 9 )]
      public string gxTpr_Assinaturaarquivoassinadonome
      {
         get {
            return sdt.gxTpr_Assinaturaarquivoassinadonome ;
         }

         set {
            sdt.gxTpr_Assinaturaarquivoassinadonome = value;
         }

      }

      [DataMember( Name = "AssinaturaArquivoAssinadoExtensao" , Order = 10 )]
      public string gxTpr_Assinaturaarquivoassinadoextensao
      {
         get {
            return sdt.gxTpr_Assinaturaarquivoassinadoextensao ;
         }

         set {
            sdt.gxTpr_Assinaturaarquivoassinadoextensao = value;
         }

      }

      [DataMember( Name = "AssinaturaPublicKey" , Order = 11 )]
      [GxSeudo()]
      public Guid gxTpr_Assinaturapublickey
      {
         get {
            return sdt.gxTpr_Assinaturapublickey ;
         }

         set {
            sdt.gxTpr_Assinaturapublickey = value;
         }

      }

      [DataMember( Name = "AssinaturaPaginaConsulta" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Assinaturapaginaconsulta
      {
         get {
            return sdt.gxTpr_Assinaturapaginaconsulta ;
         }

         set {
            sdt.gxTpr_Assinaturapaginaconsulta = value;
         }

      }

      [DataMember( Name = "AssinaturaToken" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Assinaturatoken
      {
         get {
            return sdt.gxTpr_Assinaturatoken ;
         }

         set {
            sdt.gxTpr_Assinaturatoken = value;
         }

      }

      [DataMember( Name = "AssinaturaMes" , Order = 14 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Assinaturames
      {
         get {
            return sdt.gxTpr_Assinaturames ;
         }

         set {
            sdt.gxTpr_Assinaturames = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "AssinaturaMesNome" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Assinaturamesnome
      {
         get {
            return sdt.gxTpr_Assinaturamesnome ;
         }

         set {
            sdt.gxTpr_Assinaturamesnome = value;
         }

      }

      [DataMember( Name = "AssinaturaAno" , Order = 16 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Assinaturaano
      {
         get {
            return sdt.gxTpr_Assinaturaano ;
         }

         set {
            sdt.gxTpr_Assinaturaano = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "AssinaturaFinalizadoData" , Order = 17 )]
      [GxSeudo()]
      public string gxTpr_Assinaturafinalizadodata
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Assinaturafinalizadodata, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Assinaturafinalizadodata = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "AssinaturaParticipantes_F" , Order = 18 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Assinaturaparticipantes_f
      {
         get {
            return sdt.gxTpr_Assinaturaparticipantes_f ;
         }

         set {
            sdt.gxTpr_Assinaturaparticipantes_f = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtAssinatura sdt
      {
         get {
            return (SdtAssinatura)Sdt ;
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
            sdt = new SdtAssinatura() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 19 )]
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

   [DataContract(Name = @"Assinatura", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtAssinatura_RESTLInterface : GxGenericCollectionItem<SdtAssinatura>
   {
      public SdtAssinatura_RESTLInterface( ) : base()
      {
      }

      public SdtAssinatura_RESTLInterface( SdtAssinatura psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AssinaturaStatus" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Assinaturastatus
      {
         get {
            return sdt.gxTpr_Assinaturastatus ;
         }

         set {
            sdt.gxTpr_Assinaturastatus = value;
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

      public SdtAssinatura sdt
      {
         get {
            return (SdtAssinatura)Sdt ;
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
            sdt = new SdtAssinatura() ;
         }
      }

   }

}
