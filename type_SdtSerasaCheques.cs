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
   [XmlRoot(ElementName = "SerasaCheques" )]
   [XmlType(TypeName =  "SerasaCheques" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtSerasaCheques : GxSilentTrnSdt
   {
      public SdtSerasaCheques( )
      {
      }

      public SdtSerasaCheques( IGxContext context )
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

      public void Load( int AV693SerasaChequesId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV693SerasaChequesId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"SerasaChequesId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "SerasaCheques");
         metadata.Set("BT", "SerasaCheques");
         metadata.Set("PK", "[ \"SerasaChequesId\" ]");
         metadata.Set("PKAssigned", "[ \"SerasaChequesId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"SerasaId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Serasachequesid_Z");
         state.Add("gxTpr_Serasaid_Z");
         state.Add("gxTpr_Serasachequestotalcons_Z");
         state.Add("gxTpr_Serasachequesqtdsemfundo_Z");
         state.Add("gxTpr_Serasachequesultocorsus_Z_Nullable");
         state.Add("gxTpr_Serasachequesvalorsemfundo_Z");
         state.Add("gxTpr_Serasachequestotalsust_Z");
         state.Add("gxTpr_Serasaid_N");
         state.Add("gxTpr_Serasachequestotalcons_N");
         state.Add("gxTpr_Serasachequesqtdsemfundo_N");
         state.Add("gxTpr_Serasachequesultocorsus_N");
         state.Add("gxTpr_Serasachequesvalorsemfundo_N");
         state.Add("gxTpr_Serasachequestotalsust_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtSerasaCheques sdt;
         sdt = (SdtSerasaCheques)(source);
         gxTv_SdtSerasaCheques_Serasachequesid = sdt.gxTv_SdtSerasaCheques_Serasachequesid ;
         gxTv_SdtSerasaCheques_Serasaid = sdt.gxTv_SdtSerasaCheques_Serasaid ;
         gxTv_SdtSerasaCheques_Serasachequestotalcons = sdt.gxTv_SdtSerasaCheques_Serasachequestotalcons ;
         gxTv_SdtSerasaCheques_Serasachequesqtdsemfundo = sdt.gxTv_SdtSerasaCheques_Serasachequesqtdsemfundo ;
         gxTv_SdtSerasaCheques_Serasachequesultocorsus = sdt.gxTv_SdtSerasaCheques_Serasachequesultocorsus ;
         gxTv_SdtSerasaCheques_Serasachequesvalorsemfundo = sdt.gxTv_SdtSerasaCheques_Serasachequesvalorsemfundo ;
         gxTv_SdtSerasaCheques_Serasachequestotalsust = sdt.gxTv_SdtSerasaCheques_Serasachequestotalsust ;
         gxTv_SdtSerasaCheques_Mode = sdt.gxTv_SdtSerasaCheques_Mode ;
         gxTv_SdtSerasaCheques_Initialized = sdt.gxTv_SdtSerasaCheques_Initialized ;
         gxTv_SdtSerasaCheques_Serasachequesid_Z = sdt.gxTv_SdtSerasaCheques_Serasachequesid_Z ;
         gxTv_SdtSerasaCheques_Serasaid_Z = sdt.gxTv_SdtSerasaCheques_Serasaid_Z ;
         gxTv_SdtSerasaCheques_Serasachequestotalcons_Z = sdt.gxTv_SdtSerasaCheques_Serasachequestotalcons_Z ;
         gxTv_SdtSerasaCheques_Serasachequesqtdsemfundo_Z = sdt.gxTv_SdtSerasaCheques_Serasachequesqtdsemfundo_Z ;
         gxTv_SdtSerasaCheques_Serasachequesultocorsus_Z = sdt.gxTv_SdtSerasaCheques_Serasachequesultocorsus_Z ;
         gxTv_SdtSerasaCheques_Serasachequesvalorsemfundo_Z = sdt.gxTv_SdtSerasaCheques_Serasachequesvalorsemfundo_Z ;
         gxTv_SdtSerasaCheques_Serasachequestotalsust_Z = sdt.gxTv_SdtSerasaCheques_Serasachequestotalsust_Z ;
         gxTv_SdtSerasaCheques_Serasaid_N = sdt.gxTv_SdtSerasaCheques_Serasaid_N ;
         gxTv_SdtSerasaCheques_Serasachequestotalcons_N = sdt.gxTv_SdtSerasaCheques_Serasachequestotalcons_N ;
         gxTv_SdtSerasaCheques_Serasachequesqtdsemfundo_N = sdt.gxTv_SdtSerasaCheques_Serasachequesqtdsemfundo_N ;
         gxTv_SdtSerasaCheques_Serasachequesultocorsus_N = sdt.gxTv_SdtSerasaCheques_Serasachequesultocorsus_N ;
         gxTv_SdtSerasaCheques_Serasachequesvalorsemfundo_N = sdt.gxTv_SdtSerasaCheques_Serasachequesvalorsemfundo_N ;
         gxTv_SdtSerasaCheques_Serasachequestotalsust_N = sdt.gxTv_SdtSerasaCheques_Serasachequestotalsust_N ;
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
         AddObjectProperty("SerasaChequesId", gxTv_SdtSerasaCheques_Serasachequesid, false, includeNonInitialized);
         AddObjectProperty("SerasaId", gxTv_SdtSerasaCheques_Serasaid, false, includeNonInitialized);
         AddObjectProperty("SerasaId_N", gxTv_SdtSerasaCheques_Serasaid_N, false, includeNonInitialized);
         AddObjectProperty("SerasaChequesTotalCons", gxTv_SdtSerasaCheques_Serasachequestotalcons, false, includeNonInitialized);
         AddObjectProperty("SerasaChequesTotalCons_N", gxTv_SdtSerasaCheques_Serasachequestotalcons_N, false, includeNonInitialized);
         AddObjectProperty("SerasaChequesQtdSemFundo", gxTv_SdtSerasaCheques_Serasachequesqtdsemfundo, false, includeNonInitialized);
         AddObjectProperty("SerasaChequesQtdSemFundo_N", gxTv_SdtSerasaCheques_Serasachequesqtdsemfundo_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtSerasaCheques_Serasachequesultocorsus)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtSerasaCheques_Serasachequesultocorsus)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtSerasaCheques_Serasachequesultocorsus)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("SerasaChequesUltOcorSus", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("SerasaChequesUltOcorSus_N", gxTv_SdtSerasaCheques_Serasachequesultocorsus_N, false, includeNonInitialized);
         AddObjectProperty("SerasaChequesValorSemFundo", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSerasaCheques_Serasachequesvalorsemfundo, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("SerasaChequesValorSemFundo_N", gxTv_SdtSerasaCheques_Serasachequesvalorsemfundo_N, false, includeNonInitialized);
         AddObjectProperty("SerasaChequesTotalSust", gxTv_SdtSerasaCheques_Serasachequestotalsust, false, includeNonInitialized);
         AddObjectProperty("SerasaChequesTotalSust_N", gxTv_SdtSerasaCheques_Serasachequestotalsust_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtSerasaCheques_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtSerasaCheques_Initialized, false, includeNonInitialized);
            AddObjectProperty("SerasaChequesId_Z", gxTv_SdtSerasaCheques_Serasachequesid_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaId_Z", gxTv_SdtSerasaCheques_Serasaid_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaChequesTotalCons_Z", gxTv_SdtSerasaCheques_Serasachequestotalcons_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaChequesQtdSemFundo_Z", gxTv_SdtSerasaCheques_Serasachequesqtdsemfundo_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtSerasaCheques_Serasachequesultocorsus_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtSerasaCheques_Serasachequesultocorsus_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtSerasaCheques_Serasachequesultocorsus_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("SerasaChequesUltOcorSus_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("SerasaChequesValorSemFundo_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSerasaCheques_Serasachequesvalorsemfundo_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("SerasaChequesTotalSust_Z", gxTv_SdtSerasaCheques_Serasachequestotalsust_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaId_N", gxTv_SdtSerasaCheques_Serasaid_N, false, includeNonInitialized);
            AddObjectProperty("SerasaChequesTotalCons_N", gxTv_SdtSerasaCheques_Serasachequestotalcons_N, false, includeNonInitialized);
            AddObjectProperty("SerasaChequesQtdSemFundo_N", gxTv_SdtSerasaCheques_Serasachequesqtdsemfundo_N, false, includeNonInitialized);
            AddObjectProperty("SerasaChequesUltOcorSus_N", gxTv_SdtSerasaCheques_Serasachequesultocorsus_N, false, includeNonInitialized);
            AddObjectProperty("SerasaChequesValorSemFundo_N", gxTv_SdtSerasaCheques_Serasachequesvalorsemfundo_N, false, includeNonInitialized);
            AddObjectProperty("SerasaChequesTotalSust_N", gxTv_SdtSerasaCheques_Serasachequestotalsust_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtSerasaCheques sdt )
      {
         if ( sdt.IsDirty("SerasaChequesId") )
         {
            sdtIsNull = 0;
            gxTv_SdtSerasaCheques_Serasachequesid = sdt.gxTv_SdtSerasaCheques_Serasachequesid ;
         }
         if ( sdt.IsDirty("SerasaId") )
         {
            gxTv_SdtSerasaCheques_Serasaid_N = (short)(sdt.gxTv_SdtSerasaCheques_Serasaid_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaCheques_Serasaid = sdt.gxTv_SdtSerasaCheques_Serasaid ;
         }
         if ( sdt.IsDirty("SerasaChequesTotalCons") )
         {
            gxTv_SdtSerasaCheques_Serasachequestotalcons_N = (short)(sdt.gxTv_SdtSerasaCheques_Serasachequestotalcons_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaCheques_Serasachequestotalcons = sdt.gxTv_SdtSerasaCheques_Serasachequestotalcons ;
         }
         if ( sdt.IsDirty("SerasaChequesQtdSemFundo") )
         {
            gxTv_SdtSerasaCheques_Serasachequesqtdsemfundo_N = (short)(sdt.gxTv_SdtSerasaCheques_Serasachequesqtdsemfundo_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaCheques_Serasachequesqtdsemfundo = sdt.gxTv_SdtSerasaCheques_Serasachequesqtdsemfundo ;
         }
         if ( sdt.IsDirty("SerasaChequesUltOcorSus") )
         {
            gxTv_SdtSerasaCheques_Serasachequesultocorsus_N = (short)(sdt.gxTv_SdtSerasaCheques_Serasachequesultocorsus_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaCheques_Serasachequesultocorsus = sdt.gxTv_SdtSerasaCheques_Serasachequesultocorsus ;
         }
         if ( sdt.IsDirty("SerasaChequesValorSemFundo") )
         {
            gxTv_SdtSerasaCheques_Serasachequesvalorsemfundo_N = (short)(sdt.gxTv_SdtSerasaCheques_Serasachequesvalorsemfundo_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaCheques_Serasachequesvalorsemfundo = sdt.gxTv_SdtSerasaCheques_Serasachequesvalorsemfundo ;
         }
         if ( sdt.IsDirty("SerasaChequesTotalSust") )
         {
            gxTv_SdtSerasaCheques_Serasachequestotalsust_N = (short)(sdt.gxTv_SdtSerasaCheques_Serasachequestotalsust_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaCheques_Serasachequestotalsust = sdt.gxTv_SdtSerasaCheques_Serasachequestotalsust ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "SerasaChequesId" )]
      [  XmlElement( ElementName = "SerasaChequesId"   )]
      public int gxTpr_Serasachequesid
      {
         get {
            return gxTv_SdtSerasaCheques_Serasachequesid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtSerasaCheques_Serasachequesid != value )
            {
               gxTv_SdtSerasaCheques_Mode = "INS";
               this.gxTv_SdtSerasaCheques_Serasachequesid_Z_SetNull( );
               this.gxTv_SdtSerasaCheques_Serasaid_Z_SetNull( );
               this.gxTv_SdtSerasaCheques_Serasachequestotalcons_Z_SetNull( );
               this.gxTv_SdtSerasaCheques_Serasachequesqtdsemfundo_Z_SetNull( );
               this.gxTv_SdtSerasaCheques_Serasachequesultocorsus_Z_SetNull( );
               this.gxTv_SdtSerasaCheques_Serasachequesvalorsemfundo_Z_SetNull( );
               this.gxTv_SdtSerasaCheques_Serasachequestotalsust_Z_SetNull( );
            }
            gxTv_SdtSerasaCheques_Serasachequesid = value;
            SetDirty("Serasachequesid");
         }

      }

      [  SoapElement( ElementName = "SerasaId" )]
      [  XmlElement( ElementName = "SerasaId"   )]
      public int gxTpr_Serasaid
      {
         get {
            return gxTv_SdtSerasaCheques_Serasaid ;
         }

         set {
            gxTv_SdtSerasaCheques_Serasaid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaCheques_Serasaid = value;
            SetDirty("Serasaid");
         }

      }

      public void gxTv_SdtSerasaCheques_Serasaid_SetNull( )
      {
         gxTv_SdtSerasaCheques_Serasaid_N = 1;
         gxTv_SdtSerasaCheques_Serasaid = 0;
         SetDirty("Serasaid");
         return  ;
      }

      public bool gxTv_SdtSerasaCheques_Serasaid_IsNull( )
      {
         return (gxTv_SdtSerasaCheques_Serasaid_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaChequesTotalCons" )]
      [  XmlElement( ElementName = "SerasaChequesTotalCons"   )]
      public decimal gxTpr_Serasachequestotalcons
      {
         get {
            return gxTv_SdtSerasaCheques_Serasachequestotalcons ;
         }

         set {
            gxTv_SdtSerasaCheques_Serasachequestotalcons_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaCheques_Serasachequestotalcons = value;
            SetDirty("Serasachequestotalcons");
         }

      }

      public void gxTv_SdtSerasaCheques_Serasachequestotalcons_SetNull( )
      {
         gxTv_SdtSerasaCheques_Serasachequestotalcons_N = 1;
         gxTv_SdtSerasaCheques_Serasachequestotalcons = 0;
         SetDirty("Serasachequestotalcons");
         return  ;
      }

      public bool gxTv_SdtSerasaCheques_Serasachequestotalcons_IsNull( )
      {
         return (gxTv_SdtSerasaCheques_Serasachequestotalcons_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaChequesQtdSemFundo" )]
      [  XmlElement( ElementName = "SerasaChequesQtdSemFundo"   )]
      public decimal gxTpr_Serasachequesqtdsemfundo
      {
         get {
            return gxTv_SdtSerasaCheques_Serasachequesqtdsemfundo ;
         }

         set {
            gxTv_SdtSerasaCheques_Serasachequesqtdsemfundo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaCheques_Serasachequesqtdsemfundo = value;
            SetDirty("Serasachequesqtdsemfundo");
         }

      }

      public void gxTv_SdtSerasaCheques_Serasachequesqtdsemfundo_SetNull( )
      {
         gxTv_SdtSerasaCheques_Serasachequesqtdsemfundo_N = 1;
         gxTv_SdtSerasaCheques_Serasachequesqtdsemfundo = 0;
         SetDirty("Serasachequesqtdsemfundo");
         return  ;
      }

      public bool gxTv_SdtSerasaCheques_Serasachequesqtdsemfundo_IsNull( )
      {
         return (gxTv_SdtSerasaCheques_Serasachequesqtdsemfundo_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaChequesUltOcorSus" )]
      [  XmlElement( ElementName = "SerasaChequesUltOcorSus"  , IsNullable=true )]
      public string gxTpr_Serasachequesultocorsus_Nullable
      {
         get {
            if ( gxTv_SdtSerasaCheques_Serasachequesultocorsus == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtSerasaCheques_Serasachequesultocorsus).value ;
         }

         set {
            gxTv_SdtSerasaCheques_Serasachequesultocorsus_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtSerasaCheques_Serasachequesultocorsus = DateTime.MinValue;
            else
               gxTv_SdtSerasaCheques_Serasachequesultocorsus = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Serasachequesultocorsus
      {
         get {
            return gxTv_SdtSerasaCheques_Serasachequesultocorsus ;
         }

         set {
            gxTv_SdtSerasaCheques_Serasachequesultocorsus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaCheques_Serasachequesultocorsus = value;
            SetDirty("Serasachequesultocorsus");
         }

      }

      public void gxTv_SdtSerasaCheques_Serasachequesultocorsus_SetNull( )
      {
         gxTv_SdtSerasaCheques_Serasachequesultocorsus_N = 1;
         gxTv_SdtSerasaCheques_Serasachequesultocorsus = (DateTime)(DateTime.MinValue);
         SetDirty("Serasachequesultocorsus");
         return  ;
      }

      public bool gxTv_SdtSerasaCheques_Serasachequesultocorsus_IsNull( )
      {
         return (gxTv_SdtSerasaCheques_Serasachequesultocorsus_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaChequesValorSemFundo" )]
      [  XmlElement( ElementName = "SerasaChequesValorSemFundo"   )]
      public decimal gxTpr_Serasachequesvalorsemfundo
      {
         get {
            return gxTv_SdtSerasaCheques_Serasachequesvalorsemfundo ;
         }

         set {
            gxTv_SdtSerasaCheques_Serasachequesvalorsemfundo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaCheques_Serasachequesvalorsemfundo = value;
            SetDirty("Serasachequesvalorsemfundo");
         }

      }

      public void gxTv_SdtSerasaCheques_Serasachequesvalorsemfundo_SetNull( )
      {
         gxTv_SdtSerasaCheques_Serasachequesvalorsemfundo_N = 1;
         gxTv_SdtSerasaCheques_Serasachequesvalorsemfundo = 0;
         SetDirty("Serasachequesvalorsemfundo");
         return  ;
      }

      public bool gxTv_SdtSerasaCheques_Serasachequesvalorsemfundo_IsNull( )
      {
         return (gxTv_SdtSerasaCheques_Serasachequesvalorsemfundo_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaChequesTotalSust" )]
      [  XmlElement( ElementName = "SerasaChequesTotalSust"   )]
      public decimal gxTpr_Serasachequestotalsust
      {
         get {
            return gxTv_SdtSerasaCheques_Serasachequestotalsust ;
         }

         set {
            gxTv_SdtSerasaCheques_Serasachequestotalsust_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaCheques_Serasachequestotalsust = value;
            SetDirty("Serasachequestotalsust");
         }

      }

      public void gxTv_SdtSerasaCheques_Serasachequestotalsust_SetNull( )
      {
         gxTv_SdtSerasaCheques_Serasachequestotalsust_N = 1;
         gxTv_SdtSerasaCheques_Serasachequestotalsust = 0;
         SetDirty("Serasachequestotalsust");
         return  ;
      }

      public bool gxTv_SdtSerasaCheques_Serasachequestotalsust_IsNull( )
      {
         return (gxTv_SdtSerasaCheques_Serasachequestotalsust_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtSerasaCheques_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaCheques_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtSerasaCheques_Mode_SetNull( )
      {
         gxTv_SdtSerasaCheques_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtSerasaCheques_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtSerasaCheques_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaCheques_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtSerasaCheques_Initialized_SetNull( )
      {
         gxTv_SdtSerasaCheques_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtSerasaCheques_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaChequesId_Z" )]
      [  XmlElement( ElementName = "SerasaChequesId_Z"   )]
      public int gxTpr_Serasachequesid_Z
      {
         get {
            return gxTv_SdtSerasaCheques_Serasachequesid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaCheques_Serasachequesid_Z = value;
            SetDirty("Serasachequesid_Z");
         }

      }

      public void gxTv_SdtSerasaCheques_Serasachequesid_Z_SetNull( )
      {
         gxTv_SdtSerasaCheques_Serasachequesid_Z = 0;
         SetDirty("Serasachequesid_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaCheques_Serasachequesid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaId_Z" )]
      [  XmlElement( ElementName = "SerasaId_Z"   )]
      public int gxTpr_Serasaid_Z
      {
         get {
            return gxTv_SdtSerasaCheques_Serasaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaCheques_Serasaid_Z = value;
            SetDirty("Serasaid_Z");
         }

      }

      public void gxTv_SdtSerasaCheques_Serasaid_Z_SetNull( )
      {
         gxTv_SdtSerasaCheques_Serasaid_Z = 0;
         SetDirty("Serasaid_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaCheques_Serasaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaChequesTotalCons_Z" )]
      [  XmlElement( ElementName = "SerasaChequesTotalCons_Z"   )]
      public decimal gxTpr_Serasachequestotalcons_Z
      {
         get {
            return gxTv_SdtSerasaCheques_Serasachequestotalcons_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaCheques_Serasachequestotalcons_Z = value;
            SetDirty("Serasachequestotalcons_Z");
         }

      }

      public void gxTv_SdtSerasaCheques_Serasachequestotalcons_Z_SetNull( )
      {
         gxTv_SdtSerasaCheques_Serasachequestotalcons_Z = 0;
         SetDirty("Serasachequestotalcons_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaCheques_Serasachequestotalcons_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaChequesQtdSemFundo_Z" )]
      [  XmlElement( ElementName = "SerasaChequesQtdSemFundo_Z"   )]
      public decimal gxTpr_Serasachequesqtdsemfundo_Z
      {
         get {
            return gxTv_SdtSerasaCheques_Serasachequesqtdsemfundo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaCheques_Serasachequesqtdsemfundo_Z = value;
            SetDirty("Serasachequesqtdsemfundo_Z");
         }

      }

      public void gxTv_SdtSerasaCheques_Serasachequesqtdsemfundo_Z_SetNull( )
      {
         gxTv_SdtSerasaCheques_Serasachequesqtdsemfundo_Z = 0;
         SetDirty("Serasachequesqtdsemfundo_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaCheques_Serasachequesqtdsemfundo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaChequesUltOcorSus_Z" )]
      [  XmlElement( ElementName = "SerasaChequesUltOcorSus_Z"  , IsNullable=true )]
      public string gxTpr_Serasachequesultocorsus_Z_Nullable
      {
         get {
            if ( gxTv_SdtSerasaCheques_Serasachequesultocorsus_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtSerasaCheques_Serasachequesultocorsus_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtSerasaCheques_Serasachequesultocorsus_Z = DateTime.MinValue;
            else
               gxTv_SdtSerasaCheques_Serasachequesultocorsus_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Serasachequesultocorsus_Z
      {
         get {
            return gxTv_SdtSerasaCheques_Serasachequesultocorsus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaCheques_Serasachequesultocorsus_Z = value;
            SetDirty("Serasachequesultocorsus_Z");
         }

      }

      public void gxTv_SdtSerasaCheques_Serasachequesultocorsus_Z_SetNull( )
      {
         gxTv_SdtSerasaCheques_Serasachequesultocorsus_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Serasachequesultocorsus_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaCheques_Serasachequesultocorsus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaChequesValorSemFundo_Z" )]
      [  XmlElement( ElementName = "SerasaChequesValorSemFundo_Z"   )]
      public decimal gxTpr_Serasachequesvalorsemfundo_Z
      {
         get {
            return gxTv_SdtSerasaCheques_Serasachequesvalorsemfundo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaCheques_Serasachequesvalorsemfundo_Z = value;
            SetDirty("Serasachequesvalorsemfundo_Z");
         }

      }

      public void gxTv_SdtSerasaCheques_Serasachequesvalorsemfundo_Z_SetNull( )
      {
         gxTv_SdtSerasaCheques_Serasachequesvalorsemfundo_Z = 0;
         SetDirty("Serasachequesvalorsemfundo_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaCheques_Serasachequesvalorsemfundo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaChequesTotalSust_Z" )]
      [  XmlElement( ElementName = "SerasaChequesTotalSust_Z"   )]
      public decimal gxTpr_Serasachequestotalsust_Z
      {
         get {
            return gxTv_SdtSerasaCheques_Serasachequestotalsust_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaCheques_Serasachequestotalsust_Z = value;
            SetDirty("Serasachequestotalsust_Z");
         }

      }

      public void gxTv_SdtSerasaCheques_Serasachequestotalsust_Z_SetNull( )
      {
         gxTv_SdtSerasaCheques_Serasachequestotalsust_Z = 0;
         SetDirty("Serasachequestotalsust_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaCheques_Serasachequestotalsust_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaId_N" )]
      [  XmlElement( ElementName = "SerasaId_N"   )]
      public short gxTpr_Serasaid_N
      {
         get {
            return gxTv_SdtSerasaCheques_Serasaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaCheques_Serasaid_N = value;
            SetDirty("Serasaid_N");
         }

      }

      public void gxTv_SdtSerasaCheques_Serasaid_N_SetNull( )
      {
         gxTv_SdtSerasaCheques_Serasaid_N = 0;
         SetDirty("Serasaid_N");
         return  ;
      }

      public bool gxTv_SdtSerasaCheques_Serasaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaChequesTotalCons_N" )]
      [  XmlElement( ElementName = "SerasaChequesTotalCons_N"   )]
      public short gxTpr_Serasachequestotalcons_N
      {
         get {
            return gxTv_SdtSerasaCheques_Serasachequestotalcons_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaCheques_Serasachequestotalcons_N = value;
            SetDirty("Serasachequestotalcons_N");
         }

      }

      public void gxTv_SdtSerasaCheques_Serasachequestotalcons_N_SetNull( )
      {
         gxTv_SdtSerasaCheques_Serasachequestotalcons_N = 0;
         SetDirty("Serasachequestotalcons_N");
         return  ;
      }

      public bool gxTv_SdtSerasaCheques_Serasachequestotalcons_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaChequesQtdSemFundo_N" )]
      [  XmlElement( ElementName = "SerasaChequesQtdSemFundo_N"   )]
      public short gxTpr_Serasachequesqtdsemfundo_N
      {
         get {
            return gxTv_SdtSerasaCheques_Serasachequesqtdsemfundo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaCheques_Serasachequesqtdsemfundo_N = value;
            SetDirty("Serasachequesqtdsemfundo_N");
         }

      }

      public void gxTv_SdtSerasaCheques_Serasachequesqtdsemfundo_N_SetNull( )
      {
         gxTv_SdtSerasaCheques_Serasachequesqtdsemfundo_N = 0;
         SetDirty("Serasachequesqtdsemfundo_N");
         return  ;
      }

      public bool gxTv_SdtSerasaCheques_Serasachequesqtdsemfundo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaChequesUltOcorSus_N" )]
      [  XmlElement( ElementName = "SerasaChequesUltOcorSus_N"   )]
      public short gxTpr_Serasachequesultocorsus_N
      {
         get {
            return gxTv_SdtSerasaCheques_Serasachequesultocorsus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaCheques_Serasachequesultocorsus_N = value;
            SetDirty("Serasachequesultocorsus_N");
         }

      }

      public void gxTv_SdtSerasaCheques_Serasachequesultocorsus_N_SetNull( )
      {
         gxTv_SdtSerasaCheques_Serasachequesultocorsus_N = 0;
         SetDirty("Serasachequesultocorsus_N");
         return  ;
      }

      public bool gxTv_SdtSerasaCheques_Serasachequesultocorsus_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaChequesValorSemFundo_N" )]
      [  XmlElement( ElementName = "SerasaChequesValorSemFundo_N"   )]
      public short gxTpr_Serasachequesvalorsemfundo_N
      {
         get {
            return gxTv_SdtSerasaCheques_Serasachequesvalorsemfundo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaCheques_Serasachequesvalorsemfundo_N = value;
            SetDirty("Serasachequesvalorsemfundo_N");
         }

      }

      public void gxTv_SdtSerasaCheques_Serasachequesvalorsemfundo_N_SetNull( )
      {
         gxTv_SdtSerasaCheques_Serasachequesvalorsemfundo_N = 0;
         SetDirty("Serasachequesvalorsemfundo_N");
         return  ;
      }

      public bool gxTv_SdtSerasaCheques_Serasachequesvalorsemfundo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaChequesTotalSust_N" )]
      [  XmlElement( ElementName = "SerasaChequesTotalSust_N"   )]
      public short gxTpr_Serasachequestotalsust_N
      {
         get {
            return gxTv_SdtSerasaCheques_Serasachequestotalsust_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaCheques_Serasachequestotalsust_N = value;
            SetDirty("Serasachequestotalsust_N");
         }

      }

      public void gxTv_SdtSerasaCheques_Serasachequestotalsust_N_SetNull( )
      {
         gxTv_SdtSerasaCheques_Serasachequestotalsust_N = 0;
         SetDirty("Serasachequestotalsust_N");
         return  ;
      }

      public bool gxTv_SdtSerasaCheques_Serasachequestotalsust_N_IsNull( )
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
         gxTv_SdtSerasaCheques_Serasachequesultocorsus = DateTime.MinValue;
         gxTv_SdtSerasaCheques_Mode = "";
         gxTv_SdtSerasaCheques_Serasachequesultocorsus_Z = DateTime.MinValue;
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "serasacheques", "GeneXus.Programs.serasacheques_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtSerasaCheques_Initialized ;
      private short gxTv_SdtSerasaCheques_Serasaid_N ;
      private short gxTv_SdtSerasaCheques_Serasachequestotalcons_N ;
      private short gxTv_SdtSerasaCheques_Serasachequesqtdsemfundo_N ;
      private short gxTv_SdtSerasaCheques_Serasachequesultocorsus_N ;
      private short gxTv_SdtSerasaCheques_Serasachequesvalorsemfundo_N ;
      private short gxTv_SdtSerasaCheques_Serasachequestotalsust_N ;
      private int gxTv_SdtSerasaCheques_Serasachequesid ;
      private int gxTv_SdtSerasaCheques_Serasaid ;
      private int gxTv_SdtSerasaCheques_Serasachequesid_Z ;
      private int gxTv_SdtSerasaCheques_Serasaid_Z ;
      private decimal gxTv_SdtSerasaCheques_Serasachequestotalcons ;
      private decimal gxTv_SdtSerasaCheques_Serasachequesqtdsemfundo ;
      private decimal gxTv_SdtSerasaCheques_Serasachequesvalorsemfundo ;
      private decimal gxTv_SdtSerasaCheques_Serasachequestotalsust ;
      private decimal gxTv_SdtSerasaCheques_Serasachequestotalcons_Z ;
      private decimal gxTv_SdtSerasaCheques_Serasachequesqtdsemfundo_Z ;
      private decimal gxTv_SdtSerasaCheques_Serasachequesvalorsemfundo_Z ;
      private decimal gxTv_SdtSerasaCheques_Serasachequestotalsust_Z ;
      private string gxTv_SdtSerasaCheques_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtSerasaCheques_Serasachequesultocorsus ;
      private DateTime gxTv_SdtSerasaCheques_Serasachequesultocorsus_Z ;
   }

   [DataContract(Name = @"SerasaCheques", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtSerasaCheques_RESTInterface : GxGenericCollectionItem<SdtSerasaCheques>
   {
      public SdtSerasaCheques_RESTInterface( ) : base()
      {
      }

      public SdtSerasaCheques_RESTInterface( SdtSerasaCheques psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SerasaChequesId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Serasachequesid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Serasachequesid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Serasachequesid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "SerasaId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Serasaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Serasaid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Serasaid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "SerasaChequesTotalCons" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Serasachequestotalcons
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Serasachequestotalcons, 15, 2)) ;
         }

         set {
            sdt.gxTpr_Serasachequestotalcons = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "SerasaChequesQtdSemFundo" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Serasachequesqtdsemfundo
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Serasachequesqtdsemfundo, 15, 2)) ;
         }

         set {
            sdt.gxTpr_Serasachequesqtdsemfundo = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "SerasaChequesUltOcorSus" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Serasachequesultocorsus
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Serasachequesultocorsus) ;
         }

         set {
            sdt.gxTpr_Serasachequesultocorsus = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "SerasaChequesValorSemFundo" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Serasachequesvalorsemfundo
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Serasachequesvalorsemfundo, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Serasachequesvalorsemfundo = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "SerasaChequesTotalSust" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Serasachequestotalsust
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Serasachequestotalsust, 15, 2)) ;
         }

         set {
            sdt.gxTpr_Serasachequestotalsust = NumberUtil.Val( value, ".");
         }

      }

      public SdtSerasaCheques sdt
      {
         get {
            return (SdtSerasaCheques)Sdt ;
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
            sdt = new SdtSerasaCheques() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 7 )]
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

   [DataContract(Name = @"SerasaCheques", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtSerasaCheques_RESTLInterface : GxGenericCollectionItem<SdtSerasaCheques>
   {
      public SdtSerasaCheques_RESTLInterface( ) : base()
      {
      }

      public SdtSerasaCheques_RESTLInterface( SdtSerasaCheques psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SerasaChequesTotalCons" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Serasachequestotalcons
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Serasachequestotalcons, 15, 2)) ;
         }

         set {
            sdt.gxTpr_Serasachequestotalcons = NumberUtil.Val( value, ".");
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

      public SdtSerasaCheques sdt
      {
         get {
            return (SdtSerasaCheques)Sdt ;
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
            sdt = new SdtSerasaCheques() ;
         }
      }

   }

}
