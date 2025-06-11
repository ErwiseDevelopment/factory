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
   [XmlRoot(ElementName = "ClienteDocumento" )]
   [XmlType(TypeName =  "ClienteDocumento" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtClienteDocumento : GxSilentTrnSdt
   {
      public SdtClienteDocumento( )
      {
      }

      public SdtClienteDocumento( IGxContext context )
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

      public void Load( int AV599ClienteDocumentoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV599ClienteDocumentoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ClienteDocumentoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "ClienteDocumento");
         metadata.Set("BT", "ClienteDocumento");
         metadata.Set("PK", "[ \"ClienteDocumentoId\" ]");
         metadata.Set("PKAssigned", "[ \"ClienteDocumentoId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ClienteId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"DocumentosId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"SecUserId\" ],\"FKMap\":[ \"ClienteDocumentoCreatedBy-SecUserId\" ] } ]");
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
         state.Add("gxTpr_Clientedocumentoid_Z");
         state.Add("gxTpr_Clienteid_Z");
         state.Add("gxTpr_Documentosid_Z");
         state.Add("gxTpr_Documentosdescricao_Z");
         state.Add("gxTpr_Clientedocumentonome_Z");
         state.Add("gxTpr_Clientedocumentoextensao_Z");
         state.Add("gxTpr_Clientedocumentocreatedat_Z_Nullable");
         state.Add("gxTpr_Clientedocumentocreatedby_Z");
         state.Add("gxTpr_Clientedocumentoupdatedat_Z_Nullable");
         state.Add("gxTpr_Clientenomedoarquivo_f_Z");
         state.Add("gxTpr_Clienteid_N");
         state.Add("gxTpr_Documentosid_N");
         state.Add("gxTpr_Documentosdescricao_N");
         state.Add("gxTpr_Clientedocumentoblob_N");
         state.Add("gxTpr_Clientedocumentonome_N");
         state.Add("gxTpr_Clientedocumentoextensao_N");
         state.Add("gxTpr_Clientedocumentocreatedat_N");
         state.Add("gxTpr_Clientedocumentocreatedby_N");
         state.Add("gxTpr_Clientedocumentoupdatedat_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtClienteDocumento sdt;
         sdt = (SdtClienteDocumento)(source);
         gxTv_SdtClienteDocumento_Clientedocumentoid = sdt.gxTv_SdtClienteDocumento_Clientedocumentoid ;
         gxTv_SdtClienteDocumento_Clienteid = sdt.gxTv_SdtClienteDocumento_Clienteid ;
         gxTv_SdtClienteDocumento_Documentosid = sdt.gxTv_SdtClienteDocumento_Documentosid ;
         gxTv_SdtClienteDocumento_Documentosdescricao = sdt.gxTv_SdtClienteDocumento_Documentosdescricao ;
         gxTv_SdtClienteDocumento_Clientedocumentoblob = sdt.gxTv_SdtClienteDocumento_Clientedocumentoblob ;
         gxTv_SdtClienteDocumento_Clientedocumentonome = sdt.gxTv_SdtClienteDocumento_Clientedocumentonome ;
         gxTv_SdtClienteDocumento_Clientedocumentoextensao = sdt.gxTv_SdtClienteDocumento_Clientedocumentoextensao ;
         gxTv_SdtClienteDocumento_Clientedocumentocreatedat = sdt.gxTv_SdtClienteDocumento_Clientedocumentocreatedat ;
         gxTv_SdtClienteDocumento_Clientedocumentocreatedby = sdt.gxTv_SdtClienteDocumento_Clientedocumentocreatedby ;
         gxTv_SdtClienteDocumento_Clientedocumentoupdatedat = sdt.gxTv_SdtClienteDocumento_Clientedocumentoupdatedat ;
         gxTv_SdtClienteDocumento_Clientenomedoarquivo_f = sdt.gxTv_SdtClienteDocumento_Clientenomedoarquivo_f ;
         gxTv_SdtClienteDocumento_Mode = sdt.gxTv_SdtClienteDocumento_Mode ;
         gxTv_SdtClienteDocumento_Initialized = sdt.gxTv_SdtClienteDocumento_Initialized ;
         gxTv_SdtClienteDocumento_Clientedocumentoid_Z = sdt.gxTv_SdtClienteDocumento_Clientedocumentoid_Z ;
         gxTv_SdtClienteDocumento_Clienteid_Z = sdt.gxTv_SdtClienteDocumento_Clienteid_Z ;
         gxTv_SdtClienteDocumento_Documentosid_Z = sdt.gxTv_SdtClienteDocumento_Documentosid_Z ;
         gxTv_SdtClienteDocumento_Documentosdescricao_Z = sdt.gxTv_SdtClienteDocumento_Documentosdescricao_Z ;
         gxTv_SdtClienteDocumento_Clientedocumentonome_Z = sdt.gxTv_SdtClienteDocumento_Clientedocumentonome_Z ;
         gxTv_SdtClienteDocumento_Clientedocumentoextensao_Z = sdt.gxTv_SdtClienteDocumento_Clientedocumentoextensao_Z ;
         gxTv_SdtClienteDocumento_Clientedocumentocreatedat_Z = sdt.gxTv_SdtClienteDocumento_Clientedocumentocreatedat_Z ;
         gxTv_SdtClienteDocumento_Clientedocumentocreatedby_Z = sdt.gxTv_SdtClienteDocumento_Clientedocumentocreatedby_Z ;
         gxTv_SdtClienteDocumento_Clientedocumentoupdatedat_Z = sdt.gxTv_SdtClienteDocumento_Clientedocumentoupdatedat_Z ;
         gxTv_SdtClienteDocumento_Clientenomedoarquivo_f_Z = sdt.gxTv_SdtClienteDocumento_Clientenomedoarquivo_f_Z ;
         gxTv_SdtClienteDocumento_Clienteid_N = sdt.gxTv_SdtClienteDocumento_Clienteid_N ;
         gxTv_SdtClienteDocumento_Documentosid_N = sdt.gxTv_SdtClienteDocumento_Documentosid_N ;
         gxTv_SdtClienteDocumento_Documentosdescricao_N = sdt.gxTv_SdtClienteDocumento_Documentosdescricao_N ;
         gxTv_SdtClienteDocumento_Clientedocumentoblob_N = sdt.gxTv_SdtClienteDocumento_Clientedocumentoblob_N ;
         gxTv_SdtClienteDocumento_Clientedocumentonome_N = sdt.gxTv_SdtClienteDocumento_Clientedocumentonome_N ;
         gxTv_SdtClienteDocumento_Clientedocumentoextensao_N = sdt.gxTv_SdtClienteDocumento_Clientedocumentoextensao_N ;
         gxTv_SdtClienteDocumento_Clientedocumentocreatedat_N = sdt.gxTv_SdtClienteDocumento_Clientedocumentocreatedat_N ;
         gxTv_SdtClienteDocumento_Clientedocumentocreatedby_N = sdt.gxTv_SdtClienteDocumento_Clientedocumentocreatedby_N ;
         gxTv_SdtClienteDocumento_Clientedocumentoupdatedat_N = sdt.gxTv_SdtClienteDocumento_Clientedocumentoupdatedat_N ;
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
         AddObjectProperty("ClienteDocumentoId", gxTv_SdtClienteDocumento_Clientedocumentoid, false, includeNonInitialized);
         AddObjectProperty("ClienteId", gxTv_SdtClienteDocumento_Clienteid, false, includeNonInitialized);
         AddObjectProperty("ClienteId_N", gxTv_SdtClienteDocumento_Clienteid_N, false, includeNonInitialized);
         AddObjectProperty("DocumentosId", gxTv_SdtClienteDocumento_Documentosid, false, includeNonInitialized);
         AddObjectProperty("DocumentosId_N", gxTv_SdtClienteDocumento_Documentosid_N, false, includeNonInitialized);
         AddObjectProperty("DocumentosDescricao", gxTv_SdtClienteDocumento_Documentosdescricao, false, includeNonInitialized);
         AddObjectProperty("DocumentosDescricao_N", gxTv_SdtClienteDocumento_Documentosdescricao_N, false, includeNonInitialized);
         AddObjectProperty("ClienteDocumentoBlob", gxTv_SdtClienteDocumento_Clientedocumentoblob, false, includeNonInitialized);
         AddObjectProperty("ClienteDocumentoBlob_N", gxTv_SdtClienteDocumento_Clientedocumentoblob_N, false, includeNonInitialized);
         AddObjectProperty("ClienteDocumentoNome", gxTv_SdtClienteDocumento_Clientedocumentonome, false, includeNonInitialized);
         AddObjectProperty("ClienteDocumentoNome_N", gxTv_SdtClienteDocumento_Clientedocumentonome_N, false, includeNonInitialized);
         AddObjectProperty("ClienteDocumentoExtensao", gxTv_SdtClienteDocumento_Clientedocumentoextensao, false, includeNonInitialized);
         AddObjectProperty("ClienteDocumentoExtensao_N", gxTv_SdtClienteDocumento_Clientedocumentoextensao_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtClienteDocumento_Clientedocumentocreatedat;
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
         AddObjectProperty("ClienteDocumentoCreatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ClienteDocumentoCreatedAt_N", gxTv_SdtClienteDocumento_Clientedocumentocreatedat_N, false, includeNonInitialized);
         AddObjectProperty("ClienteDocumentoCreatedBy", gxTv_SdtClienteDocumento_Clientedocumentocreatedby, false, includeNonInitialized);
         AddObjectProperty("ClienteDocumentoCreatedBy_N", gxTv_SdtClienteDocumento_Clientedocumentocreatedby_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtClienteDocumento_Clientedocumentoupdatedat;
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
         AddObjectProperty("ClienteDocumentoUpdatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ClienteDocumentoUpdatedAt_N", gxTv_SdtClienteDocumento_Clientedocumentoupdatedat_N, false, includeNonInitialized);
         AddObjectProperty("ClienteNomeDoArquivo_F", gxTv_SdtClienteDocumento_Clientenomedoarquivo_f, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtClienteDocumento_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtClienteDocumento_Initialized, false, includeNonInitialized);
            AddObjectProperty("ClienteDocumentoId_Z", gxTv_SdtClienteDocumento_Clientedocumentoid_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteId_Z", gxTv_SdtClienteDocumento_Clienteid_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentosId_Z", gxTv_SdtClienteDocumento_Documentosid_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentosDescricao_Z", gxTv_SdtClienteDocumento_Documentosdescricao_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteDocumentoNome_Z", gxTv_SdtClienteDocumento_Clientedocumentonome_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteDocumentoExtensao_Z", gxTv_SdtClienteDocumento_Clientedocumentoextensao_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtClienteDocumento_Clientedocumentocreatedat_Z;
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
            AddObjectProperty("ClienteDocumentoCreatedAt_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("ClienteDocumentoCreatedBy_Z", gxTv_SdtClienteDocumento_Clientedocumentocreatedby_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtClienteDocumento_Clientedocumentoupdatedat_Z;
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
            AddObjectProperty("ClienteDocumentoUpdatedAt_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("ClienteNomeDoArquivo_F_Z", gxTv_SdtClienteDocumento_Clientenomedoarquivo_f_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteId_N", gxTv_SdtClienteDocumento_Clienteid_N, false, includeNonInitialized);
            AddObjectProperty("DocumentosId_N", gxTv_SdtClienteDocumento_Documentosid_N, false, includeNonInitialized);
            AddObjectProperty("DocumentosDescricao_N", gxTv_SdtClienteDocumento_Documentosdescricao_N, false, includeNonInitialized);
            AddObjectProperty("ClienteDocumentoBlob_N", gxTv_SdtClienteDocumento_Clientedocumentoblob_N, false, includeNonInitialized);
            AddObjectProperty("ClienteDocumentoNome_N", gxTv_SdtClienteDocumento_Clientedocumentonome_N, false, includeNonInitialized);
            AddObjectProperty("ClienteDocumentoExtensao_N", gxTv_SdtClienteDocumento_Clientedocumentoextensao_N, false, includeNonInitialized);
            AddObjectProperty("ClienteDocumentoCreatedAt_N", gxTv_SdtClienteDocumento_Clientedocumentocreatedat_N, false, includeNonInitialized);
            AddObjectProperty("ClienteDocumentoCreatedBy_N", gxTv_SdtClienteDocumento_Clientedocumentocreatedby_N, false, includeNonInitialized);
            AddObjectProperty("ClienteDocumentoUpdatedAt_N", gxTv_SdtClienteDocumento_Clientedocumentoupdatedat_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtClienteDocumento sdt )
      {
         if ( sdt.IsDirty("ClienteDocumentoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Clientedocumentoid = sdt.gxTv_SdtClienteDocumento_Clientedocumentoid ;
         }
         if ( sdt.IsDirty("ClienteId") )
         {
            gxTv_SdtClienteDocumento_Clienteid_N = (short)(sdt.gxTv_SdtClienteDocumento_Clienteid_N);
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Clienteid = sdt.gxTv_SdtClienteDocumento_Clienteid ;
         }
         if ( sdt.IsDirty("DocumentosId") )
         {
            gxTv_SdtClienteDocumento_Documentosid_N = (short)(sdt.gxTv_SdtClienteDocumento_Documentosid_N);
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Documentosid = sdt.gxTv_SdtClienteDocumento_Documentosid ;
         }
         if ( sdt.IsDirty("DocumentosDescricao") )
         {
            gxTv_SdtClienteDocumento_Documentosdescricao_N = (short)(sdt.gxTv_SdtClienteDocumento_Documentosdescricao_N);
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Documentosdescricao = sdt.gxTv_SdtClienteDocumento_Documentosdescricao ;
         }
         if ( sdt.IsDirty("ClienteDocumentoBlob") )
         {
            gxTv_SdtClienteDocumento_Clientedocumentoblob_N = (short)(sdt.gxTv_SdtClienteDocumento_Clientedocumentoblob_N);
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Clientedocumentoblob = sdt.gxTv_SdtClienteDocumento_Clientedocumentoblob ;
         }
         if ( sdt.IsDirty("ClienteDocumentoNome") )
         {
            gxTv_SdtClienteDocumento_Clientedocumentonome_N = (short)(sdt.gxTv_SdtClienteDocumento_Clientedocumentonome_N);
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Clientedocumentonome = sdt.gxTv_SdtClienteDocumento_Clientedocumentonome ;
         }
         if ( sdt.IsDirty("ClienteDocumentoExtensao") )
         {
            gxTv_SdtClienteDocumento_Clientedocumentoextensao_N = (short)(sdt.gxTv_SdtClienteDocumento_Clientedocumentoextensao_N);
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Clientedocumentoextensao = sdt.gxTv_SdtClienteDocumento_Clientedocumentoextensao ;
         }
         if ( sdt.IsDirty("ClienteDocumentoCreatedAt") )
         {
            gxTv_SdtClienteDocumento_Clientedocumentocreatedat_N = (short)(sdt.gxTv_SdtClienteDocumento_Clientedocumentocreatedat_N);
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Clientedocumentocreatedat = sdt.gxTv_SdtClienteDocumento_Clientedocumentocreatedat ;
         }
         if ( sdt.IsDirty("ClienteDocumentoCreatedBy") )
         {
            gxTv_SdtClienteDocumento_Clientedocumentocreatedby_N = (short)(sdt.gxTv_SdtClienteDocumento_Clientedocumentocreatedby_N);
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Clientedocumentocreatedby = sdt.gxTv_SdtClienteDocumento_Clientedocumentocreatedby ;
         }
         if ( sdt.IsDirty("ClienteDocumentoUpdatedAt") )
         {
            gxTv_SdtClienteDocumento_Clientedocumentoupdatedat_N = (short)(sdt.gxTv_SdtClienteDocumento_Clientedocumentoupdatedat_N);
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Clientedocumentoupdatedat = sdt.gxTv_SdtClienteDocumento_Clientedocumentoupdatedat ;
         }
         if ( sdt.IsDirty("ClienteNomeDoArquivo_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Clientenomedoarquivo_f = sdt.gxTv_SdtClienteDocumento_Clientenomedoarquivo_f ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ClienteDocumentoId" )]
      [  XmlElement( ElementName = "ClienteDocumentoId"   )]
      public int gxTpr_Clientedocumentoid
      {
         get {
            return gxTv_SdtClienteDocumento_Clientedocumentoid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtClienteDocumento_Clientedocumentoid != value )
            {
               gxTv_SdtClienteDocumento_Mode = "INS";
               this.gxTv_SdtClienteDocumento_Clientedocumentoid_Z_SetNull( );
               this.gxTv_SdtClienteDocumento_Clienteid_Z_SetNull( );
               this.gxTv_SdtClienteDocumento_Documentosid_Z_SetNull( );
               this.gxTv_SdtClienteDocumento_Documentosdescricao_Z_SetNull( );
               this.gxTv_SdtClienteDocumento_Clientedocumentonome_Z_SetNull( );
               this.gxTv_SdtClienteDocumento_Clientedocumentoextensao_Z_SetNull( );
               this.gxTv_SdtClienteDocumento_Clientedocumentocreatedat_Z_SetNull( );
               this.gxTv_SdtClienteDocumento_Clientedocumentocreatedby_Z_SetNull( );
               this.gxTv_SdtClienteDocumento_Clientedocumentoupdatedat_Z_SetNull( );
               this.gxTv_SdtClienteDocumento_Clientenomedoarquivo_f_Z_SetNull( );
            }
            gxTv_SdtClienteDocumento_Clientedocumentoid = value;
            SetDirty("Clientedocumentoid");
         }

      }

      [  SoapElement( ElementName = "ClienteId" )]
      [  XmlElement( ElementName = "ClienteId"   )]
      public int gxTpr_Clienteid
      {
         get {
            return gxTv_SdtClienteDocumento_Clienteid ;
         }

         set {
            gxTv_SdtClienteDocumento_Clienteid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Clienteid = value;
            SetDirty("Clienteid");
         }

      }

      public void gxTv_SdtClienteDocumento_Clienteid_SetNull( )
      {
         gxTv_SdtClienteDocumento_Clienteid_N = 1;
         gxTv_SdtClienteDocumento_Clienteid = 0;
         SetDirty("Clienteid");
         return  ;
      }

      public bool gxTv_SdtClienteDocumento_Clienteid_IsNull( )
      {
         return (gxTv_SdtClienteDocumento_Clienteid_N==1) ;
      }

      [  SoapElement( ElementName = "DocumentosId" )]
      [  XmlElement( ElementName = "DocumentosId"   )]
      public int gxTpr_Documentosid
      {
         get {
            return gxTv_SdtClienteDocumento_Documentosid ;
         }

         set {
            gxTv_SdtClienteDocumento_Documentosid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Documentosid = value;
            SetDirty("Documentosid");
         }

      }

      public void gxTv_SdtClienteDocumento_Documentosid_SetNull( )
      {
         gxTv_SdtClienteDocumento_Documentosid_N = 1;
         gxTv_SdtClienteDocumento_Documentosid = 0;
         SetDirty("Documentosid");
         return  ;
      }

      public bool gxTv_SdtClienteDocumento_Documentosid_IsNull( )
      {
         return (gxTv_SdtClienteDocumento_Documentosid_N==1) ;
      }

      [  SoapElement( ElementName = "DocumentosDescricao" )]
      [  XmlElement( ElementName = "DocumentosDescricao"   )]
      public string gxTpr_Documentosdescricao
      {
         get {
            return gxTv_SdtClienteDocumento_Documentosdescricao ;
         }

         set {
            gxTv_SdtClienteDocumento_Documentosdescricao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Documentosdescricao = value;
            SetDirty("Documentosdescricao");
         }

      }

      public void gxTv_SdtClienteDocumento_Documentosdescricao_SetNull( )
      {
         gxTv_SdtClienteDocumento_Documentosdescricao_N = 1;
         gxTv_SdtClienteDocumento_Documentosdescricao = "";
         SetDirty("Documentosdescricao");
         return  ;
      }

      public bool gxTv_SdtClienteDocumento_Documentosdescricao_IsNull( )
      {
         return (gxTv_SdtClienteDocumento_Documentosdescricao_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteDocumentoBlob" )]
      [  XmlElement( ElementName = "ClienteDocumentoBlob"   )]
      [GxUpload()]
      public byte[] gxTpr_Clientedocumentoblob_Blob
      {
         get {
            IGxContext context = this.context == null ? new GxContext() : this.context;
            return context.FileToByteArray( gxTv_SdtClienteDocumento_Clientedocumentoblob) ;
         }

         set {
            gxTv_SdtClienteDocumento_Clientedocumentoblob_N = 0;
            sdtIsNull = 0;
            IGxContext context = this.context == null ? new GxContext() : this.context;
            gxTv_SdtClienteDocumento_Clientedocumentoblob=context.FileFromByteArray( value) ;
         }

      }

      [XmlIgnore]
      [GxUpload()]
      public string gxTpr_Clientedocumentoblob
      {
         get {
            return gxTv_SdtClienteDocumento_Clientedocumentoblob ;
         }

         set {
            gxTv_SdtClienteDocumento_Clientedocumentoblob_N = 0;
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Clientedocumentoblob = value;
            SetDirty("Clientedocumentoblob");
         }

      }

      public void gxTv_SdtClienteDocumento_Clientedocumentoblob_SetBlob( string blob ,
                                                                         string fileName ,
                                                                         string fileType )
      {
         gxTv_SdtClienteDocumento_Clientedocumentoblob = blob;
         return  ;
      }

      public void gxTv_SdtClienteDocumento_Clientedocumentoblob_SetNull( )
      {
         gxTv_SdtClienteDocumento_Clientedocumentoblob_N = 1;
         gxTv_SdtClienteDocumento_Clientedocumentoblob = "";
         SetDirty("Clientedocumentoblob");
         return  ;
      }

      public bool gxTv_SdtClienteDocumento_Clientedocumentoblob_IsNull( )
      {
         return (gxTv_SdtClienteDocumento_Clientedocumentoblob_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteDocumentoNome" )]
      [  XmlElement( ElementName = "ClienteDocumentoNome"   )]
      public string gxTpr_Clientedocumentonome
      {
         get {
            return gxTv_SdtClienteDocumento_Clientedocumentonome ;
         }

         set {
            gxTv_SdtClienteDocumento_Clientedocumentonome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Clientedocumentonome = value;
            SetDirty("Clientedocumentonome");
         }

      }

      public void gxTv_SdtClienteDocumento_Clientedocumentonome_SetNull( )
      {
         gxTv_SdtClienteDocumento_Clientedocumentonome_N = 1;
         gxTv_SdtClienteDocumento_Clientedocumentonome = "";
         SetDirty("Clientedocumentonome");
         return  ;
      }

      public bool gxTv_SdtClienteDocumento_Clientedocumentonome_IsNull( )
      {
         return (gxTv_SdtClienteDocumento_Clientedocumentonome_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteDocumentoExtensao" )]
      [  XmlElement( ElementName = "ClienteDocumentoExtensao"   )]
      public string gxTpr_Clientedocumentoextensao
      {
         get {
            return gxTv_SdtClienteDocumento_Clientedocumentoextensao ;
         }

         set {
            gxTv_SdtClienteDocumento_Clientedocumentoextensao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Clientedocumentoextensao = value;
            SetDirty("Clientedocumentoextensao");
         }

      }

      public void gxTv_SdtClienteDocumento_Clientedocumentoextensao_SetNull( )
      {
         gxTv_SdtClienteDocumento_Clientedocumentoextensao_N = 1;
         gxTv_SdtClienteDocumento_Clientedocumentoextensao = "";
         SetDirty("Clientedocumentoextensao");
         return  ;
      }

      public bool gxTv_SdtClienteDocumento_Clientedocumentoextensao_IsNull( )
      {
         return (gxTv_SdtClienteDocumento_Clientedocumentoextensao_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteDocumentoCreatedAt" )]
      [  XmlElement( ElementName = "ClienteDocumentoCreatedAt"  , IsNullable=true )]
      public string gxTpr_Clientedocumentocreatedat_Nullable
      {
         get {
            if ( gxTv_SdtClienteDocumento_Clientedocumentocreatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtClienteDocumento_Clientedocumentocreatedat).value ;
         }

         set {
            gxTv_SdtClienteDocumento_Clientedocumentocreatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtClienteDocumento_Clientedocumentocreatedat = DateTime.MinValue;
            else
               gxTv_SdtClienteDocumento_Clientedocumentocreatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Clientedocumentocreatedat
      {
         get {
            return gxTv_SdtClienteDocumento_Clientedocumentocreatedat ;
         }

         set {
            gxTv_SdtClienteDocumento_Clientedocumentocreatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Clientedocumentocreatedat = value;
            SetDirty("Clientedocumentocreatedat");
         }

      }

      public void gxTv_SdtClienteDocumento_Clientedocumentocreatedat_SetNull( )
      {
         gxTv_SdtClienteDocumento_Clientedocumentocreatedat_N = 1;
         gxTv_SdtClienteDocumento_Clientedocumentocreatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Clientedocumentocreatedat");
         return  ;
      }

      public bool gxTv_SdtClienteDocumento_Clientedocumentocreatedat_IsNull( )
      {
         return (gxTv_SdtClienteDocumento_Clientedocumentocreatedat_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteDocumentoCreatedBy" )]
      [  XmlElement( ElementName = "ClienteDocumentoCreatedBy"   )]
      public short gxTpr_Clientedocumentocreatedby
      {
         get {
            return gxTv_SdtClienteDocumento_Clientedocumentocreatedby ;
         }

         set {
            gxTv_SdtClienteDocumento_Clientedocumentocreatedby_N = 0;
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Clientedocumentocreatedby = value;
            SetDirty("Clientedocumentocreatedby");
         }

      }

      public void gxTv_SdtClienteDocumento_Clientedocumentocreatedby_SetNull( )
      {
         gxTv_SdtClienteDocumento_Clientedocumentocreatedby_N = 1;
         gxTv_SdtClienteDocumento_Clientedocumentocreatedby = 0;
         SetDirty("Clientedocumentocreatedby");
         return  ;
      }

      public bool gxTv_SdtClienteDocumento_Clientedocumentocreatedby_IsNull( )
      {
         return (gxTv_SdtClienteDocumento_Clientedocumentocreatedby_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteDocumentoUpdatedAt" )]
      [  XmlElement( ElementName = "ClienteDocumentoUpdatedAt"  , IsNullable=true )]
      public string gxTpr_Clientedocumentoupdatedat_Nullable
      {
         get {
            if ( gxTv_SdtClienteDocumento_Clientedocumentoupdatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtClienteDocumento_Clientedocumentoupdatedat).value ;
         }

         set {
            gxTv_SdtClienteDocumento_Clientedocumentoupdatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtClienteDocumento_Clientedocumentoupdatedat = DateTime.MinValue;
            else
               gxTv_SdtClienteDocumento_Clientedocumentoupdatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Clientedocumentoupdatedat
      {
         get {
            return gxTv_SdtClienteDocumento_Clientedocumentoupdatedat ;
         }

         set {
            gxTv_SdtClienteDocumento_Clientedocumentoupdatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Clientedocumentoupdatedat = value;
            SetDirty("Clientedocumentoupdatedat");
         }

      }

      public void gxTv_SdtClienteDocumento_Clientedocumentoupdatedat_SetNull( )
      {
         gxTv_SdtClienteDocumento_Clientedocumentoupdatedat_N = 1;
         gxTv_SdtClienteDocumento_Clientedocumentoupdatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Clientedocumentoupdatedat");
         return  ;
      }

      public bool gxTv_SdtClienteDocumento_Clientedocumentoupdatedat_IsNull( )
      {
         return (gxTv_SdtClienteDocumento_Clientedocumentoupdatedat_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteNomeDoArquivo_F" )]
      [  XmlElement( ElementName = "ClienteNomeDoArquivo_F"   )]
      public string gxTpr_Clientenomedoarquivo_f
      {
         get {
            return gxTv_SdtClienteDocumento_Clientenomedoarquivo_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Clientenomedoarquivo_f = value;
            SetDirty("Clientenomedoarquivo_f");
         }

      }

      public void gxTv_SdtClienteDocumento_Clientenomedoarquivo_f_SetNull( )
      {
         gxTv_SdtClienteDocumento_Clientenomedoarquivo_f = "";
         SetDirty("Clientenomedoarquivo_f");
         return  ;
      }

      public bool gxTv_SdtClienteDocumento_Clientenomedoarquivo_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtClienteDocumento_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtClienteDocumento_Mode_SetNull( )
      {
         gxTv_SdtClienteDocumento_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtClienteDocumento_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtClienteDocumento_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtClienteDocumento_Initialized_SetNull( )
      {
         gxTv_SdtClienteDocumento_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtClienteDocumento_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteDocumentoId_Z" )]
      [  XmlElement( ElementName = "ClienteDocumentoId_Z"   )]
      public int gxTpr_Clientedocumentoid_Z
      {
         get {
            return gxTv_SdtClienteDocumento_Clientedocumentoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Clientedocumentoid_Z = value;
            SetDirty("Clientedocumentoid_Z");
         }

      }

      public void gxTv_SdtClienteDocumento_Clientedocumentoid_Z_SetNull( )
      {
         gxTv_SdtClienteDocumento_Clientedocumentoid_Z = 0;
         SetDirty("Clientedocumentoid_Z");
         return  ;
      }

      public bool gxTv_SdtClienteDocumento_Clientedocumentoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteId_Z" )]
      [  XmlElement( ElementName = "ClienteId_Z"   )]
      public int gxTpr_Clienteid_Z
      {
         get {
            return gxTv_SdtClienteDocumento_Clienteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Clienteid_Z = value;
            SetDirty("Clienteid_Z");
         }

      }

      public void gxTv_SdtClienteDocumento_Clienteid_Z_SetNull( )
      {
         gxTv_SdtClienteDocumento_Clienteid_Z = 0;
         SetDirty("Clienteid_Z");
         return  ;
      }

      public bool gxTv_SdtClienteDocumento_Clienteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentosId_Z" )]
      [  XmlElement( ElementName = "DocumentosId_Z"   )]
      public int gxTpr_Documentosid_Z
      {
         get {
            return gxTv_SdtClienteDocumento_Documentosid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Documentosid_Z = value;
            SetDirty("Documentosid_Z");
         }

      }

      public void gxTv_SdtClienteDocumento_Documentosid_Z_SetNull( )
      {
         gxTv_SdtClienteDocumento_Documentosid_Z = 0;
         SetDirty("Documentosid_Z");
         return  ;
      }

      public bool gxTv_SdtClienteDocumento_Documentosid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentosDescricao_Z" )]
      [  XmlElement( ElementName = "DocumentosDescricao_Z"   )]
      public string gxTpr_Documentosdescricao_Z
      {
         get {
            return gxTv_SdtClienteDocumento_Documentosdescricao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Documentosdescricao_Z = value;
            SetDirty("Documentosdescricao_Z");
         }

      }

      public void gxTv_SdtClienteDocumento_Documentosdescricao_Z_SetNull( )
      {
         gxTv_SdtClienteDocumento_Documentosdescricao_Z = "";
         SetDirty("Documentosdescricao_Z");
         return  ;
      }

      public bool gxTv_SdtClienteDocumento_Documentosdescricao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteDocumentoNome_Z" )]
      [  XmlElement( ElementName = "ClienteDocumentoNome_Z"   )]
      public string gxTpr_Clientedocumentonome_Z
      {
         get {
            return gxTv_SdtClienteDocumento_Clientedocumentonome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Clientedocumentonome_Z = value;
            SetDirty("Clientedocumentonome_Z");
         }

      }

      public void gxTv_SdtClienteDocumento_Clientedocumentonome_Z_SetNull( )
      {
         gxTv_SdtClienteDocumento_Clientedocumentonome_Z = "";
         SetDirty("Clientedocumentonome_Z");
         return  ;
      }

      public bool gxTv_SdtClienteDocumento_Clientedocumentonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteDocumentoExtensao_Z" )]
      [  XmlElement( ElementName = "ClienteDocumentoExtensao_Z"   )]
      public string gxTpr_Clientedocumentoextensao_Z
      {
         get {
            return gxTv_SdtClienteDocumento_Clientedocumentoextensao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Clientedocumentoextensao_Z = value;
            SetDirty("Clientedocumentoextensao_Z");
         }

      }

      public void gxTv_SdtClienteDocumento_Clientedocumentoextensao_Z_SetNull( )
      {
         gxTv_SdtClienteDocumento_Clientedocumentoextensao_Z = "";
         SetDirty("Clientedocumentoextensao_Z");
         return  ;
      }

      public bool gxTv_SdtClienteDocumento_Clientedocumentoextensao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteDocumentoCreatedAt_Z" )]
      [  XmlElement( ElementName = "ClienteDocumentoCreatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Clientedocumentocreatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtClienteDocumento_Clientedocumentocreatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtClienteDocumento_Clientedocumentocreatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtClienteDocumento_Clientedocumentocreatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtClienteDocumento_Clientedocumentocreatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Clientedocumentocreatedat_Z
      {
         get {
            return gxTv_SdtClienteDocumento_Clientedocumentocreatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Clientedocumentocreatedat_Z = value;
            SetDirty("Clientedocumentocreatedat_Z");
         }

      }

      public void gxTv_SdtClienteDocumento_Clientedocumentocreatedat_Z_SetNull( )
      {
         gxTv_SdtClienteDocumento_Clientedocumentocreatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Clientedocumentocreatedat_Z");
         return  ;
      }

      public bool gxTv_SdtClienteDocumento_Clientedocumentocreatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteDocumentoCreatedBy_Z" )]
      [  XmlElement( ElementName = "ClienteDocumentoCreatedBy_Z"   )]
      public short gxTpr_Clientedocumentocreatedby_Z
      {
         get {
            return gxTv_SdtClienteDocumento_Clientedocumentocreatedby_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Clientedocumentocreatedby_Z = value;
            SetDirty("Clientedocumentocreatedby_Z");
         }

      }

      public void gxTv_SdtClienteDocumento_Clientedocumentocreatedby_Z_SetNull( )
      {
         gxTv_SdtClienteDocumento_Clientedocumentocreatedby_Z = 0;
         SetDirty("Clientedocumentocreatedby_Z");
         return  ;
      }

      public bool gxTv_SdtClienteDocumento_Clientedocumentocreatedby_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteDocumentoUpdatedAt_Z" )]
      [  XmlElement( ElementName = "ClienteDocumentoUpdatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Clientedocumentoupdatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtClienteDocumento_Clientedocumentoupdatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtClienteDocumento_Clientedocumentoupdatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtClienteDocumento_Clientedocumentoupdatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtClienteDocumento_Clientedocumentoupdatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Clientedocumentoupdatedat_Z
      {
         get {
            return gxTv_SdtClienteDocumento_Clientedocumentoupdatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Clientedocumentoupdatedat_Z = value;
            SetDirty("Clientedocumentoupdatedat_Z");
         }

      }

      public void gxTv_SdtClienteDocumento_Clientedocumentoupdatedat_Z_SetNull( )
      {
         gxTv_SdtClienteDocumento_Clientedocumentoupdatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Clientedocumentoupdatedat_Z");
         return  ;
      }

      public bool gxTv_SdtClienteDocumento_Clientedocumentoupdatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteNomeDoArquivo_F_Z" )]
      [  XmlElement( ElementName = "ClienteNomeDoArquivo_F_Z"   )]
      public string gxTpr_Clientenomedoarquivo_f_Z
      {
         get {
            return gxTv_SdtClienteDocumento_Clientenomedoarquivo_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Clientenomedoarquivo_f_Z = value;
            SetDirty("Clientenomedoarquivo_f_Z");
         }

      }

      public void gxTv_SdtClienteDocumento_Clientenomedoarquivo_f_Z_SetNull( )
      {
         gxTv_SdtClienteDocumento_Clientenomedoarquivo_f_Z = "";
         SetDirty("Clientenomedoarquivo_f_Z");
         return  ;
      }

      public bool gxTv_SdtClienteDocumento_Clientenomedoarquivo_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteId_N" )]
      [  XmlElement( ElementName = "ClienteId_N"   )]
      public short gxTpr_Clienteid_N
      {
         get {
            return gxTv_SdtClienteDocumento_Clienteid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Clienteid_N = value;
            SetDirty("Clienteid_N");
         }

      }

      public void gxTv_SdtClienteDocumento_Clienteid_N_SetNull( )
      {
         gxTv_SdtClienteDocumento_Clienteid_N = 0;
         SetDirty("Clienteid_N");
         return  ;
      }

      public bool gxTv_SdtClienteDocumento_Clienteid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentosId_N" )]
      [  XmlElement( ElementName = "DocumentosId_N"   )]
      public short gxTpr_Documentosid_N
      {
         get {
            return gxTv_SdtClienteDocumento_Documentosid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Documentosid_N = value;
            SetDirty("Documentosid_N");
         }

      }

      public void gxTv_SdtClienteDocumento_Documentosid_N_SetNull( )
      {
         gxTv_SdtClienteDocumento_Documentosid_N = 0;
         SetDirty("Documentosid_N");
         return  ;
      }

      public bool gxTv_SdtClienteDocumento_Documentosid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentosDescricao_N" )]
      [  XmlElement( ElementName = "DocumentosDescricao_N"   )]
      public short gxTpr_Documentosdescricao_N
      {
         get {
            return gxTv_SdtClienteDocumento_Documentosdescricao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Documentosdescricao_N = value;
            SetDirty("Documentosdescricao_N");
         }

      }

      public void gxTv_SdtClienteDocumento_Documentosdescricao_N_SetNull( )
      {
         gxTv_SdtClienteDocumento_Documentosdescricao_N = 0;
         SetDirty("Documentosdescricao_N");
         return  ;
      }

      public bool gxTv_SdtClienteDocumento_Documentosdescricao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteDocumentoBlob_N" )]
      [  XmlElement( ElementName = "ClienteDocumentoBlob_N"   )]
      public short gxTpr_Clientedocumentoblob_N
      {
         get {
            return gxTv_SdtClienteDocumento_Clientedocumentoblob_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Clientedocumentoblob_N = value;
            SetDirty("Clientedocumentoblob_N");
         }

      }

      public void gxTv_SdtClienteDocumento_Clientedocumentoblob_N_SetNull( )
      {
         gxTv_SdtClienteDocumento_Clientedocumentoblob_N = 0;
         SetDirty("Clientedocumentoblob_N");
         return  ;
      }

      public bool gxTv_SdtClienteDocumento_Clientedocumentoblob_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteDocumentoNome_N" )]
      [  XmlElement( ElementName = "ClienteDocumentoNome_N"   )]
      public short gxTpr_Clientedocumentonome_N
      {
         get {
            return gxTv_SdtClienteDocumento_Clientedocumentonome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Clientedocumentonome_N = value;
            SetDirty("Clientedocumentonome_N");
         }

      }

      public void gxTv_SdtClienteDocumento_Clientedocumentonome_N_SetNull( )
      {
         gxTv_SdtClienteDocumento_Clientedocumentonome_N = 0;
         SetDirty("Clientedocumentonome_N");
         return  ;
      }

      public bool gxTv_SdtClienteDocumento_Clientedocumentonome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteDocumentoExtensao_N" )]
      [  XmlElement( ElementName = "ClienteDocumentoExtensao_N"   )]
      public short gxTpr_Clientedocumentoextensao_N
      {
         get {
            return gxTv_SdtClienteDocumento_Clientedocumentoextensao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Clientedocumentoextensao_N = value;
            SetDirty("Clientedocumentoextensao_N");
         }

      }

      public void gxTv_SdtClienteDocumento_Clientedocumentoextensao_N_SetNull( )
      {
         gxTv_SdtClienteDocumento_Clientedocumentoextensao_N = 0;
         SetDirty("Clientedocumentoextensao_N");
         return  ;
      }

      public bool gxTv_SdtClienteDocumento_Clientedocumentoextensao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteDocumentoCreatedAt_N" )]
      [  XmlElement( ElementName = "ClienteDocumentoCreatedAt_N"   )]
      public short gxTpr_Clientedocumentocreatedat_N
      {
         get {
            return gxTv_SdtClienteDocumento_Clientedocumentocreatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Clientedocumentocreatedat_N = value;
            SetDirty("Clientedocumentocreatedat_N");
         }

      }

      public void gxTv_SdtClienteDocumento_Clientedocumentocreatedat_N_SetNull( )
      {
         gxTv_SdtClienteDocumento_Clientedocumentocreatedat_N = 0;
         SetDirty("Clientedocumentocreatedat_N");
         return  ;
      }

      public bool gxTv_SdtClienteDocumento_Clientedocumentocreatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteDocumentoCreatedBy_N" )]
      [  XmlElement( ElementName = "ClienteDocumentoCreatedBy_N"   )]
      public short gxTpr_Clientedocumentocreatedby_N
      {
         get {
            return gxTv_SdtClienteDocumento_Clientedocumentocreatedby_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Clientedocumentocreatedby_N = value;
            SetDirty("Clientedocumentocreatedby_N");
         }

      }

      public void gxTv_SdtClienteDocumento_Clientedocumentocreatedby_N_SetNull( )
      {
         gxTv_SdtClienteDocumento_Clientedocumentocreatedby_N = 0;
         SetDirty("Clientedocumentocreatedby_N");
         return  ;
      }

      public bool gxTv_SdtClienteDocumento_Clientedocumentocreatedby_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteDocumentoUpdatedAt_N" )]
      [  XmlElement( ElementName = "ClienteDocumentoUpdatedAt_N"   )]
      public short gxTpr_Clientedocumentoupdatedat_N
      {
         get {
            return gxTv_SdtClienteDocumento_Clientedocumentoupdatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteDocumento_Clientedocumentoupdatedat_N = value;
            SetDirty("Clientedocumentoupdatedat_N");
         }

      }

      public void gxTv_SdtClienteDocumento_Clientedocumentoupdatedat_N_SetNull( )
      {
         gxTv_SdtClienteDocumento_Clientedocumentoupdatedat_N = 0;
         SetDirty("Clientedocumentoupdatedat_N");
         return  ;
      }

      public bool gxTv_SdtClienteDocumento_Clientedocumentoupdatedat_N_IsNull( )
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
         gxTv_SdtClienteDocumento_Documentosdescricao = "";
         gxTv_SdtClienteDocumento_Clientedocumentoblob = "";
         gxTv_SdtClienteDocumento_Clientedocumentonome = "";
         gxTv_SdtClienteDocumento_Clientedocumentoextensao = "";
         gxTv_SdtClienteDocumento_Clientedocumentocreatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtClienteDocumento_Clientedocumentoupdatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtClienteDocumento_Clientenomedoarquivo_f = "";
         gxTv_SdtClienteDocumento_Mode = "";
         gxTv_SdtClienteDocumento_Documentosdescricao_Z = "";
         gxTv_SdtClienteDocumento_Clientedocumentonome_Z = "";
         gxTv_SdtClienteDocumento_Clientedocumentoextensao_Z = "";
         gxTv_SdtClienteDocumento_Clientedocumentocreatedat_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtClienteDocumento_Clientedocumentoupdatedat_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtClienteDocumento_Clientenomedoarquivo_f_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "clientedocumento", "GeneXus.Programs.clientedocumento_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtClienteDocumento_Clientedocumentocreatedby ;
      private short gxTv_SdtClienteDocumento_Initialized ;
      private short gxTv_SdtClienteDocumento_Clientedocumentocreatedby_Z ;
      private short gxTv_SdtClienteDocumento_Clienteid_N ;
      private short gxTv_SdtClienteDocumento_Documentosid_N ;
      private short gxTv_SdtClienteDocumento_Documentosdescricao_N ;
      private short gxTv_SdtClienteDocumento_Clientedocumentoblob_N ;
      private short gxTv_SdtClienteDocumento_Clientedocumentonome_N ;
      private short gxTv_SdtClienteDocumento_Clientedocumentoextensao_N ;
      private short gxTv_SdtClienteDocumento_Clientedocumentocreatedat_N ;
      private short gxTv_SdtClienteDocumento_Clientedocumentocreatedby_N ;
      private short gxTv_SdtClienteDocumento_Clientedocumentoupdatedat_N ;
      private int gxTv_SdtClienteDocumento_Clientedocumentoid ;
      private int gxTv_SdtClienteDocumento_Clienteid ;
      private int gxTv_SdtClienteDocumento_Documentosid ;
      private int gxTv_SdtClienteDocumento_Clientedocumentoid_Z ;
      private int gxTv_SdtClienteDocumento_Clienteid_Z ;
      private int gxTv_SdtClienteDocumento_Documentosid_Z ;
      private string gxTv_SdtClienteDocumento_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtClienteDocumento_Clientedocumentocreatedat ;
      private DateTime gxTv_SdtClienteDocumento_Clientedocumentoupdatedat ;
      private DateTime gxTv_SdtClienteDocumento_Clientedocumentocreatedat_Z ;
      private DateTime gxTv_SdtClienteDocumento_Clientedocumentoupdatedat_Z ;
      private DateTime datetime_STZ ;
      private string gxTv_SdtClienteDocumento_Documentosdescricao ;
      private string gxTv_SdtClienteDocumento_Clientedocumentonome ;
      private string gxTv_SdtClienteDocumento_Clientedocumentoextensao ;
      private string gxTv_SdtClienteDocumento_Clientenomedoarquivo_f ;
      private string gxTv_SdtClienteDocumento_Documentosdescricao_Z ;
      private string gxTv_SdtClienteDocumento_Clientedocumentonome_Z ;
      private string gxTv_SdtClienteDocumento_Clientedocumentoextensao_Z ;
      private string gxTv_SdtClienteDocumento_Clientenomedoarquivo_f_Z ;
      private string gxTv_SdtClienteDocumento_Clientedocumentoblob ;
   }

   [DataContract(Name = @"ClienteDocumento", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtClienteDocumento_RESTInterface : GxGenericCollectionItem<SdtClienteDocumento>
   {
      public SdtClienteDocumento_RESTInterface( ) : base()
      {
      }

      public SdtClienteDocumento_RESTInterface( SdtClienteDocumento psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ClienteDocumentoId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Clientedocumentoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Clientedocumentoid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Clientedocumentoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ClienteId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Clienteid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Clienteid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Clienteid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
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

      [DataMember( Name = "ClienteDocumentoBlob" , Order = 4 )]
      [GxUpload()]
      public string gxTpr_Clientedocumentoblob
      {
         get {
            return PathUtil.RelativeURL( sdt.gxTpr_Clientedocumentoblob) ;
         }

         set {
            sdt.gxTpr_Clientedocumentoblob = value;
         }

      }

      [DataMember( Name = "ClienteDocumentoNome" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Clientedocumentonome
      {
         get {
            return sdt.gxTpr_Clientedocumentonome ;
         }

         set {
            sdt.gxTpr_Clientedocumentonome = value;
         }

      }

      [DataMember( Name = "ClienteDocumentoExtensao" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Clientedocumentoextensao
      {
         get {
            return sdt.gxTpr_Clientedocumentoextensao ;
         }

         set {
            sdt.gxTpr_Clientedocumentoextensao = value;
         }

      }

      [DataMember( Name = "ClienteDocumentoCreatedAt" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Clientedocumentocreatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Clientedocumentocreatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Clientedocumentocreatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "ClienteDocumentoCreatedBy" , Order = 8 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Clientedocumentocreatedby
      {
         get {
            return sdt.gxTpr_Clientedocumentocreatedby ;
         }

         set {
            sdt.gxTpr_Clientedocumentocreatedby = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ClienteDocumentoUpdatedAt" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Clientedocumentoupdatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Clientedocumentoupdatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Clientedocumentoupdatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "ClienteNomeDoArquivo_F" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Clientenomedoarquivo_f
      {
         get {
            return sdt.gxTpr_Clientenomedoarquivo_f ;
         }

         set {
            sdt.gxTpr_Clientenomedoarquivo_f = value;
         }

      }

      public SdtClienteDocumento sdt
      {
         get {
            return (SdtClienteDocumento)Sdt ;
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
            sdt = new SdtClienteDocumento() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 11 )]
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

   [DataContract(Name = @"ClienteDocumento", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtClienteDocumento_RESTLInterface : GxGenericCollectionItem<SdtClienteDocumento>
   {
      public SdtClienteDocumento_RESTLInterface( ) : base()
      {
      }

      public SdtClienteDocumento_RESTLInterface( SdtClienteDocumento psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ClienteDocumentoNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Clientedocumentonome
      {
         get {
            return sdt.gxTpr_Clientedocumentonome ;
         }

         set {
            sdt.gxTpr_Clientedocumentonome = value;
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

      public SdtClienteDocumento sdt
      {
         get {
            return (SdtClienteDocumento)Sdt ;
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
            sdt = new SdtClienteDocumento() ;
         }
      }

   }

}
