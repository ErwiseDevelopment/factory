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
   [XmlRoot(ElementName = "EmailQueue" )]
   [XmlType(TypeName =  "EmailQueue" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtEmailQueue : GxSilentTrnSdt
   {
      public SdtEmailQueue( )
      {
      }

      public SdtEmailQueue( IGxContext context )
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

      public void Load( int AV392EmailQueueId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV392EmailQueueId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"EmailQueueId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "EmailQueue");
         metadata.Set("BT", "EmailQueue");
         metadata.Set("PK", "[ \"EmailQueueId\" ]");
         metadata.Set("PKAssigned", "[ \"EmailQueueId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"NotificationId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Emailqueueid_Z");
         state.Add("gxTpr_Notificationid_Z");
         state.Add("gxTpr_Emailqueuerecipient_Z");
         state.Add("gxTpr_Emailqueuestatus_Z");
         state.Add("gxTpr_Emailqueuesentat_Z_Nullable");
         state.Add("gxTpr_Emailqueueerrormessage_Z");
         state.Add("gxTpr_Notificationid_N");
         state.Add("gxTpr_Emailqueuerecipient_N");
         state.Add("gxTpr_Emailqueuestatus_N");
         state.Add("gxTpr_Emailqueuesentat_N");
         state.Add("gxTpr_Emailqueueerrormessage_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtEmailQueue sdt;
         sdt = (SdtEmailQueue)(source);
         gxTv_SdtEmailQueue_Emailqueueid = sdt.gxTv_SdtEmailQueue_Emailqueueid ;
         gxTv_SdtEmailQueue_Notificationid = sdt.gxTv_SdtEmailQueue_Notificationid ;
         gxTv_SdtEmailQueue_Emailqueuerecipient = sdt.gxTv_SdtEmailQueue_Emailqueuerecipient ;
         gxTv_SdtEmailQueue_Emailqueuestatus = sdt.gxTv_SdtEmailQueue_Emailqueuestatus ;
         gxTv_SdtEmailQueue_Emailqueuesentat = sdt.gxTv_SdtEmailQueue_Emailqueuesentat ;
         gxTv_SdtEmailQueue_Emailqueueerrormessage = sdt.gxTv_SdtEmailQueue_Emailqueueerrormessage ;
         gxTv_SdtEmailQueue_Mode = sdt.gxTv_SdtEmailQueue_Mode ;
         gxTv_SdtEmailQueue_Initialized = sdt.gxTv_SdtEmailQueue_Initialized ;
         gxTv_SdtEmailQueue_Emailqueueid_Z = sdt.gxTv_SdtEmailQueue_Emailqueueid_Z ;
         gxTv_SdtEmailQueue_Notificationid_Z = sdt.gxTv_SdtEmailQueue_Notificationid_Z ;
         gxTv_SdtEmailQueue_Emailqueuerecipient_Z = sdt.gxTv_SdtEmailQueue_Emailqueuerecipient_Z ;
         gxTv_SdtEmailQueue_Emailqueuestatus_Z = sdt.gxTv_SdtEmailQueue_Emailqueuestatus_Z ;
         gxTv_SdtEmailQueue_Emailqueuesentat_Z = sdt.gxTv_SdtEmailQueue_Emailqueuesentat_Z ;
         gxTv_SdtEmailQueue_Emailqueueerrormessage_Z = sdt.gxTv_SdtEmailQueue_Emailqueueerrormessage_Z ;
         gxTv_SdtEmailQueue_Notificationid_N = sdt.gxTv_SdtEmailQueue_Notificationid_N ;
         gxTv_SdtEmailQueue_Emailqueuerecipient_N = sdt.gxTv_SdtEmailQueue_Emailqueuerecipient_N ;
         gxTv_SdtEmailQueue_Emailqueuestatus_N = sdt.gxTv_SdtEmailQueue_Emailqueuestatus_N ;
         gxTv_SdtEmailQueue_Emailqueuesentat_N = sdt.gxTv_SdtEmailQueue_Emailqueuesentat_N ;
         gxTv_SdtEmailQueue_Emailqueueerrormessage_N = sdt.gxTv_SdtEmailQueue_Emailqueueerrormessage_N ;
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
         AddObjectProperty("EmailQueueId", gxTv_SdtEmailQueue_Emailqueueid, false, includeNonInitialized);
         AddObjectProperty("NotificationId", gxTv_SdtEmailQueue_Notificationid, false, includeNonInitialized);
         AddObjectProperty("NotificationId_N", gxTv_SdtEmailQueue_Notificationid_N, false, includeNonInitialized);
         AddObjectProperty("EmailQueueRecipient", gxTv_SdtEmailQueue_Emailqueuerecipient, false, includeNonInitialized);
         AddObjectProperty("EmailQueueRecipient_N", gxTv_SdtEmailQueue_Emailqueuerecipient_N, false, includeNonInitialized);
         AddObjectProperty("EmailQueueStatus", gxTv_SdtEmailQueue_Emailqueuestatus, false, includeNonInitialized);
         AddObjectProperty("EmailQueueStatus_N", gxTv_SdtEmailQueue_Emailqueuestatus_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtEmailQueue_Emailqueuesentat;
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
         AddObjectProperty("EmailQueueSentAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("EmailQueueSentAt_N", gxTv_SdtEmailQueue_Emailqueuesentat_N, false, includeNonInitialized);
         AddObjectProperty("EmailQueueErrorMessage", gxTv_SdtEmailQueue_Emailqueueerrormessage, false, includeNonInitialized);
         AddObjectProperty("EmailQueueErrorMessage_N", gxTv_SdtEmailQueue_Emailqueueerrormessage_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtEmailQueue_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtEmailQueue_Initialized, false, includeNonInitialized);
            AddObjectProperty("EmailQueueId_Z", gxTv_SdtEmailQueue_Emailqueueid_Z, false, includeNonInitialized);
            AddObjectProperty("NotificationId_Z", gxTv_SdtEmailQueue_Notificationid_Z, false, includeNonInitialized);
            AddObjectProperty("EmailQueueRecipient_Z", gxTv_SdtEmailQueue_Emailqueuerecipient_Z, false, includeNonInitialized);
            AddObjectProperty("EmailQueueStatus_Z", gxTv_SdtEmailQueue_Emailqueuestatus_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtEmailQueue_Emailqueuesentat_Z;
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
            AddObjectProperty("EmailQueueSentAt_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("EmailQueueErrorMessage_Z", gxTv_SdtEmailQueue_Emailqueueerrormessage_Z, false, includeNonInitialized);
            AddObjectProperty("NotificationId_N", gxTv_SdtEmailQueue_Notificationid_N, false, includeNonInitialized);
            AddObjectProperty("EmailQueueRecipient_N", gxTv_SdtEmailQueue_Emailqueuerecipient_N, false, includeNonInitialized);
            AddObjectProperty("EmailQueueStatus_N", gxTv_SdtEmailQueue_Emailqueuestatus_N, false, includeNonInitialized);
            AddObjectProperty("EmailQueueSentAt_N", gxTv_SdtEmailQueue_Emailqueuesentat_N, false, includeNonInitialized);
            AddObjectProperty("EmailQueueErrorMessage_N", gxTv_SdtEmailQueue_Emailqueueerrormessage_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtEmailQueue sdt )
      {
         if ( sdt.IsDirty("EmailQueueId") )
         {
            sdtIsNull = 0;
            gxTv_SdtEmailQueue_Emailqueueid = sdt.gxTv_SdtEmailQueue_Emailqueueid ;
         }
         if ( sdt.IsDirty("NotificationId") )
         {
            gxTv_SdtEmailQueue_Notificationid_N = (short)(sdt.gxTv_SdtEmailQueue_Notificationid_N);
            sdtIsNull = 0;
            gxTv_SdtEmailQueue_Notificationid = sdt.gxTv_SdtEmailQueue_Notificationid ;
         }
         if ( sdt.IsDirty("EmailQueueRecipient") )
         {
            gxTv_SdtEmailQueue_Emailqueuerecipient_N = (short)(sdt.gxTv_SdtEmailQueue_Emailqueuerecipient_N);
            sdtIsNull = 0;
            gxTv_SdtEmailQueue_Emailqueuerecipient = sdt.gxTv_SdtEmailQueue_Emailqueuerecipient ;
         }
         if ( sdt.IsDirty("EmailQueueStatus") )
         {
            gxTv_SdtEmailQueue_Emailqueuestatus_N = (short)(sdt.gxTv_SdtEmailQueue_Emailqueuestatus_N);
            sdtIsNull = 0;
            gxTv_SdtEmailQueue_Emailqueuestatus = sdt.gxTv_SdtEmailQueue_Emailqueuestatus ;
         }
         if ( sdt.IsDirty("EmailQueueSentAt") )
         {
            gxTv_SdtEmailQueue_Emailqueuesentat_N = (short)(sdt.gxTv_SdtEmailQueue_Emailqueuesentat_N);
            sdtIsNull = 0;
            gxTv_SdtEmailQueue_Emailqueuesentat = sdt.gxTv_SdtEmailQueue_Emailqueuesentat ;
         }
         if ( sdt.IsDirty("EmailQueueErrorMessage") )
         {
            gxTv_SdtEmailQueue_Emailqueueerrormessage_N = (short)(sdt.gxTv_SdtEmailQueue_Emailqueueerrormessage_N);
            sdtIsNull = 0;
            gxTv_SdtEmailQueue_Emailqueueerrormessage = sdt.gxTv_SdtEmailQueue_Emailqueueerrormessage ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "EmailQueueId" )]
      [  XmlElement( ElementName = "EmailQueueId"   )]
      public int gxTpr_Emailqueueid
      {
         get {
            return gxTv_SdtEmailQueue_Emailqueueid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtEmailQueue_Emailqueueid != value )
            {
               gxTv_SdtEmailQueue_Mode = "INS";
               this.gxTv_SdtEmailQueue_Emailqueueid_Z_SetNull( );
               this.gxTv_SdtEmailQueue_Notificationid_Z_SetNull( );
               this.gxTv_SdtEmailQueue_Emailqueuerecipient_Z_SetNull( );
               this.gxTv_SdtEmailQueue_Emailqueuestatus_Z_SetNull( );
               this.gxTv_SdtEmailQueue_Emailqueuesentat_Z_SetNull( );
               this.gxTv_SdtEmailQueue_Emailqueueerrormessage_Z_SetNull( );
            }
            gxTv_SdtEmailQueue_Emailqueueid = value;
            SetDirty("Emailqueueid");
         }

      }

      [  SoapElement( ElementName = "NotificationId" )]
      [  XmlElement( ElementName = "NotificationId"   )]
      public int gxTpr_Notificationid
      {
         get {
            return gxTv_SdtEmailQueue_Notificationid ;
         }

         set {
            gxTv_SdtEmailQueue_Notificationid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmailQueue_Notificationid = value;
            SetDirty("Notificationid");
         }

      }

      public void gxTv_SdtEmailQueue_Notificationid_SetNull( )
      {
         gxTv_SdtEmailQueue_Notificationid_N = 1;
         gxTv_SdtEmailQueue_Notificationid = 0;
         SetDirty("Notificationid");
         return  ;
      }

      public bool gxTv_SdtEmailQueue_Notificationid_IsNull( )
      {
         return (gxTv_SdtEmailQueue_Notificationid_N==1) ;
      }

      [  SoapElement( ElementName = "EmailQueueRecipient" )]
      [  XmlElement( ElementName = "EmailQueueRecipient"   )]
      public string gxTpr_Emailqueuerecipient
      {
         get {
            return gxTv_SdtEmailQueue_Emailqueuerecipient ;
         }

         set {
            gxTv_SdtEmailQueue_Emailqueuerecipient_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmailQueue_Emailqueuerecipient = value;
            SetDirty("Emailqueuerecipient");
         }

      }

      public void gxTv_SdtEmailQueue_Emailqueuerecipient_SetNull( )
      {
         gxTv_SdtEmailQueue_Emailqueuerecipient_N = 1;
         gxTv_SdtEmailQueue_Emailqueuerecipient = "";
         SetDirty("Emailqueuerecipient");
         return  ;
      }

      public bool gxTv_SdtEmailQueue_Emailqueuerecipient_IsNull( )
      {
         return (gxTv_SdtEmailQueue_Emailqueuerecipient_N==1) ;
      }

      [  SoapElement( ElementName = "EmailQueueStatus" )]
      [  XmlElement( ElementName = "EmailQueueStatus"   )]
      public string gxTpr_Emailqueuestatus
      {
         get {
            return gxTv_SdtEmailQueue_Emailqueuestatus ;
         }

         set {
            gxTv_SdtEmailQueue_Emailqueuestatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmailQueue_Emailqueuestatus = value;
            SetDirty("Emailqueuestatus");
         }

      }

      public void gxTv_SdtEmailQueue_Emailqueuestatus_SetNull( )
      {
         gxTv_SdtEmailQueue_Emailqueuestatus_N = 1;
         gxTv_SdtEmailQueue_Emailqueuestatus = "";
         SetDirty("Emailqueuestatus");
         return  ;
      }

      public bool gxTv_SdtEmailQueue_Emailqueuestatus_IsNull( )
      {
         return (gxTv_SdtEmailQueue_Emailqueuestatus_N==1) ;
      }

      [  SoapElement( ElementName = "EmailQueueSentAt" )]
      [  XmlElement( ElementName = "EmailQueueSentAt"  , IsNullable=true )]
      public string gxTpr_Emailqueuesentat_Nullable
      {
         get {
            if ( gxTv_SdtEmailQueue_Emailqueuesentat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtEmailQueue_Emailqueuesentat).value ;
         }

         set {
            gxTv_SdtEmailQueue_Emailqueuesentat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtEmailQueue_Emailqueuesentat = DateTime.MinValue;
            else
               gxTv_SdtEmailQueue_Emailqueuesentat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Emailqueuesentat
      {
         get {
            return gxTv_SdtEmailQueue_Emailqueuesentat ;
         }

         set {
            gxTv_SdtEmailQueue_Emailqueuesentat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmailQueue_Emailqueuesentat = value;
            SetDirty("Emailqueuesentat");
         }

      }

      public void gxTv_SdtEmailQueue_Emailqueuesentat_SetNull( )
      {
         gxTv_SdtEmailQueue_Emailqueuesentat_N = 1;
         gxTv_SdtEmailQueue_Emailqueuesentat = (DateTime)(DateTime.MinValue);
         SetDirty("Emailqueuesentat");
         return  ;
      }

      public bool gxTv_SdtEmailQueue_Emailqueuesentat_IsNull( )
      {
         return (gxTv_SdtEmailQueue_Emailqueuesentat_N==1) ;
      }

      [  SoapElement( ElementName = "EmailQueueErrorMessage" )]
      [  XmlElement( ElementName = "EmailQueueErrorMessage"   )]
      public string gxTpr_Emailqueueerrormessage
      {
         get {
            return gxTv_SdtEmailQueue_Emailqueueerrormessage ;
         }

         set {
            gxTv_SdtEmailQueue_Emailqueueerrormessage_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEmailQueue_Emailqueueerrormessage = value;
            SetDirty("Emailqueueerrormessage");
         }

      }

      public void gxTv_SdtEmailQueue_Emailqueueerrormessage_SetNull( )
      {
         gxTv_SdtEmailQueue_Emailqueueerrormessage_N = 1;
         gxTv_SdtEmailQueue_Emailqueueerrormessage = "";
         SetDirty("Emailqueueerrormessage");
         return  ;
      }

      public bool gxTv_SdtEmailQueue_Emailqueueerrormessage_IsNull( )
      {
         return (gxTv_SdtEmailQueue_Emailqueueerrormessage_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtEmailQueue_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmailQueue_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtEmailQueue_Mode_SetNull( )
      {
         gxTv_SdtEmailQueue_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtEmailQueue_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtEmailQueue_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmailQueue_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtEmailQueue_Initialized_SetNull( )
      {
         gxTv_SdtEmailQueue_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtEmailQueue_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmailQueueId_Z" )]
      [  XmlElement( ElementName = "EmailQueueId_Z"   )]
      public int gxTpr_Emailqueueid_Z
      {
         get {
            return gxTv_SdtEmailQueue_Emailqueueid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmailQueue_Emailqueueid_Z = value;
            SetDirty("Emailqueueid_Z");
         }

      }

      public void gxTv_SdtEmailQueue_Emailqueueid_Z_SetNull( )
      {
         gxTv_SdtEmailQueue_Emailqueueid_Z = 0;
         SetDirty("Emailqueueid_Z");
         return  ;
      }

      public bool gxTv_SdtEmailQueue_Emailqueueid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificationId_Z" )]
      [  XmlElement( ElementName = "NotificationId_Z"   )]
      public int gxTpr_Notificationid_Z
      {
         get {
            return gxTv_SdtEmailQueue_Notificationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmailQueue_Notificationid_Z = value;
            SetDirty("Notificationid_Z");
         }

      }

      public void gxTv_SdtEmailQueue_Notificationid_Z_SetNull( )
      {
         gxTv_SdtEmailQueue_Notificationid_Z = 0;
         SetDirty("Notificationid_Z");
         return  ;
      }

      public bool gxTv_SdtEmailQueue_Notificationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmailQueueRecipient_Z" )]
      [  XmlElement( ElementName = "EmailQueueRecipient_Z"   )]
      public string gxTpr_Emailqueuerecipient_Z
      {
         get {
            return gxTv_SdtEmailQueue_Emailqueuerecipient_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmailQueue_Emailqueuerecipient_Z = value;
            SetDirty("Emailqueuerecipient_Z");
         }

      }

      public void gxTv_SdtEmailQueue_Emailqueuerecipient_Z_SetNull( )
      {
         gxTv_SdtEmailQueue_Emailqueuerecipient_Z = "";
         SetDirty("Emailqueuerecipient_Z");
         return  ;
      }

      public bool gxTv_SdtEmailQueue_Emailqueuerecipient_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmailQueueStatus_Z" )]
      [  XmlElement( ElementName = "EmailQueueStatus_Z"   )]
      public string gxTpr_Emailqueuestatus_Z
      {
         get {
            return gxTv_SdtEmailQueue_Emailqueuestatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmailQueue_Emailqueuestatus_Z = value;
            SetDirty("Emailqueuestatus_Z");
         }

      }

      public void gxTv_SdtEmailQueue_Emailqueuestatus_Z_SetNull( )
      {
         gxTv_SdtEmailQueue_Emailqueuestatus_Z = "";
         SetDirty("Emailqueuestatus_Z");
         return  ;
      }

      public bool gxTv_SdtEmailQueue_Emailqueuestatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmailQueueSentAt_Z" )]
      [  XmlElement( ElementName = "EmailQueueSentAt_Z"  , IsNullable=true )]
      public string gxTpr_Emailqueuesentat_Z_Nullable
      {
         get {
            if ( gxTv_SdtEmailQueue_Emailqueuesentat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtEmailQueue_Emailqueuesentat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtEmailQueue_Emailqueuesentat_Z = DateTime.MinValue;
            else
               gxTv_SdtEmailQueue_Emailqueuesentat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Emailqueuesentat_Z
      {
         get {
            return gxTv_SdtEmailQueue_Emailqueuesentat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmailQueue_Emailqueuesentat_Z = value;
            SetDirty("Emailqueuesentat_Z");
         }

      }

      public void gxTv_SdtEmailQueue_Emailqueuesentat_Z_SetNull( )
      {
         gxTv_SdtEmailQueue_Emailqueuesentat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Emailqueuesentat_Z");
         return  ;
      }

      public bool gxTv_SdtEmailQueue_Emailqueuesentat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmailQueueErrorMessage_Z" )]
      [  XmlElement( ElementName = "EmailQueueErrorMessage_Z"   )]
      public string gxTpr_Emailqueueerrormessage_Z
      {
         get {
            return gxTv_SdtEmailQueue_Emailqueueerrormessage_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmailQueue_Emailqueueerrormessage_Z = value;
            SetDirty("Emailqueueerrormessage_Z");
         }

      }

      public void gxTv_SdtEmailQueue_Emailqueueerrormessage_Z_SetNull( )
      {
         gxTv_SdtEmailQueue_Emailqueueerrormessage_Z = "";
         SetDirty("Emailqueueerrormessage_Z");
         return  ;
      }

      public bool gxTv_SdtEmailQueue_Emailqueueerrormessage_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NotificationId_N" )]
      [  XmlElement( ElementName = "NotificationId_N"   )]
      public short gxTpr_Notificationid_N
      {
         get {
            return gxTv_SdtEmailQueue_Notificationid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmailQueue_Notificationid_N = value;
            SetDirty("Notificationid_N");
         }

      }

      public void gxTv_SdtEmailQueue_Notificationid_N_SetNull( )
      {
         gxTv_SdtEmailQueue_Notificationid_N = 0;
         SetDirty("Notificationid_N");
         return  ;
      }

      public bool gxTv_SdtEmailQueue_Notificationid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmailQueueRecipient_N" )]
      [  XmlElement( ElementName = "EmailQueueRecipient_N"   )]
      public short gxTpr_Emailqueuerecipient_N
      {
         get {
            return gxTv_SdtEmailQueue_Emailqueuerecipient_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmailQueue_Emailqueuerecipient_N = value;
            SetDirty("Emailqueuerecipient_N");
         }

      }

      public void gxTv_SdtEmailQueue_Emailqueuerecipient_N_SetNull( )
      {
         gxTv_SdtEmailQueue_Emailqueuerecipient_N = 0;
         SetDirty("Emailqueuerecipient_N");
         return  ;
      }

      public bool gxTv_SdtEmailQueue_Emailqueuerecipient_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmailQueueStatus_N" )]
      [  XmlElement( ElementName = "EmailQueueStatus_N"   )]
      public short gxTpr_Emailqueuestatus_N
      {
         get {
            return gxTv_SdtEmailQueue_Emailqueuestatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmailQueue_Emailqueuestatus_N = value;
            SetDirty("Emailqueuestatus_N");
         }

      }

      public void gxTv_SdtEmailQueue_Emailqueuestatus_N_SetNull( )
      {
         gxTv_SdtEmailQueue_Emailqueuestatus_N = 0;
         SetDirty("Emailqueuestatus_N");
         return  ;
      }

      public bool gxTv_SdtEmailQueue_Emailqueuestatus_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmailQueueSentAt_N" )]
      [  XmlElement( ElementName = "EmailQueueSentAt_N"   )]
      public short gxTpr_Emailqueuesentat_N
      {
         get {
            return gxTv_SdtEmailQueue_Emailqueuesentat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmailQueue_Emailqueuesentat_N = value;
            SetDirty("Emailqueuesentat_N");
         }

      }

      public void gxTv_SdtEmailQueue_Emailqueuesentat_N_SetNull( )
      {
         gxTv_SdtEmailQueue_Emailqueuesentat_N = 0;
         SetDirty("Emailqueuesentat_N");
         return  ;
      }

      public bool gxTv_SdtEmailQueue_Emailqueuesentat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EmailQueueErrorMessage_N" )]
      [  XmlElement( ElementName = "EmailQueueErrorMessage_N"   )]
      public short gxTpr_Emailqueueerrormessage_N
      {
         get {
            return gxTv_SdtEmailQueue_Emailqueueerrormessage_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEmailQueue_Emailqueueerrormessage_N = value;
            SetDirty("Emailqueueerrormessage_N");
         }

      }

      public void gxTv_SdtEmailQueue_Emailqueueerrormessage_N_SetNull( )
      {
         gxTv_SdtEmailQueue_Emailqueueerrormessage_N = 0;
         SetDirty("Emailqueueerrormessage_N");
         return  ;
      }

      public bool gxTv_SdtEmailQueue_Emailqueueerrormessage_N_IsNull( )
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
         gxTv_SdtEmailQueue_Emailqueuerecipient = "";
         gxTv_SdtEmailQueue_Emailqueuestatus = "";
         gxTv_SdtEmailQueue_Emailqueuesentat = (DateTime)(DateTime.MinValue);
         gxTv_SdtEmailQueue_Emailqueueerrormessage = "";
         gxTv_SdtEmailQueue_Mode = "";
         gxTv_SdtEmailQueue_Emailqueuerecipient_Z = "";
         gxTv_SdtEmailQueue_Emailqueuestatus_Z = "";
         gxTv_SdtEmailQueue_Emailqueuesentat_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtEmailQueue_Emailqueueerrormessage_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "emailqueue", "GeneXus.Programs.emailqueue_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtEmailQueue_Initialized ;
      private short gxTv_SdtEmailQueue_Notificationid_N ;
      private short gxTv_SdtEmailQueue_Emailqueuerecipient_N ;
      private short gxTv_SdtEmailQueue_Emailqueuestatus_N ;
      private short gxTv_SdtEmailQueue_Emailqueuesentat_N ;
      private short gxTv_SdtEmailQueue_Emailqueueerrormessage_N ;
      private int gxTv_SdtEmailQueue_Emailqueueid ;
      private int gxTv_SdtEmailQueue_Notificationid ;
      private int gxTv_SdtEmailQueue_Emailqueueid_Z ;
      private int gxTv_SdtEmailQueue_Notificationid_Z ;
      private string gxTv_SdtEmailQueue_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtEmailQueue_Emailqueuesentat ;
      private DateTime gxTv_SdtEmailQueue_Emailqueuesentat_Z ;
      private DateTime datetime_STZ ;
      private string gxTv_SdtEmailQueue_Emailqueuerecipient ;
      private string gxTv_SdtEmailQueue_Emailqueuestatus ;
      private string gxTv_SdtEmailQueue_Emailqueueerrormessage ;
      private string gxTv_SdtEmailQueue_Emailqueuerecipient_Z ;
      private string gxTv_SdtEmailQueue_Emailqueuestatus_Z ;
      private string gxTv_SdtEmailQueue_Emailqueueerrormessage_Z ;
   }

   [DataContract(Name = @"EmailQueue", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtEmailQueue_RESTInterface : GxGenericCollectionItem<SdtEmailQueue>
   {
      public SdtEmailQueue_RESTInterface( ) : base()
      {
      }

      public SdtEmailQueue_RESTInterface( SdtEmailQueue psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EmailQueueId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Emailqueueid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Emailqueueid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Emailqueueid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
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

      [DataMember( Name = "EmailQueueRecipient" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Emailqueuerecipient
      {
         get {
            return sdt.gxTpr_Emailqueuerecipient ;
         }

         set {
            sdt.gxTpr_Emailqueuerecipient = value;
         }

      }

      [DataMember( Name = "EmailQueueStatus" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Emailqueuestatus
      {
         get {
            return sdt.gxTpr_Emailqueuestatus ;
         }

         set {
            sdt.gxTpr_Emailqueuestatus = value;
         }

      }

      [DataMember( Name = "EmailQueueSentAt" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Emailqueuesentat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Emailqueuesentat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Emailqueuesentat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "EmailQueueErrorMessage" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Emailqueueerrormessage
      {
         get {
            return sdt.gxTpr_Emailqueueerrormessage ;
         }

         set {
            sdt.gxTpr_Emailqueueerrormessage = value;
         }

      }

      public SdtEmailQueue sdt
      {
         get {
            return (SdtEmailQueue)Sdt ;
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
            sdt = new SdtEmailQueue() ;
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

   [DataContract(Name = @"EmailQueue", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtEmailQueue_RESTLInterface : GxGenericCollectionItem<SdtEmailQueue>
   {
      public SdtEmailQueue_RESTLInterface( ) : base()
      {
      }

      public SdtEmailQueue_RESTLInterface( SdtEmailQueue psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EmailQueueRecipient" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Emailqueuerecipient
      {
         get {
            return sdt.gxTpr_Emailqueuerecipient ;
         }

         set {
            sdt.gxTpr_Emailqueuerecipient = value;
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

      public SdtEmailQueue sdt
      {
         get {
            return (SdtEmailQueue)Sdt ;
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
            sdt = new SdtEmailQueue() ;
         }
      }

   }

}
