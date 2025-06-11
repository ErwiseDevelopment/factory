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
   [XmlRoot(ElementName = "ConfiguracoesTestemunhas" )]
   [XmlType(TypeName =  "ConfiguracoesTestemunhas" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtConfiguracoesTestemunhas : GxSilentTrnSdt
   {
      public SdtConfiguracoesTestemunhas( )
      {
      }

      public SdtConfiguracoesTestemunhas( IGxContext context )
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

      public void Load( int AV478ConfiguracoesTestemunhasId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV478ConfiguracoesTestemunhasId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ConfiguracoesTestemunhasId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "ConfiguracoesTestemunhas");
         metadata.Set("BT", "ConfiguracoesTestemunhas");
         metadata.Set("PK", "[ \"ConfiguracoesTestemunhasId\" ]");
         metadata.Set("PKAssigned", "[ \"ConfiguracoesTestemunhasId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"SecUserId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Configuracoestestemunhasid_Z");
         state.Add("gxTpr_Configuracoestestemunhasnome_Z");
         state.Add("gxTpr_Configuracoestestemunhasdocumento_Z");
         state.Add("gxTpr_Configuracoestestemunhasemail_Z");
         state.Add("gxTpr_Secuserid_Z");
         state.Add("gxTpr_Configuracoestestemunhasnome_N");
         state.Add("gxTpr_Configuracoestestemunhasdocumento_N");
         state.Add("gxTpr_Configuracoestestemunhasemail_N");
         state.Add("gxTpr_Secuserid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtConfiguracoesTestemunhas sdt;
         sdt = (SdtConfiguracoesTestemunhas)(source);
         gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasid = sdt.gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasid ;
         gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome = sdt.gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome ;
         gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento = sdt.gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento ;
         gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail = sdt.gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail ;
         gxTv_SdtConfiguracoesTestemunhas_Secuserid = sdt.gxTv_SdtConfiguracoesTestemunhas_Secuserid ;
         gxTv_SdtConfiguracoesTestemunhas_Mode = sdt.gxTv_SdtConfiguracoesTestemunhas_Mode ;
         gxTv_SdtConfiguracoesTestemunhas_Initialized = sdt.gxTv_SdtConfiguracoesTestemunhas_Initialized ;
         gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasid_Z = sdt.gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasid_Z ;
         gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome_Z = sdt.gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome_Z ;
         gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento_Z = sdt.gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento_Z ;
         gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail_Z = sdt.gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail_Z ;
         gxTv_SdtConfiguracoesTestemunhas_Secuserid_Z = sdt.gxTv_SdtConfiguracoesTestemunhas_Secuserid_Z ;
         gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome_N = sdt.gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome_N ;
         gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento_N = sdt.gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento_N ;
         gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail_N = sdt.gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail_N ;
         gxTv_SdtConfiguracoesTestemunhas_Secuserid_N = sdt.gxTv_SdtConfiguracoesTestemunhas_Secuserid_N ;
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
         AddObjectProperty("ConfiguracoesTestemunhasId", gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasid, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesTestemunhasNome", gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesTestemunhasNome_N", gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome_N, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesTestemunhasDocumento", gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesTestemunhasDocumento_N", gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento_N, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesTestemunhasEmail", gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail, false, includeNonInitialized);
         AddObjectProperty("ConfiguracoesTestemunhasEmail_N", gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail_N, false, includeNonInitialized);
         AddObjectProperty("SecUserId", gxTv_SdtConfiguracoesTestemunhas_Secuserid, false, includeNonInitialized);
         AddObjectProperty("SecUserId_N", gxTv_SdtConfiguracoesTestemunhas_Secuserid_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtConfiguracoesTestemunhas_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtConfiguracoesTestemunhas_Initialized, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesTestemunhasId_Z", gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasid_Z, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesTestemunhasNome_Z", gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome_Z, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesTestemunhasDocumento_Z", gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento_Z, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesTestemunhasEmail_Z", gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserId_Z", gxTv_SdtConfiguracoesTestemunhas_Secuserid_Z, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesTestemunhasNome_N", gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome_N, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesTestemunhasDocumento_N", gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento_N, false, includeNonInitialized);
            AddObjectProperty("ConfiguracoesTestemunhasEmail_N", gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail_N, false, includeNonInitialized);
            AddObjectProperty("SecUserId_N", gxTv_SdtConfiguracoesTestemunhas_Secuserid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtConfiguracoesTestemunhas sdt )
      {
         if ( sdt.IsDirty("ConfiguracoesTestemunhasId") )
         {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasid = sdt.gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasid ;
         }
         if ( sdt.IsDirty("ConfiguracoesTestemunhasNome") )
         {
            gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome_N = (short)(sdt.gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome = sdt.gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome ;
         }
         if ( sdt.IsDirty("ConfiguracoesTestemunhasDocumento") )
         {
            gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento_N = (short)(sdt.gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento = sdt.gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento ;
         }
         if ( sdt.IsDirty("ConfiguracoesTestemunhasEmail") )
         {
            gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail_N = (short)(sdt.gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail = sdt.gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail ;
         }
         if ( sdt.IsDirty("SecUserId") )
         {
            gxTv_SdtConfiguracoesTestemunhas_Secuserid_N = (short)(sdt.gxTv_SdtConfiguracoesTestemunhas_Secuserid_N);
            sdtIsNull = 0;
            gxTv_SdtConfiguracoesTestemunhas_Secuserid = sdt.gxTv_SdtConfiguracoesTestemunhas_Secuserid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ConfiguracoesTestemunhasId" )]
      [  XmlElement( ElementName = "ConfiguracoesTestemunhasId"   )]
      public int gxTpr_Configuracoestestemunhasid
      {
         get {
            return gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasid != value )
            {
               gxTv_SdtConfiguracoesTestemunhas_Mode = "INS";
               this.gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasid_Z_SetNull( );
               this.gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome_Z_SetNull( );
               this.gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento_Z_SetNull( );
               this.gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail_Z_SetNull( );
               this.gxTv_SdtConfiguracoesTestemunhas_Secuserid_Z_SetNull( );
            }
            gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasid = value;
            SetDirty("Configuracoestestemunhasid");
         }

      }

      [  SoapElement( ElementName = "ConfiguracoesTestemunhasNome" )]
      [  XmlElement( ElementName = "ConfiguracoesTestemunhasNome"   )]
      public string gxTpr_Configuracoestestemunhasnome
      {
         get {
            return gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome ;
         }

         set {
            gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome = value;
            SetDirty("Configuracoestestemunhasnome");
         }

      }

      public void gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome_SetNull( )
      {
         gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome_N = 1;
         gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome = "";
         SetDirty("Configuracoestestemunhasnome");
         return  ;
      }

      public bool gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome_IsNull( )
      {
         return (gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome_N==1) ;
      }

      [  SoapElement( ElementName = "ConfiguracoesTestemunhasDocumento" )]
      [  XmlElement( ElementName = "ConfiguracoesTestemunhasDocumento"   )]
      public string gxTpr_Configuracoestestemunhasdocumento
      {
         get {
            return gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento ;
         }

         set {
            gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento = value;
            SetDirty("Configuracoestestemunhasdocumento");
         }

      }

      public void gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento_SetNull( )
      {
         gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento_N = 1;
         gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento = "";
         SetDirty("Configuracoestestemunhasdocumento");
         return  ;
      }

      public bool gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento_IsNull( )
      {
         return (gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento_N==1) ;
      }

      [  SoapElement( ElementName = "ConfiguracoesTestemunhasEmail" )]
      [  XmlElement( ElementName = "ConfiguracoesTestemunhasEmail"   )]
      public string gxTpr_Configuracoestestemunhasemail
      {
         get {
            return gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail ;
         }

         set {
            gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail = value;
            SetDirty("Configuracoestestemunhasemail");
         }

      }

      public void gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail_SetNull( )
      {
         gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail_N = 1;
         gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail = "";
         SetDirty("Configuracoestestemunhasemail");
         return  ;
      }

      public bool gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail_IsNull( )
      {
         return (gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserId" )]
      [  XmlElement( ElementName = "SecUserId"   )]
      public short gxTpr_Secuserid
      {
         get {
            return gxTv_SdtConfiguracoesTestemunhas_Secuserid ;
         }

         set {
            gxTv_SdtConfiguracoesTestemunhas_Secuserid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConfiguracoesTestemunhas_Secuserid = value;
            SetDirty("Secuserid");
         }

      }

      public void gxTv_SdtConfiguracoesTestemunhas_Secuserid_SetNull( )
      {
         gxTv_SdtConfiguracoesTestemunhas_Secuserid_N = 1;
         gxTv_SdtConfiguracoesTestemunhas_Secuserid = 0;
         SetDirty("Secuserid");
         return  ;
      }

      public bool gxTv_SdtConfiguracoesTestemunhas_Secuserid_IsNull( )
      {
         return (gxTv_SdtConfiguracoesTestemunhas_Secuserid_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtConfiguracoesTestemunhas_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoesTestemunhas_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtConfiguracoesTestemunhas_Mode_SetNull( )
      {
         gxTv_SdtConfiguracoesTestemunhas_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtConfiguracoesTestemunhas_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtConfiguracoesTestemunhas_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoesTestemunhas_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtConfiguracoesTestemunhas_Initialized_SetNull( )
      {
         gxTv_SdtConfiguracoesTestemunhas_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtConfiguracoesTestemunhas_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesTestemunhasId_Z" )]
      [  XmlElement( ElementName = "ConfiguracoesTestemunhasId_Z"   )]
      public int gxTpr_Configuracoestestemunhasid_Z
      {
         get {
            return gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasid_Z = value;
            SetDirty("Configuracoestestemunhasid_Z");
         }

      }

      public void gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasid_Z_SetNull( )
      {
         gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasid_Z = 0;
         SetDirty("Configuracoestestemunhasid_Z");
         return  ;
      }

      public bool gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesTestemunhasNome_Z" )]
      [  XmlElement( ElementName = "ConfiguracoesTestemunhasNome_Z"   )]
      public string gxTpr_Configuracoestestemunhasnome_Z
      {
         get {
            return gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome_Z = value;
            SetDirty("Configuracoestestemunhasnome_Z");
         }

      }

      public void gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome_Z_SetNull( )
      {
         gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome_Z = "";
         SetDirty("Configuracoestestemunhasnome_Z");
         return  ;
      }

      public bool gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesTestemunhasDocumento_Z" )]
      [  XmlElement( ElementName = "ConfiguracoesTestemunhasDocumento_Z"   )]
      public string gxTpr_Configuracoestestemunhasdocumento_Z
      {
         get {
            return gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento_Z = value;
            SetDirty("Configuracoestestemunhasdocumento_Z");
         }

      }

      public void gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento_Z_SetNull( )
      {
         gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento_Z = "";
         SetDirty("Configuracoestestemunhasdocumento_Z");
         return  ;
      }

      public bool gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesTestemunhasEmail_Z" )]
      [  XmlElement( ElementName = "ConfiguracoesTestemunhasEmail_Z"   )]
      public string gxTpr_Configuracoestestemunhasemail_Z
      {
         get {
            return gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail_Z = value;
            SetDirty("Configuracoestestemunhasemail_Z");
         }

      }

      public void gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail_Z_SetNull( )
      {
         gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail_Z = "";
         SetDirty("Configuracoestestemunhasemail_Z");
         return  ;
      }

      public bool gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserId_Z" )]
      [  XmlElement( ElementName = "SecUserId_Z"   )]
      public short gxTpr_Secuserid_Z
      {
         get {
            return gxTv_SdtConfiguracoesTestemunhas_Secuserid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoesTestemunhas_Secuserid_Z = value;
            SetDirty("Secuserid_Z");
         }

      }

      public void gxTv_SdtConfiguracoesTestemunhas_Secuserid_Z_SetNull( )
      {
         gxTv_SdtConfiguracoesTestemunhas_Secuserid_Z = 0;
         SetDirty("Secuserid_Z");
         return  ;
      }

      public bool gxTv_SdtConfiguracoesTestemunhas_Secuserid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesTestemunhasNome_N" )]
      [  XmlElement( ElementName = "ConfiguracoesTestemunhasNome_N"   )]
      public short gxTpr_Configuracoestestemunhasnome_N
      {
         get {
            return gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome_N = value;
            SetDirty("Configuracoestestemunhasnome_N");
         }

      }

      public void gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome_N_SetNull( )
      {
         gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome_N = 0;
         SetDirty("Configuracoestestemunhasnome_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesTestemunhasDocumento_N" )]
      [  XmlElement( ElementName = "ConfiguracoesTestemunhasDocumento_N"   )]
      public short gxTpr_Configuracoestestemunhasdocumento_N
      {
         get {
            return gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento_N = value;
            SetDirty("Configuracoestestemunhasdocumento_N");
         }

      }

      public void gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento_N_SetNull( )
      {
         gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento_N = 0;
         SetDirty("Configuracoestestemunhasdocumento_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConfiguracoesTestemunhasEmail_N" )]
      [  XmlElement( ElementName = "ConfiguracoesTestemunhasEmail_N"   )]
      public short gxTpr_Configuracoestestemunhasemail_N
      {
         get {
            return gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail_N = value;
            SetDirty("Configuracoestestemunhasemail_N");
         }

      }

      public void gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail_N_SetNull( )
      {
         gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail_N = 0;
         SetDirty("Configuracoestestemunhasemail_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserId_N" )]
      [  XmlElement( ElementName = "SecUserId_N"   )]
      public short gxTpr_Secuserid_N
      {
         get {
            return gxTv_SdtConfiguracoesTestemunhas_Secuserid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConfiguracoesTestemunhas_Secuserid_N = value;
            SetDirty("Secuserid_N");
         }

      }

      public void gxTv_SdtConfiguracoesTestemunhas_Secuserid_N_SetNull( )
      {
         gxTv_SdtConfiguracoesTestemunhas_Secuserid_N = 0;
         SetDirty("Secuserid_N");
         return  ;
      }

      public bool gxTv_SdtConfiguracoesTestemunhas_Secuserid_N_IsNull( )
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
         gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome = "";
         gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento = "";
         gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail = "";
         gxTv_SdtConfiguracoesTestemunhas_Mode = "";
         gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome_Z = "";
         gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento_Z = "";
         gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "configuracoestestemunhas", "GeneXus.Programs.configuracoestestemunhas_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtConfiguracoesTestemunhas_Secuserid ;
      private short gxTv_SdtConfiguracoesTestemunhas_Initialized ;
      private short gxTv_SdtConfiguracoesTestemunhas_Secuserid_Z ;
      private short gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome_N ;
      private short gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento_N ;
      private short gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail_N ;
      private short gxTv_SdtConfiguracoesTestemunhas_Secuserid_N ;
      private int gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasid ;
      private int gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasid_Z ;
      private string gxTv_SdtConfiguracoesTestemunhas_Mode ;
      private string gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome ;
      private string gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento ;
      private string gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail ;
      private string gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasnome_Z ;
      private string gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasdocumento_Z ;
      private string gxTv_SdtConfiguracoesTestemunhas_Configuracoestestemunhasemail_Z ;
   }

   [DataContract(Name = @"ConfiguracoesTestemunhas", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtConfiguracoesTestemunhas_RESTInterface : GxGenericCollectionItem<SdtConfiguracoesTestemunhas>
   {
      public SdtConfiguracoesTestemunhas_RESTInterface( ) : base()
      {
      }

      public SdtConfiguracoesTestemunhas_RESTInterface( SdtConfiguracoesTestemunhas psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ConfiguracoesTestemunhasId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Configuracoestestemunhasid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Configuracoestestemunhasid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Configuracoestestemunhasid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ConfiguracoesTestemunhasNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Configuracoestestemunhasnome
      {
         get {
            return sdt.gxTpr_Configuracoestestemunhasnome ;
         }

         set {
            sdt.gxTpr_Configuracoestestemunhasnome = value;
         }

      }

      [DataMember( Name = "ConfiguracoesTestemunhasDocumento" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Configuracoestestemunhasdocumento
      {
         get {
            return sdt.gxTpr_Configuracoestestemunhasdocumento ;
         }

         set {
            sdt.gxTpr_Configuracoestestemunhasdocumento = value;
         }

      }

      [DataMember( Name = "ConfiguracoesTestemunhasEmail" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Configuracoestestemunhasemail
      {
         get {
            return sdt.gxTpr_Configuracoestestemunhasemail ;
         }

         set {
            sdt.gxTpr_Configuracoestestemunhasemail = value;
         }

      }

      [DataMember( Name = "SecUserId" , Order = 4 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Secuserid
      {
         get {
            return sdt.gxTpr_Secuserid ;
         }

         set {
            sdt.gxTpr_Secuserid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtConfiguracoesTestemunhas sdt
      {
         get {
            return (SdtConfiguracoesTestemunhas)Sdt ;
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
            sdt = new SdtConfiguracoesTestemunhas() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 5 )]
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

   [DataContract(Name = @"ConfiguracoesTestemunhas", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtConfiguracoesTestemunhas_RESTLInterface : GxGenericCollectionItem<SdtConfiguracoesTestemunhas>
   {
      public SdtConfiguracoesTestemunhas_RESTLInterface( ) : base()
      {
      }

      public SdtConfiguracoesTestemunhas_RESTLInterface( SdtConfiguracoesTestemunhas psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ConfiguracoesTestemunhasNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Configuracoestestemunhasnome
      {
         get {
            return sdt.gxTpr_Configuracoestestemunhasnome ;
         }

         set {
            sdt.gxTpr_Configuracoestestemunhasnome = value;
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

      public SdtConfiguracoesTestemunhas sdt
      {
         get {
            return (SdtConfiguracoesTestemunhas)Sdt ;
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
            sdt = new SdtConfiguracoesTestemunhas() ;
         }
      }

   }

}
