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
   [XmlType(TypeName =  "WebService" , Namespace = "Factory21" )]
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
         state.Add("gxTpr_Webservicetipodmws_N");
         state.Add("gxTpr_Webserviceendpoint_N");
         state.Add("gxTpr_Webserviceauthtipo_N");
         state.Add("gxTpr_Webserviceusuario_N");
         state.Add("gxTpr_Webservicesenha_N");
         state.Add("gxTpr_Webservicesalt_N");
         state.Add("gxTpr_Webservicecertificadobase64_N");
         state.Add("gxTpr_Webservicecertificadopass_N");
         state.Add("gxTpr_Webserviceclientid_N");
         state.Add("gxTpr_Webserviceclientsecret_N");
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
         gxTv_SdtWebService_Webservicesalt = sdt.gxTv_SdtWebService_Webservicesalt ;
         gxTv_SdtWebService_Webservicecertificadobase64 = sdt.gxTv_SdtWebService_Webservicecertificadobase64 ;
         gxTv_SdtWebService_Webservicecertificadopass = sdt.gxTv_SdtWebService_Webservicecertificadopass ;
         gxTv_SdtWebService_Webserviceclientid = sdt.gxTv_SdtWebService_Webserviceclientid ;
         gxTv_SdtWebService_Webserviceclientsecret = sdt.gxTv_SdtWebService_Webserviceclientsecret ;
         gxTv_SdtWebService_Webserviceendpointdecrypted = sdt.gxTv_SdtWebService_Webserviceendpointdecrypted ;
         gxTv_SdtWebService_Webserviceauthtipodecrypted = sdt.gxTv_SdtWebService_Webserviceauthtipodecrypted ;
         gxTv_SdtWebService_Webserviceusuariodecrypted = sdt.gxTv_SdtWebService_Webserviceusuariodecrypted ;
         gxTv_SdtWebService_Webservicesenhadecrypted = sdt.gxTv_SdtWebService_Webservicesenhadecrypted ;
         gxTv_SdtWebService_Webservicecertificadobase64decrypted = sdt.gxTv_SdtWebService_Webservicecertificadobase64decrypted ;
         gxTv_SdtWebService_Webservicecertificadopassdecrypted = sdt.gxTv_SdtWebService_Webservicecertificadopassdecrypted ;
         gxTv_SdtWebService_Webserviceclientiddecrypted = sdt.gxTv_SdtWebService_Webserviceclientiddecrypted ;
         gxTv_SdtWebService_Webserviceclientsecretdecrypted = sdt.gxTv_SdtWebService_Webserviceclientsecretdecrypted ;
         gxTv_SdtWebService_Mode = sdt.gxTv_SdtWebService_Mode ;
         gxTv_SdtWebService_Initialized = sdt.gxTv_SdtWebService_Initialized ;
         gxTv_SdtWebService_Webserviceid_Z = sdt.gxTv_SdtWebService_Webserviceid_Z ;
         gxTv_SdtWebService_Webservicetipodmws_Z = sdt.gxTv_SdtWebService_Webservicetipodmws_Z ;
         gxTv_SdtWebService_Webservicetipodmws_N = sdt.gxTv_SdtWebService_Webservicetipodmws_N ;
         gxTv_SdtWebService_Webserviceendpoint_N = sdt.gxTv_SdtWebService_Webserviceendpoint_N ;
         gxTv_SdtWebService_Webserviceauthtipo_N = sdt.gxTv_SdtWebService_Webserviceauthtipo_N ;
         gxTv_SdtWebService_Webserviceusuario_N = sdt.gxTv_SdtWebService_Webserviceusuario_N ;
         gxTv_SdtWebService_Webservicesenha_N = sdt.gxTv_SdtWebService_Webservicesenha_N ;
         gxTv_SdtWebService_Webservicesalt_N = sdt.gxTv_SdtWebService_Webservicesalt_N ;
         gxTv_SdtWebService_Webservicecertificadobase64_N = sdt.gxTv_SdtWebService_Webservicecertificadobase64_N ;
         gxTv_SdtWebService_Webservicecertificadopass_N = sdt.gxTv_SdtWebService_Webservicecertificadopass_N ;
         gxTv_SdtWebService_Webserviceclientid_N = sdt.gxTv_SdtWebService_Webserviceclientid_N ;
         gxTv_SdtWebService_Webserviceclientsecret_N = sdt.gxTv_SdtWebService_Webserviceclientsecret_N ;
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
         AddObjectProperty("WebServiceSalt", gxTv_SdtWebService_Webservicesalt, false, includeNonInitialized);
         AddObjectProperty("WebServiceSalt_N", gxTv_SdtWebService_Webservicesalt_N, false, includeNonInitialized);
         AddObjectProperty("WebServiceCertificadoBase64", gxTv_SdtWebService_Webservicecertificadobase64, false, includeNonInitialized);
         AddObjectProperty("WebServiceCertificadoBase64_N", gxTv_SdtWebService_Webservicecertificadobase64_N, false, includeNonInitialized);
         AddObjectProperty("WebServiceCertificadoPass", gxTv_SdtWebService_Webservicecertificadopass, false, includeNonInitialized);
         AddObjectProperty("WebServiceCertificadoPass_N", gxTv_SdtWebService_Webservicecertificadopass_N, false, includeNonInitialized);
         AddObjectProperty("WebServiceClientid", gxTv_SdtWebService_Webserviceclientid, false, includeNonInitialized);
         AddObjectProperty("WebServiceClientid_N", gxTv_SdtWebService_Webserviceclientid_N, false, includeNonInitialized);
         AddObjectProperty("WebServiceClientSecret", gxTv_SdtWebService_Webserviceclientsecret, false, includeNonInitialized);
         AddObjectProperty("WebServiceClientSecret_N", gxTv_SdtWebService_Webserviceclientsecret_N, false, includeNonInitialized);
         AddObjectProperty("WebServiceEndPointDecrypted", gxTv_SdtWebService_Webserviceendpointdecrypted, false, includeNonInitialized);
         AddObjectProperty("WebServiceAuthTipoDecrypted", gxTv_SdtWebService_Webserviceauthtipodecrypted, false, includeNonInitialized);
         AddObjectProperty("WebServiceUsuarioDecrypted", gxTv_SdtWebService_Webserviceusuariodecrypted, false, includeNonInitialized);
         AddObjectProperty("WebServiceSenhaDecrypted", gxTv_SdtWebService_Webservicesenhadecrypted, false, includeNonInitialized);
         AddObjectProperty("WebServiceCertificadoBase64Decrypted", gxTv_SdtWebService_Webservicecertificadobase64decrypted, false, includeNonInitialized);
         AddObjectProperty("WebServiceCertificadoPassDecrypted", gxTv_SdtWebService_Webservicecertificadopassdecrypted, false, includeNonInitialized);
         AddObjectProperty("WebServiceClientidDecrypted", gxTv_SdtWebService_Webserviceclientiddecrypted, false, includeNonInitialized);
         AddObjectProperty("WebServiceClientSecretDecrypted", gxTv_SdtWebService_Webserviceclientsecretdecrypted, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtWebService_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtWebService_Initialized, false, includeNonInitialized);
            AddObjectProperty("WebServiceId_Z", gxTv_SdtWebService_Webserviceid_Z, false, includeNonInitialized);
            AddObjectProperty("WebServiceTipoDmWS_Z", gxTv_SdtWebService_Webservicetipodmws_Z, false, includeNonInitialized);
            AddObjectProperty("WebServiceTipoDmWS_N", gxTv_SdtWebService_Webservicetipodmws_N, false, includeNonInitialized);
            AddObjectProperty("WebServiceEndPoint_N", gxTv_SdtWebService_Webserviceendpoint_N, false, includeNonInitialized);
            AddObjectProperty("WebServiceAuthTipo_N", gxTv_SdtWebService_Webserviceauthtipo_N, false, includeNonInitialized);
            AddObjectProperty("WebServiceUsuario_N", gxTv_SdtWebService_Webserviceusuario_N, false, includeNonInitialized);
            AddObjectProperty("WebServiceSenha_N", gxTv_SdtWebService_Webservicesenha_N, false, includeNonInitialized);
            AddObjectProperty("WebServiceSalt_N", gxTv_SdtWebService_Webservicesalt_N, false, includeNonInitialized);
            AddObjectProperty("WebServiceCertificadoBase64_N", gxTv_SdtWebService_Webservicecertificadobase64_N, false, includeNonInitialized);
            AddObjectProperty("WebServiceCertificadoPass_N", gxTv_SdtWebService_Webservicecertificadopass_N, false, includeNonInitialized);
            AddObjectProperty("WebServiceClientid_N", gxTv_SdtWebService_Webserviceclientid_N, false, includeNonInitialized);
            AddObjectProperty("WebServiceClientSecret_N", gxTv_SdtWebService_Webserviceclientsecret_N, false, includeNonInitialized);
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
         if ( sdt.IsDirty("WebServiceSalt") )
         {
            gxTv_SdtWebService_Webservicesalt_N = (short)(sdt.gxTv_SdtWebService_Webservicesalt_N);
            sdtIsNull = 0;
            gxTv_SdtWebService_Webservicesalt = sdt.gxTv_SdtWebService_Webservicesalt ;
         }
         if ( sdt.IsDirty("WebServiceCertificadoBase64") )
         {
            gxTv_SdtWebService_Webservicecertificadobase64_N = (short)(sdt.gxTv_SdtWebService_Webservicecertificadobase64_N);
            sdtIsNull = 0;
            gxTv_SdtWebService_Webservicecertificadobase64 = sdt.gxTv_SdtWebService_Webservicecertificadobase64 ;
         }
         if ( sdt.IsDirty("WebServiceCertificadoPass") )
         {
            gxTv_SdtWebService_Webservicecertificadopass_N = (short)(sdt.gxTv_SdtWebService_Webservicecertificadopass_N);
            sdtIsNull = 0;
            gxTv_SdtWebService_Webservicecertificadopass = sdt.gxTv_SdtWebService_Webservicecertificadopass ;
         }
         if ( sdt.IsDirty("WebServiceClientid") )
         {
            gxTv_SdtWebService_Webserviceclientid_N = (short)(sdt.gxTv_SdtWebService_Webserviceclientid_N);
            sdtIsNull = 0;
            gxTv_SdtWebService_Webserviceclientid = sdt.gxTv_SdtWebService_Webserviceclientid ;
         }
         if ( sdt.IsDirty("WebServiceClientSecret") )
         {
            gxTv_SdtWebService_Webserviceclientsecret_N = (short)(sdt.gxTv_SdtWebService_Webserviceclientsecret_N);
            sdtIsNull = 0;
            gxTv_SdtWebService_Webserviceclientsecret = sdt.gxTv_SdtWebService_Webserviceclientsecret ;
         }
         if ( sdt.IsDirty("WebServiceEndPointDecrypted") )
         {
            sdtIsNull = 0;
            gxTv_SdtWebService_Webserviceendpointdecrypted = sdt.gxTv_SdtWebService_Webserviceendpointdecrypted ;
         }
         if ( sdt.IsDirty("WebServiceAuthTipoDecrypted") )
         {
            sdtIsNull = 0;
            gxTv_SdtWebService_Webserviceauthtipodecrypted = sdt.gxTv_SdtWebService_Webserviceauthtipodecrypted ;
         }
         if ( sdt.IsDirty("WebServiceUsuarioDecrypted") )
         {
            sdtIsNull = 0;
            gxTv_SdtWebService_Webserviceusuariodecrypted = sdt.gxTv_SdtWebService_Webserviceusuariodecrypted ;
         }
         if ( sdt.IsDirty("WebServiceSenhaDecrypted") )
         {
            sdtIsNull = 0;
            gxTv_SdtWebService_Webservicesenhadecrypted = sdt.gxTv_SdtWebService_Webservicesenhadecrypted ;
         }
         if ( sdt.IsDirty("WebServiceCertificadoBase64Decrypted") )
         {
            sdtIsNull = 0;
            gxTv_SdtWebService_Webservicecertificadobase64decrypted = sdt.gxTv_SdtWebService_Webservicecertificadobase64decrypted ;
         }
         if ( sdt.IsDirty("WebServiceCertificadoPassDecrypted") )
         {
            sdtIsNull = 0;
            gxTv_SdtWebService_Webservicecertificadopassdecrypted = sdt.gxTv_SdtWebService_Webservicecertificadopassdecrypted ;
         }
         if ( sdt.IsDirty("WebServiceClientidDecrypted") )
         {
            sdtIsNull = 0;
            gxTv_SdtWebService_Webserviceclientiddecrypted = sdt.gxTv_SdtWebService_Webserviceclientiddecrypted ;
         }
         if ( sdt.IsDirty("WebServiceClientSecretDecrypted") )
         {
            sdtIsNull = 0;
            gxTv_SdtWebService_Webserviceclientsecretdecrypted = sdt.gxTv_SdtWebService_Webserviceclientsecretdecrypted ;
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

      [  SoapElement( ElementName = "WebServiceSalt" )]
      [  XmlElement( ElementName = "WebServiceSalt"   )]
      public string gxTpr_Webservicesalt
      {
         get {
            return gxTv_SdtWebService_Webservicesalt ;
         }

         set {
            gxTv_SdtWebService_Webservicesalt_N = 0;
            sdtIsNull = 0;
            gxTv_SdtWebService_Webservicesalt = value;
            SetDirty("Webservicesalt");
         }

      }

      public void gxTv_SdtWebService_Webservicesalt_SetNull( )
      {
         gxTv_SdtWebService_Webservicesalt_N = 1;
         gxTv_SdtWebService_Webservicesalt = "";
         SetDirty("Webservicesalt");
         return  ;
      }

      public bool gxTv_SdtWebService_Webservicesalt_IsNull( )
      {
         return (gxTv_SdtWebService_Webservicesalt_N==1) ;
      }

      [  SoapElement( ElementName = "WebServiceCertificadoBase64" )]
      [  XmlElement( ElementName = "WebServiceCertificadoBase64"   )]
      public string gxTpr_Webservicecertificadobase64
      {
         get {
            return gxTv_SdtWebService_Webservicecertificadobase64 ;
         }

         set {
            gxTv_SdtWebService_Webservicecertificadobase64_N = 0;
            sdtIsNull = 0;
            gxTv_SdtWebService_Webservicecertificadobase64 = value;
            SetDirty("Webservicecertificadobase64");
         }

      }

      public void gxTv_SdtWebService_Webservicecertificadobase64_SetNull( )
      {
         gxTv_SdtWebService_Webservicecertificadobase64_N = 1;
         gxTv_SdtWebService_Webservicecertificadobase64 = "";
         SetDirty("Webservicecertificadobase64");
         return  ;
      }

      public bool gxTv_SdtWebService_Webservicecertificadobase64_IsNull( )
      {
         return (gxTv_SdtWebService_Webservicecertificadobase64_N==1) ;
      }

      [  SoapElement( ElementName = "WebServiceCertificadoPass" )]
      [  XmlElement( ElementName = "WebServiceCertificadoPass"   )]
      public string gxTpr_Webservicecertificadopass
      {
         get {
            return gxTv_SdtWebService_Webservicecertificadopass ;
         }

         set {
            gxTv_SdtWebService_Webservicecertificadopass_N = 0;
            sdtIsNull = 0;
            gxTv_SdtWebService_Webservicecertificadopass = value;
            SetDirty("Webservicecertificadopass");
         }

      }

      public void gxTv_SdtWebService_Webservicecertificadopass_SetNull( )
      {
         gxTv_SdtWebService_Webservicecertificadopass_N = 1;
         gxTv_SdtWebService_Webservicecertificadopass = "";
         SetDirty("Webservicecertificadopass");
         return  ;
      }

      public bool gxTv_SdtWebService_Webservicecertificadopass_IsNull( )
      {
         return (gxTv_SdtWebService_Webservicecertificadopass_N==1) ;
      }

      [  SoapElement( ElementName = "WebServiceClientid" )]
      [  XmlElement( ElementName = "WebServiceClientid"   )]
      public string gxTpr_Webserviceclientid
      {
         get {
            return gxTv_SdtWebService_Webserviceclientid ;
         }

         set {
            gxTv_SdtWebService_Webserviceclientid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtWebService_Webserviceclientid = value;
            SetDirty("Webserviceclientid");
         }

      }

      public void gxTv_SdtWebService_Webserviceclientid_SetNull( )
      {
         gxTv_SdtWebService_Webserviceclientid_N = 1;
         gxTv_SdtWebService_Webserviceclientid = "";
         SetDirty("Webserviceclientid");
         return  ;
      }

      public bool gxTv_SdtWebService_Webserviceclientid_IsNull( )
      {
         return (gxTv_SdtWebService_Webserviceclientid_N==1) ;
      }

      [  SoapElement( ElementName = "WebServiceClientSecret" )]
      [  XmlElement( ElementName = "WebServiceClientSecret"   )]
      public string gxTpr_Webserviceclientsecret
      {
         get {
            return gxTv_SdtWebService_Webserviceclientsecret ;
         }

         set {
            gxTv_SdtWebService_Webserviceclientsecret_N = 0;
            sdtIsNull = 0;
            gxTv_SdtWebService_Webserviceclientsecret = value;
            SetDirty("Webserviceclientsecret");
         }

      }

      public void gxTv_SdtWebService_Webserviceclientsecret_SetNull( )
      {
         gxTv_SdtWebService_Webserviceclientsecret_N = 1;
         gxTv_SdtWebService_Webserviceclientsecret = "";
         SetDirty("Webserviceclientsecret");
         return  ;
      }

      public bool gxTv_SdtWebService_Webserviceclientsecret_IsNull( )
      {
         return (gxTv_SdtWebService_Webserviceclientsecret_N==1) ;
      }

      [  SoapElement( ElementName = "WebServiceEndPointDecrypted" )]
      [  XmlElement( ElementName = "WebServiceEndPointDecrypted"   )]
      public string gxTpr_Webserviceendpointdecrypted
      {
         get {
            return gxTv_SdtWebService_Webserviceendpointdecrypted ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWebService_Webserviceendpointdecrypted = value;
            SetDirty("Webserviceendpointdecrypted");
         }

      }

      public void gxTv_SdtWebService_Webserviceendpointdecrypted_SetNull( )
      {
         gxTv_SdtWebService_Webserviceendpointdecrypted = "";
         SetDirty("Webserviceendpointdecrypted");
         return  ;
      }

      public bool gxTv_SdtWebService_Webserviceendpointdecrypted_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WebServiceAuthTipoDecrypted" )]
      [  XmlElement( ElementName = "WebServiceAuthTipoDecrypted"   )]
      public string gxTpr_Webserviceauthtipodecrypted
      {
         get {
            return gxTv_SdtWebService_Webserviceauthtipodecrypted ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWebService_Webserviceauthtipodecrypted = value;
            SetDirty("Webserviceauthtipodecrypted");
         }

      }

      public void gxTv_SdtWebService_Webserviceauthtipodecrypted_SetNull( )
      {
         gxTv_SdtWebService_Webserviceauthtipodecrypted = "";
         SetDirty("Webserviceauthtipodecrypted");
         return  ;
      }

      public bool gxTv_SdtWebService_Webserviceauthtipodecrypted_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WebServiceUsuarioDecrypted" )]
      [  XmlElement( ElementName = "WebServiceUsuarioDecrypted"   )]
      public string gxTpr_Webserviceusuariodecrypted
      {
         get {
            return gxTv_SdtWebService_Webserviceusuariodecrypted ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWebService_Webserviceusuariodecrypted = value;
            SetDirty("Webserviceusuariodecrypted");
         }

      }

      public void gxTv_SdtWebService_Webserviceusuariodecrypted_SetNull( )
      {
         gxTv_SdtWebService_Webserviceusuariodecrypted = "";
         SetDirty("Webserviceusuariodecrypted");
         return  ;
      }

      public bool gxTv_SdtWebService_Webserviceusuariodecrypted_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WebServiceSenhaDecrypted" )]
      [  XmlElement( ElementName = "WebServiceSenhaDecrypted"   )]
      public string gxTpr_Webservicesenhadecrypted
      {
         get {
            return gxTv_SdtWebService_Webservicesenhadecrypted ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWebService_Webservicesenhadecrypted = value;
            SetDirty("Webservicesenhadecrypted");
         }

      }

      public void gxTv_SdtWebService_Webservicesenhadecrypted_SetNull( )
      {
         gxTv_SdtWebService_Webservicesenhadecrypted = "";
         SetDirty("Webservicesenhadecrypted");
         return  ;
      }

      public bool gxTv_SdtWebService_Webservicesenhadecrypted_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WebServiceCertificadoBase64Decrypted" )]
      [  XmlElement( ElementName = "WebServiceCertificadoBase64Decrypted"   )]
      public string gxTpr_Webservicecertificadobase64decrypted
      {
         get {
            return gxTv_SdtWebService_Webservicecertificadobase64decrypted ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWebService_Webservicecertificadobase64decrypted = value;
            SetDirty("Webservicecertificadobase64decrypted");
         }

      }

      public void gxTv_SdtWebService_Webservicecertificadobase64decrypted_SetNull( )
      {
         gxTv_SdtWebService_Webservicecertificadobase64decrypted = "";
         SetDirty("Webservicecertificadobase64decrypted");
         return  ;
      }

      public bool gxTv_SdtWebService_Webservicecertificadobase64decrypted_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WebServiceCertificadoPassDecrypted" )]
      [  XmlElement( ElementName = "WebServiceCertificadoPassDecrypted"   )]
      public string gxTpr_Webservicecertificadopassdecrypted
      {
         get {
            return gxTv_SdtWebService_Webservicecertificadopassdecrypted ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWebService_Webservicecertificadopassdecrypted = value;
            SetDirty("Webservicecertificadopassdecrypted");
         }

      }

      public void gxTv_SdtWebService_Webservicecertificadopassdecrypted_SetNull( )
      {
         gxTv_SdtWebService_Webservicecertificadopassdecrypted = "";
         SetDirty("Webservicecertificadopassdecrypted");
         return  ;
      }

      public bool gxTv_SdtWebService_Webservicecertificadopassdecrypted_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WebServiceClientidDecrypted" )]
      [  XmlElement( ElementName = "WebServiceClientidDecrypted"   )]
      public string gxTpr_Webserviceclientiddecrypted
      {
         get {
            return gxTv_SdtWebService_Webserviceclientiddecrypted ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWebService_Webserviceclientiddecrypted = value;
            SetDirty("Webserviceclientiddecrypted");
         }

      }

      public void gxTv_SdtWebService_Webserviceclientiddecrypted_SetNull( )
      {
         gxTv_SdtWebService_Webserviceclientiddecrypted = "";
         SetDirty("Webserviceclientiddecrypted");
         return  ;
      }

      public bool gxTv_SdtWebService_Webserviceclientiddecrypted_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WebServiceClientSecretDecrypted" )]
      [  XmlElement( ElementName = "WebServiceClientSecretDecrypted"   )]
      public string gxTpr_Webserviceclientsecretdecrypted
      {
         get {
            return gxTv_SdtWebService_Webserviceclientsecretdecrypted ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWebService_Webserviceclientsecretdecrypted = value;
            SetDirty("Webserviceclientsecretdecrypted");
         }

      }

      public void gxTv_SdtWebService_Webserviceclientsecretdecrypted_SetNull( )
      {
         gxTv_SdtWebService_Webserviceclientsecretdecrypted = "";
         SetDirty("Webserviceclientsecretdecrypted");
         return  ;
      }

      public bool gxTv_SdtWebService_Webserviceclientsecretdecrypted_IsNull( )
      {
         return false ;
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

      [  SoapElement( ElementName = "WebServiceSalt_N" )]
      [  XmlElement( ElementName = "WebServiceSalt_N"   )]
      public short gxTpr_Webservicesalt_N
      {
         get {
            return gxTv_SdtWebService_Webservicesalt_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWebService_Webservicesalt_N = value;
            SetDirty("Webservicesalt_N");
         }

      }

      public void gxTv_SdtWebService_Webservicesalt_N_SetNull( )
      {
         gxTv_SdtWebService_Webservicesalt_N = 0;
         SetDirty("Webservicesalt_N");
         return  ;
      }

      public bool gxTv_SdtWebService_Webservicesalt_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WebServiceCertificadoBase64_N" )]
      [  XmlElement( ElementName = "WebServiceCertificadoBase64_N"   )]
      public short gxTpr_Webservicecertificadobase64_N
      {
         get {
            return gxTv_SdtWebService_Webservicecertificadobase64_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWebService_Webservicecertificadobase64_N = value;
            SetDirty("Webservicecertificadobase64_N");
         }

      }

      public void gxTv_SdtWebService_Webservicecertificadobase64_N_SetNull( )
      {
         gxTv_SdtWebService_Webservicecertificadobase64_N = 0;
         SetDirty("Webservicecertificadobase64_N");
         return  ;
      }

      public bool gxTv_SdtWebService_Webservicecertificadobase64_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WebServiceCertificadoPass_N" )]
      [  XmlElement( ElementName = "WebServiceCertificadoPass_N"   )]
      public short gxTpr_Webservicecertificadopass_N
      {
         get {
            return gxTv_SdtWebService_Webservicecertificadopass_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWebService_Webservicecertificadopass_N = value;
            SetDirty("Webservicecertificadopass_N");
         }

      }

      public void gxTv_SdtWebService_Webservicecertificadopass_N_SetNull( )
      {
         gxTv_SdtWebService_Webservicecertificadopass_N = 0;
         SetDirty("Webservicecertificadopass_N");
         return  ;
      }

      public bool gxTv_SdtWebService_Webservicecertificadopass_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WebServiceClientid_N" )]
      [  XmlElement( ElementName = "WebServiceClientid_N"   )]
      public short gxTpr_Webserviceclientid_N
      {
         get {
            return gxTv_SdtWebService_Webserviceclientid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWebService_Webserviceclientid_N = value;
            SetDirty("Webserviceclientid_N");
         }

      }

      public void gxTv_SdtWebService_Webserviceclientid_N_SetNull( )
      {
         gxTv_SdtWebService_Webserviceclientid_N = 0;
         SetDirty("Webserviceclientid_N");
         return  ;
      }

      public bool gxTv_SdtWebService_Webserviceclientid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WebServiceClientSecret_N" )]
      [  XmlElement( ElementName = "WebServiceClientSecret_N"   )]
      public short gxTpr_Webserviceclientsecret_N
      {
         get {
            return gxTv_SdtWebService_Webserviceclientsecret_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWebService_Webserviceclientsecret_N = value;
            SetDirty("Webserviceclientsecret_N");
         }

      }

      public void gxTv_SdtWebService_Webserviceclientsecret_N_SetNull( )
      {
         gxTv_SdtWebService_Webserviceclientsecret_N = 0;
         SetDirty("Webserviceclientsecret_N");
         return  ;
      }

      public bool gxTv_SdtWebService_Webserviceclientsecret_N_IsNull( )
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
         gxTv_SdtWebService_Webservicesalt = "";
         gxTv_SdtWebService_Webservicecertificadobase64 = "";
         gxTv_SdtWebService_Webservicecertificadopass = "";
         gxTv_SdtWebService_Webserviceclientid = "";
         gxTv_SdtWebService_Webserviceclientsecret = "";
         gxTv_SdtWebService_Webserviceendpointdecrypted = "";
         gxTv_SdtWebService_Webserviceauthtipodecrypted = "";
         gxTv_SdtWebService_Webserviceusuariodecrypted = "";
         gxTv_SdtWebService_Webservicesenhadecrypted = "";
         gxTv_SdtWebService_Webservicecertificadobase64decrypted = "";
         gxTv_SdtWebService_Webservicecertificadopassdecrypted = "";
         gxTv_SdtWebService_Webserviceclientiddecrypted = "";
         gxTv_SdtWebService_Webserviceclientsecretdecrypted = "";
         gxTv_SdtWebService_Mode = "";
         gxTv_SdtWebService_Webservicetipodmws_Z = "";
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
      private short gxTv_SdtWebService_Webservicesalt_N ;
      private short gxTv_SdtWebService_Webservicecertificadobase64_N ;
      private short gxTv_SdtWebService_Webservicecertificadopass_N ;
      private short gxTv_SdtWebService_Webserviceclientid_N ;
      private short gxTv_SdtWebService_Webserviceclientsecret_N ;
      private int gxTv_SdtWebService_Webserviceid ;
      private int gxTv_SdtWebService_Webserviceid_Z ;
      private string gxTv_SdtWebService_Mode ;
      private string gxTv_SdtWebService_Webserviceendpoint ;
      private string gxTv_SdtWebService_Webserviceauthtipo ;
      private string gxTv_SdtWebService_Webserviceusuario ;
      private string gxTv_SdtWebService_Webservicesenha ;
      private string gxTv_SdtWebService_Webservicesalt ;
      private string gxTv_SdtWebService_Webservicecertificadobase64 ;
      private string gxTv_SdtWebService_Webservicecertificadopass ;
      private string gxTv_SdtWebService_Webserviceclientid ;
      private string gxTv_SdtWebService_Webserviceclientsecret ;
      private string gxTv_SdtWebService_Webserviceendpointdecrypted ;
      private string gxTv_SdtWebService_Webserviceauthtipodecrypted ;
      private string gxTv_SdtWebService_Webserviceusuariodecrypted ;
      private string gxTv_SdtWebService_Webservicesenhadecrypted ;
      private string gxTv_SdtWebService_Webservicecertificadobase64decrypted ;
      private string gxTv_SdtWebService_Webservicecertificadopassdecrypted ;
      private string gxTv_SdtWebService_Webserviceclientiddecrypted ;
      private string gxTv_SdtWebService_Webserviceclientsecretdecrypted ;
      private string gxTv_SdtWebService_Webservicetipodmws ;
      private string gxTv_SdtWebService_Webservicetipodmws_Z ;
   }

   [DataContract(Name = @"WebService", Namespace = "Factory21")]
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
      public string gxTpr_Webservicesenha
      {
         get {
            return sdt.gxTpr_Webservicesenha ;
         }

         set {
            sdt.gxTpr_Webservicesenha = value;
         }

      }

      [DataMember( Name = "WebServiceSalt" , Order = 6 )]
      public string gxTpr_Webservicesalt
      {
         get {
            return sdt.gxTpr_Webservicesalt ;
         }

         set {
            sdt.gxTpr_Webservicesalt = value;
         }

      }

      [DataMember( Name = "WebServiceCertificadoBase64" , Order = 7 )]
      public string gxTpr_Webservicecertificadobase64
      {
         get {
            return sdt.gxTpr_Webservicecertificadobase64 ;
         }

         set {
            sdt.gxTpr_Webservicecertificadobase64 = value;
         }

      }

      [DataMember( Name = "WebServiceCertificadoPass" , Order = 8 )]
      public string gxTpr_Webservicecertificadopass
      {
         get {
            return sdt.gxTpr_Webservicecertificadopass ;
         }

         set {
            sdt.gxTpr_Webservicecertificadopass = value;
         }

      }

      [DataMember( Name = "WebServiceClientid" , Order = 9 )]
      public string gxTpr_Webserviceclientid
      {
         get {
            return sdt.gxTpr_Webserviceclientid ;
         }

         set {
            sdt.gxTpr_Webserviceclientid = value;
         }

      }

      [DataMember( Name = "WebServiceClientSecret" , Order = 10 )]
      public string gxTpr_Webserviceclientsecret
      {
         get {
            return sdt.gxTpr_Webserviceclientsecret ;
         }

         set {
            sdt.gxTpr_Webserviceclientsecret = value;
         }

      }

      [DataMember( Name = "WebServiceEndPointDecrypted" , Order = 11 )]
      public string gxTpr_Webserviceendpointdecrypted
      {
         get {
            return sdt.gxTpr_Webserviceendpointdecrypted ;
         }

         set {
            sdt.gxTpr_Webserviceendpointdecrypted = value;
         }

      }

      [DataMember( Name = "WebServiceAuthTipoDecrypted" , Order = 12 )]
      public string gxTpr_Webserviceauthtipodecrypted
      {
         get {
            return sdt.gxTpr_Webserviceauthtipodecrypted ;
         }

         set {
            sdt.gxTpr_Webserviceauthtipodecrypted = value;
         }

      }

      [DataMember( Name = "WebServiceUsuarioDecrypted" , Order = 13 )]
      public string gxTpr_Webserviceusuariodecrypted
      {
         get {
            return sdt.gxTpr_Webserviceusuariodecrypted ;
         }

         set {
            sdt.gxTpr_Webserviceusuariodecrypted = value;
         }

      }

      [DataMember( Name = "WebServiceSenhaDecrypted" , Order = 14 )]
      public string gxTpr_Webservicesenhadecrypted
      {
         get {
            return sdt.gxTpr_Webservicesenhadecrypted ;
         }

         set {
            sdt.gxTpr_Webservicesenhadecrypted = value;
         }

      }

      [DataMember( Name = "WebServiceCertificadoBase64Decrypted" , Order = 15 )]
      public string gxTpr_Webservicecertificadobase64decrypted
      {
         get {
            return sdt.gxTpr_Webservicecertificadobase64decrypted ;
         }

         set {
            sdt.gxTpr_Webservicecertificadobase64decrypted = value;
         }

      }

      [DataMember( Name = "WebServiceCertificadoPassDecrypted" , Order = 16 )]
      public string gxTpr_Webservicecertificadopassdecrypted
      {
         get {
            return sdt.gxTpr_Webservicecertificadopassdecrypted ;
         }

         set {
            sdt.gxTpr_Webservicecertificadopassdecrypted = value;
         }

      }

      [DataMember( Name = "WebServiceClientidDecrypted" , Order = 17 )]
      public string gxTpr_Webserviceclientiddecrypted
      {
         get {
            return sdt.gxTpr_Webserviceclientiddecrypted ;
         }

         set {
            sdt.gxTpr_Webserviceclientiddecrypted = value;
         }

      }

      [DataMember( Name = "WebServiceClientSecretDecrypted" , Order = 18 )]
      public string gxTpr_Webserviceclientsecretdecrypted
      {
         get {
            return sdt.gxTpr_Webserviceclientsecretdecrypted ;
         }

         set {
            sdt.gxTpr_Webserviceclientsecretdecrypted = value;
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

      [DataMember( Name = "gx_md5_hash" , Order = 19 )]
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

   [DataContract(Name = @"WebService", Namespace = "Factory21")]
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
