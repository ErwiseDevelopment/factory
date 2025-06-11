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
   [XmlRoot(ElementName = "ClienteNotas" )]
   [XmlType(TypeName =  "ClienteNotas" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtClienteNotas : GxSilentTrnSdt
   {
      public SdtClienteNotas( )
      {
      }

      public SdtClienteNotas( IGxContext context )
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

      public void Load( int AV168ClienteId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV168ClienteId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ClienteId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "ClienteNotas");
         metadata.Set("BT", "Cliente");
         metadata.Set("PK", "[ \"ClienteId\" ]");
         metadata.Set("PKAssigned", "[ \"ClienteId\" ]");
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
         state.Add("gxTpr_Clienteid_Z");
         state.Add("gxTpr_Clientecountnotas_f_Z");
         state.Add("gxTpr_Clienteid_N");
         state.Add("gxTpr_Clientecountnotas_f_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtClienteNotas sdt;
         sdt = (SdtClienteNotas)(source);
         gxTv_SdtClienteNotas_Clienteid = sdt.gxTv_SdtClienteNotas_Clienteid ;
         gxTv_SdtClienteNotas_Clientecountnotas_f = sdt.gxTv_SdtClienteNotas_Clientecountnotas_f ;
         gxTv_SdtClienteNotas_Mode = sdt.gxTv_SdtClienteNotas_Mode ;
         gxTv_SdtClienteNotas_Initialized = sdt.gxTv_SdtClienteNotas_Initialized ;
         gxTv_SdtClienteNotas_Clienteid_Z = sdt.gxTv_SdtClienteNotas_Clienteid_Z ;
         gxTv_SdtClienteNotas_Clientecountnotas_f_Z = sdt.gxTv_SdtClienteNotas_Clientecountnotas_f_Z ;
         gxTv_SdtClienteNotas_Clienteid_N = sdt.gxTv_SdtClienteNotas_Clienteid_N ;
         gxTv_SdtClienteNotas_Clientecountnotas_f_N = sdt.gxTv_SdtClienteNotas_Clientecountnotas_f_N ;
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
         AddObjectProperty("ClienteId", gxTv_SdtClienteNotas_Clienteid, false, includeNonInitialized);
         AddObjectProperty("ClienteId_N", gxTv_SdtClienteNotas_Clienteid_N, false, includeNonInitialized);
         AddObjectProperty("ClienteCountNotas_F", gxTv_SdtClienteNotas_Clientecountnotas_f, false, includeNonInitialized);
         AddObjectProperty("ClienteCountNotas_F_N", gxTv_SdtClienteNotas_Clientecountnotas_f_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtClienteNotas_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtClienteNotas_Initialized, false, includeNonInitialized);
            AddObjectProperty("ClienteId_Z", gxTv_SdtClienteNotas_Clienteid_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteCountNotas_F_Z", gxTv_SdtClienteNotas_Clientecountnotas_f_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteId_N", gxTv_SdtClienteNotas_Clienteid_N, false, includeNonInitialized);
            AddObjectProperty("ClienteCountNotas_F_N", gxTv_SdtClienteNotas_Clientecountnotas_f_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtClienteNotas sdt )
      {
         if ( sdt.IsDirty("ClienteId") )
         {
            sdtIsNull = 0;
            gxTv_SdtClienteNotas_Clienteid = sdt.gxTv_SdtClienteNotas_Clienteid ;
         }
         if ( sdt.IsDirty("ClienteCountNotas_F") )
         {
            gxTv_SdtClienteNotas_Clientecountnotas_f_N = (short)(sdt.gxTv_SdtClienteNotas_Clientecountnotas_f_N);
            sdtIsNull = 0;
            gxTv_SdtClienteNotas_Clientecountnotas_f = sdt.gxTv_SdtClienteNotas_Clientecountnotas_f ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ClienteId" )]
      [  XmlElement( ElementName = "ClienteId"   )]
      public int gxTpr_Clienteid
      {
         get {
            return gxTv_SdtClienteNotas_Clienteid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtClienteNotas_Clienteid != value )
            {
               gxTv_SdtClienteNotas_Mode = "INS";
               this.gxTv_SdtClienteNotas_Clienteid_Z_SetNull( );
               this.gxTv_SdtClienteNotas_Clientecountnotas_f_Z_SetNull( );
            }
            gxTv_SdtClienteNotas_Clienteid = value;
            SetDirty("Clienteid");
         }

      }

      [  SoapElement( ElementName = "ClienteCountNotas_F" )]
      [  XmlElement( ElementName = "ClienteCountNotas_F"   )]
      public short gxTpr_Clientecountnotas_f
      {
         get {
            return gxTv_SdtClienteNotas_Clientecountnotas_f ;
         }

         set {
            gxTv_SdtClienteNotas_Clientecountnotas_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtClienteNotas_Clientecountnotas_f = value;
            SetDirty("Clientecountnotas_f");
         }

      }

      public void gxTv_SdtClienteNotas_Clientecountnotas_f_SetNull( )
      {
         gxTv_SdtClienteNotas_Clientecountnotas_f_N = 1;
         gxTv_SdtClienteNotas_Clientecountnotas_f = 0;
         SetDirty("Clientecountnotas_f");
         return  ;
      }

      public bool gxTv_SdtClienteNotas_Clientecountnotas_f_IsNull( )
      {
         return (gxTv_SdtClienteNotas_Clientecountnotas_f_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtClienteNotas_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteNotas_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtClienteNotas_Mode_SetNull( )
      {
         gxTv_SdtClienteNotas_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtClienteNotas_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtClienteNotas_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteNotas_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtClienteNotas_Initialized_SetNull( )
      {
         gxTv_SdtClienteNotas_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtClienteNotas_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteId_Z" )]
      [  XmlElement( ElementName = "ClienteId_Z"   )]
      public int gxTpr_Clienteid_Z
      {
         get {
            return gxTv_SdtClienteNotas_Clienteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteNotas_Clienteid_Z = value;
            SetDirty("Clienteid_Z");
         }

      }

      public void gxTv_SdtClienteNotas_Clienteid_Z_SetNull( )
      {
         gxTv_SdtClienteNotas_Clienteid_Z = 0;
         SetDirty("Clienteid_Z");
         return  ;
      }

      public bool gxTv_SdtClienteNotas_Clienteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteCountNotas_F_Z" )]
      [  XmlElement( ElementName = "ClienteCountNotas_F_Z"   )]
      public short gxTpr_Clientecountnotas_f_Z
      {
         get {
            return gxTv_SdtClienteNotas_Clientecountnotas_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteNotas_Clientecountnotas_f_Z = value;
            SetDirty("Clientecountnotas_f_Z");
         }

      }

      public void gxTv_SdtClienteNotas_Clientecountnotas_f_Z_SetNull( )
      {
         gxTv_SdtClienteNotas_Clientecountnotas_f_Z = 0;
         SetDirty("Clientecountnotas_f_Z");
         return  ;
      }

      public bool gxTv_SdtClienteNotas_Clientecountnotas_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteId_N" )]
      [  XmlElement( ElementName = "ClienteId_N"   )]
      public short gxTpr_Clienteid_N
      {
         get {
            return gxTv_SdtClienteNotas_Clienteid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteNotas_Clienteid_N = value;
            SetDirty("Clienteid_N");
         }

      }

      public void gxTv_SdtClienteNotas_Clienteid_N_SetNull( )
      {
         gxTv_SdtClienteNotas_Clienteid_N = 0;
         SetDirty("Clienteid_N");
         return  ;
      }

      public bool gxTv_SdtClienteNotas_Clienteid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteCountNotas_F_N" )]
      [  XmlElement( ElementName = "ClienteCountNotas_F_N"   )]
      public short gxTpr_Clientecountnotas_f_N
      {
         get {
            return gxTv_SdtClienteNotas_Clientecountnotas_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteNotas_Clientecountnotas_f_N = value;
            SetDirty("Clientecountnotas_f_N");
         }

      }

      public void gxTv_SdtClienteNotas_Clientecountnotas_f_N_SetNull( )
      {
         gxTv_SdtClienteNotas_Clientecountnotas_f_N = 0;
         SetDirty("Clientecountnotas_f_N");
         return  ;
      }

      public bool gxTv_SdtClienteNotas_Clientecountnotas_f_N_IsNull( )
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
         gxTv_SdtClienteNotas_Mode = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "clientenotas", "GeneXus.Programs.clientenotas_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtClienteNotas_Clientecountnotas_f ;
      private short gxTv_SdtClienteNotas_Initialized ;
      private short gxTv_SdtClienteNotas_Clientecountnotas_f_Z ;
      private short gxTv_SdtClienteNotas_Clienteid_N ;
      private short gxTv_SdtClienteNotas_Clientecountnotas_f_N ;
      private int gxTv_SdtClienteNotas_Clienteid ;
      private int gxTv_SdtClienteNotas_Clienteid_Z ;
      private string gxTv_SdtClienteNotas_Mode ;
   }

   [DataContract(Name = @"ClienteNotas", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtClienteNotas_RESTInterface : GxGenericCollectionItem<SdtClienteNotas>
   {
      public SdtClienteNotas_RESTInterface( ) : base()
      {
      }

      public SdtClienteNotas_RESTInterface( SdtClienteNotas psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ClienteId" , Order = 0 )]
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

      [DataMember( Name = "ClienteCountNotas_F" , Order = 1 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Clientecountnotas_f
      {
         get {
            return sdt.gxTpr_Clientecountnotas_f ;
         }

         set {
            sdt.gxTpr_Clientecountnotas_f = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtClienteNotas sdt
      {
         get {
            return (SdtClienteNotas)Sdt ;
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
            sdt = new SdtClienteNotas() ;
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

   [DataContract(Name = @"ClienteNotas", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtClienteNotas_RESTLInterface : GxGenericCollectionItem<SdtClienteNotas>
   {
      public SdtClienteNotas_RESTLInterface( ) : base()
      {
      }

      public SdtClienteNotas_RESTLInterface( SdtClienteNotas psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ClienteCountNotas_F" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Clientecountnotas_f
      {
         get {
            return sdt.gxTpr_Clientecountnotas_f ;
         }

         set {
            sdt.gxTpr_Clientecountnotas_f = (short)(value.HasValue ? value.Value : 0);
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

      public SdtClienteNotas sdt
      {
         get {
            return (SdtClienteNotas)Sdt ;
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
            sdt = new SdtClienteNotas() ;
         }
      }

   }

}
