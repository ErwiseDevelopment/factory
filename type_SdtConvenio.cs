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
   [XmlRoot(ElementName = "Convenio" )]
   [XmlType(TypeName =  "Convenio" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtConvenio : GxSilentTrnSdt
   {
      public SdtConvenio( )
      {
      }

      public SdtConvenio( IGxContext context )
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

      public void Load( int AV410ConvenioId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV410ConvenioId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ConvenioId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Convenio");
         metadata.Set("BT", "Convenio");
         metadata.Set("PK", "[ \"ConvenioId\" ]");
         metadata.Set("PKAssigned", "[ \"ConvenioId\" ]");
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
         state.Add("gxTpr_Convenioid_Z");
         state.Add("gxTpr_Conveniodescricao_Z");
         state.Add("gxTpr_Conveniostatus_Z");
         state.Add("gxTpr_Convenioid_N");
         state.Add("gxTpr_Conveniodescricao_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtConvenio sdt;
         sdt = (SdtConvenio)(source);
         gxTv_SdtConvenio_Convenioid = sdt.gxTv_SdtConvenio_Convenioid ;
         gxTv_SdtConvenio_Conveniodescricao = sdt.gxTv_SdtConvenio_Conveniodescricao ;
         gxTv_SdtConvenio_Conveniostatus = sdt.gxTv_SdtConvenio_Conveniostatus ;
         gxTv_SdtConvenio_Mode = sdt.gxTv_SdtConvenio_Mode ;
         gxTv_SdtConvenio_Initialized = sdt.gxTv_SdtConvenio_Initialized ;
         gxTv_SdtConvenio_Convenioid_Z = sdt.gxTv_SdtConvenio_Convenioid_Z ;
         gxTv_SdtConvenio_Conveniodescricao_Z = sdt.gxTv_SdtConvenio_Conveniodescricao_Z ;
         gxTv_SdtConvenio_Conveniostatus_Z = sdt.gxTv_SdtConvenio_Conveniostatus_Z ;
         gxTv_SdtConvenio_Convenioid_N = sdt.gxTv_SdtConvenio_Convenioid_N ;
         gxTv_SdtConvenio_Conveniodescricao_N = sdt.gxTv_SdtConvenio_Conveniodescricao_N ;
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
         AddObjectProperty("ConvenioId", gxTv_SdtConvenio_Convenioid, false, includeNonInitialized);
         AddObjectProperty("ConvenioId_N", gxTv_SdtConvenio_Convenioid_N, false, includeNonInitialized);
         AddObjectProperty("ConvenioDescricao", gxTv_SdtConvenio_Conveniodescricao, false, includeNonInitialized);
         AddObjectProperty("ConvenioDescricao_N", gxTv_SdtConvenio_Conveniodescricao_N, false, includeNonInitialized);
         AddObjectProperty("ConvenioStatus", gxTv_SdtConvenio_Conveniostatus, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtConvenio_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtConvenio_Initialized, false, includeNonInitialized);
            AddObjectProperty("ConvenioId_Z", gxTv_SdtConvenio_Convenioid_Z, false, includeNonInitialized);
            AddObjectProperty("ConvenioDescricao_Z", gxTv_SdtConvenio_Conveniodescricao_Z, false, includeNonInitialized);
            AddObjectProperty("ConvenioStatus_Z", gxTv_SdtConvenio_Conveniostatus_Z, false, includeNonInitialized);
            AddObjectProperty("ConvenioId_N", gxTv_SdtConvenio_Convenioid_N, false, includeNonInitialized);
            AddObjectProperty("ConvenioDescricao_N", gxTv_SdtConvenio_Conveniodescricao_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtConvenio sdt )
      {
         if ( sdt.IsDirty("ConvenioId") )
         {
            sdtIsNull = 0;
            gxTv_SdtConvenio_Convenioid = sdt.gxTv_SdtConvenio_Convenioid ;
         }
         if ( sdt.IsDirty("ConvenioDescricao") )
         {
            gxTv_SdtConvenio_Conveniodescricao_N = (short)(sdt.gxTv_SdtConvenio_Conveniodescricao_N);
            sdtIsNull = 0;
            gxTv_SdtConvenio_Conveniodescricao = sdt.gxTv_SdtConvenio_Conveniodescricao ;
         }
         if ( sdt.IsDirty("ConvenioStatus") )
         {
            sdtIsNull = 0;
            gxTv_SdtConvenio_Conveniostatus = sdt.gxTv_SdtConvenio_Conveniostatus ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ConvenioId" )]
      [  XmlElement( ElementName = "ConvenioId"   )]
      public int gxTpr_Convenioid
      {
         get {
            return gxTv_SdtConvenio_Convenioid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtConvenio_Convenioid != value )
            {
               gxTv_SdtConvenio_Mode = "INS";
               this.gxTv_SdtConvenio_Convenioid_Z_SetNull( );
               this.gxTv_SdtConvenio_Conveniodescricao_Z_SetNull( );
               this.gxTv_SdtConvenio_Conveniostatus_Z_SetNull( );
            }
            gxTv_SdtConvenio_Convenioid = value;
            SetDirty("Convenioid");
         }

      }

      [  SoapElement( ElementName = "ConvenioDescricao" )]
      [  XmlElement( ElementName = "ConvenioDescricao"   )]
      public string gxTpr_Conveniodescricao
      {
         get {
            return gxTv_SdtConvenio_Conveniodescricao ;
         }

         set {
            gxTv_SdtConvenio_Conveniodescricao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConvenio_Conveniodescricao = value;
            SetDirty("Conveniodescricao");
         }

      }

      public void gxTv_SdtConvenio_Conveniodescricao_SetNull( )
      {
         gxTv_SdtConvenio_Conveniodescricao_N = 1;
         gxTv_SdtConvenio_Conveniodescricao = "";
         SetDirty("Conveniodescricao");
         return  ;
      }

      public bool gxTv_SdtConvenio_Conveniodescricao_IsNull( )
      {
         return (gxTv_SdtConvenio_Conveniodescricao_N==1) ;
      }

      [  SoapElement( ElementName = "ConvenioStatus" )]
      [  XmlElement( ElementName = "ConvenioStatus"   )]
      public bool gxTpr_Conveniostatus
      {
         get {
            return gxTv_SdtConvenio_Conveniostatus ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConvenio_Conveniostatus = value;
            SetDirty("Conveniostatus");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtConvenio_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConvenio_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtConvenio_Mode_SetNull( )
      {
         gxTv_SdtConvenio_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtConvenio_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtConvenio_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConvenio_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtConvenio_Initialized_SetNull( )
      {
         gxTv_SdtConvenio_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtConvenio_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConvenioId_Z" )]
      [  XmlElement( ElementName = "ConvenioId_Z"   )]
      public int gxTpr_Convenioid_Z
      {
         get {
            return gxTv_SdtConvenio_Convenioid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConvenio_Convenioid_Z = value;
            SetDirty("Convenioid_Z");
         }

      }

      public void gxTv_SdtConvenio_Convenioid_Z_SetNull( )
      {
         gxTv_SdtConvenio_Convenioid_Z = 0;
         SetDirty("Convenioid_Z");
         return  ;
      }

      public bool gxTv_SdtConvenio_Convenioid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConvenioDescricao_Z" )]
      [  XmlElement( ElementName = "ConvenioDescricao_Z"   )]
      public string gxTpr_Conveniodescricao_Z
      {
         get {
            return gxTv_SdtConvenio_Conveniodescricao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConvenio_Conveniodescricao_Z = value;
            SetDirty("Conveniodescricao_Z");
         }

      }

      public void gxTv_SdtConvenio_Conveniodescricao_Z_SetNull( )
      {
         gxTv_SdtConvenio_Conveniodescricao_Z = "";
         SetDirty("Conveniodescricao_Z");
         return  ;
      }

      public bool gxTv_SdtConvenio_Conveniodescricao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConvenioStatus_Z" )]
      [  XmlElement( ElementName = "ConvenioStatus_Z"   )]
      public bool gxTpr_Conveniostatus_Z
      {
         get {
            return gxTv_SdtConvenio_Conveniostatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConvenio_Conveniostatus_Z = value;
            SetDirty("Conveniostatus_Z");
         }

      }

      public void gxTv_SdtConvenio_Conveniostatus_Z_SetNull( )
      {
         gxTv_SdtConvenio_Conveniostatus_Z = false;
         SetDirty("Conveniostatus_Z");
         return  ;
      }

      public bool gxTv_SdtConvenio_Conveniostatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConvenioId_N" )]
      [  XmlElement( ElementName = "ConvenioId_N"   )]
      public short gxTpr_Convenioid_N
      {
         get {
            return gxTv_SdtConvenio_Convenioid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConvenio_Convenioid_N = value;
            SetDirty("Convenioid_N");
         }

      }

      public void gxTv_SdtConvenio_Convenioid_N_SetNull( )
      {
         gxTv_SdtConvenio_Convenioid_N = 0;
         SetDirty("Convenioid_N");
         return  ;
      }

      public bool gxTv_SdtConvenio_Convenioid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConvenioDescricao_N" )]
      [  XmlElement( ElementName = "ConvenioDescricao_N"   )]
      public short gxTpr_Conveniodescricao_N
      {
         get {
            return gxTv_SdtConvenio_Conveniodescricao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConvenio_Conveniodescricao_N = value;
            SetDirty("Conveniodescricao_N");
         }

      }

      public void gxTv_SdtConvenio_Conveniodescricao_N_SetNull( )
      {
         gxTv_SdtConvenio_Conveniodescricao_N = 0;
         SetDirty("Conveniodescricao_N");
         return  ;
      }

      public bool gxTv_SdtConvenio_Conveniodescricao_N_IsNull( )
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
         gxTv_SdtConvenio_Conveniodescricao = "";
         gxTv_SdtConvenio_Mode = "";
         gxTv_SdtConvenio_Conveniodescricao_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "convenio", "GeneXus.Programs.convenio_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtConvenio_Initialized ;
      private short gxTv_SdtConvenio_Convenioid_N ;
      private short gxTv_SdtConvenio_Conveniodescricao_N ;
      private int gxTv_SdtConvenio_Convenioid ;
      private int gxTv_SdtConvenio_Convenioid_Z ;
      private string gxTv_SdtConvenio_Mode ;
      private bool gxTv_SdtConvenio_Conveniostatus ;
      private bool gxTv_SdtConvenio_Conveniostatus_Z ;
      private string gxTv_SdtConvenio_Conveniodescricao ;
      private string gxTv_SdtConvenio_Conveniodescricao_Z ;
   }

   [DataContract(Name = @"Convenio", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtConvenio_RESTInterface : GxGenericCollectionItem<SdtConvenio>
   {
      public SdtConvenio_RESTInterface( ) : base()
      {
      }

      public SdtConvenio_RESTInterface( SdtConvenio psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ConvenioId" , Order = 0 )]
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

      [DataMember( Name = "ConvenioDescricao" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Conveniodescricao
      {
         get {
            return sdt.gxTpr_Conveniodescricao ;
         }

         set {
            sdt.gxTpr_Conveniodescricao = value;
         }

      }

      [DataMember( Name = "ConvenioStatus" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Conveniostatus
      {
         get {
            return sdt.gxTpr_Conveniostatus ;
         }

         set {
            sdt.gxTpr_Conveniostatus = value;
         }

      }

      public SdtConvenio sdt
      {
         get {
            return (SdtConvenio)Sdt ;
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
            sdt = new SdtConvenio() ;
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

   [DataContract(Name = @"Convenio", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtConvenio_RESTLInterface : GxGenericCollectionItem<SdtConvenio>
   {
      public SdtConvenio_RESTLInterface( ) : base()
      {
      }

      public SdtConvenio_RESTLInterface( SdtConvenio psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ConvenioDescricao" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Conveniodescricao
      {
         get {
            return sdt.gxTpr_Conveniodescricao ;
         }

         set {
            sdt.gxTpr_Conveniodescricao = value;
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

      public SdtConvenio sdt
      {
         get {
            return (SdtConvenio)Sdt ;
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
            sdt = new SdtConvenio() ;
         }
      }

   }

}
