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
   [XmlRoot(ElementName = "SecObject.Functionalities" )]
   [XmlType(TypeName =  "SecObject.Functionalities" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtSecObject_Functionalities : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtSecObject_Functionalities( )
      {
      }

      public SdtSecObject_Functionalities( IGxContext context )
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

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"SecFunctionalityId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Functionalities");
         metadata.Set("BT", "SecObjectFunctionalities");
         metadata.Set("PK", "[ \"SecFunctionalityId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"SecFunctionalityId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"SecObjectName\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Modified");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Secfunctionalityid_Z");
         state.Add("gxTpr_Secfunctionalitydescription_Z");
         state.Add("gxTpr_Secfunctionalitydescription_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities sdt;
         sdt = (GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities)(source);
         gxTv_SdtSecObject_Functionalities_Secfunctionalityid = sdt.gxTv_SdtSecObject_Functionalities_Secfunctionalityid ;
         gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription = sdt.gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription ;
         gxTv_SdtSecObject_Functionalities_Mode = sdt.gxTv_SdtSecObject_Functionalities_Mode ;
         gxTv_SdtSecObject_Functionalities_Modified = sdt.gxTv_SdtSecObject_Functionalities_Modified ;
         gxTv_SdtSecObject_Functionalities_Initialized = sdt.gxTv_SdtSecObject_Functionalities_Initialized ;
         gxTv_SdtSecObject_Functionalities_Secfunctionalityid_Z = sdt.gxTv_SdtSecObject_Functionalities_Secfunctionalityid_Z ;
         gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription_Z = sdt.gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription_Z ;
         gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription_N = sdt.gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription_N ;
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
         AddObjectProperty("SecFunctionalityId", gxTv_SdtSecObject_Functionalities_Secfunctionalityid, false, includeNonInitialized);
         AddObjectProperty("SecFunctionalityDescription", gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription, false, includeNonInitialized);
         AddObjectProperty("SecFunctionalityDescription_N", gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtSecObject_Functionalities_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtSecObject_Functionalities_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtSecObject_Functionalities_Initialized, false, includeNonInitialized);
            AddObjectProperty("SecFunctionalityId_Z", gxTv_SdtSecObject_Functionalities_Secfunctionalityid_Z, false, includeNonInitialized);
            AddObjectProperty("SecFunctionalityDescription_Z", gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription_Z, false, includeNonInitialized);
            AddObjectProperty("SecFunctionalityDescription_N", gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities sdt )
      {
         if ( sdt.IsDirty("SecFunctionalityId") )
         {
            sdtIsNull = 0;
            gxTv_SdtSecObject_Functionalities_Secfunctionalityid = sdt.gxTv_SdtSecObject_Functionalities_Secfunctionalityid ;
         }
         if ( sdt.IsDirty("SecFunctionalityDescription") )
         {
            gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription_N = (short)(sdt.gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription_N);
            sdtIsNull = 0;
            gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription = sdt.gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "SecFunctionalityId" )]
      [  XmlElement( ElementName = "SecFunctionalityId"   )]
      public long gxTpr_Secfunctionalityid
      {
         get {
            return gxTv_SdtSecObject_Functionalities_Secfunctionalityid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecObject_Functionalities_Secfunctionalityid = value;
            gxTv_SdtSecObject_Functionalities_Modified = 1;
            SetDirty("Secfunctionalityid");
         }

      }

      [  SoapElement( ElementName = "SecFunctionalityDescription" )]
      [  XmlElement( ElementName = "SecFunctionalityDescription"   )]
      public string gxTpr_Secfunctionalitydescription
      {
         get {
            return gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription ;
         }

         set {
            gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription = value;
            gxTv_SdtSecObject_Functionalities_Modified = 1;
            SetDirty("Secfunctionalitydescription");
         }

      }

      public void gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription_SetNull( )
      {
         gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription_N = 1;
         gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription = "";
         SetDirty("Secfunctionalitydescription");
         return  ;
      }

      public bool gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription_IsNull( )
      {
         return (gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtSecObject_Functionalities_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecObject_Functionalities_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtSecObject_Functionalities_Mode_SetNull( )
      {
         gxTv_SdtSecObject_Functionalities_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtSecObject_Functionalities_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtSecObject_Functionalities_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecObject_Functionalities_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtSecObject_Functionalities_Modified_SetNull( )
      {
         gxTv_SdtSecObject_Functionalities_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtSecObject_Functionalities_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtSecObject_Functionalities_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecObject_Functionalities_Initialized = value;
            gxTv_SdtSecObject_Functionalities_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtSecObject_Functionalities_Initialized_SetNull( )
      {
         gxTv_SdtSecObject_Functionalities_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtSecObject_Functionalities_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecFunctionalityId_Z" )]
      [  XmlElement( ElementName = "SecFunctionalityId_Z"   )]
      public long gxTpr_Secfunctionalityid_Z
      {
         get {
            return gxTv_SdtSecObject_Functionalities_Secfunctionalityid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecObject_Functionalities_Secfunctionalityid_Z = value;
            gxTv_SdtSecObject_Functionalities_Modified = 1;
            SetDirty("Secfunctionalityid_Z");
         }

      }

      public void gxTv_SdtSecObject_Functionalities_Secfunctionalityid_Z_SetNull( )
      {
         gxTv_SdtSecObject_Functionalities_Secfunctionalityid_Z = 0;
         SetDirty("Secfunctionalityid_Z");
         return  ;
      }

      public bool gxTv_SdtSecObject_Functionalities_Secfunctionalityid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecFunctionalityDescription_Z" )]
      [  XmlElement( ElementName = "SecFunctionalityDescription_Z"   )]
      public string gxTpr_Secfunctionalitydescription_Z
      {
         get {
            return gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription_Z = value;
            gxTv_SdtSecObject_Functionalities_Modified = 1;
            SetDirty("Secfunctionalitydescription_Z");
         }

      }

      public void gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription_Z_SetNull( )
      {
         gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription_Z = "";
         SetDirty("Secfunctionalitydescription_Z");
         return  ;
      }

      public bool gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecFunctionalityDescription_N" )]
      [  XmlElement( ElementName = "SecFunctionalityDescription_N"   )]
      public short gxTpr_Secfunctionalitydescription_N
      {
         get {
            return gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription_N = value;
            gxTv_SdtSecObject_Functionalities_Modified = 1;
            SetDirty("Secfunctionalitydescription_N");
         }

      }

      public void gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription_N_SetNull( )
      {
         gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription_N = 0;
         SetDirty("Secfunctionalitydescription_N");
         return  ;
      }

      public bool gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription_N_IsNull( )
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
         gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription = "";
         gxTv_SdtSecObject_Functionalities_Mode = "";
         gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtSecObject_Functionalities_Modified ;
      private short gxTv_SdtSecObject_Functionalities_Initialized ;
      private short gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription_N ;
      private long gxTv_SdtSecObject_Functionalities_Secfunctionalityid ;
      private long gxTv_SdtSecObject_Functionalities_Secfunctionalityid_Z ;
      private string gxTv_SdtSecObject_Functionalities_Mode ;
      private string gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription ;
      private string gxTv_SdtSecObject_Functionalities_Secfunctionalitydescription_Z ;
   }

   [DataContract(Name = @"WWPBaseObjects\SecObject.Functionalities", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtSecObject_Functionalities_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities>
   {
      public SdtSecObject_Functionalities_RESTInterface( ) : base()
      {
      }

      public SdtSecObject_Functionalities_RESTInterface( GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities psdt ) : base(psdt)
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

      public GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities)Sdt ;
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
            sdt = new GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities() ;
         }
      }

   }

   [DataContract(Name = @"WWPBaseObjects\SecObject.Functionalities", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtSecObject_Functionalities_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities>
   {
      public SdtSecObject_Functionalities_RESTLInterface( ) : base()
      {
      }

      public SdtSecObject_Functionalities_RESTLInterface( GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities psdt ) : base(psdt)
      {
      }

      public GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities)Sdt ;
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
            sdt = new GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities() ;
         }
      }

   }

}
