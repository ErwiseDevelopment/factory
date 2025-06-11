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
   public class reembolsopassos : GXDataArea
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
         Form.Meta.addItem("description", "Reembolso Passos", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtReembolsoPassos_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public reembolsopassos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public reembolsopassos( IGxContext context )
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
         chkReembolsoPassosStatus = new GXCheckbox();
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
         A740ReembolsoPassosStatus = StringUtil.StrToBool( StringUtil.BoolToStr( A740ReembolsoPassosStatus));
         n740ReembolsoPassosStatus = false;
         AssignAttri("", false, "A740ReembolsoPassosStatus", A740ReembolsoPassosStatus);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Reembolso Passos", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_ReembolsoPassos.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoPassos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoPassos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoPassos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoPassos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_ReembolsoPassos.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReembolsoPassos_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoPassos_Internalname, "Passos", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReembolsoPassos_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A738ReembolsoPassos), 4, 0, ",", "")), StringUtil.LTrim( ((edtReembolsoPassos_Enabled!=0) ? context.localUtil.Format( (decimal)(A738ReembolsoPassos), "ZZZ9") : context.localUtil.Format( (decimal)(A738ReembolsoPassos), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoPassos_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReembolsoPassos_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ReembolsoPassos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReembolsoPassosNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoPassosNome_Internalname, "Nome", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReembolsoPassosNome_Internalname, A739ReembolsoPassosNome, StringUtil.RTrim( context.localUtil.Format( A739ReembolsoPassosNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoPassosNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReembolsoPassosNome_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ReembolsoPassos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkReembolsoPassosStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkReembolsoPassosStatus_Internalname, "Status", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkReembolsoPassosStatus_Internalname, StringUtil.BoolToStr( A740ReembolsoPassosStatus), "", "Status", 1, chkReembolsoPassosStatus.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(44, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,44);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReembolsoPassosSLALembrete_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoPassosSLALembrete_Internalname, "SLA Dashboard", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReembolsoPassosSLALembrete_Internalname, ((0==A741ReembolsoPassosSLALembrete)&&IsIns( )||n741ReembolsoPassosSLALembrete ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A741ReembolsoPassosSLALembrete), 4, 0, ",", ""))), ((0==A741ReembolsoPassosSLALembrete)&&IsIns( )||n741ReembolsoPassosSLALembrete ? "" : StringUtil.LTrim( ((edtReembolsoPassosSLALembrete_Enabled!=0) ? context.localUtil.Format( (decimal)(A741ReembolsoPassosSLALembrete), "ZZZ9") : context.localUtil.Format( (decimal)(A741ReembolsoPassosSLALembrete), "ZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoPassosSLALembrete_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReembolsoPassosSLALembrete_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ReembolsoPassos.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoPassos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoPassos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoPassos.htm");
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
            Z738ReembolsoPassos = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z738ReembolsoPassos"), ",", "."), 18, MidpointRounding.ToEven));
            Z739ReembolsoPassosNome = cgiGet( "Z739ReembolsoPassosNome");
            n739ReembolsoPassosNome = (String.IsNullOrEmpty(StringUtil.RTrim( A739ReembolsoPassosNome)) ? true : false);
            Z740ReembolsoPassosStatus = StringUtil.StrToBool( cgiGet( "Z740ReembolsoPassosStatus"));
            n740ReembolsoPassosStatus = ((false==A740ReembolsoPassosStatus) ? true : false);
            Z741ReembolsoPassosSLALembrete = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z741ReembolsoPassosSLALembrete"), ",", "."), 18, MidpointRounding.ToEven));
            n741ReembolsoPassosSLALembrete = ((0==A741ReembolsoPassosSLALembrete) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtReembolsoPassos_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtReembolsoPassos_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REEMBOLSOPASSOS");
               AnyError = 1;
               GX_FocusControl = edtReembolsoPassos_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A738ReembolsoPassos = 0;
               AssignAttri("", false, "A738ReembolsoPassos", StringUtil.LTrimStr( (decimal)(A738ReembolsoPassos), 4, 0));
            }
            else
            {
               A738ReembolsoPassos = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtReembolsoPassos_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A738ReembolsoPassos", StringUtil.LTrimStr( (decimal)(A738ReembolsoPassos), 4, 0));
            }
            A739ReembolsoPassosNome = cgiGet( edtReembolsoPassosNome_Internalname);
            n739ReembolsoPassosNome = false;
            AssignAttri("", false, "A739ReembolsoPassosNome", A739ReembolsoPassosNome);
            n739ReembolsoPassosNome = (String.IsNullOrEmpty(StringUtil.RTrim( A739ReembolsoPassosNome)) ? true : false);
            A740ReembolsoPassosStatus = StringUtil.StrToBool( cgiGet( chkReembolsoPassosStatus_Internalname));
            n740ReembolsoPassosStatus = false;
            AssignAttri("", false, "A740ReembolsoPassosStatus", A740ReembolsoPassosStatus);
            n740ReembolsoPassosStatus = ((false==A740ReembolsoPassosStatus) ? true : false);
            n741ReembolsoPassosSLALembrete = ((StringUtil.StrCmp(cgiGet( edtReembolsoPassosSLALembrete_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtReembolsoPassosSLALembrete_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtReembolsoPassosSLALembrete_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REEMBOLSOPASSOSSLALEMBRETE");
               AnyError = 1;
               GX_FocusControl = edtReembolsoPassosSLALembrete_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A741ReembolsoPassosSLALembrete = 0;
               n741ReembolsoPassosSLALembrete = false;
               AssignAttri("", false, "A741ReembolsoPassosSLALembrete", (n741ReembolsoPassosSLALembrete ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A741ReembolsoPassosSLALembrete), 4, 0, ".", ""))));
            }
            else
            {
               A741ReembolsoPassosSLALembrete = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtReembolsoPassosSLALembrete_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A741ReembolsoPassosSLALembrete", (n741ReembolsoPassosSLALembrete ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A741ReembolsoPassosSLALembrete), 4, 0, ".", ""))));
            }
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
               A738ReembolsoPassos = (short)(Math.Round(NumberUtil.Val( GetPar( "ReembolsoPassos"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A738ReembolsoPassos", StringUtil.LTrimStr( (decimal)(A738ReembolsoPassos), 4, 0));
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
               InitAll2L90( ) ;
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
         DisableAttributes2L90( ) ;
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

      protected void ResetCaption2L0( )
      {
      }

      protected void ZM2L90( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z739ReembolsoPassosNome = T002L3_A739ReembolsoPassosNome[0];
               Z740ReembolsoPassosStatus = T002L3_A740ReembolsoPassosStatus[0];
               Z741ReembolsoPassosSLALembrete = T002L3_A741ReembolsoPassosSLALembrete[0];
            }
            else
            {
               Z739ReembolsoPassosNome = A739ReembolsoPassosNome;
               Z740ReembolsoPassosStatus = A740ReembolsoPassosStatus;
               Z741ReembolsoPassosSLALembrete = A741ReembolsoPassosSLALembrete;
            }
         }
         if ( GX_JID == -1 )
         {
            Z738ReembolsoPassos = A738ReembolsoPassos;
            Z739ReembolsoPassosNome = A739ReembolsoPassosNome;
            Z740ReembolsoPassosStatus = A740ReembolsoPassosStatus;
            Z741ReembolsoPassosSLALembrete = A741ReembolsoPassosSLALembrete;
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

      protected void Load2L90( )
      {
         /* Using cursor T002L4 */
         pr_default.execute(2, new Object[] {A738ReembolsoPassos});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound90 = 1;
            A739ReembolsoPassosNome = T002L4_A739ReembolsoPassosNome[0];
            n739ReembolsoPassosNome = T002L4_n739ReembolsoPassosNome[0];
            AssignAttri("", false, "A739ReembolsoPassosNome", A739ReembolsoPassosNome);
            A740ReembolsoPassosStatus = T002L4_A740ReembolsoPassosStatus[0];
            n740ReembolsoPassosStatus = T002L4_n740ReembolsoPassosStatus[0];
            AssignAttri("", false, "A740ReembolsoPassosStatus", A740ReembolsoPassosStatus);
            A741ReembolsoPassosSLALembrete = T002L4_A741ReembolsoPassosSLALembrete[0];
            n741ReembolsoPassosSLALembrete = T002L4_n741ReembolsoPassosSLALembrete[0];
            AssignAttri("", false, "A741ReembolsoPassosSLALembrete", ((0==A741ReembolsoPassosSLALembrete)&&IsIns( )||n741ReembolsoPassosSLALembrete ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A741ReembolsoPassosSLALembrete), 4, 0, ".", ""))));
            ZM2L90( -1) ;
         }
         pr_default.close(2);
         OnLoadActions2L90( ) ;
      }

      protected void OnLoadActions2L90( )
      {
      }

      protected void CheckExtendedTable2L90( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors2L90( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2L90( )
      {
         /* Using cursor T002L5 */
         pr_default.execute(3, new Object[] {A738ReembolsoPassos});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound90 = 1;
         }
         else
         {
            RcdFound90 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002L3 */
         pr_default.execute(1, new Object[] {A738ReembolsoPassos});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2L90( 1) ;
            RcdFound90 = 1;
            A738ReembolsoPassos = T002L3_A738ReembolsoPassos[0];
            AssignAttri("", false, "A738ReembolsoPassos", StringUtil.LTrimStr( (decimal)(A738ReembolsoPassos), 4, 0));
            A739ReembolsoPassosNome = T002L3_A739ReembolsoPassosNome[0];
            n739ReembolsoPassosNome = T002L3_n739ReembolsoPassosNome[0];
            AssignAttri("", false, "A739ReembolsoPassosNome", A739ReembolsoPassosNome);
            A740ReembolsoPassosStatus = T002L3_A740ReembolsoPassosStatus[0];
            n740ReembolsoPassosStatus = T002L3_n740ReembolsoPassosStatus[0];
            AssignAttri("", false, "A740ReembolsoPassosStatus", A740ReembolsoPassosStatus);
            A741ReembolsoPassosSLALembrete = T002L3_A741ReembolsoPassosSLALembrete[0];
            n741ReembolsoPassosSLALembrete = T002L3_n741ReembolsoPassosSLALembrete[0];
            AssignAttri("", false, "A741ReembolsoPassosSLALembrete", ((0==A741ReembolsoPassosSLALembrete)&&IsIns( )||n741ReembolsoPassosSLALembrete ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A741ReembolsoPassosSLALembrete), 4, 0, ".", ""))));
            Z738ReembolsoPassos = A738ReembolsoPassos;
            sMode90 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2L90( ) ;
            if ( AnyError == 1 )
            {
               RcdFound90 = 0;
               InitializeNonKey2L90( ) ;
            }
            Gx_mode = sMode90;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound90 = 0;
            InitializeNonKey2L90( ) ;
            sMode90 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode90;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2L90( ) ;
         if ( RcdFound90 == 0 )
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
         RcdFound90 = 0;
         /* Using cursor T002L6 */
         pr_default.execute(4, new Object[] {A738ReembolsoPassos});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T002L6_A738ReembolsoPassos[0] < A738ReembolsoPassos ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T002L6_A738ReembolsoPassos[0] > A738ReembolsoPassos ) ) )
            {
               A738ReembolsoPassos = T002L6_A738ReembolsoPassos[0];
               AssignAttri("", false, "A738ReembolsoPassos", StringUtil.LTrimStr( (decimal)(A738ReembolsoPassos), 4, 0));
               RcdFound90 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound90 = 0;
         /* Using cursor T002L7 */
         pr_default.execute(5, new Object[] {A738ReembolsoPassos});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T002L7_A738ReembolsoPassos[0] > A738ReembolsoPassos ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T002L7_A738ReembolsoPassos[0] < A738ReembolsoPassos ) ) )
            {
               A738ReembolsoPassos = T002L7_A738ReembolsoPassos[0];
               AssignAttri("", false, "A738ReembolsoPassos", StringUtil.LTrimStr( (decimal)(A738ReembolsoPassos), 4, 0));
               RcdFound90 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2L90( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtReembolsoPassos_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2L90( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound90 == 1 )
            {
               if ( A738ReembolsoPassos != Z738ReembolsoPassos )
               {
                  A738ReembolsoPassos = Z738ReembolsoPassos;
                  AssignAttri("", false, "A738ReembolsoPassos", StringUtil.LTrimStr( (decimal)(A738ReembolsoPassos), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "REEMBOLSOPASSOS");
                  AnyError = 1;
                  GX_FocusControl = edtReembolsoPassos_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtReembolsoPassos_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2L90( ) ;
                  GX_FocusControl = edtReembolsoPassos_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A738ReembolsoPassos != Z738ReembolsoPassos )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtReembolsoPassos_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2L90( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "REEMBOLSOPASSOS");
                     AnyError = 1;
                     GX_FocusControl = edtReembolsoPassos_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtReembolsoPassos_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2L90( ) ;
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
         if ( A738ReembolsoPassos != Z738ReembolsoPassos )
         {
            A738ReembolsoPassos = Z738ReembolsoPassos;
            AssignAttri("", false, "A738ReembolsoPassos", StringUtil.LTrimStr( (decimal)(A738ReembolsoPassos), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "REEMBOLSOPASSOS");
            AnyError = 1;
            GX_FocusControl = edtReembolsoPassos_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtReembolsoPassos_Internalname;
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
         if ( RcdFound90 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "REEMBOLSOPASSOS");
            AnyError = 1;
            GX_FocusControl = edtReembolsoPassos_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtReembolsoPassosNome_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2L90( ) ;
         if ( RcdFound90 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtReembolsoPassosNome_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2L90( ) ;
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
         if ( RcdFound90 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtReembolsoPassosNome_Internalname;
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
         if ( RcdFound90 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtReembolsoPassosNome_Internalname;
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
         ScanStart2L90( ) ;
         if ( RcdFound90 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound90 != 0 )
            {
               ScanNext2L90( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtReembolsoPassosNome_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2L90( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2L90( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002L2 */
            pr_default.execute(0, new Object[] {A738ReembolsoPassos});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ReembolsoPassos"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z739ReembolsoPassosNome, T002L2_A739ReembolsoPassosNome[0]) != 0 ) || ( Z740ReembolsoPassosStatus != T002L2_A740ReembolsoPassosStatus[0] ) || ( Z741ReembolsoPassosSLALembrete != T002L2_A741ReembolsoPassosSLALembrete[0] ) )
            {
               if ( StringUtil.StrCmp(Z739ReembolsoPassosNome, T002L2_A739ReembolsoPassosNome[0]) != 0 )
               {
                  GXUtil.WriteLog("reembolsopassos:[seudo value changed for attri]"+"ReembolsoPassosNome");
                  GXUtil.WriteLogRaw("Old: ",Z739ReembolsoPassosNome);
                  GXUtil.WriteLogRaw("Current: ",T002L2_A739ReembolsoPassosNome[0]);
               }
               if ( Z740ReembolsoPassosStatus != T002L2_A740ReembolsoPassosStatus[0] )
               {
                  GXUtil.WriteLog("reembolsopassos:[seudo value changed for attri]"+"ReembolsoPassosStatus");
                  GXUtil.WriteLogRaw("Old: ",Z740ReembolsoPassosStatus);
                  GXUtil.WriteLogRaw("Current: ",T002L2_A740ReembolsoPassosStatus[0]);
               }
               if ( Z741ReembolsoPassosSLALembrete != T002L2_A741ReembolsoPassosSLALembrete[0] )
               {
                  GXUtil.WriteLog("reembolsopassos:[seudo value changed for attri]"+"ReembolsoPassosSLALembrete");
                  GXUtil.WriteLogRaw("Old: ",Z741ReembolsoPassosSLALembrete);
                  GXUtil.WriteLogRaw("Current: ",T002L2_A741ReembolsoPassosSLALembrete[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ReembolsoPassos"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2L90( )
      {
         BeforeValidate2L90( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2L90( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2L90( 0) ;
            CheckOptimisticConcurrency2L90( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2L90( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2L90( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002L8 */
                     pr_default.execute(6, new Object[] {A738ReembolsoPassos, n739ReembolsoPassosNome, A739ReembolsoPassosNome, n740ReembolsoPassosStatus, A740ReembolsoPassosStatus, n741ReembolsoPassosSLALembrete, A741ReembolsoPassosSLALembrete});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("ReembolsoPassos");
                     if ( (pr_default.getStatus(6) == 1) )
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
                           ResetCaption2L0( ) ;
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
               Load2L90( ) ;
            }
            EndLevel2L90( ) ;
         }
         CloseExtendedTableCursors2L90( ) ;
      }

      protected void Update2L90( )
      {
         BeforeValidate2L90( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2L90( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2L90( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2L90( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2L90( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002L9 */
                     pr_default.execute(7, new Object[] {n739ReembolsoPassosNome, A739ReembolsoPassosNome, n740ReembolsoPassosStatus, A740ReembolsoPassosStatus, n741ReembolsoPassosSLALembrete, A741ReembolsoPassosSLALembrete, A738ReembolsoPassos});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("ReembolsoPassos");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ReembolsoPassos"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2L90( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2L0( ) ;
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
            EndLevel2L90( ) ;
         }
         CloseExtendedTableCursors2L90( ) ;
      }

      protected void DeferredUpdate2L90( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2L90( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2L90( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2L90( ) ;
            AfterConfirm2L90( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2L90( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002L10 */
                  pr_default.execute(8, new Object[] {A738ReembolsoPassos});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("ReembolsoPassos");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound90 == 0 )
                        {
                           InitAll2L90( ) ;
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
                        ResetCaption2L0( ) ;
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
         sMode90 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2L90( ) ;
         Gx_mode = sMode90;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2L90( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2L90( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2L90( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues2L0( ) ;
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

      public void ScanStart2L90( )
      {
         /* Using cursor T002L11 */
         pr_default.execute(9);
         RcdFound90 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound90 = 1;
            A738ReembolsoPassos = T002L11_A738ReembolsoPassos[0];
            AssignAttri("", false, "A738ReembolsoPassos", StringUtil.LTrimStr( (decimal)(A738ReembolsoPassos), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2L90( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound90 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound90 = 1;
            A738ReembolsoPassos = T002L11_A738ReembolsoPassos[0];
            AssignAttri("", false, "A738ReembolsoPassos", StringUtil.LTrimStr( (decimal)(A738ReembolsoPassos), 4, 0));
         }
      }

      protected void ScanEnd2L90( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm2L90( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2L90( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2L90( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2L90( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2L90( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2L90( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2L90( )
      {
         edtReembolsoPassos_Enabled = 0;
         AssignProp("", false, edtReembolsoPassos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoPassos_Enabled), 5, 0), true);
         edtReembolsoPassosNome_Enabled = 0;
         AssignProp("", false, edtReembolsoPassosNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoPassosNome_Enabled), 5, 0), true);
         chkReembolsoPassosStatus.Enabled = 0;
         AssignProp("", false, chkReembolsoPassosStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkReembolsoPassosStatus.Enabled), 5, 0), true);
         edtReembolsoPassosSLALembrete_Enabled = 0;
         AssignProp("", false, edtReembolsoPassosSLALembrete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoPassosSLALembrete_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2L90( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2L0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("reembolsopassos") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z738ReembolsoPassos", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z738ReembolsoPassos), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z739ReembolsoPassosNome", Z739ReembolsoPassosNome);
         GxWebStd.gx_boolean_hidden_field( context, "Z740ReembolsoPassosStatus", Z740ReembolsoPassosStatus);
         GxWebStd.gx_hidden_field( context, "Z741ReembolsoPassosSLALembrete", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z741ReembolsoPassosSLALembrete), 4, 0, ",", "")));
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
         return formatLink("reembolsopassos")  ;
      }

      public override string GetPgmname( )
      {
         return "ReembolsoPassos" ;
      }

      public override string GetPgmdesc( )
      {
         return "Reembolso Passos" ;
      }

      protected void InitializeNonKey2L90( )
      {
         A739ReembolsoPassosNome = "";
         n739ReembolsoPassosNome = false;
         AssignAttri("", false, "A739ReembolsoPassosNome", A739ReembolsoPassosNome);
         n739ReembolsoPassosNome = (String.IsNullOrEmpty(StringUtil.RTrim( A739ReembolsoPassosNome)) ? true : false);
         A740ReembolsoPassosStatus = false;
         n740ReembolsoPassosStatus = false;
         AssignAttri("", false, "A740ReembolsoPassosStatus", A740ReembolsoPassosStatus);
         n740ReembolsoPassosStatus = ((false==A740ReembolsoPassosStatus) ? true : false);
         A741ReembolsoPassosSLALembrete = 0;
         n741ReembolsoPassosSLALembrete = false;
         AssignAttri("", false, "A741ReembolsoPassosSLALembrete", ((0==A741ReembolsoPassosSLALembrete)&&IsIns( )||n741ReembolsoPassosSLALembrete ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A741ReembolsoPassosSLALembrete), 4, 0, ".", ""))));
         n741ReembolsoPassosSLALembrete = ((0==A741ReembolsoPassosSLALembrete) ? true : false);
         Z739ReembolsoPassosNome = "";
         Z740ReembolsoPassosStatus = false;
         Z741ReembolsoPassosSLALembrete = 0;
      }

      protected void InitAll2L90( )
      {
         A738ReembolsoPassos = 0;
         AssignAttri("", false, "A738ReembolsoPassos", StringUtil.LTrimStr( (decimal)(A738ReembolsoPassos), 4, 0));
         InitializeNonKey2L90( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019204231", true, true);
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
         context.AddJavascriptSource("reembolsopassos.js", "?202561019204232", false, true);
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
         edtReembolsoPassos_Internalname = "REEMBOLSOPASSOS";
         edtReembolsoPassosNome_Internalname = "REEMBOLSOPASSOSNOME";
         chkReembolsoPassosStatus_Internalname = "REEMBOLSOPASSOSSTATUS";
         edtReembolsoPassosSLALembrete_Internalname = "REEMBOLSOPASSOSSLALEMBRETE";
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
         Form.Caption = "Reembolso Passos";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtReembolsoPassosSLALembrete_Jsonclick = "";
         edtReembolsoPassosSLALembrete_Enabled = 1;
         chkReembolsoPassosStatus.Enabled = 1;
         edtReembolsoPassosNome_Jsonclick = "";
         edtReembolsoPassosNome_Enabled = 1;
         edtReembolsoPassos_Jsonclick = "";
         edtReembolsoPassos_Enabled = 1;
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
         chkReembolsoPassosStatus.Name = "REEMBOLSOPASSOSSTATUS";
         chkReembolsoPassosStatus.WebTags = "";
         chkReembolsoPassosStatus.Caption = "Status";
         AssignProp("", false, chkReembolsoPassosStatus_Internalname, "TitleCaption", chkReembolsoPassosStatus.Caption, true);
         chkReembolsoPassosStatus.CheckedValue = "false";
         A740ReembolsoPassosStatus = StringUtil.StrToBool( StringUtil.BoolToStr( A740ReembolsoPassosStatus));
         n740ReembolsoPassosStatus = false;
         AssignAttri("", false, "A740ReembolsoPassosStatus", A740ReembolsoPassosStatus);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtReembolsoPassosNome_Internalname;
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

      public void Valid_Reembolsopassos( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A740ReembolsoPassosStatus = StringUtil.StrToBool( StringUtil.BoolToStr( A740ReembolsoPassosStatus));
         n740ReembolsoPassosStatus = false;
         /*  Sending validation outputs */
         AssignAttri("", false, "A739ReembolsoPassosNome", A739ReembolsoPassosNome);
         AssignAttri("", false, "A740ReembolsoPassosStatus", A740ReembolsoPassosStatus);
         AssignAttri("", false, "A741ReembolsoPassosSLALembrete", ((0==A741ReembolsoPassosSLALembrete)&&IsIns( )||n741ReembolsoPassosSLALembrete ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A741ReembolsoPassosSLALembrete), 4, 0, ".", ""))));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z738ReembolsoPassos", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z738ReembolsoPassos), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z739ReembolsoPassosNome", Z739ReembolsoPassosNome);
         GxWebStd.gx_hidden_field( context, "Z740ReembolsoPassosStatus", StringUtil.BoolToStr( Z740ReembolsoPassosStatus));
         GxWebStd.gx_hidden_field( context, "Z741ReembolsoPassosSLALembrete", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z741ReembolsoPassosSLALembrete), 4, 0, ".", "")));
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"A740ReembolsoPassosStatus","fld":"REEMBOLSOPASSOSSTATUS","type":"boolean"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A740ReembolsoPassosStatus","fld":"REEMBOLSOPASSOSSTATUS","type":"boolean"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A740ReembolsoPassosStatus","fld":"REEMBOLSOPASSOSSTATUS","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A740ReembolsoPassosStatus","fld":"REEMBOLSOPASSOSSTATUS","type":"boolean"}]}""");
         setEventMetadata("VALID_REEMBOLSOPASSOS","""{"handler":"Valid_Reembolsopassos","iparms":[{"av":"A738ReembolsoPassos","fld":"REEMBOLSOPASSOS","pic":"ZZZ9","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"A740ReembolsoPassosStatus","fld":"REEMBOLSOPASSOSSTATUS","type":"boolean"}]""");
         setEventMetadata("VALID_REEMBOLSOPASSOS",""","oparms":[{"av":"A739ReembolsoPassosNome","fld":"REEMBOLSOPASSOSNOME","type":"svchar"},{"av":"A741ReembolsoPassosSLALembrete","fld":"REEMBOLSOPASSOSSLALEMBRETE","pic":"ZZZ9","nullAv":"n741ReembolsoPassosSLALembrete","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"Z738ReembolsoPassos","type":"int"},{"av":"Z739ReembolsoPassosNome","type":"svchar"},{"av":"Z740ReembolsoPassosStatus","type":"boolean"},{"av":"Z741ReembolsoPassosSLALembrete","type":"int"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"},{"av":"A740ReembolsoPassosStatus","fld":"REEMBOLSOPASSOSSTATUS","type":"boolean"}]}""");
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
         Z739ReembolsoPassosNome = "";
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
         A739ReembolsoPassosNome = "";
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
         T002L4_A738ReembolsoPassos = new short[1] ;
         T002L4_A739ReembolsoPassosNome = new string[] {""} ;
         T002L4_n739ReembolsoPassosNome = new bool[] {false} ;
         T002L4_A740ReembolsoPassosStatus = new bool[] {false} ;
         T002L4_n740ReembolsoPassosStatus = new bool[] {false} ;
         T002L4_A741ReembolsoPassosSLALembrete = new short[1] ;
         T002L4_n741ReembolsoPassosSLALembrete = new bool[] {false} ;
         T002L5_A738ReembolsoPassos = new short[1] ;
         T002L3_A738ReembolsoPassos = new short[1] ;
         T002L3_A739ReembolsoPassosNome = new string[] {""} ;
         T002L3_n739ReembolsoPassosNome = new bool[] {false} ;
         T002L3_A740ReembolsoPassosStatus = new bool[] {false} ;
         T002L3_n740ReembolsoPassosStatus = new bool[] {false} ;
         T002L3_A741ReembolsoPassosSLALembrete = new short[1] ;
         T002L3_n741ReembolsoPassosSLALembrete = new bool[] {false} ;
         sMode90 = "";
         T002L6_A738ReembolsoPassos = new short[1] ;
         T002L7_A738ReembolsoPassos = new short[1] ;
         T002L2_A738ReembolsoPassos = new short[1] ;
         T002L2_A739ReembolsoPassosNome = new string[] {""} ;
         T002L2_n739ReembolsoPassosNome = new bool[] {false} ;
         T002L2_A740ReembolsoPassosStatus = new bool[] {false} ;
         T002L2_n740ReembolsoPassosStatus = new bool[] {false} ;
         T002L2_A741ReembolsoPassosSLALembrete = new short[1] ;
         T002L2_n741ReembolsoPassosSLALembrete = new bool[] {false} ;
         T002L11_A738ReembolsoPassos = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ739ReembolsoPassosNome = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reembolsopassos__default(),
            new Object[][] {
                new Object[] {
               T002L2_A738ReembolsoPassos, T002L2_A739ReembolsoPassosNome, T002L2_n739ReembolsoPassosNome, T002L2_A740ReembolsoPassosStatus, T002L2_n740ReembolsoPassosStatus, T002L2_A741ReembolsoPassosSLALembrete, T002L2_n741ReembolsoPassosSLALembrete
               }
               , new Object[] {
               T002L3_A738ReembolsoPassos, T002L3_A739ReembolsoPassosNome, T002L3_n739ReembolsoPassosNome, T002L3_A740ReembolsoPassosStatus, T002L3_n740ReembolsoPassosStatus, T002L3_A741ReembolsoPassosSLALembrete, T002L3_n741ReembolsoPassosSLALembrete
               }
               , new Object[] {
               T002L4_A738ReembolsoPassos, T002L4_A739ReembolsoPassosNome, T002L4_n739ReembolsoPassosNome, T002L4_A740ReembolsoPassosStatus, T002L4_n740ReembolsoPassosStatus, T002L4_A741ReembolsoPassosSLALembrete, T002L4_n741ReembolsoPassosSLALembrete
               }
               , new Object[] {
               T002L5_A738ReembolsoPassos
               }
               , new Object[] {
               T002L6_A738ReembolsoPassos
               }
               , new Object[] {
               T002L7_A738ReembolsoPassos
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002L11_A738ReembolsoPassos
               }
            }
         );
      }

      private short Z738ReembolsoPassos ;
      private short Z741ReembolsoPassosSLALembrete ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A738ReembolsoPassos ;
      private short A741ReembolsoPassosSLALembrete ;
      private short RcdFound90 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ738ReembolsoPassos ;
      private short ZZ741ReembolsoPassosSLALembrete ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtReembolsoPassos_Enabled ;
      private int edtReembolsoPassosNome_Enabled ;
      private int edtReembolsoPassosSLALembrete_Enabled ;
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
      private string edtReembolsoPassos_Internalname ;
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
      private string edtReembolsoPassos_Jsonclick ;
      private string edtReembolsoPassosNome_Internalname ;
      private string edtReembolsoPassosNome_Jsonclick ;
      private string chkReembolsoPassosStatus_Internalname ;
      private string edtReembolsoPassosSLALembrete_Internalname ;
      private string edtReembolsoPassosSLALembrete_Jsonclick ;
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
      private string sMode90 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool Z740ReembolsoPassosStatus ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A740ReembolsoPassosStatus ;
      private bool n740ReembolsoPassosStatus ;
      private bool n741ReembolsoPassosSLALembrete ;
      private bool n739ReembolsoPassosNome ;
      private bool ZZ740ReembolsoPassosStatus ;
      private string Z739ReembolsoPassosNome ;
      private string A739ReembolsoPassosNome ;
      private string ZZ739ReembolsoPassosNome ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkReembolsoPassosStatus ;
      private IDataStoreProvider pr_default ;
      private short[] T002L4_A738ReembolsoPassos ;
      private string[] T002L4_A739ReembolsoPassosNome ;
      private bool[] T002L4_n739ReembolsoPassosNome ;
      private bool[] T002L4_A740ReembolsoPassosStatus ;
      private bool[] T002L4_n740ReembolsoPassosStatus ;
      private short[] T002L4_A741ReembolsoPassosSLALembrete ;
      private bool[] T002L4_n741ReembolsoPassosSLALembrete ;
      private short[] T002L5_A738ReembolsoPassos ;
      private short[] T002L3_A738ReembolsoPassos ;
      private string[] T002L3_A739ReembolsoPassosNome ;
      private bool[] T002L3_n739ReembolsoPassosNome ;
      private bool[] T002L3_A740ReembolsoPassosStatus ;
      private bool[] T002L3_n740ReembolsoPassosStatus ;
      private short[] T002L3_A741ReembolsoPassosSLALembrete ;
      private bool[] T002L3_n741ReembolsoPassosSLALembrete ;
      private short[] T002L6_A738ReembolsoPassos ;
      private short[] T002L7_A738ReembolsoPassos ;
      private short[] T002L2_A738ReembolsoPassos ;
      private string[] T002L2_A739ReembolsoPassosNome ;
      private bool[] T002L2_n739ReembolsoPassosNome ;
      private bool[] T002L2_A740ReembolsoPassosStatus ;
      private bool[] T002L2_n740ReembolsoPassosStatus ;
      private short[] T002L2_A741ReembolsoPassosSLALembrete ;
      private bool[] T002L2_n741ReembolsoPassosSLALembrete ;
      private short[] T002L11_A738ReembolsoPassos ;
   }

   public class reembolsopassos__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT002L2;
          prmT002L2 = new Object[] {
          new ParDef("ReembolsoPassos",GXType.Int16,4,0)
          };
          Object[] prmT002L3;
          prmT002L3 = new Object[] {
          new ParDef("ReembolsoPassos",GXType.Int16,4,0)
          };
          Object[] prmT002L4;
          prmT002L4 = new Object[] {
          new ParDef("ReembolsoPassos",GXType.Int16,4,0)
          };
          Object[] prmT002L5;
          prmT002L5 = new Object[] {
          new ParDef("ReembolsoPassos",GXType.Int16,4,0)
          };
          Object[] prmT002L6;
          prmT002L6 = new Object[] {
          new ParDef("ReembolsoPassos",GXType.Int16,4,0)
          };
          Object[] prmT002L7;
          prmT002L7 = new Object[] {
          new ParDef("ReembolsoPassos",GXType.Int16,4,0)
          };
          Object[] prmT002L8;
          prmT002L8 = new Object[] {
          new ParDef("ReembolsoPassos",GXType.Int16,4,0) ,
          new ParDef("ReembolsoPassosNome",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("ReembolsoPassosStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ReembolsoPassosSLALembrete",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT002L9;
          prmT002L9 = new Object[] {
          new ParDef("ReembolsoPassosNome",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("ReembolsoPassosStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ReembolsoPassosSLALembrete",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ReembolsoPassos",GXType.Int16,4,0)
          };
          Object[] prmT002L10;
          prmT002L10 = new Object[] {
          new ParDef("ReembolsoPassos",GXType.Int16,4,0)
          };
          Object[] prmT002L11;
          prmT002L11 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T002L2", "SELECT ReembolsoPassos, ReembolsoPassosNome, ReembolsoPassosStatus, ReembolsoPassosSLALembrete FROM ReembolsoPassos WHERE ReembolsoPassos = :ReembolsoPassos  FOR UPDATE OF ReembolsoPassos NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT002L2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002L3", "SELECT ReembolsoPassos, ReembolsoPassosNome, ReembolsoPassosStatus, ReembolsoPassosSLALembrete FROM ReembolsoPassos WHERE ReembolsoPassos = :ReembolsoPassos ",true, GxErrorMask.GX_NOMASK, false, this,prmT002L3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002L4", "SELECT TM1.ReembolsoPassos, TM1.ReembolsoPassosNome, TM1.ReembolsoPassosStatus, TM1.ReembolsoPassosSLALembrete FROM ReembolsoPassos TM1 WHERE TM1.ReembolsoPassos = :ReembolsoPassos ORDER BY TM1.ReembolsoPassos ",true, GxErrorMask.GX_NOMASK, false, this,prmT002L4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002L5", "SELECT ReembolsoPassos FROM ReembolsoPassos WHERE ReembolsoPassos = :ReembolsoPassos ",true, GxErrorMask.GX_NOMASK, false, this,prmT002L5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002L6", "SELECT ReembolsoPassos FROM ReembolsoPassos WHERE ( ReembolsoPassos > :ReembolsoPassos) ORDER BY ReembolsoPassos ",true, GxErrorMask.GX_NOMASK, false, this,prmT002L6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002L7", "SELECT ReembolsoPassos FROM ReembolsoPassos WHERE ( ReembolsoPassos < :ReembolsoPassos) ORDER BY ReembolsoPassos DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT002L7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002L8", "SAVEPOINT gxupdate;INSERT INTO ReembolsoPassos(ReembolsoPassos, ReembolsoPassosNome, ReembolsoPassosStatus, ReembolsoPassosSLALembrete) VALUES(:ReembolsoPassos, :ReembolsoPassosNome, :ReembolsoPassosStatus, :ReembolsoPassosSLALembrete);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT002L8)
             ,new CursorDef("T002L9", "SAVEPOINT gxupdate;UPDATE ReembolsoPassos SET ReembolsoPassosNome=:ReembolsoPassosNome, ReembolsoPassosStatus=:ReembolsoPassosStatus, ReembolsoPassosSLALembrete=:ReembolsoPassosSLALembrete  WHERE ReembolsoPassos = :ReembolsoPassos;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002L9)
             ,new CursorDef("T002L10", "SAVEPOINT gxupdate;DELETE FROM ReembolsoPassos  WHERE ReembolsoPassos = :ReembolsoPassos;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002L10)
             ,new CursorDef("T002L11", "SELECT ReembolsoPassos FROM ReembolsoPassos ORDER BY ReembolsoPassos ",true, GxErrorMask.GX_NOMASK, false, this,prmT002L11,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((short[]) buf[5])[0] = rslt.getShort(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((short[]) buf[5])[0] = rslt.getShort(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((short[]) buf[5])[0] = rslt.getShort(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
