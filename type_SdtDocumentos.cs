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
   [XmlRoot(ElementName = "Documentos" )]
   [XmlType(TypeName =  "Documentos" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtDocumentos : GxSilentTrnSdt
   {
      public SdtDocumentos( )
      {
      }

      public SdtDocumentos( IGxContext context )
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

      public void Load( int AV405DocumentosId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV405DocumentosId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"DocumentosId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Documentos");
         metadata.Set("BT", "Documentos");
         metadata.Set("PK", "[ \"DocumentosId\" ]");
         metadata.Set("PKAssigned", "[ \"DocumentosId\" ]");
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
         state.Add("gxTpr_Documentosid_Z");
         state.Add("gxTpr_Documentosdescricao_Z");
         state.Add("gxTpr_Documentosstatus_Z");
         state.Add("gxTpr_Documentoobrigatorio_Z");
         state.Add("gxTpr_Documentoobrigatorioreembolso_Z");
         state.Add("gxTpr_Documentosid_N");
         state.Add("gxTpr_Documentosdescricao_N");
         state.Add("gxTpr_Documentosstatus_N");
         state.Add("gxTpr_Documentoobrigatorio_N");
         state.Add("gxTpr_Documentoobrigatorioreembolso_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtDocumentos sdt;
         sdt = (SdtDocumentos)(source);
         gxTv_SdtDocumentos_Documentosid = sdt.gxTv_SdtDocumentos_Documentosid ;
         gxTv_SdtDocumentos_Documentosdescricao = sdt.gxTv_SdtDocumentos_Documentosdescricao ;
         gxTv_SdtDocumentos_Documentosstatus = sdt.gxTv_SdtDocumentos_Documentosstatus ;
         gxTv_SdtDocumentos_Documentoobrigatorio = sdt.gxTv_SdtDocumentos_Documentoobrigatorio ;
         gxTv_SdtDocumentos_Documentoobrigatorioreembolso = sdt.gxTv_SdtDocumentos_Documentoobrigatorioreembolso ;
         gxTv_SdtDocumentos_Mode = sdt.gxTv_SdtDocumentos_Mode ;
         gxTv_SdtDocumentos_Initialized = sdt.gxTv_SdtDocumentos_Initialized ;
         gxTv_SdtDocumentos_Documentosid_Z = sdt.gxTv_SdtDocumentos_Documentosid_Z ;
         gxTv_SdtDocumentos_Documentosdescricao_Z = sdt.gxTv_SdtDocumentos_Documentosdescricao_Z ;
         gxTv_SdtDocumentos_Documentosstatus_Z = sdt.gxTv_SdtDocumentos_Documentosstatus_Z ;
         gxTv_SdtDocumentos_Documentoobrigatorio_Z = sdt.gxTv_SdtDocumentos_Documentoobrigatorio_Z ;
         gxTv_SdtDocumentos_Documentoobrigatorioreembolso_Z = sdt.gxTv_SdtDocumentos_Documentoobrigatorioreembolso_Z ;
         gxTv_SdtDocumentos_Documentosid_N = sdt.gxTv_SdtDocumentos_Documentosid_N ;
         gxTv_SdtDocumentos_Documentosdescricao_N = sdt.gxTv_SdtDocumentos_Documentosdescricao_N ;
         gxTv_SdtDocumentos_Documentosstatus_N = sdt.gxTv_SdtDocumentos_Documentosstatus_N ;
         gxTv_SdtDocumentos_Documentoobrigatorio_N = sdt.gxTv_SdtDocumentos_Documentoobrigatorio_N ;
         gxTv_SdtDocumentos_Documentoobrigatorioreembolso_N = sdt.gxTv_SdtDocumentos_Documentoobrigatorioreembolso_N ;
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
         AddObjectProperty("DocumentosId", gxTv_SdtDocumentos_Documentosid, false, includeNonInitialized);
         AddObjectProperty("DocumentosId_N", gxTv_SdtDocumentos_Documentosid_N, false, includeNonInitialized);
         AddObjectProperty("DocumentosDescricao", gxTv_SdtDocumentos_Documentosdescricao, false, includeNonInitialized);
         AddObjectProperty("DocumentosDescricao_N", gxTv_SdtDocumentos_Documentosdescricao_N, false, includeNonInitialized);
         AddObjectProperty("DocumentosStatus", gxTv_SdtDocumentos_Documentosstatus, false, includeNonInitialized);
         AddObjectProperty("DocumentosStatus_N", gxTv_SdtDocumentos_Documentosstatus_N, false, includeNonInitialized);
         AddObjectProperty("DocumentoObrigatorio", gxTv_SdtDocumentos_Documentoobrigatorio, false, includeNonInitialized);
         AddObjectProperty("DocumentoObrigatorio_N", gxTv_SdtDocumentos_Documentoobrigatorio_N, false, includeNonInitialized);
         AddObjectProperty("DocumentoObrigatorioReembolso", gxTv_SdtDocumentos_Documentoobrigatorioreembolso, false, includeNonInitialized);
         AddObjectProperty("DocumentoObrigatorioReembolso_N", gxTv_SdtDocumentos_Documentoobrigatorioreembolso_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtDocumentos_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtDocumentos_Initialized, false, includeNonInitialized);
            AddObjectProperty("DocumentosId_Z", gxTv_SdtDocumentos_Documentosid_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentosDescricao_Z", gxTv_SdtDocumentos_Documentosdescricao_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentosStatus_Z", gxTv_SdtDocumentos_Documentosstatus_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentoObrigatorio_Z", gxTv_SdtDocumentos_Documentoobrigatorio_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentoObrigatorioReembolso_Z", gxTv_SdtDocumentos_Documentoobrigatorioreembolso_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentosId_N", gxTv_SdtDocumentos_Documentosid_N, false, includeNonInitialized);
            AddObjectProperty("DocumentosDescricao_N", gxTv_SdtDocumentos_Documentosdescricao_N, false, includeNonInitialized);
            AddObjectProperty("DocumentosStatus_N", gxTv_SdtDocumentos_Documentosstatus_N, false, includeNonInitialized);
            AddObjectProperty("DocumentoObrigatorio_N", gxTv_SdtDocumentos_Documentoobrigatorio_N, false, includeNonInitialized);
            AddObjectProperty("DocumentoObrigatorioReembolso_N", gxTv_SdtDocumentos_Documentoobrigatorioreembolso_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtDocumentos sdt )
      {
         if ( sdt.IsDirty("DocumentosId") )
         {
            sdtIsNull = 0;
            gxTv_SdtDocumentos_Documentosid = sdt.gxTv_SdtDocumentos_Documentosid ;
         }
         if ( sdt.IsDirty("DocumentosDescricao") )
         {
            gxTv_SdtDocumentos_Documentosdescricao_N = (short)(sdt.gxTv_SdtDocumentos_Documentosdescricao_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentos_Documentosdescricao = sdt.gxTv_SdtDocumentos_Documentosdescricao ;
         }
         if ( sdt.IsDirty("DocumentosStatus") )
         {
            gxTv_SdtDocumentos_Documentosstatus_N = (short)(sdt.gxTv_SdtDocumentos_Documentosstatus_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentos_Documentosstatus = sdt.gxTv_SdtDocumentos_Documentosstatus ;
         }
         if ( sdt.IsDirty("DocumentoObrigatorio") )
         {
            gxTv_SdtDocumentos_Documentoobrigatorio_N = (short)(sdt.gxTv_SdtDocumentos_Documentoobrigatorio_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentos_Documentoobrigatorio = sdt.gxTv_SdtDocumentos_Documentoobrigatorio ;
         }
         if ( sdt.IsDirty("DocumentoObrigatorioReembolso") )
         {
            gxTv_SdtDocumentos_Documentoobrigatorioreembolso_N = (short)(sdt.gxTv_SdtDocumentos_Documentoobrigatorioreembolso_N);
            sdtIsNull = 0;
            gxTv_SdtDocumentos_Documentoobrigatorioreembolso = sdt.gxTv_SdtDocumentos_Documentoobrigatorioreembolso ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "DocumentosId" )]
      [  XmlElement( ElementName = "DocumentosId"   )]
      public int gxTpr_Documentosid
      {
         get {
            return gxTv_SdtDocumentos_Documentosid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtDocumentos_Documentosid != value )
            {
               gxTv_SdtDocumentos_Mode = "INS";
               this.gxTv_SdtDocumentos_Documentosid_Z_SetNull( );
               this.gxTv_SdtDocumentos_Documentosdescricao_Z_SetNull( );
               this.gxTv_SdtDocumentos_Documentosstatus_Z_SetNull( );
               this.gxTv_SdtDocumentos_Documentoobrigatorio_Z_SetNull( );
               this.gxTv_SdtDocumentos_Documentoobrigatorioreembolso_Z_SetNull( );
            }
            gxTv_SdtDocumentos_Documentosid = value;
            SetDirty("Documentosid");
         }

      }

      [  SoapElement( ElementName = "DocumentosDescricao" )]
      [  XmlElement( ElementName = "DocumentosDescricao"   )]
      public string gxTpr_Documentosdescricao
      {
         get {
            return gxTv_SdtDocumentos_Documentosdescricao ;
         }

         set {
            gxTv_SdtDocumentos_Documentosdescricao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentos_Documentosdescricao = value;
            SetDirty("Documentosdescricao");
         }

      }

      public void gxTv_SdtDocumentos_Documentosdescricao_SetNull( )
      {
         gxTv_SdtDocumentos_Documentosdescricao_N = 1;
         gxTv_SdtDocumentos_Documentosdescricao = "";
         SetDirty("Documentosdescricao");
         return  ;
      }

      public bool gxTv_SdtDocumentos_Documentosdescricao_IsNull( )
      {
         return (gxTv_SdtDocumentos_Documentosdescricao_N==1) ;
      }

      [  SoapElement( ElementName = "DocumentosStatus" )]
      [  XmlElement( ElementName = "DocumentosStatus"   )]
      public bool gxTpr_Documentosstatus
      {
         get {
            return gxTv_SdtDocumentos_Documentosstatus ;
         }

         set {
            gxTv_SdtDocumentos_Documentosstatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentos_Documentosstatus = value;
            SetDirty("Documentosstatus");
         }

      }

      public void gxTv_SdtDocumentos_Documentosstatus_SetNull( )
      {
         gxTv_SdtDocumentos_Documentosstatus_N = 1;
         gxTv_SdtDocumentos_Documentosstatus = false;
         SetDirty("Documentosstatus");
         return  ;
      }

      public bool gxTv_SdtDocumentos_Documentosstatus_IsNull( )
      {
         return (gxTv_SdtDocumentos_Documentosstatus_N==1) ;
      }

      [  SoapElement( ElementName = "DocumentoObrigatorio" )]
      [  XmlElement( ElementName = "DocumentoObrigatorio"   )]
      public bool gxTpr_Documentoobrigatorio
      {
         get {
            return gxTv_SdtDocumentos_Documentoobrigatorio ;
         }

         set {
            gxTv_SdtDocumentos_Documentoobrigatorio_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentos_Documentoobrigatorio = value;
            SetDirty("Documentoobrigatorio");
         }

      }

      public void gxTv_SdtDocumentos_Documentoobrigatorio_SetNull( )
      {
         gxTv_SdtDocumentos_Documentoobrigatorio_N = 1;
         gxTv_SdtDocumentos_Documentoobrigatorio = false;
         SetDirty("Documentoobrigatorio");
         return  ;
      }

      public bool gxTv_SdtDocumentos_Documentoobrigatorio_IsNull( )
      {
         return (gxTv_SdtDocumentos_Documentoobrigatorio_N==1) ;
      }

      [  SoapElement( ElementName = "DocumentoObrigatorioReembolso" )]
      [  XmlElement( ElementName = "DocumentoObrigatorioReembolso"   )]
      public bool gxTpr_Documentoobrigatorioreembolso
      {
         get {
            return gxTv_SdtDocumentos_Documentoobrigatorioreembolso ;
         }

         set {
            gxTv_SdtDocumentos_Documentoobrigatorioreembolso_N = 0;
            sdtIsNull = 0;
            gxTv_SdtDocumentos_Documentoobrigatorioreembolso = value;
            SetDirty("Documentoobrigatorioreembolso");
         }

      }

      public void gxTv_SdtDocumentos_Documentoobrigatorioreembolso_SetNull( )
      {
         gxTv_SdtDocumentos_Documentoobrigatorioreembolso_N = 1;
         gxTv_SdtDocumentos_Documentoobrigatorioreembolso = false;
         SetDirty("Documentoobrigatorioreembolso");
         return  ;
      }

      public bool gxTv_SdtDocumentos_Documentoobrigatorioreembolso_IsNull( )
      {
         return (gxTv_SdtDocumentos_Documentoobrigatorioreembolso_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtDocumentos_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentos_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtDocumentos_Mode_SetNull( )
      {
         gxTv_SdtDocumentos_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtDocumentos_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtDocumentos_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentos_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtDocumentos_Initialized_SetNull( )
      {
         gxTv_SdtDocumentos_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtDocumentos_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentosId_Z" )]
      [  XmlElement( ElementName = "DocumentosId_Z"   )]
      public int gxTpr_Documentosid_Z
      {
         get {
            return gxTv_SdtDocumentos_Documentosid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentos_Documentosid_Z = value;
            SetDirty("Documentosid_Z");
         }

      }

      public void gxTv_SdtDocumentos_Documentosid_Z_SetNull( )
      {
         gxTv_SdtDocumentos_Documentosid_Z = 0;
         SetDirty("Documentosid_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentos_Documentosid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentosDescricao_Z" )]
      [  XmlElement( ElementName = "DocumentosDescricao_Z"   )]
      public string gxTpr_Documentosdescricao_Z
      {
         get {
            return gxTv_SdtDocumentos_Documentosdescricao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentos_Documentosdescricao_Z = value;
            SetDirty("Documentosdescricao_Z");
         }

      }

      public void gxTv_SdtDocumentos_Documentosdescricao_Z_SetNull( )
      {
         gxTv_SdtDocumentos_Documentosdescricao_Z = "";
         SetDirty("Documentosdescricao_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentos_Documentosdescricao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentosStatus_Z" )]
      [  XmlElement( ElementName = "DocumentosStatus_Z"   )]
      public bool gxTpr_Documentosstatus_Z
      {
         get {
            return gxTv_SdtDocumentos_Documentosstatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentos_Documentosstatus_Z = value;
            SetDirty("Documentosstatus_Z");
         }

      }

      public void gxTv_SdtDocumentos_Documentosstatus_Z_SetNull( )
      {
         gxTv_SdtDocumentos_Documentosstatus_Z = false;
         SetDirty("Documentosstatus_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentos_Documentosstatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoObrigatorio_Z" )]
      [  XmlElement( ElementName = "DocumentoObrigatorio_Z"   )]
      public bool gxTpr_Documentoobrigatorio_Z
      {
         get {
            return gxTv_SdtDocumentos_Documentoobrigatorio_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentos_Documentoobrigatorio_Z = value;
            SetDirty("Documentoobrigatorio_Z");
         }

      }

      public void gxTv_SdtDocumentos_Documentoobrigatorio_Z_SetNull( )
      {
         gxTv_SdtDocumentos_Documentoobrigatorio_Z = false;
         SetDirty("Documentoobrigatorio_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentos_Documentoobrigatorio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoObrigatorioReembolso_Z" )]
      [  XmlElement( ElementName = "DocumentoObrigatorioReembolso_Z"   )]
      public bool gxTpr_Documentoobrigatorioreembolso_Z
      {
         get {
            return gxTv_SdtDocumentos_Documentoobrigatorioreembolso_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentos_Documentoobrigatorioreembolso_Z = value;
            SetDirty("Documentoobrigatorioreembolso_Z");
         }

      }

      public void gxTv_SdtDocumentos_Documentoobrigatorioreembolso_Z_SetNull( )
      {
         gxTv_SdtDocumentos_Documentoobrigatorioreembolso_Z = false;
         SetDirty("Documentoobrigatorioreembolso_Z");
         return  ;
      }

      public bool gxTv_SdtDocumentos_Documentoobrigatorioreembolso_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentosId_N" )]
      [  XmlElement( ElementName = "DocumentosId_N"   )]
      public short gxTpr_Documentosid_N
      {
         get {
            return gxTv_SdtDocumentos_Documentosid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentos_Documentosid_N = value;
            SetDirty("Documentosid_N");
         }

      }

      public void gxTv_SdtDocumentos_Documentosid_N_SetNull( )
      {
         gxTv_SdtDocumentos_Documentosid_N = 0;
         SetDirty("Documentosid_N");
         return  ;
      }

      public bool gxTv_SdtDocumentos_Documentosid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentosDescricao_N" )]
      [  XmlElement( ElementName = "DocumentosDescricao_N"   )]
      public short gxTpr_Documentosdescricao_N
      {
         get {
            return gxTv_SdtDocumentos_Documentosdescricao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentos_Documentosdescricao_N = value;
            SetDirty("Documentosdescricao_N");
         }

      }

      public void gxTv_SdtDocumentos_Documentosdescricao_N_SetNull( )
      {
         gxTv_SdtDocumentos_Documentosdescricao_N = 0;
         SetDirty("Documentosdescricao_N");
         return  ;
      }

      public bool gxTv_SdtDocumentos_Documentosdescricao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentosStatus_N" )]
      [  XmlElement( ElementName = "DocumentosStatus_N"   )]
      public short gxTpr_Documentosstatus_N
      {
         get {
            return gxTv_SdtDocumentos_Documentosstatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentos_Documentosstatus_N = value;
            SetDirty("Documentosstatus_N");
         }

      }

      public void gxTv_SdtDocumentos_Documentosstatus_N_SetNull( )
      {
         gxTv_SdtDocumentos_Documentosstatus_N = 0;
         SetDirty("Documentosstatus_N");
         return  ;
      }

      public bool gxTv_SdtDocumentos_Documentosstatus_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoObrigatorio_N" )]
      [  XmlElement( ElementName = "DocumentoObrigatorio_N"   )]
      public short gxTpr_Documentoobrigatorio_N
      {
         get {
            return gxTv_SdtDocumentos_Documentoobrigatorio_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentos_Documentoobrigatorio_N = value;
            SetDirty("Documentoobrigatorio_N");
         }

      }

      public void gxTv_SdtDocumentos_Documentoobrigatorio_N_SetNull( )
      {
         gxTv_SdtDocumentos_Documentoobrigatorio_N = 0;
         SetDirty("Documentoobrigatorio_N");
         return  ;
      }

      public bool gxTv_SdtDocumentos_Documentoobrigatorio_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentoObrigatorioReembolso_N" )]
      [  XmlElement( ElementName = "DocumentoObrigatorioReembolso_N"   )]
      public short gxTpr_Documentoobrigatorioreembolso_N
      {
         get {
            return gxTv_SdtDocumentos_Documentoobrigatorioreembolso_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtDocumentos_Documentoobrigatorioreembolso_N = value;
            SetDirty("Documentoobrigatorioreembolso_N");
         }

      }

      public void gxTv_SdtDocumentos_Documentoobrigatorioreembolso_N_SetNull( )
      {
         gxTv_SdtDocumentos_Documentoobrigatorioreembolso_N = 0;
         SetDirty("Documentoobrigatorioreembolso_N");
         return  ;
      }

      public bool gxTv_SdtDocumentos_Documentoobrigatorioreembolso_N_IsNull( )
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
         gxTv_SdtDocumentos_Documentosdescricao = "";
         gxTv_SdtDocumentos_Mode = "";
         gxTv_SdtDocumentos_Documentosdescricao_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "documentos", "GeneXus.Programs.documentos_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtDocumentos_Initialized ;
      private short gxTv_SdtDocumentos_Documentosid_N ;
      private short gxTv_SdtDocumentos_Documentosdescricao_N ;
      private short gxTv_SdtDocumentos_Documentosstatus_N ;
      private short gxTv_SdtDocumentos_Documentoobrigatorio_N ;
      private short gxTv_SdtDocumentos_Documentoobrigatorioreembolso_N ;
      private int gxTv_SdtDocumentos_Documentosid ;
      private int gxTv_SdtDocumentos_Documentosid_Z ;
      private string gxTv_SdtDocumentos_Mode ;
      private bool gxTv_SdtDocumentos_Documentosstatus ;
      private bool gxTv_SdtDocumentos_Documentoobrigatorio ;
      private bool gxTv_SdtDocumentos_Documentoobrigatorioreembolso ;
      private bool gxTv_SdtDocumentos_Documentosstatus_Z ;
      private bool gxTv_SdtDocumentos_Documentoobrigatorio_Z ;
      private bool gxTv_SdtDocumentos_Documentoobrigatorioreembolso_Z ;
      private string gxTv_SdtDocumentos_Documentosdescricao ;
      private string gxTv_SdtDocumentos_Documentosdescricao_Z ;
   }

   [DataContract(Name = @"Documentos", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtDocumentos_RESTInterface : GxGenericCollectionItem<SdtDocumentos>
   {
      public SdtDocumentos_RESTInterface( ) : base()
      {
      }

      public SdtDocumentos_RESTInterface( SdtDocumentos psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "DocumentosId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Documentosid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Documentosid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Documentosid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "DocumentosDescricao" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Documentosdescricao
      {
         get {
            return sdt.gxTpr_Documentosdescricao ;
         }

         set {
            sdt.gxTpr_Documentosdescricao = value;
         }

      }

      [DataMember( Name = "DocumentosStatus" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Documentosstatus
      {
         get {
            return sdt.gxTpr_Documentosstatus ;
         }

         set {
            sdt.gxTpr_Documentosstatus = value;
         }

      }

      [DataMember( Name = "DocumentoObrigatorio" , Order = 3 )]
      [GxSeudo()]
      public bool gxTpr_Documentoobrigatorio
      {
         get {
            return sdt.gxTpr_Documentoobrigatorio ;
         }

         set {
            sdt.gxTpr_Documentoobrigatorio = value;
         }

      }

      [DataMember( Name = "DocumentoObrigatorioReembolso" , Order = 4 )]
      [GxSeudo()]
      public bool gxTpr_Documentoobrigatorioreembolso
      {
         get {
            return sdt.gxTpr_Documentoobrigatorioreembolso ;
         }

         set {
            sdt.gxTpr_Documentoobrigatorioreembolso = value;
         }

      }

      public SdtDocumentos sdt
      {
         get {
            return (SdtDocumentos)Sdt ;
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
            sdt = new SdtDocumentos() ;
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

   [DataContract(Name = @"Documentos", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtDocumentos_RESTLInterface : GxGenericCollectionItem<SdtDocumentos>
   {
      public SdtDocumentos_RESTLInterface( ) : base()
      {
      }

      public SdtDocumentos_RESTLInterface( SdtDocumentos psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "DocumentosDescricao" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Documentosdescricao
      {
         get {
            return sdt.gxTpr_Documentosdescricao ;
         }

         set {
            sdt.gxTpr_Documentosdescricao = value;
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

      public SdtDocumentos sdt
      {
         get {
            return (SdtDocumentos)Sdt ;
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
            sdt = new SdtDocumentos() ;
         }
      }

   }

}
