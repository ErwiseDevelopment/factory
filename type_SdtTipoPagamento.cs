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
   [XmlRoot(ElementName = "TipoPagamento" )]
   [XmlType(TypeName =  "TipoPagamento" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtTipoPagamento : GxSilentTrnSdt
   {
      public SdtTipoPagamento( )
      {
      }

      public SdtTipoPagamento( IGxContext context )
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

      public void Load( int AV288TipoPagamentoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV288TipoPagamentoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"TipoPagamentoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "TipoPagamento");
         metadata.Set("BT", "TipoPagamento");
         metadata.Set("PK", "[ \"TipoPagamentoId\" ]");
         metadata.Set("PKAssigned", "[ \"TipoPagamentoId\" ]");
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
         state.Add("gxTpr_Tipopagamentoid_Z");
         state.Add("gxTpr_Tipopagamentonome_Z");
         state.Add("gxTpr_Tipopagamentoid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTipoPagamento sdt;
         sdt = (SdtTipoPagamento)(source);
         gxTv_SdtTipoPagamento_Tipopagamentoid = sdt.gxTv_SdtTipoPagamento_Tipopagamentoid ;
         gxTv_SdtTipoPagamento_Tipopagamentonome = sdt.gxTv_SdtTipoPagamento_Tipopagamentonome ;
         gxTv_SdtTipoPagamento_Mode = sdt.gxTv_SdtTipoPagamento_Mode ;
         gxTv_SdtTipoPagamento_Initialized = sdt.gxTv_SdtTipoPagamento_Initialized ;
         gxTv_SdtTipoPagamento_Tipopagamentoid_Z = sdt.gxTv_SdtTipoPagamento_Tipopagamentoid_Z ;
         gxTv_SdtTipoPagamento_Tipopagamentonome_Z = sdt.gxTv_SdtTipoPagamento_Tipopagamentonome_Z ;
         gxTv_SdtTipoPagamento_Tipopagamentoid_N = sdt.gxTv_SdtTipoPagamento_Tipopagamentoid_N ;
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
         AddObjectProperty("TipoPagamentoId", gxTv_SdtTipoPagamento_Tipopagamentoid, false, includeNonInitialized);
         AddObjectProperty("TipoPagamentoId_N", gxTv_SdtTipoPagamento_Tipopagamentoid_N, false, includeNonInitialized);
         AddObjectProperty("TipoPagamentoNome", gxTv_SdtTipoPagamento_Tipopagamentonome, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTipoPagamento_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTipoPagamento_Initialized, false, includeNonInitialized);
            AddObjectProperty("TipoPagamentoId_Z", gxTv_SdtTipoPagamento_Tipopagamentoid_Z, false, includeNonInitialized);
            AddObjectProperty("TipoPagamentoNome_Z", gxTv_SdtTipoPagamento_Tipopagamentonome_Z, false, includeNonInitialized);
            AddObjectProperty("TipoPagamentoId_N", gxTv_SdtTipoPagamento_Tipopagamentoid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTipoPagamento sdt )
      {
         if ( sdt.IsDirty("TipoPagamentoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTipoPagamento_Tipopagamentoid = sdt.gxTv_SdtTipoPagamento_Tipopagamentoid ;
         }
         if ( sdt.IsDirty("TipoPagamentoNome") )
         {
            sdtIsNull = 0;
            gxTv_SdtTipoPagamento_Tipopagamentonome = sdt.gxTv_SdtTipoPagamento_Tipopagamentonome ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "TipoPagamentoId" )]
      [  XmlElement( ElementName = "TipoPagamentoId"   )]
      public int gxTpr_Tipopagamentoid
      {
         get {
            return gxTv_SdtTipoPagamento_Tipopagamentoid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTipoPagamento_Tipopagamentoid != value )
            {
               gxTv_SdtTipoPagamento_Mode = "INS";
               this.gxTv_SdtTipoPagamento_Tipopagamentoid_Z_SetNull( );
               this.gxTv_SdtTipoPagamento_Tipopagamentonome_Z_SetNull( );
            }
            gxTv_SdtTipoPagamento_Tipopagamentoid = value;
            SetDirty("Tipopagamentoid");
         }

      }

      [  SoapElement( ElementName = "TipoPagamentoNome" )]
      [  XmlElement( ElementName = "TipoPagamentoNome"   )]
      public string gxTpr_Tipopagamentonome
      {
         get {
            return gxTv_SdtTipoPagamento_Tipopagamentonome ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTipoPagamento_Tipopagamentonome = value;
            SetDirty("Tipopagamentonome");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTipoPagamento_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTipoPagamento_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTipoPagamento_Mode_SetNull( )
      {
         gxTv_SdtTipoPagamento_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTipoPagamento_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTipoPagamento_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTipoPagamento_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTipoPagamento_Initialized_SetNull( )
      {
         gxTv_SdtTipoPagamento_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTipoPagamento_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoPagamentoId_Z" )]
      [  XmlElement( ElementName = "TipoPagamentoId_Z"   )]
      public int gxTpr_Tipopagamentoid_Z
      {
         get {
            return gxTv_SdtTipoPagamento_Tipopagamentoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTipoPagamento_Tipopagamentoid_Z = value;
            SetDirty("Tipopagamentoid_Z");
         }

      }

      public void gxTv_SdtTipoPagamento_Tipopagamentoid_Z_SetNull( )
      {
         gxTv_SdtTipoPagamento_Tipopagamentoid_Z = 0;
         SetDirty("Tipopagamentoid_Z");
         return  ;
      }

      public bool gxTv_SdtTipoPagamento_Tipopagamentoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoPagamentoNome_Z" )]
      [  XmlElement( ElementName = "TipoPagamentoNome_Z"   )]
      public string gxTpr_Tipopagamentonome_Z
      {
         get {
            return gxTv_SdtTipoPagamento_Tipopagamentonome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTipoPagamento_Tipopagamentonome_Z = value;
            SetDirty("Tipopagamentonome_Z");
         }

      }

      public void gxTv_SdtTipoPagamento_Tipopagamentonome_Z_SetNull( )
      {
         gxTv_SdtTipoPagamento_Tipopagamentonome_Z = "";
         SetDirty("Tipopagamentonome_Z");
         return  ;
      }

      public bool gxTv_SdtTipoPagamento_Tipopagamentonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoPagamentoId_N" )]
      [  XmlElement( ElementName = "TipoPagamentoId_N"   )]
      public short gxTpr_Tipopagamentoid_N
      {
         get {
            return gxTv_SdtTipoPagamento_Tipopagamentoid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTipoPagamento_Tipopagamentoid_N = value;
            SetDirty("Tipopagamentoid_N");
         }

      }

      public void gxTv_SdtTipoPagamento_Tipopagamentoid_N_SetNull( )
      {
         gxTv_SdtTipoPagamento_Tipopagamentoid_N = 0;
         SetDirty("Tipopagamentoid_N");
         return  ;
      }

      public bool gxTv_SdtTipoPagamento_Tipopagamentoid_N_IsNull( )
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
         gxTv_SdtTipoPagamento_Tipopagamentonome = "";
         gxTv_SdtTipoPagamento_Mode = "";
         gxTv_SdtTipoPagamento_Tipopagamentonome_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "tipopagamento", "GeneXus.Programs.tipopagamento_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTipoPagamento_Initialized ;
      private short gxTv_SdtTipoPagamento_Tipopagamentoid_N ;
      private int gxTv_SdtTipoPagamento_Tipopagamentoid ;
      private int gxTv_SdtTipoPagamento_Tipopagamentoid_Z ;
      private string gxTv_SdtTipoPagamento_Mode ;
      private string gxTv_SdtTipoPagamento_Tipopagamentonome ;
      private string gxTv_SdtTipoPagamento_Tipopagamentonome_Z ;
   }

   [DataContract(Name = @"TipoPagamento", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtTipoPagamento_RESTInterface : GxGenericCollectionItem<SdtTipoPagamento>
   {
      public SdtTipoPagamento_RESTInterface( ) : base()
      {
      }

      public SdtTipoPagamento_RESTInterface( SdtTipoPagamento psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TipoPagamentoId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Tipopagamentoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Tipopagamentoid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Tipopagamentoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "TipoPagamentoNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Tipopagamentonome
      {
         get {
            return sdt.gxTpr_Tipopagamentonome ;
         }

         set {
            sdt.gxTpr_Tipopagamentonome = value;
         }

      }

      public SdtTipoPagamento sdt
      {
         get {
            return (SdtTipoPagamento)Sdt ;
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
            sdt = new SdtTipoPagamento() ;
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

   [DataContract(Name = @"TipoPagamento", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtTipoPagamento_RESTLInterface : GxGenericCollectionItem<SdtTipoPagamento>
   {
      public SdtTipoPagamento_RESTLInterface( ) : base()
      {
      }

      public SdtTipoPagamento_RESTLInterface( SdtTipoPagamento psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TipoPagamentoNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Tipopagamentonome
      {
         get {
            return sdt.gxTpr_Tipopagamentonome ;
         }

         set {
            sdt.gxTpr_Tipopagamentonome = value;
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

      public SdtTipoPagamento sdt
      {
         get {
            return (SdtTipoPagamento)Sdt ;
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
            sdt = new SdtTipoPagamento() ;
         }
      }

   }

}
