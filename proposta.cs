using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class proposta : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetFirstPar( "Mode");
         gxfirstwebparm_bkp = gxfirstwebparm;
         gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            dyncall( GetNextPar( )) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel7"+"_"+"PROPOSTAVALORJUROSMORA_F") == 0 )
         {
            A515PropostaDataCreditoCliente_F = context.localUtil.ParseDateParm( GetPar( "PropostaDataCreditoCliente_F"));
            n515PropostaDataCreditoCliente_F = false;
            AssignAttri("", false, "A515PropostaDataCreditoCliente_F", context.localUtil.Format(A515PropostaDataCreditoCliente_F, "99/99/9999"));
            A507PropostaSLA = (short)(Math.Round(NumberUtil.Val( GetPar( "PropostaSLA"), "."), 18, MidpointRounding.ToEven));
            n507PropostaSLA = false;
            AssignAttri("", false, "A507PropostaSLA", ((0==A507PropostaSLA)&&IsIns( )||n507PropostaSLA ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A507PropostaSLA), 4, 0, ".", ""))));
            A508PropostaJurosMora = NumberUtil.Val( GetPar( "PropostaJurosMora"), ".");
            n508PropostaJurosMora = false;
            AssignAttri("", false, "A508PropostaJurosMora", ((Convert.ToDecimal(0)==A508PropostaJurosMora)&&IsIns( )||n508PropostaJurosMora ? "" : StringUtil.LTrim( StringUtil.NToC( A508PropostaJurosMora, 16, 4, ".", ""))));
            A326PropostaValor = NumberUtil.Val( GetPar( "PropostaValor"), ".");
            n326PropostaValor = false;
            AssignAttri("", false, "A326PropostaValor", ((Convert.ToDecimal(0)==A326PropostaValor)&&IsIns( )||n326PropostaValor ? "" : StringUtil.LTrim( StringUtil.NToC( A326PropostaValor, 18, 2, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX7ASAPROPOSTAVALORJUROSMORA_F1A49( A515PropostaDataCreditoCliente_F, A507PropostaSLA, A508PropostaJurosMora, A326PropostaValor) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_51") == 0 )
         {
            A323PropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaId"), "."), 18, MidpointRounding.ToEven));
            n323PropostaId = false;
            AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
            A504PropostaPacienteClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaPacienteClienteId"), "."), 18, MidpointRounding.ToEven));
            n504PropostaPacienteClienteId = false;
            AssignAttri("", false, "A504PropostaPacienteClienteId", ((0==A504PropostaPacienteClienteId)&&IsIns( )||n504PropostaPacienteClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A504PropostaPacienteClienteId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_51( A323PropostaId, A504PropostaPacienteClienteId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_52") == 0 )
         {
            A323PropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaId"), "."), 18, MidpointRounding.ToEven));
            n323PropostaId = false;
            AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
            A504PropostaPacienteClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaPacienteClienteId"), "."), 18, MidpointRounding.ToEven));
            n504PropostaPacienteClienteId = false;
            AssignAttri("", false, "A504PropostaPacienteClienteId", ((0==A504PropostaPacienteClienteId)&&IsIns( )||n504PropostaPacienteClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A504PropostaPacienteClienteId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_52( A323PropostaId, A504PropostaPacienteClienteId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_53") == 0 )
         {
            A323PropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaId"), "."), 18, MidpointRounding.ToEven));
            n323PropostaId = false;
            AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
            A328PropostaCratedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "PropostaCratedBy"), "."), 18, MidpointRounding.ToEven));
            n328PropostaCratedBy = false;
            AssignAttri("", false, "A328PropostaCratedBy", ((0==A328PropostaCratedBy)&&IsIns( )||n328PropostaCratedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A328PropostaCratedBy), 4, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_53( A323PropostaId, A328PropostaCratedBy) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_54") == 0 )
         {
            A323PropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaId"), "."), 18, MidpointRounding.ToEven));
            n323PropostaId = false;
            AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
            A504PropostaPacienteClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaPacienteClienteId"), "."), 18, MidpointRounding.ToEven));
            n504PropostaPacienteClienteId = false;
            AssignAttri("", false, "A504PropostaPacienteClienteId", ((0==A504PropostaPacienteClienteId)&&IsIns( )||n504PropostaPacienteClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A504PropostaPacienteClienteId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_54( A323PropostaId, A504PropostaPacienteClienteId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_55") == 0 )
         {
            A323PropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaId"), "."), 18, MidpointRounding.ToEven));
            n323PropostaId = false;
            AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
            A642PropostaClinicaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaClinicaId"), "."), 18, MidpointRounding.ToEven));
            n642PropostaClinicaId = false;
            AssignAttri("", false, "A642PropostaClinicaId", ((0==A642PropostaClinicaId)&&IsIns( )||n642PropostaClinicaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A642PropostaClinicaId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_55( A323PropostaId, A642PropostaClinicaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_56") == 0 )
         {
            A323PropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaId"), "."), 18, MidpointRounding.ToEven));
            n323PropostaId = false;
            AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_56( A323PropostaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_57") == 0 )
         {
            A323PropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaId"), "."), 18, MidpointRounding.ToEven));
            n323PropostaId = false;
            AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_57( A323PropostaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_61") == 0 )
         {
            A323PropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaId"), "."), 18, MidpointRounding.ToEven));
            n323PropostaId = false;
            AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_61( A323PropostaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_62") == 0 )
         {
            A323PropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaId"), "."), 18, MidpointRounding.ToEven));
            n323PropostaId = false;
            AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_62( A323PropostaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_63") == 0 )
         {
            A323PropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaId"), "."), 18, MidpointRounding.ToEven));
            n323PropostaId = false;
            AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_63( A323PropostaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_44") == 0 )
         {
            A376ProcedimentosMedicosId = (int)(Math.Round(NumberUtil.Val( GetPar( "ProcedimentosMedicosId"), "."), 18, MidpointRounding.ToEven));
            n376ProcedimentosMedicosId = false;
            AssignAttri("", false, "A376ProcedimentosMedicosId", ((0==A376ProcedimentosMedicosId)&&IsIns( )||n376ProcedimentosMedicosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ProcedimentosMedicosId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_44( A376ProcedimentosMedicosId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_46") == 0 )
         {
            A328PropostaCratedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "PropostaCratedBy"), "."), 18, MidpointRounding.ToEven));
            n328PropostaCratedBy = false;
            AssignAttri("", false, "A328PropostaCratedBy", ((0==A328PropostaCratedBy)&&IsIns( )||n328PropostaCratedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A328PropostaCratedBy), 4, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_46( A328PropostaCratedBy) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_43") == 0 )
         {
            A227ContratoId = (int)(Math.Round(NumberUtil.Val( GetPar( "ContratoId"), "."), 18, MidpointRounding.ToEven));
            n227ContratoId = false;
            AssignAttri("", false, "A227ContratoId", ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_43( A227ContratoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_45") == 0 )
         {
            A493ConvenioCategoriaId = (int)(Math.Round(NumberUtil.Val( GetPar( "ConvenioCategoriaId"), "."), 18, MidpointRounding.ToEven));
            n493ConvenioCategoriaId = false;
            AssignAttri("", false, "A493ConvenioCategoriaId", ((0==A493ConvenioCategoriaId)&&IsIns( )||n493ConvenioCategoriaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A493ConvenioCategoriaId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_45( A493ConvenioCategoriaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_47") == 0 )
         {
            A504PropostaPacienteClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaPacienteClienteId"), "."), 18, MidpointRounding.ToEven));
            n504PropostaPacienteClienteId = false;
            AssignAttri("", false, "A504PropostaPacienteClienteId", ((0==A504PropostaPacienteClienteId)&&IsIns( )||n504PropostaPacienteClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A504PropostaPacienteClienteId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_47( A504PropostaPacienteClienteId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_58") == 0 )
         {
            A504PropostaPacienteClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaPacienteClienteId"), "."), 18, MidpointRounding.ToEven));
            n504PropostaPacienteClienteId = false;
            AssignAttri("", false, "A504PropostaPacienteClienteId", ((0==A504PropostaPacienteClienteId)&&IsIns( )||n504PropostaPacienteClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A504PropostaPacienteClienteId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_58( A504PropostaPacienteClienteId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_59") == 0 )
         {
            A504PropostaPacienteClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaPacienteClienteId"), "."), 18, MidpointRounding.ToEven));
            n504PropostaPacienteClienteId = false;
            AssignAttri("", false, "A504PropostaPacienteClienteId", ((0==A504PropostaPacienteClienteId)&&IsIns( )||n504PropostaPacienteClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A504PropostaPacienteClienteId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_59( A504PropostaPacienteClienteId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_60") == 0 )
         {
            A504PropostaPacienteClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaPacienteClienteId"), "."), 18, MidpointRounding.ToEven));
            n504PropostaPacienteClienteId = false;
            AssignAttri("", false, "A504PropostaPacienteClienteId", ((0==A504PropostaPacienteClienteId)&&IsIns( )||n504PropostaPacienteClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A504PropostaPacienteClienteId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_60( A504PropostaPacienteClienteId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_48") == 0 )
         {
            A553PropostaResponsavelId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaResponsavelId"), "."), 18, MidpointRounding.ToEven));
            n553PropostaResponsavelId = false;
            AssignAttri("", false, "A553PropostaResponsavelId", ((0==A553PropostaResponsavelId)&&IsIns( )||n553PropostaResponsavelId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A553PropostaResponsavelId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_48( A553PropostaResponsavelId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_49") == 0 )
         {
            A642PropostaClinicaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaClinicaId"), "."), 18, MidpointRounding.ToEven));
            n642PropostaClinicaId = false;
            AssignAttri("", false, "A642PropostaClinicaId", ((0==A642PropostaClinicaId)&&IsIns( )||n642PropostaClinicaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A642PropostaClinicaId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_49( A642PropostaClinicaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_50") == 0 )
         {
            A850PropostaEmpresaClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaEmpresaClienteId"), "."), 18, MidpointRounding.ToEven));
            n850PropostaEmpresaClienteId = false;
            AssignAttri("", false, "A850PropostaEmpresaClienteId", ((0==A850PropostaEmpresaClienteId)&&IsIns( )||n850PropostaEmpresaClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A850PropostaEmpresaClienteId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_50( A850PropostaEmpresaClienteId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
         {
            setAjaxEventMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else
         {
            if ( ! IsValidAjaxCall( false) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = gxfirstwebparm_bkp;
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            GxWebError = 1;
            context.HttpContext.Response.StatusCode = 403;
            context.WriteHtmlText( "<title>403 Forbidden</title>") ;
            context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
            context.WriteHtmlText( "<p /><hr />") ;
            GXUtil.WriteLog("send_http_error_code " + 403.ToString());
         }
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "proposta")), "proposta") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "proposta")))) ;
            }
            else
            {
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
            }
         }
         if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Mode");
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               Gx_mode = gxfirstwebparm;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV7PropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7PropostaId", StringUtil.LTrimStr( (decimal)(AV7PropostaId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PropostaId), "ZZZZZZZZ9"), context));
               }
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_web_controls( ) ;
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_12-186073", 0) ;
            }
         }
         Form.Meta.addItem("description", "Proposta", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPropostaTitulo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public proposta( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public proposta( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_PropostaId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7PropostaId = aP1_PropostaId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbPropostaStatus = new GXCombobox();
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         cleanup();
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbPropostaStatus.ItemCount > 0 )
         {
            A329PropostaStatus = cmbPropostaStatus.getValidValue(A329PropostaStatus);
            n329PropostaStatus = false;
            AssignAttri("", false, "A329PropostaStatus", A329PropostaStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPropostaStatus.CurrentValue = StringUtil.RTrim( A329PropostaStatus);
            AssignProp("", false, cmbPropostaStatus_Internalname, "Values", cmbPropostaStatus.ToJavascriptSource(), true);
         }
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction TableMainFixedActions", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucDvpanel_tableattributes.SetProperty("Width", Dvpanel_tableattributes_Width);
         ucDvpanel_tableattributes.SetProperty("AutoWidth", Dvpanel_tableattributes_Autowidth);
         ucDvpanel_tableattributes.SetProperty("AutoHeight", Dvpanel_tableattributes_Autoheight);
         ucDvpanel_tableattributes.SetProperty("Cls", Dvpanel_tableattributes_Cls);
         ucDvpanel_tableattributes.SetProperty("Title", Dvpanel_tableattributes_Title);
         ucDvpanel_tableattributes.SetProperty("Collapsible", Dvpanel_tableattributes_Collapsible);
         ucDvpanel_tableattributes.SetProperty("Collapsed", Dvpanel_tableattributes_Collapsed);
         ucDvpanel_tableattributes.SetProperty("ShowCollapseIcon", Dvpanel_tableattributes_Showcollapseicon);
         ucDvpanel_tableattributes.SetProperty("IconPosition", Dvpanel_tableattributes_Iconposition);
         ucDvpanel_tableattributes.SetProperty("AutoScroll", Dvpanel_tableattributes_Autoscroll);
         ucDvpanel_tableattributes.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableattributes_Internalname, "DVPANEL_TABLEATTRIBUTESContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEATTRIBUTESContainer"+"TableAttributes"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPropostaTitulo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPropostaTitulo_Internalname, "Titulo", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPropostaTitulo_Internalname, A324PropostaTitulo, StringUtil.RTrim( context.localUtil.Format( A324PropostaTitulo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaTitulo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPropostaTitulo_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Proposta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPropostaDescricao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPropostaDescricao_Internalname, "Descricao", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPropostaDescricao_Internalname, A325PropostaDescricao, StringUtil.RTrim( context.localUtil.Format( A325PropostaDescricao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaDescricao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPropostaDescricao_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Proposta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPropostaValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPropostaValor_Internalname, "Valor", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPropostaValor_Internalname, ((Convert.ToDecimal(0)==A326PropostaValor)&&IsIns( )||n326PropostaValor ? "" : StringUtil.LTrim( StringUtil.NToC( A326PropostaValor, 18, 2, ",", ""))), ((Convert.ToDecimal(0)==A326PropostaValor)&&IsIns( )||n326PropostaValor ? "" : StringUtil.LTrim( ((edtPropostaValor_Enabled!=0) ? context.localUtil.Format( A326PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A326PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaValor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPropostaValor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_Proposta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPropostaCreatedAt_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPropostaCreatedAt_Internalname, "Created At", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPropostaCreatedAt_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPropostaCreatedAt_Internalname, context.localUtil.TToC( A327PropostaCreatedAt, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A327PropostaCreatedAt, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaCreatedAt_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPropostaCreatedAt_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Proposta.htm");
         GxWebStd.gx_bitmap( context, edtPropostaCreatedAt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPropostaCreatedAt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Proposta.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedpropostacratedby_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockpropostacratedby_Internalname, "Crated By", "", "", lblTextblockpropostacratedby_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Proposta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_propostacratedby.SetProperty("Caption", Combo_propostacratedby_Caption);
         ucCombo_propostacratedby.SetProperty("Cls", Combo_propostacratedby_Cls);
         ucCombo_propostacratedby.SetProperty("DataListProc", Combo_propostacratedby_Datalistproc);
         ucCombo_propostacratedby.SetProperty("DataListProcParametersPrefix", Combo_propostacratedby_Datalistprocparametersprefix);
         ucCombo_propostacratedby.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
         ucCombo_propostacratedby.SetProperty("DropDownOptionsData", AV14PropostaCratedBy_Data);
         ucCombo_propostacratedby.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_propostacratedby_Internalname, "COMBO_PROPOSTACRATEDBYContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPropostaCratedBy_Internalname, "Proposta Crated By", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPropostaCratedBy_Internalname, ((0==A328PropostaCratedBy)&&IsIns( )||n328PropostaCratedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A328PropostaCratedBy), 4, 0, ",", ""))), ((0==A328PropostaCratedBy)&&IsIns( )||n328PropostaCratedBy ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A328PropostaCratedBy), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaCratedBy_Jsonclick, 0, "Attribute", "", "", "", "", edtPropostaCratedBy_Visible, edtPropostaCratedBy_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Proposta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbPropostaStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbPropostaStatus_Internalname, "Status", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbPropostaStatus, cmbPropostaStatus_Internalname, StringUtil.RTrim( A329PropostaStatus), 1, cmbPropostaStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbPropostaStatus.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "", true, 0, "HLP_Proposta.htm");
         cmbPropostaStatus.CurrentValue = StringUtil.RTrim( A329PropostaStatus);
         AssignProp("", false, cmbPropostaStatus_Internalname, "Values", (string)(cmbPropostaStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPropostaQuantidadeAprovadores_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPropostaQuantidadeAprovadores_Internalname, "Quantidade Aprovadores", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPropostaQuantidadeAprovadores_Internalname, ((0==A330PropostaQuantidadeAprovadores)&&IsIns( )||n330PropostaQuantidadeAprovadores ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A330PropostaQuantidadeAprovadores), 4, 0, ",", ""))), ((0==A330PropostaQuantidadeAprovadores)&&IsIns( )||n330PropostaQuantidadeAprovadores ? "" : StringUtil.LTrim( ((edtPropostaQuantidadeAprovadores_Enabled!=0) ? context.localUtil.Format( (decimal)(A330PropostaQuantidadeAprovadores), "ZZZ9") : context.localUtil.Format( (decimal)(A330PropostaQuantidadeAprovadores), "ZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaQuantidadeAprovadores_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPropostaQuantidadeAprovadores_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Proposta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedprocedimentosmedicosid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockprocedimentosmedicosid_Internalname, "Procedimentos Medicos", "", "", lblTextblockprocedimentosmedicosid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Proposta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_procedimentosmedicosid.SetProperty("Caption", Combo_procedimentosmedicosid_Caption);
         ucCombo_procedimentosmedicosid.SetProperty("Cls", Combo_procedimentosmedicosid_Cls);
         ucCombo_procedimentosmedicosid.SetProperty("DataListProc", Combo_procedimentosmedicosid_Datalistproc);
         ucCombo_procedimentosmedicosid.SetProperty("DataListProcParametersPrefix", Combo_procedimentosmedicosid_Datalistprocparametersprefix);
         ucCombo_procedimentosmedicosid.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
         ucCombo_procedimentosmedicosid.SetProperty("DropDownOptionsData", AV27ProcedimentosMedicosId_Data);
         ucCombo_procedimentosmedicosid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_procedimentosmedicosid_Internalname, "COMBO_PROCEDIMENTOSMEDICOSIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProcedimentosMedicosId_Internalname, "Procedimentos Medicos Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProcedimentosMedicosId_Internalname, ((0==A376ProcedimentosMedicosId)&&IsIns( )||n376ProcedimentosMedicosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ProcedimentosMedicosId), 9, 0, ",", ""))), ((0==A376ProcedimentosMedicosId)&&IsIns( )||n376ProcedimentosMedicosId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A376ProcedimentosMedicosId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProcedimentosMedicosId_Jsonclick, 0, "Attribute", "", "", "", "", edtProcedimentosMedicosId_Visible, edtProcedimentosMedicosId_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Proposta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPropostaReprovacoesPermitidas_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPropostaReprovacoesPermitidas_Internalname, "Reprovacoes Permitidas", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPropostaReprovacoesPermitidas_Internalname, ((0==A345PropostaReprovacoesPermitidas)&&IsIns( )||n345PropostaReprovacoesPermitidas ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A345PropostaReprovacoesPermitidas), 4, 0, ",", ""))), ((0==A345PropostaReprovacoesPermitidas)&&IsIns( )||n345PropostaReprovacoesPermitidas ? "" : StringUtil.LTrim( ((edtPropostaReprovacoesPermitidas_Enabled!=0) ? context.localUtil.Format( (decimal)(A345PropostaReprovacoesPermitidas), "ZZZ9") : context.localUtil.Format( (decimal)(A345PropostaReprovacoesPermitidas), "ZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaReprovacoesPermitidas_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPropostaReprovacoesPermitidas_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Proposta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPropostaAprovacoes_F_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPropostaAprovacoes_F_Internalname, "Aprovacoes_F", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPropostaAprovacoes_F_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A341PropostaAprovacoes_F), 4, 0, ",", "")), StringUtil.LTrim( ((edtPropostaAprovacoes_F_Enabled!=0) ? context.localUtil.Format( (decimal)(A341PropostaAprovacoes_F), "ZZZ9") : context.localUtil.Format( (decimal)(A341PropostaAprovacoes_F), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaAprovacoes_F_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPropostaAprovacoes_F_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Proposta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPropostaReprovacoes_F_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPropostaReprovacoes_F_Internalname, "Reprovacoes_F", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPropostaReprovacoes_F_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A342PropostaReprovacoes_F), 4, 0, ",", "")), StringUtil.LTrim( ((edtPropostaReprovacoes_F_Enabled!=0) ? context.localUtil.Format( (decimal)(A342PropostaReprovacoes_F), "ZZZ9") : context.localUtil.Format( (decimal)(A342PropostaReprovacoes_F), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaReprovacoes_F_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPropostaReprovacoes_F_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Proposta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPropostaAprovacoesRestantes_F_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPropostaAprovacoesRestantes_F_Internalname, "Aprovacoes Restantes_F", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPropostaAprovacoesRestantes_F_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A343PropostaAprovacoesRestantes_F), 4, 0, ",", "")), StringUtil.LTrim( ((edtPropostaAprovacoesRestantes_F_Enabled!=0) ? context.localUtil.Format( (decimal)(A343PropostaAprovacoesRestantes_F), "ZZZ9") : context.localUtil.Format( (decimal)(A343PropostaAprovacoesRestantes_F), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaAprovacoesRestantes_F_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPropostaAprovacoesRestantes_F_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Proposta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupFixedBottom CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Proposta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Proposta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Proposta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_propostacratedby_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombopropostacratedby_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ComboPropostaCratedBy), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCombopropostacratedby_Enabled!=0) ? context.localUtil.Format( (decimal)(AV19ComboPropostaCratedBy), "ZZZ9") : context.localUtil.Format( (decimal)(AV19ComboPropostaCratedBy), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,103);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombopropostacratedby_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombopropostacratedby_Visible, edtavCombopropostacratedby_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Proposta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_procedimentosmedicosid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboprocedimentosmedicosid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28ComboProcedimentosMedicosId), 9, 0, ",", "")), StringUtil.LTrim( ((edtavComboprocedimentosmedicosid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV28ComboProcedimentosMedicosId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV28ComboProcedimentosMedicosId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,105);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboprocedimentosmedicosid_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboprocedimentosmedicosid_Visible, edtavComboprocedimentosmedicosid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Proposta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPropostaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ",", "")), StringUtil.LTrim( ((edtPropostaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A323PropostaId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A323PropostaId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,106);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaId_Jsonclick, 0, "Attribute", "", "", "", "", edtPropostaId_Visible, edtPropostaId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Proposta.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E111A2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV15DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vPROPOSTACRATEDBY_DATA"), AV14PropostaCratedBy_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vPROCEDIMENTOSMEDICOSID_DATA"), AV27ProcedimentosMedicosId_Data);
               /* Read saved values. */
               Z323PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z323PropostaId"), ",", "."), 18, MidpointRounding.ToEven));
               Z327PropostaCreatedAt = context.localUtil.CToT( cgiGet( "Z327PropostaCreatedAt"), 0);
               n327PropostaCreatedAt = ((DateTime.MinValue==A327PropostaCreatedAt) ? true : false);
               Z853PropostaProtocolo = cgiGet( "Z853PropostaProtocolo");
               n853PropostaProtocolo = (String.IsNullOrEmpty(StringUtil.RTrim( A853PropostaProtocolo)) ? true : false);
               Z849PropostaTipoProposta = cgiGet( "Z849PropostaTipoProposta");
               n849PropostaTipoProposta = (String.IsNullOrEmpty(StringUtil.RTrim( A849PropostaTipoProposta)) ? true : false);
               Z324PropostaTitulo = cgiGet( "Z324PropostaTitulo");
               n324PropostaTitulo = (String.IsNullOrEmpty(StringUtil.RTrim( A324PropostaTitulo)) ? true : false);
               Z325PropostaDescricao = cgiGet( "Z325PropostaDescricao");
               n325PropostaDescricao = (String.IsNullOrEmpty(StringUtil.RTrim( A325PropostaDescricao)) ? true : false);
               Z517PropostaDataCirurgia = context.localUtil.CToD( cgiGet( "Z517PropostaDataCirurgia"), 0);
               n517PropostaDataCirurgia = ((DateTime.MinValue==A517PropostaDataCirurgia) ? true : false);
               Z326PropostaValor = context.localUtil.CToN( cgiGet( "Z326PropostaValor"), ",", ".");
               n326PropostaValor = ((Convert.ToDecimal(0)==A326PropostaValor) ? true : false);
               Z855PropostaValorLiquido = context.localUtil.CToN( cgiGet( "Z855PropostaValorLiquido"), ",", ".");
               n855PropostaValorLiquido = ((Convert.ToDecimal(0)==A855PropostaValorLiquido) ? true : false);
               Z501PropostaTaxaAdministrativa = context.localUtil.CToN( cgiGet( "Z501PropostaTaxaAdministrativa"), ",", ".");
               n501PropostaTaxaAdministrativa = ((Convert.ToDecimal(0)==A501PropostaTaxaAdministrativa) ? true : false);
               Z507PropostaSLA = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z507PropostaSLA"), ",", "."), 18, MidpointRounding.ToEven));
               n507PropostaSLA = ((0==A507PropostaSLA) ? true : false);
               Z508PropostaJurosMora = context.localUtil.CToN( cgiGet( "Z508PropostaJurosMora"), ",", ".");
               n508PropostaJurosMora = ((Convert.ToDecimal(0)==A508PropostaJurosMora) ? true : false);
               Z329PropostaStatus = cgiGet( "Z329PropostaStatus");
               n329PropostaStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A329PropostaStatus)) ? true : false);
               Z790PropostaComentarioAnalise = cgiGet( "Z790PropostaComentarioAnalise");
               n790PropostaComentarioAnalise = (String.IsNullOrEmpty(StringUtil.RTrim( A790PropostaComentarioAnalise)) ? true : false);
               Z330PropostaQuantidadeAprovadores = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z330PropostaQuantidadeAprovadores"), ",", "."), 18, MidpointRounding.ToEven));
               n330PropostaQuantidadeAprovadores = ((0==A330PropostaQuantidadeAprovadores) ? true : false);
               Z345PropostaReprovacoesPermitidas = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z345PropostaReprovacoesPermitidas"), ",", "."), 18, MidpointRounding.ToEven));
               n345PropostaReprovacoesPermitidas = ((0==A345PropostaReprovacoesPermitidas) ? true : false);
               Z496ConvenioVencimentoAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z496ConvenioVencimentoAno"), ",", "."), 18, MidpointRounding.ToEven));
               n496ConvenioVencimentoAno = ((0==A496ConvenioVencimentoAno) ? true : false);
               Z497ConvenioVencimentoMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z497ConvenioVencimentoMes"), ",", "."), 18, MidpointRounding.ToEven));
               n497ConvenioVencimentoMes = ((0==A497ConvenioVencimentoMes) ? true : false);
               Z227ContratoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z227ContratoId"), ",", "."), 18, MidpointRounding.ToEven));
               n227ContratoId = ((0==A227ContratoId) ? true : false);
               Z376ProcedimentosMedicosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z376ProcedimentosMedicosId"), ",", "."), 18, MidpointRounding.ToEven));
               n376ProcedimentosMedicosId = ((0==A376ProcedimentosMedicosId) ? true : false);
               Z493ConvenioCategoriaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z493ConvenioCategoriaId"), ",", "."), 18, MidpointRounding.ToEven));
               n493ConvenioCategoriaId = ((0==A493ConvenioCategoriaId) ? true : false);
               Z328PropostaCratedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z328PropostaCratedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n328PropostaCratedBy = ((0==A328PropostaCratedBy) ? true : false);
               Z504PropostaPacienteClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z504PropostaPacienteClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n504PropostaPacienteClienteId = ((0==A504PropostaPacienteClienteId) ? true : false);
               Z553PropostaResponsavelId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z553PropostaResponsavelId"), ",", "."), 18, MidpointRounding.ToEven));
               n553PropostaResponsavelId = ((0==A553PropostaResponsavelId) ? true : false);
               Z642PropostaClinicaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z642PropostaClinicaId"), ",", "."), 18, MidpointRounding.ToEven));
               n642PropostaClinicaId = ((0==A642PropostaClinicaId) ? true : false);
               Z850PropostaEmpresaClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z850PropostaEmpresaClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n850PropostaEmpresaClienteId = ((0==A850PropostaEmpresaClienteId) ? true : false);
               A853PropostaProtocolo = cgiGet( "Z853PropostaProtocolo");
               n853PropostaProtocolo = false;
               n853PropostaProtocolo = (String.IsNullOrEmpty(StringUtil.RTrim( A853PropostaProtocolo)) ? true : false);
               A849PropostaTipoProposta = cgiGet( "Z849PropostaTipoProposta");
               n849PropostaTipoProposta = false;
               n849PropostaTipoProposta = (String.IsNullOrEmpty(StringUtil.RTrim( A849PropostaTipoProposta)) ? true : false);
               A517PropostaDataCirurgia = context.localUtil.CToD( cgiGet( "Z517PropostaDataCirurgia"), 0);
               n517PropostaDataCirurgia = false;
               n517PropostaDataCirurgia = ((DateTime.MinValue==A517PropostaDataCirurgia) ? true : false);
               A855PropostaValorLiquido = context.localUtil.CToN( cgiGet( "Z855PropostaValorLiquido"), ",", ".");
               n855PropostaValorLiquido = false;
               n855PropostaValorLiquido = ((Convert.ToDecimal(0)==A855PropostaValorLiquido) ? true : false);
               A501PropostaTaxaAdministrativa = context.localUtil.CToN( cgiGet( "Z501PropostaTaxaAdministrativa"), ",", ".");
               n501PropostaTaxaAdministrativa = false;
               n501PropostaTaxaAdministrativa = ((Convert.ToDecimal(0)==A501PropostaTaxaAdministrativa) ? true : false);
               A507PropostaSLA = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z507PropostaSLA"), ",", "."), 18, MidpointRounding.ToEven));
               n507PropostaSLA = false;
               n507PropostaSLA = ((0==A507PropostaSLA) ? true : false);
               A508PropostaJurosMora = context.localUtil.CToN( cgiGet( "Z508PropostaJurosMora"), ",", ".");
               n508PropostaJurosMora = false;
               n508PropostaJurosMora = ((Convert.ToDecimal(0)==A508PropostaJurosMora) ? true : false);
               A790PropostaComentarioAnalise = cgiGet( "Z790PropostaComentarioAnalise");
               n790PropostaComentarioAnalise = false;
               n790PropostaComentarioAnalise = (String.IsNullOrEmpty(StringUtil.RTrim( A790PropostaComentarioAnalise)) ? true : false);
               A496ConvenioVencimentoAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z496ConvenioVencimentoAno"), ",", "."), 18, MidpointRounding.ToEven));
               n496ConvenioVencimentoAno = false;
               n496ConvenioVencimentoAno = ((0==A496ConvenioVencimentoAno) ? true : false);
               A497ConvenioVencimentoMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z497ConvenioVencimentoMes"), ",", "."), 18, MidpointRounding.ToEven));
               n497ConvenioVencimentoMes = false;
               n497ConvenioVencimentoMes = ((0==A497ConvenioVencimentoMes) ? true : false);
               A227ContratoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z227ContratoId"), ",", "."), 18, MidpointRounding.ToEven));
               n227ContratoId = false;
               n227ContratoId = ((0==A227ContratoId) ? true : false);
               A493ConvenioCategoriaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z493ConvenioCategoriaId"), ",", "."), 18, MidpointRounding.ToEven));
               n493ConvenioCategoriaId = false;
               n493ConvenioCategoriaId = ((0==A493ConvenioCategoriaId) ? true : false);
               A504PropostaPacienteClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z504PropostaPacienteClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n504PropostaPacienteClienteId = false;
               n504PropostaPacienteClienteId = ((0==A504PropostaPacienteClienteId) ? true : false);
               A553PropostaResponsavelId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z553PropostaResponsavelId"), ",", "."), 18, MidpointRounding.ToEven));
               n553PropostaResponsavelId = false;
               n553PropostaResponsavelId = ((0==A553PropostaResponsavelId) ? true : false);
               A642PropostaClinicaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z642PropostaClinicaId"), ",", "."), 18, MidpointRounding.ToEven));
               n642PropostaClinicaId = false;
               n642PropostaClinicaId = ((0==A642PropostaClinicaId) ? true : false);
               A850PropostaEmpresaClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z850PropostaEmpresaClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n850PropostaEmpresaClienteId = false;
               n850PropostaEmpresaClienteId = ((0==A850PropostaEmpresaClienteId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N850PropostaEmpresaClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N850PropostaEmpresaClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n850PropostaEmpresaClienteId = ((0==A850PropostaEmpresaClienteId) ? true : false);
               N504PropostaPacienteClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N504PropostaPacienteClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n504PropostaPacienteClienteId = ((0==A504PropostaPacienteClienteId) ? true : false);
               N553PropostaResponsavelId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N553PropostaResponsavelId"), ",", "."), 18, MidpointRounding.ToEven));
               n553PropostaResponsavelId = ((0==A553PropostaResponsavelId) ? true : false);
               N376ProcedimentosMedicosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N376ProcedimentosMedicosId"), ",", "."), 18, MidpointRounding.ToEven));
               n376ProcedimentosMedicosId = ((0==A376ProcedimentosMedicosId) ? true : false);
               N328PropostaCratedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N328PropostaCratedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n328PropostaCratedBy = ((0==A328PropostaCratedBy) ? true : false);
               N642PropostaClinicaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N642PropostaClinicaId"), ",", "."), 18, MidpointRounding.ToEven));
               n642PropostaClinicaId = ((0==A642PropostaClinicaId) ? true : false);
               N227ContratoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N227ContratoId"), ",", "."), 18, MidpointRounding.ToEven));
               n227ContratoId = ((0==A227ContratoId) ? true : false);
               N493ConvenioCategoriaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N493ConvenioCategoriaId"), ",", "."), 18, MidpointRounding.ToEven));
               n493ConvenioCategoriaId = ((0==A493ConvenioCategoriaId) ? true : false);
               A782PropostaSerasaScoreUltimaData_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( "PROPOSTASERASASCOREULTIMADATA_F"), ",", "."), 18, MidpointRounding.ToEven));
               n782PropostaSerasaScoreUltimaData_F = false;
               A783PropostaResponsavelSerasaScoreUltimaData_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( "PROPOSTARESPONSAVELSERASASCOREULTIMADATA_F"), ",", "."), 18, MidpointRounding.ToEven));
               n783PropostaResponsavelSerasaScoreUltimaData_F = false;
               A784PropostaMaiorScore_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( "PROPOSTAMAIORSCORE_F"), ",", "."), 18, MidpointRounding.ToEven));
               A786PropostaResponsavelSerasaUltimoValorRecomendado_F = context.localUtil.CToN( cgiGet( "PROPOSTARESPONSAVELSERASAULTIMOVALORRECOMENDADO_F"), ",", ".");
               n786PropostaResponsavelSerasaUltimoValorRecomendado_F = false;
               A787PropostaPacienteSerasaUltimoValorRecomendado_F = context.localUtil.CToN( cgiGet( "PROPOSTAPACIENTESERASAULTIMOVALORRECOMENDADO_F"), ",", ".");
               n787PropostaPacienteSerasaUltimoValorRecomendado_F = false;
               A788PropostaMaiorValorRecomendado = context.localUtil.CToN( cgiGet( "PROPOSTAMAIORVALORRECOMENDADO"), ",", ".");
               A501PropostaTaxaAdministrativa = context.localUtil.CToN( cgiGet( "PROPOSTATAXAADMINISTRATIVA"), ",", ".");
               n501PropostaTaxaAdministrativa = ((Convert.ToDecimal(0)==A501PropostaTaxaAdministrativa) ? true : false);
               A575PropostaTaxa_F = context.localUtil.CToN( cgiGet( "PROPOSTATAXA_F"), ",", ".");
               A515PropostaDataCreditoCliente_F = context.localUtil.CToD( cgiGet( "PROPOSTADATACREDITOCLIENTE_F"), 0);
               A507PropostaSLA = (short)(Math.Round(context.localUtil.CToN( cgiGet( "PROPOSTASLA"), ",", "."), 18, MidpointRounding.ToEven));
               n507PropostaSLA = ((0==A507PropostaSLA) ? true : false);
               A508PropostaJurosMora = context.localUtil.CToN( cgiGet( "PROPOSTAJUROSMORA"), ",", ".");
               n508PropostaJurosMora = ((Convert.ToDecimal(0)==A508PropostaJurosMora) ? true : false);
               A514PropostaValorJurosMora_F = context.localUtil.CToN( cgiGet( "PROPOSTAVALORJUROSMORA_F"), ",", ".");
               A513PropostaValorTaxa_F = context.localUtil.CToN( cgiGet( "PROPOSTAVALORTAXA_F"), ",", ".");
               AV7PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vPROPOSTAID"), ",", "."), 18, MidpointRounding.ToEven));
               AV35Insert_PropostaEmpresaClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PROPOSTAEMPRESACLIENTEID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV35Insert_PropostaEmpresaClienteId", StringUtil.LTrimStr( (decimal)(AV35Insert_PropostaEmpresaClienteId), 9, 0));
               A850PropostaEmpresaClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROPOSTAEMPRESACLIENTEID"), ",", "."), 18, MidpointRounding.ToEven));
               n850PropostaEmpresaClienteId = ((0==A850PropostaEmpresaClienteId) ? true : false);
               AV32Insert_PropostaPacienteClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PROPOSTAPACIENTECLIENTEID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV32Insert_PropostaPacienteClienteId", StringUtil.LTrimStr( (decimal)(AV32Insert_PropostaPacienteClienteId), 9, 0));
               A504PropostaPacienteClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROPOSTAPACIENTECLIENTEID"), ",", "."), 18, MidpointRounding.ToEven));
               n504PropostaPacienteClienteId = ((0==A504PropostaPacienteClienteId) ? true : false);
               AV33Insert_PropostaResponsavelId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PROPOSTARESPONSAVELID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV33Insert_PropostaResponsavelId", StringUtil.LTrimStr( (decimal)(AV33Insert_PropostaResponsavelId), 9, 0));
               A553PropostaResponsavelId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROPOSTARESPONSAVELID"), ",", "."), 18, MidpointRounding.ToEven));
               n553PropostaResponsavelId = ((0==A553PropostaResponsavelId) ? true : false);
               AV24Insert_ProcedimentosMedicosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PROCEDIMENTOSMEDICOSID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV24Insert_ProcedimentosMedicosId", StringUtil.LTrimStr( (decimal)(AV24Insert_ProcedimentosMedicosId), 9, 0));
               AV11Insert_PropostaCratedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PROPOSTACRATEDBY"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11Insert_PropostaCratedBy", StringUtil.LTrimStr( (decimal)(AV11Insert_PropostaCratedBy), 4, 0));
               AV34Insert_PropostaClinicaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PROPOSTACLINICAID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV34Insert_PropostaClinicaId", StringUtil.LTrimStr( (decimal)(AV34Insert_PropostaClinicaId), 9, 0));
               A642PropostaClinicaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROPOSTACLINICAID"), ",", "."), 18, MidpointRounding.ToEven));
               n642PropostaClinicaId = ((0==A642PropostaClinicaId) ? true : false);
               AV12Insert_ContratoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CONTRATOID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12Insert_ContratoId", StringUtil.LTrimStr( (decimal)(AV12Insert_ContratoId), 6, 0));
               A227ContratoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONTRATOID"), ",", "."), 18, MidpointRounding.ToEven));
               n227ContratoId = ((0==A227ContratoId) ? true : false);
               AV31Insert_ConvenioCategoriaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CONVENIOCATEGORIAID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV31Insert_ConvenioCategoriaId", StringUtil.LTrimStr( (decimal)(AV31Insert_ConvenioCategoriaId), 9, 0));
               A493ConvenioCategoriaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONVENIOCATEGORIAID"), ",", "."), 18, MidpointRounding.ToEven));
               n493ConvenioCategoriaId = ((0==A493ConvenioCategoriaId) ? true : false);
               A650PropostaValorTaxaClinica_F = context.localUtil.CToN( cgiGet( "PROPOSTAVALORTAXACLINICA_F"), ",", ".");
               n650PropostaValorTaxaClinica_F = false;
               A855PropostaValorLiquido = context.localUtil.CToN( cgiGet( "PROPOSTAVALORLIQUIDO"), ",", ".");
               n855PropostaValorLiquido = ((Convert.ToDecimal(0)==A855PropostaValorLiquido) ? true : false);
               A509PropostaValorReembolsado_F = context.localUtil.CToN( cgiGet( "PROPOSTAVALORREEMBOLSADO_F"), ",", ".");
               n509PropostaValorReembolsado_F = false;
               A510PropostaValorReembolsadoJuros_F = context.localUtil.CToN( cgiGet( "PROPOSTAVALORREEMBOLSADOJUROS_F"), ",", ".");
               n510PropostaValorReembolsadoJuros_F = false;
               A511PropostaValorTaxaRecebida_F = context.localUtil.CToN( cgiGet( "PROPOSTAVALORTAXARECEBIDA_F"), ",", ".");
               n511PropostaValorTaxaRecebida_F = false;
               A853PropostaProtocolo = cgiGet( "PROPOSTAPROTOCOLO");
               n853PropostaProtocolo = (String.IsNullOrEmpty(StringUtil.RTrim( A853PropostaProtocolo)) ? true : false);
               A849PropostaTipoProposta = cgiGet( "PROPOSTATIPOPROPOSTA");
               n849PropostaTipoProposta = (String.IsNullOrEmpty(StringUtil.RTrim( A849PropostaTipoProposta)) ? true : false);
               A517PropostaDataCirurgia = context.localUtil.CToD( cgiGet( "PROPOSTADATACIRURGIA"), 0);
               n517PropostaDataCirurgia = ((DateTime.MinValue==A517PropostaDataCirurgia) ? true : false);
               A790PropostaComentarioAnalise = cgiGet( "PROPOSTACOMENTARIOANALISE");
               n790PropostaComentarioAnalise = (String.IsNullOrEmpty(StringUtil.RTrim( A790PropostaComentarioAnalise)) ? true : false);
               A496ConvenioVencimentoAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( "CONVENIOVENCIMENTOANO"), ",", "."), 18, MidpointRounding.ToEven));
               n496ConvenioVencimentoAno = ((0==A496ConvenioVencimentoAno) ? true : false);
               A497ConvenioVencimentoMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( "CONVENIOVENCIMENTOMES"), ",", "."), 18, MidpointRounding.ToEven));
               n497ConvenioVencimentoMes = ((0==A497ConvenioVencimentoMes) ? true : false);
               A228ContratoNome = cgiGet( "CONTRATONOME");
               n228ContratoNome = false;
               A494ConvenioCategoriaDescricao = cgiGet( "CONVENIOCATEGORIADESCRICAO");
               n494ConvenioCategoriaDescricao = false;
               A410ConvenioId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONVENIOID"), ",", "."), 18, MidpointRounding.ToEven));
               n410ConvenioId = false;
               A512PropostaSecUserName = cgiGet( "PROPOSTASECUSERNAME");
               n512PropostaSecUserName = false;
               A505PropostaPacienteClienteRazaoSocial = cgiGet( "PROPOSTAPACIENTECLIENTERAZAOSOCIAL");
               n505PropostaPacienteClienteRazaoSocial = false;
               A540PropostaPacienteClienteDocumento = cgiGet( "PROPOSTAPACIENTECLIENTEDOCUMENTO");
               n540PropostaPacienteClienteDocumento = false;
               A541PropostaPacienteContatoEmail = cgiGet( "PROPOSTAPACIENTECONTATOEMAIL");
               n541PropostaPacienteContatoEmail = false;
               A584PropostaPacienteConta = cgiGet( "PROPOSTAPACIENTECONTA");
               n584PropostaPacienteConta = false;
               A585PropostaPacienteAgencia = cgiGet( "PROPOSTAPACIENTEAGENCIA");
               n585PropostaPacienteAgencia = false;
               A586PropostaPacienteTipoPix = cgiGet( "PROPOSTAPACIENTETIPOPIX");
               n586PropostaPacienteTipoPix = false;
               A587PropostaPacientePIX = cgiGet( "PROPOSTAPACIENTEPIX");
               n587PropostaPacientePIX = false;
               A588PropostaPacienteDepositoTipo = cgiGet( "PROPOSTAPACIENTEDEPOSITOTIPO");
               n588PropostaPacienteDepositoTipo = false;
               A620PropostaPacienteEnderecoCEP = cgiGet( "PROPOSTAPACIENTEENDERECOCEP");
               n620PropostaPacienteEnderecoCEP = false;
               A621PropostaPacienteEnderecoLogradouro = cgiGet( "PROPOSTAPACIENTEENDERECOLOGRADOURO");
               n621PropostaPacienteEnderecoLogradouro = false;
               A622PropostaPacienteEnderecoNumero = cgiGet( "PROPOSTAPACIENTEENDERECONUMERO");
               n622PropostaPacienteEnderecoNumero = false;
               A623PropostaPacienteEnderecoComplemento = cgiGet( "PROPOSTAPACIENTEENDERECOCOMPLEMENTO");
               n623PropostaPacienteEnderecoComplemento = false;
               A624PropostaPacienteEnderecoBairro = cgiGet( "PROPOSTAPACIENTEENDERECOBAIRRO");
               n624PropostaPacienteEnderecoBairro = false;
               A625PropostaPacienteMunicipioCodigo = cgiGet( "PROPOSTAPACIENTEMUNICIPIOCODIGO");
               n625PropostaPacienteMunicipioCodigo = false;
               A580PropostaResponsavelDocumento = cgiGet( "PROPOSTARESPONSAVELDOCUMENTO");
               n580PropostaResponsavelDocumento = false;
               A581PropostaResponsavelRazaoSocial = cgiGet( "PROPOSTARESPONSAVELRAZAOSOCIAL");
               n581PropostaResponsavelRazaoSocial = false;
               A582PropostaResponsavelEmail = cgiGet( "PROPOSTARESPONSAVELEMAIL");
               n582PropostaResponsavelEmail = false;
               A590PropostaResponsavelConta = cgiGet( "PROPOSTARESPONSAVELCONTA");
               n590PropostaResponsavelConta = false;
               A591PropostaResponsavelAgencia = cgiGet( "PROPOSTARESPONSAVELAGENCIA");
               n591PropostaResponsavelAgencia = false;
               A592PropostaResponsavelTipoPix = cgiGet( "PROPOSTARESPONSAVELTIPOPIX");
               n592PropostaResponsavelTipoPix = false;
               A593PropostaResponsavelPIX = cgiGet( "PROPOSTARESPONSAVELPIX");
               n593PropostaResponsavelPIX = false;
               A594PropostaResponsavelDepositoTipo = cgiGet( "PROPOSTARESPONSAVELDEPOSITOTIPO");
               n594PropostaResponsavelDepositoTipo = false;
               A643PropostaClinicaNome = cgiGet( "PROPOSTACLINICANOME");
               n643PropostaClinicaNome = false;
               A644PropostaClinicaNomeFantasia = cgiGet( "PROPOSTACLINICANOMEFANTASIA");
               n644PropostaClinicaNomeFantasia = false;
               A652PropostaClinicaDocumento = cgiGet( "PROPOSTACLINICADOCUMENTO");
               n652PropostaClinicaDocumento = false;
               A653PropostaClinicaEmail = cgiGet( "PROPOSTACLINICAEMAIL");
               n653PropostaClinicaEmail = false;
               A649PropostaMaxReembolsoId_F = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROPOSTAMAXREEMBOLSOID_F"), ",", "."), 18, MidpointRounding.ToEven));
               n649PropostaMaxReembolsoId_F = false;
               A854PropostaQtdItensNota_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( "PROPOSTAQTDITENSNOTA_F"), ",", "."), 18, MidpointRounding.ToEven));
               n854PropostaQtdItensNota_F = false;
               A733PropostaResponsavelSerasaConsultas_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( "PROPOSTARESPONSAVELSERASACONSULTAS_F"), ",", "."), 18, MidpointRounding.ToEven));
               n733PropostaResponsavelSerasaConsultas_F = false;
               A734PropostaPacienteSerasaConsultas_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( "PROPOSTAPACIENTESERASACONSULTAS_F"), ",", "."), 18, MidpointRounding.ToEven));
               n734PropostaPacienteSerasaConsultas_F = false;
               A655PropostaQtdDocumentoPendente_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( "PROPOSTAQTDDOCUMENTOPENDENTE_F"), ",", "."), 18, MidpointRounding.ToEven));
               n655PropostaQtdDocumentoPendente_F = false;
               AV36Pgmname = cgiGet( "vPGMNAME");
               Combo_propostacratedby_Objectcall = cgiGet( "COMBO_PROPOSTACRATEDBY_Objectcall");
               Combo_propostacratedby_Class = cgiGet( "COMBO_PROPOSTACRATEDBY_Class");
               Combo_propostacratedby_Icontype = cgiGet( "COMBO_PROPOSTACRATEDBY_Icontype");
               Combo_propostacratedby_Icon = cgiGet( "COMBO_PROPOSTACRATEDBY_Icon");
               Combo_propostacratedby_Caption = cgiGet( "COMBO_PROPOSTACRATEDBY_Caption");
               Combo_propostacratedby_Tooltip = cgiGet( "COMBO_PROPOSTACRATEDBY_Tooltip");
               Combo_propostacratedby_Cls = cgiGet( "COMBO_PROPOSTACRATEDBY_Cls");
               Combo_propostacratedby_Selectedvalue_set = cgiGet( "COMBO_PROPOSTACRATEDBY_Selectedvalue_set");
               Combo_propostacratedby_Selectedvalue_get = cgiGet( "COMBO_PROPOSTACRATEDBY_Selectedvalue_get");
               Combo_propostacratedby_Selectedtext_set = cgiGet( "COMBO_PROPOSTACRATEDBY_Selectedtext_set");
               Combo_propostacratedby_Selectedtext_get = cgiGet( "COMBO_PROPOSTACRATEDBY_Selectedtext_get");
               Combo_propostacratedby_Gamoauthtoken = cgiGet( "COMBO_PROPOSTACRATEDBY_Gamoauthtoken");
               Combo_propostacratedby_Ddointernalname = cgiGet( "COMBO_PROPOSTACRATEDBY_Ddointernalname");
               Combo_propostacratedby_Titlecontrolalign = cgiGet( "COMBO_PROPOSTACRATEDBY_Titlecontrolalign");
               Combo_propostacratedby_Dropdownoptionstype = cgiGet( "COMBO_PROPOSTACRATEDBY_Dropdownoptionstype");
               Combo_propostacratedby_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTACRATEDBY_Enabled"));
               Combo_propostacratedby_Visible = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTACRATEDBY_Visible"));
               Combo_propostacratedby_Titlecontrolidtoreplace = cgiGet( "COMBO_PROPOSTACRATEDBY_Titlecontrolidtoreplace");
               Combo_propostacratedby_Datalisttype = cgiGet( "COMBO_PROPOSTACRATEDBY_Datalisttype");
               Combo_propostacratedby_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTACRATEDBY_Allowmultipleselection"));
               Combo_propostacratedby_Datalistfixedvalues = cgiGet( "COMBO_PROPOSTACRATEDBY_Datalistfixedvalues");
               Combo_propostacratedby_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTACRATEDBY_Isgriditem"));
               Combo_propostacratedby_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTACRATEDBY_Hasdescription"));
               Combo_propostacratedby_Datalistproc = cgiGet( "COMBO_PROPOSTACRATEDBY_Datalistproc");
               Combo_propostacratedby_Datalistprocparametersprefix = cgiGet( "COMBO_PROPOSTACRATEDBY_Datalistprocparametersprefix");
               Combo_propostacratedby_Remoteservicesparameters = cgiGet( "COMBO_PROPOSTACRATEDBY_Remoteservicesparameters");
               Combo_propostacratedby_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_PROPOSTACRATEDBY_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_propostacratedby_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTACRATEDBY_Includeonlyselectedoption"));
               Combo_propostacratedby_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTACRATEDBY_Includeselectalloption"));
               Combo_propostacratedby_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTACRATEDBY_Emptyitem"));
               Combo_propostacratedby_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTACRATEDBY_Includeaddnewoption"));
               Combo_propostacratedby_Htmltemplate = cgiGet( "COMBO_PROPOSTACRATEDBY_Htmltemplate");
               Combo_propostacratedby_Multiplevaluestype = cgiGet( "COMBO_PROPOSTACRATEDBY_Multiplevaluestype");
               Combo_propostacratedby_Loadingdata = cgiGet( "COMBO_PROPOSTACRATEDBY_Loadingdata");
               Combo_propostacratedby_Noresultsfound = cgiGet( "COMBO_PROPOSTACRATEDBY_Noresultsfound");
               Combo_propostacratedby_Emptyitemtext = cgiGet( "COMBO_PROPOSTACRATEDBY_Emptyitemtext");
               Combo_propostacratedby_Onlyselectedvalues = cgiGet( "COMBO_PROPOSTACRATEDBY_Onlyselectedvalues");
               Combo_propostacratedby_Selectalltext = cgiGet( "COMBO_PROPOSTACRATEDBY_Selectalltext");
               Combo_propostacratedby_Multiplevaluesseparator = cgiGet( "COMBO_PROPOSTACRATEDBY_Multiplevaluesseparator");
               Combo_propostacratedby_Addnewoptiontext = cgiGet( "COMBO_PROPOSTACRATEDBY_Addnewoptiontext");
               Combo_propostacratedby_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_PROPOSTACRATEDBY_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_procedimentosmedicosid_Objectcall = cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Objectcall");
               Combo_procedimentosmedicosid_Class = cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Class");
               Combo_procedimentosmedicosid_Icontype = cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Icontype");
               Combo_procedimentosmedicosid_Icon = cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Icon");
               Combo_procedimentosmedicosid_Caption = cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Caption");
               Combo_procedimentosmedicosid_Tooltip = cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Tooltip");
               Combo_procedimentosmedicosid_Cls = cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Cls");
               Combo_procedimentosmedicosid_Selectedvalue_set = cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Selectedvalue_set");
               Combo_procedimentosmedicosid_Selectedvalue_get = cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Selectedvalue_get");
               Combo_procedimentosmedicosid_Selectedtext_set = cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Selectedtext_set");
               Combo_procedimentosmedicosid_Selectedtext_get = cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Selectedtext_get");
               Combo_procedimentosmedicosid_Gamoauthtoken = cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Gamoauthtoken");
               Combo_procedimentosmedicosid_Ddointernalname = cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Ddointernalname");
               Combo_procedimentosmedicosid_Titlecontrolalign = cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Titlecontrolalign");
               Combo_procedimentosmedicosid_Dropdownoptionstype = cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Dropdownoptionstype");
               Combo_procedimentosmedicosid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Enabled"));
               Combo_procedimentosmedicosid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Visible"));
               Combo_procedimentosmedicosid_Titlecontrolidtoreplace = cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Titlecontrolidtoreplace");
               Combo_procedimentosmedicosid_Datalisttype = cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Datalisttype");
               Combo_procedimentosmedicosid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Allowmultipleselection"));
               Combo_procedimentosmedicosid_Datalistfixedvalues = cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Datalistfixedvalues");
               Combo_procedimentosmedicosid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Isgriditem"));
               Combo_procedimentosmedicosid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Hasdescription"));
               Combo_procedimentosmedicosid_Datalistproc = cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Datalistproc");
               Combo_procedimentosmedicosid_Datalistprocparametersprefix = cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Datalistprocparametersprefix");
               Combo_procedimentosmedicosid_Remoteservicesparameters = cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Remoteservicesparameters");
               Combo_procedimentosmedicosid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_procedimentosmedicosid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Includeonlyselectedoption"));
               Combo_procedimentosmedicosid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Includeselectalloption"));
               Combo_procedimentosmedicosid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Emptyitem"));
               Combo_procedimentosmedicosid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Includeaddnewoption"));
               Combo_procedimentosmedicosid_Htmltemplate = cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Htmltemplate");
               Combo_procedimentosmedicosid_Multiplevaluestype = cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Multiplevaluestype");
               Combo_procedimentosmedicosid_Loadingdata = cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Loadingdata");
               Combo_procedimentosmedicosid_Noresultsfound = cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Noresultsfound");
               Combo_procedimentosmedicosid_Emptyitemtext = cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Emptyitemtext");
               Combo_procedimentosmedicosid_Onlyselectedvalues = cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Onlyselectedvalues");
               Combo_procedimentosmedicosid_Selectalltext = cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Selectalltext");
               Combo_procedimentosmedicosid_Multiplevaluesseparator = cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Multiplevaluesseparator");
               Combo_procedimentosmedicosid_Addnewoptiontext = cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Addnewoptiontext");
               Combo_procedimentosmedicosid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_PROCEDIMENTOSMEDICOSID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               Dvpanel_tableattributes_Objectcall = cgiGet( "DVPANEL_TABLEATTRIBUTES_Objectcall");
               Dvpanel_tableattributes_Class = cgiGet( "DVPANEL_TABLEATTRIBUTES_Class");
               Dvpanel_tableattributes_Enabled = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Enabled"));
               Dvpanel_tableattributes_Width = cgiGet( "DVPANEL_TABLEATTRIBUTES_Width");
               Dvpanel_tableattributes_Height = cgiGet( "DVPANEL_TABLEATTRIBUTES_Height");
               Dvpanel_tableattributes_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autowidth"));
               Dvpanel_tableattributes_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoheight"));
               Dvpanel_tableattributes_Cls = cgiGet( "DVPANEL_TABLEATTRIBUTES_Cls");
               Dvpanel_tableattributes_Showheader = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showheader"));
               Dvpanel_tableattributes_Title = cgiGet( "DVPANEL_TABLEATTRIBUTES_Title");
               Dvpanel_tableattributes_Titletype = cgiGet( "DVPANEL_TABLEATTRIBUTES_Titletype");
               Dvpanel_tableattributes_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsible"));
               Dvpanel_tableattributes_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsed"));
               Dvpanel_tableattributes_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showcollapseicon"));
               Dvpanel_tableattributes_Iconposition = cgiGet( "DVPANEL_TABLEATTRIBUTES_Iconposition");
               Dvpanel_tableattributes_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoscroll"));
               Dvpanel_tableattributes_Visible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Visible"));
               Dvpanel_tableattributes_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DVPANEL_TABLEATTRIBUTES_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A324PropostaTitulo = cgiGet( edtPropostaTitulo_Internalname);
               n324PropostaTitulo = false;
               AssignAttri("", false, "A324PropostaTitulo", A324PropostaTitulo);
               n324PropostaTitulo = (String.IsNullOrEmpty(StringUtil.RTrim( A324PropostaTitulo)) ? true : false);
               A325PropostaDescricao = cgiGet( edtPropostaDescricao_Internalname);
               n325PropostaDescricao = false;
               AssignAttri("", false, "A325PropostaDescricao", A325PropostaDescricao);
               n325PropostaDescricao = (String.IsNullOrEmpty(StringUtil.RTrim( A325PropostaDescricao)) ? true : false);
               n326PropostaValor = ((StringUtil.StrCmp(cgiGet( edtPropostaValor_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtPropostaValor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPropostaValor_Internalname), ",", ".") > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROPOSTAVALOR");
                  AnyError = 1;
                  GX_FocusControl = edtPropostaValor_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A326PropostaValor = 0;
                  n326PropostaValor = false;
                  AssignAttri("", false, "A326PropostaValor", (n326PropostaValor ? "" : StringUtil.LTrim( StringUtil.NToC( A326PropostaValor, 18, 2, ".", ""))));
               }
               else
               {
                  A326PropostaValor = context.localUtil.CToN( cgiGet( edtPropostaValor_Internalname), ",", ".");
                  AssignAttri("", false, "A326PropostaValor", (n326PropostaValor ? "" : StringUtil.LTrim( StringUtil.NToC( A326PropostaValor, 18, 2, ".", ""))));
               }
               if ( context.localUtil.VCDateTime( cgiGet( edtPropostaCreatedAt_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Proposta Created At"}), 1, "PROPOSTACREATEDAT");
                  AnyError = 1;
                  GX_FocusControl = edtPropostaCreatedAt_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
                  n327PropostaCreatedAt = false;
                  AssignAttri("", false, "A327PropostaCreatedAt", context.localUtil.TToC( A327PropostaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A327PropostaCreatedAt = context.localUtil.CToT( cgiGet( edtPropostaCreatedAt_Internalname));
                  n327PropostaCreatedAt = false;
                  AssignAttri("", false, "A327PropostaCreatedAt", context.localUtil.TToC( A327PropostaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               }
               n327PropostaCreatedAt = ((DateTime.MinValue==A327PropostaCreatedAt) ? true : false);
               n328PropostaCratedBy = ((StringUtil.StrCmp(cgiGet( edtPropostaCratedBy_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtPropostaCratedBy_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPropostaCratedBy_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROPOSTACRATEDBY");
                  AnyError = 1;
                  GX_FocusControl = edtPropostaCratedBy_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A328PropostaCratedBy = 0;
                  n328PropostaCratedBy = false;
                  AssignAttri("", false, "A328PropostaCratedBy", (n328PropostaCratedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A328PropostaCratedBy), 4, 0, ".", ""))));
               }
               else
               {
                  A328PropostaCratedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaCratedBy_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A328PropostaCratedBy", (n328PropostaCratedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A328PropostaCratedBy), 4, 0, ".", ""))));
               }
               cmbPropostaStatus.CurrentValue = cgiGet( cmbPropostaStatus_Internalname);
               A329PropostaStatus = cgiGet( cmbPropostaStatus_Internalname);
               n329PropostaStatus = false;
               AssignAttri("", false, "A329PropostaStatus", A329PropostaStatus);
               n329PropostaStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A329PropostaStatus)) ? true : false);
               n330PropostaQuantidadeAprovadores = ((StringUtil.StrCmp(cgiGet( edtPropostaQuantidadeAprovadores_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtPropostaQuantidadeAprovadores_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPropostaQuantidadeAprovadores_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROPOSTAQUANTIDADEAPROVADORES");
                  AnyError = 1;
                  GX_FocusControl = edtPropostaQuantidadeAprovadores_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A330PropostaQuantidadeAprovadores = 0;
                  n330PropostaQuantidadeAprovadores = false;
                  AssignAttri("", false, "A330PropostaQuantidadeAprovadores", (n330PropostaQuantidadeAprovadores ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A330PropostaQuantidadeAprovadores), 4, 0, ".", ""))));
               }
               else
               {
                  A330PropostaQuantidadeAprovadores = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaQuantidadeAprovadores_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A330PropostaQuantidadeAprovadores", (n330PropostaQuantidadeAprovadores ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A330PropostaQuantidadeAprovadores), 4, 0, ".", ""))));
               }
               n376ProcedimentosMedicosId = ((StringUtil.StrCmp(cgiGet( edtProcedimentosMedicosId_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtProcedimentosMedicosId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProcedimentosMedicosId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROCEDIMENTOSMEDICOSID");
                  AnyError = 1;
                  GX_FocusControl = edtProcedimentosMedicosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A376ProcedimentosMedicosId = 0;
                  n376ProcedimentosMedicosId = false;
                  AssignAttri("", false, "A376ProcedimentosMedicosId", (n376ProcedimentosMedicosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ProcedimentosMedicosId), 9, 0, ".", ""))));
               }
               else
               {
                  A376ProcedimentosMedicosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtProcedimentosMedicosId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A376ProcedimentosMedicosId", (n376ProcedimentosMedicosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ProcedimentosMedicosId), 9, 0, ".", ""))));
               }
               n345PropostaReprovacoesPermitidas = ((StringUtil.StrCmp(cgiGet( edtPropostaReprovacoesPermitidas_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtPropostaReprovacoesPermitidas_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPropostaReprovacoesPermitidas_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROPOSTAREPROVACOESPERMITIDAS");
                  AnyError = 1;
                  GX_FocusControl = edtPropostaReprovacoesPermitidas_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A345PropostaReprovacoesPermitidas = 0;
                  n345PropostaReprovacoesPermitidas = false;
                  AssignAttri("", false, "A345PropostaReprovacoesPermitidas", (n345PropostaReprovacoesPermitidas ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A345PropostaReprovacoesPermitidas), 4, 0, ".", ""))));
               }
               else
               {
                  A345PropostaReprovacoesPermitidas = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaReprovacoesPermitidas_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A345PropostaReprovacoesPermitidas", (n345PropostaReprovacoesPermitidas ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A345PropostaReprovacoesPermitidas), 4, 0, ".", ""))));
               }
               A341PropostaAprovacoes_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaAprovacoes_F_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n341PropostaAprovacoes_F = false;
               AssignAttri("", false, "A341PropostaAprovacoes_F", StringUtil.LTrimStr( (decimal)(A341PropostaAprovacoes_F), 4, 0));
               A342PropostaReprovacoes_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaReprovacoes_F_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n342PropostaReprovacoes_F = false;
               AssignAttri("", false, "A342PropostaReprovacoes_F", StringUtil.LTrimStr( (decimal)(A342PropostaReprovacoes_F), 4, 0));
               A343PropostaAprovacoesRestantes_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaAprovacoesRestantes_F_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A343PropostaAprovacoesRestantes_F", StringUtil.LTrimStr( (decimal)(A343PropostaAprovacoesRestantes_F), 4, 0));
               AV19ComboPropostaCratedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavCombopropostacratedby_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV19ComboPropostaCratedBy", StringUtil.LTrimStr( (decimal)(AV19ComboPropostaCratedBy), 4, 0));
               AV28ComboProcedimentosMedicosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavComboprocedimentosmedicosid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV28ComboProcedimentosMedicosId", StringUtil.LTrimStr( (decimal)(AV28ComboProcedimentosMedicosId), 9, 0));
               A323PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n323PropostaId = false;
               AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Proposta");
               A323PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n323PropostaId = false;
               AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
               forbiddenHiddens.Add("PropostaId", context.localUtil.Format( (decimal)(A323PropostaId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_PropostaEmpresaClienteId", context.localUtil.Format( (decimal)(AV35Insert_PropostaEmpresaClienteId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_PropostaPacienteClienteId", context.localUtil.Format( (decimal)(AV32Insert_PropostaPacienteClienteId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_PropostaResponsavelId", context.localUtil.Format( (decimal)(AV33Insert_PropostaResponsavelId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_ProcedimentosMedicosId", context.localUtil.Format( (decimal)(AV24Insert_ProcedimentosMedicosId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_PropostaCratedBy", context.localUtil.Format( (decimal)(AV11Insert_PropostaCratedBy), "ZZZ9"));
               forbiddenHiddens.Add("Insert_PropostaClinicaId", context.localUtil.Format( (decimal)(AV34Insert_PropostaClinicaId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_ContratoId", context.localUtil.Format( (decimal)(AV12Insert_ContratoId), "ZZZZZ9"));
               forbiddenHiddens.Add("Insert_ConvenioCategoriaId", context.localUtil.Format( (decimal)(AV31Insert_ConvenioCategoriaId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("PropostaProtocolo", StringUtil.RTrim( context.localUtil.Format( A853PropostaProtocolo, "")));
               forbiddenHiddens.Add("PropostaTipoProposta", StringUtil.RTrim( context.localUtil.Format( A849PropostaTipoProposta, "")));
               forbiddenHiddens.Add("PropostaDataCirurgia", context.localUtil.Format(A517PropostaDataCirurgia, "99/99/99"));
               forbiddenHiddens.Add("PropostaValorLiquido", context.localUtil.Format( A855PropostaValorLiquido, "ZZZ,ZZZ,ZZZ,ZZ9.99"));
               forbiddenHiddens.Add("PropostaTaxaAdministrativa", context.localUtil.Format( A501PropostaTaxaAdministrativa, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"));
               forbiddenHiddens.Add("PropostaSLA", context.localUtil.Format( (decimal)(A507PropostaSLA), "ZZZ9"));
               forbiddenHiddens.Add("PropostaJurosMora", context.localUtil.Format( A508PropostaJurosMora, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"));
               forbiddenHiddens.Add("PropostaComentarioAnalise", StringUtil.RTrim( context.localUtil.Format( A790PropostaComentarioAnalise, "")));
               forbiddenHiddens.Add("ConvenioVencimentoAno", context.localUtil.Format( (decimal)(A496ConvenioVencimentoAno), "ZZZ9"));
               forbiddenHiddens.Add("ConvenioVencimentoMes", context.localUtil.Format( (decimal)(A497ConvenioVencimentoMes), "ZZZ9"));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A323PropostaId != Z323PropostaId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("proposta:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A323PropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaId"), "."), 18, MidpointRounding.ToEven));
                  n323PropostaId = false;
                  AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode49 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode49;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound49 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1A0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PROPOSTAID");
                        AnyError = 1;
                        GX_FocusControl = edtPropostaId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
            sEvt = cgiGet( "_EventName");
            EvtGridId = cgiGet( "_EventGridId");
            EvtRowId = cgiGet( "_EventRowId");
            if ( StringUtil.Len( sEvt) > 0 )
            {
               sEvtType = StringUtil.Left( sEvt, 1);
               sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
               if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
               {
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E111A2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121A2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                     }
                     else
                     {
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E121A2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1A49( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtntrn_delete_Visible = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes1A49( ) ;
         }
         AssignProp("", false, edtavCombopropostacratedby_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombopropostacratedby_Enabled), 5, 0), true);
         AssignProp("", false, edtavComboprocedimentosmedicosid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboprocedimentosmedicosid_Enabled), 5, 0), true);
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_1A0( )
      {
         BeforeValidate1A49( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1A49( ) ;
            }
            else
            {
               CheckExtendedTable1A49( ) ;
               CloseExtendedTableCursors1A49( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption1A0( )
      {
      }

      protected void E111A2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV15DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV15DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtProcedimentosMedicosId_Visible = 0;
         AssignProp("", false, edtProcedimentosMedicosId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProcedimentosMedicosId_Visible), 5, 0), true);
         AV28ComboProcedimentosMedicosId = 0;
         AssignAttri("", false, "AV28ComboProcedimentosMedicosId", StringUtil.LTrimStr( (decimal)(AV28ComboProcedimentosMedicosId), 9, 0));
         edtavComboprocedimentosmedicosid_Visible = 0;
         AssignProp("", false, edtavComboprocedimentosmedicosid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboprocedimentosmedicosid_Visible), 5, 0), true);
         edtPropostaCratedBy_Visible = 0;
         AssignProp("", false, edtPropostaCratedBy_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPropostaCratedBy_Visible), 5, 0), true);
         AV19ComboPropostaCratedBy = 0;
         AssignAttri("", false, "AV19ComboPropostaCratedBy", StringUtil.LTrimStr( (decimal)(AV19ComboPropostaCratedBy), 4, 0));
         edtavCombopropostacratedby_Visible = 0;
         AssignProp("", false, edtavCombopropostacratedby_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombopropostacratedby_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOPROPOSTACRATEDBY' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOPROCEDIMENTOSMEDICOSID' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV36Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV37GXV1 = 1;
            AssignAttri("", false, "AV37GXV1", StringUtil.LTrimStr( (decimal)(AV37GXV1), 8, 0));
            while ( AV37GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV37GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "PropostaEmpresaClienteId") == 0 )
               {
                  AV35Insert_PropostaEmpresaClienteId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV35Insert_PropostaEmpresaClienteId", StringUtil.LTrimStr( (decimal)(AV35Insert_PropostaEmpresaClienteId), 9, 0));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "PropostaPacienteClienteId") == 0 )
               {
                  AV32Insert_PropostaPacienteClienteId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV32Insert_PropostaPacienteClienteId", StringUtil.LTrimStr( (decimal)(AV32Insert_PropostaPacienteClienteId), 9, 0));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "PropostaResponsavelId") == 0 )
               {
                  AV33Insert_PropostaResponsavelId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV33Insert_PropostaResponsavelId", StringUtil.LTrimStr( (decimal)(AV33Insert_PropostaResponsavelId), 9, 0));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "ProcedimentosMedicosId") == 0 )
               {
                  AV24Insert_ProcedimentosMedicosId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV24Insert_ProcedimentosMedicosId", StringUtil.LTrimStr( (decimal)(AV24Insert_ProcedimentosMedicosId), 9, 0));
                  if ( ! (0==AV24Insert_ProcedimentosMedicosId) )
                  {
                     AV28ComboProcedimentosMedicosId = AV24Insert_ProcedimentosMedicosId;
                     AssignAttri("", false, "AV28ComboProcedimentosMedicosId", StringUtil.LTrimStr( (decimal)(AV28ComboProcedimentosMedicosId), 9, 0));
                     Combo_procedimentosmedicosid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV28ComboProcedimentosMedicosId), 9, 0));
                     ucCombo_procedimentosmedicosid.SendProperty(context, "", false, Combo_procedimentosmedicosid_Internalname, "SelectedValue_set", Combo_procedimentosmedicosid_Selectedvalue_set);
                     GXt_char2 = AV18Combo_DataJson;
                     new propostaloaddvcombo(context ).execute(  "ProcedimentosMedicosId",  "GET",  false,  AV7PropostaId,  AV13TrnContextAtt.gxTpr_Attributevalue, out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
                     AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
                     AV18Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
                     Combo_procedimentosmedicosid_Selectedtext_set = AV17ComboSelectedText;
                     ucCombo_procedimentosmedicosid.SendProperty(context, "", false, Combo_procedimentosmedicosid_Internalname, "SelectedText_set", Combo_procedimentosmedicosid_Selectedtext_set);
                     Combo_procedimentosmedicosid_Enabled = false;
                     ucCombo_procedimentosmedicosid.SendProperty(context, "", false, Combo_procedimentosmedicosid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_procedimentosmedicosid_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "PropostaCratedBy") == 0 )
               {
                  AV11Insert_PropostaCratedBy = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_PropostaCratedBy", StringUtil.LTrimStr( (decimal)(AV11Insert_PropostaCratedBy), 4, 0));
                  if ( ! (0==AV11Insert_PropostaCratedBy) )
                  {
                     AV19ComboPropostaCratedBy = AV11Insert_PropostaCratedBy;
                     AssignAttri("", false, "AV19ComboPropostaCratedBy", StringUtil.LTrimStr( (decimal)(AV19ComboPropostaCratedBy), 4, 0));
                     Combo_propostacratedby_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV19ComboPropostaCratedBy), 4, 0));
                     ucCombo_propostacratedby.SendProperty(context, "", false, Combo_propostacratedby_Internalname, "SelectedValue_set", Combo_propostacratedby_Selectedvalue_set);
                     GXt_char2 = AV18Combo_DataJson;
                     new propostaloaddvcombo(context ).execute(  "PropostaCratedBy",  "GET",  false,  AV7PropostaId,  AV13TrnContextAtt.gxTpr_Attributevalue, out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
                     AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
                     AV18Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
                     Combo_propostacratedby_Selectedtext_set = AV17ComboSelectedText;
                     ucCombo_propostacratedby.SendProperty(context, "", false, Combo_propostacratedby_Internalname, "SelectedText_set", Combo_propostacratedby_Selectedtext_set);
                     Combo_propostacratedby_Enabled = false;
                     ucCombo_propostacratedby.SendProperty(context, "", false, Combo_propostacratedby_Internalname, "Enabled", StringUtil.BoolToStr( Combo_propostacratedby_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "PropostaClinicaId") == 0 )
               {
                  AV34Insert_PropostaClinicaId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV34Insert_PropostaClinicaId", StringUtil.LTrimStr( (decimal)(AV34Insert_PropostaClinicaId), 9, 0));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "ContratoId") == 0 )
               {
                  AV12Insert_ContratoId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_ContratoId", StringUtil.LTrimStr( (decimal)(AV12Insert_ContratoId), 6, 0));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "ConvenioCategoriaId") == 0 )
               {
                  AV31Insert_ConvenioCategoriaId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV31Insert_ConvenioCategoriaId", StringUtil.LTrimStr( (decimal)(AV31Insert_ConvenioCategoriaId), 9, 0));
               }
               AV37GXV1 = (int)(AV37GXV1+1);
               AssignAttri("", false, "AV37GXV1", StringUtil.LTrimStr( (decimal)(AV37GXV1), 8, 0));
            }
         }
         edtPropostaId_Visible = 0;
         AssignProp("", false, edtPropostaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPropostaId_Visible), 5, 0), true);
      }

      protected void E121A2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("propostaww") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S122( )
      {
         /* 'LOADCOMBOPROCEDIMENTOSMEDICOSID' Routine */
         returnInSub = false;
         GXt_char2 = AV18Combo_DataJson;
         new propostaloaddvcombo(context ).execute(  "ProcedimentosMedicosId",  Gx_mode,  false,  AV7PropostaId,  "", out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
         AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
         AV18Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
         Combo_procedimentosmedicosid_Selectedvalue_set = AV16ComboSelectedValue;
         ucCombo_procedimentosmedicosid.SendProperty(context, "", false, Combo_procedimentosmedicosid_Internalname, "SelectedValue_set", Combo_procedimentosmedicosid_Selectedvalue_set);
         Combo_procedimentosmedicosid_Selectedtext_set = AV17ComboSelectedText;
         ucCombo_procedimentosmedicosid.SendProperty(context, "", false, Combo_procedimentosmedicosid_Internalname, "SelectedText_set", Combo_procedimentosmedicosid_Selectedtext_set);
         AV28ComboProcedimentosMedicosId = (int)(Math.Round(NumberUtil.Val( AV16ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV28ComboProcedimentosMedicosId", StringUtil.LTrimStr( (decimal)(AV28ComboProcedimentosMedicosId), 9, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_procedimentosmedicosid_Enabled = false;
            ucCombo_procedimentosmedicosid.SendProperty(context, "", false, Combo_procedimentosmedicosid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_procedimentosmedicosid_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOPROPOSTACRATEDBY' Routine */
         returnInSub = false;
         GXt_char2 = AV18Combo_DataJson;
         new propostaloaddvcombo(context ).execute(  "PropostaCratedBy",  Gx_mode,  false,  AV7PropostaId,  "", out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
         AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
         AV18Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
         Combo_propostacratedby_Selectedvalue_set = AV16ComboSelectedValue;
         ucCombo_propostacratedby.SendProperty(context, "", false, Combo_propostacratedby_Internalname, "SelectedValue_set", Combo_propostacratedby_Selectedvalue_set);
         Combo_propostacratedby_Selectedtext_set = AV17ComboSelectedText;
         ucCombo_propostacratedby.SendProperty(context, "", false, Combo_propostacratedby_Internalname, "SelectedText_set", Combo_propostacratedby_Selectedtext_set);
         AV19ComboPropostaCratedBy = (short)(Math.Round(NumberUtil.Val( AV16ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV19ComboPropostaCratedBy", StringUtil.LTrimStr( (decimal)(AV19ComboPropostaCratedBy), 4, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_propostacratedby_Enabled = false;
            ucCombo_propostacratedby.SendProperty(context, "", false, Combo_propostacratedby_Internalname, "Enabled", StringUtil.BoolToStr( Combo_propostacratedby_Enabled));
         }
      }

      protected void ZM1A49( short GX_JID )
      {
         if ( ( GX_JID == 42 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z327PropostaCreatedAt = T001A3_A327PropostaCreatedAt[0];
               Z853PropostaProtocolo = T001A3_A853PropostaProtocolo[0];
               Z849PropostaTipoProposta = T001A3_A849PropostaTipoProposta[0];
               Z324PropostaTitulo = T001A3_A324PropostaTitulo[0];
               Z325PropostaDescricao = T001A3_A325PropostaDescricao[0];
               Z517PropostaDataCirurgia = T001A3_A517PropostaDataCirurgia[0];
               Z326PropostaValor = T001A3_A326PropostaValor[0];
               Z855PropostaValorLiquido = T001A3_A855PropostaValorLiquido[0];
               Z501PropostaTaxaAdministrativa = T001A3_A501PropostaTaxaAdministrativa[0];
               Z507PropostaSLA = T001A3_A507PropostaSLA[0];
               Z508PropostaJurosMora = T001A3_A508PropostaJurosMora[0];
               Z329PropostaStatus = T001A3_A329PropostaStatus[0];
               Z790PropostaComentarioAnalise = T001A3_A790PropostaComentarioAnalise[0];
               Z330PropostaQuantidadeAprovadores = T001A3_A330PropostaQuantidadeAprovadores[0];
               Z345PropostaReprovacoesPermitidas = T001A3_A345PropostaReprovacoesPermitidas[0];
               Z496ConvenioVencimentoAno = T001A3_A496ConvenioVencimentoAno[0];
               Z497ConvenioVencimentoMes = T001A3_A497ConvenioVencimentoMes[0];
               Z227ContratoId = T001A3_A227ContratoId[0];
               Z376ProcedimentosMedicosId = T001A3_A376ProcedimentosMedicosId[0];
               Z493ConvenioCategoriaId = T001A3_A493ConvenioCategoriaId[0];
               Z328PropostaCratedBy = T001A3_A328PropostaCratedBy[0];
               Z504PropostaPacienteClienteId = T001A3_A504PropostaPacienteClienteId[0];
               Z553PropostaResponsavelId = T001A3_A553PropostaResponsavelId[0];
               Z642PropostaClinicaId = T001A3_A642PropostaClinicaId[0];
               Z850PropostaEmpresaClienteId = T001A3_A850PropostaEmpresaClienteId[0];
            }
            else
            {
               Z327PropostaCreatedAt = A327PropostaCreatedAt;
               Z853PropostaProtocolo = A853PropostaProtocolo;
               Z849PropostaTipoProposta = A849PropostaTipoProposta;
               Z324PropostaTitulo = A324PropostaTitulo;
               Z325PropostaDescricao = A325PropostaDescricao;
               Z517PropostaDataCirurgia = A517PropostaDataCirurgia;
               Z326PropostaValor = A326PropostaValor;
               Z855PropostaValorLiquido = A855PropostaValorLiquido;
               Z501PropostaTaxaAdministrativa = A501PropostaTaxaAdministrativa;
               Z507PropostaSLA = A507PropostaSLA;
               Z508PropostaJurosMora = A508PropostaJurosMora;
               Z329PropostaStatus = A329PropostaStatus;
               Z790PropostaComentarioAnalise = A790PropostaComentarioAnalise;
               Z330PropostaQuantidadeAprovadores = A330PropostaQuantidadeAprovadores;
               Z345PropostaReprovacoesPermitidas = A345PropostaReprovacoesPermitidas;
               Z496ConvenioVencimentoAno = A496ConvenioVencimentoAno;
               Z497ConvenioVencimentoMes = A497ConvenioVencimentoMes;
               Z227ContratoId = A227ContratoId;
               Z376ProcedimentosMedicosId = A376ProcedimentosMedicosId;
               Z493ConvenioCategoriaId = A493ConvenioCategoriaId;
               Z328PropostaCratedBy = A328PropostaCratedBy;
               Z504PropostaPacienteClienteId = A504PropostaPacienteClienteId;
               Z553PropostaResponsavelId = A553PropostaResponsavelId;
               Z642PropostaClinicaId = A642PropostaClinicaId;
               Z850PropostaEmpresaClienteId = A850PropostaEmpresaClienteId;
            }
         }
         if ( GX_JID == -42 )
         {
            Z323PropostaId = A323PropostaId;
            Z327PropostaCreatedAt = A327PropostaCreatedAt;
            Z853PropostaProtocolo = A853PropostaProtocolo;
            Z849PropostaTipoProposta = A849PropostaTipoProposta;
            Z324PropostaTitulo = A324PropostaTitulo;
            Z325PropostaDescricao = A325PropostaDescricao;
            Z517PropostaDataCirurgia = A517PropostaDataCirurgia;
            Z326PropostaValor = A326PropostaValor;
            Z855PropostaValorLiquido = A855PropostaValorLiquido;
            Z501PropostaTaxaAdministrativa = A501PropostaTaxaAdministrativa;
            Z507PropostaSLA = A507PropostaSLA;
            Z508PropostaJurosMora = A508PropostaJurosMora;
            Z329PropostaStatus = A329PropostaStatus;
            Z790PropostaComentarioAnalise = A790PropostaComentarioAnalise;
            Z330PropostaQuantidadeAprovadores = A330PropostaQuantidadeAprovadores;
            Z345PropostaReprovacoesPermitidas = A345PropostaReprovacoesPermitidas;
            Z496ConvenioVencimentoAno = A496ConvenioVencimentoAno;
            Z497ConvenioVencimentoMes = A497ConvenioVencimentoMes;
            Z227ContratoId = A227ContratoId;
            Z376ProcedimentosMedicosId = A376ProcedimentosMedicosId;
            Z493ConvenioCategoriaId = A493ConvenioCategoriaId;
            Z328PropostaCratedBy = A328PropostaCratedBy;
            Z504PropostaPacienteClienteId = A504PropostaPacienteClienteId;
            Z553PropostaResponsavelId = A553PropostaResponsavelId;
            Z642PropostaClinicaId = A642PropostaClinicaId;
            Z850PropostaEmpresaClienteId = A850PropostaEmpresaClienteId;
            Z228ContratoNome = A228ContratoNome;
            Z494ConvenioCategoriaDescricao = A494ConvenioCategoriaDescricao;
            Z410ConvenioId = A410ConvenioId;
            Z505PropostaPacienteClienteRazaoSocial = A505PropostaPacienteClienteRazaoSocial;
            Z540PropostaPacienteClienteDocumento = A540PropostaPacienteClienteDocumento;
            Z541PropostaPacienteContatoEmail = A541PropostaPacienteContatoEmail;
            Z584PropostaPacienteConta = A584PropostaPacienteConta;
            Z585PropostaPacienteAgencia = A585PropostaPacienteAgencia;
            Z586PropostaPacienteTipoPix = A586PropostaPacienteTipoPix;
            Z587PropostaPacientePIX = A587PropostaPacientePIX;
            Z588PropostaPacienteDepositoTipo = A588PropostaPacienteDepositoTipo;
            Z620PropostaPacienteEnderecoCEP = A620PropostaPacienteEnderecoCEP;
            Z621PropostaPacienteEnderecoLogradouro = A621PropostaPacienteEnderecoLogradouro;
            Z622PropostaPacienteEnderecoNumero = A622PropostaPacienteEnderecoNumero;
            Z623PropostaPacienteEnderecoComplemento = A623PropostaPacienteEnderecoComplemento;
            Z624PropostaPacienteEnderecoBairro = A624PropostaPacienteEnderecoBairro;
            Z625PropostaPacienteMunicipioCodigo = A625PropostaPacienteMunicipioCodigo;
            Z733PropostaResponsavelSerasaConsultas_F = A733PropostaResponsavelSerasaConsultas_F;
            Z734PropostaPacienteSerasaConsultas_F = A734PropostaPacienteSerasaConsultas_F;
            Z783PropostaResponsavelSerasaScoreUltimaData_F = A783PropostaResponsavelSerasaScoreUltimaData_F;
            Z782PropostaSerasaScoreUltimaData_F = A782PropostaSerasaScoreUltimaData_F;
            Z786PropostaResponsavelSerasaUltimoValorRecomendado_F = A786PropostaResponsavelSerasaUltimoValorRecomendado_F;
            Z787PropostaPacienteSerasaUltimoValorRecomendado_F = A787PropostaPacienteSerasaUltimoValorRecomendado_F;
            Z580PropostaResponsavelDocumento = A580PropostaResponsavelDocumento;
            Z581PropostaResponsavelRazaoSocial = A581PropostaResponsavelRazaoSocial;
            Z582PropostaResponsavelEmail = A582PropostaResponsavelEmail;
            Z590PropostaResponsavelConta = A590PropostaResponsavelConta;
            Z591PropostaResponsavelAgencia = A591PropostaResponsavelAgencia;
            Z592PropostaResponsavelTipoPix = A592PropostaResponsavelTipoPix;
            Z593PropostaResponsavelPIX = A593PropostaResponsavelPIX;
            Z594PropostaResponsavelDepositoTipo = A594PropostaResponsavelDepositoTipo;
            Z643PropostaClinicaNome = A643PropostaClinicaNome;
            Z644PropostaClinicaNomeFantasia = A644PropostaClinicaNomeFantasia;
            Z652PropostaClinicaDocumento = A652PropostaClinicaDocumento;
            Z653PropostaClinicaEmail = A653PropostaClinicaEmail;
            Z649PropostaMaxReembolsoId_F = A649PropostaMaxReembolsoId_F;
            Z854PropostaQtdItensNota_F = A854PropostaQtdItensNota_F;
            Z655PropostaQtdDocumentoPendente_F = A655PropostaQtdDocumentoPendente_F;
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z512PropostaSecUserName = A512PropostaSecUserName;
         }
      }

      protected void standaloneNotModal( )
      {
         edtPropostaId_Enabled = 0;
         AssignProp("", false, edtPropostaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaId_Enabled), 5, 0), true);
         AV36Pgmname = "Proposta";
         AssignAttri("", false, "AV36Pgmname", AV36Pgmname);
         edtPropostaId_Enabled = 0;
         AssignProp("", false, edtPropostaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7PropostaId) )
         {
            A323PropostaId = AV7PropostaId;
            n323PropostaId = false;
            AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV24Insert_ProcedimentosMedicosId) )
         {
            edtProcedimentosMedicosId_Enabled = 0;
            AssignProp("", false, edtProcedimentosMedicosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProcedimentosMedicosId_Enabled), 5, 0), true);
         }
         else
         {
            edtProcedimentosMedicosId_Enabled = 1;
            AssignProp("", false, edtProcedimentosMedicosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProcedimentosMedicosId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_PropostaCratedBy) )
         {
            edtPropostaCratedBy_Enabled = 0;
            AssignProp("", false, edtPropostaCratedBy_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaCratedBy_Enabled), 5, 0), true);
         }
         else
         {
            edtPropostaCratedBy_Enabled = 1;
            AssignProp("", false, edtPropostaCratedBy_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaCratedBy_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A327PropostaCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n327PropostaCreatedAt = false;
            AssignAttri("", false, "A327PropostaCreatedAt", context.localUtil.TToC( A327PropostaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV34Insert_PropostaClinicaId) )
         {
            A642PropostaClinicaId = AV34Insert_PropostaClinicaId;
            n642PropostaClinicaId = false;
            AssignAttri("", false, "A642PropostaClinicaId", ((0==A642PropostaClinicaId)&&IsIns( )||n642PropostaClinicaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A642PropostaClinicaId), 9, 0, ".", ""))));
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtntrn_enter_Enabled = 0;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_enter_Enabled = 1;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T001A27 */
            pr_default.execute(15, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               A649PropostaMaxReembolsoId_F = T001A27_A649PropostaMaxReembolsoId_F[0];
               n649PropostaMaxReembolsoId_F = T001A27_n649PropostaMaxReembolsoId_F[0];
            }
            else
            {
               A649PropostaMaxReembolsoId_F = 0;
               n649PropostaMaxReembolsoId_F = false;
               AssignAttri("", false, "A649PropostaMaxReembolsoId_F", StringUtil.LTrimStr( (decimal)(A649PropostaMaxReembolsoId_F), 9, 0));
            }
            pr_default.close(15);
            /* Using cursor T001A29 */
            pr_default.execute(16, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               A854PropostaQtdItensNota_F = T001A29_A854PropostaQtdItensNota_F[0];
               n854PropostaQtdItensNota_F = T001A29_n854PropostaQtdItensNota_F[0];
            }
            else
            {
               A854PropostaQtdItensNota_F = 0;
               n854PropostaQtdItensNota_F = false;
               AssignAttri("", false, "A854PropostaQtdItensNota_F", StringUtil.LTrimStr( (decimal)(A854PropostaQtdItensNota_F), 4, 0));
            }
            pr_default.close(16);
            /* Using cursor T001A39 */
            pr_default.execute(20, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(20) != 101) )
            {
               A655PropostaQtdDocumentoPendente_F = T001A39_A655PropostaQtdDocumentoPendente_F[0];
               n655PropostaQtdDocumentoPendente_F = T001A39_n655PropostaQtdDocumentoPendente_F[0];
            }
            else
            {
               A655PropostaQtdDocumentoPendente_F = 0;
               n655PropostaQtdDocumentoPendente_F = false;
               AssignAttri("", false, "A655PropostaQtdDocumentoPendente_F", StringUtil.LTrimStr( (decimal)(A655PropostaQtdDocumentoPendente_F), 4, 0));
            }
            pr_default.close(20);
            /* Using cursor T001A41 */
            pr_default.execute(21, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(21) != 101) )
            {
               A341PropostaAprovacoes_F = T001A41_A341PropostaAprovacoes_F[0];
               n341PropostaAprovacoes_F = T001A41_n341PropostaAprovacoes_F[0];
               AssignAttri("", false, "A341PropostaAprovacoes_F", StringUtil.LTrimStr( (decimal)(A341PropostaAprovacoes_F), 4, 0));
            }
            else
            {
               A341PropostaAprovacoes_F = 0;
               n341PropostaAprovacoes_F = false;
               AssignAttri("", false, "A341PropostaAprovacoes_F", StringUtil.LTrimStr( (decimal)(A341PropostaAprovacoes_F), 4, 0));
            }
            pr_default.close(21);
            /* Using cursor T001A43 */
            pr_default.execute(22, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(22) != 101) )
            {
               A342PropostaReprovacoes_F = T001A43_A342PropostaReprovacoes_F[0];
               n342PropostaReprovacoes_F = T001A43_n342PropostaReprovacoes_F[0];
               AssignAttri("", false, "A342PropostaReprovacoes_F", StringUtil.LTrimStr( (decimal)(A342PropostaReprovacoes_F), 4, 0));
            }
            else
            {
               A342PropostaReprovacoes_F = 0;
               n342PropostaReprovacoes_F = false;
               AssignAttri("", false, "A342PropostaReprovacoes_F", StringUtil.LTrimStr( (decimal)(A342PropostaReprovacoes_F), 4, 0));
            }
            pr_default.close(22);
            /* Using cursor T001A10 */
            pr_default.execute(8, new Object[] {n642PropostaClinicaId, A642PropostaClinicaId});
            A643PropostaClinicaNome = T001A10_A643PropostaClinicaNome[0];
            n643PropostaClinicaNome = T001A10_n643PropostaClinicaNome[0];
            A644PropostaClinicaNomeFantasia = T001A10_A644PropostaClinicaNomeFantasia[0];
            n644PropostaClinicaNomeFantasia = T001A10_n644PropostaClinicaNomeFantasia[0];
            A652PropostaClinicaDocumento = T001A10_A652PropostaClinicaDocumento[0];
            n652PropostaClinicaDocumento = T001A10_n652PropostaClinicaDocumento[0];
            A653PropostaClinicaEmail = T001A10_A653PropostaClinicaEmail[0];
            n653PropostaClinicaEmail = T001A10_n653PropostaClinicaEmail[0];
            pr_default.close(8);
            /* Using cursor T001A25 */
            pr_default.execute(14, new Object[] {n323PropostaId, A323PropostaId, n642PropostaClinicaId, A642PropostaClinicaId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               A650PropostaValorTaxaClinica_F = T001A25_A650PropostaValorTaxaClinica_F[0];
               n650PropostaValorTaxaClinica_F = T001A25_n650PropostaValorTaxaClinica_F[0];
            }
            else
            {
               A650PropostaValorTaxaClinica_F = 0;
               n650PropostaValorTaxaClinica_F = false;
               AssignAttri("", false, "A650PropostaValorTaxaClinica_F", StringUtil.LTrimStr( A650PropostaValorTaxaClinica_F, 18, 2));
            }
            pr_default.close(14);
         }
      }

      protected void Load1A49( )
      {
         /* Using cursor T001A54 */
         pr_default.execute(23, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound49 = 1;
            A327PropostaCreatedAt = T001A54_A327PropostaCreatedAt[0];
            n327PropostaCreatedAt = T001A54_n327PropostaCreatedAt[0];
            AssignAttri("", false, "A327PropostaCreatedAt", context.localUtil.TToC( A327PropostaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            A853PropostaProtocolo = T001A54_A853PropostaProtocolo[0];
            n853PropostaProtocolo = T001A54_n853PropostaProtocolo[0];
            A849PropostaTipoProposta = T001A54_A849PropostaTipoProposta[0];
            n849PropostaTipoProposta = T001A54_n849PropostaTipoProposta[0];
            A580PropostaResponsavelDocumento = T001A54_A580PropostaResponsavelDocumento[0];
            n580PropostaResponsavelDocumento = T001A54_n580PropostaResponsavelDocumento[0];
            A581PropostaResponsavelRazaoSocial = T001A54_A581PropostaResponsavelRazaoSocial[0];
            n581PropostaResponsavelRazaoSocial = T001A54_n581PropostaResponsavelRazaoSocial[0];
            A582PropostaResponsavelEmail = T001A54_A582PropostaResponsavelEmail[0];
            n582PropostaResponsavelEmail = T001A54_n582PropostaResponsavelEmail[0];
            A590PropostaResponsavelConta = T001A54_A590PropostaResponsavelConta[0];
            n590PropostaResponsavelConta = T001A54_n590PropostaResponsavelConta[0];
            A591PropostaResponsavelAgencia = T001A54_A591PropostaResponsavelAgencia[0];
            n591PropostaResponsavelAgencia = T001A54_n591PropostaResponsavelAgencia[0];
            A592PropostaResponsavelTipoPix = T001A54_A592PropostaResponsavelTipoPix[0];
            n592PropostaResponsavelTipoPix = T001A54_n592PropostaResponsavelTipoPix[0];
            A593PropostaResponsavelPIX = T001A54_A593PropostaResponsavelPIX[0];
            n593PropostaResponsavelPIX = T001A54_n593PropostaResponsavelPIX[0];
            A594PropostaResponsavelDepositoTipo = T001A54_A594PropostaResponsavelDepositoTipo[0];
            n594PropostaResponsavelDepositoTipo = T001A54_n594PropostaResponsavelDepositoTipo[0];
            A505PropostaPacienteClienteRazaoSocial = T001A54_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = T001A54_n505PropostaPacienteClienteRazaoSocial[0];
            A540PropostaPacienteClienteDocumento = T001A54_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = T001A54_n540PropostaPacienteClienteDocumento[0];
            A541PropostaPacienteContatoEmail = T001A54_A541PropostaPacienteContatoEmail[0];
            n541PropostaPacienteContatoEmail = T001A54_n541PropostaPacienteContatoEmail[0];
            A584PropostaPacienteConta = T001A54_A584PropostaPacienteConta[0];
            n584PropostaPacienteConta = T001A54_n584PropostaPacienteConta[0];
            A585PropostaPacienteAgencia = T001A54_A585PropostaPacienteAgencia[0];
            n585PropostaPacienteAgencia = T001A54_n585PropostaPacienteAgencia[0];
            A586PropostaPacienteTipoPix = T001A54_A586PropostaPacienteTipoPix[0];
            n586PropostaPacienteTipoPix = T001A54_n586PropostaPacienteTipoPix[0];
            A587PropostaPacientePIX = T001A54_A587PropostaPacientePIX[0];
            n587PropostaPacientePIX = T001A54_n587PropostaPacientePIX[0];
            A588PropostaPacienteDepositoTipo = T001A54_A588PropostaPacienteDepositoTipo[0];
            n588PropostaPacienteDepositoTipo = T001A54_n588PropostaPacienteDepositoTipo[0];
            A620PropostaPacienteEnderecoCEP = T001A54_A620PropostaPacienteEnderecoCEP[0];
            n620PropostaPacienteEnderecoCEP = T001A54_n620PropostaPacienteEnderecoCEP[0];
            A621PropostaPacienteEnderecoLogradouro = T001A54_A621PropostaPacienteEnderecoLogradouro[0];
            n621PropostaPacienteEnderecoLogradouro = T001A54_n621PropostaPacienteEnderecoLogradouro[0];
            A622PropostaPacienteEnderecoNumero = T001A54_A622PropostaPacienteEnderecoNumero[0];
            n622PropostaPacienteEnderecoNumero = T001A54_n622PropostaPacienteEnderecoNumero[0];
            A623PropostaPacienteEnderecoComplemento = T001A54_A623PropostaPacienteEnderecoComplemento[0];
            n623PropostaPacienteEnderecoComplemento = T001A54_n623PropostaPacienteEnderecoComplemento[0];
            A624PropostaPacienteEnderecoBairro = T001A54_A624PropostaPacienteEnderecoBairro[0];
            n624PropostaPacienteEnderecoBairro = T001A54_n624PropostaPacienteEnderecoBairro[0];
            A324PropostaTitulo = T001A54_A324PropostaTitulo[0];
            n324PropostaTitulo = T001A54_n324PropostaTitulo[0];
            AssignAttri("", false, "A324PropostaTitulo", A324PropostaTitulo);
            A325PropostaDescricao = T001A54_A325PropostaDescricao[0];
            n325PropostaDescricao = T001A54_n325PropostaDescricao[0];
            AssignAttri("", false, "A325PropostaDescricao", A325PropostaDescricao);
            A517PropostaDataCirurgia = T001A54_A517PropostaDataCirurgia[0];
            n517PropostaDataCirurgia = T001A54_n517PropostaDataCirurgia[0];
            A326PropostaValor = T001A54_A326PropostaValor[0];
            n326PropostaValor = T001A54_n326PropostaValor[0];
            AssignAttri("", false, "A326PropostaValor", ((Convert.ToDecimal(0)==A326PropostaValor)&&IsIns( )||n326PropostaValor ? "" : StringUtil.LTrim( StringUtil.NToC( A326PropostaValor, 18, 2, ".", ""))));
            A855PropostaValorLiquido = T001A54_A855PropostaValorLiquido[0];
            n855PropostaValorLiquido = T001A54_n855PropostaValorLiquido[0];
            A501PropostaTaxaAdministrativa = T001A54_A501PropostaTaxaAdministrativa[0];
            n501PropostaTaxaAdministrativa = T001A54_n501PropostaTaxaAdministrativa[0];
            A507PropostaSLA = T001A54_A507PropostaSLA[0];
            n507PropostaSLA = T001A54_n507PropostaSLA[0];
            A508PropostaJurosMora = T001A54_A508PropostaJurosMora[0];
            n508PropostaJurosMora = T001A54_n508PropostaJurosMora[0];
            A643PropostaClinicaNome = T001A54_A643PropostaClinicaNome[0];
            n643PropostaClinicaNome = T001A54_n643PropostaClinicaNome[0];
            A644PropostaClinicaNomeFantasia = T001A54_A644PropostaClinicaNomeFantasia[0];
            n644PropostaClinicaNomeFantasia = T001A54_n644PropostaClinicaNomeFantasia[0];
            A652PropostaClinicaDocumento = T001A54_A652PropostaClinicaDocumento[0];
            n652PropostaClinicaDocumento = T001A54_n652PropostaClinicaDocumento[0];
            A653PropostaClinicaEmail = T001A54_A653PropostaClinicaEmail[0];
            n653PropostaClinicaEmail = T001A54_n653PropostaClinicaEmail[0];
            A512PropostaSecUserName = T001A54_A512PropostaSecUserName[0];
            n512PropostaSecUserName = T001A54_n512PropostaSecUserName[0];
            A329PropostaStatus = T001A54_A329PropostaStatus[0];
            n329PropostaStatus = T001A54_n329PropostaStatus[0];
            AssignAttri("", false, "A329PropostaStatus", A329PropostaStatus);
            A790PropostaComentarioAnalise = T001A54_A790PropostaComentarioAnalise[0];
            n790PropostaComentarioAnalise = T001A54_n790PropostaComentarioAnalise[0];
            A330PropostaQuantidadeAprovadores = T001A54_A330PropostaQuantidadeAprovadores[0];
            n330PropostaQuantidadeAprovadores = T001A54_n330PropostaQuantidadeAprovadores[0];
            AssignAttri("", false, "A330PropostaQuantidadeAprovadores", ((0==A330PropostaQuantidadeAprovadores)&&IsIns( )||n330PropostaQuantidadeAprovadores ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A330PropostaQuantidadeAprovadores), 4, 0, ".", ""))));
            A345PropostaReprovacoesPermitidas = T001A54_A345PropostaReprovacoesPermitidas[0];
            n345PropostaReprovacoesPermitidas = T001A54_n345PropostaReprovacoesPermitidas[0];
            AssignAttri("", false, "A345PropostaReprovacoesPermitidas", ((0==A345PropostaReprovacoesPermitidas)&&IsIns( )||n345PropostaReprovacoesPermitidas ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A345PropostaReprovacoesPermitidas), 4, 0, ".", ""))));
            A228ContratoNome = T001A54_A228ContratoNome[0];
            n228ContratoNome = T001A54_n228ContratoNome[0];
            A496ConvenioVencimentoAno = T001A54_A496ConvenioVencimentoAno[0];
            n496ConvenioVencimentoAno = T001A54_n496ConvenioVencimentoAno[0];
            A497ConvenioVencimentoMes = T001A54_A497ConvenioVencimentoMes[0];
            n497ConvenioVencimentoMes = T001A54_n497ConvenioVencimentoMes[0];
            A494ConvenioCategoriaDescricao = T001A54_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = T001A54_n494ConvenioCategoriaDescricao[0];
            A227ContratoId = T001A54_A227ContratoId[0];
            n227ContratoId = T001A54_n227ContratoId[0];
            A376ProcedimentosMedicosId = T001A54_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = T001A54_n376ProcedimentosMedicosId[0];
            AssignAttri("", false, "A376ProcedimentosMedicosId", ((0==A376ProcedimentosMedicosId)&&IsIns( )||n376ProcedimentosMedicosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ProcedimentosMedicosId), 9, 0, ".", ""))));
            A493ConvenioCategoriaId = T001A54_A493ConvenioCategoriaId[0];
            n493ConvenioCategoriaId = T001A54_n493ConvenioCategoriaId[0];
            A328PropostaCratedBy = T001A54_A328PropostaCratedBy[0];
            n328PropostaCratedBy = T001A54_n328PropostaCratedBy[0];
            AssignAttri("", false, "A328PropostaCratedBy", ((0==A328PropostaCratedBy)&&IsIns( )||n328PropostaCratedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A328PropostaCratedBy), 4, 0, ".", ""))));
            A504PropostaPacienteClienteId = T001A54_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = T001A54_n504PropostaPacienteClienteId[0];
            A553PropostaResponsavelId = T001A54_A553PropostaResponsavelId[0];
            n553PropostaResponsavelId = T001A54_n553PropostaResponsavelId[0];
            A642PropostaClinicaId = T001A54_A642PropostaClinicaId[0];
            n642PropostaClinicaId = T001A54_n642PropostaClinicaId[0];
            A850PropostaEmpresaClienteId = T001A54_A850PropostaEmpresaClienteId[0];
            n850PropostaEmpresaClienteId = T001A54_n850PropostaEmpresaClienteId[0];
            A410ConvenioId = T001A54_A410ConvenioId[0];
            n410ConvenioId = T001A54_n410ConvenioId[0];
            A625PropostaPacienteMunicipioCodigo = T001A54_A625PropostaPacienteMunicipioCodigo[0];
            n625PropostaPacienteMunicipioCodigo = T001A54_n625PropostaPacienteMunicipioCodigo[0];
            A649PropostaMaxReembolsoId_F = T001A54_A649PropostaMaxReembolsoId_F[0];
            n649PropostaMaxReembolsoId_F = T001A54_n649PropostaMaxReembolsoId_F[0];
            A854PropostaQtdItensNota_F = T001A54_A854PropostaQtdItensNota_F[0];
            n854PropostaQtdItensNota_F = T001A54_n854PropostaQtdItensNota_F[0];
            A733PropostaResponsavelSerasaConsultas_F = T001A54_A733PropostaResponsavelSerasaConsultas_F[0];
            n733PropostaResponsavelSerasaConsultas_F = T001A54_n733PropostaResponsavelSerasaConsultas_F[0];
            A783PropostaResponsavelSerasaScoreUltimaData_F = T001A54_A783PropostaResponsavelSerasaScoreUltimaData_F[0];
            n783PropostaResponsavelSerasaScoreUltimaData_F = T001A54_n783PropostaResponsavelSerasaScoreUltimaData_F[0];
            A786PropostaResponsavelSerasaUltimoValorRecomendado_F = T001A54_A786PropostaResponsavelSerasaUltimoValorRecomendado_F[0];
            n786PropostaResponsavelSerasaUltimoValorRecomendado_F = T001A54_n786PropostaResponsavelSerasaUltimoValorRecomendado_F[0];
            A734PropostaPacienteSerasaConsultas_F = T001A54_A734PropostaPacienteSerasaConsultas_F[0];
            n734PropostaPacienteSerasaConsultas_F = T001A54_n734PropostaPacienteSerasaConsultas_F[0];
            A782PropostaSerasaScoreUltimaData_F = T001A54_A782PropostaSerasaScoreUltimaData_F[0];
            n782PropostaSerasaScoreUltimaData_F = T001A54_n782PropostaSerasaScoreUltimaData_F[0];
            A787PropostaPacienteSerasaUltimoValorRecomendado_F = T001A54_A787PropostaPacienteSerasaUltimoValorRecomendado_F[0];
            n787PropostaPacienteSerasaUltimoValorRecomendado_F = T001A54_n787PropostaPacienteSerasaUltimoValorRecomendado_F[0];
            A655PropostaQtdDocumentoPendente_F = T001A54_A655PropostaQtdDocumentoPendente_F[0];
            n655PropostaQtdDocumentoPendente_F = T001A54_n655PropostaQtdDocumentoPendente_F[0];
            A341PropostaAprovacoes_F = T001A54_A341PropostaAprovacoes_F[0];
            n341PropostaAprovacoes_F = T001A54_n341PropostaAprovacoes_F[0];
            AssignAttri("", false, "A341PropostaAprovacoes_F", StringUtil.LTrimStr( (decimal)(A341PropostaAprovacoes_F), 4, 0));
            A342PropostaReprovacoes_F = T001A54_A342PropostaReprovacoes_F[0];
            n342PropostaReprovacoes_F = T001A54_n342PropostaReprovacoes_F[0];
            AssignAttri("", false, "A342PropostaReprovacoes_F", StringUtil.LTrimStr( (decimal)(A342PropostaReprovacoes_F), 4, 0));
            ZM1A49( -42) ;
         }
         pr_default.close(23);
         OnLoadActions1A49( ) ;
      }

      protected void OnLoadActions1A49( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV35Insert_PropostaEmpresaClienteId) )
         {
            A850PropostaEmpresaClienteId = AV35Insert_PropostaEmpresaClienteId;
            n850PropostaEmpresaClienteId = false;
            AssignAttri("", false, "A850PropostaEmpresaClienteId", ((0==A850PropostaEmpresaClienteId)&&IsIns( )||n850PropostaEmpresaClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A850PropostaEmpresaClienteId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A850PropostaEmpresaClienteId) )
            {
               A850PropostaEmpresaClienteId = 0;
               n850PropostaEmpresaClienteId = false;
               AssignAttri("", false, "A850PropostaEmpresaClienteId", ((0==A850PropostaEmpresaClienteId)&&IsIns( )||n850PropostaEmpresaClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A850PropostaEmpresaClienteId), 9, 0, ".", ""))));
               n850PropostaEmpresaClienteId = true;
               n850PropostaEmpresaClienteId = true;
               AssignAttri("", false, "A850PropostaEmpresaClienteId", ((0==A850PropostaEmpresaClienteId)&&IsIns( )||n850PropostaEmpresaClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A850PropostaEmpresaClienteId), 9, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV32Insert_PropostaPacienteClienteId) )
         {
            A504PropostaPacienteClienteId = AV32Insert_PropostaPacienteClienteId;
            n504PropostaPacienteClienteId = false;
            AssignAttri("", false, "A504PropostaPacienteClienteId", ((0==A504PropostaPacienteClienteId)&&IsIns( )||n504PropostaPacienteClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A504PropostaPacienteClienteId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A504PropostaPacienteClienteId) )
            {
               A504PropostaPacienteClienteId = 0;
               n504PropostaPacienteClienteId = false;
               AssignAttri("", false, "A504PropostaPacienteClienteId", ((0==A504PropostaPacienteClienteId)&&IsIns( )||n504PropostaPacienteClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A504PropostaPacienteClienteId), 9, 0, ".", ""))));
               n504PropostaPacienteClienteId = true;
               n504PropostaPacienteClienteId = true;
               AssignAttri("", false, "A504PropostaPacienteClienteId", ((0==A504PropostaPacienteClienteId)&&IsIns( )||n504PropostaPacienteClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A504PropostaPacienteClienteId), 9, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV33Insert_PropostaResponsavelId) )
         {
            A553PropostaResponsavelId = AV33Insert_PropostaResponsavelId;
            n553PropostaResponsavelId = false;
            AssignAttri("", false, "A553PropostaResponsavelId", ((0==A553PropostaResponsavelId)&&IsIns( )||n553PropostaResponsavelId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A553PropostaResponsavelId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A553PropostaResponsavelId) )
            {
               A553PropostaResponsavelId = 0;
               n553PropostaResponsavelId = false;
               AssignAttri("", false, "A553PropostaResponsavelId", ((0==A553PropostaResponsavelId)&&IsIns( )||n553PropostaResponsavelId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A553PropostaResponsavelId), 9, 0, ".", ""))));
               n553PropostaResponsavelId = true;
               n553PropostaResponsavelId = true;
               AssignAttri("", false, "A553PropostaResponsavelId", ((0==A553PropostaResponsavelId)&&IsIns( )||n553PropostaResponsavelId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A553PropostaResponsavelId), 9, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV24Insert_ProcedimentosMedicosId) )
         {
            A376ProcedimentosMedicosId = AV24Insert_ProcedimentosMedicosId;
            n376ProcedimentosMedicosId = false;
            AssignAttri("", false, "A376ProcedimentosMedicosId", ((0==A376ProcedimentosMedicosId)&&IsIns( )||n376ProcedimentosMedicosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ProcedimentosMedicosId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV28ComboProcedimentosMedicosId) )
            {
               A376ProcedimentosMedicosId = 0;
               n376ProcedimentosMedicosId = false;
               AssignAttri("", false, "A376ProcedimentosMedicosId", ((0==A376ProcedimentosMedicosId)&&IsIns( )||n376ProcedimentosMedicosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ProcedimentosMedicosId), 9, 0, ".", ""))));
               n376ProcedimentosMedicosId = true;
               n376ProcedimentosMedicosId = true;
               AssignAttri("", false, "A376ProcedimentosMedicosId", ((0==A376ProcedimentosMedicosId)&&IsIns( )||n376ProcedimentosMedicosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ProcedimentosMedicosId), 9, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV28ComboProcedimentosMedicosId) )
               {
                  A376ProcedimentosMedicosId = AV28ComboProcedimentosMedicosId;
                  n376ProcedimentosMedicosId = false;
                  AssignAttri("", false, "A376ProcedimentosMedicosId", ((0==A376ProcedimentosMedicosId)&&IsIns( )||n376ProcedimentosMedicosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ProcedimentosMedicosId), 9, 0, ".", ""))));
               }
               else
               {
                  if ( (0==A376ProcedimentosMedicosId) )
                  {
                     A376ProcedimentosMedicosId = 0;
                     n376ProcedimentosMedicosId = false;
                     AssignAttri("", false, "A376ProcedimentosMedicosId", ((0==A376ProcedimentosMedicosId)&&IsIns( )||n376ProcedimentosMedicosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ProcedimentosMedicosId), 9, 0, ".", ""))));
                     n376ProcedimentosMedicosId = true;
                     n376ProcedimentosMedicosId = true;
                     AssignAttri("", false, "A376ProcedimentosMedicosId", ((0==A376ProcedimentosMedicosId)&&IsIns( )||n376ProcedimentosMedicosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ProcedimentosMedicosId), 9, 0, ".", ""))));
                  }
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_PropostaCratedBy) )
         {
            A328PropostaCratedBy = AV11Insert_PropostaCratedBy;
            n328PropostaCratedBy = false;
            AssignAttri("", false, "A328PropostaCratedBy", ((0==A328PropostaCratedBy)&&IsIns( )||n328PropostaCratedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A328PropostaCratedBy), 4, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV19ComboPropostaCratedBy) )
            {
               A328PropostaCratedBy = 0;
               n328PropostaCratedBy = false;
               AssignAttri("", false, "A328PropostaCratedBy", ((0==A328PropostaCratedBy)&&IsIns( )||n328PropostaCratedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A328PropostaCratedBy), 4, 0, ".", ""))));
               n328PropostaCratedBy = true;
               n328PropostaCratedBy = true;
               AssignAttri("", false, "A328PropostaCratedBy", ((0==A328PropostaCratedBy)&&IsIns( )||n328PropostaCratedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A328PropostaCratedBy), 4, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV19ComboPropostaCratedBy) )
               {
                  A328PropostaCratedBy = AV19ComboPropostaCratedBy;
                  n328PropostaCratedBy = false;
                  AssignAttri("", false, "A328PropostaCratedBy", ((0==A328PropostaCratedBy)&&IsIns( )||n328PropostaCratedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A328PropostaCratedBy), 4, 0, ".", ""))));
               }
               else
               {
                  if ( (0==A328PropostaCratedBy) )
                  {
                     A328PropostaCratedBy = 0;
                     n328PropostaCratedBy = false;
                     AssignAttri("", false, "A328PropostaCratedBy", ((0==A328PropostaCratedBy)&&IsIns( )||n328PropostaCratedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A328PropostaCratedBy), 4, 0, ".", ""))));
                     n328PropostaCratedBy = true;
                     n328PropostaCratedBy = true;
                     AssignAttri("", false, "A328PropostaCratedBy", ((0==A328PropostaCratedBy)&&IsIns( )||n328PropostaCratedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A328PropostaCratedBy), 4, 0, ".", ""))));
                  }
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_ContratoId) )
         {
            A227ContratoId = AV12Insert_ContratoId;
            n227ContratoId = false;
            AssignAttri("", false, "A227ContratoId", ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
         }
         else
         {
            if ( (0==A227ContratoId) )
            {
               A227ContratoId = 0;
               n227ContratoId = false;
               AssignAttri("", false, "A227ContratoId", ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
               n227ContratoId = true;
               n227ContratoId = true;
               AssignAttri("", false, "A227ContratoId", ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV31Insert_ConvenioCategoriaId) )
         {
            A493ConvenioCategoriaId = AV31Insert_ConvenioCategoriaId;
            n493ConvenioCategoriaId = false;
            AssignAttri("", false, "A493ConvenioCategoriaId", ((0==A493ConvenioCategoriaId)&&IsIns( )||n493ConvenioCategoriaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A493ConvenioCategoriaId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A493ConvenioCategoriaId) )
            {
               A493ConvenioCategoriaId = 0;
               n493ConvenioCategoriaId = false;
               AssignAttri("", false, "A493ConvenioCategoriaId", ((0==A493ConvenioCategoriaId)&&IsIns( )||n493ConvenioCategoriaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A493ConvenioCategoriaId), 9, 0, ".", ""))));
               n493ConvenioCategoriaId = true;
               n493ConvenioCategoriaId = true;
               AssignAttri("", false, "A493ConvenioCategoriaId", ((0==A493ConvenioCategoriaId)&&IsIns( )||n493ConvenioCategoriaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A493ConvenioCategoriaId), 9, 0, ".", ""))));
            }
         }
         /* Using cursor T001A14 */
         pr_default.execute(10, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId, n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            A509PropostaValorReembolsado_F = T001A14_A509PropostaValorReembolsado_F[0];
            n509PropostaValorReembolsado_F = T001A14_n509PropostaValorReembolsado_F[0];
         }
         else
         {
            A509PropostaValorReembolsado_F = 0;
            n509PropostaValorReembolsado_F = false;
            AssignAttri("", false, "A509PropostaValorReembolsado_F", StringUtil.LTrimStr( A509PropostaValorReembolsado_F, 18, 2));
         }
         pr_default.close(10);
         /* Using cursor T001A17 */
         pr_default.execute(11, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId, n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            A510PropostaValorReembolsadoJuros_F = T001A17_A510PropostaValorReembolsadoJuros_F[0];
            n510PropostaValorReembolsadoJuros_F = T001A17_n510PropostaValorReembolsadoJuros_F[0];
         }
         else
         {
            A510PropostaValorReembolsadoJuros_F = 0;
            n510PropostaValorReembolsadoJuros_F = false;
            AssignAttri("", false, "A510PropostaValorReembolsadoJuros_F", StringUtil.LTrimStr( A510PropostaValorReembolsadoJuros_F, 18, 2));
         }
         pr_default.close(11);
         /* Using cursor T001A20 */
         pr_default.execute(12, new Object[] {n328PropostaCratedBy, A328PropostaCratedBy, n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            A511PropostaValorTaxaRecebida_F = T001A20_A511PropostaValorTaxaRecebida_F[0];
            n511PropostaValorTaxaRecebida_F = T001A20_n511PropostaValorTaxaRecebida_F[0];
         }
         else
         {
            A511PropostaValorTaxaRecebida_F = 0;
            n511PropostaValorTaxaRecebida_F = false;
            AssignAttri("", false, "A511PropostaValorTaxaRecebida_F", StringUtil.LTrimStr( A511PropostaValorTaxaRecebida_F, 18, 2));
         }
         pr_default.close(12);
         /* Using cursor T001A23 */
         pr_default.execute(13, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId, n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            A515PropostaDataCreditoCliente_F = T001A23_A515PropostaDataCreditoCliente_F[0];
            n515PropostaDataCreditoCliente_F = T001A23_n515PropostaDataCreditoCliente_F[0];
         }
         else
         {
            A515PropostaDataCreditoCliente_F = DateTime.MinValue;
            n515PropostaDataCreditoCliente_F = false;
            AssignAttri("", false, "A515PropostaDataCreditoCliente_F", context.localUtil.Format(A515PropostaDataCreditoCliente_F, "99/99/9999"));
         }
         pr_default.close(13);
         GXt_decimal3 = A514PropostaValorJurosMora_F;
         new prcalcularjurosmora(context ).execute(  A515PropostaDataCreditoCliente_F,  A507PropostaSLA,  A508PropostaJurosMora,  A326PropostaValor, out  GXt_decimal3) ;
         A514PropostaValorJurosMora_F = GXt_decimal3;
         AssignAttri("", false, "A514PropostaValorJurosMora_F", StringUtil.LTrimStr( A514PropostaValorJurosMora_F, 18, 2));
         /* Using cursor T001A25 */
         pr_default.execute(14, new Object[] {n323PropostaId, A323PropostaId, n642PropostaClinicaId, A642PropostaClinicaId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            A650PropostaValorTaxaClinica_F = T001A25_A650PropostaValorTaxaClinica_F[0];
            n650PropostaValorTaxaClinica_F = T001A25_n650PropostaValorTaxaClinica_F[0];
         }
         else
         {
            A650PropostaValorTaxaClinica_F = 0;
            n650PropostaValorTaxaClinica_F = false;
            AssignAttri("", false, "A650PropostaValorTaxaClinica_F", StringUtil.LTrimStr( A650PropostaValorTaxaClinica_F, 18, 2));
         }
         pr_default.close(14);
         A343PropostaAprovacoesRestantes_F = (short)(A330PropostaQuantidadeAprovadores-A341PropostaAprovacoes_F);
         AssignAttri("", false, "A343PropostaAprovacoesRestantes_F", StringUtil.LTrimStr( (decimal)(A343PropostaAprovacoesRestantes_F), 4, 0));
         A575PropostaTaxa_F = (decimal)(A326PropostaValor*(A501PropostaTaxaAdministrativa/ (decimal)(100)));
         AssignAttri("", false, "A575PropostaTaxa_F", StringUtil.LTrimStr( A575PropostaTaxa_F, 18, 2));
         A513PropostaValorTaxa_F = (decimal)(A326PropostaValor*(A501PropostaTaxaAdministrativa/ (decimal)(100)));
         AssignAttri("", false, "A513PropostaValorTaxa_F", StringUtil.LTrimStr( A513PropostaValorTaxa_F, 18, 2));
         A784PropostaMaiorScore_F = (short)(((A782PropostaSerasaScoreUltimaData_F>A783PropostaResponsavelSerasaScoreUltimaData_F) ? A782PropostaSerasaScoreUltimaData_F : A783PropostaResponsavelSerasaScoreUltimaData_F));
         AssignAttri("", false, "A784PropostaMaiorScore_F", StringUtil.LTrimStr( (decimal)(A784PropostaMaiorScore_F), 4, 0));
         A788PropostaMaiorValorRecomendado = ((A786PropostaResponsavelSerasaUltimoValorRecomendado_F>A787PropostaPacienteSerasaUltimoValorRecomendado_F) ? A786PropostaResponsavelSerasaUltimoValorRecomendado_F : A787PropostaPacienteSerasaUltimoValorRecomendado_F);
         AssignAttri("", false, "A788PropostaMaiorValorRecomendado", StringUtil.LTrimStr( A788PropostaMaiorValorRecomendado, 18, 2));
      }

      protected void CheckExtendedTable1A49( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV35Insert_PropostaEmpresaClienteId) )
         {
            A850PropostaEmpresaClienteId = AV35Insert_PropostaEmpresaClienteId;
            n850PropostaEmpresaClienteId = false;
            AssignAttri("", false, "A850PropostaEmpresaClienteId", ((0==A850PropostaEmpresaClienteId)&&IsIns( )||n850PropostaEmpresaClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A850PropostaEmpresaClienteId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A850PropostaEmpresaClienteId) )
            {
               A850PropostaEmpresaClienteId = 0;
               n850PropostaEmpresaClienteId = false;
               AssignAttri("", false, "A850PropostaEmpresaClienteId", ((0==A850PropostaEmpresaClienteId)&&IsIns( )||n850PropostaEmpresaClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A850PropostaEmpresaClienteId), 9, 0, ".", ""))));
               n850PropostaEmpresaClienteId = true;
               n850PropostaEmpresaClienteId = true;
               AssignAttri("", false, "A850PropostaEmpresaClienteId", ((0==A850PropostaEmpresaClienteId)&&IsIns( )||n850PropostaEmpresaClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A850PropostaEmpresaClienteId), 9, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV32Insert_PropostaPacienteClienteId) )
         {
            A504PropostaPacienteClienteId = AV32Insert_PropostaPacienteClienteId;
            n504PropostaPacienteClienteId = false;
            AssignAttri("", false, "A504PropostaPacienteClienteId", ((0==A504PropostaPacienteClienteId)&&IsIns( )||n504PropostaPacienteClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A504PropostaPacienteClienteId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A504PropostaPacienteClienteId) )
            {
               A504PropostaPacienteClienteId = 0;
               n504PropostaPacienteClienteId = false;
               AssignAttri("", false, "A504PropostaPacienteClienteId", ((0==A504PropostaPacienteClienteId)&&IsIns( )||n504PropostaPacienteClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A504PropostaPacienteClienteId), 9, 0, ".", ""))));
               n504PropostaPacienteClienteId = true;
               n504PropostaPacienteClienteId = true;
               AssignAttri("", false, "A504PropostaPacienteClienteId", ((0==A504PropostaPacienteClienteId)&&IsIns( )||n504PropostaPacienteClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A504PropostaPacienteClienteId), 9, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV33Insert_PropostaResponsavelId) )
         {
            A553PropostaResponsavelId = AV33Insert_PropostaResponsavelId;
            n553PropostaResponsavelId = false;
            AssignAttri("", false, "A553PropostaResponsavelId", ((0==A553PropostaResponsavelId)&&IsIns( )||n553PropostaResponsavelId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A553PropostaResponsavelId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A553PropostaResponsavelId) )
            {
               A553PropostaResponsavelId = 0;
               n553PropostaResponsavelId = false;
               AssignAttri("", false, "A553PropostaResponsavelId", ((0==A553PropostaResponsavelId)&&IsIns( )||n553PropostaResponsavelId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A553PropostaResponsavelId), 9, 0, ".", ""))));
               n553PropostaResponsavelId = true;
               n553PropostaResponsavelId = true;
               AssignAttri("", false, "A553PropostaResponsavelId", ((0==A553PropostaResponsavelId)&&IsIns( )||n553PropostaResponsavelId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A553PropostaResponsavelId), 9, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV24Insert_ProcedimentosMedicosId) )
         {
            A376ProcedimentosMedicosId = AV24Insert_ProcedimentosMedicosId;
            n376ProcedimentosMedicosId = false;
            AssignAttri("", false, "A376ProcedimentosMedicosId", ((0==A376ProcedimentosMedicosId)&&IsIns( )||n376ProcedimentosMedicosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ProcedimentosMedicosId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV28ComboProcedimentosMedicosId) )
            {
               A376ProcedimentosMedicosId = 0;
               n376ProcedimentosMedicosId = false;
               AssignAttri("", false, "A376ProcedimentosMedicosId", ((0==A376ProcedimentosMedicosId)&&IsIns( )||n376ProcedimentosMedicosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ProcedimentosMedicosId), 9, 0, ".", ""))));
               n376ProcedimentosMedicosId = true;
               n376ProcedimentosMedicosId = true;
               AssignAttri("", false, "A376ProcedimentosMedicosId", ((0==A376ProcedimentosMedicosId)&&IsIns( )||n376ProcedimentosMedicosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ProcedimentosMedicosId), 9, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV28ComboProcedimentosMedicosId) )
               {
                  A376ProcedimentosMedicosId = AV28ComboProcedimentosMedicosId;
                  n376ProcedimentosMedicosId = false;
                  AssignAttri("", false, "A376ProcedimentosMedicosId", ((0==A376ProcedimentosMedicosId)&&IsIns( )||n376ProcedimentosMedicosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ProcedimentosMedicosId), 9, 0, ".", ""))));
               }
               else
               {
                  if ( (0==A376ProcedimentosMedicosId) )
                  {
                     A376ProcedimentosMedicosId = 0;
                     n376ProcedimentosMedicosId = false;
                     AssignAttri("", false, "A376ProcedimentosMedicosId", ((0==A376ProcedimentosMedicosId)&&IsIns( )||n376ProcedimentosMedicosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ProcedimentosMedicosId), 9, 0, ".", ""))));
                     n376ProcedimentosMedicosId = true;
                     n376ProcedimentosMedicosId = true;
                     AssignAttri("", false, "A376ProcedimentosMedicosId", ((0==A376ProcedimentosMedicosId)&&IsIns( )||n376ProcedimentosMedicosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ProcedimentosMedicosId), 9, 0, ".", ""))));
                  }
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_PropostaCratedBy) )
         {
            A328PropostaCratedBy = AV11Insert_PropostaCratedBy;
            n328PropostaCratedBy = false;
            AssignAttri("", false, "A328PropostaCratedBy", ((0==A328PropostaCratedBy)&&IsIns( )||n328PropostaCratedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A328PropostaCratedBy), 4, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV19ComboPropostaCratedBy) )
            {
               A328PropostaCratedBy = 0;
               n328PropostaCratedBy = false;
               AssignAttri("", false, "A328PropostaCratedBy", ((0==A328PropostaCratedBy)&&IsIns( )||n328PropostaCratedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A328PropostaCratedBy), 4, 0, ".", ""))));
               n328PropostaCratedBy = true;
               n328PropostaCratedBy = true;
               AssignAttri("", false, "A328PropostaCratedBy", ((0==A328PropostaCratedBy)&&IsIns( )||n328PropostaCratedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A328PropostaCratedBy), 4, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV19ComboPropostaCratedBy) )
               {
                  A328PropostaCratedBy = AV19ComboPropostaCratedBy;
                  n328PropostaCratedBy = false;
                  AssignAttri("", false, "A328PropostaCratedBy", ((0==A328PropostaCratedBy)&&IsIns( )||n328PropostaCratedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A328PropostaCratedBy), 4, 0, ".", ""))));
               }
               else
               {
                  if ( (0==A328PropostaCratedBy) )
                  {
                     A328PropostaCratedBy = 0;
                     n328PropostaCratedBy = false;
                     AssignAttri("", false, "A328PropostaCratedBy", ((0==A328PropostaCratedBy)&&IsIns( )||n328PropostaCratedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A328PropostaCratedBy), 4, 0, ".", ""))));
                     n328PropostaCratedBy = true;
                     n328PropostaCratedBy = true;
                     AssignAttri("", false, "A328PropostaCratedBy", ((0==A328PropostaCratedBy)&&IsIns( )||n328PropostaCratedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A328PropostaCratedBy), 4, 0, ".", ""))));
                  }
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_ContratoId) )
         {
            A227ContratoId = AV12Insert_ContratoId;
            n227ContratoId = false;
            AssignAttri("", false, "A227ContratoId", ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
         }
         else
         {
            if ( (0==A227ContratoId) )
            {
               A227ContratoId = 0;
               n227ContratoId = false;
               AssignAttri("", false, "A227ContratoId", ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
               n227ContratoId = true;
               n227ContratoId = true;
               AssignAttri("", false, "A227ContratoId", ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV31Insert_ConvenioCategoriaId) )
         {
            A493ConvenioCategoriaId = AV31Insert_ConvenioCategoriaId;
            n493ConvenioCategoriaId = false;
            AssignAttri("", false, "A493ConvenioCategoriaId", ((0==A493ConvenioCategoriaId)&&IsIns( )||n493ConvenioCategoriaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A493ConvenioCategoriaId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A493ConvenioCategoriaId) )
            {
               A493ConvenioCategoriaId = 0;
               n493ConvenioCategoriaId = false;
               AssignAttri("", false, "A493ConvenioCategoriaId", ((0==A493ConvenioCategoriaId)&&IsIns( )||n493ConvenioCategoriaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A493ConvenioCategoriaId), 9, 0, ".", ""))));
               n493ConvenioCategoriaId = true;
               n493ConvenioCategoriaId = true;
               AssignAttri("", false, "A493ConvenioCategoriaId", ((0==A493ConvenioCategoriaId)&&IsIns( )||n493ConvenioCategoriaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A493ConvenioCategoriaId), 9, 0, ".", ""))));
            }
         }
         /* Using cursor T001A14 */
         pr_default.execute(10, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId, n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            A509PropostaValorReembolsado_F = T001A14_A509PropostaValorReembolsado_F[0];
            n509PropostaValorReembolsado_F = T001A14_n509PropostaValorReembolsado_F[0];
         }
         else
         {
            A509PropostaValorReembolsado_F = 0;
            n509PropostaValorReembolsado_F = false;
            AssignAttri("", false, "A509PropostaValorReembolsado_F", StringUtil.LTrimStr( A509PropostaValorReembolsado_F, 18, 2));
         }
         pr_default.close(10);
         if ( ( A509PropostaValorReembolsado_F < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         /* Using cursor T001A17 */
         pr_default.execute(11, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId, n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            A510PropostaValorReembolsadoJuros_F = T001A17_A510PropostaValorReembolsadoJuros_F[0];
            n510PropostaValorReembolsadoJuros_F = T001A17_n510PropostaValorReembolsadoJuros_F[0];
         }
         else
         {
            A510PropostaValorReembolsadoJuros_F = 0;
            n510PropostaValorReembolsadoJuros_F = false;
            AssignAttri("", false, "A510PropostaValorReembolsadoJuros_F", StringUtil.LTrimStr( A510PropostaValorReembolsadoJuros_F, 18, 2));
         }
         pr_default.close(11);
         if ( ( A510PropostaValorReembolsadoJuros_F < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         /* Using cursor T001A20 */
         pr_default.execute(12, new Object[] {n328PropostaCratedBy, A328PropostaCratedBy, n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            A511PropostaValorTaxaRecebida_F = T001A20_A511PropostaValorTaxaRecebida_F[0];
            n511PropostaValorTaxaRecebida_F = T001A20_n511PropostaValorTaxaRecebida_F[0];
         }
         else
         {
            A511PropostaValorTaxaRecebida_F = 0;
            n511PropostaValorTaxaRecebida_F = false;
            AssignAttri("", false, "A511PropostaValorTaxaRecebida_F", StringUtil.LTrimStr( A511PropostaValorTaxaRecebida_F, 18, 2));
         }
         pr_default.close(12);
         if ( ( A511PropostaValorTaxaRecebida_F < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         /* Using cursor T001A23 */
         pr_default.execute(13, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId, n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            A515PropostaDataCreditoCliente_F = T001A23_A515PropostaDataCreditoCliente_F[0];
            n515PropostaDataCreditoCliente_F = T001A23_n515PropostaDataCreditoCliente_F[0];
         }
         else
         {
            A515PropostaDataCreditoCliente_F = DateTime.MinValue;
            n515PropostaDataCreditoCliente_F = false;
            AssignAttri("", false, "A515PropostaDataCreditoCliente_F", context.localUtil.Format(A515PropostaDataCreditoCliente_F, "99/99/9999"));
         }
         pr_default.close(13);
         GXt_decimal3 = A514PropostaValorJurosMora_F;
         new prcalcularjurosmora(context ).execute(  A515PropostaDataCreditoCliente_F,  A507PropostaSLA,  A508PropostaJurosMora,  A326PropostaValor, out  GXt_decimal3) ;
         A514PropostaValorJurosMora_F = GXt_decimal3;
         AssignAttri("", false, "A514PropostaValorJurosMora_F", StringUtil.LTrimStr( A514PropostaValorJurosMora_F, 18, 2));
         if ( ( A514PropostaValorJurosMora_F < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         /* Using cursor T001A25 */
         pr_default.execute(14, new Object[] {n323PropostaId, A323PropostaId, n642PropostaClinicaId, A642PropostaClinicaId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            A650PropostaValorTaxaClinica_F = T001A25_A650PropostaValorTaxaClinica_F[0];
            n650PropostaValorTaxaClinica_F = T001A25_n650PropostaValorTaxaClinica_F[0];
         }
         else
         {
            A650PropostaValorTaxaClinica_F = 0;
            n650PropostaValorTaxaClinica_F = false;
            AssignAttri("", false, "A650PropostaValorTaxaClinica_F", StringUtil.LTrimStr( A650PropostaValorTaxaClinica_F, 18, 2));
         }
         pr_default.close(14);
         if ( ( A650PropostaValorTaxaClinica_F < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         /* Using cursor T001A27 */
         pr_default.execute(15, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            A649PropostaMaxReembolsoId_F = T001A27_A649PropostaMaxReembolsoId_F[0];
            n649PropostaMaxReembolsoId_F = T001A27_n649PropostaMaxReembolsoId_F[0];
         }
         else
         {
            A649PropostaMaxReembolsoId_F = 0;
            n649PropostaMaxReembolsoId_F = false;
            AssignAttri("", false, "A649PropostaMaxReembolsoId_F", StringUtil.LTrimStr( (decimal)(A649PropostaMaxReembolsoId_F), 9, 0));
         }
         pr_default.close(15);
         /* Using cursor T001A29 */
         pr_default.execute(16, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            A854PropostaQtdItensNota_F = T001A29_A854PropostaQtdItensNota_F[0];
            n854PropostaQtdItensNota_F = T001A29_n854PropostaQtdItensNota_F[0];
         }
         else
         {
            A854PropostaQtdItensNota_F = 0;
            n854PropostaQtdItensNota_F = false;
            AssignAttri("", false, "A854PropostaQtdItensNota_F", StringUtil.LTrimStr( (decimal)(A854PropostaQtdItensNota_F), 4, 0));
         }
         pr_default.close(16);
         /* Using cursor T001A39 */
         pr_default.execute(20, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(20) != 101) )
         {
            A655PropostaQtdDocumentoPendente_F = T001A39_A655PropostaQtdDocumentoPendente_F[0];
            n655PropostaQtdDocumentoPendente_F = T001A39_n655PropostaQtdDocumentoPendente_F[0];
         }
         else
         {
            A655PropostaQtdDocumentoPendente_F = 0;
            n655PropostaQtdDocumentoPendente_F = false;
            AssignAttri("", false, "A655PropostaQtdDocumentoPendente_F", StringUtil.LTrimStr( (decimal)(A655PropostaQtdDocumentoPendente_F), 4, 0));
         }
         pr_default.close(20);
         /* Using cursor T001A41 */
         pr_default.execute(21, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(21) != 101) )
         {
            A341PropostaAprovacoes_F = T001A41_A341PropostaAprovacoes_F[0];
            n341PropostaAprovacoes_F = T001A41_n341PropostaAprovacoes_F[0];
            AssignAttri("", false, "A341PropostaAprovacoes_F", StringUtil.LTrimStr( (decimal)(A341PropostaAprovacoes_F), 4, 0));
         }
         else
         {
            A341PropostaAprovacoes_F = 0;
            n341PropostaAprovacoes_F = false;
            AssignAttri("", false, "A341PropostaAprovacoes_F", StringUtil.LTrimStr( (decimal)(A341PropostaAprovacoes_F), 4, 0));
         }
         pr_default.close(21);
         A343PropostaAprovacoesRestantes_F = (short)(A330PropostaQuantidadeAprovadores-A341PropostaAprovacoes_F);
         AssignAttri("", false, "A343PropostaAprovacoesRestantes_F", StringUtil.LTrimStr( (decimal)(A343PropostaAprovacoesRestantes_F), 4, 0));
         /* Using cursor T001A43 */
         pr_default.execute(22, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(22) != 101) )
         {
            A342PropostaReprovacoes_F = T001A43_A342PropostaReprovacoes_F[0];
            n342PropostaReprovacoes_F = T001A43_n342PropostaReprovacoes_F[0];
            AssignAttri("", false, "A342PropostaReprovacoes_F", StringUtil.LTrimStr( (decimal)(A342PropostaReprovacoes_F), 4, 0));
         }
         else
         {
            A342PropostaReprovacoes_F = 0;
            n342PropostaReprovacoes_F = false;
            AssignAttri("", false, "A342PropostaReprovacoes_F", StringUtil.LTrimStr( (decimal)(A342PropostaReprovacoes_F), 4, 0));
         }
         pr_default.close(22);
         /* Using cursor T001A5 */
         pr_default.execute(3, new Object[] {n376ProcedimentosMedicosId, A376ProcedimentosMedicosId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A376ProcedimentosMedicosId) ) )
            {
               GX_msglist.addItem("Não existe 'ProcedimentosMedicos'.", "ForeignKeyNotFound", 1, "PROCEDIMENTOSMEDICOSID");
               AnyError = 1;
               GX_FocusControl = edtProcedimentosMedicosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(3);
         A575PropostaTaxa_F = (decimal)(A326PropostaValor*(A501PropostaTaxaAdministrativa/ (decimal)(100)));
         AssignAttri("", false, "A575PropostaTaxa_F", StringUtil.LTrimStr( A575PropostaTaxa_F, 18, 2));
         A513PropostaValorTaxa_F = (decimal)(A326PropostaValor*(A501PropostaTaxaAdministrativa/ (decimal)(100)));
         AssignAttri("", false, "A513PropostaValorTaxa_F", StringUtil.LTrimStr( A513PropostaValorTaxa_F, 18, 2));
         if ( ( A513PropostaValorTaxa_F < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         if ( ( A326PropostaValor < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "PROPOSTAVALOR");
            AnyError = 1;
            GX_FocusControl = edtPropostaValor_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T001A7 */
         pr_default.execute(5, new Object[] {n328PropostaCratedBy, A328PropostaCratedBy});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A328PropostaCratedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sec User Proposta'.", "ForeignKeyNotFound", 1, "PROPOSTACRATEDBY");
               AnyError = 1;
               GX_FocusControl = edtPropostaCratedBy_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A512PropostaSecUserName = T001A7_A512PropostaSecUserName[0];
         n512PropostaSecUserName = T001A7_n512PropostaSecUserName[0];
         pr_default.close(5);
         if ( ! ( ( StringUtil.StrCmp(A329PropostaStatus, "PENDENTE") == 0 ) || ( StringUtil.StrCmp(A329PropostaStatus, "EM_ANALISE") == 0 ) || ( StringUtil.StrCmp(A329PropostaStatus, "APROVADO") == 0 ) || ( StringUtil.StrCmp(A329PropostaStatus, "REJEITADO") == 0 ) || ( StringUtil.StrCmp(A329PropostaStatus, "REVISAO") == 0 ) || ( StringUtil.StrCmp(A329PropostaStatus, "CANCELADO") == 0 ) || ( StringUtil.StrCmp(A329PropostaStatus, "AGUARDANDO_ASSINATURA") == 0 ) || ( StringUtil.StrCmp(A329PropostaStatus, "AnaliseReprovada") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A329PropostaStatus)) ) )
         {
            GX_msglist.addItem("Campo Proposta Status fora do intervalo", "OutOfRange", 1, "PROPOSTASTATUS");
            AnyError = 1;
            GX_FocusControl = cmbPropostaStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ( A855PropostaValorLiquido < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         /* Using cursor T001A4 */
         pr_default.execute(2, new Object[] {n227ContratoId, A227ContratoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A227ContratoId) ) )
            {
               GX_msglist.addItem("Não existe 'Contrato'.", "ForeignKeyNotFound", 1, "CONTRATOID");
               AnyError = 1;
            }
         }
         A228ContratoNome = T001A4_A228ContratoNome[0];
         n228ContratoNome = T001A4_n228ContratoNome[0];
         pr_default.close(2);
         /* Using cursor T001A6 */
         pr_default.execute(4, new Object[] {n493ConvenioCategoriaId, A493ConvenioCategoriaId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A493ConvenioCategoriaId) ) )
            {
               GX_msglist.addItem("Não existe 'ConvenioCategoria'.", "ForeignKeyNotFound", 1, "CONVENIOCATEGORIAID");
               AnyError = 1;
            }
         }
         A494ConvenioCategoriaDescricao = T001A6_A494ConvenioCategoriaDescricao[0];
         n494ConvenioCategoriaDescricao = T001A6_n494ConvenioCategoriaDescricao[0];
         A410ConvenioId = T001A6_A410ConvenioId[0];
         n410ConvenioId = T001A6_n410ConvenioId[0];
         pr_default.close(4);
         /* Using cursor T001A8 */
         pr_default.execute(6, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A504PropostaPacienteClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Proposta Cliente'.", "ForeignKeyNotFound", 1, "PROPOSTAPACIENTECLIENTEID");
               AnyError = 1;
            }
         }
         A505PropostaPacienteClienteRazaoSocial = T001A8_A505PropostaPacienteClienteRazaoSocial[0];
         n505PropostaPacienteClienteRazaoSocial = T001A8_n505PropostaPacienteClienteRazaoSocial[0];
         A540PropostaPacienteClienteDocumento = T001A8_A540PropostaPacienteClienteDocumento[0];
         n540PropostaPacienteClienteDocumento = T001A8_n540PropostaPacienteClienteDocumento[0];
         A541PropostaPacienteContatoEmail = T001A8_A541PropostaPacienteContatoEmail[0];
         n541PropostaPacienteContatoEmail = T001A8_n541PropostaPacienteContatoEmail[0];
         A584PropostaPacienteConta = T001A8_A584PropostaPacienteConta[0];
         n584PropostaPacienteConta = T001A8_n584PropostaPacienteConta[0];
         A585PropostaPacienteAgencia = T001A8_A585PropostaPacienteAgencia[0];
         n585PropostaPacienteAgencia = T001A8_n585PropostaPacienteAgencia[0];
         A586PropostaPacienteTipoPix = T001A8_A586PropostaPacienteTipoPix[0];
         n586PropostaPacienteTipoPix = T001A8_n586PropostaPacienteTipoPix[0];
         A587PropostaPacientePIX = T001A8_A587PropostaPacientePIX[0];
         n587PropostaPacientePIX = T001A8_n587PropostaPacientePIX[0];
         A588PropostaPacienteDepositoTipo = T001A8_A588PropostaPacienteDepositoTipo[0];
         n588PropostaPacienteDepositoTipo = T001A8_n588PropostaPacienteDepositoTipo[0];
         A620PropostaPacienteEnderecoCEP = T001A8_A620PropostaPacienteEnderecoCEP[0];
         n620PropostaPacienteEnderecoCEP = T001A8_n620PropostaPacienteEnderecoCEP[0];
         A621PropostaPacienteEnderecoLogradouro = T001A8_A621PropostaPacienteEnderecoLogradouro[0];
         n621PropostaPacienteEnderecoLogradouro = T001A8_n621PropostaPacienteEnderecoLogradouro[0];
         A622PropostaPacienteEnderecoNumero = T001A8_A622PropostaPacienteEnderecoNumero[0];
         n622PropostaPacienteEnderecoNumero = T001A8_n622PropostaPacienteEnderecoNumero[0];
         A623PropostaPacienteEnderecoComplemento = T001A8_A623PropostaPacienteEnderecoComplemento[0];
         n623PropostaPacienteEnderecoComplemento = T001A8_n623PropostaPacienteEnderecoComplemento[0];
         A624PropostaPacienteEnderecoBairro = T001A8_A624PropostaPacienteEnderecoBairro[0];
         n624PropostaPacienteEnderecoBairro = T001A8_n624PropostaPacienteEnderecoBairro[0];
         A625PropostaPacienteMunicipioCodigo = T001A8_A625PropostaPacienteMunicipioCodigo[0];
         n625PropostaPacienteMunicipioCodigo = T001A8_n625PropostaPacienteMunicipioCodigo[0];
         pr_default.close(6);
         /* Using cursor T001A31 */
         pr_default.execute(17, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            A733PropostaResponsavelSerasaConsultas_F = T001A31_A733PropostaResponsavelSerasaConsultas_F[0];
            n733PropostaResponsavelSerasaConsultas_F = T001A31_n733PropostaResponsavelSerasaConsultas_F[0];
            A734PropostaPacienteSerasaConsultas_F = T001A31_A734PropostaPacienteSerasaConsultas_F[0];
            n734PropostaPacienteSerasaConsultas_F = T001A31_n734PropostaPacienteSerasaConsultas_F[0];
         }
         else
         {
            A734PropostaPacienteSerasaConsultas_F = 0;
            n734PropostaPacienteSerasaConsultas_F = false;
            AssignAttri("", false, "A734PropostaPacienteSerasaConsultas_F", StringUtil.LTrimStr( (decimal)(A734PropostaPacienteSerasaConsultas_F), 4, 0));
            A733PropostaResponsavelSerasaConsultas_F = 0;
            n733PropostaResponsavelSerasaConsultas_F = false;
            AssignAttri("", false, "A733PropostaResponsavelSerasaConsultas_F", StringUtil.LTrimStr( (decimal)(A733PropostaResponsavelSerasaConsultas_F), 4, 0));
         }
         pr_default.close(17);
         /* Using cursor T001A34 */
         pr_default.execute(18, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            A783PropostaResponsavelSerasaScoreUltimaData_F = T001A34_A783PropostaResponsavelSerasaScoreUltimaData_F[0];
            n783PropostaResponsavelSerasaScoreUltimaData_F = T001A34_n783PropostaResponsavelSerasaScoreUltimaData_F[0];
            A782PropostaSerasaScoreUltimaData_F = T001A34_A782PropostaSerasaScoreUltimaData_F[0];
            n782PropostaSerasaScoreUltimaData_F = T001A34_n782PropostaSerasaScoreUltimaData_F[0];
         }
         else
         {
            A782PropostaSerasaScoreUltimaData_F = 0;
            n782PropostaSerasaScoreUltimaData_F = false;
            AssignAttri("", false, "A782PropostaSerasaScoreUltimaData_F", StringUtil.LTrimStr( (decimal)(A782PropostaSerasaScoreUltimaData_F), 4, 0));
            A783PropostaResponsavelSerasaScoreUltimaData_F = 0;
            n783PropostaResponsavelSerasaScoreUltimaData_F = false;
            AssignAttri("", false, "A783PropostaResponsavelSerasaScoreUltimaData_F", StringUtil.LTrimStr( (decimal)(A783PropostaResponsavelSerasaScoreUltimaData_F), 4, 0));
         }
         pr_default.close(18);
         A784PropostaMaiorScore_F = (short)(((A782PropostaSerasaScoreUltimaData_F>A783PropostaResponsavelSerasaScoreUltimaData_F) ? A782PropostaSerasaScoreUltimaData_F : A783PropostaResponsavelSerasaScoreUltimaData_F));
         AssignAttri("", false, "A784PropostaMaiorScore_F", StringUtil.LTrimStr( (decimal)(A784PropostaMaiorScore_F), 4, 0));
         /* Using cursor T001A37 */
         pr_default.execute(19, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            A786PropostaResponsavelSerasaUltimoValorRecomendado_F = T001A37_A786PropostaResponsavelSerasaUltimoValorRecomendado_F[0];
            n786PropostaResponsavelSerasaUltimoValorRecomendado_F = T001A37_n786PropostaResponsavelSerasaUltimoValorRecomendado_F[0];
            A787PropostaPacienteSerasaUltimoValorRecomendado_F = T001A37_A787PropostaPacienteSerasaUltimoValorRecomendado_F[0];
            n787PropostaPacienteSerasaUltimoValorRecomendado_F = T001A37_n787PropostaPacienteSerasaUltimoValorRecomendado_F[0];
         }
         else
         {
            A787PropostaPacienteSerasaUltimoValorRecomendado_F = 0;
            n787PropostaPacienteSerasaUltimoValorRecomendado_F = false;
            AssignAttri("", false, "A787PropostaPacienteSerasaUltimoValorRecomendado_F", StringUtil.LTrimStr( A787PropostaPacienteSerasaUltimoValorRecomendado_F, 18, 2));
            A786PropostaResponsavelSerasaUltimoValorRecomendado_F = 0;
            n786PropostaResponsavelSerasaUltimoValorRecomendado_F = false;
            AssignAttri("", false, "A786PropostaResponsavelSerasaUltimoValorRecomendado_F", StringUtil.LTrimStr( A786PropostaResponsavelSerasaUltimoValorRecomendado_F, 18, 2));
         }
         pr_default.close(19);
         if ( ( A786PropostaResponsavelSerasaUltimoValorRecomendado_F < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         A788PropostaMaiorValorRecomendado = ((A786PropostaResponsavelSerasaUltimoValorRecomendado_F>A787PropostaPacienteSerasaUltimoValorRecomendado_F) ? A786PropostaResponsavelSerasaUltimoValorRecomendado_F : A787PropostaPacienteSerasaUltimoValorRecomendado_F);
         AssignAttri("", false, "A788PropostaMaiorValorRecomendado", StringUtil.LTrimStr( A788PropostaMaiorValorRecomendado, 18, 2));
         if ( ( A788PropostaMaiorValorRecomendado < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         if ( ( A787PropostaPacienteSerasaUltimoValorRecomendado_F < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         /* Using cursor T001A9 */
         pr_default.execute(7, new Object[] {n553PropostaResponsavelId, A553PropostaResponsavelId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A553PropostaResponsavelId) ) )
            {
               GX_msglist.addItem("Não existe 'Proposta Responsavel'.", "ForeignKeyNotFound", 1, "PROPOSTARESPONSAVELID");
               AnyError = 1;
            }
         }
         A580PropostaResponsavelDocumento = T001A9_A580PropostaResponsavelDocumento[0];
         n580PropostaResponsavelDocumento = T001A9_n580PropostaResponsavelDocumento[0];
         A581PropostaResponsavelRazaoSocial = T001A9_A581PropostaResponsavelRazaoSocial[0];
         n581PropostaResponsavelRazaoSocial = T001A9_n581PropostaResponsavelRazaoSocial[0];
         A582PropostaResponsavelEmail = T001A9_A582PropostaResponsavelEmail[0];
         n582PropostaResponsavelEmail = T001A9_n582PropostaResponsavelEmail[0];
         A590PropostaResponsavelConta = T001A9_A590PropostaResponsavelConta[0];
         n590PropostaResponsavelConta = T001A9_n590PropostaResponsavelConta[0];
         A591PropostaResponsavelAgencia = T001A9_A591PropostaResponsavelAgencia[0];
         n591PropostaResponsavelAgencia = T001A9_n591PropostaResponsavelAgencia[0];
         A592PropostaResponsavelTipoPix = T001A9_A592PropostaResponsavelTipoPix[0];
         n592PropostaResponsavelTipoPix = T001A9_n592PropostaResponsavelTipoPix[0];
         A593PropostaResponsavelPIX = T001A9_A593PropostaResponsavelPIX[0];
         n593PropostaResponsavelPIX = T001A9_n593PropostaResponsavelPIX[0];
         A594PropostaResponsavelDepositoTipo = T001A9_A594PropostaResponsavelDepositoTipo[0];
         n594PropostaResponsavelDepositoTipo = T001A9_n594PropostaResponsavelDepositoTipo[0];
         pr_default.close(7);
         /* Using cursor T001A10 */
         pr_default.execute(8, new Object[] {n642PropostaClinicaId, A642PropostaClinicaId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (0==A642PropostaClinicaId) ) )
            {
               GX_msglist.addItem("Não foi possível identificar o ID da clínica, por favor entre em contato com suporte.", "ForeignKeyNotFound", 1, "PROPOSTACLINICAID");
               AnyError = 1;
            }
         }
         A643PropostaClinicaNome = T001A10_A643PropostaClinicaNome[0];
         n643PropostaClinicaNome = T001A10_n643PropostaClinicaNome[0];
         A644PropostaClinicaNomeFantasia = T001A10_A644PropostaClinicaNomeFantasia[0];
         n644PropostaClinicaNomeFantasia = T001A10_n644PropostaClinicaNomeFantasia[0];
         A652PropostaClinicaDocumento = T001A10_A652PropostaClinicaDocumento[0];
         n652PropostaClinicaDocumento = T001A10_n652PropostaClinicaDocumento[0];
         A653PropostaClinicaEmail = T001A10_A653PropostaClinicaEmail[0];
         n653PropostaClinicaEmail = T001A10_n653PropostaClinicaEmail[0];
         pr_default.close(8);
         /* Using cursor T001A11 */
         pr_default.execute(9, new Object[] {n850PropostaEmpresaClienteId, A850PropostaEmpresaClienteId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( (0==A850PropostaEmpresaClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Sd Proposta Empresa'.", "ForeignKeyNotFound", 1, "PROPOSTAEMPRESACLIENTEID");
               AnyError = 1;
            }
         }
         pr_default.close(9);
      }

      protected void CloseExtendedTableCursors1A49( )
      {
         pr_default.close(10);
         pr_default.close(11);
         pr_default.close(12);
         pr_default.close(13);
         pr_default.close(14);
         pr_default.close(15);
         pr_default.close(16);
         pr_default.close(20);
         pr_default.close(21);
         pr_default.close(22);
         pr_default.close(3);
         pr_default.close(5);
         pr_default.close(2);
         pr_default.close(4);
         pr_default.close(6);
         pr_default.close(17);
         pr_default.close(18);
         pr_default.close(19);
         pr_default.close(7);
         pr_default.close(8);
         pr_default.close(9);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_51( int A323PropostaId ,
                                int A504PropostaPacienteClienteId )
      {
         /* Using cursor T001A57 */
         pr_default.execute(24, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId, n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(24) != 101) )
         {
            A509PropostaValorReembolsado_F = T001A57_A509PropostaValorReembolsado_F[0];
            n509PropostaValorReembolsado_F = T001A57_n509PropostaValorReembolsado_F[0];
         }
         else
         {
            A509PropostaValorReembolsado_F = 0;
            n509PropostaValorReembolsado_F = false;
            AssignAttri("", false, "A509PropostaValorReembolsado_F", StringUtil.LTrimStr( A509PropostaValorReembolsado_F, 18, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A509PropostaValorReembolsado_F, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(24) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(24);
      }

      protected void gxLoad_52( int A323PropostaId ,
                                int A504PropostaPacienteClienteId )
      {
         /* Using cursor T001A60 */
         pr_default.execute(25, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId, n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(25) != 101) )
         {
            A510PropostaValorReembolsadoJuros_F = T001A60_A510PropostaValorReembolsadoJuros_F[0];
            n510PropostaValorReembolsadoJuros_F = T001A60_n510PropostaValorReembolsadoJuros_F[0];
         }
         else
         {
            A510PropostaValorReembolsadoJuros_F = 0;
            n510PropostaValorReembolsadoJuros_F = false;
            AssignAttri("", false, "A510PropostaValorReembolsadoJuros_F", StringUtil.LTrimStr( A510PropostaValorReembolsadoJuros_F, 18, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A510PropostaValorReembolsadoJuros_F, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(25) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(25);
      }

      protected void gxLoad_53( int A323PropostaId ,
                                short A328PropostaCratedBy )
      {
         /* Using cursor T001A63 */
         pr_default.execute(26, new Object[] {n328PropostaCratedBy, A328PropostaCratedBy, n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(26) != 101) )
         {
            A511PropostaValorTaxaRecebida_F = T001A63_A511PropostaValorTaxaRecebida_F[0];
            n511PropostaValorTaxaRecebida_F = T001A63_n511PropostaValorTaxaRecebida_F[0];
         }
         else
         {
            A511PropostaValorTaxaRecebida_F = 0;
            n511PropostaValorTaxaRecebida_F = false;
            AssignAttri("", false, "A511PropostaValorTaxaRecebida_F", StringUtil.LTrimStr( A511PropostaValorTaxaRecebida_F, 18, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A511PropostaValorTaxaRecebida_F, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(26) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(26);
      }

      protected void gxLoad_54( int A323PropostaId ,
                                int A504PropostaPacienteClienteId )
      {
         /* Using cursor T001A66 */
         pr_default.execute(27, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId, n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(27) != 101) )
         {
            A515PropostaDataCreditoCliente_F = T001A66_A515PropostaDataCreditoCliente_F[0];
            n515PropostaDataCreditoCliente_F = T001A66_n515PropostaDataCreditoCliente_F[0];
         }
         else
         {
            A515PropostaDataCreditoCliente_F = DateTime.MinValue;
            n515PropostaDataCreditoCliente_F = false;
            AssignAttri("", false, "A515PropostaDataCreditoCliente_F", context.localUtil.Format(A515PropostaDataCreditoCliente_F, "99/99/9999"));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( context.localUtil.Format(A515PropostaDataCreditoCliente_F, "99/99/9999"))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(27) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(27);
      }

      protected void gxLoad_55( int A323PropostaId ,
                                int A642PropostaClinicaId )
      {
         /* Using cursor T001A68 */
         pr_default.execute(28, new Object[] {n323PropostaId, A323PropostaId, n642PropostaClinicaId, A642PropostaClinicaId});
         if ( (pr_default.getStatus(28) != 101) )
         {
            A650PropostaValorTaxaClinica_F = T001A68_A650PropostaValorTaxaClinica_F[0];
            n650PropostaValorTaxaClinica_F = T001A68_n650PropostaValorTaxaClinica_F[0];
         }
         else
         {
            A650PropostaValorTaxaClinica_F = 0;
            n650PropostaValorTaxaClinica_F = false;
            AssignAttri("", false, "A650PropostaValorTaxaClinica_F", StringUtil.LTrimStr( A650PropostaValorTaxaClinica_F, 18, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A650PropostaValorTaxaClinica_F, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(28) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(28);
      }

      protected void gxLoad_56( int A323PropostaId )
      {
         /* Using cursor T001A70 */
         pr_default.execute(29, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(29) != 101) )
         {
            A649PropostaMaxReembolsoId_F = T001A70_A649PropostaMaxReembolsoId_F[0];
            n649PropostaMaxReembolsoId_F = T001A70_n649PropostaMaxReembolsoId_F[0];
         }
         else
         {
            A649PropostaMaxReembolsoId_F = 0;
            n649PropostaMaxReembolsoId_F = false;
            AssignAttri("", false, "A649PropostaMaxReembolsoId_F", StringUtil.LTrimStr( (decimal)(A649PropostaMaxReembolsoId_F), 9, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A649PropostaMaxReembolsoId_F), 9, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(29) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(29);
      }

      protected void gxLoad_57( int A323PropostaId )
      {
         /* Using cursor T001A72 */
         pr_default.execute(30, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(30) != 101) )
         {
            A854PropostaQtdItensNota_F = T001A72_A854PropostaQtdItensNota_F[0];
            n854PropostaQtdItensNota_F = T001A72_n854PropostaQtdItensNota_F[0];
         }
         else
         {
            A854PropostaQtdItensNota_F = 0;
            n854PropostaQtdItensNota_F = false;
            AssignAttri("", false, "A854PropostaQtdItensNota_F", StringUtil.LTrimStr( (decimal)(A854PropostaQtdItensNota_F), 4, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A854PropostaQtdItensNota_F), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(30) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(30);
      }

      protected void gxLoad_61( int A323PropostaId )
      {
         /* Using cursor T001A74 */
         pr_default.execute(31, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(31) != 101) )
         {
            A655PropostaQtdDocumentoPendente_F = T001A74_A655PropostaQtdDocumentoPendente_F[0];
            n655PropostaQtdDocumentoPendente_F = T001A74_n655PropostaQtdDocumentoPendente_F[0];
         }
         else
         {
            A655PropostaQtdDocumentoPendente_F = 0;
            n655PropostaQtdDocumentoPendente_F = false;
            AssignAttri("", false, "A655PropostaQtdDocumentoPendente_F", StringUtil.LTrimStr( (decimal)(A655PropostaQtdDocumentoPendente_F), 4, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A655PropostaQtdDocumentoPendente_F), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(31) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(31);
      }

      protected void gxLoad_62( int A323PropostaId )
      {
         /* Using cursor T001A76 */
         pr_default.execute(32, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(32) != 101) )
         {
            A341PropostaAprovacoes_F = T001A76_A341PropostaAprovacoes_F[0];
            n341PropostaAprovacoes_F = T001A76_n341PropostaAprovacoes_F[0];
            AssignAttri("", false, "A341PropostaAprovacoes_F", StringUtil.LTrimStr( (decimal)(A341PropostaAprovacoes_F), 4, 0));
         }
         else
         {
            A341PropostaAprovacoes_F = 0;
            n341PropostaAprovacoes_F = false;
            AssignAttri("", false, "A341PropostaAprovacoes_F", StringUtil.LTrimStr( (decimal)(A341PropostaAprovacoes_F), 4, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A341PropostaAprovacoes_F), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(32) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(32);
      }

      protected void gxLoad_63( int A323PropostaId )
      {
         /* Using cursor T001A78 */
         pr_default.execute(33, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(33) != 101) )
         {
            A342PropostaReprovacoes_F = T001A78_A342PropostaReprovacoes_F[0];
            n342PropostaReprovacoes_F = T001A78_n342PropostaReprovacoes_F[0];
            AssignAttri("", false, "A342PropostaReprovacoes_F", StringUtil.LTrimStr( (decimal)(A342PropostaReprovacoes_F), 4, 0));
         }
         else
         {
            A342PropostaReprovacoes_F = 0;
            n342PropostaReprovacoes_F = false;
            AssignAttri("", false, "A342PropostaReprovacoes_F", StringUtil.LTrimStr( (decimal)(A342PropostaReprovacoes_F), 4, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A342PropostaReprovacoes_F), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(33) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(33);
      }

      protected void gxLoad_44( int A376ProcedimentosMedicosId )
      {
         /* Using cursor T001A79 */
         pr_default.execute(34, new Object[] {n376ProcedimentosMedicosId, A376ProcedimentosMedicosId});
         if ( (pr_default.getStatus(34) == 101) )
         {
            if ( ! ( (0==A376ProcedimentosMedicosId) ) )
            {
               GX_msglist.addItem("Não existe 'ProcedimentosMedicos'.", "ForeignKeyNotFound", 1, "PROCEDIMENTOSMEDICOSID");
               AnyError = 1;
               GX_FocusControl = edtProcedimentosMedicosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(34) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(34);
      }

      protected void gxLoad_46( short A328PropostaCratedBy )
      {
         /* Using cursor T001A80 */
         pr_default.execute(35, new Object[] {n328PropostaCratedBy, A328PropostaCratedBy});
         if ( (pr_default.getStatus(35) == 101) )
         {
            if ( ! ( (0==A328PropostaCratedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sec User Proposta'.", "ForeignKeyNotFound", 1, "PROPOSTACRATEDBY");
               AnyError = 1;
               GX_FocusControl = edtPropostaCratedBy_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A512PropostaSecUserName = T001A80_A512PropostaSecUserName[0];
         n512PropostaSecUserName = T001A80_n512PropostaSecUserName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A512PropostaSecUserName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(35) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(35);
      }

      protected void gxLoad_43( int A227ContratoId )
      {
         /* Using cursor T001A81 */
         pr_default.execute(36, new Object[] {n227ContratoId, A227ContratoId});
         if ( (pr_default.getStatus(36) == 101) )
         {
            if ( ! ( (0==A227ContratoId) ) )
            {
               GX_msglist.addItem("Não existe 'Contrato'.", "ForeignKeyNotFound", 1, "CONTRATOID");
               AnyError = 1;
            }
         }
         A228ContratoNome = T001A81_A228ContratoNome[0];
         n228ContratoNome = T001A81_n228ContratoNome[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A228ContratoNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(36) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(36);
      }

      protected void gxLoad_45( int A493ConvenioCategoriaId )
      {
         /* Using cursor T001A82 */
         pr_default.execute(37, new Object[] {n493ConvenioCategoriaId, A493ConvenioCategoriaId});
         if ( (pr_default.getStatus(37) == 101) )
         {
            if ( ! ( (0==A493ConvenioCategoriaId) ) )
            {
               GX_msglist.addItem("Não existe 'ConvenioCategoria'.", "ForeignKeyNotFound", 1, "CONVENIOCATEGORIAID");
               AnyError = 1;
            }
         }
         A494ConvenioCategoriaDescricao = T001A82_A494ConvenioCategoriaDescricao[0];
         n494ConvenioCategoriaDescricao = T001A82_n494ConvenioCategoriaDescricao[0];
         A410ConvenioId = T001A82_A410ConvenioId[0];
         n410ConvenioId = T001A82_n410ConvenioId[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A494ConvenioCategoriaDescricao)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A410ConvenioId), 9, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(37) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(37);
      }

      protected void gxLoad_47( int A504PropostaPacienteClienteId )
      {
         /* Using cursor T001A83 */
         pr_default.execute(38, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId});
         if ( (pr_default.getStatus(38) == 101) )
         {
            if ( ! ( (0==A504PropostaPacienteClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Proposta Cliente'.", "ForeignKeyNotFound", 1, "PROPOSTAPACIENTECLIENTEID");
               AnyError = 1;
            }
         }
         A505PropostaPacienteClienteRazaoSocial = T001A83_A505PropostaPacienteClienteRazaoSocial[0];
         n505PropostaPacienteClienteRazaoSocial = T001A83_n505PropostaPacienteClienteRazaoSocial[0];
         A540PropostaPacienteClienteDocumento = T001A83_A540PropostaPacienteClienteDocumento[0];
         n540PropostaPacienteClienteDocumento = T001A83_n540PropostaPacienteClienteDocumento[0];
         A541PropostaPacienteContatoEmail = T001A83_A541PropostaPacienteContatoEmail[0];
         n541PropostaPacienteContatoEmail = T001A83_n541PropostaPacienteContatoEmail[0];
         A584PropostaPacienteConta = T001A83_A584PropostaPacienteConta[0];
         n584PropostaPacienteConta = T001A83_n584PropostaPacienteConta[0];
         A585PropostaPacienteAgencia = T001A83_A585PropostaPacienteAgencia[0];
         n585PropostaPacienteAgencia = T001A83_n585PropostaPacienteAgencia[0];
         A586PropostaPacienteTipoPix = T001A83_A586PropostaPacienteTipoPix[0];
         n586PropostaPacienteTipoPix = T001A83_n586PropostaPacienteTipoPix[0];
         A587PropostaPacientePIX = T001A83_A587PropostaPacientePIX[0];
         n587PropostaPacientePIX = T001A83_n587PropostaPacientePIX[0];
         A588PropostaPacienteDepositoTipo = T001A83_A588PropostaPacienteDepositoTipo[0];
         n588PropostaPacienteDepositoTipo = T001A83_n588PropostaPacienteDepositoTipo[0];
         A620PropostaPacienteEnderecoCEP = T001A83_A620PropostaPacienteEnderecoCEP[0];
         n620PropostaPacienteEnderecoCEP = T001A83_n620PropostaPacienteEnderecoCEP[0];
         A621PropostaPacienteEnderecoLogradouro = T001A83_A621PropostaPacienteEnderecoLogradouro[0];
         n621PropostaPacienteEnderecoLogradouro = T001A83_n621PropostaPacienteEnderecoLogradouro[0];
         A622PropostaPacienteEnderecoNumero = T001A83_A622PropostaPacienteEnderecoNumero[0];
         n622PropostaPacienteEnderecoNumero = T001A83_n622PropostaPacienteEnderecoNumero[0];
         A623PropostaPacienteEnderecoComplemento = T001A83_A623PropostaPacienteEnderecoComplemento[0];
         n623PropostaPacienteEnderecoComplemento = T001A83_n623PropostaPacienteEnderecoComplemento[0];
         A624PropostaPacienteEnderecoBairro = T001A83_A624PropostaPacienteEnderecoBairro[0];
         n624PropostaPacienteEnderecoBairro = T001A83_n624PropostaPacienteEnderecoBairro[0];
         A625PropostaPacienteMunicipioCodigo = T001A83_A625PropostaPacienteMunicipioCodigo[0];
         n625PropostaPacienteMunicipioCodigo = T001A83_n625PropostaPacienteMunicipioCodigo[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A505PropostaPacienteClienteRazaoSocial)+"\""+","+"\""+GXUtil.EncodeJSConstant( A540PropostaPacienteClienteDocumento)+"\""+","+"\""+GXUtil.EncodeJSConstant( A541PropostaPacienteContatoEmail)+"\""+","+"\""+GXUtil.EncodeJSConstant( A584PropostaPacienteConta)+"\""+","+"\""+GXUtil.EncodeJSConstant( A585PropostaPacienteAgencia)+"\""+","+"\""+GXUtil.EncodeJSConstant( A586PropostaPacienteTipoPix)+"\""+","+"\""+GXUtil.EncodeJSConstant( A587PropostaPacientePIX)+"\""+","+"\""+GXUtil.EncodeJSConstant( A588PropostaPacienteDepositoTipo)+"\""+","+"\""+GXUtil.EncodeJSConstant( A620PropostaPacienteEnderecoCEP)+"\""+","+"\""+GXUtil.EncodeJSConstant( A621PropostaPacienteEnderecoLogradouro)+"\""+","+"\""+GXUtil.EncodeJSConstant( A622PropostaPacienteEnderecoNumero)+"\""+","+"\""+GXUtil.EncodeJSConstant( A623PropostaPacienteEnderecoComplemento)+"\""+","+"\""+GXUtil.EncodeJSConstant( A624PropostaPacienteEnderecoBairro)+"\""+","+"\""+GXUtil.EncodeJSConstant( A625PropostaPacienteMunicipioCodigo)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(38) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(38);
      }

      protected void gxLoad_58( int A504PropostaPacienteClienteId )
      {
         /* Using cursor T001A85 */
         pr_default.execute(39, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId});
         if ( (pr_default.getStatus(39) != 101) )
         {
            A733PropostaResponsavelSerasaConsultas_F = T001A85_A733PropostaResponsavelSerasaConsultas_F[0];
            n733PropostaResponsavelSerasaConsultas_F = T001A85_n733PropostaResponsavelSerasaConsultas_F[0];
            A734PropostaPacienteSerasaConsultas_F = T001A85_A734PropostaPacienteSerasaConsultas_F[0];
            n734PropostaPacienteSerasaConsultas_F = T001A85_n734PropostaPacienteSerasaConsultas_F[0];
         }
         else
         {
            A734PropostaPacienteSerasaConsultas_F = 0;
            n734PropostaPacienteSerasaConsultas_F = false;
            AssignAttri("", false, "A734PropostaPacienteSerasaConsultas_F", StringUtil.LTrimStr( (decimal)(A734PropostaPacienteSerasaConsultas_F), 4, 0));
            A733PropostaResponsavelSerasaConsultas_F = 0;
            n733PropostaResponsavelSerasaConsultas_F = false;
            AssignAttri("", false, "A733PropostaResponsavelSerasaConsultas_F", StringUtil.LTrimStr( (decimal)(A733PropostaResponsavelSerasaConsultas_F), 4, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A733PropostaResponsavelSerasaConsultas_F), 4, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A734PropostaPacienteSerasaConsultas_F), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(39) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(39);
      }

      protected void gxLoad_59( int A504PropostaPacienteClienteId )
      {
         /* Using cursor T001A88 */
         pr_default.execute(40, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId});
         if ( (pr_default.getStatus(40) != 101) )
         {
            A783PropostaResponsavelSerasaScoreUltimaData_F = T001A88_A783PropostaResponsavelSerasaScoreUltimaData_F[0];
            n783PropostaResponsavelSerasaScoreUltimaData_F = T001A88_n783PropostaResponsavelSerasaScoreUltimaData_F[0];
            A782PropostaSerasaScoreUltimaData_F = T001A88_A782PropostaSerasaScoreUltimaData_F[0];
            n782PropostaSerasaScoreUltimaData_F = T001A88_n782PropostaSerasaScoreUltimaData_F[0];
         }
         else
         {
            A782PropostaSerasaScoreUltimaData_F = 0;
            n782PropostaSerasaScoreUltimaData_F = false;
            AssignAttri("", false, "A782PropostaSerasaScoreUltimaData_F", StringUtil.LTrimStr( (decimal)(A782PropostaSerasaScoreUltimaData_F), 4, 0));
            A783PropostaResponsavelSerasaScoreUltimaData_F = 0;
            n783PropostaResponsavelSerasaScoreUltimaData_F = false;
            AssignAttri("", false, "A783PropostaResponsavelSerasaScoreUltimaData_F", StringUtil.LTrimStr( (decimal)(A783PropostaResponsavelSerasaScoreUltimaData_F), 4, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A783PropostaResponsavelSerasaScoreUltimaData_F), 4, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A782PropostaSerasaScoreUltimaData_F), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(40) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(40);
      }

      protected void gxLoad_60( int A504PropostaPacienteClienteId )
      {
         /* Using cursor T001A91 */
         pr_default.execute(41, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId});
         if ( (pr_default.getStatus(41) != 101) )
         {
            A786PropostaResponsavelSerasaUltimoValorRecomendado_F = T001A91_A786PropostaResponsavelSerasaUltimoValorRecomendado_F[0];
            n786PropostaResponsavelSerasaUltimoValorRecomendado_F = T001A91_n786PropostaResponsavelSerasaUltimoValorRecomendado_F[0];
            A787PropostaPacienteSerasaUltimoValorRecomendado_F = T001A91_A787PropostaPacienteSerasaUltimoValorRecomendado_F[0];
            n787PropostaPacienteSerasaUltimoValorRecomendado_F = T001A91_n787PropostaPacienteSerasaUltimoValorRecomendado_F[0];
         }
         else
         {
            A787PropostaPacienteSerasaUltimoValorRecomendado_F = 0;
            n787PropostaPacienteSerasaUltimoValorRecomendado_F = false;
            AssignAttri("", false, "A787PropostaPacienteSerasaUltimoValorRecomendado_F", StringUtil.LTrimStr( A787PropostaPacienteSerasaUltimoValorRecomendado_F, 18, 2));
            A786PropostaResponsavelSerasaUltimoValorRecomendado_F = 0;
            n786PropostaResponsavelSerasaUltimoValorRecomendado_F = false;
            AssignAttri("", false, "A786PropostaResponsavelSerasaUltimoValorRecomendado_F", StringUtil.LTrimStr( A786PropostaResponsavelSerasaUltimoValorRecomendado_F, 18, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A786PropostaResponsavelSerasaUltimoValorRecomendado_F, 18, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A787PropostaPacienteSerasaUltimoValorRecomendado_F, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(41) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(41);
      }

      protected void gxLoad_48( int A553PropostaResponsavelId )
      {
         /* Using cursor T001A92 */
         pr_default.execute(42, new Object[] {n553PropostaResponsavelId, A553PropostaResponsavelId});
         if ( (pr_default.getStatus(42) == 101) )
         {
            if ( ! ( (0==A553PropostaResponsavelId) ) )
            {
               GX_msglist.addItem("Não existe 'Proposta Responsavel'.", "ForeignKeyNotFound", 1, "PROPOSTARESPONSAVELID");
               AnyError = 1;
            }
         }
         A580PropostaResponsavelDocumento = T001A92_A580PropostaResponsavelDocumento[0];
         n580PropostaResponsavelDocumento = T001A92_n580PropostaResponsavelDocumento[0];
         A581PropostaResponsavelRazaoSocial = T001A92_A581PropostaResponsavelRazaoSocial[0];
         n581PropostaResponsavelRazaoSocial = T001A92_n581PropostaResponsavelRazaoSocial[0];
         A582PropostaResponsavelEmail = T001A92_A582PropostaResponsavelEmail[0];
         n582PropostaResponsavelEmail = T001A92_n582PropostaResponsavelEmail[0];
         A590PropostaResponsavelConta = T001A92_A590PropostaResponsavelConta[0];
         n590PropostaResponsavelConta = T001A92_n590PropostaResponsavelConta[0];
         A591PropostaResponsavelAgencia = T001A92_A591PropostaResponsavelAgencia[0];
         n591PropostaResponsavelAgencia = T001A92_n591PropostaResponsavelAgencia[0];
         A592PropostaResponsavelTipoPix = T001A92_A592PropostaResponsavelTipoPix[0];
         n592PropostaResponsavelTipoPix = T001A92_n592PropostaResponsavelTipoPix[0];
         A593PropostaResponsavelPIX = T001A92_A593PropostaResponsavelPIX[0];
         n593PropostaResponsavelPIX = T001A92_n593PropostaResponsavelPIX[0];
         A594PropostaResponsavelDepositoTipo = T001A92_A594PropostaResponsavelDepositoTipo[0];
         n594PropostaResponsavelDepositoTipo = T001A92_n594PropostaResponsavelDepositoTipo[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A580PropostaResponsavelDocumento)+"\""+","+"\""+GXUtil.EncodeJSConstant( A581PropostaResponsavelRazaoSocial)+"\""+","+"\""+GXUtil.EncodeJSConstant( A582PropostaResponsavelEmail)+"\""+","+"\""+GXUtil.EncodeJSConstant( A590PropostaResponsavelConta)+"\""+","+"\""+GXUtil.EncodeJSConstant( A591PropostaResponsavelAgencia)+"\""+","+"\""+GXUtil.EncodeJSConstant( A592PropostaResponsavelTipoPix)+"\""+","+"\""+GXUtil.EncodeJSConstant( A593PropostaResponsavelPIX)+"\""+","+"\""+GXUtil.EncodeJSConstant( A594PropostaResponsavelDepositoTipo)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(42) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(42);
      }

      protected void gxLoad_49( int A642PropostaClinicaId )
      {
         /* Using cursor T001A93 */
         pr_default.execute(43, new Object[] {n642PropostaClinicaId, A642PropostaClinicaId});
         if ( (pr_default.getStatus(43) == 101) )
         {
            if ( ! ( (0==A642PropostaClinicaId) ) )
            {
               GX_msglist.addItem("Não foi possível identificar o ID da clínica, por favor entre em contato com suporte.", "ForeignKeyNotFound", 1, "PROPOSTACLINICAID");
               AnyError = 1;
            }
         }
         A643PropostaClinicaNome = T001A93_A643PropostaClinicaNome[0];
         n643PropostaClinicaNome = T001A93_n643PropostaClinicaNome[0];
         A644PropostaClinicaNomeFantasia = T001A93_A644PropostaClinicaNomeFantasia[0];
         n644PropostaClinicaNomeFantasia = T001A93_n644PropostaClinicaNomeFantasia[0];
         A652PropostaClinicaDocumento = T001A93_A652PropostaClinicaDocumento[0];
         n652PropostaClinicaDocumento = T001A93_n652PropostaClinicaDocumento[0];
         A653PropostaClinicaEmail = T001A93_A653PropostaClinicaEmail[0];
         n653PropostaClinicaEmail = T001A93_n653PropostaClinicaEmail[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A643PropostaClinicaNome)+"\""+","+"\""+GXUtil.EncodeJSConstant( A644PropostaClinicaNomeFantasia)+"\""+","+"\""+GXUtil.EncodeJSConstant( A652PropostaClinicaDocumento)+"\""+","+"\""+GXUtil.EncodeJSConstant( A653PropostaClinicaEmail)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(43) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(43);
      }

      protected void gxLoad_50( int A850PropostaEmpresaClienteId )
      {
         /* Using cursor T001A94 */
         pr_default.execute(44, new Object[] {n850PropostaEmpresaClienteId, A850PropostaEmpresaClienteId});
         if ( (pr_default.getStatus(44) == 101) )
         {
            if ( ! ( (0==A850PropostaEmpresaClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Sd Proposta Empresa'.", "ForeignKeyNotFound", 1, "PROPOSTAEMPRESACLIENTEID");
               AnyError = 1;
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(44) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(44);
      }

      protected void GetKey1A49( )
      {
         /* Using cursor T001A95 */
         pr_default.execute(45, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(45) != 101) )
         {
            RcdFound49 = 1;
         }
         else
         {
            RcdFound49 = 0;
         }
         pr_default.close(45);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001A3 */
         pr_default.execute(1, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1A49( 42) ;
            RcdFound49 = 1;
            A323PropostaId = T001A3_A323PropostaId[0];
            n323PropostaId = T001A3_n323PropostaId[0];
            AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
            A327PropostaCreatedAt = T001A3_A327PropostaCreatedAt[0];
            n327PropostaCreatedAt = T001A3_n327PropostaCreatedAt[0];
            AssignAttri("", false, "A327PropostaCreatedAt", context.localUtil.TToC( A327PropostaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            A853PropostaProtocolo = T001A3_A853PropostaProtocolo[0];
            n853PropostaProtocolo = T001A3_n853PropostaProtocolo[0];
            A849PropostaTipoProposta = T001A3_A849PropostaTipoProposta[0];
            n849PropostaTipoProposta = T001A3_n849PropostaTipoProposta[0];
            A324PropostaTitulo = T001A3_A324PropostaTitulo[0];
            n324PropostaTitulo = T001A3_n324PropostaTitulo[0];
            AssignAttri("", false, "A324PropostaTitulo", A324PropostaTitulo);
            A325PropostaDescricao = T001A3_A325PropostaDescricao[0];
            n325PropostaDescricao = T001A3_n325PropostaDescricao[0];
            AssignAttri("", false, "A325PropostaDescricao", A325PropostaDescricao);
            A517PropostaDataCirurgia = T001A3_A517PropostaDataCirurgia[0];
            n517PropostaDataCirurgia = T001A3_n517PropostaDataCirurgia[0];
            A326PropostaValor = T001A3_A326PropostaValor[0];
            n326PropostaValor = T001A3_n326PropostaValor[0];
            AssignAttri("", false, "A326PropostaValor", ((Convert.ToDecimal(0)==A326PropostaValor)&&IsIns( )||n326PropostaValor ? "" : StringUtil.LTrim( StringUtil.NToC( A326PropostaValor, 18, 2, ".", ""))));
            A855PropostaValorLiquido = T001A3_A855PropostaValorLiquido[0];
            n855PropostaValorLiquido = T001A3_n855PropostaValorLiquido[0];
            A501PropostaTaxaAdministrativa = T001A3_A501PropostaTaxaAdministrativa[0];
            n501PropostaTaxaAdministrativa = T001A3_n501PropostaTaxaAdministrativa[0];
            A507PropostaSLA = T001A3_A507PropostaSLA[0];
            n507PropostaSLA = T001A3_n507PropostaSLA[0];
            A508PropostaJurosMora = T001A3_A508PropostaJurosMora[0];
            n508PropostaJurosMora = T001A3_n508PropostaJurosMora[0];
            A329PropostaStatus = T001A3_A329PropostaStatus[0];
            n329PropostaStatus = T001A3_n329PropostaStatus[0];
            AssignAttri("", false, "A329PropostaStatus", A329PropostaStatus);
            A790PropostaComentarioAnalise = T001A3_A790PropostaComentarioAnalise[0];
            n790PropostaComentarioAnalise = T001A3_n790PropostaComentarioAnalise[0];
            A330PropostaQuantidadeAprovadores = T001A3_A330PropostaQuantidadeAprovadores[0];
            n330PropostaQuantidadeAprovadores = T001A3_n330PropostaQuantidadeAprovadores[0];
            AssignAttri("", false, "A330PropostaQuantidadeAprovadores", ((0==A330PropostaQuantidadeAprovadores)&&IsIns( )||n330PropostaQuantidadeAprovadores ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A330PropostaQuantidadeAprovadores), 4, 0, ".", ""))));
            A345PropostaReprovacoesPermitidas = T001A3_A345PropostaReprovacoesPermitidas[0];
            n345PropostaReprovacoesPermitidas = T001A3_n345PropostaReprovacoesPermitidas[0];
            AssignAttri("", false, "A345PropostaReprovacoesPermitidas", ((0==A345PropostaReprovacoesPermitidas)&&IsIns( )||n345PropostaReprovacoesPermitidas ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A345PropostaReprovacoesPermitidas), 4, 0, ".", ""))));
            A496ConvenioVencimentoAno = T001A3_A496ConvenioVencimentoAno[0];
            n496ConvenioVencimentoAno = T001A3_n496ConvenioVencimentoAno[0];
            A497ConvenioVencimentoMes = T001A3_A497ConvenioVencimentoMes[0];
            n497ConvenioVencimentoMes = T001A3_n497ConvenioVencimentoMes[0];
            A227ContratoId = T001A3_A227ContratoId[0];
            n227ContratoId = T001A3_n227ContratoId[0];
            A376ProcedimentosMedicosId = T001A3_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = T001A3_n376ProcedimentosMedicosId[0];
            AssignAttri("", false, "A376ProcedimentosMedicosId", ((0==A376ProcedimentosMedicosId)&&IsIns( )||n376ProcedimentosMedicosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ProcedimentosMedicosId), 9, 0, ".", ""))));
            A493ConvenioCategoriaId = T001A3_A493ConvenioCategoriaId[0];
            n493ConvenioCategoriaId = T001A3_n493ConvenioCategoriaId[0];
            A328PropostaCratedBy = T001A3_A328PropostaCratedBy[0];
            n328PropostaCratedBy = T001A3_n328PropostaCratedBy[0];
            AssignAttri("", false, "A328PropostaCratedBy", ((0==A328PropostaCratedBy)&&IsIns( )||n328PropostaCratedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A328PropostaCratedBy), 4, 0, ".", ""))));
            A504PropostaPacienteClienteId = T001A3_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = T001A3_n504PropostaPacienteClienteId[0];
            A553PropostaResponsavelId = T001A3_A553PropostaResponsavelId[0];
            n553PropostaResponsavelId = T001A3_n553PropostaResponsavelId[0];
            A642PropostaClinicaId = T001A3_A642PropostaClinicaId[0];
            n642PropostaClinicaId = T001A3_n642PropostaClinicaId[0];
            A850PropostaEmpresaClienteId = T001A3_A850PropostaEmpresaClienteId[0];
            n850PropostaEmpresaClienteId = T001A3_n850PropostaEmpresaClienteId[0];
            Z323PropostaId = A323PropostaId;
            sMode49 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1A49( ) ;
            if ( AnyError == 1 )
            {
               RcdFound49 = 0;
               InitializeNonKey1A49( ) ;
            }
            Gx_mode = sMode49;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound49 = 0;
            InitializeNonKey1A49( ) ;
            sMode49 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode49;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1A49( ) ;
         if ( RcdFound49 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound49 = 0;
         /* Using cursor T001A96 */
         pr_default.execute(46, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(46) != 101) )
         {
            while ( (pr_default.getStatus(46) != 101) && ( ( T001A96_A323PropostaId[0] < A323PropostaId ) ) )
            {
               pr_default.readNext(46);
            }
            if ( (pr_default.getStatus(46) != 101) && ( ( T001A96_A323PropostaId[0] > A323PropostaId ) ) )
            {
               A323PropostaId = T001A96_A323PropostaId[0];
               n323PropostaId = T001A96_n323PropostaId[0];
               AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
               RcdFound49 = 1;
            }
         }
         pr_default.close(46);
      }

      protected void move_previous( )
      {
         RcdFound49 = 0;
         /* Using cursor T001A97 */
         pr_default.execute(47, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(47) != 101) )
         {
            while ( (pr_default.getStatus(47) != 101) && ( ( T001A97_A323PropostaId[0] > A323PropostaId ) ) )
            {
               pr_default.readNext(47);
            }
            if ( (pr_default.getStatus(47) != 101) && ( ( T001A97_A323PropostaId[0] < A323PropostaId ) ) )
            {
               A323PropostaId = T001A97_A323PropostaId[0];
               n323PropostaId = T001A97_n323PropostaId[0];
               AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
               RcdFound49 = 1;
            }
         }
         pr_default.close(47);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1A49( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPropostaTitulo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1A49( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound49 == 1 )
            {
               if ( A323PropostaId != Z323PropostaId )
               {
                  A323PropostaId = Z323PropostaId;
                  n323PropostaId = false;
                  AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PROPOSTAID");
                  AnyError = 1;
                  GX_FocusControl = edtPropostaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPropostaTitulo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1A49( ) ;
                  GX_FocusControl = edtPropostaTitulo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A323PropostaId != Z323PropostaId )
               {
                  /* Insert record */
                  GX_FocusControl = edtPropostaTitulo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1A49( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROPOSTAID");
                     AnyError = 1;
                     GX_FocusControl = edtPropostaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtPropostaTitulo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1A49( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A323PropostaId != Z323PropostaId )
         {
            A323PropostaId = Z323PropostaId;
            n323PropostaId = false;
            AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PROPOSTAID");
            AnyError = 1;
            GX_FocusControl = edtPropostaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPropostaTitulo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1A49( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001A2 */
            pr_default.execute(0, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Proposta"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z327PropostaCreatedAt != T001A2_A327PropostaCreatedAt[0] ) || ( StringUtil.StrCmp(Z853PropostaProtocolo, T001A2_A853PropostaProtocolo[0]) != 0 ) || ( StringUtil.StrCmp(Z849PropostaTipoProposta, T001A2_A849PropostaTipoProposta[0]) != 0 ) || ( StringUtil.StrCmp(Z324PropostaTitulo, T001A2_A324PropostaTitulo[0]) != 0 ) || ( StringUtil.StrCmp(Z325PropostaDescricao, T001A2_A325PropostaDescricao[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z517PropostaDataCirurgia ) != DateTimeUtil.ResetTime ( T001A2_A517PropostaDataCirurgia[0] ) ) || ( Z326PropostaValor != T001A2_A326PropostaValor[0] ) || ( Z855PropostaValorLiquido != T001A2_A855PropostaValorLiquido[0] ) || ( Z501PropostaTaxaAdministrativa != T001A2_A501PropostaTaxaAdministrativa[0] ) || ( Z507PropostaSLA != T001A2_A507PropostaSLA[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z508PropostaJurosMora != T001A2_A508PropostaJurosMora[0] ) || ( StringUtil.StrCmp(Z329PropostaStatus, T001A2_A329PropostaStatus[0]) != 0 ) || ( StringUtil.StrCmp(Z790PropostaComentarioAnalise, T001A2_A790PropostaComentarioAnalise[0]) != 0 ) || ( Z330PropostaQuantidadeAprovadores != T001A2_A330PropostaQuantidadeAprovadores[0] ) || ( Z345PropostaReprovacoesPermitidas != T001A2_A345PropostaReprovacoesPermitidas[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z496ConvenioVencimentoAno != T001A2_A496ConvenioVencimentoAno[0] ) || ( Z497ConvenioVencimentoMes != T001A2_A497ConvenioVencimentoMes[0] ) || ( Z227ContratoId != T001A2_A227ContratoId[0] ) || ( Z376ProcedimentosMedicosId != T001A2_A376ProcedimentosMedicosId[0] ) || ( Z493ConvenioCategoriaId != T001A2_A493ConvenioCategoriaId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z328PropostaCratedBy != T001A2_A328PropostaCratedBy[0] ) || ( Z504PropostaPacienteClienteId != T001A2_A504PropostaPacienteClienteId[0] ) || ( Z553PropostaResponsavelId != T001A2_A553PropostaResponsavelId[0] ) || ( Z642PropostaClinicaId != T001A2_A642PropostaClinicaId[0] ) || ( Z850PropostaEmpresaClienteId != T001A2_A850PropostaEmpresaClienteId[0] ) )
            {
               if ( Z327PropostaCreatedAt != T001A2_A327PropostaCreatedAt[0] )
               {
                  GXUtil.WriteLog("proposta:[seudo value changed for attri]"+"PropostaCreatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z327PropostaCreatedAt);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A327PropostaCreatedAt[0]);
               }
               if ( StringUtil.StrCmp(Z853PropostaProtocolo, T001A2_A853PropostaProtocolo[0]) != 0 )
               {
                  GXUtil.WriteLog("proposta:[seudo value changed for attri]"+"PropostaProtocolo");
                  GXUtil.WriteLogRaw("Old: ",Z853PropostaProtocolo);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A853PropostaProtocolo[0]);
               }
               if ( StringUtil.StrCmp(Z849PropostaTipoProposta, T001A2_A849PropostaTipoProposta[0]) != 0 )
               {
                  GXUtil.WriteLog("proposta:[seudo value changed for attri]"+"PropostaTipoProposta");
                  GXUtil.WriteLogRaw("Old: ",Z849PropostaTipoProposta);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A849PropostaTipoProposta[0]);
               }
               if ( StringUtil.StrCmp(Z324PropostaTitulo, T001A2_A324PropostaTitulo[0]) != 0 )
               {
                  GXUtil.WriteLog("proposta:[seudo value changed for attri]"+"PropostaTitulo");
                  GXUtil.WriteLogRaw("Old: ",Z324PropostaTitulo);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A324PropostaTitulo[0]);
               }
               if ( StringUtil.StrCmp(Z325PropostaDescricao, T001A2_A325PropostaDescricao[0]) != 0 )
               {
                  GXUtil.WriteLog("proposta:[seudo value changed for attri]"+"PropostaDescricao");
                  GXUtil.WriteLogRaw("Old: ",Z325PropostaDescricao);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A325PropostaDescricao[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z517PropostaDataCirurgia ) != DateTimeUtil.ResetTime ( T001A2_A517PropostaDataCirurgia[0] ) )
               {
                  GXUtil.WriteLog("proposta:[seudo value changed for attri]"+"PropostaDataCirurgia");
                  GXUtil.WriteLogRaw("Old: ",Z517PropostaDataCirurgia);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A517PropostaDataCirurgia[0]);
               }
               if ( Z326PropostaValor != T001A2_A326PropostaValor[0] )
               {
                  GXUtil.WriteLog("proposta:[seudo value changed for attri]"+"PropostaValor");
                  GXUtil.WriteLogRaw("Old: ",Z326PropostaValor);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A326PropostaValor[0]);
               }
               if ( Z855PropostaValorLiquido != T001A2_A855PropostaValorLiquido[0] )
               {
                  GXUtil.WriteLog("proposta:[seudo value changed for attri]"+"PropostaValorLiquido");
                  GXUtil.WriteLogRaw("Old: ",Z855PropostaValorLiquido);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A855PropostaValorLiquido[0]);
               }
               if ( Z501PropostaTaxaAdministrativa != T001A2_A501PropostaTaxaAdministrativa[0] )
               {
                  GXUtil.WriteLog("proposta:[seudo value changed for attri]"+"PropostaTaxaAdministrativa");
                  GXUtil.WriteLogRaw("Old: ",Z501PropostaTaxaAdministrativa);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A501PropostaTaxaAdministrativa[0]);
               }
               if ( Z507PropostaSLA != T001A2_A507PropostaSLA[0] )
               {
                  GXUtil.WriteLog("proposta:[seudo value changed for attri]"+"PropostaSLA");
                  GXUtil.WriteLogRaw("Old: ",Z507PropostaSLA);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A507PropostaSLA[0]);
               }
               if ( Z508PropostaJurosMora != T001A2_A508PropostaJurosMora[0] )
               {
                  GXUtil.WriteLog("proposta:[seudo value changed for attri]"+"PropostaJurosMora");
                  GXUtil.WriteLogRaw("Old: ",Z508PropostaJurosMora);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A508PropostaJurosMora[0]);
               }
               if ( StringUtil.StrCmp(Z329PropostaStatus, T001A2_A329PropostaStatus[0]) != 0 )
               {
                  GXUtil.WriteLog("proposta:[seudo value changed for attri]"+"PropostaStatus");
                  GXUtil.WriteLogRaw("Old: ",Z329PropostaStatus);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A329PropostaStatus[0]);
               }
               if ( StringUtil.StrCmp(Z790PropostaComentarioAnalise, T001A2_A790PropostaComentarioAnalise[0]) != 0 )
               {
                  GXUtil.WriteLog("proposta:[seudo value changed for attri]"+"PropostaComentarioAnalise");
                  GXUtil.WriteLogRaw("Old: ",Z790PropostaComentarioAnalise);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A790PropostaComentarioAnalise[0]);
               }
               if ( Z330PropostaQuantidadeAprovadores != T001A2_A330PropostaQuantidadeAprovadores[0] )
               {
                  GXUtil.WriteLog("proposta:[seudo value changed for attri]"+"PropostaQuantidadeAprovadores");
                  GXUtil.WriteLogRaw("Old: ",Z330PropostaQuantidadeAprovadores);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A330PropostaQuantidadeAprovadores[0]);
               }
               if ( Z345PropostaReprovacoesPermitidas != T001A2_A345PropostaReprovacoesPermitidas[0] )
               {
                  GXUtil.WriteLog("proposta:[seudo value changed for attri]"+"PropostaReprovacoesPermitidas");
                  GXUtil.WriteLogRaw("Old: ",Z345PropostaReprovacoesPermitidas);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A345PropostaReprovacoesPermitidas[0]);
               }
               if ( Z496ConvenioVencimentoAno != T001A2_A496ConvenioVencimentoAno[0] )
               {
                  GXUtil.WriteLog("proposta:[seudo value changed for attri]"+"ConvenioVencimentoAno");
                  GXUtil.WriteLogRaw("Old: ",Z496ConvenioVencimentoAno);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A496ConvenioVencimentoAno[0]);
               }
               if ( Z497ConvenioVencimentoMes != T001A2_A497ConvenioVencimentoMes[0] )
               {
                  GXUtil.WriteLog("proposta:[seudo value changed for attri]"+"ConvenioVencimentoMes");
                  GXUtil.WriteLogRaw("Old: ",Z497ConvenioVencimentoMes);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A497ConvenioVencimentoMes[0]);
               }
               if ( Z227ContratoId != T001A2_A227ContratoId[0] )
               {
                  GXUtil.WriteLog("proposta:[seudo value changed for attri]"+"ContratoId");
                  GXUtil.WriteLogRaw("Old: ",Z227ContratoId);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A227ContratoId[0]);
               }
               if ( Z376ProcedimentosMedicosId != T001A2_A376ProcedimentosMedicosId[0] )
               {
                  GXUtil.WriteLog("proposta:[seudo value changed for attri]"+"ProcedimentosMedicosId");
                  GXUtil.WriteLogRaw("Old: ",Z376ProcedimentosMedicosId);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A376ProcedimentosMedicosId[0]);
               }
               if ( Z493ConvenioCategoriaId != T001A2_A493ConvenioCategoriaId[0] )
               {
                  GXUtil.WriteLog("proposta:[seudo value changed for attri]"+"ConvenioCategoriaId");
                  GXUtil.WriteLogRaw("Old: ",Z493ConvenioCategoriaId);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A493ConvenioCategoriaId[0]);
               }
               if ( Z328PropostaCratedBy != T001A2_A328PropostaCratedBy[0] )
               {
                  GXUtil.WriteLog("proposta:[seudo value changed for attri]"+"PropostaCratedBy");
                  GXUtil.WriteLogRaw("Old: ",Z328PropostaCratedBy);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A328PropostaCratedBy[0]);
               }
               if ( Z504PropostaPacienteClienteId != T001A2_A504PropostaPacienteClienteId[0] )
               {
                  GXUtil.WriteLog("proposta:[seudo value changed for attri]"+"PropostaPacienteClienteId");
                  GXUtil.WriteLogRaw("Old: ",Z504PropostaPacienteClienteId);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A504PropostaPacienteClienteId[0]);
               }
               if ( Z553PropostaResponsavelId != T001A2_A553PropostaResponsavelId[0] )
               {
                  GXUtil.WriteLog("proposta:[seudo value changed for attri]"+"PropostaResponsavelId");
                  GXUtil.WriteLogRaw("Old: ",Z553PropostaResponsavelId);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A553PropostaResponsavelId[0]);
               }
               if ( Z642PropostaClinicaId != T001A2_A642PropostaClinicaId[0] )
               {
                  GXUtil.WriteLog("proposta:[seudo value changed for attri]"+"PropostaClinicaId");
                  GXUtil.WriteLogRaw("Old: ",Z642PropostaClinicaId);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A642PropostaClinicaId[0]);
               }
               if ( Z850PropostaEmpresaClienteId != T001A2_A850PropostaEmpresaClienteId[0] )
               {
                  GXUtil.WriteLog("proposta:[seudo value changed for attri]"+"PropostaEmpresaClienteId");
                  GXUtil.WriteLogRaw("Old: ",Z850PropostaEmpresaClienteId);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A850PropostaEmpresaClienteId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Proposta"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1A49( )
      {
         BeforeValidate1A49( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1A49( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1A49( 0) ;
            CheckOptimisticConcurrency1A49( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1A49( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1A49( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001A98 */
                     pr_default.execute(48, new Object[] {n327PropostaCreatedAt, A327PropostaCreatedAt, n853PropostaProtocolo, A853PropostaProtocolo, n849PropostaTipoProposta, A849PropostaTipoProposta, n324PropostaTitulo, A324PropostaTitulo, n325PropostaDescricao, A325PropostaDescricao, n517PropostaDataCirurgia, A517PropostaDataCirurgia, n326PropostaValor, A326PropostaValor, n855PropostaValorLiquido, A855PropostaValorLiquido, n501PropostaTaxaAdministrativa, A501PropostaTaxaAdministrativa, n507PropostaSLA, A507PropostaSLA, n508PropostaJurosMora, A508PropostaJurosMora, n329PropostaStatus, A329PropostaStatus, n790PropostaComentarioAnalise, A790PropostaComentarioAnalise, n330PropostaQuantidadeAprovadores, A330PropostaQuantidadeAprovadores, n345PropostaReprovacoesPermitidas, A345PropostaReprovacoesPermitidas, n496ConvenioVencimentoAno, A496ConvenioVencimentoAno, n497ConvenioVencimentoMes, A497ConvenioVencimentoMes, n227ContratoId, A227ContratoId, n376ProcedimentosMedicosId, A376ProcedimentosMedicosId, n493ConvenioCategoriaId, A493ConvenioCategoriaId, n328PropostaCratedBy, A328PropostaCratedBy, n504PropostaPacienteClienteId, A504PropostaPacienteClienteId, n553PropostaResponsavelId, A553PropostaResponsavelId, n642PropostaClinicaId, A642PropostaClinicaId, n850PropostaEmpresaClienteId, A850PropostaEmpresaClienteId});
                     pr_default.close(48);
                     /* Retrieving last key number assigned */
                     /* Using cursor T001A99 */
                     pr_default.execute(49);
                     A323PropostaId = T001A99_A323PropostaId[0];
                     n323PropostaId = T001A99_n323PropostaId[0];
                     AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
                     pr_default.close(49);
                     pr_default.SmartCacheProvider.SetUpdated("Proposta");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption1A0( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load1A49( ) ;
            }
            EndLevel1A49( ) ;
         }
         CloseExtendedTableCursors1A49( ) ;
      }

      protected void Update1A49( )
      {
         BeforeValidate1A49( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1A49( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1A49( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1A49( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1A49( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001A100 */
                     pr_default.execute(50, new Object[] {n327PropostaCreatedAt, A327PropostaCreatedAt, n853PropostaProtocolo, A853PropostaProtocolo, n849PropostaTipoProposta, A849PropostaTipoProposta, n324PropostaTitulo, A324PropostaTitulo, n325PropostaDescricao, A325PropostaDescricao, n517PropostaDataCirurgia, A517PropostaDataCirurgia, n326PropostaValor, A326PropostaValor, n855PropostaValorLiquido, A855PropostaValorLiquido, n501PropostaTaxaAdministrativa, A501PropostaTaxaAdministrativa, n507PropostaSLA, A507PropostaSLA, n508PropostaJurosMora, A508PropostaJurosMora, n329PropostaStatus, A329PropostaStatus, n790PropostaComentarioAnalise, A790PropostaComentarioAnalise, n330PropostaQuantidadeAprovadores, A330PropostaQuantidadeAprovadores, n345PropostaReprovacoesPermitidas, A345PropostaReprovacoesPermitidas, n496ConvenioVencimentoAno, A496ConvenioVencimentoAno, n497ConvenioVencimentoMes, A497ConvenioVencimentoMes, n227ContratoId, A227ContratoId, n376ProcedimentosMedicosId, A376ProcedimentosMedicosId, n493ConvenioCategoriaId, A493ConvenioCategoriaId, n328PropostaCratedBy, A328PropostaCratedBy, n504PropostaPacienteClienteId, A504PropostaPacienteClienteId, n553PropostaResponsavelId, A553PropostaResponsavelId, n642PropostaClinicaId, A642PropostaClinicaId, n850PropostaEmpresaClienteId, A850PropostaEmpresaClienteId, n323PropostaId, A323PropostaId});
                     pr_default.close(50);
                     pr_default.SmartCacheProvider.SetUpdated("Proposta");
                     if ( (pr_default.getStatus(50) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Proposta"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1A49( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel1A49( ) ;
         }
         CloseExtendedTableCursors1A49( ) ;
      }

      protected void DeferredUpdate1A49( )
      {
      }

      protected void delete( )
      {
         BeforeValidate1A49( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1A49( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1A49( ) ;
            AfterConfirm1A49( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1A49( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001A101 */
                  pr_default.execute(51, new Object[] {n323PropostaId, A323PropostaId});
                  pr_default.close(51);
                  pr_default.SmartCacheProvider.SetUpdated("Proposta");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsUpd( ) || IsDlt( ) )
                        {
                           if ( AnyError == 0 )
                           {
                              context.nUserReturn = 1;
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode49 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1A49( ) ;
         Gx_mode = sMode49;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1A49( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001A103 */
            pr_default.execute(52, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(52) != 101) )
            {
               A649PropostaMaxReembolsoId_F = T001A103_A649PropostaMaxReembolsoId_F[0];
               n649PropostaMaxReembolsoId_F = T001A103_n649PropostaMaxReembolsoId_F[0];
            }
            else
            {
               A649PropostaMaxReembolsoId_F = 0;
               n649PropostaMaxReembolsoId_F = false;
               AssignAttri("", false, "A649PropostaMaxReembolsoId_F", StringUtil.LTrimStr( (decimal)(A649PropostaMaxReembolsoId_F), 9, 0));
            }
            pr_default.close(52);
            /* Using cursor T001A105 */
            pr_default.execute(53, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(53) != 101) )
            {
               A854PropostaQtdItensNota_F = T001A105_A854PropostaQtdItensNota_F[0];
               n854PropostaQtdItensNota_F = T001A105_n854PropostaQtdItensNota_F[0];
            }
            else
            {
               A854PropostaQtdItensNota_F = 0;
               n854PropostaQtdItensNota_F = false;
               AssignAttri("", false, "A854PropostaQtdItensNota_F", StringUtil.LTrimStr( (decimal)(A854PropostaQtdItensNota_F), 4, 0));
            }
            pr_default.close(53);
            /* Using cursor T001A107 */
            pr_default.execute(54, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(54) != 101) )
            {
               A655PropostaQtdDocumentoPendente_F = T001A107_A655PropostaQtdDocumentoPendente_F[0];
               n655PropostaQtdDocumentoPendente_F = T001A107_n655PropostaQtdDocumentoPendente_F[0];
            }
            else
            {
               A655PropostaQtdDocumentoPendente_F = 0;
               n655PropostaQtdDocumentoPendente_F = false;
               AssignAttri("", false, "A655PropostaQtdDocumentoPendente_F", StringUtil.LTrimStr( (decimal)(A655PropostaQtdDocumentoPendente_F), 4, 0));
            }
            pr_default.close(54);
            /* Using cursor T001A109 */
            pr_default.execute(55, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(55) != 101) )
            {
               A341PropostaAprovacoes_F = T001A109_A341PropostaAprovacoes_F[0];
               n341PropostaAprovacoes_F = T001A109_n341PropostaAprovacoes_F[0];
               AssignAttri("", false, "A341PropostaAprovacoes_F", StringUtil.LTrimStr( (decimal)(A341PropostaAprovacoes_F), 4, 0));
            }
            else
            {
               A341PropostaAprovacoes_F = 0;
               n341PropostaAprovacoes_F = false;
               AssignAttri("", false, "A341PropostaAprovacoes_F", StringUtil.LTrimStr( (decimal)(A341PropostaAprovacoes_F), 4, 0));
            }
            pr_default.close(55);
            /* Using cursor T001A111 */
            pr_default.execute(56, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(56) != 101) )
            {
               A342PropostaReprovacoes_F = T001A111_A342PropostaReprovacoes_F[0];
               n342PropostaReprovacoes_F = T001A111_n342PropostaReprovacoes_F[0];
               AssignAttri("", false, "A342PropostaReprovacoes_F", StringUtil.LTrimStr( (decimal)(A342PropostaReprovacoes_F), 4, 0));
            }
            else
            {
               A342PropostaReprovacoes_F = 0;
               n342PropostaReprovacoes_F = false;
               AssignAttri("", false, "A342PropostaReprovacoes_F", StringUtil.LTrimStr( (decimal)(A342PropostaReprovacoes_F), 4, 0));
            }
            pr_default.close(56);
            /* Using cursor T001A112 */
            pr_default.execute(57, new Object[] {n328PropostaCratedBy, A328PropostaCratedBy});
            A512PropostaSecUserName = T001A112_A512PropostaSecUserName[0];
            n512PropostaSecUserName = T001A112_n512PropostaSecUserName[0];
            pr_default.close(57);
            /* Using cursor T001A115 */
            pr_default.execute(58, new Object[] {n328PropostaCratedBy, A328PropostaCratedBy, n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(58) != 101) )
            {
               A511PropostaValorTaxaRecebida_F = T001A115_A511PropostaValorTaxaRecebida_F[0];
               n511PropostaValorTaxaRecebida_F = T001A115_n511PropostaValorTaxaRecebida_F[0];
            }
            else
            {
               A511PropostaValorTaxaRecebida_F = 0;
               n511PropostaValorTaxaRecebida_F = false;
               AssignAttri("", false, "A511PropostaValorTaxaRecebida_F", StringUtil.LTrimStr( A511PropostaValorTaxaRecebida_F, 18, 2));
            }
            pr_default.close(58);
            A343PropostaAprovacoesRestantes_F = (short)(A330PropostaQuantidadeAprovadores-A341PropostaAprovacoes_F);
            AssignAttri("", false, "A343PropostaAprovacoesRestantes_F", StringUtil.LTrimStr( (decimal)(A343PropostaAprovacoesRestantes_F), 4, 0));
            A575PropostaTaxa_F = (decimal)(A326PropostaValor*(A501PropostaTaxaAdministrativa/ (decimal)(100)));
            AssignAttri("", false, "A575PropostaTaxa_F", StringUtil.LTrimStr( A575PropostaTaxa_F, 18, 2));
            A513PropostaValorTaxa_F = (decimal)(A326PropostaValor*(A501PropostaTaxaAdministrativa/ (decimal)(100)));
            AssignAttri("", false, "A513PropostaValorTaxa_F", StringUtil.LTrimStr( A513PropostaValorTaxa_F, 18, 2));
            /* Using cursor T001A116 */
            pr_default.execute(59, new Object[] {n227ContratoId, A227ContratoId});
            A228ContratoNome = T001A116_A228ContratoNome[0];
            n228ContratoNome = T001A116_n228ContratoNome[0];
            pr_default.close(59);
            /* Using cursor T001A117 */
            pr_default.execute(60, new Object[] {n493ConvenioCategoriaId, A493ConvenioCategoriaId});
            A494ConvenioCategoriaDescricao = T001A117_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = T001A117_n494ConvenioCategoriaDescricao[0];
            A410ConvenioId = T001A117_A410ConvenioId[0];
            n410ConvenioId = T001A117_n410ConvenioId[0];
            pr_default.close(60);
            /* Using cursor T001A118 */
            pr_default.execute(61, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId});
            A505PropostaPacienteClienteRazaoSocial = T001A118_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = T001A118_n505PropostaPacienteClienteRazaoSocial[0];
            A540PropostaPacienteClienteDocumento = T001A118_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = T001A118_n540PropostaPacienteClienteDocumento[0];
            A541PropostaPacienteContatoEmail = T001A118_A541PropostaPacienteContatoEmail[0];
            n541PropostaPacienteContatoEmail = T001A118_n541PropostaPacienteContatoEmail[0];
            A584PropostaPacienteConta = T001A118_A584PropostaPacienteConta[0];
            n584PropostaPacienteConta = T001A118_n584PropostaPacienteConta[0];
            A585PropostaPacienteAgencia = T001A118_A585PropostaPacienteAgencia[0];
            n585PropostaPacienteAgencia = T001A118_n585PropostaPacienteAgencia[0];
            A586PropostaPacienteTipoPix = T001A118_A586PropostaPacienteTipoPix[0];
            n586PropostaPacienteTipoPix = T001A118_n586PropostaPacienteTipoPix[0];
            A587PropostaPacientePIX = T001A118_A587PropostaPacientePIX[0];
            n587PropostaPacientePIX = T001A118_n587PropostaPacientePIX[0];
            A588PropostaPacienteDepositoTipo = T001A118_A588PropostaPacienteDepositoTipo[0];
            n588PropostaPacienteDepositoTipo = T001A118_n588PropostaPacienteDepositoTipo[0];
            A620PropostaPacienteEnderecoCEP = T001A118_A620PropostaPacienteEnderecoCEP[0];
            n620PropostaPacienteEnderecoCEP = T001A118_n620PropostaPacienteEnderecoCEP[0];
            A621PropostaPacienteEnderecoLogradouro = T001A118_A621PropostaPacienteEnderecoLogradouro[0];
            n621PropostaPacienteEnderecoLogradouro = T001A118_n621PropostaPacienteEnderecoLogradouro[0];
            A622PropostaPacienteEnderecoNumero = T001A118_A622PropostaPacienteEnderecoNumero[0];
            n622PropostaPacienteEnderecoNumero = T001A118_n622PropostaPacienteEnderecoNumero[0];
            A623PropostaPacienteEnderecoComplemento = T001A118_A623PropostaPacienteEnderecoComplemento[0];
            n623PropostaPacienteEnderecoComplemento = T001A118_n623PropostaPacienteEnderecoComplemento[0];
            A624PropostaPacienteEnderecoBairro = T001A118_A624PropostaPacienteEnderecoBairro[0];
            n624PropostaPacienteEnderecoBairro = T001A118_n624PropostaPacienteEnderecoBairro[0];
            A625PropostaPacienteMunicipioCodigo = T001A118_A625PropostaPacienteMunicipioCodigo[0];
            n625PropostaPacienteMunicipioCodigo = T001A118_n625PropostaPacienteMunicipioCodigo[0];
            pr_default.close(61);
            /* Using cursor T001A121 */
            pr_default.execute(62, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId, n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(62) != 101) )
            {
               A509PropostaValorReembolsado_F = T001A121_A509PropostaValorReembolsado_F[0];
               n509PropostaValorReembolsado_F = T001A121_n509PropostaValorReembolsado_F[0];
            }
            else
            {
               A509PropostaValorReembolsado_F = 0;
               n509PropostaValorReembolsado_F = false;
               AssignAttri("", false, "A509PropostaValorReembolsado_F", StringUtil.LTrimStr( A509PropostaValorReembolsado_F, 18, 2));
            }
            pr_default.close(62);
            /* Using cursor T001A124 */
            pr_default.execute(63, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId, n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(63) != 101) )
            {
               A510PropostaValorReembolsadoJuros_F = T001A124_A510PropostaValorReembolsadoJuros_F[0];
               n510PropostaValorReembolsadoJuros_F = T001A124_n510PropostaValorReembolsadoJuros_F[0];
            }
            else
            {
               A510PropostaValorReembolsadoJuros_F = 0;
               n510PropostaValorReembolsadoJuros_F = false;
               AssignAttri("", false, "A510PropostaValorReembolsadoJuros_F", StringUtil.LTrimStr( A510PropostaValorReembolsadoJuros_F, 18, 2));
            }
            pr_default.close(63);
            /* Using cursor T001A127 */
            pr_default.execute(64, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId, n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(64) != 101) )
            {
               A515PropostaDataCreditoCliente_F = T001A127_A515PropostaDataCreditoCliente_F[0];
               n515PropostaDataCreditoCliente_F = T001A127_n515PropostaDataCreditoCliente_F[0];
            }
            else
            {
               A515PropostaDataCreditoCliente_F = DateTime.MinValue;
               n515PropostaDataCreditoCliente_F = false;
               AssignAttri("", false, "A515PropostaDataCreditoCliente_F", context.localUtil.Format(A515PropostaDataCreditoCliente_F, "99/99/9999"));
            }
            pr_default.close(64);
            GXt_decimal3 = A514PropostaValorJurosMora_F;
            new prcalcularjurosmora(context ).execute(  A515PropostaDataCreditoCliente_F,  A507PropostaSLA,  A508PropostaJurosMora,  A326PropostaValor, out  GXt_decimal3) ;
            A514PropostaValorJurosMora_F = GXt_decimal3;
            AssignAttri("", false, "A514PropostaValorJurosMora_F", StringUtil.LTrimStr( A514PropostaValorJurosMora_F, 18, 2));
            /* Using cursor T001A129 */
            pr_default.execute(65, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId});
            if ( (pr_default.getStatus(65) != 101) )
            {
               A733PropostaResponsavelSerasaConsultas_F = T001A129_A733PropostaResponsavelSerasaConsultas_F[0];
               n733PropostaResponsavelSerasaConsultas_F = T001A129_n733PropostaResponsavelSerasaConsultas_F[0];
               A734PropostaPacienteSerasaConsultas_F = T001A129_A734PropostaPacienteSerasaConsultas_F[0];
               n734PropostaPacienteSerasaConsultas_F = T001A129_n734PropostaPacienteSerasaConsultas_F[0];
            }
            else
            {
               A734PropostaPacienteSerasaConsultas_F = 0;
               n734PropostaPacienteSerasaConsultas_F = false;
               AssignAttri("", false, "A734PropostaPacienteSerasaConsultas_F", StringUtil.LTrimStr( (decimal)(A734PropostaPacienteSerasaConsultas_F), 4, 0));
               A733PropostaResponsavelSerasaConsultas_F = 0;
               n733PropostaResponsavelSerasaConsultas_F = false;
               AssignAttri("", false, "A733PropostaResponsavelSerasaConsultas_F", StringUtil.LTrimStr( (decimal)(A733PropostaResponsavelSerasaConsultas_F), 4, 0));
            }
            pr_default.close(65);
            /* Using cursor T001A132 */
            pr_default.execute(66, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId});
            if ( (pr_default.getStatus(66) != 101) )
            {
               A783PropostaResponsavelSerasaScoreUltimaData_F = T001A132_A783PropostaResponsavelSerasaScoreUltimaData_F[0];
               n783PropostaResponsavelSerasaScoreUltimaData_F = T001A132_n783PropostaResponsavelSerasaScoreUltimaData_F[0];
               A782PropostaSerasaScoreUltimaData_F = T001A132_A782PropostaSerasaScoreUltimaData_F[0];
               n782PropostaSerasaScoreUltimaData_F = T001A132_n782PropostaSerasaScoreUltimaData_F[0];
            }
            else
            {
               A782PropostaSerasaScoreUltimaData_F = 0;
               n782PropostaSerasaScoreUltimaData_F = false;
               AssignAttri("", false, "A782PropostaSerasaScoreUltimaData_F", StringUtil.LTrimStr( (decimal)(A782PropostaSerasaScoreUltimaData_F), 4, 0));
               A783PropostaResponsavelSerasaScoreUltimaData_F = 0;
               n783PropostaResponsavelSerasaScoreUltimaData_F = false;
               AssignAttri("", false, "A783PropostaResponsavelSerasaScoreUltimaData_F", StringUtil.LTrimStr( (decimal)(A783PropostaResponsavelSerasaScoreUltimaData_F), 4, 0));
            }
            pr_default.close(66);
            A784PropostaMaiorScore_F = (short)(((A782PropostaSerasaScoreUltimaData_F>A783PropostaResponsavelSerasaScoreUltimaData_F) ? A782PropostaSerasaScoreUltimaData_F : A783PropostaResponsavelSerasaScoreUltimaData_F));
            AssignAttri("", false, "A784PropostaMaiorScore_F", StringUtil.LTrimStr( (decimal)(A784PropostaMaiorScore_F), 4, 0));
            /* Using cursor T001A135 */
            pr_default.execute(67, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId});
            if ( (pr_default.getStatus(67) != 101) )
            {
               A786PropostaResponsavelSerasaUltimoValorRecomendado_F = T001A135_A786PropostaResponsavelSerasaUltimoValorRecomendado_F[0];
               n786PropostaResponsavelSerasaUltimoValorRecomendado_F = T001A135_n786PropostaResponsavelSerasaUltimoValorRecomendado_F[0];
               A787PropostaPacienteSerasaUltimoValorRecomendado_F = T001A135_A787PropostaPacienteSerasaUltimoValorRecomendado_F[0];
               n787PropostaPacienteSerasaUltimoValorRecomendado_F = T001A135_n787PropostaPacienteSerasaUltimoValorRecomendado_F[0];
            }
            else
            {
               A787PropostaPacienteSerasaUltimoValorRecomendado_F = 0;
               n787PropostaPacienteSerasaUltimoValorRecomendado_F = false;
               AssignAttri("", false, "A787PropostaPacienteSerasaUltimoValorRecomendado_F", StringUtil.LTrimStr( A787PropostaPacienteSerasaUltimoValorRecomendado_F, 18, 2));
               A786PropostaResponsavelSerasaUltimoValorRecomendado_F = 0;
               n786PropostaResponsavelSerasaUltimoValorRecomendado_F = false;
               AssignAttri("", false, "A786PropostaResponsavelSerasaUltimoValorRecomendado_F", StringUtil.LTrimStr( A786PropostaResponsavelSerasaUltimoValorRecomendado_F, 18, 2));
            }
            pr_default.close(67);
            A788PropostaMaiorValorRecomendado = ((A786PropostaResponsavelSerasaUltimoValorRecomendado_F>A787PropostaPacienteSerasaUltimoValorRecomendado_F) ? A786PropostaResponsavelSerasaUltimoValorRecomendado_F : A787PropostaPacienteSerasaUltimoValorRecomendado_F);
            AssignAttri("", false, "A788PropostaMaiorValorRecomendado", StringUtil.LTrimStr( A788PropostaMaiorValorRecomendado, 18, 2));
            /* Using cursor T001A136 */
            pr_default.execute(68, new Object[] {n553PropostaResponsavelId, A553PropostaResponsavelId});
            A580PropostaResponsavelDocumento = T001A136_A580PropostaResponsavelDocumento[0];
            n580PropostaResponsavelDocumento = T001A136_n580PropostaResponsavelDocumento[0];
            A581PropostaResponsavelRazaoSocial = T001A136_A581PropostaResponsavelRazaoSocial[0];
            n581PropostaResponsavelRazaoSocial = T001A136_n581PropostaResponsavelRazaoSocial[0];
            A582PropostaResponsavelEmail = T001A136_A582PropostaResponsavelEmail[0];
            n582PropostaResponsavelEmail = T001A136_n582PropostaResponsavelEmail[0];
            A590PropostaResponsavelConta = T001A136_A590PropostaResponsavelConta[0];
            n590PropostaResponsavelConta = T001A136_n590PropostaResponsavelConta[0];
            A591PropostaResponsavelAgencia = T001A136_A591PropostaResponsavelAgencia[0];
            n591PropostaResponsavelAgencia = T001A136_n591PropostaResponsavelAgencia[0];
            A592PropostaResponsavelTipoPix = T001A136_A592PropostaResponsavelTipoPix[0];
            n592PropostaResponsavelTipoPix = T001A136_n592PropostaResponsavelTipoPix[0];
            A593PropostaResponsavelPIX = T001A136_A593PropostaResponsavelPIX[0];
            n593PropostaResponsavelPIX = T001A136_n593PropostaResponsavelPIX[0];
            A594PropostaResponsavelDepositoTipo = T001A136_A594PropostaResponsavelDepositoTipo[0];
            n594PropostaResponsavelDepositoTipo = T001A136_n594PropostaResponsavelDepositoTipo[0];
            pr_default.close(68);
            /* Using cursor T001A137 */
            pr_default.execute(69, new Object[] {n642PropostaClinicaId, A642PropostaClinicaId});
            A643PropostaClinicaNome = T001A137_A643PropostaClinicaNome[0];
            n643PropostaClinicaNome = T001A137_n643PropostaClinicaNome[0];
            A644PropostaClinicaNomeFantasia = T001A137_A644PropostaClinicaNomeFantasia[0];
            n644PropostaClinicaNomeFantasia = T001A137_n644PropostaClinicaNomeFantasia[0];
            A652PropostaClinicaDocumento = T001A137_A652PropostaClinicaDocumento[0];
            n652PropostaClinicaDocumento = T001A137_n652PropostaClinicaDocumento[0];
            A653PropostaClinicaEmail = T001A137_A653PropostaClinicaEmail[0];
            n653PropostaClinicaEmail = T001A137_n653PropostaClinicaEmail[0];
            pr_default.close(69);
            /* Using cursor T001A139 */
            pr_default.execute(70, new Object[] {n323PropostaId, A323PropostaId, n642PropostaClinicaId, A642PropostaClinicaId});
            if ( (pr_default.getStatus(70) != 101) )
            {
               A650PropostaValorTaxaClinica_F = T001A139_A650PropostaValorTaxaClinica_F[0];
               n650PropostaValorTaxaClinica_F = T001A139_n650PropostaValorTaxaClinica_F[0];
            }
            else
            {
               A650PropostaValorTaxaClinica_F = 0;
               n650PropostaValorTaxaClinica_F = false;
               AssignAttri("", false, "A650PropostaValorTaxaClinica_F", StringUtil.LTrimStr( A650PropostaValorTaxaClinica_F, 18, 2));
            }
            pr_default.close(70);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001A140 */
            pr_default.execute(71, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(71) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Contrato"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(71);
            /* Using cursor T001A141 */
            pr_default.execute(72, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(72) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Reembolso"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(72);
            /* Using cursor T001A142 */
            pr_default.execute(73, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(73) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Titulo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(73);
            /* Using cursor T001A143 */
            pr_default.execute(74, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(74) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"NotaFiscalItem"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(74);
            /* Using cursor T001A144 */
            pr_default.execute(75, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(75) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"PropostaContratoAssinatura"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(75);
            /* Using cursor T001A145 */
            pr_default.execute(76, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(76) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"PropostaDocumentos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(76);
            /* Using cursor T001A146 */
            pr_default.execute(77, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(77) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Aprovacao"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(77);
         }
      }

      protected void EndLevel1A49( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1A49( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("proposta",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1A0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("proposta",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1A49( )
      {
         /* Scan By routine */
         /* Using cursor T001A147 */
         pr_default.execute(78);
         RcdFound49 = 0;
         if ( (pr_default.getStatus(78) != 101) )
         {
            RcdFound49 = 1;
            A323PropostaId = T001A147_A323PropostaId[0];
            n323PropostaId = T001A147_n323PropostaId[0];
            AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1A49( )
      {
         /* Scan next routine */
         pr_default.readNext(78);
         RcdFound49 = 0;
         if ( (pr_default.getStatus(78) != 101) )
         {
            RcdFound49 = 1;
            A323PropostaId = T001A147_A323PropostaId[0];
            n323PropostaId = T001A147_n323PropostaId[0];
            AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
         }
      }

      protected void ScanEnd1A49( )
      {
         pr_default.close(78);
      }

      protected void AfterConfirm1A49( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1A49( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1A49( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1A49( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1A49( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1A49( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1A49( )
      {
         edtPropostaTitulo_Enabled = 0;
         AssignProp("", false, edtPropostaTitulo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaTitulo_Enabled), 5, 0), true);
         edtPropostaDescricao_Enabled = 0;
         AssignProp("", false, edtPropostaDescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaDescricao_Enabled), 5, 0), true);
         edtPropostaValor_Enabled = 0;
         AssignProp("", false, edtPropostaValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaValor_Enabled), 5, 0), true);
         edtPropostaCreatedAt_Enabled = 0;
         AssignProp("", false, edtPropostaCreatedAt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaCreatedAt_Enabled), 5, 0), true);
         edtPropostaCratedBy_Enabled = 0;
         AssignProp("", false, edtPropostaCratedBy_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaCratedBy_Enabled), 5, 0), true);
         cmbPropostaStatus.Enabled = 0;
         AssignProp("", false, cmbPropostaStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPropostaStatus.Enabled), 5, 0), true);
         edtPropostaQuantidadeAprovadores_Enabled = 0;
         AssignProp("", false, edtPropostaQuantidadeAprovadores_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaQuantidadeAprovadores_Enabled), 5, 0), true);
         edtProcedimentosMedicosId_Enabled = 0;
         AssignProp("", false, edtProcedimentosMedicosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProcedimentosMedicosId_Enabled), 5, 0), true);
         edtPropostaReprovacoesPermitidas_Enabled = 0;
         AssignProp("", false, edtPropostaReprovacoesPermitidas_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaReprovacoesPermitidas_Enabled), 5, 0), true);
         edtPropostaAprovacoes_F_Enabled = 0;
         AssignProp("", false, edtPropostaAprovacoes_F_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaAprovacoes_F_Enabled), 5, 0), true);
         edtPropostaReprovacoes_F_Enabled = 0;
         AssignProp("", false, edtPropostaReprovacoes_F_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaReprovacoes_F_Enabled), 5, 0), true);
         edtPropostaAprovacoesRestantes_F_Enabled = 0;
         AssignProp("", false, edtPropostaAprovacoesRestantes_F_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaAprovacoesRestantes_F_Enabled), 5, 0), true);
         edtavCombopropostacratedby_Enabled = 0;
         AssignProp("", false, edtavCombopropostacratedby_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombopropostacratedby_Enabled), 5, 0), true);
         edtavComboprocedimentosmedicosid_Enabled = 0;
         AssignProp("", false, edtavComboprocedimentosmedicosid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboprocedimentosmedicosid_Enabled), 5, 0), true);
         edtPropostaId_Enabled = 0;
         AssignProp("", false, edtPropostaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1A49( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1A0( )
      {
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         MasterPageObj.master_styles();
         CloseStyles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 133260), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("calendar-pt.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal FormWithFixedActions\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "proposta"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7PropostaId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("proposta") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal FormWithFixedActions", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Proposta");
         forbiddenHiddens.Add("PropostaId", context.localUtil.Format( (decimal)(A323PropostaId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_PropostaEmpresaClienteId", context.localUtil.Format( (decimal)(AV35Insert_PropostaEmpresaClienteId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_PropostaPacienteClienteId", context.localUtil.Format( (decimal)(AV32Insert_PropostaPacienteClienteId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_PropostaResponsavelId", context.localUtil.Format( (decimal)(AV33Insert_PropostaResponsavelId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_ProcedimentosMedicosId", context.localUtil.Format( (decimal)(AV24Insert_ProcedimentosMedicosId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_PropostaCratedBy", context.localUtil.Format( (decimal)(AV11Insert_PropostaCratedBy), "ZZZ9"));
         forbiddenHiddens.Add("Insert_PropostaClinicaId", context.localUtil.Format( (decimal)(AV34Insert_PropostaClinicaId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_ContratoId", context.localUtil.Format( (decimal)(AV12Insert_ContratoId), "ZZZZZ9"));
         forbiddenHiddens.Add("Insert_ConvenioCategoriaId", context.localUtil.Format( (decimal)(AV31Insert_ConvenioCategoriaId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("PropostaProtocolo", StringUtil.RTrim( context.localUtil.Format( A853PropostaProtocolo, "")));
         forbiddenHiddens.Add("PropostaTipoProposta", StringUtil.RTrim( context.localUtil.Format( A849PropostaTipoProposta, "")));
         forbiddenHiddens.Add("PropostaDataCirurgia", context.localUtil.Format(A517PropostaDataCirurgia, "99/99/99"));
         forbiddenHiddens.Add("PropostaValorLiquido", context.localUtil.Format( A855PropostaValorLiquido, "ZZZ,ZZZ,ZZZ,ZZ9.99"));
         forbiddenHiddens.Add("PropostaTaxaAdministrativa", context.localUtil.Format( A501PropostaTaxaAdministrativa, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"));
         forbiddenHiddens.Add("PropostaSLA", context.localUtil.Format( (decimal)(A507PropostaSLA), "ZZZ9"));
         forbiddenHiddens.Add("PropostaJurosMora", context.localUtil.Format( A508PropostaJurosMora, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"));
         forbiddenHiddens.Add("PropostaComentarioAnalise", StringUtil.RTrim( context.localUtil.Format( A790PropostaComentarioAnalise, "")));
         forbiddenHiddens.Add("ConvenioVencimentoAno", context.localUtil.Format( (decimal)(A496ConvenioVencimentoAno), "ZZZ9"));
         forbiddenHiddens.Add("ConvenioVencimentoMes", context.localUtil.Format( (decimal)(A497ConvenioVencimentoMes), "ZZZ9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("proposta:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z323PropostaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z323PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z327PropostaCreatedAt", context.localUtil.TToC( Z327PropostaCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z853PropostaProtocolo", Z853PropostaProtocolo);
         GxWebStd.gx_hidden_field( context, "Z849PropostaTipoProposta", Z849PropostaTipoProposta);
         GxWebStd.gx_hidden_field( context, "Z324PropostaTitulo", Z324PropostaTitulo);
         GxWebStd.gx_hidden_field( context, "Z325PropostaDescricao", Z325PropostaDescricao);
         GxWebStd.gx_hidden_field( context, "Z517PropostaDataCirurgia", context.localUtil.DToC( Z517PropostaDataCirurgia, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z326PropostaValor", StringUtil.LTrim( StringUtil.NToC( Z326PropostaValor, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z855PropostaValorLiquido", StringUtil.LTrim( StringUtil.NToC( Z855PropostaValorLiquido, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z501PropostaTaxaAdministrativa", StringUtil.LTrim( StringUtil.NToC( Z501PropostaTaxaAdministrativa, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z507PropostaSLA", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z507PropostaSLA), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z508PropostaJurosMora", StringUtil.LTrim( StringUtil.NToC( Z508PropostaJurosMora, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z329PropostaStatus", Z329PropostaStatus);
         GxWebStd.gx_hidden_field( context, "Z790PropostaComentarioAnalise", Z790PropostaComentarioAnalise);
         GxWebStd.gx_hidden_field( context, "Z330PropostaQuantidadeAprovadores", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z330PropostaQuantidadeAprovadores), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z345PropostaReprovacoesPermitidas", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z345PropostaReprovacoesPermitidas), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z496ConvenioVencimentoAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z496ConvenioVencimentoAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z497ConvenioVencimentoMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z497ConvenioVencimentoMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z227ContratoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z227ContratoId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z376ProcedimentosMedicosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z376ProcedimentosMedicosId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z493ConvenioCategoriaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z493ConvenioCategoriaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z328PropostaCratedBy", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z328PropostaCratedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z504PropostaPacienteClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z504PropostaPacienteClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z553PropostaResponsavelId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z553PropostaResponsavelId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z642PropostaClinicaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z642PropostaClinicaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z850PropostaEmpresaClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z850PropostaEmpresaClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N850PropostaEmpresaClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A850PropostaEmpresaClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N504PropostaPacienteClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A504PropostaPacienteClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N553PropostaResponsavelId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A553PropostaResponsavelId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N376ProcedimentosMedicosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ProcedimentosMedicosId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N328PropostaCratedBy", StringUtil.LTrim( StringUtil.NToC( (decimal)(A328PropostaCratedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N642PropostaClinicaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A642PropostaClinicaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N227ContratoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N493ConvenioCategoriaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A493ConvenioCategoriaId), 9, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV15DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV15DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROPOSTACRATEDBY_DATA", AV14PropostaCratedBy_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROPOSTACRATEDBY_DATA", AV14PropostaCratedBy_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROCEDIMENTOSMEDICOSID_DATA", AV27ProcedimentosMedicosId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROCEDIMENTOSMEDICOSID_DATA", AV27ProcedimentosMedicosId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "PROPOSTASERASASCOREULTIMADATA_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A782PropostaSerasaScoreUltimaData_F), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTARESPONSAVELSERASASCOREULTIMADATA_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A783PropostaResponsavelSerasaScoreUltimaData_F), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTAMAIORSCORE_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A784PropostaMaiorScore_F), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTARESPONSAVELSERASAULTIMOVALORRECOMENDADO_F", StringUtil.LTrim( StringUtil.NToC( A786PropostaResponsavelSerasaUltimoValorRecomendado_F, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTAPACIENTESERASAULTIMOVALORRECOMENDADO_F", StringUtil.LTrim( StringUtil.NToC( A787PropostaPacienteSerasaUltimoValorRecomendado_F, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTAMAIORVALORRECOMENDADO", StringUtil.LTrim( StringUtil.NToC( A788PropostaMaiorValorRecomendado, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTATAXAADMINISTRATIVA", StringUtil.LTrim( StringUtil.NToC( A501PropostaTaxaAdministrativa, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTATAXA_F", StringUtil.LTrim( StringUtil.NToC( A575PropostaTaxa_F, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTADATACREDITOCLIENTE_F", context.localUtil.DToC( A515PropostaDataCreditoCliente_F, 0, "/"));
         GxWebStd.gx_hidden_field( context, "PROPOSTASLA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A507PropostaSLA), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTAJUROSMORA", StringUtil.LTrim( StringUtil.NToC( A508PropostaJurosMora, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTAVALORJUROSMORA_F", StringUtil.LTrim( StringUtil.NToC( A514PropostaValorJurosMora_F, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTAVALORTAXA_F", StringUtil.LTrim( StringUtil.NToC( A513PropostaValorTaxa_F, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PropostaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_PROPOSTAEMPRESACLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35Insert_PropostaEmpresaClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTAEMPRESACLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A850PropostaEmpresaClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_PROPOSTAPACIENTECLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32Insert_PropostaPacienteClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTAPACIENTECLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A504PropostaPacienteClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_PROPOSTARESPONSAVELID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33Insert_PropostaResponsavelId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTARESPONSAVELID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A553PropostaResponsavelId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_PROCEDIMENTOSMEDICOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24Insert_ProcedimentosMedicosId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_PROPOSTACRATEDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_PropostaCratedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_PROPOSTACLINICAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34Insert_PropostaClinicaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTACLINICAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A642PropostaClinicaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CONTRATOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_ContratoId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CONTRATOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CONVENIOCATEGORIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31Insert_ConvenioCategoriaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CONVENIOCATEGORIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A493ConvenioCategoriaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTAVALORTAXACLINICA_F", StringUtil.LTrim( StringUtil.NToC( A650PropostaValorTaxaClinica_F, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTAVALORLIQUIDO", StringUtil.LTrim( StringUtil.NToC( A855PropostaValorLiquido, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTAVALORREEMBOLSADO_F", StringUtil.LTrim( StringUtil.NToC( A509PropostaValorReembolsado_F, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTAVALORREEMBOLSADOJUROS_F", StringUtil.LTrim( StringUtil.NToC( A510PropostaValorReembolsadoJuros_F, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTAVALORTAXARECEBIDA_F", StringUtil.LTrim( StringUtil.NToC( A511PropostaValorTaxaRecebida_F, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTAPROTOCOLO", A853PropostaProtocolo);
         GxWebStd.gx_hidden_field( context, "PROPOSTATIPOPROPOSTA", A849PropostaTipoProposta);
         GxWebStd.gx_hidden_field( context, "PROPOSTADATACIRURGIA", context.localUtil.DToC( A517PropostaDataCirurgia, 0, "/"));
         GxWebStd.gx_hidden_field( context, "PROPOSTACOMENTARIOANALISE", A790PropostaComentarioAnalise);
         GxWebStd.gx_hidden_field( context, "CONVENIOVENCIMENTOANO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A496ConvenioVencimentoAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CONVENIOVENCIMENTOMES", StringUtil.LTrim( StringUtil.NToC( (decimal)(A497ConvenioVencimentoMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CONTRATONOME", A228ContratoNome);
         GxWebStd.gx_hidden_field( context, "CONVENIOCATEGORIADESCRICAO", A494ConvenioCategoriaDescricao);
         GxWebStd.gx_hidden_field( context, "CONVENIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A410ConvenioId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTASECUSERNAME", A512PropostaSecUserName);
         GxWebStd.gx_hidden_field( context, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL", A505PropostaPacienteClienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, "PROPOSTAPACIENTECLIENTEDOCUMENTO", A540PropostaPacienteClienteDocumento);
         GxWebStd.gx_hidden_field( context, "PROPOSTAPACIENTECONTATOEMAIL", A541PropostaPacienteContatoEmail);
         GxWebStd.gx_hidden_field( context, "PROPOSTAPACIENTECONTA", A584PropostaPacienteConta);
         GxWebStd.gx_hidden_field( context, "PROPOSTAPACIENTEAGENCIA", A585PropostaPacienteAgencia);
         GxWebStd.gx_hidden_field( context, "PROPOSTAPACIENTETIPOPIX", A586PropostaPacienteTipoPix);
         GxWebStd.gx_hidden_field( context, "PROPOSTAPACIENTEPIX", A587PropostaPacientePIX);
         GxWebStd.gx_hidden_field( context, "PROPOSTAPACIENTEDEPOSITOTIPO", A588PropostaPacienteDepositoTipo);
         GxWebStd.gx_hidden_field( context, "PROPOSTAPACIENTEENDERECOCEP", A620PropostaPacienteEnderecoCEP);
         GxWebStd.gx_hidden_field( context, "PROPOSTAPACIENTEENDERECOLOGRADOURO", A621PropostaPacienteEnderecoLogradouro);
         GxWebStd.gx_hidden_field( context, "PROPOSTAPACIENTEENDERECONUMERO", A622PropostaPacienteEnderecoNumero);
         GxWebStd.gx_hidden_field( context, "PROPOSTAPACIENTEENDERECOCOMPLEMENTO", A623PropostaPacienteEnderecoComplemento);
         GxWebStd.gx_hidden_field( context, "PROPOSTAPACIENTEENDERECOBAIRRO", A624PropostaPacienteEnderecoBairro);
         GxWebStd.gx_hidden_field( context, "PROPOSTAPACIENTEMUNICIPIOCODIGO", A625PropostaPacienteMunicipioCodigo);
         GxWebStd.gx_hidden_field( context, "PROPOSTARESPONSAVELDOCUMENTO", A580PropostaResponsavelDocumento);
         GxWebStd.gx_hidden_field( context, "PROPOSTARESPONSAVELRAZAOSOCIAL", A581PropostaResponsavelRazaoSocial);
         GxWebStd.gx_hidden_field( context, "PROPOSTARESPONSAVELEMAIL", A582PropostaResponsavelEmail);
         GxWebStd.gx_hidden_field( context, "PROPOSTARESPONSAVELCONTA", A590PropostaResponsavelConta);
         GxWebStd.gx_hidden_field( context, "PROPOSTARESPONSAVELAGENCIA", A591PropostaResponsavelAgencia);
         GxWebStd.gx_hidden_field( context, "PROPOSTARESPONSAVELTIPOPIX", A592PropostaResponsavelTipoPix);
         GxWebStd.gx_hidden_field( context, "PROPOSTARESPONSAVELPIX", A593PropostaResponsavelPIX);
         GxWebStd.gx_hidden_field( context, "PROPOSTARESPONSAVELDEPOSITOTIPO", A594PropostaResponsavelDepositoTipo);
         GxWebStd.gx_hidden_field( context, "PROPOSTACLINICANOME", A643PropostaClinicaNome);
         GxWebStd.gx_hidden_field( context, "PROPOSTACLINICANOMEFANTASIA", A644PropostaClinicaNomeFantasia);
         GxWebStd.gx_hidden_field( context, "PROPOSTACLINICADOCUMENTO", A652PropostaClinicaDocumento);
         GxWebStd.gx_hidden_field( context, "PROPOSTACLINICAEMAIL", A653PropostaClinicaEmail);
         GxWebStd.gx_hidden_field( context, "PROPOSTAMAXREEMBOLSOID_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A649PropostaMaxReembolsoId_F), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTAQTDITENSNOTA_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A854PropostaQtdItensNota_F), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTARESPONSAVELSERASACONSULTAS_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A733PropostaResponsavelSerasaConsultas_F), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTAPACIENTESERASACONSULTAS_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A734PropostaPacienteSerasaConsultas_F), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTAQTDDOCUMENTOPENDENTE_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A655PropostaQtdDocumentoPendente_F), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV36Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTACRATEDBY_Objectcall", StringUtil.RTrim( Combo_propostacratedby_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTACRATEDBY_Cls", StringUtil.RTrim( Combo_propostacratedby_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTACRATEDBY_Selectedvalue_set", StringUtil.RTrim( Combo_propostacratedby_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTACRATEDBY_Selectedtext_set", StringUtil.RTrim( Combo_propostacratedby_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTACRATEDBY_Enabled", StringUtil.BoolToStr( Combo_propostacratedby_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTACRATEDBY_Datalistproc", StringUtil.RTrim( Combo_propostacratedby_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTACRATEDBY_Datalistprocparametersprefix", StringUtil.RTrim( Combo_propostacratedby_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_PROCEDIMENTOSMEDICOSID_Objectcall", StringUtil.RTrim( Combo_procedimentosmedicosid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_PROCEDIMENTOSMEDICOSID_Cls", StringUtil.RTrim( Combo_procedimentosmedicosid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PROCEDIMENTOSMEDICOSID_Selectedvalue_set", StringUtil.RTrim( Combo_procedimentosmedicosid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PROCEDIMENTOSMEDICOSID_Selectedtext_set", StringUtil.RTrim( Combo_procedimentosmedicosid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PROCEDIMENTOSMEDICOSID_Enabled", StringUtil.BoolToStr( Combo_procedimentosmedicosid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_PROCEDIMENTOSMEDICOSID_Datalistproc", StringUtil.RTrim( Combo_procedimentosmedicosid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_PROCEDIMENTOSMEDICOSID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_procedimentosmedicosid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Objectcall", StringUtil.RTrim( Dvpanel_tableattributes_Objectcall));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Enabled", StringUtil.BoolToStr( Dvpanel_tableattributes_Enabled));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Width", StringUtil.RTrim( Dvpanel_tableattributes_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autowidth", StringUtil.BoolToStr( Dvpanel_tableattributes_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoheight", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Cls", StringUtil.RTrim( Dvpanel_tableattributes_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Title", StringUtil.RTrim( Dvpanel_tableattributes_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsible", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsed", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableattributes_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Iconposition", StringUtil.RTrim( Dvpanel_tableattributes_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoscroll));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal FormWithFixedActions" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "proposta"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7PropostaId,9,0));
         return formatLink("proposta") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Proposta" ;
      }

      public override string GetPgmdesc( )
      {
         return "Proposta" ;
      }

      protected void InitializeNonKey1A49( )
      {
         A850PropostaEmpresaClienteId = 0;
         n850PropostaEmpresaClienteId = false;
         AssignAttri("", false, "A850PropostaEmpresaClienteId", ((0==A850PropostaEmpresaClienteId)&&IsIns( )||n850PropostaEmpresaClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A850PropostaEmpresaClienteId), 9, 0, ".", ""))));
         A504PropostaPacienteClienteId = 0;
         n504PropostaPacienteClienteId = false;
         AssignAttri("", false, "A504PropostaPacienteClienteId", ((0==A504PropostaPacienteClienteId)&&IsIns( )||n504PropostaPacienteClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A504PropostaPacienteClienteId), 9, 0, ".", ""))));
         A553PropostaResponsavelId = 0;
         n553PropostaResponsavelId = false;
         AssignAttri("", false, "A553PropostaResponsavelId", ((0==A553PropostaResponsavelId)&&IsIns( )||n553PropostaResponsavelId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A553PropostaResponsavelId), 9, 0, ".", ""))));
         A376ProcedimentosMedicosId = 0;
         n376ProcedimentosMedicosId = false;
         AssignAttri("", false, "A376ProcedimentosMedicosId", ((0==A376ProcedimentosMedicosId)&&IsIns( )||n376ProcedimentosMedicosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ProcedimentosMedicosId), 9, 0, ".", ""))));
         n376ProcedimentosMedicosId = ((0==A376ProcedimentosMedicosId) ? true : false);
         A328PropostaCratedBy = 0;
         n328PropostaCratedBy = false;
         AssignAttri("", false, "A328PropostaCratedBy", ((0==A328PropostaCratedBy)&&IsIns( )||n328PropostaCratedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A328PropostaCratedBy), 4, 0, ".", ""))));
         n328PropostaCratedBy = ((0==A328PropostaCratedBy) ? true : false);
         A642PropostaClinicaId = 0;
         n642PropostaClinicaId = false;
         AssignAttri("", false, "A642PropostaClinicaId", ((0==A642PropostaClinicaId)&&IsIns( )||n642PropostaClinicaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A642PropostaClinicaId), 9, 0, ".", ""))));
         A227ContratoId = 0;
         n227ContratoId = false;
         AssignAttri("", false, "A227ContratoId", ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
         A493ConvenioCategoriaId = 0;
         n493ConvenioCategoriaId = false;
         AssignAttri("", false, "A493ConvenioCategoriaId", ((0==A493ConvenioCategoriaId)&&IsIns( )||n493ConvenioCategoriaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A493ConvenioCategoriaId), 9, 0, ".", ""))));
         A327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         n327PropostaCreatedAt = false;
         AssignAttri("", false, "A327PropostaCreatedAt", context.localUtil.TToC( A327PropostaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         n327PropostaCreatedAt = ((DateTime.MinValue==A327PropostaCreatedAt) ? true : false);
         A343PropostaAprovacoesRestantes_F = 0;
         AssignAttri("", false, "A343PropostaAprovacoesRestantes_F", StringUtil.LTrimStr( (decimal)(A343PropostaAprovacoesRestantes_F), 4, 0));
         A513PropostaValorTaxa_F = 0;
         AssignAttri("", false, "A513PropostaValorTaxa_F", StringUtil.LTrimStr( A513PropostaValorTaxa_F, 18, 2));
         A514PropostaValorJurosMora_F = 0;
         AssignAttri("", false, "A514PropostaValorJurosMora_F", StringUtil.LTrimStr( A514PropostaValorJurosMora_F, 18, 2));
         A575PropostaTaxa_F = 0;
         AssignAttri("", false, "A575PropostaTaxa_F", StringUtil.LTrimStr( A575PropostaTaxa_F, 18, 2));
         A788PropostaMaiorValorRecomendado = 0;
         AssignAttri("", false, "A788PropostaMaiorValorRecomendado", StringUtil.LTrimStr( A788PropostaMaiorValorRecomendado, 18, 2));
         A784PropostaMaiorScore_F = 0;
         AssignAttri("", false, "A784PropostaMaiorScore_F", StringUtil.LTrimStr( (decimal)(A784PropostaMaiorScore_F), 4, 0));
         A509PropostaValorReembolsado_F = 0;
         n509PropostaValorReembolsado_F = false;
         AssignAttri("", false, "A509PropostaValorReembolsado_F", StringUtil.LTrimStr( A509PropostaValorReembolsado_F, 18, 2));
         A510PropostaValorReembolsadoJuros_F = 0;
         n510PropostaValorReembolsadoJuros_F = false;
         AssignAttri("", false, "A510PropostaValorReembolsadoJuros_F", StringUtil.LTrimStr( A510PropostaValorReembolsadoJuros_F, 18, 2));
         A511PropostaValorTaxaRecebida_F = 0;
         n511PropostaValorTaxaRecebida_F = false;
         AssignAttri("", false, "A511PropostaValorTaxaRecebida_F", StringUtil.LTrimStr( A511PropostaValorTaxaRecebida_F, 18, 2));
         A515PropostaDataCreditoCliente_F = DateTime.MinValue;
         n515PropostaDataCreditoCliente_F = false;
         AssignAttri("", false, "A515PropostaDataCreditoCliente_F", context.localUtil.Format(A515PropostaDataCreditoCliente_F, "99/99/9999"));
         A650PropostaValorTaxaClinica_F = 0;
         n650PropostaValorTaxaClinica_F = false;
         AssignAttri("", false, "A650PropostaValorTaxaClinica_F", StringUtil.LTrimStr( A650PropostaValorTaxaClinica_F, 18, 2));
         A649PropostaMaxReembolsoId_F = 0;
         n649PropostaMaxReembolsoId_F = false;
         AssignAttri("", false, "A649PropostaMaxReembolsoId_F", StringUtil.LTrimStr( (decimal)(A649PropostaMaxReembolsoId_F), 9, 0));
         A853PropostaProtocolo = "";
         n853PropostaProtocolo = false;
         AssignAttri("", false, "A853PropostaProtocolo", A853PropostaProtocolo);
         A849PropostaTipoProposta = "";
         n849PropostaTipoProposta = false;
         AssignAttri("", false, "A849PropostaTipoProposta", A849PropostaTipoProposta);
         A854PropostaQtdItensNota_F = 0;
         n854PropostaQtdItensNota_F = false;
         AssignAttri("", false, "A854PropostaQtdItensNota_F", StringUtil.LTrimStr( (decimal)(A854PropostaQtdItensNota_F), 4, 0));
         A580PropostaResponsavelDocumento = "";
         n580PropostaResponsavelDocumento = false;
         AssignAttri("", false, "A580PropostaResponsavelDocumento", A580PropostaResponsavelDocumento);
         A581PropostaResponsavelRazaoSocial = "";
         n581PropostaResponsavelRazaoSocial = false;
         AssignAttri("", false, "A581PropostaResponsavelRazaoSocial", A581PropostaResponsavelRazaoSocial);
         A582PropostaResponsavelEmail = "";
         n582PropostaResponsavelEmail = false;
         AssignAttri("", false, "A582PropostaResponsavelEmail", A582PropostaResponsavelEmail);
         A589PropostaResponsavelBanco = "";
         AssignAttri("", false, "A589PropostaResponsavelBanco", A589PropostaResponsavelBanco);
         A590PropostaResponsavelConta = "";
         n590PropostaResponsavelConta = false;
         AssignAttri("", false, "A590PropostaResponsavelConta", A590PropostaResponsavelConta);
         A591PropostaResponsavelAgencia = "";
         n591PropostaResponsavelAgencia = false;
         AssignAttri("", false, "A591PropostaResponsavelAgencia", A591PropostaResponsavelAgencia);
         A592PropostaResponsavelTipoPix = "";
         n592PropostaResponsavelTipoPix = false;
         AssignAttri("", false, "A592PropostaResponsavelTipoPix", A592PropostaResponsavelTipoPix);
         A593PropostaResponsavelPIX = "";
         n593PropostaResponsavelPIX = false;
         AssignAttri("", false, "A593PropostaResponsavelPIX", A593PropostaResponsavelPIX);
         A594PropostaResponsavelDepositoTipo = "";
         n594PropostaResponsavelDepositoTipo = false;
         AssignAttri("", false, "A594PropostaResponsavelDepositoTipo", A594PropostaResponsavelDepositoTipo);
         A733PropostaResponsavelSerasaConsultas_F = 0;
         n733PropostaResponsavelSerasaConsultas_F = false;
         AssignAttri("", false, "A733PropostaResponsavelSerasaConsultas_F", StringUtil.LTrimStr( (decimal)(A733PropostaResponsavelSerasaConsultas_F), 4, 0));
         A783PropostaResponsavelSerasaScoreUltimaData_F = 0;
         n783PropostaResponsavelSerasaScoreUltimaData_F = false;
         AssignAttri("", false, "A783PropostaResponsavelSerasaScoreUltimaData_F", StringUtil.LTrimStr( (decimal)(A783PropostaResponsavelSerasaScoreUltimaData_F), 4, 0));
         A786PropostaResponsavelSerasaUltimoValorRecomendado_F = 0;
         n786PropostaResponsavelSerasaUltimoValorRecomendado_F = false;
         AssignAttri("", false, "A786PropostaResponsavelSerasaUltimoValorRecomendado_F", StringUtil.LTrimStr( A786PropostaResponsavelSerasaUltimoValorRecomendado_F, 18, 2));
         A505PropostaPacienteClienteRazaoSocial = "";
         n505PropostaPacienteClienteRazaoSocial = false;
         AssignAttri("", false, "A505PropostaPacienteClienteRazaoSocial", A505PropostaPacienteClienteRazaoSocial);
         A540PropostaPacienteClienteDocumento = "";
         n540PropostaPacienteClienteDocumento = false;
         AssignAttri("", false, "A540PropostaPacienteClienteDocumento", A540PropostaPacienteClienteDocumento);
         A541PropostaPacienteContatoEmail = "";
         n541PropostaPacienteContatoEmail = false;
         AssignAttri("", false, "A541PropostaPacienteContatoEmail", A541PropostaPacienteContatoEmail);
         A583PropostaPacienteBanco = "";
         AssignAttri("", false, "A583PropostaPacienteBanco", A583PropostaPacienteBanco);
         A584PropostaPacienteConta = "";
         n584PropostaPacienteConta = false;
         AssignAttri("", false, "A584PropostaPacienteConta", A584PropostaPacienteConta);
         A585PropostaPacienteAgencia = "";
         n585PropostaPacienteAgencia = false;
         AssignAttri("", false, "A585PropostaPacienteAgencia", A585PropostaPacienteAgencia);
         A586PropostaPacienteTipoPix = "";
         n586PropostaPacienteTipoPix = false;
         AssignAttri("", false, "A586PropostaPacienteTipoPix", A586PropostaPacienteTipoPix);
         A587PropostaPacientePIX = "";
         n587PropostaPacientePIX = false;
         AssignAttri("", false, "A587PropostaPacientePIX", A587PropostaPacientePIX);
         A588PropostaPacienteDepositoTipo = "";
         n588PropostaPacienteDepositoTipo = false;
         AssignAttri("", false, "A588PropostaPacienteDepositoTipo", A588PropostaPacienteDepositoTipo);
         A620PropostaPacienteEnderecoCEP = "";
         n620PropostaPacienteEnderecoCEP = false;
         AssignAttri("", false, "A620PropostaPacienteEnderecoCEP", A620PropostaPacienteEnderecoCEP);
         A621PropostaPacienteEnderecoLogradouro = "";
         n621PropostaPacienteEnderecoLogradouro = false;
         AssignAttri("", false, "A621PropostaPacienteEnderecoLogradouro", A621PropostaPacienteEnderecoLogradouro);
         A622PropostaPacienteEnderecoNumero = "";
         n622PropostaPacienteEnderecoNumero = false;
         AssignAttri("", false, "A622PropostaPacienteEnderecoNumero", A622PropostaPacienteEnderecoNumero);
         A623PropostaPacienteEnderecoComplemento = "";
         n623PropostaPacienteEnderecoComplemento = false;
         AssignAttri("", false, "A623PropostaPacienteEnderecoComplemento", A623PropostaPacienteEnderecoComplemento);
         A624PropostaPacienteEnderecoBairro = "";
         n624PropostaPacienteEnderecoBairro = false;
         AssignAttri("", false, "A624PropostaPacienteEnderecoBairro", A624PropostaPacienteEnderecoBairro);
         A625PropostaPacienteMunicipioCodigo = "";
         n625PropostaPacienteMunicipioCodigo = false;
         AssignAttri("", false, "A625PropostaPacienteMunicipioCodigo", A625PropostaPacienteMunicipioCodigo);
         A734PropostaPacienteSerasaConsultas_F = 0;
         n734PropostaPacienteSerasaConsultas_F = false;
         AssignAttri("", false, "A734PropostaPacienteSerasaConsultas_F", StringUtil.LTrimStr( (decimal)(A734PropostaPacienteSerasaConsultas_F), 4, 0));
         A782PropostaSerasaScoreUltimaData_F = 0;
         n782PropostaSerasaScoreUltimaData_F = false;
         AssignAttri("", false, "A782PropostaSerasaScoreUltimaData_F", StringUtil.LTrimStr( (decimal)(A782PropostaSerasaScoreUltimaData_F), 4, 0));
         A787PropostaPacienteSerasaUltimoValorRecomendado_F = 0;
         n787PropostaPacienteSerasaUltimoValorRecomendado_F = false;
         AssignAttri("", false, "A787PropostaPacienteSerasaUltimoValorRecomendado_F", StringUtil.LTrimStr( A787PropostaPacienteSerasaUltimoValorRecomendado_F, 18, 2));
         A655PropostaQtdDocumentoPendente_F = 0;
         n655PropostaQtdDocumentoPendente_F = false;
         AssignAttri("", false, "A655PropostaQtdDocumentoPendente_F", StringUtil.LTrimStr( (decimal)(A655PropostaQtdDocumentoPendente_F), 4, 0));
         A324PropostaTitulo = "";
         n324PropostaTitulo = false;
         AssignAttri("", false, "A324PropostaTitulo", A324PropostaTitulo);
         n324PropostaTitulo = (String.IsNullOrEmpty(StringUtil.RTrim( A324PropostaTitulo)) ? true : false);
         A325PropostaDescricao = "";
         n325PropostaDescricao = false;
         AssignAttri("", false, "A325PropostaDescricao", A325PropostaDescricao);
         n325PropostaDescricao = (String.IsNullOrEmpty(StringUtil.RTrim( A325PropostaDescricao)) ? true : false);
         A517PropostaDataCirurgia = DateTime.MinValue;
         n517PropostaDataCirurgia = false;
         AssignAttri("", false, "A517PropostaDataCirurgia", context.localUtil.Format(A517PropostaDataCirurgia, "99/99/99"));
         A326PropostaValor = 0;
         n326PropostaValor = false;
         AssignAttri("", false, "A326PropostaValor", ((Convert.ToDecimal(0)==A326PropostaValor)&&IsIns( )||n326PropostaValor ? "" : StringUtil.LTrim( StringUtil.NToC( A326PropostaValor, 18, 2, ".", ""))));
         n326PropostaValor = ((Convert.ToDecimal(0)==A326PropostaValor) ? true : false);
         A855PropostaValorLiquido = 0;
         n855PropostaValorLiquido = false;
         AssignAttri("", false, "A855PropostaValorLiquido", ((Convert.ToDecimal(0)==A855PropostaValorLiquido)&&IsIns( )||n855PropostaValorLiquido ? "" : StringUtil.LTrim( StringUtil.NToC( A855PropostaValorLiquido, 18, 2, ".", ""))));
         A501PropostaTaxaAdministrativa = 0;
         n501PropostaTaxaAdministrativa = false;
         AssignAttri("", false, "A501PropostaTaxaAdministrativa", ((Convert.ToDecimal(0)==A501PropostaTaxaAdministrativa)&&IsIns( )||n501PropostaTaxaAdministrativa ? "" : StringUtil.LTrim( StringUtil.NToC( A501PropostaTaxaAdministrativa, 16, 4, ".", ""))));
         A507PropostaSLA = 0;
         n507PropostaSLA = false;
         AssignAttri("", false, "A507PropostaSLA", ((0==A507PropostaSLA)&&IsIns( )||n507PropostaSLA ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A507PropostaSLA), 4, 0, ".", ""))));
         A508PropostaJurosMora = 0;
         n508PropostaJurosMora = false;
         AssignAttri("", false, "A508PropostaJurosMora", ((Convert.ToDecimal(0)==A508PropostaJurosMora)&&IsIns( )||n508PropostaJurosMora ? "" : StringUtil.LTrim( StringUtil.NToC( A508PropostaJurosMora, 16, 4, ".", ""))));
         A643PropostaClinicaNome = "";
         n643PropostaClinicaNome = false;
         AssignAttri("", false, "A643PropostaClinicaNome", A643PropostaClinicaNome);
         A644PropostaClinicaNomeFantasia = "";
         n644PropostaClinicaNomeFantasia = false;
         AssignAttri("", false, "A644PropostaClinicaNomeFantasia", A644PropostaClinicaNomeFantasia);
         A652PropostaClinicaDocumento = "";
         n652PropostaClinicaDocumento = false;
         AssignAttri("", false, "A652PropostaClinicaDocumento", A652PropostaClinicaDocumento);
         A653PropostaClinicaEmail = "";
         n653PropostaClinicaEmail = false;
         AssignAttri("", false, "A653PropostaClinicaEmail", A653PropostaClinicaEmail);
         A512PropostaSecUserName = "";
         n512PropostaSecUserName = false;
         AssignAttri("", false, "A512PropostaSecUserName", A512PropostaSecUserName);
         A329PropostaStatus = "";
         n329PropostaStatus = false;
         AssignAttri("", false, "A329PropostaStatus", A329PropostaStatus);
         n329PropostaStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A329PropostaStatus)) ? true : false);
         A790PropostaComentarioAnalise = "";
         n790PropostaComentarioAnalise = false;
         AssignAttri("", false, "A790PropostaComentarioAnalise", A790PropostaComentarioAnalise);
         A330PropostaQuantidadeAprovadores = 0;
         n330PropostaQuantidadeAprovadores = false;
         AssignAttri("", false, "A330PropostaQuantidadeAprovadores", ((0==A330PropostaQuantidadeAprovadores)&&IsIns( )||n330PropostaQuantidadeAprovadores ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A330PropostaQuantidadeAprovadores), 4, 0, ".", ""))));
         n330PropostaQuantidadeAprovadores = ((0==A330PropostaQuantidadeAprovadores) ? true : false);
         A345PropostaReprovacoesPermitidas = 0;
         n345PropostaReprovacoesPermitidas = false;
         AssignAttri("", false, "A345PropostaReprovacoesPermitidas", ((0==A345PropostaReprovacoesPermitidas)&&IsIns( )||n345PropostaReprovacoesPermitidas ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A345PropostaReprovacoesPermitidas), 4, 0, ".", ""))));
         n345PropostaReprovacoesPermitidas = ((0==A345PropostaReprovacoesPermitidas) ? true : false);
         A228ContratoNome = "";
         n228ContratoNome = false;
         AssignAttri("", false, "A228ContratoNome", A228ContratoNome);
         A410ConvenioId = 0;
         n410ConvenioId = false;
         AssignAttri("", false, "A410ConvenioId", StringUtil.LTrimStr( (decimal)(A410ConvenioId), 9, 0));
         A496ConvenioVencimentoAno = 0;
         n496ConvenioVencimentoAno = false;
         AssignAttri("", false, "A496ConvenioVencimentoAno", ((0==A496ConvenioVencimentoAno)&&IsIns( )||n496ConvenioVencimentoAno ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A496ConvenioVencimentoAno), 4, 0, ".", ""))));
         A497ConvenioVencimentoMes = 0;
         n497ConvenioVencimentoMes = false;
         AssignAttri("", false, "A497ConvenioVencimentoMes", ((0==A497ConvenioVencimentoMes)&&IsIns( )||n497ConvenioVencimentoMes ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A497ConvenioVencimentoMes), 4, 0, ".", ""))));
         A494ConvenioCategoriaDescricao = "";
         n494ConvenioCategoriaDescricao = false;
         AssignAttri("", false, "A494ConvenioCategoriaDescricao", A494ConvenioCategoriaDescricao);
         A341PropostaAprovacoes_F = 0;
         n341PropostaAprovacoes_F = false;
         AssignAttri("", false, "A341PropostaAprovacoes_F", StringUtil.LTrimStr( (decimal)(A341PropostaAprovacoes_F), 4, 0));
         A342PropostaReprovacoes_F = 0;
         n342PropostaReprovacoes_F = false;
         AssignAttri("", false, "A342PropostaReprovacoes_F", StringUtil.LTrimStr( (decimal)(A342PropostaReprovacoes_F), 4, 0));
         Z327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         Z853PropostaProtocolo = "";
         Z849PropostaTipoProposta = "";
         Z324PropostaTitulo = "";
         Z325PropostaDescricao = "";
         Z517PropostaDataCirurgia = DateTime.MinValue;
         Z326PropostaValor = 0;
         Z855PropostaValorLiquido = 0;
         Z501PropostaTaxaAdministrativa = 0;
         Z507PropostaSLA = 0;
         Z508PropostaJurosMora = 0;
         Z329PropostaStatus = "";
         Z790PropostaComentarioAnalise = "";
         Z330PropostaQuantidadeAprovadores = 0;
         Z345PropostaReprovacoesPermitidas = 0;
         Z496ConvenioVencimentoAno = 0;
         Z497ConvenioVencimentoMes = 0;
         Z227ContratoId = 0;
         Z376ProcedimentosMedicosId = 0;
         Z493ConvenioCategoriaId = 0;
         Z328PropostaCratedBy = 0;
         Z504PropostaPacienteClienteId = 0;
         Z553PropostaResponsavelId = 0;
         Z642PropostaClinicaId = 0;
         Z850PropostaEmpresaClienteId = 0;
      }

      protected void InitAll1A49( )
      {
         A323PropostaId = 0;
         n323PropostaId = false;
         AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
         InitializeNonKey1A49( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A327PropostaCreatedAt = i327PropostaCreatedAt;
         n327PropostaCreatedAt = false;
         AssignAttri("", false, "A327PropostaCreatedAt", context.localUtil.TToC( A327PropostaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101917772", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.por.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("proposta.js", "?20256101917774", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtPropostaTitulo_Internalname = "PROPOSTATITULO";
         edtPropostaDescricao_Internalname = "PROPOSTADESCRICAO";
         edtPropostaValor_Internalname = "PROPOSTAVALOR";
         edtPropostaCreatedAt_Internalname = "PROPOSTACREATEDAT";
         lblTextblockpropostacratedby_Internalname = "TEXTBLOCKPROPOSTACRATEDBY";
         Combo_propostacratedby_Internalname = "COMBO_PROPOSTACRATEDBY";
         edtPropostaCratedBy_Internalname = "PROPOSTACRATEDBY";
         divTablesplittedpropostacratedby_Internalname = "TABLESPLITTEDPROPOSTACRATEDBY";
         cmbPropostaStatus_Internalname = "PROPOSTASTATUS";
         edtPropostaQuantidadeAprovadores_Internalname = "PROPOSTAQUANTIDADEAPROVADORES";
         lblTextblockprocedimentosmedicosid_Internalname = "TEXTBLOCKPROCEDIMENTOSMEDICOSID";
         Combo_procedimentosmedicosid_Internalname = "COMBO_PROCEDIMENTOSMEDICOSID";
         edtProcedimentosMedicosId_Internalname = "PROCEDIMENTOSMEDICOSID";
         divTablesplittedprocedimentosmedicosid_Internalname = "TABLESPLITTEDPROCEDIMENTOSMEDICOSID";
         edtPropostaReprovacoesPermitidas_Internalname = "PROPOSTAREPROVACOESPERMITIDAS";
         edtPropostaAprovacoes_F_Internalname = "PROPOSTAAPROVACOES_F";
         edtPropostaReprovacoes_F_Internalname = "PROPOSTAREPROVACOES_F";
         edtPropostaAprovacoesRestantes_F_Internalname = "PROPOSTAAPROVACOESRESTANTES_F";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombopropostacratedby_Internalname = "vCOMBOPROPOSTACRATEDBY";
         divSectionattribute_propostacratedby_Internalname = "SECTIONATTRIBUTE_PROPOSTACRATEDBY";
         edtavComboprocedimentosmedicosid_Internalname = "vCOMBOPROCEDIMENTOSMEDICOSID";
         divSectionattribute_procedimentosmedicosid_Internalname = "SECTIONATTRIBUTE_PROCEDIMENTOSMEDICOSID";
         edtPropostaId_Internalname = "PROPOSTAID";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Proposta";
         edtPropostaId_Jsonclick = "";
         edtPropostaId_Enabled = 0;
         edtPropostaId_Visible = 1;
         edtavComboprocedimentosmedicosid_Jsonclick = "";
         edtavComboprocedimentosmedicosid_Enabled = 0;
         edtavComboprocedimentosmedicosid_Visible = 1;
         edtavCombopropostacratedby_Jsonclick = "";
         edtavCombopropostacratedby_Enabled = 0;
         edtavCombopropostacratedby_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtPropostaAprovacoesRestantes_F_Jsonclick = "";
         edtPropostaAprovacoesRestantes_F_Enabled = 0;
         edtPropostaReprovacoes_F_Jsonclick = "";
         edtPropostaReprovacoes_F_Enabled = 0;
         edtPropostaAprovacoes_F_Jsonclick = "";
         edtPropostaAprovacoes_F_Enabled = 0;
         edtPropostaReprovacoesPermitidas_Jsonclick = "";
         edtPropostaReprovacoesPermitidas_Enabled = 1;
         edtProcedimentosMedicosId_Jsonclick = "";
         edtProcedimentosMedicosId_Enabled = 1;
         edtProcedimentosMedicosId_Visible = 1;
         Combo_procedimentosmedicosid_Datalistprocparametersprefix = " \"ComboName\": \"ProcedimentosMedicosId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"PropostaId\": 0";
         Combo_procedimentosmedicosid_Datalistproc = "PropostaLoadDVCombo";
         Combo_procedimentosmedicosid_Cls = "ExtendedCombo AttributeFL";
         Combo_procedimentosmedicosid_Caption = "";
         Combo_procedimentosmedicosid_Enabled = Convert.ToBoolean( -1);
         edtPropostaQuantidadeAprovadores_Jsonclick = "";
         edtPropostaQuantidadeAprovadores_Enabled = 1;
         cmbPropostaStatus_Jsonclick = "";
         cmbPropostaStatus.Enabled = 1;
         edtPropostaCratedBy_Jsonclick = "";
         edtPropostaCratedBy_Enabled = 1;
         edtPropostaCratedBy_Visible = 1;
         Combo_propostacratedby_Datalistprocparametersprefix = " \"ComboName\": \"PropostaCratedBy\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"PropostaId\": 0";
         Combo_propostacratedby_Datalistproc = "PropostaLoadDVCombo";
         Combo_propostacratedby_Cls = "ExtendedCombo AttributeFL";
         Combo_propostacratedby_Caption = "";
         Combo_propostacratedby_Enabled = Convert.ToBoolean( -1);
         edtPropostaCreatedAt_Jsonclick = "";
         edtPropostaCreatedAt_Enabled = 1;
         edtPropostaValor_Jsonclick = "";
         edtPropostaValor_Enabled = 1;
         edtPropostaDescricao_Jsonclick = "";
         edtPropostaDescricao_Enabled = 1;
         edtPropostaTitulo_Jsonclick = "";
         edtPropostaTitulo_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Informações Gerais";
         Dvpanel_tableattributes_Cls = "PanelCard_GrayTitle";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GX7ASAPROPOSTAVALORJUROSMORA_F1A49( DateTime A515PropostaDataCreditoCliente_F ,
                                                         short A507PropostaSLA ,
                                                         decimal A508PropostaJurosMora ,
                                                         decimal A326PropostaValor )
      {
         GXt_decimal3 = A514PropostaValorJurosMora_F;
         new prcalcularjurosmora(context ).execute(  A515PropostaDataCreditoCliente_F,  A507PropostaSLA,  A508PropostaJurosMora,  A326PropostaValor, out  GXt_decimal3) ;
         A514PropostaValorJurosMora_F = GXt_decimal3;
         AssignAttri("", false, "A514PropostaValorJurosMora_F", StringUtil.LTrimStr( A514PropostaValorJurosMora_F, 18, 2));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A514PropostaValorJurosMora_F, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void init_web_controls( )
      {
         cmbPropostaStatus.Name = "PROPOSTASTATUS";
         cmbPropostaStatus.WebTags = "";
         cmbPropostaStatus.addItem("PENDENTE", "Pendente aprovação", 0);
         cmbPropostaStatus.addItem("EM_ANALISE", "Em análise", 0);
         cmbPropostaStatus.addItem("APROVADO", "Aprovado", 0);
         cmbPropostaStatus.addItem("REJEITADO", "Rejeitado", 0);
         cmbPropostaStatus.addItem("REVISAO", "Revisão", 0);
         cmbPropostaStatus.addItem("CANCELADO", "Cancelado", 0);
         cmbPropostaStatus.addItem("AGUARDANDO_ASSINATURA", "Aguardando assinatura", 0);
         cmbPropostaStatus.addItem("AnaliseReprovada", "Análise reprovada", 0);
         if ( cmbPropostaStatus.ItemCount > 0 )
         {
            A329PropostaStatus = cmbPropostaStatus.getValidValue(A329PropostaStatus);
            n329PropostaStatus = false;
            AssignAttri("", false, "A329PropostaStatus", A329PropostaStatus);
         }
         /* End function init_web_controls */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Propostaid( )
      {
         n323PropostaId = false;
         n649PropostaMaxReembolsoId_F = false;
         n854PropostaQtdItensNota_F = false;
         n655PropostaQtdDocumentoPendente_F = false;
         n341PropostaAprovacoes_F = false;
         n342PropostaReprovacoes_F = false;
         /* Using cursor T001A103 */
         pr_default.execute(52, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(52) != 101) )
         {
            A649PropostaMaxReembolsoId_F = T001A103_A649PropostaMaxReembolsoId_F[0];
            n649PropostaMaxReembolsoId_F = T001A103_n649PropostaMaxReembolsoId_F[0];
         }
         else
         {
            A649PropostaMaxReembolsoId_F = 0;
            n649PropostaMaxReembolsoId_F = false;
         }
         pr_default.close(52);
         /* Using cursor T001A105 */
         pr_default.execute(53, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(53) != 101) )
         {
            A854PropostaQtdItensNota_F = T001A105_A854PropostaQtdItensNota_F[0];
            n854PropostaQtdItensNota_F = T001A105_n854PropostaQtdItensNota_F[0];
         }
         else
         {
            A854PropostaQtdItensNota_F = 0;
            n854PropostaQtdItensNota_F = false;
         }
         pr_default.close(53);
         /* Using cursor T001A107 */
         pr_default.execute(54, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(54) != 101) )
         {
            A655PropostaQtdDocumentoPendente_F = T001A107_A655PropostaQtdDocumentoPendente_F[0];
            n655PropostaQtdDocumentoPendente_F = T001A107_n655PropostaQtdDocumentoPendente_F[0];
         }
         else
         {
            A655PropostaQtdDocumentoPendente_F = 0;
            n655PropostaQtdDocumentoPendente_F = false;
         }
         pr_default.close(54);
         /* Using cursor T001A109 */
         pr_default.execute(55, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(55) != 101) )
         {
            A341PropostaAprovacoes_F = T001A109_A341PropostaAprovacoes_F[0];
            n341PropostaAprovacoes_F = T001A109_n341PropostaAprovacoes_F[0];
         }
         else
         {
            A341PropostaAprovacoes_F = 0;
            n341PropostaAprovacoes_F = false;
         }
         pr_default.close(55);
         /* Using cursor T001A111 */
         pr_default.execute(56, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(56) != 101) )
         {
            A342PropostaReprovacoes_F = T001A111_A342PropostaReprovacoes_F[0];
            n342PropostaReprovacoes_F = T001A111_n342PropostaReprovacoes_F[0];
         }
         else
         {
            A342PropostaReprovacoes_F = 0;
            n342PropostaReprovacoes_F = false;
         }
         pr_default.close(56);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A649PropostaMaxReembolsoId_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A649PropostaMaxReembolsoId_F), 9, 0, ".", "")));
         AssignAttri("", false, "A854PropostaQtdItensNota_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A854PropostaQtdItensNota_F), 4, 0, ".", "")));
         AssignAttri("", false, "A655PropostaQtdDocumentoPendente_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A655PropostaQtdDocumentoPendente_F), 4, 0, ".", "")));
         AssignAttri("", false, "A341PropostaAprovacoes_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A341PropostaAprovacoes_F), 4, 0, ".", "")));
         AssignAttri("", false, "A342PropostaReprovacoes_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A342PropostaReprovacoes_F), 4, 0, ".", "")));
      }

      public void Valid_Propostacratedby( )
      {
         n323PropostaId = false;
         n511PropostaValorTaxaRecebida_F = false;
         n512PropostaSecUserName = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_PropostaCratedBy) )
         {
            A328PropostaCratedBy = AV11Insert_PropostaCratedBy;
            n328PropostaCratedBy = false;
         }
         else
         {
            if ( (0==AV19ComboPropostaCratedBy) )
            {
               A328PropostaCratedBy = 0;
               n328PropostaCratedBy = false;
               n328PropostaCratedBy = true;
               n328PropostaCratedBy = true;
            }
            else
            {
               if ( ! (0==AV19ComboPropostaCratedBy) )
               {
                  A328PropostaCratedBy = AV19ComboPropostaCratedBy;
                  n328PropostaCratedBy = false;
               }
               else
               {
                  if ( (0==A328PropostaCratedBy) )
                  {
                     A328PropostaCratedBy = 0;
                     n328PropostaCratedBy = false;
                     n328PropostaCratedBy = true;
                     n328PropostaCratedBy = true;
                  }
               }
            }
         }
         /* Using cursor T001A112 */
         pr_default.execute(57, new Object[] {n328PropostaCratedBy, A328PropostaCratedBy});
         if ( (pr_default.getStatus(57) == 101) )
         {
            if ( ! ( (0==A328PropostaCratedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sec User Proposta'.", "ForeignKeyNotFound", 1, "PROPOSTACRATEDBY");
               AnyError = 1;
               GX_FocusControl = edtPropostaCratedBy_Internalname;
            }
         }
         A512PropostaSecUserName = T001A112_A512PropostaSecUserName[0];
         n512PropostaSecUserName = T001A112_n512PropostaSecUserName[0];
         pr_default.close(57);
         /* Using cursor T001A115 */
         pr_default.execute(58, new Object[] {n328PropostaCratedBy, A328PropostaCratedBy, n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(58) != 101) )
         {
            A511PropostaValorTaxaRecebida_F = T001A115_A511PropostaValorTaxaRecebida_F[0];
            n511PropostaValorTaxaRecebida_F = T001A115_n511PropostaValorTaxaRecebida_F[0];
         }
         else
         {
            A511PropostaValorTaxaRecebida_F = 0;
            n511PropostaValorTaxaRecebida_F = false;
         }
         pr_default.close(58);
         if ( ( A511PropostaValorTaxaRecebida_F < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "PROPOSTACRATEDBY");
            AnyError = 1;
            GX_FocusControl = edtPropostaCratedBy_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A328PropostaCratedBy", ((0==A328PropostaCratedBy)&&IsIns( )||n328PropostaCratedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A328PropostaCratedBy), 4, 0, ".", ""))));
         AssignAttri("", false, "A512PropostaSecUserName", A512PropostaSecUserName);
         AssignAttri("", false, "A511PropostaValorTaxaRecebida_F", StringUtil.LTrim( StringUtil.NToC( A511PropostaValorTaxaRecebida_F, 18, 2, ".", "")));
      }

      public void Valid_Procedimentosmedicosid( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV24Insert_ProcedimentosMedicosId) )
         {
            A376ProcedimentosMedicosId = AV24Insert_ProcedimentosMedicosId;
            n376ProcedimentosMedicosId = false;
         }
         else
         {
            if ( (0==AV28ComboProcedimentosMedicosId) )
            {
               A376ProcedimentosMedicosId = 0;
               n376ProcedimentosMedicosId = false;
               n376ProcedimentosMedicosId = true;
               n376ProcedimentosMedicosId = true;
            }
            else
            {
               if ( ! (0==AV28ComboProcedimentosMedicosId) )
               {
                  A376ProcedimentosMedicosId = AV28ComboProcedimentosMedicosId;
                  n376ProcedimentosMedicosId = false;
               }
               else
               {
                  if ( (0==A376ProcedimentosMedicosId) )
                  {
                     A376ProcedimentosMedicosId = 0;
                     n376ProcedimentosMedicosId = false;
                     n376ProcedimentosMedicosId = true;
                     n376ProcedimentosMedicosId = true;
                  }
               }
            }
         }
         /* Using cursor T001A148 */
         pr_default.execute(79, new Object[] {n376ProcedimentosMedicosId, A376ProcedimentosMedicosId});
         if ( (pr_default.getStatus(79) == 101) )
         {
            if ( ! ( (0==A376ProcedimentosMedicosId) ) )
            {
               GX_msglist.addItem("Não existe 'ProcedimentosMedicos'.", "ForeignKeyNotFound", 1, "PROCEDIMENTOSMEDICOSID");
               AnyError = 1;
               GX_FocusControl = edtProcedimentosMedicosId_Internalname;
            }
         }
         pr_default.close(79);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A376ProcedimentosMedicosId", ((0==A376ProcedimentosMedicosId)&&IsIns( )||n376ProcedimentosMedicosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ProcedimentosMedicosId), 9, 0, ".", ""))));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"AV7PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV35Insert_PropostaEmpresaClienteId","fld":"vINSERT_PROPOSTAEMPRESACLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV32Insert_PropostaPacienteClienteId","fld":"vINSERT_PROPOSTAPACIENTECLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV33Insert_PropostaResponsavelId","fld":"vINSERT_PROPOSTARESPONSAVELID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV24Insert_ProcedimentosMedicosId","fld":"vINSERT_PROCEDIMENTOSMEDICOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV11Insert_PropostaCratedBy","fld":"vINSERT_PROPOSTACRATEDBY","pic":"ZZZ9","type":"int"},{"av":"AV34Insert_PropostaClinicaId","fld":"vINSERT_PROPOSTACLINICAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV12Insert_ContratoId","fld":"vINSERT_CONTRATOID","pic":"ZZZZZ9","type":"int"},{"av":"AV31Insert_ConvenioCategoriaId","fld":"vINSERT_CONVENIOCATEGORIAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A853PropostaProtocolo","fld":"PROPOSTAPROTOCOLO","type":"svchar"},{"av":"A849PropostaTipoProposta","fld":"PROPOSTATIPOPROPOSTA","type":"svchar"},{"av":"A517PropostaDataCirurgia","fld":"PROPOSTADATACIRURGIA","type":"date"},{"av":"A855PropostaValorLiquido","fld":"PROPOSTAVALORLIQUIDO","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","nullAv":"n855PropostaValorLiquido","type":"decimal"},{"av":"A501PropostaTaxaAdministrativa","fld":"PROPOSTATAXAADMINISTRATIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","nullAv":"n501PropostaTaxaAdministrativa","type":"decimal"},{"av":"A507PropostaSLA","fld":"PROPOSTASLA","pic":"ZZZ9","nullAv":"n507PropostaSLA","type":"int"},{"av":"A508PropostaJurosMora","fld":"PROPOSTAJUROSMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","nullAv":"n508PropostaJurosMora","type":"decimal"},{"av":"A790PropostaComentarioAnalise","fld":"PROPOSTACOMENTARIOANALISE","type":"svchar"},{"av":"A496ConvenioVencimentoAno","fld":"CONVENIOVENCIMENTOANO","pic":"ZZZ9","nullAv":"n496ConvenioVencimentoAno","type":"int"},{"av":"A497ConvenioVencimentoMes","fld":"CONVENIOVENCIMENTOMES","pic":"ZZZ9","nullAv":"n497ConvenioVencimentoMes","type":"int"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E121A2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""}]}""");
         setEventMetadata("VALID_PROPOSTAVALOR","""{"handler":"Valid_Propostavalor","iparms":[]}""");
         setEventMetadata("VALID_PROPOSTACRATEDBY","""{"handler":"Valid_Propostacratedby","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV11Insert_PropostaCratedBy","fld":"vINSERT_PROPOSTACRATEDBY","pic":"ZZZ9","type":"int"},{"av":"AV19ComboPropostaCratedBy","fld":"vCOMBOPROPOSTACRATEDBY","pic":"ZZZ9","type":"int"},{"av":"A328PropostaCratedBy","fld":"PROPOSTACRATEDBY","pic":"ZZZ9","nullAv":"n328PropostaCratedBy","type":"int"},{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A511PropostaValorTaxaRecebida_F","fld":"PROPOSTAVALORTAXARECEBIDA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A512PropostaSecUserName","fld":"PROPOSTASECUSERNAME","pic":"@!","type":"svchar"}]""");
         setEventMetadata("VALID_PROPOSTACRATEDBY",""","oparms":[{"av":"A328PropostaCratedBy","fld":"PROPOSTACRATEDBY","pic":"ZZZ9","nullAv":"n328PropostaCratedBy","type":"int"},{"av":"A512PropostaSecUserName","fld":"PROPOSTASECUSERNAME","pic":"@!","type":"svchar"},{"av":"A511PropostaValorTaxaRecebida_F","fld":"PROPOSTAVALORTAXARECEBIDA_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"}]}""");
         setEventMetadata("VALID_PROPOSTASTATUS","""{"handler":"Valid_Propostastatus","iparms":[]}""");
         setEventMetadata("VALID_PROPOSTAQUANTIDADEAPROVADORES","""{"handler":"Valid_Propostaquantidadeaprovadores","iparms":[]}""");
         setEventMetadata("VALID_PROCEDIMENTOSMEDICOSID","""{"handler":"Valid_Procedimentosmedicosid","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV24Insert_ProcedimentosMedicosId","fld":"vINSERT_PROCEDIMENTOSMEDICOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28ComboProcedimentosMedicosId","fld":"vCOMBOPROCEDIMENTOSMEDICOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A376ProcedimentosMedicosId","fld":"PROCEDIMENTOSMEDICOSID","pic":"ZZZZZZZZ9","nullAv":"n376ProcedimentosMedicosId","type":"int"}]""");
         setEventMetadata("VALID_PROCEDIMENTOSMEDICOSID",""","oparms":[{"av":"A376ProcedimentosMedicosId","fld":"PROCEDIMENTOSMEDICOSID","pic":"ZZZZZZZZ9","nullAv":"n376ProcedimentosMedicosId","type":"int"}]}""");
         setEventMetadata("VALID_PROPOSTAAPROVACOES_F","""{"handler":"Valid_Propostaaprovacoes_f","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOPROPOSTACRATEDBY","""{"handler":"Validv_Combopropostacratedby","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOPROCEDIMENTOSMEDICOSID","""{"handler":"Validv_Comboprocedimentosmedicosid","iparms":[]}""");
         setEventMetadata("VALID_PROPOSTAID","""{"handler":"Valid_Propostaid","iparms":[{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A649PropostaMaxReembolsoId_F","fld":"PROPOSTAMAXREEMBOLSOID_F","pic":"ZZZZZZZZ9","type":"int"},{"av":"A854PropostaQtdItensNota_F","fld":"PROPOSTAQTDITENSNOTA_F","pic":"ZZZ9","type":"int"},{"av":"A655PropostaQtdDocumentoPendente_F","fld":"PROPOSTAQTDDOCUMENTOPENDENTE_F","pic":"ZZZ9","type":"int"},{"av":"A341PropostaAprovacoes_F","fld":"PROPOSTAAPROVACOES_F","pic":"ZZZ9","type":"int"},{"av":"A342PropostaReprovacoes_F","fld":"PROPOSTAREPROVACOES_F","pic":"ZZZ9","type":"int"}]""");
         setEventMetadata("VALID_PROPOSTAID",""","oparms":[{"av":"A649PropostaMaxReembolsoId_F","fld":"PROPOSTAMAXREEMBOLSOID_F","pic":"ZZZZZZZZ9","type":"int"},{"av":"A854PropostaQtdItensNota_F","fld":"PROPOSTAQTDITENSNOTA_F","pic":"ZZZ9","type":"int"},{"av":"A655PropostaQtdDocumentoPendente_F","fld":"PROPOSTAQTDDOCUMENTOPENDENTE_F","pic":"ZZZ9","type":"int"},{"av":"A341PropostaAprovacoes_F","fld":"PROPOSTAAPROVACOES_F","pic":"ZZZ9","type":"int"},{"av":"A342PropostaReprovacoes_F","fld":"PROPOSTAREPROVACOES_F","pic":"ZZZ9","type":"int"}]}""");
         return  ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected override void CloseCursors( )
      {
         pr_default.close(1);
         pr_default.close(59);
         pr_default.close(79);
         pr_default.close(60);
         pr_default.close(57);
         pr_default.close(61);
         pr_default.close(68);
         pr_default.close(69);
         pr_default.close(62);
         pr_default.close(63);
         pr_default.close(58);
         pr_default.close(64);
         pr_default.close(70);
         pr_default.close(52);
         pr_default.close(53);
         pr_default.close(65);
         pr_default.close(66);
         pr_default.close(67);
         pr_default.close(54);
         pr_default.close(55);
         pr_default.close(56);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         Z853PropostaProtocolo = "";
         Z849PropostaTipoProposta = "";
         Z324PropostaTitulo = "";
         Z325PropostaDescricao = "";
         Z517PropostaDataCirurgia = DateTime.MinValue;
         Z329PropostaStatus = "";
         Z790PropostaComentarioAnalise = "";
         Combo_procedimentosmedicosid_Selectedvalue_get = "";
         Combo_propostacratedby_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A515PropostaDataCreditoCliente_F = DateTime.MinValue;
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A329PropostaStatus = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A324PropostaTitulo = "";
         A325PropostaDescricao = "";
         A327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         lblTextblockpropostacratedby_Jsonclick = "";
         ucCombo_propostacratedby = new GXUserControl();
         AV15DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV14PropostaCratedBy_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockprocedimentosmedicosid_Jsonclick = "";
         ucCombo_procedimentosmedicosid = new GXUserControl();
         AV27ProcedimentosMedicosId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A853PropostaProtocolo = "";
         A849PropostaTipoProposta = "";
         A517PropostaDataCirurgia = DateTime.MinValue;
         A790PropostaComentarioAnalise = "";
         A228ContratoNome = "";
         A494ConvenioCategoriaDescricao = "";
         A512PropostaSecUserName = "";
         A505PropostaPacienteClienteRazaoSocial = "";
         A540PropostaPacienteClienteDocumento = "";
         A541PropostaPacienteContatoEmail = "";
         A584PropostaPacienteConta = "";
         A585PropostaPacienteAgencia = "";
         A586PropostaPacienteTipoPix = "";
         A587PropostaPacientePIX = "";
         A588PropostaPacienteDepositoTipo = "";
         A620PropostaPacienteEnderecoCEP = "";
         A621PropostaPacienteEnderecoLogradouro = "";
         A622PropostaPacienteEnderecoNumero = "";
         A623PropostaPacienteEnderecoComplemento = "";
         A624PropostaPacienteEnderecoBairro = "";
         A625PropostaPacienteMunicipioCodigo = "";
         A580PropostaResponsavelDocumento = "";
         A581PropostaResponsavelRazaoSocial = "";
         A582PropostaResponsavelEmail = "";
         A590PropostaResponsavelConta = "";
         A591PropostaResponsavelAgencia = "";
         A592PropostaResponsavelTipoPix = "";
         A593PropostaResponsavelPIX = "";
         A594PropostaResponsavelDepositoTipo = "";
         A643PropostaClinicaNome = "";
         A644PropostaClinicaNomeFantasia = "";
         A652PropostaClinicaDocumento = "";
         A653PropostaClinicaEmail = "";
         AV36Pgmname = "";
         Combo_propostacratedby_Objectcall = "";
         Combo_propostacratedby_Class = "";
         Combo_propostacratedby_Icontype = "";
         Combo_propostacratedby_Icon = "";
         Combo_propostacratedby_Tooltip = "";
         Combo_propostacratedby_Selectedvalue_set = "";
         Combo_propostacratedby_Selectedtext_set = "";
         Combo_propostacratedby_Selectedtext_get = "";
         Combo_propostacratedby_Gamoauthtoken = "";
         Combo_propostacratedby_Ddointernalname = "";
         Combo_propostacratedby_Titlecontrolalign = "";
         Combo_propostacratedby_Dropdownoptionstype = "";
         Combo_propostacratedby_Titlecontrolidtoreplace = "";
         Combo_propostacratedby_Datalisttype = "";
         Combo_propostacratedby_Datalistfixedvalues = "";
         Combo_propostacratedby_Remoteservicesparameters = "";
         Combo_propostacratedby_Htmltemplate = "";
         Combo_propostacratedby_Multiplevaluestype = "";
         Combo_propostacratedby_Loadingdata = "";
         Combo_propostacratedby_Noresultsfound = "";
         Combo_propostacratedby_Emptyitemtext = "";
         Combo_propostacratedby_Onlyselectedvalues = "";
         Combo_propostacratedby_Selectalltext = "";
         Combo_propostacratedby_Multiplevaluesseparator = "";
         Combo_propostacratedby_Addnewoptiontext = "";
         Combo_procedimentosmedicosid_Objectcall = "";
         Combo_procedimentosmedicosid_Class = "";
         Combo_procedimentosmedicosid_Icontype = "";
         Combo_procedimentosmedicosid_Icon = "";
         Combo_procedimentosmedicosid_Tooltip = "";
         Combo_procedimentosmedicosid_Selectedvalue_set = "";
         Combo_procedimentosmedicosid_Selectedtext_set = "";
         Combo_procedimentosmedicosid_Selectedtext_get = "";
         Combo_procedimentosmedicosid_Gamoauthtoken = "";
         Combo_procedimentosmedicosid_Ddointernalname = "";
         Combo_procedimentosmedicosid_Titlecontrolalign = "";
         Combo_procedimentosmedicosid_Dropdownoptionstype = "";
         Combo_procedimentosmedicosid_Titlecontrolidtoreplace = "";
         Combo_procedimentosmedicosid_Datalisttype = "";
         Combo_procedimentosmedicosid_Datalistfixedvalues = "";
         Combo_procedimentosmedicosid_Remoteservicesparameters = "";
         Combo_procedimentosmedicosid_Htmltemplate = "";
         Combo_procedimentosmedicosid_Multiplevaluestype = "";
         Combo_procedimentosmedicosid_Loadingdata = "";
         Combo_procedimentosmedicosid_Noresultsfound = "";
         Combo_procedimentosmedicosid_Emptyitemtext = "";
         Combo_procedimentosmedicosid_Onlyselectedvalues = "";
         Combo_procedimentosmedicosid_Selectalltext = "";
         Combo_procedimentosmedicosid_Multiplevaluesseparator = "";
         Combo_procedimentosmedicosid_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode49 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV13TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV18Combo_DataJson = "";
         AV16ComboSelectedValue = "";
         AV17ComboSelectedText = "";
         GXt_char2 = "";
         Z228ContratoNome = "";
         Z494ConvenioCategoriaDescricao = "";
         Z505PropostaPacienteClienteRazaoSocial = "";
         Z540PropostaPacienteClienteDocumento = "";
         Z541PropostaPacienteContatoEmail = "";
         Z584PropostaPacienteConta = "";
         Z585PropostaPacienteAgencia = "";
         Z586PropostaPacienteTipoPix = "";
         Z587PropostaPacientePIX = "";
         Z588PropostaPacienteDepositoTipo = "";
         Z620PropostaPacienteEnderecoCEP = "";
         Z621PropostaPacienteEnderecoLogradouro = "";
         Z622PropostaPacienteEnderecoNumero = "";
         Z623PropostaPacienteEnderecoComplemento = "";
         Z624PropostaPacienteEnderecoBairro = "";
         Z625PropostaPacienteMunicipioCodigo = "";
         Z580PropostaResponsavelDocumento = "";
         Z581PropostaResponsavelRazaoSocial = "";
         Z582PropostaResponsavelEmail = "";
         Z590PropostaResponsavelConta = "";
         Z591PropostaResponsavelAgencia = "";
         Z592PropostaResponsavelTipoPix = "";
         Z593PropostaResponsavelPIX = "";
         Z594PropostaResponsavelDepositoTipo = "";
         Z643PropostaClinicaNome = "";
         Z644PropostaClinicaNomeFantasia = "";
         Z652PropostaClinicaDocumento = "";
         Z653PropostaClinicaEmail = "";
         Z512PropostaSecUserName = "";
         T001A27_A649PropostaMaxReembolsoId_F = new int[1] ;
         T001A27_n649PropostaMaxReembolsoId_F = new bool[] {false} ;
         T001A29_A854PropostaQtdItensNota_F = new short[1] ;
         T001A29_n854PropostaQtdItensNota_F = new bool[] {false} ;
         T001A39_A655PropostaQtdDocumentoPendente_F = new short[1] ;
         T001A39_n655PropostaQtdDocumentoPendente_F = new bool[] {false} ;
         T001A41_A341PropostaAprovacoes_F = new short[1] ;
         T001A41_n341PropostaAprovacoes_F = new bool[] {false} ;
         T001A43_A342PropostaReprovacoes_F = new short[1] ;
         T001A43_n342PropostaReprovacoes_F = new bool[] {false} ;
         T001A10_A643PropostaClinicaNome = new string[] {""} ;
         T001A10_n643PropostaClinicaNome = new bool[] {false} ;
         T001A10_A644PropostaClinicaNomeFantasia = new string[] {""} ;
         T001A10_n644PropostaClinicaNomeFantasia = new bool[] {false} ;
         T001A10_A652PropostaClinicaDocumento = new string[] {""} ;
         T001A10_n652PropostaClinicaDocumento = new bool[] {false} ;
         T001A10_A653PropostaClinicaEmail = new string[] {""} ;
         T001A10_n653PropostaClinicaEmail = new bool[] {false} ;
         T001A25_A650PropostaValorTaxaClinica_F = new decimal[1] ;
         T001A25_n650PropostaValorTaxaClinica_F = new bool[] {false} ;
         T001A54_A323PropostaId = new int[1] ;
         T001A54_n323PropostaId = new bool[] {false} ;
         T001A54_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T001A54_n327PropostaCreatedAt = new bool[] {false} ;
         T001A54_A853PropostaProtocolo = new string[] {""} ;
         T001A54_n853PropostaProtocolo = new bool[] {false} ;
         T001A54_A849PropostaTipoProposta = new string[] {""} ;
         T001A54_n849PropostaTipoProposta = new bool[] {false} ;
         T001A54_A580PropostaResponsavelDocumento = new string[] {""} ;
         T001A54_n580PropostaResponsavelDocumento = new bool[] {false} ;
         T001A54_A581PropostaResponsavelRazaoSocial = new string[] {""} ;
         T001A54_n581PropostaResponsavelRazaoSocial = new bool[] {false} ;
         T001A54_A582PropostaResponsavelEmail = new string[] {""} ;
         T001A54_n582PropostaResponsavelEmail = new bool[] {false} ;
         T001A54_A590PropostaResponsavelConta = new string[] {""} ;
         T001A54_n590PropostaResponsavelConta = new bool[] {false} ;
         T001A54_A591PropostaResponsavelAgencia = new string[] {""} ;
         T001A54_n591PropostaResponsavelAgencia = new bool[] {false} ;
         T001A54_A592PropostaResponsavelTipoPix = new string[] {""} ;
         T001A54_n592PropostaResponsavelTipoPix = new bool[] {false} ;
         T001A54_A593PropostaResponsavelPIX = new string[] {""} ;
         T001A54_n593PropostaResponsavelPIX = new bool[] {false} ;
         T001A54_A594PropostaResponsavelDepositoTipo = new string[] {""} ;
         T001A54_n594PropostaResponsavelDepositoTipo = new bool[] {false} ;
         T001A54_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         T001A54_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         T001A54_A540PropostaPacienteClienteDocumento = new string[] {""} ;
         T001A54_n540PropostaPacienteClienteDocumento = new bool[] {false} ;
         T001A54_A541PropostaPacienteContatoEmail = new string[] {""} ;
         T001A54_n541PropostaPacienteContatoEmail = new bool[] {false} ;
         T001A54_A584PropostaPacienteConta = new string[] {""} ;
         T001A54_n584PropostaPacienteConta = new bool[] {false} ;
         T001A54_A585PropostaPacienteAgencia = new string[] {""} ;
         T001A54_n585PropostaPacienteAgencia = new bool[] {false} ;
         T001A54_A586PropostaPacienteTipoPix = new string[] {""} ;
         T001A54_n586PropostaPacienteTipoPix = new bool[] {false} ;
         T001A54_A587PropostaPacientePIX = new string[] {""} ;
         T001A54_n587PropostaPacientePIX = new bool[] {false} ;
         T001A54_A588PropostaPacienteDepositoTipo = new string[] {""} ;
         T001A54_n588PropostaPacienteDepositoTipo = new bool[] {false} ;
         T001A54_A620PropostaPacienteEnderecoCEP = new string[] {""} ;
         T001A54_n620PropostaPacienteEnderecoCEP = new bool[] {false} ;
         T001A54_A621PropostaPacienteEnderecoLogradouro = new string[] {""} ;
         T001A54_n621PropostaPacienteEnderecoLogradouro = new bool[] {false} ;
         T001A54_A622PropostaPacienteEnderecoNumero = new string[] {""} ;
         T001A54_n622PropostaPacienteEnderecoNumero = new bool[] {false} ;
         T001A54_A623PropostaPacienteEnderecoComplemento = new string[] {""} ;
         T001A54_n623PropostaPacienteEnderecoComplemento = new bool[] {false} ;
         T001A54_A624PropostaPacienteEnderecoBairro = new string[] {""} ;
         T001A54_n624PropostaPacienteEnderecoBairro = new bool[] {false} ;
         T001A54_A324PropostaTitulo = new string[] {""} ;
         T001A54_n324PropostaTitulo = new bool[] {false} ;
         T001A54_A325PropostaDescricao = new string[] {""} ;
         T001A54_n325PropostaDescricao = new bool[] {false} ;
         T001A54_A517PropostaDataCirurgia = new DateTime[] {DateTime.MinValue} ;
         T001A54_n517PropostaDataCirurgia = new bool[] {false} ;
         T001A54_A326PropostaValor = new decimal[1] ;
         T001A54_n326PropostaValor = new bool[] {false} ;
         T001A54_A855PropostaValorLiquido = new decimal[1] ;
         T001A54_n855PropostaValorLiquido = new bool[] {false} ;
         T001A54_A501PropostaTaxaAdministrativa = new decimal[1] ;
         T001A54_n501PropostaTaxaAdministrativa = new bool[] {false} ;
         T001A54_A507PropostaSLA = new short[1] ;
         T001A54_n507PropostaSLA = new bool[] {false} ;
         T001A54_A508PropostaJurosMora = new decimal[1] ;
         T001A54_n508PropostaJurosMora = new bool[] {false} ;
         T001A54_A643PropostaClinicaNome = new string[] {""} ;
         T001A54_n643PropostaClinicaNome = new bool[] {false} ;
         T001A54_A644PropostaClinicaNomeFantasia = new string[] {""} ;
         T001A54_n644PropostaClinicaNomeFantasia = new bool[] {false} ;
         T001A54_A652PropostaClinicaDocumento = new string[] {""} ;
         T001A54_n652PropostaClinicaDocumento = new bool[] {false} ;
         T001A54_A653PropostaClinicaEmail = new string[] {""} ;
         T001A54_n653PropostaClinicaEmail = new bool[] {false} ;
         T001A54_A512PropostaSecUserName = new string[] {""} ;
         T001A54_n512PropostaSecUserName = new bool[] {false} ;
         T001A54_A329PropostaStatus = new string[] {""} ;
         T001A54_n329PropostaStatus = new bool[] {false} ;
         T001A54_A790PropostaComentarioAnalise = new string[] {""} ;
         T001A54_n790PropostaComentarioAnalise = new bool[] {false} ;
         T001A54_A330PropostaQuantidadeAprovadores = new short[1] ;
         T001A54_n330PropostaQuantidadeAprovadores = new bool[] {false} ;
         T001A54_A345PropostaReprovacoesPermitidas = new short[1] ;
         T001A54_n345PropostaReprovacoesPermitidas = new bool[] {false} ;
         T001A54_A228ContratoNome = new string[] {""} ;
         T001A54_n228ContratoNome = new bool[] {false} ;
         T001A54_A496ConvenioVencimentoAno = new short[1] ;
         T001A54_n496ConvenioVencimentoAno = new bool[] {false} ;
         T001A54_A497ConvenioVencimentoMes = new short[1] ;
         T001A54_n497ConvenioVencimentoMes = new bool[] {false} ;
         T001A54_A494ConvenioCategoriaDescricao = new string[] {""} ;
         T001A54_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         T001A54_A227ContratoId = new int[1] ;
         T001A54_n227ContratoId = new bool[] {false} ;
         T001A54_A376ProcedimentosMedicosId = new int[1] ;
         T001A54_n376ProcedimentosMedicosId = new bool[] {false} ;
         T001A54_A493ConvenioCategoriaId = new int[1] ;
         T001A54_n493ConvenioCategoriaId = new bool[] {false} ;
         T001A54_A328PropostaCratedBy = new short[1] ;
         T001A54_n328PropostaCratedBy = new bool[] {false} ;
         T001A54_A504PropostaPacienteClienteId = new int[1] ;
         T001A54_n504PropostaPacienteClienteId = new bool[] {false} ;
         T001A54_A553PropostaResponsavelId = new int[1] ;
         T001A54_n553PropostaResponsavelId = new bool[] {false} ;
         T001A54_A642PropostaClinicaId = new int[1] ;
         T001A54_n642PropostaClinicaId = new bool[] {false} ;
         T001A54_A850PropostaEmpresaClienteId = new int[1] ;
         T001A54_n850PropostaEmpresaClienteId = new bool[] {false} ;
         T001A54_A410ConvenioId = new int[1] ;
         T001A54_n410ConvenioId = new bool[] {false} ;
         T001A54_A625PropostaPacienteMunicipioCodigo = new string[] {""} ;
         T001A54_n625PropostaPacienteMunicipioCodigo = new bool[] {false} ;
         T001A54_A649PropostaMaxReembolsoId_F = new int[1] ;
         T001A54_n649PropostaMaxReembolsoId_F = new bool[] {false} ;
         T001A54_A854PropostaQtdItensNota_F = new short[1] ;
         T001A54_n854PropostaQtdItensNota_F = new bool[] {false} ;
         T001A54_A733PropostaResponsavelSerasaConsultas_F = new short[1] ;
         T001A54_n733PropostaResponsavelSerasaConsultas_F = new bool[] {false} ;
         T001A54_A783PropostaResponsavelSerasaScoreUltimaData_F = new short[1] ;
         T001A54_n783PropostaResponsavelSerasaScoreUltimaData_F = new bool[] {false} ;
         T001A54_A786PropostaResponsavelSerasaUltimoValorRecomendado_F = new decimal[1] ;
         T001A54_n786PropostaResponsavelSerasaUltimoValorRecomendado_F = new bool[] {false} ;
         T001A54_A734PropostaPacienteSerasaConsultas_F = new short[1] ;
         T001A54_n734PropostaPacienteSerasaConsultas_F = new bool[] {false} ;
         T001A54_A782PropostaSerasaScoreUltimaData_F = new short[1] ;
         T001A54_n782PropostaSerasaScoreUltimaData_F = new bool[] {false} ;
         T001A54_A787PropostaPacienteSerasaUltimoValorRecomendado_F = new decimal[1] ;
         T001A54_n787PropostaPacienteSerasaUltimoValorRecomendado_F = new bool[] {false} ;
         T001A54_A655PropostaQtdDocumentoPendente_F = new short[1] ;
         T001A54_n655PropostaQtdDocumentoPendente_F = new bool[] {false} ;
         T001A54_A341PropostaAprovacoes_F = new short[1] ;
         T001A54_n341PropostaAprovacoes_F = new bool[] {false} ;
         T001A54_A342PropostaReprovacoes_F = new short[1] ;
         T001A54_n342PropostaReprovacoes_F = new bool[] {false} ;
         T001A14_A509PropostaValorReembolsado_F = new decimal[1] ;
         T001A14_n509PropostaValorReembolsado_F = new bool[] {false} ;
         T001A17_A510PropostaValorReembolsadoJuros_F = new decimal[1] ;
         T001A17_n510PropostaValorReembolsadoJuros_F = new bool[] {false} ;
         T001A20_A511PropostaValorTaxaRecebida_F = new decimal[1] ;
         T001A20_n511PropostaValorTaxaRecebida_F = new bool[] {false} ;
         T001A23_A515PropostaDataCreditoCliente_F = new DateTime[] {DateTime.MinValue} ;
         T001A23_n515PropostaDataCreditoCliente_F = new bool[] {false} ;
         T001A5_A376ProcedimentosMedicosId = new int[1] ;
         T001A5_n376ProcedimentosMedicosId = new bool[] {false} ;
         T001A7_A512PropostaSecUserName = new string[] {""} ;
         T001A7_n512PropostaSecUserName = new bool[] {false} ;
         T001A4_A228ContratoNome = new string[] {""} ;
         T001A4_n228ContratoNome = new bool[] {false} ;
         T001A6_A494ConvenioCategoriaDescricao = new string[] {""} ;
         T001A6_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         T001A6_A410ConvenioId = new int[1] ;
         T001A6_n410ConvenioId = new bool[] {false} ;
         T001A8_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         T001A8_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         T001A8_A540PropostaPacienteClienteDocumento = new string[] {""} ;
         T001A8_n540PropostaPacienteClienteDocumento = new bool[] {false} ;
         T001A8_A541PropostaPacienteContatoEmail = new string[] {""} ;
         T001A8_n541PropostaPacienteContatoEmail = new bool[] {false} ;
         T001A8_A584PropostaPacienteConta = new string[] {""} ;
         T001A8_n584PropostaPacienteConta = new bool[] {false} ;
         T001A8_A585PropostaPacienteAgencia = new string[] {""} ;
         T001A8_n585PropostaPacienteAgencia = new bool[] {false} ;
         T001A8_A586PropostaPacienteTipoPix = new string[] {""} ;
         T001A8_n586PropostaPacienteTipoPix = new bool[] {false} ;
         T001A8_A587PropostaPacientePIX = new string[] {""} ;
         T001A8_n587PropostaPacientePIX = new bool[] {false} ;
         T001A8_A588PropostaPacienteDepositoTipo = new string[] {""} ;
         T001A8_n588PropostaPacienteDepositoTipo = new bool[] {false} ;
         T001A8_A620PropostaPacienteEnderecoCEP = new string[] {""} ;
         T001A8_n620PropostaPacienteEnderecoCEP = new bool[] {false} ;
         T001A8_A621PropostaPacienteEnderecoLogradouro = new string[] {""} ;
         T001A8_n621PropostaPacienteEnderecoLogradouro = new bool[] {false} ;
         T001A8_A622PropostaPacienteEnderecoNumero = new string[] {""} ;
         T001A8_n622PropostaPacienteEnderecoNumero = new bool[] {false} ;
         T001A8_A623PropostaPacienteEnderecoComplemento = new string[] {""} ;
         T001A8_n623PropostaPacienteEnderecoComplemento = new bool[] {false} ;
         T001A8_A624PropostaPacienteEnderecoBairro = new string[] {""} ;
         T001A8_n624PropostaPacienteEnderecoBairro = new bool[] {false} ;
         T001A8_A625PropostaPacienteMunicipioCodigo = new string[] {""} ;
         T001A8_n625PropostaPacienteMunicipioCodigo = new bool[] {false} ;
         T001A31_A733PropostaResponsavelSerasaConsultas_F = new short[1] ;
         T001A31_n733PropostaResponsavelSerasaConsultas_F = new bool[] {false} ;
         T001A31_A734PropostaPacienteSerasaConsultas_F = new short[1] ;
         T001A31_n734PropostaPacienteSerasaConsultas_F = new bool[] {false} ;
         T001A34_A783PropostaResponsavelSerasaScoreUltimaData_F = new short[1] ;
         T001A34_n783PropostaResponsavelSerasaScoreUltimaData_F = new bool[] {false} ;
         T001A34_A782PropostaSerasaScoreUltimaData_F = new short[1] ;
         T001A34_n782PropostaSerasaScoreUltimaData_F = new bool[] {false} ;
         T001A37_A786PropostaResponsavelSerasaUltimoValorRecomendado_F = new decimal[1] ;
         T001A37_n786PropostaResponsavelSerasaUltimoValorRecomendado_F = new bool[] {false} ;
         T001A37_A787PropostaPacienteSerasaUltimoValorRecomendado_F = new decimal[1] ;
         T001A37_n787PropostaPacienteSerasaUltimoValorRecomendado_F = new bool[] {false} ;
         T001A9_A580PropostaResponsavelDocumento = new string[] {""} ;
         T001A9_n580PropostaResponsavelDocumento = new bool[] {false} ;
         T001A9_A581PropostaResponsavelRazaoSocial = new string[] {""} ;
         T001A9_n581PropostaResponsavelRazaoSocial = new bool[] {false} ;
         T001A9_A582PropostaResponsavelEmail = new string[] {""} ;
         T001A9_n582PropostaResponsavelEmail = new bool[] {false} ;
         T001A9_A590PropostaResponsavelConta = new string[] {""} ;
         T001A9_n590PropostaResponsavelConta = new bool[] {false} ;
         T001A9_A591PropostaResponsavelAgencia = new string[] {""} ;
         T001A9_n591PropostaResponsavelAgencia = new bool[] {false} ;
         T001A9_A592PropostaResponsavelTipoPix = new string[] {""} ;
         T001A9_n592PropostaResponsavelTipoPix = new bool[] {false} ;
         T001A9_A593PropostaResponsavelPIX = new string[] {""} ;
         T001A9_n593PropostaResponsavelPIX = new bool[] {false} ;
         T001A9_A594PropostaResponsavelDepositoTipo = new string[] {""} ;
         T001A9_n594PropostaResponsavelDepositoTipo = new bool[] {false} ;
         T001A11_A850PropostaEmpresaClienteId = new int[1] ;
         T001A11_n850PropostaEmpresaClienteId = new bool[] {false} ;
         T001A57_A509PropostaValorReembolsado_F = new decimal[1] ;
         T001A57_n509PropostaValorReembolsado_F = new bool[] {false} ;
         T001A60_A510PropostaValorReembolsadoJuros_F = new decimal[1] ;
         T001A60_n510PropostaValorReembolsadoJuros_F = new bool[] {false} ;
         T001A63_A511PropostaValorTaxaRecebida_F = new decimal[1] ;
         T001A63_n511PropostaValorTaxaRecebida_F = new bool[] {false} ;
         T001A66_A515PropostaDataCreditoCliente_F = new DateTime[] {DateTime.MinValue} ;
         T001A66_n515PropostaDataCreditoCliente_F = new bool[] {false} ;
         T001A68_A650PropostaValorTaxaClinica_F = new decimal[1] ;
         T001A68_n650PropostaValorTaxaClinica_F = new bool[] {false} ;
         T001A70_A649PropostaMaxReembolsoId_F = new int[1] ;
         T001A70_n649PropostaMaxReembolsoId_F = new bool[] {false} ;
         T001A72_A854PropostaQtdItensNota_F = new short[1] ;
         T001A72_n854PropostaQtdItensNota_F = new bool[] {false} ;
         T001A74_A655PropostaQtdDocumentoPendente_F = new short[1] ;
         T001A74_n655PropostaQtdDocumentoPendente_F = new bool[] {false} ;
         T001A76_A341PropostaAprovacoes_F = new short[1] ;
         T001A76_n341PropostaAprovacoes_F = new bool[] {false} ;
         T001A78_A342PropostaReprovacoes_F = new short[1] ;
         T001A78_n342PropostaReprovacoes_F = new bool[] {false} ;
         T001A79_A376ProcedimentosMedicosId = new int[1] ;
         T001A79_n376ProcedimentosMedicosId = new bool[] {false} ;
         T001A80_A512PropostaSecUserName = new string[] {""} ;
         T001A80_n512PropostaSecUserName = new bool[] {false} ;
         T001A81_A228ContratoNome = new string[] {""} ;
         T001A81_n228ContratoNome = new bool[] {false} ;
         T001A82_A494ConvenioCategoriaDescricao = new string[] {""} ;
         T001A82_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         T001A82_A410ConvenioId = new int[1] ;
         T001A82_n410ConvenioId = new bool[] {false} ;
         T001A83_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         T001A83_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         T001A83_A540PropostaPacienteClienteDocumento = new string[] {""} ;
         T001A83_n540PropostaPacienteClienteDocumento = new bool[] {false} ;
         T001A83_A541PropostaPacienteContatoEmail = new string[] {""} ;
         T001A83_n541PropostaPacienteContatoEmail = new bool[] {false} ;
         T001A83_A584PropostaPacienteConta = new string[] {""} ;
         T001A83_n584PropostaPacienteConta = new bool[] {false} ;
         T001A83_A585PropostaPacienteAgencia = new string[] {""} ;
         T001A83_n585PropostaPacienteAgencia = new bool[] {false} ;
         T001A83_A586PropostaPacienteTipoPix = new string[] {""} ;
         T001A83_n586PropostaPacienteTipoPix = new bool[] {false} ;
         T001A83_A587PropostaPacientePIX = new string[] {""} ;
         T001A83_n587PropostaPacientePIX = new bool[] {false} ;
         T001A83_A588PropostaPacienteDepositoTipo = new string[] {""} ;
         T001A83_n588PropostaPacienteDepositoTipo = new bool[] {false} ;
         T001A83_A620PropostaPacienteEnderecoCEP = new string[] {""} ;
         T001A83_n620PropostaPacienteEnderecoCEP = new bool[] {false} ;
         T001A83_A621PropostaPacienteEnderecoLogradouro = new string[] {""} ;
         T001A83_n621PropostaPacienteEnderecoLogradouro = new bool[] {false} ;
         T001A83_A622PropostaPacienteEnderecoNumero = new string[] {""} ;
         T001A83_n622PropostaPacienteEnderecoNumero = new bool[] {false} ;
         T001A83_A623PropostaPacienteEnderecoComplemento = new string[] {""} ;
         T001A83_n623PropostaPacienteEnderecoComplemento = new bool[] {false} ;
         T001A83_A624PropostaPacienteEnderecoBairro = new string[] {""} ;
         T001A83_n624PropostaPacienteEnderecoBairro = new bool[] {false} ;
         T001A83_A625PropostaPacienteMunicipioCodigo = new string[] {""} ;
         T001A83_n625PropostaPacienteMunicipioCodigo = new bool[] {false} ;
         T001A85_A733PropostaResponsavelSerasaConsultas_F = new short[1] ;
         T001A85_n733PropostaResponsavelSerasaConsultas_F = new bool[] {false} ;
         T001A85_A734PropostaPacienteSerasaConsultas_F = new short[1] ;
         T001A85_n734PropostaPacienteSerasaConsultas_F = new bool[] {false} ;
         T001A88_A783PropostaResponsavelSerasaScoreUltimaData_F = new short[1] ;
         T001A88_n783PropostaResponsavelSerasaScoreUltimaData_F = new bool[] {false} ;
         T001A88_A782PropostaSerasaScoreUltimaData_F = new short[1] ;
         T001A88_n782PropostaSerasaScoreUltimaData_F = new bool[] {false} ;
         T001A91_A786PropostaResponsavelSerasaUltimoValorRecomendado_F = new decimal[1] ;
         T001A91_n786PropostaResponsavelSerasaUltimoValorRecomendado_F = new bool[] {false} ;
         T001A91_A787PropostaPacienteSerasaUltimoValorRecomendado_F = new decimal[1] ;
         T001A91_n787PropostaPacienteSerasaUltimoValorRecomendado_F = new bool[] {false} ;
         T001A92_A580PropostaResponsavelDocumento = new string[] {""} ;
         T001A92_n580PropostaResponsavelDocumento = new bool[] {false} ;
         T001A92_A581PropostaResponsavelRazaoSocial = new string[] {""} ;
         T001A92_n581PropostaResponsavelRazaoSocial = new bool[] {false} ;
         T001A92_A582PropostaResponsavelEmail = new string[] {""} ;
         T001A92_n582PropostaResponsavelEmail = new bool[] {false} ;
         T001A92_A590PropostaResponsavelConta = new string[] {""} ;
         T001A92_n590PropostaResponsavelConta = new bool[] {false} ;
         T001A92_A591PropostaResponsavelAgencia = new string[] {""} ;
         T001A92_n591PropostaResponsavelAgencia = new bool[] {false} ;
         T001A92_A592PropostaResponsavelTipoPix = new string[] {""} ;
         T001A92_n592PropostaResponsavelTipoPix = new bool[] {false} ;
         T001A92_A593PropostaResponsavelPIX = new string[] {""} ;
         T001A92_n593PropostaResponsavelPIX = new bool[] {false} ;
         T001A92_A594PropostaResponsavelDepositoTipo = new string[] {""} ;
         T001A92_n594PropostaResponsavelDepositoTipo = new bool[] {false} ;
         T001A93_A643PropostaClinicaNome = new string[] {""} ;
         T001A93_n643PropostaClinicaNome = new bool[] {false} ;
         T001A93_A644PropostaClinicaNomeFantasia = new string[] {""} ;
         T001A93_n644PropostaClinicaNomeFantasia = new bool[] {false} ;
         T001A93_A652PropostaClinicaDocumento = new string[] {""} ;
         T001A93_n652PropostaClinicaDocumento = new bool[] {false} ;
         T001A93_A653PropostaClinicaEmail = new string[] {""} ;
         T001A93_n653PropostaClinicaEmail = new bool[] {false} ;
         T001A94_A850PropostaEmpresaClienteId = new int[1] ;
         T001A94_n850PropostaEmpresaClienteId = new bool[] {false} ;
         T001A95_A323PropostaId = new int[1] ;
         T001A95_n323PropostaId = new bool[] {false} ;
         T001A3_A323PropostaId = new int[1] ;
         T001A3_n323PropostaId = new bool[] {false} ;
         T001A3_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T001A3_n327PropostaCreatedAt = new bool[] {false} ;
         T001A3_A853PropostaProtocolo = new string[] {""} ;
         T001A3_n853PropostaProtocolo = new bool[] {false} ;
         T001A3_A849PropostaTipoProposta = new string[] {""} ;
         T001A3_n849PropostaTipoProposta = new bool[] {false} ;
         T001A3_A324PropostaTitulo = new string[] {""} ;
         T001A3_n324PropostaTitulo = new bool[] {false} ;
         T001A3_A325PropostaDescricao = new string[] {""} ;
         T001A3_n325PropostaDescricao = new bool[] {false} ;
         T001A3_A517PropostaDataCirurgia = new DateTime[] {DateTime.MinValue} ;
         T001A3_n517PropostaDataCirurgia = new bool[] {false} ;
         T001A3_A326PropostaValor = new decimal[1] ;
         T001A3_n326PropostaValor = new bool[] {false} ;
         T001A3_A855PropostaValorLiquido = new decimal[1] ;
         T001A3_n855PropostaValorLiquido = new bool[] {false} ;
         T001A3_A501PropostaTaxaAdministrativa = new decimal[1] ;
         T001A3_n501PropostaTaxaAdministrativa = new bool[] {false} ;
         T001A3_A507PropostaSLA = new short[1] ;
         T001A3_n507PropostaSLA = new bool[] {false} ;
         T001A3_A508PropostaJurosMora = new decimal[1] ;
         T001A3_n508PropostaJurosMora = new bool[] {false} ;
         T001A3_A329PropostaStatus = new string[] {""} ;
         T001A3_n329PropostaStatus = new bool[] {false} ;
         T001A3_A790PropostaComentarioAnalise = new string[] {""} ;
         T001A3_n790PropostaComentarioAnalise = new bool[] {false} ;
         T001A3_A330PropostaQuantidadeAprovadores = new short[1] ;
         T001A3_n330PropostaQuantidadeAprovadores = new bool[] {false} ;
         T001A3_A345PropostaReprovacoesPermitidas = new short[1] ;
         T001A3_n345PropostaReprovacoesPermitidas = new bool[] {false} ;
         T001A3_A496ConvenioVencimentoAno = new short[1] ;
         T001A3_n496ConvenioVencimentoAno = new bool[] {false} ;
         T001A3_A497ConvenioVencimentoMes = new short[1] ;
         T001A3_n497ConvenioVencimentoMes = new bool[] {false} ;
         T001A3_A227ContratoId = new int[1] ;
         T001A3_n227ContratoId = new bool[] {false} ;
         T001A3_A376ProcedimentosMedicosId = new int[1] ;
         T001A3_n376ProcedimentosMedicosId = new bool[] {false} ;
         T001A3_A493ConvenioCategoriaId = new int[1] ;
         T001A3_n493ConvenioCategoriaId = new bool[] {false} ;
         T001A3_A328PropostaCratedBy = new short[1] ;
         T001A3_n328PropostaCratedBy = new bool[] {false} ;
         T001A3_A504PropostaPacienteClienteId = new int[1] ;
         T001A3_n504PropostaPacienteClienteId = new bool[] {false} ;
         T001A3_A553PropostaResponsavelId = new int[1] ;
         T001A3_n553PropostaResponsavelId = new bool[] {false} ;
         T001A3_A642PropostaClinicaId = new int[1] ;
         T001A3_n642PropostaClinicaId = new bool[] {false} ;
         T001A3_A850PropostaEmpresaClienteId = new int[1] ;
         T001A3_n850PropostaEmpresaClienteId = new bool[] {false} ;
         T001A96_A323PropostaId = new int[1] ;
         T001A96_n323PropostaId = new bool[] {false} ;
         T001A97_A323PropostaId = new int[1] ;
         T001A97_n323PropostaId = new bool[] {false} ;
         T001A2_A323PropostaId = new int[1] ;
         T001A2_n323PropostaId = new bool[] {false} ;
         T001A2_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T001A2_n327PropostaCreatedAt = new bool[] {false} ;
         T001A2_A853PropostaProtocolo = new string[] {""} ;
         T001A2_n853PropostaProtocolo = new bool[] {false} ;
         T001A2_A849PropostaTipoProposta = new string[] {""} ;
         T001A2_n849PropostaTipoProposta = new bool[] {false} ;
         T001A2_A324PropostaTitulo = new string[] {""} ;
         T001A2_n324PropostaTitulo = new bool[] {false} ;
         T001A2_A325PropostaDescricao = new string[] {""} ;
         T001A2_n325PropostaDescricao = new bool[] {false} ;
         T001A2_A517PropostaDataCirurgia = new DateTime[] {DateTime.MinValue} ;
         T001A2_n517PropostaDataCirurgia = new bool[] {false} ;
         T001A2_A326PropostaValor = new decimal[1] ;
         T001A2_n326PropostaValor = new bool[] {false} ;
         T001A2_A855PropostaValorLiquido = new decimal[1] ;
         T001A2_n855PropostaValorLiquido = new bool[] {false} ;
         T001A2_A501PropostaTaxaAdministrativa = new decimal[1] ;
         T001A2_n501PropostaTaxaAdministrativa = new bool[] {false} ;
         T001A2_A507PropostaSLA = new short[1] ;
         T001A2_n507PropostaSLA = new bool[] {false} ;
         T001A2_A508PropostaJurosMora = new decimal[1] ;
         T001A2_n508PropostaJurosMora = new bool[] {false} ;
         T001A2_A329PropostaStatus = new string[] {""} ;
         T001A2_n329PropostaStatus = new bool[] {false} ;
         T001A2_A790PropostaComentarioAnalise = new string[] {""} ;
         T001A2_n790PropostaComentarioAnalise = new bool[] {false} ;
         T001A2_A330PropostaQuantidadeAprovadores = new short[1] ;
         T001A2_n330PropostaQuantidadeAprovadores = new bool[] {false} ;
         T001A2_A345PropostaReprovacoesPermitidas = new short[1] ;
         T001A2_n345PropostaReprovacoesPermitidas = new bool[] {false} ;
         T001A2_A496ConvenioVencimentoAno = new short[1] ;
         T001A2_n496ConvenioVencimentoAno = new bool[] {false} ;
         T001A2_A497ConvenioVencimentoMes = new short[1] ;
         T001A2_n497ConvenioVencimentoMes = new bool[] {false} ;
         T001A2_A227ContratoId = new int[1] ;
         T001A2_n227ContratoId = new bool[] {false} ;
         T001A2_A376ProcedimentosMedicosId = new int[1] ;
         T001A2_n376ProcedimentosMedicosId = new bool[] {false} ;
         T001A2_A493ConvenioCategoriaId = new int[1] ;
         T001A2_n493ConvenioCategoriaId = new bool[] {false} ;
         T001A2_A328PropostaCratedBy = new short[1] ;
         T001A2_n328PropostaCratedBy = new bool[] {false} ;
         T001A2_A504PropostaPacienteClienteId = new int[1] ;
         T001A2_n504PropostaPacienteClienteId = new bool[] {false} ;
         T001A2_A553PropostaResponsavelId = new int[1] ;
         T001A2_n553PropostaResponsavelId = new bool[] {false} ;
         T001A2_A642PropostaClinicaId = new int[1] ;
         T001A2_n642PropostaClinicaId = new bool[] {false} ;
         T001A2_A850PropostaEmpresaClienteId = new int[1] ;
         T001A2_n850PropostaEmpresaClienteId = new bool[] {false} ;
         T001A99_A323PropostaId = new int[1] ;
         T001A99_n323PropostaId = new bool[] {false} ;
         T001A103_A649PropostaMaxReembolsoId_F = new int[1] ;
         T001A103_n649PropostaMaxReembolsoId_F = new bool[] {false} ;
         T001A105_A854PropostaQtdItensNota_F = new short[1] ;
         T001A105_n854PropostaQtdItensNota_F = new bool[] {false} ;
         T001A107_A655PropostaQtdDocumentoPendente_F = new short[1] ;
         T001A107_n655PropostaQtdDocumentoPendente_F = new bool[] {false} ;
         T001A109_A341PropostaAprovacoes_F = new short[1] ;
         T001A109_n341PropostaAprovacoes_F = new bool[] {false} ;
         T001A111_A342PropostaReprovacoes_F = new short[1] ;
         T001A111_n342PropostaReprovacoes_F = new bool[] {false} ;
         T001A112_A512PropostaSecUserName = new string[] {""} ;
         T001A112_n512PropostaSecUserName = new bool[] {false} ;
         T001A115_A511PropostaValorTaxaRecebida_F = new decimal[1] ;
         T001A115_n511PropostaValorTaxaRecebida_F = new bool[] {false} ;
         T001A116_A228ContratoNome = new string[] {""} ;
         T001A116_n228ContratoNome = new bool[] {false} ;
         T001A117_A494ConvenioCategoriaDescricao = new string[] {""} ;
         T001A117_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         T001A117_A410ConvenioId = new int[1] ;
         T001A117_n410ConvenioId = new bool[] {false} ;
         T001A118_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         T001A118_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         T001A118_A540PropostaPacienteClienteDocumento = new string[] {""} ;
         T001A118_n540PropostaPacienteClienteDocumento = new bool[] {false} ;
         T001A118_A541PropostaPacienteContatoEmail = new string[] {""} ;
         T001A118_n541PropostaPacienteContatoEmail = new bool[] {false} ;
         T001A118_A584PropostaPacienteConta = new string[] {""} ;
         T001A118_n584PropostaPacienteConta = new bool[] {false} ;
         T001A118_A585PropostaPacienteAgencia = new string[] {""} ;
         T001A118_n585PropostaPacienteAgencia = new bool[] {false} ;
         T001A118_A586PropostaPacienteTipoPix = new string[] {""} ;
         T001A118_n586PropostaPacienteTipoPix = new bool[] {false} ;
         T001A118_A587PropostaPacientePIX = new string[] {""} ;
         T001A118_n587PropostaPacientePIX = new bool[] {false} ;
         T001A118_A588PropostaPacienteDepositoTipo = new string[] {""} ;
         T001A118_n588PropostaPacienteDepositoTipo = new bool[] {false} ;
         T001A118_A620PropostaPacienteEnderecoCEP = new string[] {""} ;
         T001A118_n620PropostaPacienteEnderecoCEP = new bool[] {false} ;
         T001A118_A621PropostaPacienteEnderecoLogradouro = new string[] {""} ;
         T001A118_n621PropostaPacienteEnderecoLogradouro = new bool[] {false} ;
         T001A118_A622PropostaPacienteEnderecoNumero = new string[] {""} ;
         T001A118_n622PropostaPacienteEnderecoNumero = new bool[] {false} ;
         T001A118_A623PropostaPacienteEnderecoComplemento = new string[] {""} ;
         T001A118_n623PropostaPacienteEnderecoComplemento = new bool[] {false} ;
         T001A118_A624PropostaPacienteEnderecoBairro = new string[] {""} ;
         T001A118_n624PropostaPacienteEnderecoBairro = new bool[] {false} ;
         T001A118_A625PropostaPacienteMunicipioCodigo = new string[] {""} ;
         T001A118_n625PropostaPacienteMunicipioCodigo = new bool[] {false} ;
         T001A121_A509PropostaValorReembolsado_F = new decimal[1] ;
         T001A121_n509PropostaValorReembolsado_F = new bool[] {false} ;
         T001A124_A510PropostaValorReembolsadoJuros_F = new decimal[1] ;
         T001A124_n510PropostaValorReembolsadoJuros_F = new bool[] {false} ;
         T001A127_A515PropostaDataCreditoCliente_F = new DateTime[] {DateTime.MinValue} ;
         T001A127_n515PropostaDataCreditoCliente_F = new bool[] {false} ;
         T001A129_A733PropostaResponsavelSerasaConsultas_F = new short[1] ;
         T001A129_n733PropostaResponsavelSerasaConsultas_F = new bool[] {false} ;
         T001A129_A734PropostaPacienteSerasaConsultas_F = new short[1] ;
         T001A129_n734PropostaPacienteSerasaConsultas_F = new bool[] {false} ;
         T001A132_A783PropostaResponsavelSerasaScoreUltimaData_F = new short[1] ;
         T001A132_n783PropostaResponsavelSerasaScoreUltimaData_F = new bool[] {false} ;
         T001A132_A782PropostaSerasaScoreUltimaData_F = new short[1] ;
         T001A132_n782PropostaSerasaScoreUltimaData_F = new bool[] {false} ;
         T001A135_A786PropostaResponsavelSerasaUltimoValorRecomendado_F = new decimal[1] ;
         T001A135_n786PropostaResponsavelSerasaUltimoValorRecomendado_F = new bool[] {false} ;
         T001A135_A787PropostaPacienteSerasaUltimoValorRecomendado_F = new decimal[1] ;
         T001A135_n787PropostaPacienteSerasaUltimoValorRecomendado_F = new bool[] {false} ;
         T001A136_A580PropostaResponsavelDocumento = new string[] {""} ;
         T001A136_n580PropostaResponsavelDocumento = new bool[] {false} ;
         T001A136_A581PropostaResponsavelRazaoSocial = new string[] {""} ;
         T001A136_n581PropostaResponsavelRazaoSocial = new bool[] {false} ;
         T001A136_A582PropostaResponsavelEmail = new string[] {""} ;
         T001A136_n582PropostaResponsavelEmail = new bool[] {false} ;
         T001A136_A590PropostaResponsavelConta = new string[] {""} ;
         T001A136_n590PropostaResponsavelConta = new bool[] {false} ;
         T001A136_A591PropostaResponsavelAgencia = new string[] {""} ;
         T001A136_n591PropostaResponsavelAgencia = new bool[] {false} ;
         T001A136_A592PropostaResponsavelTipoPix = new string[] {""} ;
         T001A136_n592PropostaResponsavelTipoPix = new bool[] {false} ;
         T001A136_A593PropostaResponsavelPIX = new string[] {""} ;
         T001A136_n593PropostaResponsavelPIX = new bool[] {false} ;
         T001A136_A594PropostaResponsavelDepositoTipo = new string[] {""} ;
         T001A136_n594PropostaResponsavelDepositoTipo = new bool[] {false} ;
         T001A137_A643PropostaClinicaNome = new string[] {""} ;
         T001A137_n643PropostaClinicaNome = new bool[] {false} ;
         T001A137_A644PropostaClinicaNomeFantasia = new string[] {""} ;
         T001A137_n644PropostaClinicaNomeFantasia = new bool[] {false} ;
         T001A137_A652PropostaClinicaDocumento = new string[] {""} ;
         T001A137_n652PropostaClinicaDocumento = new bool[] {false} ;
         T001A137_A653PropostaClinicaEmail = new string[] {""} ;
         T001A137_n653PropostaClinicaEmail = new bool[] {false} ;
         T001A139_A650PropostaValorTaxaClinica_F = new decimal[1] ;
         T001A139_n650PropostaValorTaxaClinica_F = new bool[] {false} ;
         T001A140_A227ContratoId = new int[1] ;
         T001A140_n227ContratoId = new bool[] {false} ;
         T001A141_A518ReembolsoId = new int[1] ;
         T001A142_A261TituloId = new int[1] ;
         T001A142_n261TituloId = new bool[] {false} ;
         T001A143_A830NotaFiscalItemId = new Guid[] {Guid.Empty} ;
         T001A144_A572PropostaContratoAssinaturaId = new int[1] ;
         T001A145_A414PropostaDocumentosId = new int[1] ;
         T001A146_A336AprovacaoId = new int[1] ;
         T001A147_A323PropostaId = new int[1] ;
         T001A147_n323PropostaId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         A589PropostaResponsavelBanco = "";
         A583PropostaPacienteBanco = "";
         i327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         T001A148_A376ProcedimentosMedicosId = new int[1] ;
         T001A148_n376ProcedimentosMedicosId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.proposta__default(),
            new Object[][] {
                new Object[] {
               T001A2_A323PropostaId, T001A2_A327PropostaCreatedAt, T001A2_n327PropostaCreatedAt, T001A2_A853PropostaProtocolo, T001A2_n853PropostaProtocolo, T001A2_A849PropostaTipoProposta, T001A2_n849PropostaTipoProposta, T001A2_A324PropostaTitulo, T001A2_n324PropostaTitulo, T001A2_A325PropostaDescricao,
               T001A2_n325PropostaDescricao, T001A2_A517PropostaDataCirurgia, T001A2_n517PropostaDataCirurgia, T001A2_A326PropostaValor, T001A2_n326PropostaValor, T001A2_A855PropostaValorLiquido, T001A2_n855PropostaValorLiquido, T001A2_A501PropostaTaxaAdministrativa, T001A2_n501PropostaTaxaAdministrativa, T001A2_A507PropostaSLA,
               T001A2_n507PropostaSLA, T001A2_A508PropostaJurosMora, T001A2_n508PropostaJurosMora, T001A2_A329PropostaStatus, T001A2_n329PropostaStatus, T001A2_A790PropostaComentarioAnalise, T001A2_n790PropostaComentarioAnalise, T001A2_A330PropostaQuantidadeAprovadores, T001A2_n330PropostaQuantidadeAprovadores, T001A2_A345PropostaReprovacoesPermitidas,
               T001A2_n345PropostaReprovacoesPermitidas, T001A2_A496ConvenioVencimentoAno, T001A2_n496ConvenioVencimentoAno, T001A2_A497ConvenioVencimentoMes, T001A2_n497ConvenioVencimentoMes, T001A2_A227ContratoId, T001A2_n227ContratoId, T001A2_A376ProcedimentosMedicosId, T001A2_n376ProcedimentosMedicosId, T001A2_A493ConvenioCategoriaId,
               T001A2_n493ConvenioCategoriaId, T001A2_A328PropostaCratedBy, T001A2_n328PropostaCratedBy, T001A2_A504PropostaPacienteClienteId, T001A2_n504PropostaPacienteClienteId, T001A2_A553PropostaResponsavelId, T001A2_n553PropostaResponsavelId, T001A2_A642PropostaClinicaId, T001A2_n642PropostaClinicaId, T001A2_A850PropostaEmpresaClienteId,
               T001A2_n850PropostaEmpresaClienteId
               }
               , new Object[] {
               T001A3_A323PropostaId, T001A3_A327PropostaCreatedAt, T001A3_n327PropostaCreatedAt, T001A3_A853PropostaProtocolo, T001A3_n853PropostaProtocolo, T001A3_A849PropostaTipoProposta, T001A3_n849PropostaTipoProposta, T001A3_A324PropostaTitulo, T001A3_n324PropostaTitulo, T001A3_A325PropostaDescricao,
               T001A3_n325PropostaDescricao, T001A3_A517PropostaDataCirurgia, T001A3_n517PropostaDataCirurgia, T001A3_A326PropostaValor, T001A3_n326PropostaValor, T001A3_A855PropostaValorLiquido, T001A3_n855PropostaValorLiquido, T001A3_A501PropostaTaxaAdministrativa, T001A3_n501PropostaTaxaAdministrativa, T001A3_A507PropostaSLA,
               T001A3_n507PropostaSLA, T001A3_A508PropostaJurosMora, T001A3_n508PropostaJurosMora, T001A3_A329PropostaStatus, T001A3_n329PropostaStatus, T001A3_A790PropostaComentarioAnalise, T001A3_n790PropostaComentarioAnalise, T001A3_A330PropostaQuantidadeAprovadores, T001A3_n330PropostaQuantidadeAprovadores, T001A3_A345PropostaReprovacoesPermitidas,
               T001A3_n345PropostaReprovacoesPermitidas, T001A3_A496ConvenioVencimentoAno, T001A3_n496ConvenioVencimentoAno, T001A3_A497ConvenioVencimentoMes, T001A3_n497ConvenioVencimentoMes, T001A3_A227ContratoId, T001A3_n227ContratoId, T001A3_A376ProcedimentosMedicosId, T001A3_n376ProcedimentosMedicosId, T001A3_A493ConvenioCategoriaId,
               T001A3_n493ConvenioCategoriaId, T001A3_A328PropostaCratedBy, T001A3_n328PropostaCratedBy, T001A3_A504PropostaPacienteClienteId, T001A3_n504PropostaPacienteClienteId, T001A3_A553PropostaResponsavelId, T001A3_n553PropostaResponsavelId, T001A3_A642PropostaClinicaId, T001A3_n642PropostaClinicaId, T001A3_A850PropostaEmpresaClienteId,
               T001A3_n850PropostaEmpresaClienteId
               }
               , new Object[] {
               T001A4_A228ContratoNome, T001A4_n228ContratoNome
               }
               , new Object[] {
               T001A5_A376ProcedimentosMedicosId
               }
               , new Object[] {
               T001A6_A494ConvenioCategoriaDescricao, T001A6_n494ConvenioCategoriaDescricao, T001A6_A410ConvenioId, T001A6_n410ConvenioId
               }
               , new Object[] {
               T001A7_A512PropostaSecUserName, T001A7_n512PropostaSecUserName
               }
               , new Object[] {
               T001A8_A505PropostaPacienteClienteRazaoSocial, T001A8_n505PropostaPacienteClienteRazaoSocial, T001A8_A540PropostaPacienteClienteDocumento, T001A8_n540PropostaPacienteClienteDocumento, T001A8_A541PropostaPacienteContatoEmail, T001A8_n541PropostaPacienteContatoEmail, T001A8_A584PropostaPacienteConta, T001A8_n584PropostaPacienteConta, T001A8_A585PropostaPacienteAgencia, T001A8_n585PropostaPacienteAgencia,
               T001A8_A586PropostaPacienteTipoPix, T001A8_n586PropostaPacienteTipoPix, T001A8_A587PropostaPacientePIX, T001A8_n587PropostaPacientePIX, T001A8_A588PropostaPacienteDepositoTipo, T001A8_n588PropostaPacienteDepositoTipo, T001A8_A620PropostaPacienteEnderecoCEP, T001A8_n620PropostaPacienteEnderecoCEP, T001A8_A621PropostaPacienteEnderecoLogradouro, T001A8_n621PropostaPacienteEnderecoLogradouro,
               T001A8_A622PropostaPacienteEnderecoNumero, T001A8_n622PropostaPacienteEnderecoNumero, T001A8_A623PropostaPacienteEnderecoComplemento, T001A8_n623PropostaPacienteEnderecoComplemento, T001A8_A624PropostaPacienteEnderecoBairro, T001A8_n624PropostaPacienteEnderecoBairro, T001A8_A625PropostaPacienteMunicipioCodigo, T001A8_n625PropostaPacienteMunicipioCodigo
               }
               , new Object[] {
               T001A9_A580PropostaResponsavelDocumento, T001A9_n580PropostaResponsavelDocumento, T001A9_A581PropostaResponsavelRazaoSocial, T001A9_n581PropostaResponsavelRazaoSocial, T001A9_A582PropostaResponsavelEmail, T001A9_n582PropostaResponsavelEmail, T001A9_A590PropostaResponsavelConta, T001A9_n590PropostaResponsavelConta, T001A9_A591PropostaResponsavelAgencia, T001A9_n591PropostaResponsavelAgencia,
               T001A9_A592PropostaResponsavelTipoPix, T001A9_n592PropostaResponsavelTipoPix, T001A9_A593PropostaResponsavelPIX, T001A9_n593PropostaResponsavelPIX, T001A9_A594PropostaResponsavelDepositoTipo, T001A9_n594PropostaResponsavelDepositoTipo
               }
               , new Object[] {
               T001A10_A643PropostaClinicaNome, T001A10_n643PropostaClinicaNome, T001A10_A644PropostaClinicaNomeFantasia, T001A10_n644PropostaClinicaNomeFantasia, T001A10_A652PropostaClinicaDocumento, T001A10_n652PropostaClinicaDocumento, T001A10_A653PropostaClinicaEmail, T001A10_n653PropostaClinicaEmail
               }
               , new Object[] {
               T001A11_A850PropostaEmpresaClienteId
               }
               , new Object[] {
               T001A14_A509PropostaValorReembolsado_F, T001A14_n509PropostaValorReembolsado_F
               }
               , new Object[] {
               T001A17_A510PropostaValorReembolsadoJuros_F, T001A17_n510PropostaValorReembolsadoJuros_F
               }
               , new Object[] {
               T001A20_A511PropostaValorTaxaRecebida_F, T001A20_n511PropostaValorTaxaRecebida_F
               }
               , new Object[] {
               T001A23_A515PropostaDataCreditoCliente_F, T001A23_n515PropostaDataCreditoCliente_F
               }
               , new Object[] {
               T001A25_A650PropostaValorTaxaClinica_F, T001A25_n650PropostaValorTaxaClinica_F
               }
               , new Object[] {
               T001A27_A649PropostaMaxReembolsoId_F, T001A27_n649PropostaMaxReembolsoId_F
               }
               , new Object[] {
               T001A29_A854PropostaQtdItensNota_F, T001A29_n854PropostaQtdItensNota_F
               }
               , new Object[] {
               T001A31_A733PropostaResponsavelSerasaConsultas_F, T001A31_n733PropostaResponsavelSerasaConsultas_F, T001A31_A734PropostaPacienteSerasaConsultas_F, T001A31_n734PropostaPacienteSerasaConsultas_F
               }
               , new Object[] {
               T001A34_A783PropostaResponsavelSerasaScoreUltimaData_F, T001A34_n783PropostaResponsavelSerasaScoreUltimaData_F, T001A34_A782PropostaSerasaScoreUltimaData_F, T001A34_n782PropostaSerasaScoreUltimaData_F
               }
               , new Object[] {
               T001A37_A786PropostaResponsavelSerasaUltimoValorRecomendado_F, T001A37_n786PropostaResponsavelSerasaUltimoValorRecomendado_F, T001A37_A787PropostaPacienteSerasaUltimoValorRecomendado_F, T001A37_n787PropostaPacienteSerasaUltimoValorRecomendado_F
               }
               , new Object[] {
               T001A39_A655PropostaQtdDocumentoPendente_F, T001A39_n655PropostaQtdDocumentoPendente_F
               }
               , new Object[] {
               T001A41_A341PropostaAprovacoes_F, T001A41_n341PropostaAprovacoes_F
               }
               , new Object[] {
               T001A43_A342PropostaReprovacoes_F, T001A43_n342PropostaReprovacoes_F
               }
               , new Object[] {
               T001A54_A323PropostaId, T001A54_A327PropostaCreatedAt, T001A54_n327PropostaCreatedAt, T001A54_A853PropostaProtocolo, T001A54_n853PropostaProtocolo, T001A54_A849PropostaTipoProposta, T001A54_n849PropostaTipoProposta, T001A54_A580PropostaResponsavelDocumento, T001A54_n580PropostaResponsavelDocumento, T001A54_A581PropostaResponsavelRazaoSocial,
               T001A54_n581PropostaResponsavelRazaoSocial, T001A54_A582PropostaResponsavelEmail, T001A54_n582PropostaResponsavelEmail, T001A54_A590PropostaResponsavelConta, T001A54_n590PropostaResponsavelConta, T001A54_A591PropostaResponsavelAgencia, T001A54_n591PropostaResponsavelAgencia, T001A54_A592PropostaResponsavelTipoPix, T001A54_n592PropostaResponsavelTipoPix, T001A54_A593PropostaResponsavelPIX,
               T001A54_n593PropostaResponsavelPIX, T001A54_A594PropostaResponsavelDepositoTipo, T001A54_n594PropostaResponsavelDepositoTipo, T001A54_A505PropostaPacienteClienteRazaoSocial, T001A54_n505PropostaPacienteClienteRazaoSocial, T001A54_A540PropostaPacienteClienteDocumento, T001A54_n540PropostaPacienteClienteDocumento, T001A54_A541PropostaPacienteContatoEmail, T001A54_n541PropostaPacienteContatoEmail, T001A54_A584PropostaPacienteConta,
               T001A54_n584PropostaPacienteConta, T001A54_A585PropostaPacienteAgencia, T001A54_n585PropostaPacienteAgencia, T001A54_A586PropostaPacienteTipoPix, T001A54_n586PropostaPacienteTipoPix, T001A54_A587PropostaPacientePIX, T001A54_n587PropostaPacientePIX, T001A54_A588PropostaPacienteDepositoTipo, T001A54_n588PropostaPacienteDepositoTipo, T001A54_A620PropostaPacienteEnderecoCEP,
               T001A54_n620PropostaPacienteEnderecoCEP, T001A54_A621PropostaPacienteEnderecoLogradouro, T001A54_n621PropostaPacienteEnderecoLogradouro, T001A54_A622PropostaPacienteEnderecoNumero, T001A54_n622PropostaPacienteEnderecoNumero, T001A54_A623PropostaPacienteEnderecoComplemento, T001A54_n623PropostaPacienteEnderecoComplemento, T001A54_A624PropostaPacienteEnderecoBairro, T001A54_n624PropostaPacienteEnderecoBairro, T001A54_A324PropostaTitulo,
               T001A54_n324PropostaTitulo, T001A54_A325PropostaDescricao, T001A54_n325PropostaDescricao, T001A54_A517PropostaDataCirurgia, T001A54_n517PropostaDataCirurgia, T001A54_A326PropostaValor, T001A54_n326PropostaValor, T001A54_A855PropostaValorLiquido, T001A54_n855PropostaValorLiquido, T001A54_A501PropostaTaxaAdministrativa,
               T001A54_n501PropostaTaxaAdministrativa, T001A54_A507PropostaSLA, T001A54_n507PropostaSLA, T001A54_A508PropostaJurosMora, T001A54_n508PropostaJurosMora, T001A54_A643PropostaClinicaNome, T001A54_n643PropostaClinicaNome, T001A54_A644PropostaClinicaNomeFantasia, T001A54_n644PropostaClinicaNomeFantasia, T001A54_A652PropostaClinicaDocumento,
               T001A54_n652PropostaClinicaDocumento, T001A54_A653PropostaClinicaEmail, T001A54_n653PropostaClinicaEmail, T001A54_A512PropostaSecUserName, T001A54_n512PropostaSecUserName, T001A54_A329PropostaStatus, T001A54_n329PropostaStatus, T001A54_A790PropostaComentarioAnalise, T001A54_n790PropostaComentarioAnalise, T001A54_A330PropostaQuantidadeAprovadores,
               T001A54_n330PropostaQuantidadeAprovadores, T001A54_A345PropostaReprovacoesPermitidas, T001A54_n345PropostaReprovacoesPermitidas, T001A54_A228ContratoNome, T001A54_n228ContratoNome, T001A54_A496ConvenioVencimentoAno, T001A54_n496ConvenioVencimentoAno, T001A54_A497ConvenioVencimentoMes, T001A54_n497ConvenioVencimentoMes, T001A54_A494ConvenioCategoriaDescricao,
               T001A54_n494ConvenioCategoriaDescricao, T001A54_A227ContratoId, T001A54_n227ContratoId, T001A54_A376ProcedimentosMedicosId, T001A54_n376ProcedimentosMedicosId, T001A54_A493ConvenioCategoriaId, T001A54_n493ConvenioCategoriaId, T001A54_A328PropostaCratedBy, T001A54_n328PropostaCratedBy, T001A54_A504PropostaPacienteClienteId,
               T001A54_n504PropostaPacienteClienteId, T001A54_A553PropostaResponsavelId, T001A54_n553PropostaResponsavelId, T001A54_A642PropostaClinicaId, T001A54_n642PropostaClinicaId, T001A54_A850PropostaEmpresaClienteId, T001A54_n850PropostaEmpresaClienteId, T001A54_A410ConvenioId, T001A54_n410ConvenioId, T001A54_A625PropostaPacienteMunicipioCodigo,
               T001A54_n625PropostaPacienteMunicipioCodigo, T001A54_A649PropostaMaxReembolsoId_F, T001A54_n649PropostaMaxReembolsoId_F, T001A54_A854PropostaQtdItensNota_F, T001A54_n854PropostaQtdItensNota_F, T001A54_A733PropostaResponsavelSerasaConsultas_F, T001A54_n733PropostaResponsavelSerasaConsultas_F, T001A54_A783PropostaResponsavelSerasaScoreUltimaData_F, T001A54_n783PropostaResponsavelSerasaScoreUltimaData_F, T001A54_A786PropostaResponsavelSerasaUltimoValorRecomendado_F,
               T001A54_n786PropostaResponsavelSerasaUltimoValorRecomendado_F, T001A54_A734PropostaPacienteSerasaConsultas_F, T001A54_n734PropostaPacienteSerasaConsultas_F, T001A54_A782PropostaSerasaScoreUltimaData_F, T001A54_n782PropostaSerasaScoreUltimaData_F, T001A54_A787PropostaPacienteSerasaUltimoValorRecomendado_F, T001A54_n787PropostaPacienteSerasaUltimoValorRecomendado_F, T001A54_A655PropostaQtdDocumentoPendente_F, T001A54_n655PropostaQtdDocumentoPendente_F, T001A54_A341PropostaAprovacoes_F,
               T001A54_n341PropostaAprovacoes_F, T001A54_A342PropostaReprovacoes_F, T001A54_n342PropostaReprovacoes_F
               }
               , new Object[] {
               T001A57_A509PropostaValorReembolsado_F, T001A57_n509PropostaValorReembolsado_F
               }
               , new Object[] {
               T001A60_A510PropostaValorReembolsadoJuros_F, T001A60_n510PropostaValorReembolsadoJuros_F
               }
               , new Object[] {
               T001A63_A511PropostaValorTaxaRecebida_F, T001A63_n511PropostaValorTaxaRecebida_F
               }
               , new Object[] {
               T001A66_A515PropostaDataCreditoCliente_F, T001A66_n515PropostaDataCreditoCliente_F
               }
               , new Object[] {
               T001A68_A650PropostaValorTaxaClinica_F, T001A68_n650PropostaValorTaxaClinica_F
               }
               , new Object[] {
               T001A70_A649PropostaMaxReembolsoId_F, T001A70_n649PropostaMaxReembolsoId_F
               }
               , new Object[] {
               T001A72_A854PropostaQtdItensNota_F, T001A72_n854PropostaQtdItensNota_F
               }
               , new Object[] {
               T001A74_A655PropostaQtdDocumentoPendente_F, T001A74_n655PropostaQtdDocumentoPendente_F
               }
               , new Object[] {
               T001A76_A341PropostaAprovacoes_F, T001A76_n341PropostaAprovacoes_F
               }
               , new Object[] {
               T001A78_A342PropostaReprovacoes_F, T001A78_n342PropostaReprovacoes_F
               }
               , new Object[] {
               T001A79_A376ProcedimentosMedicosId
               }
               , new Object[] {
               T001A80_A512PropostaSecUserName, T001A80_n512PropostaSecUserName
               }
               , new Object[] {
               T001A81_A228ContratoNome, T001A81_n228ContratoNome
               }
               , new Object[] {
               T001A82_A494ConvenioCategoriaDescricao, T001A82_n494ConvenioCategoriaDescricao, T001A82_A410ConvenioId, T001A82_n410ConvenioId
               }
               , new Object[] {
               T001A83_A505PropostaPacienteClienteRazaoSocial, T001A83_n505PropostaPacienteClienteRazaoSocial, T001A83_A540PropostaPacienteClienteDocumento, T001A83_n540PropostaPacienteClienteDocumento, T001A83_A541PropostaPacienteContatoEmail, T001A83_n541PropostaPacienteContatoEmail, T001A83_A584PropostaPacienteConta, T001A83_n584PropostaPacienteConta, T001A83_A585PropostaPacienteAgencia, T001A83_n585PropostaPacienteAgencia,
               T001A83_A586PropostaPacienteTipoPix, T001A83_n586PropostaPacienteTipoPix, T001A83_A587PropostaPacientePIX, T001A83_n587PropostaPacientePIX, T001A83_A588PropostaPacienteDepositoTipo, T001A83_n588PropostaPacienteDepositoTipo, T001A83_A620PropostaPacienteEnderecoCEP, T001A83_n620PropostaPacienteEnderecoCEP, T001A83_A621PropostaPacienteEnderecoLogradouro, T001A83_n621PropostaPacienteEnderecoLogradouro,
               T001A83_A622PropostaPacienteEnderecoNumero, T001A83_n622PropostaPacienteEnderecoNumero, T001A83_A623PropostaPacienteEnderecoComplemento, T001A83_n623PropostaPacienteEnderecoComplemento, T001A83_A624PropostaPacienteEnderecoBairro, T001A83_n624PropostaPacienteEnderecoBairro, T001A83_A625PropostaPacienteMunicipioCodigo, T001A83_n625PropostaPacienteMunicipioCodigo
               }
               , new Object[] {
               T001A85_A733PropostaResponsavelSerasaConsultas_F, T001A85_n733PropostaResponsavelSerasaConsultas_F, T001A85_A734PropostaPacienteSerasaConsultas_F, T001A85_n734PropostaPacienteSerasaConsultas_F
               }
               , new Object[] {
               T001A88_A783PropostaResponsavelSerasaScoreUltimaData_F, T001A88_n783PropostaResponsavelSerasaScoreUltimaData_F, T001A88_A782PropostaSerasaScoreUltimaData_F, T001A88_n782PropostaSerasaScoreUltimaData_F
               }
               , new Object[] {
               T001A91_A786PropostaResponsavelSerasaUltimoValorRecomendado_F, T001A91_n786PropostaResponsavelSerasaUltimoValorRecomendado_F, T001A91_A787PropostaPacienteSerasaUltimoValorRecomendado_F, T001A91_n787PropostaPacienteSerasaUltimoValorRecomendado_F
               }
               , new Object[] {
               T001A92_A580PropostaResponsavelDocumento, T001A92_n580PropostaResponsavelDocumento, T001A92_A581PropostaResponsavelRazaoSocial, T001A92_n581PropostaResponsavelRazaoSocial, T001A92_A582PropostaResponsavelEmail, T001A92_n582PropostaResponsavelEmail, T001A92_A590PropostaResponsavelConta, T001A92_n590PropostaResponsavelConta, T001A92_A591PropostaResponsavelAgencia, T001A92_n591PropostaResponsavelAgencia,
               T001A92_A592PropostaResponsavelTipoPix, T001A92_n592PropostaResponsavelTipoPix, T001A92_A593PropostaResponsavelPIX, T001A92_n593PropostaResponsavelPIX, T001A92_A594PropostaResponsavelDepositoTipo, T001A92_n594PropostaResponsavelDepositoTipo
               }
               , new Object[] {
               T001A93_A643PropostaClinicaNome, T001A93_n643PropostaClinicaNome, T001A93_A644PropostaClinicaNomeFantasia, T001A93_n644PropostaClinicaNomeFantasia, T001A93_A652PropostaClinicaDocumento, T001A93_n652PropostaClinicaDocumento, T001A93_A653PropostaClinicaEmail, T001A93_n653PropostaClinicaEmail
               }
               , new Object[] {
               T001A94_A850PropostaEmpresaClienteId
               }
               , new Object[] {
               T001A95_A323PropostaId
               }
               , new Object[] {
               T001A96_A323PropostaId
               }
               , new Object[] {
               T001A97_A323PropostaId
               }
               , new Object[] {
               }
               , new Object[] {
               T001A99_A323PropostaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001A103_A649PropostaMaxReembolsoId_F, T001A103_n649PropostaMaxReembolsoId_F
               }
               , new Object[] {
               T001A105_A854PropostaQtdItensNota_F, T001A105_n854PropostaQtdItensNota_F
               }
               , new Object[] {
               T001A107_A655PropostaQtdDocumentoPendente_F, T001A107_n655PropostaQtdDocumentoPendente_F
               }
               , new Object[] {
               T001A109_A341PropostaAprovacoes_F, T001A109_n341PropostaAprovacoes_F
               }
               , new Object[] {
               T001A111_A342PropostaReprovacoes_F, T001A111_n342PropostaReprovacoes_F
               }
               , new Object[] {
               T001A112_A512PropostaSecUserName, T001A112_n512PropostaSecUserName
               }
               , new Object[] {
               T001A115_A511PropostaValorTaxaRecebida_F, T001A115_n511PropostaValorTaxaRecebida_F
               }
               , new Object[] {
               T001A116_A228ContratoNome, T001A116_n228ContratoNome
               }
               , new Object[] {
               T001A117_A494ConvenioCategoriaDescricao, T001A117_n494ConvenioCategoriaDescricao, T001A117_A410ConvenioId, T001A117_n410ConvenioId
               }
               , new Object[] {
               T001A118_A505PropostaPacienteClienteRazaoSocial, T001A118_n505PropostaPacienteClienteRazaoSocial, T001A118_A540PropostaPacienteClienteDocumento, T001A118_n540PropostaPacienteClienteDocumento, T001A118_A541PropostaPacienteContatoEmail, T001A118_n541PropostaPacienteContatoEmail, T001A118_A584PropostaPacienteConta, T001A118_n584PropostaPacienteConta, T001A118_A585PropostaPacienteAgencia, T001A118_n585PropostaPacienteAgencia,
               T001A118_A586PropostaPacienteTipoPix, T001A118_n586PropostaPacienteTipoPix, T001A118_A587PropostaPacientePIX, T001A118_n587PropostaPacientePIX, T001A118_A588PropostaPacienteDepositoTipo, T001A118_n588PropostaPacienteDepositoTipo, T001A118_A620PropostaPacienteEnderecoCEP, T001A118_n620PropostaPacienteEnderecoCEP, T001A118_A621PropostaPacienteEnderecoLogradouro, T001A118_n621PropostaPacienteEnderecoLogradouro,
               T001A118_A622PropostaPacienteEnderecoNumero, T001A118_n622PropostaPacienteEnderecoNumero, T001A118_A623PropostaPacienteEnderecoComplemento, T001A118_n623PropostaPacienteEnderecoComplemento, T001A118_A624PropostaPacienteEnderecoBairro, T001A118_n624PropostaPacienteEnderecoBairro, T001A118_A625PropostaPacienteMunicipioCodigo, T001A118_n625PropostaPacienteMunicipioCodigo
               }
               , new Object[] {
               T001A121_A509PropostaValorReembolsado_F, T001A121_n509PropostaValorReembolsado_F
               }
               , new Object[] {
               T001A124_A510PropostaValorReembolsadoJuros_F, T001A124_n510PropostaValorReembolsadoJuros_F
               }
               , new Object[] {
               T001A127_A515PropostaDataCreditoCliente_F, T001A127_n515PropostaDataCreditoCliente_F
               }
               , new Object[] {
               T001A129_A733PropostaResponsavelSerasaConsultas_F, T001A129_n733PropostaResponsavelSerasaConsultas_F, T001A129_A734PropostaPacienteSerasaConsultas_F, T001A129_n734PropostaPacienteSerasaConsultas_F
               }
               , new Object[] {
               T001A132_A783PropostaResponsavelSerasaScoreUltimaData_F, T001A132_n783PropostaResponsavelSerasaScoreUltimaData_F, T001A132_A782PropostaSerasaScoreUltimaData_F, T001A132_n782PropostaSerasaScoreUltimaData_F
               }
               , new Object[] {
               T001A135_A786PropostaResponsavelSerasaUltimoValorRecomendado_F, T001A135_n786PropostaResponsavelSerasaUltimoValorRecomendado_F, T001A135_A787PropostaPacienteSerasaUltimoValorRecomendado_F, T001A135_n787PropostaPacienteSerasaUltimoValorRecomendado_F
               }
               , new Object[] {
               T001A136_A580PropostaResponsavelDocumento, T001A136_n580PropostaResponsavelDocumento, T001A136_A581PropostaResponsavelRazaoSocial, T001A136_n581PropostaResponsavelRazaoSocial, T001A136_A582PropostaResponsavelEmail, T001A136_n582PropostaResponsavelEmail, T001A136_A590PropostaResponsavelConta, T001A136_n590PropostaResponsavelConta, T001A136_A591PropostaResponsavelAgencia, T001A136_n591PropostaResponsavelAgencia,
               T001A136_A592PropostaResponsavelTipoPix, T001A136_n592PropostaResponsavelTipoPix, T001A136_A593PropostaResponsavelPIX, T001A136_n593PropostaResponsavelPIX, T001A136_A594PropostaResponsavelDepositoTipo, T001A136_n594PropostaResponsavelDepositoTipo
               }
               , new Object[] {
               T001A137_A643PropostaClinicaNome, T001A137_n643PropostaClinicaNome, T001A137_A644PropostaClinicaNomeFantasia, T001A137_n644PropostaClinicaNomeFantasia, T001A137_A652PropostaClinicaDocumento, T001A137_n652PropostaClinicaDocumento, T001A137_A653PropostaClinicaEmail, T001A137_n653PropostaClinicaEmail
               }
               , new Object[] {
               T001A139_A650PropostaValorTaxaClinica_F, T001A139_n650PropostaValorTaxaClinica_F
               }
               , new Object[] {
               T001A140_A227ContratoId
               }
               , new Object[] {
               T001A141_A518ReembolsoId
               }
               , new Object[] {
               T001A142_A261TituloId
               }
               , new Object[] {
               T001A143_A830NotaFiscalItemId
               }
               , new Object[] {
               T001A144_A572PropostaContratoAssinaturaId
               }
               , new Object[] {
               T001A145_A414PropostaDocumentosId
               }
               , new Object[] {
               T001A146_A336AprovacaoId
               }
               , new Object[] {
               T001A147_A323PropostaId
               }
               , new Object[] {
               T001A148_A376ProcedimentosMedicosId
               }
            }
         );
         AV36Pgmname = "Proposta";
      }

      private short Z507PropostaSLA ;
      private short Z330PropostaQuantidadeAprovadores ;
      private short Z345PropostaReprovacoesPermitidas ;
      private short Z496ConvenioVencimentoAno ;
      private short Z497ConvenioVencimentoMes ;
      private short Z328PropostaCratedBy ;
      private short N328PropostaCratedBy ;
      private short GxWebError ;
      private short A507PropostaSLA ;
      private short A328PropostaCratedBy ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A330PropostaQuantidadeAprovadores ;
      private short A345PropostaReprovacoesPermitidas ;
      private short A341PropostaAprovacoes_F ;
      private short A342PropostaReprovacoes_F ;
      private short A343PropostaAprovacoesRestantes_F ;
      private short AV19ComboPropostaCratedBy ;
      private short A496ConvenioVencimentoAno ;
      private short A497ConvenioVencimentoMes ;
      private short A782PropostaSerasaScoreUltimaData_F ;
      private short A783PropostaResponsavelSerasaScoreUltimaData_F ;
      private short A784PropostaMaiorScore_F ;
      private short AV11Insert_PropostaCratedBy ;
      private short A854PropostaQtdItensNota_F ;
      private short A733PropostaResponsavelSerasaConsultas_F ;
      private short A734PropostaPacienteSerasaConsultas_F ;
      private short A655PropostaQtdDocumentoPendente_F ;
      private short RcdFound49 ;
      private short Z733PropostaResponsavelSerasaConsultas_F ;
      private short Z734PropostaPacienteSerasaConsultas_F ;
      private short Z783PropostaResponsavelSerasaScoreUltimaData_F ;
      private short Z782PropostaSerasaScoreUltimaData_F ;
      private short Z854PropostaQtdItensNota_F ;
      private short Z655PropostaQtdDocumentoPendente_F ;
      private short Z341PropostaAprovacoes_F ;
      private short Z342PropostaReprovacoes_F ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7PropostaId ;
      private int Z323PropostaId ;
      private int Z227ContratoId ;
      private int Z376ProcedimentosMedicosId ;
      private int Z493ConvenioCategoriaId ;
      private int Z504PropostaPacienteClienteId ;
      private int Z553PropostaResponsavelId ;
      private int Z642PropostaClinicaId ;
      private int Z850PropostaEmpresaClienteId ;
      private int N850PropostaEmpresaClienteId ;
      private int N504PropostaPacienteClienteId ;
      private int N553PropostaResponsavelId ;
      private int N376ProcedimentosMedicosId ;
      private int N642PropostaClinicaId ;
      private int N227ContratoId ;
      private int N493ConvenioCategoriaId ;
      private int A323PropostaId ;
      private int A504PropostaPacienteClienteId ;
      private int A642PropostaClinicaId ;
      private int A376ProcedimentosMedicosId ;
      private int A227ContratoId ;
      private int A493ConvenioCategoriaId ;
      private int A553PropostaResponsavelId ;
      private int A850PropostaEmpresaClienteId ;
      private int AV7PropostaId ;
      private int trnEnded ;
      private int edtPropostaTitulo_Enabled ;
      private int edtPropostaDescricao_Enabled ;
      private int edtPropostaValor_Enabled ;
      private int edtPropostaCreatedAt_Enabled ;
      private int edtPropostaCratedBy_Visible ;
      private int edtPropostaCratedBy_Enabled ;
      private int edtPropostaQuantidadeAprovadores_Enabled ;
      private int edtProcedimentosMedicosId_Visible ;
      private int edtProcedimentosMedicosId_Enabled ;
      private int edtPropostaReprovacoesPermitidas_Enabled ;
      private int edtPropostaAprovacoes_F_Enabled ;
      private int edtPropostaReprovacoes_F_Enabled ;
      private int edtPropostaAprovacoesRestantes_F_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavCombopropostacratedby_Enabled ;
      private int edtavCombopropostacratedby_Visible ;
      private int AV28ComboProcedimentosMedicosId ;
      private int edtavComboprocedimentosmedicosid_Enabled ;
      private int edtavComboprocedimentosmedicosid_Visible ;
      private int edtPropostaId_Enabled ;
      private int edtPropostaId_Visible ;
      private int AV35Insert_PropostaEmpresaClienteId ;
      private int AV32Insert_PropostaPacienteClienteId ;
      private int AV33Insert_PropostaResponsavelId ;
      private int AV24Insert_ProcedimentosMedicosId ;
      private int AV34Insert_PropostaClinicaId ;
      private int AV12Insert_ContratoId ;
      private int AV31Insert_ConvenioCategoriaId ;
      private int A410ConvenioId ;
      private int A649PropostaMaxReembolsoId_F ;
      private int Combo_propostacratedby_Datalistupdateminimumcharacters ;
      private int Combo_propostacratedby_Gxcontroltype ;
      private int Combo_procedimentosmedicosid_Datalistupdateminimumcharacters ;
      private int Combo_procedimentosmedicosid_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV37GXV1 ;
      private int Z410ConvenioId ;
      private int Z649PropostaMaxReembolsoId_F ;
      private int idxLst ;
      private decimal Z326PropostaValor ;
      private decimal Z855PropostaValorLiquido ;
      private decimal Z501PropostaTaxaAdministrativa ;
      private decimal Z508PropostaJurosMora ;
      private decimal A508PropostaJurosMora ;
      private decimal A326PropostaValor ;
      private decimal A855PropostaValorLiquido ;
      private decimal A501PropostaTaxaAdministrativa ;
      private decimal A786PropostaResponsavelSerasaUltimoValorRecomendado_F ;
      private decimal A787PropostaPacienteSerasaUltimoValorRecomendado_F ;
      private decimal A788PropostaMaiorValorRecomendado ;
      private decimal A575PropostaTaxa_F ;
      private decimal A514PropostaValorJurosMora_F ;
      private decimal A513PropostaValorTaxa_F ;
      private decimal A650PropostaValorTaxaClinica_F ;
      private decimal A509PropostaValorReembolsado_F ;
      private decimal A510PropostaValorReembolsadoJuros_F ;
      private decimal A511PropostaValorTaxaRecebida_F ;
      private decimal Z786PropostaResponsavelSerasaUltimoValorRecomendado_F ;
      private decimal Z787PropostaPacienteSerasaUltimoValorRecomendado_F ;
      private decimal GXt_decimal3 ;
      private decimal Z511PropostaValorTaxaRecebida_F ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_procedimentosmedicosid_Selectedvalue_get ;
      private string Combo_propostacratedby_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPropostaTitulo_Internalname ;
      private string cmbPropostaStatus_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtPropostaTitulo_Jsonclick ;
      private string edtPropostaDescricao_Internalname ;
      private string edtPropostaDescricao_Jsonclick ;
      private string edtPropostaValor_Internalname ;
      private string edtPropostaValor_Jsonclick ;
      private string edtPropostaCreatedAt_Internalname ;
      private string edtPropostaCreatedAt_Jsonclick ;
      private string divTablesplittedpropostacratedby_Internalname ;
      private string lblTextblockpropostacratedby_Internalname ;
      private string lblTextblockpropostacratedby_Jsonclick ;
      private string Combo_propostacratedby_Caption ;
      private string Combo_propostacratedby_Cls ;
      private string Combo_propostacratedby_Datalistproc ;
      private string Combo_propostacratedby_Datalistprocparametersprefix ;
      private string Combo_propostacratedby_Internalname ;
      private string edtPropostaCratedBy_Internalname ;
      private string edtPropostaCratedBy_Jsonclick ;
      private string cmbPropostaStatus_Jsonclick ;
      private string edtPropostaQuantidadeAprovadores_Internalname ;
      private string edtPropostaQuantidadeAprovadores_Jsonclick ;
      private string divTablesplittedprocedimentosmedicosid_Internalname ;
      private string lblTextblockprocedimentosmedicosid_Internalname ;
      private string lblTextblockprocedimentosmedicosid_Jsonclick ;
      private string Combo_procedimentosmedicosid_Caption ;
      private string Combo_procedimentosmedicosid_Cls ;
      private string Combo_procedimentosmedicosid_Datalistproc ;
      private string Combo_procedimentosmedicosid_Datalistprocparametersprefix ;
      private string Combo_procedimentosmedicosid_Internalname ;
      private string edtProcedimentosMedicosId_Internalname ;
      private string edtProcedimentosMedicosId_Jsonclick ;
      private string edtPropostaReprovacoesPermitidas_Internalname ;
      private string edtPropostaReprovacoesPermitidas_Jsonclick ;
      private string edtPropostaAprovacoes_F_Internalname ;
      private string edtPropostaAprovacoes_F_Jsonclick ;
      private string edtPropostaReprovacoes_F_Internalname ;
      private string edtPropostaReprovacoes_F_Jsonclick ;
      private string edtPropostaAprovacoesRestantes_F_Internalname ;
      private string edtPropostaAprovacoesRestantes_F_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_propostacratedby_Internalname ;
      private string edtavCombopropostacratedby_Internalname ;
      private string edtavCombopropostacratedby_Jsonclick ;
      private string divSectionattribute_procedimentosmedicosid_Internalname ;
      private string edtavComboprocedimentosmedicosid_Internalname ;
      private string edtavComboprocedimentosmedicosid_Jsonclick ;
      private string edtPropostaId_Internalname ;
      private string edtPropostaId_Jsonclick ;
      private string AV36Pgmname ;
      private string Combo_propostacratedby_Objectcall ;
      private string Combo_propostacratedby_Class ;
      private string Combo_propostacratedby_Icontype ;
      private string Combo_propostacratedby_Icon ;
      private string Combo_propostacratedby_Tooltip ;
      private string Combo_propostacratedby_Selectedvalue_set ;
      private string Combo_propostacratedby_Selectedtext_set ;
      private string Combo_propostacratedby_Selectedtext_get ;
      private string Combo_propostacratedby_Gamoauthtoken ;
      private string Combo_propostacratedby_Ddointernalname ;
      private string Combo_propostacratedby_Titlecontrolalign ;
      private string Combo_propostacratedby_Dropdownoptionstype ;
      private string Combo_propostacratedby_Titlecontrolidtoreplace ;
      private string Combo_propostacratedby_Datalisttype ;
      private string Combo_propostacratedby_Datalistfixedvalues ;
      private string Combo_propostacratedby_Remoteservicesparameters ;
      private string Combo_propostacratedby_Htmltemplate ;
      private string Combo_propostacratedby_Multiplevaluestype ;
      private string Combo_propostacratedby_Loadingdata ;
      private string Combo_propostacratedby_Noresultsfound ;
      private string Combo_propostacratedby_Emptyitemtext ;
      private string Combo_propostacratedby_Onlyselectedvalues ;
      private string Combo_propostacratedby_Selectalltext ;
      private string Combo_propostacratedby_Multiplevaluesseparator ;
      private string Combo_propostacratedby_Addnewoptiontext ;
      private string Combo_procedimentosmedicosid_Objectcall ;
      private string Combo_procedimentosmedicosid_Class ;
      private string Combo_procedimentosmedicosid_Icontype ;
      private string Combo_procedimentosmedicosid_Icon ;
      private string Combo_procedimentosmedicosid_Tooltip ;
      private string Combo_procedimentosmedicosid_Selectedvalue_set ;
      private string Combo_procedimentosmedicosid_Selectedtext_set ;
      private string Combo_procedimentosmedicosid_Selectedtext_get ;
      private string Combo_procedimentosmedicosid_Gamoauthtoken ;
      private string Combo_procedimentosmedicosid_Ddointernalname ;
      private string Combo_procedimentosmedicosid_Titlecontrolalign ;
      private string Combo_procedimentosmedicosid_Dropdownoptionstype ;
      private string Combo_procedimentosmedicosid_Titlecontrolidtoreplace ;
      private string Combo_procedimentosmedicosid_Datalisttype ;
      private string Combo_procedimentosmedicosid_Datalistfixedvalues ;
      private string Combo_procedimentosmedicosid_Remoteservicesparameters ;
      private string Combo_procedimentosmedicosid_Htmltemplate ;
      private string Combo_procedimentosmedicosid_Multiplevaluestype ;
      private string Combo_procedimentosmedicosid_Loadingdata ;
      private string Combo_procedimentosmedicosid_Noresultsfound ;
      private string Combo_procedimentosmedicosid_Emptyitemtext ;
      private string Combo_procedimentosmedicosid_Onlyselectedvalues ;
      private string Combo_procedimentosmedicosid_Selectalltext ;
      private string Combo_procedimentosmedicosid_Multiplevaluesseparator ;
      private string Combo_procedimentosmedicosid_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode49 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private DateTime Z327PropostaCreatedAt ;
      private DateTime A327PropostaCreatedAt ;
      private DateTime i327PropostaCreatedAt ;
      private DateTime Z517PropostaDataCirurgia ;
      private DateTime A515PropostaDataCreditoCliente_F ;
      private DateTime A517PropostaDataCirurgia ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n515PropostaDataCreditoCliente_F ;
      private bool n507PropostaSLA ;
      private bool n508PropostaJurosMora ;
      private bool n326PropostaValor ;
      private bool n323PropostaId ;
      private bool n504PropostaPacienteClienteId ;
      private bool n328PropostaCratedBy ;
      private bool n642PropostaClinicaId ;
      private bool n376ProcedimentosMedicosId ;
      private bool n227ContratoId ;
      private bool n493ConvenioCategoriaId ;
      private bool n553PropostaResponsavelId ;
      private bool n850PropostaEmpresaClienteId ;
      private bool wbErr ;
      private bool n329PropostaStatus ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n330PropostaQuantidadeAprovadores ;
      private bool n345PropostaReprovacoesPermitidas ;
      private bool n327PropostaCreatedAt ;
      private bool n853PropostaProtocolo ;
      private bool n849PropostaTipoProposta ;
      private bool n324PropostaTitulo ;
      private bool n325PropostaDescricao ;
      private bool n517PropostaDataCirurgia ;
      private bool n855PropostaValorLiquido ;
      private bool n501PropostaTaxaAdministrativa ;
      private bool n790PropostaComentarioAnalise ;
      private bool n496ConvenioVencimentoAno ;
      private bool n497ConvenioVencimentoMes ;
      private bool n782PropostaSerasaScoreUltimaData_F ;
      private bool n783PropostaResponsavelSerasaScoreUltimaData_F ;
      private bool n786PropostaResponsavelSerasaUltimoValorRecomendado_F ;
      private bool n787PropostaPacienteSerasaUltimoValorRecomendado_F ;
      private bool n650PropostaValorTaxaClinica_F ;
      private bool n509PropostaValorReembolsado_F ;
      private bool n510PropostaValorReembolsadoJuros_F ;
      private bool n511PropostaValorTaxaRecebida_F ;
      private bool n228ContratoNome ;
      private bool n494ConvenioCategoriaDescricao ;
      private bool n410ConvenioId ;
      private bool n512PropostaSecUserName ;
      private bool n505PropostaPacienteClienteRazaoSocial ;
      private bool n540PropostaPacienteClienteDocumento ;
      private bool n541PropostaPacienteContatoEmail ;
      private bool n584PropostaPacienteConta ;
      private bool n585PropostaPacienteAgencia ;
      private bool n586PropostaPacienteTipoPix ;
      private bool n587PropostaPacientePIX ;
      private bool n588PropostaPacienteDepositoTipo ;
      private bool n620PropostaPacienteEnderecoCEP ;
      private bool n621PropostaPacienteEnderecoLogradouro ;
      private bool n622PropostaPacienteEnderecoNumero ;
      private bool n623PropostaPacienteEnderecoComplemento ;
      private bool n624PropostaPacienteEnderecoBairro ;
      private bool n625PropostaPacienteMunicipioCodigo ;
      private bool n580PropostaResponsavelDocumento ;
      private bool n581PropostaResponsavelRazaoSocial ;
      private bool n582PropostaResponsavelEmail ;
      private bool n590PropostaResponsavelConta ;
      private bool n591PropostaResponsavelAgencia ;
      private bool n592PropostaResponsavelTipoPix ;
      private bool n593PropostaResponsavelPIX ;
      private bool n594PropostaResponsavelDepositoTipo ;
      private bool n643PropostaClinicaNome ;
      private bool n644PropostaClinicaNomeFantasia ;
      private bool n652PropostaClinicaDocumento ;
      private bool n653PropostaClinicaEmail ;
      private bool n649PropostaMaxReembolsoId_F ;
      private bool n854PropostaQtdItensNota_F ;
      private bool n733PropostaResponsavelSerasaConsultas_F ;
      private bool n734PropostaPacienteSerasaConsultas_F ;
      private bool n655PropostaQtdDocumentoPendente_F ;
      private bool Combo_propostacratedby_Enabled ;
      private bool Combo_propostacratedby_Visible ;
      private bool Combo_propostacratedby_Allowmultipleselection ;
      private bool Combo_propostacratedby_Isgriditem ;
      private bool Combo_propostacratedby_Hasdescription ;
      private bool Combo_propostacratedby_Includeonlyselectedoption ;
      private bool Combo_propostacratedby_Includeselectalloption ;
      private bool Combo_propostacratedby_Emptyitem ;
      private bool Combo_propostacratedby_Includeaddnewoption ;
      private bool Combo_procedimentosmedicosid_Enabled ;
      private bool Combo_procedimentosmedicosid_Visible ;
      private bool Combo_procedimentosmedicosid_Allowmultipleselection ;
      private bool Combo_procedimentosmedicosid_Isgriditem ;
      private bool Combo_procedimentosmedicosid_Hasdescription ;
      private bool Combo_procedimentosmedicosid_Includeonlyselectedoption ;
      private bool Combo_procedimentosmedicosid_Includeselectalloption ;
      private bool Combo_procedimentosmedicosid_Emptyitem ;
      private bool Combo_procedimentosmedicosid_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n341PropostaAprovacoes_F ;
      private bool n342PropostaReprovacoes_F ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string AV18Combo_DataJson ;
      private string Z853PropostaProtocolo ;
      private string Z849PropostaTipoProposta ;
      private string Z324PropostaTitulo ;
      private string Z325PropostaDescricao ;
      private string Z329PropostaStatus ;
      private string Z790PropostaComentarioAnalise ;
      private string A329PropostaStatus ;
      private string A324PropostaTitulo ;
      private string A325PropostaDescricao ;
      private string A853PropostaProtocolo ;
      private string A849PropostaTipoProposta ;
      private string A790PropostaComentarioAnalise ;
      private string A228ContratoNome ;
      private string A494ConvenioCategoriaDescricao ;
      private string A512PropostaSecUserName ;
      private string A505PropostaPacienteClienteRazaoSocial ;
      private string A540PropostaPacienteClienteDocumento ;
      private string A541PropostaPacienteContatoEmail ;
      private string A584PropostaPacienteConta ;
      private string A585PropostaPacienteAgencia ;
      private string A586PropostaPacienteTipoPix ;
      private string A587PropostaPacientePIX ;
      private string A588PropostaPacienteDepositoTipo ;
      private string A620PropostaPacienteEnderecoCEP ;
      private string A621PropostaPacienteEnderecoLogradouro ;
      private string A622PropostaPacienteEnderecoNumero ;
      private string A623PropostaPacienteEnderecoComplemento ;
      private string A624PropostaPacienteEnderecoBairro ;
      private string A625PropostaPacienteMunicipioCodigo ;
      private string A580PropostaResponsavelDocumento ;
      private string A581PropostaResponsavelRazaoSocial ;
      private string A582PropostaResponsavelEmail ;
      private string A590PropostaResponsavelConta ;
      private string A591PropostaResponsavelAgencia ;
      private string A592PropostaResponsavelTipoPix ;
      private string A593PropostaResponsavelPIX ;
      private string A594PropostaResponsavelDepositoTipo ;
      private string A643PropostaClinicaNome ;
      private string A644PropostaClinicaNomeFantasia ;
      private string A652PropostaClinicaDocumento ;
      private string A653PropostaClinicaEmail ;
      private string AV16ComboSelectedValue ;
      private string AV17ComboSelectedText ;
      private string Z228ContratoNome ;
      private string Z494ConvenioCategoriaDescricao ;
      private string Z505PropostaPacienteClienteRazaoSocial ;
      private string Z540PropostaPacienteClienteDocumento ;
      private string Z541PropostaPacienteContatoEmail ;
      private string Z584PropostaPacienteConta ;
      private string Z585PropostaPacienteAgencia ;
      private string Z586PropostaPacienteTipoPix ;
      private string Z587PropostaPacientePIX ;
      private string Z588PropostaPacienteDepositoTipo ;
      private string Z620PropostaPacienteEnderecoCEP ;
      private string Z621PropostaPacienteEnderecoLogradouro ;
      private string Z622PropostaPacienteEnderecoNumero ;
      private string Z623PropostaPacienteEnderecoComplemento ;
      private string Z624PropostaPacienteEnderecoBairro ;
      private string Z625PropostaPacienteMunicipioCodigo ;
      private string Z580PropostaResponsavelDocumento ;
      private string Z581PropostaResponsavelRazaoSocial ;
      private string Z582PropostaResponsavelEmail ;
      private string Z590PropostaResponsavelConta ;
      private string Z591PropostaResponsavelAgencia ;
      private string Z592PropostaResponsavelTipoPix ;
      private string Z593PropostaResponsavelPIX ;
      private string Z594PropostaResponsavelDepositoTipo ;
      private string Z643PropostaClinicaNome ;
      private string Z644PropostaClinicaNomeFantasia ;
      private string Z652PropostaClinicaDocumento ;
      private string Z653PropostaClinicaEmail ;
      private string Z512PropostaSecUserName ;
      private string A589PropostaResponsavelBanco ;
      private string A583PropostaPacienteBanco ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_propostacratedby ;
      private GXUserControl ucCombo_procedimentosmedicosid ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbPropostaStatus ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV15DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV14PropostaCratedBy_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV27ProcedimentosMedicosId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] T001A27_A649PropostaMaxReembolsoId_F ;
      private bool[] T001A27_n649PropostaMaxReembolsoId_F ;
      private short[] T001A29_A854PropostaQtdItensNota_F ;
      private bool[] T001A29_n854PropostaQtdItensNota_F ;
      private short[] T001A39_A655PropostaQtdDocumentoPendente_F ;
      private bool[] T001A39_n655PropostaQtdDocumentoPendente_F ;
      private short[] T001A41_A341PropostaAprovacoes_F ;
      private bool[] T001A41_n341PropostaAprovacoes_F ;
      private short[] T001A43_A342PropostaReprovacoes_F ;
      private bool[] T001A43_n342PropostaReprovacoes_F ;
      private string[] T001A10_A643PropostaClinicaNome ;
      private bool[] T001A10_n643PropostaClinicaNome ;
      private string[] T001A10_A644PropostaClinicaNomeFantasia ;
      private bool[] T001A10_n644PropostaClinicaNomeFantasia ;
      private string[] T001A10_A652PropostaClinicaDocumento ;
      private bool[] T001A10_n652PropostaClinicaDocumento ;
      private string[] T001A10_A653PropostaClinicaEmail ;
      private bool[] T001A10_n653PropostaClinicaEmail ;
      private decimal[] T001A25_A650PropostaValorTaxaClinica_F ;
      private bool[] T001A25_n650PropostaValorTaxaClinica_F ;
      private int[] T001A54_A323PropostaId ;
      private bool[] T001A54_n323PropostaId ;
      private DateTime[] T001A54_A327PropostaCreatedAt ;
      private bool[] T001A54_n327PropostaCreatedAt ;
      private string[] T001A54_A853PropostaProtocolo ;
      private bool[] T001A54_n853PropostaProtocolo ;
      private string[] T001A54_A849PropostaTipoProposta ;
      private bool[] T001A54_n849PropostaTipoProposta ;
      private string[] T001A54_A580PropostaResponsavelDocumento ;
      private bool[] T001A54_n580PropostaResponsavelDocumento ;
      private string[] T001A54_A581PropostaResponsavelRazaoSocial ;
      private bool[] T001A54_n581PropostaResponsavelRazaoSocial ;
      private string[] T001A54_A582PropostaResponsavelEmail ;
      private bool[] T001A54_n582PropostaResponsavelEmail ;
      private string[] T001A54_A590PropostaResponsavelConta ;
      private bool[] T001A54_n590PropostaResponsavelConta ;
      private string[] T001A54_A591PropostaResponsavelAgencia ;
      private bool[] T001A54_n591PropostaResponsavelAgencia ;
      private string[] T001A54_A592PropostaResponsavelTipoPix ;
      private bool[] T001A54_n592PropostaResponsavelTipoPix ;
      private string[] T001A54_A593PropostaResponsavelPIX ;
      private bool[] T001A54_n593PropostaResponsavelPIX ;
      private string[] T001A54_A594PropostaResponsavelDepositoTipo ;
      private bool[] T001A54_n594PropostaResponsavelDepositoTipo ;
      private string[] T001A54_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] T001A54_n505PropostaPacienteClienteRazaoSocial ;
      private string[] T001A54_A540PropostaPacienteClienteDocumento ;
      private bool[] T001A54_n540PropostaPacienteClienteDocumento ;
      private string[] T001A54_A541PropostaPacienteContatoEmail ;
      private bool[] T001A54_n541PropostaPacienteContatoEmail ;
      private string[] T001A54_A584PropostaPacienteConta ;
      private bool[] T001A54_n584PropostaPacienteConta ;
      private string[] T001A54_A585PropostaPacienteAgencia ;
      private bool[] T001A54_n585PropostaPacienteAgencia ;
      private string[] T001A54_A586PropostaPacienteTipoPix ;
      private bool[] T001A54_n586PropostaPacienteTipoPix ;
      private string[] T001A54_A587PropostaPacientePIX ;
      private bool[] T001A54_n587PropostaPacientePIX ;
      private string[] T001A54_A588PropostaPacienteDepositoTipo ;
      private bool[] T001A54_n588PropostaPacienteDepositoTipo ;
      private string[] T001A54_A620PropostaPacienteEnderecoCEP ;
      private bool[] T001A54_n620PropostaPacienteEnderecoCEP ;
      private string[] T001A54_A621PropostaPacienteEnderecoLogradouro ;
      private bool[] T001A54_n621PropostaPacienteEnderecoLogradouro ;
      private string[] T001A54_A622PropostaPacienteEnderecoNumero ;
      private bool[] T001A54_n622PropostaPacienteEnderecoNumero ;
      private string[] T001A54_A623PropostaPacienteEnderecoComplemento ;
      private bool[] T001A54_n623PropostaPacienteEnderecoComplemento ;
      private string[] T001A54_A624PropostaPacienteEnderecoBairro ;
      private bool[] T001A54_n624PropostaPacienteEnderecoBairro ;
      private string[] T001A54_A324PropostaTitulo ;
      private bool[] T001A54_n324PropostaTitulo ;
      private string[] T001A54_A325PropostaDescricao ;
      private bool[] T001A54_n325PropostaDescricao ;
      private DateTime[] T001A54_A517PropostaDataCirurgia ;
      private bool[] T001A54_n517PropostaDataCirurgia ;
      private decimal[] T001A54_A326PropostaValor ;
      private bool[] T001A54_n326PropostaValor ;
      private decimal[] T001A54_A855PropostaValorLiquido ;
      private bool[] T001A54_n855PropostaValorLiquido ;
      private decimal[] T001A54_A501PropostaTaxaAdministrativa ;
      private bool[] T001A54_n501PropostaTaxaAdministrativa ;
      private short[] T001A54_A507PropostaSLA ;
      private bool[] T001A54_n507PropostaSLA ;
      private decimal[] T001A54_A508PropostaJurosMora ;
      private bool[] T001A54_n508PropostaJurosMora ;
      private string[] T001A54_A643PropostaClinicaNome ;
      private bool[] T001A54_n643PropostaClinicaNome ;
      private string[] T001A54_A644PropostaClinicaNomeFantasia ;
      private bool[] T001A54_n644PropostaClinicaNomeFantasia ;
      private string[] T001A54_A652PropostaClinicaDocumento ;
      private bool[] T001A54_n652PropostaClinicaDocumento ;
      private string[] T001A54_A653PropostaClinicaEmail ;
      private bool[] T001A54_n653PropostaClinicaEmail ;
      private string[] T001A54_A512PropostaSecUserName ;
      private bool[] T001A54_n512PropostaSecUserName ;
      private string[] T001A54_A329PropostaStatus ;
      private bool[] T001A54_n329PropostaStatus ;
      private string[] T001A54_A790PropostaComentarioAnalise ;
      private bool[] T001A54_n790PropostaComentarioAnalise ;
      private short[] T001A54_A330PropostaQuantidadeAprovadores ;
      private bool[] T001A54_n330PropostaQuantidadeAprovadores ;
      private short[] T001A54_A345PropostaReprovacoesPermitidas ;
      private bool[] T001A54_n345PropostaReprovacoesPermitidas ;
      private string[] T001A54_A228ContratoNome ;
      private bool[] T001A54_n228ContratoNome ;
      private short[] T001A54_A496ConvenioVencimentoAno ;
      private bool[] T001A54_n496ConvenioVencimentoAno ;
      private short[] T001A54_A497ConvenioVencimentoMes ;
      private bool[] T001A54_n497ConvenioVencimentoMes ;
      private string[] T001A54_A494ConvenioCategoriaDescricao ;
      private bool[] T001A54_n494ConvenioCategoriaDescricao ;
      private int[] T001A54_A227ContratoId ;
      private bool[] T001A54_n227ContratoId ;
      private int[] T001A54_A376ProcedimentosMedicosId ;
      private bool[] T001A54_n376ProcedimentosMedicosId ;
      private int[] T001A54_A493ConvenioCategoriaId ;
      private bool[] T001A54_n493ConvenioCategoriaId ;
      private short[] T001A54_A328PropostaCratedBy ;
      private bool[] T001A54_n328PropostaCratedBy ;
      private int[] T001A54_A504PropostaPacienteClienteId ;
      private bool[] T001A54_n504PropostaPacienteClienteId ;
      private int[] T001A54_A553PropostaResponsavelId ;
      private bool[] T001A54_n553PropostaResponsavelId ;
      private int[] T001A54_A642PropostaClinicaId ;
      private bool[] T001A54_n642PropostaClinicaId ;
      private int[] T001A54_A850PropostaEmpresaClienteId ;
      private bool[] T001A54_n850PropostaEmpresaClienteId ;
      private int[] T001A54_A410ConvenioId ;
      private bool[] T001A54_n410ConvenioId ;
      private string[] T001A54_A625PropostaPacienteMunicipioCodigo ;
      private bool[] T001A54_n625PropostaPacienteMunicipioCodigo ;
      private int[] T001A54_A649PropostaMaxReembolsoId_F ;
      private bool[] T001A54_n649PropostaMaxReembolsoId_F ;
      private short[] T001A54_A854PropostaQtdItensNota_F ;
      private bool[] T001A54_n854PropostaQtdItensNota_F ;
      private short[] T001A54_A733PropostaResponsavelSerasaConsultas_F ;
      private bool[] T001A54_n733PropostaResponsavelSerasaConsultas_F ;
      private short[] T001A54_A783PropostaResponsavelSerasaScoreUltimaData_F ;
      private bool[] T001A54_n783PropostaResponsavelSerasaScoreUltimaData_F ;
      private decimal[] T001A54_A786PropostaResponsavelSerasaUltimoValorRecomendado_F ;
      private bool[] T001A54_n786PropostaResponsavelSerasaUltimoValorRecomendado_F ;
      private short[] T001A54_A734PropostaPacienteSerasaConsultas_F ;
      private bool[] T001A54_n734PropostaPacienteSerasaConsultas_F ;
      private short[] T001A54_A782PropostaSerasaScoreUltimaData_F ;
      private bool[] T001A54_n782PropostaSerasaScoreUltimaData_F ;
      private decimal[] T001A54_A787PropostaPacienteSerasaUltimoValorRecomendado_F ;
      private bool[] T001A54_n787PropostaPacienteSerasaUltimoValorRecomendado_F ;
      private short[] T001A54_A655PropostaQtdDocumentoPendente_F ;
      private bool[] T001A54_n655PropostaQtdDocumentoPendente_F ;
      private short[] T001A54_A341PropostaAprovacoes_F ;
      private bool[] T001A54_n341PropostaAprovacoes_F ;
      private short[] T001A54_A342PropostaReprovacoes_F ;
      private bool[] T001A54_n342PropostaReprovacoes_F ;
      private decimal[] T001A14_A509PropostaValorReembolsado_F ;
      private bool[] T001A14_n509PropostaValorReembolsado_F ;
      private decimal[] T001A17_A510PropostaValorReembolsadoJuros_F ;
      private bool[] T001A17_n510PropostaValorReembolsadoJuros_F ;
      private decimal[] T001A20_A511PropostaValorTaxaRecebida_F ;
      private bool[] T001A20_n511PropostaValorTaxaRecebida_F ;
      private DateTime[] T001A23_A515PropostaDataCreditoCliente_F ;
      private bool[] T001A23_n515PropostaDataCreditoCliente_F ;
      private int[] T001A5_A376ProcedimentosMedicosId ;
      private bool[] T001A5_n376ProcedimentosMedicosId ;
      private string[] T001A7_A512PropostaSecUserName ;
      private bool[] T001A7_n512PropostaSecUserName ;
      private string[] T001A4_A228ContratoNome ;
      private bool[] T001A4_n228ContratoNome ;
      private string[] T001A6_A494ConvenioCategoriaDescricao ;
      private bool[] T001A6_n494ConvenioCategoriaDescricao ;
      private int[] T001A6_A410ConvenioId ;
      private bool[] T001A6_n410ConvenioId ;
      private string[] T001A8_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] T001A8_n505PropostaPacienteClienteRazaoSocial ;
      private string[] T001A8_A540PropostaPacienteClienteDocumento ;
      private bool[] T001A8_n540PropostaPacienteClienteDocumento ;
      private string[] T001A8_A541PropostaPacienteContatoEmail ;
      private bool[] T001A8_n541PropostaPacienteContatoEmail ;
      private string[] T001A8_A584PropostaPacienteConta ;
      private bool[] T001A8_n584PropostaPacienteConta ;
      private string[] T001A8_A585PropostaPacienteAgencia ;
      private bool[] T001A8_n585PropostaPacienteAgencia ;
      private string[] T001A8_A586PropostaPacienteTipoPix ;
      private bool[] T001A8_n586PropostaPacienteTipoPix ;
      private string[] T001A8_A587PropostaPacientePIX ;
      private bool[] T001A8_n587PropostaPacientePIX ;
      private string[] T001A8_A588PropostaPacienteDepositoTipo ;
      private bool[] T001A8_n588PropostaPacienteDepositoTipo ;
      private string[] T001A8_A620PropostaPacienteEnderecoCEP ;
      private bool[] T001A8_n620PropostaPacienteEnderecoCEP ;
      private string[] T001A8_A621PropostaPacienteEnderecoLogradouro ;
      private bool[] T001A8_n621PropostaPacienteEnderecoLogradouro ;
      private string[] T001A8_A622PropostaPacienteEnderecoNumero ;
      private bool[] T001A8_n622PropostaPacienteEnderecoNumero ;
      private string[] T001A8_A623PropostaPacienteEnderecoComplemento ;
      private bool[] T001A8_n623PropostaPacienteEnderecoComplemento ;
      private string[] T001A8_A624PropostaPacienteEnderecoBairro ;
      private bool[] T001A8_n624PropostaPacienteEnderecoBairro ;
      private string[] T001A8_A625PropostaPacienteMunicipioCodigo ;
      private bool[] T001A8_n625PropostaPacienteMunicipioCodigo ;
      private short[] T001A31_A733PropostaResponsavelSerasaConsultas_F ;
      private bool[] T001A31_n733PropostaResponsavelSerasaConsultas_F ;
      private short[] T001A31_A734PropostaPacienteSerasaConsultas_F ;
      private bool[] T001A31_n734PropostaPacienteSerasaConsultas_F ;
      private short[] T001A34_A783PropostaResponsavelSerasaScoreUltimaData_F ;
      private bool[] T001A34_n783PropostaResponsavelSerasaScoreUltimaData_F ;
      private short[] T001A34_A782PropostaSerasaScoreUltimaData_F ;
      private bool[] T001A34_n782PropostaSerasaScoreUltimaData_F ;
      private decimal[] T001A37_A786PropostaResponsavelSerasaUltimoValorRecomendado_F ;
      private bool[] T001A37_n786PropostaResponsavelSerasaUltimoValorRecomendado_F ;
      private decimal[] T001A37_A787PropostaPacienteSerasaUltimoValorRecomendado_F ;
      private bool[] T001A37_n787PropostaPacienteSerasaUltimoValorRecomendado_F ;
      private string[] T001A9_A580PropostaResponsavelDocumento ;
      private bool[] T001A9_n580PropostaResponsavelDocumento ;
      private string[] T001A9_A581PropostaResponsavelRazaoSocial ;
      private bool[] T001A9_n581PropostaResponsavelRazaoSocial ;
      private string[] T001A9_A582PropostaResponsavelEmail ;
      private bool[] T001A9_n582PropostaResponsavelEmail ;
      private string[] T001A9_A590PropostaResponsavelConta ;
      private bool[] T001A9_n590PropostaResponsavelConta ;
      private string[] T001A9_A591PropostaResponsavelAgencia ;
      private bool[] T001A9_n591PropostaResponsavelAgencia ;
      private string[] T001A9_A592PropostaResponsavelTipoPix ;
      private bool[] T001A9_n592PropostaResponsavelTipoPix ;
      private string[] T001A9_A593PropostaResponsavelPIX ;
      private bool[] T001A9_n593PropostaResponsavelPIX ;
      private string[] T001A9_A594PropostaResponsavelDepositoTipo ;
      private bool[] T001A9_n594PropostaResponsavelDepositoTipo ;
      private int[] T001A11_A850PropostaEmpresaClienteId ;
      private bool[] T001A11_n850PropostaEmpresaClienteId ;
      private decimal[] T001A57_A509PropostaValorReembolsado_F ;
      private bool[] T001A57_n509PropostaValorReembolsado_F ;
      private decimal[] T001A60_A510PropostaValorReembolsadoJuros_F ;
      private bool[] T001A60_n510PropostaValorReembolsadoJuros_F ;
      private decimal[] T001A63_A511PropostaValorTaxaRecebida_F ;
      private bool[] T001A63_n511PropostaValorTaxaRecebida_F ;
      private DateTime[] T001A66_A515PropostaDataCreditoCliente_F ;
      private bool[] T001A66_n515PropostaDataCreditoCliente_F ;
      private decimal[] T001A68_A650PropostaValorTaxaClinica_F ;
      private bool[] T001A68_n650PropostaValorTaxaClinica_F ;
      private int[] T001A70_A649PropostaMaxReembolsoId_F ;
      private bool[] T001A70_n649PropostaMaxReembolsoId_F ;
      private short[] T001A72_A854PropostaQtdItensNota_F ;
      private bool[] T001A72_n854PropostaQtdItensNota_F ;
      private short[] T001A74_A655PropostaQtdDocumentoPendente_F ;
      private bool[] T001A74_n655PropostaQtdDocumentoPendente_F ;
      private short[] T001A76_A341PropostaAprovacoes_F ;
      private bool[] T001A76_n341PropostaAprovacoes_F ;
      private short[] T001A78_A342PropostaReprovacoes_F ;
      private bool[] T001A78_n342PropostaReprovacoes_F ;
      private int[] T001A79_A376ProcedimentosMedicosId ;
      private bool[] T001A79_n376ProcedimentosMedicosId ;
      private string[] T001A80_A512PropostaSecUserName ;
      private bool[] T001A80_n512PropostaSecUserName ;
      private string[] T001A81_A228ContratoNome ;
      private bool[] T001A81_n228ContratoNome ;
      private string[] T001A82_A494ConvenioCategoriaDescricao ;
      private bool[] T001A82_n494ConvenioCategoriaDescricao ;
      private int[] T001A82_A410ConvenioId ;
      private bool[] T001A82_n410ConvenioId ;
      private string[] T001A83_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] T001A83_n505PropostaPacienteClienteRazaoSocial ;
      private string[] T001A83_A540PropostaPacienteClienteDocumento ;
      private bool[] T001A83_n540PropostaPacienteClienteDocumento ;
      private string[] T001A83_A541PropostaPacienteContatoEmail ;
      private bool[] T001A83_n541PropostaPacienteContatoEmail ;
      private string[] T001A83_A584PropostaPacienteConta ;
      private bool[] T001A83_n584PropostaPacienteConta ;
      private string[] T001A83_A585PropostaPacienteAgencia ;
      private bool[] T001A83_n585PropostaPacienteAgencia ;
      private string[] T001A83_A586PropostaPacienteTipoPix ;
      private bool[] T001A83_n586PropostaPacienteTipoPix ;
      private string[] T001A83_A587PropostaPacientePIX ;
      private bool[] T001A83_n587PropostaPacientePIX ;
      private string[] T001A83_A588PropostaPacienteDepositoTipo ;
      private bool[] T001A83_n588PropostaPacienteDepositoTipo ;
      private string[] T001A83_A620PropostaPacienteEnderecoCEP ;
      private bool[] T001A83_n620PropostaPacienteEnderecoCEP ;
      private string[] T001A83_A621PropostaPacienteEnderecoLogradouro ;
      private bool[] T001A83_n621PropostaPacienteEnderecoLogradouro ;
      private string[] T001A83_A622PropostaPacienteEnderecoNumero ;
      private bool[] T001A83_n622PropostaPacienteEnderecoNumero ;
      private string[] T001A83_A623PropostaPacienteEnderecoComplemento ;
      private bool[] T001A83_n623PropostaPacienteEnderecoComplemento ;
      private string[] T001A83_A624PropostaPacienteEnderecoBairro ;
      private bool[] T001A83_n624PropostaPacienteEnderecoBairro ;
      private string[] T001A83_A625PropostaPacienteMunicipioCodigo ;
      private bool[] T001A83_n625PropostaPacienteMunicipioCodigo ;
      private short[] T001A85_A733PropostaResponsavelSerasaConsultas_F ;
      private bool[] T001A85_n733PropostaResponsavelSerasaConsultas_F ;
      private short[] T001A85_A734PropostaPacienteSerasaConsultas_F ;
      private bool[] T001A85_n734PropostaPacienteSerasaConsultas_F ;
      private short[] T001A88_A783PropostaResponsavelSerasaScoreUltimaData_F ;
      private bool[] T001A88_n783PropostaResponsavelSerasaScoreUltimaData_F ;
      private short[] T001A88_A782PropostaSerasaScoreUltimaData_F ;
      private bool[] T001A88_n782PropostaSerasaScoreUltimaData_F ;
      private decimal[] T001A91_A786PropostaResponsavelSerasaUltimoValorRecomendado_F ;
      private bool[] T001A91_n786PropostaResponsavelSerasaUltimoValorRecomendado_F ;
      private decimal[] T001A91_A787PropostaPacienteSerasaUltimoValorRecomendado_F ;
      private bool[] T001A91_n787PropostaPacienteSerasaUltimoValorRecomendado_F ;
      private string[] T001A92_A580PropostaResponsavelDocumento ;
      private bool[] T001A92_n580PropostaResponsavelDocumento ;
      private string[] T001A92_A581PropostaResponsavelRazaoSocial ;
      private bool[] T001A92_n581PropostaResponsavelRazaoSocial ;
      private string[] T001A92_A582PropostaResponsavelEmail ;
      private bool[] T001A92_n582PropostaResponsavelEmail ;
      private string[] T001A92_A590PropostaResponsavelConta ;
      private bool[] T001A92_n590PropostaResponsavelConta ;
      private string[] T001A92_A591PropostaResponsavelAgencia ;
      private bool[] T001A92_n591PropostaResponsavelAgencia ;
      private string[] T001A92_A592PropostaResponsavelTipoPix ;
      private bool[] T001A92_n592PropostaResponsavelTipoPix ;
      private string[] T001A92_A593PropostaResponsavelPIX ;
      private bool[] T001A92_n593PropostaResponsavelPIX ;
      private string[] T001A92_A594PropostaResponsavelDepositoTipo ;
      private bool[] T001A92_n594PropostaResponsavelDepositoTipo ;
      private string[] T001A93_A643PropostaClinicaNome ;
      private bool[] T001A93_n643PropostaClinicaNome ;
      private string[] T001A93_A644PropostaClinicaNomeFantasia ;
      private bool[] T001A93_n644PropostaClinicaNomeFantasia ;
      private string[] T001A93_A652PropostaClinicaDocumento ;
      private bool[] T001A93_n652PropostaClinicaDocumento ;
      private string[] T001A93_A653PropostaClinicaEmail ;
      private bool[] T001A93_n653PropostaClinicaEmail ;
      private int[] T001A94_A850PropostaEmpresaClienteId ;
      private bool[] T001A94_n850PropostaEmpresaClienteId ;
      private int[] T001A95_A323PropostaId ;
      private bool[] T001A95_n323PropostaId ;
      private int[] T001A3_A323PropostaId ;
      private bool[] T001A3_n323PropostaId ;
      private DateTime[] T001A3_A327PropostaCreatedAt ;
      private bool[] T001A3_n327PropostaCreatedAt ;
      private string[] T001A3_A853PropostaProtocolo ;
      private bool[] T001A3_n853PropostaProtocolo ;
      private string[] T001A3_A849PropostaTipoProposta ;
      private bool[] T001A3_n849PropostaTipoProposta ;
      private string[] T001A3_A324PropostaTitulo ;
      private bool[] T001A3_n324PropostaTitulo ;
      private string[] T001A3_A325PropostaDescricao ;
      private bool[] T001A3_n325PropostaDescricao ;
      private DateTime[] T001A3_A517PropostaDataCirurgia ;
      private bool[] T001A3_n517PropostaDataCirurgia ;
      private decimal[] T001A3_A326PropostaValor ;
      private bool[] T001A3_n326PropostaValor ;
      private decimal[] T001A3_A855PropostaValorLiquido ;
      private bool[] T001A3_n855PropostaValorLiquido ;
      private decimal[] T001A3_A501PropostaTaxaAdministrativa ;
      private bool[] T001A3_n501PropostaTaxaAdministrativa ;
      private short[] T001A3_A507PropostaSLA ;
      private bool[] T001A3_n507PropostaSLA ;
      private decimal[] T001A3_A508PropostaJurosMora ;
      private bool[] T001A3_n508PropostaJurosMora ;
      private string[] T001A3_A329PropostaStatus ;
      private bool[] T001A3_n329PropostaStatus ;
      private string[] T001A3_A790PropostaComentarioAnalise ;
      private bool[] T001A3_n790PropostaComentarioAnalise ;
      private short[] T001A3_A330PropostaQuantidadeAprovadores ;
      private bool[] T001A3_n330PropostaQuantidadeAprovadores ;
      private short[] T001A3_A345PropostaReprovacoesPermitidas ;
      private bool[] T001A3_n345PropostaReprovacoesPermitidas ;
      private short[] T001A3_A496ConvenioVencimentoAno ;
      private bool[] T001A3_n496ConvenioVencimentoAno ;
      private short[] T001A3_A497ConvenioVencimentoMes ;
      private bool[] T001A3_n497ConvenioVencimentoMes ;
      private int[] T001A3_A227ContratoId ;
      private bool[] T001A3_n227ContratoId ;
      private int[] T001A3_A376ProcedimentosMedicosId ;
      private bool[] T001A3_n376ProcedimentosMedicosId ;
      private int[] T001A3_A493ConvenioCategoriaId ;
      private bool[] T001A3_n493ConvenioCategoriaId ;
      private short[] T001A3_A328PropostaCratedBy ;
      private bool[] T001A3_n328PropostaCratedBy ;
      private int[] T001A3_A504PropostaPacienteClienteId ;
      private bool[] T001A3_n504PropostaPacienteClienteId ;
      private int[] T001A3_A553PropostaResponsavelId ;
      private bool[] T001A3_n553PropostaResponsavelId ;
      private int[] T001A3_A642PropostaClinicaId ;
      private bool[] T001A3_n642PropostaClinicaId ;
      private int[] T001A3_A850PropostaEmpresaClienteId ;
      private bool[] T001A3_n850PropostaEmpresaClienteId ;
      private int[] T001A96_A323PropostaId ;
      private bool[] T001A96_n323PropostaId ;
      private int[] T001A97_A323PropostaId ;
      private bool[] T001A97_n323PropostaId ;
      private int[] T001A2_A323PropostaId ;
      private bool[] T001A2_n323PropostaId ;
      private DateTime[] T001A2_A327PropostaCreatedAt ;
      private bool[] T001A2_n327PropostaCreatedAt ;
      private string[] T001A2_A853PropostaProtocolo ;
      private bool[] T001A2_n853PropostaProtocolo ;
      private string[] T001A2_A849PropostaTipoProposta ;
      private bool[] T001A2_n849PropostaTipoProposta ;
      private string[] T001A2_A324PropostaTitulo ;
      private bool[] T001A2_n324PropostaTitulo ;
      private string[] T001A2_A325PropostaDescricao ;
      private bool[] T001A2_n325PropostaDescricao ;
      private DateTime[] T001A2_A517PropostaDataCirurgia ;
      private bool[] T001A2_n517PropostaDataCirurgia ;
      private decimal[] T001A2_A326PropostaValor ;
      private bool[] T001A2_n326PropostaValor ;
      private decimal[] T001A2_A855PropostaValorLiquido ;
      private bool[] T001A2_n855PropostaValorLiquido ;
      private decimal[] T001A2_A501PropostaTaxaAdministrativa ;
      private bool[] T001A2_n501PropostaTaxaAdministrativa ;
      private short[] T001A2_A507PropostaSLA ;
      private bool[] T001A2_n507PropostaSLA ;
      private decimal[] T001A2_A508PropostaJurosMora ;
      private bool[] T001A2_n508PropostaJurosMora ;
      private string[] T001A2_A329PropostaStatus ;
      private bool[] T001A2_n329PropostaStatus ;
      private string[] T001A2_A790PropostaComentarioAnalise ;
      private bool[] T001A2_n790PropostaComentarioAnalise ;
      private short[] T001A2_A330PropostaQuantidadeAprovadores ;
      private bool[] T001A2_n330PropostaQuantidadeAprovadores ;
      private short[] T001A2_A345PropostaReprovacoesPermitidas ;
      private bool[] T001A2_n345PropostaReprovacoesPermitidas ;
      private short[] T001A2_A496ConvenioVencimentoAno ;
      private bool[] T001A2_n496ConvenioVencimentoAno ;
      private short[] T001A2_A497ConvenioVencimentoMes ;
      private bool[] T001A2_n497ConvenioVencimentoMes ;
      private int[] T001A2_A227ContratoId ;
      private bool[] T001A2_n227ContratoId ;
      private int[] T001A2_A376ProcedimentosMedicosId ;
      private bool[] T001A2_n376ProcedimentosMedicosId ;
      private int[] T001A2_A493ConvenioCategoriaId ;
      private bool[] T001A2_n493ConvenioCategoriaId ;
      private short[] T001A2_A328PropostaCratedBy ;
      private bool[] T001A2_n328PropostaCratedBy ;
      private int[] T001A2_A504PropostaPacienteClienteId ;
      private bool[] T001A2_n504PropostaPacienteClienteId ;
      private int[] T001A2_A553PropostaResponsavelId ;
      private bool[] T001A2_n553PropostaResponsavelId ;
      private int[] T001A2_A642PropostaClinicaId ;
      private bool[] T001A2_n642PropostaClinicaId ;
      private int[] T001A2_A850PropostaEmpresaClienteId ;
      private bool[] T001A2_n850PropostaEmpresaClienteId ;
      private int[] T001A99_A323PropostaId ;
      private bool[] T001A99_n323PropostaId ;
      private int[] T001A103_A649PropostaMaxReembolsoId_F ;
      private bool[] T001A103_n649PropostaMaxReembolsoId_F ;
      private short[] T001A105_A854PropostaQtdItensNota_F ;
      private bool[] T001A105_n854PropostaQtdItensNota_F ;
      private short[] T001A107_A655PropostaQtdDocumentoPendente_F ;
      private bool[] T001A107_n655PropostaQtdDocumentoPendente_F ;
      private short[] T001A109_A341PropostaAprovacoes_F ;
      private bool[] T001A109_n341PropostaAprovacoes_F ;
      private short[] T001A111_A342PropostaReprovacoes_F ;
      private bool[] T001A111_n342PropostaReprovacoes_F ;
      private string[] T001A112_A512PropostaSecUserName ;
      private bool[] T001A112_n512PropostaSecUserName ;
      private decimal[] T001A115_A511PropostaValorTaxaRecebida_F ;
      private bool[] T001A115_n511PropostaValorTaxaRecebida_F ;
      private string[] T001A116_A228ContratoNome ;
      private bool[] T001A116_n228ContratoNome ;
      private string[] T001A117_A494ConvenioCategoriaDescricao ;
      private bool[] T001A117_n494ConvenioCategoriaDescricao ;
      private int[] T001A117_A410ConvenioId ;
      private bool[] T001A117_n410ConvenioId ;
      private string[] T001A118_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] T001A118_n505PropostaPacienteClienteRazaoSocial ;
      private string[] T001A118_A540PropostaPacienteClienteDocumento ;
      private bool[] T001A118_n540PropostaPacienteClienteDocumento ;
      private string[] T001A118_A541PropostaPacienteContatoEmail ;
      private bool[] T001A118_n541PropostaPacienteContatoEmail ;
      private string[] T001A118_A584PropostaPacienteConta ;
      private bool[] T001A118_n584PropostaPacienteConta ;
      private string[] T001A118_A585PropostaPacienteAgencia ;
      private bool[] T001A118_n585PropostaPacienteAgencia ;
      private string[] T001A118_A586PropostaPacienteTipoPix ;
      private bool[] T001A118_n586PropostaPacienteTipoPix ;
      private string[] T001A118_A587PropostaPacientePIX ;
      private bool[] T001A118_n587PropostaPacientePIX ;
      private string[] T001A118_A588PropostaPacienteDepositoTipo ;
      private bool[] T001A118_n588PropostaPacienteDepositoTipo ;
      private string[] T001A118_A620PropostaPacienteEnderecoCEP ;
      private bool[] T001A118_n620PropostaPacienteEnderecoCEP ;
      private string[] T001A118_A621PropostaPacienteEnderecoLogradouro ;
      private bool[] T001A118_n621PropostaPacienteEnderecoLogradouro ;
      private string[] T001A118_A622PropostaPacienteEnderecoNumero ;
      private bool[] T001A118_n622PropostaPacienteEnderecoNumero ;
      private string[] T001A118_A623PropostaPacienteEnderecoComplemento ;
      private bool[] T001A118_n623PropostaPacienteEnderecoComplemento ;
      private string[] T001A118_A624PropostaPacienteEnderecoBairro ;
      private bool[] T001A118_n624PropostaPacienteEnderecoBairro ;
      private string[] T001A118_A625PropostaPacienteMunicipioCodigo ;
      private bool[] T001A118_n625PropostaPacienteMunicipioCodigo ;
      private decimal[] T001A121_A509PropostaValorReembolsado_F ;
      private bool[] T001A121_n509PropostaValorReembolsado_F ;
      private decimal[] T001A124_A510PropostaValorReembolsadoJuros_F ;
      private bool[] T001A124_n510PropostaValorReembolsadoJuros_F ;
      private DateTime[] T001A127_A515PropostaDataCreditoCliente_F ;
      private bool[] T001A127_n515PropostaDataCreditoCliente_F ;
      private short[] T001A129_A733PropostaResponsavelSerasaConsultas_F ;
      private bool[] T001A129_n733PropostaResponsavelSerasaConsultas_F ;
      private short[] T001A129_A734PropostaPacienteSerasaConsultas_F ;
      private bool[] T001A129_n734PropostaPacienteSerasaConsultas_F ;
      private short[] T001A132_A783PropostaResponsavelSerasaScoreUltimaData_F ;
      private bool[] T001A132_n783PropostaResponsavelSerasaScoreUltimaData_F ;
      private short[] T001A132_A782PropostaSerasaScoreUltimaData_F ;
      private bool[] T001A132_n782PropostaSerasaScoreUltimaData_F ;
      private decimal[] T001A135_A786PropostaResponsavelSerasaUltimoValorRecomendado_F ;
      private bool[] T001A135_n786PropostaResponsavelSerasaUltimoValorRecomendado_F ;
      private decimal[] T001A135_A787PropostaPacienteSerasaUltimoValorRecomendado_F ;
      private bool[] T001A135_n787PropostaPacienteSerasaUltimoValorRecomendado_F ;
      private string[] T001A136_A580PropostaResponsavelDocumento ;
      private bool[] T001A136_n580PropostaResponsavelDocumento ;
      private string[] T001A136_A581PropostaResponsavelRazaoSocial ;
      private bool[] T001A136_n581PropostaResponsavelRazaoSocial ;
      private string[] T001A136_A582PropostaResponsavelEmail ;
      private bool[] T001A136_n582PropostaResponsavelEmail ;
      private string[] T001A136_A590PropostaResponsavelConta ;
      private bool[] T001A136_n590PropostaResponsavelConta ;
      private string[] T001A136_A591PropostaResponsavelAgencia ;
      private bool[] T001A136_n591PropostaResponsavelAgencia ;
      private string[] T001A136_A592PropostaResponsavelTipoPix ;
      private bool[] T001A136_n592PropostaResponsavelTipoPix ;
      private string[] T001A136_A593PropostaResponsavelPIX ;
      private bool[] T001A136_n593PropostaResponsavelPIX ;
      private string[] T001A136_A594PropostaResponsavelDepositoTipo ;
      private bool[] T001A136_n594PropostaResponsavelDepositoTipo ;
      private string[] T001A137_A643PropostaClinicaNome ;
      private bool[] T001A137_n643PropostaClinicaNome ;
      private string[] T001A137_A644PropostaClinicaNomeFantasia ;
      private bool[] T001A137_n644PropostaClinicaNomeFantasia ;
      private string[] T001A137_A652PropostaClinicaDocumento ;
      private bool[] T001A137_n652PropostaClinicaDocumento ;
      private string[] T001A137_A653PropostaClinicaEmail ;
      private bool[] T001A137_n653PropostaClinicaEmail ;
      private decimal[] T001A139_A650PropostaValorTaxaClinica_F ;
      private bool[] T001A139_n650PropostaValorTaxaClinica_F ;
      private int[] T001A140_A227ContratoId ;
      private bool[] T001A140_n227ContratoId ;
      private int[] T001A141_A518ReembolsoId ;
      private int[] T001A142_A261TituloId ;
      private bool[] T001A142_n261TituloId ;
      private Guid[] T001A143_A830NotaFiscalItemId ;
      private int[] T001A144_A572PropostaContratoAssinaturaId ;
      private int[] T001A145_A414PropostaDocumentosId ;
      private int[] T001A146_A336AprovacaoId ;
      private int[] T001A147_A323PropostaId ;
      private bool[] T001A147_n323PropostaId ;
      private int[] T001A148_A376ProcedimentosMedicosId ;
      private bool[] T001A148_n376ProcedimentosMedicosId ;
   }

   public class proposta__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
         ,new ForEachCursor(def[27])
         ,new ForEachCursor(def[28])
         ,new ForEachCursor(def[29])
         ,new ForEachCursor(def[30])
         ,new ForEachCursor(def[31])
         ,new ForEachCursor(def[32])
         ,new ForEachCursor(def[33])
         ,new ForEachCursor(def[34])
         ,new ForEachCursor(def[35])
         ,new ForEachCursor(def[36])
         ,new ForEachCursor(def[37])
         ,new ForEachCursor(def[38])
         ,new ForEachCursor(def[39])
         ,new ForEachCursor(def[40])
         ,new ForEachCursor(def[41])
         ,new ForEachCursor(def[42])
         ,new ForEachCursor(def[43])
         ,new ForEachCursor(def[44])
         ,new ForEachCursor(def[45])
         ,new ForEachCursor(def[46])
         ,new ForEachCursor(def[47])
         ,new UpdateCursor(def[48])
         ,new ForEachCursor(def[49])
         ,new UpdateCursor(def[50])
         ,new UpdateCursor(def[51])
         ,new ForEachCursor(def[52])
         ,new ForEachCursor(def[53])
         ,new ForEachCursor(def[54])
         ,new ForEachCursor(def[55])
         ,new ForEachCursor(def[56])
         ,new ForEachCursor(def[57])
         ,new ForEachCursor(def[58])
         ,new ForEachCursor(def[59])
         ,new ForEachCursor(def[60])
         ,new ForEachCursor(def[61])
         ,new ForEachCursor(def[62])
         ,new ForEachCursor(def[63])
         ,new ForEachCursor(def[64])
         ,new ForEachCursor(def[65])
         ,new ForEachCursor(def[66])
         ,new ForEachCursor(def[67])
         ,new ForEachCursor(def[68])
         ,new ForEachCursor(def[69])
         ,new ForEachCursor(def[70])
         ,new ForEachCursor(def[71])
         ,new ForEachCursor(def[72])
         ,new ForEachCursor(def[73])
         ,new ForEachCursor(def[74])
         ,new ForEachCursor(def[75])
         ,new ForEachCursor(def[76])
         ,new ForEachCursor(def[77])
         ,new ForEachCursor(def[78])
         ,new ForEachCursor(def[79])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT001A2;
          prmT001A2 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A3;
          prmT001A3 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A4;
          prmT001A4 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT001A5;
          prmT001A5 = new Object[] {
          new ParDef("ProcedimentosMedicosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A6;
          prmT001A6 = new Object[] {
          new ParDef("ConvenioCategoriaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A7;
          prmT001A7 = new Object[] {
          new ParDef("PropostaCratedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT001A8;
          prmT001A8 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A9;
          prmT001A9 = new Object[] {
          new ParDef("PropostaResponsavelId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A10;
          prmT001A10 = new Object[] {
          new ParDef("PropostaClinicaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A11;
          prmT001A11 = new Object[] {
          new ParDef("PropostaEmpresaClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A27;
          prmT001A27 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A29;
          prmT001A29 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A31;
          prmT001A31 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A34;
          prmT001A34 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A37;
          prmT001A37 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A39;
          prmT001A39 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A41;
          prmT001A41 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A43;
          prmT001A43 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A25;
          prmT001A25 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaClinicaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A54;
          prmT001A54 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          string cmdBufferT001A54;
          cmdBufferT001A54=" SELECT TM1.PropostaId, TM1.PropostaCreatedAt, TM1.PropostaProtocolo, TM1.PropostaTipoProposta, T8.ClienteDocumento AS PropostaResponsavelDocumento, T8.ClienteRazaoSocial AS PropostaResponsavelRazaoSocial, T8.ContatoEmail AS PropostaResponsavelEmail, T8.ContaNumero AS PropostaResponsavelConta, T8.ContaAgencia AS PropostaResponsavelAgencia, T8.ClientePixTipo AS PropostaResponsavelTipoPix, T8.ClientePix AS PropostaResponsavelPIX, T8.ClienteDepositoTipo AS PropostaResponsavelDepositoTipo, T4.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T4.ClienteDocumento AS PropostaPacienteClienteDocumento, T4.ContatoEmail AS PropostaPacienteContatoEmail, T4.ContaNumero AS PropostaPacienteConta, T4.ContaAgencia AS PropostaPacienteAgencia, T4.ClientePixTipo AS PropostaPacienteTipoPix, T4.ClientePix AS PropostaPacientePIX, T4.ClienteDepositoTipo AS PropostaPacienteDepositoTipo, T4.EnderecoCEP AS PropostaPacienteEnderecoCEP, T4.EnderecoLogradouro AS PropostaPacienteEnderecoLogradouro, T4.EnderecoNumero AS PropostaPacienteEnderecoNumero, T4.EnderecoComplemento AS PropostaPacienteEnderecoComplemento, T4.EnderecoBairro AS PropostaPacienteEnderecoBairro, TM1.PropostaTitulo, TM1.PropostaDescricao, TM1.PropostaDataCirurgia, TM1.PropostaValor, TM1.PropostaValorLiquido, TM1.PropostaTaxaAdministrativa, TM1.PropostaSLA, TM1.PropostaJurosMora, T9.ClienteRazaoSocial AS PropostaClinicaNome, T9.ClienteNomeFantasia AS PropostaClinicaNomeFantasia, T9.ClienteDocumento AS PropostaClinicaDocumento, T9.ContatoEmail AS PropostaClinicaEmail, T15.SecUserFullName AS PropostaSecUserName, TM1.PropostaStatus, TM1.PropostaComentarioAnalise, TM1.PropostaQuantidadeAprovadores, TM1.PropostaReprovacoesPermitidas, T2.ContratoNome, TM1.ConvenioVencimentoAno, TM1.ConvenioVencimentoMes, T3.ConvenioCategoriaDescricao, "
          + " TM1.ContratoId, TM1.ProcedimentosMedicosId, TM1.ConvenioCategoriaId, TM1.PropostaCratedBy AS PropostaCratedBy, TM1.PropostaPacienteClienteId AS PropostaPacienteClienteId, TM1.PropostaResponsavelId AS PropostaResponsavelId, TM1.PropostaClinicaId AS PropostaClinicaId, TM1.PropostaEmpresaClienteId AS PropostaEmpresaClienteId, T3.ConvenioId, T4.MunicipioCodigo AS PropostaPacienteMunicipioCodigo, COALESCE( T10.PropostaMaxReembolsoId_F, 0) AS PropostaMaxReembolsoId_F, COALESCE( T11.PropostaQtdItensNota_F, 0) AS PropostaQtdItensNota_F, COALESCE( T5.PropostaResponsavelSerasaConsultas_F, 0) AS PropostaResponsavelSerasaConsultas_F, COALESCE( T6.PropostaResponsavelSerasaScoreUltimaData_F, 0) AS PropostaResponsavelSerasaScoreUltimaData_F, COALESCE( T7.PropostaResponsavelSerasaUltimoValorRecomendado_F, 0) AS PropostaResponsavelSerasaUltimoValorRecomendado_F, COALESCE( T5.PropostaResponsavelSerasaConsultas_F, 0) AS PropostaPacienteSerasaConsultas_F, COALESCE( T6.PropostaResponsavelSerasaScoreUltimaData_F, 0) AS PropostaSerasaScoreUltimaData_F, COALESCE( T7.PropostaResponsavelSerasaUltimoValorRecomendado_F, 0) AS PropostaPacienteSerasaUltimoValorRecomendado_F, COALESCE( T12.PropostaQtdDocumentoPendente_F, 0) AS PropostaQtdDocumentoPendente_F, COALESCE( T13.PropostaAprovacoes_F, 0) AS PropostaAprovacoes_F, COALESCE( T14.PropostaAprovacoes_F, 0) AS PropostaReprovacoes_F FROM ((((((((((((((Proposta TM1 LEFT JOIN Contrato T2 ON T2.ContratoId = TM1.ContratoId) LEFT JOIN ConvenioCategoria T3 ON T3.ConvenioCategoriaId = TM1.ConvenioCategoriaId) LEFT JOIN Cliente T4 ON T4.ClienteId = TM1.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaResponsavelSerasaConsultas_F, ClienteId FROM Serasa WHERE TM1.PropostaPacienteClienteId = ClienteId GROUP BY ClienteId ) T5 ON T5.ClienteId"
          + " = TM1.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT MAX(T16.SerasaScore) AS PropostaResponsavelSerasaScoreUltimaData_F, COALESCE( T17.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, T16.ClienteId FROM (Serasa T16 LEFT JOIN LATERAL (SELECT MAX(SerasaCreatedAt) AS SerasaUltimaData_F, ClienteId FROM Serasa WHERE T16.ClienteId = ClienteId GROUP BY ClienteId ) T17 ON T17.ClienteId = T16.ClienteId) WHERE (TM1.PropostaPacienteClienteId = T16.ClienteId) AND (T16.SerasaCreatedAt = COALESCE( T17.SerasaUltimaData_F, DATE '00010101')) GROUP BY T17.SerasaUltimaData_F, T16.ClienteId ) T6 ON T6.ClienteId = TM1.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT MAX(T16.SerasaValorLimiteRecomendado) AS PropostaResponsavelSerasaUltimoValorRecomendado_F, COALESCE( T17.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, T16.ClienteId FROM (Serasa T16 LEFT JOIN LATERAL (SELECT MAX(SerasaCreatedAt) AS SerasaUltimaData_F, ClienteId FROM Serasa WHERE T16.ClienteId = ClienteId GROUP BY ClienteId ) T17 ON T17.ClienteId = T16.ClienteId) WHERE (TM1.PropostaPacienteClienteId = T16.ClienteId) AND (T16.SerasaCreatedAt = COALESCE( T17.SerasaUltimaData_F, DATE '00010101')) GROUP BY T17.SerasaUltimaData_F, T16.ClienteId ) T7 ON T7.ClienteId = TM1.PropostaPacienteClienteId) LEFT JOIN Cliente T8 ON T8.ClienteId = TM1.PropostaResponsavelId) LEFT JOIN Cliente T9 ON T9.ClienteId = TM1.PropostaClinicaId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoId) AS PropostaMaxReembolsoId_F, ReembolsoPropostaId FROM Reembolso WHERE TM1.PropostaId = ReembolsoPropostaId GROUP BY ReembolsoPropostaId ) T10 ON T10.ReembolsoPropostaId = TM1.PropostaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaQtdItensNota_F, PropostaId FROM NotaFiscalItem WHERE TM1.PropostaId = PropostaId GROUP BY PropostaId ) T11"
          + " ON T11.PropostaId = TM1.PropostaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaQtdDocumentoPendente_F, PropostaId FROM PropostaDocumentos WHERE (TM1.PropostaId = PropostaId) AND (PropostaDocumentosStatus = ( 'AGUARDANDO_ANALISE') or PropostaDocumentosStatus = ( 'REPROVADO')) GROUP BY PropostaId ) T12 ON T12.PropostaId = TM1.PropostaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE (TM1.PropostaId = PropostaId) AND (AprovacaoStatus = ( 'APROVADO')) GROUP BY PropostaId ) T13 ON T13.PropostaId = TM1.PropostaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE (TM1.PropostaId = PropostaId) AND (AprovacaoStatus = ( 'REPROVADO')) GROUP BY PropostaId ) T14 ON T14.PropostaId = TM1.PropostaId) LEFT JOIN SecUser T15 ON T15.SecUserId = TM1.PropostaCratedBy) WHERE TM1.PropostaId = :PropostaId ORDER BY TM1.PropostaId" ;
          Object[] prmT001A14;
          prmT001A14 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A17;
          prmT001A17 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A20;
          prmT001A20 = new Object[] {
          new ParDef("PropostaCratedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A23;
          prmT001A23 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A57;
          prmT001A57 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A60;
          prmT001A60 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A63;
          prmT001A63 = new Object[] {
          new ParDef("PropostaCratedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A66;
          prmT001A66 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A68;
          prmT001A68 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaClinicaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A70;
          prmT001A70 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A72;
          prmT001A72 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A74;
          prmT001A74 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A76;
          prmT001A76 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A78;
          prmT001A78 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A79;
          prmT001A79 = new Object[] {
          new ParDef("ProcedimentosMedicosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A80;
          prmT001A80 = new Object[] {
          new ParDef("PropostaCratedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT001A81;
          prmT001A81 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT001A82;
          prmT001A82 = new Object[] {
          new ParDef("ConvenioCategoriaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A83;
          prmT001A83 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A85;
          prmT001A85 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A88;
          prmT001A88 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A91;
          prmT001A91 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A92;
          prmT001A92 = new Object[] {
          new ParDef("PropostaResponsavelId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A93;
          prmT001A93 = new Object[] {
          new ParDef("PropostaClinicaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A94;
          prmT001A94 = new Object[] {
          new ParDef("PropostaEmpresaClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A95;
          prmT001A95 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A96;
          prmT001A96 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A97;
          prmT001A97 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A98;
          prmT001A98 = new Object[] {
          new ParDef("PropostaCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("PropostaProtocolo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("PropostaTipoProposta",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("PropostaTitulo",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("PropostaDescricao",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("PropostaDataCirurgia",GXType.Date,8,0){Nullable=true} ,
          new ParDef("PropostaValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("PropostaValorLiquido",GXType.Number,18,2){Nullable=true} ,
          new ParDef("PropostaTaxaAdministrativa",GXType.Number,16,4){Nullable=true} ,
          new ParDef("PropostaSLA",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("PropostaJurosMora",GXType.Number,16,4){Nullable=true} ,
          new ParDef("PropostaStatus",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("PropostaComentarioAnalise",GXType.VarChar,255,0){Nullable=true} ,
          new ParDef("PropostaQuantidadeAprovadores",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("PropostaReprovacoesPermitidas",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ConvenioVencimentoAno",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ConvenioVencimentoMes",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("ProcedimentosMedicosId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ConvenioCategoriaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaCratedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaResponsavelId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaClinicaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaEmpresaClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A99;
          prmT001A99 = new Object[] {
          };
          Object[] prmT001A100;
          prmT001A100 = new Object[] {
          new ParDef("PropostaCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("PropostaProtocolo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("PropostaTipoProposta",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("PropostaTitulo",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("PropostaDescricao",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("PropostaDataCirurgia",GXType.Date,8,0){Nullable=true} ,
          new ParDef("PropostaValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("PropostaValorLiquido",GXType.Number,18,2){Nullable=true} ,
          new ParDef("PropostaTaxaAdministrativa",GXType.Number,16,4){Nullable=true} ,
          new ParDef("PropostaSLA",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("PropostaJurosMora",GXType.Number,16,4){Nullable=true} ,
          new ParDef("PropostaStatus",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("PropostaComentarioAnalise",GXType.VarChar,255,0){Nullable=true} ,
          new ParDef("PropostaQuantidadeAprovadores",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("PropostaReprovacoesPermitidas",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ConvenioVencimentoAno",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ConvenioVencimentoMes",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("ProcedimentosMedicosId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ConvenioCategoriaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaCratedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaResponsavelId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaClinicaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaEmpresaClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A101;
          prmT001A101 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A103;
          prmT001A103 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A105;
          prmT001A105 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A107;
          prmT001A107 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A109;
          prmT001A109 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A111;
          prmT001A111 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A112;
          prmT001A112 = new Object[] {
          new ParDef("PropostaCratedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT001A115;
          prmT001A115 = new Object[] {
          new ParDef("PropostaCratedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A116;
          prmT001A116 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT001A117;
          prmT001A117 = new Object[] {
          new ParDef("ConvenioCategoriaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A118;
          prmT001A118 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A121;
          prmT001A121 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A124;
          prmT001A124 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A127;
          prmT001A127 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A129;
          prmT001A129 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A132;
          prmT001A132 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A135;
          prmT001A135 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A136;
          prmT001A136 = new Object[] {
          new ParDef("PropostaResponsavelId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A137;
          prmT001A137 = new Object[] {
          new ParDef("PropostaClinicaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A139;
          prmT001A139 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaClinicaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A140;
          prmT001A140 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A141;
          prmT001A141 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A142;
          prmT001A142 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A143;
          prmT001A143 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A144;
          prmT001A144 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A145;
          prmT001A145 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A146;
          prmT001A146 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001A147;
          prmT001A147 = new Object[] {
          };
          Object[] prmT001A148;
          prmT001A148 = new Object[] {
          new ParDef("ProcedimentosMedicosId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T001A2", "SELECT PropostaId, PropostaCreatedAt, PropostaProtocolo, PropostaTipoProposta, PropostaTitulo, PropostaDescricao, PropostaDataCirurgia, PropostaValor, PropostaValorLiquido, PropostaTaxaAdministrativa, PropostaSLA, PropostaJurosMora, PropostaStatus, PropostaComentarioAnalise, PropostaQuantidadeAprovadores, PropostaReprovacoesPermitidas, ConvenioVencimentoAno, ConvenioVencimentoMes, ContratoId, ProcedimentosMedicosId, ConvenioCategoriaId, PropostaCratedBy, PropostaPacienteClienteId, PropostaResponsavelId, PropostaClinicaId, PropostaEmpresaClienteId FROM Proposta WHERE PropostaId = :PropostaId  FOR UPDATE OF Proposta NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001A2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A3", "SELECT PropostaId, PropostaCreatedAt, PropostaProtocolo, PropostaTipoProposta, PropostaTitulo, PropostaDescricao, PropostaDataCirurgia, PropostaValor, PropostaValorLiquido, PropostaTaxaAdministrativa, PropostaSLA, PropostaJurosMora, PropostaStatus, PropostaComentarioAnalise, PropostaQuantidadeAprovadores, PropostaReprovacoesPermitidas, ConvenioVencimentoAno, ConvenioVencimentoMes, ContratoId, ProcedimentosMedicosId, ConvenioCategoriaId, PropostaCratedBy, PropostaPacienteClienteId, PropostaResponsavelId, PropostaClinicaId, PropostaEmpresaClienteId FROM Proposta WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A4", "SELECT ContratoNome FROM Contrato WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A5", "SELECT ProcedimentosMedicosId FROM ProcedimentosMedicos WHERE ProcedimentosMedicosId = :ProcedimentosMedicosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A6", "SELECT ConvenioCategoriaDescricao, ConvenioId FROM ConvenioCategoria WHERE ConvenioCategoriaId = :ConvenioCategoriaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A7", "SELECT SecUserFullName AS PropostaSecUserName FROM SecUser WHERE SecUserId = :PropostaCratedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A8", "SELECT ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, ClienteDocumento AS PropostaPacienteClienteDocumento, ContatoEmail AS PropostaPacienteContatoEmail, ContaNumero AS PropostaPacienteConta, ContaAgencia AS PropostaPacienteAgencia, ClientePixTipo AS PropostaPacienteTipoPix, ClientePix AS PropostaPacientePIX, ClienteDepositoTipo AS PropostaPacienteDepositoTipo, EnderecoCEP AS PropostaPacienteEnderecoCEP, EnderecoLogradouro AS PropostaPacienteEnderecoLogradouro, EnderecoNumero AS PropostaPacienteEnderecoNumero, EnderecoComplemento AS PropostaPacienteEnderecoComplemento, EnderecoBairro AS PropostaPacienteEnderecoBairro, MunicipioCodigo AS PropostaPacienteMunicipioCodigo FROM Cliente WHERE ClienteId = :PropostaPacienteClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A9", "SELECT ClienteDocumento AS PropostaResponsavelDocumento, ClienteRazaoSocial AS PropostaResponsavelRazaoSocial, ContatoEmail AS PropostaResponsavelEmail, ContaNumero AS PropostaResponsavelConta, ContaAgencia AS PropostaResponsavelAgencia, ClientePixTipo AS PropostaResponsavelTipoPix, ClientePix AS PropostaResponsavelPIX, ClienteDepositoTipo AS PropostaResponsavelDepositoTipo FROM Cliente WHERE ClienteId = :PropostaResponsavelId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A10", "SELECT ClienteRazaoSocial AS PropostaClinicaNome, ClienteNomeFantasia AS PropostaClinicaNomeFantasia, ClienteDocumento AS PropostaClinicaDocumento, ContatoEmail AS PropostaClinicaEmail FROM Cliente WHERE ClienteId = :PropostaClinicaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A11", "SELECT ClienteId AS PropostaEmpresaClienteId FROM Cliente WHERE ClienteId = :PropostaEmpresaClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A14", "SELECT COALESCE( T1.PropostaValorReembolsado_F, 0) AS PropostaValorReembolsado_F FROM (SELECT SUM(COALESCE( T5.TituloTotalMovimento_F, 0)) AS PropostaValorReembolsado_F, T2.TituloPropostaId FROM (((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T2.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T5 ON T5.TituloId = T2.TituloId) WHERE (T4.ClienteId = :PropostaPacienteClienteId) AND (T2.TituloPropostaId = :PropostaId) GROUP BY T2.TituloPropostaId ) T1 WHERE T1.TituloPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A14,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A17", "SELECT COALESCE( T1.PropostaValorReembolsadoJuros_F, 0) AS PropostaValorReembolsadoJuros_F FROM (SELECT SUM(COALESCE( T5.TituloTotalMovimento_F, 0)) AS PropostaValorReembolsadoJuros_F, T2.TituloPropostaId FROM (((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T2.TituloId = TituloId) AND (Not TituloMovimentoSoma) GROUP BY TituloId ) T5 ON T5.TituloId = T2.TituloId) WHERE (T4.ClienteId = :PropostaPacienteClienteId) AND (T2.TituloPropostaId = :PropostaId) GROUP BY T2.TituloPropostaId ) T1 WHERE T1.TituloPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A17,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A20", "SELECT COALESCE( T1.PropostaValorReembolsado_F, 0) AS PropostaValorTaxaRecebida_F FROM (SELECT SUM(COALESCE( T5.TituloTotalMovimento_F, 0)) AS PropostaValorReembolsado_F, T2.TituloPropostaId FROM (((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T2.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T5 ON T5.TituloId = T2.TituloId) WHERE (T4.ClienteId = :PropostaCratedBy) AND (T2.TituloPropostaId = :PropostaId) GROUP BY T2.TituloPropostaId ) T1 WHERE T1.TituloPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A20,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A23", "SELECT COALESCE( T1.PropostaDataCreditoCliente_F, DATE '00010101') AS PropostaDataCreditoCliente_F FROM (SELECT MAX(COALESCE( T5.TituloDataCredito_F, DATE '00010101')) AS PropostaDataCreditoCliente_F, T2.TituloPropostaId FROM (((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN LATERAL (SELECT MAX(TituloMovimentoDataCredito) AS TituloDataCredito_F, TituloId FROM TituloMovimento WHERE T2.TituloId = TituloId GROUP BY TituloId ) T5 ON T5.TituloId = T2.TituloId) WHERE (T4.ClienteId = :PropostaPacienteClienteId) AND (T2.TituloPropostaId = :PropostaId) AND (T2.TituloTipo = ( 'DEBITO')) GROUP BY T2.TituloPropostaId ) T1 WHERE T1.TituloPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A23,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A25", "SELECT COALESCE( T1.PropostaValorTaxaClinica_F, 0) AS PropostaValorTaxaClinica_F FROM (SELECT SUM(T2.TituloValor) AS PropostaValorTaxaClinica_F, T2.TituloPropostaId FROM ((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) WHERE (T2.TituloPropostaTipo = ( 'TAXA')) AND (T2.TituloPropostaId = :PropostaId) AND (T4.ClienteId = :PropostaClinicaId) GROUP BY T2.TituloPropostaId ) T1 WHERE T1.TituloPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A25,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A27", "SELECT COALESCE( T1.PropostaMaxReembolsoId_F, 0) AS PropostaMaxReembolsoId_F FROM (SELECT MAX(ReembolsoId) AS PropostaMaxReembolsoId_F, ReembolsoPropostaId FROM Reembolso GROUP BY ReembolsoPropostaId ) T1 WHERE T1.ReembolsoPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A27,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A29", "SELECT COALESCE( T1.PropostaQtdItensNota_F, 0) AS PropostaQtdItensNota_F FROM (SELECT COUNT(*) AS PropostaQtdItensNota_F, PropostaId FROM NotaFiscalItem GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A29,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A31", "SELECT COALESCE( T1.PropostaResponsavelSerasaConsultas_F, 0) AS PropostaResponsavelSerasaConsultas_F, COALESCE( T1.PropostaResponsavelSerasaConsultas_F, 0) AS PropostaPacienteSerasaConsultas_F FROM (SELECT COUNT(*) AS PropostaResponsavelSerasaConsultas_F, ClienteId FROM Serasa GROUP BY ClienteId ) T1 WHERE T1.ClienteId = :PropostaPacienteClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A31,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A34", "SELECT COALESCE( T1.PropostaResponsavelSerasaScoreUltimaData_F, 0) AS PropostaResponsavelSerasaScoreUltimaData_F, COALESCE( T1.PropostaResponsavelSerasaScoreUltimaData_F, 0) AS PropostaSerasaScoreUltimaData_F FROM (SELECT MAX(T2.SerasaScore) AS PropostaResponsavelSerasaScoreUltimaData_F, COALESCE( T3.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, T2.ClienteId FROM (Serasa T2 LEFT JOIN LATERAL (SELECT MAX(SerasaCreatedAt) AS SerasaUltimaData_F, ClienteId FROM Serasa WHERE T2.ClienteId = ClienteId GROUP BY ClienteId ) T3 ON T3.ClienteId = T2.ClienteId) WHERE T2.SerasaCreatedAt = COALESCE( T3.SerasaUltimaData_F, DATE '00010101') GROUP BY T3.SerasaUltimaData_F, T2.ClienteId ) T1 WHERE T1.ClienteId = :PropostaPacienteClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A34,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A37", "SELECT COALESCE( T1.PropostaResponsavelSerasaUltimoValorRecomendado_F, 0) AS PropostaResponsavelSerasaUltimoValorRecomendado_F, COALESCE( T1.PropostaResponsavelSerasaUltimoValorRecomendado_F, 0) AS PropostaPacienteSerasaUltimoValorRecomendado_F FROM (SELECT MAX(T2.SerasaValorLimiteRecomendado) AS PropostaResponsavelSerasaUltimoValorRecomendado_F, COALESCE( T3.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, T2.ClienteId FROM (Serasa T2 LEFT JOIN LATERAL (SELECT MAX(SerasaCreatedAt) AS SerasaUltimaData_F, ClienteId FROM Serasa WHERE T2.ClienteId = ClienteId GROUP BY ClienteId ) T3 ON T3.ClienteId = T2.ClienteId) WHERE T2.SerasaCreatedAt = COALESCE( T3.SerasaUltimaData_F, DATE '00010101') GROUP BY T3.SerasaUltimaData_F, T2.ClienteId ) T1 WHERE T1.ClienteId = :PropostaPacienteClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A37,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A39", "SELECT COALESCE( T1.PropostaQtdDocumentoPendente_F, 0) AS PropostaQtdDocumentoPendente_F FROM (SELECT COUNT(*) AS PropostaQtdDocumentoPendente_F, PropostaId FROM PropostaDocumentos WHERE PropostaDocumentosStatus = ( 'AGUARDANDO_ANALISE') or PropostaDocumentosStatus = ( 'REPROVADO') GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A39,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A41", "SELECT COALESCE( T1.PropostaAprovacoes_F, 0) AS PropostaAprovacoes_F FROM (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE AprovacaoStatus = ( 'APROVADO') GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A41,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A43", "SELECT COALESCE( T1.PropostaAprovacoes_F, 0) AS PropostaReprovacoes_F FROM (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE AprovacaoStatus = ( 'REPROVADO') GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A43,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A54", cmdBufferT001A54,true, GxErrorMask.GX_NOMASK, false, this,prmT001A54,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A57", "SELECT COALESCE( T1.PropostaValorReembolsado_F, 0) AS PropostaValorReembolsado_F FROM (SELECT SUM(COALESCE( T5.TituloTotalMovimento_F, 0)) AS PropostaValorReembolsado_F, T2.TituloPropostaId FROM (((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T2.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T5 ON T5.TituloId = T2.TituloId) WHERE (T4.ClienteId = :PropostaPacienteClienteId) AND (T2.TituloPropostaId = :PropostaId) GROUP BY T2.TituloPropostaId ) T1 WHERE T1.TituloPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A57,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A60", "SELECT COALESCE( T1.PropostaValorReembolsadoJuros_F, 0) AS PropostaValorReembolsadoJuros_F FROM (SELECT SUM(COALESCE( T5.TituloTotalMovimento_F, 0)) AS PropostaValorReembolsadoJuros_F, T2.TituloPropostaId FROM (((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T2.TituloId = TituloId) AND (Not TituloMovimentoSoma) GROUP BY TituloId ) T5 ON T5.TituloId = T2.TituloId) WHERE (T4.ClienteId = :PropostaPacienteClienteId) AND (T2.TituloPropostaId = :PropostaId) GROUP BY T2.TituloPropostaId ) T1 WHERE T1.TituloPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A60,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A63", "SELECT COALESCE( T1.PropostaValorReembolsado_F, 0) AS PropostaValorTaxaRecebida_F FROM (SELECT SUM(COALESCE( T5.TituloTotalMovimento_F, 0)) AS PropostaValorReembolsado_F, T2.TituloPropostaId FROM (((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T2.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T5 ON T5.TituloId = T2.TituloId) WHERE (T4.ClienteId = :PropostaCratedBy) AND (T2.TituloPropostaId = :PropostaId) GROUP BY T2.TituloPropostaId ) T1 WHERE T1.TituloPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A63,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A66", "SELECT COALESCE( T1.PropostaDataCreditoCliente_F, DATE '00010101') AS PropostaDataCreditoCliente_F FROM (SELECT MAX(COALESCE( T5.TituloDataCredito_F, DATE '00010101')) AS PropostaDataCreditoCliente_F, T2.TituloPropostaId FROM (((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN LATERAL (SELECT MAX(TituloMovimentoDataCredito) AS TituloDataCredito_F, TituloId FROM TituloMovimento WHERE T2.TituloId = TituloId GROUP BY TituloId ) T5 ON T5.TituloId = T2.TituloId) WHERE (T4.ClienteId = :PropostaPacienteClienteId) AND (T2.TituloPropostaId = :PropostaId) AND (T2.TituloTipo = ( 'DEBITO')) GROUP BY T2.TituloPropostaId ) T1 WHERE T1.TituloPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A66,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A68", "SELECT COALESCE( T1.PropostaValorTaxaClinica_F, 0) AS PropostaValorTaxaClinica_F FROM (SELECT SUM(T2.TituloValor) AS PropostaValorTaxaClinica_F, T2.TituloPropostaId FROM ((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) WHERE (T2.TituloPropostaTipo = ( 'TAXA')) AND (T2.TituloPropostaId = :PropostaId) AND (T4.ClienteId = :PropostaClinicaId) GROUP BY T2.TituloPropostaId ) T1 WHERE T1.TituloPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A68,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A70", "SELECT COALESCE( T1.PropostaMaxReembolsoId_F, 0) AS PropostaMaxReembolsoId_F FROM (SELECT MAX(ReembolsoId) AS PropostaMaxReembolsoId_F, ReembolsoPropostaId FROM Reembolso GROUP BY ReembolsoPropostaId ) T1 WHERE T1.ReembolsoPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A70,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A72", "SELECT COALESCE( T1.PropostaQtdItensNota_F, 0) AS PropostaQtdItensNota_F FROM (SELECT COUNT(*) AS PropostaQtdItensNota_F, PropostaId FROM NotaFiscalItem GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A72,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A74", "SELECT COALESCE( T1.PropostaQtdDocumentoPendente_F, 0) AS PropostaQtdDocumentoPendente_F FROM (SELECT COUNT(*) AS PropostaQtdDocumentoPendente_F, PropostaId FROM PropostaDocumentos WHERE PropostaDocumentosStatus = ( 'AGUARDANDO_ANALISE') or PropostaDocumentosStatus = ( 'REPROVADO') GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A74,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A76", "SELECT COALESCE( T1.PropostaAprovacoes_F, 0) AS PropostaAprovacoes_F FROM (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE AprovacaoStatus = ( 'APROVADO') GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A76,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A78", "SELECT COALESCE( T1.PropostaAprovacoes_F, 0) AS PropostaReprovacoes_F FROM (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE AprovacaoStatus = ( 'REPROVADO') GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A78,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A79", "SELECT ProcedimentosMedicosId FROM ProcedimentosMedicos WHERE ProcedimentosMedicosId = :ProcedimentosMedicosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A79,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A80", "SELECT SecUserFullName AS PropostaSecUserName FROM SecUser WHERE SecUserId = :PropostaCratedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A80,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A81", "SELECT ContratoNome FROM Contrato WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A81,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A82", "SELECT ConvenioCategoriaDescricao, ConvenioId FROM ConvenioCategoria WHERE ConvenioCategoriaId = :ConvenioCategoriaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A82,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A83", "SELECT ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, ClienteDocumento AS PropostaPacienteClienteDocumento, ContatoEmail AS PropostaPacienteContatoEmail, ContaNumero AS PropostaPacienteConta, ContaAgencia AS PropostaPacienteAgencia, ClientePixTipo AS PropostaPacienteTipoPix, ClientePix AS PropostaPacientePIX, ClienteDepositoTipo AS PropostaPacienteDepositoTipo, EnderecoCEP AS PropostaPacienteEnderecoCEP, EnderecoLogradouro AS PropostaPacienteEnderecoLogradouro, EnderecoNumero AS PropostaPacienteEnderecoNumero, EnderecoComplemento AS PropostaPacienteEnderecoComplemento, EnderecoBairro AS PropostaPacienteEnderecoBairro, MunicipioCodigo AS PropostaPacienteMunicipioCodigo FROM Cliente WHERE ClienteId = :PropostaPacienteClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A83,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A85", "SELECT COALESCE( T1.PropostaResponsavelSerasaConsultas_F, 0) AS PropostaResponsavelSerasaConsultas_F, COALESCE( T1.PropostaResponsavelSerasaConsultas_F, 0) AS PropostaPacienteSerasaConsultas_F FROM (SELECT COUNT(*) AS PropostaResponsavelSerasaConsultas_F, ClienteId FROM Serasa GROUP BY ClienteId ) T1 WHERE T1.ClienteId = :PropostaPacienteClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A85,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A88", "SELECT COALESCE( T1.PropostaResponsavelSerasaScoreUltimaData_F, 0) AS PropostaResponsavelSerasaScoreUltimaData_F, COALESCE( T1.PropostaResponsavelSerasaScoreUltimaData_F, 0) AS PropostaSerasaScoreUltimaData_F FROM (SELECT MAX(T2.SerasaScore) AS PropostaResponsavelSerasaScoreUltimaData_F, COALESCE( T3.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, T2.ClienteId FROM (Serasa T2 LEFT JOIN LATERAL (SELECT MAX(SerasaCreatedAt) AS SerasaUltimaData_F, ClienteId FROM Serasa WHERE T2.ClienteId = ClienteId GROUP BY ClienteId ) T3 ON T3.ClienteId = T2.ClienteId) WHERE T2.SerasaCreatedAt = COALESCE( T3.SerasaUltimaData_F, DATE '00010101') GROUP BY T3.SerasaUltimaData_F, T2.ClienteId ) T1 WHERE T1.ClienteId = :PropostaPacienteClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A88,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A91", "SELECT COALESCE( T1.PropostaResponsavelSerasaUltimoValorRecomendado_F, 0) AS PropostaResponsavelSerasaUltimoValorRecomendado_F, COALESCE( T1.PropostaResponsavelSerasaUltimoValorRecomendado_F, 0) AS PropostaPacienteSerasaUltimoValorRecomendado_F FROM (SELECT MAX(T2.SerasaValorLimiteRecomendado) AS PropostaResponsavelSerasaUltimoValorRecomendado_F, COALESCE( T3.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, T2.ClienteId FROM (Serasa T2 LEFT JOIN LATERAL (SELECT MAX(SerasaCreatedAt) AS SerasaUltimaData_F, ClienteId FROM Serasa WHERE T2.ClienteId = ClienteId GROUP BY ClienteId ) T3 ON T3.ClienteId = T2.ClienteId) WHERE T2.SerasaCreatedAt = COALESCE( T3.SerasaUltimaData_F, DATE '00010101') GROUP BY T3.SerasaUltimaData_F, T2.ClienteId ) T1 WHERE T1.ClienteId = :PropostaPacienteClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A91,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A92", "SELECT ClienteDocumento AS PropostaResponsavelDocumento, ClienteRazaoSocial AS PropostaResponsavelRazaoSocial, ContatoEmail AS PropostaResponsavelEmail, ContaNumero AS PropostaResponsavelConta, ContaAgencia AS PropostaResponsavelAgencia, ClientePixTipo AS PropostaResponsavelTipoPix, ClientePix AS PropostaResponsavelPIX, ClienteDepositoTipo AS PropostaResponsavelDepositoTipo FROM Cliente WHERE ClienteId = :PropostaResponsavelId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A92,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A93", "SELECT ClienteRazaoSocial AS PropostaClinicaNome, ClienteNomeFantasia AS PropostaClinicaNomeFantasia, ClienteDocumento AS PropostaClinicaDocumento, ContatoEmail AS PropostaClinicaEmail FROM Cliente WHERE ClienteId = :PropostaClinicaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A93,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A94", "SELECT ClienteId AS PropostaEmpresaClienteId FROM Cliente WHERE ClienteId = :PropostaEmpresaClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A94,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A95", "SELECT PropostaId FROM Proposta WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A95,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A96", "SELECT PropostaId FROM Proposta WHERE ( PropostaId > :PropostaId) ORDER BY PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A96,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001A97", "SELECT PropostaId FROM Proposta WHERE ( PropostaId < :PropostaId) ORDER BY PropostaId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A97,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001A98", "SAVEPOINT gxupdate;INSERT INTO Proposta(PropostaCreatedAt, PropostaProtocolo, PropostaTipoProposta, PropostaTitulo, PropostaDescricao, PropostaDataCirurgia, PropostaValor, PropostaValorLiquido, PropostaTaxaAdministrativa, PropostaSLA, PropostaJurosMora, PropostaStatus, PropostaComentarioAnalise, PropostaQuantidadeAprovadores, PropostaReprovacoesPermitidas, ConvenioVencimentoAno, ConvenioVencimentoMes, ContratoId, ProcedimentosMedicosId, ConvenioCategoriaId, PropostaCratedBy, PropostaPacienteClienteId, PropostaResponsavelId, PropostaClinicaId, PropostaEmpresaClienteId) VALUES(:PropostaCreatedAt, :PropostaProtocolo, :PropostaTipoProposta, :PropostaTitulo, :PropostaDescricao, :PropostaDataCirurgia, :PropostaValor, :PropostaValorLiquido, :PropostaTaxaAdministrativa, :PropostaSLA, :PropostaJurosMora, :PropostaStatus, :PropostaComentarioAnalise, :PropostaQuantidadeAprovadores, :PropostaReprovacoesPermitidas, :ConvenioVencimentoAno, :ConvenioVencimentoMes, :ContratoId, :ProcedimentosMedicosId, :ConvenioCategoriaId, :PropostaCratedBy, :PropostaPacienteClienteId, :PropostaResponsavelId, :PropostaClinicaId, :PropostaEmpresaClienteId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001A98)
             ,new CursorDef("T001A99", "SELECT currval('PropostaId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A99,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A100", "SAVEPOINT gxupdate;UPDATE Proposta SET PropostaCreatedAt=:PropostaCreatedAt, PropostaProtocolo=:PropostaProtocolo, PropostaTipoProposta=:PropostaTipoProposta, PropostaTitulo=:PropostaTitulo, PropostaDescricao=:PropostaDescricao, PropostaDataCirurgia=:PropostaDataCirurgia, PropostaValor=:PropostaValor, PropostaValorLiquido=:PropostaValorLiquido, PropostaTaxaAdministrativa=:PropostaTaxaAdministrativa, PropostaSLA=:PropostaSLA, PropostaJurosMora=:PropostaJurosMora, PropostaStatus=:PropostaStatus, PropostaComentarioAnalise=:PropostaComentarioAnalise, PropostaQuantidadeAprovadores=:PropostaQuantidadeAprovadores, PropostaReprovacoesPermitidas=:PropostaReprovacoesPermitidas, ConvenioVencimentoAno=:ConvenioVencimentoAno, ConvenioVencimentoMes=:ConvenioVencimentoMes, ContratoId=:ContratoId, ProcedimentosMedicosId=:ProcedimentosMedicosId, ConvenioCategoriaId=:ConvenioCategoriaId, PropostaCratedBy=:PropostaCratedBy, PropostaPacienteClienteId=:PropostaPacienteClienteId, PropostaResponsavelId=:PropostaResponsavelId, PropostaClinicaId=:PropostaClinicaId, PropostaEmpresaClienteId=:PropostaEmpresaClienteId  WHERE PropostaId = :PropostaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001A100)
             ,new CursorDef("T001A101", "SAVEPOINT gxupdate;DELETE FROM Proposta  WHERE PropostaId = :PropostaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001A101)
             ,new CursorDef("T001A103", "SELECT COALESCE( T1.PropostaMaxReembolsoId_F, 0) AS PropostaMaxReembolsoId_F FROM (SELECT MAX(ReembolsoId) AS PropostaMaxReembolsoId_F, ReembolsoPropostaId FROM Reembolso GROUP BY ReembolsoPropostaId ) T1 WHERE T1.ReembolsoPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A103,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A105", "SELECT COALESCE( T1.PropostaQtdItensNota_F, 0) AS PropostaQtdItensNota_F FROM (SELECT COUNT(*) AS PropostaQtdItensNota_F, PropostaId FROM NotaFiscalItem GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A105,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A107", "SELECT COALESCE( T1.PropostaQtdDocumentoPendente_F, 0) AS PropostaQtdDocumentoPendente_F FROM (SELECT COUNT(*) AS PropostaQtdDocumentoPendente_F, PropostaId FROM PropostaDocumentos WHERE PropostaDocumentosStatus = ( 'AGUARDANDO_ANALISE') or PropostaDocumentosStatus = ( 'REPROVADO') GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A107,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A109", "SELECT COALESCE( T1.PropostaAprovacoes_F, 0) AS PropostaAprovacoes_F FROM (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE AprovacaoStatus = ( 'APROVADO') GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A109,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A111", "SELECT COALESCE( T1.PropostaAprovacoes_F, 0) AS PropostaReprovacoes_F FROM (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE AprovacaoStatus = ( 'REPROVADO') GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A111,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A112", "SELECT SecUserFullName AS PropostaSecUserName FROM SecUser WHERE SecUserId = :PropostaCratedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A112,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A115", "SELECT COALESCE( T1.PropostaValorReembolsado_F, 0) AS PropostaValorTaxaRecebida_F FROM (SELECT SUM(COALESCE( T5.TituloTotalMovimento_F, 0)) AS PropostaValorReembolsado_F, T2.TituloPropostaId FROM (((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T2.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T5 ON T5.TituloId = T2.TituloId) WHERE (T4.ClienteId = :PropostaCratedBy) AND (T2.TituloPropostaId = :PropostaId) GROUP BY T2.TituloPropostaId ) T1 WHERE T1.TituloPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A115,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A116", "SELECT ContratoNome FROM Contrato WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A116,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A117", "SELECT ConvenioCategoriaDescricao, ConvenioId FROM ConvenioCategoria WHERE ConvenioCategoriaId = :ConvenioCategoriaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A117,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A118", "SELECT ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, ClienteDocumento AS PropostaPacienteClienteDocumento, ContatoEmail AS PropostaPacienteContatoEmail, ContaNumero AS PropostaPacienteConta, ContaAgencia AS PropostaPacienteAgencia, ClientePixTipo AS PropostaPacienteTipoPix, ClientePix AS PropostaPacientePIX, ClienteDepositoTipo AS PropostaPacienteDepositoTipo, EnderecoCEP AS PropostaPacienteEnderecoCEP, EnderecoLogradouro AS PropostaPacienteEnderecoLogradouro, EnderecoNumero AS PropostaPacienteEnderecoNumero, EnderecoComplemento AS PropostaPacienteEnderecoComplemento, EnderecoBairro AS PropostaPacienteEnderecoBairro, MunicipioCodigo AS PropostaPacienteMunicipioCodigo FROM Cliente WHERE ClienteId = :PropostaPacienteClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A118,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A121", "SELECT COALESCE( T1.PropostaValorReembolsado_F, 0) AS PropostaValorReembolsado_F FROM (SELECT SUM(COALESCE( T5.TituloTotalMovimento_F, 0)) AS PropostaValorReembolsado_F, T2.TituloPropostaId FROM (((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T2.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T5 ON T5.TituloId = T2.TituloId) WHERE (T4.ClienteId = :PropostaPacienteClienteId) AND (T2.TituloPropostaId = :PropostaId) GROUP BY T2.TituloPropostaId ) T1 WHERE T1.TituloPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A121,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A124", "SELECT COALESCE( T1.PropostaValorReembolsadoJuros_F, 0) AS PropostaValorReembolsadoJuros_F FROM (SELECT SUM(COALESCE( T5.TituloTotalMovimento_F, 0)) AS PropostaValorReembolsadoJuros_F, T2.TituloPropostaId FROM (((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T2.TituloId = TituloId) AND (Not TituloMovimentoSoma) GROUP BY TituloId ) T5 ON T5.TituloId = T2.TituloId) WHERE (T4.ClienteId = :PropostaPacienteClienteId) AND (T2.TituloPropostaId = :PropostaId) GROUP BY T2.TituloPropostaId ) T1 WHERE T1.TituloPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A124,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A127", "SELECT COALESCE( T1.PropostaDataCreditoCliente_F, DATE '00010101') AS PropostaDataCreditoCliente_F FROM (SELECT MAX(COALESCE( T5.TituloDataCredito_F, DATE '00010101')) AS PropostaDataCreditoCliente_F, T2.TituloPropostaId FROM (((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN LATERAL (SELECT MAX(TituloMovimentoDataCredito) AS TituloDataCredito_F, TituloId FROM TituloMovimento WHERE T2.TituloId = TituloId GROUP BY TituloId ) T5 ON T5.TituloId = T2.TituloId) WHERE (T4.ClienteId = :PropostaPacienteClienteId) AND (T2.TituloPropostaId = :PropostaId) AND (T2.TituloTipo = ( 'DEBITO')) GROUP BY T2.TituloPropostaId ) T1 WHERE T1.TituloPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A127,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A129", "SELECT COALESCE( T1.PropostaResponsavelSerasaConsultas_F, 0) AS PropostaResponsavelSerasaConsultas_F, COALESCE( T1.PropostaResponsavelSerasaConsultas_F, 0) AS PropostaPacienteSerasaConsultas_F FROM (SELECT COUNT(*) AS PropostaResponsavelSerasaConsultas_F, ClienteId FROM Serasa GROUP BY ClienteId ) T1 WHERE T1.ClienteId = :PropostaPacienteClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A129,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A132", "SELECT COALESCE( T1.PropostaResponsavelSerasaScoreUltimaData_F, 0) AS PropostaResponsavelSerasaScoreUltimaData_F, COALESCE( T1.PropostaResponsavelSerasaScoreUltimaData_F, 0) AS PropostaSerasaScoreUltimaData_F FROM (SELECT MAX(T2.SerasaScore) AS PropostaResponsavelSerasaScoreUltimaData_F, COALESCE( T3.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, T2.ClienteId FROM (Serasa T2 LEFT JOIN LATERAL (SELECT MAX(SerasaCreatedAt) AS SerasaUltimaData_F, ClienteId FROM Serasa WHERE T2.ClienteId = ClienteId GROUP BY ClienteId ) T3 ON T3.ClienteId = T2.ClienteId) WHERE T2.SerasaCreatedAt = COALESCE( T3.SerasaUltimaData_F, DATE '00010101') GROUP BY T3.SerasaUltimaData_F, T2.ClienteId ) T1 WHERE T1.ClienteId = :PropostaPacienteClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A132,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A135", "SELECT COALESCE( T1.PropostaResponsavelSerasaUltimoValorRecomendado_F, 0) AS PropostaResponsavelSerasaUltimoValorRecomendado_F, COALESCE( T1.PropostaResponsavelSerasaUltimoValorRecomendado_F, 0) AS PropostaPacienteSerasaUltimoValorRecomendado_F FROM (SELECT MAX(T2.SerasaValorLimiteRecomendado) AS PropostaResponsavelSerasaUltimoValorRecomendado_F, COALESCE( T3.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, T2.ClienteId FROM (Serasa T2 LEFT JOIN LATERAL (SELECT MAX(SerasaCreatedAt) AS SerasaUltimaData_F, ClienteId FROM Serasa WHERE T2.ClienteId = ClienteId GROUP BY ClienteId ) T3 ON T3.ClienteId = T2.ClienteId) WHERE T2.SerasaCreatedAt = COALESCE( T3.SerasaUltimaData_F, DATE '00010101') GROUP BY T3.SerasaUltimaData_F, T2.ClienteId ) T1 WHERE T1.ClienteId = :PropostaPacienteClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A135,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A136", "SELECT ClienteDocumento AS PropostaResponsavelDocumento, ClienteRazaoSocial AS PropostaResponsavelRazaoSocial, ContatoEmail AS PropostaResponsavelEmail, ContaNumero AS PropostaResponsavelConta, ContaAgencia AS PropostaResponsavelAgencia, ClientePixTipo AS PropostaResponsavelTipoPix, ClientePix AS PropostaResponsavelPIX, ClienteDepositoTipo AS PropostaResponsavelDepositoTipo FROM Cliente WHERE ClienteId = :PropostaResponsavelId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A136,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A137", "SELECT ClienteRazaoSocial AS PropostaClinicaNome, ClienteNomeFantasia AS PropostaClinicaNomeFantasia, ClienteDocumento AS PropostaClinicaDocumento, ContatoEmail AS PropostaClinicaEmail FROM Cliente WHERE ClienteId = :PropostaClinicaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A137,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A139", "SELECT COALESCE( T1.PropostaValorTaxaClinica_F, 0) AS PropostaValorTaxaClinica_F FROM (SELECT SUM(T2.TituloValor) AS PropostaValorTaxaClinica_F, T2.TituloPropostaId FROM ((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) WHERE (T2.TituloPropostaTipo = ( 'TAXA')) AND (T2.TituloPropostaId = :PropostaId) AND (T4.ClienteId = :PropostaClinicaId) GROUP BY T2.TituloPropostaId ) T1 WHERE T1.TituloPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A139,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A140", "SELECT ContratoId FROM Contrato WHERE ContratoPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A140,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001A141", "SELECT ReembolsoId FROM Reembolso WHERE ReembolsoPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A141,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001A142", "SELECT TituloId FROM Titulo WHERE TituloPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A142,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001A143", "SELECT NotaFiscalItemId FROM NotaFiscalItem WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A143,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001A144", "SELECT PropostaContratoAssinaturaId FROM PropostaContratoAssinatura WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A144,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001A145", "SELECT PropostaDocumentosId FROM PropostaDocumentos WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A145,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001A146", "SELECT AprovacaoId FROM Aprovacao WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A146,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001A147", "SELECT PropostaId FROM Proposta ORDER BY PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A147,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001A148", "SELECT ProcedimentosMedicosId FROM ProcedimentosMedicos WHERE ProcedimentosMedicosId = :ProcedimentosMedicosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001A148,1, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((short[]) buf[19])[0] = rslt.getShort(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((short[]) buf[27])[0] = rslt.getShort(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((short[]) buf[29])[0] = rslt.getShort(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((short[]) buf[31])[0] = rslt.getShort(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((short[]) buf[33])[0] = rslt.getShort(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((int[]) buf[35])[0] = rslt.getInt(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((int[]) buf[37])[0] = rslt.getInt(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((int[]) buf[39])[0] = rslt.getInt(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((short[]) buf[41])[0] = rslt.getShort(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((int[]) buf[43])[0] = rslt.getInt(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((int[]) buf[45])[0] = rslt.getInt(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((int[]) buf[47])[0] = rslt.getInt(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((int[]) buf[49])[0] = rslt.getInt(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((short[]) buf[19])[0] = rslt.getShort(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((short[]) buf[27])[0] = rslt.getShort(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((short[]) buf[29])[0] = rslt.getShort(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((short[]) buf[31])[0] = rslt.getShort(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((short[]) buf[33])[0] = rslt.getShort(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((int[]) buf[35])[0] = rslt.getInt(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((int[]) buf[37])[0] = rslt.getInt(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((int[]) buf[39])[0] = rslt.getInt(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((short[]) buf[41])[0] = rslt.getShort(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((int[]) buf[43])[0] = rslt.getInt(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((int[]) buf[45])[0] = rslt.getInt(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((int[]) buf[47])[0] = rslt.getInt(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((int[]) buf[49])[0] = rslt.getInt(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 11 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 12 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 13 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 14 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 17 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 19 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 20 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 21 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 22 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 23 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((string[]) buf[41])[0] = rslt.getVarchar(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((string[]) buf[43])[0] = rslt.getVarchar(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((string[]) buf[47])[0] = rslt.getVarchar(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((string[]) buf[51])[0] = rslt.getVarchar(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((DateTime[]) buf[53])[0] = rslt.getGXDate(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((decimal[]) buf[55])[0] = rslt.getDecimal(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((decimal[]) buf[57])[0] = rslt.getDecimal(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((decimal[]) buf[59])[0] = rslt.getDecimal(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((short[]) buf[61])[0] = rslt.getShort(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((decimal[]) buf[63])[0] = rslt.getDecimal(33);
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                ((string[]) buf[65])[0] = rslt.getVarchar(34);
                ((bool[]) buf[66])[0] = rslt.wasNull(34);
                ((string[]) buf[67])[0] = rslt.getVarchar(35);
                ((bool[]) buf[68])[0] = rslt.wasNull(35);
                ((string[]) buf[69])[0] = rslt.getVarchar(36);
                ((bool[]) buf[70])[0] = rslt.wasNull(36);
                ((string[]) buf[71])[0] = rslt.getVarchar(37);
                ((bool[]) buf[72])[0] = rslt.wasNull(37);
                ((string[]) buf[73])[0] = rslt.getVarchar(38);
                ((bool[]) buf[74])[0] = rslt.wasNull(38);
                ((string[]) buf[75])[0] = rslt.getVarchar(39);
                ((bool[]) buf[76])[0] = rslt.wasNull(39);
                ((string[]) buf[77])[0] = rslt.getVarchar(40);
                ((bool[]) buf[78])[0] = rslt.wasNull(40);
                ((short[]) buf[79])[0] = rslt.getShort(41);
                ((bool[]) buf[80])[0] = rslt.wasNull(41);
                ((short[]) buf[81])[0] = rslt.getShort(42);
                ((bool[]) buf[82])[0] = rslt.wasNull(42);
                ((string[]) buf[83])[0] = rslt.getVarchar(43);
                ((bool[]) buf[84])[0] = rslt.wasNull(43);
                ((short[]) buf[85])[0] = rslt.getShort(44);
                ((bool[]) buf[86])[0] = rslt.wasNull(44);
                ((short[]) buf[87])[0] = rslt.getShort(45);
                ((bool[]) buf[88])[0] = rslt.wasNull(45);
                ((string[]) buf[89])[0] = rslt.getVarchar(46);
                ((bool[]) buf[90])[0] = rslt.wasNull(46);
                ((int[]) buf[91])[0] = rslt.getInt(47);
                ((bool[]) buf[92])[0] = rslt.wasNull(47);
                ((int[]) buf[93])[0] = rslt.getInt(48);
                ((bool[]) buf[94])[0] = rslt.wasNull(48);
                ((int[]) buf[95])[0] = rslt.getInt(49);
                ((bool[]) buf[96])[0] = rslt.wasNull(49);
                ((short[]) buf[97])[0] = rslt.getShort(50);
                ((bool[]) buf[98])[0] = rslt.wasNull(50);
                ((int[]) buf[99])[0] = rslt.getInt(51);
                ((bool[]) buf[100])[0] = rslt.wasNull(51);
                ((int[]) buf[101])[0] = rslt.getInt(52);
                ((bool[]) buf[102])[0] = rslt.wasNull(52);
                ((int[]) buf[103])[0] = rslt.getInt(53);
                ((bool[]) buf[104])[0] = rslt.wasNull(53);
                ((int[]) buf[105])[0] = rslt.getInt(54);
                ((bool[]) buf[106])[0] = rslt.wasNull(54);
                ((int[]) buf[107])[0] = rslt.getInt(55);
                ((bool[]) buf[108])[0] = rslt.wasNull(55);
                ((string[]) buf[109])[0] = rslt.getVarchar(56);
                ((bool[]) buf[110])[0] = rslt.wasNull(56);
                ((int[]) buf[111])[0] = rslt.getInt(57);
                ((bool[]) buf[112])[0] = rslt.wasNull(57);
                ((short[]) buf[113])[0] = rslt.getShort(58);
                ((bool[]) buf[114])[0] = rslt.wasNull(58);
                ((short[]) buf[115])[0] = rslt.getShort(59);
                ((bool[]) buf[116])[0] = rslt.wasNull(59);
                ((short[]) buf[117])[0] = rslt.getShort(60);
                ((bool[]) buf[118])[0] = rslt.wasNull(60);
                ((decimal[]) buf[119])[0] = rslt.getDecimal(61);
                ((bool[]) buf[120])[0] = rslt.wasNull(61);
                ((short[]) buf[121])[0] = rslt.getShort(62);
                ((bool[]) buf[122])[0] = rslt.wasNull(62);
                ((short[]) buf[123])[0] = rslt.getShort(63);
                ((bool[]) buf[124])[0] = rslt.wasNull(63);
                ((decimal[]) buf[125])[0] = rslt.getDecimal(64);
                ((bool[]) buf[126])[0] = rslt.wasNull(64);
                ((short[]) buf[127])[0] = rslt.getShort(65);
                ((bool[]) buf[128])[0] = rslt.wasNull(65);
                ((short[]) buf[129])[0] = rslt.getShort(66);
                ((bool[]) buf[130])[0] = rslt.wasNull(66);
                ((short[]) buf[131])[0] = rslt.getShort(67);
                ((bool[]) buf[132])[0] = rslt.wasNull(67);
                return;
             case 24 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 25 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 26 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 27 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 28 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 29 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
       getresults30( cursor, rslt, buf) ;
    }

    public void getresults30( int cursor ,
                              IFieldGetter rslt ,
                              Object[] buf )
    {
       switch ( cursor )
       {
             case 30 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 31 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 32 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 33 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 34 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 35 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 36 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 37 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 38 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                return;
             case 39 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 40 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 41 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 42 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                return;
             case 43 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                return;
             case 44 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 45 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 46 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 47 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 49 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 52 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 53 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 54 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 55 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 56 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 57 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 58 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 59 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
       getresults60( cursor, rslt, buf) ;
    }

    public void getresults60( int cursor ,
                              IFieldGetter rslt ,
                              Object[] buf )
    {
       switch ( cursor )
       {
             case 60 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 61 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                return;
             case 62 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 63 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 64 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 65 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 66 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 67 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 68 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                return;
             case 69 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                return;
             case 70 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 71 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 72 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 73 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 74 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 75 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 76 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 77 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 78 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 79 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
