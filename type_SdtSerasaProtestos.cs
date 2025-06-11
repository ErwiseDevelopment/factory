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
   [XmlRoot(ElementName = "SerasaProtestos" )]
   [XmlType(TypeName =  "SerasaProtestos" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtSerasaProtestos : GxSilentTrnSdt
   {
      public SdtSerasaProtestos( )
      {
      }

      public SdtSerasaProtestos( IGxContext context )
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

      public void Load( int AV711SerasaProtestosId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV711SerasaProtestosId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"SerasaProtestosId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "SerasaProtestos");
         metadata.Set("BT", "SerasaProtestos");
         metadata.Set("PK", "[ \"SerasaProtestosId\" ]");
         metadata.Set("PKAssigned", "[ \"SerasaProtestosId\" ]");
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
         state.Add("gxTpr_Serasaprotestosid_Z");
         state.Add("gxTpr_Serasaid_Z");
         state.Add("gxTpr_Serasaprotestosdata_Z_Nullable");
         state.Add("gxTpr_Serasaprotestosvalor_Z");
         state.Add("gxTpr_Serasaprotestoscartorio_Z");
         state.Add("gxTpr_Serasaprotestoscidade_Z");
         state.Add("gxTpr_Serasaid_N");
         state.Add("gxTpr_Serasaprotestosdata_N");
         state.Add("gxTpr_Serasaprotestosvalor_N");
         state.Add("gxTpr_Serasaprotestoscartorio_N");
         state.Add("gxTpr_Serasaprotestoscidade_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtSerasaProtestos sdt;
         sdt = (SdtSerasaProtestos)(source);
         gxTv_SdtSerasaProtestos_Serasaprotestosid = sdt.gxTv_SdtSerasaProtestos_Serasaprotestosid ;
         gxTv_SdtSerasaProtestos_Serasaid = sdt.gxTv_SdtSerasaProtestos_Serasaid ;
         gxTv_SdtSerasaProtestos_Serasaprotestosdata = sdt.gxTv_SdtSerasaProtestos_Serasaprotestosdata ;
         gxTv_SdtSerasaProtestos_Serasaprotestosvalor = sdt.gxTv_SdtSerasaProtestos_Serasaprotestosvalor ;
         gxTv_SdtSerasaProtestos_Serasaprotestoscartorio = sdt.gxTv_SdtSerasaProtestos_Serasaprotestoscartorio ;
         gxTv_SdtSerasaProtestos_Serasaprotestoscidade = sdt.gxTv_SdtSerasaProtestos_Serasaprotestoscidade ;
         gxTv_SdtSerasaProtestos_Mode = sdt.gxTv_SdtSerasaProtestos_Mode ;
         gxTv_SdtSerasaProtestos_Initialized = sdt.gxTv_SdtSerasaProtestos_Initialized ;
         gxTv_SdtSerasaProtestos_Serasaprotestosid_Z = sdt.gxTv_SdtSerasaProtestos_Serasaprotestosid_Z ;
         gxTv_SdtSerasaProtestos_Serasaid_Z = sdt.gxTv_SdtSerasaProtestos_Serasaid_Z ;
         gxTv_SdtSerasaProtestos_Serasaprotestosdata_Z = sdt.gxTv_SdtSerasaProtestos_Serasaprotestosdata_Z ;
         gxTv_SdtSerasaProtestos_Serasaprotestosvalor_Z = sdt.gxTv_SdtSerasaProtestos_Serasaprotestosvalor_Z ;
         gxTv_SdtSerasaProtestos_Serasaprotestoscartorio_Z = sdt.gxTv_SdtSerasaProtestos_Serasaprotestoscartorio_Z ;
         gxTv_SdtSerasaProtestos_Serasaprotestoscidade_Z = sdt.gxTv_SdtSerasaProtestos_Serasaprotestoscidade_Z ;
         gxTv_SdtSerasaProtestos_Serasaid_N = sdt.gxTv_SdtSerasaProtestos_Serasaid_N ;
         gxTv_SdtSerasaProtestos_Serasaprotestosdata_N = sdt.gxTv_SdtSerasaProtestos_Serasaprotestosdata_N ;
         gxTv_SdtSerasaProtestos_Serasaprotestosvalor_N = sdt.gxTv_SdtSerasaProtestos_Serasaprotestosvalor_N ;
         gxTv_SdtSerasaProtestos_Serasaprotestoscartorio_N = sdt.gxTv_SdtSerasaProtestos_Serasaprotestoscartorio_N ;
         gxTv_SdtSerasaProtestos_Serasaprotestoscidade_N = sdt.gxTv_SdtSerasaProtestos_Serasaprotestoscidade_N ;
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
         AddObjectProperty("SerasaProtestosId", gxTv_SdtSerasaProtestos_Serasaprotestosid, false, includeNonInitialized);
         AddObjectProperty("SerasaId", gxTv_SdtSerasaProtestos_Serasaid, false, includeNonInitialized);
         AddObjectProperty("SerasaId_N", gxTv_SdtSerasaProtestos_Serasaid_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtSerasaProtestos_Serasaprotestosdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtSerasaProtestos_Serasaprotestosdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtSerasaProtestos_Serasaprotestosdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("SerasaProtestosData", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("SerasaProtestosData_N", gxTv_SdtSerasaProtestos_Serasaprotestosdata_N, false, includeNonInitialized);
         AddObjectProperty("SerasaProtestosValor", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSerasaProtestos_Serasaprotestosvalor, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("SerasaProtestosValor_N", gxTv_SdtSerasaProtestos_Serasaprotestosvalor_N, false, includeNonInitialized);
         AddObjectProperty("SerasaProtestosCartorio", gxTv_SdtSerasaProtestos_Serasaprotestoscartorio, false, includeNonInitialized);
         AddObjectProperty("SerasaProtestosCartorio_N", gxTv_SdtSerasaProtestos_Serasaprotestoscartorio_N, false, includeNonInitialized);
         AddObjectProperty("SerasaProtestosCidade", gxTv_SdtSerasaProtestos_Serasaprotestoscidade, false, includeNonInitialized);
         AddObjectProperty("SerasaProtestosCidade_N", gxTv_SdtSerasaProtestos_Serasaprotestoscidade_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtSerasaProtestos_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtSerasaProtestos_Initialized, false, includeNonInitialized);
            AddObjectProperty("SerasaProtestosId_Z", gxTv_SdtSerasaProtestos_Serasaprotestosid_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaId_Z", gxTv_SdtSerasaProtestos_Serasaid_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtSerasaProtestos_Serasaprotestosdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtSerasaProtestos_Serasaprotestosdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtSerasaProtestos_Serasaprotestosdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("SerasaProtestosData_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("SerasaProtestosValor_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtSerasaProtestos_Serasaprotestosvalor_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("SerasaProtestosCartorio_Z", gxTv_SdtSerasaProtestos_Serasaprotestoscartorio_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaProtestosCidade_Z", gxTv_SdtSerasaProtestos_Serasaprotestoscidade_Z, false, includeNonInitialized);
            AddObjectProperty("SerasaId_N", gxTv_SdtSerasaProtestos_Serasaid_N, false, includeNonInitialized);
            AddObjectProperty("SerasaProtestosData_N", gxTv_SdtSerasaProtestos_Serasaprotestosdata_N, false, includeNonInitialized);
            AddObjectProperty("SerasaProtestosValor_N", gxTv_SdtSerasaProtestos_Serasaprotestosvalor_N, false, includeNonInitialized);
            AddObjectProperty("SerasaProtestosCartorio_N", gxTv_SdtSerasaProtestos_Serasaprotestoscartorio_N, false, includeNonInitialized);
            AddObjectProperty("SerasaProtestosCidade_N", gxTv_SdtSerasaProtestos_Serasaprotestoscidade_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtSerasaProtestos sdt )
      {
         if ( sdt.IsDirty("SerasaProtestosId") )
         {
            sdtIsNull = 0;
            gxTv_SdtSerasaProtestos_Serasaprotestosid = sdt.gxTv_SdtSerasaProtestos_Serasaprotestosid ;
         }
         if ( sdt.IsDirty("SerasaId") )
         {
            gxTv_SdtSerasaProtestos_Serasaid_N = (short)(sdt.gxTv_SdtSerasaProtestos_Serasaid_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaProtestos_Serasaid = sdt.gxTv_SdtSerasaProtestos_Serasaid ;
         }
         if ( sdt.IsDirty("SerasaProtestosData") )
         {
            gxTv_SdtSerasaProtestos_Serasaprotestosdata_N = (short)(sdt.gxTv_SdtSerasaProtestos_Serasaprotestosdata_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaProtestos_Serasaprotestosdata = sdt.gxTv_SdtSerasaProtestos_Serasaprotestosdata ;
         }
         if ( sdt.IsDirty("SerasaProtestosValor") )
         {
            gxTv_SdtSerasaProtestos_Serasaprotestosvalor_N = (short)(sdt.gxTv_SdtSerasaProtestos_Serasaprotestosvalor_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaProtestos_Serasaprotestosvalor = sdt.gxTv_SdtSerasaProtestos_Serasaprotestosvalor ;
         }
         if ( sdt.IsDirty("SerasaProtestosCartorio") )
         {
            gxTv_SdtSerasaProtestos_Serasaprotestoscartorio_N = (short)(sdt.gxTv_SdtSerasaProtestos_Serasaprotestoscartorio_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaProtestos_Serasaprotestoscartorio = sdt.gxTv_SdtSerasaProtestos_Serasaprotestoscartorio ;
         }
         if ( sdt.IsDirty("SerasaProtestosCidade") )
         {
            gxTv_SdtSerasaProtestos_Serasaprotestoscidade_N = (short)(sdt.gxTv_SdtSerasaProtestos_Serasaprotestoscidade_N);
            sdtIsNull = 0;
            gxTv_SdtSerasaProtestos_Serasaprotestoscidade = sdt.gxTv_SdtSerasaProtestos_Serasaprotestoscidade ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "SerasaProtestosId" )]
      [  XmlElement( ElementName = "SerasaProtestosId"   )]
      public int gxTpr_Serasaprotestosid
      {
         get {
            return gxTv_SdtSerasaProtestos_Serasaprotestosid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtSerasaProtestos_Serasaprotestosid != value )
            {
               gxTv_SdtSerasaProtestos_Mode = "INS";
               this.gxTv_SdtSerasaProtestos_Serasaprotestosid_Z_SetNull( );
               this.gxTv_SdtSerasaProtestos_Serasaid_Z_SetNull( );
               this.gxTv_SdtSerasaProtestos_Serasaprotestosdata_Z_SetNull( );
               this.gxTv_SdtSerasaProtestos_Serasaprotestosvalor_Z_SetNull( );
               this.gxTv_SdtSerasaProtestos_Serasaprotestoscartorio_Z_SetNull( );
               this.gxTv_SdtSerasaProtestos_Serasaprotestoscidade_Z_SetNull( );
            }
            gxTv_SdtSerasaProtestos_Serasaprotestosid = value;
            SetDirty("Serasaprotestosid");
         }

      }

      [  SoapElement( ElementName = "SerasaId" )]
      [  XmlElement( ElementName = "SerasaId"   )]
      public int gxTpr_Serasaid
      {
         get {
            return gxTv_SdtSerasaProtestos_Serasaid ;
         }

         set {
            gxTv_SdtSerasaProtestos_Serasaid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaProtestos_Serasaid = value;
            SetDirty("Serasaid");
         }

      }

      public void gxTv_SdtSerasaProtestos_Serasaid_SetNull( )
      {
         gxTv_SdtSerasaProtestos_Serasaid_N = 1;
         gxTv_SdtSerasaProtestos_Serasaid = 0;
         SetDirty("Serasaid");
         return  ;
      }

      public bool gxTv_SdtSerasaProtestos_Serasaid_IsNull( )
      {
         return (gxTv_SdtSerasaProtestos_Serasaid_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaProtestosData" )]
      [  XmlElement( ElementName = "SerasaProtestosData"  , IsNullable=true )]
      public string gxTpr_Serasaprotestosdata_Nullable
      {
         get {
            if ( gxTv_SdtSerasaProtestos_Serasaprotestosdata == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtSerasaProtestos_Serasaprotestosdata).value ;
         }

         set {
            gxTv_SdtSerasaProtestos_Serasaprotestosdata_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtSerasaProtestos_Serasaprotestosdata = DateTime.MinValue;
            else
               gxTv_SdtSerasaProtestos_Serasaprotestosdata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Serasaprotestosdata
      {
         get {
            return gxTv_SdtSerasaProtestos_Serasaprotestosdata ;
         }

         set {
            gxTv_SdtSerasaProtestos_Serasaprotestosdata_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaProtestos_Serasaprotestosdata = value;
            SetDirty("Serasaprotestosdata");
         }

      }

      public void gxTv_SdtSerasaProtestos_Serasaprotestosdata_SetNull( )
      {
         gxTv_SdtSerasaProtestos_Serasaprotestosdata_N = 1;
         gxTv_SdtSerasaProtestos_Serasaprotestosdata = (DateTime)(DateTime.MinValue);
         SetDirty("Serasaprotestosdata");
         return  ;
      }

      public bool gxTv_SdtSerasaProtestos_Serasaprotestosdata_IsNull( )
      {
         return (gxTv_SdtSerasaProtestos_Serasaprotestosdata_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaProtestosValor" )]
      [  XmlElement( ElementName = "SerasaProtestosValor"   )]
      public decimal gxTpr_Serasaprotestosvalor
      {
         get {
            return gxTv_SdtSerasaProtestos_Serasaprotestosvalor ;
         }

         set {
            gxTv_SdtSerasaProtestos_Serasaprotestosvalor_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaProtestos_Serasaprotestosvalor = value;
            SetDirty("Serasaprotestosvalor");
         }

      }

      public void gxTv_SdtSerasaProtestos_Serasaprotestosvalor_SetNull( )
      {
         gxTv_SdtSerasaProtestos_Serasaprotestosvalor_N = 1;
         gxTv_SdtSerasaProtestos_Serasaprotestosvalor = 0;
         SetDirty("Serasaprotestosvalor");
         return  ;
      }

      public bool gxTv_SdtSerasaProtestos_Serasaprotestosvalor_IsNull( )
      {
         return (gxTv_SdtSerasaProtestos_Serasaprotestosvalor_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaProtestosCartorio" )]
      [  XmlElement( ElementName = "SerasaProtestosCartorio"   )]
      public string gxTpr_Serasaprotestoscartorio
      {
         get {
            return gxTv_SdtSerasaProtestos_Serasaprotestoscartorio ;
         }

         set {
            gxTv_SdtSerasaProtestos_Serasaprotestoscartorio_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaProtestos_Serasaprotestoscartorio = value;
            SetDirty("Serasaprotestoscartorio");
         }

      }

      public void gxTv_SdtSerasaProtestos_Serasaprotestoscartorio_SetNull( )
      {
         gxTv_SdtSerasaProtestos_Serasaprotestoscartorio_N = 1;
         gxTv_SdtSerasaProtestos_Serasaprotestoscartorio = "";
         SetDirty("Serasaprotestoscartorio");
         return  ;
      }

      public bool gxTv_SdtSerasaProtestos_Serasaprotestoscartorio_IsNull( )
      {
         return (gxTv_SdtSerasaProtestos_Serasaprotestoscartorio_N==1) ;
      }

      [  SoapElement( ElementName = "SerasaProtestosCidade" )]
      [  XmlElement( ElementName = "SerasaProtestosCidade"   )]
      public string gxTpr_Serasaprotestoscidade
      {
         get {
            return gxTv_SdtSerasaProtestos_Serasaprotestoscidade ;
         }

         set {
            gxTv_SdtSerasaProtestos_Serasaprotestoscidade_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSerasaProtestos_Serasaprotestoscidade = value;
            SetDirty("Serasaprotestoscidade");
         }

      }

      public void gxTv_SdtSerasaProtestos_Serasaprotestoscidade_SetNull( )
      {
         gxTv_SdtSerasaProtestos_Serasaprotestoscidade_N = 1;
         gxTv_SdtSerasaProtestos_Serasaprotestoscidade = "";
         SetDirty("Serasaprotestoscidade");
         return  ;
      }

      public bool gxTv_SdtSerasaProtestos_Serasaprotestoscidade_IsNull( )
      {
         return (gxTv_SdtSerasaProtestos_Serasaprotestoscidade_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtSerasaProtestos_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaProtestos_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtSerasaProtestos_Mode_SetNull( )
      {
         gxTv_SdtSerasaProtestos_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtSerasaProtestos_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtSerasaProtestos_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaProtestos_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtSerasaProtestos_Initialized_SetNull( )
      {
         gxTv_SdtSerasaProtestos_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtSerasaProtestos_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaProtestosId_Z" )]
      [  XmlElement( ElementName = "SerasaProtestosId_Z"   )]
      public int gxTpr_Serasaprotestosid_Z
      {
         get {
            return gxTv_SdtSerasaProtestos_Serasaprotestosid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaProtestos_Serasaprotestosid_Z = value;
            SetDirty("Serasaprotestosid_Z");
         }

      }

      public void gxTv_SdtSerasaProtestos_Serasaprotestosid_Z_SetNull( )
      {
         gxTv_SdtSerasaProtestos_Serasaprotestosid_Z = 0;
         SetDirty("Serasaprotestosid_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaProtestos_Serasaprotestosid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaId_Z" )]
      [  XmlElement( ElementName = "SerasaId_Z"   )]
      public int gxTpr_Serasaid_Z
      {
         get {
            return gxTv_SdtSerasaProtestos_Serasaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaProtestos_Serasaid_Z = value;
            SetDirty("Serasaid_Z");
         }

      }

      public void gxTv_SdtSerasaProtestos_Serasaid_Z_SetNull( )
      {
         gxTv_SdtSerasaProtestos_Serasaid_Z = 0;
         SetDirty("Serasaid_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaProtestos_Serasaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaProtestosData_Z" )]
      [  XmlElement( ElementName = "SerasaProtestosData_Z"  , IsNullable=true )]
      public string gxTpr_Serasaprotestosdata_Z_Nullable
      {
         get {
            if ( gxTv_SdtSerasaProtestos_Serasaprotestosdata_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtSerasaProtestos_Serasaprotestosdata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtSerasaProtestos_Serasaprotestosdata_Z = DateTime.MinValue;
            else
               gxTv_SdtSerasaProtestos_Serasaprotestosdata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Serasaprotestosdata_Z
      {
         get {
            return gxTv_SdtSerasaProtestos_Serasaprotestosdata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaProtestos_Serasaprotestosdata_Z = value;
            SetDirty("Serasaprotestosdata_Z");
         }

      }

      public void gxTv_SdtSerasaProtestos_Serasaprotestosdata_Z_SetNull( )
      {
         gxTv_SdtSerasaProtestos_Serasaprotestosdata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Serasaprotestosdata_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaProtestos_Serasaprotestosdata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaProtestosValor_Z" )]
      [  XmlElement( ElementName = "SerasaProtestosValor_Z"   )]
      public decimal gxTpr_Serasaprotestosvalor_Z
      {
         get {
            return gxTv_SdtSerasaProtestos_Serasaprotestosvalor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaProtestos_Serasaprotestosvalor_Z = value;
            SetDirty("Serasaprotestosvalor_Z");
         }

      }

      public void gxTv_SdtSerasaProtestos_Serasaprotestosvalor_Z_SetNull( )
      {
         gxTv_SdtSerasaProtestos_Serasaprotestosvalor_Z = 0;
         SetDirty("Serasaprotestosvalor_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaProtestos_Serasaprotestosvalor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaProtestosCartorio_Z" )]
      [  XmlElement( ElementName = "SerasaProtestosCartorio_Z"   )]
      public string gxTpr_Serasaprotestoscartorio_Z
      {
         get {
            return gxTv_SdtSerasaProtestos_Serasaprotestoscartorio_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaProtestos_Serasaprotestoscartorio_Z = value;
            SetDirty("Serasaprotestoscartorio_Z");
         }

      }

      public void gxTv_SdtSerasaProtestos_Serasaprotestoscartorio_Z_SetNull( )
      {
         gxTv_SdtSerasaProtestos_Serasaprotestoscartorio_Z = "";
         SetDirty("Serasaprotestoscartorio_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaProtestos_Serasaprotestoscartorio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaProtestosCidade_Z" )]
      [  XmlElement( ElementName = "SerasaProtestosCidade_Z"   )]
      public string gxTpr_Serasaprotestoscidade_Z
      {
         get {
            return gxTv_SdtSerasaProtestos_Serasaprotestoscidade_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaProtestos_Serasaprotestoscidade_Z = value;
            SetDirty("Serasaprotestoscidade_Z");
         }

      }

      public void gxTv_SdtSerasaProtestos_Serasaprotestoscidade_Z_SetNull( )
      {
         gxTv_SdtSerasaProtestos_Serasaprotestoscidade_Z = "";
         SetDirty("Serasaprotestoscidade_Z");
         return  ;
      }

      public bool gxTv_SdtSerasaProtestos_Serasaprotestoscidade_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaId_N" )]
      [  XmlElement( ElementName = "SerasaId_N"   )]
      public short gxTpr_Serasaid_N
      {
         get {
            return gxTv_SdtSerasaProtestos_Serasaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaProtestos_Serasaid_N = value;
            SetDirty("Serasaid_N");
         }

      }

      public void gxTv_SdtSerasaProtestos_Serasaid_N_SetNull( )
      {
         gxTv_SdtSerasaProtestos_Serasaid_N = 0;
         SetDirty("Serasaid_N");
         return  ;
      }

      public bool gxTv_SdtSerasaProtestos_Serasaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaProtestosData_N" )]
      [  XmlElement( ElementName = "SerasaProtestosData_N"   )]
      public short gxTpr_Serasaprotestosdata_N
      {
         get {
            return gxTv_SdtSerasaProtestos_Serasaprotestosdata_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaProtestos_Serasaprotestosdata_N = value;
            SetDirty("Serasaprotestosdata_N");
         }

      }

      public void gxTv_SdtSerasaProtestos_Serasaprotestosdata_N_SetNull( )
      {
         gxTv_SdtSerasaProtestos_Serasaprotestosdata_N = 0;
         SetDirty("Serasaprotestosdata_N");
         return  ;
      }

      public bool gxTv_SdtSerasaProtestos_Serasaprotestosdata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaProtestosValor_N" )]
      [  XmlElement( ElementName = "SerasaProtestosValor_N"   )]
      public short gxTpr_Serasaprotestosvalor_N
      {
         get {
            return gxTv_SdtSerasaProtestos_Serasaprotestosvalor_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaProtestos_Serasaprotestosvalor_N = value;
            SetDirty("Serasaprotestosvalor_N");
         }

      }

      public void gxTv_SdtSerasaProtestos_Serasaprotestosvalor_N_SetNull( )
      {
         gxTv_SdtSerasaProtestos_Serasaprotestosvalor_N = 0;
         SetDirty("Serasaprotestosvalor_N");
         return  ;
      }

      public bool gxTv_SdtSerasaProtestos_Serasaprotestosvalor_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaProtestosCartorio_N" )]
      [  XmlElement( ElementName = "SerasaProtestosCartorio_N"   )]
      public short gxTpr_Serasaprotestoscartorio_N
      {
         get {
            return gxTv_SdtSerasaProtestos_Serasaprotestoscartorio_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaProtestos_Serasaprotestoscartorio_N = value;
            SetDirty("Serasaprotestoscartorio_N");
         }

      }

      public void gxTv_SdtSerasaProtestos_Serasaprotestoscartorio_N_SetNull( )
      {
         gxTv_SdtSerasaProtestos_Serasaprotestoscartorio_N = 0;
         SetDirty("Serasaprotestoscartorio_N");
         return  ;
      }

      public bool gxTv_SdtSerasaProtestos_Serasaprotestoscartorio_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SerasaProtestosCidade_N" )]
      [  XmlElement( ElementName = "SerasaProtestosCidade_N"   )]
      public short gxTpr_Serasaprotestoscidade_N
      {
         get {
            return gxTv_SdtSerasaProtestos_Serasaprotestoscidade_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSerasaProtestos_Serasaprotestoscidade_N = value;
            SetDirty("Serasaprotestoscidade_N");
         }

      }

      public void gxTv_SdtSerasaProtestos_Serasaprotestoscidade_N_SetNull( )
      {
         gxTv_SdtSerasaProtestos_Serasaprotestoscidade_N = 0;
         SetDirty("Serasaprotestoscidade_N");
         return  ;
      }

      public bool gxTv_SdtSerasaProtestos_Serasaprotestoscidade_N_IsNull( )
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
         gxTv_SdtSerasaProtestos_Serasaprotestosdata = DateTime.MinValue;
         gxTv_SdtSerasaProtestos_Serasaprotestoscartorio = "";
         gxTv_SdtSerasaProtestos_Serasaprotestoscidade = "";
         gxTv_SdtSerasaProtestos_Mode = "";
         gxTv_SdtSerasaProtestos_Serasaprotestosdata_Z = DateTime.MinValue;
         gxTv_SdtSerasaProtestos_Serasaprotestoscartorio_Z = "";
         gxTv_SdtSerasaProtestos_Serasaprotestoscidade_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "serasaprotestos", "GeneXus.Programs.serasaprotestos_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtSerasaProtestos_Initialized ;
      private short gxTv_SdtSerasaProtestos_Serasaid_N ;
      private short gxTv_SdtSerasaProtestos_Serasaprotestosdata_N ;
      private short gxTv_SdtSerasaProtestos_Serasaprotestosvalor_N ;
      private short gxTv_SdtSerasaProtestos_Serasaprotestoscartorio_N ;
      private short gxTv_SdtSerasaProtestos_Serasaprotestoscidade_N ;
      private int gxTv_SdtSerasaProtestos_Serasaprotestosid ;
      private int gxTv_SdtSerasaProtestos_Serasaid ;
      private int gxTv_SdtSerasaProtestos_Serasaprotestosid_Z ;
      private int gxTv_SdtSerasaProtestos_Serasaid_Z ;
      private decimal gxTv_SdtSerasaProtestos_Serasaprotestosvalor ;
      private decimal gxTv_SdtSerasaProtestos_Serasaprotestosvalor_Z ;
      private string gxTv_SdtSerasaProtestos_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtSerasaProtestos_Serasaprotestosdata ;
      private DateTime gxTv_SdtSerasaProtestos_Serasaprotestosdata_Z ;
      private string gxTv_SdtSerasaProtestos_Serasaprotestoscartorio ;
      private string gxTv_SdtSerasaProtestos_Serasaprotestoscidade ;
      private string gxTv_SdtSerasaProtestos_Serasaprotestoscartorio_Z ;
      private string gxTv_SdtSerasaProtestos_Serasaprotestoscidade_Z ;
   }

   [DataContract(Name = @"SerasaProtestos", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtSerasaProtestos_RESTInterface : GxGenericCollectionItem<SdtSerasaProtestos>
   {
      public SdtSerasaProtestos_RESTInterface( ) : base()
      {
      }

      public SdtSerasaProtestos_RESTInterface( SdtSerasaProtestos psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SerasaProtestosId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Serasaprotestosid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Serasaprotestosid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Serasaprotestosid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
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

      [DataMember( Name = "SerasaProtestosData" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Serasaprotestosdata
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Serasaprotestosdata) ;
         }

         set {
            sdt.gxTpr_Serasaprotestosdata = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "SerasaProtestosValor" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Serasaprotestosvalor
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Serasaprotestosvalor, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Serasaprotestosvalor = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "SerasaProtestosCartorio" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Serasaprotestoscartorio
      {
         get {
            return sdt.gxTpr_Serasaprotestoscartorio ;
         }

         set {
            sdt.gxTpr_Serasaprotestoscartorio = value;
         }

      }

      [DataMember( Name = "SerasaProtestosCidade" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Serasaprotestoscidade
      {
         get {
            return sdt.gxTpr_Serasaprotestoscidade ;
         }

         set {
            sdt.gxTpr_Serasaprotestoscidade = value;
         }

      }

      public SdtSerasaProtestos sdt
      {
         get {
            return (SdtSerasaProtestos)Sdt ;
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
            sdt = new SdtSerasaProtestos() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 6 )]
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

   [DataContract(Name = @"SerasaProtestos", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtSerasaProtestos_RESTLInterface : GxGenericCollectionItem<SdtSerasaProtestos>
   {
      public SdtSerasaProtestos_RESTLInterface( ) : base()
      {
      }

      public SdtSerasaProtestos_RESTLInterface( SdtSerasaProtestos psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SerasaProtestosData" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Serasaprotestosdata
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Serasaprotestosdata) ;
         }

         set {
            sdt.gxTpr_Serasaprotestosdata = DateTimeUtil.CToD2( value);
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

      public SdtSerasaProtestos sdt
      {
         get {
            return (SdtSerasaProtestos)Sdt ;
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
            sdt = new SdtSerasaProtestos() ;
         }
      }

   }

}
