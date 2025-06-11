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
   [XmlRoot(ElementName = "Preferencias" )]
   [XmlType(TypeName =  "Preferencias" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtPreferencias : GxSilentTrnSdt
   {
      public SdtPreferencias( )
      {
      }

      public SdtPreferencias( IGxContext context )
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

      public void Load( int AV296PreferenciasId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV296PreferenciasId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"PreferenciasId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Preferencias");
         metadata.Set("BT", "Preferencias");
         metadata.Set("PK", "[ \"PreferenciasId\" ]");
         metadata.Set("PKAssigned", "[ \"PreferenciasId\" ]");
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
         state.Add("gxTpr_Preferenciasid_Z");
         state.Add("gxTpr_Preferenciasmulta_Z");
         state.Add("gxTpr_Preferenciasjuros_Z");
         state.Add("gxTpr_Preferenciasmulta_N");
         state.Add("gxTpr_Preferenciasjuros_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtPreferencias sdt;
         sdt = (SdtPreferencias)(source);
         gxTv_SdtPreferencias_Preferenciasid = sdt.gxTv_SdtPreferencias_Preferenciasid ;
         gxTv_SdtPreferencias_Preferenciasmulta = sdt.gxTv_SdtPreferencias_Preferenciasmulta ;
         gxTv_SdtPreferencias_Preferenciasjuros = sdt.gxTv_SdtPreferencias_Preferenciasjuros ;
         gxTv_SdtPreferencias_Mode = sdt.gxTv_SdtPreferencias_Mode ;
         gxTv_SdtPreferencias_Initialized = sdt.gxTv_SdtPreferencias_Initialized ;
         gxTv_SdtPreferencias_Preferenciasid_Z = sdt.gxTv_SdtPreferencias_Preferenciasid_Z ;
         gxTv_SdtPreferencias_Preferenciasmulta_Z = sdt.gxTv_SdtPreferencias_Preferenciasmulta_Z ;
         gxTv_SdtPreferencias_Preferenciasjuros_Z = sdt.gxTv_SdtPreferencias_Preferenciasjuros_Z ;
         gxTv_SdtPreferencias_Preferenciasmulta_N = sdt.gxTv_SdtPreferencias_Preferenciasmulta_N ;
         gxTv_SdtPreferencias_Preferenciasjuros_N = sdt.gxTv_SdtPreferencias_Preferenciasjuros_N ;
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
         AddObjectProperty("PreferenciasId", gxTv_SdtPreferencias_Preferenciasid, false, includeNonInitialized);
         AddObjectProperty("PreferenciasMulta", StringUtil.LTrim( StringUtil.Str( gxTv_SdtPreferencias_Preferenciasmulta, 16, 4)), false, includeNonInitialized);
         AddObjectProperty("PreferenciasMulta_N", gxTv_SdtPreferencias_Preferenciasmulta_N, false, includeNonInitialized);
         AddObjectProperty("PreferenciasJuros", StringUtil.LTrim( StringUtil.Str( gxTv_SdtPreferencias_Preferenciasjuros, 16, 4)), false, includeNonInitialized);
         AddObjectProperty("PreferenciasJuros_N", gxTv_SdtPreferencias_Preferenciasjuros_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtPreferencias_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtPreferencias_Initialized, false, includeNonInitialized);
            AddObjectProperty("PreferenciasId_Z", gxTv_SdtPreferencias_Preferenciasid_Z, false, includeNonInitialized);
            AddObjectProperty("PreferenciasMulta_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtPreferencias_Preferenciasmulta_Z, 16, 4)), false, includeNonInitialized);
            AddObjectProperty("PreferenciasJuros_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtPreferencias_Preferenciasjuros_Z, 16, 4)), false, includeNonInitialized);
            AddObjectProperty("PreferenciasMulta_N", gxTv_SdtPreferencias_Preferenciasmulta_N, false, includeNonInitialized);
            AddObjectProperty("PreferenciasJuros_N", gxTv_SdtPreferencias_Preferenciasjuros_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtPreferencias sdt )
      {
         if ( sdt.IsDirty("PreferenciasId") )
         {
            sdtIsNull = 0;
            gxTv_SdtPreferencias_Preferenciasid = sdt.gxTv_SdtPreferencias_Preferenciasid ;
         }
         if ( sdt.IsDirty("PreferenciasMulta") )
         {
            gxTv_SdtPreferencias_Preferenciasmulta_N = (short)(sdt.gxTv_SdtPreferencias_Preferenciasmulta_N);
            sdtIsNull = 0;
            gxTv_SdtPreferencias_Preferenciasmulta = sdt.gxTv_SdtPreferencias_Preferenciasmulta ;
         }
         if ( sdt.IsDirty("PreferenciasJuros") )
         {
            gxTv_SdtPreferencias_Preferenciasjuros_N = (short)(sdt.gxTv_SdtPreferencias_Preferenciasjuros_N);
            sdtIsNull = 0;
            gxTv_SdtPreferencias_Preferenciasjuros = sdt.gxTv_SdtPreferencias_Preferenciasjuros ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "PreferenciasId" )]
      [  XmlElement( ElementName = "PreferenciasId"   )]
      public int gxTpr_Preferenciasid
      {
         get {
            return gxTv_SdtPreferencias_Preferenciasid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtPreferencias_Preferenciasid != value )
            {
               gxTv_SdtPreferencias_Mode = "INS";
               this.gxTv_SdtPreferencias_Preferenciasid_Z_SetNull( );
               this.gxTv_SdtPreferencias_Preferenciasmulta_Z_SetNull( );
               this.gxTv_SdtPreferencias_Preferenciasjuros_Z_SetNull( );
            }
            gxTv_SdtPreferencias_Preferenciasid = value;
            SetDirty("Preferenciasid");
         }

      }

      [  SoapElement( ElementName = "PreferenciasMulta" )]
      [  XmlElement( ElementName = "PreferenciasMulta"   )]
      public decimal gxTpr_Preferenciasmulta
      {
         get {
            return gxTv_SdtPreferencias_Preferenciasmulta ;
         }

         set {
            gxTv_SdtPreferencias_Preferenciasmulta_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPreferencias_Preferenciasmulta = value;
            SetDirty("Preferenciasmulta");
         }

      }

      public void gxTv_SdtPreferencias_Preferenciasmulta_SetNull( )
      {
         gxTv_SdtPreferencias_Preferenciasmulta_N = 1;
         gxTv_SdtPreferencias_Preferenciasmulta = 0;
         SetDirty("Preferenciasmulta");
         return  ;
      }

      public bool gxTv_SdtPreferencias_Preferenciasmulta_IsNull( )
      {
         return (gxTv_SdtPreferencias_Preferenciasmulta_N==1) ;
      }

      [  SoapElement( ElementName = "PreferenciasJuros" )]
      [  XmlElement( ElementName = "PreferenciasJuros"   )]
      public decimal gxTpr_Preferenciasjuros
      {
         get {
            return gxTv_SdtPreferencias_Preferenciasjuros ;
         }

         set {
            gxTv_SdtPreferencias_Preferenciasjuros_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPreferencias_Preferenciasjuros = value;
            SetDirty("Preferenciasjuros");
         }

      }

      public void gxTv_SdtPreferencias_Preferenciasjuros_SetNull( )
      {
         gxTv_SdtPreferencias_Preferenciasjuros_N = 1;
         gxTv_SdtPreferencias_Preferenciasjuros = 0;
         SetDirty("Preferenciasjuros");
         return  ;
      }

      public bool gxTv_SdtPreferencias_Preferenciasjuros_IsNull( )
      {
         return (gxTv_SdtPreferencias_Preferenciasjuros_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtPreferencias_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPreferencias_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtPreferencias_Mode_SetNull( )
      {
         gxTv_SdtPreferencias_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtPreferencias_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtPreferencias_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPreferencias_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtPreferencias_Initialized_SetNull( )
      {
         gxTv_SdtPreferencias_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtPreferencias_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PreferenciasId_Z" )]
      [  XmlElement( ElementName = "PreferenciasId_Z"   )]
      public int gxTpr_Preferenciasid_Z
      {
         get {
            return gxTv_SdtPreferencias_Preferenciasid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPreferencias_Preferenciasid_Z = value;
            SetDirty("Preferenciasid_Z");
         }

      }

      public void gxTv_SdtPreferencias_Preferenciasid_Z_SetNull( )
      {
         gxTv_SdtPreferencias_Preferenciasid_Z = 0;
         SetDirty("Preferenciasid_Z");
         return  ;
      }

      public bool gxTv_SdtPreferencias_Preferenciasid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PreferenciasMulta_Z" )]
      [  XmlElement( ElementName = "PreferenciasMulta_Z"   )]
      public decimal gxTpr_Preferenciasmulta_Z
      {
         get {
            return gxTv_SdtPreferencias_Preferenciasmulta_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPreferencias_Preferenciasmulta_Z = value;
            SetDirty("Preferenciasmulta_Z");
         }

      }

      public void gxTv_SdtPreferencias_Preferenciasmulta_Z_SetNull( )
      {
         gxTv_SdtPreferencias_Preferenciasmulta_Z = 0;
         SetDirty("Preferenciasmulta_Z");
         return  ;
      }

      public bool gxTv_SdtPreferencias_Preferenciasmulta_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PreferenciasJuros_Z" )]
      [  XmlElement( ElementName = "PreferenciasJuros_Z"   )]
      public decimal gxTpr_Preferenciasjuros_Z
      {
         get {
            return gxTv_SdtPreferencias_Preferenciasjuros_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPreferencias_Preferenciasjuros_Z = value;
            SetDirty("Preferenciasjuros_Z");
         }

      }

      public void gxTv_SdtPreferencias_Preferenciasjuros_Z_SetNull( )
      {
         gxTv_SdtPreferencias_Preferenciasjuros_Z = 0;
         SetDirty("Preferenciasjuros_Z");
         return  ;
      }

      public bool gxTv_SdtPreferencias_Preferenciasjuros_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PreferenciasMulta_N" )]
      [  XmlElement( ElementName = "PreferenciasMulta_N"   )]
      public short gxTpr_Preferenciasmulta_N
      {
         get {
            return gxTv_SdtPreferencias_Preferenciasmulta_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPreferencias_Preferenciasmulta_N = value;
            SetDirty("Preferenciasmulta_N");
         }

      }

      public void gxTv_SdtPreferencias_Preferenciasmulta_N_SetNull( )
      {
         gxTv_SdtPreferencias_Preferenciasmulta_N = 0;
         SetDirty("Preferenciasmulta_N");
         return  ;
      }

      public bool gxTv_SdtPreferencias_Preferenciasmulta_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PreferenciasJuros_N" )]
      [  XmlElement( ElementName = "PreferenciasJuros_N"   )]
      public short gxTpr_Preferenciasjuros_N
      {
         get {
            return gxTv_SdtPreferencias_Preferenciasjuros_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPreferencias_Preferenciasjuros_N = value;
            SetDirty("Preferenciasjuros_N");
         }

      }

      public void gxTv_SdtPreferencias_Preferenciasjuros_N_SetNull( )
      {
         gxTv_SdtPreferencias_Preferenciasjuros_N = 0;
         SetDirty("Preferenciasjuros_N");
         return  ;
      }

      public bool gxTv_SdtPreferencias_Preferenciasjuros_N_IsNull( )
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
         gxTv_SdtPreferencias_Mode = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "preferencias", "GeneXus.Programs.preferencias_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtPreferencias_Initialized ;
      private short gxTv_SdtPreferencias_Preferenciasmulta_N ;
      private short gxTv_SdtPreferencias_Preferenciasjuros_N ;
      private int gxTv_SdtPreferencias_Preferenciasid ;
      private int gxTv_SdtPreferencias_Preferenciasid_Z ;
      private decimal gxTv_SdtPreferencias_Preferenciasmulta ;
      private decimal gxTv_SdtPreferencias_Preferenciasjuros ;
      private decimal gxTv_SdtPreferencias_Preferenciasmulta_Z ;
      private decimal gxTv_SdtPreferencias_Preferenciasjuros_Z ;
      private string gxTv_SdtPreferencias_Mode ;
   }

   [DataContract(Name = @"Preferencias", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtPreferencias_RESTInterface : GxGenericCollectionItem<SdtPreferencias>
   {
      public SdtPreferencias_RESTInterface( ) : base()
      {
      }

      public SdtPreferencias_RESTInterface( SdtPreferencias psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PreferenciasId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Preferenciasid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Preferenciasid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Preferenciasid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "PreferenciasMulta" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Preferenciasmulta
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Preferenciasmulta, 16, 4)) ;
         }

         set {
            sdt.gxTpr_Preferenciasmulta = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "PreferenciasJuros" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Preferenciasjuros
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Preferenciasjuros, 16, 4)) ;
         }

         set {
            sdt.gxTpr_Preferenciasjuros = NumberUtil.Val( value, ".");
         }

      }

      public SdtPreferencias sdt
      {
         get {
            return (SdtPreferencias)Sdt ;
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
            sdt = new SdtPreferencias() ;
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

   [DataContract(Name = @"Preferencias", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtPreferencias_RESTLInterface : GxGenericCollectionItem<SdtPreferencias>
   {
      public SdtPreferencias_RESTLInterface( ) : base()
      {
      }

      public SdtPreferencias_RESTLInterface( SdtPreferencias psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PreferenciasMulta" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Preferenciasmulta
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Preferenciasmulta, 16, 4)) ;
         }

         set {
            sdt.gxTpr_Preferenciasmulta = NumberUtil.Val( value, ".");
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

      public SdtPreferencias sdt
      {
         get {
            return (SdtPreferencias)Sdt ;
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
            sdt = new SdtPreferencias() ;
         }
      }

   }

}
