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
   [XmlRoot(ElementName = "Nacionalidade" )]
   [XmlType(TypeName =  "Nacionalidade" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtNacionalidade : GxSilentTrnSdt
   {
      public SdtNacionalidade( )
      {
      }

      public SdtNacionalidade( IGxContext context )
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

      public void Load( int AV434NacionalidadeId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV434NacionalidadeId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"NacionalidadeId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Nacionalidade");
         metadata.Set("BT", "Nacionalidade");
         metadata.Set("PK", "[ \"NacionalidadeId\" ]");
         metadata.Set("PKAssigned", "[ \"NacionalidadeId\" ]");
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
         state.Add("gxTpr_Nacionalidadeid_Z");
         state.Add("gxTpr_Nacionalidadenome_Z");
         state.Add("gxTpr_Nacionalidadenome_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtNacionalidade sdt;
         sdt = (SdtNacionalidade)(source);
         gxTv_SdtNacionalidade_Nacionalidadeid = sdt.gxTv_SdtNacionalidade_Nacionalidadeid ;
         gxTv_SdtNacionalidade_Nacionalidadenome = sdt.gxTv_SdtNacionalidade_Nacionalidadenome ;
         gxTv_SdtNacionalidade_Mode = sdt.gxTv_SdtNacionalidade_Mode ;
         gxTv_SdtNacionalidade_Initialized = sdt.gxTv_SdtNacionalidade_Initialized ;
         gxTv_SdtNacionalidade_Nacionalidadeid_Z = sdt.gxTv_SdtNacionalidade_Nacionalidadeid_Z ;
         gxTv_SdtNacionalidade_Nacionalidadenome_Z = sdt.gxTv_SdtNacionalidade_Nacionalidadenome_Z ;
         gxTv_SdtNacionalidade_Nacionalidadenome_N = sdt.gxTv_SdtNacionalidade_Nacionalidadenome_N ;
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
         AddObjectProperty("NacionalidadeId", gxTv_SdtNacionalidade_Nacionalidadeid, false, includeNonInitialized);
         AddObjectProperty("NacionalidadeNome", gxTv_SdtNacionalidade_Nacionalidadenome, false, includeNonInitialized);
         AddObjectProperty("NacionalidadeNome_N", gxTv_SdtNacionalidade_Nacionalidadenome_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtNacionalidade_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtNacionalidade_Initialized, false, includeNonInitialized);
            AddObjectProperty("NacionalidadeId_Z", gxTv_SdtNacionalidade_Nacionalidadeid_Z, false, includeNonInitialized);
            AddObjectProperty("NacionalidadeNome_Z", gxTv_SdtNacionalidade_Nacionalidadenome_Z, false, includeNonInitialized);
            AddObjectProperty("NacionalidadeNome_N", gxTv_SdtNacionalidade_Nacionalidadenome_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtNacionalidade sdt )
      {
         if ( sdt.IsDirty("NacionalidadeId") )
         {
            sdtIsNull = 0;
            gxTv_SdtNacionalidade_Nacionalidadeid = sdt.gxTv_SdtNacionalidade_Nacionalidadeid ;
         }
         if ( sdt.IsDirty("NacionalidadeNome") )
         {
            gxTv_SdtNacionalidade_Nacionalidadenome_N = (short)(sdt.gxTv_SdtNacionalidade_Nacionalidadenome_N);
            sdtIsNull = 0;
            gxTv_SdtNacionalidade_Nacionalidadenome = sdt.gxTv_SdtNacionalidade_Nacionalidadenome ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "NacionalidadeId" )]
      [  XmlElement( ElementName = "NacionalidadeId"   )]
      public int gxTpr_Nacionalidadeid
      {
         get {
            return gxTv_SdtNacionalidade_Nacionalidadeid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtNacionalidade_Nacionalidadeid != value )
            {
               gxTv_SdtNacionalidade_Mode = "INS";
               this.gxTv_SdtNacionalidade_Nacionalidadeid_Z_SetNull( );
               this.gxTv_SdtNacionalidade_Nacionalidadenome_Z_SetNull( );
            }
            gxTv_SdtNacionalidade_Nacionalidadeid = value;
            SetDirty("Nacionalidadeid");
         }

      }

      [  SoapElement( ElementName = "NacionalidadeNome" )]
      [  XmlElement( ElementName = "NacionalidadeNome"   )]
      public string gxTpr_Nacionalidadenome
      {
         get {
            return gxTv_SdtNacionalidade_Nacionalidadenome ;
         }

         set {
            gxTv_SdtNacionalidade_Nacionalidadenome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtNacionalidade_Nacionalidadenome = value;
            SetDirty("Nacionalidadenome");
         }

      }

      public void gxTv_SdtNacionalidade_Nacionalidadenome_SetNull( )
      {
         gxTv_SdtNacionalidade_Nacionalidadenome_N = 1;
         gxTv_SdtNacionalidade_Nacionalidadenome = "";
         SetDirty("Nacionalidadenome");
         return  ;
      }

      public bool gxTv_SdtNacionalidade_Nacionalidadenome_IsNull( )
      {
         return (gxTv_SdtNacionalidade_Nacionalidadenome_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtNacionalidade_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNacionalidade_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtNacionalidade_Mode_SetNull( )
      {
         gxTv_SdtNacionalidade_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtNacionalidade_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtNacionalidade_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNacionalidade_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtNacionalidade_Initialized_SetNull( )
      {
         gxTv_SdtNacionalidade_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtNacionalidade_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NacionalidadeId_Z" )]
      [  XmlElement( ElementName = "NacionalidadeId_Z"   )]
      public int gxTpr_Nacionalidadeid_Z
      {
         get {
            return gxTv_SdtNacionalidade_Nacionalidadeid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNacionalidade_Nacionalidadeid_Z = value;
            SetDirty("Nacionalidadeid_Z");
         }

      }

      public void gxTv_SdtNacionalidade_Nacionalidadeid_Z_SetNull( )
      {
         gxTv_SdtNacionalidade_Nacionalidadeid_Z = 0;
         SetDirty("Nacionalidadeid_Z");
         return  ;
      }

      public bool gxTv_SdtNacionalidade_Nacionalidadeid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NacionalidadeNome_Z" )]
      [  XmlElement( ElementName = "NacionalidadeNome_Z"   )]
      public string gxTpr_Nacionalidadenome_Z
      {
         get {
            return gxTv_SdtNacionalidade_Nacionalidadenome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNacionalidade_Nacionalidadenome_Z = value;
            SetDirty("Nacionalidadenome_Z");
         }

      }

      public void gxTv_SdtNacionalidade_Nacionalidadenome_Z_SetNull( )
      {
         gxTv_SdtNacionalidade_Nacionalidadenome_Z = "";
         SetDirty("Nacionalidadenome_Z");
         return  ;
      }

      public bool gxTv_SdtNacionalidade_Nacionalidadenome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "NacionalidadeNome_N" )]
      [  XmlElement( ElementName = "NacionalidadeNome_N"   )]
      public short gxTpr_Nacionalidadenome_N
      {
         get {
            return gxTv_SdtNacionalidade_Nacionalidadenome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtNacionalidade_Nacionalidadenome_N = value;
            SetDirty("Nacionalidadenome_N");
         }

      }

      public void gxTv_SdtNacionalidade_Nacionalidadenome_N_SetNull( )
      {
         gxTv_SdtNacionalidade_Nacionalidadenome_N = 0;
         SetDirty("Nacionalidadenome_N");
         return  ;
      }

      public bool gxTv_SdtNacionalidade_Nacionalidadenome_N_IsNull( )
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
         gxTv_SdtNacionalidade_Nacionalidadenome = "";
         gxTv_SdtNacionalidade_Mode = "";
         gxTv_SdtNacionalidade_Nacionalidadenome_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "nacionalidade", "GeneXus.Programs.nacionalidade_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtNacionalidade_Initialized ;
      private short gxTv_SdtNacionalidade_Nacionalidadenome_N ;
      private int gxTv_SdtNacionalidade_Nacionalidadeid ;
      private int gxTv_SdtNacionalidade_Nacionalidadeid_Z ;
      private string gxTv_SdtNacionalidade_Mode ;
      private string gxTv_SdtNacionalidade_Nacionalidadenome ;
      private string gxTv_SdtNacionalidade_Nacionalidadenome_Z ;
   }

   [DataContract(Name = @"Nacionalidade", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtNacionalidade_RESTInterface : GxGenericCollectionItem<SdtNacionalidade>
   {
      public SdtNacionalidade_RESTInterface( ) : base()
      {
      }

      public SdtNacionalidade_RESTInterface( SdtNacionalidade psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "NacionalidadeId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Nacionalidadeid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Nacionalidadeid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Nacionalidadeid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "NacionalidadeNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Nacionalidadenome
      {
         get {
            return sdt.gxTpr_Nacionalidadenome ;
         }

         set {
            sdt.gxTpr_Nacionalidadenome = value;
         }

      }

      public SdtNacionalidade sdt
      {
         get {
            return (SdtNacionalidade)Sdt ;
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
            sdt = new SdtNacionalidade() ;
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

   [DataContract(Name = @"Nacionalidade", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtNacionalidade_RESTLInterface : GxGenericCollectionItem<SdtNacionalidade>
   {
      public SdtNacionalidade_RESTLInterface( ) : base()
      {
      }

      public SdtNacionalidade_RESTLInterface( SdtNacionalidade psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "NacionalidadeNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Nacionalidadenome
      {
         get {
            return sdt.gxTpr_Nacionalidadenome ;
         }

         set {
            sdt.gxTpr_Nacionalidadenome = value;
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

      public SdtNacionalidade sdt
      {
         get {
            return (SdtNacionalidade)Sdt ;
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
            sdt = new SdtNacionalidade() ;
         }
      }

   }

}
