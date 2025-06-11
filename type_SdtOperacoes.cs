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
   [XmlRoot(ElementName = "Operacoes" )]
   [XmlType(TypeName =  "Operacoes" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtOperacoes : GxSilentTrnSdt
   {
      public SdtOperacoes( )
      {
      }

      public SdtOperacoes( IGxContext context )
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

      public void Load( int AV1010OperacoesId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV1010OperacoesId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"OperacoesId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Operacoes");
         metadata.Set("BT", "Operacoes");
         metadata.Set("PK", "[ \"OperacoesId\" ]");
         metadata.Set("PKAssigned", "[ \"OperacoesId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ClienteId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ContratoId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Operacoesid_Z");
         state.Add("gxTpr_Clienteid_Z");
         state.Add("gxTpr_Clienterazaosocial_Z");
         state.Add("gxTpr_Operacoesdata_Z_Nullable");
         state.Add("gxTpr_Operacoesstatus_Z");
         state.Add("gxTpr_Operacoestaxaefetiva_Z");
         state.Add("gxTpr_Contratoid_Z");
         state.Add("gxTpr_Operacoestaxamora_Z");
         state.Add("gxTpr_Operacoesfator_Z");
         state.Add("gxTpr_Operacoestipotarifa_Z");
         state.Add("gxTpr_Operacoestarifa_Z");
         state.Add("gxTpr_Contratonome_Z");
         state.Add("gxTpr_Operacoescreatedat_Z_Nullable");
         state.Add("gxTpr_Operacoesupdateat_Z_Nullable");
         state.Add("gxTpr_Operacoesid_N");
         state.Add("gxTpr_Clienteid_N");
         state.Add("gxTpr_Clienterazaosocial_N");
         state.Add("gxTpr_Operacoesdata_N");
         state.Add("gxTpr_Operacoesstatus_N");
         state.Add("gxTpr_Operacoestaxaefetiva_N");
         state.Add("gxTpr_Contratoid_N");
         state.Add("gxTpr_Operacoestaxamora_N");
         state.Add("gxTpr_Operacoesfator_N");
         state.Add("gxTpr_Operacoestipotarifa_N");
         state.Add("gxTpr_Operacoestarifa_N");
         state.Add("gxTpr_Contratonome_N");
         state.Add("gxTpr_Operacoescreatedat_N");
         state.Add("gxTpr_Operacoesupdateat_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtOperacoes sdt;
         sdt = (SdtOperacoes)(source);
         gxTv_SdtOperacoes_Operacoesid = sdt.gxTv_SdtOperacoes_Operacoesid ;
         gxTv_SdtOperacoes_Clienteid = sdt.gxTv_SdtOperacoes_Clienteid ;
         gxTv_SdtOperacoes_Clienterazaosocial = sdt.gxTv_SdtOperacoes_Clienterazaosocial ;
         gxTv_SdtOperacoes_Operacoesdata = sdt.gxTv_SdtOperacoes_Operacoesdata ;
         gxTv_SdtOperacoes_Operacoesstatus = sdt.gxTv_SdtOperacoes_Operacoesstatus ;
         gxTv_SdtOperacoes_Operacoestaxaefetiva = sdt.gxTv_SdtOperacoes_Operacoestaxaefetiva ;
         gxTv_SdtOperacoes_Contratoid = sdt.gxTv_SdtOperacoes_Contratoid ;
         gxTv_SdtOperacoes_Operacoestaxamora = sdt.gxTv_SdtOperacoes_Operacoestaxamora ;
         gxTv_SdtOperacoes_Operacoesfator = sdt.gxTv_SdtOperacoes_Operacoesfator ;
         gxTv_SdtOperacoes_Operacoestipotarifa = sdt.gxTv_SdtOperacoes_Operacoestipotarifa ;
         gxTv_SdtOperacoes_Operacoestarifa = sdt.gxTv_SdtOperacoes_Operacoestarifa ;
         gxTv_SdtOperacoes_Contratonome = sdt.gxTv_SdtOperacoes_Contratonome ;
         gxTv_SdtOperacoes_Operacoescreatedat = sdt.gxTv_SdtOperacoes_Operacoescreatedat ;
         gxTv_SdtOperacoes_Operacoesupdateat = sdt.gxTv_SdtOperacoes_Operacoesupdateat ;
         gxTv_SdtOperacoes_Mode = sdt.gxTv_SdtOperacoes_Mode ;
         gxTv_SdtOperacoes_Initialized = sdt.gxTv_SdtOperacoes_Initialized ;
         gxTv_SdtOperacoes_Operacoesid_Z = sdt.gxTv_SdtOperacoes_Operacoesid_Z ;
         gxTv_SdtOperacoes_Clienteid_Z = sdt.gxTv_SdtOperacoes_Clienteid_Z ;
         gxTv_SdtOperacoes_Clienterazaosocial_Z = sdt.gxTv_SdtOperacoes_Clienterazaosocial_Z ;
         gxTv_SdtOperacoes_Operacoesdata_Z = sdt.gxTv_SdtOperacoes_Operacoesdata_Z ;
         gxTv_SdtOperacoes_Operacoesstatus_Z = sdt.gxTv_SdtOperacoes_Operacoesstatus_Z ;
         gxTv_SdtOperacoes_Operacoestaxaefetiva_Z = sdt.gxTv_SdtOperacoes_Operacoestaxaefetiva_Z ;
         gxTv_SdtOperacoes_Contratoid_Z = sdt.gxTv_SdtOperacoes_Contratoid_Z ;
         gxTv_SdtOperacoes_Operacoestaxamora_Z = sdt.gxTv_SdtOperacoes_Operacoestaxamora_Z ;
         gxTv_SdtOperacoes_Operacoesfator_Z = sdt.gxTv_SdtOperacoes_Operacoesfator_Z ;
         gxTv_SdtOperacoes_Operacoestipotarifa_Z = sdt.gxTv_SdtOperacoes_Operacoestipotarifa_Z ;
         gxTv_SdtOperacoes_Operacoestarifa_Z = sdt.gxTv_SdtOperacoes_Operacoestarifa_Z ;
         gxTv_SdtOperacoes_Contratonome_Z = sdt.gxTv_SdtOperacoes_Contratonome_Z ;
         gxTv_SdtOperacoes_Operacoescreatedat_Z = sdt.gxTv_SdtOperacoes_Operacoescreatedat_Z ;
         gxTv_SdtOperacoes_Operacoesupdateat_Z = sdt.gxTv_SdtOperacoes_Operacoesupdateat_Z ;
         gxTv_SdtOperacoes_Operacoesid_N = sdt.gxTv_SdtOperacoes_Operacoesid_N ;
         gxTv_SdtOperacoes_Clienteid_N = sdt.gxTv_SdtOperacoes_Clienteid_N ;
         gxTv_SdtOperacoes_Clienterazaosocial_N = sdt.gxTv_SdtOperacoes_Clienterazaosocial_N ;
         gxTv_SdtOperacoes_Operacoesdata_N = sdt.gxTv_SdtOperacoes_Operacoesdata_N ;
         gxTv_SdtOperacoes_Operacoesstatus_N = sdt.gxTv_SdtOperacoes_Operacoesstatus_N ;
         gxTv_SdtOperacoes_Operacoestaxaefetiva_N = sdt.gxTv_SdtOperacoes_Operacoestaxaefetiva_N ;
         gxTv_SdtOperacoes_Contratoid_N = sdt.gxTv_SdtOperacoes_Contratoid_N ;
         gxTv_SdtOperacoes_Operacoestaxamora_N = sdt.gxTv_SdtOperacoes_Operacoestaxamora_N ;
         gxTv_SdtOperacoes_Operacoesfator_N = sdt.gxTv_SdtOperacoes_Operacoesfator_N ;
         gxTv_SdtOperacoes_Operacoestipotarifa_N = sdt.gxTv_SdtOperacoes_Operacoestipotarifa_N ;
         gxTv_SdtOperacoes_Operacoestarifa_N = sdt.gxTv_SdtOperacoes_Operacoestarifa_N ;
         gxTv_SdtOperacoes_Contratonome_N = sdt.gxTv_SdtOperacoes_Contratonome_N ;
         gxTv_SdtOperacoes_Operacoescreatedat_N = sdt.gxTv_SdtOperacoes_Operacoescreatedat_N ;
         gxTv_SdtOperacoes_Operacoesupdateat_N = sdt.gxTv_SdtOperacoes_Operacoesupdateat_N ;
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
         AddObjectProperty("OperacoesId", gxTv_SdtOperacoes_Operacoesid, false, includeNonInitialized);
         AddObjectProperty("OperacoesId_N", gxTv_SdtOperacoes_Operacoesid_N, false, includeNonInitialized);
         AddObjectProperty("ClienteId", gxTv_SdtOperacoes_Clienteid, false, includeNonInitialized);
         AddObjectProperty("ClienteId_N", gxTv_SdtOperacoes_Clienteid_N, false, includeNonInitialized);
         AddObjectProperty("ClienteRazaoSocial", gxTv_SdtOperacoes_Clienterazaosocial, false, includeNonInitialized);
         AddObjectProperty("ClienteRazaoSocial_N", gxTv_SdtOperacoes_Clienterazaosocial_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtOperacoes_Operacoesdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtOperacoes_Operacoesdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtOperacoes_Operacoesdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("OperacoesData", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("OperacoesData_N", gxTv_SdtOperacoes_Operacoesdata_N, false, includeNonInitialized);
         AddObjectProperty("OperacoesStatus", gxTv_SdtOperacoes_Operacoesstatus, false, includeNonInitialized);
         AddObjectProperty("OperacoesStatus_N", gxTv_SdtOperacoes_Operacoesstatus_N, false, includeNonInitialized);
         AddObjectProperty("OperacoesTaxaEfetiva", StringUtil.LTrim( StringUtil.Str( gxTv_SdtOperacoes_Operacoestaxaefetiva, 16, 4)), false, includeNonInitialized);
         AddObjectProperty("OperacoesTaxaEfetiva_N", gxTv_SdtOperacoes_Operacoestaxaefetiva_N, false, includeNonInitialized);
         AddObjectProperty("ContratoId", gxTv_SdtOperacoes_Contratoid, false, includeNonInitialized);
         AddObjectProperty("ContratoId_N", gxTv_SdtOperacoes_Contratoid_N, false, includeNonInitialized);
         AddObjectProperty("OperacoesTaxaMora", StringUtil.LTrim( StringUtil.Str( gxTv_SdtOperacoes_Operacoestaxamora, 16, 4)), false, includeNonInitialized);
         AddObjectProperty("OperacoesTaxaMora_N", gxTv_SdtOperacoes_Operacoestaxamora_N, false, includeNonInitialized);
         AddObjectProperty("OperacoesFator", StringUtil.LTrim( StringUtil.Str( gxTv_SdtOperacoes_Operacoesfator, 16, 4)), false, includeNonInitialized);
         AddObjectProperty("OperacoesFator_N", gxTv_SdtOperacoes_Operacoesfator_N, false, includeNonInitialized);
         AddObjectProperty("OperacoesTipoTarifa", gxTv_SdtOperacoes_Operacoestipotarifa, false, includeNonInitialized);
         AddObjectProperty("OperacoesTipoTarifa_N", gxTv_SdtOperacoes_Operacoestipotarifa_N, false, includeNonInitialized);
         AddObjectProperty("OperacoesTarifa", gxTv_SdtOperacoes_Operacoestarifa, false, includeNonInitialized);
         AddObjectProperty("OperacoesTarifa_N", gxTv_SdtOperacoes_Operacoestarifa_N, false, includeNonInitialized);
         AddObjectProperty("ContratoNome", gxTv_SdtOperacoes_Contratonome, false, includeNonInitialized);
         AddObjectProperty("ContratoNome_N", gxTv_SdtOperacoes_Contratonome_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtOperacoes_Operacoescreatedat;
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
         AddObjectProperty("OperacoesCreatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("OperacoesCreatedAt_N", gxTv_SdtOperacoes_Operacoescreatedat_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtOperacoes_Operacoesupdateat;
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
         AddObjectProperty("OperacoesUpdateAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("OperacoesUpdateAt_N", gxTv_SdtOperacoes_Operacoesupdateat_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtOperacoes_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtOperacoes_Initialized, false, includeNonInitialized);
            AddObjectProperty("OperacoesId_Z", gxTv_SdtOperacoes_Operacoesid_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteId_Z", gxTv_SdtOperacoes_Clienteid_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteRazaoSocial_Z", gxTv_SdtOperacoes_Clienterazaosocial_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtOperacoes_Operacoesdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtOperacoes_Operacoesdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtOperacoes_Operacoesdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("OperacoesData_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("OperacoesStatus_Z", gxTv_SdtOperacoes_Operacoesstatus_Z, false, includeNonInitialized);
            AddObjectProperty("OperacoesTaxaEfetiva_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtOperacoes_Operacoestaxaefetiva_Z, 16, 4)), false, includeNonInitialized);
            AddObjectProperty("ContratoId_Z", gxTv_SdtOperacoes_Contratoid_Z, false, includeNonInitialized);
            AddObjectProperty("OperacoesTaxaMora_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtOperacoes_Operacoestaxamora_Z, 16, 4)), false, includeNonInitialized);
            AddObjectProperty("OperacoesFator_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtOperacoes_Operacoesfator_Z, 16, 4)), false, includeNonInitialized);
            AddObjectProperty("OperacoesTipoTarifa_Z", gxTv_SdtOperacoes_Operacoestipotarifa_Z, false, includeNonInitialized);
            AddObjectProperty("OperacoesTarifa_Z", gxTv_SdtOperacoes_Operacoestarifa_Z, false, includeNonInitialized);
            AddObjectProperty("ContratoNome_Z", gxTv_SdtOperacoes_Contratonome_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtOperacoes_Operacoescreatedat_Z;
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
            AddObjectProperty("OperacoesCreatedAt_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtOperacoes_Operacoesupdateat_Z;
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
            AddObjectProperty("OperacoesUpdateAt_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("OperacoesId_N", gxTv_SdtOperacoes_Operacoesid_N, false, includeNonInitialized);
            AddObjectProperty("ClienteId_N", gxTv_SdtOperacoes_Clienteid_N, false, includeNonInitialized);
            AddObjectProperty("ClienteRazaoSocial_N", gxTv_SdtOperacoes_Clienterazaosocial_N, false, includeNonInitialized);
            AddObjectProperty("OperacoesData_N", gxTv_SdtOperacoes_Operacoesdata_N, false, includeNonInitialized);
            AddObjectProperty("OperacoesStatus_N", gxTv_SdtOperacoes_Operacoesstatus_N, false, includeNonInitialized);
            AddObjectProperty("OperacoesTaxaEfetiva_N", gxTv_SdtOperacoes_Operacoestaxaefetiva_N, false, includeNonInitialized);
            AddObjectProperty("ContratoId_N", gxTv_SdtOperacoes_Contratoid_N, false, includeNonInitialized);
            AddObjectProperty("OperacoesTaxaMora_N", gxTv_SdtOperacoes_Operacoestaxamora_N, false, includeNonInitialized);
            AddObjectProperty("OperacoesFator_N", gxTv_SdtOperacoes_Operacoesfator_N, false, includeNonInitialized);
            AddObjectProperty("OperacoesTipoTarifa_N", gxTv_SdtOperacoes_Operacoestipotarifa_N, false, includeNonInitialized);
            AddObjectProperty("OperacoesTarifa_N", gxTv_SdtOperacoes_Operacoestarifa_N, false, includeNonInitialized);
            AddObjectProperty("ContratoNome_N", gxTv_SdtOperacoes_Contratonome_N, false, includeNonInitialized);
            AddObjectProperty("OperacoesCreatedAt_N", gxTv_SdtOperacoes_Operacoescreatedat_N, false, includeNonInitialized);
            AddObjectProperty("OperacoesUpdateAt_N", gxTv_SdtOperacoes_Operacoesupdateat_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtOperacoes sdt )
      {
         if ( sdt.IsDirty("OperacoesId") )
         {
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoesid = sdt.gxTv_SdtOperacoes_Operacoesid ;
         }
         if ( sdt.IsDirty("ClienteId") )
         {
            gxTv_SdtOperacoes_Clienteid_N = (short)(sdt.gxTv_SdtOperacoes_Clienteid_N);
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Clienteid = sdt.gxTv_SdtOperacoes_Clienteid ;
         }
         if ( sdt.IsDirty("ClienteRazaoSocial") )
         {
            gxTv_SdtOperacoes_Clienterazaosocial_N = (short)(sdt.gxTv_SdtOperacoes_Clienterazaosocial_N);
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Clienterazaosocial = sdt.gxTv_SdtOperacoes_Clienterazaosocial ;
         }
         if ( sdt.IsDirty("OperacoesData") )
         {
            gxTv_SdtOperacoes_Operacoesdata_N = (short)(sdt.gxTv_SdtOperacoes_Operacoesdata_N);
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoesdata = sdt.gxTv_SdtOperacoes_Operacoesdata ;
         }
         if ( sdt.IsDirty("OperacoesStatus") )
         {
            gxTv_SdtOperacoes_Operacoesstatus_N = (short)(sdt.gxTv_SdtOperacoes_Operacoesstatus_N);
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoesstatus = sdt.gxTv_SdtOperacoes_Operacoesstatus ;
         }
         if ( sdt.IsDirty("OperacoesTaxaEfetiva") )
         {
            gxTv_SdtOperacoes_Operacoestaxaefetiva_N = (short)(sdt.gxTv_SdtOperacoes_Operacoestaxaefetiva_N);
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoestaxaefetiva = sdt.gxTv_SdtOperacoes_Operacoestaxaefetiva ;
         }
         if ( sdt.IsDirty("ContratoId") )
         {
            gxTv_SdtOperacoes_Contratoid_N = (short)(sdt.gxTv_SdtOperacoes_Contratoid_N);
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Contratoid = sdt.gxTv_SdtOperacoes_Contratoid ;
         }
         if ( sdt.IsDirty("OperacoesTaxaMora") )
         {
            gxTv_SdtOperacoes_Operacoestaxamora_N = (short)(sdt.gxTv_SdtOperacoes_Operacoestaxamora_N);
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoestaxamora = sdt.gxTv_SdtOperacoes_Operacoestaxamora ;
         }
         if ( sdt.IsDirty("OperacoesFator") )
         {
            gxTv_SdtOperacoes_Operacoesfator_N = (short)(sdt.gxTv_SdtOperacoes_Operacoesfator_N);
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoesfator = sdt.gxTv_SdtOperacoes_Operacoesfator ;
         }
         if ( sdt.IsDirty("OperacoesTipoTarifa") )
         {
            gxTv_SdtOperacoes_Operacoestipotarifa_N = (short)(sdt.gxTv_SdtOperacoes_Operacoestipotarifa_N);
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoestipotarifa = sdt.gxTv_SdtOperacoes_Operacoestipotarifa ;
         }
         if ( sdt.IsDirty("OperacoesTarifa") )
         {
            gxTv_SdtOperacoes_Operacoestarifa_N = (short)(sdt.gxTv_SdtOperacoes_Operacoestarifa_N);
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoestarifa = sdt.gxTv_SdtOperacoes_Operacoestarifa ;
         }
         if ( sdt.IsDirty("ContratoNome") )
         {
            gxTv_SdtOperacoes_Contratonome_N = (short)(sdt.gxTv_SdtOperacoes_Contratonome_N);
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Contratonome = sdt.gxTv_SdtOperacoes_Contratonome ;
         }
         if ( sdt.IsDirty("OperacoesCreatedAt") )
         {
            gxTv_SdtOperacoes_Operacoescreatedat_N = (short)(sdt.gxTv_SdtOperacoes_Operacoescreatedat_N);
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoescreatedat = sdt.gxTv_SdtOperacoes_Operacoescreatedat ;
         }
         if ( sdt.IsDirty("OperacoesUpdateAt") )
         {
            gxTv_SdtOperacoes_Operacoesupdateat_N = (short)(sdt.gxTv_SdtOperacoes_Operacoesupdateat_N);
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoesupdateat = sdt.gxTv_SdtOperacoes_Operacoesupdateat ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "OperacoesId" )]
      [  XmlElement( ElementName = "OperacoesId"   )]
      public int gxTpr_Operacoesid
      {
         get {
            return gxTv_SdtOperacoes_Operacoesid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtOperacoes_Operacoesid != value )
            {
               gxTv_SdtOperacoes_Mode = "INS";
               this.gxTv_SdtOperacoes_Operacoesid_Z_SetNull( );
               this.gxTv_SdtOperacoes_Clienteid_Z_SetNull( );
               this.gxTv_SdtOperacoes_Clienterazaosocial_Z_SetNull( );
               this.gxTv_SdtOperacoes_Operacoesdata_Z_SetNull( );
               this.gxTv_SdtOperacoes_Operacoesstatus_Z_SetNull( );
               this.gxTv_SdtOperacoes_Operacoestaxaefetiva_Z_SetNull( );
               this.gxTv_SdtOperacoes_Contratoid_Z_SetNull( );
               this.gxTv_SdtOperacoes_Operacoestaxamora_Z_SetNull( );
               this.gxTv_SdtOperacoes_Operacoesfator_Z_SetNull( );
               this.gxTv_SdtOperacoes_Operacoestipotarifa_Z_SetNull( );
               this.gxTv_SdtOperacoes_Operacoestarifa_Z_SetNull( );
               this.gxTv_SdtOperacoes_Contratonome_Z_SetNull( );
               this.gxTv_SdtOperacoes_Operacoescreatedat_Z_SetNull( );
               this.gxTv_SdtOperacoes_Operacoesupdateat_Z_SetNull( );
            }
            gxTv_SdtOperacoes_Operacoesid = value;
            SetDirty("Operacoesid");
         }

      }

      [  SoapElement( ElementName = "ClienteId" )]
      [  XmlElement( ElementName = "ClienteId"   )]
      public int gxTpr_Clienteid
      {
         get {
            return gxTv_SdtOperacoes_Clienteid ;
         }

         set {
            gxTv_SdtOperacoes_Clienteid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Clienteid = value;
            SetDirty("Clienteid");
         }

      }

      public void gxTv_SdtOperacoes_Clienteid_SetNull( )
      {
         gxTv_SdtOperacoes_Clienteid_N = 1;
         gxTv_SdtOperacoes_Clienteid = 0;
         SetDirty("Clienteid");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Clienteid_IsNull( )
      {
         return (gxTv_SdtOperacoes_Clienteid_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteRazaoSocial" )]
      [  XmlElement( ElementName = "ClienteRazaoSocial"   )]
      public string gxTpr_Clienterazaosocial
      {
         get {
            return gxTv_SdtOperacoes_Clienterazaosocial ;
         }

         set {
            gxTv_SdtOperacoes_Clienterazaosocial_N = 0;
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Clienterazaosocial = value;
            SetDirty("Clienterazaosocial");
         }

      }

      public void gxTv_SdtOperacoes_Clienterazaosocial_SetNull( )
      {
         gxTv_SdtOperacoes_Clienterazaosocial_N = 1;
         gxTv_SdtOperacoes_Clienterazaosocial = "";
         SetDirty("Clienterazaosocial");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Clienterazaosocial_IsNull( )
      {
         return (gxTv_SdtOperacoes_Clienterazaosocial_N==1) ;
      }

      [  SoapElement( ElementName = "OperacoesData" )]
      [  XmlElement( ElementName = "OperacoesData"  , IsNullable=true )]
      public string gxTpr_Operacoesdata_Nullable
      {
         get {
            if ( gxTv_SdtOperacoes_Operacoesdata == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtOperacoes_Operacoesdata).value ;
         }

         set {
            gxTv_SdtOperacoes_Operacoesdata_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtOperacoes_Operacoesdata = DateTime.MinValue;
            else
               gxTv_SdtOperacoes_Operacoesdata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Operacoesdata
      {
         get {
            return gxTv_SdtOperacoes_Operacoesdata ;
         }

         set {
            gxTv_SdtOperacoes_Operacoesdata_N = 0;
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoesdata = value;
            SetDirty("Operacoesdata");
         }

      }

      public void gxTv_SdtOperacoes_Operacoesdata_SetNull( )
      {
         gxTv_SdtOperacoes_Operacoesdata_N = 1;
         gxTv_SdtOperacoes_Operacoesdata = (DateTime)(DateTime.MinValue);
         SetDirty("Operacoesdata");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Operacoesdata_IsNull( )
      {
         return (gxTv_SdtOperacoes_Operacoesdata_N==1) ;
      }

      [  SoapElement( ElementName = "OperacoesStatus" )]
      [  XmlElement( ElementName = "OperacoesStatus"   )]
      public string gxTpr_Operacoesstatus
      {
         get {
            return gxTv_SdtOperacoes_Operacoesstatus ;
         }

         set {
            gxTv_SdtOperacoes_Operacoesstatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoesstatus = value;
            SetDirty("Operacoesstatus");
         }

      }

      public void gxTv_SdtOperacoes_Operacoesstatus_SetNull( )
      {
         gxTv_SdtOperacoes_Operacoesstatus_N = 1;
         gxTv_SdtOperacoes_Operacoesstatus = "";
         SetDirty("Operacoesstatus");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Operacoesstatus_IsNull( )
      {
         return (gxTv_SdtOperacoes_Operacoesstatus_N==1) ;
      }

      [  SoapElement( ElementName = "OperacoesTaxaEfetiva" )]
      [  XmlElement( ElementName = "OperacoesTaxaEfetiva"   )]
      public decimal gxTpr_Operacoestaxaefetiva
      {
         get {
            return gxTv_SdtOperacoes_Operacoestaxaefetiva ;
         }

         set {
            gxTv_SdtOperacoes_Operacoestaxaefetiva_N = 0;
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoestaxaefetiva = value;
            SetDirty("Operacoestaxaefetiva");
         }

      }

      public void gxTv_SdtOperacoes_Operacoestaxaefetiva_SetNull( )
      {
         gxTv_SdtOperacoes_Operacoestaxaefetiva_N = 1;
         gxTv_SdtOperacoes_Operacoestaxaefetiva = 0;
         SetDirty("Operacoestaxaefetiva");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Operacoestaxaefetiva_IsNull( )
      {
         return (gxTv_SdtOperacoes_Operacoestaxaefetiva_N==1) ;
      }

      [  SoapElement( ElementName = "ContratoId" )]
      [  XmlElement( ElementName = "ContratoId"   )]
      public int gxTpr_Contratoid
      {
         get {
            return gxTv_SdtOperacoes_Contratoid ;
         }

         set {
            gxTv_SdtOperacoes_Contratoid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Contratoid = value;
            SetDirty("Contratoid");
         }

      }

      public void gxTv_SdtOperacoes_Contratoid_SetNull( )
      {
         gxTv_SdtOperacoes_Contratoid_N = 1;
         gxTv_SdtOperacoes_Contratoid = 0;
         SetDirty("Contratoid");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Contratoid_IsNull( )
      {
         return (gxTv_SdtOperacoes_Contratoid_N==1) ;
      }

      [  SoapElement( ElementName = "OperacoesTaxaMora" )]
      [  XmlElement( ElementName = "OperacoesTaxaMora"   )]
      public decimal gxTpr_Operacoestaxamora
      {
         get {
            return gxTv_SdtOperacoes_Operacoestaxamora ;
         }

         set {
            gxTv_SdtOperacoes_Operacoestaxamora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoestaxamora = value;
            SetDirty("Operacoestaxamora");
         }

      }

      public void gxTv_SdtOperacoes_Operacoestaxamora_SetNull( )
      {
         gxTv_SdtOperacoes_Operacoestaxamora_N = 1;
         gxTv_SdtOperacoes_Operacoestaxamora = 0;
         SetDirty("Operacoestaxamora");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Operacoestaxamora_IsNull( )
      {
         return (gxTv_SdtOperacoes_Operacoestaxamora_N==1) ;
      }

      [  SoapElement( ElementName = "OperacoesFator" )]
      [  XmlElement( ElementName = "OperacoesFator"   )]
      public decimal gxTpr_Operacoesfator
      {
         get {
            return gxTv_SdtOperacoes_Operacoesfator ;
         }

         set {
            gxTv_SdtOperacoes_Operacoesfator_N = 0;
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoesfator = value;
            SetDirty("Operacoesfator");
         }

      }

      public void gxTv_SdtOperacoes_Operacoesfator_SetNull( )
      {
         gxTv_SdtOperacoes_Operacoesfator_N = 1;
         gxTv_SdtOperacoes_Operacoesfator = 0;
         SetDirty("Operacoesfator");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Operacoesfator_IsNull( )
      {
         return (gxTv_SdtOperacoes_Operacoesfator_N==1) ;
      }

      [  SoapElement( ElementName = "OperacoesTipoTarifa" )]
      [  XmlElement( ElementName = "OperacoesTipoTarifa"   )]
      public string gxTpr_Operacoestipotarifa
      {
         get {
            return gxTv_SdtOperacoes_Operacoestipotarifa ;
         }

         set {
            gxTv_SdtOperacoes_Operacoestipotarifa_N = 0;
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoestipotarifa = value;
            SetDirty("Operacoestipotarifa");
         }

      }

      public void gxTv_SdtOperacoes_Operacoestipotarifa_SetNull( )
      {
         gxTv_SdtOperacoes_Operacoestipotarifa_N = 1;
         gxTv_SdtOperacoes_Operacoestipotarifa = "";
         SetDirty("Operacoestipotarifa");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Operacoestipotarifa_IsNull( )
      {
         return (gxTv_SdtOperacoes_Operacoestipotarifa_N==1) ;
      }

      [  SoapElement( ElementName = "OperacoesTarifa" )]
      [  XmlElement( ElementName = "OperacoesTarifa"   )]
      public decimal gxTpr_Operacoestarifa
      {
         get {
            return gxTv_SdtOperacoes_Operacoestarifa ;
         }

         set {
            gxTv_SdtOperacoes_Operacoestarifa_N = 0;
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoestarifa = value;
            SetDirty("Operacoestarifa");
         }

      }

      public void gxTv_SdtOperacoes_Operacoestarifa_SetNull( )
      {
         gxTv_SdtOperacoes_Operacoestarifa_N = 1;
         gxTv_SdtOperacoes_Operacoestarifa = 0;
         SetDirty("Operacoestarifa");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Operacoestarifa_IsNull( )
      {
         return (gxTv_SdtOperacoes_Operacoestarifa_N==1) ;
      }

      [  SoapElement( ElementName = "ContratoNome" )]
      [  XmlElement( ElementName = "ContratoNome"   )]
      public string gxTpr_Contratonome
      {
         get {
            return gxTv_SdtOperacoes_Contratonome ;
         }

         set {
            gxTv_SdtOperacoes_Contratonome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Contratonome = value;
            SetDirty("Contratonome");
         }

      }

      public void gxTv_SdtOperacoes_Contratonome_SetNull( )
      {
         gxTv_SdtOperacoes_Contratonome_N = 1;
         gxTv_SdtOperacoes_Contratonome = "";
         SetDirty("Contratonome");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Contratonome_IsNull( )
      {
         return (gxTv_SdtOperacoes_Contratonome_N==1) ;
      }

      [  SoapElement( ElementName = "OperacoesCreatedAt" )]
      [  XmlElement( ElementName = "OperacoesCreatedAt"  , IsNullable=true )]
      public string gxTpr_Operacoescreatedat_Nullable
      {
         get {
            if ( gxTv_SdtOperacoes_Operacoescreatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtOperacoes_Operacoescreatedat).value ;
         }

         set {
            gxTv_SdtOperacoes_Operacoescreatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtOperacoes_Operacoescreatedat = DateTime.MinValue;
            else
               gxTv_SdtOperacoes_Operacoescreatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Operacoescreatedat
      {
         get {
            return gxTv_SdtOperacoes_Operacoescreatedat ;
         }

         set {
            gxTv_SdtOperacoes_Operacoescreatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoescreatedat = value;
            SetDirty("Operacoescreatedat");
         }

      }

      public void gxTv_SdtOperacoes_Operacoescreatedat_SetNull( )
      {
         gxTv_SdtOperacoes_Operacoescreatedat_N = 1;
         gxTv_SdtOperacoes_Operacoescreatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Operacoescreatedat");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Operacoescreatedat_IsNull( )
      {
         return (gxTv_SdtOperacoes_Operacoescreatedat_N==1) ;
      }

      [  SoapElement( ElementName = "OperacoesUpdateAt" )]
      [  XmlElement( ElementName = "OperacoesUpdateAt"  , IsNullable=true )]
      public string gxTpr_Operacoesupdateat_Nullable
      {
         get {
            if ( gxTv_SdtOperacoes_Operacoesupdateat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtOperacoes_Operacoesupdateat).value ;
         }

         set {
            gxTv_SdtOperacoes_Operacoesupdateat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtOperacoes_Operacoesupdateat = DateTime.MinValue;
            else
               gxTv_SdtOperacoes_Operacoesupdateat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Operacoesupdateat
      {
         get {
            return gxTv_SdtOperacoes_Operacoesupdateat ;
         }

         set {
            gxTv_SdtOperacoes_Operacoesupdateat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoesupdateat = value;
            SetDirty("Operacoesupdateat");
         }

      }

      public void gxTv_SdtOperacoes_Operacoesupdateat_SetNull( )
      {
         gxTv_SdtOperacoes_Operacoesupdateat_N = 1;
         gxTv_SdtOperacoes_Operacoesupdateat = (DateTime)(DateTime.MinValue);
         SetDirty("Operacoesupdateat");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Operacoesupdateat_IsNull( )
      {
         return (gxTv_SdtOperacoes_Operacoesupdateat_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtOperacoes_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtOperacoes_Mode_SetNull( )
      {
         gxTv_SdtOperacoes_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtOperacoes_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtOperacoes_Initialized_SetNull( )
      {
         gxTv_SdtOperacoes_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesId_Z" )]
      [  XmlElement( ElementName = "OperacoesId_Z"   )]
      public int gxTpr_Operacoesid_Z
      {
         get {
            return gxTv_SdtOperacoes_Operacoesid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoesid_Z = value;
            SetDirty("Operacoesid_Z");
         }

      }

      public void gxTv_SdtOperacoes_Operacoesid_Z_SetNull( )
      {
         gxTv_SdtOperacoes_Operacoesid_Z = 0;
         SetDirty("Operacoesid_Z");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Operacoesid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteId_Z" )]
      [  XmlElement( ElementName = "ClienteId_Z"   )]
      public int gxTpr_Clienteid_Z
      {
         get {
            return gxTv_SdtOperacoes_Clienteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Clienteid_Z = value;
            SetDirty("Clienteid_Z");
         }

      }

      public void gxTv_SdtOperacoes_Clienteid_Z_SetNull( )
      {
         gxTv_SdtOperacoes_Clienteid_Z = 0;
         SetDirty("Clienteid_Z");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Clienteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteRazaoSocial_Z" )]
      [  XmlElement( ElementName = "ClienteRazaoSocial_Z"   )]
      public string gxTpr_Clienterazaosocial_Z
      {
         get {
            return gxTv_SdtOperacoes_Clienterazaosocial_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Clienterazaosocial_Z = value;
            SetDirty("Clienterazaosocial_Z");
         }

      }

      public void gxTv_SdtOperacoes_Clienterazaosocial_Z_SetNull( )
      {
         gxTv_SdtOperacoes_Clienterazaosocial_Z = "";
         SetDirty("Clienterazaosocial_Z");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Clienterazaosocial_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesData_Z" )]
      [  XmlElement( ElementName = "OperacoesData_Z"  , IsNullable=true )]
      public string gxTpr_Operacoesdata_Z_Nullable
      {
         get {
            if ( gxTv_SdtOperacoes_Operacoesdata_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtOperacoes_Operacoesdata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtOperacoes_Operacoesdata_Z = DateTime.MinValue;
            else
               gxTv_SdtOperacoes_Operacoesdata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Operacoesdata_Z
      {
         get {
            return gxTv_SdtOperacoes_Operacoesdata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoesdata_Z = value;
            SetDirty("Operacoesdata_Z");
         }

      }

      public void gxTv_SdtOperacoes_Operacoesdata_Z_SetNull( )
      {
         gxTv_SdtOperacoes_Operacoesdata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Operacoesdata_Z");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Operacoesdata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesStatus_Z" )]
      [  XmlElement( ElementName = "OperacoesStatus_Z"   )]
      public string gxTpr_Operacoesstatus_Z
      {
         get {
            return gxTv_SdtOperacoes_Operacoesstatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoesstatus_Z = value;
            SetDirty("Operacoesstatus_Z");
         }

      }

      public void gxTv_SdtOperacoes_Operacoesstatus_Z_SetNull( )
      {
         gxTv_SdtOperacoes_Operacoesstatus_Z = "";
         SetDirty("Operacoesstatus_Z");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Operacoesstatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesTaxaEfetiva_Z" )]
      [  XmlElement( ElementName = "OperacoesTaxaEfetiva_Z"   )]
      public decimal gxTpr_Operacoestaxaefetiva_Z
      {
         get {
            return gxTv_SdtOperacoes_Operacoestaxaefetiva_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoestaxaefetiva_Z = value;
            SetDirty("Operacoestaxaefetiva_Z");
         }

      }

      public void gxTv_SdtOperacoes_Operacoestaxaefetiva_Z_SetNull( )
      {
         gxTv_SdtOperacoes_Operacoestaxaefetiva_Z = 0;
         SetDirty("Operacoestaxaefetiva_Z");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Operacoestaxaefetiva_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoId_Z" )]
      [  XmlElement( ElementName = "ContratoId_Z"   )]
      public int gxTpr_Contratoid_Z
      {
         get {
            return gxTv_SdtOperacoes_Contratoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Contratoid_Z = value;
            SetDirty("Contratoid_Z");
         }

      }

      public void gxTv_SdtOperacoes_Contratoid_Z_SetNull( )
      {
         gxTv_SdtOperacoes_Contratoid_Z = 0;
         SetDirty("Contratoid_Z");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Contratoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesTaxaMora_Z" )]
      [  XmlElement( ElementName = "OperacoesTaxaMora_Z"   )]
      public decimal gxTpr_Operacoestaxamora_Z
      {
         get {
            return gxTv_SdtOperacoes_Operacoestaxamora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoestaxamora_Z = value;
            SetDirty("Operacoestaxamora_Z");
         }

      }

      public void gxTv_SdtOperacoes_Operacoestaxamora_Z_SetNull( )
      {
         gxTv_SdtOperacoes_Operacoestaxamora_Z = 0;
         SetDirty("Operacoestaxamora_Z");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Operacoestaxamora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesFator_Z" )]
      [  XmlElement( ElementName = "OperacoesFator_Z"   )]
      public decimal gxTpr_Operacoesfator_Z
      {
         get {
            return gxTv_SdtOperacoes_Operacoesfator_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoesfator_Z = value;
            SetDirty("Operacoesfator_Z");
         }

      }

      public void gxTv_SdtOperacoes_Operacoesfator_Z_SetNull( )
      {
         gxTv_SdtOperacoes_Operacoesfator_Z = 0;
         SetDirty("Operacoesfator_Z");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Operacoesfator_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesTipoTarifa_Z" )]
      [  XmlElement( ElementName = "OperacoesTipoTarifa_Z"   )]
      public string gxTpr_Operacoestipotarifa_Z
      {
         get {
            return gxTv_SdtOperacoes_Operacoestipotarifa_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoestipotarifa_Z = value;
            SetDirty("Operacoestipotarifa_Z");
         }

      }

      public void gxTv_SdtOperacoes_Operacoestipotarifa_Z_SetNull( )
      {
         gxTv_SdtOperacoes_Operacoestipotarifa_Z = "";
         SetDirty("Operacoestipotarifa_Z");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Operacoestipotarifa_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesTarifa_Z" )]
      [  XmlElement( ElementName = "OperacoesTarifa_Z"   )]
      public decimal gxTpr_Operacoestarifa_Z
      {
         get {
            return gxTv_SdtOperacoes_Operacoestarifa_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoestarifa_Z = value;
            SetDirty("Operacoestarifa_Z");
         }

      }

      public void gxTv_SdtOperacoes_Operacoestarifa_Z_SetNull( )
      {
         gxTv_SdtOperacoes_Operacoestarifa_Z = 0;
         SetDirty("Operacoestarifa_Z");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Operacoestarifa_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoNome_Z" )]
      [  XmlElement( ElementName = "ContratoNome_Z"   )]
      public string gxTpr_Contratonome_Z
      {
         get {
            return gxTv_SdtOperacoes_Contratonome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Contratonome_Z = value;
            SetDirty("Contratonome_Z");
         }

      }

      public void gxTv_SdtOperacoes_Contratonome_Z_SetNull( )
      {
         gxTv_SdtOperacoes_Contratonome_Z = "";
         SetDirty("Contratonome_Z");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Contratonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesCreatedAt_Z" )]
      [  XmlElement( ElementName = "OperacoesCreatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Operacoescreatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtOperacoes_Operacoescreatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtOperacoes_Operacoescreatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtOperacoes_Operacoescreatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtOperacoes_Operacoescreatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Operacoescreatedat_Z
      {
         get {
            return gxTv_SdtOperacoes_Operacoescreatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoescreatedat_Z = value;
            SetDirty("Operacoescreatedat_Z");
         }

      }

      public void gxTv_SdtOperacoes_Operacoescreatedat_Z_SetNull( )
      {
         gxTv_SdtOperacoes_Operacoescreatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Operacoescreatedat_Z");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Operacoescreatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesUpdateAt_Z" )]
      [  XmlElement( ElementName = "OperacoesUpdateAt_Z"  , IsNullable=true )]
      public string gxTpr_Operacoesupdateat_Z_Nullable
      {
         get {
            if ( gxTv_SdtOperacoes_Operacoesupdateat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtOperacoes_Operacoesupdateat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtOperacoes_Operacoesupdateat_Z = DateTime.MinValue;
            else
               gxTv_SdtOperacoes_Operacoesupdateat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Operacoesupdateat_Z
      {
         get {
            return gxTv_SdtOperacoes_Operacoesupdateat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoesupdateat_Z = value;
            SetDirty("Operacoesupdateat_Z");
         }

      }

      public void gxTv_SdtOperacoes_Operacoesupdateat_Z_SetNull( )
      {
         gxTv_SdtOperacoes_Operacoesupdateat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Operacoesupdateat_Z");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Operacoesupdateat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesId_N" )]
      [  XmlElement( ElementName = "OperacoesId_N"   )]
      public short gxTpr_Operacoesid_N
      {
         get {
            return gxTv_SdtOperacoes_Operacoesid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoesid_N = value;
            SetDirty("Operacoesid_N");
         }

      }

      public void gxTv_SdtOperacoes_Operacoesid_N_SetNull( )
      {
         gxTv_SdtOperacoes_Operacoesid_N = 0;
         SetDirty("Operacoesid_N");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Operacoesid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteId_N" )]
      [  XmlElement( ElementName = "ClienteId_N"   )]
      public short gxTpr_Clienteid_N
      {
         get {
            return gxTv_SdtOperacoes_Clienteid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Clienteid_N = value;
            SetDirty("Clienteid_N");
         }

      }

      public void gxTv_SdtOperacoes_Clienteid_N_SetNull( )
      {
         gxTv_SdtOperacoes_Clienteid_N = 0;
         SetDirty("Clienteid_N");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Clienteid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteRazaoSocial_N" )]
      [  XmlElement( ElementName = "ClienteRazaoSocial_N"   )]
      public short gxTpr_Clienterazaosocial_N
      {
         get {
            return gxTv_SdtOperacoes_Clienterazaosocial_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Clienterazaosocial_N = value;
            SetDirty("Clienterazaosocial_N");
         }

      }

      public void gxTv_SdtOperacoes_Clienterazaosocial_N_SetNull( )
      {
         gxTv_SdtOperacoes_Clienterazaosocial_N = 0;
         SetDirty("Clienterazaosocial_N");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Clienterazaosocial_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesData_N" )]
      [  XmlElement( ElementName = "OperacoesData_N"   )]
      public short gxTpr_Operacoesdata_N
      {
         get {
            return gxTv_SdtOperacoes_Operacoesdata_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoesdata_N = value;
            SetDirty("Operacoesdata_N");
         }

      }

      public void gxTv_SdtOperacoes_Operacoesdata_N_SetNull( )
      {
         gxTv_SdtOperacoes_Operacoesdata_N = 0;
         SetDirty("Operacoesdata_N");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Operacoesdata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesStatus_N" )]
      [  XmlElement( ElementName = "OperacoesStatus_N"   )]
      public short gxTpr_Operacoesstatus_N
      {
         get {
            return gxTv_SdtOperacoes_Operacoesstatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoesstatus_N = value;
            SetDirty("Operacoesstatus_N");
         }

      }

      public void gxTv_SdtOperacoes_Operacoesstatus_N_SetNull( )
      {
         gxTv_SdtOperacoes_Operacoesstatus_N = 0;
         SetDirty("Operacoesstatus_N");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Operacoesstatus_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesTaxaEfetiva_N" )]
      [  XmlElement( ElementName = "OperacoesTaxaEfetiva_N"   )]
      public short gxTpr_Operacoestaxaefetiva_N
      {
         get {
            return gxTv_SdtOperacoes_Operacoestaxaefetiva_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoestaxaefetiva_N = value;
            SetDirty("Operacoestaxaefetiva_N");
         }

      }

      public void gxTv_SdtOperacoes_Operacoestaxaefetiva_N_SetNull( )
      {
         gxTv_SdtOperacoes_Operacoestaxaefetiva_N = 0;
         SetDirty("Operacoestaxaefetiva_N");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Operacoestaxaefetiva_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoId_N" )]
      [  XmlElement( ElementName = "ContratoId_N"   )]
      public short gxTpr_Contratoid_N
      {
         get {
            return gxTv_SdtOperacoes_Contratoid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Contratoid_N = value;
            SetDirty("Contratoid_N");
         }

      }

      public void gxTv_SdtOperacoes_Contratoid_N_SetNull( )
      {
         gxTv_SdtOperacoes_Contratoid_N = 0;
         SetDirty("Contratoid_N");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Contratoid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesTaxaMora_N" )]
      [  XmlElement( ElementName = "OperacoesTaxaMora_N"   )]
      public short gxTpr_Operacoestaxamora_N
      {
         get {
            return gxTv_SdtOperacoes_Operacoestaxamora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoestaxamora_N = value;
            SetDirty("Operacoestaxamora_N");
         }

      }

      public void gxTv_SdtOperacoes_Operacoestaxamora_N_SetNull( )
      {
         gxTv_SdtOperacoes_Operacoestaxamora_N = 0;
         SetDirty("Operacoestaxamora_N");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Operacoestaxamora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesFator_N" )]
      [  XmlElement( ElementName = "OperacoesFator_N"   )]
      public short gxTpr_Operacoesfator_N
      {
         get {
            return gxTv_SdtOperacoes_Operacoesfator_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoesfator_N = value;
            SetDirty("Operacoesfator_N");
         }

      }

      public void gxTv_SdtOperacoes_Operacoesfator_N_SetNull( )
      {
         gxTv_SdtOperacoes_Operacoesfator_N = 0;
         SetDirty("Operacoesfator_N");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Operacoesfator_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesTipoTarifa_N" )]
      [  XmlElement( ElementName = "OperacoesTipoTarifa_N"   )]
      public short gxTpr_Operacoestipotarifa_N
      {
         get {
            return gxTv_SdtOperacoes_Operacoestipotarifa_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoestipotarifa_N = value;
            SetDirty("Operacoestipotarifa_N");
         }

      }

      public void gxTv_SdtOperacoes_Operacoestipotarifa_N_SetNull( )
      {
         gxTv_SdtOperacoes_Operacoestipotarifa_N = 0;
         SetDirty("Operacoestipotarifa_N");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Operacoestipotarifa_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesTarifa_N" )]
      [  XmlElement( ElementName = "OperacoesTarifa_N"   )]
      public short gxTpr_Operacoestarifa_N
      {
         get {
            return gxTv_SdtOperacoes_Operacoestarifa_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoestarifa_N = value;
            SetDirty("Operacoestarifa_N");
         }

      }

      public void gxTv_SdtOperacoes_Operacoestarifa_N_SetNull( )
      {
         gxTv_SdtOperacoes_Operacoestarifa_N = 0;
         SetDirty("Operacoestarifa_N");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Operacoestarifa_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoNome_N" )]
      [  XmlElement( ElementName = "ContratoNome_N"   )]
      public short gxTpr_Contratonome_N
      {
         get {
            return gxTv_SdtOperacoes_Contratonome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Contratonome_N = value;
            SetDirty("Contratonome_N");
         }

      }

      public void gxTv_SdtOperacoes_Contratonome_N_SetNull( )
      {
         gxTv_SdtOperacoes_Contratonome_N = 0;
         SetDirty("Contratonome_N");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Contratonome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesCreatedAt_N" )]
      [  XmlElement( ElementName = "OperacoesCreatedAt_N"   )]
      public short gxTpr_Operacoescreatedat_N
      {
         get {
            return gxTv_SdtOperacoes_Operacoescreatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoescreatedat_N = value;
            SetDirty("Operacoescreatedat_N");
         }

      }

      public void gxTv_SdtOperacoes_Operacoescreatedat_N_SetNull( )
      {
         gxTv_SdtOperacoes_Operacoescreatedat_N = 0;
         SetDirty("Operacoescreatedat_N");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Operacoescreatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesUpdateAt_N" )]
      [  XmlElement( ElementName = "OperacoesUpdateAt_N"   )]
      public short gxTpr_Operacoesupdateat_N
      {
         get {
            return gxTv_SdtOperacoes_Operacoesupdateat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoes_Operacoesupdateat_N = value;
            SetDirty("Operacoesupdateat_N");
         }

      }

      public void gxTv_SdtOperacoes_Operacoesupdateat_N_SetNull( )
      {
         gxTv_SdtOperacoes_Operacoesupdateat_N = 0;
         SetDirty("Operacoesupdateat_N");
         return  ;
      }

      public bool gxTv_SdtOperacoes_Operacoesupdateat_N_IsNull( )
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
         gxTv_SdtOperacoes_Clienterazaosocial = "";
         gxTv_SdtOperacoes_Operacoesdata = DateTime.MinValue;
         gxTv_SdtOperacoes_Operacoesstatus = "";
         gxTv_SdtOperacoes_Operacoestipotarifa = "";
         gxTv_SdtOperacoes_Contratonome = "";
         gxTv_SdtOperacoes_Operacoescreatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtOperacoes_Operacoesupdateat = (DateTime)(DateTime.MinValue);
         gxTv_SdtOperacoes_Mode = "";
         gxTv_SdtOperacoes_Clienterazaosocial_Z = "";
         gxTv_SdtOperacoes_Operacoesdata_Z = DateTime.MinValue;
         gxTv_SdtOperacoes_Operacoesstatus_Z = "";
         gxTv_SdtOperacoes_Operacoestipotarifa_Z = "";
         gxTv_SdtOperacoes_Contratonome_Z = "";
         gxTv_SdtOperacoes_Operacoescreatedat_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtOperacoes_Operacoesupdateat_Z = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "operacoes", "GeneXus.Programs.operacoes_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtOperacoes_Initialized ;
      private short gxTv_SdtOperacoes_Operacoesid_N ;
      private short gxTv_SdtOperacoes_Clienteid_N ;
      private short gxTv_SdtOperacoes_Clienterazaosocial_N ;
      private short gxTv_SdtOperacoes_Operacoesdata_N ;
      private short gxTv_SdtOperacoes_Operacoesstatus_N ;
      private short gxTv_SdtOperacoes_Operacoestaxaefetiva_N ;
      private short gxTv_SdtOperacoes_Contratoid_N ;
      private short gxTv_SdtOperacoes_Operacoestaxamora_N ;
      private short gxTv_SdtOperacoes_Operacoesfator_N ;
      private short gxTv_SdtOperacoes_Operacoestipotarifa_N ;
      private short gxTv_SdtOperacoes_Operacoestarifa_N ;
      private short gxTv_SdtOperacoes_Contratonome_N ;
      private short gxTv_SdtOperacoes_Operacoescreatedat_N ;
      private short gxTv_SdtOperacoes_Operacoesupdateat_N ;
      private int gxTv_SdtOperacoes_Operacoesid ;
      private int gxTv_SdtOperacoes_Clienteid ;
      private int gxTv_SdtOperacoes_Contratoid ;
      private int gxTv_SdtOperacoes_Operacoesid_Z ;
      private int gxTv_SdtOperacoes_Clienteid_Z ;
      private int gxTv_SdtOperacoes_Contratoid_Z ;
      private decimal gxTv_SdtOperacoes_Operacoestaxaefetiva ;
      private decimal gxTv_SdtOperacoes_Operacoestaxamora ;
      private decimal gxTv_SdtOperacoes_Operacoesfator ;
      private decimal gxTv_SdtOperacoes_Operacoestarifa ;
      private decimal gxTv_SdtOperacoes_Operacoestaxaefetiva_Z ;
      private decimal gxTv_SdtOperacoes_Operacoestaxamora_Z ;
      private decimal gxTv_SdtOperacoes_Operacoesfator_Z ;
      private decimal gxTv_SdtOperacoes_Operacoestarifa_Z ;
      private string gxTv_SdtOperacoes_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtOperacoes_Operacoescreatedat ;
      private DateTime gxTv_SdtOperacoes_Operacoesupdateat ;
      private DateTime gxTv_SdtOperacoes_Operacoescreatedat_Z ;
      private DateTime gxTv_SdtOperacoes_Operacoesupdateat_Z ;
      private DateTime datetime_STZ ;
      private DateTime gxTv_SdtOperacoes_Operacoesdata ;
      private DateTime gxTv_SdtOperacoes_Operacoesdata_Z ;
      private string gxTv_SdtOperacoes_Clienterazaosocial ;
      private string gxTv_SdtOperacoes_Operacoesstatus ;
      private string gxTv_SdtOperacoes_Operacoestipotarifa ;
      private string gxTv_SdtOperacoes_Contratonome ;
      private string gxTv_SdtOperacoes_Clienterazaosocial_Z ;
      private string gxTv_SdtOperacoes_Operacoesstatus_Z ;
      private string gxTv_SdtOperacoes_Operacoestipotarifa_Z ;
      private string gxTv_SdtOperacoes_Contratonome_Z ;
   }

   [DataContract(Name = @"Operacoes", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtOperacoes_RESTInterface : GxGenericCollectionItem<SdtOperacoes>
   {
      public SdtOperacoes_RESTInterface( ) : base()
      {
      }

      public SdtOperacoes_RESTInterface( SdtOperacoes psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "OperacoesId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Operacoesid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Operacoesid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Operacoesid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
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

      [DataMember( Name = "OperacoesData" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Operacoesdata
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Operacoesdata) ;
         }

         set {
            sdt.gxTpr_Operacoesdata = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "OperacoesStatus" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Operacoesstatus
      {
         get {
            return sdt.gxTpr_Operacoesstatus ;
         }

         set {
            sdt.gxTpr_Operacoesstatus = value;
         }

      }

      [DataMember( Name = "OperacoesTaxaEfetiva" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Operacoestaxaefetiva
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Operacoestaxaefetiva, 16, 4)) ;
         }

         set {
            sdt.gxTpr_Operacoestaxaefetiva = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ContratoId" , Order = 6 )]
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

      [DataMember( Name = "OperacoesTaxaMora" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Operacoestaxamora
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Operacoestaxamora, 16, 4)) ;
         }

         set {
            sdt.gxTpr_Operacoestaxamora = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "OperacoesFator" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Operacoesfator
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Operacoesfator, 16, 4)) ;
         }

         set {
            sdt.gxTpr_Operacoesfator = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "OperacoesTipoTarifa" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Operacoestipotarifa
      {
         get {
            return sdt.gxTpr_Operacoestipotarifa ;
         }

         set {
            sdt.gxTpr_Operacoestipotarifa = value;
         }

      }

      [DataMember( Name = "OperacoesTarifa" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Operacoestarifa
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Operacoestarifa, 15, 2)) ;
         }

         set {
            sdt.gxTpr_Operacoestarifa = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ContratoNome" , Order = 11 )]
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

      [DataMember( Name = "OperacoesCreatedAt" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Operacoescreatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Operacoescreatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Operacoescreatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "OperacoesUpdateAt" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Operacoesupdateat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Operacoesupdateat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Operacoesupdateat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      public SdtOperacoes sdt
      {
         get {
            return (SdtOperacoes)Sdt ;
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
            sdt = new SdtOperacoes() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 14 )]
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

   [DataContract(Name = @"Operacoes", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtOperacoes_RESTLInterface : GxGenericCollectionItem<SdtOperacoes>
   {
      public SdtOperacoes_RESTLInterface( ) : base()
      {
      }

      public SdtOperacoes_RESTLInterface( SdtOperacoes psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "OperacoesData" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Operacoesdata
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Operacoesdata) ;
         }

         set {
            sdt.gxTpr_Operacoesdata = DateTimeUtil.CToD2( value);
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

      public SdtOperacoes sdt
      {
         get {
            return (SdtOperacoes)Sdt ;
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
            sdt = new SdtOperacoes() ;
         }
      }

   }

}
