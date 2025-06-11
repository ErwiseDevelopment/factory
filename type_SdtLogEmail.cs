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
   [XmlRoot(ElementName = "LogEmail" )]
   [XmlType(TypeName =  "LogEmail" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtLogEmail : GxSilentTrnSdt
   {
      public SdtLogEmail( )
      {
      }

      public SdtLogEmail( IGxContext context )
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

      public void Load( int AV626LogEmailId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV626LogEmailId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"LogEmailId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "LogEmail");
         metadata.Set("BT", "LogEmail");
         metadata.Set("PK", "[ \"LogEmailId\" ]");
         metadata.Set("PKAssigned", "[ \"LogEmailId\" ]");
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
         state.Add("gxTpr_Logemailid_Z");
         state.Add("gxTpr_Logemailsubject_Z");
         state.Add("gxTpr_Logemaildestinatario_Z");
         state.Add("gxTpr_Logemailcreatedat_Z_Nullable");
         state.Add("gxTpr_Logemailcorpo_N");
         state.Add("gxTpr_Logemailsubject_N");
         state.Add("gxTpr_Logemaildestinatario_N");
         state.Add("gxTpr_Logemailcreatedat_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtLogEmail sdt;
         sdt = (SdtLogEmail)(source);
         gxTv_SdtLogEmail_Logemailid = sdt.gxTv_SdtLogEmail_Logemailid ;
         gxTv_SdtLogEmail_Logemailcorpo = sdt.gxTv_SdtLogEmail_Logemailcorpo ;
         gxTv_SdtLogEmail_Logemailsubject = sdt.gxTv_SdtLogEmail_Logemailsubject ;
         gxTv_SdtLogEmail_Logemaildestinatario = sdt.gxTv_SdtLogEmail_Logemaildestinatario ;
         gxTv_SdtLogEmail_Logemailcreatedat = sdt.gxTv_SdtLogEmail_Logemailcreatedat ;
         gxTv_SdtLogEmail_Mode = sdt.gxTv_SdtLogEmail_Mode ;
         gxTv_SdtLogEmail_Initialized = sdt.gxTv_SdtLogEmail_Initialized ;
         gxTv_SdtLogEmail_Logemailid_Z = sdt.gxTv_SdtLogEmail_Logemailid_Z ;
         gxTv_SdtLogEmail_Logemailsubject_Z = sdt.gxTv_SdtLogEmail_Logemailsubject_Z ;
         gxTv_SdtLogEmail_Logemaildestinatario_Z = sdt.gxTv_SdtLogEmail_Logemaildestinatario_Z ;
         gxTv_SdtLogEmail_Logemailcreatedat_Z = sdt.gxTv_SdtLogEmail_Logemailcreatedat_Z ;
         gxTv_SdtLogEmail_Logemailcorpo_N = sdt.gxTv_SdtLogEmail_Logemailcorpo_N ;
         gxTv_SdtLogEmail_Logemailsubject_N = sdt.gxTv_SdtLogEmail_Logemailsubject_N ;
         gxTv_SdtLogEmail_Logemaildestinatario_N = sdt.gxTv_SdtLogEmail_Logemaildestinatario_N ;
         gxTv_SdtLogEmail_Logemailcreatedat_N = sdt.gxTv_SdtLogEmail_Logemailcreatedat_N ;
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
         AddObjectProperty("LogEmailId", gxTv_SdtLogEmail_Logemailid, false, includeNonInitialized);
         AddObjectProperty("LogEmailCorpo", gxTv_SdtLogEmail_Logemailcorpo, false, includeNonInitialized);
         AddObjectProperty("LogEmailCorpo_N", gxTv_SdtLogEmail_Logemailcorpo_N, false, includeNonInitialized);
         AddObjectProperty("LogEmailSubject", gxTv_SdtLogEmail_Logemailsubject, false, includeNonInitialized);
         AddObjectProperty("LogEmailSubject_N", gxTv_SdtLogEmail_Logemailsubject_N, false, includeNonInitialized);
         AddObjectProperty("LogEmailDestinatario", gxTv_SdtLogEmail_Logemaildestinatario, false, includeNonInitialized);
         AddObjectProperty("LogEmailDestinatario_N", gxTv_SdtLogEmail_Logemaildestinatario_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtLogEmail_Logemailcreatedat;
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
         AddObjectProperty("LogEmailCreatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("LogEmailCreatedAt_N", gxTv_SdtLogEmail_Logemailcreatedat_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtLogEmail_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtLogEmail_Initialized, false, includeNonInitialized);
            AddObjectProperty("LogEmailId_Z", gxTv_SdtLogEmail_Logemailid_Z, false, includeNonInitialized);
            AddObjectProperty("LogEmailSubject_Z", gxTv_SdtLogEmail_Logemailsubject_Z, false, includeNonInitialized);
            AddObjectProperty("LogEmailDestinatario_Z", gxTv_SdtLogEmail_Logemaildestinatario_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtLogEmail_Logemailcreatedat_Z;
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
            AddObjectProperty("LogEmailCreatedAt_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("LogEmailCorpo_N", gxTv_SdtLogEmail_Logemailcorpo_N, false, includeNonInitialized);
            AddObjectProperty("LogEmailSubject_N", gxTv_SdtLogEmail_Logemailsubject_N, false, includeNonInitialized);
            AddObjectProperty("LogEmailDestinatario_N", gxTv_SdtLogEmail_Logemaildestinatario_N, false, includeNonInitialized);
            AddObjectProperty("LogEmailCreatedAt_N", gxTv_SdtLogEmail_Logemailcreatedat_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtLogEmail sdt )
      {
         if ( sdt.IsDirty("LogEmailId") )
         {
            sdtIsNull = 0;
            gxTv_SdtLogEmail_Logemailid = sdt.gxTv_SdtLogEmail_Logemailid ;
         }
         if ( sdt.IsDirty("LogEmailCorpo") )
         {
            gxTv_SdtLogEmail_Logemailcorpo_N = (short)(sdt.gxTv_SdtLogEmail_Logemailcorpo_N);
            sdtIsNull = 0;
            gxTv_SdtLogEmail_Logemailcorpo = sdt.gxTv_SdtLogEmail_Logemailcorpo ;
         }
         if ( sdt.IsDirty("LogEmailSubject") )
         {
            gxTv_SdtLogEmail_Logemailsubject_N = (short)(sdt.gxTv_SdtLogEmail_Logemailsubject_N);
            sdtIsNull = 0;
            gxTv_SdtLogEmail_Logemailsubject = sdt.gxTv_SdtLogEmail_Logemailsubject ;
         }
         if ( sdt.IsDirty("LogEmailDestinatario") )
         {
            gxTv_SdtLogEmail_Logemaildestinatario_N = (short)(sdt.gxTv_SdtLogEmail_Logemaildestinatario_N);
            sdtIsNull = 0;
            gxTv_SdtLogEmail_Logemaildestinatario = sdt.gxTv_SdtLogEmail_Logemaildestinatario ;
         }
         if ( sdt.IsDirty("LogEmailCreatedAt") )
         {
            gxTv_SdtLogEmail_Logemailcreatedat_N = (short)(sdt.gxTv_SdtLogEmail_Logemailcreatedat_N);
            sdtIsNull = 0;
            gxTv_SdtLogEmail_Logemailcreatedat = sdt.gxTv_SdtLogEmail_Logemailcreatedat ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "LogEmailId" )]
      [  XmlElement( ElementName = "LogEmailId"   )]
      public int gxTpr_Logemailid
      {
         get {
            return gxTv_SdtLogEmail_Logemailid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtLogEmail_Logemailid != value )
            {
               gxTv_SdtLogEmail_Mode = "INS";
               this.gxTv_SdtLogEmail_Logemailid_Z_SetNull( );
               this.gxTv_SdtLogEmail_Logemailsubject_Z_SetNull( );
               this.gxTv_SdtLogEmail_Logemaildestinatario_Z_SetNull( );
               this.gxTv_SdtLogEmail_Logemailcreatedat_Z_SetNull( );
            }
            gxTv_SdtLogEmail_Logemailid = value;
            SetDirty("Logemailid");
         }

      }

      [  SoapElement( ElementName = "LogEmailCorpo" )]
      [  XmlElement( ElementName = "LogEmailCorpo"   )]
      public string gxTpr_Logemailcorpo
      {
         get {
            return gxTv_SdtLogEmail_Logemailcorpo ;
         }

         set {
            gxTv_SdtLogEmail_Logemailcorpo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtLogEmail_Logemailcorpo = value;
            SetDirty("Logemailcorpo");
         }

      }

      public void gxTv_SdtLogEmail_Logemailcorpo_SetNull( )
      {
         gxTv_SdtLogEmail_Logemailcorpo_N = 1;
         gxTv_SdtLogEmail_Logemailcorpo = "";
         SetDirty("Logemailcorpo");
         return  ;
      }

      public bool gxTv_SdtLogEmail_Logemailcorpo_IsNull( )
      {
         return (gxTv_SdtLogEmail_Logemailcorpo_N==1) ;
      }

      [  SoapElement( ElementName = "LogEmailSubject" )]
      [  XmlElement( ElementName = "LogEmailSubject"   )]
      public string gxTpr_Logemailsubject
      {
         get {
            return gxTv_SdtLogEmail_Logemailsubject ;
         }

         set {
            gxTv_SdtLogEmail_Logemailsubject_N = 0;
            sdtIsNull = 0;
            gxTv_SdtLogEmail_Logemailsubject = value;
            SetDirty("Logemailsubject");
         }

      }

      public void gxTv_SdtLogEmail_Logemailsubject_SetNull( )
      {
         gxTv_SdtLogEmail_Logemailsubject_N = 1;
         gxTv_SdtLogEmail_Logemailsubject = "";
         SetDirty("Logemailsubject");
         return  ;
      }

      public bool gxTv_SdtLogEmail_Logemailsubject_IsNull( )
      {
         return (gxTv_SdtLogEmail_Logemailsubject_N==1) ;
      }

      [  SoapElement( ElementName = "LogEmailDestinatario" )]
      [  XmlElement( ElementName = "LogEmailDestinatario"   )]
      public string gxTpr_Logemaildestinatario
      {
         get {
            return gxTv_SdtLogEmail_Logemaildestinatario ;
         }

         set {
            gxTv_SdtLogEmail_Logemaildestinatario_N = 0;
            sdtIsNull = 0;
            gxTv_SdtLogEmail_Logemaildestinatario = value;
            SetDirty("Logemaildestinatario");
         }

      }

      public void gxTv_SdtLogEmail_Logemaildestinatario_SetNull( )
      {
         gxTv_SdtLogEmail_Logemaildestinatario_N = 1;
         gxTv_SdtLogEmail_Logemaildestinatario = "";
         SetDirty("Logemaildestinatario");
         return  ;
      }

      public bool gxTv_SdtLogEmail_Logemaildestinatario_IsNull( )
      {
         return (gxTv_SdtLogEmail_Logemaildestinatario_N==1) ;
      }

      [  SoapElement( ElementName = "LogEmailCreatedAt" )]
      [  XmlElement( ElementName = "LogEmailCreatedAt"  , IsNullable=true )]
      public string gxTpr_Logemailcreatedat_Nullable
      {
         get {
            if ( gxTv_SdtLogEmail_Logemailcreatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtLogEmail_Logemailcreatedat).value ;
         }

         set {
            gxTv_SdtLogEmail_Logemailcreatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtLogEmail_Logemailcreatedat = DateTime.MinValue;
            else
               gxTv_SdtLogEmail_Logemailcreatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Logemailcreatedat
      {
         get {
            return gxTv_SdtLogEmail_Logemailcreatedat ;
         }

         set {
            gxTv_SdtLogEmail_Logemailcreatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtLogEmail_Logemailcreatedat = value;
            SetDirty("Logemailcreatedat");
         }

      }

      public void gxTv_SdtLogEmail_Logemailcreatedat_SetNull( )
      {
         gxTv_SdtLogEmail_Logemailcreatedat_N = 1;
         gxTv_SdtLogEmail_Logemailcreatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Logemailcreatedat");
         return  ;
      }

      public bool gxTv_SdtLogEmail_Logemailcreatedat_IsNull( )
      {
         return (gxTv_SdtLogEmail_Logemailcreatedat_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtLogEmail_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLogEmail_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtLogEmail_Mode_SetNull( )
      {
         gxTv_SdtLogEmail_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtLogEmail_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtLogEmail_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLogEmail_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtLogEmail_Initialized_SetNull( )
      {
         gxTv_SdtLogEmail_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtLogEmail_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LogEmailId_Z" )]
      [  XmlElement( ElementName = "LogEmailId_Z"   )]
      public int gxTpr_Logemailid_Z
      {
         get {
            return gxTv_SdtLogEmail_Logemailid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLogEmail_Logemailid_Z = value;
            SetDirty("Logemailid_Z");
         }

      }

      public void gxTv_SdtLogEmail_Logemailid_Z_SetNull( )
      {
         gxTv_SdtLogEmail_Logemailid_Z = 0;
         SetDirty("Logemailid_Z");
         return  ;
      }

      public bool gxTv_SdtLogEmail_Logemailid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LogEmailSubject_Z" )]
      [  XmlElement( ElementName = "LogEmailSubject_Z"   )]
      public string gxTpr_Logemailsubject_Z
      {
         get {
            return gxTv_SdtLogEmail_Logemailsubject_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLogEmail_Logemailsubject_Z = value;
            SetDirty("Logemailsubject_Z");
         }

      }

      public void gxTv_SdtLogEmail_Logemailsubject_Z_SetNull( )
      {
         gxTv_SdtLogEmail_Logemailsubject_Z = "";
         SetDirty("Logemailsubject_Z");
         return  ;
      }

      public bool gxTv_SdtLogEmail_Logemailsubject_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LogEmailDestinatario_Z" )]
      [  XmlElement( ElementName = "LogEmailDestinatario_Z"   )]
      public string gxTpr_Logemaildestinatario_Z
      {
         get {
            return gxTv_SdtLogEmail_Logemaildestinatario_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLogEmail_Logemaildestinatario_Z = value;
            SetDirty("Logemaildestinatario_Z");
         }

      }

      public void gxTv_SdtLogEmail_Logemaildestinatario_Z_SetNull( )
      {
         gxTv_SdtLogEmail_Logemaildestinatario_Z = "";
         SetDirty("Logemaildestinatario_Z");
         return  ;
      }

      public bool gxTv_SdtLogEmail_Logemaildestinatario_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LogEmailCreatedAt_Z" )]
      [  XmlElement( ElementName = "LogEmailCreatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Logemailcreatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtLogEmail_Logemailcreatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtLogEmail_Logemailcreatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtLogEmail_Logemailcreatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtLogEmail_Logemailcreatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Logemailcreatedat_Z
      {
         get {
            return gxTv_SdtLogEmail_Logemailcreatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLogEmail_Logemailcreatedat_Z = value;
            SetDirty("Logemailcreatedat_Z");
         }

      }

      public void gxTv_SdtLogEmail_Logemailcreatedat_Z_SetNull( )
      {
         gxTv_SdtLogEmail_Logemailcreatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Logemailcreatedat_Z");
         return  ;
      }

      public bool gxTv_SdtLogEmail_Logemailcreatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LogEmailCorpo_N" )]
      [  XmlElement( ElementName = "LogEmailCorpo_N"   )]
      public short gxTpr_Logemailcorpo_N
      {
         get {
            return gxTv_SdtLogEmail_Logemailcorpo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLogEmail_Logemailcorpo_N = value;
            SetDirty("Logemailcorpo_N");
         }

      }

      public void gxTv_SdtLogEmail_Logemailcorpo_N_SetNull( )
      {
         gxTv_SdtLogEmail_Logemailcorpo_N = 0;
         SetDirty("Logemailcorpo_N");
         return  ;
      }

      public bool gxTv_SdtLogEmail_Logemailcorpo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LogEmailSubject_N" )]
      [  XmlElement( ElementName = "LogEmailSubject_N"   )]
      public short gxTpr_Logemailsubject_N
      {
         get {
            return gxTv_SdtLogEmail_Logemailsubject_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLogEmail_Logemailsubject_N = value;
            SetDirty("Logemailsubject_N");
         }

      }

      public void gxTv_SdtLogEmail_Logemailsubject_N_SetNull( )
      {
         gxTv_SdtLogEmail_Logemailsubject_N = 0;
         SetDirty("Logemailsubject_N");
         return  ;
      }

      public bool gxTv_SdtLogEmail_Logemailsubject_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LogEmailDestinatario_N" )]
      [  XmlElement( ElementName = "LogEmailDestinatario_N"   )]
      public short gxTpr_Logemaildestinatario_N
      {
         get {
            return gxTv_SdtLogEmail_Logemaildestinatario_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLogEmail_Logemaildestinatario_N = value;
            SetDirty("Logemaildestinatario_N");
         }

      }

      public void gxTv_SdtLogEmail_Logemaildestinatario_N_SetNull( )
      {
         gxTv_SdtLogEmail_Logemaildestinatario_N = 0;
         SetDirty("Logemaildestinatario_N");
         return  ;
      }

      public bool gxTv_SdtLogEmail_Logemaildestinatario_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LogEmailCreatedAt_N" )]
      [  XmlElement( ElementName = "LogEmailCreatedAt_N"   )]
      public short gxTpr_Logemailcreatedat_N
      {
         get {
            return gxTv_SdtLogEmail_Logemailcreatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLogEmail_Logemailcreatedat_N = value;
            SetDirty("Logemailcreatedat_N");
         }

      }

      public void gxTv_SdtLogEmail_Logemailcreatedat_N_SetNull( )
      {
         gxTv_SdtLogEmail_Logemailcreatedat_N = 0;
         SetDirty("Logemailcreatedat_N");
         return  ;
      }

      public bool gxTv_SdtLogEmail_Logemailcreatedat_N_IsNull( )
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
         gxTv_SdtLogEmail_Logemailcorpo = "";
         gxTv_SdtLogEmail_Logemailsubject = "";
         gxTv_SdtLogEmail_Logemaildestinatario = "";
         gxTv_SdtLogEmail_Logemailcreatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtLogEmail_Mode = "";
         gxTv_SdtLogEmail_Logemailsubject_Z = "";
         gxTv_SdtLogEmail_Logemaildestinatario_Z = "";
         gxTv_SdtLogEmail_Logemailcreatedat_Z = (DateTime)(DateTime.MinValue);
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "logemail", "GeneXus.Programs.logemail_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtLogEmail_Initialized ;
      private short gxTv_SdtLogEmail_Logemailcorpo_N ;
      private short gxTv_SdtLogEmail_Logemailsubject_N ;
      private short gxTv_SdtLogEmail_Logemaildestinatario_N ;
      private short gxTv_SdtLogEmail_Logemailcreatedat_N ;
      private int gxTv_SdtLogEmail_Logemailid ;
      private int gxTv_SdtLogEmail_Logemailid_Z ;
      private string gxTv_SdtLogEmail_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtLogEmail_Logemailcreatedat ;
      private DateTime gxTv_SdtLogEmail_Logemailcreatedat_Z ;
      private DateTime datetime_STZ ;
      private string gxTv_SdtLogEmail_Logemailcorpo ;
      private string gxTv_SdtLogEmail_Logemailsubject ;
      private string gxTv_SdtLogEmail_Logemaildestinatario ;
      private string gxTv_SdtLogEmail_Logemailsubject_Z ;
      private string gxTv_SdtLogEmail_Logemaildestinatario_Z ;
   }

   [DataContract(Name = @"LogEmail", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtLogEmail_RESTInterface : GxGenericCollectionItem<SdtLogEmail>
   {
      public SdtLogEmail_RESTInterface( ) : base()
      {
      }

      public SdtLogEmail_RESTInterface( SdtLogEmail psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "LogEmailId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Logemailid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Logemailid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Logemailid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "LogEmailCorpo" , Order = 1 )]
      public string gxTpr_Logemailcorpo
      {
         get {
            return sdt.gxTpr_Logemailcorpo ;
         }

         set {
            sdt.gxTpr_Logemailcorpo = value;
         }

      }

      [DataMember( Name = "LogEmailSubject" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Logemailsubject
      {
         get {
            return sdt.gxTpr_Logemailsubject ;
         }

         set {
            sdt.gxTpr_Logemailsubject = value;
         }

      }

      [DataMember( Name = "LogEmailDestinatario" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Logemaildestinatario
      {
         get {
            return sdt.gxTpr_Logemaildestinatario ;
         }

         set {
            sdt.gxTpr_Logemaildestinatario = value;
         }

      }

      [DataMember( Name = "LogEmailCreatedAt" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Logemailcreatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Logemailcreatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Logemailcreatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      public SdtLogEmail sdt
      {
         get {
            return (SdtLogEmail)Sdt ;
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
            sdt = new SdtLogEmail() ;
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

   [DataContract(Name = @"LogEmail", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtLogEmail_RESTLInterface : GxGenericCollectionItem<SdtLogEmail>
   {
      public SdtLogEmail_RESTLInterface( ) : base()
      {
      }

      public SdtLogEmail_RESTLInterface( SdtLogEmail psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "LogEmailSubject" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Logemailsubject
      {
         get {
            return sdt.gxTpr_Logemailsubject ;
         }

         set {
            sdt.gxTpr_Logemailsubject = value;
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

      public SdtLogEmail sdt
      {
         get {
            return (SdtLogEmail)Sdt ;
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
            sdt = new SdtLogEmail() ;
         }
      }

   }

}
