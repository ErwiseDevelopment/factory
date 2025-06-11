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
   public class propostac : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_25") == 0 )
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
            gxLoad_25( A323PropostaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_26") == 0 )
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
            gxLoad_26( A323PropostaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_22") == 0 )
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
            gxLoad_22( A376ProcedimentosMedicosId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_23") == 0 )
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
            gxLoad_23( A328PropostaCratedBy) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_21") == 0 )
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
            gxLoad_21( A227ContratoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_24") == 0 )
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
            gxLoad_24( A504PropostaPacienteClienteId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "propostac")), "propostac") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "propostac")))) ;
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
         Form.Meta.addItem("description", "Propostas", 0) ;
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

      public propostac( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public propostac( IGxContext context )
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmastercli", "GeneXus.Programs.wwpbaseobjects.workwithplusmastercli", new Object[] {context});
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
         GxWebStd.gx_single_line_edit( context, edtPropostaTitulo_Internalname, A324PropostaTitulo, StringUtil.RTrim( context.localUtil.Format( A324PropostaTitulo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaTitulo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPropostaTitulo_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PropostaC.htm");
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
         GxWebStd.gx_single_line_edit( context, edtPropostaDescricao_Internalname, A325PropostaDescricao, StringUtil.RTrim( context.localUtil.Format( A325PropostaDescricao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaDescricao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPropostaDescricao_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PropostaC.htm");
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
         GxWebStd.gx_single_line_edit( context, edtPropostaValor_Internalname, ((Convert.ToDecimal(0)==A326PropostaValor)&&IsIns( )||n326PropostaValor ? "" : StringUtil.LTrim( StringUtil.NToC( A326PropostaValor, 18, 2, ",", ""))), ((Convert.ToDecimal(0)==A326PropostaValor)&&IsIns( )||n326PropostaValor ? "" : StringUtil.LTrim( ((edtPropostaValor_Enabled!=0) ? context.localUtil.Format( A326PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A326PropostaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaValor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPropostaValor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_PropostaC.htm");
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
         GxWebStd.gx_single_line_edit( context, edtPropostaCreatedAt_Internalname, context.localUtil.TToC( A327PropostaCreatedAt, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A327PropostaCreatedAt, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaCreatedAt_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPropostaCreatedAt_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_PropostaC.htm");
         GxWebStd.gx_bitmap( context, edtPropostaCreatedAt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPropostaCreatedAt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_PropostaC.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblockpropostacratedby_Internalname, "Crated By", "", "", lblTextblockpropostacratedby_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_PropostaC.htm");
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
         GxWebStd.gx_single_line_edit( context, edtPropostaCratedBy_Internalname, ((0==A328PropostaCratedBy)&&IsIns( )||n328PropostaCratedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A328PropostaCratedBy), 4, 0, ",", ""))), ((0==A328PropostaCratedBy)&&IsIns( )||n328PropostaCratedBy ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A328PropostaCratedBy), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaCratedBy_Jsonclick, 0, "Attribute", "", "", "", "", edtPropostaCratedBy_Visible, edtPropostaCratedBy_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_PropostaC.htm");
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
         GxWebStd.gx_combobox_ctrl1( context, cmbPropostaStatus, cmbPropostaStatus_Internalname, StringUtil.RTrim( A329PropostaStatus), 1, cmbPropostaStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbPropostaStatus.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "", true, 0, "HLP_PropostaC.htm");
         cmbPropostaStatus.CurrentValue = StringUtil.RTrim( A329PropostaStatus);
         AssignProp("", false, cmbPropostaStatus_Internalname, "Values", (string)(cmbPropostaStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedcontratoid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockcontratoid_Internalname, "Contrato", "", "", lblTextblockcontratoid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_PropostaC.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_contratoid.SetProperty("Caption", Combo_contratoid_Caption);
         ucCombo_contratoid.SetProperty("Cls", Combo_contratoid_Cls);
         ucCombo_contratoid.SetProperty("DataListProc", Combo_contratoid_Datalistproc);
         ucCombo_contratoid.SetProperty("DataListProcParametersPrefix", Combo_contratoid_Datalistprocparametersprefix);
         ucCombo_contratoid.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
         ucCombo_contratoid.SetProperty("DropDownOptionsData", AV21ContratoId_Data);
         ucCombo_contratoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_contratoid_Internalname, "COMBO_CONTRATOIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtContratoId_Internalname, "Contrato Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtContratoId_Internalname, ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ",", ""))), ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A227ContratoId), "ZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtContratoId_Jsonclick, 0, "Attribute", "", "", "", "", edtContratoId_Visible, edtContratoId_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_PropostaC.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPropostaQuantidadeAprovadores_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPropostaQuantidadeAprovadores_Internalname, "Quantidade Aprovadores", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPropostaQuantidadeAprovadores_Internalname, ((0==A330PropostaQuantidadeAprovadores)&&IsIns( )||n330PropostaQuantidadeAprovadores ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A330PropostaQuantidadeAprovadores), 4, 0, ",", ""))), ((0==A330PropostaQuantidadeAprovadores)&&IsIns( )||n330PropostaQuantidadeAprovadores ? "" : StringUtil.LTrim( ((edtPropostaQuantidadeAprovadores_Enabled!=0) ? context.localUtil.Format( (decimal)(A330PropostaQuantidadeAprovadores), "ZZZ9") : context.localUtil.Format( (decimal)(A330PropostaQuantidadeAprovadores), "ZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaQuantidadeAprovadores_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPropostaQuantidadeAprovadores_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_PropostaC.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblockprocedimentosmedicosid_Internalname, "Procedimentos Medicos", "", "", lblTextblockprocedimentosmedicosid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_PropostaC.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProcedimentosMedicosId_Internalname, ((0==A376ProcedimentosMedicosId)&&IsIns( )||n376ProcedimentosMedicosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ProcedimentosMedicosId), 9, 0, ",", ""))), ((0==A376ProcedimentosMedicosId)&&IsIns( )||n376ProcedimentosMedicosId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A376ProcedimentosMedicosId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,80);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProcedimentosMedicosId_Jsonclick, 0, "Attribute", "", "", "", "", edtProcedimentosMedicosId_Visible, edtProcedimentosMedicosId_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_PropostaC.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPropostaReprovacoesPermitidas_Internalname, ((0==A345PropostaReprovacoesPermitidas)&&IsIns( )||n345PropostaReprovacoesPermitidas ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A345PropostaReprovacoesPermitidas), 4, 0, ",", ""))), ((0==A345PropostaReprovacoesPermitidas)&&IsIns( )||n345PropostaReprovacoesPermitidas ? "" : StringUtil.LTrim( ((edtPropostaReprovacoesPermitidas_Enabled!=0) ? context.localUtil.Format( (decimal)(A345PropostaReprovacoesPermitidas), "ZZZ9") : context.localUtil.Format( (decimal)(A345PropostaReprovacoesPermitidas), "ZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,85);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaReprovacoesPermitidas_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPropostaReprovacoesPermitidas_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_PropostaC.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPropostaAprovacoes_F_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A341PropostaAprovacoes_F), 4, 0, ",", "")), StringUtil.LTrim( ((edtPropostaAprovacoes_F_Enabled!=0) ? context.localUtil.Format( (decimal)(A341PropostaAprovacoes_F), "ZZZ9") : context.localUtil.Format( (decimal)(A341PropostaAprovacoes_F), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,90);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaAprovacoes_F_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPropostaAprovacoes_F_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_PropostaC.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPropostaReprovacoes_F_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A342PropostaReprovacoes_F), 4, 0, ",", "")), StringUtil.LTrim( ((edtPropostaReprovacoes_F_Enabled!=0) ? context.localUtil.Format( (decimal)(A342PropostaReprovacoes_F), "ZZZ9") : context.localUtil.Format( (decimal)(A342PropostaReprovacoes_F), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,95);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaReprovacoes_F_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPropostaReprovacoes_F_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_PropostaC.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPropostaAprovacoesRestantes_F_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A343PropostaAprovacoesRestantes_F), 4, 0, ",", "")), StringUtil.LTrim( ((edtPropostaAprovacoesRestantes_F_Enabled!=0) ? context.localUtil.Format( (decimal)(A343PropostaAprovacoesRestantes_F), "ZZZ9") : context.localUtil.Format( (decimal)(A343PropostaAprovacoesRestantes_F), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,100);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaAprovacoesRestantes_F_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPropostaAprovacoesRestantes_F_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_PropostaC.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_PropostaC.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_PropostaC.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_PropostaC.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombopropostacratedby_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ComboPropostaCratedBy), 4, 0, ",", "")), StringUtil.LTrim( ((edtavCombopropostacratedby_Enabled!=0) ? context.localUtil.Format( (decimal)(AV19ComboPropostaCratedBy), "ZZZ9") : context.localUtil.Format( (decimal)(AV19ComboPropostaCratedBy), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,114);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombopropostacratedby_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombopropostacratedby_Visible, edtavCombopropostacratedby_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_PropostaC.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_contratoid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombocontratoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22ComboContratoId), 6, 0, ",", "")), StringUtil.LTrim( ((edtavCombocontratoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV22ComboContratoId), "ZZZZZ9") : context.localUtil.Format( (decimal)(AV22ComboContratoId), "ZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,116);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombocontratoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombocontratoid_Visible, edtavCombocontratoid_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_PropostaC.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_procedimentosmedicosid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboprocedimentosmedicosid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV28ComboProcedimentosMedicosId), 9, 0, ",", "")), StringUtil.LTrim( ((edtavComboprocedimentosmedicosid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV28ComboProcedimentosMedicosId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV28ComboProcedimentosMedicosId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,118);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboprocedimentosmedicosid_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboprocedimentosmedicosid_Visible, edtavComboprocedimentosmedicosid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_PropostaC.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPropostaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ",", "")), StringUtil.LTrim( ((edtPropostaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A323PropostaId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A323PropostaId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,119);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaId_Jsonclick, 0, "Attribute", "", "", "", "", edtPropostaId_Visible, edtPropostaId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_PropostaC.htm");
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
         E111L2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV15DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vPROPOSTACRATEDBY_DATA"), AV14PropostaCratedBy_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vCONTRATOID_DATA"), AV21ContratoId_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vPROCEDIMENTOSMEDICOSID_DATA"), AV27ProcedimentosMedicosId_Data);
               /* Read saved values. */
               Z323PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z323PropostaId"), ",", "."), 18, MidpointRounding.ToEven));
               Z327PropostaCreatedAt = context.localUtil.CToT( cgiGet( "Z327PropostaCreatedAt"), 0);
               n327PropostaCreatedAt = ((DateTime.MinValue==A327PropostaCreatedAt) ? true : false);
               Z324PropostaTitulo = cgiGet( "Z324PropostaTitulo");
               n324PropostaTitulo = (String.IsNullOrEmpty(StringUtil.RTrim( A324PropostaTitulo)) ? true : false);
               Z325PropostaDescricao = cgiGet( "Z325PropostaDescricao");
               n325PropostaDescricao = (String.IsNullOrEmpty(StringUtil.RTrim( A325PropostaDescricao)) ? true : false);
               Z326PropostaValor = context.localUtil.CToN( cgiGet( "Z326PropostaValor"), ",", ".");
               n326PropostaValor = ((Convert.ToDecimal(0)==A326PropostaValor) ? true : false);
               Z329PropostaStatus = cgiGet( "Z329PropostaStatus");
               n329PropostaStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A329PropostaStatus)) ? true : false);
               Z330PropostaQuantidadeAprovadores = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z330PropostaQuantidadeAprovadores"), ",", "."), 18, MidpointRounding.ToEven));
               n330PropostaQuantidadeAprovadores = ((0==A330PropostaQuantidadeAprovadores) ? true : false);
               Z345PropostaReprovacoesPermitidas = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z345PropostaReprovacoesPermitidas"), ",", "."), 18, MidpointRounding.ToEven));
               n345PropostaReprovacoesPermitidas = ((0==A345PropostaReprovacoesPermitidas) ? true : false);
               Z227ContratoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z227ContratoId"), ",", "."), 18, MidpointRounding.ToEven));
               n227ContratoId = ((0==A227ContratoId) ? true : false);
               Z376ProcedimentosMedicosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z376ProcedimentosMedicosId"), ",", "."), 18, MidpointRounding.ToEven));
               n376ProcedimentosMedicosId = ((0==A376ProcedimentosMedicosId) ? true : false);
               Z328PropostaCratedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z328PropostaCratedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n328PropostaCratedBy = ((0==A328PropostaCratedBy) ? true : false);
               Z504PropostaPacienteClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z504PropostaPacienteClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n504PropostaPacienteClienteId = ((0==A504PropostaPacienteClienteId) ? true : false);
               A504PropostaPacienteClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z504PropostaPacienteClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n504PropostaPacienteClienteId = false;
               n504PropostaPacienteClienteId = ((0==A504PropostaPacienteClienteId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N376ProcedimentosMedicosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N376ProcedimentosMedicosId"), ",", "."), 18, MidpointRounding.ToEven));
               n376ProcedimentosMedicosId = ((0==A376ProcedimentosMedicosId) ? true : false);
               N328PropostaCratedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N328PropostaCratedBy"), ",", "."), 18, MidpointRounding.ToEven));
               n328PropostaCratedBy = ((0==A328PropostaCratedBy) ? true : false);
               N227ContratoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N227ContratoId"), ",", "."), 18, MidpointRounding.ToEven));
               n227ContratoId = ((0==A227ContratoId) ? true : false);
               N504PropostaPacienteClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N504PropostaPacienteClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n504PropostaPacienteClienteId = ((0==A504PropostaPacienteClienteId) ? true : false);
               AV7PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vPROPOSTAID"), ",", "."), 18, MidpointRounding.ToEven));
               AV24Insert_ProcedimentosMedicosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PROCEDIMENTOSMEDICOSID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV24Insert_ProcedimentosMedicosId", StringUtil.LTrimStr( (decimal)(AV24Insert_ProcedimentosMedicosId), 9, 0));
               AV11Insert_PropostaCratedBy = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PROPOSTACRATEDBY"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11Insert_PropostaCratedBy", StringUtil.LTrimStr( (decimal)(AV11Insert_PropostaCratedBy), 4, 0));
               AV12Insert_ContratoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CONTRATOID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12Insert_ContratoId", StringUtil.LTrimStr( (decimal)(AV12Insert_ContratoId), 6, 0));
               AV29Insert_PropostaPacienteClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PROPOSTAPACIENTECLIENTEID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV29Insert_PropostaPacienteClienteId", StringUtil.LTrimStr( (decimal)(AV29Insert_PropostaPacienteClienteId), 9, 0));
               A504PropostaPacienteClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROPOSTAPACIENTECLIENTEID"), ",", "."), 18, MidpointRounding.ToEven));
               n504PropostaPacienteClienteId = ((0==A504PropostaPacienteClienteId) ? true : false);
               A228ContratoNome = cgiGet( "CONTRATONOME");
               n228ContratoNome = false;
               A505PropostaPacienteClienteRazaoSocial = cgiGet( "PROPOSTAPACIENTECLIENTERAZAOSOCIAL");
               n505PropostaPacienteClienteRazaoSocial = false;
               AV30Pgmname = cgiGet( "vPGMNAME");
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
               Combo_contratoid_Objectcall = cgiGet( "COMBO_CONTRATOID_Objectcall");
               Combo_contratoid_Class = cgiGet( "COMBO_CONTRATOID_Class");
               Combo_contratoid_Icontype = cgiGet( "COMBO_CONTRATOID_Icontype");
               Combo_contratoid_Icon = cgiGet( "COMBO_CONTRATOID_Icon");
               Combo_contratoid_Caption = cgiGet( "COMBO_CONTRATOID_Caption");
               Combo_contratoid_Tooltip = cgiGet( "COMBO_CONTRATOID_Tooltip");
               Combo_contratoid_Cls = cgiGet( "COMBO_CONTRATOID_Cls");
               Combo_contratoid_Selectedvalue_set = cgiGet( "COMBO_CONTRATOID_Selectedvalue_set");
               Combo_contratoid_Selectedvalue_get = cgiGet( "COMBO_CONTRATOID_Selectedvalue_get");
               Combo_contratoid_Selectedtext_set = cgiGet( "COMBO_CONTRATOID_Selectedtext_set");
               Combo_contratoid_Selectedtext_get = cgiGet( "COMBO_CONTRATOID_Selectedtext_get");
               Combo_contratoid_Gamoauthtoken = cgiGet( "COMBO_CONTRATOID_Gamoauthtoken");
               Combo_contratoid_Ddointernalname = cgiGet( "COMBO_CONTRATOID_Ddointernalname");
               Combo_contratoid_Titlecontrolalign = cgiGet( "COMBO_CONTRATOID_Titlecontrolalign");
               Combo_contratoid_Dropdownoptionstype = cgiGet( "COMBO_CONTRATOID_Dropdownoptionstype");
               Combo_contratoid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_CONTRATOID_Enabled"));
               Combo_contratoid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_CONTRATOID_Visible"));
               Combo_contratoid_Titlecontrolidtoreplace = cgiGet( "COMBO_CONTRATOID_Titlecontrolidtoreplace");
               Combo_contratoid_Datalisttype = cgiGet( "COMBO_CONTRATOID_Datalisttype");
               Combo_contratoid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_CONTRATOID_Allowmultipleselection"));
               Combo_contratoid_Datalistfixedvalues = cgiGet( "COMBO_CONTRATOID_Datalistfixedvalues");
               Combo_contratoid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_CONTRATOID_Isgriditem"));
               Combo_contratoid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_CONTRATOID_Hasdescription"));
               Combo_contratoid_Datalistproc = cgiGet( "COMBO_CONTRATOID_Datalistproc");
               Combo_contratoid_Datalistprocparametersprefix = cgiGet( "COMBO_CONTRATOID_Datalistprocparametersprefix");
               Combo_contratoid_Remoteservicesparameters = cgiGet( "COMBO_CONTRATOID_Remoteservicesparameters");
               Combo_contratoid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_CONTRATOID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_contratoid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_CONTRATOID_Includeonlyselectedoption"));
               Combo_contratoid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_CONTRATOID_Includeselectalloption"));
               Combo_contratoid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_CONTRATOID_Emptyitem"));
               Combo_contratoid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_CONTRATOID_Includeaddnewoption"));
               Combo_contratoid_Htmltemplate = cgiGet( "COMBO_CONTRATOID_Htmltemplate");
               Combo_contratoid_Multiplevaluestype = cgiGet( "COMBO_CONTRATOID_Multiplevaluestype");
               Combo_contratoid_Loadingdata = cgiGet( "COMBO_CONTRATOID_Loadingdata");
               Combo_contratoid_Noresultsfound = cgiGet( "COMBO_CONTRATOID_Noresultsfound");
               Combo_contratoid_Emptyitemtext = cgiGet( "COMBO_CONTRATOID_Emptyitemtext");
               Combo_contratoid_Onlyselectedvalues = cgiGet( "COMBO_CONTRATOID_Onlyselectedvalues");
               Combo_contratoid_Selectalltext = cgiGet( "COMBO_CONTRATOID_Selectalltext");
               Combo_contratoid_Multiplevaluesseparator = cgiGet( "COMBO_CONTRATOID_Multiplevaluesseparator");
               Combo_contratoid_Addnewoptiontext = cgiGet( "COMBO_CONTRATOID_Addnewoptiontext");
               Combo_contratoid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_CONTRATOID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
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
               n227ContratoId = ((StringUtil.StrCmp(cgiGet( edtContratoId_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtContratoId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtContratoId_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONTRATOID");
                  AnyError = 1;
                  GX_FocusControl = edtContratoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A227ContratoId = 0;
                  n227ContratoId = false;
                  AssignAttri("", false, "A227ContratoId", (n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
               }
               else
               {
                  A227ContratoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtContratoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A227ContratoId", (n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
               }
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
               AV22ComboContratoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCombocontratoid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV22ComboContratoId", StringUtil.LTrimStr( (decimal)(AV22ComboContratoId), 6, 0));
               AV28ComboProcedimentosMedicosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavComboprocedimentosmedicosid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV28ComboProcedimentosMedicosId", StringUtil.LTrimStr( (decimal)(AV28ComboProcedimentosMedicosId), 9, 0));
               A323PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n323PropostaId = false;
               AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"PropostaC");
               A323PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n323PropostaId = false;
               AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
               forbiddenHiddens.Add("PropostaId", context.localUtil.Format( (decimal)(A323PropostaId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_ProcedimentosMedicosId", context.localUtil.Format( (decimal)(AV24Insert_ProcedimentosMedicosId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_PropostaCratedBy", context.localUtil.Format( (decimal)(AV11Insert_PropostaCratedBy), "ZZZ9"));
               forbiddenHiddens.Add("Insert_ContratoId", context.localUtil.Format( (decimal)(AV12Insert_ContratoId), "ZZZZZ9"));
               forbiddenHiddens.Add("Insert_PropostaPacienteClienteId", context.localUtil.Format( (decimal)(AV29Insert_PropostaPacienteClienteId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A323PropostaId != Z323PropostaId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("propostac:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                           CONFIRM_1L0( ) ;
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
                           E111L2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121L2 ();
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
            E121L2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1L49( ) ;
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
            DisableAttributes1L49( ) ;
         }
         AssignProp("", false, edtavCombopropostacratedby_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombopropostacratedby_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombocontratoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocontratoid_Enabled), 5, 0), true);
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

      protected void CONFIRM_1L0( )
      {
         BeforeValidate1L49( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1L49( ) ;
            }
            else
            {
               CheckExtendedTable1L49( ) ;
               CloseExtendedTableCursors1L49( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption1L0( )
      {
      }

      protected void E111L2( )
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
         edtContratoId_Visible = 0;
         AssignProp("", false, edtContratoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtContratoId_Visible), 5, 0), true);
         AV22ComboContratoId = 0;
         AssignAttri("", false, "AV22ComboContratoId", StringUtil.LTrimStr( (decimal)(AV22ComboContratoId), 6, 0));
         edtavCombocontratoid_Visible = 0;
         AssignProp("", false, edtavCombocontratoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombocontratoid_Visible), 5, 0), true);
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
         /* Execute user subroutine: 'LOADCOMBOCONTRATOID' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOPROCEDIMENTOSMEDICOSID' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV30Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV31GXV1 = 1;
            AssignAttri("", false, "AV31GXV1", StringUtil.LTrimStr( (decimal)(AV31GXV1), 8, 0));
            while ( AV31GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV31GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "ProcedimentosMedicosId") == 0 )
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
                     new propostacloaddvcombo(context ).execute(  "ProcedimentosMedicosId",  "GET",  false,  AV7PropostaId,  AV13TrnContextAtt.gxTpr_Attributevalue, out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
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
                     new propostacloaddvcombo(context ).execute(  "PropostaCratedBy",  "GET",  false,  AV7PropostaId,  AV13TrnContextAtt.gxTpr_Attributevalue, out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
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
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "ContratoId") == 0 )
               {
                  AV12Insert_ContratoId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_ContratoId", StringUtil.LTrimStr( (decimal)(AV12Insert_ContratoId), 6, 0));
                  if ( ! (0==AV12Insert_ContratoId) )
                  {
                     AV22ComboContratoId = AV12Insert_ContratoId;
                     AssignAttri("", false, "AV22ComboContratoId", StringUtil.LTrimStr( (decimal)(AV22ComboContratoId), 6, 0));
                     Combo_contratoid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV22ComboContratoId), 6, 0));
                     ucCombo_contratoid.SendProperty(context, "", false, Combo_contratoid_Internalname, "SelectedValue_set", Combo_contratoid_Selectedvalue_set);
                     GXt_char2 = AV18Combo_DataJson;
                     new propostacloaddvcombo(context ).execute(  "ContratoId",  "GET",  false,  AV7PropostaId,  AV13TrnContextAtt.gxTpr_Attributevalue, out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
                     AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
                     AV18Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
                     Combo_contratoid_Selectedtext_set = AV17ComboSelectedText;
                     ucCombo_contratoid.SendProperty(context, "", false, Combo_contratoid_Internalname, "SelectedText_set", Combo_contratoid_Selectedtext_set);
                     Combo_contratoid_Enabled = false;
                     ucCombo_contratoid.SendProperty(context, "", false, Combo_contratoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_contratoid_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "PropostaPacienteClienteId") == 0 )
               {
                  AV29Insert_PropostaPacienteClienteId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV29Insert_PropostaPacienteClienteId", StringUtil.LTrimStr( (decimal)(AV29Insert_PropostaPacienteClienteId), 9, 0));
               }
               AV31GXV1 = (int)(AV31GXV1+1);
               AssignAttri("", false, "AV31GXV1", StringUtil.LTrimStr( (decimal)(AV31GXV1), 8, 0));
            }
         }
         edtPropostaId_Visible = 0;
         AssignProp("", false, edtPropostaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPropostaId_Visible), 5, 0), true);
      }

      protected void E121L2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("propostacww") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S132( )
      {
         /* 'LOADCOMBOPROCEDIMENTOSMEDICOSID' Routine */
         returnInSub = false;
         GXt_char2 = AV18Combo_DataJson;
         new propostacloaddvcombo(context ).execute(  "ProcedimentosMedicosId",  Gx_mode,  false,  AV7PropostaId,  "", out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
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

      protected void S122( )
      {
         /* 'LOADCOMBOCONTRATOID' Routine */
         returnInSub = false;
         GXt_char2 = AV18Combo_DataJson;
         new propostacloaddvcombo(context ).execute(  "ContratoId",  Gx_mode,  false,  AV7PropostaId,  "", out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
         AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
         AV18Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
         Combo_contratoid_Selectedvalue_set = AV16ComboSelectedValue;
         ucCombo_contratoid.SendProperty(context, "", false, Combo_contratoid_Internalname, "SelectedValue_set", Combo_contratoid_Selectedvalue_set);
         Combo_contratoid_Selectedtext_set = AV17ComboSelectedText;
         ucCombo_contratoid.SendProperty(context, "", false, Combo_contratoid_Internalname, "SelectedText_set", Combo_contratoid_Selectedtext_set);
         AV22ComboContratoId = (int)(Math.Round(NumberUtil.Val( AV16ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV22ComboContratoId", StringUtil.LTrimStr( (decimal)(AV22ComboContratoId), 6, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_contratoid_Enabled = false;
            ucCombo_contratoid.SendProperty(context, "", false, Combo_contratoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_contratoid_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOPROPOSTACRATEDBY' Routine */
         returnInSub = false;
         GXt_char2 = AV18Combo_DataJson;
         new propostacloaddvcombo(context ).execute(  "PropostaCratedBy",  Gx_mode,  false,  AV7PropostaId,  "", out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
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

      protected void ZM1L49( short GX_JID )
      {
         if ( ( GX_JID == 20 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z327PropostaCreatedAt = T001L3_A327PropostaCreatedAt[0];
               Z324PropostaTitulo = T001L3_A324PropostaTitulo[0];
               Z325PropostaDescricao = T001L3_A325PropostaDescricao[0];
               Z326PropostaValor = T001L3_A326PropostaValor[0];
               Z329PropostaStatus = T001L3_A329PropostaStatus[0];
               Z330PropostaQuantidadeAprovadores = T001L3_A330PropostaQuantidadeAprovadores[0];
               Z345PropostaReprovacoesPermitidas = T001L3_A345PropostaReprovacoesPermitidas[0];
               Z227ContratoId = T001L3_A227ContratoId[0];
               Z376ProcedimentosMedicosId = T001L3_A376ProcedimentosMedicosId[0];
               Z328PropostaCratedBy = T001L3_A328PropostaCratedBy[0];
               Z504PropostaPacienteClienteId = T001L3_A504PropostaPacienteClienteId[0];
            }
            else
            {
               Z327PropostaCreatedAt = A327PropostaCreatedAt;
               Z324PropostaTitulo = A324PropostaTitulo;
               Z325PropostaDescricao = A325PropostaDescricao;
               Z326PropostaValor = A326PropostaValor;
               Z329PropostaStatus = A329PropostaStatus;
               Z330PropostaQuantidadeAprovadores = A330PropostaQuantidadeAprovadores;
               Z345PropostaReprovacoesPermitidas = A345PropostaReprovacoesPermitidas;
               Z227ContratoId = A227ContratoId;
               Z376ProcedimentosMedicosId = A376ProcedimentosMedicosId;
               Z328PropostaCratedBy = A328PropostaCratedBy;
               Z504PropostaPacienteClienteId = A504PropostaPacienteClienteId;
            }
         }
         if ( GX_JID == -20 )
         {
            Z323PropostaId = A323PropostaId;
            Z327PropostaCreatedAt = A327PropostaCreatedAt;
            Z324PropostaTitulo = A324PropostaTitulo;
            Z325PropostaDescricao = A325PropostaDescricao;
            Z326PropostaValor = A326PropostaValor;
            Z329PropostaStatus = A329PropostaStatus;
            Z330PropostaQuantidadeAprovadores = A330PropostaQuantidadeAprovadores;
            Z345PropostaReprovacoesPermitidas = A345PropostaReprovacoesPermitidas;
            Z227ContratoId = A227ContratoId;
            Z376ProcedimentosMedicosId = A376ProcedimentosMedicosId;
            Z328PropostaCratedBy = A328PropostaCratedBy;
            Z504PropostaPacienteClienteId = A504PropostaPacienteClienteId;
            Z505PropostaPacienteClienteRazaoSocial = A505PropostaPacienteClienteRazaoSocial;
            Z341PropostaAprovacoes_F = A341PropostaAprovacoes_F;
            Z342PropostaReprovacoes_F = A342PropostaReprovacoes_F;
            Z228ContratoNome = A228ContratoNome;
         }
      }

      protected void standaloneNotModal( )
      {
         edtPropostaId_Enabled = 0;
         AssignProp("", false, edtPropostaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaId_Enabled), 5, 0), true);
         AV30Pgmname = "PropostaC";
         AssignAttri("", false, "AV30Pgmname", AV30Pgmname);
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_ContratoId) )
         {
            edtContratoId_Enabled = 0;
            AssignProp("", false, edtContratoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContratoId_Enabled), 5, 0), true);
         }
         else
         {
            edtContratoId_Enabled = 1;
            AssignProp("", false, edtContratoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContratoId_Enabled), 5, 0), true);
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV29Insert_PropostaPacienteClienteId) )
         {
            A504PropostaPacienteClienteId = AV29Insert_PropostaPacienteClienteId;
            n504PropostaPacienteClienteId = false;
            AssignAttri("", false, "A504PropostaPacienteClienteId", ((0==A504PropostaPacienteClienteId)&&IsIns( )||n504PropostaPacienteClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A504PropostaPacienteClienteId), 9, 0, ".", ""))));
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
            /* Using cursor T001L9 */
            pr_default.execute(6, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(6) != 101) )
            {
               A341PropostaAprovacoes_F = T001L9_A341PropostaAprovacoes_F[0];
               n341PropostaAprovacoes_F = T001L9_n341PropostaAprovacoes_F[0];
               AssignAttri("", false, "A341PropostaAprovacoes_F", StringUtil.LTrimStr( (decimal)(A341PropostaAprovacoes_F), 4, 0));
            }
            else
            {
               A341PropostaAprovacoes_F = 0;
               n341PropostaAprovacoes_F = false;
               AssignAttri("", false, "A341PropostaAprovacoes_F", StringUtil.LTrimStr( (decimal)(A341PropostaAprovacoes_F), 4, 0));
            }
            pr_default.close(6);
            /* Using cursor T001L11 */
            pr_default.execute(7, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               A342PropostaReprovacoes_F = T001L11_A342PropostaReprovacoes_F[0];
               n342PropostaReprovacoes_F = T001L11_n342PropostaReprovacoes_F[0];
               AssignAttri("", false, "A342PropostaReprovacoes_F", StringUtil.LTrimStr( (decimal)(A342PropostaReprovacoes_F), 4, 0));
            }
            else
            {
               A342PropostaReprovacoes_F = 0;
               n342PropostaReprovacoes_F = false;
               AssignAttri("", false, "A342PropostaReprovacoes_F", StringUtil.LTrimStr( (decimal)(A342PropostaReprovacoes_F), 4, 0));
            }
            pr_default.close(7);
            /* Using cursor T001L7 */
            pr_default.execute(5, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId});
            A505PropostaPacienteClienteRazaoSocial = T001L7_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = T001L7_n505PropostaPacienteClienteRazaoSocial[0];
            pr_default.close(5);
         }
      }

      protected void Load1L49( )
      {
         /* Using cursor T001L14 */
         pr_default.execute(8, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound49 = 1;
            A327PropostaCreatedAt = T001L14_A327PropostaCreatedAt[0];
            n327PropostaCreatedAt = T001L14_n327PropostaCreatedAt[0];
            AssignAttri("", false, "A327PropostaCreatedAt", context.localUtil.TToC( A327PropostaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            A324PropostaTitulo = T001L14_A324PropostaTitulo[0];
            n324PropostaTitulo = T001L14_n324PropostaTitulo[0];
            AssignAttri("", false, "A324PropostaTitulo", A324PropostaTitulo);
            A325PropostaDescricao = T001L14_A325PropostaDescricao[0];
            n325PropostaDescricao = T001L14_n325PropostaDescricao[0];
            AssignAttri("", false, "A325PropostaDescricao", A325PropostaDescricao);
            A326PropostaValor = T001L14_A326PropostaValor[0];
            n326PropostaValor = T001L14_n326PropostaValor[0];
            AssignAttri("", false, "A326PropostaValor", ((Convert.ToDecimal(0)==A326PropostaValor)&&IsIns( )||n326PropostaValor ? "" : StringUtil.LTrim( StringUtil.NToC( A326PropostaValor, 18, 2, ".", ""))));
            A329PropostaStatus = T001L14_A329PropostaStatus[0];
            n329PropostaStatus = T001L14_n329PropostaStatus[0];
            AssignAttri("", false, "A329PropostaStatus", A329PropostaStatus);
            A228ContratoNome = T001L14_A228ContratoNome[0];
            n228ContratoNome = T001L14_n228ContratoNome[0];
            A330PropostaQuantidadeAprovadores = T001L14_A330PropostaQuantidadeAprovadores[0];
            n330PropostaQuantidadeAprovadores = T001L14_n330PropostaQuantidadeAprovadores[0];
            AssignAttri("", false, "A330PropostaQuantidadeAprovadores", ((0==A330PropostaQuantidadeAprovadores)&&IsIns( )||n330PropostaQuantidadeAprovadores ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A330PropostaQuantidadeAprovadores), 4, 0, ".", ""))));
            A345PropostaReprovacoesPermitidas = T001L14_A345PropostaReprovacoesPermitidas[0];
            n345PropostaReprovacoesPermitidas = T001L14_n345PropostaReprovacoesPermitidas[0];
            AssignAttri("", false, "A345PropostaReprovacoesPermitidas", ((0==A345PropostaReprovacoesPermitidas)&&IsIns( )||n345PropostaReprovacoesPermitidas ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A345PropostaReprovacoesPermitidas), 4, 0, ".", ""))));
            A505PropostaPacienteClienteRazaoSocial = T001L14_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = T001L14_n505PropostaPacienteClienteRazaoSocial[0];
            A227ContratoId = T001L14_A227ContratoId[0];
            n227ContratoId = T001L14_n227ContratoId[0];
            AssignAttri("", false, "A227ContratoId", ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
            A376ProcedimentosMedicosId = T001L14_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = T001L14_n376ProcedimentosMedicosId[0];
            AssignAttri("", false, "A376ProcedimentosMedicosId", ((0==A376ProcedimentosMedicosId)&&IsIns( )||n376ProcedimentosMedicosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ProcedimentosMedicosId), 9, 0, ".", ""))));
            A328PropostaCratedBy = T001L14_A328PropostaCratedBy[0];
            n328PropostaCratedBy = T001L14_n328PropostaCratedBy[0];
            AssignAttri("", false, "A328PropostaCratedBy", ((0==A328PropostaCratedBy)&&IsIns( )||n328PropostaCratedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A328PropostaCratedBy), 4, 0, ".", ""))));
            A504PropostaPacienteClienteId = T001L14_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = T001L14_n504PropostaPacienteClienteId[0];
            A341PropostaAprovacoes_F = T001L14_A341PropostaAprovacoes_F[0];
            n341PropostaAprovacoes_F = T001L14_n341PropostaAprovacoes_F[0];
            AssignAttri("", false, "A341PropostaAprovacoes_F", StringUtil.LTrimStr( (decimal)(A341PropostaAprovacoes_F), 4, 0));
            A342PropostaReprovacoes_F = T001L14_A342PropostaReprovacoes_F[0];
            n342PropostaReprovacoes_F = T001L14_n342PropostaReprovacoes_F[0];
            AssignAttri("", false, "A342PropostaReprovacoes_F", StringUtil.LTrimStr( (decimal)(A342PropostaReprovacoes_F), 4, 0));
            ZM1L49( -20) ;
         }
         pr_default.close(8);
         OnLoadActions1L49( ) ;
      }

      protected void OnLoadActions1L49( )
      {
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
            if ( (0==AV22ComboContratoId) )
            {
               A227ContratoId = 0;
               n227ContratoId = false;
               AssignAttri("", false, "A227ContratoId", ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
               n227ContratoId = true;
               n227ContratoId = true;
               AssignAttri("", false, "A227ContratoId", ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV22ComboContratoId) )
               {
                  A227ContratoId = AV22ComboContratoId;
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
            }
         }
         A343PropostaAprovacoesRestantes_F = (short)(A330PropostaQuantidadeAprovadores-A341PropostaAprovacoes_F);
         AssignAttri("", false, "A343PropostaAprovacoesRestantes_F", StringUtil.LTrimStr( (decimal)(A343PropostaAprovacoesRestantes_F), 4, 0));
      }

      protected void CheckExtendedTable1L49( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
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
            if ( (0==AV22ComboContratoId) )
            {
               A227ContratoId = 0;
               n227ContratoId = false;
               AssignAttri("", false, "A227ContratoId", ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
               n227ContratoId = true;
               n227ContratoId = true;
               AssignAttri("", false, "A227ContratoId", ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV22ComboContratoId) )
               {
                  A227ContratoId = AV22ComboContratoId;
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
            }
         }
         /* Using cursor T001L9 */
         pr_default.execute(6, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            A341PropostaAprovacoes_F = T001L9_A341PropostaAprovacoes_F[0];
            n341PropostaAprovacoes_F = T001L9_n341PropostaAprovacoes_F[0];
            AssignAttri("", false, "A341PropostaAprovacoes_F", StringUtil.LTrimStr( (decimal)(A341PropostaAprovacoes_F), 4, 0));
         }
         else
         {
            A341PropostaAprovacoes_F = 0;
            n341PropostaAprovacoes_F = false;
            AssignAttri("", false, "A341PropostaAprovacoes_F", StringUtil.LTrimStr( (decimal)(A341PropostaAprovacoes_F), 4, 0));
         }
         pr_default.close(6);
         A343PropostaAprovacoesRestantes_F = (short)(A330PropostaQuantidadeAprovadores-A341PropostaAprovacoes_F);
         AssignAttri("", false, "A343PropostaAprovacoesRestantes_F", StringUtil.LTrimStr( (decimal)(A343PropostaAprovacoesRestantes_F), 4, 0));
         /* Using cursor T001L11 */
         pr_default.execute(7, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            A342PropostaReprovacoes_F = T001L11_A342PropostaReprovacoes_F[0];
            n342PropostaReprovacoes_F = T001L11_n342PropostaReprovacoes_F[0];
            AssignAttri("", false, "A342PropostaReprovacoes_F", StringUtil.LTrimStr( (decimal)(A342PropostaReprovacoes_F), 4, 0));
         }
         else
         {
            A342PropostaReprovacoes_F = 0;
            n342PropostaReprovacoes_F = false;
            AssignAttri("", false, "A342PropostaReprovacoes_F", StringUtil.LTrimStr( (decimal)(A342PropostaReprovacoes_F), 4, 0));
         }
         pr_default.close(7);
         /* Using cursor T001L5 */
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
         if ( ( A326PropostaValor < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "PROPOSTAVALOR");
            AnyError = 1;
            GX_FocusControl = edtPropostaValor_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T001L6 */
         pr_default.execute(4, new Object[] {n328PropostaCratedBy, A328PropostaCratedBy});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A328PropostaCratedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sec User Proposta'.", "ForeignKeyNotFound", 1, "PROPOSTACRATEDBY");
               AnyError = 1;
               GX_FocusControl = edtPropostaCratedBy_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(4);
         if ( ! ( ( StringUtil.StrCmp(A329PropostaStatus, "PENDENTE") == 0 ) || ( StringUtil.StrCmp(A329PropostaStatus, "EM_ANALISE") == 0 ) || ( StringUtil.StrCmp(A329PropostaStatus, "APROVADO") == 0 ) || ( StringUtil.StrCmp(A329PropostaStatus, "REJEITADO") == 0 ) || ( StringUtil.StrCmp(A329PropostaStatus, "REVISAO") == 0 ) || ( StringUtil.StrCmp(A329PropostaStatus, "CANCELADO") == 0 ) || ( StringUtil.StrCmp(A329PropostaStatus, "AGUARDANDO_ASSINATURA") == 0 ) || ( StringUtil.StrCmp(A329PropostaStatus, "AnaliseReprovada") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A329PropostaStatus)) ) )
         {
            GX_msglist.addItem("Campo Proposta Status fora do intervalo", "OutOfRange", 1, "PROPOSTASTATUS");
            AnyError = 1;
            GX_FocusControl = cmbPropostaStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T001L4 */
         pr_default.execute(2, new Object[] {n227ContratoId, A227ContratoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A227ContratoId) ) )
            {
               GX_msglist.addItem("Não existe 'Contrato'.", "ForeignKeyNotFound", 1, "CONTRATOID");
               AnyError = 1;
               GX_FocusControl = edtContratoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A228ContratoNome = T001L4_A228ContratoNome[0];
         n228ContratoNome = T001L4_n228ContratoNome[0];
         pr_default.close(2);
         /* Using cursor T001L7 */
         pr_default.execute(5, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A504PropostaPacienteClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Proposta Cliente'.", "ForeignKeyNotFound", 1, "PROPOSTAPACIENTECLIENTEID");
               AnyError = 1;
            }
         }
         A505PropostaPacienteClienteRazaoSocial = T001L7_A505PropostaPacienteClienteRazaoSocial[0];
         n505PropostaPacienteClienteRazaoSocial = T001L7_n505PropostaPacienteClienteRazaoSocial[0];
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors1L49( )
      {
         pr_default.close(6);
         pr_default.close(7);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(2);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_25( int A323PropostaId )
      {
         /* Using cursor T001L16 */
         pr_default.execute(9, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            A341PropostaAprovacoes_F = T001L16_A341PropostaAprovacoes_F[0];
            n341PropostaAprovacoes_F = T001L16_n341PropostaAprovacoes_F[0];
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
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_26( int A323PropostaId )
      {
         /* Using cursor T001L18 */
         pr_default.execute(10, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            A342PropostaReprovacoes_F = T001L18_A342PropostaReprovacoes_F[0];
            n342PropostaReprovacoes_F = T001L18_n342PropostaReprovacoes_F[0];
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
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_22( int A376ProcedimentosMedicosId )
      {
         /* Using cursor T001L19 */
         pr_default.execute(11, new Object[] {n376ProcedimentosMedicosId, A376ProcedimentosMedicosId});
         if ( (pr_default.getStatus(11) == 101) )
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
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void gxLoad_23( short A328PropostaCratedBy )
      {
         /* Using cursor T001L20 */
         pr_default.execute(12, new Object[] {n328PropostaCratedBy, A328PropostaCratedBy});
         if ( (pr_default.getStatus(12) == 101) )
         {
            if ( ! ( (0==A328PropostaCratedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sec User Proposta'.", "ForeignKeyNotFound", 1, "PROPOSTACRATEDBY");
               AnyError = 1;
               GX_FocusControl = edtPropostaCratedBy_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void gxLoad_21( int A227ContratoId )
      {
         /* Using cursor T001L21 */
         pr_default.execute(13, new Object[] {n227ContratoId, A227ContratoId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            if ( ! ( (0==A227ContratoId) ) )
            {
               GX_msglist.addItem("Não existe 'Contrato'.", "ForeignKeyNotFound", 1, "CONTRATOID");
               AnyError = 1;
               GX_FocusControl = edtContratoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A228ContratoNome = T001L21_A228ContratoNome[0];
         n228ContratoNome = T001L21_n228ContratoNome[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A228ContratoNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(13) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(13);
      }

      protected void gxLoad_24( int A504PropostaPacienteClienteId )
      {
         /* Using cursor T001L22 */
         pr_default.execute(14, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( (0==A504PropostaPacienteClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Proposta Cliente'.", "ForeignKeyNotFound", 1, "PROPOSTAPACIENTECLIENTEID");
               AnyError = 1;
            }
         }
         A505PropostaPacienteClienteRazaoSocial = T001L22_A505PropostaPacienteClienteRazaoSocial[0];
         n505PropostaPacienteClienteRazaoSocial = T001L22_n505PropostaPacienteClienteRazaoSocial[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A505PropostaPacienteClienteRazaoSocial)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void GetKey1L49( )
      {
         /* Using cursor T001L23 */
         pr_default.execute(15, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound49 = 1;
         }
         else
         {
            RcdFound49 = 0;
         }
         pr_default.close(15);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001L3 */
         pr_default.execute(1, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1L49( 20) ;
            RcdFound49 = 1;
            A323PropostaId = T001L3_A323PropostaId[0];
            n323PropostaId = T001L3_n323PropostaId[0];
            AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
            A327PropostaCreatedAt = T001L3_A327PropostaCreatedAt[0];
            n327PropostaCreatedAt = T001L3_n327PropostaCreatedAt[0];
            AssignAttri("", false, "A327PropostaCreatedAt", context.localUtil.TToC( A327PropostaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            A324PropostaTitulo = T001L3_A324PropostaTitulo[0];
            n324PropostaTitulo = T001L3_n324PropostaTitulo[0];
            AssignAttri("", false, "A324PropostaTitulo", A324PropostaTitulo);
            A325PropostaDescricao = T001L3_A325PropostaDescricao[0];
            n325PropostaDescricao = T001L3_n325PropostaDescricao[0];
            AssignAttri("", false, "A325PropostaDescricao", A325PropostaDescricao);
            A326PropostaValor = T001L3_A326PropostaValor[0];
            n326PropostaValor = T001L3_n326PropostaValor[0];
            AssignAttri("", false, "A326PropostaValor", ((Convert.ToDecimal(0)==A326PropostaValor)&&IsIns( )||n326PropostaValor ? "" : StringUtil.LTrim( StringUtil.NToC( A326PropostaValor, 18, 2, ".", ""))));
            A329PropostaStatus = T001L3_A329PropostaStatus[0];
            n329PropostaStatus = T001L3_n329PropostaStatus[0];
            AssignAttri("", false, "A329PropostaStatus", A329PropostaStatus);
            A330PropostaQuantidadeAprovadores = T001L3_A330PropostaQuantidadeAprovadores[0];
            n330PropostaQuantidadeAprovadores = T001L3_n330PropostaQuantidadeAprovadores[0];
            AssignAttri("", false, "A330PropostaQuantidadeAprovadores", ((0==A330PropostaQuantidadeAprovadores)&&IsIns( )||n330PropostaQuantidadeAprovadores ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A330PropostaQuantidadeAprovadores), 4, 0, ".", ""))));
            A345PropostaReprovacoesPermitidas = T001L3_A345PropostaReprovacoesPermitidas[0];
            n345PropostaReprovacoesPermitidas = T001L3_n345PropostaReprovacoesPermitidas[0];
            AssignAttri("", false, "A345PropostaReprovacoesPermitidas", ((0==A345PropostaReprovacoesPermitidas)&&IsIns( )||n345PropostaReprovacoesPermitidas ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A345PropostaReprovacoesPermitidas), 4, 0, ".", ""))));
            A227ContratoId = T001L3_A227ContratoId[0];
            n227ContratoId = T001L3_n227ContratoId[0];
            AssignAttri("", false, "A227ContratoId", ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
            A376ProcedimentosMedicosId = T001L3_A376ProcedimentosMedicosId[0];
            n376ProcedimentosMedicosId = T001L3_n376ProcedimentosMedicosId[0];
            AssignAttri("", false, "A376ProcedimentosMedicosId", ((0==A376ProcedimentosMedicosId)&&IsIns( )||n376ProcedimentosMedicosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ProcedimentosMedicosId), 9, 0, ".", ""))));
            A328PropostaCratedBy = T001L3_A328PropostaCratedBy[0];
            n328PropostaCratedBy = T001L3_n328PropostaCratedBy[0];
            AssignAttri("", false, "A328PropostaCratedBy", ((0==A328PropostaCratedBy)&&IsIns( )||n328PropostaCratedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A328PropostaCratedBy), 4, 0, ".", ""))));
            A504PropostaPacienteClienteId = T001L3_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = T001L3_n504PropostaPacienteClienteId[0];
            Z323PropostaId = A323PropostaId;
            sMode49 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1L49( ) ;
            if ( AnyError == 1 )
            {
               RcdFound49 = 0;
               InitializeNonKey1L49( ) ;
            }
            Gx_mode = sMode49;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound49 = 0;
            InitializeNonKey1L49( ) ;
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
         GetKey1L49( ) ;
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
         /* Using cursor T001L24 */
         pr_default.execute(16, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            while ( (pr_default.getStatus(16) != 101) && ( ( T001L24_A323PropostaId[0] < A323PropostaId ) ) )
            {
               pr_default.readNext(16);
            }
            if ( (pr_default.getStatus(16) != 101) && ( ( T001L24_A323PropostaId[0] > A323PropostaId ) ) )
            {
               A323PropostaId = T001L24_A323PropostaId[0];
               n323PropostaId = T001L24_n323PropostaId[0];
               AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
               RcdFound49 = 1;
            }
         }
         pr_default.close(16);
      }

      protected void move_previous( )
      {
         RcdFound49 = 0;
         /* Using cursor T001L25 */
         pr_default.execute(17, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            while ( (pr_default.getStatus(17) != 101) && ( ( T001L25_A323PropostaId[0] > A323PropostaId ) ) )
            {
               pr_default.readNext(17);
            }
            if ( (pr_default.getStatus(17) != 101) && ( ( T001L25_A323PropostaId[0] < A323PropostaId ) ) )
            {
               A323PropostaId = T001L25_A323PropostaId[0];
               n323PropostaId = T001L25_n323PropostaId[0];
               AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
               RcdFound49 = 1;
            }
         }
         pr_default.close(17);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1L49( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPropostaTitulo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1L49( ) ;
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
                  Update1L49( ) ;
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
                  Insert1L49( ) ;
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
                     Insert1L49( ) ;
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

      protected void CheckOptimisticConcurrency1L49( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001L2 */
            pr_default.execute(0, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Proposta"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z327PropostaCreatedAt != T001L2_A327PropostaCreatedAt[0] ) || ( StringUtil.StrCmp(Z324PropostaTitulo, T001L2_A324PropostaTitulo[0]) != 0 ) || ( StringUtil.StrCmp(Z325PropostaDescricao, T001L2_A325PropostaDescricao[0]) != 0 ) || ( Z326PropostaValor != T001L2_A326PropostaValor[0] ) || ( StringUtil.StrCmp(Z329PropostaStatus, T001L2_A329PropostaStatus[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z330PropostaQuantidadeAprovadores != T001L2_A330PropostaQuantidadeAprovadores[0] ) || ( Z345PropostaReprovacoesPermitidas != T001L2_A345PropostaReprovacoesPermitidas[0] ) || ( Z227ContratoId != T001L2_A227ContratoId[0] ) || ( Z376ProcedimentosMedicosId != T001L2_A376ProcedimentosMedicosId[0] ) || ( Z328PropostaCratedBy != T001L2_A328PropostaCratedBy[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z504PropostaPacienteClienteId != T001L2_A504PropostaPacienteClienteId[0] ) )
            {
               if ( Z327PropostaCreatedAt != T001L2_A327PropostaCreatedAt[0] )
               {
                  GXUtil.WriteLog("propostac:[seudo value changed for attri]"+"PropostaCreatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z327PropostaCreatedAt);
                  GXUtil.WriteLogRaw("Current: ",T001L2_A327PropostaCreatedAt[0]);
               }
               if ( StringUtil.StrCmp(Z324PropostaTitulo, T001L2_A324PropostaTitulo[0]) != 0 )
               {
                  GXUtil.WriteLog("propostac:[seudo value changed for attri]"+"PropostaTitulo");
                  GXUtil.WriteLogRaw("Old: ",Z324PropostaTitulo);
                  GXUtil.WriteLogRaw("Current: ",T001L2_A324PropostaTitulo[0]);
               }
               if ( StringUtil.StrCmp(Z325PropostaDescricao, T001L2_A325PropostaDescricao[0]) != 0 )
               {
                  GXUtil.WriteLog("propostac:[seudo value changed for attri]"+"PropostaDescricao");
                  GXUtil.WriteLogRaw("Old: ",Z325PropostaDescricao);
                  GXUtil.WriteLogRaw("Current: ",T001L2_A325PropostaDescricao[0]);
               }
               if ( Z326PropostaValor != T001L2_A326PropostaValor[0] )
               {
                  GXUtil.WriteLog("propostac:[seudo value changed for attri]"+"PropostaValor");
                  GXUtil.WriteLogRaw("Old: ",Z326PropostaValor);
                  GXUtil.WriteLogRaw("Current: ",T001L2_A326PropostaValor[0]);
               }
               if ( StringUtil.StrCmp(Z329PropostaStatus, T001L2_A329PropostaStatus[0]) != 0 )
               {
                  GXUtil.WriteLog("propostac:[seudo value changed for attri]"+"PropostaStatus");
                  GXUtil.WriteLogRaw("Old: ",Z329PropostaStatus);
                  GXUtil.WriteLogRaw("Current: ",T001L2_A329PropostaStatus[0]);
               }
               if ( Z330PropostaQuantidadeAprovadores != T001L2_A330PropostaQuantidadeAprovadores[0] )
               {
                  GXUtil.WriteLog("propostac:[seudo value changed for attri]"+"PropostaQuantidadeAprovadores");
                  GXUtil.WriteLogRaw("Old: ",Z330PropostaQuantidadeAprovadores);
                  GXUtil.WriteLogRaw("Current: ",T001L2_A330PropostaQuantidadeAprovadores[0]);
               }
               if ( Z345PropostaReprovacoesPermitidas != T001L2_A345PropostaReprovacoesPermitidas[0] )
               {
                  GXUtil.WriteLog("propostac:[seudo value changed for attri]"+"PropostaReprovacoesPermitidas");
                  GXUtil.WriteLogRaw("Old: ",Z345PropostaReprovacoesPermitidas);
                  GXUtil.WriteLogRaw("Current: ",T001L2_A345PropostaReprovacoesPermitidas[0]);
               }
               if ( Z227ContratoId != T001L2_A227ContratoId[0] )
               {
                  GXUtil.WriteLog("propostac:[seudo value changed for attri]"+"ContratoId");
                  GXUtil.WriteLogRaw("Old: ",Z227ContratoId);
                  GXUtil.WriteLogRaw("Current: ",T001L2_A227ContratoId[0]);
               }
               if ( Z376ProcedimentosMedicosId != T001L2_A376ProcedimentosMedicosId[0] )
               {
                  GXUtil.WriteLog("propostac:[seudo value changed for attri]"+"ProcedimentosMedicosId");
                  GXUtil.WriteLogRaw("Old: ",Z376ProcedimentosMedicosId);
                  GXUtil.WriteLogRaw("Current: ",T001L2_A376ProcedimentosMedicosId[0]);
               }
               if ( Z328PropostaCratedBy != T001L2_A328PropostaCratedBy[0] )
               {
                  GXUtil.WriteLog("propostac:[seudo value changed for attri]"+"PropostaCratedBy");
                  GXUtil.WriteLogRaw("Old: ",Z328PropostaCratedBy);
                  GXUtil.WriteLogRaw("Current: ",T001L2_A328PropostaCratedBy[0]);
               }
               if ( Z504PropostaPacienteClienteId != T001L2_A504PropostaPacienteClienteId[0] )
               {
                  GXUtil.WriteLog("propostac:[seudo value changed for attri]"+"PropostaPacienteClienteId");
                  GXUtil.WriteLogRaw("Old: ",Z504PropostaPacienteClienteId);
                  GXUtil.WriteLogRaw("Current: ",T001L2_A504PropostaPacienteClienteId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Proposta"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1L49( )
      {
         BeforeValidate1L49( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1L49( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1L49( 0) ;
            CheckOptimisticConcurrency1L49( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1L49( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1L49( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001L26 */
                     pr_default.execute(18, new Object[] {n327PropostaCreatedAt, A327PropostaCreatedAt, n324PropostaTitulo, A324PropostaTitulo, n325PropostaDescricao, A325PropostaDescricao, n326PropostaValor, A326PropostaValor, n329PropostaStatus, A329PropostaStatus, n330PropostaQuantidadeAprovadores, A330PropostaQuantidadeAprovadores, n345PropostaReprovacoesPermitidas, A345PropostaReprovacoesPermitidas, n227ContratoId, A227ContratoId, n376ProcedimentosMedicosId, A376ProcedimentosMedicosId, n328PropostaCratedBy, A328PropostaCratedBy, n504PropostaPacienteClienteId, A504PropostaPacienteClienteId});
                     pr_default.close(18);
                     /* Retrieving last key number assigned */
                     /* Using cursor T001L27 */
                     pr_default.execute(19);
                     A323PropostaId = T001L27_A323PropostaId[0];
                     n323PropostaId = T001L27_n323PropostaId[0];
                     AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
                     pr_default.close(19);
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
                           ResetCaption1L0( ) ;
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
               Load1L49( ) ;
            }
            EndLevel1L49( ) ;
         }
         CloseExtendedTableCursors1L49( ) ;
      }

      protected void Update1L49( )
      {
         BeforeValidate1L49( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1L49( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1L49( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1L49( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1L49( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001L28 */
                     pr_default.execute(20, new Object[] {n327PropostaCreatedAt, A327PropostaCreatedAt, n324PropostaTitulo, A324PropostaTitulo, n325PropostaDescricao, A325PropostaDescricao, n326PropostaValor, A326PropostaValor, n329PropostaStatus, A329PropostaStatus, n330PropostaQuantidadeAprovadores, A330PropostaQuantidadeAprovadores, n345PropostaReprovacoesPermitidas, A345PropostaReprovacoesPermitidas, n227ContratoId, A227ContratoId, n376ProcedimentosMedicosId, A376ProcedimentosMedicosId, n328PropostaCratedBy, A328PropostaCratedBy, n504PropostaPacienteClienteId, A504PropostaPacienteClienteId, n323PropostaId, A323PropostaId});
                     pr_default.close(20);
                     pr_default.SmartCacheProvider.SetUpdated("Proposta");
                     if ( (pr_default.getStatus(20) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Proposta"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1L49( ) ;
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
            EndLevel1L49( ) ;
         }
         CloseExtendedTableCursors1L49( ) ;
      }

      protected void DeferredUpdate1L49( )
      {
      }

      protected void delete( )
      {
         BeforeValidate1L49( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1L49( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1L49( ) ;
            AfterConfirm1L49( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1L49( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001L29 */
                  pr_default.execute(21, new Object[] {n323PropostaId, A323PropostaId});
                  pr_default.close(21);
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
         EndLevel1L49( ) ;
         Gx_mode = sMode49;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1L49( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001L31 */
            pr_default.execute(22, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(22) != 101) )
            {
               A341PropostaAprovacoes_F = T001L31_A341PropostaAprovacoes_F[0];
               n341PropostaAprovacoes_F = T001L31_n341PropostaAprovacoes_F[0];
               AssignAttri("", false, "A341PropostaAprovacoes_F", StringUtil.LTrimStr( (decimal)(A341PropostaAprovacoes_F), 4, 0));
            }
            else
            {
               A341PropostaAprovacoes_F = 0;
               n341PropostaAprovacoes_F = false;
               AssignAttri("", false, "A341PropostaAprovacoes_F", StringUtil.LTrimStr( (decimal)(A341PropostaAprovacoes_F), 4, 0));
            }
            pr_default.close(22);
            /* Using cursor T001L33 */
            pr_default.execute(23, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(23) != 101) )
            {
               A342PropostaReprovacoes_F = T001L33_A342PropostaReprovacoes_F[0];
               n342PropostaReprovacoes_F = T001L33_n342PropostaReprovacoes_F[0];
               AssignAttri("", false, "A342PropostaReprovacoes_F", StringUtil.LTrimStr( (decimal)(A342PropostaReprovacoes_F), 4, 0));
            }
            else
            {
               A342PropostaReprovacoes_F = 0;
               n342PropostaReprovacoes_F = false;
               AssignAttri("", false, "A342PropostaReprovacoes_F", StringUtil.LTrimStr( (decimal)(A342PropostaReprovacoes_F), 4, 0));
            }
            pr_default.close(23);
            /* Using cursor T001L34 */
            pr_default.execute(24, new Object[] {n227ContratoId, A227ContratoId});
            A228ContratoNome = T001L34_A228ContratoNome[0];
            n228ContratoNome = T001L34_n228ContratoNome[0];
            pr_default.close(24);
            A343PropostaAprovacoesRestantes_F = (short)(A330PropostaQuantidadeAprovadores-A341PropostaAprovacoes_F);
            AssignAttri("", false, "A343PropostaAprovacoesRestantes_F", StringUtil.LTrimStr( (decimal)(A343PropostaAprovacoesRestantes_F), 4, 0));
            /* Using cursor T001L35 */
            pr_default.execute(25, new Object[] {n504PropostaPacienteClienteId, A504PropostaPacienteClienteId});
            A505PropostaPacienteClienteRazaoSocial = T001L35_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = T001L35_n505PropostaPacienteClienteRazaoSocial[0];
            pr_default.close(25);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001L36 */
            pr_default.execute(26, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(26) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Contrato"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(26);
            /* Using cursor T001L37 */
            pr_default.execute(27, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(27) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Reembolso"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(27);
            /* Using cursor T001L38 */
            pr_default.execute(28, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(28) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Titulo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(28);
            /* Using cursor T001L39 */
            pr_default.execute(29, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(29) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"NotaFiscalItem"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(29);
            /* Using cursor T001L40 */
            pr_default.execute(30, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(30) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"PropostaContratoAssinatura"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(30);
            /* Using cursor T001L41 */
            pr_default.execute(31, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(31) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"PropostaDocumentos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(31);
            /* Using cursor T001L42 */
            pr_default.execute(32, new Object[] {n323PropostaId, A323PropostaId});
            if ( (pr_default.getStatus(32) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Aprovacao"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(32);
         }
      }

      protected void EndLevel1L49( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1L49( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("propostac",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1L0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("propostac",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1L49( )
      {
         /* Scan By routine */
         /* Using cursor T001L43 */
         pr_default.execute(33);
         RcdFound49 = 0;
         if ( (pr_default.getStatus(33) != 101) )
         {
            RcdFound49 = 1;
            A323PropostaId = T001L43_A323PropostaId[0];
            n323PropostaId = T001L43_n323PropostaId[0];
            AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1L49( )
      {
         /* Scan next routine */
         pr_default.readNext(33);
         RcdFound49 = 0;
         if ( (pr_default.getStatus(33) != 101) )
         {
            RcdFound49 = 1;
            A323PropostaId = T001L43_A323PropostaId[0];
            n323PropostaId = T001L43_n323PropostaId[0];
            AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
         }
      }

      protected void ScanEnd1L49( )
      {
         pr_default.close(33);
      }

      protected void AfterConfirm1L49( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1L49( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1L49( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1L49( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1L49( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1L49( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1L49( )
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
         edtContratoId_Enabled = 0;
         AssignProp("", false, edtContratoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContratoId_Enabled), 5, 0), true);
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
         edtavCombocontratoid_Enabled = 0;
         AssignProp("", false, edtavCombocontratoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombocontratoid_Enabled), 5, 0), true);
         edtavComboprocedimentosmedicosid_Enabled = 0;
         AssignProp("", false, edtavComboprocedimentosmedicosid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboprocedimentosmedicosid_Enabled), 5, 0), true);
         edtPropostaId_Enabled = 0;
         AssignProp("", false, edtPropostaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1L49( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1L0( )
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
         GXEncryptionTmp = "propostac"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7PropostaId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("propostac") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"PropostaC");
         forbiddenHiddens.Add("PropostaId", context.localUtil.Format( (decimal)(A323PropostaId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_ProcedimentosMedicosId", context.localUtil.Format( (decimal)(AV24Insert_ProcedimentosMedicosId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_PropostaCratedBy", context.localUtil.Format( (decimal)(AV11Insert_PropostaCratedBy), "ZZZ9"));
         forbiddenHiddens.Add("Insert_ContratoId", context.localUtil.Format( (decimal)(AV12Insert_ContratoId), "ZZZZZ9"));
         forbiddenHiddens.Add("Insert_PropostaPacienteClienteId", context.localUtil.Format( (decimal)(AV29Insert_PropostaPacienteClienteId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("propostac:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z323PropostaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z323PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z327PropostaCreatedAt", context.localUtil.TToC( Z327PropostaCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z324PropostaTitulo", Z324PropostaTitulo);
         GxWebStd.gx_hidden_field( context, "Z325PropostaDescricao", Z325PropostaDescricao);
         GxWebStd.gx_hidden_field( context, "Z326PropostaValor", StringUtil.LTrim( StringUtil.NToC( Z326PropostaValor, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z329PropostaStatus", Z329PropostaStatus);
         GxWebStd.gx_hidden_field( context, "Z330PropostaQuantidadeAprovadores", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z330PropostaQuantidadeAprovadores), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z345PropostaReprovacoesPermitidas", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z345PropostaReprovacoesPermitidas), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z227ContratoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z227ContratoId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z376ProcedimentosMedicosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z376ProcedimentosMedicosId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z328PropostaCratedBy", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z328PropostaCratedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z504PropostaPacienteClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z504PropostaPacienteClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N376ProcedimentosMedicosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ProcedimentosMedicosId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N328PropostaCratedBy", StringUtil.LTrim( StringUtil.NToC( (decimal)(A328PropostaCratedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N227ContratoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N504PropostaPacienteClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A504PropostaPacienteClienteId), 9, 0, ",", "")));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCONTRATOID_DATA", AV21ContratoId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCONTRATOID_DATA", AV21ContratoId_Data);
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
         GxWebStd.gx_hidden_field( context, "vPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROPOSTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PropostaId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_PROCEDIMENTOSMEDICOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24Insert_ProcedimentosMedicosId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_PROPOSTACRATEDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_PropostaCratedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CONTRATOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_ContratoId), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_PROPOSTAPACIENTECLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29Insert_PropostaPacienteClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTAPACIENTECLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A504PropostaPacienteClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CONTRATONOME", A228ContratoNome);
         GxWebStd.gx_hidden_field( context, "PROPOSTAPACIENTECLIENTERAZAOSOCIAL", A505PropostaPacienteClienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV30Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTACRATEDBY_Objectcall", StringUtil.RTrim( Combo_propostacratedby_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTACRATEDBY_Cls", StringUtil.RTrim( Combo_propostacratedby_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTACRATEDBY_Selectedvalue_set", StringUtil.RTrim( Combo_propostacratedby_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTACRATEDBY_Selectedtext_set", StringUtil.RTrim( Combo_propostacratedby_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTACRATEDBY_Enabled", StringUtil.BoolToStr( Combo_propostacratedby_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTACRATEDBY_Datalistproc", StringUtil.RTrim( Combo_propostacratedby_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTACRATEDBY_Datalistprocparametersprefix", StringUtil.RTrim( Combo_propostacratedby_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_CONTRATOID_Objectcall", StringUtil.RTrim( Combo_contratoid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_CONTRATOID_Cls", StringUtil.RTrim( Combo_contratoid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_CONTRATOID_Selectedvalue_set", StringUtil.RTrim( Combo_contratoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CONTRATOID_Selectedtext_set", StringUtil.RTrim( Combo_contratoid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_CONTRATOID_Enabled", StringUtil.BoolToStr( Combo_contratoid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_CONTRATOID_Datalistproc", StringUtil.RTrim( Combo_contratoid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_CONTRATOID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_contratoid_Datalistprocparametersprefix));
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
         GXEncryptionTmp = "propostac"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7PropostaId,9,0));
         return formatLink("propostac") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "PropostaC" ;
      }

      public override string GetPgmdesc( )
      {
         return "Propostas" ;
      }

      protected void InitializeNonKey1L49( )
      {
         A376ProcedimentosMedicosId = 0;
         n376ProcedimentosMedicosId = false;
         AssignAttri("", false, "A376ProcedimentosMedicosId", ((0==A376ProcedimentosMedicosId)&&IsIns( )||n376ProcedimentosMedicosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A376ProcedimentosMedicosId), 9, 0, ".", ""))));
         n376ProcedimentosMedicosId = ((0==A376ProcedimentosMedicosId) ? true : false);
         A328PropostaCratedBy = 0;
         n328PropostaCratedBy = false;
         AssignAttri("", false, "A328PropostaCratedBy", ((0==A328PropostaCratedBy)&&IsIns( )||n328PropostaCratedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A328PropostaCratedBy), 4, 0, ".", ""))));
         n328PropostaCratedBy = ((0==A328PropostaCratedBy) ? true : false);
         A227ContratoId = 0;
         n227ContratoId = false;
         AssignAttri("", false, "A227ContratoId", ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
         n227ContratoId = ((0==A227ContratoId) ? true : false);
         A504PropostaPacienteClienteId = 0;
         n504PropostaPacienteClienteId = false;
         AssignAttri("", false, "A504PropostaPacienteClienteId", ((0==A504PropostaPacienteClienteId)&&IsIns( )||n504PropostaPacienteClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A504PropostaPacienteClienteId), 9, 0, ".", ""))));
         A327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         n327PropostaCreatedAt = false;
         AssignAttri("", false, "A327PropostaCreatedAt", context.localUtil.TToC( A327PropostaCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         n327PropostaCreatedAt = ((DateTime.MinValue==A327PropostaCreatedAt) ? true : false);
         A343PropostaAprovacoesRestantes_F = 0;
         AssignAttri("", false, "A343PropostaAprovacoesRestantes_F", StringUtil.LTrimStr( (decimal)(A343PropostaAprovacoesRestantes_F), 4, 0));
         A324PropostaTitulo = "";
         n324PropostaTitulo = false;
         AssignAttri("", false, "A324PropostaTitulo", A324PropostaTitulo);
         n324PropostaTitulo = (String.IsNullOrEmpty(StringUtil.RTrim( A324PropostaTitulo)) ? true : false);
         A325PropostaDescricao = "";
         n325PropostaDescricao = false;
         AssignAttri("", false, "A325PropostaDescricao", A325PropostaDescricao);
         n325PropostaDescricao = (String.IsNullOrEmpty(StringUtil.RTrim( A325PropostaDescricao)) ? true : false);
         A326PropostaValor = 0;
         n326PropostaValor = false;
         AssignAttri("", false, "A326PropostaValor", ((Convert.ToDecimal(0)==A326PropostaValor)&&IsIns( )||n326PropostaValor ? "" : StringUtil.LTrim( StringUtil.NToC( A326PropostaValor, 18, 2, ".", ""))));
         n326PropostaValor = ((Convert.ToDecimal(0)==A326PropostaValor) ? true : false);
         A329PropostaStatus = "";
         n329PropostaStatus = false;
         AssignAttri("", false, "A329PropostaStatus", A329PropostaStatus);
         n329PropostaStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A329PropostaStatus)) ? true : false);
         A228ContratoNome = "";
         n228ContratoNome = false;
         AssignAttri("", false, "A228ContratoNome", A228ContratoNome);
         A330PropostaQuantidadeAprovadores = 0;
         n330PropostaQuantidadeAprovadores = false;
         AssignAttri("", false, "A330PropostaQuantidadeAprovadores", ((0==A330PropostaQuantidadeAprovadores)&&IsIns( )||n330PropostaQuantidadeAprovadores ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A330PropostaQuantidadeAprovadores), 4, 0, ".", ""))));
         n330PropostaQuantidadeAprovadores = ((0==A330PropostaQuantidadeAprovadores) ? true : false);
         A345PropostaReprovacoesPermitidas = 0;
         n345PropostaReprovacoesPermitidas = false;
         AssignAttri("", false, "A345PropostaReprovacoesPermitidas", ((0==A345PropostaReprovacoesPermitidas)&&IsIns( )||n345PropostaReprovacoesPermitidas ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A345PropostaReprovacoesPermitidas), 4, 0, ".", ""))));
         n345PropostaReprovacoesPermitidas = ((0==A345PropostaReprovacoesPermitidas) ? true : false);
         A341PropostaAprovacoes_F = 0;
         n341PropostaAprovacoes_F = false;
         AssignAttri("", false, "A341PropostaAprovacoes_F", StringUtil.LTrimStr( (decimal)(A341PropostaAprovacoes_F), 4, 0));
         A342PropostaReprovacoes_F = 0;
         n342PropostaReprovacoes_F = false;
         AssignAttri("", false, "A342PropostaReprovacoes_F", StringUtil.LTrimStr( (decimal)(A342PropostaReprovacoes_F), 4, 0));
         A505PropostaPacienteClienteRazaoSocial = "";
         n505PropostaPacienteClienteRazaoSocial = false;
         AssignAttri("", false, "A505PropostaPacienteClienteRazaoSocial", A505PropostaPacienteClienteRazaoSocial);
         Z327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         Z324PropostaTitulo = "";
         Z325PropostaDescricao = "";
         Z326PropostaValor = 0;
         Z329PropostaStatus = "";
         Z330PropostaQuantidadeAprovadores = 0;
         Z345PropostaReprovacoesPermitidas = 0;
         Z227ContratoId = 0;
         Z376ProcedimentosMedicosId = 0;
         Z328PropostaCratedBy = 0;
         Z504PropostaPacienteClienteId = 0;
      }

      protected void InitAll1L49( )
      {
         A323PropostaId = 0;
         n323PropostaId = false;
         AssignAttri("", false, "A323PropostaId", StringUtil.LTrimStr( (decimal)(A323PropostaId), 9, 0));
         InitializeNonKey1L49( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101917288", true, true);
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
         context.AddJavascriptSource("propostac.js", "?20256101917289", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         lblTextblockcontratoid_Internalname = "TEXTBLOCKCONTRATOID";
         Combo_contratoid_Internalname = "COMBO_CONTRATOID";
         edtContratoId_Internalname = "CONTRATOID";
         divTablesplittedcontratoid_Internalname = "TABLESPLITTEDCONTRATOID";
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
         edtavCombocontratoid_Internalname = "vCOMBOCONTRATOID";
         divSectionattribute_contratoid_Internalname = "SECTIONATTRIBUTE_CONTRATOID";
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
         Form.Caption = "Propostas";
         edtPropostaId_Jsonclick = "";
         edtPropostaId_Enabled = 0;
         edtPropostaId_Visible = 1;
         edtavComboprocedimentosmedicosid_Jsonclick = "";
         edtavComboprocedimentosmedicosid_Enabled = 0;
         edtavComboprocedimentosmedicosid_Visible = 1;
         edtavCombocontratoid_Jsonclick = "";
         edtavCombocontratoid_Enabled = 0;
         edtavCombocontratoid_Visible = 1;
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
         Combo_procedimentosmedicosid_Datalistproc = "PropostaCLoadDVCombo";
         Combo_procedimentosmedicosid_Cls = "ExtendedCombo AttributeFL";
         Combo_procedimentosmedicosid_Caption = "";
         Combo_procedimentosmedicosid_Enabled = Convert.ToBoolean( -1);
         edtPropostaQuantidadeAprovadores_Jsonclick = "";
         edtPropostaQuantidadeAprovadores_Enabled = 1;
         edtContratoId_Jsonclick = "";
         edtContratoId_Enabled = 1;
         edtContratoId_Visible = 1;
         Combo_contratoid_Datalistprocparametersprefix = " \"ComboName\": \"ContratoId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"PropostaId\": 0";
         Combo_contratoid_Datalistproc = "PropostaCLoadDVCombo";
         Combo_contratoid_Cls = "ExtendedCombo AttributeFL";
         Combo_contratoid_Caption = "";
         Combo_contratoid_Enabled = Convert.ToBoolean( -1);
         cmbPropostaStatus_Jsonclick = "";
         cmbPropostaStatus.Enabled = 1;
         edtPropostaCratedBy_Jsonclick = "";
         edtPropostaCratedBy_Enabled = 1;
         edtPropostaCratedBy_Visible = 1;
         Combo_propostacratedby_Datalistprocparametersprefix = " \"ComboName\": \"PropostaCratedBy\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"PropostaId\": 0";
         Combo_propostacratedby_Datalistproc = "PropostaCLoadDVCombo";
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
         n341PropostaAprovacoes_F = false;
         n342PropostaReprovacoes_F = false;
         /* Using cursor T001L31 */
         pr_default.execute(22, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(22) != 101) )
         {
            A341PropostaAprovacoes_F = T001L31_A341PropostaAprovacoes_F[0];
            n341PropostaAprovacoes_F = T001L31_n341PropostaAprovacoes_F[0];
         }
         else
         {
            A341PropostaAprovacoes_F = 0;
            n341PropostaAprovacoes_F = false;
         }
         pr_default.close(22);
         /* Using cursor T001L33 */
         pr_default.execute(23, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(23) != 101) )
         {
            A342PropostaReprovacoes_F = T001L33_A342PropostaReprovacoes_F[0];
            n342PropostaReprovacoes_F = T001L33_n342PropostaReprovacoes_F[0];
         }
         else
         {
            A342PropostaReprovacoes_F = 0;
            n342PropostaReprovacoes_F = false;
         }
         pr_default.close(23);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A341PropostaAprovacoes_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A341PropostaAprovacoes_F), 4, 0, ".", "")));
         AssignAttri("", false, "A342PropostaReprovacoes_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A342PropostaReprovacoes_F), 4, 0, ".", "")));
      }

      public void Valid_Propostacratedby( )
      {
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
         /* Using cursor T001L44 */
         pr_default.execute(34, new Object[] {n328PropostaCratedBy, A328PropostaCratedBy});
         if ( (pr_default.getStatus(34) == 101) )
         {
            if ( ! ( (0==A328PropostaCratedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sec User Proposta'.", "ForeignKeyNotFound", 1, "PROPOSTACRATEDBY");
               AnyError = 1;
               GX_FocusControl = edtPropostaCratedBy_Internalname;
            }
         }
         pr_default.close(34);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A328PropostaCratedBy", ((0==A328PropostaCratedBy)&&IsIns( )||n328PropostaCratedBy ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A328PropostaCratedBy), 4, 0, ".", ""))));
      }

      public void Valid_Contratoid( )
      {
         n228ContratoNome = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_ContratoId) )
         {
            A227ContratoId = AV12Insert_ContratoId;
            n227ContratoId = false;
         }
         else
         {
            if ( (0==AV22ComboContratoId) )
            {
               A227ContratoId = 0;
               n227ContratoId = false;
               n227ContratoId = true;
               n227ContratoId = true;
            }
            else
            {
               if ( ! (0==AV22ComboContratoId) )
               {
                  A227ContratoId = AV22ComboContratoId;
                  n227ContratoId = false;
               }
               else
               {
                  if ( (0==A227ContratoId) )
                  {
                     A227ContratoId = 0;
                     n227ContratoId = false;
                     n227ContratoId = true;
                     n227ContratoId = true;
                  }
               }
            }
         }
         /* Using cursor T001L34 */
         pr_default.execute(24, new Object[] {n227ContratoId, A227ContratoId});
         if ( (pr_default.getStatus(24) == 101) )
         {
            if ( ! ( (0==A227ContratoId) ) )
            {
               GX_msglist.addItem("Não existe 'Contrato'.", "ForeignKeyNotFound", 1, "CONTRATOID");
               AnyError = 1;
               GX_FocusControl = edtContratoId_Internalname;
            }
         }
         A228ContratoNome = T001L34_A228ContratoNome[0];
         n228ContratoNome = T001L34_n228ContratoNome[0];
         pr_default.close(24);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A227ContratoId", ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
         AssignAttri("", false, "A228ContratoNome", A228ContratoNome);
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
         /* Using cursor T001L45 */
         pr_default.execute(35, new Object[] {n376ProcedimentosMedicosId, A376ProcedimentosMedicosId});
         if ( (pr_default.getStatus(35) == 101) )
         {
            if ( ! ( (0==A376ProcedimentosMedicosId) ) )
            {
               GX_msglist.addItem("Não existe 'ProcedimentosMedicos'.", "ForeignKeyNotFound", 1, "PROCEDIMENTOSMEDICOSID");
               AnyError = 1;
               GX_FocusControl = edtProcedimentosMedicosId_Internalname;
            }
         }
         pr_default.close(35);
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"AV7PropostaId","fld":"vPROPOSTAID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV24Insert_ProcedimentosMedicosId","fld":"vINSERT_PROCEDIMENTOSMEDICOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV11Insert_PropostaCratedBy","fld":"vINSERT_PROPOSTACRATEDBY","pic":"ZZZ9","type":"int"},{"av":"AV12Insert_ContratoId","fld":"vINSERT_CONTRATOID","pic":"ZZZZZ9","type":"int"},{"av":"AV29Insert_PropostaPacienteClienteId","fld":"vINSERT_PROPOSTAPACIENTECLIENTEID","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E121L2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV9TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""}]}""");
         setEventMetadata("VALID_PROPOSTAVALOR","""{"handler":"Valid_Propostavalor","iparms":[]}""");
         setEventMetadata("VALID_PROPOSTACRATEDBY","""{"handler":"Valid_Propostacratedby","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV11Insert_PropostaCratedBy","fld":"vINSERT_PROPOSTACRATEDBY","pic":"ZZZ9","type":"int"},{"av":"AV19ComboPropostaCratedBy","fld":"vCOMBOPROPOSTACRATEDBY","pic":"ZZZ9","type":"int"},{"av":"A328PropostaCratedBy","fld":"PROPOSTACRATEDBY","pic":"ZZZ9","nullAv":"n328PropostaCratedBy","type":"int"}]""");
         setEventMetadata("VALID_PROPOSTACRATEDBY",""","oparms":[{"av":"A328PropostaCratedBy","fld":"PROPOSTACRATEDBY","pic":"ZZZ9","nullAv":"n328PropostaCratedBy","type":"int"}]}""");
         setEventMetadata("VALID_PROPOSTASTATUS","""{"handler":"Valid_Propostastatus","iparms":[]}""");
         setEventMetadata("VALID_CONTRATOID","""{"handler":"Valid_Contratoid","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV12Insert_ContratoId","fld":"vINSERT_CONTRATOID","pic":"ZZZZZ9","type":"int"},{"av":"AV22ComboContratoId","fld":"vCOMBOCONTRATOID","pic":"ZZZZZ9","type":"int"},{"av":"A227ContratoId","fld":"CONTRATOID","pic":"ZZZZZ9","nullAv":"n227ContratoId","type":"int"},{"av":"A228ContratoNome","fld":"CONTRATONOME","type":"svchar"}]""");
         setEventMetadata("VALID_CONTRATOID",""","oparms":[{"av":"A227ContratoId","fld":"CONTRATOID","pic":"ZZZZZ9","nullAv":"n227ContratoId","type":"int"},{"av":"A228ContratoNome","fld":"CONTRATONOME","type":"svchar"}]}""");
         setEventMetadata("VALID_PROPOSTAQUANTIDADEAPROVADORES","""{"handler":"Valid_Propostaquantidadeaprovadores","iparms":[]}""");
         setEventMetadata("VALID_PROCEDIMENTOSMEDICOSID","""{"handler":"Valid_Procedimentosmedicosid","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV24Insert_ProcedimentosMedicosId","fld":"vINSERT_PROCEDIMENTOSMEDICOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28ComboProcedimentosMedicosId","fld":"vCOMBOPROCEDIMENTOSMEDICOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A376ProcedimentosMedicosId","fld":"PROCEDIMENTOSMEDICOSID","pic":"ZZZZZZZZ9","nullAv":"n376ProcedimentosMedicosId","type":"int"}]""");
         setEventMetadata("VALID_PROCEDIMENTOSMEDICOSID",""","oparms":[{"av":"A376ProcedimentosMedicosId","fld":"PROCEDIMENTOSMEDICOSID","pic":"ZZZZZZZZ9","nullAv":"n376ProcedimentosMedicosId","type":"int"}]}""");
         setEventMetadata("VALID_PROPOSTAAPROVACOES_F","""{"handler":"Valid_Propostaaprovacoes_f","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOPROPOSTACRATEDBY","""{"handler":"Validv_Combopropostacratedby","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOCONTRATOID","""{"handler":"Validv_Combocontratoid","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOPROCEDIMENTOSMEDICOSID","""{"handler":"Validv_Comboprocedimentosmedicosid","iparms":[]}""");
         setEventMetadata("VALID_PROPOSTAID","""{"handler":"Valid_Propostaid","iparms":[{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A341PropostaAprovacoes_F","fld":"PROPOSTAAPROVACOES_F","pic":"ZZZ9","type":"int"},{"av":"A342PropostaReprovacoes_F","fld":"PROPOSTAREPROVACOES_F","pic":"ZZZ9","type":"int"}]""");
         setEventMetadata("VALID_PROPOSTAID",""","oparms":[{"av":"A341PropostaAprovacoes_F","fld":"PROPOSTAAPROVACOES_F","pic":"ZZZ9","type":"int"},{"av":"A342PropostaReprovacoes_F","fld":"PROPOSTAREPROVACOES_F","pic":"ZZZ9","type":"int"}]}""");
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
         pr_default.close(24);
         pr_default.close(35);
         pr_default.close(34);
         pr_default.close(25);
         pr_default.close(22);
         pr_default.close(23);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         Z324PropostaTitulo = "";
         Z325PropostaDescricao = "";
         Z329PropostaStatus = "";
         Combo_procedimentosmedicosid_Selectedvalue_get = "";
         Combo_contratoid_Selectedvalue_get = "";
         Combo_propostacratedby_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
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
         lblTextblockcontratoid_Jsonclick = "";
         ucCombo_contratoid = new GXUserControl();
         AV21ContratoId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockprocedimentosmedicosid_Jsonclick = "";
         ucCombo_procedimentosmedicosid = new GXUserControl();
         AV27ProcedimentosMedicosId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A228ContratoNome = "";
         A505PropostaPacienteClienteRazaoSocial = "";
         AV30Pgmname = "";
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
         Combo_contratoid_Objectcall = "";
         Combo_contratoid_Class = "";
         Combo_contratoid_Icontype = "";
         Combo_contratoid_Icon = "";
         Combo_contratoid_Tooltip = "";
         Combo_contratoid_Selectedvalue_set = "";
         Combo_contratoid_Selectedtext_set = "";
         Combo_contratoid_Selectedtext_get = "";
         Combo_contratoid_Gamoauthtoken = "";
         Combo_contratoid_Ddointernalname = "";
         Combo_contratoid_Titlecontrolalign = "";
         Combo_contratoid_Dropdownoptionstype = "";
         Combo_contratoid_Titlecontrolidtoreplace = "";
         Combo_contratoid_Datalisttype = "";
         Combo_contratoid_Datalistfixedvalues = "";
         Combo_contratoid_Remoteservicesparameters = "";
         Combo_contratoid_Htmltemplate = "";
         Combo_contratoid_Multiplevaluestype = "";
         Combo_contratoid_Loadingdata = "";
         Combo_contratoid_Noresultsfound = "";
         Combo_contratoid_Emptyitemtext = "";
         Combo_contratoid_Onlyselectedvalues = "";
         Combo_contratoid_Selectalltext = "";
         Combo_contratoid_Multiplevaluesseparator = "";
         Combo_contratoid_Addnewoptiontext = "";
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
         Z505PropostaPacienteClienteRazaoSocial = "";
         Z228ContratoNome = "";
         T001L9_A341PropostaAprovacoes_F = new short[1] ;
         T001L9_n341PropostaAprovacoes_F = new bool[] {false} ;
         T001L11_A342PropostaReprovacoes_F = new short[1] ;
         T001L11_n342PropostaReprovacoes_F = new bool[] {false} ;
         T001L7_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         T001L7_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         T001L14_A323PropostaId = new int[1] ;
         T001L14_n323PropostaId = new bool[] {false} ;
         T001L14_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T001L14_n327PropostaCreatedAt = new bool[] {false} ;
         T001L14_A324PropostaTitulo = new string[] {""} ;
         T001L14_n324PropostaTitulo = new bool[] {false} ;
         T001L14_A325PropostaDescricao = new string[] {""} ;
         T001L14_n325PropostaDescricao = new bool[] {false} ;
         T001L14_A326PropostaValor = new decimal[1] ;
         T001L14_n326PropostaValor = new bool[] {false} ;
         T001L14_A329PropostaStatus = new string[] {""} ;
         T001L14_n329PropostaStatus = new bool[] {false} ;
         T001L14_A228ContratoNome = new string[] {""} ;
         T001L14_n228ContratoNome = new bool[] {false} ;
         T001L14_A330PropostaQuantidadeAprovadores = new short[1] ;
         T001L14_n330PropostaQuantidadeAprovadores = new bool[] {false} ;
         T001L14_A345PropostaReprovacoesPermitidas = new short[1] ;
         T001L14_n345PropostaReprovacoesPermitidas = new bool[] {false} ;
         T001L14_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         T001L14_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         T001L14_A227ContratoId = new int[1] ;
         T001L14_n227ContratoId = new bool[] {false} ;
         T001L14_A376ProcedimentosMedicosId = new int[1] ;
         T001L14_n376ProcedimentosMedicosId = new bool[] {false} ;
         T001L14_A328PropostaCratedBy = new short[1] ;
         T001L14_n328PropostaCratedBy = new bool[] {false} ;
         T001L14_A504PropostaPacienteClienteId = new int[1] ;
         T001L14_n504PropostaPacienteClienteId = new bool[] {false} ;
         T001L14_A341PropostaAprovacoes_F = new short[1] ;
         T001L14_n341PropostaAprovacoes_F = new bool[] {false} ;
         T001L14_A342PropostaReprovacoes_F = new short[1] ;
         T001L14_n342PropostaReprovacoes_F = new bool[] {false} ;
         T001L5_A376ProcedimentosMedicosId = new int[1] ;
         T001L5_n376ProcedimentosMedicosId = new bool[] {false} ;
         T001L6_A328PropostaCratedBy = new short[1] ;
         T001L6_n328PropostaCratedBy = new bool[] {false} ;
         T001L4_A228ContratoNome = new string[] {""} ;
         T001L4_n228ContratoNome = new bool[] {false} ;
         T001L16_A341PropostaAprovacoes_F = new short[1] ;
         T001L16_n341PropostaAprovacoes_F = new bool[] {false} ;
         T001L18_A342PropostaReprovacoes_F = new short[1] ;
         T001L18_n342PropostaReprovacoes_F = new bool[] {false} ;
         T001L19_A376ProcedimentosMedicosId = new int[1] ;
         T001L19_n376ProcedimentosMedicosId = new bool[] {false} ;
         T001L20_A328PropostaCratedBy = new short[1] ;
         T001L20_n328PropostaCratedBy = new bool[] {false} ;
         T001L21_A228ContratoNome = new string[] {""} ;
         T001L21_n228ContratoNome = new bool[] {false} ;
         T001L22_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         T001L22_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         T001L23_A323PropostaId = new int[1] ;
         T001L23_n323PropostaId = new bool[] {false} ;
         T001L3_A323PropostaId = new int[1] ;
         T001L3_n323PropostaId = new bool[] {false} ;
         T001L3_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T001L3_n327PropostaCreatedAt = new bool[] {false} ;
         T001L3_A324PropostaTitulo = new string[] {""} ;
         T001L3_n324PropostaTitulo = new bool[] {false} ;
         T001L3_A325PropostaDescricao = new string[] {""} ;
         T001L3_n325PropostaDescricao = new bool[] {false} ;
         T001L3_A326PropostaValor = new decimal[1] ;
         T001L3_n326PropostaValor = new bool[] {false} ;
         T001L3_A329PropostaStatus = new string[] {""} ;
         T001L3_n329PropostaStatus = new bool[] {false} ;
         T001L3_A330PropostaQuantidadeAprovadores = new short[1] ;
         T001L3_n330PropostaQuantidadeAprovadores = new bool[] {false} ;
         T001L3_A345PropostaReprovacoesPermitidas = new short[1] ;
         T001L3_n345PropostaReprovacoesPermitidas = new bool[] {false} ;
         T001L3_A227ContratoId = new int[1] ;
         T001L3_n227ContratoId = new bool[] {false} ;
         T001L3_A376ProcedimentosMedicosId = new int[1] ;
         T001L3_n376ProcedimentosMedicosId = new bool[] {false} ;
         T001L3_A328PropostaCratedBy = new short[1] ;
         T001L3_n328PropostaCratedBy = new bool[] {false} ;
         T001L3_A504PropostaPacienteClienteId = new int[1] ;
         T001L3_n504PropostaPacienteClienteId = new bool[] {false} ;
         T001L24_A323PropostaId = new int[1] ;
         T001L24_n323PropostaId = new bool[] {false} ;
         T001L25_A323PropostaId = new int[1] ;
         T001L25_n323PropostaId = new bool[] {false} ;
         T001L2_A323PropostaId = new int[1] ;
         T001L2_n323PropostaId = new bool[] {false} ;
         T001L2_A327PropostaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T001L2_n327PropostaCreatedAt = new bool[] {false} ;
         T001L2_A324PropostaTitulo = new string[] {""} ;
         T001L2_n324PropostaTitulo = new bool[] {false} ;
         T001L2_A325PropostaDescricao = new string[] {""} ;
         T001L2_n325PropostaDescricao = new bool[] {false} ;
         T001L2_A326PropostaValor = new decimal[1] ;
         T001L2_n326PropostaValor = new bool[] {false} ;
         T001L2_A329PropostaStatus = new string[] {""} ;
         T001L2_n329PropostaStatus = new bool[] {false} ;
         T001L2_A330PropostaQuantidadeAprovadores = new short[1] ;
         T001L2_n330PropostaQuantidadeAprovadores = new bool[] {false} ;
         T001L2_A345PropostaReprovacoesPermitidas = new short[1] ;
         T001L2_n345PropostaReprovacoesPermitidas = new bool[] {false} ;
         T001L2_A227ContratoId = new int[1] ;
         T001L2_n227ContratoId = new bool[] {false} ;
         T001L2_A376ProcedimentosMedicosId = new int[1] ;
         T001L2_n376ProcedimentosMedicosId = new bool[] {false} ;
         T001L2_A328PropostaCratedBy = new short[1] ;
         T001L2_n328PropostaCratedBy = new bool[] {false} ;
         T001L2_A504PropostaPacienteClienteId = new int[1] ;
         T001L2_n504PropostaPacienteClienteId = new bool[] {false} ;
         T001L27_A323PropostaId = new int[1] ;
         T001L27_n323PropostaId = new bool[] {false} ;
         T001L31_A341PropostaAprovacoes_F = new short[1] ;
         T001L31_n341PropostaAprovacoes_F = new bool[] {false} ;
         T001L33_A342PropostaReprovacoes_F = new short[1] ;
         T001L33_n342PropostaReprovacoes_F = new bool[] {false} ;
         T001L34_A228ContratoNome = new string[] {""} ;
         T001L34_n228ContratoNome = new bool[] {false} ;
         T001L35_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         T001L35_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         T001L36_A227ContratoId = new int[1] ;
         T001L36_n227ContratoId = new bool[] {false} ;
         T001L37_A518ReembolsoId = new int[1] ;
         T001L38_A261TituloId = new int[1] ;
         T001L39_A830NotaFiscalItemId = new Guid[] {Guid.Empty} ;
         T001L40_A572PropostaContratoAssinaturaId = new int[1] ;
         T001L41_A414PropostaDocumentosId = new int[1] ;
         T001L42_A336AprovacaoId = new int[1] ;
         T001L43_A323PropostaId = new int[1] ;
         T001L43_n323PropostaId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i327PropostaCreatedAt = (DateTime)(DateTime.MinValue);
         T001L44_A328PropostaCratedBy = new short[1] ;
         T001L44_n328PropostaCratedBy = new bool[] {false} ;
         T001L45_A376ProcedimentosMedicosId = new int[1] ;
         T001L45_n376ProcedimentosMedicosId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.propostac__default(),
            new Object[][] {
                new Object[] {
               T001L2_A323PropostaId, T001L2_A327PropostaCreatedAt, T001L2_n327PropostaCreatedAt, T001L2_A324PropostaTitulo, T001L2_n324PropostaTitulo, T001L2_A325PropostaDescricao, T001L2_n325PropostaDescricao, T001L2_A326PropostaValor, T001L2_n326PropostaValor, T001L2_A329PropostaStatus,
               T001L2_n329PropostaStatus, T001L2_A330PropostaQuantidadeAprovadores, T001L2_n330PropostaQuantidadeAprovadores, T001L2_A345PropostaReprovacoesPermitidas, T001L2_n345PropostaReprovacoesPermitidas, T001L2_A227ContratoId, T001L2_n227ContratoId, T001L2_A376ProcedimentosMedicosId, T001L2_n376ProcedimentosMedicosId, T001L2_A328PropostaCratedBy,
               T001L2_n328PropostaCratedBy, T001L2_A504PropostaPacienteClienteId, T001L2_n504PropostaPacienteClienteId
               }
               , new Object[] {
               T001L3_A323PropostaId, T001L3_A327PropostaCreatedAt, T001L3_n327PropostaCreatedAt, T001L3_A324PropostaTitulo, T001L3_n324PropostaTitulo, T001L3_A325PropostaDescricao, T001L3_n325PropostaDescricao, T001L3_A326PropostaValor, T001L3_n326PropostaValor, T001L3_A329PropostaStatus,
               T001L3_n329PropostaStatus, T001L3_A330PropostaQuantidadeAprovadores, T001L3_n330PropostaQuantidadeAprovadores, T001L3_A345PropostaReprovacoesPermitidas, T001L3_n345PropostaReprovacoesPermitidas, T001L3_A227ContratoId, T001L3_n227ContratoId, T001L3_A376ProcedimentosMedicosId, T001L3_n376ProcedimentosMedicosId, T001L3_A328PropostaCratedBy,
               T001L3_n328PropostaCratedBy, T001L3_A504PropostaPacienteClienteId, T001L3_n504PropostaPacienteClienteId
               }
               , new Object[] {
               T001L4_A228ContratoNome, T001L4_n228ContratoNome
               }
               , new Object[] {
               T001L5_A376ProcedimentosMedicosId
               }
               , new Object[] {
               T001L6_A328PropostaCratedBy
               }
               , new Object[] {
               T001L7_A505PropostaPacienteClienteRazaoSocial, T001L7_n505PropostaPacienteClienteRazaoSocial
               }
               , new Object[] {
               T001L9_A341PropostaAprovacoes_F, T001L9_n341PropostaAprovacoes_F
               }
               , new Object[] {
               T001L11_A342PropostaReprovacoes_F, T001L11_n342PropostaReprovacoes_F
               }
               , new Object[] {
               T001L14_A323PropostaId, T001L14_A327PropostaCreatedAt, T001L14_n327PropostaCreatedAt, T001L14_A324PropostaTitulo, T001L14_n324PropostaTitulo, T001L14_A325PropostaDescricao, T001L14_n325PropostaDescricao, T001L14_A326PropostaValor, T001L14_n326PropostaValor, T001L14_A329PropostaStatus,
               T001L14_n329PropostaStatus, T001L14_A228ContratoNome, T001L14_n228ContratoNome, T001L14_A330PropostaQuantidadeAprovadores, T001L14_n330PropostaQuantidadeAprovadores, T001L14_A345PropostaReprovacoesPermitidas, T001L14_n345PropostaReprovacoesPermitidas, T001L14_A505PropostaPacienteClienteRazaoSocial, T001L14_n505PropostaPacienteClienteRazaoSocial, T001L14_A227ContratoId,
               T001L14_n227ContratoId, T001L14_A376ProcedimentosMedicosId, T001L14_n376ProcedimentosMedicosId, T001L14_A328PropostaCratedBy, T001L14_n328PropostaCratedBy, T001L14_A504PropostaPacienteClienteId, T001L14_n504PropostaPacienteClienteId, T001L14_A341PropostaAprovacoes_F, T001L14_n341PropostaAprovacoes_F, T001L14_A342PropostaReprovacoes_F,
               T001L14_n342PropostaReprovacoes_F
               }
               , new Object[] {
               T001L16_A341PropostaAprovacoes_F, T001L16_n341PropostaAprovacoes_F
               }
               , new Object[] {
               T001L18_A342PropostaReprovacoes_F, T001L18_n342PropostaReprovacoes_F
               }
               , new Object[] {
               T001L19_A376ProcedimentosMedicosId
               }
               , new Object[] {
               T001L20_A328PropostaCratedBy
               }
               , new Object[] {
               T001L21_A228ContratoNome, T001L21_n228ContratoNome
               }
               , new Object[] {
               T001L22_A505PropostaPacienteClienteRazaoSocial, T001L22_n505PropostaPacienteClienteRazaoSocial
               }
               , new Object[] {
               T001L23_A323PropostaId
               }
               , new Object[] {
               T001L24_A323PropostaId
               }
               , new Object[] {
               T001L25_A323PropostaId
               }
               , new Object[] {
               }
               , new Object[] {
               T001L27_A323PropostaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001L31_A341PropostaAprovacoes_F, T001L31_n341PropostaAprovacoes_F
               }
               , new Object[] {
               T001L33_A342PropostaReprovacoes_F, T001L33_n342PropostaReprovacoes_F
               }
               , new Object[] {
               T001L34_A228ContratoNome, T001L34_n228ContratoNome
               }
               , new Object[] {
               T001L35_A505PropostaPacienteClienteRazaoSocial, T001L35_n505PropostaPacienteClienteRazaoSocial
               }
               , new Object[] {
               T001L36_A227ContratoId
               }
               , new Object[] {
               T001L37_A518ReembolsoId
               }
               , new Object[] {
               T001L38_A261TituloId
               }
               , new Object[] {
               T001L39_A830NotaFiscalItemId
               }
               , new Object[] {
               T001L40_A572PropostaContratoAssinaturaId
               }
               , new Object[] {
               T001L41_A414PropostaDocumentosId
               }
               , new Object[] {
               T001L42_A336AprovacaoId
               }
               , new Object[] {
               T001L43_A323PropostaId
               }
               , new Object[] {
               T001L44_A328PropostaCratedBy
               }
               , new Object[] {
               T001L45_A376ProcedimentosMedicosId
               }
            }
         );
         AV30Pgmname = "PropostaC";
      }

      private short Z330PropostaQuantidadeAprovadores ;
      private short Z345PropostaReprovacoesPermitidas ;
      private short Z328PropostaCratedBy ;
      private short N328PropostaCratedBy ;
      private short GxWebError ;
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
      private short AV11Insert_PropostaCratedBy ;
      private short RcdFound49 ;
      private short Z341PropostaAprovacoes_F ;
      private short Z342PropostaReprovacoes_F ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7PropostaId ;
      private int Z323PropostaId ;
      private int Z227ContratoId ;
      private int Z376ProcedimentosMedicosId ;
      private int Z504PropostaPacienteClienteId ;
      private int N376ProcedimentosMedicosId ;
      private int N227ContratoId ;
      private int N504PropostaPacienteClienteId ;
      private int A323PropostaId ;
      private int A376ProcedimentosMedicosId ;
      private int A227ContratoId ;
      private int A504PropostaPacienteClienteId ;
      private int AV7PropostaId ;
      private int trnEnded ;
      private int edtPropostaTitulo_Enabled ;
      private int edtPropostaDescricao_Enabled ;
      private int edtPropostaValor_Enabled ;
      private int edtPropostaCreatedAt_Enabled ;
      private int edtPropostaCratedBy_Visible ;
      private int edtPropostaCratedBy_Enabled ;
      private int edtContratoId_Visible ;
      private int edtContratoId_Enabled ;
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
      private int AV22ComboContratoId ;
      private int edtavCombocontratoid_Enabled ;
      private int edtavCombocontratoid_Visible ;
      private int AV28ComboProcedimentosMedicosId ;
      private int edtavComboprocedimentosmedicosid_Enabled ;
      private int edtavComboprocedimentosmedicosid_Visible ;
      private int edtPropostaId_Enabled ;
      private int edtPropostaId_Visible ;
      private int AV24Insert_ProcedimentosMedicosId ;
      private int AV12Insert_ContratoId ;
      private int AV29Insert_PropostaPacienteClienteId ;
      private int Combo_propostacratedby_Datalistupdateminimumcharacters ;
      private int Combo_propostacratedby_Gxcontroltype ;
      private int Combo_contratoid_Datalistupdateminimumcharacters ;
      private int Combo_contratoid_Gxcontroltype ;
      private int Combo_procedimentosmedicosid_Datalistupdateminimumcharacters ;
      private int Combo_procedimentosmedicosid_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV31GXV1 ;
      private int idxLst ;
      private decimal Z326PropostaValor ;
      private decimal A326PropostaValor ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_procedimentosmedicosid_Selectedvalue_get ;
      private string Combo_contratoid_Selectedvalue_get ;
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
      private string divTablesplittedcontratoid_Internalname ;
      private string lblTextblockcontratoid_Internalname ;
      private string lblTextblockcontratoid_Jsonclick ;
      private string Combo_contratoid_Caption ;
      private string Combo_contratoid_Cls ;
      private string Combo_contratoid_Datalistproc ;
      private string Combo_contratoid_Datalistprocparametersprefix ;
      private string Combo_contratoid_Internalname ;
      private string edtContratoId_Internalname ;
      private string edtContratoId_Jsonclick ;
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
      private string divSectionattribute_contratoid_Internalname ;
      private string edtavCombocontratoid_Internalname ;
      private string edtavCombocontratoid_Jsonclick ;
      private string divSectionattribute_procedimentosmedicosid_Internalname ;
      private string edtavComboprocedimentosmedicosid_Internalname ;
      private string edtavComboprocedimentosmedicosid_Jsonclick ;
      private string edtPropostaId_Internalname ;
      private string edtPropostaId_Jsonclick ;
      private string AV30Pgmname ;
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
      private string Combo_contratoid_Objectcall ;
      private string Combo_contratoid_Class ;
      private string Combo_contratoid_Icontype ;
      private string Combo_contratoid_Icon ;
      private string Combo_contratoid_Tooltip ;
      private string Combo_contratoid_Selectedvalue_set ;
      private string Combo_contratoid_Selectedtext_set ;
      private string Combo_contratoid_Selectedtext_get ;
      private string Combo_contratoid_Gamoauthtoken ;
      private string Combo_contratoid_Ddointernalname ;
      private string Combo_contratoid_Titlecontrolalign ;
      private string Combo_contratoid_Dropdownoptionstype ;
      private string Combo_contratoid_Titlecontrolidtoreplace ;
      private string Combo_contratoid_Datalisttype ;
      private string Combo_contratoid_Datalistfixedvalues ;
      private string Combo_contratoid_Remoteservicesparameters ;
      private string Combo_contratoid_Htmltemplate ;
      private string Combo_contratoid_Multiplevaluestype ;
      private string Combo_contratoid_Loadingdata ;
      private string Combo_contratoid_Noresultsfound ;
      private string Combo_contratoid_Emptyitemtext ;
      private string Combo_contratoid_Onlyselectedvalues ;
      private string Combo_contratoid_Selectalltext ;
      private string Combo_contratoid_Multiplevaluesseparator ;
      private string Combo_contratoid_Addnewoptiontext ;
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
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n323PropostaId ;
      private bool n376ProcedimentosMedicosId ;
      private bool n328PropostaCratedBy ;
      private bool n227ContratoId ;
      private bool n504PropostaPacienteClienteId ;
      private bool wbErr ;
      private bool n329PropostaStatus ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n326PropostaValor ;
      private bool n330PropostaQuantidadeAprovadores ;
      private bool n345PropostaReprovacoesPermitidas ;
      private bool n327PropostaCreatedAt ;
      private bool n324PropostaTitulo ;
      private bool n325PropostaDescricao ;
      private bool n228ContratoNome ;
      private bool n505PropostaPacienteClienteRazaoSocial ;
      private bool Combo_propostacratedby_Enabled ;
      private bool Combo_propostacratedby_Visible ;
      private bool Combo_propostacratedby_Allowmultipleselection ;
      private bool Combo_propostacratedby_Isgriditem ;
      private bool Combo_propostacratedby_Hasdescription ;
      private bool Combo_propostacratedby_Includeonlyselectedoption ;
      private bool Combo_propostacratedby_Includeselectalloption ;
      private bool Combo_propostacratedby_Emptyitem ;
      private bool Combo_propostacratedby_Includeaddnewoption ;
      private bool Combo_contratoid_Enabled ;
      private bool Combo_contratoid_Visible ;
      private bool Combo_contratoid_Allowmultipleselection ;
      private bool Combo_contratoid_Isgriditem ;
      private bool Combo_contratoid_Hasdescription ;
      private bool Combo_contratoid_Includeonlyselectedoption ;
      private bool Combo_contratoid_Includeselectalloption ;
      private bool Combo_contratoid_Emptyitem ;
      private bool Combo_contratoid_Includeaddnewoption ;
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
      private string Z324PropostaTitulo ;
      private string Z325PropostaDescricao ;
      private string Z329PropostaStatus ;
      private string A329PropostaStatus ;
      private string A324PropostaTitulo ;
      private string A325PropostaDescricao ;
      private string A228ContratoNome ;
      private string A505PropostaPacienteClienteRazaoSocial ;
      private string AV16ComboSelectedValue ;
      private string AV17ComboSelectedText ;
      private string Z505PropostaPacienteClienteRazaoSocial ;
      private string Z228ContratoNome ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_propostacratedby ;
      private GXUserControl ucCombo_contratoid ;
      private GXUserControl ucCombo_procedimentosmedicosid ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbPropostaStatus ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV15DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV14PropostaCratedBy_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV21ContratoId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV27ProcedimentosMedicosId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private short[] T001L9_A341PropostaAprovacoes_F ;
      private bool[] T001L9_n341PropostaAprovacoes_F ;
      private short[] T001L11_A342PropostaReprovacoes_F ;
      private bool[] T001L11_n342PropostaReprovacoes_F ;
      private string[] T001L7_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] T001L7_n505PropostaPacienteClienteRazaoSocial ;
      private int[] T001L14_A323PropostaId ;
      private bool[] T001L14_n323PropostaId ;
      private DateTime[] T001L14_A327PropostaCreatedAt ;
      private bool[] T001L14_n327PropostaCreatedAt ;
      private string[] T001L14_A324PropostaTitulo ;
      private bool[] T001L14_n324PropostaTitulo ;
      private string[] T001L14_A325PropostaDescricao ;
      private bool[] T001L14_n325PropostaDescricao ;
      private decimal[] T001L14_A326PropostaValor ;
      private bool[] T001L14_n326PropostaValor ;
      private string[] T001L14_A329PropostaStatus ;
      private bool[] T001L14_n329PropostaStatus ;
      private string[] T001L14_A228ContratoNome ;
      private bool[] T001L14_n228ContratoNome ;
      private short[] T001L14_A330PropostaQuantidadeAprovadores ;
      private bool[] T001L14_n330PropostaQuantidadeAprovadores ;
      private short[] T001L14_A345PropostaReprovacoesPermitidas ;
      private bool[] T001L14_n345PropostaReprovacoesPermitidas ;
      private string[] T001L14_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] T001L14_n505PropostaPacienteClienteRazaoSocial ;
      private int[] T001L14_A227ContratoId ;
      private bool[] T001L14_n227ContratoId ;
      private int[] T001L14_A376ProcedimentosMedicosId ;
      private bool[] T001L14_n376ProcedimentosMedicosId ;
      private short[] T001L14_A328PropostaCratedBy ;
      private bool[] T001L14_n328PropostaCratedBy ;
      private int[] T001L14_A504PropostaPacienteClienteId ;
      private bool[] T001L14_n504PropostaPacienteClienteId ;
      private short[] T001L14_A341PropostaAprovacoes_F ;
      private bool[] T001L14_n341PropostaAprovacoes_F ;
      private short[] T001L14_A342PropostaReprovacoes_F ;
      private bool[] T001L14_n342PropostaReprovacoes_F ;
      private int[] T001L5_A376ProcedimentosMedicosId ;
      private bool[] T001L5_n376ProcedimentosMedicosId ;
      private short[] T001L6_A328PropostaCratedBy ;
      private bool[] T001L6_n328PropostaCratedBy ;
      private string[] T001L4_A228ContratoNome ;
      private bool[] T001L4_n228ContratoNome ;
      private short[] T001L16_A341PropostaAprovacoes_F ;
      private bool[] T001L16_n341PropostaAprovacoes_F ;
      private short[] T001L18_A342PropostaReprovacoes_F ;
      private bool[] T001L18_n342PropostaReprovacoes_F ;
      private int[] T001L19_A376ProcedimentosMedicosId ;
      private bool[] T001L19_n376ProcedimentosMedicosId ;
      private short[] T001L20_A328PropostaCratedBy ;
      private bool[] T001L20_n328PropostaCratedBy ;
      private string[] T001L21_A228ContratoNome ;
      private bool[] T001L21_n228ContratoNome ;
      private string[] T001L22_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] T001L22_n505PropostaPacienteClienteRazaoSocial ;
      private int[] T001L23_A323PropostaId ;
      private bool[] T001L23_n323PropostaId ;
      private int[] T001L3_A323PropostaId ;
      private bool[] T001L3_n323PropostaId ;
      private DateTime[] T001L3_A327PropostaCreatedAt ;
      private bool[] T001L3_n327PropostaCreatedAt ;
      private string[] T001L3_A324PropostaTitulo ;
      private bool[] T001L3_n324PropostaTitulo ;
      private string[] T001L3_A325PropostaDescricao ;
      private bool[] T001L3_n325PropostaDescricao ;
      private decimal[] T001L3_A326PropostaValor ;
      private bool[] T001L3_n326PropostaValor ;
      private string[] T001L3_A329PropostaStatus ;
      private bool[] T001L3_n329PropostaStatus ;
      private short[] T001L3_A330PropostaQuantidadeAprovadores ;
      private bool[] T001L3_n330PropostaQuantidadeAprovadores ;
      private short[] T001L3_A345PropostaReprovacoesPermitidas ;
      private bool[] T001L3_n345PropostaReprovacoesPermitidas ;
      private int[] T001L3_A227ContratoId ;
      private bool[] T001L3_n227ContratoId ;
      private int[] T001L3_A376ProcedimentosMedicosId ;
      private bool[] T001L3_n376ProcedimentosMedicosId ;
      private short[] T001L3_A328PropostaCratedBy ;
      private bool[] T001L3_n328PropostaCratedBy ;
      private int[] T001L3_A504PropostaPacienteClienteId ;
      private bool[] T001L3_n504PropostaPacienteClienteId ;
      private int[] T001L24_A323PropostaId ;
      private bool[] T001L24_n323PropostaId ;
      private int[] T001L25_A323PropostaId ;
      private bool[] T001L25_n323PropostaId ;
      private int[] T001L2_A323PropostaId ;
      private bool[] T001L2_n323PropostaId ;
      private DateTime[] T001L2_A327PropostaCreatedAt ;
      private bool[] T001L2_n327PropostaCreatedAt ;
      private string[] T001L2_A324PropostaTitulo ;
      private bool[] T001L2_n324PropostaTitulo ;
      private string[] T001L2_A325PropostaDescricao ;
      private bool[] T001L2_n325PropostaDescricao ;
      private decimal[] T001L2_A326PropostaValor ;
      private bool[] T001L2_n326PropostaValor ;
      private string[] T001L2_A329PropostaStatus ;
      private bool[] T001L2_n329PropostaStatus ;
      private short[] T001L2_A330PropostaQuantidadeAprovadores ;
      private bool[] T001L2_n330PropostaQuantidadeAprovadores ;
      private short[] T001L2_A345PropostaReprovacoesPermitidas ;
      private bool[] T001L2_n345PropostaReprovacoesPermitidas ;
      private int[] T001L2_A227ContratoId ;
      private bool[] T001L2_n227ContratoId ;
      private int[] T001L2_A376ProcedimentosMedicosId ;
      private bool[] T001L2_n376ProcedimentosMedicosId ;
      private short[] T001L2_A328PropostaCratedBy ;
      private bool[] T001L2_n328PropostaCratedBy ;
      private int[] T001L2_A504PropostaPacienteClienteId ;
      private bool[] T001L2_n504PropostaPacienteClienteId ;
      private int[] T001L27_A323PropostaId ;
      private bool[] T001L27_n323PropostaId ;
      private short[] T001L31_A341PropostaAprovacoes_F ;
      private bool[] T001L31_n341PropostaAprovacoes_F ;
      private short[] T001L33_A342PropostaReprovacoes_F ;
      private bool[] T001L33_n342PropostaReprovacoes_F ;
      private string[] T001L34_A228ContratoNome ;
      private bool[] T001L34_n228ContratoNome ;
      private string[] T001L35_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] T001L35_n505PropostaPacienteClienteRazaoSocial ;
      private int[] T001L36_A227ContratoId ;
      private bool[] T001L36_n227ContratoId ;
      private int[] T001L37_A518ReembolsoId ;
      private int[] T001L38_A261TituloId ;
      private Guid[] T001L39_A830NotaFiscalItemId ;
      private int[] T001L40_A572PropostaContratoAssinaturaId ;
      private int[] T001L41_A414PropostaDocumentosId ;
      private int[] T001L42_A336AprovacaoId ;
      private int[] T001L43_A323PropostaId ;
      private bool[] T001L43_n323PropostaId ;
      private short[] T001L44_A328PropostaCratedBy ;
      private bool[] T001L44_n328PropostaCratedBy ;
      private int[] T001L45_A376ProcedimentosMedicosId ;
      private bool[] T001L45_n376ProcedimentosMedicosId ;
   }

   public class propostac__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[34])
         ,new ForEachCursor(def[35])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT001L2;
          prmT001L2 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001L3;
          prmT001L3 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001L4;
          prmT001L4 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT001L5;
          prmT001L5 = new Object[] {
          new ParDef("ProcedimentosMedicosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001L6;
          prmT001L6 = new Object[] {
          new ParDef("PropostaCratedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT001L7;
          prmT001L7 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001L9;
          prmT001L9 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001L11;
          prmT001L11 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001L14;
          prmT001L14 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001L16;
          prmT001L16 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001L18;
          prmT001L18 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001L19;
          prmT001L19 = new Object[] {
          new ParDef("ProcedimentosMedicosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001L20;
          prmT001L20 = new Object[] {
          new ParDef("PropostaCratedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT001L21;
          prmT001L21 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT001L22;
          prmT001L22 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001L23;
          prmT001L23 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001L24;
          prmT001L24 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001L25;
          prmT001L25 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001L26;
          prmT001L26 = new Object[] {
          new ParDef("PropostaCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("PropostaTitulo",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("PropostaDescricao",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("PropostaValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("PropostaStatus",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("PropostaQuantidadeAprovadores",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("PropostaReprovacoesPermitidas",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("ProcedimentosMedicosId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaCratedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001L27;
          prmT001L27 = new Object[] {
          };
          Object[] prmT001L28;
          prmT001L28 = new Object[] {
          new ParDef("PropostaCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("PropostaTitulo",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("PropostaDescricao",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("PropostaValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("PropostaStatus",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("PropostaQuantidadeAprovadores",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("PropostaReprovacoesPermitidas",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("ProcedimentosMedicosId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaCratedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001L29;
          prmT001L29 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001L31;
          prmT001L31 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001L33;
          prmT001L33 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001L34;
          prmT001L34 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT001L35;
          prmT001L35 = new Object[] {
          new ParDef("PropostaPacienteClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001L36;
          prmT001L36 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001L37;
          prmT001L37 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001L38;
          prmT001L38 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001L39;
          prmT001L39 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001L40;
          prmT001L40 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001L41;
          prmT001L41 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001L42;
          prmT001L42 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001L43;
          prmT001L43 = new Object[] {
          };
          Object[] prmT001L44;
          prmT001L44 = new Object[] {
          new ParDef("PropostaCratedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT001L45;
          prmT001L45 = new Object[] {
          new ParDef("ProcedimentosMedicosId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T001L2", "SELECT PropostaId, PropostaCreatedAt, PropostaTitulo, PropostaDescricao, PropostaValor, PropostaStatus, PropostaQuantidadeAprovadores, PropostaReprovacoesPermitidas, ContratoId, ProcedimentosMedicosId, PropostaCratedBy, PropostaPacienteClienteId FROM Proposta WHERE PropostaId = :PropostaId  FOR UPDATE OF Proposta NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001L2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001L3", "SELECT PropostaId, PropostaCreatedAt, PropostaTitulo, PropostaDescricao, PropostaValor, PropostaStatus, PropostaQuantidadeAprovadores, PropostaReprovacoesPermitidas, ContratoId, ProcedimentosMedicosId, PropostaCratedBy, PropostaPacienteClienteId FROM Proposta WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001L4", "SELECT ContratoNome FROM Contrato WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001L5", "SELECT ProcedimentosMedicosId FROM ProcedimentosMedicos WHERE ProcedimentosMedicosId = :ProcedimentosMedicosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001L6", "SELECT SecUserId AS PropostaCratedBy FROM SecUser WHERE SecUserId = :PropostaCratedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001L7", "SELECT ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial FROM Cliente WHERE ClienteId = :PropostaPacienteClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001L9", "SELECT COALESCE( T1.PropostaAprovacoes_F, 0) AS PropostaAprovacoes_F FROM (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE AprovacaoStatus = ( 'APROVADO') GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001L11", "SELECT COALESCE( T1.PropostaAprovacoes_F, 0) AS PropostaReprovacoes_F FROM (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE AprovacaoStatus = ( 'REPROVADO') GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001L14", "SELECT TM1.PropostaId, TM1.PropostaCreatedAt, TM1.PropostaTitulo, TM1.PropostaDescricao, TM1.PropostaValor, TM1.PropostaStatus, T5.ContratoNome, TM1.PropostaQuantidadeAprovadores, TM1.PropostaReprovacoesPermitidas, T2.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, TM1.ContratoId, TM1.ProcedimentosMedicosId, TM1.PropostaCratedBy AS PropostaCratedBy, TM1.PropostaPacienteClienteId AS PropostaPacienteClienteId, COALESCE( T3.PropostaAprovacoes_F, 0) AS PropostaAprovacoes_F, COALESCE( T4.PropostaAprovacoes_F, 0) AS PropostaReprovacoes_F FROM ((((Proposta TM1 LEFT JOIN Cliente T2 ON T2.ClienteId = TM1.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE (TM1.PropostaId = PropostaId) AND (AprovacaoStatus = ( 'APROVADO')) GROUP BY PropostaId ) T3 ON T3.PropostaId = TM1.PropostaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE (TM1.PropostaId = PropostaId) AND (AprovacaoStatus = ( 'REPROVADO')) GROUP BY PropostaId ) T4 ON T4.PropostaId = TM1.PropostaId) LEFT JOIN Contrato T5 ON T5.ContratoId = TM1.ContratoId) WHERE TM1.PropostaId = :PropostaId ORDER BY TM1.PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L14,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001L16", "SELECT COALESCE( T1.PropostaAprovacoes_F, 0) AS PropostaAprovacoes_F FROM (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE AprovacaoStatus = ( 'APROVADO') GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001L18", "SELECT COALESCE( T1.PropostaAprovacoes_F, 0) AS PropostaReprovacoes_F FROM (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE AprovacaoStatus = ( 'REPROVADO') GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L18,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001L19", "SELECT ProcedimentosMedicosId FROM ProcedimentosMedicos WHERE ProcedimentosMedicosId = :ProcedimentosMedicosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L19,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001L20", "SELECT SecUserId AS PropostaCratedBy FROM SecUser WHERE SecUserId = :PropostaCratedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L20,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001L21", "SELECT ContratoNome FROM Contrato WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L21,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001L22", "SELECT ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial FROM Cliente WHERE ClienteId = :PropostaPacienteClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L22,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001L23", "SELECT PropostaId FROM Proposta WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L23,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001L24", "SELECT PropostaId FROM Proposta WHERE ( PropostaId > :PropostaId) ORDER BY PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L24,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001L25", "SELECT PropostaId FROM Proposta WHERE ( PropostaId < :PropostaId) ORDER BY PropostaId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L25,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001L26", "SAVEPOINT gxupdate;INSERT INTO Proposta(PropostaCreatedAt, PropostaTitulo, PropostaDescricao, PropostaValor, PropostaStatus, PropostaQuantidadeAprovadores, PropostaReprovacoesPermitidas, ContratoId, ProcedimentosMedicosId, PropostaCratedBy, PropostaPacienteClienteId, ConvenioVencimentoAno, ConvenioVencimentoMes, ConvenioCategoriaId, PropostaTaxaAdministrativa, PropostaSLA, PropostaJurosMora, PropostaDataCirurgia, PropostaResponsavelId, PropostaClinicaId, PropostaComentarioAnalise, PropostaProtocolo, PropostaEmpresaClienteId, PropostaTipoProposta, PropostaValorLiquido) VALUES(:PropostaCreatedAt, :PropostaTitulo, :PropostaDescricao, :PropostaValor, :PropostaStatus, :PropostaQuantidadeAprovadores, :PropostaReprovacoesPermitidas, :ContratoId, :ProcedimentosMedicosId, :PropostaCratedBy, :PropostaPacienteClienteId, 0, 0, 0, 0, 0, 0, DATE '00010101', 0, 0, '', '', 0, '', 0);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001L26)
             ,new CursorDef("T001L27", "SELECT currval('PropostaId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L27,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001L28", "SAVEPOINT gxupdate;UPDATE Proposta SET PropostaCreatedAt=:PropostaCreatedAt, PropostaTitulo=:PropostaTitulo, PropostaDescricao=:PropostaDescricao, PropostaValor=:PropostaValor, PropostaStatus=:PropostaStatus, PropostaQuantidadeAprovadores=:PropostaQuantidadeAprovadores, PropostaReprovacoesPermitidas=:PropostaReprovacoesPermitidas, ContratoId=:ContratoId, ProcedimentosMedicosId=:ProcedimentosMedicosId, PropostaCratedBy=:PropostaCratedBy, PropostaPacienteClienteId=:PropostaPacienteClienteId  WHERE PropostaId = :PropostaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001L28)
             ,new CursorDef("T001L29", "SAVEPOINT gxupdate;DELETE FROM Proposta  WHERE PropostaId = :PropostaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001L29)
             ,new CursorDef("T001L31", "SELECT COALESCE( T1.PropostaAprovacoes_F, 0) AS PropostaAprovacoes_F FROM (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE AprovacaoStatus = ( 'APROVADO') GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L31,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001L33", "SELECT COALESCE( T1.PropostaAprovacoes_F, 0) AS PropostaReprovacoes_F FROM (SELECT COUNT(*) AS PropostaAprovacoes_F, PropostaId FROM Aprovacao WHERE AprovacaoStatus = ( 'REPROVADO') GROUP BY PropostaId ) T1 WHERE T1.PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L33,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001L34", "SELECT ContratoNome FROM Contrato WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L34,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001L35", "SELECT ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial FROM Cliente WHERE ClienteId = :PropostaPacienteClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L35,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001L36", "SELECT ContratoId FROM Contrato WHERE ContratoPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L36,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001L37", "SELECT ReembolsoId FROM Reembolso WHERE ReembolsoPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L37,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001L38", "SELECT TituloId FROM Titulo WHERE TituloPropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L38,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001L39", "SELECT NotaFiscalItemId FROM NotaFiscalItem WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L39,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001L40", "SELECT PropostaContratoAssinaturaId FROM PropostaContratoAssinatura WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L40,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001L41", "SELECT PropostaDocumentosId FROM PropostaDocumentos WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L41,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001L42", "SELECT AprovacaoId FROM Aprovacao WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L42,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001L43", "SELECT PropostaId FROM Proposta ORDER BY PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L43,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001L44", "SELECT SecUserId AS PropostaCratedBy FROM SecUser WHERE SecUserId = :PropostaCratedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L44,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001L45", "SELECT ProcedimentosMedicosId FROM ProcedimentosMedicos WHERE ProcedimentosMedicosId = :ProcedimentosMedicosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L45,1, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((int[]) buf[17])[0] = rslt.getInt(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((short[]) buf[19])[0] = rslt.getShort(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                return;
             case 1 :
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
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((int[]) buf[17])[0] = rslt.getInt(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((short[]) buf[19])[0] = rslt.getShort(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
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
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((short[]) buf[15])[0] = rslt.getShort(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((short[]) buf[23])[0] = rslt.getShort(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((int[]) buf[25])[0] = rslt.getInt(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((short[]) buf[27])[0] = rslt.getShort(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((short[]) buf[29])[0] = rslt.getShort(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 25 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 26 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 27 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 28 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 29 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
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
             case 34 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 35 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
