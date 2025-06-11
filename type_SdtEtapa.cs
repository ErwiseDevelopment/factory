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
   [XmlRoot(ElementName = "Etapa" )]
   [XmlType(TypeName =  "Etapa" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtEtapa : GxSilentTrnSdt
   {
      public SdtEtapa( )
      {
      }

      public SdtEtapa( IGxContext context )
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

      public void Load( int AV527EtapaId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV527EtapaId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"EtapaId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Etapa");
         metadata.Set("BT", "Etapa");
         metadata.Set("PK", "[ \"EtapaId\" ]");
         metadata.Set("PKAssigned", "[ \"EtapaId\" ]");
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
         state.Add("gxTpr_Etapaid_Z");
         state.Add("gxTpr_Etapadescricao_Z");
         state.Add("gxTpr_Etapacreatedat_Z_Nullable");
         state.Add("gxTpr_Etapadescricao_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtEtapa sdt;
         sdt = (SdtEtapa)(source);
         gxTv_SdtEtapa_Etapaid = sdt.gxTv_SdtEtapa_Etapaid ;
         gxTv_SdtEtapa_Etapadescricao = sdt.gxTv_SdtEtapa_Etapadescricao ;
         gxTv_SdtEtapa_Etapacreatedat = sdt.gxTv_SdtEtapa_Etapacreatedat ;
         gxTv_SdtEtapa_Mode = sdt.gxTv_SdtEtapa_Mode ;
         gxTv_SdtEtapa_Initialized = sdt.gxTv_SdtEtapa_Initialized ;
         gxTv_SdtEtapa_Etapaid_Z = sdt.gxTv_SdtEtapa_Etapaid_Z ;
         gxTv_SdtEtapa_Etapadescricao_Z = sdt.gxTv_SdtEtapa_Etapadescricao_Z ;
         gxTv_SdtEtapa_Etapacreatedat_Z = sdt.gxTv_SdtEtapa_Etapacreatedat_Z ;
         gxTv_SdtEtapa_Etapadescricao_N = sdt.gxTv_SdtEtapa_Etapadescricao_N ;
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
         AddObjectProperty("EtapaId", gxTv_SdtEtapa_Etapaid, false, includeNonInitialized);
         AddObjectProperty("EtapaDescricao", gxTv_SdtEtapa_Etapadescricao, false, includeNonInitialized);
         AddObjectProperty("EtapaDescricao_N", gxTv_SdtEtapa_Etapadescricao_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtEtapa_Etapacreatedat;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("EtapaCreatedAt", sDateCnv, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtEtapa_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtEtapa_Initialized, false, includeNonInitialized);
            AddObjectProperty("EtapaId_Z", gxTv_SdtEtapa_Etapaid_Z, false, includeNonInitialized);
            AddObjectProperty("EtapaDescricao_Z", gxTv_SdtEtapa_Etapadescricao_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtEtapa_Etapacreatedat_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("EtapaCreatedAt_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("EtapaDescricao_N", gxTv_SdtEtapa_Etapadescricao_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtEtapa sdt )
      {
         if ( sdt.IsDirty("EtapaId") )
         {
            sdtIsNull = 0;
            gxTv_SdtEtapa_Etapaid = sdt.gxTv_SdtEtapa_Etapaid ;
         }
         if ( sdt.IsDirty("EtapaDescricao") )
         {
            gxTv_SdtEtapa_Etapadescricao_N = (short)(sdt.gxTv_SdtEtapa_Etapadescricao_N);
            sdtIsNull = 0;
            gxTv_SdtEtapa_Etapadescricao = sdt.gxTv_SdtEtapa_Etapadescricao ;
         }
         if ( sdt.IsDirty("EtapaCreatedAt") )
         {
            sdtIsNull = 0;
            gxTv_SdtEtapa_Etapacreatedat = sdt.gxTv_SdtEtapa_Etapacreatedat ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "EtapaId" )]
      [  XmlElement( ElementName = "EtapaId"   )]
      public int gxTpr_Etapaid
      {
         get {
            return gxTv_SdtEtapa_Etapaid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtEtapa_Etapaid != value )
            {
               gxTv_SdtEtapa_Mode = "INS";
               this.gxTv_SdtEtapa_Etapaid_Z_SetNull( );
               this.gxTv_SdtEtapa_Etapadescricao_Z_SetNull( );
               this.gxTv_SdtEtapa_Etapacreatedat_Z_SetNull( );
            }
            gxTv_SdtEtapa_Etapaid = value;
            SetDirty("Etapaid");
         }

      }

      [  SoapElement( ElementName = "EtapaDescricao" )]
      [  XmlElement( ElementName = "EtapaDescricao"   )]
      public string gxTpr_Etapadescricao
      {
         get {
            return gxTv_SdtEtapa_Etapadescricao ;
         }

         set {
            gxTv_SdtEtapa_Etapadescricao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtEtapa_Etapadescricao = value;
            SetDirty("Etapadescricao");
         }

      }

      public void gxTv_SdtEtapa_Etapadescricao_SetNull( )
      {
         gxTv_SdtEtapa_Etapadescricao_N = 1;
         gxTv_SdtEtapa_Etapadescricao = "";
         SetDirty("Etapadescricao");
         return  ;
      }

      public bool gxTv_SdtEtapa_Etapadescricao_IsNull( )
      {
         return (gxTv_SdtEtapa_Etapadescricao_N==1) ;
      }

      [  SoapElement( ElementName = "EtapaCreatedAt" )]
      [  XmlElement( ElementName = "EtapaCreatedAt"  , IsNullable=true )]
      public string gxTpr_Etapacreatedat_Nullable
      {
         get {
            if ( gxTv_SdtEtapa_Etapacreatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtEtapa_Etapacreatedat).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtEtapa_Etapacreatedat = DateTime.MinValue;
            else
               gxTv_SdtEtapa_Etapacreatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Etapacreatedat
      {
         get {
            return gxTv_SdtEtapa_Etapacreatedat ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEtapa_Etapacreatedat = value;
            SetDirty("Etapacreatedat");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtEtapa_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEtapa_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtEtapa_Mode_SetNull( )
      {
         gxTv_SdtEtapa_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtEtapa_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtEtapa_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEtapa_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtEtapa_Initialized_SetNull( )
      {
         gxTv_SdtEtapa_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtEtapa_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EtapaId_Z" )]
      [  XmlElement( ElementName = "EtapaId_Z"   )]
      public int gxTpr_Etapaid_Z
      {
         get {
            return gxTv_SdtEtapa_Etapaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEtapa_Etapaid_Z = value;
            SetDirty("Etapaid_Z");
         }

      }

      public void gxTv_SdtEtapa_Etapaid_Z_SetNull( )
      {
         gxTv_SdtEtapa_Etapaid_Z = 0;
         SetDirty("Etapaid_Z");
         return  ;
      }

      public bool gxTv_SdtEtapa_Etapaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EtapaDescricao_Z" )]
      [  XmlElement( ElementName = "EtapaDescricao_Z"   )]
      public string gxTpr_Etapadescricao_Z
      {
         get {
            return gxTv_SdtEtapa_Etapadescricao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEtapa_Etapadescricao_Z = value;
            SetDirty("Etapadescricao_Z");
         }

      }

      public void gxTv_SdtEtapa_Etapadescricao_Z_SetNull( )
      {
         gxTv_SdtEtapa_Etapadescricao_Z = "";
         SetDirty("Etapadescricao_Z");
         return  ;
      }

      public bool gxTv_SdtEtapa_Etapadescricao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EtapaCreatedAt_Z" )]
      [  XmlElement( ElementName = "EtapaCreatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Etapacreatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtEtapa_Etapacreatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtEtapa_Etapacreatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtEtapa_Etapacreatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtEtapa_Etapacreatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Etapacreatedat_Z
      {
         get {
            return gxTv_SdtEtapa_Etapacreatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEtapa_Etapacreatedat_Z = value;
            SetDirty("Etapacreatedat_Z");
         }

      }

      public void gxTv_SdtEtapa_Etapacreatedat_Z_SetNull( )
      {
         gxTv_SdtEtapa_Etapacreatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Etapacreatedat_Z");
         return  ;
      }

      public bool gxTv_SdtEtapa_Etapacreatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EtapaDescricao_N" )]
      [  XmlElement( ElementName = "EtapaDescricao_N"   )]
      public short gxTpr_Etapadescricao_N
      {
         get {
            return gxTv_SdtEtapa_Etapadescricao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtEtapa_Etapadescricao_N = value;
            SetDirty("Etapadescricao_N");
         }

      }

      public void gxTv_SdtEtapa_Etapadescricao_N_SetNull( )
      {
         gxTv_SdtEtapa_Etapadescricao_N = 0;
         SetDirty("Etapadescricao_N");
         return  ;
      }

      public bool gxTv_SdtEtapa_Etapadescricao_N_IsNull( )
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
         gxTv_SdtEtapa_Etapadescricao = "";
         gxTv_SdtEtapa_Etapacreatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtEtapa_Mode = "";
         gxTv_SdtEtapa_Etapadescricao_Z = "";
         gxTv_SdtEtapa_Etapacreatedat_Z = (DateTime)(DateTime.MinValue);
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "etapa", "GeneXus.Programs.etapa_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtEtapa_Initialized ;
      private short gxTv_SdtEtapa_Etapadescricao_N ;
      private int gxTv_SdtEtapa_Etapaid ;
      private int gxTv_SdtEtapa_Etapaid_Z ;
      private string gxTv_SdtEtapa_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtEtapa_Etapacreatedat ;
      private DateTime gxTv_SdtEtapa_Etapacreatedat_Z ;
      private DateTime datetime_STZ ;
      private string gxTv_SdtEtapa_Etapadescricao ;
      private string gxTv_SdtEtapa_Etapadescricao_Z ;
   }

   [DataContract(Name = @"Etapa", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtEtapa_RESTInterface : GxGenericCollectionItem<SdtEtapa>
   {
      public SdtEtapa_RESTInterface( ) : base()
      {
      }

      public SdtEtapa_RESTInterface( SdtEtapa psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EtapaId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Etapaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Etapaid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Etapaid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "EtapaDescricao" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Etapadescricao
      {
         get {
            return sdt.gxTpr_Etapadescricao ;
         }

         set {
            sdt.gxTpr_Etapadescricao = value;
         }

      }

      [DataMember( Name = "EtapaCreatedAt" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Etapacreatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Etapacreatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Etapacreatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      public SdtEtapa sdt
      {
         get {
            return (SdtEtapa)Sdt ;
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
            sdt = new SdtEtapa() ;
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

   [DataContract(Name = @"Etapa", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtEtapa_RESTLInterface : GxGenericCollectionItem<SdtEtapa>
   {
      public SdtEtapa_RESTLInterface( ) : base()
      {
      }

      public SdtEtapa_RESTLInterface( SdtEtapa psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "EtapaDescricao" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Etapadescricao
      {
         get {
            return sdt.gxTpr_Etapadescricao ;
         }

         set {
            sdt.gxTpr_Etapadescricao = value;
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

      public SdtEtapa sdt
      {
         get {
            return (SdtEtapa)Sdt ;
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
            sdt = new SdtEtapa() ;
         }
      }

   }

}
