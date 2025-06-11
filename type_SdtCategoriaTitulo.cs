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
   [XmlRoot(ElementName = "CategoriaTitulo" )]
   [XmlType(TypeName =  "CategoriaTitulo" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtCategoriaTitulo : GxSilentTrnSdt
   {
      public SdtCategoriaTitulo( )
      {
      }

      public SdtCategoriaTitulo( IGxContext context )
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

      public void Load( int AV426CategoriaTituloId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV426CategoriaTituloId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"CategoriaTituloId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "CategoriaTitulo");
         metadata.Set("BT", "CategoriaTitulo");
         metadata.Set("PK", "[ \"CategoriaTituloId\" ]");
         metadata.Set("PKAssigned", "[ \"CategoriaTituloId\" ]");
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
         state.Add("gxTpr_Categoriatituloid_Z");
         state.Add("gxTpr_Categoriatitulonome_Z");
         state.Add("gxTpr_Categoriatitulodescricao_Z");
         state.Add("gxTpr_Categoriastatus_Z");
         state.Add("gxTpr_Categoriatituloid_N");
         state.Add("gxTpr_Categoriatitulonome_N");
         state.Add("gxTpr_Categoriatitulodescricao_N");
         state.Add("gxTpr_Categoriastatus_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtCategoriaTitulo sdt;
         sdt = (SdtCategoriaTitulo)(source);
         gxTv_SdtCategoriaTitulo_Categoriatituloid = sdt.gxTv_SdtCategoriaTitulo_Categoriatituloid ;
         gxTv_SdtCategoriaTitulo_Categoriatitulonome = sdt.gxTv_SdtCategoriaTitulo_Categoriatitulonome ;
         gxTv_SdtCategoriaTitulo_Categoriatitulodescricao = sdt.gxTv_SdtCategoriaTitulo_Categoriatitulodescricao ;
         gxTv_SdtCategoriaTitulo_Categoriastatus = sdt.gxTv_SdtCategoriaTitulo_Categoriastatus ;
         gxTv_SdtCategoriaTitulo_Mode = sdt.gxTv_SdtCategoriaTitulo_Mode ;
         gxTv_SdtCategoriaTitulo_Initialized = sdt.gxTv_SdtCategoriaTitulo_Initialized ;
         gxTv_SdtCategoriaTitulo_Categoriatituloid_Z = sdt.gxTv_SdtCategoriaTitulo_Categoriatituloid_Z ;
         gxTv_SdtCategoriaTitulo_Categoriatitulonome_Z = sdt.gxTv_SdtCategoriaTitulo_Categoriatitulonome_Z ;
         gxTv_SdtCategoriaTitulo_Categoriatitulodescricao_Z = sdt.gxTv_SdtCategoriaTitulo_Categoriatitulodescricao_Z ;
         gxTv_SdtCategoriaTitulo_Categoriastatus_Z = sdt.gxTv_SdtCategoriaTitulo_Categoriastatus_Z ;
         gxTv_SdtCategoriaTitulo_Categoriatituloid_N = sdt.gxTv_SdtCategoriaTitulo_Categoriatituloid_N ;
         gxTv_SdtCategoriaTitulo_Categoriatitulonome_N = sdt.gxTv_SdtCategoriaTitulo_Categoriatitulonome_N ;
         gxTv_SdtCategoriaTitulo_Categoriatitulodescricao_N = sdt.gxTv_SdtCategoriaTitulo_Categoriatitulodescricao_N ;
         gxTv_SdtCategoriaTitulo_Categoriastatus_N = sdt.gxTv_SdtCategoriaTitulo_Categoriastatus_N ;
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
         AddObjectProperty("CategoriaTituloId", gxTv_SdtCategoriaTitulo_Categoriatituloid, false, includeNonInitialized);
         AddObjectProperty("CategoriaTituloId_N", gxTv_SdtCategoriaTitulo_Categoriatituloid_N, false, includeNonInitialized);
         AddObjectProperty("CategoriaTituloNome", gxTv_SdtCategoriaTitulo_Categoriatitulonome, false, includeNonInitialized);
         AddObjectProperty("CategoriaTituloNome_N", gxTv_SdtCategoriaTitulo_Categoriatitulonome_N, false, includeNonInitialized);
         AddObjectProperty("CategoriaTituloDescricao", gxTv_SdtCategoriaTitulo_Categoriatitulodescricao, false, includeNonInitialized);
         AddObjectProperty("CategoriaTituloDescricao_N", gxTv_SdtCategoriaTitulo_Categoriatitulodescricao_N, false, includeNonInitialized);
         AddObjectProperty("CategoriaStatus", gxTv_SdtCategoriaTitulo_Categoriastatus, false, includeNonInitialized);
         AddObjectProperty("CategoriaStatus_N", gxTv_SdtCategoriaTitulo_Categoriastatus_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtCategoriaTitulo_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtCategoriaTitulo_Initialized, false, includeNonInitialized);
            AddObjectProperty("CategoriaTituloId_Z", gxTv_SdtCategoriaTitulo_Categoriatituloid_Z, false, includeNonInitialized);
            AddObjectProperty("CategoriaTituloNome_Z", gxTv_SdtCategoriaTitulo_Categoriatitulonome_Z, false, includeNonInitialized);
            AddObjectProperty("CategoriaTituloDescricao_Z", gxTv_SdtCategoriaTitulo_Categoriatitulodescricao_Z, false, includeNonInitialized);
            AddObjectProperty("CategoriaStatus_Z", gxTv_SdtCategoriaTitulo_Categoriastatus_Z, false, includeNonInitialized);
            AddObjectProperty("CategoriaTituloId_N", gxTv_SdtCategoriaTitulo_Categoriatituloid_N, false, includeNonInitialized);
            AddObjectProperty("CategoriaTituloNome_N", gxTv_SdtCategoriaTitulo_Categoriatitulonome_N, false, includeNonInitialized);
            AddObjectProperty("CategoriaTituloDescricao_N", gxTv_SdtCategoriaTitulo_Categoriatitulodescricao_N, false, includeNonInitialized);
            AddObjectProperty("CategoriaStatus_N", gxTv_SdtCategoriaTitulo_Categoriastatus_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtCategoriaTitulo sdt )
      {
         if ( sdt.IsDirty("CategoriaTituloId") )
         {
            sdtIsNull = 0;
            gxTv_SdtCategoriaTitulo_Categoriatituloid = sdt.gxTv_SdtCategoriaTitulo_Categoriatituloid ;
         }
         if ( sdt.IsDirty("CategoriaTituloNome") )
         {
            gxTv_SdtCategoriaTitulo_Categoriatitulonome_N = (short)(sdt.gxTv_SdtCategoriaTitulo_Categoriatitulonome_N);
            sdtIsNull = 0;
            gxTv_SdtCategoriaTitulo_Categoriatitulonome = sdt.gxTv_SdtCategoriaTitulo_Categoriatitulonome ;
         }
         if ( sdt.IsDirty("CategoriaTituloDescricao") )
         {
            gxTv_SdtCategoriaTitulo_Categoriatitulodescricao_N = (short)(sdt.gxTv_SdtCategoriaTitulo_Categoriatitulodescricao_N);
            sdtIsNull = 0;
            gxTv_SdtCategoriaTitulo_Categoriatitulodescricao = sdt.gxTv_SdtCategoriaTitulo_Categoriatitulodescricao ;
         }
         if ( sdt.IsDirty("CategoriaStatus") )
         {
            gxTv_SdtCategoriaTitulo_Categoriastatus_N = (short)(sdt.gxTv_SdtCategoriaTitulo_Categoriastatus_N);
            sdtIsNull = 0;
            gxTv_SdtCategoriaTitulo_Categoriastatus = sdt.gxTv_SdtCategoriaTitulo_Categoriastatus ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "CategoriaTituloId" )]
      [  XmlElement( ElementName = "CategoriaTituloId"   )]
      public int gxTpr_Categoriatituloid
      {
         get {
            return gxTv_SdtCategoriaTitulo_Categoriatituloid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtCategoriaTitulo_Categoriatituloid != value )
            {
               gxTv_SdtCategoriaTitulo_Mode = "INS";
               this.gxTv_SdtCategoriaTitulo_Categoriatituloid_Z_SetNull( );
               this.gxTv_SdtCategoriaTitulo_Categoriatitulonome_Z_SetNull( );
               this.gxTv_SdtCategoriaTitulo_Categoriatitulodescricao_Z_SetNull( );
               this.gxTv_SdtCategoriaTitulo_Categoriastatus_Z_SetNull( );
            }
            gxTv_SdtCategoriaTitulo_Categoriatituloid = value;
            SetDirty("Categoriatituloid");
         }

      }

      [  SoapElement( ElementName = "CategoriaTituloNome" )]
      [  XmlElement( ElementName = "CategoriaTituloNome"   )]
      public string gxTpr_Categoriatitulonome
      {
         get {
            return gxTv_SdtCategoriaTitulo_Categoriatitulonome ;
         }

         set {
            gxTv_SdtCategoriaTitulo_Categoriatitulonome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCategoriaTitulo_Categoriatitulonome = value;
            SetDirty("Categoriatitulonome");
         }

      }

      public void gxTv_SdtCategoriaTitulo_Categoriatitulonome_SetNull( )
      {
         gxTv_SdtCategoriaTitulo_Categoriatitulonome_N = 1;
         gxTv_SdtCategoriaTitulo_Categoriatitulonome = "";
         SetDirty("Categoriatitulonome");
         return  ;
      }

      public bool gxTv_SdtCategoriaTitulo_Categoriatitulonome_IsNull( )
      {
         return (gxTv_SdtCategoriaTitulo_Categoriatitulonome_N==1) ;
      }

      [  SoapElement( ElementName = "CategoriaTituloDescricao" )]
      [  XmlElement( ElementName = "CategoriaTituloDescricao"   )]
      public string gxTpr_Categoriatitulodescricao
      {
         get {
            return gxTv_SdtCategoriaTitulo_Categoriatitulodescricao ;
         }

         set {
            gxTv_SdtCategoriaTitulo_Categoriatitulodescricao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCategoriaTitulo_Categoriatitulodescricao = value;
            SetDirty("Categoriatitulodescricao");
         }

      }

      public void gxTv_SdtCategoriaTitulo_Categoriatitulodescricao_SetNull( )
      {
         gxTv_SdtCategoriaTitulo_Categoriatitulodescricao_N = 1;
         gxTv_SdtCategoriaTitulo_Categoriatitulodescricao = "";
         SetDirty("Categoriatitulodescricao");
         return  ;
      }

      public bool gxTv_SdtCategoriaTitulo_Categoriatitulodescricao_IsNull( )
      {
         return (gxTv_SdtCategoriaTitulo_Categoriatitulodescricao_N==1) ;
      }

      [  SoapElement( ElementName = "CategoriaStatus" )]
      [  XmlElement( ElementName = "CategoriaStatus"   )]
      public bool gxTpr_Categoriastatus
      {
         get {
            return gxTv_SdtCategoriaTitulo_Categoriastatus ;
         }

         set {
            gxTv_SdtCategoriaTitulo_Categoriastatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCategoriaTitulo_Categoriastatus = value;
            SetDirty("Categoriastatus");
         }

      }

      public void gxTv_SdtCategoriaTitulo_Categoriastatus_SetNull( )
      {
         gxTv_SdtCategoriaTitulo_Categoriastatus_N = 1;
         gxTv_SdtCategoriaTitulo_Categoriastatus = false;
         SetDirty("Categoriastatus");
         return  ;
      }

      public bool gxTv_SdtCategoriaTitulo_Categoriastatus_IsNull( )
      {
         return (gxTv_SdtCategoriaTitulo_Categoriastatus_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtCategoriaTitulo_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCategoriaTitulo_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtCategoriaTitulo_Mode_SetNull( )
      {
         gxTv_SdtCategoriaTitulo_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtCategoriaTitulo_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtCategoriaTitulo_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCategoriaTitulo_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtCategoriaTitulo_Initialized_SetNull( )
      {
         gxTv_SdtCategoriaTitulo_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtCategoriaTitulo_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoriaTituloId_Z" )]
      [  XmlElement( ElementName = "CategoriaTituloId_Z"   )]
      public int gxTpr_Categoriatituloid_Z
      {
         get {
            return gxTv_SdtCategoriaTitulo_Categoriatituloid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCategoriaTitulo_Categoriatituloid_Z = value;
            SetDirty("Categoriatituloid_Z");
         }

      }

      public void gxTv_SdtCategoriaTitulo_Categoriatituloid_Z_SetNull( )
      {
         gxTv_SdtCategoriaTitulo_Categoriatituloid_Z = 0;
         SetDirty("Categoriatituloid_Z");
         return  ;
      }

      public bool gxTv_SdtCategoriaTitulo_Categoriatituloid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoriaTituloNome_Z" )]
      [  XmlElement( ElementName = "CategoriaTituloNome_Z"   )]
      public string gxTpr_Categoriatitulonome_Z
      {
         get {
            return gxTv_SdtCategoriaTitulo_Categoriatitulonome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCategoriaTitulo_Categoriatitulonome_Z = value;
            SetDirty("Categoriatitulonome_Z");
         }

      }

      public void gxTv_SdtCategoriaTitulo_Categoriatitulonome_Z_SetNull( )
      {
         gxTv_SdtCategoriaTitulo_Categoriatitulonome_Z = "";
         SetDirty("Categoriatitulonome_Z");
         return  ;
      }

      public bool gxTv_SdtCategoriaTitulo_Categoriatitulonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoriaTituloDescricao_Z" )]
      [  XmlElement( ElementName = "CategoriaTituloDescricao_Z"   )]
      public string gxTpr_Categoriatitulodescricao_Z
      {
         get {
            return gxTv_SdtCategoriaTitulo_Categoriatitulodescricao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCategoriaTitulo_Categoriatitulodescricao_Z = value;
            SetDirty("Categoriatitulodescricao_Z");
         }

      }

      public void gxTv_SdtCategoriaTitulo_Categoriatitulodescricao_Z_SetNull( )
      {
         gxTv_SdtCategoriaTitulo_Categoriatitulodescricao_Z = "";
         SetDirty("Categoriatitulodescricao_Z");
         return  ;
      }

      public bool gxTv_SdtCategoriaTitulo_Categoriatitulodescricao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoriaStatus_Z" )]
      [  XmlElement( ElementName = "CategoriaStatus_Z"   )]
      public bool gxTpr_Categoriastatus_Z
      {
         get {
            return gxTv_SdtCategoriaTitulo_Categoriastatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCategoriaTitulo_Categoriastatus_Z = value;
            SetDirty("Categoriastatus_Z");
         }

      }

      public void gxTv_SdtCategoriaTitulo_Categoriastatus_Z_SetNull( )
      {
         gxTv_SdtCategoriaTitulo_Categoriastatus_Z = false;
         SetDirty("Categoriastatus_Z");
         return  ;
      }

      public bool gxTv_SdtCategoriaTitulo_Categoriastatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoriaTituloId_N" )]
      [  XmlElement( ElementName = "CategoriaTituloId_N"   )]
      public short gxTpr_Categoriatituloid_N
      {
         get {
            return gxTv_SdtCategoriaTitulo_Categoriatituloid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCategoriaTitulo_Categoriatituloid_N = value;
            SetDirty("Categoriatituloid_N");
         }

      }

      public void gxTv_SdtCategoriaTitulo_Categoriatituloid_N_SetNull( )
      {
         gxTv_SdtCategoriaTitulo_Categoriatituloid_N = 0;
         SetDirty("Categoriatituloid_N");
         return  ;
      }

      public bool gxTv_SdtCategoriaTitulo_Categoriatituloid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoriaTituloNome_N" )]
      [  XmlElement( ElementName = "CategoriaTituloNome_N"   )]
      public short gxTpr_Categoriatitulonome_N
      {
         get {
            return gxTv_SdtCategoriaTitulo_Categoriatitulonome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCategoriaTitulo_Categoriatitulonome_N = value;
            SetDirty("Categoriatitulonome_N");
         }

      }

      public void gxTv_SdtCategoriaTitulo_Categoriatitulonome_N_SetNull( )
      {
         gxTv_SdtCategoriaTitulo_Categoriatitulonome_N = 0;
         SetDirty("Categoriatitulonome_N");
         return  ;
      }

      public bool gxTv_SdtCategoriaTitulo_Categoriatitulonome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoriaTituloDescricao_N" )]
      [  XmlElement( ElementName = "CategoriaTituloDescricao_N"   )]
      public short gxTpr_Categoriatitulodescricao_N
      {
         get {
            return gxTv_SdtCategoriaTitulo_Categoriatitulodescricao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCategoriaTitulo_Categoriatitulodescricao_N = value;
            SetDirty("Categoriatitulodescricao_N");
         }

      }

      public void gxTv_SdtCategoriaTitulo_Categoriatitulodescricao_N_SetNull( )
      {
         gxTv_SdtCategoriaTitulo_Categoriatitulodescricao_N = 0;
         SetDirty("Categoriatitulodescricao_N");
         return  ;
      }

      public bool gxTv_SdtCategoriaTitulo_Categoriatitulodescricao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoriaStatus_N" )]
      [  XmlElement( ElementName = "CategoriaStatus_N"   )]
      public short gxTpr_Categoriastatus_N
      {
         get {
            return gxTv_SdtCategoriaTitulo_Categoriastatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCategoriaTitulo_Categoriastatus_N = value;
            SetDirty("Categoriastatus_N");
         }

      }

      public void gxTv_SdtCategoriaTitulo_Categoriastatus_N_SetNull( )
      {
         gxTv_SdtCategoriaTitulo_Categoriastatus_N = 0;
         SetDirty("Categoriastatus_N");
         return  ;
      }

      public bool gxTv_SdtCategoriaTitulo_Categoriastatus_N_IsNull( )
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
         gxTv_SdtCategoriaTitulo_Categoriatitulonome = "";
         gxTv_SdtCategoriaTitulo_Categoriatitulodescricao = "";
         gxTv_SdtCategoriaTitulo_Mode = "";
         gxTv_SdtCategoriaTitulo_Categoriatitulonome_Z = "";
         gxTv_SdtCategoriaTitulo_Categoriatitulodescricao_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "categoriatitulo", "GeneXus.Programs.categoriatitulo_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtCategoriaTitulo_Initialized ;
      private short gxTv_SdtCategoriaTitulo_Categoriatituloid_N ;
      private short gxTv_SdtCategoriaTitulo_Categoriatitulonome_N ;
      private short gxTv_SdtCategoriaTitulo_Categoriatitulodescricao_N ;
      private short gxTv_SdtCategoriaTitulo_Categoriastatus_N ;
      private int gxTv_SdtCategoriaTitulo_Categoriatituloid ;
      private int gxTv_SdtCategoriaTitulo_Categoriatituloid_Z ;
      private string gxTv_SdtCategoriaTitulo_Mode ;
      private bool gxTv_SdtCategoriaTitulo_Categoriastatus ;
      private bool gxTv_SdtCategoriaTitulo_Categoriastatus_Z ;
      private string gxTv_SdtCategoriaTitulo_Categoriatitulonome ;
      private string gxTv_SdtCategoriaTitulo_Categoriatitulodescricao ;
      private string gxTv_SdtCategoriaTitulo_Categoriatitulonome_Z ;
      private string gxTv_SdtCategoriaTitulo_Categoriatitulodescricao_Z ;
   }

   [DataContract(Name = @"CategoriaTitulo", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtCategoriaTitulo_RESTInterface : GxGenericCollectionItem<SdtCategoriaTitulo>
   {
      public SdtCategoriaTitulo_RESTInterface( ) : base()
      {
      }

      public SdtCategoriaTitulo_RESTInterface( SdtCategoriaTitulo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CategoriaTituloId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Categoriatituloid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Categoriatituloid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Categoriatituloid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "CategoriaTituloNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Categoriatitulonome
      {
         get {
            return sdt.gxTpr_Categoriatitulonome ;
         }

         set {
            sdt.gxTpr_Categoriatitulonome = value;
         }

      }

      [DataMember( Name = "CategoriaTituloDescricao" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Categoriatitulodescricao
      {
         get {
            return sdt.gxTpr_Categoriatitulodescricao ;
         }

         set {
            sdt.gxTpr_Categoriatitulodescricao = value;
         }

      }

      [DataMember( Name = "CategoriaStatus" , Order = 3 )]
      [GxSeudo()]
      public bool gxTpr_Categoriastatus
      {
         get {
            return sdt.gxTpr_Categoriastatus ;
         }

         set {
            sdt.gxTpr_Categoriastatus = value;
         }

      }

      public SdtCategoriaTitulo sdt
      {
         get {
            return (SdtCategoriaTitulo)Sdt ;
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
            sdt = new SdtCategoriaTitulo() ;
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

   [DataContract(Name = @"CategoriaTitulo", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtCategoriaTitulo_RESTLInterface : GxGenericCollectionItem<SdtCategoriaTitulo>
   {
      public SdtCategoriaTitulo_RESTLInterface( ) : base()
      {
      }

      public SdtCategoriaTitulo_RESTLInterface( SdtCategoriaTitulo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CategoriaTituloNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Categoriatitulonome
      {
         get {
            return sdt.gxTpr_Categoriatitulonome ;
         }

         set {
            sdt.gxTpr_Categoriatitulonome = value;
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

      public SdtCategoriaTitulo sdt
      {
         get {
            return (SdtCategoriaTitulo)Sdt ;
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
            sdt = new SdtCategoriaTitulo() ;
         }
      }

   }

}
