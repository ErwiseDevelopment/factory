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
   [XmlRoot(ElementName = "ChavePIX" )]
   [XmlType(TypeName =  "ChavePIX" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtChavePIX : GxSilentTrnSdt
   {
      public SdtChavePIX( )
      {
      }

      public SdtChavePIX( IGxContext context )
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

      public void Load( int AV961ChavePIXId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV961ChavePIXId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ChavePIXId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "ChavePIX");
         metadata.Set("BT", "ChavePIX");
         metadata.Set("PK", "[ \"ChavePIXId\" ]");
         metadata.Set("PKAssigned", "[ \"ChavePIXId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ContaBancariaId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"SecUserId\" ],\"FKMap\":[ \"ChavePIXCreatedBy-SecUserId\" ] },{ \"FK\":[ \"SecUserId\" ],\"FKMap\":[ \"ChavePIXUpdatedBy-SecUserId\" ] } ]");
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
         state.Add("gxTpr_Chavepixid_Z");
         state.Add("gxTpr_Chavepixtipo_Z");
         state.Add("gxTpr_Chavepixconteudo_Z");
         state.Add("gxTpr_Chavepixstatus_Z");
         state.Add("gxTpr_Chavepixprincipal_Z");
         state.Add("gxTpr_Contabancariaid_Z");
         state.Add("gxTpr_Contabancarianumero_Z");
         state.Add("gxTpr_Contabancariacountchavepix_f_Z");
         state.Add("gxTpr_Agencianumero_Z");
         state.Add("gxTpr_Agenciabanconome_Z");
         state.Add("gxTpr_Chavepixcreatedat_Z_Nullable");
         state.Add("gxTpr_Chavepixcreatedby_Z");
         state.Add("gxTpr_Chavepixcreatedbyname_Z");
         state.Add("gxTpr_Chavepixupdatedat_Z_Nullable");
         state.Add("gxTpr_Chavepixupdatedby_Z");
         state.Add("gxTpr_Chavepixupdatedbyname_Z");
         state.Add("gxTpr_Chavepixtipo_N");
         state.Add("gxTpr_Chavepixconteudo_N");
         state.Add("gxTpr_Chavepixstatus_N");
         state.Add("gxTpr_Chavepixprincipal_N");
         state.Add("gxTpr_Contabancariaid_N");
         state.Add("gxTpr_Contabancarianumero_N");
         state.Add("gxTpr_Contabancariacountchavepix_f_N");
         state.Add("gxTpr_Agencianumero_N");
         state.Add("gxTpr_Agenciabanconome_N");
         state.Add("gxTpr_Chavepixcreatedat_N");
         state.Add("gxTpr_Chavepixcreatedby_N");
         state.Add("gxTpr_Chavepixcreatedbyname_N");
         state.Add("gxTpr_Chavepixupdatedat_N");
         state.Add("gxTpr_Chavepixupdatedby_N");
         state.Add("gxTpr_Chavepixupdatedbyname_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtChavePIX sdt;
         sdt = (SdtChavePIX)(source);
         gxTv_SdtChavePIX_Chavepixid = sdt.gxTv_SdtChavePIX_Chavepixid ;
         gxTv_SdtChavePIX_Chavepixtipo = sdt.gxTv_SdtChavePIX_Chavepixtipo ;
         gxTv_SdtChavePIX_Chavepixconteudo = sdt.gxTv_SdtChavePIX_Chavepixconteudo ;
         gxTv_SdtChavePIX_Chavepixstatus = sdt.gxTv_SdtChavePIX_Chavepixstatus ;
         gxTv_SdtChavePIX_Chavepixprincipal = sdt.gxTv_SdtChavePIX_Chavepixprincipal ;
         gxTv_SdtChavePIX_Contabancariaid = sdt.gxTv_SdtChavePIX_Contabancariaid ;
         gxTv_SdtChavePIX_Contabancarianumero = sdt.gxTv_SdtChavePIX_Contabancarianumero ;
         gxTv_SdtChavePIX_Contabancariacountchavepix_f = sdt.gxTv_SdtChavePIX_Contabancariacountchavepix_f ;
         gxTv_SdtChavePIX_Agencianumero = sdt.gxTv_SdtChavePIX_Agencianumero ;
         gxTv_SdtChavePIX_Agenciabanconome = sdt.gxTv_SdtChavePIX_Agenciabanconome ;
         gxTv_SdtChavePIX_Chavepixcreatedat = sdt.gxTv_SdtChavePIX_Chavepixcreatedat ;
         gxTv_SdtChavePIX_Chavepixcreatedby = sdt.gxTv_SdtChavePIX_Chavepixcreatedby ;
         gxTv_SdtChavePIX_Chavepixcreatedbyname = sdt.gxTv_SdtChavePIX_Chavepixcreatedbyname ;
         gxTv_SdtChavePIX_Chavepixupdatedat = sdt.gxTv_SdtChavePIX_Chavepixupdatedat ;
         gxTv_SdtChavePIX_Chavepixupdatedby = sdt.gxTv_SdtChavePIX_Chavepixupdatedby ;
         gxTv_SdtChavePIX_Chavepixupdatedbyname = sdt.gxTv_SdtChavePIX_Chavepixupdatedbyname ;
         gxTv_SdtChavePIX_Mode = sdt.gxTv_SdtChavePIX_Mode ;
         gxTv_SdtChavePIX_Initialized = sdt.gxTv_SdtChavePIX_Initialized ;
         gxTv_SdtChavePIX_Chavepixid_Z = sdt.gxTv_SdtChavePIX_Chavepixid_Z ;
         gxTv_SdtChavePIX_Chavepixtipo_Z = sdt.gxTv_SdtChavePIX_Chavepixtipo_Z ;
         gxTv_SdtChavePIX_Chavepixconteudo_Z = sdt.gxTv_SdtChavePIX_Chavepixconteudo_Z ;
         gxTv_SdtChavePIX_Chavepixstatus_Z = sdt.gxTv_SdtChavePIX_Chavepixstatus_Z ;
         gxTv_SdtChavePIX_Chavepixprincipal_Z = sdt.gxTv_SdtChavePIX_Chavepixprincipal_Z ;
         gxTv_SdtChavePIX_Contabancariaid_Z = sdt.gxTv_SdtChavePIX_Contabancariaid_Z ;
         gxTv_SdtChavePIX_Contabancarianumero_Z = sdt.gxTv_SdtChavePIX_Contabancarianumero_Z ;
         gxTv_SdtChavePIX_Contabancariacountchavepix_f_Z = sdt.gxTv_SdtChavePIX_Contabancariacountchavepix_f_Z ;
         gxTv_SdtChavePIX_Agencianumero_Z = sdt.gxTv_SdtChavePIX_Agencianumero_Z ;
         gxTv_SdtChavePIX_Agenciabanconome_Z = sdt.gxTv_SdtChavePIX_Agenciabanconome_Z ;
         gxTv_SdtChavePIX_Chavepixcreatedat_Z = sdt.gxTv_SdtChavePIX_Chavepixcreatedat_Z ;
         gxTv_SdtChavePIX_Chavepixcreatedby_Z = sdt.gxTv_SdtChavePIX_Chavepixcreatedby_Z ;
         gxTv_SdtChavePIX_Chavepixcreatedbyname_Z = sdt.gxTv_SdtChavePIX_Chavepixcreatedbyname_Z ;
         gxTv_SdtChavePIX_Chavepixupdatedat_Z = sdt.gxTv_SdtChavePIX_Chavepixupdatedat_Z ;
         gxTv_SdtChavePIX_Chavepixupdatedby_Z = sdt.gxTv_SdtChavePIX_Chavepixupdatedby_Z ;
         gxTv_SdtChavePIX_Chavepixupdatedbyname_Z = sdt.gxTv_SdtChavePIX_Chavepixupdatedbyname_Z ;
         gxTv_SdtChavePIX_Chavepixtipo_N = sdt.gxTv_SdtChavePIX_Chavepixtipo_N ;
         gxTv_SdtChavePIX_Chavepixconteudo_N = sdt.gxTv_SdtChavePIX_Chavepixconteudo_N ;
         gxTv_SdtChavePIX_Chavepixstatus_N = sdt.gxTv_SdtChavePIX_Chavepixstatus_N ;
         gxTv_SdtChavePIX_Chavepixprincipal_N = sdt.gxTv_SdtChavePIX_Chavepixprincipal_N ;
         gxTv_SdtChavePIX_Contabancariaid_N = sdt.gxTv_SdtChavePIX_Contabancariaid_N ;
         gxTv_SdtChavePIX_Contabancarianumero_N = sdt.gxTv_SdtChavePIX_Contabancarianumero_N ;
         gxTv_SdtChavePIX_Contabancariacountchavepix_f_N = sdt.gxTv_SdtChavePIX_Contabancariacountchavepix_f_N ;
         gxTv_SdtChavePIX_Agencianumero_N = sdt.gxTv_SdtChavePIX_Agencianumero_N ;
         gxTv_SdtChavePIX_Agenciabanconome_N = sdt.gxTv_SdtChavePIX_Agenciabanconome_N ;
         gxTv_SdtChavePIX_Chavepixcreatedat_N = sdt.gxTv_SdtChavePIX_Chavepixcreatedat_N ;
         gxTv_SdtChavePIX_Chavepixcreatedby_N = sdt.gxTv_SdtChavePIX_Chavepixcreatedby_N ;
         gxTv_SdtChavePIX_Chavepixcreatedbyname_N = sdt.gxTv_SdtChavePIX_Chavepixcreatedbyname_N ;
         gxTv_SdtChavePIX_Chavepixupdatedat_N = sdt.gxTv_SdtChavePIX_Chavepixupdatedat_N ;
         gxTv_SdtChavePIX_Chavepixupdatedby_N = sdt.gxTv_SdtChavePIX_Chavepixupdatedby_N ;
         gxTv_SdtChavePIX_Chavepixupdatedbyname_N = sdt.gxTv_SdtChavePIX_Chavepixupdatedbyname_N ;
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
         AddObjectProperty("ChavePIXId", gxTv_SdtChavePIX_Chavepixid, false, includeNonInitialized);
         AddObjectProperty("ChavePIXTipo", gxTv_SdtChavePIX_Chavepixtipo, false, includeNonInitialized);
         AddObjectProperty("ChavePIXTipo_N", gxTv_SdtChavePIX_Chavepixtipo_N, false, includeNonInitialized);
         AddObjectProperty("ChavePIXConteudo", gxTv_SdtChavePIX_Chavepixconteudo, false, includeNonInitialized);
         AddObjectProperty("ChavePIXConteudo_N", gxTv_SdtChavePIX_Chavepixconteudo_N, false, includeNonInitialized);
         AddObjectProperty("ChavePIXStatus", gxTv_SdtChavePIX_Chavepixstatus, false, includeNonInitialized);
         AddObjectProperty("ChavePIXStatus_N", gxTv_SdtChavePIX_Chavepixstatus_N, false, includeNonInitialized);
         AddObjectProperty("ChavePIXPrincipal", gxTv_SdtChavePIX_Chavepixprincipal, false, includeNonInitialized);
         AddObjectProperty("ChavePIXPrincipal_N", gxTv_SdtChavePIX_Chavepixprincipal_N, false, includeNonInitialized);
         AddObjectProperty("ContaBancariaId", gxTv_SdtChavePIX_Contabancariaid, false, includeNonInitialized);
         AddObjectProperty("ContaBancariaId_N", gxTv_SdtChavePIX_Contabancariaid_N, false, includeNonInitialized);
         AddObjectProperty("ContaBancariaNumero", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtChavePIX_Contabancarianumero), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("ContaBancariaNumero_N", gxTv_SdtChavePIX_Contabancarianumero_N, false, includeNonInitialized);
         AddObjectProperty("ContaBancariaCountChavePIX_F", gxTv_SdtChavePIX_Contabancariacountchavepix_f, false, includeNonInitialized);
         AddObjectProperty("ContaBancariaCountChavePIX_F_N", gxTv_SdtChavePIX_Contabancariacountchavepix_f_N, false, includeNonInitialized);
         AddObjectProperty("AgenciaNumero", gxTv_SdtChavePIX_Agencianumero, false, includeNonInitialized);
         AddObjectProperty("AgenciaNumero_N", gxTv_SdtChavePIX_Agencianumero_N, false, includeNonInitialized);
         AddObjectProperty("AgenciaBancoNome", gxTv_SdtChavePIX_Agenciabanconome, false, includeNonInitialized);
         AddObjectProperty("AgenciaBancoNome_N", gxTv_SdtChavePIX_Agenciabanconome_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtChavePIX_Chavepixcreatedat;
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
         AddObjectProperty("ChavePIXCreatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ChavePIXCreatedAt_N", gxTv_SdtChavePIX_Chavepixcreatedat_N, false, includeNonInitialized);
         AddObjectProperty("ChavePIXCreatedBy", gxTv_SdtChavePIX_Chavepixcreatedby, false, includeNonInitialized);
         AddObjectProperty("ChavePIXCreatedBy_N", gxTv_SdtChavePIX_Chavepixcreatedby_N, false, includeNonInitialized);
         AddObjectProperty("ChavePIXCreatedByName", gxTv_SdtChavePIX_Chavepixcreatedbyname, false, includeNonInitialized);
         AddObjectProperty("ChavePIXCreatedByName_N", gxTv_SdtChavePIX_Chavepixcreatedbyname_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtChavePIX_Chavepixupdatedat;
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
         AddObjectProperty("ChavePIXUpdatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ChavePIXUpdatedAt_N", gxTv_SdtChavePIX_Chavepixupdatedat_N, false, includeNonInitialized);
         AddObjectProperty("ChavePIXUpdatedBy", gxTv_SdtChavePIX_Chavepixupdatedby, false, includeNonInitialized);
         AddObjectProperty("ChavePIXUpdatedBy_N", gxTv_SdtChavePIX_Chavepixupdatedby_N, false, includeNonInitialized);
         AddObjectProperty("ChavePIXUpdatedByName", gxTv_SdtChavePIX_Chavepixupdatedbyname, false, includeNonInitialized);
         AddObjectProperty("ChavePIXUpdatedByName_N", gxTv_SdtChavePIX_Chavepixupdatedbyname_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtChavePIX_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtChavePIX_Initialized, false, includeNonInitialized);
            AddObjectProperty("ChavePIXId_Z", gxTv_SdtChavePIX_Chavepixid_Z, false, includeNonInitialized);
            AddObjectProperty("ChavePIXTipo_Z", gxTv_SdtChavePIX_Chavepixtipo_Z, false, includeNonInitialized);
            AddObjectProperty("ChavePIXConteudo_Z", gxTv_SdtChavePIX_Chavepixconteudo_Z, false, includeNonInitialized);
            AddObjectProperty("ChavePIXStatus_Z", gxTv_SdtChavePIX_Chavepixstatus_Z, false, includeNonInitialized);
            AddObjectProperty("ChavePIXPrincipal_Z", gxTv_SdtChavePIX_Chavepixprincipal_Z, false, includeNonInitialized);
            AddObjectProperty("ContaBancariaId_Z", gxTv_SdtChavePIX_Contabancariaid_Z, false, includeNonInitialized);
            AddObjectProperty("ContaBancariaNumero_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtChavePIX_Contabancarianumero_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("ContaBancariaCountChavePIX_F_Z", gxTv_SdtChavePIX_Contabancariacountchavepix_f_Z, false, includeNonInitialized);
            AddObjectProperty("AgenciaNumero_Z", gxTv_SdtChavePIX_Agencianumero_Z, false, includeNonInitialized);
            AddObjectProperty("AgenciaBancoNome_Z", gxTv_SdtChavePIX_Agenciabanconome_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtChavePIX_Chavepixcreatedat_Z;
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
            AddObjectProperty("ChavePIXCreatedAt_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("ChavePIXCreatedBy_Z", gxTv_SdtChavePIX_Chavepixcreatedby_Z, false, includeNonInitialized);
            AddObjectProperty("ChavePIXCreatedByName_Z", gxTv_SdtChavePIX_Chavepixcreatedbyname_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtChavePIX_Chavepixupdatedat_Z;
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
            AddObjectProperty("ChavePIXUpdatedAt_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("ChavePIXUpdatedBy_Z", gxTv_SdtChavePIX_Chavepixupdatedby_Z, false, includeNonInitialized);
            AddObjectProperty("ChavePIXUpdatedByName_Z", gxTv_SdtChavePIX_Chavepixupdatedbyname_Z, false, includeNonInitialized);
            AddObjectProperty("ChavePIXTipo_N", gxTv_SdtChavePIX_Chavepixtipo_N, false, includeNonInitialized);
            AddObjectProperty("ChavePIXConteudo_N", gxTv_SdtChavePIX_Chavepixconteudo_N, false, includeNonInitialized);
            AddObjectProperty("ChavePIXStatus_N", gxTv_SdtChavePIX_Chavepixstatus_N, false, includeNonInitialized);
            AddObjectProperty("ChavePIXPrincipal_N", gxTv_SdtChavePIX_Chavepixprincipal_N, false, includeNonInitialized);
            AddObjectProperty("ContaBancariaId_N", gxTv_SdtChavePIX_Contabancariaid_N, false, includeNonInitialized);
            AddObjectProperty("ContaBancariaNumero_N", gxTv_SdtChavePIX_Contabancarianumero_N, false, includeNonInitialized);
            AddObjectProperty("ContaBancariaCountChavePIX_F_N", gxTv_SdtChavePIX_Contabancariacountchavepix_f_N, false, includeNonInitialized);
            AddObjectProperty("AgenciaNumero_N", gxTv_SdtChavePIX_Agencianumero_N, false, includeNonInitialized);
            AddObjectProperty("AgenciaBancoNome_N", gxTv_SdtChavePIX_Agenciabanconome_N, false, includeNonInitialized);
            AddObjectProperty("ChavePIXCreatedAt_N", gxTv_SdtChavePIX_Chavepixcreatedat_N, false, includeNonInitialized);
            AddObjectProperty("ChavePIXCreatedBy_N", gxTv_SdtChavePIX_Chavepixcreatedby_N, false, includeNonInitialized);
            AddObjectProperty("ChavePIXCreatedByName_N", gxTv_SdtChavePIX_Chavepixcreatedbyname_N, false, includeNonInitialized);
            AddObjectProperty("ChavePIXUpdatedAt_N", gxTv_SdtChavePIX_Chavepixupdatedat_N, false, includeNonInitialized);
            AddObjectProperty("ChavePIXUpdatedBy_N", gxTv_SdtChavePIX_Chavepixupdatedby_N, false, includeNonInitialized);
            AddObjectProperty("ChavePIXUpdatedByName_N", gxTv_SdtChavePIX_Chavepixupdatedbyname_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtChavePIX sdt )
      {
         if ( sdt.IsDirty("ChavePIXId") )
         {
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixid = sdt.gxTv_SdtChavePIX_Chavepixid ;
         }
         if ( sdt.IsDirty("ChavePIXTipo") )
         {
            gxTv_SdtChavePIX_Chavepixtipo_N = (short)(sdt.gxTv_SdtChavePIX_Chavepixtipo_N);
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixtipo = sdt.gxTv_SdtChavePIX_Chavepixtipo ;
         }
         if ( sdt.IsDirty("ChavePIXConteudo") )
         {
            gxTv_SdtChavePIX_Chavepixconteudo_N = (short)(sdt.gxTv_SdtChavePIX_Chavepixconteudo_N);
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixconteudo = sdt.gxTv_SdtChavePIX_Chavepixconteudo ;
         }
         if ( sdt.IsDirty("ChavePIXStatus") )
         {
            gxTv_SdtChavePIX_Chavepixstatus_N = (short)(sdt.gxTv_SdtChavePIX_Chavepixstatus_N);
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixstatus = sdt.gxTv_SdtChavePIX_Chavepixstatus ;
         }
         if ( sdt.IsDirty("ChavePIXPrincipal") )
         {
            gxTv_SdtChavePIX_Chavepixprincipal_N = (short)(sdt.gxTv_SdtChavePIX_Chavepixprincipal_N);
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixprincipal = sdt.gxTv_SdtChavePIX_Chavepixprincipal ;
         }
         if ( sdt.IsDirty("ContaBancariaId") )
         {
            gxTv_SdtChavePIX_Contabancariaid_N = (short)(sdt.gxTv_SdtChavePIX_Contabancariaid_N);
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Contabancariaid = sdt.gxTv_SdtChavePIX_Contabancariaid ;
         }
         if ( sdt.IsDirty("ContaBancariaNumero") )
         {
            gxTv_SdtChavePIX_Contabancarianumero_N = (short)(sdt.gxTv_SdtChavePIX_Contabancarianumero_N);
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Contabancarianumero = sdt.gxTv_SdtChavePIX_Contabancarianumero ;
         }
         if ( sdt.IsDirty("ContaBancariaCountChavePIX_F") )
         {
            gxTv_SdtChavePIX_Contabancariacountchavepix_f_N = (short)(sdt.gxTv_SdtChavePIX_Contabancariacountchavepix_f_N);
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Contabancariacountchavepix_f = sdt.gxTv_SdtChavePIX_Contabancariacountchavepix_f ;
         }
         if ( sdt.IsDirty("AgenciaNumero") )
         {
            gxTv_SdtChavePIX_Agencianumero_N = (short)(sdt.gxTv_SdtChavePIX_Agencianumero_N);
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Agencianumero = sdt.gxTv_SdtChavePIX_Agencianumero ;
         }
         if ( sdt.IsDirty("AgenciaBancoNome") )
         {
            gxTv_SdtChavePIX_Agenciabanconome_N = (short)(sdt.gxTv_SdtChavePIX_Agenciabanconome_N);
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Agenciabanconome = sdt.gxTv_SdtChavePIX_Agenciabanconome ;
         }
         if ( sdt.IsDirty("ChavePIXCreatedAt") )
         {
            gxTv_SdtChavePIX_Chavepixcreatedat_N = (short)(sdt.gxTv_SdtChavePIX_Chavepixcreatedat_N);
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixcreatedat = sdt.gxTv_SdtChavePIX_Chavepixcreatedat ;
         }
         if ( sdt.IsDirty("ChavePIXCreatedBy") )
         {
            gxTv_SdtChavePIX_Chavepixcreatedby_N = (short)(sdt.gxTv_SdtChavePIX_Chavepixcreatedby_N);
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixcreatedby = sdt.gxTv_SdtChavePIX_Chavepixcreatedby ;
         }
         if ( sdt.IsDirty("ChavePIXCreatedByName") )
         {
            gxTv_SdtChavePIX_Chavepixcreatedbyname_N = (short)(sdt.gxTv_SdtChavePIX_Chavepixcreatedbyname_N);
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixcreatedbyname = sdt.gxTv_SdtChavePIX_Chavepixcreatedbyname ;
         }
         if ( sdt.IsDirty("ChavePIXUpdatedAt") )
         {
            gxTv_SdtChavePIX_Chavepixupdatedat_N = (short)(sdt.gxTv_SdtChavePIX_Chavepixupdatedat_N);
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixupdatedat = sdt.gxTv_SdtChavePIX_Chavepixupdatedat ;
         }
         if ( sdt.IsDirty("ChavePIXUpdatedBy") )
         {
            gxTv_SdtChavePIX_Chavepixupdatedby_N = (short)(sdt.gxTv_SdtChavePIX_Chavepixupdatedby_N);
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixupdatedby = sdt.gxTv_SdtChavePIX_Chavepixupdatedby ;
         }
         if ( sdt.IsDirty("ChavePIXUpdatedByName") )
         {
            gxTv_SdtChavePIX_Chavepixupdatedbyname_N = (short)(sdt.gxTv_SdtChavePIX_Chavepixupdatedbyname_N);
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixupdatedbyname = sdt.gxTv_SdtChavePIX_Chavepixupdatedbyname ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ChavePIXId" )]
      [  XmlElement( ElementName = "ChavePIXId"   )]
      public int gxTpr_Chavepixid
      {
         get {
            return gxTv_SdtChavePIX_Chavepixid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtChavePIX_Chavepixid != value )
            {
               gxTv_SdtChavePIX_Mode = "INS";
               this.gxTv_SdtChavePIX_Chavepixid_Z_SetNull( );
               this.gxTv_SdtChavePIX_Chavepixtipo_Z_SetNull( );
               this.gxTv_SdtChavePIX_Chavepixconteudo_Z_SetNull( );
               this.gxTv_SdtChavePIX_Chavepixstatus_Z_SetNull( );
               this.gxTv_SdtChavePIX_Chavepixprincipal_Z_SetNull( );
               this.gxTv_SdtChavePIX_Contabancariaid_Z_SetNull( );
               this.gxTv_SdtChavePIX_Contabancarianumero_Z_SetNull( );
               this.gxTv_SdtChavePIX_Contabancariacountchavepix_f_Z_SetNull( );
               this.gxTv_SdtChavePIX_Agencianumero_Z_SetNull( );
               this.gxTv_SdtChavePIX_Agenciabanconome_Z_SetNull( );
               this.gxTv_SdtChavePIX_Chavepixcreatedat_Z_SetNull( );
               this.gxTv_SdtChavePIX_Chavepixcreatedby_Z_SetNull( );
               this.gxTv_SdtChavePIX_Chavepixcreatedbyname_Z_SetNull( );
               this.gxTv_SdtChavePIX_Chavepixupdatedat_Z_SetNull( );
               this.gxTv_SdtChavePIX_Chavepixupdatedby_Z_SetNull( );
               this.gxTv_SdtChavePIX_Chavepixupdatedbyname_Z_SetNull( );
            }
            gxTv_SdtChavePIX_Chavepixid = value;
            SetDirty("Chavepixid");
         }

      }

      [  SoapElement( ElementName = "ChavePIXTipo" )]
      [  XmlElement( ElementName = "ChavePIXTipo"   )]
      public string gxTpr_Chavepixtipo
      {
         get {
            return gxTv_SdtChavePIX_Chavepixtipo ;
         }

         set {
            gxTv_SdtChavePIX_Chavepixtipo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixtipo = value;
            SetDirty("Chavepixtipo");
         }

      }

      public void gxTv_SdtChavePIX_Chavepixtipo_SetNull( )
      {
         gxTv_SdtChavePIX_Chavepixtipo_N = 1;
         gxTv_SdtChavePIX_Chavepixtipo = "";
         SetDirty("Chavepixtipo");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Chavepixtipo_IsNull( )
      {
         return (gxTv_SdtChavePIX_Chavepixtipo_N==1) ;
      }

      [  SoapElement( ElementName = "ChavePIXConteudo" )]
      [  XmlElement( ElementName = "ChavePIXConteudo"   )]
      public string gxTpr_Chavepixconteudo
      {
         get {
            return gxTv_SdtChavePIX_Chavepixconteudo ;
         }

         set {
            gxTv_SdtChavePIX_Chavepixconteudo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixconteudo = value;
            SetDirty("Chavepixconteudo");
         }

      }

      public void gxTv_SdtChavePIX_Chavepixconteudo_SetNull( )
      {
         gxTv_SdtChavePIX_Chavepixconteudo_N = 1;
         gxTv_SdtChavePIX_Chavepixconteudo = "";
         SetDirty("Chavepixconteudo");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Chavepixconteudo_IsNull( )
      {
         return (gxTv_SdtChavePIX_Chavepixconteudo_N==1) ;
      }

      [  SoapElement( ElementName = "ChavePIXStatus" )]
      [  XmlElement( ElementName = "ChavePIXStatus"   )]
      public bool gxTpr_Chavepixstatus
      {
         get {
            return gxTv_SdtChavePIX_Chavepixstatus ;
         }

         set {
            gxTv_SdtChavePIX_Chavepixstatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixstatus = value;
            SetDirty("Chavepixstatus");
         }

      }

      public void gxTv_SdtChavePIX_Chavepixstatus_SetNull( )
      {
         gxTv_SdtChavePIX_Chavepixstatus_N = 1;
         gxTv_SdtChavePIX_Chavepixstatus = false;
         SetDirty("Chavepixstatus");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Chavepixstatus_IsNull( )
      {
         return (gxTv_SdtChavePIX_Chavepixstatus_N==1) ;
      }

      [  SoapElement( ElementName = "ChavePIXPrincipal" )]
      [  XmlElement( ElementName = "ChavePIXPrincipal"   )]
      public bool gxTpr_Chavepixprincipal
      {
         get {
            return gxTv_SdtChavePIX_Chavepixprincipal ;
         }

         set {
            gxTv_SdtChavePIX_Chavepixprincipal_N = 0;
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixprincipal = value;
            SetDirty("Chavepixprincipal");
         }

      }

      public void gxTv_SdtChavePIX_Chavepixprincipal_SetNull( )
      {
         gxTv_SdtChavePIX_Chavepixprincipal_N = 1;
         gxTv_SdtChavePIX_Chavepixprincipal = false;
         SetDirty("Chavepixprincipal");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Chavepixprincipal_IsNull( )
      {
         return (gxTv_SdtChavePIX_Chavepixprincipal_N==1) ;
      }

      [  SoapElement( ElementName = "ContaBancariaId" )]
      [  XmlElement( ElementName = "ContaBancariaId"   )]
      public int gxTpr_Contabancariaid
      {
         get {
            return gxTv_SdtChavePIX_Contabancariaid ;
         }

         set {
            gxTv_SdtChavePIX_Contabancariaid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Contabancariaid = value;
            SetDirty("Contabancariaid");
         }

      }

      public void gxTv_SdtChavePIX_Contabancariaid_SetNull( )
      {
         gxTv_SdtChavePIX_Contabancariaid_N = 1;
         gxTv_SdtChavePIX_Contabancariaid = 0;
         SetDirty("Contabancariaid");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Contabancariaid_IsNull( )
      {
         return (gxTv_SdtChavePIX_Contabancariaid_N==1) ;
      }

      [  SoapElement( ElementName = "ContaBancariaNumero" )]
      [  XmlElement( ElementName = "ContaBancariaNumero"   )]
      public long gxTpr_Contabancarianumero
      {
         get {
            return gxTv_SdtChavePIX_Contabancarianumero ;
         }

         set {
            gxTv_SdtChavePIX_Contabancarianumero_N = 0;
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Contabancarianumero = value;
            SetDirty("Contabancarianumero");
         }

      }

      public void gxTv_SdtChavePIX_Contabancarianumero_SetNull( )
      {
         gxTv_SdtChavePIX_Contabancarianumero_N = 1;
         gxTv_SdtChavePIX_Contabancarianumero = 0;
         SetDirty("Contabancarianumero");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Contabancarianumero_IsNull( )
      {
         return (gxTv_SdtChavePIX_Contabancarianumero_N==1) ;
      }

      [  SoapElement( ElementName = "ContaBancariaCountChavePIX_F" )]
      [  XmlElement( ElementName = "ContaBancariaCountChavePIX_F"   )]
      public short gxTpr_Contabancariacountchavepix_f
      {
         get {
            return gxTv_SdtChavePIX_Contabancariacountchavepix_f ;
         }

         set {
            gxTv_SdtChavePIX_Contabancariacountchavepix_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Contabancariacountchavepix_f = value;
            SetDirty("Contabancariacountchavepix_f");
         }

      }

      public void gxTv_SdtChavePIX_Contabancariacountchavepix_f_SetNull( )
      {
         gxTv_SdtChavePIX_Contabancariacountchavepix_f_N = 1;
         gxTv_SdtChavePIX_Contabancariacountchavepix_f = 0;
         SetDirty("Contabancariacountchavepix_f");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Contabancariacountchavepix_f_IsNull( )
      {
         return (gxTv_SdtChavePIX_Contabancariacountchavepix_f_N==1) ;
      }

      [  SoapElement( ElementName = "AgenciaNumero" )]
      [  XmlElement( ElementName = "AgenciaNumero"   )]
      public int gxTpr_Agencianumero
      {
         get {
            return gxTv_SdtChavePIX_Agencianumero ;
         }

         set {
            gxTv_SdtChavePIX_Agencianumero_N = 0;
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Agencianumero = value;
            SetDirty("Agencianumero");
         }

      }

      public void gxTv_SdtChavePIX_Agencianumero_SetNull( )
      {
         gxTv_SdtChavePIX_Agencianumero_N = 1;
         gxTv_SdtChavePIX_Agencianumero = 0;
         SetDirty("Agencianumero");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Agencianumero_IsNull( )
      {
         return (gxTv_SdtChavePIX_Agencianumero_N==1) ;
      }

      [  SoapElement( ElementName = "AgenciaBancoNome" )]
      [  XmlElement( ElementName = "AgenciaBancoNome"   )]
      public string gxTpr_Agenciabanconome
      {
         get {
            return gxTv_SdtChavePIX_Agenciabanconome ;
         }

         set {
            gxTv_SdtChavePIX_Agenciabanconome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Agenciabanconome = value;
            SetDirty("Agenciabanconome");
         }

      }

      public void gxTv_SdtChavePIX_Agenciabanconome_SetNull( )
      {
         gxTv_SdtChavePIX_Agenciabanconome_N = 1;
         gxTv_SdtChavePIX_Agenciabanconome = "";
         SetDirty("Agenciabanconome");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Agenciabanconome_IsNull( )
      {
         return (gxTv_SdtChavePIX_Agenciabanconome_N==1) ;
      }

      [  SoapElement( ElementName = "ChavePIXCreatedAt" )]
      [  XmlElement( ElementName = "ChavePIXCreatedAt"  , IsNullable=true )]
      public string gxTpr_Chavepixcreatedat_Nullable
      {
         get {
            if ( gxTv_SdtChavePIX_Chavepixcreatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtChavePIX_Chavepixcreatedat).value ;
         }

         set {
            gxTv_SdtChavePIX_Chavepixcreatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtChavePIX_Chavepixcreatedat = DateTime.MinValue;
            else
               gxTv_SdtChavePIX_Chavepixcreatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Chavepixcreatedat
      {
         get {
            return gxTv_SdtChavePIX_Chavepixcreatedat ;
         }

         set {
            gxTv_SdtChavePIX_Chavepixcreatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixcreatedat = value;
            SetDirty("Chavepixcreatedat");
         }

      }

      public void gxTv_SdtChavePIX_Chavepixcreatedat_SetNull( )
      {
         gxTv_SdtChavePIX_Chavepixcreatedat_N = 1;
         gxTv_SdtChavePIX_Chavepixcreatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Chavepixcreatedat");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Chavepixcreatedat_IsNull( )
      {
         return (gxTv_SdtChavePIX_Chavepixcreatedat_N==1) ;
      }

      [  SoapElement( ElementName = "ChavePIXCreatedBy" )]
      [  XmlElement( ElementName = "ChavePIXCreatedBy"   )]
      public short gxTpr_Chavepixcreatedby
      {
         get {
            return gxTv_SdtChavePIX_Chavepixcreatedby ;
         }

         set {
            gxTv_SdtChavePIX_Chavepixcreatedby_N = 0;
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixcreatedby = value;
            SetDirty("Chavepixcreatedby");
         }

      }

      public void gxTv_SdtChavePIX_Chavepixcreatedby_SetNull( )
      {
         gxTv_SdtChavePIX_Chavepixcreatedby_N = 1;
         gxTv_SdtChavePIX_Chavepixcreatedby = 0;
         SetDirty("Chavepixcreatedby");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Chavepixcreatedby_IsNull( )
      {
         return (gxTv_SdtChavePIX_Chavepixcreatedby_N==1) ;
      }

      [  SoapElement( ElementName = "ChavePIXCreatedByName" )]
      [  XmlElement( ElementName = "ChavePIXCreatedByName"   )]
      public string gxTpr_Chavepixcreatedbyname
      {
         get {
            return gxTv_SdtChavePIX_Chavepixcreatedbyname ;
         }

         set {
            gxTv_SdtChavePIX_Chavepixcreatedbyname_N = 0;
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixcreatedbyname = value;
            SetDirty("Chavepixcreatedbyname");
         }

      }

      public void gxTv_SdtChavePIX_Chavepixcreatedbyname_SetNull( )
      {
         gxTv_SdtChavePIX_Chavepixcreatedbyname_N = 1;
         gxTv_SdtChavePIX_Chavepixcreatedbyname = "";
         SetDirty("Chavepixcreatedbyname");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Chavepixcreatedbyname_IsNull( )
      {
         return (gxTv_SdtChavePIX_Chavepixcreatedbyname_N==1) ;
      }

      [  SoapElement( ElementName = "ChavePIXUpdatedAt" )]
      [  XmlElement( ElementName = "ChavePIXUpdatedAt"  , IsNullable=true )]
      public string gxTpr_Chavepixupdatedat_Nullable
      {
         get {
            if ( gxTv_SdtChavePIX_Chavepixupdatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtChavePIX_Chavepixupdatedat).value ;
         }

         set {
            gxTv_SdtChavePIX_Chavepixupdatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtChavePIX_Chavepixupdatedat = DateTime.MinValue;
            else
               gxTv_SdtChavePIX_Chavepixupdatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Chavepixupdatedat
      {
         get {
            return gxTv_SdtChavePIX_Chavepixupdatedat ;
         }

         set {
            gxTv_SdtChavePIX_Chavepixupdatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixupdatedat = value;
            SetDirty("Chavepixupdatedat");
         }

      }

      public void gxTv_SdtChavePIX_Chavepixupdatedat_SetNull( )
      {
         gxTv_SdtChavePIX_Chavepixupdatedat_N = 1;
         gxTv_SdtChavePIX_Chavepixupdatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Chavepixupdatedat");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Chavepixupdatedat_IsNull( )
      {
         return (gxTv_SdtChavePIX_Chavepixupdatedat_N==1) ;
      }

      [  SoapElement( ElementName = "ChavePIXUpdatedBy" )]
      [  XmlElement( ElementName = "ChavePIXUpdatedBy"   )]
      public short gxTpr_Chavepixupdatedby
      {
         get {
            return gxTv_SdtChavePIX_Chavepixupdatedby ;
         }

         set {
            gxTv_SdtChavePIX_Chavepixupdatedby_N = 0;
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixupdatedby = value;
            SetDirty("Chavepixupdatedby");
         }

      }

      public void gxTv_SdtChavePIX_Chavepixupdatedby_SetNull( )
      {
         gxTv_SdtChavePIX_Chavepixupdatedby_N = 1;
         gxTv_SdtChavePIX_Chavepixupdatedby = 0;
         SetDirty("Chavepixupdatedby");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Chavepixupdatedby_IsNull( )
      {
         return (gxTv_SdtChavePIX_Chavepixupdatedby_N==1) ;
      }

      [  SoapElement( ElementName = "ChavePIXUpdatedByName" )]
      [  XmlElement( ElementName = "ChavePIXUpdatedByName"   )]
      public string gxTpr_Chavepixupdatedbyname
      {
         get {
            return gxTv_SdtChavePIX_Chavepixupdatedbyname ;
         }

         set {
            gxTv_SdtChavePIX_Chavepixupdatedbyname_N = 0;
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixupdatedbyname = value;
            SetDirty("Chavepixupdatedbyname");
         }

      }

      public void gxTv_SdtChavePIX_Chavepixupdatedbyname_SetNull( )
      {
         gxTv_SdtChavePIX_Chavepixupdatedbyname_N = 1;
         gxTv_SdtChavePIX_Chavepixupdatedbyname = "";
         SetDirty("Chavepixupdatedbyname");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Chavepixupdatedbyname_IsNull( )
      {
         return (gxTv_SdtChavePIX_Chavepixupdatedbyname_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtChavePIX_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtChavePIX_Mode_SetNull( )
      {
         gxTv_SdtChavePIX_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtChavePIX_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtChavePIX_Initialized_SetNull( )
      {
         gxTv_SdtChavePIX_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ChavePIXId_Z" )]
      [  XmlElement( ElementName = "ChavePIXId_Z"   )]
      public int gxTpr_Chavepixid_Z
      {
         get {
            return gxTv_SdtChavePIX_Chavepixid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixid_Z = value;
            SetDirty("Chavepixid_Z");
         }

      }

      public void gxTv_SdtChavePIX_Chavepixid_Z_SetNull( )
      {
         gxTv_SdtChavePIX_Chavepixid_Z = 0;
         SetDirty("Chavepixid_Z");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Chavepixid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ChavePIXTipo_Z" )]
      [  XmlElement( ElementName = "ChavePIXTipo_Z"   )]
      public string gxTpr_Chavepixtipo_Z
      {
         get {
            return gxTv_SdtChavePIX_Chavepixtipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixtipo_Z = value;
            SetDirty("Chavepixtipo_Z");
         }

      }

      public void gxTv_SdtChavePIX_Chavepixtipo_Z_SetNull( )
      {
         gxTv_SdtChavePIX_Chavepixtipo_Z = "";
         SetDirty("Chavepixtipo_Z");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Chavepixtipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ChavePIXConteudo_Z" )]
      [  XmlElement( ElementName = "ChavePIXConteudo_Z"   )]
      public string gxTpr_Chavepixconteudo_Z
      {
         get {
            return gxTv_SdtChavePIX_Chavepixconteudo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixconteudo_Z = value;
            SetDirty("Chavepixconteudo_Z");
         }

      }

      public void gxTv_SdtChavePIX_Chavepixconteudo_Z_SetNull( )
      {
         gxTv_SdtChavePIX_Chavepixconteudo_Z = "";
         SetDirty("Chavepixconteudo_Z");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Chavepixconteudo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ChavePIXStatus_Z" )]
      [  XmlElement( ElementName = "ChavePIXStatus_Z"   )]
      public bool gxTpr_Chavepixstatus_Z
      {
         get {
            return gxTv_SdtChavePIX_Chavepixstatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixstatus_Z = value;
            SetDirty("Chavepixstatus_Z");
         }

      }

      public void gxTv_SdtChavePIX_Chavepixstatus_Z_SetNull( )
      {
         gxTv_SdtChavePIX_Chavepixstatus_Z = false;
         SetDirty("Chavepixstatus_Z");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Chavepixstatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ChavePIXPrincipal_Z" )]
      [  XmlElement( ElementName = "ChavePIXPrincipal_Z"   )]
      public bool gxTpr_Chavepixprincipal_Z
      {
         get {
            return gxTv_SdtChavePIX_Chavepixprincipal_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixprincipal_Z = value;
            SetDirty("Chavepixprincipal_Z");
         }

      }

      public void gxTv_SdtChavePIX_Chavepixprincipal_Z_SetNull( )
      {
         gxTv_SdtChavePIX_Chavepixprincipal_Z = false;
         SetDirty("Chavepixprincipal_Z");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Chavepixprincipal_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaId_Z" )]
      [  XmlElement( ElementName = "ContaBancariaId_Z"   )]
      public int gxTpr_Contabancariaid_Z
      {
         get {
            return gxTv_SdtChavePIX_Contabancariaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Contabancariaid_Z = value;
            SetDirty("Contabancariaid_Z");
         }

      }

      public void gxTv_SdtChavePIX_Contabancariaid_Z_SetNull( )
      {
         gxTv_SdtChavePIX_Contabancariaid_Z = 0;
         SetDirty("Contabancariaid_Z");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Contabancariaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaNumero_Z" )]
      [  XmlElement( ElementName = "ContaBancariaNumero_Z"   )]
      public long gxTpr_Contabancarianumero_Z
      {
         get {
            return gxTv_SdtChavePIX_Contabancarianumero_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Contabancarianumero_Z = value;
            SetDirty("Contabancarianumero_Z");
         }

      }

      public void gxTv_SdtChavePIX_Contabancarianumero_Z_SetNull( )
      {
         gxTv_SdtChavePIX_Contabancarianumero_Z = 0;
         SetDirty("Contabancarianumero_Z");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Contabancarianumero_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaCountChavePIX_F_Z" )]
      [  XmlElement( ElementName = "ContaBancariaCountChavePIX_F_Z"   )]
      public short gxTpr_Contabancariacountchavepix_f_Z
      {
         get {
            return gxTv_SdtChavePIX_Contabancariacountchavepix_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Contabancariacountchavepix_f_Z = value;
            SetDirty("Contabancariacountchavepix_f_Z");
         }

      }

      public void gxTv_SdtChavePIX_Contabancariacountchavepix_f_Z_SetNull( )
      {
         gxTv_SdtChavePIX_Contabancariacountchavepix_f_Z = 0;
         SetDirty("Contabancariacountchavepix_f_Z");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Contabancariacountchavepix_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaNumero_Z" )]
      [  XmlElement( ElementName = "AgenciaNumero_Z"   )]
      public int gxTpr_Agencianumero_Z
      {
         get {
            return gxTv_SdtChavePIX_Agencianumero_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Agencianumero_Z = value;
            SetDirty("Agencianumero_Z");
         }

      }

      public void gxTv_SdtChavePIX_Agencianumero_Z_SetNull( )
      {
         gxTv_SdtChavePIX_Agencianumero_Z = 0;
         SetDirty("Agencianumero_Z");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Agencianumero_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaBancoNome_Z" )]
      [  XmlElement( ElementName = "AgenciaBancoNome_Z"   )]
      public string gxTpr_Agenciabanconome_Z
      {
         get {
            return gxTv_SdtChavePIX_Agenciabanconome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Agenciabanconome_Z = value;
            SetDirty("Agenciabanconome_Z");
         }

      }

      public void gxTv_SdtChavePIX_Agenciabanconome_Z_SetNull( )
      {
         gxTv_SdtChavePIX_Agenciabanconome_Z = "";
         SetDirty("Agenciabanconome_Z");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Agenciabanconome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ChavePIXCreatedAt_Z" )]
      [  XmlElement( ElementName = "ChavePIXCreatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Chavepixcreatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtChavePIX_Chavepixcreatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtChavePIX_Chavepixcreatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtChavePIX_Chavepixcreatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtChavePIX_Chavepixcreatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Chavepixcreatedat_Z
      {
         get {
            return gxTv_SdtChavePIX_Chavepixcreatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixcreatedat_Z = value;
            SetDirty("Chavepixcreatedat_Z");
         }

      }

      public void gxTv_SdtChavePIX_Chavepixcreatedat_Z_SetNull( )
      {
         gxTv_SdtChavePIX_Chavepixcreatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Chavepixcreatedat_Z");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Chavepixcreatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ChavePIXCreatedBy_Z" )]
      [  XmlElement( ElementName = "ChavePIXCreatedBy_Z"   )]
      public short gxTpr_Chavepixcreatedby_Z
      {
         get {
            return gxTv_SdtChavePIX_Chavepixcreatedby_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixcreatedby_Z = value;
            SetDirty("Chavepixcreatedby_Z");
         }

      }

      public void gxTv_SdtChavePIX_Chavepixcreatedby_Z_SetNull( )
      {
         gxTv_SdtChavePIX_Chavepixcreatedby_Z = 0;
         SetDirty("Chavepixcreatedby_Z");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Chavepixcreatedby_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ChavePIXCreatedByName_Z" )]
      [  XmlElement( ElementName = "ChavePIXCreatedByName_Z"   )]
      public string gxTpr_Chavepixcreatedbyname_Z
      {
         get {
            return gxTv_SdtChavePIX_Chavepixcreatedbyname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixcreatedbyname_Z = value;
            SetDirty("Chavepixcreatedbyname_Z");
         }

      }

      public void gxTv_SdtChavePIX_Chavepixcreatedbyname_Z_SetNull( )
      {
         gxTv_SdtChavePIX_Chavepixcreatedbyname_Z = "";
         SetDirty("Chavepixcreatedbyname_Z");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Chavepixcreatedbyname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ChavePIXUpdatedAt_Z" )]
      [  XmlElement( ElementName = "ChavePIXUpdatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Chavepixupdatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtChavePIX_Chavepixupdatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtChavePIX_Chavepixupdatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtChavePIX_Chavepixupdatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtChavePIX_Chavepixupdatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Chavepixupdatedat_Z
      {
         get {
            return gxTv_SdtChavePIX_Chavepixupdatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixupdatedat_Z = value;
            SetDirty("Chavepixupdatedat_Z");
         }

      }

      public void gxTv_SdtChavePIX_Chavepixupdatedat_Z_SetNull( )
      {
         gxTv_SdtChavePIX_Chavepixupdatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Chavepixupdatedat_Z");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Chavepixupdatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ChavePIXUpdatedBy_Z" )]
      [  XmlElement( ElementName = "ChavePIXUpdatedBy_Z"   )]
      public short gxTpr_Chavepixupdatedby_Z
      {
         get {
            return gxTv_SdtChavePIX_Chavepixupdatedby_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixupdatedby_Z = value;
            SetDirty("Chavepixupdatedby_Z");
         }

      }

      public void gxTv_SdtChavePIX_Chavepixupdatedby_Z_SetNull( )
      {
         gxTv_SdtChavePIX_Chavepixupdatedby_Z = 0;
         SetDirty("Chavepixupdatedby_Z");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Chavepixupdatedby_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ChavePIXUpdatedByName_Z" )]
      [  XmlElement( ElementName = "ChavePIXUpdatedByName_Z"   )]
      public string gxTpr_Chavepixupdatedbyname_Z
      {
         get {
            return gxTv_SdtChavePIX_Chavepixupdatedbyname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixupdatedbyname_Z = value;
            SetDirty("Chavepixupdatedbyname_Z");
         }

      }

      public void gxTv_SdtChavePIX_Chavepixupdatedbyname_Z_SetNull( )
      {
         gxTv_SdtChavePIX_Chavepixupdatedbyname_Z = "";
         SetDirty("Chavepixupdatedbyname_Z");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Chavepixupdatedbyname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ChavePIXTipo_N" )]
      [  XmlElement( ElementName = "ChavePIXTipo_N"   )]
      public short gxTpr_Chavepixtipo_N
      {
         get {
            return gxTv_SdtChavePIX_Chavepixtipo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixtipo_N = value;
            SetDirty("Chavepixtipo_N");
         }

      }

      public void gxTv_SdtChavePIX_Chavepixtipo_N_SetNull( )
      {
         gxTv_SdtChavePIX_Chavepixtipo_N = 0;
         SetDirty("Chavepixtipo_N");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Chavepixtipo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ChavePIXConteudo_N" )]
      [  XmlElement( ElementName = "ChavePIXConteudo_N"   )]
      public short gxTpr_Chavepixconteudo_N
      {
         get {
            return gxTv_SdtChavePIX_Chavepixconteudo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixconteudo_N = value;
            SetDirty("Chavepixconteudo_N");
         }

      }

      public void gxTv_SdtChavePIX_Chavepixconteudo_N_SetNull( )
      {
         gxTv_SdtChavePIX_Chavepixconteudo_N = 0;
         SetDirty("Chavepixconteudo_N");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Chavepixconteudo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ChavePIXStatus_N" )]
      [  XmlElement( ElementName = "ChavePIXStatus_N"   )]
      public short gxTpr_Chavepixstatus_N
      {
         get {
            return gxTv_SdtChavePIX_Chavepixstatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixstatus_N = value;
            SetDirty("Chavepixstatus_N");
         }

      }

      public void gxTv_SdtChavePIX_Chavepixstatus_N_SetNull( )
      {
         gxTv_SdtChavePIX_Chavepixstatus_N = 0;
         SetDirty("Chavepixstatus_N");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Chavepixstatus_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ChavePIXPrincipal_N" )]
      [  XmlElement( ElementName = "ChavePIXPrincipal_N"   )]
      public short gxTpr_Chavepixprincipal_N
      {
         get {
            return gxTv_SdtChavePIX_Chavepixprincipal_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixprincipal_N = value;
            SetDirty("Chavepixprincipal_N");
         }

      }

      public void gxTv_SdtChavePIX_Chavepixprincipal_N_SetNull( )
      {
         gxTv_SdtChavePIX_Chavepixprincipal_N = 0;
         SetDirty("Chavepixprincipal_N");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Chavepixprincipal_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaId_N" )]
      [  XmlElement( ElementName = "ContaBancariaId_N"   )]
      public short gxTpr_Contabancariaid_N
      {
         get {
            return gxTv_SdtChavePIX_Contabancariaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Contabancariaid_N = value;
            SetDirty("Contabancariaid_N");
         }

      }

      public void gxTv_SdtChavePIX_Contabancariaid_N_SetNull( )
      {
         gxTv_SdtChavePIX_Contabancariaid_N = 0;
         SetDirty("Contabancariaid_N");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Contabancariaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaNumero_N" )]
      [  XmlElement( ElementName = "ContaBancariaNumero_N"   )]
      public short gxTpr_Contabancarianumero_N
      {
         get {
            return gxTv_SdtChavePIX_Contabancarianumero_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Contabancarianumero_N = value;
            SetDirty("Contabancarianumero_N");
         }

      }

      public void gxTv_SdtChavePIX_Contabancarianumero_N_SetNull( )
      {
         gxTv_SdtChavePIX_Contabancarianumero_N = 0;
         SetDirty("Contabancarianumero_N");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Contabancarianumero_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaCountChavePIX_F_N" )]
      [  XmlElement( ElementName = "ContaBancariaCountChavePIX_F_N"   )]
      public short gxTpr_Contabancariacountchavepix_f_N
      {
         get {
            return gxTv_SdtChavePIX_Contabancariacountchavepix_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Contabancariacountchavepix_f_N = value;
            SetDirty("Contabancariacountchavepix_f_N");
         }

      }

      public void gxTv_SdtChavePIX_Contabancariacountchavepix_f_N_SetNull( )
      {
         gxTv_SdtChavePIX_Contabancariacountchavepix_f_N = 0;
         SetDirty("Contabancariacountchavepix_f_N");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Contabancariacountchavepix_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaNumero_N" )]
      [  XmlElement( ElementName = "AgenciaNumero_N"   )]
      public short gxTpr_Agencianumero_N
      {
         get {
            return gxTv_SdtChavePIX_Agencianumero_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Agencianumero_N = value;
            SetDirty("Agencianumero_N");
         }

      }

      public void gxTv_SdtChavePIX_Agencianumero_N_SetNull( )
      {
         gxTv_SdtChavePIX_Agencianumero_N = 0;
         SetDirty("Agencianumero_N");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Agencianumero_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaBancoNome_N" )]
      [  XmlElement( ElementName = "AgenciaBancoNome_N"   )]
      public short gxTpr_Agenciabanconome_N
      {
         get {
            return gxTv_SdtChavePIX_Agenciabanconome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Agenciabanconome_N = value;
            SetDirty("Agenciabanconome_N");
         }

      }

      public void gxTv_SdtChavePIX_Agenciabanconome_N_SetNull( )
      {
         gxTv_SdtChavePIX_Agenciabanconome_N = 0;
         SetDirty("Agenciabanconome_N");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Agenciabanconome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ChavePIXCreatedAt_N" )]
      [  XmlElement( ElementName = "ChavePIXCreatedAt_N"   )]
      public short gxTpr_Chavepixcreatedat_N
      {
         get {
            return gxTv_SdtChavePIX_Chavepixcreatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixcreatedat_N = value;
            SetDirty("Chavepixcreatedat_N");
         }

      }

      public void gxTv_SdtChavePIX_Chavepixcreatedat_N_SetNull( )
      {
         gxTv_SdtChavePIX_Chavepixcreatedat_N = 0;
         SetDirty("Chavepixcreatedat_N");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Chavepixcreatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ChavePIXCreatedBy_N" )]
      [  XmlElement( ElementName = "ChavePIXCreatedBy_N"   )]
      public short gxTpr_Chavepixcreatedby_N
      {
         get {
            return gxTv_SdtChavePIX_Chavepixcreatedby_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixcreatedby_N = value;
            SetDirty("Chavepixcreatedby_N");
         }

      }

      public void gxTv_SdtChavePIX_Chavepixcreatedby_N_SetNull( )
      {
         gxTv_SdtChavePIX_Chavepixcreatedby_N = 0;
         SetDirty("Chavepixcreatedby_N");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Chavepixcreatedby_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ChavePIXCreatedByName_N" )]
      [  XmlElement( ElementName = "ChavePIXCreatedByName_N"   )]
      public short gxTpr_Chavepixcreatedbyname_N
      {
         get {
            return gxTv_SdtChavePIX_Chavepixcreatedbyname_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixcreatedbyname_N = value;
            SetDirty("Chavepixcreatedbyname_N");
         }

      }

      public void gxTv_SdtChavePIX_Chavepixcreatedbyname_N_SetNull( )
      {
         gxTv_SdtChavePIX_Chavepixcreatedbyname_N = 0;
         SetDirty("Chavepixcreatedbyname_N");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Chavepixcreatedbyname_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ChavePIXUpdatedAt_N" )]
      [  XmlElement( ElementName = "ChavePIXUpdatedAt_N"   )]
      public short gxTpr_Chavepixupdatedat_N
      {
         get {
            return gxTv_SdtChavePIX_Chavepixupdatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixupdatedat_N = value;
            SetDirty("Chavepixupdatedat_N");
         }

      }

      public void gxTv_SdtChavePIX_Chavepixupdatedat_N_SetNull( )
      {
         gxTv_SdtChavePIX_Chavepixupdatedat_N = 0;
         SetDirty("Chavepixupdatedat_N");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Chavepixupdatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ChavePIXUpdatedBy_N" )]
      [  XmlElement( ElementName = "ChavePIXUpdatedBy_N"   )]
      public short gxTpr_Chavepixupdatedby_N
      {
         get {
            return gxTv_SdtChavePIX_Chavepixupdatedby_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixupdatedby_N = value;
            SetDirty("Chavepixupdatedby_N");
         }

      }

      public void gxTv_SdtChavePIX_Chavepixupdatedby_N_SetNull( )
      {
         gxTv_SdtChavePIX_Chavepixupdatedby_N = 0;
         SetDirty("Chavepixupdatedby_N");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Chavepixupdatedby_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ChavePIXUpdatedByName_N" )]
      [  XmlElement( ElementName = "ChavePIXUpdatedByName_N"   )]
      public short gxTpr_Chavepixupdatedbyname_N
      {
         get {
            return gxTv_SdtChavePIX_Chavepixupdatedbyname_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtChavePIX_Chavepixupdatedbyname_N = value;
            SetDirty("Chavepixupdatedbyname_N");
         }

      }

      public void gxTv_SdtChavePIX_Chavepixupdatedbyname_N_SetNull( )
      {
         gxTv_SdtChavePIX_Chavepixupdatedbyname_N = 0;
         SetDirty("Chavepixupdatedbyname_N");
         return  ;
      }

      public bool gxTv_SdtChavePIX_Chavepixupdatedbyname_N_IsNull( )
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
         gxTv_SdtChavePIX_Chavepixtipo = "";
         gxTv_SdtChavePIX_Chavepixconteudo = "";
         gxTv_SdtChavePIX_Agenciabanconome = "";
         gxTv_SdtChavePIX_Chavepixcreatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtChavePIX_Chavepixcreatedbyname = "";
         gxTv_SdtChavePIX_Chavepixupdatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtChavePIX_Chavepixupdatedbyname = "";
         gxTv_SdtChavePIX_Mode = "";
         gxTv_SdtChavePIX_Chavepixtipo_Z = "";
         gxTv_SdtChavePIX_Chavepixconteudo_Z = "";
         gxTv_SdtChavePIX_Agenciabanconome_Z = "";
         gxTv_SdtChavePIX_Chavepixcreatedat_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtChavePIX_Chavepixcreatedbyname_Z = "";
         gxTv_SdtChavePIX_Chavepixupdatedat_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtChavePIX_Chavepixupdatedbyname_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "chavepix", "GeneXus.Programs.chavepix_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtChavePIX_Contabancariacountchavepix_f ;
      private short gxTv_SdtChavePIX_Chavepixcreatedby ;
      private short gxTv_SdtChavePIX_Chavepixupdatedby ;
      private short gxTv_SdtChavePIX_Initialized ;
      private short gxTv_SdtChavePIX_Contabancariacountchavepix_f_Z ;
      private short gxTv_SdtChavePIX_Chavepixcreatedby_Z ;
      private short gxTv_SdtChavePIX_Chavepixupdatedby_Z ;
      private short gxTv_SdtChavePIX_Chavepixtipo_N ;
      private short gxTv_SdtChavePIX_Chavepixconteudo_N ;
      private short gxTv_SdtChavePIX_Chavepixstatus_N ;
      private short gxTv_SdtChavePIX_Chavepixprincipal_N ;
      private short gxTv_SdtChavePIX_Contabancariaid_N ;
      private short gxTv_SdtChavePIX_Contabancarianumero_N ;
      private short gxTv_SdtChavePIX_Contabancariacountchavepix_f_N ;
      private short gxTv_SdtChavePIX_Agencianumero_N ;
      private short gxTv_SdtChavePIX_Agenciabanconome_N ;
      private short gxTv_SdtChavePIX_Chavepixcreatedat_N ;
      private short gxTv_SdtChavePIX_Chavepixcreatedby_N ;
      private short gxTv_SdtChavePIX_Chavepixcreatedbyname_N ;
      private short gxTv_SdtChavePIX_Chavepixupdatedat_N ;
      private short gxTv_SdtChavePIX_Chavepixupdatedby_N ;
      private short gxTv_SdtChavePIX_Chavepixupdatedbyname_N ;
      private int gxTv_SdtChavePIX_Chavepixid ;
      private int gxTv_SdtChavePIX_Contabancariaid ;
      private int gxTv_SdtChavePIX_Agencianumero ;
      private int gxTv_SdtChavePIX_Chavepixid_Z ;
      private int gxTv_SdtChavePIX_Contabancariaid_Z ;
      private int gxTv_SdtChavePIX_Agencianumero_Z ;
      private long gxTv_SdtChavePIX_Contabancarianumero ;
      private long gxTv_SdtChavePIX_Contabancarianumero_Z ;
      private string gxTv_SdtChavePIX_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtChavePIX_Chavepixcreatedat ;
      private DateTime gxTv_SdtChavePIX_Chavepixupdatedat ;
      private DateTime gxTv_SdtChavePIX_Chavepixcreatedat_Z ;
      private DateTime gxTv_SdtChavePIX_Chavepixupdatedat_Z ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtChavePIX_Chavepixstatus ;
      private bool gxTv_SdtChavePIX_Chavepixprincipal ;
      private bool gxTv_SdtChavePIX_Chavepixstatus_Z ;
      private bool gxTv_SdtChavePIX_Chavepixprincipal_Z ;
      private string gxTv_SdtChavePIX_Chavepixtipo ;
      private string gxTv_SdtChavePIX_Chavepixconteudo ;
      private string gxTv_SdtChavePIX_Agenciabanconome ;
      private string gxTv_SdtChavePIX_Chavepixcreatedbyname ;
      private string gxTv_SdtChavePIX_Chavepixupdatedbyname ;
      private string gxTv_SdtChavePIX_Chavepixtipo_Z ;
      private string gxTv_SdtChavePIX_Chavepixconteudo_Z ;
      private string gxTv_SdtChavePIX_Agenciabanconome_Z ;
      private string gxTv_SdtChavePIX_Chavepixcreatedbyname_Z ;
      private string gxTv_SdtChavePIX_Chavepixupdatedbyname_Z ;
   }

   [DataContract(Name = @"ChavePIX", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtChavePIX_RESTInterface : GxGenericCollectionItem<SdtChavePIX>
   {
      public SdtChavePIX_RESTInterface( ) : base()
      {
      }

      public SdtChavePIX_RESTInterface( SdtChavePIX psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ChavePIXId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Chavepixid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Chavepixid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Chavepixid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ChavePIXTipo" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Chavepixtipo
      {
         get {
            return sdt.gxTpr_Chavepixtipo ;
         }

         set {
            sdt.gxTpr_Chavepixtipo = value;
         }

      }

      [DataMember( Name = "ChavePIXConteudo" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Chavepixconteudo
      {
         get {
            return sdt.gxTpr_Chavepixconteudo ;
         }

         set {
            sdt.gxTpr_Chavepixconteudo = value;
         }

      }

      [DataMember( Name = "ChavePIXStatus" , Order = 3 )]
      [GxSeudo()]
      public bool gxTpr_Chavepixstatus
      {
         get {
            return sdt.gxTpr_Chavepixstatus ;
         }

         set {
            sdt.gxTpr_Chavepixstatus = value;
         }

      }

      [DataMember( Name = "ChavePIXPrincipal" , Order = 4 )]
      [GxSeudo()]
      public bool gxTpr_Chavepixprincipal
      {
         get {
            return sdt.gxTpr_Chavepixprincipal ;
         }

         set {
            sdt.gxTpr_Chavepixprincipal = value;
         }

      }

      [DataMember( Name = "ContaBancariaId" , Order = 5 )]
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

      [DataMember( Name = "ContaBancariaNumero" , Order = 6 )]
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

      [DataMember( Name = "ContaBancariaCountChavePIX_F" , Order = 7 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Contabancariacountchavepix_f
      {
         get {
            return sdt.gxTpr_Contabancariacountchavepix_f ;
         }

         set {
            sdt.gxTpr_Contabancariacountchavepix_f = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "AgenciaNumero" , Order = 8 )]
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

      [DataMember( Name = "AgenciaBancoNome" , Order = 9 )]
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

      [DataMember( Name = "ChavePIXCreatedAt" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Chavepixcreatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Chavepixcreatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Chavepixcreatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "ChavePIXCreatedBy" , Order = 11 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Chavepixcreatedby
      {
         get {
            return sdt.gxTpr_Chavepixcreatedby ;
         }

         set {
            sdt.gxTpr_Chavepixcreatedby = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ChavePIXCreatedByName" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Chavepixcreatedbyname
      {
         get {
            return sdt.gxTpr_Chavepixcreatedbyname ;
         }

         set {
            sdt.gxTpr_Chavepixcreatedbyname = value;
         }

      }

      [DataMember( Name = "ChavePIXUpdatedAt" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Chavepixupdatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Chavepixupdatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Chavepixupdatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "ChavePIXUpdatedBy" , Order = 14 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Chavepixupdatedby
      {
         get {
            return sdt.gxTpr_Chavepixupdatedby ;
         }

         set {
            sdt.gxTpr_Chavepixupdatedby = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ChavePIXUpdatedByName" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Chavepixupdatedbyname
      {
         get {
            return sdt.gxTpr_Chavepixupdatedbyname ;
         }

         set {
            sdt.gxTpr_Chavepixupdatedbyname = value;
         }

      }

      public SdtChavePIX sdt
      {
         get {
            return (SdtChavePIX)Sdt ;
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
            sdt = new SdtChavePIX() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 16 )]
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

   [DataContract(Name = @"ChavePIX", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtChavePIX_RESTLInterface : GxGenericCollectionItem<SdtChavePIX>
   {
      public SdtChavePIX_RESTLInterface( ) : base()
      {
      }

      public SdtChavePIX_RESTLInterface( SdtChavePIX psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ChavePIXTipo" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Chavepixtipo
      {
         get {
            return sdt.gxTpr_Chavepixtipo ;
         }

         set {
            sdt.gxTpr_Chavepixtipo = value;
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

      public SdtChavePIX sdt
      {
         get {
            return (SdtChavePIX)Sdt ;
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
            sdt = new SdtChavePIX() ;
         }
      }

   }

}
