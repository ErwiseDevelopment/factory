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
   public class logemail : GXDataArea
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_12-186073", 0) ;
            }
         }
         Form.Meta.addItem("description", "Log Email", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtLogEmailId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public logemail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public logemail( IGxContext context )
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
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "title-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Log Email", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_LogEmail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
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
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "form-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 form__toolbar-cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-first";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_LogEmail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_LogEmail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_LogEmail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_LogEmail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_LogEmail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell-advanced", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLogEmailId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLogEmailId_Internalname, "Email Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLogEmailId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A626LogEmailId), 9, 0, ",", "")), StringUtil.LTrim( ((edtLogEmailId_Enabled!=0) ? context.localUtil.Format( (decimal)(A626LogEmailId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A626LogEmailId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLogEmailId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLogEmailId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_LogEmail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLogEmailCorpo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLogEmailCorpo_Internalname, "Email Corpo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtLogEmailCorpo_Internalname, A627LogEmailCorpo, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", 0, 1, edtLogEmailCorpo_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_LogEmail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLogEmailSubject_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLogEmailSubject_Internalname, "Email Subject", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLogEmailSubject_Internalname, A628LogEmailSubject, StringUtil.RTrim( context.localUtil.Format( A628LogEmailSubject, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLogEmailSubject_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLogEmailSubject_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_LogEmail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLogEmailDestinatario_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLogEmailDestinatario_Internalname, "Email Destinatario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtLogEmailDestinatario_Internalname, A629LogEmailDestinatario, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", 0, 1, edtLogEmailDestinatario_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_LogEmail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtLogEmailCreatedAt_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLogEmailCreatedAt_Internalname, "Created At", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtLogEmailCreatedAt_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtLogEmailCreatedAt_Internalname, context.localUtil.TToC( A630LogEmailCreatedAt, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A630LogEmailCreatedAt, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLogEmailCreatedAt_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLogEmailCreatedAt_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_LogEmail.htm");
         GxWebStd.gx_bitmap( context, edtLogEmailCreatedAt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtLogEmailCreatedAt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_LogEmail.htm");
         context.WriteHtmlTextNl( "</div>") ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "end", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_LogEmail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_LogEmail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_LogEmail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
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
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z626LogEmailId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z626LogEmailId"), ",", "."), 18, MidpointRounding.ToEven));
            Z628LogEmailSubject = cgiGet( "Z628LogEmailSubject");
            n628LogEmailSubject = (String.IsNullOrEmpty(StringUtil.RTrim( A628LogEmailSubject)) ? true : false);
            Z629LogEmailDestinatario = cgiGet( "Z629LogEmailDestinatario");
            n629LogEmailDestinatario = (String.IsNullOrEmpty(StringUtil.RTrim( A629LogEmailDestinatario)) ? true : false);
            Z630LogEmailCreatedAt = context.localUtil.CToT( cgiGet( "Z630LogEmailCreatedAt"), 0);
            n630LogEmailCreatedAt = ((DateTime.MinValue==A630LogEmailCreatedAt) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtLogEmailId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLogEmailId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LOGEMAILID");
               AnyError = 1;
               GX_FocusControl = edtLogEmailId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A626LogEmailId = 0;
               AssignAttri("", false, "A626LogEmailId", StringUtil.LTrimStr( (decimal)(A626LogEmailId), 9, 0));
            }
            else
            {
               A626LogEmailId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtLogEmailId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A626LogEmailId", StringUtil.LTrimStr( (decimal)(A626LogEmailId), 9, 0));
            }
            A627LogEmailCorpo = cgiGet( edtLogEmailCorpo_Internalname);
            n627LogEmailCorpo = false;
            AssignAttri("", false, "A627LogEmailCorpo", A627LogEmailCorpo);
            n627LogEmailCorpo = (String.IsNullOrEmpty(StringUtil.RTrim( A627LogEmailCorpo)) ? true : false);
            A628LogEmailSubject = cgiGet( edtLogEmailSubject_Internalname);
            n628LogEmailSubject = false;
            AssignAttri("", false, "A628LogEmailSubject", A628LogEmailSubject);
            n628LogEmailSubject = (String.IsNullOrEmpty(StringUtil.RTrim( A628LogEmailSubject)) ? true : false);
            A629LogEmailDestinatario = cgiGet( edtLogEmailDestinatario_Internalname);
            n629LogEmailDestinatario = false;
            AssignAttri("", false, "A629LogEmailDestinatario", A629LogEmailDestinatario);
            n629LogEmailDestinatario = (String.IsNullOrEmpty(StringUtil.RTrim( A629LogEmailDestinatario)) ? true : false);
            if ( context.localUtil.VCDateTime( cgiGet( edtLogEmailCreatedAt_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Log Email Created At"}), 1, "LOGEMAILCREATEDAT");
               AnyError = 1;
               GX_FocusControl = edtLogEmailCreatedAt_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A630LogEmailCreatedAt = (DateTime)(DateTime.MinValue);
               n630LogEmailCreatedAt = false;
               AssignAttri("", false, "A630LogEmailCreatedAt", context.localUtil.TToC( A630LogEmailCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A630LogEmailCreatedAt = context.localUtil.CToT( cgiGet( edtLogEmailCreatedAt_Internalname));
               n630LogEmailCreatedAt = false;
               AssignAttri("", false, "A630LogEmailCreatedAt", context.localUtil.TToC( A630LogEmailCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            }
            n630LogEmailCreatedAt = ((DateTime.MinValue==A630LogEmailCreatedAt) ? true : false);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A626LogEmailId = (int)(Math.Round(NumberUtil.Val( GetPar( "LogEmailId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A626LogEmailId", StringUtil.LTrimStr( (decimal)(A626LogEmailId), 9, 0));
               getEqualNoModal( ) ;
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               standaloneModal( ) ;
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
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
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
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2A80( ) ;
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
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes2A80( ) ;
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

      protected void ResetCaption2A0( )
      {
      }

      protected void ZM2A80( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z628LogEmailSubject = T002A3_A628LogEmailSubject[0];
               Z629LogEmailDestinatario = T002A3_A629LogEmailDestinatario[0];
               Z630LogEmailCreatedAt = T002A3_A630LogEmailCreatedAt[0];
            }
            else
            {
               Z628LogEmailSubject = A628LogEmailSubject;
               Z629LogEmailDestinatario = A629LogEmailDestinatario;
               Z630LogEmailCreatedAt = A630LogEmailCreatedAt;
            }
         }
         if ( GX_JID == -1 )
         {
            Z626LogEmailId = A626LogEmailId;
            Z627LogEmailCorpo = A627LogEmailCorpo;
            Z628LogEmailSubject = A628LogEmailSubject;
            Z629LogEmailDestinatario = A629LogEmailDestinatario;
            Z630LogEmailCreatedAt = A630LogEmailCreatedAt;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load2A80( )
      {
         /* Using cursor T002A4 */
         pr_default.execute(2, new Object[] {A626LogEmailId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound80 = 1;
            A627LogEmailCorpo = T002A4_A627LogEmailCorpo[0];
            n627LogEmailCorpo = T002A4_n627LogEmailCorpo[0];
            AssignAttri("", false, "A627LogEmailCorpo", A627LogEmailCorpo);
            A628LogEmailSubject = T002A4_A628LogEmailSubject[0];
            n628LogEmailSubject = T002A4_n628LogEmailSubject[0];
            AssignAttri("", false, "A628LogEmailSubject", A628LogEmailSubject);
            A629LogEmailDestinatario = T002A4_A629LogEmailDestinatario[0];
            n629LogEmailDestinatario = T002A4_n629LogEmailDestinatario[0];
            AssignAttri("", false, "A629LogEmailDestinatario", A629LogEmailDestinatario);
            A630LogEmailCreatedAt = T002A4_A630LogEmailCreatedAt[0];
            n630LogEmailCreatedAt = T002A4_n630LogEmailCreatedAt[0];
            AssignAttri("", false, "A630LogEmailCreatedAt", context.localUtil.TToC( A630LogEmailCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            ZM2A80( -1) ;
         }
         pr_default.close(2);
         OnLoadActions2A80( ) ;
      }

      protected void OnLoadActions2A80( )
      {
      }

      protected void CheckExtendedTable2A80( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors2A80( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2A80( )
      {
         /* Using cursor T002A5 */
         pr_default.execute(3, new Object[] {A626LogEmailId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound80 = 1;
         }
         else
         {
            RcdFound80 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002A3 */
         pr_default.execute(1, new Object[] {A626LogEmailId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2A80( 1) ;
            RcdFound80 = 1;
            A626LogEmailId = T002A3_A626LogEmailId[0];
            AssignAttri("", false, "A626LogEmailId", StringUtil.LTrimStr( (decimal)(A626LogEmailId), 9, 0));
            A627LogEmailCorpo = T002A3_A627LogEmailCorpo[0];
            n627LogEmailCorpo = T002A3_n627LogEmailCorpo[0];
            AssignAttri("", false, "A627LogEmailCorpo", A627LogEmailCorpo);
            A628LogEmailSubject = T002A3_A628LogEmailSubject[0];
            n628LogEmailSubject = T002A3_n628LogEmailSubject[0];
            AssignAttri("", false, "A628LogEmailSubject", A628LogEmailSubject);
            A629LogEmailDestinatario = T002A3_A629LogEmailDestinatario[0];
            n629LogEmailDestinatario = T002A3_n629LogEmailDestinatario[0];
            AssignAttri("", false, "A629LogEmailDestinatario", A629LogEmailDestinatario);
            A630LogEmailCreatedAt = T002A3_A630LogEmailCreatedAt[0];
            n630LogEmailCreatedAt = T002A3_n630LogEmailCreatedAt[0];
            AssignAttri("", false, "A630LogEmailCreatedAt", context.localUtil.TToC( A630LogEmailCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            Z626LogEmailId = A626LogEmailId;
            sMode80 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2A80( ) ;
            if ( AnyError == 1 )
            {
               RcdFound80 = 0;
               InitializeNonKey2A80( ) ;
            }
            Gx_mode = sMode80;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound80 = 0;
            InitializeNonKey2A80( ) ;
            sMode80 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode80;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2A80( ) ;
         if ( RcdFound80 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound80 = 0;
         /* Using cursor T002A6 */
         pr_default.execute(4, new Object[] {A626LogEmailId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T002A6_A626LogEmailId[0] < A626LogEmailId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T002A6_A626LogEmailId[0] > A626LogEmailId ) ) )
            {
               A626LogEmailId = T002A6_A626LogEmailId[0];
               AssignAttri("", false, "A626LogEmailId", StringUtil.LTrimStr( (decimal)(A626LogEmailId), 9, 0));
               RcdFound80 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound80 = 0;
         /* Using cursor T002A7 */
         pr_default.execute(5, new Object[] {A626LogEmailId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T002A7_A626LogEmailId[0] > A626LogEmailId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T002A7_A626LogEmailId[0] < A626LogEmailId ) ) )
            {
               A626LogEmailId = T002A7_A626LogEmailId[0];
               AssignAttri("", false, "A626LogEmailId", StringUtil.LTrimStr( (decimal)(A626LogEmailId), 9, 0));
               RcdFound80 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2A80( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtLogEmailId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2A80( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound80 == 1 )
            {
               if ( A626LogEmailId != Z626LogEmailId )
               {
                  A626LogEmailId = Z626LogEmailId;
                  AssignAttri("", false, "A626LogEmailId", StringUtil.LTrimStr( (decimal)(A626LogEmailId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "LOGEMAILID");
                  AnyError = 1;
                  GX_FocusControl = edtLogEmailId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtLogEmailId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2A80( ) ;
                  GX_FocusControl = edtLogEmailId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A626LogEmailId != Z626LogEmailId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtLogEmailId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2A80( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "LOGEMAILID");
                     AnyError = 1;
                     GX_FocusControl = edtLogEmailId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtLogEmailId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2A80( ) ;
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
      }

      protected void btn_delete( )
      {
         if ( A626LogEmailId != Z626LogEmailId )
         {
            A626LogEmailId = Z626LogEmailId;
            AssignAttri("", false, "A626LogEmailId", StringUtil.LTrimStr( (decimal)(A626LogEmailId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "LOGEMAILID");
            AnyError = 1;
            GX_FocusControl = edtLogEmailId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtLogEmailId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound80 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "LOGEMAILID");
            AnyError = 1;
            GX_FocusControl = edtLogEmailId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtLogEmailCorpo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2A80( ) ;
         if ( RcdFound80 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLogEmailCorpo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2A80( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound80 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLogEmailCorpo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound80 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLogEmailCorpo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2A80( ) ;
         if ( RcdFound80 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound80 != 0 )
            {
               ScanNext2A80( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLogEmailCorpo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2A80( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2A80( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002A2 */
            pr_default.execute(0, new Object[] {A626LogEmailId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"LogEmail"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z628LogEmailSubject, T002A2_A628LogEmailSubject[0]) != 0 ) || ( StringUtil.StrCmp(Z629LogEmailDestinatario, T002A2_A629LogEmailDestinatario[0]) != 0 ) || ( Z630LogEmailCreatedAt != T002A2_A630LogEmailCreatedAt[0] ) )
            {
               if ( StringUtil.StrCmp(Z628LogEmailSubject, T002A2_A628LogEmailSubject[0]) != 0 )
               {
                  GXUtil.WriteLog("logemail:[seudo value changed for attri]"+"LogEmailSubject");
                  GXUtil.WriteLogRaw("Old: ",Z628LogEmailSubject);
                  GXUtil.WriteLogRaw("Current: ",T002A2_A628LogEmailSubject[0]);
               }
               if ( StringUtil.StrCmp(Z629LogEmailDestinatario, T002A2_A629LogEmailDestinatario[0]) != 0 )
               {
                  GXUtil.WriteLog("logemail:[seudo value changed for attri]"+"LogEmailDestinatario");
                  GXUtil.WriteLogRaw("Old: ",Z629LogEmailDestinatario);
                  GXUtil.WriteLogRaw("Current: ",T002A2_A629LogEmailDestinatario[0]);
               }
               if ( Z630LogEmailCreatedAt != T002A2_A630LogEmailCreatedAt[0] )
               {
                  GXUtil.WriteLog("logemail:[seudo value changed for attri]"+"LogEmailCreatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z630LogEmailCreatedAt);
                  GXUtil.WriteLogRaw("Current: ",T002A2_A630LogEmailCreatedAt[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"LogEmail"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2A80( )
      {
         BeforeValidate2A80( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2A80( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2A80( 0) ;
            CheckOptimisticConcurrency2A80( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2A80( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2A80( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002A8 */
                     pr_default.execute(6, new Object[] {n627LogEmailCorpo, A627LogEmailCorpo, n628LogEmailSubject, A628LogEmailSubject, n629LogEmailDestinatario, A629LogEmailDestinatario, n630LogEmailCreatedAt, A630LogEmailCreatedAt});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor T002A9 */
                     pr_default.execute(7);
                     A626LogEmailId = T002A9_A626LogEmailId[0];
                     AssignAttri("", false, "A626LogEmailId", StringUtil.LTrimStr( (decimal)(A626LogEmailId), 9, 0));
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("LogEmail");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption2A0( ) ;
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
               Load2A80( ) ;
            }
            EndLevel2A80( ) ;
         }
         CloseExtendedTableCursors2A80( ) ;
      }

      protected void Update2A80( )
      {
         BeforeValidate2A80( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2A80( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2A80( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2A80( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2A80( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002A10 */
                     pr_default.execute(8, new Object[] {n627LogEmailCorpo, A627LogEmailCorpo, n628LogEmailSubject, A628LogEmailSubject, n629LogEmailDestinatario, A629LogEmailDestinatario, n630LogEmailCreatedAt, A630LogEmailCreatedAt, A626LogEmailId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("LogEmail");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"LogEmail"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2A80( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2A0( ) ;
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
            EndLevel2A80( ) ;
         }
         CloseExtendedTableCursors2A80( ) ;
      }

      protected void DeferredUpdate2A80( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2A80( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2A80( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2A80( ) ;
            AfterConfirm2A80( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2A80( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002A11 */
                  pr_default.execute(9, new Object[] {A626LogEmailId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("LogEmail");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound80 == 0 )
                        {
                           InitAll2A80( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption2A0( ) ;
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
         sMode80 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2A80( ) ;
         Gx_mode = sMode80;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2A80( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2A80( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2A80( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues2A0( ) ;
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

      public void ScanStart2A80( )
      {
         /* Using cursor T002A12 */
         pr_default.execute(10);
         RcdFound80 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound80 = 1;
            A626LogEmailId = T002A12_A626LogEmailId[0];
            AssignAttri("", false, "A626LogEmailId", StringUtil.LTrimStr( (decimal)(A626LogEmailId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2A80( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound80 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound80 = 1;
            A626LogEmailId = T002A12_A626LogEmailId[0];
            AssignAttri("", false, "A626LogEmailId", StringUtil.LTrimStr( (decimal)(A626LogEmailId), 9, 0));
         }
      }

      protected void ScanEnd2A80( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm2A80( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2A80( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2A80( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2A80( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2A80( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2A80( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2A80( )
      {
         edtLogEmailId_Enabled = 0;
         AssignProp("", false, edtLogEmailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLogEmailId_Enabled), 5, 0), true);
         edtLogEmailCorpo_Enabled = 0;
         AssignProp("", false, edtLogEmailCorpo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLogEmailCorpo_Enabled), 5, 0), true);
         edtLogEmailSubject_Enabled = 0;
         AssignProp("", false, edtLogEmailSubject_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLogEmailSubject_Enabled), 5, 0), true);
         edtLogEmailDestinatario_Enabled = 0;
         AssignProp("", false, edtLogEmailDestinatario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLogEmailDestinatario_Enabled), 5, 0), true);
         edtLogEmailCreatedAt_Enabled = 0;
         AssignProp("", false, edtLogEmailCreatedAt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLogEmailCreatedAt_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2A80( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2A0( )
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
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("logemail") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z626LogEmailId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z626LogEmailId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z628LogEmailSubject", Z628LogEmailSubject);
         GxWebStd.gx_hidden_field( context, "Z629LogEmailDestinatario", Z629LogEmailDestinatario);
         GxWebStd.gx_hidden_field( context, "Z630LogEmailCreatedAt", context.localUtil.TToC( Z630LogEmailCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
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
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
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
         return formatLink("logemail")  ;
      }

      public override string GetPgmname( )
      {
         return "LogEmail" ;
      }

      public override string GetPgmdesc( )
      {
         return "Log Email" ;
      }

      protected void InitializeNonKey2A80( )
      {
         A627LogEmailCorpo = "";
         n627LogEmailCorpo = false;
         AssignAttri("", false, "A627LogEmailCorpo", A627LogEmailCorpo);
         n627LogEmailCorpo = (String.IsNullOrEmpty(StringUtil.RTrim( A627LogEmailCorpo)) ? true : false);
         A628LogEmailSubject = "";
         n628LogEmailSubject = false;
         AssignAttri("", false, "A628LogEmailSubject", A628LogEmailSubject);
         n628LogEmailSubject = (String.IsNullOrEmpty(StringUtil.RTrim( A628LogEmailSubject)) ? true : false);
         A629LogEmailDestinatario = "";
         n629LogEmailDestinatario = false;
         AssignAttri("", false, "A629LogEmailDestinatario", A629LogEmailDestinatario);
         n629LogEmailDestinatario = (String.IsNullOrEmpty(StringUtil.RTrim( A629LogEmailDestinatario)) ? true : false);
         A630LogEmailCreatedAt = (DateTime)(DateTime.MinValue);
         n630LogEmailCreatedAt = false;
         AssignAttri("", false, "A630LogEmailCreatedAt", context.localUtil.TToC( A630LogEmailCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         n630LogEmailCreatedAt = ((DateTime.MinValue==A630LogEmailCreatedAt) ? true : false);
         Z628LogEmailSubject = "";
         Z629LogEmailDestinatario = "";
         Z630LogEmailCreatedAt = (DateTime)(DateTime.MinValue);
      }

      protected void InitAll2A80( )
      {
         A626LogEmailId = 0;
         AssignAttri("", false, "A626LogEmailId", StringUtil.LTrimStr( (decimal)(A626LogEmailId), 9, 0));
         InitializeNonKey2A80( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101919334", true, true);
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
         context.AddJavascriptSource("logemail.js", "?20256101919334", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtLogEmailId_Internalname = "LOGEMAILID";
         edtLogEmailCorpo_Internalname = "LOGEMAILCORPO";
         edtLogEmailSubject_Internalname = "LOGEMAILSUBJECT";
         edtLogEmailDestinatario_Internalname = "LOGEMAILDESTINATARIO";
         edtLogEmailCreatedAt_Internalname = "LOGEMAILCREATEDAT";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
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
         Form.Caption = "Log Email";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtLogEmailCreatedAt_Jsonclick = "";
         edtLogEmailCreatedAt_Enabled = 1;
         edtLogEmailDestinatario_Enabled = 1;
         edtLogEmailSubject_Jsonclick = "";
         edtLogEmailSubject_Enabled = 1;
         edtLogEmailCorpo_Enabled = 1;
         edtLogEmailId_Jsonclick = "";
         edtLogEmailId_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
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

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtLogEmailCorpo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
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

      public void Valid_Logemailid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A627LogEmailCorpo", A627LogEmailCorpo);
         AssignAttri("", false, "A628LogEmailSubject", A628LogEmailSubject);
         AssignAttri("", false, "A629LogEmailDestinatario", A629LogEmailDestinatario);
         AssignAttri("", false, "A630LogEmailCreatedAt", context.localUtil.TToC( A630LogEmailCreatedAt, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z626LogEmailId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z626LogEmailId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z627LogEmailCorpo", Z627LogEmailCorpo);
         GxWebStd.gx_hidden_field( context, "Z628LogEmailSubject", Z628LogEmailSubject);
         GxWebStd.gx_hidden_field( context, "Z629LogEmailDestinatario", Z629LogEmailDestinatario);
         GxWebStd.gx_hidden_field( context, "Z630LogEmailCreatedAt", context.localUtil.TToC( Z630LogEmailCreatedAt, 10, 8, 0, 3, "/", ":", " "));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("VALID_LOGEMAILID","""{"handler":"Valid_Logemailid","iparms":[{"av":"A626LogEmailId","fld":"LOGEMAILID","pic":"ZZZZZZZZ9","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"}]""");
         setEventMetadata("VALID_LOGEMAILID",""","oparms":[{"av":"A627LogEmailCorpo","fld":"LOGEMAILCORPO","type":"vchar"},{"av":"A628LogEmailSubject","fld":"LOGEMAILSUBJECT","type":"svchar"},{"av":"A629LogEmailDestinatario","fld":"LOGEMAILDESTINATARIO","type":"svchar"},{"av":"A630LogEmailCreatedAt","fld":"LOGEMAILCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"Z626LogEmailId","type":"int"},{"av":"Z627LogEmailCorpo","type":"vchar"},{"av":"Z628LogEmailSubject","type":"svchar"},{"av":"Z629LogEmailDestinatario","type":"svchar"},{"av":"Z630LogEmailCreatedAt","type":"dtime"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
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
         Z628LogEmailSubject = "";
         Z629LogEmailDestinatario = "";
         Z630LogEmailCreatedAt = (DateTime)(DateTime.MinValue);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A627LogEmailCorpo = "";
         A628LogEmailSubject = "";
         A629LogEmailDestinatario = "";
         A630LogEmailCreatedAt = (DateTime)(DateTime.MinValue);
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z627LogEmailCorpo = "";
         T002A4_A626LogEmailId = new int[1] ;
         T002A4_A627LogEmailCorpo = new string[] {""} ;
         T002A4_n627LogEmailCorpo = new bool[] {false} ;
         T002A4_A628LogEmailSubject = new string[] {""} ;
         T002A4_n628LogEmailSubject = new bool[] {false} ;
         T002A4_A629LogEmailDestinatario = new string[] {""} ;
         T002A4_n629LogEmailDestinatario = new bool[] {false} ;
         T002A4_A630LogEmailCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T002A4_n630LogEmailCreatedAt = new bool[] {false} ;
         T002A5_A626LogEmailId = new int[1] ;
         T002A3_A626LogEmailId = new int[1] ;
         T002A3_A627LogEmailCorpo = new string[] {""} ;
         T002A3_n627LogEmailCorpo = new bool[] {false} ;
         T002A3_A628LogEmailSubject = new string[] {""} ;
         T002A3_n628LogEmailSubject = new bool[] {false} ;
         T002A3_A629LogEmailDestinatario = new string[] {""} ;
         T002A3_n629LogEmailDestinatario = new bool[] {false} ;
         T002A3_A630LogEmailCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T002A3_n630LogEmailCreatedAt = new bool[] {false} ;
         sMode80 = "";
         T002A6_A626LogEmailId = new int[1] ;
         T002A7_A626LogEmailId = new int[1] ;
         T002A2_A626LogEmailId = new int[1] ;
         T002A2_A627LogEmailCorpo = new string[] {""} ;
         T002A2_n627LogEmailCorpo = new bool[] {false} ;
         T002A2_A628LogEmailSubject = new string[] {""} ;
         T002A2_n628LogEmailSubject = new bool[] {false} ;
         T002A2_A629LogEmailDestinatario = new string[] {""} ;
         T002A2_n629LogEmailDestinatario = new bool[] {false} ;
         T002A2_A630LogEmailCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T002A2_n630LogEmailCreatedAt = new bool[] {false} ;
         T002A9_A626LogEmailId = new int[1] ;
         T002A12_A626LogEmailId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ627LogEmailCorpo = "";
         ZZ628LogEmailSubject = "";
         ZZ629LogEmailDestinatario = "";
         ZZ630LogEmailCreatedAt = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.logemail__default(),
            new Object[][] {
                new Object[] {
               T002A2_A626LogEmailId, T002A2_A627LogEmailCorpo, T002A2_n627LogEmailCorpo, T002A2_A628LogEmailSubject, T002A2_n628LogEmailSubject, T002A2_A629LogEmailDestinatario, T002A2_n629LogEmailDestinatario, T002A2_A630LogEmailCreatedAt, T002A2_n630LogEmailCreatedAt
               }
               , new Object[] {
               T002A3_A626LogEmailId, T002A3_A627LogEmailCorpo, T002A3_n627LogEmailCorpo, T002A3_A628LogEmailSubject, T002A3_n628LogEmailSubject, T002A3_A629LogEmailDestinatario, T002A3_n629LogEmailDestinatario, T002A3_A630LogEmailCreatedAt, T002A3_n630LogEmailCreatedAt
               }
               , new Object[] {
               T002A4_A626LogEmailId, T002A4_A627LogEmailCorpo, T002A4_n627LogEmailCorpo, T002A4_A628LogEmailSubject, T002A4_n628LogEmailSubject, T002A4_A629LogEmailDestinatario, T002A4_n629LogEmailDestinatario, T002A4_A630LogEmailCreatedAt, T002A4_n630LogEmailCreatedAt
               }
               , new Object[] {
               T002A5_A626LogEmailId
               }
               , new Object[] {
               T002A6_A626LogEmailId
               }
               , new Object[] {
               T002A7_A626LogEmailId
               }
               , new Object[] {
               }
               , new Object[] {
               T002A9_A626LogEmailId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002A12_A626LogEmailId
               }
            }
         );
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound80 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z626LogEmailId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A626LogEmailId ;
      private int edtLogEmailId_Enabled ;
      private int edtLogEmailCorpo_Enabled ;
      private int edtLogEmailSubject_Enabled ;
      private int edtLogEmailDestinatario_Enabled ;
      private int edtLogEmailCreatedAt_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ626LogEmailId ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtLogEmailId_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtLogEmailId_Jsonclick ;
      private string edtLogEmailCorpo_Internalname ;
      private string edtLogEmailSubject_Internalname ;
      private string edtLogEmailSubject_Jsonclick ;
      private string edtLogEmailDestinatario_Internalname ;
      private string edtLogEmailCreatedAt_Internalname ;
      private string edtLogEmailCreatedAt_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode80 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z630LogEmailCreatedAt ;
      private DateTime A630LogEmailCreatedAt ;
      private DateTime ZZ630LogEmailCreatedAt ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n628LogEmailSubject ;
      private bool n629LogEmailDestinatario ;
      private bool n630LogEmailCreatedAt ;
      private bool n627LogEmailCorpo ;
      private string A627LogEmailCorpo ;
      private string Z627LogEmailCorpo ;
      private string ZZ627LogEmailCorpo ;
      private string Z628LogEmailSubject ;
      private string Z629LogEmailDestinatario ;
      private string A628LogEmailSubject ;
      private string A629LogEmailDestinatario ;
      private string ZZ628LogEmailSubject ;
      private string ZZ629LogEmailDestinatario ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T002A4_A626LogEmailId ;
      private string[] T002A4_A627LogEmailCorpo ;
      private bool[] T002A4_n627LogEmailCorpo ;
      private string[] T002A4_A628LogEmailSubject ;
      private bool[] T002A4_n628LogEmailSubject ;
      private string[] T002A4_A629LogEmailDestinatario ;
      private bool[] T002A4_n629LogEmailDestinatario ;
      private DateTime[] T002A4_A630LogEmailCreatedAt ;
      private bool[] T002A4_n630LogEmailCreatedAt ;
      private int[] T002A5_A626LogEmailId ;
      private int[] T002A3_A626LogEmailId ;
      private string[] T002A3_A627LogEmailCorpo ;
      private bool[] T002A3_n627LogEmailCorpo ;
      private string[] T002A3_A628LogEmailSubject ;
      private bool[] T002A3_n628LogEmailSubject ;
      private string[] T002A3_A629LogEmailDestinatario ;
      private bool[] T002A3_n629LogEmailDestinatario ;
      private DateTime[] T002A3_A630LogEmailCreatedAt ;
      private bool[] T002A3_n630LogEmailCreatedAt ;
      private int[] T002A6_A626LogEmailId ;
      private int[] T002A7_A626LogEmailId ;
      private int[] T002A2_A626LogEmailId ;
      private string[] T002A2_A627LogEmailCorpo ;
      private bool[] T002A2_n627LogEmailCorpo ;
      private string[] T002A2_A628LogEmailSubject ;
      private bool[] T002A2_n628LogEmailSubject ;
      private string[] T002A2_A629LogEmailDestinatario ;
      private bool[] T002A2_n629LogEmailDestinatario ;
      private DateTime[] T002A2_A630LogEmailCreatedAt ;
      private bool[] T002A2_n630LogEmailCreatedAt ;
      private int[] T002A9_A626LogEmailId ;
      private int[] T002A12_A626LogEmailId ;
   }

   public class logemail__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT002A2;
          prmT002A2 = new Object[] {
          new ParDef("LogEmailId",GXType.Int32,9,0)
          };
          Object[] prmT002A3;
          prmT002A3 = new Object[] {
          new ParDef("LogEmailId",GXType.Int32,9,0)
          };
          Object[] prmT002A4;
          prmT002A4 = new Object[] {
          new ParDef("LogEmailId",GXType.Int32,9,0)
          };
          Object[] prmT002A5;
          prmT002A5 = new Object[] {
          new ParDef("LogEmailId",GXType.Int32,9,0)
          };
          Object[] prmT002A6;
          prmT002A6 = new Object[] {
          new ParDef("LogEmailId",GXType.Int32,9,0)
          };
          Object[] prmT002A7;
          prmT002A7 = new Object[] {
          new ParDef("LogEmailId",GXType.Int32,9,0)
          };
          Object[] prmT002A8;
          prmT002A8 = new Object[] {
          new ParDef("LogEmailCorpo",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("LogEmailSubject",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("LogEmailDestinatario",GXType.VarChar,255,0){Nullable=true} ,
          new ParDef("LogEmailCreatedAt",GXType.DateTime,8,5){Nullable=true}
          };
          Object[] prmT002A9;
          prmT002A9 = new Object[] {
          };
          Object[] prmT002A10;
          prmT002A10 = new Object[] {
          new ParDef("LogEmailCorpo",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("LogEmailSubject",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("LogEmailDestinatario",GXType.VarChar,255,0){Nullable=true} ,
          new ParDef("LogEmailCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("LogEmailId",GXType.Int32,9,0)
          };
          Object[] prmT002A11;
          prmT002A11 = new Object[] {
          new ParDef("LogEmailId",GXType.Int32,9,0)
          };
          Object[] prmT002A12;
          prmT002A12 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T002A2", "SELECT LogEmailId, LogEmailCorpo, LogEmailSubject, LogEmailDestinatario, LogEmailCreatedAt FROM LogEmail WHERE LogEmailId = :LogEmailId  FOR UPDATE OF LogEmail NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT002A2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002A3", "SELECT LogEmailId, LogEmailCorpo, LogEmailSubject, LogEmailDestinatario, LogEmailCreatedAt FROM LogEmail WHERE LogEmailId = :LogEmailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002A3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002A4", "SELECT TM1.LogEmailId, TM1.LogEmailCorpo, TM1.LogEmailSubject, TM1.LogEmailDestinatario, TM1.LogEmailCreatedAt FROM LogEmail TM1 WHERE TM1.LogEmailId = :LogEmailId ORDER BY TM1.LogEmailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002A4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002A5", "SELECT LogEmailId FROM LogEmail WHERE LogEmailId = :LogEmailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002A5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002A6", "SELECT LogEmailId FROM LogEmail WHERE ( LogEmailId > :LogEmailId) ORDER BY LogEmailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002A6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002A7", "SELECT LogEmailId FROM LogEmail WHERE ( LogEmailId < :LogEmailId) ORDER BY LogEmailId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT002A7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002A8", "SAVEPOINT gxupdate;INSERT INTO LogEmail(LogEmailCorpo, LogEmailSubject, LogEmailDestinatario, LogEmailCreatedAt) VALUES(:LogEmailCorpo, :LogEmailSubject, :LogEmailDestinatario, :LogEmailCreatedAt);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT002A8)
             ,new CursorDef("T002A9", "SELECT currval('LogEmailId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT002A9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002A10", "SAVEPOINT gxupdate;UPDATE LogEmail SET LogEmailCorpo=:LogEmailCorpo, LogEmailSubject=:LogEmailSubject, LogEmailDestinatario=:LogEmailDestinatario, LogEmailCreatedAt=:LogEmailCreatedAt  WHERE LogEmailId = :LogEmailId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002A10)
             ,new CursorDef("T002A11", "SAVEPOINT gxupdate;DELETE FROM LogEmail  WHERE LogEmailId = :LogEmailId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002A11)
             ,new CursorDef("T002A12", "SELECT LogEmailId FROM LogEmail ORDER BY LogEmailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002A12,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
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
