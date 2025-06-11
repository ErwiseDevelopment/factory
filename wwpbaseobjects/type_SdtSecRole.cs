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
   [XmlRoot(ElementName = "SecRole" )]
   [XmlType(TypeName =  "SecRole" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtSecRole : GxSilentTrnSdt
   {
      public SdtSecRole( )
      {
      }

      public SdtSecRole( IGxContext context )
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

      public void Load( short AV131SecRoleId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV131SecRoleId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"SecRoleId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "WWPBaseObjects\\SecRole");
         metadata.Set("BT", "SecRole");
         metadata.Set("PK", "[ \"SecRoleId\" ]");
         metadata.Set("PKAssigned", "[ \"SecRoleId\" ]");
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
         state.Add("gxTpr_Secroleid_Z");
         state.Add("gxTpr_Secrolename_Z");
         state.Add("gxTpr_Secroledescription_Z");
         state.Add("gxTpr_Secroleactive_Z");
         state.Add("gxTpr_Secroleactive_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.wwpbaseobjects.SdtSecRole sdt;
         sdt = (GeneXus.Programs.wwpbaseobjects.SdtSecRole)(source);
         gxTv_SdtSecRole_Secroleid = sdt.gxTv_SdtSecRole_Secroleid ;
         gxTv_SdtSecRole_Secrolename = sdt.gxTv_SdtSecRole_Secrolename ;
         gxTv_SdtSecRole_Secroledescription = sdt.gxTv_SdtSecRole_Secroledescription ;
         gxTv_SdtSecRole_Secroleactive = sdt.gxTv_SdtSecRole_Secroleactive ;
         gxTv_SdtSecRole_Mode = sdt.gxTv_SdtSecRole_Mode ;
         gxTv_SdtSecRole_Initialized = sdt.gxTv_SdtSecRole_Initialized ;
         gxTv_SdtSecRole_Secroleid_Z = sdt.gxTv_SdtSecRole_Secroleid_Z ;
         gxTv_SdtSecRole_Secrolename_Z = sdt.gxTv_SdtSecRole_Secrolename_Z ;
         gxTv_SdtSecRole_Secroledescription_Z = sdt.gxTv_SdtSecRole_Secroledescription_Z ;
         gxTv_SdtSecRole_Secroleactive_Z = sdt.gxTv_SdtSecRole_Secroleactive_Z ;
         gxTv_SdtSecRole_Secroleactive_N = sdt.gxTv_SdtSecRole_Secroleactive_N ;
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
         AddObjectProperty("SecRoleId", gxTv_SdtSecRole_Secroleid, false, includeNonInitialized);
         AddObjectProperty("SecRoleName", gxTv_SdtSecRole_Secrolename, false, includeNonInitialized);
         AddObjectProperty("SecRoleDescription", gxTv_SdtSecRole_Secroledescription, false, includeNonInitialized);
         AddObjectProperty("SecRoleActive", gxTv_SdtSecRole_Secroleactive, false, includeNonInitialized);
         AddObjectProperty("SecRoleActive_N", gxTv_SdtSecRole_Secroleactive_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtSecRole_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtSecRole_Initialized, false, includeNonInitialized);
            AddObjectProperty("SecRoleId_Z", gxTv_SdtSecRole_Secroleid_Z, false, includeNonInitialized);
            AddObjectProperty("SecRoleName_Z", gxTv_SdtSecRole_Secrolename_Z, false, includeNonInitialized);
            AddObjectProperty("SecRoleDescription_Z", gxTv_SdtSecRole_Secroledescription_Z, false, includeNonInitialized);
            AddObjectProperty("SecRoleActive_Z", gxTv_SdtSecRole_Secroleactive_Z, false, includeNonInitialized);
            AddObjectProperty("SecRoleActive_N", gxTv_SdtSecRole_Secroleactive_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.wwpbaseobjects.SdtSecRole sdt )
      {
         if ( sdt.IsDirty("SecRoleId") )
         {
            sdtIsNull = 0;
            gxTv_SdtSecRole_Secroleid = sdt.gxTv_SdtSecRole_Secroleid ;
         }
         if ( sdt.IsDirty("SecRoleName") )
         {
            sdtIsNull = 0;
            gxTv_SdtSecRole_Secrolename = sdt.gxTv_SdtSecRole_Secrolename ;
         }
         if ( sdt.IsDirty("SecRoleDescription") )
         {
            sdtIsNull = 0;
            gxTv_SdtSecRole_Secroledescription = sdt.gxTv_SdtSecRole_Secroledescription ;
         }
         if ( sdt.IsDirty("SecRoleActive") )
         {
            gxTv_SdtSecRole_Secroleactive_N = (short)(sdt.gxTv_SdtSecRole_Secroleactive_N);
            sdtIsNull = 0;
            gxTv_SdtSecRole_Secroleactive = sdt.gxTv_SdtSecRole_Secroleactive ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "SecRoleId" )]
      [  XmlElement( ElementName = "SecRoleId"   )]
      public short gxTpr_Secroleid
      {
         get {
            return gxTv_SdtSecRole_Secroleid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtSecRole_Secroleid != value )
            {
               gxTv_SdtSecRole_Mode = "INS";
               this.gxTv_SdtSecRole_Secroleid_Z_SetNull( );
               this.gxTv_SdtSecRole_Secrolename_Z_SetNull( );
               this.gxTv_SdtSecRole_Secroledescription_Z_SetNull( );
               this.gxTv_SdtSecRole_Secroleactive_Z_SetNull( );
            }
            gxTv_SdtSecRole_Secroleid = value;
            SetDirty("Secroleid");
         }

      }

      [  SoapElement( ElementName = "SecRoleName" )]
      [  XmlElement( ElementName = "SecRoleName"   )]
      public string gxTpr_Secrolename
      {
         get {
            return gxTv_SdtSecRole_Secrolename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecRole_Secrolename = value;
            SetDirty("Secrolename");
         }

      }

      [  SoapElement( ElementName = "SecRoleDescription" )]
      [  XmlElement( ElementName = "SecRoleDescription"   )]
      public string gxTpr_Secroledescription
      {
         get {
            return gxTv_SdtSecRole_Secroledescription ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecRole_Secroledescription = value;
            SetDirty("Secroledescription");
         }

      }

      [  SoapElement( ElementName = "SecRoleActive" )]
      [  XmlElement( ElementName = "SecRoleActive"   )]
      public bool gxTpr_Secroleactive
      {
         get {
            return gxTv_SdtSecRole_Secroleactive ;
         }

         set {
            gxTv_SdtSecRole_Secroleactive_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecRole_Secroleactive = value;
            SetDirty("Secroleactive");
         }

      }

      public void gxTv_SdtSecRole_Secroleactive_SetNull( )
      {
         gxTv_SdtSecRole_Secroleactive_N = 1;
         gxTv_SdtSecRole_Secroleactive = false;
         SetDirty("Secroleactive");
         return  ;
      }

      public bool gxTv_SdtSecRole_Secroleactive_IsNull( )
      {
         return (gxTv_SdtSecRole_Secroleactive_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtSecRole_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecRole_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtSecRole_Mode_SetNull( )
      {
         gxTv_SdtSecRole_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtSecRole_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtSecRole_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecRole_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtSecRole_Initialized_SetNull( )
      {
         gxTv_SdtSecRole_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtSecRole_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecRoleId_Z" )]
      [  XmlElement( ElementName = "SecRoleId_Z"   )]
      public short gxTpr_Secroleid_Z
      {
         get {
            return gxTv_SdtSecRole_Secroleid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecRole_Secroleid_Z = value;
            SetDirty("Secroleid_Z");
         }

      }

      public void gxTv_SdtSecRole_Secroleid_Z_SetNull( )
      {
         gxTv_SdtSecRole_Secroleid_Z = 0;
         SetDirty("Secroleid_Z");
         return  ;
      }

      public bool gxTv_SdtSecRole_Secroleid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecRoleName_Z" )]
      [  XmlElement( ElementName = "SecRoleName_Z"   )]
      public string gxTpr_Secrolename_Z
      {
         get {
            return gxTv_SdtSecRole_Secrolename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecRole_Secrolename_Z = value;
            SetDirty("Secrolename_Z");
         }

      }

      public void gxTv_SdtSecRole_Secrolename_Z_SetNull( )
      {
         gxTv_SdtSecRole_Secrolename_Z = "";
         SetDirty("Secrolename_Z");
         return  ;
      }

      public bool gxTv_SdtSecRole_Secrolename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecRoleDescription_Z" )]
      [  XmlElement( ElementName = "SecRoleDescription_Z"   )]
      public string gxTpr_Secroledescription_Z
      {
         get {
            return gxTv_SdtSecRole_Secroledescription_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecRole_Secroledescription_Z = value;
            SetDirty("Secroledescription_Z");
         }

      }

      public void gxTv_SdtSecRole_Secroledescription_Z_SetNull( )
      {
         gxTv_SdtSecRole_Secroledescription_Z = "";
         SetDirty("Secroledescription_Z");
         return  ;
      }

      public bool gxTv_SdtSecRole_Secroledescription_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecRoleActive_Z" )]
      [  XmlElement( ElementName = "SecRoleActive_Z"   )]
      public bool gxTpr_Secroleactive_Z
      {
         get {
            return gxTv_SdtSecRole_Secroleactive_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecRole_Secroleactive_Z = value;
            SetDirty("Secroleactive_Z");
         }

      }

      public void gxTv_SdtSecRole_Secroleactive_Z_SetNull( )
      {
         gxTv_SdtSecRole_Secroleactive_Z = false;
         SetDirty("Secroleactive_Z");
         return  ;
      }

      public bool gxTv_SdtSecRole_Secroleactive_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecRoleActive_N" )]
      [  XmlElement( ElementName = "SecRoleActive_N"   )]
      public short gxTpr_Secroleactive_N
      {
         get {
            return gxTv_SdtSecRole_Secroleactive_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecRole_Secroleactive_N = value;
            SetDirty("Secroleactive_N");
         }

      }

      public void gxTv_SdtSecRole_Secroleactive_N_SetNull( )
      {
         gxTv_SdtSecRole_Secroleactive_N = 0;
         SetDirty("Secroleactive_N");
         return  ;
      }

      public bool gxTv_SdtSecRole_Secroleactive_N_IsNull( )
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
         gxTv_SdtSecRole_Secrolename = "";
         gxTv_SdtSecRole_Secroledescription = "";
         gxTv_SdtSecRole_Mode = "";
         gxTv_SdtSecRole_Secrolename_Z = "";
         gxTv_SdtSecRole_Secroledescription_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "wwpbaseobjects.secrole", "GeneXus.Programs.wwpbaseobjects.secrole_bc", new Object[] {context}, constructorCallingAssembly);;
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

      private short gxTv_SdtSecRole_Secroleid ;
      private short sdtIsNull ;
      private short gxTv_SdtSecRole_Initialized ;
      private short gxTv_SdtSecRole_Secroleid_Z ;
      private short gxTv_SdtSecRole_Secroleactive_N ;
      private string gxTv_SdtSecRole_Mode ;
      private bool gxTv_SdtSecRole_Secroleactive ;
      private bool gxTv_SdtSecRole_Secroleactive_Z ;
      private string gxTv_SdtSecRole_Secrolename ;
      private string gxTv_SdtSecRole_Secroledescription ;
      private string gxTv_SdtSecRole_Secrolename_Z ;
      private string gxTv_SdtSecRole_Secroledescription_Z ;
   }

   [DataContract(Name = @"WWPBaseObjects\SecRole", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtSecRole_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.SdtSecRole>
   {
      public SdtSecRole_RESTInterface( ) : base()
      {
      }

      public SdtSecRole_RESTInterface( GeneXus.Programs.wwpbaseobjects.SdtSecRole psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SecRoleId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Secroleid
      {
         get {
            return sdt.gxTpr_Secroleid ;
         }

         set {
            sdt.gxTpr_Secroleid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "SecRoleName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Secrolename
      {
         get {
            return sdt.gxTpr_Secrolename ;
         }

         set {
            sdt.gxTpr_Secrolename = value;
         }

      }

      [DataMember( Name = "SecRoleDescription" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Secroledescription
      {
         get {
            return sdt.gxTpr_Secroledescription ;
         }

         set {
            sdt.gxTpr_Secroledescription = value;
         }

      }

      [DataMember( Name = "SecRoleActive" , Order = 3 )]
      [GxSeudo()]
      public bool gxTpr_Secroleactive
      {
         get {
            return sdt.gxTpr_Secroleactive ;
         }

         set {
            sdt.gxTpr_Secroleactive = value;
         }

      }

      public GeneXus.Programs.wwpbaseobjects.SdtSecRole sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.SdtSecRole)Sdt ;
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
            sdt = new GeneXus.Programs.wwpbaseobjects.SdtSecRole() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 4 )]
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

   [DataContract(Name = @"WWPBaseObjects\SecRole", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtSecRole_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.SdtSecRole>
   {
      public SdtSecRole_RESTLInterface( ) : base()
      {
      }

      public SdtSecRole_RESTLInterface( GeneXus.Programs.wwpbaseobjects.SdtSecRole psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SecRoleName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Secrolename
      {
         get {
            return sdt.gxTpr_Secrolename ;
         }

         set {
            sdt.gxTpr_Secrolename = value;
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

      public GeneXus.Programs.wwpbaseobjects.SdtSecRole sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.SdtSecRole)Sdt ;
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
            sdt = new GeneXus.Programs.wwpbaseobjects.SdtSecRole() ;
         }
      }

   }

}
