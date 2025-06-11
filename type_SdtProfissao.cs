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
   [XmlRoot(ElementName = "Profissao" )]
   [XmlType(TypeName =  "Profissao" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtProfissao : GxSilentTrnSdt
   {
      public SdtProfissao( )
      {
      }

      public SdtProfissao( IGxContext context )
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

      public void Load( int AV440ProfissaoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV440ProfissaoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ProfissaoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Profissao");
         metadata.Set("BT", "Profissao");
         metadata.Set("PK", "[ \"ProfissaoId\" ]");
         metadata.Set("PKAssigned", "[ \"ProfissaoId\" ]");
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
         state.Add("gxTpr_Profissaoid_Z");
         state.Add("gxTpr_Profissaonome_Z");
         state.Add("gxTpr_Profissaonome_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtProfissao sdt;
         sdt = (SdtProfissao)(source);
         gxTv_SdtProfissao_Profissaoid = sdt.gxTv_SdtProfissao_Profissaoid ;
         gxTv_SdtProfissao_Profissaonome = sdt.gxTv_SdtProfissao_Profissaonome ;
         gxTv_SdtProfissao_Mode = sdt.gxTv_SdtProfissao_Mode ;
         gxTv_SdtProfissao_Initialized = sdt.gxTv_SdtProfissao_Initialized ;
         gxTv_SdtProfissao_Profissaoid_Z = sdt.gxTv_SdtProfissao_Profissaoid_Z ;
         gxTv_SdtProfissao_Profissaonome_Z = sdt.gxTv_SdtProfissao_Profissaonome_Z ;
         gxTv_SdtProfissao_Profissaonome_N = sdt.gxTv_SdtProfissao_Profissaonome_N ;
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
         AddObjectProperty("ProfissaoId", gxTv_SdtProfissao_Profissaoid, false, includeNonInitialized);
         AddObjectProperty("ProfissaoNome", gxTv_SdtProfissao_Profissaonome, false, includeNonInitialized);
         AddObjectProperty("ProfissaoNome_N", gxTv_SdtProfissao_Profissaonome_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtProfissao_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtProfissao_Initialized, false, includeNonInitialized);
            AddObjectProperty("ProfissaoId_Z", gxTv_SdtProfissao_Profissaoid_Z, false, includeNonInitialized);
            AddObjectProperty("ProfissaoNome_Z", gxTv_SdtProfissao_Profissaonome_Z, false, includeNonInitialized);
            AddObjectProperty("ProfissaoNome_N", gxTv_SdtProfissao_Profissaonome_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtProfissao sdt )
      {
         if ( sdt.IsDirty("ProfissaoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfissao_Profissaoid = sdt.gxTv_SdtProfissao_Profissaoid ;
         }
         if ( sdt.IsDirty("ProfissaoNome") )
         {
            gxTv_SdtProfissao_Profissaonome_N = (short)(sdt.gxTv_SdtProfissao_Profissaonome_N);
            sdtIsNull = 0;
            gxTv_SdtProfissao_Profissaonome = sdt.gxTv_SdtProfissao_Profissaonome ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ProfissaoId" )]
      [  XmlElement( ElementName = "ProfissaoId"   )]
      public int gxTpr_Profissaoid
      {
         get {
            return gxTv_SdtProfissao_Profissaoid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtProfissao_Profissaoid != value )
            {
               gxTv_SdtProfissao_Mode = "INS";
               this.gxTv_SdtProfissao_Profissaoid_Z_SetNull( );
               this.gxTv_SdtProfissao_Profissaonome_Z_SetNull( );
            }
            gxTv_SdtProfissao_Profissaoid = value;
            SetDirty("Profissaoid");
         }

      }

      [  SoapElement( ElementName = "ProfissaoNome" )]
      [  XmlElement( ElementName = "ProfissaoNome"   )]
      public string gxTpr_Profissaonome
      {
         get {
            return gxTv_SdtProfissao_Profissaonome ;
         }

         set {
            gxTv_SdtProfissao_Profissaonome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProfissao_Profissaonome = value;
            SetDirty("Profissaonome");
         }

      }

      public void gxTv_SdtProfissao_Profissaonome_SetNull( )
      {
         gxTv_SdtProfissao_Profissaonome_N = 1;
         gxTv_SdtProfissao_Profissaonome = "";
         SetDirty("Profissaonome");
         return  ;
      }

      public bool gxTv_SdtProfissao_Profissaonome_IsNull( )
      {
         return (gxTv_SdtProfissao_Profissaonome_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtProfissao_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfissao_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtProfissao_Mode_SetNull( )
      {
         gxTv_SdtProfissao_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtProfissao_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtProfissao_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfissao_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtProfissao_Initialized_SetNull( )
      {
         gxTv_SdtProfissao_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtProfissao_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfissaoId_Z" )]
      [  XmlElement( ElementName = "ProfissaoId_Z"   )]
      public int gxTpr_Profissaoid_Z
      {
         get {
            return gxTv_SdtProfissao_Profissaoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfissao_Profissaoid_Z = value;
            SetDirty("Profissaoid_Z");
         }

      }

      public void gxTv_SdtProfissao_Profissaoid_Z_SetNull( )
      {
         gxTv_SdtProfissao_Profissaoid_Z = 0;
         SetDirty("Profissaoid_Z");
         return  ;
      }

      public bool gxTv_SdtProfissao_Profissaoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfissaoNome_Z" )]
      [  XmlElement( ElementName = "ProfissaoNome_Z"   )]
      public string gxTpr_Profissaonome_Z
      {
         get {
            return gxTv_SdtProfissao_Profissaonome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfissao_Profissaonome_Z = value;
            SetDirty("Profissaonome_Z");
         }

      }

      public void gxTv_SdtProfissao_Profissaonome_Z_SetNull( )
      {
         gxTv_SdtProfissao_Profissaonome_Z = "";
         SetDirty("Profissaonome_Z");
         return  ;
      }

      public bool gxTv_SdtProfissao_Profissaonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfissaoNome_N" )]
      [  XmlElement( ElementName = "ProfissaoNome_N"   )]
      public short gxTpr_Profissaonome_N
      {
         get {
            return gxTv_SdtProfissao_Profissaonome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfissao_Profissaonome_N = value;
            SetDirty("Profissaonome_N");
         }

      }

      public void gxTv_SdtProfissao_Profissaonome_N_SetNull( )
      {
         gxTv_SdtProfissao_Profissaonome_N = 0;
         SetDirty("Profissaonome_N");
         return  ;
      }

      public bool gxTv_SdtProfissao_Profissaonome_N_IsNull( )
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
         gxTv_SdtProfissao_Profissaonome = "";
         gxTv_SdtProfissao_Mode = "";
         gxTv_SdtProfissao_Profissaonome_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "profissao", "GeneXus.Programs.profissao_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtProfissao_Initialized ;
      private short gxTv_SdtProfissao_Profissaonome_N ;
      private int gxTv_SdtProfissao_Profissaoid ;
      private int gxTv_SdtProfissao_Profissaoid_Z ;
      private string gxTv_SdtProfissao_Mode ;
      private string gxTv_SdtProfissao_Profissaonome ;
      private string gxTv_SdtProfissao_Profissaonome_Z ;
   }

   [DataContract(Name = @"Profissao", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtProfissao_RESTInterface : GxGenericCollectionItem<SdtProfissao>
   {
      public SdtProfissao_RESTInterface( ) : base()
      {
      }

      public SdtProfissao_RESTInterface( SdtProfissao psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ProfissaoId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Profissaoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Profissaoid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Profissaoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ProfissaoNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Profissaonome
      {
         get {
            return sdt.gxTpr_Profissaonome ;
         }

         set {
            sdt.gxTpr_Profissaonome = value;
         }

      }

      public SdtProfissao sdt
      {
         get {
            return (SdtProfissao)Sdt ;
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
            sdt = new SdtProfissao() ;
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

   [DataContract(Name = @"Profissao", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtProfissao_RESTLInterface : GxGenericCollectionItem<SdtProfissao>
   {
      public SdtProfissao_RESTLInterface( ) : base()
      {
      }

      public SdtProfissao_RESTLInterface( SdtProfissao psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ProfissaoNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Profissaonome
      {
         get {
            return sdt.gxTpr_Profissaonome ;
         }

         set {
            sdt.gxTpr_Profissaonome = value;
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

      public SdtProfissao sdt
      {
         get {
            return (SdtProfissao)Sdt ;
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
            sdt = new SdtProfissao() ;
         }
      }

   }

}
