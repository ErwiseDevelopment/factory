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
   [XmlRoot(ElementName = "LimiteAprovacao" )]
   [XmlType(TypeName =  "LimiteAprovacao" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtLimiteAprovacao : GxSilentTrnSdt
   {
      public SdtLimiteAprovacao( )
      {
      }

      public SdtLimiteAprovacao( IGxContext context )
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

      public void Load( int AV331LimiteAprovacaoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV331LimiteAprovacaoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"LimiteAprovacaoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "LimiteAprovacao");
         metadata.Set("BT", "LimiteAprovacao");
         metadata.Set("PK", "[ \"LimiteAprovacaoId\" ]");
         metadata.Set("PKAssigned", "[ \"LimiteAprovacaoId\" ]");
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
         state.Add("gxTpr_Limiteaprovacaoid_Z");
         state.Add("gxTpr_Limiteaprovacaovalorminimo_Z");
         state.Add("gxTpr_Limiteaprovacaoaprovacoes_Z");
         state.Add("gxTpr_Limiteaprovacaoreprovacoespermitidas_Z");
         state.Add("gxTpr_Limiteaprovacaovalorminimo_N");
         state.Add("gxTpr_Limiteaprovacaoaprovacoes_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtLimiteAprovacao sdt;
         sdt = (SdtLimiteAprovacao)(source);
         gxTv_SdtLimiteAprovacao_Limiteaprovacaoid = sdt.gxTv_SdtLimiteAprovacao_Limiteaprovacaoid ;
         gxTv_SdtLimiteAprovacao_Limiteaprovacaovalorminimo = sdt.gxTv_SdtLimiteAprovacao_Limiteaprovacaovalorminimo ;
         gxTv_SdtLimiteAprovacao_Limiteaprovacaoaprovacoes = sdt.gxTv_SdtLimiteAprovacao_Limiteaprovacaoaprovacoes ;
         gxTv_SdtLimiteAprovacao_Limiteaprovacaoreprovacoespermitidas = sdt.gxTv_SdtLimiteAprovacao_Limiteaprovacaoreprovacoespermitidas ;
         gxTv_SdtLimiteAprovacao_Mode = sdt.gxTv_SdtLimiteAprovacao_Mode ;
         gxTv_SdtLimiteAprovacao_Initialized = sdt.gxTv_SdtLimiteAprovacao_Initialized ;
         gxTv_SdtLimiteAprovacao_Limiteaprovacaoid_Z = sdt.gxTv_SdtLimiteAprovacao_Limiteaprovacaoid_Z ;
         gxTv_SdtLimiteAprovacao_Limiteaprovacaovalorminimo_Z = sdt.gxTv_SdtLimiteAprovacao_Limiteaprovacaovalorminimo_Z ;
         gxTv_SdtLimiteAprovacao_Limiteaprovacaoaprovacoes_Z = sdt.gxTv_SdtLimiteAprovacao_Limiteaprovacaoaprovacoes_Z ;
         gxTv_SdtLimiteAprovacao_Limiteaprovacaoreprovacoespermitidas_Z = sdt.gxTv_SdtLimiteAprovacao_Limiteaprovacaoreprovacoespermitidas_Z ;
         gxTv_SdtLimiteAprovacao_Limiteaprovacaovalorminimo_N = sdt.gxTv_SdtLimiteAprovacao_Limiteaprovacaovalorminimo_N ;
         gxTv_SdtLimiteAprovacao_Limiteaprovacaoaprovacoes_N = sdt.gxTv_SdtLimiteAprovacao_Limiteaprovacaoaprovacoes_N ;
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
         AddObjectProperty("LimiteAprovacaoId", gxTv_SdtLimiteAprovacao_Limiteaprovacaoid, false, includeNonInitialized);
         AddObjectProperty("LimiteAprovacaoValorMinimo", StringUtil.LTrim( StringUtil.Str( gxTv_SdtLimiteAprovacao_Limiteaprovacaovalorminimo, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("LimiteAprovacaoValorMinimo_N", gxTv_SdtLimiteAprovacao_Limiteaprovacaovalorminimo_N, false, includeNonInitialized);
         AddObjectProperty("LimiteAprovacaoAprovacoes", gxTv_SdtLimiteAprovacao_Limiteaprovacaoaprovacoes, false, includeNonInitialized);
         AddObjectProperty("LimiteAprovacaoAprovacoes_N", gxTv_SdtLimiteAprovacao_Limiteaprovacaoaprovacoes_N, false, includeNonInitialized);
         AddObjectProperty("LimiteAprovacaoReprovacoesPermitidas", gxTv_SdtLimiteAprovacao_Limiteaprovacaoreprovacoespermitidas, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtLimiteAprovacao_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtLimiteAprovacao_Initialized, false, includeNonInitialized);
            AddObjectProperty("LimiteAprovacaoId_Z", gxTv_SdtLimiteAprovacao_Limiteaprovacaoid_Z, false, includeNonInitialized);
            AddObjectProperty("LimiteAprovacaoValorMinimo_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtLimiteAprovacao_Limiteaprovacaovalorminimo_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("LimiteAprovacaoAprovacoes_Z", gxTv_SdtLimiteAprovacao_Limiteaprovacaoaprovacoes_Z, false, includeNonInitialized);
            AddObjectProperty("LimiteAprovacaoReprovacoesPermitidas_Z", gxTv_SdtLimiteAprovacao_Limiteaprovacaoreprovacoespermitidas_Z, false, includeNonInitialized);
            AddObjectProperty("LimiteAprovacaoValorMinimo_N", gxTv_SdtLimiteAprovacao_Limiteaprovacaovalorminimo_N, false, includeNonInitialized);
            AddObjectProperty("LimiteAprovacaoAprovacoes_N", gxTv_SdtLimiteAprovacao_Limiteaprovacaoaprovacoes_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtLimiteAprovacao sdt )
      {
         if ( sdt.IsDirty("LimiteAprovacaoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtLimiteAprovacao_Limiteaprovacaoid = sdt.gxTv_SdtLimiteAprovacao_Limiteaprovacaoid ;
         }
         if ( sdt.IsDirty("LimiteAprovacaoValorMinimo") )
         {
            gxTv_SdtLimiteAprovacao_Limiteaprovacaovalorminimo_N = (short)(sdt.gxTv_SdtLimiteAprovacao_Limiteaprovacaovalorminimo_N);
            sdtIsNull = 0;
            gxTv_SdtLimiteAprovacao_Limiteaprovacaovalorminimo = sdt.gxTv_SdtLimiteAprovacao_Limiteaprovacaovalorminimo ;
         }
         if ( sdt.IsDirty("LimiteAprovacaoAprovacoes") )
         {
            gxTv_SdtLimiteAprovacao_Limiteaprovacaoaprovacoes_N = (short)(sdt.gxTv_SdtLimiteAprovacao_Limiteaprovacaoaprovacoes_N);
            sdtIsNull = 0;
            gxTv_SdtLimiteAprovacao_Limiteaprovacaoaprovacoes = sdt.gxTv_SdtLimiteAprovacao_Limiteaprovacaoaprovacoes ;
         }
         if ( sdt.IsDirty("LimiteAprovacaoReprovacoesPermitidas") )
         {
            sdtIsNull = 0;
            gxTv_SdtLimiteAprovacao_Limiteaprovacaoreprovacoespermitidas = sdt.gxTv_SdtLimiteAprovacao_Limiteaprovacaoreprovacoespermitidas ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "LimiteAprovacaoId" )]
      [  XmlElement( ElementName = "LimiteAprovacaoId"   )]
      public int gxTpr_Limiteaprovacaoid
      {
         get {
            return gxTv_SdtLimiteAprovacao_Limiteaprovacaoid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtLimiteAprovacao_Limiteaprovacaoid != value )
            {
               gxTv_SdtLimiteAprovacao_Mode = "INS";
               this.gxTv_SdtLimiteAprovacao_Limiteaprovacaoid_Z_SetNull( );
               this.gxTv_SdtLimiteAprovacao_Limiteaprovacaovalorminimo_Z_SetNull( );
               this.gxTv_SdtLimiteAprovacao_Limiteaprovacaoaprovacoes_Z_SetNull( );
               this.gxTv_SdtLimiteAprovacao_Limiteaprovacaoreprovacoespermitidas_Z_SetNull( );
            }
            gxTv_SdtLimiteAprovacao_Limiteaprovacaoid = value;
            SetDirty("Limiteaprovacaoid");
         }

      }

      [  SoapElement( ElementName = "LimiteAprovacaoValorMinimo" )]
      [  XmlElement( ElementName = "LimiteAprovacaoValorMinimo"   )]
      public decimal gxTpr_Limiteaprovacaovalorminimo
      {
         get {
            return gxTv_SdtLimiteAprovacao_Limiteaprovacaovalorminimo ;
         }

         set {
            gxTv_SdtLimiteAprovacao_Limiteaprovacaovalorminimo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtLimiteAprovacao_Limiteaprovacaovalorminimo = value;
            SetDirty("Limiteaprovacaovalorminimo");
         }

      }

      public void gxTv_SdtLimiteAprovacao_Limiteaprovacaovalorminimo_SetNull( )
      {
         gxTv_SdtLimiteAprovacao_Limiteaprovacaovalorminimo_N = 1;
         gxTv_SdtLimiteAprovacao_Limiteaprovacaovalorminimo = 0;
         SetDirty("Limiteaprovacaovalorminimo");
         return  ;
      }

      public bool gxTv_SdtLimiteAprovacao_Limiteaprovacaovalorminimo_IsNull( )
      {
         return (gxTv_SdtLimiteAprovacao_Limiteaprovacaovalorminimo_N==1) ;
      }

      [  SoapElement( ElementName = "LimiteAprovacaoAprovacoes" )]
      [  XmlElement( ElementName = "LimiteAprovacaoAprovacoes"   )]
      public short gxTpr_Limiteaprovacaoaprovacoes
      {
         get {
            return gxTv_SdtLimiteAprovacao_Limiteaprovacaoaprovacoes ;
         }

         set {
            gxTv_SdtLimiteAprovacao_Limiteaprovacaoaprovacoes_N = 0;
            sdtIsNull = 0;
            gxTv_SdtLimiteAprovacao_Limiteaprovacaoaprovacoes = value;
            SetDirty("Limiteaprovacaoaprovacoes");
         }

      }

      public void gxTv_SdtLimiteAprovacao_Limiteaprovacaoaprovacoes_SetNull( )
      {
         gxTv_SdtLimiteAprovacao_Limiteaprovacaoaprovacoes_N = 1;
         gxTv_SdtLimiteAprovacao_Limiteaprovacaoaprovacoes = 0;
         SetDirty("Limiteaprovacaoaprovacoes");
         return  ;
      }

      public bool gxTv_SdtLimiteAprovacao_Limiteaprovacaoaprovacoes_IsNull( )
      {
         return (gxTv_SdtLimiteAprovacao_Limiteaprovacaoaprovacoes_N==1) ;
      }

      [  SoapElement( ElementName = "LimiteAprovacaoReprovacoesPermitidas" )]
      [  XmlElement( ElementName = "LimiteAprovacaoReprovacoesPermitidas"   )]
      public short gxTpr_Limiteaprovacaoreprovacoespermitidas
      {
         get {
            return gxTv_SdtLimiteAprovacao_Limiteaprovacaoreprovacoespermitidas ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLimiteAprovacao_Limiteaprovacaoreprovacoespermitidas = value;
            SetDirty("Limiteaprovacaoreprovacoespermitidas");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtLimiteAprovacao_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLimiteAprovacao_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtLimiteAprovacao_Mode_SetNull( )
      {
         gxTv_SdtLimiteAprovacao_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtLimiteAprovacao_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtLimiteAprovacao_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLimiteAprovacao_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtLimiteAprovacao_Initialized_SetNull( )
      {
         gxTv_SdtLimiteAprovacao_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtLimiteAprovacao_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LimiteAprovacaoId_Z" )]
      [  XmlElement( ElementName = "LimiteAprovacaoId_Z"   )]
      public int gxTpr_Limiteaprovacaoid_Z
      {
         get {
            return gxTv_SdtLimiteAprovacao_Limiteaprovacaoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLimiteAprovacao_Limiteaprovacaoid_Z = value;
            SetDirty("Limiteaprovacaoid_Z");
         }

      }

      public void gxTv_SdtLimiteAprovacao_Limiteaprovacaoid_Z_SetNull( )
      {
         gxTv_SdtLimiteAprovacao_Limiteaprovacaoid_Z = 0;
         SetDirty("Limiteaprovacaoid_Z");
         return  ;
      }

      public bool gxTv_SdtLimiteAprovacao_Limiteaprovacaoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LimiteAprovacaoValorMinimo_Z" )]
      [  XmlElement( ElementName = "LimiteAprovacaoValorMinimo_Z"   )]
      public decimal gxTpr_Limiteaprovacaovalorminimo_Z
      {
         get {
            return gxTv_SdtLimiteAprovacao_Limiteaprovacaovalorminimo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLimiteAprovacao_Limiteaprovacaovalorminimo_Z = value;
            SetDirty("Limiteaprovacaovalorminimo_Z");
         }

      }

      public void gxTv_SdtLimiteAprovacao_Limiteaprovacaovalorminimo_Z_SetNull( )
      {
         gxTv_SdtLimiteAprovacao_Limiteaprovacaovalorminimo_Z = 0;
         SetDirty("Limiteaprovacaovalorminimo_Z");
         return  ;
      }

      public bool gxTv_SdtLimiteAprovacao_Limiteaprovacaovalorminimo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LimiteAprovacaoAprovacoes_Z" )]
      [  XmlElement( ElementName = "LimiteAprovacaoAprovacoes_Z"   )]
      public short gxTpr_Limiteaprovacaoaprovacoes_Z
      {
         get {
            return gxTv_SdtLimiteAprovacao_Limiteaprovacaoaprovacoes_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLimiteAprovacao_Limiteaprovacaoaprovacoes_Z = value;
            SetDirty("Limiteaprovacaoaprovacoes_Z");
         }

      }

      public void gxTv_SdtLimiteAprovacao_Limiteaprovacaoaprovacoes_Z_SetNull( )
      {
         gxTv_SdtLimiteAprovacao_Limiteaprovacaoaprovacoes_Z = 0;
         SetDirty("Limiteaprovacaoaprovacoes_Z");
         return  ;
      }

      public bool gxTv_SdtLimiteAprovacao_Limiteaprovacaoaprovacoes_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LimiteAprovacaoReprovacoesPermitidas_Z" )]
      [  XmlElement( ElementName = "LimiteAprovacaoReprovacoesPermitidas_Z"   )]
      public short gxTpr_Limiteaprovacaoreprovacoespermitidas_Z
      {
         get {
            return gxTv_SdtLimiteAprovacao_Limiteaprovacaoreprovacoespermitidas_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLimiteAprovacao_Limiteaprovacaoreprovacoespermitidas_Z = value;
            SetDirty("Limiteaprovacaoreprovacoespermitidas_Z");
         }

      }

      public void gxTv_SdtLimiteAprovacao_Limiteaprovacaoreprovacoespermitidas_Z_SetNull( )
      {
         gxTv_SdtLimiteAprovacao_Limiteaprovacaoreprovacoespermitidas_Z = 0;
         SetDirty("Limiteaprovacaoreprovacoespermitidas_Z");
         return  ;
      }

      public bool gxTv_SdtLimiteAprovacao_Limiteaprovacaoreprovacoespermitidas_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LimiteAprovacaoValorMinimo_N" )]
      [  XmlElement( ElementName = "LimiteAprovacaoValorMinimo_N"   )]
      public short gxTpr_Limiteaprovacaovalorminimo_N
      {
         get {
            return gxTv_SdtLimiteAprovacao_Limiteaprovacaovalorminimo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLimiteAprovacao_Limiteaprovacaovalorminimo_N = value;
            SetDirty("Limiteaprovacaovalorminimo_N");
         }

      }

      public void gxTv_SdtLimiteAprovacao_Limiteaprovacaovalorminimo_N_SetNull( )
      {
         gxTv_SdtLimiteAprovacao_Limiteaprovacaovalorminimo_N = 0;
         SetDirty("Limiteaprovacaovalorminimo_N");
         return  ;
      }

      public bool gxTv_SdtLimiteAprovacao_Limiteaprovacaovalorminimo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LimiteAprovacaoAprovacoes_N" )]
      [  XmlElement( ElementName = "LimiteAprovacaoAprovacoes_N"   )]
      public short gxTpr_Limiteaprovacaoaprovacoes_N
      {
         get {
            return gxTv_SdtLimiteAprovacao_Limiteaprovacaoaprovacoes_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtLimiteAprovacao_Limiteaprovacaoaprovacoes_N = value;
            SetDirty("Limiteaprovacaoaprovacoes_N");
         }

      }

      public void gxTv_SdtLimiteAprovacao_Limiteaprovacaoaprovacoes_N_SetNull( )
      {
         gxTv_SdtLimiteAprovacao_Limiteaprovacaoaprovacoes_N = 0;
         SetDirty("Limiteaprovacaoaprovacoes_N");
         return  ;
      }

      public bool gxTv_SdtLimiteAprovacao_Limiteaprovacaoaprovacoes_N_IsNull( )
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
         gxTv_SdtLimiteAprovacao_Mode = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "limiteaprovacao", "GeneXus.Programs.limiteaprovacao_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtLimiteAprovacao_Limiteaprovacaoaprovacoes ;
      private short gxTv_SdtLimiteAprovacao_Limiteaprovacaoreprovacoespermitidas ;
      private short gxTv_SdtLimiteAprovacao_Initialized ;
      private short gxTv_SdtLimiteAprovacao_Limiteaprovacaoaprovacoes_Z ;
      private short gxTv_SdtLimiteAprovacao_Limiteaprovacaoreprovacoespermitidas_Z ;
      private short gxTv_SdtLimiteAprovacao_Limiteaprovacaovalorminimo_N ;
      private short gxTv_SdtLimiteAprovacao_Limiteaprovacaoaprovacoes_N ;
      private int gxTv_SdtLimiteAprovacao_Limiteaprovacaoid ;
      private int gxTv_SdtLimiteAprovacao_Limiteaprovacaoid_Z ;
      private decimal gxTv_SdtLimiteAprovacao_Limiteaprovacaovalorminimo ;
      private decimal gxTv_SdtLimiteAprovacao_Limiteaprovacaovalorminimo_Z ;
      private string gxTv_SdtLimiteAprovacao_Mode ;
   }

   [DataContract(Name = @"LimiteAprovacao", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtLimiteAprovacao_RESTInterface : GxGenericCollectionItem<SdtLimiteAprovacao>
   {
      public SdtLimiteAprovacao_RESTInterface( ) : base()
      {
      }

      public SdtLimiteAprovacao_RESTInterface( SdtLimiteAprovacao psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "LimiteAprovacaoId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Limiteaprovacaoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Limiteaprovacaoid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Limiteaprovacaoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "LimiteAprovacaoValorMinimo" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Limiteaprovacaovalorminimo
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Limiteaprovacaovalorminimo, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Limiteaprovacaovalorminimo = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "LimiteAprovacaoAprovacoes" , Order = 2 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Limiteaprovacaoaprovacoes
      {
         get {
            return sdt.gxTpr_Limiteaprovacaoaprovacoes ;
         }

         set {
            sdt.gxTpr_Limiteaprovacaoaprovacoes = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "LimiteAprovacaoReprovacoesPermitidas" , Order = 3 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Limiteaprovacaoreprovacoespermitidas
      {
         get {
            return sdt.gxTpr_Limiteaprovacaoreprovacoespermitidas ;
         }

         set {
            sdt.gxTpr_Limiteaprovacaoreprovacoespermitidas = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtLimiteAprovacao sdt
      {
         get {
            return (SdtLimiteAprovacao)Sdt ;
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
            sdt = new SdtLimiteAprovacao() ;
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

   [DataContract(Name = @"LimiteAprovacao", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtLimiteAprovacao_RESTLInterface : GxGenericCollectionItem<SdtLimiteAprovacao>
   {
      public SdtLimiteAprovacao_RESTLInterface( ) : base()
      {
      }

      public SdtLimiteAprovacao_RESTLInterface( SdtLimiteAprovacao psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "LimiteAprovacaoValorMinimo" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Limiteaprovacaovalorminimo
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Limiteaprovacaovalorminimo, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Limiteaprovacaovalorminimo = NumberUtil.Val( value, ".");
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

      public SdtLimiteAprovacao sdt
      {
         get {
            return (SdtLimiteAprovacao)Sdt ;
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
            sdt = new SdtLimiteAprovacao() ;
         }
      }

   }

}
