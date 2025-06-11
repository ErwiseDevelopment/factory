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
   [XmlRoot(ElementName = "Taxas" )]
   [XmlType(TypeName =  "Taxas" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtTaxas : GxSilentTrnSdt
   {
      public SdtTaxas( )
      {
      }

      public SdtTaxas( IGxContext context )
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

      public void Load( int AV863TaxasId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV863TaxasId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"TaxasId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Taxas");
         metadata.Set("BT", "Taxas");
         metadata.Set("PK", "[ \"TaxasId\" ]");
         metadata.Set("PKAssigned", "[ \"TaxasId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"SecUserId\" ],\"FKMap\":[ \"TaxasCreatedBy-SecUserId\" ] },{ \"FK\":[ \"SecUserId\" ],\"FKMap\":[ \"TaxasUpdatedBy-SecUserId\" ] } ]");
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
         state.Add("gxTpr_Taxasid_Z");
         state.Add("gxTpr_Taxaspercentual_Z");
         state.Add("gxTpr_Taxaspercentualanual_Z");
         state.Add("gxTpr_Taxasvalorminimo_Z");
         state.Add("gxTpr_Taxascreatedat_Z_Nullable");
         state.Add("gxTpr_Taxasupdatedat_Z_Nullable");
         state.Add("gxTpr_Taxascreatedby_Z");
         state.Add("gxTpr_Taxascreatedname_Z");
         state.Add("gxTpr_Taxasupdatedby_Z");
         state.Add("gxTpr_Taxasupdatedname_Z");
         state.Add("gxTpr_Taxaspercentual_N");
         state.Add("gxTpr_Taxaspercentualanual_N");
         state.Add("gxTpr_Taxasvalorminimo_N");
         state.Add("gxTpr_Taxascreatedat_N");
         state.Add("gxTpr_Taxasupdatedat_N");
         state.Add("gxTpr_Taxascreatedby_N");
         state.Add("gxTpr_Taxascreatedname_N");
         state.Add("gxTpr_Taxasupdatedby_N");
         state.Add("gxTpr_Taxasupdatedname_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTaxas sdt;
         sdt = (SdtTaxas)(source);
         gxTv_SdtTaxas_Taxasid = sdt.gxTv_SdtTaxas_Taxasid ;
         gxTv_SdtTaxas_Taxaspercentual = sdt.gxTv_SdtTaxas_Taxaspercentual ;
         gxTv_SdtTaxas_Taxaspercentualanual = sdt.gxTv_SdtTaxas_Taxaspercentualanual ;
         gxTv_SdtTaxas_Taxasvalorminimo = sdt.gxTv_SdtTaxas_Taxasvalorminimo ;
         gxTv_SdtTaxas_Taxascreatedat = sdt.gxTv_SdtTaxas_Taxascreatedat ;
         gxTv_SdtTaxas_Taxasupdatedat = sdt.gxTv_SdtTaxas_Taxasupdatedat ;
         gxTv_SdtTaxas_Taxascreatedby = sdt.gxTv_SdtTaxas_Taxascreatedby ;
         gxTv_SdtTaxas_Taxascreatedname = sdt.gxTv_SdtTaxas_Taxascreatedname ;
         gxTv_SdtTaxas_Taxasupdatedby = sdt.gxTv_SdtTaxas_Taxasupdatedby ;
         gxTv_SdtTaxas_Taxasupdatedname = sdt.gxTv_SdtTaxas_Taxasupdatedname ;
         gxTv_SdtTaxas_Mode = sdt.gxTv_SdtTaxas_Mode ;
         gxTv_SdtTaxas_Initialized = sdt.gxTv_SdtTaxas_Initialized ;
         gxTv_SdtTaxas_Taxasid_Z = sdt.gxTv_SdtTaxas_Taxasid_Z ;
         gxTv_SdtTaxas_Taxaspercentual_Z = sdt.gxTv_SdtTaxas_Taxaspercentual_Z ;
         gxTv_SdtTaxas_Taxaspercentualanual_Z = sdt.gxTv_SdtTaxas_Taxaspercentualanual_Z ;
         gxTv_SdtTaxas_Taxasvalorminimo_Z = sdt.gxTv_SdtTaxas_Taxasvalorminimo_Z ;
         gxTv_SdtTaxas_Taxascreatedat_Z = sdt.gxTv_SdtTaxas_Taxascreatedat_Z ;
         gxTv_SdtTaxas_Taxasupdatedat_Z = sdt.gxTv_SdtTaxas_Taxasupdatedat_Z ;
         gxTv_SdtTaxas_Taxascreatedby_Z = sdt.gxTv_SdtTaxas_Taxascreatedby_Z ;
         gxTv_SdtTaxas_Taxascreatedname_Z = sdt.gxTv_SdtTaxas_Taxascreatedname_Z ;
         gxTv_SdtTaxas_Taxasupdatedby_Z = sdt.gxTv_SdtTaxas_Taxasupdatedby_Z ;
         gxTv_SdtTaxas_Taxasupdatedname_Z = sdt.gxTv_SdtTaxas_Taxasupdatedname_Z ;
         gxTv_SdtTaxas_Taxaspercentual_N = sdt.gxTv_SdtTaxas_Taxaspercentual_N ;
         gxTv_SdtTaxas_Taxaspercentualanual_N = sdt.gxTv_SdtTaxas_Taxaspercentualanual_N ;
         gxTv_SdtTaxas_Taxasvalorminimo_N = sdt.gxTv_SdtTaxas_Taxasvalorminimo_N ;
         gxTv_SdtTaxas_Taxascreatedat_N = sdt.gxTv_SdtTaxas_Taxascreatedat_N ;
         gxTv_SdtTaxas_Taxasupdatedat_N = sdt.gxTv_SdtTaxas_Taxasupdatedat_N ;
         gxTv_SdtTaxas_Taxascreatedby_N = sdt.gxTv_SdtTaxas_Taxascreatedby_N ;
         gxTv_SdtTaxas_Taxascreatedname_N = sdt.gxTv_SdtTaxas_Taxascreatedname_N ;
         gxTv_SdtTaxas_Taxasupdatedby_N = sdt.gxTv_SdtTaxas_Taxasupdatedby_N ;
         gxTv_SdtTaxas_Taxasupdatedname_N = sdt.gxTv_SdtTaxas_Taxasupdatedname_N ;
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
         AddObjectProperty("TaxasId", gxTv_SdtTaxas_Taxasid, false, includeNonInitialized);
         AddObjectProperty("TaxasPercentual", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTaxas_Taxaspercentual, 16, 4)), false, includeNonInitialized);
         AddObjectProperty("TaxasPercentual_N", gxTv_SdtTaxas_Taxaspercentual_N, false, includeNonInitialized);
         AddObjectProperty("TaxasPercentualAnual", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTaxas_Taxaspercentualanual, 16, 4)), false, includeNonInitialized);
         AddObjectProperty("TaxasPercentualAnual_N", gxTv_SdtTaxas_Taxaspercentualanual_N, false, includeNonInitialized);
         AddObjectProperty("TaxasValorMinimo", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTaxas_Taxasvalorminimo, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("TaxasValorMinimo_N", gxTv_SdtTaxas_Taxasvalorminimo_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtTaxas_Taxascreatedat;
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
         AddObjectProperty("TaxasCreatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("TaxasCreatedAt_N", gxTv_SdtTaxas_Taxascreatedat_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtTaxas_Taxasupdatedat;
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
         AddObjectProperty("TaxasUpdatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("TaxasUpdatedAt_N", gxTv_SdtTaxas_Taxasupdatedat_N, false, includeNonInitialized);
         AddObjectProperty("TaxasCreatedBy", gxTv_SdtTaxas_Taxascreatedby, false, includeNonInitialized);
         AddObjectProperty("TaxasCreatedBy_N", gxTv_SdtTaxas_Taxascreatedby_N, false, includeNonInitialized);
         AddObjectProperty("TaxasCreatedName", gxTv_SdtTaxas_Taxascreatedname, false, includeNonInitialized);
         AddObjectProperty("TaxasCreatedName_N", gxTv_SdtTaxas_Taxascreatedname_N, false, includeNonInitialized);
         AddObjectProperty("TaxasUpdatedBy", gxTv_SdtTaxas_Taxasupdatedby, false, includeNonInitialized);
         AddObjectProperty("TaxasUpdatedBy_N", gxTv_SdtTaxas_Taxasupdatedby_N, false, includeNonInitialized);
         AddObjectProperty("TaxasUpdatedName", gxTv_SdtTaxas_Taxasupdatedname, false, includeNonInitialized);
         AddObjectProperty("TaxasUpdatedName_N", gxTv_SdtTaxas_Taxasupdatedname_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTaxas_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTaxas_Initialized, false, includeNonInitialized);
            AddObjectProperty("TaxasId_Z", gxTv_SdtTaxas_Taxasid_Z, false, includeNonInitialized);
            AddObjectProperty("TaxasPercentual_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTaxas_Taxaspercentual_Z, 16, 4)), false, includeNonInitialized);
            AddObjectProperty("TaxasPercentualAnual_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTaxas_Taxaspercentualanual_Z, 16, 4)), false, includeNonInitialized);
            AddObjectProperty("TaxasValorMinimo_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtTaxas_Taxasvalorminimo_Z, 18, 2)), false, includeNonInitialized);
            datetime_STZ = gxTv_SdtTaxas_Taxascreatedat_Z;
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
            AddObjectProperty("TaxasCreatedAt_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtTaxas_Taxasupdatedat_Z;
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
            AddObjectProperty("TaxasUpdatedAt_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("TaxasCreatedBy_Z", gxTv_SdtTaxas_Taxascreatedby_Z, false, includeNonInitialized);
            AddObjectProperty("TaxasCreatedName_Z", gxTv_SdtTaxas_Taxascreatedname_Z, false, includeNonInitialized);
            AddObjectProperty("TaxasUpdatedBy_Z", gxTv_SdtTaxas_Taxasupdatedby_Z, false, includeNonInitialized);
            AddObjectProperty("TaxasUpdatedName_Z", gxTv_SdtTaxas_Taxasupdatedname_Z, false, includeNonInitialized);
            AddObjectProperty("TaxasPercentual_N", gxTv_SdtTaxas_Taxaspercentual_N, false, includeNonInitialized);
            AddObjectProperty("TaxasPercentualAnual_N", gxTv_SdtTaxas_Taxaspercentualanual_N, false, includeNonInitialized);
            AddObjectProperty("TaxasValorMinimo_N", gxTv_SdtTaxas_Taxasvalorminimo_N, false, includeNonInitialized);
            AddObjectProperty("TaxasCreatedAt_N", gxTv_SdtTaxas_Taxascreatedat_N, false, includeNonInitialized);
            AddObjectProperty("TaxasUpdatedAt_N", gxTv_SdtTaxas_Taxasupdatedat_N, false, includeNonInitialized);
            AddObjectProperty("TaxasCreatedBy_N", gxTv_SdtTaxas_Taxascreatedby_N, false, includeNonInitialized);
            AddObjectProperty("TaxasCreatedName_N", gxTv_SdtTaxas_Taxascreatedname_N, false, includeNonInitialized);
            AddObjectProperty("TaxasUpdatedBy_N", gxTv_SdtTaxas_Taxasupdatedby_N, false, includeNonInitialized);
            AddObjectProperty("TaxasUpdatedName_N", gxTv_SdtTaxas_Taxasupdatedname_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTaxas sdt )
      {
         if ( sdt.IsDirty("TaxasId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxasid = sdt.gxTv_SdtTaxas_Taxasid ;
         }
         if ( sdt.IsDirty("TaxasPercentual") )
         {
            gxTv_SdtTaxas_Taxaspercentual_N = (short)(sdt.gxTv_SdtTaxas_Taxaspercentual_N);
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxaspercentual = sdt.gxTv_SdtTaxas_Taxaspercentual ;
         }
         if ( sdt.IsDirty("TaxasPercentualAnual") )
         {
            gxTv_SdtTaxas_Taxaspercentualanual_N = (short)(sdt.gxTv_SdtTaxas_Taxaspercentualanual_N);
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxaspercentualanual = sdt.gxTv_SdtTaxas_Taxaspercentualanual ;
         }
         if ( sdt.IsDirty("TaxasValorMinimo") )
         {
            gxTv_SdtTaxas_Taxasvalorminimo_N = (short)(sdt.gxTv_SdtTaxas_Taxasvalorminimo_N);
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxasvalorminimo = sdt.gxTv_SdtTaxas_Taxasvalorminimo ;
         }
         if ( sdt.IsDirty("TaxasCreatedAt") )
         {
            gxTv_SdtTaxas_Taxascreatedat_N = (short)(sdt.gxTv_SdtTaxas_Taxascreatedat_N);
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxascreatedat = sdt.gxTv_SdtTaxas_Taxascreatedat ;
         }
         if ( sdt.IsDirty("TaxasUpdatedAt") )
         {
            gxTv_SdtTaxas_Taxasupdatedat_N = (short)(sdt.gxTv_SdtTaxas_Taxasupdatedat_N);
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxasupdatedat = sdt.gxTv_SdtTaxas_Taxasupdatedat ;
         }
         if ( sdt.IsDirty("TaxasCreatedBy") )
         {
            gxTv_SdtTaxas_Taxascreatedby_N = (short)(sdt.gxTv_SdtTaxas_Taxascreatedby_N);
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxascreatedby = sdt.gxTv_SdtTaxas_Taxascreatedby ;
         }
         if ( sdt.IsDirty("TaxasCreatedName") )
         {
            gxTv_SdtTaxas_Taxascreatedname_N = (short)(sdt.gxTv_SdtTaxas_Taxascreatedname_N);
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxascreatedname = sdt.gxTv_SdtTaxas_Taxascreatedname ;
         }
         if ( sdt.IsDirty("TaxasUpdatedBy") )
         {
            gxTv_SdtTaxas_Taxasupdatedby_N = (short)(sdt.gxTv_SdtTaxas_Taxasupdatedby_N);
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxasupdatedby = sdt.gxTv_SdtTaxas_Taxasupdatedby ;
         }
         if ( sdt.IsDirty("TaxasUpdatedName") )
         {
            gxTv_SdtTaxas_Taxasupdatedname_N = (short)(sdt.gxTv_SdtTaxas_Taxasupdatedname_N);
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxasupdatedname = sdt.gxTv_SdtTaxas_Taxasupdatedname ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "TaxasId" )]
      [  XmlElement( ElementName = "TaxasId"   )]
      public int gxTpr_Taxasid
      {
         get {
            return gxTv_SdtTaxas_Taxasid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTaxas_Taxasid != value )
            {
               gxTv_SdtTaxas_Mode = "INS";
               this.gxTv_SdtTaxas_Taxasid_Z_SetNull( );
               this.gxTv_SdtTaxas_Taxaspercentual_Z_SetNull( );
               this.gxTv_SdtTaxas_Taxaspercentualanual_Z_SetNull( );
               this.gxTv_SdtTaxas_Taxasvalorminimo_Z_SetNull( );
               this.gxTv_SdtTaxas_Taxascreatedat_Z_SetNull( );
               this.gxTv_SdtTaxas_Taxasupdatedat_Z_SetNull( );
               this.gxTv_SdtTaxas_Taxascreatedby_Z_SetNull( );
               this.gxTv_SdtTaxas_Taxascreatedname_Z_SetNull( );
               this.gxTv_SdtTaxas_Taxasupdatedby_Z_SetNull( );
               this.gxTv_SdtTaxas_Taxasupdatedname_Z_SetNull( );
            }
            gxTv_SdtTaxas_Taxasid = value;
            SetDirty("Taxasid");
         }

      }

      [  SoapElement( ElementName = "TaxasPercentual" )]
      [  XmlElement( ElementName = "TaxasPercentual"   )]
      public decimal gxTpr_Taxaspercentual
      {
         get {
            return gxTv_SdtTaxas_Taxaspercentual ;
         }

         set {
            gxTv_SdtTaxas_Taxaspercentual_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxaspercentual = value;
            SetDirty("Taxaspercentual");
         }

      }

      public void gxTv_SdtTaxas_Taxaspercentual_SetNull( )
      {
         gxTv_SdtTaxas_Taxaspercentual_N = 1;
         gxTv_SdtTaxas_Taxaspercentual = 0;
         SetDirty("Taxaspercentual");
         return  ;
      }

      public bool gxTv_SdtTaxas_Taxaspercentual_IsNull( )
      {
         return (gxTv_SdtTaxas_Taxaspercentual_N==1) ;
      }

      [  SoapElement( ElementName = "TaxasPercentualAnual" )]
      [  XmlElement( ElementName = "TaxasPercentualAnual"   )]
      public decimal gxTpr_Taxaspercentualanual
      {
         get {
            return gxTv_SdtTaxas_Taxaspercentualanual ;
         }

         set {
            gxTv_SdtTaxas_Taxaspercentualanual_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxaspercentualanual = value;
            SetDirty("Taxaspercentualanual");
         }

      }

      public void gxTv_SdtTaxas_Taxaspercentualanual_SetNull( )
      {
         gxTv_SdtTaxas_Taxaspercentualanual_N = 1;
         gxTv_SdtTaxas_Taxaspercentualanual = 0;
         SetDirty("Taxaspercentualanual");
         return  ;
      }

      public bool gxTv_SdtTaxas_Taxaspercentualanual_IsNull( )
      {
         return (gxTv_SdtTaxas_Taxaspercentualanual_N==1) ;
      }

      [  SoapElement( ElementName = "TaxasValorMinimo" )]
      [  XmlElement( ElementName = "TaxasValorMinimo"   )]
      public decimal gxTpr_Taxasvalorminimo
      {
         get {
            return gxTv_SdtTaxas_Taxasvalorminimo ;
         }

         set {
            gxTv_SdtTaxas_Taxasvalorminimo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxasvalorminimo = value;
            SetDirty("Taxasvalorminimo");
         }

      }

      public void gxTv_SdtTaxas_Taxasvalorminimo_SetNull( )
      {
         gxTv_SdtTaxas_Taxasvalorminimo_N = 1;
         gxTv_SdtTaxas_Taxasvalorminimo = 0;
         SetDirty("Taxasvalorminimo");
         return  ;
      }

      public bool gxTv_SdtTaxas_Taxasvalorminimo_IsNull( )
      {
         return (gxTv_SdtTaxas_Taxasvalorminimo_N==1) ;
      }

      [  SoapElement( ElementName = "TaxasCreatedAt" )]
      [  XmlElement( ElementName = "TaxasCreatedAt"  , IsNullable=true )]
      public string gxTpr_Taxascreatedat_Nullable
      {
         get {
            if ( gxTv_SdtTaxas_Taxascreatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTaxas_Taxascreatedat).value ;
         }

         set {
            gxTv_SdtTaxas_Taxascreatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTaxas_Taxascreatedat = DateTime.MinValue;
            else
               gxTv_SdtTaxas_Taxascreatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Taxascreatedat
      {
         get {
            return gxTv_SdtTaxas_Taxascreatedat ;
         }

         set {
            gxTv_SdtTaxas_Taxascreatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxascreatedat = value;
            SetDirty("Taxascreatedat");
         }

      }

      public void gxTv_SdtTaxas_Taxascreatedat_SetNull( )
      {
         gxTv_SdtTaxas_Taxascreatedat_N = 1;
         gxTv_SdtTaxas_Taxascreatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Taxascreatedat");
         return  ;
      }

      public bool gxTv_SdtTaxas_Taxascreatedat_IsNull( )
      {
         return (gxTv_SdtTaxas_Taxascreatedat_N==1) ;
      }

      [  SoapElement( ElementName = "TaxasUpdatedAt" )]
      [  XmlElement( ElementName = "TaxasUpdatedAt"  , IsNullable=true )]
      public string gxTpr_Taxasupdatedat_Nullable
      {
         get {
            if ( gxTv_SdtTaxas_Taxasupdatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTaxas_Taxasupdatedat).value ;
         }

         set {
            gxTv_SdtTaxas_Taxasupdatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTaxas_Taxasupdatedat = DateTime.MinValue;
            else
               gxTv_SdtTaxas_Taxasupdatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Taxasupdatedat
      {
         get {
            return gxTv_SdtTaxas_Taxasupdatedat ;
         }

         set {
            gxTv_SdtTaxas_Taxasupdatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxasupdatedat = value;
            SetDirty("Taxasupdatedat");
         }

      }

      public void gxTv_SdtTaxas_Taxasupdatedat_SetNull( )
      {
         gxTv_SdtTaxas_Taxasupdatedat_N = 1;
         gxTv_SdtTaxas_Taxasupdatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Taxasupdatedat");
         return  ;
      }

      public bool gxTv_SdtTaxas_Taxasupdatedat_IsNull( )
      {
         return (gxTv_SdtTaxas_Taxasupdatedat_N==1) ;
      }

      [  SoapElement( ElementName = "TaxasCreatedBy" )]
      [  XmlElement( ElementName = "TaxasCreatedBy"   )]
      public short gxTpr_Taxascreatedby
      {
         get {
            return gxTv_SdtTaxas_Taxascreatedby ;
         }

         set {
            gxTv_SdtTaxas_Taxascreatedby_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxascreatedby = value;
            SetDirty("Taxascreatedby");
         }

      }

      public void gxTv_SdtTaxas_Taxascreatedby_SetNull( )
      {
         gxTv_SdtTaxas_Taxascreatedby_N = 1;
         gxTv_SdtTaxas_Taxascreatedby = 0;
         SetDirty("Taxascreatedby");
         return  ;
      }

      public bool gxTv_SdtTaxas_Taxascreatedby_IsNull( )
      {
         return (gxTv_SdtTaxas_Taxascreatedby_N==1) ;
      }

      [  SoapElement( ElementName = "TaxasCreatedName" )]
      [  XmlElement( ElementName = "TaxasCreatedName"   )]
      public string gxTpr_Taxascreatedname
      {
         get {
            return gxTv_SdtTaxas_Taxascreatedname ;
         }

         set {
            gxTv_SdtTaxas_Taxascreatedname_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxascreatedname = value;
            SetDirty("Taxascreatedname");
         }

      }

      public void gxTv_SdtTaxas_Taxascreatedname_SetNull( )
      {
         gxTv_SdtTaxas_Taxascreatedname_N = 1;
         gxTv_SdtTaxas_Taxascreatedname = "";
         SetDirty("Taxascreatedname");
         return  ;
      }

      public bool gxTv_SdtTaxas_Taxascreatedname_IsNull( )
      {
         return (gxTv_SdtTaxas_Taxascreatedname_N==1) ;
      }

      [  SoapElement( ElementName = "TaxasUpdatedBy" )]
      [  XmlElement( ElementName = "TaxasUpdatedBy"   )]
      public short gxTpr_Taxasupdatedby
      {
         get {
            return gxTv_SdtTaxas_Taxasupdatedby ;
         }

         set {
            gxTv_SdtTaxas_Taxasupdatedby_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxasupdatedby = value;
            SetDirty("Taxasupdatedby");
         }

      }

      public void gxTv_SdtTaxas_Taxasupdatedby_SetNull( )
      {
         gxTv_SdtTaxas_Taxasupdatedby_N = 1;
         gxTv_SdtTaxas_Taxasupdatedby = 0;
         SetDirty("Taxasupdatedby");
         return  ;
      }

      public bool gxTv_SdtTaxas_Taxasupdatedby_IsNull( )
      {
         return (gxTv_SdtTaxas_Taxasupdatedby_N==1) ;
      }

      [  SoapElement( ElementName = "TaxasUpdatedName" )]
      [  XmlElement( ElementName = "TaxasUpdatedName"   )]
      public string gxTpr_Taxasupdatedname
      {
         get {
            return gxTv_SdtTaxas_Taxasupdatedname ;
         }

         set {
            gxTv_SdtTaxas_Taxasupdatedname_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxasupdatedname = value;
            SetDirty("Taxasupdatedname");
         }

      }

      public void gxTv_SdtTaxas_Taxasupdatedname_SetNull( )
      {
         gxTv_SdtTaxas_Taxasupdatedname_N = 1;
         gxTv_SdtTaxas_Taxasupdatedname = "";
         SetDirty("Taxasupdatedname");
         return  ;
      }

      public bool gxTv_SdtTaxas_Taxasupdatedname_IsNull( )
      {
         return (gxTv_SdtTaxas_Taxasupdatedname_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTaxas_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTaxas_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTaxas_Mode_SetNull( )
      {
         gxTv_SdtTaxas_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTaxas_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTaxas_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTaxas_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTaxas_Initialized_SetNull( )
      {
         gxTv_SdtTaxas_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTaxas_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TaxasId_Z" )]
      [  XmlElement( ElementName = "TaxasId_Z"   )]
      public int gxTpr_Taxasid_Z
      {
         get {
            return gxTv_SdtTaxas_Taxasid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxasid_Z = value;
            SetDirty("Taxasid_Z");
         }

      }

      public void gxTv_SdtTaxas_Taxasid_Z_SetNull( )
      {
         gxTv_SdtTaxas_Taxasid_Z = 0;
         SetDirty("Taxasid_Z");
         return  ;
      }

      public bool gxTv_SdtTaxas_Taxasid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TaxasPercentual_Z" )]
      [  XmlElement( ElementName = "TaxasPercentual_Z"   )]
      public decimal gxTpr_Taxaspercentual_Z
      {
         get {
            return gxTv_SdtTaxas_Taxaspercentual_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxaspercentual_Z = value;
            SetDirty("Taxaspercentual_Z");
         }

      }

      public void gxTv_SdtTaxas_Taxaspercentual_Z_SetNull( )
      {
         gxTv_SdtTaxas_Taxaspercentual_Z = 0;
         SetDirty("Taxaspercentual_Z");
         return  ;
      }

      public bool gxTv_SdtTaxas_Taxaspercentual_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TaxasPercentualAnual_Z" )]
      [  XmlElement( ElementName = "TaxasPercentualAnual_Z"   )]
      public decimal gxTpr_Taxaspercentualanual_Z
      {
         get {
            return gxTv_SdtTaxas_Taxaspercentualanual_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxaspercentualanual_Z = value;
            SetDirty("Taxaspercentualanual_Z");
         }

      }

      public void gxTv_SdtTaxas_Taxaspercentualanual_Z_SetNull( )
      {
         gxTv_SdtTaxas_Taxaspercentualanual_Z = 0;
         SetDirty("Taxaspercentualanual_Z");
         return  ;
      }

      public bool gxTv_SdtTaxas_Taxaspercentualanual_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TaxasValorMinimo_Z" )]
      [  XmlElement( ElementName = "TaxasValorMinimo_Z"   )]
      public decimal gxTpr_Taxasvalorminimo_Z
      {
         get {
            return gxTv_SdtTaxas_Taxasvalorminimo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxasvalorminimo_Z = value;
            SetDirty("Taxasvalorminimo_Z");
         }

      }

      public void gxTv_SdtTaxas_Taxasvalorminimo_Z_SetNull( )
      {
         gxTv_SdtTaxas_Taxasvalorminimo_Z = 0;
         SetDirty("Taxasvalorminimo_Z");
         return  ;
      }

      public bool gxTv_SdtTaxas_Taxasvalorminimo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TaxasCreatedAt_Z" )]
      [  XmlElement( ElementName = "TaxasCreatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Taxascreatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtTaxas_Taxascreatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTaxas_Taxascreatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTaxas_Taxascreatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtTaxas_Taxascreatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Taxascreatedat_Z
      {
         get {
            return gxTv_SdtTaxas_Taxascreatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxascreatedat_Z = value;
            SetDirty("Taxascreatedat_Z");
         }

      }

      public void gxTv_SdtTaxas_Taxascreatedat_Z_SetNull( )
      {
         gxTv_SdtTaxas_Taxascreatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Taxascreatedat_Z");
         return  ;
      }

      public bool gxTv_SdtTaxas_Taxascreatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TaxasUpdatedAt_Z" )]
      [  XmlElement( ElementName = "TaxasUpdatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Taxasupdatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtTaxas_Taxasupdatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTaxas_Taxasupdatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTaxas_Taxasupdatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtTaxas_Taxasupdatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Taxasupdatedat_Z
      {
         get {
            return gxTv_SdtTaxas_Taxasupdatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxasupdatedat_Z = value;
            SetDirty("Taxasupdatedat_Z");
         }

      }

      public void gxTv_SdtTaxas_Taxasupdatedat_Z_SetNull( )
      {
         gxTv_SdtTaxas_Taxasupdatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Taxasupdatedat_Z");
         return  ;
      }

      public bool gxTv_SdtTaxas_Taxasupdatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TaxasCreatedBy_Z" )]
      [  XmlElement( ElementName = "TaxasCreatedBy_Z"   )]
      public short gxTpr_Taxascreatedby_Z
      {
         get {
            return gxTv_SdtTaxas_Taxascreatedby_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxascreatedby_Z = value;
            SetDirty("Taxascreatedby_Z");
         }

      }

      public void gxTv_SdtTaxas_Taxascreatedby_Z_SetNull( )
      {
         gxTv_SdtTaxas_Taxascreatedby_Z = 0;
         SetDirty("Taxascreatedby_Z");
         return  ;
      }

      public bool gxTv_SdtTaxas_Taxascreatedby_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TaxasCreatedName_Z" )]
      [  XmlElement( ElementName = "TaxasCreatedName_Z"   )]
      public string gxTpr_Taxascreatedname_Z
      {
         get {
            return gxTv_SdtTaxas_Taxascreatedname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxascreatedname_Z = value;
            SetDirty("Taxascreatedname_Z");
         }

      }

      public void gxTv_SdtTaxas_Taxascreatedname_Z_SetNull( )
      {
         gxTv_SdtTaxas_Taxascreatedname_Z = "";
         SetDirty("Taxascreatedname_Z");
         return  ;
      }

      public bool gxTv_SdtTaxas_Taxascreatedname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TaxasUpdatedBy_Z" )]
      [  XmlElement( ElementName = "TaxasUpdatedBy_Z"   )]
      public short gxTpr_Taxasupdatedby_Z
      {
         get {
            return gxTv_SdtTaxas_Taxasupdatedby_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxasupdatedby_Z = value;
            SetDirty("Taxasupdatedby_Z");
         }

      }

      public void gxTv_SdtTaxas_Taxasupdatedby_Z_SetNull( )
      {
         gxTv_SdtTaxas_Taxasupdatedby_Z = 0;
         SetDirty("Taxasupdatedby_Z");
         return  ;
      }

      public bool gxTv_SdtTaxas_Taxasupdatedby_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TaxasUpdatedName_Z" )]
      [  XmlElement( ElementName = "TaxasUpdatedName_Z"   )]
      public string gxTpr_Taxasupdatedname_Z
      {
         get {
            return gxTv_SdtTaxas_Taxasupdatedname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxasupdatedname_Z = value;
            SetDirty("Taxasupdatedname_Z");
         }

      }

      public void gxTv_SdtTaxas_Taxasupdatedname_Z_SetNull( )
      {
         gxTv_SdtTaxas_Taxasupdatedname_Z = "";
         SetDirty("Taxasupdatedname_Z");
         return  ;
      }

      public bool gxTv_SdtTaxas_Taxasupdatedname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TaxasPercentual_N" )]
      [  XmlElement( ElementName = "TaxasPercentual_N"   )]
      public short gxTpr_Taxaspercentual_N
      {
         get {
            return gxTv_SdtTaxas_Taxaspercentual_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxaspercentual_N = value;
            SetDirty("Taxaspercentual_N");
         }

      }

      public void gxTv_SdtTaxas_Taxaspercentual_N_SetNull( )
      {
         gxTv_SdtTaxas_Taxaspercentual_N = 0;
         SetDirty("Taxaspercentual_N");
         return  ;
      }

      public bool gxTv_SdtTaxas_Taxaspercentual_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TaxasPercentualAnual_N" )]
      [  XmlElement( ElementName = "TaxasPercentualAnual_N"   )]
      public short gxTpr_Taxaspercentualanual_N
      {
         get {
            return gxTv_SdtTaxas_Taxaspercentualanual_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxaspercentualanual_N = value;
            SetDirty("Taxaspercentualanual_N");
         }

      }

      public void gxTv_SdtTaxas_Taxaspercentualanual_N_SetNull( )
      {
         gxTv_SdtTaxas_Taxaspercentualanual_N = 0;
         SetDirty("Taxaspercentualanual_N");
         return  ;
      }

      public bool gxTv_SdtTaxas_Taxaspercentualanual_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TaxasValorMinimo_N" )]
      [  XmlElement( ElementName = "TaxasValorMinimo_N"   )]
      public short gxTpr_Taxasvalorminimo_N
      {
         get {
            return gxTv_SdtTaxas_Taxasvalorminimo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxasvalorminimo_N = value;
            SetDirty("Taxasvalorminimo_N");
         }

      }

      public void gxTv_SdtTaxas_Taxasvalorminimo_N_SetNull( )
      {
         gxTv_SdtTaxas_Taxasvalorminimo_N = 0;
         SetDirty("Taxasvalorminimo_N");
         return  ;
      }

      public bool gxTv_SdtTaxas_Taxasvalorminimo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TaxasCreatedAt_N" )]
      [  XmlElement( ElementName = "TaxasCreatedAt_N"   )]
      public short gxTpr_Taxascreatedat_N
      {
         get {
            return gxTv_SdtTaxas_Taxascreatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxascreatedat_N = value;
            SetDirty("Taxascreatedat_N");
         }

      }

      public void gxTv_SdtTaxas_Taxascreatedat_N_SetNull( )
      {
         gxTv_SdtTaxas_Taxascreatedat_N = 0;
         SetDirty("Taxascreatedat_N");
         return  ;
      }

      public bool gxTv_SdtTaxas_Taxascreatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TaxasUpdatedAt_N" )]
      [  XmlElement( ElementName = "TaxasUpdatedAt_N"   )]
      public short gxTpr_Taxasupdatedat_N
      {
         get {
            return gxTv_SdtTaxas_Taxasupdatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxasupdatedat_N = value;
            SetDirty("Taxasupdatedat_N");
         }

      }

      public void gxTv_SdtTaxas_Taxasupdatedat_N_SetNull( )
      {
         gxTv_SdtTaxas_Taxasupdatedat_N = 0;
         SetDirty("Taxasupdatedat_N");
         return  ;
      }

      public bool gxTv_SdtTaxas_Taxasupdatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TaxasCreatedBy_N" )]
      [  XmlElement( ElementName = "TaxasCreatedBy_N"   )]
      public short gxTpr_Taxascreatedby_N
      {
         get {
            return gxTv_SdtTaxas_Taxascreatedby_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxascreatedby_N = value;
            SetDirty("Taxascreatedby_N");
         }

      }

      public void gxTv_SdtTaxas_Taxascreatedby_N_SetNull( )
      {
         gxTv_SdtTaxas_Taxascreatedby_N = 0;
         SetDirty("Taxascreatedby_N");
         return  ;
      }

      public bool gxTv_SdtTaxas_Taxascreatedby_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TaxasCreatedName_N" )]
      [  XmlElement( ElementName = "TaxasCreatedName_N"   )]
      public short gxTpr_Taxascreatedname_N
      {
         get {
            return gxTv_SdtTaxas_Taxascreatedname_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxascreatedname_N = value;
            SetDirty("Taxascreatedname_N");
         }

      }

      public void gxTv_SdtTaxas_Taxascreatedname_N_SetNull( )
      {
         gxTv_SdtTaxas_Taxascreatedname_N = 0;
         SetDirty("Taxascreatedname_N");
         return  ;
      }

      public bool gxTv_SdtTaxas_Taxascreatedname_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TaxasUpdatedBy_N" )]
      [  XmlElement( ElementName = "TaxasUpdatedBy_N"   )]
      public short gxTpr_Taxasupdatedby_N
      {
         get {
            return gxTv_SdtTaxas_Taxasupdatedby_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxasupdatedby_N = value;
            SetDirty("Taxasupdatedby_N");
         }

      }

      public void gxTv_SdtTaxas_Taxasupdatedby_N_SetNull( )
      {
         gxTv_SdtTaxas_Taxasupdatedby_N = 0;
         SetDirty("Taxasupdatedby_N");
         return  ;
      }

      public bool gxTv_SdtTaxas_Taxasupdatedby_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TaxasUpdatedName_N" )]
      [  XmlElement( ElementName = "TaxasUpdatedName_N"   )]
      public short gxTpr_Taxasupdatedname_N
      {
         get {
            return gxTv_SdtTaxas_Taxasupdatedname_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTaxas_Taxasupdatedname_N = value;
            SetDirty("Taxasupdatedname_N");
         }

      }

      public void gxTv_SdtTaxas_Taxasupdatedname_N_SetNull( )
      {
         gxTv_SdtTaxas_Taxasupdatedname_N = 0;
         SetDirty("Taxasupdatedname_N");
         return  ;
      }

      public bool gxTv_SdtTaxas_Taxasupdatedname_N_IsNull( )
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
         gxTv_SdtTaxas_Taxascreatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtTaxas_Taxasupdatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtTaxas_Taxascreatedname = "";
         gxTv_SdtTaxas_Taxasupdatedname = "";
         gxTv_SdtTaxas_Mode = "";
         gxTv_SdtTaxas_Taxascreatedat_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtTaxas_Taxasupdatedat_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtTaxas_Taxascreatedname_Z = "";
         gxTv_SdtTaxas_Taxasupdatedname_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "taxas", "GeneXus.Programs.taxas_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTaxas_Taxascreatedby ;
      private short gxTv_SdtTaxas_Taxasupdatedby ;
      private short gxTv_SdtTaxas_Initialized ;
      private short gxTv_SdtTaxas_Taxascreatedby_Z ;
      private short gxTv_SdtTaxas_Taxasupdatedby_Z ;
      private short gxTv_SdtTaxas_Taxaspercentual_N ;
      private short gxTv_SdtTaxas_Taxaspercentualanual_N ;
      private short gxTv_SdtTaxas_Taxasvalorminimo_N ;
      private short gxTv_SdtTaxas_Taxascreatedat_N ;
      private short gxTv_SdtTaxas_Taxasupdatedat_N ;
      private short gxTv_SdtTaxas_Taxascreatedby_N ;
      private short gxTv_SdtTaxas_Taxascreatedname_N ;
      private short gxTv_SdtTaxas_Taxasupdatedby_N ;
      private short gxTv_SdtTaxas_Taxasupdatedname_N ;
      private int gxTv_SdtTaxas_Taxasid ;
      private int gxTv_SdtTaxas_Taxasid_Z ;
      private decimal gxTv_SdtTaxas_Taxaspercentual ;
      private decimal gxTv_SdtTaxas_Taxaspercentualanual ;
      private decimal gxTv_SdtTaxas_Taxasvalorminimo ;
      private decimal gxTv_SdtTaxas_Taxaspercentual_Z ;
      private decimal gxTv_SdtTaxas_Taxaspercentualanual_Z ;
      private decimal gxTv_SdtTaxas_Taxasvalorminimo_Z ;
      private string gxTv_SdtTaxas_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtTaxas_Taxascreatedat ;
      private DateTime gxTv_SdtTaxas_Taxasupdatedat ;
      private DateTime gxTv_SdtTaxas_Taxascreatedat_Z ;
      private DateTime gxTv_SdtTaxas_Taxasupdatedat_Z ;
      private DateTime datetime_STZ ;
      private string gxTv_SdtTaxas_Taxascreatedname ;
      private string gxTv_SdtTaxas_Taxasupdatedname ;
      private string gxTv_SdtTaxas_Taxascreatedname_Z ;
      private string gxTv_SdtTaxas_Taxasupdatedname_Z ;
   }

   [DataContract(Name = @"Taxas", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtTaxas_RESTInterface : GxGenericCollectionItem<SdtTaxas>
   {
      public SdtTaxas_RESTInterface( ) : base()
      {
      }

      public SdtTaxas_RESTInterface( SdtTaxas psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TaxasId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Taxasid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Taxasid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Taxasid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "TaxasPercentual" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Taxaspercentual
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Taxaspercentual, 16, 4)) ;
         }

         set {
            sdt.gxTpr_Taxaspercentual = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "TaxasPercentualAnual" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Taxaspercentualanual
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Taxaspercentualanual, 16, 4)) ;
         }

         set {
            sdt.gxTpr_Taxaspercentualanual = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "TaxasValorMinimo" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Taxasvalorminimo
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Taxasvalorminimo, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Taxasvalorminimo = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "TaxasCreatedAt" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Taxascreatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Taxascreatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Taxascreatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "TaxasUpdatedAt" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Taxasupdatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Taxasupdatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Taxasupdatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "TaxasCreatedBy" , Order = 6 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Taxascreatedby
      {
         get {
            return sdt.gxTpr_Taxascreatedby ;
         }

         set {
            sdt.gxTpr_Taxascreatedby = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "TaxasCreatedName" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Taxascreatedname
      {
         get {
            return sdt.gxTpr_Taxascreatedname ;
         }

         set {
            sdt.gxTpr_Taxascreatedname = value;
         }

      }

      [DataMember( Name = "TaxasUpdatedBy" , Order = 8 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Taxasupdatedby
      {
         get {
            return sdt.gxTpr_Taxasupdatedby ;
         }

         set {
            sdt.gxTpr_Taxasupdatedby = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "TaxasUpdatedName" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Taxasupdatedname
      {
         get {
            return sdt.gxTpr_Taxasupdatedname ;
         }

         set {
            sdt.gxTpr_Taxasupdatedname = value;
         }

      }

      public SdtTaxas sdt
      {
         get {
            return (SdtTaxas)Sdt ;
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
            sdt = new SdtTaxas() ;
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

   [DataContract(Name = @"Taxas", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtTaxas_RESTLInterface : GxGenericCollectionItem<SdtTaxas>
   {
      public SdtTaxas_RESTLInterface( ) : base()
      {
      }

      public SdtTaxas_RESTLInterface( SdtTaxas psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "TaxasPercentual" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Taxaspercentual
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Taxaspercentual, 16, 4)) ;
         }

         set {
            sdt.gxTpr_Taxaspercentual = NumberUtil.Val( value, ".");
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

      public SdtTaxas sdt
      {
         get {
            return (SdtTaxas)Sdt ;
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
            sdt = new SdtTaxas() ;
         }
      }

   }

}
