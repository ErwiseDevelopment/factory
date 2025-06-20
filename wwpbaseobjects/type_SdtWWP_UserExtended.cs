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
namespace GeneXus.Programs.wwpbaseobjects {
   [XmlRoot(ElementName = "WWP_UserExtended" )]
   [XmlType(TypeName =  "WWP_UserExtended" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtWWP_UserExtended : GxSilentTrnSdt
   {
      public SdtWWP_UserExtended( )
      {
      }

      public SdtWWP_UserExtended( IGxContext context )
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

      public void Load( string AV7WWPUserExtendedId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(string)AV7WWPUserExtendedId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"WWPUserExtendedId", typeof(string)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "WWPBaseObjects\\WWP_UserExtended");
         metadata.Set("BT", "WWP_UserExtended");
         metadata.Set("PK", "[ \"WWPUserExtendedId\" ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Wwpuserextendedphoto_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Wwpuserextendedid_Z");
         state.Add("gxTpr_Wwpuserextendedname_Z");
         state.Add("gxTpr_Wwpuserextendedfullname_Z");
         state.Add("gxTpr_Wwpuserextendedphone_Z");
         state.Add("gxTpr_Wwpuserextendedemail_Z");
         state.Add("gxTpr_Wwpuserextendedemainotif_Z");
         state.Add("gxTpr_Wwpuserextendedsmsnotif_Z");
         state.Add("gxTpr_Wwpuserextendedmobilenotif_Z");
         state.Add("gxTpr_Wwpuserextendeddesktopnotif_Z");
         state.Add("gxTpr_Wwpuserextendeddeleted_Z");
         state.Add("gxTpr_Wwpuserextendeddeletedin_Z_Nullable");
         state.Add("gxTpr_Wwpuserextendedphoto_gxi_Z");
         state.Add("gxTpr_Wwpuserextendedid_N");
         state.Add("gxTpr_Wwpuserextendeddeletedin_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended sdt;
         sdt = (GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended)(source);
         gxTv_SdtWWP_UserExtended_Wwpuserextendedid = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendedid ;
         gxTv_SdtWWP_UserExtended_Wwpuserextendedphoto = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendedphoto ;
         gxTv_SdtWWP_UserExtended_Wwpuserextendedphoto_gxi = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendedphoto_gxi ;
         gxTv_SdtWWP_UserExtended_Wwpuserextendedname = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendedname ;
         gxTv_SdtWWP_UserExtended_Wwpuserextendedfullname = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendedfullname ;
         gxTv_SdtWWP_UserExtended_Wwpuserextendedphone = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendedphone ;
         gxTv_SdtWWP_UserExtended_Wwpuserextendedemail = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendedemail ;
         gxTv_SdtWWP_UserExtended_Wwpuserextendedemainotif = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendedemainotif ;
         gxTv_SdtWWP_UserExtended_Wwpuserextendedsmsnotif = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendedsmsnotif ;
         gxTv_SdtWWP_UserExtended_Wwpuserextendedmobilenotif = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendedmobilenotif ;
         gxTv_SdtWWP_UserExtended_Wwpuserextendeddesktopnotif = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendeddesktopnotif ;
         gxTv_SdtWWP_UserExtended_Wwpuserextendeddeleted = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendeddeleted ;
         gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin ;
         gxTv_SdtWWP_UserExtended_Mode = sdt.gxTv_SdtWWP_UserExtended_Mode ;
         gxTv_SdtWWP_UserExtended_Initialized = sdt.gxTv_SdtWWP_UserExtended_Initialized ;
         gxTv_SdtWWP_UserExtended_Wwpuserextendedid_Z = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendedid_Z ;
         gxTv_SdtWWP_UserExtended_Wwpuserextendedname_Z = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendedname_Z ;
         gxTv_SdtWWP_UserExtended_Wwpuserextendedfullname_Z = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendedfullname_Z ;
         gxTv_SdtWWP_UserExtended_Wwpuserextendedphone_Z = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendedphone_Z ;
         gxTv_SdtWWP_UserExtended_Wwpuserextendedemail_Z = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendedemail_Z ;
         gxTv_SdtWWP_UserExtended_Wwpuserextendedemainotif_Z = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendedemainotif_Z ;
         gxTv_SdtWWP_UserExtended_Wwpuserextendedsmsnotif_Z = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendedsmsnotif_Z ;
         gxTv_SdtWWP_UserExtended_Wwpuserextendedmobilenotif_Z = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendedmobilenotif_Z ;
         gxTv_SdtWWP_UserExtended_Wwpuserextendeddesktopnotif_Z = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendeddesktopnotif_Z ;
         gxTv_SdtWWP_UserExtended_Wwpuserextendeddeleted_Z = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendeddeleted_Z ;
         gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin_Z = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin_Z ;
         gxTv_SdtWWP_UserExtended_Wwpuserextendedphoto_gxi_Z = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendedphoto_gxi_Z ;
         gxTv_SdtWWP_UserExtended_Wwpuserextendedid_N = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendedid_N ;
         gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin_N = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin_N ;
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
         AddObjectProperty("WWPUserExtendedId", gxTv_SdtWWP_UserExtended_Wwpuserextendedid, false, includeNonInitialized);
         AddObjectProperty("WWPUserExtendedId_N", gxTv_SdtWWP_UserExtended_Wwpuserextendedid_N, false, includeNonInitialized);
         AddObjectProperty("WWPUserExtendedPhoto", gxTv_SdtWWP_UserExtended_Wwpuserextendedphoto, false, includeNonInitialized);
         AddObjectProperty("WWPUserExtendedName", gxTv_SdtWWP_UserExtended_Wwpuserextendedname, false, includeNonInitialized);
         AddObjectProperty("WWPUserExtendedFullName", gxTv_SdtWWP_UserExtended_Wwpuserextendedfullname, false, includeNonInitialized);
         AddObjectProperty("WWPUserExtendedPhone", gxTv_SdtWWP_UserExtended_Wwpuserextendedphone, false, includeNonInitialized);
         AddObjectProperty("WWPUserExtendedEmail", gxTv_SdtWWP_UserExtended_Wwpuserextendedemail, false, includeNonInitialized);
         AddObjectProperty("WWPUserExtendedEmaiNotif", gxTv_SdtWWP_UserExtended_Wwpuserextendedemainotif, false, includeNonInitialized);
         AddObjectProperty("WWPUserExtendedSMSNotif", gxTv_SdtWWP_UserExtended_Wwpuserextendedsmsnotif, false, includeNonInitialized);
         AddObjectProperty("WWPUserExtendedMobileNotif", gxTv_SdtWWP_UserExtended_Wwpuserextendedmobilenotif, false, includeNonInitialized);
         AddObjectProperty("WWPUserExtendedDesktopNotif", gxTv_SdtWWP_UserExtended_Wwpuserextendeddesktopnotif, false, includeNonInitialized);
         AddObjectProperty("WWPUserExtendedDeleted", gxTv_SdtWWP_UserExtended_Wwpuserextendeddeleted, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin;
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
         AddObjectProperty("WWPUserExtendedDeletedIn", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("WWPUserExtendedDeletedIn_N", gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("WWPUserExtendedPhoto_GXI", gxTv_SdtWWP_UserExtended_Wwpuserextendedphoto_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtWWP_UserExtended_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtWWP_UserExtended_Initialized, false, includeNonInitialized);
            AddObjectProperty("WWPUserExtendedId_Z", gxTv_SdtWWP_UserExtended_Wwpuserextendedid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPUserExtendedName_Z", gxTv_SdtWWP_UserExtended_Wwpuserextendedname_Z, false, includeNonInitialized);
            AddObjectProperty("WWPUserExtendedFullName_Z", gxTv_SdtWWP_UserExtended_Wwpuserextendedfullname_Z, false, includeNonInitialized);
            AddObjectProperty("WWPUserExtendedPhone_Z", gxTv_SdtWWP_UserExtended_Wwpuserextendedphone_Z, false, includeNonInitialized);
            AddObjectProperty("WWPUserExtendedEmail_Z", gxTv_SdtWWP_UserExtended_Wwpuserextendedemail_Z, false, includeNonInitialized);
            AddObjectProperty("WWPUserExtendedEmaiNotif_Z", gxTv_SdtWWP_UserExtended_Wwpuserextendedemainotif_Z, false, includeNonInitialized);
            AddObjectProperty("WWPUserExtendedSMSNotif_Z", gxTv_SdtWWP_UserExtended_Wwpuserextendedsmsnotif_Z, false, includeNonInitialized);
            AddObjectProperty("WWPUserExtendedMobileNotif_Z", gxTv_SdtWWP_UserExtended_Wwpuserextendedmobilenotif_Z, false, includeNonInitialized);
            AddObjectProperty("WWPUserExtendedDesktopNotif_Z", gxTv_SdtWWP_UserExtended_Wwpuserextendeddesktopnotif_Z, false, includeNonInitialized);
            AddObjectProperty("WWPUserExtendedDeleted_Z", gxTv_SdtWWP_UserExtended_Wwpuserextendeddeleted_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin_Z;
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
            AddObjectProperty("WWPUserExtendedDeletedIn_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("WWPUserExtendedPhoto_GXI_Z", gxTv_SdtWWP_UserExtended_Wwpuserextendedphoto_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("WWPUserExtendedId_N", gxTv_SdtWWP_UserExtended_Wwpuserextendedid_N, false, includeNonInitialized);
            AddObjectProperty("WWPUserExtendedDeletedIn_N", gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended sdt )
      {
         if ( sdt.IsDirty("WWPUserExtendedId") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendedid = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendedid ;
         }
         if ( sdt.IsDirty("WWPUserExtendedPhoto") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendedphoto = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendedphoto ;
         }
         if ( sdt.IsDirty("WWPUserExtendedPhoto") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendedphoto_gxi = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendedphoto_gxi ;
         }
         if ( sdt.IsDirty("WWPUserExtendedName") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendedname = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendedname ;
         }
         if ( sdt.IsDirty("WWPUserExtendedFullName") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendedfullname = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendedfullname ;
         }
         if ( sdt.IsDirty("WWPUserExtendedPhone") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendedphone = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendedphone ;
         }
         if ( sdt.IsDirty("WWPUserExtendedEmail") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendedemail = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendedemail ;
         }
         if ( sdt.IsDirty("WWPUserExtendedEmaiNotif") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendedemainotif = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendedemainotif ;
         }
         if ( sdt.IsDirty("WWPUserExtendedSMSNotif") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendedsmsnotif = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendedsmsnotif ;
         }
         if ( sdt.IsDirty("WWPUserExtendedMobileNotif") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendedmobilenotif = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendedmobilenotif ;
         }
         if ( sdt.IsDirty("WWPUserExtendedDesktopNotif") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendeddesktopnotif = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendeddesktopnotif ;
         }
         if ( sdt.IsDirty("WWPUserExtendedDeleted") )
         {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendeddeleted = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendeddeleted ;
         }
         if ( sdt.IsDirty("WWPUserExtendedDeletedIn") )
         {
            gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin_N = (short)(sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin_N);
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin = sdt.gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "WWPUserExtendedId" )]
      [  XmlElement( ElementName = "WWPUserExtendedId"   )]
      public string gxTpr_Wwpuserextendedid
      {
         get {
            return gxTv_SdtWWP_UserExtended_Wwpuserextendedid ;
         }

         set {
            sdtIsNull = 0;
            if ( StringUtil.StrCmp(gxTv_SdtWWP_UserExtended_Wwpuserextendedid, value) != 0 )
            {
               gxTv_SdtWWP_UserExtended_Mode = "INS";
               this.gxTv_SdtWWP_UserExtended_Wwpuserextendedid_Z_SetNull( );
               this.gxTv_SdtWWP_UserExtended_Wwpuserextendedname_Z_SetNull( );
               this.gxTv_SdtWWP_UserExtended_Wwpuserextendedfullname_Z_SetNull( );
               this.gxTv_SdtWWP_UserExtended_Wwpuserextendedphone_Z_SetNull( );
               this.gxTv_SdtWWP_UserExtended_Wwpuserextendedemail_Z_SetNull( );
               this.gxTv_SdtWWP_UserExtended_Wwpuserextendedemainotif_Z_SetNull( );
               this.gxTv_SdtWWP_UserExtended_Wwpuserextendedsmsnotif_Z_SetNull( );
               this.gxTv_SdtWWP_UserExtended_Wwpuserextendedmobilenotif_Z_SetNull( );
               this.gxTv_SdtWWP_UserExtended_Wwpuserextendeddesktopnotif_Z_SetNull( );
               this.gxTv_SdtWWP_UserExtended_Wwpuserextendeddeleted_Z_SetNull( );
               this.gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin_Z_SetNull( );
               this.gxTv_SdtWWP_UserExtended_Wwpuserextendedphoto_gxi_Z_SetNull( );
            }
            gxTv_SdtWWP_UserExtended_Wwpuserextendedid = value;
            SetDirty("Wwpuserextendedid");
         }

      }

      [  SoapElement( ElementName = "WWPUserExtendedPhoto" )]
      [  XmlElement( ElementName = "WWPUserExtendedPhoto"   )]
      [GxUpload()]
      public string gxTpr_Wwpuserextendedphoto
      {
         get {
            return gxTv_SdtWWP_UserExtended_Wwpuserextendedphoto ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendedphoto = value;
            SetDirty("Wwpuserextendedphoto");
         }

      }

      [  SoapElement( ElementName = "WWPUserExtendedPhoto_GXI" )]
      [  XmlElement( ElementName = "WWPUserExtendedPhoto_GXI"   )]
      public string gxTpr_Wwpuserextendedphoto_gxi
      {
         get {
            return gxTv_SdtWWP_UserExtended_Wwpuserextendedphoto_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendedphoto_gxi = value;
            SetDirty("Wwpuserextendedphoto_gxi");
         }

      }

      [  SoapElement( ElementName = "WWPUserExtendedName" )]
      [  XmlElement( ElementName = "WWPUserExtendedName"   )]
      public string gxTpr_Wwpuserextendedname
      {
         get {
            return gxTv_SdtWWP_UserExtended_Wwpuserextendedname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendedname = value;
            SetDirty("Wwpuserextendedname");
         }

      }

      [  SoapElement( ElementName = "WWPUserExtendedFullName" )]
      [  XmlElement( ElementName = "WWPUserExtendedFullName"   )]
      public string gxTpr_Wwpuserextendedfullname
      {
         get {
            return gxTv_SdtWWP_UserExtended_Wwpuserextendedfullname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendedfullname = value;
            SetDirty("Wwpuserextendedfullname");
         }

      }

      [  SoapElement( ElementName = "WWPUserExtendedPhone" )]
      [  XmlElement( ElementName = "WWPUserExtendedPhone"   )]
      public string gxTpr_Wwpuserextendedphone
      {
         get {
            return gxTv_SdtWWP_UserExtended_Wwpuserextendedphone ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendedphone = value;
            SetDirty("Wwpuserextendedphone");
         }

      }

      [  SoapElement( ElementName = "WWPUserExtendedEmail" )]
      [  XmlElement( ElementName = "WWPUserExtendedEmail"   )]
      public string gxTpr_Wwpuserextendedemail
      {
         get {
            return gxTv_SdtWWP_UserExtended_Wwpuserextendedemail ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendedemail = value;
            SetDirty("Wwpuserextendedemail");
         }

      }

      [  SoapElement( ElementName = "WWPUserExtendedEmaiNotif" )]
      [  XmlElement( ElementName = "WWPUserExtendedEmaiNotif"   )]
      public bool gxTpr_Wwpuserextendedemainotif
      {
         get {
            return gxTv_SdtWWP_UserExtended_Wwpuserextendedemainotif ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendedemainotif = value;
            SetDirty("Wwpuserextendedemainotif");
         }

      }

      [  SoapElement( ElementName = "WWPUserExtendedSMSNotif" )]
      [  XmlElement( ElementName = "WWPUserExtendedSMSNotif"   )]
      public bool gxTpr_Wwpuserextendedsmsnotif
      {
         get {
            return gxTv_SdtWWP_UserExtended_Wwpuserextendedsmsnotif ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendedsmsnotif = value;
            SetDirty("Wwpuserextendedsmsnotif");
         }

      }

      [  SoapElement( ElementName = "WWPUserExtendedMobileNotif" )]
      [  XmlElement( ElementName = "WWPUserExtendedMobileNotif"   )]
      public bool gxTpr_Wwpuserextendedmobilenotif
      {
         get {
            return gxTv_SdtWWP_UserExtended_Wwpuserextendedmobilenotif ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendedmobilenotif = value;
            SetDirty("Wwpuserextendedmobilenotif");
         }

      }

      [  SoapElement( ElementName = "WWPUserExtendedDesktopNotif" )]
      [  XmlElement( ElementName = "WWPUserExtendedDesktopNotif"   )]
      public bool gxTpr_Wwpuserextendeddesktopnotif
      {
         get {
            return gxTv_SdtWWP_UserExtended_Wwpuserextendeddesktopnotif ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendeddesktopnotif = value;
            SetDirty("Wwpuserextendeddesktopnotif");
         }

      }

      [  SoapElement( ElementName = "WWPUserExtendedDeleted" )]
      [  XmlElement( ElementName = "WWPUserExtendedDeleted"   )]
      public bool gxTpr_Wwpuserextendeddeleted
      {
         get {
            return gxTv_SdtWWP_UserExtended_Wwpuserextendeddeleted ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendeddeleted = value;
            SetDirty("Wwpuserextendeddeleted");
         }

      }

      [  SoapElement( ElementName = "WWPUserExtendedDeletedIn" )]
      [  XmlElement( ElementName = "WWPUserExtendedDeletedIn"  , IsNullable=true )]
      public string gxTpr_Wwpuserextendeddeletedin_Nullable
      {
         get {
            if ( gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin).value ;
         }

         set {
            gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin = DateTime.MinValue;
            else
               gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Wwpuserextendeddeletedin
      {
         get {
            return gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin ;
         }

         set {
            gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin_N = 0;
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin = value;
            SetDirty("Wwpuserextendeddeletedin");
         }

      }

      public void gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin_SetNull( )
      {
         gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin_N = 1;
         gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin = (DateTime)(DateTime.MinValue);
         SetDirty("Wwpuserextendeddeletedin");
         return  ;
      }

      public bool gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin_IsNull( )
      {
         return (gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtWWP_UserExtended_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtWWP_UserExtended_Mode_SetNull( )
      {
         gxTv_SdtWWP_UserExtended_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtWWP_UserExtended_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtWWP_UserExtended_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtWWP_UserExtended_Initialized_SetNull( )
      {
         gxTv_SdtWWP_UserExtended_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtWWP_UserExtended_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPUserExtendedId_Z" )]
      [  XmlElement( ElementName = "WWPUserExtendedId_Z"   )]
      public string gxTpr_Wwpuserextendedid_Z
      {
         get {
            return gxTv_SdtWWP_UserExtended_Wwpuserextendedid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendedid_Z = value;
            SetDirty("Wwpuserextendedid_Z");
         }

      }

      public void gxTv_SdtWWP_UserExtended_Wwpuserextendedid_Z_SetNull( )
      {
         gxTv_SdtWWP_UserExtended_Wwpuserextendedid_Z = "";
         SetDirty("Wwpuserextendedid_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_UserExtended_Wwpuserextendedid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPUserExtendedName_Z" )]
      [  XmlElement( ElementName = "WWPUserExtendedName_Z"   )]
      public string gxTpr_Wwpuserextendedname_Z
      {
         get {
            return gxTv_SdtWWP_UserExtended_Wwpuserextendedname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendedname_Z = value;
            SetDirty("Wwpuserextendedname_Z");
         }

      }

      public void gxTv_SdtWWP_UserExtended_Wwpuserextendedname_Z_SetNull( )
      {
         gxTv_SdtWWP_UserExtended_Wwpuserextendedname_Z = "";
         SetDirty("Wwpuserextendedname_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_UserExtended_Wwpuserextendedname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPUserExtendedFullName_Z" )]
      [  XmlElement( ElementName = "WWPUserExtendedFullName_Z"   )]
      public string gxTpr_Wwpuserextendedfullname_Z
      {
         get {
            return gxTv_SdtWWP_UserExtended_Wwpuserextendedfullname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendedfullname_Z = value;
            SetDirty("Wwpuserextendedfullname_Z");
         }

      }

      public void gxTv_SdtWWP_UserExtended_Wwpuserextendedfullname_Z_SetNull( )
      {
         gxTv_SdtWWP_UserExtended_Wwpuserextendedfullname_Z = "";
         SetDirty("Wwpuserextendedfullname_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_UserExtended_Wwpuserextendedfullname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPUserExtendedPhone_Z" )]
      [  XmlElement( ElementName = "WWPUserExtendedPhone_Z"   )]
      public string gxTpr_Wwpuserextendedphone_Z
      {
         get {
            return gxTv_SdtWWP_UserExtended_Wwpuserextendedphone_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendedphone_Z = value;
            SetDirty("Wwpuserextendedphone_Z");
         }

      }

      public void gxTv_SdtWWP_UserExtended_Wwpuserextendedphone_Z_SetNull( )
      {
         gxTv_SdtWWP_UserExtended_Wwpuserextendedphone_Z = "";
         SetDirty("Wwpuserextendedphone_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_UserExtended_Wwpuserextendedphone_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPUserExtendedEmail_Z" )]
      [  XmlElement( ElementName = "WWPUserExtendedEmail_Z"   )]
      public string gxTpr_Wwpuserextendedemail_Z
      {
         get {
            return gxTv_SdtWWP_UserExtended_Wwpuserextendedemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendedemail_Z = value;
            SetDirty("Wwpuserextendedemail_Z");
         }

      }

      public void gxTv_SdtWWP_UserExtended_Wwpuserextendedemail_Z_SetNull( )
      {
         gxTv_SdtWWP_UserExtended_Wwpuserextendedemail_Z = "";
         SetDirty("Wwpuserextendedemail_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_UserExtended_Wwpuserextendedemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPUserExtendedEmaiNotif_Z" )]
      [  XmlElement( ElementName = "WWPUserExtendedEmaiNotif_Z"   )]
      public bool gxTpr_Wwpuserextendedemainotif_Z
      {
         get {
            return gxTv_SdtWWP_UserExtended_Wwpuserextendedemainotif_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendedemainotif_Z = value;
            SetDirty("Wwpuserextendedemainotif_Z");
         }

      }

      public void gxTv_SdtWWP_UserExtended_Wwpuserextendedemainotif_Z_SetNull( )
      {
         gxTv_SdtWWP_UserExtended_Wwpuserextendedemainotif_Z = false;
         SetDirty("Wwpuserextendedemainotif_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_UserExtended_Wwpuserextendedemainotif_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPUserExtendedSMSNotif_Z" )]
      [  XmlElement( ElementName = "WWPUserExtendedSMSNotif_Z"   )]
      public bool gxTpr_Wwpuserextendedsmsnotif_Z
      {
         get {
            return gxTv_SdtWWP_UserExtended_Wwpuserextendedsmsnotif_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendedsmsnotif_Z = value;
            SetDirty("Wwpuserextendedsmsnotif_Z");
         }

      }

      public void gxTv_SdtWWP_UserExtended_Wwpuserextendedsmsnotif_Z_SetNull( )
      {
         gxTv_SdtWWP_UserExtended_Wwpuserextendedsmsnotif_Z = false;
         SetDirty("Wwpuserextendedsmsnotif_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_UserExtended_Wwpuserextendedsmsnotif_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPUserExtendedMobileNotif_Z" )]
      [  XmlElement( ElementName = "WWPUserExtendedMobileNotif_Z"   )]
      public bool gxTpr_Wwpuserextendedmobilenotif_Z
      {
         get {
            return gxTv_SdtWWP_UserExtended_Wwpuserextendedmobilenotif_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendedmobilenotif_Z = value;
            SetDirty("Wwpuserextendedmobilenotif_Z");
         }

      }

      public void gxTv_SdtWWP_UserExtended_Wwpuserextendedmobilenotif_Z_SetNull( )
      {
         gxTv_SdtWWP_UserExtended_Wwpuserextendedmobilenotif_Z = false;
         SetDirty("Wwpuserextendedmobilenotif_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_UserExtended_Wwpuserextendedmobilenotif_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPUserExtendedDesktopNotif_Z" )]
      [  XmlElement( ElementName = "WWPUserExtendedDesktopNotif_Z"   )]
      public bool gxTpr_Wwpuserextendeddesktopnotif_Z
      {
         get {
            return gxTv_SdtWWP_UserExtended_Wwpuserextendeddesktopnotif_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendeddesktopnotif_Z = value;
            SetDirty("Wwpuserextendeddesktopnotif_Z");
         }

      }

      public void gxTv_SdtWWP_UserExtended_Wwpuserextendeddesktopnotif_Z_SetNull( )
      {
         gxTv_SdtWWP_UserExtended_Wwpuserextendeddesktopnotif_Z = false;
         SetDirty("Wwpuserextendeddesktopnotif_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_UserExtended_Wwpuserextendeddesktopnotif_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPUserExtendedDeleted_Z" )]
      [  XmlElement( ElementName = "WWPUserExtendedDeleted_Z"   )]
      public bool gxTpr_Wwpuserextendeddeleted_Z
      {
         get {
            return gxTv_SdtWWP_UserExtended_Wwpuserextendeddeleted_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendeddeleted_Z = value;
            SetDirty("Wwpuserextendeddeleted_Z");
         }

      }

      public void gxTv_SdtWWP_UserExtended_Wwpuserextendeddeleted_Z_SetNull( )
      {
         gxTv_SdtWWP_UserExtended_Wwpuserextendeddeleted_Z = false;
         SetDirty("Wwpuserextendeddeleted_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_UserExtended_Wwpuserextendeddeleted_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPUserExtendedDeletedIn_Z" )]
      [  XmlElement( ElementName = "WWPUserExtendedDeletedIn_Z"  , IsNullable=true )]
      public string gxTpr_Wwpuserextendeddeletedin_Z_Nullable
      {
         get {
            if ( gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin_Z = DateTime.MinValue;
            else
               gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Wwpuserextendeddeletedin_Z
      {
         get {
            return gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin_Z = value;
            SetDirty("Wwpuserextendeddeletedin_Z");
         }

      }

      public void gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin_Z_SetNull( )
      {
         gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Wwpuserextendeddeletedin_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPUserExtendedPhoto_GXI_Z" )]
      [  XmlElement( ElementName = "WWPUserExtendedPhoto_GXI_Z"   )]
      public string gxTpr_Wwpuserextendedphoto_gxi_Z
      {
         get {
            return gxTv_SdtWWP_UserExtended_Wwpuserextendedphoto_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendedphoto_gxi_Z = value;
            SetDirty("Wwpuserextendedphoto_gxi_Z");
         }

      }

      public void gxTv_SdtWWP_UserExtended_Wwpuserextendedphoto_gxi_Z_SetNull( )
      {
         gxTv_SdtWWP_UserExtended_Wwpuserextendedphoto_gxi_Z = "";
         SetDirty("Wwpuserextendedphoto_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtWWP_UserExtended_Wwpuserextendedphoto_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPUserExtendedId_N" )]
      [  XmlElement( ElementName = "WWPUserExtendedId_N"   )]
      public short gxTpr_Wwpuserextendedid_N
      {
         get {
            return gxTv_SdtWWP_UserExtended_Wwpuserextendedid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendedid_N = value;
            SetDirty("Wwpuserextendedid_N");
         }

      }

      public void gxTv_SdtWWP_UserExtended_Wwpuserextendedid_N_SetNull( )
      {
         gxTv_SdtWWP_UserExtended_Wwpuserextendedid_N = 0;
         SetDirty("Wwpuserextendedid_N");
         return  ;
      }

      public bool gxTv_SdtWWP_UserExtended_Wwpuserextendedid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPUserExtendedDeletedIn_N" )]
      [  XmlElement( ElementName = "WWPUserExtendedDeletedIn_N"   )]
      public short gxTpr_Wwpuserextendeddeletedin_N
      {
         get {
            return gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin_N = value;
            SetDirty("Wwpuserextendeddeletedin_N");
         }

      }

      public void gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin_N_SetNull( )
      {
         gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin_N = 0;
         SetDirty("Wwpuserextendeddeletedin_N");
         return  ;
      }

      public bool gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin_N_IsNull( )
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
         gxTv_SdtWWP_UserExtended_Wwpuserextendedid = "";
         sdtIsNull = 1;
         gxTv_SdtWWP_UserExtended_Wwpuserextendedphoto = "";
         gxTv_SdtWWP_UserExtended_Wwpuserextendedphoto_gxi = "";
         gxTv_SdtWWP_UserExtended_Wwpuserextendedname = "";
         gxTv_SdtWWP_UserExtended_Wwpuserextendedfullname = "";
         gxTv_SdtWWP_UserExtended_Wwpuserextendedphone = "";
         gxTv_SdtWWP_UserExtended_Wwpuserextendedemail = "";
         gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_UserExtended_Mode = "";
         gxTv_SdtWWP_UserExtended_Wwpuserextendedid_Z = "";
         gxTv_SdtWWP_UserExtended_Wwpuserextendedname_Z = "";
         gxTv_SdtWWP_UserExtended_Wwpuserextendedfullname_Z = "";
         gxTv_SdtWWP_UserExtended_Wwpuserextendedphone_Z = "";
         gxTv_SdtWWP_UserExtended_Wwpuserextendedemail_Z = "";
         gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtWWP_UserExtended_Wwpuserextendedphoto_gxi_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "wwpbaseobjects.wwp_userextended", "GeneXus.Programs.wwpbaseobjects.wwp_userextended_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtWWP_UserExtended_Initialized ;
      private short gxTv_SdtWWP_UserExtended_Wwpuserextendedid_N ;
      private short gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin_N ;
      private string gxTv_SdtWWP_UserExtended_Wwpuserextendedid ;
      private string gxTv_SdtWWP_UserExtended_Wwpuserextendedphone ;
      private string gxTv_SdtWWP_UserExtended_Mode ;
      private string gxTv_SdtWWP_UserExtended_Wwpuserextendedid_Z ;
      private string gxTv_SdtWWP_UserExtended_Wwpuserextendedphone_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin ;
      private DateTime gxTv_SdtWWP_UserExtended_Wwpuserextendeddeletedin_Z ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtWWP_UserExtended_Wwpuserextendedemainotif ;
      private bool gxTv_SdtWWP_UserExtended_Wwpuserextendedsmsnotif ;
      private bool gxTv_SdtWWP_UserExtended_Wwpuserextendedmobilenotif ;
      private bool gxTv_SdtWWP_UserExtended_Wwpuserextendeddesktopnotif ;
      private bool gxTv_SdtWWP_UserExtended_Wwpuserextendeddeleted ;
      private bool gxTv_SdtWWP_UserExtended_Wwpuserextendedemainotif_Z ;
      private bool gxTv_SdtWWP_UserExtended_Wwpuserextendedsmsnotif_Z ;
      private bool gxTv_SdtWWP_UserExtended_Wwpuserextendedmobilenotif_Z ;
      private bool gxTv_SdtWWP_UserExtended_Wwpuserextendeddesktopnotif_Z ;
      private bool gxTv_SdtWWP_UserExtended_Wwpuserextendeddeleted_Z ;
      private string gxTv_SdtWWP_UserExtended_Wwpuserextendedphoto_gxi ;
      private string gxTv_SdtWWP_UserExtended_Wwpuserextendedname ;
      private string gxTv_SdtWWP_UserExtended_Wwpuserextendedfullname ;
      private string gxTv_SdtWWP_UserExtended_Wwpuserextendedemail ;
      private string gxTv_SdtWWP_UserExtended_Wwpuserextendedname_Z ;
      private string gxTv_SdtWWP_UserExtended_Wwpuserextendedfullname_Z ;
      private string gxTv_SdtWWP_UserExtended_Wwpuserextendedemail_Z ;
      private string gxTv_SdtWWP_UserExtended_Wwpuserextendedphoto_gxi_Z ;
      private string gxTv_SdtWWP_UserExtended_Wwpuserextendedphoto ;
   }

   [DataContract(Name = @"WWPBaseObjects\WWP_UserExtended", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtWWP_UserExtended_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended>
   {
      public SdtWWP_UserExtended_RESTInterface( ) : base()
      {
      }

      public SdtWWP_UserExtended_RESTInterface( GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WWPUserExtendedId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Wwpuserextendedid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Wwpuserextendedid) ;
         }

         set {
            sdt.gxTpr_Wwpuserextendedid = value;
         }

      }

      [DataMember( Name = "WWPUserExtendedPhoto" , Order = 1 )]
      [GxUpload()]
      public string gxTpr_Wwpuserextendedphoto
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Wwpuserextendedphoto)) ? PathUtil.RelativeURL( sdt.gxTpr_Wwpuserextendedphoto) : StringUtil.RTrim( sdt.gxTpr_Wwpuserextendedphoto_gxi)) ;
         }

         set {
            sdt.gxTpr_Wwpuserextendedphoto = value;
         }

      }

      [DataMember( Name = "WWPUserExtendedName" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Wwpuserextendedname
      {
         get {
            return sdt.gxTpr_Wwpuserextendedname ;
         }

         set {
            sdt.gxTpr_Wwpuserextendedname = value;
         }

      }

      [DataMember( Name = "WWPUserExtendedFullName" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Wwpuserextendedfullname
      {
         get {
            return sdt.gxTpr_Wwpuserextendedfullname ;
         }

         set {
            sdt.gxTpr_Wwpuserextendedfullname = value;
         }

      }

      [DataMember( Name = "WWPUserExtendedPhone" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Wwpuserextendedphone
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Wwpuserextendedphone) ;
         }

         set {
            sdt.gxTpr_Wwpuserextendedphone = value;
         }

      }

      [DataMember( Name = "WWPUserExtendedEmail" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Wwpuserextendedemail
      {
         get {
            return sdt.gxTpr_Wwpuserextendedemail ;
         }

         set {
            sdt.gxTpr_Wwpuserextendedemail = value;
         }

      }

      [DataMember( Name = "WWPUserExtendedEmaiNotif" , Order = 6 )]
      [GxSeudo()]
      public bool gxTpr_Wwpuserextendedemainotif
      {
         get {
            return sdt.gxTpr_Wwpuserextendedemainotif ;
         }

         set {
            sdt.gxTpr_Wwpuserextendedemainotif = value;
         }

      }

      [DataMember( Name = "WWPUserExtendedSMSNotif" , Order = 7 )]
      [GxSeudo()]
      public bool gxTpr_Wwpuserextendedsmsnotif
      {
         get {
            return sdt.gxTpr_Wwpuserextendedsmsnotif ;
         }

         set {
            sdt.gxTpr_Wwpuserextendedsmsnotif = value;
         }

      }

      [DataMember( Name = "WWPUserExtendedMobileNotif" , Order = 8 )]
      [GxSeudo()]
      public bool gxTpr_Wwpuserextendedmobilenotif
      {
         get {
            return sdt.gxTpr_Wwpuserextendedmobilenotif ;
         }

         set {
            sdt.gxTpr_Wwpuserextendedmobilenotif = value;
         }

      }

      [DataMember( Name = "WWPUserExtendedDesktopNotif" , Order = 9 )]
      [GxSeudo()]
      public bool gxTpr_Wwpuserextendeddesktopnotif
      {
         get {
            return sdt.gxTpr_Wwpuserextendeddesktopnotif ;
         }

         set {
            sdt.gxTpr_Wwpuserextendeddesktopnotif = value;
         }

      }

      [DataMember( Name = "WWPUserExtendedDeleted" , Order = 10 )]
      [GxSeudo()]
      public bool gxTpr_Wwpuserextendeddeleted
      {
         get {
            return sdt.gxTpr_Wwpuserextendeddeleted ;
         }

         set {
            sdt.gxTpr_Wwpuserextendeddeleted = value;
         }

      }

      [DataMember( Name = "WWPUserExtendedDeletedIn" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Wwpuserextendeddeletedin
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Wwpuserextendeddeletedin, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Wwpuserextendeddeletedin = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      public GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended)Sdt ;
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
            sdt = new GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 12 )]
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

   [DataContract(Name = @"WWPBaseObjects\WWP_UserExtended", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtWWP_UserExtended_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended>
   {
      public SdtWWP_UserExtended_RESTLInterface( ) : base()
      {
      }

      public SdtWWP_UserExtended_RESTLInterface( GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "uri" , Order = 0 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended)Sdt ;
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
            sdt = new GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended() ;
         }
      }

   }

}
