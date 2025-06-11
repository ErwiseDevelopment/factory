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
   [XmlRoot(ElementName = "Tags" )]
   [XmlType(TypeName =  "Tags" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtTags : GxSilentTrnSdt
   {
      public SdtTags( )
      {
      }

      public SdtTags( IGxContext context )
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

      public void Load( int AV372TagsId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV372TagsId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"TagsId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Tags");
         metadata.Set("BT", "Tags");
         metadata.Set("PK", "[ \"TagsId\" ]");
         metadata.Set("PKAssigned", "[ \"TagsId\" ]");
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
         state.Add("gxTpr_Tagsid_Z");
         state.Add("gxTpr_Tagsdescricao_Z");
         state.Add("gxTpr_Tagsconteudo_Z");
         state.Add("gxTpr_Tagsdescricao_N");
         state.Add("gxTpr_Tagsconteudo_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTags sdt;
         sdt = (SdtTags)(source);
         gxTv_SdtTags_Tagsid = sdt.gxTv_SdtTags_Tagsid ;
         gxTv_SdtTags_Tagsdescricao = sdt.gxTv_SdtTags_Tagsdescricao ;
         gxTv_SdtTags_Tagsconteudo = sdt.gxTv_SdtTags_Tagsconteudo ;
         gxTv_SdtTags_Mode = sdt.gxTv_SdtTags_Mode ;
         gxTv_SdtTags_Initialized = sdt.gxTv_SdtTags_Initialized ;
         gxTv_SdtTags_Tagsid_Z = sdt.gxTv_SdtTags_Tagsid_Z ;
         gxTv_SdtTags_Tagsdescricao_Z = sdt.gxTv_SdtTags_Tagsdescricao_Z ;
         gxTv_SdtTags_Tagsconteudo_Z = sdt.gxTv_SdtTags_Tagsconteudo_Z ;
         gxTv_SdtTags_Tagsdescricao_N = sdt.gxTv_SdtTags_Tagsdescricao_N ;
         gxTv_SdtTags_Tagsconteudo_N = sdt.gxTv_SdtTags_Tagsconteudo_N ;
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
         AddObjectProperty("TagsId", gxTv_SdtTags_Tagsid, false, includeNonInitialized);
         AddObjectProperty("TagsDescricao", gxTv_SdtTags_Tagsdescricao, false, includeNonInitialized);
         AddObjectProperty("TagsDescricao_N", gxTv_SdtTags_Tagsdescricao_N, false, includeNonInitialized);
         AddObjectProperty("TagsConteudo", gxTv_SdtTags_Tagsconteudo, false, includeNonInitialized);
         AddObjectProperty("TagsConteudo_N", gxTv_SdtTags_Tagsconteudo_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTags_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTags_Initialized, false, includeNonInitialized);
            AddObjectProperty("TagsId_Z", gxTv_SdtTags_Tagsid_Z, false, includeNonInitialized);
            AddObjectProperty("TagsDescricao_Z", gxTv_SdtTags_Tagsdescricao_Z, false, includeNonInitialized);
            AddObjectProperty("TagsConteudo_Z", gxTv_SdtTags_Tagsconteudo_Z, false, includeNonInitialized);
            AddObjectProperty("TagsDescricao_N", gxTv_SdtTags_Tagsdescricao_N, false, includeNonInitialized);
            AddObjectProperty("TagsConteudo_N", gxTv_SdtTags_Tagsconteudo_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTags sdt )
      {
         if ( sdt.IsDirty("TagsId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTags_Tagsid = sdt.gxTv_SdtTags_Tagsid ;
         }
         if ( sdt.IsDirty("TagsDescricao") )
         {
            gxTv_SdtTags_Tagsdescricao_N = (short)(sdt.gxTv_SdtTags_Tagsdescricao_N);
            sdtIsNull = 0;
            gxTv_SdtTags_Tagsdescricao = sdt.gxTv_SdtTags_Tagsdescricao ;
         }
         if ( sdt.IsDirty("TagsConteudo") )
         {
            gxTv_SdtTags_Tagsconteudo_N = (short)(sdt.gxTv_SdtTags_Tagsconteudo_N);
            sdtIsNull = 0;
            gxTv_SdtTags_Tagsconteudo = sdt.gxTv_SdtTags_Tagsconteudo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "TagsId" )]
      [  XmlElement( ElementName = "TagsId"   )]
      public int gxTpr_Tagsid
      {
         get {
            return gxTv_SdtTags_Tagsid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTags_Tagsid != value )
            {
               gxTv_SdtTags_Mode = "INS";
               this.gxTv_SdtTags_Tagsid_Z_SetNull( );
               this.gxTv_SdtTags_Tagsdescricao_Z_SetNull( );
               this.gxTv_SdtTags_Tagsconteudo_Z_SetNull( );
            }
            gxTv_SdtTags_Tagsid = value;
            SetDirty("Tagsid");
         }

      }

      [  SoapElement( ElementName = "TagsDescricao" )]
      [  XmlElement( ElementName = "TagsDescricao"   )]
      public string gxTpr_Tagsdescricao
      {
         get {
            return gxTv_SdtTags_Tagsdescricao ;
         }

         set {
            gxTv_SdtTags_Tagsdescricao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTags_Tagsdescricao = value;
            SetDirty("Tagsdescricao");
         }

      }

      public void gxTv_SdtTags_Tagsdescricao_SetNull( )
      {
         gxTv_SdtTags_Tagsdescricao_N = 1;
         gxTv_SdtTags_Tagsdescricao = "";
         SetDirty("Tagsdescricao");
         return  ;
      }

      public bool gxTv_SdtTags_Tagsdescricao_IsNull( )
      {
         return (gxTv_SdtTags_Tagsdescricao_N==1) ;
      }

      [  SoapElement( ElementName = "TagsConteudo" )]
      [  XmlElement( ElementName = "TagsConteudo"   )]
      public string gxTpr_Tagsconteudo
      {
         get {
            return gxTv_SdtTags_Tagsconteudo ;
         }

         set {
            gxTv_SdtTags_Tagsconteudo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTags_Tagsconteudo = value;
            SetDirty("Tagsconteudo");
         }

      }

      public void gxTv_SdtTags_Tagsconteudo_SetNull( )
      {
         gxTv_SdtTags_Tagsconteudo_N = 1;
         gxTv_SdtTags_Tagsconteudo = "";
         SetDirty("Tagsconteudo");
         return  ;
      }

      public bool gxTv_SdtTags_Tagsconteudo_IsNull( )
      {
         return (gxTv_SdtTags_Tagsconteudo_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTags_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTags_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTags_Mode_SetNull( )
      {
         gxTv_SdtTags_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTags_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTags_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTags_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTags_Initialized_SetNull( )
      {
         gxTv_SdtTags_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTags_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TagsId_Z" )]
      [  XmlElement( ElementName = "TagsId_Z"   )]
      public int gxTpr_Tagsid_Z
      {
         get {
            return gxTv_SdtTags_Tagsid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTags_Tagsid_Z = value;
            SetDirty("Tagsid_Z");
         }

      }

      public void gxTv_SdtTags_Tagsid_Z_SetNull( )
      {
         gxTv_SdtTags_Tagsid_Z = 0;
         SetDirty("Tagsid_Z");
         return  ;
      }

      public bool gxTv_SdtTags_Tagsid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TagsDescricao_Z" )]
      [  XmlElement( ElementName = "TagsDescricao_Z"   )]
      public string gxTpr_Tagsdescricao_Z
      {
         get {
            return gxTv_SdtTags_Tagsdescricao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTags_Tagsdescricao_Z = value;
            SetDirty("Tagsdescricao_Z");
         }

      }

      public void gxTv_SdtTags_Tagsdescricao_Z_SetNull( )
      {
         gxTv_SdtTags_Tagsdescricao_Z = "";
         SetDirty("Tagsdescricao_Z");
         return  ;
      }

      public bool gxTv_SdtTags_Tagsdescricao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TagsConteudo_Z" )]
      [  XmlElement( ElementName = "TagsConteudo_Z"   )]
      public string gxTpr_Tagsconteudo_Z
      {
         get {
            return gxTv_SdtTags_Tagsconteudo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTags_Tagsconteudo_Z = value;
            SetDirty("Tagsconteudo_Z");
         }

      }

      public void gxTv_SdtTags_Tagsconteudo_Z_SetNull( )
      {
         gxTv_SdtTags_Tagsconteudo_Z = "";
         SetDirty("Tagsconteudo_Z");
         return  ;
      }

      public bool gxTv_SdtTags_Tagsconteudo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TagsDescricao_N" )]
      [  XmlElement( ElementName = "TagsDescricao_N"   )]
      public short gxTpr_Tagsdescricao_N
      {
         get {
            return gxTv_SdtTags_Tagsdescricao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTags_Tagsdescricao_N = value;
            SetDirty("Tagsdescricao_N");
         }

      }

      public void gxTv_SdtTags_Tagsdescricao_N_SetNull( )
      {
         gxTv_SdtTags_Tagsdescricao_N = 0;
         SetDirty("Tagsdescricao_N");
         return  ;
      }

      public bool gxTv_SdtTags_Tagsdescricao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TagsConteudo_N" )]
      [  XmlElement( ElementName = "TagsConteudo_N"   )]
      public short gxTpr_Tagsconteudo_N
      {
         get {
            return gxTv_SdtTags_Tagsconteudo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTags_Tagsconteudo_N = value;
            SetDirty("Tagsconteudo_N");
         }

      }

      public void gxTv_SdtTags_Tagsconteudo_N_SetNull( )
      {
         gxTv_SdtTags_Tagsconteudo_N = 0;
         SetDirty("Tagsconteudo_N");
         return  ;
      }

      public bool gxTv_SdtTags_Tagsconteudo_N_IsNull( )
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
         gxTv_SdtTags_Tagsdescricao = "";
         gxTv_SdtTags_Tagsconteudo = "";
         gxTv_SdtTags_Mode = "";
         gxTv_SdtTags_Tagsdescricao_Z = "";
         gxTv_SdtTags_Tagsconteudo_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "tags", "GeneXus.Programs.tags_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTags_Initialized ;
      private short gxTv_SdtTags_Tagsdescricao_N ;
      private short gxTv_SdtTags_Tagsconteudo_N ;
      private int gxTv_SdtTags_Tagsid ;
      private int gxTv_SdtTags_Tagsid_Z ;
      private string gxTv_SdtTags_Mode ;
      private string gxTv_SdtTags_Tagsdescricao ;
      private string gxTv_SdtTags_Tagsconteudo ;
      private string gxTv_SdtTags_Tagsdescricao_Z ;
      private string gxTv_SdtTags_Tagsconteudo_Z ;
   }

   [DataContract(Name = @"Tags", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtTags_RESTInterface : GxGenericCollectionItem<SdtTags>
   {
      public SdtTags_RESTInterface( ) : base()
      {
      }

      public SdtTags_RESTInterface( SdtTags psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TagsId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Tagsid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Tagsid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Tagsid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "TagsDescricao" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Tagsdescricao
      {
         get {
            return sdt.gxTpr_Tagsdescricao ;
         }

         set {
            sdt.gxTpr_Tagsdescricao = value;
         }

      }

      [DataMember( Name = "TagsConteudo" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Tagsconteudo
      {
         get {
            return sdt.gxTpr_Tagsconteudo ;
         }

         set {
            sdt.gxTpr_Tagsconteudo = value;
         }

      }

      public SdtTags sdt
      {
         get {
            return (SdtTags)Sdt ;
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
            sdt = new SdtTags() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 3 )]
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

   [DataContract(Name = @"Tags", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtTags_RESTLInterface : GxGenericCollectionItem<SdtTags>
   {
      public SdtTags_RESTLInterface( ) : base()
      {
      }

      public SdtTags_RESTLInterface( SdtTags psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TagsDescricao" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Tagsdescricao
      {
         get {
            return sdt.gxTpr_Tagsdescricao ;
         }

         set {
            sdt.gxTpr_Tagsdescricao = value;
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

      public SdtTags sdt
      {
         get {
            return (SdtTags)Sdt ;
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
            sdt = new SdtTags() ;
         }
      }

   }

}
