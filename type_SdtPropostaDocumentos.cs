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
   [XmlRoot(ElementName = "PropostaDocumentos" )]
   [XmlType(TypeName =  "PropostaDocumentos" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtPropostaDocumentos : GxSilentTrnSdt
   {
      public SdtPropostaDocumentos( )
      {
      }

      public SdtPropostaDocumentos( IGxContext context )
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

      public void Load( int AV414PropostaDocumentosId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV414PropostaDocumentosId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"PropostaDocumentosId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "PropostaDocumentos");
         metadata.Set("BT", "PropostaDocumentos");
         metadata.Set("PK", "[ \"PropostaDocumentosId\" ]");
         metadata.Set("PKAssigned", "[ \"PropostaDocumentosId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"DocumentosId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"PropostaId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Propostadocumentosid_Z");
         state.Add("gxTpr_Propostaid_Z");
         state.Add("gxTpr_Documentosid_Z");
         state.Add("gxTpr_Documentosdescricao_Z");
         state.Add("gxTpr_Documentosstatus_Z");
         state.Add("gxTpr_Propostadocumentosanexoname_Z");
         state.Add("gxTpr_Propostadocumentosanexofiletype_Z");
         state.Add("gxTpr_Propostadocumentosstatus_Z");
         state.Add("gxTpr_Propostadocumentosadm_Z");
         state.Add("gxTpr_Propostaid_N");
         state.Add("gxTpr_Documentosid_N");
         state.Add("gxTpr_Documentosdescricao_N");
         state.Add("gxTpr_Documentosstatus_N");
         state.Add("gxTpr_Propostadocumentosanexo_N");
         state.Add("gxTpr_Propostadocumentosanexoname_N");
         state.Add("gxTpr_Propostadocumentosanexofiletype_N");
         state.Add("gxTpr_Propostadocumentosstatus_N");
         state.Add("gxTpr_Propostadocumentosadm_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtPropostaDocumentos sdt;
         sdt = (SdtPropostaDocumentos)(source);
         gxTv_SdtPropostaDocumentos_Propostadocumentosid = sdt.gxTv_SdtPropostaDocumentos_Propostadocumentosid ;
         gxTv_SdtPropostaDocumentos_Propostaid = sdt.gxTv_SdtPropostaDocumentos_Propostaid ;
         gxTv_SdtPropostaDocumentos_Documentosid = sdt.gxTv_SdtPropostaDocumentos_Documentosid ;
         gxTv_SdtPropostaDocumentos_Documentosdescricao = sdt.gxTv_SdtPropostaDocumentos_Documentosdescricao ;
         gxTv_SdtPropostaDocumentos_Documentosstatus = sdt.gxTv_SdtPropostaDocumentos_Documentosstatus ;
         gxTv_SdtPropostaDocumentos_Propostadocumentosanexo = sdt.gxTv_SdtPropostaDocumentos_Propostadocumentosanexo ;
         gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname = sdt.gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname ;
         gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype = sdt.gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype ;
         gxTv_SdtPropostaDocumentos_Propostadocumentosstatus = sdt.gxTv_SdtPropostaDocumentos_Propostadocumentosstatus ;
         gxTv_SdtPropostaDocumentos_Propostadocumentosadm = sdt.gxTv_SdtPropostaDocumentos_Propostadocumentosadm ;
         gxTv_SdtPropostaDocumentos_Mode = sdt.gxTv_SdtPropostaDocumentos_Mode ;
         gxTv_SdtPropostaDocumentos_Initialized = sdt.gxTv_SdtPropostaDocumentos_Initialized ;
         gxTv_SdtPropostaDocumentos_Propostadocumentosid_Z = sdt.gxTv_SdtPropostaDocumentos_Propostadocumentosid_Z ;
         gxTv_SdtPropostaDocumentos_Propostaid_Z = sdt.gxTv_SdtPropostaDocumentos_Propostaid_Z ;
         gxTv_SdtPropostaDocumentos_Documentosid_Z = sdt.gxTv_SdtPropostaDocumentos_Documentosid_Z ;
         gxTv_SdtPropostaDocumentos_Documentosdescricao_Z = sdt.gxTv_SdtPropostaDocumentos_Documentosdescricao_Z ;
         gxTv_SdtPropostaDocumentos_Documentosstatus_Z = sdt.gxTv_SdtPropostaDocumentos_Documentosstatus_Z ;
         gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname_Z = sdt.gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname_Z ;
         gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype_Z = sdt.gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype_Z ;
         gxTv_SdtPropostaDocumentos_Propostadocumentosstatus_Z = sdt.gxTv_SdtPropostaDocumentos_Propostadocumentosstatus_Z ;
         gxTv_SdtPropostaDocumentos_Propostadocumentosadm_Z = sdt.gxTv_SdtPropostaDocumentos_Propostadocumentosadm_Z ;
         gxTv_SdtPropostaDocumentos_Propostaid_N = sdt.gxTv_SdtPropostaDocumentos_Propostaid_N ;
         gxTv_SdtPropostaDocumentos_Documentosid_N = sdt.gxTv_SdtPropostaDocumentos_Documentosid_N ;
         gxTv_SdtPropostaDocumentos_Documentosdescricao_N = sdt.gxTv_SdtPropostaDocumentos_Documentosdescricao_N ;
         gxTv_SdtPropostaDocumentos_Documentosstatus_N = sdt.gxTv_SdtPropostaDocumentos_Documentosstatus_N ;
         gxTv_SdtPropostaDocumentos_Propostadocumentosanexo_N = sdt.gxTv_SdtPropostaDocumentos_Propostadocumentosanexo_N ;
         gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname_N = sdt.gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname_N ;
         gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype_N = sdt.gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype_N ;
         gxTv_SdtPropostaDocumentos_Propostadocumentosstatus_N = sdt.gxTv_SdtPropostaDocumentos_Propostadocumentosstatus_N ;
         gxTv_SdtPropostaDocumentos_Propostadocumentosadm_N = sdt.gxTv_SdtPropostaDocumentos_Propostadocumentosadm_N ;
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
         AddObjectProperty("PropostaDocumentosId", gxTv_SdtPropostaDocumentos_Propostadocumentosid, false, includeNonInitialized);
         AddObjectProperty("PropostaId", gxTv_SdtPropostaDocumentos_Propostaid, false, includeNonInitialized);
         AddObjectProperty("PropostaId_N", gxTv_SdtPropostaDocumentos_Propostaid_N, false, includeNonInitialized);
         AddObjectProperty("DocumentosId", gxTv_SdtPropostaDocumentos_Documentosid, false, includeNonInitialized);
         AddObjectProperty("DocumentosId_N", gxTv_SdtPropostaDocumentos_Documentosid_N, false, includeNonInitialized);
         AddObjectProperty("DocumentosDescricao", gxTv_SdtPropostaDocumentos_Documentosdescricao, false, includeNonInitialized);
         AddObjectProperty("DocumentosDescricao_N", gxTv_SdtPropostaDocumentos_Documentosdescricao_N, false, includeNonInitialized);
         AddObjectProperty("DocumentosStatus", gxTv_SdtPropostaDocumentos_Documentosstatus, false, includeNonInitialized);
         AddObjectProperty("DocumentosStatus_N", gxTv_SdtPropostaDocumentos_Documentosstatus_N, false, includeNonInitialized);
         AddObjectProperty("PropostaDocumentosAnexo", gxTv_SdtPropostaDocumentos_Propostadocumentosanexo, false, includeNonInitialized);
         AddObjectProperty("PropostaDocumentosAnexo_N", gxTv_SdtPropostaDocumentos_Propostadocumentosanexo_N, false, includeNonInitialized);
         AddObjectProperty("PropostaDocumentosAnexoName", gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname, false, includeNonInitialized);
         AddObjectProperty("PropostaDocumentosAnexoName_N", gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname_N, false, includeNonInitialized);
         AddObjectProperty("PropostaDocumentosAnexoFileType", gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype, false, includeNonInitialized);
         AddObjectProperty("PropostaDocumentosAnexoFileType_N", gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype_N, false, includeNonInitialized);
         AddObjectProperty("PropostaDocumentosStatus", gxTv_SdtPropostaDocumentos_Propostadocumentosstatus, false, includeNonInitialized);
         AddObjectProperty("PropostaDocumentosStatus_N", gxTv_SdtPropostaDocumentos_Propostadocumentosstatus_N, false, includeNonInitialized);
         AddObjectProperty("PropostaDocumentosAdm", gxTv_SdtPropostaDocumentos_Propostadocumentosadm, false, includeNonInitialized);
         AddObjectProperty("PropostaDocumentosAdm_N", gxTv_SdtPropostaDocumentos_Propostadocumentosadm_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtPropostaDocumentos_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtPropostaDocumentos_Initialized, false, includeNonInitialized);
            AddObjectProperty("PropostaDocumentosId_Z", gxTv_SdtPropostaDocumentos_Propostadocumentosid_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaId_Z", gxTv_SdtPropostaDocumentos_Propostaid_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentosId_Z", gxTv_SdtPropostaDocumentos_Documentosid_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentosDescricao_Z", gxTv_SdtPropostaDocumentos_Documentosdescricao_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentosStatus_Z", gxTv_SdtPropostaDocumentos_Documentosstatus_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaDocumentosAnexoName_Z", gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaDocumentosAnexoFileType_Z", gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaDocumentosStatus_Z", gxTv_SdtPropostaDocumentos_Propostadocumentosstatus_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaDocumentosAdm_Z", gxTv_SdtPropostaDocumentos_Propostadocumentosadm_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaId_N", gxTv_SdtPropostaDocumentos_Propostaid_N, false, includeNonInitialized);
            AddObjectProperty("DocumentosId_N", gxTv_SdtPropostaDocumentos_Documentosid_N, false, includeNonInitialized);
            AddObjectProperty("DocumentosDescricao_N", gxTv_SdtPropostaDocumentos_Documentosdescricao_N, false, includeNonInitialized);
            AddObjectProperty("DocumentosStatus_N", gxTv_SdtPropostaDocumentos_Documentosstatus_N, false, includeNonInitialized);
            AddObjectProperty("PropostaDocumentosAnexo_N", gxTv_SdtPropostaDocumentos_Propostadocumentosanexo_N, false, includeNonInitialized);
            AddObjectProperty("PropostaDocumentosAnexoName_N", gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname_N, false, includeNonInitialized);
            AddObjectProperty("PropostaDocumentosAnexoFileType_N", gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype_N, false, includeNonInitialized);
            AddObjectProperty("PropostaDocumentosStatus_N", gxTv_SdtPropostaDocumentos_Propostadocumentosstatus_N, false, includeNonInitialized);
            AddObjectProperty("PropostaDocumentosAdm_N", gxTv_SdtPropostaDocumentos_Propostadocumentosadm_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtPropostaDocumentos sdt )
      {
         if ( sdt.IsDirty("PropostaDocumentosId") )
         {
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Propostadocumentosid = sdt.gxTv_SdtPropostaDocumentos_Propostadocumentosid ;
         }
         if ( sdt.IsDirty("PropostaId") )
         {
            gxTv_SdtPropostaDocumentos_Propostaid_N = (short)(sdt.gxTv_SdtPropostaDocumentos_Propostaid_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Propostaid = sdt.gxTv_SdtPropostaDocumentos_Propostaid ;
         }
         if ( sdt.IsDirty("DocumentosId") )
         {
            gxTv_SdtPropostaDocumentos_Documentosid_N = (short)(sdt.gxTv_SdtPropostaDocumentos_Documentosid_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Documentosid = sdt.gxTv_SdtPropostaDocumentos_Documentosid ;
         }
         if ( sdt.IsDirty("DocumentosDescricao") )
         {
            gxTv_SdtPropostaDocumentos_Documentosdescricao_N = (short)(sdt.gxTv_SdtPropostaDocumentos_Documentosdescricao_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Documentosdescricao = sdt.gxTv_SdtPropostaDocumentos_Documentosdescricao ;
         }
         if ( sdt.IsDirty("DocumentosStatus") )
         {
            gxTv_SdtPropostaDocumentos_Documentosstatus_N = (short)(sdt.gxTv_SdtPropostaDocumentos_Documentosstatus_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Documentosstatus = sdt.gxTv_SdtPropostaDocumentos_Documentosstatus ;
         }
         if ( sdt.IsDirty("PropostaDocumentosAnexo") )
         {
            gxTv_SdtPropostaDocumentos_Propostadocumentosanexo_N = (short)(sdt.gxTv_SdtPropostaDocumentos_Propostadocumentosanexo_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Propostadocumentosanexo = sdt.gxTv_SdtPropostaDocumentos_Propostadocumentosanexo ;
         }
         if ( sdt.IsDirty("PropostaDocumentosAnexoName") )
         {
            gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname_N = (short)(sdt.gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname = sdt.gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname ;
         }
         if ( sdt.IsDirty("PropostaDocumentosAnexoFileType") )
         {
            gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype_N = (short)(sdt.gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype = sdt.gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype ;
         }
         if ( sdt.IsDirty("PropostaDocumentosStatus") )
         {
            gxTv_SdtPropostaDocumentos_Propostadocumentosstatus_N = (short)(sdt.gxTv_SdtPropostaDocumentos_Propostadocumentosstatus_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Propostadocumentosstatus = sdt.gxTv_SdtPropostaDocumentos_Propostadocumentosstatus ;
         }
         if ( sdt.IsDirty("PropostaDocumentosAdm") )
         {
            gxTv_SdtPropostaDocumentos_Propostadocumentosadm_N = (short)(sdt.gxTv_SdtPropostaDocumentos_Propostadocumentosadm_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Propostadocumentosadm = sdt.gxTv_SdtPropostaDocumentos_Propostadocumentosadm ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "PropostaDocumentosId" )]
      [  XmlElement( ElementName = "PropostaDocumentosId"   )]
      public int gxTpr_Propostadocumentosid
      {
         get {
            return gxTv_SdtPropostaDocumentos_Propostadocumentosid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtPropostaDocumentos_Propostadocumentosid != value )
            {
               gxTv_SdtPropostaDocumentos_Mode = "INS";
               this.gxTv_SdtPropostaDocumentos_Propostadocumentosid_Z_SetNull( );
               this.gxTv_SdtPropostaDocumentos_Propostaid_Z_SetNull( );
               this.gxTv_SdtPropostaDocumentos_Documentosid_Z_SetNull( );
               this.gxTv_SdtPropostaDocumentos_Documentosdescricao_Z_SetNull( );
               this.gxTv_SdtPropostaDocumentos_Documentosstatus_Z_SetNull( );
               this.gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname_Z_SetNull( );
               this.gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype_Z_SetNull( );
               this.gxTv_SdtPropostaDocumentos_Propostadocumentosstatus_Z_SetNull( );
               this.gxTv_SdtPropostaDocumentos_Propostadocumentosadm_Z_SetNull( );
            }
            gxTv_SdtPropostaDocumentos_Propostadocumentosid = value;
            SetDirty("Propostadocumentosid");
         }

      }

      [  SoapElement( ElementName = "PropostaId" )]
      [  XmlElement( ElementName = "PropostaId"   )]
      public int gxTpr_Propostaid
      {
         get {
            return gxTv_SdtPropostaDocumentos_Propostaid ;
         }

         set {
            gxTv_SdtPropostaDocumentos_Propostaid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Propostaid = value;
            SetDirty("Propostaid");
         }

      }

      public void gxTv_SdtPropostaDocumentos_Propostaid_SetNull( )
      {
         gxTv_SdtPropostaDocumentos_Propostaid_N = 1;
         gxTv_SdtPropostaDocumentos_Propostaid = 0;
         SetDirty("Propostaid");
         return  ;
      }

      public bool gxTv_SdtPropostaDocumentos_Propostaid_IsNull( )
      {
         return (gxTv_SdtPropostaDocumentos_Propostaid_N==1) ;
      }

      [  SoapElement( ElementName = "DocumentosId" )]
      [  XmlElement( ElementName = "DocumentosId"   )]
      public int gxTpr_Documentosid
      {
         get {
            return gxTv_SdtPropostaDocumentos_Documentosid ;
         }

         set {
            gxTv_SdtPropostaDocumentos_Documentosid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Documentosid = value;
            SetDirty("Documentosid");
         }

      }

      public void gxTv_SdtPropostaDocumentos_Documentosid_SetNull( )
      {
         gxTv_SdtPropostaDocumentos_Documentosid_N = 1;
         gxTv_SdtPropostaDocumentos_Documentosid = 0;
         SetDirty("Documentosid");
         return  ;
      }

      public bool gxTv_SdtPropostaDocumentos_Documentosid_IsNull( )
      {
         return (gxTv_SdtPropostaDocumentos_Documentosid_N==1) ;
      }

      [  SoapElement( ElementName = "DocumentosDescricao" )]
      [  XmlElement( ElementName = "DocumentosDescricao"   )]
      public string gxTpr_Documentosdescricao
      {
         get {
            return gxTv_SdtPropostaDocumentos_Documentosdescricao ;
         }

         set {
            gxTv_SdtPropostaDocumentos_Documentosdescricao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Documentosdescricao = value;
            SetDirty("Documentosdescricao");
         }

      }

      public void gxTv_SdtPropostaDocumentos_Documentosdescricao_SetNull( )
      {
         gxTv_SdtPropostaDocumentos_Documentosdescricao_N = 1;
         gxTv_SdtPropostaDocumentos_Documentosdescricao = "";
         SetDirty("Documentosdescricao");
         return  ;
      }

      public bool gxTv_SdtPropostaDocumentos_Documentosdescricao_IsNull( )
      {
         return (gxTv_SdtPropostaDocumentos_Documentosdescricao_N==1) ;
      }

      [  SoapElement( ElementName = "DocumentosStatus" )]
      [  XmlElement( ElementName = "DocumentosStatus"   )]
      public bool gxTpr_Documentosstatus
      {
         get {
            return gxTv_SdtPropostaDocumentos_Documentosstatus ;
         }

         set {
            gxTv_SdtPropostaDocumentos_Documentosstatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Documentosstatus = value;
            SetDirty("Documentosstatus");
         }

      }

      public void gxTv_SdtPropostaDocumentos_Documentosstatus_SetNull( )
      {
         gxTv_SdtPropostaDocumentos_Documentosstatus_N = 1;
         gxTv_SdtPropostaDocumentos_Documentosstatus = false;
         SetDirty("Documentosstatus");
         return  ;
      }

      public bool gxTv_SdtPropostaDocumentos_Documentosstatus_IsNull( )
      {
         return (gxTv_SdtPropostaDocumentos_Documentosstatus_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaDocumentosAnexo" )]
      [  XmlElement( ElementName = "PropostaDocumentosAnexo"   )]
      [GxUpload()]
      public byte[] gxTpr_Propostadocumentosanexo_Blob
      {
         get {
            IGxContext context = this.context == null ? new GxContext() : this.context;
            return context.FileToByteArray( gxTv_SdtPropostaDocumentos_Propostadocumentosanexo) ;
         }

         set {
            gxTv_SdtPropostaDocumentos_Propostadocumentosanexo_N = 0;
            sdtIsNull = 0;
            IGxContext context = this.context == null ? new GxContext() : this.context;
            gxTv_SdtPropostaDocumentos_Propostadocumentosanexo=context.FileFromByteArray( value) ;
         }

      }

      [XmlIgnore]
      [GxUpload()]
      public string gxTpr_Propostadocumentosanexo
      {
         get {
            return gxTv_SdtPropostaDocumentos_Propostadocumentosanexo ;
         }

         set {
            gxTv_SdtPropostaDocumentos_Propostadocumentosanexo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Propostadocumentosanexo = value;
            SetDirty("Propostadocumentosanexo");
         }

      }

      public void gxTv_SdtPropostaDocumentos_Propostadocumentosanexo_SetBlob( string blob ,
                                                                              string fileName ,
                                                                              string fileType )
      {
         gxTv_SdtPropostaDocumentos_Propostadocumentosanexo = blob;
         return  ;
      }

      public void gxTv_SdtPropostaDocumentos_Propostadocumentosanexo_SetNull( )
      {
         gxTv_SdtPropostaDocumentos_Propostadocumentosanexo_N = 1;
         gxTv_SdtPropostaDocumentos_Propostadocumentosanexo = "";
         SetDirty("Propostadocumentosanexo");
         return  ;
      }

      public bool gxTv_SdtPropostaDocumentos_Propostadocumentosanexo_IsNull( )
      {
         return (gxTv_SdtPropostaDocumentos_Propostadocumentosanexo_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaDocumentosAnexoName" )]
      [  XmlElement( ElementName = "PropostaDocumentosAnexoName"   )]
      public string gxTpr_Propostadocumentosanexoname
      {
         get {
            return gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname ;
         }

         set {
            gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname = value;
            SetDirty("Propostadocumentosanexoname");
         }

      }

      public void gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname_SetNull( )
      {
         gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname_N = 1;
         gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname = "";
         SetDirty("Propostadocumentosanexoname");
         return  ;
      }

      public bool gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname_IsNull( )
      {
         return (gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaDocumentosAnexoFileType" )]
      [  XmlElement( ElementName = "PropostaDocumentosAnexoFileType"   )]
      public string gxTpr_Propostadocumentosanexofiletype
      {
         get {
            return gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype ;
         }

         set {
            gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype = value;
            SetDirty("Propostadocumentosanexofiletype");
         }

      }

      public void gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype_SetNull( )
      {
         gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype_N = 1;
         gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype = "";
         SetDirty("Propostadocumentosanexofiletype");
         return  ;
      }

      public bool gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype_IsNull( )
      {
         return (gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaDocumentosStatus" )]
      [  XmlElement( ElementName = "PropostaDocumentosStatus"   )]
      public string gxTpr_Propostadocumentosstatus
      {
         get {
            return gxTv_SdtPropostaDocumentos_Propostadocumentosstatus ;
         }

         set {
            gxTv_SdtPropostaDocumentos_Propostadocumentosstatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Propostadocumentosstatus = value;
            SetDirty("Propostadocumentosstatus");
         }

      }

      public void gxTv_SdtPropostaDocumentos_Propostadocumentosstatus_SetNull( )
      {
         gxTv_SdtPropostaDocumentos_Propostadocumentosstatus_N = 1;
         gxTv_SdtPropostaDocumentos_Propostadocumentosstatus = "";
         SetDirty("Propostadocumentosstatus");
         return  ;
      }

      public bool gxTv_SdtPropostaDocumentos_Propostadocumentosstatus_IsNull( )
      {
         return (gxTv_SdtPropostaDocumentos_Propostadocumentosstatus_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaDocumentosAdm" )]
      [  XmlElement( ElementName = "PropostaDocumentosAdm"   )]
      public bool gxTpr_Propostadocumentosadm
      {
         get {
            return gxTv_SdtPropostaDocumentos_Propostadocumentosadm ;
         }

         set {
            gxTv_SdtPropostaDocumentos_Propostadocumentosadm_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Propostadocumentosadm = value;
            SetDirty("Propostadocumentosadm");
         }

      }

      public void gxTv_SdtPropostaDocumentos_Propostadocumentosadm_SetNull( )
      {
         gxTv_SdtPropostaDocumentos_Propostadocumentosadm_N = 1;
         gxTv_SdtPropostaDocumentos_Propostadocumentosadm = false;
         SetDirty("Propostadocumentosadm");
         return  ;
      }

      public bool gxTv_SdtPropostaDocumentos_Propostadocumentosadm_IsNull( )
      {
         return (gxTv_SdtPropostaDocumentos_Propostadocumentosadm_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtPropostaDocumentos_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtPropostaDocumentos_Mode_SetNull( )
      {
         gxTv_SdtPropostaDocumentos_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtPropostaDocumentos_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtPropostaDocumentos_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtPropostaDocumentos_Initialized_SetNull( )
      {
         gxTv_SdtPropostaDocumentos_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtPropostaDocumentos_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaDocumentosId_Z" )]
      [  XmlElement( ElementName = "PropostaDocumentosId_Z"   )]
      public int gxTpr_Propostadocumentosid_Z
      {
         get {
            return gxTv_SdtPropostaDocumentos_Propostadocumentosid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Propostadocumentosid_Z = value;
            SetDirty("Propostadocumentosid_Z");
         }

      }

      public void gxTv_SdtPropostaDocumentos_Propostadocumentosid_Z_SetNull( )
      {
         gxTv_SdtPropostaDocumentos_Propostadocumentosid_Z = 0;
         SetDirty("Propostadocumentosid_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaDocumentos_Propostadocumentosid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaId_Z" )]
      [  XmlElement( ElementName = "PropostaId_Z"   )]
      public int gxTpr_Propostaid_Z
      {
         get {
            return gxTv_SdtPropostaDocumentos_Propostaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Propostaid_Z = value;
            SetDirty("Propostaid_Z");
         }

      }

      public void gxTv_SdtPropostaDocumentos_Propostaid_Z_SetNull( )
      {
         gxTv_SdtPropostaDocumentos_Propostaid_Z = 0;
         SetDirty("Propostaid_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaDocumentos_Propostaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentosId_Z" )]
      [  XmlElement( ElementName = "DocumentosId_Z"   )]
      public int gxTpr_Documentosid_Z
      {
         get {
            return gxTv_SdtPropostaDocumentos_Documentosid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Documentosid_Z = value;
            SetDirty("Documentosid_Z");
         }

      }

      public void gxTv_SdtPropostaDocumentos_Documentosid_Z_SetNull( )
      {
         gxTv_SdtPropostaDocumentos_Documentosid_Z = 0;
         SetDirty("Documentosid_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaDocumentos_Documentosid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentosDescricao_Z" )]
      [  XmlElement( ElementName = "DocumentosDescricao_Z"   )]
      public string gxTpr_Documentosdescricao_Z
      {
         get {
            return gxTv_SdtPropostaDocumentos_Documentosdescricao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Documentosdescricao_Z = value;
            SetDirty("Documentosdescricao_Z");
         }

      }

      public void gxTv_SdtPropostaDocumentos_Documentosdescricao_Z_SetNull( )
      {
         gxTv_SdtPropostaDocumentos_Documentosdescricao_Z = "";
         SetDirty("Documentosdescricao_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaDocumentos_Documentosdescricao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentosStatus_Z" )]
      [  XmlElement( ElementName = "DocumentosStatus_Z"   )]
      public bool gxTpr_Documentosstatus_Z
      {
         get {
            return gxTv_SdtPropostaDocumentos_Documentosstatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Documentosstatus_Z = value;
            SetDirty("Documentosstatus_Z");
         }

      }

      public void gxTv_SdtPropostaDocumentos_Documentosstatus_Z_SetNull( )
      {
         gxTv_SdtPropostaDocumentos_Documentosstatus_Z = false;
         SetDirty("Documentosstatus_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaDocumentos_Documentosstatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaDocumentosAnexoName_Z" )]
      [  XmlElement( ElementName = "PropostaDocumentosAnexoName_Z"   )]
      public string gxTpr_Propostadocumentosanexoname_Z
      {
         get {
            return gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname_Z = value;
            SetDirty("Propostadocumentosanexoname_Z");
         }

      }

      public void gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname_Z_SetNull( )
      {
         gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname_Z = "";
         SetDirty("Propostadocumentosanexoname_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaDocumentosAnexoFileType_Z" )]
      [  XmlElement( ElementName = "PropostaDocumentosAnexoFileType_Z"   )]
      public string gxTpr_Propostadocumentosanexofiletype_Z
      {
         get {
            return gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype_Z = value;
            SetDirty("Propostadocumentosanexofiletype_Z");
         }

      }

      public void gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype_Z_SetNull( )
      {
         gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype_Z = "";
         SetDirty("Propostadocumentosanexofiletype_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaDocumentosStatus_Z" )]
      [  XmlElement( ElementName = "PropostaDocumentosStatus_Z"   )]
      public string gxTpr_Propostadocumentosstatus_Z
      {
         get {
            return gxTv_SdtPropostaDocumentos_Propostadocumentosstatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Propostadocumentosstatus_Z = value;
            SetDirty("Propostadocumentosstatus_Z");
         }

      }

      public void gxTv_SdtPropostaDocumentos_Propostadocumentosstatus_Z_SetNull( )
      {
         gxTv_SdtPropostaDocumentos_Propostadocumentosstatus_Z = "";
         SetDirty("Propostadocumentosstatus_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaDocumentos_Propostadocumentosstatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaDocumentosAdm_Z" )]
      [  XmlElement( ElementName = "PropostaDocumentosAdm_Z"   )]
      public bool gxTpr_Propostadocumentosadm_Z
      {
         get {
            return gxTv_SdtPropostaDocumentos_Propostadocumentosadm_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Propostadocumentosadm_Z = value;
            SetDirty("Propostadocumentosadm_Z");
         }

      }

      public void gxTv_SdtPropostaDocumentos_Propostadocumentosadm_Z_SetNull( )
      {
         gxTv_SdtPropostaDocumentos_Propostadocumentosadm_Z = false;
         SetDirty("Propostadocumentosadm_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaDocumentos_Propostadocumentosadm_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaId_N" )]
      [  XmlElement( ElementName = "PropostaId_N"   )]
      public short gxTpr_Propostaid_N
      {
         get {
            return gxTv_SdtPropostaDocumentos_Propostaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Propostaid_N = value;
            SetDirty("Propostaid_N");
         }

      }

      public void gxTv_SdtPropostaDocumentos_Propostaid_N_SetNull( )
      {
         gxTv_SdtPropostaDocumentos_Propostaid_N = 0;
         SetDirty("Propostaid_N");
         return  ;
      }

      public bool gxTv_SdtPropostaDocumentos_Propostaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentosId_N" )]
      [  XmlElement( ElementName = "DocumentosId_N"   )]
      public short gxTpr_Documentosid_N
      {
         get {
            return gxTv_SdtPropostaDocumentos_Documentosid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Documentosid_N = value;
            SetDirty("Documentosid_N");
         }

      }

      public void gxTv_SdtPropostaDocumentos_Documentosid_N_SetNull( )
      {
         gxTv_SdtPropostaDocumentos_Documentosid_N = 0;
         SetDirty("Documentosid_N");
         return  ;
      }

      public bool gxTv_SdtPropostaDocumentos_Documentosid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentosDescricao_N" )]
      [  XmlElement( ElementName = "DocumentosDescricao_N"   )]
      public short gxTpr_Documentosdescricao_N
      {
         get {
            return gxTv_SdtPropostaDocumentos_Documentosdescricao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Documentosdescricao_N = value;
            SetDirty("Documentosdescricao_N");
         }

      }

      public void gxTv_SdtPropostaDocumentos_Documentosdescricao_N_SetNull( )
      {
         gxTv_SdtPropostaDocumentos_Documentosdescricao_N = 0;
         SetDirty("Documentosdescricao_N");
         return  ;
      }

      public bool gxTv_SdtPropostaDocumentos_Documentosdescricao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentosStatus_N" )]
      [  XmlElement( ElementName = "DocumentosStatus_N"   )]
      public short gxTpr_Documentosstatus_N
      {
         get {
            return gxTv_SdtPropostaDocumentos_Documentosstatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Documentosstatus_N = value;
            SetDirty("Documentosstatus_N");
         }

      }

      public void gxTv_SdtPropostaDocumentos_Documentosstatus_N_SetNull( )
      {
         gxTv_SdtPropostaDocumentos_Documentosstatus_N = 0;
         SetDirty("Documentosstatus_N");
         return  ;
      }

      public bool gxTv_SdtPropostaDocumentos_Documentosstatus_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaDocumentosAnexo_N" )]
      [  XmlElement( ElementName = "PropostaDocumentosAnexo_N"   )]
      public short gxTpr_Propostadocumentosanexo_N
      {
         get {
            return gxTv_SdtPropostaDocumentos_Propostadocumentosanexo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Propostadocumentosanexo_N = value;
            SetDirty("Propostadocumentosanexo_N");
         }

      }

      public void gxTv_SdtPropostaDocumentos_Propostadocumentosanexo_N_SetNull( )
      {
         gxTv_SdtPropostaDocumentos_Propostadocumentosanexo_N = 0;
         SetDirty("Propostadocumentosanexo_N");
         return  ;
      }

      public bool gxTv_SdtPropostaDocumentos_Propostadocumentosanexo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaDocumentosAnexoName_N" )]
      [  XmlElement( ElementName = "PropostaDocumentosAnexoName_N"   )]
      public short gxTpr_Propostadocumentosanexoname_N
      {
         get {
            return gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname_N = value;
            SetDirty("Propostadocumentosanexoname_N");
         }

      }

      public void gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname_N_SetNull( )
      {
         gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname_N = 0;
         SetDirty("Propostadocumentosanexoname_N");
         return  ;
      }

      public bool gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaDocumentosAnexoFileType_N" )]
      [  XmlElement( ElementName = "PropostaDocumentosAnexoFileType_N"   )]
      public short gxTpr_Propostadocumentosanexofiletype_N
      {
         get {
            return gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype_N = value;
            SetDirty("Propostadocumentosanexofiletype_N");
         }

      }

      public void gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype_N_SetNull( )
      {
         gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype_N = 0;
         SetDirty("Propostadocumentosanexofiletype_N");
         return  ;
      }

      public bool gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaDocumentosStatus_N" )]
      [  XmlElement( ElementName = "PropostaDocumentosStatus_N"   )]
      public short gxTpr_Propostadocumentosstatus_N
      {
         get {
            return gxTv_SdtPropostaDocumentos_Propostadocumentosstatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Propostadocumentosstatus_N = value;
            SetDirty("Propostadocumentosstatus_N");
         }

      }

      public void gxTv_SdtPropostaDocumentos_Propostadocumentosstatus_N_SetNull( )
      {
         gxTv_SdtPropostaDocumentos_Propostadocumentosstatus_N = 0;
         SetDirty("Propostadocumentosstatus_N");
         return  ;
      }

      public bool gxTv_SdtPropostaDocumentos_Propostadocumentosstatus_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaDocumentosAdm_N" )]
      [  XmlElement( ElementName = "PropostaDocumentosAdm_N"   )]
      public short gxTpr_Propostadocumentosadm_N
      {
         get {
            return gxTv_SdtPropostaDocumentos_Propostadocumentosadm_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaDocumentos_Propostadocumentosadm_N = value;
            SetDirty("Propostadocumentosadm_N");
         }

      }

      public void gxTv_SdtPropostaDocumentos_Propostadocumentosadm_N_SetNull( )
      {
         gxTv_SdtPropostaDocumentos_Propostadocumentosadm_N = 0;
         SetDirty("Propostadocumentosadm_N");
         return  ;
      }

      public bool gxTv_SdtPropostaDocumentos_Propostadocumentosadm_N_IsNull( )
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
         gxTv_SdtPropostaDocumentos_Documentosdescricao = "";
         gxTv_SdtPropostaDocumentos_Propostadocumentosanexo = "";
         gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname = "";
         gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype = "";
         gxTv_SdtPropostaDocumentos_Propostadocumentosstatus = "";
         gxTv_SdtPropostaDocumentos_Mode = "";
         gxTv_SdtPropostaDocumentos_Documentosdescricao_Z = "";
         gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname_Z = "";
         gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype_Z = "";
         gxTv_SdtPropostaDocumentos_Propostadocumentosstatus_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "propostadocumentos", "GeneXus.Programs.propostadocumentos_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtPropostaDocumentos_Initialized ;
      private short gxTv_SdtPropostaDocumentos_Propostaid_N ;
      private short gxTv_SdtPropostaDocumentos_Documentosid_N ;
      private short gxTv_SdtPropostaDocumentos_Documentosdescricao_N ;
      private short gxTv_SdtPropostaDocumentos_Documentosstatus_N ;
      private short gxTv_SdtPropostaDocumentos_Propostadocumentosanexo_N ;
      private short gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname_N ;
      private short gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype_N ;
      private short gxTv_SdtPropostaDocumentos_Propostadocumentosstatus_N ;
      private short gxTv_SdtPropostaDocumentos_Propostadocumentosadm_N ;
      private int gxTv_SdtPropostaDocumentos_Propostadocumentosid ;
      private int gxTv_SdtPropostaDocumentos_Propostaid ;
      private int gxTv_SdtPropostaDocumentos_Documentosid ;
      private int gxTv_SdtPropostaDocumentos_Propostadocumentosid_Z ;
      private int gxTv_SdtPropostaDocumentos_Propostaid_Z ;
      private int gxTv_SdtPropostaDocumentos_Documentosid_Z ;
      private string gxTv_SdtPropostaDocumentos_Mode ;
      private bool gxTv_SdtPropostaDocumentos_Documentosstatus ;
      private bool gxTv_SdtPropostaDocumentos_Propostadocumentosadm ;
      private bool gxTv_SdtPropostaDocumentos_Documentosstatus_Z ;
      private bool gxTv_SdtPropostaDocumentos_Propostadocumentosadm_Z ;
      private string gxTv_SdtPropostaDocumentos_Documentosdescricao ;
      private string gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname ;
      private string gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype ;
      private string gxTv_SdtPropostaDocumentos_Propostadocumentosstatus ;
      private string gxTv_SdtPropostaDocumentos_Documentosdescricao_Z ;
      private string gxTv_SdtPropostaDocumentos_Propostadocumentosanexoname_Z ;
      private string gxTv_SdtPropostaDocumentos_Propostadocumentosanexofiletype_Z ;
      private string gxTv_SdtPropostaDocumentos_Propostadocumentosstatus_Z ;
      private string gxTv_SdtPropostaDocumentos_Propostadocumentosanexo ;
   }

   [DataContract(Name = @"PropostaDocumentos", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtPropostaDocumentos_RESTInterface : GxGenericCollectionItem<SdtPropostaDocumentos>
   {
      public SdtPropostaDocumentos_RESTInterface( ) : base()
      {
      }

      public SdtPropostaDocumentos_RESTInterface( SdtPropostaDocumentos psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PropostaDocumentosId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Propostadocumentosid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Propostadocumentosid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Propostadocumentosid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "PropostaId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Propostaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Propostaid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Propostaid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "DocumentosId" , Order = 2 )]
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

      [DataMember( Name = "DocumentosDescricao" , Order = 3 )]
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

      [DataMember( Name = "DocumentosStatus" , Order = 4 )]
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

      [DataMember( Name = "PropostaDocumentosAnexo" , Order = 5 )]
      [GxUpload()]
      public string gxTpr_Propostadocumentosanexo
      {
         get {
            return PathUtil.RelativeURL( sdt.gxTpr_Propostadocumentosanexo) ;
         }

         set {
            sdt.gxTpr_Propostadocumentosanexo = value;
         }

      }

      [DataMember( Name = "PropostaDocumentosAnexoName" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Propostadocumentosanexoname
      {
         get {
            return sdt.gxTpr_Propostadocumentosanexoname ;
         }

         set {
            sdt.gxTpr_Propostadocumentosanexoname = value;
         }

      }

      [DataMember( Name = "PropostaDocumentosAnexoFileType" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Propostadocumentosanexofiletype
      {
         get {
            return sdt.gxTpr_Propostadocumentosanexofiletype ;
         }

         set {
            sdt.gxTpr_Propostadocumentosanexofiletype = value;
         }

      }

      [DataMember( Name = "PropostaDocumentosStatus" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Propostadocumentosstatus
      {
         get {
            return sdt.gxTpr_Propostadocumentosstatus ;
         }

         set {
            sdt.gxTpr_Propostadocumentosstatus = value;
         }

      }

      [DataMember( Name = "PropostaDocumentosAdm" , Order = 9 )]
      [GxSeudo()]
      public bool gxTpr_Propostadocumentosadm
      {
         get {
            return sdt.gxTpr_Propostadocumentosadm ;
         }

         set {
            sdt.gxTpr_Propostadocumentosadm = value;
         }

      }

      public SdtPropostaDocumentos sdt
      {
         get {
            return (SdtPropostaDocumentos)Sdt ;
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
            sdt = new SdtPropostaDocumentos() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 10 )]
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

   [DataContract(Name = @"PropostaDocumentos", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtPropostaDocumentos_RESTLInterface : GxGenericCollectionItem<SdtPropostaDocumentos>
   {
      public SdtPropostaDocumentos_RESTLInterface( ) : base()
      {
      }

      public SdtPropostaDocumentos_RESTLInterface( SdtPropostaDocumentos psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PropostaDocumentosAnexoName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Propostadocumentosanexoname
      {
         get {
            return sdt.gxTpr_Propostadocumentosanexoname ;
         }

         set {
            sdt.gxTpr_Propostadocumentosanexoname = value;
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

      public SdtPropostaDocumentos sdt
      {
         get {
            return (SdtPropostaDocumentos)Sdt ;
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
            sdt = new SdtPropostaDocumentos() ;
         }
      }

   }

}
