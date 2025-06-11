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
   [XmlRoot(ElementName = "ContaBancaria" )]
   [XmlType(TypeName =  "ContaBancaria" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtContaBancaria : GxSilentTrnSdt
   {
      public SdtContaBancaria( )
      {
      }

      public SdtContaBancaria( IGxContext context )
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

      public void Load( int AV951ContaBancariaId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV951ContaBancariaId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ContaBancariaId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "ContaBancaria");
         metadata.Set("BT", "ContaBancaria");
         metadata.Set("PK", "[ \"ContaBancariaId\" ]");
         metadata.Set("PKAssigned", "[ \"ContaBancariaId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"AgenciaId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"SecUserId\" ],\"FKMap\":[ \"ContaBancariaCreatedBy-SecUserId\" ] },{ \"FK\":[ \"SecUserId\" ],\"FKMap\":[ \"ContaBancariaUpdatedBy-SecUserId\" ] } ]");
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
         state.Add("gxTpr_Contabancariaid_Z");
         state.Add("gxTpr_Agenciaid_Z");
         state.Add("gxTpr_Agencianumero_Z");
         state.Add("gxTpr_Agenciabanconome_Z");
         state.Add("gxTpr_Contabancarianumero_Z");
         state.Add("gxTpr_Contabancariadigito_Z");
         state.Add("gxTpr_Contabancariacountchavepix_f_Z");
         state.Add("gxTpr_Contabancariacarteira_Z");
         state.Add("gxTpr_Contabancariacreatedat_Z_Nullable");
         state.Add("gxTpr_Contabancariastatus_Z");
         state.Add("gxTpr_Contabancariacreatedby_Z");
         state.Add("gxTpr_Contabancariacreatedbyname_Z");
         state.Add("gxTpr_Contabancariaupdatedat_Z_Nullable");
         state.Add("gxTpr_Contabancariaupdatedby_Z");
         state.Add("gxTpr_Contabancariaupdatedbyname_Z");
         state.Add("gxTpr_Contabancariaregistraboletos_Z");
         state.Add("gxTpr_Contabancariadescricao_f_Z");
         state.Add("gxTpr_Contabancariaid_N");
         state.Add("gxTpr_Agenciaid_N");
         state.Add("gxTpr_Agencianumero_N");
         state.Add("gxTpr_Agenciabanconome_N");
         state.Add("gxTpr_Contabancarianumero_N");
         state.Add("gxTpr_Contabancariadigito_N");
         state.Add("gxTpr_Contabancariacountchavepix_f_N");
         state.Add("gxTpr_Contabancariacarteira_N");
         state.Add("gxTpr_Contabancariacreatedat_N");
         state.Add("gxTpr_Contabancariastatus_N");
         state.Add("gxTpr_Contabancariacreatedby_N");
         state.Add("gxTpr_Contabancariacreatedbyname_N");
         state.Add("gxTpr_Contabancariaupdatedat_N");
         state.Add("gxTpr_Contabancariaupdatedby_N");
         state.Add("gxTpr_Contabancariaupdatedbyname_N");
         state.Add("gxTpr_Contabancariaregistraboletos_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtContaBancaria sdt;
         sdt = (SdtContaBancaria)(source);
         gxTv_SdtContaBancaria_Contabancariaid = sdt.gxTv_SdtContaBancaria_Contabancariaid ;
         gxTv_SdtContaBancaria_Agenciaid = sdt.gxTv_SdtContaBancaria_Agenciaid ;
         gxTv_SdtContaBancaria_Agencianumero = sdt.gxTv_SdtContaBancaria_Agencianumero ;
         gxTv_SdtContaBancaria_Agenciabanconome = sdt.gxTv_SdtContaBancaria_Agenciabanconome ;
         gxTv_SdtContaBancaria_Contabancarianumero = sdt.gxTv_SdtContaBancaria_Contabancarianumero ;
         gxTv_SdtContaBancaria_Contabancariadigito = sdt.gxTv_SdtContaBancaria_Contabancariadigito ;
         gxTv_SdtContaBancaria_Contabancariacountchavepix_f = sdt.gxTv_SdtContaBancaria_Contabancariacountchavepix_f ;
         gxTv_SdtContaBancaria_Contabancariacarteira = sdt.gxTv_SdtContaBancaria_Contabancariacarteira ;
         gxTv_SdtContaBancaria_Contabancariacreatedat = sdt.gxTv_SdtContaBancaria_Contabancariacreatedat ;
         gxTv_SdtContaBancaria_Contabancariastatus = sdt.gxTv_SdtContaBancaria_Contabancariastatus ;
         gxTv_SdtContaBancaria_Contabancariacreatedby = sdt.gxTv_SdtContaBancaria_Contabancariacreatedby ;
         gxTv_SdtContaBancaria_Contabancariacreatedbyname = sdt.gxTv_SdtContaBancaria_Contabancariacreatedbyname ;
         gxTv_SdtContaBancaria_Contabancariaupdatedat = sdt.gxTv_SdtContaBancaria_Contabancariaupdatedat ;
         gxTv_SdtContaBancaria_Contabancariaupdatedby = sdt.gxTv_SdtContaBancaria_Contabancariaupdatedby ;
         gxTv_SdtContaBancaria_Contabancariaupdatedbyname = sdt.gxTv_SdtContaBancaria_Contabancariaupdatedbyname ;
         gxTv_SdtContaBancaria_Contabancariaregistraboletos = sdt.gxTv_SdtContaBancaria_Contabancariaregistraboletos ;
         gxTv_SdtContaBancaria_Contabancariadescricao_f = sdt.gxTv_SdtContaBancaria_Contabancariadescricao_f ;
         gxTv_SdtContaBancaria_Mode = sdt.gxTv_SdtContaBancaria_Mode ;
         gxTv_SdtContaBancaria_Initialized = sdt.gxTv_SdtContaBancaria_Initialized ;
         gxTv_SdtContaBancaria_Contabancariaid_Z = sdt.gxTv_SdtContaBancaria_Contabancariaid_Z ;
         gxTv_SdtContaBancaria_Agenciaid_Z = sdt.gxTv_SdtContaBancaria_Agenciaid_Z ;
         gxTv_SdtContaBancaria_Agencianumero_Z = sdt.gxTv_SdtContaBancaria_Agencianumero_Z ;
         gxTv_SdtContaBancaria_Agenciabanconome_Z = sdt.gxTv_SdtContaBancaria_Agenciabanconome_Z ;
         gxTv_SdtContaBancaria_Contabancarianumero_Z = sdt.gxTv_SdtContaBancaria_Contabancarianumero_Z ;
         gxTv_SdtContaBancaria_Contabancariadigito_Z = sdt.gxTv_SdtContaBancaria_Contabancariadigito_Z ;
         gxTv_SdtContaBancaria_Contabancariacountchavepix_f_Z = sdt.gxTv_SdtContaBancaria_Contabancariacountchavepix_f_Z ;
         gxTv_SdtContaBancaria_Contabancariacarteira_Z = sdt.gxTv_SdtContaBancaria_Contabancariacarteira_Z ;
         gxTv_SdtContaBancaria_Contabancariacreatedat_Z = sdt.gxTv_SdtContaBancaria_Contabancariacreatedat_Z ;
         gxTv_SdtContaBancaria_Contabancariastatus_Z = sdt.gxTv_SdtContaBancaria_Contabancariastatus_Z ;
         gxTv_SdtContaBancaria_Contabancariacreatedby_Z = sdt.gxTv_SdtContaBancaria_Contabancariacreatedby_Z ;
         gxTv_SdtContaBancaria_Contabancariacreatedbyname_Z = sdt.gxTv_SdtContaBancaria_Contabancariacreatedbyname_Z ;
         gxTv_SdtContaBancaria_Contabancariaupdatedat_Z = sdt.gxTv_SdtContaBancaria_Contabancariaupdatedat_Z ;
         gxTv_SdtContaBancaria_Contabancariaupdatedby_Z = sdt.gxTv_SdtContaBancaria_Contabancariaupdatedby_Z ;
         gxTv_SdtContaBancaria_Contabancariaupdatedbyname_Z = sdt.gxTv_SdtContaBancaria_Contabancariaupdatedbyname_Z ;
         gxTv_SdtContaBancaria_Contabancariaregistraboletos_Z = sdt.gxTv_SdtContaBancaria_Contabancariaregistraboletos_Z ;
         gxTv_SdtContaBancaria_Contabancariadescricao_f_Z = sdt.gxTv_SdtContaBancaria_Contabancariadescricao_f_Z ;
         gxTv_SdtContaBancaria_Contabancariaid_N = sdt.gxTv_SdtContaBancaria_Contabancariaid_N ;
         gxTv_SdtContaBancaria_Agenciaid_N = sdt.gxTv_SdtContaBancaria_Agenciaid_N ;
         gxTv_SdtContaBancaria_Agencianumero_N = sdt.gxTv_SdtContaBancaria_Agencianumero_N ;
         gxTv_SdtContaBancaria_Agenciabanconome_N = sdt.gxTv_SdtContaBancaria_Agenciabanconome_N ;
         gxTv_SdtContaBancaria_Contabancarianumero_N = sdt.gxTv_SdtContaBancaria_Contabancarianumero_N ;
         gxTv_SdtContaBancaria_Contabancariadigito_N = sdt.gxTv_SdtContaBancaria_Contabancariadigito_N ;
         gxTv_SdtContaBancaria_Contabancariacountchavepix_f_N = sdt.gxTv_SdtContaBancaria_Contabancariacountchavepix_f_N ;
         gxTv_SdtContaBancaria_Contabancariacarteira_N = sdt.gxTv_SdtContaBancaria_Contabancariacarteira_N ;
         gxTv_SdtContaBancaria_Contabancariacreatedat_N = sdt.gxTv_SdtContaBancaria_Contabancariacreatedat_N ;
         gxTv_SdtContaBancaria_Contabancariastatus_N = sdt.gxTv_SdtContaBancaria_Contabancariastatus_N ;
         gxTv_SdtContaBancaria_Contabancariacreatedby_N = sdt.gxTv_SdtContaBancaria_Contabancariacreatedby_N ;
         gxTv_SdtContaBancaria_Contabancariacreatedbyname_N = sdt.gxTv_SdtContaBancaria_Contabancariacreatedbyname_N ;
         gxTv_SdtContaBancaria_Contabancariaupdatedat_N = sdt.gxTv_SdtContaBancaria_Contabancariaupdatedat_N ;
         gxTv_SdtContaBancaria_Contabancariaupdatedby_N = sdt.gxTv_SdtContaBancaria_Contabancariaupdatedby_N ;
         gxTv_SdtContaBancaria_Contabancariaupdatedbyname_N = sdt.gxTv_SdtContaBancaria_Contabancariaupdatedbyname_N ;
         gxTv_SdtContaBancaria_Contabancariaregistraboletos_N = sdt.gxTv_SdtContaBancaria_Contabancariaregistraboletos_N ;
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
         AddObjectProperty("ContaBancariaId", gxTv_SdtContaBancaria_Contabancariaid, false, includeNonInitialized);
         AddObjectProperty("ContaBancariaId_N", gxTv_SdtContaBancaria_Contabancariaid_N, false, includeNonInitialized);
         AddObjectProperty("AgenciaId", gxTv_SdtContaBancaria_Agenciaid, false, includeNonInitialized);
         AddObjectProperty("AgenciaId_N", gxTv_SdtContaBancaria_Agenciaid_N, false, includeNonInitialized);
         AddObjectProperty("AgenciaNumero", gxTv_SdtContaBancaria_Agencianumero, false, includeNonInitialized);
         AddObjectProperty("AgenciaNumero_N", gxTv_SdtContaBancaria_Agencianumero_N, false, includeNonInitialized);
         AddObjectProperty("AgenciaBancoNome", gxTv_SdtContaBancaria_Agenciabanconome, false, includeNonInitialized);
         AddObjectProperty("AgenciaBancoNome_N", gxTv_SdtContaBancaria_Agenciabanconome_N, false, includeNonInitialized);
         AddObjectProperty("ContaBancariaNumero", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtContaBancaria_Contabancarianumero), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("ContaBancariaNumero_N", gxTv_SdtContaBancaria_Contabancarianumero_N, false, includeNonInitialized);
         AddObjectProperty("ContaBancariaDigito", gxTv_SdtContaBancaria_Contabancariadigito, false, includeNonInitialized);
         AddObjectProperty("ContaBancariaDigito_N", gxTv_SdtContaBancaria_Contabancariadigito_N, false, includeNonInitialized);
         AddObjectProperty("ContaBancariaCountChavePIX_F", gxTv_SdtContaBancaria_Contabancariacountchavepix_f, false, includeNonInitialized);
         AddObjectProperty("ContaBancariaCountChavePIX_F_N", gxTv_SdtContaBancaria_Contabancariacountchavepix_f_N, false, includeNonInitialized);
         AddObjectProperty("ContaBancariaCarteira", gxTv_SdtContaBancaria_Contabancariacarteira, false, includeNonInitialized);
         AddObjectProperty("ContaBancariaCarteira_N", gxTv_SdtContaBancaria_Contabancariacarteira_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtContaBancaria_Contabancariacreatedat;
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
         AddObjectProperty("ContaBancariaCreatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ContaBancariaCreatedAt_N", gxTv_SdtContaBancaria_Contabancariacreatedat_N, false, includeNonInitialized);
         AddObjectProperty("ContaBancariaStatus", gxTv_SdtContaBancaria_Contabancariastatus, false, includeNonInitialized);
         AddObjectProperty("ContaBancariaStatus_N", gxTv_SdtContaBancaria_Contabancariastatus_N, false, includeNonInitialized);
         AddObjectProperty("ContaBancariaCreatedBy", gxTv_SdtContaBancaria_Contabancariacreatedby, false, includeNonInitialized);
         AddObjectProperty("ContaBancariaCreatedBy_N", gxTv_SdtContaBancaria_Contabancariacreatedby_N, false, includeNonInitialized);
         AddObjectProperty("ContaBancariaCreatedByName", gxTv_SdtContaBancaria_Contabancariacreatedbyname, false, includeNonInitialized);
         AddObjectProperty("ContaBancariaCreatedByName_N", gxTv_SdtContaBancaria_Contabancariacreatedbyname_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtContaBancaria_Contabancariaupdatedat;
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
         AddObjectProperty("ContaBancariaUpdatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ContaBancariaUpdatedAt_N", gxTv_SdtContaBancaria_Contabancariaupdatedat_N, false, includeNonInitialized);
         AddObjectProperty("ContaBancariaUpdatedBy", gxTv_SdtContaBancaria_Contabancariaupdatedby, false, includeNonInitialized);
         AddObjectProperty("ContaBancariaUpdatedBy_N", gxTv_SdtContaBancaria_Contabancariaupdatedby_N, false, includeNonInitialized);
         AddObjectProperty("ContaBancariaUpdatedByName", gxTv_SdtContaBancaria_Contabancariaupdatedbyname, false, includeNonInitialized);
         AddObjectProperty("ContaBancariaUpdatedByName_N", gxTv_SdtContaBancaria_Contabancariaupdatedbyname_N, false, includeNonInitialized);
         AddObjectProperty("ContaBancariaRegistraBoletos", gxTv_SdtContaBancaria_Contabancariaregistraboletos, false, includeNonInitialized);
         AddObjectProperty("ContaBancariaRegistraBoletos_N", gxTv_SdtContaBancaria_Contabancariaregistraboletos_N, false, includeNonInitialized);
         AddObjectProperty("ContaBancariaDescricao_F", gxTv_SdtContaBancaria_Contabancariadescricao_f, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtContaBancaria_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtContaBancaria_Initialized, false, includeNonInitialized);
            AddObjectProperty("ContaBancariaId_Z", gxTv_SdtContaBancaria_Contabancariaid_Z, false, includeNonInitialized);
            AddObjectProperty("AgenciaId_Z", gxTv_SdtContaBancaria_Agenciaid_Z, false, includeNonInitialized);
            AddObjectProperty("AgenciaNumero_Z", gxTv_SdtContaBancaria_Agencianumero_Z, false, includeNonInitialized);
            AddObjectProperty("AgenciaBancoNome_Z", gxTv_SdtContaBancaria_Agenciabanconome_Z, false, includeNonInitialized);
            AddObjectProperty("ContaBancariaNumero_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtContaBancaria_Contabancarianumero_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("ContaBancariaDigito_Z", gxTv_SdtContaBancaria_Contabancariadigito_Z, false, includeNonInitialized);
            AddObjectProperty("ContaBancariaCountChavePIX_F_Z", gxTv_SdtContaBancaria_Contabancariacountchavepix_f_Z, false, includeNonInitialized);
            AddObjectProperty("ContaBancariaCarteira_Z", gxTv_SdtContaBancaria_Contabancariacarteira_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtContaBancaria_Contabancariacreatedat_Z;
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
            AddObjectProperty("ContaBancariaCreatedAt_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("ContaBancariaStatus_Z", gxTv_SdtContaBancaria_Contabancariastatus_Z, false, includeNonInitialized);
            AddObjectProperty("ContaBancariaCreatedBy_Z", gxTv_SdtContaBancaria_Contabancariacreatedby_Z, false, includeNonInitialized);
            AddObjectProperty("ContaBancariaCreatedByName_Z", gxTv_SdtContaBancaria_Contabancariacreatedbyname_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtContaBancaria_Contabancariaupdatedat_Z;
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
            AddObjectProperty("ContaBancariaUpdatedAt_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("ContaBancariaUpdatedBy_Z", gxTv_SdtContaBancaria_Contabancariaupdatedby_Z, false, includeNonInitialized);
            AddObjectProperty("ContaBancariaUpdatedByName_Z", gxTv_SdtContaBancaria_Contabancariaupdatedbyname_Z, false, includeNonInitialized);
            AddObjectProperty("ContaBancariaRegistraBoletos_Z", gxTv_SdtContaBancaria_Contabancariaregistraboletos_Z, false, includeNonInitialized);
            AddObjectProperty("ContaBancariaDescricao_F_Z", gxTv_SdtContaBancaria_Contabancariadescricao_f_Z, false, includeNonInitialized);
            AddObjectProperty("ContaBancariaId_N", gxTv_SdtContaBancaria_Contabancariaid_N, false, includeNonInitialized);
            AddObjectProperty("AgenciaId_N", gxTv_SdtContaBancaria_Agenciaid_N, false, includeNonInitialized);
            AddObjectProperty("AgenciaNumero_N", gxTv_SdtContaBancaria_Agencianumero_N, false, includeNonInitialized);
            AddObjectProperty("AgenciaBancoNome_N", gxTv_SdtContaBancaria_Agenciabanconome_N, false, includeNonInitialized);
            AddObjectProperty("ContaBancariaNumero_N", gxTv_SdtContaBancaria_Contabancarianumero_N, false, includeNonInitialized);
            AddObjectProperty("ContaBancariaDigito_N", gxTv_SdtContaBancaria_Contabancariadigito_N, false, includeNonInitialized);
            AddObjectProperty("ContaBancariaCountChavePIX_F_N", gxTv_SdtContaBancaria_Contabancariacountchavepix_f_N, false, includeNonInitialized);
            AddObjectProperty("ContaBancariaCarteira_N", gxTv_SdtContaBancaria_Contabancariacarteira_N, false, includeNonInitialized);
            AddObjectProperty("ContaBancariaCreatedAt_N", gxTv_SdtContaBancaria_Contabancariacreatedat_N, false, includeNonInitialized);
            AddObjectProperty("ContaBancariaStatus_N", gxTv_SdtContaBancaria_Contabancariastatus_N, false, includeNonInitialized);
            AddObjectProperty("ContaBancariaCreatedBy_N", gxTv_SdtContaBancaria_Contabancariacreatedby_N, false, includeNonInitialized);
            AddObjectProperty("ContaBancariaCreatedByName_N", gxTv_SdtContaBancaria_Contabancariacreatedbyname_N, false, includeNonInitialized);
            AddObjectProperty("ContaBancariaUpdatedAt_N", gxTv_SdtContaBancaria_Contabancariaupdatedat_N, false, includeNonInitialized);
            AddObjectProperty("ContaBancariaUpdatedBy_N", gxTv_SdtContaBancaria_Contabancariaupdatedby_N, false, includeNonInitialized);
            AddObjectProperty("ContaBancariaUpdatedByName_N", gxTv_SdtContaBancaria_Contabancariaupdatedbyname_N, false, includeNonInitialized);
            AddObjectProperty("ContaBancariaRegistraBoletos_N", gxTv_SdtContaBancaria_Contabancariaregistraboletos_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtContaBancaria sdt )
      {
         if ( sdt.IsDirty("ContaBancariaId") )
         {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariaid = sdt.gxTv_SdtContaBancaria_Contabancariaid ;
         }
         if ( sdt.IsDirty("AgenciaId") )
         {
            gxTv_SdtContaBancaria_Agenciaid_N = (short)(sdt.gxTv_SdtContaBancaria_Agenciaid_N);
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Agenciaid = sdt.gxTv_SdtContaBancaria_Agenciaid ;
         }
         if ( sdt.IsDirty("AgenciaNumero") )
         {
            gxTv_SdtContaBancaria_Agencianumero_N = (short)(sdt.gxTv_SdtContaBancaria_Agencianumero_N);
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Agencianumero = sdt.gxTv_SdtContaBancaria_Agencianumero ;
         }
         if ( sdt.IsDirty("AgenciaBancoNome") )
         {
            gxTv_SdtContaBancaria_Agenciabanconome_N = (short)(sdt.gxTv_SdtContaBancaria_Agenciabanconome_N);
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Agenciabanconome = sdt.gxTv_SdtContaBancaria_Agenciabanconome ;
         }
         if ( sdt.IsDirty("ContaBancariaNumero") )
         {
            gxTv_SdtContaBancaria_Contabancarianumero_N = (short)(sdt.gxTv_SdtContaBancaria_Contabancarianumero_N);
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancarianumero = sdt.gxTv_SdtContaBancaria_Contabancarianumero ;
         }
         if ( sdt.IsDirty("ContaBancariaDigito") )
         {
            gxTv_SdtContaBancaria_Contabancariadigito_N = (short)(sdt.gxTv_SdtContaBancaria_Contabancariadigito_N);
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariadigito = sdt.gxTv_SdtContaBancaria_Contabancariadigito ;
         }
         if ( sdt.IsDirty("ContaBancariaCountChavePIX_F") )
         {
            gxTv_SdtContaBancaria_Contabancariacountchavepix_f_N = (short)(sdt.gxTv_SdtContaBancaria_Contabancariacountchavepix_f_N);
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariacountchavepix_f = sdt.gxTv_SdtContaBancaria_Contabancariacountchavepix_f ;
         }
         if ( sdt.IsDirty("ContaBancariaCarteira") )
         {
            gxTv_SdtContaBancaria_Contabancariacarteira_N = (short)(sdt.gxTv_SdtContaBancaria_Contabancariacarteira_N);
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariacarteira = sdt.gxTv_SdtContaBancaria_Contabancariacarteira ;
         }
         if ( sdt.IsDirty("ContaBancariaCreatedAt") )
         {
            gxTv_SdtContaBancaria_Contabancariacreatedat_N = (short)(sdt.gxTv_SdtContaBancaria_Contabancariacreatedat_N);
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariacreatedat = sdt.gxTv_SdtContaBancaria_Contabancariacreatedat ;
         }
         if ( sdt.IsDirty("ContaBancariaStatus") )
         {
            gxTv_SdtContaBancaria_Contabancariastatus_N = (short)(sdt.gxTv_SdtContaBancaria_Contabancariastatus_N);
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariastatus = sdt.gxTv_SdtContaBancaria_Contabancariastatus ;
         }
         if ( sdt.IsDirty("ContaBancariaCreatedBy") )
         {
            gxTv_SdtContaBancaria_Contabancariacreatedby_N = (short)(sdt.gxTv_SdtContaBancaria_Contabancariacreatedby_N);
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariacreatedby = sdt.gxTv_SdtContaBancaria_Contabancariacreatedby ;
         }
         if ( sdt.IsDirty("ContaBancariaCreatedByName") )
         {
            gxTv_SdtContaBancaria_Contabancariacreatedbyname_N = (short)(sdt.gxTv_SdtContaBancaria_Contabancariacreatedbyname_N);
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariacreatedbyname = sdt.gxTv_SdtContaBancaria_Contabancariacreatedbyname ;
         }
         if ( sdt.IsDirty("ContaBancariaUpdatedAt") )
         {
            gxTv_SdtContaBancaria_Contabancariaupdatedat_N = (short)(sdt.gxTv_SdtContaBancaria_Contabancariaupdatedat_N);
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariaupdatedat = sdt.gxTv_SdtContaBancaria_Contabancariaupdatedat ;
         }
         if ( sdt.IsDirty("ContaBancariaUpdatedBy") )
         {
            gxTv_SdtContaBancaria_Contabancariaupdatedby_N = (short)(sdt.gxTv_SdtContaBancaria_Contabancariaupdatedby_N);
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariaupdatedby = sdt.gxTv_SdtContaBancaria_Contabancariaupdatedby ;
         }
         if ( sdt.IsDirty("ContaBancariaUpdatedByName") )
         {
            gxTv_SdtContaBancaria_Contabancariaupdatedbyname_N = (short)(sdt.gxTv_SdtContaBancaria_Contabancariaupdatedbyname_N);
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariaupdatedbyname = sdt.gxTv_SdtContaBancaria_Contabancariaupdatedbyname ;
         }
         if ( sdt.IsDirty("ContaBancariaRegistraBoletos") )
         {
            gxTv_SdtContaBancaria_Contabancariaregistraboletos_N = (short)(sdt.gxTv_SdtContaBancaria_Contabancariaregistraboletos_N);
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariaregistraboletos = sdt.gxTv_SdtContaBancaria_Contabancariaregistraboletos ;
         }
         if ( sdt.IsDirty("ContaBancariaDescricao_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariadescricao_f = sdt.gxTv_SdtContaBancaria_Contabancariadescricao_f ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ContaBancariaId" )]
      [  XmlElement( ElementName = "ContaBancariaId"   )]
      public int gxTpr_Contabancariaid
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariaid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtContaBancaria_Contabancariaid != value )
            {
               gxTv_SdtContaBancaria_Mode = "INS";
               this.gxTv_SdtContaBancaria_Contabancariaid_Z_SetNull( );
               this.gxTv_SdtContaBancaria_Agenciaid_Z_SetNull( );
               this.gxTv_SdtContaBancaria_Agencianumero_Z_SetNull( );
               this.gxTv_SdtContaBancaria_Agenciabanconome_Z_SetNull( );
               this.gxTv_SdtContaBancaria_Contabancarianumero_Z_SetNull( );
               this.gxTv_SdtContaBancaria_Contabancariadigito_Z_SetNull( );
               this.gxTv_SdtContaBancaria_Contabancariacountchavepix_f_Z_SetNull( );
               this.gxTv_SdtContaBancaria_Contabancariacarteira_Z_SetNull( );
               this.gxTv_SdtContaBancaria_Contabancariacreatedat_Z_SetNull( );
               this.gxTv_SdtContaBancaria_Contabancariastatus_Z_SetNull( );
               this.gxTv_SdtContaBancaria_Contabancariacreatedby_Z_SetNull( );
               this.gxTv_SdtContaBancaria_Contabancariacreatedbyname_Z_SetNull( );
               this.gxTv_SdtContaBancaria_Contabancariaupdatedat_Z_SetNull( );
               this.gxTv_SdtContaBancaria_Contabancariaupdatedby_Z_SetNull( );
               this.gxTv_SdtContaBancaria_Contabancariaupdatedbyname_Z_SetNull( );
               this.gxTv_SdtContaBancaria_Contabancariaregistraboletos_Z_SetNull( );
               this.gxTv_SdtContaBancaria_Contabancariadescricao_f_Z_SetNull( );
            }
            gxTv_SdtContaBancaria_Contabancariaid = value;
            SetDirty("Contabancariaid");
         }

      }

      [  SoapElement( ElementName = "AgenciaId" )]
      [  XmlElement( ElementName = "AgenciaId"   )]
      public int gxTpr_Agenciaid
      {
         get {
            return gxTv_SdtContaBancaria_Agenciaid ;
         }

         set {
            gxTv_SdtContaBancaria_Agenciaid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Agenciaid = value;
            SetDirty("Agenciaid");
         }

      }

      public void gxTv_SdtContaBancaria_Agenciaid_SetNull( )
      {
         gxTv_SdtContaBancaria_Agenciaid_N = 1;
         gxTv_SdtContaBancaria_Agenciaid = 0;
         SetDirty("Agenciaid");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Agenciaid_IsNull( )
      {
         return (gxTv_SdtContaBancaria_Agenciaid_N==1) ;
      }

      [  SoapElement( ElementName = "AgenciaNumero" )]
      [  XmlElement( ElementName = "AgenciaNumero"   )]
      public int gxTpr_Agencianumero
      {
         get {
            return gxTv_SdtContaBancaria_Agencianumero ;
         }

         set {
            gxTv_SdtContaBancaria_Agencianumero_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Agencianumero = value;
            SetDirty("Agencianumero");
         }

      }

      public void gxTv_SdtContaBancaria_Agencianumero_SetNull( )
      {
         gxTv_SdtContaBancaria_Agencianumero_N = 1;
         gxTv_SdtContaBancaria_Agencianumero = 0;
         SetDirty("Agencianumero");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Agencianumero_IsNull( )
      {
         return (gxTv_SdtContaBancaria_Agencianumero_N==1) ;
      }

      [  SoapElement( ElementName = "AgenciaBancoNome" )]
      [  XmlElement( ElementName = "AgenciaBancoNome"   )]
      public string gxTpr_Agenciabanconome
      {
         get {
            return gxTv_SdtContaBancaria_Agenciabanconome ;
         }

         set {
            gxTv_SdtContaBancaria_Agenciabanconome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Agenciabanconome = value;
            SetDirty("Agenciabanconome");
         }

      }

      public void gxTv_SdtContaBancaria_Agenciabanconome_SetNull( )
      {
         gxTv_SdtContaBancaria_Agenciabanconome_N = 1;
         gxTv_SdtContaBancaria_Agenciabanconome = "";
         SetDirty("Agenciabanconome");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Agenciabanconome_IsNull( )
      {
         return (gxTv_SdtContaBancaria_Agenciabanconome_N==1) ;
      }

      [  SoapElement( ElementName = "ContaBancariaNumero" )]
      [  XmlElement( ElementName = "ContaBancariaNumero"   )]
      public long gxTpr_Contabancarianumero
      {
         get {
            return gxTv_SdtContaBancaria_Contabancarianumero ;
         }

         set {
            gxTv_SdtContaBancaria_Contabancarianumero_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancarianumero = value;
            SetDirty("Contabancarianumero");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancarianumero_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancarianumero_N = 1;
         gxTv_SdtContaBancaria_Contabancarianumero = 0;
         SetDirty("Contabancarianumero");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancarianumero_IsNull( )
      {
         return (gxTv_SdtContaBancaria_Contabancarianumero_N==1) ;
      }

      [  SoapElement( ElementName = "ContaBancariaDigito" )]
      [  XmlElement( ElementName = "ContaBancariaDigito"   )]
      public short gxTpr_Contabancariadigito
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariadigito ;
         }

         set {
            gxTv_SdtContaBancaria_Contabancariadigito_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariadigito = value;
            SetDirty("Contabancariadigito");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariadigito_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariadigito_N = 1;
         gxTv_SdtContaBancaria_Contabancariadigito = 0;
         SetDirty("Contabancariadigito");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariadigito_IsNull( )
      {
         return (gxTv_SdtContaBancaria_Contabancariadigito_N==1) ;
      }

      [  SoapElement( ElementName = "ContaBancariaCountChavePIX_F" )]
      [  XmlElement( ElementName = "ContaBancariaCountChavePIX_F"   )]
      public short gxTpr_Contabancariacountchavepix_f
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariacountchavepix_f ;
         }

         set {
            gxTv_SdtContaBancaria_Contabancariacountchavepix_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariacountchavepix_f = value;
            SetDirty("Contabancariacountchavepix_f");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariacountchavepix_f_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariacountchavepix_f_N = 1;
         gxTv_SdtContaBancaria_Contabancariacountchavepix_f = 0;
         SetDirty("Contabancariacountchavepix_f");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariacountchavepix_f_IsNull( )
      {
         return (gxTv_SdtContaBancaria_Contabancariacountchavepix_f_N==1) ;
      }

      [  SoapElement( ElementName = "ContaBancariaCarteira" )]
      [  XmlElement( ElementName = "ContaBancariaCarteira"   )]
      public long gxTpr_Contabancariacarteira
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariacarteira ;
         }

         set {
            gxTv_SdtContaBancaria_Contabancariacarteira_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariacarteira = value;
            SetDirty("Contabancariacarteira");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariacarteira_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariacarteira_N = 1;
         gxTv_SdtContaBancaria_Contabancariacarteira = 0;
         SetDirty("Contabancariacarteira");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariacarteira_IsNull( )
      {
         return (gxTv_SdtContaBancaria_Contabancariacarteira_N==1) ;
      }

      [  SoapElement( ElementName = "ContaBancariaCreatedAt" )]
      [  XmlElement( ElementName = "ContaBancariaCreatedAt"  , IsNullable=true )]
      public string gxTpr_Contabancariacreatedat_Nullable
      {
         get {
            if ( gxTv_SdtContaBancaria_Contabancariacreatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtContaBancaria_Contabancariacreatedat).value ;
         }

         set {
            gxTv_SdtContaBancaria_Contabancariacreatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtContaBancaria_Contabancariacreatedat = DateTime.MinValue;
            else
               gxTv_SdtContaBancaria_Contabancariacreatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Contabancariacreatedat
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariacreatedat ;
         }

         set {
            gxTv_SdtContaBancaria_Contabancariacreatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariacreatedat = value;
            SetDirty("Contabancariacreatedat");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariacreatedat_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariacreatedat_N = 1;
         gxTv_SdtContaBancaria_Contabancariacreatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Contabancariacreatedat");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariacreatedat_IsNull( )
      {
         return (gxTv_SdtContaBancaria_Contabancariacreatedat_N==1) ;
      }

      [  SoapElement( ElementName = "ContaBancariaStatus" )]
      [  XmlElement( ElementName = "ContaBancariaStatus"   )]
      public bool gxTpr_Contabancariastatus
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariastatus ;
         }

         set {
            gxTv_SdtContaBancaria_Contabancariastatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariastatus = value;
            SetDirty("Contabancariastatus");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariastatus_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariastatus_N = 1;
         gxTv_SdtContaBancaria_Contabancariastatus = false;
         SetDirty("Contabancariastatus");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariastatus_IsNull( )
      {
         return (gxTv_SdtContaBancaria_Contabancariastatus_N==1) ;
      }

      [  SoapElement( ElementName = "ContaBancariaCreatedBy" )]
      [  XmlElement( ElementName = "ContaBancariaCreatedBy"   )]
      public short gxTpr_Contabancariacreatedby
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariacreatedby ;
         }

         set {
            gxTv_SdtContaBancaria_Contabancariacreatedby_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariacreatedby = value;
            SetDirty("Contabancariacreatedby");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariacreatedby_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariacreatedby_N = 1;
         gxTv_SdtContaBancaria_Contabancariacreatedby = 0;
         SetDirty("Contabancariacreatedby");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariacreatedby_IsNull( )
      {
         return (gxTv_SdtContaBancaria_Contabancariacreatedby_N==1) ;
      }

      [  SoapElement( ElementName = "ContaBancariaCreatedByName" )]
      [  XmlElement( ElementName = "ContaBancariaCreatedByName"   )]
      public string gxTpr_Contabancariacreatedbyname
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariacreatedbyname ;
         }

         set {
            gxTv_SdtContaBancaria_Contabancariacreatedbyname_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariacreatedbyname = value;
            SetDirty("Contabancariacreatedbyname");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariacreatedbyname_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariacreatedbyname_N = 1;
         gxTv_SdtContaBancaria_Contabancariacreatedbyname = "";
         SetDirty("Contabancariacreatedbyname");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariacreatedbyname_IsNull( )
      {
         return (gxTv_SdtContaBancaria_Contabancariacreatedbyname_N==1) ;
      }

      [  SoapElement( ElementName = "ContaBancariaUpdatedAt" )]
      [  XmlElement( ElementName = "ContaBancariaUpdatedAt"  , IsNullable=true )]
      public string gxTpr_Contabancariaupdatedat_Nullable
      {
         get {
            if ( gxTv_SdtContaBancaria_Contabancariaupdatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtContaBancaria_Contabancariaupdatedat).value ;
         }

         set {
            gxTv_SdtContaBancaria_Contabancariaupdatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtContaBancaria_Contabancariaupdatedat = DateTime.MinValue;
            else
               gxTv_SdtContaBancaria_Contabancariaupdatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Contabancariaupdatedat
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariaupdatedat ;
         }

         set {
            gxTv_SdtContaBancaria_Contabancariaupdatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariaupdatedat = value;
            SetDirty("Contabancariaupdatedat");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariaupdatedat_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariaupdatedat_N = 1;
         gxTv_SdtContaBancaria_Contabancariaupdatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Contabancariaupdatedat");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariaupdatedat_IsNull( )
      {
         return (gxTv_SdtContaBancaria_Contabancariaupdatedat_N==1) ;
      }

      [  SoapElement( ElementName = "ContaBancariaUpdatedBy" )]
      [  XmlElement( ElementName = "ContaBancariaUpdatedBy"   )]
      public short gxTpr_Contabancariaupdatedby
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariaupdatedby ;
         }

         set {
            gxTv_SdtContaBancaria_Contabancariaupdatedby_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariaupdatedby = value;
            SetDirty("Contabancariaupdatedby");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariaupdatedby_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariaupdatedby_N = 1;
         gxTv_SdtContaBancaria_Contabancariaupdatedby = 0;
         SetDirty("Contabancariaupdatedby");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariaupdatedby_IsNull( )
      {
         return (gxTv_SdtContaBancaria_Contabancariaupdatedby_N==1) ;
      }

      [  SoapElement( ElementName = "ContaBancariaUpdatedByName" )]
      [  XmlElement( ElementName = "ContaBancariaUpdatedByName"   )]
      public string gxTpr_Contabancariaupdatedbyname
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariaupdatedbyname ;
         }

         set {
            gxTv_SdtContaBancaria_Contabancariaupdatedbyname_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariaupdatedbyname = value;
            SetDirty("Contabancariaupdatedbyname");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariaupdatedbyname_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariaupdatedbyname_N = 1;
         gxTv_SdtContaBancaria_Contabancariaupdatedbyname = "";
         SetDirty("Contabancariaupdatedbyname");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariaupdatedbyname_IsNull( )
      {
         return (gxTv_SdtContaBancaria_Contabancariaupdatedbyname_N==1) ;
      }

      [  SoapElement( ElementName = "ContaBancariaRegistraBoletos" )]
      [  XmlElement( ElementName = "ContaBancariaRegistraBoletos"   )]
      public bool gxTpr_Contabancariaregistraboletos
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariaregistraboletos ;
         }

         set {
            gxTv_SdtContaBancaria_Contabancariaregistraboletos_N = 0;
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariaregistraboletos = value;
            SetDirty("Contabancariaregistraboletos");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariaregistraboletos_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariaregistraboletos_N = 1;
         gxTv_SdtContaBancaria_Contabancariaregistraboletos = false;
         SetDirty("Contabancariaregistraboletos");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariaregistraboletos_IsNull( )
      {
         return (gxTv_SdtContaBancaria_Contabancariaregistraboletos_N==1) ;
      }

      [  SoapElement( ElementName = "ContaBancariaDescricao_F" )]
      [  XmlElement( ElementName = "ContaBancariaDescricao_F"   )]
      public string gxTpr_Contabancariadescricao_f
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariadescricao_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariadescricao_f = value;
            SetDirty("Contabancariadescricao_f");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariadescricao_f_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariadescricao_f = "";
         SetDirty("Contabancariadescricao_f");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariadescricao_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtContaBancaria_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtContaBancaria_Mode_SetNull( )
      {
         gxTv_SdtContaBancaria_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtContaBancaria_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtContaBancaria_Initialized_SetNull( )
      {
         gxTv_SdtContaBancaria_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaId_Z" )]
      [  XmlElement( ElementName = "ContaBancariaId_Z"   )]
      public int gxTpr_Contabancariaid_Z
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariaid_Z = value;
            SetDirty("Contabancariaid_Z");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariaid_Z_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariaid_Z = 0;
         SetDirty("Contabancariaid_Z");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaId_Z" )]
      [  XmlElement( ElementName = "AgenciaId_Z"   )]
      public int gxTpr_Agenciaid_Z
      {
         get {
            return gxTv_SdtContaBancaria_Agenciaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Agenciaid_Z = value;
            SetDirty("Agenciaid_Z");
         }

      }

      public void gxTv_SdtContaBancaria_Agenciaid_Z_SetNull( )
      {
         gxTv_SdtContaBancaria_Agenciaid_Z = 0;
         SetDirty("Agenciaid_Z");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Agenciaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaNumero_Z" )]
      [  XmlElement( ElementName = "AgenciaNumero_Z"   )]
      public int gxTpr_Agencianumero_Z
      {
         get {
            return gxTv_SdtContaBancaria_Agencianumero_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Agencianumero_Z = value;
            SetDirty("Agencianumero_Z");
         }

      }

      public void gxTv_SdtContaBancaria_Agencianumero_Z_SetNull( )
      {
         gxTv_SdtContaBancaria_Agencianumero_Z = 0;
         SetDirty("Agencianumero_Z");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Agencianumero_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaBancoNome_Z" )]
      [  XmlElement( ElementName = "AgenciaBancoNome_Z"   )]
      public string gxTpr_Agenciabanconome_Z
      {
         get {
            return gxTv_SdtContaBancaria_Agenciabanconome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Agenciabanconome_Z = value;
            SetDirty("Agenciabanconome_Z");
         }

      }

      public void gxTv_SdtContaBancaria_Agenciabanconome_Z_SetNull( )
      {
         gxTv_SdtContaBancaria_Agenciabanconome_Z = "";
         SetDirty("Agenciabanconome_Z");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Agenciabanconome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaNumero_Z" )]
      [  XmlElement( ElementName = "ContaBancariaNumero_Z"   )]
      public long gxTpr_Contabancarianumero_Z
      {
         get {
            return gxTv_SdtContaBancaria_Contabancarianumero_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancarianumero_Z = value;
            SetDirty("Contabancarianumero_Z");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancarianumero_Z_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancarianumero_Z = 0;
         SetDirty("Contabancarianumero_Z");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancarianumero_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaDigito_Z" )]
      [  XmlElement( ElementName = "ContaBancariaDigito_Z"   )]
      public short gxTpr_Contabancariadigito_Z
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariadigito_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariadigito_Z = value;
            SetDirty("Contabancariadigito_Z");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariadigito_Z_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariadigito_Z = 0;
         SetDirty("Contabancariadigito_Z");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariadigito_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaCountChavePIX_F_Z" )]
      [  XmlElement( ElementName = "ContaBancariaCountChavePIX_F_Z"   )]
      public short gxTpr_Contabancariacountchavepix_f_Z
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariacountchavepix_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariacountchavepix_f_Z = value;
            SetDirty("Contabancariacountchavepix_f_Z");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariacountchavepix_f_Z_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariacountchavepix_f_Z = 0;
         SetDirty("Contabancariacountchavepix_f_Z");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariacountchavepix_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaCarteira_Z" )]
      [  XmlElement( ElementName = "ContaBancariaCarteira_Z"   )]
      public long gxTpr_Contabancariacarteira_Z
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariacarteira_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariacarteira_Z = value;
            SetDirty("Contabancariacarteira_Z");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariacarteira_Z_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariacarteira_Z = 0;
         SetDirty("Contabancariacarteira_Z");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariacarteira_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaCreatedAt_Z" )]
      [  XmlElement( ElementName = "ContaBancariaCreatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Contabancariacreatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtContaBancaria_Contabancariacreatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtContaBancaria_Contabancariacreatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtContaBancaria_Contabancariacreatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtContaBancaria_Contabancariacreatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Contabancariacreatedat_Z
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariacreatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariacreatedat_Z = value;
            SetDirty("Contabancariacreatedat_Z");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariacreatedat_Z_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariacreatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Contabancariacreatedat_Z");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariacreatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaStatus_Z" )]
      [  XmlElement( ElementName = "ContaBancariaStatus_Z"   )]
      public bool gxTpr_Contabancariastatus_Z
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariastatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariastatus_Z = value;
            SetDirty("Contabancariastatus_Z");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariastatus_Z_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariastatus_Z = false;
         SetDirty("Contabancariastatus_Z");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariastatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaCreatedBy_Z" )]
      [  XmlElement( ElementName = "ContaBancariaCreatedBy_Z"   )]
      public short gxTpr_Contabancariacreatedby_Z
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariacreatedby_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariacreatedby_Z = value;
            SetDirty("Contabancariacreatedby_Z");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariacreatedby_Z_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariacreatedby_Z = 0;
         SetDirty("Contabancariacreatedby_Z");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariacreatedby_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaCreatedByName_Z" )]
      [  XmlElement( ElementName = "ContaBancariaCreatedByName_Z"   )]
      public string gxTpr_Contabancariacreatedbyname_Z
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariacreatedbyname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariacreatedbyname_Z = value;
            SetDirty("Contabancariacreatedbyname_Z");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariacreatedbyname_Z_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariacreatedbyname_Z = "";
         SetDirty("Contabancariacreatedbyname_Z");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariacreatedbyname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaUpdatedAt_Z" )]
      [  XmlElement( ElementName = "ContaBancariaUpdatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Contabancariaupdatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtContaBancaria_Contabancariaupdatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtContaBancaria_Contabancariaupdatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtContaBancaria_Contabancariaupdatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtContaBancaria_Contabancariaupdatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Contabancariaupdatedat_Z
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariaupdatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariaupdatedat_Z = value;
            SetDirty("Contabancariaupdatedat_Z");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariaupdatedat_Z_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariaupdatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Contabancariaupdatedat_Z");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariaupdatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaUpdatedBy_Z" )]
      [  XmlElement( ElementName = "ContaBancariaUpdatedBy_Z"   )]
      public short gxTpr_Contabancariaupdatedby_Z
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariaupdatedby_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariaupdatedby_Z = value;
            SetDirty("Contabancariaupdatedby_Z");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariaupdatedby_Z_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariaupdatedby_Z = 0;
         SetDirty("Contabancariaupdatedby_Z");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariaupdatedby_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaUpdatedByName_Z" )]
      [  XmlElement( ElementName = "ContaBancariaUpdatedByName_Z"   )]
      public string gxTpr_Contabancariaupdatedbyname_Z
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariaupdatedbyname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariaupdatedbyname_Z = value;
            SetDirty("Contabancariaupdatedbyname_Z");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariaupdatedbyname_Z_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariaupdatedbyname_Z = "";
         SetDirty("Contabancariaupdatedbyname_Z");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariaupdatedbyname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaRegistraBoletos_Z" )]
      [  XmlElement( ElementName = "ContaBancariaRegistraBoletos_Z"   )]
      public bool gxTpr_Contabancariaregistraboletos_Z
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariaregistraboletos_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariaregistraboletos_Z = value;
            SetDirty("Contabancariaregistraboletos_Z");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariaregistraboletos_Z_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariaregistraboletos_Z = false;
         SetDirty("Contabancariaregistraboletos_Z");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariaregistraboletos_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaDescricao_F_Z" )]
      [  XmlElement( ElementName = "ContaBancariaDescricao_F_Z"   )]
      public string gxTpr_Contabancariadescricao_f_Z
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariadescricao_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariadescricao_f_Z = value;
            SetDirty("Contabancariadescricao_f_Z");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariadescricao_f_Z_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariadescricao_f_Z = "";
         SetDirty("Contabancariadescricao_f_Z");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariadescricao_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaId_N" )]
      [  XmlElement( ElementName = "ContaBancariaId_N"   )]
      public short gxTpr_Contabancariaid_N
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariaid_N = value;
            SetDirty("Contabancariaid_N");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariaid_N_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariaid_N = 0;
         SetDirty("Contabancariaid_N");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaId_N" )]
      [  XmlElement( ElementName = "AgenciaId_N"   )]
      public short gxTpr_Agenciaid_N
      {
         get {
            return gxTv_SdtContaBancaria_Agenciaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Agenciaid_N = value;
            SetDirty("Agenciaid_N");
         }

      }

      public void gxTv_SdtContaBancaria_Agenciaid_N_SetNull( )
      {
         gxTv_SdtContaBancaria_Agenciaid_N = 0;
         SetDirty("Agenciaid_N");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Agenciaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaNumero_N" )]
      [  XmlElement( ElementName = "AgenciaNumero_N"   )]
      public short gxTpr_Agencianumero_N
      {
         get {
            return gxTv_SdtContaBancaria_Agencianumero_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Agencianumero_N = value;
            SetDirty("Agencianumero_N");
         }

      }

      public void gxTv_SdtContaBancaria_Agencianumero_N_SetNull( )
      {
         gxTv_SdtContaBancaria_Agencianumero_N = 0;
         SetDirty("Agencianumero_N");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Agencianumero_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaBancoNome_N" )]
      [  XmlElement( ElementName = "AgenciaBancoNome_N"   )]
      public short gxTpr_Agenciabanconome_N
      {
         get {
            return gxTv_SdtContaBancaria_Agenciabanconome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Agenciabanconome_N = value;
            SetDirty("Agenciabanconome_N");
         }

      }

      public void gxTv_SdtContaBancaria_Agenciabanconome_N_SetNull( )
      {
         gxTv_SdtContaBancaria_Agenciabanconome_N = 0;
         SetDirty("Agenciabanconome_N");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Agenciabanconome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaNumero_N" )]
      [  XmlElement( ElementName = "ContaBancariaNumero_N"   )]
      public short gxTpr_Contabancarianumero_N
      {
         get {
            return gxTv_SdtContaBancaria_Contabancarianumero_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancarianumero_N = value;
            SetDirty("Contabancarianumero_N");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancarianumero_N_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancarianumero_N = 0;
         SetDirty("Contabancarianumero_N");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancarianumero_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaDigito_N" )]
      [  XmlElement( ElementName = "ContaBancariaDigito_N"   )]
      public short gxTpr_Contabancariadigito_N
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariadigito_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariadigito_N = value;
            SetDirty("Contabancariadigito_N");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariadigito_N_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariadigito_N = 0;
         SetDirty("Contabancariadigito_N");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariadigito_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaCountChavePIX_F_N" )]
      [  XmlElement( ElementName = "ContaBancariaCountChavePIX_F_N"   )]
      public short gxTpr_Contabancariacountchavepix_f_N
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariacountchavepix_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariacountchavepix_f_N = value;
            SetDirty("Contabancariacountchavepix_f_N");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariacountchavepix_f_N_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariacountchavepix_f_N = 0;
         SetDirty("Contabancariacountchavepix_f_N");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariacountchavepix_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaCarteira_N" )]
      [  XmlElement( ElementName = "ContaBancariaCarteira_N"   )]
      public short gxTpr_Contabancariacarteira_N
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariacarteira_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariacarteira_N = value;
            SetDirty("Contabancariacarteira_N");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariacarteira_N_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariacarteira_N = 0;
         SetDirty("Contabancariacarteira_N");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariacarteira_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaCreatedAt_N" )]
      [  XmlElement( ElementName = "ContaBancariaCreatedAt_N"   )]
      public short gxTpr_Contabancariacreatedat_N
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariacreatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariacreatedat_N = value;
            SetDirty("Contabancariacreatedat_N");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariacreatedat_N_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariacreatedat_N = 0;
         SetDirty("Contabancariacreatedat_N");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariacreatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaStatus_N" )]
      [  XmlElement( ElementName = "ContaBancariaStatus_N"   )]
      public short gxTpr_Contabancariastatus_N
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariastatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariastatus_N = value;
            SetDirty("Contabancariastatus_N");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariastatus_N_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariastatus_N = 0;
         SetDirty("Contabancariastatus_N");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariastatus_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaCreatedBy_N" )]
      [  XmlElement( ElementName = "ContaBancariaCreatedBy_N"   )]
      public short gxTpr_Contabancariacreatedby_N
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariacreatedby_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariacreatedby_N = value;
            SetDirty("Contabancariacreatedby_N");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariacreatedby_N_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariacreatedby_N = 0;
         SetDirty("Contabancariacreatedby_N");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariacreatedby_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaCreatedByName_N" )]
      [  XmlElement( ElementName = "ContaBancariaCreatedByName_N"   )]
      public short gxTpr_Contabancariacreatedbyname_N
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariacreatedbyname_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariacreatedbyname_N = value;
            SetDirty("Contabancariacreatedbyname_N");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariacreatedbyname_N_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariacreatedbyname_N = 0;
         SetDirty("Contabancariacreatedbyname_N");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariacreatedbyname_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaUpdatedAt_N" )]
      [  XmlElement( ElementName = "ContaBancariaUpdatedAt_N"   )]
      public short gxTpr_Contabancariaupdatedat_N
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariaupdatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariaupdatedat_N = value;
            SetDirty("Contabancariaupdatedat_N");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariaupdatedat_N_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariaupdatedat_N = 0;
         SetDirty("Contabancariaupdatedat_N");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariaupdatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaUpdatedBy_N" )]
      [  XmlElement( ElementName = "ContaBancariaUpdatedBy_N"   )]
      public short gxTpr_Contabancariaupdatedby_N
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariaupdatedby_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariaupdatedby_N = value;
            SetDirty("Contabancariaupdatedby_N");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariaupdatedby_N_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariaupdatedby_N = 0;
         SetDirty("Contabancariaupdatedby_N");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariaupdatedby_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaUpdatedByName_N" )]
      [  XmlElement( ElementName = "ContaBancariaUpdatedByName_N"   )]
      public short gxTpr_Contabancariaupdatedbyname_N
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariaupdatedbyname_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariaupdatedbyname_N = value;
            SetDirty("Contabancariaupdatedbyname_N");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariaupdatedbyname_N_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariaupdatedbyname_N = 0;
         SetDirty("Contabancariaupdatedbyname_N");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariaupdatedbyname_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContaBancariaRegistraBoletos_N" )]
      [  XmlElement( ElementName = "ContaBancariaRegistraBoletos_N"   )]
      public short gxTpr_Contabancariaregistraboletos_N
      {
         get {
            return gxTv_SdtContaBancaria_Contabancariaregistraboletos_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtContaBancaria_Contabancariaregistraboletos_N = value;
            SetDirty("Contabancariaregistraboletos_N");
         }

      }

      public void gxTv_SdtContaBancaria_Contabancariaregistraboletos_N_SetNull( )
      {
         gxTv_SdtContaBancaria_Contabancariaregistraboletos_N = 0;
         SetDirty("Contabancariaregistraboletos_N");
         return  ;
      }

      public bool gxTv_SdtContaBancaria_Contabancariaregistraboletos_N_IsNull( )
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
         gxTv_SdtContaBancaria_Agenciabanconome = "";
         gxTv_SdtContaBancaria_Contabancariacreatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtContaBancaria_Contabancariacreatedbyname = "";
         gxTv_SdtContaBancaria_Contabancariaupdatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtContaBancaria_Contabancariaupdatedbyname = "";
         gxTv_SdtContaBancaria_Contabancariadescricao_f = "";
         gxTv_SdtContaBancaria_Mode = "";
         gxTv_SdtContaBancaria_Agenciabanconome_Z = "";
         gxTv_SdtContaBancaria_Contabancariacreatedat_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtContaBancaria_Contabancariacreatedbyname_Z = "";
         gxTv_SdtContaBancaria_Contabancariaupdatedat_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtContaBancaria_Contabancariaupdatedbyname_Z = "";
         gxTv_SdtContaBancaria_Contabancariadescricao_f_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "contabancaria", "GeneXus.Programs.contabancaria_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtContaBancaria_Contabancariadigito ;
      private short gxTv_SdtContaBancaria_Contabancariacountchavepix_f ;
      private short gxTv_SdtContaBancaria_Contabancariacreatedby ;
      private short gxTv_SdtContaBancaria_Contabancariaupdatedby ;
      private short gxTv_SdtContaBancaria_Initialized ;
      private short gxTv_SdtContaBancaria_Contabancariadigito_Z ;
      private short gxTv_SdtContaBancaria_Contabancariacountchavepix_f_Z ;
      private short gxTv_SdtContaBancaria_Contabancariacreatedby_Z ;
      private short gxTv_SdtContaBancaria_Contabancariaupdatedby_Z ;
      private short gxTv_SdtContaBancaria_Contabancariaid_N ;
      private short gxTv_SdtContaBancaria_Agenciaid_N ;
      private short gxTv_SdtContaBancaria_Agencianumero_N ;
      private short gxTv_SdtContaBancaria_Agenciabanconome_N ;
      private short gxTv_SdtContaBancaria_Contabancarianumero_N ;
      private short gxTv_SdtContaBancaria_Contabancariadigito_N ;
      private short gxTv_SdtContaBancaria_Contabancariacountchavepix_f_N ;
      private short gxTv_SdtContaBancaria_Contabancariacarteira_N ;
      private short gxTv_SdtContaBancaria_Contabancariacreatedat_N ;
      private short gxTv_SdtContaBancaria_Contabancariastatus_N ;
      private short gxTv_SdtContaBancaria_Contabancariacreatedby_N ;
      private short gxTv_SdtContaBancaria_Contabancariacreatedbyname_N ;
      private short gxTv_SdtContaBancaria_Contabancariaupdatedat_N ;
      private short gxTv_SdtContaBancaria_Contabancariaupdatedby_N ;
      private short gxTv_SdtContaBancaria_Contabancariaupdatedbyname_N ;
      private short gxTv_SdtContaBancaria_Contabancariaregistraboletos_N ;
      private int gxTv_SdtContaBancaria_Contabancariaid ;
      private int gxTv_SdtContaBancaria_Agenciaid ;
      private int gxTv_SdtContaBancaria_Agencianumero ;
      private int gxTv_SdtContaBancaria_Contabancariaid_Z ;
      private int gxTv_SdtContaBancaria_Agenciaid_Z ;
      private int gxTv_SdtContaBancaria_Agencianumero_Z ;
      private long gxTv_SdtContaBancaria_Contabancarianumero ;
      private long gxTv_SdtContaBancaria_Contabancariacarteira ;
      private long gxTv_SdtContaBancaria_Contabancarianumero_Z ;
      private long gxTv_SdtContaBancaria_Contabancariacarteira_Z ;
      private string gxTv_SdtContaBancaria_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtContaBancaria_Contabancariacreatedat ;
      private DateTime gxTv_SdtContaBancaria_Contabancariaupdatedat ;
      private DateTime gxTv_SdtContaBancaria_Contabancariacreatedat_Z ;
      private DateTime gxTv_SdtContaBancaria_Contabancariaupdatedat_Z ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtContaBancaria_Contabancariastatus ;
      private bool gxTv_SdtContaBancaria_Contabancariaregistraboletos ;
      private bool gxTv_SdtContaBancaria_Contabancariastatus_Z ;
      private bool gxTv_SdtContaBancaria_Contabancariaregistraboletos_Z ;
      private string gxTv_SdtContaBancaria_Agenciabanconome ;
      private string gxTv_SdtContaBancaria_Contabancariacreatedbyname ;
      private string gxTv_SdtContaBancaria_Contabancariaupdatedbyname ;
      private string gxTv_SdtContaBancaria_Contabancariadescricao_f ;
      private string gxTv_SdtContaBancaria_Agenciabanconome_Z ;
      private string gxTv_SdtContaBancaria_Contabancariacreatedbyname_Z ;
      private string gxTv_SdtContaBancaria_Contabancariaupdatedbyname_Z ;
      private string gxTv_SdtContaBancaria_Contabancariadescricao_f_Z ;
   }

   [DataContract(Name = @"ContaBancaria", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtContaBancaria_RESTInterface : GxGenericCollectionItem<SdtContaBancaria>
   {
      public SdtContaBancaria_RESTInterface( ) : base()
      {
      }

      public SdtContaBancaria_RESTInterface( SdtContaBancaria psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ContaBancariaId" , Order = 0 )]
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

      [DataMember( Name = "AgenciaId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Agenciaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Agenciaid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Agenciaid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "AgenciaNumero" , Order = 2 )]
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

      [DataMember( Name = "AgenciaBancoNome" , Order = 3 )]
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

      [DataMember( Name = "ContaBancariaNumero" , Order = 4 )]
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

      [DataMember( Name = "ContaBancariaDigito" , Order = 5 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Contabancariadigito
      {
         get {
            return sdt.gxTpr_Contabancariadigito ;
         }

         set {
            sdt.gxTpr_Contabancariadigito = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ContaBancariaCountChavePIX_F" , Order = 6 )]
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

      [DataMember( Name = "ContaBancariaCarteira" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Contabancariacarteira
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Contabancariacarteira), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Contabancariacarteira = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ContaBancariaCreatedAt" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Contabancariacreatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Contabancariacreatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Contabancariacreatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "ContaBancariaStatus" , Order = 9 )]
      [GxSeudo()]
      public bool gxTpr_Contabancariastatus
      {
         get {
            return sdt.gxTpr_Contabancariastatus ;
         }

         set {
            sdt.gxTpr_Contabancariastatus = value;
         }

      }

      [DataMember( Name = "ContaBancariaCreatedBy" , Order = 10 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Contabancariacreatedby
      {
         get {
            return sdt.gxTpr_Contabancariacreatedby ;
         }

         set {
            sdt.gxTpr_Contabancariacreatedby = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ContaBancariaCreatedByName" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Contabancariacreatedbyname
      {
         get {
            return sdt.gxTpr_Contabancariacreatedbyname ;
         }

         set {
            sdt.gxTpr_Contabancariacreatedbyname = value;
         }

      }

      [DataMember( Name = "ContaBancariaUpdatedAt" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Contabancariaupdatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Contabancariaupdatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Contabancariaupdatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "ContaBancariaUpdatedBy" , Order = 13 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Contabancariaupdatedby
      {
         get {
            return sdt.gxTpr_Contabancariaupdatedby ;
         }

         set {
            sdt.gxTpr_Contabancariaupdatedby = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ContaBancariaUpdatedByName" , Order = 14 )]
      [GxSeudo()]
      public string gxTpr_Contabancariaupdatedbyname
      {
         get {
            return sdt.gxTpr_Contabancariaupdatedbyname ;
         }

         set {
            sdt.gxTpr_Contabancariaupdatedbyname = value;
         }

      }

      [DataMember( Name = "ContaBancariaRegistraBoletos" , Order = 15 )]
      [GxSeudo()]
      public bool gxTpr_Contabancariaregistraboletos
      {
         get {
            return sdt.gxTpr_Contabancariaregistraboletos ;
         }

         set {
            sdt.gxTpr_Contabancariaregistraboletos = value;
         }

      }

      [DataMember( Name = "ContaBancariaDescricao_F" , Order = 16 )]
      [GxSeudo()]
      public string gxTpr_Contabancariadescricao_f
      {
         get {
            return sdt.gxTpr_Contabancariadescricao_f ;
         }

         set {
            sdt.gxTpr_Contabancariadescricao_f = value;
         }

      }

      public SdtContaBancaria sdt
      {
         get {
            return (SdtContaBancaria)Sdt ;
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
            sdt = new SdtContaBancaria() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 17 )]
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

   [DataContract(Name = @"ContaBancaria", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtContaBancaria_RESTLInterface : GxGenericCollectionItem<SdtContaBancaria>
   {
      public SdtContaBancaria_RESTLInterface( ) : base()
      {
      }

      public SdtContaBancaria_RESTLInterface( SdtContaBancaria psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ContaBancariaNumero" , Order = 0 )]
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

      [DataMember( Name = "uri" , Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtContaBancaria sdt
      {
         get {
            return (SdtContaBancaria)Sdt ;
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
            sdt = new SdtContaBancaria() ;
         }
      }

   }

}
