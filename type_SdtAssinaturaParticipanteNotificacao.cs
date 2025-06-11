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
   [XmlRoot(ElementName = "AssinaturaParticipanteNotificacao" )]
   [XmlType(TypeName =  "AssinaturaParticipanteNotificacao" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtAssinaturaParticipanteNotificacao : GxSilentTrnSdt
   {
      public SdtAssinaturaParticipanteNotificacao( )
      {
      }

      public SdtAssinaturaParticipanteNotificacao( IGxContext context )
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

      public void Load( int AV258AssinaturaParticipanteNotificacaoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV258AssinaturaParticipanteNotificacaoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"AssinaturaParticipanteNotificacaoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "AssinaturaParticipanteNotificacao");
         metadata.Set("BT", "AssinaturaParticipanteNotificacao");
         metadata.Set("PK", "[ \"AssinaturaParticipanteNotificacaoId\" ]");
         metadata.Set("PKAssigned", "[ \"AssinaturaParticipanteNotificacaoId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"AssinaturaParticipanteId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Assinaturaparticipantenotificacaoid_Z");
         state.Add("gxTpr_Assinaturaparticipanteid_Z");
         state.Add("gxTpr_Assinaturaparticipantenotificacaodata_Z_Nullable");
         state.Add("gxTpr_Assinaturaparticipantenotificacaostatus_Z");
         state.Add("gxTpr_Assinaturaparticipanteid_N");
         state.Add("gxTpr_Assinaturaparticipantenotificacaodata_N");
         state.Add("gxTpr_Assinaturaparticipantenotificacaostatus_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtAssinaturaParticipanteNotificacao sdt;
         sdt = (SdtAssinaturaParticipanteNotificacao)(source);
         gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaoid = sdt.gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaoid ;
         gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipanteid = sdt.gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipanteid ;
         gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata = sdt.gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata ;
         gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus = sdt.gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus ;
         gxTv_SdtAssinaturaParticipanteNotificacao_Mode = sdt.gxTv_SdtAssinaturaParticipanteNotificacao_Mode ;
         gxTv_SdtAssinaturaParticipanteNotificacao_Initialized = sdt.gxTv_SdtAssinaturaParticipanteNotificacao_Initialized ;
         gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaoid_Z = sdt.gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaoid_Z ;
         gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipanteid_Z = sdt.gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipanteid_Z ;
         gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata_Z = sdt.gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata_Z ;
         gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus_Z = sdt.gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus_Z ;
         gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipanteid_N = sdt.gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipanteid_N ;
         gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata_N = sdt.gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata_N ;
         gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus_N = sdt.gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus_N ;
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
         AddObjectProperty("AssinaturaParticipanteNotificacaoId", gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaoid, false, includeNonInitialized);
         AddObjectProperty("AssinaturaParticipanteId", gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipanteid, false, includeNonInitialized);
         AddObjectProperty("AssinaturaParticipanteId_N", gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipanteid_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata;
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
         AddObjectProperty("AssinaturaParticipanteNotificacaoData", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("AssinaturaParticipanteNotificacaoData_N", gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata_N, false, includeNonInitialized);
         AddObjectProperty("AssinaturaParticipanteNotificacaoStatus", gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus, false, includeNonInitialized);
         AddObjectProperty("AssinaturaParticipanteNotificacaoStatus_N", gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtAssinaturaParticipanteNotificacao_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtAssinaturaParticipanteNotificacao_Initialized, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteNotificacaoId_Z", gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaoid_Z, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteId_Z", gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipanteid_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata_Z;
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
            AddObjectProperty("AssinaturaParticipanteNotificacaoData_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteNotificacaoStatus_Z", gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus_Z, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteId_N", gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipanteid_N, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteNotificacaoData_N", gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata_N, false, includeNonInitialized);
            AddObjectProperty("AssinaturaParticipanteNotificacaoStatus_N", gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtAssinaturaParticipanteNotificacao sdt )
      {
         if ( sdt.IsDirty("AssinaturaParticipanteNotificacaoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaoid = sdt.gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaoid ;
         }
         if ( sdt.IsDirty("AssinaturaParticipanteId") )
         {
            gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipanteid_N = (short)(sdt.gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipanteid_N);
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipanteid = sdt.gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipanteid ;
         }
         if ( sdt.IsDirty("AssinaturaParticipanteNotificacaoData") )
         {
            gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata_N = (short)(sdt.gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata_N);
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata = sdt.gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata ;
         }
         if ( sdt.IsDirty("AssinaturaParticipanteNotificacaoStatus") )
         {
            gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus_N = (short)(sdt.gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus_N);
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus = sdt.gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteNotificacaoId" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteNotificacaoId"   )]
      public int gxTpr_Assinaturaparticipantenotificacaoid
      {
         get {
            return gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaoid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaoid != value )
            {
               gxTv_SdtAssinaturaParticipanteNotificacao_Mode = "INS";
               this.gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaoid_Z_SetNull( );
               this.gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipanteid_Z_SetNull( );
               this.gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata_Z_SetNull( );
               this.gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus_Z_SetNull( );
            }
            gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaoid = value;
            SetDirty("Assinaturaparticipantenotificacaoid");
         }

      }

      [  SoapElement( ElementName = "AssinaturaParticipanteId" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteId"   )]
      public int gxTpr_Assinaturaparticipanteid
      {
         get {
            return gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipanteid ;
         }

         set {
            gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipanteid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipanteid = value;
            SetDirty("Assinaturaparticipanteid");
         }

      }

      public void gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipanteid_SetNull( )
      {
         gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipanteid_N = 1;
         gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipanteid = 0;
         SetDirty("Assinaturaparticipanteid");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipanteid_IsNull( )
      {
         return (gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipanteid_N==1) ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteNotificacaoData" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteNotificacaoData"  , IsNullable=true )]
      public string gxTpr_Assinaturaparticipantenotificacaodata_Nullable
      {
         get {
            if ( gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata).value ;
         }

         set {
            gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata = DateTime.MinValue;
            else
               gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Assinaturaparticipantenotificacaodata
      {
         get {
            return gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata ;
         }

         set {
            gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata = value;
            SetDirty("Assinaturaparticipantenotificacaodata");
         }

      }

      public void gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata_SetNull( )
      {
         gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata_N = 1;
         gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata = (DateTime)(DateTime.MinValue);
         SetDirty("Assinaturaparticipantenotificacaodata");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata_IsNull( )
      {
         return (gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata_N==1) ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteNotificacaoStatus" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteNotificacaoStatus"   )]
      public string gxTpr_Assinaturaparticipantenotificacaostatus
      {
         get {
            return gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus ;
         }

         set {
            gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus = value;
            SetDirty("Assinaturaparticipantenotificacaostatus");
         }

      }

      public void gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus_SetNull( )
      {
         gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus_N = 1;
         gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus = "";
         SetDirty("Assinaturaparticipantenotificacaostatus");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus_IsNull( )
      {
         return (gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtAssinaturaParticipanteNotificacao_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipanteNotificacao_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtAssinaturaParticipanteNotificacao_Mode_SetNull( )
      {
         gxTv_SdtAssinaturaParticipanteNotificacao_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipanteNotificacao_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtAssinaturaParticipanteNotificacao_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipanteNotificacao_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtAssinaturaParticipanteNotificacao_Initialized_SetNull( )
      {
         gxTv_SdtAssinaturaParticipanteNotificacao_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipanteNotificacao_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteNotificacaoId_Z" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteNotificacaoId_Z"   )]
      public int gxTpr_Assinaturaparticipantenotificacaoid_Z
      {
         get {
            return gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaoid_Z = value;
            SetDirty("Assinaturaparticipantenotificacaoid_Z");
         }

      }

      public void gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaoid_Z_SetNull( )
      {
         gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaoid_Z = 0;
         SetDirty("Assinaturaparticipantenotificacaoid_Z");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteId_Z" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteId_Z"   )]
      public int gxTpr_Assinaturaparticipanteid_Z
      {
         get {
            return gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipanteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipanteid_Z = value;
            SetDirty("Assinaturaparticipanteid_Z");
         }

      }

      public void gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipanteid_Z_SetNull( )
      {
         gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipanteid_Z = 0;
         SetDirty("Assinaturaparticipanteid_Z");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipanteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteNotificacaoData_Z" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteNotificacaoData_Z"  , IsNullable=true )]
      public string gxTpr_Assinaturaparticipantenotificacaodata_Z_Nullable
      {
         get {
            if ( gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata_Z = DateTime.MinValue;
            else
               gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Assinaturaparticipantenotificacaodata_Z
      {
         get {
            return gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata_Z = value;
            SetDirty("Assinaturaparticipantenotificacaodata_Z");
         }

      }

      public void gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata_Z_SetNull( )
      {
         gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Assinaturaparticipantenotificacaodata_Z");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteNotificacaoStatus_Z" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteNotificacaoStatus_Z"   )]
      public string gxTpr_Assinaturaparticipantenotificacaostatus_Z
      {
         get {
            return gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus_Z = value;
            SetDirty("Assinaturaparticipantenotificacaostatus_Z");
         }

      }

      public void gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus_Z_SetNull( )
      {
         gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus_Z = "";
         SetDirty("Assinaturaparticipantenotificacaostatus_Z");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteId_N" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteId_N"   )]
      public short gxTpr_Assinaturaparticipanteid_N
      {
         get {
            return gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipanteid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipanteid_N = value;
            SetDirty("Assinaturaparticipanteid_N");
         }

      }

      public void gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipanteid_N_SetNull( )
      {
         gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipanteid_N = 0;
         SetDirty("Assinaturaparticipanteid_N");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipanteid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteNotificacaoData_N" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteNotificacaoData_N"   )]
      public short gxTpr_Assinaturaparticipantenotificacaodata_N
      {
         get {
            return gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata_N = value;
            SetDirty("Assinaturaparticipantenotificacaodata_N");
         }

      }

      public void gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata_N_SetNull( )
      {
         gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata_N = 0;
         SetDirty("Assinaturaparticipantenotificacaodata_N");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AssinaturaParticipanteNotificacaoStatus_N" )]
      [  XmlElement( ElementName = "AssinaturaParticipanteNotificacaoStatus_N"   )]
      public short gxTpr_Assinaturaparticipantenotificacaostatus_N
      {
         get {
            return gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus_N = value;
            SetDirty("Assinaturaparticipantenotificacaostatus_N");
         }

      }

      public void gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus_N_SetNull( )
      {
         gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus_N = 0;
         SetDirty("Assinaturaparticipantenotificacaostatus_N");
         return  ;
      }

      public bool gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus_N_IsNull( )
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
         gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata = (DateTime)(DateTime.MinValue);
         gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus = "";
         gxTv_SdtAssinaturaParticipanteNotificacao_Mode = "";
         gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "assinaturaparticipantenotificacao", "GeneXus.Programs.assinaturaparticipantenotificacao_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtAssinaturaParticipanteNotificacao_Initialized ;
      private short gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipanteid_N ;
      private short gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata_N ;
      private short gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus_N ;
      private int gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaoid ;
      private int gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipanteid ;
      private int gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaoid_Z ;
      private int gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipanteid_Z ;
      private string gxTv_SdtAssinaturaParticipanteNotificacao_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata ;
      private DateTime gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaodata_Z ;
      private DateTime datetime_STZ ;
      private string gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus ;
      private string gxTv_SdtAssinaturaParticipanteNotificacao_Assinaturaparticipantenotificacaostatus_Z ;
   }

   [DataContract(Name = @"AssinaturaParticipanteNotificacao", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtAssinaturaParticipanteNotificacao_RESTInterface : GxGenericCollectionItem<SdtAssinaturaParticipanteNotificacao>
   {
      public SdtAssinaturaParticipanteNotificacao_RESTInterface( ) : base()
      {
      }

      public SdtAssinaturaParticipanteNotificacao_RESTInterface( SdtAssinaturaParticipanteNotificacao psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AssinaturaParticipanteNotificacaoId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Assinaturaparticipantenotificacaoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Assinaturaparticipantenotificacaoid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Assinaturaparticipantenotificacaoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "AssinaturaParticipanteId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Assinaturaparticipanteid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Assinaturaparticipanteid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Assinaturaparticipanteid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "AssinaturaParticipanteNotificacaoData" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Assinaturaparticipantenotificacaodata
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Assinaturaparticipantenotificacaodata, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Assinaturaparticipantenotificacaodata = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "AssinaturaParticipanteNotificacaoStatus" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Assinaturaparticipantenotificacaostatus
      {
         get {
            return sdt.gxTpr_Assinaturaparticipantenotificacaostatus ;
         }

         set {
            sdt.gxTpr_Assinaturaparticipantenotificacaostatus = value;
         }

      }

      public SdtAssinaturaParticipanteNotificacao sdt
      {
         get {
            return (SdtAssinaturaParticipanteNotificacao)Sdt ;
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
            sdt = new SdtAssinaturaParticipanteNotificacao() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 4 )]
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

   [DataContract(Name = @"AssinaturaParticipanteNotificacao", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtAssinaturaParticipanteNotificacao_RESTLInterface : GxGenericCollectionItem<SdtAssinaturaParticipanteNotificacao>
   {
      public SdtAssinaturaParticipanteNotificacao_RESTLInterface( ) : base()
      {
      }

      public SdtAssinaturaParticipanteNotificacao_RESTLInterface( SdtAssinaturaParticipanteNotificacao psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AssinaturaParticipanteNotificacaoData" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Assinaturaparticipantenotificacaodata
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Assinaturaparticipantenotificacaodata, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Assinaturaparticipantenotificacaodata = DateTimeUtil.CToT2( value, (IGxContext)(context));
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

      public SdtAssinaturaParticipanteNotificacao sdt
      {
         get {
            return (SdtAssinaturaParticipanteNotificacao)Sdt ;
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
            sdt = new SdtAssinaturaParticipanteNotificacao() ;
         }
      }

   }

}
