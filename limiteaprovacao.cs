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
   public class limiteaprovacao : GXDataArea
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "limiteaprovacao")), "limiteaprovacao") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "limiteaprovacao")))) ;
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
                  AV7LimiteAprovacaoId = (int)(Math.Round(NumberUtil.Val( GetPar( "LimiteAprovacaoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7LimiteAprovacaoId", StringUtil.LTrimStr( (decimal)(AV7LimiteAprovacaoId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vLIMITEAPROVACAOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7LimiteAprovacaoId), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Limite Aprovacao", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtLimiteAprovacaoValorMinimo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public limiteaprovacao( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public limiteaprovacao( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_LimiteAprovacaoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7LimiteAprovacaoId = aP1_LimiteAprovacaoId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLimiteAprovacaoValorMinimo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLimiteAprovacaoValorMinimo_Internalname, "A partir de", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLimiteAprovacaoValorMinimo_Internalname, ((Convert.ToDecimal(0)==A332LimiteAprovacaoValorMinimo)&&IsIns( )||n332LimiteAprovacaoValorMinimo ? "" : StringUtil.LTrim( StringUtil.NToC( A332LimiteAprovacaoValorMinimo, 18, 2, ",", ""))), ((Convert.ToDecimal(0)==A332LimiteAprovacaoValorMinimo)&&IsIns( )||n332LimiteAprovacaoValorMinimo ? "" : StringUtil.LTrim( ((edtLimiteAprovacaoValorMinimo_Enabled!=0) ? context.localUtil.Format( A332LimiteAprovacaoValorMinimo, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A332LimiteAprovacaoValorMinimo, "ZZZ,ZZZ,ZZZ,ZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLimiteAprovacaoValorMinimo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtLimiteAprovacaoValorMinimo_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_LimiteAprovacao.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLimiteAprovacaoAprovacoes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLimiteAprovacaoAprovacoes_Internalname, "Aprova��es necess�rias", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLimiteAprovacaoAprovacoes_Internalname, ((0==A334LimiteAprovacaoAprovacoes)&&IsIns( )||n334LimiteAprovacaoAprovacoes ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A334LimiteAprovacaoAprovacoes), 4, 0, ",", ""))), ((0==A334LimiteAprovacaoAprovacoes)&&IsIns( )||n334LimiteAprovacaoAprovacoes ? "" : StringUtil.LTrim( ((edtLimiteAprovacaoAprovacoes_Enabled!=0) ? context.localUtil.Format( (decimal)(A334LimiteAprovacaoAprovacoes), "ZZZ9") : context.localUtil.Format( (decimal)(A334LimiteAprovacaoAprovacoes), "ZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLimiteAprovacaoAprovacoes_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtLimiteAprovacaoAprovacoes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LimiteAprovacao.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLimiteAprovacaoReprovacoesPermitidas_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLimiteAprovacaoReprovacoesPermitidas_Internalname, "Reprova��es permitidas", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLimiteAprovacaoReprovacoesPermitidas_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A344LimiteAprovacaoReprovacoesPermitidas), 4, 0, ",", "")), StringUtil.LTrim( ((edtLimiteAprovacaoReprovacoesPermitidas_Enabled!=0) ? context.localUtil.Format( (decimal)(A344LimiteAprovacaoReprovacoesPermitidas), "ZZZ9") : context.localUtil.Format( (decimal)(A344LimiteAprovacaoReprovacoesPermitidas), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLimiteAprovacaoReprovacoesPermitidas_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtLimiteAprovacaoReprovacoesPermitidas_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LimiteAprovacao.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_LimiteAprovacao.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_LimiteAprovacao.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_LimiteAprovacao.htm");
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
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLimiteAprovacaoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A331LimiteAprovacaoId), 9, 0, ",", "")), StringUtil.LTrim( ((edtLimiteAprovacaoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A331LimiteAprovacaoId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A331LimiteAprovacaoId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLimiteAprovacaoId_Jsonclick, 0, "Attribute", "", "", "", "", edtLimiteAprovacaoId_Visible, edtLimiteAprovacaoId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_LimiteAprovacao.htm");
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
         E111B2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z331LimiteAprovacaoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z331LimiteAprovacaoId"), ",", "."), 18, MidpointRounding.ToEven));
               Z332LimiteAprovacaoValorMinimo = context.localUtil.CToN( cgiGet( "Z332LimiteAprovacaoValorMinimo"), ",", ".");
               n332LimiteAprovacaoValorMinimo = ((Convert.ToDecimal(0)==A332LimiteAprovacaoValorMinimo) ? true : false);
               Z334LimiteAprovacaoAprovacoes = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z334LimiteAprovacaoAprovacoes"), ",", "."), 18, MidpointRounding.ToEven));
               n334LimiteAprovacaoAprovacoes = ((0==A334LimiteAprovacaoAprovacoes) ? true : false);
               Z344LimiteAprovacaoReprovacoesPermitidas = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z344LimiteAprovacaoReprovacoesPermitidas"), ",", "."), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7LimiteAprovacaoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vLIMITEAPROVACAOID"), ",", "."), 18, MidpointRounding.ToEven));
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
               n332LimiteAprovacaoValorMinimo = ((StringUtil.StrCmp(cgiGet( edtLimiteAprovacaoValorMinimo_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtLimiteAprovacaoValorMinimo_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLimiteAprovacaoValorMinimo_Internalname), ",", ".") > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LIMITEAPROVACAOVALORMINIMO");
                  AnyError = 1;
                  GX_FocusControl = edtLimiteAprovacaoValorMinimo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A332LimiteAprovacaoValorMinimo = 0;
                  n332LimiteAprovacaoValorMinimo = false;
                  AssignAttri("", false, "A332LimiteAprovacaoValorMinimo", (n332LimiteAprovacaoValorMinimo ? "" : StringUtil.LTrim( StringUtil.NToC( A332LimiteAprovacaoValorMinimo, 18, 2, ".", ""))));
               }
               else
               {
                  A332LimiteAprovacaoValorMinimo = context.localUtil.CToN( cgiGet( edtLimiteAprovacaoValorMinimo_Internalname), ",", ".");
                  AssignAttri("", false, "A332LimiteAprovacaoValorMinimo", (n332LimiteAprovacaoValorMinimo ? "" : StringUtil.LTrim( StringUtil.NToC( A332LimiteAprovacaoValorMinimo, 18, 2, ".", ""))));
               }
               n334LimiteAprovacaoAprovacoes = ((StringUtil.StrCmp(cgiGet( edtLimiteAprovacaoAprovacoes_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtLimiteAprovacaoAprovacoes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLimiteAprovacaoAprovacoes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LIMITEAPROVACAOAPROVACOES");
                  AnyError = 1;
                  GX_FocusControl = edtLimiteAprovacaoAprovacoes_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A334LimiteAprovacaoAprovacoes = 0;
                  n334LimiteAprovacaoAprovacoes = false;
                  AssignAttri("", false, "A334LimiteAprovacaoAprovacoes", (n334LimiteAprovacaoAprovacoes ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A334LimiteAprovacaoAprovacoes), 4, 0, ".", ""))));
               }
               else
               {
                  A334LimiteAprovacaoAprovacoes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtLimiteAprovacaoAprovacoes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A334LimiteAprovacaoAprovacoes", (n334LimiteAprovacaoAprovacoes ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A334LimiteAprovacaoAprovacoes), 4, 0, ".", ""))));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtLimiteAprovacaoReprovacoesPermitidas_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLimiteAprovacaoReprovacoesPermitidas_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LIMITEAPROVACAOREPROVACOESPERMITIDAS");
                  AnyError = 1;
                  GX_FocusControl = edtLimiteAprovacaoReprovacoesPermitidas_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A344LimiteAprovacaoReprovacoesPermitidas = 0;
                  AssignAttri("", false, "A344LimiteAprovacaoReprovacoesPermitidas", StringUtil.LTrimStr( (decimal)(A344LimiteAprovacaoReprovacoesPermitidas), 4, 0));
               }
               else
               {
                  A344LimiteAprovacaoReprovacoesPermitidas = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtLimiteAprovacaoReprovacoesPermitidas_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A344LimiteAprovacaoReprovacoesPermitidas", StringUtil.LTrimStr( (decimal)(A344LimiteAprovacaoReprovacoesPermitidas), 4, 0));
               }
               A331LimiteAprovacaoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtLimiteAprovacaoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A331LimiteAprovacaoId", StringUtil.LTrimStr( (decimal)(A331LimiteAprovacaoId), 9, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"LimiteAprovacao");
               A331LimiteAprovacaoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtLimiteAprovacaoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A331LimiteAprovacaoId", StringUtil.LTrimStr( (decimal)(A331LimiteAprovacaoId), 9, 0));
               forbiddenHiddens.Add("LimiteAprovacaoId", context.localUtil.Format( (decimal)(A331LimiteAprovacaoId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A331LimiteAprovacaoId != Z331LimiteAprovacaoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("limiteaprovacao:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A331LimiteAprovacaoId = (int)(Math.Round(NumberUtil.Val( GetPar( "LimiteAprovacaoId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A331LimiteAprovacaoId", StringUtil.LTrimStr( (decimal)(A331LimiteAprovacaoId), 9, 0));
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
                     sMode50 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode50;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound50 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_1B0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "LIMITEAPROVACAOID");
                        AnyError = 1;
                        GX_FocusControl = edtLimiteAprovacaoId_Internalname;
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
                           E111B2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121B2 ();
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
            E121B2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1B50( ) ;
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
            DisableAttributes1B50( ) ;
         }
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

      protected void CONFIRM_1B0( )
      {
         BeforeValidate1B50( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1B50( ) ;
            }
            else
            {
               CheckExtendedTable1B50( ) ;
               CloseExtendedTableCursors1B50( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption1B0( )
      {
      }

      protected void E111B2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         edtLimiteAprovacaoId_Visible = 0;
         AssignProp("", false, edtLimiteAprovacaoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLimiteAprovacaoId_Visible), 5, 0), true);
      }

      protected void E121B2( )
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

      protected void ZM1B50( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z332LimiteAprovacaoValorMinimo = T001B3_A332LimiteAprovacaoValorMinimo[0];
               Z334LimiteAprovacaoAprovacoes = T001B3_A334LimiteAprovacaoAprovacoes[0];
               Z344LimiteAprovacaoReprovacoesPermitidas = T001B3_A344LimiteAprovacaoReprovacoesPermitidas[0];
            }
            else
            {
               Z332LimiteAprovacaoValorMinimo = A332LimiteAprovacaoValorMinimo;
               Z334LimiteAprovacaoAprovacoes = A334LimiteAprovacaoAprovacoes;
               Z344LimiteAprovacaoReprovacoesPermitidas = A344LimiteAprovacaoReprovacoesPermitidas;
            }
         }
         if ( GX_JID == -6 )
         {
            Z331LimiteAprovacaoId = A331LimiteAprovacaoId;
            Z332LimiteAprovacaoValorMinimo = A332LimiteAprovacaoValorMinimo;
            Z334LimiteAprovacaoAprovacoes = A334LimiteAprovacaoAprovacoes;
            Z344LimiteAprovacaoReprovacoesPermitidas = A344LimiteAprovacaoReprovacoesPermitidas;
         }
      }

      protected void standaloneNotModal( )
      {
         edtLimiteAprovacaoId_Enabled = 0;
         AssignProp("", false, edtLimiteAprovacaoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLimiteAprovacaoId_Enabled), 5, 0), true);
         edtLimiteAprovacaoId_Enabled = 0;
         AssignProp("", false, edtLimiteAprovacaoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLimiteAprovacaoId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7LimiteAprovacaoId) )
         {
            A331LimiteAprovacaoId = AV7LimiteAprovacaoId;
            AssignAttri("", false, "A331LimiteAprovacaoId", StringUtil.LTrimStr( (decimal)(A331LimiteAprovacaoId), 9, 0));
         }
      }

      protected void standaloneModal( )
      {
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
      }

      protected void Load1B50( )
      {
         /* Using cursor T001B4 */
         pr_default.execute(2, new Object[] {A331LimiteAprovacaoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound50 = 1;
            A332LimiteAprovacaoValorMinimo = T001B4_A332LimiteAprovacaoValorMinimo[0];
            n332LimiteAprovacaoValorMinimo = T001B4_n332LimiteAprovacaoValorMinimo[0];
            AssignAttri("", false, "A332LimiteAprovacaoValorMinimo", ((Convert.ToDecimal(0)==A332LimiteAprovacaoValorMinimo)&&IsIns( )||n332LimiteAprovacaoValorMinimo ? "" : StringUtil.LTrim( StringUtil.NToC( A332LimiteAprovacaoValorMinimo, 18, 2, ".", ""))));
            A334LimiteAprovacaoAprovacoes = T001B4_A334LimiteAprovacaoAprovacoes[0];
            n334LimiteAprovacaoAprovacoes = T001B4_n334LimiteAprovacaoAprovacoes[0];
            AssignAttri("", false, "A334LimiteAprovacaoAprovacoes", ((0==A334LimiteAprovacaoAprovacoes)&&IsIns( )||n334LimiteAprovacaoAprovacoes ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A334LimiteAprovacaoAprovacoes), 4, 0, ".", ""))));
            A344LimiteAprovacaoReprovacoesPermitidas = T001B4_A344LimiteAprovacaoReprovacoesPermitidas[0];
            AssignAttri("", false, "A344LimiteAprovacaoReprovacoesPermitidas", StringUtil.LTrimStr( (decimal)(A344LimiteAprovacaoReprovacoesPermitidas), 4, 0));
            ZM1B50( -6) ;
         }
         pr_default.close(2);
         OnLoadActions1B50( ) ;
      }

      protected void OnLoadActions1B50( )
      {
      }

      protected void CheckExtendedTable1B50( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( (Convert.ToDecimal(0)==A332LimiteAprovacaoValorMinimo) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 � obrigat�rio.", "Limite Aprovacao Valor Minimo", "", "", "", "", "", "", "", ""), 1, "LIMITEAPROVACAOVALORMINIMO");
            AnyError = 1;
            GX_FocusControl = edtLimiteAprovacaoValorMinimo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ( A332LimiteAprovacaoValorMinimo < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor n�o pode ser negativo", 1, "LIMITEAPROVACAOVALORMINIMO");
            AnyError = 1;
            GX_FocusControl = edtLimiteAprovacaoValorMinimo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (0==A334LimiteAprovacaoAprovacoes) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 � obrigat�rio.", "Limite Aprovacao Aprovacoes", "", "", "", "", "", "", "", ""), 1, "LIMITEAPROVACAOAPROVACOES");
            AnyError = 1;
            GX_FocusControl = edtLimiteAprovacaoAprovacoes_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1B50( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1B50( )
      {
         /* Using cursor T001B5 */
         pr_default.execute(3, new Object[] {A331LimiteAprovacaoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound50 = 1;
         }
         else
         {
            RcdFound50 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001B3 */
         pr_default.execute(1, new Object[] {A331LimiteAprovacaoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1B50( 6) ;
            RcdFound50 = 1;
            A331LimiteAprovacaoId = T001B3_A331LimiteAprovacaoId[0];
            AssignAttri("", false, "A331LimiteAprovacaoId", StringUtil.LTrimStr( (decimal)(A331LimiteAprovacaoId), 9, 0));
            A332LimiteAprovacaoValorMinimo = T001B3_A332LimiteAprovacaoValorMinimo[0];
            n332LimiteAprovacaoValorMinimo = T001B3_n332LimiteAprovacaoValorMinimo[0];
            AssignAttri("", false, "A332LimiteAprovacaoValorMinimo", ((Convert.ToDecimal(0)==A332LimiteAprovacaoValorMinimo)&&IsIns( )||n332LimiteAprovacaoValorMinimo ? "" : StringUtil.LTrim( StringUtil.NToC( A332LimiteAprovacaoValorMinimo, 18, 2, ".", ""))));
            A334LimiteAprovacaoAprovacoes = T001B3_A334LimiteAprovacaoAprovacoes[0];
            n334LimiteAprovacaoAprovacoes = T001B3_n334LimiteAprovacaoAprovacoes[0];
            AssignAttri("", false, "A334LimiteAprovacaoAprovacoes", ((0==A334LimiteAprovacaoAprovacoes)&&IsIns( )||n334LimiteAprovacaoAprovacoes ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A334LimiteAprovacaoAprovacoes), 4, 0, ".", ""))));
            A344LimiteAprovacaoReprovacoesPermitidas = T001B3_A344LimiteAprovacaoReprovacoesPermitidas[0];
            AssignAttri("", false, "A344LimiteAprovacaoReprovacoesPermitidas", StringUtil.LTrimStr( (decimal)(A344LimiteAprovacaoReprovacoesPermitidas), 4, 0));
            Z331LimiteAprovacaoId = A331LimiteAprovacaoId;
            sMode50 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1B50( ) ;
            if ( AnyError == 1 )
            {
               RcdFound50 = 0;
               InitializeNonKey1B50( ) ;
            }
            Gx_mode = sMode50;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound50 = 0;
            InitializeNonKey1B50( ) ;
            sMode50 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode50;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1B50( ) ;
         if ( RcdFound50 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound50 = 0;
         /* Using cursor T001B6 */
         pr_default.execute(4, new Object[] {A331LimiteAprovacaoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T001B6_A331LimiteAprovacaoId[0] < A331LimiteAprovacaoId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T001B6_A331LimiteAprovacaoId[0] > A331LimiteAprovacaoId ) ) )
            {
               A331LimiteAprovacaoId = T001B6_A331LimiteAprovacaoId[0];
               AssignAttri("", false, "A331LimiteAprovacaoId", StringUtil.LTrimStr( (decimal)(A331LimiteAprovacaoId), 9, 0));
               RcdFound50 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound50 = 0;
         /* Using cursor T001B7 */
         pr_default.execute(5, new Object[] {A331LimiteAprovacaoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T001B7_A331LimiteAprovacaoId[0] > A331LimiteAprovacaoId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T001B7_A331LimiteAprovacaoId[0] < A331LimiteAprovacaoId ) ) )
            {
               A331LimiteAprovacaoId = T001B7_A331LimiteAprovacaoId[0];
               AssignAttri("", false, "A331LimiteAprovacaoId", StringUtil.LTrimStr( (decimal)(A331LimiteAprovacaoId), 9, 0));
               RcdFound50 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1B50( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtLimiteAprovacaoValorMinimo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1B50( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound50 == 1 )
            {
               if ( A331LimiteAprovacaoId != Z331LimiteAprovacaoId )
               {
                  A331LimiteAprovacaoId = Z331LimiteAprovacaoId;
                  AssignAttri("", false, "A331LimiteAprovacaoId", StringUtil.LTrimStr( (decimal)(A331LimiteAprovacaoId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "LIMITEAPROVACAOID");
                  AnyError = 1;
                  GX_FocusControl = edtLimiteAprovacaoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtLimiteAprovacaoValorMinimo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1B50( ) ;
                  GX_FocusControl = edtLimiteAprovacaoValorMinimo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A331LimiteAprovacaoId != Z331LimiteAprovacaoId )
               {
                  /* Insert record */
                  GX_FocusControl = edtLimiteAprovacaoValorMinimo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1B50( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "LIMITEAPROVACAOID");
                     AnyError = 1;
                     GX_FocusControl = edtLimiteAprovacaoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtLimiteAprovacaoValorMinimo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1B50( ) ;
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
         if ( A331LimiteAprovacaoId != Z331LimiteAprovacaoId )
         {
            A331LimiteAprovacaoId = Z331LimiteAprovacaoId;
            AssignAttri("", false, "A331LimiteAprovacaoId", StringUtil.LTrimStr( (decimal)(A331LimiteAprovacaoId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "LIMITEAPROVACAOID");
            AnyError = 1;
            GX_FocusControl = edtLimiteAprovacaoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtLimiteAprovacaoValorMinimo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1B50( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001B2 */
            pr_default.execute(0, new Object[] {A331LimiteAprovacaoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"LimiteAprovacao"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z332LimiteAprovacaoValorMinimo != T001B2_A332LimiteAprovacaoValorMinimo[0] ) || ( Z334LimiteAprovacaoAprovacoes != T001B2_A334LimiteAprovacaoAprovacoes[0] ) || ( Z344LimiteAprovacaoReprovacoesPermitidas != T001B2_A344LimiteAprovacaoReprovacoesPermitidas[0] ) )
            {
               if ( Z332LimiteAprovacaoValorMinimo != T001B2_A332LimiteAprovacaoValorMinimo[0] )
               {
                  GXUtil.WriteLog("limiteaprovacao:[seudo value changed for attri]"+"LimiteAprovacaoValorMinimo");
                  GXUtil.WriteLogRaw("Old: ",Z332LimiteAprovacaoValorMinimo);
                  GXUtil.WriteLogRaw("Current: ",T001B2_A332LimiteAprovacaoValorMinimo[0]);
               }
               if ( Z334LimiteAprovacaoAprovacoes != T001B2_A334LimiteAprovacaoAprovacoes[0] )
               {
                  GXUtil.WriteLog("limiteaprovacao:[seudo value changed for attri]"+"LimiteAprovacaoAprovacoes");
                  GXUtil.WriteLogRaw("Old: ",Z334LimiteAprovacaoAprovacoes);
                  GXUtil.WriteLogRaw("Current: ",T001B2_A334LimiteAprovacaoAprovacoes[0]);
               }
               if ( Z344LimiteAprovacaoReprovacoesPermitidas != T001B2_A344LimiteAprovacaoReprovacoesPermitidas[0] )
               {
                  GXUtil.WriteLog("limiteaprovacao:[seudo value changed for attri]"+"LimiteAprovacaoReprovacoesPermitidas");
                  GXUtil.WriteLogRaw("Old: ",Z344LimiteAprovacaoReprovacoesPermitidas);
                  GXUtil.WriteLogRaw("Current: ",T001B2_A344LimiteAprovacaoReprovacoesPermitidas[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"LimiteAprovacao"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1B50( )
      {
         BeforeValidate1B50( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1B50( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1B50( 0) ;
            CheckOptimisticConcurrency1B50( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1B50( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1B50( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001B8 */
                     pr_default.execute(6, new Object[] {n332LimiteAprovacaoValorMinimo, A332LimiteAprovacaoValorMinimo, n334LimiteAprovacaoAprovacoes, A334LimiteAprovacaoAprovacoes, A344LimiteAprovacaoReprovacoesPermitidas});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor T001B9 */
                     pr_default.execute(7);
                     A331LimiteAprovacaoId = T001B9_A331LimiteAprovacaoId[0];
                     AssignAttri("", false, "A331LimiteAprovacaoId", StringUtil.LTrimStr( (decimal)(A331LimiteAprovacaoId), 9, 0));
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("LimiteAprovacao");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption1B0( ) ;
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
               Load1B50( ) ;
            }
            EndLevel1B50( ) ;
         }
         CloseExtendedTableCursors1B50( ) ;
      }

      protected void Update1B50( )
      {
         BeforeValidate1B50( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1B50( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1B50( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1B50( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1B50( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001B10 */
                     pr_default.execute(8, new Object[] {n332LimiteAprovacaoValorMinimo, A332LimiteAprovacaoValorMinimo, n334LimiteAprovacaoAprovacoes, A334LimiteAprovacaoAprovacoes, A344LimiteAprovacaoReprovacoesPermitidas, A331LimiteAprovacaoId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("LimiteAprovacao");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"LimiteAprovacao"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1B50( ) ;
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
            EndLevel1B50( ) ;
         }
         CloseExtendedTableCursors1B50( ) ;
      }

      protected void DeferredUpdate1B50( )
      {
      }

      protected void delete( )
      {
         BeforeValidate1B50( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1B50( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1B50( ) ;
            AfterConfirm1B50( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1B50( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001B11 */
                  pr_default.execute(9, new Object[] {A331LimiteAprovacaoId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("LimiteAprovacao");
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
         sMode50 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1B50( ) ;
         Gx_mode = sMode50;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1B50( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1B50( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1B50( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("limiteaprovacao",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1B0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("limiteaprovacao",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1B50( )
      {
         /* Scan By routine */
         /* Using cursor T001B12 */
         pr_default.execute(10);
         RcdFound50 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound50 = 1;
            A331LimiteAprovacaoId = T001B12_A331LimiteAprovacaoId[0];
            AssignAttri("", false, "A331LimiteAprovacaoId", StringUtil.LTrimStr( (decimal)(A331LimiteAprovacaoId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1B50( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound50 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound50 = 1;
            A331LimiteAprovacaoId = T001B12_A331LimiteAprovacaoId[0];
            AssignAttri("", false, "A331LimiteAprovacaoId", StringUtil.LTrimStr( (decimal)(A331LimiteAprovacaoId), 9, 0));
         }
      }

      protected void ScanEnd1B50( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm1B50( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1B50( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1B50( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1B50( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1B50( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1B50( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1B50( )
      {
         edtLimiteAprovacaoValorMinimo_Enabled = 0;
         AssignProp("", false, edtLimiteAprovacaoValorMinimo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLimiteAprovacaoValorMinimo_Enabled), 5, 0), true);
         edtLimiteAprovacaoAprovacoes_Enabled = 0;
         AssignProp("", false, edtLimiteAprovacaoAprovacoes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLimiteAprovacaoAprovacoes_Enabled), 5, 0), true);
         edtLimiteAprovacaoReprovacoesPermitidas_Enabled = 0;
         AssignProp("", false, edtLimiteAprovacaoReprovacoesPermitidas_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLimiteAprovacaoReprovacoesPermitidas_Enabled), 5, 0), true);
         edtLimiteAprovacaoId_Enabled = 0;
         AssignProp("", false, edtLimiteAprovacaoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLimiteAprovacaoId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1B50( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1B0( )
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
         GXEncryptionTmp = "limiteaprovacao"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7LimiteAprovacaoId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("limiteaprovacao") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"LimiteAprovacao");
         forbiddenHiddens.Add("LimiteAprovacaoId", context.localUtil.Format( (decimal)(A331LimiteAprovacaoId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("limiteaprovacao:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z331LimiteAprovacaoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z331LimiteAprovacaoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z332LimiteAprovacaoValorMinimo", StringUtil.LTrim( StringUtil.NToC( Z332LimiteAprovacaoValorMinimo, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z334LimiteAprovacaoAprovacoes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z334LimiteAprovacaoAprovacoes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z344LimiteAprovacaoReprovacoesPermitidas", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z344LimiteAprovacaoReprovacoesPermitidas), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vLIMITEAPROVACAOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7LimiteAprovacaoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vLIMITEAPROVACAOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7LimiteAprovacaoId), "ZZZZZZZZ9"), context));
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
         GXEncryptionTmp = "limiteaprovacao"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7LimiteAprovacaoId,9,0));
         return formatLink("limiteaprovacao") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "LimiteAprovacao" ;
      }

      public override string GetPgmdesc( )
      {
         return "Limite Aprovacao" ;
      }

      protected void InitializeNonKey1B50( )
      {
         A332LimiteAprovacaoValorMinimo = 0;
         n332LimiteAprovacaoValorMinimo = false;
         AssignAttri("", false, "A332LimiteAprovacaoValorMinimo", ((Convert.ToDecimal(0)==A332LimiteAprovacaoValorMinimo)&&IsIns( )||n332LimiteAprovacaoValorMinimo ? "" : StringUtil.LTrim( StringUtil.NToC( A332LimiteAprovacaoValorMinimo, 18, 2, ".", ""))));
         n332LimiteAprovacaoValorMinimo = ((Convert.ToDecimal(0)==A332LimiteAprovacaoValorMinimo) ? true : false);
         A334LimiteAprovacaoAprovacoes = 0;
         n334LimiteAprovacaoAprovacoes = false;
         AssignAttri("", false, "A334LimiteAprovacaoAprovacoes", ((0==A334LimiteAprovacaoAprovacoes)&&IsIns( )||n334LimiteAprovacaoAprovacoes ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A334LimiteAprovacaoAprovacoes), 4, 0, ".", ""))));
         n334LimiteAprovacaoAprovacoes = ((0==A334LimiteAprovacaoAprovacoes) ? true : false);
         A344LimiteAprovacaoReprovacoesPermitidas = 0;
         AssignAttri("", false, "A344LimiteAprovacaoReprovacoesPermitidas", StringUtil.LTrimStr( (decimal)(A344LimiteAprovacaoReprovacoesPermitidas), 4, 0));
         Z332LimiteAprovacaoValorMinimo = 0;
         Z334LimiteAprovacaoAprovacoes = 0;
         Z344LimiteAprovacaoReprovacoesPermitidas = 0;
      }

      protected void InitAll1B50( )
      {
         A331LimiteAprovacaoId = 0;
         AssignAttri("", false, "A331LimiteAprovacaoId", StringUtil.LTrimStr( (decimal)(A331LimiteAprovacaoId), 9, 0));
         InitializeNonKey1B50( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019154973", true, true);
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
         context.AddJavascriptSource("limiteaprovacao.js", "?202561019154973", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtLimiteAprovacaoValorMinimo_Internalname = "LIMITEAPROVACAOVALORMINIMO";
         edtLimiteAprovacaoAprovacoes_Internalname = "LIMITEAPROVACAOAPROVACOES";
         edtLimiteAprovacaoReprovacoesPermitidas_Internalname = "LIMITEAPROVACAOREPROVACOESPERMITIDAS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtLimiteAprovacaoId_Internalname = "LIMITEAPROVACAOID";
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
         Form.Caption = "Limite Aprovacao";
         edtLimiteAprovacaoId_Jsonclick = "";
         edtLimiteAprovacaoId_Enabled = 0;
         edtLimiteAprovacaoId_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtLimiteAprovacaoReprovacoesPermitidas_Jsonclick = "";
         edtLimiteAprovacaoReprovacoesPermitidas_Enabled = 1;
         edtLimiteAprovacaoAprovacoes_Jsonclick = "";
         edtLimiteAprovacaoAprovacoes_Enabled = 1;
         edtLimiteAprovacaoValorMinimo_Jsonclick = "";
         edtLimiteAprovacaoValorMinimo_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Informa��es Gerais";
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

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7LimiteAprovacaoId","fld":"vLIMITEAPROVACAOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7LimiteAprovacaoId","fld":"vLIMITEAPROVACAOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A331LimiteAprovacaoId","fld":"LIMITEAPROVACAOID","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E121B2","iparms":[]}""");
         setEventMetadata("VALID_LIMITEAPROVACAOVALORMINIMO","""{"handler":"Valid_Limiteaprovacaovalorminimo","iparms":[]}""");
         setEventMetadata("VALID_LIMITEAPROVACAOAPROVACOES","""{"handler":"Valid_Limiteaprovacaoaprovacoes","iparms":[]}""");
         setEventMetadata("VALID_LIMITEAPROVACAOID","""{"handler":"Valid_Limiteaprovacaoid","iparms":[]}""");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
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
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode50 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         T001B4_A331LimiteAprovacaoId = new int[1] ;
         T001B4_A332LimiteAprovacaoValorMinimo = new decimal[1] ;
         T001B4_n332LimiteAprovacaoValorMinimo = new bool[] {false} ;
         T001B4_A334LimiteAprovacaoAprovacoes = new short[1] ;
         T001B4_n334LimiteAprovacaoAprovacoes = new bool[] {false} ;
         T001B4_A344LimiteAprovacaoReprovacoesPermitidas = new short[1] ;
         T001B5_A331LimiteAprovacaoId = new int[1] ;
         T001B3_A331LimiteAprovacaoId = new int[1] ;
         T001B3_A332LimiteAprovacaoValorMinimo = new decimal[1] ;
         T001B3_n332LimiteAprovacaoValorMinimo = new bool[] {false} ;
         T001B3_A334LimiteAprovacaoAprovacoes = new short[1] ;
         T001B3_n334LimiteAprovacaoAprovacoes = new bool[] {false} ;
         T001B3_A344LimiteAprovacaoReprovacoesPermitidas = new short[1] ;
         T001B6_A331LimiteAprovacaoId = new int[1] ;
         T001B7_A331LimiteAprovacaoId = new int[1] ;
         T001B2_A331LimiteAprovacaoId = new int[1] ;
         T001B2_A332LimiteAprovacaoValorMinimo = new decimal[1] ;
         T001B2_n332LimiteAprovacaoValorMinimo = new bool[] {false} ;
         T001B2_A334LimiteAprovacaoAprovacoes = new short[1] ;
         T001B2_n334LimiteAprovacaoAprovacoes = new bool[] {false} ;
         T001B2_A344LimiteAprovacaoReprovacoesPermitidas = new short[1] ;
         T001B9_A331LimiteAprovacaoId = new int[1] ;
         T001B12_A331LimiteAprovacaoId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.limiteaprovacao__default(),
            new Object[][] {
                new Object[] {
               T001B2_A331LimiteAprovacaoId, T001B2_A332LimiteAprovacaoValorMinimo, T001B2_n332LimiteAprovacaoValorMinimo, T001B2_A334LimiteAprovacaoAprovacoes, T001B2_n334LimiteAprovacaoAprovacoes, T001B2_A344LimiteAprovacaoReprovacoesPermitidas
               }
               , new Object[] {
               T001B3_A331LimiteAprovacaoId, T001B3_A332LimiteAprovacaoValorMinimo, T001B3_n332LimiteAprovacaoValorMinimo, T001B3_A334LimiteAprovacaoAprovacoes, T001B3_n334LimiteAprovacaoAprovacoes, T001B3_A344LimiteAprovacaoReprovacoesPermitidas
               }
               , new Object[] {
               T001B4_A331LimiteAprovacaoId, T001B4_A332LimiteAprovacaoValorMinimo, T001B4_n332LimiteAprovacaoValorMinimo, T001B4_A334LimiteAprovacaoAprovacoes, T001B4_n334LimiteAprovacaoAprovacoes, T001B4_A344LimiteAprovacaoReprovacoesPermitidas
               }
               , new Object[] {
               T001B5_A331LimiteAprovacaoId
               }
               , new Object[] {
               T001B6_A331LimiteAprovacaoId
               }
               , new Object[] {
               T001B7_A331LimiteAprovacaoId
               }
               , new Object[] {
               }
               , new Object[] {
               T001B9_A331LimiteAprovacaoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001B12_A331LimiteAprovacaoId
               }
            }
         );
      }

      private short Z334LimiteAprovacaoAprovacoes ;
      private short Z344LimiteAprovacaoReprovacoesPermitidas ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A334LimiteAprovacaoAprovacoes ;
      private short A344LimiteAprovacaoReprovacoesPermitidas ;
      private short RcdFound50 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7LimiteAprovacaoId ;
      private int Z331LimiteAprovacaoId ;
      private int AV7LimiteAprovacaoId ;
      private int trnEnded ;
      private int edtLimiteAprovacaoValorMinimo_Enabled ;
      private int edtLimiteAprovacaoAprovacoes_Enabled ;
      private int edtLimiteAprovacaoReprovacoesPermitidas_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int A331LimiteAprovacaoId ;
      private int edtLimiteAprovacaoId_Enabled ;
      private int edtLimiteAprovacaoId_Visible ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private decimal Z332LimiteAprovacaoValorMinimo ;
      private decimal A332LimiteAprovacaoValorMinimo ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtLimiteAprovacaoValorMinimo_Internalname ;
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
      private string edtLimiteAprovacaoValorMinimo_Jsonclick ;
      private string edtLimiteAprovacaoAprovacoes_Internalname ;
      private string edtLimiteAprovacaoAprovacoes_Jsonclick ;
      private string edtLimiteAprovacaoReprovacoesPermitidas_Internalname ;
      private string edtLimiteAprovacaoReprovacoesPermitidas_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtLimiteAprovacaoId_Internalname ;
      private string edtLimiteAprovacaoId_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode50 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n332LimiteAprovacaoValorMinimo ;
      private bool n334LimiteAprovacaoAprovacoes ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private int[] T001B4_A331LimiteAprovacaoId ;
      private decimal[] T001B4_A332LimiteAprovacaoValorMinimo ;
      private bool[] T001B4_n332LimiteAprovacaoValorMinimo ;
      private short[] T001B4_A334LimiteAprovacaoAprovacoes ;
      private bool[] T001B4_n334LimiteAprovacaoAprovacoes ;
      private short[] T001B4_A344LimiteAprovacaoReprovacoesPermitidas ;
      private int[] T001B5_A331LimiteAprovacaoId ;
      private int[] T001B3_A331LimiteAprovacaoId ;
      private decimal[] T001B3_A332LimiteAprovacaoValorMinimo ;
      private bool[] T001B3_n332LimiteAprovacaoValorMinimo ;
      private short[] T001B3_A334LimiteAprovacaoAprovacoes ;
      private bool[] T001B3_n334LimiteAprovacaoAprovacoes ;
      private short[] T001B3_A344LimiteAprovacaoReprovacoesPermitidas ;
      private int[] T001B6_A331LimiteAprovacaoId ;
      private int[] T001B7_A331LimiteAprovacaoId ;
      private int[] T001B2_A331LimiteAprovacaoId ;
      private decimal[] T001B2_A332LimiteAprovacaoValorMinimo ;
      private bool[] T001B2_n332LimiteAprovacaoValorMinimo ;
      private short[] T001B2_A334LimiteAprovacaoAprovacoes ;
      private bool[] T001B2_n334LimiteAprovacaoAprovacoes ;
      private short[] T001B2_A344LimiteAprovacaoReprovacoesPermitidas ;
      private int[] T001B9_A331LimiteAprovacaoId ;
      private int[] T001B12_A331LimiteAprovacaoId ;
   }

   public class limiteaprovacao__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT001B2;
          prmT001B2 = new Object[] {
          new ParDef("LimiteAprovacaoId",GXType.Int32,9,0)
          };
          Object[] prmT001B3;
          prmT001B3 = new Object[] {
          new ParDef("LimiteAprovacaoId",GXType.Int32,9,0)
          };
          Object[] prmT001B4;
          prmT001B4 = new Object[] {
          new ParDef("LimiteAprovacaoId",GXType.Int32,9,0)
          };
          Object[] prmT001B5;
          prmT001B5 = new Object[] {
          new ParDef("LimiteAprovacaoId",GXType.Int32,9,0)
          };
          Object[] prmT001B6;
          prmT001B6 = new Object[] {
          new ParDef("LimiteAprovacaoId",GXType.Int32,9,0)
          };
          Object[] prmT001B7;
          prmT001B7 = new Object[] {
          new ParDef("LimiteAprovacaoId",GXType.Int32,9,0)
          };
          Object[] prmT001B8;
          prmT001B8 = new Object[] {
          new ParDef("LimiteAprovacaoValorMinimo",GXType.Number,18,2){Nullable=true} ,
          new ParDef("LimiteAprovacaoAprovacoes",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("LimiteAprovacaoReprovacoesPermitidas",GXType.Int16,4,0)
          };
          Object[] prmT001B9;
          prmT001B9 = new Object[] {
          };
          Object[] prmT001B10;
          prmT001B10 = new Object[] {
          new ParDef("LimiteAprovacaoValorMinimo",GXType.Number,18,2){Nullable=true} ,
          new ParDef("LimiteAprovacaoAprovacoes",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("LimiteAprovacaoReprovacoesPermitidas",GXType.Int16,4,0) ,
          new ParDef("LimiteAprovacaoId",GXType.Int32,9,0)
          };
          Object[] prmT001B11;
          prmT001B11 = new Object[] {
          new ParDef("LimiteAprovacaoId",GXType.Int32,9,0)
          };
          Object[] prmT001B12;
          prmT001B12 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T001B2", "SELECT LimiteAprovacaoId, LimiteAprovacaoValorMinimo, LimiteAprovacaoAprovacoes, LimiteAprovacaoReprovacoesPermitidas FROM LimiteAprovacao WHERE LimiteAprovacaoId = :LimiteAprovacaoId  FOR UPDATE OF LimiteAprovacao NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001B2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001B3", "SELECT LimiteAprovacaoId, LimiteAprovacaoValorMinimo, LimiteAprovacaoAprovacoes, LimiteAprovacaoReprovacoesPermitidas FROM LimiteAprovacao WHERE LimiteAprovacaoId = :LimiteAprovacaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001B4", "SELECT TM1.LimiteAprovacaoId, TM1.LimiteAprovacaoValorMinimo, TM1.LimiteAprovacaoAprovacoes, TM1.LimiteAprovacaoReprovacoesPermitidas FROM LimiteAprovacao TM1 WHERE TM1.LimiteAprovacaoId = :LimiteAprovacaoId ORDER BY TM1.LimiteAprovacaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001B5", "SELECT LimiteAprovacaoId FROM LimiteAprovacao WHERE LimiteAprovacaoId = :LimiteAprovacaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001B6", "SELECT LimiteAprovacaoId FROM LimiteAprovacao WHERE ( LimiteAprovacaoId > :LimiteAprovacaoId) ORDER BY LimiteAprovacaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001B7", "SELECT LimiteAprovacaoId FROM LimiteAprovacao WHERE ( LimiteAprovacaoId < :LimiteAprovacaoId) ORDER BY LimiteAprovacaoId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001B8", "SAVEPOINT gxupdate;INSERT INTO LimiteAprovacao(LimiteAprovacaoValorMinimo, LimiteAprovacaoAprovacoes, LimiteAprovacaoReprovacoesPermitidas) VALUES(:LimiteAprovacaoValorMinimo, :LimiteAprovacaoAprovacoes, :LimiteAprovacaoReprovacoesPermitidas);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001B8)
             ,new CursorDef("T001B9", "SELECT currval('LimiteAprovacaoId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001B10", "SAVEPOINT gxupdate;UPDATE LimiteAprovacao SET LimiteAprovacaoValorMinimo=:LimiteAprovacaoValorMinimo, LimiteAprovacaoAprovacoes=:LimiteAprovacaoAprovacoes, LimiteAprovacaoReprovacoesPermitidas=:LimiteAprovacaoReprovacoesPermitidas  WHERE LimiteAprovacaoId = :LimiteAprovacaoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001B10)
             ,new CursorDef("T001B11", "SAVEPOINT gxupdate;DELETE FROM LimiteAprovacao  WHERE LimiteAprovacaoId = :LimiteAprovacaoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001B11)
             ,new CursorDef("T001B12", "SELECT LimiteAprovacaoId FROM LimiteAprovacao ORDER BY LimiteAprovacaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001B12,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((short[]) buf[5])[0] = rslt.getShort(4);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((short[]) buf[5])[0] = rslt.getShort(4);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((short[]) buf[5])[0] = rslt.getShort(4);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
