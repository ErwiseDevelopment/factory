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
namespace GeneXus.Programs.myobjects.viacep {
   public class wpviacep : GXDataArea
   {
      public wpviacep( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpviacep( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
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

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
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
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid2") == 0 )
            {
               gxnrGrid2_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid2") == 0 )
            {
               gxgrGrid2_refresh_invoke( ) ;
               return  ;
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
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid2_newrow_invoke( )
      {
         nRC_GXsfl_70 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_70"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_70_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_70_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_70_idx = GetPar( "sGXsfl_70_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid2_newrow( ) ;
         /* End function gxnrGrid2_newrow_invoke */
      }

      protected void gxgrGrid2_refresh_invoke( )
      {
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid2_refresh( ) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid2_refresh_invoke */
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
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

      public override short ExecuteStartEvent( )
      {
         PA3S2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3S2( ) ;
         }
         return gxajaxcallmode ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
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
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("myobjects.viacep.wpviacep") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Enderecocompleto", AV6EnderecoCompleto);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Enderecocompleto", AV6EnderecoCompleto);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Enderecosceps", AV7EnderecosCEPs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Enderecosceps", AV7EnderecosCEPs);
         }
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_70", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_70), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vENDERECOSCEPS", AV7EnderecosCEPs);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vENDERECOSCEPS", AV7EnderecosCEPs);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vENDERECOCOMPLETO", AV6EnderecoCompleto);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vENDERECOCOMPLETO", AV6EnderecoCompleto);
         }
         GxWebStd.gx_hidden_field( context, "FULLADDRESS_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Fulladdress_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FULLADDRESS_Class", StringUtil.RTrim( Fulladdress_Class));
         GxWebStd.gx_hidden_field( context, "FULLADDRESS_Historymanagement", StringUtil.BoolToStr( Fulladdress_Historymanagement));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
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

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE3S2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3S2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("myobjects.viacep.wpviacep")  ;
      }

      public override string GetPgmname( )
      {
         return "MyObjects.ViaCEP.WPviacep" ;
      }

      public override string GetPgmdesc( )
      {
         return "WPviacep" ;
      }

      protected void WB3S0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucFulladdress.SetProperty("PageCount", Fulladdress_Pagecount);
            ucFulladdress.SetProperty("Class", Fulladdress_Class);
            ucFulladdress.SetProperty("HistoryManagement", Fulladdress_Historymanagement);
            ucFulladdress.Render(context, "tab", Fulladdress_Internalname, "FULLADDRESSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"FULLADDRESSContainer"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabpage1_title_Internalname, "Busca por CEP", "", "", lblTabpage1_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_MyObjects/ViaCEP/WPviacep.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabPage1") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"FULLADDRESSContainer"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabpage1table1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCep_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCep_Internalname, "CEP", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_70_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCep_Internalname, StringUtil.RTrim( AV5CEP), StringUtil.RTrim( context.localUtil.Format( AV5CEP, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCep_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCep_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_MyObjects/ViaCEP/WPviacep.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "Center", "Middle", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBuscarcep_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(70), 2, 0)+","+"null"+");", "Buscar", bttBuscarcep_Jsonclick, 5, "Buscar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'BUSCARCEP\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_MyObjects/ViaCEP/WPviacep.htm");
            GxWebStd.gx_div_end( context, "Center", "Middle", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTbresult_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCtllogradouro_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtllogradouro_Internalname, "Logradouro", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_70_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtllogradouro_Internalname, AV6EnderecoCompleto.gxTpr_Logradouro, StringUtil.RTrim( context.localUtil.Format( AV6EnderecoCompleto.gxTpr_Logradouro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtllogradouro_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtllogradouro_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_MyObjects/ViaCEP/WPviacep.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCtlcep_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtlcep_Internalname, "CEP", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'" + sGXsfl_70_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtlcep_Internalname, AV6EnderecoCompleto.gxTpr_Cep, StringUtil.RTrim( context.localUtil.Format( AV6EnderecoCompleto.gxTpr_Cep, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtlcep_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtlcep_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_MyObjects/ViaCEP/WPviacep.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCtlcomplemento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtlcomplemento_Internalname, "Complemento", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_70_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtlcomplemento_Internalname, AV6EnderecoCompleto.gxTpr_Complemento, StringUtil.RTrim( context.localUtil.Format( AV6EnderecoCompleto.gxTpr_Complemento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtlcomplemento_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtlcomplemento_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_MyObjects/ViaCEP/WPviacep.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCtlbairro_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtlbairro_Internalname, "Bairro", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'" + sGXsfl_70_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtlbairro_Internalname, AV6EnderecoCompleto.gxTpr_Bairro, StringUtil.RTrim( context.localUtil.Format( AV6EnderecoCompleto.gxTpr_Bairro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtlbairro_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtlbairro_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_MyObjects/ViaCEP/WPviacep.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCtllocalidade_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtllocalidade_Internalname, "Localidade", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_70_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtllocalidade_Internalname, AV6EnderecoCompleto.gxTpr_Localidade, StringUtil.RTrim( context.localUtil.Format( AV6EnderecoCompleto.gxTpr_Localidade, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtllocalidade_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtllocalidade_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_MyObjects/ViaCEP/WPviacep.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCtluf_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtluf_Internalname, "UF", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'" + sGXsfl_70_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtluf_Internalname, StringUtil.RTrim( AV6EnderecoCompleto.gxTpr_Uf), StringUtil.RTrim( context.localUtil.Format( AV6EnderecoCompleto.gxTpr_Uf, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtluf_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtluf_Enabled, 0, "text", "", 2, "chr", 1, "row", 2, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_MyObjects/ViaCEP/WPviacep.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"FULLADDRESSContainer"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblAddress_title_Internalname, "Busca por endereço", "", "", lblAddress_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_MyObjects/ViaCEP/WPviacep.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "ADDRESS") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"FULLADDRESSContainer"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divAddresstable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLogradouro_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLogradouro_Internalname, "Logradouro", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_70_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLogradouro_Internalname, AV9logradouro, StringUtil.RTrim( context.localUtil.Format( AV9logradouro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLogradouro_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLogradouro_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_MyObjects/ViaCEP/WPviacep.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavLocalidade_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavLocalidade_Internalname, "Localidade", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'" + sGXsfl_70_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavLocalidade_Internalname, AV8localidade, StringUtil.RTrim( context.localUtil.Format( AV8localidade, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavLocalidade_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavLocalidade_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_MyObjects/ViaCEP/WPviacep.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavUf_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUf_Internalname, "UF", "col-xs-12 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'" + sGXsfl_70_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUf_Internalname, StringUtil.RTrim( AV12uf), StringUtil.RTrim( context.localUtil.Format( AV12uf, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUf_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUf_Enabled, 0, "text", "", 2, "chr", 1, "row", 2, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_MyObjects/ViaCEP/WPviacep.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBuscaraddress_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(70), 2, 0)+","+"null"+");", "Buscar", bttBuscaraddress_Jsonclick, 5, "Buscar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'BUSCARADDRESS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_MyObjects/ViaCEP/WPviacep.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            Grid2Container.SetWrapped(nGXWrapped);
            StartGridControl70( ) ;
         }
         if ( wbEnd == 70 )
         {
            wbEnd = 0;
            nRC_GXsfl_70 = (int)(nGXsfl_70_idx-1);
            if ( Grid2Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               AV19GXV7 = nGXsfl_70_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid2Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid2", Grid2Container, subGrid2_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid2ContainerData", Grid2Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid2ContainerData"+"V", Grid2Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid2ContainerData"+"V"+"\" value='"+Grid2Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 70 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid2Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  AV19GXV7 = nGXsfl_70_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid2Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid2", Grid2Container, subGrid2_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid2ContainerData", Grid2Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid2ContainerData"+"V", Grid2Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid2ContainerData"+"V"+"\" value='"+Grid2Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START3S2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_12-186073", 0) ;
            }
         }
         Form.Meta.addItem("description", "WPviacep", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3S0( ) ;
      }

      protected void WS3S2( )
      {
         START3S2( ) ;
         EVT3S2( ) ;
      }

      protected void EVT3S2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'BUSCARCEP'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'BuscarCEP' */
                              E113S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'BUSCARADDRESS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'BuscarADDRESS' */
                              E123S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_70_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_70_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_70_idx), 4, 0), 4, "0");
                              SubsflControlProps_702( ) ;
                              AV19GXV7 = nGXsfl_70_idx;
                              if ( ( AV7EnderecosCEPs.Count >= AV19GXV7 ) && ( AV19GXV7 > 0 ) )
                              {
                                 AV7EnderecosCEPs.CurrentItem = ((GeneXus.Programs.myobjects.viacep.SdtListaEndereco_EnderecoCompleto)AV7EnderecosCEPs.Item(AV19GXV7));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E133S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE3S2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA3S2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavCep_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid2_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_702( ) ;
         while ( nGXsfl_70_idx <= nRC_GXsfl_70 )
         {
            sendrow_702( ) ;
            nGXsfl_70_idx = ((subGrid2_Islastpage==1)&&(nGXsfl_70_idx+1>subGrid2_fnc_Recordsperpage( )) ? 1 : nGXsfl_70_idx+1);
            sGXsfl_70_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_70_idx), 4, 0), 4, "0");
            SubsflControlProps_702( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid2Container)) ;
         /* End function gxnrGrid2_newrow */
      }

      protected void gxgrGrid2_refresh( )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID2_nCurrentRecord = 0;
         RF3S2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid2_refresh */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3S2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         edtavCtllogradouro_Enabled = 0;
         AssignProp("", false, edtavCtllogradouro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtllogradouro_Enabled), 5, 0), true);
         edtavCtlcep_Enabled = 0;
         AssignProp("", false, edtavCtlcep_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcep_Enabled), 5, 0), true);
         edtavCtlcomplemento_Enabled = 0;
         AssignProp("", false, edtavCtlcomplemento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcomplemento_Enabled), 5, 0), true);
         edtavCtlbairro_Enabled = 0;
         AssignProp("", false, edtavCtlbairro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlbairro_Enabled), 5, 0), true);
         edtavCtllocalidade_Enabled = 0;
         AssignProp("", false, edtavCtllocalidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtllocalidade_Enabled), 5, 0), true);
         edtavCtluf_Enabled = 0;
         AssignProp("", false, edtavCtluf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtluf_Enabled), 5, 0), true);
         edtavCtllocalidade1_Enabled = 0;
         edtavCtluf1_Enabled = 0;
         edtavCtlunidade_Enabled = 0;
      }

      protected void RF3S2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid2Container.ClearRows();
         }
         wbStart = 70;
         nGXsfl_70_idx = 1;
         sGXsfl_70_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_70_idx), 4, 0), 4, "0");
         SubsflControlProps_702( ) ;
         bGXsfl_70_Refreshing = true;
         Grid2Container.AddObjectProperty("GridName", "Grid2");
         Grid2Container.AddObjectProperty("CmpContext", "");
         Grid2Container.AddObjectProperty("InMasterPage", "false");
         Grid2Container.AddObjectProperty("Class", "Grid");
         Grid2Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid2Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid2Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Backcolorstyle), 1, 0, ".", "")));
         Grid2Container.PageSize = subGrid2_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_702( ) ;
            /* Execute user event: Load */
            E133S2 ();
            wbEnd = 70;
            WB3S0( ) ;
         }
         bGXsfl_70_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3S2( )
      {
      }

      protected int subGrid2_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid2_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid2_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid2_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         edtavCtllogradouro_Enabled = 0;
         AssignProp("", false, edtavCtllogradouro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtllogradouro_Enabled), 5, 0), true);
         edtavCtlcep_Enabled = 0;
         AssignProp("", false, edtavCtlcep_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcep_Enabled), 5, 0), true);
         edtavCtlcomplemento_Enabled = 0;
         AssignProp("", false, edtavCtlcomplemento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlcomplemento_Enabled), 5, 0), true);
         edtavCtlbairro_Enabled = 0;
         AssignProp("", false, edtavCtlbairro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtlbairro_Enabled), 5, 0), true);
         edtavCtllocalidade_Enabled = 0;
         AssignProp("", false, edtavCtllocalidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtllocalidade_Enabled), 5, 0), true);
         edtavCtluf_Enabled = 0;
         AssignProp("", false, edtavCtluf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCtluf_Enabled), 5, 0), true);
         edtavCtllocalidade1_Enabled = 0;
         edtavCtluf1_Enabled = 0;
         edtavCtlunidade_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3S0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vENDERECOCOMPLETO"), AV6EnderecoCompleto);
            ajax_req_read_hidden_sdt(cgiGet( "Enderecocompleto"), AV6EnderecoCompleto);
            ajax_req_read_hidden_sdt(cgiGet( "Enderecosceps"), AV7EnderecosCEPs);
            ajax_req_read_hidden_sdt(cgiGet( "vENDERECOSCEPS"), AV7EnderecosCEPs);
            /* Read saved values. */
            nRC_GXsfl_70 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_70"), ",", "."), 18, MidpointRounding.ToEven));
            Fulladdress_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "FULLADDRESS_Pagecount"), ",", "."), 18, MidpointRounding.ToEven));
            Fulladdress_Class = cgiGet( "FULLADDRESS_Class");
            Fulladdress_Historymanagement = StringUtil.StrToBool( cgiGet( "FULLADDRESS_Historymanagement"));
            nRC_GXsfl_70 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_70"), ",", "."), 18, MidpointRounding.ToEven));
            nGXsfl_70_fel_idx = 0;
            while ( nGXsfl_70_fel_idx < nRC_GXsfl_70 )
            {
               nGXsfl_70_fel_idx = ((subGrid2_Islastpage==1)&&(nGXsfl_70_fel_idx+1>subGrid2_fnc_Recordsperpage( )) ? 1 : nGXsfl_70_fel_idx+1);
               sGXsfl_70_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_70_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_702( ) ;
               AV19GXV7 = nGXsfl_70_fel_idx;
               if ( ( AV7EnderecosCEPs.Count >= AV19GXV7 ) && ( AV19GXV7 > 0 ) )
               {
                  AV7EnderecosCEPs.CurrentItem = ((GeneXus.Programs.myobjects.viacep.SdtListaEndereco_EnderecoCompleto)AV7EnderecosCEPs.Item(AV19GXV7));
               }
            }
            if ( nGXsfl_70_fel_idx == 0 )
            {
               nGXsfl_70_idx = 1;
               sGXsfl_70_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_70_idx), 4, 0), 4, "0");
               SubsflControlProps_702( ) ;
            }
            nGXsfl_70_fel_idx = 1;
            /* Read variables values. */
            AV5CEP = cgiGet( edtavCep_Internalname);
            AssignAttri("", false, "AV5CEP", AV5CEP);
            AV6EnderecoCompleto.gxTpr_Logradouro = cgiGet( edtavCtllogradouro_Internalname);
            AV6EnderecoCompleto.gxTpr_Cep = cgiGet( edtavCtlcep_Internalname);
            AV6EnderecoCompleto.gxTpr_Complemento = cgiGet( edtavCtlcomplemento_Internalname);
            AV6EnderecoCompleto.gxTpr_Bairro = cgiGet( edtavCtlbairro_Internalname);
            AV6EnderecoCompleto.gxTpr_Localidade = cgiGet( edtavCtllocalidade_Internalname);
            AV6EnderecoCompleto.gxTpr_Uf = cgiGet( edtavCtluf_Internalname);
            AV9logradouro = cgiGet( edtavLogradouro_Internalname);
            AssignAttri("", false, "AV9logradouro", AV9logradouro);
            AV8localidade = cgiGet( edtavLocalidade_Internalname);
            AssignAttri("", false, "AV8localidade", AV8localidade);
            AV12uf = cgiGet( edtavUf_Internalname);
            AssignAttri("", false, "AV12uf", AV12uf);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void E113S2( )
      {
         /* 'BuscarCEP' Routine */
         returnInSub = false;
         new GeneXus.Programs.myobjects.viacep.cepparaendereco(context ).execute(  AV5CEP, out  AV11ModeloRetorno, out  AV10Mensagem) ;
         AV6EnderecoCompleto.FromJSonString(AV11ModeloRetorno, null);
         GX_msglist.addItem(AV10Mensagem);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6EnderecoCompleto", AV6EnderecoCompleto);
      }

      protected void E123S2( )
      {
         AV19GXV7 = nGXsfl_70_idx;
         if ( ( AV19GXV7 > 0 ) && ( AV7EnderecosCEPs.Count >= AV19GXV7 ) )
         {
            AV7EnderecosCEPs.CurrentItem = ((GeneXus.Programs.myobjects.viacep.SdtListaEndereco_EnderecoCompleto)AV7EnderecosCEPs.Item(AV19GXV7));
         }
         /* 'BuscarADDRESS' Routine */
         returnInSub = false;
         new GeneXus.Programs.myobjects.viacep.enderecoparacep(context ).execute(  AV12uf,  AV8localidade,  AV9logradouro, out  AV11ModeloRetorno, out  AV10Mensagem) ;
         AV7EnderecosCEPs.FromJSonString(AV11ModeloRetorno, null);
         gx_BV70 = true;
         GX_msglist.addItem(AV10Mensagem);
         /*  Sending Event outputs  */
         if ( gx_BV70 )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7EnderecosCEPs", AV7EnderecosCEPs);
            nGXsfl_70_bak_idx = nGXsfl_70_idx;
            gxgrGrid2_refresh( ) ;
            nGXsfl_70_idx = nGXsfl_70_bak_idx;
            sGXsfl_70_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_70_idx), 4, 0), 4, "0");
            SubsflControlProps_702( ) ;
         }
      }

      private void E133S2( )
      {
         /* Load Routine */
         returnInSub = false;
         AV19GXV7 = 1;
         while ( AV19GXV7 <= AV7EnderecosCEPs.Count )
         {
            AV7EnderecosCEPs.CurrentItem = ((GeneXus.Programs.myobjects.viacep.SdtListaEndereco_EnderecoCompleto)AV7EnderecosCEPs.Item(AV19GXV7));
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 70;
            }
            sendrow_702( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_70_Refreshing )
            {
               DoAjaxLoad(70, Grid2Row);
            }
            AV19GXV7 = (int)(AV19GXV7+1);
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA3S2( ) ;
         WS3S2( ) ;
         WE3S2( ) ;
         cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019235630", true, true);
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
         context.AddJavascriptSource("myobjects/viacep/wpviacep.js", "?202561019235631", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_702( )
      {
         edtavCtlcep1_Internalname = "CTLCEP1_"+sGXsfl_70_idx;
         edtavCtllogradouro1_Internalname = "CTLLOGRADOURO1_"+sGXsfl_70_idx;
         edtavCtlcomplemento1_Internalname = "CTLCOMPLEMENTO1_"+sGXsfl_70_idx;
         edtavCtlbairro1_Internalname = "CTLBAIRRO1_"+sGXsfl_70_idx;
         edtavCtllocalidade1_Internalname = "CTLLOCALIDADE1_"+sGXsfl_70_idx;
         edtavCtluf1_Internalname = "CTLUF1_"+sGXsfl_70_idx;
         edtavCtlunidade_Internalname = "CTLUNIDADE_"+sGXsfl_70_idx;
         edtavCtlibge_Internalname = "CTLIBGE_"+sGXsfl_70_idx;
         edtavCtlgia_Internalname = "CTLGIA_"+sGXsfl_70_idx;
      }

      protected void SubsflControlProps_fel_702( )
      {
         edtavCtlcep1_Internalname = "CTLCEP1_"+sGXsfl_70_fel_idx;
         edtavCtllogradouro1_Internalname = "CTLLOGRADOURO1_"+sGXsfl_70_fel_idx;
         edtavCtlcomplemento1_Internalname = "CTLCOMPLEMENTO1_"+sGXsfl_70_fel_idx;
         edtavCtlbairro1_Internalname = "CTLBAIRRO1_"+sGXsfl_70_fel_idx;
         edtavCtllocalidade1_Internalname = "CTLLOCALIDADE1_"+sGXsfl_70_fel_idx;
         edtavCtluf1_Internalname = "CTLUF1_"+sGXsfl_70_fel_idx;
         edtavCtlunidade_Internalname = "CTLUNIDADE_"+sGXsfl_70_fel_idx;
         edtavCtlibge_Internalname = "CTLIBGE_"+sGXsfl_70_fel_idx;
         edtavCtlgia_Internalname = "CTLGIA_"+sGXsfl_70_fel_idx;
      }

      protected void sendrow_702( )
      {
         sGXsfl_70_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_70_idx), 4, 0), 4, "0");
         SubsflControlProps_702( ) ;
         WB3S0( ) ;
         Grid2Row = GXWebRow.GetNew(context,Grid2Container);
         if ( subGrid2_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGrid2_Backstyle = 0;
            if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
            {
               subGrid2_Linesclass = subGrid2_Class+"Odd";
            }
         }
         else if ( subGrid2_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGrid2_Backstyle = 0;
            subGrid2_Backcolor = subGrid2_Allbackcolor;
            if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
            {
               subGrid2_Linesclass = subGrid2_Class+"Uniform";
            }
         }
         else if ( subGrid2_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGrid2_Backstyle = 1;
            if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
            {
               subGrid2_Linesclass = subGrid2_Class+"Odd";
            }
            subGrid2_Backcolor = (int)(0x0);
         }
         else if ( subGrid2_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGrid2_Backstyle = 1;
            if ( ((int)((nGXsfl_70_idx) % (2))) == 0 )
            {
               subGrid2_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
               {
                  subGrid2_Linesclass = subGrid2_Class+"Even";
               }
            }
            else
            {
               subGrid2_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
               {
                  subGrid2_Linesclass = subGrid2_Class+"Odd";
               }
            }
         }
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"Grid"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_70_idx+"\">") ;
         }
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'" + sGXsfl_70_idx + "',70)\"";
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcep1_Internalname,((GeneXus.Programs.myobjects.viacep.SdtListaEndereco_EnderecoCompleto)AV7EnderecosCEPs.Item(AV19GXV7)).gxTpr_Cep,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcep1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)1,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)70,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'" + sGXsfl_70_idx + "',70)\"";
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtllogradouro1_Internalname,((GeneXus.Programs.myobjects.viacep.SdtListaEndereco_EnderecoCompleto)AV7EnderecosCEPs.Item(AV19GXV7)).gxTpr_Logradouro,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtllogradouro1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)1,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)70,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'" + sGXsfl_70_idx + "',70)\"";
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlcomplemento1_Internalname,((GeneXus.Programs.myobjects.viacep.SdtListaEndereco_EnderecoCompleto)AV7EnderecosCEPs.Item(AV19GXV7)).gxTpr_Complemento,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlcomplemento1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)1,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)70,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'" + sGXsfl_70_idx + "',70)\"";
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlbairro1_Internalname,((GeneXus.Programs.myobjects.viacep.SdtListaEndereco_EnderecoCompleto)AV7EnderecosCEPs.Item(AV19GXV7)).gxTpr_Bairro,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlbairro1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)1,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)70,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtllocalidade1_Internalname,((GeneXus.Programs.myobjects.viacep.SdtListaEndereco_EnderecoCompleto)AV7EnderecosCEPs.Item(AV19GXV7)).gxTpr_Localidade,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtllocalidade1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(int)edtavCtllocalidade1_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)70,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtluf1_Internalname,StringUtil.RTrim( ((GeneXus.Programs.myobjects.viacep.SdtListaEndereco_EnderecoCompleto)AV7EnderecosCEPs.Item(AV19GXV7)).gxTpr_Uf),(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtluf1_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(int)edtavCtluf1_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)2,(short)0,(short)0,(short)70,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlunidade_Internalname,((GeneXus.Programs.myobjects.viacep.SdtListaEndereco_EnderecoCompleto)AV7EnderecosCEPs.Item(AV19GXV7)).gxTpr_Unidade,(string)"",""+" onchange=\""+""+";gx.evt.onchange(this, event)\" ",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlunidade_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(int)edtavCtlunidade_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)70,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'" + sGXsfl_70_idx + "',70)\"";
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlibge_Internalname,((GeneXus.Programs.myobjects.viacep.SdtListaEndereco_EnderecoCompleto)AV7EnderecosCEPs.Item(AV19GXV7)).gxTpr_Ibge,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlibge_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)1,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)70,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'" + sGXsfl_70_idx + "',70)\"";
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavCtlgia_Internalname,((GeneXus.Programs.myobjects.viacep.SdtListaEndereco_EnderecoCompleto)AV7EnderecosCEPs.Item(AV19GXV7)).gxTpr_Gia,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavCtlgia_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)1,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)70,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         send_integrity_lvl_hashes3S2( ) ;
         Grid2Container.AddRow(Grid2Row);
         nGXsfl_70_idx = ((subGrid2_Islastpage==1)&&(nGXsfl_70_idx+1>subGrid2_fnc_Recordsperpage( )) ? 1 : nGXsfl_70_idx+1);
         sGXsfl_70_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_70_idx), 4, 0), 4, "0");
         SubsflControlProps_702( ) ;
         /* End function sendrow_702 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl70( )
      {
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid2Container"+"DivS\" data-gxgridid=\"70\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid2_Internalname, subGrid2_Internalname, "", "Grid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid2_Backcolorstyle == 0 )
            {
               subGrid2_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid2_Class) > 0 )
               {
                  subGrid2_Linesclass = subGrid2_Class+"Title";
               }
            }
            else
            {
               subGrid2_Titlebackstyle = 1;
               if ( subGrid2_Backcolorstyle == 1 )
               {
                  subGrid2_Titlebackcolor = subGrid2_Allbackcolor;
                  if ( StringUtil.Len( subGrid2_Class) > 0 )
                  {
                     subGrid2_Linesclass = subGrid2_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid2_Class) > 0 )
                  {
                     subGrid2_Linesclass = subGrid2_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "CEP") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Logradouro") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Complemento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Bairro") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Localidade") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "UF") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Unidade") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "IBGE") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "GIA") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid2Container.AddObjectProperty("GridName", "Grid2");
         }
         else
         {
            Grid2Container.AddObjectProperty("GridName", "Grid2");
            Grid2Container.AddObjectProperty("Header", subGrid2_Header);
            Grid2Container.AddObjectProperty("Class", "Grid");
            Grid2Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid2Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid2Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Backcolorstyle), 1, 0, ".", "")));
            Grid2Container.AddObjectProperty("CmpContext", "");
            Grid2Container.AddObjectProperty("InMasterPage", "false");
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtllocalidade1_Enabled), 5, 0, ".", "")));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtluf1_Enabled), 5, 0, ".", "")));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavCtlunidade_Enabled), 5, 0, ".", "")));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Selectedindex), 4, 0, ".", "")));
            Grid2Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Allowselection), 1, 0, ".", "")));
            Grid2Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Selectioncolor), 9, 0, ".", "")));
            Grid2Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Allowhovering), 1, 0, ".", "")));
            Grid2Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Hoveringcolor), 9, 0, ".", "")));
            Grid2Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Allowcollapsing), 1, 0, ".", "")));
            Grid2Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblTabpage1_title_Internalname = "TABPAGE1_TITLE";
         edtavCep_Internalname = "vCEP";
         bttBuscarcep_Internalname = "BUSCARCEP";
         edtavCtllogradouro_Internalname = "CTLLOGRADOURO";
         edtavCtlcep_Internalname = "CTLCEP";
         edtavCtlcomplemento_Internalname = "CTLCOMPLEMENTO";
         edtavCtlbairro_Internalname = "CTLBAIRRO";
         edtavCtllocalidade_Internalname = "CTLLOCALIDADE";
         edtavCtluf_Internalname = "CTLUF";
         divTbresult_Internalname = "TBRESULT";
         divTabpage1table1_Internalname = "TABPAGE1TABLE1";
         lblAddress_title_Internalname = "ADDRESS_TITLE";
         edtavLogradouro_Internalname = "vLOGRADOURO";
         edtavLocalidade_Internalname = "vLOCALIDADE";
         edtavUf_Internalname = "vUF";
         bttBuscaraddress_Internalname = "BUSCARADDRESS";
         edtavCtlcep1_Internalname = "CTLCEP1";
         edtavCtllogradouro1_Internalname = "CTLLOGRADOURO1";
         edtavCtlcomplemento1_Internalname = "CTLCOMPLEMENTO1";
         edtavCtlbairro1_Internalname = "CTLBAIRRO1";
         edtavCtllocalidade1_Internalname = "CTLLOCALIDADE1";
         edtavCtluf1_Internalname = "CTLUF1";
         edtavCtlunidade_Internalname = "CTLUNIDADE";
         edtavCtlibge_Internalname = "CTLIBGE";
         edtavCtlgia_Internalname = "CTLGIA";
         divAddresstable1_Internalname = "ADDRESSTABLE1";
         Fulladdress_Internalname = "FULLADDRESS";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGrid2_Internalname = "GRID2";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid2_Allowcollapsing = 0;
         subGrid2_Allowselection = 0;
         subGrid2_Header = "";
         edtavCtlgia_Jsonclick = "";
         edtavCtlibge_Jsonclick = "";
         edtavCtlunidade_Jsonclick = "";
         edtavCtlunidade_Enabled = 0;
         edtavCtluf1_Jsonclick = "";
         edtavCtluf1_Enabled = 0;
         edtavCtllocalidade1_Jsonclick = "";
         edtavCtllocalidade1_Enabled = 0;
         edtavCtlbairro1_Jsonclick = "";
         edtavCtlcomplemento1_Jsonclick = "";
         edtavCtllogradouro1_Jsonclick = "";
         edtavCtlcep1_Jsonclick = "";
         subGrid2_Class = "Grid";
         subGrid2_Backcolorstyle = 0;
         edtavCtlunidade_Enabled = -1;
         edtavCtluf1_Enabled = -1;
         edtavCtllocalidade1_Enabled = -1;
         edtavCtluf_Enabled = -1;
         edtavCtllocalidade_Enabled = -1;
         edtavCtlbairro_Enabled = -1;
         edtavCtlcomplemento_Enabled = -1;
         edtavCtlcep_Enabled = -1;
         edtavCtllogradouro_Enabled = -1;
         edtavUf_Jsonclick = "";
         edtavUf_Enabled = 1;
         edtavLocalidade_Jsonclick = "";
         edtavLocalidade_Enabled = 1;
         edtavLogradouro_Jsonclick = "";
         edtavLogradouro_Enabled = 1;
         edtavCtluf_Jsonclick = "";
         edtavCtluf_Enabled = 0;
         edtavCtllocalidade_Jsonclick = "";
         edtavCtllocalidade_Enabled = 0;
         edtavCtlbairro_Jsonclick = "";
         edtavCtlbairro_Enabled = 0;
         edtavCtlcomplemento_Jsonclick = "";
         edtavCtlcomplemento_Enabled = 0;
         edtavCtlcep_Jsonclick = "";
         edtavCtlcep_Enabled = 0;
         edtavCtllogradouro_Jsonclick = "";
         edtavCtllogradouro_Enabled = 0;
         edtavCep_Jsonclick = "";
         edtavCep_Enabled = 1;
         Fulladdress_Historymanagement = Convert.ToBoolean( 0);
         Fulladdress_Class = "Tab";
         Fulladdress_Pagecount = 2;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "WPviacep";
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID2_nFirstRecordOnPage","type":"int"},{"av":"GRID2_nEOF","type":"int"},{"av":"AV7EnderecosCEPs","fld":"vENDERECOSCEPS","grid":70,"type":""},{"av":"nGXsfl_70_idx","ctrl":"GRID","prop":"GridCurrRow","grid":70},{"av":"nRC_GXsfl_70","ctrl":"GRID2","prop":"GridRC","grid":70,"type":"int"}]}""");
         setEventMetadata("'BUSCARCEP'","""{"handler":"E113S2","iparms":[{"av":"AV5CEP","fld":"vCEP","type":"char"}]""");
         setEventMetadata("'BUSCARCEP'",""","oparms":[{"av":"AV6EnderecoCompleto","fld":"vENDERECOCOMPLETO","type":""}]}""");
         setEventMetadata("'BUSCARADDRESS'","""{"handler":"E123S2","iparms":[{"av":"AV12uf","fld":"vUF","type":"char"},{"av":"AV8localidade","fld":"vLOCALIDADE","type":"svchar"},{"av":"AV9logradouro","fld":"vLOGRADOURO","type":"svchar"},{"av":"AV7EnderecosCEPs","fld":"vENDERECOSCEPS","grid":70,"type":""},{"av":"nGXsfl_70_idx","ctrl":"GRID","prop":"GridCurrRow","grid":70},{"av":"GRID2_nFirstRecordOnPage","type":"int"},{"av":"nRC_GXsfl_70","ctrl":"GRID2","prop":"GridRC","grid":70,"type":"int"},{"av":"GRID2_nEOF","type":"int"}]""");
         setEventMetadata("'BUSCARADDRESS'",""","oparms":[{"av":"AV7EnderecosCEPs","fld":"vENDERECOSCEPS","grid":70,"type":""},{"av":"nGXsfl_70_idx","ctrl":"GRID","prop":"GridCurrRow","grid":70},{"av":"GRID2_nFirstRecordOnPage","type":"int"},{"av":"nRC_GXsfl_70","ctrl":"GRID2","prop":"GridRC","grid":70,"type":"int"}]}""");
         setEventMetadata("NULL","""{"handler":"Validv_Gxv16","iparms":[]}""");
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

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV6EnderecoCompleto = new GeneXus.Programs.myobjects.viacep.SdtEnderecoCompleto(context);
         AV7EnderecosCEPs = new GXBaseCollection<GeneXus.Programs.myobjects.viacep.SdtListaEndereco_EnderecoCompleto>( context, "EnderecoCompleto", "Factory21");
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucFulladdress = new GXUserControl();
         lblTabpage1_title_Jsonclick = "";
         TempTags = "";
         AV5CEP = "";
         ClassString = "";
         StyleString = "";
         bttBuscarcep_Jsonclick = "";
         lblAddress_title_Jsonclick = "";
         AV9logradouro = "";
         AV8localidade = "";
         AV12uf = "";
         bttBuscaraddress_Jsonclick = "";
         Grid2Container = new GXWebGrid( context);
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV11ModeloRetorno = "";
         AV10Mensagem = "";
         Grid2Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid2_Linesclass = "";
         ROClassString = "";
         Grid2Column = new GXWebColumn();
         /* GeneXus formulas. */
         edtavCtllogradouro_Enabled = 0;
         edtavCtlcep_Enabled = 0;
         edtavCtlcomplemento_Enabled = 0;
         edtavCtlbairro_Enabled = 0;
         edtavCtllocalidade_Enabled = 0;
         edtavCtluf_Enabled = 0;
         edtavCtllocalidade1_Enabled = 0;
         edtavCtluf1_Enabled = 0;
         edtavCtlunidade_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid2_Backcolorstyle ;
      private short GRID2_nEOF ;
      private short nGXWrapped ;
      private short subGrid2_Backstyle ;
      private short subGrid2_Titlebackstyle ;
      private short subGrid2_Allowselection ;
      private short subGrid2_Allowhovering ;
      private short subGrid2_Allowcollapsing ;
      private short subGrid2_Collapsed ;
      private int nRC_GXsfl_70 ;
      private int nGXsfl_70_idx=1 ;
      private int Fulladdress_Pagecount ;
      private int edtavCep_Enabled ;
      private int edtavCtllogradouro_Enabled ;
      private int edtavCtlcep_Enabled ;
      private int edtavCtlcomplemento_Enabled ;
      private int edtavCtlbairro_Enabled ;
      private int edtavCtllocalidade_Enabled ;
      private int edtavCtluf_Enabled ;
      private int edtavLogradouro_Enabled ;
      private int edtavLocalidade_Enabled ;
      private int edtavUf_Enabled ;
      private int AV19GXV7 ;
      private int subGrid2_Islastpage ;
      private int edtavCtllocalidade1_Enabled ;
      private int edtavCtluf1_Enabled ;
      private int edtavCtlunidade_Enabled ;
      private int nGXsfl_70_fel_idx=1 ;
      private int nGXsfl_70_bak_idx=1 ;
      private int idxLst ;
      private int subGrid2_Backcolor ;
      private int subGrid2_Allbackcolor ;
      private int subGrid2_Titlebackcolor ;
      private int subGrid2_Selectedindex ;
      private int subGrid2_Selectioncolor ;
      private int subGrid2_Hoveringcolor ;
      private long GRID2_nCurrentRecord ;
      private long GRID2_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_70_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Fulladdress_Class ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string Fulladdress_Internalname ;
      private string lblTabpage1_title_Internalname ;
      private string lblTabpage1_title_Jsonclick ;
      private string divTabpage1table1_Internalname ;
      private string edtavCep_Internalname ;
      private string TempTags ;
      private string AV5CEP ;
      private string edtavCep_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string bttBuscarcep_Internalname ;
      private string bttBuscarcep_Jsonclick ;
      private string divTbresult_Internalname ;
      private string edtavCtllogradouro_Internalname ;
      private string edtavCtllogradouro_Jsonclick ;
      private string edtavCtlcep_Internalname ;
      private string edtavCtlcep_Jsonclick ;
      private string edtavCtlcomplemento_Internalname ;
      private string edtavCtlcomplemento_Jsonclick ;
      private string edtavCtlbairro_Internalname ;
      private string edtavCtlbairro_Jsonclick ;
      private string edtavCtllocalidade_Internalname ;
      private string edtavCtllocalidade_Jsonclick ;
      private string edtavCtluf_Internalname ;
      private string edtavCtluf_Jsonclick ;
      private string lblAddress_title_Internalname ;
      private string lblAddress_title_Jsonclick ;
      private string divAddresstable1_Internalname ;
      private string edtavLogradouro_Internalname ;
      private string edtavLogradouro_Jsonclick ;
      private string edtavLocalidade_Internalname ;
      private string edtavLocalidade_Jsonclick ;
      private string edtavUf_Internalname ;
      private string AV12uf ;
      private string edtavUf_Jsonclick ;
      private string bttBuscaraddress_Internalname ;
      private string bttBuscaraddress_Jsonclick ;
      private string sStyleString ;
      private string subGrid2_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string sGXsfl_70_fel_idx="0001" ;
      private string edtavCtlcep1_Internalname ;
      private string edtavCtllogradouro1_Internalname ;
      private string edtavCtlcomplemento1_Internalname ;
      private string edtavCtlbairro1_Internalname ;
      private string edtavCtllocalidade1_Internalname ;
      private string edtavCtluf1_Internalname ;
      private string edtavCtlunidade_Internalname ;
      private string edtavCtlibge_Internalname ;
      private string edtavCtlgia_Internalname ;
      private string subGrid2_Class ;
      private string subGrid2_Linesclass ;
      private string ROClassString ;
      private string edtavCtlcep1_Jsonclick ;
      private string edtavCtllogradouro1_Jsonclick ;
      private string edtavCtlcomplemento1_Jsonclick ;
      private string edtavCtlbairro1_Jsonclick ;
      private string edtavCtllocalidade1_Jsonclick ;
      private string edtavCtluf1_Jsonclick ;
      private string edtavCtlunidade_Jsonclick ;
      private string edtavCtlibge_Jsonclick ;
      private string edtavCtlgia_Jsonclick ;
      private string subGrid2_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Fulladdress_Historymanagement ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_70_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_BV70 ;
      private string AV11ModeloRetorno ;
      private string AV9logradouro ;
      private string AV8localidade ;
      private string AV10Mensagem ;
      private GXWebGrid Grid2Container ;
      private GXWebRow Grid2Row ;
      private GXWebColumn Grid2Column ;
      private GXUserControl ucFulladdress ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.myobjects.viacep.SdtEnderecoCompleto AV6EnderecoCompleto ;
      private GXBaseCollection<GeneXus.Programs.myobjects.viacep.SdtListaEndereco_EnderecoCompleto> AV7EnderecosCEPs ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
