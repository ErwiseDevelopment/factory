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
   [XmlRoot(ElementName = "Especialidade" )]
   [XmlType(TypeName =  "Especialidade" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtEspecialidade : GxSilentTrnSdt
   {
      public SdtEspecialidade( )
      {
      }

      public SdtEspecialidade( IGxContext context )
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

      public void Load( int AV457EspecialidadeId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV457EspecialidadeId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"EspecialidadeId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Especialidade");
         metadata.Set("BT", "Especialidade");
         metadata.Set("PK", "[ \"EspecialidadeId\" ]");
         metadata.Set("PKAssigned", "[ \"EspecialidadeId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"SecUserId\" ],\"FKMap\":[ \"EspecialidadeCreatedBy-SecUserId\" ] } ]");
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
         state.Add("gxTpr_Especialidadeid_Z");
         state.Add("gxTpr_Especialidadenome_Z");
         state.Add("gxTpr_Especialidadestatus_Z");
         state.Add("gxTpr_Especialidadeupdatedat_Z_Nullable");
         state.Add("gxTpr_Especialidadecreatedat_Z_Nullable");
         state.Add("gxTpr_Especialidadecreatedby_Z");
         state.Add("gxTpr_Especialidadeid_N");
         state.Add("gxTpr_Especialidadenome_N");
         state.Add("gxTpr_Especialidadestatus_N");
         state.Add("gxTpr_Especialidadeupdatedat_N");
         state.Add("gxTpr_Especialidadecreatedat_N");
         state.Add("gxTpr_Especialidadecreatedby_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtEspecialidade sdt;
         sdt = (SdtEspecialidade)(source);
         gxTv_SdtEspecialidade_Especialidadeid = sdt.gxTv_SdtEspecialidade_Especialidadeid ;
         gxTv_SdtEspecialidade_Especialidadenome = sdt.gxTv_SdtEspecialidade_Especialidadenome ;
         gxTv_SdtEspecialidade_Especialidadestatus = sdt.gxTv_SdtEspecialidade_Especialidadestatus ;
         gxTv_SdtEspecialidade_Especialidadeupdatedat = sdt.gxTv_SdtEspecialidade_Especialidadeupdatedat ;
         gxTv_SdtEspecialidade_Especialidadecreatedat = sdt.gxTv_SdtEspecialidade_Especialidadecreatedat ;
         gxTv_SdtEspecialidade_Especialidadecreatedby = sdt.gxTv_SdtEspecialidade_Especialidadecreatedby ;
         gxTv_SdtEspecialidade_Mode = sdt.gxTv_SdtEspecialidade_Mode ;
         gxTv_SdtEspecialidade_Initialized = sdt.gxTv_SdtEspecialidade_Initialized ;
         gxTv_SdtEspecialidade_Especialidadeid_Z = sdt.gxTv_SdtEspecialidade_Especialidadeid_Z ;
         gxTv_SdtEspecialidade_Especialidadenome_Z = sdt.gxTv_SdtEspecialidade_Especialidadenome_Z ;
         gxTv_SdtEspecialidade_Especialidadestatus_Z = sdt.gxTv_SdtEspecialidade_Especialidadestatus_Z ;
         gxTv_SdtEspecialidade_Especialidadeupdatedat_Z = sdt.gxTv_SdtEspecialidade_Especialidadeupdatedat_Z ;
         gxTv_SdtEspecialidade_Especialidadecreatedat_Z = sdt.gxTv_SdtEspecialidade_Especialidadecreatedat_Z ;
         gxTv_SdtEspecialidade_Especialidadecreatedby_Z = sdt.gxTv_SdtEspecialidade_Especialidadecreatedby_Z ;
         gxTv_SdtEspecialidade_Especialidadeid_N = sdt.gxTv_SdtEspecialidade_Especialidadeid_N ;
         gxTv_SdtEspecialidade_Especialidadenome_N = sdt.gxTv_SdtEspecialidade_Especialidadenome_N ;
         gxTv_SdtEspecialidade_Especialidadestatus_N = sdt.gxTv_SdtEspecialidade_Especialidadestatus_N ;
         gxTv_SdtEspecialidade_Especialidadeupdatedat_N = sdt.gxTv_SdtEspecialidade_Especialidadeupdatedat_N ;
         gxTv_SdtEspecialidade_Especialidadecreatedat_N = sdt.gxTv_SdtEspecialidade_Especialidadecreatedat_N ;
         gxTv_SdtEspecialidade_Especialidadecreatedby_N = sdt.gxTv_SdtEspecialidade_Especialidadecreatedby_N ;
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
         AddObjectProperty("EspecialidadeId", gxTv_SdtEspecialidade_Especialidadeid, false, includeNonInitialized);
         AddObjectProperty("EspecialidadeId_N", gxTv_SdtEspecialidade_Especialidadeid_N, false, includeNonInitialized);
         AddObjectProperty("EspecialidadeNome", gxTv_SdtEspecialidade_Especialidadenome, false, includeNonInitialized);
         AddObjectProperty("EspecialidadeNome_N", gxTv_SdtEspecialidade_Especialidadenome_N, false, includeNonInitialized);
         AddObjectProperty("EspecialidadeStatus", gxTv_SdtEspecialidade_Especialidadestatus, false, includeNonInitialized);
         AddObjectProperty("EspecialidadeStatus_N", gxTv_SdtEspecialidade_Especialidadestatus_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtEspecialidade_Especialidadeupdatedat;
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
         AddObjectProperty("EspecialidadeUpdatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("EspecialidadeUpdatedAt_N", gxTv_SdtEspecialidade_Especialidadeupdatedat_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtEspecialidade_Especialidadecreatedat;
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
         AddObjectProperty("EspecialidadeCreatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("EspecialidadeCreatedAt_N", gxTv_SdtEspecialidade_Especialidadecreatedat_N, false, includeNonInitialized);
         AddObjectProperty("EspecialidadeCreatedBy", gxTv_SdtEspecialidade_Especialidadecreatedby, false, includeNonInitialized);
         AddObjectProperty("EspecialidadeCreatedBy_N", gxTv_SdtEspecialidade_Especialidadecreatedby_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtEspecialidade_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtEspecialidade_Initialized, false, includeNonInitialized);
            AddObjectProperty("EspecialidadeId_Z", gxTv_SdtEspecialidade_Especialidadeid_Z, false, includeNonInitialized);
            AddObjectProperty("EspecialidadeNome_Z", gxTv_SdtEspecialidade_Especialidadenome_Z, false, includeNonInitialized);
            AddObjectProperty("EspecialidadeStatus_Z", gxTv_SdtEspecialidade_Especialidadestatus_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtEspecialidade_Especialidadeupdatedat_Z;
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
            AddObjectProperty("EspecialidadeUpdatedAt_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtEspecialidade_Especialidadecreatedat_Z;
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
            AddObjectProperty("EspecialidadeCreatedAt_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("EspecialidadeCreatedBy_Z", gxTv_SdtEspecialidade_Especialidadecreatedby_Z, false, includeNonInitialized);
            AddObjectProperty("EspecialidadeId_N", gxTv_SdtEspecialidade_Especialidadeid_N, false, includeNonInitialized);
            AddObjectProperty("EspecialidadeNome_N", gxTv_SdtEspecialidade_Especialidadenome_N, false, includeNonInitialized);
            AddObjectProperty("EspecialidadeStatus_N", gxTv_SdtEspecialidade_Especialidadestatus_N, false, includeNonInitialized);
            AddObjectProperty("EspecialidadeUpdatedAt_N", gxTv_SdtEspecialidade_Especialidadeupdatedat_N, false, includeNonInitialized);
            AddObjectProperty("EspecialidadeCreatedAt_N", gxTv_SdtEspecialidade_Especialidadecreatedat_N, false, includeNonInitialized);
            AddObjectProperty("EspecialidadeCreatedBy_N", gxTv_SdtEspecialidade_Especialidadecreatedby_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtEspecialidade sdt )
      {
         if ( sdt.IsDirty("EspecialidadeId") )
         {
            sdtIsNull = 0;
            gxTv_SdtEspecialidade_Especialidadeid = sdt.gxTv_SdtEspecialidade_Especialidadeid ;
         }
         if ( sdt.IsDirty("EspecialidadeNome") )
         {
            gxTv_SdtEspecialidade_Especialidadenome_N = (short)(sdt.gxTv_SdtEspecialidade_Especialidadenome_N);
            sdtIsNull = 0;
            gxTv_SdtEspecialidade_Especialidadenome = sdt.gxTv_SdtEspecialidade_Especialidadenome ;
         }
         if ( sdt.IsDirty("EspecialidadeStatus") )
         {
            gxTv_SdtEspecialidade_Especialidadestatus_N = (short)(sdt.gxTv_SdtEspecialidade_Especialidadestatus_N);
            sdtIsNull = 0;
            gxTv_SdtEspecialidade_Especialidadestatus = sdt.gxTv_SdtEspecialidade_Especialidadestatus ;
         }
         if ( sdt.IsDirty("EspecialidadeUpdatedAt") )
         {
            gxTv_SdtEspecialidade_Especialidadeupdatedat_N = (short)(sdt.gxTv_SdtEspecialidade_Especialidadeupdatedat_N);
            sdtIsNull = 0;
            gxTv_SdtEspecialidade_Especialidadeupdatedat = sdt.gxTv_SdtEspecialidade_Especialidadeupdatedat ;
         }
         if ( sdt.IsDirty("EspecialidadeCreatedAt") )
         {
            gxTv_SdtEspecialidade_Especialidadecreatedat_N = (short)(sdt.gxTv_SdtEspecialidade_Especialidadecreatedat_N);
            sdtIsNull = 0;
            gxTv_SdtEspecialidade_Especialidadecreatedat = sdt.gxTv_SdtEspecialidade_Especialidadecreatedat ;
         }
         if ( sdt.IsDirty("EspecialidadeCreatedBy") )
         {
            gxTv_SdtEspecialidade_Especialidadecreatedby_N = (short)(sdt.gxTv_SdtEspecialidade_Especialidadecreatedby_N);
            sdtIsNull = 0;
            gxTv_SdtEspecialidade_Especialidadecreatedby = sdt.gxTv_SdtEspecialidade_Especialidadecreatedby ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "EspecialidadeId" )]
      [  XmlElement( ElementName = "EspecialidadeId"   )]
      public int gxTpr_Especialidadeid
      {
         get {
            return gxTv_SdtEspecialidade_Especialidadeid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtEspecialidade_Especialidadeid != value )
            {
               gxTv_SdtEspecialidade_Mode = "INS";
               this.gxTv_SdtEspecialidade_Especialidadeid_Z_SetNull( );
               this.gxTv_SdtEspecialidade_Especialidadenome_Z_SetNull( );
               this.gxTv_SdtEspecialidade_Especialidadestatus_Z_SetNull( );
               this.gxTv_SdtEspecialidade_Especialidadeupdatedat_Z_SetNull( );
               this.gxTv_SdtEspecialidade_Especialidadecreatedat_Z_SetNull( );
               this.gxTv_SdtEspecialidade_Especialidadecreatedby_Z_SetNull( );
            }
            gxTv_SdtEspecialidade_Especialidadeid = value;
            SetDirty("Especialidadeid");
         }

      }

      [  SoapElement( ElementName = "EspecialidadeNome" )]
      [  XmlElement( ElementName = "EspecialidadeNome"   )]
      public string gxTpr_Especialidadenome
      {
         get {
            return gxTv_SdtEspecialidade_Especialidadenome ;
         }

         set {
            gxTv_SdtEspecialidade_Especialidadenome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEspecialidade_Especialidadenome = value;
            SetDirty("Especialidadenome");
         }

      }

      public void gxTv_SdtEspecialidade_Especialidadenome_SetNull( )
      {
         gxTv_SdtEspecialidade_Especialidadenome_N = 1;
         gxTv_SdtEspecialidade_Especialidadenome = "";
         SetDirty("Especialidadenome");
         return  ;
      }

      public bool gxTv_SdtEspecialidade_Especialidadenome_IsNull( )
      {
         return (gxTv_SdtEspecialidade_Especialidadenome_N==1) ;
      }

      [  SoapElement( ElementName = "EspecialidadeStatus" )]
      [  XmlElement( ElementName = "EspecialidadeStatus"   )]
      public bool gxTpr_Especialidadestatus
      {
         get {
            return gxTv_SdtEspecialidade_Especialidadestatus ;
         }

         set {
            gxTv_SdtEspecialidade_Especialidadestatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEspecialidade_Especialidadestatus = value;
            SetDirty("Especialidadestatus");
         }

      }

      public void gxTv_SdtEspecialidade_Especialidadestatus_SetNull( )
      {
         gxTv_SdtEspecialidade_Especialidadestatus_N = 1;
         gxTv_SdtEspecialidade_Especialidadestatus = false;
         SetDirty("Especialidadestatus");
         return  ;
      }

      public bool gxTv_SdtEspecialidade_Especialidadestatus_IsNull( )
      {
         return (gxTv_SdtEspecialidade_Especialidadestatus_N==1) ;
      }

      [  SoapElement( ElementName = "EspecialidadeUpdatedAt" )]
      [  XmlElement( ElementName = "EspecialidadeUpdatedAt"  , IsNullable=true )]
      public string gxTpr_Especialidadeupdatedat_Nullable
      {
         get {
            if ( gxTv_SdtEspecialidade_Especialidadeupdatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtEspecialidade_Especialidadeupdatedat).value ;
         }

         set {
            gxTv_SdtEspecialidade_Especialidadeupdatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtEspecialidade_Especialidadeupdatedat = DateTime.MinValue;
            else
               gxTv_SdtEspecialidade_Especialidadeupdatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Especialidadeupdatedat
      {
         get {
            return gxTv_SdtEspecialidade_Especialidadeupdatedat ;
         }

         set {
            gxTv_SdtEspecialidade_Especialidadeupdatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEspecialidade_Especialidadeupdatedat = value;
            SetDirty("Especialidadeupdatedat");
         }

      }

      public void gxTv_SdtEspecialidade_Especialidadeupdatedat_SetNull( )
      {
         gxTv_SdtEspecialidade_Especialidadeupdatedat_N = 1;
         gxTv_SdtEspecialidade_Especialidadeupdatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Especialidadeupdatedat");
         return  ;
      }

      public bool gxTv_SdtEspecialidade_Especialidadeupdatedat_IsNull( )
      {
         return (gxTv_SdtEspecialidade_Especialidadeupdatedat_N==1) ;
      }

      [  SoapElement( ElementName = "EspecialidadeCreatedAt" )]
      [  XmlElement( ElementName = "EspecialidadeCreatedAt"  , IsNullable=true )]
      public string gxTpr_Especialidadecreatedat_Nullable
      {
         get {
            if ( gxTv_SdtEspecialidade_Especialidadecreatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtEspecialidade_Especialidadecreatedat).value ;
         }

         set {
            gxTv_SdtEspecialidade_Especialidadecreatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtEspecialidade_Especialidadecreatedat = DateTime.MinValue;
            else
               gxTv_SdtEspecialidade_Especialidadecreatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Especialidadecreatedat
      {
         get {
            return gxTv_SdtEspecialidade_Especialidadecreatedat ;
         }

         set {
            gxTv_SdtEspecialidade_Especialidadecreatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEspecialidade_Especialidadecreatedat = value;
            SetDirty("Especialidadecreatedat");
         }

      }

      public void gxTv_SdtEspecialidade_Especialidadecreatedat_SetNull( )
      {
         gxTv_SdtEspecialidade_Especialidadecreatedat_N = 1;
         gxTv_SdtEspecialidade_Especialidadecreatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Especialidadecreatedat");
         return  ;
      }

      public bool gxTv_SdtEspecialidade_Especialidadecreatedat_IsNull( )
      {
         return (gxTv_SdtEspecialidade_Especialidadecreatedat_N==1) ;
      }

      [  SoapElement( ElementName = "EspecialidadeCreatedBy" )]
      [  XmlElement( ElementName = "EspecialidadeCreatedBy"   )]
      public short gxTpr_Especialidadecreatedby
      {
         get {
            return gxTv_SdtEspecialidade_Especialidadecreatedby ;
         }

         set {
            gxTv_SdtEspecialidade_Especialidadecreatedby_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEspecialidade_Especialidadecreatedby = value;
            SetDirty("Especialidadecreatedby");
         }

      }

      public void gxTv_SdtEspecialidade_Especialidadecreatedby_SetNull( )
      {
         gxTv_SdtEspecialidade_Especialidadecreatedby_N = 1;
         gxTv_SdtEspecialidade_Especialidadecreatedby = 0;
         SetDirty("Especialidadecreatedby");
         return  ;
      }

      public bool gxTv_SdtEspecialidade_Especialidadecreatedby_IsNull( )
      {
         return (gxTv_SdtEspecialidade_Especialidadecreatedby_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtEspecialidade_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEspecialidade_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtEspecialidade_Mode_SetNull( )
      {
         gxTv_SdtEspecialidade_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtEspecialidade_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtEspecialidade_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEspecialidade_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtEspecialidade_Initialized_SetNull( )
      {
         gxTv_SdtEspecialidade_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtEspecialidade_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspecialidadeId_Z" )]
      [  XmlElement( ElementName = "EspecialidadeId_Z"   )]
      public int gxTpr_Especialidadeid_Z
      {
         get {
            return gxTv_SdtEspecialidade_Especialidadeid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEspecialidade_Especialidadeid_Z = value;
            SetDirty("Especialidadeid_Z");
         }

      }

      public void gxTv_SdtEspecialidade_Especialidadeid_Z_SetNull( )
      {
         gxTv_SdtEspecialidade_Especialidadeid_Z = 0;
         SetDirty("Especialidadeid_Z");
         return  ;
      }

      public bool gxTv_SdtEspecialidade_Especialidadeid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspecialidadeNome_Z" )]
      [  XmlElement( ElementName = "EspecialidadeNome_Z"   )]
      public string gxTpr_Especialidadenome_Z
      {
         get {
            return gxTv_SdtEspecialidade_Especialidadenome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEspecialidade_Especialidadenome_Z = value;
            SetDirty("Especialidadenome_Z");
         }

      }

      public void gxTv_SdtEspecialidade_Especialidadenome_Z_SetNull( )
      {
         gxTv_SdtEspecialidade_Especialidadenome_Z = "";
         SetDirty("Especialidadenome_Z");
         return  ;
      }

      public bool gxTv_SdtEspecialidade_Especialidadenome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspecialidadeStatus_Z" )]
      [  XmlElement( ElementName = "EspecialidadeStatus_Z"   )]
      public bool gxTpr_Especialidadestatus_Z
      {
         get {
            return gxTv_SdtEspecialidade_Especialidadestatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEspecialidade_Especialidadestatus_Z = value;
            SetDirty("Especialidadestatus_Z");
         }

      }

      public void gxTv_SdtEspecialidade_Especialidadestatus_Z_SetNull( )
      {
         gxTv_SdtEspecialidade_Especialidadestatus_Z = false;
         SetDirty("Especialidadestatus_Z");
         return  ;
      }

      public bool gxTv_SdtEspecialidade_Especialidadestatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspecialidadeUpdatedAt_Z" )]
      [  XmlElement( ElementName = "EspecialidadeUpdatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Especialidadeupdatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtEspecialidade_Especialidadeupdatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtEspecialidade_Especialidadeupdatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtEspecialidade_Especialidadeupdatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtEspecialidade_Especialidadeupdatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Especialidadeupdatedat_Z
      {
         get {
            return gxTv_SdtEspecialidade_Especialidadeupdatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEspecialidade_Especialidadeupdatedat_Z = value;
            SetDirty("Especialidadeupdatedat_Z");
         }

      }

      public void gxTv_SdtEspecialidade_Especialidadeupdatedat_Z_SetNull( )
      {
         gxTv_SdtEspecialidade_Especialidadeupdatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Especialidadeupdatedat_Z");
         return  ;
      }

      public bool gxTv_SdtEspecialidade_Especialidadeupdatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspecialidadeCreatedAt_Z" )]
      [  XmlElement( ElementName = "EspecialidadeCreatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Especialidadecreatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtEspecialidade_Especialidadecreatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtEspecialidade_Especialidadecreatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtEspecialidade_Especialidadecreatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtEspecialidade_Especialidadecreatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Especialidadecreatedat_Z
      {
         get {
            return gxTv_SdtEspecialidade_Especialidadecreatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEspecialidade_Especialidadecreatedat_Z = value;
            SetDirty("Especialidadecreatedat_Z");
         }

      }

      public void gxTv_SdtEspecialidade_Especialidadecreatedat_Z_SetNull( )
      {
         gxTv_SdtEspecialidade_Especialidadecreatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Especialidadecreatedat_Z");
         return  ;
      }

      public bool gxTv_SdtEspecialidade_Especialidadecreatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspecialidadeCreatedBy_Z" )]
      [  XmlElement( ElementName = "EspecialidadeCreatedBy_Z"   )]
      public short gxTpr_Especialidadecreatedby_Z
      {
         get {
            return gxTv_SdtEspecialidade_Especialidadecreatedby_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEspecialidade_Especialidadecreatedby_Z = value;
            SetDirty("Especialidadecreatedby_Z");
         }

      }

      public void gxTv_SdtEspecialidade_Especialidadecreatedby_Z_SetNull( )
      {
         gxTv_SdtEspecialidade_Especialidadecreatedby_Z = 0;
         SetDirty("Especialidadecreatedby_Z");
         return  ;
      }

      public bool gxTv_SdtEspecialidade_Especialidadecreatedby_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspecialidadeId_N" )]
      [  XmlElement( ElementName = "EspecialidadeId_N"   )]
      public short gxTpr_Especialidadeid_N
      {
         get {
            return gxTv_SdtEspecialidade_Especialidadeid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEspecialidade_Especialidadeid_N = value;
            SetDirty("Especialidadeid_N");
         }

      }

      public void gxTv_SdtEspecialidade_Especialidadeid_N_SetNull( )
      {
         gxTv_SdtEspecialidade_Especialidadeid_N = 0;
         SetDirty("Especialidadeid_N");
         return  ;
      }

      public bool gxTv_SdtEspecialidade_Especialidadeid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspecialidadeNome_N" )]
      [  XmlElement( ElementName = "EspecialidadeNome_N"   )]
      public short gxTpr_Especialidadenome_N
      {
         get {
            return gxTv_SdtEspecialidade_Especialidadenome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEspecialidade_Especialidadenome_N = value;
            SetDirty("Especialidadenome_N");
         }

      }

      public void gxTv_SdtEspecialidade_Especialidadenome_N_SetNull( )
      {
         gxTv_SdtEspecialidade_Especialidadenome_N = 0;
         SetDirty("Especialidadenome_N");
         return  ;
      }

      public bool gxTv_SdtEspecialidade_Especialidadenome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspecialidadeStatus_N" )]
      [  XmlElement( ElementName = "EspecialidadeStatus_N"   )]
      public short gxTpr_Especialidadestatus_N
      {
         get {
            return gxTv_SdtEspecialidade_Especialidadestatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEspecialidade_Especialidadestatus_N = value;
            SetDirty("Especialidadestatus_N");
         }

      }

      public void gxTv_SdtEspecialidade_Especialidadestatus_N_SetNull( )
      {
         gxTv_SdtEspecialidade_Especialidadestatus_N = 0;
         SetDirty("Especialidadestatus_N");
         return  ;
      }

      public bool gxTv_SdtEspecialidade_Especialidadestatus_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspecialidadeUpdatedAt_N" )]
      [  XmlElement( ElementName = "EspecialidadeUpdatedAt_N"   )]
      public short gxTpr_Especialidadeupdatedat_N
      {
         get {
            return gxTv_SdtEspecialidade_Especialidadeupdatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEspecialidade_Especialidadeupdatedat_N = value;
            SetDirty("Especialidadeupdatedat_N");
         }

      }

      public void gxTv_SdtEspecialidade_Especialidadeupdatedat_N_SetNull( )
      {
         gxTv_SdtEspecialidade_Especialidadeupdatedat_N = 0;
         SetDirty("Especialidadeupdatedat_N");
         return  ;
      }

      public bool gxTv_SdtEspecialidade_Especialidadeupdatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspecialidadeCreatedAt_N" )]
      [  XmlElement( ElementName = "EspecialidadeCreatedAt_N"   )]
      public short gxTpr_Especialidadecreatedat_N
      {
         get {
            return gxTv_SdtEspecialidade_Especialidadecreatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEspecialidade_Especialidadecreatedat_N = value;
            SetDirty("Especialidadecreatedat_N");
         }

      }

      public void gxTv_SdtEspecialidade_Especialidadecreatedat_N_SetNull( )
      {
         gxTv_SdtEspecialidade_Especialidadecreatedat_N = 0;
         SetDirty("Especialidadecreatedat_N");
         return  ;
      }

      public bool gxTv_SdtEspecialidade_Especialidadecreatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EspecialidadeCreatedBy_N" )]
      [  XmlElement( ElementName = "EspecialidadeCreatedBy_N"   )]
      public short gxTpr_Especialidadecreatedby_N
      {
         get {
            return gxTv_SdtEspecialidade_Especialidadecreatedby_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEspecialidade_Especialidadecreatedby_N = value;
            SetDirty("Especialidadecreatedby_N");
         }

      }

      public void gxTv_SdtEspecialidade_Especialidadecreatedby_N_SetNull( )
      {
         gxTv_SdtEspecialidade_Especialidadecreatedby_N = 0;
         SetDirty("Especialidadecreatedby_N");
         return  ;
      }

      public bool gxTv_SdtEspecialidade_Especialidadecreatedby_N_IsNull( )
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
         gxTv_SdtEspecialidade_Especialidadenome = "";
         gxTv_SdtEspecialidade_Especialidadeupdatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtEspecialidade_Especialidadecreatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtEspecialidade_Mode = "";
         gxTv_SdtEspecialidade_Especialidadenome_Z = "";
         gxTv_SdtEspecialidade_Especialidadeupdatedat_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtEspecialidade_Especialidadecreatedat_Z = (DateTime)(DateTime.MinValue);
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "especialidade", "GeneXus.Programs.especialidade_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtEspecialidade_Especialidadecreatedby ;
      private short gxTv_SdtEspecialidade_Initialized ;
      private short gxTv_SdtEspecialidade_Especialidadecreatedby_Z ;
      private short gxTv_SdtEspecialidade_Especialidadeid_N ;
      private short gxTv_SdtEspecialidade_Especialidadenome_N ;
      private short gxTv_SdtEspecialidade_Especialidadestatus_N ;
      private short gxTv_SdtEspecialidade_Especialidadeupdatedat_N ;
      private short gxTv_SdtEspecialidade_Especialidadecreatedat_N ;
      private short gxTv_SdtEspecialidade_Especialidadecreatedby_N ;
      private int gxTv_SdtEspecialidade_Especialidadeid ;
      private int gxTv_SdtEspecialidade_Especialidadeid_Z ;
      private string gxTv_SdtEspecialidade_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtEspecialidade_Especialidadeupdatedat ;
      private DateTime gxTv_SdtEspecialidade_Especialidadecreatedat ;
      private DateTime gxTv_SdtEspecialidade_Especialidadeupdatedat_Z ;
      private DateTime gxTv_SdtEspecialidade_Especialidadecreatedat_Z ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtEspecialidade_Especialidadestatus ;
      private bool gxTv_SdtEspecialidade_Especialidadestatus_Z ;
      private string gxTv_SdtEspecialidade_Especialidadenome ;
      private string gxTv_SdtEspecialidade_Especialidadenome_Z ;
   }

   [DataContract(Name = @"Especialidade", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtEspecialidade_RESTInterface : GxGenericCollectionItem<SdtEspecialidade>
   {
      public SdtEspecialidade_RESTInterface( ) : base()
      {
      }

      public SdtEspecialidade_RESTInterface( SdtEspecialidade psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EspecialidadeId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Especialidadeid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Especialidadeid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Especialidadeid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "EspecialidadeNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Especialidadenome
      {
         get {
            return sdt.gxTpr_Especialidadenome ;
         }

         set {
            sdt.gxTpr_Especialidadenome = value;
         }

      }

      [DataMember( Name = "EspecialidadeStatus" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Especialidadestatus
      {
         get {
            return sdt.gxTpr_Especialidadestatus ;
         }

         set {
            sdt.gxTpr_Especialidadestatus = value;
         }

      }

      [DataMember( Name = "EspecialidadeUpdatedAt" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Especialidadeupdatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Especialidadeupdatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Especialidadeupdatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "EspecialidadeCreatedAt" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Especialidadecreatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Especialidadecreatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Especialidadecreatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "EspecialidadeCreatedBy" , Order = 5 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Especialidadecreatedby
      {
         get {
            return sdt.gxTpr_Especialidadecreatedby ;
         }

         set {
            sdt.gxTpr_Especialidadecreatedby = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtEspecialidade sdt
      {
         get {
            return (SdtEspecialidade)Sdt ;
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
            sdt = new SdtEspecialidade() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 6 )]
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

   [DataContract(Name = @"Especialidade", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtEspecialidade_RESTLInterface : GxGenericCollectionItem<SdtEspecialidade>
   {
      public SdtEspecialidade_RESTLInterface( ) : base()
      {
      }

      public SdtEspecialidade_RESTLInterface( SdtEspecialidade psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EspecialidadeNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Especialidadenome
      {
         get {
            return sdt.gxTpr_Especialidadenome ;
         }

         set {
            sdt.gxTpr_Especialidadenome = value;
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

      public SdtEspecialidade sdt
      {
         get {
            return (SdtEspecialidade)Sdt ;
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
            sdt = new SdtEspecialidade() ;
         }
      }

   }

}
