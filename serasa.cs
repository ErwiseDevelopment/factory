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
   public class serasa : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
         {
            A662SerasaId = (int)(Math.Round(NumberUtil.Val( GetPar( "SerasaId"), "."), 18, MidpointRounding.ToEven));
            n662SerasaId = false;
            AssignAttri("", false, "A662SerasaId", StringUtil.LTrimStr( (decimal)(A662SerasaId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A662SerasaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A662SerasaId = (int)(Math.Round(NumberUtil.Val( GetPar( "SerasaId"), "."), 18, MidpointRounding.ToEven));
            n662SerasaId = false;
            AssignAttri("", false, "A662SerasaId", StringUtil.LTrimStr( (decimal)(A662SerasaId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A662SerasaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
         {
            A662SerasaId = (int)(Math.Round(NumberUtil.Val( GetPar( "SerasaId"), "."), 18, MidpointRounding.ToEven));
            n662SerasaId = false;
            AssignAttri("", false, "A662SerasaId", StringUtil.LTrimStr( (decimal)(A662SerasaId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A662SerasaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
         {
            A662SerasaId = (int)(Math.Round(NumberUtil.Val( GetPar( "SerasaId"), "."), 18, MidpointRounding.ToEven));
            n662SerasaId = false;
            AssignAttri("", false, "A662SerasaId", StringUtil.LTrimStr( (decimal)(A662SerasaId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_15( A662SerasaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A662SerasaId = (int)(Math.Round(NumberUtil.Val( GetPar( "SerasaId"), "."), 18, MidpointRounding.ToEven));
            n662SerasaId = false;
            AssignAttri("", false, "A662SerasaId", StringUtil.LTrimStr( (decimal)(A662SerasaId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A662SerasaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_11") == 0 )
         {
            A168ClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteId"), "."), 18, MidpointRounding.ToEven));
            n168ClienteId = false;
            AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_11( A168ClienteId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "serasa")), "serasa") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "serasa")))) ;
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
                  AV7SerasaId = (int)(Math.Round(NumberUtil.Val( GetPar( "SerasaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7SerasaId", StringUtil.LTrimStr( (decimal)(AV7SerasaId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vSERASAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SerasaId), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Serasa", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtClienteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public serasa( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public serasa( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_SerasaId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7SerasaId = aP1_SerasaId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbSerasaCpfRegular = new GXCombobox();
         cmbSerasaRetricaoAtiva = new GXCombobox();
         cmbSerasaProtestoAtivo = new GXCombobox();
         cmbSerasaBaixoComprometimento = new GXCombobox();
         cmbSerasaAnotacoesCompletas = new GXCombobox();
         cmbSerasaConsultasDetalhadas = new GXCombobox();
         cmbSerasaAnotacoesConsultaSPC = new GXCombobox();
         cmbSerasaParticipacaoSocietaria = new GXCombobox();
         cmbSerasaRendaEstimada = new GXCombobox();
         cmbSerasaHistoricoPagamentoPF = new GXCombobox();
         cmbSerasaRecomendaCompleto = new GXCombobox();
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
         if ( cmbSerasaCpfRegular.ItemCount > 0 )
         {
            A671SerasaCpfRegular = StringUtil.StrToBool( cmbSerasaCpfRegular.getValidValue(StringUtil.BoolToStr( A671SerasaCpfRegular)));
            n671SerasaCpfRegular = false;
            AssignAttri("", false, "A671SerasaCpfRegular", A671SerasaCpfRegular);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSerasaCpfRegular.CurrentValue = StringUtil.BoolToStr( A671SerasaCpfRegular);
            AssignProp("", false, cmbSerasaCpfRegular_Internalname, "Values", cmbSerasaCpfRegular.ToJavascriptSource(), true);
         }
         if ( cmbSerasaRetricaoAtiva.ItemCount > 0 )
         {
            A672SerasaRetricaoAtiva = StringUtil.StrToBool( cmbSerasaRetricaoAtiva.getValidValue(StringUtil.BoolToStr( A672SerasaRetricaoAtiva)));
            n672SerasaRetricaoAtiva = false;
            AssignAttri("", false, "A672SerasaRetricaoAtiva", A672SerasaRetricaoAtiva);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSerasaRetricaoAtiva.CurrentValue = StringUtil.BoolToStr( A672SerasaRetricaoAtiva);
            AssignProp("", false, cmbSerasaRetricaoAtiva_Internalname, "Values", cmbSerasaRetricaoAtiva.ToJavascriptSource(), true);
         }
         if ( cmbSerasaProtestoAtivo.ItemCount > 0 )
         {
            A673SerasaProtestoAtivo = StringUtil.StrToBool( cmbSerasaProtestoAtivo.getValidValue(StringUtil.BoolToStr( A673SerasaProtestoAtivo)));
            n673SerasaProtestoAtivo = false;
            AssignAttri("", false, "A673SerasaProtestoAtivo", A673SerasaProtestoAtivo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSerasaProtestoAtivo.CurrentValue = StringUtil.BoolToStr( A673SerasaProtestoAtivo);
            AssignProp("", false, cmbSerasaProtestoAtivo_Internalname, "Values", cmbSerasaProtestoAtivo.ToJavascriptSource(), true);
         }
         if ( cmbSerasaBaixoComprometimento.ItemCount > 0 )
         {
            A674SerasaBaixoComprometimento = StringUtil.StrToBool( cmbSerasaBaixoComprometimento.getValidValue(StringUtil.BoolToStr( A674SerasaBaixoComprometimento)));
            n674SerasaBaixoComprometimento = false;
            AssignAttri("", false, "A674SerasaBaixoComprometimento", A674SerasaBaixoComprometimento);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSerasaBaixoComprometimento.CurrentValue = StringUtil.BoolToStr( A674SerasaBaixoComprometimento);
            AssignProp("", false, cmbSerasaBaixoComprometimento_Internalname, "Values", cmbSerasaBaixoComprometimento.ToJavascriptSource(), true);
         }
         if ( cmbSerasaAnotacoesCompletas.ItemCount > 0 )
         {
            A678SerasaAnotacoesCompletas = StringUtil.StrToBool( cmbSerasaAnotacoesCompletas.getValidValue(StringUtil.BoolToStr( A678SerasaAnotacoesCompletas)));
            n678SerasaAnotacoesCompletas = false;
            AssignAttri("", false, "A678SerasaAnotacoesCompletas", A678SerasaAnotacoesCompletas);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSerasaAnotacoesCompletas.CurrentValue = StringUtil.BoolToStr( A678SerasaAnotacoesCompletas);
            AssignProp("", false, cmbSerasaAnotacoesCompletas_Internalname, "Values", cmbSerasaAnotacoesCompletas.ToJavascriptSource(), true);
         }
         if ( cmbSerasaConsultasDetalhadas.ItemCount > 0 )
         {
            A679SerasaConsultasDetalhadas = StringUtil.StrToBool( cmbSerasaConsultasDetalhadas.getValidValue(StringUtil.BoolToStr( A679SerasaConsultasDetalhadas)));
            n679SerasaConsultasDetalhadas = false;
            AssignAttri("", false, "A679SerasaConsultasDetalhadas", A679SerasaConsultasDetalhadas);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSerasaConsultasDetalhadas.CurrentValue = StringUtil.BoolToStr( A679SerasaConsultasDetalhadas);
            AssignProp("", false, cmbSerasaConsultasDetalhadas_Internalname, "Values", cmbSerasaConsultasDetalhadas.ToJavascriptSource(), true);
         }
         if ( cmbSerasaAnotacoesConsultaSPC.ItemCount > 0 )
         {
            A680SerasaAnotacoesConsultaSPC = StringUtil.StrToBool( cmbSerasaAnotacoesConsultaSPC.getValidValue(StringUtil.BoolToStr( A680SerasaAnotacoesConsultaSPC)));
            n680SerasaAnotacoesConsultaSPC = false;
            AssignAttri("", false, "A680SerasaAnotacoesConsultaSPC", A680SerasaAnotacoesConsultaSPC);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSerasaAnotacoesConsultaSPC.CurrentValue = StringUtil.BoolToStr( A680SerasaAnotacoesConsultaSPC);
            AssignProp("", false, cmbSerasaAnotacoesConsultaSPC_Internalname, "Values", cmbSerasaAnotacoesConsultaSPC.ToJavascriptSource(), true);
         }
         if ( cmbSerasaParticipacaoSocietaria.ItemCount > 0 )
         {
            A681SerasaParticipacaoSocietaria = StringUtil.StrToBool( cmbSerasaParticipacaoSocietaria.getValidValue(StringUtil.BoolToStr( A681SerasaParticipacaoSocietaria)));
            n681SerasaParticipacaoSocietaria = false;
            AssignAttri("", false, "A681SerasaParticipacaoSocietaria", A681SerasaParticipacaoSocietaria);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSerasaParticipacaoSocietaria.CurrentValue = StringUtil.BoolToStr( A681SerasaParticipacaoSocietaria);
            AssignProp("", false, cmbSerasaParticipacaoSocietaria_Internalname, "Values", cmbSerasaParticipacaoSocietaria.ToJavascriptSource(), true);
         }
         if ( cmbSerasaRendaEstimada.ItemCount > 0 )
         {
            A682SerasaRendaEstimada = StringUtil.StrToBool( cmbSerasaRendaEstimada.getValidValue(StringUtil.BoolToStr( A682SerasaRendaEstimada)));
            n682SerasaRendaEstimada = false;
            AssignAttri("", false, "A682SerasaRendaEstimada", A682SerasaRendaEstimada);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSerasaRendaEstimada.CurrentValue = StringUtil.BoolToStr( A682SerasaRendaEstimada);
            AssignProp("", false, cmbSerasaRendaEstimada_Internalname, "Values", cmbSerasaRendaEstimada.ToJavascriptSource(), true);
         }
         if ( cmbSerasaHistoricoPagamentoPF.ItemCount > 0 )
         {
            A683SerasaHistoricoPagamentoPF = StringUtil.StrToBool( cmbSerasaHistoricoPagamentoPF.getValidValue(StringUtil.BoolToStr( A683SerasaHistoricoPagamentoPF)));
            n683SerasaHistoricoPagamentoPF = false;
            AssignAttri("", false, "A683SerasaHistoricoPagamentoPF", A683SerasaHistoricoPagamentoPF);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSerasaHistoricoPagamentoPF.CurrentValue = StringUtil.BoolToStr( A683SerasaHistoricoPagamentoPF);
            AssignProp("", false, cmbSerasaHistoricoPagamentoPF_Internalname, "Values", cmbSerasaHistoricoPagamentoPF.ToJavascriptSource(), true);
         }
         if ( cmbSerasaRecomendaCompleto.ItemCount > 0 )
         {
            A684SerasaRecomendaCompleto = StringUtil.StrToBool( cmbSerasaRecomendaCompleto.getValidValue(StringUtil.BoolToStr( A684SerasaRecomendaCompleto)));
            n684SerasaRecomendaCompleto = false;
            AssignAttri("", false, "A684SerasaRecomendaCompleto", A684SerasaRecomendaCompleto);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbSerasaRecomendaCompleto.CurrentValue = StringUtil.BoolToStr( A684SerasaRecomendaCompleto);
            AssignProp("", false, cmbSerasaRecomendaCompleto_Internalname, "Values", cmbSerasaRecomendaCompleto.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaId_Internalname, "Id", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A662SerasaId), 9, 0, ",", "")), StringUtil.LTrim( ((edtSerasaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A662SerasaId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A662SerasaId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Serasa.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedclienteid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockclienteid_Internalname, "Cliente", "", "", lblTextblockclienteid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Serasa.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_clienteid.SetProperty("Caption", Combo_clienteid_Caption);
         ucCombo_clienteid.SetProperty("Cls", Combo_clienteid_Cls);
         ucCombo_clienteid.SetProperty("DataListProc", Combo_clienteid_Datalistproc);
         ucCombo_clienteid.SetProperty("DataListProcParametersPrefix", Combo_clienteid_Datalistprocparametersprefix);
         ucCombo_clienteid.SetProperty("DropDownOptionsTitleSettingsIcons", AV14DDO_TitleSettingsIcons);
         ucCombo_clienteid.SetProperty("DropDownOptionsData", AV13ClienteId_Data);
         ucCombo_clienteid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_clienteid_Internalname, "COMBO_CLIENTEIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteId_Internalname, "Cliente Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteId_Internalname, ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", ""))), ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteId_Jsonclick, 0, "Attribute", "", "", "", "", edtClienteId_Visible, edtClienteId_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Serasa.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaNumeroProposta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaNumeroProposta_Internalname, "Numero Proposta", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaNumeroProposta_Internalname, A663SerasaNumeroProposta, StringUtil.RTrim( context.localUtil.Format( A663SerasaNumeroProposta, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaNumeroProposta_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaNumeroProposta_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Serasa.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaPolitica_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaPolitica_Internalname, "Politica", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaPolitica_Internalname, ((Convert.ToDecimal(0)==A664SerasaPolitica)&&IsIns( )||n664SerasaPolitica ? "" : StringUtil.LTrim( StringUtil.NToC( A664SerasaPolitica, 15, 2, ",", ""))), ((Convert.ToDecimal(0)==A664SerasaPolitica)&&IsIns( )||n664SerasaPolitica ? "" : StringUtil.LTrim( ((edtSerasaPolitica_Enabled!=0) ? context.localUtil.Format( A664SerasaPolitica, "ZZZZZZZZZZZ9.99") : context.localUtil.Format( A664SerasaPolitica, "ZZZZZZZZZZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaPolitica_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaPolitica_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Serasa.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaCreatedAt_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaCreatedAt_Internalname, "Created At", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtSerasaCreatedAt_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtSerasaCreatedAt_Internalname, context.localUtil.TToC( A665SerasaCreatedAt, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A665SerasaCreatedAt, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaCreatedAt_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaCreatedAt_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Serasa.htm");
         GxWebStd.gx_bitmap( context, edtSerasaCreatedAt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtSerasaCreatedAt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Serasa.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaTipoVenda_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaTipoVenda_Internalname, "Tipo Venda", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaTipoVenda_Internalname, A666SerasaTipoVenda, StringUtil.RTrim( context.localUtil.Format( A666SerasaTipoVenda, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaTipoVenda_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaTipoVenda_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Serasa.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaCodTipoVenda_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaCodTipoVenda_Internalname, "Tipo Venda", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaCodTipoVenda_Internalname, ((Convert.ToDecimal(0)==A667SerasaCodTipoVenda)&&IsIns( )||n667SerasaCodTipoVenda ? "" : StringUtil.LTrim( StringUtil.NToC( A667SerasaCodTipoVenda, 15, 2, ",", ""))), ((Convert.ToDecimal(0)==A667SerasaCodTipoVenda)&&IsIns( )||n667SerasaCodTipoVenda ? "" : StringUtil.LTrim( ((edtSerasaCodTipoVenda_Enabled!=0) ? context.localUtil.Format( A667SerasaCodTipoVenda, "ZZZZZZZZZZZ9.99") : context.localUtil.Format( A667SerasaCodTipoVenda, "ZZZZZZZZZZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaCodTipoVenda_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaCodTipoVenda_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Serasa.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaCodNivelRisco_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaCodNivelRisco_Internalname, "Nivel Risco", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaCodNivelRisco_Internalname, ((Convert.ToDecimal(0)==A668SerasaCodNivelRisco)&&IsIns( )||n668SerasaCodNivelRisco ? "" : StringUtil.LTrim( StringUtil.NToC( A668SerasaCodNivelRisco, 15, 2, ",", ""))), ((Convert.ToDecimal(0)==A668SerasaCodNivelRisco)&&IsIns( )||n668SerasaCodNivelRisco ? "" : StringUtil.LTrim( ((edtSerasaCodNivelRisco_Enabled!=0) ? context.localUtil.Format( A668SerasaCodNivelRisco, "ZZZZZZZZZZZ9.99") : context.localUtil.Format( A668SerasaCodNivelRisco, "ZZZZZZZZZZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaCodNivelRisco_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaCodNivelRisco_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Serasa.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaTipoRecomendacao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaTipoRecomendacao_Internalname, "Tipo Recomendacao", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaTipoRecomendacao_Internalname, A669SerasaTipoRecomendacao, StringUtil.RTrim( context.localUtil.Format( A669SerasaTipoRecomendacao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaTipoRecomendacao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaTipoRecomendacao_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Serasa.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaRecomendacaoVenda_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaRecomendacaoVenda_Internalname, "Recomendacao Venda", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaRecomendacaoVenda_Internalname, A670SerasaRecomendacaoVenda, StringUtil.RTrim( context.localUtil.Format( A670SerasaRecomendacaoVenda, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaRecomendacaoVenda_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaRecomendacaoVenda_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Serasa.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbSerasaCpfRegular_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbSerasaCpfRegular_Internalname, "Cpf Regular", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbSerasaCpfRegular, cmbSerasaCpfRegular_Internalname, StringUtil.BoolToStr( A671SerasaCpfRegular), 1, cmbSerasaCpfRegular_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbSerasaCpfRegular.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "", true, 0, "HLP_Serasa.htm");
         cmbSerasaCpfRegular.CurrentValue = StringUtil.BoolToStr( A671SerasaCpfRegular);
         AssignProp("", false, cmbSerasaCpfRegular_Internalname, "Values", (string)(cmbSerasaCpfRegular.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbSerasaRetricaoAtiva_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbSerasaRetricaoAtiva_Internalname, "Retricao Ativa", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbSerasaRetricaoAtiva, cmbSerasaRetricaoAtiva_Internalname, StringUtil.BoolToStr( A672SerasaRetricaoAtiva), 1, cmbSerasaRetricaoAtiva_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbSerasaRetricaoAtiva.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"", "", true, 0, "HLP_Serasa.htm");
         cmbSerasaRetricaoAtiva.CurrentValue = StringUtil.BoolToStr( A672SerasaRetricaoAtiva);
         AssignProp("", false, cmbSerasaRetricaoAtiva_Internalname, "Values", (string)(cmbSerasaRetricaoAtiva.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbSerasaProtestoAtivo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbSerasaProtestoAtivo_Internalname, "Protesto Ativo", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbSerasaProtestoAtivo, cmbSerasaProtestoAtivo_Internalname, StringUtil.BoolToStr( A673SerasaProtestoAtivo), 1, cmbSerasaProtestoAtivo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbSerasaProtestoAtivo.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "", true, 0, "HLP_Serasa.htm");
         cmbSerasaProtestoAtivo.CurrentValue = StringUtil.BoolToStr( A673SerasaProtestoAtivo);
         AssignProp("", false, cmbSerasaProtestoAtivo_Internalname, "Values", (string)(cmbSerasaProtestoAtivo.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbSerasaBaixoComprometimento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbSerasaBaixoComprometimento_Internalname, "Baixo Comprometimento", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbSerasaBaixoComprometimento, cmbSerasaBaixoComprometimento_Internalname, StringUtil.BoolToStr( A674SerasaBaixoComprometimento), 1, cmbSerasaBaixoComprometimento_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbSerasaBaixoComprometimento.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "", true, 0, "HLP_Serasa.htm");
         cmbSerasaBaixoComprometimento.CurrentValue = StringUtil.BoolToStr( A674SerasaBaixoComprometimento);
         AssignProp("", false, cmbSerasaBaixoComprometimento_Internalname, "Values", (string)(cmbSerasaBaixoComprometimento.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaValorLimiteRecomendado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaValorLimiteRecomendado_Internalname, "Limite Recomendado", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaValorLimiteRecomendado_Internalname, ((Convert.ToDecimal(0)==A675SerasaValorLimiteRecomendado)&&IsIns( )||n675SerasaValorLimiteRecomendado ? "" : StringUtil.LTrim( StringUtil.NToC( A675SerasaValorLimiteRecomendado, 18, 2, ",", ""))), ((Convert.ToDecimal(0)==A675SerasaValorLimiteRecomendado)&&IsIns( )||n675SerasaValorLimiteRecomendado ? "" : StringUtil.LTrim( ((edtSerasaValorLimiteRecomendado_Enabled!=0) ? context.localUtil.Format( A675SerasaValorLimiteRecomendado, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A675SerasaValorLimiteRecomendado, "ZZZ,ZZZ,ZZZ,ZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaValorLimiteRecomendado_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaValorLimiteRecomendado_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_Serasa.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaFaixaDeRendaEstimada_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaFaixaDeRendaEstimada_Internalname, "Renda Estimada", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaFaixaDeRendaEstimada_Internalname, ((Convert.ToDecimal(0)==A676SerasaFaixaDeRendaEstimada)&&IsIns( )||n676SerasaFaixaDeRendaEstimada ? "" : StringUtil.LTrim( StringUtil.NToC( A676SerasaFaixaDeRendaEstimada, 15, 2, ",", ""))), ((Convert.ToDecimal(0)==A676SerasaFaixaDeRendaEstimada)&&IsIns( )||n676SerasaFaixaDeRendaEstimada ? "" : StringUtil.LTrim( ((edtSerasaFaixaDeRendaEstimada_Enabled!=0) ? context.localUtil.Format( A676SerasaFaixaDeRendaEstimada, "ZZZZZZZZZZZ9.99") : context.localUtil.Format( A676SerasaFaixaDeRendaEstimada, "ZZZZZZZZZZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,103);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaFaixaDeRendaEstimada_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaFaixaDeRendaEstimada_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Serasa.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaMensagemRendaEstimada_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaMensagemRendaEstimada_Internalname, "Renda Estimada", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtSerasaMensagemRendaEstimada_Internalname, A677SerasaMensagemRendaEstimada, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,108);\"", 0, 1, edtSerasaMensagemRendaEstimada_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "250", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Serasa.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbSerasaAnotacoesCompletas_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbSerasaAnotacoesCompletas_Internalname, "Anotacoes Completas", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbSerasaAnotacoesCompletas, cmbSerasaAnotacoesCompletas_Internalname, StringUtil.BoolToStr( A678SerasaAnotacoesCompletas), 1, cmbSerasaAnotacoesCompletas_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbSerasaAnotacoesCompletas.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,113);\"", "", true, 0, "HLP_Serasa.htm");
         cmbSerasaAnotacoesCompletas.CurrentValue = StringUtil.BoolToStr( A678SerasaAnotacoesCompletas);
         AssignProp("", false, cmbSerasaAnotacoesCompletas_Internalname, "Values", (string)(cmbSerasaAnotacoesCompletas.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbSerasaConsultasDetalhadas_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbSerasaConsultasDetalhadas_Internalname, "Consultas Detalhadas", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbSerasaConsultasDetalhadas, cmbSerasaConsultasDetalhadas_Internalname, StringUtil.BoolToStr( A679SerasaConsultasDetalhadas), 1, cmbSerasaConsultasDetalhadas_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbSerasaConsultasDetalhadas.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,118);\"", "", true, 0, "HLP_Serasa.htm");
         cmbSerasaConsultasDetalhadas.CurrentValue = StringUtil.BoolToStr( A679SerasaConsultasDetalhadas);
         AssignProp("", false, cmbSerasaConsultasDetalhadas_Internalname, "Values", (string)(cmbSerasaConsultasDetalhadas.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbSerasaAnotacoesConsultaSPC_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbSerasaAnotacoesConsultaSPC_Internalname, "Consulta SPC", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbSerasaAnotacoesConsultaSPC, cmbSerasaAnotacoesConsultaSPC_Internalname, StringUtil.BoolToStr( A680SerasaAnotacoesConsultaSPC), 1, cmbSerasaAnotacoesConsultaSPC_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbSerasaAnotacoesConsultaSPC.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,123);\"", "", true, 0, "HLP_Serasa.htm");
         cmbSerasaAnotacoesConsultaSPC.CurrentValue = StringUtil.BoolToStr( A680SerasaAnotacoesConsultaSPC);
         AssignProp("", false, cmbSerasaAnotacoesConsultaSPC_Internalname, "Values", (string)(cmbSerasaAnotacoesConsultaSPC.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbSerasaParticipacaoSocietaria_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbSerasaParticipacaoSocietaria_Internalname, "Participacao Societaria", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbSerasaParticipacaoSocietaria, cmbSerasaParticipacaoSocietaria_Internalname, StringUtil.BoolToStr( A681SerasaParticipacaoSocietaria), 1, cmbSerasaParticipacaoSocietaria_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbSerasaParticipacaoSocietaria.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,128);\"", "", true, 0, "HLP_Serasa.htm");
         cmbSerasaParticipacaoSocietaria.CurrentValue = StringUtil.BoolToStr( A681SerasaParticipacaoSocietaria);
         AssignProp("", false, cmbSerasaParticipacaoSocietaria_Internalname, "Values", (string)(cmbSerasaParticipacaoSocietaria.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbSerasaRendaEstimada_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbSerasaRendaEstimada_Internalname, "Renda Estimada", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 133,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbSerasaRendaEstimada, cmbSerasaRendaEstimada_Internalname, StringUtil.BoolToStr( A682SerasaRendaEstimada), 1, cmbSerasaRendaEstimada_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbSerasaRendaEstimada.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,133);\"", "", true, 0, "HLP_Serasa.htm");
         cmbSerasaRendaEstimada.CurrentValue = StringUtil.BoolToStr( A682SerasaRendaEstimada);
         AssignProp("", false, cmbSerasaRendaEstimada_Internalname, "Values", (string)(cmbSerasaRendaEstimada.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbSerasaHistoricoPagamentoPF_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbSerasaHistoricoPagamentoPF_Internalname, "Pagamento PF", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 138,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbSerasaHistoricoPagamentoPF, cmbSerasaHistoricoPagamentoPF_Internalname, StringUtil.BoolToStr( A683SerasaHistoricoPagamentoPF), 1, cmbSerasaHistoricoPagamentoPF_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbSerasaHistoricoPagamentoPF.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,138);\"", "", true, 0, "HLP_Serasa.htm");
         cmbSerasaHistoricoPagamentoPF.CurrentValue = StringUtil.BoolToStr( A683SerasaHistoricoPagamentoPF);
         AssignProp("", false, cmbSerasaHistoricoPagamentoPF_Internalname, "Values", (string)(cmbSerasaHistoricoPagamentoPF.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbSerasaRecomendaCompleto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbSerasaRecomendaCompleto_Internalname, "Recomenda Completo", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 143,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbSerasaRecomendaCompleto, cmbSerasaRecomendaCompleto_Internalname, StringUtil.BoolToStr( A684SerasaRecomendaCompleto), 1, cmbSerasaRecomendaCompleto_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbSerasaRecomendaCompleto.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,143);\"", "", true, 0, "HLP_Serasa.htm");
         cmbSerasaRecomendaCompleto.CurrentValue = StringUtil.BoolToStr( A684SerasaRecomendaCompleto);
         AssignProp("", false, cmbSerasaRecomendaCompleto_Internalname, "Values", (string)(cmbSerasaRecomendaCompleto.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaScore_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaScore_Internalname, "Score", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 148,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaScore_Internalname, ((0==A685SerasaScore)&&IsIns( )||n685SerasaScore ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A685SerasaScore), 4, 0, ",", ""))), ((0==A685SerasaScore)&&IsIns( )||n685SerasaScore ? "" : StringUtil.LTrim( ((edtSerasaScore_Enabled!=0) ? context.localUtil.Format( (decimal)(A685SerasaScore), "ZZZ9") : context.localUtil.Format( (decimal)(A685SerasaScore), "ZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,148);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaScore_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaScore_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Serasa.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaTaxa_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaTaxa_Internalname, "Taxa", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 153,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaTaxa_Internalname, ((Convert.ToDecimal(0)==A686SerasaTaxa)&&IsIns( )||n686SerasaTaxa ? "" : StringUtil.LTrim( StringUtil.NToC( A686SerasaTaxa, 15, 2, ",", ""))), ((Convert.ToDecimal(0)==A686SerasaTaxa)&&IsIns( )||n686SerasaTaxa ? "" : StringUtil.LTrim( ((edtSerasaTaxa_Enabled!=0) ? context.localUtil.Format( A686SerasaTaxa, "ZZZZZZZZZZZ9.99") : context.localUtil.Format( A686SerasaTaxa, "ZZZZZZZZZZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,153);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaTaxa_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaTaxa_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Serasa.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaMensagemScore_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaMensagemScore_Internalname, "Mensagem Score", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 158,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtSerasaMensagemScore_Internalname, A687SerasaMensagemScore, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,158);\"", 0, 1, edtSerasaMensagemScore_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "250", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_Serasa.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaSituacaoCPF_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaSituacaoCPF_Internalname, "Situacao CPF", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 163,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaSituacaoCPF_Internalname, A688SerasaSituacaoCPF, StringUtil.RTrim( context.localUtil.Format( A688SerasaSituacaoCPF, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,163);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaSituacaoCPF_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaSituacaoCPF_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Serasa.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaDataNascimento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaDataNascimento_Internalname, "Data Nascimento", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 168,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtSerasaDataNascimento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtSerasaDataNascimento_Internalname, context.localUtil.Format(A689SerasaDataNascimento, "99/99/99"), context.localUtil.Format( A689SerasaDataNascimento, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,168);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaDataNascimento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaDataNascimento_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Serasa.htm");
         GxWebStd.gx_bitmap( context, edtSerasaDataNascimento_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtSerasaDataNascimento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Serasa.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaGenero_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaGenero_Internalname, "Genero", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 173,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaGenero_Internalname, A690SerasaGenero, StringUtil.RTrim( context.localUtil.Format( A690SerasaGenero, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,173);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaGenero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaGenero_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Serasa.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaNomeMae_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaNomeMae_Internalname, "Nome Mae", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 178,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaNomeMae_Internalname, A691SerasaNomeMae, StringUtil.RTrim( context.localUtil.Format( A691SerasaNomeMae, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,178);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaNomeMae_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaNomeMae_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Serasa.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSerasaGrafia_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSerasaGrafia_Internalname, "Grafia", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 183,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSerasaGrafia_Internalname, A692SerasaGrafia, StringUtil.RTrim( context.localUtil.Format( A692SerasaGrafia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,183);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSerasaGrafia_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtSerasaGrafia_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Serasa.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 188,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Serasa.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 190,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Serasa.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 192,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Serasa.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_clienteid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 197,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboclienteid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18ComboClienteId), 9, 0, ",", "")), StringUtil.LTrim( ((edtavComboclienteid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV18ComboClienteId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV18ComboClienteId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,197);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboclienteid_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboclienteid_Visible, edtavComboclienteid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Serasa.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         E112E2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV14DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vCLIENTEID_DATA"), AV13ClienteId_Data);
               /* Read saved values. */
               Z662SerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z662SerasaId"), ",", "."), 18, MidpointRounding.ToEven));
               Z665SerasaCreatedAt = context.localUtil.CToT( cgiGet( "Z665SerasaCreatedAt"), 0);
               n665SerasaCreatedAt = ((DateTime.MinValue==A665SerasaCreatedAt) ? true : false);
               Z663SerasaNumeroProposta = cgiGet( "Z663SerasaNumeroProposta");
               n663SerasaNumeroProposta = (String.IsNullOrEmpty(StringUtil.RTrim( A663SerasaNumeroProposta)) ? true : false);
               Z664SerasaPolitica = context.localUtil.CToN( cgiGet( "Z664SerasaPolitica"), ",", ".");
               n664SerasaPolitica = ((Convert.ToDecimal(0)==A664SerasaPolitica) ? true : false);
               Z666SerasaTipoVenda = cgiGet( "Z666SerasaTipoVenda");
               n666SerasaTipoVenda = (String.IsNullOrEmpty(StringUtil.RTrim( A666SerasaTipoVenda)) ? true : false);
               Z667SerasaCodTipoVenda = context.localUtil.CToN( cgiGet( "Z667SerasaCodTipoVenda"), ",", ".");
               n667SerasaCodTipoVenda = ((Convert.ToDecimal(0)==A667SerasaCodTipoVenda) ? true : false);
               Z668SerasaCodNivelRisco = context.localUtil.CToN( cgiGet( "Z668SerasaCodNivelRisco"), ",", ".");
               n668SerasaCodNivelRisco = ((Convert.ToDecimal(0)==A668SerasaCodNivelRisco) ? true : false);
               Z669SerasaTipoRecomendacao = cgiGet( "Z669SerasaTipoRecomendacao");
               n669SerasaTipoRecomendacao = (String.IsNullOrEmpty(StringUtil.RTrim( A669SerasaTipoRecomendacao)) ? true : false);
               Z670SerasaRecomendacaoVenda = cgiGet( "Z670SerasaRecomendacaoVenda");
               n670SerasaRecomendacaoVenda = (String.IsNullOrEmpty(StringUtil.RTrim( A670SerasaRecomendacaoVenda)) ? true : false);
               Z671SerasaCpfRegular = StringUtil.StrToBool( cgiGet( "Z671SerasaCpfRegular"));
               n671SerasaCpfRegular = ((false==A671SerasaCpfRegular) ? true : false);
               Z672SerasaRetricaoAtiva = StringUtil.StrToBool( cgiGet( "Z672SerasaRetricaoAtiva"));
               n672SerasaRetricaoAtiva = ((false==A672SerasaRetricaoAtiva) ? true : false);
               Z673SerasaProtestoAtivo = StringUtil.StrToBool( cgiGet( "Z673SerasaProtestoAtivo"));
               n673SerasaProtestoAtivo = ((false==A673SerasaProtestoAtivo) ? true : false);
               Z674SerasaBaixoComprometimento = StringUtil.StrToBool( cgiGet( "Z674SerasaBaixoComprometimento"));
               n674SerasaBaixoComprometimento = ((false==A674SerasaBaixoComprometimento) ? true : false);
               Z675SerasaValorLimiteRecomendado = context.localUtil.CToN( cgiGet( "Z675SerasaValorLimiteRecomendado"), ",", ".");
               n675SerasaValorLimiteRecomendado = ((Convert.ToDecimal(0)==A675SerasaValorLimiteRecomendado) ? true : false);
               Z676SerasaFaixaDeRendaEstimada = context.localUtil.CToN( cgiGet( "Z676SerasaFaixaDeRendaEstimada"), ",", ".");
               n676SerasaFaixaDeRendaEstimada = ((Convert.ToDecimal(0)==A676SerasaFaixaDeRendaEstimada) ? true : false);
               Z677SerasaMensagemRendaEstimada = cgiGet( "Z677SerasaMensagemRendaEstimada");
               n677SerasaMensagemRendaEstimada = (String.IsNullOrEmpty(StringUtil.RTrim( A677SerasaMensagemRendaEstimada)) ? true : false);
               Z678SerasaAnotacoesCompletas = StringUtil.StrToBool( cgiGet( "Z678SerasaAnotacoesCompletas"));
               n678SerasaAnotacoesCompletas = ((false==A678SerasaAnotacoesCompletas) ? true : false);
               Z679SerasaConsultasDetalhadas = StringUtil.StrToBool( cgiGet( "Z679SerasaConsultasDetalhadas"));
               n679SerasaConsultasDetalhadas = ((false==A679SerasaConsultasDetalhadas) ? true : false);
               Z680SerasaAnotacoesConsultaSPC = StringUtil.StrToBool( cgiGet( "Z680SerasaAnotacoesConsultaSPC"));
               n680SerasaAnotacoesConsultaSPC = ((false==A680SerasaAnotacoesConsultaSPC) ? true : false);
               Z681SerasaParticipacaoSocietaria = StringUtil.StrToBool( cgiGet( "Z681SerasaParticipacaoSocietaria"));
               n681SerasaParticipacaoSocietaria = ((false==A681SerasaParticipacaoSocietaria) ? true : false);
               Z682SerasaRendaEstimada = StringUtil.StrToBool( cgiGet( "Z682SerasaRendaEstimada"));
               n682SerasaRendaEstimada = ((false==A682SerasaRendaEstimada) ? true : false);
               Z683SerasaHistoricoPagamentoPF = StringUtil.StrToBool( cgiGet( "Z683SerasaHistoricoPagamentoPF"));
               n683SerasaHistoricoPagamentoPF = ((false==A683SerasaHistoricoPagamentoPF) ? true : false);
               Z684SerasaRecomendaCompleto = StringUtil.StrToBool( cgiGet( "Z684SerasaRecomendaCompleto"));
               n684SerasaRecomendaCompleto = ((false==A684SerasaRecomendaCompleto) ? true : false);
               Z685SerasaScore = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z685SerasaScore"), ",", "."), 18, MidpointRounding.ToEven));
               n685SerasaScore = ((0==A685SerasaScore) ? true : false);
               Z686SerasaTaxa = context.localUtil.CToN( cgiGet( "Z686SerasaTaxa"), ",", ".");
               n686SerasaTaxa = ((Convert.ToDecimal(0)==A686SerasaTaxa) ? true : false);
               Z687SerasaMensagemScore = cgiGet( "Z687SerasaMensagemScore");
               n687SerasaMensagemScore = (String.IsNullOrEmpty(StringUtil.RTrim( A687SerasaMensagemScore)) ? true : false);
               Z688SerasaSituacaoCPF = cgiGet( "Z688SerasaSituacaoCPF");
               n688SerasaSituacaoCPF = (String.IsNullOrEmpty(StringUtil.RTrim( A688SerasaSituacaoCPF)) ? true : false);
               Z689SerasaDataNascimento = context.localUtil.CToD( cgiGet( "Z689SerasaDataNascimento"), 0);
               n689SerasaDataNascimento = ((DateTime.MinValue==A689SerasaDataNascimento) ? true : false);
               Z690SerasaGenero = cgiGet( "Z690SerasaGenero");
               n690SerasaGenero = (String.IsNullOrEmpty(StringUtil.RTrim( A690SerasaGenero)) ? true : false);
               Z691SerasaNomeMae = cgiGet( "Z691SerasaNomeMae");
               n691SerasaNomeMae = (String.IsNullOrEmpty(StringUtil.RTrim( A691SerasaNomeMae)) ? true : false);
               Z692SerasaGrafia = cgiGet( "Z692SerasaGrafia");
               n692SerasaGrafia = (String.IsNullOrEmpty(StringUtil.RTrim( A692SerasaGrafia)) ? true : false);
               Z168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z168ClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n168ClienteId = ((0==A168ClienteId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N168ClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n168ClienteId = ((0==A168ClienteId) ? true : false);
               AV7SerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vSERASAID"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CLIENTEID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11Insert_ClienteId", StringUtil.LTrimStr( (decimal)(AV11Insert_ClienteId), 9, 0));
               A774SerasaJSON = cgiGet( "SERASAJSON");
               n774SerasaJSON = false;
               n774SerasaJSON = (String.IsNullOrEmpty(StringUtil.RTrim( A774SerasaJSON)) ? true : false);
               A170ClienteRazaoSocial = cgiGet( "CLIENTERAZAOSOCIAL");
               n170ClienteRazaoSocial = false;
               A775SerasaCountAcoes_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( "SERASACOUNTACOES_F"), ",", "."), 18, MidpointRounding.ToEven));
               n775SerasaCountAcoes_F = false;
               A776SerasaCountEnderecos_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( "SERASACOUNTENDERECOS_F"), ",", "."), 18, MidpointRounding.ToEven));
               n776SerasaCountEnderecos_F = false;
               A777SerasaCountProtestos_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( "SERASACOUNTPROTESTOS_F"), ",", "."), 18, MidpointRounding.ToEven));
               n777SerasaCountProtestos_F = false;
               A778SerasaCountOcorrencias_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( "SERASACOUNTOCORRENCIAS_F"), ",", "."), 18, MidpointRounding.ToEven));
               n778SerasaCountOcorrencias_F = false;
               A779SerasaCountCheques_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( "SERASACOUNTCHEQUES_F"), ",", "."), 18, MidpointRounding.ToEven));
               n779SerasaCountCheques_F = false;
               AV19Pgmname = cgiGet( "vPGMNAME");
               Combo_clienteid_Objectcall = cgiGet( "COMBO_CLIENTEID_Objectcall");
               Combo_clienteid_Class = cgiGet( "COMBO_CLIENTEID_Class");
               Combo_clienteid_Icontype = cgiGet( "COMBO_CLIENTEID_Icontype");
               Combo_clienteid_Icon = cgiGet( "COMBO_CLIENTEID_Icon");
               Combo_clienteid_Caption = cgiGet( "COMBO_CLIENTEID_Caption");
               Combo_clienteid_Tooltip = cgiGet( "COMBO_CLIENTEID_Tooltip");
               Combo_clienteid_Cls = cgiGet( "COMBO_CLIENTEID_Cls");
               Combo_clienteid_Selectedvalue_set = cgiGet( "COMBO_CLIENTEID_Selectedvalue_set");
               Combo_clienteid_Selectedvalue_get = cgiGet( "COMBO_CLIENTEID_Selectedvalue_get");
               Combo_clienteid_Selectedtext_set = cgiGet( "COMBO_CLIENTEID_Selectedtext_set");
               Combo_clienteid_Selectedtext_get = cgiGet( "COMBO_CLIENTEID_Selectedtext_get");
               Combo_clienteid_Gamoauthtoken = cgiGet( "COMBO_CLIENTEID_Gamoauthtoken");
               Combo_clienteid_Ddointernalname = cgiGet( "COMBO_CLIENTEID_Ddointernalname");
               Combo_clienteid_Titlecontrolalign = cgiGet( "COMBO_CLIENTEID_Titlecontrolalign");
               Combo_clienteid_Dropdownoptionstype = cgiGet( "COMBO_CLIENTEID_Dropdownoptionstype");
               Combo_clienteid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_CLIENTEID_Enabled"));
               Combo_clienteid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_CLIENTEID_Visible"));
               Combo_clienteid_Titlecontrolidtoreplace = cgiGet( "COMBO_CLIENTEID_Titlecontrolidtoreplace");
               Combo_clienteid_Datalisttype = cgiGet( "COMBO_CLIENTEID_Datalisttype");
               Combo_clienteid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_CLIENTEID_Allowmultipleselection"));
               Combo_clienteid_Datalistfixedvalues = cgiGet( "COMBO_CLIENTEID_Datalistfixedvalues");
               Combo_clienteid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_CLIENTEID_Isgriditem"));
               Combo_clienteid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_CLIENTEID_Hasdescription"));
               Combo_clienteid_Datalistproc = cgiGet( "COMBO_CLIENTEID_Datalistproc");
               Combo_clienteid_Datalistprocparametersprefix = cgiGet( "COMBO_CLIENTEID_Datalistprocparametersprefix");
               Combo_clienteid_Remoteservicesparameters = cgiGet( "COMBO_CLIENTEID_Remoteservicesparameters");
               Combo_clienteid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_CLIENTEID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_clienteid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_CLIENTEID_Includeonlyselectedoption"));
               Combo_clienteid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_CLIENTEID_Includeselectalloption"));
               Combo_clienteid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CLIENTEID_Emptyitem"));
               Combo_clienteid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_CLIENTEID_Includeaddnewoption"));
               Combo_clienteid_Htmltemplate = cgiGet( "COMBO_CLIENTEID_Htmltemplate");
               Combo_clienteid_Multiplevaluestype = cgiGet( "COMBO_CLIENTEID_Multiplevaluestype");
               Combo_clienteid_Loadingdata = cgiGet( "COMBO_CLIENTEID_Loadingdata");
               Combo_clienteid_Noresultsfound = cgiGet( "COMBO_CLIENTEID_Noresultsfound");
               Combo_clienteid_Emptyitemtext = cgiGet( "COMBO_CLIENTEID_Emptyitemtext");
               Combo_clienteid_Onlyselectedvalues = cgiGet( "COMBO_CLIENTEID_Onlyselectedvalues");
               Combo_clienteid_Selectalltext = cgiGet( "COMBO_CLIENTEID_Selectalltext");
               Combo_clienteid_Multiplevaluesseparator = cgiGet( "COMBO_CLIENTEID_Multiplevaluesseparator");
               Combo_clienteid_Addnewoptiontext = cgiGet( "COMBO_CLIENTEID_Addnewoptiontext");
               Combo_clienteid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_CLIENTEID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
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
               A662SerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSerasaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n662SerasaId = false;
               AssignAttri("", false, "A662SerasaId", StringUtil.LTrimStr( (decimal)(A662SerasaId), 9, 0));
               n168ClienteId = ((StringUtil.StrCmp(cgiGet( edtClienteId_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIENTEID");
                  AnyError = 1;
                  GX_FocusControl = edtClienteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A168ClienteId = 0;
                  n168ClienteId = false;
                  AssignAttri("", false, "A168ClienteId", (n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
               }
               else
               {
                  A168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A168ClienteId", (n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
               }
               A663SerasaNumeroProposta = cgiGet( edtSerasaNumeroProposta_Internalname);
               n663SerasaNumeroProposta = false;
               AssignAttri("", false, "A663SerasaNumeroProposta", A663SerasaNumeroProposta);
               n663SerasaNumeroProposta = (String.IsNullOrEmpty(StringUtil.RTrim( A663SerasaNumeroProposta)) ? true : false);
               n664SerasaPolitica = ((StringUtil.StrCmp(cgiGet( edtSerasaPolitica_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSerasaPolitica_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSerasaPolitica_Internalname), ",", ".") > 999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SERASAPOLITICA");
                  AnyError = 1;
                  GX_FocusControl = edtSerasaPolitica_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A664SerasaPolitica = 0;
                  n664SerasaPolitica = false;
                  AssignAttri("", false, "A664SerasaPolitica", (n664SerasaPolitica ? "" : StringUtil.LTrim( StringUtil.NToC( A664SerasaPolitica, 15, 2, ".", ""))));
               }
               else
               {
                  A664SerasaPolitica = context.localUtil.CToN( cgiGet( edtSerasaPolitica_Internalname), ",", ".");
                  AssignAttri("", false, "A664SerasaPolitica", (n664SerasaPolitica ? "" : StringUtil.LTrim( StringUtil.NToC( A664SerasaPolitica, 15, 2, ".", ""))));
               }
               if ( context.localUtil.VCDateTime( cgiGet( edtSerasaCreatedAt_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Serasa Created At"}), 1, "SERASACREATEDAT");
                  AnyError = 1;
                  GX_FocusControl = edtSerasaCreatedAt_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A665SerasaCreatedAt = (DateTime)(DateTime.MinValue);
                  n665SerasaCreatedAt = false;
                  AssignAttri("", false, "A665SerasaCreatedAt", context.localUtil.TToC( A665SerasaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A665SerasaCreatedAt = context.localUtil.CToT( cgiGet( edtSerasaCreatedAt_Internalname));
                  n665SerasaCreatedAt = false;
                  AssignAttri("", false, "A665SerasaCreatedAt", context.localUtil.TToC( A665SerasaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
               }
               n665SerasaCreatedAt = ((DateTime.MinValue==A665SerasaCreatedAt) ? true : false);
               A666SerasaTipoVenda = cgiGet( edtSerasaTipoVenda_Internalname);
               n666SerasaTipoVenda = false;
               AssignAttri("", false, "A666SerasaTipoVenda", A666SerasaTipoVenda);
               n666SerasaTipoVenda = (String.IsNullOrEmpty(StringUtil.RTrim( A666SerasaTipoVenda)) ? true : false);
               n667SerasaCodTipoVenda = ((StringUtil.StrCmp(cgiGet( edtSerasaCodTipoVenda_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSerasaCodTipoVenda_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSerasaCodTipoVenda_Internalname), ",", ".") > 999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SERASACODTIPOVENDA");
                  AnyError = 1;
                  GX_FocusControl = edtSerasaCodTipoVenda_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A667SerasaCodTipoVenda = 0;
                  n667SerasaCodTipoVenda = false;
                  AssignAttri("", false, "A667SerasaCodTipoVenda", (n667SerasaCodTipoVenda ? "" : StringUtil.LTrim( StringUtil.NToC( A667SerasaCodTipoVenda, 15, 2, ".", ""))));
               }
               else
               {
                  A667SerasaCodTipoVenda = context.localUtil.CToN( cgiGet( edtSerasaCodTipoVenda_Internalname), ",", ".");
                  AssignAttri("", false, "A667SerasaCodTipoVenda", (n667SerasaCodTipoVenda ? "" : StringUtil.LTrim( StringUtil.NToC( A667SerasaCodTipoVenda, 15, 2, ".", ""))));
               }
               n668SerasaCodNivelRisco = ((StringUtil.StrCmp(cgiGet( edtSerasaCodNivelRisco_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSerasaCodNivelRisco_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSerasaCodNivelRisco_Internalname), ",", ".") > 999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SERASACODNIVELRISCO");
                  AnyError = 1;
                  GX_FocusControl = edtSerasaCodNivelRisco_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A668SerasaCodNivelRisco = 0;
                  n668SerasaCodNivelRisco = false;
                  AssignAttri("", false, "A668SerasaCodNivelRisco", (n668SerasaCodNivelRisco ? "" : StringUtil.LTrim( StringUtil.NToC( A668SerasaCodNivelRisco, 15, 2, ".", ""))));
               }
               else
               {
                  A668SerasaCodNivelRisco = context.localUtil.CToN( cgiGet( edtSerasaCodNivelRisco_Internalname), ",", ".");
                  AssignAttri("", false, "A668SerasaCodNivelRisco", (n668SerasaCodNivelRisco ? "" : StringUtil.LTrim( StringUtil.NToC( A668SerasaCodNivelRisco, 15, 2, ".", ""))));
               }
               A669SerasaTipoRecomendacao = cgiGet( edtSerasaTipoRecomendacao_Internalname);
               n669SerasaTipoRecomendacao = false;
               AssignAttri("", false, "A669SerasaTipoRecomendacao", A669SerasaTipoRecomendacao);
               n669SerasaTipoRecomendacao = (String.IsNullOrEmpty(StringUtil.RTrim( A669SerasaTipoRecomendacao)) ? true : false);
               A670SerasaRecomendacaoVenda = cgiGet( edtSerasaRecomendacaoVenda_Internalname);
               n670SerasaRecomendacaoVenda = false;
               AssignAttri("", false, "A670SerasaRecomendacaoVenda", A670SerasaRecomendacaoVenda);
               n670SerasaRecomendacaoVenda = (String.IsNullOrEmpty(StringUtil.RTrim( A670SerasaRecomendacaoVenda)) ? true : false);
               cmbSerasaCpfRegular.CurrentValue = cgiGet( cmbSerasaCpfRegular_Internalname);
               A671SerasaCpfRegular = StringUtil.StrToBool( cgiGet( cmbSerasaCpfRegular_Internalname));
               n671SerasaCpfRegular = false;
               AssignAttri("", false, "A671SerasaCpfRegular", A671SerasaCpfRegular);
               n671SerasaCpfRegular = ((false==A671SerasaCpfRegular) ? true : false);
               cmbSerasaRetricaoAtiva.CurrentValue = cgiGet( cmbSerasaRetricaoAtiva_Internalname);
               A672SerasaRetricaoAtiva = StringUtil.StrToBool( cgiGet( cmbSerasaRetricaoAtiva_Internalname));
               n672SerasaRetricaoAtiva = false;
               AssignAttri("", false, "A672SerasaRetricaoAtiva", A672SerasaRetricaoAtiva);
               n672SerasaRetricaoAtiva = ((false==A672SerasaRetricaoAtiva) ? true : false);
               cmbSerasaProtestoAtivo.CurrentValue = cgiGet( cmbSerasaProtestoAtivo_Internalname);
               A673SerasaProtestoAtivo = StringUtil.StrToBool( cgiGet( cmbSerasaProtestoAtivo_Internalname));
               n673SerasaProtestoAtivo = false;
               AssignAttri("", false, "A673SerasaProtestoAtivo", A673SerasaProtestoAtivo);
               n673SerasaProtestoAtivo = ((false==A673SerasaProtestoAtivo) ? true : false);
               cmbSerasaBaixoComprometimento.CurrentValue = cgiGet( cmbSerasaBaixoComprometimento_Internalname);
               A674SerasaBaixoComprometimento = StringUtil.StrToBool( cgiGet( cmbSerasaBaixoComprometimento_Internalname));
               n674SerasaBaixoComprometimento = false;
               AssignAttri("", false, "A674SerasaBaixoComprometimento", A674SerasaBaixoComprometimento);
               n674SerasaBaixoComprometimento = ((false==A674SerasaBaixoComprometimento) ? true : false);
               n675SerasaValorLimiteRecomendado = ((StringUtil.StrCmp(cgiGet( edtSerasaValorLimiteRecomendado_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSerasaValorLimiteRecomendado_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSerasaValorLimiteRecomendado_Internalname), ",", ".") > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SERASAVALORLIMITERECOMENDADO");
                  AnyError = 1;
                  GX_FocusControl = edtSerasaValorLimiteRecomendado_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A675SerasaValorLimiteRecomendado = 0;
                  n675SerasaValorLimiteRecomendado = false;
                  AssignAttri("", false, "A675SerasaValorLimiteRecomendado", (n675SerasaValorLimiteRecomendado ? "" : StringUtil.LTrim( StringUtil.NToC( A675SerasaValorLimiteRecomendado, 18, 2, ".", ""))));
               }
               else
               {
                  A675SerasaValorLimiteRecomendado = context.localUtil.CToN( cgiGet( edtSerasaValorLimiteRecomendado_Internalname), ",", ".");
                  AssignAttri("", false, "A675SerasaValorLimiteRecomendado", (n675SerasaValorLimiteRecomendado ? "" : StringUtil.LTrim( StringUtil.NToC( A675SerasaValorLimiteRecomendado, 18, 2, ".", ""))));
               }
               n676SerasaFaixaDeRendaEstimada = ((StringUtil.StrCmp(cgiGet( edtSerasaFaixaDeRendaEstimada_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSerasaFaixaDeRendaEstimada_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSerasaFaixaDeRendaEstimada_Internalname), ",", ".") > 999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SERASAFAIXADERENDAESTIMADA");
                  AnyError = 1;
                  GX_FocusControl = edtSerasaFaixaDeRendaEstimada_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A676SerasaFaixaDeRendaEstimada = 0;
                  n676SerasaFaixaDeRendaEstimada = false;
                  AssignAttri("", false, "A676SerasaFaixaDeRendaEstimada", (n676SerasaFaixaDeRendaEstimada ? "" : StringUtil.LTrim( StringUtil.NToC( A676SerasaFaixaDeRendaEstimada, 15, 2, ".", ""))));
               }
               else
               {
                  A676SerasaFaixaDeRendaEstimada = context.localUtil.CToN( cgiGet( edtSerasaFaixaDeRendaEstimada_Internalname), ",", ".");
                  AssignAttri("", false, "A676SerasaFaixaDeRendaEstimada", (n676SerasaFaixaDeRendaEstimada ? "" : StringUtil.LTrim( StringUtil.NToC( A676SerasaFaixaDeRendaEstimada, 15, 2, ".", ""))));
               }
               A677SerasaMensagemRendaEstimada = cgiGet( edtSerasaMensagemRendaEstimada_Internalname);
               n677SerasaMensagemRendaEstimada = false;
               AssignAttri("", false, "A677SerasaMensagemRendaEstimada", A677SerasaMensagemRendaEstimada);
               n677SerasaMensagemRendaEstimada = (String.IsNullOrEmpty(StringUtil.RTrim( A677SerasaMensagemRendaEstimada)) ? true : false);
               cmbSerasaAnotacoesCompletas.CurrentValue = cgiGet( cmbSerasaAnotacoesCompletas_Internalname);
               A678SerasaAnotacoesCompletas = StringUtil.StrToBool( cgiGet( cmbSerasaAnotacoesCompletas_Internalname));
               n678SerasaAnotacoesCompletas = false;
               AssignAttri("", false, "A678SerasaAnotacoesCompletas", A678SerasaAnotacoesCompletas);
               n678SerasaAnotacoesCompletas = ((false==A678SerasaAnotacoesCompletas) ? true : false);
               cmbSerasaConsultasDetalhadas.CurrentValue = cgiGet( cmbSerasaConsultasDetalhadas_Internalname);
               A679SerasaConsultasDetalhadas = StringUtil.StrToBool( cgiGet( cmbSerasaConsultasDetalhadas_Internalname));
               n679SerasaConsultasDetalhadas = false;
               AssignAttri("", false, "A679SerasaConsultasDetalhadas", A679SerasaConsultasDetalhadas);
               n679SerasaConsultasDetalhadas = ((false==A679SerasaConsultasDetalhadas) ? true : false);
               cmbSerasaAnotacoesConsultaSPC.CurrentValue = cgiGet( cmbSerasaAnotacoesConsultaSPC_Internalname);
               A680SerasaAnotacoesConsultaSPC = StringUtil.StrToBool( cgiGet( cmbSerasaAnotacoesConsultaSPC_Internalname));
               n680SerasaAnotacoesConsultaSPC = false;
               AssignAttri("", false, "A680SerasaAnotacoesConsultaSPC", A680SerasaAnotacoesConsultaSPC);
               n680SerasaAnotacoesConsultaSPC = ((false==A680SerasaAnotacoesConsultaSPC) ? true : false);
               cmbSerasaParticipacaoSocietaria.CurrentValue = cgiGet( cmbSerasaParticipacaoSocietaria_Internalname);
               A681SerasaParticipacaoSocietaria = StringUtil.StrToBool( cgiGet( cmbSerasaParticipacaoSocietaria_Internalname));
               n681SerasaParticipacaoSocietaria = false;
               AssignAttri("", false, "A681SerasaParticipacaoSocietaria", A681SerasaParticipacaoSocietaria);
               n681SerasaParticipacaoSocietaria = ((false==A681SerasaParticipacaoSocietaria) ? true : false);
               cmbSerasaRendaEstimada.CurrentValue = cgiGet( cmbSerasaRendaEstimada_Internalname);
               A682SerasaRendaEstimada = StringUtil.StrToBool( cgiGet( cmbSerasaRendaEstimada_Internalname));
               n682SerasaRendaEstimada = false;
               AssignAttri("", false, "A682SerasaRendaEstimada", A682SerasaRendaEstimada);
               n682SerasaRendaEstimada = ((false==A682SerasaRendaEstimada) ? true : false);
               cmbSerasaHistoricoPagamentoPF.CurrentValue = cgiGet( cmbSerasaHistoricoPagamentoPF_Internalname);
               A683SerasaHistoricoPagamentoPF = StringUtil.StrToBool( cgiGet( cmbSerasaHistoricoPagamentoPF_Internalname));
               n683SerasaHistoricoPagamentoPF = false;
               AssignAttri("", false, "A683SerasaHistoricoPagamentoPF", A683SerasaHistoricoPagamentoPF);
               n683SerasaHistoricoPagamentoPF = ((false==A683SerasaHistoricoPagamentoPF) ? true : false);
               cmbSerasaRecomendaCompleto.CurrentValue = cgiGet( cmbSerasaRecomendaCompleto_Internalname);
               A684SerasaRecomendaCompleto = StringUtil.StrToBool( cgiGet( cmbSerasaRecomendaCompleto_Internalname));
               n684SerasaRecomendaCompleto = false;
               AssignAttri("", false, "A684SerasaRecomendaCompleto", A684SerasaRecomendaCompleto);
               n684SerasaRecomendaCompleto = ((false==A684SerasaRecomendaCompleto) ? true : false);
               n685SerasaScore = ((StringUtil.StrCmp(cgiGet( edtSerasaScore_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSerasaScore_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSerasaScore_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SERASASCORE");
                  AnyError = 1;
                  GX_FocusControl = edtSerasaScore_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A685SerasaScore = 0;
                  n685SerasaScore = false;
                  AssignAttri("", false, "A685SerasaScore", (n685SerasaScore ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A685SerasaScore), 4, 0, ".", ""))));
               }
               else
               {
                  A685SerasaScore = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSerasaScore_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A685SerasaScore", (n685SerasaScore ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A685SerasaScore), 4, 0, ".", ""))));
               }
               n686SerasaTaxa = ((StringUtil.StrCmp(cgiGet( edtSerasaTaxa_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSerasaTaxa_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSerasaTaxa_Internalname), ",", ".") > 999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SERASATAXA");
                  AnyError = 1;
                  GX_FocusControl = edtSerasaTaxa_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A686SerasaTaxa = 0;
                  n686SerasaTaxa = false;
                  AssignAttri("", false, "A686SerasaTaxa", (n686SerasaTaxa ? "" : StringUtil.LTrim( StringUtil.NToC( A686SerasaTaxa, 15, 2, ".", ""))));
               }
               else
               {
                  A686SerasaTaxa = context.localUtil.CToN( cgiGet( edtSerasaTaxa_Internalname), ",", ".");
                  AssignAttri("", false, "A686SerasaTaxa", (n686SerasaTaxa ? "" : StringUtil.LTrim( StringUtil.NToC( A686SerasaTaxa, 15, 2, ".", ""))));
               }
               A687SerasaMensagemScore = cgiGet( edtSerasaMensagemScore_Internalname);
               n687SerasaMensagemScore = false;
               AssignAttri("", false, "A687SerasaMensagemScore", A687SerasaMensagemScore);
               n687SerasaMensagemScore = (String.IsNullOrEmpty(StringUtil.RTrim( A687SerasaMensagemScore)) ? true : false);
               A688SerasaSituacaoCPF = cgiGet( edtSerasaSituacaoCPF_Internalname);
               n688SerasaSituacaoCPF = false;
               AssignAttri("", false, "A688SerasaSituacaoCPF", A688SerasaSituacaoCPF);
               n688SerasaSituacaoCPF = (String.IsNullOrEmpty(StringUtil.RTrim( A688SerasaSituacaoCPF)) ? true : false);
               if ( context.localUtil.VCDate( cgiGet( edtSerasaDataNascimento_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Serasa Data Nascimento"}), 1, "SERASADATANASCIMENTO");
                  AnyError = 1;
                  GX_FocusControl = edtSerasaDataNascimento_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A689SerasaDataNascimento = DateTime.MinValue;
                  n689SerasaDataNascimento = false;
                  AssignAttri("", false, "A689SerasaDataNascimento", context.localUtil.Format(A689SerasaDataNascimento, "99/99/99"));
               }
               else
               {
                  A689SerasaDataNascimento = context.localUtil.CToD( cgiGet( edtSerasaDataNascimento_Internalname), 2);
                  n689SerasaDataNascimento = false;
                  AssignAttri("", false, "A689SerasaDataNascimento", context.localUtil.Format(A689SerasaDataNascimento, "99/99/99"));
               }
               n689SerasaDataNascimento = ((DateTime.MinValue==A689SerasaDataNascimento) ? true : false);
               A690SerasaGenero = cgiGet( edtSerasaGenero_Internalname);
               n690SerasaGenero = false;
               AssignAttri("", false, "A690SerasaGenero", A690SerasaGenero);
               n690SerasaGenero = (String.IsNullOrEmpty(StringUtil.RTrim( A690SerasaGenero)) ? true : false);
               A691SerasaNomeMae = cgiGet( edtSerasaNomeMae_Internalname);
               n691SerasaNomeMae = false;
               AssignAttri("", false, "A691SerasaNomeMae", A691SerasaNomeMae);
               n691SerasaNomeMae = (String.IsNullOrEmpty(StringUtil.RTrim( A691SerasaNomeMae)) ? true : false);
               A692SerasaGrafia = cgiGet( edtSerasaGrafia_Internalname);
               n692SerasaGrafia = false;
               AssignAttri("", false, "A692SerasaGrafia", A692SerasaGrafia);
               n692SerasaGrafia = (String.IsNullOrEmpty(StringUtil.RTrim( A692SerasaGrafia)) ? true : false);
               AV18ComboClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavComboclienteid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV18ComboClienteId", StringUtil.LTrimStr( (decimal)(AV18ComboClienteId), 9, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Serasa");
               A662SerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSerasaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n662SerasaId = false;
               AssignAttri("", false, "A662SerasaId", StringUtil.LTrimStr( (decimal)(A662SerasaId), 9, 0));
               forbiddenHiddens.Add("SerasaId", context.localUtil.Format( (decimal)(A662SerasaId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_ClienteId", context.localUtil.Format( (decimal)(AV11Insert_ClienteId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A662SerasaId != Z662SerasaId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("serasa:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A662SerasaId = (int)(Math.Round(NumberUtil.Val( GetPar( "SerasaId"), "."), 18, MidpointRounding.ToEven));
                  n662SerasaId = false;
                  AssignAttri("", false, "A662SerasaId", StringUtil.LTrimStr( (decimal)(A662SerasaId), 9, 0));
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
                     sMode84 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode84;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound84 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_2E0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "SERASAID");
                        AnyError = 1;
                        GX_FocusControl = edtSerasaId_Internalname;
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
                           E112E2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E122E2 ();
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
            E122E2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2E84( ) ;
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
            DisableAttributes2E84( ) ;
         }
         AssignProp("", false, edtavComboclienteid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboclienteid_Enabled), 5, 0), true);
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

      protected void CONFIRM_2E0( )
      {
         BeforeValidate2E84( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2E84( ) ;
            }
            else
            {
               CheckExtendedTable2E84( ) ;
               CloseExtendedTableCursors2E84( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption2E0( )
      {
      }

      protected void E112E2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV14DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV14DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtClienteId_Visible = 0;
         AssignProp("", false, edtClienteId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtClienteId_Visible), 5, 0), true);
         AV18ComboClienteId = 0;
         AssignAttri("", false, "AV18ComboClienteId", StringUtil.LTrimStr( (decimal)(AV18ComboClienteId), 9, 0));
         edtavComboclienteid_Visible = 0;
         AssignProp("", false, edtavComboclienteid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboclienteid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOCLIENTEID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV19Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV20GXV1 = 1;
            AssignAttri("", false, "AV20GXV1", StringUtil.LTrimStr( (decimal)(AV20GXV1), 8, 0));
            while ( AV20GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV20GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "ClienteId") == 0 )
               {
                  AV11Insert_ClienteId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_ClienteId", StringUtil.LTrimStr( (decimal)(AV11Insert_ClienteId), 9, 0));
                  if ( ! (0==AV11Insert_ClienteId) )
                  {
                     AV18ComboClienteId = AV11Insert_ClienteId;
                     AssignAttri("", false, "AV18ComboClienteId", StringUtil.LTrimStr( (decimal)(AV18ComboClienteId), 9, 0));
                     Combo_clienteid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV18ComboClienteId), 9, 0));
                     ucCombo_clienteid.SendProperty(context, "", false, Combo_clienteid_Internalname, "SelectedValue_set", Combo_clienteid_Selectedvalue_set);
                     GXt_char2 = AV17Combo_DataJson;
                     new serasaloaddvcombo(context ).execute(  "ClienteId",  "GET",  false,  AV7SerasaId,  AV12TrnContextAtt.gxTpr_Attributevalue, out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV15ComboSelectedValue", AV15ComboSelectedValue);
                     AssignAttri("", false, "AV16ComboSelectedText", AV16ComboSelectedText);
                     AV17Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV17Combo_DataJson", AV17Combo_DataJson);
                     Combo_clienteid_Selectedtext_set = AV16ComboSelectedText;
                     ucCombo_clienteid.SendProperty(context, "", false, Combo_clienteid_Internalname, "SelectedText_set", Combo_clienteid_Selectedtext_set);
                     Combo_clienteid_Enabled = false;
                     ucCombo_clienteid.SendProperty(context, "", false, Combo_clienteid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_clienteid_Enabled));
                  }
               }
               AV20GXV1 = (int)(AV20GXV1+1);
               AssignAttri("", false, "AV20GXV1", StringUtil.LTrimStr( (decimal)(AV20GXV1), 8, 0));
            }
         }
      }

      protected void E122E2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S112( )
      {
         /* 'LOADCOMBOCLIENTEID' Routine */
         returnInSub = false;
         GXt_char2 = AV17Combo_DataJson;
         new serasaloaddvcombo(context ).execute(  "ClienteId",  Gx_mode,  false,  AV7SerasaId,  "", out  AV15ComboSelectedValue, out  AV16ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV15ComboSelectedValue", AV15ComboSelectedValue);
         AssignAttri("", false, "AV16ComboSelectedText", AV16ComboSelectedText);
         AV17Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV17Combo_DataJson", AV17Combo_DataJson);
         Combo_clienteid_Selectedvalue_set = AV15ComboSelectedValue;
         ucCombo_clienteid.SendProperty(context, "", false, Combo_clienteid_Internalname, "SelectedValue_set", Combo_clienteid_Selectedvalue_set);
         Combo_clienteid_Selectedtext_set = AV16ComboSelectedText;
         ucCombo_clienteid.SendProperty(context, "", false, Combo_clienteid_Internalname, "SelectedText_set", Combo_clienteid_Selectedtext_set);
         AV18ComboClienteId = (int)(Math.Round(NumberUtil.Val( AV15ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV18ComboClienteId", StringUtil.LTrimStr( (decimal)(AV18ComboClienteId), 9, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_clienteid_Enabled = false;
            ucCombo_clienteid.SendProperty(context, "", false, Combo_clienteid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_clienteid_Enabled));
         }
      }

      protected void ZM2E84( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z665SerasaCreatedAt = T002E3_A665SerasaCreatedAt[0];
               Z663SerasaNumeroProposta = T002E3_A663SerasaNumeroProposta[0];
               Z664SerasaPolitica = T002E3_A664SerasaPolitica[0];
               Z666SerasaTipoVenda = T002E3_A666SerasaTipoVenda[0];
               Z667SerasaCodTipoVenda = T002E3_A667SerasaCodTipoVenda[0];
               Z668SerasaCodNivelRisco = T002E3_A668SerasaCodNivelRisco[0];
               Z669SerasaTipoRecomendacao = T002E3_A669SerasaTipoRecomendacao[0];
               Z670SerasaRecomendacaoVenda = T002E3_A670SerasaRecomendacaoVenda[0];
               Z671SerasaCpfRegular = T002E3_A671SerasaCpfRegular[0];
               Z672SerasaRetricaoAtiva = T002E3_A672SerasaRetricaoAtiva[0];
               Z673SerasaProtestoAtivo = T002E3_A673SerasaProtestoAtivo[0];
               Z674SerasaBaixoComprometimento = T002E3_A674SerasaBaixoComprometimento[0];
               Z675SerasaValorLimiteRecomendado = T002E3_A675SerasaValorLimiteRecomendado[0];
               Z676SerasaFaixaDeRendaEstimada = T002E3_A676SerasaFaixaDeRendaEstimada[0];
               Z677SerasaMensagemRendaEstimada = T002E3_A677SerasaMensagemRendaEstimada[0];
               Z678SerasaAnotacoesCompletas = T002E3_A678SerasaAnotacoesCompletas[0];
               Z679SerasaConsultasDetalhadas = T002E3_A679SerasaConsultasDetalhadas[0];
               Z680SerasaAnotacoesConsultaSPC = T002E3_A680SerasaAnotacoesConsultaSPC[0];
               Z681SerasaParticipacaoSocietaria = T002E3_A681SerasaParticipacaoSocietaria[0];
               Z682SerasaRendaEstimada = T002E3_A682SerasaRendaEstimada[0];
               Z683SerasaHistoricoPagamentoPF = T002E3_A683SerasaHistoricoPagamentoPF[0];
               Z684SerasaRecomendaCompleto = T002E3_A684SerasaRecomendaCompleto[0];
               Z685SerasaScore = T002E3_A685SerasaScore[0];
               Z686SerasaTaxa = T002E3_A686SerasaTaxa[0];
               Z687SerasaMensagemScore = T002E3_A687SerasaMensagemScore[0];
               Z688SerasaSituacaoCPF = T002E3_A688SerasaSituacaoCPF[0];
               Z689SerasaDataNascimento = T002E3_A689SerasaDataNascimento[0];
               Z690SerasaGenero = T002E3_A690SerasaGenero[0];
               Z691SerasaNomeMae = T002E3_A691SerasaNomeMae[0];
               Z692SerasaGrafia = T002E3_A692SerasaGrafia[0];
               Z168ClienteId = T002E3_A168ClienteId[0];
            }
            else
            {
               Z665SerasaCreatedAt = A665SerasaCreatedAt;
               Z663SerasaNumeroProposta = A663SerasaNumeroProposta;
               Z664SerasaPolitica = A664SerasaPolitica;
               Z666SerasaTipoVenda = A666SerasaTipoVenda;
               Z667SerasaCodTipoVenda = A667SerasaCodTipoVenda;
               Z668SerasaCodNivelRisco = A668SerasaCodNivelRisco;
               Z669SerasaTipoRecomendacao = A669SerasaTipoRecomendacao;
               Z670SerasaRecomendacaoVenda = A670SerasaRecomendacaoVenda;
               Z671SerasaCpfRegular = A671SerasaCpfRegular;
               Z672SerasaRetricaoAtiva = A672SerasaRetricaoAtiva;
               Z673SerasaProtestoAtivo = A673SerasaProtestoAtivo;
               Z674SerasaBaixoComprometimento = A674SerasaBaixoComprometimento;
               Z675SerasaValorLimiteRecomendado = A675SerasaValorLimiteRecomendado;
               Z676SerasaFaixaDeRendaEstimada = A676SerasaFaixaDeRendaEstimada;
               Z677SerasaMensagemRendaEstimada = A677SerasaMensagemRendaEstimada;
               Z678SerasaAnotacoesCompletas = A678SerasaAnotacoesCompletas;
               Z679SerasaConsultasDetalhadas = A679SerasaConsultasDetalhadas;
               Z680SerasaAnotacoesConsultaSPC = A680SerasaAnotacoesConsultaSPC;
               Z681SerasaParticipacaoSocietaria = A681SerasaParticipacaoSocietaria;
               Z682SerasaRendaEstimada = A682SerasaRendaEstimada;
               Z683SerasaHistoricoPagamentoPF = A683SerasaHistoricoPagamentoPF;
               Z684SerasaRecomendaCompleto = A684SerasaRecomendaCompleto;
               Z685SerasaScore = A685SerasaScore;
               Z686SerasaTaxa = A686SerasaTaxa;
               Z687SerasaMensagemScore = A687SerasaMensagemScore;
               Z688SerasaSituacaoCPF = A688SerasaSituacaoCPF;
               Z689SerasaDataNascimento = A689SerasaDataNascimento;
               Z690SerasaGenero = A690SerasaGenero;
               Z691SerasaNomeMae = A691SerasaNomeMae;
               Z692SerasaGrafia = A692SerasaGrafia;
               Z168ClienteId = A168ClienteId;
            }
         }
         if ( GX_JID == -10 )
         {
            Z662SerasaId = A662SerasaId;
            Z665SerasaCreatedAt = A665SerasaCreatedAt;
            Z663SerasaNumeroProposta = A663SerasaNumeroProposta;
            Z664SerasaPolitica = A664SerasaPolitica;
            Z666SerasaTipoVenda = A666SerasaTipoVenda;
            Z667SerasaCodTipoVenda = A667SerasaCodTipoVenda;
            Z668SerasaCodNivelRisco = A668SerasaCodNivelRisco;
            Z669SerasaTipoRecomendacao = A669SerasaTipoRecomendacao;
            Z670SerasaRecomendacaoVenda = A670SerasaRecomendacaoVenda;
            Z671SerasaCpfRegular = A671SerasaCpfRegular;
            Z672SerasaRetricaoAtiva = A672SerasaRetricaoAtiva;
            Z673SerasaProtestoAtivo = A673SerasaProtestoAtivo;
            Z674SerasaBaixoComprometimento = A674SerasaBaixoComprometimento;
            Z675SerasaValorLimiteRecomendado = A675SerasaValorLimiteRecomendado;
            Z676SerasaFaixaDeRendaEstimada = A676SerasaFaixaDeRendaEstimada;
            Z677SerasaMensagemRendaEstimada = A677SerasaMensagemRendaEstimada;
            Z678SerasaAnotacoesCompletas = A678SerasaAnotacoesCompletas;
            Z679SerasaConsultasDetalhadas = A679SerasaConsultasDetalhadas;
            Z680SerasaAnotacoesConsultaSPC = A680SerasaAnotacoesConsultaSPC;
            Z681SerasaParticipacaoSocietaria = A681SerasaParticipacaoSocietaria;
            Z682SerasaRendaEstimada = A682SerasaRendaEstimada;
            Z683SerasaHistoricoPagamentoPF = A683SerasaHistoricoPagamentoPF;
            Z684SerasaRecomendaCompleto = A684SerasaRecomendaCompleto;
            Z685SerasaScore = A685SerasaScore;
            Z686SerasaTaxa = A686SerasaTaxa;
            Z687SerasaMensagemScore = A687SerasaMensagemScore;
            Z688SerasaSituacaoCPF = A688SerasaSituacaoCPF;
            Z689SerasaDataNascimento = A689SerasaDataNascimento;
            Z690SerasaGenero = A690SerasaGenero;
            Z691SerasaNomeMae = A691SerasaNomeMae;
            Z692SerasaGrafia = A692SerasaGrafia;
            Z774SerasaJSON = A774SerasaJSON;
            Z168ClienteId = A168ClienteId;
            Z775SerasaCountAcoes_F = A775SerasaCountAcoes_F;
            Z776SerasaCountEnderecos_F = A776SerasaCountEnderecos_F;
            Z777SerasaCountProtestos_F = A777SerasaCountProtestos_F;
            Z778SerasaCountOcorrencias_F = A778SerasaCountOcorrencias_F;
            Z779SerasaCountCheques_F = A779SerasaCountCheques_F;
            Z170ClienteRazaoSocial = A170ClienteRazaoSocial;
         }
      }

      protected void standaloneNotModal( )
      {
         edtSerasaId_Enabled = 0;
         AssignProp("", false, edtSerasaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaId_Enabled), 5, 0), true);
         AV19Pgmname = "Serasa";
         AssignAttri("", false, "AV19Pgmname", AV19Pgmname);
         edtSerasaId_Enabled = 0;
         AssignProp("", false, edtSerasaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7SerasaId) )
         {
            A662SerasaId = AV7SerasaId;
            n662SerasaId = false;
            AssignAttri("", false, "A662SerasaId", StringUtil.LTrimStr( (decimal)(A662SerasaId), 9, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_ClienteId) )
         {
            edtClienteId_Enabled = 0;
            AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
         }
         else
         {
            edtClienteId_Enabled = 1;
            AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A665SerasaCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n665SerasaCreatedAt = false;
            AssignAttri("", false, "A665SerasaCreatedAt", context.localUtil.TToC( A665SerasaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_ClienteId) )
         {
            A168ClienteId = AV11Insert_ClienteId;
            n168ClienteId = false;
            AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV18ComboClienteId) )
            {
               A168ClienteId = 0;
               n168ClienteId = false;
               AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
               n168ClienteId = true;
               n168ClienteId = true;
               AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV18ComboClienteId) )
               {
                  A168ClienteId = AV18ComboClienteId;
                  n168ClienteId = false;
                  AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
               }
            }
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
            /* Using cursor T002E6 */
            pr_default.execute(3, new Object[] {n662SerasaId, A662SerasaId});
            if ( (pr_default.getStatus(3) != 101) )
            {
               A775SerasaCountAcoes_F = T002E6_A775SerasaCountAcoes_F[0];
               n775SerasaCountAcoes_F = T002E6_n775SerasaCountAcoes_F[0];
            }
            else
            {
               A775SerasaCountAcoes_F = 0;
               n775SerasaCountAcoes_F = false;
               AssignAttri("", false, "A775SerasaCountAcoes_F", StringUtil.LTrimStr( (decimal)(A775SerasaCountAcoes_F), 4, 0));
            }
            pr_default.close(3);
            /* Using cursor T002E8 */
            pr_default.execute(4, new Object[] {n662SerasaId, A662SerasaId});
            if ( (pr_default.getStatus(4) != 101) )
            {
               A776SerasaCountEnderecos_F = T002E8_A776SerasaCountEnderecos_F[0];
               n776SerasaCountEnderecos_F = T002E8_n776SerasaCountEnderecos_F[0];
            }
            else
            {
               A776SerasaCountEnderecos_F = 0;
               n776SerasaCountEnderecos_F = false;
               AssignAttri("", false, "A776SerasaCountEnderecos_F", StringUtil.LTrimStr( (decimal)(A776SerasaCountEnderecos_F), 4, 0));
            }
            pr_default.close(4);
            /* Using cursor T002E10 */
            pr_default.execute(5, new Object[] {n662SerasaId, A662SerasaId});
            if ( (pr_default.getStatus(5) != 101) )
            {
               A777SerasaCountProtestos_F = T002E10_A777SerasaCountProtestos_F[0];
               n777SerasaCountProtestos_F = T002E10_n777SerasaCountProtestos_F[0];
            }
            else
            {
               A777SerasaCountProtestos_F = 0;
               n777SerasaCountProtestos_F = false;
               AssignAttri("", false, "A777SerasaCountProtestos_F", StringUtil.LTrimStr( (decimal)(A777SerasaCountProtestos_F), 4, 0));
            }
            pr_default.close(5);
            /* Using cursor T002E12 */
            pr_default.execute(6, new Object[] {n662SerasaId, A662SerasaId});
            if ( (pr_default.getStatus(6) != 101) )
            {
               A778SerasaCountOcorrencias_F = T002E12_A778SerasaCountOcorrencias_F[0];
               n778SerasaCountOcorrencias_F = T002E12_n778SerasaCountOcorrencias_F[0];
            }
            else
            {
               A778SerasaCountOcorrencias_F = 0;
               n778SerasaCountOcorrencias_F = false;
               AssignAttri("", false, "A778SerasaCountOcorrencias_F", StringUtil.LTrimStr( (decimal)(A778SerasaCountOcorrencias_F), 4, 0));
            }
            pr_default.close(6);
            /* Using cursor T002E14 */
            pr_default.execute(7, new Object[] {n662SerasaId, A662SerasaId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               A779SerasaCountCheques_F = T002E14_A779SerasaCountCheques_F[0];
               n779SerasaCountCheques_F = T002E14_n779SerasaCountCheques_F[0];
            }
            else
            {
               A779SerasaCountCheques_F = 0;
               n779SerasaCountCheques_F = false;
               AssignAttri("", false, "A779SerasaCountCheques_F", StringUtil.LTrimStr( (decimal)(A779SerasaCountCheques_F), 4, 0));
            }
            pr_default.close(7);
            /* Using cursor T002E4 */
            pr_default.execute(2, new Object[] {n168ClienteId, A168ClienteId});
            A170ClienteRazaoSocial = T002E4_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = T002E4_n170ClienteRazaoSocial[0];
            pr_default.close(2);
         }
      }

      protected void Load2E84( )
      {
         /* Using cursor T002E20 */
         pr_default.execute(8, new Object[] {n662SerasaId, A662SerasaId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound84 = 1;
            A665SerasaCreatedAt = T002E20_A665SerasaCreatedAt[0];
            n665SerasaCreatedAt = T002E20_n665SerasaCreatedAt[0];
            AssignAttri("", false, "A665SerasaCreatedAt", context.localUtil.TToC( A665SerasaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            A170ClienteRazaoSocial = T002E20_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = T002E20_n170ClienteRazaoSocial[0];
            A663SerasaNumeroProposta = T002E20_A663SerasaNumeroProposta[0];
            n663SerasaNumeroProposta = T002E20_n663SerasaNumeroProposta[0];
            AssignAttri("", false, "A663SerasaNumeroProposta", A663SerasaNumeroProposta);
            A664SerasaPolitica = T002E20_A664SerasaPolitica[0];
            n664SerasaPolitica = T002E20_n664SerasaPolitica[0];
            AssignAttri("", false, "A664SerasaPolitica", ((Convert.ToDecimal(0)==A664SerasaPolitica)&&IsIns( )||n664SerasaPolitica ? "" : StringUtil.LTrim( StringUtil.NToC( A664SerasaPolitica, 15, 2, ".", ""))));
            A666SerasaTipoVenda = T002E20_A666SerasaTipoVenda[0];
            n666SerasaTipoVenda = T002E20_n666SerasaTipoVenda[0];
            AssignAttri("", false, "A666SerasaTipoVenda", A666SerasaTipoVenda);
            A667SerasaCodTipoVenda = T002E20_A667SerasaCodTipoVenda[0];
            n667SerasaCodTipoVenda = T002E20_n667SerasaCodTipoVenda[0];
            AssignAttri("", false, "A667SerasaCodTipoVenda", ((Convert.ToDecimal(0)==A667SerasaCodTipoVenda)&&IsIns( )||n667SerasaCodTipoVenda ? "" : StringUtil.LTrim( StringUtil.NToC( A667SerasaCodTipoVenda, 15, 2, ".", ""))));
            A668SerasaCodNivelRisco = T002E20_A668SerasaCodNivelRisco[0];
            n668SerasaCodNivelRisco = T002E20_n668SerasaCodNivelRisco[0];
            AssignAttri("", false, "A668SerasaCodNivelRisco", ((Convert.ToDecimal(0)==A668SerasaCodNivelRisco)&&IsIns( )||n668SerasaCodNivelRisco ? "" : StringUtil.LTrim( StringUtil.NToC( A668SerasaCodNivelRisco, 15, 2, ".", ""))));
            A669SerasaTipoRecomendacao = T002E20_A669SerasaTipoRecomendacao[0];
            n669SerasaTipoRecomendacao = T002E20_n669SerasaTipoRecomendacao[0];
            AssignAttri("", false, "A669SerasaTipoRecomendacao", A669SerasaTipoRecomendacao);
            A670SerasaRecomendacaoVenda = T002E20_A670SerasaRecomendacaoVenda[0];
            n670SerasaRecomendacaoVenda = T002E20_n670SerasaRecomendacaoVenda[0];
            AssignAttri("", false, "A670SerasaRecomendacaoVenda", A670SerasaRecomendacaoVenda);
            A671SerasaCpfRegular = T002E20_A671SerasaCpfRegular[0];
            n671SerasaCpfRegular = T002E20_n671SerasaCpfRegular[0];
            AssignAttri("", false, "A671SerasaCpfRegular", A671SerasaCpfRegular);
            A672SerasaRetricaoAtiva = T002E20_A672SerasaRetricaoAtiva[0];
            n672SerasaRetricaoAtiva = T002E20_n672SerasaRetricaoAtiva[0];
            AssignAttri("", false, "A672SerasaRetricaoAtiva", A672SerasaRetricaoAtiva);
            A673SerasaProtestoAtivo = T002E20_A673SerasaProtestoAtivo[0];
            n673SerasaProtestoAtivo = T002E20_n673SerasaProtestoAtivo[0];
            AssignAttri("", false, "A673SerasaProtestoAtivo", A673SerasaProtestoAtivo);
            A674SerasaBaixoComprometimento = T002E20_A674SerasaBaixoComprometimento[0];
            n674SerasaBaixoComprometimento = T002E20_n674SerasaBaixoComprometimento[0];
            AssignAttri("", false, "A674SerasaBaixoComprometimento", A674SerasaBaixoComprometimento);
            A675SerasaValorLimiteRecomendado = T002E20_A675SerasaValorLimiteRecomendado[0];
            n675SerasaValorLimiteRecomendado = T002E20_n675SerasaValorLimiteRecomendado[0];
            AssignAttri("", false, "A675SerasaValorLimiteRecomendado", ((Convert.ToDecimal(0)==A675SerasaValorLimiteRecomendado)&&IsIns( )||n675SerasaValorLimiteRecomendado ? "" : StringUtil.LTrim( StringUtil.NToC( A675SerasaValorLimiteRecomendado, 18, 2, ".", ""))));
            A676SerasaFaixaDeRendaEstimada = T002E20_A676SerasaFaixaDeRendaEstimada[0];
            n676SerasaFaixaDeRendaEstimada = T002E20_n676SerasaFaixaDeRendaEstimada[0];
            AssignAttri("", false, "A676SerasaFaixaDeRendaEstimada", ((Convert.ToDecimal(0)==A676SerasaFaixaDeRendaEstimada)&&IsIns( )||n676SerasaFaixaDeRendaEstimada ? "" : StringUtil.LTrim( StringUtil.NToC( A676SerasaFaixaDeRendaEstimada, 15, 2, ".", ""))));
            A677SerasaMensagemRendaEstimada = T002E20_A677SerasaMensagemRendaEstimada[0];
            n677SerasaMensagemRendaEstimada = T002E20_n677SerasaMensagemRendaEstimada[0];
            AssignAttri("", false, "A677SerasaMensagemRendaEstimada", A677SerasaMensagemRendaEstimada);
            A678SerasaAnotacoesCompletas = T002E20_A678SerasaAnotacoesCompletas[0];
            n678SerasaAnotacoesCompletas = T002E20_n678SerasaAnotacoesCompletas[0];
            AssignAttri("", false, "A678SerasaAnotacoesCompletas", A678SerasaAnotacoesCompletas);
            A679SerasaConsultasDetalhadas = T002E20_A679SerasaConsultasDetalhadas[0];
            n679SerasaConsultasDetalhadas = T002E20_n679SerasaConsultasDetalhadas[0];
            AssignAttri("", false, "A679SerasaConsultasDetalhadas", A679SerasaConsultasDetalhadas);
            A680SerasaAnotacoesConsultaSPC = T002E20_A680SerasaAnotacoesConsultaSPC[0];
            n680SerasaAnotacoesConsultaSPC = T002E20_n680SerasaAnotacoesConsultaSPC[0];
            AssignAttri("", false, "A680SerasaAnotacoesConsultaSPC", A680SerasaAnotacoesConsultaSPC);
            A681SerasaParticipacaoSocietaria = T002E20_A681SerasaParticipacaoSocietaria[0];
            n681SerasaParticipacaoSocietaria = T002E20_n681SerasaParticipacaoSocietaria[0];
            AssignAttri("", false, "A681SerasaParticipacaoSocietaria", A681SerasaParticipacaoSocietaria);
            A682SerasaRendaEstimada = T002E20_A682SerasaRendaEstimada[0];
            n682SerasaRendaEstimada = T002E20_n682SerasaRendaEstimada[0];
            AssignAttri("", false, "A682SerasaRendaEstimada", A682SerasaRendaEstimada);
            A683SerasaHistoricoPagamentoPF = T002E20_A683SerasaHistoricoPagamentoPF[0];
            n683SerasaHistoricoPagamentoPF = T002E20_n683SerasaHistoricoPagamentoPF[0];
            AssignAttri("", false, "A683SerasaHistoricoPagamentoPF", A683SerasaHistoricoPagamentoPF);
            A684SerasaRecomendaCompleto = T002E20_A684SerasaRecomendaCompleto[0];
            n684SerasaRecomendaCompleto = T002E20_n684SerasaRecomendaCompleto[0];
            AssignAttri("", false, "A684SerasaRecomendaCompleto", A684SerasaRecomendaCompleto);
            A685SerasaScore = T002E20_A685SerasaScore[0];
            n685SerasaScore = T002E20_n685SerasaScore[0];
            AssignAttri("", false, "A685SerasaScore", ((0==A685SerasaScore)&&IsIns( )||n685SerasaScore ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A685SerasaScore), 4, 0, ".", ""))));
            A686SerasaTaxa = T002E20_A686SerasaTaxa[0];
            n686SerasaTaxa = T002E20_n686SerasaTaxa[0];
            AssignAttri("", false, "A686SerasaTaxa", ((Convert.ToDecimal(0)==A686SerasaTaxa)&&IsIns( )||n686SerasaTaxa ? "" : StringUtil.LTrim( StringUtil.NToC( A686SerasaTaxa, 15, 2, ".", ""))));
            A687SerasaMensagemScore = T002E20_A687SerasaMensagemScore[0];
            n687SerasaMensagemScore = T002E20_n687SerasaMensagemScore[0];
            AssignAttri("", false, "A687SerasaMensagemScore", A687SerasaMensagemScore);
            A688SerasaSituacaoCPF = T002E20_A688SerasaSituacaoCPF[0];
            n688SerasaSituacaoCPF = T002E20_n688SerasaSituacaoCPF[0];
            AssignAttri("", false, "A688SerasaSituacaoCPF", A688SerasaSituacaoCPF);
            A689SerasaDataNascimento = T002E20_A689SerasaDataNascimento[0];
            n689SerasaDataNascimento = T002E20_n689SerasaDataNascimento[0];
            AssignAttri("", false, "A689SerasaDataNascimento", context.localUtil.Format(A689SerasaDataNascimento, "99/99/99"));
            A690SerasaGenero = T002E20_A690SerasaGenero[0];
            n690SerasaGenero = T002E20_n690SerasaGenero[0];
            AssignAttri("", false, "A690SerasaGenero", A690SerasaGenero);
            A691SerasaNomeMae = T002E20_A691SerasaNomeMae[0];
            n691SerasaNomeMae = T002E20_n691SerasaNomeMae[0];
            AssignAttri("", false, "A691SerasaNomeMae", A691SerasaNomeMae);
            A692SerasaGrafia = T002E20_A692SerasaGrafia[0];
            n692SerasaGrafia = T002E20_n692SerasaGrafia[0];
            AssignAttri("", false, "A692SerasaGrafia", A692SerasaGrafia);
            A774SerasaJSON = T002E20_A774SerasaJSON[0];
            n774SerasaJSON = T002E20_n774SerasaJSON[0];
            A168ClienteId = T002E20_A168ClienteId[0];
            n168ClienteId = T002E20_n168ClienteId[0];
            AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            A775SerasaCountAcoes_F = T002E20_A775SerasaCountAcoes_F[0];
            n775SerasaCountAcoes_F = T002E20_n775SerasaCountAcoes_F[0];
            A776SerasaCountEnderecos_F = T002E20_A776SerasaCountEnderecos_F[0];
            n776SerasaCountEnderecos_F = T002E20_n776SerasaCountEnderecos_F[0];
            A777SerasaCountProtestos_F = T002E20_A777SerasaCountProtestos_F[0];
            n777SerasaCountProtestos_F = T002E20_n777SerasaCountProtestos_F[0];
            A778SerasaCountOcorrencias_F = T002E20_A778SerasaCountOcorrencias_F[0];
            n778SerasaCountOcorrencias_F = T002E20_n778SerasaCountOcorrencias_F[0];
            A779SerasaCountCheques_F = T002E20_A779SerasaCountCheques_F[0];
            n779SerasaCountCheques_F = T002E20_n779SerasaCountCheques_F[0];
            ZM2E84( -10) ;
         }
         pr_default.close(8);
         OnLoadActions2E84( ) ;
      }

      protected void OnLoadActions2E84( )
      {
      }

      protected void CheckExtendedTable2E84( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T002E6 */
         pr_default.execute(3, new Object[] {n662SerasaId, A662SerasaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            A775SerasaCountAcoes_F = T002E6_A775SerasaCountAcoes_F[0];
            n775SerasaCountAcoes_F = T002E6_n775SerasaCountAcoes_F[0];
         }
         else
         {
            A775SerasaCountAcoes_F = 0;
            n775SerasaCountAcoes_F = false;
            AssignAttri("", false, "A775SerasaCountAcoes_F", StringUtil.LTrimStr( (decimal)(A775SerasaCountAcoes_F), 4, 0));
         }
         pr_default.close(3);
         /* Using cursor T002E8 */
         pr_default.execute(4, new Object[] {n662SerasaId, A662SerasaId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            A776SerasaCountEnderecos_F = T002E8_A776SerasaCountEnderecos_F[0];
            n776SerasaCountEnderecos_F = T002E8_n776SerasaCountEnderecos_F[0];
         }
         else
         {
            A776SerasaCountEnderecos_F = 0;
            n776SerasaCountEnderecos_F = false;
            AssignAttri("", false, "A776SerasaCountEnderecos_F", StringUtil.LTrimStr( (decimal)(A776SerasaCountEnderecos_F), 4, 0));
         }
         pr_default.close(4);
         /* Using cursor T002E10 */
         pr_default.execute(5, new Object[] {n662SerasaId, A662SerasaId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            A777SerasaCountProtestos_F = T002E10_A777SerasaCountProtestos_F[0];
            n777SerasaCountProtestos_F = T002E10_n777SerasaCountProtestos_F[0];
         }
         else
         {
            A777SerasaCountProtestos_F = 0;
            n777SerasaCountProtestos_F = false;
            AssignAttri("", false, "A777SerasaCountProtestos_F", StringUtil.LTrimStr( (decimal)(A777SerasaCountProtestos_F), 4, 0));
         }
         pr_default.close(5);
         /* Using cursor T002E12 */
         pr_default.execute(6, new Object[] {n662SerasaId, A662SerasaId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            A778SerasaCountOcorrencias_F = T002E12_A778SerasaCountOcorrencias_F[0];
            n778SerasaCountOcorrencias_F = T002E12_n778SerasaCountOcorrencias_F[0];
         }
         else
         {
            A778SerasaCountOcorrencias_F = 0;
            n778SerasaCountOcorrencias_F = false;
            AssignAttri("", false, "A778SerasaCountOcorrencias_F", StringUtil.LTrimStr( (decimal)(A778SerasaCountOcorrencias_F), 4, 0));
         }
         pr_default.close(6);
         /* Using cursor T002E14 */
         pr_default.execute(7, new Object[] {n662SerasaId, A662SerasaId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            A779SerasaCountCheques_F = T002E14_A779SerasaCountCheques_F[0];
            n779SerasaCountCheques_F = T002E14_n779SerasaCountCheques_F[0];
         }
         else
         {
            A779SerasaCountCheques_F = 0;
            n779SerasaCountCheques_F = false;
            AssignAttri("", false, "A779SerasaCountCheques_F", StringUtil.LTrimStr( (decimal)(A779SerasaCountCheques_F), 4, 0));
         }
         pr_default.close(7);
         /* Using cursor T002E4 */
         pr_default.execute(2, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A168ClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtClienteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A170ClienteRazaoSocial = T002E4_A170ClienteRazaoSocial[0];
         n170ClienteRazaoSocial = T002E4_n170ClienteRazaoSocial[0];
         pr_default.close(2);
         if ( ( A675SerasaValorLimiteRecomendado < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "SERASAVALORLIMITERECOMENDADO");
            AnyError = 1;
            GX_FocusControl = edtSerasaValorLimiteRecomendado_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors2E84( )
      {
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(6);
         pr_default.close(7);
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_12( int A662SerasaId )
      {
         /* Using cursor T002E22 */
         pr_default.execute(9, new Object[] {n662SerasaId, A662SerasaId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            A775SerasaCountAcoes_F = T002E22_A775SerasaCountAcoes_F[0];
            n775SerasaCountAcoes_F = T002E22_n775SerasaCountAcoes_F[0];
         }
         else
         {
            A775SerasaCountAcoes_F = 0;
            n775SerasaCountAcoes_F = false;
            AssignAttri("", false, "A775SerasaCountAcoes_F", StringUtil.LTrimStr( (decimal)(A775SerasaCountAcoes_F), 4, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A775SerasaCountAcoes_F), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_13( int A662SerasaId )
      {
         /* Using cursor T002E24 */
         pr_default.execute(10, new Object[] {n662SerasaId, A662SerasaId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            A776SerasaCountEnderecos_F = T002E24_A776SerasaCountEnderecos_F[0];
            n776SerasaCountEnderecos_F = T002E24_n776SerasaCountEnderecos_F[0];
         }
         else
         {
            A776SerasaCountEnderecos_F = 0;
            n776SerasaCountEnderecos_F = false;
            AssignAttri("", false, "A776SerasaCountEnderecos_F", StringUtil.LTrimStr( (decimal)(A776SerasaCountEnderecos_F), 4, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A776SerasaCountEnderecos_F), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_14( int A662SerasaId )
      {
         /* Using cursor T002E26 */
         pr_default.execute(11, new Object[] {n662SerasaId, A662SerasaId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            A777SerasaCountProtestos_F = T002E26_A777SerasaCountProtestos_F[0];
            n777SerasaCountProtestos_F = T002E26_n777SerasaCountProtestos_F[0];
         }
         else
         {
            A777SerasaCountProtestos_F = 0;
            n777SerasaCountProtestos_F = false;
            AssignAttri("", false, "A777SerasaCountProtestos_F", StringUtil.LTrimStr( (decimal)(A777SerasaCountProtestos_F), 4, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A777SerasaCountProtestos_F), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void gxLoad_15( int A662SerasaId )
      {
         /* Using cursor T002E28 */
         pr_default.execute(12, new Object[] {n662SerasaId, A662SerasaId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            A778SerasaCountOcorrencias_F = T002E28_A778SerasaCountOcorrencias_F[0];
            n778SerasaCountOcorrencias_F = T002E28_n778SerasaCountOcorrencias_F[0];
         }
         else
         {
            A778SerasaCountOcorrencias_F = 0;
            n778SerasaCountOcorrencias_F = false;
            AssignAttri("", false, "A778SerasaCountOcorrencias_F", StringUtil.LTrimStr( (decimal)(A778SerasaCountOcorrencias_F), 4, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A778SerasaCountOcorrencias_F), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void gxLoad_16( int A662SerasaId )
      {
         /* Using cursor T002E30 */
         pr_default.execute(13, new Object[] {n662SerasaId, A662SerasaId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            A779SerasaCountCheques_F = T002E30_A779SerasaCountCheques_F[0];
            n779SerasaCountCheques_F = T002E30_n779SerasaCountCheques_F[0];
         }
         else
         {
            A779SerasaCountCheques_F = 0;
            n779SerasaCountCheques_F = false;
            AssignAttri("", false, "A779SerasaCountCheques_F", StringUtil.LTrimStr( (decimal)(A779SerasaCountCheques_F), 4, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A779SerasaCountCheques_F), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(13) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(13);
      }

      protected void gxLoad_11( int A168ClienteId )
      {
         /* Using cursor T002E31 */
         pr_default.execute(14, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( (0==A168ClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtClienteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A170ClienteRazaoSocial = T002E31_A170ClienteRazaoSocial[0];
         n170ClienteRazaoSocial = T002E31_n170ClienteRazaoSocial[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A170ClienteRazaoSocial)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void GetKey2E84( )
      {
         /* Using cursor T002E32 */
         pr_default.execute(15, new Object[] {n662SerasaId, A662SerasaId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound84 = 1;
         }
         else
         {
            RcdFound84 = 0;
         }
         pr_default.close(15);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002E3 */
         pr_default.execute(1, new Object[] {n662SerasaId, A662SerasaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2E84( 10) ;
            RcdFound84 = 1;
            A662SerasaId = T002E3_A662SerasaId[0];
            n662SerasaId = T002E3_n662SerasaId[0];
            AssignAttri("", false, "A662SerasaId", StringUtil.LTrimStr( (decimal)(A662SerasaId), 9, 0));
            A665SerasaCreatedAt = T002E3_A665SerasaCreatedAt[0];
            n665SerasaCreatedAt = T002E3_n665SerasaCreatedAt[0];
            AssignAttri("", false, "A665SerasaCreatedAt", context.localUtil.TToC( A665SerasaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            A663SerasaNumeroProposta = T002E3_A663SerasaNumeroProposta[0];
            n663SerasaNumeroProposta = T002E3_n663SerasaNumeroProposta[0];
            AssignAttri("", false, "A663SerasaNumeroProposta", A663SerasaNumeroProposta);
            A664SerasaPolitica = T002E3_A664SerasaPolitica[0];
            n664SerasaPolitica = T002E3_n664SerasaPolitica[0];
            AssignAttri("", false, "A664SerasaPolitica", ((Convert.ToDecimal(0)==A664SerasaPolitica)&&IsIns( )||n664SerasaPolitica ? "" : StringUtil.LTrim( StringUtil.NToC( A664SerasaPolitica, 15, 2, ".", ""))));
            A666SerasaTipoVenda = T002E3_A666SerasaTipoVenda[0];
            n666SerasaTipoVenda = T002E3_n666SerasaTipoVenda[0];
            AssignAttri("", false, "A666SerasaTipoVenda", A666SerasaTipoVenda);
            A667SerasaCodTipoVenda = T002E3_A667SerasaCodTipoVenda[0];
            n667SerasaCodTipoVenda = T002E3_n667SerasaCodTipoVenda[0];
            AssignAttri("", false, "A667SerasaCodTipoVenda", ((Convert.ToDecimal(0)==A667SerasaCodTipoVenda)&&IsIns( )||n667SerasaCodTipoVenda ? "" : StringUtil.LTrim( StringUtil.NToC( A667SerasaCodTipoVenda, 15, 2, ".", ""))));
            A668SerasaCodNivelRisco = T002E3_A668SerasaCodNivelRisco[0];
            n668SerasaCodNivelRisco = T002E3_n668SerasaCodNivelRisco[0];
            AssignAttri("", false, "A668SerasaCodNivelRisco", ((Convert.ToDecimal(0)==A668SerasaCodNivelRisco)&&IsIns( )||n668SerasaCodNivelRisco ? "" : StringUtil.LTrim( StringUtil.NToC( A668SerasaCodNivelRisco, 15, 2, ".", ""))));
            A669SerasaTipoRecomendacao = T002E3_A669SerasaTipoRecomendacao[0];
            n669SerasaTipoRecomendacao = T002E3_n669SerasaTipoRecomendacao[0];
            AssignAttri("", false, "A669SerasaTipoRecomendacao", A669SerasaTipoRecomendacao);
            A670SerasaRecomendacaoVenda = T002E3_A670SerasaRecomendacaoVenda[0];
            n670SerasaRecomendacaoVenda = T002E3_n670SerasaRecomendacaoVenda[0];
            AssignAttri("", false, "A670SerasaRecomendacaoVenda", A670SerasaRecomendacaoVenda);
            A671SerasaCpfRegular = T002E3_A671SerasaCpfRegular[0];
            n671SerasaCpfRegular = T002E3_n671SerasaCpfRegular[0];
            AssignAttri("", false, "A671SerasaCpfRegular", A671SerasaCpfRegular);
            A672SerasaRetricaoAtiva = T002E3_A672SerasaRetricaoAtiva[0];
            n672SerasaRetricaoAtiva = T002E3_n672SerasaRetricaoAtiva[0];
            AssignAttri("", false, "A672SerasaRetricaoAtiva", A672SerasaRetricaoAtiva);
            A673SerasaProtestoAtivo = T002E3_A673SerasaProtestoAtivo[0];
            n673SerasaProtestoAtivo = T002E3_n673SerasaProtestoAtivo[0];
            AssignAttri("", false, "A673SerasaProtestoAtivo", A673SerasaProtestoAtivo);
            A674SerasaBaixoComprometimento = T002E3_A674SerasaBaixoComprometimento[0];
            n674SerasaBaixoComprometimento = T002E3_n674SerasaBaixoComprometimento[0];
            AssignAttri("", false, "A674SerasaBaixoComprometimento", A674SerasaBaixoComprometimento);
            A675SerasaValorLimiteRecomendado = T002E3_A675SerasaValorLimiteRecomendado[0];
            n675SerasaValorLimiteRecomendado = T002E3_n675SerasaValorLimiteRecomendado[0];
            AssignAttri("", false, "A675SerasaValorLimiteRecomendado", ((Convert.ToDecimal(0)==A675SerasaValorLimiteRecomendado)&&IsIns( )||n675SerasaValorLimiteRecomendado ? "" : StringUtil.LTrim( StringUtil.NToC( A675SerasaValorLimiteRecomendado, 18, 2, ".", ""))));
            A676SerasaFaixaDeRendaEstimada = T002E3_A676SerasaFaixaDeRendaEstimada[0];
            n676SerasaFaixaDeRendaEstimada = T002E3_n676SerasaFaixaDeRendaEstimada[0];
            AssignAttri("", false, "A676SerasaFaixaDeRendaEstimada", ((Convert.ToDecimal(0)==A676SerasaFaixaDeRendaEstimada)&&IsIns( )||n676SerasaFaixaDeRendaEstimada ? "" : StringUtil.LTrim( StringUtil.NToC( A676SerasaFaixaDeRendaEstimada, 15, 2, ".", ""))));
            A677SerasaMensagemRendaEstimada = T002E3_A677SerasaMensagemRendaEstimada[0];
            n677SerasaMensagemRendaEstimada = T002E3_n677SerasaMensagemRendaEstimada[0];
            AssignAttri("", false, "A677SerasaMensagemRendaEstimada", A677SerasaMensagemRendaEstimada);
            A678SerasaAnotacoesCompletas = T002E3_A678SerasaAnotacoesCompletas[0];
            n678SerasaAnotacoesCompletas = T002E3_n678SerasaAnotacoesCompletas[0];
            AssignAttri("", false, "A678SerasaAnotacoesCompletas", A678SerasaAnotacoesCompletas);
            A679SerasaConsultasDetalhadas = T002E3_A679SerasaConsultasDetalhadas[0];
            n679SerasaConsultasDetalhadas = T002E3_n679SerasaConsultasDetalhadas[0];
            AssignAttri("", false, "A679SerasaConsultasDetalhadas", A679SerasaConsultasDetalhadas);
            A680SerasaAnotacoesConsultaSPC = T002E3_A680SerasaAnotacoesConsultaSPC[0];
            n680SerasaAnotacoesConsultaSPC = T002E3_n680SerasaAnotacoesConsultaSPC[0];
            AssignAttri("", false, "A680SerasaAnotacoesConsultaSPC", A680SerasaAnotacoesConsultaSPC);
            A681SerasaParticipacaoSocietaria = T002E3_A681SerasaParticipacaoSocietaria[0];
            n681SerasaParticipacaoSocietaria = T002E3_n681SerasaParticipacaoSocietaria[0];
            AssignAttri("", false, "A681SerasaParticipacaoSocietaria", A681SerasaParticipacaoSocietaria);
            A682SerasaRendaEstimada = T002E3_A682SerasaRendaEstimada[0];
            n682SerasaRendaEstimada = T002E3_n682SerasaRendaEstimada[0];
            AssignAttri("", false, "A682SerasaRendaEstimada", A682SerasaRendaEstimada);
            A683SerasaHistoricoPagamentoPF = T002E3_A683SerasaHistoricoPagamentoPF[0];
            n683SerasaHistoricoPagamentoPF = T002E3_n683SerasaHistoricoPagamentoPF[0];
            AssignAttri("", false, "A683SerasaHistoricoPagamentoPF", A683SerasaHistoricoPagamentoPF);
            A684SerasaRecomendaCompleto = T002E3_A684SerasaRecomendaCompleto[0];
            n684SerasaRecomendaCompleto = T002E3_n684SerasaRecomendaCompleto[0];
            AssignAttri("", false, "A684SerasaRecomendaCompleto", A684SerasaRecomendaCompleto);
            A685SerasaScore = T002E3_A685SerasaScore[0];
            n685SerasaScore = T002E3_n685SerasaScore[0];
            AssignAttri("", false, "A685SerasaScore", ((0==A685SerasaScore)&&IsIns( )||n685SerasaScore ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A685SerasaScore), 4, 0, ".", ""))));
            A686SerasaTaxa = T002E3_A686SerasaTaxa[0];
            n686SerasaTaxa = T002E3_n686SerasaTaxa[0];
            AssignAttri("", false, "A686SerasaTaxa", ((Convert.ToDecimal(0)==A686SerasaTaxa)&&IsIns( )||n686SerasaTaxa ? "" : StringUtil.LTrim( StringUtil.NToC( A686SerasaTaxa, 15, 2, ".", ""))));
            A687SerasaMensagemScore = T002E3_A687SerasaMensagemScore[0];
            n687SerasaMensagemScore = T002E3_n687SerasaMensagemScore[0];
            AssignAttri("", false, "A687SerasaMensagemScore", A687SerasaMensagemScore);
            A688SerasaSituacaoCPF = T002E3_A688SerasaSituacaoCPF[0];
            n688SerasaSituacaoCPF = T002E3_n688SerasaSituacaoCPF[0];
            AssignAttri("", false, "A688SerasaSituacaoCPF", A688SerasaSituacaoCPF);
            A689SerasaDataNascimento = T002E3_A689SerasaDataNascimento[0];
            n689SerasaDataNascimento = T002E3_n689SerasaDataNascimento[0];
            AssignAttri("", false, "A689SerasaDataNascimento", context.localUtil.Format(A689SerasaDataNascimento, "99/99/99"));
            A690SerasaGenero = T002E3_A690SerasaGenero[0];
            n690SerasaGenero = T002E3_n690SerasaGenero[0];
            AssignAttri("", false, "A690SerasaGenero", A690SerasaGenero);
            A691SerasaNomeMae = T002E3_A691SerasaNomeMae[0];
            n691SerasaNomeMae = T002E3_n691SerasaNomeMae[0];
            AssignAttri("", false, "A691SerasaNomeMae", A691SerasaNomeMae);
            A692SerasaGrafia = T002E3_A692SerasaGrafia[0];
            n692SerasaGrafia = T002E3_n692SerasaGrafia[0];
            AssignAttri("", false, "A692SerasaGrafia", A692SerasaGrafia);
            A774SerasaJSON = T002E3_A774SerasaJSON[0];
            n774SerasaJSON = T002E3_n774SerasaJSON[0];
            A168ClienteId = T002E3_A168ClienteId[0];
            n168ClienteId = T002E3_n168ClienteId[0];
            AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            Z662SerasaId = A662SerasaId;
            sMode84 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2E84( ) ;
            if ( AnyError == 1 )
            {
               RcdFound84 = 0;
               InitializeNonKey2E84( ) ;
            }
            Gx_mode = sMode84;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound84 = 0;
            InitializeNonKey2E84( ) ;
            sMode84 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode84;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2E84( ) ;
         if ( RcdFound84 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound84 = 0;
         /* Using cursor T002E33 */
         pr_default.execute(16, new Object[] {n662SerasaId, A662SerasaId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            while ( (pr_default.getStatus(16) != 101) && ( ( T002E33_A662SerasaId[0] < A662SerasaId ) ) )
            {
               pr_default.readNext(16);
            }
            if ( (pr_default.getStatus(16) != 101) && ( ( T002E33_A662SerasaId[0] > A662SerasaId ) ) )
            {
               A662SerasaId = T002E33_A662SerasaId[0];
               n662SerasaId = T002E33_n662SerasaId[0];
               AssignAttri("", false, "A662SerasaId", StringUtil.LTrimStr( (decimal)(A662SerasaId), 9, 0));
               RcdFound84 = 1;
            }
         }
         pr_default.close(16);
      }

      protected void move_previous( )
      {
         RcdFound84 = 0;
         /* Using cursor T002E34 */
         pr_default.execute(17, new Object[] {n662SerasaId, A662SerasaId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            while ( (pr_default.getStatus(17) != 101) && ( ( T002E34_A662SerasaId[0] > A662SerasaId ) ) )
            {
               pr_default.readNext(17);
            }
            if ( (pr_default.getStatus(17) != 101) && ( ( T002E34_A662SerasaId[0] < A662SerasaId ) ) )
            {
               A662SerasaId = T002E34_A662SerasaId[0];
               n662SerasaId = T002E34_n662SerasaId[0];
               AssignAttri("", false, "A662SerasaId", StringUtil.LTrimStr( (decimal)(A662SerasaId), 9, 0));
               RcdFound84 = 1;
            }
         }
         pr_default.close(17);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2E84( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtClienteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2E84( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound84 == 1 )
            {
               if ( A662SerasaId != Z662SerasaId )
               {
                  A662SerasaId = Z662SerasaId;
                  n662SerasaId = false;
                  AssignAttri("", false, "A662SerasaId", StringUtil.LTrimStr( (decimal)(A662SerasaId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SERASAID");
                  AnyError = 1;
                  GX_FocusControl = edtSerasaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtClienteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update2E84( ) ;
                  GX_FocusControl = edtClienteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A662SerasaId != Z662SerasaId )
               {
                  /* Insert record */
                  GX_FocusControl = edtClienteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2E84( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SERASAID");
                     AnyError = 1;
                     GX_FocusControl = edtSerasaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtClienteId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2E84( ) ;
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
         if ( A662SerasaId != Z662SerasaId )
         {
            A662SerasaId = Z662SerasaId;
            n662SerasaId = false;
            AssignAttri("", false, "A662SerasaId", StringUtil.LTrimStr( (decimal)(A662SerasaId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SERASAID");
            AnyError = 1;
            GX_FocusControl = edtSerasaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtClienteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency2E84( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002E2 */
            pr_default.execute(0, new Object[] {n662SerasaId, A662SerasaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Serasa"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z665SerasaCreatedAt != T002E2_A665SerasaCreatedAt[0] ) || ( StringUtil.StrCmp(Z663SerasaNumeroProposta, T002E2_A663SerasaNumeroProposta[0]) != 0 ) || ( Z664SerasaPolitica != T002E2_A664SerasaPolitica[0] ) || ( StringUtil.StrCmp(Z666SerasaTipoVenda, T002E2_A666SerasaTipoVenda[0]) != 0 ) || ( Z667SerasaCodTipoVenda != T002E2_A667SerasaCodTipoVenda[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z668SerasaCodNivelRisco != T002E2_A668SerasaCodNivelRisco[0] ) || ( StringUtil.StrCmp(Z669SerasaTipoRecomendacao, T002E2_A669SerasaTipoRecomendacao[0]) != 0 ) || ( StringUtil.StrCmp(Z670SerasaRecomendacaoVenda, T002E2_A670SerasaRecomendacaoVenda[0]) != 0 ) || ( Z671SerasaCpfRegular != T002E2_A671SerasaCpfRegular[0] ) || ( Z672SerasaRetricaoAtiva != T002E2_A672SerasaRetricaoAtiva[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z673SerasaProtestoAtivo != T002E2_A673SerasaProtestoAtivo[0] ) || ( Z674SerasaBaixoComprometimento != T002E2_A674SerasaBaixoComprometimento[0] ) || ( Z675SerasaValorLimiteRecomendado != T002E2_A675SerasaValorLimiteRecomendado[0] ) || ( Z676SerasaFaixaDeRendaEstimada != T002E2_A676SerasaFaixaDeRendaEstimada[0] ) || ( StringUtil.StrCmp(Z677SerasaMensagemRendaEstimada, T002E2_A677SerasaMensagemRendaEstimada[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z678SerasaAnotacoesCompletas != T002E2_A678SerasaAnotacoesCompletas[0] ) || ( Z679SerasaConsultasDetalhadas != T002E2_A679SerasaConsultasDetalhadas[0] ) || ( Z680SerasaAnotacoesConsultaSPC != T002E2_A680SerasaAnotacoesConsultaSPC[0] ) || ( Z681SerasaParticipacaoSocietaria != T002E2_A681SerasaParticipacaoSocietaria[0] ) || ( Z682SerasaRendaEstimada != T002E2_A682SerasaRendaEstimada[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z683SerasaHistoricoPagamentoPF != T002E2_A683SerasaHistoricoPagamentoPF[0] ) || ( Z684SerasaRecomendaCompleto != T002E2_A684SerasaRecomendaCompleto[0] ) || ( Z685SerasaScore != T002E2_A685SerasaScore[0] ) || ( Z686SerasaTaxa != T002E2_A686SerasaTaxa[0] ) || ( StringUtil.StrCmp(Z687SerasaMensagemScore, T002E2_A687SerasaMensagemScore[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z688SerasaSituacaoCPF, T002E2_A688SerasaSituacaoCPF[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z689SerasaDataNascimento ) != DateTimeUtil.ResetTime ( T002E2_A689SerasaDataNascimento[0] ) ) || ( StringUtil.StrCmp(Z690SerasaGenero, T002E2_A690SerasaGenero[0]) != 0 ) || ( StringUtil.StrCmp(Z691SerasaNomeMae, T002E2_A691SerasaNomeMae[0]) != 0 ) || ( StringUtil.StrCmp(Z692SerasaGrafia, T002E2_A692SerasaGrafia[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z168ClienteId != T002E2_A168ClienteId[0] ) )
            {
               if ( Z665SerasaCreatedAt != T002E2_A665SerasaCreatedAt[0] )
               {
                  GXUtil.WriteLog("serasa:[seudo value changed for attri]"+"SerasaCreatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z665SerasaCreatedAt);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A665SerasaCreatedAt[0]);
               }
               if ( StringUtil.StrCmp(Z663SerasaNumeroProposta, T002E2_A663SerasaNumeroProposta[0]) != 0 )
               {
                  GXUtil.WriteLog("serasa:[seudo value changed for attri]"+"SerasaNumeroProposta");
                  GXUtil.WriteLogRaw("Old: ",Z663SerasaNumeroProposta);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A663SerasaNumeroProposta[0]);
               }
               if ( Z664SerasaPolitica != T002E2_A664SerasaPolitica[0] )
               {
                  GXUtil.WriteLog("serasa:[seudo value changed for attri]"+"SerasaPolitica");
                  GXUtil.WriteLogRaw("Old: ",Z664SerasaPolitica);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A664SerasaPolitica[0]);
               }
               if ( StringUtil.StrCmp(Z666SerasaTipoVenda, T002E2_A666SerasaTipoVenda[0]) != 0 )
               {
                  GXUtil.WriteLog("serasa:[seudo value changed for attri]"+"SerasaTipoVenda");
                  GXUtil.WriteLogRaw("Old: ",Z666SerasaTipoVenda);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A666SerasaTipoVenda[0]);
               }
               if ( Z667SerasaCodTipoVenda != T002E2_A667SerasaCodTipoVenda[0] )
               {
                  GXUtil.WriteLog("serasa:[seudo value changed for attri]"+"SerasaCodTipoVenda");
                  GXUtil.WriteLogRaw("Old: ",Z667SerasaCodTipoVenda);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A667SerasaCodTipoVenda[0]);
               }
               if ( Z668SerasaCodNivelRisco != T002E2_A668SerasaCodNivelRisco[0] )
               {
                  GXUtil.WriteLog("serasa:[seudo value changed for attri]"+"SerasaCodNivelRisco");
                  GXUtil.WriteLogRaw("Old: ",Z668SerasaCodNivelRisco);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A668SerasaCodNivelRisco[0]);
               }
               if ( StringUtil.StrCmp(Z669SerasaTipoRecomendacao, T002E2_A669SerasaTipoRecomendacao[0]) != 0 )
               {
                  GXUtil.WriteLog("serasa:[seudo value changed for attri]"+"SerasaTipoRecomendacao");
                  GXUtil.WriteLogRaw("Old: ",Z669SerasaTipoRecomendacao);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A669SerasaTipoRecomendacao[0]);
               }
               if ( StringUtil.StrCmp(Z670SerasaRecomendacaoVenda, T002E2_A670SerasaRecomendacaoVenda[0]) != 0 )
               {
                  GXUtil.WriteLog("serasa:[seudo value changed for attri]"+"SerasaRecomendacaoVenda");
                  GXUtil.WriteLogRaw("Old: ",Z670SerasaRecomendacaoVenda);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A670SerasaRecomendacaoVenda[0]);
               }
               if ( Z671SerasaCpfRegular != T002E2_A671SerasaCpfRegular[0] )
               {
                  GXUtil.WriteLog("serasa:[seudo value changed for attri]"+"SerasaCpfRegular");
                  GXUtil.WriteLogRaw("Old: ",Z671SerasaCpfRegular);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A671SerasaCpfRegular[0]);
               }
               if ( Z672SerasaRetricaoAtiva != T002E2_A672SerasaRetricaoAtiva[0] )
               {
                  GXUtil.WriteLog("serasa:[seudo value changed for attri]"+"SerasaRetricaoAtiva");
                  GXUtil.WriteLogRaw("Old: ",Z672SerasaRetricaoAtiva);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A672SerasaRetricaoAtiva[0]);
               }
               if ( Z673SerasaProtestoAtivo != T002E2_A673SerasaProtestoAtivo[0] )
               {
                  GXUtil.WriteLog("serasa:[seudo value changed for attri]"+"SerasaProtestoAtivo");
                  GXUtil.WriteLogRaw("Old: ",Z673SerasaProtestoAtivo);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A673SerasaProtestoAtivo[0]);
               }
               if ( Z674SerasaBaixoComprometimento != T002E2_A674SerasaBaixoComprometimento[0] )
               {
                  GXUtil.WriteLog("serasa:[seudo value changed for attri]"+"SerasaBaixoComprometimento");
                  GXUtil.WriteLogRaw("Old: ",Z674SerasaBaixoComprometimento);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A674SerasaBaixoComprometimento[0]);
               }
               if ( Z675SerasaValorLimiteRecomendado != T002E2_A675SerasaValorLimiteRecomendado[0] )
               {
                  GXUtil.WriteLog("serasa:[seudo value changed for attri]"+"SerasaValorLimiteRecomendado");
                  GXUtil.WriteLogRaw("Old: ",Z675SerasaValorLimiteRecomendado);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A675SerasaValorLimiteRecomendado[0]);
               }
               if ( Z676SerasaFaixaDeRendaEstimada != T002E2_A676SerasaFaixaDeRendaEstimada[0] )
               {
                  GXUtil.WriteLog("serasa:[seudo value changed for attri]"+"SerasaFaixaDeRendaEstimada");
                  GXUtil.WriteLogRaw("Old: ",Z676SerasaFaixaDeRendaEstimada);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A676SerasaFaixaDeRendaEstimada[0]);
               }
               if ( StringUtil.StrCmp(Z677SerasaMensagemRendaEstimada, T002E2_A677SerasaMensagemRendaEstimada[0]) != 0 )
               {
                  GXUtil.WriteLog("serasa:[seudo value changed for attri]"+"SerasaMensagemRendaEstimada");
                  GXUtil.WriteLogRaw("Old: ",Z677SerasaMensagemRendaEstimada);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A677SerasaMensagemRendaEstimada[0]);
               }
               if ( Z678SerasaAnotacoesCompletas != T002E2_A678SerasaAnotacoesCompletas[0] )
               {
                  GXUtil.WriteLog("serasa:[seudo value changed for attri]"+"SerasaAnotacoesCompletas");
                  GXUtil.WriteLogRaw("Old: ",Z678SerasaAnotacoesCompletas);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A678SerasaAnotacoesCompletas[0]);
               }
               if ( Z679SerasaConsultasDetalhadas != T002E2_A679SerasaConsultasDetalhadas[0] )
               {
                  GXUtil.WriteLog("serasa:[seudo value changed for attri]"+"SerasaConsultasDetalhadas");
                  GXUtil.WriteLogRaw("Old: ",Z679SerasaConsultasDetalhadas);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A679SerasaConsultasDetalhadas[0]);
               }
               if ( Z680SerasaAnotacoesConsultaSPC != T002E2_A680SerasaAnotacoesConsultaSPC[0] )
               {
                  GXUtil.WriteLog("serasa:[seudo value changed for attri]"+"SerasaAnotacoesConsultaSPC");
                  GXUtil.WriteLogRaw("Old: ",Z680SerasaAnotacoesConsultaSPC);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A680SerasaAnotacoesConsultaSPC[0]);
               }
               if ( Z681SerasaParticipacaoSocietaria != T002E2_A681SerasaParticipacaoSocietaria[0] )
               {
                  GXUtil.WriteLog("serasa:[seudo value changed for attri]"+"SerasaParticipacaoSocietaria");
                  GXUtil.WriteLogRaw("Old: ",Z681SerasaParticipacaoSocietaria);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A681SerasaParticipacaoSocietaria[0]);
               }
               if ( Z682SerasaRendaEstimada != T002E2_A682SerasaRendaEstimada[0] )
               {
                  GXUtil.WriteLog("serasa:[seudo value changed for attri]"+"SerasaRendaEstimada");
                  GXUtil.WriteLogRaw("Old: ",Z682SerasaRendaEstimada);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A682SerasaRendaEstimada[0]);
               }
               if ( Z683SerasaHistoricoPagamentoPF != T002E2_A683SerasaHistoricoPagamentoPF[0] )
               {
                  GXUtil.WriteLog("serasa:[seudo value changed for attri]"+"SerasaHistoricoPagamentoPF");
                  GXUtil.WriteLogRaw("Old: ",Z683SerasaHistoricoPagamentoPF);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A683SerasaHistoricoPagamentoPF[0]);
               }
               if ( Z684SerasaRecomendaCompleto != T002E2_A684SerasaRecomendaCompleto[0] )
               {
                  GXUtil.WriteLog("serasa:[seudo value changed for attri]"+"SerasaRecomendaCompleto");
                  GXUtil.WriteLogRaw("Old: ",Z684SerasaRecomendaCompleto);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A684SerasaRecomendaCompleto[0]);
               }
               if ( Z685SerasaScore != T002E2_A685SerasaScore[0] )
               {
                  GXUtil.WriteLog("serasa:[seudo value changed for attri]"+"SerasaScore");
                  GXUtil.WriteLogRaw("Old: ",Z685SerasaScore);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A685SerasaScore[0]);
               }
               if ( Z686SerasaTaxa != T002E2_A686SerasaTaxa[0] )
               {
                  GXUtil.WriteLog("serasa:[seudo value changed for attri]"+"SerasaTaxa");
                  GXUtil.WriteLogRaw("Old: ",Z686SerasaTaxa);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A686SerasaTaxa[0]);
               }
               if ( StringUtil.StrCmp(Z687SerasaMensagemScore, T002E2_A687SerasaMensagemScore[0]) != 0 )
               {
                  GXUtil.WriteLog("serasa:[seudo value changed for attri]"+"SerasaMensagemScore");
                  GXUtil.WriteLogRaw("Old: ",Z687SerasaMensagemScore);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A687SerasaMensagemScore[0]);
               }
               if ( StringUtil.StrCmp(Z688SerasaSituacaoCPF, T002E2_A688SerasaSituacaoCPF[0]) != 0 )
               {
                  GXUtil.WriteLog("serasa:[seudo value changed for attri]"+"SerasaSituacaoCPF");
                  GXUtil.WriteLogRaw("Old: ",Z688SerasaSituacaoCPF);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A688SerasaSituacaoCPF[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z689SerasaDataNascimento ) != DateTimeUtil.ResetTime ( T002E2_A689SerasaDataNascimento[0] ) )
               {
                  GXUtil.WriteLog("serasa:[seudo value changed for attri]"+"SerasaDataNascimento");
                  GXUtil.WriteLogRaw("Old: ",Z689SerasaDataNascimento);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A689SerasaDataNascimento[0]);
               }
               if ( StringUtil.StrCmp(Z690SerasaGenero, T002E2_A690SerasaGenero[0]) != 0 )
               {
                  GXUtil.WriteLog("serasa:[seudo value changed for attri]"+"SerasaGenero");
                  GXUtil.WriteLogRaw("Old: ",Z690SerasaGenero);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A690SerasaGenero[0]);
               }
               if ( StringUtil.StrCmp(Z691SerasaNomeMae, T002E2_A691SerasaNomeMae[0]) != 0 )
               {
                  GXUtil.WriteLog("serasa:[seudo value changed for attri]"+"SerasaNomeMae");
                  GXUtil.WriteLogRaw("Old: ",Z691SerasaNomeMae);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A691SerasaNomeMae[0]);
               }
               if ( StringUtil.StrCmp(Z692SerasaGrafia, T002E2_A692SerasaGrafia[0]) != 0 )
               {
                  GXUtil.WriteLog("serasa:[seudo value changed for attri]"+"SerasaGrafia");
                  GXUtil.WriteLogRaw("Old: ",Z692SerasaGrafia);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A692SerasaGrafia[0]);
               }
               if ( Z168ClienteId != T002E2_A168ClienteId[0] )
               {
                  GXUtil.WriteLog("serasa:[seudo value changed for attri]"+"ClienteId");
                  GXUtil.WriteLogRaw("Old: ",Z168ClienteId);
                  GXUtil.WriteLogRaw("Current: ",T002E2_A168ClienteId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Serasa"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2E84( )
      {
         BeforeValidate2E84( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2E84( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2E84( 0) ;
            CheckOptimisticConcurrency2E84( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2E84( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2E84( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002E35 */
                     pr_default.execute(18, new Object[] {n665SerasaCreatedAt, A665SerasaCreatedAt, n663SerasaNumeroProposta, A663SerasaNumeroProposta, n664SerasaPolitica, A664SerasaPolitica, n666SerasaTipoVenda, A666SerasaTipoVenda, n667SerasaCodTipoVenda, A667SerasaCodTipoVenda, n668SerasaCodNivelRisco, A668SerasaCodNivelRisco, n669SerasaTipoRecomendacao, A669SerasaTipoRecomendacao, n670SerasaRecomendacaoVenda, A670SerasaRecomendacaoVenda, n671SerasaCpfRegular, A671SerasaCpfRegular, n672SerasaRetricaoAtiva, A672SerasaRetricaoAtiva, n673SerasaProtestoAtivo, A673SerasaProtestoAtivo, n674SerasaBaixoComprometimento, A674SerasaBaixoComprometimento, n675SerasaValorLimiteRecomendado, A675SerasaValorLimiteRecomendado, n676SerasaFaixaDeRendaEstimada, A676SerasaFaixaDeRendaEstimada, n677SerasaMensagemRendaEstimada, A677SerasaMensagemRendaEstimada, n678SerasaAnotacoesCompletas, A678SerasaAnotacoesCompletas, n679SerasaConsultasDetalhadas, A679SerasaConsultasDetalhadas, n680SerasaAnotacoesConsultaSPC, A680SerasaAnotacoesConsultaSPC, n681SerasaParticipacaoSocietaria, A681SerasaParticipacaoSocietaria, n682SerasaRendaEstimada, A682SerasaRendaEstimada, n683SerasaHistoricoPagamentoPF, A683SerasaHistoricoPagamentoPF, n684SerasaRecomendaCompleto, A684SerasaRecomendaCompleto, n685SerasaScore, A685SerasaScore, n686SerasaTaxa, A686SerasaTaxa, n687SerasaMensagemScore, A687SerasaMensagemScore, n688SerasaSituacaoCPF, A688SerasaSituacaoCPF, n689SerasaDataNascimento, A689SerasaDataNascimento, n690SerasaGenero, A690SerasaGenero, n691SerasaNomeMae, A691SerasaNomeMae, n692SerasaGrafia, A692SerasaGrafia, n774SerasaJSON, A774SerasaJSON, n168ClienteId, A168ClienteId});
                     pr_default.close(18);
                     /* Retrieving last key number assigned */
                     /* Using cursor T002E36 */
                     pr_default.execute(19);
                     A662SerasaId = T002E36_A662SerasaId[0];
                     n662SerasaId = T002E36_n662SerasaId[0];
                     AssignAttri("", false, "A662SerasaId", StringUtil.LTrimStr( (decimal)(A662SerasaId), 9, 0));
                     pr_default.close(19);
                     pr_default.SmartCacheProvider.SetUpdated("Serasa");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption2E0( ) ;
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
               Load2E84( ) ;
            }
            EndLevel2E84( ) ;
         }
         CloseExtendedTableCursors2E84( ) ;
      }

      protected void Update2E84( )
      {
         BeforeValidate2E84( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2E84( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2E84( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2E84( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2E84( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002E37 */
                     pr_default.execute(20, new Object[] {n665SerasaCreatedAt, A665SerasaCreatedAt, n663SerasaNumeroProposta, A663SerasaNumeroProposta, n664SerasaPolitica, A664SerasaPolitica, n666SerasaTipoVenda, A666SerasaTipoVenda, n667SerasaCodTipoVenda, A667SerasaCodTipoVenda, n668SerasaCodNivelRisco, A668SerasaCodNivelRisco, n669SerasaTipoRecomendacao, A669SerasaTipoRecomendacao, n670SerasaRecomendacaoVenda, A670SerasaRecomendacaoVenda, n671SerasaCpfRegular, A671SerasaCpfRegular, n672SerasaRetricaoAtiva, A672SerasaRetricaoAtiva, n673SerasaProtestoAtivo, A673SerasaProtestoAtivo, n674SerasaBaixoComprometimento, A674SerasaBaixoComprometimento, n675SerasaValorLimiteRecomendado, A675SerasaValorLimiteRecomendado, n676SerasaFaixaDeRendaEstimada, A676SerasaFaixaDeRendaEstimada, n677SerasaMensagemRendaEstimada, A677SerasaMensagemRendaEstimada, n678SerasaAnotacoesCompletas, A678SerasaAnotacoesCompletas, n679SerasaConsultasDetalhadas, A679SerasaConsultasDetalhadas, n680SerasaAnotacoesConsultaSPC, A680SerasaAnotacoesConsultaSPC, n681SerasaParticipacaoSocietaria, A681SerasaParticipacaoSocietaria, n682SerasaRendaEstimada, A682SerasaRendaEstimada, n683SerasaHistoricoPagamentoPF, A683SerasaHistoricoPagamentoPF, n684SerasaRecomendaCompleto, A684SerasaRecomendaCompleto, n685SerasaScore, A685SerasaScore, n686SerasaTaxa, A686SerasaTaxa, n687SerasaMensagemScore, A687SerasaMensagemScore, n688SerasaSituacaoCPF, A688SerasaSituacaoCPF, n689SerasaDataNascimento, A689SerasaDataNascimento, n690SerasaGenero, A690SerasaGenero, n691SerasaNomeMae, A691SerasaNomeMae, n692SerasaGrafia, A692SerasaGrafia, n774SerasaJSON, A774SerasaJSON, n168ClienteId, A168ClienteId, n662SerasaId, A662SerasaId});
                     pr_default.close(20);
                     pr_default.SmartCacheProvider.SetUpdated("Serasa");
                     if ( (pr_default.getStatus(20) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Serasa"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2E84( ) ;
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
            EndLevel2E84( ) ;
         }
         CloseExtendedTableCursors2E84( ) ;
      }

      protected void DeferredUpdate2E84( )
      {
      }

      protected void delete( )
      {
         BeforeValidate2E84( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2E84( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2E84( ) ;
            AfterConfirm2E84( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2E84( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002E38 */
                  pr_default.execute(21, new Object[] {n662SerasaId, A662SerasaId});
                  pr_default.close(21);
                  pr_default.SmartCacheProvider.SetUpdated("Serasa");
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
         sMode84 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2E84( ) ;
         Gx_mode = sMode84;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2E84( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002E40 */
            pr_default.execute(22, new Object[] {n662SerasaId, A662SerasaId});
            if ( (pr_default.getStatus(22) != 101) )
            {
               A775SerasaCountAcoes_F = T002E40_A775SerasaCountAcoes_F[0];
               n775SerasaCountAcoes_F = T002E40_n775SerasaCountAcoes_F[0];
            }
            else
            {
               A775SerasaCountAcoes_F = 0;
               n775SerasaCountAcoes_F = false;
               AssignAttri("", false, "A775SerasaCountAcoes_F", StringUtil.LTrimStr( (decimal)(A775SerasaCountAcoes_F), 4, 0));
            }
            pr_default.close(22);
            /* Using cursor T002E42 */
            pr_default.execute(23, new Object[] {n662SerasaId, A662SerasaId});
            if ( (pr_default.getStatus(23) != 101) )
            {
               A776SerasaCountEnderecos_F = T002E42_A776SerasaCountEnderecos_F[0];
               n776SerasaCountEnderecos_F = T002E42_n776SerasaCountEnderecos_F[0];
            }
            else
            {
               A776SerasaCountEnderecos_F = 0;
               n776SerasaCountEnderecos_F = false;
               AssignAttri("", false, "A776SerasaCountEnderecos_F", StringUtil.LTrimStr( (decimal)(A776SerasaCountEnderecos_F), 4, 0));
            }
            pr_default.close(23);
            /* Using cursor T002E44 */
            pr_default.execute(24, new Object[] {n662SerasaId, A662SerasaId});
            if ( (pr_default.getStatus(24) != 101) )
            {
               A777SerasaCountProtestos_F = T002E44_A777SerasaCountProtestos_F[0];
               n777SerasaCountProtestos_F = T002E44_n777SerasaCountProtestos_F[0];
            }
            else
            {
               A777SerasaCountProtestos_F = 0;
               n777SerasaCountProtestos_F = false;
               AssignAttri("", false, "A777SerasaCountProtestos_F", StringUtil.LTrimStr( (decimal)(A777SerasaCountProtestos_F), 4, 0));
            }
            pr_default.close(24);
            /* Using cursor T002E46 */
            pr_default.execute(25, new Object[] {n662SerasaId, A662SerasaId});
            if ( (pr_default.getStatus(25) != 101) )
            {
               A778SerasaCountOcorrencias_F = T002E46_A778SerasaCountOcorrencias_F[0];
               n778SerasaCountOcorrencias_F = T002E46_n778SerasaCountOcorrencias_F[0];
            }
            else
            {
               A778SerasaCountOcorrencias_F = 0;
               n778SerasaCountOcorrencias_F = false;
               AssignAttri("", false, "A778SerasaCountOcorrencias_F", StringUtil.LTrimStr( (decimal)(A778SerasaCountOcorrencias_F), 4, 0));
            }
            pr_default.close(25);
            /* Using cursor T002E48 */
            pr_default.execute(26, new Object[] {n662SerasaId, A662SerasaId});
            if ( (pr_default.getStatus(26) != 101) )
            {
               A779SerasaCountCheques_F = T002E48_A779SerasaCountCheques_F[0];
               n779SerasaCountCheques_F = T002E48_n779SerasaCountCheques_F[0];
            }
            else
            {
               A779SerasaCountCheques_F = 0;
               n779SerasaCountCheques_F = false;
               AssignAttri("", false, "A779SerasaCountCheques_F", StringUtil.LTrimStr( (decimal)(A779SerasaCountCheques_F), 4, 0));
            }
            pr_default.close(26);
            /* Using cursor T002E49 */
            pr_default.execute(27, new Object[] {n168ClienteId, A168ClienteId});
            A170ClienteRazaoSocial = T002E49_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = T002E49_n170ClienteRazaoSocial[0];
            pr_default.close(27);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T002E50 */
            pr_default.execute(28, new Object[] {n662SerasaId, A662SerasaId});
            if ( (pr_default.getStatus(28) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SerasaOcorrencias"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(28);
            /* Using cursor T002E51 */
            pr_default.execute(29, new Object[] {n662SerasaId, A662SerasaId});
            if ( (pr_default.getStatus(29) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SerasaEnderecos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(29);
            /* Using cursor T002E52 */
            pr_default.execute(30, new Object[] {n662SerasaId, A662SerasaId});
            if ( (pr_default.getStatus(30) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SerasaProtestos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(30);
            /* Using cursor T002E53 */
            pr_default.execute(31, new Object[] {n662SerasaId, A662SerasaId});
            if ( (pr_default.getStatus(31) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SerasaAcoes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(31);
            /* Using cursor T002E54 */
            pr_default.execute(32, new Object[] {n662SerasaId, A662SerasaId});
            if ( (pr_default.getStatus(32) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SerasaCheques"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(32);
         }
      }

      protected void EndLevel2E84( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2E84( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues2E0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2E84( )
      {
         /* Scan By routine */
         /* Using cursor T002E55 */
         pr_default.execute(33);
         RcdFound84 = 0;
         if ( (pr_default.getStatus(33) != 101) )
         {
            RcdFound84 = 1;
            A662SerasaId = T002E55_A662SerasaId[0];
            n662SerasaId = T002E55_n662SerasaId[0];
            AssignAttri("", false, "A662SerasaId", StringUtil.LTrimStr( (decimal)(A662SerasaId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2E84( )
      {
         /* Scan next routine */
         pr_default.readNext(33);
         RcdFound84 = 0;
         if ( (pr_default.getStatus(33) != 101) )
         {
            RcdFound84 = 1;
            A662SerasaId = T002E55_A662SerasaId[0];
            n662SerasaId = T002E55_n662SerasaId[0];
            AssignAttri("", false, "A662SerasaId", StringUtil.LTrimStr( (decimal)(A662SerasaId), 9, 0));
         }
      }

      protected void ScanEnd2E84( )
      {
         pr_default.close(33);
      }

      protected void AfterConfirm2E84( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2E84( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2E84( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2E84( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2E84( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2E84( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2E84( )
      {
         edtSerasaId_Enabled = 0;
         AssignProp("", false, edtSerasaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaId_Enabled), 5, 0), true);
         edtClienteId_Enabled = 0;
         AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
         edtSerasaNumeroProposta_Enabled = 0;
         AssignProp("", false, edtSerasaNumeroProposta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaNumeroProposta_Enabled), 5, 0), true);
         edtSerasaPolitica_Enabled = 0;
         AssignProp("", false, edtSerasaPolitica_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaPolitica_Enabled), 5, 0), true);
         edtSerasaCreatedAt_Enabled = 0;
         AssignProp("", false, edtSerasaCreatedAt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaCreatedAt_Enabled), 5, 0), true);
         edtSerasaTipoVenda_Enabled = 0;
         AssignProp("", false, edtSerasaTipoVenda_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaTipoVenda_Enabled), 5, 0), true);
         edtSerasaCodTipoVenda_Enabled = 0;
         AssignProp("", false, edtSerasaCodTipoVenda_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaCodTipoVenda_Enabled), 5, 0), true);
         edtSerasaCodNivelRisco_Enabled = 0;
         AssignProp("", false, edtSerasaCodNivelRisco_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaCodNivelRisco_Enabled), 5, 0), true);
         edtSerasaTipoRecomendacao_Enabled = 0;
         AssignProp("", false, edtSerasaTipoRecomendacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaTipoRecomendacao_Enabled), 5, 0), true);
         edtSerasaRecomendacaoVenda_Enabled = 0;
         AssignProp("", false, edtSerasaRecomendacaoVenda_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaRecomendacaoVenda_Enabled), 5, 0), true);
         cmbSerasaCpfRegular.Enabled = 0;
         AssignProp("", false, cmbSerasaCpfRegular_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSerasaCpfRegular.Enabled), 5, 0), true);
         cmbSerasaRetricaoAtiva.Enabled = 0;
         AssignProp("", false, cmbSerasaRetricaoAtiva_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSerasaRetricaoAtiva.Enabled), 5, 0), true);
         cmbSerasaProtestoAtivo.Enabled = 0;
         AssignProp("", false, cmbSerasaProtestoAtivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSerasaProtestoAtivo.Enabled), 5, 0), true);
         cmbSerasaBaixoComprometimento.Enabled = 0;
         AssignProp("", false, cmbSerasaBaixoComprometimento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSerasaBaixoComprometimento.Enabled), 5, 0), true);
         edtSerasaValorLimiteRecomendado_Enabled = 0;
         AssignProp("", false, edtSerasaValorLimiteRecomendado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaValorLimiteRecomendado_Enabled), 5, 0), true);
         edtSerasaFaixaDeRendaEstimada_Enabled = 0;
         AssignProp("", false, edtSerasaFaixaDeRendaEstimada_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaFaixaDeRendaEstimada_Enabled), 5, 0), true);
         edtSerasaMensagemRendaEstimada_Enabled = 0;
         AssignProp("", false, edtSerasaMensagemRendaEstimada_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaMensagemRendaEstimada_Enabled), 5, 0), true);
         cmbSerasaAnotacoesCompletas.Enabled = 0;
         AssignProp("", false, cmbSerasaAnotacoesCompletas_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSerasaAnotacoesCompletas.Enabled), 5, 0), true);
         cmbSerasaConsultasDetalhadas.Enabled = 0;
         AssignProp("", false, cmbSerasaConsultasDetalhadas_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSerasaConsultasDetalhadas.Enabled), 5, 0), true);
         cmbSerasaAnotacoesConsultaSPC.Enabled = 0;
         AssignProp("", false, cmbSerasaAnotacoesConsultaSPC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSerasaAnotacoesConsultaSPC.Enabled), 5, 0), true);
         cmbSerasaParticipacaoSocietaria.Enabled = 0;
         AssignProp("", false, cmbSerasaParticipacaoSocietaria_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSerasaParticipacaoSocietaria.Enabled), 5, 0), true);
         cmbSerasaRendaEstimada.Enabled = 0;
         AssignProp("", false, cmbSerasaRendaEstimada_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSerasaRendaEstimada.Enabled), 5, 0), true);
         cmbSerasaHistoricoPagamentoPF.Enabled = 0;
         AssignProp("", false, cmbSerasaHistoricoPagamentoPF_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSerasaHistoricoPagamentoPF.Enabled), 5, 0), true);
         cmbSerasaRecomendaCompleto.Enabled = 0;
         AssignProp("", false, cmbSerasaRecomendaCompleto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbSerasaRecomendaCompleto.Enabled), 5, 0), true);
         edtSerasaScore_Enabled = 0;
         AssignProp("", false, edtSerasaScore_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaScore_Enabled), 5, 0), true);
         edtSerasaTaxa_Enabled = 0;
         AssignProp("", false, edtSerasaTaxa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaTaxa_Enabled), 5, 0), true);
         edtSerasaMensagemScore_Enabled = 0;
         AssignProp("", false, edtSerasaMensagemScore_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaMensagemScore_Enabled), 5, 0), true);
         edtSerasaSituacaoCPF_Enabled = 0;
         AssignProp("", false, edtSerasaSituacaoCPF_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaSituacaoCPF_Enabled), 5, 0), true);
         edtSerasaDataNascimento_Enabled = 0;
         AssignProp("", false, edtSerasaDataNascimento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaDataNascimento_Enabled), 5, 0), true);
         edtSerasaGenero_Enabled = 0;
         AssignProp("", false, edtSerasaGenero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaGenero_Enabled), 5, 0), true);
         edtSerasaNomeMae_Enabled = 0;
         AssignProp("", false, edtSerasaNomeMae_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaNomeMae_Enabled), 5, 0), true);
         edtSerasaGrafia_Enabled = 0;
         AssignProp("", false, edtSerasaGrafia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSerasaGrafia_Enabled), 5, 0), true);
         edtavComboclienteid_Enabled = 0;
         AssignProp("", false, edtavComboclienteid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboclienteid_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2E84( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2E0( )
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
         GXEncryptionTmp = "serasa"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7SerasaId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("serasa") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Serasa");
         forbiddenHiddens.Add("SerasaId", context.localUtil.Format( (decimal)(A662SerasaId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_ClienteId", context.localUtil.Format( (decimal)(AV11Insert_ClienteId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("serasa:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z662SerasaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z662SerasaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z665SerasaCreatedAt", context.localUtil.TToC( Z665SerasaCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z663SerasaNumeroProposta", Z663SerasaNumeroProposta);
         GxWebStd.gx_hidden_field( context, "Z664SerasaPolitica", StringUtil.LTrim( StringUtil.NToC( Z664SerasaPolitica, 15, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z666SerasaTipoVenda", Z666SerasaTipoVenda);
         GxWebStd.gx_hidden_field( context, "Z667SerasaCodTipoVenda", StringUtil.LTrim( StringUtil.NToC( Z667SerasaCodTipoVenda, 15, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z668SerasaCodNivelRisco", StringUtil.LTrim( StringUtil.NToC( Z668SerasaCodNivelRisco, 15, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z669SerasaTipoRecomendacao", Z669SerasaTipoRecomendacao);
         GxWebStd.gx_hidden_field( context, "Z670SerasaRecomendacaoVenda", Z670SerasaRecomendacaoVenda);
         GxWebStd.gx_boolean_hidden_field( context, "Z671SerasaCpfRegular", Z671SerasaCpfRegular);
         GxWebStd.gx_boolean_hidden_field( context, "Z672SerasaRetricaoAtiva", Z672SerasaRetricaoAtiva);
         GxWebStd.gx_boolean_hidden_field( context, "Z673SerasaProtestoAtivo", Z673SerasaProtestoAtivo);
         GxWebStd.gx_boolean_hidden_field( context, "Z674SerasaBaixoComprometimento", Z674SerasaBaixoComprometimento);
         GxWebStd.gx_hidden_field( context, "Z675SerasaValorLimiteRecomendado", StringUtil.LTrim( StringUtil.NToC( Z675SerasaValorLimiteRecomendado, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z676SerasaFaixaDeRendaEstimada", StringUtil.LTrim( StringUtil.NToC( Z676SerasaFaixaDeRendaEstimada, 15, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z677SerasaMensagemRendaEstimada", Z677SerasaMensagemRendaEstimada);
         GxWebStd.gx_boolean_hidden_field( context, "Z678SerasaAnotacoesCompletas", Z678SerasaAnotacoesCompletas);
         GxWebStd.gx_boolean_hidden_field( context, "Z679SerasaConsultasDetalhadas", Z679SerasaConsultasDetalhadas);
         GxWebStd.gx_boolean_hidden_field( context, "Z680SerasaAnotacoesConsultaSPC", Z680SerasaAnotacoesConsultaSPC);
         GxWebStd.gx_boolean_hidden_field( context, "Z681SerasaParticipacaoSocietaria", Z681SerasaParticipacaoSocietaria);
         GxWebStd.gx_boolean_hidden_field( context, "Z682SerasaRendaEstimada", Z682SerasaRendaEstimada);
         GxWebStd.gx_boolean_hidden_field( context, "Z683SerasaHistoricoPagamentoPF", Z683SerasaHistoricoPagamentoPF);
         GxWebStd.gx_boolean_hidden_field( context, "Z684SerasaRecomendaCompleto", Z684SerasaRecomendaCompleto);
         GxWebStd.gx_hidden_field( context, "Z685SerasaScore", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z685SerasaScore), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z686SerasaTaxa", StringUtil.LTrim( StringUtil.NToC( Z686SerasaTaxa, 15, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z687SerasaMensagemScore", Z687SerasaMensagemScore);
         GxWebStd.gx_hidden_field( context, "Z688SerasaSituacaoCPF", Z688SerasaSituacaoCPF);
         GxWebStd.gx_hidden_field( context, "Z689SerasaDataNascimento", context.localUtil.DToC( Z689SerasaDataNascimento, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z690SerasaGenero", Z690SerasaGenero);
         GxWebStd.gx_hidden_field( context, "Z691SerasaNomeMae", Z691SerasaNomeMae);
         GxWebStd.gx_hidden_field( context, "Z692SerasaGrafia", Z692SerasaGrafia);
         GxWebStd.gx_hidden_field( context, "Z168ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z168ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N168ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV14DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV14DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLIENTEID_DATA", AV13ClienteId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLIENTEID_DATA", AV13ClienteId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vSERASAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7SerasaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vSERASAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7SerasaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_CLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "SERASAJSON", A774SerasaJSON);
         GxWebStd.gx_hidden_field( context, "CLIENTERAZAOSOCIAL", A170ClienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, "SERASACOUNTACOES_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A775SerasaCountAcoes_F), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "SERASACOUNTENDERECOS_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A776SerasaCountEnderecos_F), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "SERASACOUNTPROTESTOS_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A777SerasaCountProtestos_F), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "SERASACOUNTOCORRENCIAS_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A778SerasaCountOcorrencias_F), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "SERASACOUNTCHEQUES_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A779SerasaCountCheques_F), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV19Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIENTEID_Objectcall", StringUtil.RTrim( Combo_clienteid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIENTEID_Cls", StringUtil.RTrim( Combo_clienteid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIENTEID_Selectedvalue_set", StringUtil.RTrim( Combo_clienteid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIENTEID_Selectedtext_set", StringUtil.RTrim( Combo_clienteid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIENTEID_Enabled", StringUtil.BoolToStr( Combo_clienteid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIENTEID_Datalistproc", StringUtil.RTrim( Combo_clienteid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_CLIENTEID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_clienteid_Datalistprocparametersprefix));
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
         GXEncryptionTmp = "serasa"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7SerasaId,9,0));
         return formatLink("serasa") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Serasa" ;
      }

      public override string GetPgmdesc( )
      {
         return "Serasa" ;
      }

      protected void InitializeNonKey2E84( )
      {
         A168ClienteId = 0;
         n168ClienteId = false;
         AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
         n168ClienteId = ((0==A168ClienteId) ? true : false);
         A665SerasaCreatedAt = (DateTime)(DateTime.MinValue);
         n665SerasaCreatedAt = false;
         AssignAttri("", false, "A665SerasaCreatedAt", context.localUtil.TToC( A665SerasaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         n665SerasaCreatedAt = ((DateTime.MinValue==A665SerasaCreatedAt) ? true : false);
         A170ClienteRazaoSocial = "";
         n170ClienteRazaoSocial = false;
         AssignAttri("", false, "A170ClienteRazaoSocial", A170ClienteRazaoSocial);
         A663SerasaNumeroProposta = "";
         n663SerasaNumeroProposta = false;
         AssignAttri("", false, "A663SerasaNumeroProposta", A663SerasaNumeroProposta);
         n663SerasaNumeroProposta = (String.IsNullOrEmpty(StringUtil.RTrim( A663SerasaNumeroProposta)) ? true : false);
         A664SerasaPolitica = 0;
         n664SerasaPolitica = false;
         AssignAttri("", false, "A664SerasaPolitica", ((Convert.ToDecimal(0)==A664SerasaPolitica)&&IsIns( )||n664SerasaPolitica ? "" : StringUtil.LTrim( StringUtil.NToC( A664SerasaPolitica, 15, 2, ".", ""))));
         n664SerasaPolitica = ((Convert.ToDecimal(0)==A664SerasaPolitica) ? true : false);
         A666SerasaTipoVenda = "";
         n666SerasaTipoVenda = false;
         AssignAttri("", false, "A666SerasaTipoVenda", A666SerasaTipoVenda);
         n666SerasaTipoVenda = (String.IsNullOrEmpty(StringUtil.RTrim( A666SerasaTipoVenda)) ? true : false);
         A667SerasaCodTipoVenda = 0;
         n667SerasaCodTipoVenda = false;
         AssignAttri("", false, "A667SerasaCodTipoVenda", ((Convert.ToDecimal(0)==A667SerasaCodTipoVenda)&&IsIns( )||n667SerasaCodTipoVenda ? "" : StringUtil.LTrim( StringUtil.NToC( A667SerasaCodTipoVenda, 15, 2, ".", ""))));
         n667SerasaCodTipoVenda = ((Convert.ToDecimal(0)==A667SerasaCodTipoVenda) ? true : false);
         A668SerasaCodNivelRisco = 0;
         n668SerasaCodNivelRisco = false;
         AssignAttri("", false, "A668SerasaCodNivelRisco", ((Convert.ToDecimal(0)==A668SerasaCodNivelRisco)&&IsIns( )||n668SerasaCodNivelRisco ? "" : StringUtil.LTrim( StringUtil.NToC( A668SerasaCodNivelRisco, 15, 2, ".", ""))));
         n668SerasaCodNivelRisco = ((Convert.ToDecimal(0)==A668SerasaCodNivelRisco) ? true : false);
         A669SerasaTipoRecomendacao = "";
         n669SerasaTipoRecomendacao = false;
         AssignAttri("", false, "A669SerasaTipoRecomendacao", A669SerasaTipoRecomendacao);
         n669SerasaTipoRecomendacao = (String.IsNullOrEmpty(StringUtil.RTrim( A669SerasaTipoRecomendacao)) ? true : false);
         A670SerasaRecomendacaoVenda = "";
         n670SerasaRecomendacaoVenda = false;
         AssignAttri("", false, "A670SerasaRecomendacaoVenda", A670SerasaRecomendacaoVenda);
         n670SerasaRecomendacaoVenda = (String.IsNullOrEmpty(StringUtil.RTrim( A670SerasaRecomendacaoVenda)) ? true : false);
         A671SerasaCpfRegular = false;
         n671SerasaCpfRegular = false;
         AssignAttri("", false, "A671SerasaCpfRegular", A671SerasaCpfRegular);
         n671SerasaCpfRegular = ((false==A671SerasaCpfRegular) ? true : false);
         A672SerasaRetricaoAtiva = false;
         n672SerasaRetricaoAtiva = false;
         AssignAttri("", false, "A672SerasaRetricaoAtiva", A672SerasaRetricaoAtiva);
         n672SerasaRetricaoAtiva = ((false==A672SerasaRetricaoAtiva) ? true : false);
         A673SerasaProtestoAtivo = false;
         n673SerasaProtestoAtivo = false;
         AssignAttri("", false, "A673SerasaProtestoAtivo", A673SerasaProtestoAtivo);
         n673SerasaProtestoAtivo = ((false==A673SerasaProtestoAtivo) ? true : false);
         A674SerasaBaixoComprometimento = false;
         n674SerasaBaixoComprometimento = false;
         AssignAttri("", false, "A674SerasaBaixoComprometimento", A674SerasaBaixoComprometimento);
         n674SerasaBaixoComprometimento = ((false==A674SerasaBaixoComprometimento) ? true : false);
         A675SerasaValorLimiteRecomendado = 0;
         n675SerasaValorLimiteRecomendado = false;
         AssignAttri("", false, "A675SerasaValorLimiteRecomendado", ((Convert.ToDecimal(0)==A675SerasaValorLimiteRecomendado)&&IsIns( )||n675SerasaValorLimiteRecomendado ? "" : StringUtil.LTrim( StringUtil.NToC( A675SerasaValorLimiteRecomendado, 18, 2, ".", ""))));
         n675SerasaValorLimiteRecomendado = ((Convert.ToDecimal(0)==A675SerasaValorLimiteRecomendado) ? true : false);
         A676SerasaFaixaDeRendaEstimada = 0;
         n676SerasaFaixaDeRendaEstimada = false;
         AssignAttri("", false, "A676SerasaFaixaDeRendaEstimada", ((Convert.ToDecimal(0)==A676SerasaFaixaDeRendaEstimada)&&IsIns( )||n676SerasaFaixaDeRendaEstimada ? "" : StringUtil.LTrim( StringUtil.NToC( A676SerasaFaixaDeRendaEstimada, 15, 2, ".", ""))));
         n676SerasaFaixaDeRendaEstimada = ((Convert.ToDecimal(0)==A676SerasaFaixaDeRendaEstimada) ? true : false);
         A677SerasaMensagemRendaEstimada = "";
         n677SerasaMensagemRendaEstimada = false;
         AssignAttri("", false, "A677SerasaMensagemRendaEstimada", A677SerasaMensagemRendaEstimada);
         n677SerasaMensagemRendaEstimada = (String.IsNullOrEmpty(StringUtil.RTrim( A677SerasaMensagemRendaEstimada)) ? true : false);
         A678SerasaAnotacoesCompletas = false;
         n678SerasaAnotacoesCompletas = false;
         AssignAttri("", false, "A678SerasaAnotacoesCompletas", A678SerasaAnotacoesCompletas);
         n678SerasaAnotacoesCompletas = ((false==A678SerasaAnotacoesCompletas) ? true : false);
         A679SerasaConsultasDetalhadas = false;
         n679SerasaConsultasDetalhadas = false;
         AssignAttri("", false, "A679SerasaConsultasDetalhadas", A679SerasaConsultasDetalhadas);
         n679SerasaConsultasDetalhadas = ((false==A679SerasaConsultasDetalhadas) ? true : false);
         A680SerasaAnotacoesConsultaSPC = false;
         n680SerasaAnotacoesConsultaSPC = false;
         AssignAttri("", false, "A680SerasaAnotacoesConsultaSPC", A680SerasaAnotacoesConsultaSPC);
         n680SerasaAnotacoesConsultaSPC = ((false==A680SerasaAnotacoesConsultaSPC) ? true : false);
         A681SerasaParticipacaoSocietaria = false;
         n681SerasaParticipacaoSocietaria = false;
         AssignAttri("", false, "A681SerasaParticipacaoSocietaria", A681SerasaParticipacaoSocietaria);
         n681SerasaParticipacaoSocietaria = ((false==A681SerasaParticipacaoSocietaria) ? true : false);
         A682SerasaRendaEstimada = false;
         n682SerasaRendaEstimada = false;
         AssignAttri("", false, "A682SerasaRendaEstimada", A682SerasaRendaEstimada);
         n682SerasaRendaEstimada = ((false==A682SerasaRendaEstimada) ? true : false);
         A683SerasaHistoricoPagamentoPF = false;
         n683SerasaHistoricoPagamentoPF = false;
         AssignAttri("", false, "A683SerasaHistoricoPagamentoPF", A683SerasaHistoricoPagamentoPF);
         n683SerasaHistoricoPagamentoPF = ((false==A683SerasaHistoricoPagamentoPF) ? true : false);
         A684SerasaRecomendaCompleto = false;
         n684SerasaRecomendaCompleto = false;
         AssignAttri("", false, "A684SerasaRecomendaCompleto", A684SerasaRecomendaCompleto);
         n684SerasaRecomendaCompleto = ((false==A684SerasaRecomendaCompleto) ? true : false);
         A685SerasaScore = 0;
         n685SerasaScore = false;
         AssignAttri("", false, "A685SerasaScore", ((0==A685SerasaScore)&&IsIns( )||n685SerasaScore ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A685SerasaScore), 4, 0, ".", ""))));
         n685SerasaScore = ((0==A685SerasaScore) ? true : false);
         A686SerasaTaxa = 0;
         n686SerasaTaxa = false;
         AssignAttri("", false, "A686SerasaTaxa", ((Convert.ToDecimal(0)==A686SerasaTaxa)&&IsIns( )||n686SerasaTaxa ? "" : StringUtil.LTrim( StringUtil.NToC( A686SerasaTaxa, 15, 2, ".", ""))));
         n686SerasaTaxa = ((Convert.ToDecimal(0)==A686SerasaTaxa) ? true : false);
         A687SerasaMensagemScore = "";
         n687SerasaMensagemScore = false;
         AssignAttri("", false, "A687SerasaMensagemScore", A687SerasaMensagemScore);
         n687SerasaMensagemScore = (String.IsNullOrEmpty(StringUtil.RTrim( A687SerasaMensagemScore)) ? true : false);
         A688SerasaSituacaoCPF = "";
         n688SerasaSituacaoCPF = false;
         AssignAttri("", false, "A688SerasaSituacaoCPF", A688SerasaSituacaoCPF);
         n688SerasaSituacaoCPF = (String.IsNullOrEmpty(StringUtil.RTrim( A688SerasaSituacaoCPF)) ? true : false);
         A689SerasaDataNascimento = DateTime.MinValue;
         n689SerasaDataNascimento = false;
         AssignAttri("", false, "A689SerasaDataNascimento", context.localUtil.Format(A689SerasaDataNascimento, "99/99/99"));
         n689SerasaDataNascimento = ((DateTime.MinValue==A689SerasaDataNascimento) ? true : false);
         A690SerasaGenero = "";
         n690SerasaGenero = false;
         AssignAttri("", false, "A690SerasaGenero", A690SerasaGenero);
         n690SerasaGenero = (String.IsNullOrEmpty(StringUtil.RTrim( A690SerasaGenero)) ? true : false);
         A691SerasaNomeMae = "";
         n691SerasaNomeMae = false;
         AssignAttri("", false, "A691SerasaNomeMae", A691SerasaNomeMae);
         n691SerasaNomeMae = (String.IsNullOrEmpty(StringUtil.RTrim( A691SerasaNomeMae)) ? true : false);
         A692SerasaGrafia = "";
         n692SerasaGrafia = false;
         AssignAttri("", false, "A692SerasaGrafia", A692SerasaGrafia);
         n692SerasaGrafia = (String.IsNullOrEmpty(StringUtil.RTrim( A692SerasaGrafia)) ? true : false);
         A774SerasaJSON = "";
         n774SerasaJSON = false;
         AssignAttri("", false, "A774SerasaJSON", A774SerasaJSON);
         A775SerasaCountAcoes_F = 0;
         n775SerasaCountAcoes_F = false;
         AssignAttri("", false, "A775SerasaCountAcoes_F", StringUtil.LTrimStr( (decimal)(A775SerasaCountAcoes_F), 4, 0));
         A776SerasaCountEnderecos_F = 0;
         n776SerasaCountEnderecos_F = false;
         AssignAttri("", false, "A776SerasaCountEnderecos_F", StringUtil.LTrimStr( (decimal)(A776SerasaCountEnderecos_F), 4, 0));
         A777SerasaCountProtestos_F = 0;
         n777SerasaCountProtestos_F = false;
         AssignAttri("", false, "A777SerasaCountProtestos_F", StringUtil.LTrimStr( (decimal)(A777SerasaCountProtestos_F), 4, 0));
         A778SerasaCountOcorrencias_F = 0;
         n778SerasaCountOcorrencias_F = false;
         AssignAttri("", false, "A778SerasaCountOcorrencias_F", StringUtil.LTrimStr( (decimal)(A778SerasaCountOcorrencias_F), 4, 0));
         A779SerasaCountCheques_F = 0;
         n779SerasaCountCheques_F = false;
         AssignAttri("", false, "A779SerasaCountCheques_F", StringUtil.LTrimStr( (decimal)(A779SerasaCountCheques_F), 4, 0));
         Z665SerasaCreatedAt = (DateTime)(DateTime.MinValue);
         Z663SerasaNumeroProposta = "";
         Z664SerasaPolitica = 0;
         Z666SerasaTipoVenda = "";
         Z667SerasaCodTipoVenda = 0;
         Z668SerasaCodNivelRisco = 0;
         Z669SerasaTipoRecomendacao = "";
         Z670SerasaRecomendacaoVenda = "";
         Z671SerasaCpfRegular = false;
         Z672SerasaRetricaoAtiva = false;
         Z673SerasaProtestoAtivo = false;
         Z674SerasaBaixoComprometimento = false;
         Z675SerasaValorLimiteRecomendado = 0;
         Z676SerasaFaixaDeRendaEstimada = 0;
         Z677SerasaMensagemRendaEstimada = "";
         Z678SerasaAnotacoesCompletas = false;
         Z679SerasaConsultasDetalhadas = false;
         Z680SerasaAnotacoesConsultaSPC = false;
         Z681SerasaParticipacaoSocietaria = false;
         Z682SerasaRendaEstimada = false;
         Z683SerasaHistoricoPagamentoPF = false;
         Z684SerasaRecomendaCompleto = false;
         Z685SerasaScore = 0;
         Z686SerasaTaxa = 0;
         Z687SerasaMensagemScore = "";
         Z688SerasaSituacaoCPF = "";
         Z689SerasaDataNascimento = DateTime.MinValue;
         Z690SerasaGenero = "";
         Z691SerasaNomeMae = "";
         Z692SerasaGrafia = "";
         Z168ClienteId = 0;
      }

      protected void InitAll2E84( )
      {
         A662SerasaId = 0;
         n662SerasaId = false;
         AssignAttri("", false, "A662SerasaId", StringUtil.LTrimStr( (decimal)(A662SerasaId), 9, 0));
         InitializeNonKey2E84( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A665SerasaCreatedAt = i665SerasaCreatedAt;
         n665SerasaCreatedAt = false;
         AssignAttri("", false, "A665SerasaCreatedAt", context.localUtil.TToC( A665SerasaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019201125", true, true);
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
         context.AddJavascriptSource("serasa.js", "?202561019201127", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtSerasaId_Internalname = "SERASAID";
         lblTextblockclienteid_Internalname = "TEXTBLOCKCLIENTEID";
         Combo_clienteid_Internalname = "COMBO_CLIENTEID";
         edtClienteId_Internalname = "CLIENTEID";
         divTablesplittedclienteid_Internalname = "TABLESPLITTEDCLIENTEID";
         edtSerasaNumeroProposta_Internalname = "SERASANUMEROPROPOSTA";
         edtSerasaPolitica_Internalname = "SERASAPOLITICA";
         edtSerasaCreatedAt_Internalname = "SERASACREATEDAT";
         edtSerasaTipoVenda_Internalname = "SERASATIPOVENDA";
         edtSerasaCodTipoVenda_Internalname = "SERASACODTIPOVENDA";
         edtSerasaCodNivelRisco_Internalname = "SERASACODNIVELRISCO";
         edtSerasaTipoRecomendacao_Internalname = "SERASATIPORECOMENDACAO";
         edtSerasaRecomendacaoVenda_Internalname = "SERASARECOMENDACAOVENDA";
         cmbSerasaCpfRegular_Internalname = "SERASACPFREGULAR";
         cmbSerasaRetricaoAtiva_Internalname = "SERASARETRICAOATIVA";
         cmbSerasaProtestoAtivo_Internalname = "SERASAPROTESTOATIVO";
         cmbSerasaBaixoComprometimento_Internalname = "SERASABAIXOCOMPROMETIMENTO";
         edtSerasaValorLimiteRecomendado_Internalname = "SERASAVALORLIMITERECOMENDADO";
         edtSerasaFaixaDeRendaEstimada_Internalname = "SERASAFAIXADERENDAESTIMADA";
         edtSerasaMensagemRendaEstimada_Internalname = "SERASAMENSAGEMRENDAESTIMADA";
         cmbSerasaAnotacoesCompletas_Internalname = "SERASAANOTACOESCOMPLETAS";
         cmbSerasaConsultasDetalhadas_Internalname = "SERASACONSULTASDETALHADAS";
         cmbSerasaAnotacoesConsultaSPC_Internalname = "SERASAANOTACOESCONSULTASPC";
         cmbSerasaParticipacaoSocietaria_Internalname = "SERASAPARTICIPACAOSOCIETARIA";
         cmbSerasaRendaEstimada_Internalname = "SERASARENDAESTIMADA";
         cmbSerasaHistoricoPagamentoPF_Internalname = "SERASAHISTORICOPAGAMENTOPF";
         cmbSerasaRecomendaCompleto_Internalname = "SERASARECOMENDACOMPLETO";
         edtSerasaScore_Internalname = "SERASASCORE";
         edtSerasaTaxa_Internalname = "SERASATAXA";
         edtSerasaMensagemScore_Internalname = "SERASAMENSAGEMSCORE";
         edtSerasaSituacaoCPF_Internalname = "SERASASITUACAOCPF";
         edtSerasaDataNascimento_Internalname = "SERASADATANASCIMENTO";
         edtSerasaGenero_Internalname = "SERASAGENERO";
         edtSerasaNomeMae_Internalname = "SERASANOMEMAE";
         edtSerasaGrafia_Internalname = "SERASAGRAFIA";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavComboclienteid_Internalname = "vCOMBOCLIENTEID";
         divSectionattribute_clienteid_Internalname = "SECTIONATTRIBUTE_CLIENTEID";
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
         Form.Caption = "Serasa";
         edtavComboclienteid_Jsonclick = "";
         edtavComboclienteid_Enabled = 0;
         edtavComboclienteid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtSerasaGrafia_Jsonclick = "";
         edtSerasaGrafia_Enabled = 1;
         edtSerasaNomeMae_Jsonclick = "";
         edtSerasaNomeMae_Enabled = 1;
         edtSerasaGenero_Jsonclick = "";
         edtSerasaGenero_Enabled = 1;
         edtSerasaDataNascimento_Jsonclick = "";
         edtSerasaDataNascimento_Enabled = 1;
         edtSerasaSituacaoCPF_Jsonclick = "";
         edtSerasaSituacaoCPF_Enabled = 1;
         edtSerasaMensagemScore_Enabled = 1;
         edtSerasaTaxa_Jsonclick = "";
         edtSerasaTaxa_Enabled = 1;
         edtSerasaScore_Jsonclick = "";
         edtSerasaScore_Enabled = 1;
         cmbSerasaRecomendaCompleto_Jsonclick = "";
         cmbSerasaRecomendaCompleto.Enabled = 1;
         cmbSerasaHistoricoPagamentoPF_Jsonclick = "";
         cmbSerasaHistoricoPagamentoPF.Enabled = 1;
         cmbSerasaRendaEstimada_Jsonclick = "";
         cmbSerasaRendaEstimada.Enabled = 1;
         cmbSerasaParticipacaoSocietaria_Jsonclick = "";
         cmbSerasaParticipacaoSocietaria.Enabled = 1;
         cmbSerasaAnotacoesConsultaSPC_Jsonclick = "";
         cmbSerasaAnotacoesConsultaSPC.Enabled = 1;
         cmbSerasaConsultasDetalhadas_Jsonclick = "";
         cmbSerasaConsultasDetalhadas.Enabled = 1;
         cmbSerasaAnotacoesCompletas_Jsonclick = "";
         cmbSerasaAnotacoesCompletas.Enabled = 1;
         edtSerasaMensagemRendaEstimada_Enabled = 1;
         edtSerasaFaixaDeRendaEstimada_Jsonclick = "";
         edtSerasaFaixaDeRendaEstimada_Enabled = 1;
         edtSerasaValorLimiteRecomendado_Jsonclick = "";
         edtSerasaValorLimiteRecomendado_Enabled = 1;
         cmbSerasaBaixoComprometimento_Jsonclick = "";
         cmbSerasaBaixoComprometimento.Enabled = 1;
         cmbSerasaProtestoAtivo_Jsonclick = "";
         cmbSerasaProtestoAtivo.Enabled = 1;
         cmbSerasaRetricaoAtiva_Jsonclick = "";
         cmbSerasaRetricaoAtiva.Enabled = 1;
         cmbSerasaCpfRegular_Jsonclick = "";
         cmbSerasaCpfRegular.Enabled = 1;
         edtSerasaRecomendacaoVenda_Jsonclick = "";
         edtSerasaRecomendacaoVenda_Enabled = 1;
         edtSerasaTipoRecomendacao_Jsonclick = "";
         edtSerasaTipoRecomendacao_Enabled = 1;
         edtSerasaCodNivelRisco_Jsonclick = "";
         edtSerasaCodNivelRisco_Enabled = 1;
         edtSerasaCodTipoVenda_Jsonclick = "";
         edtSerasaCodTipoVenda_Enabled = 1;
         edtSerasaTipoVenda_Jsonclick = "";
         edtSerasaTipoVenda_Enabled = 1;
         edtSerasaCreatedAt_Jsonclick = "";
         edtSerasaCreatedAt_Enabled = 1;
         edtSerasaPolitica_Jsonclick = "";
         edtSerasaPolitica_Enabled = 1;
         edtSerasaNumeroProposta_Jsonclick = "";
         edtSerasaNumeroProposta_Enabled = 1;
         edtClienteId_Jsonclick = "";
         edtClienteId_Enabled = 1;
         edtClienteId_Visible = 1;
         Combo_clienteid_Datalistprocparametersprefix = " \"ComboName\": \"ClienteId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"SerasaId\": 0";
         Combo_clienteid_Datalistproc = "SerasaLoadDVCombo";
         Combo_clienteid_Cls = "ExtendedCombo AttributeFL";
         Combo_clienteid_Caption = "";
         Combo_clienteid_Enabled = Convert.ToBoolean( -1);
         edtSerasaId_Jsonclick = "";
         edtSerasaId_Enabled = 0;
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

      protected void init_web_controls( )
      {
         cmbSerasaCpfRegular.Name = "SERASACPFREGULAR";
         cmbSerasaCpfRegular.WebTags = "";
         cmbSerasaCpfRegular.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbSerasaCpfRegular.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbSerasaCpfRegular.ItemCount > 0 )
         {
            A671SerasaCpfRegular = StringUtil.StrToBool( cmbSerasaCpfRegular.getValidValue(StringUtil.BoolToStr( A671SerasaCpfRegular)));
            n671SerasaCpfRegular = false;
            AssignAttri("", false, "A671SerasaCpfRegular", A671SerasaCpfRegular);
         }
         cmbSerasaRetricaoAtiva.Name = "SERASARETRICAOATIVA";
         cmbSerasaRetricaoAtiva.WebTags = "";
         cmbSerasaRetricaoAtiva.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbSerasaRetricaoAtiva.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbSerasaRetricaoAtiva.ItemCount > 0 )
         {
            A672SerasaRetricaoAtiva = StringUtil.StrToBool( cmbSerasaRetricaoAtiva.getValidValue(StringUtil.BoolToStr( A672SerasaRetricaoAtiva)));
            n672SerasaRetricaoAtiva = false;
            AssignAttri("", false, "A672SerasaRetricaoAtiva", A672SerasaRetricaoAtiva);
         }
         cmbSerasaProtestoAtivo.Name = "SERASAPROTESTOATIVO";
         cmbSerasaProtestoAtivo.WebTags = "";
         cmbSerasaProtestoAtivo.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbSerasaProtestoAtivo.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbSerasaProtestoAtivo.ItemCount > 0 )
         {
            A673SerasaProtestoAtivo = StringUtil.StrToBool( cmbSerasaProtestoAtivo.getValidValue(StringUtil.BoolToStr( A673SerasaProtestoAtivo)));
            n673SerasaProtestoAtivo = false;
            AssignAttri("", false, "A673SerasaProtestoAtivo", A673SerasaProtestoAtivo);
         }
         cmbSerasaBaixoComprometimento.Name = "SERASABAIXOCOMPROMETIMENTO";
         cmbSerasaBaixoComprometimento.WebTags = "";
         cmbSerasaBaixoComprometimento.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbSerasaBaixoComprometimento.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbSerasaBaixoComprometimento.ItemCount > 0 )
         {
            A674SerasaBaixoComprometimento = StringUtil.StrToBool( cmbSerasaBaixoComprometimento.getValidValue(StringUtil.BoolToStr( A674SerasaBaixoComprometimento)));
            n674SerasaBaixoComprometimento = false;
            AssignAttri("", false, "A674SerasaBaixoComprometimento", A674SerasaBaixoComprometimento);
         }
         cmbSerasaAnotacoesCompletas.Name = "SERASAANOTACOESCOMPLETAS";
         cmbSerasaAnotacoesCompletas.WebTags = "";
         cmbSerasaAnotacoesCompletas.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbSerasaAnotacoesCompletas.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbSerasaAnotacoesCompletas.ItemCount > 0 )
         {
            A678SerasaAnotacoesCompletas = StringUtil.StrToBool( cmbSerasaAnotacoesCompletas.getValidValue(StringUtil.BoolToStr( A678SerasaAnotacoesCompletas)));
            n678SerasaAnotacoesCompletas = false;
            AssignAttri("", false, "A678SerasaAnotacoesCompletas", A678SerasaAnotacoesCompletas);
         }
         cmbSerasaConsultasDetalhadas.Name = "SERASACONSULTASDETALHADAS";
         cmbSerasaConsultasDetalhadas.WebTags = "";
         cmbSerasaConsultasDetalhadas.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbSerasaConsultasDetalhadas.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbSerasaConsultasDetalhadas.ItemCount > 0 )
         {
            A679SerasaConsultasDetalhadas = StringUtil.StrToBool( cmbSerasaConsultasDetalhadas.getValidValue(StringUtil.BoolToStr( A679SerasaConsultasDetalhadas)));
            n679SerasaConsultasDetalhadas = false;
            AssignAttri("", false, "A679SerasaConsultasDetalhadas", A679SerasaConsultasDetalhadas);
         }
         cmbSerasaAnotacoesConsultaSPC.Name = "SERASAANOTACOESCONSULTASPC";
         cmbSerasaAnotacoesConsultaSPC.WebTags = "";
         cmbSerasaAnotacoesConsultaSPC.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbSerasaAnotacoesConsultaSPC.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbSerasaAnotacoesConsultaSPC.ItemCount > 0 )
         {
            A680SerasaAnotacoesConsultaSPC = StringUtil.StrToBool( cmbSerasaAnotacoesConsultaSPC.getValidValue(StringUtil.BoolToStr( A680SerasaAnotacoesConsultaSPC)));
            n680SerasaAnotacoesConsultaSPC = false;
            AssignAttri("", false, "A680SerasaAnotacoesConsultaSPC", A680SerasaAnotacoesConsultaSPC);
         }
         cmbSerasaParticipacaoSocietaria.Name = "SERASAPARTICIPACAOSOCIETARIA";
         cmbSerasaParticipacaoSocietaria.WebTags = "";
         cmbSerasaParticipacaoSocietaria.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbSerasaParticipacaoSocietaria.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbSerasaParticipacaoSocietaria.ItemCount > 0 )
         {
            A681SerasaParticipacaoSocietaria = StringUtil.StrToBool( cmbSerasaParticipacaoSocietaria.getValidValue(StringUtil.BoolToStr( A681SerasaParticipacaoSocietaria)));
            n681SerasaParticipacaoSocietaria = false;
            AssignAttri("", false, "A681SerasaParticipacaoSocietaria", A681SerasaParticipacaoSocietaria);
         }
         cmbSerasaRendaEstimada.Name = "SERASARENDAESTIMADA";
         cmbSerasaRendaEstimada.WebTags = "";
         cmbSerasaRendaEstimada.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbSerasaRendaEstimada.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbSerasaRendaEstimada.ItemCount > 0 )
         {
            A682SerasaRendaEstimada = StringUtil.StrToBool( cmbSerasaRendaEstimada.getValidValue(StringUtil.BoolToStr( A682SerasaRendaEstimada)));
            n682SerasaRendaEstimada = false;
            AssignAttri("", false, "A682SerasaRendaEstimada", A682SerasaRendaEstimada);
         }
         cmbSerasaHistoricoPagamentoPF.Name = "SERASAHISTORICOPAGAMENTOPF";
         cmbSerasaHistoricoPagamentoPF.WebTags = "";
         cmbSerasaHistoricoPagamentoPF.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbSerasaHistoricoPagamentoPF.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbSerasaHistoricoPagamentoPF.ItemCount > 0 )
         {
            A683SerasaHistoricoPagamentoPF = StringUtil.StrToBool( cmbSerasaHistoricoPagamentoPF.getValidValue(StringUtil.BoolToStr( A683SerasaHistoricoPagamentoPF)));
            n683SerasaHistoricoPagamentoPF = false;
            AssignAttri("", false, "A683SerasaHistoricoPagamentoPF", A683SerasaHistoricoPagamentoPF);
         }
         cmbSerasaRecomendaCompleto.Name = "SERASARECOMENDACOMPLETO";
         cmbSerasaRecomendaCompleto.WebTags = "";
         cmbSerasaRecomendaCompleto.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbSerasaRecomendaCompleto.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbSerasaRecomendaCompleto.ItemCount > 0 )
         {
            A684SerasaRecomendaCompleto = StringUtil.StrToBool( cmbSerasaRecomendaCompleto.getValidValue(StringUtil.BoolToStr( A684SerasaRecomendaCompleto)));
            n684SerasaRecomendaCompleto = false;
            AssignAttri("", false, "A684SerasaRecomendaCompleto", A684SerasaRecomendaCompleto);
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

      public void Valid_Serasaid( )
      {
         n662SerasaId = false;
         n775SerasaCountAcoes_F = false;
         n776SerasaCountEnderecos_F = false;
         n777SerasaCountProtestos_F = false;
         n778SerasaCountOcorrencias_F = false;
         n779SerasaCountCheques_F = false;
         /* Using cursor T002E40 */
         pr_default.execute(22, new Object[] {n662SerasaId, A662SerasaId});
         if ( (pr_default.getStatus(22) != 101) )
         {
            A775SerasaCountAcoes_F = T002E40_A775SerasaCountAcoes_F[0];
            n775SerasaCountAcoes_F = T002E40_n775SerasaCountAcoes_F[0];
         }
         else
         {
            A775SerasaCountAcoes_F = 0;
            n775SerasaCountAcoes_F = false;
         }
         pr_default.close(22);
         /* Using cursor T002E42 */
         pr_default.execute(23, new Object[] {n662SerasaId, A662SerasaId});
         if ( (pr_default.getStatus(23) != 101) )
         {
            A776SerasaCountEnderecos_F = T002E42_A776SerasaCountEnderecos_F[0];
            n776SerasaCountEnderecos_F = T002E42_n776SerasaCountEnderecos_F[0];
         }
         else
         {
            A776SerasaCountEnderecos_F = 0;
            n776SerasaCountEnderecos_F = false;
         }
         pr_default.close(23);
         /* Using cursor T002E44 */
         pr_default.execute(24, new Object[] {n662SerasaId, A662SerasaId});
         if ( (pr_default.getStatus(24) != 101) )
         {
            A777SerasaCountProtestos_F = T002E44_A777SerasaCountProtestos_F[0];
            n777SerasaCountProtestos_F = T002E44_n777SerasaCountProtestos_F[0];
         }
         else
         {
            A777SerasaCountProtestos_F = 0;
            n777SerasaCountProtestos_F = false;
         }
         pr_default.close(24);
         /* Using cursor T002E46 */
         pr_default.execute(25, new Object[] {n662SerasaId, A662SerasaId});
         if ( (pr_default.getStatus(25) != 101) )
         {
            A778SerasaCountOcorrencias_F = T002E46_A778SerasaCountOcorrencias_F[0];
            n778SerasaCountOcorrencias_F = T002E46_n778SerasaCountOcorrencias_F[0];
         }
         else
         {
            A778SerasaCountOcorrencias_F = 0;
            n778SerasaCountOcorrencias_F = false;
         }
         pr_default.close(25);
         /* Using cursor T002E48 */
         pr_default.execute(26, new Object[] {n662SerasaId, A662SerasaId});
         if ( (pr_default.getStatus(26) != 101) )
         {
            A779SerasaCountCheques_F = T002E48_A779SerasaCountCheques_F[0];
            n779SerasaCountCheques_F = T002E48_n779SerasaCountCheques_F[0];
         }
         else
         {
            A779SerasaCountCheques_F = 0;
            n779SerasaCountCheques_F = false;
         }
         pr_default.close(26);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A775SerasaCountAcoes_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A775SerasaCountAcoes_F), 4, 0, ".", "")));
         AssignAttri("", false, "A776SerasaCountEnderecos_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A776SerasaCountEnderecos_F), 4, 0, ".", "")));
         AssignAttri("", false, "A777SerasaCountProtestos_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A777SerasaCountProtestos_F), 4, 0, ".", "")));
         AssignAttri("", false, "A778SerasaCountOcorrencias_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A778SerasaCountOcorrencias_F), 4, 0, ".", "")));
         AssignAttri("", false, "A779SerasaCountCheques_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A779SerasaCountCheques_F), 4, 0, ".", "")));
      }

      public void Valid_Clienteid( )
      {
         n170ClienteRazaoSocial = false;
         /* Using cursor T002E49 */
         pr_default.execute(27, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(27) == 101) )
         {
            if ( ! ( (0==A168ClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtClienteId_Internalname;
            }
         }
         A170ClienteRazaoSocial = T002E49_A170ClienteRazaoSocial[0];
         n170ClienteRazaoSocial = T002E49_n170ClienteRazaoSocial[0];
         pr_default.close(27);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A170ClienteRazaoSocial", A170ClienteRazaoSocial);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7SerasaId","fld":"vSERASAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7SerasaId","fld":"vSERASAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A662SerasaId","fld":"SERASAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV11Insert_ClienteId","fld":"vINSERT_CLIENTEID","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E122E2","iparms":[]}""");
         setEventMetadata("VALID_SERASAID","""{"handler":"Valid_Serasaid","iparms":[{"av":"A662SerasaId","fld":"SERASAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A775SerasaCountAcoes_F","fld":"SERASACOUNTACOES_F","pic":"ZZZ9","type":"int"},{"av":"A776SerasaCountEnderecos_F","fld":"SERASACOUNTENDERECOS_F","pic":"ZZZ9","type":"int"},{"av":"A777SerasaCountProtestos_F","fld":"SERASACOUNTPROTESTOS_F","pic":"ZZZ9","type":"int"},{"av":"A778SerasaCountOcorrencias_F","fld":"SERASACOUNTOCORRENCIAS_F","pic":"ZZZ9","type":"int"},{"av":"A779SerasaCountCheques_F","fld":"SERASACOUNTCHEQUES_F","pic":"ZZZ9","type":"int"}]""");
         setEventMetadata("VALID_SERASAID",""","oparms":[{"av":"A775SerasaCountAcoes_F","fld":"SERASACOUNTACOES_F","pic":"ZZZ9","type":"int"},{"av":"A776SerasaCountEnderecos_F","fld":"SERASACOUNTENDERECOS_F","pic":"ZZZ9","type":"int"},{"av":"A777SerasaCountProtestos_F","fld":"SERASACOUNTPROTESTOS_F","pic":"ZZZ9","type":"int"},{"av":"A778SerasaCountOcorrencias_F","fld":"SERASACOUNTOCORRENCIAS_F","pic":"ZZZ9","type":"int"},{"av":"A779SerasaCountCheques_F","fld":"SERASACOUNTCHEQUES_F","pic":"ZZZ9","type":"int"}]}""");
         setEventMetadata("VALID_CLIENTEID","""{"handler":"Valid_Clienteid","iparms":[{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","nullAv":"n168ClienteId","type":"int"},{"av":"A170ClienteRazaoSocial","fld":"CLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"}]""");
         setEventMetadata("VALID_CLIENTEID",""","oparms":[{"av":"A170ClienteRazaoSocial","fld":"CLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"}]}""");
         setEventMetadata("VALID_SERASAVALORLIMITERECOMENDADO","""{"handler":"Valid_Serasavalorlimiterecomendado","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOCLIENTEID","""{"handler":"Validv_Comboclienteid","iparms":[]}""");
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
         pr_default.close(27);
         pr_default.close(22);
         pr_default.close(23);
         pr_default.close(24);
         pr_default.close(25);
         pr_default.close(26);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z665SerasaCreatedAt = (DateTime)(DateTime.MinValue);
         Z663SerasaNumeroProposta = "";
         Z666SerasaTipoVenda = "";
         Z669SerasaTipoRecomendacao = "";
         Z670SerasaRecomendacaoVenda = "";
         Z677SerasaMensagemRendaEstimada = "";
         Z687SerasaMensagemScore = "";
         Z688SerasaSituacaoCPF = "";
         Z689SerasaDataNascimento = DateTime.MinValue;
         Z690SerasaGenero = "";
         Z691SerasaNomeMae = "";
         Z692SerasaGrafia = "";
         Combo_clienteid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         lblTextblockclienteid_Jsonclick = "";
         ucCombo_clienteid = new GXUserControl();
         AV14DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV13ClienteId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A663SerasaNumeroProposta = "";
         A665SerasaCreatedAt = (DateTime)(DateTime.MinValue);
         A666SerasaTipoVenda = "";
         A669SerasaTipoRecomendacao = "";
         A670SerasaRecomendacaoVenda = "";
         A677SerasaMensagemRendaEstimada = "";
         A687SerasaMensagemScore = "";
         A688SerasaSituacaoCPF = "";
         A689SerasaDataNascimento = DateTime.MinValue;
         A690SerasaGenero = "";
         A691SerasaNomeMae = "";
         A692SerasaGrafia = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A774SerasaJSON = "";
         A170ClienteRazaoSocial = "";
         AV19Pgmname = "";
         Combo_clienteid_Objectcall = "";
         Combo_clienteid_Class = "";
         Combo_clienteid_Icontype = "";
         Combo_clienteid_Icon = "";
         Combo_clienteid_Tooltip = "";
         Combo_clienteid_Selectedvalue_set = "";
         Combo_clienteid_Selectedtext_set = "";
         Combo_clienteid_Selectedtext_get = "";
         Combo_clienteid_Gamoauthtoken = "";
         Combo_clienteid_Ddointernalname = "";
         Combo_clienteid_Titlecontrolalign = "";
         Combo_clienteid_Dropdownoptionstype = "";
         Combo_clienteid_Titlecontrolidtoreplace = "";
         Combo_clienteid_Datalisttype = "";
         Combo_clienteid_Datalistfixedvalues = "";
         Combo_clienteid_Remoteservicesparameters = "";
         Combo_clienteid_Htmltemplate = "";
         Combo_clienteid_Multiplevaluestype = "";
         Combo_clienteid_Loadingdata = "";
         Combo_clienteid_Noresultsfound = "";
         Combo_clienteid_Emptyitemtext = "";
         Combo_clienteid_Onlyselectedvalues = "";
         Combo_clienteid_Selectalltext = "";
         Combo_clienteid_Multiplevaluesseparator = "";
         Combo_clienteid_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode84 = "";
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
         AV12TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV17Combo_DataJson = "";
         AV15ComboSelectedValue = "";
         AV16ComboSelectedText = "";
         GXt_char2 = "";
         Z774SerasaJSON = "";
         Z170ClienteRazaoSocial = "";
         T002E6_A775SerasaCountAcoes_F = new short[1] ;
         T002E6_n775SerasaCountAcoes_F = new bool[] {false} ;
         T002E8_A776SerasaCountEnderecos_F = new short[1] ;
         T002E8_n776SerasaCountEnderecos_F = new bool[] {false} ;
         T002E10_A777SerasaCountProtestos_F = new short[1] ;
         T002E10_n777SerasaCountProtestos_F = new bool[] {false} ;
         T002E12_A778SerasaCountOcorrencias_F = new short[1] ;
         T002E12_n778SerasaCountOcorrencias_F = new bool[] {false} ;
         T002E14_A779SerasaCountCheques_F = new short[1] ;
         T002E14_n779SerasaCountCheques_F = new bool[] {false} ;
         T002E4_A170ClienteRazaoSocial = new string[] {""} ;
         T002E4_n170ClienteRazaoSocial = new bool[] {false} ;
         T002E20_A662SerasaId = new int[1] ;
         T002E20_n662SerasaId = new bool[] {false} ;
         T002E20_A665SerasaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T002E20_n665SerasaCreatedAt = new bool[] {false} ;
         T002E20_A170ClienteRazaoSocial = new string[] {""} ;
         T002E20_n170ClienteRazaoSocial = new bool[] {false} ;
         T002E20_A663SerasaNumeroProposta = new string[] {""} ;
         T002E20_n663SerasaNumeroProposta = new bool[] {false} ;
         T002E20_A664SerasaPolitica = new decimal[1] ;
         T002E20_n664SerasaPolitica = new bool[] {false} ;
         T002E20_A666SerasaTipoVenda = new string[] {""} ;
         T002E20_n666SerasaTipoVenda = new bool[] {false} ;
         T002E20_A667SerasaCodTipoVenda = new decimal[1] ;
         T002E20_n667SerasaCodTipoVenda = new bool[] {false} ;
         T002E20_A668SerasaCodNivelRisco = new decimal[1] ;
         T002E20_n668SerasaCodNivelRisco = new bool[] {false} ;
         T002E20_A669SerasaTipoRecomendacao = new string[] {""} ;
         T002E20_n669SerasaTipoRecomendacao = new bool[] {false} ;
         T002E20_A670SerasaRecomendacaoVenda = new string[] {""} ;
         T002E20_n670SerasaRecomendacaoVenda = new bool[] {false} ;
         T002E20_A671SerasaCpfRegular = new bool[] {false} ;
         T002E20_n671SerasaCpfRegular = new bool[] {false} ;
         T002E20_A672SerasaRetricaoAtiva = new bool[] {false} ;
         T002E20_n672SerasaRetricaoAtiva = new bool[] {false} ;
         T002E20_A673SerasaProtestoAtivo = new bool[] {false} ;
         T002E20_n673SerasaProtestoAtivo = new bool[] {false} ;
         T002E20_A674SerasaBaixoComprometimento = new bool[] {false} ;
         T002E20_n674SerasaBaixoComprometimento = new bool[] {false} ;
         T002E20_A675SerasaValorLimiteRecomendado = new decimal[1] ;
         T002E20_n675SerasaValorLimiteRecomendado = new bool[] {false} ;
         T002E20_A676SerasaFaixaDeRendaEstimada = new decimal[1] ;
         T002E20_n676SerasaFaixaDeRendaEstimada = new bool[] {false} ;
         T002E20_A677SerasaMensagemRendaEstimada = new string[] {""} ;
         T002E20_n677SerasaMensagemRendaEstimada = new bool[] {false} ;
         T002E20_A678SerasaAnotacoesCompletas = new bool[] {false} ;
         T002E20_n678SerasaAnotacoesCompletas = new bool[] {false} ;
         T002E20_A679SerasaConsultasDetalhadas = new bool[] {false} ;
         T002E20_n679SerasaConsultasDetalhadas = new bool[] {false} ;
         T002E20_A680SerasaAnotacoesConsultaSPC = new bool[] {false} ;
         T002E20_n680SerasaAnotacoesConsultaSPC = new bool[] {false} ;
         T002E20_A681SerasaParticipacaoSocietaria = new bool[] {false} ;
         T002E20_n681SerasaParticipacaoSocietaria = new bool[] {false} ;
         T002E20_A682SerasaRendaEstimada = new bool[] {false} ;
         T002E20_n682SerasaRendaEstimada = new bool[] {false} ;
         T002E20_A683SerasaHistoricoPagamentoPF = new bool[] {false} ;
         T002E20_n683SerasaHistoricoPagamentoPF = new bool[] {false} ;
         T002E20_A684SerasaRecomendaCompleto = new bool[] {false} ;
         T002E20_n684SerasaRecomendaCompleto = new bool[] {false} ;
         T002E20_A685SerasaScore = new short[1] ;
         T002E20_n685SerasaScore = new bool[] {false} ;
         T002E20_A686SerasaTaxa = new decimal[1] ;
         T002E20_n686SerasaTaxa = new bool[] {false} ;
         T002E20_A687SerasaMensagemScore = new string[] {""} ;
         T002E20_n687SerasaMensagemScore = new bool[] {false} ;
         T002E20_A688SerasaSituacaoCPF = new string[] {""} ;
         T002E20_n688SerasaSituacaoCPF = new bool[] {false} ;
         T002E20_A689SerasaDataNascimento = new DateTime[] {DateTime.MinValue} ;
         T002E20_n689SerasaDataNascimento = new bool[] {false} ;
         T002E20_A690SerasaGenero = new string[] {""} ;
         T002E20_n690SerasaGenero = new bool[] {false} ;
         T002E20_A691SerasaNomeMae = new string[] {""} ;
         T002E20_n691SerasaNomeMae = new bool[] {false} ;
         T002E20_A692SerasaGrafia = new string[] {""} ;
         T002E20_n692SerasaGrafia = new bool[] {false} ;
         T002E20_A774SerasaJSON = new string[] {""} ;
         T002E20_n774SerasaJSON = new bool[] {false} ;
         T002E20_A168ClienteId = new int[1] ;
         T002E20_n168ClienteId = new bool[] {false} ;
         T002E20_A775SerasaCountAcoes_F = new short[1] ;
         T002E20_n775SerasaCountAcoes_F = new bool[] {false} ;
         T002E20_A776SerasaCountEnderecos_F = new short[1] ;
         T002E20_n776SerasaCountEnderecos_F = new bool[] {false} ;
         T002E20_A777SerasaCountProtestos_F = new short[1] ;
         T002E20_n777SerasaCountProtestos_F = new bool[] {false} ;
         T002E20_A778SerasaCountOcorrencias_F = new short[1] ;
         T002E20_n778SerasaCountOcorrencias_F = new bool[] {false} ;
         T002E20_A779SerasaCountCheques_F = new short[1] ;
         T002E20_n779SerasaCountCheques_F = new bool[] {false} ;
         T002E22_A775SerasaCountAcoes_F = new short[1] ;
         T002E22_n775SerasaCountAcoes_F = new bool[] {false} ;
         T002E24_A776SerasaCountEnderecos_F = new short[1] ;
         T002E24_n776SerasaCountEnderecos_F = new bool[] {false} ;
         T002E26_A777SerasaCountProtestos_F = new short[1] ;
         T002E26_n777SerasaCountProtestos_F = new bool[] {false} ;
         T002E28_A778SerasaCountOcorrencias_F = new short[1] ;
         T002E28_n778SerasaCountOcorrencias_F = new bool[] {false} ;
         T002E30_A779SerasaCountCheques_F = new short[1] ;
         T002E30_n779SerasaCountCheques_F = new bool[] {false} ;
         T002E31_A170ClienteRazaoSocial = new string[] {""} ;
         T002E31_n170ClienteRazaoSocial = new bool[] {false} ;
         T002E32_A662SerasaId = new int[1] ;
         T002E32_n662SerasaId = new bool[] {false} ;
         T002E3_A662SerasaId = new int[1] ;
         T002E3_n662SerasaId = new bool[] {false} ;
         T002E3_A665SerasaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T002E3_n665SerasaCreatedAt = new bool[] {false} ;
         T002E3_A663SerasaNumeroProposta = new string[] {""} ;
         T002E3_n663SerasaNumeroProposta = new bool[] {false} ;
         T002E3_A664SerasaPolitica = new decimal[1] ;
         T002E3_n664SerasaPolitica = new bool[] {false} ;
         T002E3_A666SerasaTipoVenda = new string[] {""} ;
         T002E3_n666SerasaTipoVenda = new bool[] {false} ;
         T002E3_A667SerasaCodTipoVenda = new decimal[1] ;
         T002E3_n667SerasaCodTipoVenda = new bool[] {false} ;
         T002E3_A668SerasaCodNivelRisco = new decimal[1] ;
         T002E3_n668SerasaCodNivelRisco = new bool[] {false} ;
         T002E3_A669SerasaTipoRecomendacao = new string[] {""} ;
         T002E3_n669SerasaTipoRecomendacao = new bool[] {false} ;
         T002E3_A670SerasaRecomendacaoVenda = new string[] {""} ;
         T002E3_n670SerasaRecomendacaoVenda = new bool[] {false} ;
         T002E3_A671SerasaCpfRegular = new bool[] {false} ;
         T002E3_n671SerasaCpfRegular = new bool[] {false} ;
         T002E3_A672SerasaRetricaoAtiva = new bool[] {false} ;
         T002E3_n672SerasaRetricaoAtiva = new bool[] {false} ;
         T002E3_A673SerasaProtestoAtivo = new bool[] {false} ;
         T002E3_n673SerasaProtestoAtivo = new bool[] {false} ;
         T002E3_A674SerasaBaixoComprometimento = new bool[] {false} ;
         T002E3_n674SerasaBaixoComprometimento = new bool[] {false} ;
         T002E3_A675SerasaValorLimiteRecomendado = new decimal[1] ;
         T002E3_n675SerasaValorLimiteRecomendado = new bool[] {false} ;
         T002E3_A676SerasaFaixaDeRendaEstimada = new decimal[1] ;
         T002E3_n676SerasaFaixaDeRendaEstimada = new bool[] {false} ;
         T002E3_A677SerasaMensagemRendaEstimada = new string[] {""} ;
         T002E3_n677SerasaMensagemRendaEstimada = new bool[] {false} ;
         T002E3_A678SerasaAnotacoesCompletas = new bool[] {false} ;
         T002E3_n678SerasaAnotacoesCompletas = new bool[] {false} ;
         T002E3_A679SerasaConsultasDetalhadas = new bool[] {false} ;
         T002E3_n679SerasaConsultasDetalhadas = new bool[] {false} ;
         T002E3_A680SerasaAnotacoesConsultaSPC = new bool[] {false} ;
         T002E3_n680SerasaAnotacoesConsultaSPC = new bool[] {false} ;
         T002E3_A681SerasaParticipacaoSocietaria = new bool[] {false} ;
         T002E3_n681SerasaParticipacaoSocietaria = new bool[] {false} ;
         T002E3_A682SerasaRendaEstimada = new bool[] {false} ;
         T002E3_n682SerasaRendaEstimada = new bool[] {false} ;
         T002E3_A683SerasaHistoricoPagamentoPF = new bool[] {false} ;
         T002E3_n683SerasaHistoricoPagamentoPF = new bool[] {false} ;
         T002E3_A684SerasaRecomendaCompleto = new bool[] {false} ;
         T002E3_n684SerasaRecomendaCompleto = new bool[] {false} ;
         T002E3_A685SerasaScore = new short[1] ;
         T002E3_n685SerasaScore = new bool[] {false} ;
         T002E3_A686SerasaTaxa = new decimal[1] ;
         T002E3_n686SerasaTaxa = new bool[] {false} ;
         T002E3_A687SerasaMensagemScore = new string[] {""} ;
         T002E3_n687SerasaMensagemScore = new bool[] {false} ;
         T002E3_A688SerasaSituacaoCPF = new string[] {""} ;
         T002E3_n688SerasaSituacaoCPF = new bool[] {false} ;
         T002E3_A689SerasaDataNascimento = new DateTime[] {DateTime.MinValue} ;
         T002E3_n689SerasaDataNascimento = new bool[] {false} ;
         T002E3_A690SerasaGenero = new string[] {""} ;
         T002E3_n690SerasaGenero = new bool[] {false} ;
         T002E3_A691SerasaNomeMae = new string[] {""} ;
         T002E3_n691SerasaNomeMae = new bool[] {false} ;
         T002E3_A692SerasaGrafia = new string[] {""} ;
         T002E3_n692SerasaGrafia = new bool[] {false} ;
         T002E3_A774SerasaJSON = new string[] {""} ;
         T002E3_n774SerasaJSON = new bool[] {false} ;
         T002E3_A168ClienteId = new int[1] ;
         T002E3_n168ClienteId = new bool[] {false} ;
         T002E33_A662SerasaId = new int[1] ;
         T002E33_n662SerasaId = new bool[] {false} ;
         T002E34_A662SerasaId = new int[1] ;
         T002E34_n662SerasaId = new bool[] {false} ;
         T002E2_A662SerasaId = new int[1] ;
         T002E2_n662SerasaId = new bool[] {false} ;
         T002E2_A665SerasaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T002E2_n665SerasaCreatedAt = new bool[] {false} ;
         T002E2_A663SerasaNumeroProposta = new string[] {""} ;
         T002E2_n663SerasaNumeroProposta = new bool[] {false} ;
         T002E2_A664SerasaPolitica = new decimal[1] ;
         T002E2_n664SerasaPolitica = new bool[] {false} ;
         T002E2_A666SerasaTipoVenda = new string[] {""} ;
         T002E2_n666SerasaTipoVenda = new bool[] {false} ;
         T002E2_A667SerasaCodTipoVenda = new decimal[1] ;
         T002E2_n667SerasaCodTipoVenda = new bool[] {false} ;
         T002E2_A668SerasaCodNivelRisco = new decimal[1] ;
         T002E2_n668SerasaCodNivelRisco = new bool[] {false} ;
         T002E2_A669SerasaTipoRecomendacao = new string[] {""} ;
         T002E2_n669SerasaTipoRecomendacao = new bool[] {false} ;
         T002E2_A670SerasaRecomendacaoVenda = new string[] {""} ;
         T002E2_n670SerasaRecomendacaoVenda = new bool[] {false} ;
         T002E2_A671SerasaCpfRegular = new bool[] {false} ;
         T002E2_n671SerasaCpfRegular = new bool[] {false} ;
         T002E2_A672SerasaRetricaoAtiva = new bool[] {false} ;
         T002E2_n672SerasaRetricaoAtiva = new bool[] {false} ;
         T002E2_A673SerasaProtestoAtivo = new bool[] {false} ;
         T002E2_n673SerasaProtestoAtivo = new bool[] {false} ;
         T002E2_A674SerasaBaixoComprometimento = new bool[] {false} ;
         T002E2_n674SerasaBaixoComprometimento = new bool[] {false} ;
         T002E2_A675SerasaValorLimiteRecomendado = new decimal[1] ;
         T002E2_n675SerasaValorLimiteRecomendado = new bool[] {false} ;
         T002E2_A676SerasaFaixaDeRendaEstimada = new decimal[1] ;
         T002E2_n676SerasaFaixaDeRendaEstimada = new bool[] {false} ;
         T002E2_A677SerasaMensagemRendaEstimada = new string[] {""} ;
         T002E2_n677SerasaMensagemRendaEstimada = new bool[] {false} ;
         T002E2_A678SerasaAnotacoesCompletas = new bool[] {false} ;
         T002E2_n678SerasaAnotacoesCompletas = new bool[] {false} ;
         T002E2_A679SerasaConsultasDetalhadas = new bool[] {false} ;
         T002E2_n679SerasaConsultasDetalhadas = new bool[] {false} ;
         T002E2_A680SerasaAnotacoesConsultaSPC = new bool[] {false} ;
         T002E2_n680SerasaAnotacoesConsultaSPC = new bool[] {false} ;
         T002E2_A681SerasaParticipacaoSocietaria = new bool[] {false} ;
         T002E2_n681SerasaParticipacaoSocietaria = new bool[] {false} ;
         T002E2_A682SerasaRendaEstimada = new bool[] {false} ;
         T002E2_n682SerasaRendaEstimada = new bool[] {false} ;
         T002E2_A683SerasaHistoricoPagamentoPF = new bool[] {false} ;
         T002E2_n683SerasaHistoricoPagamentoPF = new bool[] {false} ;
         T002E2_A684SerasaRecomendaCompleto = new bool[] {false} ;
         T002E2_n684SerasaRecomendaCompleto = new bool[] {false} ;
         T002E2_A685SerasaScore = new short[1] ;
         T002E2_n685SerasaScore = new bool[] {false} ;
         T002E2_A686SerasaTaxa = new decimal[1] ;
         T002E2_n686SerasaTaxa = new bool[] {false} ;
         T002E2_A687SerasaMensagemScore = new string[] {""} ;
         T002E2_n687SerasaMensagemScore = new bool[] {false} ;
         T002E2_A688SerasaSituacaoCPF = new string[] {""} ;
         T002E2_n688SerasaSituacaoCPF = new bool[] {false} ;
         T002E2_A689SerasaDataNascimento = new DateTime[] {DateTime.MinValue} ;
         T002E2_n689SerasaDataNascimento = new bool[] {false} ;
         T002E2_A690SerasaGenero = new string[] {""} ;
         T002E2_n690SerasaGenero = new bool[] {false} ;
         T002E2_A691SerasaNomeMae = new string[] {""} ;
         T002E2_n691SerasaNomeMae = new bool[] {false} ;
         T002E2_A692SerasaGrafia = new string[] {""} ;
         T002E2_n692SerasaGrafia = new bool[] {false} ;
         T002E2_A774SerasaJSON = new string[] {""} ;
         T002E2_n774SerasaJSON = new bool[] {false} ;
         T002E2_A168ClienteId = new int[1] ;
         T002E2_n168ClienteId = new bool[] {false} ;
         T002E36_A662SerasaId = new int[1] ;
         T002E36_n662SerasaId = new bool[] {false} ;
         T002E40_A775SerasaCountAcoes_F = new short[1] ;
         T002E40_n775SerasaCountAcoes_F = new bool[] {false} ;
         T002E42_A776SerasaCountEnderecos_F = new short[1] ;
         T002E42_n776SerasaCountEnderecos_F = new bool[] {false} ;
         T002E44_A777SerasaCountProtestos_F = new short[1] ;
         T002E44_n777SerasaCountProtestos_F = new bool[] {false} ;
         T002E46_A778SerasaCountOcorrencias_F = new short[1] ;
         T002E46_n778SerasaCountOcorrencias_F = new bool[] {false} ;
         T002E48_A779SerasaCountCheques_F = new short[1] ;
         T002E48_n779SerasaCountCheques_F = new bool[] {false} ;
         T002E49_A170ClienteRazaoSocial = new string[] {""} ;
         T002E49_n170ClienteRazaoSocial = new bool[] {false} ;
         T002E50_A726SerasaOcorrenciasId = new int[1] ;
         T002E51_A716SerasaEnderecosId = new int[1] ;
         T002E52_A711SerasaProtestosId = new int[1] ;
         T002E53_A699SerasaAcoesId = new int[1] ;
         T002E54_A693SerasaChequesId = new int[1] ;
         T002E55_A662SerasaId = new int[1] ;
         T002E55_n662SerasaId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i665SerasaCreatedAt = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.serasa__default(),
            new Object[][] {
                new Object[] {
               T002E2_A662SerasaId, T002E2_A665SerasaCreatedAt, T002E2_n665SerasaCreatedAt, T002E2_A663SerasaNumeroProposta, T002E2_n663SerasaNumeroProposta, T002E2_A664SerasaPolitica, T002E2_n664SerasaPolitica, T002E2_A666SerasaTipoVenda, T002E2_n666SerasaTipoVenda, T002E2_A667SerasaCodTipoVenda,
               T002E2_n667SerasaCodTipoVenda, T002E2_A668SerasaCodNivelRisco, T002E2_n668SerasaCodNivelRisco, T002E2_A669SerasaTipoRecomendacao, T002E2_n669SerasaTipoRecomendacao, T002E2_A670SerasaRecomendacaoVenda, T002E2_n670SerasaRecomendacaoVenda, T002E2_A671SerasaCpfRegular, T002E2_n671SerasaCpfRegular, T002E2_A672SerasaRetricaoAtiva,
               T002E2_n672SerasaRetricaoAtiva, T002E2_A673SerasaProtestoAtivo, T002E2_n673SerasaProtestoAtivo, T002E2_A674SerasaBaixoComprometimento, T002E2_n674SerasaBaixoComprometimento, T002E2_A675SerasaValorLimiteRecomendado, T002E2_n675SerasaValorLimiteRecomendado, T002E2_A676SerasaFaixaDeRendaEstimada, T002E2_n676SerasaFaixaDeRendaEstimada, T002E2_A677SerasaMensagemRendaEstimada,
               T002E2_n677SerasaMensagemRendaEstimada, T002E2_A678SerasaAnotacoesCompletas, T002E2_n678SerasaAnotacoesCompletas, T002E2_A679SerasaConsultasDetalhadas, T002E2_n679SerasaConsultasDetalhadas, T002E2_A680SerasaAnotacoesConsultaSPC, T002E2_n680SerasaAnotacoesConsultaSPC, T002E2_A681SerasaParticipacaoSocietaria, T002E2_n681SerasaParticipacaoSocietaria, T002E2_A682SerasaRendaEstimada,
               T002E2_n682SerasaRendaEstimada, T002E2_A683SerasaHistoricoPagamentoPF, T002E2_n683SerasaHistoricoPagamentoPF, T002E2_A684SerasaRecomendaCompleto, T002E2_n684SerasaRecomendaCompleto, T002E2_A685SerasaScore, T002E2_n685SerasaScore, T002E2_A686SerasaTaxa, T002E2_n686SerasaTaxa, T002E2_A687SerasaMensagemScore,
               T002E2_n687SerasaMensagemScore, T002E2_A688SerasaSituacaoCPF, T002E2_n688SerasaSituacaoCPF, T002E2_A689SerasaDataNascimento, T002E2_n689SerasaDataNascimento, T002E2_A690SerasaGenero, T002E2_n690SerasaGenero, T002E2_A691SerasaNomeMae, T002E2_n691SerasaNomeMae, T002E2_A692SerasaGrafia,
               T002E2_n692SerasaGrafia, T002E2_A774SerasaJSON, T002E2_n774SerasaJSON, T002E2_A168ClienteId, T002E2_n168ClienteId
               }
               , new Object[] {
               T002E3_A662SerasaId, T002E3_A665SerasaCreatedAt, T002E3_n665SerasaCreatedAt, T002E3_A663SerasaNumeroProposta, T002E3_n663SerasaNumeroProposta, T002E3_A664SerasaPolitica, T002E3_n664SerasaPolitica, T002E3_A666SerasaTipoVenda, T002E3_n666SerasaTipoVenda, T002E3_A667SerasaCodTipoVenda,
               T002E3_n667SerasaCodTipoVenda, T002E3_A668SerasaCodNivelRisco, T002E3_n668SerasaCodNivelRisco, T002E3_A669SerasaTipoRecomendacao, T002E3_n669SerasaTipoRecomendacao, T002E3_A670SerasaRecomendacaoVenda, T002E3_n670SerasaRecomendacaoVenda, T002E3_A671SerasaCpfRegular, T002E3_n671SerasaCpfRegular, T002E3_A672SerasaRetricaoAtiva,
               T002E3_n672SerasaRetricaoAtiva, T002E3_A673SerasaProtestoAtivo, T002E3_n673SerasaProtestoAtivo, T002E3_A674SerasaBaixoComprometimento, T002E3_n674SerasaBaixoComprometimento, T002E3_A675SerasaValorLimiteRecomendado, T002E3_n675SerasaValorLimiteRecomendado, T002E3_A676SerasaFaixaDeRendaEstimada, T002E3_n676SerasaFaixaDeRendaEstimada, T002E3_A677SerasaMensagemRendaEstimada,
               T002E3_n677SerasaMensagemRendaEstimada, T002E3_A678SerasaAnotacoesCompletas, T002E3_n678SerasaAnotacoesCompletas, T002E3_A679SerasaConsultasDetalhadas, T002E3_n679SerasaConsultasDetalhadas, T002E3_A680SerasaAnotacoesConsultaSPC, T002E3_n680SerasaAnotacoesConsultaSPC, T002E3_A681SerasaParticipacaoSocietaria, T002E3_n681SerasaParticipacaoSocietaria, T002E3_A682SerasaRendaEstimada,
               T002E3_n682SerasaRendaEstimada, T002E3_A683SerasaHistoricoPagamentoPF, T002E3_n683SerasaHistoricoPagamentoPF, T002E3_A684SerasaRecomendaCompleto, T002E3_n684SerasaRecomendaCompleto, T002E3_A685SerasaScore, T002E3_n685SerasaScore, T002E3_A686SerasaTaxa, T002E3_n686SerasaTaxa, T002E3_A687SerasaMensagemScore,
               T002E3_n687SerasaMensagemScore, T002E3_A688SerasaSituacaoCPF, T002E3_n688SerasaSituacaoCPF, T002E3_A689SerasaDataNascimento, T002E3_n689SerasaDataNascimento, T002E3_A690SerasaGenero, T002E3_n690SerasaGenero, T002E3_A691SerasaNomeMae, T002E3_n691SerasaNomeMae, T002E3_A692SerasaGrafia,
               T002E3_n692SerasaGrafia, T002E3_A774SerasaJSON, T002E3_n774SerasaJSON, T002E3_A168ClienteId, T002E3_n168ClienteId
               }
               , new Object[] {
               T002E4_A170ClienteRazaoSocial, T002E4_n170ClienteRazaoSocial
               }
               , new Object[] {
               T002E6_A775SerasaCountAcoes_F, T002E6_n775SerasaCountAcoes_F
               }
               , new Object[] {
               T002E8_A776SerasaCountEnderecos_F, T002E8_n776SerasaCountEnderecos_F
               }
               , new Object[] {
               T002E10_A777SerasaCountProtestos_F, T002E10_n777SerasaCountProtestos_F
               }
               , new Object[] {
               T002E12_A778SerasaCountOcorrencias_F, T002E12_n778SerasaCountOcorrencias_F
               }
               , new Object[] {
               T002E14_A779SerasaCountCheques_F, T002E14_n779SerasaCountCheques_F
               }
               , new Object[] {
               T002E20_A662SerasaId, T002E20_A665SerasaCreatedAt, T002E20_n665SerasaCreatedAt, T002E20_A170ClienteRazaoSocial, T002E20_n170ClienteRazaoSocial, T002E20_A663SerasaNumeroProposta, T002E20_n663SerasaNumeroProposta, T002E20_A664SerasaPolitica, T002E20_n664SerasaPolitica, T002E20_A666SerasaTipoVenda,
               T002E20_n666SerasaTipoVenda, T002E20_A667SerasaCodTipoVenda, T002E20_n667SerasaCodTipoVenda, T002E20_A668SerasaCodNivelRisco, T002E20_n668SerasaCodNivelRisco, T002E20_A669SerasaTipoRecomendacao, T002E20_n669SerasaTipoRecomendacao, T002E20_A670SerasaRecomendacaoVenda, T002E20_n670SerasaRecomendacaoVenda, T002E20_A671SerasaCpfRegular,
               T002E20_n671SerasaCpfRegular, T002E20_A672SerasaRetricaoAtiva, T002E20_n672SerasaRetricaoAtiva, T002E20_A673SerasaProtestoAtivo, T002E20_n673SerasaProtestoAtivo, T002E20_A674SerasaBaixoComprometimento, T002E20_n674SerasaBaixoComprometimento, T002E20_A675SerasaValorLimiteRecomendado, T002E20_n675SerasaValorLimiteRecomendado, T002E20_A676SerasaFaixaDeRendaEstimada,
               T002E20_n676SerasaFaixaDeRendaEstimada, T002E20_A677SerasaMensagemRendaEstimada, T002E20_n677SerasaMensagemRendaEstimada, T002E20_A678SerasaAnotacoesCompletas, T002E20_n678SerasaAnotacoesCompletas, T002E20_A679SerasaConsultasDetalhadas, T002E20_n679SerasaConsultasDetalhadas, T002E20_A680SerasaAnotacoesConsultaSPC, T002E20_n680SerasaAnotacoesConsultaSPC, T002E20_A681SerasaParticipacaoSocietaria,
               T002E20_n681SerasaParticipacaoSocietaria, T002E20_A682SerasaRendaEstimada, T002E20_n682SerasaRendaEstimada, T002E20_A683SerasaHistoricoPagamentoPF, T002E20_n683SerasaHistoricoPagamentoPF, T002E20_A684SerasaRecomendaCompleto, T002E20_n684SerasaRecomendaCompleto, T002E20_A685SerasaScore, T002E20_n685SerasaScore, T002E20_A686SerasaTaxa,
               T002E20_n686SerasaTaxa, T002E20_A687SerasaMensagemScore, T002E20_n687SerasaMensagemScore, T002E20_A688SerasaSituacaoCPF, T002E20_n688SerasaSituacaoCPF, T002E20_A689SerasaDataNascimento, T002E20_n689SerasaDataNascimento, T002E20_A690SerasaGenero, T002E20_n690SerasaGenero, T002E20_A691SerasaNomeMae,
               T002E20_n691SerasaNomeMae, T002E20_A692SerasaGrafia, T002E20_n692SerasaGrafia, T002E20_A774SerasaJSON, T002E20_n774SerasaJSON, T002E20_A168ClienteId, T002E20_n168ClienteId, T002E20_A775SerasaCountAcoes_F, T002E20_n775SerasaCountAcoes_F, T002E20_A776SerasaCountEnderecos_F,
               T002E20_n776SerasaCountEnderecos_F, T002E20_A777SerasaCountProtestos_F, T002E20_n777SerasaCountProtestos_F, T002E20_A778SerasaCountOcorrencias_F, T002E20_n778SerasaCountOcorrencias_F, T002E20_A779SerasaCountCheques_F, T002E20_n779SerasaCountCheques_F
               }
               , new Object[] {
               T002E22_A775SerasaCountAcoes_F, T002E22_n775SerasaCountAcoes_F
               }
               , new Object[] {
               T002E24_A776SerasaCountEnderecos_F, T002E24_n776SerasaCountEnderecos_F
               }
               , new Object[] {
               T002E26_A777SerasaCountProtestos_F, T002E26_n777SerasaCountProtestos_F
               }
               , new Object[] {
               T002E28_A778SerasaCountOcorrencias_F, T002E28_n778SerasaCountOcorrencias_F
               }
               , new Object[] {
               T002E30_A779SerasaCountCheques_F, T002E30_n779SerasaCountCheques_F
               }
               , new Object[] {
               T002E31_A170ClienteRazaoSocial, T002E31_n170ClienteRazaoSocial
               }
               , new Object[] {
               T002E32_A662SerasaId
               }
               , new Object[] {
               T002E33_A662SerasaId
               }
               , new Object[] {
               T002E34_A662SerasaId
               }
               , new Object[] {
               }
               , new Object[] {
               T002E36_A662SerasaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002E40_A775SerasaCountAcoes_F, T002E40_n775SerasaCountAcoes_F
               }
               , new Object[] {
               T002E42_A776SerasaCountEnderecos_F, T002E42_n776SerasaCountEnderecos_F
               }
               , new Object[] {
               T002E44_A777SerasaCountProtestos_F, T002E44_n777SerasaCountProtestos_F
               }
               , new Object[] {
               T002E46_A778SerasaCountOcorrencias_F, T002E46_n778SerasaCountOcorrencias_F
               }
               , new Object[] {
               T002E48_A779SerasaCountCheques_F, T002E48_n779SerasaCountCheques_F
               }
               , new Object[] {
               T002E49_A170ClienteRazaoSocial, T002E49_n170ClienteRazaoSocial
               }
               , new Object[] {
               T002E50_A726SerasaOcorrenciasId
               }
               , new Object[] {
               T002E51_A716SerasaEnderecosId
               }
               , new Object[] {
               T002E52_A711SerasaProtestosId
               }
               , new Object[] {
               T002E53_A699SerasaAcoesId
               }
               , new Object[] {
               T002E54_A693SerasaChequesId
               }
               , new Object[] {
               T002E55_A662SerasaId
               }
            }
         );
         AV19Pgmname = "Serasa";
      }

      private short Z685SerasaScore ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A685SerasaScore ;
      private short A775SerasaCountAcoes_F ;
      private short A776SerasaCountEnderecos_F ;
      private short A777SerasaCountProtestos_F ;
      private short A778SerasaCountOcorrencias_F ;
      private short A779SerasaCountCheques_F ;
      private short RcdFound84 ;
      private short Z775SerasaCountAcoes_F ;
      private short Z776SerasaCountEnderecos_F ;
      private short Z777SerasaCountProtestos_F ;
      private short Z778SerasaCountOcorrencias_F ;
      private short Z779SerasaCountCheques_F ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7SerasaId ;
      private int Z662SerasaId ;
      private int Z168ClienteId ;
      private int N168ClienteId ;
      private int A662SerasaId ;
      private int A168ClienteId ;
      private int AV7SerasaId ;
      private int trnEnded ;
      private int edtSerasaId_Enabled ;
      private int edtClienteId_Visible ;
      private int edtClienteId_Enabled ;
      private int edtSerasaNumeroProposta_Enabled ;
      private int edtSerasaPolitica_Enabled ;
      private int edtSerasaCreatedAt_Enabled ;
      private int edtSerasaTipoVenda_Enabled ;
      private int edtSerasaCodTipoVenda_Enabled ;
      private int edtSerasaCodNivelRisco_Enabled ;
      private int edtSerasaTipoRecomendacao_Enabled ;
      private int edtSerasaRecomendacaoVenda_Enabled ;
      private int edtSerasaValorLimiteRecomendado_Enabled ;
      private int edtSerasaFaixaDeRendaEstimada_Enabled ;
      private int edtSerasaMensagemRendaEstimada_Enabled ;
      private int edtSerasaScore_Enabled ;
      private int edtSerasaTaxa_Enabled ;
      private int edtSerasaMensagemScore_Enabled ;
      private int edtSerasaSituacaoCPF_Enabled ;
      private int edtSerasaDataNascimento_Enabled ;
      private int edtSerasaGenero_Enabled ;
      private int edtSerasaNomeMae_Enabled ;
      private int edtSerasaGrafia_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int AV18ComboClienteId ;
      private int edtavComboclienteid_Enabled ;
      private int edtavComboclienteid_Visible ;
      private int AV11Insert_ClienteId ;
      private int Combo_clienteid_Datalistupdateminimumcharacters ;
      private int Combo_clienteid_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV20GXV1 ;
      private int idxLst ;
      private decimal Z664SerasaPolitica ;
      private decimal Z667SerasaCodTipoVenda ;
      private decimal Z668SerasaCodNivelRisco ;
      private decimal Z675SerasaValorLimiteRecomendado ;
      private decimal Z676SerasaFaixaDeRendaEstimada ;
      private decimal Z686SerasaTaxa ;
      private decimal A664SerasaPolitica ;
      private decimal A667SerasaCodTipoVenda ;
      private decimal A668SerasaCodNivelRisco ;
      private decimal A675SerasaValorLimiteRecomendado ;
      private decimal A676SerasaFaixaDeRendaEstimada ;
      private decimal A686SerasaTaxa ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_clienteid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtClienteId_Internalname ;
      private string cmbSerasaCpfRegular_Internalname ;
      private string cmbSerasaRetricaoAtiva_Internalname ;
      private string cmbSerasaProtestoAtivo_Internalname ;
      private string cmbSerasaBaixoComprometimento_Internalname ;
      private string cmbSerasaAnotacoesCompletas_Internalname ;
      private string cmbSerasaConsultasDetalhadas_Internalname ;
      private string cmbSerasaAnotacoesConsultaSPC_Internalname ;
      private string cmbSerasaParticipacaoSocietaria_Internalname ;
      private string cmbSerasaRendaEstimada_Internalname ;
      private string cmbSerasaHistoricoPagamentoPF_Internalname ;
      private string cmbSerasaRecomendaCompleto_Internalname ;
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
      private string edtSerasaId_Internalname ;
      private string TempTags ;
      private string edtSerasaId_Jsonclick ;
      private string divTablesplittedclienteid_Internalname ;
      private string lblTextblockclienteid_Internalname ;
      private string lblTextblockclienteid_Jsonclick ;
      private string Combo_clienteid_Caption ;
      private string Combo_clienteid_Cls ;
      private string Combo_clienteid_Datalistproc ;
      private string Combo_clienteid_Datalistprocparametersprefix ;
      private string Combo_clienteid_Internalname ;
      private string edtClienteId_Jsonclick ;
      private string edtSerasaNumeroProposta_Internalname ;
      private string edtSerasaNumeroProposta_Jsonclick ;
      private string edtSerasaPolitica_Internalname ;
      private string edtSerasaPolitica_Jsonclick ;
      private string edtSerasaCreatedAt_Internalname ;
      private string edtSerasaCreatedAt_Jsonclick ;
      private string edtSerasaTipoVenda_Internalname ;
      private string edtSerasaTipoVenda_Jsonclick ;
      private string edtSerasaCodTipoVenda_Internalname ;
      private string edtSerasaCodTipoVenda_Jsonclick ;
      private string edtSerasaCodNivelRisco_Internalname ;
      private string edtSerasaCodNivelRisco_Jsonclick ;
      private string edtSerasaTipoRecomendacao_Internalname ;
      private string edtSerasaTipoRecomendacao_Jsonclick ;
      private string edtSerasaRecomendacaoVenda_Internalname ;
      private string edtSerasaRecomendacaoVenda_Jsonclick ;
      private string cmbSerasaCpfRegular_Jsonclick ;
      private string cmbSerasaRetricaoAtiva_Jsonclick ;
      private string cmbSerasaProtestoAtivo_Jsonclick ;
      private string cmbSerasaBaixoComprometimento_Jsonclick ;
      private string edtSerasaValorLimiteRecomendado_Internalname ;
      private string edtSerasaValorLimiteRecomendado_Jsonclick ;
      private string edtSerasaFaixaDeRendaEstimada_Internalname ;
      private string edtSerasaFaixaDeRendaEstimada_Jsonclick ;
      private string edtSerasaMensagemRendaEstimada_Internalname ;
      private string cmbSerasaAnotacoesCompletas_Jsonclick ;
      private string cmbSerasaConsultasDetalhadas_Jsonclick ;
      private string cmbSerasaAnotacoesConsultaSPC_Jsonclick ;
      private string cmbSerasaParticipacaoSocietaria_Jsonclick ;
      private string cmbSerasaRendaEstimada_Jsonclick ;
      private string cmbSerasaHistoricoPagamentoPF_Jsonclick ;
      private string cmbSerasaRecomendaCompleto_Jsonclick ;
      private string edtSerasaScore_Internalname ;
      private string edtSerasaScore_Jsonclick ;
      private string edtSerasaTaxa_Internalname ;
      private string edtSerasaTaxa_Jsonclick ;
      private string edtSerasaMensagemScore_Internalname ;
      private string edtSerasaSituacaoCPF_Internalname ;
      private string edtSerasaSituacaoCPF_Jsonclick ;
      private string edtSerasaDataNascimento_Internalname ;
      private string edtSerasaDataNascimento_Jsonclick ;
      private string edtSerasaGenero_Internalname ;
      private string edtSerasaGenero_Jsonclick ;
      private string edtSerasaNomeMae_Internalname ;
      private string edtSerasaNomeMae_Jsonclick ;
      private string edtSerasaGrafia_Internalname ;
      private string edtSerasaGrafia_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_clienteid_Internalname ;
      private string edtavComboclienteid_Internalname ;
      private string edtavComboclienteid_Jsonclick ;
      private string AV19Pgmname ;
      private string Combo_clienteid_Objectcall ;
      private string Combo_clienteid_Class ;
      private string Combo_clienteid_Icontype ;
      private string Combo_clienteid_Icon ;
      private string Combo_clienteid_Tooltip ;
      private string Combo_clienteid_Selectedvalue_set ;
      private string Combo_clienteid_Selectedtext_set ;
      private string Combo_clienteid_Selectedtext_get ;
      private string Combo_clienteid_Gamoauthtoken ;
      private string Combo_clienteid_Ddointernalname ;
      private string Combo_clienteid_Titlecontrolalign ;
      private string Combo_clienteid_Dropdownoptionstype ;
      private string Combo_clienteid_Titlecontrolidtoreplace ;
      private string Combo_clienteid_Datalisttype ;
      private string Combo_clienteid_Datalistfixedvalues ;
      private string Combo_clienteid_Remoteservicesparameters ;
      private string Combo_clienteid_Htmltemplate ;
      private string Combo_clienteid_Multiplevaluestype ;
      private string Combo_clienteid_Loadingdata ;
      private string Combo_clienteid_Noresultsfound ;
      private string Combo_clienteid_Emptyitemtext ;
      private string Combo_clienteid_Onlyselectedvalues ;
      private string Combo_clienteid_Selectalltext ;
      private string Combo_clienteid_Multiplevaluesseparator ;
      private string Combo_clienteid_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode84 ;
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
      private DateTime Z665SerasaCreatedAt ;
      private DateTime A665SerasaCreatedAt ;
      private DateTime i665SerasaCreatedAt ;
      private DateTime Z689SerasaDataNascimento ;
      private DateTime A689SerasaDataNascimento ;
      private bool Z671SerasaCpfRegular ;
      private bool Z672SerasaRetricaoAtiva ;
      private bool Z673SerasaProtestoAtivo ;
      private bool Z674SerasaBaixoComprometimento ;
      private bool Z678SerasaAnotacoesCompletas ;
      private bool Z679SerasaConsultasDetalhadas ;
      private bool Z680SerasaAnotacoesConsultaSPC ;
      private bool Z681SerasaParticipacaoSocietaria ;
      private bool Z682SerasaRendaEstimada ;
      private bool Z683SerasaHistoricoPagamentoPF ;
      private bool Z684SerasaRecomendaCompleto ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n662SerasaId ;
      private bool n168ClienteId ;
      private bool wbErr ;
      private bool A671SerasaCpfRegular ;
      private bool n671SerasaCpfRegular ;
      private bool A672SerasaRetricaoAtiva ;
      private bool n672SerasaRetricaoAtiva ;
      private bool A673SerasaProtestoAtivo ;
      private bool n673SerasaProtestoAtivo ;
      private bool A674SerasaBaixoComprometimento ;
      private bool n674SerasaBaixoComprometimento ;
      private bool A678SerasaAnotacoesCompletas ;
      private bool n678SerasaAnotacoesCompletas ;
      private bool A679SerasaConsultasDetalhadas ;
      private bool n679SerasaConsultasDetalhadas ;
      private bool A680SerasaAnotacoesConsultaSPC ;
      private bool n680SerasaAnotacoesConsultaSPC ;
      private bool A681SerasaParticipacaoSocietaria ;
      private bool n681SerasaParticipacaoSocietaria ;
      private bool A682SerasaRendaEstimada ;
      private bool n682SerasaRendaEstimada ;
      private bool A683SerasaHistoricoPagamentoPF ;
      private bool n683SerasaHistoricoPagamentoPF ;
      private bool A684SerasaRecomendaCompleto ;
      private bool n684SerasaRecomendaCompleto ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n664SerasaPolitica ;
      private bool n667SerasaCodTipoVenda ;
      private bool n668SerasaCodNivelRisco ;
      private bool n675SerasaValorLimiteRecomendado ;
      private bool n676SerasaFaixaDeRendaEstimada ;
      private bool n685SerasaScore ;
      private bool n686SerasaTaxa ;
      private bool n665SerasaCreatedAt ;
      private bool n663SerasaNumeroProposta ;
      private bool n666SerasaTipoVenda ;
      private bool n669SerasaTipoRecomendacao ;
      private bool n670SerasaRecomendacaoVenda ;
      private bool n677SerasaMensagemRendaEstimada ;
      private bool n687SerasaMensagemScore ;
      private bool n688SerasaSituacaoCPF ;
      private bool n689SerasaDataNascimento ;
      private bool n690SerasaGenero ;
      private bool n691SerasaNomeMae ;
      private bool n692SerasaGrafia ;
      private bool n774SerasaJSON ;
      private bool n170ClienteRazaoSocial ;
      private bool n775SerasaCountAcoes_F ;
      private bool n776SerasaCountEnderecos_F ;
      private bool n777SerasaCountProtestos_F ;
      private bool n778SerasaCountOcorrencias_F ;
      private bool n779SerasaCountCheques_F ;
      private bool Combo_clienteid_Enabled ;
      private bool Combo_clienteid_Visible ;
      private bool Combo_clienteid_Allowmultipleselection ;
      private bool Combo_clienteid_Isgriditem ;
      private bool Combo_clienteid_Hasdescription ;
      private bool Combo_clienteid_Includeonlyselectedoption ;
      private bool Combo_clienteid_Includeselectalloption ;
      private bool Combo_clienteid_Emptyitem ;
      private bool Combo_clienteid_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string A774SerasaJSON ;
      private string AV17Combo_DataJson ;
      private string Z774SerasaJSON ;
      private string Z663SerasaNumeroProposta ;
      private string Z666SerasaTipoVenda ;
      private string Z669SerasaTipoRecomendacao ;
      private string Z670SerasaRecomendacaoVenda ;
      private string Z677SerasaMensagemRendaEstimada ;
      private string Z687SerasaMensagemScore ;
      private string Z688SerasaSituacaoCPF ;
      private string Z690SerasaGenero ;
      private string Z691SerasaNomeMae ;
      private string Z692SerasaGrafia ;
      private string A663SerasaNumeroProposta ;
      private string A666SerasaTipoVenda ;
      private string A669SerasaTipoRecomendacao ;
      private string A670SerasaRecomendacaoVenda ;
      private string A677SerasaMensagemRendaEstimada ;
      private string A687SerasaMensagemScore ;
      private string A688SerasaSituacaoCPF ;
      private string A690SerasaGenero ;
      private string A691SerasaNomeMae ;
      private string A692SerasaGrafia ;
      private string A170ClienteRazaoSocial ;
      private string AV15ComboSelectedValue ;
      private string AV16ComboSelectedText ;
      private string Z170ClienteRazaoSocial ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_clienteid ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbSerasaCpfRegular ;
      private GXCombobox cmbSerasaRetricaoAtiva ;
      private GXCombobox cmbSerasaProtestoAtivo ;
      private GXCombobox cmbSerasaBaixoComprometimento ;
      private GXCombobox cmbSerasaAnotacoesCompletas ;
      private GXCombobox cmbSerasaConsultasDetalhadas ;
      private GXCombobox cmbSerasaAnotacoesConsultaSPC ;
      private GXCombobox cmbSerasaParticipacaoSocietaria ;
      private GXCombobox cmbSerasaRendaEstimada ;
      private GXCombobox cmbSerasaHistoricoPagamentoPF ;
      private GXCombobox cmbSerasaRecomendaCompleto ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV14DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13ClienteId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private short[] T002E6_A775SerasaCountAcoes_F ;
      private bool[] T002E6_n775SerasaCountAcoes_F ;
      private short[] T002E8_A776SerasaCountEnderecos_F ;
      private bool[] T002E8_n776SerasaCountEnderecos_F ;
      private short[] T002E10_A777SerasaCountProtestos_F ;
      private bool[] T002E10_n777SerasaCountProtestos_F ;
      private short[] T002E12_A778SerasaCountOcorrencias_F ;
      private bool[] T002E12_n778SerasaCountOcorrencias_F ;
      private short[] T002E14_A779SerasaCountCheques_F ;
      private bool[] T002E14_n779SerasaCountCheques_F ;
      private string[] T002E4_A170ClienteRazaoSocial ;
      private bool[] T002E4_n170ClienteRazaoSocial ;
      private int[] T002E20_A662SerasaId ;
      private bool[] T002E20_n662SerasaId ;
      private DateTime[] T002E20_A665SerasaCreatedAt ;
      private bool[] T002E20_n665SerasaCreatedAt ;
      private string[] T002E20_A170ClienteRazaoSocial ;
      private bool[] T002E20_n170ClienteRazaoSocial ;
      private string[] T002E20_A663SerasaNumeroProposta ;
      private bool[] T002E20_n663SerasaNumeroProposta ;
      private decimal[] T002E20_A664SerasaPolitica ;
      private bool[] T002E20_n664SerasaPolitica ;
      private string[] T002E20_A666SerasaTipoVenda ;
      private bool[] T002E20_n666SerasaTipoVenda ;
      private decimal[] T002E20_A667SerasaCodTipoVenda ;
      private bool[] T002E20_n667SerasaCodTipoVenda ;
      private decimal[] T002E20_A668SerasaCodNivelRisco ;
      private bool[] T002E20_n668SerasaCodNivelRisco ;
      private string[] T002E20_A669SerasaTipoRecomendacao ;
      private bool[] T002E20_n669SerasaTipoRecomendacao ;
      private string[] T002E20_A670SerasaRecomendacaoVenda ;
      private bool[] T002E20_n670SerasaRecomendacaoVenda ;
      private bool[] T002E20_A671SerasaCpfRegular ;
      private bool[] T002E20_n671SerasaCpfRegular ;
      private bool[] T002E20_A672SerasaRetricaoAtiva ;
      private bool[] T002E20_n672SerasaRetricaoAtiva ;
      private bool[] T002E20_A673SerasaProtestoAtivo ;
      private bool[] T002E20_n673SerasaProtestoAtivo ;
      private bool[] T002E20_A674SerasaBaixoComprometimento ;
      private bool[] T002E20_n674SerasaBaixoComprometimento ;
      private decimal[] T002E20_A675SerasaValorLimiteRecomendado ;
      private bool[] T002E20_n675SerasaValorLimiteRecomendado ;
      private decimal[] T002E20_A676SerasaFaixaDeRendaEstimada ;
      private bool[] T002E20_n676SerasaFaixaDeRendaEstimada ;
      private string[] T002E20_A677SerasaMensagemRendaEstimada ;
      private bool[] T002E20_n677SerasaMensagemRendaEstimada ;
      private bool[] T002E20_A678SerasaAnotacoesCompletas ;
      private bool[] T002E20_n678SerasaAnotacoesCompletas ;
      private bool[] T002E20_A679SerasaConsultasDetalhadas ;
      private bool[] T002E20_n679SerasaConsultasDetalhadas ;
      private bool[] T002E20_A680SerasaAnotacoesConsultaSPC ;
      private bool[] T002E20_n680SerasaAnotacoesConsultaSPC ;
      private bool[] T002E20_A681SerasaParticipacaoSocietaria ;
      private bool[] T002E20_n681SerasaParticipacaoSocietaria ;
      private bool[] T002E20_A682SerasaRendaEstimada ;
      private bool[] T002E20_n682SerasaRendaEstimada ;
      private bool[] T002E20_A683SerasaHistoricoPagamentoPF ;
      private bool[] T002E20_n683SerasaHistoricoPagamentoPF ;
      private bool[] T002E20_A684SerasaRecomendaCompleto ;
      private bool[] T002E20_n684SerasaRecomendaCompleto ;
      private short[] T002E20_A685SerasaScore ;
      private bool[] T002E20_n685SerasaScore ;
      private decimal[] T002E20_A686SerasaTaxa ;
      private bool[] T002E20_n686SerasaTaxa ;
      private string[] T002E20_A687SerasaMensagemScore ;
      private bool[] T002E20_n687SerasaMensagemScore ;
      private string[] T002E20_A688SerasaSituacaoCPF ;
      private bool[] T002E20_n688SerasaSituacaoCPF ;
      private DateTime[] T002E20_A689SerasaDataNascimento ;
      private bool[] T002E20_n689SerasaDataNascimento ;
      private string[] T002E20_A690SerasaGenero ;
      private bool[] T002E20_n690SerasaGenero ;
      private string[] T002E20_A691SerasaNomeMae ;
      private bool[] T002E20_n691SerasaNomeMae ;
      private string[] T002E20_A692SerasaGrafia ;
      private bool[] T002E20_n692SerasaGrafia ;
      private string[] T002E20_A774SerasaJSON ;
      private bool[] T002E20_n774SerasaJSON ;
      private int[] T002E20_A168ClienteId ;
      private bool[] T002E20_n168ClienteId ;
      private short[] T002E20_A775SerasaCountAcoes_F ;
      private bool[] T002E20_n775SerasaCountAcoes_F ;
      private short[] T002E20_A776SerasaCountEnderecos_F ;
      private bool[] T002E20_n776SerasaCountEnderecos_F ;
      private short[] T002E20_A777SerasaCountProtestos_F ;
      private bool[] T002E20_n777SerasaCountProtestos_F ;
      private short[] T002E20_A778SerasaCountOcorrencias_F ;
      private bool[] T002E20_n778SerasaCountOcorrencias_F ;
      private short[] T002E20_A779SerasaCountCheques_F ;
      private bool[] T002E20_n779SerasaCountCheques_F ;
      private short[] T002E22_A775SerasaCountAcoes_F ;
      private bool[] T002E22_n775SerasaCountAcoes_F ;
      private short[] T002E24_A776SerasaCountEnderecos_F ;
      private bool[] T002E24_n776SerasaCountEnderecos_F ;
      private short[] T002E26_A777SerasaCountProtestos_F ;
      private bool[] T002E26_n777SerasaCountProtestos_F ;
      private short[] T002E28_A778SerasaCountOcorrencias_F ;
      private bool[] T002E28_n778SerasaCountOcorrencias_F ;
      private short[] T002E30_A779SerasaCountCheques_F ;
      private bool[] T002E30_n779SerasaCountCheques_F ;
      private string[] T002E31_A170ClienteRazaoSocial ;
      private bool[] T002E31_n170ClienteRazaoSocial ;
      private int[] T002E32_A662SerasaId ;
      private bool[] T002E32_n662SerasaId ;
      private int[] T002E3_A662SerasaId ;
      private bool[] T002E3_n662SerasaId ;
      private DateTime[] T002E3_A665SerasaCreatedAt ;
      private bool[] T002E3_n665SerasaCreatedAt ;
      private string[] T002E3_A663SerasaNumeroProposta ;
      private bool[] T002E3_n663SerasaNumeroProposta ;
      private decimal[] T002E3_A664SerasaPolitica ;
      private bool[] T002E3_n664SerasaPolitica ;
      private string[] T002E3_A666SerasaTipoVenda ;
      private bool[] T002E3_n666SerasaTipoVenda ;
      private decimal[] T002E3_A667SerasaCodTipoVenda ;
      private bool[] T002E3_n667SerasaCodTipoVenda ;
      private decimal[] T002E3_A668SerasaCodNivelRisco ;
      private bool[] T002E3_n668SerasaCodNivelRisco ;
      private string[] T002E3_A669SerasaTipoRecomendacao ;
      private bool[] T002E3_n669SerasaTipoRecomendacao ;
      private string[] T002E3_A670SerasaRecomendacaoVenda ;
      private bool[] T002E3_n670SerasaRecomendacaoVenda ;
      private bool[] T002E3_A671SerasaCpfRegular ;
      private bool[] T002E3_n671SerasaCpfRegular ;
      private bool[] T002E3_A672SerasaRetricaoAtiva ;
      private bool[] T002E3_n672SerasaRetricaoAtiva ;
      private bool[] T002E3_A673SerasaProtestoAtivo ;
      private bool[] T002E3_n673SerasaProtestoAtivo ;
      private bool[] T002E3_A674SerasaBaixoComprometimento ;
      private bool[] T002E3_n674SerasaBaixoComprometimento ;
      private decimal[] T002E3_A675SerasaValorLimiteRecomendado ;
      private bool[] T002E3_n675SerasaValorLimiteRecomendado ;
      private decimal[] T002E3_A676SerasaFaixaDeRendaEstimada ;
      private bool[] T002E3_n676SerasaFaixaDeRendaEstimada ;
      private string[] T002E3_A677SerasaMensagemRendaEstimada ;
      private bool[] T002E3_n677SerasaMensagemRendaEstimada ;
      private bool[] T002E3_A678SerasaAnotacoesCompletas ;
      private bool[] T002E3_n678SerasaAnotacoesCompletas ;
      private bool[] T002E3_A679SerasaConsultasDetalhadas ;
      private bool[] T002E3_n679SerasaConsultasDetalhadas ;
      private bool[] T002E3_A680SerasaAnotacoesConsultaSPC ;
      private bool[] T002E3_n680SerasaAnotacoesConsultaSPC ;
      private bool[] T002E3_A681SerasaParticipacaoSocietaria ;
      private bool[] T002E3_n681SerasaParticipacaoSocietaria ;
      private bool[] T002E3_A682SerasaRendaEstimada ;
      private bool[] T002E3_n682SerasaRendaEstimada ;
      private bool[] T002E3_A683SerasaHistoricoPagamentoPF ;
      private bool[] T002E3_n683SerasaHistoricoPagamentoPF ;
      private bool[] T002E3_A684SerasaRecomendaCompleto ;
      private bool[] T002E3_n684SerasaRecomendaCompleto ;
      private short[] T002E3_A685SerasaScore ;
      private bool[] T002E3_n685SerasaScore ;
      private decimal[] T002E3_A686SerasaTaxa ;
      private bool[] T002E3_n686SerasaTaxa ;
      private string[] T002E3_A687SerasaMensagemScore ;
      private bool[] T002E3_n687SerasaMensagemScore ;
      private string[] T002E3_A688SerasaSituacaoCPF ;
      private bool[] T002E3_n688SerasaSituacaoCPF ;
      private DateTime[] T002E3_A689SerasaDataNascimento ;
      private bool[] T002E3_n689SerasaDataNascimento ;
      private string[] T002E3_A690SerasaGenero ;
      private bool[] T002E3_n690SerasaGenero ;
      private string[] T002E3_A691SerasaNomeMae ;
      private bool[] T002E3_n691SerasaNomeMae ;
      private string[] T002E3_A692SerasaGrafia ;
      private bool[] T002E3_n692SerasaGrafia ;
      private string[] T002E3_A774SerasaJSON ;
      private bool[] T002E3_n774SerasaJSON ;
      private int[] T002E3_A168ClienteId ;
      private bool[] T002E3_n168ClienteId ;
      private int[] T002E33_A662SerasaId ;
      private bool[] T002E33_n662SerasaId ;
      private int[] T002E34_A662SerasaId ;
      private bool[] T002E34_n662SerasaId ;
      private int[] T002E2_A662SerasaId ;
      private bool[] T002E2_n662SerasaId ;
      private DateTime[] T002E2_A665SerasaCreatedAt ;
      private bool[] T002E2_n665SerasaCreatedAt ;
      private string[] T002E2_A663SerasaNumeroProposta ;
      private bool[] T002E2_n663SerasaNumeroProposta ;
      private decimal[] T002E2_A664SerasaPolitica ;
      private bool[] T002E2_n664SerasaPolitica ;
      private string[] T002E2_A666SerasaTipoVenda ;
      private bool[] T002E2_n666SerasaTipoVenda ;
      private decimal[] T002E2_A667SerasaCodTipoVenda ;
      private bool[] T002E2_n667SerasaCodTipoVenda ;
      private decimal[] T002E2_A668SerasaCodNivelRisco ;
      private bool[] T002E2_n668SerasaCodNivelRisco ;
      private string[] T002E2_A669SerasaTipoRecomendacao ;
      private bool[] T002E2_n669SerasaTipoRecomendacao ;
      private string[] T002E2_A670SerasaRecomendacaoVenda ;
      private bool[] T002E2_n670SerasaRecomendacaoVenda ;
      private bool[] T002E2_A671SerasaCpfRegular ;
      private bool[] T002E2_n671SerasaCpfRegular ;
      private bool[] T002E2_A672SerasaRetricaoAtiva ;
      private bool[] T002E2_n672SerasaRetricaoAtiva ;
      private bool[] T002E2_A673SerasaProtestoAtivo ;
      private bool[] T002E2_n673SerasaProtestoAtivo ;
      private bool[] T002E2_A674SerasaBaixoComprometimento ;
      private bool[] T002E2_n674SerasaBaixoComprometimento ;
      private decimal[] T002E2_A675SerasaValorLimiteRecomendado ;
      private bool[] T002E2_n675SerasaValorLimiteRecomendado ;
      private decimal[] T002E2_A676SerasaFaixaDeRendaEstimada ;
      private bool[] T002E2_n676SerasaFaixaDeRendaEstimada ;
      private string[] T002E2_A677SerasaMensagemRendaEstimada ;
      private bool[] T002E2_n677SerasaMensagemRendaEstimada ;
      private bool[] T002E2_A678SerasaAnotacoesCompletas ;
      private bool[] T002E2_n678SerasaAnotacoesCompletas ;
      private bool[] T002E2_A679SerasaConsultasDetalhadas ;
      private bool[] T002E2_n679SerasaConsultasDetalhadas ;
      private bool[] T002E2_A680SerasaAnotacoesConsultaSPC ;
      private bool[] T002E2_n680SerasaAnotacoesConsultaSPC ;
      private bool[] T002E2_A681SerasaParticipacaoSocietaria ;
      private bool[] T002E2_n681SerasaParticipacaoSocietaria ;
      private bool[] T002E2_A682SerasaRendaEstimada ;
      private bool[] T002E2_n682SerasaRendaEstimada ;
      private bool[] T002E2_A683SerasaHistoricoPagamentoPF ;
      private bool[] T002E2_n683SerasaHistoricoPagamentoPF ;
      private bool[] T002E2_A684SerasaRecomendaCompleto ;
      private bool[] T002E2_n684SerasaRecomendaCompleto ;
      private short[] T002E2_A685SerasaScore ;
      private bool[] T002E2_n685SerasaScore ;
      private decimal[] T002E2_A686SerasaTaxa ;
      private bool[] T002E2_n686SerasaTaxa ;
      private string[] T002E2_A687SerasaMensagemScore ;
      private bool[] T002E2_n687SerasaMensagemScore ;
      private string[] T002E2_A688SerasaSituacaoCPF ;
      private bool[] T002E2_n688SerasaSituacaoCPF ;
      private DateTime[] T002E2_A689SerasaDataNascimento ;
      private bool[] T002E2_n689SerasaDataNascimento ;
      private string[] T002E2_A690SerasaGenero ;
      private bool[] T002E2_n690SerasaGenero ;
      private string[] T002E2_A691SerasaNomeMae ;
      private bool[] T002E2_n691SerasaNomeMae ;
      private string[] T002E2_A692SerasaGrafia ;
      private bool[] T002E2_n692SerasaGrafia ;
      private string[] T002E2_A774SerasaJSON ;
      private bool[] T002E2_n774SerasaJSON ;
      private int[] T002E2_A168ClienteId ;
      private bool[] T002E2_n168ClienteId ;
      private int[] T002E36_A662SerasaId ;
      private bool[] T002E36_n662SerasaId ;
      private short[] T002E40_A775SerasaCountAcoes_F ;
      private bool[] T002E40_n775SerasaCountAcoes_F ;
      private short[] T002E42_A776SerasaCountEnderecos_F ;
      private bool[] T002E42_n776SerasaCountEnderecos_F ;
      private short[] T002E44_A777SerasaCountProtestos_F ;
      private bool[] T002E44_n777SerasaCountProtestos_F ;
      private short[] T002E46_A778SerasaCountOcorrencias_F ;
      private bool[] T002E46_n778SerasaCountOcorrencias_F ;
      private short[] T002E48_A779SerasaCountCheques_F ;
      private bool[] T002E48_n779SerasaCountCheques_F ;
      private string[] T002E49_A170ClienteRazaoSocial ;
      private bool[] T002E49_n170ClienteRazaoSocial ;
      private int[] T002E50_A726SerasaOcorrenciasId ;
      private int[] T002E51_A716SerasaEnderecosId ;
      private int[] T002E52_A711SerasaProtestosId ;
      private int[] T002E53_A699SerasaAcoesId ;
      private int[] T002E54_A693SerasaChequesId ;
      private int[] T002E55_A662SerasaId ;
      private bool[] T002E55_n662SerasaId ;
   }

   public class serasa__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new UpdateCursor(def[20])
         ,new UpdateCursor(def[21])
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT002E2;
          prmT002E2 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002E3;
          prmT002E3 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002E4;
          prmT002E4 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002E6;
          prmT002E6 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002E8;
          prmT002E8 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002E10;
          prmT002E10 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002E12;
          prmT002E12 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002E14;
          prmT002E14 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002E20;
          prmT002E20 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          string cmdBufferT002E20;
          cmdBufferT002E20=" SELECT TM1.SerasaId, TM1.SerasaCreatedAt, T7.ClienteRazaoSocial, TM1.SerasaNumeroProposta, TM1.SerasaPolitica, TM1.SerasaTipoVenda, TM1.SerasaCodTipoVenda, TM1.SerasaCodNivelRisco, TM1.SerasaTipoRecomendacao, TM1.SerasaRecomendacaoVenda, TM1.SerasaCpfRegular, TM1.SerasaRetricaoAtiva, TM1.SerasaProtestoAtivo, TM1.SerasaBaixoComprometimento, TM1.SerasaValorLimiteRecomendado, TM1.SerasaFaixaDeRendaEstimada, TM1.SerasaMensagemRendaEstimada, TM1.SerasaAnotacoesCompletas, TM1.SerasaConsultasDetalhadas, TM1.SerasaAnotacoesConsultaSPC, TM1.SerasaParticipacaoSocietaria, TM1.SerasaRendaEstimada, TM1.SerasaHistoricoPagamentoPF, TM1.SerasaRecomendaCompleto, TM1.SerasaScore, TM1.SerasaTaxa, TM1.SerasaMensagemScore, TM1.SerasaSituacaoCPF, TM1.SerasaDataNascimento, TM1.SerasaGenero, TM1.SerasaNomeMae, TM1.SerasaGrafia, TM1.SerasaJSON, TM1.ClienteId, COALESCE( T2.SerasaCountAcoes_F, 0) AS SerasaCountAcoes_F, COALESCE( T3.SerasaCountEnderecos_F, 0) AS SerasaCountEnderecos_F, COALESCE( T4.SerasaCountProtestos_F, 0) AS SerasaCountProtestos_F, COALESCE( T5.SerasaCountOcorrencias_F, 0) AS SerasaCountOcorrencias_F, COALESCE( T6.SerasaCountCheques_F, 0) AS SerasaCountCheques_F FROM ((((((Serasa TM1 LEFT JOIN LATERAL (SELECT COUNT(*) AS SerasaCountAcoes_F, SerasaId FROM SerasaAcoes WHERE TM1.SerasaId = SerasaId GROUP BY SerasaId ) T2 ON T2.SerasaId = TM1.SerasaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS SerasaCountEnderecos_F, SerasaId FROM SerasaEnderecos WHERE TM1.SerasaId = SerasaId GROUP BY SerasaId ) T3 ON T3.SerasaId = TM1.SerasaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS SerasaCountProtestos_F, SerasaId FROM SerasaProtestos WHERE TM1.SerasaId = SerasaId GROUP BY SerasaId ) T4 ON T4.SerasaId = TM1.SerasaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS SerasaCountOcorrencias_F, SerasaId FROM SerasaOcorrencias "
          + " WHERE TM1.SerasaId = SerasaId GROUP BY SerasaId ) T5 ON T5.SerasaId = TM1.SerasaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS SerasaCountCheques_F, SerasaId FROM SerasaCheques WHERE TM1.SerasaId = SerasaId GROUP BY SerasaId ) T6 ON T6.SerasaId = TM1.SerasaId) LEFT JOIN Cliente T7 ON T7.ClienteId = TM1.ClienteId) WHERE TM1.SerasaId = :SerasaId ORDER BY TM1.SerasaId" ;
          Object[] prmT002E22;
          prmT002E22 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002E24;
          prmT002E24 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002E26;
          prmT002E26 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002E28;
          prmT002E28 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002E30;
          prmT002E30 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002E31;
          prmT002E31 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002E32;
          prmT002E32 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002E33;
          prmT002E33 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002E34;
          prmT002E34 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002E35;
          prmT002E35 = new Object[] {
          new ParDef("SerasaCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("SerasaNumeroProposta",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaPolitica",GXType.Number,15,2){Nullable=true} ,
          new ParDef("SerasaTipoVenda",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaCodTipoVenda",GXType.Number,15,2){Nullable=true} ,
          new ParDef("SerasaCodNivelRisco",GXType.Number,15,2){Nullable=true} ,
          new ParDef("SerasaTipoRecomendacao",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaRecomendacaoVenda",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SerasaCpfRegular",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaRetricaoAtiva",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaProtestoAtivo",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaBaixoComprometimento",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaValorLimiteRecomendado",GXType.Number,18,2){Nullable=true} ,
          new ParDef("SerasaFaixaDeRendaEstimada",GXType.Number,15,2){Nullable=true} ,
          new ParDef("SerasaMensagemRendaEstimada",GXType.VarChar,250,0){Nullable=true} ,
          new ParDef("SerasaAnotacoesCompletas",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaConsultasDetalhadas",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaAnotacoesConsultaSPC",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaParticipacaoSocietaria",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaRendaEstimada",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaHistoricoPagamentoPF",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaRecomendaCompleto",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaScore",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("SerasaTaxa",GXType.Number,15,2){Nullable=true} ,
          new ParDef("SerasaMensagemScore",GXType.VarChar,250,0){Nullable=true} ,
          new ParDef("SerasaSituacaoCPF",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaDataNascimento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("SerasaGenero",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaNomeMae",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("SerasaGrafia",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("SerasaJSON",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002E36;
          prmT002E36 = new Object[] {
          };
          Object[] prmT002E37;
          prmT002E37 = new Object[] {
          new ParDef("SerasaCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("SerasaNumeroProposta",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaPolitica",GXType.Number,15,2){Nullable=true} ,
          new ParDef("SerasaTipoVenda",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaCodTipoVenda",GXType.Number,15,2){Nullable=true} ,
          new ParDef("SerasaCodNivelRisco",GXType.Number,15,2){Nullable=true} ,
          new ParDef("SerasaTipoRecomendacao",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaRecomendacaoVenda",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SerasaCpfRegular",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaRetricaoAtiva",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaProtestoAtivo",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaBaixoComprometimento",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaValorLimiteRecomendado",GXType.Number,18,2){Nullable=true} ,
          new ParDef("SerasaFaixaDeRendaEstimada",GXType.Number,15,2){Nullable=true} ,
          new ParDef("SerasaMensagemRendaEstimada",GXType.VarChar,250,0){Nullable=true} ,
          new ParDef("SerasaAnotacoesCompletas",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaConsultasDetalhadas",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaAnotacoesConsultaSPC",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaParticipacaoSocietaria",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaRendaEstimada",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaHistoricoPagamentoPF",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaRecomendaCompleto",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SerasaScore",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("SerasaTaxa",GXType.Number,15,2){Nullable=true} ,
          new ParDef("SerasaMensagemScore",GXType.VarChar,250,0){Nullable=true} ,
          new ParDef("SerasaSituacaoCPF",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaDataNascimento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("SerasaGenero",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaNomeMae",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("SerasaGrafia",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("SerasaJSON",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002E38;
          prmT002E38 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002E40;
          prmT002E40 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002E42;
          prmT002E42 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002E44;
          prmT002E44 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002E46;
          prmT002E46 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002E48;
          prmT002E48 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002E49;
          prmT002E49 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002E50;
          prmT002E50 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002E51;
          prmT002E51 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002E52;
          prmT002E52 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002E53;
          prmT002E53 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002E54;
          prmT002E54 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002E55;
          prmT002E55 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T002E2", "SELECT SerasaId, SerasaCreatedAt, SerasaNumeroProposta, SerasaPolitica, SerasaTipoVenda, SerasaCodTipoVenda, SerasaCodNivelRisco, SerasaTipoRecomendacao, SerasaRecomendacaoVenda, SerasaCpfRegular, SerasaRetricaoAtiva, SerasaProtestoAtivo, SerasaBaixoComprometimento, SerasaValorLimiteRecomendado, SerasaFaixaDeRendaEstimada, SerasaMensagemRendaEstimada, SerasaAnotacoesCompletas, SerasaConsultasDetalhadas, SerasaAnotacoesConsultaSPC, SerasaParticipacaoSocietaria, SerasaRendaEstimada, SerasaHistoricoPagamentoPF, SerasaRecomendaCompleto, SerasaScore, SerasaTaxa, SerasaMensagemScore, SerasaSituacaoCPF, SerasaDataNascimento, SerasaGenero, SerasaNomeMae, SerasaGrafia, SerasaJSON, ClienteId FROM Serasa WHERE SerasaId = :SerasaId  FOR UPDATE OF Serasa NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT002E2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002E3", "SELECT SerasaId, SerasaCreatedAt, SerasaNumeroProposta, SerasaPolitica, SerasaTipoVenda, SerasaCodTipoVenda, SerasaCodNivelRisco, SerasaTipoRecomendacao, SerasaRecomendacaoVenda, SerasaCpfRegular, SerasaRetricaoAtiva, SerasaProtestoAtivo, SerasaBaixoComprometimento, SerasaValorLimiteRecomendado, SerasaFaixaDeRendaEstimada, SerasaMensagemRendaEstimada, SerasaAnotacoesCompletas, SerasaConsultasDetalhadas, SerasaAnotacoesConsultaSPC, SerasaParticipacaoSocietaria, SerasaRendaEstimada, SerasaHistoricoPagamentoPF, SerasaRecomendaCompleto, SerasaScore, SerasaTaxa, SerasaMensagemScore, SerasaSituacaoCPF, SerasaDataNascimento, SerasaGenero, SerasaNomeMae, SerasaGrafia, SerasaJSON, ClienteId FROM Serasa WHERE SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002E3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002E4", "SELECT ClienteRazaoSocial FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002E4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002E6", "SELECT COALESCE( T1.SerasaCountAcoes_F, 0) AS SerasaCountAcoes_F FROM (SELECT COUNT(*) AS SerasaCountAcoes_F, SerasaId FROM SerasaAcoes GROUP BY SerasaId ) T1 WHERE T1.SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002E6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002E8", "SELECT COALESCE( T1.SerasaCountEnderecos_F, 0) AS SerasaCountEnderecos_F FROM (SELECT COUNT(*) AS SerasaCountEnderecos_F, SerasaId FROM SerasaEnderecos GROUP BY SerasaId ) T1 WHERE T1.SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002E8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002E10", "SELECT COALESCE( T1.SerasaCountProtestos_F, 0) AS SerasaCountProtestos_F FROM (SELECT COUNT(*) AS SerasaCountProtestos_F, SerasaId FROM SerasaProtestos GROUP BY SerasaId ) T1 WHERE T1.SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002E10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002E12", "SELECT COALESCE( T1.SerasaCountOcorrencias_F, 0) AS SerasaCountOcorrencias_F FROM (SELECT COUNT(*) AS SerasaCountOcorrencias_F, SerasaId FROM SerasaOcorrencias GROUP BY SerasaId ) T1 WHERE T1.SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002E12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002E14", "SELECT COALESCE( T1.SerasaCountCheques_F, 0) AS SerasaCountCheques_F FROM (SELECT COUNT(*) AS SerasaCountCheques_F, SerasaId FROM SerasaCheques GROUP BY SerasaId ) T1 WHERE T1.SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002E14,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002E20", cmdBufferT002E20,true, GxErrorMask.GX_NOMASK, false, this,prmT002E20,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002E22", "SELECT COALESCE( T1.SerasaCountAcoes_F, 0) AS SerasaCountAcoes_F FROM (SELECT COUNT(*) AS SerasaCountAcoes_F, SerasaId FROM SerasaAcoes GROUP BY SerasaId ) T1 WHERE T1.SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002E22,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002E24", "SELECT COALESCE( T1.SerasaCountEnderecos_F, 0) AS SerasaCountEnderecos_F FROM (SELECT COUNT(*) AS SerasaCountEnderecos_F, SerasaId FROM SerasaEnderecos GROUP BY SerasaId ) T1 WHERE T1.SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002E24,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002E26", "SELECT COALESCE( T1.SerasaCountProtestos_F, 0) AS SerasaCountProtestos_F FROM (SELECT COUNT(*) AS SerasaCountProtestos_F, SerasaId FROM SerasaProtestos GROUP BY SerasaId ) T1 WHERE T1.SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002E26,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002E28", "SELECT COALESCE( T1.SerasaCountOcorrencias_F, 0) AS SerasaCountOcorrencias_F FROM (SELECT COUNT(*) AS SerasaCountOcorrencias_F, SerasaId FROM SerasaOcorrencias GROUP BY SerasaId ) T1 WHERE T1.SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002E28,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002E30", "SELECT COALESCE( T1.SerasaCountCheques_F, 0) AS SerasaCountCheques_F FROM (SELECT COUNT(*) AS SerasaCountCheques_F, SerasaId FROM SerasaCheques GROUP BY SerasaId ) T1 WHERE T1.SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002E30,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002E31", "SELECT ClienteRazaoSocial FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002E31,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002E32", "SELECT SerasaId FROM Serasa WHERE SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002E32,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002E33", "SELECT SerasaId FROM Serasa WHERE ( SerasaId > :SerasaId) ORDER BY SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002E33,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002E34", "SELECT SerasaId FROM Serasa WHERE ( SerasaId < :SerasaId) ORDER BY SerasaId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT002E34,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002E35", "SAVEPOINT gxupdate;INSERT INTO Serasa(SerasaCreatedAt, SerasaNumeroProposta, SerasaPolitica, SerasaTipoVenda, SerasaCodTipoVenda, SerasaCodNivelRisco, SerasaTipoRecomendacao, SerasaRecomendacaoVenda, SerasaCpfRegular, SerasaRetricaoAtiva, SerasaProtestoAtivo, SerasaBaixoComprometimento, SerasaValorLimiteRecomendado, SerasaFaixaDeRendaEstimada, SerasaMensagemRendaEstimada, SerasaAnotacoesCompletas, SerasaConsultasDetalhadas, SerasaAnotacoesConsultaSPC, SerasaParticipacaoSocietaria, SerasaRendaEstimada, SerasaHistoricoPagamentoPF, SerasaRecomendaCompleto, SerasaScore, SerasaTaxa, SerasaMensagemScore, SerasaSituacaoCPF, SerasaDataNascimento, SerasaGenero, SerasaNomeMae, SerasaGrafia, SerasaJSON, ClienteId) VALUES(:SerasaCreatedAt, :SerasaNumeroProposta, :SerasaPolitica, :SerasaTipoVenda, :SerasaCodTipoVenda, :SerasaCodNivelRisco, :SerasaTipoRecomendacao, :SerasaRecomendacaoVenda, :SerasaCpfRegular, :SerasaRetricaoAtiva, :SerasaProtestoAtivo, :SerasaBaixoComprometimento, :SerasaValorLimiteRecomendado, :SerasaFaixaDeRendaEstimada, :SerasaMensagemRendaEstimada, :SerasaAnotacoesCompletas, :SerasaConsultasDetalhadas, :SerasaAnotacoesConsultaSPC, :SerasaParticipacaoSocietaria, :SerasaRendaEstimada, :SerasaHistoricoPagamentoPF, :SerasaRecomendaCompleto, :SerasaScore, :SerasaTaxa, :SerasaMensagemScore, :SerasaSituacaoCPF, :SerasaDataNascimento, :SerasaGenero, :SerasaNomeMae, :SerasaGrafia, :SerasaJSON, :ClienteId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT002E35)
             ,new CursorDef("T002E36", "SELECT currval('SerasaId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT002E36,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002E37", "SAVEPOINT gxupdate;UPDATE Serasa SET SerasaCreatedAt=:SerasaCreatedAt, SerasaNumeroProposta=:SerasaNumeroProposta, SerasaPolitica=:SerasaPolitica, SerasaTipoVenda=:SerasaTipoVenda, SerasaCodTipoVenda=:SerasaCodTipoVenda, SerasaCodNivelRisco=:SerasaCodNivelRisco, SerasaTipoRecomendacao=:SerasaTipoRecomendacao, SerasaRecomendacaoVenda=:SerasaRecomendacaoVenda, SerasaCpfRegular=:SerasaCpfRegular, SerasaRetricaoAtiva=:SerasaRetricaoAtiva, SerasaProtestoAtivo=:SerasaProtestoAtivo, SerasaBaixoComprometimento=:SerasaBaixoComprometimento, SerasaValorLimiteRecomendado=:SerasaValorLimiteRecomendado, SerasaFaixaDeRendaEstimada=:SerasaFaixaDeRendaEstimada, SerasaMensagemRendaEstimada=:SerasaMensagemRendaEstimada, SerasaAnotacoesCompletas=:SerasaAnotacoesCompletas, SerasaConsultasDetalhadas=:SerasaConsultasDetalhadas, SerasaAnotacoesConsultaSPC=:SerasaAnotacoesConsultaSPC, SerasaParticipacaoSocietaria=:SerasaParticipacaoSocietaria, SerasaRendaEstimada=:SerasaRendaEstimada, SerasaHistoricoPagamentoPF=:SerasaHistoricoPagamentoPF, SerasaRecomendaCompleto=:SerasaRecomendaCompleto, SerasaScore=:SerasaScore, SerasaTaxa=:SerasaTaxa, SerasaMensagemScore=:SerasaMensagemScore, SerasaSituacaoCPF=:SerasaSituacaoCPF, SerasaDataNascimento=:SerasaDataNascimento, SerasaGenero=:SerasaGenero, SerasaNomeMae=:SerasaNomeMae, SerasaGrafia=:SerasaGrafia, SerasaJSON=:SerasaJSON, ClienteId=:ClienteId  WHERE SerasaId = :SerasaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002E37)
             ,new CursorDef("T002E38", "SAVEPOINT gxupdate;DELETE FROM Serasa  WHERE SerasaId = :SerasaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002E38)
             ,new CursorDef("T002E40", "SELECT COALESCE( T1.SerasaCountAcoes_F, 0) AS SerasaCountAcoes_F FROM (SELECT COUNT(*) AS SerasaCountAcoes_F, SerasaId FROM SerasaAcoes GROUP BY SerasaId ) T1 WHERE T1.SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002E40,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002E42", "SELECT COALESCE( T1.SerasaCountEnderecos_F, 0) AS SerasaCountEnderecos_F FROM (SELECT COUNT(*) AS SerasaCountEnderecos_F, SerasaId FROM SerasaEnderecos GROUP BY SerasaId ) T1 WHERE T1.SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002E42,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002E44", "SELECT COALESCE( T1.SerasaCountProtestos_F, 0) AS SerasaCountProtestos_F FROM (SELECT COUNT(*) AS SerasaCountProtestos_F, SerasaId FROM SerasaProtestos GROUP BY SerasaId ) T1 WHERE T1.SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002E44,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002E46", "SELECT COALESCE( T1.SerasaCountOcorrencias_F, 0) AS SerasaCountOcorrencias_F FROM (SELECT COUNT(*) AS SerasaCountOcorrencias_F, SerasaId FROM SerasaOcorrencias GROUP BY SerasaId ) T1 WHERE T1.SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002E46,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002E48", "SELECT COALESCE( T1.SerasaCountCheques_F, 0) AS SerasaCountCheques_F FROM (SELECT COUNT(*) AS SerasaCountCheques_F, SerasaId FROM SerasaCheques GROUP BY SerasaId ) T1 WHERE T1.SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002E48,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002E49", "SELECT ClienteRazaoSocial FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002E49,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002E50", "SELECT SerasaOcorrenciasId FROM SerasaOcorrencias WHERE SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002E50,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002E51", "SELECT SerasaEnderecosId FROM SerasaEnderecos WHERE SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002E51,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002E52", "SELECT SerasaProtestosId FROM SerasaProtestos WHERE SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002E52,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002E53", "SELECT SerasaAcoesId FROM SerasaAcoes WHERE SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002E53,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002E54", "SELECT SerasaChequesId FROM SerasaCheques WHERE SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002E54,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002E55", "SELECT SerasaId FROM Serasa ORDER BY SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002E55,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((bool[]) buf[17])[0] = rslt.getBool(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((bool[]) buf[19])[0] = rslt.getBool(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((bool[]) buf[21])[0] = rslt.getBool(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((bool[]) buf[23])[0] = rslt.getBool(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((bool[]) buf[31])[0] = rslt.getBool(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((bool[]) buf[33])[0] = rslt.getBool(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((bool[]) buf[35])[0] = rslt.getBool(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((bool[]) buf[37])[0] = rslt.getBool(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((bool[]) buf[39])[0] = rslt.getBool(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((bool[]) buf[41])[0] = rslt.getBool(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((bool[]) buf[43])[0] = rslt.getBool(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((short[]) buf[45])[0] = rslt.getShort(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((decimal[]) buf[47])[0] = rslt.getDecimal(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((string[]) buf[51])[0] = rslt.getVarchar(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((DateTime[]) buf[53])[0] = rslt.getGXDate(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((string[]) buf[55])[0] = rslt.getVarchar(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((string[]) buf[57])[0] = rslt.getVarchar(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((string[]) buf[59])[0] = rslt.getVarchar(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((string[]) buf[61])[0] = rslt.getLongVarchar(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((int[]) buf[63])[0] = rslt.getInt(33);
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((bool[]) buf[17])[0] = rslt.getBool(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((bool[]) buf[19])[0] = rslt.getBool(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((bool[]) buf[21])[0] = rslt.getBool(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((bool[]) buf[23])[0] = rslt.getBool(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((bool[]) buf[31])[0] = rslt.getBool(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((bool[]) buf[33])[0] = rslt.getBool(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((bool[]) buf[35])[0] = rslt.getBool(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((bool[]) buf[37])[0] = rslt.getBool(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((bool[]) buf[39])[0] = rslt.getBool(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((bool[]) buf[41])[0] = rslt.getBool(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((bool[]) buf[43])[0] = rslt.getBool(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((short[]) buf[45])[0] = rslt.getShort(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((decimal[]) buf[47])[0] = rslt.getDecimal(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((string[]) buf[51])[0] = rslt.getVarchar(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((DateTime[]) buf[53])[0] = rslt.getGXDate(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((string[]) buf[55])[0] = rslt.getVarchar(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((string[]) buf[57])[0] = rslt.getVarchar(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((string[]) buf[59])[0] = rslt.getVarchar(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((string[]) buf[61])[0] = rslt.getLongVarchar(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((int[]) buf[63])[0] = rslt.getInt(33);
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((bool[]) buf[19])[0] = rslt.getBool(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((bool[]) buf[21])[0] = rslt.getBool(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((bool[]) buf[23])[0] = rslt.getBool(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((bool[]) buf[25])[0] = rslt.getBool(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((decimal[]) buf[29])[0] = rslt.getDecimal(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((bool[]) buf[33])[0] = rslt.getBool(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((bool[]) buf[35])[0] = rslt.getBool(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((bool[]) buf[37])[0] = rslt.getBool(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((bool[]) buf[39])[0] = rslt.getBool(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((bool[]) buf[41])[0] = rslt.getBool(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((bool[]) buf[43])[0] = rslt.getBool(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((bool[]) buf[45])[0] = rslt.getBool(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((short[]) buf[47])[0] = rslt.getShort(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((decimal[]) buf[49])[0] = rslt.getDecimal(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((string[]) buf[51])[0] = rslt.getVarchar(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((string[]) buf[53])[0] = rslt.getVarchar(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((DateTime[]) buf[55])[0] = rslt.getGXDate(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((string[]) buf[57])[0] = rslt.getVarchar(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((string[]) buf[59])[0] = rslt.getVarchar(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((string[]) buf[61])[0] = rslt.getVarchar(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((string[]) buf[63])[0] = rslt.getLongVarchar(33);
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                ((int[]) buf[65])[0] = rslt.getInt(34);
                ((bool[]) buf[66])[0] = rslt.wasNull(34);
                ((short[]) buf[67])[0] = rslt.getShort(35);
                ((bool[]) buf[68])[0] = rslt.wasNull(35);
                ((short[]) buf[69])[0] = rslt.getShort(36);
                ((bool[]) buf[70])[0] = rslt.wasNull(36);
                ((short[]) buf[71])[0] = rslt.getShort(37);
                ((bool[]) buf[72])[0] = rslt.wasNull(37);
                ((short[]) buf[73])[0] = rslt.getShort(38);
                ((bool[]) buf[74])[0] = rslt.wasNull(38);
                ((short[]) buf[75])[0] = rslt.getShort(39);
                ((bool[]) buf[76])[0] = rslt.wasNull(39);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 16 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 17 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 19 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 22 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 23 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 24 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 25 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 26 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 27 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 28 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 29 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 31 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 32 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 33 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
