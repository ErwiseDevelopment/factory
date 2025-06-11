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
   [XmlRoot(ElementName = "Usuario" )]
   [XmlType(TypeName =  "Usuario" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtUsuario : GxSilentTrnSdt
   {
      public SdtUsuario( )
      {
      }

      public SdtUsuario( IGxContext context )
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

      public void Load( short AV133SecUserId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV133SecUserId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"SecUserId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Usuario");
         metadata.Set("BT", "SecUser");
         metadata.Set("PK", "[ \"SecUserId\" ]");
         metadata.Set("PKAssigned", "[ \"SecUserId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ClienteId\" ],\"FKMap\":[ \"SecUserOwnerId-ClienteId\" ] },{ \"FK\":[ \"SecUserId\" ],\"FKMap\":[ \"SecUserClienteId-SecUserId\" ] },{ \"FK\":[ \"SecUserId\" ],\"FKMap\":[ \"SecUserUserMan-SecUserId\" ] } ]");
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
         state.Add("gxTpr_Secuserid_Z");
         state.Add("gxTpr_Secusername_Z");
         state.Add("gxTpr_Secuserfullname_Z");
         state.Add("gxTpr_Secuseremail_Z");
         state.Add("gxTpr_Secuserstatus_Z");
         state.Add("gxTpr_Secusercreatedat_Z_Nullable");
         state.Add("gxTpr_Secuserupdateat_Z_Nullable");
         state.Add("gxTpr_Secuserclienteid_Z");
         state.Add("gxTpr_Secuserownerid_Z");
         state.Add("gxTpr_Secuseruserman_Z");
         state.Add("gxTpr_Secuserid_N");
         state.Add("gxTpr_Secusername_N");
         state.Add("gxTpr_Secuserfullname_N");
         state.Add("gxTpr_Secuseremail_N");
         state.Add("gxTpr_Secuserstatus_N");
         state.Add("gxTpr_Secusercreatedat_N");
         state.Add("gxTpr_Secuserupdateat_N");
         state.Add("gxTpr_Secuserclienteid_N");
         state.Add("gxTpr_Secuserownerid_N");
         state.Add("gxTpr_Secuseruserman_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtUsuario sdt;
         sdt = (SdtUsuario)(source);
         gxTv_SdtUsuario_Secuserid = sdt.gxTv_SdtUsuario_Secuserid ;
         gxTv_SdtUsuario_Secusername = sdt.gxTv_SdtUsuario_Secusername ;
         gxTv_SdtUsuario_Secuserfullname = sdt.gxTv_SdtUsuario_Secuserfullname ;
         gxTv_SdtUsuario_Secuseremail = sdt.gxTv_SdtUsuario_Secuseremail ;
         gxTv_SdtUsuario_Secuserstatus = sdt.gxTv_SdtUsuario_Secuserstatus ;
         gxTv_SdtUsuario_Secusercreatedat = sdt.gxTv_SdtUsuario_Secusercreatedat ;
         gxTv_SdtUsuario_Secuserupdateat = sdt.gxTv_SdtUsuario_Secuserupdateat ;
         gxTv_SdtUsuario_Secuserclienteid = sdt.gxTv_SdtUsuario_Secuserclienteid ;
         gxTv_SdtUsuario_Secuserownerid = sdt.gxTv_SdtUsuario_Secuserownerid ;
         gxTv_SdtUsuario_Secuseruserman = sdt.gxTv_SdtUsuario_Secuseruserman ;
         gxTv_SdtUsuario_Mode = sdt.gxTv_SdtUsuario_Mode ;
         gxTv_SdtUsuario_Initialized = sdt.gxTv_SdtUsuario_Initialized ;
         gxTv_SdtUsuario_Secuserid_Z = sdt.gxTv_SdtUsuario_Secuserid_Z ;
         gxTv_SdtUsuario_Secusername_Z = sdt.gxTv_SdtUsuario_Secusername_Z ;
         gxTv_SdtUsuario_Secuserfullname_Z = sdt.gxTv_SdtUsuario_Secuserfullname_Z ;
         gxTv_SdtUsuario_Secuseremail_Z = sdt.gxTv_SdtUsuario_Secuseremail_Z ;
         gxTv_SdtUsuario_Secuserstatus_Z = sdt.gxTv_SdtUsuario_Secuserstatus_Z ;
         gxTv_SdtUsuario_Secusercreatedat_Z = sdt.gxTv_SdtUsuario_Secusercreatedat_Z ;
         gxTv_SdtUsuario_Secuserupdateat_Z = sdt.gxTv_SdtUsuario_Secuserupdateat_Z ;
         gxTv_SdtUsuario_Secuserclienteid_Z = sdt.gxTv_SdtUsuario_Secuserclienteid_Z ;
         gxTv_SdtUsuario_Secuserownerid_Z = sdt.gxTv_SdtUsuario_Secuserownerid_Z ;
         gxTv_SdtUsuario_Secuseruserman_Z = sdt.gxTv_SdtUsuario_Secuseruserman_Z ;
         gxTv_SdtUsuario_Secuserid_N = sdt.gxTv_SdtUsuario_Secuserid_N ;
         gxTv_SdtUsuario_Secusername_N = sdt.gxTv_SdtUsuario_Secusername_N ;
         gxTv_SdtUsuario_Secuserfullname_N = sdt.gxTv_SdtUsuario_Secuserfullname_N ;
         gxTv_SdtUsuario_Secuseremail_N = sdt.gxTv_SdtUsuario_Secuseremail_N ;
         gxTv_SdtUsuario_Secuserstatus_N = sdt.gxTv_SdtUsuario_Secuserstatus_N ;
         gxTv_SdtUsuario_Secusercreatedat_N = sdt.gxTv_SdtUsuario_Secusercreatedat_N ;
         gxTv_SdtUsuario_Secuserupdateat_N = sdt.gxTv_SdtUsuario_Secuserupdateat_N ;
         gxTv_SdtUsuario_Secuserclienteid_N = sdt.gxTv_SdtUsuario_Secuserclienteid_N ;
         gxTv_SdtUsuario_Secuserownerid_N = sdt.gxTv_SdtUsuario_Secuserownerid_N ;
         gxTv_SdtUsuario_Secuseruserman_N = sdt.gxTv_SdtUsuario_Secuseruserman_N ;
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
         AddObjectProperty("SecUserId", gxTv_SdtUsuario_Secuserid, false, includeNonInitialized);
         AddObjectProperty("SecUserId_N", gxTv_SdtUsuario_Secuserid_N, false, includeNonInitialized);
         AddObjectProperty("SecUserName", gxTv_SdtUsuario_Secusername, false, includeNonInitialized);
         AddObjectProperty("SecUserName_N", gxTv_SdtUsuario_Secusername_N, false, includeNonInitialized);
         AddObjectProperty("SecUserFullName", gxTv_SdtUsuario_Secuserfullname, false, includeNonInitialized);
         AddObjectProperty("SecUserFullName_N", gxTv_SdtUsuario_Secuserfullname_N, false, includeNonInitialized);
         AddObjectProperty("SecUserEmail", gxTv_SdtUsuario_Secuseremail, false, includeNonInitialized);
         AddObjectProperty("SecUserEmail_N", gxTv_SdtUsuario_Secuseremail_N, false, includeNonInitialized);
         AddObjectProperty("SecUserStatus", gxTv_SdtUsuario_Secuserstatus, false, includeNonInitialized);
         AddObjectProperty("SecUserStatus_N", gxTv_SdtUsuario_Secuserstatus_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtUsuario_Secusercreatedat;
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
         AddObjectProperty("SecUserCreatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("SecUserCreatedAt_N", gxTv_SdtUsuario_Secusercreatedat_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtUsuario_Secuserupdateat;
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
         AddObjectProperty("SecUserUpdateAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("SecUserUpdateAt_N", gxTv_SdtUsuario_Secuserupdateat_N, false, includeNonInitialized);
         AddObjectProperty("SecUserClienteId", gxTv_SdtUsuario_Secuserclienteid, false, includeNonInitialized);
         AddObjectProperty("SecUserClienteId_N", gxTv_SdtUsuario_Secuserclienteid_N, false, includeNonInitialized);
         AddObjectProperty("SecUserOwnerId", gxTv_SdtUsuario_Secuserownerid, false, includeNonInitialized);
         AddObjectProperty("SecUserOwnerId_N", gxTv_SdtUsuario_Secuserownerid_N, false, includeNonInitialized);
         AddObjectProperty("SecUserUserMan", gxTv_SdtUsuario_Secuseruserman, false, includeNonInitialized);
         AddObjectProperty("SecUserUserMan_N", gxTv_SdtUsuario_Secuseruserman_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtUsuario_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtUsuario_Initialized, false, includeNonInitialized);
            AddObjectProperty("SecUserId_Z", gxTv_SdtUsuario_Secuserid_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserName_Z", gxTv_SdtUsuario_Secusername_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserFullName_Z", gxTv_SdtUsuario_Secuserfullname_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserEmail_Z", gxTv_SdtUsuario_Secuseremail_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserStatus_Z", gxTv_SdtUsuario_Secuserstatus_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtUsuario_Secusercreatedat_Z;
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
            AddObjectProperty("SecUserCreatedAt_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtUsuario_Secuserupdateat_Z;
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
            AddObjectProperty("SecUserUpdateAt_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("SecUserClienteId_Z", gxTv_SdtUsuario_Secuserclienteid_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserOwnerId_Z", gxTv_SdtUsuario_Secuserownerid_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserUserMan_Z", gxTv_SdtUsuario_Secuseruserman_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserId_N", gxTv_SdtUsuario_Secuserid_N, false, includeNonInitialized);
            AddObjectProperty("SecUserName_N", gxTv_SdtUsuario_Secusername_N, false, includeNonInitialized);
            AddObjectProperty("SecUserFullName_N", gxTv_SdtUsuario_Secuserfullname_N, false, includeNonInitialized);
            AddObjectProperty("SecUserEmail_N", gxTv_SdtUsuario_Secuseremail_N, false, includeNonInitialized);
            AddObjectProperty("SecUserStatus_N", gxTv_SdtUsuario_Secuserstatus_N, false, includeNonInitialized);
            AddObjectProperty("SecUserCreatedAt_N", gxTv_SdtUsuario_Secusercreatedat_N, false, includeNonInitialized);
            AddObjectProperty("SecUserUpdateAt_N", gxTv_SdtUsuario_Secuserupdateat_N, false, includeNonInitialized);
            AddObjectProperty("SecUserClienteId_N", gxTv_SdtUsuario_Secuserclienteid_N, false, includeNonInitialized);
            AddObjectProperty("SecUserOwnerId_N", gxTv_SdtUsuario_Secuserownerid_N, false, includeNonInitialized);
            AddObjectProperty("SecUserUserMan_N", gxTv_SdtUsuario_Secuseruserman_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtUsuario sdt )
      {
         if ( sdt.IsDirty("SecUserId") )
         {
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secuserid = sdt.gxTv_SdtUsuario_Secuserid ;
         }
         if ( sdt.IsDirty("SecUserName") )
         {
            gxTv_SdtUsuario_Secusername_N = (short)(sdt.gxTv_SdtUsuario_Secusername_N);
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secusername = sdt.gxTv_SdtUsuario_Secusername ;
         }
         if ( sdt.IsDirty("SecUserFullName") )
         {
            gxTv_SdtUsuario_Secuserfullname_N = (short)(sdt.gxTv_SdtUsuario_Secuserfullname_N);
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secuserfullname = sdt.gxTv_SdtUsuario_Secuserfullname ;
         }
         if ( sdt.IsDirty("SecUserEmail") )
         {
            gxTv_SdtUsuario_Secuseremail_N = (short)(sdt.gxTv_SdtUsuario_Secuseremail_N);
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secuseremail = sdt.gxTv_SdtUsuario_Secuseremail ;
         }
         if ( sdt.IsDirty("SecUserStatus") )
         {
            gxTv_SdtUsuario_Secuserstatus_N = (short)(sdt.gxTv_SdtUsuario_Secuserstatus_N);
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secuserstatus = sdt.gxTv_SdtUsuario_Secuserstatus ;
         }
         if ( sdt.IsDirty("SecUserCreatedAt") )
         {
            gxTv_SdtUsuario_Secusercreatedat_N = (short)(sdt.gxTv_SdtUsuario_Secusercreatedat_N);
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secusercreatedat = sdt.gxTv_SdtUsuario_Secusercreatedat ;
         }
         if ( sdt.IsDirty("SecUserUpdateAt") )
         {
            gxTv_SdtUsuario_Secuserupdateat_N = (short)(sdt.gxTv_SdtUsuario_Secuserupdateat_N);
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secuserupdateat = sdt.gxTv_SdtUsuario_Secuserupdateat ;
         }
         if ( sdt.IsDirty("SecUserClienteId") )
         {
            gxTv_SdtUsuario_Secuserclienteid_N = (short)(sdt.gxTv_SdtUsuario_Secuserclienteid_N);
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secuserclienteid = sdt.gxTv_SdtUsuario_Secuserclienteid ;
         }
         if ( sdt.IsDirty("SecUserOwnerId") )
         {
            gxTv_SdtUsuario_Secuserownerid_N = (short)(sdt.gxTv_SdtUsuario_Secuserownerid_N);
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secuserownerid = sdt.gxTv_SdtUsuario_Secuserownerid ;
         }
         if ( sdt.IsDirty("SecUserUserMan") )
         {
            gxTv_SdtUsuario_Secuseruserman_N = (short)(sdt.gxTv_SdtUsuario_Secuseruserman_N);
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secuseruserman = sdt.gxTv_SdtUsuario_Secuseruserman ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "SecUserId" )]
      [  XmlElement( ElementName = "SecUserId"   )]
      public short gxTpr_Secuserid
      {
         get {
            return gxTv_SdtUsuario_Secuserid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtUsuario_Secuserid != value )
            {
               gxTv_SdtUsuario_Mode = "INS";
               this.gxTv_SdtUsuario_Secuserid_Z_SetNull( );
               this.gxTv_SdtUsuario_Secusername_Z_SetNull( );
               this.gxTv_SdtUsuario_Secuserfullname_Z_SetNull( );
               this.gxTv_SdtUsuario_Secuseremail_Z_SetNull( );
               this.gxTv_SdtUsuario_Secuserstatus_Z_SetNull( );
               this.gxTv_SdtUsuario_Secusercreatedat_Z_SetNull( );
               this.gxTv_SdtUsuario_Secuserupdateat_Z_SetNull( );
               this.gxTv_SdtUsuario_Secuserclienteid_Z_SetNull( );
               this.gxTv_SdtUsuario_Secuserownerid_Z_SetNull( );
               this.gxTv_SdtUsuario_Secuseruserman_Z_SetNull( );
            }
            gxTv_SdtUsuario_Secuserid = value;
            SetDirty("Secuserid");
         }

      }

      [  SoapElement( ElementName = "SecUserName" )]
      [  XmlElement( ElementName = "SecUserName"   )]
      public string gxTpr_Secusername
      {
         get {
            return gxTv_SdtUsuario_Secusername ;
         }

         set {
            gxTv_SdtUsuario_Secusername_N = 0;
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secusername = value;
            SetDirty("Secusername");
         }

      }

      public void gxTv_SdtUsuario_Secusername_SetNull( )
      {
         gxTv_SdtUsuario_Secusername_N = 1;
         gxTv_SdtUsuario_Secusername = "";
         SetDirty("Secusername");
         return  ;
      }

      public bool gxTv_SdtUsuario_Secusername_IsNull( )
      {
         return (gxTv_SdtUsuario_Secusername_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserFullName" )]
      [  XmlElement( ElementName = "SecUserFullName"   )]
      public string gxTpr_Secuserfullname
      {
         get {
            return gxTv_SdtUsuario_Secuserfullname ;
         }

         set {
            gxTv_SdtUsuario_Secuserfullname_N = 0;
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secuserfullname = value;
            SetDirty("Secuserfullname");
         }

      }

      public void gxTv_SdtUsuario_Secuserfullname_SetNull( )
      {
         gxTv_SdtUsuario_Secuserfullname_N = 1;
         gxTv_SdtUsuario_Secuserfullname = "";
         SetDirty("Secuserfullname");
         return  ;
      }

      public bool gxTv_SdtUsuario_Secuserfullname_IsNull( )
      {
         return (gxTv_SdtUsuario_Secuserfullname_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserEmail" )]
      [  XmlElement( ElementName = "SecUserEmail"   )]
      public string gxTpr_Secuseremail
      {
         get {
            return gxTv_SdtUsuario_Secuseremail ;
         }

         set {
            gxTv_SdtUsuario_Secuseremail_N = 0;
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secuseremail = value;
            SetDirty("Secuseremail");
         }

      }

      public void gxTv_SdtUsuario_Secuseremail_SetNull( )
      {
         gxTv_SdtUsuario_Secuseremail_N = 1;
         gxTv_SdtUsuario_Secuseremail = "";
         SetDirty("Secuseremail");
         return  ;
      }

      public bool gxTv_SdtUsuario_Secuseremail_IsNull( )
      {
         return (gxTv_SdtUsuario_Secuseremail_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserStatus" )]
      [  XmlElement( ElementName = "SecUserStatus"   )]
      public bool gxTpr_Secuserstatus
      {
         get {
            return gxTv_SdtUsuario_Secuserstatus ;
         }

         set {
            gxTv_SdtUsuario_Secuserstatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secuserstatus = value;
            SetDirty("Secuserstatus");
         }

      }

      public void gxTv_SdtUsuario_Secuserstatus_SetNull( )
      {
         gxTv_SdtUsuario_Secuserstatus_N = 1;
         gxTv_SdtUsuario_Secuserstatus = false;
         SetDirty("Secuserstatus");
         return  ;
      }

      public bool gxTv_SdtUsuario_Secuserstatus_IsNull( )
      {
         return (gxTv_SdtUsuario_Secuserstatus_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserCreatedAt" )]
      [  XmlElement( ElementName = "SecUserCreatedAt"  , IsNullable=true )]
      public string gxTpr_Secusercreatedat_Nullable
      {
         get {
            if ( gxTv_SdtUsuario_Secusercreatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtUsuario_Secusercreatedat).value ;
         }

         set {
            gxTv_SdtUsuario_Secusercreatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtUsuario_Secusercreatedat = DateTime.MinValue;
            else
               gxTv_SdtUsuario_Secusercreatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Secusercreatedat
      {
         get {
            return gxTv_SdtUsuario_Secusercreatedat ;
         }

         set {
            gxTv_SdtUsuario_Secusercreatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secusercreatedat = value;
            SetDirty("Secusercreatedat");
         }

      }

      public void gxTv_SdtUsuario_Secusercreatedat_SetNull( )
      {
         gxTv_SdtUsuario_Secusercreatedat_N = 1;
         gxTv_SdtUsuario_Secusercreatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Secusercreatedat");
         return  ;
      }

      public bool gxTv_SdtUsuario_Secusercreatedat_IsNull( )
      {
         return (gxTv_SdtUsuario_Secusercreatedat_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserUpdateAt" )]
      [  XmlElement( ElementName = "SecUserUpdateAt"  , IsNullable=true )]
      public string gxTpr_Secuserupdateat_Nullable
      {
         get {
            if ( gxTv_SdtUsuario_Secuserupdateat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtUsuario_Secuserupdateat).value ;
         }

         set {
            gxTv_SdtUsuario_Secuserupdateat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtUsuario_Secuserupdateat = DateTime.MinValue;
            else
               gxTv_SdtUsuario_Secuserupdateat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Secuserupdateat
      {
         get {
            return gxTv_SdtUsuario_Secuserupdateat ;
         }

         set {
            gxTv_SdtUsuario_Secuserupdateat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secuserupdateat = value;
            SetDirty("Secuserupdateat");
         }

      }

      public void gxTv_SdtUsuario_Secuserupdateat_SetNull( )
      {
         gxTv_SdtUsuario_Secuserupdateat_N = 1;
         gxTv_SdtUsuario_Secuserupdateat = (DateTime)(DateTime.MinValue);
         SetDirty("Secuserupdateat");
         return  ;
      }

      public bool gxTv_SdtUsuario_Secuserupdateat_IsNull( )
      {
         return (gxTv_SdtUsuario_Secuserupdateat_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserClienteId" )]
      [  XmlElement( ElementName = "SecUserClienteId"   )]
      public short gxTpr_Secuserclienteid
      {
         get {
            return gxTv_SdtUsuario_Secuserclienteid ;
         }

         set {
            gxTv_SdtUsuario_Secuserclienteid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secuserclienteid = value;
            SetDirty("Secuserclienteid");
         }

      }

      public void gxTv_SdtUsuario_Secuserclienteid_SetNull( )
      {
         gxTv_SdtUsuario_Secuserclienteid_N = 1;
         gxTv_SdtUsuario_Secuserclienteid = 0;
         SetDirty("Secuserclienteid");
         return  ;
      }

      public bool gxTv_SdtUsuario_Secuserclienteid_IsNull( )
      {
         return (gxTv_SdtUsuario_Secuserclienteid_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserOwnerId" )]
      [  XmlElement( ElementName = "SecUserOwnerId"   )]
      public int gxTpr_Secuserownerid
      {
         get {
            return gxTv_SdtUsuario_Secuserownerid ;
         }

         set {
            gxTv_SdtUsuario_Secuserownerid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secuserownerid = value;
            SetDirty("Secuserownerid");
         }

      }

      public void gxTv_SdtUsuario_Secuserownerid_SetNull( )
      {
         gxTv_SdtUsuario_Secuserownerid_N = 1;
         gxTv_SdtUsuario_Secuserownerid = 0;
         SetDirty("Secuserownerid");
         return  ;
      }

      public bool gxTv_SdtUsuario_Secuserownerid_IsNull( )
      {
         return (gxTv_SdtUsuario_Secuserownerid_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserUserMan" )]
      [  XmlElement( ElementName = "SecUserUserMan"   )]
      public short gxTpr_Secuseruserman
      {
         get {
            return gxTv_SdtUsuario_Secuseruserman ;
         }

         set {
            gxTv_SdtUsuario_Secuseruserman_N = 0;
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secuseruserman = value;
            SetDirty("Secuseruserman");
         }

      }

      public void gxTv_SdtUsuario_Secuseruserman_SetNull( )
      {
         gxTv_SdtUsuario_Secuseruserman_N = 1;
         gxTv_SdtUsuario_Secuseruserman = 0;
         SetDirty("Secuseruserman");
         return  ;
      }

      public bool gxTv_SdtUsuario_Secuseruserman_IsNull( )
      {
         return (gxTv_SdtUsuario_Secuseruserman_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtUsuario_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUsuario_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtUsuario_Mode_SetNull( )
      {
         gxTv_SdtUsuario_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtUsuario_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtUsuario_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUsuario_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtUsuario_Initialized_SetNull( )
      {
         gxTv_SdtUsuario_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtUsuario_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserId_Z" )]
      [  XmlElement( ElementName = "SecUserId_Z"   )]
      public short gxTpr_Secuserid_Z
      {
         get {
            return gxTv_SdtUsuario_Secuserid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secuserid_Z = value;
            SetDirty("Secuserid_Z");
         }

      }

      public void gxTv_SdtUsuario_Secuserid_Z_SetNull( )
      {
         gxTv_SdtUsuario_Secuserid_Z = 0;
         SetDirty("Secuserid_Z");
         return  ;
      }

      public bool gxTv_SdtUsuario_Secuserid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserName_Z" )]
      [  XmlElement( ElementName = "SecUserName_Z"   )]
      public string gxTpr_Secusername_Z
      {
         get {
            return gxTv_SdtUsuario_Secusername_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secusername_Z = value;
            SetDirty("Secusername_Z");
         }

      }

      public void gxTv_SdtUsuario_Secusername_Z_SetNull( )
      {
         gxTv_SdtUsuario_Secusername_Z = "";
         SetDirty("Secusername_Z");
         return  ;
      }

      public bool gxTv_SdtUsuario_Secusername_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserFullName_Z" )]
      [  XmlElement( ElementName = "SecUserFullName_Z"   )]
      public string gxTpr_Secuserfullname_Z
      {
         get {
            return gxTv_SdtUsuario_Secuserfullname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secuserfullname_Z = value;
            SetDirty("Secuserfullname_Z");
         }

      }

      public void gxTv_SdtUsuario_Secuserfullname_Z_SetNull( )
      {
         gxTv_SdtUsuario_Secuserfullname_Z = "";
         SetDirty("Secuserfullname_Z");
         return  ;
      }

      public bool gxTv_SdtUsuario_Secuserfullname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserEmail_Z" )]
      [  XmlElement( ElementName = "SecUserEmail_Z"   )]
      public string gxTpr_Secuseremail_Z
      {
         get {
            return gxTv_SdtUsuario_Secuseremail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secuseremail_Z = value;
            SetDirty("Secuseremail_Z");
         }

      }

      public void gxTv_SdtUsuario_Secuseremail_Z_SetNull( )
      {
         gxTv_SdtUsuario_Secuseremail_Z = "";
         SetDirty("Secuseremail_Z");
         return  ;
      }

      public bool gxTv_SdtUsuario_Secuseremail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserStatus_Z" )]
      [  XmlElement( ElementName = "SecUserStatus_Z"   )]
      public bool gxTpr_Secuserstatus_Z
      {
         get {
            return gxTv_SdtUsuario_Secuserstatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secuserstatus_Z = value;
            SetDirty("Secuserstatus_Z");
         }

      }

      public void gxTv_SdtUsuario_Secuserstatus_Z_SetNull( )
      {
         gxTv_SdtUsuario_Secuserstatus_Z = false;
         SetDirty("Secuserstatus_Z");
         return  ;
      }

      public bool gxTv_SdtUsuario_Secuserstatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserCreatedAt_Z" )]
      [  XmlElement( ElementName = "SecUserCreatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Secusercreatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtUsuario_Secusercreatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtUsuario_Secusercreatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtUsuario_Secusercreatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtUsuario_Secusercreatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Secusercreatedat_Z
      {
         get {
            return gxTv_SdtUsuario_Secusercreatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secusercreatedat_Z = value;
            SetDirty("Secusercreatedat_Z");
         }

      }

      public void gxTv_SdtUsuario_Secusercreatedat_Z_SetNull( )
      {
         gxTv_SdtUsuario_Secusercreatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Secusercreatedat_Z");
         return  ;
      }

      public bool gxTv_SdtUsuario_Secusercreatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserUpdateAt_Z" )]
      [  XmlElement( ElementName = "SecUserUpdateAt_Z"  , IsNullable=true )]
      public string gxTpr_Secuserupdateat_Z_Nullable
      {
         get {
            if ( gxTv_SdtUsuario_Secuserupdateat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtUsuario_Secuserupdateat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtUsuario_Secuserupdateat_Z = DateTime.MinValue;
            else
               gxTv_SdtUsuario_Secuserupdateat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Secuserupdateat_Z
      {
         get {
            return gxTv_SdtUsuario_Secuserupdateat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secuserupdateat_Z = value;
            SetDirty("Secuserupdateat_Z");
         }

      }

      public void gxTv_SdtUsuario_Secuserupdateat_Z_SetNull( )
      {
         gxTv_SdtUsuario_Secuserupdateat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Secuserupdateat_Z");
         return  ;
      }

      public bool gxTv_SdtUsuario_Secuserupdateat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserClienteId_Z" )]
      [  XmlElement( ElementName = "SecUserClienteId_Z"   )]
      public short gxTpr_Secuserclienteid_Z
      {
         get {
            return gxTv_SdtUsuario_Secuserclienteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secuserclienteid_Z = value;
            SetDirty("Secuserclienteid_Z");
         }

      }

      public void gxTv_SdtUsuario_Secuserclienteid_Z_SetNull( )
      {
         gxTv_SdtUsuario_Secuserclienteid_Z = 0;
         SetDirty("Secuserclienteid_Z");
         return  ;
      }

      public bool gxTv_SdtUsuario_Secuserclienteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserOwnerId_Z" )]
      [  XmlElement( ElementName = "SecUserOwnerId_Z"   )]
      public int gxTpr_Secuserownerid_Z
      {
         get {
            return gxTv_SdtUsuario_Secuserownerid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secuserownerid_Z = value;
            SetDirty("Secuserownerid_Z");
         }

      }

      public void gxTv_SdtUsuario_Secuserownerid_Z_SetNull( )
      {
         gxTv_SdtUsuario_Secuserownerid_Z = 0;
         SetDirty("Secuserownerid_Z");
         return  ;
      }

      public bool gxTv_SdtUsuario_Secuserownerid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserUserMan_Z" )]
      [  XmlElement( ElementName = "SecUserUserMan_Z"   )]
      public short gxTpr_Secuseruserman_Z
      {
         get {
            return gxTv_SdtUsuario_Secuseruserman_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secuseruserman_Z = value;
            SetDirty("Secuseruserman_Z");
         }

      }

      public void gxTv_SdtUsuario_Secuseruserman_Z_SetNull( )
      {
         gxTv_SdtUsuario_Secuseruserman_Z = 0;
         SetDirty("Secuseruserman_Z");
         return  ;
      }

      public bool gxTv_SdtUsuario_Secuseruserman_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserId_N" )]
      [  XmlElement( ElementName = "SecUserId_N"   )]
      public short gxTpr_Secuserid_N
      {
         get {
            return gxTv_SdtUsuario_Secuserid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secuserid_N = value;
            SetDirty("Secuserid_N");
         }

      }

      public void gxTv_SdtUsuario_Secuserid_N_SetNull( )
      {
         gxTv_SdtUsuario_Secuserid_N = 0;
         SetDirty("Secuserid_N");
         return  ;
      }

      public bool gxTv_SdtUsuario_Secuserid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserName_N" )]
      [  XmlElement( ElementName = "SecUserName_N"   )]
      public short gxTpr_Secusername_N
      {
         get {
            return gxTv_SdtUsuario_Secusername_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secusername_N = value;
            SetDirty("Secusername_N");
         }

      }

      public void gxTv_SdtUsuario_Secusername_N_SetNull( )
      {
         gxTv_SdtUsuario_Secusername_N = 0;
         SetDirty("Secusername_N");
         return  ;
      }

      public bool gxTv_SdtUsuario_Secusername_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserFullName_N" )]
      [  XmlElement( ElementName = "SecUserFullName_N"   )]
      public short gxTpr_Secuserfullname_N
      {
         get {
            return gxTv_SdtUsuario_Secuserfullname_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secuserfullname_N = value;
            SetDirty("Secuserfullname_N");
         }

      }

      public void gxTv_SdtUsuario_Secuserfullname_N_SetNull( )
      {
         gxTv_SdtUsuario_Secuserfullname_N = 0;
         SetDirty("Secuserfullname_N");
         return  ;
      }

      public bool gxTv_SdtUsuario_Secuserfullname_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserEmail_N" )]
      [  XmlElement( ElementName = "SecUserEmail_N"   )]
      public short gxTpr_Secuseremail_N
      {
         get {
            return gxTv_SdtUsuario_Secuseremail_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secuseremail_N = value;
            SetDirty("Secuseremail_N");
         }

      }

      public void gxTv_SdtUsuario_Secuseremail_N_SetNull( )
      {
         gxTv_SdtUsuario_Secuseremail_N = 0;
         SetDirty("Secuseremail_N");
         return  ;
      }

      public bool gxTv_SdtUsuario_Secuseremail_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserStatus_N" )]
      [  XmlElement( ElementName = "SecUserStatus_N"   )]
      public short gxTpr_Secuserstatus_N
      {
         get {
            return gxTv_SdtUsuario_Secuserstatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secuserstatus_N = value;
            SetDirty("Secuserstatus_N");
         }

      }

      public void gxTv_SdtUsuario_Secuserstatus_N_SetNull( )
      {
         gxTv_SdtUsuario_Secuserstatus_N = 0;
         SetDirty("Secuserstatus_N");
         return  ;
      }

      public bool gxTv_SdtUsuario_Secuserstatus_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserCreatedAt_N" )]
      [  XmlElement( ElementName = "SecUserCreatedAt_N"   )]
      public short gxTpr_Secusercreatedat_N
      {
         get {
            return gxTv_SdtUsuario_Secusercreatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secusercreatedat_N = value;
            SetDirty("Secusercreatedat_N");
         }

      }

      public void gxTv_SdtUsuario_Secusercreatedat_N_SetNull( )
      {
         gxTv_SdtUsuario_Secusercreatedat_N = 0;
         SetDirty("Secusercreatedat_N");
         return  ;
      }

      public bool gxTv_SdtUsuario_Secusercreatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserUpdateAt_N" )]
      [  XmlElement( ElementName = "SecUserUpdateAt_N"   )]
      public short gxTpr_Secuserupdateat_N
      {
         get {
            return gxTv_SdtUsuario_Secuserupdateat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secuserupdateat_N = value;
            SetDirty("Secuserupdateat_N");
         }

      }

      public void gxTv_SdtUsuario_Secuserupdateat_N_SetNull( )
      {
         gxTv_SdtUsuario_Secuserupdateat_N = 0;
         SetDirty("Secuserupdateat_N");
         return  ;
      }

      public bool gxTv_SdtUsuario_Secuserupdateat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserClienteId_N" )]
      [  XmlElement( ElementName = "SecUserClienteId_N"   )]
      public short gxTpr_Secuserclienteid_N
      {
         get {
            return gxTv_SdtUsuario_Secuserclienteid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secuserclienteid_N = value;
            SetDirty("Secuserclienteid_N");
         }

      }

      public void gxTv_SdtUsuario_Secuserclienteid_N_SetNull( )
      {
         gxTv_SdtUsuario_Secuserclienteid_N = 0;
         SetDirty("Secuserclienteid_N");
         return  ;
      }

      public bool gxTv_SdtUsuario_Secuserclienteid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserOwnerId_N" )]
      [  XmlElement( ElementName = "SecUserOwnerId_N"   )]
      public short gxTpr_Secuserownerid_N
      {
         get {
            return gxTv_SdtUsuario_Secuserownerid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secuserownerid_N = value;
            SetDirty("Secuserownerid_N");
         }

      }

      public void gxTv_SdtUsuario_Secuserownerid_N_SetNull( )
      {
         gxTv_SdtUsuario_Secuserownerid_N = 0;
         SetDirty("Secuserownerid_N");
         return  ;
      }

      public bool gxTv_SdtUsuario_Secuserownerid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserUserMan_N" )]
      [  XmlElement( ElementName = "SecUserUserMan_N"   )]
      public short gxTpr_Secuseruserman_N
      {
         get {
            return gxTv_SdtUsuario_Secuseruserman_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtUsuario_Secuseruserman_N = value;
            SetDirty("Secuseruserman_N");
         }

      }

      public void gxTv_SdtUsuario_Secuseruserman_N_SetNull( )
      {
         gxTv_SdtUsuario_Secuseruserman_N = 0;
         SetDirty("Secuseruserman_N");
         return  ;
      }

      public bool gxTv_SdtUsuario_Secuseruserman_N_IsNull( )
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
         gxTv_SdtUsuario_Secusername = "";
         gxTv_SdtUsuario_Secuserfullname = "";
         gxTv_SdtUsuario_Secuseremail = "";
         gxTv_SdtUsuario_Secusercreatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtUsuario_Secuserupdateat = (DateTime)(DateTime.MinValue);
         gxTv_SdtUsuario_Mode = "";
         gxTv_SdtUsuario_Secusername_Z = "";
         gxTv_SdtUsuario_Secuserfullname_Z = "";
         gxTv_SdtUsuario_Secuseremail_Z = "";
         gxTv_SdtUsuario_Secusercreatedat_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtUsuario_Secuserupdateat_Z = (DateTime)(DateTime.MinValue);
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "usuario", "GeneXus.Programs.usuario_bc", new Object[] {context}, constructorCallingAssembly);;
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

      private short gxTv_SdtUsuario_Secuserid ;
      private short sdtIsNull ;
      private short gxTv_SdtUsuario_Secuserclienteid ;
      private short gxTv_SdtUsuario_Secuseruserman ;
      private short gxTv_SdtUsuario_Initialized ;
      private short gxTv_SdtUsuario_Secuserid_Z ;
      private short gxTv_SdtUsuario_Secuserclienteid_Z ;
      private short gxTv_SdtUsuario_Secuseruserman_Z ;
      private short gxTv_SdtUsuario_Secuserid_N ;
      private short gxTv_SdtUsuario_Secusername_N ;
      private short gxTv_SdtUsuario_Secuserfullname_N ;
      private short gxTv_SdtUsuario_Secuseremail_N ;
      private short gxTv_SdtUsuario_Secuserstatus_N ;
      private short gxTv_SdtUsuario_Secusercreatedat_N ;
      private short gxTv_SdtUsuario_Secuserupdateat_N ;
      private short gxTv_SdtUsuario_Secuserclienteid_N ;
      private short gxTv_SdtUsuario_Secuserownerid_N ;
      private short gxTv_SdtUsuario_Secuseruserman_N ;
      private int gxTv_SdtUsuario_Secuserownerid ;
      private int gxTv_SdtUsuario_Secuserownerid_Z ;
      private string gxTv_SdtUsuario_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtUsuario_Secusercreatedat ;
      private DateTime gxTv_SdtUsuario_Secuserupdateat ;
      private DateTime gxTv_SdtUsuario_Secusercreatedat_Z ;
      private DateTime gxTv_SdtUsuario_Secuserupdateat_Z ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtUsuario_Secuserstatus ;
      private bool gxTv_SdtUsuario_Secuserstatus_Z ;
      private string gxTv_SdtUsuario_Secusername ;
      private string gxTv_SdtUsuario_Secuserfullname ;
      private string gxTv_SdtUsuario_Secuseremail ;
      private string gxTv_SdtUsuario_Secusername_Z ;
      private string gxTv_SdtUsuario_Secuserfullname_Z ;
      private string gxTv_SdtUsuario_Secuseremail_Z ;
   }

   [DataContract(Name = @"Usuario", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtUsuario_RESTInterface : GxGenericCollectionItem<SdtUsuario>
   {
      public SdtUsuario_RESTInterface( ) : base()
      {
      }

      public SdtUsuario_RESTInterface( SdtUsuario psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SecUserId" , Order = 0 )]
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

      [DataMember( Name = "SecUserName" , Order = 1 )]
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

      [DataMember( Name = "SecUserFullName" , Order = 2 )]
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

      [DataMember( Name = "SecUserEmail" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Secuseremail
      {
         get {
            return sdt.gxTpr_Secuseremail ;
         }

         set {
            sdt.gxTpr_Secuseremail = value;
         }

      }

      [DataMember( Name = "SecUserStatus" , Order = 4 )]
      [GxSeudo()]
      public bool gxTpr_Secuserstatus
      {
         get {
            return sdt.gxTpr_Secuserstatus ;
         }

         set {
            sdt.gxTpr_Secuserstatus = value;
         }

      }

      [DataMember( Name = "SecUserCreatedAt" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Secusercreatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Secusercreatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Secusercreatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "SecUserUpdateAt" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Secuserupdateat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Secuserupdateat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Secuserupdateat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "SecUserClienteId" , Order = 7 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Secuserclienteid
      {
         get {
            return sdt.gxTpr_Secuserclienteid ;
         }

         set {
            sdt.gxTpr_Secuserclienteid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "SecUserOwnerId" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Secuserownerid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Secuserownerid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Secuserownerid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "SecUserUserMan" , Order = 9 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Secuseruserman
      {
         get {
            return sdt.gxTpr_Secuseruserman ;
         }

         set {
            sdt.gxTpr_Secuseruserman = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtUsuario sdt
      {
         get {
            return (SdtUsuario)Sdt ;
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
            sdt = new SdtUsuario() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 10 )]
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

   [DataContract(Name = @"Usuario", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtUsuario_RESTLInterface : GxGenericCollectionItem<SdtUsuario>
   {
      public SdtUsuario_RESTLInterface( ) : base()
      {
      }

      public SdtUsuario_RESTLInterface( SdtUsuario psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SecUserName" , Order = 0 )]
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

      [DataMember( Name = "uri" , Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtUsuario sdt
      {
         get {
            return (SdtUsuario)Sdt ;
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
            sdt = new SdtUsuario() ;
         }
      }

   }

}
