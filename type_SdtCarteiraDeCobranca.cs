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
   [XmlRoot(ElementName = "CarteiraDeCobranca" )]
   [XmlType(TypeName =  "CarteiraDeCobranca" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtCarteiraDeCobranca : GxSilentTrnSdt
   {
      public SdtCarteiraDeCobranca( )
      {
      }

      public SdtCarteiraDeCobranca( IGxContext context )
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

      public void Load( int AV1069CarteiraDeCobrancaId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV1069CarteiraDeCobrancaId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"CarteiraDeCobrancaId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "CarteiraDeCobranca");
         metadata.Set("BT", "CarteiraDeCobranca");
         metadata.Set("PK", "[ \"CarteiraDeCobrancaId\" ]");
         metadata.Set("PKAssigned", "[ \"CarteiraDeCobrancaId\" ]");
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
         state.Add("gxTpr_Carteiradecobrancaid_Z");
         state.Add("gxTpr_Carteiradecobrancacodigo_Z");
         state.Add("gxTpr_Carteiradecobrancanome_Z");
         state.Add("gxTpr_Carteiradecobrancaworkspaceid_Z");
         state.Add("gxTpr_Carteiradecobrancaconvenio_Z");
         state.Add("gxTpr_Carteiradecobrancastatus_Z");
         state.Add("gxTpr_Carteiradecobrancacreatedat_Z_Nullable");
         state.Add("gxTpr_Carteiradecobrancaupdatedat_Z_Nullable");
         state.Add("gxTpr_Carteiradecobrancavalortotal_Z");
         state.Add("gxTpr_Carteiradecobrancavalorrecebido_Z");
         state.Add("gxTpr_Carteiradecobrancatotalboletos_Z");
         state.Add("gxTpr_Carteiradecobrancatotalboletosregistrados_Z");
         state.Add("gxTpr_Carteiradecobrancatotalboletosexpirados_Z");
         state.Add("gxTpr_Carteiradecobrancatotalboletoscancelados_Z");
         state.Add("gxTpr_Carteiradecobrancaid_N");
         state.Add("gxTpr_Carteiradecobrancacodigo_N");
         state.Add("gxTpr_Carteiradecobrancanome_N");
         state.Add("gxTpr_Carteiradecobrancaworkspaceid_N");
         state.Add("gxTpr_Carteiradecobrancaconvenio_N");
         state.Add("gxTpr_Carteiradecobrancastatus_N");
         state.Add("gxTpr_Carteiradecobrancacreatedat_N");
         state.Add("gxTpr_Carteiradecobrancaupdatedat_N");
         state.Add("gxTpr_Carteiradecobrancatotalboletosregistrados_N");
         state.Add("gxTpr_Carteiradecobrancatotalboletosexpirados_N");
         state.Add("gxTpr_Carteiradecobrancatotalboletoscancelados_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtCarteiraDeCobranca sdt;
         sdt = (SdtCarteiraDeCobranca)(source);
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaid = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaid ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancastatus = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancastatus ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalortotal = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalortotal ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalorrecebido = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalorrecebido ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletos = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletos ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosregistrados = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosregistrados ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosexpirados = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosexpirados ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletoscancelados = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletoscancelados ;
         gxTv_SdtCarteiraDeCobranca_Mode = sdt.gxTv_SdtCarteiraDeCobranca_Mode ;
         gxTv_SdtCarteiraDeCobranca_Initialized = sdt.gxTv_SdtCarteiraDeCobranca_Initialized ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaid_Z = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaid_Z ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo_Z = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo_Z ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome_Z = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome_Z ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid_Z = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid_Z ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio_Z = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio_Z ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancastatus_Z = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancastatus_Z ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat_Z = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat_Z ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat_Z = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat_Z ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalortotal_Z = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalortotal_Z ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalorrecebido_Z = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalorrecebido_Z ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletos_Z = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletos_Z ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosregistrados_Z = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosregistrados_Z ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosexpirados_Z = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosexpirados_Z ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletoscancelados_Z = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletoscancelados_Z ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaid_N = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaid_N ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo_N = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo_N ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome_N = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome_N ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid_N = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid_N ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio_N = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio_N ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancastatus_N = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancastatus_N ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat_N = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat_N ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat_N = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat_N ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosregistrados_N = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosregistrados_N ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosexpirados_N = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosexpirados_N ;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletoscancelados_N = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletoscancelados_N ;
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
         AddObjectProperty("CarteiraDeCobrancaId", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaid, false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaId_N", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaid_N, false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaCodigo", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo, false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaCodigo_N", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo_N, false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaNome", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome, false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaNome_N", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome_N, false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaWorkspaceId", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid, false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaWorkspaceId_N", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid_N, false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaConvenio", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio, false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaConvenio_N", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio_N, false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaStatus", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancastatus, false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaStatus_N", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancastatus_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat;
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
         AddObjectProperty("CarteiraDeCobrancaCreatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaCreatedAt_N", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat;
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
         AddObjectProperty("CarteiraDeCobrancaUpdatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaUpdatedAt_N", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat_N, false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaValorTotal", StringUtil.LTrim( StringUtil.Str( gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalortotal, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaValorRecebido", StringUtil.LTrim( StringUtil.Str( gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalorrecebido, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaTotalBoletos", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletos, false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaTotalBoletosRegistrados", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosregistrados, false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaTotalBoletosRegistrados_N", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosregistrados_N, false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaTotalBoletosExpirados", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosexpirados, false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaTotalBoletosExpirados_N", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosexpirados_N, false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaTotalBoletosCancelados", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletoscancelados, false, includeNonInitialized);
         AddObjectProperty("CarteiraDeCobrancaTotalBoletosCancelados_N", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletoscancelados_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtCarteiraDeCobranca_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtCarteiraDeCobranca_Initialized, false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaId_Z", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaid_Z, false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaCodigo_Z", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo_Z, false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaNome_Z", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome_Z, false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaWorkspaceId_Z", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid_Z, false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaConvenio_Z", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio_Z, false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaStatus_Z", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancastatus_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat_Z;
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
            AddObjectProperty("CarteiraDeCobrancaCreatedAt_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat_Z;
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
            AddObjectProperty("CarteiraDeCobrancaUpdatedAt_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaValorTotal_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalortotal_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaValorRecebido_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalorrecebido_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaTotalBoletos_Z", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletos_Z, false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaTotalBoletosRegistrados_Z", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosregistrados_Z, false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaTotalBoletosExpirados_Z", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosexpirados_Z, false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaTotalBoletosCancelados_Z", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletoscancelados_Z, false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaId_N", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaid_N, false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaCodigo_N", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo_N, false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaNome_N", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome_N, false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaWorkspaceId_N", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid_N, false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaConvenio_N", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio_N, false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaStatus_N", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancastatus_N, false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaCreatedAt_N", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat_N, false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaUpdatedAt_N", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat_N, false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaTotalBoletosRegistrados_N", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosregistrados_N, false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaTotalBoletosExpirados_N", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosexpirados_N, false, includeNonInitialized);
            AddObjectProperty("CarteiraDeCobrancaTotalBoletosCancelados_N", gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletoscancelados_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtCarteiraDeCobranca sdt )
      {
         if ( sdt.IsDirty("CarteiraDeCobrancaId") )
         {
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaid = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaid ;
         }
         if ( sdt.IsDirty("CarteiraDeCobrancaCodigo") )
         {
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo_N = (short)(sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo_N);
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo ;
         }
         if ( sdt.IsDirty("CarteiraDeCobrancaNome") )
         {
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome_N = (short)(sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome_N);
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome ;
         }
         if ( sdt.IsDirty("CarteiraDeCobrancaWorkspaceId") )
         {
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid_N = (short)(sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid_N);
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid ;
         }
         if ( sdt.IsDirty("CarteiraDeCobrancaConvenio") )
         {
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio_N = (short)(sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio_N);
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio ;
         }
         if ( sdt.IsDirty("CarteiraDeCobrancaStatus") )
         {
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancastatus_N = (short)(sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancastatus_N);
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancastatus = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancastatus ;
         }
         if ( sdt.IsDirty("CarteiraDeCobrancaCreatedAt") )
         {
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat_N = (short)(sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat_N);
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat ;
         }
         if ( sdt.IsDirty("CarteiraDeCobrancaUpdatedAt") )
         {
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat_N = (short)(sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat_N);
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat ;
         }
         if ( sdt.IsDirty("CarteiraDeCobrancaValorTotal") )
         {
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalortotal = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalortotal ;
         }
         if ( sdt.IsDirty("CarteiraDeCobrancaValorRecebido") )
         {
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalorrecebido = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalorrecebido ;
         }
         if ( sdt.IsDirty("CarteiraDeCobrancaTotalBoletos") )
         {
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletos = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletos ;
         }
         if ( sdt.IsDirty("CarteiraDeCobrancaTotalBoletosRegistrados") )
         {
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosregistrados_N = (short)(sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosregistrados_N);
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosregistrados = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosregistrados ;
         }
         if ( sdt.IsDirty("CarteiraDeCobrancaTotalBoletosExpirados") )
         {
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosexpirados_N = (short)(sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosexpirados_N);
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosexpirados = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosexpirados ;
         }
         if ( sdt.IsDirty("CarteiraDeCobrancaTotalBoletosCancelados") )
         {
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletoscancelados_N = (short)(sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletoscancelados_N);
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletoscancelados = sdt.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletoscancelados ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaId" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaId"   )]
      public int gxTpr_Carteiradecobrancaid
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaid != value )
            {
               gxTv_SdtCarteiraDeCobranca_Mode = "INS";
               this.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaid_Z_SetNull( );
               this.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo_Z_SetNull( );
               this.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome_Z_SetNull( );
               this.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid_Z_SetNull( );
               this.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio_Z_SetNull( );
               this.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancastatus_Z_SetNull( );
               this.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat_Z_SetNull( );
               this.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat_Z_SetNull( );
               this.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalortotal_Z_SetNull( );
               this.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalorrecebido_Z_SetNull( );
               this.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletos_Z_SetNull( );
               this.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosregistrados_Z_SetNull( );
               this.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosexpirados_Z_SetNull( );
               this.gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletoscancelados_Z_SetNull( );
            }
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaid = value;
            SetDirty("Carteiradecobrancaid");
         }

      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaCodigo" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaCodigo"   )]
      public string gxTpr_Carteiradecobrancacodigo
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo ;
         }

         set {
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo = value;
            SetDirty("Carteiradecobrancacodigo");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo_N = 1;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo = "";
         SetDirty("Carteiradecobrancacodigo");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo_IsNull( )
      {
         return (gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo_N==1) ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaNome" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaNome"   )]
      public string gxTpr_Carteiradecobrancanome
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome ;
         }

         set {
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome = value;
            SetDirty("Carteiradecobrancanome");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome_N = 1;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome = "";
         SetDirty("Carteiradecobrancanome");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome_IsNull( )
      {
         return (gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome_N==1) ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaWorkspaceId" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaWorkspaceId"   )]
      public Guid gxTpr_Carteiradecobrancaworkspaceid
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid ;
         }

         set {
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid = value;
            SetDirty("Carteiradecobrancaworkspaceid");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid_N = 1;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid = Guid.Empty;
         SetDirty("Carteiradecobrancaworkspaceid");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid_IsNull( )
      {
         return (gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid_N==1) ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaConvenio" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaConvenio"   )]
      public string gxTpr_Carteiradecobrancaconvenio
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio ;
         }

         set {
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio = value;
            SetDirty("Carteiradecobrancaconvenio");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio_N = 1;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio = "";
         SetDirty("Carteiradecobrancaconvenio");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio_IsNull( )
      {
         return (gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio_N==1) ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaStatus" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaStatus"   )]
      public bool gxTpr_Carteiradecobrancastatus
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancastatus ;
         }

         set {
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancastatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancastatus = value;
            SetDirty("Carteiradecobrancastatus");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancastatus_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancastatus_N = 1;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancastatus = false;
         SetDirty("Carteiradecobrancastatus");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancastatus_IsNull( )
      {
         return (gxTv_SdtCarteiraDeCobranca_Carteiradecobrancastatus_N==1) ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaCreatedAt" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaCreatedAt"  , IsNullable=true )]
      public string gxTpr_Carteiradecobrancacreatedat_Nullable
      {
         get {
            if ( gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat).value ;
         }

         set {
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat = DateTime.MinValue;
            else
               gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Carteiradecobrancacreatedat
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat ;
         }

         set {
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat = value;
            SetDirty("Carteiradecobrancacreatedat");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat_N = 1;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Carteiradecobrancacreatedat");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat_IsNull( )
      {
         return (gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat_N==1) ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaUpdatedAt" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaUpdatedAt"  , IsNullable=true )]
      public string gxTpr_Carteiradecobrancaupdatedat_Nullable
      {
         get {
            if ( gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat).value ;
         }

         set {
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat = DateTime.MinValue;
            else
               gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Carteiradecobrancaupdatedat
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat ;
         }

         set {
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat = value;
            SetDirty("Carteiradecobrancaupdatedat");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat_N = 1;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Carteiradecobrancaupdatedat");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat_IsNull( )
      {
         return (gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat_N==1) ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaValorTotal" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaValorTotal"   )]
      public decimal gxTpr_Carteiradecobrancavalortotal
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalortotal ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalortotal = value;
            SetDirty("Carteiradecobrancavalortotal");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalortotal_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalortotal = 0;
         SetDirty("Carteiradecobrancavalortotal");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalortotal_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaValorRecebido" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaValorRecebido"   )]
      public decimal gxTpr_Carteiradecobrancavalorrecebido
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalorrecebido ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalorrecebido = value;
            SetDirty("Carteiradecobrancavalorrecebido");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalorrecebido_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalorrecebido = 0;
         SetDirty("Carteiradecobrancavalorrecebido");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalorrecebido_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaTotalBoletos" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaTotalBoletos"   )]
      public int gxTpr_Carteiradecobrancatotalboletos
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletos ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletos = value;
            SetDirty("Carteiradecobrancatotalboletos");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletos_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletos = 0;
         SetDirty("Carteiradecobrancatotalboletos");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletos_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaTotalBoletosRegistrados" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaTotalBoletosRegistrados"   )]
      public int gxTpr_Carteiradecobrancatotalboletosregistrados
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosregistrados ;
         }

         set {
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosregistrados_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosregistrados = value;
            SetDirty("Carteiradecobrancatotalboletosregistrados");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosregistrados_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosregistrados_N = 1;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosregistrados = 0;
         SetDirty("Carteiradecobrancatotalboletosregistrados");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosregistrados_IsNull( )
      {
         return (gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosregistrados_N==1) ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaTotalBoletosExpirados" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaTotalBoletosExpirados"   )]
      public int gxTpr_Carteiradecobrancatotalboletosexpirados
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosexpirados ;
         }

         set {
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosexpirados_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosexpirados = value;
            SetDirty("Carteiradecobrancatotalboletosexpirados");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosexpirados_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosexpirados_N = 1;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosexpirados = 0;
         SetDirty("Carteiradecobrancatotalboletosexpirados");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosexpirados_IsNull( )
      {
         return (gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosexpirados_N==1) ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaTotalBoletosCancelados" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaTotalBoletosCancelados"   )]
      public int gxTpr_Carteiradecobrancatotalboletoscancelados
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletoscancelados ;
         }

         set {
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletoscancelados_N = 0;
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletoscancelados = value;
            SetDirty("Carteiradecobrancatotalboletoscancelados");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletoscancelados_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletoscancelados_N = 1;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletoscancelados = 0;
         SetDirty("Carteiradecobrancatotalboletoscancelados");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletoscancelados_IsNull( )
      {
         return (gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletoscancelados_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Mode_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Initialized_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaId_Z" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaId_Z"   )]
      public int gxTpr_Carteiradecobrancaid_Z
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaid_Z = value;
            SetDirty("Carteiradecobrancaid_Z");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaid_Z_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaid_Z = 0;
         SetDirty("Carteiradecobrancaid_Z");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaCodigo_Z" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaCodigo_Z"   )]
      public string gxTpr_Carteiradecobrancacodigo_Z
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo_Z = value;
            SetDirty("Carteiradecobrancacodigo_Z");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo_Z_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo_Z = "";
         SetDirty("Carteiradecobrancacodigo_Z");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaNome_Z" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaNome_Z"   )]
      public string gxTpr_Carteiradecobrancanome_Z
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome_Z = value;
            SetDirty("Carteiradecobrancanome_Z");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome_Z_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome_Z = "";
         SetDirty("Carteiradecobrancanome_Z");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaWorkspaceId_Z" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaWorkspaceId_Z"   )]
      public Guid gxTpr_Carteiradecobrancaworkspaceid_Z
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid_Z = value;
            SetDirty("Carteiradecobrancaworkspaceid_Z");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid_Z_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid_Z = Guid.Empty;
         SetDirty("Carteiradecobrancaworkspaceid_Z");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaConvenio_Z" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaConvenio_Z"   )]
      public string gxTpr_Carteiradecobrancaconvenio_Z
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio_Z = value;
            SetDirty("Carteiradecobrancaconvenio_Z");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio_Z_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio_Z = "";
         SetDirty("Carteiradecobrancaconvenio_Z");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaStatus_Z" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaStatus_Z"   )]
      public bool gxTpr_Carteiradecobrancastatus_Z
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancastatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancastatus_Z = value;
            SetDirty("Carteiradecobrancastatus_Z");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancastatus_Z_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancastatus_Z = false;
         SetDirty("Carteiradecobrancastatus_Z");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancastatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaCreatedAt_Z" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaCreatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Carteiradecobrancacreatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Carteiradecobrancacreatedat_Z
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat_Z = value;
            SetDirty("Carteiradecobrancacreatedat_Z");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat_Z_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Carteiradecobrancacreatedat_Z");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaUpdatedAt_Z" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaUpdatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Carteiradecobrancaupdatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Carteiradecobrancaupdatedat_Z
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat_Z = value;
            SetDirty("Carteiradecobrancaupdatedat_Z");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat_Z_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Carteiradecobrancaupdatedat_Z");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaValorTotal_Z" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaValorTotal_Z"   )]
      public decimal gxTpr_Carteiradecobrancavalortotal_Z
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalortotal_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalortotal_Z = value;
            SetDirty("Carteiradecobrancavalortotal_Z");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalortotal_Z_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalortotal_Z = 0;
         SetDirty("Carteiradecobrancavalortotal_Z");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalortotal_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaValorRecebido_Z" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaValorRecebido_Z"   )]
      public decimal gxTpr_Carteiradecobrancavalorrecebido_Z
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalorrecebido_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalorrecebido_Z = value;
            SetDirty("Carteiradecobrancavalorrecebido_Z");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalorrecebido_Z_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalorrecebido_Z = 0;
         SetDirty("Carteiradecobrancavalorrecebido_Z");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalorrecebido_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaTotalBoletos_Z" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaTotalBoletos_Z"   )]
      public int gxTpr_Carteiradecobrancatotalboletos_Z
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletos_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletos_Z = value;
            SetDirty("Carteiradecobrancatotalboletos_Z");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletos_Z_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletos_Z = 0;
         SetDirty("Carteiradecobrancatotalboletos_Z");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletos_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaTotalBoletosRegistrados_Z" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaTotalBoletosRegistrados_Z"   )]
      public int gxTpr_Carteiradecobrancatotalboletosregistrados_Z
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosregistrados_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosregistrados_Z = value;
            SetDirty("Carteiradecobrancatotalboletosregistrados_Z");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosregistrados_Z_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosregistrados_Z = 0;
         SetDirty("Carteiradecobrancatotalboletosregistrados_Z");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosregistrados_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaTotalBoletosExpirados_Z" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaTotalBoletosExpirados_Z"   )]
      public int gxTpr_Carteiradecobrancatotalboletosexpirados_Z
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosexpirados_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosexpirados_Z = value;
            SetDirty("Carteiradecobrancatotalboletosexpirados_Z");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosexpirados_Z_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosexpirados_Z = 0;
         SetDirty("Carteiradecobrancatotalboletosexpirados_Z");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosexpirados_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaTotalBoletosCancelados_Z" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaTotalBoletosCancelados_Z"   )]
      public int gxTpr_Carteiradecobrancatotalboletoscancelados_Z
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletoscancelados_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletoscancelados_Z = value;
            SetDirty("Carteiradecobrancatotalboletoscancelados_Z");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletoscancelados_Z_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletoscancelados_Z = 0;
         SetDirty("Carteiradecobrancatotalboletoscancelados_Z");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletoscancelados_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaId_N" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaId_N"   )]
      public short gxTpr_Carteiradecobrancaid_N
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaid_N = value;
            SetDirty("Carteiradecobrancaid_N");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaid_N_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaid_N = 0;
         SetDirty("Carteiradecobrancaid_N");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaCodigo_N" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaCodigo_N"   )]
      public short gxTpr_Carteiradecobrancacodigo_N
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo_N = value;
            SetDirty("Carteiradecobrancacodigo_N");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo_N_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo_N = 0;
         SetDirty("Carteiradecobrancacodigo_N");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaNome_N" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaNome_N"   )]
      public short gxTpr_Carteiradecobrancanome_N
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome_N = value;
            SetDirty("Carteiradecobrancanome_N");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome_N_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome_N = 0;
         SetDirty("Carteiradecobrancanome_N");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaWorkspaceId_N" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaWorkspaceId_N"   )]
      public short gxTpr_Carteiradecobrancaworkspaceid_N
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid_N = value;
            SetDirty("Carteiradecobrancaworkspaceid_N");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid_N_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid_N = 0;
         SetDirty("Carteiradecobrancaworkspaceid_N");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaConvenio_N" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaConvenio_N"   )]
      public short gxTpr_Carteiradecobrancaconvenio_N
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio_N = value;
            SetDirty("Carteiradecobrancaconvenio_N");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio_N_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio_N = 0;
         SetDirty("Carteiradecobrancaconvenio_N");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaStatus_N" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaStatus_N"   )]
      public short gxTpr_Carteiradecobrancastatus_N
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancastatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancastatus_N = value;
            SetDirty("Carteiradecobrancastatus_N");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancastatus_N_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancastatus_N = 0;
         SetDirty("Carteiradecobrancastatus_N");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancastatus_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaCreatedAt_N" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaCreatedAt_N"   )]
      public short gxTpr_Carteiradecobrancacreatedat_N
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat_N = value;
            SetDirty("Carteiradecobrancacreatedat_N");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat_N_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat_N = 0;
         SetDirty("Carteiradecobrancacreatedat_N");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaUpdatedAt_N" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaUpdatedAt_N"   )]
      public short gxTpr_Carteiradecobrancaupdatedat_N
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat_N = value;
            SetDirty("Carteiradecobrancaupdatedat_N");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat_N_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat_N = 0;
         SetDirty("Carteiradecobrancaupdatedat_N");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaTotalBoletosRegistrados_N" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaTotalBoletosRegistrados_N"   )]
      public short gxTpr_Carteiradecobrancatotalboletosregistrados_N
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosregistrados_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosregistrados_N = value;
            SetDirty("Carteiradecobrancatotalboletosregistrados_N");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosregistrados_N_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosregistrados_N = 0;
         SetDirty("Carteiradecobrancatotalboletosregistrados_N");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosregistrados_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaTotalBoletosExpirados_N" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaTotalBoletosExpirados_N"   )]
      public short gxTpr_Carteiradecobrancatotalboletosexpirados_N
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosexpirados_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosexpirados_N = value;
            SetDirty("Carteiradecobrancatotalboletosexpirados_N");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosexpirados_N_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosexpirados_N = 0;
         SetDirty("Carteiradecobrancatotalboletosexpirados_N");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosexpirados_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarteiraDeCobrancaTotalBoletosCancelados_N" )]
      [  XmlElement( ElementName = "CarteiraDeCobrancaTotalBoletosCancelados_N"   )]
      public short gxTpr_Carteiradecobrancatotalboletoscancelados_N
      {
         get {
            return gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletoscancelados_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletoscancelados_N = value;
            SetDirty("Carteiradecobrancatotalboletoscancelados_N");
         }

      }

      public void gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletoscancelados_N_SetNull( )
      {
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletoscancelados_N = 0;
         SetDirty("Carteiradecobrancatotalboletoscancelados_N");
         return  ;
      }

      public bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletoscancelados_N_IsNull( )
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
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo = "";
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome = "";
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid = Guid.Empty;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio = "";
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtCarteiraDeCobranca_Mode = "";
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo_Z = "";
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome_Z = "";
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid_Z = Guid.Empty;
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio_Z = "";
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat_Z = (DateTime)(DateTime.MinValue);
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "carteiradecobranca", "GeneXus.Programs.carteiradecobranca_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtCarteiraDeCobranca_Initialized ;
      private short gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaid_N ;
      private short gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo_N ;
      private short gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome_N ;
      private short gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid_N ;
      private short gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio_N ;
      private short gxTv_SdtCarteiraDeCobranca_Carteiradecobrancastatus_N ;
      private short gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat_N ;
      private short gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat_N ;
      private short gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosregistrados_N ;
      private short gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosexpirados_N ;
      private short gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletoscancelados_N ;
      private int gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaid ;
      private int gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletos ;
      private int gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosregistrados ;
      private int gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosexpirados ;
      private int gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletoscancelados ;
      private int gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaid_Z ;
      private int gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletos_Z ;
      private int gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosregistrados_Z ;
      private int gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletosexpirados_Z ;
      private int gxTv_SdtCarteiraDeCobranca_Carteiradecobrancatotalboletoscancelados_Z ;
      private decimal gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalortotal ;
      private decimal gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalorrecebido ;
      private decimal gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalortotal_Z ;
      private decimal gxTv_SdtCarteiraDeCobranca_Carteiradecobrancavalorrecebido_Z ;
      private string gxTv_SdtCarteiraDeCobranca_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat ;
      private DateTime gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat ;
      private DateTime gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacreatedat_Z ;
      private DateTime gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaupdatedat_Z ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancastatus ;
      private bool gxTv_SdtCarteiraDeCobranca_Carteiradecobrancastatus_Z ;
      private string gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo ;
      private string gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome ;
      private string gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio ;
      private string gxTv_SdtCarteiraDeCobranca_Carteiradecobrancacodigo_Z ;
      private string gxTv_SdtCarteiraDeCobranca_Carteiradecobrancanome_Z ;
      private string gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaconvenio_Z ;
      private Guid gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid ;
      private Guid gxTv_SdtCarteiraDeCobranca_Carteiradecobrancaworkspaceid_Z ;
   }

   [DataContract(Name = @"CarteiraDeCobranca", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtCarteiraDeCobranca_RESTInterface : GxGenericCollectionItem<SdtCarteiraDeCobranca>
   {
      public SdtCarteiraDeCobranca_RESTInterface( ) : base()
      {
      }

      public SdtCarteiraDeCobranca_RESTInterface( SdtCarteiraDeCobranca psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CarteiraDeCobrancaId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Carteiradecobrancaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Carteiradecobrancaid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Carteiradecobrancaid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "CarteiraDeCobrancaCodigo" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Carteiradecobrancacodigo
      {
         get {
            return sdt.gxTpr_Carteiradecobrancacodigo ;
         }

         set {
            sdt.gxTpr_Carteiradecobrancacodigo = value;
         }

      }

      [DataMember( Name = "CarteiraDeCobrancaNome" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Carteiradecobrancanome
      {
         get {
            return sdt.gxTpr_Carteiradecobrancanome ;
         }

         set {
            sdt.gxTpr_Carteiradecobrancanome = value;
         }

      }

      [DataMember( Name = "CarteiraDeCobrancaWorkspaceId" , Order = 3 )]
      [GxSeudo()]
      public Guid gxTpr_Carteiradecobrancaworkspaceid
      {
         get {
            return sdt.gxTpr_Carteiradecobrancaworkspaceid ;
         }

         set {
            sdt.gxTpr_Carteiradecobrancaworkspaceid = value;
         }

      }

      [DataMember( Name = "CarteiraDeCobrancaConvenio" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Carteiradecobrancaconvenio
      {
         get {
            return sdt.gxTpr_Carteiradecobrancaconvenio ;
         }

         set {
            sdt.gxTpr_Carteiradecobrancaconvenio = value;
         }

      }

      [DataMember( Name = "CarteiraDeCobrancaStatus" , Order = 5 )]
      [GxSeudo()]
      public bool gxTpr_Carteiradecobrancastatus
      {
         get {
            return sdt.gxTpr_Carteiradecobrancastatus ;
         }

         set {
            sdt.gxTpr_Carteiradecobrancastatus = value;
         }

      }

      [DataMember( Name = "CarteiraDeCobrancaCreatedAt" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Carteiradecobrancacreatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Carteiradecobrancacreatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Carteiradecobrancacreatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "CarteiraDeCobrancaUpdatedAt" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Carteiradecobrancaupdatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Carteiradecobrancaupdatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Carteiradecobrancaupdatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "CarteiraDeCobrancaValorTotal" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Carteiradecobrancavalortotal
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Carteiradecobrancavalortotal, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Carteiradecobrancavalortotal = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "CarteiraDeCobrancaValorRecebido" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Carteiradecobrancavalorrecebido
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Carteiradecobrancavalorrecebido, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Carteiradecobrancavalorrecebido = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "CarteiraDeCobrancaTotalBoletos" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Carteiradecobrancatotalboletos
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Carteiradecobrancatotalboletos), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Carteiradecobrancatotalboletos = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "CarteiraDeCobrancaTotalBoletosRegistrados" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Carteiradecobrancatotalboletosregistrados
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Carteiradecobrancatotalboletosregistrados), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Carteiradecobrancatotalboletosregistrados = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "CarteiraDeCobrancaTotalBoletosExpirados" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Carteiradecobrancatotalboletosexpirados
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Carteiradecobrancatotalboletosexpirados), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Carteiradecobrancatotalboletosexpirados = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "CarteiraDeCobrancaTotalBoletosCancelados" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Carteiradecobrancatotalboletoscancelados
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Carteiradecobrancatotalboletoscancelados), 8, 0)) ;
         }

         set {
            sdt.gxTpr_Carteiradecobrancatotalboletoscancelados = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      public SdtCarteiraDeCobranca sdt
      {
         get {
            return (SdtCarteiraDeCobranca)Sdt ;
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
            sdt = new SdtCarteiraDeCobranca() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 14 )]
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

   [DataContract(Name = @"CarteiraDeCobranca", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtCarteiraDeCobranca_RESTLInterface : GxGenericCollectionItem<SdtCarteiraDeCobranca>
   {
      public SdtCarteiraDeCobranca_RESTLInterface( ) : base()
      {
      }

      public SdtCarteiraDeCobranca_RESTLInterface( SdtCarteiraDeCobranca psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CarteiraDeCobrancaCodigo" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Carteiradecobrancacodigo
      {
         get {
            return sdt.gxTpr_Carteiradecobrancacodigo ;
         }

         set {
            sdt.gxTpr_Carteiradecobrancacodigo = value;
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

      public SdtCarteiraDeCobranca sdt
      {
         get {
            return (SdtCarteiraDeCobranca)Sdt ;
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
            sdt = new SdtCarteiraDeCobranca() ;
         }
      }

   }

}
