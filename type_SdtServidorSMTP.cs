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
   [XmlRoot(ElementName = "ServidorSMTP" )]
   [XmlType(TypeName =  "ServidorSMTP" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtServidorSMTP : GxSilentTrnSdt
   {
      public SdtServidorSMTP( )
      {
      }

      public SdtServidorSMTP( IGxContext context )
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

      public void Load( short AV158ServidorSMTPId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV158ServidorSMTPId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ServidorSMTPId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "ServidorSMTP");
         metadata.Set("BT", "ServidorSMTP");
         metadata.Set("PK", "[ \"ServidorSMTPId\" ]");
         metadata.Set("PKAssigned", "[ \"ServidorSMTPId\" ]");
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
         state.Add("gxTpr_Servidorsmtpid_Z");
         state.Add("gxTpr_Servidorsmtpserver_Z");
         state.Add("gxTpr_Servidorsmtpporta_Z");
         state.Add("gxTpr_Servidorsmtpemail_Z");
         state.Add("gxTpr_Servidorsmtppass_Z");
         state.Add("gxTpr_Servidorsmtpusuario_Z");
         state.Add("gxTpr_Servidorsmtpserver_N");
         state.Add("gxTpr_Servidorsmtpporta_N");
         state.Add("gxTpr_Servidorsmtpemail_N");
         state.Add("gxTpr_Servidorsmtppass_N");
         state.Add("gxTpr_Servidorsmtpusuario_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtServidorSMTP sdt;
         sdt = (SdtServidorSMTP)(source);
         gxTv_SdtServidorSMTP_Servidorsmtpid = sdt.gxTv_SdtServidorSMTP_Servidorsmtpid ;
         gxTv_SdtServidorSMTP_Servidorsmtpserver = sdt.gxTv_SdtServidorSMTP_Servidorsmtpserver ;
         gxTv_SdtServidorSMTP_Servidorsmtpporta = sdt.gxTv_SdtServidorSMTP_Servidorsmtpporta ;
         gxTv_SdtServidorSMTP_Servidorsmtpemail = sdt.gxTv_SdtServidorSMTP_Servidorsmtpemail ;
         gxTv_SdtServidorSMTP_Servidorsmtppass = sdt.gxTv_SdtServidorSMTP_Servidorsmtppass ;
         gxTv_SdtServidorSMTP_Servidorsmtpusuario = sdt.gxTv_SdtServidorSMTP_Servidorsmtpusuario ;
         gxTv_SdtServidorSMTP_Mode = sdt.gxTv_SdtServidorSMTP_Mode ;
         gxTv_SdtServidorSMTP_Initialized = sdt.gxTv_SdtServidorSMTP_Initialized ;
         gxTv_SdtServidorSMTP_Servidorsmtpid_Z = sdt.gxTv_SdtServidorSMTP_Servidorsmtpid_Z ;
         gxTv_SdtServidorSMTP_Servidorsmtpserver_Z = sdt.gxTv_SdtServidorSMTP_Servidorsmtpserver_Z ;
         gxTv_SdtServidorSMTP_Servidorsmtpporta_Z = sdt.gxTv_SdtServidorSMTP_Servidorsmtpporta_Z ;
         gxTv_SdtServidorSMTP_Servidorsmtpemail_Z = sdt.gxTv_SdtServidorSMTP_Servidorsmtpemail_Z ;
         gxTv_SdtServidorSMTP_Servidorsmtppass_Z = sdt.gxTv_SdtServidorSMTP_Servidorsmtppass_Z ;
         gxTv_SdtServidorSMTP_Servidorsmtpusuario_Z = sdt.gxTv_SdtServidorSMTP_Servidorsmtpusuario_Z ;
         gxTv_SdtServidorSMTP_Servidorsmtpserver_N = sdt.gxTv_SdtServidorSMTP_Servidorsmtpserver_N ;
         gxTv_SdtServidorSMTP_Servidorsmtpporta_N = sdt.gxTv_SdtServidorSMTP_Servidorsmtpporta_N ;
         gxTv_SdtServidorSMTP_Servidorsmtpemail_N = sdt.gxTv_SdtServidorSMTP_Servidorsmtpemail_N ;
         gxTv_SdtServidorSMTP_Servidorsmtppass_N = sdt.gxTv_SdtServidorSMTP_Servidorsmtppass_N ;
         gxTv_SdtServidorSMTP_Servidorsmtpusuario_N = sdt.gxTv_SdtServidorSMTP_Servidorsmtpusuario_N ;
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
         AddObjectProperty("ServidorSMTPId", gxTv_SdtServidorSMTP_Servidorsmtpid, false, includeNonInitialized);
         AddObjectProperty("ServidorSMTPServer", gxTv_SdtServidorSMTP_Servidorsmtpserver, false, includeNonInitialized);
         AddObjectProperty("ServidorSMTPServer_N", gxTv_SdtServidorSMTP_Servidorsmtpserver_N, false, includeNonInitialized);
         AddObjectProperty("ServidorSMTPPorta", gxTv_SdtServidorSMTP_Servidorsmtpporta, false, includeNonInitialized);
         AddObjectProperty("ServidorSMTPPorta_N", gxTv_SdtServidorSMTP_Servidorsmtpporta_N, false, includeNonInitialized);
         AddObjectProperty("ServidorSMTPEmail", gxTv_SdtServidorSMTP_Servidorsmtpemail, false, includeNonInitialized);
         AddObjectProperty("ServidorSMTPEmail_N", gxTv_SdtServidorSMTP_Servidorsmtpemail_N, false, includeNonInitialized);
         AddObjectProperty("ServidorSMTPPass", gxTv_SdtServidorSMTP_Servidorsmtppass, false, includeNonInitialized);
         AddObjectProperty("ServidorSMTPPass_N", gxTv_SdtServidorSMTP_Servidorsmtppass_N, false, includeNonInitialized);
         AddObjectProperty("ServidorSMTPUsuario", gxTv_SdtServidorSMTP_Servidorsmtpusuario, false, includeNonInitialized);
         AddObjectProperty("ServidorSMTPUsuario_N", gxTv_SdtServidorSMTP_Servidorsmtpusuario_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtServidorSMTP_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtServidorSMTP_Initialized, false, includeNonInitialized);
            AddObjectProperty("ServidorSMTPId_Z", gxTv_SdtServidorSMTP_Servidorsmtpid_Z, false, includeNonInitialized);
            AddObjectProperty("ServidorSMTPServer_Z", gxTv_SdtServidorSMTP_Servidorsmtpserver_Z, false, includeNonInitialized);
            AddObjectProperty("ServidorSMTPPorta_Z", gxTv_SdtServidorSMTP_Servidorsmtpporta_Z, false, includeNonInitialized);
            AddObjectProperty("ServidorSMTPEmail_Z", gxTv_SdtServidorSMTP_Servidorsmtpemail_Z, false, includeNonInitialized);
            AddObjectProperty("ServidorSMTPPass_Z", gxTv_SdtServidorSMTP_Servidorsmtppass_Z, false, includeNonInitialized);
            AddObjectProperty("ServidorSMTPUsuario_Z", gxTv_SdtServidorSMTP_Servidorsmtpusuario_Z, false, includeNonInitialized);
            AddObjectProperty("ServidorSMTPServer_N", gxTv_SdtServidorSMTP_Servidorsmtpserver_N, false, includeNonInitialized);
            AddObjectProperty("ServidorSMTPPorta_N", gxTv_SdtServidorSMTP_Servidorsmtpporta_N, false, includeNonInitialized);
            AddObjectProperty("ServidorSMTPEmail_N", gxTv_SdtServidorSMTP_Servidorsmtpemail_N, false, includeNonInitialized);
            AddObjectProperty("ServidorSMTPPass_N", gxTv_SdtServidorSMTP_Servidorsmtppass_N, false, includeNonInitialized);
            AddObjectProperty("ServidorSMTPUsuario_N", gxTv_SdtServidorSMTP_Servidorsmtpusuario_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtServidorSMTP sdt )
      {
         if ( sdt.IsDirty("ServidorSMTPId") )
         {
            sdtIsNull = 0;
            gxTv_SdtServidorSMTP_Servidorsmtpid = sdt.gxTv_SdtServidorSMTP_Servidorsmtpid ;
         }
         if ( sdt.IsDirty("ServidorSMTPServer") )
         {
            gxTv_SdtServidorSMTP_Servidorsmtpserver_N = (short)(sdt.gxTv_SdtServidorSMTP_Servidorsmtpserver_N);
            sdtIsNull = 0;
            gxTv_SdtServidorSMTP_Servidorsmtpserver = sdt.gxTv_SdtServidorSMTP_Servidorsmtpserver ;
         }
         if ( sdt.IsDirty("ServidorSMTPPorta") )
         {
            gxTv_SdtServidorSMTP_Servidorsmtpporta_N = (short)(sdt.gxTv_SdtServidorSMTP_Servidorsmtpporta_N);
            sdtIsNull = 0;
            gxTv_SdtServidorSMTP_Servidorsmtpporta = sdt.gxTv_SdtServidorSMTP_Servidorsmtpporta ;
         }
         if ( sdt.IsDirty("ServidorSMTPEmail") )
         {
            gxTv_SdtServidorSMTP_Servidorsmtpemail_N = (short)(sdt.gxTv_SdtServidorSMTP_Servidorsmtpemail_N);
            sdtIsNull = 0;
            gxTv_SdtServidorSMTP_Servidorsmtpemail = sdt.gxTv_SdtServidorSMTP_Servidorsmtpemail ;
         }
         if ( sdt.IsDirty("ServidorSMTPPass") )
         {
            gxTv_SdtServidorSMTP_Servidorsmtppass_N = (short)(sdt.gxTv_SdtServidorSMTP_Servidorsmtppass_N);
            sdtIsNull = 0;
            gxTv_SdtServidorSMTP_Servidorsmtppass = sdt.gxTv_SdtServidorSMTP_Servidorsmtppass ;
         }
         if ( sdt.IsDirty("ServidorSMTPUsuario") )
         {
            gxTv_SdtServidorSMTP_Servidorsmtpusuario_N = (short)(sdt.gxTv_SdtServidorSMTP_Servidorsmtpusuario_N);
            sdtIsNull = 0;
            gxTv_SdtServidorSMTP_Servidorsmtpusuario = sdt.gxTv_SdtServidorSMTP_Servidorsmtpusuario ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ServidorSMTPId" )]
      [  XmlElement( ElementName = "ServidorSMTPId"   )]
      public short gxTpr_Servidorsmtpid
      {
         get {
            return gxTv_SdtServidorSMTP_Servidorsmtpid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtServidorSMTP_Servidorsmtpid != value )
            {
               gxTv_SdtServidorSMTP_Mode = "INS";
               this.gxTv_SdtServidorSMTP_Servidorsmtpid_Z_SetNull( );
               this.gxTv_SdtServidorSMTP_Servidorsmtpserver_Z_SetNull( );
               this.gxTv_SdtServidorSMTP_Servidorsmtpporta_Z_SetNull( );
               this.gxTv_SdtServidorSMTP_Servidorsmtpemail_Z_SetNull( );
               this.gxTv_SdtServidorSMTP_Servidorsmtppass_Z_SetNull( );
               this.gxTv_SdtServidorSMTP_Servidorsmtpusuario_Z_SetNull( );
            }
            gxTv_SdtServidorSMTP_Servidorsmtpid = value;
            SetDirty("Servidorsmtpid");
         }

      }

      [  SoapElement( ElementName = "ServidorSMTPServer" )]
      [  XmlElement( ElementName = "ServidorSMTPServer"   )]
      public string gxTpr_Servidorsmtpserver
      {
         get {
            return gxTv_SdtServidorSMTP_Servidorsmtpserver ;
         }

         set {
            gxTv_SdtServidorSMTP_Servidorsmtpserver_N = 0;
            sdtIsNull = 0;
            gxTv_SdtServidorSMTP_Servidorsmtpserver = value;
            SetDirty("Servidorsmtpserver");
         }

      }

      public void gxTv_SdtServidorSMTP_Servidorsmtpserver_SetNull( )
      {
         gxTv_SdtServidorSMTP_Servidorsmtpserver_N = 1;
         gxTv_SdtServidorSMTP_Servidorsmtpserver = "";
         SetDirty("Servidorsmtpserver");
         return  ;
      }

      public bool gxTv_SdtServidorSMTP_Servidorsmtpserver_IsNull( )
      {
         return (gxTv_SdtServidorSMTP_Servidorsmtpserver_N==1) ;
      }

      [  SoapElement( ElementName = "ServidorSMTPPorta" )]
      [  XmlElement( ElementName = "ServidorSMTPPorta"   )]
      public string gxTpr_Servidorsmtpporta
      {
         get {
            return gxTv_SdtServidorSMTP_Servidorsmtpporta ;
         }

         set {
            gxTv_SdtServidorSMTP_Servidorsmtpporta_N = 0;
            sdtIsNull = 0;
            gxTv_SdtServidorSMTP_Servidorsmtpporta = value;
            SetDirty("Servidorsmtpporta");
         }

      }

      public void gxTv_SdtServidorSMTP_Servidorsmtpporta_SetNull( )
      {
         gxTv_SdtServidorSMTP_Servidorsmtpporta_N = 1;
         gxTv_SdtServidorSMTP_Servidorsmtpporta = "";
         SetDirty("Servidorsmtpporta");
         return  ;
      }

      public bool gxTv_SdtServidorSMTP_Servidorsmtpporta_IsNull( )
      {
         return (gxTv_SdtServidorSMTP_Servidorsmtpporta_N==1) ;
      }

      [  SoapElement( ElementName = "ServidorSMTPEmail" )]
      [  XmlElement( ElementName = "ServidorSMTPEmail"   )]
      public string gxTpr_Servidorsmtpemail
      {
         get {
            return gxTv_SdtServidorSMTP_Servidorsmtpemail ;
         }

         set {
            gxTv_SdtServidorSMTP_Servidorsmtpemail_N = 0;
            sdtIsNull = 0;
            gxTv_SdtServidorSMTP_Servidorsmtpemail = value;
            SetDirty("Servidorsmtpemail");
         }

      }

      public void gxTv_SdtServidorSMTP_Servidorsmtpemail_SetNull( )
      {
         gxTv_SdtServidorSMTP_Servidorsmtpemail_N = 1;
         gxTv_SdtServidorSMTP_Servidorsmtpemail = "";
         SetDirty("Servidorsmtpemail");
         return  ;
      }

      public bool gxTv_SdtServidorSMTP_Servidorsmtpemail_IsNull( )
      {
         return (gxTv_SdtServidorSMTP_Servidorsmtpemail_N==1) ;
      }

      [  SoapElement( ElementName = "ServidorSMTPPass" )]
      [  XmlElement( ElementName = "ServidorSMTPPass"   )]
      public string gxTpr_Servidorsmtppass
      {
         get {
            return gxTv_SdtServidorSMTP_Servidorsmtppass ;
         }

         set {
            gxTv_SdtServidorSMTP_Servidorsmtppass_N = 0;
            sdtIsNull = 0;
            gxTv_SdtServidorSMTP_Servidorsmtppass = value;
            SetDirty("Servidorsmtppass");
         }

      }

      public void gxTv_SdtServidorSMTP_Servidorsmtppass_SetNull( )
      {
         gxTv_SdtServidorSMTP_Servidorsmtppass_N = 1;
         gxTv_SdtServidorSMTP_Servidorsmtppass = "";
         SetDirty("Servidorsmtppass");
         return  ;
      }

      public bool gxTv_SdtServidorSMTP_Servidorsmtppass_IsNull( )
      {
         return (gxTv_SdtServidorSMTP_Servidorsmtppass_N==1) ;
      }

      [  SoapElement( ElementName = "ServidorSMTPUsuario" )]
      [  XmlElement( ElementName = "ServidorSMTPUsuario"   )]
      public string gxTpr_Servidorsmtpusuario
      {
         get {
            return gxTv_SdtServidorSMTP_Servidorsmtpusuario ;
         }

         set {
            gxTv_SdtServidorSMTP_Servidorsmtpusuario_N = 0;
            sdtIsNull = 0;
            gxTv_SdtServidorSMTP_Servidorsmtpusuario = value;
            SetDirty("Servidorsmtpusuario");
         }

      }

      public void gxTv_SdtServidorSMTP_Servidorsmtpusuario_SetNull( )
      {
         gxTv_SdtServidorSMTP_Servidorsmtpusuario_N = 1;
         gxTv_SdtServidorSMTP_Servidorsmtpusuario = "";
         SetDirty("Servidorsmtpusuario");
         return  ;
      }

      public bool gxTv_SdtServidorSMTP_Servidorsmtpusuario_IsNull( )
      {
         return (gxTv_SdtServidorSMTP_Servidorsmtpusuario_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtServidorSMTP_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtServidorSMTP_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtServidorSMTP_Mode_SetNull( )
      {
         gxTv_SdtServidorSMTP_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtServidorSMTP_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtServidorSMTP_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtServidorSMTP_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtServidorSMTP_Initialized_SetNull( )
      {
         gxTv_SdtServidorSMTP_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtServidorSMTP_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ServidorSMTPId_Z" )]
      [  XmlElement( ElementName = "ServidorSMTPId_Z"   )]
      public short gxTpr_Servidorsmtpid_Z
      {
         get {
            return gxTv_SdtServidorSMTP_Servidorsmtpid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtServidorSMTP_Servidorsmtpid_Z = value;
            SetDirty("Servidorsmtpid_Z");
         }

      }

      public void gxTv_SdtServidorSMTP_Servidorsmtpid_Z_SetNull( )
      {
         gxTv_SdtServidorSMTP_Servidorsmtpid_Z = 0;
         SetDirty("Servidorsmtpid_Z");
         return  ;
      }

      public bool gxTv_SdtServidorSMTP_Servidorsmtpid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ServidorSMTPServer_Z" )]
      [  XmlElement( ElementName = "ServidorSMTPServer_Z"   )]
      public string gxTpr_Servidorsmtpserver_Z
      {
         get {
            return gxTv_SdtServidorSMTP_Servidorsmtpserver_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtServidorSMTP_Servidorsmtpserver_Z = value;
            SetDirty("Servidorsmtpserver_Z");
         }

      }

      public void gxTv_SdtServidorSMTP_Servidorsmtpserver_Z_SetNull( )
      {
         gxTv_SdtServidorSMTP_Servidorsmtpserver_Z = "";
         SetDirty("Servidorsmtpserver_Z");
         return  ;
      }

      public bool gxTv_SdtServidorSMTP_Servidorsmtpserver_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ServidorSMTPPorta_Z" )]
      [  XmlElement( ElementName = "ServidorSMTPPorta_Z"   )]
      public string gxTpr_Servidorsmtpporta_Z
      {
         get {
            return gxTv_SdtServidorSMTP_Servidorsmtpporta_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtServidorSMTP_Servidorsmtpporta_Z = value;
            SetDirty("Servidorsmtpporta_Z");
         }

      }

      public void gxTv_SdtServidorSMTP_Servidorsmtpporta_Z_SetNull( )
      {
         gxTv_SdtServidorSMTP_Servidorsmtpporta_Z = "";
         SetDirty("Servidorsmtpporta_Z");
         return  ;
      }

      public bool gxTv_SdtServidorSMTP_Servidorsmtpporta_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ServidorSMTPEmail_Z" )]
      [  XmlElement( ElementName = "ServidorSMTPEmail_Z"   )]
      public string gxTpr_Servidorsmtpemail_Z
      {
         get {
            return gxTv_SdtServidorSMTP_Servidorsmtpemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtServidorSMTP_Servidorsmtpemail_Z = value;
            SetDirty("Servidorsmtpemail_Z");
         }

      }

      public void gxTv_SdtServidorSMTP_Servidorsmtpemail_Z_SetNull( )
      {
         gxTv_SdtServidorSMTP_Servidorsmtpemail_Z = "";
         SetDirty("Servidorsmtpemail_Z");
         return  ;
      }

      public bool gxTv_SdtServidorSMTP_Servidorsmtpemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ServidorSMTPPass_Z" )]
      [  XmlElement( ElementName = "ServidorSMTPPass_Z"   )]
      public string gxTpr_Servidorsmtppass_Z
      {
         get {
            return gxTv_SdtServidorSMTP_Servidorsmtppass_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtServidorSMTP_Servidorsmtppass_Z = value;
            SetDirty("Servidorsmtppass_Z");
         }

      }

      public void gxTv_SdtServidorSMTP_Servidorsmtppass_Z_SetNull( )
      {
         gxTv_SdtServidorSMTP_Servidorsmtppass_Z = "";
         SetDirty("Servidorsmtppass_Z");
         return  ;
      }

      public bool gxTv_SdtServidorSMTP_Servidorsmtppass_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ServidorSMTPUsuario_Z" )]
      [  XmlElement( ElementName = "ServidorSMTPUsuario_Z"   )]
      public string gxTpr_Servidorsmtpusuario_Z
      {
         get {
            return gxTv_SdtServidorSMTP_Servidorsmtpusuario_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtServidorSMTP_Servidorsmtpusuario_Z = value;
            SetDirty("Servidorsmtpusuario_Z");
         }

      }

      public void gxTv_SdtServidorSMTP_Servidorsmtpusuario_Z_SetNull( )
      {
         gxTv_SdtServidorSMTP_Servidorsmtpusuario_Z = "";
         SetDirty("Servidorsmtpusuario_Z");
         return  ;
      }

      public bool gxTv_SdtServidorSMTP_Servidorsmtpusuario_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ServidorSMTPServer_N" )]
      [  XmlElement( ElementName = "ServidorSMTPServer_N"   )]
      public short gxTpr_Servidorsmtpserver_N
      {
         get {
            return gxTv_SdtServidorSMTP_Servidorsmtpserver_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtServidorSMTP_Servidorsmtpserver_N = value;
            SetDirty("Servidorsmtpserver_N");
         }

      }

      public void gxTv_SdtServidorSMTP_Servidorsmtpserver_N_SetNull( )
      {
         gxTv_SdtServidorSMTP_Servidorsmtpserver_N = 0;
         SetDirty("Servidorsmtpserver_N");
         return  ;
      }

      public bool gxTv_SdtServidorSMTP_Servidorsmtpserver_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ServidorSMTPPorta_N" )]
      [  XmlElement( ElementName = "ServidorSMTPPorta_N"   )]
      public short gxTpr_Servidorsmtpporta_N
      {
         get {
            return gxTv_SdtServidorSMTP_Servidorsmtpporta_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtServidorSMTP_Servidorsmtpporta_N = value;
            SetDirty("Servidorsmtpporta_N");
         }

      }

      public void gxTv_SdtServidorSMTP_Servidorsmtpporta_N_SetNull( )
      {
         gxTv_SdtServidorSMTP_Servidorsmtpporta_N = 0;
         SetDirty("Servidorsmtpporta_N");
         return  ;
      }

      public bool gxTv_SdtServidorSMTP_Servidorsmtpporta_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ServidorSMTPEmail_N" )]
      [  XmlElement( ElementName = "ServidorSMTPEmail_N"   )]
      public short gxTpr_Servidorsmtpemail_N
      {
         get {
            return gxTv_SdtServidorSMTP_Servidorsmtpemail_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtServidorSMTP_Servidorsmtpemail_N = value;
            SetDirty("Servidorsmtpemail_N");
         }

      }

      public void gxTv_SdtServidorSMTP_Servidorsmtpemail_N_SetNull( )
      {
         gxTv_SdtServidorSMTP_Servidorsmtpemail_N = 0;
         SetDirty("Servidorsmtpemail_N");
         return  ;
      }

      public bool gxTv_SdtServidorSMTP_Servidorsmtpemail_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ServidorSMTPPass_N" )]
      [  XmlElement( ElementName = "ServidorSMTPPass_N"   )]
      public short gxTpr_Servidorsmtppass_N
      {
         get {
            return gxTv_SdtServidorSMTP_Servidorsmtppass_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtServidorSMTP_Servidorsmtppass_N = value;
            SetDirty("Servidorsmtppass_N");
         }

      }

      public void gxTv_SdtServidorSMTP_Servidorsmtppass_N_SetNull( )
      {
         gxTv_SdtServidorSMTP_Servidorsmtppass_N = 0;
         SetDirty("Servidorsmtppass_N");
         return  ;
      }

      public bool gxTv_SdtServidorSMTP_Servidorsmtppass_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ServidorSMTPUsuario_N" )]
      [  XmlElement( ElementName = "ServidorSMTPUsuario_N"   )]
      public short gxTpr_Servidorsmtpusuario_N
      {
         get {
            return gxTv_SdtServidorSMTP_Servidorsmtpusuario_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtServidorSMTP_Servidorsmtpusuario_N = value;
            SetDirty("Servidorsmtpusuario_N");
         }

      }

      public void gxTv_SdtServidorSMTP_Servidorsmtpusuario_N_SetNull( )
      {
         gxTv_SdtServidorSMTP_Servidorsmtpusuario_N = 0;
         SetDirty("Servidorsmtpusuario_N");
         return  ;
      }

      public bool gxTv_SdtServidorSMTP_Servidorsmtpusuario_N_IsNull( )
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
         gxTv_SdtServidorSMTP_Servidorsmtpserver = "";
         gxTv_SdtServidorSMTP_Servidorsmtpporta = "";
         gxTv_SdtServidorSMTP_Servidorsmtpemail = "";
         gxTv_SdtServidorSMTP_Servidorsmtppass = "";
         gxTv_SdtServidorSMTP_Servidorsmtpusuario = "";
         gxTv_SdtServidorSMTP_Mode = "";
         gxTv_SdtServidorSMTP_Servidorsmtpserver_Z = "";
         gxTv_SdtServidorSMTP_Servidorsmtpporta_Z = "";
         gxTv_SdtServidorSMTP_Servidorsmtpemail_Z = "";
         gxTv_SdtServidorSMTP_Servidorsmtppass_Z = "";
         gxTv_SdtServidorSMTP_Servidorsmtpusuario_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "servidorsmtp", "GeneXus.Programs.servidorsmtp_bc", new Object[] {context}, constructorCallingAssembly);;
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

      private short gxTv_SdtServidorSMTP_Servidorsmtpid ;
      private short sdtIsNull ;
      private short gxTv_SdtServidorSMTP_Initialized ;
      private short gxTv_SdtServidorSMTP_Servidorsmtpid_Z ;
      private short gxTv_SdtServidorSMTP_Servidorsmtpserver_N ;
      private short gxTv_SdtServidorSMTP_Servidorsmtpporta_N ;
      private short gxTv_SdtServidorSMTP_Servidorsmtpemail_N ;
      private short gxTv_SdtServidorSMTP_Servidorsmtppass_N ;
      private short gxTv_SdtServidorSMTP_Servidorsmtpusuario_N ;
      private string gxTv_SdtServidorSMTP_Mode ;
      private string gxTv_SdtServidorSMTP_Servidorsmtpserver ;
      private string gxTv_SdtServidorSMTP_Servidorsmtpporta ;
      private string gxTv_SdtServidorSMTP_Servidorsmtpemail ;
      private string gxTv_SdtServidorSMTP_Servidorsmtppass ;
      private string gxTv_SdtServidorSMTP_Servidorsmtpusuario ;
      private string gxTv_SdtServidorSMTP_Servidorsmtpserver_Z ;
      private string gxTv_SdtServidorSMTP_Servidorsmtpporta_Z ;
      private string gxTv_SdtServidorSMTP_Servidorsmtpemail_Z ;
      private string gxTv_SdtServidorSMTP_Servidorsmtppass_Z ;
      private string gxTv_SdtServidorSMTP_Servidorsmtpusuario_Z ;
   }

   [DataContract(Name = @"ServidorSMTP", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtServidorSMTP_RESTInterface : GxGenericCollectionItem<SdtServidorSMTP>
   {
      public SdtServidorSMTP_RESTInterface( ) : base()
      {
      }

      public SdtServidorSMTP_RESTInterface( SdtServidorSMTP psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ServidorSMTPId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Servidorsmtpid
      {
         get {
            return sdt.gxTpr_Servidorsmtpid ;
         }

         set {
            sdt.gxTpr_Servidorsmtpid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ServidorSMTPServer" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Servidorsmtpserver
      {
         get {
            return sdt.gxTpr_Servidorsmtpserver ;
         }

         set {
            sdt.gxTpr_Servidorsmtpserver = value;
         }

      }

      [DataMember( Name = "ServidorSMTPPorta" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Servidorsmtpporta
      {
         get {
            return sdt.gxTpr_Servidorsmtpporta ;
         }

         set {
            sdt.gxTpr_Servidorsmtpporta = value;
         }

      }

      [DataMember( Name = "ServidorSMTPEmail" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Servidorsmtpemail
      {
         get {
            return sdt.gxTpr_Servidorsmtpemail ;
         }

         set {
            sdt.gxTpr_Servidorsmtpemail = value;
         }

      }

      [DataMember( Name = "ServidorSMTPPass" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Servidorsmtppass
      {
         get {
            return sdt.gxTpr_Servidorsmtppass ;
         }

         set {
            sdt.gxTpr_Servidorsmtppass = value;
         }

      }

      [DataMember( Name = "ServidorSMTPUsuario" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Servidorsmtpusuario
      {
         get {
            return sdt.gxTpr_Servidorsmtpusuario ;
         }

         set {
            sdt.gxTpr_Servidorsmtpusuario = value;
         }

      }

      public SdtServidorSMTP sdt
      {
         get {
            return (SdtServidorSMTP)Sdt ;
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
            sdt = new SdtServidorSMTP() ;
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

   [DataContract(Name = @"ServidorSMTP", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtServidorSMTP_RESTLInterface : GxGenericCollectionItem<SdtServidorSMTP>
   {
      public SdtServidorSMTP_RESTLInterface( ) : base()
      {
      }

      public SdtServidorSMTP_RESTLInterface( SdtServidorSMTP psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ServidorSMTPServer" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Servidorsmtpserver
      {
         get {
            return sdt.gxTpr_Servidorsmtpserver ;
         }

         set {
            sdt.gxTpr_Servidorsmtpserver = value;
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

      public SdtServidorSMTP sdt
      {
         get {
            return (SdtServidorSMTP)Sdt ;
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
            sdt = new SdtServidorSMTP() ;
         }
      }

   }

}
