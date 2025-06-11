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
   [XmlRoot(ElementName = "Municipio" )]
   [XmlType(TypeName =  "Municipio" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtMunicipio : GxSilentTrnSdt
   {
      public SdtMunicipio( )
      {
      }

      public SdtMunicipio( IGxContext context )
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

      public void Load( string AV186MunicipioCodigo )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(string)AV186MunicipioCodigo});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"MunicipioCodigo", typeof(string)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Municipio");
         metadata.Set("BT", "Municipio");
         metadata.Set("PK", "[ \"MunicipioCodigo\" ]");
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
         state.Add("gxTpr_Municipiocodigo_Z");
         state.Add("gxTpr_Municipionome_Z");
         state.Add("gxTpr_Municipioddd_Z");
         state.Add("gxTpr_Municipiouf_Z");
         state.Add("gxTpr_Municipiocodigo_N");
         state.Add("gxTpr_Municipionome_N");
         state.Add("gxTpr_Municipioddd_N");
         state.Add("gxTpr_Municipiouf_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtMunicipio sdt;
         sdt = (SdtMunicipio)(source);
         gxTv_SdtMunicipio_Municipiocodigo = sdt.gxTv_SdtMunicipio_Municipiocodigo ;
         gxTv_SdtMunicipio_Municipionome = sdt.gxTv_SdtMunicipio_Municipionome ;
         gxTv_SdtMunicipio_Municipioddd = sdt.gxTv_SdtMunicipio_Municipioddd ;
         gxTv_SdtMunicipio_Municipiouf = sdt.gxTv_SdtMunicipio_Municipiouf ;
         gxTv_SdtMunicipio_Mode = sdt.gxTv_SdtMunicipio_Mode ;
         gxTv_SdtMunicipio_Initialized = sdt.gxTv_SdtMunicipio_Initialized ;
         gxTv_SdtMunicipio_Municipiocodigo_Z = sdt.gxTv_SdtMunicipio_Municipiocodigo_Z ;
         gxTv_SdtMunicipio_Municipionome_Z = sdt.gxTv_SdtMunicipio_Municipionome_Z ;
         gxTv_SdtMunicipio_Municipioddd_Z = sdt.gxTv_SdtMunicipio_Municipioddd_Z ;
         gxTv_SdtMunicipio_Municipiouf_Z = sdt.gxTv_SdtMunicipio_Municipiouf_Z ;
         gxTv_SdtMunicipio_Municipiocodigo_N = sdt.gxTv_SdtMunicipio_Municipiocodigo_N ;
         gxTv_SdtMunicipio_Municipionome_N = sdt.gxTv_SdtMunicipio_Municipionome_N ;
         gxTv_SdtMunicipio_Municipioddd_N = sdt.gxTv_SdtMunicipio_Municipioddd_N ;
         gxTv_SdtMunicipio_Municipiouf_N = sdt.gxTv_SdtMunicipio_Municipiouf_N ;
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
         AddObjectProperty("MunicipioCodigo", gxTv_SdtMunicipio_Municipiocodigo, false, includeNonInitialized);
         AddObjectProperty("MunicipioCodigo_N", gxTv_SdtMunicipio_Municipiocodigo_N, false, includeNonInitialized);
         AddObjectProperty("MunicipioNome", gxTv_SdtMunicipio_Municipionome, false, includeNonInitialized);
         AddObjectProperty("MunicipioNome_N", gxTv_SdtMunicipio_Municipionome_N, false, includeNonInitialized);
         AddObjectProperty("MunicipioDDD", gxTv_SdtMunicipio_Municipioddd, false, includeNonInitialized);
         AddObjectProperty("MunicipioDDD_N", gxTv_SdtMunicipio_Municipioddd_N, false, includeNonInitialized);
         AddObjectProperty("MunicipioUF", gxTv_SdtMunicipio_Municipiouf, false, includeNonInitialized);
         AddObjectProperty("MunicipioUF_N", gxTv_SdtMunicipio_Municipiouf_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtMunicipio_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtMunicipio_Initialized, false, includeNonInitialized);
            AddObjectProperty("MunicipioCodigo_Z", gxTv_SdtMunicipio_Municipiocodigo_Z, false, includeNonInitialized);
            AddObjectProperty("MunicipioNome_Z", gxTv_SdtMunicipio_Municipionome_Z, false, includeNonInitialized);
            AddObjectProperty("MunicipioDDD_Z", gxTv_SdtMunicipio_Municipioddd_Z, false, includeNonInitialized);
            AddObjectProperty("MunicipioUF_Z", gxTv_SdtMunicipio_Municipiouf_Z, false, includeNonInitialized);
            AddObjectProperty("MunicipioCodigo_N", gxTv_SdtMunicipio_Municipiocodigo_N, false, includeNonInitialized);
            AddObjectProperty("MunicipioNome_N", gxTv_SdtMunicipio_Municipionome_N, false, includeNonInitialized);
            AddObjectProperty("MunicipioDDD_N", gxTv_SdtMunicipio_Municipioddd_N, false, includeNonInitialized);
            AddObjectProperty("MunicipioUF_N", gxTv_SdtMunicipio_Municipiouf_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtMunicipio sdt )
      {
         if ( sdt.IsDirty("MunicipioCodigo") )
         {
            sdtIsNull = 0;
            gxTv_SdtMunicipio_Municipiocodigo = sdt.gxTv_SdtMunicipio_Municipiocodigo ;
         }
         if ( sdt.IsDirty("MunicipioNome") )
         {
            gxTv_SdtMunicipio_Municipionome_N = (short)(sdt.gxTv_SdtMunicipio_Municipionome_N);
            sdtIsNull = 0;
            gxTv_SdtMunicipio_Municipionome = sdt.gxTv_SdtMunicipio_Municipionome ;
         }
         if ( sdt.IsDirty("MunicipioDDD") )
         {
            gxTv_SdtMunicipio_Municipioddd_N = (short)(sdt.gxTv_SdtMunicipio_Municipioddd_N);
            sdtIsNull = 0;
            gxTv_SdtMunicipio_Municipioddd = sdt.gxTv_SdtMunicipio_Municipioddd ;
         }
         if ( sdt.IsDirty("MunicipioUF") )
         {
            gxTv_SdtMunicipio_Municipiouf_N = (short)(sdt.gxTv_SdtMunicipio_Municipiouf_N);
            sdtIsNull = 0;
            gxTv_SdtMunicipio_Municipiouf = sdt.gxTv_SdtMunicipio_Municipiouf ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "MunicipioCodigo" )]
      [  XmlElement( ElementName = "MunicipioCodigo"   )]
      public string gxTpr_Municipiocodigo
      {
         get {
            return gxTv_SdtMunicipio_Municipiocodigo ;
         }

         set {
            sdtIsNull = 0;
            if ( StringUtil.StrCmp(gxTv_SdtMunicipio_Municipiocodigo, value) != 0 )
            {
               gxTv_SdtMunicipio_Mode = "INS";
               this.gxTv_SdtMunicipio_Municipiocodigo_Z_SetNull( );
               this.gxTv_SdtMunicipio_Municipionome_Z_SetNull( );
               this.gxTv_SdtMunicipio_Municipioddd_Z_SetNull( );
               this.gxTv_SdtMunicipio_Municipiouf_Z_SetNull( );
            }
            gxTv_SdtMunicipio_Municipiocodigo = value;
            SetDirty("Municipiocodigo");
         }

      }

      [  SoapElement( ElementName = "MunicipioNome" )]
      [  XmlElement( ElementName = "MunicipioNome"   )]
      public string gxTpr_Municipionome
      {
         get {
            return gxTv_SdtMunicipio_Municipionome ;
         }

         set {
            gxTv_SdtMunicipio_Municipionome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtMunicipio_Municipionome = value;
            SetDirty("Municipionome");
         }

      }

      public void gxTv_SdtMunicipio_Municipionome_SetNull( )
      {
         gxTv_SdtMunicipio_Municipionome_N = 1;
         gxTv_SdtMunicipio_Municipionome = "";
         SetDirty("Municipionome");
         return  ;
      }

      public bool gxTv_SdtMunicipio_Municipionome_IsNull( )
      {
         return (gxTv_SdtMunicipio_Municipionome_N==1) ;
      }

      [  SoapElement( ElementName = "MunicipioDDD" )]
      [  XmlElement( ElementName = "MunicipioDDD"   )]
      public string gxTpr_Municipioddd
      {
         get {
            return gxTv_SdtMunicipio_Municipioddd ;
         }

         set {
            gxTv_SdtMunicipio_Municipioddd_N = 0;
            sdtIsNull = 0;
            gxTv_SdtMunicipio_Municipioddd = value;
            SetDirty("Municipioddd");
         }

      }

      public void gxTv_SdtMunicipio_Municipioddd_SetNull( )
      {
         gxTv_SdtMunicipio_Municipioddd_N = 1;
         gxTv_SdtMunicipio_Municipioddd = "";
         SetDirty("Municipioddd");
         return  ;
      }

      public bool gxTv_SdtMunicipio_Municipioddd_IsNull( )
      {
         return (gxTv_SdtMunicipio_Municipioddd_N==1) ;
      }

      [  SoapElement( ElementName = "MunicipioUF" )]
      [  XmlElement( ElementName = "MunicipioUF"   )]
      public string gxTpr_Municipiouf
      {
         get {
            return gxTv_SdtMunicipio_Municipiouf ;
         }

         set {
            gxTv_SdtMunicipio_Municipiouf_N = 0;
            sdtIsNull = 0;
            gxTv_SdtMunicipio_Municipiouf = value;
            SetDirty("Municipiouf");
         }

      }

      public void gxTv_SdtMunicipio_Municipiouf_SetNull( )
      {
         gxTv_SdtMunicipio_Municipiouf_N = 1;
         gxTv_SdtMunicipio_Municipiouf = "";
         SetDirty("Municipiouf");
         return  ;
      }

      public bool gxTv_SdtMunicipio_Municipiouf_IsNull( )
      {
         return (gxTv_SdtMunicipio_Municipiouf_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtMunicipio_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMunicipio_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtMunicipio_Mode_SetNull( )
      {
         gxTv_SdtMunicipio_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtMunicipio_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtMunicipio_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMunicipio_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtMunicipio_Initialized_SetNull( )
      {
         gxTv_SdtMunicipio_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtMunicipio_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioCodigo_Z" )]
      [  XmlElement( ElementName = "MunicipioCodigo_Z"   )]
      public string gxTpr_Municipiocodigo_Z
      {
         get {
            return gxTv_SdtMunicipio_Municipiocodigo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMunicipio_Municipiocodigo_Z = value;
            SetDirty("Municipiocodigo_Z");
         }

      }

      public void gxTv_SdtMunicipio_Municipiocodigo_Z_SetNull( )
      {
         gxTv_SdtMunicipio_Municipiocodigo_Z = "";
         SetDirty("Municipiocodigo_Z");
         return  ;
      }

      public bool gxTv_SdtMunicipio_Municipiocodigo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioNome_Z" )]
      [  XmlElement( ElementName = "MunicipioNome_Z"   )]
      public string gxTpr_Municipionome_Z
      {
         get {
            return gxTv_SdtMunicipio_Municipionome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMunicipio_Municipionome_Z = value;
            SetDirty("Municipionome_Z");
         }

      }

      public void gxTv_SdtMunicipio_Municipionome_Z_SetNull( )
      {
         gxTv_SdtMunicipio_Municipionome_Z = "";
         SetDirty("Municipionome_Z");
         return  ;
      }

      public bool gxTv_SdtMunicipio_Municipionome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioDDD_Z" )]
      [  XmlElement( ElementName = "MunicipioDDD_Z"   )]
      public string gxTpr_Municipioddd_Z
      {
         get {
            return gxTv_SdtMunicipio_Municipioddd_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMunicipio_Municipioddd_Z = value;
            SetDirty("Municipioddd_Z");
         }

      }

      public void gxTv_SdtMunicipio_Municipioddd_Z_SetNull( )
      {
         gxTv_SdtMunicipio_Municipioddd_Z = "";
         SetDirty("Municipioddd_Z");
         return  ;
      }

      public bool gxTv_SdtMunicipio_Municipioddd_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioUF_Z" )]
      [  XmlElement( ElementName = "MunicipioUF_Z"   )]
      public string gxTpr_Municipiouf_Z
      {
         get {
            return gxTv_SdtMunicipio_Municipiouf_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMunicipio_Municipiouf_Z = value;
            SetDirty("Municipiouf_Z");
         }

      }

      public void gxTv_SdtMunicipio_Municipiouf_Z_SetNull( )
      {
         gxTv_SdtMunicipio_Municipiouf_Z = "";
         SetDirty("Municipiouf_Z");
         return  ;
      }

      public bool gxTv_SdtMunicipio_Municipiouf_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioCodigo_N" )]
      [  XmlElement( ElementName = "MunicipioCodigo_N"   )]
      public short gxTpr_Municipiocodigo_N
      {
         get {
            return gxTv_SdtMunicipio_Municipiocodigo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMunicipio_Municipiocodigo_N = value;
            SetDirty("Municipiocodigo_N");
         }

      }

      public void gxTv_SdtMunicipio_Municipiocodigo_N_SetNull( )
      {
         gxTv_SdtMunicipio_Municipiocodigo_N = 0;
         SetDirty("Municipiocodigo_N");
         return  ;
      }

      public bool gxTv_SdtMunicipio_Municipiocodigo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioNome_N" )]
      [  XmlElement( ElementName = "MunicipioNome_N"   )]
      public short gxTpr_Municipionome_N
      {
         get {
            return gxTv_SdtMunicipio_Municipionome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMunicipio_Municipionome_N = value;
            SetDirty("Municipionome_N");
         }

      }

      public void gxTv_SdtMunicipio_Municipionome_N_SetNull( )
      {
         gxTv_SdtMunicipio_Municipionome_N = 0;
         SetDirty("Municipionome_N");
         return  ;
      }

      public bool gxTv_SdtMunicipio_Municipionome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioDDD_N" )]
      [  XmlElement( ElementName = "MunicipioDDD_N"   )]
      public short gxTpr_Municipioddd_N
      {
         get {
            return gxTv_SdtMunicipio_Municipioddd_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMunicipio_Municipioddd_N = value;
            SetDirty("Municipioddd_N");
         }

      }

      public void gxTv_SdtMunicipio_Municipioddd_N_SetNull( )
      {
         gxTv_SdtMunicipio_Municipioddd_N = 0;
         SetDirty("Municipioddd_N");
         return  ;
      }

      public bool gxTv_SdtMunicipio_Municipioddd_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MunicipioUF_N" )]
      [  XmlElement( ElementName = "MunicipioUF_N"   )]
      public short gxTpr_Municipiouf_N
      {
         get {
            return gxTv_SdtMunicipio_Municipiouf_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMunicipio_Municipiouf_N = value;
            SetDirty("Municipiouf_N");
         }

      }

      public void gxTv_SdtMunicipio_Municipiouf_N_SetNull( )
      {
         gxTv_SdtMunicipio_Municipiouf_N = 0;
         SetDirty("Municipiouf_N");
         return  ;
      }

      public bool gxTv_SdtMunicipio_Municipiouf_N_IsNull( )
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
         gxTv_SdtMunicipio_Municipiocodigo = "";
         sdtIsNull = 1;
         gxTv_SdtMunicipio_Municipionome = "";
         gxTv_SdtMunicipio_Municipioddd = "";
         gxTv_SdtMunicipio_Municipiouf = "";
         gxTv_SdtMunicipio_Mode = "";
         gxTv_SdtMunicipio_Municipiocodigo_Z = "";
         gxTv_SdtMunicipio_Municipionome_Z = "";
         gxTv_SdtMunicipio_Municipioddd_Z = "";
         gxTv_SdtMunicipio_Municipiouf_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "municipio", "GeneXus.Programs.municipio_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtMunicipio_Initialized ;
      private short gxTv_SdtMunicipio_Municipiocodigo_N ;
      private short gxTv_SdtMunicipio_Municipionome_N ;
      private short gxTv_SdtMunicipio_Municipioddd_N ;
      private short gxTv_SdtMunicipio_Municipiouf_N ;
      private string gxTv_SdtMunicipio_Mode ;
      private string gxTv_SdtMunicipio_Municipiocodigo ;
      private string gxTv_SdtMunicipio_Municipionome ;
      private string gxTv_SdtMunicipio_Municipioddd ;
      private string gxTv_SdtMunicipio_Municipiouf ;
      private string gxTv_SdtMunicipio_Municipiocodigo_Z ;
      private string gxTv_SdtMunicipio_Municipionome_Z ;
      private string gxTv_SdtMunicipio_Municipioddd_Z ;
      private string gxTv_SdtMunicipio_Municipiouf_Z ;
   }

   [DataContract(Name = @"Municipio", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtMunicipio_RESTInterface : GxGenericCollectionItem<SdtMunicipio>
   {
      public SdtMunicipio_RESTInterface( ) : base()
      {
      }

      public SdtMunicipio_RESTInterface( SdtMunicipio psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "MunicipioCodigo" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Municipiocodigo
      {
         get {
            return sdt.gxTpr_Municipiocodigo ;
         }

         set {
            sdt.gxTpr_Municipiocodigo = value;
         }

      }

      [DataMember( Name = "MunicipioNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Municipionome
      {
         get {
            return sdt.gxTpr_Municipionome ;
         }

         set {
            sdt.gxTpr_Municipionome = value;
         }

      }

      [DataMember( Name = "MunicipioDDD" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Municipioddd
      {
         get {
            return sdt.gxTpr_Municipioddd ;
         }

         set {
            sdt.gxTpr_Municipioddd = value;
         }

      }

      [DataMember( Name = "MunicipioUF" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Municipiouf
      {
         get {
            return sdt.gxTpr_Municipiouf ;
         }

         set {
            sdt.gxTpr_Municipiouf = value;
         }

      }

      public SdtMunicipio sdt
      {
         get {
            return (SdtMunicipio)Sdt ;
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
            sdt = new SdtMunicipio() ;
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

   [DataContract(Name = @"Municipio", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtMunicipio_RESTLInterface : GxGenericCollectionItem<SdtMunicipio>
   {
      public SdtMunicipio_RESTLInterface( ) : base()
      {
      }

      public SdtMunicipio_RESTLInterface( SdtMunicipio psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "MunicipioNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Municipionome
      {
         get {
            return sdt.gxTpr_Municipionome ;
         }

         set {
            sdt.gxTpr_Municipionome = value;
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

      public SdtMunicipio sdt
      {
         get {
            return (SdtMunicipio)Sdt ;
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
            sdt = new SdtMunicipio() ;
         }
      }

   }

}
