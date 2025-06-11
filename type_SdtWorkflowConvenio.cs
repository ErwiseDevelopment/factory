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
   [XmlRoot(ElementName = "WorkflowConvenio" )]
   [XmlType(TypeName =  "WorkflowConvenio" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtWorkflowConvenio : GxSilentTrnSdt
   {
      public SdtWorkflowConvenio( )
      {
      }

      public SdtWorkflowConvenio( IGxContext context )
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

      public void Load( int AV742WorkflowConvenioId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV742WorkflowConvenioId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"WorkflowConvenioId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "WorkflowConvenio");
         metadata.Set("BT", "WorkflowConvenio");
         metadata.Set("PK", "[ \"WorkflowConvenioId\" ]");
         metadata.Set("PKAssigned", "[ \"WorkflowConvenioId\" ]");
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
         state.Add("gxTpr_Workflowconvenioid_Z");
         state.Add("gxTpr_Workflowconveniodesc_Z");
         state.Add("gxTpr_Workflowconveniostatus_Z");
         state.Add("gxTpr_Workflowconveniocreatedat_Z_Nullable");
         state.Add("gxTpr_Workflowconveniosla_Z");
         state.Add("gxTpr_Workflowconvenioid_N");
         state.Add("gxTpr_Workflowconveniodesc_N");
         state.Add("gxTpr_Workflowconveniostatus_N");
         state.Add("gxTpr_Workflowconveniocreatedat_N");
         state.Add("gxTpr_Workflowconveniosla_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtWorkflowConvenio sdt;
         sdt = (SdtWorkflowConvenio)(source);
         gxTv_SdtWorkflowConvenio_Workflowconvenioid = sdt.gxTv_SdtWorkflowConvenio_Workflowconvenioid ;
         gxTv_SdtWorkflowConvenio_Workflowconveniodesc = sdt.gxTv_SdtWorkflowConvenio_Workflowconveniodesc ;
         gxTv_SdtWorkflowConvenio_Workflowconveniostatus = sdt.gxTv_SdtWorkflowConvenio_Workflowconveniostatus ;
         gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat = sdt.gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat ;
         gxTv_SdtWorkflowConvenio_Workflowconveniosla = sdt.gxTv_SdtWorkflowConvenio_Workflowconveniosla ;
         gxTv_SdtWorkflowConvenio_Mode = sdt.gxTv_SdtWorkflowConvenio_Mode ;
         gxTv_SdtWorkflowConvenio_Initialized = sdt.gxTv_SdtWorkflowConvenio_Initialized ;
         gxTv_SdtWorkflowConvenio_Workflowconvenioid_Z = sdt.gxTv_SdtWorkflowConvenio_Workflowconvenioid_Z ;
         gxTv_SdtWorkflowConvenio_Workflowconveniodesc_Z = sdt.gxTv_SdtWorkflowConvenio_Workflowconveniodesc_Z ;
         gxTv_SdtWorkflowConvenio_Workflowconveniostatus_Z = sdt.gxTv_SdtWorkflowConvenio_Workflowconveniostatus_Z ;
         gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat_Z = sdt.gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat_Z ;
         gxTv_SdtWorkflowConvenio_Workflowconveniosla_Z = sdt.gxTv_SdtWorkflowConvenio_Workflowconveniosla_Z ;
         gxTv_SdtWorkflowConvenio_Workflowconvenioid_N = sdt.gxTv_SdtWorkflowConvenio_Workflowconvenioid_N ;
         gxTv_SdtWorkflowConvenio_Workflowconveniodesc_N = sdt.gxTv_SdtWorkflowConvenio_Workflowconveniodesc_N ;
         gxTv_SdtWorkflowConvenio_Workflowconveniostatus_N = sdt.gxTv_SdtWorkflowConvenio_Workflowconveniostatus_N ;
         gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat_N = sdt.gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat_N ;
         gxTv_SdtWorkflowConvenio_Workflowconveniosla_N = sdt.gxTv_SdtWorkflowConvenio_Workflowconveniosla_N ;
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
         AddObjectProperty("WorkflowConvenioId", gxTv_SdtWorkflowConvenio_Workflowconvenioid, false, includeNonInitialized);
         AddObjectProperty("WorkflowConvenioId_N", gxTv_SdtWorkflowConvenio_Workflowconvenioid_N, false, includeNonInitialized);
         AddObjectProperty("WorkflowConvenioDesc", gxTv_SdtWorkflowConvenio_Workflowconveniodesc, false, includeNonInitialized);
         AddObjectProperty("WorkflowConvenioDesc_N", gxTv_SdtWorkflowConvenio_Workflowconveniodesc_N, false, includeNonInitialized);
         AddObjectProperty("WorkflowConvenioStatus", gxTv_SdtWorkflowConvenio_Workflowconveniostatus, false, includeNonInitialized);
         AddObjectProperty("WorkflowConvenioStatus_N", gxTv_SdtWorkflowConvenio_Workflowconveniostatus_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat;
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
         AddObjectProperty("WorkflowConvenioCreatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("WorkflowConvenioCreatedAt_N", gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat_N, false, includeNonInitialized);
         AddObjectProperty("WorkflowConvenioSLA", gxTv_SdtWorkflowConvenio_Workflowconveniosla, false, includeNonInitialized);
         AddObjectProperty("WorkflowConvenioSLA_N", gxTv_SdtWorkflowConvenio_Workflowconveniosla_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtWorkflowConvenio_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtWorkflowConvenio_Initialized, false, includeNonInitialized);
            AddObjectProperty("WorkflowConvenioId_Z", gxTv_SdtWorkflowConvenio_Workflowconvenioid_Z, false, includeNonInitialized);
            AddObjectProperty("WorkflowConvenioDesc_Z", gxTv_SdtWorkflowConvenio_Workflowconveniodesc_Z, false, includeNonInitialized);
            AddObjectProperty("WorkflowConvenioStatus_Z", gxTv_SdtWorkflowConvenio_Workflowconveniostatus_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat_Z;
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
            AddObjectProperty("WorkflowConvenioCreatedAt_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("WorkflowConvenioSLA_Z", gxTv_SdtWorkflowConvenio_Workflowconveniosla_Z, false, includeNonInitialized);
            AddObjectProperty("WorkflowConvenioId_N", gxTv_SdtWorkflowConvenio_Workflowconvenioid_N, false, includeNonInitialized);
            AddObjectProperty("WorkflowConvenioDesc_N", gxTv_SdtWorkflowConvenio_Workflowconveniodesc_N, false, includeNonInitialized);
            AddObjectProperty("WorkflowConvenioStatus_N", gxTv_SdtWorkflowConvenio_Workflowconveniostatus_N, false, includeNonInitialized);
            AddObjectProperty("WorkflowConvenioCreatedAt_N", gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat_N, false, includeNonInitialized);
            AddObjectProperty("WorkflowConvenioSLA_N", gxTv_SdtWorkflowConvenio_Workflowconveniosla_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtWorkflowConvenio sdt )
      {
         if ( sdt.IsDirty("WorkflowConvenioId") )
         {
            sdtIsNull = 0;
            gxTv_SdtWorkflowConvenio_Workflowconvenioid = sdt.gxTv_SdtWorkflowConvenio_Workflowconvenioid ;
         }
         if ( sdt.IsDirty("WorkflowConvenioDesc") )
         {
            gxTv_SdtWorkflowConvenio_Workflowconveniodesc_N = (short)(sdt.gxTv_SdtWorkflowConvenio_Workflowconveniodesc_N);
            sdtIsNull = 0;
            gxTv_SdtWorkflowConvenio_Workflowconveniodesc = sdt.gxTv_SdtWorkflowConvenio_Workflowconveniodesc ;
         }
         if ( sdt.IsDirty("WorkflowConvenioStatus") )
         {
            gxTv_SdtWorkflowConvenio_Workflowconveniostatus_N = (short)(sdt.gxTv_SdtWorkflowConvenio_Workflowconveniostatus_N);
            sdtIsNull = 0;
            gxTv_SdtWorkflowConvenio_Workflowconveniostatus = sdt.gxTv_SdtWorkflowConvenio_Workflowconveniostatus ;
         }
         if ( sdt.IsDirty("WorkflowConvenioCreatedAt") )
         {
            gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat_N = (short)(sdt.gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat_N);
            sdtIsNull = 0;
            gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat = sdt.gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat ;
         }
         if ( sdt.IsDirty("WorkflowConvenioSLA") )
         {
            gxTv_SdtWorkflowConvenio_Workflowconveniosla_N = (short)(sdt.gxTv_SdtWorkflowConvenio_Workflowconveniosla_N);
            sdtIsNull = 0;
            gxTv_SdtWorkflowConvenio_Workflowconveniosla = sdt.gxTv_SdtWorkflowConvenio_Workflowconveniosla ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "WorkflowConvenioId" )]
      [  XmlElement( ElementName = "WorkflowConvenioId"   )]
      public int gxTpr_Workflowconvenioid
      {
         get {
            return gxTv_SdtWorkflowConvenio_Workflowconvenioid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtWorkflowConvenio_Workflowconvenioid != value )
            {
               gxTv_SdtWorkflowConvenio_Mode = "INS";
               this.gxTv_SdtWorkflowConvenio_Workflowconvenioid_Z_SetNull( );
               this.gxTv_SdtWorkflowConvenio_Workflowconveniodesc_Z_SetNull( );
               this.gxTv_SdtWorkflowConvenio_Workflowconveniostatus_Z_SetNull( );
               this.gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat_Z_SetNull( );
               this.gxTv_SdtWorkflowConvenio_Workflowconveniosla_Z_SetNull( );
            }
            gxTv_SdtWorkflowConvenio_Workflowconvenioid = value;
            SetDirty("Workflowconvenioid");
         }

      }

      [  SoapElement( ElementName = "WorkflowConvenioDesc" )]
      [  XmlElement( ElementName = "WorkflowConvenioDesc"   )]
      public string gxTpr_Workflowconveniodesc
      {
         get {
            return gxTv_SdtWorkflowConvenio_Workflowconveniodesc ;
         }

         set {
            gxTv_SdtWorkflowConvenio_Workflowconveniodesc_N = 0;
            sdtIsNull = 0;
            gxTv_SdtWorkflowConvenio_Workflowconveniodesc = value;
            SetDirty("Workflowconveniodesc");
         }

      }

      public void gxTv_SdtWorkflowConvenio_Workflowconveniodesc_SetNull( )
      {
         gxTv_SdtWorkflowConvenio_Workflowconveniodesc_N = 1;
         gxTv_SdtWorkflowConvenio_Workflowconveniodesc = "";
         SetDirty("Workflowconveniodesc");
         return  ;
      }

      public bool gxTv_SdtWorkflowConvenio_Workflowconveniodesc_IsNull( )
      {
         return (gxTv_SdtWorkflowConvenio_Workflowconveniodesc_N==1) ;
      }

      [  SoapElement( ElementName = "WorkflowConvenioStatus" )]
      [  XmlElement( ElementName = "WorkflowConvenioStatus"   )]
      public bool gxTpr_Workflowconveniostatus
      {
         get {
            return gxTv_SdtWorkflowConvenio_Workflowconveniostatus ;
         }

         set {
            gxTv_SdtWorkflowConvenio_Workflowconveniostatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtWorkflowConvenio_Workflowconveniostatus = value;
            SetDirty("Workflowconveniostatus");
         }

      }

      public void gxTv_SdtWorkflowConvenio_Workflowconveniostatus_SetNull( )
      {
         gxTv_SdtWorkflowConvenio_Workflowconveniostatus_N = 1;
         gxTv_SdtWorkflowConvenio_Workflowconveniostatus = false;
         SetDirty("Workflowconveniostatus");
         return  ;
      }

      public bool gxTv_SdtWorkflowConvenio_Workflowconveniostatus_IsNull( )
      {
         return (gxTv_SdtWorkflowConvenio_Workflowconveniostatus_N==1) ;
      }

      [  SoapElement( ElementName = "WorkflowConvenioCreatedAt" )]
      [  XmlElement( ElementName = "WorkflowConvenioCreatedAt"  , IsNullable=true )]
      public string gxTpr_Workflowconveniocreatedat_Nullable
      {
         get {
            if ( gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat).value ;
         }

         set {
            gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat = DateTime.MinValue;
            else
               gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Workflowconveniocreatedat
      {
         get {
            return gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat ;
         }

         set {
            gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat = value;
            SetDirty("Workflowconveniocreatedat");
         }

      }

      public void gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat_SetNull( )
      {
         gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat_N = 1;
         gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Workflowconveniocreatedat");
         return  ;
      }

      public bool gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat_IsNull( )
      {
         return (gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat_N==1) ;
      }

      [  SoapElement( ElementName = "WorkflowConvenioSLA" )]
      [  XmlElement( ElementName = "WorkflowConvenioSLA"   )]
      public short gxTpr_Workflowconveniosla
      {
         get {
            return gxTv_SdtWorkflowConvenio_Workflowconveniosla ;
         }

         set {
            gxTv_SdtWorkflowConvenio_Workflowconveniosla_N = 0;
            sdtIsNull = 0;
            gxTv_SdtWorkflowConvenio_Workflowconveniosla = value;
            SetDirty("Workflowconveniosla");
         }

      }

      public void gxTv_SdtWorkflowConvenio_Workflowconveniosla_SetNull( )
      {
         gxTv_SdtWorkflowConvenio_Workflowconveniosla_N = 1;
         gxTv_SdtWorkflowConvenio_Workflowconveniosla = 0;
         SetDirty("Workflowconveniosla");
         return  ;
      }

      public bool gxTv_SdtWorkflowConvenio_Workflowconveniosla_IsNull( )
      {
         return (gxTv_SdtWorkflowConvenio_Workflowconveniosla_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtWorkflowConvenio_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkflowConvenio_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtWorkflowConvenio_Mode_SetNull( )
      {
         gxTv_SdtWorkflowConvenio_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtWorkflowConvenio_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtWorkflowConvenio_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkflowConvenio_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtWorkflowConvenio_Initialized_SetNull( )
      {
         gxTv_SdtWorkflowConvenio_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtWorkflowConvenio_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WorkflowConvenioId_Z" )]
      [  XmlElement( ElementName = "WorkflowConvenioId_Z"   )]
      public int gxTpr_Workflowconvenioid_Z
      {
         get {
            return gxTv_SdtWorkflowConvenio_Workflowconvenioid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkflowConvenio_Workflowconvenioid_Z = value;
            SetDirty("Workflowconvenioid_Z");
         }

      }

      public void gxTv_SdtWorkflowConvenio_Workflowconvenioid_Z_SetNull( )
      {
         gxTv_SdtWorkflowConvenio_Workflowconvenioid_Z = 0;
         SetDirty("Workflowconvenioid_Z");
         return  ;
      }

      public bool gxTv_SdtWorkflowConvenio_Workflowconvenioid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WorkflowConvenioDesc_Z" )]
      [  XmlElement( ElementName = "WorkflowConvenioDesc_Z"   )]
      public string gxTpr_Workflowconveniodesc_Z
      {
         get {
            return gxTv_SdtWorkflowConvenio_Workflowconveniodesc_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkflowConvenio_Workflowconveniodesc_Z = value;
            SetDirty("Workflowconveniodesc_Z");
         }

      }

      public void gxTv_SdtWorkflowConvenio_Workflowconveniodesc_Z_SetNull( )
      {
         gxTv_SdtWorkflowConvenio_Workflowconveniodesc_Z = "";
         SetDirty("Workflowconveniodesc_Z");
         return  ;
      }

      public bool gxTv_SdtWorkflowConvenio_Workflowconveniodesc_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WorkflowConvenioStatus_Z" )]
      [  XmlElement( ElementName = "WorkflowConvenioStatus_Z"   )]
      public bool gxTpr_Workflowconveniostatus_Z
      {
         get {
            return gxTv_SdtWorkflowConvenio_Workflowconveniostatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkflowConvenio_Workflowconveniostatus_Z = value;
            SetDirty("Workflowconveniostatus_Z");
         }

      }

      public void gxTv_SdtWorkflowConvenio_Workflowconveniostatus_Z_SetNull( )
      {
         gxTv_SdtWorkflowConvenio_Workflowconveniostatus_Z = false;
         SetDirty("Workflowconveniostatus_Z");
         return  ;
      }

      public bool gxTv_SdtWorkflowConvenio_Workflowconveniostatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WorkflowConvenioCreatedAt_Z" )]
      [  XmlElement( ElementName = "WorkflowConvenioCreatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Workflowconveniocreatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Workflowconveniocreatedat_Z
      {
         get {
            return gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat_Z = value;
            SetDirty("Workflowconveniocreatedat_Z");
         }

      }

      public void gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat_Z_SetNull( )
      {
         gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Workflowconveniocreatedat_Z");
         return  ;
      }

      public bool gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WorkflowConvenioSLA_Z" )]
      [  XmlElement( ElementName = "WorkflowConvenioSLA_Z"   )]
      public short gxTpr_Workflowconveniosla_Z
      {
         get {
            return gxTv_SdtWorkflowConvenio_Workflowconveniosla_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkflowConvenio_Workflowconveniosla_Z = value;
            SetDirty("Workflowconveniosla_Z");
         }

      }

      public void gxTv_SdtWorkflowConvenio_Workflowconveniosla_Z_SetNull( )
      {
         gxTv_SdtWorkflowConvenio_Workflowconveniosla_Z = 0;
         SetDirty("Workflowconveniosla_Z");
         return  ;
      }

      public bool gxTv_SdtWorkflowConvenio_Workflowconveniosla_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WorkflowConvenioId_N" )]
      [  XmlElement( ElementName = "WorkflowConvenioId_N"   )]
      public short gxTpr_Workflowconvenioid_N
      {
         get {
            return gxTv_SdtWorkflowConvenio_Workflowconvenioid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkflowConvenio_Workflowconvenioid_N = value;
            SetDirty("Workflowconvenioid_N");
         }

      }

      public void gxTv_SdtWorkflowConvenio_Workflowconvenioid_N_SetNull( )
      {
         gxTv_SdtWorkflowConvenio_Workflowconvenioid_N = 0;
         SetDirty("Workflowconvenioid_N");
         return  ;
      }

      public bool gxTv_SdtWorkflowConvenio_Workflowconvenioid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WorkflowConvenioDesc_N" )]
      [  XmlElement( ElementName = "WorkflowConvenioDesc_N"   )]
      public short gxTpr_Workflowconveniodesc_N
      {
         get {
            return gxTv_SdtWorkflowConvenio_Workflowconveniodesc_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkflowConvenio_Workflowconveniodesc_N = value;
            SetDirty("Workflowconveniodesc_N");
         }

      }

      public void gxTv_SdtWorkflowConvenio_Workflowconveniodesc_N_SetNull( )
      {
         gxTv_SdtWorkflowConvenio_Workflowconveniodesc_N = 0;
         SetDirty("Workflowconveniodesc_N");
         return  ;
      }

      public bool gxTv_SdtWorkflowConvenio_Workflowconveniodesc_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WorkflowConvenioStatus_N" )]
      [  XmlElement( ElementName = "WorkflowConvenioStatus_N"   )]
      public short gxTpr_Workflowconveniostatus_N
      {
         get {
            return gxTv_SdtWorkflowConvenio_Workflowconveniostatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkflowConvenio_Workflowconveniostatus_N = value;
            SetDirty("Workflowconveniostatus_N");
         }

      }

      public void gxTv_SdtWorkflowConvenio_Workflowconveniostatus_N_SetNull( )
      {
         gxTv_SdtWorkflowConvenio_Workflowconveniostatus_N = 0;
         SetDirty("Workflowconveniostatus_N");
         return  ;
      }

      public bool gxTv_SdtWorkflowConvenio_Workflowconveniostatus_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WorkflowConvenioCreatedAt_N" )]
      [  XmlElement( ElementName = "WorkflowConvenioCreatedAt_N"   )]
      public short gxTpr_Workflowconveniocreatedat_N
      {
         get {
            return gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat_N = value;
            SetDirty("Workflowconveniocreatedat_N");
         }

      }

      public void gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat_N_SetNull( )
      {
         gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat_N = 0;
         SetDirty("Workflowconveniocreatedat_N");
         return  ;
      }

      public bool gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WorkflowConvenioSLA_N" )]
      [  XmlElement( ElementName = "WorkflowConvenioSLA_N"   )]
      public short gxTpr_Workflowconveniosla_N
      {
         get {
            return gxTv_SdtWorkflowConvenio_Workflowconveniosla_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtWorkflowConvenio_Workflowconveniosla_N = value;
            SetDirty("Workflowconveniosla_N");
         }

      }

      public void gxTv_SdtWorkflowConvenio_Workflowconveniosla_N_SetNull( )
      {
         gxTv_SdtWorkflowConvenio_Workflowconveniosla_N = 0;
         SetDirty("Workflowconveniosla_N");
         return  ;
      }

      public bool gxTv_SdtWorkflowConvenio_Workflowconveniosla_N_IsNull( )
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
         gxTv_SdtWorkflowConvenio_Workflowconveniodesc = "";
         gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtWorkflowConvenio_Mode = "";
         gxTv_SdtWorkflowConvenio_Workflowconveniodesc_Z = "";
         gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat_Z = (DateTime)(DateTime.MinValue);
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "workflowconvenio", "GeneXus.Programs.workflowconvenio_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtWorkflowConvenio_Workflowconveniosla ;
      private short gxTv_SdtWorkflowConvenio_Initialized ;
      private short gxTv_SdtWorkflowConvenio_Workflowconveniosla_Z ;
      private short gxTv_SdtWorkflowConvenio_Workflowconvenioid_N ;
      private short gxTv_SdtWorkflowConvenio_Workflowconveniodesc_N ;
      private short gxTv_SdtWorkflowConvenio_Workflowconveniostatus_N ;
      private short gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat_N ;
      private short gxTv_SdtWorkflowConvenio_Workflowconveniosla_N ;
      private int gxTv_SdtWorkflowConvenio_Workflowconvenioid ;
      private int gxTv_SdtWorkflowConvenio_Workflowconvenioid_Z ;
      private string gxTv_SdtWorkflowConvenio_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat ;
      private DateTime gxTv_SdtWorkflowConvenio_Workflowconveniocreatedat_Z ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtWorkflowConvenio_Workflowconveniostatus ;
      private bool gxTv_SdtWorkflowConvenio_Workflowconveniostatus_Z ;
      private string gxTv_SdtWorkflowConvenio_Workflowconveniodesc ;
      private string gxTv_SdtWorkflowConvenio_Workflowconveniodesc_Z ;
   }

   [DataContract(Name = @"WorkflowConvenio", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtWorkflowConvenio_RESTInterface : GxGenericCollectionItem<SdtWorkflowConvenio>
   {
      public SdtWorkflowConvenio_RESTInterface( ) : base()
      {
      }

      public SdtWorkflowConvenio_RESTInterface( SdtWorkflowConvenio psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WorkflowConvenioId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Workflowconvenioid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Workflowconvenioid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Workflowconvenioid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "WorkflowConvenioDesc" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Workflowconveniodesc
      {
         get {
            return sdt.gxTpr_Workflowconveniodesc ;
         }

         set {
            sdt.gxTpr_Workflowconveniodesc = value;
         }

      }

      [DataMember( Name = "WorkflowConvenioStatus" , Order = 2 )]
      [GxSeudo()]
      public bool gxTpr_Workflowconveniostatus
      {
         get {
            return sdt.gxTpr_Workflowconveniostatus ;
         }

         set {
            sdt.gxTpr_Workflowconveniostatus = value;
         }

      }

      [DataMember( Name = "WorkflowConvenioCreatedAt" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Workflowconveniocreatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Workflowconveniocreatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Workflowconveniocreatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "WorkflowConvenioSLA" , Order = 4 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Workflowconveniosla
      {
         get {
            return sdt.gxTpr_Workflowconveniosla ;
         }

         set {
            sdt.gxTpr_Workflowconveniosla = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtWorkflowConvenio sdt
      {
         get {
            return (SdtWorkflowConvenio)Sdt ;
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
            sdt = new SdtWorkflowConvenio() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 5 )]
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

   [DataContract(Name = @"WorkflowConvenio", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtWorkflowConvenio_RESTLInterface : GxGenericCollectionItem<SdtWorkflowConvenio>
   {
      public SdtWorkflowConvenio_RESTLInterface( ) : base()
      {
      }

      public SdtWorkflowConvenio_RESTLInterface( SdtWorkflowConvenio psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WorkflowConvenioDesc" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Workflowconveniodesc
      {
         get {
            return sdt.gxTpr_Workflowconveniodesc ;
         }

         set {
            sdt.gxTpr_Workflowconveniodesc = value;
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

      public SdtWorkflowConvenio sdt
      {
         get {
            return (SdtWorkflowConvenio)Sdt ;
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
            sdt = new SdtWorkflowConvenio() ;
         }
      }

   }

}
