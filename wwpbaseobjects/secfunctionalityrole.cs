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
namespace GeneXus.Programs.wwpbaseobjects {
   public class secfunctionalityrole : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_2") == 0 )
         {
            A128SecFunctionalityId = (long)(Math.Round(NumberUtil.Val( GetPar( "SecFunctionalityId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A128SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A128SecFunctionalityId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A128SecFunctionalityId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A131SecRoleId = (short)(Math.Round(NumberUtil.Val( GetPar( "SecRoleId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A131SecRoleId", StringUtil.LTrimStr( (decimal)(A131SecRoleId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A131SecRoleId) ;
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
         Form.Meta.addItem("description", "Functionality - Role", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSecFunctionalityId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public secfunctionalityrole( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secfunctionalityrole( IGxContext context )
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
         chkSecFunctionalityRoleAtivo = new GXCheckbox();
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
         A735SecFunctionalityRoleAtivo = StringUtil.StrToBool( StringUtil.BoolToStr( A735SecFunctionalityRoleAtivo));
         AssignAttri("", false, "A735SecFunctionalityRoleAtivo", A735SecFunctionalityRoleAtivo);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Functionality - Role", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/SecFunctionalityRole.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecFunctionalityRole.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecFunctionalityRole.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecFunctionalityRole.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecFunctionalityRole.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects/SecFunctionalityRole.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSecFunctionalityId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecFunctionalityId_Internalname, "Functionality Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecFunctionalityId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A128SecFunctionalityId), 10, 0, ",", "")), StringUtil.LTrim( ((edtSecFunctionalityId_Enabled!=0) ? context.localUtil.Format( (decimal)(A128SecFunctionalityId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A128SecFunctionalityId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecFunctionalityId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSecFunctionalityId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/SecFunctionalityRole.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSecFunctionalityDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecFunctionalityDescription_Internalname, "Functionality Description", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecFunctionalityDescription_Internalname, A135SecFunctionalityDescription, StringUtil.RTrim( context.localUtil.Format( A135SecFunctionalityDescription, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecFunctionalityDescription_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSecFunctionalityDescription_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/SecFunctionalityRole.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSecRoleId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecRoleId_Internalname, "Role Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecRoleId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A131SecRoleId), 4, 0, ",", "")), StringUtil.LTrim( ((edtSecRoleId_Enabled!=0) ? context.localUtil.Format( (decimal)(A131SecRoleId), "ZZZ9") : context.localUtil.Format( (decimal)(A131SecRoleId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecRoleId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSecRoleId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/SecFunctionalityRole.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkSecFunctionalityRoleAtivo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkSecFunctionalityRoleAtivo_Internalname, "Role Ativo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkSecFunctionalityRoleAtivo_Internalname, StringUtil.BoolToStr( A735SecFunctionalityRoleAtivo), "", "Role Ativo", 1, chkSecFunctionalityRoleAtivo.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(49, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,49);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecFunctionalityRole.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecFunctionalityRole.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecFunctionalityRole.htm");
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
            Z128SecFunctionalityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z128SecFunctionalityId"), ",", "."), 18, MidpointRounding.ToEven));
            Z131SecRoleId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z131SecRoleId"), ",", "."), 18, MidpointRounding.ToEven));
            Z735SecFunctionalityRoleAtivo = StringUtil.StrToBool( cgiGet( "Z735SecFunctionalityRoleAtivo"));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtSecFunctionalityId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSecFunctionalityId_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SECFUNCTIONALITYID");
               AnyError = 1;
               GX_FocusControl = edtSecFunctionalityId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A128SecFunctionalityId = 0;
               AssignAttri("", false, "A128SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A128SecFunctionalityId), 10, 0));
            }
            else
            {
               A128SecFunctionalityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtSecFunctionalityId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A128SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A128SecFunctionalityId), 10, 0));
            }
            A135SecFunctionalityDescription = cgiGet( edtSecFunctionalityDescription_Internalname);
            n135SecFunctionalityDescription = false;
            AssignAttri("", false, "A135SecFunctionalityDescription", A135SecFunctionalityDescription);
            if ( ( ( context.localUtil.CToN( cgiGet( edtSecRoleId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSecRoleId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SECROLEID");
               AnyError = 1;
               GX_FocusControl = edtSecRoleId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A131SecRoleId = 0;
               AssignAttri("", false, "A131SecRoleId", StringUtil.LTrimStr( (decimal)(A131SecRoleId), 4, 0));
            }
            else
            {
               A131SecRoleId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSecRoleId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A131SecRoleId", StringUtil.LTrimStr( (decimal)(A131SecRoleId), 4, 0));
            }
            A735SecFunctionalityRoleAtivo = StringUtil.StrToBool( cgiGet( chkSecFunctionalityRoleAtivo_Internalname));
            AssignAttri("", false, "A735SecFunctionalityRoleAtivo", A735SecFunctionalityRoleAtivo);
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
               A128SecFunctionalityId = (long)(Math.Round(NumberUtil.Val( GetPar( "SecFunctionalityId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A128SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A128SecFunctionalityId), 10, 0));
               A131SecRoleId = (short)(Math.Round(NumberUtil.Val( GetPar( "SecRoleId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A131SecRoleId", StringUtil.LTrimStr( (decimal)(A131SecRoleId), 4, 0));
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
               InitAll0F18( ) ;
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
         DisableAttributes0F18( ) ;
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

      protected void ResetCaption0F0( )
      {
      }

      protected void ZM0F18( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z735SecFunctionalityRoleAtivo = T000F3_A735SecFunctionalityRoleAtivo[0];
            }
            else
            {
               Z735SecFunctionalityRoleAtivo = A735SecFunctionalityRoleAtivo;
            }
         }
         if ( GX_JID == -1 )
         {
            Z735SecFunctionalityRoleAtivo = A735SecFunctionalityRoleAtivo;
            Z128SecFunctionalityId = A128SecFunctionalityId;
            Z131SecRoleId = A131SecRoleId;
            Z135SecFunctionalityDescription = A135SecFunctionalityDescription;
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

      protected void Load0F18( )
      {
         /* Using cursor T000F6 */
         pr_default.execute(4, new Object[] {A128SecFunctionalityId, A131SecRoleId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound18 = 1;
            A135SecFunctionalityDescription = T000F6_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = T000F6_n135SecFunctionalityDescription[0];
            AssignAttri("", false, "A135SecFunctionalityDescription", A135SecFunctionalityDescription);
            A735SecFunctionalityRoleAtivo = T000F6_A735SecFunctionalityRoleAtivo[0];
            AssignAttri("", false, "A735SecFunctionalityRoleAtivo", A735SecFunctionalityRoleAtivo);
            ZM0F18( -1) ;
         }
         pr_default.close(4);
         OnLoadActions0F18( ) ;
      }

      protected void OnLoadActions0F18( )
      {
      }

      protected void CheckExtendedTable0F18( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000F4 */
         pr_default.execute(2, new Object[] {A128SecFunctionalityId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Functionality'.", "ForeignKeyNotFound", 1, "SECFUNCTIONALITYID");
            AnyError = 1;
            GX_FocusControl = edtSecFunctionalityId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A135SecFunctionalityDescription = T000F4_A135SecFunctionalityDescription[0];
         n135SecFunctionalityDescription = T000F4_n135SecFunctionalityDescription[0];
         AssignAttri("", false, "A135SecFunctionalityDescription", A135SecFunctionalityDescription);
         pr_default.close(2);
         /* Using cursor T000F5 */
         pr_default.execute(3, new Object[] {A131SecRoleId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe 'Role'.", "ForeignKeyNotFound", 1, "SECROLEID");
            AnyError = 1;
            GX_FocusControl = edtSecRoleId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0F18( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( long A128SecFunctionalityId )
      {
         /* Using cursor T000F7 */
         pr_default.execute(5, new Object[] {A128SecFunctionalityId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("Não existe 'Functionality'.", "ForeignKeyNotFound", 1, "SECFUNCTIONALITYID");
            AnyError = 1;
            GX_FocusControl = edtSecFunctionalityId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A135SecFunctionalityDescription = T000F7_A135SecFunctionalityDescription[0];
         n135SecFunctionalityDescription = T000F7_n135SecFunctionalityDescription[0];
         AssignAttri("", false, "A135SecFunctionalityDescription", A135SecFunctionalityDescription);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A135SecFunctionalityDescription)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_3( short A131SecRoleId )
      {
         /* Using cursor T000F8 */
         pr_default.execute(6, new Object[] {A131SecRoleId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("Não existe 'Role'.", "ForeignKeyNotFound", 1, "SECROLEID");
            AnyError = 1;
            GX_FocusControl = edtSecRoleId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey0F18( )
      {
         /* Using cursor T000F9 */
         pr_default.execute(7, new Object[] {A128SecFunctionalityId, A131SecRoleId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound18 = 1;
         }
         else
         {
            RcdFound18 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000F3 */
         pr_default.execute(1, new Object[] {A128SecFunctionalityId, A131SecRoleId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0F18( 1) ;
            RcdFound18 = 1;
            A735SecFunctionalityRoleAtivo = T000F3_A735SecFunctionalityRoleAtivo[0];
            AssignAttri("", false, "A735SecFunctionalityRoleAtivo", A735SecFunctionalityRoleAtivo);
            A128SecFunctionalityId = T000F3_A128SecFunctionalityId[0];
            AssignAttri("", false, "A128SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A128SecFunctionalityId), 10, 0));
            A131SecRoleId = T000F3_A131SecRoleId[0];
            AssignAttri("", false, "A131SecRoleId", StringUtil.LTrimStr( (decimal)(A131SecRoleId), 4, 0));
            Z128SecFunctionalityId = A128SecFunctionalityId;
            Z131SecRoleId = A131SecRoleId;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0F18( ) ;
            if ( AnyError == 1 )
            {
               RcdFound18 = 0;
               InitializeNonKey0F18( ) ;
            }
            Gx_mode = sMode18;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound18 = 0;
            InitializeNonKey0F18( ) ;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode18;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0F18( ) ;
         if ( RcdFound18 == 0 )
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
         RcdFound18 = 0;
         /* Using cursor T000F10 */
         pr_default.execute(8, new Object[] {A128SecFunctionalityId, A131SecRoleId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000F10_A128SecFunctionalityId[0] < A128SecFunctionalityId ) || ( T000F10_A128SecFunctionalityId[0] == A128SecFunctionalityId ) && ( T000F10_A131SecRoleId[0] < A131SecRoleId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000F10_A128SecFunctionalityId[0] > A128SecFunctionalityId ) || ( T000F10_A128SecFunctionalityId[0] == A128SecFunctionalityId ) && ( T000F10_A131SecRoleId[0] > A131SecRoleId ) ) )
            {
               A128SecFunctionalityId = T000F10_A128SecFunctionalityId[0];
               AssignAttri("", false, "A128SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A128SecFunctionalityId), 10, 0));
               A131SecRoleId = T000F10_A131SecRoleId[0];
               AssignAttri("", false, "A131SecRoleId", StringUtil.LTrimStr( (decimal)(A131SecRoleId), 4, 0));
               RcdFound18 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound18 = 0;
         /* Using cursor T000F11 */
         pr_default.execute(9, new Object[] {A128SecFunctionalityId, A131SecRoleId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000F11_A128SecFunctionalityId[0] > A128SecFunctionalityId ) || ( T000F11_A128SecFunctionalityId[0] == A128SecFunctionalityId ) && ( T000F11_A131SecRoleId[0] > A131SecRoleId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000F11_A128SecFunctionalityId[0] < A128SecFunctionalityId ) || ( T000F11_A128SecFunctionalityId[0] == A128SecFunctionalityId ) && ( T000F11_A131SecRoleId[0] < A131SecRoleId ) ) )
            {
               A128SecFunctionalityId = T000F11_A128SecFunctionalityId[0];
               AssignAttri("", false, "A128SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A128SecFunctionalityId), 10, 0));
               A131SecRoleId = T000F11_A131SecRoleId[0];
               AssignAttri("", false, "A131SecRoleId", StringUtil.LTrimStr( (decimal)(A131SecRoleId), 4, 0));
               RcdFound18 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0F18( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSecFunctionalityId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0F18( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound18 == 1 )
            {
               if ( ( A128SecFunctionalityId != Z128SecFunctionalityId ) || ( A131SecRoleId != Z131SecRoleId ) )
               {
                  A128SecFunctionalityId = Z128SecFunctionalityId;
                  AssignAttri("", false, "A128SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A128SecFunctionalityId), 10, 0));
                  A131SecRoleId = Z131SecRoleId;
                  AssignAttri("", false, "A131SecRoleId", StringUtil.LTrimStr( (decimal)(A131SecRoleId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SECFUNCTIONALITYID");
                  AnyError = 1;
                  GX_FocusControl = edtSecFunctionalityId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSecFunctionalityId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0F18( ) ;
                  GX_FocusControl = edtSecFunctionalityId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A128SecFunctionalityId != Z128SecFunctionalityId ) || ( A131SecRoleId != Z131SecRoleId ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtSecFunctionalityId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0F18( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SECFUNCTIONALITYID");
                     AnyError = 1;
                     GX_FocusControl = edtSecFunctionalityId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtSecFunctionalityId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0F18( ) ;
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
         if ( ( A128SecFunctionalityId != Z128SecFunctionalityId ) || ( A131SecRoleId != Z131SecRoleId ) )
         {
            A128SecFunctionalityId = Z128SecFunctionalityId;
            AssignAttri("", false, "A128SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A128SecFunctionalityId), 10, 0));
            A131SecRoleId = Z131SecRoleId;
            AssignAttri("", false, "A131SecRoleId", StringUtil.LTrimStr( (decimal)(A131SecRoleId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SECFUNCTIONALITYID");
            AnyError = 1;
            GX_FocusControl = edtSecFunctionalityId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSecFunctionalityId_Internalname;
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
         if ( RcdFound18 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "SECFUNCTIONALITYID");
            AnyError = 1;
            GX_FocusControl = edtSecFunctionalityId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = chkSecFunctionalityRoleAtivo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0F18( ) ;
         if ( RcdFound18 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = chkSecFunctionalityRoleAtivo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0F18( ) ;
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
         if ( RcdFound18 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = chkSecFunctionalityRoleAtivo_Internalname;
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
         if ( RcdFound18 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = chkSecFunctionalityRoleAtivo_Internalname;
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
         ScanStart0F18( ) ;
         if ( RcdFound18 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound18 != 0 )
            {
               ScanNext0F18( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = chkSecFunctionalityRoleAtivo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0F18( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0F18( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000F2 */
            pr_default.execute(0, new Object[] {A128SecFunctionalityId, A131SecRoleId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecFunctionalityRole"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z735SecFunctionalityRoleAtivo != T000F2_A735SecFunctionalityRoleAtivo[0] ) )
            {
               if ( Z735SecFunctionalityRoleAtivo != T000F2_A735SecFunctionalityRoleAtivo[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.secfunctionalityrole:[seudo value changed for attri]"+"SecFunctionalityRoleAtivo");
                  GXUtil.WriteLogRaw("Old: ",Z735SecFunctionalityRoleAtivo);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A735SecFunctionalityRoleAtivo[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SecFunctionalityRole"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0F18( )
      {
         BeforeValidate0F18( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F18( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0F18( 0) ;
            CheckOptimisticConcurrency0F18( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F18( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0F18( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000F12 */
                     pr_default.execute(10, new Object[] {A735SecFunctionalityRoleAtivo, A128SecFunctionalityId, A131SecRoleId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("SecFunctionalityRole");
                     if ( (pr_default.getStatus(10) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0F0( ) ;
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
               Load0F18( ) ;
            }
            EndLevel0F18( ) ;
         }
         CloseExtendedTableCursors0F18( ) ;
      }

      protected void Update0F18( )
      {
         BeforeValidate0F18( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F18( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F18( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F18( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0F18( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000F13 */
                     pr_default.execute(11, new Object[] {A735SecFunctionalityRoleAtivo, A128SecFunctionalityId, A131SecRoleId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("SecFunctionalityRole");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecFunctionalityRole"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0F18( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0F0( ) ;
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
            EndLevel0F18( ) ;
         }
         CloseExtendedTableCursors0F18( ) ;
      }

      protected void DeferredUpdate0F18( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0F18( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F18( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0F18( ) ;
            AfterConfirm0F18( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0F18( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000F14 */
                  pr_default.execute(12, new Object[] {A128SecFunctionalityId, A131SecRoleId});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("SecFunctionalityRole");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound18 == 0 )
                        {
                           InitAll0F18( ) ;
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
                        ResetCaption0F0( ) ;
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
         sMode18 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0F18( ) ;
         Gx_mode = sMode18;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0F18( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000F15 */
            pr_default.execute(13, new Object[] {A128SecFunctionalityId});
            A135SecFunctionalityDescription = T000F15_A135SecFunctionalityDescription[0];
            n135SecFunctionalityDescription = T000F15_n135SecFunctionalityDescription[0];
            AssignAttri("", false, "A135SecFunctionalityDescription", A135SecFunctionalityDescription);
            pr_default.close(13);
         }
      }

      protected void EndLevel0F18( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0F18( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("wwpbaseobjects.secfunctionalityrole",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0F0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("wwpbaseobjects.secfunctionalityrole",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0F18( )
      {
         /* Scan By routine */
         /* Using cursor T000F16 */
         pr_default.execute(14);
         RcdFound18 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound18 = 1;
            A128SecFunctionalityId = T000F16_A128SecFunctionalityId[0];
            AssignAttri("", false, "A128SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A128SecFunctionalityId), 10, 0));
            A131SecRoleId = T000F16_A131SecRoleId[0];
            AssignAttri("", false, "A131SecRoleId", StringUtil.LTrimStr( (decimal)(A131SecRoleId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0F18( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound18 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound18 = 1;
            A128SecFunctionalityId = T000F16_A128SecFunctionalityId[0];
            AssignAttri("", false, "A128SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A128SecFunctionalityId), 10, 0));
            A131SecRoleId = T000F16_A131SecRoleId[0];
            AssignAttri("", false, "A131SecRoleId", StringUtil.LTrimStr( (decimal)(A131SecRoleId), 4, 0));
         }
      }

      protected void ScanEnd0F18( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm0F18( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0F18( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0F18( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0F18( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0F18( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0F18( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0F18( )
      {
         edtSecFunctionalityId_Enabled = 0;
         AssignProp("", false, edtSecFunctionalityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecFunctionalityId_Enabled), 5, 0), true);
         edtSecFunctionalityDescription_Enabled = 0;
         AssignProp("", false, edtSecFunctionalityDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecFunctionalityDescription_Enabled), 5, 0), true);
         edtSecRoleId_Enabled = 0;
         AssignProp("", false, edtSecRoleId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecRoleId_Enabled), 5, 0), true);
         chkSecFunctionalityRoleAtivo.Enabled = 0;
         AssignProp("", false, chkSecFunctionalityRoleAtivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkSecFunctionalityRoleAtivo.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0F18( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0F0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.secfunctionalityrole") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z128SecFunctionalityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z128SecFunctionalityId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z131SecRoleId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z131SecRoleId), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z735SecFunctionalityRoleAtivo", Z735SecFunctionalityRoleAtivo);
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
         return formatLink("wwpbaseobjects.secfunctionalityrole")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.SecFunctionalityRole" ;
      }

      public override string GetPgmdesc( )
      {
         return "Functionality - Role" ;
      }

      protected void InitializeNonKey0F18( )
      {
         A135SecFunctionalityDescription = "";
         n135SecFunctionalityDescription = false;
         AssignAttri("", false, "A135SecFunctionalityDescription", A135SecFunctionalityDescription);
         A735SecFunctionalityRoleAtivo = false;
         AssignAttri("", false, "A735SecFunctionalityRoleAtivo", A735SecFunctionalityRoleAtivo);
         Z735SecFunctionalityRoleAtivo = false;
      }

      protected void InitAll0F18( )
      {
         A128SecFunctionalityId = 0;
         AssignAttri("", false, "A128SecFunctionalityId", StringUtil.LTrimStr( (decimal)(A128SecFunctionalityId), 10, 0));
         A131SecRoleId = 0;
         AssignAttri("", false, "A131SecRoleId", StringUtil.LTrimStr( (decimal)(A131SecRoleId), 4, 0));
         InitializeNonKey0F18( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019124334", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/secfunctionalityrole.js", "?202561019124335", false, true);
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
         edtSecFunctionalityId_Internalname = "SECFUNCTIONALITYID";
         edtSecFunctionalityDescription_Internalname = "SECFUNCTIONALITYDESCRIPTION";
         edtSecRoleId_Internalname = "SECROLEID";
         chkSecFunctionalityRoleAtivo_Internalname = "SECFUNCTIONALITYROLEATIVO";
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
         Form.Caption = "Functionality - Role";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chkSecFunctionalityRoleAtivo.Enabled = 1;
         edtSecRoleId_Jsonclick = "";
         edtSecRoleId_Enabled = 1;
         edtSecFunctionalityDescription_Jsonclick = "";
         edtSecFunctionalityDescription_Enabled = 0;
         edtSecFunctionalityId_Jsonclick = "";
         edtSecFunctionalityId_Enabled = 1;
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
         chkSecFunctionalityRoleAtivo.Name = "SECFUNCTIONALITYROLEATIVO";
         chkSecFunctionalityRoleAtivo.WebTags = "";
         chkSecFunctionalityRoleAtivo.Caption = "Role Ativo";
         AssignProp("", false, chkSecFunctionalityRoleAtivo_Internalname, "TitleCaption", chkSecFunctionalityRoleAtivo.Caption, true);
         chkSecFunctionalityRoleAtivo.CheckedValue = "false";
         A735SecFunctionalityRoleAtivo = StringUtil.StrToBool( StringUtil.BoolToStr( A735SecFunctionalityRoleAtivo));
         AssignAttri("", false, "A735SecFunctionalityRoleAtivo", A735SecFunctionalityRoleAtivo);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         /* Using cursor T000F15 */
         pr_default.execute(13, new Object[] {A128SecFunctionalityId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("Não existe 'Functionality'.", "ForeignKeyNotFound", 1, "SECFUNCTIONALITYID");
            AnyError = 1;
            GX_FocusControl = edtSecFunctionalityId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A135SecFunctionalityDescription = T000F15_A135SecFunctionalityDescription[0];
         n135SecFunctionalityDescription = T000F15_n135SecFunctionalityDescription[0];
         AssignAttri("", false, "A135SecFunctionalityDescription", A135SecFunctionalityDescription);
         pr_default.close(13);
         /* Using cursor T000F17 */
         pr_default.execute(15, new Object[] {A131SecRoleId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("Não existe 'Role'.", "ForeignKeyNotFound", 1, "SECROLEID");
            AnyError = 1;
            GX_FocusControl = edtSecRoleId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(15);
         GX_FocusControl = chkSecFunctionalityRoleAtivo_Internalname;
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

      public void Valid_Secfunctionalityid( )
      {
         n135SecFunctionalityDescription = false;
         /* Using cursor T000F15 */
         pr_default.execute(13, new Object[] {A128SecFunctionalityId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("Não existe 'Functionality'.", "ForeignKeyNotFound", 1, "SECFUNCTIONALITYID");
            AnyError = 1;
            GX_FocusControl = edtSecFunctionalityId_Internalname;
         }
         A135SecFunctionalityDescription = T000F15_A135SecFunctionalityDescription[0];
         n135SecFunctionalityDescription = T000F15_n135SecFunctionalityDescription[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A135SecFunctionalityDescription", A135SecFunctionalityDescription);
      }

      public void Valid_Secroleid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T000F17 */
         pr_default.execute(15, new Object[] {A131SecRoleId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("Não existe 'Role'.", "ForeignKeyNotFound", 1, "SECROLEID");
            AnyError = 1;
            GX_FocusControl = edtSecRoleId_Internalname;
         }
         pr_default.close(15);
         dynload_actions( ) ;
         A735SecFunctionalityRoleAtivo = StringUtil.StrToBool( StringUtil.BoolToStr( A735SecFunctionalityRoleAtivo));
         /*  Sending validation outputs */
         AssignAttri("", false, "A735SecFunctionalityRoleAtivo", A735SecFunctionalityRoleAtivo);
         AssignAttri("", false, "A135SecFunctionalityDescription", A135SecFunctionalityDescription);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z128SecFunctionalityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z128SecFunctionalityId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z131SecRoleId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z131SecRoleId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z735SecFunctionalityRoleAtivo", StringUtil.BoolToStr( Z735SecFunctionalityRoleAtivo));
         GxWebStd.gx_hidden_field( context, "Z135SecFunctionalityDescription", Z135SecFunctionalityDescription);
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"A735SecFunctionalityRoleAtivo","fld":"SECFUNCTIONALITYROLEATIVO","type":"boolean"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A735SecFunctionalityRoleAtivo","fld":"SECFUNCTIONALITYROLEATIVO","type":"boolean"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A735SecFunctionalityRoleAtivo","fld":"SECFUNCTIONALITYROLEATIVO","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A735SecFunctionalityRoleAtivo","fld":"SECFUNCTIONALITYROLEATIVO","type":"boolean"}]}""");
         setEventMetadata("VALID_SECFUNCTIONALITYID","""{"handler":"Valid_Secfunctionalityid","iparms":[{"av":"A128SecFunctionalityId","fld":"SECFUNCTIONALITYID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"A135SecFunctionalityDescription","fld":"SECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"A735SecFunctionalityRoleAtivo","fld":"SECFUNCTIONALITYROLEATIVO","type":"boolean"}]""");
         setEventMetadata("VALID_SECFUNCTIONALITYID",""","oparms":[{"av":"A135SecFunctionalityDescription","fld":"SECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"A735SecFunctionalityRoleAtivo","fld":"SECFUNCTIONALITYROLEATIVO","type":"boolean"}]}""");
         setEventMetadata("VALID_SECROLEID","""{"handler":"Valid_Secroleid","iparms":[{"av":"A128SecFunctionalityId","fld":"SECFUNCTIONALITYID","pic":"ZZZZZZZZZ9","type":"int"},{"av":"A131SecRoleId","fld":"SECROLEID","pic":"ZZZ9","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"A735SecFunctionalityRoleAtivo","fld":"SECFUNCTIONALITYROLEATIVO","type":"boolean"}]""");
         setEventMetadata("VALID_SECROLEID",""","oparms":[{"av":"A135SecFunctionalityDescription","fld":"SECFUNCTIONALITYDESCRIPTION","type":"svchar"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"Z128SecFunctionalityId","type":"int"},{"av":"Z131SecRoleId","type":"int"},{"av":"Z735SecFunctionalityRoleAtivo","type":"boolean"},{"av":"Z135SecFunctionalityDescription","type":"svchar"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"},{"av":"A735SecFunctionalityRoleAtivo","fld":"SECFUNCTIONALITYROLEATIVO","type":"boolean"}]}""");
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
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
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
         A135SecFunctionalityDescription = "";
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
         Z135SecFunctionalityDescription = "";
         T000F6_A135SecFunctionalityDescription = new string[] {""} ;
         T000F6_n135SecFunctionalityDescription = new bool[] {false} ;
         T000F6_A735SecFunctionalityRoleAtivo = new bool[] {false} ;
         T000F6_A128SecFunctionalityId = new long[1] ;
         T000F6_A131SecRoleId = new short[1] ;
         T000F4_A135SecFunctionalityDescription = new string[] {""} ;
         T000F4_n135SecFunctionalityDescription = new bool[] {false} ;
         T000F5_A131SecRoleId = new short[1] ;
         T000F7_A135SecFunctionalityDescription = new string[] {""} ;
         T000F7_n135SecFunctionalityDescription = new bool[] {false} ;
         T000F8_A131SecRoleId = new short[1] ;
         T000F9_A128SecFunctionalityId = new long[1] ;
         T000F9_A131SecRoleId = new short[1] ;
         T000F3_A735SecFunctionalityRoleAtivo = new bool[] {false} ;
         T000F3_A128SecFunctionalityId = new long[1] ;
         T000F3_A131SecRoleId = new short[1] ;
         sMode18 = "";
         T000F10_A128SecFunctionalityId = new long[1] ;
         T000F10_A131SecRoleId = new short[1] ;
         T000F11_A128SecFunctionalityId = new long[1] ;
         T000F11_A131SecRoleId = new short[1] ;
         T000F2_A735SecFunctionalityRoleAtivo = new bool[] {false} ;
         T000F2_A128SecFunctionalityId = new long[1] ;
         T000F2_A131SecRoleId = new short[1] ;
         T000F15_A135SecFunctionalityDescription = new string[] {""} ;
         T000F15_n135SecFunctionalityDescription = new bool[] {false} ;
         T000F16_A128SecFunctionalityId = new long[1] ;
         T000F16_A131SecRoleId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000F17_A131SecRoleId = new short[1] ;
         ZZ135SecFunctionalityDescription = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secfunctionalityrole__default(),
            new Object[][] {
                new Object[] {
               T000F2_A735SecFunctionalityRoleAtivo, T000F2_A128SecFunctionalityId, T000F2_A131SecRoleId
               }
               , new Object[] {
               T000F3_A735SecFunctionalityRoleAtivo, T000F3_A128SecFunctionalityId, T000F3_A131SecRoleId
               }
               , new Object[] {
               T000F4_A135SecFunctionalityDescription, T000F4_n135SecFunctionalityDescription
               }
               , new Object[] {
               T000F5_A131SecRoleId
               }
               , new Object[] {
               T000F6_A135SecFunctionalityDescription, T000F6_n135SecFunctionalityDescription, T000F6_A735SecFunctionalityRoleAtivo, T000F6_A128SecFunctionalityId, T000F6_A131SecRoleId
               }
               , new Object[] {
               T000F7_A135SecFunctionalityDescription, T000F7_n135SecFunctionalityDescription
               }
               , new Object[] {
               T000F8_A131SecRoleId
               }
               , new Object[] {
               T000F9_A128SecFunctionalityId, T000F9_A131SecRoleId
               }
               , new Object[] {
               T000F10_A128SecFunctionalityId, T000F10_A131SecRoleId
               }
               , new Object[] {
               T000F11_A128SecFunctionalityId, T000F11_A131SecRoleId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000F15_A135SecFunctionalityDescription, T000F15_n135SecFunctionalityDescription
               }
               , new Object[] {
               T000F16_A128SecFunctionalityId, T000F16_A131SecRoleId
               }
               , new Object[] {
               T000F17_A131SecRoleId
               }
            }
         );
      }

      private short Z131SecRoleId ;
      private short GxWebError ;
      private short A131SecRoleId ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound18 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ131SecRoleId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtSecFunctionalityId_Enabled ;
      private int edtSecFunctionalityDescription_Enabled ;
      private int edtSecRoleId_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z128SecFunctionalityId ;
      private long A128SecFunctionalityId ;
      private long ZZ128SecFunctionalityId ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtSecFunctionalityId_Internalname ;
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
      private string edtSecFunctionalityId_Jsonclick ;
      private string edtSecFunctionalityDescription_Internalname ;
      private string edtSecFunctionalityDescription_Jsonclick ;
      private string edtSecRoleId_Internalname ;
      private string edtSecRoleId_Jsonclick ;
      private string chkSecFunctionalityRoleAtivo_Internalname ;
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
      private string sMode18 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool Z735SecFunctionalityRoleAtivo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A735SecFunctionalityRoleAtivo ;
      private bool n135SecFunctionalityDescription ;
      private bool ZZ735SecFunctionalityRoleAtivo ;
      private string A135SecFunctionalityDescription ;
      private string Z135SecFunctionalityDescription ;
      private string ZZ135SecFunctionalityDescription ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkSecFunctionalityRoleAtivo ;
      private IDataStoreProvider pr_default ;
      private string[] T000F6_A135SecFunctionalityDescription ;
      private bool[] T000F6_n135SecFunctionalityDescription ;
      private bool[] T000F6_A735SecFunctionalityRoleAtivo ;
      private long[] T000F6_A128SecFunctionalityId ;
      private short[] T000F6_A131SecRoleId ;
      private string[] T000F4_A135SecFunctionalityDescription ;
      private bool[] T000F4_n135SecFunctionalityDescription ;
      private short[] T000F5_A131SecRoleId ;
      private string[] T000F7_A135SecFunctionalityDescription ;
      private bool[] T000F7_n135SecFunctionalityDescription ;
      private short[] T000F8_A131SecRoleId ;
      private long[] T000F9_A128SecFunctionalityId ;
      private short[] T000F9_A131SecRoleId ;
      private bool[] T000F3_A735SecFunctionalityRoleAtivo ;
      private long[] T000F3_A128SecFunctionalityId ;
      private short[] T000F3_A131SecRoleId ;
      private long[] T000F10_A128SecFunctionalityId ;
      private short[] T000F10_A131SecRoleId ;
      private long[] T000F11_A128SecFunctionalityId ;
      private short[] T000F11_A131SecRoleId ;
      private bool[] T000F2_A735SecFunctionalityRoleAtivo ;
      private long[] T000F2_A128SecFunctionalityId ;
      private short[] T000F2_A131SecRoleId ;
      private string[] T000F15_A135SecFunctionalityDescription ;
      private bool[] T000F15_n135SecFunctionalityDescription ;
      private long[] T000F16_A128SecFunctionalityId ;
      private short[] T000F16_A131SecRoleId ;
      private short[] T000F17_A131SecRoleId ;
   }

   public class secfunctionalityrole__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000F2;
          prmT000F2 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0) ,
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmT000F3;
          prmT000F3 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0) ,
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmT000F4;
          prmT000F4 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmT000F5;
          prmT000F5 = new Object[] {
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmT000F6;
          prmT000F6 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0) ,
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmT000F7;
          prmT000F7 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmT000F8;
          prmT000F8 = new Object[] {
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmT000F9;
          prmT000F9 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0) ,
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmT000F10;
          prmT000F10 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0) ,
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmT000F11;
          prmT000F11 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0) ,
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmT000F12;
          prmT000F12 = new Object[] {
          new ParDef("SecFunctionalityRoleAtivo",GXType.Boolean,4,0) ,
          new ParDef("SecFunctionalityId",GXType.Int64,10,0) ,
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmT000F13;
          prmT000F13 = new Object[] {
          new ParDef("SecFunctionalityRoleAtivo",GXType.Boolean,4,0) ,
          new ParDef("SecFunctionalityId",GXType.Int64,10,0) ,
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmT000F14;
          prmT000F14 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0) ,
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmT000F15;
          prmT000F15 = new Object[] {
          new ParDef("SecFunctionalityId",GXType.Int64,10,0)
          };
          Object[] prmT000F16;
          prmT000F16 = new Object[] {
          };
          Object[] prmT000F17;
          prmT000F17 = new Object[] {
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T000F2", "SELECT SecFunctionalityRoleAtivo, SecFunctionalityId, SecRoleId FROM SecFunctionalityRole WHERE SecFunctionalityId = :SecFunctionalityId AND SecRoleId = :SecRoleId  FOR UPDATE OF SecFunctionalityRole NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000F2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F3", "SELECT SecFunctionalityRoleAtivo, SecFunctionalityId, SecRoleId FROM SecFunctionalityRole WHERE SecFunctionalityId = :SecFunctionalityId AND SecRoleId = :SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F4", "SELECT SecFunctionalityDescription FROM SecFunctionality WHERE SecFunctionalityId = :SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F5", "SELECT SecRoleId FROM SecRole WHERE SecRoleId = :SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F6", "SELECT T2.SecFunctionalityDescription, TM1.SecFunctionalityRoleAtivo, TM1.SecFunctionalityId, TM1.SecRoleId FROM (SecFunctionalityRole TM1 INNER JOIN SecFunctionality T2 ON T2.SecFunctionalityId = TM1.SecFunctionalityId) WHERE TM1.SecFunctionalityId = :SecFunctionalityId and TM1.SecRoleId = :SecRoleId ORDER BY TM1.SecFunctionalityId, TM1.SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F7", "SELECT SecFunctionalityDescription FROM SecFunctionality WHERE SecFunctionalityId = :SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F8", "SELECT SecRoleId FROM SecRole WHERE SecRoleId = :SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F9", "SELECT SecFunctionalityId, SecRoleId FROM SecFunctionalityRole WHERE SecFunctionalityId = :SecFunctionalityId AND SecRoleId = :SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F10", "SELECT SecFunctionalityId, SecRoleId FROM SecFunctionalityRole WHERE ( SecFunctionalityId > :SecFunctionalityId or SecFunctionalityId = :SecFunctionalityId and SecRoleId > :SecRoleId) ORDER BY SecFunctionalityId, SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000F11", "SELECT SecFunctionalityId, SecRoleId FROM SecFunctionalityRole WHERE ( SecFunctionalityId < :SecFunctionalityId or SecFunctionalityId = :SecFunctionalityId and SecRoleId < :SecRoleId) ORDER BY SecFunctionalityId DESC, SecRoleId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000F12", "SAVEPOINT gxupdate;INSERT INTO SecFunctionalityRole(SecFunctionalityRoleAtivo, SecFunctionalityId, SecRoleId) VALUES(:SecFunctionalityRoleAtivo, :SecFunctionalityId, :SecRoleId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000F12)
             ,new CursorDef("T000F13", "SAVEPOINT gxupdate;UPDATE SecFunctionalityRole SET SecFunctionalityRoleAtivo=:SecFunctionalityRoleAtivo  WHERE SecFunctionalityId = :SecFunctionalityId AND SecRoleId = :SecRoleId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000F13)
             ,new CursorDef("T000F14", "SAVEPOINT gxupdate;DELETE FROM SecFunctionalityRole  WHERE SecFunctionalityId = :SecFunctionalityId AND SecRoleId = :SecRoleId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000F14)
             ,new CursorDef("T000F15", "SELECT SecFunctionalityDescription FROM SecFunctionality WHERE SecFunctionalityId = :SecFunctionalityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F16", "SELECT SecFunctionalityId, SecRoleId FROM SecFunctionalityRole ORDER BY SecFunctionalityId, SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F16,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000F17", "SELECT SecRoleId FROM SecRole WHERE SecRoleId = :SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F17,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 1 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 7 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 8 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 9 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 14 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
