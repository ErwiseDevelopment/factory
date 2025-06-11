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
   [XmlRoot(ElementName = "Banco" )]
   [XmlType(TypeName =  "Banco" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtBanco : GxSilentTrnSdt
   {
      public SdtBanco( )
      {
      }

      public SdtBanco( IGxContext context )
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

      public void Load( int AV402BancoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV402BancoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"BancoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Banco");
         metadata.Set("BT", "Banco");
         metadata.Set("PK", "[ \"BancoId\" ]");
         metadata.Set("PKAssigned", "[ \"BancoId\" ]");
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
         state.Add("gxTpr_Bancoid_Z");
         state.Add("gxTpr_Bancocodigo_Z");
         state.Add("gxTpr_Banconome_Z");
         state.Add("gxTpr_Bancocountagencia_f_Z");
         state.Add("gxTpr_Bancoid_N");
         state.Add("gxTpr_Bancocodigo_N");
         state.Add("gxTpr_Banconome_N");
         state.Add("gxTpr_Bancocountagencia_f_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtBanco sdt;
         sdt = (SdtBanco)(source);
         gxTv_SdtBanco_Bancoid = sdt.gxTv_SdtBanco_Bancoid ;
         gxTv_SdtBanco_Bancocodigo = sdt.gxTv_SdtBanco_Bancocodigo ;
         gxTv_SdtBanco_Banconome = sdt.gxTv_SdtBanco_Banconome ;
         gxTv_SdtBanco_Bancocountagencia_f = sdt.gxTv_SdtBanco_Bancocountagencia_f ;
         gxTv_SdtBanco_Mode = sdt.gxTv_SdtBanco_Mode ;
         gxTv_SdtBanco_Initialized = sdt.gxTv_SdtBanco_Initialized ;
         gxTv_SdtBanco_Bancoid_Z = sdt.gxTv_SdtBanco_Bancoid_Z ;
         gxTv_SdtBanco_Bancocodigo_Z = sdt.gxTv_SdtBanco_Bancocodigo_Z ;
         gxTv_SdtBanco_Banconome_Z = sdt.gxTv_SdtBanco_Banconome_Z ;
         gxTv_SdtBanco_Bancocountagencia_f_Z = sdt.gxTv_SdtBanco_Bancocountagencia_f_Z ;
         gxTv_SdtBanco_Bancoid_N = sdt.gxTv_SdtBanco_Bancoid_N ;
         gxTv_SdtBanco_Bancocodigo_N = sdt.gxTv_SdtBanco_Bancocodigo_N ;
         gxTv_SdtBanco_Banconome_N = sdt.gxTv_SdtBanco_Banconome_N ;
         gxTv_SdtBanco_Bancocountagencia_f_N = sdt.gxTv_SdtBanco_Bancocountagencia_f_N ;
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
         AddObjectProperty("BancoId", gxTv_SdtBanco_Bancoid, false, includeNonInitialized);
         AddObjectProperty("BancoId_N", gxTv_SdtBanco_Bancoid_N, false, includeNonInitialized);
         AddObjectProperty("BancoCodigo", gxTv_SdtBanco_Bancocodigo, false, includeNonInitialized);
         AddObjectProperty("BancoCodigo_N", gxTv_SdtBanco_Bancocodigo_N, false, includeNonInitialized);
         AddObjectProperty("BancoNome", gxTv_SdtBanco_Banconome, false, includeNonInitialized);
         AddObjectProperty("BancoNome_N", gxTv_SdtBanco_Banconome_N, false, includeNonInitialized);
         AddObjectProperty("BancoCountAgencia_F", gxTv_SdtBanco_Bancocountagencia_f, false, includeNonInitialized);
         AddObjectProperty("BancoCountAgencia_F_N", gxTv_SdtBanco_Bancocountagencia_f_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtBanco_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtBanco_Initialized, false, includeNonInitialized);
            AddObjectProperty("BancoId_Z", gxTv_SdtBanco_Bancoid_Z, false, includeNonInitialized);
            AddObjectProperty("BancoCodigo_Z", gxTv_SdtBanco_Bancocodigo_Z, false, includeNonInitialized);
            AddObjectProperty("BancoNome_Z", gxTv_SdtBanco_Banconome_Z, false, includeNonInitialized);
            AddObjectProperty("BancoCountAgencia_F_Z", gxTv_SdtBanco_Bancocountagencia_f_Z, false, includeNonInitialized);
            AddObjectProperty("BancoId_N", gxTv_SdtBanco_Bancoid_N, false, includeNonInitialized);
            AddObjectProperty("BancoCodigo_N", gxTv_SdtBanco_Bancocodigo_N, false, includeNonInitialized);
            AddObjectProperty("BancoNome_N", gxTv_SdtBanco_Banconome_N, false, includeNonInitialized);
            AddObjectProperty("BancoCountAgencia_F_N", gxTv_SdtBanco_Bancocountagencia_f_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtBanco sdt )
      {
         if ( sdt.IsDirty("BancoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtBanco_Bancoid = sdt.gxTv_SdtBanco_Bancoid ;
         }
         if ( sdt.IsDirty("BancoCodigo") )
         {
            gxTv_SdtBanco_Bancocodigo_N = (short)(sdt.gxTv_SdtBanco_Bancocodigo_N);
            sdtIsNull = 0;
            gxTv_SdtBanco_Bancocodigo = sdt.gxTv_SdtBanco_Bancocodigo ;
         }
         if ( sdt.IsDirty("BancoNome") )
         {
            gxTv_SdtBanco_Banconome_N = (short)(sdt.gxTv_SdtBanco_Banconome_N);
            sdtIsNull = 0;
            gxTv_SdtBanco_Banconome = sdt.gxTv_SdtBanco_Banconome ;
         }
         if ( sdt.IsDirty("BancoCountAgencia_F") )
         {
            gxTv_SdtBanco_Bancocountagencia_f_N = (short)(sdt.gxTv_SdtBanco_Bancocountagencia_f_N);
            sdtIsNull = 0;
            gxTv_SdtBanco_Bancocountagencia_f = sdt.gxTv_SdtBanco_Bancocountagencia_f ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "BancoId" )]
      [  XmlElement( ElementName = "BancoId"   )]
      public int gxTpr_Bancoid
      {
         get {
            return gxTv_SdtBanco_Bancoid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtBanco_Bancoid != value )
            {
               gxTv_SdtBanco_Mode = "INS";
               this.gxTv_SdtBanco_Bancoid_Z_SetNull( );
               this.gxTv_SdtBanco_Bancocodigo_Z_SetNull( );
               this.gxTv_SdtBanco_Banconome_Z_SetNull( );
               this.gxTv_SdtBanco_Bancocountagencia_f_Z_SetNull( );
            }
            gxTv_SdtBanco_Bancoid = value;
            SetDirty("Bancoid");
         }

      }

      [  SoapElement( ElementName = "BancoCodigo" )]
      [  XmlElement( ElementName = "BancoCodigo"   )]
      public int gxTpr_Bancocodigo
      {
         get {
            return gxTv_SdtBanco_Bancocodigo ;
         }

         set {
            gxTv_SdtBanco_Bancocodigo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBanco_Bancocodigo = value;
            SetDirty("Bancocodigo");
         }

      }

      public void gxTv_SdtBanco_Bancocodigo_SetNull( )
      {
         gxTv_SdtBanco_Bancocodigo_N = 1;
         gxTv_SdtBanco_Bancocodigo = 0;
         SetDirty("Bancocodigo");
         return  ;
      }

      public bool gxTv_SdtBanco_Bancocodigo_IsNull( )
      {
         return (gxTv_SdtBanco_Bancocodigo_N==1) ;
      }

      [  SoapElement( ElementName = "BancoNome" )]
      [  XmlElement( ElementName = "BancoNome"   )]
      public string gxTpr_Banconome
      {
         get {
            return gxTv_SdtBanco_Banconome ;
         }

         set {
            gxTv_SdtBanco_Banconome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBanco_Banconome = value;
            SetDirty("Banconome");
         }

      }

      public void gxTv_SdtBanco_Banconome_SetNull( )
      {
         gxTv_SdtBanco_Banconome_N = 1;
         gxTv_SdtBanco_Banconome = "";
         SetDirty("Banconome");
         return  ;
      }

      public bool gxTv_SdtBanco_Banconome_IsNull( )
      {
         return (gxTv_SdtBanco_Banconome_N==1) ;
      }

      [  SoapElement( ElementName = "BancoCountAgencia_F" )]
      [  XmlElement( ElementName = "BancoCountAgencia_F"   )]
      public short gxTpr_Bancocountagencia_f
      {
         get {
            return gxTv_SdtBanco_Bancocountagencia_f ;
         }

         set {
            gxTv_SdtBanco_Bancocountagencia_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtBanco_Bancocountagencia_f = value;
            SetDirty("Bancocountagencia_f");
         }

      }

      public void gxTv_SdtBanco_Bancocountagencia_f_SetNull( )
      {
         gxTv_SdtBanco_Bancocountagencia_f_N = 1;
         gxTv_SdtBanco_Bancocountagencia_f = 0;
         SetDirty("Bancocountagencia_f");
         return  ;
      }

      public bool gxTv_SdtBanco_Bancocountagencia_f_IsNull( )
      {
         return (gxTv_SdtBanco_Bancocountagencia_f_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtBanco_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBanco_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtBanco_Mode_SetNull( )
      {
         gxTv_SdtBanco_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtBanco_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtBanco_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBanco_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtBanco_Initialized_SetNull( )
      {
         gxTv_SdtBanco_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtBanco_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BancoId_Z" )]
      [  XmlElement( ElementName = "BancoId_Z"   )]
      public int gxTpr_Bancoid_Z
      {
         get {
            return gxTv_SdtBanco_Bancoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBanco_Bancoid_Z = value;
            SetDirty("Bancoid_Z");
         }

      }

      public void gxTv_SdtBanco_Bancoid_Z_SetNull( )
      {
         gxTv_SdtBanco_Bancoid_Z = 0;
         SetDirty("Bancoid_Z");
         return  ;
      }

      public bool gxTv_SdtBanco_Bancoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BancoCodigo_Z" )]
      [  XmlElement( ElementName = "BancoCodigo_Z"   )]
      public int gxTpr_Bancocodigo_Z
      {
         get {
            return gxTv_SdtBanco_Bancocodigo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBanco_Bancocodigo_Z = value;
            SetDirty("Bancocodigo_Z");
         }

      }

      public void gxTv_SdtBanco_Bancocodigo_Z_SetNull( )
      {
         gxTv_SdtBanco_Bancocodigo_Z = 0;
         SetDirty("Bancocodigo_Z");
         return  ;
      }

      public bool gxTv_SdtBanco_Bancocodigo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BancoNome_Z" )]
      [  XmlElement( ElementName = "BancoNome_Z"   )]
      public string gxTpr_Banconome_Z
      {
         get {
            return gxTv_SdtBanco_Banconome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBanco_Banconome_Z = value;
            SetDirty("Banconome_Z");
         }

      }

      public void gxTv_SdtBanco_Banconome_Z_SetNull( )
      {
         gxTv_SdtBanco_Banconome_Z = "";
         SetDirty("Banconome_Z");
         return  ;
      }

      public bool gxTv_SdtBanco_Banconome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BancoCountAgencia_F_Z" )]
      [  XmlElement( ElementName = "BancoCountAgencia_F_Z"   )]
      public short gxTpr_Bancocountagencia_f_Z
      {
         get {
            return gxTv_SdtBanco_Bancocountagencia_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBanco_Bancocountagencia_f_Z = value;
            SetDirty("Bancocountagencia_f_Z");
         }

      }

      public void gxTv_SdtBanco_Bancocountagencia_f_Z_SetNull( )
      {
         gxTv_SdtBanco_Bancocountagencia_f_Z = 0;
         SetDirty("Bancocountagencia_f_Z");
         return  ;
      }

      public bool gxTv_SdtBanco_Bancocountagencia_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BancoId_N" )]
      [  XmlElement( ElementName = "BancoId_N"   )]
      public short gxTpr_Bancoid_N
      {
         get {
            return gxTv_SdtBanco_Bancoid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBanco_Bancoid_N = value;
            SetDirty("Bancoid_N");
         }

      }

      public void gxTv_SdtBanco_Bancoid_N_SetNull( )
      {
         gxTv_SdtBanco_Bancoid_N = 0;
         SetDirty("Bancoid_N");
         return  ;
      }

      public bool gxTv_SdtBanco_Bancoid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BancoCodigo_N" )]
      [  XmlElement( ElementName = "BancoCodigo_N"   )]
      public short gxTpr_Bancocodigo_N
      {
         get {
            return gxTv_SdtBanco_Bancocodigo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBanco_Bancocodigo_N = value;
            SetDirty("Bancocodigo_N");
         }

      }

      public void gxTv_SdtBanco_Bancocodigo_N_SetNull( )
      {
         gxTv_SdtBanco_Bancocodigo_N = 0;
         SetDirty("Bancocodigo_N");
         return  ;
      }

      public bool gxTv_SdtBanco_Bancocodigo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BancoNome_N" )]
      [  XmlElement( ElementName = "BancoNome_N"   )]
      public short gxTpr_Banconome_N
      {
         get {
            return gxTv_SdtBanco_Banconome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBanco_Banconome_N = value;
            SetDirty("Banconome_N");
         }

      }

      public void gxTv_SdtBanco_Banconome_N_SetNull( )
      {
         gxTv_SdtBanco_Banconome_N = 0;
         SetDirty("Banconome_N");
         return  ;
      }

      public bool gxTv_SdtBanco_Banconome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BancoCountAgencia_F_N" )]
      [  XmlElement( ElementName = "BancoCountAgencia_F_N"   )]
      public short gxTpr_Bancocountagencia_f_N
      {
         get {
            return gxTv_SdtBanco_Bancocountagencia_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtBanco_Bancocountagencia_f_N = value;
            SetDirty("Bancocountagencia_f_N");
         }

      }

      public void gxTv_SdtBanco_Bancocountagencia_f_N_SetNull( )
      {
         gxTv_SdtBanco_Bancocountagencia_f_N = 0;
         SetDirty("Bancocountagencia_f_N");
         return  ;
      }

      public bool gxTv_SdtBanco_Bancocountagencia_f_N_IsNull( )
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
         gxTv_SdtBanco_Banconome = "";
         gxTv_SdtBanco_Mode = "";
         gxTv_SdtBanco_Banconome_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "banco", "GeneXus.Programs.banco_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtBanco_Bancocountagencia_f ;
      private short gxTv_SdtBanco_Initialized ;
      private short gxTv_SdtBanco_Bancocountagencia_f_Z ;
      private short gxTv_SdtBanco_Bancoid_N ;
      private short gxTv_SdtBanco_Bancocodigo_N ;
      private short gxTv_SdtBanco_Banconome_N ;
      private short gxTv_SdtBanco_Bancocountagencia_f_N ;
      private int gxTv_SdtBanco_Bancoid ;
      private int gxTv_SdtBanco_Bancocodigo ;
      private int gxTv_SdtBanco_Bancoid_Z ;
      private int gxTv_SdtBanco_Bancocodigo_Z ;
      private string gxTv_SdtBanco_Mode ;
      private string gxTv_SdtBanco_Banconome ;
      private string gxTv_SdtBanco_Banconome_Z ;
   }

   [DataContract(Name = @"Banco", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtBanco_RESTInterface : GxGenericCollectionItem<SdtBanco>
   {
      public SdtBanco_RESTInterface( ) : base()
      {
      }

      public SdtBanco_RESTInterface( SdtBanco psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "BancoId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Bancoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Bancoid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Bancoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "BancoCodigo" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Bancocodigo
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Bancocodigo), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Bancocodigo = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "BancoNome" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Banconome
      {
         get {
            return sdt.gxTpr_Banconome ;
         }

         set {
            sdt.gxTpr_Banconome = value;
         }

      }

      [DataMember( Name = "BancoCountAgencia_F" , Order = 3 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Bancocountagencia_f
      {
         get {
            return sdt.gxTpr_Bancocountagencia_f ;
         }

         set {
            sdt.gxTpr_Bancocountagencia_f = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtBanco sdt
      {
         get {
            return (SdtBanco)Sdt ;
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
            sdt = new SdtBanco() ;
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

   [DataContract(Name = @"Banco", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtBanco_RESTLInterface : GxGenericCollectionItem<SdtBanco>
   {
      public SdtBanco_RESTLInterface( ) : base()
      {
      }

      public SdtBanco_RESTLInterface( SdtBanco psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "BancoCodigo" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Bancocodigo
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Bancocodigo), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Bancocodigo = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
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

      public SdtBanco sdt
      {
         get {
            return (SdtBanco)Sdt ;
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
            sdt = new SdtBanco() ;
         }
      }

   }

}
