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
   [XmlRoot(ElementName = "TituloMovimento" )]
   [XmlType(TypeName =  "TituloMovimento" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtTituloMovimento : GxSilentTrnSdt
   {
      public SdtTituloMovimento( )
      {
      }

      public SdtTituloMovimento( IGxContext context )
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

      public void Load( int AV270TituloMovimentoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV270TituloMovimentoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"TituloMovimentoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "TituloMovimento");
         metadata.Set("BT", "TituloMovimento");
         metadata.Set("PK", "[ \"TituloMovimentoId\" ]");
         metadata.Set("PKAssigned", "[ \"TituloMovimentoId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ContaId\" ],\"FKMap\":[ \"TituloMovimentoConta-ContaId\" ] },{ \"FK\":[ \"TipoPagamentoId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"TituloId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Titulomovimentoid_Z");
         state.Add("gxTpr_Tipopagamentoid_Z");
         state.Add("gxTpr_Tituloid_Z");
         state.Add("gxTpr_Titulomovimentovalor_Z");
         state.Add("gxTpr_Titulomovimentotipo_Z");
         state.Add("gxTpr_Titulomovimentosoma_Z");
         state.Add("gxTpr_Titulomovimentodatacredito_Z_Nullable");
         state.Add("gxTpr_Titulomovimentocreatedat_Z_Nullable");
         state.Add("gxTpr_Titulomovimentoupdatedat_Z_Nullable");
         state.Add("gxTpr_Tipopagamentonome_Z");
         state.Add("gxTpr_Titulomovimentoope_Z");
         state.Add("gxTpr_Titulomovimentoconta_Z");
         state.Add("gxTpr_Tipopagamentoid_N");
         state.Add("gxTpr_Tituloid_N");
         state.Add("gxTpr_Titulomovimentovalor_N");
         state.Add("gxTpr_Titulomovimentotipo_N");
         state.Add("gxTpr_Titulomovimentosoma_N");
         state.Add("gxTpr_Titulomovimentodatacredito_N");
         state.Add("gxTpr_Titulomovimentocreatedat_N");
         state.Add("gxTpr_Titulomovimentoupdatedat_N");
         state.Add("gxTpr_Titulomovimentoope_N");
         state.Add("gxTpr_Titulomovimentoconta_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTituloMovimento sdt;
         sdt = (SdtTituloMovimento)(source);
         gxTv_SdtTituloMovimento_Titulomovimentoid = sdt.gxTv_SdtTituloMovimento_Titulomovimentoid ;
         gxTv_SdtTituloMovimento_Tipopagamentoid = sdt.gxTv_SdtTituloMovimento_Tipopagamentoid ;
         gxTv_SdtTituloMovimento_Tituloid = sdt.gxTv_SdtTituloMovimento_Tituloid ;
         gxTv_SdtTituloMovimento_Titulomovimentovalor = sdt.gxTv_SdtTituloMovimento_Titulomovimentovalor ;
         gxTv_SdtTituloMovimento_Titulomovimentotipo = sdt.gxTv_SdtTituloMovimento_Titulomovimentotipo ;
         gxTv_SdtTituloMovimento_Titulomovimentosoma = sdt.gxTv_SdtTituloMovimento_Titulomovimentosoma ;
         gxTv_SdtTituloMovimento_Titulomovimentodatacredito = sdt.gxTv_SdtTituloMovimento_Titulomovimentodatacredito ;
         gxTv_SdtTituloMovimento_Titulomovimentocreatedat = sdt.gxTv_SdtTituloMovimento_Titulomovimentocreatedat ;
         gxTv_SdtTituloMovimento_Titulomovimentoupdatedat = sdt.gxTv_SdtTituloMovimento_Titulomovimentoupdatedat ;
         gxTv_SdtTituloMovimento_Tipopagamentonome = sdt.gxTv_SdtTituloMovimento_Tipopagamentonome ;
         gxTv_SdtTituloMovimento_Titulomovimentoope = sdt.gxTv_SdtTituloMovimento_Titulomovimentoope ;
         gxTv_SdtTituloMovimento_Titulomovimentoconta = sdt.gxTv_SdtTituloMovimento_Titulomovimentoconta ;
         gxTv_SdtTituloMovimento_Mode = sdt.gxTv_SdtTituloMovimento_Mode ;
         gxTv_SdtTituloMovimento_Initialized = sdt.gxTv_SdtTituloMovimento_Initialized ;
         gxTv_SdtTituloMovimento_Titulomovimentoid_Z = sdt.gxTv_SdtTituloMovimento_Titulomovimentoid_Z ;
         gxTv_SdtTituloMovimento_Tipopagamentoid_Z = sdt.gxTv_SdtTituloMovimento_Tipopagamentoid_Z ;
         gxTv_SdtTituloMovimento_Tituloid_Z = sdt.gxTv_SdtTituloMovimento_Tituloid_Z ;
         gxTv_SdtTituloMovimento_Titulomovimentovalor_Z = sdt.gxTv_SdtTituloMovimento_Titulomovimentovalor_Z ;
         gxTv_SdtTituloMovimento_Titulomovimentotipo_Z = sdt.gxTv_SdtTituloMovimento_Titulomovimentotipo_Z ;
         gxTv_SdtTituloMovimento_Titulomovimentosoma_Z = sdt.gxTv_SdtTituloMovimento_Titulomovimentosoma_Z ;
         gxTv_SdtTituloMovimento_Titulomovimentodatacredito_Z = sdt.gxTv_SdtTituloMovimento_Titulomovimentodatacredito_Z ;
         gxTv_SdtTituloMovimento_Titulomovimentocreatedat_Z = sdt.gxTv_SdtTituloMovimento_Titulomovimentocreatedat_Z ;
         gxTv_SdtTituloMovimento_Titulomovimentoupdatedat_Z = sdt.gxTv_SdtTituloMovimento_Titulomovimentoupdatedat_Z ;
         gxTv_SdtTituloMovimento_Tipopagamentonome_Z = sdt.gxTv_SdtTituloMovimento_Tipopagamentonome_Z ;
         gxTv_SdtTituloMovimento_Titulomovimentoope_Z = sdt.gxTv_SdtTituloMovimento_Titulomovimentoope_Z ;
         gxTv_SdtTituloMovimento_Titulomovimentoconta_Z = sdt.gxTv_SdtTituloMovimento_Titulomovimentoconta_Z ;
         gxTv_SdtTituloMovimento_Tipopagamentoid_N = sdt.gxTv_SdtTituloMovimento_Tipopagamentoid_N ;
         gxTv_SdtTituloMovimento_Tituloid_N = sdt.gxTv_SdtTituloMovimento_Tituloid_N ;
         gxTv_SdtTituloMovimento_Titulomovimentovalor_N = sdt.gxTv_SdtTituloMovimento_Titulomovimentovalor_N ;
         gxTv_SdtTituloMovimento_Titulomovimentotipo_N = sdt.gxTv_SdtTituloMovimento_Titulomovimentotipo_N ;
         gxTv_SdtTituloMovimento_Titulomovimentosoma_N = sdt.gxTv_SdtTituloMovimento_Titulomovimentosoma_N ;
         gxTv_SdtTituloMovimento_Titulomovimentodatacredito_N = sdt.gxTv_SdtTituloMovimento_Titulomovimentodatacredito_N ;
         gxTv_SdtTituloMovimento_Titulomovimentocreatedat_N = sdt.gxTv_SdtTituloMovimento_Titulomovimentocreatedat_N ;
         gxTv_SdtTituloMovimento_Titulomovimentoupdatedat_N = sdt.gxTv_SdtTituloMovimento_Titulomovimentoupdatedat_N ;
         gxTv_SdtTituloMovimento_Titulomovimentoope_N = sdt.gxTv_SdtTituloMovimento_Titulomovimentoope_N ;
         gxTv_SdtTituloMovimento_Titulomovimentoconta_N = sdt.gxTv_SdtTituloMovimento_Titulomovimentoconta_N ;
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
         AddObjectProperty("TituloMovimentoId", gxTv_SdtTituloMovimento_Titulomovimentoid, false, includeNonInitialized);
         AddObjectProperty("TipoPagamentoId", gxTv_SdtTituloMovimento_Tipopagamentoid, false, includeNonInitialized);
         AddObjectProperty("TipoPagamentoId_N", gxTv_SdtTituloMovimento_Tipopagamentoid_N, false, includeNonInitialized);
         AddObjectProperty("TituloId", gxTv_SdtTituloMovimento_Tituloid, false, includeNonInitialized);
         AddObjectProperty("TituloId_N", gxTv_SdtTituloMovimento_Tituloid_N, false, includeNonInitialized);
         AddObjectProperty("TituloMovimentoValor", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTituloMovimento_Titulomovimentovalor, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("TituloMovimentoValor_N", gxTv_SdtTituloMovimento_Titulomovimentovalor_N, false, includeNonInitialized);
         AddObjectProperty("TituloMovimentoTipo", gxTv_SdtTituloMovimento_Titulomovimentotipo, false, includeNonInitialized);
         AddObjectProperty("TituloMovimentoTipo_N", gxTv_SdtTituloMovimento_Titulomovimentotipo_N, false, includeNonInitialized);
         AddObjectProperty("TituloMovimentoSoma", gxTv_SdtTituloMovimento_Titulomovimentosoma, false, includeNonInitialized);
         AddObjectProperty("TituloMovimentoSoma_N", gxTv_SdtTituloMovimento_Titulomovimentosoma_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtTituloMovimento_Titulomovimentodatacredito)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtTituloMovimento_Titulomovimentodatacredito)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtTituloMovimento_Titulomovimentodatacredito)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("TituloMovimentoDataCredito", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("TituloMovimentoDataCredito_N", gxTv_SdtTituloMovimento_Titulomovimentodatacredito_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtTituloMovimento_Titulomovimentocreatedat;
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
         AddObjectProperty("TituloMovimentoCreatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("TituloMovimentoCreatedAt_N", gxTv_SdtTituloMovimento_Titulomovimentocreatedat_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtTituloMovimento_Titulomovimentoupdatedat;
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
         AddObjectProperty("TituloMovimentoUpdatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("TituloMovimentoUpdatedAt_N", gxTv_SdtTituloMovimento_Titulomovimentoupdatedat_N, false, includeNonInitialized);
         AddObjectProperty("TipoPagamentoNome", gxTv_SdtTituloMovimento_Tipopagamentonome, false, includeNonInitialized);
         AddObjectProperty("TituloMovimentoOpe", gxTv_SdtTituloMovimento_Titulomovimentoope, false, includeNonInitialized);
         AddObjectProperty("TituloMovimentoOpe_N", gxTv_SdtTituloMovimento_Titulomovimentoope_N, false, includeNonInitialized);
         AddObjectProperty("TituloMovimentoConta", gxTv_SdtTituloMovimento_Titulomovimentoconta, false, includeNonInitialized);
         AddObjectProperty("TituloMovimentoConta_N", gxTv_SdtTituloMovimento_Titulomovimentoconta_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTituloMovimento_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTituloMovimento_Initialized, false, includeNonInitialized);
            AddObjectProperty("TituloMovimentoId_Z", gxTv_SdtTituloMovimento_Titulomovimentoid_Z, false, includeNonInitialized);
            AddObjectProperty("TipoPagamentoId_Z", gxTv_SdtTituloMovimento_Tipopagamentoid_Z, false, includeNonInitialized);
            AddObjectProperty("TituloId_Z", gxTv_SdtTituloMovimento_Tituloid_Z, false, includeNonInitialized);
            AddObjectProperty("TituloMovimentoValor_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTituloMovimento_Titulomovimentovalor_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("TituloMovimentoTipo_Z", gxTv_SdtTituloMovimento_Titulomovimentotipo_Z, false, includeNonInitialized);
            AddObjectProperty("TituloMovimentoSoma_Z", gxTv_SdtTituloMovimento_Titulomovimentosoma_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtTituloMovimento_Titulomovimentodatacredito_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtTituloMovimento_Titulomovimentodatacredito_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtTituloMovimento_Titulomovimentodatacredito_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("TituloMovimentoDataCredito_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtTituloMovimento_Titulomovimentocreatedat_Z;
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
            AddObjectProperty("TituloMovimentoCreatedAt_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtTituloMovimento_Titulomovimentoupdatedat_Z;
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
            AddObjectProperty("TituloMovimentoUpdatedAt_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("TipoPagamentoNome_Z", gxTv_SdtTituloMovimento_Tipopagamentonome_Z, false, includeNonInitialized);
            AddObjectProperty("TituloMovimentoOpe_Z", gxTv_SdtTituloMovimento_Titulomovimentoope_Z, false, includeNonInitialized);
            AddObjectProperty("TituloMovimentoConta_Z", gxTv_SdtTituloMovimento_Titulomovimentoconta_Z, false, includeNonInitialized);
            AddObjectProperty("TipoPagamentoId_N", gxTv_SdtTituloMovimento_Tipopagamentoid_N, false, includeNonInitialized);
            AddObjectProperty("TituloId_N", gxTv_SdtTituloMovimento_Tituloid_N, false, includeNonInitialized);
            AddObjectProperty("TituloMovimentoValor_N", gxTv_SdtTituloMovimento_Titulomovimentovalor_N, false, includeNonInitialized);
            AddObjectProperty("TituloMovimentoTipo_N", gxTv_SdtTituloMovimento_Titulomovimentotipo_N, false, includeNonInitialized);
            AddObjectProperty("TituloMovimentoSoma_N", gxTv_SdtTituloMovimento_Titulomovimentosoma_N, false, includeNonInitialized);
            AddObjectProperty("TituloMovimentoDataCredito_N", gxTv_SdtTituloMovimento_Titulomovimentodatacredito_N, false, includeNonInitialized);
            AddObjectProperty("TituloMovimentoCreatedAt_N", gxTv_SdtTituloMovimento_Titulomovimentocreatedat_N, false, includeNonInitialized);
            AddObjectProperty("TituloMovimentoUpdatedAt_N", gxTv_SdtTituloMovimento_Titulomovimentoupdatedat_N, false, includeNonInitialized);
            AddObjectProperty("TituloMovimentoOpe_N", gxTv_SdtTituloMovimento_Titulomovimentoope_N, false, includeNonInitialized);
            AddObjectProperty("TituloMovimentoConta_N", gxTv_SdtTituloMovimento_Titulomovimentoconta_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTituloMovimento sdt )
      {
         if ( sdt.IsDirty("TituloMovimentoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Titulomovimentoid = sdt.gxTv_SdtTituloMovimento_Titulomovimentoid ;
         }
         if ( sdt.IsDirty("TipoPagamentoId") )
         {
            gxTv_SdtTituloMovimento_Tipopagamentoid_N = (short)(sdt.gxTv_SdtTituloMovimento_Tipopagamentoid_N);
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Tipopagamentoid = sdt.gxTv_SdtTituloMovimento_Tipopagamentoid ;
         }
         if ( sdt.IsDirty("TituloId") )
         {
            gxTv_SdtTituloMovimento_Tituloid_N = (short)(sdt.gxTv_SdtTituloMovimento_Tituloid_N);
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Tituloid = sdt.gxTv_SdtTituloMovimento_Tituloid ;
         }
         if ( sdt.IsDirty("TituloMovimentoValor") )
         {
            gxTv_SdtTituloMovimento_Titulomovimentovalor_N = (short)(sdt.gxTv_SdtTituloMovimento_Titulomovimentovalor_N);
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Titulomovimentovalor = sdt.gxTv_SdtTituloMovimento_Titulomovimentovalor ;
         }
         if ( sdt.IsDirty("TituloMovimentoTipo") )
         {
            gxTv_SdtTituloMovimento_Titulomovimentotipo_N = (short)(sdt.gxTv_SdtTituloMovimento_Titulomovimentotipo_N);
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Titulomovimentotipo = sdt.gxTv_SdtTituloMovimento_Titulomovimentotipo ;
         }
         if ( sdt.IsDirty("TituloMovimentoSoma") )
         {
            gxTv_SdtTituloMovimento_Titulomovimentosoma_N = (short)(sdt.gxTv_SdtTituloMovimento_Titulomovimentosoma_N);
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Titulomovimentosoma = sdt.gxTv_SdtTituloMovimento_Titulomovimentosoma ;
         }
         if ( sdt.IsDirty("TituloMovimentoDataCredito") )
         {
            gxTv_SdtTituloMovimento_Titulomovimentodatacredito_N = (short)(sdt.gxTv_SdtTituloMovimento_Titulomovimentodatacredito_N);
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Titulomovimentodatacredito = sdt.gxTv_SdtTituloMovimento_Titulomovimentodatacredito ;
         }
         if ( sdt.IsDirty("TituloMovimentoCreatedAt") )
         {
            gxTv_SdtTituloMovimento_Titulomovimentocreatedat_N = (short)(sdt.gxTv_SdtTituloMovimento_Titulomovimentocreatedat_N);
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Titulomovimentocreatedat = sdt.gxTv_SdtTituloMovimento_Titulomovimentocreatedat ;
         }
         if ( sdt.IsDirty("TituloMovimentoUpdatedAt") )
         {
            gxTv_SdtTituloMovimento_Titulomovimentoupdatedat_N = (short)(sdt.gxTv_SdtTituloMovimento_Titulomovimentoupdatedat_N);
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Titulomovimentoupdatedat = sdt.gxTv_SdtTituloMovimento_Titulomovimentoupdatedat ;
         }
         if ( sdt.IsDirty("TipoPagamentoNome") )
         {
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Tipopagamentonome = sdt.gxTv_SdtTituloMovimento_Tipopagamentonome ;
         }
         if ( sdt.IsDirty("TituloMovimentoOpe") )
         {
            gxTv_SdtTituloMovimento_Titulomovimentoope_N = (short)(sdt.gxTv_SdtTituloMovimento_Titulomovimentoope_N);
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Titulomovimentoope = sdt.gxTv_SdtTituloMovimento_Titulomovimentoope ;
         }
         if ( sdt.IsDirty("TituloMovimentoConta") )
         {
            gxTv_SdtTituloMovimento_Titulomovimentoconta_N = (short)(sdt.gxTv_SdtTituloMovimento_Titulomovimentoconta_N);
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Titulomovimentoconta = sdt.gxTv_SdtTituloMovimento_Titulomovimentoconta ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "TituloMovimentoId" )]
      [  XmlElement( ElementName = "TituloMovimentoId"   )]
      public int gxTpr_Titulomovimentoid
      {
         get {
            return gxTv_SdtTituloMovimento_Titulomovimentoid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTituloMovimento_Titulomovimentoid != value )
            {
               gxTv_SdtTituloMovimento_Mode = "INS";
               this.gxTv_SdtTituloMovimento_Titulomovimentoid_Z_SetNull( );
               this.gxTv_SdtTituloMovimento_Tipopagamentoid_Z_SetNull( );
               this.gxTv_SdtTituloMovimento_Tituloid_Z_SetNull( );
               this.gxTv_SdtTituloMovimento_Titulomovimentovalor_Z_SetNull( );
               this.gxTv_SdtTituloMovimento_Titulomovimentotipo_Z_SetNull( );
               this.gxTv_SdtTituloMovimento_Titulomovimentosoma_Z_SetNull( );
               this.gxTv_SdtTituloMovimento_Titulomovimentodatacredito_Z_SetNull( );
               this.gxTv_SdtTituloMovimento_Titulomovimentocreatedat_Z_SetNull( );
               this.gxTv_SdtTituloMovimento_Titulomovimentoupdatedat_Z_SetNull( );
               this.gxTv_SdtTituloMovimento_Tipopagamentonome_Z_SetNull( );
               this.gxTv_SdtTituloMovimento_Titulomovimentoope_Z_SetNull( );
               this.gxTv_SdtTituloMovimento_Titulomovimentoconta_Z_SetNull( );
            }
            gxTv_SdtTituloMovimento_Titulomovimentoid = value;
            SetDirty("Titulomovimentoid");
         }

      }

      [  SoapElement( ElementName = "TipoPagamentoId" )]
      [  XmlElement( ElementName = "TipoPagamentoId"   )]
      public int gxTpr_Tipopagamentoid
      {
         get {
            return gxTv_SdtTituloMovimento_Tipopagamentoid ;
         }

         set {
            gxTv_SdtTituloMovimento_Tipopagamentoid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Tipopagamentoid = value;
            SetDirty("Tipopagamentoid");
         }

      }

      public void gxTv_SdtTituloMovimento_Tipopagamentoid_SetNull( )
      {
         gxTv_SdtTituloMovimento_Tipopagamentoid_N = 1;
         gxTv_SdtTituloMovimento_Tipopagamentoid = 0;
         SetDirty("Tipopagamentoid");
         return  ;
      }

      public bool gxTv_SdtTituloMovimento_Tipopagamentoid_IsNull( )
      {
         return (gxTv_SdtTituloMovimento_Tipopagamentoid_N==1) ;
      }

      [  SoapElement( ElementName = "TituloId" )]
      [  XmlElement( ElementName = "TituloId"   )]
      public int gxTpr_Tituloid
      {
         get {
            return gxTv_SdtTituloMovimento_Tituloid ;
         }

         set {
            gxTv_SdtTituloMovimento_Tituloid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Tituloid = value;
            SetDirty("Tituloid");
         }

      }

      public void gxTv_SdtTituloMovimento_Tituloid_SetNull( )
      {
         gxTv_SdtTituloMovimento_Tituloid_N = 1;
         gxTv_SdtTituloMovimento_Tituloid = 0;
         SetDirty("Tituloid");
         return  ;
      }

      public bool gxTv_SdtTituloMovimento_Tituloid_IsNull( )
      {
         return (gxTv_SdtTituloMovimento_Tituloid_N==1) ;
      }

      [  SoapElement( ElementName = "TituloMovimentoValor" )]
      [  XmlElement( ElementName = "TituloMovimentoValor"   )]
      public decimal gxTpr_Titulomovimentovalor
      {
         get {
            return gxTv_SdtTituloMovimento_Titulomovimentovalor ;
         }

         set {
            gxTv_SdtTituloMovimento_Titulomovimentovalor_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Titulomovimentovalor = value;
            SetDirty("Titulomovimentovalor");
         }

      }

      public void gxTv_SdtTituloMovimento_Titulomovimentovalor_SetNull( )
      {
         gxTv_SdtTituloMovimento_Titulomovimentovalor_N = 1;
         gxTv_SdtTituloMovimento_Titulomovimentovalor = 0;
         SetDirty("Titulomovimentovalor");
         return  ;
      }

      public bool gxTv_SdtTituloMovimento_Titulomovimentovalor_IsNull( )
      {
         return (gxTv_SdtTituloMovimento_Titulomovimentovalor_N==1) ;
      }

      [  SoapElement( ElementName = "TituloMovimentoTipo" )]
      [  XmlElement( ElementName = "TituloMovimentoTipo"   )]
      public string gxTpr_Titulomovimentotipo
      {
         get {
            return gxTv_SdtTituloMovimento_Titulomovimentotipo ;
         }

         set {
            gxTv_SdtTituloMovimento_Titulomovimentotipo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Titulomovimentotipo = value;
            SetDirty("Titulomovimentotipo");
         }

      }

      public void gxTv_SdtTituloMovimento_Titulomovimentotipo_SetNull( )
      {
         gxTv_SdtTituloMovimento_Titulomovimentotipo_N = 1;
         gxTv_SdtTituloMovimento_Titulomovimentotipo = "";
         SetDirty("Titulomovimentotipo");
         return  ;
      }

      public bool gxTv_SdtTituloMovimento_Titulomovimentotipo_IsNull( )
      {
         return (gxTv_SdtTituloMovimento_Titulomovimentotipo_N==1) ;
      }

      [  SoapElement( ElementName = "TituloMovimentoSoma" )]
      [  XmlElement( ElementName = "TituloMovimentoSoma"   )]
      public bool gxTpr_Titulomovimentosoma
      {
         get {
            return gxTv_SdtTituloMovimento_Titulomovimentosoma ;
         }

         set {
            gxTv_SdtTituloMovimento_Titulomovimentosoma_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Titulomovimentosoma = value;
            SetDirty("Titulomovimentosoma");
         }

      }

      public void gxTv_SdtTituloMovimento_Titulomovimentosoma_SetNull( )
      {
         gxTv_SdtTituloMovimento_Titulomovimentosoma_N = 1;
         gxTv_SdtTituloMovimento_Titulomovimentosoma = false;
         SetDirty("Titulomovimentosoma");
         return  ;
      }

      public bool gxTv_SdtTituloMovimento_Titulomovimentosoma_IsNull( )
      {
         return (gxTv_SdtTituloMovimento_Titulomovimentosoma_N==1) ;
      }

      [  SoapElement( ElementName = "TituloMovimentoDataCredito" )]
      [  XmlElement( ElementName = "TituloMovimentoDataCredito"  , IsNullable=true )]
      public string gxTpr_Titulomovimentodatacredito_Nullable
      {
         get {
            if ( gxTv_SdtTituloMovimento_Titulomovimentodatacredito == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtTituloMovimento_Titulomovimentodatacredito).value ;
         }

         set {
            gxTv_SdtTituloMovimento_Titulomovimentodatacredito_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtTituloMovimento_Titulomovimentodatacredito = DateTime.MinValue;
            else
               gxTv_SdtTituloMovimento_Titulomovimentodatacredito = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Titulomovimentodatacredito
      {
         get {
            return gxTv_SdtTituloMovimento_Titulomovimentodatacredito ;
         }

         set {
            gxTv_SdtTituloMovimento_Titulomovimentodatacredito_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Titulomovimentodatacredito = value;
            SetDirty("Titulomovimentodatacredito");
         }

      }

      public void gxTv_SdtTituloMovimento_Titulomovimentodatacredito_SetNull( )
      {
         gxTv_SdtTituloMovimento_Titulomovimentodatacredito_N = 1;
         gxTv_SdtTituloMovimento_Titulomovimentodatacredito = (DateTime)(DateTime.MinValue);
         SetDirty("Titulomovimentodatacredito");
         return  ;
      }

      public bool gxTv_SdtTituloMovimento_Titulomovimentodatacredito_IsNull( )
      {
         return (gxTv_SdtTituloMovimento_Titulomovimentodatacredito_N==1) ;
      }

      [  SoapElement( ElementName = "TituloMovimentoCreatedAt" )]
      [  XmlElement( ElementName = "TituloMovimentoCreatedAt"  , IsNullable=true )]
      public string gxTpr_Titulomovimentocreatedat_Nullable
      {
         get {
            if ( gxTv_SdtTituloMovimento_Titulomovimentocreatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTituloMovimento_Titulomovimentocreatedat).value ;
         }

         set {
            gxTv_SdtTituloMovimento_Titulomovimentocreatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTituloMovimento_Titulomovimentocreatedat = DateTime.MinValue;
            else
               gxTv_SdtTituloMovimento_Titulomovimentocreatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Titulomovimentocreatedat
      {
         get {
            return gxTv_SdtTituloMovimento_Titulomovimentocreatedat ;
         }

         set {
            gxTv_SdtTituloMovimento_Titulomovimentocreatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Titulomovimentocreatedat = value;
            SetDirty("Titulomovimentocreatedat");
         }

      }

      public void gxTv_SdtTituloMovimento_Titulomovimentocreatedat_SetNull( )
      {
         gxTv_SdtTituloMovimento_Titulomovimentocreatedat_N = 1;
         gxTv_SdtTituloMovimento_Titulomovimentocreatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Titulomovimentocreatedat");
         return  ;
      }

      public bool gxTv_SdtTituloMovimento_Titulomovimentocreatedat_IsNull( )
      {
         return (gxTv_SdtTituloMovimento_Titulomovimentocreatedat_N==1) ;
      }

      [  SoapElement( ElementName = "TituloMovimentoUpdatedAt" )]
      [  XmlElement( ElementName = "TituloMovimentoUpdatedAt"  , IsNullable=true )]
      public string gxTpr_Titulomovimentoupdatedat_Nullable
      {
         get {
            if ( gxTv_SdtTituloMovimento_Titulomovimentoupdatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTituloMovimento_Titulomovimentoupdatedat).value ;
         }

         set {
            gxTv_SdtTituloMovimento_Titulomovimentoupdatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTituloMovimento_Titulomovimentoupdatedat = DateTime.MinValue;
            else
               gxTv_SdtTituloMovimento_Titulomovimentoupdatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Titulomovimentoupdatedat
      {
         get {
            return gxTv_SdtTituloMovimento_Titulomovimentoupdatedat ;
         }

         set {
            gxTv_SdtTituloMovimento_Titulomovimentoupdatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Titulomovimentoupdatedat = value;
            SetDirty("Titulomovimentoupdatedat");
         }

      }

      public void gxTv_SdtTituloMovimento_Titulomovimentoupdatedat_SetNull( )
      {
         gxTv_SdtTituloMovimento_Titulomovimentoupdatedat_N = 1;
         gxTv_SdtTituloMovimento_Titulomovimentoupdatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Titulomovimentoupdatedat");
         return  ;
      }

      public bool gxTv_SdtTituloMovimento_Titulomovimentoupdatedat_IsNull( )
      {
         return (gxTv_SdtTituloMovimento_Titulomovimentoupdatedat_N==1) ;
      }

      [  SoapElement( ElementName = "TipoPagamentoNome" )]
      [  XmlElement( ElementName = "TipoPagamentoNome"   )]
      public string gxTpr_Tipopagamentonome
      {
         get {
            return gxTv_SdtTituloMovimento_Tipopagamentonome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Tipopagamentonome = value;
            SetDirty("Tipopagamentonome");
         }

      }

      [  SoapElement( ElementName = "TituloMovimentoOpe" )]
      [  XmlElement( ElementName = "TituloMovimentoOpe"   )]
      public string gxTpr_Titulomovimentoope
      {
         get {
            return gxTv_SdtTituloMovimento_Titulomovimentoope ;
         }

         set {
            gxTv_SdtTituloMovimento_Titulomovimentoope_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Titulomovimentoope = value;
            SetDirty("Titulomovimentoope");
         }

      }

      public void gxTv_SdtTituloMovimento_Titulomovimentoope_SetNull( )
      {
         gxTv_SdtTituloMovimento_Titulomovimentoope_N = 1;
         gxTv_SdtTituloMovimento_Titulomovimentoope = "";
         SetDirty("Titulomovimentoope");
         return  ;
      }

      public bool gxTv_SdtTituloMovimento_Titulomovimentoope_IsNull( )
      {
         return (gxTv_SdtTituloMovimento_Titulomovimentoope_N==1) ;
      }

      [  SoapElement( ElementName = "TituloMovimentoConta" )]
      [  XmlElement( ElementName = "TituloMovimentoConta"   )]
      public int gxTpr_Titulomovimentoconta
      {
         get {
            return gxTv_SdtTituloMovimento_Titulomovimentoconta ;
         }

         set {
            gxTv_SdtTituloMovimento_Titulomovimentoconta_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Titulomovimentoconta = value;
            SetDirty("Titulomovimentoconta");
         }

      }

      public void gxTv_SdtTituloMovimento_Titulomovimentoconta_SetNull( )
      {
         gxTv_SdtTituloMovimento_Titulomovimentoconta_N = 1;
         gxTv_SdtTituloMovimento_Titulomovimentoconta = 0;
         SetDirty("Titulomovimentoconta");
         return  ;
      }

      public bool gxTv_SdtTituloMovimento_Titulomovimentoconta_IsNull( )
      {
         return (gxTv_SdtTituloMovimento_Titulomovimentoconta_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTituloMovimento_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTituloMovimento_Mode_SetNull( )
      {
         gxTv_SdtTituloMovimento_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTituloMovimento_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTituloMovimento_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTituloMovimento_Initialized_SetNull( )
      {
         gxTv_SdtTituloMovimento_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTituloMovimento_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloMovimentoId_Z" )]
      [  XmlElement( ElementName = "TituloMovimentoId_Z"   )]
      public int gxTpr_Titulomovimentoid_Z
      {
         get {
            return gxTv_SdtTituloMovimento_Titulomovimentoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Titulomovimentoid_Z = value;
            SetDirty("Titulomovimentoid_Z");
         }

      }

      public void gxTv_SdtTituloMovimento_Titulomovimentoid_Z_SetNull( )
      {
         gxTv_SdtTituloMovimento_Titulomovimentoid_Z = 0;
         SetDirty("Titulomovimentoid_Z");
         return  ;
      }

      public bool gxTv_SdtTituloMovimento_Titulomovimentoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoPagamentoId_Z" )]
      [  XmlElement( ElementName = "TipoPagamentoId_Z"   )]
      public int gxTpr_Tipopagamentoid_Z
      {
         get {
            return gxTv_SdtTituloMovimento_Tipopagamentoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Tipopagamentoid_Z = value;
            SetDirty("Tipopagamentoid_Z");
         }

      }

      public void gxTv_SdtTituloMovimento_Tipopagamentoid_Z_SetNull( )
      {
         gxTv_SdtTituloMovimento_Tipopagamentoid_Z = 0;
         SetDirty("Tipopagamentoid_Z");
         return  ;
      }

      public bool gxTv_SdtTituloMovimento_Tipopagamentoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloId_Z" )]
      [  XmlElement( ElementName = "TituloId_Z"   )]
      public int gxTpr_Tituloid_Z
      {
         get {
            return gxTv_SdtTituloMovimento_Tituloid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Tituloid_Z = value;
            SetDirty("Tituloid_Z");
         }

      }

      public void gxTv_SdtTituloMovimento_Tituloid_Z_SetNull( )
      {
         gxTv_SdtTituloMovimento_Tituloid_Z = 0;
         SetDirty("Tituloid_Z");
         return  ;
      }

      public bool gxTv_SdtTituloMovimento_Tituloid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloMovimentoValor_Z" )]
      [  XmlElement( ElementName = "TituloMovimentoValor_Z"   )]
      public decimal gxTpr_Titulomovimentovalor_Z
      {
         get {
            return gxTv_SdtTituloMovimento_Titulomovimentovalor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Titulomovimentovalor_Z = value;
            SetDirty("Titulomovimentovalor_Z");
         }

      }

      public void gxTv_SdtTituloMovimento_Titulomovimentovalor_Z_SetNull( )
      {
         gxTv_SdtTituloMovimento_Titulomovimentovalor_Z = 0;
         SetDirty("Titulomovimentovalor_Z");
         return  ;
      }

      public bool gxTv_SdtTituloMovimento_Titulomovimentovalor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloMovimentoTipo_Z" )]
      [  XmlElement( ElementName = "TituloMovimentoTipo_Z"   )]
      public string gxTpr_Titulomovimentotipo_Z
      {
         get {
            return gxTv_SdtTituloMovimento_Titulomovimentotipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Titulomovimentotipo_Z = value;
            SetDirty("Titulomovimentotipo_Z");
         }

      }

      public void gxTv_SdtTituloMovimento_Titulomovimentotipo_Z_SetNull( )
      {
         gxTv_SdtTituloMovimento_Titulomovimentotipo_Z = "";
         SetDirty("Titulomovimentotipo_Z");
         return  ;
      }

      public bool gxTv_SdtTituloMovimento_Titulomovimentotipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloMovimentoSoma_Z" )]
      [  XmlElement( ElementName = "TituloMovimentoSoma_Z"   )]
      public bool gxTpr_Titulomovimentosoma_Z
      {
         get {
            return gxTv_SdtTituloMovimento_Titulomovimentosoma_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Titulomovimentosoma_Z = value;
            SetDirty("Titulomovimentosoma_Z");
         }

      }

      public void gxTv_SdtTituloMovimento_Titulomovimentosoma_Z_SetNull( )
      {
         gxTv_SdtTituloMovimento_Titulomovimentosoma_Z = false;
         SetDirty("Titulomovimentosoma_Z");
         return  ;
      }

      public bool gxTv_SdtTituloMovimento_Titulomovimentosoma_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloMovimentoDataCredito_Z" )]
      [  XmlElement( ElementName = "TituloMovimentoDataCredito_Z"  , IsNullable=true )]
      public string gxTpr_Titulomovimentodatacredito_Z_Nullable
      {
         get {
            if ( gxTv_SdtTituloMovimento_Titulomovimentodatacredito_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtTituloMovimento_Titulomovimentodatacredito_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtTituloMovimento_Titulomovimentodatacredito_Z = DateTime.MinValue;
            else
               gxTv_SdtTituloMovimento_Titulomovimentodatacredito_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Titulomovimentodatacredito_Z
      {
         get {
            return gxTv_SdtTituloMovimento_Titulomovimentodatacredito_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Titulomovimentodatacredito_Z = value;
            SetDirty("Titulomovimentodatacredito_Z");
         }

      }

      public void gxTv_SdtTituloMovimento_Titulomovimentodatacredito_Z_SetNull( )
      {
         gxTv_SdtTituloMovimento_Titulomovimentodatacredito_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Titulomovimentodatacredito_Z");
         return  ;
      }

      public bool gxTv_SdtTituloMovimento_Titulomovimentodatacredito_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloMovimentoCreatedAt_Z" )]
      [  XmlElement( ElementName = "TituloMovimentoCreatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Titulomovimentocreatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtTituloMovimento_Titulomovimentocreatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTituloMovimento_Titulomovimentocreatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTituloMovimento_Titulomovimentocreatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtTituloMovimento_Titulomovimentocreatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Titulomovimentocreatedat_Z
      {
         get {
            return gxTv_SdtTituloMovimento_Titulomovimentocreatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Titulomovimentocreatedat_Z = value;
            SetDirty("Titulomovimentocreatedat_Z");
         }

      }

      public void gxTv_SdtTituloMovimento_Titulomovimentocreatedat_Z_SetNull( )
      {
         gxTv_SdtTituloMovimento_Titulomovimentocreatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Titulomovimentocreatedat_Z");
         return  ;
      }

      public bool gxTv_SdtTituloMovimento_Titulomovimentocreatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloMovimentoUpdatedAt_Z" )]
      [  XmlElement( ElementName = "TituloMovimentoUpdatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Titulomovimentoupdatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtTituloMovimento_Titulomovimentoupdatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTituloMovimento_Titulomovimentoupdatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTituloMovimento_Titulomovimentoupdatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtTituloMovimento_Titulomovimentoupdatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Titulomovimentoupdatedat_Z
      {
         get {
            return gxTv_SdtTituloMovimento_Titulomovimentoupdatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Titulomovimentoupdatedat_Z = value;
            SetDirty("Titulomovimentoupdatedat_Z");
         }

      }

      public void gxTv_SdtTituloMovimento_Titulomovimentoupdatedat_Z_SetNull( )
      {
         gxTv_SdtTituloMovimento_Titulomovimentoupdatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Titulomovimentoupdatedat_Z");
         return  ;
      }

      public bool gxTv_SdtTituloMovimento_Titulomovimentoupdatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoPagamentoNome_Z" )]
      [  XmlElement( ElementName = "TipoPagamentoNome_Z"   )]
      public string gxTpr_Tipopagamentonome_Z
      {
         get {
            return gxTv_SdtTituloMovimento_Tipopagamentonome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Tipopagamentonome_Z = value;
            SetDirty("Tipopagamentonome_Z");
         }

      }

      public void gxTv_SdtTituloMovimento_Tipopagamentonome_Z_SetNull( )
      {
         gxTv_SdtTituloMovimento_Tipopagamentonome_Z = "";
         SetDirty("Tipopagamentonome_Z");
         return  ;
      }

      public bool gxTv_SdtTituloMovimento_Tipopagamentonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloMovimentoOpe_Z" )]
      [  XmlElement( ElementName = "TituloMovimentoOpe_Z"   )]
      public string gxTpr_Titulomovimentoope_Z
      {
         get {
            return gxTv_SdtTituloMovimento_Titulomovimentoope_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Titulomovimentoope_Z = value;
            SetDirty("Titulomovimentoope_Z");
         }

      }

      public void gxTv_SdtTituloMovimento_Titulomovimentoope_Z_SetNull( )
      {
         gxTv_SdtTituloMovimento_Titulomovimentoope_Z = "";
         SetDirty("Titulomovimentoope_Z");
         return  ;
      }

      public bool gxTv_SdtTituloMovimento_Titulomovimentoope_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloMovimentoConta_Z" )]
      [  XmlElement( ElementName = "TituloMovimentoConta_Z"   )]
      public int gxTpr_Titulomovimentoconta_Z
      {
         get {
            return gxTv_SdtTituloMovimento_Titulomovimentoconta_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Titulomovimentoconta_Z = value;
            SetDirty("Titulomovimentoconta_Z");
         }

      }

      public void gxTv_SdtTituloMovimento_Titulomovimentoconta_Z_SetNull( )
      {
         gxTv_SdtTituloMovimento_Titulomovimentoconta_Z = 0;
         SetDirty("Titulomovimentoconta_Z");
         return  ;
      }

      public bool gxTv_SdtTituloMovimento_Titulomovimentoconta_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoPagamentoId_N" )]
      [  XmlElement( ElementName = "TipoPagamentoId_N"   )]
      public short gxTpr_Tipopagamentoid_N
      {
         get {
            return gxTv_SdtTituloMovimento_Tipopagamentoid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Tipopagamentoid_N = value;
            SetDirty("Tipopagamentoid_N");
         }

      }

      public void gxTv_SdtTituloMovimento_Tipopagamentoid_N_SetNull( )
      {
         gxTv_SdtTituloMovimento_Tipopagamentoid_N = 0;
         SetDirty("Tipopagamentoid_N");
         return  ;
      }

      public bool gxTv_SdtTituloMovimento_Tipopagamentoid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloId_N" )]
      [  XmlElement( ElementName = "TituloId_N"   )]
      public short gxTpr_Tituloid_N
      {
         get {
            return gxTv_SdtTituloMovimento_Tituloid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Tituloid_N = value;
            SetDirty("Tituloid_N");
         }

      }

      public void gxTv_SdtTituloMovimento_Tituloid_N_SetNull( )
      {
         gxTv_SdtTituloMovimento_Tituloid_N = 0;
         SetDirty("Tituloid_N");
         return  ;
      }

      public bool gxTv_SdtTituloMovimento_Tituloid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloMovimentoValor_N" )]
      [  XmlElement( ElementName = "TituloMovimentoValor_N"   )]
      public short gxTpr_Titulomovimentovalor_N
      {
         get {
            return gxTv_SdtTituloMovimento_Titulomovimentovalor_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Titulomovimentovalor_N = value;
            SetDirty("Titulomovimentovalor_N");
         }

      }

      public void gxTv_SdtTituloMovimento_Titulomovimentovalor_N_SetNull( )
      {
         gxTv_SdtTituloMovimento_Titulomovimentovalor_N = 0;
         SetDirty("Titulomovimentovalor_N");
         return  ;
      }

      public bool gxTv_SdtTituloMovimento_Titulomovimentovalor_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloMovimentoTipo_N" )]
      [  XmlElement( ElementName = "TituloMovimentoTipo_N"   )]
      public short gxTpr_Titulomovimentotipo_N
      {
         get {
            return gxTv_SdtTituloMovimento_Titulomovimentotipo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Titulomovimentotipo_N = value;
            SetDirty("Titulomovimentotipo_N");
         }

      }

      public void gxTv_SdtTituloMovimento_Titulomovimentotipo_N_SetNull( )
      {
         gxTv_SdtTituloMovimento_Titulomovimentotipo_N = 0;
         SetDirty("Titulomovimentotipo_N");
         return  ;
      }

      public bool gxTv_SdtTituloMovimento_Titulomovimentotipo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloMovimentoSoma_N" )]
      [  XmlElement( ElementName = "TituloMovimentoSoma_N"   )]
      public short gxTpr_Titulomovimentosoma_N
      {
         get {
            return gxTv_SdtTituloMovimento_Titulomovimentosoma_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Titulomovimentosoma_N = value;
            SetDirty("Titulomovimentosoma_N");
         }

      }

      public void gxTv_SdtTituloMovimento_Titulomovimentosoma_N_SetNull( )
      {
         gxTv_SdtTituloMovimento_Titulomovimentosoma_N = 0;
         SetDirty("Titulomovimentosoma_N");
         return  ;
      }

      public bool gxTv_SdtTituloMovimento_Titulomovimentosoma_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloMovimentoDataCredito_N" )]
      [  XmlElement( ElementName = "TituloMovimentoDataCredito_N"   )]
      public short gxTpr_Titulomovimentodatacredito_N
      {
         get {
            return gxTv_SdtTituloMovimento_Titulomovimentodatacredito_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Titulomovimentodatacredito_N = value;
            SetDirty("Titulomovimentodatacredito_N");
         }

      }

      public void gxTv_SdtTituloMovimento_Titulomovimentodatacredito_N_SetNull( )
      {
         gxTv_SdtTituloMovimento_Titulomovimentodatacredito_N = 0;
         SetDirty("Titulomovimentodatacredito_N");
         return  ;
      }

      public bool gxTv_SdtTituloMovimento_Titulomovimentodatacredito_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloMovimentoCreatedAt_N" )]
      [  XmlElement( ElementName = "TituloMovimentoCreatedAt_N"   )]
      public short gxTpr_Titulomovimentocreatedat_N
      {
         get {
            return gxTv_SdtTituloMovimento_Titulomovimentocreatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Titulomovimentocreatedat_N = value;
            SetDirty("Titulomovimentocreatedat_N");
         }

      }

      public void gxTv_SdtTituloMovimento_Titulomovimentocreatedat_N_SetNull( )
      {
         gxTv_SdtTituloMovimento_Titulomovimentocreatedat_N = 0;
         SetDirty("Titulomovimentocreatedat_N");
         return  ;
      }

      public bool gxTv_SdtTituloMovimento_Titulomovimentocreatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloMovimentoUpdatedAt_N" )]
      [  XmlElement( ElementName = "TituloMovimentoUpdatedAt_N"   )]
      public short gxTpr_Titulomovimentoupdatedat_N
      {
         get {
            return gxTv_SdtTituloMovimento_Titulomovimentoupdatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Titulomovimentoupdatedat_N = value;
            SetDirty("Titulomovimentoupdatedat_N");
         }

      }

      public void gxTv_SdtTituloMovimento_Titulomovimentoupdatedat_N_SetNull( )
      {
         gxTv_SdtTituloMovimento_Titulomovimentoupdatedat_N = 0;
         SetDirty("Titulomovimentoupdatedat_N");
         return  ;
      }

      public bool gxTv_SdtTituloMovimento_Titulomovimentoupdatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloMovimentoOpe_N" )]
      [  XmlElement( ElementName = "TituloMovimentoOpe_N"   )]
      public short gxTpr_Titulomovimentoope_N
      {
         get {
            return gxTv_SdtTituloMovimento_Titulomovimentoope_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Titulomovimentoope_N = value;
            SetDirty("Titulomovimentoope_N");
         }

      }

      public void gxTv_SdtTituloMovimento_Titulomovimentoope_N_SetNull( )
      {
         gxTv_SdtTituloMovimento_Titulomovimentoope_N = 0;
         SetDirty("Titulomovimentoope_N");
         return  ;
      }

      public bool gxTv_SdtTituloMovimento_Titulomovimentoope_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TituloMovimentoConta_N" )]
      [  XmlElement( ElementName = "TituloMovimentoConta_N"   )]
      public short gxTpr_Titulomovimentoconta_N
      {
         get {
            return gxTv_SdtTituloMovimento_Titulomovimentoconta_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTituloMovimento_Titulomovimentoconta_N = value;
            SetDirty("Titulomovimentoconta_N");
         }

      }

      public void gxTv_SdtTituloMovimento_Titulomovimentoconta_N_SetNull( )
      {
         gxTv_SdtTituloMovimento_Titulomovimentoconta_N = 0;
         SetDirty("Titulomovimentoconta_N");
         return  ;
      }

      public bool gxTv_SdtTituloMovimento_Titulomovimentoconta_N_IsNull( )
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
         gxTv_SdtTituloMovimento_Titulomovimentotipo = "";
         gxTv_SdtTituloMovimento_Titulomovimentodatacredito = DateTime.MinValue;
         gxTv_SdtTituloMovimento_Titulomovimentocreatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtTituloMovimento_Titulomovimentoupdatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtTituloMovimento_Tipopagamentonome = "";
         gxTv_SdtTituloMovimento_Titulomovimentoope = "";
         gxTv_SdtTituloMovimento_Mode = "";
         gxTv_SdtTituloMovimento_Titulomovimentotipo_Z = "";
         gxTv_SdtTituloMovimento_Titulomovimentodatacredito_Z = DateTime.MinValue;
         gxTv_SdtTituloMovimento_Titulomovimentocreatedat_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtTituloMovimento_Titulomovimentoupdatedat_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtTituloMovimento_Tipopagamentonome_Z = "";
         gxTv_SdtTituloMovimento_Titulomovimentoope_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "titulomovimento", "GeneXus.Programs.titulomovimento_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTituloMovimento_Initialized ;
      private short gxTv_SdtTituloMovimento_Tipopagamentoid_N ;
      private short gxTv_SdtTituloMovimento_Tituloid_N ;
      private short gxTv_SdtTituloMovimento_Titulomovimentovalor_N ;
      private short gxTv_SdtTituloMovimento_Titulomovimentotipo_N ;
      private short gxTv_SdtTituloMovimento_Titulomovimentosoma_N ;
      private short gxTv_SdtTituloMovimento_Titulomovimentodatacredito_N ;
      private short gxTv_SdtTituloMovimento_Titulomovimentocreatedat_N ;
      private short gxTv_SdtTituloMovimento_Titulomovimentoupdatedat_N ;
      private short gxTv_SdtTituloMovimento_Titulomovimentoope_N ;
      private short gxTv_SdtTituloMovimento_Titulomovimentoconta_N ;
      private int gxTv_SdtTituloMovimento_Titulomovimentoid ;
      private int gxTv_SdtTituloMovimento_Tipopagamentoid ;
      private int gxTv_SdtTituloMovimento_Tituloid ;
      private int gxTv_SdtTituloMovimento_Titulomovimentoconta ;
      private int gxTv_SdtTituloMovimento_Titulomovimentoid_Z ;
      private int gxTv_SdtTituloMovimento_Tipopagamentoid_Z ;
      private int gxTv_SdtTituloMovimento_Tituloid_Z ;
      private int gxTv_SdtTituloMovimento_Titulomovimentoconta_Z ;
      private decimal gxTv_SdtTituloMovimento_Titulomovimentovalor ;
      private decimal gxTv_SdtTituloMovimento_Titulomovimentovalor_Z ;
      private string gxTv_SdtTituloMovimento_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtTituloMovimento_Titulomovimentocreatedat ;
      private DateTime gxTv_SdtTituloMovimento_Titulomovimentoupdatedat ;
      private DateTime gxTv_SdtTituloMovimento_Titulomovimentocreatedat_Z ;
      private DateTime gxTv_SdtTituloMovimento_Titulomovimentoupdatedat_Z ;
      private DateTime datetime_STZ ;
      private DateTime gxTv_SdtTituloMovimento_Titulomovimentodatacredito ;
      private DateTime gxTv_SdtTituloMovimento_Titulomovimentodatacredito_Z ;
      private bool gxTv_SdtTituloMovimento_Titulomovimentosoma ;
      private bool gxTv_SdtTituloMovimento_Titulomovimentosoma_Z ;
      private string gxTv_SdtTituloMovimento_Titulomovimentotipo ;
      private string gxTv_SdtTituloMovimento_Tipopagamentonome ;
      private string gxTv_SdtTituloMovimento_Titulomovimentoope ;
      private string gxTv_SdtTituloMovimento_Titulomovimentotipo_Z ;
      private string gxTv_SdtTituloMovimento_Tipopagamentonome_Z ;
      private string gxTv_SdtTituloMovimento_Titulomovimentoope_Z ;
   }

   [DataContract(Name = @"TituloMovimento", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtTituloMovimento_RESTInterface : GxGenericCollectionItem<SdtTituloMovimento>
   {
      public SdtTituloMovimento_RESTInterface( ) : base()
      {
      }

      public SdtTituloMovimento_RESTInterface( SdtTituloMovimento psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TituloMovimentoId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Titulomovimentoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Titulomovimentoid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Titulomovimentoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "TipoPagamentoId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Tipopagamentoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Tipopagamentoid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Tipopagamentoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
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

      [DataMember( Name = "TituloMovimentoValor" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Titulomovimentovalor
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Titulomovimentovalor, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Titulomovimentovalor = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "TituloMovimentoTipo" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Titulomovimentotipo
      {
         get {
            return sdt.gxTpr_Titulomovimentotipo ;
         }

         set {
            sdt.gxTpr_Titulomovimentotipo = value;
         }

      }

      [DataMember( Name = "TituloMovimentoSoma" , Order = 5 )]
      [GxSeudo()]
      public bool gxTpr_Titulomovimentosoma
      {
         get {
            return sdt.gxTpr_Titulomovimentosoma ;
         }

         set {
            sdt.gxTpr_Titulomovimentosoma = value;
         }

      }

      [DataMember( Name = "TituloMovimentoDataCredito" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Titulomovimentodatacredito
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Titulomovimentodatacredito) ;
         }

         set {
            sdt.gxTpr_Titulomovimentodatacredito = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "TituloMovimentoCreatedAt" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Titulomovimentocreatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Titulomovimentocreatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Titulomovimentocreatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "TituloMovimentoUpdatedAt" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Titulomovimentoupdatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Titulomovimentoupdatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Titulomovimentoupdatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "TipoPagamentoNome" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Tipopagamentonome
      {
         get {
            return sdt.gxTpr_Tipopagamentonome ;
         }

         set {
            sdt.gxTpr_Tipopagamentonome = value;
         }

      }

      [DataMember( Name = "TituloMovimentoOpe" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Titulomovimentoope
      {
         get {
            return sdt.gxTpr_Titulomovimentoope ;
         }

         set {
            sdt.gxTpr_Titulomovimentoope = value;
         }

      }

      [DataMember( Name = "TituloMovimentoConta" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Titulomovimentoconta
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Titulomovimentoconta), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Titulomovimentoconta = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      public SdtTituloMovimento sdt
      {
         get {
            return (SdtTituloMovimento)Sdt ;
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
            sdt = new SdtTituloMovimento() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 12 )]
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

   [DataContract(Name = @"TituloMovimento", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtTituloMovimento_RESTLInterface : GxGenericCollectionItem<SdtTituloMovimento>
   {
      public SdtTituloMovimento_RESTLInterface( ) : base()
      {
      }

      public SdtTituloMovimento_RESTLInterface( SdtTituloMovimento psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TituloMovimentoValor" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Titulomovimentovalor
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Titulomovimentovalor, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Titulomovimentovalor = NumberUtil.Val( value, ".");
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

      public SdtTituloMovimento sdt
      {
         get {
            return (SdtTituloMovimento)Sdt ;
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
            sdt = new SdtTituloMovimento() ;
         }
      }

   }

}
