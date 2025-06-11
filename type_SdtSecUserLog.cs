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
   [XmlRoot(ElementName = "SecUserLog" )]
   [XmlType(TypeName =  "SecUserLog" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtSecUserLog : GxSilentTrnSdt
   {
      public SdtSecUserLog( )
      {
      }

      public SdtSecUserLog( IGxContext context )
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

      public void Load( int AV559SecUserLogId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV559SecUserLogId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"SecUserLogId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "SecUserLog");
         metadata.Set("BT", "SecUserLog");
         metadata.Set("PK", "[ \"SecUserLogId\" ]");
         metadata.Set("PKAssigned", "[ \"SecUserLogId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"SecUserId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Secuserlogid_Z");
         state.Add("gxTpr_Secuserid_Z");
         state.Add("gxTpr_Secusername_Z");
         state.Add("gxTpr_Secuserfullname_Z");
         state.Add("gxTpr_Secuserlogdatetime_Z_Nullable");
         state.Add("gxTpr_Secuserid_N");
         state.Add("gxTpr_Secusername_N");
         state.Add("gxTpr_Secuserfullname_N");
         state.Add("gxTpr_Secuserlogdatetime_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtSecUserLog sdt;
         sdt = (SdtSecUserLog)(source);
         gxTv_SdtSecUserLog_Secuserlogid = sdt.gxTv_SdtSecUserLog_Secuserlogid ;
         gxTv_SdtSecUserLog_Secuserid = sdt.gxTv_SdtSecUserLog_Secuserid ;
         gxTv_SdtSecUserLog_Secusername = sdt.gxTv_SdtSecUserLog_Secusername ;
         gxTv_SdtSecUserLog_Secuserfullname = sdt.gxTv_SdtSecUserLog_Secuserfullname ;
         gxTv_SdtSecUserLog_Secuserlogdatetime = sdt.gxTv_SdtSecUserLog_Secuserlogdatetime ;
         gxTv_SdtSecUserLog_Mode = sdt.gxTv_SdtSecUserLog_Mode ;
         gxTv_SdtSecUserLog_Initialized = sdt.gxTv_SdtSecUserLog_Initialized ;
         gxTv_SdtSecUserLog_Secuserlogid_Z = sdt.gxTv_SdtSecUserLog_Secuserlogid_Z ;
         gxTv_SdtSecUserLog_Secuserid_Z = sdt.gxTv_SdtSecUserLog_Secuserid_Z ;
         gxTv_SdtSecUserLog_Secusername_Z = sdt.gxTv_SdtSecUserLog_Secusername_Z ;
         gxTv_SdtSecUserLog_Secuserfullname_Z = sdt.gxTv_SdtSecUserLog_Secuserfullname_Z ;
         gxTv_SdtSecUserLog_Secuserlogdatetime_Z = sdt.gxTv_SdtSecUserLog_Secuserlogdatetime_Z ;
         gxTv_SdtSecUserLog_Secuserid_N = sdt.gxTv_SdtSecUserLog_Secuserid_N ;
         gxTv_SdtSecUserLog_Secusername_N = sdt.gxTv_SdtSecUserLog_Secusername_N ;
         gxTv_SdtSecUserLog_Secuserfullname_N = sdt.gxTv_SdtSecUserLog_Secuserfullname_N ;
         gxTv_SdtSecUserLog_Secuserlogdatetime_N = sdt.gxTv_SdtSecUserLog_Secuserlogdatetime_N ;
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
         AddObjectProperty("SecUserLogId", gxTv_SdtSecUserLog_Secuserlogid, false, includeNonInitialized);
         AddObjectProperty("SecUserId", gxTv_SdtSecUserLog_Secuserid, false, includeNonInitialized);
         AddObjectProperty("SecUserId_N", gxTv_SdtSecUserLog_Secuserid_N, false, includeNonInitialized);
         AddObjectProperty("SecUserName", gxTv_SdtSecUserLog_Secusername, false, includeNonInitialized);
         AddObjectProperty("SecUserName_N", gxTv_SdtSecUserLog_Secusername_N, false, includeNonInitialized);
         AddObjectProperty("SecUserFullName", gxTv_SdtSecUserLog_Secuserfullname, false, includeNonInitialized);
         AddObjectProperty("SecUserFullName_N", gxTv_SdtSecUserLog_Secuserfullname_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtSecUserLog_Secuserlogdatetime;
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
         AddObjectProperty("SecUserLogDateTime", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("SecUserLogDateTime_N", gxTv_SdtSecUserLog_Secuserlogdatetime_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtSecUserLog_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtSecUserLog_Initialized, false, includeNonInitialized);
            AddObjectProperty("SecUserLogId_Z", gxTv_SdtSecUserLog_Secuserlogid_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserId_Z", gxTv_SdtSecUserLog_Secuserid_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserName_Z", gxTv_SdtSecUserLog_Secusername_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserFullName_Z", gxTv_SdtSecUserLog_Secuserfullname_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtSecUserLog_Secuserlogdatetime_Z;
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
            AddObjectProperty("SecUserLogDateTime_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("SecUserId_N", gxTv_SdtSecUserLog_Secuserid_N, false, includeNonInitialized);
            AddObjectProperty("SecUserName_N", gxTv_SdtSecUserLog_Secusername_N, false, includeNonInitialized);
            AddObjectProperty("SecUserFullName_N", gxTv_SdtSecUserLog_Secuserfullname_N, false, includeNonInitialized);
            AddObjectProperty("SecUserLogDateTime_N", gxTv_SdtSecUserLog_Secuserlogdatetime_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtSecUserLog sdt )
      {
         if ( sdt.IsDirty("SecUserLogId") )
         {
            sdtIsNull = 0;
            gxTv_SdtSecUserLog_Secuserlogid = sdt.gxTv_SdtSecUserLog_Secuserlogid ;
         }
         if ( sdt.IsDirty("SecUserId") )
         {
            gxTv_SdtSecUserLog_Secuserid_N = (short)(sdt.gxTv_SdtSecUserLog_Secuserid_N);
            sdtIsNull = 0;
            gxTv_SdtSecUserLog_Secuserid = sdt.gxTv_SdtSecUserLog_Secuserid ;
         }
         if ( sdt.IsDirty("SecUserName") )
         {
            gxTv_SdtSecUserLog_Secusername_N = (short)(sdt.gxTv_SdtSecUserLog_Secusername_N);
            sdtIsNull = 0;
            gxTv_SdtSecUserLog_Secusername = sdt.gxTv_SdtSecUserLog_Secusername ;
         }
         if ( sdt.IsDirty("SecUserFullName") )
         {
            gxTv_SdtSecUserLog_Secuserfullname_N = (short)(sdt.gxTv_SdtSecUserLog_Secuserfullname_N);
            sdtIsNull = 0;
            gxTv_SdtSecUserLog_Secuserfullname = sdt.gxTv_SdtSecUserLog_Secuserfullname ;
         }
         if ( sdt.IsDirty("SecUserLogDateTime") )
         {
            gxTv_SdtSecUserLog_Secuserlogdatetime_N = (short)(sdt.gxTv_SdtSecUserLog_Secuserlogdatetime_N);
            sdtIsNull = 0;
            gxTv_SdtSecUserLog_Secuserlogdatetime = sdt.gxTv_SdtSecUserLog_Secuserlogdatetime ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "SecUserLogId" )]
      [  XmlElement( ElementName = "SecUserLogId"   )]
      public int gxTpr_Secuserlogid
      {
         get {
            return gxTv_SdtSecUserLog_Secuserlogid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtSecUserLog_Secuserlogid != value )
            {
               gxTv_SdtSecUserLog_Mode = "INS";
               this.gxTv_SdtSecUserLog_Secuserlogid_Z_SetNull( );
               this.gxTv_SdtSecUserLog_Secuserid_Z_SetNull( );
               this.gxTv_SdtSecUserLog_Secusername_Z_SetNull( );
               this.gxTv_SdtSecUserLog_Secuserfullname_Z_SetNull( );
               this.gxTv_SdtSecUserLog_Secuserlogdatetime_Z_SetNull( );
            }
            gxTv_SdtSecUserLog_Secuserlogid = value;
            SetDirty("Secuserlogid");
         }

      }

      [  SoapElement( ElementName = "SecUserId" )]
      [  XmlElement( ElementName = "SecUserId"   )]
      public short gxTpr_Secuserid
      {
         get {
            return gxTv_SdtSecUserLog_Secuserid ;
         }

         set {
            gxTv_SdtSecUserLog_Secuserid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecUserLog_Secuserid = value;
            SetDirty("Secuserid");
         }

      }

      public void gxTv_SdtSecUserLog_Secuserid_SetNull( )
      {
         gxTv_SdtSecUserLog_Secuserid_N = 1;
         gxTv_SdtSecUserLog_Secuserid = 0;
         SetDirty("Secuserid");
         return  ;
      }

      public bool gxTv_SdtSecUserLog_Secuserid_IsNull( )
      {
         return (gxTv_SdtSecUserLog_Secuserid_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserName" )]
      [  XmlElement( ElementName = "SecUserName"   )]
      public string gxTpr_Secusername
      {
         get {
            return gxTv_SdtSecUserLog_Secusername ;
         }

         set {
            gxTv_SdtSecUserLog_Secusername_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecUserLog_Secusername = value;
            SetDirty("Secusername");
         }

      }

      public void gxTv_SdtSecUserLog_Secusername_SetNull( )
      {
         gxTv_SdtSecUserLog_Secusername_N = 1;
         gxTv_SdtSecUserLog_Secusername = "";
         SetDirty("Secusername");
         return  ;
      }

      public bool gxTv_SdtSecUserLog_Secusername_IsNull( )
      {
         return (gxTv_SdtSecUserLog_Secusername_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserFullName" )]
      [  XmlElement( ElementName = "SecUserFullName"   )]
      public string gxTpr_Secuserfullname
      {
         get {
            return gxTv_SdtSecUserLog_Secuserfullname ;
         }

         set {
            gxTv_SdtSecUserLog_Secuserfullname_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecUserLog_Secuserfullname = value;
            SetDirty("Secuserfullname");
         }

      }

      public void gxTv_SdtSecUserLog_Secuserfullname_SetNull( )
      {
         gxTv_SdtSecUserLog_Secuserfullname_N = 1;
         gxTv_SdtSecUserLog_Secuserfullname = "";
         SetDirty("Secuserfullname");
         return  ;
      }

      public bool gxTv_SdtSecUserLog_Secuserfullname_IsNull( )
      {
         return (gxTv_SdtSecUserLog_Secuserfullname_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserLogDateTime" )]
      [  XmlElement( ElementName = "SecUserLogDateTime"  , IsNullable=true )]
      public string gxTpr_Secuserlogdatetime_Nullable
      {
         get {
            if ( gxTv_SdtSecUserLog_Secuserlogdatetime == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtSecUserLog_Secuserlogdatetime).value ;
         }

         set {
            gxTv_SdtSecUserLog_Secuserlogdatetime_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtSecUserLog_Secuserlogdatetime = DateTime.MinValue;
            else
               gxTv_SdtSecUserLog_Secuserlogdatetime = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Secuserlogdatetime
      {
         get {
            return gxTv_SdtSecUserLog_Secuserlogdatetime ;
         }

         set {
            gxTv_SdtSecUserLog_Secuserlogdatetime_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecUserLog_Secuserlogdatetime = value;
            SetDirty("Secuserlogdatetime");
         }

      }

      public void gxTv_SdtSecUserLog_Secuserlogdatetime_SetNull( )
      {
         gxTv_SdtSecUserLog_Secuserlogdatetime_N = 1;
         gxTv_SdtSecUserLog_Secuserlogdatetime = (DateTime)(DateTime.MinValue);
         SetDirty("Secuserlogdatetime");
         return  ;
      }

      public bool gxTv_SdtSecUserLog_Secuserlogdatetime_IsNull( )
      {
         return (gxTv_SdtSecUserLog_Secuserlogdatetime_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtSecUserLog_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUserLog_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtSecUserLog_Mode_SetNull( )
      {
         gxTv_SdtSecUserLog_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtSecUserLog_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtSecUserLog_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUserLog_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtSecUserLog_Initialized_SetNull( )
      {
         gxTv_SdtSecUserLog_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtSecUserLog_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserLogId_Z" )]
      [  XmlElement( ElementName = "SecUserLogId_Z"   )]
      public int gxTpr_Secuserlogid_Z
      {
         get {
            return gxTv_SdtSecUserLog_Secuserlogid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUserLog_Secuserlogid_Z = value;
            SetDirty("Secuserlogid_Z");
         }

      }

      public void gxTv_SdtSecUserLog_Secuserlogid_Z_SetNull( )
      {
         gxTv_SdtSecUserLog_Secuserlogid_Z = 0;
         SetDirty("Secuserlogid_Z");
         return  ;
      }

      public bool gxTv_SdtSecUserLog_Secuserlogid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserId_Z" )]
      [  XmlElement( ElementName = "SecUserId_Z"   )]
      public short gxTpr_Secuserid_Z
      {
         get {
            return gxTv_SdtSecUserLog_Secuserid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUserLog_Secuserid_Z = value;
            SetDirty("Secuserid_Z");
         }

      }

      public void gxTv_SdtSecUserLog_Secuserid_Z_SetNull( )
      {
         gxTv_SdtSecUserLog_Secuserid_Z = 0;
         SetDirty("Secuserid_Z");
         return  ;
      }

      public bool gxTv_SdtSecUserLog_Secuserid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserName_Z" )]
      [  XmlElement( ElementName = "SecUserName_Z"   )]
      public string gxTpr_Secusername_Z
      {
         get {
            return gxTv_SdtSecUserLog_Secusername_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUserLog_Secusername_Z = value;
            SetDirty("Secusername_Z");
         }

      }

      public void gxTv_SdtSecUserLog_Secusername_Z_SetNull( )
      {
         gxTv_SdtSecUserLog_Secusername_Z = "";
         SetDirty("Secusername_Z");
         return  ;
      }

      public bool gxTv_SdtSecUserLog_Secusername_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserFullName_Z" )]
      [  XmlElement( ElementName = "SecUserFullName_Z"   )]
      public string gxTpr_Secuserfullname_Z
      {
         get {
            return gxTv_SdtSecUserLog_Secuserfullname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUserLog_Secuserfullname_Z = value;
            SetDirty("Secuserfullname_Z");
         }

      }

      public void gxTv_SdtSecUserLog_Secuserfullname_Z_SetNull( )
      {
         gxTv_SdtSecUserLog_Secuserfullname_Z = "";
         SetDirty("Secuserfullname_Z");
         return  ;
      }

      public bool gxTv_SdtSecUserLog_Secuserfullname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserLogDateTime_Z" )]
      [  XmlElement( ElementName = "SecUserLogDateTime_Z"  , IsNullable=true )]
      public string gxTpr_Secuserlogdatetime_Z_Nullable
      {
         get {
            if ( gxTv_SdtSecUserLog_Secuserlogdatetime_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtSecUserLog_Secuserlogdatetime_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtSecUserLog_Secuserlogdatetime_Z = DateTime.MinValue;
            else
               gxTv_SdtSecUserLog_Secuserlogdatetime_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Secuserlogdatetime_Z
      {
         get {
            return gxTv_SdtSecUserLog_Secuserlogdatetime_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUserLog_Secuserlogdatetime_Z = value;
            SetDirty("Secuserlogdatetime_Z");
         }

      }

      public void gxTv_SdtSecUserLog_Secuserlogdatetime_Z_SetNull( )
      {
         gxTv_SdtSecUserLog_Secuserlogdatetime_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Secuserlogdatetime_Z");
         return  ;
      }

      public bool gxTv_SdtSecUserLog_Secuserlogdatetime_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserId_N" )]
      [  XmlElement( ElementName = "SecUserId_N"   )]
      public short gxTpr_Secuserid_N
      {
         get {
            return gxTv_SdtSecUserLog_Secuserid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUserLog_Secuserid_N = value;
            SetDirty("Secuserid_N");
         }

      }

      public void gxTv_SdtSecUserLog_Secuserid_N_SetNull( )
      {
         gxTv_SdtSecUserLog_Secuserid_N = 0;
         SetDirty("Secuserid_N");
         return  ;
      }

      public bool gxTv_SdtSecUserLog_Secuserid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserName_N" )]
      [  XmlElement( ElementName = "SecUserName_N"   )]
      public short gxTpr_Secusername_N
      {
         get {
            return gxTv_SdtSecUserLog_Secusername_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUserLog_Secusername_N = value;
            SetDirty("Secusername_N");
         }

      }

      public void gxTv_SdtSecUserLog_Secusername_N_SetNull( )
      {
         gxTv_SdtSecUserLog_Secusername_N = 0;
         SetDirty("Secusername_N");
         return  ;
      }

      public bool gxTv_SdtSecUserLog_Secusername_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserFullName_N" )]
      [  XmlElement( ElementName = "SecUserFullName_N"   )]
      public short gxTpr_Secuserfullname_N
      {
         get {
            return gxTv_SdtSecUserLog_Secuserfullname_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUserLog_Secuserfullname_N = value;
            SetDirty("Secuserfullname_N");
         }

      }

      public void gxTv_SdtSecUserLog_Secuserfullname_N_SetNull( )
      {
         gxTv_SdtSecUserLog_Secuserfullname_N = 0;
         SetDirty("Secuserfullname_N");
         return  ;
      }

      public bool gxTv_SdtSecUserLog_Secuserfullname_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserLogDateTime_N" )]
      [  XmlElement( ElementName = "SecUserLogDateTime_N"   )]
      public short gxTpr_Secuserlogdatetime_N
      {
         get {
            return gxTv_SdtSecUserLog_Secuserlogdatetime_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUserLog_Secuserlogdatetime_N = value;
            SetDirty("Secuserlogdatetime_N");
         }

      }

      public void gxTv_SdtSecUserLog_Secuserlogdatetime_N_SetNull( )
      {
         gxTv_SdtSecUserLog_Secuserlogdatetime_N = 0;
         SetDirty("Secuserlogdatetime_N");
         return  ;
      }

      public bool gxTv_SdtSecUserLog_Secuserlogdatetime_N_IsNull( )
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
         gxTv_SdtSecUserLog_Secusername = "";
         gxTv_SdtSecUserLog_Secuserfullname = "";
         gxTv_SdtSecUserLog_Secuserlogdatetime = (DateTime)(DateTime.MinValue);
         gxTv_SdtSecUserLog_Mode = "";
         gxTv_SdtSecUserLog_Secusername_Z = "";
         gxTv_SdtSecUserLog_Secuserfullname_Z = "";
         gxTv_SdtSecUserLog_Secuserlogdatetime_Z = (DateTime)(DateTime.MinValue);
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "secuserlog", "GeneXus.Programs.secuserlog_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtSecUserLog_Secuserid ;
      private short gxTv_SdtSecUserLog_Initialized ;
      private short gxTv_SdtSecUserLog_Secuserid_Z ;
      private short gxTv_SdtSecUserLog_Secuserid_N ;
      private short gxTv_SdtSecUserLog_Secusername_N ;
      private short gxTv_SdtSecUserLog_Secuserfullname_N ;
      private short gxTv_SdtSecUserLog_Secuserlogdatetime_N ;
      private int gxTv_SdtSecUserLog_Secuserlogid ;
      private int gxTv_SdtSecUserLog_Secuserlogid_Z ;
      private string gxTv_SdtSecUserLog_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtSecUserLog_Secuserlogdatetime ;
      private DateTime gxTv_SdtSecUserLog_Secuserlogdatetime_Z ;
      private DateTime datetime_STZ ;
      private string gxTv_SdtSecUserLog_Secusername ;
      private string gxTv_SdtSecUserLog_Secuserfullname ;
      private string gxTv_SdtSecUserLog_Secusername_Z ;
      private string gxTv_SdtSecUserLog_Secuserfullname_Z ;
   }

   [DataContract(Name = @"SecUserLog", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtSecUserLog_RESTInterface : GxGenericCollectionItem<SdtSecUserLog>
   {
      public SdtSecUserLog_RESTInterface( ) : base()
      {
      }

      public SdtSecUserLog_RESTInterface( SdtSecUserLog psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SecUserLogId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Secuserlogid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Secuserlogid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Secuserlogid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "SecUserId" , Order = 1 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Secuserid
      {
         get {
            return sdt.gxTpr_Secuserid ;
         }

         set {
            sdt.gxTpr_Secuserid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "SecUserName" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Secusername
      {
         get {
            return sdt.gxTpr_Secusername ;
         }

         set {
            sdt.gxTpr_Secusername = value;
         }

      }

      [DataMember( Name = "SecUserFullName" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Secuserfullname
      {
         get {
            return sdt.gxTpr_Secuserfullname ;
         }

         set {
            sdt.gxTpr_Secuserfullname = value;
         }

      }

      [DataMember( Name = "SecUserLogDateTime" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Secuserlogdatetime
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Secuserlogdatetime, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Secuserlogdatetime = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      public SdtSecUserLog sdt
      {
         get {
            return (SdtSecUserLog)Sdt ;
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
            sdt = new SdtSecUserLog() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 5 )]
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

   [DataContract(Name = @"SecUserLog", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtSecUserLog_RESTLInterface : GxGenericCollectionItem<SdtSecUserLog>
   {
      public SdtSecUserLog_RESTLInterface( ) : base()
      {
      }

      public SdtSecUserLog_RESTLInterface( SdtSecUserLog psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SecUserLogDateTime" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Secuserlogdatetime
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Secuserlogdatetime, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Secuserlogdatetime = DateTimeUtil.CToT2( value, (IGxContext)(context));
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

      public SdtSecUserLog sdt
      {
         get {
            return (SdtSecUserLog)Sdt ;
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
            sdt = new SdtSecUserLog() ;
         }
      }

   }

}
