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
   [XmlRoot(ElementName = "SecUserToken" )]
   [XmlType(TypeName =  "SecUserToken" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtSecUserToken : GxSilentTrnSdt
   {
      public SdtSecUserToken( )
      {
      }

      public SdtSecUserToken( IGxContext context )
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

      public void Load( short AV164SecUserTokenID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV164SecUserTokenID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"SecUserTokenID", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "SecUserToken");
         metadata.Set("BT", "SecUserToken");
         metadata.Set("PK", "[ \"SecUserTokenID\" ]");
         metadata.Set("PKAssigned", "[ \"SecUserTokenID\" ]");
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
         state.Add("gxTpr_Secusertokenid_Z");
         state.Add("gxTpr_Secusertokendatetime_Z_Nullable");
         state.Add("gxTpr_Secuserid_Z");
         state.Add("gxTpr_Secusertokenused_Z");
         state.Add("gxTpr_Secusertokenkey_N");
         state.Add("gxTpr_Secusertokendatetime_N");
         state.Add("gxTpr_Secuserid_N");
         state.Add("gxTpr_Secusertokenused_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtSecUserToken sdt;
         sdt = (SdtSecUserToken)(source);
         gxTv_SdtSecUserToken_Secusertokenid = sdt.gxTv_SdtSecUserToken_Secusertokenid ;
         gxTv_SdtSecUserToken_Secusertokenkey = sdt.gxTv_SdtSecUserToken_Secusertokenkey ;
         gxTv_SdtSecUserToken_Secusertokendatetime = sdt.gxTv_SdtSecUserToken_Secusertokendatetime ;
         gxTv_SdtSecUserToken_Secuserid = sdt.gxTv_SdtSecUserToken_Secuserid ;
         gxTv_SdtSecUserToken_Secusertokenused = sdt.gxTv_SdtSecUserToken_Secusertokenused ;
         gxTv_SdtSecUserToken_Mode = sdt.gxTv_SdtSecUserToken_Mode ;
         gxTv_SdtSecUserToken_Initialized = sdt.gxTv_SdtSecUserToken_Initialized ;
         gxTv_SdtSecUserToken_Secusertokenid_Z = sdt.gxTv_SdtSecUserToken_Secusertokenid_Z ;
         gxTv_SdtSecUserToken_Secusertokendatetime_Z = sdt.gxTv_SdtSecUserToken_Secusertokendatetime_Z ;
         gxTv_SdtSecUserToken_Secuserid_Z = sdt.gxTv_SdtSecUserToken_Secuserid_Z ;
         gxTv_SdtSecUserToken_Secusertokenused_Z = sdt.gxTv_SdtSecUserToken_Secusertokenused_Z ;
         gxTv_SdtSecUserToken_Secusertokenkey_N = sdt.gxTv_SdtSecUserToken_Secusertokenkey_N ;
         gxTv_SdtSecUserToken_Secusertokendatetime_N = sdt.gxTv_SdtSecUserToken_Secusertokendatetime_N ;
         gxTv_SdtSecUserToken_Secuserid_N = sdt.gxTv_SdtSecUserToken_Secuserid_N ;
         gxTv_SdtSecUserToken_Secusertokenused_N = sdt.gxTv_SdtSecUserToken_Secusertokenused_N ;
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
         AddObjectProperty("SecUserTokenID", gxTv_SdtSecUserToken_Secusertokenid, false, includeNonInitialized);
         AddObjectProperty("SecUserTokenKey", gxTv_SdtSecUserToken_Secusertokenkey, false, includeNonInitialized);
         AddObjectProperty("SecUserTokenKey_N", gxTv_SdtSecUserToken_Secusertokenkey_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtSecUserToken_Secusertokendatetime;
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
         AddObjectProperty("SecUserTokenDateTime", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("SecUserTokenDateTime_N", gxTv_SdtSecUserToken_Secusertokendatetime_N, false, includeNonInitialized);
         AddObjectProperty("SecUserId", gxTv_SdtSecUserToken_Secuserid, false, includeNonInitialized);
         AddObjectProperty("SecUserId_N", gxTv_SdtSecUserToken_Secuserid_N, false, includeNonInitialized);
         AddObjectProperty("SecUserTokenUsed", gxTv_SdtSecUserToken_Secusertokenused, false, includeNonInitialized);
         AddObjectProperty("SecUserTokenUsed_N", gxTv_SdtSecUserToken_Secusertokenused_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtSecUserToken_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtSecUserToken_Initialized, false, includeNonInitialized);
            AddObjectProperty("SecUserTokenID_Z", gxTv_SdtSecUserToken_Secusertokenid_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtSecUserToken_Secusertokendatetime_Z;
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
            AddObjectProperty("SecUserTokenDateTime_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("SecUserId_Z", gxTv_SdtSecUserToken_Secuserid_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserTokenUsed_Z", gxTv_SdtSecUserToken_Secusertokenused_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserTokenKey_N", gxTv_SdtSecUserToken_Secusertokenkey_N, false, includeNonInitialized);
            AddObjectProperty("SecUserTokenDateTime_N", gxTv_SdtSecUserToken_Secusertokendatetime_N, false, includeNonInitialized);
            AddObjectProperty("SecUserId_N", gxTv_SdtSecUserToken_Secuserid_N, false, includeNonInitialized);
            AddObjectProperty("SecUserTokenUsed_N", gxTv_SdtSecUserToken_Secusertokenused_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtSecUserToken sdt )
      {
         if ( sdt.IsDirty("SecUserTokenID") )
         {
            sdtIsNull = 0;
            gxTv_SdtSecUserToken_Secusertokenid = sdt.gxTv_SdtSecUserToken_Secusertokenid ;
         }
         if ( sdt.IsDirty("SecUserTokenKey") )
         {
            gxTv_SdtSecUserToken_Secusertokenkey_N = (short)(sdt.gxTv_SdtSecUserToken_Secusertokenkey_N);
            sdtIsNull = 0;
            gxTv_SdtSecUserToken_Secusertokenkey = sdt.gxTv_SdtSecUserToken_Secusertokenkey ;
         }
         if ( sdt.IsDirty("SecUserTokenDateTime") )
         {
            gxTv_SdtSecUserToken_Secusertokendatetime_N = (short)(sdt.gxTv_SdtSecUserToken_Secusertokendatetime_N);
            sdtIsNull = 0;
            gxTv_SdtSecUserToken_Secusertokendatetime = sdt.gxTv_SdtSecUserToken_Secusertokendatetime ;
         }
         if ( sdt.IsDirty("SecUserId") )
         {
            gxTv_SdtSecUserToken_Secuserid_N = (short)(sdt.gxTv_SdtSecUserToken_Secuserid_N);
            sdtIsNull = 0;
            gxTv_SdtSecUserToken_Secuserid = sdt.gxTv_SdtSecUserToken_Secuserid ;
         }
         if ( sdt.IsDirty("SecUserTokenUsed") )
         {
            gxTv_SdtSecUserToken_Secusertokenused_N = (short)(sdt.gxTv_SdtSecUserToken_Secusertokenused_N);
            sdtIsNull = 0;
            gxTv_SdtSecUserToken_Secusertokenused = sdt.gxTv_SdtSecUserToken_Secusertokenused ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "SecUserTokenID" )]
      [  XmlElement( ElementName = "SecUserTokenID"   )]
      public short gxTpr_Secusertokenid
      {
         get {
            return gxTv_SdtSecUserToken_Secusertokenid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtSecUserToken_Secusertokenid != value )
            {
               gxTv_SdtSecUserToken_Mode = "INS";
               this.gxTv_SdtSecUserToken_Secusertokenid_Z_SetNull( );
               this.gxTv_SdtSecUserToken_Secusertokendatetime_Z_SetNull( );
               this.gxTv_SdtSecUserToken_Secuserid_Z_SetNull( );
               this.gxTv_SdtSecUserToken_Secusertokenused_Z_SetNull( );
            }
            gxTv_SdtSecUserToken_Secusertokenid = value;
            SetDirty("Secusertokenid");
         }

      }

      [  SoapElement( ElementName = "SecUserTokenKey" )]
      [  XmlElement( ElementName = "SecUserTokenKey"   )]
      public string gxTpr_Secusertokenkey
      {
         get {
            return gxTv_SdtSecUserToken_Secusertokenkey ;
         }

         set {
            gxTv_SdtSecUserToken_Secusertokenkey_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecUserToken_Secusertokenkey = value;
            SetDirty("Secusertokenkey");
         }

      }

      public void gxTv_SdtSecUserToken_Secusertokenkey_SetNull( )
      {
         gxTv_SdtSecUserToken_Secusertokenkey_N = 1;
         gxTv_SdtSecUserToken_Secusertokenkey = "";
         SetDirty("Secusertokenkey");
         return  ;
      }

      public bool gxTv_SdtSecUserToken_Secusertokenkey_IsNull( )
      {
         return (gxTv_SdtSecUserToken_Secusertokenkey_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserTokenDateTime" )]
      [  XmlElement( ElementName = "SecUserTokenDateTime"  , IsNullable=true )]
      public string gxTpr_Secusertokendatetime_Nullable
      {
         get {
            if ( gxTv_SdtSecUserToken_Secusertokendatetime == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtSecUserToken_Secusertokendatetime).value ;
         }

         set {
            gxTv_SdtSecUserToken_Secusertokendatetime_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtSecUserToken_Secusertokendatetime = DateTime.MinValue;
            else
               gxTv_SdtSecUserToken_Secusertokendatetime = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Secusertokendatetime
      {
         get {
            return gxTv_SdtSecUserToken_Secusertokendatetime ;
         }

         set {
            gxTv_SdtSecUserToken_Secusertokendatetime_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecUserToken_Secusertokendatetime = value;
            SetDirty("Secusertokendatetime");
         }

      }

      public void gxTv_SdtSecUserToken_Secusertokendatetime_SetNull( )
      {
         gxTv_SdtSecUserToken_Secusertokendatetime_N = 1;
         gxTv_SdtSecUserToken_Secusertokendatetime = (DateTime)(DateTime.MinValue);
         SetDirty("Secusertokendatetime");
         return  ;
      }

      public bool gxTv_SdtSecUserToken_Secusertokendatetime_IsNull( )
      {
         return (gxTv_SdtSecUserToken_Secusertokendatetime_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserId" )]
      [  XmlElement( ElementName = "SecUserId"   )]
      public short gxTpr_Secuserid
      {
         get {
            return gxTv_SdtSecUserToken_Secuserid ;
         }

         set {
            gxTv_SdtSecUserToken_Secuserid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecUserToken_Secuserid = value;
            SetDirty("Secuserid");
         }

      }

      public void gxTv_SdtSecUserToken_Secuserid_SetNull( )
      {
         gxTv_SdtSecUserToken_Secuserid_N = 1;
         gxTv_SdtSecUserToken_Secuserid = 0;
         SetDirty("Secuserid");
         return  ;
      }

      public bool gxTv_SdtSecUserToken_Secuserid_IsNull( )
      {
         return (gxTv_SdtSecUserToken_Secuserid_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserTokenUsed" )]
      [  XmlElement( ElementName = "SecUserTokenUsed"   )]
      public bool gxTpr_Secusertokenused
      {
         get {
            return gxTv_SdtSecUserToken_Secusertokenused ;
         }

         set {
            gxTv_SdtSecUserToken_Secusertokenused_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecUserToken_Secusertokenused = value;
            SetDirty("Secusertokenused");
         }

      }

      public void gxTv_SdtSecUserToken_Secusertokenused_SetNull( )
      {
         gxTv_SdtSecUserToken_Secusertokenused_N = 1;
         gxTv_SdtSecUserToken_Secusertokenused = false;
         SetDirty("Secusertokenused");
         return  ;
      }

      public bool gxTv_SdtSecUserToken_Secusertokenused_IsNull( )
      {
         return (gxTv_SdtSecUserToken_Secusertokenused_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtSecUserToken_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUserToken_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtSecUserToken_Mode_SetNull( )
      {
         gxTv_SdtSecUserToken_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtSecUserToken_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtSecUserToken_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUserToken_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtSecUserToken_Initialized_SetNull( )
      {
         gxTv_SdtSecUserToken_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtSecUserToken_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserTokenID_Z" )]
      [  XmlElement( ElementName = "SecUserTokenID_Z"   )]
      public short gxTpr_Secusertokenid_Z
      {
         get {
            return gxTv_SdtSecUserToken_Secusertokenid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUserToken_Secusertokenid_Z = value;
            SetDirty("Secusertokenid_Z");
         }

      }

      public void gxTv_SdtSecUserToken_Secusertokenid_Z_SetNull( )
      {
         gxTv_SdtSecUserToken_Secusertokenid_Z = 0;
         SetDirty("Secusertokenid_Z");
         return  ;
      }

      public bool gxTv_SdtSecUserToken_Secusertokenid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserTokenDateTime_Z" )]
      [  XmlElement( ElementName = "SecUserTokenDateTime_Z"  , IsNullable=true )]
      public string gxTpr_Secusertokendatetime_Z_Nullable
      {
         get {
            if ( gxTv_SdtSecUserToken_Secusertokendatetime_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtSecUserToken_Secusertokendatetime_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtSecUserToken_Secusertokendatetime_Z = DateTime.MinValue;
            else
               gxTv_SdtSecUserToken_Secusertokendatetime_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Secusertokendatetime_Z
      {
         get {
            return gxTv_SdtSecUserToken_Secusertokendatetime_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUserToken_Secusertokendatetime_Z = value;
            SetDirty("Secusertokendatetime_Z");
         }

      }

      public void gxTv_SdtSecUserToken_Secusertokendatetime_Z_SetNull( )
      {
         gxTv_SdtSecUserToken_Secusertokendatetime_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Secusertokendatetime_Z");
         return  ;
      }

      public bool gxTv_SdtSecUserToken_Secusertokendatetime_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserId_Z" )]
      [  XmlElement( ElementName = "SecUserId_Z"   )]
      public short gxTpr_Secuserid_Z
      {
         get {
            return gxTv_SdtSecUserToken_Secuserid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUserToken_Secuserid_Z = value;
            SetDirty("Secuserid_Z");
         }

      }

      public void gxTv_SdtSecUserToken_Secuserid_Z_SetNull( )
      {
         gxTv_SdtSecUserToken_Secuserid_Z = 0;
         SetDirty("Secuserid_Z");
         return  ;
      }

      public bool gxTv_SdtSecUserToken_Secuserid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserTokenUsed_Z" )]
      [  XmlElement( ElementName = "SecUserTokenUsed_Z"   )]
      public bool gxTpr_Secusertokenused_Z
      {
         get {
            return gxTv_SdtSecUserToken_Secusertokenused_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUserToken_Secusertokenused_Z = value;
            SetDirty("Secusertokenused_Z");
         }

      }

      public void gxTv_SdtSecUserToken_Secusertokenused_Z_SetNull( )
      {
         gxTv_SdtSecUserToken_Secusertokenused_Z = false;
         SetDirty("Secusertokenused_Z");
         return  ;
      }

      public bool gxTv_SdtSecUserToken_Secusertokenused_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserTokenKey_N" )]
      [  XmlElement( ElementName = "SecUserTokenKey_N"   )]
      public short gxTpr_Secusertokenkey_N
      {
         get {
            return gxTv_SdtSecUserToken_Secusertokenkey_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUserToken_Secusertokenkey_N = value;
            SetDirty("Secusertokenkey_N");
         }

      }

      public void gxTv_SdtSecUserToken_Secusertokenkey_N_SetNull( )
      {
         gxTv_SdtSecUserToken_Secusertokenkey_N = 0;
         SetDirty("Secusertokenkey_N");
         return  ;
      }

      public bool gxTv_SdtSecUserToken_Secusertokenkey_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserTokenDateTime_N" )]
      [  XmlElement( ElementName = "SecUserTokenDateTime_N"   )]
      public short gxTpr_Secusertokendatetime_N
      {
         get {
            return gxTv_SdtSecUserToken_Secusertokendatetime_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUserToken_Secusertokendatetime_N = value;
            SetDirty("Secusertokendatetime_N");
         }

      }

      public void gxTv_SdtSecUserToken_Secusertokendatetime_N_SetNull( )
      {
         gxTv_SdtSecUserToken_Secusertokendatetime_N = 0;
         SetDirty("Secusertokendatetime_N");
         return  ;
      }

      public bool gxTv_SdtSecUserToken_Secusertokendatetime_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserId_N" )]
      [  XmlElement( ElementName = "SecUserId_N"   )]
      public short gxTpr_Secuserid_N
      {
         get {
            return gxTv_SdtSecUserToken_Secuserid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUserToken_Secuserid_N = value;
            SetDirty("Secuserid_N");
         }

      }

      public void gxTv_SdtSecUserToken_Secuserid_N_SetNull( )
      {
         gxTv_SdtSecUserToken_Secuserid_N = 0;
         SetDirty("Secuserid_N");
         return  ;
      }

      public bool gxTv_SdtSecUserToken_Secuserid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserTokenUsed_N" )]
      [  XmlElement( ElementName = "SecUserTokenUsed_N"   )]
      public short gxTpr_Secusertokenused_N
      {
         get {
            return gxTv_SdtSecUserToken_Secusertokenused_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUserToken_Secusertokenused_N = value;
            SetDirty("Secusertokenused_N");
         }

      }

      public void gxTv_SdtSecUserToken_Secusertokenused_N_SetNull( )
      {
         gxTv_SdtSecUserToken_Secusertokenused_N = 0;
         SetDirty("Secusertokenused_N");
         return  ;
      }

      public bool gxTv_SdtSecUserToken_Secusertokenused_N_IsNull( )
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
         gxTv_SdtSecUserToken_Secusertokenkey = "";
         gxTv_SdtSecUserToken_Secusertokendatetime = (DateTime)(DateTime.MinValue);
         gxTv_SdtSecUserToken_Mode = "";
         gxTv_SdtSecUserToken_Secusertokendatetime_Z = (DateTime)(DateTime.MinValue);
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "secusertoken", "GeneXus.Programs.secusertoken_bc", new Object[] {context}, constructorCallingAssembly);;
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

      private short gxTv_SdtSecUserToken_Secusertokenid ;
      private short sdtIsNull ;
      private short gxTv_SdtSecUserToken_Secuserid ;
      private short gxTv_SdtSecUserToken_Initialized ;
      private short gxTv_SdtSecUserToken_Secusertokenid_Z ;
      private short gxTv_SdtSecUserToken_Secuserid_Z ;
      private short gxTv_SdtSecUserToken_Secusertokenkey_N ;
      private short gxTv_SdtSecUserToken_Secusertokendatetime_N ;
      private short gxTv_SdtSecUserToken_Secuserid_N ;
      private short gxTv_SdtSecUserToken_Secusertokenused_N ;
      private string gxTv_SdtSecUserToken_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtSecUserToken_Secusertokendatetime ;
      private DateTime gxTv_SdtSecUserToken_Secusertokendatetime_Z ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtSecUserToken_Secusertokenused ;
      private bool gxTv_SdtSecUserToken_Secusertokenused_Z ;
      private string gxTv_SdtSecUserToken_Secusertokenkey ;
   }

   [DataContract(Name = @"SecUserToken", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtSecUserToken_RESTInterface : GxGenericCollectionItem<SdtSecUserToken>
   {
      public SdtSecUserToken_RESTInterface( ) : base()
      {
      }

      public SdtSecUserToken_RESTInterface( SdtSecUserToken psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SecUserTokenID" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Secusertokenid
      {
         get {
            return sdt.gxTpr_Secusertokenid ;
         }

         set {
            sdt.gxTpr_Secusertokenid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "SecUserTokenKey" , Order = 1 )]
      public string gxTpr_Secusertokenkey
      {
         get {
            return sdt.gxTpr_Secusertokenkey ;
         }

         set {
            sdt.gxTpr_Secusertokenkey = value;
         }

      }

      [DataMember( Name = "SecUserTokenDateTime" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Secusertokendatetime
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Secusertokendatetime, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Secusertokendatetime = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "SecUserId" , Order = 3 )]
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

      [DataMember( Name = "SecUserTokenUsed" , Order = 4 )]
      [GxSeudo()]
      public bool gxTpr_Secusertokenused
      {
         get {
            return sdt.gxTpr_Secusertokenused ;
         }

         set {
            sdt.gxTpr_Secusertokenused = value;
         }

      }

      public SdtSecUserToken sdt
      {
         get {
            return (SdtSecUserToken)Sdt ;
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
            sdt = new SdtSecUserToken() ;
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

   [DataContract(Name = @"SecUserToken", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtSecUserToken_RESTLInterface : GxGenericCollectionItem<SdtSecUserToken>
   {
      public SdtSecUserToken_RESTLInterface( ) : base()
      {
      }

      public SdtSecUserToken_RESTLInterface( SdtSecUserToken psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SecUserTokenDateTime" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Secusertokendatetime
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Secusertokendatetime, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Secusertokendatetime = DateTimeUtil.CToT2( value, (IGxContext)(context));
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

      public SdtSecUserToken sdt
      {
         get {
            return (SdtSecUserToken)Sdt ;
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
            sdt = new SdtSecUserToken() ;
         }
      }

   }

}
