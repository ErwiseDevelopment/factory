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
   [XmlRoot(ElementName = "UserNotification" )]
   [XmlType(TypeName =  "UserNotification" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtUserNotification : GxSilentTrnSdt
   {
      public SdtUserNotification( )
      {
      }

      public SdtUserNotification( IGxContext context )
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

      public void Load( int AV387UserNotificationId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV387UserNotificationId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"UserNotificationId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "UserNotification");
         metadata.Set("BT", "UserNotification");
         metadata.Set("PK", "[ \"UserNotificationId\" ]");
         metadata.Set("PKAssigned", "[ \"UserNotificationId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"NotificationId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"SecUserId\" ],\"FKMap\":[ \"UserNotificationUserId-SecUserId\" ] } ]");
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
         state.Add("gxTpr_Usernotificationid_Z");
         state.Add("gxTpr_Notificationid_Z");
         state.Add("gxTpr_Usernotificationuserid_Z");
         state.Add("gxTpr_Usernotificationstatus_Z");
         state.Add("gxTpr_Usernotificationsentat_Z_Nullable");
         state.Add("gxTpr_Usernotificationreadat_Z_Nullable");
         state.Add("gxTpr_Notificationid_N");
         state.Add("gxTpr_Usernotificationuserid_N");
         state.Add("gxTpr_Usernotificationstatus_N");
         state.Add("gxTpr_Usernotificationsentat_N");
         state.Add("gxTpr_Usernotificationreadat_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtUserNotification sdt;
         sdt = (SdtUserNotification)(source);
         gxTv_SdtUserNotification_Usernotificationid = sdt.gxTv_SdtUserNotification_Usernotificationid ;
         gxTv_SdtUserNotification_Notificationid = sdt.gxTv_SdtUserNotification_Notificationid ;
         gxTv_SdtUserNotification_Usernotificationuserid = sdt.gxTv_SdtUserNotification_Usernotificationuserid ;
         gxTv_SdtUserNotification_Usernotificationstatus = sdt.gxTv_SdtUserNotification_Usernotificationstatus ;
         gxTv_SdtUserNotification_Usernotificationsentat = sdt.gxTv_SdtUserNotification_Usernotificationsentat ;
         gxTv_SdtUserNotification_Usernotificationreadat = sdt.gxTv_SdtUserNotification_Usernotificationreadat ;
         gxTv_SdtUserNotification_Mode = sdt.gxTv_SdtUserNotification_Mode ;
         gxTv_SdtUserNotification_Initialized = sdt.gxTv_SdtUserNotification_Initialized ;
         gxTv_SdtUserNotification_Usernotificationid_Z = sdt.gxTv_SdtUserNotification_Usernotificationid_Z ;
         gxTv_SdtUserNotification_Notificationid_Z = sdt.gxTv_SdtUserNotification_Notificationid_Z ;
         gxTv_SdtUserNotification_Usernotificationuserid_Z = sdt.gxTv_SdtUserNotification_Usernotificationuserid_Z ;
         gxTv_SdtUserNotification_Usernotificationstatus_Z = sdt.gxTv_SdtUserNotification_Usernotificationstatus_Z ;
         gxTv_SdtUserNotification_Usernotificationsentat_Z = sdt.gxTv_SdtUserNotification_Usernotificationsentat_Z ;
         gxTv_SdtUserNotification_Usernotificationreadat_Z = sdt.gxTv_SdtUserNotification_Usernotificationreadat_Z ;
         gxTv_SdtUserNotification_Notificationid_N = sdt.gxTv_SdtUserNotification_Notificationid_N ;
         gxTv_SdtUserNotification_Usernotificationuserid_N = sdt.gxTv_SdtUserNotification_Usernotificationuserid_N ;
         gxTv_SdtUserNotification_Usernotificationstatus_N = sdt.gxTv_SdtUserNotification_Usernotificationstatus_N ;
         gxTv_SdtUserNotification_Usernotificationsentat_N = sdt.gxTv_SdtUserNotification_Usernotificationsentat_N ;
         gxTv_SdtUserNotification_Usernotificationreadat_N = sdt.gxTv_SdtUserNotification_Usernotificationreadat_N ;
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
         AddObjectProperty("UserNotificationId", gxTv_SdtUserNotification_Usernotificationid, false, includeNonInitialized);
         AddObjectProperty("NotificationId", gxTv_SdtUserNotification_Notificationid, false, includeNonInitialized);
         AddObjectProperty("NotificationId_N", gxTv_SdtUserNotification_Notificationid_N, false, includeNonInitialized);
         AddObjectProperty("UserNotificationUserId", gxTv_SdtUserNotification_Usernotificationuserid, false, includeNonInitialized);
         AddObjectProperty("UserNotificationUserId_N", gxTv_SdtUserNotification_Usernotificationuserid_N, false, includeNonInitialized);
         AddObjectProperty("UserNotificationStatus", gxTv_SdtUserNotification_Usernotificationstatus, false, includeNonInitialized);
         AddObjectProperty("UserNotificationStatus_N", gxTv_SdtUserNotification_Usernotificationstatus_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtUserNotification_Usernotificationsentat;
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
         AddObjectProperty("UserNotificationSentAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("UserNotificationSentAt_N", gxTv_SdtUserNotification_Usernotificationsentat_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtUserNotification_Usernotificationreadat;
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
         AddObjectProperty("UserNotificationReadAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("UserNotificationReadAt_N", gxTv_SdtUserNotification_Usernotificationreadat_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtUserNotification_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtUserNotification_Initialized, false, includeNonInitialized);
            AddObjectProperty("UserNotificationId_Z", gxTv_SdtUserNotification_Usernotificationid_Z, false, includeNonInitialized);
            AddObjectProperty("NotificationId_Z", gxTv_SdtUserNotification_Notificationid_Z, false, includeNonInitialized);
            AddObjectProperty("UserNotificationUserId_Z", gxTv_SdtUserNotification_Usernotificationuserid_Z, false, includeNonInitialized);
            AddObjectProperty("UserNotificationStatus_Z", gxTv_SdtUserNotification_Usernotificationstatus_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtUserNotification_Usernotificationsentat_Z;
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
            AddObjectProperty("UserNotificationSentAt_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtUserNotification_Usernotificationreadat_Z;
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
            AddObjectProperty("UserNotificationReadAt_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("NotificationId_N", gxTv_SdtUserNotification_Notificationid_N, false, includeNonInitialized);
            AddObjectProperty("UserNotificationUserId_N", gxTv_SdtUserNotification_Usernotificationuserid_N, false, includeNonInitialized);
            AddObjectProperty("UserNotificationStatus_N", gxTv_SdtUserNotification_Usernotificationstatus_N, false, includeNonInitialized);
            AddObjectProperty("UserNotificationSentAt_N", gxTv_SdtUserNotification_Usernotificationsentat_N, false, includeNonInitialized);
            AddObjectProperty("UserNotificationReadAt_N", gxTv_SdtUserNotification_Usernotificationreadat_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtUserNotification sdt )
      {
         if ( sdt.IsDirty("UserNotificationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtUserNotification_Usernotificationid = sdt.gxTv_SdtUserNotification_Usernotificationid ;
         }
         if ( sdt.IsDirty("NotificationId") )
         {
            gxTv_SdtUserNotification_Notificationid_N = (short)(sdt.gxTv_SdtUserNotification_Notificationid_N);
            sdtIsNull = 0;
            gxTv_SdtUserNotification_Notificationid = sdt.gxTv_SdtUserNotification_Notificationid ;
         }
         if ( sdt.IsDirty("UserNotificationUserId") )
         {
            gxTv_SdtUserNotification_Usernotificationuserid_N = (short)(sdt.gxTv_SdtUserNotification_Usernotificationuserid_N);
            sdtIsNull = 0;
            gxTv_SdtUserNotification_Usernotificationuserid = sdt.gxTv_SdtUserNotification_Usernotificationuserid ;
         }
         if ( sdt.IsDirty("UserNotificationStatus") )
         {
            gxTv_SdtUserNotification_Usernotificationstatus_N = (short)(sdt.gxTv_SdtUserNotification_Usernotificationstatus_N);
            sdtIsNull = 0;
            gxTv_SdtUserNotification_Usernotificationstatus = sdt.gxTv_SdtUserNotification_Usernotificationstatus ;
         }
         if ( sdt.IsDirty("UserNotificationSentAt") )
         {
            gxTv_SdtUserNotification_Usernotificationsentat_N = (short)(sdt.gxTv_SdtUserNotification_Usernotificationsentat_N);
            sdtIsNull = 0;
            gxTv_SdtUserNotification_Usernotificationsentat = sdt.gxTv_SdtUserNotification_Usernotificationsentat ;
         }
         if ( sdt.IsDirty("UserNotificationReadAt") )
         {
            gxTv_SdtUserNotification_Usernotificationreadat_N = (short)(sdt.gxTv_SdtUserNotification_Usernotificationreadat_N);
            sdtIsNull = 0;
            gxTv_SdtUserNotification_Usernotificationreadat = sdt.gxTv_SdtUserNotification_Usernotificationreadat ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "UserNotificationId" )]
      [  XmlElement( ElementName = "UserNotificationId"   )]
      public int gxTpr_Usernotificationid
      {
         get {
            return gxTv_SdtUserNotification_Usernotificationid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtUserNotification_Usernotificationid != value )
            {
               gxTv_SdtUserNotification_Mode = "INS";
               this.gxTv_SdtUserNotification_Usernotificationid_Z_SetNull( );
               this.gxTv_SdtUserNotification_Notificationid_Z_SetNull( );
               this.gxTv_SdtUserNotification_Usernotificationuserid_Z_SetNull( );
               this.gxTv_SdtUserNotification_Usernotificationstatus_Z_SetNull( );
               this.gxTv_SdtUserNotification_Usernotificationsentat_Z_SetNull( );
               this.gxTv_SdtUserNotification_Usernotificationreadat_Z_SetNull( );
            }
            gxTv_SdtUserNotification_Usernotificationid = value;
            SetDirty("Usernotificationid");
         }

      }

      [  SoapElement( ElementName = "NotificationId" )]
      [  XmlElement( ElementName = "NotificationId"   )]
      public int gxTpr_Notificationid
      {
         get {
            return gxTv_SdtUserNotification_Notificationid ;
         }

         set {
            gxTv_SdtUserNotification_Notificationid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtUserNotification_Notificationid = value;
            SetDirty("Notificationid");
         }

      }

      public void gxTv_SdtUserNotification_Notificationid_SetNull( )
      {
         gxTv_SdtUserNotification_Notificationid_N = 1;
         gxTv_SdtUserNotification_Notificationid = 0;
         SetDirty("Notificationid");
         return  ;
      }

      public bool gxTv_SdtUserNotification_Notificationid_IsNull( )
      {
         return (gxTv_SdtUserNotification_Notificationid_N==1) ;
      }

      [  SoapElement( ElementName = "UserNotificationUserId" )]
      [  XmlElement( ElementName = "UserNotificationUserId"   )]
      public short gxTpr_Usernotificationuserid
      {
         get {
            return gxTv_SdtUserNotification_Usernotificationuserid ;
         }

         set {
            gxTv_SdtUserNotification_Usernotificationuserid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtUserNotification_Usernotificationuserid = value;
            SetDirty("Usernotificationuserid");
         }

      }

      public void gxTv_SdtUserNotification_Usernotificationuserid_SetNull( )
      {
         gxTv_SdtUserNotification_Usernotificationuserid_N = 1;
         gxTv_SdtUserNotification_Usernotificationuserid = 0;
         SetDirty("Usernotificationuserid");
         return  ;
      }

      public bool gxTv_SdtUserNotification_Usernotificationuserid_IsNull( )
      {
         return (gxTv_SdtUserNotification_Usernotificationuserid_N==1) ;
      }

      [  SoapElement( ElementName = "UserNotificationStatus" )]
      [  XmlElement( ElementName = "UserNotificationStatus"   )]
      public string gxTpr_Usernotificationstatus
      {
         get {
            return gxTv_SdtUserNotification_Usernotificationstatus ;
         }

         set {
            gxTv_SdtUserNotification_Usernotificationstatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtUserNotification_Usernotificationstatus = value;
            SetDirty("Usernotificationstatus");
         }

      }

      public void gxTv_SdtUserNotification_Usernotificationstatus_SetNull( )
      {
         gxTv_SdtUserNotification_Usernotificationstatus_N = 1;
         gxTv_SdtUserNotification_Usernotificationstatus = "";
         SetDirty("Usernotificationstatus");
         return  ;
      }

      public bool gxTv_SdtUserNotification_Usernotificationstatus_IsNull( )
      {
         return (gxTv_SdtUserNotification_Usernotificationstatus_N==1) ;
      }

      [  SoapElement( ElementName = "UserNotificationSentAt" )]
      [  XmlElement( ElementName = "UserNotificationSentAt"  , IsNullable=true )]
      public string gxTpr_Usernotificationsentat_Nullable
      {
         get {
            if ( gxTv_SdtUserNotification_Usernotificationsentat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtUserNotification_Usernotificationsentat).value ;
         }

         set {
            gxTv_SdtUserNotification_Usernotificationsentat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtUserNotification_Usernotificationsentat = DateTime.MinValue;
            else
               gxTv_SdtUserNotification_Usernotificationsentat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Usernotificationsentat
      {
         get {
            return gxTv_SdtUserNotification_Usernotificationsentat ;
         }

         set {
            gxTv_SdtUserNotification_Usernotificationsentat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtUserNotification_Usernotificationsentat = value;
            SetDirty("Usernotificationsentat");
         }

      }

      public void gxTv_SdtUserNotification_Usernotificationsentat_SetNull( )
      {
         gxTv_SdtUserNotification_Usernotificationsentat_N = 1;
         gxTv_SdtUserNotification_Usernotificationsentat = (DateTime)(DateTime.MinValue);
         SetDirty("Usernotificationsentat");
         return  ;
      }

      public bool gxTv_SdtUserNotification_Usernotificationsentat_IsNull( )
      {
         return (gxTv_SdtUserNotification_Usernotificationsentat_N==1) ;
      }

      [  SoapElement( ElementName = "UserNotificationReadAt" )]
      [  XmlElement( ElementName = "UserNotificationReadAt"  , IsNullable=true )]
      public string gxTpr_Usernotificationreadat_Nullable
      {
         get {
            if ( gxTv_SdtUserNotification_Usernotificationreadat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtUserNotification_Usernotificationreadat).value ;
         }

         set {
            gxTv_SdtUserNotification_Usernotificationreadat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtUserNotification_Usernotificationreadat = DateTime.MinValue;
            else
               gxTv_SdtUserNotification_Usernotificationreadat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Usernotificationreadat
      {
         get {
            return gxTv_SdtUserNotification_Usernotificationreadat ;
         }

         set {
            gxTv_SdtUserNotification_Usernotificationreadat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtUserNotification_Usernotificationreadat = value;
            SetDirty("Usernotificationreadat");
         }

      }

      public void gxTv_SdtUserNotification_Usernotificationreadat_SetNull( )
      {
         gxTv_SdtUserNotification_Usernotificationreadat_N = 1;
         gxTv_SdtUserNotification_Usernotificationreadat = (DateTime)(DateTime.MinValue);
         SetDirty("Usernotificationreadat");
         return  ;
      }

      public bool gxTv_SdtUserNotification_Usernotificationreadat_IsNull( )
      {
         return (gxTv_SdtUserNotification_Usernotificationreadat_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtUserNotification_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUserNotification_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtUserNotification_Mode_SetNull( )
      {
         gxTv_SdtUserNotification_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtUserNotification_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtUserNotification_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUserNotification_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtUserNotification_Initialized_SetNull( )
      {
         gxTv_SdtUserNotification_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtUserNotification_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UserNotificationId_Z" )]
      [  XmlElement( ElementName = "UserNotificationId_Z"   )]
      public int gxTpr_Usernotificationid_Z
      {
         get {
            return gxTv_SdtUserNotification_Usernotificationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUserNotification_Usernotificationid_Z = value;
            SetDirty("Usernotificationid_Z");
         }

      }

      public void gxTv_SdtUserNotification_Usernotificationid_Z_SetNull( )
      {
         gxTv_SdtUserNotification_Usernotificationid_Z = 0;
         SetDirty("Usernotificationid_Z");
         return  ;
      }

      public bool gxTv_SdtUserNotification_Usernotificationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificationId_Z" )]
      [  XmlElement( ElementName = "NotificationId_Z"   )]
      public int gxTpr_Notificationid_Z
      {
         get {
            return gxTv_SdtUserNotification_Notificationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUserNotification_Notificationid_Z = value;
            SetDirty("Notificationid_Z");
         }

      }

      public void gxTv_SdtUserNotification_Notificationid_Z_SetNull( )
      {
         gxTv_SdtUserNotification_Notificationid_Z = 0;
         SetDirty("Notificationid_Z");
         return  ;
      }

      public bool gxTv_SdtUserNotification_Notificationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UserNotificationUserId_Z" )]
      [  XmlElement( ElementName = "UserNotificationUserId_Z"   )]
      public short gxTpr_Usernotificationuserid_Z
      {
         get {
            return gxTv_SdtUserNotification_Usernotificationuserid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUserNotification_Usernotificationuserid_Z = value;
            SetDirty("Usernotificationuserid_Z");
         }

      }

      public void gxTv_SdtUserNotification_Usernotificationuserid_Z_SetNull( )
      {
         gxTv_SdtUserNotification_Usernotificationuserid_Z = 0;
         SetDirty("Usernotificationuserid_Z");
         return  ;
      }

      public bool gxTv_SdtUserNotification_Usernotificationuserid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UserNotificationStatus_Z" )]
      [  XmlElement( ElementName = "UserNotificationStatus_Z"   )]
      public string gxTpr_Usernotificationstatus_Z
      {
         get {
            return gxTv_SdtUserNotification_Usernotificationstatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUserNotification_Usernotificationstatus_Z = value;
            SetDirty("Usernotificationstatus_Z");
         }

      }

      public void gxTv_SdtUserNotification_Usernotificationstatus_Z_SetNull( )
      {
         gxTv_SdtUserNotification_Usernotificationstatus_Z = "";
         SetDirty("Usernotificationstatus_Z");
         return  ;
      }

      public bool gxTv_SdtUserNotification_Usernotificationstatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UserNotificationSentAt_Z" )]
      [  XmlElement( ElementName = "UserNotificationSentAt_Z"  , IsNullable=true )]
      public string gxTpr_Usernotificationsentat_Z_Nullable
      {
         get {
            if ( gxTv_SdtUserNotification_Usernotificationsentat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtUserNotification_Usernotificationsentat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtUserNotification_Usernotificationsentat_Z = DateTime.MinValue;
            else
               gxTv_SdtUserNotification_Usernotificationsentat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Usernotificationsentat_Z
      {
         get {
            return gxTv_SdtUserNotification_Usernotificationsentat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUserNotification_Usernotificationsentat_Z = value;
            SetDirty("Usernotificationsentat_Z");
         }

      }

      public void gxTv_SdtUserNotification_Usernotificationsentat_Z_SetNull( )
      {
         gxTv_SdtUserNotification_Usernotificationsentat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Usernotificationsentat_Z");
         return  ;
      }

      public bool gxTv_SdtUserNotification_Usernotificationsentat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UserNotificationReadAt_Z" )]
      [  XmlElement( ElementName = "UserNotificationReadAt_Z"  , IsNullable=true )]
      public string gxTpr_Usernotificationreadat_Z_Nullable
      {
         get {
            if ( gxTv_SdtUserNotification_Usernotificationreadat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtUserNotification_Usernotificationreadat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtUserNotification_Usernotificationreadat_Z = DateTime.MinValue;
            else
               gxTv_SdtUserNotification_Usernotificationreadat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Usernotificationreadat_Z
      {
         get {
            return gxTv_SdtUserNotification_Usernotificationreadat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUserNotification_Usernotificationreadat_Z = value;
            SetDirty("Usernotificationreadat_Z");
         }

      }

      public void gxTv_SdtUserNotification_Usernotificationreadat_Z_SetNull( )
      {
         gxTv_SdtUserNotification_Usernotificationreadat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Usernotificationreadat_Z");
         return  ;
      }

      public bool gxTv_SdtUserNotification_Usernotificationreadat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificationId_N" )]
      [  XmlElement( ElementName = "NotificationId_N"   )]
      public short gxTpr_Notificationid_N
      {
         get {
            return gxTv_SdtUserNotification_Notificationid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUserNotification_Notificationid_N = value;
            SetDirty("Notificationid_N");
         }

      }

      public void gxTv_SdtUserNotification_Notificationid_N_SetNull( )
      {
         gxTv_SdtUserNotification_Notificationid_N = 0;
         SetDirty("Notificationid_N");
         return  ;
      }

      public bool gxTv_SdtUserNotification_Notificationid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UserNotificationUserId_N" )]
      [  XmlElement( ElementName = "UserNotificationUserId_N"   )]
      public short gxTpr_Usernotificationuserid_N
      {
         get {
            return gxTv_SdtUserNotification_Usernotificationuserid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUserNotification_Usernotificationuserid_N = value;
            SetDirty("Usernotificationuserid_N");
         }

      }

      public void gxTv_SdtUserNotification_Usernotificationuserid_N_SetNull( )
      {
         gxTv_SdtUserNotification_Usernotificationuserid_N = 0;
         SetDirty("Usernotificationuserid_N");
         return  ;
      }

      public bool gxTv_SdtUserNotification_Usernotificationuserid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UserNotificationStatus_N" )]
      [  XmlElement( ElementName = "UserNotificationStatus_N"   )]
      public short gxTpr_Usernotificationstatus_N
      {
         get {
            return gxTv_SdtUserNotification_Usernotificationstatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUserNotification_Usernotificationstatus_N = value;
            SetDirty("Usernotificationstatus_N");
         }

      }

      public void gxTv_SdtUserNotification_Usernotificationstatus_N_SetNull( )
      {
         gxTv_SdtUserNotification_Usernotificationstatus_N = 0;
         SetDirty("Usernotificationstatus_N");
         return  ;
      }

      public bool gxTv_SdtUserNotification_Usernotificationstatus_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UserNotificationSentAt_N" )]
      [  XmlElement( ElementName = "UserNotificationSentAt_N"   )]
      public short gxTpr_Usernotificationsentat_N
      {
         get {
            return gxTv_SdtUserNotification_Usernotificationsentat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUserNotification_Usernotificationsentat_N = value;
            SetDirty("Usernotificationsentat_N");
         }

      }

      public void gxTv_SdtUserNotification_Usernotificationsentat_N_SetNull( )
      {
         gxTv_SdtUserNotification_Usernotificationsentat_N = 0;
         SetDirty("Usernotificationsentat_N");
         return  ;
      }

      public bool gxTv_SdtUserNotification_Usernotificationsentat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UserNotificationReadAt_N" )]
      [  XmlElement( ElementName = "UserNotificationReadAt_N"   )]
      public short gxTpr_Usernotificationreadat_N
      {
         get {
            return gxTv_SdtUserNotification_Usernotificationreadat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUserNotification_Usernotificationreadat_N = value;
            SetDirty("Usernotificationreadat_N");
         }

      }

      public void gxTv_SdtUserNotification_Usernotificationreadat_N_SetNull( )
      {
         gxTv_SdtUserNotification_Usernotificationreadat_N = 0;
         SetDirty("Usernotificationreadat_N");
         return  ;
      }

      public bool gxTv_SdtUserNotification_Usernotificationreadat_N_IsNull( )
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
         gxTv_SdtUserNotification_Usernotificationstatus = "";
         gxTv_SdtUserNotification_Usernotificationsentat = (DateTime)(DateTime.MinValue);
         gxTv_SdtUserNotification_Usernotificationreadat = (DateTime)(DateTime.MinValue);
         gxTv_SdtUserNotification_Mode = "";
         gxTv_SdtUserNotification_Usernotificationstatus_Z = "";
         gxTv_SdtUserNotification_Usernotificationsentat_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtUserNotification_Usernotificationreadat_Z = (DateTime)(DateTime.MinValue);
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "usernotification", "GeneXus.Programs.usernotification_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtUserNotification_Usernotificationuserid ;
      private short gxTv_SdtUserNotification_Initialized ;
      private short gxTv_SdtUserNotification_Usernotificationuserid_Z ;
      private short gxTv_SdtUserNotification_Notificationid_N ;
      private short gxTv_SdtUserNotification_Usernotificationuserid_N ;
      private short gxTv_SdtUserNotification_Usernotificationstatus_N ;
      private short gxTv_SdtUserNotification_Usernotificationsentat_N ;
      private short gxTv_SdtUserNotification_Usernotificationreadat_N ;
      private int gxTv_SdtUserNotification_Usernotificationid ;
      private int gxTv_SdtUserNotification_Notificationid ;
      private int gxTv_SdtUserNotification_Usernotificationid_Z ;
      private int gxTv_SdtUserNotification_Notificationid_Z ;
      private string gxTv_SdtUserNotification_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtUserNotification_Usernotificationsentat ;
      private DateTime gxTv_SdtUserNotification_Usernotificationreadat ;
      private DateTime gxTv_SdtUserNotification_Usernotificationsentat_Z ;
      private DateTime gxTv_SdtUserNotification_Usernotificationreadat_Z ;
      private DateTime datetime_STZ ;
      private string gxTv_SdtUserNotification_Usernotificationstatus ;
      private string gxTv_SdtUserNotification_Usernotificationstatus_Z ;
   }

   [DataContract(Name = @"UserNotification", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtUserNotification_RESTInterface : GxGenericCollectionItem<SdtUserNotification>
   {
      public SdtUserNotification_RESTInterface( ) : base()
      {
      }

      public SdtUserNotification_RESTInterface( SdtUserNotification psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "UserNotificationId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Usernotificationid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Usernotificationid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Usernotificationid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "NotificationId" , Order = 1 )]
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

      [DataMember( Name = "UserNotificationUserId" , Order = 2 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Usernotificationuserid
      {
         get {
            return sdt.gxTpr_Usernotificationuserid ;
         }

         set {
            sdt.gxTpr_Usernotificationuserid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "UserNotificationStatus" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Usernotificationstatus
      {
         get {
            return sdt.gxTpr_Usernotificationstatus ;
         }

         set {
            sdt.gxTpr_Usernotificationstatus = value;
         }

      }

      [DataMember( Name = "UserNotificationSentAt" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Usernotificationsentat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Usernotificationsentat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Usernotificationsentat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "UserNotificationReadAt" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Usernotificationreadat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Usernotificationreadat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Usernotificationreadat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      public SdtUserNotification sdt
      {
         get {
            return (SdtUserNotification)Sdt ;
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
            sdt = new SdtUserNotification() ;
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

   [DataContract(Name = @"UserNotification", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtUserNotification_RESTLInterface : GxGenericCollectionItem<SdtUserNotification>
   {
      public SdtUserNotification_RESTLInterface( ) : base()
      {
      }

      public SdtUserNotification_RESTLInterface( SdtUserNotification psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "UserNotificationStatus" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Usernotificationstatus
      {
         get {
            return sdt.gxTpr_Usernotificationstatus ;
         }

         set {
            sdt.gxTpr_Usernotificationstatus = value;
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

      public SdtUserNotification sdt
      {
         get {
            return (SdtUserNotification)Sdt ;
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
            sdt = new SdtUserNotification() ;
         }
      }

   }

}
