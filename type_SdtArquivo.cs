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
   [XmlRoot(ElementName = "Arquivo" )]
   [XmlType(TypeName =  "Arquivo" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtArquivo : GxSilentTrnSdt
   {
      public SdtArquivo( )
      {
      }

      public SdtArquivo( IGxContext context )
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

      public void Load( int AV231ArquivoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV231ArquivoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ArquivoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Arquivo");
         metadata.Set("BT", "Arquivo");
         metadata.Set("PK", "[ \"ArquivoId\" ]");
         metadata.Set("PKAssigned", "[ \"ArquivoId\" ]");
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
         state.Add("gxTpr_Arquivoid_Z");
         state.Add("gxTpr_Arquivonome_Z");
         state.Add("gxTpr_Arquivoextensao_Z");
         state.Add("gxTpr_Arquivoid_N");
         state.Add("gxTpr_Arquivonome_N");
         state.Add("gxTpr_Arquivoextensao_N");
         state.Add("gxTpr_Arquivoblob_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtArquivo sdt;
         sdt = (SdtArquivo)(source);
         gxTv_SdtArquivo_Arquivoid = sdt.gxTv_SdtArquivo_Arquivoid ;
         gxTv_SdtArquivo_Arquivonome = sdt.gxTv_SdtArquivo_Arquivonome ;
         gxTv_SdtArquivo_Arquivoextensao = sdt.gxTv_SdtArquivo_Arquivoextensao ;
         gxTv_SdtArquivo_Arquivoblob = sdt.gxTv_SdtArquivo_Arquivoblob ;
         gxTv_SdtArquivo_Mode = sdt.gxTv_SdtArquivo_Mode ;
         gxTv_SdtArquivo_Initialized = sdt.gxTv_SdtArquivo_Initialized ;
         gxTv_SdtArquivo_Arquivoid_Z = sdt.gxTv_SdtArquivo_Arquivoid_Z ;
         gxTv_SdtArquivo_Arquivonome_Z = sdt.gxTv_SdtArquivo_Arquivonome_Z ;
         gxTv_SdtArquivo_Arquivoextensao_Z = sdt.gxTv_SdtArquivo_Arquivoextensao_Z ;
         gxTv_SdtArquivo_Arquivoid_N = sdt.gxTv_SdtArquivo_Arquivoid_N ;
         gxTv_SdtArquivo_Arquivonome_N = sdt.gxTv_SdtArquivo_Arquivonome_N ;
         gxTv_SdtArquivo_Arquivoextensao_N = sdt.gxTv_SdtArquivo_Arquivoextensao_N ;
         gxTv_SdtArquivo_Arquivoblob_N = sdt.gxTv_SdtArquivo_Arquivoblob_N ;
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
         AddObjectProperty("ArquivoId", gxTv_SdtArquivo_Arquivoid, false, includeNonInitialized);
         AddObjectProperty("ArquivoId_N", gxTv_SdtArquivo_Arquivoid_N, false, includeNonInitialized);
         AddObjectProperty("ArquivoNome", gxTv_SdtArquivo_Arquivonome, false, includeNonInitialized);
         AddObjectProperty("ArquivoNome_N", gxTv_SdtArquivo_Arquivonome_N, false, includeNonInitialized);
         AddObjectProperty("ArquivoExtensao", gxTv_SdtArquivo_Arquivoextensao, false, includeNonInitialized);
         AddObjectProperty("ArquivoExtensao_N", gxTv_SdtArquivo_Arquivoextensao_N, false, includeNonInitialized);
         AddObjectProperty("ArquivoBlob", gxTv_SdtArquivo_Arquivoblob, false, includeNonInitialized);
         AddObjectProperty("ArquivoBlob_N", gxTv_SdtArquivo_Arquivoblob_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtArquivo_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtArquivo_Initialized, false, includeNonInitialized);
            AddObjectProperty("ArquivoId_Z", gxTv_SdtArquivo_Arquivoid_Z, false, includeNonInitialized);
            AddObjectProperty("ArquivoNome_Z", gxTv_SdtArquivo_Arquivonome_Z, false, includeNonInitialized);
            AddObjectProperty("ArquivoExtensao_Z", gxTv_SdtArquivo_Arquivoextensao_Z, false, includeNonInitialized);
            AddObjectProperty("ArquivoId_N", gxTv_SdtArquivo_Arquivoid_N, false, includeNonInitialized);
            AddObjectProperty("ArquivoNome_N", gxTv_SdtArquivo_Arquivonome_N, false, includeNonInitialized);
            AddObjectProperty("ArquivoExtensao_N", gxTv_SdtArquivo_Arquivoextensao_N, false, includeNonInitialized);
            AddObjectProperty("ArquivoBlob_N", gxTv_SdtArquivo_Arquivoblob_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtArquivo sdt )
      {
         if ( sdt.IsDirty("ArquivoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtArquivo_Arquivoid = sdt.gxTv_SdtArquivo_Arquivoid ;
         }
         if ( sdt.IsDirty("ArquivoNome") )
         {
            gxTv_SdtArquivo_Arquivonome_N = (short)(sdt.gxTv_SdtArquivo_Arquivonome_N);
            sdtIsNull = 0;
            gxTv_SdtArquivo_Arquivonome = sdt.gxTv_SdtArquivo_Arquivonome ;
         }
         if ( sdt.IsDirty("ArquivoExtensao") )
         {
            gxTv_SdtArquivo_Arquivoextensao_N = (short)(sdt.gxTv_SdtArquivo_Arquivoextensao_N);
            sdtIsNull = 0;
            gxTv_SdtArquivo_Arquivoextensao = sdt.gxTv_SdtArquivo_Arquivoextensao ;
         }
         if ( sdt.IsDirty("ArquivoBlob") )
         {
            gxTv_SdtArquivo_Arquivoblob_N = (short)(sdt.gxTv_SdtArquivo_Arquivoblob_N);
            sdtIsNull = 0;
            gxTv_SdtArquivo_Arquivoblob = sdt.gxTv_SdtArquivo_Arquivoblob ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ArquivoId" )]
      [  XmlElement( ElementName = "ArquivoId"   )]
      public int gxTpr_Arquivoid
      {
         get {
            return gxTv_SdtArquivo_Arquivoid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtArquivo_Arquivoid != value )
            {
               gxTv_SdtArquivo_Mode = "INS";
               this.gxTv_SdtArquivo_Arquivoid_Z_SetNull( );
               this.gxTv_SdtArquivo_Arquivonome_Z_SetNull( );
               this.gxTv_SdtArquivo_Arquivoextensao_Z_SetNull( );
            }
            gxTv_SdtArquivo_Arquivoid = value;
            SetDirty("Arquivoid");
         }

      }

      [  SoapElement( ElementName = "ArquivoNome" )]
      [  XmlElement( ElementName = "ArquivoNome"   )]
      public string gxTpr_Arquivonome
      {
         get {
            return gxTv_SdtArquivo_Arquivonome ;
         }

         set {
            gxTv_SdtArquivo_Arquivonome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtArquivo_Arquivonome = value;
            SetDirty("Arquivonome");
         }

      }

      public void gxTv_SdtArquivo_Arquivonome_SetNull( )
      {
         gxTv_SdtArquivo_Arquivonome_N = 1;
         gxTv_SdtArquivo_Arquivonome = "";
         SetDirty("Arquivonome");
         return  ;
      }

      public bool gxTv_SdtArquivo_Arquivonome_IsNull( )
      {
         return (gxTv_SdtArquivo_Arquivonome_N==1) ;
      }

      [  SoapElement( ElementName = "ArquivoExtensao" )]
      [  XmlElement( ElementName = "ArquivoExtensao"   )]
      public string gxTpr_Arquivoextensao
      {
         get {
            return gxTv_SdtArquivo_Arquivoextensao ;
         }

         set {
            gxTv_SdtArquivo_Arquivoextensao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtArquivo_Arquivoextensao = value;
            SetDirty("Arquivoextensao");
         }

      }

      public void gxTv_SdtArquivo_Arquivoextensao_SetNull( )
      {
         gxTv_SdtArquivo_Arquivoextensao_N = 1;
         gxTv_SdtArquivo_Arquivoextensao = "";
         SetDirty("Arquivoextensao");
         return  ;
      }

      public bool gxTv_SdtArquivo_Arquivoextensao_IsNull( )
      {
         return (gxTv_SdtArquivo_Arquivoextensao_N==1) ;
      }

      [  SoapElement( ElementName = "ArquivoBlob" )]
      [  XmlElement( ElementName = "ArquivoBlob"   )]
      [GxUpload()]
      public byte[] gxTpr_Arquivoblob_Blob
      {
         get {
            IGxContext context = this.context == null ? new GxContext() : this.context;
            return context.FileToByteArray( gxTv_SdtArquivo_Arquivoblob) ;
         }

         set {
            gxTv_SdtArquivo_Arquivoblob_N = 0;
            sdtIsNull = 0;
            IGxContext context = this.context == null ? new GxContext() : this.context;
            gxTv_SdtArquivo_Arquivoblob=context.FileFromByteArray( value) ;
         }

      }

      [XmlIgnore]
      [GxUpload()]
      public string gxTpr_Arquivoblob
      {
         get {
            return gxTv_SdtArquivo_Arquivoblob ;
         }

         set {
            gxTv_SdtArquivo_Arquivoblob_N = 0;
            sdtIsNull = 0;
            gxTv_SdtArquivo_Arquivoblob = value;
            SetDirty("Arquivoblob");
         }

      }

      public void gxTv_SdtArquivo_Arquivoblob_SetBlob( string blob ,
                                                       string fileName ,
                                                       string fileType )
      {
         gxTv_SdtArquivo_Arquivoblob = blob;
         gxTv_SdtArquivo_Arquivonome = fileName;
         gxTv_SdtArquivo_Arquivoextensao = fileType;
         return  ;
      }

      public void gxTv_SdtArquivo_Arquivoblob_SetNull( )
      {
         gxTv_SdtArquivo_Arquivoblob_N = 1;
         gxTv_SdtArquivo_Arquivoblob = "";
         SetDirty("Arquivoblob");
         return  ;
      }

      public bool gxTv_SdtArquivo_Arquivoblob_IsNull( )
      {
         return (gxTv_SdtArquivo_Arquivoblob_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtArquivo_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtArquivo_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtArquivo_Mode_SetNull( )
      {
         gxTv_SdtArquivo_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtArquivo_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtArquivo_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtArquivo_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtArquivo_Initialized_SetNull( )
      {
         gxTv_SdtArquivo_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtArquivo_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ArquivoId_Z" )]
      [  XmlElement( ElementName = "ArquivoId_Z"   )]
      public int gxTpr_Arquivoid_Z
      {
         get {
            return gxTv_SdtArquivo_Arquivoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtArquivo_Arquivoid_Z = value;
            SetDirty("Arquivoid_Z");
         }

      }

      public void gxTv_SdtArquivo_Arquivoid_Z_SetNull( )
      {
         gxTv_SdtArquivo_Arquivoid_Z = 0;
         SetDirty("Arquivoid_Z");
         return  ;
      }

      public bool gxTv_SdtArquivo_Arquivoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ArquivoNome_Z" )]
      [  XmlElement( ElementName = "ArquivoNome_Z"   )]
      public string gxTpr_Arquivonome_Z
      {
         get {
            return gxTv_SdtArquivo_Arquivonome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtArquivo_Arquivonome_Z = value;
            SetDirty("Arquivonome_Z");
         }

      }

      public void gxTv_SdtArquivo_Arquivonome_Z_SetNull( )
      {
         gxTv_SdtArquivo_Arquivonome_Z = "";
         SetDirty("Arquivonome_Z");
         return  ;
      }

      public bool gxTv_SdtArquivo_Arquivonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ArquivoExtensao_Z" )]
      [  XmlElement( ElementName = "ArquivoExtensao_Z"   )]
      public string gxTpr_Arquivoextensao_Z
      {
         get {
            return gxTv_SdtArquivo_Arquivoextensao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtArquivo_Arquivoextensao_Z = value;
            SetDirty("Arquivoextensao_Z");
         }

      }

      public void gxTv_SdtArquivo_Arquivoextensao_Z_SetNull( )
      {
         gxTv_SdtArquivo_Arquivoextensao_Z = "";
         SetDirty("Arquivoextensao_Z");
         return  ;
      }

      public bool gxTv_SdtArquivo_Arquivoextensao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ArquivoId_N" )]
      [  XmlElement( ElementName = "ArquivoId_N"   )]
      public short gxTpr_Arquivoid_N
      {
         get {
            return gxTv_SdtArquivo_Arquivoid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtArquivo_Arquivoid_N = value;
            SetDirty("Arquivoid_N");
         }

      }

      public void gxTv_SdtArquivo_Arquivoid_N_SetNull( )
      {
         gxTv_SdtArquivo_Arquivoid_N = 0;
         SetDirty("Arquivoid_N");
         return  ;
      }

      public bool gxTv_SdtArquivo_Arquivoid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ArquivoNome_N" )]
      [  XmlElement( ElementName = "ArquivoNome_N"   )]
      public short gxTpr_Arquivonome_N
      {
         get {
            return gxTv_SdtArquivo_Arquivonome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtArquivo_Arquivonome_N = value;
            SetDirty("Arquivonome_N");
         }

      }

      public void gxTv_SdtArquivo_Arquivonome_N_SetNull( )
      {
         gxTv_SdtArquivo_Arquivonome_N = 0;
         SetDirty("Arquivonome_N");
         return  ;
      }

      public bool gxTv_SdtArquivo_Arquivonome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ArquivoExtensao_N" )]
      [  XmlElement( ElementName = "ArquivoExtensao_N"   )]
      public short gxTpr_Arquivoextensao_N
      {
         get {
            return gxTv_SdtArquivo_Arquivoextensao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtArquivo_Arquivoextensao_N = value;
            SetDirty("Arquivoextensao_N");
         }

      }

      public void gxTv_SdtArquivo_Arquivoextensao_N_SetNull( )
      {
         gxTv_SdtArquivo_Arquivoextensao_N = 0;
         SetDirty("Arquivoextensao_N");
         return  ;
      }

      public bool gxTv_SdtArquivo_Arquivoextensao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ArquivoBlob_N" )]
      [  XmlElement( ElementName = "ArquivoBlob_N"   )]
      public short gxTpr_Arquivoblob_N
      {
         get {
            return gxTv_SdtArquivo_Arquivoblob_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtArquivo_Arquivoblob_N = value;
            SetDirty("Arquivoblob_N");
         }

      }

      public void gxTv_SdtArquivo_Arquivoblob_N_SetNull( )
      {
         gxTv_SdtArquivo_Arquivoblob_N = 0;
         SetDirty("Arquivoblob_N");
         return  ;
      }

      public bool gxTv_SdtArquivo_Arquivoblob_N_IsNull( )
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
         gxTv_SdtArquivo_Arquivonome = "";
         gxTv_SdtArquivo_Arquivoextensao = "";
         gxTv_SdtArquivo_Arquivoblob = "";
         gxTv_SdtArquivo_Mode = "";
         gxTv_SdtArquivo_Arquivonome_Z = "";
         gxTv_SdtArquivo_Arquivoextensao_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "arquivo", "GeneXus.Programs.arquivo_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtArquivo_Initialized ;
      private short gxTv_SdtArquivo_Arquivoid_N ;
      private short gxTv_SdtArquivo_Arquivonome_N ;
      private short gxTv_SdtArquivo_Arquivoextensao_N ;
      private short gxTv_SdtArquivo_Arquivoblob_N ;
      private int gxTv_SdtArquivo_Arquivoid ;
      private int gxTv_SdtArquivo_Arquivoid_Z ;
      private string gxTv_SdtArquivo_Mode ;
      private string gxTv_SdtArquivo_Arquivonome ;
      private string gxTv_SdtArquivo_Arquivoextensao ;
      private string gxTv_SdtArquivo_Arquivonome_Z ;
      private string gxTv_SdtArquivo_Arquivoextensao_Z ;
      private string gxTv_SdtArquivo_Arquivoblob ;
   }

   [DataContract(Name = @"Arquivo", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtArquivo_RESTInterface : GxGenericCollectionItem<SdtArquivo>
   {
      public SdtArquivo_RESTInterface( ) : base()
      {
      }

      public SdtArquivo_RESTInterface( SdtArquivo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ArquivoId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Arquivoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Arquivoid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Arquivoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ArquivoNome" , Order = 1 )]
      public string gxTpr_Arquivonome
      {
         get {
            return sdt.gxTpr_Arquivonome ;
         }

         set {
            sdt.gxTpr_Arquivonome = value;
         }

      }

      [DataMember( Name = "ArquivoExtensao" , Order = 2 )]
      public string gxTpr_Arquivoextensao
      {
         get {
            return sdt.gxTpr_Arquivoextensao ;
         }

         set {
            sdt.gxTpr_Arquivoextensao = value;
         }

      }

      [DataMember( Name = "ArquivoBlob" , Order = 3 )]
      [GxUpload()]
      public string gxTpr_Arquivoblob
      {
         get {
            return PathUtil.RelativeURL( sdt.gxTpr_Arquivoblob) ;
         }

         set {
            sdt.gxTpr_Arquivoblob = value;
         }

      }

      public SdtArquivo sdt
      {
         get {
            return (SdtArquivo)Sdt ;
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
            sdt = new SdtArquivo() ;
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

   [DataContract(Name = @"Arquivo", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtArquivo_RESTLInterface : GxGenericCollectionItem<SdtArquivo>
   {
      public SdtArquivo_RESTLInterface( ) : base()
      {
      }

      public SdtArquivo_RESTLInterface( SdtArquivo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ArquivoNome" , Order = 0 )]
      public string gxTpr_Arquivonome
      {
         get {
            return sdt.gxTpr_Arquivonome ;
         }

         set {
            sdt.gxTpr_Arquivonome = value;
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

      public SdtArquivo sdt
      {
         get {
            return (SdtArquivo)Sdt ;
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
            sdt = new SdtArquivo() ;
         }
      }

   }

}
