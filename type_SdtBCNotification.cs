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
   [XmlRoot(ElementName = "BCNotification" )]
   [XmlType(TypeName =  "BCNotification" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtBCNotification : GxSilentTrnSdt
   {
      public SdtBCNotification( )
      {
      }

      public SdtBCNotification( IGxContext context )
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

      public void Load( int AV381NotificationId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV381NotificationId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"NotificationId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "BCNotification");
         metadata.Set("BT", "Notification");
         metadata.Set("PK", "[ \"NotificationId\" ]");
         metadata.Set("PKAssigned", "[ \"NotificationId\" ]");
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
         state.Add("gxTpr_Notificationid_Z");
         state.Add("gxTpr_Notificationtitle_Z");
         state.Add("gxTpr_Notificationmessage_Z");
         state.Add("gxTpr_Notificationtype_Z");
         state.Add("gxTpr_Notificationcreatedat_Z_Nullable");
         state.Add("gxTpr_Notificationstatus_Z");
         state.Add("gxTpr_Secuserid_Z");
         state.Add("gxTpr_Notificationlink_Z");
         state.Add("gxTpr_Notificationid_N");
         state.Add("gxTpr_Notificationtitle_N");
         state.Add("gxTpr_Notificationmessage_N");
         state.Add("gxTpr_Notificationtype_N");
         state.Add("gxTpr_Notificationcreatedat_N");
         state.Add("gxTpr_Notificationstatus_N");
         state.Add("gxTpr_Secuserid_N");
         state.Add("gxTpr_Notificationlink_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtBCNotification sdt;
         sdt = (SdtBCNotification)(source);
         gxTv_SdtBCNotification_Notificationid = sdt.gxTv_SdtBCNotification_Notificationid ;
         gxTv_SdtBCNotification_Notificationtitle = sdt.gxTv_SdtBCNotification_Notificationtitle ;
         gxTv_SdtBCNotification_Notificationmessage = sdt.gxTv_SdtBCNotification_Notificationmessage ;
         gxTv_SdtBCNotification_Notificationtype = sdt.gxTv_SdtBCNotification_Notificationtype ;
         gxTv_SdtBCNotification_Notificationcreatedat = sdt.gxTv_SdtBCNotification_Notificationcreatedat ;
         gxTv_SdtBCNotification_Notificationstatus = sdt.gxTv_SdtBCNotification_Notificationstatus ;
         gxTv_SdtBCNotification_Secuserid = sdt.gxTv_SdtBCNotification_Secuserid ;
         gxTv_SdtBCNotification_Notificationlink = sdt.gxTv_SdtBCNotification_Notificationlink ;
         gxTv_SdtBCNotification_Mode = sdt.gxTv_SdtBCNotification_Mode ;
         gxTv_SdtBCNotification_Initialized = sdt.gxTv_SdtBCNotification_Initialized ;
         gxTv_SdtBCNotification_Notificationid_Z = sdt.gxTv_SdtBCNotification_Notificationid_Z ;
         gxTv_SdtBCNotification_Notificationtitle_Z = sdt.gxTv_SdtBCNotification_Notificationtitle_Z ;
         gxTv_SdtBCNotification_Notificationmessage_Z = sdt.gxTv_SdtBCNotification_Notificationmessage_Z ;
         gxTv_SdtBCNotification_Notificationtype_Z = sdt.gxTv_SdtBCNotification_Notificationtype_Z ;
         gxTv_SdtBCNotification_Notificationcreatedat_Z = sdt.gxTv_SdtBCNotification_Notificationcreatedat_Z ;
         gxTv_SdtBCNotification_Notificationstatus_Z = sdt.gxTv_SdtBCNotification_Notificationstatus_Z ;
         gxTv_SdtBCNotification_Secuserid_Z = sdt.gxTv_SdtBCNotification_Secuserid_Z ;
         gxTv_SdtBCNotification_Notificationlink_Z = sdt.gxTv_SdtBCNotification_Notificationlink_Z ;
         gxTv_SdtBCNotification_Notificationid_N = sdt.gxTv_SdtBCNotification_Notificationid_N ;
         gxTv_SdtBCNotification_Notificationtitle_N = sdt.gxTv_SdtBCNotification_Notificationtitle_N ;
         gxTv_SdtBCNotification_Notificationmessage_N = sdt.gxTv_SdtBCNotification_Notificationmessage_N ;
         gxTv_SdtBCNotification_Notificationtype_N = sdt.gxTv_SdtBCNotification_Notificationtype_N ;
         gxTv_SdtBCNotification_Notificationcreatedat_N = sdt.gxTv_SdtBCNotification_Notificationcreatedat_N ;
         gxTv_SdtBCNotification_Notificationstatus_N = sdt.gxTv_SdtBCNotification_Notificationstatus_N ;
         gxTv_SdtBCNotification_Secuserid_N = sdt.gxTv_SdtBCNotification_Secuserid_N ;
         gxTv_SdtBCNotification_Notificationlink_N = sdt.gxTv_SdtBCNotification_Notificationlink_N ;
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
         AddObjectProperty("NotificationId", gxTv_SdtBCNotification_Notificationid, false, includeNonInitialized);
         AddObjectProperty("NotificationId_N", gxTv_SdtBCNotification_Notificationid_N, false, includeNonInitialized);
         AddObjectProperty("NotificationTitle", gxTv_SdtBCNotification_Notificationtitle, false, includeNonInitialized);
         AddObjectProperty("NotificationTitle_N", gxTv_SdtBCNotification_Notificationtitle_N, false, includeNonInitialized);
         AddObjectProperty("NotificationMessage", gxTv_SdtBCNotification_Notificationmessage, false, includeNonInitialized);
         AddObjectProperty("NotificationMessage_N", gxTv_SdtBCNotification_Notificationmessage_N, false, includeNonInitialized);
         AddObjectProperty("NotificationType", gxTv_SdtBCNotification_Notificationtype, false, includeNonInitialized);
         AddObjectProperty("NotificationType_N", gxTv_SdtBCNotification_Notificationtype_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtBCNotification_Notificationcreatedat;
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
         AddObjectProperty("NotificationCreatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("NotificationCreatedAt_N", gxTv_SdtBCNotification_Notificationcreatedat_N, false, includeNonInitialized);
         AddObjectProperty("NotificationStatus", gxTv_SdtBCNotification_Notificationstatus, false, includeNonInitialized);
         AddObjectProperty("NotificationStatus_N", gxTv_SdtBCNotification_Notificationstatus_N, false, includeNonInitialized);
         AddObjectProperty("SecUserId", gxTv_SdtBCNotification_Secuserid, false, includeNonInitialized);
         AddObjectProperty("SecUserId_N", gxTv_SdtBCNotification_Secuserid_N, false, includeNonInitialized);
         AddObjectProperty("NotificationLink", gxTv_SdtBCNotification_Notificationlink, false, includeNonInitialized);
         AddObjectProperty("NotificationLink_N", gxTv_SdtBCNotification_Notificationlink_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtBCNotification_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtBCNotification_Initialized, false, includeNonInitialized);
            AddObjectProperty("NotificationId_Z", gxTv_SdtBCNotification_Notificationid_Z, false, includeNonInitialized);
            AddObjectProperty("NotificationTitle_Z", gxTv_SdtBCNotification_Notificationtitle_Z, false, includeNonInitialized);
            AddObjectProperty("NotificationMessage_Z", gxTv_SdtBCNotification_Notificationmessage_Z, false, includeNonInitialized);
            AddObjectProperty("NotificationType_Z", gxTv_SdtBCNotification_Notificationtype_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtBCNotification_Notificationcreatedat_Z;
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
            AddObjectProperty("NotificationCreatedAt_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("NotificationStatus_Z", gxTv_SdtBCNotification_Notificationstatus_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserId_Z", gxTv_SdtBCNotification_Secuserid_Z, false, includeNonInitialized);
            AddObjectProperty("NotificationLink_Z", gxTv_SdtBCNotification_Notificationlink_Z, false, includeNonInitialized);
            AddObjectProperty("NotificationId_N", gxTv_SdtBCNotification_Notificationid_N, false, includeNonInitialized);
            AddObjectProperty("NotificationTitle_N", gxTv_SdtBCNotification_Notificationtitle_N, false, includeNonInitialized);
            AddObjectProperty("NotificationMessage_N", gxTv_SdtBCNotification_Notificationmessage_N, false, includeNonInitialized);
            AddObjectProperty("NotificationType_N", gxTv_SdtBCNotification_Notificationtype_N, false, includeNonInitialized);
            AddObjectProperty("NotificationCreatedAt_N", gxTv_SdtBCNotification_Notificationcreatedat_N, false, includeNonInitialized);
            AddObjectProperty("NotificationStatus_N", gxTv_SdtBCNotification_Notificationstatus_N, false, includeNonInitialized);
            AddObjectProperty("SecUserId_N", gxTv_SdtBCNotification_Secuserid_N, false, includeNonInitialized);
            AddObjectProperty("NotificationLink_N", gxTv_SdtBCNotification_Notificationlink_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtBCNotification sdt )
      {
         if ( sdt.IsDirty("NotificationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtBCNotification_Notificationid = sdt.gxTv_SdtBCNotification_Notificationid ;
         }
         if ( sdt.IsDirty("NotificationTitle") )
         {
            gxTv_SdtBCNotification_Notificationtitle_N = (short)(sdt.gxTv_SdtBCNotification_Notificationtitle_N);
            sdtIsNull = 0;
            gxTv_SdtBCNotification_Notificationtitle = sdt.gxTv_SdtBCNotification_Notificationtitle ;
         }
         if ( sdt.IsDirty("NotificationMessage") )
         {
            gxTv_SdtBCNotification_Notificationmessage_N = (short)(sdt.gxTv_SdtBCNotification_Notificationmessage_N);
            sdtIsNull = 0;
            gxTv_SdtBCNotification_Notificationmessage = sdt.gxTv_SdtBCNotification_Notificationmessage ;
         }
         if ( sdt.IsDirty("NotificationType") )
         {
            gxTv_SdtBCNotification_Notificationtype_N = (short)(sdt.gxTv_SdtBCNotification_Notificationtype_N);
            sdtIsNull = 0;
            gxTv_SdtBCNotification_Notificationtype = sdt.gxTv_SdtBCNotification_Notificationtype ;
         }
         if ( sdt.IsDirty("NotificationCreatedAt") )
         {
            gxTv_SdtBCNotification_Notificationcreatedat_N = (short)(sdt.gxTv_SdtBCNotification_Notificationcreatedat_N);
            sdtIsNull = 0;
            gxTv_SdtBCNotification_Notificationcreatedat = sdt.gxTv_SdtBCNotification_Notificationcreatedat ;
         }
         if ( sdt.IsDirty("NotificationStatus") )
         {
            gxTv_SdtBCNotification_Notificationstatus_N = (short)(sdt.gxTv_SdtBCNotification_Notificationstatus_N);
            sdtIsNull = 0;
            gxTv_SdtBCNotification_Notificationstatus = sdt.gxTv_SdtBCNotification_Notificationstatus ;
         }
         if ( sdt.IsDirty("SecUserId") )
         {
            gxTv_SdtBCNotification_Secuserid_N = (short)(sdt.gxTv_SdtBCNotification_Secuserid_N);
            sdtIsNull = 0;
            gxTv_SdtBCNotification_Secuserid = sdt.gxTv_SdtBCNotification_Secuserid ;
         }
         if ( sdt.IsDirty("NotificationLink") )
         {
            gxTv_SdtBCNotification_Notificationlink_N = (short)(sdt.gxTv_SdtBCNotification_Notificationlink_N);
            sdtIsNull = 0;
            gxTv_SdtBCNotification_Notificationlink = sdt.gxTv_SdtBCNotification_Notificationlink ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "NotificationId" )]
      [  XmlElement( ElementName = "NotificationId"   )]
      public int gxTpr_Notificationid
      {
         get {
            return gxTv_SdtBCNotification_Notificationid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtBCNotification_Notificationid != value )
            {
               gxTv_SdtBCNotification_Mode = "INS";
               this.gxTv_SdtBCNotification_Notificationid_Z_SetNull( );
               this.gxTv_SdtBCNotification_Notificationtitle_Z_SetNull( );
               this.gxTv_SdtBCNotification_Notificationmessage_Z_SetNull( );
               this.gxTv_SdtBCNotification_Notificationtype_Z_SetNull( );
               this.gxTv_SdtBCNotification_Notificationcreatedat_Z_SetNull( );
               this.gxTv_SdtBCNotification_Notificationstatus_Z_SetNull( );
               this.gxTv_SdtBCNotification_Secuserid_Z_SetNull( );
               this.gxTv_SdtBCNotification_Notificationlink_Z_SetNull( );
            }
            gxTv_SdtBCNotification_Notificationid = value;
            SetDirty("Notificationid");
         }

      }

      [  SoapElement( ElementName = "NotificationTitle" )]
      [  XmlElement( ElementName = "NotificationTitle"   )]
      public string gxTpr_Notificationtitle
      {
         get {
            return gxTv_SdtBCNotification_Notificationtitle ;
         }

         set {
            gxTv_SdtBCNotification_Notificationtitle_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBCNotification_Notificationtitle = value;
            SetDirty("Notificationtitle");
         }

      }

      public void gxTv_SdtBCNotification_Notificationtitle_SetNull( )
      {
         gxTv_SdtBCNotification_Notificationtitle_N = 1;
         gxTv_SdtBCNotification_Notificationtitle = "";
         SetDirty("Notificationtitle");
         return  ;
      }

      public bool gxTv_SdtBCNotification_Notificationtitle_IsNull( )
      {
         return (gxTv_SdtBCNotification_Notificationtitle_N==1) ;
      }

      [  SoapElement( ElementName = "NotificationMessage" )]
      [  XmlElement( ElementName = "NotificationMessage"   )]
      public string gxTpr_Notificationmessage
      {
         get {
            return gxTv_SdtBCNotification_Notificationmessage ;
         }

         set {
            gxTv_SdtBCNotification_Notificationmessage_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBCNotification_Notificationmessage = value;
            SetDirty("Notificationmessage");
         }

      }

      public void gxTv_SdtBCNotification_Notificationmessage_SetNull( )
      {
         gxTv_SdtBCNotification_Notificationmessage_N = 1;
         gxTv_SdtBCNotification_Notificationmessage = "";
         SetDirty("Notificationmessage");
         return  ;
      }

      public bool gxTv_SdtBCNotification_Notificationmessage_IsNull( )
      {
         return (gxTv_SdtBCNotification_Notificationmessage_N==1) ;
      }

      [  SoapElement( ElementName = "NotificationType" )]
      [  XmlElement( ElementName = "NotificationType"   )]
      public string gxTpr_Notificationtype
      {
         get {
            return gxTv_SdtBCNotification_Notificationtype ;
         }

         set {
            gxTv_SdtBCNotification_Notificationtype_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBCNotification_Notificationtype = value;
            SetDirty("Notificationtype");
         }

      }

      public void gxTv_SdtBCNotification_Notificationtype_SetNull( )
      {
         gxTv_SdtBCNotification_Notificationtype_N = 1;
         gxTv_SdtBCNotification_Notificationtype = "";
         SetDirty("Notificationtype");
         return  ;
      }

      public bool gxTv_SdtBCNotification_Notificationtype_IsNull( )
      {
         return (gxTv_SdtBCNotification_Notificationtype_N==1) ;
      }

      [  SoapElement( ElementName = "NotificationCreatedAt" )]
      [  XmlElement( ElementName = "NotificationCreatedAt"  , IsNullable=true )]
      public string gxTpr_Notificationcreatedat_Nullable
      {
         get {
            if ( gxTv_SdtBCNotification_Notificationcreatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtBCNotification_Notificationcreatedat).value ;
         }

         set {
            gxTv_SdtBCNotification_Notificationcreatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtBCNotification_Notificationcreatedat = DateTime.MinValue;
            else
               gxTv_SdtBCNotification_Notificationcreatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Notificationcreatedat
      {
         get {
            return gxTv_SdtBCNotification_Notificationcreatedat ;
         }

         set {
            gxTv_SdtBCNotification_Notificationcreatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBCNotification_Notificationcreatedat = value;
            SetDirty("Notificationcreatedat");
         }

      }

      public void gxTv_SdtBCNotification_Notificationcreatedat_SetNull( )
      {
         gxTv_SdtBCNotification_Notificationcreatedat_N = 1;
         gxTv_SdtBCNotification_Notificationcreatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Notificationcreatedat");
         return  ;
      }

      public bool gxTv_SdtBCNotification_Notificationcreatedat_IsNull( )
      {
         return (gxTv_SdtBCNotification_Notificationcreatedat_N==1) ;
      }

      [  SoapElement( ElementName = "NotificationStatus" )]
      [  XmlElement( ElementName = "NotificationStatus"   )]
      public string gxTpr_Notificationstatus
      {
         get {
            return gxTv_SdtBCNotification_Notificationstatus ;
         }

         set {
            gxTv_SdtBCNotification_Notificationstatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBCNotification_Notificationstatus = value;
            SetDirty("Notificationstatus");
         }

      }

      public void gxTv_SdtBCNotification_Notificationstatus_SetNull( )
      {
         gxTv_SdtBCNotification_Notificationstatus_N = 1;
         gxTv_SdtBCNotification_Notificationstatus = "";
         SetDirty("Notificationstatus");
         return  ;
      }

      public bool gxTv_SdtBCNotification_Notificationstatus_IsNull( )
      {
         return (gxTv_SdtBCNotification_Notificationstatus_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserId" )]
      [  XmlElement( ElementName = "SecUserId"   )]
      public short gxTpr_Secuserid
      {
         get {
            return gxTv_SdtBCNotification_Secuserid ;
         }

         set {
            gxTv_SdtBCNotification_Secuserid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBCNotification_Secuserid = value;
            SetDirty("Secuserid");
         }

      }

      public void gxTv_SdtBCNotification_Secuserid_SetNull( )
      {
         gxTv_SdtBCNotification_Secuserid_N = 1;
         gxTv_SdtBCNotification_Secuserid = 0;
         SetDirty("Secuserid");
         return  ;
      }

      public bool gxTv_SdtBCNotification_Secuserid_IsNull( )
      {
         return (gxTv_SdtBCNotification_Secuserid_N==1) ;
      }

      [  SoapElement( ElementName = "NotificationLink" )]
      [  XmlElement( ElementName = "NotificationLink"   )]
      public string gxTpr_Notificationlink
      {
         get {
            return gxTv_SdtBCNotification_Notificationlink ;
         }

         set {
            gxTv_SdtBCNotification_Notificationlink_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBCNotification_Notificationlink = value;
            SetDirty("Notificationlink");
         }

      }

      public void gxTv_SdtBCNotification_Notificationlink_SetNull( )
      {
         gxTv_SdtBCNotification_Notificationlink_N = 1;
         gxTv_SdtBCNotification_Notificationlink = "";
         SetDirty("Notificationlink");
         return  ;
      }

      public bool gxTv_SdtBCNotification_Notificationlink_IsNull( )
      {
         return (gxTv_SdtBCNotification_Notificationlink_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtBCNotification_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBCNotification_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtBCNotification_Mode_SetNull( )
      {
         gxTv_SdtBCNotification_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtBCNotification_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtBCNotification_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBCNotification_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtBCNotification_Initialized_SetNull( )
      {
         gxTv_SdtBCNotification_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtBCNotification_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificationId_Z" )]
      [  XmlElement( ElementName = "NotificationId_Z"   )]
      public int gxTpr_Notificationid_Z
      {
         get {
            return gxTv_SdtBCNotification_Notificationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBCNotification_Notificationid_Z = value;
            SetDirty("Notificationid_Z");
         }

      }

      public void gxTv_SdtBCNotification_Notificationid_Z_SetNull( )
      {
         gxTv_SdtBCNotification_Notificationid_Z = 0;
         SetDirty("Notificationid_Z");
         return  ;
      }

      public bool gxTv_SdtBCNotification_Notificationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificationTitle_Z" )]
      [  XmlElement( ElementName = "NotificationTitle_Z"   )]
      public string gxTpr_Notificationtitle_Z
      {
         get {
            return gxTv_SdtBCNotification_Notificationtitle_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBCNotification_Notificationtitle_Z = value;
            SetDirty("Notificationtitle_Z");
         }

      }

      public void gxTv_SdtBCNotification_Notificationtitle_Z_SetNull( )
      {
         gxTv_SdtBCNotification_Notificationtitle_Z = "";
         SetDirty("Notificationtitle_Z");
         return  ;
      }

      public bool gxTv_SdtBCNotification_Notificationtitle_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificationMessage_Z" )]
      [  XmlElement( ElementName = "NotificationMessage_Z"   )]
      public string gxTpr_Notificationmessage_Z
      {
         get {
            return gxTv_SdtBCNotification_Notificationmessage_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBCNotification_Notificationmessage_Z = value;
            SetDirty("Notificationmessage_Z");
         }

      }

      public void gxTv_SdtBCNotification_Notificationmessage_Z_SetNull( )
      {
         gxTv_SdtBCNotification_Notificationmessage_Z = "";
         SetDirty("Notificationmessage_Z");
         return  ;
      }

      public bool gxTv_SdtBCNotification_Notificationmessage_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificationType_Z" )]
      [  XmlElement( ElementName = "NotificationType_Z"   )]
      public string gxTpr_Notificationtype_Z
      {
         get {
            return gxTv_SdtBCNotification_Notificationtype_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBCNotification_Notificationtype_Z = value;
            SetDirty("Notificationtype_Z");
         }

      }

      public void gxTv_SdtBCNotification_Notificationtype_Z_SetNull( )
      {
         gxTv_SdtBCNotification_Notificationtype_Z = "";
         SetDirty("Notificationtype_Z");
         return  ;
      }

      public bool gxTv_SdtBCNotification_Notificationtype_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificationCreatedAt_Z" )]
      [  XmlElement( ElementName = "NotificationCreatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Notificationcreatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtBCNotification_Notificationcreatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtBCNotification_Notificationcreatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtBCNotification_Notificationcreatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtBCNotification_Notificationcreatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Notificationcreatedat_Z
      {
         get {
            return gxTv_SdtBCNotification_Notificationcreatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBCNotification_Notificationcreatedat_Z = value;
            SetDirty("Notificationcreatedat_Z");
         }

      }

      public void gxTv_SdtBCNotification_Notificationcreatedat_Z_SetNull( )
      {
         gxTv_SdtBCNotification_Notificationcreatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Notificationcreatedat_Z");
         return  ;
      }

      public bool gxTv_SdtBCNotification_Notificationcreatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificationStatus_Z" )]
      [  XmlElement( ElementName = "NotificationStatus_Z"   )]
      public string gxTpr_Notificationstatus_Z
      {
         get {
            return gxTv_SdtBCNotification_Notificationstatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBCNotification_Notificationstatus_Z = value;
            SetDirty("Notificationstatus_Z");
         }

      }

      public void gxTv_SdtBCNotification_Notificationstatus_Z_SetNull( )
      {
         gxTv_SdtBCNotification_Notificationstatus_Z = "";
         SetDirty("Notificationstatus_Z");
         return  ;
      }

      public bool gxTv_SdtBCNotification_Notificationstatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserId_Z" )]
      [  XmlElement( ElementName = "SecUserId_Z"   )]
      public short gxTpr_Secuserid_Z
      {
         get {
            return gxTv_SdtBCNotification_Secuserid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBCNotification_Secuserid_Z = value;
            SetDirty("Secuserid_Z");
         }

      }

      public void gxTv_SdtBCNotification_Secuserid_Z_SetNull( )
      {
         gxTv_SdtBCNotification_Secuserid_Z = 0;
         SetDirty("Secuserid_Z");
         return  ;
      }

      public bool gxTv_SdtBCNotification_Secuserid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificationLink_Z" )]
      [  XmlElement( ElementName = "NotificationLink_Z"   )]
      public string gxTpr_Notificationlink_Z
      {
         get {
            return gxTv_SdtBCNotification_Notificationlink_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBCNotification_Notificationlink_Z = value;
            SetDirty("Notificationlink_Z");
         }

      }

      public void gxTv_SdtBCNotification_Notificationlink_Z_SetNull( )
      {
         gxTv_SdtBCNotification_Notificationlink_Z = "";
         SetDirty("Notificationlink_Z");
         return  ;
      }

      public bool gxTv_SdtBCNotification_Notificationlink_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificationId_N" )]
      [  XmlElement( ElementName = "NotificationId_N"   )]
      public short gxTpr_Notificationid_N
      {
         get {
            return gxTv_SdtBCNotification_Notificationid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBCNotification_Notificationid_N = value;
            SetDirty("Notificationid_N");
         }

      }

      public void gxTv_SdtBCNotification_Notificationid_N_SetNull( )
      {
         gxTv_SdtBCNotification_Notificationid_N = 0;
         SetDirty("Notificationid_N");
         return  ;
      }

      public bool gxTv_SdtBCNotification_Notificationid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificationTitle_N" )]
      [  XmlElement( ElementName = "NotificationTitle_N"   )]
      public short gxTpr_Notificationtitle_N
      {
         get {
            return gxTv_SdtBCNotification_Notificationtitle_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBCNotification_Notificationtitle_N = value;
            SetDirty("Notificationtitle_N");
         }

      }

      public void gxTv_SdtBCNotification_Notificationtitle_N_SetNull( )
      {
         gxTv_SdtBCNotification_Notificationtitle_N = 0;
         SetDirty("Notificationtitle_N");
         return  ;
      }

      public bool gxTv_SdtBCNotification_Notificationtitle_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificationMessage_N" )]
      [  XmlElement( ElementName = "NotificationMessage_N"   )]
      public short gxTpr_Notificationmessage_N
      {
         get {
            return gxTv_SdtBCNotification_Notificationmessage_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBCNotification_Notificationmessage_N = value;
            SetDirty("Notificationmessage_N");
         }

      }

      public void gxTv_SdtBCNotification_Notificationmessage_N_SetNull( )
      {
         gxTv_SdtBCNotification_Notificationmessage_N = 0;
         SetDirty("Notificationmessage_N");
         return  ;
      }

      public bool gxTv_SdtBCNotification_Notificationmessage_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificationType_N" )]
      [  XmlElement( ElementName = "NotificationType_N"   )]
      public short gxTpr_Notificationtype_N
      {
         get {
            return gxTv_SdtBCNotification_Notificationtype_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBCNotification_Notificationtype_N = value;
            SetDirty("Notificationtype_N");
         }

      }

      public void gxTv_SdtBCNotification_Notificationtype_N_SetNull( )
      {
         gxTv_SdtBCNotification_Notificationtype_N = 0;
         SetDirty("Notificationtype_N");
         return  ;
      }

      public bool gxTv_SdtBCNotification_Notificationtype_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificationCreatedAt_N" )]
      [  XmlElement( ElementName = "NotificationCreatedAt_N"   )]
      public short gxTpr_Notificationcreatedat_N
      {
         get {
            return gxTv_SdtBCNotification_Notificationcreatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBCNotification_Notificationcreatedat_N = value;
            SetDirty("Notificationcreatedat_N");
         }

      }

      public void gxTv_SdtBCNotification_Notificationcreatedat_N_SetNull( )
      {
         gxTv_SdtBCNotification_Notificationcreatedat_N = 0;
         SetDirty("Notificationcreatedat_N");
         return  ;
      }

      public bool gxTv_SdtBCNotification_Notificationcreatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificationStatus_N" )]
      [  XmlElement( ElementName = "NotificationStatus_N"   )]
      public short gxTpr_Notificationstatus_N
      {
         get {
            return gxTv_SdtBCNotification_Notificationstatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBCNotification_Notificationstatus_N = value;
            SetDirty("Notificationstatus_N");
         }

      }

      public void gxTv_SdtBCNotification_Notificationstatus_N_SetNull( )
      {
         gxTv_SdtBCNotification_Notificationstatus_N = 0;
         SetDirty("Notificationstatus_N");
         return  ;
      }

      public bool gxTv_SdtBCNotification_Notificationstatus_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserId_N" )]
      [  XmlElement( ElementName = "SecUserId_N"   )]
      public short gxTpr_Secuserid_N
      {
         get {
            return gxTv_SdtBCNotification_Secuserid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBCNotification_Secuserid_N = value;
            SetDirty("Secuserid_N");
         }

      }

      public void gxTv_SdtBCNotification_Secuserid_N_SetNull( )
      {
         gxTv_SdtBCNotification_Secuserid_N = 0;
         SetDirty("Secuserid_N");
         return  ;
      }

      public bool gxTv_SdtBCNotification_Secuserid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificationLink_N" )]
      [  XmlElement( ElementName = "NotificationLink_N"   )]
      public short gxTpr_Notificationlink_N
      {
         get {
            return gxTv_SdtBCNotification_Notificationlink_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBCNotification_Notificationlink_N = value;
            SetDirty("Notificationlink_N");
         }

      }

      public void gxTv_SdtBCNotification_Notificationlink_N_SetNull( )
      {
         gxTv_SdtBCNotification_Notificationlink_N = 0;
         SetDirty("Notificationlink_N");
         return  ;
      }

      public bool gxTv_SdtBCNotification_Notificationlink_N_IsNull( )
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
         gxTv_SdtBCNotification_Notificationtitle = "";
         gxTv_SdtBCNotification_Notificationmessage = "";
         gxTv_SdtBCNotification_Notificationtype = "";
         gxTv_SdtBCNotification_Notificationcreatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtBCNotification_Notificationstatus = "";
         gxTv_SdtBCNotification_Notificationlink = "";
         gxTv_SdtBCNotification_Mode = "";
         gxTv_SdtBCNotification_Notificationtitle_Z = "";
         gxTv_SdtBCNotification_Notificationmessage_Z = "";
         gxTv_SdtBCNotification_Notificationtype_Z = "";
         gxTv_SdtBCNotification_Notificationcreatedat_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtBCNotification_Notificationstatus_Z = "";
         gxTv_SdtBCNotification_Notificationlink_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "bcnotification", "GeneXus.Programs.bcnotification_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtBCNotification_Secuserid ;
      private short gxTv_SdtBCNotification_Initialized ;
      private short gxTv_SdtBCNotification_Secuserid_Z ;
      private short gxTv_SdtBCNotification_Notificationid_N ;
      private short gxTv_SdtBCNotification_Notificationtitle_N ;
      private short gxTv_SdtBCNotification_Notificationmessage_N ;
      private short gxTv_SdtBCNotification_Notificationtype_N ;
      private short gxTv_SdtBCNotification_Notificationcreatedat_N ;
      private short gxTv_SdtBCNotification_Notificationstatus_N ;
      private short gxTv_SdtBCNotification_Secuserid_N ;
      private short gxTv_SdtBCNotification_Notificationlink_N ;
      private int gxTv_SdtBCNotification_Notificationid ;
      private int gxTv_SdtBCNotification_Notificationid_Z ;
      private string gxTv_SdtBCNotification_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtBCNotification_Notificationcreatedat ;
      private DateTime gxTv_SdtBCNotification_Notificationcreatedat_Z ;
      private DateTime datetime_STZ ;
      private string gxTv_SdtBCNotification_Notificationtitle ;
      private string gxTv_SdtBCNotification_Notificationmessage ;
      private string gxTv_SdtBCNotification_Notificationtype ;
      private string gxTv_SdtBCNotification_Notificationstatus ;
      private string gxTv_SdtBCNotification_Notificationlink ;
      private string gxTv_SdtBCNotification_Notificationtitle_Z ;
      private string gxTv_SdtBCNotification_Notificationmessage_Z ;
      private string gxTv_SdtBCNotification_Notificationtype_Z ;
      private string gxTv_SdtBCNotification_Notificationstatus_Z ;
      private string gxTv_SdtBCNotification_Notificationlink_Z ;
   }

   [DataContract(Name = @"BCNotification", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtBCNotification_RESTInterface : GxGenericCollectionItem<SdtBCNotification>
   {
      public SdtBCNotification_RESTInterface( ) : base()
      {
      }

      public SdtBCNotification_RESTInterface( SdtBCNotification psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "NotificationId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Notificationid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Notificationid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Notificationid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "NotificationTitle" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Notificationtitle
      {
         get {
            return sdt.gxTpr_Notificationtitle ;
         }

         set {
            sdt.gxTpr_Notificationtitle = value;
         }

      }

      [DataMember( Name = "NotificationMessage" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Notificationmessage
      {
         get {
            return sdt.gxTpr_Notificationmessage ;
         }

         set {
            sdt.gxTpr_Notificationmessage = value;
         }

      }

      [DataMember( Name = "NotificationType" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Notificationtype
      {
         get {
            return sdt.gxTpr_Notificationtype ;
         }

         set {
            sdt.gxTpr_Notificationtype = value;
         }

      }

      [DataMember( Name = "NotificationCreatedAt" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Notificationcreatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Notificationcreatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Notificationcreatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "NotificationStatus" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Notificationstatus
      {
         get {
            return sdt.gxTpr_Notificationstatus ;
         }

         set {
            sdt.gxTpr_Notificationstatus = value;
         }

      }

      [DataMember( Name = "SecUserId" , Order = 6 )]
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

      [DataMember( Name = "NotificationLink" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Notificationlink
      {
         get {
            return sdt.gxTpr_Notificationlink ;
         }

         set {
            sdt.gxTpr_Notificationlink = value;
         }

      }

      public SdtBCNotification sdt
      {
         get {
            return (SdtBCNotification)Sdt ;
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
            sdt = new SdtBCNotification() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 8 )]
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

   [DataContract(Name = @"BCNotification", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtBCNotification_RESTLInterface : GxGenericCollectionItem<SdtBCNotification>
   {
      public SdtBCNotification_RESTLInterface( ) : base()
      {
      }

      public SdtBCNotification_RESTLInterface( SdtBCNotification psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "NotificationTitle" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Notificationtitle
      {
         get {
            return sdt.gxTpr_Notificationtitle ;
         }

         set {
            sdt.gxTpr_Notificationtitle = value;
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

      public SdtBCNotification sdt
      {
         get {
            return (SdtBCNotification)Sdt ;
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
            sdt = new SdtBCNotification() ;
         }
      }

   }

}
