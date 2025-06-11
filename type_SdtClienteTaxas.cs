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
   [XmlRoot(ElementName = "ClienteTaxas" )]
   [XmlType(TypeName =  "ClienteTaxas" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtClienteTaxas : GxSilentTrnSdt
   {
      public SdtClienteTaxas( )
      {
      }

      public SdtClienteTaxas( IGxContext context )
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

      public void Load( int AV1008ClienteTaxasId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV1008ClienteTaxasId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ClienteTaxasId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "ClienteTaxas");
         metadata.Set("BT", "ClienteTaxas");
         metadata.Set("PK", "[ \"ClienteTaxasId\" ]");
         metadata.Set("PKAssigned", "[ \"ClienteTaxasId\" ]");
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
         state.Add("gxTpr_Clientetaxasid_Z");
         state.Add("gxTpr_Clientetaxastipo_Z");
         state.Add("gxTpr_Clientetaxasefetiva_Z");
         state.Add("gxTpr_Clientetaxasmora_Z");
         state.Add("gxTpr_Clientetaxasfator_Z");
         state.Add("gxTpr_Clientetaxastipotarifa_Z");
         state.Add("gxTpr_Clientetaxastarifa_Z");
         state.Add("gxTpr_Clientetaxascreatedat_Z_Nullable");
         state.Add("gxTpr_Clientetaxasupdatedat_Z_Nullable");
         state.Add("gxTpr_Clientetaxastipo_N");
         state.Add("gxTpr_Clientetaxasefetiva_N");
         state.Add("gxTpr_Clientetaxasmora_N");
         state.Add("gxTpr_Clientetaxasfator_N");
         state.Add("gxTpr_Clientetaxastipotarifa_N");
         state.Add("gxTpr_Clientetaxastarifa_N");
         state.Add("gxTpr_Clientetaxascreatedat_N");
         state.Add("gxTpr_Clientetaxasupdatedat_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtClienteTaxas sdt;
         sdt = (SdtClienteTaxas)(source);
         gxTv_SdtClienteTaxas_Clientetaxasid = sdt.gxTv_SdtClienteTaxas_Clientetaxasid ;
         gxTv_SdtClienteTaxas_Clientetaxastipo = sdt.gxTv_SdtClienteTaxas_Clientetaxastipo ;
         gxTv_SdtClienteTaxas_Clientetaxasefetiva = sdt.gxTv_SdtClienteTaxas_Clientetaxasefetiva ;
         gxTv_SdtClienteTaxas_Clientetaxasmora = sdt.gxTv_SdtClienteTaxas_Clientetaxasmora ;
         gxTv_SdtClienteTaxas_Clientetaxasfator = sdt.gxTv_SdtClienteTaxas_Clientetaxasfator ;
         gxTv_SdtClienteTaxas_Clientetaxastipotarifa = sdt.gxTv_SdtClienteTaxas_Clientetaxastipotarifa ;
         gxTv_SdtClienteTaxas_Clientetaxastarifa = sdt.gxTv_SdtClienteTaxas_Clientetaxastarifa ;
         gxTv_SdtClienteTaxas_Clientetaxascreatedat = sdt.gxTv_SdtClienteTaxas_Clientetaxascreatedat ;
         gxTv_SdtClienteTaxas_Clientetaxasupdatedat = sdt.gxTv_SdtClienteTaxas_Clientetaxasupdatedat ;
         gxTv_SdtClienteTaxas_Mode = sdt.gxTv_SdtClienteTaxas_Mode ;
         gxTv_SdtClienteTaxas_Initialized = sdt.gxTv_SdtClienteTaxas_Initialized ;
         gxTv_SdtClienteTaxas_Clientetaxasid_Z = sdt.gxTv_SdtClienteTaxas_Clientetaxasid_Z ;
         gxTv_SdtClienteTaxas_Clientetaxastipo_Z = sdt.gxTv_SdtClienteTaxas_Clientetaxastipo_Z ;
         gxTv_SdtClienteTaxas_Clientetaxasefetiva_Z = sdt.gxTv_SdtClienteTaxas_Clientetaxasefetiva_Z ;
         gxTv_SdtClienteTaxas_Clientetaxasmora_Z = sdt.gxTv_SdtClienteTaxas_Clientetaxasmora_Z ;
         gxTv_SdtClienteTaxas_Clientetaxasfator_Z = sdt.gxTv_SdtClienteTaxas_Clientetaxasfator_Z ;
         gxTv_SdtClienteTaxas_Clientetaxastipotarifa_Z = sdt.gxTv_SdtClienteTaxas_Clientetaxastipotarifa_Z ;
         gxTv_SdtClienteTaxas_Clientetaxastarifa_Z = sdt.gxTv_SdtClienteTaxas_Clientetaxastarifa_Z ;
         gxTv_SdtClienteTaxas_Clientetaxascreatedat_Z = sdt.gxTv_SdtClienteTaxas_Clientetaxascreatedat_Z ;
         gxTv_SdtClienteTaxas_Clientetaxasupdatedat_Z = sdt.gxTv_SdtClienteTaxas_Clientetaxasupdatedat_Z ;
         gxTv_SdtClienteTaxas_Clientetaxastipo_N = sdt.gxTv_SdtClienteTaxas_Clientetaxastipo_N ;
         gxTv_SdtClienteTaxas_Clientetaxasefetiva_N = sdt.gxTv_SdtClienteTaxas_Clientetaxasefetiva_N ;
         gxTv_SdtClienteTaxas_Clientetaxasmora_N = sdt.gxTv_SdtClienteTaxas_Clientetaxasmora_N ;
         gxTv_SdtClienteTaxas_Clientetaxasfator_N = sdt.gxTv_SdtClienteTaxas_Clientetaxasfator_N ;
         gxTv_SdtClienteTaxas_Clientetaxastipotarifa_N = sdt.gxTv_SdtClienteTaxas_Clientetaxastipotarifa_N ;
         gxTv_SdtClienteTaxas_Clientetaxastarifa_N = sdt.gxTv_SdtClienteTaxas_Clientetaxastarifa_N ;
         gxTv_SdtClienteTaxas_Clientetaxascreatedat_N = sdt.gxTv_SdtClienteTaxas_Clientetaxascreatedat_N ;
         gxTv_SdtClienteTaxas_Clientetaxasupdatedat_N = sdt.gxTv_SdtClienteTaxas_Clientetaxasupdatedat_N ;
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
         AddObjectProperty("ClienteTaxasId", gxTv_SdtClienteTaxas_Clientetaxasid, false, includeNonInitialized);
         AddObjectProperty("ClienteTaxasTipo", gxTv_SdtClienteTaxas_Clientetaxastipo, false, includeNonInitialized);
         AddObjectProperty("ClienteTaxasTipo_N", gxTv_SdtClienteTaxas_Clientetaxastipo_N, false, includeNonInitialized);
         AddObjectProperty("ClienteTaxasEfetiva", StringUtil.LTrim( StringUtil.Str( gxTv_SdtClienteTaxas_Clientetaxasefetiva, 16, 4)), false, includeNonInitialized);
         AddObjectProperty("ClienteTaxasEfetiva_N", gxTv_SdtClienteTaxas_Clientetaxasefetiva_N, false, includeNonInitialized);
         AddObjectProperty("ClienteTaxasMora", StringUtil.LTrim( StringUtil.Str( gxTv_SdtClienteTaxas_Clientetaxasmora, 16, 4)), false, includeNonInitialized);
         AddObjectProperty("ClienteTaxasMora_N", gxTv_SdtClienteTaxas_Clientetaxasmora_N, false, includeNonInitialized);
         AddObjectProperty("ClienteTaxasFator", StringUtil.LTrim( StringUtil.Str( gxTv_SdtClienteTaxas_Clientetaxasfator, 16, 4)), false, includeNonInitialized);
         AddObjectProperty("ClienteTaxasFator_N", gxTv_SdtClienteTaxas_Clientetaxasfator_N, false, includeNonInitialized);
         AddObjectProperty("ClienteTaxasTipoTarifa", gxTv_SdtClienteTaxas_Clientetaxastipotarifa, false, includeNonInitialized);
         AddObjectProperty("ClienteTaxasTipoTarifa_N", gxTv_SdtClienteTaxas_Clientetaxastipotarifa_N, false, includeNonInitialized);
         AddObjectProperty("ClienteTaxasTarifa", gxTv_SdtClienteTaxas_Clientetaxastarifa, false, includeNonInitialized);
         AddObjectProperty("ClienteTaxasTarifa_N", gxTv_SdtClienteTaxas_Clientetaxastarifa_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtClienteTaxas_Clientetaxascreatedat;
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
         AddObjectProperty("ClienteTaxasCreatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ClienteTaxasCreatedAt_N", gxTv_SdtClienteTaxas_Clientetaxascreatedat_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtClienteTaxas_Clientetaxasupdatedat;
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
         AddObjectProperty("ClienteTaxasUpdatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ClienteTaxasUpdatedAt_N", gxTv_SdtClienteTaxas_Clientetaxasupdatedat_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtClienteTaxas_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtClienteTaxas_Initialized, false, includeNonInitialized);
            AddObjectProperty("ClienteTaxasId_Z", gxTv_SdtClienteTaxas_Clientetaxasid_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteTaxasTipo_Z", gxTv_SdtClienteTaxas_Clientetaxastipo_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteTaxasEfetiva_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtClienteTaxas_Clientetaxasefetiva_Z, 16, 4)), false, includeNonInitialized);
            AddObjectProperty("ClienteTaxasMora_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtClienteTaxas_Clientetaxasmora_Z, 16, 4)), false, includeNonInitialized);
            AddObjectProperty("ClienteTaxasFator_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtClienteTaxas_Clientetaxasfator_Z, 16, 4)), false, includeNonInitialized);
            AddObjectProperty("ClienteTaxasTipoTarifa_Z", gxTv_SdtClienteTaxas_Clientetaxastipotarifa_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteTaxasTarifa_Z", gxTv_SdtClienteTaxas_Clientetaxastarifa_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtClienteTaxas_Clientetaxascreatedat_Z;
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
            AddObjectProperty("ClienteTaxasCreatedAt_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtClienteTaxas_Clientetaxasupdatedat_Z;
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
            AddObjectProperty("ClienteTaxasUpdatedAt_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("ClienteTaxasTipo_N", gxTv_SdtClienteTaxas_Clientetaxastipo_N, false, includeNonInitialized);
            AddObjectProperty("ClienteTaxasEfetiva_N", gxTv_SdtClienteTaxas_Clientetaxasefetiva_N, false, includeNonInitialized);
            AddObjectProperty("ClienteTaxasMora_N", gxTv_SdtClienteTaxas_Clientetaxasmora_N, false, includeNonInitialized);
            AddObjectProperty("ClienteTaxasFator_N", gxTv_SdtClienteTaxas_Clientetaxasfator_N, false, includeNonInitialized);
            AddObjectProperty("ClienteTaxasTipoTarifa_N", gxTv_SdtClienteTaxas_Clientetaxastipotarifa_N, false, includeNonInitialized);
            AddObjectProperty("ClienteTaxasTarifa_N", gxTv_SdtClienteTaxas_Clientetaxastarifa_N, false, includeNonInitialized);
            AddObjectProperty("ClienteTaxasCreatedAt_N", gxTv_SdtClienteTaxas_Clientetaxascreatedat_N, false, includeNonInitialized);
            AddObjectProperty("ClienteTaxasUpdatedAt_N", gxTv_SdtClienteTaxas_Clientetaxasupdatedat_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtClienteTaxas sdt )
      {
         if ( sdt.IsDirty("ClienteTaxasId") )
         {
            sdtIsNull = 0;
            gxTv_SdtClienteTaxas_Clientetaxasid = sdt.gxTv_SdtClienteTaxas_Clientetaxasid ;
         }
         if ( sdt.IsDirty("ClienteTaxasTipo") )
         {
            gxTv_SdtClienteTaxas_Clientetaxastipo_N = (short)(sdt.gxTv_SdtClienteTaxas_Clientetaxastipo_N);
            sdtIsNull = 0;
            gxTv_SdtClienteTaxas_Clientetaxastipo = sdt.gxTv_SdtClienteTaxas_Clientetaxastipo ;
         }
         if ( sdt.IsDirty("ClienteTaxasEfetiva") )
         {
            gxTv_SdtClienteTaxas_Clientetaxasefetiva_N = (short)(sdt.gxTv_SdtClienteTaxas_Clientetaxasefetiva_N);
            sdtIsNull = 0;
            gxTv_SdtClienteTaxas_Clientetaxasefetiva = sdt.gxTv_SdtClienteTaxas_Clientetaxasefetiva ;
         }
         if ( sdt.IsDirty("ClienteTaxasMora") )
         {
            gxTv_SdtClienteTaxas_Clientetaxasmora_N = (short)(sdt.gxTv_SdtClienteTaxas_Clientetaxasmora_N);
            sdtIsNull = 0;
            gxTv_SdtClienteTaxas_Clientetaxasmora = sdt.gxTv_SdtClienteTaxas_Clientetaxasmora ;
         }
         if ( sdt.IsDirty("ClienteTaxasFator") )
         {
            gxTv_SdtClienteTaxas_Clientetaxasfator_N = (short)(sdt.gxTv_SdtClienteTaxas_Clientetaxasfator_N);
            sdtIsNull = 0;
            gxTv_SdtClienteTaxas_Clientetaxasfator = sdt.gxTv_SdtClienteTaxas_Clientetaxasfator ;
         }
         if ( sdt.IsDirty("ClienteTaxasTipoTarifa") )
         {
            gxTv_SdtClienteTaxas_Clientetaxastipotarifa_N = (short)(sdt.gxTv_SdtClienteTaxas_Clientetaxastipotarifa_N);
            sdtIsNull = 0;
            gxTv_SdtClienteTaxas_Clientetaxastipotarifa = sdt.gxTv_SdtClienteTaxas_Clientetaxastipotarifa ;
         }
         if ( sdt.IsDirty("ClienteTaxasTarifa") )
         {
            gxTv_SdtClienteTaxas_Clientetaxastarifa_N = (short)(sdt.gxTv_SdtClienteTaxas_Clientetaxastarifa_N);
            sdtIsNull = 0;
            gxTv_SdtClienteTaxas_Clientetaxastarifa = sdt.gxTv_SdtClienteTaxas_Clientetaxastarifa ;
         }
         if ( sdt.IsDirty("ClienteTaxasCreatedAt") )
         {
            gxTv_SdtClienteTaxas_Clientetaxascreatedat_N = (short)(sdt.gxTv_SdtClienteTaxas_Clientetaxascreatedat_N);
            sdtIsNull = 0;
            gxTv_SdtClienteTaxas_Clientetaxascreatedat = sdt.gxTv_SdtClienteTaxas_Clientetaxascreatedat ;
         }
         if ( sdt.IsDirty("ClienteTaxasUpdatedAt") )
         {
            gxTv_SdtClienteTaxas_Clientetaxasupdatedat_N = (short)(sdt.gxTv_SdtClienteTaxas_Clientetaxasupdatedat_N);
            sdtIsNull = 0;
            gxTv_SdtClienteTaxas_Clientetaxasupdatedat = sdt.gxTv_SdtClienteTaxas_Clientetaxasupdatedat ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ClienteTaxasId" )]
      [  XmlElement( ElementName = "ClienteTaxasId"   )]
      public int gxTpr_Clientetaxasid
      {
         get {
            return gxTv_SdtClienteTaxas_Clientetaxasid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtClienteTaxas_Clientetaxasid != value )
            {
               gxTv_SdtClienteTaxas_Mode = "INS";
               this.gxTv_SdtClienteTaxas_Clientetaxasid_Z_SetNull( );
               this.gxTv_SdtClienteTaxas_Clientetaxastipo_Z_SetNull( );
               this.gxTv_SdtClienteTaxas_Clientetaxasefetiva_Z_SetNull( );
               this.gxTv_SdtClienteTaxas_Clientetaxasmora_Z_SetNull( );
               this.gxTv_SdtClienteTaxas_Clientetaxasfator_Z_SetNull( );
               this.gxTv_SdtClienteTaxas_Clientetaxastipotarifa_Z_SetNull( );
               this.gxTv_SdtClienteTaxas_Clientetaxastarifa_Z_SetNull( );
               this.gxTv_SdtClienteTaxas_Clientetaxascreatedat_Z_SetNull( );
               this.gxTv_SdtClienteTaxas_Clientetaxasupdatedat_Z_SetNull( );
            }
            gxTv_SdtClienteTaxas_Clientetaxasid = value;
            SetDirty("Clientetaxasid");
         }

      }

      [  SoapElement( ElementName = "ClienteTaxasTipo" )]
      [  XmlElement( ElementName = "ClienteTaxasTipo"   )]
      public string gxTpr_Clientetaxastipo
      {
         get {
            return gxTv_SdtClienteTaxas_Clientetaxastipo ;
         }

         set {
            gxTv_SdtClienteTaxas_Clientetaxastipo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtClienteTaxas_Clientetaxastipo = value;
            SetDirty("Clientetaxastipo");
         }

      }

      public void gxTv_SdtClienteTaxas_Clientetaxastipo_SetNull( )
      {
         gxTv_SdtClienteTaxas_Clientetaxastipo_N = 1;
         gxTv_SdtClienteTaxas_Clientetaxastipo = "";
         SetDirty("Clientetaxastipo");
         return  ;
      }

      public bool gxTv_SdtClienteTaxas_Clientetaxastipo_IsNull( )
      {
         return (gxTv_SdtClienteTaxas_Clientetaxastipo_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteTaxasEfetiva" )]
      [  XmlElement( ElementName = "ClienteTaxasEfetiva"   )]
      public decimal gxTpr_Clientetaxasefetiva
      {
         get {
            return gxTv_SdtClienteTaxas_Clientetaxasefetiva ;
         }

         set {
            gxTv_SdtClienteTaxas_Clientetaxasefetiva_N = 0;
            sdtIsNull = 0;
            gxTv_SdtClienteTaxas_Clientetaxasefetiva = value;
            SetDirty("Clientetaxasefetiva");
         }

      }

      public void gxTv_SdtClienteTaxas_Clientetaxasefetiva_SetNull( )
      {
         gxTv_SdtClienteTaxas_Clientetaxasefetiva_N = 1;
         gxTv_SdtClienteTaxas_Clientetaxasefetiva = 0;
         SetDirty("Clientetaxasefetiva");
         return  ;
      }

      public bool gxTv_SdtClienteTaxas_Clientetaxasefetiva_IsNull( )
      {
         return (gxTv_SdtClienteTaxas_Clientetaxasefetiva_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteTaxasMora" )]
      [  XmlElement( ElementName = "ClienteTaxasMora"   )]
      public decimal gxTpr_Clientetaxasmora
      {
         get {
            return gxTv_SdtClienteTaxas_Clientetaxasmora ;
         }

         set {
            gxTv_SdtClienteTaxas_Clientetaxasmora_N = 0;
            sdtIsNull = 0;
            gxTv_SdtClienteTaxas_Clientetaxasmora = value;
            SetDirty("Clientetaxasmora");
         }

      }

      public void gxTv_SdtClienteTaxas_Clientetaxasmora_SetNull( )
      {
         gxTv_SdtClienteTaxas_Clientetaxasmora_N = 1;
         gxTv_SdtClienteTaxas_Clientetaxasmora = 0;
         SetDirty("Clientetaxasmora");
         return  ;
      }

      public bool gxTv_SdtClienteTaxas_Clientetaxasmora_IsNull( )
      {
         return (gxTv_SdtClienteTaxas_Clientetaxasmora_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteTaxasFator" )]
      [  XmlElement( ElementName = "ClienteTaxasFator"   )]
      public decimal gxTpr_Clientetaxasfator
      {
         get {
            return gxTv_SdtClienteTaxas_Clientetaxasfator ;
         }

         set {
            gxTv_SdtClienteTaxas_Clientetaxasfator_N = 0;
            sdtIsNull = 0;
            gxTv_SdtClienteTaxas_Clientetaxasfator = value;
            SetDirty("Clientetaxasfator");
         }

      }

      public void gxTv_SdtClienteTaxas_Clientetaxasfator_SetNull( )
      {
         gxTv_SdtClienteTaxas_Clientetaxasfator_N = 1;
         gxTv_SdtClienteTaxas_Clientetaxasfator = 0;
         SetDirty("Clientetaxasfator");
         return  ;
      }

      public bool gxTv_SdtClienteTaxas_Clientetaxasfator_IsNull( )
      {
         return (gxTv_SdtClienteTaxas_Clientetaxasfator_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteTaxasTipoTarifa" )]
      [  XmlElement( ElementName = "ClienteTaxasTipoTarifa"   )]
      public string gxTpr_Clientetaxastipotarifa
      {
         get {
            return gxTv_SdtClienteTaxas_Clientetaxastipotarifa ;
         }

         set {
            gxTv_SdtClienteTaxas_Clientetaxastipotarifa_N = 0;
            sdtIsNull = 0;
            gxTv_SdtClienteTaxas_Clientetaxastipotarifa = value;
            SetDirty("Clientetaxastipotarifa");
         }

      }

      public void gxTv_SdtClienteTaxas_Clientetaxastipotarifa_SetNull( )
      {
         gxTv_SdtClienteTaxas_Clientetaxastipotarifa_N = 1;
         gxTv_SdtClienteTaxas_Clientetaxastipotarifa = "";
         SetDirty("Clientetaxastipotarifa");
         return  ;
      }

      public bool gxTv_SdtClienteTaxas_Clientetaxastipotarifa_IsNull( )
      {
         return (gxTv_SdtClienteTaxas_Clientetaxastipotarifa_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteTaxasTarifa" )]
      [  XmlElement( ElementName = "ClienteTaxasTarifa"   )]
      public decimal gxTpr_Clientetaxastarifa
      {
         get {
            return gxTv_SdtClienteTaxas_Clientetaxastarifa ;
         }

         set {
            gxTv_SdtClienteTaxas_Clientetaxastarifa_N = 0;
            sdtIsNull = 0;
            gxTv_SdtClienteTaxas_Clientetaxastarifa = value;
            SetDirty("Clientetaxastarifa");
         }

      }

      public void gxTv_SdtClienteTaxas_Clientetaxastarifa_SetNull( )
      {
         gxTv_SdtClienteTaxas_Clientetaxastarifa_N = 1;
         gxTv_SdtClienteTaxas_Clientetaxastarifa = 0;
         SetDirty("Clientetaxastarifa");
         return  ;
      }

      public bool gxTv_SdtClienteTaxas_Clientetaxastarifa_IsNull( )
      {
         return (gxTv_SdtClienteTaxas_Clientetaxastarifa_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteTaxasCreatedAt" )]
      [  XmlElement( ElementName = "ClienteTaxasCreatedAt"  , IsNullable=true )]
      public string gxTpr_Clientetaxascreatedat_Nullable
      {
         get {
            if ( gxTv_SdtClienteTaxas_Clientetaxascreatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtClienteTaxas_Clientetaxascreatedat).value ;
         }

         set {
            gxTv_SdtClienteTaxas_Clientetaxascreatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtClienteTaxas_Clientetaxascreatedat = DateTime.MinValue;
            else
               gxTv_SdtClienteTaxas_Clientetaxascreatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Clientetaxascreatedat
      {
         get {
            return gxTv_SdtClienteTaxas_Clientetaxascreatedat ;
         }

         set {
            gxTv_SdtClienteTaxas_Clientetaxascreatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtClienteTaxas_Clientetaxascreatedat = value;
            SetDirty("Clientetaxascreatedat");
         }

      }

      public void gxTv_SdtClienteTaxas_Clientetaxascreatedat_SetNull( )
      {
         gxTv_SdtClienteTaxas_Clientetaxascreatedat_N = 1;
         gxTv_SdtClienteTaxas_Clientetaxascreatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Clientetaxascreatedat");
         return  ;
      }

      public bool gxTv_SdtClienteTaxas_Clientetaxascreatedat_IsNull( )
      {
         return (gxTv_SdtClienteTaxas_Clientetaxascreatedat_N==1) ;
      }

      [  SoapElement( ElementName = "ClienteTaxasUpdatedAt" )]
      [  XmlElement( ElementName = "ClienteTaxasUpdatedAt"  , IsNullable=true )]
      public string gxTpr_Clientetaxasupdatedat_Nullable
      {
         get {
            if ( gxTv_SdtClienteTaxas_Clientetaxasupdatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtClienteTaxas_Clientetaxasupdatedat).value ;
         }

         set {
            gxTv_SdtClienteTaxas_Clientetaxasupdatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtClienteTaxas_Clientetaxasupdatedat = DateTime.MinValue;
            else
               gxTv_SdtClienteTaxas_Clientetaxasupdatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Clientetaxasupdatedat
      {
         get {
            return gxTv_SdtClienteTaxas_Clientetaxasupdatedat ;
         }

         set {
            gxTv_SdtClienteTaxas_Clientetaxasupdatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtClienteTaxas_Clientetaxasupdatedat = value;
            SetDirty("Clientetaxasupdatedat");
         }

      }

      public void gxTv_SdtClienteTaxas_Clientetaxasupdatedat_SetNull( )
      {
         gxTv_SdtClienteTaxas_Clientetaxasupdatedat_N = 1;
         gxTv_SdtClienteTaxas_Clientetaxasupdatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Clientetaxasupdatedat");
         return  ;
      }

      public bool gxTv_SdtClienteTaxas_Clientetaxasupdatedat_IsNull( )
      {
         return (gxTv_SdtClienteTaxas_Clientetaxasupdatedat_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtClienteTaxas_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteTaxas_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtClienteTaxas_Mode_SetNull( )
      {
         gxTv_SdtClienteTaxas_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtClienteTaxas_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtClienteTaxas_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteTaxas_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtClienteTaxas_Initialized_SetNull( )
      {
         gxTv_SdtClienteTaxas_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtClienteTaxas_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteTaxasId_Z" )]
      [  XmlElement( ElementName = "ClienteTaxasId_Z"   )]
      public int gxTpr_Clientetaxasid_Z
      {
         get {
            return gxTv_SdtClienteTaxas_Clientetaxasid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteTaxas_Clientetaxasid_Z = value;
            SetDirty("Clientetaxasid_Z");
         }

      }

      public void gxTv_SdtClienteTaxas_Clientetaxasid_Z_SetNull( )
      {
         gxTv_SdtClienteTaxas_Clientetaxasid_Z = 0;
         SetDirty("Clientetaxasid_Z");
         return  ;
      }

      public bool gxTv_SdtClienteTaxas_Clientetaxasid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteTaxasTipo_Z" )]
      [  XmlElement( ElementName = "ClienteTaxasTipo_Z"   )]
      public string gxTpr_Clientetaxastipo_Z
      {
         get {
            return gxTv_SdtClienteTaxas_Clientetaxastipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteTaxas_Clientetaxastipo_Z = value;
            SetDirty("Clientetaxastipo_Z");
         }

      }

      public void gxTv_SdtClienteTaxas_Clientetaxastipo_Z_SetNull( )
      {
         gxTv_SdtClienteTaxas_Clientetaxastipo_Z = "";
         SetDirty("Clientetaxastipo_Z");
         return  ;
      }

      public bool gxTv_SdtClienteTaxas_Clientetaxastipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteTaxasEfetiva_Z" )]
      [  XmlElement( ElementName = "ClienteTaxasEfetiva_Z"   )]
      public decimal gxTpr_Clientetaxasefetiva_Z
      {
         get {
            return gxTv_SdtClienteTaxas_Clientetaxasefetiva_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteTaxas_Clientetaxasefetiva_Z = value;
            SetDirty("Clientetaxasefetiva_Z");
         }

      }

      public void gxTv_SdtClienteTaxas_Clientetaxasefetiva_Z_SetNull( )
      {
         gxTv_SdtClienteTaxas_Clientetaxasefetiva_Z = 0;
         SetDirty("Clientetaxasefetiva_Z");
         return  ;
      }

      public bool gxTv_SdtClienteTaxas_Clientetaxasefetiva_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteTaxasMora_Z" )]
      [  XmlElement( ElementName = "ClienteTaxasMora_Z"   )]
      public decimal gxTpr_Clientetaxasmora_Z
      {
         get {
            return gxTv_SdtClienteTaxas_Clientetaxasmora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteTaxas_Clientetaxasmora_Z = value;
            SetDirty("Clientetaxasmora_Z");
         }

      }

      public void gxTv_SdtClienteTaxas_Clientetaxasmora_Z_SetNull( )
      {
         gxTv_SdtClienteTaxas_Clientetaxasmora_Z = 0;
         SetDirty("Clientetaxasmora_Z");
         return  ;
      }

      public bool gxTv_SdtClienteTaxas_Clientetaxasmora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteTaxasFator_Z" )]
      [  XmlElement( ElementName = "ClienteTaxasFator_Z"   )]
      public decimal gxTpr_Clientetaxasfator_Z
      {
         get {
            return gxTv_SdtClienteTaxas_Clientetaxasfator_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteTaxas_Clientetaxasfator_Z = value;
            SetDirty("Clientetaxasfator_Z");
         }

      }

      public void gxTv_SdtClienteTaxas_Clientetaxasfator_Z_SetNull( )
      {
         gxTv_SdtClienteTaxas_Clientetaxasfator_Z = 0;
         SetDirty("Clientetaxasfator_Z");
         return  ;
      }

      public bool gxTv_SdtClienteTaxas_Clientetaxasfator_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteTaxasTipoTarifa_Z" )]
      [  XmlElement( ElementName = "ClienteTaxasTipoTarifa_Z"   )]
      public string gxTpr_Clientetaxastipotarifa_Z
      {
         get {
            return gxTv_SdtClienteTaxas_Clientetaxastipotarifa_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteTaxas_Clientetaxastipotarifa_Z = value;
            SetDirty("Clientetaxastipotarifa_Z");
         }

      }

      public void gxTv_SdtClienteTaxas_Clientetaxastipotarifa_Z_SetNull( )
      {
         gxTv_SdtClienteTaxas_Clientetaxastipotarifa_Z = "";
         SetDirty("Clientetaxastipotarifa_Z");
         return  ;
      }

      public bool gxTv_SdtClienteTaxas_Clientetaxastipotarifa_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteTaxasTarifa_Z" )]
      [  XmlElement( ElementName = "ClienteTaxasTarifa_Z"   )]
      public decimal gxTpr_Clientetaxastarifa_Z
      {
         get {
            return gxTv_SdtClienteTaxas_Clientetaxastarifa_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteTaxas_Clientetaxastarifa_Z = value;
            SetDirty("Clientetaxastarifa_Z");
         }

      }

      public void gxTv_SdtClienteTaxas_Clientetaxastarifa_Z_SetNull( )
      {
         gxTv_SdtClienteTaxas_Clientetaxastarifa_Z = 0;
         SetDirty("Clientetaxastarifa_Z");
         return  ;
      }

      public bool gxTv_SdtClienteTaxas_Clientetaxastarifa_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteTaxasCreatedAt_Z" )]
      [  XmlElement( ElementName = "ClienteTaxasCreatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Clientetaxascreatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtClienteTaxas_Clientetaxascreatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtClienteTaxas_Clientetaxascreatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtClienteTaxas_Clientetaxascreatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtClienteTaxas_Clientetaxascreatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Clientetaxascreatedat_Z
      {
         get {
            return gxTv_SdtClienteTaxas_Clientetaxascreatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteTaxas_Clientetaxascreatedat_Z = value;
            SetDirty("Clientetaxascreatedat_Z");
         }

      }

      public void gxTv_SdtClienteTaxas_Clientetaxascreatedat_Z_SetNull( )
      {
         gxTv_SdtClienteTaxas_Clientetaxascreatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Clientetaxascreatedat_Z");
         return  ;
      }

      public bool gxTv_SdtClienteTaxas_Clientetaxascreatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteTaxasUpdatedAt_Z" )]
      [  XmlElement( ElementName = "ClienteTaxasUpdatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Clientetaxasupdatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtClienteTaxas_Clientetaxasupdatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtClienteTaxas_Clientetaxasupdatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtClienteTaxas_Clientetaxasupdatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtClienteTaxas_Clientetaxasupdatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Clientetaxasupdatedat_Z
      {
         get {
            return gxTv_SdtClienteTaxas_Clientetaxasupdatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteTaxas_Clientetaxasupdatedat_Z = value;
            SetDirty("Clientetaxasupdatedat_Z");
         }

      }

      public void gxTv_SdtClienteTaxas_Clientetaxasupdatedat_Z_SetNull( )
      {
         gxTv_SdtClienteTaxas_Clientetaxasupdatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Clientetaxasupdatedat_Z");
         return  ;
      }

      public bool gxTv_SdtClienteTaxas_Clientetaxasupdatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteTaxasTipo_N" )]
      [  XmlElement( ElementName = "ClienteTaxasTipo_N"   )]
      public short gxTpr_Clientetaxastipo_N
      {
         get {
            return gxTv_SdtClienteTaxas_Clientetaxastipo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteTaxas_Clientetaxastipo_N = value;
            SetDirty("Clientetaxastipo_N");
         }

      }

      public void gxTv_SdtClienteTaxas_Clientetaxastipo_N_SetNull( )
      {
         gxTv_SdtClienteTaxas_Clientetaxastipo_N = 0;
         SetDirty("Clientetaxastipo_N");
         return  ;
      }

      public bool gxTv_SdtClienteTaxas_Clientetaxastipo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteTaxasEfetiva_N" )]
      [  XmlElement( ElementName = "ClienteTaxasEfetiva_N"   )]
      public short gxTpr_Clientetaxasefetiva_N
      {
         get {
            return gxTv_SdtClienteTaxas_Clientetaxasefetiva_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteTaxas_Clientetaxasefetiva_N = value;
            SetDirty("Clientetaxasefetiva_N");
         }

      }

      public void gxTv_SdtClienteTaxas_Clientetaxasefetiva_N_SetNull( )
      {
         gxTv_SdtClienteTaxas_Clientetaxasefetiva_N = 0;
         SetDirty("Clientetaxasefetiva_N");
         return  ;
      }

      public bool gxTv_SdtClienteTaxas_Clientetaxasefetiva_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteTaxasMora_N" )]
      [  XmlElement( ElementName = "ClienteTaxasMora_N"   )]
      public short gxTpr_Clientetaxasmora_N
      {
         get {
            return gxTv_SdtClienteTaxas_Clientetaxasmora_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteTaxas_Clientetaxasmora_N = value;
            SetDirty("Clientetaxasmora_N");
         }

      }

      public void gxTv_SdtClienteTaxas_Clientetaxasmora_N_SetNull( )
      {
         gxTv_SdtClienteTaxas_Clientetaxasmora_N = 0;
         SetDirty("Clientetaxasmora_N");
         return  ;
      }

      public bool gxTv_SdtClienteTaxas_Clientetaxasmora_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteTaxasFator_N" )]
      [  XmlElement( ElementName = "ClienteTaxasFator_N"   )]
      public short gxTpr_Clientetaxasfator_N
      {
         get {
            return gxTv_SdtClienteTaxas_Clientetaxasfator_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteTaxas_Clientetaxasfator_N = value;
            SetDirty("Clientetaxasfator_N");
         }

      }

      public void gxTv_SdtClienteTaxas_Clientetaxasfator_N_SetNull( )
      {
         gxTv_SdtClienteTaxas_Clientetaxasfator_N = 0;
         SetDirty("Clientetaxasfator_N");
         return  ;
      }

      public bool gxTv_SdtClienteTaxas_Clientetaxasfator_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteTaxasTipoTarifa_N" )]
      [  XmlElement( ElementName = "ClienteTaxasTipoTarifa_N"   )]
      public short gxTpr_Clientetaxastipotarifa_N
      {
         get {
            return gxTv_SdtClienteTaxas_Clientetaxastipotarifa_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteTaxas_Clientetaxastipotarifa_N = value;
            SetDirty("Clientetaxastipotarifa_N");
         }

      }

      public void gxTv_SdtClienteTaxas_Clientetaxastipotarifa_N_SetNull( )
      {
         gxTv_SdtClienteTaxas_Clientetaxastipotarifa_N = 0;
         SetDirty("Clientetaxastipotarifa_N");
         return  ;
      }

      public bool gxTv_SdtClienteTaxas_Clientetaxastipotarifa_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteTaxasTarifa_N" )]
      [  XmlElement( ElementName = "ClienteTaxasTarifa_N"   )]
      public short gxTpr_Clientetaxastarifa_N
      {
         get {
            return gxTv_SdtClienteTaxas_Clientetaxastarifa_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteTaxas_Clientetaxastarifa_N = value;
            SetDirty("Clientetaxastarifa_N");
         }

      }

      public void gxTv_SdtClienteTaxas_Clientetaxastarifa_N_SetNull( )
      {
         gxTv_SdtClienteTaxas_Clientetaxastarifa_N = 0;
         SetDirty("Clientetaxastarifa_N");
         return  ;
      }

      public bool gxTv_SdtClienteTaxas_Clientetaxastarifa_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteTaxasCreatedAt_N" )]
      [  XmlElement( ElementName = "ClienteTaxasCreatedAt_N"   )]
      public short gxTpr_Clientetaxascreatedat_N
      {
         get {
            return gxTv_SdtClienteTaxas_Clientetaxascreatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteTaxas_Clientetaxascreatedat_N = value;
            SetDirty("Clientetaxascreatedat_N");
         }

      }

      public void gxTv_SdtClienteTaxas_Clientetaxascreatedat_N_SetNull( )
      {
         gxTv_SdtClienteTaxas_Clientetaxascreatedat_N = 0;
         SetDirty("Clientetaxascreatedat_N");
         return  ;
      }

      public bool gxTv_SdtClienteTaxas_Clientetaxascreatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteTaxasUpdatedAt_N" )]
      [  XmlElement( ElementName = "ClienteTaxasUpdatedAt_N"   )]
      public short gxTpr_Clientetaxasupdatedat_N
      {
         get {
            return gxTv_SdtClienteTaxas_Clientetaxasupdatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtClienteTaxas_Clientetaxasupdatedat_N = value;
            SetDirty("Clientetaxasupdatedat_N");
         }

      }

      public void gxTv_SdtClienteTaxas_Clientetaxasupdatedat_N_SetNull( )
      {
         gxTv_SdtClienteTaxas_Clientetaxasupdatedat_N = 0;
         SetDirty("Clientetaxasupdatedat_N");
         return  ;
      }

      public bool gxTv_SdtClienteTaxas_Clientetaxasupdatedat_N_IsNull( )
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
         gxTv_SdtClienteTaxas_Clientetaxastipo = "";
         gxTv_SdtClienteTaxas_Clientetaxastipotarifa = "";
         gxTv_SdtClienteTaxas_Clientetaxascreatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtClienteTaxas_Clientetaxasupdatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtClienteTaxas_Mode = "";
         gxTv_SdtClienteTaxas_Clientetaxastipo_Z = "";
         gxTv_SdtClienteTaxas_Clientetaxastipotarifa_Z = "";
         gxTv_SdtClienteTaxas_Clientetaxascreatedat_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtClienteTaxas_Clientetaxasupdatedat_Z = (DateTime)(DateTime.MinValue);
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "clientetaxas", "GeneXus.Programs.clientetaxas_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtClienteTaxas_Initialized ;
      private short gxTv_SdtClienteTaxas_Clientetaxastipo_N ;
      private short gxTv_SdtClienteTaxas_Clientetaxasefetiva_N ;
      private short gxTv_SdtClienteTaxas_Clientetaxasmora_N ;
      private short gxTv_SdtClienteTaxas_Clientetaxasfator_N ;
      private short gxTv_SdtClienteTaxas_Clientetaxastipotarifa_N ;
      private short gxTv_SdtClienteTaxas_Clientetaxastarifa_N ;
      private short gxTv_SdtClienteTaxas_Clientetaxascreatedat_N ;
      private short gxTv_SdtClienteTaxas_Clientetaxasupdatedat_N ;
      private int gxTv_SdtClienteTaxas_Clientetaxasid ;
      private int gxTv_SdtClienteTaxas_Clientetaxasid_Z ;
      private decimal gxTv_SdtClienteTaxas_Clientetaxasefetiva ;
      private decimal gxTv_SdtClienteTaxas_Clientetaxasmora ;
      private decimal gxTv_SdtClienteTaxas_Clientetaxasfator ;
      private decimal gxTv_SdtClienteTaxas_Clientetaxastarifa ;
      private decimal gxTv_SdtClienteTaxas_Clientetaxasefetiva_Z ;
      private decimal gxTv_SdtClienteTaxas_Clientetaxasmora_Z ;
      private decimal gxTv_SdtClienteTaxas_Clientetaxasfator_Z ;
      private decimal gxTv_SdtClienteTaxas_Clientetaxastarifa_Z ;
      private string gxTv_SdtClienteTaxas_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtClienteTaxas_Clientetaxascreatedat ;
      private DateTime gxTv_SdtClienteTaxas_Clientetaxasupdatedat ;
      private DateTime gxTv_SdtClienteTaxas_Clientetaxascreatedat_Z ;
      private DateTime gxTv_SdtClienteTaxas_Clientetaxasupdatedat_Z ;
      private DateTime datetime_STZ ;
      private string gxTv_SdtClienteTaxas_Clientetaxastipo ;
      private string gxTv_SdtClienteTaxas_Clientetaxastipotarifa ;
      private string gxTv_SdtClienteTaxas_Clientetaxastipo_Z ;
      private string gxTv_SdtClienteTaxas_Clientetaxastipotarifa_Z ;
   }

   [DataContract(Name = @"ClienteTaxas", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtClienteTaxas_RESTInterface : GxGenericCollectionItem<SdtClienteTaxas>
   {
      public SdtClienteTaxas_RESTInterface( ) : base()
      {
      }

      public SdtClienteTaxas_RESTInterface( SdtClienteTaxas psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ClienteTaxasId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Clientetaxasid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Clientetaxasid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Clientetaxasid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ClienteTaxasTipo" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Clientetaxastipo
      {
         get {
            return sdt.gxTpr_Clientetaxastipo ;
         }

         set {
            sdt.gxTpr_Clientetaxastipo = value;
         }

      }

      [DataMember( Name = "ClienteTaxasEfetiva" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Clientetaxasefetiva
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Clientetaxasefetiva, 16, 4)) ;
         }

         set {
            sdt.gxTpr_Clientetaxasefetiva = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ClienteTaxasMora" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Clientetaxasmora
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Clientetaxasmora, 16, 4)) ;
         }

         set {
            sdt.gxTpr_Clientetaxasmora = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ClienteTaxasFator" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Clientetaxasfator
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Clientetaxasfator, 16, 4)) ;
         }

         set {
            sdt.gxTpr_Clientetaxasfator = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ClienteTaxasTipoTarifa" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Clientetaxastipotarifa
      {
         get {
            return sdt.gxTpr_Clientetaxastipotarifa ;
         }

         set {
            sdt.gxTpr_Clientetaxastipotarifa = value;
         }

      }

      [DataMember( Name = "ClienteTaxasTarifa" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Clientetaxastarifa
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Clientetaxastarifa, 15, 2)) ;
         }

         set {
            sdt.gxTpr_Clientetaxastarifa = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ClienteTaxasCreatedAt" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Clientetaxascreatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Clientetaxascreatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Clientetaxascreatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "ClienteTaxasUpdatedAt" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Clientetaxasupdatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Clientetaxasupdatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Clientetaxasupdatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      public SdtClienteTaxas sdt
      {
         get {
            return (SdtClienteTaxas)Sdt ;
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
            sdt = new SdtClienteTaxas() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 9 )]
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

   [DataContract(Name = @"ClienteTaxas", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtClienteTaxas_RESTLInterface : GxGenericCollectionItem<SdtClienteTaxas>
   {
      public SdtClienteTaxas_RESTLInterface( ) : base()
      {
      }

      public SdtClienteTaxas_RESTLInterface( SdtClienteTaxas psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ClienteTaxasTipo" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Clientetaxastipo
      {
         get {
            return sdt.gxTpr_Clientetaxastipo ;
         }

         set {
            sdt.gxTpr_Clientetaxastipo = value;
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

      public SdtClienteTaxas sdt
      {
         get {
            return (SdtClienteTaxas)Sdt ;
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
            sdt = new SdtClienteTaxas() ;
         }
      }

   }

}
