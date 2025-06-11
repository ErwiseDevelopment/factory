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
   public class secusertoken : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A133SecUserId = (short)(Math.Round(NumberUtil.Val( GetPar( "SecUserId"), "."), 18, MidpointRounding.ToEven));
            n133SecUserId = false;
            AssignAttri("", false, "A133SecUserId", ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A133SecUserId) ;
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
         Form.Meta.addItem("description", "Sec User Token", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSecUserTokenID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public secusertoken( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secusertoken( IGxContext context )
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
         chkSecUserTokenUsed = new GXCheckbox();
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
         A167SecUserTokenUsed = StringUtil.StrToBool( StringUtil.BoolToStr( A167SecUserTokenUsed));
         n167SecUserTokenUsed = false;
         AssignAttri("", false, "A167SecUserTokenUsed", A167SecUserTokenUsed);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Sec User Token", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_SecUserToken.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SecUserToken.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_SecUserToken.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_SecUserToken.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SecUserToken.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_SecUserToken.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSecUserTokenID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecUserTokenID_Internalname, "Token ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecUserTokenID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A164SecUserTokenID), 4, 0, ",", "")), StringUtil.LTrim( ((edtSecUserTokenID_Enabled!=0) ? context.localUtil.Format( (decimal)(A164SecUserTokenID), "ZZZ9") : context.localUtil.Format( (decimal)(A164SecUserTokenID), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecUserTokenID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSecUserTokenID_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SecUserToken.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSecUserTokenKey_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecUserTokenKey_Internalname, "Chave", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtSecUserTokenKey_Internalname, A165SecUserTokenKey, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", 0, 1, edtSecUserTokenKey_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_SecUserToken.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSecUserTokenDateTime_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecUserTokenDateTime_Internalname, "Expira", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtSecUserTokenDateTime_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtSecUserTokenDateTime_Internalname, context.localUtil.TToC( A166SecUserTokenDateTime, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A166SecUserTokenDateTime, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecUserTokenDateTime_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSecUserTokenDateTime_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SecUserToken.htm");
         GxWebStd.gx_bitmap( context, edtSecUserTokenDateTime_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtSecUserTokenDateTime_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_SecUserToken.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSecUserId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecUserId_Internalname, "Usuário", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecUserId_Internalname, ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ",", ""))), ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( ((edtSecUserId_Enabled!=0) ? context.localUtil.Format( (decimal)(A133SecUserId), "ZZZ9") : context.localUtil.Format( (decimal)(A133SecUserId), "ZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecUserId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSecUserId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_SecUserToken.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkSecUserTokenUsed_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkSecUserTokenUsed_Internalname, "Usado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkSecUserTokenUsed_Internalname, StringUtil.BoolToStr( A167SecUserTokenUsed), "", "Usado", 1, chkSecUserTokenUsed.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(54, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,54);\"");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_SecUserToken.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_SecUserToken.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_SecUserToken.htm");
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
            Z164SecUserTokenID = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z164SecUserTokenID"), ",", "."), 18, MidpointRounding.ToEven));
            Z166SecUserTokenDateTime = context.localUtil.CToT( cgiGet( "Z166SecUserTokenDateTime"), 0);
            n166SecUserTokenDateTime = ((DateTime.MinValue==A166SecUserTokenDateTime) ? true : false);
            Z167SecUserTokenUsed = StringUtil.StrToBool( cgiGet( "Z167SecUserTokenUsed"));
            n167SecUserTokenUsed = ((false==A167SecUserTokenUsed) ? true : false);
            Z133SecUserId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z133SecUserId"), ",", "."), 18, MidpointRounding.ToEven));
            n133SecUserId = ((0==A133SecUserId) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtSecUserTokenID_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSecUserTokenID_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SECUSERTOKENID");
               AnyError = 1;
               GX_FocusControl = edtSecUserTokenID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A164SecUserTokenID = 0;
               AssignAttri("", false, "A164SecUserTokenID", StringUtil.LTrimStr( (decimal)(A164SecUserTokenID), 4, 0));
            }
            else
            {
               A164SecUserTokenID = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSecUserTokenID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A164SecUserTokenID", StringUtil.LTrimStr( (decimal)(A164SecUserTokenID), 4, 0));
            }
            A165SecUserTokenKey = cgiGet( edtSecUserTokenKey_Internalname);
            n165SecUserTokenKey = false;
            AssignAttri("", false, "A165SecUserTokenKey", A165SecUserTokenKey);
            n165SecUserTokenKey = (String.IsNullOrEmpty(StringUtil.RTrim( A165SecUserTokenKey)) ? true : false);
            if ( context.localUtil.VCDateTime( cgiGet( edtSecUserTokenDateTime_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Expira"}), 1, "SECUSERTOKENDATETIME");
               AnyError = 1;
               GX_FocusControl = edtSecUserTokenDateTime_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A166SecUserTokenDateTime = (DateTime)(DateTime.MinValue);
               n166SecUserTokenDateTime = false;
               AssignAttri("", false, "A166SecUserTokenDateTime", context.localUtil.TToC( A166SecUserTokenDateTime, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A166SecUserTokenDateTime = context.localUtil.CToT( cgiGet( edtSecUserTokenDateTime_Internalname));
               n166SecUserTokenDateTime = false;
               AssignAttri("", false, "A166SecUserTokenDateTime", context.localUtil.TToC( A166SecUserTokenDateTime, 8, 5, 0, 3, "/", ":", " "));
            }
            n166SecUserTokenDateTime = ((DateTime.MinValue==A166SecUserTokenDateTime) ? true : false);
            n133SecUserId = ((StringUtil.StrCmp(cgiGet( edtSecUserId_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtSecUserId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSecUserId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SECUSERID");
               AnyError = 1;
               GX_FocusControl = edtSecUserId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A133SecUserId = 0;
               n133SecUserId = false;
               AssignAttri("", false, "A133SecUserId", (n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
            }
            else
            {
               A133SecUserId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSecUserId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A133SecUserId", (n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
            }
            A167SecUserTokenUsed = StringUtil.StrToBool( cgiGet( chkSecUserTokenUsed_Internalname));
            n167SecUserTokenUsed = false;
            AssignAttri("", false, "A167SecUserTokenUsed", A167SecUserTokenUsed);
            n167SecUserTokenUsed = ((false==A167SecUserTokenUsed) ? true : false);
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
               A164SecUserTokenID = (short)(Math.Round(NumberUtil.Val( GetPar( "SecUserTokenID"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A164SecUserTokenID", StringUtil.LTrimStr( (decimal)(A164SecUserTokenID), 4, 0));
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
               InitAll0N27( ) ;
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
         DisableAttributes0N27( ) ;
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

      protected void ResetCaption0N0( )
      {
      }

      protected void ZM0N27( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z166SecUserTokenDateTime = T000N3_A166SecUserTokenDateTime[0];
               Z167SecUserTokenUsed = T000N3_A167SecUserTokenUsed[0];
               Z133SecUserId = T000N3_A133SecUserId[0];
            }
            else
            {
               Z166SecUserTokenDateTime = A166SecUserTokenDateTime;
               Z167SecUserTokenUsed = A167SecUserTokenUsed;
               Z133SecUserId = A133SecUserId;
            }
         }
         if ( GX_JID == -2 )
         {
            Z164SecUserTokenID = A164SecUserTokenID;
            Z165SecUserTokenKey = A165SecUserTokenKey;
            Z166SecUserTokenDateTime = A166SecUserTokenDateTime;
            Z167SecUserTokenUsed = A167SecUserTokenUsed;
            Z133SecUserId = A133SecUserId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A167SecUserTokenUsed) && ( Gx_BScreen == 0 ) )
         {
            A167SecUserTokenUsed = false;
            n167SecUserTokenUsed = false;
            AssignAttri("", false, "A167SecUserTokenUsed", A167SecUserTokenUsed);
         }
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

      protected void Load0N27( )
      {
         /* Using cursor T000N5 */
         pr_default.execute(3, new Object[] {A164SecUserTokenID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound27 = 1;
            A165SecUserTokenKey = T000N5_A165SecUserTokenKey[0];
            n165SecUserTokenKey = T000N5_n165SecUserTokenKey[0];
            AssignAttri("", false, "A165SecUserTokenKey", A165SecUserTokenKey);
            A166SecUserTokenDateTime = T000N5_A166SecUserTokenDateTime[0];
            n166SecUserTokenDateTime = T000N5_n166SecUserTokenDateTime[0];
            AssignAttri("", false, "A166SecUserTokenDateTime", context.localUtil.TToC( A166SecUserTokenDateTime, 8, 5, 0, 3, "/", ":", " "));
            A167SecUserTokenUsed = T000N5_A167SecUserTokenUsed[0];
            n167SecUserTokenUsed = T000N5_n167SecUserTokenUsed[0];
            AssignAttri("", false, "A167SecUserTokenUsed", A167SecUserTokenUsed);
            A133SecUserId = T000N5_A133SecUserId[0];
            n133SecUserId = T000N5_n133SecUserId[0];
            AssignAttri("", false, "A133SecUserId", ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
            ZM0N27( -2) ;
         }
         pr_default.close(3);
         OnLoadActions0N27( ) ;
      }

      protected void OnLoadActions0N27( )
      {
      }

      protected void CheckExtendedTable0N27( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T000N4 */
         pr_default.execute(2, new Object[] {n133SecUserId, A133SecUserId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A133SecUserId) ) )
            {
               GX_msglist.addItem("Não existe 'User'.", "ForeignKeyNotFound", 1, "SECUSERID");
               AnyError = 1;
               GX_FocusControl = edtSecUserId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0N27( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( short A133SecUserId )
      {
         /* Using cursor T000N6 */
         pr_default.execute(4, new Object[] {n133SecUserId, A133SecUserId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A133SecUserId) ) )
            {
               GX_msglist.addItem("Não existe 'User'.", "ForeignKeyNotFound", 1, "SECUSERID");
               AnyError = 1;
               GX_FocusControl = edtSecUserId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey0N27( )
      {
         /* Using cursor T000N7 */
         pr_default.execute(5, new Object[] {A164SecUserTokenID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound27 = 1;
         }
         else
         {
            RcdFound27 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000N3 */
         pr_default.execute(1, new Object[] {A164SecUserTokenID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0N27( 2) ;
            RcdFound27 = 1;
            A164SecUserTokenID = T000N3_A164SecUserTokenID[0];
            AssignAttri("", false, "A164SecUserTokenID", StringUtil.LTrimStr( (decimal)(A164SecUserTokenID), 4, 0));
            A165SecUserTokenKey = T000N3_A165SecUserTokenKey[0];
            n165SecUserTokenKey = T000N3_n165SecUserTokenKey[0];
            AssignAttri("", false, "A165SecUserTokenKey", A165SecUserTokenKey);
            A166SecUserTokenDateTime = T000N3_A166SecUserTokenDateTime[0];
            n166SecUserTokenDateTime = T000N3_n166SecUserTokenDateTime[0];
            AssignAttri("", false, "A166SecUserTokenDateTime", context.localUtil.TToC( A166SecUserTokenDateTime, 8, 5, 0, 3, "/", ":", " "));
            A167SecUserTokenUsed = T000N3_A167SecUserTokenUsed[0];
            n167SecUserTokenUsed = T000N3_n167SecUserTokenUsed[0];
            AssignAttri("", false, "A167SecUserTokenUsed", A167SecUserTokenUsed);
            A133SecUserId = T000N3_A133SecUserId[0];
            n133SecUserId = T000N3_n133SecUserId[0];
            AssignAttri("", false, "A133SecUserId", ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
            Z164SecUserTokenID = A164SecUserTokenID;
            sMode27 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0N27( ) ;
            if ( AnyError == 1 )
            {
               RcdFound27 = 0;
               InitializeNonKey0N27( ) ;
            }
            Gx_mode = sMode27;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound27 = 0;
            InitializeNonKey0N27( ) ;
            sMode27 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode27;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0N27( ) ;
         if ( RcdFound27 == 0 )
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
         RcdFound27 = 0;
         /* Using cursor T000N8 */
         pr_default.execute(6, new Object[] {A164SecUserTokenID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000N8_A164SecUserTokenID[0] < A164SecUserTokenID ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000N8_A164SecUserTokenID[0] > A164SecUserTokenID ) ) )
            {
               A164SecUserTokenID = T000N8_A164SecUserTokenID[0];
               AssignAttri("", false, "A164SecUserTokenID", StringUtil.LTrimStr( (decimal)(A164SecUserTokenID), 4, 0));
               RcdFound27 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound27 = 0;
         /* Using cursor T000N9 */
         pr_default.execute(7, new Object[] {A164SecUserTokenID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000N9_A164SecUserTokenID[0] > A164SecUserTokenID ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000N9_A164SecUserTokenID[0] < A164SecUserTokenID ) ) )
            {
               A164SecUserTokenID = T000N9_A164SecUserTokenID[0];
               AssignAttri("", false, "A164SecUserTokenID", StringUtil.LTrimStr( (decimal)(A164SecUserTokenID), 4, 0));
               RcdFound27 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0N27( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSecUserTokenID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0N27( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound27 == 1 )
            {
               if ( A164SecUserTokenID != Z164SecUserTokenID )
               {
                  A164SecUserTokenID = Z164SecUserTokenID;
                  AssignAttri("", false, "A164SecUserTokenID", StringUtil.LTrimStr( (decimal)(A164SecUserTokenID), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SECUSERTOKENID");
                  AnyError = 1;
                  GX_FocusControl = edtSecUserTokenID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSecUserTokenID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0N27( ) ;
                  GX_FocusControl = edtSecUserTokenID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A164SecUserTokenID != Z164SecUserTokenID )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtSecUserTokenID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0N27( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SECUSERTOKENID");
                     AnyError = 1;
                     GX_FocusControl = edtSecUserTokenID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtSecUserTokenID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0N27( ) ;
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
         if ( A164SecUserTokenID != Z164SecUserTokenID )
         {
            A164SecUserTokenID = Z164SecUserTokenID;
            AssignAttri("", false, "A164SecUserTokenID", StringUtil.LTrimStr( (decimal)(A164SecUserTokenID), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SECUSERTOKENID");
            AnyError = 1;
            GX_FocusControl = edtSecUserTokenID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSecUserTokenID_Internalname;
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
         if ( RcdFound27 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "SECUSERTOKENID");
            AnyError = 1;
            GX_FocusControl = edtSecUserTokenID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtSecUserTokenKey_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0N27( ) ;
         if ( RcdFound27 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSecUserTokenKey_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0N27( ) ;
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
         if ( RcdFound27 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSecUserTokenKey_Internalname;
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
         if ( RcdFound27 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSecUserTokenKey_Internalname;
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
         ScanStart0N27( ) ;
         if ( RcdFound27 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound27 != 0 )
            {
               ScanNext0N27( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSecUserTokenKey_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0N27( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0N27( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000N2 */
            pr_default.execute(0, new Object[] {A164SecUserTokenID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecUserToken"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z166SecUserTokenDateTime != T000N2_A166SecUserTokenDateTime[0] ) || ( Z167SecUserTokenUsed != T000N2_A167SecUserTokenUsed[0] ) || ( Z133SecUserId != T000N2_A133SecUserId[0] ) )
            {
               if ( Z166SecUserTokenDateTime != T000N2_A166SecUserTokenDateTime[0] )
               {
                  GXUtil.WriteLog("secusertoken:[seudo value changed for attri]"+"SecUserTokenDateTime");
                  GXUtil.WriteLogRaw("Old: ",Z166SecUserTokenDateTime);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A166SecUserTokenDateTime[0]);
               }
               if ( Z167SecUserTokenUsed != T000N2_A167SecUserTokenUsed[0] )
               {
                  GXUtil.WriteLog("secusertoken:[seudo value changed for attri]"+"SecUserTokenUsed");
                  GXUtil.WriteLogRaw("Old: ",Z167SecUserTokenUsed);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A167SecUserTokenUsed[0]);
               }
               if ( Z133SecUserId != T000N2_A133SecUserId[0] )
               {
                  GXUtil.WriteLog("secusertoken:[seudo value changed for attri]"+"SecUserId");
                  GXUtil.WriteLogRaw("Old: ",Z133SecUserId);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A133SecUserId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SecUserToken"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0N27( )
      {
         BeforeValidate0N27( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N27( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0N27( 0) ;
            CheckOptimisticConcurrency0N27( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0N27( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0N27( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000N10 */
                     pr_default.execute(8, new Object[] {n165SecUserTokenKey, A165SecUserTokenKey, n166SecUserTokenDateTime, A166SecUserTokenDateTime, n167SecUserTokenUsed, A167SecUserTokenUsed, n133SecUserId, A133SecUserId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000N11 */
                     pr_default.execute(9);
                     A164SecUserTokenID = T000N11_A164SecUserTokenID[0];
                     AssignAttri("", false, "A164SecUserTokenID", StringUtil.LTrimStr( (decimal)(A164SecUserTokenID), 4, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("SecUserToken");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0N0( ) ;
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
               Load0N27( ) ;
            }
            EndLevel0N27( ) ;
         }
         CloseExtendedTableCursors0N27( ) ;
      }

      protected void Update0N27( )
      {
         BeforeValidate0N27( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N27( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0N27( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0N27( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0N27( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000N12 */
                     pr_default.execute(10, new Object[] {n165SecUserTokenKey, A165SecUserTokenKey, n166SecUserTokenDateTime, A166SecUserTokenDateTime, n167SecUserTokenUsed, A167SecUserTokenUsed, n133SecUserId, A133SecUserId, A164SecUserTokenID});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("SecUserToken");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecUserToken"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0N27( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0N0( ) ;
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
            EndLevel0N27( ) ;
         }
         CloseExtendedTableCursors0N27( ) ;
      }

      protected void DeferredUpdate0N27( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0N27( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0N27( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0N27( ) ;
            AfterConfirm0N27( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0N27( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000N13 */
                  pr_default.execute(11, new Object[] {A164SecUserTokenID});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("SecUserToken");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound27 == 0 )
                        {
                           InitAll0N27( ) ;
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
                        ResetCaption0N0( ) ;
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
         sMode27 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0N27( ) ;
         Gx_mode = sMode27;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0N27( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0N27( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0N27( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("secusertoken",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0N0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("secusertoken",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0N27( )
      {
         /* Using cursor T000N14 */
         pr_default.execute(12);
         RcdFound27 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound27 = 1;
            A164SecUserTokenID = T000N14_A164SecUserTokenID[0];
            AssignAttri("", false, "A164SecUserTokenID", StringUtil.LTrimStr( (decimal)(A164SecUserTokenID), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0N27( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound27 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound27 = 1;
            A164SecUserTokenID = T000N14_A164SecUserTokenID[0];
            AssignAttri("", false, "A164SecUserTokenID", StringUtil.LTrimStr( (decimal)(A164SecUserTokenID), 4, 0));
         }
      }

      protected void ScanEnd0N27( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0N27( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0N27( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0N27( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0N27( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0N27( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0N27( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0N27( )
      {
         edtSecUserTokenID_Enabled = 0;
         AssignProp("", false, edtSecUserTokenID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserTokenID_Enabled), 5, 0), true);
         edtSecUserTokenKey_Enabled = 0;
         AssignProp("", false, edtSecUserTokenKey_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserTokenKey_Enabled), 5, 0), true);
         edtSecUserTokenDateTime_Enabled = 0;
         AssignProp("", false, edtSecUserTokenDateTime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserTokenDateTime_Enabled), 5, 0), true);
         edtSecUserId_Enabled = 0;
         AssignProp("", false, edtSecUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserId_Enabled), 5, 0), true);
         chkSecUserTokenUsed.Enabled = 0;
         AssignProp("", false, chkSecUserTokenUsed_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkSecUserTokenUsed.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0N27( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0N0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("secusertoken") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z164SecUserTokenID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z164SecUserTokenID), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z166SecUserTokenDateTime", context.localUtil.TToC( Z166SecUserTokenDateTime, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_boolean_hidden_field( context, "Z167SecUserTokenUsed", Z167SecUserTokenUsed);
         GxWebStd.gx_hidden_field( context, "Z133SecUserId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z133SecUserId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
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
         return formatLink("secusertoken")  ;
      }

      public override string GetPgmname( )
      {
         return "SecUserToken" ;
      }

      public override string GetPgmdesc( )
      {
         return "Sec User Token" ;
      }

      protected void InitializeNonKey0N27( )
      {
         A165SecUserTokenKey = "";
         n165SecUserTokenKey = false;
         AssignAttri("", false, "A165SecUserTokenKey", A165SecUserTokenKey);
         n165SecUserTokenKey = (String.IsNullOrEmpty(StringUtil.RTrim( A165SecUserTokenKey)) ? true : false);
         A166SecUserTokenDateTime = (DateTime)(DateTime.MinValue);
         n166SecUserTokenDateTime = false;
         AssignAttri("", false, "A166SecUserTokenDateTime", context.localUtil.TToC( A166SecUserTokenDateTime, 8, 5, 0, 3, "/", ":", " "));
         n166SecUserTokenDateTime = ((DateTime.MinValue==A166SecUserTokenDateTime) ? true : false);
         A133SecUserId = 0;
         n133SecUserId = false;
         AssignAttri("", false, "A133SecUserId", ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
         n133SecUserId = ((0==A133SecUserId) ? true : false);
         A167SecUserTokenUsed = false;
         n167SecUserTokenUsed = false;
         AssignAttri("", false, "A167SecUserTokenUsed", A167SecUserTokenUsed);
         Z166SecUserTokenDateTime = (DateTime)(DateTime.MinValue);
         Z167SecUserTokenUsed = false;
         Z133SecUserId = 0;
      }

      protected void InitAll0N27( )
      {
         A164SecUserTokenID = 0;
         AssignAttri("", false, "A164SecUserTokenID", StringUtil.LTrimStr( (decimal)(A164SecUserTokenID), 4, 0));
         InitializeNonKey0N27( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A167SecUserTokenUsed = i167SecUserTokenUsed;
         n167SecUserTokenUsed = false;
         AssignAttri("", false, "A167SecUserTokenUsed", A167SecUserTokenUsed);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2025610191329", true, true);
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
         context.AddJavascriptSource("secusertoken.js", "?2025610191329", false, true);
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
         edtSecUserTokenID_Internalname = "SECUSERTOKENID";
         edtSecUserTokenKey_Internalname = "SECUSERTOKENKEY";
         edtSecUserTokenDateTime_Internalname = "SECUSERTOKENDATETIME";
         edtSecUserId_Internalname = "SECUSERID";
         chkSecUserTokenUsed_Internalname = "SECUSERTOKENUSED";
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
         Form.Caption = "Sec User Token";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chkSecUserTokenUsed.Enabled = 1;
         edtSecUserId_Jsonclick = "";
         edtSecUserId_Enabled = 1;
         edtSecUserTokenDateTime_Jsonclick = "";
         edtSecUserTokenDateTime_Enabled = 1;
         edtSecUserTokenKey_Enabled = 1;
         edtSecUserTokenID_Jsonclick = "";
         edtSecUserTokenID_Enabled = 1;
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
         chkSecUserTokenUsed.Name = "SECUSERTOKENUSED";
         chkSecUserTokenUsed.WebTags = "";
         chkSecUserTokenUsed.Caption = "Usado";
         AssignProp("", false, chkSecUserTokenUsed_Internalname, "TitleCaption", chkSecUserTokenUsed.Caption, true);
         chkSecUserTokenUsed.CheckedValue = "false";
         if ( IsIns( ) && (false==A167SecUserTokenUsed) )
         {
            A167SecUserTokenUsed = false;
            n167SecUserTokenUsed = false;
            AssignAttri("", false, "A167SecUserTokenUsed", A167SecUserTokenUsed);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtSecUserTokenKey_Internalname;
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

      public void Valid_Secusertokenid( )
      {
         n167SecUserTokenUsed = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A167SecUserTokenUsed = StringUtil.StrToBool( StringUtil.BoolToStr( A167SecUserTokenUsed));
         n167SecUserTokenUsed = false;
         /*  Sending validation outputs */
         AssignAttri("", false, "A165SecUserTokenKey", A165SecUserTokenKey);
         AssignAttri("", false, "A166SecUserTokenDateTime", context.localUtil.TToC( A166SecUserTokenDateTime, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A133SecUserId", ((0==A133SecUserId)&&IsIns( )||n133SecUserId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ".", ""))));
         AssignAttri("", false, "A167SecUserTokenUsed", A167SecUserTokenUsed);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z164SecUserTokenID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z164SecUserTokenID), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z165SecUserTokenKey", Z165SecUserTokenKey);
         GxWebStd.gx_hidden_field( context, "Z166SecUserTokenDateTime", context.localUtil.TToC( Z166SecUserTokenDateTime, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z133SecUserId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z133SecUserId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z167SecUserTokenUsed", StringUtil.BoolToStr( Z167SecUserTokenUsed));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Secuserid( )
      {
         /* Using cursor T000N15 */
         pr_default.execute(13, new Object[] {n133SecUserId, A133SecUserId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            if ( ! ( (0==A133SecUserId) ) )
            {
               GX_msglist.addItem("Não existe 'User'.", "ForeignKeyNotFound", 1, "SECUSERID");
               AnyError = 1;
               GX_FocusControl = edtSecUserId_Internalname;
            }
         }
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"A167SecUserTokenUsed","fld":"SECUSERTOKENUSED","type":"boolean"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A167SecUserTokenUsed","fld":"SECUSERTOKENUSED","type":"boolean"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A167SecUserTokenUsed","fld":"SECUSERTOKENUSED","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A167SecUserTokenUsed","fld":"SECUSERTOKENUSED","type":"boolean"}]}""");
         setEventMetadata("VALID_SECUSERTOKENID","""{"handler":"Valid_Secusertokenid","iparms":[{"av":"A164SecUserTokenID","fld":"SECUSERTOKENID","pic":"ZZZ9","type":"int"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"A167SecUserTokenUsed","fld":"SECUSERTOKENUSED","type":"boolean"}]""");
         setEventMetadata("VALID_SECUSERTOKENID",""","oparms":[{"av":"A165SecUserTokenKey","fld":"SECUSERTOKENKEY","type":"vchar"},{"av":"A166SecUserTokenDateTime","fld":"SECUSERTOKENDATETIME","pic":"99/99/99 99:99","type":"dtime"},{"av":"A133SecUserId","fld":"SECUSERID","pic":"ZZZ9","nullAv":"n133SecUserId","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"Z164SecUserTokenID","type":"int"},{"av":"Z165SecUserTokenKey","type":"vchar"},{"av":"Z166SecUserTokenDateTime","type":"dtime"},{"av":"Z133SecUserId","type":"int"},{"av":"Z167SecUserTokenUsed","type":"boolean"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"},{"av":"A167SecUserTokenUsed","fld":"SECUSERTOKENUSED","type":"boolean"}]}""");
         setEventMetadata("VALID_SECUSERID","""{"handler":"Valid_Secuserid","iparms":[{"av":"A133SecUserId","fld":"SECUSERID","pic":"ZZZ9","nullAv":"n133SecUserId","type":"int"},{"av":"A167SecUserTokenUsed","fld":"SECUSERTOKENUSED","type":"boolean"}]""");
         setEventMetadata("VALID_SECUSERID",""","oparms":[{"av":"A167SecUserTokenUsed","fld":"SECUSERTOKENUSED","type":"boolean"}]}""");
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
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z166SecUserTokenDateTime = (DateTime)(DateTime.MinValue);
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
         A165SecUserTokenKey = "";
         A166SecUserTokenDateTime = (DateTime)(DateTime.MinValue);
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
         Z165SecUserTokenKey = "";
         T000N5_A164SecUserTokenID = new short[1] ;
         T000N5_A165SecUserTokenKey = new string[] {""} ;
         T000N5_n165SecUserTokenKey = new bool[] {false} ;
         T000N5_A166SecUserTokenDateTime = new DateTime[] {DateTime.MinValue} ;
         T000N5_n166SecUserTokenDateTime = new bool[] {false} ;
         T000N5_A167SecUserTokenUsed = new bool[] {false} ;
         T000N5_n167SecUserTokenUsed = new bool[] {false} ;
         T000N5_A133SecUserId = new short[1] ;
         T000N5_n133SecUserId = new bool[] {false} ;
         T000N4_A133SecUserId = new short[1] ;
         T000N4_n133SecUserId = new bool[] {false} ;
         T000N6_A133SecUserId = new short[1] ;
         T000N6_n133SecUserId = new bool[] {false} ;
         T000N7_A164SecUserTokenID = new short[1] ;
         T000N3_A164SecUserTokenID = new short[1] ;
         T000N3_A165SecUserTokenKey = new string[] {""} ;
         T000N3_n165SecUserTokenKey = new bool[] {false} ;
         T000N3_A166SecUserTokenDateTime = new DateTime[] {DateTime.MinValue} ;
         T000N3_n166SecUserTokenDateTime = new bool[] {false} ;
         T000N3_A167SecUserTokenUsed = new bool[] {false} ;
         T000N3_n167SecUserTokenUsed = new bool[] {false} ;
         T000N3_A133SecUserId = new short[1] ;
         T000N3_n133SecUserId = new bool[] {false} ;
         sMode27 = "";
         T000N8_A164SecUserTokenID = new short[1] ;
         T000N9_A164SecUserTokenID = new short[1] ;
         T000N2_A164SecUserTokenID = new short[1] ;
         T000N2_A165SecUserTokenKey = new string[] {""} ;
         T000N2_n165SecUserTokenKey = new bool[] {false} ;
         T000N2_A166SecUserTokenDateTime = new DateTime[] {DateTime.MinValue} ;
         T000N2_n166SecUserTokenDateTime = new bool[] {false} ;
         T000N2_A167SecUserTokenUsed = new bool[] {false} ;
         T000N2_n167SecUserTokenUsed = new bool[] {false} ;
         T000N2_A133SecUserId = new short[1] ;
         T000N2_n133SecUserId = new bool[] {false} ;
         T000N11_A164SecUserTokenID = new short[1] ;
         T000N14_A164SecUserTokenID = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ165SecUserTokenKey = "";
         ZZ166SecUserTokenDateTime = (DateTime)(DateTime.MinValue);
         T000N15_A133SecUserId = new short[1] ;
         T000N15_n133SecUserId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.secusertoken__default(),
            new Object[][] {
                new Object[] {
               T000N2_A164SecUserTokenID, T000N2_A165SecUserTokenKey, T000N2_n165SecUserTokenKey, T000N2_A166SecUserTokenDateTime, T000N2_n166SecUserTokenDateTime, T000N2_A167SecUserTokenUsed, T000N2_n167SecUserTokenUsed, T000N2_A133SecUserId, T000N2_n133SecUserId
               }
               , new Object[] {
               T000N3_A164SecUserTokenID, T000N3_A165SecUserTokenKey, T000N3_n165SecUserTokenKey, T000N3_A166SecUserTokenDateTime, T000N3_n166SecUserTokenDateTime, T000N3_A167SecUserTokenUsed, T000N3_n167SecUserTokenUsed, T000N3_A133SecUserId, T000N3_n133SecUserId
               }
               , new Object[] {
               T000N4_A133SecUserId
               }
               , new Object[] {
               T000N5_A164SecUserTokenID, T000N5_A165SecUserTokenKey, T000N5_n165SecUserTokenKey, T000N5_A166SecUserTokenDateTime, T000N5_n166SecUserTokenDateTime, T000N5_A167SecUserTokenUsed, T000N5_n167SecUserTokenUsed, T000N5_A133SecUserId, T000N5_n133SecUserId
               }
               , new Object[] {
               T000N6_A133SecUserId
               }
               , new Object[] {
               T000N7_A164SecUserTokenID
               }
               , new Object[] {
               T000N8_A164SecUserTokenID
               }
               , new Object[] {
               T000N9_A164SecUserTokenID
               }
               , new Object[] {
               }
               , new Object[] {
               T000N11_A164SecUserTokenID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000N14_A164SecUserTokenID
               }
               , new Object[] {
               T000N15_A133SecUserId
               }
            }
         );
         Z167SecUserTokenUsed = false;
         n167SecUserTokenUsed = false;
         A167SecUserTokenUsed = false;
         n167SecUserTokenUsed = false;
         i167SecUserTokenUsed = false;
         n167SecUserTokenUsed = false;
      }

      private short Z164SecUserTokenID ;
      private short Z133SecUserId ;
      private short GxWebError ;
      private short A133SecUserId ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A164SecUserTokenID ;
      private short Gx_BScreen ;
      private short RcdFound27 ;
      private short gxajaxcallmode ;
      private short ZZ164SecUserTokenID ;
      private short ZZ133SecUserId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtSecUserTokenID_Enabled ;
      private int edtSecUserTokenKey_Enabled ;
      private int edtSecUserTokenDateTime_Enabled ;
      private int edtSecUserId_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtSecUserTokenID_Internalname ;
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
      private string edtSecUserTokenID_Jsonclick ;
      private string edtSecUserTokenKey_Internalname ;
      private string edtSecUserTokenDateTime_Internalname ;
      private string edtSecUserTokenDateTime_Jsonclick ;
      private string edtSecUserId_Internalname ;
      private string edtSecUserId_Jsonclick ;
      private string chkSecUserTokenUsed_Internalname ;
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
      private string sMode27 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z166SecUserTokenDateTime ;
      private DateTime A166SecUserTokenDateTime ;
      private DateTime ZZ166SecUserTokenDateTime ;
      private bool Z167SecUserTokenUsed ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n133SecUserId ;
      private bool wbErr ;
      private bool A167SecUserTokenUsed ;
      private bool n167SecUserTokenUsed ;
      private bool n166SecUserTokenDateTime ;
      private bool n165SecUserTokenKey ;
      private bool i167SecUserTokenUsed ;
      private bool ZZ167SecUserTokenUsed ;
      private string A165SecUserTokenKey ;
      private string Z165SecUserTokenKey ;
      private string ZZ165SecUserTokenKey ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkSecUserTokenUsed ;
      private IDataStoreProvider pr_default ;
      private short[] T000N5_A164SecUserTokenID ;
      private string[] T000N5_A165SecUserTokenKey ;
      private bool[] T000N5_n165SecUserTokenKey ;
      private DateTime[] T000N5_A166SecUserTokenDateTime ;
      private bool[] T000N5_n166SecUserTokenDateTime ;
      private bool[] T000N5_A167SecUserTokenUsed ;
      private bool[] T000N5_n167SecUserTokenUsed ;
      private short[] T000N5_A133SecUserId ;
      private bool[] T000N5_n133SecUserId ;
      private short[] T000N4_A133SecUserId ;
      private bool[] T000N4_n133SecUserId ;
      private short[] T000N6_A133SecUserId ;
      private bool[] T000N6_n133SecUserId ;
      private short[] T000N7_A164SecUserTokenID ;
      private short[] T000N3_A164SecUserTokenID ;
      private string[] T000N3_A165SecUserTokenKey ;
      private bool[] T000N3_n165SecUserTokenKey ;
      private DateTime[] T000N3_A166SecUserTokenDateTime ;
      private bool[] T000N3_n166SecUserTokenDateTime ;
      private bool[] T000N3_A167SecUserTokenUsed ;
      private bool[] T000N3_n167SecUserTokenUsed ;
      private short[] T000N3_A133SecUserId ;
      private bool[] T000N3_n133SecUserId ;
      private short[] T000N8_A164SecUserTokenID ;
      private short[] T000N9_A164SecUserTokenID ;
      private short[] T000N2_A164SecUserTokenID ;
      private string[] T000N2_A165SecUserTokenKey ;
      private bool[] T000N2_n165SecUserTokenKey ;
      private DateTime[] T000N2_A166SecUserTokenDateTime ;
      private bool[] T000N2_n166SecUserTokenDateTime ;
      private bool[] T000N2_A167SecUserTokenUsed ;
      private bool[] T000N2_n167SecUserTokenUsed ;
      private short[] T000N2_A133SecUserId ;
      private bool[] T000N2_n133SecUserId ;
      private short[] T000N11_A164SecUserTokenID ;
      private short[] T000N14_A164SecUserTokenID ;
      private short[] T000N15_A133SecUserId ;
      private bool[] T000N15_n133SecUserId ;
   }

   public class secusertoken__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000N2;
          prmT000N2 = new Object[] {
          new ParDef("SecUserTokenID",GXType.Int16,4,0)
          };
          Object[] prmT000N3;
          prmT000N3 = new Object[] {
          new ParDef("SecUserTokenID",GXType.Int16,4,0)
          };
          Object[] prmT000N4;
          prmT000N4 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000N5;
          prmT000N5 = new Object[] {
          new ParDef("SecUserTokenID",GXType.Int16,4,0)
          };
          Object[] prmT000N6;
          prmT000N6 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000N7;
          prmT000N7 = new Object[] {
          new ParDef("SecUserTokenID",GXType.Int16,4,0)
          };
          Object[] prmT000N8;
          prmT000N8 = new Object[] {
          new ParDef("SecUserTokenID",GXType.Int16,4,0)
          };
          Object[] prmT000N9;
          prmT000N9 = new Object[] {
          new ParDef("SecUserTokenID",GXType.Int16,4,0)
          };
          Object[] prmT000N10;
          prmT000N10 = new Object[] {
          new ParDef("SecUserTokenKey",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("SecUserTokenDateTime",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("SecUserTokenUsed",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000N11;
          prmT000N11 = new Object[] {
          };
          Object[] prmT000N12;
          prmT000N12 = new Object[] {
          new ParDef("SecUserTokenKey",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("SecUserTokenDateTime",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("SecUserTokenUsed",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("SecUserTokenID",GXType.Int16,4,0)
          };
          Object[] prmT000N13;
          prmT000N13 = new Object[] {
          new ParDef("SecUserTokenID",GXType.Int16,4,0)
          };
          Object[] prmT000N14;
          prmT000N14 = new Object[] {
          };
          Object[] prmT000N15;
          prmT000N15 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T000N2", "SELECT SecUserTokenID, SecUserTokenKey, SecUserTokenDateTime, SecUserTokenUsed, SecUserId FROM SecUserToken WHERE SecUserTokenID = :SecUserTokenID  FOR UPDATE OF SecUserToken NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000N2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000N3", "SELECT SecUserTokenID, SecUserTokenKey, SecUserTokenDateTime, SecUserTokenUsed, SecUserId FROM SecUserToken WHERE SecUserTokenID = :SecUserTokenID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000N4", "SELECT SecUserId FROM SecUser WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000N5", "SELECT TM1.SecUserTokenID, TM1.SecUserTokenKey, TM1.SecUserTokenDateTime, TM1.SecUserTokenUsed, TM1.SecUserId FROM SecUserToken TM1 WHERE TM1.SecUserTokenID = :SecUserTokenID ORDER BY TM1.SecUserTokenID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000N6", "SELECT SecUserId FROM SecUser WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000N7", "SELECT SecUserTokenID FROM SecUserToken WHERE SecUserTokenID = :SecUserTokenID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000N8", "SELECT SecUserTokenID FROM SecUserToken WHERE ( SecUserTokenID > :SecUserTokenID) ORDER BY SecUserTokenID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N8,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000N9", "SELECT SecUserTokenID FROM SecUserToken WHERE ( SecUserTokenID < :SecUserTokenID) ORDER BY SecUserTokenID DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N9,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000N10", "SAVEPOINT gxupdate;INSERT INTO SecUserToken(SecUserTokenKey, SecUserTokenDateTime, SecUserTokenUsed, SecUserId) VALUES(:SecUserTokenKey, :SecUserTokenDateTime, :SecUserTokenUsed, :SecUserId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000N10)
             ,new CursorDef("T000N11", "SELECT currval('SecUserTokenID') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000N12", "SAVEPOINT gxupdate;UPDATE SecUserToken SET SecUserTokenKey=:SecUserTokenKey, SecUserTokenDateTime=:SecUserTokenDateTime, SecUserTokenUsed=:SecUserTokenUsed, SecUserId=:SecUserId  WHERE SecUserTokenID = :SecUserTokenID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000N12)
             ,new CursorDef("T000N13", "SAVEPOINT gxupdate;DELETE FROM SecUserToken  WHERE SecUserTokenID = :SecUserTokenID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000N13)
             ,new CursorDef("T000N14", "SELECT SecUserTokenID FROM SecUserToken ORDER BY SecUserTokenID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N14,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000N15", "SELECT SecUserId FROM SecUser WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N15,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
