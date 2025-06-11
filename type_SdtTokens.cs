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
   [XmlRoot(ElementName = "Tokens" )]
   [XmlType(TypeName =  "Tokens" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtTokens : GxSilentTrnSdt
   {
      public SdtTokens( )
      {
      }

      public SdtTokens( IGxContext context )
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

      public void Load( int AV1050TokensId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV1050TokensId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"TokensId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Tokens");
         metadata.Set("BT", "Tokens");
         metadata.Set("PK", "[ \"TokensId\" ]");
         metadata.Set("PKAssigned", "[ \"TokensId\" ]");
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
         state.Add("gxTpr_Tokensid_Z");
         state.Add("gxTpr_Tokensexpire_Z");
         state.Add("gxTpr_Tokenstype_Z");
         state.Add("gxTpr_Tokensdatetime_Z");
         state.Add("gxTpr_Tokenscontent_N");
         state.Add("gxTpr_Tokensexpire_N");
         state.Add("gxTpr_Tokenstype_N");
         state.Add("gxTpr_Tokensdatetime_N");
         state.Add("gxTpr_Tokenssalt_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTokens sdt;
         sdt = (SdtTokens)(source);
         gxTv_SdtTokens_Tokensid = sdt.gxTv_SdtTokens_Tokensid ;
         gxTv_SdtTokens_Tokenscontent = sdt.gxTv_SdtTokens_Tokenscontent ;
         gxTv_SdtTokens_Tokensexpire = sdt.gxTv_SdtTokens_Tokensexpire ;
         gxTv_SdtTokens_Tokenstype = sdt.gxTv_SdtTokens_Tokenstype ;
         gxTv_SdtTokens_Tokensdatetime = sdt.gxTv_SdtTokens_Tokensdatetime ;
         gxTv_SdtTokens_Tokenssalt = sdt.gxTv_SdtTokens_Tokenssalt ;
         gxTv_SdtTokens_Mode = sdt.gxTv_SdtTokens_Mode ;
         gxTv_SdtTokens_Initialized = sdt.gxTv_SdtTokens_Initialized ;
         gxTv_SdtTokens_Tokensid_Z = sdt.gxTv_SdtTokens_Tokensid_Z ;
         gxTv_SdtTokens_Tokensexpire_Z = sdt.gxTv_SdtTokens_Tokensexpire_Z ;
         gxTv_SdtTokens_Tokenstype_Z = sdt.gxTv_SdtTokens_Tokenstype_Z ;
         gxTv_SdtTokens_Tokensdatetime_Z = sdt.gxTv_SdtTokens_Tokensdatetime_Z ;
         gxTv_SdtTokens_Tokenscontent_N = sdt.gxTv_SdtTokens_Tokenscontent_N ;
         gxTv_SdtTokens_Tokensexpire_N = sdt.gxTv_SdtTokens_Tokensexpire_N ;
         gxTv_SdtTokens_Tokenstype_N = sdt.gxTv_SdtTokens_Tokenstype_N ;
         gxTv_SdtTokens_Tokensdatetime_N = sdt.gxTv_SdtTokens_Tokensdatetime_N ;
         gxTv_SdtTokens_Tokenssalt_N = sdt.gxTv_SdtTokens_Tokenssalt_N ;
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
         AddObjectProperty("TokensId", gxTv_SdtTokens_Tokensid, false, includeNonInitialized);
         AddObjectProperty("TokensContent", gxTv_SdtTokens_Tokenscontent, false, includeNonInitialized);
         AddObjectProperty("TokensContent_N", gxTv_SdtTokens_Tokenscontent_N, false, includeNonInitialized);
         AddObjectProperty("TokensExpire", gxTv_SdtTokens_Tokensexpire, false, includeNonInitialized);
         AddObjectProperty("TokensExpire_N", gxTv_SdtTokens_Tokensexpire_N, false, includeNonInitialized);
         AddObjectProperty("TokensType", gxTv_SdtTokens_Tokenstype, false, includeNonInitialized);
         AddObjectProperty("TokensType_N", gxTv_SdtTokens_Tokenstype_N, false, includeNonInitialized);
         AddObjectProperty("TokensDateTime", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtTokens_Tokensdatetime), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("TokensDateTime_N", gxTv_SdtTokens_Tokensdatetime_N, false, includeNonInitialized);
         AddObjectProperty("TokensSalt", gxTv_SdtTokens_Tokenssalt, false, includeNonInitialized);
         AddObjectProperty("TokensSalt_N", gxTv_SdtTokens_Tokenssalt_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTokens_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTokens_Initialized, false, includeNonInitialized);
            AddObjectProperty("TokensId_Z", gxTv_SdtTokens_Tokensid_Z, false, includeNonInitialized);
            AddObjectProperty("TokensExpire_Z", gxTv_SdtTokens_Tokensexpire_Z, false, includeNonInitialized);
            AddObjectProperty("TokensType_Z", gxTv_SdtTokens_Tokenstype_Z, false, includeNonInitialized);
            AddObjectProperty("TokensDateTime_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtTokens_Tokensdatetime_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("TokensContent_N", gxTv_SdtTokens_Tokenscontent_N, false, includeNonInitialized);
            AddObjectProperty("TokensExpire_N", gxTv_SdtTokens_Tokensexpire_N, false, includeNonInitialized);
            AddObjectProperty("TokensType_N", gxTv_SdtTokens_Tokenstype_N, false, includeNonInitialized);
            AddObjectProperty("TokensDateTime_N", gxTv_SdtTokens_Tokensdatetime_N, false, includeNonInitialized);
            AddObjectProperty("TokensSalt_N", gxTv_SdtTokens_Tokenssalt_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTokens sdt )
      {
         if ( sdt.IsDirty("TokensId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTokens_Tokensid = sdt.gxTv_SdtTokens_Tokensid ;
         }
         if ( sdt.IsDirty("TokensContent") )
         {
            gxTv_SdtTokens_Tokenscontent_N = (short)(sdt.gxTv_SdtTokens_Tokenscontent_N);
            sdtIsNull = 0;
            gxTv_SdtTokens_Tokenscontent = sdt.gxTv_SdtTokens_Tokenscontent ;
         }
         if ( sdt.IsDirty("TokensExpire") )
         {
            gxTv_SdtTokens_Tokensexpire_N = (short)(sdt.gxTv_SdtTokens_Tokensexpire_N);
            sdtIsNull = 0;
            gxTv_SdtTokens_Tokensexpire = sdt.gxTv_SdtTokens_Tokensexpire ;
         }
         if ( sdt.IsDirty("TokensType") )
         {
            gxTv_SdtTokens_Tokenstype_N = (short)(sdt.gxTv_SdtTokens_Tokenstype_N);
            sdtIsNull = 0;
            gxTv_SdtTokens_Tokenstype = sdt.gxTv_SdtTokens_Tokenstype ;
         }
         if ( sdt.IsDirty("TokensDateTime") )
         {
            gxTv_SdtTokens_Tokensdatetime_N = (short)(sdt.gxTv_SdtTokens_Tokensdatetime_N);
            sdtIsNull = 0;
            gxTv_SdtTokens_Tokensdatetime = sdt.gxTv_SdtTokens_Tokensdatetime ;
         }
         if ( sdt.IsDirty("TokensSalt") )
         {
            gxTv_SdtTokens_Tokenssalt_N = (short)(sdt.gxTv_SdtTokens_Tokenssalt_N);
            sdtIsNull = 0;
            gxTv_SdtTokens_Tokenssalt = sdt.gxTv_SdtTokens_Tokenssalt ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "TokensId" )]
      [  XmlElement( ElementName = "TokensId"   )]
      public int gxTpr_Tokensid
      {
         get {
            return gxTv_SdtTokens_Tokensid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTokens_Tokensid != value )
            {
               gxTv_SdtTokens_Mode = "INS";
               this.gxTv_SdtTokens_Tokensid_Z_SetNull( );
               this.gxTv_SdtTokens_Tokensexpire_Z_SetNull( );
               this.gxTv_SdtTokens_Tokenstype_Z_SetNull( );
               this.gxTv_SdtTokens_Tokensdatetime_Z_SetNull( );
            }
            gxTv_SdtTokens_Tokensid = value;
            SetDirty("Tokensid");
         }

      }

      [  SoapElement( ElementName = "TokensContent" )]
      [  XmlElement( ElementName = "TokensContent"   )]
      public string gxTpr_Tokenscontent
      {
         get {
            return gxTv_SdtTokens_Tokenscontent ;
         }

         set {
            gxTv_SdtTokens_Tokenscontent_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTokens_Tokenscontent = value;
            SetDirty("Tokenscontent");
         }

      }

      public void gxTv_SdtTokens_Tokenscontent_SetNull( )
      {
         gxTv_SdtTokens_Tokenscontent_N = 1;
         gxTv_SdtTokens_Tokenscontent = "";
         SetDirty("Tokenscontent");
         return  ;
      }

      public bool gxTv_SdtTokens_Tokenscontent_IsNull( )
      {
         return (gxTv_SdtTokens_Tokenscontent_N==1) ;
      }

      [  SoapElement( ElementName = "TokensExpire" )]
      [  XmlElement( ElementName = "TokensExpire"   )]
      public int gxTpr_Tokensexpire
      {
         get {
            return gxTv_SdtTokens_Tokensexpire ;
         }

         set {
            gxTv_SdtTokens_Tokensexpire_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTokens_Tokensexpire = value;
            SetDirty("Tokensexpire");
         }

      }

      public void gxTv_SdtTokens_Tokensexpire_SetNull( )
      {
         gxTv_SdtTokens_Tokensexpire_N = 1;
         gxTv_SdtTokens_Tokensexpire = 0;
         SetDirty("Tokensexpire");
         return  ;
      }

      public bool gxTv_SdtTokens_Tokensexpire_IsNull( )
      {
         return (gxTv_SdtTokens_Tokensexpire_N==1) ;
      }

      [  SoapElement( ElementName = "TokensType" )]
      [  XmlElement( ElementName = "TokensType"   )]
      public string gxTpr_Tokenstype
      {
         get {
            return gxTv_SdtTokens_Tokenstype ;
         }

         set {
            gxTv_SdtTokens_Tokenstype_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTokens_Tokenstype = value;
            SetDirty("Tokenstype");
         }

      }

      public void gxTv_SdtTokens_Tokenstype_SetNull( )
      {
         gxTv_SdtTokens_Tokenstype_N = 1;
         gxTv_SdtTokens_Tokenstype = "";
         SetDirty("Tokenstype");
         return  ;
      }

      public bool gxTv_SdtTokens_Tokenstype_IsNull( )
      {
         return (gxTv_SdtTokens_Tokenstype_N==1) ;
      }

      [  SoapElement( ElementName = "TokensDateTime" )]
      [  XmlElement( ElementName = "TokensDateTime"   )]
      public long gxTpr_Tokensdatetime
      {
         get {
            return gxTv_SdtTokens_Tokensdatetime ;
         }

         set {
            gxTv_SdtTokens_Tokensdatetime_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTokens_Tokensdatetime = value;
            SetDirty("Tokensdatetime");
         }

      }

      public void gxTv_SdtTokens_Tokensdatetime_SetNull( )
      {
         gxTv_SdtTokens_Tokensdatetime_N = 1;
         gxTv_SdtTokens_Tokensdatetime = 0;
         SetDirty("Tokensdatetime");
         return  ;
      }

      public bool gxTv_SdtTokens_Tokensdatetime_IsNull( )
      {
         return (gxTv_SdtTokens_Tokensdatetime_N==1) ;
      }

      [  SoapElement( ElementName = "TokensSalt" )]
      [  XmlElement( ElementName = "TokensSalt"   )]
      public string gxTpr_Tokenssalt
      {
         get {
            return gxTv_SdtTokens_Tokenssalt ;
         }

         set {
            gxTv_SdtTokens_Tokenssalt_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTokens_Tokenssalt = value;
            SetDirty("Tokenssalt");
         }

      }

      public void gxTv_SdtTokens_Tokenssalt_SetNull( )
      {
         gxTv_SdtTokens_Tokenssalt_N = 1;
         gxTv_SdtTokens_Tokenssalt = "";
         SetDirty("Tokenssalt");
         return  ;
      }

      public bool gxTv_SdtTokens_Tokenssalt_IsNull( )
      {
         return (gxTv_SdtTokens_Tokenssalt_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTokens_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTokens_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTokens_Mode_SetNull( )
      {
         gxTv_SdtTokens_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTokens_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTokens_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTokens_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTokens_Initialized_SetNull( )
      {
         gxTv_SdtTokens_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTokens_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TokensId_Z" )]
      [  XmlElement( ElementName = "TokensId_Z"   )]
      public int gxTpr_Tokensid_Z
      {
         get {
            return gxTv_SdtTokens_Tokensid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTokens_Tokensid_Z = value;
            SetDirty("Tokensid_Z");
         }

      }

      public void gxTv_SdtTokens_Tokensid_Z_SetNull( )
      {
         gxTv_SdtTokens_Tokensid_Z = 0;
         SetDirty("Tokensid_Z");
         return  ;
      }

      public bool gxTv_SdtTokens_Tokensid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TokensExpire_Z" )]
      [  XmlElement( ElementName = "TokensExpire_Z"   )]
      public int gxTpr_Tokensexpire_Z
      {
         get {
            return gxTv_SdtTokens_Tokensexpire_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTokens_Tokensexpire_Z = value;
            SetDirty("Tokensexpire_Z");
         }

      }

      public void gxTv_SdtTokens_Tokensexpire_Z_SetNull( )
      {
         gxTv_SdtTokens_Tokensexpire_Z = 0;
         SetDirty("Tokensexpire_Z");
         return  ;
      }

      public bool gxTv_SdtTokens_Tokensexpire_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TokensType_Z" )]
      [  XmlElement( ElementName = "TokensType_Z"   )]
      public string gxTpr_Tokenstype_Z
      {
         get {
            return gxTv_SdtTokens_Tokenstype_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTokens_Tokenstype_Z = value;
            SetDirty("Tokenstype_Z");
         }

      }

      public void gxTv_SdtTokens_Tokenstype_Z_SetNull( )
      {
         gxTv_SdtTokens_Tokenstype_Z = "";
         SetDirty("Tokenstype_Z");
         return  ;
      }

      public bool gxTv_SdtTokens_Tokenstype_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TokensDateTime_Z" )]
      [  XmlElement( ElementName = "TokensDateTime_Z"   )]
      public long gxTpr_Tokensdatetime_Z
      {
         get {
            return gxTv_SdtTokens_Tokensdatetime_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTokens_Tokensdatetime_Z = value;
            SetDirty("Tokensdatetime_Z");
         }

      }

      public void gxTv_SdtTokens_Tokensdatetime_Z_SetNull( )
      {
         gxTv_SdtTokens_Tokensdatetime_Z = 0;
         SetDirty("Tokensdatetime_Z");
         return  ;
      }

      public bool gxTv_SdtTokens_Tokensdatetime_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TokensContent_N" )]
      [  XmlElement( ElementName = "TokensContent_N"   )]
      public short gxTpr_Tokenscontent_N
      {
         get {
            return gxTv_SdtTokens_Tokenscontent_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTokens_Tokenscontent_N = value;
            SetDirty("Tokenscontent_N");
         }

      }

      public void gxTv_SdtTokens_Tokenscontent_N_SetNull( )
      {
         gxTv_SdtTokens_Tokenscontent_N = 0;
         SetDirty("Tokenscontent_N");
         return  ;
      }

      public bool gxTv_SdtTokens_Tokenscontent_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TokensExpire_N" )]
      [  XmlElement( ElementName = "TokensExpire_N"   )]
      public short gxTpr_Tokensexpire_N
      {
         get {
            return gxTv_SdtTokens_Tokensexpire_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTokens_Tokensexpire_N = value;
            SetDirty("Tokensexpire_N");
         }

      }

      public void gxTv_SdtTokens_Tokensexpire_N_SetNull( )
      {
         gxTv_SdtTokens_Tokensexpire_N = 0;
         SetDirty("Tokensexpire_N");
         return  ;
      }

      public bool gxTv_SdtTokens_Tokensexpire_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TokensType_N" )]
      [  XmlElement( ElementName = "TokensType_N"   )]
      public short gxTpr_Tokenstype_N
      {
         get {
            return gxTv_SdtTokens_Tokenstype_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTokens_Tokenstype_N = value;
            SetDirty("Tokenstype_N");
         }

      }

      public void gxTv_SdtTokens_Tokenstype_N_SetNull( )
      {
         gxTv_SdtTokens_Tokenstype_N = 0;
         SetDirty("Tokenstype_N");
         return  ;
      }

      public bool gxTv_SdtTokens_Tokenstype_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TokensDateTime_N" )]
      [  XmlElement( ElementName = "TokensDateTime_N"   )]
      public short gxTpr_Tokensdatetime_N
      {
         get {
            return gxTv_SdtTokens_Tokensdatetime_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTokens_Tokensdatetime_N = value;
            SetDirty("Tokensdatetime_N");
         }

      }

      public void gxTv_SdtTokens_Tokensdatetime_N_SetNull( )
      {
         gxTv_SdtTokens_Tokensdatetime_N = 0;
         SetDirty("Tokensdatetime_N");
         return  ;
      }

      public bool gxTv_SdtTokens_Tokensdatetime_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TokensSalt_N" )]
      [  XmlElement( ElementName = "TokensSalt_N"   )]
      public short gxTpr_Tokenssalt_N
      {
         get {
            return gxTv_SdtTokens_Tokenssalt_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTokens_Tokenssalt_N = value;
            SetDirty("Tokenssalt_N");
         }

      }

      public void gxTv_SdtTokens_Tokenssalt_N_SetNull( )
      {
         gxTv_SdtTokens_Tokenssalt_N = 0;
         SetDirty("Tokenssalt_N");
         return  ;
      }

      public bool gxTv_SdtTokens_Tokenssalt_N_IsNull( )
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
         gxTv_SdtTokens_Tokenscontent = "";
         gxTv_SdtTokens_Tokenstype = "";
         gxTv_SdtTokens_Tokenssalt = "";
         gxTv_SdtTokens_Mode = "";
         gxTv_SdtTokens_Tokenstype_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "tokens", "GeneXus.Programs.tokens_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTokens_Initialized ;
      private short gxTv_SdtTokens_Tokenscontent_N ;
      private short gxTv_SdtTokens_Tokensexpire_N ;
      private short gxTv_SdtTokens_Tokenstype_N ;
      private short gxTv_SdtTokens_Tokensdatetime_N ;
      private short gxTv_SdtTokens_Tokenssalt_N ;
      private int gxTv_SdtTokens_Tokensid ;
      private int gxTv_SdtTokens_Tokensexpire ;
      private int gxTv_SdtTokens_Tokensid_Z ;
      private int gxTv_SdtTokens_Tokensexpire_Z ;
      private long gxTv_SdtTokens_Tokensdatetime ;
      private long gxTv_SdtTokens_Tokensdatetime_Z ;
      private string gxTv_SdtTokens_Mode ;
      private string gxTv_SdtTokens_Tokenscontent ;
      private string gxTv_SdtTokens_Tokenssalt ;
      private string gxTv_SdtTokens_Tokenstype ;
      private string gxTv_SdtTokens_Tokenstype_Z ;
   }

   [DataContract(Name = @"Tokens", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtTokens_RESTInterface : GxGenericCollectionItem<SdtTokens>
   {
      public SdtTokens_RESTInterface( ) : base()
      {
      }

      public SdtTokens_RESTInterface( SdtTokens psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TokensId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Tokensid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Tokensid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Tokensid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "TokensContent" , Order = 1 )]
      public string gxTpr_Tokenscontent
      {
         get {
            return sdt.gxTpr_Tokenscontent ;
         }

         set {
            sdt.gxTpr_Tokenscontent = value;
         }

      }

      [DataMember( Name = "TokensExpire" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Tokensexpire
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Tokensexpire), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Tokensexpire = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "TokensType" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Tokenstype
      {
         get {
            return sdt.gxTpr_Tokenstype ;
         }

         set {
            sdt.gxTpr_Tokenstype = value;
         }

      }

      [DataMember( Name = "TokensDateTime" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Tokensdatetime
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Tokensdatetime), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Tokensdatetime = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "TokensSalt" , Order = 5 )]
      public string gxTpr_Tokenssalt
      {
         get {
            return sdt.gxTpr_Tokenssalt ;
         }

         set {
            sdt.gxTpr_Tokenssalt = value;
         }

      }

      public SdtTokens sdt
      {
         get {
            return (SdtTokens)Sdt ;
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
            sdt = new SdtTokens() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 6 )]
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

   [DataContract(Name = @"Tokens", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtTokens_RESTLInterface : GxGenericCollectionItem<SdtTokens>
   {
      public SdtTokens_RESTLInterface( ) : base()
      {
      }

      public SdtTokens_RESTLInterface( SdtTokens psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TokensExpire" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Tokensexpire
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Tokensexpire), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Tokensexpire = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
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

      public SdtTokens sdt
      {
         get {
            return (SdtTokens)Sdt ;
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
            sdt = new SdtTokens() ;
         }
      }

   }

}
