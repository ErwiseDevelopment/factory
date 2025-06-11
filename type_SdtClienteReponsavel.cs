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
   [XmlRoot(ElementName = "ClienteReponsavel" )]
   [XmlType(TypeName =  "ClienteReponsavel" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtClienteReponsavel : GxSilentTrnSdt
   {
      public SdtClienteReponsavel( )
      {
      }

      public SdtClienteReponsavel( IGxContext context )
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

      public void Load( int AV551ClienteReponsavelId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV551ClienteReponsavelId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ClienteReponsavelId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "ClienteReponsavel");
         metadata.Set("BT", "ClienteReponsavel");
         metadata.Set("PK", "[ \"ClienteReponsavelId\" ]");
         metadata.Set("PKAssigned", "[ \"ClienteReponsavelId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ClienteId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ClienteId\" ],\"FKMap\":[ \"ReponsavelClienteId-ClienteId\" ] } ]");
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
         state.Add("gxTpr_Clientereponsavelid_Z");
         state.Add("gxTpr_Reponsavelclienteid_Z");
         state.Add("gxTpr_Clienteid_Z");
         state.Add("gxTpr_Reponsavelclienteid_N");
         state.Add("gxTpr_Clienteid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtClienteReponsavel sdt;
         sdt = (SdtClienteReponsavel)(source);
         gxTv_SdtClienteReponsavel_Clientereponsavelid = sdt.gxTv_SdtClienteReponsavel_Clientereponsavelid ;
         gxTv_SdtClienteReponsavel_Reponsavelclienteid = sdt.gxTv_SdtClienteReponsavel_Reponsavelclienteid ;
         gxTv_SdtClienteReponsavel_Clienteid = sdt.gxTv_SdtClienteReponsavel_Clienteid ;
         gxTv_SdtClienteReponsavel_Mode = sdt.gxTv_SdtClienteReponsavel_Mode ;
         gxTv_SdtClienteReponsavel_Initialized = sdt.gxTv_SdtClienteReponsavel_Initialized ;
         gxTv_SdtClienteReponsavel_Clientereponsavelid_Z = sdt.gxTv_SdtClienteReponsavel_Clientereponsavelid_Z ;
         gxTv_SdtClienteReponsavel_Reponsavelclienteid_Z = sdt.gxTv_SdtClienteReponsavel_Reponsavelclienteid_Z ;
         gxTv_SdtClienteReponsavel_Clienteid_Z = sdt.gxTv_SdtClienteReponsavel_Clienteid_Z ;
         gxTv_SdtClienteReponsavel_Reponsavelclienteid_N = sdt.gxTv_SdtClienteReponsavel_Reponsavelclienteid_N ;
         gxTv_SdtClienteReponsavel_Clienteid_N = sdt.gxTv_SdtClienteReponsavel_Clienteid_N ;
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
         AddObjectProperty("ClienteReponsavelId", gxTv_SdtClienteReponsavel_Clientereponsavelid, false, includeNonInitialized);
         AddObjectProperty("ReponsavelClienteId", gxTv_SdtClienteReponsavel_Reponsavelclienteid, false, includeNonInitialized);
         AddObjectProperty("ReponsavelClienteId_N", gxTv_SdtClienteReponsavel_Reponsavelclienteid_N, false, includeNonInitialized);
         AddObjectProperty("ClienteId", gxTv_SdtClienteReponsavel_Clienteid, false, includeNonInitialized);
         AddObjectProperty("ClienteId_N", gxTv_SdtClienteReponsavel_Clienteid_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtClienteReponsavel_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtClienteReponsavel_Initialized, false, includeNonInitialized);
            AddObjectProperty("ClienteReponsavelId_Z", gxTv_SdtClienteReponsavel_Clientereponsavelid_Z, false, includeNonInitialized);
            AddObjectProperty("ReponsavelClienteId_Z", gxTv_SdtClienteReponsavel_Reponsavelclienteid_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteId_Z", gxTv_SdtClienteReponsavel_Clienteid_Z, false, includeNonInitialized);
            AddObjectProperty("ReponsavelClienteId_N", gxTv_SdtClienteReponsavel_Reponsavelclienteid_N, false, includeNonInitialized);
            AddObjectProperty("ClienteId_N", gxTv_SdtClienteReponsavel_Clienteid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtClienteReponsavel sdt )
      {
         if ( sdt.IsDirty("ClienteReponsavelId") )
         {
            sdtIsNull = 0;
            gxTv_SdtClienteReponsavel_Clientereponsavelid = sdt.gxTv_SdtClienteReponsavel_Clientereponsavelid ;
         }
         if ( sdt.IsDirty("ReponsavelClienteId") )
         {
            gxTv_SdtClienteReponsavel_Reponsavelclienteid_N = (short)(sdt.gxTv_SdtClienteReponsavel_Reponsavelclienteid_N);
            sdtIsNull = 0;
            gxTv_SdtClienteReponsavel_Reponsavelclienteid = sdt.gxTv_SdtClienteReponsavel_Reponsavelclienteid ;
         }
         if ( sdt.IsDirty("ClienteId") )
         {
            gxTv_SdtClienteReponsavel_Clienteid_N = (short)(sdt.gxTv_SdtClienteReponsavel_Clienteid_N);
            sdtIsNull = 0;
            gxTv_SdtClienteReponsavel_Clienteid = sdt.gxTv_SdtClienteReponsavel_Clienteid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ClienteReponsavelId" )]
      [  XmlElement( ElementName = "ClienteReponsavelId"   )]
      public int gxTpr_Clientereponsavelid
      {
         get {
            return gxTv_SdtClienteReponsavel_Clientereponsavelid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtClienteReponsavel_Clientereponsavelid != value )
            {
               gxTv_SdtClienteReponsavel_Mode = "INS";
               this.gxTv_SdtClienteReponsavel_Clientereponsavelid_Z_SetNull( );
               this.gxTv_SdtClienteReponsavel_Reponsavelclienteid_Z_SetNull( );
               this.gxTv_SdtClienteReponsavel_Clienteid_Z_SetNull( );
            }
            gxTv_SdtClienteReponsavel_Clientereponsavelid = value;
            SetDirty("Clientereponsavelid");
         }

      }

      [  SoapElement( ElementName = "ReponsavelClienteId" )]
      [  XmlElement( ElementName = "ReponsavelClienteId"   )]
      public int gxTpr_Reponsavelclienteid
      {
         get {
            return gxTv_SdtClienteReponsavel_Reponsavelclienteid ;
         }

         set {
            gxTv_SdtClienteReponsavel_Reponsavelclienteid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtClienteReponsavel_Reponsavelclienteid = value;
            SetDirty("Reponsavelclienteid");
         }

      }

      public void gxTv_SdtClienteReponsavel_Reponsavelclienteid_SetNull( )
      {
         gxTv_SdtClienteReponsavel_Reponsavelclienteid_N = 1;
         gxTv_SdtClienteReponsavel_Reponsavelclienteid = 0;
         SetDirty("Reponsavelclienteid");
         return  ;
      }

      public bool gxTv_SdtClienteReponsavel_Reponsavelclienteid_IsNull( )
      {
         return (gxTv_SdtClienteReponsavel_Reponsavelclienteid_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteId" )]
      [  XmlElement( ElementName = "ClienteId"   )]
      public int gxTpr_Clienteid
      {
         get {
            return gxTv_SdtClienteReponsavel_Clienteid ;
         }

         set {
            gxTv_SdtClienteReponsavel_Clienteid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtClienteReponsavel_Clienteid = value;
            SetDirty("Clienteid");
         }

      }

      public void gxTv_SdtClienteReponsavel_Clienteid_SetNull( )
      {
         gxTv_SdtClienteReponsavel_Clienteid_N = 1;
         gxTv_SdtClienteReponsavel_Clienteid = 0;
         SetDirty("Clienteid");
         return  ;
      }

      public bool gxTv_SdtClienteReponsavel_Clienteid_IsNull( )
      {
         return (gxTv_SdtClienteReponsavel_Clienteid_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtClienteReponsavel_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteReponsavel_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtClienteReponsavel_Mode_SetNull( )
      {
         gxTv_SdtClienteReponsavel_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtClienteReponsavel_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtClienteReponsavel_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteReponsavel_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtClienteReponsavel_Initialized_SetNull( )
      {
         gxTv_SdtClienteReponsavel_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtClienteReponsavel_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteReponsavelId_Z" )]
      [  XmlElement( ElementName = "ClienteReponsavelId_Z"   )]
      public int gxTpr_Clientereponsavelid_Z
      {
         get {
            return gxTv_SdtClienteReponsavel_Clientereponsavelid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteReponsavel_Clientereponsavelid_Z = value;
            SetDirty("Clientereponsavelid_Z");
         }

      }

      public void gxTv_SdtClienteReponsavel_Clientereponsavelid_Z_SetNull( )
      {
         gxTv_SdtClienteReponsavel_Clientereponsavelid_Z = 0;
         SetDirty("Clientereponsavelid_Z");
         return  ;
      }

      public bool gxTv_SdtClienteReponsavel_Clientereponsavelid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReponsavelClienteId_Z" )]
      [  XmlElement( ElementName = "ReponsavelClienteId_Z"   )]
      public int gxTpr_Reponsavelclienteid_Z
      {
         get {
            return gxTv_SdtClienteReponsavel_Reponsavelclienteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteReponsavel_Reponsavelclienteid_Z = value;
            SetDirty("Reponsavelclienteid_Z");
         }

      }

      public void gxTv_SdtClienteReponsavel_Reponsavelclienteid_Z_SetNull( )
      {
         gxTv_SdtClienteReponsavel_Reponsavelclienteid_Z = 0;
         SetDirty("Reponsavelclienteid_Z");
         return  ;
      }

      public bool gxTv_SdtClienteReponsavel_Reponsavelclienteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteId_Z" )]
      [  XmlElement( ElementName = "ClienteId_Z"   )]
      public int gxTpr_Clienteid_Z
      {
         get {
            return gxTv_SdtClienteReponsavel_Clienteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteReponsavel_Clienteid_Z = value;
            SetDirty("Clienteid_Z");
         }

      }

      public void gxTv_SdtClienteReponsavel_Clienteid_Z_SetNull( )
      {
         gxTv_SdtClienteReponsavel_Clienteid_Z = 0;
         SetDirty("Clienteid_Z");
         return  ;
      }

      public bool gxTv_SdtClienteReponsavel_Clienteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReponsavelClienteId_N" )]
      [  XmlElement( ElementName = "ReponsavelClienteId_N"   )]
      public short gxTpr_Reponsavelclienteid_N
      {
         get {
            return gxTv_SdtClienteReponsavel_Reponsavelclienteid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteReponsavel_Reponsavelclienteid_N = value;
            SetDirty("Reponsavelclienteid_N");
         }

      }

      public void gxTv_SdtClienteReponsavel_Reponsavelclienteid_N_SetNull( )
      {
         gxTv_SdtClienteReponsavel_Reponsavelclienteid_N = 0;
         SetDirty("Reponsavelclienteid_N");
         return  ;
      }

      public bool gxTv_SdtClienteReponsavel_Reponsavelclienteid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteId_N" )]
      [  XmlElement( ElementName = "ClienteId_N"   )]
      public short gxTpr_Clienteid_N
      {
         get {
            return gxTv_SdtClienteReponsavel_Clienteid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteReponsavel_Clienteid_N = value;
            SetDirty("Clienteid_N");
         }

      }

      public void gxTv_SdtClienteReponsavel_Clienteid_N_SetNull( )
      {
         gxTv_SdtClienteReponsavel_Clienteid_N = 0;
         SetDirty("Clienteid_N");
         return  ;
      }

      public bool gxTv_SdtClienteReponsavel_Clienteid_N_IsNull( )
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
         gxTv_SdtClienteReponsavel_Mode = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "clientereponsavel", "GeneXus.Programs.clientereponsavel_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtClienteReponsavel_Initialized ;
      private short gxTv_SdtClienteReponsavel_Reponsavelclienteid_N ;
      private short gxTv_SdtClienteReponsavel_Clienteid_N ;
      private int gxTv_SdtClienteReponsavel_Clientereponsavelid ;
      private int gxTv_SdtClienteReponsavel_Reponsavelclienteid ;
      private int gxTv_SdtClienteReponsavel_Clienteid ;
      private int gxTv_SdtClienteReponsavel_Clientereponsavelid_Z ;
      private int gxTv_SdtClienteReponsavel_Reponsavelclienteid_Z ;
      private int gxTv_SdtClienteReponsavel_Clienteid_Z ;
      private string gxTv_SdtClienteReponsavel_Mode ;
   }

   [DataContract(Name = @"ClienteReponsavel", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtClienteReponsavel_RESTInterface : GxGenericCollectionItem<SdtClienteReponsavel>
   {
      public SdtClienteReponsavel_RESTInterface( ) : base()
      {
      }

      public SdtClienteReponsavel_RESTInterface( SdtClienteReponsavel psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ClienteReponsavelId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Clientereponsavelid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Clientereponsavelid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Clientereponsavelid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ReponsavelClienteId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Reponsavelclienteid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Reponsavelclienteid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Reponsavelclienteid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ClienteId" , Order = 2 )]
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

      public SdtClienteReponsavel sdt
      {
         get {
            return (SdtClienteReponsavel)Sdt ;
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
            sdt = new SdtClienteReponsavel() ;
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

   [DataContract(Name = @"ClienteReponsavel", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtClienteReponsavel_RESTLInterface : GxGenericCollectionItem<SdtClienteReponsavel>
   {
      public SdtClienteReponsavel_RESTLInterface( ) : base()
      {
      }

      public SdtClienteReponsavel_RESTLInterface( SdtClienteReponsavel psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ClienteReponsavelId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Clientereponsavelid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Clientereponsavelid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Clientereponsavelid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "uri" , Order = 1 )]
      public string Uri
      {
         get {
            string gxuri = "/rest/ClienteReponsavel/{0}";
            gxuri = String.Format(gxuri,gxTpr_Clientereponsavelid) ;
            return gxuri ;
         }

         set {
         }

      }

      public SdtClienteReponsavel sdt
      {
         get {
            return (SdtClienteReponsavel)Sdt ;
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
            sdt = new SdtClienteReponsavel() ;
         }
      }

      private string gxuri ;
   }

}
