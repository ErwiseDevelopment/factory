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
   [XmlRoot(ElementName = "OperacoesTitulos" )]
   [XmlType(TypeName =  "OperacoesTitulos" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtOperacoesTitulos : GxSilentTrnSdt
   {
      public SdtOperacoesTitulos( )
      {
      }

      public SdtOperacoesTitulos( IGxContext context )
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

      public void Load( int AV1019OperacoesTitulosId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV1019OperacoesTitulosId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"OperacoesTitulosId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "OperacoesTitulos");
         metadata.Set("BT", "OperacoesTitulos");
         metadata.Set("PK", "[ \"OperacoesTitulosId\" ]");
         metadata.Set("PKAssigned", "[ \"OperacoesTitulosId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ClienteId\" ],\"FKMap\":[ \"SacadoId-ClienteId\" ] },{ \"FK\":[ \"OperacoesId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Operacoestitulosid_Z");
         state.Add("gxTpr_Operacoesid_Z");
         state.Add("gxTpr_Sacadoid_Z");
         state.Add("gxTpr_Sacadorazaosocial_Z");
         state.Add("gxTpr_Operacoestitulostipo_Z");
         state.Add("gxTpr_Operacoestitulosnumero_Z");
         state.Add("gxTpr_Operacoestitulosdataemissao_Z_Nullable");
         state.Add("gxTpr_Operacoestitulosdatavencimento_Z_Nullable");
         state.Add("gxTpr_Operacoestitulosvalor_Z");
         state.Add("gxTpr_Operacoestitulosliquido_Z");
         state.Add("gxTpr_Operacoestitulostaxa_Z");
         state.Add("gxTpr_Operacoestitulosstatus_Z");
         state.Add("gxTpr_Operacoestituloscreatedat_Z_Nullable");
         state.Add("gxTpr_Operacoestitulosupdatedat_Z_Nullable");
         state.Add("gxTpr_Operacoesid_N");
         state.Add("gxTpr_Sacadoid_N");
         state.Add("gxTpr_Sacadorazaosocial_N");
         state.Add("gxTpr_Operacoestitulostipo_N");
         state.Add("gxTpr_Operacoestitulosnumero_N");
         state.Add("gxTpr_Operacoestitulosdataemissao_N");
         state.Add("gxTpr_Operacoestitulosdatavencimento_N");
         state.Add("gxTpr_Operacoestitulosvalor_N");
         state.Add("gxTpr_Operacoestitulosliquido_N");
         state.Add("gxTpr_Operacoestitulostaxa_N");
         state.Add("gxTpr_Operacoestitulosstatus_N");
         state.Add("gxTpr_Operacoestituloscreatedat_N");
         state.Add("gxTpr_Operacoestitulosupdatedat_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtOperacoesTitulos sdt;
         sdt = (SdtOperacoesTitulos)(source);
         gxTv_SdtOperacoesTitulos_Operacoestitulosid = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosid ;
         gxTv_SdtOperacoesTitulos_Operacoesid = sdt.gxTv_SdtOperacoesTitulos_Operacoesid ;
         gxTv_SdtOperacoesTitulos_Sacadoid = sdt.gxTv_SdtOperacoesTitulos_Sacadoid ;
         gxTv_SdtOperacoesTitulos_Sacadorazaosocial = sdt.gxTv_SdtOperacoesTitulos_Sacadorazaosocial ;
         gxTv_SdtOperacoesTitulos_Operacoestitulostipo = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulostipo ;
         gxTv_SdtOperacoesTitulos_Operacoestitulosnumero = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosnumero ;
         gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao ;
         gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento ;
         gxTv_SdtOperacoesTitulos_Operacoestitulosvalor = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosvalor ;
         gxTv_SdtOperacoesTitulos_Operacoestitulosliquido = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosliquido ;
         gxTv_SdtOperacoesTitulos_Operacoestitulostaxa = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulostaxa ;
         gxTv_SdtOperacoesTitulos_Operacoestitulosstatus = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosstatus ;
         gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat = sdt.gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat ;
         gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat ;
         gxTv_SdtOperacoesTitulos_Mode = sdt.gxTv_SdtOperacoesTitulos_Mode ;
         gxTv_SdtOperacoesTitulos_Initialized = sdt.gxTv_SdtOperacoesTitulos_Initialized ;
         gxTv_SdtOperacoesTitulos_Operacoestitulosid_Z = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosid_Z ;
         gxTv_SdtOperacoesTitulos_Operacoesid_Z = sdt.gxTv_SdtOperacoesTitulos_Operacoesid_Z ;
         gxTv_SdtOperacoesTitulos_Sacadoid_Z = sdt.gxTv_SdtOperacoesTitulos_Sacadoid_Z ;
         gxTv_SdtOperacoesTitulos_Sacadorazaosocial_Z = sdt.gxTv_SdtOperacoesTitulos_Sacadorazaosocial_Z ;
         gxTv_SdtOperacoesTitulos_Operacoestitulostipo_Z = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulostipo_Z ;
         gxTv_SdtOperacoesTitulos_Operacoestitulosnumero_Z = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosnumero_Z ;
         gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao_Z = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao_Z ;
         gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento_Z = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento_Z ;
         gxTv_SdtOperacoesTitulos_Operacoestitulosvalor_Z = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosvalor_Z ;
         gxTv_SdtOperacoesTitulos_Operacoestitulosliquido_Z = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosliquido_Z ;
         gxTv_SdtOperacoesTitulos_Operacoestitulostaxa_Z = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulostaxa_Z ;
         gxTv_SdtOperacoesTitulos_Operacoestitulosstatus_Z = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosstatus_Z ;
         gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat_Z = sdt.gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat_Z ;
         gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat_Z = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat_Z ;
         gxTv_SdtOperacoesTitulos_Operacoesid_N = sdt.gxTv_SdtOperacoesTitulos_Operacoesid_N ;
         gxTv_SdtOperacoesTitulos_Sacadoid_N = sdt.gxTv_SdtOperacoesTitulos_Sacadoid_N ;
         gxTv_SdtOperacoesTitulos_Sacadorazaosocial_N = sdt.gxTv_SdtOperacoesTitulos_Sacadorazaosocial_N ;
         gxTv_SdtOperacoesTitulos_Operacoestitulostipo_N = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulostipo_N ;
         gxTv_SdtOperacoesTitulos_Operacoestitulosnumero_N = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosnumero_N ;
         gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao_N = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao_N ;
         gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento_N = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento_N ;
         gxTv_SdtOperacoesTitulos_Operacoestitulosvalor_N = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosvalor_N ;
         gxTv_SdtOperacoesTitulos_Operacoestitulosliquido_N = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosliquido_N ;
         gxTv_SdtOperacoesTitulos_Operacoestitulostaxa_N = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulostaxa_N ;
         gxTv_SdtOperacoesTitulos_Operacoestitulosstatus_N = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosstatus_N ;
         gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat_N = sdt.gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat_N ;
         gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat_N = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat_N ;
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
         AddObjectProperty("OperacoesTitulosId", gxTv_SdtOperacoesTitulos_Operacoestitulosid, false, includeNonInitialized);
         AddObjectProperty("OperacoesId", gxTv_SdtOperacoesTitulos_Operacoesid, false, includeNonInitialized);
         AddObjectProperty("OperacoesId_N", gxTv_SdtOperacoesTitulos_Operacoesid_N, false, includeNonInitialized);
         AddObjectProperty("SacadoId", gxTv_SdtOperacoesTitulos_Sacadoid, false, includeNonInitialized);
         AddObjectProperty("SacadoId_N", gxTv_SdtOperacoesTitulos_Sacadoid_N, false, includeNonInitialized);
         AddObjectProperty("SacadoRazaoSocial", gxTv_SdtOperacoesTitulos_Sacadorazaosocial, false, includeNonInitialized);
         AddObjectProperty("SacadoRazaoSocial_N", gxTv_SdtOperacoesTitulos_Sacadorazaosocial_N, false, includeNonInitialized);
         AddObjectProperty("OperacoesTitulosTipo", gxTv_SdtOperacoesTitulos_Operacoestitulostipo, false, includeNonInitialized);
         AddObjectProperty("OperacoesTitulosTipo_N", gxTv_SdtOperacoesTitulos_Operacoestitulostipo_N, false, includeNonInitialized);
         AddObjectProperty("OperacoesTitulosNumero", gxTv_SdtOperacoesTitulos_Operacoestitulosnumero, false, includeNonInitialized);
         AddObjectProperty("OperacoesTitulosNumero_N", gxTv_SdtOperacoesTitulos_Operacoestitulosnumero_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("OperacoesTitulosDataEmissao", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("OperacoesTitulosDataEmissao_N", gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("OperacoesTitulosDataVencimento", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("OperacoesTitulosDataVencimento_N", gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento_N, false, includeNonInitialized);
         AddObjectProperty("OperacoesTitulosValor", StringUtil.LTrim( StringUtil.Str( gxTv_SdtOperacoesTitulos_Operacoestitulosvalor, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("OperacoesTitulosValor_N", gxTv_SdtOperacoesTitulos_Operacoestitulosvalor_N, false, includeNonInitialized);
         AddObjectProperty("OperacoesTitulosLiquido", StringUtil.LTrim( StringUtil.Str( gxTv_SdtOperacoesTitulos_Operacoestitulosliquido, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("OperacoesTitulosLiquido_N", gxTv_SdtOperacoesTitulos_Operacoestitulosliquido_N, false, includeNonInitialized);
         AddObjectProperty("OperacoesTitulosTaxa", StringUtil.LTrim( StringUtil.Str( gxTv_SdtOperacoesTitulos_Operacoestitulostaxa, 16, 4)), false, includeNonInitialized);
         AddObjectProperty("OperacoesTitulosTaxa_N", gxTv_SdtOperacoesTitulos_Operacoestitulostaxa_N, false, includeNonInitialized);
         AddObjectProperty("OperacoesTitulosStatus", gxTv_SdtOperacoesTitulos_Operacoestitulosstatus, false, includeNonInitialized);
         AddObjectProperty("OperacoesTitulosStatus_N", gxTv_SdtOperacoesTitulos_Operacoestitulosstatus_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat;
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
         AddObjectProperty("OperacoesTitulosCreatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("OperacoesTitulosCreatedAt_N", gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat;
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
         AddObjectProperty("OperacoesTitulosUpdatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("OperacoesTitulosUpdatedAt_N", gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtOperacoesTitulos_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtOperacoesTitulos_Initialized, false, includeNonInitialized);
            AddObjectProperty("OperacoesTitulosId_Z", gxTv_SdtOperacoesTitulos_Operacoestitulosid_Z, false, includeNonInitialized);
            AddObjectProperty("OperacoesId_Z", gxTv_SdtOperacoesTitulos_Operacoesid_Z, false, includeNonInitialized);
            AddObjectProperty("SacadoId_Z", gxTv_SdtOperacoesTitulos_Sacadoid_Z, false, includeNonInitialized);
            AddObjectProperty("SacadoRazaoSocial_Z", gxTv_SdtOperacoesTitulos_Sacadorazaosocial_Z, false, includeNonInitialized);
            AddObjectProperty("OperacoesTitulosTipo_Z", gxTv_SdtOperacoesTitulos_Operacoestitulostipo_Z, false, includeNonInitialized);
            AddObjectProperty("OperacoesTitulosNumero_Z", gxTv_SdtOperacoesTitulos_Operacoestitulosnumero_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("OperacoesTitulosDataEmissao_Z", sDateCnv, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("OperacoesTitulosDataVencimento_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("OperacoesTitulosValor_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtOperacoesTitulos_Operacoestitulosvalor_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("OperacoesTitulosLiquido_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtOperacoesTitulos_Operacoestitulosliquido_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("OperacoesTitulosTaxa_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtOperacoesTitulos_Operacoestitulostaxa_Z, 16, 4)), false, includeNonInitialized);
            AddObjectProperty("OperacoesTitulosStatus_Z", gxTv_SdtOperacoesTitulos_Operacoestitulosstatus_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat_Z;
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
            AddObjectProperty("OperacoesTitulosCreatedAt_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat_Z;
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
            AddObjectProperty("OperacoesTitulosUpdatedAt_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("OperacoesId_N", gxTv_SdtOperacoesTitulos_Operacoesid_N, false, includeNonInitialized);
            AddObjectProperty("SacadoId_N", gxTv_SdtOperacoesTitulos_Sacadoid_N, false, includeNonInitialized);
            AddObjectProperty("SacadoRazaoSocial_N", gxTv_SdtOperacoesTitulos_Sacadorazaosocial_N, false, includeNonInitialized);
            AddObjectProperty("OperacoesTitulosTipo_N", gxTv_SdtOperacoesTitulos_Operacoestitulostipo_N, false, includeNonInitialized);
            AddObjectProperty("OperacoesTitulosNumero_N", gxTv_SdtOperacoesTitulos_Operacoestitulosnumero_N, false, includeNonInitialized);
            AddObjectProperty("OperacoesTitulosDataEmissao_N", gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao_N, false, includeNonInitialized);
            AddObjectProperty("OperacoesTitulosDataVencimento_N", gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento_N, false, includeNonInitialized);
            AddObjectProperty("OperacoesTitulosValor_N", gxTv_SdtOperacoesTitulos_Operacoestitulosvalor_N, false, includeNonInitialized);
            AddObjectProperty("OperacoesTitulosLiquido_N", gxTv_SdtOperacoesTitulos_Operacoestitulosliquido_N, false, includeNonInitialized);
            AddObjectProperty("OperacoesTitulosTaxa_N", gxTv_SdtOperacoesTitulos_Operacoestitulostaxa_N, false, includeNonInitialized);
            AddObjectProperty("OperacoesTitulosStatus_N", gxTv_SdtOperacoesTitulos_Operacoestitulosstatus_N, false, includeNonInitialized);
            AddObjectProperty("OperacoesTitulosCreatedAt_N", gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat_N, false, includeNonInitialized);
            AddObjectProperty("OperacoesTitulosUpdatedAt_N", gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtOperacoesTitulos sdt )
      {
         if ( sdt.IsDirty("OperacoesTitulosId") )
         {
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulosid = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosid ;
         }
         if ( sdt.IsDirty("OperacoesId") )
         {
            gxTv_SdtOperacoesTitulos_Operacoesid_N = (short)(sdt.gxTv_SdtOperacoesTitulos_Operacoesid_N);
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoesid = sdt.gxTv_SdtOperacoesTitulos_Operacoesid ;
         }
         if ( sdt.IsDirty("SacadoId") )
         {
            gxTv_SdtOperacoesTitulos_Sacadoid_N = (short)(sdt.gxTv_SdtOperacoesTitulos_Sacadoid_N);
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Sacadoid = sdt.gxTv_SdtOperacoesTitulos_Sacadoid ;
         }
         if ( sdt.IsDirty("SacadoRazaoSocial") )
         {
            gxTv_SdtOperacoesTitulos_Sacadorazaosocial_N = (short)(sdt.gxTv_SdtOperacoesTitulos_Sacadorazaosocial_N);
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Sacadorazaosocial = sdt.gxTv_SdtOperacoesTitulos_Sacadorazaosocial ;
         }
         if ( sdt.IsDirty("OperacoesTitulosTipo") )
         {
            gxTv_SdtOperacoesTitulos_Operacoestitulostipo_N = (short)(sdt.gxTv_SdtOperacoesTitulos_Operacoestitulostipo_N);
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulostipo = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulostipo ;
         }
         if ( sdt.IsDirty("OperacoesTitulosNumero") )
         {
            gxTv_SdtOperacoesTitulos_Operacoestitulosnumero_N = (short)(sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosnumero_N);
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulosnumero = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosnumero ;
         }
         if ( sdt.IsDirty("OperacoesTitulosDataEmissao") )
         {
            gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao_N = (short)(sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao_N);
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao ;
         }
         if ( sdt.IsDirty("OperacoesTitulosDataVencimento") )
         {
            gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento_N = (short)(sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento_N);
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento ;
         }
         if ( sdt.IsDirty("OperacoesTitulosValor") )
         {
            gxTv_SdtOperacoesTitulos_Operacoestitulosvalor_N = (short)(sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosvalor_N);
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulosvalor = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosvalor ;
         }
         if ( sdt.IsDirty("OperacoesTitulosLiquido") )
         {
            gxTv_SdtOperacoesTitulos_Operacoestitulosliquido_N = (short)(sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosliquido_N);
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulosliquido = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosliquido ;
         }
         if ( sdt.IsDirty("OperacoesTitulosTaxa") )
         {
            gxTv_SdtOperacoesTitulos_Operacoestitulostaxa_N = (short)(sdt.gxTv_SdtOperacoesTitulos_Operacoestitulostaxa_N);
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulostaxa = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulostaxa ;
         }
         if ( sdt.IsDirty("OperacoesTitulosStatus") )
         {
            gxTv_SdtOperacoesTitulos_Operacoestitulosstatus_N = (short)(sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosstatus_N);
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulosstatus = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosstatus ;
         }
         if ( sdt.IsDirty("OperacoesTitulosCreatedAt") )
         {
            gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat_N = (short)(sdt.gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat_N);
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat = sdt.gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat ;
         }
         if ( sdt.IsDirty("OperacoesTitulosUpdatedAt") )
         {
            gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat_N = (short)(sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat_N);
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat = sdt.gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "OperacoesTitulosId" )]
      [  XmlElement( ElementName = "OperacoesTitulosId"   )]
      public int gxTpr_Operacoestitulosid
      {
         get {
            return gxTv_SdtOperacoesTitulos_Operacoestitulosid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtOperacoesTitulos_Operacoestitulosid != value )
            {
               gxTv_SdtOperacoesTitulos_Mode = "INS";
               this.gxTv_SdtOperacoesTitulos_Operacoestitulosid_Z_SetNull( );
               this.gxTv_SdtOperacoesTitulos_Operacoesid_Z_SetNull( );
               this.gxTv_SdtOperacoesTitulos_Sacadoid_Z_SetNull( );
               this.gxTv_SdtOperacoesTitulos_Sacadorazaosocial_Z_SetNull( );
               this.gxTv_SdtOperacoesTitulos_Operacoestitulostipo_Z_SetNull( );
               this.gxTv_SdtOperacoesTitulos_Operacoestitulosnumero_Z_SetNull( );
               this.gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao_Z_SetNull( );
               this.gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento_Z_SetNull( );
               this.gxTv_SdtOperacoesTitulos_Operacoestitulosvalor_Z_SetNull( );
               this.gxTv_SdtOperacoesTitulos_Operacoestitulosliquido_Z_SetNull( );
               this.gxTv_SdtOperacoesTitulos_Operacoestitulostaxa_Z_SetNull( );
               this.gxTv_SdtOperacoesTitulos_Operacoestitulosstatus_Z_SetNull( );
               this.gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat_Z_SetNull( );
               this.gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat_Z_SetNull( );
            }
            gxTv_SdtOperacoesTitulos_Operacoestitulosid = value;
            SetDirty("Operacoestitulosid");
         }

      }

      [  SoapElement( ElementName = "OperacoesId" )]
      [  XmlElement( ElementName = "OperacoesId"   )]
      public int gxTpr_Operacoesid
      {
         get {
            return gxTv_SdtOperacoesTitulos_Operacoesid ;
         }

         set {
            gxTv_SdtOperacoesTitulos_Operacoesid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoesid = value;
            SetDirty("Operacoesid");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Operacoesid_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Operacoesid_N = 1;
         gxTv_SdtOperacoesTitulos_Operacoesid = 0;
         SetDirty("Operacoesid");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Operacoesid_IsNull( )
      {
         return (gxTv_SdtOperacoesTitulos_Operacoesid_N==1) ;
      }

      [  SoapElement( ElementName = "SacadoId" )]
      [  XmlElement( ElementName = "SacadoId"   )]
      public int gxTpr_Sacadoid
      {
         get {
            return gxTv_SdtOperacoesTitulos_Sacadoid ;
         }

         set {
            gxTv_SdtOperacoesTitulos_Sacadoid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Sacadoid = value;
            SetDirty("Sacadoid");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Sacadoid_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Sacadoid_N = 1;
         gxTv_SdtOperacoesTitulos_Sacadoid = 0;
         SetDirty("Sacadoid");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Sacadoid_IsNull( )
      {
         return (gxTv_SdtOperacoesTitulos_Sacadoid_N==1) ;
      }

      [  SoapElement( ElementName = "SacadoRazaoSocial" )]
      [  XmlElement( ElementName = "SacadoRazaoSocial"   )]
      public string gxTpr_Sacadorazaosocial
      {
         get {
            return gxTv_SdtOperacoesTitulos_Sacadorazaosocial ;
         }

         set {
            gxTv_SdtOperacoesTitulos_Sacadorazaosocial_N = 0;
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Sacadorazaosocial = value;
            SetDirty("Sacadorazaosocial");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Sacadorazaosocial_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Sacadorazaosocial_N = 1;
         gxTv_SdtOperacoesTitulos_Sacadorazaosocial = "";
         SetDirty("Sacadorazaosocial");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Sacadorazaosocial_IsNull( )
      {
         return (gxTv_SdtOperacoesTitulos_Sacadorazaosocial_N==1) ;
      }

      [  SoapElement( ElementName = "OperacoesTitulosTipo" )]
      [  XmlElement( ElementName = "OperacoesTitulosTipo"   )]
      public string gxTpr_Operacoestitulostipo
      {
         get {
            return gxTv_SdtOperacoesTitulos_Operacoestitulostipo ;
         }

         set {
            gxTv_SdtOperacoesTitulos_Operacoestitulostipo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulostipo = value;
            SetDirty("Operacoestitulostipo");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Operacoestitulostipo_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Operacoestitulostipo_N = 1;
         gxTv_SdtOperacoesTitulos_Operacoestitulostipo = "";
         SetDirty("Operacoestitulostipo");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Operacoestitulostipo_IsNull( )
      {
         return (gxTv_SdtOperacoesTitulos_Operacoestitulostipo_N==1) ;
      }

      [  SoapElement( ElementName = "OperacoesTitulosNumero" )]
      [  XmlElement( ElementName = "OperacoesTitulosNumero"   )]
      public int gxTpr_Operacoestitulosnumero
      {
         get {
            return gxTv_SdtOperacoesTitulos_Operacoestitulosnumero ;
         }

         set {
            gxTv_SdtOperacoesTitulos_Operacoestitulosnumero_N = 0;
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulosnumero = value;
            SetDirty("Operacoestitulosnumero");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Operacoestitulosnumero_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Operacoestitulosnumero_N = 1;
         gxTv_SdtOperacoesTitulos_Operacoestitulosnumero = 0;
         SetDirty("Operacoestitulosnumero");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Operacoestitulosnumero_IsNull( )
      {
         return (gxTv_SdtOperacoesTitulos_Operacoestitulosnumero_N==1) ;
      }

      [  SoapElement( ElementName = "OperacoesTitulosDataEmissao" )]
      [  XmlElement( ElementName = "OperacoesTitulosDataEmissao"  , IsNullable=true )]
      public string gxTpr_Operacoestitulosdataemissao_Nullable
      {
         get {
            if ( gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao).value ;
         }

         set {
            gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao = DateTime.MinValue;
            else
               gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Operacoestitulosdataemissao
      {
         get {
            return gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao ;
         }

         set {
            gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao = value;
            SetDirty("Operacoestitulosdataemissao");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao_N = 1;
         gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao = (DateTime)(DateTime.MinValue);
         SetDirty("Operacoestitulosdataemissao");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao_IsNull( )
      {
         return (gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao_N==1) ;
      }

      [  SoapElement( ElementName = "OperacoesTitulosDataVencimento" )]
      [  XmlElement( ElementName = "OperacoesTitulosDataVencimento"  , IsNullable=true )]
      public string gxTpr_Operacoestitulosdatavencimento_Nullable
      {
         get {
            if ( gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento).value ;
         }

         set {
            gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento = DateTime.MinValue;
            else
               gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Operacoestitulosdatavencimento
      {
         get {
            return gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento ;
         }

         set {
            gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento = value;
            SetDirty("Operacoestitulosdatavencimento");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento_N = 1;
         gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento = (DateTime)(DateTime.MinValue);
         SetDirty("Operacoestitulosdatavencimento");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento_IsNull( )
      {
         return (gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento_N==1) ;
      }

      [  SoapElement( ElementName = "OperacoesTitulosValor" )]
      [  XmlElement( ElementName = "OperacoesTitulosValor"   )]
      public decimal gxTpr_Operacoestitulosvalor
      {
         get {
            return gxTv_SdtOperacoesTitulos_Operacoestitulosvalor ;
         }

         set {
            gxTv_SdtOperacoesTitulos_Operacoestitulosvalor_N = 0;
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulosvalor = value;
            SetDirty("Operacoestitulosvalor");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Operacoestitulosvalor_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Operacoestitulosvalor_N = 1;
         gxTv_SdtOperacoesTitulos_Operacoestitulosvalor = 0;
         SetDirty("Operacoestitulosvalor");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Operacoestitulosvalor_IsNull( )
      {
         return (gxTv_SdtOperacoesTitulos_Operacoestitulosvalor_N==1) ;
      }

      [  SoapElement( ElementName = "OperacoesTitulosLiquido" )]
      [  XmlElement( ElementName = "OperacoesTitulosLiquido"   )]
      public decimal gxTpr_Operacoestitulosliquido
      {
         get {
            return gxTv_SdtOperacoesTitulos_Operacoestitulosliquido ;
         }

         set {
            gxTv_SdtOperacoesTitulos_Operacoestitulosliquido_N = 0;
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulosliquido = value;
            SetDirty("Operacoestitulosliquido");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Operacoestitulosliquido_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Operacoestitulosliquido_N = 1;
         gxTv_SdtOperacoesTitulos_Operacoestitulosliquido = 0;
         SetDirty("Operacoestitulosliquido");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Operacoestitulosliquido_IsNull( )
      {
         return (gxTv_SdtOperacoesTitulos_Operacoestitulosliquido_N==1) ;
      }

      [  SoapElement( ElementName = "OperacoesTitulosTaxa" )]
      [  XmlElement( ElementName = "OperacoesTitulosTaxa"   )]
      public decimal gxTpr_Operacoestitulostaxa
      {
         get {
            return gxTv_SdtOperacoesTitulos_Operacoestitulostaxa ;
         }

         set {
            gxTv_SdtOperacoesTitulos_Operacoestitulostaxa_N = 0;
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulostaxa = value;
            SetDirty("Operacoestitulostaxa");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Operacoestitulostaxa_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Operacoestitulostaxa_N = 1;
         gxTv_SdtOperacoesTitulos_Operacoestitulostaxa = 0;
         SetDirty("Operacoestitulostaxa");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Operacoestitulostaxa_IsNull( )
      {
         return (gxTv_SdtOperacoesTitulos_Operacoestitulostaxa_N==1) ;
      }

      [  SoapElement( ElementName = "OperacoesTitulosStatus" )]
      [  XmlElement( ElementName = "OperacoesTitulosStatus"   )]
      public string gxTpr_Operacoestitulosstatus
      {
         get {
            return gxTv_SdtOperacoesTitulos_Operacoestitulosstatus ;
         }

         set {
            gxTv_SdtOperacoesTitulos_Operacoestitulosstatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulosstatus = value;
            SetDirty("Operacoestitulosstatus");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Operacoestitulosstatus_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Operacoestitulosstatus_N = 1;
         gxTv_SdtOperacoesTitulos_Operacoestitulosstatus = "";
         SetDirty("Operacoestitulosstatus");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Operacoestitulosstatus_IsNull( )
      {
         return (gxTv_SdtOperacoesTitulos_Operacoestitulosstatus_N==1) ;
      }

      [  SoapElement( ElementName = "OperacoesTitulosCreatedAt" )]
      [  XmlElement( ElementName = "OperacoesTitulosCreatedAt"  , IsNullable=true )]
      public string gxTpr_Operacoestituloscreatedat_Nullable
      {
         get {
            if ( gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat).value ;
         }

         set {
            gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat = DateTime.MinValue;
            else
               gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Operacoestituloscreatedat
      {
         get {
            return gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat ;
         }

         set {
            gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat = value;
            SetDirty("Operacoestituloscreatedat");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat_N = 1;
         gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Operacoestituloscreatedat");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat_IsNull( )
      {
         return (gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat_N==1) ;
      }

      [  SoapElement( ElementName = "OperacoesTitulosUpdatedAt" )]
      [  XmlElement( ElementName = "OperacoesTitulosUpdatedAt"  , IsNullable=true )]
      public string gxTpr_Operacoestitulosupdatedat_Nullable
      {
         get {
            if ( gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat).value ;
         }

         set {
            gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat = DateTime.MinValue;
            else
               gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Operacoestitulosupdatedat
      {
         get {
            return gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat ;
         }

         set {
            gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat = value;
            SetDirty("Operacoestitulosupdatedat");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat_N = 1;
         gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Operacoestitulosupdatedat");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat_IsNull( )
      {
         return (gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtOperacoesTitulos_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Mode_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtOperacoesTitulos_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Initialized_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesTitulosId_Z" )]
      [  XmlElement( ElementName = "OperacoesTitulosId_Z"   )]
      public int gxTpr_Operacoestitulosid_Z
      {
         get {
            return gxTv_SdtOperacoesTitulos_Operacoestitulosid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulosid_Z = value;
            SetDirty("Operacoestitulosid_Z");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Operacoestitulosid_Z_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Operacoestitulosid_Z = 0;
         SetDirty("Operacoestitulosid_Z");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Operacoestitulosid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesId_Z" )]
      [  XmlElement( ElementName = "OperacoesId_Z"   )]
      public int gxTpr_Operacoesid_Z
      {
         get {
            return gxTv_SdtOperacoesTitulos_Operacoesid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoesid_Z = value;
            SetDirty("Operacoesid_Z");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Operacoesid_Z_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Operacoesid_Z = 0;
         SetDirty("Operacoesid_Z");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Operacoesid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SacadoId_Z" )]
      [  XmlElement( ElementName = "SacadoId_Z"   )]
      public int gxTpr_Sacadoid_Z
      {
         get {
            return gxTv_SdtOperacoesTitulos_Sacadoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Sacadoid_Z = value;
            SetDirty("Sacadoid_Z");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Sacadoid_Z_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Sacadoid_Z = 0;
         SetDirty("Sacadoid_Z");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Sacadoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SacadoRazaoSocial_Z" )]
      [  XmlElement( ElementName = "SacadoRazaoSocial_Z"   )]
      public string gxTpr_Sacadorazaosocial_Z
      {
         get {
            return gxTv_SdtOperacoesTitulos_Sacadorazaosocial_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Sacadorazaosocial_Z = value;
            SetDirty("Sacadorazaosocial_Z");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Sacadorazaosocial_Z_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Sacadorazaosocial_Z = "";
         SetDirty("Sacadorazaosocial_Z");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Sacadorazaosocial_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesTitulosTipo_Z" )]
      [  XmlElement( ElementName = "OperacoesTitulosTipo_Z"   )]
      public string gxTpr_Operacoestitulostipo_Z
      {
         get {
            return gxTv_SdtOperacoesTitulos_Operacoestitulostipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulostipo_Z = value;
            SetDirty("Operacoestitulostipo_Z");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Operacoestitulostipo_Z_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Operacoestitulostipo_Z = "";
         SetDirty("Operacoestitulostipo_Z");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Operacoestitulostipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesTitulosNumero_Z" )]
      [  XmlElement( ElementName = "OperacoesTitulosNumero_Z"   )]
      public int gxTpr_Operacoestitulosnumero_Z
      {
         get {
            return gxTv_SdtOperacoesTitulos_Operacoestitulosnumero_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulosnumero_Z = value;
            SetDirty("Operacoestitulosnumero_Z");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Operacoestitulosnumero_Z_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Operacoestitulosnumero_Z = 0;
         SetDirty("Operacoestitulosnumero_Z");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Operacoestitulosnumero_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesTitulosDataEmissao_Z" )]
      [  XmlElement( ElementName = "OperacoesTitulosDataEmissao_Z"  , IsNullable=true )]
      public string gxTpr_Operacoestitulosdataemissao_Z_Nullable
      {
         get {
            if ( gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao_Z = DateTime.MinValue;
            else
               gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Operacoestitulosdataemissao_Z
      {
         get {
            return gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao_Z = value;
            SetDirty("Operacoestitulosdataemissao_Z");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao_Z_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Operacoestitulosdataemissao_Z");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesTitulosDataVencimento_Z" )]
      [  XmlElement( ElementName = "OperacoesTitulosDataVencimento_Z"  , IsNullable=true )]
      public string gxTpr_Operacoestitulosdatavencimento_Z_Nullable
      {
         get {
            if ( gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento_Z = DateTime.MinValue;
            else
               gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Operacoestitulosdatavencimento_Z
      {
         get {
            return gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento_Z = value;
            SetDirty("Operacoestitulosdatavencimento_Z");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento_Z_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Operacoestitulosdatavencimento_Z");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesTitulosValor_Z" )]
      [  XmlElement( ElementName = "OperacoesTitulosValor_Z"   )]
      public decimal gxTpr_Operacoestitulosvalor_Z
      {
         get {
            return gxTv_SdtOperacoesTitulos_Operacoestitulosvalor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulosvalor_Z = value;
            SetDirty("Operacoestitulosvalor_Z");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Operacoestitulosvalor_Z_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Operacoestitulosvalor_Z = 0;
         SetDirty("Operacoestitulosvalor_Z");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Operacoestitulosvalor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesTitulosLiquido_Z" )]
      [  XmlElement( ElementName = "OperacoesTitulosLiquido_Z"   )]
      public decimal gxTpr_Operacoestitulosliquido_Z
      {
         get {
            return gxTv_SdtOperacoesTitulos_Operacoestitulosliquido_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulosliquido_Z = value;
            SetDirty("Operacoestitulosliquido_Z");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Operacoestitulosliquido_Z_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Operacoestitulosliquido_Z = 0;
         SetDirty("Operacoestitulosliquido_Z");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Operacoestitulosliquido_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesTitulosTaxa_Z" )]
      [  XmlElement( ElementName = "OperacoesTitulosTaxa_Z"   )]
      public decimal gxTpr_Operacoestitulostaxa_Z
      {
         get {
            return gxTv_SdtOperacoesTitulos_Operacoestitulostaxa_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulostaxa_Z = value;
            SetDirty("Operacoestitulostaxa_Z");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Operacoestitulostaxa_Z_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Operacoestitulostaxa_Z = 0;
         SetDirty("Operacoestitulostaxa_Z");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Operacoestitulostaxa_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesTitulosStatus_Z" )]
      [  XmlElement( ElementName = "OperacoesTitulosStatus_Z"   )]
      public string gxTpr_Operacoestitulosstatus_Z
      {
         get {
            return gxTv_SdtOperacoesTitulos_Operacoestitulosstatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulosstatus_Z = value;
            SetDirty("Operacoestitulosstatus_Z");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Operacoestitulosstatus_Z_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Operacoestitulosstatus_Z = "";
         SetDirty("Operacoestitulosstatus_Z");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Operacoestitulosstatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesTitulosCreatedAt_Z" )]
      [  XmlElement( ElementName = "OperacoesTitulosCreatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Operacoestituloscreatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Operacoestituloscreatedat_Z
      {
         get {
            return gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat_Z = value;
            SetDirty("Operacoestituloscreatedat_Z");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat_Z_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Operacoestituloscreatedat_Z");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesTitulosUpdatedAt_Z" )]
      [  XmlElement( ElementName = "OperacoesTitulosUpdatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Operacoestitulosupdatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Operacoestitulosupdatedat_Z
      {
         get {
            return gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat_Z = value;
            SetDirty("Operacoestitulosupdatedat_Z");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat_Z_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Operacoestitulosupdatedat_Z");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesId_N" )]
      [  XmlElement( ElementName = "OperacoesId_N"   )]
      public short gxTpr_Operacoesid_N
      {
         get {
            return gxTv_SdtOperacoesTitulos_Operacoesid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoesid_N = value;
            SetDirty("Operacoesid_N");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Operacoesid_N_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Operacoesid_N = 0;
         SetDirty("Operacoesid_N");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Operacoesid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SacadoId_N" )]
      [  XmlElement( ElementName = "SacadoId_N"   )]
      public short gxTpr_Sacadoid_N
      {
         get {
            return gxTv_SdtOperacoesTitulos_Sacadoid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Sacadoid_N = value;
            SetDirty("Sacadoid_N");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Sacadoid_N_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Sacadoid_N = 0;
         SetDirty("Sacadoid_N");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Sacadoid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SacadoRazaoSocial_N" )]
      [  XmlElement( ElementName = "SacadoRazaoSocial_N"   )]
      public short gxTpr_Sacadorazaosocial_N
      {
         get {
            return gxTv_SdtOperacoesTitulos_Sacadorazaosocial_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Sacadorazaosocial_N = value;
            SetDirty("Sacadorazaosocial_N");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Sacadorazaosocial_N_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Sacadorazaosocial_N = 0;
         SetDirty("Sacadorazaosocial_N");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Sacadorazaosocial_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesTitulosTipo_N" )]
      [  XmlElement( ElementName = "OperacoesTitulosTipo_N"   )]
      public short gxTpr_Operacoestitulostipo_N
      {
         get {
            return gxTv_SdtOperacoesTitulos_Operacoestitulostipo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulostipo_N = value;
            SetDirty("Operacoestitulostipo_N");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Operacoestitulostipo_N_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Operacoestitulostipo_N = 0;
         SetDirty("Operacoestitulostipo_N");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Operacoestitulostipo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesTitulosNumero_N" )]
      [  XmlElement( ElementName = "OperacoesTitulosNumero_N"   )]
      public short gxTpr_Operacoestitulosnumero_N
      {
         get {
            return gxTv_SdtOperacoesTitulos_Operacoestitulosnumero_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulosnumero_N = value;
            SetDirty("Operacoestitulosnumero_N");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Operacoestitulosnumero_N_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Operacoestitulosnumero_N = 0;
         SetDirty("Operacoestitulosnumero_N");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Operacoestitulosnumero_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesTitulosDataEmissao_N" )]
      [  XmlElement( ElementName = "OperacoesTitulosDataEmissao_N"   )]
      public short gxTpr_Operacoestitulosdataemissao_N
      {
         get {
            return gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao_N = value;
            SetDirty("Operacoestitulosdataemissao_N");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao_N_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao_N = 0;
         SetDirty("Operacoestitulosdataemissao_N");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesTitulosDataVencimento_N" )]
      [  XmlElement( ElementName = "OperacoesTitulosDataVencimento_N"   )]
      public short gxTpr_Operacoestitulosdatavencimento_N
      {
         get {
            return gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento_N = value;
            SetDirty("Operacoestitulosdatavencimento_N");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento_N_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento_N = 0;
         SetDirty("Operacoestitulosdatavencimento_N");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesTitulosValor_N" )]
      [  XmlElement( ElementName = "OperacoesTitulosValor_N"   )]
      public short gxTpr_Operacoestitulosvalor_N
      {
         get {
            return gxTv_SdtOperacoesTitulos_Operacoestitulosvalor_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulosvalor_N = value;
            SetDirty("Operacoestitulosvalor_N");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Operacoestitulosvalor_N_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Operacoestitulosvalor_N = 0;
         SetDirty("Operacoestitulosvalor_N");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Operacoestitulosvalor_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesTitulosLiquido_N" )]
      [  XmlElement( ElementName = "OperacoesTitulosLiquido_N"   )]
      public short gxTpr_Operacoestitulosliquido_N
      {
         get {
            return gxTv_SdtOperacoesTitulos_Operacoestitulosliquido_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulosliquido_N = value;
            SetDirty("Operacoestitulosliquido_N");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Operacoestitulosliquido_N_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Operacoestitulosliquido_N = 0;
         SetDirty("Operacoestitulosliquido_N");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Operacoestitulosliquido_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesTitulosTaxa_N" )]
      [  XmlElement( ElementName = "OperacoesTitulosTaxa_N"   )]
      public short gxTpr_Operacoestitulostaxa_N
      {
         get {
            return gxTv_SdtOperacoesTitulos_Operacoestitulostaxa_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulostaxa_N = value;
            SetDirty("Operacoestitulostaxa_N");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Operacoestitulostaxa_N_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Operacoestitulostaxa_N = 0;
         SetDirty("Operacoestitulostaxa_N");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Operacoestitulostaxa_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesTitulosStatus_N" )]
      [  XmlElement( ElementName = "OperacoesTitulosStatus_N"   )]
      public short gxTpr_Operacoestitulosstatus_N
      {
         get {
            return gxTv_SdtOperacoesTitulos_Operacoestitulosstatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulosstatus_N = value;
            SetDirty("Operacoestitulosstatus_N");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Operacoestitulosstatus_N_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Operacoestitulosstatus_N = 0;
         SetDirty("Operacoestitulosstatus_N");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Operacoestitulosstatus_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesTitulosCreatedAt_N" )]
      [  XmlElement( ElementName = "OperacoesTitulosCreatedAt_N"   )]
      public short gxTpr_Operacoestituloscreatedat_N
      {
         get {
            return gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat_N = value;
            SetDirty("Operacoestituloscreatedat_N");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat_N_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat_N = 0;
         SetDirty("Operacoestituloscreatedat_N");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OperacoesTitulosUpdatedAt_N" )]
      [  XmlElement( ElementName = "OperacoesTitulosUpdatedAt_N"   )]
      public short gxTpr_Operacoestitulosupdatedat_N
      {
         get {
            return gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat_N = value;
            SetDirty("Operacoestitulosupdatedat_N");
         }

      }

      public void gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat_N_SetNull( )
      {
         gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat_N = 0;
         SetDirty("Operacoestitulosupdatedat_N");
         return  ;
      }

      public bool gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat_N_IsNull( )
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
         gxTv_SdtOperacoesTitulos_Sacadorazaosocial = "";
         gxTv_SdtOperacoesTitulos_Operacoestitulostipo = "";
         gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao = DateTime.MinValue;
         gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento = DateTime.MinValue;
         gxTv_SdtOperacoesTitulos_Operacoestitulosstatus = "";
         gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtOperacoesTitulos_Mode = "";
         gxTv_SdtOperacoesTitulos_Sacadorazaosocial_Z = "";
         gxTv_SdtOperacoesTitulos_Operacoestitulostipo_Z = "";
         gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao_Z = DateTime.MinValue;
         gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento_Z = DateTime.MinValue;
         gxTv_SdtOperacoesTitulos_Operacoestitulosstatus_Z = "";
         gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat_Z = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "operacoestitulos", "GeneXus.Programs.operacoestitulos_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtOperacoesTitulos_Initialized ;
      private short gxTv_SdtOperacoesTitulos_Operacoesid_N ;
      private short gxTv_SdtOperacoesTitulos_Sacadoid_N ;
      private short gxTv_SdtOperacoesTitulos_Sacadorazaosocial_N ;
      private short gxTv_SdtOperacoesTitulos_Operacoestitulostipo_N ;
      private short gxTv_SdtOperacoesTitulos_Operacoestitulosnumero_N ;
      private short gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao_N ;
      private short gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento_N ;
      private short gxTv_SdtOperacoesTitulos_Operacoestitulosvalor_N ;
      private short gxTv_SdtOperacoesTitulos_Operacoestitulosliquido_N ;
      private short gxTv_SdtOperacoesTitulos_Operacoestitulostaxa_N ;
      private short gxTv_SdtOperacoesTitulos_Operacoestitulosstatus_N ;
      private short gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat_N ;
      private short gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat_N ;
      private int gxTv_SdtOperacoesTitulos_Operacoestitulosid ;
      private int gxTv_SdtOperacoesTitulos_Operacoesid ;
      private int gxTv_SdtOperacoesTitulos_Sacadoid ;
      private int gxTv_SdtOperacoesTitulos_Operacoestitulosnumero ;
      private int gxTv_SdtOperacoesTitulos_Operacoestitulosid_Z ;
      private int gxTv_SdtOperacoesTitulos_Operacoesid_Z ;
      private int gxTv_SdtOperacoesTitulos_Sacadoid_Z ;
      private int gxTv_SdtOperacoesTitulos_Operacoestitulosnumero_Z ;
      private decimal gxTv_SdtOperacoesTitulos_Operacoestitulosvalor ;
      private decimal gxTv_SdtOperacoesTitulos_Operacoestitulosliquido ;
      private decimal gxTv_SdtOperacoesTitulos_Operacoestitulostaxa ;
      private decimal gxTv_SdtOperacoesTitulos_Operacoestitulosvalor_Z ;
      private decimal gxTv_SdtOperacoesTitulos_Operacoestitulosliquido_Z ;
      private decimal gxTv_SdtOperacoesTitulos_Operacoestitulostaxa_Z ;
      private string gxTv_SdtOperacoesTitulos_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat ;
      private DateTime gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat ;
      private DateTime gxTv_SdtOperacoesTitulos_Operacoestituloscreatedat_Z ;
      private DateTime gxTv_SdtOperacoesTitulos_Operacoestitulosupdatedat_Z ;
      private DateTime datetime_STZ ;
      private DateTime gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao ;
      private DateTime gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento ;
      private DateTime gxTv_SdtOperacoesTitulos_Operacoestitulosdataemissao_Z ;
      private DateTime gxTv_SdtOperacoesTitulos_Operacoestitulosdatavencimento_Z ;
      private string gxTv_SdtOperacoesTitulos_Sacadorazaosocial ;
      private string gxTv_SdtOperacoesTitulos_Operacoestitulostipo ;
      private string gxTv_SdtOperacoesTitulos_Operacoestitulosstatus ;
      private string gxTv_SdtOperacoesTitulos_Sacadorazaosocial_Z ;
      private string gxTv_SdtOperacoesTitulos_Operacoestitulostipo_Z ;
      private string gxTv_SdtOperacoesTitulos_Operacoestitulosstatus_Z ;
   }

   [DataContract(Name = @"OperacoesTitulos", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtOperacoesTitulos_RESTInterface : GxGenericCollectionItem<SdtOperacoesTitulos>
   {
      public SdtOperacoesTitulos_RESTInterface( ) : base()
      {
      }

      public SdtOperacoesTitulos_RESTInterface( SdtOperacoesTitulos psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "OperacoesTitulosId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Operacoestitulosid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Operacoestitulosid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Operacoestitulosid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "OperacoesId" , Order = 1 )]
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

      [DataMember( Name = "SacadoId" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Sacadoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Sacadoid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Sacadoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "SacadoRazaoSocial" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Sacadorazaosocial
      {
         get {
            return sdt.gxTpr_Sacadorazaosocial ;
         }

         set {
            sdt.gxTpr_Sacadorazaosocial = value;
         }

      }

      [DataMember( Name = "OperacoesTitulosTipo" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Operacoestitulostipo
      {
         get {
            return sdt.gxTpr_Operacoestitulostipo ;
         }

         set {
            sdt.gxTpr_Operacoestitulostipo = value;
         }

      }

      [DataMember( Name = "OperacoesTitulosNumero" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Operacoestitulosnumero
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Operacoestitulosnumero), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Operacoestitulosnumero = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "OperacoesTitulosDataEmissao" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Operacoestitulosdataemissao
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Operacoestitulosdataemissao) ;
         }

         set {
            sdt.gxTpr_Operacoestitulosdataemissao = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "OperacoesTitulosDataVencimento" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Operacoestitulosdatavencimento
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Operacoestitulosdatavencimento) ;
         }

         set {
            sdt.gxTpr_Operacoestitulosdatavencimento = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "OperacoesTitulosValor" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Operacoestitulosvalor
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Operacoestitulosvalor, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Operacoestitulosvalor = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "OperacoesTitulosLiquido" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Operacoestitulosliquido
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Operacoestitulosliquido, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Operacoestitulosliquido = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "OperacoesTitulosTaxa" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Operacoestitulostaxa
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Operacoestitulostaxa, 16, 4)) ;
         }

         set {
            sdt.gxTpr_Operacoestitulostaxa = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "OperacoesTitulosStatus" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Operacoestitulosstatus
      {
         get {
            return sdt.gxTpr_Operacoestitulosstatus ;
         }

         set {
            sdt.gxTpr_Operacoestitulosstatus = value;
         }

      }

      [DataMember( Name = "OperacoesTitulosCreatedAt" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Operacoestituloscreatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Operacoestituloscreatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Operacoestituloscreatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "OperacoesTitulosUpdatedAt" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Operacoestitulosupdatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Operacoestitulosupdatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Operacoestitulosupdatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      public SdtOperacoesTitulos sdt
      {
         get {
            return (SdtOperacoesTitulos)Sdt ;
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
            sdt = new SdtOperacoesTitulos() ;
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

   [DataContract(Name = @"OperacoesTitulos", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtOperacoesTitulos_RESTLInterface : GxGenericCollectionItem<SdtOperacoesTitulos>
   {
      public SdtOperacoesTitulos_RESTLInterface( ) : base()
      {
      }

      public SdtOperacoesTitulos_RESTLInterface( SdtOperacoesTitulos psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SacadoRazaoSocial" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Sacadorazaosocial
      {
         get {
            return sdt.gxTpr_Sacadorazaosocial ;
         }

         set {
            sdt.gxTpr_Sacadorazaosocial = value;
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

      public SdtOperacoesTitulos sdt
      {
         get {
            return (SdtOperacoesTitulos)Sdt ;
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
            sdt = new SdtOperacoesTitulos() ;
         }
      }

   }

}
