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
   [XmlRoot(ElementName = "ReembolsoDocumento" )]
   [XmlType(TypeName =  "ReembolsoDocumento" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtReembolsoDocumento : GxSilentTrnSdt
   {
      public SdtReembolsoDocumento( )
      {
      }

      public SdtReembolsoDocumento( IGxContext context )
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

      public void Load( int AV529ReembolsoDocumentoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV529ReembolsoDocumentoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ReembolsoDocumentoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "ReembolsoDocumento");
         metadata.Set("BT", "ReembolsoDocumento");
         metadata.Set("PK", "[ \"ReembolsoDocumentoId\" ]");
         metadata.Set("PKAssigned", "[ \"ReembolsoDocumentoId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"DocumentosId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ReembolsoEtapaId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Reembolsodocumentoid_Z");
         state.Add("gxTpr_Reembolsoetapaid_Z");
         state.Add("gxTpr_Reembolsodocumentonome_Z");
         state.Add("gxTpr_Reembolsodocumentoblobext_Z");
         state.Add("gxTpr_Reembolsodocumentocreatedat_Z_Nullable");
         state.Add("gxTpr_Documentosid_Z");
         state.Add("gxTpr_Reembolsodocumentostatus_Z");
         state.Add("gxTpr_Reembolsoetapaid_N");
         state.Add("gxTpr_Reembolsodocumentonome_N");
         state.Add("gxTpr_Reembolsodocumentoblob_N");
         state.Add("gxTpr_Reembolsodocumentoblobext_N");
         state.Add("gxTpr_Reembolsodocumentocreatedat_N");
         state.Add("gxTpr_Documentosid_N");
         state.Add("gxTpr_Reembolsodocumentostatus_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtReembolsoDocumento sdt;
         sdt = (SdtReembolsoDocumento)(source);
         gxTv_SdtReembolsoDocumento_Reembolsodocumentoid = sdt.gxTv_SdtReembolsoDocumento_Reembolsodocumentoid ;
         gxTv_SdtReembolsoDocumento_Reembolsoetapaid = sdt.gxTv_SdtReembolsoDocumento_Reembolsoetapaid ;
         gxTv_SdtReembolsoDocumento_Reembolsodocumentonome = sdt.gxTv_SdtReembolsoDocumento_Reembolsodocumentonome ;
         gxTv_SdtReembolsoDocumento_Reembolsodocumentoblob = sdt.gxTv_SdtReembolsoDocumento_Reembolsodocumentoblob ;
         gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext = sdt.gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext ;
         gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat = sdt.gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat ;
         gxTv_SdtReembolsoDocumento_Documentosid = sdt.gxTv_SdtReembolsoDocumento_Documentosid ;
         gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus = sdt.gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus ;
         gxTv_SdtReembolsoDocumento_Mode = sdt.gxTv_SdtReembolsoDocumento_Mode ;
         gxTv_SdtReembolsoDocumento_Initialized = sdt.gxTv_SdtReembolsoDocumento_Initialized ;
         gxTv_SdtReembolsoDocumento_Reembolsodocumentoid_Z = sdt.gxTv_SdtReembolsoDocumento_Reembolsodocumentoid_Z ;
         gxTv_SdtReembolsoDocumento_Reembolsoetapaid_Z = sdt.gxTv_SdtReembolsoDocumento_Reembolsoetapaid_Z ;
         gxTv_SdtReembolsoDocumento_Reembolsodocumentonome_Z = sdt.gxTv_SdtReembolsoDocumento_Reembolsodocumentonome_Z ;
         gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext_Z = sdt.gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext_Z ;
         gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat_Z = sdt.gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat_Z ;
         gxTv_SdtReembolsoDocumento_Documentosid_Z = sdt.gxTv_SdtReembolsoDocumento_Documentosid_Z ;
         gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus_Z = sdt.gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus_Z ;
         gxTv_SdtReembolsoDocumento_Reembolsoetapaid_N = sdt.gxTv_SdtReembolsoDocumento_Reembolsoetapaid_N ;
         gxTv_SdtReembolsoDocumento_Reembolsodocumentonome_N = sdt.gxTv_SdtReembolsoDocumento_Reembolsodocumentonome_N ;
         gxTv_SdtReembolsoDocumento_Reembolsodocumentoblob_N = sdt.gxTv_SdtReembolsoDocumento_Reembolsodocumentoblob_N ;
         gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext_N = sdt.gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext_N ;
         gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat_N = sdt.gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat_N ;
         gxTv_SdtReembolsoDocumento_Documentosid_N = sdt.gxTv_SdtReembolsoDocumento_Documentosid_N ;
         gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus_N = sdt.gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus_N ;
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
         AddObjectProperty("ReembolsoDocumentoId", gxTv_SdtReembolsoDocumento_Reembolsodocumentoid, false, includeNonInitialized);
         AddObjectProperty("ReembolsoEtapaId", gxTv_SdtReembolsoDocumento_Reembolsoetapaid, false, includeNonInitialized);
         AddObjectProperty("ReembolsoEtapaId_N", gxTv_SdtReembolsoDocumento_Reembolsoetapaid_N, false, includeNonInitialized);
         AddObjectProperty("ReembolsoDocumentoNome", gxTv_SdtReembolsoDocumento_Reembolsodocumentonome, false, includeNonInitialized);
         AddObjectProperty("ReembolsoDocumentoNome_N", gxTv_SdtReembolsoDocumento_Reembolsodocumentonome_N, false, includeNonInitialized);
         AddObjectProperty("ReembolsoDocumentoBlob", gxTv_SdtReembolsoDocumento_Reembolsodocumentoblob, false, includeNonInitialized);
         AddObjectProperty("ReembolsoDocumentoBlob_N", gxTv_SdtReembolsoDocumento_Reembolsodocumentoblob_N, false, includeNonInitialized);
         AddObjectProperty("ReembolsoDocumentoBlobExt", gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext, false, includeNonInitialized);
         AddObjectProperty("ReembolsoDocumentoBlobExt_N", gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat;
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
         AddObjectProperty("ReembolsoDocumentoCreatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ReembolsoDocumentoCreatedAt_N", gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat_N, false, includeNonInitialized);
         AddObjectProperty("DocumentosId", gxTv_SdtReembolsoDocumento_Documentosid, false, includeNonInitialized);
         AddObjectProperty("DocumentosId_N", gxTv_SdtReembolsoDocumento_Documentosid_N, false, includeNonInitialized);
         AddObjectProperty("ReembolsoDocumentoStatus", gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus, false, includeNonInitialized);
         AddObjectProperty("ReembolsoDocumentoStatus_N", gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtReembolsoDocumento_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtReembolsoDocumento_Initialized, false, includeNonInitialized);
            AddObjectProperty("ReembolsoDocumentoId_Z", gxTv_SdtReembolsoDocumento_Reembolsodocumentoid_Z, false, includeNonInitialized);
            AddObjectProperty("ReembolsoEtapaId_Z", gxTv_SdtReembolsoDocumento_Reembolsoetapaid_Z, false, includeNonInitialized);
            AddObjectProperty("ReembolsoDocumentoNome_Z", gxTv_SdtReembolsoDocumento_Reembolsodocumentonome_Z, false, includeNonInitialized);
            AddObjectProperty("ReembolsoDocumentoBlobExt_Z", gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat_Z;
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
            AddObjectProperty("ReembolsoDocumentoCreatedAt_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("DocumentosId_Z", gxTv_SdtReembolsoDocumento_Documentosid_Z, false, includeNonInitialized);
            AddObjectProperty("ReembolsoDocumentoStatus_Z", gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus_Z, false, includeNonInitialized);
            AddObjectProperty("ReembolsoEtapaId_N", gxTv_SdtReembolsoDocumento_Reembolsoetapaid_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoDocumentoNome_N", gxTv_SdtReembolsoDocumento_Reembolsodocumentonome_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoDocumentoBlob_N", gxTv_SdtReembolsoDocumento_Reembolsodocumentoblob_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoDocumentoBlobExt_N", gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoDocumentoCreatedAt_N", gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat_N, false, includeNonInitialized);
            AddObjectProperty("DocumentosId_N", gxTv_SdtReembolsoDocumento_Documentosid_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoDocumentoStatus_N", gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtReembolsoDocumento sdt )
      {
         if ( sdt.IsDirty("ReembolsoDocumentoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtReembolsoDocumento_Reembolsodocumentoid = sdt.gxTv_SdtReembolsoDocumento_Reembolsodocumentoid ;
         }
         if ( sdt.IsDirty("ReembolsoEtapaId") )
         {
            gxTv_SdtReembolsoDocumento_Reembolsoetapaid_N = (short)(sdt.gxTv_SdtReembolsoDocumento_Reembolsoetapaid_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoDocumento_Reembolsoetapaid = sdt.gxTv_SdtReembolsoDocumento_Reembolsoetapaid ;
         }
         if ( sdt.IsDirty("ReembolsoDocumentoNome") )
         {
            gxTv_SdtReembolsoDocumento_Reembolsodocumentonome_N = (short)(sdt.gxTv_SdtReembolsoDocumento_Reembolsodocumentonome_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoDocumento_Reembolsodocumentonome = sdt.gxTv_SdtReembolsoDocumento_Reembolsodocumentonome ;
         }
         if ( sdt.IsDirty("ReembolsoDocumentoBlob") )
         {
            gxTv_SdtReembolsoDocumento_Reembolsodocumentoblob_N = (short)(sdt.gxTv_SdtReembolsoDocumento_Reembolsodocumentoblob_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoDocumento_Reembolsodocumentoblob = sdt.gxTv_SdtReembolsoDocumento_Reembolsodocumentoblob ;
         }
         if ( sdt.IsDirty("ReembolsoDocumentoBlobExt") )
         {
            gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext_N = (short)(sdt.gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext = sdt.gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext ;
         }
         if ( sdt.IsDirty("ReembolsoDocumentoCreatedAt") )
         {
            gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat_N = (short)(sdt.gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat = sdt.gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat ;
         }
         if ( sdt.IsDirty("DocumentosId") )
         {
            gxTv_SdtReembolsoDocumento_Documentosid_N = (short)(sdt.gxTv_SdtReembolsoDocumento_Documentosid_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoDocumento_Documentosid = sdt.gxTv_SdtReembolsoDocumento_Documentosid ;
         }
         if ( sdt.IsDirty("ReembolsoDocumentoStatus") )
         {
            gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus_N = (short)(sdt.gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus = sdt.gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ReembolsoDocumentoId" )]
      [  XmlElement( ElementName = "ReembolsoDocumentoId"   )]
      public int gxTpr_Reembolsodocumentoid
      {
         get {
            return gxTv_SdtReembolsoDocumento_Reembolsodocumentoid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtReembolsoDocumento_Reembolsodocumentoid != value )
            {
               gxTv_SdtReembolsoDocumento_Mode = "INS";
               this.gxTv_SdtReembolsoDocumento_Reembolsodocumentoid_Z_SetNull( );
               this.gxTv_SdtReembolsoDocumento_Reembolsoetapaid_Z_SetNull( );
               this.gxTv_SdtReembolsoDocumento_Reembolsodocumentonome_Z_SetNull( );
               this.gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext_Z_SetNull( );
               this.gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat_Z_SetNull( );
               this.gxTv_SdtReembolsoDocumento_Documentosid_Z_SetNull( );
               this.gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus_Z_SetNull( );
            }
            gxTv_SdtReembolsoDocumento_Reembolsodocumentoid = value;
            SetDirty("Reembolsodocumentoid");
         }

      }

      [  SoapElement( ElementName = "ReembolsoEtapaId" )]
      [  XmlElement( ElementName = "ReembolsoEtapaId"   )]
      public int gxTpr_Reembolsoetapaid
      {
         get {
            return gxTv_SdtReembolsoDocumento_Reembolsoetapaid ;
         }

         set {
            gxTv_SdtReembolsoDocumento_Reembolsoetapaid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoDocumento_Reembolsoetapaid = value;
            SetDirty("Reembolsoetapaid");
         }

      }

      public void gxTv_SdtReembolsoDocumento_Reembolsoetapaid_SetNull( )
      {
         gxTv_SdtReembolsoDocumento_Reembolsoetapaid_N = 1;
         gxTv_SdtReembolsoDocumento_Reembolsoetapaid = 0;
         SetDirty("Reembolsoetapaid");
         return  ;
      }

      public bool gxTv_SdtReembolsoDocumento_Reembolsoetapaid_IsNull( )
      {
         return (gxTv_SdtReembolsoDocumento_Reembolsoetapaid_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoDocumentoNome" )]
      [  XmlElement( ElementName = "ReembolsoDocumentoNome"   )]
      public string gxTpr_Reembolsodocumentonome
      {
         get {
            return gxTv_SdtReembolsoDocumento_Reembolsodocumentonome ;
         }

         set {
            gxTv_SdtReembolsoDocumento_Reembolsodocumentonome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoDocumento_Reembolsodocumentonome = value;
            SetDirty("Reembolsodocumentonome");
         }

      }

      public void gxTv_SdtReembolsoDocumento_Reembolsodocumentonome_SetNull( )
      {
         gxTv_SdtReembolsoDocumento_Reembolsodocumentonome_N = 1;
         gxTv_SdtReembolsoDocumento_Reembolsodocumentonome = "";
         SetDirty("Reembolsodocumentonome");
         return  ;
      }

      public bool gxTv_SdtReembolsoDocumento_Reembolsodocumentonome_IsNull( )
      {
         return (gxTv_SdtReembolsoDocumento_Reembolsodocumentonome_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoDocumentoBlob" )]
      [  XmlElement( ElementName = "ReembolsoDocumentoBlob"   )]
      [GxUpload()]
      public byte[] gxTpr_Reembolsodocumentoblob_Blob
      {
         get {
            IGxContext context = this.context == null ? new GxContext() : this.context;
            return context.FileToByteArray( gxTv_SdtReembolsoDocumento_Reembolsodocumentoblob) ;
         }

         set {
            gxTv_SdtReembolsoDocumento_Reembolsodocumentoblob_N = 0;
            sdtIsNull = 0;
            IGxContext context = this.context == null ? new GxContext() : this.context;
            gxTv_SdtReembolsoDocumento_Reembolsodocumentoblob=context.FileFromByteArray( value) ;
         }

      }

      [XmlIgnore]
      [GxUpload()]
      public string gxTpr_Reembolsodocumentoblob
      {
         get {
            return gxTv_SdtReembolsoDocumento_Reembolsodocumentoblob ;
         }

         set {
            gxTv_SdtReembolsoDocumento_Reembolsodocumentoblob_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoDocumento_Reembolsodocumentoblob = value;
            SetDirty("Reembolsodocumentoblob");
         }

      }

      public void gxTv_SdtReembolsoDocumento_Reembolsodocumentoblob_SetBlob( string blob ,
                                                                             string fileName ,
                                                                             string fileType )
      {
         gxTv_SdtReembolsoDocumento_Reembolsodocumentoblob = blob;
         return  ;
      }

      public void gxTv_SdtReembolsoDocumento_Reembolsodocumentoblob_SetNull( )
      {
         gxTv_SdtReembolsoDocumento_Reembolsodocumentoblob_N = 1;
         gxTv_SdtReembolsoDocumento_Reembolsodocumentoblob = "";
         SetDirty("Reembolsodocumentoblob");
         return  ;
      }

      public bool gxTv_SdtReembolsoDocumento_Reembolsodocumentoblob_IsNull( )
      {
         return (gxTv_SdtReembolsoDocumento_Reembolsodocumentoblob_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoDocumentoBlobExt" )]
      [  XmlElement( ElementName = "ReembolsoDocumentoBlobExt"   )]
      public string gxTpr_Reembolsodocumentoblobext
      {
         get {
            return gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext ;
         }

         set {
            gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext = value;
            SetDirty("Reembolsodocumentoblobext");
         }

      }

      public void gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext_SetNull( )
      {
         gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext_N = 1;
         gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext = "";
         SetDirty("Reembolsodocumentoblobext");
         return  ;
      }

      public bool gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext_IsNull( )
      {
         return (gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoDocumentoCreatedAt" )]
      [  XmlElement( ElementName = "ReembolsoDocumentoCreatedAt"  , IsNullable=true )]
      public string gxTpr_Reembolsodocumentocreatedat_Nullable
      {
         get {
            if ( gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat).value ;
         }

         set {
            gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat = DateTime.MinValue;
            else
               gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Reembolsodocumentocreatedat
      {
         get {
            return gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat ;
         }

         set {
            gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat = value;
            SetDirty("Reembolsodocumentocreatedat");
         }

      }

      public void gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat_SetNull( )
      {
         gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat_N = 1;
         gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Reembolsodocumentocreatedat");
         return  ;
      }

      public bool gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat_IsNull( )
      {
         return (gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat_N==1) ;
      }

      [  SoapElement( ElementName = "DocumentosId" )]
      [  XmlElement( ElementName = "DocumentosId"   )]
      public int gxTpr_Documentosid
      {
         get {
            return gxTv_SdtReembolsoDocumento_Documentosid ;
         }

         set {
            gxTv_SdtReembolsoDocumento_Documentosid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoDocumento_Documentosid = value;
            SetDirty("Documentosid");
         }

      }

      public void gxTv_SdtReembolsoDocumento_Documentosid_SetNull( )
      {
         gxTv_SdtReembolsoDocumento_Documentosid_N = 1;
         gxTv_SdtReembolsoDocumento_Documentosid = 0;
         SetDirty("Documentosid");
         return  ;
      }

      public bool gxTv_SdtReembolsoDocumento_Documentosid_IsNull( )
      {
         return (gxTv_SdtReembolsoDocumento_Documentosid_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoDocumentoStatus" )]
      [  XmlElement( ElementName = "ReembolsoDocumentoStatus"   )]
      public string gxTpr_Reembolsodocumentostatus
      {
         get {
            return gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus ;
         }

         set {
            gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus = value;
            SetDirty("Reembolsodocumentostatus");
         }

      }

      public void gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus_SetNull( )
      {
         gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus_N = 1;
         gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus = "";
         SetDirty("Reembolsodocumentostatus");
         return  ;
      }

      public bool gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus_IsNull( )
      {
         return (gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtReembolsoDocumento_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoDocumento_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtReembolsoDocumento_Mode_SetNull( )
      {
         gxTv_SdtReembolsoDocumento_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtReembolsoDocumento_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtReembolsoDocumento_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoDocumento_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtReembolsoDocumento_Initialized_SetNull( )
      {
         gxTv_SdtReembolsoDocumento_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtReembolsoDocumento_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoDocumentoId_Z" )]
      [  XmlElement( ElementName = "ReembolsoDocumentoId_Z"   )]
      public int gxTpr_Reembolsodocumentoid_Z
      {
         get {
            return gxTv_SdtReembolsoDocumento_Reembolsodocumentoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoDocumento_Reembolsodocumentoid_Z = value;
            SetDirty("Reembolsodocumentoid_Z");
         }

      }

      public void gxTv_SdtReembolsoDocumento_Reembolsodocumentoid_Z_SetNull( )
      {
         gxTv_SdtReembolsoDocumento_Reembolsodocumentoid_Z = 0;
         SetDirty("Reembolsodocumentoid_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoDocumento_Reembolsodocumentoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoEtapaId_Z" )]
      [  XmlElement( ElementName = "ReembolsoEtapaId_Z"   )]
      public int gxTpr_Reembolsoetapaid_Z
      {
         get {
            return gxTv_SdtReembolsoDocumento_Reembolsoetapaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoDocumento_Reembolsoetapaid_Z = value;
            SetDirty("Reembolsoetapaid_Z");
         }

      }

      public void gxTv_SdtReembolsoDocumento_Reembolsoetapaid_Z_SetNull( )
      {
         gxTv_SdtReembolsoDocumento_Reembolsoetapaid_Z = 0;
         SetDirty("Reembolsoetapaid_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoDocumento_Reembolsoetapaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoDocumentoNome_Z" )]
      [  XmlElement( ElementName = "ReembolsoDocumentoNome_Z"   )]
      public string gxTpr_Reembolsodocumentonome_Z
      {
         get {
            return gxTv_SdtReembolsoDocumento_Reembolsodocumentonome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoDocumento_Reembolsodocumentonome_Z = value;
            SetDirty("Reembolsodocumentonome_Z");
         }

      }

      public void gxTv_SdtReembolsoDocumento_Reembolsodocumentonome_Z_SetNull( )
      {
         gxTv_SdtReembolsoDocumento_Reembolsodocumentonome_Z = "";
         SetDirty("Reembolsodocumentonome_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoDocumento_Reembolsodocumentonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoDocumentoBlobExt_Z" )]
      [  XmlElement( ElementName = "ReembolsoDocumentoBlobExt_Z"   )]
      public string gxTpr_Reembolsodocumentoblobext_Z
      {
         get {
            return gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext_Z = value;
            SetDirty("Reembolsodocumentoblobext_Z");
         }

      }

      public void gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext_Z_SetNull( )
      {
         gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext_Z = "";
         SetDirty("Reembolsodocumentoblobext_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoDocumentoCreatedAt_Z" )]
      [  XmlElement( ElementName = "ReembolsoDocumentoCreatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Reembolsodocumentocreatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Reembolsodocumentocreatedat_Z
      {
         get {
            return gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat_Z = value;
            SetDirty("Reembolsodocumentocreatedat_Z");
         }

      }

      public void gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat_Z_SetNull( )
      {
         gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Reembolsodocumentocreatedat_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentosId_Z" )]
      [  XmlElement( ElementName = "DocumentosId_Z"   )]
      public int gxTpr_Documentosid_Z
      {
         get {
            return gxTv_SdtReembolsoDocumento_Documentosid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoDocumento_Documentosid_Z = value;
            SetDirty("Documentosid_Z");
         }

      }

      public void gxTv_SdtReembolsoDocumento_Documentosid_Z_SetNull( )
      {
         gxTv_SdtReembolsoDocumento_Documentosid_Z = 0;
         SetDirty("Documentosid_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoDocumento_Documentosid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoDocumentoStatus_Z" )]
      [  XmlElement( ElementName = "ReembolsoDocumentoStatus_Z"   )]
      public string gxTpr_Reembolsodocumentostatus_Z
      {
         get {
            return gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus_Z = value;
            SetDirty("Reembolsodocumentostatus_Z");
         }

      }

      public void gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus_Z_SetNull( )
      {
         gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus_Z = "";
         SetDirty("Reembolsodocumentostatus_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoEtapaId_N" )]
      [  XmlElement( ElementName = "ReembolsoEtapaId_N"   )]
      public short gxTpr_Reembolsoetapaid_N
      {
         get {
            return gxTv_SdtReembolsoDocumento_Reembolsoetapaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoDocumento_Reembolsoetapaid_N = value;
            SetDirty("Reembolsoetapaid_N");
         }

      }

      public void gxTv_SdtReembolsoDocumento_Reembolsoetapaid_N_SetNull( )
      {
         gxTv_SdtReembolsoDocumento_Reembolsoetapaid_N = 0;
         SetDirty("Reembolsoetapaid_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoDocumento_Reembolsoetapaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoDocumentoNome_N" )]
      [  XmlElement( ElementName = "ReembolsoDocumentoNome_N"   )]
      public short gxTpr_Reembolsodocumentonome_N
      {
         get {
            return gxTv_SdtReembolsoDocumento_Reembolsodocumentonome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoDocumento_Reembolsodocumentonome_N = value;
            SetDirty("Reembolsodocumentonome_N");
         }

      }

      public void gxTv_SdtReembolsoDocumento_Reembolsodocumentonome_N_SetNull( )
      {
         gxTv_SdtReembolsoDocumento_Reembolsodocumentonome_N = 0;
         SetDirty("Reembolsodocumentonome_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoDocumento_Reembolsodocumentonome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoDocumentoBlob_N" )]
      [  XmlElement( ElementName = "ReembolsoDocumentoBlob_N"   )]
      public short gxTpr_Reembolsodocumentoblob_N
      {
         get {
            return gxTv_SdtReembolsoDocumento_Reembolsodocumentoblob_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoDocumento_Reembolsodocumentoblob_N = value;
            SetDirty("Reembolsodocumentoblob_N");
         }

      }

      public void gxTv_SdtReembolsoDocumento_Reembolsodocumentoblob_N_SetNull( )
      {
         gxTv_SdtReembolsoDocumento_Reembolsodocumentoblob_N = 0;
         SetDirty("Reembolsodocumentoblob_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoDocumento_Reembolsodocumentoblob_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoDocumentoBlobExt_N" )]
      [  XmlElement( ElementName = "ReembolsoDocumentoBlobExt_N"   )]
      public short gxTpr_Reembolsodocumentoblobext_N
      {
         get {
            return gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext_N = value;
            SetDirty("Reembolsodocumentoblobext_N");
         }

      }

      public void gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext_N_SetNull( )
      {
         gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext_N = 0;
         SetDirty("Reembolsodocumentoblobext_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoDocumentoCreatedAt_N" )]
      [  XmlElement( ElementName = "ReembolsoDocumentoCreatedAt_N"   )]
      public short gxTpr_Reembolsodocumentocreatedat_N
      {
         get {
            return gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat_N = value;
            SetDirty("Reembolsodocumentocreatedat_N");
         }

      }

      public void gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat_N_SetNull( )
      {
         gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat_N = 0;
         SetDirty("Reembolsodocumentocreatedat_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentosId_N" )]
      [  XmlElement( ElementName = "DocumentosId_N"   )]
      public short gxTpr_Documentosid_N
      {
         get {
            return gxTv_SdtReembolsoDocumento_Documentosid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoDocumento_Documentosid_N = value;
            SetDirty("Documentosid_N");
         }

      }

      public void gxTv_SdtReembolsoDocumento_Documentosid_N_SetNull( )
      {
         gxTv_SdtReembolsoDocumento_Documentosid_N = 0;
         SetDirty("Documentosid_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoDocumento_Documentosid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoDocumentoStatus_N" )]
      [  XmlElement( ElementName = "ReembolsoDocumentoStatus_N"   )]
      public short gxTpr_Reembolsodocumentostatus_N
      {
         get {
            return gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus_N = value;
            SetDirty("Reembolsodocumentostatus_N");
         }

      }

      public void gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus_N_SetNull( )
      {
         gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus_N = 0;
         SetDirty("Reembolsodocumentostatus_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus_N_IsNull( )
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
         gxTv_SdtReembolsoDocumento_Reembolsodocumentonome = "";
         gxTv_SdtReembolsoDocumento_Reembolsodocumentoblob = "";
         gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext = "";
         gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus = "";
         gxTv_SdtReembolsoDocumento_Mode = "";
         gxTv_SdtReembolsoDocumento_Reembolsodocumentonome_Z = "";
         gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext_Z = "";
         gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "reembolsodocumento", "GeneXus.Programs.reembolsodocumento_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtReembolsoDocumento_Initialized ;
      private short gxTv_SdtReembolsoDocumento_Reembolsoetapaid_N ;
      private short gxTv_SdtReembolsoDocumento_Reembolsodocumentonome_N ;
      private short gxTv_SdtReembolsoDocumento_Reembolsodocumentoblob_N ;
      private short gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext_N ;
      private short gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat_N ;
      private short gxTv_SdtReembolsoDocumento_Documentosid_N ;
      private short gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus_N ;
      private int gxTv_SdtReembolsoDocumento_Reembolsodocumentoid ;
      private int gxTv_SdtReembolsoDocumento_Reembolsoetapaid ;
      private int gxTv_SdtReembolsoDocumento_Documentosid ;
      private int gxTv_SdtReembolsoDocumento_Reembolsodocumentoid_Z ;
      private int gxTv_SdtReembolsoDocumento_Reembolsoetapaid_Z ;
      private int gxTv_SdtReembolsoDocumento_Documentosid_Z ;
      private string gxTv_SdtReembolsoDocumento_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat ;
      private DateTime gxTv_SdtReembolsoDocumento_Reembolsodocumentocreatedat_Z ;
      private DateTime datetime_STZ ;
      private string gxTv_SdtReembolsoDocumento_Reembolsodocumentonome ;
      private string gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext ;
      private string gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus ;
      private string gxTv_SdtReembolsoDocumento_Reembolsodocumentonome_Z ;
      private string gxTv_SdtReembolsoDocumento_Reembolsodocumentoblobext_Z ;
      private string gxTv_SdtReembolsoDocumento_Reembolsodocumentostatus_Z ;
      private string gxTv_SdtReembolsoDocumento_Reembolsodocumentoblob ;
   }

   [DataContract(Name = @"ReembolsoDocumento", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtReembolsoDocumento_RESTInterface : GxGenericCollectionItem<SdtReembolsoDocumento>
   {
      public SdtReembolsoDocumento_RESTInterface( ) : base()
      {
      }

      public SdtReembolsoDocumento_RESTInterface( SdtReembolsoDocumento psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ReembolsoDocumentoId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Reembolsodocumentoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Reembolsodocumentoid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Reembolsodocumentoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ReembolsoEtapaId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Reembolsoetapaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Reembolsoetapaid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Reembolsoetapaid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ReembolsoDocumentoNome" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Reembolsodocumentonome
      {
         get {
            return sdt.gxTpr_Reembolsodocumentonome ;
         }

         set {
            sdt.gxTpr_Reembolsodocumentonome = value;
         }

      }

      [DataMember( Name = "ReembolsoDocumentoBlob" , Order = 3 )]
      [GxUpload()]
      public string gxTpr_Reembolsodocumentoblob
      {
         get {
            return PathUtil.RelativeURL( sdt.gxTpr_Reembolsodocumentoblob) ;
         }

         set {
            sdt.gxTpr_Reembolsodocumentoblob = value;
         }

      }

      [DataMember( Name = "ReembolsoDocumentoBlobExt" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Reembolsodocumentoblobext
      {
         get {
            return sdt.gxTpr_Reembolsodocumentoblobext ;
         }

         set {
            sdt.gxTpr_Reembolsodocumentoblobext = value;
         }

      }

      [DataMember( Name = "ReembolsoDocumentoCreatedAt" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Reembolsodocumentocreatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Reembolsodocumentocreatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Reembolsodocumentocreatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "DocumentosId" , Order = 6 )]
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

      [DataMember( Name = "ReembolsoDocumentoStatus" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Reembolsodocumentostatus
      {
         get {
            return sdt.gxTpr_Reembolsodocumentostatus ;
         }

         set {
            sdt.gxTpr_Reembolsodocumentostatus = value;
         }

      }

      public SdtReembolsoDocumento sdt
      {
         get {
            return (SdtReembolsoDocumento)Sdt ;
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
            sdt = new SdtReembolsoDocumento() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 8 )]
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

   [DataContract(Name = @"ReembolsoDocumento", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtReembolsoDocumento_RESTLInterface : GxGenericCollectionItem<SdtReembolsoDocumento>
   {
      public SdtReembolsoDocumento_RESTLInterface( ) : base()
      {
      }

      public SdtReembolsoDocumento_RESTLInterface( SdtReembolsoDocumento psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ReembolsoDocumentoNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Reembolsodocumentonome
      {
         get {
            return sdt.gxTpr_Reembolsodocumentonome ;
         }

         set {
            sdt.gxTpr_Reembolsodocumentonome = value;
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

      public SdtReembolsoDocumento sdt
      {
         get {
            return (SdtReembolsoDocumento)Sdt ;
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
            sdt = new SdtReembolsoDocumento() ;
         }
      }

   }

}
