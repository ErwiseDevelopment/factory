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
   [XmlRoot(ElementName = "TemporaryCode" )]
   [XmlType(TypeName =  "TemporaryCode" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtTemporaryCode : GxSilentTrnSdt
   {
      public SdtTemporaryCode( )
      {
      }

      public SdtTemporaryCode( IGxContext context )
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

      public void Load( int AV214TemporaryCodeId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV214TemporaryCodeId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"TemporaryCodeId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "TemporaryCode");
         metadata.Set("BT", "TemporaryCode");
         metadata.Set("PK", "[ \"TemporaryCodeId\" ]");
         metadata.Set("PKAssigned", "[ \"TemporaryCodeId\" ]");
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
         state.Add("gxTpr_Temporarycodeid_Z");
         state.Add("gxTpr_Temporarycodecontent_Z");
         state.Add("gxTpr_Temporarycodedatetime_Z_Nullable");
         state.Add("gxTpr_Temporarycodeemail_Z");
         state.Add("gxTpr_Temporarycodeused_Z");
         state.Add("gxTpr_Temporarycodecontent_N");
         state.Add("gxTpr_Temporarycodedatetime_N");
         state.Add("gxTpr_Temporarycodeemail_N");
         state.Add("gxTpr_Temporarycodeused_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTemporaryCode sdt;
         sdt = (SdtTemporaryCode)(source);
         gxTv_SdtTemporaryCode_Temporarycodeid = sdt.gxTv_SdtTemporaryCode_Temporarycodeid ;
         gxTv_SdtTemporaryCode_Temporarycodecontent = sdt.gxTv_SdtTemporaryCode_Temporarycodecontent ;
         gxTv_SdtTemporaryCode_Temporarycodedatetime = sdt.gxTv_SdtTemporaryCode_Temporarycodedatetime ;
         gxTv_SdtTemporaryCode_Temporarycodeemail = sdt.gxTv_SdtTemporaryCode_Temporarycodeemail ;
         gxTv_SdtTemporaryCode_Temporarycodeused = sdt.gxTv_SdtTemporaryCode_Temporarycodeused ;
         gxTv_SdtTemporaryCode_Mode = sdt.gxTv_SdtTemporaryCode_Mode ;
         gxTv_SdtTemporaryCode_Initialized = sdt.gxTv_SdtTemporaryCode_Initialized ;
         gxTv_SdtTemporaryCode_Temporarycodeid_Z = sdt.gxTv_SdtTemporaryCode_Temporarycodeid_Z ;
         gxTv_SdtTemporaryCode_Temporarycodecontent_Z = sdt.gxTv_SdtTemporaryCode_Temporarycodecontent_Z ;
         gxTv_SdtTemporaryCode_Temporarycodedatetime_Z = sdt.gxTv_SdtTemporaryCode_Temporarycodedatetime_Z ;
         gxTv_SdtTemporaryCode_Temporarycodeemail_Z = sdt.gxTv_SdtTemporaryCode_Temporarycodeemail_Z ;
         gxTv_SdtTemporaryCode_Temporarycodeused_Z = sdt.gxTv_SdtTemporaryCode_Temporarycodeused_Z ;
         gxTv_SdtTemporaryCode_Temporarycodecontent_N = sdt.gxTv_SdtTemporaryCode_Temporarycodecontent_N ;
         gxTv_SdtTemporaryCode_Temporarycodedatetime_N = sdt.gxTv_SdtTemporaryCode_Temporarycodedatetime_N ;
         gxTv_SdtTemporaryCode_Temporarycodeemail_N = sdt.gxTv_SdtTemporaryCode_Temporarycodeemail_N ;
         gxTv_SdtTemporaryCode_Temporarycodeused_N = sdt.gxTv_SdtTemporaryCode_Temporarycodeused_N ;
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
         AddObjectProperty("TemporaryCodeId", gxTv_SdtTemporaryCode_Temporarycodeid, false, includeNonInitialized);
         AddObjectProperty("TemporaryCodeContent", gxTv_SdtTemporaryCode_Temporarycodecontent, false, includeNonInitialized);
         AddObjectProperty("TemporaryCodeContent_N", gxTv_SdtTemporaryCode_Temporarycodecontent_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtTemporaryCode_Temporarycodedatetime;
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
         AddObjectProperty("TemporaryCodeDateTime", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("TemporaryCodeDateTime_N", gxTv_SdtTemporaryCode_Temporarycodedatetime_N, false, includeNonInitialized);
         AddObjectProperty("TemporaryCodeEmail", gxTv_SdtTemporaryCode_Temporarycodeemail, false, includeNonInitialized);
         AddObjectProperty("TemporaryCodeEmail_N", gxTv_SdtTemporaryCode_Temporarycodeemail_N, false, includeNonInitialized);
         AddObjectProperty("TemporaryCodeUsed", gxTv_SdtTemporaryCode_Temporarycodeused, false, includeNonInitialized);
         AddObjectProperty("TemporaryCodeUsed_N", gxTv_SdtTemporaryCode_Temporarycodeused_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTemporaryCode_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTemporaryCode_Initialized, false, includeNonInitialized);
            AddObjectProperty("TemporaryCodeId_Z", gxTv_SdtTemporaryCode_Temporarycodeid_Z, false, includeNonInitialized);
            AddObjectProperty("TemporaryCodeContent_Z", gxTv_SdtTemporaryCode_Temporarycodecontent_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtTemporaryCode_Temporarycodedatetime_Z;
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
            AddObjectProperty("TemporaryCodeDateTime_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("TemporaryCodeEmail_Z", gxTv_SdtTemporaryCode_Temporarycodeemail_Z, false, includeNonInitialized);
            AddObjectProperty("TemporaryCodeUsed_Z", gxTv_SdtTemporaryCode_Temporarycodeused_Z, false, includeNonInitialized);
            AddObjectProperty("TemporaryCodeContent_N", gxTv_SdtTemporaryCode_Temporarycodecontent_N, false, includeNonInitialized);
            AddObjectProperty("TemporaryCodeDateTime_N", gxTv_SdtTemporaryCode_Temporarycodedatetime_N, false, includeNonInitialized);
            AddObjectProperty("TemporaryCodeEmail_N", gxTv_SdtTemporaryCode_Temporarycodeemail_N, false, includeNonInitialized);
            AddObjectProperty("TemporaryCodeUsed_N", gxTv_SdtTemporaryCode_Temporarycodeused_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTemporaryCode sdt )
      {
         if ( sdt.IsDirty("TemporaryCodeId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTemporaryCode_Temporarycodeid = sdt.gxTv_SdtTemporaryCode_Temporarycodeid ;
         }
         if ( sdt.IsDirty("TemporaryCodeContent") )
         {
            gxTv_SdtTemporaryCode_Temporarycodecontent_N = (short)(sdt.gxTv_SdtTemporaryCode_Temporarycodecontent_N);
            sdtIsNull = 0;
            gxTv_SdtTemporaryCode_Temporarycodecontent = sdt.gxTv_SdtTemporaryCode_Temporarycodecontent ;
         }
         if ( sdt.IsDirty("TemporaryCodeDateTime") )
         {
            gxTv_SdtTemporaryCode_Temporarycodedatetime_N = (short)(sdt.gxTv_SdtTemporaryCode_Temporarycodedatetime_N);
            sdtIsNull = 0;
            gxTv_SdtTemporaryCode_Temporarycodedatetime = sdt.gxTv_SdtTemporaryCode_Temporarycodedatetime ;
         }
         if ( sdt.IsDirty("TemporaryCodeEmail") )
         {
            gxTv_SdtTemporaryCode_Temporarycodeemail_N = (short)(sdt.gxTv_SdtTemporaryCode_Temporarycodeemail_N);
            sdtIsNull = 0;
            gxTv_SdtTemporaryCode_Temporarycodeemail = sdt.gxTv_SdtTemporaryCode_Temporarycodeemail ;
         }
         if ( sdt.IsDirty("TemporaryCodeUsed") )
         {
            gxTv_SdtTemporaryCode_Temporarycodeused_N = (short)(sdt.gxTv_SdtTemporaryCode_Temporarycodeused_N);
            sdtIsNull = 0;
            gxTv_SdtTemporaryCode_Temporarycodeused = sdt.gxTv_SdtTemporaryCode_Temporarycodeused ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "TemporaryCodeId" )]
      [  XmlElement( ElementName = "TemporaryCodeId"   )]
      public int gxTpr_Temporarycodeid
      {
         get {
            return gxTv_SdtTemporaryCode_Temporarycodeid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTemporaryCode_Temporarycodeid != value )
            {
               gxTv_SdtTemporaryCode_Mode = "INS";
               this.gxTv_SdtTemporaryCode_Temporarycodeid_Z_SetNull( );
               this.gxTv_SdtTemporaryCode_Temporarycodecontent_Z_SetNull( );
               this.gxTv_SdtTemporaryCode_Temporarycodedatetime_Z_SetNull( );
               this.gxTv_SdtTemporaryCode_Temporarycodeemail_Z_SetNull( );
               this.gxTv_SdtTemporaryCode_Temporarycodeused_Z_SetNull( );
            }
            gxTv_SdtTemporaryCode_Temporarycodeid = value;
            SetDirty("Temporarycodeid");
         }

      }

      [  SoapElement( ElementName = "TemporaryCodeContent" )]
      [  XmlElement( ElementName = "TemporaryCodeContent"   )]
      public string gxTpr_Temporarycodecontent
      {
         get {
            return gxTv_SdtTemporaryCode_Temporarycodecontent ;
         }

         set {
            gxTv_SdtTemporaryCode_Temporarycodecontent_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTemporaryCode_Temporarycodecontent = value;
            SetDirty("Temporarycodecontent");
         }

      }

      public void gxTv_SdtTemporaryCode_Temporarycodecontent_SetNull( )
      {
         gxTv_SdtTemporaryCode_Temporarycodecontent_N = 1;
         gxTv_SdtTemporaryCode_Temporarycodecontent = "";
         SetDirty("Temporarycodecontent");
         return  ;
      }

      public bool gxTv_SdtTemporaryCode_Temporarycodecontent_IsNull( )
      {
         return (gxTv_SdtTemporaryCode_Temporarycodecontent_N==1) ;
      }

      [  SoapElement( ElementName = "TemporaryCodeDateTime" )]
      [  XmlElement( ElementName = "TemporaryCodeDateTime"  , IsNullable=true )]
      public string gxTpr_Temporarycodedatetime_Nullable
      {
         get {
            if ( gxTv_SdtTemporaryCode_Temporarycodedatetime == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTemporaryCode_Temporarycodedatetime).value ;
         }

         set {
            gxTv_SdtTemporaryCode_Temporarycodedatetime_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTemporaryCode_Temporarycodedatetime = DateTime.MinValue;
            else
               gxTv_SdtTemporaryCode_Temporarycodedatetime = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Temporarycodedatetime
      {
         get {
            return gxTv_SdtTemporaryCode_Temporarycodedatetime ;
         }

         set {
            gxTv_SdtTemporaryCode_Temporarycodedatetime_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTemporaryCode_Temporarycodedatetime = value;
            SetDirty("Temporarycodedatetime");
         }

      }

      public void gxTv_SdtTemporaryCode_Temporarycodedatetime_SetNull( )
      {
         gxTv_SdtTemporaryCode_Temporarycodedatetime_N = 1;
         gxTv_SdtTemporaryCode_Temporarycodedatetime = (DateTime)(DateTime.MinValue);
         SetDirty("Temporarycodedatetime");
         return  ;
      }

      public bool gxTv_SdtTemporaryCode_Temporarycodedatetime_IsNull( )
      {
         return (gxTv_SdtTemporaryCode_Temporarycodedatetime_N==1) ;
      }

      [  SoapElement( ElementName = "TemporaryCodeEmail" )]
      [  XmlElement( ElementName = "TemporaryCodeEmail"   )]
      public string gxTpr_Temporarycodeemail
      {
         get {
            return gxTv_SdtTemporaryCode_Temporarycodeemail ;
         }

         set {
            gxTv_SdtTemporaryCode_Temporarycodeemail_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTemporaryCode_Temporarycodeemail = value;
            SetDirty("Temporarycodeemail");
         }

      }

      public void gxTv_SdtTemporaryCode_Temporarycodeemail_SetNull( )
      {
         gxTv_SdtTemporaryCode_Temporarycodeemail_N = 1;
         gxTv_SdtTemporaryCode_Temporarycodeemail = "";
         SetDirty("Temporarycodeemail");
         return  ;
      }

      public bool gxTv_SdtTemporaryCode_Temporarycodeemail_IsNull( )
      {
         return (gxTv_SdtTemporaryCode_Temporarycodeemail_N==1) ;
      }

      [  SoapElement( ElementName = "TemporaryCodeUsed" )]
      [  XmlElement( ElementName = "TemporaryCodeUsed"   )]
      public bool gxTpr_Temporarycodeused
      {
         get {
            return gxTv_SdtTemporaryCode_Temporarycodeused ;
         }

         set {
            gxTv_SdtTemporaryCode_Temporarycodeused_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTemporaryCode_Temporarycodeused = value;
            SetDirty("Temporarycodeused");
         }

      }

      public void gxTv_SdtTemporaryCode_Temporarycodeused_SetNull( )
      {
         gxTv_SdtTemporaryCode_Temporarycodeused_N = 1;
         gxTv_SdtTemporaryCode_Temporarycodeused = false;
         SetDirty("Temporarycodeused");
         return  ;
      }

      public bool gxTv_SdtTemporaryCode_Temporarycodeused_IsNull( )
      {
         return (gxTv_SdtTemporaryCode_Temporarycodeused_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTemporaryCode_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTemporaryCode_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTemporaryCode_Mode_SetNull( )
      {
         gxTv_SdtTemporaryCode_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTemporaryCode_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTemporaryCode_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTemporaryCode_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTemporaryCode_Initialized_SetNull( )
      {
         gxTv_SdtTemporaryCode_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTemporaryCode_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TemporaryCodeId_Z" )]
      [  XmlElement( ElementName = "TemporaryCodeId_Z"   )]
      public int gxTpr_Temporarycodeid_Z
      {
         get {
            return gxTv_SdtTemporaryCode_Temporarycodeid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTemporaryCode_Temporarycodeid_Z = value;
            SetDirty("Temporarycodeid_Z");
         }

      }

      public void gxTv_SdtTemporaryCode_Temporarycodeid_Z_SetNull( )
      {
         gxTv_SdtTemporaryCode_Temporarycodeid_Z = 0;
         SetDirty("Temporarycodeid_Z");
         return  ;
      }

      public bool gxTv_SdtTemporaryCode_Temporarycodeid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TemporaryCodeContent_Z" )]
      [  XmlElement( ElementName = "TemporaryCodeContent_Z"   )]
      public string gxTpr_Temporarycodecontent_Z
      {
         get {
            return gxTv_SdtTemporaryCode_Temporarycodecontent_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTemporaryCode_Temporarycodecontent_Z = value;
            SetDirty("Temporarycodecontent_Z");
         }

      }

      public void gxTv_SdtTemporaryCode_Temporarycodecontent_Z_SetNull( )
      {
         gxTv_SdtTemporaryCode_Temporarycodecontent_Z = "";
         SetDirty("Temporarycodecontent_Z");
         return  ;
      }

      public bool gxTv_SdtTemporaryCode_Temporarycodecontent_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TemporaryCodeDateTime_Z" )]
      [  XmlElement( ElementName = "TemporaryCodeDateTime_Z"  , IsNullable=true )]
      public string gxTpr_Temporarycodedatetime_Z_Nullable
      {
         get {
            if ( gxTv_SdtTemporaryCode_Temporarycodedatetime_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTemporaryCode_Temporarycodedatetime_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTemporaryCode_Temporarycodedatetime_Z = DateTime.MinValue;
            else
               gxTv_SdtTemporaryCode_Temporarycodedatetime_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Temporarycodedatetime_Z
      {
         get {
            return gxTv_SdtTemporaryCode_Temporarycodedatetime_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTemporaryCode_Temporarycodedatetime_Z = value;
            SetDirty("Temporarycodedatetime_Z");
         }

      }

      public void gxTv_SdtTemporaryCode_Temporarycodedatetime_Z_SetNull( )
      {
         gxTv_SdtTemporaryCode_Temporarycodedatetime_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Temporarycodedatetime_Z");
         return  ;
      }

      public bool gxTv_SdtTemporaryCode_Temporarycodedatetime_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TemporaryCodeEmail_Z" )]
      [  XmlElement( ElementName = "TemporaryCodeEmail_Z"   )]
      public string gxTpr_Temporarycodeemail_Z
      {
         get {
            return gxTv_SdtTemporaryCode_Temporarycodeemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTemporaryCode_Temporarycodeemail_Z = value;
            SetDirty("Temporarycodeemail_Z");
         }

      }

      public void gxTv_SdtTemporaryCode_Temporarycodeemail_Z_SetNull( )
      {
         gxTv_SdtTemporaryCode_Temporarycodeemail_Z = "";
         SetDirty("Temporarycodeemail_Z");
         return  ;
      }

      public bool gxTv_SdtTemporaryCode_Temporarycodeemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TemporaryCodeUsed_Z" )]
      [  XmlElement( ElementName = "TemporaryCodeUsed_Z"   )]
      public bool gxTpr_Temporarycodeused_Z
      {
         get {
            return gxTv_SdtTemporaryCode_Temporarycodeused_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTemporaryCode_Temporarycodeused_Z = value;
            SetDirty("Temporarycodeused_Z");
         }

      }

      public void gxTv_SdtTemporaryCode_Temporarycodeused_Z_SetNull( )
      {
         gxTv_SdtTemporaryCode_Temporarycodeused_Z = false;
         SetDirty("Temporarycodeused_Z");
         return  ;
      }

      public bool gxTv_SdtTemporaryCode_Temporarycodeused_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TemporaryCodeContent_N" )]
      [  XmlElement( ElementName = "TemporaryCodeContent_N"   )]
      public short gxTpr_Temporarycodecontent_N
      {
         get {
            return gxTv_SdtTemporaryCode_Temporarycodecontent_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTemporaryCode_Temporarycodecontent_N = value;
            SetDirty("Temporarycodecontent_N");
         }

      }

      public void gxTv_SdtTemporaryCode_Temporarycodecontent_N_SetNull( )
      {
         gxTv_SdtTemporaryCode_Temporarycodecontent_N = 0;
         SetDirty("Temporarycodecontent_N");
         return  ;
      }

      public bool gxTv_SdtTemporaryCode_Temporarycodecontent_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TemporaryCodeDateTime_N" )]
      [  XmlElement( ElementName = "TemporaryCodeDateTime_N"   )]
      public short gxTpr_Temporarycodedatetime_N
      {
         get {
            return gxTv_SdtTemporaryCode_Temporarycodedatetime_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTemporaryCode_Temporarycodedatetime_N = value;
            SetDirty("Temporarycodedatetime_N");
         }

      }

      public void gxTv_SdtTemporaryCode_Temporarycodedatetime_N_SetNull( )
      {
         gxTv_SdtTemporaryCode_Temporarycodedatetime_N = 0;
         SetDirty("Temporarycodedatetime_N");
         return  ;
      }

      public bool gxTv_SdtTemporaryCode_Temporarycodedatetime_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TemporaryCodeEmail_N" )]
      [  XmlElement( ElementName = "TemporaryCodeEmail_N"   )]
      public short gxTpr_Temporarycodeemail_N
      {
         get {
            return gxTv_SdtTemporaryCode_Temporarycodeemail_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTemporaryCode_Temporarycodeemail_N = value;
            SetDirty("Temporarycodeemail_N");
         }

      }

      public void gxTv_SdtTemporaryCode_Temporarycodeemail_N_SetNull( )
      {
         gxTv_SdtTemporaryCode_Temporarycodeemail_N = 0;
         SetDirty("Temporarycodeemail_N");
         return  ;
      }

      public bool gxTv_SdtTemporaryCode_Temporarycodeemail_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TemporaryCodeUsed_N" )]
      [  XmlElement( ElementName = "TemporaryCodeUsed_N"   )]
      public short gxTpr_Temporarycodeused_N
      {
         get {
            return gxTv_SdtTemporaryCode_Temporarycodeused_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTemporaryCode_Temporarycodeused_N = value;
            SetDirty("Temporarycodeused_N");
         }

      }

      public void gxTv_SdtTemporaryCode_Temporarycodeused_N_SetNull( )
      {
         gxTv_SdtTemporaryCode_Temporarycodeused_N = 0;
         SetDirty("Temporarycodeused_N");
         return  ;
      }

      public bool gxTv_SdtTemporaryCode_Temporarycodeused_N_IsNull( )
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
         gxTv_SdtTemporaryCode_Temporarycodecontent = "";
         gxTv_SdtTemporaryCode_Temporarycodedatetime = (DateTime)(DateTime.MinValue);
         gxTv_SdtTemporaryCode_Temporarycodeemail = "";
         gxTv_SdtTemporaryCode_Mode = "";
         gxTv_SdtTemporaryCode_Temporarycodecontent_Z = "";
         gxTv_SdtTemporaryCode_Temporarycodedatetime_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtTemporaryCode_Temporarycodeemail_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "temporarycode", "GeneXus.Programs.temporarycode_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTemporaryCode_Initialized ;
      private short gxTv_SdtTemporaryCode_Temporarycodecontent_N ;
      private short gxTv_SdtTemporaryCode_Temporarycodedatetime_N ;
      private short gxTv_SdtTemporaryCode_Temporarycodeemail_N ;
      private short gxTv_SdtTemporaryCode_Temporarycodeused_N ;
      private int gxTv_SdtTemporaryCode_Temporarycodeid ;
      private int gxTv_SdtTemporaryCode_Temporarycodeid_Z ;
      private string gxTv_SdtTemporaryCode_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtTemporaryCode_Temporarycodedatetime ;
      private DateTime gxTv_SdtTemporaryCode_Temporarycodedatetime_Z ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtTemporaryCode_Temporarycodeused ;
      private bool gxTv_SdtTemporaryCode_Temporarycodeused_Z ;
      private string gxTv_SdtTemporaryCode_Temporarycodecontent ;
      private string gxTv_SdtTemporaryCode_Temporarycodeemail ;
      private string gxTv_SdtTemporaryCode_Temporarycodecontent_Z ;
      private string gxTv_SdtTemporaryCode_Temporarycodeemail_Z ;
   }

   [DataContract(Name = @"TemporaryCode", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtTemporaryCode_RESTInterface : GxGenericCollectionItem<SdtTemporaryCode>
   {
      public SdtTemporaryCode_RESTInterface( ) : base()
      {
      }

      public SdtTemporaryCode_RESTInterface( SdtTemporaryCode psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TemporaryCodeId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Temporarycodeid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Temporarycodeid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Temporarycodeid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "TemporaryCodeContent" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Temporarycodecontent
      {
         get {
            return sdt.gxTpr_Temporarycodecontent ;
         }

         set {
            sdt.gxTpr_Temporarycodecontent = value;
         }

      }

      [DataMember( Name = "TemporaryCodeDateTime" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Temporarycodedatetime
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Temporarycodedatetime, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Temporarycodedatetime = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "TemporaryCodeEmail" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Temporarycodeemail
      {
         get {
            return sdt.gxTpr_Temporarycodeemail ;
         }

         set {
            sdt.gxTpr_Temporarycodeemail = value;
         }

      }

      [DataMember( Name = "TemporaryCodeUsed" , Order = 4 )]
      [GxSeudo()]
      public bool gxTpr_Temporarycodeused
      {
         get {
            return sdt.gxTpr_Temporarycodeused ;
         }

         set {
            sdt.gxTpr_Temporarycodeused = value;
         }

      }

      public SdtTemporaryCode sdt
      {
         get {
            return (SdtTemporaryCode)Sdt ;
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
            sdt = new SdtTemporaryCode() ;
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

   [DataContract(Name = @"TemporaryCode", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtTemporaryCode_RESTLInterface : GxGenericCollectionItem<SdtTemporaryCode>
   {
      public SdtTemporaryCode_RESTLInterface( ) : base()
      {
      }

      public SdtTemporaryCode_RESTLInterface( SdtTemporaryCode psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TemporaryCodeContent" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Temporarycodecontent
      {
         get {
            return sdt.gxTpr_Temporarycodecontent ;
         }

         set {
            sdt.gxTpr_Temporarycodecontent = value;
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

      public SdtTemporaryCode sdt
      {
         get {
            return (SdtTemporaryCode)Sdt ;
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
            sdt = new SdtTemporaryCode() ;
         }
      }

   }

}
