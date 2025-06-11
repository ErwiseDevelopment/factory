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
   [XmlRoot(ElementName = "PropostaContrato" )]
   [XmlType(TypeName =  "PropostaContrato" , Namespace = "Factory21" )]
   [Serializable]
   public class SdtPropostaContrato : GxSilentTrnSdt
   {
      public SdtPropostaContrato( )
      {
      }

      public SdtPropostaContrato( IGxContext context )
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

      public void Load( int AV323PropostaId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(int)AV323PropostaId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"PropostaId", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "PropostaContrato");
         metadata.Set("BT", "Proposta");
         metadata.Set("PK", "[ \"PropostaId\" ]");
         metadata.Set("PKAssigned", "[ \"PropostaId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ClienteId\" ],\"FKMap\":[ \"PropostaPacienteClienteId-ClienteId\" ] },{ \"FK\":[ \"ContratoId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ProcedimentosMedicosId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"SecUserId\" ],\"FKMap\":[ \"PropostaCratedBy-SecUserId\" ] } ]");
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
         state.Add("gxTpr_Propostaid_Z");
         state.Add("gxTpr_Propostatitulo_Z");
         state.Add("gxTpr_Procedimentosmedicosid_Z");
         state.Add("gxTpr_Propostadescricao_Z");
         state.Add("gxTpr_Propostavalor_Z");
         state.Add("gxTpr_Propostacreatedat_Z_Nullable");
         state.Add("gxTpr_Propostacratedby_Z");
         state.Add("gxTpr_Propostastatus_Z");
         state.Add("gxTpr_Contratoid_Z");
         state.Add("gxTpr_Contratonome_Z");
         state.Add("gxTpr_Propostaquantidadeaprovadores_Z");
         state.Add("gxTpr_Propostareprovacoespermitidas_Z");
         state.Add("gxTpr_Propostaaprovacoes_f_Z");
         state.Add("gxTpr_Propostareprovacoes_f_Z");
         state.Add("gxTpr_Propostaaprovacoesrestantes_f_Z");
         state.Add("gxTpr_Propostapacienteclienteid_Z");
         state.Add("gxTpr_Propostapacienteclienterazaosocial_Z");
         state.Add("gxTpr_Reembolsostatusatual_f_Z");
         state.Add("gxTpr_Workflowpasso_f_Z");
         state.Add("gxTpr_Propostaid_N");
         state.Add("gxTpr_Propostatitulo_N");
         state.Add("gxTpr_Procedimentosmedicosid_N");
         state.Add("gxTpr_Propostadescricao_N");
         state.Add("gxTpr_Propostavalor_N");
         state.Add("gxTpr_Propostacreatedat_N");
         state.Add("gxTpr_Propostacratedby_N");
         state.Add("gxTpr_Propostastatus_N");
         state.Add("gxTpr_Contratoid_N");
         state.Add("gxTpr_Contratonome_N");
         state.Add("gxTpr_Propostaquantidadeaprovadores_N");
         state.Add("gxTpr_Propostareprovacoespermitidas_N");
         state.Add("gxTpr_Propostaaprovacoes_f_N");
         state.Add("gxTpr_Propostareprovacoes_f_N");
         state.Add("gxTpr_Propostapacienteclienteid_N");
         state.Add("gxTpr_Propostapacienteclienterazaosocial_N");
         state.Add("gxTpr_Reembolsostatusatual_f_N");
         state.Add("gxTpr_Workflowpasso_f_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtPropostaContrato sdt;
         sdt = (SdtPropostaContrato)(source);
         gxTv_SdtPropostaContrato_Propostaid = sdt.gxTv_SdtPropostaContrato_Propostaid ;
         gxTv_SdtPropostaContrato_Propostatitulo = sdt.gxTv_SdtPropostaContrato_Propostatitulo ;
         gxTv_SdtPropostaContrato_Procedimentosmedicosid = sdt.gxTv_SdtPropostaContrato_Procedimentosmedicosid ;
         gxTv_SdtPropostaContrato_Propostadescricao = sdt.gxTv_SdtPropostaContrato_Propostadescricao ;
         gxTv_SdtPropostaContrato_Propostavalor = sdt.gxTv_SdtPropostaContrato_Propostavalor ;
         gxTv_SdtPropostaContrato_Propostacreatedat = sdt.gxTv_SdtPropostaContrato_Propostacreatedat ;
         gxTv_SdtPropostaContrato_Propostacratedby = sdt.gxTv_SdtPropostaContrato_Propostacratedby ;
         gxTv_SdtPropostaContrato_Propostastatus = sdt.gxTv_SdtPropostaContrato_Propostastatus ;
         gxTv_SdtPropostaContrato_Contratoid = sdt.gxTv_SdtPropostaContrato_Contratoid ;
         gxTv_SdtPropostaContrato_Contratonome = sdt.gxTv_SdtPropostaContrato_Contratonome ;
         gxTv_SdtPropostaContrato_Propostaquantidadeaprovadores = sdt.gxTv_SdtPropostaContrato_Propostaquantidadeaprovadores ;
         gxTv_SdtPropostaContrato_Propostareprovacoespermitidas = sdt.gxTv_SdtPropostaContrato_Propostareprovacoespermitidas ;
         gxTv_SdtPropostaContrato_Propostaaprovacoes_f = sdt.gxTv_SdtPropostaContrato_Propostaaprovacoes_f ;
         gxTv_SdtPropostaContrato_Propostareprovacoes_f = sdt.gxTv_SdtPropostaContrato_Propostareprovacoes_f ;
         gxTv_SdtPropostaContrato_Propostaaprovacoesrestantes_f = sdt.gxTv_SdtPropostaContrato_Propostaaprovacoesrestantes_f ;
         gxTv_SdtPropostaContrato_Propostapacienteclienteid = sdt.gxTv_SdtPropostaContrato_Propostapacienteclienteid ;
         gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial = sdt.gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial ;
         gxTv_SdtPropostaContrato_Reembolsostatusatual_f = sdt.gxTv_SdtPropostaContrato_Reembolsostatusatual_f ;
         gxTv_SdtPropostaContrato_Workflowpasso_f = sdt.gxTv_SdtPropostaContrato_Workflowpasso_f ;
         gxTv_SdtPropostaContrato_Mode = sdt.gxTv_SdtPropostaContrato_Mode ;
         gxTv_SdtPropostaContrato_Initialized = sdt.gxTv_SdtPropostaContrato_Initialized ;
         gxTv_SdtPropostaContrato_Propostaid_Z = sdt.gxTv_SdtPropostaContrato_Propostaid_Z ;
         gxTv_SdtPropostaContrato_Propostatitulo_Z = sdt.gxTv_SdtPropostaContrato_Propostatitulo_Z ;
         gxTv_SdtPropostaContrato_Procedimentosmedicosid_Z = sdt.gxTv_SdtPropostaContrato_Procedimentosmedicosid_Z ;
         gxTv_SdtPropostaContrato_Propostadescricao_Z = sdt.gxTv_SdtPropostaContrato_Propostadescricao_Z ;
         gxTv_SdtPropostaContrato_Propostavalor_Z = sdt.gxTv_SdtPropostaContrato_Propostavalor_Z ;
         gxTv_SdtPropostaContrato_Propostacreatedat_Z = sdt.gxTv_SdtPropostaContrato_Propostacreatedat_Z ;
         gxTv_SdtPropostaContrato_Propostacratedby_Z = sdt.gxTv_SdtPropostaContrato_Propostacratedby_Z ;
         gxTv_SdtPropostaContrato_Propostastatus_Z = sdt.gxTv_SdtPropostaContrato_Propostastatus_Z ;
         gxTv_SdtPropostaContrato_Contratoid_Z = sdt.gxTv_SdtPropostaContrato_Contratoid_Z ;
         gxTv_SdtPropostaContrato_Contratonome_Z = sdt.gxTv_SdtPropostaContrato_Contratonome_Z ;
         gxTv_SdtPropostaContrato_Propostaquantidadeaprovadores_Z = sdt.gxTv_SdtPropostaContrato_Propostaquantidadeaprovadores_Z ;
         gxTv_SdtPropostaContrato_Propostareprovacoespermitidas_Z = sdt.gxTv_SdtPropostaContrato_Propostareprovacoespermitidas_Z ;
         gxTv_SdtPropostaContrato_Propostaaprovacoes_f_Z = sdt.gxTv_SdtPropostaContrato_Propostaaprovacoes_f_Z ;
         gxTv_SdtPropostaContrato_Propostareprovacoes_f_Z = sdt.gxTv_SdtPropostaContrato_Propostareprovacoes_f_Z ;
         gxTv_SdtPropostaContrato_Propostaaprovacoesrestantes_f_Z = sdt.gxTv_SdtPropostaContrato_Propostaaprovacoesrestantes_f_Z ;
         gxTv_SdtPropostaContrato_Propostapacienteclienteid_Z = sdt.gxTv_SdtPropostaContrato_Propostapacienteclienteid_Z ;
         gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial_Z = sdt.gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial_Z ;
         gxTv_SdtPropostaContrato_Reembolsostatusatual_f_Z = sdt.gxTv_SdtPropostaContrato_Reembolsostatusatual_f_Z ;
         gxTv_SdtPropostaContrato_Workflowpasso_f_Z = sdt.gxTv_SdtPropostaContrato_Workflowpasso_f_Z ;
         gxTv_SdtPropostaContrato_Propostaid_N = sdt.gxTv_SdtPropostaContrato_Propostaid_N ;
         gxTv_SdtPropostaContrato_Propostatitulo_N = sdt.gxTv_SdtPropostaContrato_Propostatitulo_N ;
         gxTv_SdtPropostaContrato_Procedimentosmedicosid_N = sdt.gxTv_SdtPropostaContrato_Procedimentosmedicosid_N ;
         gxTv_SdtPropostaContrato_Propostadescricao_N = sdt.gxTv_SdtPropostaContrato_Propostadescricao_N ;
         gxTv_SdtPropostaContrato_Propostavalor_N = sdt.gxTv_SdtPropostaContrato_Propostavalor_N ;
         gxTv_SdtPropostaContrato_Propostacreatedat_N = sdt.gxTv_SdtPropostaContrato_Propostacreatedat_N ;
         gxTv_SdtPropostaContrato_Propostacratedby_N = sdt.gxTv_SdtPropostaContrato_Propostacratedby_N ;
         gxTv_SdtPropostaContrato_Propostastatus_N = sdt.gxTv_SdtPropostaContrato_Propostastatus_N ;
         gxTv_SdtPropostaContrato_Contratoid_N = sdt.gxTv_SdtPropostaContrato_Contratoid_N ;
         gxTv_SdtPropostaContrato_Contratonome_N = sdt.gxTv_SdtPropostaContrato_Contratonome_N ;
         gxTv_SdtPropostaContrato_Propostaquantidadeaprovadores_N = sdt.gxTv_SdtPropostaContrato_Propostaquantidadeaprovadores_N ;
         gxTv_SdtPropostaContrato_Propostareprovacoespermitidas_N = sdt.gxTv_SdtPropostaContrato_Propostareprovacoespermitidas_N ;
         gxTv_SdtPropostaContrato_Propostaaprovacoes_f_N = sdt.gxTv_SdtPropostaContrato_Propostaaprovacoes_f_N ;
         gxTv_SdtPropostaContrato_Propostareprovacoes_f_N = sdt.gxTv_SdtPropostaContrato_Propostareprovacoes_f_N ;
         gxTv_SdtPropostaContrato_Propostapacienteclienteid_N = sdt.gxTv_SdtPropostaContrato_Propostapacienteclienteid_N ;
         gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial_N = sdt.gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial_N ;
         gxTv_SdtPropostaContrato_Reembolsostatusatual_f_N = sdt.gxTv_SdtPropostaContrato_Reembolsostatusatual_f_N ;
         gxTv_SdtPropostaContrato_Workflowpasso_f_N = sdt.gxTv_SdtPropostaContrato_Workflowpasso_f_N ;
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
         AddObjectProperty("PropostaId", gxTv_SdtPropostaContrato_Propostaid, false, includeNonInitialized);
         AddObjectProperty("PropostaId_N", gxTv_SdtPropostaContrato_Propostaid_N, false, includeNonInitialized);
         AddObjectProperty("PropostaTitulo", gxTv_SdtPropostaContrato_Propostatitulo, false, includeNonInitialized);
         AddObjectProperty("PropostaTitulo_N", gxTv_SdtPropostaContrato_Propostatitulo_N, false, includeNonInitialized);
         AddObjectProperty("ProcedimentosMedicosId", gxTv_SdtPropostaContrato_Procedimentosmedicosid, false, includeNonInitialized);
         AddObjectProperty("ProcedimentosMedicosId_N", gxTv_SdtPropostaContrato_Procedimentosmedicosid_N, false, includeNonInitialized);
         AddObjectProperty("PropostaDescricao", gxTv_SdtPropostaContrato_Propostadescricao, false, includeNonInitialized);
         AddObjectProperty("PropostaDescricao_N", gxTv_SdtPropostaContrato_Propostadescricao_N, false, includeNonInitialized);
         AddObjectProperty("PropostaValor", StringUtil.LTrim( StringUtil.Str( gxTv_SdtPropostaContrato_Propostavalor, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("PropostaValor_N", gxTv_SdtPropostaContrato_Propostavalor_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtPropostaContrato_Propostacreatedat;
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
         AddObjectProperty("PropostaCreatedAt", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("PropostaCreatedAt_N", gxTv_SdtPropostaContrato_Propostacreatedat_N, false, includeNonInitialized);
         AddObjectProperty("PropostaCratedBy", gxTv_SdtPropostaContrato_Propostacratedby, false, includeNonInitialized);
         AddObjectProperty("PropostaCratedBy_N", gxTv_SdtPropostaContrato_Propostacratedby_N, false, includeNonInitialized);
         AddObjectProperty("PropostaStatus", gxTv_SdtPropostaContrato_Propostastatus, false, includeNonInitialized);
         AddObjectProperty("PropostaStatus_N", gxTv_SdtPropostaContrato_Propostastatus_N, false, includeNonInitialized);
         AddObjectProperty("ContratoId", gxTv_SdtPropostaContrato_Contratoid, false, includeNonInitialized);
         AddObjectProperty("ContratoId_N", gxTv_SdtPropostaContrato_Contratoid_N, false, includeNonInitialized);
         AddObjectProperty("ContratoNome", gxTv_SdtPropostaContrato_Contratonome, false, includeNonInitialized);
         AddObjectProperty("ContratoNome_N", gxTv_SdtPropostaContrato_Contratonome_N, false, includeNonInitialized);
         AddObjectProperty("PropostaQuantidadeAprovadores", gxTv_SdtPropostaContrato_Propostaquantidadeaprovadores, false, includeNonInitialized);
         AddObjectProperty("PropostaQuantidadeAprovadores_N", gxTv_SdtPropostaContrato_Propostaquantidadeaprovadores_N, false, includeNonInitialized);
         AddObjectProperty("PropostaReprovacoesPermitidas", gxTv_SdtPropostaContrato_Propostareprovacoespermitidas, false, includeNonInitialized);
         AddObjectProperty("PropostaReprovacoesPermitidas_N", gxTv_SdtPropostaContrato_Propostareprovacoespermitidas_N, false, includeNonInitialized);
         AddObjectProperty("PropostaAprovacoes_F", gxTv_SdtPropostaContrato_Propostaaprovacoes_f, false, includeNonInitialized);
         AddObjectProperty("PropostaAprovacoes_F_N", gxTv_SdtPropostaContrato_Propostaaprovacoes_f_N, false, includeNonInitialized);
         AddObjectProperty("PropostaReprovacoes_F", gxTv_SdtPropostaContrato_Propostareprovacoes_f, false, includeNonInitialized);
         AddObjectProperty("PropostaReprovacoes_F_N", gxTv_SdtPropostaContrato_Propostareprovacoes_f_N, false, includeNonInitialized);
         AddObjectProperty("PropostaAprovacoesRestantes_F", gxTv_SdtPropostaContrato_Propostaaprovacoesrestantes_f, false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteClienteId", gxTv_SdtPropostaContrato_Propostapacienteclienteid, false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteClienteId_N", gxTv_SdtPropostaContrato_Propostapacienteclienteid_N, false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteClienteRazaoSocial", gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial, false, includeNonInitialized);
         AddObjectProperty("PropostaPacienteClienteRazaoSocial_N", gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial_N, false, includeNonInitialized);
         AddObjectProperty("ReembolsoStatusAtual_F", gxTv_SdtPropostaContrato_Reembolsostatusatual_f, false, includeNonInitialized);
         AddObjectProperty("ReembolsoStatusAtual_F_N", gxTv_SdtPropostaContrato_Reembolsostatusatual_f_N, false, includeNonInitialized);
         AddObjectProperty("WorkFlowPasso_F", gxTv_SdtPropostaContrato_Workflowpasso_f, false, includeNonInitialized);
         AddObjectProperty("WorkFlowPasso_F_N", gxTv_SdtPropostaContrato_Workflowpasso_f_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtPropostaContrato_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtPropostaContrato_Initialized, false, includeNonInitialized);
            AddObjectProperty("PropostaId_Z", gxTv_SdtPropostaContrato_Propostaid_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaTitulo_Z", gxTv_SdtPropostaContrato_Propostatitulo_Z, false, includeNonInitialized);
            AddObjectProperty("ProcedimentosMedicosId_Z", gxTv_SdtPropostaContrato_Procedimentosmedicosid_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaDescricao_Z", gxTv_SdtPropostaContrato_Propostadescricao_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaValor_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtPropostaContrato_Propostavalor_Z, 18, 2)), false, includeNonInitialized);
            datetime_STZ = gxTv_SdtPropostaContrato_Propostacreatedat_Z;
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
            AddObjectProperty("PropostaCreatedAt_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("PropostaCratedBy_Z", gxTv_SdtPropostaContrato_Propostacratedby_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaStatus_Z", gxTv_SdtPropostaContrato_Propostastatus_Z, false, includeNonInitialized);
            AddObjectProperty("ContratoId_Z", gxTv_SdtPropostaContrato_Contratoid_Z, false, includeNonInitialized);
            AddObjectProperty("ContratoNome_Z", gxTv_SdtPropostaContrato_Contratonome_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaQuantidadeAprovadores_Z", gxTv_SdtPropostaContrato_Propostaquantidadeaprovadores_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaReprovacoesPermitidas_Z", gxTv_SdtPropostaContrato_Propostareprovacoespermitidas_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaAprovacoes_F_Z", gxTv_SdtPropostaContrato_Propostaaprovacoes_f_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaReprovacoes_F_Z", gxTv_SdtPropostaContrato_Propostareprovacoes_f_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaAprovacoesRestantes_F_Z", gxTv_SdtPropostaContrato_Propostaaprovacoesrestantes_f_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteClienteId_Z", gxTv_SdtPropostaContrato_Propostapacienteclienteid_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteClienteRazaoSocial_Z", gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial_Z, false, includeNonInitialized);
            AddObjectProperty("ReembolsoStatusAtual_F_Z", gxTv_SdtPropostaContrato_Reembolsostatusatual_f_Z, false, includeNonInitialized);
            AddObjectProperty("WorkFlowPasso_F_Z", gxTv_SdtPropostaContrato_Workflowpasso_f_Z, false, includeNonInitialized);
            AddObjectProperty("PropostaId_N", gxTv_SdtPropostaContrato_Propostaid_N, false, includeNonInitialized);
            AddObjectProperty("PropostaTitulo_N", gxTv_SdtPropostaContrato_Propostatitulo_N, false, includeNonInitialized);
            AddObjectProperty("ProcedimentosMedicosId_N", gxTv_SdtPropostaContrato_Procedimentosmedicosid_N, false, includeNonInitialized);
            AddObjectProperty("PropostaDescricao_N", gxTv_SdtPropostaContrato_Propostadescricao_N, false, includeNonInitialized);
            AddObjectProperty("PropostaValor_N", gxTv_SdtPropostaContrato_Propostavalor_N, false, includeNonInitialized);
            AddObjectProperty("PropostaCreatedAt_N", gxTv_SdtPropostaContrato_Propostacreatedat_N, false, includeNonInitialized);
            AddObjectProperty("PropostaCratedBy_N", gxTv_SdtPropostaContrato_Propostacratedby_N, false, includeNonInitialized);
            AddObjectProperty("PropostaStatus_N", gxTv_SdtPropostaContrato_Propostastatus_N, false, includeNonInitialized);
            AddObjectProperty("ContratoId_N", gxTv_SdtPropostaContrato_Contratoid_N, false, includeNonInitialized);
            AddObjectProperty("ContratoNome_N", gxTv_SdtPropostaContrato_Contratonome_N, false, includeNonInitialized);
            AddObjectProperty("PropostaQuantidadeAprovadores_N", gxTv_SdtPropostaContrato_Propostaquantidadeaprovadores_N, false, includeNonInitialized);
            AddObjectProperty("PropostaReprovacoesPermitidas_N", gxTv_SdtPropostaContrato_Propostareprovacoespermitidas_N, false, includeNonInitialized);
            AddObjectProperty("PropostaAprovacoes_F_N", gxTv_SdtPropostaContrato_Propostaaprovacoes_f_N, false, includeNonInitialized);
            AddObjectProperty("PropostaReprovacoes_F_N", gxTv_SdtPropostaContrato_Propostareprovacoes_f_N, false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteClienteId_N", gxTv_SdtPropostaContrato_Propostapacienteclienteid_N, false, includeNonInitialized);
            AddObjectProperty("PropostaPacienteClienteRazaoSocial_N", gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial_N, false, includeNonInitialized);
            AddObjectProperty("ReembolsoStatusAtual_F_N", gxTv_SdtPropostaContrato_Reembolsostatusatual_f_N, false, includeNonInitialized);
            AddObjectProperty("WorkFlowPasso_F_N", gxTv_SdtPropostaContrato_Workflowpasso_f_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtPropostaContrato sdt )
      {
         if ( sdt.IsDirty("PropostaId") )
         {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostaid = sdt.gxTv_SdtPropostaContrato_Propostaid ;
         }
         if ( sdt.IsDirty("PropostaTitulo") )
         {
            gxTv_SdtPropostaContrato_Propostatitulo_N = (short)(sdt.gxTv_SdtPropostaContrato_Propostatitulo_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostatitulo = sdt.gxTv_SdtPropostaContrato_Propostatitulo ;
         }
         if ( sdt.IsDirty("ProcedimentosMedicosId") )
         {
            gxTv_SdtPropostaContrato_Procedimentosmedicosid_N = (short)(sdt.gxTv_SdtPropostaContrato_Procedimentosmedicosid_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Procedimentosmedicosid = sdt.gxTv_SdtPropostaContrato_Procedimentosmedicosid ;
         }
         if ( sdt.IsDirty("PropostaDescricao") )
         {
            gxTv_SdtPropostaContrato_Propostadescricao_N = (short)(sdt.gxTv_SdtPropostaContrato_Propostadescricao_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostadescricao = sdt.gxTv_SdtPropostaContrato_Propostadescricao ;
         }
         if ( sdt.IsDirty("PropostaValor") )
         {
            gxTv_SdtPropostaContrato_Propostavalor_N = (short)(sdt.gxTv_SdtPropostaContrato_Propostavalor_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostavalor = sdt.gxTv_SdtPropostaContrato_Propostavalor ;
         }
         if ( sdt.IsDirty("PropostaCreatedAt") )
         {
            gxTv_SdtPropostaContrato_Propostacreatedat_N = (short)(sdt.gxTv_SdtPropostaContrato_Propostacreatedat_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostacreatedat = sdt.gxTv_SdtPropostaContrato_Propostacreatedat ;
         }
         if ( sdt.IsDirty("PropostaCratedBy") )
         {
            gxTv_SdtPropostaContrato_Propostacratedby_N = (short)(sdt.gxTv_SdtPropostaContrato_Propostacratedby_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostacratedby = sdt.gxTv_SdtPropostaContrato_Propostacratedby ;
         }
         if ( sdt.IsDirty("PropostaStatus") )
         {
            gxTv_SdtPropostaContrato_Propostastatus_N = (short)(sdt.gxTv_SdtPropostaContrato_Propostastatus_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostastatus = sdt.gxTv_SdtPropostaContrato_Propostastatus ;
         }
         if ( sdt.IsDirty("ContratoId") )
         {
            gxTv_SdtPropostaContrato_Contratoid_N = (short)(sdt.gxTv_SdtPropostaContrato_Contratoid_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Contratoid = sdt.gxTv_SdtPropostaContrato_Contratoid ;
         }
         if ( sdt.IsDirty("ContratoNome") )
         {
            gxTv_SdtPropostaContrato_Contratonome_N = (short)(sdt.gxTv_SdtPropostaContrato_Contratonome_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Contratonome = sdt.gxTv_SdtPropostaContrato_Contratonome ;
         }
         if ( sdt.IsDirty("PropostaQuantidadeAprovadores") )
         {
            gxTv_SdtPropostaContrato_Propostaquantidadeaprovadores_N = (short)(sdt.gxTv_SdtPropostaContrato_Propostaquantidadeaprovadores_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostaquantidadeaprovadores = sdt.gxTv_SdtPropostaContrato_Propostaquantidadeaprovadores ;
         }
         if ( sdt.IsDirty("PropostaReprovacoesPermitidas") )
         {
            gxTv_SdtPropostaContrato_Propostareprovacoespermitidas_N = (short)(sdt.gxTv_SdtPropostaContrato_Propostareprovacoespermitidas_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostareprovacoespermitidas = sdt.gxTv_SdtPropostaContrato_Propostareprovacoespermitidas ;
         }
         if ( sdt.IsDirty("PropostaAprovacoes_F") )
         {
            gxTv_SdtPropostaContrato_Propostaaprovacoes_f_N = (short)(sdt.gxTv_SdtPropostaContrato_Propostaaprovacoes_f_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostaaprovacoes_f = sdt.gxTv_SdtPropostaContrato_Propostaaprovacoes_f ;
         }
         if ( sdt.IsDirty("PropostaReprovacoes_F") )
         {
            gxTv_SdtPropostaContrato_Propostareprovacoes_f_N = (short)(sdt.gxTv_SdtPropostaContrato_Propostareprovacoes_f_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostareprovacoes_f = sdt.gxTv_SdtPropostaContrato_Propostareprovacoes_f ;
         }
         if ( sdt.IsDirty("PropostaAprovacoesRestantes_F") )
         {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostaaprovacoesrestantes_f = sdt.gxTv_SdtPropostaContrato_Propostaaprovacoesrestantes_f ;
         }
         if ( sdt.IsDirty("PropostaPacienteClienteId") )
         {
            gxTv_SdtPropostaContrato_Propostapacienteclienteid_N = (short)(sdt.gxTv_SdtPropostaContrato_Propostapacienteclienteid_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostapacienteclienteid = sdt.gxTv_SdtPropostaContrato_Propostapacienteclienteid ;
         }
         if ( sdt.IsDirty("PropostaPacienteClienteRazaoSocial") )
         {
            gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial_N = (short)(sdt.gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial = sdt.gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial ;
         }
         if ( sdt.IsDirty("ReembolsoStatusAtual_F") )
         {
            gxTv_SdtPropostaContrato_Reembolsostatusatual_f_N = (short)(sdt.gxTv_SdtPropostaContrato_Reembolsostatusatual_f_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Reembolsostatusatual_f = sdt.gxTv_SdtPropostaContrato_Reembolsostatusatual_f ;
         }
         if ( sdt.IsDirty("WorkFlowPasso_F") )
         {
            gxTv_SdtPropostaContrato_Workflowpasso_f_N = (short)(sdt.gxTv_SdtPropostaContrato_Workflowpasso_f_N);
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Workflowpasso_f = sdt.gxTv_SdtPropostaContrato_Workflowpasso_f ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "PropostaId" )]
      [  XmlElement( ElementName = "PropostaId"   )]
      public int gxTpr_Propostaid
      {
         get {
            return gxTv_SdtPropostaContrato_Propostaid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtPropostaContrato_Propostaid != value )
            {
               gxTv_SdtPropostaContrato_Mode = "INS";
               this.gxTv_SdtPropostaContrato_Propostaid_Z_SetNull( );
               this.gxTv_SdtPropostaContrato_Propostatitulo_Z_SetNull( );
               this.gxTv_SdtPropostaContrato_Procedimentosmedicosid_Z_SetNull( );
               this.gxTv_SdtPropostaContrato_Propostadescricao_Z_SetNull( );
               this.gxTv_SdtPropostaContrato_Propostavalor_Z_SetNull( );
               this.gxTv_SdtPropostaContrato_Propostacreatedat_Z_SetNull( );
               this.gxTv_SdtPropostaContrato_Propostacratedby_Z_SetNull( );
               this.gxTv_SdtPropostaContrato_Propostastatus_Z_SetNull( );
               this.gxTv_SdtPropostaContrato_Contratoid_Z_SetNull( );
               this.gxTv_SdtPropostaContrato_Contratonome_Z_SetNull( );
               this.gxTv_SdtPropostaContrato_Propostaquantidadeaprovadores_Z_SetNull( );
               this.gxTv_SdtPropostaContrato_Propostareprovacoespermitidas_Z_SetNull( );
               this.gxTv_SdtPropostaContrato_Propostaaprovacoes_f_Z_SetNull( );
               this.gxTv_SdtPropostaContrato_Propostareprovacoes_f_Z_SetNull( );
               this.gxTv_SdtPropostaContrato_Propostaaprovacoesrestantes_f_Z_SetNull( );
               this.gxTv_SdtPropostaContrato_Propostapacienteclienteid_Z_SetNull( );
               this.gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial_Z_SetNull( );
               this.gxTv_SdtPropostaContrato_Reembolsostatusatual_f_Z_SetNull( );
               this.gxTv_SdtPropostaContrato_Workflowpasso_f_Z_SetNull( );
            }
            gxTv_SdtPropostaContrato_Propostaid = value;
            SetDirty("Propostaid");
         }

      }

      [  SoapElement( ElementName = "PropostaTitulo" )]
      [  XmlElement( ElementName = "PropostaTitulo"   )]
      public string gxTpr_Propostatitulo
      {
         get {
            return gxTv_SdtPropostaContrato_Propostatitulo ;
         }

         set {
            gxTv_SdtPropostaContrato_Propostatitulo_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostatitulo = value;
            SetDirty("Propostatitulo");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostatitulo_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostatitulo_N = 1;
         gxTv_SdtPropostaContrato_Propostatitulo = "";
         SetDirty("Propostatitulo");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostatitulo_IsNull( )
      {
         return (gxTv_SdtPropostaContrato_Propostatitulo_N==1) ;
      }

      [  SoapElement( ElementName = "ProcedimentosMedicosId" )]
      [  XmlElement( ElementName = "ProcedimentosMedicosId"   )]
      public int gxTpr_Procedimentosmedicosid
      {
         get {
            return gxTv_SdtPropostaContrato_Procedimentosmedicosid ;
         }

         set {
            gxTv_SdtPropostaContrato_Procedimentosmedicosid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Procedimentosmedicosid = value;
            SetDirty("Procedimentosmedicosid");
         }

      }

      public void gxTv_SdtPropostaContrato_Procedimentosmedicosid_SetNull( )
      {
         gxTv_SdtPropostaContrato_Procedimentosmedicosid_N = 1;
         gxTv_SdtPropostaContrato_Procedimentosmedicosid = 0;
         SetDirty("Procedimentosmedicosid");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Procedimentosmedicosid_IsNull( )
      {
         return (gxTv_SdtPropostaContrato_Procedimentosmedicosid_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaDescricao" )]
      [  XmlElement( ElementName = "PropostaDescricao"   )]
      public string gxTpr_Propostadescricao
      {
         get {
            return gxTv_SdtPropostaContrato_Propostadescricao ;
         }

         set {
            gxTv_SdtPropostaContrato_Propostadescricao_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostadescricao = value;
            SetDirty("Propostadescricao");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostadescricao_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostadescricao_N = 1;
         gxTv_SdtPropostaContrato_Propostadescricao = "";
         SetDirty("Propostadescricao");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostadescricao_IsNull( )
      {
         return (gxTv_SdtPropostaContrato_Propostadescricao_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaValor" )]
      [  XmlElement( ElementName = "PropostaValor"   )]
      public decimal gxTpr_Propostavalor
      {
         get {
            return gxTv_SdtPropostaContrato_Propostavalor ;
         }

         set {
            gxTv_SdtPropostaContrato_Propostavalor_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostavalor = value;
            SetDirty("Propostavalor");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostavalor_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostavalor_N = 1;
         gxTv_SdtPropostaContrato_Propostavalor = 0;
         SetDirty("Propostavalor");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostavalor_IsNull( )
      {
         return (gxTv_SdtPropostaContrato_Propostavalor_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaCreatedAt" )]
      [  XmlElement( ElementName = "PropostaCreatedAt"  , IsNullable=true )]
      public string gxTpr_Propostacreatedat_Nullable
      {
         get {
            if ( gxTv_SdtPropostaContrato_Propostacreatedat == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtPropostaContrato_Propostacreatedat).value ;
         }

         set {
            gxTv_SdtPropostaContrato_Propostacreatedat_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtPropostaContrato_Propostacreatedat = DateTime.MinValue;
            else
               gxTv_SdtPropostaContrato_Propostacreatedat = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Propostacreatedat
      {
         get {
            return gxTv_SdtPropostaContrato_Propostacreatedat ;
         }

         set {
            gxTv_SdtPropostaContrato_Propostacreatedat_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostacreatedat = value;
            SetDirty("Propostacreatedat");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostacreatedat_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostacreatedat_N = 1;
         gxTv_SdtPropostaContrato_Propostacreatedat = (DateTime)(DateTime.MinValue);
         SetDirty("Propostacreatedat");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostacreatedat_IsNull( )
      {
         return (gxTv_SdtPropostaContrato_Propostacreatedat_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaCratedBy" )]
      [  XmlElement( ElementName = "PropostaCratedBy"   )]
      public short gxTpr_Propostacratedby
      {
         get {
            return gxTv_SdtPropostaContrato_Propostacratedby ;
         }

         set {
            gxTv_SdtPropostaContrato_Propostacratedby_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostacratedby = value;
            SetDirty("Propostacratedby");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostacratedby_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostacratedby_N = 1;
         gxTv_SdtPropostaContrato_Propostacratedby = 0;
         SetDirty("Propostacratedby");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostacratedby_IsNull( )
      {
         return (gxTv_SdtPropostaContrato_Propostacratedby_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaStatus" )]
      [  XmlElement( ElementName = "PropostaStatus"   )]
      public string gxTpr_Propostastatus
      {
         get {
            return gxTv_SdtPropostaContrato_Propostastatus ;
         }

         set {
            gxTv_SdtPropostaContrato_Propostastatus_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostastatus = value;
            SetDirty("Propostastatus");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostastatus_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostastatus_N = 1;
         gxTv_SdtPropostaContrato_Propostastatus = "";
         SetDirty("Propostastatus");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostastatus_IsNull( )
      {
         return (gxTv_SdtPropostaContrato_Propostastatus_N==1) ;
      }

      [  SoapElement( ElementName = "ContratoId" )]
      [  XmlElement( ElementName = "ContratoId"   )]
      public int gxTpr_Contratoid
      {
         get {
            return gxTv_SdtPropostaContrato_Contratoid ;
         }

         set {
            gxTv_SdtPropostaContrato_Contratoid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Contratoid = value;
            SetDirty("Contratoid");
         }

      }

      public void gxTv_SdtPropostaContrato_Contratoid_SetNull( )
      {
         gxTv_SdtPropostaContrato_Contratoid_N = 1;
         gxTv_SdtPropostaContrato_Contratoid = 0;
         SetDirty("Contratoid");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Contratoid_IsNull( )
      {
         return (gxTv_SdtPropostaContrato_Contratoid_N==1) ;
      }

      [  SoapElement( ElementName = "ContratoNome" )]
      [  XmlElement( ElementName = "ContratoNome"   )]
      public string gxTpr_Contratonome
      {
         get {
            return gxTv_SdtPropostaContrato_Contratonome ;
         }

         set {
            gxTv_SdtPropostaContrato_Contratonome_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Contratonome = value;
            SetDirty("Contratonome");
         }

      }

      public void gxTv_SdtPropostaContrato_Contratonome_SetNull( )
      {
         gxTv_SdtPropostaContrato_Contratonome_N = 1;
         gxTv_SdtPropostaContrato_Contratonome = "";
         SetDirty("Contratonome");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Contratonome_IsNull( )
      {
         return (gxTv_SdtPropostaContrato_Contratonome_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaQuantidadeAprovadores" )]
      [  XmlElement( ElementName = "PropostaQuantidadeAprovadores"   )]
      public short gxTpr_Propostaquantidadeaprovadores
      {
         get {
            return gxTv_SdtPropostaContrato_Propostaquantidadeaprovadores ;
         }

         set {
            gxTv_SdtPropostaContrato_Propostaquantidadeaprovadores_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostaquantidadeaprovadores = value;
            SetDirty("Propostaquantidadeaprovadores");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostaquantidadeaprovadores_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostaquantidadeaprovadores_N = 1;
         gxTv_SdtPropostaContrato_Propostaquantidadeaprovadores = 0;
         SetDirty("Propostaquantidadeaprovadores");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostaquantidadeaprovadores_IsNull( )
      {
         return (gxTv_SdtPropostaContrato_Propostaquantidadeaprovadores_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaReprovacoesPermitidas" )]
      [  XmlElement( ElementName = "PropostaReprovacoesPermitidas"   )]
      public short gxTpr_Propostareprovacoespermitidas
      {
         get {
            return gxTv_SdtPropostaContrato_Propostareprovacoespermitidas ;
         }

         set {
            gxTv_SdtPropostaContrato_Propostareprovacoespermitidas_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostareprovacoespermitidas = value;
            SetDirty("Propostareprovacoespermitidas");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostareprovacoespermitidas_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostareprovacoespermitidas_N = 1;
         gxTv_SdtPropostaContrato_Propostareprovacoespermitidas = 0;
         SetDirty("Propostareprovacoespermitidas");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostareprovacoespermitidas_IsNull( )
      {
         return (gxTv_SdtPropostaContrato_Propostareprovacoespermitidas_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaAprovacoes_F" )]
      [  XmlElement( ElementName = "PropostaAprovacoes_F"   )]
      public short gxTpr_Propostaaprovacoes_f
      {
         get {
            return gxTv_SdtPropostaContrato_Propostaaprovacoes_f ;
         }

         set {
            gxTv_SdtPropostaContrato_Propostaaprovacoes_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostaaprovacoes_f = value;
            SetDirty("Propostaaprovacoes_f");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostaaprovacoes_f_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostaaprovacoes_f_N = 1;
         gxTv_SdtPropostaContrato_Propostaaprovacoes_f = 0;
         SetDirty("Propostaaprovacoes_f");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostaaprovacoes_f_IsNull( )
      {
         return (gxTv_SdtPropostaContrato_Propostaaprovacoes_f_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaReprovacoes_F" )]
      [  XmlElement( ElementName = "PropostaReprovacoes_F"   )]
      public short gxTpr_Propostareprovacoes_f
      {
         get {
            return gxTv_SdtPropostaContrato_Propostareprovacoes_f ;
         }

         set {
            gxTv_SdtPropostaContrato_Propostareprovacoes_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostareprovacoes_f = value;
            SetDirty("Propostareprovacoes_f");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostareprovacoes_f_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostareprovacoes_f_N = 1;
         gxTv_SdtPropostaContrato_Propostareprovacoes_f = 0;
         SetDirty("Propostareprovacoes_f");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostareprovacoes_f_IsNull( )
      {
         return (gxTv_SdtPropostaContrato_Propostareprovacoes_f_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaAprovacoesRestantes_F" )]
      [  XmlElement( ElementName = "PropostaAprovacoesRestantes_F"   )]
      public short gxTpr_Propostaaprovacoesrestantes_f
      {
         get {
            return gxTv_SdtPropostaContrato_Propostaaprovacoesrestantes_f ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostaaprovacoesrestantes_f = value;
            SetDirty("Propostaaprovacoesrestantes_f");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostaaprovacoesrestantes_f_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostaaprovacoesrestantes_f = 0;
         SetDirty("Propostaaprovacoesrestantes_f");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostaaprovacoesrestantes_f_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteClienteId" )]
      [  XmlElement( ElementName = "PropostaPacienteClienteId"   )]
      public int gxTpr_Propostapacienteclienteid
      {
         get {
            return gxTv_SdtPropostaContrato_Propostapacienteclienteid ;
         }

         set {
            gxTv_SdtPropostaContrato_Propostapacienteclienteid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostapacienteclienteid = value;
            SetDirty("Propostapacienteclienteid");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostapacienteclienteid_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostapacienteclienteid_N = 1;
         gxTv_SdtPropostaContrato_Propostapacienteclienteid = 0;
         SetDirty("Propostapacienteclienteid");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostapacienteclienteid_IsNull( )
      {
         return (gxTv_SdtPropostaContrato_Propostapacienteclienteid_N==1) ;
      }

      [  SoapElement( ElementName = "PropostaPacienteClienteRazaoSocial" )]
      [  XmlElement( ElementName = "PropostaPacienteClienteRazaoSocial"   )]
      public string gxTpr_Propostapacienteclienterazaosocial
      {
         get {
            return gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial ;
         }

         set {
            gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial = value;
            SetDirty("Propostapacienteclienterazaosocial");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial_N = 1;
         gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial = "";
         SetDirty("Propostapacienteclienterazaosocial");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial_IsNull( )
      {
         return (gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial_N==1) ;
      }

      [  SoapElement( ElementName = "ReembolsoStatusAtual_F" )]
      [  XmlElement( ElementName = "ReembolsoStatusAtual_F"   )]
      public string gxTpr_Reembolsostatusatual_f
      {
         get {
            return gxTv_SdtPropostaContrato_Reembolsostatusatual_f ;
         }

         set {
            gxTv_SdtPropostaContrato_Reembolsostatusatual_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Reembolsostatusatual_f = value;
            SetDirty("Reembolsostatusatual_f");
         }

      }

      public void gxTv_SdtPropostaContrato_Reembolsostatusatual_f_SetNull( )
      {
         gxTv_SdtPropostaContrato_Reembolsostatusatual_f_N = 1;
         gxTv_SdtPropostaContrato_Reembolsostatusatual_f = "";
         SetDirty("Reembolsostatusatual_f");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Reembolsostatusatual_f_IsNull( )
      {
         return (gxTv_SdtPropostaContrato_Reembolsostatusatual_f_N==1) ;
      }

      [  SoapElement( ElementName = "WorkFlowPasso_F" )]
      [  XmlElement( ElementName = "WorkFlowPasso_F"   )]
      public string gxTpr_Workflowpasso_f
      {
         get {
            return gxTv_SdtPropostaContrato_Workflowpasso_f ;
         }

         set {
            gxTv_SdtPropostaContrato_Workflowpasso_f_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Workflowpasso_f = value;
            SetDirty("Workflowpasso_f");
         }

      }

      public void gxTv_SdtPropostaContrato_Workflowpasso_f_SetNull( )
      {
         gxTv_SdtPropostaContrato_Workflowpasso_f_N = 1;
         gxTv_SdtPropostaContrato_Workflowpasso_f = "";
         SetDirty("Workflowpasso_f");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Workflowpasso_f_IsNull( )
      {
         return (gxTv_SdtPropostaContrato_Workflowpasso_f_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtPropostaContrato_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtPropostaContrato_Mode_SetNull( )
      {
         gxTv_SdtPropostaContrato_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtPropostaContrato_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtPropostaContrato_Initialized_SetNull( )
      {
         gxTv_SdtPropostaContrato_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaId_Z" )]
      [  XmlElement( ElementName = "PropostaId_Z"   )]
      public int gxTpr_Propostaid_Z
      {
         get {
            return gxTv_SdtPropostaContrato_Propostaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostaid_Z = value;
            SetDirty("Propostaid_Z");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostaid_Z_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostaid_Z = 0;
         SetDirty("Propostaid_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaTitulo_Z" )]
      [  XmlElement( ElementName = "PropostaTitulo_Z"   )]
      public string gxTpr_Propostatitulo_Z
      {
         get {
            return gxTv_SdtPropostaContrato_Propostatitulo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostatitulo_Z = value;
            SetDirty("Propostatitulo_Z");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostatitulo_Z_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostatitulo_Z = "";
         SetDirty("Propostatitulo_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostatitulo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProcedimentosMedicosId_Z" )]
      [  XmlElement( ElementName = "ProcedimentosMedicosId_Z"   )]
      public int gxTpr_Procedimentosmedicosid_Z
      {
         get {
            return gxTv_SdtPropostaContrato_Procedimentosmedicosid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Procedimentosmedicosid_Z = value;
            SetDirty("Procedimentosmedicosid_Z");
         }

      }

      public void gxTv_SdtPropostaContrato_Procedimentosmedicosid_Z_SetNull( )
      {
         gxTv_SdtPropostaContrato_Procedimentosmedicosid_Z = 0;
         SetDirty("Procedimentosmedicosid_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Procedimentosmedicosid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaDescricao_Z" )]
      [  XmlElement( ElementName = "PropostaDescricao_Z"   )]
      public string gxTpr_Propostadescricao_Z
      {
         get {
            return gxTv_SdtPropostaContrato_Propostadescricao_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostadescricao_Z = value;
            SetDirty("Propostadescricao_Z");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostadescricao_Z_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostadescricao_Z = "";
         SetDirty("Propostadescricao_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostadescricao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaValor_Z" )]
      [  XmlElement( ElementName = "PropostaValor_Z"   )]
      public decimal gxTpr_Propostavalor_Z
      {
         get {
            return gxTv_SdtPropostaContrato_Propostavalor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostavalor_Z = value;
            SetDirty("Propostavalor_Z");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostavalor_Z_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostavalor_Z = 0;
         SetDirty("Propostavalor_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostavalor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaCreatedAt_Z" )]
      [  XmlElement( ElementName = "PropostaCreatedAt_Z"  , IsNullable=true )]
      public string gxTpr_Propostacreatedat_Z_Nullable
      {
         get {
            if ( gxTv_SdtPropostaContrato_Propostacreatedat_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtPropostaContrato_Propostacreatedat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtPropostaContrato_Propostacreatedat_Z = DateTime.MinValue;
            else
               gxTv_SdtPropostaContrato_Propostacreatedat_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Propostacreatedat_Z
      {
         get {
            return gxTv_SdtPropostaContrato_Propostacreatedat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostacreatedat_Z = value;
            SetDirty("Propostacreatedat_Z");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostacreatedat_Z_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostacreatedat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Propostacreatedat_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostacreatedat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaCratedBy_Z" )]
      [  XmlElement( ElementName = "PropostaCratedBy_Z"   )]
      public short gxTpr_Propostacratedby_Z
      {
         get {
            return gxTv_SdtPropostaContrato_Propostacratedby_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostacratedby_Z = value;
            SetDirty("Propostacratedby_Z");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostacratedby_Z_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostacratedby_Z = 0;
         SetDirty("Propostacratedby_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostacratedby_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaStatus_Z" )]
      [  XmlElement( ElementName = "PropostaStatus_Z"   )]
      public string gxTpr_Propostastatus_Z
      {
         get {
            return gxTv_SdtPropostaContrato_Propostastatus_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostastatus_Z = value;
            SetDirty("Propostastatus_Z");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostastatus_Z_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostastatus_Z = "";
         SetDirty("Propostastatus_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostastatus_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoId_Z" )]
      [  XmlElement( ElementName = "ContratoId_Z"   )]
      public int gxTpr_Contratoid_Z
      {
         get {
            return gxTv_SdtPropostaContrato_Contratoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Contratoid_Z = value;
            SetDirty("Contratoid_Z");
         }

      }

      public void gxTv_SdtPropostaContrato_Contratoid_Z_SetNull( )
      {
         gxTv_SdtPropostaContrato_Contratoid_Z = 0;
         SetDirty("Contratoid_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Contratoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoNome_Z" )]
      [  XmlElement( ElementName = "ContratoNome_Z"   )]
      public string gxTpr_Contratonome_Z
      {
         get {
            return gxTv_SdtPropostaContrato_Contratonome_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Contratonome_Z = value;
            SetDirty("Contratonome_Z");
         }

      }

      public void gxTv_SdtPropostaContrato_Contratonome_Z_SetNull( )
      {
         gxTv_SdtPropostaContrato_Contratonome_Z = "";
         SetDirty("Contratonome_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Contratonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaQuantidadeAprovadores_Z" )]
      [  XmlElement( ElementName = "PropostaQuantidadeAprovadores_Z"   )]
      public short gxTpr_Propostaquantidadeaprovadores_Z
      {
         get {
            return gxTv_SdtPropostaContrato_Propostaquantidadeaprovadores_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostaquantidadeaprovadores_Z = value;
            SetDirty("Propostaquantidadeaprovadores_Z");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostaquantidadeaprovadores_Z_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostaquantidadeaprovadores_Z = 0;
         SetDirty("Propostaquantidadeaprovadores_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostaquantidadeaprovadores_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaReprovacoesPermitidas_Z" )]
      [  XmlElement( ElementName = "PropostaReprovacoesPermitidas_Z"   )]
      public short gxTpr_Propostareprovacoespermitidas_Z
      {
         get {
            return gxTv_SdtPropostaContrato_Propostareprovacoespermitidas_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostareprovacoespermitidas_Z = value;
            SetDirty("Propostareprovacoespermitidas_Z");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostareprovacoespermitidas_Z_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostareprovacoespermitidas_Z = 0;
         SetDirty("Propostareprovacoespermitidas_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostareprovacoespermitidas_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaAprovacoes_F_Z" )]
      [  XmlElement( ElementName = "PropostaAprovacoes_F_Z"   )]
      public short gxTpr_Propostaaprovacoes_f_Z
      {
         get {
            return gxTv_SdtPropostaContrato_Propostaaprovacoes_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostaaprovacoes_f_Z = value;
            SetDirty("Propostaaprovacoes_f_Z");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostaaprovacoes_f_Z_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostaaprovacoes_f_Z = 0;
         SetDirty("Propostaaprovacoes_f_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostaaprovacoes_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaReprovacoes_F_Z" )]
      [  XmlElement( ElementName = "PropostaReprovacoes_F_Z"   )]
      public short gxTpr_Propostareprovacoes_f_Z
      {
         get {
            return gxTv_SdtPropostaContrato_Propostareprovacoes_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostareprovacoes_f_Z = value;
            SetDirty("Propostareprovacoes_f_Z");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostareprovacoes_f_Z_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostareprovacoes_f_Z = 0;
         SetDirty("Propostareprovacoes_f_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostareprovacoes_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaAprovacoesRestantes_F_Z" )]
      [  XmlElement( ElementName = "PropostaAprovacoesRestantes_F_Z"   )]
      public short gxTpr_Propostaaprovacoesrestantes_f_Z
      {
         get {
            return gxTv_SdtPropostaContrato_Propostaaprovacoesrestantes_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostaaprovacoesrestantes_f_Z = value;
            SetDirty("Propostaaprovacoesrestantes_f_Z");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostaaprovacoesrestantes_f_Z_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostaaprovacoesrestantes_f_Z = 0;
         SetDirty("Propostaaprovacoesrestantes_f_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostaaprovacoesrestantes_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteClienteId_Z" )]
      [  XmlElement( ElementName = "PropostaPacienteClienteId_Z"   )]
      public int gxTpr_Propostapacienteclienteid_Z
      {
         get {
            return gxTv_SdtPropostaContrato_Propostapacienteclienteid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostapacienteclienteid_Z = value;
            SetDirty("Propostapacienteclienteid_Z");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostapacienteclienteid_Z_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostapacienteclienteid_Z = 0;
         SetDirty("Propostapacienteclienteid_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostapacienteclienteid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteClienteRazaoSocial_Z" )]
      [  XmlElement( ElementName = "PropostaPacienteClienteRazaoSocial_Z"   )]
      public string gxTpr_Propostapacienteclienterazaosocial_Z
      {
         get {
            return gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial_Z = value;
            SetDirty("Propostapacienteclienterazaosocial_Z");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial_Z_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial_Z = "";
         SetDirty("Propostapacienteclienterazaosocial_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoStatusAtual_F_Z" )]
      [  XmlElement( ElementName = "ReembolsoStatusAtual_F_Z"   )]
      public string gxTpr_Reembolsostatusatual_f_Z
      {
         get {
            return gxTv_SdtPropostaContrato_Reembolsostatusatual_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Reembolsostatusatual_f_Z = value;
            SetDirty("Reembolsostatusatual_f_Z");
         }

      }

      public void gxTv_SdtPropostaContrato_Reembolsostatusatual_f_Z_SetNull( )
      {
         gxTv_SdtPropostaContrato_Reembolsostatusatual_f_Z = "";
         SetDirty("Reembolsostatusatual_f_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Reembolsostatusatual_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WorkFlowPasso_F_Z" )]
      [  XmlElement( ElementName = "WorkFlowPasso_F_Z"   )]
      public string gxTpr_Workflowpasso_f_Z
      {
         get {
            return gxTv_SdtPropostaContrato_Workflowpasso_f_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Workflowpasso_f_Z = value;
            SetDirty("Workflowpasso_f_Z");
         }

      }

      public void gxTv_SdtPropostaContrato_Workflowpasso_f_Z_SetNull( )
      {
         gxTv_SdtPropostaContrato_Workflowpasso_f_Z = "";
         SetDirty("Workflowpasso_f_Z");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Workflowpasso_f_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaId_N" )]
      [  XmlElement( ElementName = "PropostaId_N"   )]
      public short gxTpr_Propostaid_N
      {
         get {
            return gxTv_SdtPropostaContrato_Propostaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostaid_N = value;
            SetDirty("Propostaid_N");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostaid_N_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostaid_N = 0;
         SetDirty("Propostaid_N");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaTitulo_N" )]
      [  XmlElement( ElementName = "PropostaTitulo_N"   )]
      public short gxTpr_Propostatitulo_N
      {
         get {
            return gxTv_SdtPropostaContrato_Propostatitulo_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostatitulo_N = value;
            SetDirty("Propostatitulo_N");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostatitulo_N_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostatitulo_N = 0;
         SetDirty("Propostatitulo_N");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostatitulo_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProcedimentosMedicosId_N" )]
      [  XmlElement( ElementName = "ProcedimentosMedicosId_N"   )]
      public short gxTpr_Procedimentosmedicosid_N
      {
         get {
            return gxTv_SdtPropostaContrato_Procedimentosmedicosid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Procedimentosmedicosid_N = value;
            SetDirty("Procedimentosmedicosid_N");
         }

      }

      public void gxTv_SdtPropostaContrato_Procedimentosmedicosid_N_SetNull( )
      {
         gxTv_SdtPropostaContrato_Procedimentosmedicosid_N = 0;
         SetDirty("Procedimentosmedicosid_N");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Procedimentosmedicosid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaDescricao_N" )]
      [  XmlElement( ElementName = "PropostaDescricao_N"   )]
      public short gxTpr_Propostadescricao_N
      {
         get {
            return gxTv_SdtPropostaContrato_Propostadescricao_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostadescricao_N = value;
            SetDirty("Propostadescricao_N");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostadescricao_N_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostadescricao_N = 0;
         SetDirty("Propostadescricao_N");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostadescricao_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaValor_N" )]
      [  XmlElement( ElementName = "PropostaValor_N"   )]
      public short gxTpr_Propostavalor_N
      {
         get {
            return gxTv_SdtPropostaContrato_Propostavalor_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostavalor_N = value;
            SetDirty("Propostavalor_N");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostavalor_N_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostavalor_N = 0;
         SetDirty("Propostavalor_N");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostavalor_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaCreatedAt_N" )]
      [  XmlElement( ElementName = "PropostaCreatedAt_N"   )]
      public short gxTpr_Propostacreatedat_N
      {
         get {
            return gxTv_SdtPropostaContrato_Propostacreatedat_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostacreatedat_N = value;
            SetDirty("Propostacreatedat_N");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostacreatedat_N_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostacreatedat_N = 0;
         SetDirty("Propostacreatedat_N");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostacreatedat_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaCratedBy_N" )]
      [  XmlElement( ElementName = "PropostaCratedBy_N"   )]
      public short gxTpr_Propostacratedby_N
      {
         get {
            return gxTv_SdtPropostaContrato_Propostacratedby_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostacratedby_N = value;
            SetDirty("Propostacratedby_N");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostacratedby_N_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostacratedby_N = 0;
         SetDirty("Propostacratedby_N");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostacratedby_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaStatus_N" )]
      [  XmlElement( ElementName = "PropostaStatus_N"   )]
      public short gxTpr_Propostastatus_N
      {
         get {
            return gxTv_SdtPropostaContrato_Propostastatus_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostastatus_N = value;
            SetDirty("Propostastatus_N");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostastatus_N_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostastatus_N = 0;
         SetDirty("Propostastatus_N");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostastatus_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoId_N" )]
      [  XmlElement( ElementName = "ContratoId_N"   )]
      public short gxTpr_Contratoid_N
      {
         get {
            return gxTv_SdtPropostaContrato_Contratoid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Contratoid_N = value;
            SetDirty("Contratoid_N");
         }

      }

      public void gxTv_SdtPropostaContrato_Contratoid_N_SetNull( )
      {
         gxTv_SdtPropostaContrato_Contratoid_N = 0;
         SetDirty("Contratoid_N");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Contratoid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ContratoNome_N" )]
      [  XmlElement( ElementName = "ContratoNome_N"   )]
      public short gxTpr_Contratonome_N
      {
         get {
            return gxTv_SdtPropostaContrato_Contratonome_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Contratonome_N = value;
            SetDirty("Contratonome_N");
         }

      }

      public void gxTv_SdtPropostaContrato_Contratonome_N_SetNull( )
      {
         gxTv_SdtPropostaContrato_Contratonome_N = 0;
         SetDirty("Contratonome_N");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Contratonome_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaQuantidadeAprovadores_N" )]
      [  XmlElement( ElementName = "PropostaQuantidadeAprovadores_N"   )]
      public short gxTpr_Propostaquantidadeaprovadores_N
      {
         get {
            return gxTv_SdtPropostaContrato_Propostaquantidadeaprovadores_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostaquantidadeaprovadores_N = value;
            SetDirty("Propostaquantidadeaprovadores_N");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostaquantidadeaprovadores_N_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostaquantidadeaprovadores_N = 0;
         SetDirty("Propostaquantidadeaprovadores_N");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostaquantidadeaprovadores_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaReprovacoesPermitidas_N" )]
      [  XmlElement( ElementName = "PropostaReprovacoesPermitidas_N"   )]
      public short gxTpr_Propostareprovacoespermitidas_N
      {
         get {
            return gxTv_SdtPropostaContrato_Propostareprovacoespermitidas_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostareprovacoespermitidas_N = value;
            SetDirty("Propostareprovacoespermitidas_N");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostareprovacoespermitidas_N_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostareprovacoespermitidas_N = 0;
         SetDirty("Propostareprovacoespermitidas_N");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostareprovacoespermitidas_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaAprovacoes_F_N" )]
      [  XmlElement( ElementName = "PropostaAprovacoes_F_N"   )]
      public short gxTpr_Propostaaprovacoes_f_N
      {
         get {
            return gxTv_SdtPropostaContrato_Propostaaprovacoes_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostaaprovacoes_f_N = value;
            SetDirty("Propostaaprovacoes_f_N");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostaaprovacoes_f_N_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostaaprovacoes_f_N = 0;
         SetDirty("Propostaaprovacoes_f_N");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostaaprovacoes_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaReprovacoes_F_N" )]
      [  XmlElement( ElementName = "PropostaReprovacoes_F_N"   )]
      public short gxTpr_Propostareprovacoes_f_N
      {
         get {
            return gxTv_SdtPropostaContrato_Propostareprovacoes_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostareprovacoes_f_N = value;
            SetDirty("Propostareprovacoes_f_N");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostareprovacoes_f_N_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostareprovacoes_f_N = 0;
         SetDirty("Propostareprovacoes_f_N");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostareprovacoes_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteClienteId_N" )]
      [  XmlElement( ElementName = "PropostaPacienteClienteId_N"   )]
      public short gxTpr_Propostapacienteclienteid_N
      {
         get {
            return gxTv_SdtPropostaContrato_Propostapacienteclienteid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostapacienteclienteid_N = value;
            SetDirty("Propostapacienteclienteid_N");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostapacienteclienteid_N_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostapacienteclienteid_N = 0;
         SetDirty("Propostapacienteclienteid_N");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostapacienteclienteid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PropostaPacienteClienteRazaoSocial_N" )]
      [  XmlElement( ElementName = "PropostaPacienteClienteRazaoSocial_N"   )]
      public short gxTpr_Propostapacienteclienterazaosocial_N
      {
         get {
            return gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial_N = value;
            SetDirty("Propostapacienteclienterazaosocial_N");
         }

      }

      public void gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial_N_SetNull( )
      {
         gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial_N = 0;
         SetDirty("Propostapacienteclienterazaosocial_N");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ReembolsoStatusAtual_F_N" )]
      [  XmlElement( ElementName = "ReembolsoStatusAtual_F_N"   )]
      public short gxTpr_Reembolsostatusatual_f_N
      {
         get {
            return gxTv_SdtPropostaContrato_Reembolsostatusatual_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Reembolsostatusatual_f_N = value;
            SetDirty("Reembolsostatusatual_f_N");
         }

      }

      public void gxTv_SdtPropostaContrato_Reembolsostatusatual_f_N_SetNull( )
      {
         gxTv_SdtPropostaContrato_Reembolsostatusatual_f_N = 0;
         SetDirty("Reembolsostatusatual_f_N");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Reembolsostatusatual_f_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WorkFlowPasso_F_N" )]
      [  XmlElement( ElementName = "WorkFlowPasso_F_N"   )]
      public short gxTpr_Workflowpasso_f_N
      {
         get {
            return gxTv_SdtPropostaContrato_Workflowpasso_f_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPropostaContrato_Workflowpasso_f_N = value;
            SetDirty("Workflowpasso_f_N");
         }

      }

      public void gxTv_SdtPropostaContrato_Workflowpasso_f_N_SetNull( )
      {
         gxTv_SdtPropostaContrato_Workflowpasso_f_N = 0;
         SetDirty("Workflowpasso_f_N");
         return  ;
      }

      public bool gxTv_SdtPropostaContrato_Workflowpasso_f_N_IsNull( )
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
         gxTv_SdtPropostaContrato_Propostatitulo = "";
         gxTv_SdtPropostaContrato_Propostadescricao = "";
         gxTv_SdtPropostaContrato_Propostacreatedat = (DateTime)(DateTime.MinValue);
         gxTv_SdtPropostaContrato_Propostastatus = "";
         gxTv_SdtPropostaContrato_Contratonome = "";
         gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial = "";
         gxTv_SdtPropostaContrato_Reembolsostatusatual_f = "";
         gxTv_SdtPropostaContrato_Workflowpasso_f = "";
         gxTv_SdtPropostaContrato_Mode = "";
         gxTv_SdtPropostaContrato_Propostatitulo_Z = "";
         gxTv_SdtPropostaContrato_Propostadescricao_Z = "";
         gxTv_SdtPropostaContrato_Propostacreatedat_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtPropostaContrato_Propostastatus_Z = "";
         gxTv_SdtPropostaContrato_Contratonome_Z = "";
         gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial_Z = "";
         gxTv_SdtPropostaContrato_Reembolsostatusatual_f_Z = "";
         gxTv_SdtPropostaContrato_Workflowpasso_f_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "propostacontrato", "GeneXus.Programs.propostacontrato_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtPropostaContrato_Propostacratedby ;
      private short gxTv_SdtPropostaContrato_Propostaquantidadeaprovadores ;
      private short gxTv_SdtPropostaContrato_Propostareprovacoespermitidas ;
      private short gxTv_SdtPropostaContrato_Propostaaprovacoes_f ;
      private short gxTv_SdtPropostaContrato_Propostareprovacoes_f ;
      private short gxTv_SdtPropostaContrato_Propostaaprovacoesrestantes_f ;
      private short gxTv_SdtPropostaContrato_Initialized ;
      private short gxTv_SdtPropostaContrato_Propostacratedby_Z ;
      private short gxTv_SdtPropostaContrato_Propostaquantidadeaprovadores_Z ;
      private short gxTv_SdtPropostaContrato_Propostareprovacoespermitidas_Z ;
      private short gxTv_SdtPropostaContrato_Propostaaprovacoes_f_Z ;
      private short gxTv_SdtPropostaContrato_Propostareprovacoes_f_Z ;
      private short gxTv_SdtPropostaContrato_Propostaaprovacoesrestantes_f_Z ;
      private short gxTv_SdtPropostaContrato_Propostaid_N ;
      private short gxTv_SdtPropostaContrato_Propostatitulo_N ;
      private short gxTv_SdtPropostaContrato_Procedimentosmedicosid_N ;
      private short gxTv_SdtPropostaContrato_Propostadescricao_N ;
      private short gxTv_SdtPropostaContrato_Propostavalor_N ;
      private short gxTv_SdtPropostaContrato_Propostacreatedat_N ;
      private short gxTv_SdtPropostaContrato_Propostacratedby_N ;
      private short gxTv_SdtPropostaContrato_Propostastatus_N ;
      private short gxTv_SdtPropostaContrato_Contratoid_N ;
      private short gxTv_SdtPropostaContrato_Contratonome_N ;
      private short gxTv_SdtPropostaContrato_Propostaquantidadeaprovadores_N ;
      private short gxTv_SdtPropostaContrato_Propostareprovacoespermitidas_N ;
      private short gxTv_SdtPropostaContrato_Propostaaprovacoes_f_N ;
      private short gxTv_SdtPropostaContrato_Propostareprovacoes_f_N ;
      private short gxTv_SdtPropostaContrato_Propostapacienteclienteid_N ;
      private short gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial_N ;
      private short gxTv_SdtPropostaContrato_Reembolsostatusatual_f_N ;
      private short gxTv_SdtPropostaContrato_Workflowpasso_f_N ;
      private int gxTv_SdtPropostaContrato_Propostaid ;
      private int gxTv_SdtPropostaContrato_Procedimentosmedicosid ;
      private int gxTv_SdtPropostaContrato_Contratoid ;
      private int gxTv_SdtPropostaContrato_Propostapacienteclienteid ;
      private int gxTv_SdtPropostaContrato_Propostaid_Z ;
      private int gxTv_SdtPropostaContrato_Procedimentosmedicosid_Z ;
      private int gxTv_SdtPropostaContrato_Contratoid_Z ;
      private int gxTv_SdtPropostaContrato_Propostapacienteclienteid_Z ;
      private decimal gxTv_SdtPropostaContrato_Propostavalor ;
      private decimal gxTv_SdtPropostaContrato_Propostavalor_Z ;
      private string gxTv_SdtPropostaContrato_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtPropostaContrato_Propostacreatedat ;
      private DateTime gxTv_SdtPropostaContrato_Propostacreatedat_Z ;
      private DateTime datetime_STZ ;
      private string gxTv_SdtPropostaContrato_Propostatitulo ;
      private string gxTv_SdtPropostaContrato_Propostadescricao ;
      private string gxTv_SdtPropostaContrato_Propostastatus ;
      private string gxTv_SdtPropostaContrato_Contratonome ;
      private string gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial ;
      private string gxTv_SdtPropostaContrato_Reembolsostatusatual_f ;
      private string gxTv_SdtPropostaContrato_Workflowpasso_f ;
      private string gxTv_SdtPropostaContrato_Propostatitulo_Z ;
      private string gxTv_SdtPropostaContrato_Propostadescricao_Z ;
      private string gxTv_SdtPropostaContrato_Propostastatus_Z ;
      private string gxTv_SdtPropostaContrato_Contratonome_Z ;
      private string gxTv_SdtPropostaContrato_Propostapacienteclienterazaosocial_Z ;
      private string gxTv_SdtPropostaContrato_Reembolsostatusatual_f_Z ;
      private string gxTv_SdtPropostaContrato_Workflowpasso_f_Z ;
   }

   [DataContract(Name = @"PropostaContrato", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtPropostaContrato_RESTInterface : GxGenericCollectionItem<SdtPropostaContrato>
   {
      public SdtPropostaContrato_RESTInterface( ) : base()
      {
      }

      public SdtPropostaContrato_RESTInterface( SdtPropostaContrato psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PropostaId" , Order = 0 )]
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

      [DataMember( Name = "PropostaTitulo" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Propostatitulo
      {
         get {
            return sdt.gxTpr_Propostatitulo ;
         }

         set {
            sdt.gxTpr_Propostatitulo = value;
         }

      }

      [DataMember( Name = "ProcedimentosMedicosId" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Procedimentosmedicosid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Procedimentosmedicosid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Procedimentosmedicosid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "PropostaDescricao" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Propostadescricao
      {
         get {
            return sdt.gxTpr_Propostadescricao ;
         }

         set {
            sdt.gxTpr_Propostadescricao = value;
         }

      }

      [DataMember( Name = "PropostaValor" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Propostavalor
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Propostavalor, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Propostavalor = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "PropostaCreatedAt" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Propostacreatedat
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Propostacreatedat, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Propostacreatedat = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "PropostaCratedBy" , Order = 6 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Propostacratedby
      {
         get {
            return sdt.gxTpr_Propostacratedby ;
         }

         set {
            sdt.gxTpr_Propostacratedby = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PropostaStatus" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Propostastatus
      {
         get {
            return sdt.gxTpr_Propostastatus ;
         }

         set {
            sdt.gxTpr_Propostastatus = value;
         }

      }

      [DataMember( Name = "ContratoId" , Order = 8 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Contratoid
      {
         get {
            return sdt.gxTpr_Contratoid ;
         }

         set {
            sdt.gxTpr_Contratoid = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ContratoNome" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Contratonome
      {
         get {
            return sdt.gxTpr_Contratonome ;
         }

         set {
            sdt.gxTpr_Contratonome = value;
         }

      }

      [DataMember( Name = "PropostaQuantidadeAprovadores" , Order = 10 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Propostaquantidadeaprovadores
      {
         get {
            return sdt.gxTpr_Propostaquantidadeaprovadores ;
         }

         set {
            sdt.gxTpr_Propostaquantidadeaprovadores = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PropostaReprovacoesPermitidas" , Order = 11 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Propostareprovacoespermitidas
      {
         get {
            return sdt.gxTpr_Propostareprovacoespermitidas ;
         }

         set {
            sdt.gxTpr_Propostareprovacoespermitidas = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PropostaAprovacoes_F" , Order = 12 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Propostaaprovacoes_f
      {
         get {
            return sdt.gxTpr_Propostaaprovacoes_f ;
         }

         set {
            sdt.gxTpr_Propostaaprovacoes_f = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PropostaReprovacoes_F" , Order = 13 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Propostareprovacoes_f
      {
         get {
            return sdt.gxTpr_Propostareprovacoes_f ;
         }

         set {
            sdt.gxTpr_Propostareprovacoes_f = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PropostaAprovacoesRestantes_F" , Order = 14 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Propostaaprovacoesrestantes_f
      {
         get {
            return sdt.gxTpr_Propostaaprovacoesrestantes_f ;
         }

         set {
            sdt.gxTpr_Propostaaprovacoesrestantes_f = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PropostaPacienteClienteId" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Propostapacienteclienteid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Propostapacienteclienteid), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Propostapacienteclienteid = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "PropostaPacienteClienteRazaoSocial" , Order = 16 )]
      [GxSeudo()]
      public string gxTpr_Propostapacienteclienterazaosocial
      {
         get {
            return sdt.gxTpr_Propostapacienteclienterazaosocial ;
         }

         set {
            sdt.gxTpr_Propostapacienteclienterazaosocial = value;
         }

      }

      [DataMember( Name = "ReembolsoStatusAtual_F" , Order = 17 )]
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

      [DataMember( Name = "WorkFlowPasso_F" , Order = 18 )]
      [GxSeudo()]
      public string gxTpr_Workflowpasso_f
      {
         get {
            return sdt.gxTpr_Workflowpasso_f ;
         }

         set {
            sdt.gxTpr_Workflowpasso_f = value;
         }

      }

      public SdtPropostaContrato sdt
      {
         get {
            return (SdtPropostaContrato)Sdt ;
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
            sdt = new SdtPropostaContrato() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 19 )]
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

   [DataContract(Name = @"PropostaContrato", Namespace = "Factory21")]
   [GxJsonSerialization("default")]
   public class SdtPropostaContrato_RESTLInterface : GxGenericCollectionItem<SdtPropostaContrato>
   {
      public SdtPropostaContrato_RESTLInterface( ) : base()
      {
      }

      public SdtPropostaContrato_RESTLInterface( SdtPropostaContrato psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PropostaTitulo" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Propostatitulo
      {
         get {
            return sdt.gxTpr_Propostatitulo ;
         }

         set {
            sdt.gxTpr_Propostatitulo = value;
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

      public SdtPropostaContrato sdt
      {
         get {
            return (SdtPropostaContrato)Sdt ;
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
            sdt = new SdtPropostaContrato() ;
         }
      }

   }

}
