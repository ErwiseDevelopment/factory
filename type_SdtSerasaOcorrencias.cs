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
   [XmlRoot(ElementName = "SerasaOcorrencias" )]
   [XmlType(TypeName =  "SerasaOcorrencias" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtSerasaOcorrencias : GxSilentTrnSdt
   {
      public SdtSerasaOcorrencias( )
      {
      }

      public SdtSerasaOcorrencias( IGxContext context )
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

      public void Load( int AV726SerasaOcorrenciasId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV726SerasaOcorrenciasId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"SerasaOcorrenciasId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "SerasaOcorrencias");
         metadata.Set("BT", "SerasaOcorrencias");
         metadata.Set("PK", "[ \"SerasaOcorrenciasId\" ]");
         metadata.Set("PKAssigned", "[ \"SerasaOcorrenciasId\" ]");
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
         state.Add("gxTpr_Serasaocorrenciasid_Z");
         state.Add("gxTpr_Serasaid_Z");
         state.Add("gxTpr_Serasaocorrenciasdata_Z_Nullable");
         state.Add("gxTpr_Serasaocorrenciasorigem_Z");
         state.Add("gxTpr_Serasaocorrenciasmodalidade_Z");
         state.Add("gxTpr_Serasaocorrenciastipomoeda_Z");
         state.Add("gxTpr_Serasaocorrenciasvalor_Z");
         state.Add("gxTpr_Serasaid_N");
         state.Add("gxTpr_Serasaocorrenciasdata_N");
         state.Add("gxTpr_Serasaocorrenciasorigem_N");
         state.Add("gxTpr_Serasaocorrenciasmodalidade_N");
         state.Add("gxTpr_Serasaocorrenciastipomoeda_N");
         state.Add("gxTpr_Serasaocorrenciasvalor_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtSerasaOcorrencias sdt;
         sdt = (SdtSerasaOcorrencias)(source);
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasid = sdt.gxTv_SdtSerasaOcorrencias_Serasaocorrenciasid ;
         gxTv_SdtSerasaOcorrencias_Serasaid = sdt.gxTv_SdtSerasaOcorrencias_Serasaid ;
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata = sdt.gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata ;
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem = sdt.gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem ;
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade = sdt.gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade ;
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda = sdt.gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda ;
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasvalor = sdt.gxTv_SdtSerasaOcorrencias_Serasaocorrenciasvalor ;
         gxTv_SdtSerasaOcorrencias_Mode = sdt.gxTv_SdtSerasaOcorrencias_Mode ;
         gxTv_SdtSerasaOcorrencias_Initialized = sdt.gxTv_SdtSerasaOcorrencias_Initialized ;
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasid_Z = sdt.gxTv_SdtSerasaOcorrencias_Serasaocorrenciasid_Z ;
         gxTv_SdtSerasaOcorrencias_Serasaid_Z = sdt.gxTv_SdtSerasaOcorrencias_Serasaid_Z ;
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata_Z = sdt.gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata_Z ;
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem_Z = sdt.gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem_Z ;
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade_Z = sdt.gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade_Z ;
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda_Z = sdt.gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda_Z ;
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasvalor_Z = sdt.gxTv_SdtSerasaOcorrencias_Serasaocorrenciasvalor_Z ;
         gxTv_SdtSerasaOcorrencias_Serasaid_N = sdt.gxTv_SdtSerasaOcorrencias_Serasaid_N ;
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata_N = sdt.gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata_N ;
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem_N = sdt.gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem_N ;
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade_N = sdt.gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade_N ;
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda_N = sdt.gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda_N ;
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasvalor_N = sdt.gxTv_SdtSerasaOcorrencias_Serasaocorrenciasvalor_N ;
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
         AddObjectProperty("SerasaOcorrenciasId", gxTv_SdtSerasaOcorrencias_Serasaocorrenciasid, false, includeNonInitialized);
         AddObjectProperty("SerasaId", gxTv_SdtSerasaOcorrencias_Serasaid, false, includeNonInitialized);
         AddObjectProperty("SerasaId_N", gxTv_SdtSerasaOcorrencias_Serasaid_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("SerasaOcorrenciasData", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("SerasaOcorrenciasData_N", gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata_N, false, includeNonInitialized);
         AddObjectProperty("SerasaOcorrenciasOrigem", gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem, false, includeNonInitialized);
         AddObjectProperty("SerasaOcorrenciasOrigem_N", gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem_N, false, includeNonInitialized);
         AddObjectProperty("SerasaOcorrenciasModalidade", gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade, false, includeNonInitialized);
         AddObjectProperty("SerasaOcorrenciasModalidade_N", gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade_N, false, includeNonInitialized);
         AddObjectProperty("SerasaOcorrenciasTipoMoeda", gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda, false, includeNonInitialized);
         AddObjectProperty("SerasaOcorrenciasTipoMoeda_N", gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda_N, false, includeNonInitialized);
         AddObjectProperty("SerasaOcorrenciasValor", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSerasaOcorrencias_Serasaocorrenciasvalor, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("SerasaOcorrenciasValor_N", gxTv_SdtSerasaOcorrencias_Serasaocorrenciasvalor_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtSerasaOcorrencias_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtSerasaOcorrencias_Initialized, false, includeNonInitialized);
            AddObjectProperty("SerasaOcorrenciasId_Z", gxTv_SdtSerasaOcorrencias_Serasaocorrenciasid_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaId_Z", gxTv_SdtSerasaOcorrencias_Serasaid_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("SerasaOcorrenciasData_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("SerasaOcorrenciasOrigem_Z", gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaOcorrenciasModalidade_Z", gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaOcorrenciasTipoMoeda_Z", gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaOcorrenciasValor_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSerasaOcorrencias_Serasaocorrenciasvalor_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("SerasaId_N", gxTv_SdtSerasaOcorrencias_Serasaid_N, false, includeNonInitialized);
            AddObjectProperty("SerasaOcorrenciasData_N", gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata_N, false, includeNonInitialized);
            AddObjectProperty("SerasaOcorrenciasOrigem_N", gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem_N, false, includeNonInitialized);
            AddObjectProperty("SerasaOcorrenciasModalidade_N", gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade_N, false, includeNonInitialized);
            AddObjectProperty("SerasaOcorrenciasTipoMoeda_N", gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda_N, false, includeNonInitialized);
            AddObjectProperty("SerasaOcorrenciasValor_N", gxTv_SdtSerasaOcorrencias_Serasaocorrenciasvalor_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtSerasaOcorrencias sdt )
      {
         if ( sdt.IsDirty("SerasaOcorrenciasId") )
         {
            sdtIsNull = 0;
            gxTv_SdtSerasaOcorrencias_Serasaocorrenciasid = sdt.gxTv_SdtSerasaOcorrencias_Serasaocorrenciasid ;
         }
         if ( sdt.IsDirty("SerasaId") )
         {
            gxTv_SdtSerasaOcorrencias_Serasaid_N = (short)(sdt.gxTv_SdtSerasaOcorrencias_Serasaid_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaOcorrencias_Serasaid = sdt.gxTv_SdtSerasaOcorrencias_Serasaid ;
         }
         if ( sdt.IsDirty("SerasaOcorrenciasData") )
         {
            gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata_N = (short)(sdt.gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata = sdt.gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata ;
         }
         if ( sdt.IsDirty("SerasaOcorrenciasOrigem") )
         {
            gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem_N = (short)(sdt.gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem = sdt.gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem ;
         }
         if ( sdt.IsDirty("SerasaOcorrenciasModalidade") )
         {
            gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade_N = (short)(sdt.gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade = sdt.gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade ;
         }
         if ( sdt.IsDirty("SerasaOcorrenciasTipoMoeda") )
         {
            gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda_N = (short)(sdt.gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda = sdt.gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda ;
         }
         if ( sdt.IsDirty("SerasaOcorrenciasValor") )
         {
            gxTv_SdtSerasaOcorrencias_Serasaocorrenciasvalor_N = (short)(sdt.gxTv_SdtSerasaOcorrencias_Serasaocorrenciasvalor_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaOcorrencias_Serasaocorrenciasvalor = sdt.gxTv_SdtSerasaOcorrencias_Serasaocorrenciasvalor ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "SerasaOcorrenciasId" )]
      [  XmlElement( ElementName = "SerasaOcorrenciasId"   )]
      public int gxTpr_Serasaocorrenciasid
      {
         get {
            return gxTv_SdtSerasaOcorrencias_Serasaocorrenciasid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtSerasaOcorrencias_Serasaocorrenciasid != value )
            {
               gxTv_SdtSerasaOcorrencias_Mode = "INS";
               this.gxTv_SdtSerasaOcorrencias_Serasaocorrenciasid_Z_SetNull( );
               this.gxTv_SdtSerasaOcorrencias_Serasaid_Z_SetNull( );
               this.gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata_Z_SetNull( );
               this.gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem_Z_SetNull( );
               this.gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade_Z_SetNull( );
               this.gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda_Z_SetNull( );
               this.gxTv_SdtSerasaOcorrencias_Serasaocorrenciasvalor_Z_SetNull( );
            }
            gxTv_SdtSerasaOcorrencias_Serasaocorrenciasid = value;
            SetDirty("Serasaocorrenciasid");
         }

      }

      [  SoapElement( ElementName = "SerasaId" )]
      [  XmlElement( ElementName = "SerasaId"   )]
      public int gxTpr_Serasaid
      {
         get {
            return gxTv_SdtSerasaOcorrencias_Serasaid ;
         }

         set {
            gxTv_SdtSerasaOcorrencias_Serasaid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaOcorrencias_Serasaid = value;
            SetDirty("Serasaid");
         }

      }

      public void gxTv_SdtSerasaOcorrencias_Serasaid_SetNull( )
      {
         gxTv_SdtSerasaOcorrencias_Serasaid_N = 1;
         gxTv_SdtSerasaOcorrencias_Serasaid = 0;
         SetDirty("Serasaid");
         return  ;
      }

      public bool gxTv_SdtSerasaOcorrencias_Serasaid_IsNull( )
      {
         return (gxTv_SdtSerasaOcorrencias_Serasaid_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaOcorrenciasData" )]
      [  XmlElement( ElementName = "SerasaOcorrenciasData"  , IsNullable=true )]
      public string gxTpr_Serasaocorrenciasdata_Nullable
      {
         get {
            if ( gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata).value ;
         }

         set {
            gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata = DateTime.MinValue;
            else
               gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Serasaocorrenciasdata
      {
         get {
            return gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata ;
         }

         set {
            gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata = value;
            SetDirty("Serasaocorrenciasdata");
         }

      }

      public void gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata_SetNull( )
      {
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata_N = 1;
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata = (DateTime)(DateTime.MinValue);
         SetDirty("Serasaocorrenciasdata");
         return  ;
      }

      public bool gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata_IsNull( )
      {
         return (gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaOcorrenciasOrigem" )]
      [  XmlElement( ElementName = "SerasaOcorrenciasOrigem"   )]
      public string gxTpr_Serasaocorrenciasorigem
      {
         get {
            return gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem ;
         }

         set {
            gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem = value;
            SetDirty("Serasaocorrenciasorigem");
         }

      }

      public void gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem_SetNull( )
      {
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem_N = 1;
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem = "";
         SetDirty("Serasaocorrenciasorigem");
         return  ;
      }

      public bool gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem_IsNull( )
      {
         return (gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaOcorrenciasModalidade" )]
      [  XmlElement( ElementName = "SerasaOcorrenciasModalidade"   )]
      public string gxTpr_Serasaocorrenciasmodalidade
      {
         get {
            return gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade ;
         }

         set {
            gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade = value;
            SetDirty("Serasaocorrenciasmodalidade");
         }

      }

      public void gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade_SetNull( )
      {
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade_N = 1;
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade = "";
         SetDirty("Serasaocorrenciasmodalidade");
         return  ;
      }

      public bool gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade_IsNull( )
      {
         return (gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaOcorrenciasTipoMoeda" )]
      [  XmlElement( ElementName = "SerasaOcorrenciasTipoMoeda"   )]
      public string gxTpr_Serasaocorrenciastipomoeda
      {
         get {
            return gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda ;
         }

         set {
            gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda = value;
            SetDirty("Serasaocorrenciastipomoeda");
         }

      }

      public void gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda_SetNull( )
      {
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda_N = 1;
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda = "";
         SetDirty("Serasaocorrenciastipomoeda");
         return  ;
      }

      public bool gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda_IsNull( )
      {
         return (gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaOcorrenciasValor" )]
      [  XmlElement( ElementName = "SerasaOcorrenciasValor"   )]
      public decimal gxTpr_Serasaocorrenciasvalor
      {
         get {
            return gxTv_SdtSerasaOcorrencias_Serasaocorrenciasvalor ;
         }

         set {
            gxTv_SdtSerasaOcorrencias_Serasaocorrenciasvalor_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaOcorrencias_Serasaocorrenciasvalor = value;
            SetDirty("Serasaocorrenciasvalor");
         }

      }

      public void gxTv_SdtSerasaOcorrencias_Serasaocorrenciasvalor_SetNull( )
      {
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasvalor_N = 1;
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasvalor = 0;
         SetDirty("Serasaocorrenciasvalor");
         return  ;
      }

      public bool gxTv_SdtSerasaOcorrencias_Serasaocorrenciasvalor_IsNull( )
      {
         return (gxTv_SdtSerasaOcorrencias_Serasaocorrenciasvalor_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtSerasaOcorrencias_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaOcorrencias_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtSerasaOcorrencias_Mode_SetNull( )
      {
         gxTv_SdtSerasaOcorrencias_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtSerasaOcorrencias_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtSerasaOcorrencias_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaOcorrencias_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtSerasaOcorrencias_Initialized_SetNull( )
      {
         gxTv_SdtSerasaOcorrencias_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtSerasaOcorrencias_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaOcorrenciasId_Z" )]
      [  XmlElement( ElementName = "SerasaOcorrenciasId_Z"   )]
      public int gxTpr_Serasaocorrenciasid_Z
      {
         get {
            return gxTv_SdtSerasaOcorrencias_Serasaocorrenciasid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaOcorrencias_Serasaocorrenciasid_Z = value;
            SetDirty("Serasaocorrenciasid_Z");
         }

      }

      public void gxTv_SdtSerasaOcorrencias_Serasaocorrenciasid_Z_SetNull( )
      {
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasid_Z = 0;
         SetDirty("Serasaocorrenciasid_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaOcorrencias_Serasaocorrenciasid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaId_Z" )]
      [  XmlElement( ElementName = "SerasaId_Z"   )]
      public int gxTpr_Serasaid_Z
      {
         get {
            return gxTv_SdtSerasaOcorrencias_Serasaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaOcorrencias_Serasaid_Z = value;
            SetDirty("Serasaid_Z");
         }

      }

      public void gxTv_SdtSerasaOcorrencias_Serasaid_Z_SetNull( )
      {
         gxTv_SdtSerasaOcorrencias_Serasaid_Z = 0;
         SetDirty("Serasaid_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaOcorrencias_Serasaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaOcorrenciasData_Z" )]
      [  XmlElement( ElementName = "SerasaOcorrenciasData_Z"  , IsNullable=true )]
      public string gxTpr_Serasaocorrenciasdata_Z_Nullable
      {
         get {
            if ( gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata_Z = DateTime.MinValue;
            else
               gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Serasaocorrenciasdata_Z
      {
         get {
            return gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata_Z = value;
            SetDirty("Serasaocorrenciasdata_Z");
         }

      }

      public void gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata_Z_SetNull( )
      {
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Serasaocorrenciasdata_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaOcorrenciasOrigem_Z" )]
      [  XmlElement( ElementName = "SerasaOcorrenciasOrigem_Z"   )]
      public string gxTpr_Serasaocorrenciasorigem_Z
      {
         get {
            return gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem_Z = value;
            SetDirty("Serasaocorrenciasorigem_Z");
         }

      }

      public void gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem_Z_SetNull( )
      {
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem_Z = "";
         SetDirty("Serasaocorrenciasorigem_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaOcorrenciasModalidade_Z" )]
      [  XmlElement( ElementName = "SerasaOcorrenciasModalidade_Z"   )]
      public string gxTpr_Serasaocorrenciasmodalidade_Z
      {
         get {
            return gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade_Z = value;
            SetDirty("Serasaocorrenciasmodalidade_Z");
         }

      }

      public void gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade_Z_SetNull( )
      {
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade_Z = "";
         SetDirty("Serasaocorrenciasmodalidade_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaOcorrenciasTipoMoeda_Z" )]
      [  XmlElement( ElementName = "SerasaOcorrenciasTipoMoeda_Z"   )]
      public string gxTpr_Serasaocorrenciastipomoeda_Z
      {
         get {
            return gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda_Z = value;
            SetDirty("Serasaocorrenciastipomoeda_Z");
         }

      }

      public void gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda_Z_SetNull( )
      {
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda_Z = "";
         SetDirty("Serasaocorrenciastipomoeda_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaOcorrenciasValor_Z" )]
      [  XmlElement( ElementName = "SerasaOcorrenciasValor_Z"   )]
      public decimal gxTpr_Serasaocorrenciasvalor_Z
      {
         get {
            return gxTv_SdtSerasaOcorrencias_Serasaocorrenciasvalor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaOcorrencias_Serasaocorrenciasvalor_Z = value;
            SetDirty("Serasaocorrenciasvalor_Z");
         }

      }

      public void gxTv_SdtSerasaOcorrencias_Serasaocorrenciasvalor_Z_SetNull( )
      {
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasvalor_Z = 0;
         SetDirty("Serasaocorrenciasvalor_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaOcorrencias_Serasaocorrenciasvalor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaId_N" )]
      [  XmlElement( ElementName = "SerasaId_N"   )]
      public short gxTpr_Serasaid_N
      {
         get {
            return gxTv_SdtSerasaOcorrencias_Serasaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaOcorrencias_Serasaid_N = value;
            SetDirty("Serasaid_N");
         }

      }

      public void gxTv_SdtSerasaOcorrencias_Serasaid_N_SetNull( )
      {
         gxTv_SdtSerasaOcorrencias_Serasaid_N = 0;
         SetDirty("Serasaid_N");
         return  ;
      }

      public bool gxTv_SdtSerasaOcorrencias_Serasaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaOcorrenciasData_N" )]
      [  XmlElement( ElementName = "SerasaOcorrenciasData_N"   )]
      public short gxTpr_Serasaocorrenciasdata_N
      {
         get {
            return gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata_N = value;
            SetDirty("Serasaocorrenciasdata_N");
         }

      }

      public void gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata_N_SetNull( )
      {
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata_N = 0;
         SetDirty("Serasaocorrenciasdata_N");
         return  ;
      }

      public bool gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaOcorrenciasOrigem_N" )]
      [  XmlElement( ElementName = "SerasaOcorrenciasOrigem_N"   )]
      public short gxTpr_Serasaocorrenciasorigem_N
      {
         get {
            return gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem_N = value;
            SetDirty("Serasaocorrenciasorigem_N");
         }

      }

      public void gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem_N_SetNull( )
      {
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem_N = 0;
         SetDirty("Serasaocorrenciasorigem_N");
         return  ;
      }

      public bool gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaOcorrenciasModalidade_N" )]
      [  XmlElement( ElementName = "SerasaOcorrenciasModalidade_N"   )]
      public short gxTpr_Serasaocorrenciasmodalidade_N
      {
         get {
            return gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade_N = value;
            SetDirty("Serasaocorrenciasmodalidade_N");
         }

      }

      public void gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade_N_SetNull( )
      {
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade_N = 0;
         SetDirty("Serasaocorrenciasmodalidade_N");
         return  ;
      }

      public bool gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaOcorrenciasTipoMoeda_N" )]
      [  XmlElement( ElementName = "SerasaOcorrenciasTipoMoeda_N"   )]
      public short gxTpr_Serasaocorrenciastipomoeda_N
      {
         get {
            return gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda_N = value;
            SetDirty("Serasaocorrenciastipomoeda_N");
         }

      }

      public void gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda_N_SetNull( )
      {
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda_N = 0;
         SetDirty("Serasaocorrenciastipomoeda_N");
         return  ;
      }

      public bool gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaOcorrenciasValor_N" )]
      [  XmlElement( ElementName = "SerasaOcorrenciasValor_N"   )]
      public short gxTpr_Serasaocorrenciasvalor_N
      {
         get {
            return gxTv_SdtSerasaOcorrencias_Serasaocorrenciasvalor_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaOcorrencias_Serasaocorrenciasvalor_N = value;
            SetDirty("Serasaocorrenciasvalor_N");
         }

      }

      public void gxTv_SdtSerasaOcorrencias_Serasaocorrenciasvalor_N_SetNull( )
      {
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasvalor_N = 0;
         SetDirty("Serasaocorrenciasvalor_N");
         return  ;
      }

      public bool gxTv_SdtSerasaOcorrencias_Serasaocorrenciasvalor_N_IsNull( )
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
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata = DateTime.MinValue;
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem = "";
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade = "";
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda = "";
         gxTv_SdtSerasaOcorrencias_Mode = "";
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata_Z = DateTime.MinValue;
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem_Z = "";
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade_Z = "";
         gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "serasaocorrencias", "GeneXus.Programs.serasaocorrencias_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtSerasaOcorrencias_Initialized ;
      private short gxTv_SdtSerasaOcorrencias_Serasaid_N ;
      private short gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata_N ;
      private short gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem_N ;
      private short gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade_N ;
      private short gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda_N ;
      private short gxTv_SdtSerasaOcorrencias_Serasaocorrenciasvalor_N ;
      private int gxTv_SdtSerasaOcorrencias_Serasaocorrenciasid ;
      private int gxTv_SdtSerasaOcorrencias_Serasaid ;
      private int gxTv_SdtSerasaOcorrencias_Serasaocorrenciasid_Z ;
      private int gxTv_SdtSerasaOcorrencias_Serasaid_Z ;
      private decimal gxTv_SdtSerasaOcorrencias_Serasaocorrenciasvalor ;
      private decimal gxTv_SdtSerasaOcorrencias_Serasaocorrenciasvalor_Z ;
      private string gxTv_SdtSerasaOcorrencias_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata ;
      private DateTime gxTv_SdtSerasaOcorrencias_Serasaocorrenciasdata_Z ;
      private string gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem ;
      private string gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade ;
      private string gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda ;
      private string gxTv_SdtSerasaOcorrencias_Serasaocorrenciasorigem_Z ;
      private string gxTv_SdtSerasaOcorrencias_Serasaocorrenciasmodalidade_Z ;
      private string gxTv_SdtSerasaOcorrencias_Serasaocorrenciastipomoeda_Z ;
   }

   [DataContract(Name = @"SerasaOcorrencias", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtSerasaOcorrencias_RESTInterface : GxGenericCollectionItem<SdtSerasaOcorrencias>
   {
      public SdtSerasaOcorrencias_RESTInterface( ) : base()
      {
      }

      public SdtSerasaOcorrencias_RESTInterface( SdtSerasaOcorrencias psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SerasaOcorrenciasId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Serasaocorrenciasid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Serasaocorrenciasid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Serasaocorrenciasid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
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

      [DataMember( Name = "SerasaOcorrenciasData" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Serasaocorrenciasdata
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Serasaocorrenciasdata) ;
         }

         set {
            sdt.gxTpr_Serasaocorrenciasdata = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "SerasaOcorrenciasOrigem" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Serasaocorrenciasorigem
      {
         get {
            return sdt.gxTpr_Serasaocorrenciasorigem ;
         }

         set {
            sdt.gxTpr_Serasaocorrenciasorigem = value;
         }

      }

      [DataMember( Name = "SerasaOcorrenciasModalidade" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Serasaocorrenciasmodalidade
      {
         get {
            return sdt.gxTpr_Serasaocorrenciasmodalidade ;
         }

         set {
            sdt.gxTpr_Serasaocorrenciasmodalidade = value;
         }

      }

      [DataMember( Name = "SerasaOcorrenciasTipoMoeda" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Serasaocorrenciastipomoeda
      {
         get {
            return sdt.gxTpr_Serasaocorrenciastipomoeda ;
         }

         set {
            sdt.gxTpr_Serasaocorrenciastipomoeda = value;
         }

      }

      [DataMember( Name = "SerasaOcorrenciasValor" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Serasaocorrenciasvalor
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Serasaocorrenciasvalor, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Serasaocorrenciasvalor = NumberUtil.Val( value, ".");
         }

      }

      public SdtSerasaOcorrencias sdt
      {
         get {
            return (SdtSerasaOcorrencias)Sdt ;
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
            sdt = new SdtSerasaOcorrencias() ;
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

   [DataContract(Name = @"SerasaOcorrencias", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtSerasaOcorrencias_RESTLInterface : GxGenericCollectionItem<SdtSerasaOcorrencias>
   {
      public SdtSerasaOcorrencias_RESTLInterface( ) : base()
      {
      }

      public SdtSerasaOcorrencias_RESTLInterface( SdtSerasaOcorrencias psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SerasaOcorrenciasData" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Serasaocorrenciasdata
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Serasaocorrenciasdata) ;
         }

         set {
            sdt.gxTpr_Serasaocorrenciasdata = DateTimeUtil.CToD2( value);
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

      public SdtSerasaOcorrencias sdt
      {
         get {
            return (SdtSerasaOcorrencias)Sdt ;
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
            sdt = new SdtSerasaOcorrencias() ;
         }
      }

   }

}
