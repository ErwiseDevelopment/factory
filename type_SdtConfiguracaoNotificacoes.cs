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
   [XmlRoot(ElementName = "ConfiguracaoNotificacoes" )]
   [XmlType(TypeName =  "ConfiguracaoNotificacoes" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtConfiguracaoNotificacoes : GxSilentTrnSdt
   {
      public SdtConfiguracaoNotificacoes( )
      {
      }

      public SdtConfiguracaoNotificacoes( IGxContext context )
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

      public void Load( int AV491ConfiguracaoNotificacoesId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV491ConfiguracaoNotificacoesId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ConfiguracaoNotificacoesId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "ConfiguracaoNotificacoes");
         metadata.Set("BT", "ConfiguracaoNotificacoes");
         metadata.Set("PK", "[ \"ConfiguracaoNotificacoesId\" ]");
         metadata.Set("PKAssigned", "[ \"ConfiguracaoNotificacoesId\" ]");
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
         state.Add("gxTpr_Configuracaonotificacoesid_Z");
         state.Add("gxTpr_Configuracaonotificacoesemail_Z");
         state.Add("gxTpr_Configuracaonotificacoesemail_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtConfiguracaoNotificacoes sdt;
         sdt = (SdtConfiguracaoNotificacoes)(source);
         gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesid = sdt.gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesid ;
         gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail = sdt.gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail ;
         gxTv_SdtConfiguracaoNotificacoes_Mode = sdt.gxTv_SdtConfiguracaoNotificacoes_Mode ;
         gxTv_SdtConfiguracaoNotificacoes_Initialized = sdt.gxTv_SdtConfiguracaoNotificacoes_Initialized ;
         gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesid_Z = sdt.gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesid_Z ;
         gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail_Z = sdt.gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail_Z ;
         gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail_N = sdt.gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail_N ;
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
         AddObjectProperty("ConfiguracaoNotificacoesId", gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesid, false, includeNonInitialized);
         AddObjectProperty("ConfiguracaoNotificacoesEmail", gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail, false, includeNonInitialized);
         AddObjectProperty("ConfiguracaoNotificacoesEmail_N", gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtConfiguracaoNotificacoes_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtConfiguracaoNotificacoes_Initialized, false, includeNonInitialized);
            AddObjectProperty("ConfiguracaoNotificacoesId_Z", gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesid_Z, false, includeNonInitialized);
            AddObjectProperty("ConfiguracaoNotificacoesEmail_Z", gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail_Z, false, includeNonInitialized);
            AddObjectProperty("ConfiguracaoNotificacoesEmail_N", gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtConfiguracaoNotificacoes sdt )
      {
         if ( sdt.IsDirty("ConfiguracaoNotificacoesId") )
         {
            sdtIsNull = 0;
            gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesid = sdt.gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesid ;
         }
         if ( sdt.IsDirty("ConfiguracaoNotificacoesEmail") )
         {
            gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail_N = (short)(sdt.gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail = sdt.gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ConfiguracaoNotificacoesId" )]
      [  XmlElement( ElementName = "ConfiguracaoNotificacoesId"   )]
      public int gxTpr_Configuracaonotificacoesid
      {
         get {
            return gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesid != value )
            {
               gxTv_SdtConfiguracaoNotificacoes_Mode = "INS";
               this.gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesid_Z_SetNull( );
               this.gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail_Z_SetNull( );
            }
            gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesid = value;
            SetDirty("Configuracaonotificacoesid");
         }

      }

      [  SoapElement( ElementName = "ConfiguracaoNotificacoesEmail" )]
      [  XmlElement( ElementName = "ConfiguracaoNotificacoesEmail"   )]
      public string gxTpr_Configuracaonotificacoesemail
      {
         get {
            return gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail ;
         }

         set {
            gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail = value;
            SetDirty("Configuracaonotificacoesemail");
         }

      }

      public void gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail_SetNull( )
      {
         gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail_N = 1;
         gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail = "";
         SetDirty("Configuracaonotificacoesemail");
         return  ;
      }

      public bool gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail_IsNull( )
      {
         return (gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtConfiguracaoNotificacoes_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracaoNotificacoes_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtConfiguracaoNotificacoes_Mode_SetNull( )
      {
         gxTv_SdtConfiguracaoNotificacoes_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtConfiguracaoNotificacoes_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtConfiguracaoNotificacoes_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracaoNotificacoes_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtConfiguracaoNotificacoes_Initialized_SetNull( )
      {
         gxTv_SdtConfiguracaoNotificacoes_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtConfiguracaoNotificacoes_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracaoNotificacoesId_Z" )]
      [  XmlElement( ElementName = "ConfiguracaoNotificacoesId_Z"   )]
      public int gxTpr_Configuracaonotificacoesid_Z
      {
         get {
            return gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesid_Z = value;
            SetDirty("Configuracaonotificacoesid_Z");
         }

      }

      public void gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesid_Z_SetNull( )
      {
         gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesid_Z = 0;
         SetDirty("Configuracaonotificacoesid_Z");
         return  ;
      }

      public bool gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracaoNotificacoesEmail_Z" )]
      [  XmlElement( ElementName = "ConfiguracaoNotificacoesEmail_Z"   )]
      public string gxTpr_Configuracaonotificacoesemail_Z
      {
         get {
            return gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail_Z = value;
            SetDirty("Configuracaonotificacoesemail_Z");
         }

      }

      public void gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail_Z_SetNull( )
      {
         gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail_Z = "";
         SetDirty("Configuracaonotificacoesemail_Z");
         return  ;
      }

      public bool gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracaoNotificacoesEmail_N" )]
      [  XmlElement( ElementName = "ConfiguracaoNotificacoesEmail_N"   )]
      public short gxTpr_Configuracaonotificacoesemail_N
      {
         get {
            return gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail_N = value;
            SetDirty("Configuracaonotificacoesemail_N");
         }

      }

      public void gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail_N_SetNull( )
      {
         gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail_N = 0;
         SetDirty("Configuracaonotificacoesemail_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail_N_IsNull( )
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
         gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail = "";
         gxTv_SdtConfiguracaoNotificacoes_Mode = "";
         gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "configuracaonotificacoes", "GeneXus.Programs.configuracaonotificacoes_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtConfiguracaoNotificacoes_Initialized ;
      private short gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail_N ;
      private int gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesid ;
      private int gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesid_Z ;
      private string gxTv_SdtConfiguracaoNotificacoes_Mode ;
      private string gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail ;
      private string gxTv_SdtConfiguracaoNotificacoes_Configuracaonotificacoesemail_Z ;
   }

   [DataContract(Name = @"ConfiguracaoNotificacoes", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtConfiguracaoNotificacoes_RESTInterface : GxGenericCollectionItem<SdtConfiguracaoNotificacoes>
   {
      public SdtConfiguracaoNotificacoes_RESTInterface( ) : base()
      {
      }

      public SdtConfiguracaoNotificacoes_RESTInterface( SdtConfiguracaoNotificacoes psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ConfiguracaoNotificacoesId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Configuracaonotificacoesid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Configuracaonotificacoesid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Configuracaonotificacoesid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ConfiguracaoNotificacoesEmail" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Configuracaonotificacoesemail
      {
         get {
            return sdt.gxTpr_Configuracaonotificacoesemail ;
         }

         set {
            sdt.gxTpr_Configuracaonotificacoesemail = value;
         }

      }

      public SdtConfiguracaoNotificacoes sdt
      {
         get {
            return (SdtConfiguracaoNotificacoes)Sdt ;
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
            sdt = new SdtConfiguracaoNotificacoes() ;
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

   [DataContract(Name = @"ConfiguracaoNotificacoes", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtConfiguracaoNotificacoes_RESTLInterface : GxGenericCollectionItem<SdtConfiguracaoNotificacoes>
   {
      public SdtConfiguracaoNotificacoes_RESTLInterface( ) : base()
      {
      }

      public SdtConfiguracaoNotificacoes_RESTLInterface( SdtConfiguracaoNotificacoes psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ConfiguracaoNotificacoesEmail" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Configuracaonotificacoesemail
      {
         get {
            return sdt.gxTpr_Configuracaonotificacoesemail ;
         }

         set {
            sdt.gxTpr_Configuracaonotificacoesemail = value;
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

      public SdtConfiguracaoNotificacoes sdt
      {
         get {
            return (SdtConfiguracaoNotificacoes)Sdt ;
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
            sdt = new SdtConfiguracaoNotificacoes() ;
         }
      }

   }

}
