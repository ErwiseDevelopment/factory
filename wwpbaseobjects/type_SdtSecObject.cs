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
   [XmlRoot(ElementName = "SecObject" )]
   [XmlType(TypeName =  "SecObject" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtSecObject : GxSilentTrnSdt
   {
      public SdtSecObject( )
      {
      }

      public SdtSecObject( IGxContext context )
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

      public void Load( string AV132SecObjectName )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(string)AV132SecObjectName});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"SecObjectName", typeof(string)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "WWPBaseObjects\\SecObject");
         metadata.Set("BT", "SecObject");
         metadata.Set("PK", "[ \"SecObjectName\" ]");
         metadata.Set("Levels", "[ \"Functionalities\" ]");
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
         state.Add("gxTpr_Secobjectname_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.wwpbaseobjects.SdtSecObject sdt;
         sdt = (GeneXus.Programs.wwpbaseobjects.SdtSecObject)(source);
         gxTv_SdtSecObject_Secobjectname = sdt.gxTv_SdtSecObject_Secobjectname ;
         gxTv_SdtSecObject_Functionalities = sdt.gxTv_SdtSecObject_Functionalities ;
         gxTv_SdtSecObject_Mode = sdt.gxTv_SdtSecObject_Mode ;
         gxTv_SdtSecObject_Initialized = sdt.gxTv_SdtSecObject_Initialized ;
         gxTv_SdtSecObject_Secobjectname_Z = sdt.gxTv_SdtSecObject_Secobjectname_Z ;
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
         AddObjectProperty("SecObjectName", gxTv_SdtSecObject_Secobjectname, false, includeNonInitialized);
         if ( gxTv_SdtSecObject_Functionalities != null )
         {
            AddObjectProperty("Functionalities", gxTv_SdtSecObject_Functionalities, includeState, includeNonInitialized);
         }
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtSecObject_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtSecObject_Initialized, false, includeNonInitialized);
            AddObjectProperty("SecObjectName_Z", gxTv_SdtSecObject_Secobjectname_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.wwpbaseobjects.SdtSecObject sdt )
      {
         if ( sdt.IsDirty("SecObjectName") )
         {
            sdtIsNull = 0;
            gxTv_SdtSecObject_Secobjectname = sdt.gxTv_SdtSecObject_Secobjectname ;
         }
         if ( gxTv_SdtSecObject_Functionalities != null )
         {
            GXBCLevelCollection<GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities> newCollectionFunctionalities = sdt.gxTpr_Functionalities;
            GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities currItemFunctionalities;
            GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities newItemFunctionalities;
            short idx = 1;
            while ( idx <= newCollectionFunctionalities.Count )
            {
               newItemFunctionalities = ((GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities)newCollectionFunctionalities.Item(idx));
               currItemFunctionalities = gxTv_SdtSecObject_Functionalities.GetByKey(newItemFunctionalities.gxTpr_Secfunctionalityid);
               if ( StringUtil.StrCmp(currItemFunctionalities.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemFunctionalities.UpdateDirties(newItemFunctionalities);
                  if ( StringUtil.StrCmp(newItemFunctionalities.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemFunctionalities.gxTpr_Mode = "DLT";
                  }
                  currItemFunctionalities.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtSecObject_Functionalities.Add(newItemFunctionalities, 0);
               }
               idx = (short)(idx+1);
            }
         }
         return  ;
      }

      [  SoapElement( ElementName = "SecObjectName" )]
      [  XmlElement( ElementName = "SecObjectName"   )]
      public string gxTpr_Secobjectname
      {
         get {
            return gxTv_SdtSecObject_Secobjectname ;
         }

         set {
            sdtIsNull = 0;
            if ( StringUtil.StrCmp(gxTv_SdtSecObject_Secobjectname, value) != 0 )
            {
               gxTv_SdtSecObject_Mode = "INS";
               this.gxTv_SdtSecObject_Secobjectname_Z_SetNull( );
               if ( gxTv_SdtSecObject_Functionalities != null )
               {
                  GXBCLevelCollection<GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities> collectionFunctionalities = gxTv_SdtSecObject_Functionalities;
                  GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities currItemFunctionalities;
                  short idx = 1;
                  while ( idx <= collectionFunctionalities.Count )
                  {
                     currItemFunctionalities = ((GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities)collectionFunctionalities.Item(idx));
                     currItemFunctionalities.gxTpr_Mode = "INS";
                     currItemFunctionalities.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtSecObject_Secobjectname = value;
            SetDirty("Secobjectname");
         }

      }

      [  SoapElement( ElementName = "Functionalities" )]
      [  XmlArray( ElementName = "Functionalities"  )]
      [  XmlArrayItemAttribute( ElementName= "SecObject.Functionalities"  , IsNullable=false)]
      public GXBCLevelCollection<GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities> gxTpr_Functionalities_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtSecObject_Functionalities == null )
            {
               gxTv_SdtSecObject_Functionalities = new GXBCLevelCollection<GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities>( context, "SecObject.Functionalities", "Factory21");
            }
            return gxTv_SdtSecObject_Functionalities ;
         }

         set {
            if ( gxTv_SdtSecObject_Functionalities == null )
            {
               gxTv_SdtSecObject_Functionalities = new GXBCLevelCollection<GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities>( context, "SecObject.Functionalities", "Factory21");
            }
            sdtIsNull = 0;
            gxTv_SdtSecObject_Functionalities = value;
         }

      }

      [XmlIgnore]
      public GXBCLevelCollection<GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities> gxTpr_Functionalities
      {
         get {
            if ( gxTv_SdtSecObject_Functionalities == null )
            {
               gxTv_SdtSecObject_Functionalities = new GXBCLevelCollection<GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities>( context, "SecObject.Functionalities", "Factory21");
            }
            sdtIsNull = 0;
            return gxTv_SdtSecObject_Functionalities ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecObject_Functionalities = value;
            SetDirty("Functionalities");
         }

      }

      public void gxTv_SdtSecObject_Functionalities_SetNull( )
      {
         gxTv_SdtSecObject_Functionalities = null;
         SetDirty("Functionalities");
         return  ;
      }

      public bool gxTv_SdtSecObject_Functionalities_IsNull( )
      {
         if ( gxTv_SdtSecObject_Functionalities == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtSecObject_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecObject_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtSecObject_Mode_SetNull( )
      {
         gxTv_SdtSecObject_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtSecObject_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtSecObject_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecObject_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtSecObject_Initialized_SetNull( )
      {
         gxTv_SdtSecObject_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtSecObject_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecObjectName_Z" )]
      [  XmlElement( ElementName = "SecObjectName_Z"   )]
      public string gxTpr_Secobjectname_Z
      {
         get {
            return gxTv_SdtSecObject_Secobjectname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecObject_Secobjectname_Z = value;
            SetDirty("Secobjectname_Z");
         }

      }

      public void gxTv_SdtSecObject_Secobjectname_Z_SetNull( )
      {
         gxTv_SdtSecObject_Secobjectname_Z = "";
         SetDirty("Secobjectname_Z");
         return  ;
      }

      public bool gxTv_SdtSecObject_Secobjectname_Z_IsNull( )
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
         gxTv_SdtSecObject_Secobjectname = "";
         sdtIsNull = 1;
         gxTv_SdtSecObject_Mode = "";
         gxTv_SdtSecObject_Secobjectname_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "wwpbaseobjects.secobject", "GeneXus.Programs.wwpbaseobjects.secobject_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtSecObject_Initialized ;
      private string gxTv_SdtSecObject_Mode ;
      private string gxTv_SdtSecObject_Secobjectname ;
      private string gxTv_SdtSecObject_Secobjectname_Z ;
      private GXBCLevelCollection<GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities> gxTv_SdtSecObject_Functionalities=null ;
   }

   [DataContract(Name = @"WWPBaseObjects\SecObject", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtSecObject_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.SdtSecObject>
   {
      public SdtSecObject_RESTInterface( ) : base()
      {
      }

      public SdtSecObject_RESTInterface( GeneXus.Programs.wwpbaseobjects.SdtSecObject psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SecObjectName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Secobjectname
      {
         get {
            return sdt.gxTpr_Secobjectname ;
         }

         set {
            sdt.gxTpr_Secobjectname = value;
         }

      }

      [DataMember( Name = "Functionalities" , Order = 1 )]
      public GxGenericCollection<GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities_RESTInterface> gxTpr_Functionalities
      {
         get {
            return new GxGenericCollection<GeneXus.Programs.wwpbaseobjects.SdtSecObject_Functionalities_RESTInterface>(sdt.gxTpr_Functionalities) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Functionalities);
         }

      }

      public GeneXus.Programs.wwpbaseobjects.SdtSecObject sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.SdtSecObject)Sdt ;
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
            sdt = new GeneXus.Programs.wwpbaseobjects.SdtSecObject() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 2 )]
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

   [DataContract(Name = @"WWPBaseObjects\SecObject", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtSecObject_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.SdtSecObject>
   {
      public SdtSecObject_RESTLInterface( ) : base()
      {
      }

      public SdtSecObject_RESTLInterface( GeneXus.Programs.wwpbaseobjects.SdtSecObject psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SecObjectName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Secobjectname
      {
         get {
            return sdt.gxTpr_Secobjectname ;
         }

         set {
            sdt.gxTpr_Secobjectname = value;
         }

      }

      [DataMember( Name = "uri" , Order = 1 )]
      public string Uri
      {
         get {
            string gxuri = "/rest/WWPBaseObjects\\SecObject/{0}";
            gxuri = String.Format(gxuri,gxTpr_Secobjectname) ;
            return gxuri ;
         }

         set {
         }

      }

      public GeneXus.Programs.wwpbaseobjects.SdtSecObject sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.SdtSecObject)Sdt ;
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
            sdt = new GeneXus.Programs.wwpbaseobjects.SdtSecObject() ;
         }
      }

      private string gxuri ;
   }

}
