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
   [XmlRoot(ElementName = "ConvenioCategoria" )]
   [XmlType(TypeName =  "ConvenioCategoria" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtConvenioCategoria : GxSilentTrnSdt
   {
      public SdtConvenioCategoria( )
      {
      }

      public SdtConvenioCategoria( IGxContext context )
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

      public void Load( int AV493ConvenioCategoriaId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV493ConvenioCategoriaId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ConvenioCategoriaId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "ConvenioCategoria");
         metadata.Set("BT", "ConvenioCategoria");
         metadata.Set("PK", "[ \"ConvenioCategoriaId\" ]");
         metadata.Set("PKAssigned", "[ \"ConvenioCategoriaId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ConvenioId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Conveniocategoriaid_Z");
         state.Add("gxTpr_Convenioid_Z");
         state.Add("gxTpr_Conveniocategoriadescricao_Z");
         state.Add("gxTpr_Conveniocategoriastatus_Z");
         state.Add("gxTpr_Conveniocategoriaid_N");
         state.Add("gxTpr_Convenioid_N");
         state.Add("gxTpr_Conveniocategoriadescricao_N");
         state.Add("gxTpr_Conveniocategoriastatus_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtConvenioCategoria sdt;
         sdt = (SdtConvenioCategoria)(source);
         gxTv_SdtConvenioCategoria_Conveniocategoriaid = sdt.gxTv_SdtConvenioCategoria_Conveniocategoriaid ;
         gxTv_SdtConvenioCategoria_Convenioid = sdt.gxTv_SdtConvenioCategoria_Convenioid ;
         gxTv_SdtConvenioCategoria_Conveniocategoriadescricao = sdt.gxTv_SdtConvenioCategoria_Conveniocategoriadescricao ;
         gxTv_SdtConvenioCategoria_Conveniocategoriastatus = sdt.gxTv_SdtConvenioCategoria_Conveniocategoriastatus ;
         gxTv_SdtConvenioCategoria_Mode = sdt.gxTv_SdtConvenioCategoria_Mode ;
         gxTv_SdtConvenioCategoria_Initialized = sdt.gxTv_SdtConvenioCategoria_Initialized ;
         gxTv_SdtConvenioCategoria_Conveniocategoriaid_Z = sdt.gxTv_SdtConvenioCategoria_Conveniocategoriaid_Z ;
         gxTv_SdtConvenioCategoria_Convenioid_Z = sdt.gxTv_SdtConvenioCategoria_Convenioid_Z ;
         gxTv_SdtConvenioCategoria_Conveniocategoriadescricao_Z = sdt.gxTv_SdtConvenioCategoria_Conveniocategoriadescricao_Z ;
         gxTv_SdtConvenioCategoria_Conveniocategoriastatus_Z = sdt.gxTv_SdtConvenioCategoria_Conveniocategoriastatus_Z ;
         gxTv_SdtConvenioCategoria_Conveniocategoriaid_N = sdt.gxTv_SdtConvenioCategoria_Conveniocategoriaid_N ;
         gxTv_SdtConvenioCategoria_Convenioid_N = sdt.gxTv_SdtConvenioCategoria_Convenioid_N ;
         gxTv_SdtConvenioCategoria_Conveniocategoriadescricao_N = sdt.gxTv_SdtConvenioCategoria_Conveniocategoriadescricao_N ;
         gxTv_SdtConvenioCategoria_Conveniocategoriastatus_N = sdt.gxTv_SdtConvenioCategoria_Conveniocategoriastatus_N ;
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
         AddObjectProperty("ConvenioCategoriaId", gxTv_SdtConvenioCategoria_Conveniocategoriaid, false, includeNonInitialized);
         AddObjectProperty("ConvenioCategoriaId_N", gxTv_SdtConvenioCategoria_Conveniocategoriaid_N, false, includeNonInitialized);
         AddObjectProperty("ConvenioId", gxTv_SdtConvenioCategoria_Convenioid, false, includeNonInitialized);
         AddObjectProperty("ConvenioId_N", gxTv_SdtConvenioCategoria_Convenioid_N, false, includeNonInitialized);
         AddObjectProperty("ConvenioCategoriaDescricao", gxTv_SdtConvenioCategoria_Conveniocategoriadescricao, false, includeNonInitialized);
         AddObjectProperty("ConvenioCategoriaDescricao_N", gxTv_SdtConvenioCategoria_Conveniocategoriadescricao_N, false, includeNonInitialized);
         AddObjectProperty("ConvenioCategoriaStatus", gxTv_SdtConvenioCategoria_Conveniocategoriastatus, false, includeNonInitialized);
         AddObjectProperty("ConvenioCategoriaStatus_N", gxTv_SdtConvenioCategoria_Conveniocategoriastatus_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtConvenioCategoria_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtConvenioCategoria_Initialized, false, includeNonInitialized);
            AddObjectProperty("ConvenioCategoriaId_Z", gxTv_SdtConvenioCategoria_Conveniocategoriaid_Z, false, includeNonInitialized);
            AddObjectProperty("ConvenioId_Z", gxTv_SdtConvenioCategoria_Convenioid_Z, false, includeNonInitialized);
            AddObjectProperty("ConvenioCategoriaDescricao_Z", gxTv_SdtConvenioCategoria_Conveniocategoriadescricao_Z, false, includeNonInitialized);
            AddObjectProperty("ConvenioCategoriaStatus_Z", gxTv_SdtConvenioCategoria_Conveniocategoriastatus_Z, false, includeNonInitialized);
            AddObjectProperty("ConvenioCategoriaId_N", gxTv_SdtConvenioCategoria_Conveniocategoriaid_N, false, includeNonInitialized);
            AddObjectProperty("ConvenioId_N", gxTv_SdtConvenioCategoria_Convenioid_N, false, includeNonInitialized);
            AddObjectProperty("ConvenioCategoriaDescricao_N", gxTv_SdtConvenioCategoria_Conveniocategoriadescricao_N, false, includeNonInitialized);
            AddObjectProperty("ConvenioCategoriaStatus_N", gxTv_SdtConvenioCategoria_Conveniocategoriastatus_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtConvenioCategoria sdt )
      {
         if ( sdt.IsDirty("ConvenioCategoriaId") )
         {
            sdtIsNull = 0;
            gxTv_SdtConvenioCategoria_Conveniocategoriaid = sdt.gxTv_SdtConvenioCategoria_Conveniocategoriaid ;
         }
         if ( sdt.IsDirty("ConvenioId") )
         {
            gxTv_SdtConvenioCategoria_Convenioid_N = (short)(sdt.gxTv_SdtConvenioCategoria_Convenioid_N);
            sdtIsNull = 0;
            gxTv_SdtConvenioCategoria_Convenioid = sdt.gxTv_SdtConvenioCategoria_Convenioid ;
         }
         if ( sdt.IsDirty("ConvenioCategoriaDescricao") )
         {
            gxTv_SdtConvenioCategoria_Conveniocategoriadescricao_N = (short)(sdt.gxTv_SdtConvenioCategoria_Conveniocategoriadescricao_N);
            sdtIsNull = 0;
            gxTv_SdtConvenioCategoria_Conveniocategoriadescricao = sdt.gxTv_SdtConvenioCategoria_Conveniocategoriadescricao ;
         }
         if ( sdt.IsDirty("ConvenioCategoriaStatus") )
         {
            gxTv_SdtConvenioCategoria_Conveniocategoriastatus_N = (short)(sdt.gxTv_SdtConvenioCategoria_Conveniocategoriastatus_N);
            sdtIsNull = 0;
            gxTv_SdtConvenioCategoria_Conveniocategoriastatus = sdt.gxTv_SdtConvenioCategoria_Conveniocategoriastatus ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ConvenioCategoriaId" )]
      [  XmlElement( ElementName = "ConvenioCategoriaId"   )]
      public int gxTpr_Conveniocategoriaid
      {
         get {
            return gxTv_SdtConvenioCategoria_Conveniocategoriaid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtConvenioCategoria_Conveniocategoriaid != value )
            {
               gxTv_SdtConvenioCategoria_Mode = "INS";
               this.gxTv_SdtConvenioCategoria_Conveniocategoriaid_Z_SetNull( );
               this.gxTv_SdtConvenioCategoria_Convenioid_Z_SetNull( );
               this.gxTv_SdtConvenioCategoria_Conveniocategoriadescricao_Z_SetNull( );
               this.gxTv_SdtConvenioCategoria_Conveniocategoriastatus_Z_SetNull( );
            }
            gxTv_SdtConvenioCategoria_Conveniocategoriaid = value;
            SetDirty("Conveniocategoriaid");
         }

      }

      [  SoapElement( ElementName = "ConvenioId" )]
      [  XmlElement( ElementName = "ConvenioId"   )]
      public int gxTpr_Convenioid
      {
         get {
            return gxTv_SdtConvenioCategoria_Convenioid ;
         }

         set {
            gxTv_SdtConvenioCategoria_Convenioid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConvenioCategoria_Convenioid = value;
            SetDirty("Convenioid");
         }

      }

      public void gxTv_SdtConvenioCategoria_Convenioid_SetNull( )
      {
         gxTv_SdtConvenioCategoria_Convenioid_N = 1;
         gxTv_SdtConvenioCategoria_Convenioid = 0;
         SetDirty("Convenioid");
         return  ;
      }

      public bool gxTv_SdtConvenioCategoria_Convenioid_IsNull( )
      {
         return (gxTv_SdtConvenioCategoria_Convenioid_N==1) ;
      }

      [  SoapElement( ElementName = "ConvenioCategoriaDescricao" )]
      [  XmlElement( ElementName = "ConvenioCategoriaDescricao"   )]
      public string gxTpr_Conveniocategoriadescricao
      {
         get {
            return gxTv_SdtConvenioCategoria_Conveniocategoriadescricao ;
         }

         set {
            gxTv_SdtConvenioCategoria_Conveniocategoriadescricao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConvenioCategoria_Conveniocategoriadescricao = value;
            SetDirty("Conveniocategoriadescricao");
         }

      }

      public void gxTv_SdtConvenioCategoria_Conveniocategoriadescricao_SetNull( )
      {
         gxTv_SdtConvenioCategoria_Conveniocategoriadescricao_N = 1;
         gxTv_SdtConvenioCategoria_Conveniocategoriadescricao = "";
         SetDirty("Conveniocategoriadescricao");
         return  ;
      }

      public bool gxTv_SdtConvenioCategoria_Conveniocategoriadescricao_IsNull( )
      {
         return (gxTv_SdtConvenioCategoria_Conveniocategoriadescricao_N==1) ;
      }

      [  SoapElement( ElementName = "ConvenioCategoriaStatus" )]
      [  XmlElement( ElementName = "ConvenioCategoriaStatus"   )]
      public bool gxTpr_Conveniocategoriastatus
      {
         get {
            return gxTv_SdtConvenioCategoria_Conveniocategoriastatus ;
         }

         set {
            gxTv_SdtConvenioCategoria_Conveniocategoriastatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConvenioCategoria_Conveniocategoriastatus = value;
            SetDirty("Conveniocategoriastatus");
         }

      }

      public void gxTv_SdtConvenioCategoria_Conveniocategoriastatus_SetNull( )
      {
         gxTv_SdtConvenioCategoria_Conveniocategoriastatus_N = 1;
         gxTv_SdtConvenioCategoria_Conveniocategoriastatus = false;
         SetDirty("Conveniocategoriastatus");
         return  ;
      }

      public bool gxTv_SdtConvenioCategoria_Conveniocategoriastatus_IsNull( )
      {
         return (gxTv_SdtConvenioCategoria_Conveniocategoriastatus_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtConvenioCategoria_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConvenioCategoria_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtConvenioCategoria_Mode_SetNull( )
      {
         gxTv_SdtConvenioCategoria_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtConvenioCategoria_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtConvenioCategoria_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConvenioCategoria_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtConvenioCategoria_Initialized_SetNull( )
      {
         gxTv_SdtConvenioCategoria_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtConvenioCategoria_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConvenioCategoriaId_Z" )]
      [  XmlElement( ElementName = "ConvenioCategoriaId_Z"   )]
      public int gxTpr_Conveniocategoriaid_Z
      {
         get {
            return gxTv_SdtConvenioCategoria_Conveniocategoriaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConvenioCategoria_Conveniocategoriaid_Z = value;
            SetDirty("Conveniocategoriaid_Z");
         }

      }

      public void gxTv_SdtConvenioCategoria_Conveniocategoriaid_Z_SetNull( )
      {
         gxTv_SdtConvenioCategoria_Conveniocategoriaid_Z = 0;
         SetDirty("Conveniocategoriaid_Z");
         return  ;
      }

      public bool gxTv_SdtConvenioCategoria_Conveniocategoriaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConvenioId_Z" )]
      [  XmlElement( ElementName = "ConvenioId_Z"   )]
      public int gxTpr_Convenioid_Z
      {
         get {
            return gxTv_SdtConvenioCategoria_Convenioid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConvenioCategoria_Convenioid_Z = value;
            SetDirty("Convenioid_Z");
         }

      }

      public void gxTv_SdtConvenioCategoria_Convenioid_Z_SetNull( )
      {
         gxTv_SdtConvenioCategoria_Convenioid_Z = 0;
         SetDirty("Convenioid_Z");
         return  ;
      }

      public bool gxTv_SdtConvenioCategoria_Convenioid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConvenioCategoriaDescricao_Z" )]
      [  XmlElement( ElementName = "ConvenioCategoriaDescricao_Z"   )]
      public string gxTpr_Conveniocategoriadescricao_Z
      {
         get {
            return gxTv_SdtConvenioCategoria_Conveniocategoriadescricao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConvenioCategoria_Conveniocategoriadescricao_Z = value;
            SetDirty("Conveniocategoriadescricao_Z");
         }

      }

      public void gxTv_SdtConvenioCategoria_Conveniocategoriadescricao_Z_SetNull( )
      {
         gxTv_SdtConvenioCategoria_Conveniocategoriadescricao_Z = "";
         SetDirty("Conveniocategoriadescricao_Z");
         return  ;
      }

      public bool gxTv_SdtConvenioCategoria_Conveniocategoriadescricao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConvenioCategoriaStatus_Z" )]
      [  XmlElement( ElementName = "ConvenioCategoriaStatus_Z"   )]
      public bool gxTpr_Conveniocategoriastatus_Z
      {
         get {
            return gxTv_SdtConvenioCategoria_Conveniocategoriastatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConvenioCategoria_Conveniocategoriastatus_Z = value;
            SetDirty("Conveniocategoriastatus_Z");
         }

      }

      public void gxTv_SdtConvenioCategoria_Conveniocategoriastatus_Z_SetNull( )
      {
         gxTv_SdtConvenioCategoria_Conveniocategoriastatus_Z = false;
         SetDirty("Conveniocategoriastatus_Z");
         return  ;
      }

      public bool gxTv_SdtConvenioCategoria_Conveniocategoriastatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConvenioCategoriaId_N" )]
      [  XmlElement( ElementName = "ConvenioCategoriaId_N"   )]
      public short gxTpr_Conveniocategoriaid_N
      {
         get {
            return gxTv_SdtConvenioCategoria_Conveniocategoriaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConvenioCategoria_Conveniocategoriaid_N = value;
            SetDirty("Conveniocategoriaid_N");
         }

      }

      public void gxTv_SdtConvenioCategoria_Conveniocategoriaid_N_SetNull( )
      {
         gxTv_SdtConvenioCategoria_Conveniocategoriaid_N = 0;
         SetDirty("Conveniocategoriaid_N");
         return  ;
      }

      public bool gxTv_SdtConvenioCategoria_Conveniocategoriaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConvenioId_N" )]
      [  XmlElement( ElementName = "ConvenioId_N"   )]
      public short gxTpr_Convenioid_N
      {
         get {
            return gxTv_SdtConvenioCategoria_Convenioid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConvenioCategoria_Convenioid_N = value;
            SetDirty("Convenioid_N");
         }

      }

      public void gxTv_SdtConvenioCategoria_Convenioid_N_SetNull( )
      {
         gxTv_SdtConvenioCategoria_Convenioid_N = 0;
         SetDirty("Convenioid_N");
         return  ;
      }

      public bool gxTv_SdtConvenioCategoria_Convenioid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConvenioCategoriaDescricao_N" )]
      [  XmlElement( ElementName = "ConvenioCategoriaDescricao_N"   )]
      public short gxTpr_Conveniocategoriadescricao_N
      {
         get {
            return gxTv_SdtConvenioCategoria_Conveniocategoriadescricao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConvenioCategoria_Conveniocategoriadescricao_N = value;
            SetDirty("Conveniocategoriadescricao_N");
         }

      }

      public void gxTv_SdtConvenioCategoria_Conveniocategoriadescricao_N_SetNull( )
      {
         gxTv_SdtConvenioCategoria_Conveniocategoriadescricao_N = 0;
         SetDirty("Conveniocategoriadescricao_N");
         return  ;
      }

      public bool gxTv_SdtConvenioCategoria_Conveniocategoriadescricao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConvenioCategoriaStatus_N" )]
      [  XmlElement( ElementName = "ConvenioCategoriaStatus_N"   )]
      public short gxTpr_Conveniocategoriastatus_N
      {
         get {
            return gxTv_SdtConvenioCategoria_Conveniocategoriastatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConvenioCategoria_Conveniocategoriastatus_N = value;
            SetDirty("Conveniocategoriastatus_N");
         }

      }

      public void gxTv_SdtConvenioCategoria_Conveniocategoriastatus_N_SetNull( )
      {
         gxTv_SdtConvenioCategoria_Conveniocategoriastatus_N = 0;
         SetDirty("Conveniocategoriastatus_N");
         return  ;
      }

      public bool gxTv_SdtConvenioCategoria_Conveniocategoriastatus_N_IsNull( )
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
         gxTv_SdtConvenioCategoria_Conveniocategoriadescricao = "";
         gxTv_SdtConvenioCategoria_Mode = "";
         gxTv_SdtConvenioCategoria_Conveniocategoriadescricao_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "conveniocategoria", "GeneXus.Programs.conveniocategoria_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtConvenioCategoria_Initialized ;
      private short gxTv_SdtConvenioCategoria_Conveniocategoriaid_N ;
      private short gxTv_SdtConvenioCategoria_Convenioid_N ;
      private short gxTv_SdtConvenioCategoria_Conveniocategoriadescricao_N ;
      private short gxTv_SdtConvenioCategoria_Conveniocategoriastatus_N ;
      private int gxTv_SdtConvenioCategoria_Conveniocategoriaid ;
      private int gxTv_SdtConvenioCategoria_Convenioid ;
      private int gxTv_SdtConvenioCategoria_Conveniocategoriaid_Z ;
      private int gxTv_SdtConvenioCategoria_Convenioid_Z ;
      private string gxTv_SdtConvenioCategoria_Mode ;
      private bool gxTv_SdtConvenioCategoria_Conveniocategoriastatus ;
      private bool gxTv_SdtConvenioCategoria_Conveniocategoriastatus_Z ;
      private string gxTv_SdtConvenioCategoria_Conveniocategoriadescricao ;
      private string gxTv_SdtConvenioCategoria_Conveniocategoriadescricao_Z ;
   }

   [DataContract(Name = @"ConvenioCategoria", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtConvenioCategoria_RESTInterface : GxGenericCollectionItem<SdtConvenioCategoria>
   {
      public SdtConvenioCategoria_RESTInterface( ) : base()
      {
      }

      public SdtConvenioCategoria_RESTInterface( SdtConvenioCategoria psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ConvenioCategoriaId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Conveniocategoriaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Conveniocategoriaid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Conveniocategoriaid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ConvenioId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Convenioid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Convenioid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Convenioid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ConvenioCategoriaDescricao" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Conveniocategoriadescricao
      {
         get {
            return sdt.gxTpr_Conveniocategoriadescricao ;
         }

         set {
            sdt.gxTpr_Conveniocategoriadescricao = value;
         }

      }

      [DataMember( Name = "ConvenioCategoriaStatus" , Order = 3 )]
      [GxSeudo()]
      public bool gxTpr_Conveniocategoriastatus
      {
         get {
            return sdt.gxTpr_Conveniocategoriastatus ;
         }

         set {
            sdt.gxTpr_Conveniocategoriastatus = value;
         }

      }

      public SdtConvenioCategoria sdt
      {
         get {
            return (SdtConvenioCategoria)Sdt ;
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
            sdt = new SdtConvenioCategoria() ;
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

   [DataContract(Name = @"ConvenioCategoria", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtConvenioCategoria_RESTLInterface : GxGenericCollectionItem<SdtConvenioCategoria>
   {
      public SdtConvenioCategoria_RESTLInterface( ) : base()
      {
      }

      public SdtConvenioCategoria_RESTLInterface( SdtConvenioCategoria psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ConvenioCategoriaDescricao" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Conveniocategoriadescricao
      {
         get {
            return sdt.gxTpr_Conveniocategoriadescricao ;
         }

         set {
            sdt.gxTpr_Conveniocategoriadescricao = value;
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

      public SdtConvenioCategoria sdt
      {
         get {
            return (SdtConvenioCategoria)Sdt ;
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
            sdt = new SdtConvenioCategoria() ;
         }
      }

   }

}
