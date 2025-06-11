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
   [XmlRoot(ElementName = "ReembolsoEtapa" )]
   [XmlType(TypeName =  "ReembolsoEtapa" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtReembolsoEtapa : GxSilentTrnSdt
   {
      public SdtReembolsoEtapa( )
      {
      }

      public SdtReembolsoEtapa( IGxContext context )
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

      public void Load( int AV526ReembolsoEtapaId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV526ReembolsoEtapaId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ReembolsoEtapaId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "ReembolsoEtapa");
         metadata.Set("BT", "ReembolsoEtapa");
         metadata.Set("PK", "[ \"ReembolsoEtapaId\" ]");
         metadata.Set("PKAssigned", "[ \"ReembolsoEtapaId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ReembolsoId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Reembolsoetapaid_Z");
         state.Add("gxTpr_Reembolsoid_Z");
         state.Add("gxTpr_Reembolsoetapacreatedat_Z_Nullable");
         state.Add("gxTpr_Reembolsoetapastatus_Z");
         state.Add("gxTpr_Reembolsoetapaid_N");
         state.Add("gxTpr_Reembolsoid_N");
         state.Add("gxTpr_Reembolsoetapacreatedat_N");
         state.Add("gxTpr_Reembolsoetapastatus_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtReembolsoEtapa sdt;
         sdt = (SdtReembolsoEtapa)(source);
         gxTv_SdtReembolsoEtapa_Reembolsoetapaid = sdt.gxTv_SdtReembolsoEtapa_Reembolsoetapaid ;
         gxTv_SdtReembolsoEtapa_Reembolsoid = sdt.gxTv_SdtReembolsoEtapa_Reembolsoid ;
         gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat = sdt.gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat ;
         gxTv_SdtReembolsoEtapa_Reembolsoetapastatus = sdt.gxTv_SdtReembolsoEtapa_Reembolsoetapastatus ;
         gxTv_SdtReembolsoEtapa_Mode = sdt.gxTv_SdtReembolsoEtapa_Mode ;
         gxTv_SdtReembolsoEtapa_Initialized = sdt.gxTv_SdtReembolsoEtapa_Initialized ;
         gxTv_SdtReembolsoEtapa_Reembolsoetapaid_Z = sdt.gxTv_SdtReembolsoEtapa_Reembolsoetapaid_Z ;
         gxTv_SdtReembolsoEtapa_Reembolsoid_Z = sdt.gxTv_SdtReembolsoEtapa_Reembolsoid_Z ;
         gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat_Z = sdt.gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat_Z ;
         gxTv_SdtReembolsoEtapa_Reembolsoetapastatus_Z = sdt.gxTv_SdtReembolsoEtapa_Reembolsoetapastatus_Z ;
         gxTv_SdtReembolsoEtapa_Reembolsoetapaid_N = sdt.gxTv_SdtReembolsoEtapa_Reembolsoetapaid_N ;
         gxTv_SdtReembolsoEtapa_Reembolsoid_N = sdt.gxTv_SdtReembolsoEtapa_Reembolsoid_N ;
         gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat_N = sdt.gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat_N ;
         gxTv_SdtReembolsoEtapa_Reembolsoetapastatus_N = sdt.gxTv_SdtReembolsoEtapa_Reembolsoetapastatus_N ;
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
         AddObjectProperty("ReembolsoEtapaId", gxTv_SdtReembolsoEtapa_Reembolsoetapaid, false, includeNonInitialized);
         AddObjectProperty("ReembolsoEtapaId_N", gxTv_SdtReembolsoEtapa_Reembolsoetapaid_N, false, includeNonInitialized);
         AddObjectProperty("ReembolsoId", gxTv_SdtReembolsoEtapa_Reembolsoid, false, includeNonInitialized);
         AddObjectProperty("ReembolsoId_N", gxTv_SdtReembolsoEtapa_Reembolsoid_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat;
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
         AddObjectProperty("ReembolsoEtapaCreatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ReembolsoEtapaCreatedAt_N", gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat_N, false, includeNonInitialized);
         AddObjectProperty("ReembolsoEtapaStatus", gxTv_SdtReembolsoEtapa_Reembolsoetapastatus, false, includeNonInitialized);
         AddObjectProperty("ReembolsoEtapaStatus_N", gxTv_SdtReembolsoEtapa_Reembolsoetapastatus_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtReembolsoEtapa_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtReembolsoEtapa_Initialized, false, includeNonInitialized);
            AddObjectProperty("ReembolsoEtapaId_Z", gxTv_SdtReembolsoEtapa_Reembolsoetapaid_Z, false, includeNonInitialized);
            AddObjectProperty("ReembolsoId_Z", gxTv_SdtReembolsoEtapa_Reembolsoid_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat_Z;
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
            AddObjectProperty("ReembolsoEtapaCreatedAt_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("ReembolsoEtapaStatus_Z", gxTv_SdtReembolsoEtapa_Reembolsoetapastatus_Z, false, includeNonInitialized);
            AddObjectProperty("ReembolsoEtapaId_N", gxTv_SdtReembolsoEtapa_Reembolsoetapaid_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoId_N", gxTv_SdtReembolsoEtapa_Reembolsoid_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoEtapaCreatedAt_N", gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoEtapaStatus_N", gxTv_SdtReembolsoEtapa_Reembolsoetapastatus_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtReembolsoEtapa sdt )
      {
         if ( sdt.IsDirty("ReembolsoEtapaId") )
         {
            sdtIsNull = 0;
            gxTv_SdtReembolsoEtapa_Reembolsoetapaid = sdt.gxTv_SdtReembolsoEtapa_Reembolsoetapaid ;
         }
         if ( sdt.IsDirty("ReembolsoId") )
         {
            gxTv_SdtReembolsoEtapa_Reembolsoid_N = (short)(sdt.gxTv_SdtReembolsoEtapa_Reembolsoid_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoEtapa_Reembolsoid = sdt.gxTv_SdtReembolsoEtapa_Reembolsoid ;
         }
         if ( sdt.IsDirty("ReembolsoEtapaCreatedAt") )
         {
            gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat_N = (short)(sdt.gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat = sdt.gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat ;
         }
         if ( sdt.IsDirty("ReembolsoEtapaStatus") )
         {
            gxTv_SdtReembolsoEtapa_Reembolsoetapastatus_N = (short)(sdt.gxTv_SdtReembolsoEtapa_Reembolsoetapastatus_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoEtapa_Reembolsoetapastatus = sdt.gxTv_SdtReembolsoEtapa_Reembolsoetapastatus ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ReembolsoEtapaId" )]
      [  XmlElement( ElementName = "ReembolsoEtapaId"   )]
      public int gxTpr_Reembolsoetapaid
      {
         get {
            return gxTv_SdtReembolsoEtapa_Reembolsoetapaid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtReembolsoEtapa_Reembolsoetapaid != value )
            {
               gxTv_SdtReembolsoEtapa_Mode = "INS";
               this.gxTv_SdtReembolsoEtapa_Reembolsoetapaid_Z_SetNull( );
               this.gxTv_SdtReembolsoEtapa_Reembolsoid_Z_SetNull( );
               this.gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat_Z_SetNull( );
               this.gxTv_SdtReembolsoEtapa_Reembolsoetapastatus_Z_SetNull( );
            }
            gxTv_SdtReembolsoEtapa_Reembolsoetapaid = value;
            SetDirty("Reembolsoetapaid");
         }

      }

      [  SoapElement( ElementName = "ReembolsoId" )]
      [  XmlElement( ElementName = "ReembolsoId"   )]
      public int gxTpr_Reembolsoid
      {
         get {
            return gxTv_SdtReembolsoEtapa_Reembolsoid ;
         }

         set {
            gxTv_SdtReembolsoEtapa_Reembolsoid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoEtapa_Reembolsoid = value;
            SetDirty("Reembolsoid");
         }

      }

      public void gxTv_SdtReembolsoEtapa_Reembolsoid_SetNull( )
      {
         gxTv_SdtReembolsoEtapa_Reembolsoid_N = 1;
         gxTv_SdtReembolsoEtapa_Reembolsoid = 0;
         SetDirty("Reembolsoid");
         return  ;
      }

      public bool gxTv_SdtReembolsoEtapa_Reembolsoid_IsNull( )
      {
         return (gxTv_SdtReembolsoEtapa_Reembolsoid_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoEtapaCreatedAt" )]
      [  XmlElement( ElementName = "ReembolsoEtapaCreatedAt"  , IsNullable=true )]
      public string gxTpr_Reembolsoetapacreatedat_Nullable
      {
         get {
            if ( gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat).value ;
         }

         set {
            gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat = DateTime.MinValue;
            else
               gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Reembolsoetapacreatedat
      {
         get {
            return gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat ;
         }

         set {
            gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat = value;
            SetDirty("Reembolsoetapacreatedat");
         }

      }

      public void gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat_SetNull( )
      {
         gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat_N = 1;
         gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Reembolsoetapacreatedat");
         return  ;
      }

      public bool gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat_IsNull( )
      {
         return (gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoEtapaStatus" )]
      [  XmlElement( ElementName = "ReembolsoEtapaStatus"   )]
      public string gxTpr_Reembolsoetapastatus
      {
         get {
            return gxTv_SdtReembolsoEtapa_Reembolsoetapastatus ;
         }

         set {
            gxTv_SdtReembolsoEtapa_Reembolsoetapastatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoEtapa_Reembolsoetapastatus = value;
            SetDirty("Reembolsoetapastatus");
         }

      }

      public void gxTv_SdtReembolsoEtapa_Reembolsoetapastatus_SetNull( )
      {
         gxTv_SdtReembolsoEtapa_Reembolsoetapastatus_N = 1;
         gxTv_SdtReembolsoEtapa_Reembolsoetapastatus = "";
         SetDirty("Reembolsoetapastatus");
         return  ;
      }

      public bool gxTv_SdtReembolsoEtapa_Reembolsoetapastatus_IsNull( )
      {
         return (gxTv_SdtReembolsoEtapa_Reembolsoetapastatus_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtReembolsoEtapa_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoEtapa_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtReembolsoEtapa_Mode_SetNull( )
      {
         gxTv_SdtReembolsoEtapa_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtReembolsoEtapa_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtReembolsoEtapa_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoEtapa_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtReembolsoEtapa_Initialized_SetNull( )
      {
         gxTv_SdtReembolsoEtapa_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtReembolsoEtapa_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoEtapaId_Z" )]
      [  XmlElement( ElementName = "ReembolsoEtapaId_Z"   )]
      public int gxTpr_Reembolsoetapaid_Z
      {
         get {
            return gxTv_SdtReembolsoEtapa_Reembolsoetapaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoEtapa_Reembolsoetapaid_Z = value;
            SetDirty("Reembolsoetapaid_Z");
         }

      }

      public void gxTv_SdtReembolsoEtapa_Reembolsoetapaid_Z_SetNull( )
      {
         gxTv_SdtReembolsoEtapa_Reembolsoetapaid_Z = 0;
         SetDirty("Reembolsoetapaid_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoEtapa_Reembolsoetapaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoId_Z" )]
      [  XmlElement( ElementName = "ReembolsoId_Z"   )]
      public int gxTpr_Reembolsoid_Z
      {
         get {
            return gxTv_SdtReembolsoEtapa_Reembolsoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoEtapa_Reembolsoid_Z = value;
            SetDirty("Reembolsoid_Z");
         }

      }

      public void gxTv_SdtReembolsoEtapa_Reembolsoid_Z_SetNull( )
      {
         gxTv_SdtReembolsoEtapa_Reembolsoid_Z = 0;
         SetDirty("Reembolsoid_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoEtapa_Reembolsoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoEtapaCreatedAt_Z" )]
      [  XmlElement( ElementName = "ReembolsoEtapaCreatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Reembolsoetapacreatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Reembolsoetapacreatedat_Z
      {
         get {
            return gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat_Z = value;
            SetDirty("Reembolsoetapacreatedat_Z");
         }

      }

      public void gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat_Z_SetNull( )
      {
         gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Reembolsoetapacreatedat_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoEtapaStatus_Z" )]
      [  XmlElement( ElementName = "ReembolsoEtapaStatus_Z"   )]
      public string gxTpr_Reembolsoetapastatus_Z
      {
         get {
            return gxTv_SdtReembolsoEtapa_Reembolsoetapastatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoEtapa_Reembolsoetapastatus_Z = value;
            SetDirty("Reembolsoetapastatus_Z");
         }

      }

      public void gxTv_SdtReembolsoEtapa_Reembolsoetapastatus_Z_SetNull( )
      {
         gxTv_SdtReembolsoEtapa_Reembolsoetapastatus_Z = "";
         SetDirty("Reembolsoetapastatus_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoEtapa_Reembolsoetapastatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoEtapaId_N" )]
      [  XmlElement( ElementName = "ReembolsoEtapaId_N"   )]
      public short gxTpr_Reembolsoetapaid_N
      {
         get {
            return gxTv_SdtReembolsoEtapa_Reembolsoetapaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoEtapa_Reembolsoetapaid_N = value;
            SetDirty("Reembolsoetapaid_N");
         }

      }

      public void gxTv_SdtReembolsoEtapa_Reembolsoetapaid_N_SetNull( )
      {
         gxTv_SdtReembolsoEtapa_Reembolsoetapaid_N = 0;
         SetDirty("Reembolsoetapaid_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoEtapa_Reembolsoetapaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoId_N" )]
      [  XmlElement( ElementName = "ReembolsoId_N"   )]
      public short gxTpr_Reembolsoid_N
      {
         get {
            return gxTv_SdtReembolsoEtapa_Reembolsoid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoEtapa_Reembolsoid_N = value;
            SetDirty("Reembolsoid_N");
         }

      }

      public void gxTv_SdtReembolsoEtapa_Reembolsoid_N_SetNull( )
      {
         gxTv_SdtReembolsoEtapa_Reembolsoid_N = 0;
         SetDirty("Reembolsoid_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoEtapa_Reembolsoid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoEtapaCreatedAt_N" )]
      [  XmlElement( ElementName = "ReembolsoEtapaCreatedAt_N"   )]
      public short gxTpr_Reembolsoetapacreatedat_N
      {
         get {
            return gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat_N = value;
            SetDirty("Reembolsoetapacreatedat_N");
         }

      }

      public void gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat_N_SetNull( )
      {
         gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat_N = 0;
         SetDirty("Reembolsoetapacreatedat_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoEtapaStatus_N" )]
      [  XmlElement( ElementName = "ReembolsoEtapaStatus_N"   )]
      public short gxTpr_Reembolsoetapastatus_N
      {
         get {
            return gxTv_SdtReembolsoEtapa_Reembolsoetapastatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoEtapa_Reembolsoetapastatus_N = value;
            SetDirty("Reembolsoetapastatus_N");
         }

      }

      public void gxTv_SdtReembolsoEtapa_Reembolsoetapastatus_N_SetNull( )
      {
         gxTv_SdtReembolsoEtapa_Reembolsoetapastatus_N = 0;
         SetDirty("Reembolsoetapastatus_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoEtapa_Reembolsoetapastatus_N_IsNull( )
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
         gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtReembolsoEtapa_Reembolsoetapastatus = "";
         gxTv_SdtReembolsoEtapa_Mode = "";
         gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtReembolsoEtapa_Reembolsoetapastatus_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "reembolsoetapa", "GeneXus.Programs.reembolsoetapa_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtReembolsoEtapa_Initialized ;
      private short gxTv_SdtReembolsoEtapa_Reembolsoetapaid_N ;
      private short gxTv_SdtReembolsoEtapa_Reembolsoid_N ;
      private short gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat_N ;
      private short gxTv_SdtReembolsoEtapa_Reembolsoetapastatus_N ;
      private int gxTv_SdtReembolsoEtapa_Reembolsoetapaid ;
      private int gxTv_SdtReembolsoEtapa_Reembolsoid ;
      private int gxTv_SdtReembolsoEtapa_Reembolsoetapaid_Z ;
      private int gxTv_SdtReembolsoEtapa_Reembolsoid_Z ;
      private string gxTv_SdtReembolsoEtapa_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat ;
      private DateTime gxTv_SdtReembolsoEtapa_Reembolsoetapacreatedat_Z ;
      private DateTime datetime_STZ ;
      private string gxTv_SdtReembolsoEtapa_Reembolsoetapastatus ;
      private string gxTv_SdtReembolsoEtapa_Reembolsoetapastatus_Z ;
   }

   [DataContract(Name = @"ReembolsoEtapa", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtReembolsoEtapa_RESTInterface : GxGenericCollectionItem<SdtReembolsoEtapa>
   {
      public SdtReembolsoEtapa_RESTInterface( ) : base()
      {
      }

      public SdtReembolsoEtapa_RESTInterface( SdtReembolsoEtapa psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ReembolsoEtapaId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Reembolsoetapaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Reembolsoetapaid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Reembolsoetapaid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ReembolsoId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Reembolsoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Reembolsoid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Reembolsoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ReembolsoEtapaCreatedAt" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Reembolsoetapacreatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Reembolsoetapacreatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Reembolsoetapacreatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "ReembolsoEtapaStatus" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Reembolsoetapastatus
      {
         get {
            return sdt.gxTpr_Reembolsoetapastatus ;
         }

         set {
            sdt.gxTpr_Reembolsoetapastatus = value;
         }

      }

      public SdtReembolsoEtapa sdt
      {
         get {
            return (SdtReembolsoEtapa)Sdt ;
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
            sdt = new SdtReembolsoEtapa() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 4 )]
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

   [DataContract(Name = @"ReembolsoEtapa", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtReembolsoEtapa_RESTLInterface : GxGenericCollectionItem<SdtReembolsoEtapa>
   {
      public SdtReembolsoEtapa_RESTLInterface( ) : base()
      {
      }

      public SdtReembolsoEtapa_RESTLInterface( SdtReembolsoEtapa psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ReembolsoEtapaCreatedAt" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Reembolsoetapacreatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Reembolsoetapacreatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Reembolsoetapacreatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
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

      public SdtReembolsoEtapa sdt
      {
         get {
            return (SdtReembolsoEtapa)Sdt ;
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
            sdt = new SdtReembolsoEtapa() ;
         }
      }

   }

}
