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
   [XmlRoot(ElementName = "CEP" )]
   [XmlType(TypeName =  "CEP" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtCEP : GxSilentTrnSdt
   {
      public SdtCEP( )
      {
      }

      public SdtCEP( IGxContext context )
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

      public void Load( int AV178CEPId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV178CEPId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"CEPId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "CEP");
         metadata.Set("BT", "CEP");
         metadata.Set("PK", "[ \"CEPId\" ]");
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
         state.Add("gxTpr_Cepid_Z");
         state.Add("gxTpr_Cep_Z");
         state.Add("gxTpr_Cep_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtCEP sdt;
         sdt = (SdtCEP)(source);
         gxTv_SdtCEP_Cepid = sdt.gxTv_SdtCEP_Cepid ;
         gxTv_SdtCEP_Cep = sdt.gxTv_SdtCEP_Cep ;
         gxTv_SdtCEP_Mode = sdt.gxTv_SdtCEP_Mode ;
         gxTv_SdtCEP_Initialized = sdt.gxTv_SdtCEP_Initialized ;
         gxTv_SdtCEP_Cepid_Z = sdt.gxTv_SdtCEP_Cepid_Z ;
         gxTv_SdtCEP_Cep_Z = sdt.gxTv_SdtCEP_Cep_Z ;
         gxTv_SdtCEP_Cep_N = sdt.gxTv_SdtCEP_Cep_N ;
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
         AddObjectProperty("CEPId", gxTv_SdtCEP_Cepid, false, includeNonInitialized);
         AddObjectProperty("CEP", gxTv_SdtCEP_Cep, false, includeNonInitialized);
         AddObjectProperty("CEP_N", gxTv_SdtCEP_Cep_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtCEP_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtCEP_Initialized, false, includeNonInitialized);
            AddObjectProperty("CEPId_Z", gxTv_SdtCEP_Cepid_Z, false, includeNonInitialized);
            AddObjectProperty("CEP_Z", gxTv_SdtCEP_Cep_Z, false, includeNonInitialized);
            AddObjectProperty("CEP_N", gxTv_SdtCEP_Cep_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtCEP sdt )
      {
         if ( sdt.IsDirty("CEPId") )
         {
            sdtIsNull = 0;
            gxTv_SdtCEP_Cepid = sdt.gxTv_SdtCEP_Cepid ;
         }
         if ( sdt.IsDirty("CEP") )
         {
            gxTv_SdtCEP_Cep_N = (short)(sdt.gxTv_SdtCEP_Cep_N);
            sdtIsNull = 0;
            gxTv_SdtCEP_Cep = sdt.gxTv_SdtCEP_Cep ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "CEPId" )]
      [  XmlElement( ElementName = "CEPId"   )]
      public int gxTpr_Cepid
      {
         get {
            return gxTv_SdtCEP_Cepid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtCEP_Cepid != value )
            {
               gxTv_SdtCEP_Mode = "INS";
               this.gxTv_SdtCEP_Cepid_Z_SetNull( );
               this.gxTv_SdtCEP_Cep_Z_SetNull( );
            }
            gxTv_SdtCEP_Cepid = value;
            SetDirty("Cepid");
         }

      }

      [  SoapElement( ElementName = "CEP" )]
      [  XmlElement( ElementName = "CEP"   )]
      public string gxTpr_Cep
      {
         get {
            return gxTv_SdtCEP_Cep ;
         }

         set {
            gxTv_SdtCEP_Cep_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCEP_Cep = value;
            SetDirty("Cep");
         }

      }

      public void gxTv_SdtCEP_Cep_SetNull( )
      {
         gxTv_SdtCEP_Cep_N = 1;
         gxTv_SdtCEP_Cep = "";
         SetDirty("Cep");
         return  ;
      }

      public bool gxTv_SdtCEP_Cep_IsNull( )
      {
         return (gxTv_SdtCEP_Cep_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtCEP_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCEP_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtCEP_Mode_SetNull( )
      {
         gxTv_SdtCEP_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtCEP_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtCEP_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCEP_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtCEP_Initialized_SetNull( )
      {
         gxTv_SdtCEP_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtCEP_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CEPId_Z" )]
      [  XmlElement( ElementName = "CEPId_Z"   )]
      public int gxTpr_Cepid_Z
      {
         get {
            return gxTv_SdtCEP_Cepid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCEP_Cepid_Z = value;
            SetDirty("Cepid_Z");
         }

      }

      public void gxTv_SdtCEP_Cepid_Z_SetNull( )
      {
         gxTv_SdtCEP_Cepid_Z = 0;
         SetDirty("Cepid_Z");
         return  ;
      }

      public bool gxTv_SdtCEP_Cepid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CEP_Z" )]
      [  XmlElement( ElementName = "CEP_Z"   )]
      public string gxTpr_Cep_Z
      {
         get {
            return gxTv_SdtCEP_Cep_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCEP_Cep_Z = value;
            SetDirty("Cep_Z");
         }

      }

      public void gxTv_SdtCEP_Cep_Z_SetNull( )
      {
         gxTv_SdtCEP_Cep_Z = "";
         SetDirty("Cep_Z");
         return  ;
      }

      public bool gxTv_SdtCEP_Cep_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CEP_N" )]
      [  XmlElement( ElementName = "CEP_N"   )]
      public short gxTpr_Cep_N
      {
         get {
            return gxTv_SdtCEP_Cep_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCEP_Cep_N = value;
            SetDirty("Cep_N");
         }

      }

      public void gxTv_SdtCEP_Cep_N_SetNull( )
      {
         gxTv_SdtCEP_Cep_N = 0;
         SetDirty("Cep_N");
         return  ;
      }

      public bool gxTv_SdtCEP_Cep_N_IsNull( )
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
         gxTv_SdtCEP_Cep = "";
         gxTv_SdtCEP_Mode = "";
         gxTv_SdtCEP_Cep_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "cep", "GeneXus.Programs.cep_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtCEP_Initialized ;
      private short gxTv_SdtCEP_Cep_N ;
      private int gxTv_SdtCEP_Cepid ;
      private int gxTv_SdtCEP_Cepid_Z ;
      private string gxTv_SdtCEP_Mode ;
      private string gxTv_SdtCEP_Cep ;
      private string gxTv_SdtCEP_Cep_Z ;
   }

   [DataContract(Name = @"CEP", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtCEP_RESTInterface : GxGenericCollectionItem<SdtCEP>
   {
      public SdtCEP_RESTInterface( ) : base()
      {
      }

      public SdtCEP_RESTInterface( SdtCEP psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CEPId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Cepid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Cepid), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Cepid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "CEP" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Cep
      {
         get {
            return sdt.gxTpr_Cep ;
         }

         set {
            sdt.gxTpr_Cep = value;
         }

      }

      public SdtCEP sdt
      {
         get {
            return (SdtCEP)Sdt ;
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
            sdt = new SdtCEP() ;
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

   [DataContract(Name = @"CEP", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtCEP_RESTLInterface : GxGenericCollectionItem<SdtCEP>
   {
      public SdtCEP_RESTLInterface( ) : base()
      {
      }

      public SdtCEP_RESTLInterface( SdtCEP psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CEP" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Cep
      {
         get {
            return sdt.gxTpr_Cep ;
         }

         set {
            sdt.gxTpr_Cep = value;
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

      public SdtCEP sdt
      {
         get {
            return (SdtCEP)Sdt ;
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
            sdt = new SdtCEP() ;
         }
      }

   }

}
