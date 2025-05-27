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
   [XmlRoot(ElementName = "WebService" )]
   [XmlType(TypeName =  "WebService" , Namespace = "Factory2" )]
   [Serializable]
   public class SdtWebService : GxSilentTrnSdt
   {
      public SdtWebService( )
      {
      }

      public SdtWebService( IGxContext context )
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

      public void Load( int AV656WebServiceId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV656WebServiceId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"WebServiceId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "WebService");
         metadata.Set("BT", "WebService");
         metadata.Set("PK", "[ \"WebServiceId\" ]");
         metadata.Set("PKAssigned", "[ \"WebServiceId\" ]");
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
         state.Add("gxTpr_Webserviceid_Z");
         state.Add("gxTpr_Webservicetipodmws_Z");
         state.Add("gxTpr_Webserviceendpoint_Z");
         state.Add("gxTpr_Webserviceauthtipo_Z");
         state.Add("gxTpr_Webserviceusuario_Z");
         state.Add("gxTpr_Webservicesenha_Z");
         state.Add("gxTpr_Webservicetipodmws_N");
         state.Add("gxTpr_Webserviceendpoint_N");
         state.Add("gxTpr_Webserviceauthtipo_N");
         state.Add("gxTpr_Webserviceusuario_N");
         state.Add("gxTpr_Webservicesenha_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtWebService sdt;
         sdt = (SdtWebService)(source);
         gxTv_SdtWebService_Webserviceid = sdt.gxTv_SdtWebService_Webserviceid ;
         gxTv_SdtWebService_Webservicetipodmws = sdt.gxTv_SdtWebService_Webservicetipodmws ;
         gxTv_SdtWebService_Webserviceendpoint = sdt.gxTv_SdtWebService_Webserviceendpoint ;
         gxTv_SdtWebService_Webserviceauthtipo = sdt.gxTv_SdtWebService_Webserviceauthtipo ;
         gxTv_SdtWebService_Webserviceusuario = sdt.gxTv_SdtWebService_Webserviceusuario ;
         gxTv_SdtWebService_Webservicesenha = sdt.gxTv_SdtWebService_Webservicesenha ;
         gxTv_SdtWebService_Mode = sdt.gxTv_SdtWebService_Mode ;
         gxTv_SdtWebService_Initialized = sdt.gxTv_SdtWebService_Initialized ;
         gxTv_SdtWebService_Webserviceid_Z = sdt.gxTv_SdtWebService_Webserviceid_Z ;
         gxTv_SdtWebService_Webservicetipodmws_Z = sdt.gxTv_SdtWebService_Webservicetipodmws_Z ;
         gxTv_SdtWebService_Webserviceendpoint_Z = sdt.gxTv_SdtWebService_Webserviceendpoint_Z ;
         gxTv_SdtWebService_Webserviceauthtipo_Z = sdt.gxTv_SdtWebService_Webserviceauthtipo_Z ;
         gxTv_SdtWebService_Webserviceusuario_Z = sdt.gxTv_SdtWebService_Webserviceusuario_Z ;
         gxTv_SdtWebService_Webservicesenha_Z = sdt.gxTv_SdtWebService_Webservicesenha_Z ;
         gxTv_SdtWebService_Webservicetipodmws_N = sdt.gxTv_SdtWebService_Webservicetipodmws_N ;
         gxTv_SdtWebService_Webserviceendpoint_N = sdt.gxTv_SdtWebService_Webserviceendpoint_N ;
         gxTv_SdtWebService_Webserviceauthtipo_N = sdt.gxTv_SdtWebService_Webserviceauthtipo_N ;
         gxTv_SdtWebService_Webserviceusuario_N = sdt.gxTv_SdtWebService_Webserviceusuario_N ;
         gxTv_SdtWebService_Webservicesenha_N = sdt.gxTv_SdtWebService_Webservicesenha_N ;
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
         AddObjectProperty("WebServiceId", gxTv_SdtWebService_Webserviceid, false, includeNonInitialized);
         AddObjectProperty("WebServiceTipoDmWS", gxTv_SdtWebService_Webservicetipodmws, false, includeNonInitialized);
         AddObjectProperty("WebServiceTipoDmWS_N", gxTv_SdtWebService_Webservicetipodmws_N, false, includeNonInitialized);
         AddObjectProperty("WebServiceEndPoint", gxTv_SdtWebService_Webserviceendpoint, false, includeNonInitialized);
         AddObjectProperty("WebServiceEndPoint_N", gxTv_SdtWebService_Webserviceendpoint_N, false, includeNonInitialized);
         AddObjectProperty("WebServiceAuthTipo", gxTv_SdtWebService_Webserviceauthtipo, false, includeNonInitialized);
         AddObjectProperty("WebServiceAuthTipo_N", gxTv_SdtWebService_Webserviceauthtipo_N, false, includeNonInitialized);
         AddObjectProperty("WebServiceUsuario", gxTv_SdtWebService_Webserviceusuario, false, includeNonInitialized);
         AddObjectProperty("WebServiceUsuario_N", gxTv_SdtWebService_Webserviceusuario_N, false, includeNonInitialized);
         AddObjectProperty("WebServiceSenha", gxTv_SdtWebService_Webservicesenha, false, includeNonInitialized);
         AddObjectProperty("WebServiceSenha_N", gxTv_SdtWebService_Webservicesenha_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtWebService_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtWebService_Initialized, false, includeNonInitialized);
            AddObjectProperty("WebServiceId_Z", gxTv_SdtWebService_Webserviceid_Z, false, includeNonInitialized);
            AddObjectProperty("WebServiceTipoDmWS_Z", gxTv_SdtWebService_Webservicetipodmws_Z, false, includeNonInitialized);
            AddObjectProperty("WebServiceEndPoint_Z", gxTv_SdtWebService_Webserviceendpoint_Z, false, includeNonInitialized);
            AddObjectProperty("WebServiceAuthTipo_Z", gxTv_SdtWebService_Webserviceauthtipo_Z, false, includeNonInitialized);
            AddObjectProperty("WebServiceUsuario_Z", gxTv_SdtWebService_Webserviceusuario_Z, false, includeNonInitialized);
            AddObjectProperty("WebServiceSenha_Z", gxTv_SdtWebService_Webservicesenha_Z, false, includeNonInitialized);
            AddObjectProperty("WebServiceTipoDmWS_N", gxTv_SdtWebService_Webservicetipodmws_N, false, includeNonInitialized);
            AddObjectProperty("WebServiceEndPoint_N", gxTv_SdtWebService_Webserviceendpoint_N, false, includeNonInitialized);
            AddObjectProperty("WebServiceAuthTipo_N", gxTv_SdtWebService_Webserviceauthtipo_N, false, includeNonInitialized);
            AddObjectProperty("WebServiceUsuario_N", gxTv_SdtWebService_Webserviceusuario_N, false, includeNonInitialized);
            AddObjectProperty("WebServiceSenha_N", gxTv_SdtWebService_Webservicesenha_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtWebService sdt )
      {
         if ( sdt.IsDirty("WebServiceId") )
         {
            sdtIsNull = 0;
            gxTv_SdtWebService_Webserviceid = sdt.gxTv_SdtWebService_Webserviceid ;
         }
         if ( sdt.IsDirty("WebServiceTipoDmWS") )
         {
            gxTv_SdtWebService_Webservicetipodmws_N = (short)(sdt.gxTv_SdtWebService_Webservicetipodmws_N);
            sdtIsNull = 0;
            gxTv_SdtWebService_Webservicetipodmws = sdt.gxTv_SdtWebService_Webservicetipodmws ;
         }
         if ( sdt.IsDirty("WebServiceEndPoint") )
         {
            gxTv_SdtWebService_Webserviceendpoint_N = (short)(sdt.gxTv_SdtWebService_Webserviceendpoint_N);
            sdtIsNull = 0;
            gxTv_SdtWebService_Webserviceendpoint = sdt.gxTv_SdtWebService_Webserviceendpoint ;
         }
         if ( sdt.IsDirty("WebServiceAuthTipo") )
         {
            gxTv_SdtWebService_Webserviceauthtipo_N = (short)(sdt.gxTv_SdtWebService_Webserviceauthtipo_N);
            sdtIsNull = 0;
            gxTv_SdtWebService_Webserviceauthtipo = sdt.gxTv_SdtWebService_Webserviceauthtipo ;
         }
         if ( sdt.IsDirty("WebServiceUsuario") )
         {
            gxTv_SdtWebService_Webserviceusuario_N = (short)(sdt.gxTv_SdtWebService_Webserviceusuario_N);
            sdtIsNull = 0;
            gxTv_SdtWebService_Webserviceusuario = sdt.gxTv_SdtWebService_Webserviceusuario ;
         }
         if ( sdt.IsDirty("WebServiceSenha") )
         {
            gxTv_SdtWebService_Webservicesenha_N = (short)(sdt.gxTv_SdtWebService_Webservicesenha_N);
            sdtIsNull = 0;
            gxTv_SdtWebService_Webservicesenha = sdt.gxTv_SdtWebService_Webservicesenha ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "WebServiceId" )]
      [  XmlElement( ElementName = "WebServiceId"   )]
      public int gxTpr_Webserviceid
      {
         get {
            return gxTv_SdtWebService_Webserviceid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtWebService_Webserviceid != value )
            {
               gxTv_SdtWebService_Mode = "INS";
               this.gxTv_SdtWebService_Webserviceid_Z_SetNull( );
               this.gxTv_SdtWebService_Webservicetipodmws_Z_SetNull( );
               this.gxTv_SdtWebService_Webserviceendpoint_Z_SetNull( );
               this.gxTv_SdtWebService_Webserviceauthtipo_Z_SetNull( );
               this.gxTv_SdtWebService_Webserviceusuario_Z_SetNull( );
               this.gxTv_SdtWebService_Webservicesenha_Z_SetNull( );
            }
            gxTv_SdtWebService_Webserviceid = value;
            SetDirty("Webserviceid");
         }

      }

      [  SoapElement( ElementName = "WebServiceTipoDmWS" )]
      [  XmlElement( ElementName = "WebServiceTipoDmWS"   )]
      public string gxTpr_Webservicetipodmws
      {
         get {
            return gxTv_SdtWebService_Webservicetipodmws ;
         }

         set {
            gxTv_SdtWebService_Webservicetipodmws_N = 0;
            sdtIsNull = 0;
            gxTv_SdtWebService_Webservicetipodmws = value;
            SetDirty("Webservicetipodmws");
         }

      }

      public void gxTv_SdtWebService_Webservicetipodmws_SetNull( )
      {
         gxTv_SdtWebService_Webservicetipodmws_N = 1;
         gxTv_SdtWebService_Webservicetipodmws = "";
         SetDirty("Webservicetipodmws");
         return  ;
      }

      public bool gxTv_SdtWebService_Webservicetipodmws_IsNull( )
      {
         return (gxTv_SdtWebService_Webservicetipodmws_N==1) ;
      }

      [  SoapElement( ElementName = "WebServiceEndPoint" )]
      [  XmlElement( ElementName = "WebServiceEndPoint"   )]
      public string gxTpr_Webserviceendpoint
      {
         get {
            return gxTv_SdtWebService_Webserviceendpoint ;
         }

         set {
            gxTv_SdtWebService_Webserviceendpoint_N = 0;
            sdtIsNull = 0;
            gxTv_SdtWebService_Webserviceendpoint = value;
            SetDirty("Webserviceendpoint");
         }

      }

      public void gxTv_SdtWebService_Webserviceendpoint_SetNull( )
      {
         gxTv_SdtWebService_Webserviceendpoint_N = 1;
         gxTv_SdtWebService_Webserviceendpoint = "";
         SetDirty("Webserviceendpoint");
         return  ;
      }

      public bool gxTv_SdtWebService_Webserviceendpoint_IsNull( )
      {
         return (gxTv_SdtWebService_Webserviceendpoint_N==1) ;
      }

      [  SoapElement( ElementName = "WebServiceAuthTipo" )]
      [  XmlElement( ElementName = "WebServiceAuthTipo"   )]
      public string gxTpr_Webserviceauthtipo
      {
         get {
            return gxTv_SdtWebService_Webserviceauthtipo ;
         }

         set {
            gxTv_SdtWebService_Webserviceauthtipo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtWebService_Webserviceauthtipo = value;
            SetDirty("Webserviceauthtipo");
         }

      }

      public void gxTv_SdtWebService_Webserviceauthtipo_SetNull( )
      {
         gxTv_SdtWebService_Webserviceauthtipo_N = 1;
         gxTv_SdtWebService_Webserviceauthtipo = "";
         SetDirty("Webserviceauthtipo");
         return  ;
      }

      public bool gxTv_SdtWebService_Webserviceauthtipo_IsNull( )
      {
         return (gxTv_SdtWebService_Webserviceauthtipo_N==1) ;
      }

      [  SoapElement( ElementName = "WebServiceUsuario" )]
      [  XmlElement( ElementName = "WebServiceUsuario"   )]
      public string gxTpr_Webserviceusuario
      {
         get {
            return gxTv_SdtWebService_Webserviceusuario ;
         }

         set {
            gxTv_SdtWebService_Webserviceusuario_N = 0;
            sdtIsNull = 0;
            gxTv_SdtWebService_Webserviceusuario = value;
            SetDirty("Webserviceusuario");
         }

      }

      public void gxTv_SdtWebService_Webserviceusuario_SetNull( )
      {
         gxTv_SdtWebService_Webserviceusuario_N = 1;
         gxTv_SdtWebService_Webserviceusuario = "";
         SetDirty("Webserviceusuario");
         return  ;
      }

      public bool gxTv_SdtWebService_Webserviceusuario_IsNull( )
      {
         return (gxTv_SdtWebService_Webserviceusuario_N==1) ;
      }

      [  SoapElement( ElementName = "WebServiceSenha" )]
      [  XmlElement( ElementName = "WebServiceSenha"   )]
      public string gxTpr_Webservicesenha
      {
         get {
            return gxTv_SdtWebService_Webservicesenha ;
         }

         set {
            gxTv_SdtWebService_Webservicesenha_N = 0;
            sdtIsNull = 0;
            gxTv_SdtWebService_Webservicesenha = value;
            SetDirty("Webservicesenha");
         }

      }

      public void gxTv_SdtWebService_Webservicesenha_SetNull( )
      {
         gxTv_SdtWebService_Webservicesenha_N = 1;
         gxTv_SdtWebService_Webservicesenha = "";
         SetDirty("Webservicesenha");
         return  ;
      }

      public bool gxTv_SdtWebService_Webservicesenha_IsNull( )
      {
         return (gxTv_SdtWebService_Webservicesenha_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtWebService_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWebService_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtWebService_Mode_SetNull( )
      {
         gxTv_SdtWebService_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtWebService_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtWebService_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWebService_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtWebService_Initialized_SetNull( )
      {
         gxTv_SdtWebService_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtWebService_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WebServiceId_Z" )]
      [  XmlElement( ElementName = "WebServiceId_Z"   )]
      public int gxTpr_Webserviceid_Z
      {
         get {
            return gxTv_SdtWebService_Webserviceid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWebService_Webserviceid_Z = value;
            SetDirty("Webserviceid_Z");
         }

      }

      public void gxTv_SdtWebService_Webserviceid_Z_SetNull( )
      {
         gxTv_SdtWebService_Webserviceid_Z = 0;
         SetDirty("Webserviceid_Z");
         return  ;
      }

      public bool gxTv_SdtWebService_Webserviceid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WebServiceTipoDmWS_Z" )]
      [  XmlElement( ElementName = "WebServiceTipoDmWS_Z"   )]
      public string gxTpr_Webservicetipodmws_Z
      {
         get {
            return gxTv_SdtWebService_Webservicetipodmws_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWebService_Webservicetipodmws_Z = value;
            SetDirty("Webservicetipodmws_Z");
         }

      }

      public void gxTv_SdtWebService_Webservicetipodmws_Z_SetNull( )
      {
         gxTv_SdtWebService_Webservicetipodmws_Z = "";
         SetDirty("Webservicetipodmws_Z");
         return  ;
      }

      public bool gxTv_SdtWebService_Webservicetipodmws_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WebServiceEndPoint_Z" )]
      [  XmlElement( ElementName = "WebServiceEndPoint_Z"   )]
      public string gxTpr_Webserviceendpoint_Z
      {
         get {
            return gxTv_SdtWebService_Webserviceendpoint_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWebService_Webserviceendpoint_Z = value;
            SetDirty("Webserviceendpoint_Z");
         }

      }

      public void gxTv_SdtWebService_Webserviceendpoint_Z_SetNull( )
      {
         gxTv_SdtWebService_Webserviceendpoint_Z = "";
         SetDirty("Webserviceendpoint_Z");
         return  ;
      }

      public bool gxTv_SdtWebService_Webserviceendpoint_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WebServiceAuthTipo_Z" )]
      [  XmlElement( ElementName = "WebServiceAuthTipo_Z"   )]
      public string gxTpr_Webserviceauthtipo_Z
      {
         get {
            return gxTv_SdtWebService_Webserviceauthtipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWebService_Webserviceauthtipo_Z = value;
            SetDirty("Webserviceauthtipo_Z");
         }

      }

      public void gxTv_SdtWebService_Webserviceauthtipo_Z_SetNull( )
      {
         gxTv_SdtWebService_Webserviceauthtipo_Z = "";
         SetDirty("Webserviceauthtipo_Z");
         return  ;
      }

      public bool gxTv_SdtWebService_Webserviceauthtipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WebServiceUsuario_Z" )]
      [  XmlElement( ElementName = "WebServiceUsuario_Z"   )]
      public string gxTpr_Webserviceusuario_Z
      {
         get {
            return gxTv_SdtWebService_Webserviceusuario_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWebService_Webserviceusuario_Z = value;
            SetDirty("Webserviceusuario_Z");
         }

      }

      public void gxTv_SdtWebService_Webserviceusuario_Z_SetNull( )
      {
         gxTv_SdtWebService_Webserviceusuario_Z = "";
         SetDirty("Webserviceusuario_Z");
         return  ;
      }

      public bool gxTv_SdtWebService_Webserviceusuario_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WebServiceSenha_Z" )]
      [  XmlElement( ElementName = "WebServiceSenha_Z"   )]
      public string gxTpr_Webservicesenha_Z
      {
         get {
            return gxTv_SdtWebService_Webservicesenha_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWebService_Webservicesenha_Z = value;
            SetDirty("Webservicesenha_Z");
         }

      }

      public void gxTv_SdtWebService_Webservicesenha_Z_SetNull( )
      {
         gxTv_SdtWebService_Webservicesenha_Z = "";
         SetDirty("Webservicesenha_Z");
         return  ;
      }

      public bool gxTv_SdtWebService_Webservicesenha_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WebServiceTipoDmWS_N" )]
      [  XmlElement( ElementName = "WebServiceTipoDmWS_N"   )]
      public short gxTpr_Webservicetipodmws_N
      {
         get {
            return gxTv_SdtWebService_Webservicetipodmws_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWebService_Webservicetipodmws_N = value;
            SetDirty("Webservicetipodmws_N");
         }

      }

      public void gxTv_SdtWebService_Webservicetipodmws_N_SetNull( )
      {
         gxTv_SdtWebService_Webservicetipodmws_N = 0;
         SetDirty("Webservicetipodmws_N");
         return  ;
      }

      public bool gxTv_SdtWebService_Webservicetipodmws_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WebServiceEndPoint_N" )]
      [  XmlElement( ElementName = "WebServiceEndPoint_N"   )]
      public short gxTpr_Webserviceendpoint_N
      {
         get {
            return gxTv_SdtWebService_Webserviceendpoint_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWebService_Webserviceendpoint_N = value;
            SetDirty("Webserviceendpoint_N");
         }

      }

      public void gxTv_SdtWebService_Webserviceendpoint_N_SetNull( )
      {
         gxTv_SdtWebService_Webserviceendpoint_N = 0;
         SetDirty("Webserviceendpoint_N");
         return  ;
      }

      public bool gxTv_SdtWebService_Webserviceendpoint_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WebServiceAuthTipo_N" )]
      [  XmlElement( ElementName = "WebServiceAuthTipo_N"   )]
      public short gxTpr_Webserviceauthtipo_N
      {
         get {
            return gxTv_SdtWebService_Webserviceauthtipo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWebService_Webserviceauthtipo_N = value;
            SetDirty("Webserviceauthtipo_N");
         }

      }

      public void gxTv_SdtWebService_Webserviceauthtipo_N_SetNull( )
      {
         gxTv_SdtWebService_Webserviceauthtipo_N = 0;
         SetDirty("Webserviceauthtipo_N");
         return  ;
      }

      public bool gxTv_SdtWebService_Webserviceauthtipo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WebServiceUsuario_N" )]
      [  XmlElement( ElementName = "WebServiceUsuario_N"   )]
      public short gxTpr_Webserviceusuario_N
      {
         get {
            return gxTv_SdtWebService_Webserviceusuario_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWebService_Webserviceusuario_N = value;
            SetDirty("Webserviceusuario_N");
         }

      }

      public void gxTv_SdtWebService_Webserviceusuario_N_SetNull( )
      {
         gxTv_SdtWebService_Webserviceusuario_N = 0;
         SetDirty("Webserviceusuario_N");
         return  ;
      }

      public bool gxTv_SdtWebService_Webserviceusuario_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WebServiceSenha_N" )]
      [  XmlElement( ElementName = "WebServiceSenha_N"   )]
      public short gxTpr_Webservicesenha_N
      {
         get {
            return gxTv_SdtWebService_Webservicesenha_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWebService_Webservicesenha_N = value;
            SetDirty("Webservicesenha_N");
         }

      }

      public void gxTv_SdtWebService_Webservicesenha_N_SetNull( )
      {
         gxTv_SdtWebService_Webservicesenha_N = 0;
         SetDirty("Webservicesenha_N");
         return  ;
      }

      public bool gxTv_SdtWebService_Webservicesenha_N_IsNull( )
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
         gxTv_SdtWebService_Webservicetipodmws = "";
         gxTv_SdtWebService_Webserviceendpoint = "";
         gxTv_SdtWebService_Webserviceauthtipo = "";
         gxTv_SdtWebService_Webserviceusuario = "";
         gxTv_SdtWebService_Webservicesenha = "";
         gxTv_SdtWebService_Mode = "";
         gxTv_SdtWebService_Webservicetipodmws_Z = "";
         gxTv_SdtWebService_Webserviceendpoint_Z = "";
         gxTv_SdtWebService_Webserviceauthtipo_Z = "";
         gxTv_SdtWebService_Webserviceusuario_Z = "";
         gxTv_SdtWebService_Webservicesenha_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "webservice", "GeneXus.Programs.webservice_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtWebService_Initialized ;
      private short gxTv_SdtWebService_Webservicetipodmws_N ;
      private short gxTv_SdtWebService_Webserviceendpoint_N ;
      private short gxTv_SdtWebService_Webserviceauthtipo_N ;
      private short gxTv_SdtWebService_Webserviceusuario_N ;
      private short gxTv_SdtWebService_Webservicesenha_N ;
      private int gxTv_SdtWebService_Webserviceid ;
      private int gxTv_SdtWebService_Webserviceid_Z ;
      private string gxTv_SdtWebService_Mode ;
      private string gxTv_SdtWebService_Webservicetipodmws ;
      private string gxTv_SdtWebService_Webserviceendpoint ;
      private string gxTv_SdtWebService_Webserviceauthtipo ;
      private string gxTv_SdtWebService_Webserviceusuario ;
      private string gxTv_SdtWebService_Webservicesenha ;
      private string gxTv_SdtWebService_Webservicetipodmws_Z ;
      private string gxTv_SdtWebService_Webserviceendpoint_Z ;
      private string gxTv_SdtWebService_Webserviceauthtipo_Z ;
      private string gxTv_SdtWebService_Webserviceusuario_Z ;
      private string gxTv_SdtWebService_Webservicesenha_Z ;
   }

   [DataContract(Name = @"WebService", Namespace = "Factory2")]
   [GxJsonSerialization("default")]
   public class SdtWebService_RESTInterface : GxGenericCollectionItem<SdtWebService>
   {
      public SdtWebService_RESTInterface( ) : base()
      {
      }

      public SdtWebService_RESTInterface( SdtWebService psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WebServiceId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Webserviceid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Webserviceid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Webserviceid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "WebServiceTipoDmWS" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Webservicetipodmws
      {
         get {
            return sdt.gxTpr_Webservicetipodmws ;
         }

         set {
            sdt.gxTpr_Webservicetipodmws = value;
         }

      }

      [DataMember( Name = "WebServiceEndPoint" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Webserviceendpoint
      {
         get {
            return sdt.gxTpr_Webserviceendpoint ;
         }

         set {
            sdt.gxTpr_Webserviceendpoint = value;
         }

      }

      [DataMember( Name = "WebServiceAuthTipo" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Webserviceauthtipo
      {
         get {
            return sdt.gxTpr_Webserviceauthtipo ;
         }

         set {
            sdt.gxTpr_Webserviceauthtipo = value;
         }

      }

      [DataMember( Name = "WebServiceUsuario" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Webserviceusuario
      {
         get {
            return sdt.gxTpr_Webserviceusuario ;
         }

         set {
            sdt.gxTpr_Webserviceusuario = value;
         }

      }

      [DataMember( Name = "WebServiceSenha" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Webservicesenha
      {
         get {
            return sdt.gxTpr_Webservicesenha ;
         }

         set {
            sdt.gxTpr_Webservicesenha = value;
         }

      }

      public SdtWebService sdt
      {
         get {
            return (SdtWebService)Sdt ;
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
            sdt = new SdtWebService() ;
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

   [DataContract(Name = @"WebService", Namespace = "Factory2")]
   [GxJsonSerialization("default")]
   public class SdtWebService_RESTLInterface : GxGenericCollectionItem<SdtWebService>
   {
      public SdtWebService_RESTLInterface( ) : base()
      {
      }

      public SdtWebService_RESTLInterface( SdtWebService psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WebServiceTipoDmWS" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Webservicetipodmws
      {
         get {
            return sdt.gxTpr_Webservicetipodmws ;
         }

         set {
            sdt.gxTpr_Webservicetipodmws = value;
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

      public SdtWebService sdt
      {
         get {
            return (SdtWebService)Sdt ;
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
            sdt = new SdtWebService() ;
         }
      }

   }

}
