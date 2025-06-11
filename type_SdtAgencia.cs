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
   [XmlRoot(ElementName = "Agencia" )]
   [XmlType(TypeName =  "Agencia" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtAgencia : GxSilentTrnSdt
   {
      public SdtAgencia( )
      {
      }

      public SdtAgencia( IGxContext context )
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

      public void Load( int AV938AgenciaId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV938AgenciaId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"AgenciaId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Agencia");
         metadata.Set("BT", "Agencia");
         metadata.Set("PK", "[ \"AgenciaId\" ]");
         metadata.Set("PKAssigned", "[ \"AgenciaId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"BancoId\" ],\"FKMap\":[ \"AgenciaBancoId-BancoId\" ] },{ \"FK\":[ \"SecUserId\" ],\"FKMap\":[ \"AgenciaCreatedBy-SecUserId\" ] },{ \"FK\":[ \"SecUserId\" ],\"FKMap\":[ \"AgenciaUpdatedBy-SecUserId\" ] } ]");
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
         state.Add("gxTpr_Agenciaid_Z");
         state.Add("gxTpr_Agenciabancoid_Z");
         state.Add("gxTpr_Agenciabanconome_Z");
         state.Add("gxTpr_Agenciabancocodigo_Z");
         state.Add("gxTpr_Agencianumero_Z");
         state.Add("gxTpr_Agenciadigito_Z");
         state.Add("gxTpr_Agenciastatus_Z");
         state.Add("gxTpr_Agenciacreatedat_Z_Nullable");
         state.Add("gxTpr_Agenciaupdatedat_Z_Nullable");
         state.Add("gxTpr_Agenciacreatedby_Z");
         state.Add("gxTpr_Agenciacreatedbyname_Z");
         state.Add("gxTpr_Agenciaupdatedby_Z");
         state.Add("gxTpr_Agenciaupdatedbyname_Z");
         state.Add("gxTpr_Agenciaid_N");
         state.Add("gxTpr_Agenciabancoid_N");
         state.Add("gxTpr_Agenciabanconome_N");
         state.Add("gxTpr_Agenciabancocodigo_N");
         state.Add("gxTpr_Agencianumero_N");
         state.Add("gxTpr_Agenciadigito_N");
         state.Add("gxTpr_Agenciastatus_N");
         state.Add("gxTpr_Agenciacreatedat_N");
         state.Add("gxTpr_Agenciaupdatedat_N");
         state.Add("gxTpr_Agenciacreatedby_N");
         state.Add("gxTpr_Agenciacreatedbyname_N");
         state.Add("gxTpr_Agenciaupdatedby_N");
         state.Add("gxTpr_Agenciaupdatedbyname_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtAgencia sdt;
         sdt = (SdtAgencia)(source);
         gxTv_SdtAgencia_Agenciaid = sdt.gxTv_SdtAgencia_Agenciaid ;
         gxTv_SdtAgencia_Agenciabancoid = sdt.gxTv_SdtAgencia_Agenciabancoid ;
         gxTv_SdtAgencia_Agenciabanconome = sdt.gxTv_SdtAgencia_Agenciabanconome ;
         gxTv_SdtAgencia_Agenciabancocodigo = sdt.gxTv_SdtAgencia_Agenciabancocodigo ;
         gxTv_SdtAgencia_Agencianumero = sdt.gxTv_SdtAgencia_Agencianumero ;
         gxTv_SdtAgencia_Agenciadigito = sdt.gxTv_SdtAgencia_Agenciadigito ;
         gxTv_SdtAgencia_Agenciastatus = sdt.gxTv_SdtAgencia_Agenciastatus ;
         gxTv_SdtAgencia_Agenciacreatedat = sdt.gxTv_SdtAgencia_Agenciacreatedat ;
         gxTv_SdtAgencia_Agenciaupdatedat = sdt.gxTv_SdtAgencia_Agenciaupdatedat ;
         gxTv_SdtAgencia_Agenciacreatedby = sdt.gxTv_SdtAgencia_Agenciacreatedby ;
         gxTv_SdtAgencia_Agenciacreatedbyname = sdt.gxTv_SdtAgencia_Agenciacreatedbyname ;
         gxTv_SdtAgencia_Agenciaupdatedby = sdt.gxTv_SdtAgencia_Agenciaupdatedby ;
         gxTv_SdtAgencia_Agenciaupdatedbyname = sdt.gxTv_SdtAgencia_Agenciaupdatedbyname ;
         gxTv_SdtAgencia_Mode = sdt.gxTv_SdtAgencia_Mode ;
         gxTv_SdtAgencia_Initialized = sdt.gxTv_SdtAgencia_Initialized ;
         gxTv_SdtAgencia_Agenciaid_Z = sdt.gxTv_SdtAgencia_Agenciaid_Z ;
         gxTv_SdtAgencia_Agenciabancoid_Z = sdt.gxTv_SdtAgencia_Agenciabancoid_Z ;
         gxTv_SdtAgencia_Agenciabanconome_Z = sdt.gxTv_SdtAgencia_Agenciabanconome_Z ;
         gxTv_SdtAgencia_Agenciabancocodigo_Z = sdt.gxTv_SdtAgencia_Agenciabancocodigo_Z ;
         gxTv_SdtAgencia_Agencianumero_Z = sdt.gxTv_SdtAgencia_Agencianumero_Z ;
         gxTv_SdtAgencia_Agenciadigito_Z = sdt.gxTv_SdtAgencia_Agenciadigito_Z ;
         gxTv_SdtAgencia_Agenciastatus_Z = sdt.gxTv_SdtAgencia_Agenciastatus_Z ;
         gxTv_SdtAgencia_Agenciacreatedat_Z = sdt.gxTv_SdtAgencia_Agenciacreatedat_Z ;
         gxTv_SdtAgencia_Agenciaupdatedat_Z = sdt.gxTv_SdtAgencia_Agenciaupdatedat_Z ;
         gxTv_SdtAgencia_Agenciacreatedby_Z = sdt.gxTv_SdtAgencia_Agenciacreatedby_Z ;
         gxTv_SdtAgencia_Agenciacreatedbyname_Z = sdt.gxTv_SdtAgencia_Agenciacreatedbyname_Z ;
         gxTv_SdtAgencia_Agenciaupdatedby_Z = sdt.gxTv_SdtAgencia_Agenciaupdatedby_Z ;
         gxTv_SdtAgencia_Agenciaupdatedbyname_Z = sdt.gxTv_SdtAgencia_Agenciaupdatedbyname_Z ;
         gxTv_SdtAgencia_Agenciaid_N = sdt.gxTv_SdtAgencia_Agenciaid_N ;
         gxTv_SdtAgencia_Agenciabancoid_N = sdt.gxTv_SdtAgencia_Agenciabancoid_N ;
         gxTv_SdtAgencia_Agenciabanconome_N = sdt.gxTv_SdtAgencia_Agenciabanconome_N ;
         gxTv_SdtAgencia_Agenciabancocodigo_N = sdt.gxTv_SdtAgencia_Agenciabancocodigo_N ;
         gxTv_SdtAgencia_Agencianumero_N = sdt.gxTv_SdtAgencia_Agencianumero_N ;
         gxTv_SdtAgencia_Agenciadigito_N = sdt.gxTv_SdtAgencia_Agenciadigito_N ;
         gxTv_SdtAgencia_Agenciastatus_N = sdt.gxTv_SdtAgencia_Agenciastatus_N ;
         gxTv_SdtAgencia_Agenciacreatedat_N = sdt.gxTv_SdtAgencia_Agenciacreatedat_N ;
         gxTv_SdtAgencia_Agenciaupdatedat_N = sdt.gxTv_SdtAgencia_Agenciaupdatedat_N ;
         gxTv_SdtAgencia_Agenciacreatedby_N = sdt.gxTv_SdtAgencia_Agenciacreatedby_N ;
         gxTv_SdtAgencia_Agenciacreatedbyname_N = sdt.gxTv_SdtAgencia_Agenciacreatedbyname_N ;
         gxTv_SdtAgencia_Agenciaupdatedby_N = sdt.gxTv_SdtAgencia_Agenciaupdatedby_N ;
         gxTv_SdtAgencia_Agenciaupdatedbyname_N = sdt.gxTv_SdtAgencia_Agenciaupdatedbyname_N ;
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
         AddObjectProperty("AgenciaId", gxTv_SdtAgencia_Agenciaid, false, includeNonInitialized);
         AddObjectProperty("AgenciaId_N", gxTv_SdtAgencia_Agenciaid_N, false, includeNonInitialized);
         AddObjectProperty("AgenciaBancoId", gxTv_SdtAgencia_Agenciabancoid, false, includeNonInitialized);
         AddObjectProperty("AgenciaBancoId_N", gxTv_SdtAgencia_Agenciabancoid_N, false, includeNonInitialized);
         AddObjectProperty("AgenciaBancoNome", gxTv_SdtAgencia_Agenciabanconome, false, includeNonInitialized);
         AddObjectProperty("AgenciaBancoNome_N", gxTv_SdtAgencia_Agenciabanconome_N, false, includeNonInitialized);
         AddObjectProperty("AgenciaBancoCodigo", gxTv_SdtAgencia_Agenciabancocodigo, false, includeNonInitialized);
         AddObjectProperty("AgenciaBancoCodigo_N", gxTv_SdtAgencia_Agenciabancocodigo_N, false, includeNonInitialized);
         AddObjectProperty("AgenciaNumero", gxTv_SdtAgencia_Agencianumero, false, includeNonInitialized);
         AddObjectProperty("AgenciaNumero_N", gxTv_SdtAgencia_Agencianumero_N, false, includeNonInitialized);
         AddObjectProperty("AgenciaDigito", gxTv_SdtAgencia_Agenciadigito, false, includeNonInitialized);
         AddObjectProperty("AgenciaDigito_N", gxTv_SdtAgencia_Agenciadigito_N, false, includeNonInitialized);
         AddObjectProperty("AgenciaStatus", gxTv_SdtAgencia_Agenciastatus, false, includeNonInitialized);
         AddObjectProperty("AgenciaStatus_N", gxTv_SdtAgencia_Agenciastatus_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtAgencia_Agenciacreatedat;
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
         AddObjectProperty("AgenciaCreatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("AgenciaCreatedAt_N", gxTv_SdtAgencia_Agenciacreatedat_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtAgencia_Agenciaupdatedat;
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
         AddObjectProperty("AgenciaUpdatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("AgenciaUpdatedAt_N", gxTv_SdtAgencia_Agenciaupdatedat_N, false, includeNonInitialized);
         AddObjectProperty("AgenciaCreatedBy", gxTv_SdtAgencia_Agenciacreatedby, false, includeNonInitialized);
         AddObjectProperty("AgenciaCreatedBy_N", gxTv_SdtAgencia_Agenciacreatedby_N, false, includeNonInitialized);
         AddObjectProperty("AgenciaCreatedByName", gxTv_SdtAgencia_Agenciacreatedbyname, false, includeNonInitialized);
         AddObjectProperty("AgenciaCreatedByName_N", gxTv_SdtAgencia_Agenciacreatedbyname_N, false, includeNonInitialized);
         AddObjectProperty("AgenciaUpdatedBy", gxTv_SdtAgencia_Agenciaupdatedby, false, includeNonInitialized);
         AddObjectProperty("AgenciaUpdatedBy_N", gxTv_SdtAgencia_Agenciaupdatedby_N, false, includeNonInitialized);
         AddObjectProperty("AgenciaUpdatedByName", gxTv_SdtAgencia_Agenciaupdatedbyname, false, includeNonInitialized);
         AddObjectProperty("AgenciaUpdatedByName_N", gxTv_SdtAgencia_Agenciaupdatedbyname_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtAgencia_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtAgencia_Initialized, false, includeNonInitialized);
            AddObjectProperty("AgenciaId_Z", gxTv_SdtAgencia_Agenciaid_Z, false, includeNonInitialized);
            AddObjectProperty("AgenciaBancoId_Z", gxTv_SdtAgencia_Agenciabancoid_Z, false, includeNonInitialized);
            AddObjectProperty("AgenciaBancoNome_Z", gxTv_SdtAgencia_Agenciabanconome_Z, false, includeNonInitialized);
            AddObjectProperty("AgenciaBancoCodigo_Z", gxTv_SdtAgencia_Agenciabancocodigo_Z, false, includeNonInitialized);
            AddObjectProperty("AgenciaNumero_Z", gxTv_SdtAgencia_Agencianumero_Z, false, includeNonInitialized);
            AddObjectProperty("AgenciaDigito_Z", gxTv_SdtAgencia_Agenciadigito_Z, false, includeNonInitialized);
            AddObjectProperty("AgenciaStatus_Z", gxTv_SdtAgencia_Agenciastatus_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtAgencia_Agenciacreatedat_Z;
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
            AddObjectProperty("AgenciaCreatedAt_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtAgencia_Agenciaupdatedat_Z;
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
            AddObjectProperty("AgenciaUpdatedAt_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("AgenciaCreatedBy_Z", gxTv_SdtAgencia_Agenciacreatedby_Z, false, includeNonInitialized);
            AddObjectProperty("AgenciaCreatedByName_Z", gxTv_SdtAgencia_Agenciacreatedbyname_Z, false, includeNonInitialized);
            AddObjectProperty("AgenciaUpdatedBy_Z", gxTv_SdtAgencia_Agenciaupdatedby_Z, false, includeNonInitialized);
            AddObjectProperty("AgenciaUpdatedByName_Z", gxTv_SdtAgencia_Agenciaupdatedbyname_Z, false, includeNonInitialized);
            AddObjectProperty("AgenciaId_N", gxTv_SdtAgencia_Agenciaid_N, false, includeNonInitialized);
            AddObjectProperty("AgenciaBancoId_N", gxTv_SdtAgencia_Agenciabancoid_N, false, includeNonInitialized);
            AddObjectProperty("AgenciaBancoNome_N", gxTv_SdtAgencia_Agenciabanconome_N, false, includeNonInitialized);
            AddObjectProperty("AgenciaBancoCodigo_N", gxTv_SdtAgencia_Agenciabancocodigo_N, false, includeNonInitialized);
            AddObjectProperty("AgenciaNumero_N", gxTv_SdtAgencia_Agencianumero_N, false, includeNonInitialized);
            AddObjectProperty("AgenciaDigito_N", gxTv_SdtAgencia_Agenciadigito_N, false, includeNonInitialized);
            AddObjectProperty("AgenciaStatus_N", gxTv_SdtAgencia_Agenciastatus_N, false, includeNonInitialized);
            AddObjectProperty("AgenciaCreatedAt_N", gxTv_SdtAgencia_Agenciacreatedat_N, false, includeNonInitialized);
            AddObjectProperty("AgenciaUpdatedAt_N", gxTv_SdtAgencia_Agenciaupdatedat_N, false, includeNonInitialized);
            AddObjectProperty("AgenciaCreatedBy_N", gxTv_SdtAgencia_Agenciacreatedby_N, false, includeNonInitialized);
            AddObjectProperty("AgenciaCreatedByName_N", gxTv_SdtAgencia_Agenciacreatedbyname_N, false, includeNonInitialized);
            AddObjectProperty("AgenciaUpdatedBy_N", gxTv_SdtAgencia_Agenciaupdatedby_N, false, includeNonInitialized);
            AddObjectProperty("AgenciaUpdatedByName_N", gxTv_SdtAgencia_Agenciaupdatedbyname_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtAgencia sdt )
      {
         if ( sdt.IsDirty("AgenciaId") )
         {
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciaid = sdt.gxTv_SdtAgencia_Agenciaid ;
         }
         if ( sdt.IsDirty("AgenciaBancoId") )
         {
            gxTv_SdtAgencia_Agenciabancoid_N = (short)(sdt.gxTv_SdtAgencia_Agenciabancoid_N);
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciabancoid = sdt.gxTv_SdtAgencia_Agenciabancoid ;
         }
         if ( sdt.IsDirty("AgenciaBancoNome") )
         {
            gxTv_SdtAgencia_Agenciabanconome_N = (short)(sdt.gxTv_SdtAgencia_Agenciabanconome_N);
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciabanconome = sdt.gxTv_SdtAgencia_Agenciabanconome ;
         }
         if ( sdt.IsDirty("AgenciaBancoCodigo") )
         {
            gxTv_SdtAgencia_Agenciabancocodigo_N = (short)(sdt.gxTv_SdtAgencia_Agenciabancocodigo_N);
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciabancocodigo = sdt.gxTv_SdtAgencia_Agenciabancocodigo ;
         }
         if ( sdt.IsDirty("AgenciaNumero") )
         {
            gxTv_SdtAgencia_Agencianumero_N = (short)(sdt.gxTv_SdtAgencia_Agencianumero_N);
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agencianumero = sdt.gxTv_SdtAgencia_Agencianumero ;
         }
         if ( sdt.IsDirty("AgenciaDigito") )
         {
            gxTv_SdtAgencia_Agenciadigito_N = (short)(sdt.gxTv_SdtAgencia_Agenciadigito_N);
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciadigito = sdt.gxTv_SdtAgencia_Agenciadigito ;
         }
         if ( sdt.IsDirty("AgenciaStatus") )
         {
            gxTv_SdtAgencia_Agenciastatus_N = (short)(sdt.gxTv_SdtAgencia_Agenciastatus_N);
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciastatus = sdt.gxTv_SdtAgencia_Agenciastatus ;
         }
         if ( sdt.IsDirty("AgenciaCreatedAt") )
         {
            gxTv_SdtAgencia_Agenciacreatedat_N = (short)(sdt.gxTv_SdtAgencia_Agenciacreatedat_N);
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciacreatedat = sdt.gxTv_SdtAgencia_Agenciacreatedat ;
         }
         if ( sdt.IsDirty("AgenciaUpdatedAt") )
         {
            gxTv_SdtAgencia_Agenciaupdatedat_N = (short)(sdt.gxTv_SdtAgencia_Agenciaupdatedat_N);
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciaupdatedat = sdt.gxTv_SdtAgencia_Agenciaupdatedat ;
         }
         if ( sdt.IsDirty("AgenciaCreatedBy") )
         {
            gxTv_SdtAgencia_Agenciacreatedby_N = (short)(sdt.gxTv_SdtAgencia_Agenciacreatedby_N);
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciacreatedby = sdt.gxTv_SdtAgencia_Agenciacreatedby ;
         }
         if ( sdt.IsDirty("AgenciaCreatedByName") )
         {
            gxTv_SdtAgencia_Agenciacreatedbyname_N = (short)(sdt.gxTv_SdtAgencia_Agenciacreatedbyname_N);
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciacreatedbyname = sdt.gxTv_SdtAgencia_Agenciacreatedbyname ;
         }
         if ( sdt.IsDirty("AgenciaUpdatedBy") )
         {
            gxTv_SdtAgencia_Agenciaupdatedby_N = (short)(sdt.gxTv_SdtAgencia_Agenciaupdatedby_N);
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciaupdatedby = sdt.gxTv_SdtAgencia_Agenciaupdatedby ;
         }
         if ( sdt.IsDirty("AgenciaUpdatedByName") )
         {
            gxTv_SdtAgencia_Agenciaupdatedbyname_N = (short)(sdt.gxTv_SdtAgencia_Agenciaupdatedbyname_N);
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciaupdatedbyname = sdt.gxTv_SdtAgencia_Agenciaupdatedbyname ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "AgenciaId" )]
      [  XmlElement( ElementName = "AgenciaId"   )]
      public int gxTpr_Agenciaid
      {
         get {
            return gxTv_SdtAgencia_Agenciaid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtAgencia_Agenciaid != value )
            {
               gxTv_SdtAgencia_Mode = "INS";
               this.gxTv_SdtAgencia_Agenciaid_Z_SetNull( );
               this.gxTv_SdtAgencia_Agenciabancoid_Z_SetNull( );
               this.gxTv_SdtAgencia_Agenciabanconome_Z_SetNull( );
               this.gxTv_SdtAgencia_Agenciabancocodigo_Z_SetNull( );
               this.gxTv_SdtAgencia_Agencianumero_Z_SetNull( );
               this.gxTv_SdtAgencia_Agenciadigito_Z_SetNull( );
               this.gxTv_SdtAgencia_Agenciastatus_Z_SetNull( );
               this.gxTv_SdtAgencia_Agenciacreatedat_Z_SetNull( );
               this.gxTv_SdtAgencia_Agenciaupdatedat_Z_SetNull( );
               this.gxTv_SdtAgencia_Agenciacreatedby_Z_SetNull( );
               this.gxTv_SdtAgencia_Agenciacreatedbyname_Z_SetNull( );
               this.gxTv_SdtAgencia_Agenciaupdatedby_Z_SetNull( );
               this.gxTv_SdtAgencia_Agenciaupdatedbyname_Z_SetNull( );
            }
            gxTv_SdtAgencia_Agenciaid = value;
            SetDirty("Agenciaid");
         }

      }

      [  SoapElement( ElementName = "AgenciaBancoId" )]
      [  XmlElement( ElementName = "AgenciaBancoId"   )]
      public int gxTpr_Agenciabancoid
      {
         get {
            return gxTv_SdtAgencia_Agenciabancoid ;
         }

         set {
            gxTv_SdtAgencia_Agenciabancoid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciabancoid = value;
            SetDirty("Agenciabancoid");
         }

      }

      public void gxTv_SdtAgencia_Agenciabancoid_SetNull( )
      {
         gxTv_SdtAgencia_Agenciabancoid_N = 1;
         gxTv_SdtAgencia_Agenciabancoid = 0;
         SetDirty("Agenciabancoid");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agenciabancoid_IsNull( )
      {
         return (gxTv_SdtAgencia_Agenciabancoid_N==1) ;
      }

      [  SoapElement( ElementName = "AgenciaBancoNome" )]
      [  XmlElement( ElementName = "AgenciaBancoNome"   )]
      public string gxTpr_Agenciabanconome
      {
         get {
            return gxTv_SdtAgencia_Agenciabanconome ;
         }

         set {
            gxTv_SdtAgencia_Agenciabanconome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciabanconome = value;
            SetDirty("Agenciabanconome");
         }

      }

      public void gxTv_SdtAgencia_Agenciabanconome_SetNull( )
      {
         gxTv_SdtAgencia_Agenciabanconome_N = 1;
         gxTv_SdtAgencia_Agenciabanconome = "";
         SetDirty("Agenciabanconome");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agenciabanconome_IsNull( )
      {
         return (gxTv_SdtAgencia_Agenciabanconome_N==1) ;
      }

      [  SoapElement( ElementName = "AgenciaBancoCodigo" )]
      [  XmlElement( ElementName = "AgenciaBancoCodigo"   )]
      public int gxTpr_Agenciabancocodigo
      {
         get {
            return gxTv_SdtAgencia_Agenciabancocodigo ;
         }

         set {
            gxTv_SdtAgencia_Agenciabancocodigo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciabancocodigo = value;
            SetDirty("Agenciabancocodigo");
         }

      }

      public void gxTv_SdtAgencia_Agenciabancocodigo_SetNull( )
      {
         gxTv_SdtAgencia_Agenciabancocodigo_N = 1;
         gxTv_SdtAgencia_Agenciabancocodigo = 0;
         SetDirty("Agenciabancocodigo");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agenciabancocodigo_IsNull( )
      {
         return (gxTv_SdtAgencia_Agenciabancocodigo_N==1) ;
      }

      [  SoapElement( ElementName = "AgenciaNumero" )]
      [  XmlElement( ElementName = "AgenciaNumero"   )]
      public int gxTpr_Agencianumero
      {
         get {
            return gxTv_SdtAgencia_Agencianumero ;
         }

         set {
            gxTv_SdtAgencia_Agencianumero_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agencianumero = value;
            SetDirty("Agencianumero");
         }

      }

      public void gxTv_SdtAgencia_Agencianumero_SetNull( )
      {
         gxTv_SdtAgencia_Agencianumero_N = 1;
         gxTv_SdtAgencia_Agencianumero = 0;
         SetDirty("Agencianumero");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agencianumero_IsNull( )
      {
         return (gxTv_SdtAgencia_Agencianumero_N==1) ;
      }

      [  SoapElement( ElementName = "AgenciaDigito" )]
      [  XmlElement( ElementName = "AgenciaDigito"   )]
      public int gxTpr_Agenciadigito
      {
         get {
            return gxTv_SdtAgencia_Agenciadigito ;
         }

         set {
            gxTv_SdtAgencia_Agenciadigito_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciadigito = value;
            SetDirty("Agenciadigito");
         }

      }

      public void gxTv_SdtAgencia_Agenciadigito_SetNull( )
      {
         gxTv_SdtAgencia_Agenciadigito_N = 1;
         gxTv_SdtAgencia_Agenciadigito = 0;
         SetDirty("Agenciadigito");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agenciadigito_IsNull( )
      {
         return (gxTv_SdtAgencia_Agenciadigito_N==1) ;
      }

      [  SoapElement( ElementName = "AgenciaStatus" )]
      [  XmlElement( ElementName = "AgenciaStatus"   )]
      public bool gxTpr_Agenciastatus
      {
         get {
            return gxTv_SdtAgencia_Agenciastatus ;
         }

         set {
            gxTv_SdtAgencia_Agenciastatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciastatus = value;
            SetDirty("Agenciastatus");
         }

      }

      public void gxTv_SdtAgencia_Agenciastatus_SetNull( )
      {
         gxTv_SdtAgencia_Agenciastatus_N = 1;
         gxTv_SdtAgencia_Agenciastatus = false;
         SetDirty("Agenciastatus");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agenciastatus_IsNull( )
      {
         return (gxTv_SdtAgencia_Agenciastatus_N==1) ;
      }

      [  SoapElement( ElementName = "AgenciaCreatedAt" )]
      [  XmlElement( ElementName = "AgenciaCreatedAt"  , IsNullable=true )]
      public string gxTpr_Agenciacreatedat_Nullable
      {
         get {
            if ( gxTv_SdtAgencia_Agenciacreatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtAgencia_Agenciacreatedat).value ;
         }

         set {
            gxTv_SdtAgencia_Agenciacreatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtAgencia_Agenciacreatedat = DateTime.MinValue;
            else
               gxTv_SdtAgencia_Agenciacreatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Agenciacreatedat
      {
         get {
            return gxTv_SdtAgencia_Agenciacreatedat ;
         }

         set {
            gxTv_SdtAgencia_Agenciacreatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciacreatedat = value;
            SetDirty("Agenciacreatedat");
         }

      }

      public void gxTv_SdtAgencia_Agenciacreatedat_SetNull( )
      {
         gxTv_SdtAgencia_Agenciacreatedat_N = 1;
         gxTv_SdtAgencia_Agenciacreatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Agenciacreatedat");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agenciacreatedat_IsNull( )
      {
         return (gxTv_SdtAgencia_Agenciacreatedat_N==1) ;
      }

      [  SoapElement( ElementName = "AgenciaUpdatedAt" )]
      [  XmlElement( ElementName = "AgenciaUpdatedAt"  , IsNullable=true )]
      public string gxTpr_Agenciaupdatedat_Nullable
      {
         get {
            if ( gxTv_SdtAgencia_Agenciaupdatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtAgencia_Agenciaupdatedat).value ;
         }

         set {
            gxTv_SdtAgencia_Agenciaupdatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtAgencia_Agenciaupdatedat = DateTime.MinValue;
            else
               gxTv_SdtAgencia_Agenciaupdatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Agenciaupdatedat
      {
         get {
            return gxTv_SdtAgencia_Agenciaupdatedat ;
         }

         set {
            gxTv_SdtAgencia_Agenciaupdatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciaupdatedat = value;
            SetDirty("Agenciaupdatedat");
         }

      }

      public void gxTv_SdtAgencia_Agenciaupdatedat_SetNull( )
      {
         gxTv_SdtAgencia_Agenciaupdatedat_N = 1;
         gxTv_SdtAgencia_Agenciaupdatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Agenciaupdatedat");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agenciaupdatedat_IsNull( )
      {
         return (gxTv_SdtAgencia_Agenciaupdatedat_N==1) ;
      }

      [  SoapElement( ElementName = "AgenciaCreatedBy" )]
      [  XmlElement( ElementName = "AgenciaCreatedBy"   )]
      public short gxTpr_Agenciacreatedby
      {
         get {
            return gxTv_SdtAgencia_Agenciacreatedby ;
         }

         set {
            gxTv_SdtAgencia_Agenciacreatedby_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciacreatedby = value;
            SetDirty("Agenciacreatedby");
         }

      }

      public void gxTv_SdtAgencia_Agenciacreatedby_SetNull( )
      {
         gxTv_SdtAgencia_Agenciacreatedby_N = 1;
         gxTv_SdtAgencia_Agenciacreatedby = 0;
         SetDirty("Agenciacreatedby");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agenciacreatedby_IsNull( )
      {
         return (gxTv_SdtAgencia_Agenciacreatedby_N==1) ;
      }

      [  SoapElement( ElementName = "AgenciaCreatedByName" )]
      [  XmlElement( ElementName = "AgenciaCreatedByName"   )]
      public string gxTpr_Agenciacreatedbyname
      {
         get {
            return gxTv_SdtAgencia_Agenciacreatedbyname ;
         }

         set {
            gxTv_SdtAgencia_Agenciacreatedbyname_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciacreatedbyname = value;
            SetDirty("Agenciacreatedbyname");
         }

      }

      public void gxTv_SdtAgencia_Agenciacreatedbyname_SetNull( )
      {
         gxTv_SdtAgencia_Agenciacreatedbyname_N = 1;
         gxTv_SdtAgencia_Agenciacreatedbyname = "";
         SetDirty("Agenciacreatedbyname");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agenciacreatedbyname_IsNull( )
      {
         return (gxTv_SdtAgencia_Agenciacreatedbyname_N==1) ;
      }

      [  SoapElement( ElementName = "AgenciaUpdatedBy" )]
      [  XmlElement( ElementName = "AgenciaUpdatedBy"   )]
      public short gxTpr_Agenciaupdatedby
      {
         get {
            return gxTv_SdtAgencia_Agenciaupdatedby ;
         }

         set {
            gxTv_SdtAgencia_Agenciaupdatedby_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciaupdatedby = value;
            SetDirty("Agenciaupdatedby");
         }

      }

      public void gxTv_SdtAgencia_Agenciaupdatedby_SetNull( )
      {
         gxTv_SdtAgencia_Agenciaupdatedby_N = 1;
         gxTv_SdtAgencia_Agenciaupdatedby = 0;
         SetDirty("Agenciaupdatedby");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agenciaupdatedby_IsNull( )
      {
         return (gxTv_SdtAgencia_Agenciaupdatedby_N==1) ;
      }

      [  SoapElement( ElementName = "AgenciaUpdatedByName" )]
      [  XmlElement( ElementName = "AgenciaUpdatedByName"   )]
      public string gxTpr_Agenciaupdatedbyname
      {
         get {
            return gxTv_SdtAgencia_Agenciaupdatedbyname ;
         }

         set {
            gxTv_SdtAgencia_Agenciaupdatedbyname_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciaupdatedbyname = value;
            SetDirty("Agenciaupdatedbyname");
         }

      }

      public void gxTv_SdtAgencia_Agenciaupdatedbyname_SetNull( )
      {
         gxTv_SdtAgencia_Agenciaupdatedbyname_N = 1;
         gxTv_SdtAgencia_Agenciaupdatedbyname = "";
         SetDirty("Agenciaupdatedbyname");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agenciaupdatedbyname_IsNull( )
      {
         return (gxTv_SdtAgencia_Agenciaupdatedbyname_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtAgencia_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAgencia_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtAgencia_Mode_SetNull( )
      {
         gxTv_SdtAgencia_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtAgencia_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtAgencia_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAgencia_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtAgencia_Initialized_SetNull( )
      {
         gxTv_SdtAgencia_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtAgencia_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaId_Z" )]
      [  XmlElement( ElementName = "AgenciaId_Z"   )]
      public int gxTpr_Agenciaid_Z
      {
         get {
            return gxTv_SdtAgencia_Agenciaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciaid_Z = value;
            SetDirty("Agenciaid_Z");
         }

      }

      public void gxTv_SdtAgencia_Agenciaid_Z_SetNull( )
      {
         gxTv_SdtAgencia_Agenciaid_Z = 0;
         SetDirty("Agenciaid_Z");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agenciaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaBancoId_Z" )]
      [  XmlElement( ElementName = "AgenciaBancoId_Z"   )]
      public int gxTpr_Agenciabancoid_Z
      {
         get {
            return gxTv_SdtAgencia_Agenciabancoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciabancoid_Z = value;
            SetDirty("Agenciabancoid_Z");
         }

      }

      public void gxTv_SdtAgencia_Agenciabancoid_Z_SetNull( )
      {
         gxTv_SdtAgencia_Agenciabancoid_Z = 0;
         SetDirty("Agenciabancoid_Z");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agenciabancoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaBancoNome_Z" )]
      [  XmlElement( ElementName = "AgenciaBancoNome_Z"   )]
      public string gxTpr_Agenciabanconome_Z
      {
         get {
            return gxTv_SdtAgencia_Agenciabanconome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciabanconome_Z = value;
            SetDirty("Agenciabanconome_Z");
         }

      }

      public void gxTv_SdtAgencia_Agenciabanconome_Z_SetNull( )
      {
         gxTv_SdtAgencia_Agenciabanconome_Z = "";
         SetDirty("Agenciabanconome_Z");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agenciabanconome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaBancoCodigo_Z" )]
      [  XmlElement( ElementName = "AgenciaBancoCodigo_Z"   )]
      public int gxTpr_Agenciabancocodigo_Z
      {
         get {
            return gxTv_SdtAgencia_Agenciabancocodigo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciabancocodigo_Z = value;
            SetDirty("Agenciabancocodigo_Z");
         }

      }

      public void gxTv_SdtAgencia_Agenciabancocodigo_Z_SetNull( )
      {
         gxTv_SdtAgencia_Agenciabancocodigo_Z = 0;
         SetDirty("Agenciabancocodigo_Z");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agenciabancocodigo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaNumero_Z" )]
      [  XmlElement( ElementName = "AgenciaNumero_Z"   )]
      public int gxTpr_Agencianumero_Z
      {
         get {
            return gxTv_SdtAgencia_Agencianumero_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agencianumero_Z = value;
            SetDirty("Agencianumero_Z");
         }

      }

      public void gxTv_SdtAgencia_Agencianumero_Z_SetNull( )
      {
         gxTv_SdtAgencia_Agencianumero_Z = 0;
         SetDirty("Agencianumero_Z");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agencianumero_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaDigito_Z" )]
      [  XmlElement( ElementName = "AgenciaDigito_Z"   )]
      public int gxTpr_Agenciadigito_Z
      {
         get {
            return gxTv_SdtAgencia_Agenciadigito_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciadigito_Z = value;
            SetDirty("Agenciadigito_Z");
         }

      }

      public void gxTv_SdtAgencia_Agenciadigito_Z_SetNull( )
      {
         gxTv_SdtAgencia_Agenciadigito_Z = 0;
         SetDirty("Agenciadigito_Z");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agenciadigito_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaStatus_Z" )]
      [  XmlElement( ElementName = "AgenciaStatus_Z"   )]
      public bool gxTpr_Agenciastatus_Z
      {
         get {
            return gxTv_SdtAgencia_Agenciastatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciastatus_Z = value;
            SetDirty("Agenciastatus_Z");
         }

      }

      public void gxTv_SdtAgencia_Agenciastatus_Z_SetNull( )
      {
         gxTv_SdtAgencia_Agenciastatus_Z = false;
         SetDirty("Agenciastatus_Z");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agenciastatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaCreatedAt_Z" )]
      [  XmlElement( ElementName = "AgenciaCreatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Agenciacreatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtAgencia_Agenciacreatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtAgencia_Agenciacreatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtAgencia_Agenciacreatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtAgencia_Agenciacreatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Agenciacreatedat_Z
      {
         get {
            return gxTv_SdtAgencia_Agenciacreatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciacreatedat_Z = value;
            SetDirty("Agenciacreatedat_Z");
         }

      }

      public void gxTv_SdtAgencia_Agenciacreatedat_Z_SetNull( )
      {
         gxTv_SdtAgencia_Agenciacreatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Agenciacreatedat_Z");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agenciacreatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaUpdatedAt_Z" )]
      [  XmlElement( ElementName = "AgenciaUpdatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Agenciaupdatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtAgencia_Agenciaupdatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtAgencia_Agenciaupdatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtAgencia_Agenciaupdatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtAgencia_Agenciaupdatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Agenciaupdatedat_Z
      {
         get {
            return gxTv_SdtAgencia_Agenciaupdatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciaupdatedat_Z = value;
            SetDirty("Agenciaupdatedat_Z");
         }

      }

      public void gxTv_SdtAgencia_Agenciaupdatedat_Z_SetNull( )
      {
         gxTv_SdtAgencia_Agenciaupdatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Agenciaupdatedat_Z");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agenciaupdatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaCreatedBy_Z" )]
      [  XmlElement( ElementName = "AgenciaCreatedBy_Z"   )]
      public short gxTpr_Agenciacreatedby_Z
      {
         get {
            return gxTv_SdtAgencia_Agenciacreatedby_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciacreatedby_Z = value;
            SetDirty("Agenciacreatedby_Z");
         }

      }

      public void gxTv_SdtAgencia_Agenciacreatedby_Z_SetNull( )
      {
         gxTv_SdtAgencia_Agenciacreatedby_Z = 0;
         SetDirty("Agenciacreatedby_Z");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agenciacreatedby_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaCreatedByName_Z" )]
      [  XmlElement( ElementName = "AgenciaCreatedByName_Z"   )]
      public string gxTpr_Agenciacreatedbyname_Z
      {
         get {
            return gxTv_SdtAgencia_Agenciacreatedbyname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciacreatedbyname_Z = value;
            SetDirty("Agenciacreatedbyname_Z");
         }

      }

      public void gxTv_SdtAgencia_Agenciacreatedbyname_Z_SetNull( )
      {
         gxTv_SdtAgencia_Agenciacreatedbyname_Z = "";
         SetDirty("Agenciacreatedbyname_Z");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agenciacreatedbyname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaUpdatedBy_Z" )]
      [  XmlElement( ElementName = "AgenciaUpdatedBy_Z"   )]
      public short gxTpr_Agenciaupdatedby_Z
      {
         get {
            return gxTv_SdtAgencia_Agenciaupdatedby_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciaupdatedby_Z = value;
            SetDirty("Agenciaupdatedby_Z");
         }

      }

      public void gxTv_SdtAgencia_Agenciaupdatedby_Z_SetNull( )
      {
         gxTv_SdtAgencia_Agenciaupdatedby_Z = 0;
         SetDirty("Agenciaupdatedby_Z");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agenciaupdatedby_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaUpdatedByName_Z" )]
      [  XmlElement( ElementName = "AgenciaUpdatedByName_Z"   )]
      public string gxTpr_Agenciaupdatedbyname_Z
      {
         get {
            return gxTv_SdtAgencia_Agenciaupdatedbyname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciaupdatedbyname_Z = value;
            SetDirty("Agenciaupdatedbyname_Z");
         }

      }

      public void gxTv_SdtAgencia_Agenciaupdatedbyname_Z_SetNull( )
      {
         gxTv_SdtAgencia_Agenciaupdatedbyname_Z = "";
         SetDirty("Agenciaupdatedbyname_Z");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agenciaupdatedbyname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaId_N" )]
      [  XmlElement( ElementName = "AgenciaId_N"   )]
      public short gxTpr_Agenciaid_N
      {
         get {
            return gxTv_SdtAgencia_Agenciaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciaid_N = value;
            SetDirty("Agenciaid_N");
         }

      }

      public void gxTv_SdtAgencia_Agenciaid_N_SetNull( )
      {
         gxTv_SdtAgencia_Agenciaid_N = 0;
         SetDirty("Agenciaid_N");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agenciaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaBancoId_N" )]
      [  XmlElement( ElementName = "AgenciaBancoId_N"   )]
      public short gxTpr_Agenciabancoid_N
      {
         get {
            return gxTv_SdtAgencia_Agenciabancoid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciabancoid_N = value;
            SetDirty("Agenciabancoid_N");
         }

      }

      public void gxTv_SdtAgencia_Agenciabancoid_N_SetNull( )
      {
         gxTv_SdtAgencia_Agenciabancoid_N = 0;
         SetDirty("Agenciabancoid_N");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agenciabancoid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaBancoNome_N" )]
      [  XmlElement( ElementName = "AgenciaBancoNome_N"   )]
      public short gxTpr_Agenciabanconome_N
      {
         get {
            return gxTv_SdtAgencia_Agenciabanconome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciabanconome_N = value;
            SetDirty("Agenciabanconome_N");
         }

      }

      public void gxTv_SdtAgencia_Agenciabanconome_N_SetNull( )
      {
         gxTv_SdtAgencia_Agenciabanconome_N = 0;
         SetDirty("Agenciabanconome_N");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agenciabanconome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaBancoCodigo_N" )]
      [  XmlElement( ElementName = "AgenciaBancoCodigo_N"   )]
      public short gxTpr_Agenciabancocodigo_N
      {
         get {
            return gxTv_SdtAgencia_Agenciabancocodigo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciabancocodigo_N = value;
            SetDirty("Agenciabancocodigo_N");
         }

      }

      public void gxTv_SdtAgencia_Agenciabancocodigo_N_SetNull( )
      {
         gxTv_SdtAgencia_Agenciabancocodigo_N = 0;
         SetDirty("Agenciabancocodigo_N");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agenciabancocodigo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaNumero_N" )]
      [  XmlElement( ElementName = "AgenciaNumero_N"   )]
      public short gxTpr_Agencianumero_N
      {
         get {
            return gxTv_SdtAgencia_Agencianumero_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agencianumero_N = value;
            SetDirty("Agencianumero_N");
         }

      }

      public void gxTv_SdtAgencia_Agencianumero_N_SetNull( )
      {
         gxTv_SdtAgencia_Agencianumero_N = 0;
         SetDirty("Agencianumero_N");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agencianumero_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaDigito_N" )]
      [  XmlElement( ElementName = "AgenciaDigito_N"   )]
      public short gxTpr_Agenciadigito_N
      {
         get {
            return gxTv_SdtAgencia_Agenciadigito_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciadigito_N = value;
            SetDirty("Agenciadigito_N");
         }

      }

      public void gxTv_SdtAgencia_Agenciadigito_N_SetNull( )
      {
         gxTv_SdtAgencia_Agenciadigito_N = 0;
         SetDirty("Agenciadigito_N");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agenciadigito_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaStatus_N" )]
      [  XmlElement( ElementName = "AgenciaStatus_N"   )]
      public short gxTpr_Agenciastatus_N
      {
         get {
            return gxTv_SdtAgencia_Agenciastatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciastatus_N = value;
            SetDirty("Agenciastatus_N");
         }

      }

      public void gxTv_SdtAgencia_Agenciastatus_N_SetNull( )
      {
         gxTv_SdtAgencia_Agenciastatus_N = 0;
         SetDirty("Agenciastatus_N");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agenciastatus_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaCreatedAt_N" )]
      [  XmlElement( ElementName = "AgenciaCreatedAt_N"   )]
      public short gxTpr_Agenciacreatedat_N
      {
         get {
            return gxTv_SdtAgencia_Agenciacreatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciacreatedat_N = value;
            SetDirty("Agenciacreatedat_N");
         }

      }

      public void gxTv_SdtAgencia_Agenciacreatedat_N_SetNull( )
      {
         gxTv_SdtAgencia_Agenciacreatedat_N = 0;
         SetDirty("Agenciacreatedat_N");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agenciacreatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaUpdatedAt_N" )]
      [  XmlElement( ElementName = "AgenciaUpdatedAt_N"   )]
      public short gxTpr_Agenciaupdatedat_N
      {
         get {
            return gxTv_SdtAgencia_Agenciaupdatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciaupdatedat_N = value;
            SetDirty("Agenciaupdatedat_N");
         }

      }

      public void gxTv_SdtAgencia_Agenciaupdatedat_N_SetNull( )
      {
         gxTv_SdtAgencia_Agenciaupdatedat_N = 0;
         SetDirty("Agenciaupdatedat_N");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agenciaupdatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaCreatedBy_N" )]
      [  XmlElement( ElementName = "AgenciaCreatedBy_N"   )]
      public short gxTpr_Agenciacreatedby_N
      {
         get {
            return gxTv_SdtAgencia_Agenciacreatedby_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciacreatedby_N = value;
            SetDirty("Agenciacreatedby_N");
         }

      }

      public void gxTv_SdtAgencia_Agenciacreatedby_N_SetNull( )
      {
         gxTv_SdtAgencia_Agenciacreatedby_N = 0;
         SetDirty("Agenciacreatedby_N");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agenciacreatedby_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaCreatedByName_N" )]
      [  XmlElement( ElementName = "AgenciaCreatedByName_N"   )]
      public short gxTpr_Agenciacreatedbyname_N
      {
         get {
            return gxTv_SdtAgencia_Agenciacreatedbyname_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciacreatedbyname_N = value;
            SetDirty("Agenciacreatedbyname_N");
         }

      }

      public void gxTv_SdtAgencia_Agenciacreatedbyname_N_SetNull( )
      {
         gxTv_SdtAgencia_Agenciacreatedbyname_N = 0;
         SetDirty("Agenciacreatedbyname_N");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agenciacreatedbyname_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaUpdatedBy_N" )]
      [  XmlElement( ElementName = "AgenciaUpdatedBy_N"   )]
      public short gxTpr_Agenciaupdatedby_N
      {
         get {
            return gxTv_SdtAgencia_Agenciaupdatedby_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciaupdatedby_N = value;
            SetDirty("Agenciaupdatedby_N");
         }

      }

      public void gxTv_SdtAgencia_Agenciaupdatedby_N_SetNull( )
      {
         gxTv_SdtAgencia_Agenciaupdatedby_N = 0;
         SetDirty("Agenciaupdatedby_N");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agenciaupdatedby_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AgenciaUpdatedByName_N" )]
      [  XmlElement( ElementName = "AgenciaUpdatedByName_N"   )]
      public short gxTpr_Agenciaupdatedbyname_N
      {
         get {
            return gxTv_SdtAgencia_Agenciaupdatedbyname_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAgencia_Agenciaupdatedbyname_N = value;
            SetDirty("Agenciaupdatedbyname_N");
         }

      }

      public void gxTv_SdtAgencia_Agenciaupdatedbyname_N_SetNull( )
      {
         gxTv_SdtAgencia_Agenciaupdatedbyname_N = 0;
         SetDirty("Agenciaupdatedbyname_N");
         return  ;
      }

      public bool gxTv_SdtAgencia_Agenciaupdatedbyname_N_IsNull( )
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
         gxTv_SdtAgencia_Agenciabanconome = "";
         gxTv_SdtAgencia_Agenciacreatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtAgencia_Agenciaupdatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtAgencia_Agenciacreatedbyname = "";
         gxTv_SdtAgencia_Agenciaupdatedbyname = "";
         gxTv_SdtAgencia_Mode = "";
         gxTv_SdtAgencia_Agenciabanconome_Z = "";
         gxTv_SdtAgencia_Agenciacreatedat_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtAgencia_Agenciaupdatedat_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtAgencia_Agenciacreatedbyname_Z = "";
         gxTv_SdtAgencia_Agenciaupdatedbyname_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "agencia", "GeneXus.Programs.agencia_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtAgencia_Agenciacreatedby ;
      private short gxTv_SdtAgencia_Agenciaupdatedby ;
      private short gxTv_SdtAgencia_Initialized ;
      private short gxTv_SdtAgencia_Agenciacreatedby_Z ;
      private short gxTv_SdtAgencia_Agenciaupdatedby_Z ;
      private short gxTv_SdtAgencia_Agenciaid_N ;
      private short gxTv_SdtAgencia_Agenciabancoid_N ;
      private short gxTv_SdtAgencia_Agenciabanconome_N ;
      private short gxTv_SdtAgencia_Agenciabancocodigo_N ;
      private short gxTv_SdtAgencia_Agencianumero_N ;
      private short gxTv_SdtAgencia_Agenciadigito_N ;
      private short gxTv_SdtAgencia_Agenciastatus_N ;
      private short gxTv_SdtAgencia_Agenciacreatedat_N ;
      private short gxTv_SdtAgencia_Agenciaupdatedat_N ;
      private short gxTv_SdtAgencia_Agenciacreatedby_N ;
      private short gxTv_SdtAgencia_Agenciacreatedbyname_N ;
      private short gxTv_SdtAgencia_Agenciaupdatedby_N ;
      private short gxTv_SdtAgencia_Agenciaupdatedbyname_N ;
      private int gxTv_SdtAgencia_Agenciaid ;
      private int gxTv_SdtAgencia_Agenciabancoid ;
      private int gxTv_SdtAgencia_Agenciabancocodigo ;
      private int gxTv_SdtAgencia_Agencianumero ;
      private int gxTv_SdtAgencia_Agenciadigito ;
      private int gxTv_SdtAgencia_Agenciaid_Z ;
      private int gxTv_SdtAgencia_Agenciabancoid_Z ;
      private int gxTv_SdtAgencia_Agenciabancocodigo_Z ;
      private int gxTv_SdtAgencia_Agencianumero_Z ;
      private int gxTv_SdtAgencia_Agenciadigito_Z ;
      private string gxTv_SdtAgencia_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtAgencia_Agenciacreatedat ;
      private DateTime gxTv_SdtAgencia_Agenciaupdatedat ;
      private DateTime gxTv_SdtAgencia_Agenciacreatedat_Z ;
      private DateTime gxTv_SdtAgencia_Agenciaupdatedat_Z ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtAgencia_Agenciastatus ;
      private bool gxTv_SdtAgencia_Agenciastatus_Z ;
      private string gxTv_SdtAgencia_Agenciabanconome ;
      private string gxTv_SdtAgencia_Agenciacreatedbyname ;
      private string gxTv_SdtAgencia_Agenciaupdatedbyname ;
      private string gxTv_SdtAgencia_Agenciabanconome_Z ;
      private string gxTv_SdtAgencia_Agenciacreatedbyname_Z ;
      private string gxTv_SdtAgencia_Agenciaupdatedbyname_Z ;
   }

   [DataContract(Name = @"Agencia", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtAgencia_RESTInterface : GxGenericCollectionItem<SdtAgencia>
   {
      public SdtAgencia_RESTInterface( ) : base()
      {
      }

      public SdtAgencia_RESTInterface( SdtAgencia psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AgenciaId" , Order = 0 )]
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

      [DataMember( Name = "AgenciaBancoId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Agenciabancoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Agenciabancoid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Agenciabancoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "AgenciaBancoNome" , Order = 2 )]
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

      [DataMember( Name = "AgenciaBancoCodigo" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Agenciabancocodigo
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Agenciabancocodigo), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Agenciabancocodigo = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "AgenciaNumero" , Order = 4 )]
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

      [DataMember( Name = "AgenciaDigito" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Agenciadigito
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Agenciadigito), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Agenciadigito = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "AgenciaStatus" , Order = 6 )]
      [GxSeudo()]
      public bool gxTpr_Agenciastatus
      {
         get {
            return sdt.gxTpr_Agenciastatus ;
         }

         set {
            sdt.gxTpr_Agenciastatus = value;
         }

      }

      [DataMember( Name = "AgenciaCreatedAt" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Agenciacreatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Agenciacreatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Agenciacreatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "AgenciaUpdatedAt" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Agenciaupdatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Agenciaupdatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Agenciaupdatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "AgenciaCreatedBy" , Order = 9 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Agenciacreatedby
      {
         get {
            return sdt.gxTpr_Agenciacreatedby ;
         }

         set {
            sdt.gxTpr_Agenciacreatedby = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "AgenciaCreatedByName" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Agenciacreatedbyname
      {
         get {
            return sdt.gxTpr_Agenciacreatedbyname ;
         }

         set {
            sdt.gxTpr_Agenciacreatedbyname = value;
         }

      }

      [DataMember( Name = "AgenciaUpdatedBy" , Order = 11 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Agenciaupdatedby
      {
         get {
            return sdt.gxTpr_Agenciaupdatedby ;
         }

         set {
            sdt.gxTpr_Agenciaupdatedby = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "AgenciaUpdatedByName" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Agenciaupdatedbyname
      {
         get {
            return sdt.gxTpr_Agenciaupdatedbyname ;
         }

         set {
            sdt.gxTpr_Agenciaupdatedbyname = value;
         }

      }

      public SdtAgencia sdt
      {
         get {
            return (SdtAgencia)Sdt ;
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
            sdt = new SdtAgencia() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 13 )]
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

   [DataContract(Name = @"Agencia", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtAgencia_RESTLInterface : GxGenericCollectionItem<SdtAgencia>
   {
      public SdtAgencia_RESTLInterface( ) : base()
      {
      }

      public SdtAgencia_RESTLInterface( SdtAgencia psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AgenciaBancoNome" , Order = 0 )]
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

      [DataMember( Name = "uri" , Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtAgencia sdt
      {
         get {
            return (SdtAgencia)Sdt ;
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
            sdt = new SdtAgencia() ;
         }
      }

   }

}
