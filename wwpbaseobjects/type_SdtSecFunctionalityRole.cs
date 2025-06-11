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
   [XmlRoot(ElementName = "SecFunctionalityRole" )]
   [XmlType(TypeName =  "SecFunctionalityRole" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtSecFunctionalityRole : GxSilentTrnSdt
   {
      public SdtSecFunctionalityRole( )
      {
      }

      public SdtSecFunctionalityRole( IGxContext context )
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

      public void Load( long AV128SecFunctionalityId ,
                        short AV131SecRoleId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(long)AV128SecFunctionalityId,(short)AV131SecRoleId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"SecFunctionalityId", typeof(long)}, new Object[]{"SecRoleId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "WWPBaseObjects\\SecFunctionalityRole");
         metadata.Set("BT", "SecFunctionalityRole");
         metadata.Set("PK", "[ \"SecFunctionalityId\",\"SecRoleId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"SecFunctionalityId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"SecRoleId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Secfunctionalityid_Z");
         state.Add("gxTpr_Secfunctionalitydescription_Z");
         state.Add("gxTpr_Secroleid_Z");
         state.Add("gxTpr_Secfunctionalityroleativo_Z");
         state.Add("gxTpr_Secfunctionalitydescription_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole sdt;
         sdt = (GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole)(source);
         gxTv_SdtSecFunctionalityRole_Secfunctionalityid = sdt.gxTv_SdtSecFunctionalityRole_Secfunctionalityid ;
         gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription = sdt.gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription ;
         gxTv_SdtSecFunctionalityRole_Secroleid = sdt.gxTv_SdtSecFunctionalityRole_Secroleid ;
         gxTv_SdtSecFunctionalityRole_Secfunctionalityroleativo = sdt.gxTv_SdtSecFunctionalityRole_Secfunctionalityroleativo ;
         gxTv_SdtSecFunctionalityRole_Mode = sdt.gxTv_SdtSecFunctionalityRole_Mode ;
         gxTv_SdtSecFunctionalityRole_Initialized = sdt.gxTv_SdtSecFunctionalityRole_Initialized ;
         gxTv_SdtSecFunctionalityRole_Secfunctionalityid_Z = sdt.gxTv_SdtSecFunctionalityRole_Secfunctionalityid_Z ;
         gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription_Z = sdt.gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription_Z ;
         gxTv_SdtSecFunctionalityRole_Secroleid_Z = sdt.gxTv_SdtSecFunctionalityRole_Secroleid_Z ;
         gxTv_SdtSecFunctionalityRole_Secfunctionalityroleativo_Z = sdt.gxTv_SdtSecFunctionalityRole_Secfunctionalityroleativo_Z ;
         gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription_N = sdt.gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription_N ;
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
         AddObjectProperty("SecFunctionalityId", gxTv_SdtSecFunctionalityRole_Secfunctionalityid, false, includeNonInitialized);
         AddObjectProperty("SecFunctionalityDescription", gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription, false, includeNonInitialized);
         AddObjectProperty("SecFunctionalityDescription_N", gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription_N, false, includeNonInitialized);
         AddObjectProperty("SecRoleId", gxTv_SdtSecFunctionalityRole_Secroleid, false, includeNonInitialized);
         AddObjectProperty("SecFunctionalityRoleAtivo", gxTv_SdtSecFunctionalityRole_Secfunctionalityroleativo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtSecFunctionalityRole_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtSecFunctionalityRole_Initialized, false, includeNonInitialized);
            AddObjectProperty("SecFunctionalityId_Z", gxTv_SdtSecFunctionalityRole_Secfunctionalityid_Z, false, includeNonInitialized);
            AddObjectProperty("SecFunctionalityDescription_Z", gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription_Z, false, includeNonInitialized);
            AddObjectProperty("SecRoleId_Z", gxTv_SdtSecFunctionalityRole_Secroleid_Z, false, includeNonInitialized);
            AddObjectProperty("SecFunctionalityRoleAtivo_Z", gxTv_SdtSecFunctionalityRole_Secfunctionalityroleativo_Z, false, includeNonInitialized);
            AddObjectProperty("SecFunctionalityDescription_N", gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole sdt )
      {
         if ( sdt.IsDirty("SecFunctionalityId") )
         {
            sdtIsNull = 0;
            gxTv_SdtSecFunctionalityRole_Secfunctionalityid = sdt.gxTv_SdtSecFunctionalityRole_Secfunctionalityid ;
         }
         if ( sdt.IsDirty("SecFunctionalityDescription") )
         {
            gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription_N = (short)(sdt.gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription_N);
            sdtIsNull = 0;
            gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription = sdt.gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription ;
         }
         if ( sdt.IsDirty("SecRoleId") )
         {
            sdtIsNull = 0;
            gxTv_SdtSecFunctionalityRole_Secroleid = sdt.gxTv_SdtSecFunctionalityRole_Secroleid ;
         }
         if ( sdt.IsDirty("SecFunctionalityRoleAtivo") )
         {
            sdtIsNull = 0;
            gxTv_SdtSecFunctionalityRole_Secfunctionalityroleativo = sdt.gxTv_SdtSecFunctionalityRole_Secfunctionalityroleativo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "SecFunctionalityId" )]
      [  XmlElement( ElementName = "SecFunctionalityId"   )]
      public long gxTpr_Secfunctionalityid
      {
         get {
            return gxTv_SdtSecFunctionalityRole_Secfunctionalityid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtSecFunctionalityRole_Secfunctionalityid != value )
            {
               gxTv_SdtSecFunctionalityRole_Mode = "INS";
               this.gxTv_SdtSecFunctionalityRole_Secfunctionalityid_Z_SetNull( );
               this.gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription_Z_SetNull( );
               this.gxTv_SdtSecFunctionalityRole_Secroleid_Z_SetNull( );
               this.gxTv_SdtSecFunctionalityRole_Secfunctionalityroleativo_Z_SetNull( );
            }
            gxTv_SdtSecFunctionalityRole_Secfunctionalityid = value;
            SetDirty("Secfunctionalityid");
         }

      }

      [  SoapElement( ElementName = "SecFunctionalityDescription" )]
      [  XmlElement( ElementName = "SecFunctionalityDescription"   )]
      public string gxTpr_Secfunctionalitydescription
      {
         get {
            return gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription ;
         }

         set {
            gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription = value;
            SetDirty("Secfunctionalitydescription");
         }

      }

      public void gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription_SetNull( )
      {
         gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription_N = 1;
         gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription = "";
         SetDirty("Secfunctionalitydescription");
         return  ;
      }

      public bool gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription_IsNull( )
      {
         return (gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription_N==1) ;
      }

      [  SoapElement( ElementName = "SecRoleId" )]
      [  XmlElement( ElementName = "SecRoleId"   )]
      public short gxTpr_Secroleid
      {
         get {
            return gxTv_SdtSecFunctionalityRole_Secroleid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtSecFunctionalityRole_Secroleid != value )
            {
               gxTv_SdtSecFunctionalityRole_Mode = "INS";
               this.gxTv_SdtSecFunctionalityRole_Secfunctionalityid_Z_SetNull( );
               this.gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription_Z_SetNull( );
               this.gxTv_SdtSecFunctionalityRole_Secroleid_Z_SetNull( );
               this.gxTv_SdtSecFunctionalityRole_Secfunctionalityroleativo_Z_SetNull( );
            }
            gxTv_SdtSecFunctionalityRole_Secroleid = value;
            SetDirty("Secroleid");
         }

      }

      [  SoapElement( ElementName = "SecFunctionalityRoleAtivo" )]
      [  XmlElement( ElementName = "SecFunctionalityRoleAtivo"   )]
      public bool gxTpr_Secfunctionalityroleativo
      {
         get {
            return gxTv_SdtSecFunctionalityRole_Secfunctionalityroleativo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecFunctionalityRole_Secfunctionalityroleativo = value;
            SetDirty("Secfunctionalityroleativo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtSecFunctionalityRole_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecFunctionalityRole_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtSecFunctionalityRole_Mode_SetNull( )
      {
         gxTv_SdtSecFunctionalityRole_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtSecFunctionalityRole_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtSecFunctionalityRole_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecFunctionalityRole_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtSecFunctionalityRole_Initialized_SetNull( )
      {
         gxTv_SdtSecFunctionalityRole_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtSecFunctionalityRole_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecFunctionalityId_Z" )]
      [  XmlElement( ElementName = "SecFunctionalityId_Z"   )]
      public long gxTpr_Secfunctionalityid_Z
      {
         get {
            return gxTv_SdtSecFunctionalityRole_Secfunctionalityid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecFunctionalityRole_Secfunctionalityid_Z = value;
            SetDirty("Secfunctionalityid_Z");
         }

      }

      public void gxTv_SdtSecFunctionalityRole_Secfunctionalityid_Z_SetNull( )
      {
         gxTv_SdtSecFunctionalityRole_Secfunctionalityid_Z = 0;
         SetDirty("Secfunctionalityid_Z");
         return  ;
      }

      public bool gxTv_SdtSecFunctionalityRole_Secfunctionalityid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecFunctionalityDescription_Z" )]
      [  XmlElement( ElementName = "SecFunctionalityDescription_Z"   )]
      public string gxTpr_Secfunctionalitydescription_Z
      {
         get {
            return gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription_Z = value;
            SetDirty("Secfunctionalitydescription_Z");
         }

      }

      public void gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription_Z_SetNull( )
      {
         gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription_Z = "";
         SetDirty("Secfunctionalitydescription_Z");
         return  ;
      }

      public bool gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecRoleId_Z" )]
      [  XmlElement( ElementName = "SecRoleId_Z"   )]
      public short gxTpr_Secroleid_Z
      {
         get {
            return gxTv_SdtSecFunctionalityRole_Secroleid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecFunctionalityRole_Secroleid_Z = value;
            SetDirty("Secroleid_Z");
         }

      }

      public void gxTv_SdtSecFunctionalityRole_Secroleid_Z_SetNull( )
      {
         gxTv_SdtSecFunctionalityRole_Secroleid_Z = 0;
         SetDirty("Secroleid_Z");
         return  ;
      }

      public bool gxTv_SdtSecFunctionalityRole_Secroleid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecFunctionalityRoleAtivo_Z" )]
      [  XmlElement( ElementName = "SecFunctionalityRoleAtivo_Z"   )]
      public bool gxTpr_Secfunctionalityroleativo_Z
      {
         get {
            return gxTv_SdtSecFunctionalityRole_Secfunctionalityroleativo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecFunctionalityRole_Secfunctionalityroleativo_Z = value;
            SetDirty("Secfunctionalityroleativo_Z");
         }

      }

      public void gxTv_SdtSecFunctionalityRole_Secfunctionalityroleativo_Z_SetNull( )
      {
         gxTv_SdtSecFunctionalityRole_Secfunctionalityroleativo_Z = false;
         SetDirty("Secfunctionalityroleativo_Z");
         return  ;
      }

      public bool gxTv_SdtSecFunctionalityRole_Secfunctionalityroleativo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecFunctionalityDescription_N" )]
      [  XmlElement( ElementName = "SecFunctionalityDescription_N"   )]
      public short gxTpr_Secfunctionalitydescription_N
      {
         get {
            return gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription_N = value;
            SetDirty("Secfunctionalitydescription_N");
         }

      }

      public void gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription_N_SetNull( )
      {
         gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription_N = 0;
         SetDirty("Secfunctionalitydescription_N");
         return  ;
      }

      public bool gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription_N_IsNull( )
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
         gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription = "";
         gxTv_SdtSecFunctionalityRole_Mode = "";
         gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "wwpbaseobjects.secfunctionalityrole", "GeneXus.Programs.wwpbaseobjects.secfunctionalityrole_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtSecFunctionalityRole_Secroleid ;
      private short gxTv_SdtSecFunctionalityRole_Initialized ;
      private short gxTv_SdtSecFunctionalityRole_Secroleid_Z ;
      private short gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription_N ;
      private long gxTv_SdtSecFunctionalityRole_Secfunctionalityid ;
      private long gxTv_SdtSecFunctionalityRole_Secfunctionalityid_Z ;
      private string gxTv_SdtSecFunctionalityRole_Mode ;
      private bool gxTv_SdtSecFunctionalityRole_Secfunctionalityroleativo ;
      private bool gxTv_SdtSecFunctionalityRole_Secfunctionalityroleativo_Z ;
      private string gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription ;
      private string gxTv_SdtSecFunctionalityRole_Secfunctionalitydescription_Z ;
   }

   [DataContract(Name = @"WWPBaseObjects\SecFunctionalityRole", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtSecFunctionalityRole_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole>
   {
      public SdtSecFunctionalityRole_RESTInterface( ) : base()
      {
      }

      public SdtSecFunctionalityRole_RESTInterface( GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SecFunctionalityId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Secfunctionalityid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Secfunctionalityid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Secfunctionalityid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "SecFunctionalityDescription" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Secfunctionalitydescription
      {
         get {
            return sdt.gxTpr_Secfunctionalitydescription ;
         }

         set {
            sdt.gxTpr_Secfunctionalitydescription = value;
         }

      }

      [DataMember( Name = "SecRoleId" , Order = 2 )]
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

      [DataMember( Name = "SecFunctionalityRoleAtivo" , Order = 3 )]
      [GxSeudo()]
      public bool gxTpr_Secfunctionalityroleativo
      {
         get {
            return sdt.gxTpr_Secfunctionalityroleativo ;
         }

         set {
            sdt.gxTpr_Secfunctionalityroleativo = value;
         }

      }

      public GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole)Sdt ;
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
            sdt = new GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole() ;
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

   [DataContract(Name = @"WWPBaseObjects\SecFunctionalityRole", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtSecFunctionalityRole_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole>
   {
      public SdtSecFunctionalityRole_RESTLInterface( ) : base()
      {
      }

      public SdtSecFunctionalityRole_RESTLInterface( GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SecFunctionalityRoleAtivo" , Order = 0 )]
      [GxSeudo()]
      public bool gxTpr_Secfunctionalityroleativo
      {
         get {
            return sdt.gxTpr_Secfunctionalityroleativo ;
         }

         set {
            sdt.gxTpr_Secfunctionalityroleativo = value;
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

      public GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole)Sdt ;
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
            sdt = new GeneXus.Programs.wwpbaseobjects.SdtSecFunctionalityRole() ;
         }
      }

   }

}
