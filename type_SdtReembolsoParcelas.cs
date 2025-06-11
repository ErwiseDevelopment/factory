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
   [XmlRoot(ElementName = "ReembolsoParcelas" )]
   [XmlType(TypeName =  "ReembolsoParcelas" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtReembolsoParcelas : GxSilentTrnSdt
   {
      public SdtReembolsoParcelas( )
      {
      }

      public SdtReembolsoParcelas( IGxContext context )
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

      public void Load( int AV634ReembolsoParcelasId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV634ReembolsoParcelasId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ReembolsoParcelasId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "ReembolsoParcelas");
         metadata.Set("BT", "ReembolsoParcelas");
         metadata.Set("PK", "[ \"ReembolsoParcelasId\" ]");
         metadata.Set("PKAssigned", "[ \"ReembolsoParcelasId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ReembolsoId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Reembolsoparcelasid_Z");
         state.Add("gxTpr_Reembolsoid_Z");
         state.Add("gxTpr_Reembolsoparcelasvalor_Z");
         state.Add("gxTpr_Reembolsoparcelasdata_Z_Nullable");
         state.Add("gxTpr_Reembolsoparcelasobservacao_Z");
         state.Add("gxTpr_Reembolsoparcelascreatedat_Z_Nullable");
         state.Add("gxTpr_Reembolsoparcelastaxavalor_Z");
         state.Add("gxTpr_Reembolsoparcelasjurosvalor_Z");
         state.Add("gxTpr_Reembolsoparcelasdiaspjuros_Z");
         state.Add("gxTpr_Reembolsoid_N");
         state.Add("gxTpr_Reembolsoparcelasvalor_N");
         state.Add("gxTpr_Reembolsoparcelasdata_N");
         state.Add("gxTpr_Reembolsoparcelasobservacao_N");
         state.Add("gxTpr_Reembolsoparcelascreatedat_N");
         state.Add("gxTpr_Reembolsoparcelastaxavalor_N");
         state.Add("gxTpr_Reembolsoparcelasjurosvalor_N");
         state.Add("gxTpr_Reembolsoparcelasdiaspjuros_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtReembolsoParcelas sdt;
         sdt = (SdtReembolsoParcelas)(source);
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasid = sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelasid ;
         gxTv_SdtReembolsoParcelas_Reembolsoid = sdt.gxTv_SdtReembolsoParcelas_Reembolsoid ;
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasvalor = sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelasvalor ;
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata = sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata ;
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao = sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao ;
         gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat = sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat ;
         gxTv_SdtReembolsoParcelas_Reembolsoparcelastaxavalor = sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelastaxavalor ;
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasjurosvalor = sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelasjurosvalor ;
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasdiaspjuros = sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelasdiaspjuros ;
         gxTv_SdtReembolsoParcelas_Mode = sdt.gxTv_SdtReembolsoParcelas_Mode ;
         gxTv_SdtReembolsoParcelas_Initialized = sdt.gxTv_SdtReembolsoParcelas_Initialized ;
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasid_Z = sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelasid_Z ;
         gxTv_SdtReembolsoParcelas_Reembolsoid_Z = sdt.gxTv_SdtReembolsoParcelas_Reembolsoid_Z ;
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasvalor_Z = sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelasvalor_Z ;
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata_Z = sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata_Z ;
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao_Z = sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao_Z ;
         gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat_Z = sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat_Z ;
         gxTv_SdtReembolsoParcelas_Reembolsoparcelastaxavalor_Z = sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelastaxavalor_Z ;
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasjurosvalor_Z = sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelasjurosvalor_Z ;
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasdiaspjuros_Z = sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelasdiaspjuros_Z ;
         gxTv_SdtReembolsoParcelas_Reembolsoid_N = sdt.gxTv_SdtReembolsoParcelas_Reembolsoid_N ;
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasvalor_N = sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelasvalor_N ;
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata_N = sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata_N ;
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao_N = sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao_N ;
         gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat_N = sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat_N ;
         gxTv_SdtReembolsoParcelas_Reembolsoparcelastaxavalor_N = sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelastaxavalor_N ;
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasjurosvalor_N = sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelasjurosvalor_N ;
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasdiaspjuros_N = sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelasdiaspjuros_N ;
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
         AddObjectProperty("ReembolsoParcelasId", gxTv_SdtReembolsoParcelas_Reembolsoparcelasid, false, includeNonInitialized);
         AddObjectProperty("ReembolsoId", gxTv_SdtReembolsoParcelas_Reembolsoid, false, includeNonInitialized);
         AddObjectProperty("ReembolsoId_N", gxTv_SdtReembolsoParcelas_Reembolsoid_N, false, includeNonInitialized);
         AddObjectProperty("ReembolsoParcelasValor", StringUtil.LTrim( StringUtil.Str( gxTv_SdtReembolsoParcelas_Reembolsoparcelasvalor, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("ReembolsoParcelasValor_N", gxTv_SdtReembolsoParcelas_Reembolsoparcelasvalor_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("ReembolsoParcelasData", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ReembolsoParcelasData_N", gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata_N, false, includeNonInitialized);
         AddObjectProperty("ReembolsoParcelasObservacao", gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao, false, includeNonInitialized);
         AddObjectProperty("ReembolsoParcelasObservacao_N", gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat;
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
         AddObjectProperty("ReembolsoParcelasCreatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ReembolsoParcelasCreatedAt_N", gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat_N, false, includeNonInitialized);
         AddObjectProperty("ReembolsoParcelasTaxaValor", StringUtil.LTrim( StringUtil.Str( gxTv_SdtReembolsoParcelas_Reembolsoparcelastaxavalor, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("ReembolsoParcelasTaxaValor_N", gxTv_SdtReembolsoParcelas_Reembolsoparcelastaxavalor_N, false, includeNonInitialized);
         AddObjectProperty("ReembolsoParcelasJurosValor", StringUtil.LTrim( StringUtil.Str( gxTv_SdtReembolsoParcelas_Reembolsoparcelasjurosvalor, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("ReembolsoParcelasJurosValor_N", gxTv_SdtReembolsoParcelas_Reembolsoparcelasjurosvalor_N, false, includeNonInitialized);
         AddObjectProperty("ReembolsoParcelasDiasPJuros", gxTv_SdtReembolsoParcelas_Reembolsoparcelasdiaspjuros, false, includeNonInitialized);
         AddObjectProperty("ReembolsoParcelasDiasPJuros_N", gxTv_SdtReembolsoParcelas_Reembolsoparcelasdiaspjuros_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtReembolsoParcelas_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtReembolsoParcelas_Initialized, false, includeNonInitialized);
            AddObjectProperty("ReembolsoParcelasId_Z", gxTv_SdtReembolsoParcelas_Reembolsoparcelasid_Z, false, includeNonInitialized);
            AddObjectProperty("ReembolsoId_Z", gxTv_SdtReembolsoParcelas_Reembolsoid_Z, false, includeNonInitialized);
            AddObjectProperty("ReembolsoParcelasValor_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtReembolsoParcelas_Reembolsoparcelasvalor_Z, 18, 2)), false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("ReembolsoParcelasData_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("ReembolsoParcelasObservacao_Z", gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat_Z;
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
            AddObjectProperty("ReembolsoParcelasCreatedAt_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("ReembolsoParcelasTaxaValor_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtReembolsoParcelas_Reembolsoparcelastaxavalor_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("ReembolsoParcelasJurosValor_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtReembolsoParcelas_Reembolsoparcelasjurosvalor_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("ReembolsoParcelasDiasPJuros_Z", gxTv_SdtReembolsoParcelas_Reembolsoparcelasdiaspjuros_Z, false, includeNonInitialized);
            AddObjectProperty("ReembolsoId_N", gxTv_SdtReembolsoParcelas_Reembolsoid_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoParcelasValor_N", gxTv_SdtReembolsoParcelas_Reembolsoparcelasvalor_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoParcelasData_N", gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoParcelasObservacao_N", gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoParcelasCreatedAt_N", gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoParcelasTaxaValor_N", gxTv_SdtReembolsoParcelas_Reembolsoparcelastaxavalor_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoParcelasJurosValor_N", gxTv_SdtReembolsoParcelas_Reembolsoparcelasjurosvalor_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoParcelasDiasPJuros_N", gxTv_SdtReembolsoParcelas_Reembolsoparcelasdiaspjuros_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtReembolsoParcelas sdt )
      {
         if ( sdt.IsDirty("ReembolsoParcelasId") )
         {
            sdtIsNull = 0;
            gxTv_SdtReembolsoParcelas_Reembolsoparcelasid = sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelasid ;
         }
         if ( sdt.IsDirty("ReembolsoId") )
         {
            gxTv_SdtReembolsoParcelas_Reembolsoid_N = (short)(sdt.gxTv_SdtReembolsoParcelas_Reembolsoid_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoParcelas_Reembolsoid = sdt.gxTv_SdtReembolsoParcelas_Reembolsoid ;
         }
         if ( sdt.IsDirty("ReembolsoParcelasValor") )
         {
            gxTv_SdtReembolsoParcelas_Reembolsoparcelasvalor_N = (short)(sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelasvalor_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoParcelas_Reembolsoparcelasvalor = sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelasvalor ;
         }
         if ( sdt.IsDirty("ReembolsoParcelasData") )
         {
            gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata_N = (short)(sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata = sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata ;
         }
         if ( sdt.IsDirty("ReembolsoParcelasObservacao") )
         {
            gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao_N = (short)(sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao = sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao ;
         }
         if ( sdt.IsDirty("ReembolsoParcelasCreatedAt") )
         {
            gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat_N = (short)(sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat = sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat ;
         }
         if ( sdt.IsDirty("ReembolsoParcelasTaxaValor") )
         {
            gxTv_SdtReembolsoParcelas_Reembolsoparcelastaxavalor_N = (short)(sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelastaxavalor_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoParcelas_Reembolsoparcelastaxavalor = sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelastaxavalor ;
         }
         if ( sdt.IsDirty("ReembolsoParcelasJurosValor") )
         {
            gxTv_SdtReembolsoParcelas_Reembolsoparcelasjurosvalor_N = (short)(sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelasjurosvalor_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoParcelas_Reembolsoparcelasjurosvalor = sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelasjurosvalor ;
         }
         if ( sdt.IsDirty("ReembolsoParcelasDiasPJuros") )
         {
            gxTv_SdtReembolsoParcelas_Reembolsoparcelasdiaspjuros_N = (short)(sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelasdiaspjuros_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoParcelas_Reembolsoparcelasdiaspjuros = sdt.gxTv_SdtReembolsoParcelas_Reembolsoparcelasdiaspjuros ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ReembolsoParcelasId" )]
      [  XmlElement( ElementName = "ReembolsoParcelasId"   )]
      public int gxTpr_Reembolsoparcelasid
      {
         get {
            return gxTv_SdtReembolsoParcelas_Reembolsoparcelasid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtReembolsoParcelas_Reembolsoparcelasid != value )
            {
               gxTv_SdtReembolsoParcelas_Mode = "INS";
               this.gxTv_SdtReembolsoParcelas_Reembolsoparcelasid_Z_SetNull( );
               this.gxTv_SdtReembolsoParcelas_Reembolsoid_Z_SetNull( );
               this.gxTv_SdtReembolsoParcelas_Reembolsoparcelasvalor_Z_SetNull( );
               this.gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata_Z_SetNull( );
               this.gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao_Z_SetNull( );
               this.gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat_Z_SetNull( );
               this.gxTv_SdtReembolsoParcelas_Reembolsoparcelastaxavalor_Z_SetNull( );
               this.gxTv_SdtReembolsoParcelas_Reembolsoparcelasjurosvalor_Z_SetNull( );
               this.gxTv_SdtReembolsoParcelas_Reembolsoparcelasdiaspjuros_Z_SetNull( );
            }
            gxTv_SdtReembolsoParcelas_Reembolsoparcelasid = value;
            SetDirty("Reembolsoparcelasid");
         }

      }

      [  SoapElement( ElementName = "ReembolsoId" )]
      [  XmlElement( ElementName = "ReembolsoId"   )]
      public int gxTpr_Reembolsoid
      {
         get {
            return gxTv_SdtReembolsoParcelas_Reembolsoid ;
         }

         set {
            gxTv_SdtReembolsoParcelas_Reembolsoid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoParcelas_Reembolsoid = value;
            SetDirty("Reembolsoid");
         }

      }

      public void gxTv_SdtReembolsoParcelas_Reembolsoid_SetNull( )
      {
         gxTv_SdtReembolsoParcelas_Reembolsoid_N = 1;
         gxTv_SdtReembolsoParcelas_Reembolsoid = 0;
         SetDirty("Reembolsoid");
         return  ;
      }

      public bool gxTv_SdtReembolsoParcelas_Reembolsoid_IsNull( )
      {
         return (gxTv_SdtReembolsoParcelas_Reembolsoid_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoParcelasValor" )]
      [  XmlElement( ElementName = "ReembolsoParcelasValor"   )]
      public decimal gxTpr_Reembolsoparcelasvalor
      {
         get {
            return gxTv_SdtReembolsoParcelas_Reembolsoparcelasvalor ;
         }

         set {
            gxTv_SdtReembolsoParcelas_Reembolsoparcelasvalor_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoParcelas_Reembolsoparcelasvalor = value;
            SetDirty("Reembolsoparcelasvalor");
         }

      }

      public void gxTv_SdtReembolsoParcelas_Reembolsoparcelasvalor_SetNull( )
      {
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasvalor_N = 1;
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasvalor = 0;
         SetDirty("Reembolsoparcelasvalor");
         return  ;
      }

      public bool gxTv_SdtReembolsoParcelas_Reembolsoparcelasvalor_IsNull( )
      {
         return (gxTv_SdtReembolsoParcelas_Reembolsoparcelasvalor_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoParcelasData" )]
      [  XmlElement( ElementName = "ReembolsoParcelasData"  , IsNullable=true )]
      public string gxTpr_Reembolsoparcelasdata_Nullable
      {
         get {
            if ( gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata).value ;
         }

         set {
            gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata = DateTime.MinValue;
            else
               gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Reembolsoparcelasdata
      {
         get {
            return gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata ;
         }

         set {
            gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata = value;
            SetDirty("Reembolsoparcelasdata");
         }

      }

      public void gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata_SetNull( )
      {
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata_N = 1;
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata = (DateTime)(DateTime.MinValue);
         SetDirty("Reembolsoparcelasdata");
         return  ;
      }

      public bool gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata_IsNull( )
      {
         return (gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoParcelasObservacao" )]
      [  XmlElement( ElementName = "ReembolsoParcelasObservacao"   )]
      public string gxTpr_Reembolsoparcelasobservacao
      {
         get {
            return gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao ;
         }

         set {
            gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao = value;
            SetDirty("Reembolsoparcelasobservacao");
         }

      }

      public void gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao_SetNull( )
      {
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao_N = 1;
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao = "";
         SetDirty("Reembolsoparcelasobservacao");
         return  ;
      }

      public bool gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao_IsNull( )
      {
         return (gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoParcelasCreatedAt" )]
      [  XmlElement( ElementName = "ReembolsoParcelasCreatedAt"  , IsNullable=true )]
      public string gxTpr_Reembolsoparcelascreatedat_Nullable
      {
         get {
            if ( gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat).value ;
         }

         set {
            gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat = DateTime.MinValue;
            else
               gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Reembolsoparcelascreatedat
      {
         get {
            return gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat ;
         }

         set {
            gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat = value;
            SetDirty("Reembolsoparcelascreatedat");
         }

      }

      public void gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat_SetNull( )
      {
         gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat_N = 1;
         gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Reembolsoparcelascreatedat");
         return  ;
      }

      public bool gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat_IsNull( )
      {
         return (gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoParcelasTaxaValor" )]
      [  XmlElement( ElementName = "ReembolsoParcelasTaxaValor"   )]
      public decimal gxTpr_Reembolsoparcelastaxavalor
      {
         get {
            return gxTv_SdtReembolsoParcelas_Reembolsoparcelastaxavalor ;
         }

         set {
            gxTv_SdtReembolsoParcelas_Reembolsoparcelastaxavalor_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoParcelas_Reembolsoparcelastaxavalor = value;
            SetDirty("Reembolsoparcelastaxavalor");
         }

      }

      public void gxTv_SdtReembolsoParcelas_Reembolsoparcelastaxavalor_SetNull( )
      {
         gxTv_SdtReembolsoParcelas_Reembolsoparcelastaxavalor_N = 1;
         gxTv_SdtReembolsoParcelas_Reembolsoparcelastaxavalor = 0;
         SetDirty("Reembolsoparcelastaxavalor");
         return  ;
      }

      public bool gxTv_SdtReembolsoParcelas_Reembolsoparcelastaxavalor_IsNull( )
      {
         return (gxTv_SdtReembolsoParcelas_Reembolsoparcelastaxavalor_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoParcelasJurosValor" )]
      [  XmlElement( ElementName = "ReembolsoParcelasJurosValor"   )]
      public decimal gxTpr_Reembolsoparcelasjurosvalor
      {
         get {
            return gxTv_SdtReembolsoParcelas_Reembolsoparcelasjurosvalor ;
         }

         set {
            gxTv_SdtReembolsoParcelas_Reembolsoparcelasjurosvalor_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoParcelas_Reembolsoparcelasjurosvalor = value;
            SetDirty("Reembolsoparcelasjurosvalor");
         }

      }

      public void gxTv_SdtReembolsoParcelas_Reembolsoparcelasjurosvalor_SetNull( )
      {
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasjurosvalor_N = 1;
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasjurosvalor = 0;
         SetDirty("Reembolsoparcelasjurosvalor");
         return  ;
      }

      public bool gxTv_SdtReembolsoParcelas_Reembolsoparcelasjurosvalor_IsNull( )
      {
         return (gxTv_SdtReembolsoParcelas_Reembolsoparcelasjurosvalor_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoParcelasDiasPJuros" )]
      [  XmlElement( ElementName = "ReembolsoParcelasDiasPJuros"   )]
      public short gxTpr_Reembolsoparcelasdiaspjuros
      {
         get {
            return gxTv_SdtReembolsoParcelas_Reembolsoparcelasdiaspjuros ;
         }

         set {
            gxTv_SdtReembolsoParcelas_Reembolsoparcelasdiaspjuros_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoParcelas_Reembolsoparcelasdiaspjuros = value;
            SetDirty("Reembolsoparcelasdiaspjuros");
         }

      }

      public void gxTv_SdtReembolsoParcelas_Reembolsoparcelasdiaspjuros_SetNull( )
      {
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasdiaspjuros_N = 1;
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasdiaspjuros = 0;
         SetDirty("Reembolsoparcelasdiaspjuros");
         return  ;
      }

      public bool gxTv_SdtReembolsoParcelas_Reembolsoparcelasdiaspjuros_IsNull( )
      {
         return (gxTv_SdtReembolsoParcelas_Reembolsoparcelasdiaspjuros_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtReembolsoParcelas_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoParcelas_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtReembolsoParcelas_Mode_SetNull( )
      {
         gxTv_SdtReembolsoParcelas_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtReembolsoParcelas_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtReembolsoParcelas_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoParcelas_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtReembolsoParcelas_Initialized_SetNull( )
      {
         gxTv_SdtReembolsoParcelas_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtReembolsoParcelas_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoParcelasId_Z" )]
      [  XmlElement( ElementName = "ReembolsoParcelasId_Z"   )]
      public int gxTpr_Reembolsoparcelasid_Z
      {
         get {
            return gxTv_SdtReembolsoParcelas_Reembolsoparcelasid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoParcelas_Reembolsoparcelasid_Z = value;
            SetDirty("Reembolsoparcelasid_Z");
         }

      }

      public void gxTv_SdtReembolsoParcelas_Reembolsoparcelasid_Z_SetNull( )
      {
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasid_Z = 0;
         SetDirty("Reembolsoparcelasid_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoParcelas_Reembolsoparcelasid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoId_Z" )]
      [  XmlElement( ElementName = "ReembolsoId_Z"   )]
      public int gxTpr_Reembolsoid_Z
      {
         get {
            return gxTv_SdtReembolsoParcelas_Reembolsoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoParcelas_Reembolsoid_Z = value;
            SetDirty("Reembolsoid_Z");
         }

      }

      public void gxTv_SdtReembolsoParcelas_Reembolsoid_Z_SetNull( )
      {
         gxTv_SdtReembolsoParcelas_Reembolsoid_Z = 0;
         SetDirty("Reembolsoid_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoParcelas_Reembolsoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoParcelasValor_Z" )]
      [  XmlElement( ElementName = "ReembolsoParcelasValor_Z"   )]
      public decimal gxTpr_Reembolsoparcelasvalor_Z
      {
         get {
            return gxTv_SdtReembolsoParcelas_Reembolsoparcelasvalor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoParcelas_Reembolsoparcelasvalor_Z = value;
            SetDirty("Reembolsoparcelasvalor_Z");
         }

      }

      public void gxTv_SdtReembolsoParcelas_Reembolsoparcelasvalor_Z_SetNull( )
      {
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasvalor_Z = 0;
         SetDirty("Reembolsoparcelasvalor_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoParcelas_Reembolsoparcelasvalor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoParcelasData_Z" )]
      [  XmlElement( ElementName = "ReembolsoParcelasData_Z"  , IsNullable=true )]
      public string gxTpr_Reembolsoparcelasdata_Z_Nullable
      {
         get {
            if ( gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata_Z = DateTime.MinValue;
            else
               gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Reembolsoparcelasdata_Z
      {
         get {
            return gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata_Z = value;
            SetDirty("Reembolsoparcelasdata_Z");
         }

      }

      public void gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata_Z_SetNull( )
      {
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Reembolsoparcelasdata_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoParcelasObservacao_Z" )]
      [  XmlElement( ElementName = "ReembolsoParcelasObservacao_Z"   )]
      public string gxTpr_Reembolsoparcelasobservacao_Z
      {
         get {
            return gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao_Z = value;
            SetDirty("Reembolsoparcelasobservacao_Z");
         }

      }

      public void gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao_Z_SetNull( )
      {
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao_Z = "";
         SetDirty("Reembolsoparcelasobservacao_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoParcelasCreatedAt_Z" )]
      [  XmlElement( ElementName = "ReembolsoParcelasCreatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Reembolsoparcelascreatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Reembolsoparcelascreatedat_Z
      {
         get {
            return gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat_Z = value;
            SetDirty("Reembolsoparcelascreatedat_Z");
         }

      }

      public void gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat_Z_SetNull( )
      {
         gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Reembolsoparcelascreatedat_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoParcelasTaxaValor_Z" )]
      [  XmlElement( ElementName = "ReembolsoParcelasTaxaValor_Z"   )]
      public decimal gxTpr_Reembolsoparcelastaxavalor_Z
      {
         get {
            return gxTv_SdtReembolsoParcelas_Reembolsoparcelastaxavalor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoParcelas_Reembolsoparcelastaxavalor_Z = value;
            SetDirty("Reembolsoparcelastaxavalor_Z");
         }

      }

      public void gxTv_SdtReembolsoParcelas_Reembolsoparcelastaxavalor_Z_SetNull( )
      {
         gxTv_SdtReembolsoParcelas_Reembolsoparcelastaxavalor_Z = 0;
         SetDirty("Reembolsoparcelastaxavalor_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoParcelas_Reembolsoparcelastaxavalor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoParcelasJurosValor_Z" )]
      [  XmlElement( ElementName = "ReembolsoParcelasJurosValor_Z"   )]
      public decimal gxTpr_Reembolsoparcelasjurosvalor_Z
      {
         get {
            return gxTv_SdtReembolsoParcelas_Reembolsoparcelasjurosvalor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoParcelas_Reembolsoparcelasjurosvalor_Z = value;
            SetDirty("Reembolsoparcelasjurosvalor_Z");
         }

      }

      public void gxTv_SdtReembolsoParcelas_Reembolsoparcelasjurosvalor_Z_SetNull( )
      {
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasjurosvalor_Z = 0;
         SetDirty("Reembolsoparcelasjurosvalor_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoParcelas_Reembolsoparcelasjurosvalor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoParcelasDiasPJuros_Z" )]
      [  XmlElement( ElementName = "ReembolsoParcelasDiasPJuros_Z"   )]
      public short gxTpr_Reembolsoparcelasdiaspjuros_Z
      {
         get {
            return gxTv_SdtReembolsoParcelas_Reembolsoparcelasdiaspjuros_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoParcelas_Reembolsoparcelasdiaspjuros_Z = value;
            SetDirty("Reembolsoparcelasdiaspjuros_Z");
         }

      }

      public void gxTv_SdtReembolsoParcelas_Reembolsoparcelasdiaspjuros_Z_SetNull( )
      {
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasdiaspjuros_Z = 0;
         SetDirty("Reembolsoparcelasdiaspjuros_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoParcelas_Reembolsoparcelasdiaspjuros_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoId_N" )]
      [  XmlElement( ElementName = "ReembolsoId_N"   )]
      public short gxTpr_Reembolsoid_N
      {
         get {
            return gxTv_SdtReembolsoParcelas_Reembolsoid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoParcelas_Reembolsoid_N = value;
            SetDirty("Reembolsoid_N");
         }

      }

      public void gxTv_SdtReembolsoParcelas_Reembolsoid_N_SetNull( )
      {
         gxTv_SdtReembolsoParcelas_Reembolsoid_N = 0;
         SetDirty("Reembolsoid_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoParcelas_Reembolsoid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoParcelasValor_N" )]
      [  XmlElement( ElementName = "ReembolsoParcelasValor_N"   )]
      public short gxTpr_Reembolsoparcelasvalor_N
      {
         get {
            return gxTv_SdtReembolsoParcelas_Reembolsoparcelasvalor_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoParcelas_Reembolsoparcelasvalor_N = value;
            SetDirty("Reembolsoparcelasvalor_N");
         }

      }

      public void gxTv_SdtReembolsoParcelas_Reembolsoparcelasvalor_N_SetNull( )
      {
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasvalor_N = 0;
         SetDirty("Reembolsoparcelasvalor_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoParcelas_Reembolsoparcelasvalor_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoParcelasData_N" )]
      [  XmlElement( ElementName = "ReembolsoParcelasData_N"   )]
      public short gxTpr_Reembolsoparcelasdata_N
      {
         get {
            return gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata_N = value;
            SetDirty("Reembolsoparcelasdata_N");
         }

      }

      public void gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata_N_SetNull( )
      {
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata_N = 0;
         SetDirty("Reembolsoparcelasdata_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoParcelasObservacao_N" )]
      [  XmlElement( ElementName = "ReembolsoParcelasObservacao_N"   )]
      public short gxTpr_Reembolsoparcelasobservacao_N
      {
         get {
            return gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao_N = value;
            SetDirty("Reembolsoparcelasobservacao_N");
         }

      }

      public void gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao_N_SetNull( )
      {
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao_N = 0;
         SetDirty("Reembolsoparcelasobservacao_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoParcelasCreatedAt_N" )]
      [  XmlElement( ElementName = "ReembolsoParcelasCreatedAt_N"   )]
      public short gxTpr_Reembolsoparcelascreatedat_N
      {
         get {
            return gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat_N = value;
            SetDirty("Reembolsoparcelascreatedat_N");
         }

      }

      public void gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat_N_SetNull( )
      {
         gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat_N = 0;
         SetDirty("Reembolsoparcelascreatedat_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoParcelasTaxaValor_N" )]
      [  XmlElement( ElementName = "ReembolsoParcelasTaxaValor_N"   )]
      public short gxTpr_Reembolsoparcelastaxavalor_N
      {
         get {
            return gxTv_SdtReembolsoParcelas_Reembolsoparcelastaxavalor_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoParcelas_Reembolsoparcelastaxavalor_N = value;
            SetDirty("Reembolsoparcelastaxavalor_N");
         }

      }

      public void gxTv_SdtReembolsoParcelas_Reembolsoparcelastaxavalor_N_SetNull( )
      {
         gxTv_SdtReembolsoParcelas_Reembolsoparcelastaxavalor_N = 0;
         SetDirty("Reembolsoparcelastaxavalor_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoParcelas_Reembolsoparcelastaxavalor_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoParcelasJurosValor_N" )]
      [  XmlElement( ElementName = "ReembolsoParcelasJurosValor_N"   )]
      public short gxTpr_Reembolsoparcelasjurosvalor_N
      {
         get {
            return gxTv_SdtReembolsoParcelas_Reembolsoparcelasjurosvalor_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoParcelas_Reembolsoparcelasjurosvalor_N = value;
            SetDirty("Reembolsoparcelasjurosvalor_N");
         }

      }

      public void gxTv_SdtReembolsoParcelas_Reembolsoparcelasjurosvalor_N_SetNull( )
      {
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasjurosvalor_N = 0;
         SetDirty("Reembolsoparcelasjurosvalor_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoParcelas_Reembolsoparcelasjurosvalor_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoParcelasDiasPJuros_N" )]
      [  XmlElement( ElementName = "ReembolsoParcelasDiasPJuros_N"   )]
      public short gxTpr_Reembolsoparcelasdiaspjuros_N
      {
         get {
            return gxTv_SdtReembolsoParcelas_Reembolsoparcelasdiaspjuros_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoParcelas_Reembolsoparcelasdiaspjuros_N = value;
            SetDirty("Reembolsoparcelasdiaspjuros_N");
         }

      }

      public void gxTv_SdtReembolsoParcelas_Reembolsoparcelasdiaspjuros_N_SetNull( )
      {
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasdiaspjuros_N = 0;
         SetDirty("Reembolsoparcelasdiaspjuros_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoParcelas_Reembolsoparcelasdiaspjuros_N_IsNull( )
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
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata = DateTime.MinValue;
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao = "";
         gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtReembolsoParcelas_Mode = "";
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata_Z = DateTime.MinValue;
         gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao_Z = "";
         gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat_Z = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "reembolsoparcelas", "GeneXus.Programs.reembolsoparcelas_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtReembolsoParcelas_Reembolsoparcelasdiaspjuros ;
      private short gxTv_SdtReembolsoParcelas_Initialized ;
      private short gxTv_SdtReembolsoParcelas_Reembolsoparcelasdiaspjuros_Z ;
      private short gxTv_SdtReembolsoParcelas_Reembolsoid_N ;
      private short gxTv_SdtReembolsoParcelas_Reembolsoparcelasvalor_N ;
      private short gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata_N ;
      private short gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao_N ;
      private short gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat_N ;
      private short gxTv_SdtReembolsoParcelas_Reembolsoparcelastaxavalor_N ;
      private short gxTv_SdtReembolsoParcelas_Reembolsoparcelasjurosvalor_N ;
      private short gxTv_SdtReembolsoParcelas_Reembolsoparcelasdiaspjuros_N ;
      private int gxTv_SdtReembolsoParcelas_Reembolsoparcelasid ;
      private int gxTv_SdtReembolsoParcelas_Reembolsoid ;
      private int gxTv_SdtReembolsoParcelas_Reembolsoparcelasid_Z ;
      private int gxTv_SdtReembolsoParcelas_Reembolsoid_Z ;
      private decimal gxTv_SdtReembolsoParcelas_Reembolsoparcelasvalor ;
      private decimal gxTv_SdtReembolsoParcelas_Reembolsoparcelastaxavalor ;
      private decimal gxTv_SdtReembolsoParcelas_Reembolsoparcelasjurosvalor ;
      private decimal gxTv_SdtReembolsoParcelas_Reembolsoparcelasvalor_Z ;
      private decimal gxTv_SdtReembolsoParcelas_Reembolsoparcelastaxavalor_Z ;
      private decimal gxTv_SdtReembolsoParcelas_Reembolsoparcelasjurosvalor_Z ;
      private string gxTv_SdtReembolsoParcelas_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat ;
      private DateTime gxTv_SdtReembolsoParcelas_Reembolsoparcelascreatedat_Z ;
      private DateTime datetime_STZ ;
      private DateTime gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata ;
      private DateTime gxTv_SdtReembolsoParcelas_Reembolsoparcelasdata_Z ;
      private string gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao ;
      private string gxTv_SdtReembolsoParcelas_Reembolsoparcelasobservacao_Z ;
   }

   [DataContract(Name = @"ReembolsoParcelas", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtReembolsoParcelas_RESTInterface : GxGenericCollectionItem<SdtReembolsoParcelas>
   {
      public SdtReembolsoParcelas_RESTInterface( ) : base()
      {
      }

      public SdtReembolsoParcelas_RESTInterface( SdtReembolsoParcelas psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ReembolsoParcelasId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Reembolsoparcelasid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Reembolsoparcelasid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Reembolsoparcelasid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ReembolsoId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Reembolsoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Reembolsoid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Reembolsoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ReembolsoParcelasValor" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Reembolsoparcelasvalor
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Reembolsoparcelasvalor, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Reembolsoparcelasvalor = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ReembolsoParcelasData" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Reembolsoparcelasdata
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Reembolsoparcelasdata) ;
         }

         set {
            sdt.gxTpr_Reembolsoparcelasdata = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "ReembolsoParcelasObservacao" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Reembolsoparcelasobservacao
      {
         get {
            return sdt.gxTpr_Reembolsoparcelasobservacao ;
         }

         set {
            sdt.gxTpr_Reembolsoparcelasobservacao = value;
         }

      }

      [DataMember( Name = "ReembolsoParcelasCreatedAt" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Reembolsoparcelascreatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Reembolsoparcelascreatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Reembolsoparcelascreatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "ReembolsoParcelasTaxaValor" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Reembolsoparcelastaxavalor
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Reembolsoparcelastaxavalor, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Reembolsoparcelastaxavalor = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ReembolsoParcelasJurosValor" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Reembolsoparcelasjurosvalor
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Reembolsoparcelasjurosvalor, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Reembolsoparcelasjurosvalor = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ReembolsoParcelasDiasPJuros" , Order = 8 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Reembolsoparcelasdiaspjuros
      {
         get {
            return sdt.gxTpr_Reembolsoparcelasdiaspjuros ;
         }

         set {
            sdt.gxTpr_Reembolsoparcelasdiaspjuros = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtReembolsoParcelas sdt
      {
         get {
            return (SdtReembolsoParcelas)Sdt ;
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
            sdt = new SdtReembolsoParcelas() ;
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

   [DataContract(Name = @"ReembolsoParcelas", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtReembolsoParcelas_RESTLInterface : GxGenericCollectionItem<SdtReembolsoParcelas>
   {
      public SdtReembolsoParcelas_RESTLInterface( ) : base()
      {
      }

      public SdtReembolsoParcelas_RESTLInterface( SdtReembolsoParcelas psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ReembolsoParcelasValor" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Reembolsoparcelasvalor
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Reembolsoparcelasvalor, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Reembolsoparcelasvalor = NumberUtil.Val( value, ".");
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

      public SdtReembolsoParcelas sdt
      {
         get {
            return (SdtReembolsoParcelas)Sdt ;
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
            sdt = new SdtReembolsoParcelas() ;
         }
      }

   }

}
