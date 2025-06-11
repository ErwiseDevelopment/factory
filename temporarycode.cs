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
   public class temporarycode : GXDataArea
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
         Form.Meta.addItem("description", "Temporary Code", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTemporaryCodeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public temporarycode( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public temporarycode( IGxContext context )
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
         chkTemporaryCodeUsed = new GXCheckbox();
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
         A218TemporaryCodeUsed = StringUtil.StrToBool( StringUtil.BoolToStr( A218TemporaryCodeUsed));
         n218TemporaryCodeUsed = false;
         AssignAttri("", false, "A218TemporaryCodeUsed", A218TemporaryCodeUsed);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Temporary Code", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_TemporaryCode.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TemporaryCode.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TemporaryCode.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TemporaryCode.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TemporaryCode.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_TemporaryCode.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTemporaryCodeId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTemporaryCodeId_Internalname, "Code Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTemporaryCodeId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A214TemporaryCodeId), 9, 0, ",", "")), StringUtil.LTrim( ((edtTemporaryCodeId_Enabled!=0) ? context.localUtil.Format( (decimal)(A214TemporaryCodeId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A214TemporaryCodeId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTemporaryCodeId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTemporaryCodeId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TemporaryCode.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTemporaryCodeContent_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTemporaryCodeContent_Internalname, "Code Content", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTemporaryCodeContent_Internalname, A215TemporaryCodeContent, StringUtil.RTrim( context.localUtil.Format( A215TemporaryCodeContent, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTemporaryCodeContent_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTemporaryCodeContent_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_TemporaryCode.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTemporaryCodeDateTime_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTemporaryCodeDateTime_Internalname, "Date Time", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTemporaryCodeDateTime_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTemporaryCodeDateTime_Internalname, context.localUtil.TToC( A216TemporaryCodeDateTime, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A216TemporaryCodeDateTime, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTemporaryCodeDateTime_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTemporaryCodeDateTime_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_TemporaryCode.htm");
         GxWebStd.gx_bitmap( context, edtTemporaryCodeDateTime_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTemporaryCodeDateTime_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TemporaryCode.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTemporaryCodeEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTemporaryCodeEmail_Internalname, "Code Email", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTemporaryCodeEmail_Internalname, A217TemporaryCodeEmail, StringUtil.RTrim( context.localUtil.Format( A217TemporaryCodeEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A217TemporaryCodeEmail, "", "", "", edtTemporaryCodeEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTemporaryCodeEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_TemporaryCode.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkTemporaryCodeUsed_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTemporaryCodeUsed_Internalname, "Code Used", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTemporaryCodeUsed_Internalname, StringUtil.BoolToStr( A218TemporaryCodeUsed), "", "Code Used", 1, chkTemporaryCodeUsed.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(54, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,54);\"");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TemporaryCode.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TemporaryCode.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TemporaryCode.htm");
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
            Z214TemporaryCodeId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z214TemporaryCodeId"), ",", "."), 18, MidpointRounding.ToEven));
            Z215TemporaryCodeContent = cgiGet( "Z215TemporaryCodeContent");
            n215TemporaryCodeContent = (String.IsNullOrEmpty(StringUtil.RTrim( A215TemporaryCodeContent)) ? true : false);
            Z216TemporaryCodeDateTime = context.localUtil.CToT( cgiGet( "Z216TemporaryCodeDateTime"), 0);
            n216TemporaryCodeDateTime = ((DateTime.MinValue==A216TemporaryCodeDateTime) ? true : false);
            Z217TemporaryCodeEmail = cgiGet( "Z217TemporaryCodeEmail");
            n217TemporaryCodeEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A217TemporaryCodeEmail)) ? true : false);
            Z218TemporaryCodeUsed = StringUtil.StrToBool( cgiGet( "Z218TemporaryCodeUsed"));
            n218TemporaryCodeUsed = ((false==A218TemporaryCodeUsed) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtTemporaryCodeId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTemporaryCodeId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TEMPORARYCODEID");
               AnyError = 1;
               GX_FocusControl = edtTemporaryCodeId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A214TemporaryCodeId = 0;
               AssignAttri("", false, "A214TemporaryCodeId", StringUtil.LTrimStr( (decimal)(A214TemporaryCodeId), 9, 0));
            }
            else
            {
               A214TemporaryCodeId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtTemporaryCodeId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A214TemporaryCodeId", StringUtil.LTrimStr( (decimal)(A214TemporaryCodeId), 9, 0));
            }
            A215TemporaryCodeContent = cgiGet( edtTemporaryCodeContent_Internalname);
            n215TemporaryCodeContent = false;
            AssignAttri("", false, "A215TemporaryCodeContent", A215TemporaryCodeContent);
            n215TemporaryCodeContent = (String.IsNullOrEmpty(StringUtil.RTrim( A215TemporaryCodeContent)) ? true : false);
            if ( context.localUtil.VCDateTime( cgiGet( edtTemporaryCodeDateTime_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Temporary Code Date Time"}), 1, "TEMPORARYCODEDATETIME");
               AnyError = 1;
               GX_FocusControl = edtTemporaryCodeDateTime_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A216TemporaryCodeDateTime = (DateTime)(DateTime.MinValue);
               n216TemporaryCodeDateTime = false;
               AssignAttri("", false, "A216TemporaryCodeDateTime", context.localUtil.TToC( A216TemporaryCodeDateTime, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A216TemporaryCodeDateTime = context.localUtil.CToT( cgiGet( edtTemporaryCodeDateTime_Internalname));
               n216TemporaryCodeDateTime = false;
               AssignAttri("", false, "A216TemporaryCodeDateTime", context.localUtil.TToC( A216TemporaryCodeDateTime, 8, 5, 0, 3, "/", ":", " "));
            }
            n216TemporaryCodeDateTime = ((DateTime.MinValue==A216TemporaryCodeDateTime) ? true : false);
            A217TemporaryCodeEmail = cgiGet( edtTemporaryCodeEmail_Internalname);
            n217TemporaryCodeEmail = false;
            AssignAttri("", false, "A217TemporaryCodeEmail", A217TemporaryCodeEmail);
            n217TemporaryCodeEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A217TemporaryCodeEmail)) ? true : false);
            A218TemporaryCodeUsed = StringUtil.StrToBool( cgiGet( chkTemporaryCodeUsed_Internalname));
            n218TemporaryCodeUsed = false;
            AssignAttri("", false, "A218TemporaryCodeUsed", A218TemporaryCodeUsed);
            n218TemporaryCodeUsed = ((false==A218TemporaryCodeUsed) ? true : false);
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
               A214TemporaryCodeId = (int)(Math.Round(NumberUtil.Val( GetPar( "TemporaryCodeId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A214TemporaryCodeId", StringUtil.LTrimStr( (decimal)(A214TemporaryCodeId), 9, 0));
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
               InitAll0V34( ) ;
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
         DisableAttributes0V34( ) ;
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

      protected void ResetCaption0V0( )
      {
      }

      protected void ZM0V34( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z215TemporaryCodeContent = T000V3_A215TemporaryCodeContent[0];
               Z216TemporaryCodeDateTime = T000V3_A216TemporaryCodeDateTime[0];
               Z217TemporaryCodeEmail = T000V3_A217TemporaryCodeEmail[0];
               Z218TemporaryCodeUsed = T000V3_A218TemporaryCodeUsed[0];
            }
            else
            {
               Z215TemporaryCodeContent = A215TemporaryCodeContent;
               Z216TemporaryCodeDateTime = A216TemporaryCodeDateTime;
               Z217TemporaryCodeEmail = A217TemporaryCodeEmail;
               Z218TemporaryCodeUsed = A218TemporaryCodeUsed;
            }
         }
         if ( GX_JID == -2 )
         {
            Z214TemporaryCodeId = A214TemporaryCodeId;
            Z215TemporaryCodeContent = A215TemporaryCodeContent;
            Z216TemporaryCodeDateTime = A216TemporaryCodeDateTime;
            Z217TemporaryCodeEmail = A217TemporaryCodeEmail;
            Z218TemporaryCodeUsed = A218TemporaryCodeUsed;
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

      protected void Load0V34( )
      {
         /* Using cursor T000V4 */
         pr_default.execute(2, new Object[] {A214TemporaryCodeId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound34 = 1;
            A215TemporaryCodeContent = T000V4_A215TemporaryCodeContent[0];
            n215TemporaryCodeContent = T000V4_n215TemporaryCodeContent[0];
            AssignAttri("", false, "A215TemporaryCodeContent", A215TemporaryCodeContent);
            A216TemporaryCodeDateTime = T000V4_A216TemporaryCodeDateTime[0];
            n216TemporaryCodeDateTime = T000V4_n216TemporaryCodeDateTime[0];
            AssignAttri("", false, "A216TemporaryCodeDateTime", context.localUtil.TToC( A216TemporaryCodeDateTime, 8, 5, 0, 3, "/", ":", " "));
            A217TemporaryCodeEmail = T000V4_A217TemporaryCodeEmail[0];
            n217TemporaryCodeEmail = T000V4_n217TemporaryCodeEmail[0];
            AssignAttri("", false, "A217TemporaryCodeEmail", A217TemporaryCodeEmail);
            A218TemporaryCodeUsed = T000V4_A218TemporaryCodeUsed[0];
            n218TemporaryCodeUsed = T000V4_n218TemporaryCodeUsed[0];
            AssignAttri("", false, "A218TemporaryCodeUsed", A218TemporaryCodeUsed);
            ZM0V34( -2) ;
         }
         pr_default.close(2);
         OnLoadActions0V34( ) ;
      }

      protected void OnLoadActions0V34( )
      {
      }

      protected void CheckExtendedTable0V34( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( GxRegex.IsMatch(A217TemporaryCodeEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A217TemporaryCodeEmail)) ) )
         {
            GX_msglist.addItem("O valor de Temporary Code Email não coincide com o padrão especificado", "OutOfRange", 1, "TEMPORARYCODEEMAIL");
            AnyError = 1;
            GX_FocusControl = edtTemporaryCodeEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0V34( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0V34( )
      {
         /* Using cursor T000V5 */
         pr_default.execute(3, new Object[] {A214TemporaryCodeId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound34 = 1;
         }
         else
         {
            RcdFound34 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000V3 */
         pr_default.execute(1, new Object[] {A214TemporaryCodeId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0V34( 2) ;
            RcdFound34 = 1;
            A214TemporaryCodeId = T000V3_A214TemporaryCodeId[0];
            AssignAttri("", false, "A214TemporaryCodeId", StringUtil.LTrimStr( (decimal)(A214TemporaryCodeId), 9, 0));
            A215TemporaryCodeContent = T000V3_A215TemporaryCodeContent[0];
            n215TemporaryCodeContent = T000V3_n215TemporaryCodeContent[0];
            AssignAttri("", false, "A215TemporaryCodeContent", A215TemporaryCodeContent);
            A216TemporaryCodeDateTime = T000V3_A216TemporaryCodeDateTime[0];
            n216TemporaryCodeDateTime = T000V3_n216TemporaryCodeDateTime[0];
            AssignAttri("", false, "A216TemporaryCodeDateTime", context.localUtil.TToC( A216TemporaryCodeDateTime, 8, 5, 0, 3, "/", ":", " "));
            A217TemporaryCodeEmail = T000V3_A217TemporaryCodeEmail[0];
            n217TemporaryCodeEmail = T000V3_n217TemporaryCodeEmail[0];
            AssignAttri("", false, "A217TemporaryCodeEmail", A217TemporaryCodeEmail);
            A218TemporaryCodeUsed = T000V3_A218TemporaryCodeUsed[0];
            n218TemporaryCodeUsed = T000V3_n218TemporaryCodeUsed[0];
            AssignAttri("", false, "A218TemporaryCodeUsed", A218TemporaryCodeUsed);
            Z214TemporaryCodeId = A214TemporaryCodeId;
            sMode34 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0V34( ) ;
            if ( AnyError == 1 )
            {
               RcdFound34 = 0;
               InitializeNonKey0V34( ) ;
            }
            Gx_mode = sMode34;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound34 = 0;
            InitializeNonKey0V34( ) ;
            sMode34 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode34;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0V34( ) ;
         if ( RcdFound34 == 0 )
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
         RcdFound34 = 0;
         /* Using cursor T000V6 */
         pr_default.execute(4, new Object[] {A214TemporaryCodeId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000V6_A214TemporaryCodeId[0] < A214TemporaryCodeId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000V6_A214TemporaryCodeId[0] > A214TemporaryCodeId ) ) )
            {
               A214TemporaryCodeId = T000V6_A214TemporaryCodeId[0];
               AssignAttri("", false, "A214TemporaryCodeId", StringUtil.LTrimStr( (decimal)(A214TemporaryCodeId), 9, 0));
               RcdFound34 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound34 = 0;
         /* Using cursor T000V7 */
         pr_default.execute(5, new Object[] {A214TemporaryCodeId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000V7_A214TemporaryCodeId[0] > A214TemporaryCodeId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000V7_A214TemporaryCodeId[0] < A214TemporaryCodeId ) ) )
            {
               A214TemporaryCodeId = T000V7_A214TemporaryCodeId[0];
               AssignAttri("", false, "A214TemporaryCodeId", StringUtil.LTrimStr( (decimal)(A214TemporaryCodeId), 9, 0));
               RcdFound34 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0V34( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTemporaryCodeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0V34( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound34 == 1 )
            {
               if ( A214TemporaryCodeId != Z214TemporaryCodeId )
               {
                  A214TemporaryCodeId = Z214TemporaryCodeId;
                  AssignAttri("", false, "A214TemporaryCodeId", StringUtil.LTrimStr( (decimal)(A214TemporaryCodeId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TEMPORARYCODEID");
                  AnyError = 1;
                  GX_FocusControl = edtTemporaryCodeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTemporaryCodeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0V34( ) ;
                  GX_FocusControl = edtTemporaryCodeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A214TemporaryCodeId != Z214TemporaryCodeId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTemporaryCodeId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0V34( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TEMPORARYCODEID");
                     AnyError = 1;
                     GX_FocusControl = edtTemporaryCodeId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTemporaryCodeId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0V34( ) ;
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
         if ( A214TemporaryCodeId != Z214TemporaryCodeId )
         {
            A214TemporaryCodeId = Z214TemporaryCodeId;
            AssignAttri("", false, "A214TemporaryCodeId", StringUtil.LTrimStr( (decimal)(A214TemporaryCodeId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TEMPORARYCODEID");
            AnyError = 1;
            GX_FocusControl = edtTemporaryCodeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTemporaryCodeId_Internalname;
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
         if ( RcdFound34 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TEMPORARYCODEID");
            AnyError = 1;
            GX_FocusControl = edtTemporaryCodeId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTemporaryCodeContent_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0V34( ) ;
         if ( RcdFound34 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTemporaryCodeContent_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0V34( ) ;
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
         if ( RcdFound34 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTemporaryCodeContent_Internalname;
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
         if ( RcdFound34 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTemporaryCodeContent_Internalname;
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
         ScanStart0V34( ) ;
         if ( RcdFound34 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound34 != 0 )
            {
               ScanNext0V34( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTemporaryCodeContent_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0V34( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0V34( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000V2 */
            pr_default.execute(0, new Object[] {A214TemporaryCodeId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TemporaryCode"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z215TemporaryCodeContent, T000V2_A215TemporaryCodeContent[0]) != 0 ) || ( Z216TemporaryCodeDateTime != T000V2_A216TemporaryCodeDateTime[0] ) || ( StringUtil.StrCmp(Z217TemporaryCodeEmail, T000V2_A217TemporaryCodeEmail[0]) != 0 ) || ( Z218TemporaryCodeUsed != T000V2_A218TemporaryCodeUsed[0] ) )
            {
               if ( StringUtil.StrCmp(Z215TemporaryCodeContent, T000V2_A215TemporaryCodeContent[0]) != 0 )
               {
                  GXUtil.WriteLog("temporarycode:[seudo value changed for attri]"+"TemporaryCodeContent");
                  GXUtil.WriteLogRaw("Old: ",Z215TemporaryCodeContent);
                  GXUtil.WriteLogRaw("Current: ",T000V2_A215TemporaryCodeContent[0]);
               }
               if ( Z216TemporaryCodeDateTime != T000V2_A216TemporaryCodeDateTime[0] )
               {
                  GXUtil.WriteLog("temporarycode:[seudo value changed for attri]"+"TemporaryCodeDateTime");
                  GXUtil.WriteLogRaw("Old: ",Z216TemporaryCodeDateTime);
                  GXUtil.WriteLogRaw("Current: ",T000V2_A216TemporaryCodeDateTime[0]);
               }
               if ( StringUtil.StrCmp(Z217TemporaryCodeEmail, T000V2_A217TemporaryCodeEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("temporarycode:[seudo value changed for attri]"+"TemporaryCodeEmail");
                  GXUtil.WriteLogRaw("Old: ",Z217TemporaryCodeEmail);
                  GXUtil.WriteLogRaw("Current: ",T000V2_A217TemporaryCodeEmail[0]);
               }
               if ( Z218TemporaryCodeUsed != T000V2_A218TemporaryCodeUsed[0] )
               {
                  GXUtil.WriteLog("temporarycode:[seudo value changed for attri]"+"TemporaryCodeUsed");
                  GXUtil.WriteLogRaw("Old: ",Z218TemporaryCodeUsed);
                  GXUtil.WriteLogRaw("Current: ",T000V2_A218TemporaryCodeUsed[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TemporaryCode"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0V34( )
      {
         BeforeValidate0V34( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0V34( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0V34( 0) ;
            CheckOptimisticConcurrency0V34( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0V34( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0V34( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000V8 */
                     pr_default.execute(6, new Object[] {n215TemporaryCodeContent, A215TemporaryCodeContent, n216TemporaryCodeDateTime, A216TemporaryCodeDateTime, n217TemporaryCodeEmail, A217TemporaryCodeEmail, n218TemporaryCodeUsed, A218TemporaryCodeUsed});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000V9 */
                     pr_default.execute(7);
                     A214TemporaryCodeId = T000V9_A214TemporaryCodeId[0];
                     AssignAttri("", false, "A214TemporaryCodeId", StringUtil.LTrimStr( (decimal)(A214TemporaryCodeId), 9, 0));
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("TemporaryCode");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0V0( ) ;
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
               Load0V34( ) ;
            }
            EndLevel0V34( ) ;
         }
         CloseExtendedTableCursors0V34( ) ;
      }

      protected void Update0V34( )
      {
         BeforeValidate0V34( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0V34( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0V34( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0V34( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0V34( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000V10 */
                     pr_default.execute(8, new Object[] {n215TemporaryCodeContent, A215TemporaryCodeContent, n216TemporaryCodeDateTime, A216TemporaryCodeDateTime, n217TemporaryCodeEmail, A217TemporaryCodeEmail, n218TemporaryCodeUsed, A218TemporaryCodeUsed, A214TemporaryCodeId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("TemporaryCode");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TemporaryCode"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0V34( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0V0( ) ;
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
            EndLevel0V34( ) ;
         }
         CloseExtendedTableCursors0V34( ) ;
      }

      protected void DeferredUpdate0V34( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0V34( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0V34( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0V34( ) ;
            AfterConfirm0V34( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0V34( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000V11 */
                  pr_default.execute(9, new Object[] {A214TemporaryCodeId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("TemporaryCode");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound34 == 0 )
                        {
                           InitAll0V34( ) ;
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
                        ResetCaption0V0( ) ;
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
         sMode34 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0V34( ) ;
         Gx_mode = sMode34;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0V34( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0V34( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0V34( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues0V0( ) ;
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

      public void ScanStart0V34( )
      {
         /* Using cursor T000V12 */
         pr_default.execute(10);
         RcdFound34 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound34 = 1;
            A214TemporaryCodeId = T000V12_A214TemporaryCodeId[0];
            AssignAttri("", false, "A214TemporaryCodeId", StringUtil.LTrimStr( (decimal)(A214TemporaryCodeId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0V34( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound34 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound34 = 1;
            A214TemporaryCodeId = T000V12_A214TemporaryCodeId[0];
            AssignAttri("", false, "A214TemporaryCodeId", StringUtil.LTrimStr( (decimal)(A214TemporaryCodeId), 9, 0));
         }
      }

      protected void ScanEnd0V34( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0V34( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0V34( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0V34( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0V34( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0V34( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0V34( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0V34( )
      {
         edtTemporaryCodeId_Enabled = 0;
         AssignProp("", false, edtTemporaryCodeId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTemporaryCodeId_Enabled), 5, 0), true);
         edtTemporaryCodeContent_Enabled = 0;
         AssignProp("", false, edtTemporaryCodeContent_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTemporaryCodeContent_Enabled), 5, 0), true);
         edtTemporaryCodeDateTime_Enabled = 0;
         AssignProp("", false, edtTemporaryCodeDateTime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTemporaryCodeDateTime_Enabled), 5, 0), true);
         edtTemporaryCodeEmail_Enabled = 0;
         AssignProp("", false, edtTemporaryCodeEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTemporaryCodeEmail_Enabled), 5, 0), true);
         chkTemporaryCodeUsed.Enabled = 0;
         AssignProp("", false, chkTemporaryCodeUsed_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTemporaryCodeUsed.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0V34( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0V0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("temporarycode") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z214TemporaryCodeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z214TemporaryCodeId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z215TemporaryCodeContent", Z215TemporaryCodeContent);
         GxWebStd.gx_hidden_field( context, "Z216TemporaryCodeDateTime", context.localUtil.TToC( Z216TemporaryCodeDateTime, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z217TemporaryCodeEmail", Z217TemporaryCodeEmail);
         GxWebStd.gx_boolean_hidden_field( context, "Z218TemporaryCodeUsed", Z218TemporaryCodeUsed);
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
         return formatLink("temporarycode")  ;
      }

      public override string GetPgmname( )
      {
         return "TemporaryCode" ;
      }

      public override string GetPgmdesc( )
      {
         return "Temporary Code" ;
      }

      protected void InitializeNonKey0V34( )
      {
         A215TemporaryCodeContent = "";
         n215TemporaryCodeContent = false;
         AssignAttri("", false, "A215TemporaryCodeContent", A215TemporaryCodeContent);
         n215TemporaryCodeContent = (String.IsNullOrEmpty(StringUtil.RTrim( A215TemporaryCodeContent)) ? true : false);
         A216TemporaryCodeDateTime = (DateTime)(DateTime.MinValue);
         n216TemporaryCodeDateTime = false;
         AssignAttri("", false, "A216TemporaryCodeDateTime", context.localUtil.TToC( A216TemporaryCodeDateTime, 8, 5, 0, 3, "/", ":", " "));
         n216TemporaryCodeDateTime = ((DateTime.MinValue==A216TemporaryCodeDateTime) ? true : false);
         A217TemporaryCodeEmail = "";
         n217TemporaryCodeEmail = false;
         AssignAttri("", false, "A217TemporaryCodeEmail", A217TemporaryCodeEmail);
         n217TemporaryCodeEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A217TemporaryCodeEmail)) ? true : false);
         A218TemporaryCodeUsed = false;
         n218TemporaryCodeUsed = false;
         AssignAttri("", false, "A218TemporaryCodeUsed", A218TemporaryCodeUsed);
         n218TemporaryCodeUsed = ((false==A218TemporaryCodeUsed) ? true : false);
         Z215TemporaryCodeContent = "";
         Z216TemporaryCodeDateTime = (DateTime)(DateTime.MinValue);
         Z217TemporaryCodeEmail = "";
         Z218TemporaryCodeUsed = false;
      }

      protected void InitAll0V34( )
      {
         A214TemporaryCodeId = 0;
         AssignAttri("", false, "A214TemporaryCodeId", StringUtil.LTrimStr( (decimal)(A214TemporaryCodeId), 9, 0));
         InitializeNonKey0V34( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019133181", true, true);
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
         context.AddJavascriptSource("temporarycode.js", "?202561019133181", false, true);
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
         edtTemporaryCodeId_Internalname = "TEMPORARYCODEID";
         edtTemporaryCodeContent_Internalname = "TEMPORARYCODECONTENT";
         edtTemporaryCodeDateTime_Internalname = "TEMPORARYCODEDATETIME";
         edtTemporaryCodeEmail_Internalname = "TEMPORARYCODEEMAIL";
         chkTemporaryCodeUsed_Internalname = "TEMPORARYCODEUSED";
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
         Form.Caption = "Temporary Code";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chkTemporaryCodeUsed.Enabled = 1;
         edtTemporaryCodeEmail_Jsonclick = "";
         edtTemporaryCodeEmail_Enabled = 1;
         edtTemporaryCodeDateTime_Jsonclick = "";
         edtTemporaryCodeDateTime_Enabled = 1;
         edtTemporaryCodeContent_Jsonclick = "";
         edtTemporaryCodeContent_Enabled = 1;
         edtTemporaryCodeId_Jsonclick = "";
         edtTemporaryCodeId_Enabled = 1;
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
         chkTemporaryCodeUsed.Name = "TEMPORARYCODEUSED";
         chkTemporaryCodeUsed.WebTags = "";
         chkTemporaryCodeUsed.Caption = "Code Used";
         AssignProp("", false, chkTemporaryCodeUsed_Internalname, "TitleCaption", chkTemporaryCodeUsed.Caption, true);
         chkTemporaryCodeUsed.CheckedValue = "false";
         A218TemporaryCodeUsed = StringUtil.StrToBool( StringUtil.BoolToStr( A218TemporaryCodeUsed));
         n218TemporaryCodeUsed = false;
         AssignAttri("", false, "A218TemporaryCodeUsed", A218TemporaryCodeUsed);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtTemporaryCodeContent_Internalname;
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

      public void Valid_Temporarycodeid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A218TemporaryCodeUsed = StringUtil.StrToBool( StringUtil.BoolToStr( A218TemporaryCodeUsed));
         n218TemporaryCodeUsed = false;
         /*  Sending validation outputs */
         AssignAttri("", false, "A215TemporaryCodeContent", A215TemporaryCodeContent);
         AssignAttri("", false, "A216TemporaryCodeDateTime", context.localUtil.TToC( A216TemporaryCodeDateTime, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A217TemporaryCodeEmail", A217TemporaryCodeEmail);
         AssignAttri("", false, "A218TemporaryCodeUsed", A218TemporaryCodeUsed);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z214TemporaryCodeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z214TemporaryCodeId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z215TemporaryCodeContent", Z215TemporaryCodeContent);
         GxWebStd.gx_hidden_field( context, "Z216TemporaryCodeDateTime", context.localUtil.TToC( Z216TemporaryCodeDateTime, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z217TemporaryCodeEmail", Z217TemporaryCodeEmail);
         GxWebStd.gx_hidden_field( context, "Z218TemporaryCodeUsed", StringUtil.BoolToStr( Z218TemporaryCodeUsed));
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"A218TemporaryCodeUsed","fld":"TEMPORARYCODEUSED","type":"boolean"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A218TemporaryCodeUsed","fld":"TEMPORARYCODEUSED","type":"boolean"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A218TemporaryCodeUsed","fld":"TEMPORARYCODEUSED","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A218TemporaryCodeUsed","fld":"TEMPORARYCODEUSED","type":"boolean"}]}""");
         setEventMetadata("VALID_TEMPORARYCODEID","""{"handler":"Valid_Temporarycodeid","iparms":[{"av":"A214TemporaryCodeId","fld":"TEMPORARYCODEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"A218TemporaryCodeUsed","fld":"TEMPORARYCODEUSED","type":"boolean"}]""");
         setEventMetadata("VALID_TEMPORARYCODEID",""","oparms":[{"av":"A215TemporaryCodeContent","fld":"TEMPORARYCODECONTENT","type":"svchar"},{"av":"A216TemporaryCodeDateTime","fld":"TEMPORARYCODEDATETIME","pic":"99/99/99 99:99","type":"dtime"},{"av":"A217TemporaryCodeEmail","fld":"TEMPORARYCODEEMAIL","type":"svchar"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"Z214TemporaryCodeId","type":"int"},{"av":"Z215TemporaryCodeContent","type":"svchar"},{"av":"Z216TemporaryCodeDateTime","type":"dtime"},{"av":"Z217TemporaryCodeEmail","type":"svchar"},{"av":"Z218TemporaryCodeUsed","type":"boolean"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"},{"av":"A218TemporaryCodeUsed","fld":"TEMPORARYCODEUSED","type":"boolean"}]}""");
         setEventMetadata("VALID_TEMPORARYCODEEMAIL","""{"handler":"Valid_Temporarycodeemail","iparms":[{"av":"A218TemporaryCodeUsed","fld":"TEMPORARYCODEUSED","type":"boolean"}]""");
         setEventMetadata("VALID_TEMPORARYCODEEMAIL",""","oparms":[{"av":"A218TemporaryCodeUsed","fld":"TEMPORARYCODEUSED","type":"boolean"}]}""");
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
         Z215TemporaryCodeContent = "";
         Z216TemporaryCodeDateTime = (DateTime)(DateTime.MinValue);
         Z217TemporaryCodeEmail = "";
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
         A215TemporaryCodeContent = "";
         A216TemporaryCodeDateTime = (DateTime)(DateTime.MinValue);
         A217TemporaryCodeEmail = "";
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
         T000V4_A214TemporaryCodeId = new int[1] ;
         T000V4_A215TemporaryCodeContent = new string[] {""} ;
         T000V4_n215TemporaryCodeContent = new bool[] {false} ;
         T000V4_A216TemporaryCodeDateTime = new DateTime[] {DateTime.MinValue} ;
         T000V4_n216TemporaryCodeDateTime = new bool[] {false} ;
         T000V4_A217TemporaryCodeEmail = new string[] {""} ;
         T000V4_n217TemporaryCodeEmail = new bool[] {false} ;
         T000V4_A218TemporaryCodeUsed = new bool[] {false} ;
         T000V4_n218TemporaryCodeUsed = new bool[] {false} ;
         T000V5_A214TemporaryCodeId = new int[1] ;
         T000V3_A214TemporaryCodeId = new int[1] ;
         T000V3_A215TemporaryCodeContent = new string[] {""} ;
         T000V3_n215TemporaryCodeContent = new bool[] {false} ;
         T000V3_A216TemporaryCodeDateTime = new DateTime[] {DateTime.MinValue} ;
         T000V3_n216TemporaryCodeDateTime = new bool[] {false} ;
         T000V3_A217TemporaryCodeEmail = new string[] {""} ;
         T000V3_n217TemporaryCodeEmail = new bool[] {false} ;
         T000V3_A218TemporaryCodeUsed = new bool[] {false} ;
         T000V3_n218TemporaryCodeUsed = new bool[] {false} ;
         sMode34 = "";
         T000V6_A214TemporaryCodeId = new int[1] ;
         T000V7_A214TemporaryCodeId = new int[1] ;
         T000V2_A214TemporaryCodeId = new int[1] ;
         T000V2_A215TemporaryCodeContent = new string[] {""} ;
         T000V2_n215TemporaryCodeContent = new bool[] {false} ;
         T000V2_A216TemporaryCodeDateTime = new DateTime[] {DateTime.MinValue} ;
         T000V2_n216TemporaryCodeDateTime = new bool[] {false} ;
         T000V2_A217TemporaryCodeEmail = new string[] {""} ;
         T000V2_n217TemporaryCodeEmail = new bool[] {false} ;
         T000V2_A218TemporaryCodeUsed = new bool[] {false} ;
         T000V2_n218TemporaryCodeUsed = new bool[] {false} ;
         T000V9_A214TemporaryCodeId = new int[1] ;
         T000V12_A214TemporaryCodeId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ215TemporaryCodeContent = "";
         ZZ216TemporaryCodeDateTime = (DateTime)(DateTime.MinValue);
         ZZ217TemporaryCodeEmail = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.temporarycode__default(),
            new Object[][] {
                new Object[] {
               T000V2_A214TemporaryCodeId, T000V2_A215TemporaryCodeContent, T000V2_n215TemporaryCodeContent, T000V2_A216TemporaryCodeDateTime, T000V2_n216TemporaryCodeDateTime, T000V2_A217TemporaryCodeEmail, T000V2_n217TemporaryCodeEmail, T000V2_A218TemporaryCodeUsed, T000V2_n218TemporaryCodeUsed
               }
               , new Object[] {
               T000V3_A214TemporaryCodeId, T000V3_A215TemporaryCodeContent, T000V3_n215TemporaryCodeContent, T000V3_A216TemporaryCodeDateTime, T000V3_n216TemporaryCodeDateTime, T000V3_A217TemporaryCodeEmail, T000V3_n217TemporaryCodeEmail, T000V3_A218TemporaryCodeUsed, T000V3_n218TemporaryCodeUsed
               }
               , new Object[] {
               T000V4_A214TemporaryCodeId, T000V4_A215TemporaryCodeContent, T000V4_n215TemporaryCodeContent, T000V4_A216TemporaryCodeDateTime, T000V4_n216TemporaryCodeDateTime, T000V4_A217TemporaryCodeEmail, T000V4_n217TemporaryCodeEmail, T000V4_A218TemporaryCodeUsed, T000V4_n218TemporaryCodeUsed
               }
               , new Object[] {
               T000V5_A214TemporaryCodeId
               }
               , new Object[] {
               T000V6_A214TemporaryCodeId
               }
               , new Object[] {
               T000V7_A214TemporaryCodeId
               }
               , new Object[] {
               }
               , new Object[] {
               T000V9_A214TemporaryCodeId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000V12_A214TemporaryCodeId
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
      private short RcdFound34 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z214TemporaryCodeId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A214TemporaryCodeId ;
      private int edtTemporaryCodeId_Enabled ;
      private int edtTemporaryCodeContent_Enabled ;
      private int edtTemporaryCodeDateTime_Enabled ;
      private int edtTemporaryCodeEmail_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ214TemporaryCodeId ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTemporaryCodeId_Internalname ;
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
      private string edtTemporaryCodeId_Jsonclick ;
      private string edtTemporaryCodeContent_Internalname ;
      private string edtTemporaryCodeContent_Jsonclick ;
      private string edtTemporaryCodeDateTime_Internalname ;
      private string edtTemporaryCodeDateTime_Jsonclick ;
      private string edtTemporaryCodeEmail_Internalname ;
      private string edtTemporaryCodeEmail_Jsonclick ;
      private string chkTemporaryCodeUsed_Internalname ;
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
      private string sMode34 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z216TemporaryCodeDateTime ;
      private DateTime A216TemporaryCodeDateTime ;
      private DateTime ZZ216TemporaryCodeDateTime ;
      private bool Z218TemporaryCodeUsed ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A218TemporaryCodeUsed ;
      private bool n218TemporaryCodeUsed ;
      private bool n215TemporaryCodeContent ;
      private bool n216TemporaryCodeDateTime ;
      private bool n217TemporaryCodeEmail ;
      private bool ZZ218TemporaryCodeUsed ;
      private string Z215TemporaryCodeContent ;
      private string Z217TemporaryCodeEmail ;
      private string A215TemporaryCodeContent ;
      private string A217TemporaryCodeEmail ;
      private string ZZ215TemporaryCodeContent ;
      private string ZZ217TemporaryCodeEmail ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkTemporaryCodeUsed ;
      private IDataStoreProvider pr_default ;
      private int[] T000V4_A214TemporaryCodeId ;
      private string[] T000V4_A215TemporaryCodeContent ;
      private bool[] T000V4_n215TemporaryCodeContent ;
      private DateTime[] T000V4_A216TemporaryCodeDateTime ;
      private bool[] T000V4_n216TemporaryCodeDateTime ;
      private string[] T000V4_A217TemporaryCodeEmail ;
      private bool[] T000V4_n217TemporaryCodeEmail ;
      private bool[] T000V4_A218TemporaryCodeUsed ;
      private bool[] T000V4_n218TemporaryCodeUsed ;
      private int[] T000V5_A214TemporaryCodeId ;
      private int[] T000V3_A214TemporaryCodeId ;
      private string[] T000V3_A215TemporaryCodeContent ;
      private bool[] T000V3_n215TemporaryCodeContent ;
      private DateTime[] T000V3_A216TemporaryCodeDateTime ;
      private bool[] T000V3_n216TemporaryCodeDateTime ;
      private string[] T000V3_A217TemporaryCodeEmail ;
      private bool[] T000V3_n217TemporaryCodeEmail ;
      private bool[] T000V3_A218TemporaryCodeUsed ;
      private bool[] T000V3_n218TemporaryCodeUsed ;
      private int[] T000V6_A214TemporaryCodeId ;
      private int[] T000V7_A214TemporaryCodeId ;
      private int[] T000V2_A214TemporaryCodeId ;
      private string[] T000V2_A215TemporaryCodeContent ;
      private bool[] T000V2_n215TemporaryCodeContent ;
      private DateTime[] T000V2_A216TemporaryCodeDateTime ;
      private bool[] T000V2_n216TemporaryCodeDateTime ;
      private string[] T000V2_A217TemporaryCodeEmail ;
      private bool[] T000V2_n217TemporaryCodeEmail ;
      private bool[] T000V2_A218TemporaryCodeUsed ;
      private bool[] T000V2_n218TemporaryCodeUsed ;
      private int[] T000V9_A214TemporaryCodeId ;
      private int[] T000V12_A214TemporaryCodeId ;
   }

   public class temporarycode__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT000V2;
          prmT000V2 = new Object[] {
          new ParDef("TemporaryCodeId",GXType.Int32,9,0)
          };
          Object[] prmT000V3;
          prmT000V3 = new Object[] {
          new ParDef("TemporaryCodeId",GXType.Int32,9,0)
          };
          Object[] prmT000V4;
          prmT000V4 = new Object[] {
          new ParDef("TemporaryCodeId",GXType.Int32,9,0)
          };
          Object[] prmT000V5;
          prmT000V5 = new Object[] {
          new ParDef("TemporaryCodeId",GXType.Int32,9,0)
          };
          Object[] prmT000V6;
          prmT000V6 = new Object[] {
          new ParDef("TemporaryCodeId",GXType.Int32,9,0)
          };
          Object[] prmT000V7;
          prmT000V7 = new Object[] {
          new ParDef("TemporaryCodeId",GXType.Int32,9,0)
          };
          Object[] prmT000V8;
          prmT000V8 = new Object[] {
          new ParDef("TemporaryCodeContent",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("TemporaryCodeDateTime",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("TemporaryCodeEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("TemporaryCodeUsed",GXType.Boolean,4,0){Nullable=true}
          };
          Object[] prmT000V9;
          prmT000V9 = new Object[] {
          };
          Object[] prmT000V10;
          prmT000V10 = new Object[] {
          new ParDef("TemporaryCodeContent",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("TemporaryCodeDateTime",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("TemporaryCodeEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("TemporaryCodeUsed",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("TemporaryCodeId",GXType.Int32,9,0)
          };
          Object[] prmT000V11;
          prmT000V11 = new Object[] {
          new ParDef("TemporaryCodeId",GXType.Int32,9,0)
          };
          Object[] prmT000V12;
          prmT000V12 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T000V2", "SELECT TemporaryCodeId, TemporaryCodeContent, TemporaryCodeDateTime, TemporaryCodeEmail, TemporaryCodeUsed FROM TemporaryCode WHERE TemporaryCodeId = :TemporaryCodeId  FOR UPDATE OF TemporaryCode NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000V2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000V3", "SELECT TemporaryCodeId, TemporaryCodeContent, TemporaryCodeDateTime, TemporaryCodeEmail, TemporaryCodeUsed FROM TemporaryCode WHERE TemporaryCodeId = :TemporaryCodeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000V4", "SELECT TM1.TemporaryCodeId, TM1.TemporaryCodeContent, TM1.TemporaryCodeDateTime, TM1.TemporaryCodeEmail, TM1.TemporaryCodeUsed FROM TemporaryCode TM1 WHERE TM1.TemporaryCodeId = :TemporaryCodeId ORDER BY TM1.TemporaryCodeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000V5", "SELECT TemporaryCodeId FROM TemporaryCode WHERE TemporaryCodeId = :TemporaryCodeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000V6", "SELECT TemporaryCodeId FROM TemporaryCode WHERE ( TemporaryCodeId > :TemporaryCodeId) ORDER BY TemporaryCodeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000V7", "SELECT TemporaryCodeId FROM TemporaryCode WHERE ( TemporaryCodeId < :TemporaryCodeId) ORDER BY TemporaryCodeId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000V8", "SAVEPOINT gxupdate;INSERT INTO TemporaryCode(TemporaryCodeContent, TemporaryCodeDateTime, TemporaryCodeEmail, TemporaryCodeUsed) VALUES(:TemporaryCodeContent, :TemporaryCodeDateTime, :TemporaryCodeEmail, :TemporaryCodeUsed);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000V8)
             ,new CursorDef("T000V9", "SELECT currval('TemporaryCodeId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000V10", "SAVEPOINT gxupdate;UPDATE TemporaryCode SET TemporaryCodeContent=:TemporaryCodeContent, TemporaryCodeDateTime=:TemporaryCodeDateTime, TemporaryCodeEmail=:TemporaryCodeEmail, TemporaryCodeUsed=:TemporaryCodeUsed  WHERE TemporaryCodeId = :TemporaryCodeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000V10)
             ,new CursorDef("T000V11", "SAVEPOINT gxupdate;DELETE FROM TemporaryCode  WHERE TemporaryCodeId = :TemporaryCodeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000V11)
             ,new CursorDef("T000V12", "SELECT TemporaryCodeId FROM TemporaryCode ORDER BY TemporaryCodeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V12,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
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
