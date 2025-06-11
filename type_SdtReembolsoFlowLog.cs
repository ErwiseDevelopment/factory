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
   [XmlRoot(ElementName = "ReembolsoFlowLog" )]
   [XmlType(TypeName =  "ReembolsoFlowLog" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtReembolsoFlowLog : GxSilentTrnSdt
   {
      public SdtReembolsoFlowLog( )
      {
      }

      public SdtReembolsoFlowLog( IGxContext context )
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

      public void Load( int AV746ReembolsoFlowLogId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV746ReembolsoFlowLogId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ReembolsoFlowLogId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "ReembolsoFlowLog");
         metadata.Set("BT", "ReembolsoFlowLog");
         metadata.Set("PK", "[ \"ReembolsoFlowLogId\" ]");
         metadata.Set("PKAssigned", "[ \"ReembolsoFlowLogId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ReembolsoId\" ],\"FKMap\":[ \"ReembolsoLogId-ReembolsoId\" ] },{ \"FK\":[ \"SecUserId\" ],\"FKMap\":[ \"ReembolsoFlowLogUser-SecUserId\" ] },{ \"FK\":[ \"WorkflowConvenioId\" ],\"FKMap\":[ \"LogWorkflowConvenioId-WorkflowConvenioId\" ] } ]");
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
         state.Add("gxTpr_Reembolsoflowlogid_Z");
         state.Add("gxTpr_Logworkflowconvenioid_Z");
         state.Add("gxTpr_Logworkflowconveniodesc_Z");
         state.Add("gxTpr_Reembolsoflowlogdate_Z_Nullable");
         state.Add("gxTpr_Reembolsoflowloguser_Z");
         state.Add("gxTpr_Reembolsoflowlogusernome_Z");
         state.Add("gxTpr_Reembolsologid_Z");
         state.Add("gxTpr_Reembolsoworkflowconvenioid_Z");
         state.Add("gxTpr_Reembolsoworkflowconveniosla_Z");
         state.Add("gxTpr_Logreembolsostatusatual_f_Z");
         state.Add("gxTpr_Reembolsoflowlogdatasla_f_Z_Nullable");
         state.Add("gxTpr_Reembolsologprotocolo_Z");
         state.Add("gxTpr_Reembolsopaciente_Z");
         state.Add("gxTpr_Reembolsoflowlogdatafinal_Z_Nullable");
         state.Add("gxTpr_Logworkflowconvenioid_N");
         state.Add("gxTpr_Logworkflowconveniodesc_N");
         state.Add("gxTpr_Reembolsoflowlogdate_N");
         state.Add("gxTpr_Reembolsoflowloguser_N");
         state.Add("gxTpr_Reembolsoflowlogusernome_N");
         state.Add("gxTpr_Reembolsologid_N");
         state.Add("gxTpr_Reembolsoworkflowconvenioid_N");
         state.Add("gxTpr_Reembolsoworkflowconveniosla_N");
         state.Add("gxTpr_Logreembolsostatusatual_f_N");
         state.Add("gxTpr_Reembolsologprotocolo_N");
         state.Add("gxTpr_Reembolsoflowlogdatafinal_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtReembolsoFlowLog sdt;
         sdt = (SdtReembolsoFlowLog)(source);
         gxTv_SdtReembolsoFlowLog_Reembolsoflowlogid = sdt.gxTv_SdtReembolsoFlowLog_Reembolsoflowlogid ;
         gxTv_SdtReembolsoFlowLog_Logworkflowconvenioid = sdt.gxTv_SdtReembolsoFlowLog_Logworkflowconvenioid ;
         gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc = sdt.gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc ;
         gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate = sdt.gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate ;
         gxTv_SdtReembolsoFlowLog_Reembolsoflowloguser = sdt.gxTv_SdtReembolsoFlowLog_Reembolsoflowloguser ;
         gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome = sdt.gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome ;
         gxTv_SdtReembolsoFlowLog_Reembolsologid = sdt.gxTv_SdtReembolsoFlowLog_Reembolsologid ;
         gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconvenioid = sdt.gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconvenioid ;
         gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconveniosla = sdt.gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconveniosla ;
         gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f = sdt.gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f ;
         gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatasla_f = sdt.gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatasla_f ;
         gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo = sdt.gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo ;
         gxTv_SdtReembolsoFlowLog_Reembolsopaciente = sdt.gxTv_SdtReembolsoFlowLog_Reembolsopaciente ;
         gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal = sdt.gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal ;
         gxTv_SdtReembolsoFlowLog_Mode = sdt.gxTv_SdtReembolsoFlowLog_Mode ;
         gxTv_SdtReembolsoFlowLog_Initialized = sdt.gxTv_SdtReembolsoFlowLog_Initialized ;
         gxTv_SdtReembolsoFlowLog_Reembolsoflowlogid_Z = sdt.gxTv_SdtReembolsoFlowLog_Reembolsoflowlogid_Z ;
         gxTv_SdtReembolsoFlowLog_Logworkflowconvenioid_Z = sdt.gxTv_SdtReembolsoFlowLog_Logworkflowconvenioid_Z ;
         gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc_Z = sdt.gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc_Z ;
         gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate_Z = sdt.gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate_Z ;
         gxTv_SdtReembolsoFlowLog_Reembolsoflowloguser_Z = sdt.gxTv_SdtReembolsoFlowLog_Reembolsoflowloguser_Z ;
         gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome_Z = sdt.gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome_Z ;
         gxTv_SdtReembolsoFlowLog_Reembolsologid_Z = sdt.gxTv_SdtReembolsoFlowLog_Reembolsologid_Z ;
         gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconvenioid_Z = sdt.gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconvenioid_Z ;
         gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconveniosla_Z = sdt.gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconveniosla_Z ;
         gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f_Z = sdt.gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f_Z ;
         gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatasla_f_Z = sdt.gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatasla_f_Z ;
         gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo_Z = sdt.gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo_Z ;
         gxTv_SdtReembolsoFlowLog_Reembolsopaciente_Z = sdt.gxTv_SdtReembolsoFlowLog_Reembolsopaciente_Z ;
         gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal_Z = sdt.gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal_Z ;
         gxTv_SdtReembolsoFlowLog_Logworkflowconvenioid_N = sdt.gxTv_SdtReembolsoFlowLog_Logworkflowconvenioid_N ;
         gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc_N = sdt.gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc_N ;
         gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate_N = sdt.gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate_N ;
         gxTv_SdtReembolsoFlowLog_Reembolsoflowloguser_N = sdt.gxTv_SdtReembolsoFlowLog_Reembolsoflowloguser_N ;
         gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome_N = sdt.gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome_N ;
         gxTv_SdtReembolsoFlowLog_Reembolsologid_N = sdt.gxTv_SdtReembolsoFlowLog_Reembolsologid_N ;
         gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconvenioid_N = sdt.gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconvenioid_N ;
         gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconveniosla_N = sdt.gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconveniosla_N ;
         gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f_N = sdt.gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f_N ;
         gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo_N = sdt.gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo_N ;
         gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal_N = sdt.gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal_N ;
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
         AddObjectProperty("ReembolsoFlowLogId", gxTv_SdtReembolsoFlowLog_Reembolsoflowlogid, false, includeNonInitialized);
         AddObjectProperty("LogWorkflowConvenioId", gxTv_SdtReembolsoFlowLog_Logworkflowconvenioid, false, includeNonInitialized);
         AddObjectProperty("LogWorkflowConvenioId_N", gxTv_SdtReembolsoFlowLog_Logworkflowconvenioid_N, false, includeNonInitialized);
         AddObjectProperty("LogWorkflowConvenioDesc", gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc, false, includeNonInitialized);
         AddObjectProperty("LogWorkflowConvenioDesc_N", gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate;
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
         AddObjectProperty("ReembolsoFlowLogDate", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ReembolsoFlowLogDate_N", gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate_N, false, includeNonInitialized);
         AddObjectProperty("ReembolsoFlowLogUser", gxTv_SdtReembolsoFlowLog_Reembolsoflowloguser, false, includeNonInitialized);
         AddObjectProperty("ReembolsoFlowLogUser_N", gxTv_SdtReembolsoFlowLog_Reembolsoflowloguser_N, false, includeNonInitialized);
         AddObjectProperty("ReembolsoFlowLogUserNome", gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome, false, includeNonInitialized);
         AddObjectProperty("ReembolsoFlowLogUserNome_N", gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome_N, false, includeNonInitialized);
         AddObjectProperty("ReembolsoLogId", gxTv_SdtReembolsoFlowLog_Reembolsologid, false, includeNonInitialized);
         AddObjectProperty("ReembolsoLogId_N", gxTv_SdtReembolsoFlowLog_Reembolsologid_N, false, includeNonInitialized);
         AddObjectProperty("ReembolsoWorkFlowConvenioId", gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconvenioid, false, includeNonInitialized);
         AddObjectProperty("ReembolsoWorkFlowConvenioId_N", gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconvenioid_N, false, includeNonInitialized);
         AddObjectProperty("ReembolsoWorkflowConvenioSLA", gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconveniosla, false, includeNonInitialized);
         AddObjectProperty("ReembolsoWorkflowConvenioSLA_N", gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconveniosla_N, false, includeNonInitialized);
         AddObjectProperty("LogReembolsoStatusAtual_F", gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f, false, includeNonInitialized);
         AddObjectProperty("LogReembolsoStatusAtual_F_N", gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatasla_f;
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
         AddObjectProperty("ReembolsoFlowLogDataSLA_F", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ReembolsoLogProtocolo", gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo, false, includeNonInitialized);
         AddObjectProperty("ReembolsoLogProtocolo_N", gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo_N, false, includeNonInitialized);
         AddObjectProperty("ReembolsoPaciente", gxTv_SdtReembolsoFlowLog_Reembolsopaciente, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal;
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
         AddObjectProperty("ReembolsoFlowLogDataFinal", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ReembolsoFlowLogDataFinal_N", gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtReembolsoFlowLog_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtReembolsoFlowLog_Initialized, false, includeNonInitialized);
            AddObjectProperty("ReembolsoFlowLogId_Z", gxTv_SdtReembolsoFlowLog_Reembolsoflowlogid_Z, false, includeNonInitialized);
            AddObjectProperty("LogWorkflowConvenioId_Z", gxTv_SdtReembolsoFlowLog_Logworkflowconvenioid_Z, false, includeNonInitialized);
            AddObjectProperty("LogWorkflowConvenioDesc_Z", gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate_Z;
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
            AddObjectProperty("ReembolsoFlowLogDate_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("ReembolsoFlowLogUser_Z", gxTv_SdtReembolsoFlowLog_Reembolsoflowloguser_Z, false, includeNonInitialized);
            AddObjectProperty("ReembolsoFlowLogUserNome_Z", gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome_Z, false, includeNonInitialized);
            AddObjectProperty("ReembolsoLogId_Z", gxTv_SdtReembolsoFlowLog_Reembolsologid_Z, false, includeNonInitialized);
            AddObjectProperty("ReembolsoWorkFlowConvenioId_Z", gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconvenioid_Z, false, includeNonInitialized);
            AddObjectProperty("ReembolsoWorkflowConvenioSLA_Z", gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconveniosla_Z, false, includeNonInitialized);
            AddObjectProperty("LogReembolsoStatusAtual_F_Z", gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatasla_f_Z;
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
            AddObjectProperty("ReembolsoFlowLogDataSLA_F_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("ReembolsoLogProtocolo_Z", gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo_Z, false, includeNonInitialized);
            AddObjectProperty("ReembolsoPaciente_Z", gxTv_SdtReembolsoFlowLog_Reembolsopaciente_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal_Z;
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
            AddObjectProperty("ReembolsoFlowLogDataFinal_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("LogWorkflowConvenioId_N", gxTv_SdtReembolsoFlowLog_Logworkflowconvenioid_N, false, includeNonInitialized);
            AddObjectProperty("LogWorkflowConvenioDesc_N", gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoFlowLogDate_N", gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoFlowLogUser_N", gxTv_SdtReembolsoFlowLog_Reembolsoflowloguser_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoFlowLogUserNome_N", gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoLogId_N", gxTv_SdtReembolsoFlowLog_Reembolsologid_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoWorkFlowConvenioId_N", gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconvenioid_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoWorkflowConvenioSLA_N", gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconveniosla_N, false, includeNonInitialized);
            AddObjectProperty("LogReembolsoStatusAtual_F_N", gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoLogProtocolo_N", gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoFlowLogDataFinal_N", gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtReembolsoFlowLog sdt )
      {
         if ( sdt.IsDirty("ReembolsoFlowLogId") )
         {
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsoflowlogid = sdt.gxTv_SdtReembolsoFlowLog_Reembolsoflowlogid ;
         }
         if ( sdt.IsDirty("LogWorkflowConvenioId") )
         {
            gxTv_SdtReembolsoFlowLog_Logworkflowconvenioid_N = (short)(sdt.gxTv_SdtReembolsoFlowLog_Logworkflowconvenioid_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Logworkflowconvenioid = sdt.gxTv_SdtReembolsoFlowLog_Logworkflowconvenioid ;
         }
         if ( sdt.IsDirty("LogWorkflowConvenioDesc") )
         {
            gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc_N = (short)(sdt.gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc = sdt.gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc ;
         }
         if ( sdt.IsDirty("ReembolsoFlowLogDate") )
         {
            gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate_N = (short)(sdt.gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate = sdt.gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate ;
         }
         if ( sdt.IsDirty("ReembolsoFlowLogUser") )
         {
            gxTv_SdtReembolsoFlowLog_Reembolsoflowloguser_N = (short)(sdt.gxTv_SdtReembolsoFlowLog_Reembolsoflowloguser_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsoflowloguser = sdt.gxTv_SdtReembolsoFlowLog_Reembolsoflowloguser ;
         }
         if ( sdt.IsDirty("ReembolsoFlowLogUserNome") )
         {
            gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome_N = (short)(sdt.gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome = sdt.gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome ;
         }
         if ( sdt.IsDirty("ReembolsoLogId") )
         {
            gxTv_SdtReembolsoFlowLog_Reembolsologid_N = (short)(sdt.gxTv_SdtReembolsoFlowLog_Reembolsologid_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsologid = sdt.gxTv_SdtReembolsoFlowLog_Reembolsologid ;
         }
         if ( sdt.IsDirty("ReembolsoWorkFlowConvenioId") )
         {
            gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconvenioid_N = (short)(sdt.gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconvenioid_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconvenioid = sdt.gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconvenioid ;
         }
         if ( sdt.IsDirty("ReembolsoWorkflowConvenioSLA") )
         {
            gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconveniosla_N = (short)(sdt.gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconveniosla_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconveniosla = sdt.gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconveniosla ;
         }
         if ( sdt.IsDirty("LogReembolsoStatusAtual_F") )
         {
            gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f_N = (short)(sdt.gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f = sdt.gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f ;
         }
         if ( sdt.IsDirty("ReembolsoFlowLogDataSLA_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatasla_f = sdt.gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatasla_f ;
         }
         if ( sdt.IsDirty("ReembolsoLogProtocolo") )
         {
            gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo_N = (short)(sdt.gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo = sdt.gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo ;
         }
         if ( sdt.IsDirty("ReembolsoPaciente") )
         {
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsopaciente = sdt.gxTv_SdtReembolsoFlowLog_Reembolsopaciente ;
         }
         if ( sdt.IsDirty("ReembolsoFlowLogDataFinal") )
         {
            gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal_N = (short)(sdt.gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal_N);
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal = sdt.gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ReembolsoFlowLogId" )]
      [  XmlElement( ElementName = "ReembolsoFlowLogId"   )]
      public int gxTpr_Reembolsoflowlogid
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Reembolsoflowlogid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtReembolsoFlowLog_Reembolsoflowlogid != value )
            {
               gxTv_SdtReembolsoFlowLog_Mode = "INS";
               this.gxTv_SdtReembolsoFlowLog_Reembolsoflowlogid_Z_SetNull( );
               this.gxTv_SdtReembolsoFlowLog_Logworkflowconvenioid_Z_SetNull( );
               this.gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc_Z_SetNull( );
               this.gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate_Z_SetNull( );
               this.gxTv_SdtReembolsoFlowLog_Reembolsoflowloguser_Z_SetNull( );
               this.gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome_Z_SetNull( );
               this.gxTv_SdtReembolsoFlowLog_Reembolsologid_Z_SetNull( );
               this.gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconvenioid_Z_SetNull( );
               this.gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconveniosla_Z_SetNull( );
               this.gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f_Z_SetNull( );
               this.gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatasla_f_Z_SetNull( );
               this.gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo_Z_SetNull( );
               this.gxTv_SdtReembolsoFlowLog_Reembolsopaciente_Z_SetNull( );
               this.gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal_Z_SetNull( );
            }
            gxTv_SdtReembolsoFlowLog_Reembolsoflowlogid = value;
            SetDirty("Reembolsoflowlogid");
         }

      }

      [  SoapElement( ElementName = "LogWorkflowConvenioId" )]
      [  XmlElement( ElementName = "LogWorkflowConvenioId"   )]
      public int gxTpr_Logworkflowconvenioid
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Logworkflowconvenioid ;
         }

         set {
            gxTv_SdtReembolsoFlowLog_Logworkflowconvenioid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Logworkflowconvenioid = value;
            SetDirty("Logworkflowconvenioid");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Logworkflowconvenioid_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Logworkflowconvenioid_N = 1;
         gxTv_SdtReembolsoFlowLog_Logworkflowconvenioid = 0;
         SetDirty("Logworkflowconvenioid");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Logworkflowconvenioid_IsNull( )
      {
         return (gxTv_SdtReembolsoFlowLog_Logworkflowconvenioid_N==1) ;
      }

      [  SoapElement( ElementName = "LogWorkflowConvenioDesc" )]
      [  XmlElement( ElementName = "LogWorkflowConvenioDesc"   )]
      public string gxTpr_Logworkflowconveniodesc
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc ;
         }

         set {
            gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc = value;
            SetDirty("Logworkflowconveniodesc");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc_N = 1;
         gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc = "";
         SetDirty("Logworkflowconveniodesc");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc_IsNull( )
      {
         return (gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoFlowLogDate" )]
      [  XmlElement( ElementName = "ReembolsoFlowLogDate"  , IsNullable=true )]
      public string gxTpr_Reembolsoflowlogdate_Nullable
      {
         get {
            if ( gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate).value ;
         }

         set {
            gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate = DateTime.MinValue;
            else
               gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Reembolsoflowlogdate
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate ;
         }

         set {
            gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate = value;
            SetDirty("Reembolsoflowlogdate");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate_N = 1;
         gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate = (DateTime)(DateTime.MinValue);
         SetDirty("Reembolsoflowlogdate");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate_IsNull( )
      {
         return (gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoFlowLogUser" )]
      [  XmlElement( ElementName = "ReembolsoFlowLogUser"   )]
      public short gxTpr_Reembolsoflowloguser
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Reembolsoflowloguser ;
         }

         set {
            gxTv_SdtReembolsoFlowLog_Reembolsoflowloguser_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsoflowloguser = value;
            SetDirty("Reembolsoflowloguser");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Reembolsoflowloguser_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Reembolsoflowloguser_N = 1;
         gxTv_SdtReembolsoFlowLog_Reembolsoflowloguser = 0;
         SetDirty("Reembolsoflowloguser");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Reembolsoflowloguser_IsNull( )
      {
         return (gxTv_SdtReembolsoFlowLog_Reembolsoflowloguser_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoFlowLogUserNome" )]
      [  XmlElement( ElementName = "ReembolsoFlowLogUserNome"   )]
      public string gxTpr_Reembolsoflowlogusernome
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome ;
         }

         set {
            gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome = value;
            SetDirty("Reembolsoflowlogusernome");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome_N = 1;
         gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome = "";
         SetDirty("Reembolsoflowlogusernome");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome_IsNull( )
      {
         return (gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoLogId" )]
      [  XmlElement( ElementName = "ReembolsoLogId"   )]
      public int gxTpr_Reembolsologid
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Reembolsologid ;
         }

         set {
            gxTv_SdtReembolsoFlowLog_Reembolsologid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsologid = value;
            SetDirty("Reembolsologid");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Reembolsologid_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Reembolsologid_N = 1;
         gxTv_SdtReembolsoFlowLog_Reembolsologid = 0;
         SetDirty("Reembolsologid");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Reembolsologid_IsNull( )
      {
         return (gxTv_SdtReembolsoFlowLog_Reembolsologid_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoWorkFlowConvenioId" )]
      [  XmlElement( ElementName = "ReembolsoWorkFlowConvenioId"   )]
      public int gxTpr_Reembolsoworkflowconvenioid
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconvenioid ;
         }

         set {
            gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconvenioid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconvenioid = value;
            SetDirty("Reembolsoworkflowconvenioid");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconvenioid_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconvenioid_N = 1;
         gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconvenioid = 0;
         SetDirty("Reembolsoworkflowconvenioid");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconvenioid_IsNull( )
      {
         return (gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconvenioid_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoWorkflowConvenioSLA" )]
      [  XmlElement( ElementName = "ReembolsoWorkflowConvenioSLA"   )]
      public short gxTpr_Reembolsoworkflowconveniosla
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconveniosla ;
         }

         set {
            gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconveniosla_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconveniosla = value;
            SetDirty("Reembolsoworkflowconveniosla");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconveniosla_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconveniosla_N = 1;
         gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconveniosla = 0;
         SetDirty("Reembolsoworkflowconveniosla");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconveniosla_IsNull( )
      {
         return (gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconveniosla_N==1) ;
      }

      [  SoapElement( ElementName = "LogReembolsoStatusAtual_F" )]
      [  XmlElement( ElementName = "LogReembolsoStatusAtual_F"   )]
      public string gxTpr_Logreembolsostatusatual_f
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f ;
         }

         set {
            gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f = value;
            SetDirty("Logreembolsostatusatual_f");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f_N = 1;
         gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f = "";
         SetDirty("Logreembolsostatusatual_f");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f_IsNull( )
      {
         return (gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoFlowLogDataSLA_F" )]
      [  XmlElement( ElementName = "ReembolsoFlowLogDataSLA_F"  , IsNullable=true )]
      public string gxTpr_Reembolsoflowlogdatasla_f_Nullable
      {
         get {
            if ( gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatasla_f == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatasla_f).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatasla_f = DateTime.MinValue;
            else
               gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatasla_f = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Reembolsoflowlogdatasla_f
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatasla_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatasla_f = value;
            SetDirty("Reembolsoflowlogdatasla_f");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatasla_f_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatasla_f = (DateTime)(DateTime.MinValue);
         SetDirty("Reembolsoflowlogdatasla_f");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatasla_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoLogProtocolo" )]
      [  XmlElement( ElementName = "ReembolsoLogProtocolo"   )]
      public string gxTpr_Reembolsologprotocolo
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo ;
         }

         set {
            gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo = value;
            SetDirty("Reembolsologprotocolo");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo_N = 1;
         gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo = "";
         SetDirty("Reembolsologprotocolo");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo_IsNull( )
      {
         return (gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoPaciente" )]
      [  XmlElement( ElementName = "ReembolsoPaciente"   )]
      public string gxTpr_Reembolsopaciente
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Reembolsopaciente ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsopaciente = value;
            SetDirty("Reembolsopaciente");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Reembolsopaciente_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Reembolsopaciente = "";
         SetDirty("Reembolsopaciente");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Reembolsopaciente_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoFlowLogDataFinal" )]
      [  XmlElement( ElementName = "ReembolsoFlowLogDataFinal"  , IsNullable=true )]
      public string gxTpr_Reembolsoflowlogdatafinal_Nullable
      {
         get {
            if ( gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal).value ;
         }

         set {
            gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal = DateTime.MinValue;
            else
               gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Reembolsoflowlogdatafinal
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal ;
         }

         set {
            gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal = value;
            SetDirty("Reembolsoflowlogdatafinal");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal_N = 1;
         gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal = (DateTime)(DateTime.MinValue);
         SetDirty("Reembolsoflowlogdatafinal");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal_IsNull( )
      {
         return (gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Mode_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Initialized_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoFlowLogId_Z" )]
      [  XmlElement( ElementName = "ReembolsoFlowLogId_Z"   )]
      public int gxTpr_Reembolsoflowlogid_Z
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Reembolsoflowlogid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsoflowlogid_Z = value;
            SetDirty("Reembolsoflowlogid_Z");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Reembolsoflowlogid_Z_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Reembolsoflowlogid_Z = 0;
         SetDirty("Reembolsoflowlogid_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Reembolsoflowlogid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LogWorkflowConvenioId_Z" )]
      [  XmlElement( ElementName = "LogWorkflowConvenioId_Z"   )]
      public int gxTpr_Logworkflowconvenioid_Z
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Logworkflowconvenioid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Logworkflowconvenioid_Z = value;
            SetDirty("Logworkflowconvenioid_Z");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Logworkflowconvenioid_Z_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Logworkflowconvenioid_Z = 0;
         SetDirty("Logworkflowconvenioid_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Logworkflowconvenioid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LogWorkflowConvenioDesc_Z" )]
      [  XmlElement( ElementName = "LogWorkflowConvenioDesc_Z"   )]
      public string gxTpr_Logworkflowconveniodesc_Z
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc_Z = value;
            SetDirty("Logworkflowconveniodesc_Z");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc_Z_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc_Z = "";
         SetDirty("Logworkflowconveniodesc_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoFlowLogDate_Z" )]
      [  XmlElement( ElementName = "ReembolsoFlowLogDate_Z"  , IsNullable=true )]
      public string gxTpr_Reembolsoflowlogdate_Z_Nullable
      {
         get {
            if ( gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate_Z = DateTime.MinValue;
            else
               gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Reembolsoflowlogdate_Z
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate_Z = value;
            SetDirty("Reembolsoflowlogdate_Z");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate_Z_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Reembolsoflowlogdate_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoFlowLogUser_Z" )]
      [  XmlElement( ElementName = "ReembolsoFlowLogUser_Z"   )]
      public short gxTpr_Reembolsoflowloguser_Z
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Reembolsoflowloguser_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsoflowloguser_Z = value;
            SetDirty("Reembolsoflowloguser_Z");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Reembolsoflowloguser_Z_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Reembolsoflowloguser_Z = 0;
         SetDirty("Reembolsoflowloguser_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Reembolsoflowloguser_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoFlowLogUserNome_Z" )]
      [  XmlElement( ElementName = "ReembolsoFlowLogUserNome_Z"   )]
      public string gxTpr_Reembolsoflowlogusernome_Z
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome_Z = value;
            SetDirty("Reembolsoflowlogusernome_Z");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome_Z_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome_Z = "";
         SetDirty("Reembolsoflowlogusernome_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoLogId_Z" )]
      [  XmlElement( ElementName = "ReembolsoLogId_Z"   )]
      public int gxTpr_Reembolsologid_Z
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Reembolsologid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsologid_Z = value;
            SetDirty("Reembolsologid_Z");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Reembolsologid_Z_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Reembolsologid_Z = 0;
         SetDirty("Reembolsologid_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Reembolsologid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoWorkFlowConvenioId_Z" )]
      [  XmlElement( ElementName = "ReembolsoWorkFlowConvenioId_Z"   )]
      public int gxTpr_Reembolsoworkflowconvenioid_Z
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconvenioid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconvenioid_Z = value;
            SetDirty("Reembolsoworkflowconvenioid_Z");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconvenioid_Z_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconvenioid_Z = 0;
         SetDirty("Reembolsoworkflowconvenioid_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconvenioid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoWorkflowConvenioSLA_Z" )]
      [  XmlElement( ElementName = "ReembolsoWorkflowConvenioSLA_Z"   )]
      public short gxTpr_Reembolsoworkflowconveniosla_Z
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconveniosla_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconveniosla_Z = value;
            SetDirty("Reembolsoworkflowconveniosla_Z");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconveniosla_Z_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconveniosla_Z = 0;
         SetDirty("Reembolsoworkflowconveniosla_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconveniosla_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LogReembolsoStatusAtual_F_Z" )]
      [  XmlElement( ElementName = "LogReembolsoStatusAtual_F_Z"   )]
      public string gxTpr_Logreembolsostatusatual_f_Z
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f_Z = value;
            SetDirty("Logreembolsostatusatual_f_Z");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f_Z_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f_Z = "";
         SetDirty("Logreembolsostatusatual_f_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoFlowLogDataSLA_F_Z" )]
      [  XmlElement( ElementName = "ReembolsoFlowLogDataSLA_F_Z"  , IsNullable=true )]
      public string gxTpr_Reembolsoflowlogdatasla_f_Z_Nullable
      {
         get {
            if ( gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatasla_f_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatasla_f_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatasla_f_Z = DateTime.MinValue;
            else
               gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatasla_f_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Reembolsoflowlogdatasla_f_Z
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatasla_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatasla_f_Z = value;
            SetDirty("Reembolsoflowlogdatasla_f_Z");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatasla_f_Z_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatasla_f_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Reembolsoflowlogdatasla_f_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatasla_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoLogProtocolo_Z" )]
      [  XmlElement( ElementName = "ReembolsoLogProtocolo_Z"   )]
      public string gxTpr_Reembolsologprotocolo_Z
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo_Z = value;
            SetDirty("Reembolsologprotocolo_Z");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo_Z_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo_Z = "";
         SetDirty("Reembolsologprotocolo_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoPaciente_Z" )]
      [  XmlElement( ElementName = "ReembolsoPaciente_Z"   )]
      public string gxTpr_Reembolsopaciente_Z
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Reembolsopaciente_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsopaciente_Z = value;
            SetDirty("Reembolsopaciente_Z");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Reembolsopaciente_Z_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Reembolsopaciente_Z = "";
         SetDirty("Reembolsopaciente_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Reembolsopaciente_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoFlowLogDataFinal_Z" )]
      [  XmlElement( ElementName = "ReembolsoFlowLogDataFinal_Z"  , IsNullable=true )]
      public string gxTpr_Reembolsoflowlogdatafinal_Z_Nullable
      {
         get {
            if ( gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal_Z = DateTime.MinValue;
            else
               gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Reembolsoflowlogdatafinal_Z
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal_Z = value;
            SetDirty("Reembolsoflowlogdatafinal_Z");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal_Z_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Reembolsoflowlogdatafinal_Z");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LogWorkflowConvenioId_N" )]
      [  XmlElement( ElementName = "LogWorkflowConvenioId_N"   )]
      public short gxTpr_Logworkflowconvenioid_N
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Logworkflowconvenioid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Logworkflowconvenioid_N = value;
            SetDirty("Logworkflowconvenioid_N");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Logworkflowconvenioid_N_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Logworkflowconvenioid_N = 0;
         SetDirty("Logworkflowconvenioid_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Logworkflowconvenioid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LogWorkflowConvenioDesc_N" )]
      [  XmlElement( ElementName = "LogWorkflowConvenioDesc_N"   )]
      public short gxTpr_Logworkflowconveniodesc_N
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc_N = value;
            SetDirty("Logworkflowconveniodesc_N");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc_N_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc_N = 0;
         SetDirty("Logworkflowconveniodesc_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoFlowLogDate_N" )]
      [  XmlElement( ElementName = "ReembolsoFlowLogDate_N"   )]
      public short gxTpr_Reembolsoflowlogdate_N
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate_N = value;
            SetDirty("Reembolsoflowlogdate_N");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate_N_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate_N = 0;
         SetDirty("Reembolsoflowlogdate_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoFlowLogUser_N" )]
      [  XmlElement( ElementName = "ReembolsoFlowLogUser_N"   )]
      public short gxTpr_Reembolsoflowloguser_N
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Reembolsoflowloguser_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsoflowloguser_N = value;
            SetDirty("Reembolsoflowloguser_N");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Reembolsoflowloguser_N_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Reembolsoflowloguser_N = 0;
         SetDirty("Reembolsoflowloguser_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Reembolsoflowloguser_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoFlowLogUserNome_N" )]
      [  XmlElement( ElementName = "ReembolsoFlowLogUserNome_N"   )]
      public short gxTpr_Reembolsoflowlogusernome_N
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome_N = value;
            SetDirty("Reembolsoflowlogusernome_N");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome_N_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome_N = 0;
         SetDirty("Reembolsoflowlogusernome_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoLogId_N" )]
      [  XmlElement( ElementName = "ReembolsoLogId_N"   )]
      public short gxTpr_Reembolsologid_N
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Reembolsologid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsologid_N = value;
            SetDirty("Reembolsologid_N");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Reembolsologid_N_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Reembolsologid_N = 0;
         SetDirty("Reembolsologid_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Reembolsologid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoWorkFlowConvenioId_N" )]
      [  XmlElement( ElementName = "ReembolsoWorkFlowConvenioId_N"   )]
      public short gxTpr_Reembolsoworkflowconvenioid_N
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconvenioid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconvenioid_N = value;
            SetDirty("Reembolsoworkflowconvenioid_N");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconvenioid_N_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconvenioid_N = 0;
         SetDirty("Reembolsoworkflowconvenioid_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconvenioid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoWorkflowConvenioSLA_N" )]
      [  XmlElement( ElementName = "ReembolsoWorkflowConvenioSLA_N"   )]
      public short gxTpr_Reembolsoworkflowconveniosla_N
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconveniosla_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconveniosla_N = value;
            SetDirty("Reembolsoworkflowconveniosla_N");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconveniosla_N_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconveniosla_N = 0;
         SetDirty("Reembolsoworkflowconveniosla_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconveniosla_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LogReembolsoStatusAtual_F_N" )]
      [  XmlElement( ElementName = "LogReembolsoStatusAtual_F_N"   )]
      public short gxTpr_Logreembolsostatusatual_f_N
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f_N = value;
            SetDirty("Logreembolsostatusatual_f_N");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f_N_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f_N = 0;
         SetDirty("Logreembolsostatusatual_f_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoLogProtocolo_N" )]
      [  XmlElement( ElementName = "ReembolsoLogProtocolo_N"   )]
      public short gxTpr_Reembolsologprotocolo_N
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo_N = value;
            SetDirty("Reembolsologprotocolo_N");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo_N_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo_N = 0;
         SetDirty("Reembolsologprotocolo_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoFlowLogDataFinal_N" )]
      [  XmlElement( ElementName = "ReembolsoFlowLogDataFinal_N"   )]
      public short gxTpr_Reembolsoflowlogdatafinal_N
      {
         get {
            return gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal_N = value;
            SetDirty("Reembolsoflowlogdatafinal_N");
         }

      }

      public void gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal_N_SetNull( )
      {
         gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal_N = 0;
         SetDirty("Reembolsoflowlogdatafinal_N");
         return  ;
      }

      public bool gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal_N_IsNull( )
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
         gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc = "";
         gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate = (DateTime)(DateTime.MinValue);
         gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome = "";
         gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f = "";
         gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatasla_f = (DateTime)(DateTime.MinValue);
         gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo = "";
         gxTv_SdtReembolsoFlowLog_Reembolsopaciente = "";
         gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal = (DateTime)(DateTime.MinValue);
         gxTv_SdtReembolsoFlowLog_Mode = "";
         gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc_Z = "";
         gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome_Z = "";
         gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f_Z = "";
         gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatasla_f_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo_Z = "";
         gxTv_SdtReembolsoFlowLog_Reembolsopaciente_Z = "";
         gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal_Z = (DateTime)(DateTime.MinValue);
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "reembolsoflowlog", "GeneXus.Programs.reembolsoflowlog_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtReembolsoFlowLog_Reembolsoflowloguser ;
      private short gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconveniosla ;
      private short gxTv_SdtReembolsoFlowLog_Initialized ;
      private short gxTv_SdtReembolsoFlowLog_Reembolsoflowloguser_Z ;
      private short gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconveniosla_Z ;
      private short gxTv_SdtReembolsoFlowLog_Logworkflowconvenioid_N ;
      private short gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc_N ;
      private short gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate_N ;
      private short gxTv_SdtReembolsoFlowLog_Reembolsoflowloguser_N ;
      private short gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome_N ;
      private short gxTv_SdtReembolsoFlowLog_Reembolsologid_N ;
      private short gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconvenioid_N ;
      private short gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconveniosla_N ;
      private short gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f_N ;
      private short gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo_N ;
      private short gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal_N ;
      private int gxTv_SdtReembolsoFlowLog_Reembolsoflowlogid ;
      private int gxTv_SdtReembolsoFlowLog_Logworkflowconvenioid ;
      private int gxTv_SdtReembolsoFlowLog_Reembolsologid ;
      private int gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconvenioid ;
      private int gxTv_SdtReembolsoFlowLog_Reembolsoflowlogid_Z ;
      private int gxTv_SdtReembolsoFlowLog_Logworkflowconvenioid_Z ;
      private int gxTv_SdtReembolsoFlowLog_Reembolsologid_Z ;
      private int gxTv_SdtReembolsoFlowLog_Reembolsoworkflowconvenioid_Z ;
      private string gxTv_SdtReembolsoFlowLog_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate ;
      private DateTime gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatasla_f ;
      private DateTime gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal ;
      private DateTime gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdate_Z ;
      private DateTime gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatasla_f_Z ;
      private DateTime gxTv_SdtReembolsoFlowLog_Reembolsoflowlogdatafinal_Z ;
      private DateTime datetime_STZ ;
      private string gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc ;
      private string gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome ;
      private string gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f ;
      private string gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo ;
      private string gxTv_SdtReembolsoFlowLog_Reembolsopaciente ;
      private string gxTv_SdtReembolsoFlowLog_Logworkflowconveniodesc_Z ;
      private string gxTv_SdtReembolsoFlowLog_Reembolsoflowlogusernome_Z ;
      private string gxTv_SdtReembolsoFlowLog_Logreembolsostatusatual_f_Z ;
      private string gxTv_SdtReembolsoFlowLog_Reembolsologprotocolo_Z ;
      private string gxTv_SdtReembolsoFlowLog_Reembolsopaciente_Z ;
   }

   [DataContract(Name = @"ReembolsoFlowLog", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtReembolsoFlowLog_RESTInterface : GxGenericCollectionItem<SdtReembolsoFlowLog>
   {
      public SdtReembolsoFlowLog_RESTInterface( ) : base()
      {
      }

      public SdtReembolsoFlowLog_RESTInterface( SdtReembolsoFlowLog psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ReembolsoFlowLogId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Reembolsoflowlogid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Reembolsoflowlogid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Reembolsoflowlogid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "LogWorkflowConvenioId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Logworkflowconvenioid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Logworkflowconvenioid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Logworkflowconvenioid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "LogWorkflowConvenioDesc" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Logworkflowconveniodesc
      {
         get {
            return sdt.gxTpr_Logworkflowconveniodesc ;
         }

         set {
            sdt.gxTpr_Logworkflowconveniodesc = value;
         }

      }

      [DataMember( Name = "ReembolsoFlowLogDate" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Reembolsoflowlogdate
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Reembolsoflowlogdate, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Reembolsoflowlogdate = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "ReembolsoFlowLogUser" , Order = 4 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Reembolsoflowloguser
      {
         get {
            return sdt.gxTpr_Reembolsoflowloguser ;
         }

         set {
            sdt.gxTpr_Reembolsoflowloguser = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ReembolsoFlowLogUserNome" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Reembolsoflowlogusernome
      {
         get {
            return sdt.gxTpr_Reembolsoflowlogusernome ;
         }

         set {
            sdt.gxTpr_Reembolsoflowlogusernome = value;
         }

      }

      [DataMember( Name = "ReembolsoLogId" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Reembolsologid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Reembolsologid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Reembolsologid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ReembolsoWorkFlowConvenioId" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Reembolsoworkflowconvenioid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Reembolsoworkflowconvenioid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Reembolsoworkflowconvenioid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ReembolsoWorkflowConvenioSLA" , Order = 8 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Reembolsoworkflowconveniosla
      {
         get {
            return sdt.gxTpr_Reembolsoworkflowconveniosla ;
         }

         set {
            sdt.gxTpr_Reembolsoworkflowconveniosla = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "LogReembolsoStatusAtual_F" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Logreembolsostatusatual_f
      {
         get {
            return sdt.gxTpr_Logreembolsostatusatual_f ;
         }

         set {
            sdt.gxTpr_Logreembolsostatusatual_f = value;
         }

      }

      [DataMember( Name = "ReembolsoFlowLogDataSLA_F" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Reembolsoflowlogdatasla_f
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Reembolsoflowlogdatasla_f, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Reembolsoflowlogdatasla_f = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "ReembolsoLogProtocolo" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Reembolsologprotocolo
      {
         get {
            return sdt.gxTpr_Reembolsologprotocolo ;
         }

         set {
            sdt.gxTpr_Reembolsologprotocolo = value;
         }

      }

      [DataMember( Name = "ReembolsoPaciente" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Reembolsopaciente
      {
         get {
            return sdt.gxTpr_Reembolsopaciente ;
         }

         set {
            sdt.gxTpr_Reembolsopaciente = value;
         }

      }

      [DataMember( Name = "ReembolsoFlowLogDataFinal" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Reembolsoflowlogdatafinal
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Reembolsoflowlogdatafinal, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Reembolsoflowlogdatafinal = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      public SdtReembolsoFlowLog sdt
      {
         get {
            return (SdtReembolsoFlowLog)Sdt ;
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
            sdt = new SdtReembolsoFlowLog() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 14 )]
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

   [DataContract(Name = @"ReembolsoFlowLog", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtReembolsoFlowLog_RESTLInterface : GxGenericCollectionItem<SdtReembolsoFlowLog>
   {
      public SdtReembolsoFlowLog_RESTLInterface( ) : base()
      {
      }

      public SdtReembolsoFlowLog_RESTLInterface( SdtReembolsoFlowLog psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "LogWorkflowConvenioDesc" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Logworkflowconveniodesc
      {
         get {
            return sdt.gxTpr_Logworkflowconveniodesc ;
         }

         set {
            sdt.gxTpr_Logworkflowconveniodesc = value;
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

      public SdtReembolsoFlowLog sdt
      {
         get {
            return (SdtReembolsoFlowLog)Sdt ;
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
            sdt = new SdtReembolsoFlowLog() ;
         }
      }

   }

}
