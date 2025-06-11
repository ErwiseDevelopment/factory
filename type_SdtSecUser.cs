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
   [XmlRoot(ElementName = "SecUser" )]
   [XmlType(TypeName =  "SecUser" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtSecUser : GxSilentTrnSdt
   {
      public SdtSecUser( )
      {
      }

      public SdtSecUser( IGxContext context )
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
         metadata.Set("Name", "SecUser");
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
         state.Add("gxTpr_Secuserpassword_Z");
         state.Add("gxTpr_Secuseranalista_Z");
         state.Add("gxTpr_Secusercreatedat_Z_Nullable");
         state.Add("gxTpr_Secuserupdateat_Z_Nullable");
         state.Add("gxTpr_Secuseruserman_Z");
         state.Add("gxTpr_Secusermanname_Z");
         state.Add("gxTpr_Secusermanfullname_Z");
         state.Add("gxTpr_Secusertemp_Z");
         state.Add("gxTpr_Secuserclienteacesso_Z");
         state.Add("gxTpr_Secuserclienteid_Z");
         state.Add("gxTpr_Secuserclientefullname_Z");
         state.Add("gxTpr_Secuserclientestatus_Z");
         state.Add("gxTpr_Secusercliclienteacesso_Z");
         state.Add("gxTpr_Secuserownerid_Z");
         state.Add("gxTpr_Tipoclienteportalpjpf_Z");
         state.Add("gxTpr_Secuserid_N");
         state.Add("gxTpr_Secusername_N");
         state.Add("gxTpr_Secuserfullname_N");
         state.Add("gxTpr_Secuseremail_N");
         state.Add("gxTpr_Secuserstatus_N");
         state.Add("gxTpr_Secuserpassword_N");
         state.Add("gxTpr_Secuseranalista_N");
         state.Add("gxTpr_Secusercreatedat_N");
         state.Add("gxTpr_Secuserupdateat_N");
         state.Add("gxTpr_Secuseruserman_N");
         state.Add("gxTpr_Secusermanname_N");
         state.Add("gxTpr_Secusermanfullname_N");
         state.Add("gxTpr_Secusertemp_N");
         state.Add("gxTpr_Secuserclienteacesso_N");
         state.Add("gxTpr_Secuserteste_N");
         state.Add("gxTpr_Secuserclienteid_N");
         state.Add("gxTpr_Secuserclientefullname_N");
         state.Add("gxTpr_Secuserclientestatus_N");
         state.Add("gxTpr_Secusercliclienteacesso_N");
         state.Add("gxTpr_Secuserownerid_N");
         state.Add("gxTpr_Tipoclienteportalpjpf_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtSecUser sdt;
         sdt = (SdtSecUser)(source);
         gxTv_SdtSecUser_Secuserid = sdt.gxTv_SdtSecUser_Secuserid ;
         gxTv_SdtSecUser_Secusername = sdt.gxTv_SdtSecUser_Secusername ;
         gxTv_SdtSecUser_Secuserfullname = sdt.gxTv_SdtSecUser_Secuserfullname ;
         gxTv_SdtSecUser_Secuseremail = sdt.gxTv_SdtSecUser_Secuseremail ;
         gxTv_SdtSecUser_Secuserstatus = sdt.gxTv_SdtSecUser_Secuserstatus ;
         gxTv_SdtSecUser_Secuserpassword = sdt.gxTv_SdtSecUser_Secuserpassword ;
         gxTv_SdtSecUser_Secuseranalista = sdt.gxTv_SdtSecUser_Secuseranalista ;
         gxTv_SdtSecUser_Secusercreatedat = sdt.gxTv_SdtSecUser_Secusercreatedat ;
         gxTv_SdtSecUser_Secuserupdateat = sdt.gxTv_SdtSecUser_Secuserupdateat ;
         gxTv_SdtSecUser_Secuseruserman = sdt.gxTv_SdtSecUser_Secuseruserman ;
         gxTv_SdtSecUser_Secusermanname = sdt.gxTv_SdtSecUser_Secusermanname ;
         gxTv_SdtSecUser_Secusermanfullname = sdt.gxTv_SdtSecUser_Secusermanfullname ;
         gxTv_SdtSecUser_Secusertemp = sdt.gxTv_SdtSecUser_Secusertemp ;
         gxTv_SdtSecUser_Secuserclienteacesso = sdt.gxTv_SdtSecUser_Secuserclienteacesso ;
         gxTv_SdtSecUser_Secuserteste = sdt.gxTv_SdtSecUser_Secuserteste ;
         gxTv_SdtSecUser_Secuserclienteid = sdt.gxTv_SdtSecUser_Secuserclienteid ;
         gxTv_SdtSecUser_Secuserclientefullname = sdt.gxTv_SdtSecUser_Secuserclientefullname ;
         gxTv_SdtSecUser_Secuserclientestatus = sdt.gxTv_SdtSecUser_Secuserclientestatus ;
         gxTv_SdtSecUser_Secusercliclienteacesso = sdt.gxTv_SdtSecUser_Secusercliclienteacesso ;
         gxTv_SdtSecUser_Secuserownerid = sdt.gxTv_SdtSecUser_Secuserownerid ;
         gxTv_SdtSecUser_Tipoclienteportalpjpf = sdt.gxTv_SdtSecUser_Tipoclienteportalpjpf ;
         gxTv_SdtSecUser_Mode = sdt.gxTv_SdtSecUser_Mode ;
         gxTv_SdtSecUser_Initialized = sdt.gxTv_SdtSecUser_Initialized ;
         gxTv_SdtSecUser_Secuserid_Z = sdt.gxTv_SdtSecUser_Secuserid_Z ;
         gxTv_SdtSecUser_Secusername_Z = sdt.gxTv_SdtSecUser_Secusername_Z ;
         gxTv_SdtSecUser_Secuserfullname_Z = sdt.gxTv_SdtSecUser_Secuserfullname_Z ;
         gxTv_SdtSecUser_Secuseremail_Z = sdt.gxTv_SdtSecUser_Secuseremail_Z ;
         gxTv_SdtSecUser_Secuserstatus_Z = sdt.gxTv_SdtSecUser_Secuserstatus_Z ;
         gxTv_SdtSecUser_Secuserpassword_Z = sdt.gxTv_SdtSecUser_Secuserpassword_Z ;
         gxTv_SdtSecUser_Secuseranalista_Z = sdt.gxTv_SdtSecUser_Secuseranalista_Z ;
         gxTv_SdtSecUser_Secusercreatedat_Z = sdt.gxTv_SdtSecUser_Secusercreatedat_Z ;
         gxTv_SdtSecUser_Secuserupdateat_Z = sdt.gxTv_SdtSecUser_Secuserupdateat_Z ;
         gxTv_SdtSecUser_Secuseruserman_Z = sdt.gxTv_SdtSecUser_Secuseruserman_Z ;
         gxTv_SdtSecUser_Secusermanname_Z = sdt.gxTv_SdtSecUser_Secusermanname_Z ;
         gxTv_SdtSecUser_Secusermanfullname_Z = sdt.gxTv_SdtSecUser_Secusermanfullname_Z ;
         gxTv_SdtSecUser_Secusertemp_Z = sdt.gxTv_SdtSecUser_Secusertemp_Z ;
         gxTv_SdtSecUser_Secuserclienteacesso_Z = sdt.gxTv_SdtSecUser_Secuserclienteacesso_Z ;
         gxTv_SdtSecUser_Secuserclienteid_Z = sdt.gxTv_SdtSecUser_Secuserclienteid_Z ;
         gxTv_SdtSecUser_Secuserclientefullname_Z = sdt.gxTv_SdtSecUser_Secuserclientefullname_Z ;
         gxTv_SdtSecUser_Secuserclientestatus_Z = sdt.gxTv_SdtSecUser_Secuserclientestatus_Z ;
         gxTv_SdtSecUser_Secusercliclienteacesso_Z = sdt.gxTv_SdtSecUser_Secusercliclienteacesso_Z ;
         gxTv_SdtSecUser_Secuserownerid_Z = sdt.gxTv_SdtSecUser_Secuserownerid_Z ;
         gxTv_SdtSecUser_Tipoclienteportalpjpf_Z = sdt.gxTv_SdtSecUser_Tipoclienteportalpjpf_Z ;
         gxTv_SdtSecUser_Secuserid_N = sdt.gxTv_SdtSecUser_Secuserid_N ;
         gxTv_SdtSecUser_Secusername_N = sdt.gxTv_SdtSecUser_Secusername_N ;
         gxTv_SdtSecUser_Secuserfullname_N = sdt.gxTv_SdtSecUser_Secuserfullname_N ;
         gxTv_SdtSecUser_Secuseremail_N = sdt.gxTv_SdtSecUser_Secuseremail_N ;
         gxTv_SdtSecUser_Secuserstatus_N = sdt.gxTv_SdtSecUser_Secuserstatus_N ;
         gxTv_SdtSecUser_Secuserpassword_N = sdt.gxTv_SdtSecUser_Secuserpassword_N ;
         gxTv_SdtSecUser_Secuseranalista_N = sdt.gxTv_SdtSecUser_Secuseranalista_N ;
         gxTv_SdtSecUser_Secusercreatedat_N = sdt.gxTv_SdtSecUser_Secusercreatedat_N ;
         gxTv_SdtSecUser_Secuserupdateat_N = sdt.gxTv_SdtSecUser_Secuserupdateat_N ;
         gxTv_SdtSecUser_Secuseruserman_N = sdt.gxTv_SdtSecUser_Secuseruserman_N ;
         gxTv_SdtSecUser_Secusermanname_N = sdt.gxTv_SdtSecUser_Secusermanname_N ;
         gxTv_SdtSecUser_Secusermanfullname_N = sdt.gxTv_SdtSecUser_Secusermanfullname_N ;
         gxTv_SdtSecUser_Secusertemp_N = sdt.gxTv_SdtSecUser_Secusertemp_N ;
         gxTv_SdtSecUser_Secuserclienteacesso_N = sdt.gxTv_SdtSecUser_Secuserclienteacesso_N ;
         gxTv_SdtSecUser_Secuserteste_N = sdt.gxTv_SdtSecUser_Secuserteste_N ;
         gxTv_SdtSecUser_Secuserclienteid_N = sdt.gxTv_SdtSecUser_Secuserclienteid_N ;
         gxTv_SdtSecUser_Secuserclientefullname_N = sdt.gxTv_SdtSecUser_Secuserclientefullname_N ;
         gxTv_SdtSecUser_Secuserclientestatus_N = sdt.gxTv_SdtSecUser_Secuserclientestatus_N ;
         gxTv_SdtSecUser_Secusercliclienteacesso_N = sdt.gxTv_SdtSecUser_Secusercliclienteacesso_N ;
         gxTv_SdtSecUser_Secuserownerid_N = sdt.gxTv_SdtSecUser_Secuserownerid_N ;
         gxTv_SdtSecUser_Tipoclienteportalpjpf_N = sdt.gxTv_SdtSecUser_Tipoclienteportalpjpf_N ;
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
         AddObjectProperty("SecUserId", gxTv_SdtSecUser_Secuserid, false, includeNonInitialized);
         AddObjectProperty("SecUserId_N", gxTv_SdtSecUser_Secuserid_N, false, includeNonInitialized);
         AddObjectProperty("SecUserName", gxTv_SdtSecUser_Secusername, false, includeNonInitialized);
         AddObjectProperty("SecUserName_N", gxTv_SdtSecUser_Secusername_N, false, includeNonInitialized);
         AddObjectProperty("SecUserFullName", gxTv_SdtSecUser_Secuserfullname, false, includeNonInitialized);
         AddObjectProperty("SecUserFullName_N", gxTv_SdtSecUser_Secuserfullname_N, false, includeNonInitialized);
         AddObjectProperty("SecUserEmail", gxTv_SdtSecUser_Secuseremail, false, includeNonInitialized);
         AddObjectProperty("SecUserEmail_N", gxTv_SdtSecUser_Secuseremail_N, false, includeNonInitialized);
         AddObjectProperty("SecUserStatus", gxTv_SdtSecUser_Secuserstatus, false, includeNonInitialized);
         AddObjectProperty("SecUserStatus_N", gxTv_SdtSecUser_Secuserstatus_N, false, includeNonInitialized);
         AddObjectProperty("SecUserPassword", gxTv_SdtSecUser_Secuserpassword, false, includeNonInitialized);
         AddObjectProperty("SecUserPassword_N", gxTv_SdtSecUser_Secuserpassword_N, false, includeNonInitialized);
         AddObjectProperty("SecUserAnalista", gxTv_SdtSecUser_Secuseranalista, false, includeNonInitialized);
         AddObjectProperty("SecUserAnalista_N", gxTv_SdtSecUser_Secuseranalista_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtSecUser_Secusercreatedat;
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
         AddObjectProperty("SecUserCreatedAt_N", gxTv_SdtSecUser_Secusercreatedat_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtSecUser_Secuserupdateat;
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
         AddObjectProperty("SecUserUpdateAt_N", gxTv_SdtSecUser_Secuserupdateat_N, false, includeNonInitialized);
         AddObjectProperty("SecUserUserMan", gxTv_SdtSecUser_Secuseruserman, false, includeNonInitialized);
         AddObjectProperty("SecUserUserMan_N", gxTv_SdtSecUser_Secuseruserman_N, false, includeNonInitialized);
         AddObjectProperty("SecUserManName", gxTv_SdtSecUser_Secusermanname, false, includeNonInitialized);
         AddObjectProperty("SecUserManName_N", gxTv_SdtSecUser_Secusermanname_N, false, includeNonInitialized);
         AddObjectProperty("SecUserManFullName", gxTv_SdtSecUser_Secusermanfullname, false, includeNonInitialized);
         AddObjectProperty("SecUserManFullName_N", gxTv_SdtSecUser_Secusermanfullname_N, false, includeNonInitialized);
         AddObjectProperty("SecUserTemp", gxTv_SdtSecUser_Secusertemp, false, includeNonInitialized);
         AddObjectProperty("SecUserTemp_N", gxTv_SdtSecUser_Secusertemp_N, false, includeNonInitialized);
         AddObjectProperty("SecUserClienteAcesso", gxTv_SdtSecUser_Secuserclienteacesso, false, includeNonInitialized);
         AddObjectProperty("SecUserClienteAcesso_N", gxTv_SdtSecUser_Secuserclienteacesso_N, false, includeNonInitialized);
         AddObjectProperty("SecUserTeste", gxTv_SdtSecUser_Secuserteste, false, includeNonInitialized);
         AddObjectProperty("SecUserTeste_N", gxTv_SdtSecUser_Secuserteste_N, false, includeNonInitialized);
         AddObjectProperty("SecUserClienteId", gxTv_SdtSecUser_Secuserclienteid, false, includeNonInitialized);
         AddObjectProperty("SecUserClienteId_N", gxTv_SdtSecUser_Secuserclienteid_N, false, includeNonInitialized);
         AddObjectProperty("SecUserClienteFullName", gxTv_SdtSecUser_Secuserclientefullname, false, includeNonInitialized);
         AddObjectProperty("SecUserClienteFullName_N", gxTv_SdtSecUser_Secuserclientefullname_N, false, includeNonInitialized);
         AddObjectProperty("SecUserClienteStatus", gxTv_SdtSecUser_Secuserclientestatus, false, includeNonInitialized);
         AddObjectProperty("SecUserClienteStatus_N", gxTv_SdtSecUser_Secuserclientestatus_N, false, includeNonInitialized);
         AddObjectProperty("SecUserCliClienteAcesso", gxTv_SdtSecUser_Secusercliclienteacesso, false, includeNonInitialized);
         AddObjectProperty("SecUserCliClienteAcesso_N", gxTv_SdtSecUser_Secusercliclienteacesso_N, false, includeNonInitialized);
         AddObjectProperty("SecUserOwnerId", gxTv_SdtSecUser_Secuserownerid, false, includeNonInitialized);
         AddObjectProperty("SecUserOwnerId_N", gxTv_SdtSecUser_Secuserownerid_N, false, includeNonInitialized);
         AddObjectProperty("TipoClientePortalPjPf", gxTv_SdtSecUser_Tipoclienteportalpjpf, false, includeNonInitialized);
         AddObjectProperty("TipoClientePortalPjPf_N", gxTv_SdtSecUser_Tipoclienteportalpjpf_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtSecUser_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtSecUser_Initialized, false, includeNonInitialized);
            AddObjectProperty("SecUserId_Z", gxTv_SdtSecUser_Secuserid_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserName_Z", gxTv_SdtSecUser_Secusername_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserFullName_Z", gxTv_SdtSecUser_Secuserfullname_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserEmail_Z", gxTv_SdtSecUser_Secuseremail_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserStatus_Z", gxTv_SdtSecUser_Secuserstatus_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserPassword_Z", gxTv_SdtSecUser_Secuserpassword_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserAnalista_Z", gxTv_SdtSecUser_Secuseranalista_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtSecUser_Secusercreatedat_Z;
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
            datetime_STZ = gxTv_SdtSecUser_Secuserupdateat_Z;
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
            AddObjectProperty("SecUserUserMan_Z", gxTv_SdtSecUser_Secuseruserman_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserManName_Z", gxTv_SdtSecUser_Secusermanname_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserManFullName_Z", gxTv_SdtSecUser_Secusermanfullname_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserTemp_Z", gxTv_SdtSecUser_Secusertemp_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserClienteAcesso_Z", gxTv_SdtSecUser_Secuserclienteacesso_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserClienteId_Z", gxTv_SdtSecUser_Secuserclienteid_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserClienteFullName_Z", gxTv_SdtSecUser_Secuserclientefullname_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserClienteStatus_Z", gxTv_SdtSecUser_Secuserclientestatus_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserCliClienteAcesso_Z", gxTv_SdtSecUser_Secusercliclienteacesso_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserOwnerId_Z", gxTv_SdtSecUser_Secuserownerid_Z, false, includeNonInitialized);
            AddObjectProperty("TipoClientePortalPjPf_Z", gxTv_SdtSecUser_Tipoclienteportalpjpf_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserId_N", gxTv_SdtSecUser_Secuserid_N, false, includeNonInitialized);
            AddObjectProperty("SecUserName_N", gxTv_SdtSecUser_Secusername_N, false, includeNonInitialized);
            AddObjectProperty("SecUserFullName_N", gxTv_SdtSecUser_Secuserfullname_N, false, includeNonInitialized);
            AddObjectProperty("SecUserEmail_N", gxTv_SdtSecUser_Secuseremail_N, false, includeNonInitialized);
            AddObjectProperty("SecUserStatus_N", gxTv_SdtSecUser_Secuserstatus_N, false, includeNonInitialized);
            AddObjectProperty("SecUserPassword_N", gxTv_SdtSecUser_Secuserpassword_N, false, includeNonInitialized);
            AddObjectProperty("SecUserAnalista_N", gxTv_SdtSecUser_Secuseranalista_N, false, includeNonInitialized);
            AddObjectProperty("SecUserCreatedAt_N", gxTv_SdtSecUser_Secusercreatedat_N, false, includeNonInitialized);
            AddObjectProperty("SecUserUpdateAt_N", gxTv_SdtSecUser_Secuserupdateat_N, false, includeNonInitialized);
            AddObjectProperty("SecUserUserMan_N", gxTv_SdtSecUser_Secuseruserman_N, false, includeNonInitialized);
            AddObjectProperty("SecUserManName_N", gxTv_SdtSecUser_Secusermanname_N, false, includeNonInitialized);
            AddObjectProperty("SecUserManFullName_N", gxTv_SdtSecUser_Secusermanfullname_N, false, includeNonInitialized);
            AddObjectProperty("SecUserTemp_N", gxTv_SdtSecUser_Secusertemp_N, false, includeNonInitialized);
            AddObjectProperty("SecUserClienteAcesso_N", gxTv_SdtSecUser_Secuserclienteacesso_N, false, includeNonInitialized);
            AddObjectProperty("SecUserTeste_N", gxTv_SdtSecUser_Secuserteste_N, false, includeNonInitialized);
            AddObjectProperty("SecUserClienteId_N", gxTv_SdtSecUser_Secuserclienteid_N, false, includeNonInitialized);
            AddObjectProperty("SecUserClienteFullName_N", gxTv_SdtSecUser_Secuserclientefullname_N, false, includeNonInitialized);
            AddObjectProperty("SecUserClienteStatus_N", gxTv_SdtSecUser_Secuserclientestatus_N, false, includeNonInitialized);
            AddObjectProperty("SecUserCliClienteAcesso_N", gxTv_SdtSecUser_Secusercliclienteacesso_N, false, includeNonInitialized);
            AddObjectProperty("SecUserOwnerId_N", gxTv_SdtSecUser_Secuserownerid_N, false, includeNonInitialized);
            AddObjectProperty("TipoClientePortalPjPf_N", gxTv_SdtSecUser_Tipoclienteportalpjpf_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtSecUser sdt )
      {
         if ( sdt.IsDirty("SecUserId") )
         {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserid = sdt.gxTv_SdtSecUser_Secuserid ;
         }
         if ( sdt.IsDirty("SecUserName") )
         {
            gxTv_SdtSecUser_Secusername_N = (short)(sdt.gxTv_SdtSecUser_Secusername_N);
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secusername = sdt.gxTv_SdtSecUser_Secusername ;
         }
         if ( sdt.IsDirty("SecUserFullName") )
         {
            gxTv_SdtSecUser_Secuserfullname_N = (short)(sdt.gxTv_SdtSecUser_Secuserfullname_N);
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserfullname = sdt.gxTv_SdtSecUser_Secuserfullname ;
         }
         if ( sdt.IsDirty("SecUserEmail") )
         {
            gxTv_SdtSecUser_Secuseremail_N = (short)(sdt.gxTv_SdtSecUser_Secuseremail_N);
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuseremail = sdt.gxTv_SdtSecUser_Secuseremail ;
         }
         if ( sdt.IsDirty("SecUserStatus") )
         {
            gxTv_SdtSecUser_Secuserstatus_N = (short)(sdt.gxTv_SdtSecUser_Secuserstatus_N);
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserstatus = sdt.gxTv_SdtSecUser_Secuserstatus ;
         }
         if ( sdt.IsDirty("SecUserPassword") )
         {
            gxTv_SdtSecUser_Secuserpassword_N = (short)(sdt.gxTv_SdtSecUser_Secuserpassword_N);
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserpassword = sdt.gxTv_SdtSecUser_Secuserpassword ;
         }
         if ( sdt.IsDirty("SecUserAnalista") )
         {
            gxTv_SdtSecUser_Secuseranalista_N = (short)(sdt.gxTv_SdtSecUser_Secuseranalista_N);
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuseranalista = sdt.gxTv_SdtSecUser_Secuseranalista ;
         }
         if ( sdt.IsDirty("SecUserCreatedAt") )
         {
            gxTv_SdtSecUser_Secusercreatedat_N = (short)(sdt.gxTv_SdtSecUser_Secusercreatedat_N);
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secusercreatedat = sdt.gxTv_SdtSecUser_Secusercreatedat ;
         }
         if ( sdt.IsDirty("SecUserUpdateAt") )
         {
            gxTv_SdtSecUser_Secuserupdateat_N = (short)(sdt.gxTv_SdtSecUser_Secuserupdateat_N);
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserupdateat = sdt.gxTv_SdtSecUser_Secuserupdateat ;
         }
         if ( sdt.IsDirty("SecUserUserMan") )
         {
            gxTv_SdtSecUser_Secuseruserman_N = (short)(sdt.gxTv_SdtSecUser_Secuseruserman_N);
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuseruserman = sdt.gxTv_SdtSecUser_Secuseruserman ;
         }
         if ( sdt.IsDirty("SecUserManName") )
         {
            gxTv_SdtSecUser_Secusermanname_N = (short)(sdt.gxTv_SdtSecUser_Secusermanname_N);
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secusermanname = sdt.gxTv_SdtSecUser_Secusermanname ;
         }
         if ( sdt.IsDirty("SecUserManFullName") )
         {
            gxTv_SdtSecUser_Secusermanfullname_N = (short)(sdt.gxTv_SdtSecUser_Secusermanfullname_N);
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secusermanfullname = sdt.gxTv_SdtSecUser_Secusermanfullname ;
         }
         if ( sdt.IsDirty("SecUserTemp") )
         {
            gxTv_SdtSecUser_Secusertemp_N = (short)(sdt.gxTv_SdtSecUser_Secusertemp_N);
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secusertemp = sdt.gxTv_SdtSecUser_Secusertemp ;
         }
         if ( sdt.IsDirty("SecUserClienteAcesso") )
         {
            gxTv_SdtSecUser_Secuserclienteacesso_N = (short)(sdt.gxTv_SdtSecUser_Secuserclienteacesso_N);
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserclienteacesso = sdt.gxTv_SdtSecUser_Secuserclienteacesso ;
         }
         if ( sdt.IsDirty("SecUserTeste") )
         {
            gxTv_SdtSecUser_Secuserteste_N = (short)(sdt.gxTv_SdtSecUser_Secuserteste_N);
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserteste = sdt.gxTv_SdtSecUser_Secuserteste ;
         }
         if ( sdt.IsDirty("SecUserClienteId") )
         {
            gxTv_SdtSecUser_Secuserclienteid_N = (short)(sdt.gxTv_SdtSecUser_Secuserclienteid_N);
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserclienteid = sdt.gxTv_SdtSecUser_Secuserclienteid ;
         }
         if ( sdt.IsDirty("SecUserClienteFullName") )
         {
            gxTv_SdtSecUser_Secuserclientefullname_N = (short)(sdt.gxTv_SdtSecUser_Secuserclientefullname_N);
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserclientefullname = sdt.gxTv_SdtSecUser_Secuserclientefullname ;
         }
         if ( sdt.IsDirty("SecUserClienteStatus") )
         {
            gxTv_SdtSecUser_Secuserclientestatus_N = (short)(sdt.gxTv_SdtSecUser_Secuserclientestatus_N);
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserclientestatus = sdt.gxTv_SdtSecUser_Secuserclientestatus ;
         }
         if ( sdt.IsDirty("SecUserCliClienteAcesso") )
         {
            gxTv_SdtSecUser_Secusercliclienteacesso_N = (short)(sdt.gxTv_SdtSecUser_Secusercliclienteacesso_N);
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secusercliclienteacesso = sdt.gxTv_SdtSecUser_Secusercliclienteacesso ;
         }
         if ( sdt.IsDirty("SecUserOwnerId") )
         {
            gxTv_SdtSecUser_Secuserownerid_N = (short)(sdt.gxTv_SdtSecUser_Secuserownerid_N);
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserownerid = sdt.gxTv_SdtSecUser_Secuserownerid ;
         }
         if ( sdt.IsDirty("TipoClientePortalPjPf") )
         {
            gxTv_SdtSecUser_Tipoclienteportalpjpf_N = (short)(sdt.gxTv_SdtSecUser_Tipoclienteportalpjpf_N);
            sdtIsNull = 0;
            gxTv_SdtSecUser_Tipoclienteportalpjpf = sdt.gxTv_SdtSecUser_Tipoclienteportalpjpf ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "SecUserId" )]
      [  XmlElement( ElementName = "SecUserId"   )]
      public short gxTpr_Secuserid
      {
         get {
            return gxTv_SdtSecUser_Secuserid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtSecUser_Secuserid != value )
            {
               gxTv_SdtSecUser_Mode = "INS";
               this.gxTv_SdtSecUser_Secuserid_Z_SetNull( );
               this.gxTv_SdtSecUser_Secusername_Z_SetNull( );
               this.gxTv_SdtSecUser_Secuserfullname_Z_SetNull( );
               this.gxTv_SdtSecUser_Secuseremail_Z_SetNull( );
               this.gxTv_SdtSecUser_Secuserstatus_Z_SetNull( );
               this.gxTv_SdtSecUser_Secuserpassword_Z_SetNull( );
               this.gxTv_SdtSecUser_Secuseranalista_Z_SetNull( );
               this.gxTv_SdtSecUser_Secusercreatedat_Z_SetNull( );
               this.gxTv_SdtSecUser_Secuserupdateat_Z_SetNull( );
               this.gxTv_SdtSecUser_Secuseruserman_Z_SetNull( );
               this.gxTv_SdtSecUser_Secusermanname_Z_SetNull( );
               this.gxTv_SdtSecUser_Secusermanfullname_Z_SetNull( );
               this.gxTv_SdtSecUser_Secusertemp_Z_SetNull( );
               this.gxTv_SdtSecUser_Secuserclienteacesso_Z_SetNull( );
               this.gxTv_SdtSecUser_Secuserclienteid_Z_SetNull( );
               this.gxTv_SdtSecUser_Secuserclientefullname_Z_SetNull( );
               this.gxTv_SdtSecUser_Secuserclientestatus_Z_SetNull( );
               this.gxTv_SdtSecUser_Secusercliclienteacesso_Z_SetNull( );
               this.gxTv_SdtSecUser_Secuserownerid_Z_SetNull( );
               this.gxTv_SdtSecUser_Tipoclienteportalpjpf_Z_SetNull( );
            }
            gxTv_SdtSecUser_Secuserid = value;
            SetDirty("Secuserid");
         }

      }

      [  SoapElement( ElementName = "SecUserName" )]
      [  XmlElement( ElementName = "SecUserName"   )]
      public string gxTpr_Secusername
      {
         get {
            return gxTv_SdtSecUser_Secusername ;
         }

         set {
            gxTv_SdtSecUser_Secusername_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secusername = value;
            SetDirty("Secusername");
         }

      }

      public void gxTv_SdtSecUser_Secusername_SetNull( )
      {
         gxTv_SdtSecUser_Secusername_N = 1;
         gxTv_SdtSecUser_Secusername = "";
         SetDirty("Secusername");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secusername_IsNull( )
      {
         return (gxTv_SdtSecUser_Secusername_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserFullName" )]
      [  XmlElement( ElementName = "SecUserFullName"   )]
      public string gxTpr_Secuserfullname
      {
         get {
            return gxTv_SdtSecUser_Secuserfullname ;
         }

         set {
            gxTv_SdtSecUser_Secuserfullname_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserfullname = value;
            SetDirty("Secuserfullname");
         }

      }

      public void gxTv_SdtSecUser_Secuserfullname_SetNull( )
      {
         gxTv_SdtSecUser_Secuserfullname_N = 1;
         gxTv_SdtSecUser_Secuserfullname = "";
         SetDirty("Secuserfullname");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserfullname_IsNull( )
      {
         return (gxTv_SdtSecUser_Secuserfullname_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserEmail" )]
      [  XmlElement( ElementName = "SecUserEmail"   )]
      public string gxTpr_Secuseremail
      {
         get {
            return gxTv_SdtSecUser_Secuseremail ;
         }

         set {
            gxTv_SdtSecUser_Secuseremail_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuseremail = value;
            SetDirty("Secuseremail");
         }

      }

      public void gxTv_SdtSecUser_Secuseremail_SetNull( )
      {
         gxTv_SdtSecUser_Secuseremail_N = 1;
         gxTv_SdtSecUser_Secuseremail = "";
         SetDirty("Secuseremail");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuseremail_IsNull( )
      {
         return (gxTv_SdtSecUser_Secuseremail_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserStatus" )]
      [  XmlElement( ElementName = "SecUserStatus"   )]
      public bool gxTpr_Secuserstatus
      {
         get {
            return gxTv_SdtSecUser_Secuserstatus ;
         }

         set {
            gxTv_SdtSecUser_Secuserstatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserstatus = value;
            SetDirty("Secuserstatus");
         }

      }

      public void gxTv_SdtSecUser_Secuserstatus_SetNull( )
      {
         gxTv_SdtSecUser_Secuserstatus_N = 1;
         gxTv_SdtSecUser_Secuserstatus = false;
         SetDirty("Secuserstatus");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserstatus_IsNull( )
      {
         return (gxTv_SdtSecUser_Secuserstatus_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserPassword" )]
      [  XmlElement( ElementName = "SecUserPassword"   )]
      public string gxTpr_Secuserpassword
      {
         get {
            return gxTv_SdtSecUser_Secuserpassword ;
         }

         set {
            gxTv_SdtSecUser_Secuserpassword_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserpassword = value;
            SetDirty("Secuserpassword");
         }

      }

      public void gxTv_SdtSecUser_Secuserpassword_SetNull( )
      {
         gxTv_SdtSecUser_Secuserpassword_N = 1;
         gxTv_SdtSecUser_Secuserpassword = "";
         SetDirty("Secuserpassword");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserpassword_IsNull( )
      {
         return (gxTv_SdtSecUser_Secuserpassword_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserAnalista" )]
      [  XmlElement( ElementName = "SecUserAnalista"   )]
      public bool gxTpr_Secuseranalista
      {
         get {
            return gxTv_SdtSecUser_Secuseranalista ;
         }

         set {
            gxTv_SdtSecUser_Secuseranalista_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuseranalista = value;
            SetDirty("Secuseranalista");
         }

      }

      public void gxTv_SdtSecUser_Secuseranalista_SetNull( )
      {
         gxTv_SdtSecUser_Secuseranalista_N = 1;
         gxTv_SdtSecUser_Secuseranalista = false;
         SetDirty("Secuseranalista");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuseranalista_IsNull( )
      {
         return (gxTv_SdtSecUser_Secuseranalista_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserCreatedAt" )]
      [  XmlElement( ElementName = "SecUserCreatedAt"  , IsNullable=true )]
      public string gxTpr_Secusercreatedat_Nullable
      {
         get {
            if ( gxTv_SdtSecUser_Secusercreatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtSecUser_Secusercreatedat).value ;
         }

         set {
            gxTv_SdtSecUser_Secusercreatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtSecUser_Secusercreatedat = DateTime.MinValue;
            else
               gxTv_SdtSecUser_Secusercreatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Secusercreatedat
      {
         get {
            return gxTv_SdtSecUser_Secusercreatedat ;
         }

         set {
            gxTv_SdtSecUser_Secusercreatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secusercreatedat = value;
            SetDirty("Secusercreatedat");
         }

      }

      public void gxTv_SdtSecUser_Secusercreatedat_SetNull( )
      {
         gxTv_SdtSecUser_Secusercreatedat_N = 1;
         gxTv_SdtSecUser_Secusercreatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Secusercreatedat");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secusercreatedat_IsNull( )
      {
         return (gxTv_SdtSecUser_Secusercreatedat_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserUpdateAt" )]
      [  XmlElement( ElementName = "SecUserUpdateAt"  , IsNullable=true )]
      public string gxTpr_Secuserupdateat_Nullable
      {
         get {
            if ( gxTv_SdtSecUser_Secuserupdateat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtSecUser_Secuserupdateat).value ;
         }

         set {
            gxTv_SdtSecUser_Secuserupdateat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtSecUser_Secuserupdateat = DateTime.MinValue;
            else
               gxTv_SdtSecUser_Secuserupdateat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Secuserupdateat
      {
         get {
            return gxTv_SdtSecUser_Secuserupdateat ;
         }

         set {
            gxTv_SdtSecUser_Secuserupdateat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserupdateat = value;
            SetDirty("Secuserupdateat");
         }

      }

      public void gxTv_SdtSecUser_Secuserupdateat_SetNull( )
      {
         gxTv_SdtSecUser_Secuserupdateat_N = 1;
         gxTv_SdtSecUser_Secuserupdateat = (DateTime)(DateTime.MinValue);
         SetDirty("Secuserupdateat");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserupdateat_IsNull( )
      {
         return (gxTv_SdtSecUser_Secuserupdateat_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserUserMan" )]
      [  XmlElement( ElementName = "SecUserUserMan"   )]
      public short gxTpr_Secuseruserman
      {
         get {
            return gxTv_SdtSecUser_Secuseruserman ;
         }

         set {
            gxTv_SdtSecUser_Secuseruserman_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuseruserman = value;
            SetDirty("Secuseruserman");
         }

      }

      public void gxTv_SdtSecUser_Secuseruserman_SetNull( )
      {
         gxTv_SdtSecUser_Secuseruserman_N = 1;
         gxTv_SdtSecUser_Secuseruserman = 0;
         SetDirty("Secuseruserman");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuseruserman_IsNull( )
      {
         return (gxTv_SdtSecUser_Secuseruserman_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserManName" )]
      [  XmlElement( ElementName = "SecUserManName"   )]
      public string gxTpr_Secusermanname
      {
         get {
            return gxTv_SdtSecUser_Secusermanname ;
         }

         set {
            gxTv_SdtSecUser_Secusermanname_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secusermanname = value;
            SetDirty("Secusermanname");
         }

      }

      public void gxTv_SdtSecUser_Secusermanname_SetNull( )
      {
         gxTv_SdtSecUser_Secusermanname_N = 1;
         gxTv_SdtSecUser_Secusermanname = "";
         SetDirty("Secusermanname");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secusermanname_IsNull( )
      {
         return (gxTv_SdtSecUser_Secusermanname_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserManFullName" )]
      [  XmlElement( ElementName = "SecUserManFullName"   )]
      public string gxTpr_Secusermanfullname
      {
         get {
            return gxTv_SdtSecUser_Secusermanfullname ;
         }

         set {
            gxTv_SdtSecUser_Secusermanfullname_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secusermanfullname = value;
            SetDirty("Secusermanfullname");
         }

      }

      public void gxTv_SdtSecUser_Secusermanfullname_SetNull( )
      {
         gxTv_SdtSecUser_Secusermanfullname_N = 1;
         gxTv_SdtSecUser_Secusermanfullname = "";
         SetDirty("Secusermanfullname");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secusermanfullname_IsNull( )
      {
         return (gxTv_SdtSecUser_Secusermanfullname_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserTemp" )]
      [  XmlElement( ElementName = "SecUserTemp"   )]
      public bool gxTpr_Secusertemp
      {
         get {
            return gxTv_SdtSecUser_Secusertemp ;
         }

         set {
            gxTv_SdtSecUser_Secusertemp_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secusertemp = value;
            SetDirty("Secusertemp");
         }

      }

      public void gxTv_SdtSecUser_Secusertemp_SetNull( )
      {
         gxTv_SdtSecUser_Secusertemp_N = 1;
         gxTv_SdtSecUser_Secusertemp = false;
         SetDirty("Secusertemp");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secusertemp_IsNull( )
      {
         return (gxTv_SdtSecUser_Secusertemp_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserClienteAcesso" )]
      [  XmlElement( ElementName = "SecUserClienteAcesso"   )]
      public bool gxTpr_Secuserclienteacesso
      {
         get {
            return gxTv_SdtSecUser_Secuserclienteacesso ;
         }

         set {
            gxTv_SdtSecUser_Secuserclienteacesso_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserclienteacesso = value;
            SetDirty("Secuserclienteacesso");
         }

      }

      public void gxTv_SdtSecUser_Secuserclienteacesso_SetNull( )
      {
         gxTv_SdtSecUser_Secuserclienteacesso_N = 1;
         gxTv_SdtSecUser_Secuserclienteacesso = false;
         SetDirty("Secuserclienteacesso");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserclienteacesso_IsNull( )
      {
         return (gxTv_SdtSecUser_Secuserclienteacesso_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserTeste" )]
      [  XmlElement( ElementName = "SecUserTeste"   )]
      public string gxTpr_Secuserteste
      {
         get {
            return gxTv_SdtSecUser_Secuserteste ;
         }

         set {
            gxTv_SdtSecUser_Secuserteste_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserteste = value;
            SetDirty("Secuserteste");
         }

      }

      public void gxTv_SdtSecUser_Secuserteste_SetNull( )
      {
         gxTv_SdtSecUser_Secuserteste_N = 1;
         gxTv_SdtSecUser_Secuserteste = "";
         SetDirty("Secuserteste");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserteste_IsNull( )
      {
         return (gxTv_SdtSecUser_Secuserteste_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserClienteId" )]
      [  XmlElement( ElementName = "SecUserClienteId"   )]
      public short gxTpr_Secuserclienteid
      {
         get {
            return gxTv_SdtSecUser_Secuserclienteid ;
         }

         set {
            gxTv_SdtSecUser_Secuserclienteid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserclienteid = value;
            SetDirty("Secuserclienteid");
         }

      }

      public void gxTv_SdtSecUser_Secuserclienteid_SetNull( )
      {
         gxTv_SdtSecUser_Secuserclienteid_N = 1;
         gxTv_SdtSecUser_Secuserclienteid = 0;
         SetDirty("Secuserclienteid");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserclienteid_IsNull( )
      {
         return (gxTv_SdtSecUser_Secuserclienteid_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserClienteFullName" )]
      [  XmlElement( ElementName = "SecUserClienteFullName"   )]
      public string gxTpr_Secuserclientefullname
      {
         get {
            return gxTv_SdtSecUser_Secuserclientefullname ;
         }

         set {
            gxTv_SdtSecUser_Secuserclientefullname_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserclientefullname = value;
            SetDirty("Secuserclientefullname");
         }

      }

      public void gxTv_SdtSecUser_Secuserclientefullname_SetNull( )
      {
         gxTv_SdtSecUser_Secuserclientefullname_N = 1;
         gxTv_SdtSecUser_Secuserclientefullname = "";
         SetDirty("Secuserclientefullname");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserclientefullname_IsNull( )
      {
         return (gxTv_SdtSecUser_Secuserclientefullname_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserClienteStatus" )]
      [  XmlElement( ElementName = "SecUserClienteStatus"   )]
      public bool gxTpr_Secuserclientestatus
      {
         get {
            return gxTv_SdtSecUser_Secuserclientestatus ;
         }

         set {
            gxTv_SdtSecUser_Secuserclientestatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserclientestatus = value;
            SetDirty("Secuserclientestatus");
         }

      }

      public void gxTv_SdtSecUser_Secuserclientestatus_SetNull( )
      {
         gxTv_SdtSecUser_Secuserclientestatus_N = 1;
         gxTv_SdtSecUser_Secuserclientestatus = false;
         SetDirty("Secuserclientestatus");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserclientestatus_IsNull( )
      {
         return (gxTv_SdtSecUser_Secuserclientestatus_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserCliClienteAcesso" )]
      [  XmlElement( ElementName = "SecUserCliClienteAcesso"   )]
      public bool gxTpr_Secusercliclienteacesso
      {
         get {
            return gxTv_SdtSecUser_Secusercliclienteacesso ;
         }

         set {
            gxTv_SdtSecUser_Secusercliclienteacesso_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secusercliclienteacesso = value;
            SetDirty("Secusercliclienteacesso");
         }

      }

      public void gxTv_SdtSecUser_Secusercliclienteacesso_SetNull( )
      {
         gxTv_SdtSecUser_Secusercliclienteacesso_N = 1;
         gxTv_SdtSecUser_Secusercliclienteacesso = false;
         SetDirty("Secusercliclienteacesso");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secusercliclienteacesso_IsNull( )
      {
         return (gxTv_SdtSecUser_Secusercliclienteacesso_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserOwnerId" )]
      [  XmlElement( ElementName = "SecUserOwnerId"   )]
      public int gxTpr_Secuserownerid
      {
         get {
            return gxTv_SdtSecUser_Secuserownerid ;
         }

         set {
            gxTv_SdtSecUser_Secuserownerid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserownerid = value;
            SetDirty("Secuserownerid");
         }

      }

      public void gxTv_SdtSecUser_Secuserownerid_SetNull( )
      {
         gxTv_SdtSecUser_Secuserownerid_N = 1;
         gxTv_SdtSecUser_Secuserownerid = 0;
         SetDirty("Secuserownerid");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserownerid_IsNull( )
      {
         return (gxTv_SdtSecUser_Secuserownerid_N==1) ;
      }

      [  SoapElement( ElementName = "TipoClientePortalPjPf" )]
      [  XmlElement( ElementName = "TipoClientePortalPjPf"   )]
      public bool gxTpr_Tipoclienteportalpjpf
      {
         get {
            return gxTv_SdtSecUser_Tipoclienteportalpjpf ;
         }

         set {
            gxTv_SdtSecUser_Tipoclienteportalpjpf_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecUser_Tipoclienteportalpjpf = value;
            SetDirty("Tipoclienteportalpjpf");
         }

      }

      public void gxTv_SdtSecUser_Tipoclienteportalpjpf_SetNull( )
      {
         gxTv_SdtSecUser_Tipoclienteportalpjpf_N = 1;
         gxTv_SdtSecUser_Tipoclienteportalpjpf = false;
         SetDirty("Tipoclienteportalpjpf");
         return  ;
      }

      public bool gxTv_SdtSecUser_Tipoclienteportalpjpf_IsNull( )
      {
         return (gxTv_SdtSecUser_Tipoclienteportalpjpf_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtSecUser_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtSecUser_Mode_SetNull( )
      {
         gxTv_SdtSecUser_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtSecUser_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtSecUser_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtSecUser_Initialized_SetNull( )
      {
         gxTv_SdtSecUser_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtSecUser_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserId_Z" )]
      [  XmlElement( ElementName = "SecUserId_Z"   )]
      public short gxTpr_Secuserid_Z
      {
         get {
            return gxTv_SdtSecUser_Secuserid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserid_Z = value;
            SetDirty("Secuserid_Z");
         }

      }

      public void gxTv_SdtSecUser_Secuserid_Z_SetNull( )
      {
         gxTv_SdtSecUser_Secuserid_Z = 0;
         SetDirty("Secuserid_Z");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserName_Z" )]
      [  XmlElement( ElementName = "SecUserName_Z"   )]
      public string gxTpr_Secusername_Z
      {
         get {
            return gxTv_SdtSecUser_Secusername_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secusername_Z = value;
            SetDirty("Secusername_Z");
         }

      }

      public void gxTv_SdtSecUser_Secusername_Z_SetNull( )
      {
         gxTv_SdtSecUser_Secusername_Z = "";
         SetDirty("Secusername_Z");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secusername_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserFullName_Z" )]
      [  XmlElement( ElementName = "SecUserFullName_Z"   )]
      public string gxTpr_Secuserfullname_Z
      {
         get {
            return gxTv_SdtSecUser_Secuserfullname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserfullname_Z = value;
            SetDirty("Secuserfullname_Z");
         }

      }

      public void gxTv_SdtSecUser_Secuserfullname_Z_SetNull( )
      {
         gxTv_SdtSecUser_Secuserfullname_Z = "";
         SetDirty("Secuserfullname_Z");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserfullname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserEmail_Z" )]
      [  XmlElement( ElementName = "SecUserEmail_Z"   )]
      public string gxTpr_Secuseremail_Z
      {
         get {
            return gxTv_SdtSecUser_Secuseremail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuseremail_Z = value;
            SetDirty("Secuseremail_Z");
         }

      }

      public void gxTv_SdtSecUser_Secuseremail_Z_SetNull( )
      {
         gxTv_SdtSecUser_Secuseremail_Z = "";
         SetDirty("Secuseremail_Z");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuseremail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserStatus_Z" )]
      [  XmlElement( ElementName = "SecUserStatus_Z"   )]
      public bool gxTpr_Secuserstatus_Z
      {
         get {
            return gxTv_SdtSecUser_Secuserstatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserstatus_Z = value;
            SetDirty("Secuserstatus_Z");
         }

      }

      public void gxTv_SdtSecUser_Secuserstatus_Z_SetNull( )
      {
         gxTv_SdtSecUser_Secuserstatus_Z = false;
         SetDirty("Secuserstatus_Z");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserstatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserPassword_Z" )]
      [  XmlElement( ElementName = "SecUserPassword_Z"   )]
      public string gxTpr_Secuserpassword_Z
      {
         get {
            return gxTv_SdtSecUser_Secuserpassword_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserpassword_Z = value;
            SetDirty("Secuserpassword_Z");
         }

      }

      public void gxTv_SdtSecUser_Secuserpassword_Z_SetNull( )
      {
         gxTv_SdtSecUser_Secuserpassword_Z = "";
         SetDirty("Secuserpassword_Z");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserpassword_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserAnalista_Z" )]
      [  XmlElement( ElementName = "SecUserAnalista_Z"   )]
      public bool gxTpr_Secuseranalista_Z
      {
         get {
            return gxTv_SdtSecUser_Secuseranalista_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuseranalista_Z = value;
            SetDirty("Secuseranalista_Z");
         }

      }

      public void gxTv_SdtSecUser_Secuseranalista_Z_SetNull( )
      {
         gxTv_SdtSecUser_Secuseranalista_Z = false;
         SetDirty("Secuseranalista_Z");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuseranalista_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserCreatedAt_Z" )]
      [  XmlElement( ElementName = "SecUserCreatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Secusercreatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtSecUser_Secusercreatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtSecUser_Secusercreatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtSecUser_Secusercreatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtSecUser_Secusercreatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Secusercreatedat_Z
      {
         get {
            return gxTv_SdtSecUser_Secusercreatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secusercreatedat_Z = value;
            SetDirty("Secusercreatedat_Z");
         }

      }

      public void gxTv_SdtSecUser_Secusercreatedat_Z_SetNull( )
      {
         gxTv_SdtSecUser_Secusercreatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Secusercreatedat_Z");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secusercreatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserUpdateAt_Z" )]
      [  XmlElement( ElementName = "SecUserUpdateAt_Z"  , IsNullable=true )]
      public string gxTpr_Secuserupdateat_Z_Nullable
      {
         get {
            if ( gxTv_SdtSecUser_Secuserupdateat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtSecUser_Secuserupdateat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtSecUser_Secuserupdateat_Z = DateTime.MinValue;
            else
               gxTv_SdtSecUser_Secuserupdateat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Secuserupdateat_Z
      {
         get {
            return gxTv_SdtSecUser_Secuserupdateat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserupdateat_Z = value;
            SetDirty("Secuserupdateat_Z");
         }

      }

      public void gxTv_SdtSecUser_Secuserupdateat_Z_SetNull( )
      {
         gxTv_SdtSecUser_Secuserupdateat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Secuserupdateat_Z");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserupdateat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserUserMan_Z" )]
      [  XmlElement( ElementName = "SecUserUserMan_Z"   )]
      public short gxTpr_Secuseruserman_Z
      {
         get {
            return gxTv_SdtSecUser_Secuseruserman_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuseruserman_Z = value;
            SetDirty("Secuseruserman_Z");
         }

      }

      public void gxTv_SdtSecUser_Secuseruserman_Z_SetNull( )
      {
         gxTv_SdtSecUser_Secuseruserman_Z = 0;
         SetDirty("Secuseruserman_Z");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuseruserman_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserManName_Z" )]
      [  XmlElement( ElementName = "SecUserManName_Z"   )]
      public string gxTpr_Secusermanname_Z
      {
         get {
            return gxTv_SdtSecUser_Secusermanname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secusermanname_Z = value;
            SetDirty("Secusermanname_Z");
         }

      }

      public void gxTv_SdtSecUser_Secusermanname_Z_SetNull( )
      {
         gxTv_SdtSecUser_Secusermanname_Z = "";
         SetDirty("Secusermanname_Z");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secusermanname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserManFullName_Z" )]
      [  XmlElement( ElementName = "SecUserManFullName_Z"   )]
      public string gxTpr_Secusermanfullname_Z
      {
         get {
            return gxTv_SdtSecUser_Secusermanfullname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secusermanfullname_Z = value;
            SetDirty("Secusermanfullname_Z");
         }

      }

      public void gxTv_SdtSecUser_Secusermanfullname_Z_SetNull( )
      {
         gxTv_SdtSecUser_Secusermanfullname_Z = "";
         SetDirty("Secusermanfullname_Z");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secusermanfullname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserTemp_Z" )]
      [  XmlElement( ElementName = "SecUserTemp_Z"   )]
      public bool gxTpr_Secusertemp_Z
      {
         get {
            return gxTv_SdtSecUser_Secusertemp_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secusertemp_Z = value;
            SetDirty("Secusertemp_Z");
         }

      }

      public void gxTv_SdtSecUser_Secusertemp_Z_SetNull( )
      {
         gxTv_SdtSecUser_Secusertemp_Z = false;
         SetDirty("Secusertemp_Z");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secusertemp_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserClienteAcesso_Z" )]
      [  XmlElement( ElementName = "SecUserClienteAcesso_Z"   )]
      public bool gxTpr_Secuserclienteacesso_Z
      {
         get {
            return gxTv_SdtSecUser_Secuserclienteacesso_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserclienteacesso_Z = value;
            SetDirty("Secuserclienteacesso_Z");
         }

      }

      public void gxTv_SdtSecUser_Secuserclienteacesso_Z_SetNull( )
      {
         gxTv_SdtSecUser_Secuserclienteacesso_Z = false;
         SetDirty("Secuserclienteacesso_Z");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserclienteacesso_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserClienteId_Z" )]
      [  XmlElement( ElementName = "SecUserClienteId_Z"   )]
      public short gxTpr_Secuserclienteid_Z
      {
         get {
            return gxTv_SdtSecUser_Secuserclienteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserclienteid_Z = value;
            SetDirty("Secuserclienteid_Z");
         }

      }

      public void gxTv_SdtSecUser_Secuserclienteid_Z_SetNull( )
      {
         gxTv_SdtSecUser_Secuserclienteid_Z = 0;
         SetDirty("Secuserclienteid_Z");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserclienteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserClienteFullName_Z" )]
      [  XmlElement( ElementName = "SecUserClienteFullName_Z"   )]
      public string gxTpr_Secuserclientefullname_Z
      {
         get {
            return gxTv_SdtSecUser_Secuserclientefullname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserclientefullname_Z = value;
            SetDirty("Secuserclientefullname_Z");
         }

      }

      public void gxTv_SdtSecUser_Secuserclientefullname_Z_SetNull( )
      {
         gxTv_SdtSecUser_Secuserclientefullname_Z = "";
         SetDirty("Secuserclientefullname_Z");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserclientefullname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserClienteStatus_Z" )]
      [  XmlElement( ElementName = "SecUserClienteStatus_Z"   )]
      public bool gxTpr_Secuserclientestatus_Z
      {
         get {
            return gxTv_SdtSecUser_Secuserclientestatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserclientestatus_Z = value;
            SetDirty("Secuserclientestatus_Z");
         }

      }

      public void gxTv_SdtSecUser_Secuserclientestatus_Z_SetNull( )
      {
         gxTv_SdtSecUser_Secuserclientestatus_Z = false;
         SetDirty("Secuserclientestatus_Z");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserclientestatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserCliClienteAcesso_Z" )]
      [  XmlElement( ElementName = "SecUserCliClienteAcesso_Z"   )]
      public bool gxTpr_Secusercliclienteacesso_Z
      {
         get {
            return gxTv_SdtSecUser_Secusercliclienteacesso_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secusercliclienteacesso_Z = value;
            SetDirty("Secusercliclienteacesso_Z");
         }

      }

      public void gxTv_SdtSecUser_Secusercliclienteacesso_Z_SetNull( )
      {
         gxTv_SdtSecUser_Secusercliclienteacesso_Z = false;
         SetDirty("Secusercliclienteacesso_Z");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secusercliclienteacesso_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserOwnerId_Z" )]
      [  XmlElement( ElementName = "SecUserOwnerId_Z"   )]
      public int gxTpr_Secuserownerid_Z
      {
         get {
            return gxTv_SdtSecUser_Secuserownerid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserownerid_Z = value;
            SetDirty("Secuserownerid_Z");
         }

      }

      public void gxTv_SdtSecUser_Secuserownerid_Z_SetNull( )
      {
         gxTv_SdtSecUser_Secuserownerid_Z = 0;
         SetDirty("Secuserownerid_Z");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserownerid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoClientePortalPjPf_Z" )]
      [  XmlElement( ElementName = "TipoClientePortalPjPf_Z"   )]
      public bool gxTpr_Tipoclienteportalpjpf_Z
      {
         get {
            return gxTv_SdtSecUser_Tipoclienteportalpjpf_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Tipoclienteportalpjpf_Z = value;
            SetDirty("Tipoclienteportalpjpf_Z");
         }

      }

      public void gxTv_SdtSecUser_Tipoclienteportalpjpf_Z_SetNull( )
      {
         gxTv_SdtSecUser_Tipoclienteportalpjpf_Z = false;
         SetDirty("Tipoclienteportalpjpf_Z");
         return  ;
      }

      public bool gxTv_SdtSecUser_Tipoclienteportalpjpf_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserId_N" )]
      [  XmlElement( ElementName = "SecUserId_N"   )]
      public short gxTpr_Secuserid_N
      {
         get {
            return gxTv_SdtSecUser_Secuserid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserid_N = value;
            SetDirty("Secuserid_N");
         }

      }

      public void gxTv_SdtSecUser_Secuserid_N_SetNull( )
      {
         gxTv_SdtSecUser_Secuserid_N = 0;
         SetDirty("Secuserid_N");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserName_N" )]
      [  XmlElement( ElementName = "SecUserName_N"   )]
      public short gxTpr_Secusername_N
      {
         get {
            return gxTv_SdtSecUser_Secusername_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secusername_N = value;
            SetDirty("Secusername_N");
         }

      }

      public void gxTv_SdtSecUser_Secusername_N_SetNull( )
      {
         gxTv_SdtSecUser_Secusername_N = 0;
         SetDirty("Secusername_N");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secusername_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserFullName_N" )]
      [  XmlElement( ElementName = "SecUserFullName_N"   )]
      public short gxTpr_Secuserfullname_N
      {
         get {
            return gxTv_SdtSecUser_Secuserfullname_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserfullname_N = value;
            SetDirty("Secuserfullname_N");
         }

      }

      public void gxTv_SdtSecUser_Secuserfullname_N_SetNull( )
      {
         gxTv_SdtSecUser_Secuserfullname_N = 0;
         SetDirty("Secuserfullname_N");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserfullname_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserEmail_N" )]
      [  XmlElement( ElementName = "SecUserEmail_N"   )]
      public short gxTpr_Secuseremail_N
      {
         get {
            return gxTv_SdtSecUser_Secuseremail_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuseremail_N = value;
            SetDirty("Secuseremail_N");
         }

      }

      public void gxTv_SdtSecUser_Secuseremail_N_SetNull( )
      {
         gxTv_SdtSecUser_Secuseremail_N = 0;
         SetDirty("Secuseremail_N");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuseremail_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserStatus_N" )]
      [  XmlElement( ElementName = "SecUserStatus_N"   )]
      public short gxTpr_Secuserstatus_N
      {
         get {
            return gxTv_SdtSecUser_Secuserstatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserstatus_N = value;
            SetDirty("Secuserstatus_N");
         }

      }

      public void gxTv_SdtSecUser_Secuserstatus_N_SetNull( )
      {
         gxTv_SdtSecUser_Secuserstatus_N = 0;
         SetDirty("Secuserstatus_N");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserstatus_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserPassword_N" )]
      [  XmlElement( ElementName = "SecUserPassword_N"   )]
      public short gxTpr_Secuserpassword_N
      {
         get {
            return gxTv_SdtSecUser_Secuserpassword_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserpassword_N = value;
            SetDirty("Secuserpassword_N");
         }

      }

      public void gxTv_SdtSecUser_Secuserpassword_N_SetNull( )
      {
         gxTv_SdtSecUser_Secuserpassword_N = 0;
         SetDirty("Secuserpassword_N");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserpassword_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserAnalista_N" )]
      [  XmlElement( ElementName = "SecUserAnalista_N"   )]
      public short gxTpr_Secuseranalista_N
      {
         get {
            return gxTv_SdtSecUser_Secuseranalista_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuseranalista_N = value;
            SetDirty("Secuseranalista_N");
         }

      }

      public void gxTv_SdtSecUser_Secuseranalista_N_SetNull( )
      {
         gxTv_SdtSecUser_Secuseranalista_N = 0;
         SetDirty("Secuseranalista_N");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuseranalista_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserCreatedAt_N" )]
      [  XmlElement( ElementName = "SecUserCreatedAt_N"   )]
      public short gxTpr_Secusercreatedat_N
      {
         get {
            return gxTv_SdtSecUser_Secusercreatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secusercreatedat_N = value;
            SetDirty("Secusercreatedat_N");
         }

      }

      public void gxTv_SdtSecUser_Secusercreatedat_N_SetNull( )
      {
         gxTv_SdtSecUser_Secusercreatedat_N = 0;
         SetDirty("Secusercreatedat_N");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secusercreatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserUpdateAt_N" )]
      [  XmlElement( ElementName = "SecUserUpdateAt_N"   )]
      public short gxTpr_Secuserupdateat_N
      {
         get {
            return gxTv_SdtSecUser_Secuserupdateat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserupdateat_N = value;
            SetDirty("Secuserupdateat_N");
         }

      }

      public void gxTv_SdtSecUser_Secuserupdateat_N_SetNull( )
      {
         gxTv_SdtSecUser_Secuserupdateat_N = 0;
         SetDirty("Secuserupdateat_N");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserupdateat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserUserMan_N" )]
      [  XmlElement( ElementName = "SecUserUserMan_N"   )]
      public short gxTpr_Secuseruserman_N
      {
         get {
            return gxTv_SdtSecUser_Secuseruserman_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuseruserman_N = value;
            SetDirty("Secuseruserman_N");
         }

      }

      public void gxTv_SdtSecUser_Secuseruserman_N_SetNull( )
      {
         gxTv_SdtSecUser_Secuseruserman_N = 0;
         SetDirty("Secuseruserman_N");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuseruserman_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserManName_N" )]
      [  XmlElement( ElementName = "SecUserManName_N"   )]
      public short gxTpr_Secusermanname_N
      {
         get {
            return gxTv_SdtSecUser_Secusermanname_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secusermanname_N = value;
            SetDirty("Secusermanname_N");
         }

      }

      public void gxTv_SdtSecUser_Secusermanname_N_SetNull( )
      {
         gxTv_SdtSecUser_Secusermanname_N = 0;
         SetDirty("Secusermanname_N");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secusermanname_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserManFullName_N" )]
      [  XmlElement( ElementName = "SecUserManFullName_N"   )]
      public short gxTpr_Secusermanfullname_N
      {
         get {
            return gxTv_SdtSecUser_Secusermanfullname_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secusermanfullname_N = value;
            SetDirty("Secusermanfullname_N");
         }

      }

      public void gxTv_SdtSecUser_Secusermanfullname_N_SetNull( )
      {
         gxTv_SdtSecUser_Secusermanfullname_N = 0;
         SetDirty("Secusermanfullname_N");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secusermanfullname_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserTemp_N" )]
      [  XmlElement( ElementName = "SecUserTemp_N"   )]
      public short gxTpr_Secusertemp_N
      {
         get {
            return gxTv_SdtSecUser_Secusertemp_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secusertemp_N = value;
            SetDirty("Secusertemp_N");
         }

      }

      public void gxTv_SdtSecUser_Secusertemp_N_SetNull( )
      {
         gxTv_SdtSecUser_Secusertemp_N = 0;
         SetDirty("Secusertemp_N");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secusertemp_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserClienteAcesso_N" )]
      [  XmlElement( ElementName = "SecUserClienteAcesso_N"   )]
      public short gxTpr_Secuserclienteacesso_N
      {
         get {
            return gxTv_SdtSecUser_Secuserclienteacesso_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserclienteacesso_N = value;
            SetDirty("Secuserclienteacesso_N");
         }

      }

      public void gxTv_SdtSecUser_Secuserclienteacesso_N_SetNull( )
      {
         gxTv_SdtSecUser_Secuserclienteacesso_N = 0;
         SetDirty("Secuserclienteacesso_N");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserclienteacesso_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserTeste_N" )]
      [  XmlElement( ElementName = "SecUserTeste_N"   )]
      public short gxTpr_Secuserteste_N
      {
         get {
            return gxTv_SdtSecUser_Secuserteste_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserteste_N = value;
            SetDirty("Secuserteste_N");
         }

      }

      public void gxTv_SdtSecUser_Secuserteste_N_SetNull( )
      {
         gxTv_SdtSecUser_Secuserteste_N = 0;
         SetDirty("Secuserteste_N");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserteste_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserClienteId_N" )]
      [  XmlElement( ElementName = "SecUserClienteId_N"   )]
      public short gxTpr_Secuserclienteid_N
      {
         get {
            return gxTv_SdtSecUser_Secuserclienteid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserclienteid_N = value;
            SetDirty("Secuserclienteid_N");
         }

      }

      public void gxTv_SdtSecUser_Secuserclienteid_N_SetNull( )
      {
         gxTv_SdtSecUser_Secuserclienteid_N = 0;
         SetDirty("Secuserclienteid_N");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserclienteid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserClienteFullName_N" )]
      [  XmlElement( ElementName = "SecUserClienteFullName_N"   )]
      public short gxTpr_Secuserclientefullname_N
      {
         get {
            return gxTv_SdtSecUser_Secuserclientefullname_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserclientefullname_N = value;
            SetDirty("Secuserclientefullname_N");
         }

      }

      public void gxTv_SdtSecUser_Secuserclientefullname_N_SetNull( )
      {
         gxTv_SdtSecUser_Secuserclientefullname_N = 0;
         SetDirty("Secuserclientefullname_N");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserclientefullname_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserClienteStatus_N" )]
      [  XmlElement( ElementName = "SecUserClienteStatus_N"   )]
      public short gxTpr_Secuserclientestatus_N
      {
         get {
            return gxTv_SdtSecUser_Secuserclientestatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserclientestatus_N = value;
            SetDirty("Secuserclientestatus_N");
         }

      }

      public void gxTv_SdtSecUser_Secuserclientestatus_N_SetNull( )
      {
         gxTv_SdtSecUser_Secuserclientestatus_N = 0;
         SetDirty("Secuserclientestatus_N");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserclientestatus_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserCliClienteAcesso_N" )]
      [  XmlElement( ElementName = "SecUserCliClienteAcesso_N"   )]
      public short gxTpr_Secusercliclienteacesso_N
      {
         get {
            return gxTv_SdtSecUser_Secusercliclienteacesso_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secusercliclienteacesso_N = value;
            SetDirty("Secusercliclienteacesso_N");
         }

      }

      public void gxTv_SdtSecUser_Secusercliclienteacesso_N_SetNull( )
      {
         gxTv_SdtSecUser_Secusercliclienteacesso_N = 0;
         SetDirty("Secusercliclienteacesso_N");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secusercliclienteacesso_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserOwnerId_N" )]
      [  XmlElement( ElementName = "SecUserOwnerId_N"   )]
      public short gxTpr_Secuserownerid_N
      {
         get {
            return gxTv_SdtSecUser_Secuserownerid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserownerid_N = value;
            SetDirty("Secuserownerid_N");
         }

      }

      public void gxTv_SdtSecUser_Secuserownerid_N_SetNull( )
      {
         gxTv_SdtSecUser_Secuserownerid_N = 0;
         SetDirty("Secuserownerid_N");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserownerid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoClientePortalPjPf_N" )]
      [  XmlElement( ElementName = "TipoClientePortalPjPf_N"   )]
      public short gxTpr_Tipoclienteportalpjpf_N
      {
         get {
            return gxTv_SdtSecUser_Tipoclienteportalpjpf_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Tipoclienteportalpjpf_N = value;
            SetDirty("Tipoclienteportalpjpf_N");
         }

      }

      public void gxTv_SdtSecUser_Tipoclienteportalpjpf_N_SetNull( )
      {
         gxTv_SdtSecUser_Tipoclienteportalpjpf_N = 0;
         SetDirty("Tipoclienteportalpjpf_N");
         return  ;
      }

      public bool gxTv_SdtSecUser_Tipoclienteportalpjpf_N_IsNull( )
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
         gxTv_SdtSecUser_Secusername = "";
         gxTv_SdtSecUser_Secuserfullname = "";
         gxTv_SdtSecUser_Secuseremail = "";
         gxTv_SdtSecUser_Secuserpassword = "";
         gxTv_SdtSecUser_Secusercreatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtSecUser_Secuserupdateat = (DateTime)(DateTime.MinValue);
         gxTv_SdtSecUser_Secusermanname = "";
         gxTv_SdtSecUser_Secusermanfullname = "";
         gxTv_SdtSecUser_Secuserteste = "";
         gxTv_SdtSecUser_Secuserclientefullname = "";
         gxTv_SdtSecUser_Mode = "";
         gxTv_SdtSecUser_Secusername_Z = "";
         gxTv_SdtSecUser_Secuserfullname_Z = "";
         gxTv_SdtSecUser_Secuseremail_Z = "";
         gxTv_SdtSecUser_Secuserpassword_Z = "";
         gxTv_SdtSecUser_Secusercreatedat_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtSecUser_Secuserupdateat_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtSecUser_Secusermanname_Z = "";
         gxTv_SdtSecUser_Secusermanfullname_Z = "";
         gxTv_SdtSecUser_Secuserclientefullname_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "secuser", "GeneXus.Programs.secuser_bc", new Object[] {context}, constructorCallingAssembly);;
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

      private short gxTv_SdtSecUser_Secuserid ;
      private short sdtIsNull ;
      private short gxTv_SdtSecUser_Secuseruserman ;
      private short gxTv_SdtSecUser_Secuserclienteid ;
      private short gxTv_SdtSecUser_Initialized ;
      private short gxTv_SdtSecUser_Secuserid_Z ;
      private short gxTv_SdtSecUser_Secuseruserman_Z ;
      private short gxTv_SdtSecUser_Secuserclienteid_Z ;
      private short gxTv_SdtSecUser_Secuserid_N ;
      private short gxTv_SdtSecUser_Secusername_N ;
      private short gxTv_SdtSecUser_Secuserfullname_N ;
      private short gxTv_SdtSecUser_Secuseremail_N ;
      private short gxTv_SdtSecUser_Secuserstatus_N ;
      private short gxTv_SdtSecUser_Secuserpassword_N ;
      private short gxTv_SdtSecUser_Secuseranalista_N ;
      private short gxTv_SdtSecUser_Secusercreatedat_N ;
      private short gxTv_SdtSecUser_Secuserupdateat_N ;
      private short gxTv_SdtSecUser_Secuseruserman_N ;
      private short gxTv_SdtSecUser_Secusermanname_N ;
      private short gxTv_SdtSecUser_Secusermanfullname_N ;
      private short gxTv_SdtSecUser_Secusertemp_N ;
      private short gxTv_SdtSecUser_Secuserclienteacesso_N ;
      private short gxTv_SdtSecUser_Secuserteste_N ;
      private short gxTv_SdtSecUser_Secuserclienteid_N ;
      private short gxTv_SdtSecUser_Secuserclientefullname_N ;
      private short gxTv_SdtSecUser_Secuserclientestatus_N ;
      private short gxTv_SdtSecUser_Secusercliclienteacesso_N ;
      private short gxTv_SdtSecUser_Secuserownerid_N ;
      private short gxTv_SdtSecUser_Tipoclienteportalpjpf_N ;
      private int gxTv_SdtSecUser_Secuserownerid ;
      private int gxTv_SdtSecUser_Secuserownerid_Z ;
      private string gxTv_SdtSecUser_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtSecUser_Secusercreatedat ;
      private DateTime gxTv_SdtSecUser_Secuserupdateat ;
      private DateTime gxTv_SdtSecUser_Secusercreatedat_Z ;
      private DateTime gxTv_SdtSecUser_Secuserupdateat_Z ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtSecUser_Secuserstatus ;
      private bool gxTv_SdtSecUser_Secuseranalista ;
      private bool gxTv_SdtSecUser_Secusertemp ;
      private bool gxTv_SdtSecUser_Secuserclienteacesso ;
      private bool gxTv_SdtSecUser_Secuserclientestatus ;
      private bool gxTv_SdtSecUser_Secusercliclienteacesso ;
      private bool gxTv_SdtSecUser_Tipoclienteportalpjpf ;
      private bool gxTv_SdtSecUser_Secuserstatus_Z ;
      private bool gxTv_SdtSecUser_Secuseranalista_Z ;
      private bool gxTv_SdtSecUser_Secusertemp_Z ;
      private bool gxTv_SdtSecUser_Secuserclienteacesso_Z ;
      private bool gxTv_SdtSecUser_Secuserclientestatus_Z ;
      private bool gxTv_SdtSecUser_Secusercliclienteacesso_Z ;
      private bool gxTv_SdtSecUser_Tipoclienteportalpjpf_Z ;
      private string gxTv_SdtSecUser_Secuserteste ;
      private string gxTv_SdtSecUser_Secusername ;
      private string gxTv_SdtSecUser_Secuserfullname ;
      private string gxTv_SdtSecUser_Secuseremail ;
      private string gxTv_SdtSecUser_Secuserpassword ;
      private string gxTv_SdtSecUser_Secusermanname ;
      private string gxTv_SdtSecUser_Secusermanfullname ;
      private string gxTv_SdtSecUser_Secuserclientefullname ;
      private string gxTv_SdtSecUser_Secusername_Z ;
      private string gxTv_SdtSecUser_Secuserfullname_Z ;
      private string gxTv_SdtSecUser_Secuseremail_Z ;
      private string gxTv_SdtSecUser_Secuserpassword_Z ;
      private string gxTv_SdtSecUser_Secusermanname_Z ;
      private string gxTv_SdtSecUser_Secusermanfullname_Z ;
      private string gxTv_SdtSecUser_Secuserclientefullname_Z ;
   }

   [DataContract(Name = @"SecUser", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtSecUser_RESTInterface : GxGenericCollectionItem<SdtSecUser>
   {
      public SdtSecUser_RESTInterface( ) : base()
      {
      }

      public SdtSecUser_RESTInterface( SdtSecUser psdt ) : base(psdt)
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

      [DataMember( Name = "SecUserPassword" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Secuserpassword
      {
         get {
            return sdt.gxTpr_Secuserpassword ;
         }

         set {
            sdt.gxTpr_Secuserpassword = value;
         }

      }

      [DataMember( Name = "SecUserAnalista" , Order = 6 )]
      [GxSeudo()]
      public bool gxTpr_Secuseranalista
      {
         get {
            return sdt.gxTpr_Secuseranalista ;
         }

         set {
            sdt.gxTpr_Secuseranalista = value;
         }

      }

      [DataMember( Name = "SecUserCreatedAt" , Order = 7 )]
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

      [DataMember( Name = "SecUserUpdateAt" , Order = 8 )]
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

      [DataMember( Name = "SecUserManName" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Secusermanname
      {
         get {
            return sdt.gxTpr_Secusermanname ;
         }

         set {
            sdt.gxTpr_Secusermanname = value;
         }

      }

      [DataMember( Name = "SecUserManFullName" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Secusermanfullname
      {
         get {
            return sdt.gxTpr_Secusermanfullname ;
         }

         set {
            sdt.gxTpr_Secusermanfullname = value;
         }

      }

      [DataMember( Name = "SecUserTemp" , Order = 12 )]
      [GxSeudo()]
      public bool gxTpr_Secusertemp
      {
         get {
            return sdt.gxTpr_Secusertemp ;
         }

         set {
            sdt.gxTpr_Secusertemp = value;
         }

      }

      [DataMember( Name = "SecUserClienteAcesso" , Order = 13 )]
      [GxSeudo()]
      public bool gxTpr_Secuserclienteacesso
      {
         get {
            return sdt.gxTpr_Secuserclienteacesso ;
         }

         set {
            sdt.gxTpr_Secuserclienteacesso = value;
         }

      }

      [DataMember( Name = "SecUserTeste" , Order = 14 )]
      public string gxTpr_Secuserteste
      {
         get {
            return sdt.gxTpr_Secuserteste ;
         }

         set {
            sdt.gxTpr_Secuserteste = value;
         }

      }

      [DataMember( Name = "SecUserClienteId" , Order = 15 )]
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

      [DataMember( Name = "SecUserClienteFullName" , Order = 16 )]
      [GxSeudo()]
      public string gxTpr_Secuserclientefullname
      {
         get {
            return sdt.gxTpr_Secuserclientefullname ;
         }

         set {
            sdt.gxTpr_Secuserclientefullname = value;
         }

      }

      [DataMember( Name = "SecUserClienteStatus" , Order = 17 )]
      [GxSeudo()]
      public bool gxTpr_Secuserclientestatus
      {
         get {
            return sdt.gxTpr_Secuserclientestatus ;
         }

         set {
            sdt.gxTpr_Secuserclientestatus = value;
         }

      }

      [DataMember( Name = "SecUserCliClienteAcesso" , Order = 18 )]
      [GxSeudo()]
      public bool gxTpr_Secusercliclienteacesso
      {
         get {
            return sdt.gxTpr_Secusercliclienteacesso ;
         }

         set {
            sdt.gxTpr_Secusercliclienteacesso = value;
         }

      }

      [DataMember( Name = "SecUserOwnerId" , Order = 19 )]
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

      [DataMember( Name = "TipoClientePortalPjPf" , Order = 20 )]
      [GxSeudo()]
      public bool gxTpr_Tipoclienteportalpjpf
      {
         get {
            return sdt.gxTpr_Tipoclienteportalpjpf ;
         }

         set {
            sdt.gxTpr_Tipoclienteportalpjpf = value;
         }

      }

      public SdtSecUser sdt
      {
         get {
            return (SdtSecUser)Sdt ;
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
            sdt = new SdtSecUser() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 21 )]
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

   [DataContract(Name = @"SecUser", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtSecUser_RESTLInterface : GxGenericCollectionItem<SdtSecUser>
   {
      public SdtSecUser_RESTLInterface( ) : base()
      {
      }

      public SdtSecUser_RESTLInterface( SdtSecUser psdt ) : base(psdt)
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

      public SdtSecUser sdt
      {
         get {
            return (SdtSecUser)Sdt ;
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
            sdt = new SdtSecUser() ;
         }
      }

   }

}
