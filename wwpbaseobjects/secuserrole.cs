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
   public class secuserrole : GXDataArea
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
            A133SecUserId = (short)(Math.Round(NumberUtil.Val( GetPar( "SecUserId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A133SecUserId", StringUtil.LTrimStr( (decimal)(A133SecUserId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A133SecUserId) ;
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
         Form.Meta.addItem("description", "Sec User Role", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSecUserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public secuserrole( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secuserrole( IGxContext context )
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
         chkSecUserRoleActive = new GXCheckbox();
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
         A647SecUserRoleActive = StringUtil.StrToBool( StringUtil.BoolToStr( A647SecUserRoleActive));
         AssignAttri("", false, "A647SecUserRoleActive", A647SecUserRoleActive);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Sec User Role", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects/SecUserRole.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecUserRole.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecUserRole.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecUserRole.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecUserRole.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects/SecUserRole.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSecUserId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecUserId_Internalname, "Usuário", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecUserId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A133SecUserId), 4, 0, ",", "")), StringUtil.LTrim( ((edtSecUserId_Enabled!=0) ? context.localUtil.Format( (decimal)(A133SecUserId), "ZZZ9") : context.localUtil.Format( (decimal)(A133SecUserId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecUserId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSecUserId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/SecUserRole.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecRoleId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A131SecRoleId), 4, 0, ",", "")), StringUtil.LTrim( ((edtSecRoleId_Enabled!=0) ? context.localUtil.Format( (decimal)(A131SecRoleId), "ZZZ9") : context.localUtil.Format( (decimal)(A131SecRoleId), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecRoleId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSecRoleId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects/SecUserRole.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSecUserName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecUserName_Internalname, "Usuário", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecUserName_Internalname, A141SecUserName, StringUtil.RTrim( context.localUtil.Format( A141SecUserName, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecUserName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSecUserName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/SecUserRole.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSecRoleName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecRoleName_Internalname, "Role Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecRoleName_Internalname, A140SecRoleName, StringUtil.RTrim( context.localUtil.Format( A140SecRoleName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecRoleName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSecRoleName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/SecUserRole.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtSecRoleDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSecRoleDescription_Internalname, "Role Description", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSecRoleDescription_Internalname, A139SecRoleDescription, StringUtil.RTrim( context.localUtil.Format( A139SecRoleDescription, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSecRoleDescription_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSecRoleDescription_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects/SecUserRole.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkSecUserRoleActive_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkSecUserRoleActive_Internalname, "Role Active", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkSecUserRoleActive_Internalname, StringUtil.BoolToStr( A647SecUserRoleActive), "", "Role Active", 1, chkSecUserRoleActive.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(59, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,59);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecUserRole.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecUserRole.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects/SecUserRole.htm");
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
            Z133SecUserId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z133SecUserId"), ",", "."), 18, MidpointRounding.ToEven));
            Z131SecRoleId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z131SecRoleId"), ",", "."), 18, MidpointRounding.ToEven));
            Z647SecUserRoleActive = StringUtil.StrToBool( cgiGet( "Z647SecUserRoleActive"));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtSecUserId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSecUserId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SECUSERID");
               AnyError = 1;
               GX_FocusControl = edtSecUserId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A133SecUserId = 0;
               AssignAttri("", false, "A133SecUserId", StringUtil.LTrimStr( (decimal)(A133SecUserId), 4, 0));
            }
            else
            {
               A133SecUserId = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtSecUserId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A133SecUserId", StringUtil.LTrimStr( (decimal)(A133SecUserId), 4, 0));
            }
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
            A141SecUserName = StringUtil.Upper( cgiGet( edtSecUserName_Internalname));
            n141SecUserName = false;
            AssignAttri("", false, "A141SecUserName", A141SecUserName);
            A140SecRoleName = cgiGet( edtSecRoleName_Internalname);
            AssignAttri("", false, "A140SecRoleName", A140SecRoleName);
            A139SecRoleDescription = cgiGet( edtSecRoleDescription_Internalname);
            AssignAttri("", false, "A139SecRoleDescription", A139SecRoleDescription);
            A647SecUserRoleActive = StringUtil.StrToBool( cgiGet( chkSecUserRoleActive_Internalname));
            AssignAttri("", false, "A647SecUserRoleActive", A647SecUserRoleActive);
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
               A133SecUserId = (short)(Math.Round(NumberUtil.Val( GetPar( "SecUserId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A133SecUserId", StringUtil.LTrimStr( (decimal)(A133SecUserId), 4, 0));
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
               InitAll0J23( ) ;
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
         DisableAttributes0J23( ) ;
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

      protected void ResetCaption0J0( )
      {
      }

      protected void ZM0J23( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z647SecUserRoleActive = T000J3_A647SecUserRoleActive[0];
            }
            else
            {
               Z647SecUserRoleActive = A647SecUserRoleActive;
            }
         }
         if ( GX_JID == -1 )
         {
            Z647SecUserRoleActive = A647SecUserRoleActive;
            Z133SecUserId = A133SecUserId;
            Z131SecRoleId = A131SecRoleId;
            Z141SecUserName = A141SecUserName;
            Z140SecRoleName = A140SecRoleName;
            Z139SecRoleDescription = A139SecRoleDescription;
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

      protected void Load0J23( )
      {
         /* Using cursor T000J6 */
         pr_default.execute(4, new Object[] {A133SecUserId, A131SecRoleId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound23 = 1;
            A141SecUserName = T000J6_A141SecUserName[0];
            n141SecUserName = T000J6_n141SecUserName[0];
            AssignAttri("", false, "A141SecUserName", A141SecUserName);
            A140SecRoleName = T000J6_A140SecRoleName[0];
            AssignAttri("", false, "A140SecRoleName", A140SecRoleName);
            A139SecRoleDescription = T000J6_A139SecRoleDescription[0];
            AssignAttri("", false, "A139SecRoleDescription", A139SecRoleDescription);
            A647SecUserRoleActive = T000J6_A647SecUserRoleActive[0];
            AssignAttri("", false, "A647SecUserRoleActive", A647SecUserRoleActive);
            ZM0J23( -1) ;
         }
         pr_default.close(4);
         OnLoadActions0J23( ) ;
      }

      protected void OnLoadActions0J23( )
      {
      }

      protected void CheckExtendedTable0J23( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000J4 */
         pr_default.execute(2, new Object[] {A133SecUserId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'User'.", "ForeignKeyNotFound", 1, "SECUSERID");
            AnyError = 1;
            GX_FocusControl = edtSecUserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A141SecUserName = T000J4_A141SecUserName[0];
         n141SecUserName = T000J4_n141SecUserName[0];
         AssignAttri("", false, "A141SecUserName", A141SecUserName);
         pr_default.close(2);
         /* Using cursor T000J5 */
         pr_default.execute(3, new Object[] {A131SecRoleId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe 'Role'.", "ForeignKeyNotFound", 1, "SECROLEID");
            AnyError = 1;
            GX_FocusControl = edtSecRoleId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A140SecRoleName = T000J5_A140SecRoleName[0];
         AssignAttri("", false, "A140SecRoleName", A140SecRoleName);
         A139SecRoleDescription = T000J5_A139SecRoleDescription[0];
         AssignAttri("", false, "A139SecRoleDescription", A139SecRoleDescription);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0J23( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( short A133SecUserId )
      {
         /* Using cursor T000J7 */
         pr_default.execute(5, new Object[] {A133SecUserId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("Não existe 'User'.", "ForeignKeyNotFound", 1, "SECUSERID");
            AnyError = 1;
            GX_FocusControl = edtSecUserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A141SecUserName = T000J7_A141SecUserName[0];
         n141SecUserName = T000J7_n141SecUserName[0];
         AssignAttri("", false, "A141SecUserName", A141SecUserName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A141SecUserName)+"\"") ;
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
         /* Using cursor T000J8 */
         pr_default.execute(6, new Object[] {A131SecRoleId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("Não existe 'Role'.", "ForeignKeyNotFound", 1, "SECROLEID");
            AnyError = 1;
            GX_FocusControl = edtSecRoleId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A140SecRoleName = T000J8_A140SecRoleName[0];
         AssignAttri("", false, "A140SecRoleName", A140SecRoleName);
         A139SecRoleDescription = T000J8_A139SecRoleDescription[0];
         AssignAttri("", false, "A139SecRoleDescription", A139SecRoleDescription);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A140SecRoleName)+"\""+","+"\""+GXUtil.EncodeJSConstant( A139SecRoleDescription)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey0J23( )
      {
         /* Using cursor T000J9 */
         pr_default.execute(7, new Object[] {A133SecUserId, A131SecRoleId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound23 = 1;
         }
         else
         {
            RcdFound23 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000J3 */
         pr_default.execute(1, new Object[] {A133SecUserId, A131SecRoleId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0J23( 1) ;
            RcdFound23 = 1;
            A647SecUserRoleActive = T000J3_A647SecUserRoleActive[0];
            AssignAttri("", false, "A647SecUserRoleActive", A647SecUserRoleActive);
            A133SecUserId = T000J3_A133SecUserId[0];
            AssignAttri("", false, "A133SecUserId", StringUtil.LTrimStr( (decimal)(A133SecUserId), 4, 0));
            A131SecRoleId = T000J3_A131SecRoleId[0];
            AssignAttri("", false, "A131SecRoleId", StringUtil.LTrimStr( (decimal)(A131SecRoleId), 4, 0));
            Z133SecUserId = A133SecUserId;
            Z131SecRoleId = A131SecRoleId;
            sMode23 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0J23( ) ;
            if ( AnyError == 1 )
            {
               RcdFound23 = 0;
               InitializeNonKey0J23( ) ;
            }
            Gx_mode = sMode23;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound23 = 0;
            InitializeNonKey0J23( ) ;
            sMode23 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode23;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0J23( ) ;
         if ( RcdFound23 == 0 )
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
         RcdFound23 = 0;
         /* Using cursor T000J10 */
         pr_default.execute(8, new Object[] {A133SecUserId, A131SecRoleId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000J10_A133SecUserId[0] < A133SecUserId ) || ( T000J10_A133SecUserId[0] == A133SecUserId ) && ( T000J10_A131SecRoleId[0] < A131SecRoleId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000J10_A133SecUserId[0] > A133SecUserId ) || ( T000J10_A133SecUserId[0] == A133SecUserId ) && ( T000J10_A131SecRoleId[0] > A131SecRoleId ) ) )
            {
               A133SecUserId = T000J10_A133SecUserId[0];
               AssignAttri("", false, "A133SecUserId", StringUtil.LTrimStr( (decimal)(A133SecUserId), 4, 0));
               A131SecRoleId = T000J10_A131SecRoleId[0];
               AssignAttri("", false, "A131SecRoleId", StringUtil.LTrimStr( (decimal)(A131SecRoleId), 4, 0));
               RcdFound23 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound23 = 0;
         /* Using cursor T000J11 */
         pr_default.execute(9, new Object[] {A133SecUserId, A131SecRoleId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000J11_A133SecUserId[0] > A133SecUserId ) || ( T000J11_A133SecUserId[0] == A133SecUserId ) && ( T000J11_A131SecRoleId[0] > A131SecRoleId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000J11_A133SecUserId[0] < A133SecUserId ) || ( T000J11_A133SecUserId[0] == A133SecUserId ) && ( T000J11_A131SecRoleId[0] < A131SecRoleId ) ) )
            {
               A133SecUserId = T000J11_A133SecUserId[0];
               AssignAttri("", false, "A133SecUserId", StringUtil.LTrimStr( (decimal)(A133SecUserId), 4, 0));
               A131SecRoleId = T000J11_A131SecRoleId[0];
               AssignAttri("", false, "A131SecRoleId", StringUtil.LTrimStr( (decimal)(A131SecRoleId), 4, 0));
               RcdFound23 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0J23( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSecUserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0J23( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound23 == 1 )
            {
               if ( ( A133SecUserId != Z133SecUserId ) || ( A131SecRoleId != Z131SecRoleId ) )
               {
                  A133SecUserId = Z133SecUserId;
                  AssignAttri("", false, "A133SecUserId", StringUtil.LTrimStr( (decimal)(A133SecUserId), 4, 0));
                  A131SecRoleId = Z131SecRoleId;
                  AssignAttri("", false, "A131SecRoleId", StringUtil.LTrimStr( (decimal)(A131SecRoleId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SECUSERID");
                  AnyError = 1;
                  GX_FocusControl = edtSecUserId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSecUserId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0J23( ) ;
                  GX_FocusControl = edtSecUserId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A133SecUserId != Z133SecUserId ) || ( A131SecRoleId != Z131SecRoleId ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtSecUserId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0J23( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SECUSERID");
                     AnyError = 1;
                     GX_FocusControl = edtSecUserId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtSecUserId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0J23( ) ;
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
         if ( ( A133SecUserId != Z133SecUserId ) || ( A131SecRoleId != Z131SecRoleId ) )
         {
            A133SecUserId = Z133SecUserId;
            AssignAttri("", false, "A133SecUserId", StringUtil.LTrimStr( (decimal)(A133SecUserId), 4, 0));
            A131SecRoleId = Z131SecRoleId;
            AssignAttri("", false, "A131SecRoleId", StringUtil.LTrimStr( (decimal)(A131SecRoleId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SECUSERID");
            AnyError = 1;
            GX_FocusControl = edtSecUserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSecUserId_Internalname;
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
         if ( RcdFound23 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "SECUSERID");
            AnyError = 1;
            GX_FocusControl = edtSecUserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = chkSecUserRoleActive_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0J23( ) ;
         if ( RcdFound23 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = chkSecUserRoleActive_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0J23( ) ;
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
         if ( RcdFound23 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = chkSecUserRoleActive_Internalname;
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
         if ( RcdFound23 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = chkSecUserRoleActive_Internalname;
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
         ScanStart0J23( ) ;
         if ( RcdFound23 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound23 != 0 )
            {
               ScanNext0J23( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = chkSecUserRoleActive_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0J23( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0J23( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000J2 */
            pr_default.execute(0, new Object[] {A133SecUserId, A131SecRoleId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecUserRole"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z647SecUserRoleActive != T000J2_A647SecUserRoleActive[0] ) )
            {
               if ( Z647SecUserRoleActive != T000J2_A647SecUserRoleActive[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.secuserrole:[seudo value changed for attri]"+"SecUserRoleActive");
                  GXUtil.WriteLogRaw("Old: ",Z647SecUserRoleActive);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A647SecUserRoleActive[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SecUserRole"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0J23( )
      {
         BeforeValidate0J23( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J23( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0J23( 0) ;
            CheckOptimisticConcurrency0J23( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0J23( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0J23( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000J12 */
                     pr_default.execute(10, new Object[] {A647SecUserRoleActive, A133SecUserId, A131SecRoleId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("SecUserRole");
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
                           ResetCaption0J0( ) ;
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
               Load0J23( ) ;
            }
            EndLevel0J23( ) ;
         }
         CloseExtendedTableCursors0J23( ) ;
      }

      protected void Update0J23( )
      {
         BeforeValidate0J23( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J23( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0J23( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0J23( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0J23( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000J13 */
                     pr_default.execute(11, new Object[] {A647SecUserRoleActive, A133SecUserId, A131SecRoleId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("SecUserRole");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecUserRole"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0J23( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0J0( ) ;
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
            EndLevel0J23( ) ;
         }
         CloseExtendedTableCursors0J23( ) ;
      }

      protected void DeferredUpdate0J23( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0J23( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0J23( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0J23( ) ;
            AfterConfirm0J23( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0J23( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000J14 */
                  pr_default.execute(12, new Object[] {A133SecUserId, A131SecRoleId});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("SecUserRole");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound23 == 0 )
                        {
                           InitAll0J23( ) ;
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
                        ResetCaption0J0( ) ;
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
         sMode23 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0J23( ) ;
         Gx_mode = sMode23;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0J23( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000J15 */
            pr_default.execute(13, new Object[] {A133SecUserId});
            A141SecUserName = T000J15_A141SecUserName[0];
            n141SecUserName = T000J15_n141SecUserName[0];
            AssignAttri("", false, "A141SecUserName", A141SecUserName);
            pr_default.close(13);
            /* Using cursor T000J16 */
            pr_default.execute(14, new Object[] {A131SecRoleId});
            A140SecRoleName = T000J16_A140SecRoleName[0];
            AssignAttri("", false, "A140SecRoleName", A140SecRoleName);
            A139SecRoleDescription = T000J16_A139SecRoleDescription[0];
            AssignAttri("", false, "A139SecRoleDescription", A139SecRoleDescription);
            pr_default.close(14);
         }
      }

      protected void EndLevel0J23( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0J23( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("wwpbaseobjects.secuserrole",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0J0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("wwpbaseobjects.secuserrole",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0J23( )
      {
         /* Using cursor T000J17 */
         pr_default.execute(15);
         RcdFound23 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound23 = 1;
            A133SecUserId = T000J17_A133SecUserId[0];
            AssignAttri("", false, "A133SecUserId", StringUtil.LTrimStr( (decimal)(A133SecUserId), 4, 0));
            A131SecRoleId = T000J17_A131SecRoleId[0];
            AssignAttri("", false, "A131SecRoleId", StringUtil.LTrimStr( (decimal)(A131SecRoleId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0J23( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound23 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound23 = 1;
            A133SecUserId = T000J17_A133SecUserId[0];
            AssignAttri("", false, "A133SecUserId", StringUtil.LTrimStr( (decimal)(A133SecUserId), 4, 0));
            A131SecRoleId = T000J17_A131SecRoleId[0];
            AssignAttri("", false, "A131SecRoleId", StringUtil.LTrimStr( (decimal)(A131SecRoleId), 4, 0));
         }
      }

      protected void ScanEnd0J23( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm0J23( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0J23( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0J23( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0J23( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0J23( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0J23( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0J23( )
      {
         edtSecUserId_Enabled = 0;
         AssignProp("", false, edtSecUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserId_Enabled), 5, 0), true);
         edtSecRoleId_Enabled = 0;
         AssignProp("", false, edtSecRoleId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecRoleId_Enabled), 5, 0), true);
         edtSecUserName_Enabled = 0;
         AssignProp("", false, edtSecUserName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecUserName_Enabled), 5, 0), true);
         edtSecRoleName_Enabled = 0;
         AssignProp("", false, edtSecRoleName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecRoleName_Enabled), 5, 0), true);
         edtSecRoleDescription_Enabled = 0;
         AssignProp("", false, edtSecRoleDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSecRoleDescription_Enabled), 5, 0), true);
         chkSecUserRoleActive.Enabled = 0;
         AssignProp("", false, chkSecUserRoleActive_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkSecUserRoleActive.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0J23( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0J0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.secuserrole") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z133SecUserId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z133SecUserId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z131SecRoleId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z131SecRoleId), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z647SecUserRoleActive", Z647SecUserRoleActive);
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
         return formatLink("wwpbaseobjects.secuserrole")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.SecUserRole" ;
      }

      public override string GetPgmdesc( )
      {
         return "Sec User Role" ;
      }

      protected void InitializeNonKey0J23( )
      {
         A141SecUserName = "";
         n141SecUserName = false;
         AssignAttri("", false, "A141SecUserName", A141SecUserName);
         A140SecRoleName = "";
         AssignAttri("", false, "A140SecRoleName", A140SecRoleName);
         A139SecRoleDescription = "";
         AssignAttri("", false, "A139SecRoleDescription", A139SecRoleDescription);
         A647SecUserRoleActive = false;
         AssignAttri("", false, "A647SecUserRoleActive", A647SecUserRoleActive);
         Z647SecUserRoleActive = false;
      }

      protected void InitAll0J23( )
      {
         A133SecUserId = 0;
         AssignAttri("", false, "A133SecUserId", StringUtil.LTrimStr( (decimal)(A133SecUserId), 4, 0));
         A131SecRoleId = 0;
         AssignAttri("", false, "A131SecRoleId", StringUtil.LTrimStr( (decimal)(A131SecRoleId), 4, 0));
         InitializeNonKey0J23( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101913099", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/secuserrole.js", "?20256101913099", false, true);
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
         edtSecUserId_Internalname = "SECUSERID";
         edtSecRoleId_Internalname = "SECROLEID";
         edtSecUserName_Internalname = "SECUSERNAME";
         edtSecRoleName_Internalname = "SECROLENAME";
         edtSecRoleDescription_Internalname = "SECROLEDESCRIPTION";
         chkSecUserRoleActive_Internalname = "SECUSERROLEACTIVE";
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
         Form.Caption = "Sec User Role";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chkSecUserRoleActive.Enabled = 1;
         edtSecRoleDescription_Jsonclick = "";
         edtSecRoleDescription_Enabled = 0;
         edtSecRoleName_Jsonclick = "";
         edtSecRoleName_Enabled = 0;
         edtSecUserName_Jsonclick = "";
         edtSecUserName_Enabled = 0;
         edtSecRoleId_Jsonclick = "";
         edtSecRoleId_Enabled = 1;
         edtSecUserId_Jsonclick = "";
         edtSecUserId_Enabled = 1;
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
         chkSecUserRoleActive.Name = "SECUSERROLEACTIVE";
         chkSecUserRoleActive.WebTags = "";
         chkSecUserRoleActive.Caption = "Role Active";
         AssignProp("", false, chkSecUserRoleActive_Internalname, "TitleCaption", chkSecUserRoleActive.Caption, true);
         chkSecUserRoleActive.CheckedValue = "false";
         A647SecUserRoleActive = StringUtil.StrToBool( StringUtil.BoolToStr( A647SecUserRoleActive));
         AssignAttri("", false, "A647SecUserRoleActive", A647SecUserRoleActive);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         /* Using cursor T000J15 */
         pr_default.execute(13, new Object[] {A133SecUserId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("Não existe 'User'.", "ForeignKeyNotFound", 1, "SECUSERID");
            AnyError = 1;
            GX_FocusControl = edtSecUserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A141SecUserName = T000J15_A141SecUserName[0];
         n141SecUserName = T000J15_n141SecUserName[0];
         AssignAttri("", false, "A141SecUserName", A141SecUserName);
         pr_default.close(13);
         /* Using cursor T000J16 */
         pr_default.execute(14, new Object[] {A131SecRoleId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("Não existe 'Role'.", "ForeignKeyNotFound", 1, "SECROLEID");
            AnyError = 1;
            GX_FocusControl = edtSecRoleId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A140SecRoleName = T000J16_A140SecRoleName[0];
         AssignAttri("", false, "A140SecRoleName", A140SecRoleName);
         A139SecRoleDescription = T000J16_A139SecRoleDescription[0];
         AssignAttri("", false, "A139SecRoleDescription", A139SecRoleDescription);
         pr_default.close(14);
         GX_FocusControl = chkSecUserRoleActive_Internalname;
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

      public void Valid_Secuserid( )
      {
         n141SecUserName = false;
         /* Using cursor T000J15 */
         pr_default.execute(13, new Object[] {A133SecUserId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("Não existe 'User'.", "ForeignKeyNotFound", 1, "SECUSERID");
            AnyError = 1;
            GX_FocusControl = edtSecUserId_Internalname;
         }
         A141SecUserName = T000J15_A141SecUserName[0];
         n141SecUserName = T000J15_n141SecUserName[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A141SecUserName", A141SecUserName);
      }

      public void Valid_Secroleid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T000J16 */
         pr_default.execute(14, new Object[] {A131SecRoleId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("Não existe 'Role'.", "ForeignKeyNotFound", 1, "SECROLEID");
            AnyError = 1;
            GX_FocusControl = edtSecRoleId_Internalname;
         }
         A140SecRoleName = T000J16_A140SecRoleName[0];
         A139SecRoleDescription = T000J16_A139SecRoleDescription[0];
         pr_default.close(14);
         dynload_actions( ) ;
         A647SecUserRoleActive = StringUtil.StrToBool( StringUtil.BoolToStr( A647SecUserRoleActive));
         /*  Sending validation outputs */
         AssignAttri("", false, "A647SecUserRoleActive", A647SecUserRoleActive);
         AssignAttri("", false, "A141SecUserName", A141SecUserName);
         AssignAttri("", false, "A140SecRoleName", A140SecRoleName);
         AssignAttri("", false, "A139SecRoleDescription", A139SecRoleDescription);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z133SecUserId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z133SecUserId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z131SecRoleId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z131SecRoleId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z647SecUserRoleActive", StringUtil.BoolToStr( Z647SecUserRoleActive));
         GxWebStd.gx_hidden_field( context, "Z141SecUserName", Z141SecUserName);
         GxWebStd.gx_hidden_field( context, "Z140SecRoleName", Z140SecRoleName);
         GxWebStd.gx_hidden_field( context, "Z139SecRoleDescription", Z139SecRoleDescription);
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"A647SecUserRoleActive","fld":"SECUSERROLEACTIVE","type":"boolean"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A647SecUserRoleActive","fld":"SECUSERROLEACTIVE","type":"boolean"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A647SecUserRoleActive","fld":"SECUSERROLEACTIVE","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A647SecUserRoleActive","fld":"SECUSERROLEACTIVE","type":"boolean"}]}""");
         setEventMetadata("VALID_SECUSERID","""{"handler":"Valid_Secuserid","iparms":[{"av":"A133SecUserId","fld":"SECUSERID","pic":"ZZZ9","type":"int"},{"av":"A141SecUserName","fld":"SECUSERNAME","pic":"@!","type":"svchar"},{"av":"A647SecUserRoleActive","fld":"SECUSERROLEACTIVE","type":"boolean"}]""");
         setEventMetadata("VALID_SECUSERID",""","oparms":[{"av":"A141SecUserName","fld":"SECUSERNAME","pic":"@!","type":"svchar"},{"av":"A647SecUserRoleActive","fld":"SECUSERROLEACTIVE","type":"boolean"}]}""");
         setEventMetadata("VALID_SECROLEID","""{"handler":"Valid_Secroleid","iparms":[{"av":"A133SecUserId","fld":"SECUSERID","pic":"ZZZ9","type":"int"},{"av":"A131SecRoleId","fld":"SECROLEID","pic":"ZZZ9","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"A647SecUserRoleActive","fld":"SECUSERROLEACTIVE","type":"boolean"}]""");
         setEventMetadata("VALID_SECROLEID",""","oparms":[{"av":"A141SecUserName","fld":"SECUSERNAME","pic":"@!","type":"svchar"},{"av":"A140SecRoleName","fld":"SECROLENAME","type":"svchar"},{"av":"A139SecRoleDescription","fld":"SECROLEDESCRIPTION","type":"svchar"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"Z133SecUserId","type":"int"},{"av":"Z131SecRoleId","type":"int"},{"av":"Z647SecUserRoleActive","type":"boolean"},{"av":"Z141SecUserName","type":"svchar"},{"av":"Z140SecRoleName","type":"svchar"},{"av":"Z139SecRoleDescription","type":"svchar"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"},{"av":"A647SecUserRoleActive","fld":"SECUSERROLEACTIVE","type":"boolean"}]}""");
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
         pr_default.close(14);
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
         A141SecUserName = "";
         A140SecRoleName = "";
         A139SecRoleDescription = "";
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
         Z141SecUserName = "";
         Z140SecRoleName = "";
         Z139SecRoleDescription = "";
         T000J6_A141SecUserName = new string[] {""} ;
         T000J6_n141SecUserName = new bool[] {false} ;
         T000J6_A140SecRoleName = new string[] {""} ;
         T000J6_A139SecRoleDescription = new string[] {""} ;
         T000J6_A647SecUserRoleActive = new bool[] {false} ;
         T000J6_A133SecUserId = new short[1] ;
         T000J6_A131SecRoleId = new short[1] ;
         T000J4_A141SecUserName = new string[] {""} ;
         T000J4_n141SecUserName = new bool[] {false} ;
         T000J5_A140SecRoleName = new string[] {""} ;
         T000J5_A139SecRoleDescription = new string[] {""} ;
         T000J7_A141SecUserName = new string[] {""} ;
         T000J7_n141SecUserName = new bool[] {false} ;
         T000J8_A140SecRoleName = new string[] {""} ;
         T000J8_A139SecRoleDescription = new string[] {""} ;
         T000J9_A133SecUserId = new short[1] ;
         T000J9_A131SecRoleId = new short[1] ;
         T000J3_A647SecUserRoleActive = new bool[] {false} ;
         T000J3_A133SecUserId = new short[1] ;
         T000J3_A131SecRoleId = new short[1] ;
         sMode23 = "";
         T000J10_A133SecUserId = new short[1] ;
         T000J10_A131SecRoleId = new short[1] ;
         T000J11_A133SecUserId = new short[1] ;
         T000J11_A131SecRoleId = new short[1] ;
         T000J2_A647SecUserRoleActive = new bool[] {false} ;
         T000J2_A133SecUserId = new short[1] ;
         T000J2_A131SecRoleId = new short[1] ;
         T000J15_A141SecUserName = new string[] {""} ;
         T000J15_n141SecUserName = new bool[] {false} ;
         T000J16_A140SecRoleName = new string[] {""} ;
         T000J16_A139SecRoleDescription = new string[] {""} ;
         T000J17_A133SecUserId = new short[1] ;
         T000J17_A131SecRoleId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ141SecUserName = "";
         ZZ140SecRoleName = "";
         ZZ139SecRoleDescription = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secuserrole__default(),
            new Object[][] {
                new Object[] {
               T000J2_A647SecUserRoleActive, T000J2_A133SecUserId, T000J2_A131SecRoleId
               }
               , new Object[] {
               T000J3_A647SecUserRoleActive, T000J3_A133SecUserId, T000J3_A131SecRoleId
               }
               , new Object[] {
               T000J4_A141SecUserName, T000J4_n141SecUserName
               }
               , new Object[] {
               T000J5_A140SecRoleName, T000J5_A139SecRoleDescription
               }
               , new Object[] {
               T000J6_A141SecUserName, T000J6_n141SecUserName, T000J6_A140SecRoleName, T000J6_A139SecRoleDescription, T000J6_A647SecUserRoleActive, T000J6_A133SecUserId, T000J6_A131SecRoleId
               }
               , new Object[] {
               T000J7_A141SecUserName, T000J7_n141SecUserName
               }
               , new Object[] {
               T000J8_A140SecRoleName, T000J8_A139SecRoleDescription
               }
               , new Object[] {
               T000J9_A133SecUserId, T000J9_A131SecRoleId
               }
               , new Object[] {
               T000J10_A133SecUserId, T000J10_A131SecRoleId
               }
               , new Object[] {
               T000J11_A133SecUserId, T000J11_A131SecRoleId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000J15_A141SecUserName, T000J15_n141SecUserName
               }
               , new Object[] {
               T000J16_A140SecRoleName, T000J16_A139SecRoleDescription
               }
               , new Object[] {
               T000J17_A133SecUserId, T000J17_A131SecRoleId
               }
            }
         );
      }

      private short Z133SecUserId ;
      private short Z131SecRoleId ;
      private short GxWebError ;
      private short A133SecUserId ;
      private short A131SecRoleId ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound23 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ133SecUserId ;
      private short ZZ131SecRoleId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtSecUserId_Enabled ;
      private int edtSecRoleId_Enabled ;
      private int edtSecUserName_Enabled ;
      private int edtSecRoleName_Enabled ;
      private int edtSecRoleDescription_Enabled ;
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
      private string edtSecUserId_Internalname ;
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
      private string edtSecUserId_Jsonclick ;
      private string edtSecRoleId_Internalname ;
      private string edtSecRoleId_Jsonclick ;
      private string edtSecUserName_Internalname ;
      private string edtSecUserName_Jsonclick ;
      private string edtSecRoleName_Internalname ;
      private string edtSecRoleName_Jsonclick ;
      private string edtSecRoleDescription_Internalname ;
      private string edtSecRoleDescription_Jsonclick ;
      private string chkSecUserRoleActive_Internalname ;
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
      private string sMode23 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool Z647SecUserRoleActive ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A647SecUserRoleActive ;
      private bool n141SecUserName ;
      private bool ZZ647SecUserRoleActive ;
      private string A141SecUserName ;
      private string A140SecRoleName ;
      private string A139SecRoleDescription ;
      private string Z141SecUserName ;
      private string Z140SecRoleName ;
      private string Z139SecRoleDescription ;
      private string ZZ141SecUserName ;
      private string ZZ140SecRoleName ;
      private string ZZ139SecRoleDescription ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkSecUserRoleActive ;
      private IDataStoreProvider pr_default ;
      private string[] T000J6_A141SecUserName ;
      private bool[] T000J6_n141SecUserName ;
      private string[] T000J6_A140SecRoleName ;
      private string[] T000J6_A139SecRoleDescription ;
      private bool[] T000J6_A647SecUserRoleActive ;
      private short[] T000J6_A133SecUserId ;
      private short[] T000J6_A131SecRoleId ;
      private string[] T000J4_A141SecUserName ;
      private bool[] T000J4_n141SecUserName ;
      private string[] T000J5_A140SecRoleName ;
      private string[] T000J5_A139SecRoleDescription ;
      private string[] T000J7_A141SecUserName ;
      private bool[] T000J7_n141SecUserName ;
      private string[] T000J8_A140SecRoleName ;
      private string[] T000J8_A139SecRoleDescription ;
      private short[] T000J9_A133SecUserId ;
      private short[] T000J9_A131SecRoleId ;
      private bool[] T000J3_A647SecUserRoleActive ;
      private short[] T000J3_A133SecUserId ;
      private short[] T000J3_A131SecRoleId ;
      private short[] T000J10_A133SecUserId ;
      private short[] T000J10_A131SecRoleId ;
      private short[] T000J11_A133SecUserId ;
      private short[] T000J11_A131SecRoleId ;
      private bool[] T000J2_A647SecUserRoleActive ;
      private short[] T000J2_A133SecUserId ;
      private short[] T000J2_A131SecRoleId ;
      private string[] T000J15_A141SecUserName ;
      private bool[] T000J15_n141SecUserName ;
      private string[] T000J16_A140SecRoleName ;
      private string[] T000J16_A139SecRoleDescription ;
      private short[] T000J17_A133SecUserId ;
      private short[] T000J17_A131SecRoleId ;
   }

   public class secuserrole__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT000J2;
          prmT000J2 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0) ,
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmT000J3;
          prmT000J3 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0) ,
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmT000J4;
          prmT000J4 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0)
          };
          Object[] prmT000J5;
          prmT000J5 = new Object[] {
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmT000J6;
          prmT000J6 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0) ,
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmT000J7;
          prmT000J7 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0)
          };
          Object[] prmT000J8;
          prmT000J8 = new Object[] {
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmT000J9;
          prmT000J9 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0) ,
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmT000J10;
          prmT000J10 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0) ,
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmT000J11;
          prmT000J11 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0) ,
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmT000J12;
          prmT000J12 = new Object[] {
          new ParDef("SecUserRoleActive",GXType.Boolean,4,0) ,
          new ParDef("SecUserId",GXType.Int16,4,0) ,
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmT000J13;
          prmT000J13 = new Object[] {
          new ParDef("SecUserRoleActive",GXType.Boolean,4,0) ,
          new ParDef("SecUserId",GXType.Int16,4,0) ,
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmT000J14;
          prmT000J14 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0) ,
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmT000J15;
          prmT000J15 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0)
          };
          Object[] prmT000J16;
          prmT000J16 = new Object[] {
          new ParDef("SecRoleId",GXType.Int16,4,0)
          };
          Object[] prmT000J17;
          prmT000J17 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T000J2", "SELECT SecUserRoleActive, SecUserId, SecRoleId FROM SecUserRole WHERE SecUserId = :SecUserId AND SecRoleId = :SecRoleId  FOR UPDATE OF SecUserRole NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000J2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000J3", "SELECT SecUserRoleActive, SecUserId, SecRoleId FROM SecUserRole WHERE SecUserId = :SecUserId AND SecRoleId = :SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000J4", "SELECT SecUserName FROM SecUser WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000J5", "SELECT SecRoleName, SecRoleDescription FROM SecRole WHERE SecRoleId = :SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000J6", "SELECT T2.SecUserName, T3.SecRoleName, T3.SecRoleDescription, TM1.SecUserRoleActive, TM1.SecUserId, TM1.SecRoleId FROM ((SecUserRole TM1 INNER JOIN SecUser T2 ON T2.SecUserId = TM1.SecUserId) INNER JOIN SecRole T3 ON T3.SecRoleId = TM1.SecRoleId) WHERE TM1.SecUserId = :SecUserId and TM1.SecRoleId = :SecRoleId ORDER BY TM1.SecUserId, TM1.SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000J7", "SELECT SecUserName FROM SecUser WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000J8", "SELECT SecRoleName, SecRoleDescription FROM SecRole WHERE SecRoleId = :SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000J9", "SELECT SecUserId, SecRoleId FROM SecUserRole WHERE SecUserId = :SecUserId AND SecRoleId = :SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000J10", "SELECT SecUserId, SecRoleId FROM SecUserRole WHERE ( SecUserId > :SecUserId or SecUserId = :SecUserId and SecRoleId > :SecRoleId) ORDER BY SecUserId, SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000J11", "SELECT SecUserId, SecRoleId FROM SecUserRole WHERE ( SecUserId < :SecUserId or SecUserId = :SecUserId and SecRoleId < :SecRoleId) ORDER BY SecUserId DESC, SecRoleId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000J12", "SAVEPOINT gxupdate;INSERT INTO SecUserRole(SecUserRoleActive, SecUserId, SecRoleId) VALUES(:SecUserRoleActive, :SecUserId, :SecRoleId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000J12)
             ,new CursorDef("T000J13", "SAVEPOINT gxupdate;UPDATE SecUserRole SET SecUserRoleActive=:SecUserRoleActive  WHERE SecUserId = :SecUserId AND SecRoleId = :SecRoleId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000J13)
             ,new CursorDef("T000J14", "SAVEPOINT gxupdate;DELETE FROM SecUserRole  WHERE SecUserId = :SecUserId AND SecRoleId = :SecRoleId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000J14)
             ,new CursorDef("T000J15", "SELECT SecUserName FROM SecUser WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000J16", "SELECT SecRoleName, SecRoleDescription FROM SecRole WHERE SecRoleId = :SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000J17", "SELECT SecUserId, SecRoleId FROM SecUserRole ORDER BY SecUserId, SecRoleId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J17,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 1 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.getBool(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
