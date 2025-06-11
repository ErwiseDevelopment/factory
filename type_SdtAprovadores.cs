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
   [XmlRoot(ElementName = "Aprovadores" )]
   [XmlType(TypeName =  "Aprovadores" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtAprovadores : GxSilentTrnSdt
   {
      public SdtAprovadores( )
      {
      }

      public SdtAprovadores( IGxContext context )
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

      public void Load( int AV375AprovadoresId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV375AprovadoresId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"AprovadoresId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Aprovadores");
         metadata.Set("BT", "Aprovadores");
         metadata.Set("PK", "[ \"AprovadoresId\" ]");
         metadata.Set("PKAssigned", "[ \"AprovadoresId\" ]");
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
         state.Add("gxTpr_Aprovadoresid_Z");
         state.Add("gxTpr_Secuserid_Z");
         state.Add("gxTpr_Secusername_Z");
         state.Add("gxTpr_Secuseremail_Z");
         state.Add("gxTpr_Aprovadoresstatus_Z");
         state.Add("gxTpr_Aprovadoresid_N");
         state.Add("gxTpr_Secuserid_N");
         state.Add("gxTpr_Secusername_N");
         state.Add("gxTpr_Secuseremail_N");
         state.Add("gxTpr_Aprovadoresstatus_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtAprovadores sdt;
         sdt = (SdtAprovadores)(source);
         gxTv_SdtAprovadores_Aprovadoresid = sdt.gxTv_SdtAprovadores_Aprovadoresid ;
         gxTv_SdtAprovadores_Secuserid = sdt.gxTv_SdtAprovadores_Secuserid ;
         gxTv_SdtAprovadores_Secusername = sdt.gxTv_SdtAprovadores_Secusername ;
         gxTv_SdtAprovadores_Secuseremail = sdt.gxTv_SdtAprovadores_Secuseremail ;
         gxTv_SdtAprovadores_Aprovadoresstatus = sdt.gxTv_SdtAprovadores_Aprovadoresstatus ;
         gxTv_SdtAprovadores_Mode = sdt.gxTv_SdtAprovadores_Mode ;
         gxTv_SdtAprovadores_Initialized = sdt.gxTv_SdtAprovadores_Initialized ;
         gxTv_SdtAprovadores_Aprovadoresid_Z = sdt.gxTv_SdtAprovadores_Aprovadoresid_Z ;
         gxTv_SdtAprovadores_Secuserid_Z = sdt.gxTv_SdtAprovadores_Secuserid_Z ;
         gxTv_SdtAprovadores_Secusername_Z = sdt.gxTv_SdtAprovadores_Secusername_Z ;
         gxTv_SdtAprovadores_Secuseremail_Z = sdt.gxTv_SdtAprovadores_Secuseremail_Z ;
         gxTv_SdtAprovadores_Aprovadoresstatus_Z = sdt.gxTv_SdtAprovadores_Aprovadoresstatus_Z ;
         gxTv_SdtAprovadores_Aprovadoresid_N = sdt.gxTv_SdtAprovadores_Aprovadoresid_N ;
         gxTv_SdtAprovadores_Secuserid_N = sdt.gxTv_SdtAprovadores_Secuserid_N ;
         gxTv_SdtAprovadores_Secusername_N = sdt.gxTv_SdtAprovadores_Secusername_N ;
         gxTv_SdtAprovadores_Secuseremail_N = sdt.gxTv_SdtAprovadores_Secuseremail_N ;
         gxTv_SdtAprovadores_Aprovadoresstatus_N = sdt.gxTv_SdtAprovadores_Aprovadoresstatus_N ;
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
         AddObjectProperty("AprovadoresId", gxTv_SdtAprovadores_Aprovadoresid, false, includeNonInitialized);
         AddObjectProperty("AprovadoresId_N", gxTv_SdtAprovadores_Aprovadoresid_N, false, includeNonInitialized);
         AddObjectProperty("SecUserId", gxTv_SdtAprovadores_Secuserid, false, includeNonInitialized);
         AddObjectProperty("SecUserId_N", gxTv_SdtAprovadores_Secuserid_N, false, includeNonInitialized);
         AddObjectProperty("SecUserName", gxTv_SdtAprovadores_Secusername, false, includeNonInitialized);
         AddObjectProperty("SecUserName_N", gxTv_SdtAprovadores_Secusername_N, false, includeNonInitialized);
         AddObjectProperty("SecUserEmail", gxTv_SdtAprovadores_Secuseremail, false, includeNonInitialized);
         AddObjectProperty("SecUserEmail_N", gxTv_SdtAprovadores_Secuseremail_N, false, includeNonInitialized);
         AddObjectProperty("AprovadoresStatus", gxTv_SdtAprovadores_Aprovadoresstatus, false, includeNonInitialized);
         AddObjectProperty("AprovadoresStatus_N", gxTv_SdtAprovadores_Aprovadoresstatus_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtAprovadores_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtAprovadores_Initialized, false, includeNonInitialized);
            AddObjectProperty("AprovadoresId_Z", gxTv_SdtAprovadores_Aprovadoresid_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserId_Z", gxTv_SdtAprovadores_Secuserid_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserName_Z", gxTv_SdtAprovadores_Secusername_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserEmail_Z", gxTv_SdtAprovadores_Secuseremail_Z, false, includeNonInitialized);
            AddObjectProperty("AprovadoresStatus_Z", gxTv_SdtAprovadores_Aprovadoresstatus_Z, false, includeNonInitialized);
            AddObjectProperty("AprovadoresId_N", gxTv_SdtAprovadores_Aprovadoresid_N, false, includeNonInitialized);
            AddObjectProperty("SecUserId_N", gxTv_SdtAprovadores_Secuserid_N, false, includeNonInitialized);
            AddObjectProperty("SecUserName_N", gxTv_SdtAprovadores_Secusername_N, false, includeNonInitialized);
            AddObjectProperty("SecUserEmail_N", gxTv_SdtAprovadores_Secuseremail_N, false, includeNonInitialized);
            AddObjectProperty("AprovadoresStatus_N", gxTv_SdtAprovadores_Aprovadoresstatus_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtAprovadores sdt )
      {
         if ( sdt.IsDirty("AprovadoresId") )
         {
            sdtIsNull = 0;
            gxTv_SdtAprovadores_Aprovadoresid = sdt.gxTv_SdtAprovadores_Aprovadoresid ;
         }
         if ( sdt.IsDirty("SecUserId") )
         {
            gxTv_SdtAprovadores_Secuserid_N = (short)(sdt.gxTv_SdtAprovadores_Secuserid_N);
            sdtIsNull = 0;
            gxTv_SdtAprovadores_Secuserid = sdt.gxTv_SdtAprovadores_Secuserid ;
         }
         if ( sdt.IsDirty("SecUserName") )
         {
            gxTv_SdtAprovadores_Secusername_N = (short)(sdt.gxTv_SdtAprovadores_Secusername_N);
            sdtIsNull = 0;
            gxTv_SdtAprovadores_Secusername = sdt.gxTv_SdtAprovadores_Secusername ;
         }
         if ( sdt.IsDirty("SecUserEmail") )
         {
            gxTv_SdtAprovadores_Secuseremail_N = (short)(sdt.gxTv_SdtAprovadores_Secuseremail_N);
            sdtIsNull = 0;
            gxTv_SdtAprovadores_Secuseremail = sdt.gxTv_SdtAprovadores_Secuseremail ;
         }
         if ( sdt.IsDirty("AprovadoresStatus") )
         {
            gxTv_SdtAprovadores_Aprovadoresstatus_N = (short)(sdt.gxTv_SdtAprovadores_Aprovadoresstatus_N);
            sdtIsNull = 0;
            gxTv_SdtAprovadores_Aprovadoresstatus = sdt.gxTv_SdtAprovadores_Aprovadoresstatus ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "AprovadoresId" )]
      [  XmlElement( ElementName = "AprovadoresId"   )]
      public int gxTpr_Aprovadoresid
      {
         get {
            return gxTv_SdtAprovadores_Aprovadoresid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtAprovadores_Aprovadoresid != value )
            {
               gxTv_SdtAprovadores_Mode = "INS";
               this.gxTv_SdtAprovadores_Aprovadoresid_Z_SetNull( );
               this.gxTv_SdtAprovadores_Secuserid_Z_SetNull( );
               this.gxTv_SdtAprovadores_Secusername_Z_SetNull( );
               this.gxTv_SdtAprovadores_Secuseremail_Z_SetNull( );
               this.gxTv_SdtAprovadores_Aprovadoresstatus_Z_SetNull( );
            }
            gxTv_SdtAprovadores_Aprovadoresid = value;
            SetDirty("Aprovadoresid");
         }

      }

      [  SoapElement( ElementName = "SecUserId" )]
      [  XmlElement( ElementName = "SecUserId"   )]
      public short gxTpr_Secuserid
      {
         get {
            return gxTv_SdtAprovadores_Secuserid ;
         }

         set {
            gxTv_SdtAprovadores_Secuserid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAprovadores_Secuserid = value;
            SetDirty("Secuserid");
         }

      }

      public void gxTv_SdtAprovadores_Secuserid_SetNull( )
      {
         gxTv_SdtAprovadores_Secuserid_N = 1;
         gxTv_SdtAprovadores_Secuserid = 0;
         SetDirty("Secuserid");
         return  ;
      }

      public bool gxTv_SdtAprovadores_Secuserid_IsNull( )
      {
         return (gxTv_SdtAprovadores_Secuserid_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserName" )]
      [  XmlElement( ElementName = "SecUserName"   )]
      public string gxTpr_Secusername
      {
         get {
            return gxTv_SdtAprovadores_Secusername ;
         }

         set {
            gxTv_SdtAprovadores_Secusername_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAprovadores_Secusername = value;
            SetDirty("Secusername");
         }

      }

      public void gxTv_SdtAprovadores_Secusername_SetNull( )
      {
         gxTv_SdtAprovadores_Secusername_N = 1;
         gxTv_SdtAprovadores_Secusername = "";
         SetDirty("Secusername");
         return  ;
      }

      public bool gxTv_SdtAprovadores_Secusername_IsNull( )
      {
         return (gxTv_SdtAprovadores_Secusername_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserEmail" )]
      [  XmlElement( ElementName = "SecUserEmail"   )]
      public string gxTpr_Secuseremail
      {
         get {
            return gxTv_SdtAprovadores_Secuseremail ;
         }

         set {
            gxTv_SdtAprovadores_Secuseremail_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAprovadores_Secuseremail = value;
            SetDirty("Secuseremail");
         }

      }

      public void gxTv_SdtAprovadores_Secuseremail_SetNull( )
      {
         gxTv_SdtAprovadores_Secuseremail_N = 1;
         gxTv_SdtAprovadores_Secuseremail = "";
         SetDirty("Secuseremail");
         return  ;
      }

      public bool gxTv_SdtAprovadores_Secuseremail_IsNull( )
      {
         return (gxTv_SdtAprovadores_Secuseremail_N==1) ;
      }

      [  SoapElement( ElementName = "AprovadoresStatus" )]
      [  XmlElement( ElementName = "AprovadoresStatus"   )]
      public bool gxTpr_Aprovadoresstatus
      {
         get {
            return gxTv_SdtAprovadores_Aprovadoresstatus ;
         }

         set {
            gxTv_SdtAprovadores_Aprovadoresstatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAprovadores_Aprovadoresstatus = value;
            SetDirty("Aprovadoresstatus");
         }

      }

      public void gxTv_SdtAprovadores_Aprovadoresstatus_SetNull( )
      {
         gxTv_SdtAprovadores_Aprovadoresstatus_N = 1;
         gxTv_SdtAprovadores_Aprovadoresstatus = false;
         SetDirty("Aprovadoresstatus");
         return  ;
      }

      public bool gxTv_SdtAprovadores_Aprovadoresstatus_IsNull( )
      {
         return (gxTv_SdtAprovadores_Aprovadoresstatus_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtAprovadores_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAprovadores_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtAprovadores_Mode_SetNull( )
      {
         gxTv_SdtAprovadores_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtAprovadores_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtAprovadores_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAprovadores_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtAprovadores_Initialized_SetNull( )
      {
         gxTv_SdtAprovadores_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtAprovadores_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AprovadoresId_Z" )]
      [  XmlElement( ElementName = "AprovadoresId_Z"   )]
      public int gxTpr_Aprovadoresid_Z
      {
         get {
            return gxTv_SdtAprovadores_Aprovadoresid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAprovadores_Aprovadoresid_Z = value;
            SetDirty("Aprovadoresid_Z");
         }

      }

      public void gxTv_SdtAprovadores_Aprovadoresid_Z_SetNull( )
      {
         gxTv_SdtAprovadores_Aprovadoresid_Z = 0;
         SetDirty("Aprovadoresid_Z");
         return  ;
      }

      public bool gxTv_SdtAprovadores_Aprovadoresid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserId_Z" )]
      [  XmlElement( ElementName = "SecUserId_Z"   )]
      public short gxTpr_Secuserid_Z
      {
         get {
            return gxTv_SdtAprovadores_Secuserid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAprovadores_Secuserid_Z = value;
            SetDirty("Secuserid_Z");
         }

      }

      public void gxTv_SdtAprovadores_Secuserid_Z_SetNull( )
      {
         gxTv_SdtAprovadores_Secuserid_Z = 0;
         SetDirty("Secuserid_Z");
         return  ;
      }

      public bool gxTv_SdtAprovadores_Secuserid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserName_Z" )]
      [  XmlElement( ElementName = "SecUserName_Z"   )]
      public string gxTpr_Secusername_Z
      {
         get {
            return gxTv_SdtAprovadores_Secusername_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAprovadores_Secusername_Z = value;
            SetDirty("Secusername_Z");
         }

      }

      public void gxTv_SdtAprovadores_Secusername_Z_SetNull( )
      {
         gxTv_SdtAprovadores_Secusername_Z = "";
         SetDirty("Secusername_Z");
         return  ;
      }

      public bool gxTv_SdtAprovadores_Secusername_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserEmail_Z" )]
      [  XmlElement( ElementName = "SecUserEmail_Z"   )]
      public string gxTpr_Secuseremail_Z
      {
         get {
            return gxTv_SdtAprovadores_Secuseremail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAprovadores_Secuseremail_Z = value;
            SetDirty("Secuseremail_Z");
         }

      }

      public void gxTv_SdtAprovadores_Secuseremail_Z_SetNull( )
      {
         gxTv_SdtAprovadores_Secuseremail_Z = "";
         SetDirty("Secuseremail_Z");
         return  ;
      }

      public bool gxTv_SdtAprovadores_Secuseremail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AprovadoresStatus_Z" )]
      [  XmlElement( ElementName = "AprovadoresStatus_Z"   )]
      public bool gxTpr_Aprovadoresstatus_Z
      {
         get {
            return gxTv_SdtAprovadores_Aprovadoresstatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAprovadores_Aprovadoresstatus_Z = value;
            SetDirty("Aprovadoresstatus_Z");
         }

      }

      public void gxTv_SdtAprovadores_Aprovadoresstatus_Z_SetNull( )
      {
         gxTv_SdtAprovadores_Aprovadoresstatus_Z = false;
         SetDirty("Aprovadoresstatus_Z");
         return  ;
      }

      public bool gxTv_SdtAprovadores_Aprovadoresstatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AprovadoresId_N" )]
      [  XmlElement( ElementName = "AprovadoresId_N"   )]
      public short gxTpr_Aprovadoresid_N
      {
         get {
            return gxTv_SdtAprovadores_Aprovadoresid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAprovadores_Aprovadoresid_N = value;
            SetDirty("Aprovadoresid_N");
         }

      }

      public void gxTv_SdtAprovadores_Aprovadoresid_N_SetNull( )
      {
         gxTv_SdtAprovadores_Aprovadoresid_N = 0;
         SetDirty("Aprovadoresid_N");
         return  ;
      }

      public bool gxTv_SdtAprovadores_Aprovadoresid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserId_N" )]
      [  XmlElement( ElementName = "SecUserId_N"   )]
      public short gxTpr_Secuserid_N
      {
         get {
            return gxTv_SdtAprovadores_Secuserid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAprovadores_Secuserid_N = value;
            SetDirty("Secuserid_N");
         }

      }

      public void gxTv_SdtAprovadores_Secuserid_N_SetNull( )
      {
         gxTv_SdtAprovadores_Secuserid_N = 0;
         SetDirty("Secuserid_N");
         return  ;
      }

      public bool gxTv_SdtAprovadores_Secuserid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserName_N" )]
      [  XmlElement( ElementName = "SecUserName_N"   )]
      public short gxTpr_Secusername_N
      {
         get {
            return gxTv_SdtAprovadores_Secusername_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAprovadores_Secusername_N = value;
            SetDirty("Secusername_N");
         }

      }

      public void gxTv_SdtAprovadores_Secusername_N_SetNull( )
      {
         gxTv_SdtAprovadores_Secusername_N = 0;
         SetDirty("Secusername_N");
         return  ;
      }

      public bool gxTv_SdtAprovadores_Secusername_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserEmail_N" )]
      [  XmlElement( ElementName = "SecUserEmail_N"   )]
      public short gxTpr_Secuseremail_N
      {
         get {
            return gxTv_SdtAprovadores_Secuseremail_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAprovadores_Secuseremail_N = value;
            SetDirty("Secuseremail_N");
         }

      }

      public void gxTv_SdtAprovadores_Secuseremail_N_SetNull( )
      {
         gxTv_SdtAprovadores_Secuseremail_N = 0;
         SetDirty("Secuseremail_N");
         return  ;
      }

      public bool gxTv_SdtAprovadores_Secuseremail_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AprovadoresStatus_N" )]
      [  XmlElement( ElementName = "AprovadoresStatus_N"   )]
      public short gxTpr_Aprovadoresstatus_N
      {
         get {
            return gxTv_SdtAprovadores_Aprovadoresstatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAprovadores_Aprovadoresstatus_N = value;
            SetDirty("Aprovadoresstatus_N");
         }

      }

      public void gxTv_SdtAprovadores_Aprovadoresstatus_N_SetNull( )
      {
         gxTv_SdtAprovadores_Aprovadoresstatus_N = 0;
         SetDirty("Aprovadoresstatus_N");
         return  ;
      }

      public bool gxTv_SdtAprovadores_Aprovadoresstatus_N_IsNull( )
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
         gxTv_SdtAprovadores_Secusername = "";
         gxTv_SdtAprovadores_Secuseremail = "";
         gxTv_SdtAprovadores_Mode = "";
         gxTv_SdtAprovadores_Secusername_Z = "";
         gxTv_SdtAprovadores_Secuseremail_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "aprovadores", "GeneXus.Programs.aprovadores_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtAprovadores_Secuserid ;
      private short gxTv_SdtAprovadores_Initialized ;
      private short gxTv_SdtAprovadores_Secuserid_Z ;
      private short gxTv_SdtAprovadores_Aprovadoresid_N ;
      private short gxTv_SdtAprovadores_Secuserid_N ;
      private short gxTv_SdtAprovadores_Secusername_N ;
      private short gxTv_SdtAprovadores_Secuseremail_N ;
      private short gxTv_SdtAprovadores_Aprovadoresstatus_N ;
      private int gxTv_SdtAprovadores_Aprovadoresid ;
      private int gxTv_SdtAprovadores_Aprovadoresid_Z ;
      private string gxTv_SdtAprovadores_Mode ;
      private bool gxTv_SdtAprovadores_Aprovadoresstatus ;
      private bool gxTv_SdtAprovadores_Aprovadoresstatus_Z ;
      private string gxTv_SdtAprovadores_Secusername ;
      private string gxTv_SdtAprovadores_Secuseremail ;
      private string gxTv_SdtAprovadores_Secusername_Z ;
      private string gxTv_SdtAprovadores_Secuseremail_Z ;
   }

   [DataContract(Name = @"Aprovadores", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtAprovadores_RESTInterface : GxGenericCollectionItem<SdtAprovadores>
   {
      public SdtAprovadores_RESTInterface( ) : base()
      {
      }

      public SdtAprovadores_RESTInterface( SdtAprovadores psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AprovadoresId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Aprovadoresid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Aprovadoresid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Aprovadoresid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
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

      [DataMember( Name = "AprovadoresStatus" , Order = 4 )]
      [GxSeudo()]
      public bool gxTpr_Aprovadoresstatus
      {
         get {
            return sdt.gxTpr_Aprovadoresstatus ;
         }

         set {
            sdt.gxTpr_Aprovadoresstatus = value;
         }

      }

      public SdtAprovadores sdt
      {
         get {
            return (SdtAprovadores)Sdt ;
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
            sdt = new SdtAprovadores() ;
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

   [DataContract(Name = @"Aprovadores", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtAprovadores_RESTLInterface : GxGenericCollectionItem<SdtAprovadores>
   {
      public SdtAprovadores_RESTLInterface( ) : base()
      {
      }

      public SdtAprovadores_RESTLInterface( SdtAprovadores psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AprovadoresStatus" , Order = 0 )]
      [GxSeudo()]
      public bool gxTpr_Aprovadoresstatus
      {
         get {
            return sdt.gxTpr_Aprovadoresstatus ;
         }

         set {
            sdt.gxTpr_Aprovadoresstatus = value;
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

      public SdtAprovadores sdt
      {
         get {
            return (SdtAprovadores)Sdt ;
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
            sdt = new SdtAprovadores() ;
         }
      }

   }

}
