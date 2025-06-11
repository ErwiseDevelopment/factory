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
   [XmlRoot(ElementName = "Reembolso" )]
   [XmlType(TypeName =  "Reembolso" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtReembolso : GxSilentTrnSdt
   {
      public SdtReembolso( )
      {
      }

      public SdtReembolso( IGxContext context )
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

      public void Load( int AV518ReembolsoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV518ReembolsoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ReembolsoId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Reembolso");
         metadata.Set("BT", "Reembolso");
         metadata.Set("PK", "[ \"ReembolsoId\" ]");
         metadata.Set("PKAssigned", "[ \"ReembolsoId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"PropostaId\" ],\"FKMap\":[ \"ReembolsoPropostaId-PropostaId\" ] },{ \"FK\":[ \"SecUserId\" ],\"FKMap\":[ \"ReembolsoCreatedBy-SecUserId\" ] },{ \"FK\":[ \"WorkflowConvenioId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Reembolsoid_Z");
         state.Add("gxTpr_Reembolsopropostaid_Z");
         state.Add("gxTpr_Reembolsopropostapacienteclienterazaosocial_Z");
         state.Add("gxTpr_Reembolsopropostapacienteclienteid_Z");
         state.Add("gxTpr_Reembolsopropostaclinicaid_Z");
         state.Add("gxTpr_Reembolsoprotocolo_Z");
         state.Add("gxTpr_Reembolsovalorreembolsado_f_Z");
         state.Add("gxTpr_Reembolsocreatedat_Z_Nullable");
         state.Add("gxTpr_Reembolsopropostavalor_Z");
         state.Add("gxTpr_Reembolsodataaberturaconvenio_Z_Nullable");
         state.Add("gxTpr_Reembolsocreatedby_Z");
         state.Add("gxTpr_Reembolsoetapaultimo_f_Z_Nullable");
         state.Add("gxTpr_Reembolsostatusatual_f_Z");
         state.Add("gxTpr_Workflowconvenioid_Z");
         state.Add("gxTpr_Workflowconveniodesc_Z");
         state.Add("gxTpr_Reembolsoid_N");
         state.Add("gxTpr_Reembolsopropostaid_N");
         state.Add("gxTpr_Reembolsopropostapacienteclienterazaosocial_N");
         state.Add("gxTpr_Reembolsopropostapacienteclienteid_N");
         state.Add("gxTpr_Reembolsopropostaclinicaid_N");
         state.Add("gxTpr_Reembolsoprotocolo_N");
         state.Add("gxTpr_Reembolsovalorreembolsado_f_N");
         state.Add("gxTpr_Reembolsocreatedat_N");
         state.Add("gxTpr_Reembolsopropostavalor_N");
         state.Add("gxTpr_Reembolsodataaberturaconvenio_N");
         state.Add("gxTpr_Reembolsocreatedby_N");
         state.Add("gxTpr_Reembolsoetapaultimo_f_N");
         state.Add("gxTpr_Reembolsostatusatual_f_N");
         state.Add("gxTpr_Workflowconvenioid_N");
         state.Add("gxTpr_Workflowconveniodesc_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtReembolso sdt;
         sdt = (SdtReembolso)(source);
         gxTv_SdtReembolso_Reembolsoid = sdt.gxTv_SdtReembolso_Reembolsoid ;
         gxTv_SdtReembolso_Reembolsopropostaid = sdt.gxTv_SdtReembolso_Reembolsopropostaid ;
         gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial = sdt.gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial ;
         gxTv_SdtReembolso_Reembolsopropostapacienteclienteid = sdt.gxTv_SdtReembolso_Reembolsopropostapacienteclienteid ;
         gxTv_SdtReembolso_Reembolsopropostaclinicaid = sdt.gxTv_SdtReembolso_Reembolsopropostaclinicaid ;
         gxTv_SdtReembolso_Reembolsoprotocolo = sdt.gxTv_SdtReembolso_Reembolsoprotocolo ;
         gxTv_SdtReembolso_Reembolsovalorreembolsado_f = sdt.gxTv_SdtReembolso_Reembolsovalorreembolsado_f ;
         gxTv_SdtReembolso_Reembolsocreatedat = sdt.gxTv_SdtReembolso_Reembolsocreatedat ;
         gxTv_SdtReembolso_Reembolsopropostavalor = sdt.gxTv_SdtReembolso_Reembolsopropostavalor ;
         gxTv_SdtReembolso_Reembolsodataaberturaconvenio = sdt.gxTv_SdtReembolso_Reembolsodataaberturaconvenio ;
         gxTv_SdtReembolso_Reembolsocreatedby = sdt.gxTv_SdtReembolso_Reembolsocreatedby ;
         gxTv_SdtReembolso_Reembolsoetapaultimo_f = sdt.gxTv_SdtReembolso_Reembolsoetapaultimo_f ;
         gxTv_SdtReembolso_Reembolsostatusatual_f = sdt.gxTv_SdtReembolso_Reembolsostatusatual_f ;
         gxTv_SdtReembolso_Workflowconvenioid = sdt.gxTv_SdtReembolso_Workflowconvenioid ;
         gxTv_SdtReembolso_Workflowconveniodesc = sdt.gxTv_SdtReembolso_Workflowconveniodesc ;
         gxTv_SdtReembolso_Mode = sdt.gxTv_SdtReembolso_Mode ;
         gxTv_SdtReembolso_Initialized = sdt.gxTv_SdtReembolso_Initialized ;
         gxTv_SdtReembolso_Reembolsoid_Z = sdt.gxTv_SdtReembolso_Reembolsoid_Z ;
         gxTv_SdtReembolso_Reembolsopropostaid_Z = sdt.gxTv_SdtReembolso_Reembolsopropostaid_Z ;
         gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial_Z = sdt.gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial_Z ;
         gxTv_SdtReembolso_Reembolsopropostapacienteclienteid_Z = sdt.gxTv_SdtReembolso_Reembolsopropostapacienteclienteid_Z ;
         gxTv_SdtReembolso_Reembolsopropostaclinicaid_Z = sdt.gxTv_SdtReembolso_Reembolsopropostaclinicaid_Z ;
         gxTv_SdtReembolso_Reembolsoprotocolo_Z = sdt.gxTv_SdtReembolso_Reembolsoprotocolo_Z ;
         gxTv_SdtReembolso_Reembolsovalorreembolsado_f_Z = sdt.gxTv_SdtReembolso_Reembolsovalorreembolsado_f_Z ;
         gxTv_SdtReembolso_Reembolsocreatedat_Z = sdt.gxTv_SdtReembolso_Reembolsocreatedat_Z ;
         gxTv_SdtReembolso_Reembolsopropostavalor_Z = sdt.gxTv_SdtReembolso_Reembolsopropostavalor_Z ;
         gxTv_SdtReembolso_Reembolsodataaberturaconvenio_Z = sdt.gxTv_SdtReembolso_Reembolsodataaberturaconvenio_Z ;
         gxTv_SdtReembolso_Reembolsocreatedby_Z = sdt.gxTv_SdtReembolso_Reembolsocreatedby_Z ;
         gxTv_SdtReembolso_Reembolsoetapaultimo_f_Z = sdt.gxTv_SdtReembolso_Reembolsoetapaultimo_f_Z ;
         gxTv_SdtReembolso_Reembolsostatusatual_f_Z = sdt.gxTv_SdtReembolso_Reembolsostatusatual_f_Z ;
         gxTv_SdtReembolso_Workflowconvenioid_Z = sdt.gxTv_SdtReembolso_Workflowconvenioid_Z ;
         gxTv_SdtReembolso_Workflowconveniodesc_Z = sdt.gxTv_SdtReembolso_Workflowconveniodesc_Z ;
         gxTv_SdtReembolso_Reembolsoid_N = sdt.gxTv_SdtReembolso_Reembolsoid_N ;
         gxTv_SdtReembolso_Reembolsopropostaid_N = sdt.gxTv_SdtReembolso_Reembolsopropostaid_N ;
         gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial_N = sdt.gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial_N ;
         gxTv_SdtReembolso_Reembolsopropostapacienteclienteid_N = sdt.gxTv_SdtReembolso_Reembolsopropostapacienteclienteid_N ;
         gxTv_SdtReembolso_Reembolsopropostaclinicaid_N = sdt.gxTv_SdtReembolso_Reembolsopropostaclinicaid_N ;
         gxTv_SdtReembolso_Reembolsoprotocolo_N = sdt.gxTv_SdtReembolso_Reembolsoprotocolo_N ;
         gxTv_SdtReembolso_Reembolsovalorreembolsado_f_N = sdt.gxTv_SdtReembolso_Reembolsovalorreembolsado_f_N ;
         gxTv_SdtReembolso_Reembolsocreatedat_N = sdt.gxTv_SdtReembolso_Reembolsocreatedat_N ;
         gxTv_SdtReembolso_Reembolsopropostavalor_N = sdt.gxTv_SdtReembolso_Reembolsopropostavalor_N ;
         gxTv_SdtReembolso_Reembolsodataaberturaconvenio_N = sdt.gxTv_SdtReembolso_Reembolsodataaberturaconvenio_N ;
         gxTv_SdtReembolso_Reembolsocreatedby_N = sdt.gxTv_SdtReembolso_Reembolsocreatedby_N ;
         gxTv_SdtReembolso_Reembolsoetapaultimo_f_N = sdt.gxTv_SdtReembolso_Reembolsoetapaultimo_f_N ;
         gxTv_SdtReembolso_Reembolsostatusatual_f_N = sdt.gxTv_SdtReembolso_Reembolsostatusatual_f_N ;
         gxTv_SdtReembolso_Workflowconvenioid_N = sdt.gxTv_SdtReembolso_Workflowconvenioid_N ;
         gxTv_SdtReembolso_Workflowconveniodesc_N = sdt.gxTv_SdtReembolso_Workflowconveniodesc_N ;
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
         AddObjectProperty("ReembolsoId", gxTv_SdtReembolso_Reembolsoid, false, includeNonInitialized);
         AddObjectProperty("ReembolsoId_N", gxTv_SdtReembolso_Reembolsoid_N, false, includeNonInitialized);
         AddObjectProperty("ReembolsoPropostaId", gxTv_SdtReembolso_Reembolsopropostaid, false, includeNonInitialized);
         AddObjectProperty("ReembolsoPropostaId_N", gxTv_SdtReembolso_Reembolsopropostaid_N, false, includeNonInitialized);
         AddObjectProperty("ReembolsoPropostaPacienteClienteRazaoSocial", gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial, false, includeNonInitialized);
         AddObjectProperty("ReembolsoPropostaPacienteClienteRazaoSocial_N", gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial_N, false, includeNonInitialized);
         AddObjectProperty("ReembolsoPropostaPacienteClienteId", gxTv_SdtReembolso_Reembolsopropostapacienteclienteid, false, includeNonInitialized);
         AddObjectProperty("ReembolsoPropostaPacienteClienteId_N", gxTv_SdtReembolso_Reembolsopropostapacienteclienteid_N, false, includeNonInitialized);
         AddObjectProperty("ReembolsoPropostaClinicaId", gxTv_SdtReembolso_Reembolsopropostaclinicaid, false, includeNonInitialized);
         AddObjectProperty("ReembolsoPropostaClinicaId_N", gxTv_SdtReembolso_Reembolsopropostaclinicaid_N, false, includeNonInitialized);
         AddObjectProperty("ReembolsoProtocolo", gxTv_SdtReembolso_Reembolsoprotocolo, false, includeNonInitialized);
         AddObjectProperty("ReembolsoProtocolo_N", gxTv_SdtReembolso_Reembolsoprotocolo_N, false, includeNonInitialized);
         AddObjectProperty("ReembolsoValorReembolsado_F", StringUtil.LTrim( StringUtil.Str( gxTv_SdtReembolso_Reembolsovalorreembolsado_f, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("ReembolsoValorReembolsado_F_N", gxTv_SdtReembolso_Reembolsovalorreembolsado_f_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtReembolso_Reembolsocreatedat;
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
         AddObjectProperty("ReembolsoCreatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ReembolsoCreatedAt_N", gxTv_SdtReembolso_Reembolsocreatedat_N, false, includeNonInitialized);
         AddObjectProperty("ReembolsoPropostaValor", StringUtil.LTrim( StringUtil.Str( gxTv_SdtReembolso_Reembolsopropostavalor, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("ReembolsoPropostaValor_N", gxTv_SdtReembolso_Reembolsopropostavalor_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtReembolso_Reembolsodataaberturaconvenio)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtReembolso_Reembolsodataaberturaconvenio)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtReembolso_Reembolsodataaberturaconvenio)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("ReembolsoDataAberturaConvenio", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ReembolsoDataAberturaConvenio_N", gxTv_SdtReembolso_Reembolsodataaberturaconvenio_N, false, includeNonInitialized);
         AddObjectProperty("ReembolsoCreatedBy", gxTv_SdtReembolso_Reembolsocreatedby, false, includeNonInitialized);
         AddObjectProperty("ReembolsoCreatedBy_N", gxTv_SdtReembolso_Reembolsocreatedby_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtReembolso_Reembolsoetapaultimo_f;
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
         AddObjectProperty("ReembolsoEtapaUltimo_F", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ReembolsoEtapaUltimo_F_N", gxTv_SdtReembolso_Reembolsoetapaultimo_f_N, false, includeNonInitialized);
         AddObjectProperty("ReembolsoStatusAtual_F", gxTv_SdtReembolso_Reembolsostatusatual_f, false, includeNonInitialized);
         AddObjectProperty("ReembolsoStatusAtual_F_N", gxTv_SdtReembolso_Reembolsostatusatual_f_N, false, includeNonInitialized);
         AddObjectProperty("WorkflowConvenioId", gxTv_SdtReembolso_Workflowconvenioid, false, includeNonInitialized);
         AddObjectProperty("WorkflowConvenioId_N", gxTv_SdtReembolso_Workflowconvenioid_N, false, includeNonInitialized);
         AddObjectProperty("WorkflowConvenioDesc", gxTv_SdtReembolso_Workflowconveniodesc, false, includeNonInitialized);
         AddObjectProperty("WorkflowConvenioDesc_N", gxTv_SdtReembolso_Workflowconveniodesc_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtReembolso_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtReembolso_Initialized, false, includeNonInitialized);
            AddObjectProperty("ReembolsoId_Z", gxTv_SdtReembolso_Reembolsoid_Z, false, includeNonInitialized);
            AddObjectProperty("ReembolsoPropostaId_Z", gxTv_SdtReembolso_Reembolsopropostaid_Z, false, includeNonInitialized);
            AddObjectProperty("ReembolsoPropostaPacienteClienteRazaoSocial_Z", gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial_Z, false, includeNonInitialized);
            AddObjectProperty("ReembolsoPropostaPacienteClienteId_Z", gxTv_SdtReembolso_Reembolsopropostapacienteclienteid_Z, false, includeNonInitialized);
            AddObjectProperty("ReembolsoPropostaClinicaId_Z", gxTv_SdtReembolso_Reembolsopropostaclinicaid_Z, false, includeNonInitialized);
            AddObjectProperty("ReembolsoProtocolo_Z", gxTv_SdtReembolso_Reembolsoprotocolo_Z, false, includeNonInitialized);
            AddObjectProperty("ReembolsoValorReembolsado_F_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtReembolso_Reembolsovalorreembolsado_f_Z, 18, 2)), false, includeNonInitialized);
            datetime_STZ = gxTv_SdtReembolso_Reembolsocreatedat_Z;
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
            AddObjectProperty("ReembolsoCreatedAt_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("ReembolsoPropostaValor_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtReembolso_Reembolsopropostavalor_Z, 18, 2)), false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtReembolso_Reembolsodataaberturaconvenio_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtReembolso_Reembolsodataaberturaconvenio_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtReembolso_Reembolsodataaberturaconvenio_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("ReembolsoDataAberturaConvenio_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("ReembolsoCreatedBy_Z", gxTv_SdtReembolso_Reembolsocreatedby_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtReembolso_Reembolsoetapaultimo_f_Z;
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
            AddObjectProperty("ReembolsoEtapaUltimo_F_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("ReembolsoStatusAtual_F_Z", gxTv_SdtReembolso_Reembolsostatusatual_f_Z, false, includeNonInitialized);
            AddObjectProperty("WorkflowConvenioId_Z", gxTv_SdtReembolso_Workflowconvenioid_Z, false, includeNonInitialized);
            AddObjectProperty("WorkflowConvenioDesc_Z", gxTv_SdtReembolso_Workflowconveniodesc_Z, false, includeNonInitialized);
            AddObjectProperty("ReembolsoId_N", gxTv_SdtReembolso_Reembolsoid_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoPropostaId_N", gxTv_SdtReembolso_Reembolsopropostaid_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoPropostaPacienteClienteRazaoSocial_N", gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoPropostaPacienteClienteId_N", gxTv_SdtReembolso_Reembolsopropostapacienteclienteid_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoPropostaClinicaId_N", gxTv_SdtReembolso_Reembolsopropostaclinicaid_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoProtocolo_N", gxTv_SdtReembolso_Reembolsoprotocolo_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoValorReembolsado_F_N", gxTv_SdtReembolso_Reembolsovalorreembolsado_f_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoCreatedAt_N", gxTv_SdtReembolso_Reembolsocreatedat_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoPropostaValor_N", gxTv_SdtReembolso_Reembolsopropostavalor_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoDataAberturaConvenio_N", gxTv_SdtReembolso_Reembolsodataaberturaconvenio_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoCreatedBy_N", gxTv_SdtReembolso_Reembolsocreatedby_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoEtapaUltimo_F_N", gxTv_SdtReembolso_Reembolsoetapaultimo_f_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoStatusAtual_F_N", gxTv_SdtReembolso_Reembolsostatusatual_f_N, false, includeNonInitialized);
            AddObjectProperty("WorkflowConvenioId_N", gxTv_SdtReembolso_Workflowconvenioid_N, false, includeNonInitialized);
            AddObjectProperty("WorkflowConvenioDesc_N", gxTv_SdtReembolso_Workflowconveniodesc_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtReembolso sdt )
      {
         if ( sdt.IsDirty("ReembolsoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsoid = sdt.gxTv_SdtReembolso_Reembolsoid ;
         }
         if ( sdt.IsDirty("ReembolsoPropostaId") )
         {
            gxTv_SdtReembolso_Reembolsopropostaid_N = (short)(sdt.gxTv_SdtReembolso_Reembolsopropostaid_N);
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsopropostaid = sdt.gxTv_SdtReembolso_Reembolsopropostaid ;
         }
         if ( sdt.IsDirty("ReembolsoPropostaPacienteClienteRazaoSocial") )
         {
            gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial_N = (short)(sdt.gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial_N);
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial = sdt.gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial ;
         }
         if ( sdt.IsDirty("ReembolsoPropostaPacienteClienteId") )
         {
            gxTv_SdtReembolso_Reembolsopropostapacienteclienteid_N = (short)(sdt.gxTv_SdtReembolso_Reembolsopropostapacienteclienteid_N);
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsopropostapacienteclienteid = sdt.gxTv_SdtReembolso_Reembolsopropostapacienteclienteid ;
         }
         if ( sdt.IsDirty("ReembolsoPropostaClinicaId") )
         {
            gxTv_SdtReembolso_Reembolsopropostaclinicaid_N = (short)(sdt.gxTv_SdtReembolso_Reembolsopropostaclinicaid_N);
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsopropostaclinicaid = sdt.gxTv_SdtReembolso_Reembolsopropostaclinicaid ;
         }
         if ( sdt.IsDirty("ReembolsoProtocolo") )
         {
            gxTv_SdtReembolso_Reembolsoprotocolo_N = (short)(sdt.gxTv_SdtReembolso_Reembolsoprotocolo_N);
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsoprotocolo = sdt.gxTv_SdtReembolso_Reembolsoprotocolo ;
         }
         if ( sdt.IsDirty("ReembolsoValorReembolsado_F") )
         {
            gxTv_SdtReembolso_Reembolsovalorreembolsado_f_N = (short)(sdt.gxTv_SdtReembolso_Reembolsovalorreembolsado_f_N);
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsovalorreembolsado_f = sdt.gxTv_SdtReembolso_Reembolsovalorreembolsado_f ;
         }
         if ( sdt.IsDirty("ReembolsoCreatedAt") )
         {
            gxTv_SdtReembolso_Reembolsocreatedat_N = (short)(sdt.gxTv_SdtReembolso_Reembolsocreatedat_N);
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsocreatedat = sdt.gxTv_SdtReembolso_Reembolsocreatedat ;
         }
         if ( sdt.IsDirty("ReembolsoPropostaValor") )
         {
            gxTv_SdtReembolso_Reembolsopropostavalor_N = (short)(sdt.gxTv_SdtReembolso_Reembolsopropostavalor_N);
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsopropostavalor = sdt.gxTv_SdtReembolso_Reembolsopropostavalor ;
         }
         if ( sdt.IsDirty("ReembolsoDataAberturaConvenio") )
         {
            gxTv_SdtReembolso_Reembolsodataaberturaconvenio_N = (short)(sdt.gxTv_SdtReembolso_Reembolsodataaberturaconvenio_N);
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsodataaberturaconvenio = sdt.gxTv_SdtReembolso_Reembolsodataaberturaconvenio ;
         }
         if ( sdt.IsDirty("ReembolsoCreatedBy") )
         {
            gxTv_SdtReembolso_Reembolsocreatedby_N = (short)(sdt.gxTv_SdtReembolso_Reembolsocreatedby_N);
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsocreatedby = sdt.gxTv_SdtReembolso_Reembolsocreatedby ;
         }
         if ( sdt.IsDirty("ReembolsoEtapaUltimo_F") )
         {
            gxTv_SdtReembolso_Reembolsoetapaultimo_f_N = (short)(sdt.gxTv_SdtReembolso_Reembolsoetapaultimo_f_N);
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsoetapaultimo_f = sdt.gxTv_SdtReembolso_Reembolsoetapaultimo_f ;
         }
         if ( sdt.IsDirty("ReembolsoStatusAtual_F") )
         {
            gxTv_SdtReembolso_Reembolsostatusatual_f_N = (short)(sdt.gxTv_SdtReembolso_Reembolsostatusatual_f_N);
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsostatusatual_f = sdt.gxTv_SdtReembolso_Reembolsostatusatual_f ;
         }
         if ( sdt.IsDirty("WorkflowConvenioId") )
         {
            gxTv_SdtReembolso_Workflowconvenioid_N = (short)(sdt.gxTv_SdtReembolso_Workflowconvenioid_N);
            sdtIsNull = 0;
            gxTv_SdtReembolso_Workflowconvenioid = sdt.gxTv_SdtReembolso_Workflowconvenioid ;
         }
         if ( sdt.IsDirty("WorkflowConvenioDesc") )
         {
            gxTv_SdtReembolso_Workflowconveniodesc_N = (short)(sdt.gxTv_SdtReembolso_Workflowconveniodesc_N);
            sdtIsNull = 0;
            gxTv_SdtReembolso_Workflowconveniodesc = sdt.gxTv_SdtReembolso_Workflowconveniodesc ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ReembolsoId" )]
      [  XmlElement( ElementName = "ReembolsoId"   )]
      public int gxTpr_Reembolsoid
      {
         get {
            return gxTv_SdtReembolso_Reembolsoid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtReembolso_Reembolsoid != value )
            {
               gxTv_SdtReembolso_Mode = "INS";
               this.gxTv_SdtReembolso_Reembolsoid_Z_SetNull( );
               this.gxTv_SdtReembolso_Reembolsopropostaid_Z_SetNull( );
               this.gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial_Z_SetNull( );
               this.gxTv_SdtReembolso_Reembolsopropostapacienteclienteid_Z_SetNull( );
               this.gxTv_SdtReembolso_Reembolsopropostaclinicaid_Z_SetNull( );
               this.gxTv_SdtReembolso_Reembolsoprotocolo_Z_SetNull( );
               this.gxTv_SdtReembolso_Reembolsovalorreembolsado_f_Z_SetNull( );
               this.gxTv_SdtReembolso_Reembolsocreatedat_Z_SetNull( );
               this.gxTv_SdtReembolso_Reembolsopropostavalor_Z_SetNull( );
               this.gxTv_SdtReembolso_Reembolsodataaberturaconvenio_Z_SetNull( );
               this.gxTv_SdtReembolso_Reembolsocreatedby_Z_SetNull( );
               this.gxTv_SdtReembolso_Reembolsoetapaultimo_f_Z_SetNull( );
               this.gxTv_SdtReembolso_Reembolsostatusatual_f_Z_SetNull( );
               this.gxTv_SdtReembolso_Workflowconvenioid_Z_SetNull( );
               this.gxTv_SdtReembolso_Workflowconveniodesc_Z_SetNull( );
            }
            gxTv_SdtReembolso_Reembolsoid = value;
            SetDirty("Reembolsoid");
         }

      }

      [  SoapElement( ElementName = "ReembolsoPropostaId" )]
      [  XmlElement( ElementName = "ReembolsoPropostaId"   )]
      public int gxTpr_Reembolsopropostaid
      {
         get {
            return gxTv_SdtReembolso_Reembolsopropostaid ;
         }

         set {
            gxTv_SdtReembolso_Reembolsopropostaid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsopropostaid = value;
            SetDirty("Reembolsopropostaid");
         }

      }

      public void gxTv_SdtReembolso_Reembolsopropostaid_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsopropostaid_N = 1;
         gxTv_SdtReembolso_Reembolsopropostaid = 0;
         SetDirty("Reembolsopropostaid");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsopropostaid_IsNull( )
      {
         return (gxTv_SdtReembolso_Reembolsopropostaid_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoPropostaPacienteClienteRazaoSocial" )]
      [  XmlElement( ElementName = "ReembolsoPropostaPacienteClienteRazaoSocial"   )]
      public string gxTpr_Reembolsopropostapacienteclienterazaosocial
      {
         get {
            return gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial ;
         }

         set {
            gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial = value;
            SetDirty("Reembolsopropostapacienteclienterazaosocial");
         }

      }

      public void gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial_N = 1;
         gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial = "";
         SetDirty("Reembolsopropostapacienteclienterazaosocial");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial_IsNull( )
      {
         return (gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoPropostaPacienteClienteId" )]
      [  XmlElement( ElementName = "ReembolsoPropostaPacienteClienteId"   )]
      public int gxTpr_Reembolsopropostapacienteclienteid
      {
         get {
            return gxTv_SdtReembolso_Reembolsopropostapacienteclienteid ;
         }

         set {
            gxTv_SdtReembolso_Reembolsopropostapacienteclienteid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsopropostapacienteclienteid = value;
            SetDirty("Reembolsopropostapacienteclienteid");
         }

      }

      public void gxTv_SdtReembolso_Reembolsopropostapacienteclienteid_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsopropostapacienteclienteid_N = 1;
         gxTv_SdtReembolso_Reembolsopropostapacienteclienteid = 0;
         SetDirty("Reembolsopropostapacienteclienteid");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsopropostapacienteclienteid_IsNull( )
      {
         return (gxTv_SdtReembolso_Reembolsopropostapacienteclienteid_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoPropostaClinicaId" )]
      [  XmlElement( ElementName = "ReembolsoPropostaClinicaId"   )]
      public int gxTpr_Reembolsopropostaclinicaid
      {
         get {
            return gxTv_SdtReembolso_Reembolsopropostaclinicaid ;
         }

         set {
            gxTv_SdtReembolso_Reembolsopropostaclinicaid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsopropostaclinicaid = value;
            SetDirty("Reembolsopropostaclinicaid");
         }

      }

      public void gxTv_SdtReembolso_Reembolsopropostaclinicaid_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsopropostaclinicaid_N = 1;
         gxTv_SdtReembolso_Reembolsopropostaclinicaid = 0;
         SetDirty("Reembolsopropostaclinicaid");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsopropostaclinicaid_IsNull( )
      {
         return (gxTv_SdtReembolso_Reembolsopropostaclinicaid_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoProtocolo" )]
      [  XmlElement( ElementName = "ReembolsoProtocolo"   )]
      public string gxTpr_Reembolsoprotocolo
      {
         get {
            return gxTv_SdtReembolso_Reembolsoprotocolo ;
         }

         set {
            gxTv_SdtReembolso_Reembolsoprotocolo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsoprotocolo = value;
            SetDirty("Reembolsoprotocolo");
         }

      }

      public void gxTv_SdtReembolso_Reembolsoprotocolo_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsoprotocolo_N = 1;
         gxTv_SdtReembolso_Reembolsoprotocolo = "";
         SetDirty("Reembolsoprotocolo");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsoprotocolo_IsNull( )
      {
         return (gxTv_SdtReembolso_Reembolsoprotocolo_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoValorReembolsado_F" )]
      [  XmlElement( ElementName = "ReembolsoValorReembolsado_F"   )]
      public decimal gxTpr_Reembolsovalorreembolsado_f
      {
         get {
            return gxTv_SdtReembolso_Reembolsovalorreembolsado_f ;
         }

         set {
            gxTv_SdtReembolso_Reembolsovalorreembolsado_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsovalorreembolsado_f = value;
            SetDirty("Reembolsovalorreembolsado_f");
         }

      }

      public void gxTv_SdtReembolso_Reembolsovalorreembolsado_f_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsovalorreembolsado_f_N = 1;
         gxTv_SdtReembolso_Reembolsovalorreembolsado_f = 0;
         SetDirty("Reembolsovalorreembolsado_f");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsovalorreembolsado_f_IsNull( )
      {
         return (gxTv_SdtReembolso_Reembolsovalorreembolsado_f_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoCreatedAt" )]
      [  XmlElement( ElementName = "ReembolsoCreatedAt"  , IsNullable=true )]
      public string gxTpr_Reembolsocreatedat_Nullable
      {
         get {
            if ( gxTv_SdtReembolso_Reembolsocreatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtReembolso_Reembolsocreatedat).value ;
         }

         set {
            gxTv_SdtReembolso_Reembolsocreatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtReembolso_Reembolsocreatedat = DateTime.MinValue;
            else
               gxTv_SdtReembolso_Reembolsocreatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Reembolsocreatedat
      {
         get {
            return gxTv_SdtReembolso_Reembolsocreatedat ;
         }

         set {
            gxTv_SdtReembolso_Reembolsocreatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsocreatedat = value;
            SetDirty("Reembolsocreatedat");
         }

      }

      public void gxTv_SdtReembolso_Reembolsocreatedat_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsocreatedat_N = 1;
         gxTv_SdtReembolso_Reembolsocreatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Reembolsocreatedat");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsocreatedat_IsNull( )
      {
         return (gxTv_SdtReembolso_Reembolsocreatedat_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoPropostaValor" )]
      [  XmlElement( ElementName = "ReembolsoPropostaValor"   )]
      public decimal gxTpr_Reembolsopropostavalor
      {
         get {
            return gxTv_SdtReembolso_Reembolsopropostavalor ;
         }

         set {
            gxTv_SdtReembolso_Reembolsopropostavalor_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsopropostavalor = value;
            SetDirty("Reembolsopropostavalor");
         }

      }

      public void gxTv_SdtReembolso_Reembolsopropostavalor_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsopropostavalor_N = 1;
         gxTv_SdtReembolso_Reembolsopropostavalor = 0;
         SetDirty("Reembolsopropostavalor");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsopropostavalor_IsNull( )
      {
         return (gxTv_SdtReembolso_Reembolsopropostavalor_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoDataAberturaConvenio" )]
      [  XmlElement( ElementName = "ReembolsoDataAberturaConvenio"  , IsNullable=true )]
      public string gxTpr_Reembolsodataaberturaconvenio_Nullable
      {
         get {
            if ( gxTv_SdtReembolso_Reembolsodataaberturaconvenio == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtReembolso_Reembolsodataaberturaconvenio).value ;
         }

         set {
            gxTv_SdtReembolso_Reembolsodataaberturaconvenio_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtReembolso_Reembolsodataaberturaconvenio = DateTime.MinValue;
            else
               gxTv_SdtReembolso_Reembolsodataaberturaconvenio = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Reembolsodataaberturaconvenio
      {
         get {
            return gxTv_SdtReembolso_Reembolsodataaberturaconvenio ;
         }

         set {
            gxTv_SdtReembolso_Reembolsodataaberturaconvenio_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsodataaberturaconvenio = value;
            SetDirty("Reembolsodataaberturaconvenio");
         }

      }

      public void gxTv_SdtReembolso_Reembolsodataaberturaconvenio_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsodataaberturaconvenio_N = 1;
         gxTv_SdtReembolso_Reembolsodataaberturaconvenio = (DateTime)(DateTime.MinValue);
         SetDirty("Reembolsodataaberturaconvenio");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsodataaberturaconvenio_IsNull( )
      {
         return (gxTv_SdtReembolso_Reembolsodataaberturaconvenio_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoCreatedBy" )]
      [  XmlElement( ElementName = "ReembolsoCreatedBy"   )]
      public short gxTpr_Reembolsocreatedby
      {
         get {
            return gxTv_SdtReembolso_Reembolsocreatedby ;
         }

         set {
            gxTv_SdtReembolso_Reembolsocreatedby_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsocreatedby = value;
            SetDirty("Reembolsocreatedby");
         }

      }

      public void gxTv_SdtReembolso_Reembolsocreatedby_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsocreatedby_N = 1;
         gxTv_SdtReembolso_Reembolsocreatedby = 0;
         SetDirty("Reembolsocreatedby");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsocreatedby_IsNull( )
      {
         return (gxTv_SdtReembolso_Reembolsocreatedby_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoEtapaUltimo_F" )]
      [  XmlElement( ElementName = "ReembolsoEtapaUltimo_F"  , IsNullable=true )]
      public string gxTpr_Reembolsoetapaultimo_f_Nullable
      {
         get {
            if ( gxTv_SdtReembolso_Reembolsoetapaultimo_f == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtReembolso_Reembolsoetapaultimo_f).value ;
         }

         set {
            gxTv_SdtReembolso_Reembolsoetapaultimo_f_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtReembolso_Reembolsoetapaultimo_f = DateTime.MinValue;
            else
               gxTv_SdtReembolso_Reembolsoetapaultimo_f = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Reembolsoetapaultimo_f
      {
         get {
            return gxTv_SdtReembolso_Reembolsoetapaultimo_f ;
         }

         set {
            gxTv_SdtReembolso_Reembolsoetapaultimo_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsoetapaultimo_f = value;
            SetDirty("Reembolsoetapaultimo_f");
         }

      }

      public void gxTv_SdtReembolso_Reembolsoetapaultimo_f_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsoetapaultimo_f_N = 1;
         gxTv_SdtReembolso_Reembolsoetapaultimo_f = (DateTime)(DateTime.MinValue);
         SetDirty("Reembolsoetapaultimo_f");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsoetapaultimo_f_IsNull( )
      {
         return (gxTv_SdtReembolso_Reembolsoetapaultimo_f_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoStatusAtual_F" )]
      [  XmlElement( ElementName = "ReembolsoStatusAtual_F"   )]
      public string gxTpr_Reembolsostatusatual_f
      {
         get {
            return gxTv_SdtReembolso_Reembolsostatusatual_f ;
         }

         set {
            gxTv_SdtReembolso_Reembolsostatusatual_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsostatusatual_f = value;
            SetDirty("Reembolsostatusatual_f");
         }

      }

      public void gxTv_SdtReembolso_Reembolsostatusatual_f_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsostatusatual_f_N = 1;
         gxTv_SdtReembolso_Reembolsostatusatual_f = "";
         SetDirty("Reembolsostatusatual_f");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsostatusatual_f_IsNull( )
      {
         return (gxTv_SdtReembolso_Reembolsostatusatual_f_N==1) ;
      }

      [  SoapElement( ElementName = "WorkflowConvenioId" )]
      [  XmlElement( ElementName = "WorkflowConvenioId"   )]
      public int gxTpr_Workflowconvenioid
      {
         get {
            return gxTv_SdtReembolso_Workflowconvenioid ;
         }

         set {
            gxTv_SdtReembolso_Workflowconvenioid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolso_Workflowconvenioid = value;
            SetDirty("Workflowconvenioid");
         }

      }

      public void gxTv_SdtReembolso_Workflowconvenioid_SetNull( )
      {
         gxTv_SdtReembolso_Workflowconvenioid_N = 1;
         gxTv_SdtReembolso_Workflowconvenioid = 0;
         SetDirty("Workflowconvenioid");
         return  ;
      }

      public bool gxTv_SdtReembolso_Workflowconvenioid_IsNull( )
      {
         return (gxTv_SdtReembolso_Workflowconvenioid_N==1) ;
      }

      [  SoapElement( ElementName = "WorkflowConvenioDesc" )]
      [  XmlElement( ElementName = "WorkflowConvenioDesc"   )]
      public string gxTpr_Workflowconveniodesc
      {
         get {
            return gxTv_SdtReembolso_Workflowconveniodesc ;
         }

         set {
            gxTv_SdtReembolso_Workflowconveniodesc_N = 0;
            sdtIsNull = 0;
            gxTv_SdtReembolso_Workflowconveniodesc = value;
            SetDirty("Workflowconveniodesc");
         }

      }

      public void gxTv_SdtReembolso_Workflowconveniodesc_SetNull( )
      {
         gxTv_SdtReembolso_Workflowconveniodesc_N = 1;
         gxTv_SdtReembolso_Workflowconveniodesc = "";
         SetDirty("Workflowconveniodesc");
         return  ;
      }

      public bool gxTv_SdtReembolso_Workflowconveniodesc_IsNull( )
      {
         return (gxTv_SdtReembolso_Workflowconveniodesc_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtReembolso_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolso_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtReembolso_Mode_SetNull( )
      {
         gxTv_SdtReembolso_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtReembolso_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtReembolso_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolso_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtReembolso_Initialized_SetNull( )
      {
         gxTv_SdtReembolso_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtReembolso_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoId_Z" )]
      [  XmlElement( ElementName = "ReembolsoId_Z"   )]
      public int gxTpr_Reembolsoid_Z
      {
         get {
            return gxTv_SdtReembolso_Reembolsoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsoid_Z = value;
            SetDirty("Reembolsoid_Z");
         }

      }

      public void gxTv_SdtReembolso_Reembolsoid_Z_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsoid_Z = 0;
         SetDirty("Reembolsoid_Z");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoPropostaId_Z" )]
      [  XmlElement( ElementName = "ReembolsoPropostaId_Z"   )]
      public int gxTpr_Reembolsopropostaid_Z
      {
         get {
            return gxTv_SdtReembolso_Reembolsopropostaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsopropostaid_Z = value;
            SetDirty("Reembolsopropostaid_Z");
         }

      }

      public void gxTv_SdtReembolso_Reembolsopropostaid_Z_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsopropostaid_Z = 0;
         SetDirty("Reembolsopropostaid_Z");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsopropostaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoPropostaPacienteClienteRazaoSocial_Z" )]
      [  XmlElement( ElementName = "ReembolsoPropostaPacienteClienteRazaoSocial_Z"   )]
      public string gxTpr_Reembolsopropostapacienteclienterazaosocial_Z
      {
         get {
            return gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial_Z = value;
            SetDirty("Reembolsopropostapacienteclienterazaosocial_Z");
         }

      }

      public void gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial_Z_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial_Z = "";
         SetDirty("Reembolsopropostapacienteclienterazaosocial_Z");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoPropostaPacienteClienteId_Z" )]
      [  XmlElement( ElementName = "ReembolsoPropostaPacienteClienteId_Z"   )]
      public int gxTpr_Reembolsopropostapacienteclienteid_Z
      {
         get {
            return gxTv_SdtReembolso_Reembolsopropostapacienteclienteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsopropostapacienteclienteid_Z = value;
            SetDirty("Reembolsopropostapacienteclienteid_Z");
         }

      }

      public void gxTv_SdtReembolso_Reembolsopropostapacienteclienteid_Z_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsopropostapacienteclienteid_Z = 0;
         SetDirty("Reembolsopropostapacienteclienteid_Z");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsopropostapacienteclienteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoPropostaClinicaId_Z" )]
      [  XmlElement( ElementName = "ReembolsoPropostaClinicaId_Z"   )]
      public int gxTpr_Reembolsopropostaclinicaid_Z
      {
         get {
            return gxTv_SdtReembolso_Reembolsopropostaclinicaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsopropostaclinicaid_Z = value;
            SetDirty("Reembolsopropostaclinicaid_Z");
         }

      }

      public void gxTv_SdtReembolso_Reembolsopropostaclinicaid_Z_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsopropostaclinicaid_Z = 0;
         SetDirty("Reembolsopropostaclinicaid_Z");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsopropostaclinicaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoProtocolo_Z" )]
      [  XmlElement( ElementName = "ReembolsoProtocolo_Z"   )]
      public string gxTpr_Reembolsoprotocolo_Z
      {
         get {
            return gxTv_SdtReembolso_Reembolsoprotocolo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsoprotocolo_Z = value;
            SetDirty("Reembolsoprotocolo_Z");
         }

      }

      public void gxTv_SdtReembolso_Reembolsoprotocolo_Z_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsoprotocolo_Z = "";
         SetDirty("Reembolsoprotocolo_Z");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsoprotocolo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoValorReembolsado_F_Z" )]
      [  XmlElement( ElementName = "ReembolsoValorReembolsado_F_Z"   )]
      public decimal gxTpr_Reembolsovalorreembolsado_f_Z
      {
         get {
            return gxTv_SdtReembolso_Reembolsovalorreembolsado_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsovalorreembolsado_f_Z = value;
            SetDirty("Reembolsovalorreembolsado_f_Z");
         }

      }

      public void gxTv_SdtReembolso_Reembolsovalorreembolsado_f_Z_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsovalorreembolsado_f_Z = 0;
         SetDirty("Reembolsovalorreembolsado_f_Z");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsovalorreembolsado_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoCreatedAt_Z" )]
      [  XmlElement( ElementName = "ReembolsoCreatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Reembolsocreatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtReembolso_Reembolsocreatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtReembolso_Reembolsocreatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtReembolso_Reembolsocreatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtReembolso_Reembolsocreatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Reembolsocreatedat_Z
      {
         get {
            return gxTv_SdtReembolso_Reembolsocreatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsocreatedat_Z = value;
            SetDirty("Reembolsocreatedat_Z");
         }

      }

      public void gxTv_SdtReembolso_Reembolsocreatedat_Z_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsocreatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Reembolsocreatedat_Z");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsocreatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoPropostaValor_Z" )]
      [  XmlElement( ElementName = "ReembolsoPropostaValor_Z"   )]
      public decimal gxTpr_Reembolsopropostavalor_Z
      {
         get {
            return gxTv_SdtReembolso_Reembolsopropostavalor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsopropostavalor_Z = value;
            SetDirty("Reembolsopropostavalor_Z");
         }

      }

      public void gxTv_SdtReembolso_Reembolsopropostavalor_Z_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsopropostavalor_Z = 0;
         SetDirty("Reembolsopropostavalor_Z");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsopropostavalor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoDataAberturaConvenio_Z" )]
      [  XmlElement( ElementName = "ReembolsoDataAberturaConvenio_Z"  , IsNullable=true )]
      public string gxTpr_Reembolsodataaberturaconvenio_Z_Nullable
      {
         get {
            if ( gxTv_SdtReembolso_Reembolsodataaberturaconvenio_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtReembolso_Reembolsodataaberturaconvenio_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtReembolso_Reembolsodataaberturaconvenio_Z = DateTime.MinValue;
            else
               gxTv_SdtReembolso_Reembolsodataaberturaconvenio_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Reembolsodataaberturaconvenio_Z
      {
         get {
            return gxTv_SdtReembolso_Reembolsodataaberturaconvenio_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsodataaberturaconvenio_Z = value;
            SetDirty("Reembolsodataaberturaconvenio_Z");
         }

      }

      public void gxTv_SdtReembolso_Reembolsodataaberturaconvenio_Z_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsodataaberturaconvenio_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Reembolsodataaberturaconvenio_Z");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsodataaberturaconvenio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoCreatedBy_Z" )]
      [  XmlElement( ElementName = "ReembolsoCreatedBy_Z"   )]
      public short gxTpr_Reembolsocreatedby_Z
      {
         get {
            return gxTv_SdtReembolso_Reembolsocreatedby_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsocreatedby_Z = value;
            SetDirty("Reembolsocreatedby_Z");
         }

      }

      public void gxTv_SdtReembolso_Reembolsocreatedby_Z_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsocreatedby_Z = 0;
         SetDirty("Reembolsocreatedby_Z");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsocreatedby_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoEtapaUltimo_F_Z" )]
      [  XmlElement( ElementName = "ReembolsoEtapaUltimo_F_Z"  , IsNullable=true )]
      public string gxTpr_Reembolsoetapaultimo_f_Z_Nullable
      {
         get {
            if ( gxTv_SdtReembolso_Reembolsoetapaultimo_f_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtReembolso_Reembolsoetapaultimo_f_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtReembolso_Reembolsoetapaultimo_f_Z = DateTime.MinValue;
            else
               gxTv_SdtReembolso_Reembolsoetapaultimo_f_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Reembolsoetapaultimo_f_Z
      {
         get {
            return gxTv_SdtReembolso_Reembolsoetapaultimo_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsoetapaultimo_f_Z = value;
            SetDirty("Reembolsoetapaultimo_f_Z");
         }

      }

      public void gxTv_SdtReembolso_Reembolsoetapaultimo_f_Z_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsoetapaultimo_f_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Reembolsoetapaultimo_f_Z");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsoetapaultimo_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoStatusAtual_F_Z" )]
      [  XmlElement( ElementName = "ReembolsoStatusAtual_F_Z"   )]
      public string gxTpr_Reembolsostatusatual_f_Z
      {
         get {
            return gxTv_SdtReembolso_Reembolsostatusatual_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsostatusatual_f_Z = value;
            SetDirty("Reembolsostatusatual_f_Z");
         }

      }

      public void gxTv_SdtReembolso_Reembolsostatusatual_f_Z_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsostatusatual_f_Z = "";
         SetDirty("Reembolsostatusatual_f_Z");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsostatusatual_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WorkflowConvenioId_Z" )]
      [  XmlElement( ElementName = "WorkflowConvenioId_Z"   )]
      public int gxTpr_Workflowconvenioid_Z
      {
         get {
            return gxTv_SdtReembolso_Workflowconvenioid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolso_Workflowconvenioid_Z = value;
            SetDirty("Workflowconvenioid_Z");
         }

      }

      public void gxTv_SdtReembolso_Workflowconvenioid_Z_SetNull( )
      {
         gxTv_SdtReembolso_Workflowconvenioid_Z = 0;
         SetDirty("Workflowconvenioid_Z");
         return  ;
      }

      public bool gxTv_SdtReembolso_Workflowconvenioid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WorkflowConvenioDesc_Z" )]
      [  XmlElement( ElementName = "WorkflowConvenioDesc_Z"   )]
      public string gxTpr_Workflowconveniodesc_Z
      {
         get {
            return gxTv_SdtReembolso_Workflowconveniodesc_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolso_Workflowconveniodesc_Z = value;
            SetDirty("Workflowconveniodesc_Z");
         }

      }

      public void gxTv_SdtReembolso_Workflowconveniodesc_Z_SetNull( )
      {
         gxTv_SdtReembolso_Workflowconveniodesc_Z = "";
         SetDirty("Workflowconveniodesc_Z");
         return  ;
      }

      public bool gxTv_SdtReembolso_Workflowconveniodesc_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoId_N" )]
      [  XmlElement( ElementName = "ReembolsoId_N"   )]
      public short gxTpr_Reembolsoid_N
      {
         get {
            return gxTv_SdtReembolso_Reembolsoid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsoid_N = value;
            SetDirty("Reembolsoid_N");
         }

      }

      public void gxTv_SdtReembolso_Reembolsoid_N_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsoid_N = 0;
         SetDirty("Reembolsoid_N");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsoid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoPropostaId_N" )]
      [  XmlElement( ElementName = "ReembolsoPropostaId_N"   )]
      public short gxTpr_Reembolsopropostaid_N
      {
         get {
            return gxTv_SdtReembolso_Reembolsopropostaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsopropostaid_N = value;
            SetDirty("Reembolsopropostaid_N");
         }

      }

      public void gxTv_SdtReembolso_Reembolsopropostaid_N_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsopropostaid_N = 0;
         SetDirty("Reembolsopropostaid_N");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsopropostaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoPropostaPacienteClienteRazaoSocial_N" )]
      [  XmlElement( ElementName = "ReembolsoPropostaPacienteClienteRazaoSocial_N"   )]
      public short gxTpr_Reembolsopropostapacienteclienterazaosocial_N
      {
         get {
            return gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial_N = value;
            SetDirty("Reembolsopropostapacienteclienterazaosocial_N");
         }

      }

      public void gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial_N_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial_N = 0;
         SetDirty("Reembolsopropostapacienteclienterazaosocial_N");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoPropostaPacienteClienteId_N" )]
      [  XmlElement( ElementName = "ReembolsoPropostaPacienteClienteId_N"   )]
      public short gxTpr_Reembolsopropostapacienteclienteid_N
      {
         get {
            return gxTv_SdtReembolso_Reembolsopropostapacienteclienteid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsopropostapacienteclienteid_N = value;
            SetDirty("Reembolsopropostapacienteclienteid_N");
         }

      }

      public void gxTv_SdtReembolso_Reembolsopropostapacienteclienteid_N_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsopropostapacienteclienteid_N = 0;
         SetDirty("Reembolsopropostapacienteclienteid_N");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsopropostapacienteclienteid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoPropostaClinicaId_N" )]
      [  XmlElement( ElementName = "ReembolsoPropostaClinicaId_N"   )]
      public short gxTpr_Reembolsopropostaclinicaid_N
      {
         get {
            return gxTv_SdtReembolso_Reembolsopropostaclinicaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsopropostaclinicaid_N = value;
            SetDirty("Reembolsopropostaclinicaid_N");
         }

      }

      public void gxTv_SdtReembolso_Reembolsopropostaclinicaid_N_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsopropostaclinicaid_N = 0;
         SetDirty("Reembolsopropostaclinicaid_N");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsopropostaclinicaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoProtocolo_N" )]
      [  XmlElement( ElementName = "ReembolsoProtocolo_N"   )]
      public short gxTpr_Reembolsoprotocolo_N
      {
         get {
            return gxTv_SdtReembolso_Reembolsoprotocolo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsoprotocolo_N = value;
            SetDirty("Reembolsoprotocolo_N");
         }

      }

      public void gxTv_SdtReembolso_Reembolsoprotocolo_N_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsoprotocolo_N = 0;
         SetDirty("Reembolsoprotocolo_N");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsoprotocolo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoValorReembolsado_F_N" )]
      [  XmlElement( ElementName = "ReembolsoValorReembolsado_F_N"   )]
      public short gxTpr_Reembolsovalorreembolsado_f_N
      {
         get {
            return gxTv_SdtReembolso_Reembolsovalorreembolsado_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsovalorreembolsado_f_N = value;
            SetDirty("Reembolsovalorreembolsado_f_N");
         }

      }

      public void gxTv_SdtReembolso_Reembolsovalorreembolsado_f_N_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsovalorreembolsado_f_N = 0;
         SetDirty("Reembolsovalorreembolsado_f_N");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsovalorreembolsado_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoCreatedAt_N" )]
      [  XmlElement( ElementName = "ReembolsoCreatedAt_N"   )]
      public short gxTpr_Reembolsocreatedat_N
      {
         get {
            return gxTv_SdtReembolso_Reembolsocreatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsocreatedat_N = value;
            SetDirty("Reembolsocreatedat_N");
         }

      }

      public void gxTv_SdtReembolso_Reembolsocreatedat_N_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsocreatedat_N = 0;
         SetDirty("Reembolsocreatedat_N");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsocreatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoPropostaValor_N" )]
      [  XmlElement( ElementName = "ReembolsoPropostaValor_N"   )]
      public short gxTpr_Reembolsopropostavalor_N
      {
         get {
            return gxTv_SdtReembolso_Reembolsopropostavalor_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsopropostavalor_N = value;
            SetDirty("Reembolsopropostavalor_N");
         }

      }

      public void gxTv_SdtReembolso_Reembolsopropostavalor_N_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsopropostavalor_N = 0;
         SetDirty("Reembolsopropostavalor_N");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsopropostavalor_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoDataAberturaConvenio_N" )]
      [  XmlElement( ElementName = "ReembolsoDataAberturaConvenio_N"   )]
      public short gxTpr_Reembolsodataaberturaconvenio_N
      {
         get {
            return gxTv_SdtReembolso_Reembolsodataaberturaconvenio_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsodataaberturaconvenio_N = value;
            SetDirty("Reembolsodataaberturaconvenio_N");
         }

      }

      public void gxTv_SdtReembolso_Reembolsodataaberturaconvenio_N_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsodataaberturaconvenio_N = 0;
         SetDirty("Reembolsodataaberturaconvenio_N");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsodataaberturaconvenio_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoCreatedBy_N" )]
      [  XmlElement( ElementName = "ReembolsoCreatedBy_N"   )]
      public short gxTpr_Reembolsocreatedby_N
      {
         get {
            return gxTv_SdtReembolso_Reembolsocreatedby_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsocreatedby_N = value;
            SetDirty("Reembolsocreatedby_N");
         }

      }

      public void gxTv_SdtReembolso_Reembolsocreatedby_N_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsocreatedby_N = 0;
         SetDirty("Reembolsocreatedby_N");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsocreatedby_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoEtapaUltimo_F_N" )]
      [  XmlElement( ElementName = "ReembolsoEtapaUltimo_F_N"   )]
      public short gxTpr_Reembolsoetapaultimo_f_N
      {
         get {
            return gxTv_SdtReembolso_Reembolsoetapaultimo_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsoetapaultimo_f_N = value;
            SetDirty("Reembolsoetapaultimo_f_N");
         }

      }

      public void gxTv_SdtReembolso_Reembolsoetapaultimo_f_N_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsoetapaultimo_f_N = 0;
         SetDirty("Reembolsoetapaultimo_f_N");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsoetapaultimo_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoStatusAtual_F_N" )]
      [  XmlElement( ElementName = "ReembolsoStatusAtual_F_N"   )]
      public short gxTpr_Reembolsostatusatual_f_N
      {
         get {
            return gxTv_SdtReembolso_Reembolsostatusatual_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolso_Reembolsostatusatual_f_N = value;
            SetDirty("Reembolsostatusatual_f_N");
         }

      }

      public void gxTv_SdtReembolso_Reembolsostatusatual_f_N_SetNull( )
      {
         gxTv_SdtReembolso_Reembolsostatusatual_f_N = 0;
         SetDirty("Reembolsostatusatual_f_N");
         return  ;
      }

      public bool gxTv_SdtReembolso_Reembolsostatusatual_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WorkflowConvenioId_N" )]
      [  XmlElement( ElementName = "WorkflowConvenioId_N"   )]
      public short gxTpr_Workflowconvenioid_N
      {
         get {
            return gxTv_SdtReembolso_Workflowconvenioid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolso_Workflowconvenioid_N = value;
            SetDirty("Workflowconvenioid_N");
         }

      }

      public void gxTv_SdtReembolso_Workflowconvenioid_N_SetNull( )
      {
         gxTv_SdtReembolso_Workflowconvenioid_N = 0;
         SetDirty("Workflowconvenioid_N");
         return  ;
      }

      public bool gxTv_SdtReembolso_Workflowconvenioid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WorkflowConvenioDesc_N" )]
      [  XmlElement( ElementName = "WorkflowConvenioDesc_N"   )]
      public short gxTpr_Workflowconveniodesc_N
      {
         get {
            return gxTv_SdtReembolso_Workflowconveniodesc_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtReembolso_Workflowconveniodesc_N = value;
            SetDirty("Workflowconveniodesc_N");
         }

      }

      public void gxTv_SdtReembolso_Workflowconveniodesc_N_SetNull( )
      {
         gxTv_SdtReembolso_Workflowconveniodesc_N = 0;
         SetDirty("Workflowconveniodesc_N");
         return  ;
      }

      public bool gxTv_SdtReembolso_Workflowconveniodesc_N_IsNull( )
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
         gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial = "";
         gxTv_SdtReembolso_Reembolsoprotocolo = "";
         gxTv_SdtReembolso_Reembolsocreatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtReembolso_Reembolsodataaberturaconvenio = DateTime.MinValue;
         gxTv_SdtReembolso_Reembolsoetapaultimo_f = (DateTime)(DateTime.MinValue);
         gxTv_SdtReembolso_Reembolsostatusatual_f = "";
         gxTv_SdtReembolso_Workflowconveniodesc = "";
         gxTv_SdtReembolso_Mode = "";
         gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial_Z = "";
         gxTv_SdtReembolso_Reembolsoprotocolo_Z = "";
         gxTv_SdtReembolso_Reembolsocreatedat_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtReembolso_Reembolsodataaberturaconvenio_Z = DateTime.MinValue;
         gxTv_SdtReembolso_Reembolsoetapaultimo_f_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtReembolso_Reembolsostatusatual_f_Z = "";
         gxTv_SdtReembolso_Workflowconveniodesc_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "reembolso", "GeneXus.Programs.reembolso_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtReembolso_Reembolsocreatedby ;
      private short gxTv_SdtReembolso_Initialized ;
      private short gxTv_SdtReembolso_Reembolsocreatedby_Z ;
      private short gxTv_SdtReembolso_Reembolsoid_N ;
      private short gxTv_SdtReembolso_Reembolsopropostaid_N ;
      private short gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial_N ;
      private short gxTv_SdtReembolso_Reembolsopropostapacienteclienteid_N ;
      private short gxTv_SdtReembolso_Reembolsopropostaclinicaid_N ;
      private short gxTv_SdtReembolso_Reembolsoprotocolo_N ;
      private short gxTv_SdtReembolso_Reembolsovalorreembolsado_f_N ;
      private short gxTv_SdtReembolso_Reembolsocreatedat_N ;
      private short gxTv_SdtReembolso_Reembolsopropostavalor_N ;
      private short gxTv_SdtReembolso_Reembolsodataaberturaconvenio_N ;
      private short gxTv_SdtReembolso_Reembolsocreatedby_N ;
      private short gxTv_SdtReembolso_Reembolsoetapaultimo_f_N ;
      private short gxTv_SdtReembolso_Reembolsostatusatual_f_N ;
      private short gxTv_SdtReembolso_Workflowconvenioid_N ;
      private short gxTv_SdtReembolso_Workflowconveniodesc_N ;
      private int gxTv_SdtReembolso_Reembolsoid ;
      private int gxTv_SdtReembolso_Reembolsopropostaid ;
      private int gxTv_SdtReembolso_Reembolsopropostapacienteclienteid ;
      private int gxTv_SdtReembolso_Reembolsopropostaclinicaid ;
      private int gxTv_SdtReembolso_Workflowconvenioid ;
      private int gxTv_SdtReembolso_Reembolsoid_Z ;
      private int gxTv_SdtReembolso_Reembolsopropostaid_Z ;
      private int gxTv_SdtReembolso_Reembolsopropostapacienteclienteid_Z ;
      private int gxTv_SdtReembolso_Reembolsopropostaclinicaid_Z ;
      private int gxTv_SdtReembolso_Workflowconvenioid_Z ;
      private decimal gxTv_SdtReembolso_Reembolsovalorreembolsado_f ;
      private decimal gxTv_SdtReembolso_Reembolsopropostavalor ;
      private decimal gxTv_SdtReembolso_Reembolsovalorreembolsado_f_Z ;
      private decimal gxTv_SdtReembolso_Reembolsopropostavalor_Z ;
      private string gxTv_SdtReembolso_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtReembolso_Reembolsocreatedat ;
      private DateTime gxTv_SdtReembolso_Reembolsoetapaultimo_f ;
      private DateTime gxTv_SdtReembolso_Reembolsocreatedat_Z ;
      private DateTime gxTv_SdtReembolso_Reembolsoetapaultimo_f_Z ;
      private DateTime datetime_STZ ;
      private DateTime gxTv_SdtReembolso_Reembolsodataaberturaconvenio ;
      private DateTime gxTv_SdtReembolso_Reembolsodataaberturaconvenio_Z ;
      private string gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial ;
      private string gxTv_SdtReembolso_Reembolsoprotocolo ;
      private string gxTv_SdtReembolso_Reembolsostatusatual_f ;
      private string gxTv_SdtReembolso_Workflowconveniodesc ;
      private string gxTv_SdtReembolso_Reembolsopropostapacienteclienterazaosocial_Z ;
      private string gxTv_SdtReembolso_Reembolsoprotocolo_Z ;
      private string gxTv_SdtReembolso_Reembolsostatusatual_f_Z ;
      private string gxTv_SdtReembolso_Workflowconveniodesc_Z ;
   }

   [DataContract(Name = @"Reembolso", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtReembolso_RESTInterface : GxGenericCollectionItem<SdtReembolso>
   {
      public SdtReembolso_RESTInterface( ) : base()
      {
      }

      public SdtReembolso_RESTInterface( SdtReembolso psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ReembolsoId" , Order = 0 )]
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

      [DataMember( Name = "ReembolsoPropostaId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Reembolsopropostaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Reembolsopropostaid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Reembolsopropostaid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ReembolsoPropostaPacienteClienteRazaoSocial" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Reembolsopropostapacienteclienterazaosocial
      {
         get {
            return sdt.gxTpr_Reembolsopropostapacienteclienterazaosocial ;
         }

         set {
            sdt.gxTpr_Reembolsopropostapacienteclienterazaosocial = value;
         }

      }

      [DataMember( Name = "ReembolsoPropostaPacienteClienteId" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Reembolsopropostapacienteclienteid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Reembolsopropostapacienteclienteid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Reembolsopropostapacienteclienteid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ReembolsoPropostaClinicaId" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Reembolsopropostaclinicaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Reembolsopropostaclinicaid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Reembolsopropostaclinicaid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ReembolsoProtocolo" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Reembolsoprotocolo
      {
         get {
            return sdt.gxTpr_Reembolsoprotocolo ;
         }

         set {
            sdt.gxTpr_Reembolsoprotocolo = value;
         }

      }

      [DataMember( Name = "ReembolsoValorReembolsado_F" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Reembolsovalorreembolsado_f
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Reembolsovalorreembolsado_f, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Reembolsovalorreembolsado_f = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ReembolsoCreatedAt" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Reembolsocreatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Reembolsocreatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Reembolsocreatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "ReembolsoPropostaValor" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Reembolsopropostavalor
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Reembolsopropostavalor, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Reembolsopropostavalor = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ReembolsoDataAberturaConvenio" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Reembolsodataaberturaconvenio
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Reembolsodataaberturaconvenio) ;
         }

         set {
            sdt.gxTpr_Reembolsodataaberturaconvenio = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "ReembolsoCreatedBy" , Order = 10 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Reembolsocreatedby
      {
         get {
            return sdt.gxTpr_Reembolsocreatedby ;
         }

         set {
            sdt.gxTpr_Reembolsocreatedby = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ReembolsoEtapaUltimo_F" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Reembolsoetapaultimo_f
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Reembolsoetapaultimo_f, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Reembolsoetapaultimo_f = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "ReembolsoStatusAtual_F" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Reembolsostatusatual_f
      {
         get {
            return sdt.gxTpr_Reembolsostatusatual_f ;
         }

         set {
            sdt.gxTpr_Reembolsostatusatual_f = value;
         }

      }

      [DataMember( Name = "WorkflowConvenioId" , Order = 13 )]
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

      [DataMember( Name = "WorkflowConvenioDesc" , Order = 14 )]
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

      public SdtReembolso sdt
      {
         get {
            return (SdtReembolso)Sdt ;
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
            sdt = new SdtReembolso() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 15 )]
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

   [DataContract(Name = @"Reembolso", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtReembolso_RESTLInterface : GxGenericCollectionItem<SdtReembolso>
   {
      public SdtReembolso_RESTLInterface( ) : base()
      {
      }

      public SdtReembolso_RESTLInterface( SdtReembolso psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ReembolsoPropostaPacienteClienteRazaoSocial" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Reembolsopropostapacienteclienterazaosocial
      {
         get {
            return sdt.gxTpr_Reembolsopropostapacienteclienterazaosocial ;
         }

         set {
            sdt.gxTpr_Reembolsopropostapacienteclienterazaosocial = value;
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

      public SdtReembolso sdt
      {
         get {
            return (SdtReembolso)Sdt ;
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
            sdt = new SdtReembolso() ;
         }
      }

   }

}
