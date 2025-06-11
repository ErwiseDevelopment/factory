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
   [XmlRoot(ElementName = "Aprovacao" )]
   [XmlType(TypeName =  "Aprovacao" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtAprovacao : GxSilentTrnSdt
   {
      public SdtAprovacao( )
      {
      }

      public SdtAprovacao( IGxContext context )
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

      public void Load( int AV336AprovacaoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV336AprovacaoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"AprovacaoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Aprovacao");
         metadata.Set("BT", "Aprovacao");
         metadata.Set("PK", "[ \"AprovacaoId\" ]");
         metadata.Set("PKAssigned", "[ \"AprovacaoId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"AprovadoresId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"PropostaId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Aprovacaoid_Z");
         state.Add("gxTpr_Aprovadoresid_Z");
         state.Add("gxTpr_Propostaid_Z");
         state.Add("gxTpr_Secusername_Z");
         state.Add("gxTpr_Aprovacaoem_Z_Nullable");
         state.Add("gxTpr_Aprovacaodecisao_Z");
         state.Add("gxTpr_Aprovacaostatus_Z");
         state.Add("gxTpr_Aprovadoresid_N");
         state.Add("gxTpr_Propostaid_N");
         state.Add("gxTpr_Secusername_N");
         state.Add("gxTpr_Aprovacaoem_N");
         state.Add("gxTpr_Aprovacaodecisao_N");
         state.Add("gxTpr_Aprovacaostatus_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtAprovacao sdt;
         sdt = (SdtAprovacao)(source);
         gxTv_SdtAprovacao_Aprovacaoid = sdt.gxTv_SdtAprovacao_Aprovacaoid ;
         gxTv_SdtAprovacao_Aprovadoresid = sdt.gxTv_SdtAprovacao_Aprovadoresid ;
         gxTv_SdtAprovacao_Propostaid = sdt.gxTv_SdtAprovacao_Propostaid ;
         gxTv_SdtAprovacao_Secusername = sdt.gxTv_SdtAprovacao_Secusername ;
         gxTv_SdtAprovacao_Aprovacaoem = sdt.gxTv_SdtAprovacao_Aprovacaoem ;
         gxTv_SdtAprovacao_Aprovacaodecisao = sdt.gxTv_SdtAprovacao_Aprovacaodecisao ;
         gxTv_SdtAprovacao_Aprovacaostatus = sdt.gxTv_SdtAprovacao_Aprovacaostatus ;
         gxTv_SdtAprovacao_Mode = sdt.gxTv_SdtAprovacao_Mode ;
         gxTv_SdtAprovacao_Initialized = sdt.gxTv_SdtAprovacao_Initialized ;
         gxTv_SdtAprovacao_Aprovacaoid_Z = sdt.gxTv_SdtAprovacao_Aprovacaoid_Z ;
         gxTv_SdtAprovacao_Aprovadoresid_Z = sdt.gxTv_SdtAprovacao_Aprovadoresid_Z ;
         gxTv_SdtAprovacao_Propostaid_Z = sdt.gxTv_SdtAprovacao_Propostaid_Z ;
         gxTv_SdtAprovacao_Secusername_Z = sdt.gxTv_SdtAprovacao_Secusername_Z ;
         gxTv_SdtAprovacao_Aprovacaoem_Z = sdt.gxTv_SdtAprovacao_Aprovacaoem_Z ;
         gxTv_SdtAprovacao_Aprovacaodecisao_Z = sdt.gxTv_SdtAprovacao_Aprovacaodecisao_Z ;
         gxTv_SdtAprovacao_Aprovacaostatus_Z = sdt.gxTv_SdtAprovacao_Aprovacaostatus_Z ;
         gxTv_SdtAprovacao_Aprovadoresid_N = sdt.gxTv_SdtAprovacao_Aprovadoresid_N ;
         gxTv_SdtAprovacao_Propostaid_N = sdt.gxTv_SdtAprovacao_Propostaid_N ;
         gxTv_SdtAprovacao_Secusername_N = sdt.gxTv_SdtAprovacao_Secusername_N ;
         gxTv_SdtAprovacao_Aprovacaoem_N = sdt.gxTv_SdtAprovacao_Aprovacaoem_N ;
         gxTv_SdtAprovacao_Aprovacaodecisao_N = sdt.gxTv_SdtAprovacao_Aprovacaodecisao_N ;
         gxTv_SdtAprovacao_Aprovacaostatus_N = sdt.gxTv_SdtAprovacao_Aprovacaostatus_N ;
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
         AddObjectProperty("AprovacaoId", gxTv_SdtAprovacao_Aprovacaoid, false, includeNonInitialized);
         AddObjectProperty("AprovadoresId", gxTv_SdtAprovacao_Aprovadoresid, false, includeNonInitialized);
         AddObjectProperty("AprovadoresId_N", gxTv_SdtAprovacao_Aprovadoresid_N, false, includeNonInitialized);
         AddObjectProperty("PropostaId", gxTv_SdtAprovacao_Propostaid, false, includeNonInitialized);
         AddObjectProperty("PropostaId_N", gxTv_SdtAprovacao_Propostaid_N, false, includeNonInitialized);
         AddObjectProperty("SecUserName", gxTv_SdtAprovacao_Secusername, false, includeNonInitialized);
         AddObjectProperty("SecUserName_N", gxTv_SdtAprovacao_Secusername_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtAprovacao_Aprovacaoem;
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
         AddObjectProperty("AprovacaoEm", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("AprovacaoEm_N", gxTv_SdtAprovacao_Aprovacaoem_N, false, includeNonInitialized);
         AddObjectProperty("AprovacaoDecisao", gxTv_SdtAprovacao_Aprovacaodecisao, false, includeNonInitialized);
         AddObjectProperty("AprovacaoDecisao_N", gxTv_SdtAprovacao_Aprovacaodecisao_N, false, includeNonInitialized);
         AddObjectProperty("AprovacaoStatus", gxTv_SdtAprovacao_Aprovacaostatus, false, includeNonInitialized);
         AddObjectProperty("AprovacaoStatus_N", gxTv_SdtAprovacao_Aprovacaostatus_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtAprovacao_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtAprovacao_Initialized, false, includeNonInitialized);
            AddObjectProperty("AprovacaoId_Z", gxTv_SdtAprovacao_Aprovacaoid_Z, false, includeNonInitialized);
            AddObjectProperty("AprovadoresId_Z", gxTv_SdtAprovacao_Aprovadoresid_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaId_Z", gxTv_SdtAprovacao_Propostaid_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserName_Z", gxTv_SdtAprovacao_Secusername_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtAprovacao_Aprovacaoem_Z;
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
            AddObjectProperty("AprovacaoEm_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("AprovacaoDecisao_Z", gxTv_SdtAprovacao_Aprovacaodecisao_Z, false, includeNonInitialized);
            AddObjectProperty("AprovacaoStatus_Z", gxTv_SdtAprovacao_Aprovacaostatus_Z, false, includeNonInitialized);
            AddObjectProperty("AprovadoresId_N", gxTv_SdtAprovacao_Aprovadoresid_N, false, includeNonInitialized);
            AddObjectProperty("PropostaId_N", gxTv_SdtAprovacao_Propostaid_N, false, includeNonInitialized);
            AddObjectProperty("SecUserName_N", gxTv_SdtAprovacao_Secusername_N, false, includeNonInitialized);
            AddObjectProperty("AprovacaoEm_N", gxTv_SdtAprovacao_Aprovacaoem_N, false, includeNonInitialized);
            AddObjectProperty("AprovacaoDecisao_N", gxTv_SdtAprovacao_Aprovacaodecisao_N, false, includeNonInitialized);
            AddObjectProperty("AprovacaoStatus_N", gxTv_SdtAprovacao_Aprovacaostatus_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtAprovacao sdt )
      {
         if ( sdt.IsDirty("AprovacaoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtAprovacao_Aprovacaoid = sdt.gxTv_SdtAprovacao_Aprovacaoid ;
         }
         if ( sdt.IsDirty("AprovadoresId") )
         {
            gxTv_SdtAprovacao_Aprovadoresid_N = (short)(sdt.gxTv_SdtAprovacao_Aprovadoresid_N);
            sdtIsNull = 0;
            gxTv_SdtAprovacao_Aprovadoresid = sdt.gxTv_SdtAprovacao_Aprovadoresid ;
         }
         if ( sdt.IsDirty("PropostaId") )
         {
            gxTv_SdtAprovacao_Propostaid_N = (short)(sdt.gxTv_SdtAprovacao_Propostaid_N);
            sdtIsNull = 0;
            gxTv_SdtAprovacao_Propostaid = sdt.gxTv_SdtAprovacao_Propostaid ;
         }
         if ( sdt.IsDirty("SecUserName") )
         {
            gxTv_SdtAprovacao_Secusername_N = (short)(sdt.gxTv_SdtAprovacao_Secusername_N);
            sdtIsNull = 0;
            gxTv_SdtAprovacao_Secusername = sdt.gxTv_SdtAprovacao_Secusername ;
         }
         if ( sdt.IsDirty("AprovacaoEm") )
         {
            gxTv_SdtAprovacao_Aprovacaoem_N = (short)(sdt.gxTv_SdtAprovacao_Aprovacaoem_N);
            sdtIsNull = 0;
            gxTv_SdtAprovacao_Aprovacaoem = sdt.gxTv_SdtAprovacao_Aprovacaoem ;
         }
         if ( sdt.IsDirty("AprovacaoDecisao") )
         {
            gxTv_SdtAprovacao_Aprovacaodecisao_N = (short)(sdt.gxTv_SdtAprovacao_Aprovacaodecisao_N);
            sdtIsNull = 0;
            gxTv_SdtAprovacao_Aprovacaodecisao = sdt.gxTv_SdtAprovacao_Aprovacaodecisao ;
         }
         if ( sdt.IsDirty("AprovacaoStatus") )
         {
            gxTv_SdtAprovacao_Aprovacaostatus_N = (short)(sdt.gxTv_SdtAprovacao_Aprovacaostatus_N);
            sdtIsNull = 0;
            gxTv_SdtAprovacao_Aprovacaostatus = sdt.gxTv_SdtAprovacao_Aprovacaostatus ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "AprovacaoId" )]
      [  XmlElement( ElementName = "AprovacaoId"   )]
      public int gxTpr_Aprovacaoid
      {
         get {
            return gxTv_SdtAprovacao_Aprovacaoid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtAprovacao_Aprovacaoid != value )
            {
               gxTv_SdtAprovacao_Mode = "INS";
               this.gxTv_SdtAprovacao_Aprovacaoid_Z_SetNull( );
               this.gxTv_SdtAprovacao_Aprovadoresid_Z_SetNull( );
               this.gxTv_SdtAprovacao_Propostaid_Z_SetNull( );
               this.gxTv_SdtAprovacao_Secusername_Z_SetNull( );
               this.gxTv_SdtAprovacao_Aprovacaoem_Z_SetNull( );
               this.gxTv_SdtAprovacao_Aprovacaodecisao_Z_SetNull( );
               this.gxTv_SdtAprovacao_Aprovacaostatus_Z_SetNull( );
            }
            gxTv_SdtAprovacao_Aprovacaoid = value;
            SetDirty("Aprovacaoid");
         }

      }

      [  SoapElement( ElementName = "AprovadoresId" )]
      [  XmlElement( ElementName = "AprovadoresId"   )]
      public int gxTpr_Aprovadoresid
      {
         get {
            return gxTv_SdtAprovacao_Aprovadoresid ;
         }

         set {
            gxTv_SdtAprovacao_Aprovadoresid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAprovacao_Aprovadoresid = value;
            SetDirty("Aprovadoresid");
         }

      }

      public void gxTv_SdtAprovacao_Aprovadoresid_SetNull( )
      {
         gxTv_SdtAprovacao_Aprovadoresid_N = 1;
         gxTv_SdtAprovacao_Aprovadoresid = 0;
         SetDirty("Aprovadoresid");
         return  ;
      }

      public bool gxTv_SdtAprovacao_Aprovadoresid_IsNull( )
      {
         return (gxTv_SdtAprovacao_Aprovadoresid_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaId" )]
      [  XmlElement( ElementName = "PropostaId"   )]
      public int gxTpr_Propostaid
      {
         get {
            return gxTv_SdtAprovacao_Propostaid ;
         }

         set {
            gxTv_SdtAprovacao_Propostaid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAprovacao_Propostaid = value;
            SetDirty("Propostaid");
         }

      }

      public void gxTv_SdtAprovacao_Propostaid_SetNull( )
      {
         gxTv_SdtAprovacao_Propostaid_N = 1;
         gxTv_SdtAprovacao_Propostaid = 0;
         SetDirty("Propostaid");
         return  ;
      }

      public bool gxTv_SdtAprovacao_Propostaid_IsNull( )
      {
         return (gxTv_SdtAprovacao_Propostaid_N==1) ;
      }

      [  SoapElement( ElementName = "SecUserName" )]
      [  XmlElement( ElementName = "SecUserName"   )]
      public string gxTpr_Secusername
      {
         get {
            return gxTv_SdtAprovacao_Secusername ;
         }

         set {
            gxTv_SdtAprovacao_Secusername_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAprovacao_Secusername = value;
            SetDirty("Secusername");
         }

      }

      public void gxTv_SdtAprovacao_Secusername_SetNull( )
      {
         gxTv_SdtAprovacao_Secusername_N = 1;
         gxTv_SdtAprovacao_Secusername = "";
         SetDirty("Secusername");
         return  ;
      }

      public bool gxTv_SdtAprovacao_Secusername_IsNull( )
      {
         return (gxTv_SdtAprovacao_Secusername_N==1) ;
      }

      [  SoapElement( ElementName = "AprovacaoEm" )]
      [  XmlElement( ElementName = "AprovacaoEm"  , IsNullable=true )]
      public string gxTpr_Aprovacaoem_Nullable
      {
         get {
            if ( gxTv_SdtAprovacao_Aprovacaoem == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtAprovacao_Aprovacaoem).value ;
         }

         set {
            gxTv_SdtAprovacao_Aprovacaoem_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtAprovacao_Aprovacaoem = DateTime.MinValue;
            else
               gxTv_SdtAprovacao_Aprovacaoem = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Aprovacaoem
      {
         get {
            return gxTv_SdtAprovacao_Aprovacaoem ;
         }

         set {
            gxTv_SdtAprovacao_Aprovacaoem_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAprovacao_Aprovacaoem = value;
            SetDirty("Aprovacaoem");
         }

      }

      public void gxTv_SdtAprovacao_Aprovacaoem_SetNull( )
      {
         gxTv_SdtAprovacao_Aprovacaoem_N = 1;
         gxTv_SdtAprovacao_Aprovacaoem = (DateTime)(DateTime.MinValue);
         SetDirty("Aprovacaoem");
         return  ;
      }

      public bool gxTv_SdtAprovacao_Aprovacaoem_IsNull( )
      {
         return (gxTv_SdtAprovacao_Aprovacaoem_N==1) ;
      }

      [  SoapElement( ElementName = "AprovacaoDecisao" )]
      [  XmlElement( ElementName = "AprovacaoDecisao"   )]
      public string gxTpr_Aprovacaodecisao
      {
         get {
            return gxTv_SdtAprovacao_Aprovacaodecisao ;
         }

         set {
            gxTv_SdtAprovacao_Aprovacaodecisao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAprovacao_Aprovacaodecisao = value;
            SetDirty("Aprovacaodecisao");
         }

      }

      public void gxTv_SdtAprovacao_Aprovacaodecisao_SetNull( )
      {
         gxTv_SdtAprovacao_Aprovacaodecisao_N = 1;
         gxTv_SdtAprovacao_Aprovacaodecisao = "";
         SetDirty("Aprovacaodecisao");
         return  ;
      }

      public bool gxTv_SdtAprovacao_Aprovacaodecisao_IsNull( )
      {
         return (gxTv_SdtAprovacao_Aprovacaodecisao_N==1) ;
      }

      [  SoapElement( ElementName = "AprovacaoStatus" )]
      [  XmlElement( ElementName = "AprovacaoStatus"   )]
      public string gxTpr_Aprovacaostatus
      {
         get {
            return gxTv_SdtAprovacao_Aprovacaostatus ;
         }

         set {
            gxTv_SdtAprovacao_Aprovacaostatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtAprovacao_Aprovacaostatus = value;
            SetDirty("Aprovacaostatus");
         }

      }

      public void gxTv_SdtAprovacao_Aprovacaostatus_SetNull( )
      {
         gxTv_SdtAprovacao_Aprovacaostatus_N = 1;
         gxTv_SdtAprovacao_Aprovacaostatus = "";
         SetDirty("Aprovacaostatus");
         return  ;
      }

      public bool gxTv_SdtAprovacao_Aprovacaostatus_IsNull( )
      {
         return (gxTv_SdtAprovacao_Aprovacaostatus_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtAprovacao_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAprovacao_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtAprovacao_Mode_SetNull( )
      {
         gxTv_SdtAprovacao_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtAprovacao_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtAprovacao_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAprovacao_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtAprovacao_Initialized_SetNull( )
      {
         gxTv_SdtAprovacao_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtAprovacao_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AprovacaoId_Z" )]
      [  XmlElement( ElementName = "AprovacaoId_Z"   )]
      public int gxTpr_Aprovacaoid_Z
      {
         get {
            return gxTv_SdtAprovacao_Aprovacaoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAprovacao_Aprovacaoid_Z = value;
            SetDirty("Aprovacaoid_Z");
         }

      }

      public void gxTv_SdtAprovacao_Aprovacaoid_Z_SetNull( )
      {
         gxTv_SdtAprovacao_Aprovacaoid_Z = 0;
         SetDirty("Aprovacaoid_Z");
         return  ;
      }

      public bool gxTv_SdtAprovacao_Aprovacaoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AprovadoresId_Z" )]
      [  XmlElement( ElementName = "AprovadoresId_Z"   )]
      public int gxTpr_Aprovadoresid_Z
      {
         get {
            return gxTv_SdtAprovacao_Aprovadoresid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAprovacao_Aprovadoresid_Z = value;
            SetDirty("Aprovadoresid_Z");
         }

      }

      public void gxTv_SdtAprovacao_Aprovadoresid_Z_SetNull( )
      {
         gxTv_SdtAprovacao_Aprovadoresid_Z = 0;
         SetDirty("Aprovadoresid_Z");
         return  ;
      }

      public bool gxTv_SdtAprovacao_Aprovadoresid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaId_Z" )]
      [  XmlElement( ElementName = "PropostaId_Z"   )]
      public int gxTpr_Propostaid_Z
      {
         get {
            return gxTv_SdtAprovacao_Propostaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAprovacao_Propostaid_Z = value;
            SetDirty("Propostaid_Z");
         }

      }

      public void gxTv_SdtAprovacao_Propostaid_Z_SetNull( )
      {
         gxTv_SdtAprovacao_Propostaid_Z = 0;
         SetDirty("Propostaid_Z");
         return  ;
      }

      public bool gxTv_SdtAprovacao_Propostaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserName_Z" )]
      [  XmlElement( ElementName = "SecUserName_Z"   )]
      public string gxTpr_Secusername_Z
      {
         get {
            return gxTv_SdtAprovacao_Secusername_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAprovacao_Secusername_Z = value;
            SetDirty("Secusername_Z");
         }

      }

      public void gxTv_SdtAprovacao_Secusername_Z_SetNull( )
      {
         gxTv_SdtAprovacao_Secusername_Z = "";
         SetDirty("Secusername_Z");
         return  ;
      }

      public bool gxTv_SdtAprovacao_Secusername_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AprovacaoEm_Z" )]
      [  XmlElement( ElementName = "AprovacaoEm_Z"  , IsNullable=true )]
      public string gxTpr_Aprovacaoem_Z_Nullable
      {
         get {
            if ( gxTv_SdtAprovacao_Aprovacaoem_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtAprovacao_Aprovacaoem_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtAprovacao_Aprovacaoem_Z = DateTime.MinValue;
            else
               gxTv_SdtAprovacao_Aprovacaoem_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Aprovacaoem_Z
      {
         get {
            return gxTv_SdtAprovacao_Aprovacaoem_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAprovacao_Aprovacaoem_Z = value;
            SetDirty("Aprovacaoem_Z");
         }

      }

      public void gxTv_SdtAprovacao_Aprovacaoem_Z_SetNull( )
      {
         gxTv_SdtAprovacao_Aprovacaoem_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Aprovacaoem_Z");
         return  ;
      }

      public bool gxTv_SdtAprovacao_Aprovacaoem_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AprovacaoDecisao_Z" )]
      [  XmlElement( ElementName = "AprovacaoDecisao_Z"   )]
      public string gxTpr_Aprovacaodecisao_Z
      {
         get {
            return gxTv_SdtAprovacao_Aprovacaodecisao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAprovacao_Aprovacaodecisao_Z = value;
            SetDirty("Aprovacaodecisao_Z");
         }

      }

      public void gxTv_SdtAprovacao_Aprovacaodecisao_Z_SetNull( )
      {
         gxTv_SdtAprovacao_Aprovacaodecisao_Z = "";
         SetDirty("Aprovacaodecisao_Z");
         return  ;
      }

      public bool gxTv_SdtAprovacao_Aprovacaodecisao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AprovacaoStatus_Z" )]
      [  XmlElement( ElementName = "AprovacaoStatus_Z"   )]
      public string gxTpr_Aprovacaostatus_Z
      {
         get {
            return gxTv_SdtAprovacao_Aprovacaostatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAprovacao_Aprovacaostatus_Z = value;
            SetDirty("Aprovacaostatus_Z");
         }

      }

      public void gxTv_SdtAprovacao_Aprovacaostatus_Z_SetNull( )
      {
         gxTv_SdtAprovacao_Aprovacaostatus_Z = "";
         SetDirty("Aprovacaostatus_Z");
         return  ;
      }

      public bool gxTv_SdtAprovacao_Aprovacaostatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AprovadoresId_N" )]
      [  XmlElement( ElementName = "AprovadoresId_N"   )]
      public short gxTpr_Aprovadoresid_N
      {
         get {
            return gxTv_SdtAprovacao_Aprovadoresid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAprovacao_Aprovadoresid_N = value;
            SetDirty("Aprovadoresid_N");
         }

      }

      public void gxTv_SdtAprovacao_Aprovadoresid_N_SetNull( )
      {
         gxTv_SdtAprovacao_Aprovadoresid_N = 0;
         SetDirty("Aprovadoresid_N");
         return  ;
      }

      public bool gxTv_SdtAprovacao_Aprovadoresid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaId_N" )]
      [  XmlElement( ElementName = "PropostaId_N"   )]
      public short gxTpr_Propostaid_N
      {
         get {
            return gxTv_SdtAprovacao_Propostaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAprovacao_Propostaid_N = value;
            SetDirty("Propostaid_N");
         }

      }

      public void gxTv_SdtAprovacao_Propostaid_N_SetNull( )
      {
         gxTv_SdtAprovacao_Propostaid_N = 0;
         SetDirty("Propostaid_N");
         return  ;
      }

      public bool gxTv_SdtAprovacao_Propostaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserName_N" )]
      [  XmlElement( ElementName = "SecUserName_N"   )]
      public short gxTpr_Secusername_N
      {
         get {
            return gxTv_SdtAprovacao_Secusername_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAprovacao_Secusername_N = value;
            SetDirty("Secusername_N");
         }

      }

      public void gxTv_SdtAprovacao_Secusername_N_SetNull( )
      {
         gxTv_SdtAprovacao_Secusername_N = 0;
         SetDirty("Secusername_N");
         return  ;
      }

      public bool gxTv_SdtAprovacao_Secusername_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AprovacaoEm_N" )]
      [  XmlElement( ElementName = "AprovacaoEm_N"   )]
      public short gxTpr_Aprovacaoem_N
      {
         get {
            return gxTv_SdtAprovacao_Aprovacaoem_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAprovacao_Aprovacaoem_N = value;
            SetDirty("Aprovacaoem_N");
         }

      }

      public void gxTv_SdtAprovacao_Aprovacaoem_N_SetNull( )
      {
         gxTv_SdtAprovacao_Aprovacaoem_N = 0;
         SetDirty("Aprovacaoem_N");
         return  ;
      }

      public bool gxTv_SdtAprovacao_Aprovacaoem_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AprovacaoDecisao_N" )]
      [  XmlElement( ElementName = "AprovacaoDecisao_N"   )]
      public short gxTpr_Aprovacaodecisao_N
      {
         get {
            return gxTv_SdtAprovacao_Aprovacaodecisao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAprovacao_Aprovacaodecisao_N = value;
            SetDirty("Aprovacaodecisao_N");
         }

      }

      public void gxTv_SdtAprovacao_Aprovacaodecisao_N_SetNull( )
      {
         gxTv_SdtAprovacao_Aprovacaodecisao_N = 0;
         SetDirty("Aprovacaodecisao_N");
         return  ;
      }

      public bool gxTv_SdtAprovacao_Aprovacaodecisao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AprovacaoStatus_N" )]
      [  XmlElement( ElementName = "AprovacaoStatus_N"   )]
      public short gxTpr_Aprovacaostatus_N
      {
         get {
            return gxTv_SdtAprovacao_Aprovacaostatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtAprovacao_Aprovacaostatus_N = value;
            SetDirty("Aprovacaostatus_N");
         }

      }

      public void gxTv_SdtAprovacao_Aprovacaostatus_N_SetNull( )
      {
         gxTv_SdtAprovacao_Aprovacaostatus_N = 0;
         SetDirty("Aprovacaostatus_N");
         return  ;
      }

      public bool gxTv_SdtAprovacao_Aprovacaostatus_N_IsNull( )
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
         gxTv_SdtAprovacao_Secusername = "";
         gxTv_SdtAprovacao_Aprovacaoem = (DateTime)(DateTime.MinValue);
         gxTv_SdtAprovacao_Aprovacaodecisao = "";
         gxTv_SdtAprovacao_Aprovacaostatus = "";
         gxTv_SdtAprovacao_Mode = "";
         gxTv_SdtAprovacao_Secusername_Z = "";
         gxTv_SdtAprovacao_Aprovacaoem_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtAprovacao_Aprovacaodecisao_Z = "";
         gxTv_SdtAprovacao_Aprovacaostatus_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "aprovacao", "GeneXus.Programs.aprovacao_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtAprovacao_Initialized ;
      private short gxTv_SdtAprovacao_Aprovadoresid_N ;
      private short gxTv_SdtAprovacao_Propostaid_N ;
      private short gxTv_SdtAprovacao_Secusername_N ;
      private short gxTv_SdtAprovacao_Aprovacaoem_N ;
      private short gxTv_SdtAprovacao_Aprovacaodecisao_N ;
      private short gxTv_SdtAprovacao_Aprovacaostatus_N ;
      private int gxTv_SdtAprovacao_Aprovacaoid ;
      private int gxTv_SdtAprovacao_Aprovadoresid ;
      private int gxTv_SdtAprovacao_Propostaid ;
      private int gxTv_SdtAprovacao_Aprovacaoid_Z ;
      private int gxTv_SdtAprovacao_Aprovadoresid_Z ;
      private int gxTv_SdtAprovacao_Propostaid_Z ;
      private string gxTv_SdtAprovacao_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtAprovacao_Aprovacaoem ;
      private DateTime gxTv_SdtAprovacao_Aprovacaoem_Z ;
      private DateTime datetime_STZ ;
      private string gxTv_SdtAprovacao_Secusername ;
      private string gxTv_SdtAprovacao_Aprovacaodecisao ;
      private string gxTv_SdtAprovacao_Aprovacaostatus ;
      private string gxTv_SdtAprovacao_Secusername_Z ;
      private string gxTv_SdtAprovacao_Aprovacaodecisao_Z ;
      private string gxTv_SdtAprovacao_Aprovacaostatus_Z ;
   }

   [DataContract(Name = @"Aprovacao", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtAprovacao_RESTInterface : GxGenericCollectionItem<SdtAprovacao>
   {
      public SdtAprovacao_RESTInterface( ) : base()
      {
      }

      public SdtAprovacao_RESTInterface( SdtAprovacao psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AprovacaoId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Aprovacaoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Aprovacaoid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Aprovacaoid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "AprovadoresId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Aprovadoresid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Aprovadoresid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Aprovadoresid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "PropostaId" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Propostaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Propostaid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Propostaid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "SecUserName" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Secusername
      {
         get {
            return sdt.gxTpr_Secusername ;
         }

         set {
            sdt.gxTpr_Secusername = value;
         }

      }

      [DataMember( Name = "AprovacaoEm" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Aprovacaoem
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Aprovacaoem, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Aprovacaoem = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "AprovacaoDecisao" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Aprovacaodecisao
      {
         get {
            return sdt.gxTpr_Aprovacaodecisao ;
         }

         set {
            sdt.gxTpr_Aprovacaodecisao = value;
         }

      }

      [DataMember( Name = "AprovacaoStatus" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Aprovacaostatus
      {
         get {
            return sdt.gxTpr_Aprovacaostatus ;
         }

         set {
            sdt.gxTpr_Aprovacaostatus = value;
         }

      }

      public SdtAprovacao sdt
      {
         get {
            return (SdtAprovacao)Sdt ;
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
            sdt = new SdtAprovacao() ;
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

   [DataContract(Name = @"Aprovacao", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtAprovacao_RESTLInterface : GxGenericCollectionItem<SdtAprovacao>
   {
      public SdtAprovacao_RESTLInterface( ) : base()
      {
      }

      public SdtAprovacao_RESTLInterface( SdtAprovacao psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AprovacaoEm" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Aprovacaoem
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Aprovacaoem, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Aprovacaoem = DateTimeUtil.CToT2( value, (IGxContext)(context));
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

      public SdtAprovacao sdt
      {
         get {
            return (SdtAprovacao)Sdt ;
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
            sdt = new SdtAprovacao() ;
         }
      }

   }

}
