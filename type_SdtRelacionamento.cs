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
   [XmlRoot(ElementName = "Relacionamento" )]
   [XmlType(TypeName =  "Relacionamento" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtRelacionamento : GxSilentTrnSdt
   {
      public SdtRelacionamento( )
      {
      }

      public SdtRelacionamento( IGxContext context )
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

      public void Load( int AV1032RelacionamentoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV1032RelacionamentoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"RelacionamentoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Relacionamento");
         metadata.Set("BT", "Relacionamento");
         metadata.Set("PK", "[ \"RelacionamentoId\" ]");
         metadata.Set("PKAssigned", "[ \"RelacionamentoId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ClienteId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Relacionamentoid_Z");
         state.Add("gxTpr_Clienteid_Z");
         state.Add("gxTpr_Relacionamentotipo_Z");
         state.Add("gxTpr_Clienteid_N");
         state.Add("gxTpr_Relacionamentotipo_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtRelacionamento sdt;
         sdt = (SdtRelacionamento)(source);
         gxTv_SdtRelacionamento_Relacionamentoid = sdt.gxTv_SdtRelacionamento_Relacionamentoid ;
         gxTv_SdtRelacionamento_Clienteid = sdt.gxTv_SdtRelacionamento_Clienteid ;
         gxTv_SdtRelacionamento_Relacionamentotipo = sdt.gxTv_SdtRelacionamento_Relacionamentotipo ;
         gxTv_SdtRelacionamento_Mode = sdt.gxTv_SdtRelacionamento_Mode ;
         gxTv_SdtRelacionamento_Initialized = sdt.gxTv_SdtRelacionamento_Initialized ;
         gxTv_SdtRelacionamento_Relacionamentoid_Z = sdt.gxTv_SdtRelacionamento_Relacionamentoid_Z ;
         gxTv_SdtRelacionamento_Clienteid_Z = sdt.gxTv_SdtRelacionamento_Clienteid_Z ;
         gxTv_SdtRelacionamento_Relacionamentotipo_Z = sdt.gxTv_SdtRelacionamento_Relacionamentotipo_Z ;
         gxTv_SdtRelacionamento_Clienteid_N = sdt.gxTv_SdtRelacionamento_Clienteid_N ;
         gxTv_SdtRelacionamento_Relacionamentotipo_N = sdt.gxTv_SdtRelacionamento_Relacionamentotipo_N ;
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
         AddObjectProperty("RelacionamentoId", gxTv_SdtRelacionamento_Relacionamentoid, false, includeNonInitialized);
         AddObjectProperty("ClienteId", gxTv_SdtRelacionamento_Clienteid, false, includeNonInitialized);
         AddObjectProperty("ClienteId_N", gxTv_SdtRelacionamento_Clienteid_N, false, includeNonInitialized);
         AddObjectProperty("RelacionamentoTipo", gxTv_SdtRelacionamento_Relacionamentotipo, false, includeNonInitialized);
         AddObjectProperty("RelacionamentoTipo_N", gxTv_SdtRelacionamento_Relacionamentotipo_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtRelacionamento_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtRelacionamento_Initialized, false, includeNonInitialized);
            AddObjectProperty("RelacionamentoId_Z", gxTv_SdtRelacionamento_Relacionamentoid_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteId_Z", gxTv_SdtRelacionamento_Clienteid_Z, false, includeNonInitialized);
            AddObjectProperty("RelacionamentoTipo_Z", gxTv_SdtRelacionamento_Relacionamentotipo_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteId_N", gxTv_SdtRelacionamento_Clienteid_N, false, includeNonInitialized);
            AddObjectProperty("RelacionamentoTipo_N", gxTv_SdtRelacionamento_Relacionamentotipo_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtRelacionamento sdt )
      {
         if ( sdt.IsDirty("RelacionamentoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtRelacionamento_Relacionamentoid = sdt.gxTv_SdtRelacionamento_Relacionamentoid ;
         }
         if ( sdt.IsDirty("ClienteId") )
         {
            gxTv_SdtRelacionamento_Clienteid_N = (short)(sdt.gxTv_SdtRelacionamento_Clienteid_N);
            sdtIsNull = 0;
            gxTv_SdtRelacionamento_Clienteid = sdt.gxTv_SdtRelacionamento_Clienteid ;
         }
         if ( sdt.IsDirty("RelacionamentoTipo") )
         {
            gxTv_SdtRelacionamento_Relacionamentotipo_N = (short)(sdt.gxTv_SdtRelacionamento_Relacionamentotipo_N);
            sdtIsNull = 0;
            gxTv_SdtRelacionamento_Relacionamentotipo = sdt.gxTv_SdtRelacionamento_Relacionamentotipo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "RelacionamentoId" )]
      [  XmlElement( ElementName = "RelacionamentoId"   )]
      public int gxTpr_Relacionamentoid
      {
         get {
            return gxTv_SdtRelacionamento_Relacionamentoid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtRelacionamento_Relacionamentoid != value )
            {
               gxTv_SdtRelacionamento_Mode = "INS";
               this.gxTv_SdtRelacionamento_Relacionamentoid_Z_SetNull( );
               this.gxTv_SdtRelacionamento_Clienteid_Z_SetNull( );
               this.gxTv_SdtRelacionamento_Relacionamentotipo_Z_SetNull( );
            }
            gxTv_SdtRelacionamento_Relacionamentoid = value;
            SetDirty("Relacionamentoid");
         }

      }

      [  SoapElement( ElementName = "ClienteId" )]
      [  XmlElement( ElementName = "ClienteId"   )]
      public int gxTpr_Clienteid
      {
         get {
            return gxTv_SdtRelacionamento_Clienteid ;
         }

         set {
            gxTv_SdtRelacionamento_Clienteid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtRelacionamento_Clienteid = value;
            SetDirty("Clienteid");
         }

      }

      public void gxTv_SdtRelacionamento_Clienteid_SetNull( )
      {
         gxTv_SdtRelacionamento_Clienteid_N = 1;
         gxTv_SdtRelacionamento_Clienteid = 0;
         SetDirty("Clienteid");
         return  ;
      }

      public bool gxTv_SdtRelacionamento_Clienteid_IsNull( )
      {
         return (gxTv_SdtRelacionamento_Clienteid_N==1) ;
      }

      [  SoapElement( ElementName = "RelacionamentoTipo" )]
      [  XmlElement( ElementName = "RelacionamentoTipo"   )]
      public string gxTpr_Relacionamentotipo
      {
         get {
            return gxTv_SdtRelacionamento_Relacionamentotipo ;
         }

         set {
            gxTv_SdtRelacionamento_Relacionamentotipo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtRelacionamento_Relacionamentotipo = value;
            SetDirty("Relacionamentotipo");
         }

      }

      public void gxTv_SdtRelacionamento_Relacionamentotipo_SetNull( )
      {
         gxTv_SdtRelacionamento_Relacionamentotipo_N = 1;
         gxTv_SdtRelacionamento_Relacionamentotipo = "";
         SetDirty("Relacionamentotipo");
         return  ;
      }

      public bool gxTv_SdtRelacionamento_Relacionamentotipo_IsNull( )
      {
         return (gxTv_SdtRelacionamento_Relacionamentotipo_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtRelacionamento_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRelacionamento_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtRelacionamento_Mode_SetNull( )
      {
         gxTv_SdtRelacionamento_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtRelacionamento_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtRelacionamento_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRelacionamento_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtRelacionamento_Initialized_SetNull( )
      {
         gxTv_SdtRelacionamento_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtRelacionamento_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RelacionamentoId_Z" )]
      [  XmlElement( ElementName = "RelacionamentoId_Z"   )]
      public int gxTpr_Relacionamentoid_Z
      {
         get {
            return gxTv_SdtRelacionamento_Relacionamentoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRelacionamento_Relacionamentoid_Z = value;
            SetDirty("Relacionamentoid_Z");
         }

      }

      public void gxTv_SdtRelacionamento_Relacionamentoid_Z_SetNull( )
      {
         gxTv_SdtRelacionamento_Relacionamentoid_Z = 0;
         SetDirty("Relacionamentoid_Z");
         return  ;
      }

      public bool gxTv_SdtRelacionamento_Relacionamentoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteId_Z" )]
      [  XmlElement( ElementName = "ClienteId_Z"   )]
      public int gxTpr_Clienteid_Z
      {
         get {
            return gxTv_SdtRelacionamento_Clienteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRelacionamento_Clienteid_Z = value;
            SetDirty("Clienteid_Z");
         }

      }

      public void gxTv_SdtRelacionamento_Clienteid_Z_SetNull( )
      {
         gxTv_SdtRelacionamento_Clienteid_Z = 0;
         SetDirty("Clienteid_Z");
         return  ;
      }

      public bool gxTv_SdtRelacionamento_Clienteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RelacionamentoTipo_Z" )]
      [  XmlElement( ElementName = "RelacionamentoTipo_Z"   )]
      public string gxTpr_Relacionamentotipo_Z
      {
         get {
            return gxTv_SdtRelacionamento_Relacionamentotipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRelacionamento_Relacionamentotipo_Z = value;
            SetDirty("Relacionamentotipo_Z");
         }

      }

      public void gxTv_SdtRelacionamento_Relacionamentotipo_Z_SetNull( )
      {
         gxTv_SdtRelacionamento_Relacionamentotipo_Z = "";
         SetDirty("Relacionamentotipo_Z");
         return  ;
      }

      public bool gxTv_SdtRelacionamento_Relacionamentotipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteId_N" )]
      [  XmlElement( ElementName = "ClienteId_N"   )]
      public short gxTpr_Clienteid_N
      {
         get {
            return gxTv_SdtRelacionamento_Clienteid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRelacionamento_Clienteid_N = value;
            SetDirty("Clienteid_N");
         }

      }

      public void gxTv_SdtRelacionamento_Clienteid_N_SetNull( )
      {
         gxTv_SdtRelacionamento_Clienteid_N = 0;
         SetDirty("Clienteid_N");
         return  ;
      }

      public bool gxTv_SdtRelacionamento_Clienteid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RelacionamentoTipo_N" )]
      [  XmlElement( ElementName = "RelacionamentoTipo_N"   )]
      public short gxTpr_Relacionamentotipo_N
      {
         get {
            return gxTv_SdtRelacionamento_Relacionamentotipo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRelacionamento_Relacionamentotipo_N = value;
            SetDirty("Relacionamentotipo_N");
         }

      }

      public void gxTv_SdtRelacionamento_Relacionamentotipo_N_SetNull( )
      {
         gxTv_SdtRelacionamento_Relacionamentotipo_N = 0;
         SetDirty("Relacionamentotipo_N");
         return  ;
      }

      public bool gxTv_SdtRelacionamento_Relacionamentotipo_N_IsNull( )
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
         gxTv_SdtRelacionamento_Relacionamentotipo = "";
         gxTv_SdtRelacionamento_Mode = "";
         gxTv_SdtRelacionamento_Relacionamentotipo_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "relacionamento", "GeneXus.Programs.relacionamento_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtRelacionamento_Initialized ;
      private short gxTv_SdtRelacionamento_Clienteid_N ;
      private short gxTv_SdtRelacionamento_Relacionamentotipo_N ;
      private int gxTv_SdtRelacionamento_Relacionamentoid ;
      private int gxTv_SdtRelacionamento_Clienteid ;
      private int gxTv_SdtRelacionamento_Relacionamentoid_Z ;
      private int gxTv_SdtRelacionamento_Clienteid_Z ;
      private string gxTv_SdtRelacionamento_Mode ;
      private string gxTv_SdtRelacionamento_Relacionamentotipo ;
      private string gxTv_SdtRelacionamento_Relacionamentotipo_Z ;
   }

   [DataContract(Name = @"Relacionamento", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtRelacionamento_RESTInterface : GxGenericCollectionItem<SdtRelacionamento>
   {
      public SdtRelacionamento_RESTInterface( ) : base()
      {
      }

      public SdtRelacionamento_RESTInterface( SdtRelacionamento psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "RelacionamentoId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Relacionamentoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Relacionamentoid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Relacionamentoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ClienteId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Clienteid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Clienteid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Clienteid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "RelacionamentoTipo" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Relacionamentotipo
      {
         get {
            return sdt.gxTpr_Relacionamentotipo ;
         }

         set {
            sdt.gxTpr_Relacionamentotipo = value;
         }

      }

      public SdtRelacionamento sdt
      {
         get {
            return (SdtRelacionamento)Sdt ;
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
            sdt = new SdtRelacionamento() ;
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

   [DataContract(Name = @"Relacionamento", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtRelacionamento_RESTLInterface : GxGenericCollectionItem<SdtRelacionamento>
   {
      public SdtRelacionamento_RESTLInterface( ) : base()
      {
      }

      public SdtRelacionamento_RESTLInterface( SdtRelacionamento psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "RelacionamentoTipo" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Relacionamentotipo
      {
         get {
            return sdt.gxTpr_Relacionamentotipo ;
         }

         set {
            sdt.gxTpr_Relacionamentotipo = value;
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

      public SdtRelacionamento sdt
      {
         get {
            return (SdtRelacionamento)Sdt ;
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
            sdt = new SdtRelacionamento() ;
         }
      }

   }

}
