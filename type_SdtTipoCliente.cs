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
   [XmlRoot(ElementName = "TipoCliente" )]
   [XmlType(TypeName =  "TipoCliente" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtTipoCliente : GxSilentTrnSdt
   {
      public SdtTipoCliente( )
      {
      }

      public SdtTipoCliente( IGxContext context )
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

      public void Load( short AV192TipoClienteId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV192TipoClienteId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"TipoClienteId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "TipoCliente");
         metadata.Set("BT", "TipoCliente");
         metadata.Set("PK", "[ \"TipoClienteId\" ]");
         metadata.Set("PKAssigned", "[ \"TipoClienteId\" ]");
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
         state.Add("gxTpr_Tipoclienteid_Z");
         state.Add("gxTpr_Tipoclientedescricao_Z");
         state.Add("gxTpr_Tipoclientetipopessoa_Z");
         state.Add("gxTpr_Tipoclienteportal_Z");
         state.Add("gxTpr_Tipoclienteportalpjpf_Z");
         state.Add("gxTpr_Tipoclientefinancia_Z");
         state.Add("gxTpr_Tipoclientecreatedat_Z_Nullable");
         state.Add("gxTpr_Tipoclienteupdateat_Z_Nullable");
         state.Add("gxTpr_Tipoclienteid_N");
         state.Add("gxTpr_Tipoclientedescricao_N");
         state.Add("gxTpr_Tipoclientetipopessoa_N");
         state.Add("gxTpr_Tipoclienteportal_N");
         state.Add("gxTpr_Tipoclienteportalpjpf_N");
         state.Add("gxTpr_Tipoclientefinancia_N");
         state.Add("gxTpr_Tipoclientecreatedat_N");
         state.Add("gxTpr_Tipoclienteupdateat_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTipoCliente sdt;
         sdt = (SdtTipoCliente)(source);
         gxTv_SdtTipoCliente_Tipoclienteid = sdt.gxTv_SdtTipoCliente_Tipoclienteid ;
         gxTv_SdtTipoCliente_Tipoclientedescricao = sdt.gxTv_SdtTipoCliente_Tipoclientedescricao ;
         gxTv_SdtTipoCliente_Tipoclientetipopessoa = sdt.gxTv_SdtTipoCliente_Tipoclientetipopessoa ;
         gxTv_SdtTipoCliente_Tipoclienteportal = sdt.gxTv_SdtTipoCliente_Tipoclienteportal ;
         gxTv_SdtTipoCliente_Tipoclienteportalpjpf = sdt.gxTv_SdtTipoCliente_Tipoclienteportalpjpf ;
         gxTv_SdtTipoCliente_Tipoclientefinancia = sdt.gxTv_SdtTipoCliente_Tipoclientefinancia ;
         gxTv_SdtTipoCliente_Tipoclientecreatedat = sdt.gxTv_SdtTipoCliente_Tipoclientecreatedat ;
         gxTv_SdtTipoCliente_Tipoclienteupdateat = sdt.gxTv_SdtTipoCliente_Tipoclienteupdateat ;
         gxTv_SdtTipoCliente_Mode = sdt.gxTv_SdtTipoCliente_Mode ;
         gxTv_SdtTipoCliente_Initialized = sdt.gxTv_SdtTipoCliente_Initialized ;
         gxTv_SdtTipoCliente_Tipoclienteid_Z = sdt.gxTv_SdtTipoCliente_Tipoclienteid_Z ;
         gxTv_SdtTipoCliente_Tipoclientedescricao_Z = sdt.gxTv_SdtTipoCliente_Tipoclientedescricao_Z ;
         gxTv_SdtTipoCliente_Tipoclientetipopessoa_Z = sdt.gxTv_SdtTipoCliente_Tipoclientetipopessoa_Z ;
         gxTv_SdtTipoCliente_Tipoclienteportal_Z = sdt.gxTv_SdtTipoCliente_Tipoclienteportal_Z ;
         gxTv_SdtTipoCliente_Tipoclienteportalpjpf_Z = sdt.gxTv_SdtTipoCliente_Tipoclienteportalpjpf_Z ;
         gxTv_SdtTipoCliente_Tipoclientefinancia_Z = sdt.gxTv_SdtTipoCliente_Tipoclientefinancia_Z ;
         gxTv_SdtTipoCliente_Tipoclientecreatedat_Z = sdt.gxTv_SdtTipoCliente_Tipoclientecreatedat_Z ;
         gxTv_SdtTipoCliente_Tipoclienteupdateat_Z = sdt.gxTv_SdtTipoCliente_Tipoclienteupdateat_Z ;
         gxTv_SdtTipoCliente_Tipoclienteid_N = sdt.gxTv_SdtTipoCliente_Tipoclienteid_N ;
         gxTv_SdtTipoCliente_Tipoclientedescricao_N = sdt.gxTv_SdtTipoCliente_Tipoclientedescricao_N ;
         gxTv_SdtTipoCliente_Tipoclientetipopessoa_N = sdt.gxTv_SdtTipoCliente_Tipoclientetipopessoa_N ;
         gxTv_SdtTipoCliente_Tipoclienteportal_N = sdt.gxTv_SdtTipoCliente_Tipoclienteportal_N ;
         gxTv_SdtTipoCliente_Tipoclienteportalpjpf_N = sdt.gxTv_SdtTipoCliente_Tipoclienteportalpjpf_N ;
         gxTv_SdtTipoCliente_Tipoclientefinancia_N = sdt.gxTv_SdtTipoCliente_Tipoclientefinancia_N ;
         gxTv_SdtTipoCliente_Tipoclientecreatedat_N = sdt.gxTv_SdtTipoCliente_Tipoclientecreatedat_N ;
         gxTv_SdtTipoCliente_Tipoclienteupdateat_N = sdt.gxTv_SdtTipoCliente_Tipoclienteupdateat_N ;
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
         AddObjectProperty("TipoClienteId", gxTv_SdtTipoCliente_Tipoclienteid, false, includeNonInitialized);
         AddObjectProperty("TipoClienteId_N", gxTv_SdtTipoCliente_Tipoclienteid_N, false, includeNonInitialized);
         AddObjectProperty("TipoClienteDescricao", gxTv_SdtTipoCliente_Tipoclientedescricao, false, includeNonInitialized);
         AddObjectProperty("TipoClienteDescricao_N", gxTv_SdtTipoCliente_Tipoclientedescricao_N, false, includeNonInitialized);
         AddObjectProperty("TipoClienteTipoPessoa", gxTv_SdtTipoCliente_Tipoclientetipopessoa, false, includeNonInitialized);
         AddObjectProperty("TipoClienteTipoPessoa_N", gxTv_SdtTipoCliente_Tipoclientetipopessoa_N, false, includeNonInitialized);
         AddObjectProperty("TipoClientePortal", gxTv_SdtTipoCliente_Tipoclienteportal, false, includeNonInitialized);
         AddObjectProperty("TipoClientePortal_N", gxTv_SdtTipoCliente_Tipoclienteportal_N, false, includeNonInitialized);
         AddObjectProperty("TipoClientePortalPjPf", gxTv_SdtTipoCliente_Tipoclienteportalpjpf, false, includeNonInitialized);
         AddObjectProperty("TipoClientePortalPjPf_N", gxTv_SdtTipoCliente_Tipoclienteportalpjpf_N, false, includeNonInitialized);
         AddObjectProperty("TipoClienteFinancia", gxTv_SdtTipoCliente_Tipoclientefinancia, false, includeNonInitialized);
         AddObjectProperty("TipoClienteFinancia_N", gxTv_SdtTipoCliente_Tipoclientefinancia_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtTipoCliente_Tipoclientecreatedat;
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
         AddObjectProperty("TipoClienteCreatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("TipoClienteCreatedAt_N", gxTv_SdtTipoCliente_Tipoclientecreatedat_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtTipoCliente_Tipoclienteupdateat;
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
         AddObjectProperty("TipoClienteUpdateAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("TipoClienteUpdateAt_N", gxTv_SdtTipoCliente_Tipoclienteupdateat_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTipoCliente_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTipoCliente_Initialized, false, includeNonInitialized);
            AddObjectProperty("TipoClienteId_Z", gxTv_SdtTipoCliente_Tipoclienteid_Z, false, includeNonInitialized);
            AddObjectProperty("TipoClienteDescricao_Z", gxTv_SdtTipoCliente_Tipoclientedescricao_Z, false, includeNonInitialized);
            AddObjectProperty("TipoClienteTipoPessoa_Z", gxTv_SdtTipoCliente_Tipoclientetipopessoa_Z, false, includeNonInitialized);
            AddObjectProperty("TipoClientePortal_Z", gxTv_SdtTipoCliente_Tipoclienteportal_Z, false, includeNonInitialized);
            AddObjectProperty("TipoClientePortalPjPf_Z", gxTv_SdtTipoCliente_Tipoclienteportalpjpf_Z, false, includeNonInitialized);
            AddObjectProperty("TipoClienteFinancia_Z", gxTv_SdtTipoCliente_Tipoclientefinancia_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtTipoCliente_Tipoclientecreatedat_Z;
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
            AddObjectProperty("TipoClienteCreatedAt_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtTipoCliente_Tipoclienteupdateat_Z;
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
            AddObjectProperty("TipoClienteUpdateAt_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("TipoClienteId_N", gxTv_SdtTipoCliente_Tipoclienteid_N, false, includeNonInitialized);
            AddObjectProperty("TipoClienteDescricao_N", gxTv_SdtTipoCliente_Tipoclientedescricao_N, false, includeNonInitialized);
            AddObjectProperty("TipoClienteTipoPessoa_N", gxTv_SdtTipoCliente_Tipoclientetipopessoa_N, false, includeNonInitialized);
            AddObjectProperty("TipoClientePortal_N", gxTv_SdtTipoCliente_Tipoclienteportal_N, false, includeNonInitialized);
            AddObjectProperty("TipoClientePortalPjPf_N", gxTv_SdtTipoCliente_Tipoclienteportalpjpf_N, false, includeNonInitialized);
            AddObjectProperty("TipoClienteFinancia_N", gxTv_SdtTipoCliente_Tipoclientefinancia_N, false, includeNonInitialized);
            AddObjectProperty("TipoClienteCreatedAt_N", gxTv_SdtTipoCliente_Tipoclientecreatedat_N, false, includeNonInitialized);
            AddObjectProperty("TipoClienteUpdateAt_N", gxTv_SdtTipoCliente_Tipoclienteupdateat_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTipoCliente sdt )
      {
         if ( sdt.IsDirty("TipoClienteId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTipoCliente_Tipoclienteid = sdt.gxTv_SdtTipoCliente_Tipoclienteid ;
         }
         if ( sdt.IsDirty("TipoClienteDescricao") )
         {
            gxTv_SdtTipoCliente_Tipoclientedescricao_N = (short)(sdt.gxTv_SdtTipoCliente_Tipoclientedescricao_N);
            sdtIsNull = 0;
            gxTv_SdtTipoCliente_Tipoclientedescricao = sdt.gxTv_SdtTipoCliente_Tipoclientedescricao ;
         }
         if ( sdt.IsDirty("TipoClienteTipoPessoa") )
         {
            gxTv_SdtTipoCliente_Tipoclientetipopessoa_N = (short)(sdt.gxTv_SdtTipoCliente_Tipoclientetipopessoa_N);
            sdtIsNull = 0;
            gxTv_SdtTipoCliente_Tipoclientetipopessoa = sdt.gxTv_SdtTipoCliente_Tipoclientetipopessoa ;
         }
         if ( sdt.IsDirty("TipoClientePortal") )
         {
            gxTv_SdtTipoCliente_Tipoclienteportal_N = (short)(sdt.gxTv_SdtTipoCliente_Tipoclienteportal_N);
            sdtIsNull = 0;
            gxTv_SdtTipoCliente_Tipoclienteportal = sdt.gxTv_SdtTipoCliente_Tipoclienteportal ;
         }
         if ( sdt.IsDirty("TipoClientePortalPjPf") )
         {
            gxTv_SdtTipoCliente_Tipoclienteportalpjpf_N = (short)(sdt.gxTv_SdtTipoCliente_Tipoclienteportalpjpf_N);
            sdtIsNull = 0;
            gxTv_SdtTipoCliente_Tipoclienteportalpjpf = sdt.gxTv_SdtTipoCliente_Tipoclienteportalpjpf ;
         }
         if ( sdt.IsDirty("TipoClienteFinancia") )
         {
            gxTv_SdtTipoCliente_Tipoclientefinancia_N = (short)(sdt.gxTv_SdtTipoCliente_Tipoclientefinancia_N);
            sdtIsNull = 0;
            gxTv_SdtTipoCliente_Tipoclientefinancia = sdt.gxTv_SdtTipoCliente_Tipoclientefinancia ;
         }
         if ( sdt.IsDirty("TipoClienteCreatedAt") )
         {
            gxTv_SdtTipoCliente_Tipoclientecreatedat_N = (short)(sdt.gxTv_SdtTipoCliente_Tipoclientecreatedat_N);
            sdtIsNull = 0;
            gxTv_SdtTipoCliente_Tipoclientecreatedat = sdt.gxTv_SdtTipoCliente_Tipoclientecreatedat ;
         }
         if ( sdt.IsDirty("TipoClienteUpdateAt") )
         {
            gxTv_SdtTipoCliente_Tipoclienteupdateat_N = (short)(sdt.gxTv_SdtTipoCliente_Tipoclienteupdateat_N);
            sdtIsNull = 0;
            gxTv_SdtTipoCliente_Tipoclienteupdateat = sdt.gxTv_SdtTipoCliente_Tipoclienteupdateat ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "TipoClienteId" )]
      [  XmlElement( ElementName = "TipoClienteId"   )]
      public short gxTpr_Tipoclienteid
      {
         get {
            return gxTv_SdtTipoCliente_Tipoclienteid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTipoCliente_Tipoclienteid != value )
            {
               gxTv_SdtTipoCliente_Mode = "INS";
               this.gxTv_SdtTipoCliente_Tipoclienteid_Z_SetNull( );
               this.gxTv_SdtTipoCliente_Tipoclientedescricao_Z_SetNull( );
               this.gxTv_SdtTipoCliente_Tipoclientetipopessoa_Z_SetNull( );
               this.gxTv_SdtTipoCliente_Tipoclienteportal_Z_SetNull( );
               this.gxTv_SdtTipoCliente_Tipoclienteportalpjpf_Z_SetNull( );
               this.gxTv_SdtTipoCliente_Tipoclientefinancia_Z_SetNull( );
               this.gxTv_SdtTipoCliente_Tipoclientecreatedat_Z_SetNull( );
               this.gxTv_SdtTipoCliente_Tipoclienteupdateat_Z_SetNull( );
            }
            gxTv_SdtTipoCliente_Tipoclienteid = value;
            SetDirty("Tipoclienteid");
         }

      }

      [  SoapElement( ElementName = "TipoClienteDescricao" )]
      [  XmlElement( ElementName = "TipoClienteDescricao"   )]
      public string gxTpr_Tipoclientedescricao
      {
         get {
            return gxTv_SdtTipoCliente_Tipoclientedescricao ;
         }

         set {
            gxTv_SdtTipoCliente_Tipoclientedescricao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTipoCliente_Tipoclientedescricao = value;
            SetDirty("Tipoclientedescricao");
         }

      }

      public void gxTv_SdtTipoCliente_Tipoclientedescricao_SetNull( )
      {
         gxTv_SdtTipoCliente_Tipoclientedescricao_N = 1;
         gxTv_SdtTipoCliente_Tipoclientedescricao = "";
         SetDirty("Tipoclientedescricao");
         return  ;
      }

      public bool gxTv_SdtTipoCliente_Tipoclientedescricao_IsNull( )
      {
         return (gxTv_SdtTipoCliente_Tipoclientedescricao_N==1) ;
      }

      [  SoapElement( ElementName = "TipoClienteTipoPessoa" )]
      [  XmlElement( ElementName = "TipoClienteTipoPessoa"   )]
      public string gxTpr_Tipoclientetipopessoa
      {
         get {
            return gxTv_SdtTipoCliente_Tipoclientetipopessoa ;
         }

         set {
            gxTv_SdtTipoCliente_Tipoclientetipopessoa_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTipoCliente_Tipoclientetipopessoa = value;
            SetDirty("Tipoclientetipopessoa");
         }

      }

      public void gxTv_SdtTipoCliente_Tipoclientetipopessoa_SetNull( )
      {
         gxTv_SdtTipoCliente_Tipoclientetipopessoa_N = 1;
         gxTv_SdtTipoCliente_Tipoclientetipopessoa = "";
         SetDirty("Tipoclientetipopessoa");
         return  ;
      }

      public bool gxTv_SdtTipoCliente_Tipoclientetipopessoa_IsNull( )
      {
         return (gxTv_SdtTipoCliente_Tipoclientetipopessoa_N==1) ;
      }

      [  SoapElement( ElementName = "TipoClientePortal" )]
      [  XmlElement( ElementName = "TipoClientePortal"   )]
      public bool gxTpr_Tipoclienteportal
      {
         get {
            return gxTv_SdtTipoCliente_Tipoclienteportal ;
         }

         set {
            gxTv_SdtTipoCliente_Tipoclienteportal_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTipoCliente_Tipoclienteportal = value;
            SetDirty("Tipoclienteportal");
         }

      }

      public void gxTv_SdtTipoCliente_Tipoclienteportal_SetNull( )
      {
         gxTv_SdtTipoCliente_Tipoclienteportal_N = 1;
         gxTv_SdtTipoCliente_Tipoclienteportal = false;
         SetDirty("Tipoclienteportal");
         return  ;
      }

      public bool gxTv_SdtTipoCliente_Tipoclienteportal_IsNull( )
      {
         return (gxTv_SdtTipoCliente_Tipoclienteportal_N==1) ;
      }

      [  SoapElement( ElementName = "TipoClientePortalPjPf" )]
      [  XmlElement( ElementName = "TipoClientePortalPjPf"   )]
      public bool gxTpr_Tipoclienteportalpjpf
      {
         get {
            return gxTv_SdtTipoCliente_Tipoclienteportalpjpf ;
         }

         set {
            gxTv_SdtTipoCliente_Tipoclienteportalpjpf_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTipoCliente_Tipoclienteportalpjpf = value;
            SetDirty("Tipoclienteportalpjpf");
         }

      }

      public void gxTv_SdtTipoCliente_Tipoclienteportalpjpf_SetNull( )
      {
         gxTv_SdtTipoCliente_Tipoclienteportalpjpf_N = 1;
         gxTv_SdtTipoCliente_Tipoclienteportalpjpf = false;
         SetDirty("Tipoclienteportalpjpf");
         return  ;
      }

      public bool gxTv_SdtTipoCliente_Tipoclienteportalpjpf_IsNull( )
      {
         return (gxTv_SdtTipoCliente_Tipoclienteportalpjpf_N==1) ;
      }

      [  SoapElement( ElementName = "TipoClienteFinancia" )]
      [  XmlElement( ElementName = "TipoClienteFinancia"   )]
      public bool gxTpr_Tipoclientefinancia
      {
         get {
            return gxTv_SdtTipoCliente_Tipoclientefinancia ;
         }

         set {
            gxTv_SdtTipoCliente_Tipoclientefinancia_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTipoCliente_Tipoclientefinancia = value;
            SetDirty("Tipoclientefinancia");
         }

      }

      public void gxTv_SdtTipoCliente_Tipoclientefinancia_SetNull( )
      {
         gxTv_SdtTipoCliente_Tipoclientefinancia_N = 1;
         gxTv_SdtTipoCliente_Tipoclientefinancia = false;
         SetDirty("Tipoclientefinancia");
         return  ;
      }

      public bool gxTv_SdtTipoCliente_Tipoclientefinancia_IsNull( )
      {
         return (gxTv_SdtTipoCliente_Tipoclientefinancia_N==1) ;
      }

      [  SoapElement( ElementName = "TipoClienteCreatedAt" )]
      [  XmlElement( ElementName = "TipoClienteCreatedAt"  , IsNullable=true )]
      public string gxTpr_Tipoclientecreatedat_Nullable
      {
         get {
            if ( gxTv_SdtTipoCliente_Tipoclientecreatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTipoCliente_Tipoclientecreatedat).value ;
         }

         set {
            gxTv_SdtTipoCliente_Tipoclientecreatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTipoCliente_Tipoclientecreatedat = DateTime.MinValue;
            else
               gxTv_SdtTipoCliente_Tipoclientecreatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Tipoclientecreatedat
      {
         get {
            return gxTv_SdtTipoCliente_Tipoclientecreatedat ;
         }

         set {
            gxTv_SdtTipoCliente_Tipoclientecreatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTipoCliente_Tipoclientecreatedat = value;
            SetDirty("Tipoclientecreatedat");
         }

      }

      public void gxTv_SdtTipoCliente_Tipoclientecreatedat_SetNull( )
      {
         gxTv_SdtTipoCliente_Tipoclientecreatedat_N = 1;
         gxTv_SdtTipoCliente_Tipoclientecreatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Tipoclientecreatedat");
         return  ;
      }

      public bool gxTv_SdtTipoCliente_Tipoclientecreatedat_IsNull( )
      {
         return (gxTv_SdtTipoCliente_Tipoclientecreatedat_N==1) ;
      }

      [  SoapElement( ElementName = "TipoClienteUpdateAt" )]
      [  XmlElement( ElementName = "TipoClienteUpdateAt"  , IsNullable=true )]
      public string gxTpr_Tipoclienteupdateat_Nullable
      {
         get {
            if ( gxTv_SdtTipoCliente_Tipoclienteupdateat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTipoCliente_Tipoclienteupdateat).value ;
         }

         set {
            gxTv_SdtTipoCliente_Tipoclienteupdateat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTipoCliente_Tipoclienteupdateat = DateTime.MinValue;
            else
               gxTv_SdtTipoCliente_Tipoclienteupdateat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Tipoclienteupdateat
      {
         get {
            return gxTv_SdtTipoCliente_Tipoclienteupdateat ;
         }

         set {
            gxTv_SdtTipoCliente_Tipoclienteupdateat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTipoCliente_Tipoclienteupdateat = value;
            SetDirty("Tipoclienteupdateat");
         }

      }

      public void gxTv_SdtTipoCliente_Tipoclienteupdateat_SetNull( )
      {
         gxTv_SdtTipoCliente_Tipoclienteupdateat_N = 1;
         gxTv_SdtTipoCliente_Tipoclienteupdateat = (DateTime)(DateTime.MinValue);
         SetDirty("Tipoclienteupdateat");
         return  ;
      }

      public bool gxTv_SdtTipoCliente_Tipoclienteupdateat_IsNull( )
      {
         return (gxTv_SdtTipoCliente_Tipoclienteupdateat_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTipoCliente_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTipoCliente_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTipoCliente_Mode_SetNull( )
      {
         gxTv_SdtTipoCliente_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTipoCliente_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTipoCliente_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTipoCliente_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTipoCliente_Initialized_SetNull( )
      {
         gxTv_SdtTipoCliente_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTipoCliente_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoClienteId_Z" )]
      [  XmlElement( ElementName = "TipoClienteId_Z"   )]
      public short gxTpr_Tipoclienteid_Z
      {
         get {
            return gxTv_SdtTipoCliente_Tipoclienteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTipoCliente_Tipoclienteid_Z = value;
            SetDirty("Tipoclienteid_Z");
         }

      }

      public void gxTv_SdtTipoCliente_Tipoclienteid_Z_SetNull( )
      {
         gxTv_SdtTipoCliente_Tipoclienteid_Z = 0;
         SetDirty("Tipoclienteid_Z");
         return  ;
      }

      public bool gxTv_SdtTipoCliente_Tipoclienteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoClienteDescricao_Z" )]
      [  XmlElement( ElementName = "TipoClienteDescricao_Z"   )]
      public string gxTpr_Tipoclientedescricao_Z
      {
         get {
            return gxTv_SdtTipoCliente_Tipoclientedescricao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTipoCliente_Tipoclientedescricao_Z = value;
            SetDirty("Tipoclientedescricao_Z");
         }

      }

      public void gxTv_SdtTipoCliente_Tipoclientedescricao_Z_SetNull( )
      {
         gxTv_SdtTipoCliente_Tipoclientedescricao_Z = "";
         SetDirty("Tipoclientedescricao_Z");
         return  ;
      }

      public bool gxTv_SdtTipoCliente_Tipoclientedescricao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoClienteTipoPessoa_Z" )]
      [  XmlElement( ElementName = "TipoClienteTipoPessoa_Z"   )]
      public string gxTpr_Tipoclientetipopessoa_Z
      {
         get {
            return gxTv_SdtTipoCliente_Tipoclientetipopessoa_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTipoCliente_Tipoclientetipopessoa_Z = value;
            SetDirty("Tipoclientetipopessoa_Z");
         }

      }

      public void gxTv_SdtTipoCliente_Tipoclientetipopessoa_Z_SetNull( )
      {
         gxTv_SdtTipoCliente_Tipoclientetipopessoa_Z = "";
         SetDirty("Tipoclientetipopessoa_Z");
         return  ;
      }

      public bool gxTv_SdtTipoCliente_Tipoclientetipopessoa_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoClientePortal_Z" )]
      [  XmlElement( ElementName = "TipoClientePortal_Z"   )]
      public bool gxTpr_Tipoclienteportal_Z
      {
         get {
            return gxTv_SdtTipoCliente_Tipoclienteportal_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTipoCliente_Tipoclienteportal_Z = value;
            SetDirty("Tipoclienteportal_Z");
         }

      }

      public void gxTv_SdtTipoCliente_Tipoclienteportal_Z_SetNull( )
      {
         gxTv_SdtTipoCliente_Tipoclienteportal_Z = false;
         SetDirty("Tipoclienteportal_Z");
         return  ;
      }

      public bool gxTv_SdtTipoCliente_Tipoclienteportal_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoClientePortalPjPf_Z" )]
      [  XmlElement( ElementName = "TipoClientePortalPjPf_Z"   )]
      public bool gxTpr_Tipoclienteportalpjpf_Z
      {
         get {
            return gxTv_SdtTipoCliente_Tipoclienteportalpjpf_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTipoCliente_Tipoclienteportalpjpf_Z = value;
            SetDirty("Tipoclienteportalpjpf_Z");
         }

      }

      public void gxTv_SdtTipoCliente_Tipoclienteportalpjpf_Z_SetNull( )
      {
         gxTv_SdtTipoCliente_Tipoclienteportalpjpf_Z = false;
         SetDirty("Tipoclienteportalpjpf_Z");
         return  ;
      }

      public bool gxTv_SdtTipoCliente_Tipoclienteportalpjpf_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoClienteFinancia_Z" )]
      [  XmlElement( ElementName = "TipoClienteFinancia_Z"   )]
      public bool gxTpr_Tipoclientefinancia_Z
      {
         get {
            return gxTv_SdtTipoCliente_Tipoclientefinancia_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTipoCliente_Tipoclientefinancia_Z = value;
            SetDirty("Tipoclientefinancia_Z");
         }

      }

      public void gxTv_SdtTipoCliente_Tipoclientefinancia_Z_SetNull( )
      {
         gxTv_SdtTipoCliente_Tipoclientefinancia_Z = false;
         SetDirty("Tipoclientefinancia_Z");
         return  ;
      }

      public bool gxTv_SdtTipoCliente_Tipoclientefinancia_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoClienteCreatedAt_Z" )]
      [  XmlElement( ElementName = "TipoClienteCreatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Tipoclientecreatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtTipoCliente_Tipoclientecreatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTipoCliente_Tipoclientecreatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTipoCliente_Tipoclientecreatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtTipoCliente_Tipoclientecreatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Tipoclientecreatedat_Z
      {
         get {
            return gxTv_SdtTipoCliente_Tipoclientecreatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTipoCliente_Tipoclientecreatedat_Z = value;
            SetDirty("Tipoclientecreatedat_Z");
         }

      }

      public void gxTv_SdtTipoCliente_Tipoclientecreatedat_Z_SetNull( )
      {
         gxTv_SdtTipoCliente_Tipoclientecreatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Tipoclientecreatedat_Z");
         return  ;
      }

      public bool gxTv_SdtTipoCliente_Tipoclientecreatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoClienteUpdateAt_Z" )]
      [  XmlElement( ElementName = "TipoClienteUpdateAt_Z"  , IsNullable=true )]
      public string gxTpr_Tipoclienteupdateat_Z_Nullable
      {
         get {
            if ( gxTv_SdtTipoCliente_Tipoclienteupdateat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTipoCliente_Tipoclienteupdateat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTipoCliente_Tipoclienteupdateat_Z = DateTime.MinValue;
            else
               gxTv_SdtTipoCliente_Tipoclienteupdateat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Tipoclienteupdateat_Z
      {
         get {
            return gxTv_SdtTipoCliente_Tipoclienteupdateat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTipoCliente_Tipoclienteupdateat_Z = value;
            SetDirty("Tipoclienteupdateat_Z");
         }

      }

      public void gxTv_SdtTipoCliente_Tipoclienteupdateat_Z_SetNull( )
      {
         gxTv_SdtTipoCliente_Tipoclienteupdateat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Tipoclienteupdateat_Z");
         return  ;
      }

      public bool gxTv_SdtTipoCliente_Tipoclienteupdateat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoClienteId_N" )]
      [  XmlElement( ElementName = "TipoClienteId_N"   )]
      public short gxTpr_Tipoclienteid_N
      {
         get {
            return gxTv_SdtTipoCliente_Tipoclienteid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTipoCliente_Tipoclienteid_N = value;
            SetDirty("Tipoclienteid_N");
         }

      }

      public void gxTv_SdtTipoCliente_Tipoclienteid_N_SetNull( )
      {
         gxTv_SdtTipoCliente_Tipoclienteid_N = 0;
         SetDirty("Tipoclienteid_N");
         return  ;
      }

      public bool gxTv_SdtTipoCliente_Tipoclienteid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoClienteDescricao_N" )]
      [  XmlElement( ElementName = "TipoClienteDescricao_N"   )]
      public short gxTpr_Tipoclientedescricao_N
      {
         get {
            return gxTv_SdtTipoCliente_Tipoclientedescricao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTipoCliente_Tipoclientedescricao_N = value;
            SetDirty("Tipoclientedescricao_N");
         }

      }

      public void gxTv_SdtTipoCliente_Tipoclientedescricao_N_SetNull( )
      {
         gxTv_SdtTipoCliente_Tipoclientedescricao_N = 0;
         SetDirty("Tipoclientedescricao_N");
         return  ;
      }

      public bool gxTv_SdtTipoCliente_Tipoclientedescricao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoClienteTipoPessoa_N" )]
      [  XmlElement( ElementName = "TipoClienteTipoPessoa_N"   )]
      public short gxTpr_Tipoclientetipopessoa_N
      {
         get {
            return gxTv_SdtTipoCliente_Tipoclientetipopessoa_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTipoCliente_Tipoclientetipopessoa_N = value;
            SetDirty("Tipoclientetipopessoa_N");
         }

      }

      public void gxTv_SdtTipoCliente_Tipoclientetipopessoa_N_SetNull( )
      {
         gxTv_SdtTipoCliente_Tipoclientetipopessoa_N = 0;
         SetDirty("Tipoclientetipopessoa_N");
         return  ;
      }

      public bool gxTv_SdtTipoCliente_Tipoclientetipopessoa_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoClientePortal_N" )]
      [  XmlElement( ElementName = "TipoClientePortal_N"   )]
      public short gxTpr_Tipoclienteportal_N
      {
         get {
            return gxTv_SdtTipoCliente_Tipoclienteportal_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTipoCliente_Tipoclienteportal_N = value;
            SetDirty("Tipoclienteportal_N");
         }

      }

      public void gxTv_SdtTipoCliente_Tipoclienteportal_N_SetNull( )
      {
         gxTv_SdtTipoCliente_Tipoclienteportal_N = 0;
         SetDirty("Tipoclienteportal_N");
         return  ;
      }

      public bool gxTv_SdtTipoCliente_Tipoclienteportal_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoClientePortalPjPf_N" )]
      [  XmlElement( ElementName = "TipoClientePortalPjPf_N"   )]
      public short gxTpr_Tipoclienteportalpjpf_N
      {
         get {
            return gxTv_SdtTipoCliente_Tipoclienteportalpjpf_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTipoCliente_Tipoclienteportalpjpf_N = value;
            SetDirty("Tipoclienteportalpjpf_N");
         }

      }

      public void gxTv_SdtTipoCliente_Tipoclienteportalpjpf_N_SetNull( )
      {
         gxTv_SdtTipoCliente_Tipoclienteportalpjpf_N = 0;
         SetDirty("Tipoclienteportalpjpf_N");
         return  ;
      }

      public bool gxTv_SdtTipoCliente_Tipoclienteportalpjpf_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoClienteFinancia_N" )]
      [  XmlElement( ElementName = "TipoClienteFinancia_N"   )]
      public short gxTpr_Tipoclientefinancia_N
      {
         get {
            return gxTv_SdtTipoCliente_Tipoclientefinancia_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTipoCliente_Tipoclientefinancia_N = value;
            SetDirty("Tipoclientefinancia_N");
         }

      }

      public void gxTv_SdtTipoCliente_Tipoclientefinancia_N_SetNull( )
      {
         gxTv_SdtTipoCliente_Tipoclientefinancia_N = 0;
         SetDirty("Tipoclientefinancia_N");
         return  ;
      }

      public bool gxTv_SdtTipoCliente_Tipoclientefinancia_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoClienteCreatedAt_N" )]
      [  XmlElement( ElementName = "TipoClienteCreatedAt_N"   )]
      public short gxTpr_Tipoclientecreatedat_N
      {
         get {
            return gxTv_SdtTipoCliente_Tipoclientecreatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTipoCliente_Tipoclientecreatedat_N = value;
            SetDirty("Tipoclientecreatedat_N");
         }

      }

      public void gxTv_SdtTipoCliente_Tipoclientecreatedat_N_SetNull( )
      {
         gxTv_SdtTipoCliente_Tipoclientecreatedat_N = 0;
         SetDirty("Tipoclientecreatedat_N");
         return  ;
      }

      public bool gxTv_SdtTipoCliente_Tipoclientecreatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoClienteUpdateAt_N" )]
      [  XmlElement( ElementName = "TipoClienteUpdateAt_N"   )]
      public short gxTpr_Tipoclienteupdateat_N
      {
         get {
            return gxTv_SdtTipoCliente_Tipoclienteupdateat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTipoCliente_Tipoclienteupdateat_N = value;
            SetDirty("Tipoclienteupdateat_N");
         }

      }

      public void gxTv_SdtTipoCliente_Tipoclienteupdateat_N_SetNull( )
      {
         gxTv_SdtTipoCliente_Tipoclienteupdateat_N = 0;
         SetDirty("Tipoclienteupdateat_N");
         return  ;
      }

      public bool gxTv_SdtTipoCliente_Tipoclienteupdateat_N_IsNull( )
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
         gxTv_SdtTipoCliente_Tipoclientedescricao = "";
         gxTv_SdtTipoCliente_Tipoclientetipopessoa = "";
         gxTv_SdtTipoCliente_Tipoclientecreatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtTipoCliente_Tipoclienteupdateat = (DateTime)(DateTime.MinValue);
         gxTv_SdtTipoCliente_Mode = "";
         gxTv_SdtTipoCliente_Tipoclientedescricao_Z = "";
         gxTv_SdtTipoCliente_Tipoclientetipopessoa_Z = "";
         gxTv_SdtTipoCliente_Tipoclientecreatedat_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtTipoCliente_Tipoclienteupdateat_Z = (DateTime)(DateTime.MinValue);
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "tipocliente", "GeneXus.Programs.tipocliente_bc", new Object[] {context}, constructorCallingAssembly);;
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

      private short gxTv_SdtTipoCliente_Tipoclienteid ;
      private short sdtIsNull ;
      private short gxTv_SdtTipoCliente_Initialized ;
      private short gxTv_SdtTipoCliente_Tipoclienteid_Z ;
      private short gxTv_SdtTipoCliente_Tipoclienteid_N ;
      private short gxTv_SdtTipoCliente_Tipoclientedescricao_N ;
      private short gxTv_SdtTipoCliente_Tipoclientetipopessoa_N ;
      private short gxTv_SdtTipoCliente_Tipoclienteportal_N ;
      private short gxTv_SdtTipoCliente_Tipoclienteportalpjpf_N ;
      private short gxTv_SdtTipoCliente_Tipoclientefinancia_N ;
      private short gxTv_SdtTipoCliente_Tipoclientecreatedat_N ;
      private short gxTv_SdtTipoCliente_Tipoclienteupdateat_N ;
      private string gxTv_SdtTipoCliente_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtTipoCliente_Tipoclientecreatedat ;
      private DateTime gxTv_SdtTipoCliente_Tipoclienteupdateat ;
      private DateTime gxTv_SdtTipoCliente_Tipoclientecreatedat_Z ;
      private DateTime gxTv_SdtTipoCliente_Tipoclienteupdateat_Z ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtTipoCliente_Tipoclienteportal ;
      private bool gxTv_SdtTipoCliente_Tipoclienteportalpjpf ;
      private bool gxTv_SdtTipoCliente_Tipoclientefinancia ;
      private bool gxTv_SdtTipoCliente_Tipoclienteportal_Z ;
      private bool gxTv_SdtTipoCliente_Tipoclienteportalpjpf_Z ;
      private bool gxTv_SdtTipoCliente_Tipoclientefinancia_Z ;
      private string gxTv_SdtTipoCliente_Tipoclientedescricao ;
      private string gxTv_SdtTipoCliente_Tipoclientetipopessoa ;
      private string gxTv_SdtTipoCliente_Tipoclientedescricao_Z ;
      private string gxTv_SdtTipoCliente_Tipoclientetipopessoa_Z ;
   }

   [DataContract(Name = @"TipoCliente", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtTipoCliente_RESTInterface : GxGenericCollectionItem<SdtTipoCliente>
   {
      public SdtTipoCliente_RESTInterface( ) : base()
      {
      }

      public SdtTipoCliente_RESTInterface( SdtTipoCliente psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TipoClienteId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Tipoclienteid
      {
         get {
            return sdt.gxTpr_Tipoclienteid ;
         }

         set {
            sdt.gxTpr_Tipoclienteid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "TipoClienteDescricao" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Tipoclientedescricao
      {
         get {
            return sdt.gxTpr_Tipoclientedescricao ;
         }

         set {
            sdt.gxTpr_Tipoclientedescricao = value;
         }

      }

      [DataMember( Name = "TipoClienteTipoPessoa" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Tipoclientetipopessoa
      {
         get {
            return sdt.gxTpr_Tipoclientetipopessoa ;
         }

         set {
            sdt.gxTpr_Tipoclientetipopessoa = value;
         }

      }

      [DataMember( Name = "TipoClientePortal" , Order = 3 )]
      [GxSeudo()]
      public bool gxTpr_Tipoclienteportal
      {
         get {
            return sdt.gxTpr_Tipoclienteportal ;
         }

         set {
            sdt.gxTpr_Tipoclienteportal = value;
         }

      }

      [DataMember( Name = "TipoClientePortalPjPf" , Order = 4 )]
      [GxSeudo()]
      public bool gxTpr_Tipoclienteportalpjpf
      {
         get {
            return sdt.gxTpr_Tipoclienteportalpjpf ;
         }

         set {
            sdt.gxTpr_Tipoclienteportalpjpf = value;
         }

      }

      [DataMember( Name = "TipoClienteFinancia" , Order = 5 )]
      [GxSeudo()]
      public bool gxTpr_Tipoclientefinancia
      {
         get {
            return sdt.gxTpr_Tipoclientefinancia ;
         }

         set {
            sdt.gxTpr_Tipoclientefinancia = value;
         }

      }

      [DataMember( Name = "TipoClienteCreatedAt" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Tipoclientecreatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Tipoclientecreatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Tipoclientecreatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "TipoClienteUpdateAt" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Tipoclienteupdateat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Tipoclienteupdateat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Tipoclienteupdateat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      public SdtTipoCliente sdt
      {
         get {
            return (SdtTipoCliente)Sdt ;
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
            sdt = new SdtTipoCliente() ;
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

   [DataContract(Name = @"TipoCliente", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtTipoCliente_RESTLInterface : GxGenericCollectionItem<SdtTipoCliente>
   {
      public SdtTipoCliente_RESTLInterface( ) : base()
      {
      }

      public SdtTipoCliente_RESTLInterface( SdtTipoCliente psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TipoClienteDescricao" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Tipoclientedescricao
      {
         get {
            return sdt.gxTpr_Tipoclientedescricao ;
         }

         set {
            sdt.gxTpr_Tipoclientedescricao = value;
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

      public SdtTipoCliente sdt
      {
         get {
            return (SdtTipoCliente)Sdt ;
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
            sdt = new SdtTipoCliente() ;
         }
      }

   }

}
