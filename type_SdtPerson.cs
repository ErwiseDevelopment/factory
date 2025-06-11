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
   [XmlRoot(ElementName = "Person" )]
   [XmlType(TypeName =  "Person" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtPerson : GxSilentTrnSdt
   {
      public SdtPerson( )
      {
      }

      public SdtPerson( IGxContext context )
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

      public void Load( int AV151PersonID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV151PersonID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"PersonID", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Person");
         metadata.Set("BT", "Person");
         metadata.Set("PK", "[ \"PersonID\" ]");
         metadata.Set("PKAssigned", "[ \"PersonID\" ]");
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
         state.Add("gxTpr_Personid_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtPerson sdt;
         sdt = (SdtPerson)(source);
         gxTv_SdtPerson_Personid = sdt.gxTv_SdtPerson_Personid ;
         gxTv_SdtPerson_Mode = sdt.gxTv_SdtPerson_Mode ;
         gxTv_SdtPerson_Initialized = sdt.gxTv_SdtPerson_Initialized ;
         gxTv_SdtPerson_Personid_Z = sdt.gxTv_SdtPerson_Personid_Z ;
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
         AddObjectProperty("PersonID", gxTv_SdtPerson_Personid, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtPerson_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtPerson_Initialized, false, includeNonInitialized);
            AddObjectProperty("PersonID_Z", gxTv_SdtPerson_Personid_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtPerson sdt )
      {
         if ( sdt.IsDirty("PersonID") )
         {
            sdtIsNull = 0;
            gxTv_SdtPerson_Personid = sdt.gxTv_SdtPerson_Personid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "PersonID" )]
      [  XmlElement( ElementName = "PersonID"   )]
      public int gxTpr_Personid
      {
         get {
            return gxTv_SdtPerson_Personid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtPerson_Personid != value )
            {
               gxTv_SdtPerson_Mode = "INS";
               this.gxTv_SdtPerson_Personid_Z_SetNull( );
            }
            gxTv_SdtPerson_Personid = value;
            SetDirty("Personid");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtPerson_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPerson_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtPerson_Mode_SetNull( )
      {
         gxTv_SdtPerson_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtPerson_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtPerson_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPerson_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtPerson_Initialized_SetNull( )
      {
         gxTv_SdtPerson_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtPerson_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PersonID_Z" )]
      [  XmlElement( ElementName = "PersonID_Z"   )]
      public int gxTpr_Personid_Z
      {
         get {
            return gxTv_SdtPerson_Personid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPerson_Personid_Z = value;
            SetDirty("Personid_Z");
         }

      }

      public void gxTv_SdtPerson_Personid_Z_SetNull( )
      {
         gxTv_SdtPerson_Personid_Z = 0;
         SetDirty("Personid_Z");
         return  ;
      }

      public bool gxTv_SdtPerson_Personid_Z_IsNull( )
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
         gxTv_SdtPerson_Mode = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "person", "GeneXus.Programs.person_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtPerson_Initialized ;
      private int gxTv_SdtPerson_Personid ;
      private int gxTv_SdtPerson_Personid_Z ;
      private string gxTv_SdtPerson_Mode ;
   }

   [DataContract(Name = @"Person", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtPerson_RESTInterface : GxGenericCollectionItem<SdtPerson>
   {
      public SdtPerson_RESTInterface( ) : base()
      {
      }

      public SdtPerson_RESTInterface( SdtPerson psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PersonID" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Personid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Personid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Personid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      public SdtPerson sdt
      {
         get {
            return (SdtPerson)Sdt ;
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
            sdt = new SdtPerson() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 1 )]
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

   [DataContract(Name = @"Person", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtPerson_RESTLInterface : GxGenericCollectionItem<SdtPerson>
   {
      public SdtPerson_RESTLInterface( ) : base()
      {
      }

      public SdtPerson_RESTLInterface( SdtPerson psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PersonID" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Personid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Personid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Personid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "uri" , Order = 1 )]
      public string Uri
      {
         get {
            string gxuri = "/rest/Person/{0}";
            gxuri = String.Format(gxuri,gxTpr_Personid) ;
            return gxuri ;
         }

         set {
         }

      }

      public SdtPerson sdt
      {
         get {
            return (SdtPerson)Sdt ;
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
            sdt = new SdtPerson() ;
         }
      }

      private string gxuri ;
   }

}
